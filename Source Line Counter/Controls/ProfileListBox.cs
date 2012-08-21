#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace SourceLineCounter.Controls
{
    internal partial class ProfileListBox : UserControl
    {
        private List<LanguageProfile> _profiles = new List<LanguageProfile>();

        public ProfileListBox()
        {
            InitializeComponent();
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool AllSelected
        {
            get { return profilesList.SelectedItems.Count == profilesList.Items.Count; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool NoneSelected
        {
            get { return profilesList.SelectedItems.Count == 0; }
        }

        public bool MultiSelect
        {
            get { return profilesList.SelectionMode == SelectionMode.MultiSimple; }
            set
            {
                if (value)
                    profilesList.SelectionMode = SelectionMode.MultiSimple;
                else
                    profilesList.SelectionMode = SelectionMode.One;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public int Count
        {
            get { return profilesList.Items.Count; }
        }

        public void Populate(IEnumerable<LanguageProfile> profiles, bool retainSelectedItems)
        {
            _profiles = new List<LanguageProfile>(profiles);
            PopulateInternal(retainSelectedItems);
        }

        public void Sort()
        {
            Sort((p1, p2) => p2.Name != null ? (p1.Name != null ? p1.Name.CompareTo(p2.Name) : 0) : 0);
        }

        public void Sort(Comparison<LanguageProfile> comparison)
        {
            _profiles.Sort(comparison);
            PopulateInternal(true);
        }

        public LanguageProfile GetSelectedProfile()
        {
            return GetSelectedProfiles().Count > 0 ? GetSelectedProfiles()[0] : null;
        }

        public List<LanguageProfile> GetSelectedProfiles()
        {
            var selectedprofiles = new List<LanguageProfile>();

            foreach (int index in profilesList.SelectedIndices)
            {
                var profile = _profiles[index];
                selectedprofiles.Add(profile);
            }

            return selectedprofiles;
        }

        public LanguageProfile GetProfileFromIndex(int index)
        {
            return _profiles.Count > index ? _profiles[index] : null;
        }

        public void SelectAll()
        {
            profilesList.BeginUpdate();

            for (var i = profilesList.Items.Count - 1; i >= 0; i--)
            {
                profilesList.SetSelected(i, true);
            }

            profilesList.EndUpdate();
        }

        public void UnSelectAll()
        {
            profilesList.BeginUpdate();

            for (var i = profilesList.Items.Count - 1; i >= 0; i--)
            {
                profilesList.SetSelected(i, false);
            }

            profilesList.EndUpdate();
        }

        public void Select(int index)
        {
            profilesList.SetSelected(index, true);
        }

        public void Select(LanguageProfile profile)
        {
            var index = _profiles.IndexOf(profile);

            if (index > -1)
            {
                Select(index);
            }
        }

        public void Add(LanguageProfile profile)
        {
            _profiles.Add(profile);
            PopulateInternal(true);
        }

        public void Remove(LanguageProfile profile)
        {
            var index = _profiles.IndexOf(profile);

            if (index > -1)
            {
                profilesList.Items.RemoveAt(index);
                profilesList.SelectedIndex = index > 0 ? index - 1 : 0;
                _profiles.Remove(profile);
                PopulateInternal(true);
            }
        }

        private void PopulateInternal(bool retainSelectedItems)
        {
            var selectedIDs = new List<long>();

            if (retainSelectedItems)
            {
                foreach (var profile in GetSelectedProfiles())
                {
                    if (profile.ID.HasValue)
                    {
                        selectedIDs.Add(profile.ID.Value);
                    }
                }
            }

            profilesList.Items.Clear();

            foreach (var profile in _profiles)
            {
                profilesList.Items.Add(profile.Name);
            }

            if (retainSelectedItems)
            {
                for (var i = 0; i < profilesList.Items.Count; i++)
                {
                    var profile = GetProfileFromIndex(i);
                    if (profile.ID != null && (profile != null && selectedIDs.Contains(profile.ID.Value)))
                        profilesList.SetSelected(i, true);
                }
            }

            if (SelectedIndexChanged != null)
                SelectedIndexChanged(this, EventArgs.Empty);
        }

        public event EventHandler SelectedIndexChanged;

        private void profilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(this, EventArgs.Empty);
        }
    }
}