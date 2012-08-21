using BrightIdeasSoftware;
using SourceLineCounter.Controls;

namespace SourceLineCounter.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.folderbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPreprocessorLines = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalBytes = new System.Windows.Forms.Label();
            this.lblStatsDisplay = new System.Windows.Forms.LinkLabel();
            this.lblExecutionTime = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCodeLines = new System.Windows.Forms.Label();
            this.lblEmptyLines = new System.Windows.Forms.Label();
            this.lblCommentedLines = new System.Windows.Forms.Label();
            this.lblTotalLines = new System.Windows.Forms.Label();
            this.lblTotalFiles = new System.Windows.Forms.Label();
            this.pbSourceGraph = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.filebtn = new System.Windows.Forms.Button();
            this.profilesbtn = new System.Windows.Forms.Button();
            this.profileList = new ProfileListBox();
            this.selectbtn = new System.Windows.Forms.Button();
            this.unselectbtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNoStats = new System.Windows.Forms.Label();
            this.pbLanguageUsage = new System.Windows.Forms.PictureBox();
            this.SourceFileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openInWindowsExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblprogress = new System.Windows.Forms.Label();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.fileListView = new BrightIdeasSoftware.ObjectListView();
            this.olvColFilename = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColFiletype = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColProfile = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColTotalLines = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCommentLInes = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColEmptyLines = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCodeLines = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColSize = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColModified = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDirectory = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.fileIconList = new System.Windows.Forms.ImageList(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.languageUsageTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.timerExecution = new System.Windows.Forms.Timer(this.components);
            this.txtPaths = new SourceLineCounter.Controls.TextBoxExtended();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSourceGraph)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLanguageUsage)).BeginInit();
            this.SourceFileMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileListView)).BeginInit();
            this.SuspendLayout();
            // 
            // folderbtn
            // 
            this.folderbtn.Location = new System.Drawing.Point(12, 117);
            this.folderbtn.Name = "folderbtn";
            this.folderbtn.Size = new System.Drawing.Size(93, 23);
            this.folderbtn.TabIndex = 17;
            this.folderbtn.Text = "Add Folder";
            this.folderbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.folderbtn.UseVisualStyleBackColor = true;
            this.folderbtn.Click += new System.EventHandler(this.folderbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Source files and/or directories (one path per line):";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblPreprocessorLines);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblTotalBytes);
            this.groupBox1.Controls.Add(this.lblStatsDisplay);
            this.groupBox1.Controls.Add(this.lblExecutionTime);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblCodeLines);
            this.groupBox1.Controls.Add(this.lblEmptyLines);
            this.groupBox1.Controls.Add(this.lblCommentedLines);
            this.groupBox1.Controls.Add(this.lblTotalLines);
            this.groupBox1.Controls.Add(this.lblTotalFiles);
            this.groupBox1.Controls.Add(this.pbSourceGraph);
            this.groupBox1.Location = new System.Drawing.Point(831, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 204);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cumulative Stats:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Preprocessor Lines:";
            // 
            // lblPreprocessorLines
            // 
            this.lblPreprocessorLines.AutoSize = true;
            this.lblPreprocessorLines.Location = new System.Drawing.Point(110, 119);
            this.lblPreprocessorLines.Name = "lblPreprocessorLines";
            this.lblPreprocessorLines.Size = new System.Drawing.Size(13, 13);
            this.lblPreprocessorLines.TabIndex = 41;
            this.lblPreprocessorLines.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Total Bytes:";
            // 
            // lblTotalBytes
            // 
            this.lblTotalBytes.AutoSize = true;
            this.lblTotalBytes.Location = new System.Drawing.Point(110, 59);
            this.lblTotalBytes.Name = "lblTotalBytes";
            this.lblTotalBytes.Size = new System.Drawing.Size(13, 13);
            this.lblTotalBytes.TabIndex = 39;
            this.lblTotalBytes.Text = "0";
            // 
            // lblStatsDisplay
            // 
            this.lblStatsDisplay.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lblStatsDisplay.AutoSize = true;
            this.lblStatsDisplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStatsDisplay.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblStatsDisplay.Location = new System.Drawing.Point(94, 0);
            this.lblStatsDisplay.Name = "lblStatsDisplay";
            this.lblStatsDisplay.Size = new System.Drawing.Size(62, 13);
            this.lblStatsDisplay.TabIndex = 38;
            this.lblStatsDisplay.TabStop = true;
            this.lblStatsDisplay.Text = "View Graph";
            this.lblStatsDisplay.Click += new System.EventHandler(this.lblStatsDisplay_Click);
            // 
            // lblExecutionTime
            // 
            this.lblExecutionTime.AutoSize = true;
            this.lblExecutionTime.Location = new System.Drawing.Point(110, 19);
            this.lblExecutionTime.Name = "lblExecutionTime";
            this.lblExecutionTime.Size = new System.Drawing.Size(13, 13);
            this.lblExecutionTime.TabIndex = 35;
            this.lblExecutionTime.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Execution Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Lines of Code:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Empty Lines:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Comment Lines:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Total Lines:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Total Files:";
            // 
            // lblCodeLines
            // 
            this.lblCodeLines.AutoSize = true;
            this.lblCodeLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodeLines.Location = new System.Drawing.Point(110, 159);
            this.lblCodeLines.Name = "lblCodeLines";
            this.lblCodeLines.Size = new System.Drawing.Size(14, 13);
            this.lblCodeLines.TabIndex = 26;
            this.lblCodeLines.Text = "0";
            // 
            // lblEmptyLines
            // 
            this.lblEmptyLines.AutoSize = true;
            this.lblEmptyLines.Location = new System.Drawing.Point(110, 139);
            this.lblEmptyLines.Name = "lblEmptyLines";
            this.lblEmptyLines.Size = new System.Drawing.Size(13, 13);
            this.lblEmptyLines.TabIndex = 25;
            this.lblEmptyLines.Text = "0";
            // 
            // lblCommentedLines
            // 
            this.lblCommentedLines.AutoSize = true;
            this.lblCommentedLines.Location = new System.Drawing.Point(110, 99);
            this.lblCommentedLines.Name = "lblCommentedLines";
            this.lblCommentedLines.Size = new System.Drawing.Size(13, 13);
            this.lblCommentedLines.TabIndex = 24;
            this.lblCommentedLines.Text = "0";
            // 
            // lblTotalLines
            // 
            this.lblTotalLines.AutoSize = true;
            this.lblTotalLines.Location = new System.Drawing.Point(110, 79);
            this.lblTotalLines.Name = "lblTotalLines";
            this.lblTotalLines.Size = new System.Drawing.Size(13, 13);
            this.lblTotalLines.TabIndex = 23;
            this.lblTotalLines.Text = "0";
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.AutoSize = true;
            this.lblTotalFiles.Location = new System.Drawing.Point(110, 39);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(13, 13);
            this.lblTotalFiles.TabIndex = 22;
            this.lblTotalFiles.Text = "0";
            // 
            // pbSourceGraph
            // 
            this.pbSourceGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSourceGraph.Location = new System.Drawing.Point(3, 16);
            this.pbSourceGraph.Name = "pbSourceGraph";
            this.pbSourceGraph.Size = new System.Drawing.Size(246, 185);
            this.pbSourceGraph.TabIndex = 37;
            this.pbSourceGraph.TabStop = false;
            this.pbSourceGraph.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(12, 146);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(153, 30);
            this.btnStart.TabIndex = 21;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Profiles:";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 202);
            this.progressBar1.MarqueeAnimationSpeed = 60;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(507, 14);
            this.progressBar1.TabIndex = 26;
            this.progressBar1.Visible = false;
            // 
            // filebtn
            // 
            this.filebtn.Location = new System.Drawing.Point(111, 117);
            this.filebtn.Name = "filebtn";
            this.filebtn.Size = new System.Drawing.Size(93, 23);
            this.filebtn.TabIndex = 29;
            this.filebtn.Text = "Add File(s)";
            this.filebtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.filebtn.UseVisualStyleBackColor = true;
            this.filebtn.Click += new System.EventHandler(this.filebtn_Click);
            // 
            // profilesbtn
            // 
            this.profilesbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.profilesbtn.Location = new System.Drawing.Point(333, 146);
            this.profilesbtn.Name = "profilesbtn";
            this.profilesbtn.Size = new System.Drawing.Size(186, 23);
            this.profilesbtn.TabIndex = 30;
            this.profilesbtn.Text = "Manage Profiles";
            this.profilesbtn.UseVisualStyleBackColor = true;
            this.profilesbtn.Click += new System.EventHandler(this.ManageProfiles);
            // 
            // profileList
            // 
            this.profileList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.profileList.Location = new System.Drawing.Point(333, 25);
            this.profileList.Name = "profileList";
            this.profileList.Size = new System.Drawing.Size(186, 82);
            this.profileList.TabIndex = 33;
            this.profileList.SelectedIndexChanged += new System.EventHandler(this.profileList_SelectedIndexChanged);
            // 
            // selectbtn
            // 
            this.selectbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectbtn.Location = new System.Drawing.Point(333, 117);
            this.selectbtn.Name = "selectbtn";
            this.selectbtn.Size = new System.Drawing.Size(90, 23);
            this.selectbtn.TabIndex = 34;
            this.selectbtn.Text = "Select All";
            this.selectbtn.UseVisualStyleBackColor = true;
            this.selectbtn.Click += new System.EventHandler(this.selectbtn_Click);
            // 
            // unselectbtn
            // 
            this.unselectbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unselectbtn.Enabled = false;
            this.unselectbtn.Location = new System.Drawing.Point(429, 117);
            this.unselectbtn.Name = "unselectbtn";
            this.unselectbtn.Size = new System.Drawing.Size(90, 23);
            this.unselectbtn.TabIndex = 35;
            this.unselectbtn.Text = "Unselect All";
            this.unselectbtn.UseVisualStyleBackColor = true;
            this.unselectbtn.Click += new System.EventHandler(this.unselectbtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblNoStats);
            this.groupBox2.Controls.Add(this.pbLanguageUsage);
            this.groupBox2.Location = new System.Drawing.Point(525, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 204);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Language Usage:";
            // 
            // lblNoStats
            // 
            this.lblNoStats.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoStats.AutoSize = true;
            this.lblNoStats.Location = new System.Drawing.Point(107, 96);
            this.lblNoStats.Name = "lblNoStats";
            this.lblNoStats.Size = new System.Drawing.Size(93, 13);
            this.lblNoStats.TabIndex = 41;
            this.lblNoStats.Text = "No stats to display";
            // 
            // pbLanguageUsage
            // 
            this.pbLanguageUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLanguageUsage.Location = new System.Drawing.Point(3, 16);
            this.pbLanguageUsage.Name = "pbLanguageUsage";
            this.pbLanguageUsage.Size = new System.Drawing.Size(297, 185);
            this.pbLanguageUsage.TabIndex = 0;
            this.pbLanguageUsage.TabStop = false;
            this.pbLanguageUsage.MouseLeave += new System.EventHandler(this.pbLanguageUsage_MouseLeave);
            this.pbLanguageUsage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbLanguageUsage_MouseMove);
            // 
            // SourceFileMenu
            // 
            this.SourceFileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInWindowsExplorerToolStripMenuItem});
            this.SourceFileMenu.Name = "SourceFileMenu";
            this.SourceFileMenu.ShowImageMargin = false;
            this.SourceFileMenu.ShowItemToolTips = false;
            this.SourceFileMenu.Size = new System.Drawing.Size(189, 26);
            // 
            // openInWindowsExplorerToolStripMenuItem
            // 
            this.openInWindowsExplorerToolStripMenuItem.Name = "openInWindowsExplorerToolStripMenuItem";
            this.openInWindowsExplorerToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.openInWindowsExplorerToolStripMenuItem.Text = "Open in Windows Explorer";
            this.openInWindowsExplorerToolStripMenuItem.Click += new System.EventHandler(this.openInWindowsExplorerToolStripMenuItem_Click);
            // 
            // lblprogress
            // 
            this.lblprogress.AutoEllipsis = true;
            this.lblprogress.Location = new System.Drawing.Point(12, 186);
            this.lblprogress.Name = "lblprogress";
            this.lblprogress.Size = new System.Drawing.Size(507, 13);
            this.lblprogress.TabIndex = 40;
            this.lblprogress.Text = "lblprogress";
            this.lblprogress.Visible = false;
            // 
            // chkRecursive
            // 
            this.chkRecursive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Checked = true;
            this.chkRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecursive.Location = new System.Drawing.Point(253, 121);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(74, 17);
            this.chkRecursive.TabIndex = 41;
            this.chkRecursive.Text = "Recursive";
            this.chkRecursive.UseVisualStyleBackColor = true;
            // 
            // fileListView
            // 
            this.fileListView.AllColumns.Add(this.olvColFilename);
            this.fileListView.AllColumns.Add(this.olvColFiletype);
            this.fileListView.AllColumns.Add(this.olvColProfile);
            this.fileListView.AllColumns.Add(this.olvColTotalLines);
            this.fileListView.AllColumns.Add(this.olvColCommentLInes);
            this.fileListView.AllColumns.Add(this.olvColEmptyLines);
            this.fileListView.AllColumns.Add(this.olvColCodeLines);
            this.fileListView.AllColumns.Add(this.olvColSize);
            this.fileListView.AllColumns.Add(this.olvColModified);
            this.fileListView.AllColumns.Add(this.olvColDirectory);
            this.fileListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColFilename,
            this.olvColFiletype,
            this.olvColProfile,
            this.olvColTotalLines,
            this.olvColCommentLInes,
            this.olvColEmptyLines,
            this.olvColCodeLines,
            this.olvColSize,
            this.olvColModified,
            this.olvColDirectory});
            this.fileListView.FullRowSelect = true;
            this.fileListView.GridLines = true;
            this.fileListView.Location = new System.Drawing.Point(12, 222);
            this.fileListView.Name = "fileListView";
            this.fileListView.ShowGroups = false;
            this.fileListView.Size = new System.Drawing.Size(1071, 298);
            this.fileListView.SmallImageList = this.fileIconList;
            this.fileListView.TabIndex = 42;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            this.fileListView.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.fileListView_CellRightClick);
            // 
            // olvColFilename
            // 
            this.olvColFilename.Text = "Filename";
            this.olvColFilename.Width = 127;
            // 
            // olvColFiletype
            // 
            this.olvColFiletype.Text = "Filetype";
            this.olvColFiletype.Width = 97;
            // 
            // olvColProfile
            // 
            this.olvColProfile.Text = "Profile";
            this.olvColProfile.Width = 96;
            // 
            // olvColTotalLines
            // 
            this.olvColTotalLines.AspectToStringFormat = "{0:N0}";
            this.olvColTotalLines.Text = "Total Lines";
            this.olvColTotalLines.Width = 105;
            // 
            // olvColCommentLInes
            // 
            this.olvColCommentLInes.AspectToStringFormat = "{0:N0}";
            this.olvColCommentLInes.Text = "Comment Lines";
            this.olvColCommentLInes.Width = 114;
            // 
            // olvColEmptyLines
            // 
            this.olvColEmptyLines.AspectToStringFormat = "{0:N0}";
            this.olvColEmptyLines.Text = "Empty Lines";
            this.olvColEmptyLines.Width = 107;
            // 
            // olvColCodeLines
            // 
            this.olvColCodeLines.AspectToStringFormat = "{0:N0}";
            this.olvColCodeLines.Text = "Lines of Code";
            this.olvColCodeLines.Width = 106;
            // 
            // olvColSize
            // 
            this.olvColSize.AspectToStringFormat = "{0:N0}";
            this.olvColSize.Text = "Size (bytes)";
            this.olvColSize.Width = 86;
            // 
            // olvColModified
            // 
            this.olvColModified.Text = "Last Modified";
            this.olvColModified.Width = 152;
            // 
            // olvColDirectory
            // 
            this.olvColDirectory.Text = "Directory";
            // 
            // fileIconList
            // 
            this.fileIconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.fileIconList.ImageSize = new System.Drawing.Size(16, 16);
            this.fileIconList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(12, 147);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(153, 30);
            this.btnStop.TabIndex = 43;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // timerExecution
            // 
            this.timerExecution.Tick += new System.EventHandler(this.timerExecution_Tick);
            // 
            // txtPaths
            // 
            this.txtPaths.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaths.Location = new System.Drawing.Point(12, 25);
            this.txtPaths.Multiline = true;
            this.txtPaths.Name = "txtPaths";
            this.txtPaths.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPaths.Size = new System.Drawing.Size(315, 86);
            this.txtPaths.TabIndex = 18;
            this.txtPaths.Text = "D:\\Visual Studio\\Projects\\Tabster\\Tabster\\Program.cs";
            this.txtPaths.WordWrap = false;
            this.txtPaths.TextChanged += new System.EventHandler(this.txtPaths_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 532);
            this.Controls.Add(this.fileListView);
            this.Controls.Add(this.chkRecursive);
            this.Controls.Add(this.lblprogress);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.unselectbtn);
            this.Controls.Add(this.selectbtn);
            this.Controls.Add(this.profileList);
            this.Controls.Add(this.profilesbtn);
            this.Controls.Add(this.filebtn);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPaths);
            this.Controls.Add(this.folderbtn);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1100, 510);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Source Line Counter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSourceGraph)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLanguageUsage)).EndInit();
            this.SourceFileMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button folderbtn;
        private TextBoxExtended txtPaths;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblTotalLines;
        private System.Windows.Forms.Label lblTotalFiles;
        private System.Windows.Forms.Label lblEmptyLines;
        private System.Windows.Forms.Label lblCommentedLines;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button filebtn;
        private System.Windows.Forms.Button profilesbtn;
        private System.Windows.Forms.Label lblCodeLines;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ProfileListBox profileList;
        private System.Windows.Forms.Button selectbtn;
        private System.Windows.Forms.Button unselectbtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblExecutionTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbLanguageUsage;
        private System.Windows.Forms.PictureBox pbSourceGraph;
        private System.Windows.Forms.LinkLabel lblStatsDisplay;
        private System.Windows.Forms.ContextMenuStrip SourceFileMenu;
        private System.Windows.Forms.ToolStripMenuItem openInWindowsExplorerToolStripMenuItem;
        private System.Windows.Forms.Label lblprogress;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalBytes;
        private System.Windows.Forms.Label lblNoStats;
        private ObjectListView fileListView;
        private OLVColumn olvColFilename;
        private OLVColumn olvColFiletype;
        private OLVColumn olvColProfile;
        private OLVColumn olvColSize;
        private OLVColumn olvColModified;
        private OLVColumn olvColTotalLines;
        private OLVColumn olvColCommentLInes;
        private OLVColumn olvColEmptyLines;
        private OLVColumn olvColCodeLines;
        private OLVColumn olvColDirectory;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ToolTip languageUsageTooltip;
        private System.Windows.Forms.ImageList fileIconList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPreprocessorLines;
        private System.Windows.Forms.Timer timerExecution;
    }
}

