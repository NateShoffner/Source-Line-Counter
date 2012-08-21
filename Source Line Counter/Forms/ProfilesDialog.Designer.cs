namespace SourceLineCounter.Forms
{
    partial class ProfilesDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExtensions = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.closebtn = new System.Windows.Forms.Button();
            this.txtmultistart = new System.Windows.Forms.TextBox();
            this.txtSingleComments = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtmultiend = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.deletebtn = new System.Windows.Forms.Button();
            this.newbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.chkInlineComments = new System.Windows.Forms.CheckBox();
            this.chkInterspersedComments = new System.Windows.Forms.CheckBox();
            this.txtPreprocessors = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.profilesList = new SourceLineCounter.Controls.ProfileListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Language Name: ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(303, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(173, 20);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.ValidateInput);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 26);
            this.label2.TabIndex = 23;
            this.label2.Text = "File Extension(s):\r\n(one per line)";
            // 
            // txtExtensions
            // 
            this.txtExtensions.Location = new System.Drawing.Point(303, 35);
            this.txtExtensions.Multiline = true;
            this.txtExtensions.Name = "txtExtensions";
            this.txtExtensions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExtensions.Size = new System.Drawing.Size(173, 61);
            this.txtExtensions.TabIndex = 1;
            this.txtExtensions.TextChanged += new System.EventHandler(this.ValidateInput);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 26);
            this.label3.TabIndex = 25;
            this.label3.Text = "Comment Symbol(s):\r\n(one per line)";
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closebtn.Location = new System.Drawing.Point(401, 355);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(75, 23);
            this.closebtn.TabIndex = 6;
            this.closebtn.Text = "&Close";
            this.closebtn.UseVisualStyleBackColor = true;
            // 
            // txtmultistart
            // 
            this.txtmultistart.Location = new System.Drawing.Point(382, 241);
            this.txtmultistart.Name = "txtmultistart";
            this.txtmultistart.Size = new System.Drawing.Size(94, 20);
            this.txtmultistart.TabIndex = 4;
            this.txtmultistart.TextChanged += new System.EventHandler(this.ValidateInput);
            // 
            // txtSingleComments
            // 
            this.txtSingleComments.Location = new System.Drawing.Point(303, 102);
            this.txtSingleComments.Multiline = true;
            this.txtSingleComments.Name = "txtSingleComments";
            this.txtSingleComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSingleComments.Size = new System.Drawing.Size(173, 61);
            this.txtSingleComments.TabIndex = 3;
            this.txtSingleComments.TextChanged += new System.EventHandler(this.ValidateInput);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Multi-line Comment Symbol(s):\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Start:";
            // 
            // txtmultiend
            // 
            this.txtmultiend.Location = new System.Drawing.Point(382, 270);
            this.txtmultiend.Name = "txtmultiend";
            this.txtmultiend.Size = new System.Drawing.Size(94, 20);
            this.txtmultiend.TabIndex = 5;
            this.txtmultiend.TextChanged += new System.EventHandler(this.ValidateInput);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(345, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "End:";
            // 
            // deletebtn
            // 
            this.deletebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deletebtn.Location = new System.Drawing.Point(12, 355);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(75, 23);
            this.deletebtn.TabIndex = 36;
            this.deletebtn.Text = "&Delete";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // newbtn
            // 
            this.newbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newbtn.Location = new System.Drawing.Point(93, 355);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(75, 23);
            this.newbtn.TabIndex = 37;
            this.newbtn.Text = "&New";
            this.newbtn.UseVisualStyleBackColor = true;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.savebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(382, 315);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(94, 23);
            this.savebtn.TabIndex = 38;
            this.savebtn.Text = "&Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // chkInlineComments
            // 
            this.chkInlineComments.AutoSize = true;
            this.chkInlineComments.Enabled = false;
            this.chkInlineComments.Location = new System.Drawing.Point(174, 296);
            this.chkInlineComments.Name = "chkInlineComments";
            this.chkInlineComments.Size = new System.Drawing.Size(172, 17);
            this.chkInlineComments.TabIndex = 39;
            this.chkInlineComments.Text = "Allow inline multi-line comments";
            this.chkInlineComments.UseVisualStyleBackColor = true;
            // 
            // chkInterspersedComments
            // 
            this.chkInterspersedComments.AutoSize = true;
            this.chkInterspersedComments.Enabled = false;
            this.chkInterspersedComments.Location = new System.Drawing.Point(174, 319);
            this.chkInterspersedComments.Name = "chkInterspersedComments";
            this.chkInterspersedComments.Size = new System.Drawing.Size(162, 17);
            this.chkInterspersedComments.TabIndex = 40;
            this.chkInterspersedComments.Text = "Allow interspersed comments";
            this.chkInterspersedComments.UseVisualStyleBackColor = true;
            // 
            // txtPreprocessors
            // 
            this.txtPreprocessors.Location = new System.Drawing.Point(303, 169);
            this.txtPreprocessors.Multiline = true;
            this.txtPreprocessors.Name = "txtPreprocessors";
            this.txtPreprocessors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPreprocessors.Size = new System.Drawing.Size(173, 61);
            this.txtPreprocessors.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 26);
            this.label7.TabIndex = 42;
            this.label7.Text = "Preprocessor Directive(s):\r\n(one per line)";
            // 
            // profilesList
            // 
            this.profilesList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.profilesList.Location = new System.Drawing.Point(12, 9);
            this.profilesList.MultiSelect = false;
            this.profilesList.Name = "profilesList";
            this.profilesList.Size = new System.Drawing.Size(156, 340);
            this.profilesList.TabIndex = 43;
            this.profilesList.SelectedIndexChanged += new System.EventHandler(this.profileList_SelectedIndexChanged);
            // 
            // ProfilesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closebtn;
            this.ClientSize = new System.Drawing.Size(489, 390);
            this.Controls.Add(this.profilesList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPreprocessors);
            this.Controls.Add(this.chkInterspersedComments);
            this.Controls.Add(this.chkInlineComments);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.deletebtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtmultiend);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSingleComments);
            this.Controls.Add(this.txtmultistart);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtExtensions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfilesDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profiles";
            this.Load += new System.EventHandler(this.ProfilesDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExtensions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.TextBox txtmultistart;
        private System.Windows.Forms.TextBox txtSingleComments;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtmultiend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Button newbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.CheckBox chkInlineComments;
        private System.Windows.Forms.CheckBox chkInterspersedComments;
        private System.Windows.Forms.TextBox txtPreprocessors;
        private System.Windows.Forms.Label label7;
        private Controls.ProfileListBox profilesList;
    }
}