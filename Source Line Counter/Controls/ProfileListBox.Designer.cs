namespace SourceLineCounter.Controls
{
    partial class ProfileListBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.profilesList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // profilesList
            // 
            this.profilesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilesList.FormattingEnabled = true;
            this.profilesList.Location = new System.Drawing.Point(0, 0);
            this.profilesList.Name = "profilesList";
            this.profilesList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.profilesList.Size = new System.Drawing.Size(150, 150);
            this.profilesList.TabIndex = 36;
            this.profilesList.SelectedIndexChanged += new System.EventHandler(this.profilesList_SelectedIndexChanged);
            // 
            // ProfileListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.profilesList);
            this.Name = "ProfileListBox";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox profilesList;
    }
}
