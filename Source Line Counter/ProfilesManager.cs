#region

using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using SQLiteID = System.Int64;

#endregion

namespace SourceLineCounter
{
    internal class ProfileManager : IEnumerable<LanguageProfile>
    {
        private const string Tableprofiles = "language_profiles";
        private const string TableExtensions = "language_extensions";
        private const string TableCommentIndicators = "language_comment_indicators";
        private const string TablePreprocessors = "language_preprocessors";

        private readonly SQLiteConnection _db;
        private readonly List<LanguageProfile> _profiles = new List<LanguageProfile>();

        public ProfileManager(string dbName)
        {
            _db = new SQLiteConnection(string.Format("Data Source={0};Version=3;Compress=True;", dbName));
            _db.Open();

            CreateTables();
        }

        #region Implementation of IEnumerable

        public IEnumerator<LanguageProfile> GetEnumerator()
        {
            return ((IEnumerable<LanguageProfile>) _profiles).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        public void Upsert(LanguageProfile profile)
        {
            var newProfile = !profile.ID.HasValue;

            using (var cmd = _db.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format(@"INSERT OR REPLACE INTO {0} (id, name, inline_comments, interspersed_comments)
                                                  VALUES (@id, @name, @inline_comments, @interspersed_comments)", Tableprofiles);
                cmd.Parameters.Add(new SQLiteParameter("@id", profile.ID));
                cmd.Parameters.Add(new SQLiteParameter("@name", profile.Name));
                cmd.Parameters.Add(new SQLiteParameter("@inline_comments", profile.AllowInlineComments));
                cmd.Parameters.Add(new SQLiteParameter("@interspersed_comments", profile.AllowInterspersedComments));
                var reader = cmd.ExecuteReader();
                reader.Close();

                profile.ID = _db.LastInsertRowId;
            }

            //should probably do this a bit cleaner
            DeleteExtensions(profile.ID.Value);
            DeleteCommentIndicators(profile.ID.Value);
            DeletePreprocessers(profile.ID.Value);

            //file extensions
            foreach (var extension in profile.Extensions)
            {
                using (var cmd = _db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format("INSERT INTO {0} (profile_id, extension) VALUES (@profile_id, @extension)", TableExtensions);
                    cmd.Parameters.Add(new SQLiteParameter("@profile_id", profile.ID));
                    cmd.Parameters.Add(new SQLiteParameter("@extension", extension));
                    var reader = cmd.ExecuteReader();
                    reader.Close();
                }
            }

            //comment indicators
            foreach (var indicator in profile.CommentIndicators)
            {
                using (var cmd = _db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format(@"INSERT INTO {0} (profile_id, start_indicator, end_indicator, multiline) 
                                                    VALUES (@profile_id, @start_indicator, @end_indicator, @multiline)", TableCommentIndicators);
                    cmd.Parameters.Add(new SQLiteParameter("@profile_id", profile.ID));
                    cmd.Parameters.Add(new SQLiteParameter("@start_indicator", indicator.StartIndicator));
                    cmd.Parameters.Add(new SQLiteParameter("@end_indicator", indicator.EndIndicator));
                    cmd.Parameters.Add(new SQLiteParameter("@multiline", indicator.Multiline));
                    var reader = cmd.ExecuteReader();
                    reader.Close();
                }
            }

            //preprocessors
            foreach (var preprocessor in profile.Preprocessors)
            {
                using (var cmd = _db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = string.Format(@"INSERT INTO {0} (profile_id, preprocessor)
                                                    VALUES (@profile_id, @preprocessor)", TablePreprocessors);
                    cmd.Parameters.Add(new SQLiteParameter("@profile_id", profile.ID));
                    cmd.Parameters.Add(new SQLiteParameter("@preprocessor", preprocessor));
                    var reader = cmd.ExecuteReader();
                    reader.Close();
                }
            }

            if (newProfile)
                _profiles.Add(profile);
        }

        public void Remove(LanguageProfile profile)
        {
            if (!profile.ID.HasValue)
                return;

            using (var cmd = new SQLiteCommand(string.Format("DELETE FROM {0} WHERE id={1}", Tableprofiles, profile.ID), _db))
            {
                cmd.ExecuteNonQuery();
            }

            DeleteExtensions(profile.ID.Value);
            DeleteCommentIndicators(profile.ID.Value);
            DeletePreprocessers(profile.ID.Value);
        }

        public void Load()
        {
            _profiles.Clear();

            using (var cmd = new SQLiteCommand(string.Format("SELECT * FROM {0}", Tableprofiles), _db))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = SQLiteID.Parse(reader["id"].ToString());
                        var name = reader["name"].ToString();
                        var inlineComments = bool.Parse(reader["inline_comments"].ToString());
                        var interspersedComments = bool.Parse(reader["interspersed_comments"].ToString());

                        var extensions = GetprofileExtensions(id);
                        var commentIndicators = GetCommentIndicators(id);
                        var preprocessors = GetPreprocessors(id);

                        var profile = new LanguageProfile
                        {
                            ID = id,
                            Name = name,
                            Extensions = extensions,
                            CommentIndicators = commentIndicators,
                            Preprocessors = preprocessors,
                            AllowInlineComments = inlineComments,
                            AllowInterspersedComments = interspersedComments
                        };

                        _profiles.Add(profile);
                    }
                }
            }

            _profiles.Sort((p1, p2) => string.CompareOrdinal(p1.Name, p2.Name));
        }

        private string[] GetprofileExtensions(SQLiteID id)
        {
            var extensions = new List<string>();

            using (var cmd = new SQLiteCommand(string.Format("SELECT * FROM {0} WHERE profile_id={1}", TableExtensions, id), _db))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        extensions.Add(reader["extension"].ToString());
                    }
                }
            }

            return extensions.ToArray();
        }

        private LanguageCommentIndicator[] GetCommentIndicators(SQLiteID id)
        {
            var indicators = new List<LanguageCommentIndicator>();

            using (var cmd = new SQLiteCommand(string.Format("SELECT * FROM {0} WHERE profile_id={1}", TableCommentIndicators, id), _db))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var startIndicator = reader["start_indicator"].ToString();
                        var endIndicator = reader["end_indicator"].ToString();
                        var isMultiline = bool.Parse(reader["multiline"].ToString());

                        var indicator = new LanguageCommentIndicator(startIndicator, endIndicator, isMultiline);
                        indicators.Add(indicator);
                    }
                }
            }

            return indicators.ToArray();
        }

        private string[] GetPreprocessors(SQLiteID id)
        {
            var preprocessors = new List<string>();

            using (var cmd = new SQLiteCommand(string.Format("SELECT * FROM {0} WHERE profile_id={1}", TablePreprocessors, id), _db))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        preprocessors.Add(reader["preprocessor"].ToString());
                    }
                }
            }

            return preprocessors.ToArray();
        }

        private void CreateTables()
        {
            using (var cmd = new SQLiteCommand(string.Format("CREATE TABLE IF NOT EXISTS {0} (id INTEGER PRIMARY KEY, name TEXT, inline_comments BOOLEAN, interspersed_comments BOOLEAN)", Tableprofiles), _db))
            {
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SQLiteCommand(string.Format("CREATE TABLE IF NOT EXISTS {0} (profile_id INTEGER, extension TEXT)", TableExtensions), _db))
            {
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SQLiteCommand(string.Format("CREATE TABLE IF NOT EXISTS {0} (profile_id INTEGER, start_indicator TEXT, end_indicator TEXT, multiline BOOLEAN)", TableCommentIndicators), _db))
            {
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SQLiteCommand(string.Format("CREATE TABLE IF NOT EXISTS {0} (profile_id INTEGER, preprocessor TEXT)", TablePreprocessors), _db))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void DeleteExtensions(long id)
        {
            using (var cmd = new SQLiteCommand(string.Format("DELETE FROM {0} WHERE profile_id={1}", TableExtensions, id), _db))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void DeleteCommentIndicators(long id)
        {
            using (var cmd = new SQLiteCommand(string.Format("DELETE FROM {0} WHERE profile_id={1}", TableCommentIndicators, id), _db))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void DeletePreprocessers(long id)
        {
            using (var cmd = new SQLiteCommand(string.Format("DELETE FROM {0} WHERE profile_id={1}", TablePreprocessors, id), _db))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}