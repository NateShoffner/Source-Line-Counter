#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

#endregion

namespace SourceLineCounter.Forms
{
    internal partial class ProfilesDialog : Form
    {
        private readonly ProfileManager _profileManager;

        public ProfilesDialog(ProfileManager profileManager)
        {
            InitializeComponent();
            _profileManager = profileManager;
        }

        public bool ProfilesModified { get; private set; }

        private void ProfilesDialog_Load(object sender, EventArgs e)
        {
            LoadProfiles();

            if (profilesList.Count > 0)
                profilesList.Select(0);
        }

        private void LoadProfiles()
        {
            profilesList.Populate(_profileManager, true);
            profilesList.Sort();
        }

        private void PopulateFields(LanguageProfile profile)
        {
            if (profile != null)
            {
                txtName.Text = profile.Name;
                txtExtensions.Lines = profile.Extensions;

                var commentBuilder = new StringBuilder();
                foreach (var indicator in profile.CommentIndicators.ToList().FindAll(x => !x.Multiline))
                {
                    commentBuilder.AppendLine(indicator.StartIndicator);
                }
                txtSingleComments.Text = commentBuilder.ToString();

                //todo allow multiple multiline comment rules
                var multilineIndicators = profile.CommentIndicators.ToList().FindAll(x => x.Multiline);
                txtmultistart.Text = multilineIndicators.Count > 0 ? multilineIndicators[0].StartIndicator : "";
                txtmultiend.Text = multilineIndicators.Count > 0 && multilineIndicators[0].HasEndIndicator ? multilineIndicators[0].EndIndicator : "";

                txtPreprocessors.Lines = profile.Preprocessors;

                chkInlineComments.Checked = profile.AllowInlineComments;
                chkInterspersedComments.Checked = profile.AllowInterspersedComments;
            }

            else
            {
                txtName.Text = txtExtensions.Text = txtSingleComments.Text = txtmultistart.Text = txtmultiend.Text = "";
            }
        }

        private void ValidateInput(object sender, EventArgs e)
        {
            savebtn.Enabled = txtName.Text.Length > 0 && txtExtensions.Text.Length > 0;
            chkInlineComments.Enabled = txtmultistart.Text.Length > 0;
            chkInterspersedComments.Enabled = txtmultistart.Text.Length > 0 && txtmultiend.Text.Length > 0;
        }


        private void profileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var profile = profilesList.GetSelectedProfile();

            if (profile != null)
            {
                PopulateFields(profile);
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            var profile = profilesList.GetSelectedProfile();

            if (profile != null)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected profile?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    profilesList.Remove(profile);
                    _profileManager.Remove(profile);
                    ProfilesModified = true;
                }
            }
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            profilesList.UnSelectAll();
            PopulateFields(null);
            txtName.Select();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            var newProfile = profilesList.GetSelectedProfiles().Count == 0;

            var profile = newProfile ? new LanguageProfile() : profilesList.GetSelectedProfile();

            var commentIndicators = new List<LanguageCommentIndicator>();
            commentIndicators.AddRange(txtSingleComments.Lines.Select(indicator => new LanguageCommentIndicator(indicator)));
            commentIndicators.Add(new LanguageCommentIndicator(txtmultistart.Text, txtmultiend.Text, true));

            profile.Name = txtName.Text;
            profile.Extensions = txtExtensions.Lines;
            profile.CommentIndicators = commentIndicators.ToArray();
            profile.Preprocessors = txtPreprocessors.Lines;
            profile.AllowInlineComments = chkInlineComments.Checked;
            profile.AllowInterspersedComments = chkInterspersedComments.Checked;

            _profileManager.Upsert(profile);

            LoadProfiles();

            if (newProfile)
                profilesList.Select(profile);

            ProfilesModified = true;
        }
    }
}