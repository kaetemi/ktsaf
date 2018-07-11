namespace ktsaf
{
	partial class SearchAndFind
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
			this.keywordsText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.locationEntry = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.browseButton = new System.Windows.Forms.Button();
			this.searchButton = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.label3 = new System.Windows.Forms.Label();
			this.strategyDropDown = new System.Windows.Forms.ComboBox();
			this.fileList = new System.Windows.Forms.ListView();
			this.nameHeader = new System.Windows.Forms.ColumnHeader();
			this.folderHeader = new System.Windows.Forms.ColumnHeader();
			this.sizeHeader = new System.Windows.Forms.ColumnHeader();
			this.typeHeader = new System.Windows.Forms.ColumnHeader();
			this.modifiedHeader = new System.Windows.Forms.ColumnHeader();
			this.fileRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openSelectedDirectoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyFullFileNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sizeFilter = new System.Windows.Forms.ComboBox();
			this.fileRightClick.SuspendLayout();
			this.SuspendLayout();
			// 
			// keywordsText
			// 
			this.keywordsText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.keywordsText.Location = new System.Drawing.Point(77, 12);
			this.keywordsText.Name = "keywordsText";
			this.keywordsText.Size = new System.Drawing.Size(470, 20);
			this.keywordsText.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 1000;
			this.label1.Text = "Keywords: ";
			// 
			// locationEntry
			// 
			this.locationEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.locationEntry.Location = new System.Drawing.Point(77, 38);
			this.locationEntry.Name = "locationEntry";
			this.locationEntry.Size = new System.Drawing.Size(314, 20);
			this.locationEntry.TabIndex = 20;
			this.locationEntry.Text = "C:\\";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 1000;
			this.label2.Text = "Search in: ";
			// 
			// browseButton
			// 
			this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseButton.Location = new System.Drawing.Point(397, 36);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(75, 23);
			this.browseButton.TabIndex = 30;
			this.browseButton.Text = "Browse...";
			this.browseButton.UseVisualStyleBackColor = true;
			// 
			// searchButton
			// 
			this.searchButton.Location = new System.Drawing.Point(12, 64);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(75, 23);
			this.searchButton.TabIndex = 50;
			this.searchButton.Text = "Search";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.searchButtonStart);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(93, 64);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(100, 23);
			this.progressBar.TabIndex = 1000;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(199, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(371, 13);
			this.label3.TabIndex = 1000;
			this.label3.Text = "Enter one or more keywords seperated by spaces, and hit Search to find files.";
			// 
			// strategyDropDown
			// 
			this.strategyDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.strategyDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.strategyDropDown.FormattingEnabled = true;
			this.strategyDropDown.Items.AddRange(new object[] {
            "No subdirectories",
            "Iterative (Recommended)",
            "Depth-first"});
			this.strategyDropDown.Location = new System.Drawing.Point(478, 37);
			this.strategyDropDown.Name = "strategyDropDown";
			this.strategyDropDown.Size = new System.Drawing.Size(150, 21);
			this.strategyDropDown.TabIndex = 40;
			// 
			// fileList
			// 
			this.fileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.fileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.folderHeader,
            this.sizeHeader,
            this.typeHeader,
            this.modifiedHeader});
			this.fileList.ContextMenuStrip = this.fileRightClick;
			this.fileList.GridLines = true;
			this.fileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.fileList.LabelWrap = false;
			this.fileList.Location = new System.Drawing.Point(12, 93);
			this.fileList.Name = "fileList";
			this.fileList.ShowGroups = false;
			this.fileList.Size = new System.Drawing.Size(616, 255);
			this.fileList.TabIndex = 60;
			this.fileList.UseCompatibleStateImageBehavior = false;
			this.fileList.View = System.Windows.Forms.View.Details;
			// 
			// nameHeader
			// 
			this.nameHeader.Text = "Name";
			this.nameHeader.Width = 120;
			// 
			// folderHeader
			// 
			this.folderHeader.Text = "Directory";
			this.folderHeader.Width = 240;
			// 
			// sizeHeader
			// 
			this.sizeHeader.Text = "Size";
			this.sizeHeader.Width = 120;
			// 
			// typeHeader
			// 
			this.typeHeader.Text = "Type";
			// 
			// modifiedHeader
			// 
			this.modifiedHeader.Text = "Modified";
			this.modifiedHeader.Width = 120;
			// 
			// fileRightClick
			// 
			this.fileRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSelectedDirectoriesToolStripMenuItem,
            this.copyFullFileNamesToolStripMenuItem});
			this.fileRightClick.Name = "fileRightClick";
			this.fileRightClick.Size = new System.Drawing.Size(208, 48);
			// 
			// openSelectedDirectoriesToolStripMenuItem
			// 
			this.openSelectedDirectoriesToolStripMenuItem.Name = "openSelectedDirectoriesToolStripMenuItem";
			this.openSelectedDirectoriesToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.openSelectedDirectoriesToolStripMenuItem.Text = "Open selected directories";
			this.openSelectedDirectoriesToolStripMenuItem.Click += new System.EventHandler(this.openSelectedDirectoriesToolStripMenuItem_Click);
			// 
			// copyFullFileNamesToolStripMenuItem
			// 
			this.copyFullFileNamesToolStripMenuItem.Name = "copyFullFileNamesToolStripMenuItem";
			this.copyFullFileNamesToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
			this.copyFullFileNamesToolStripMenuItem.Text = "Copy file path(s)";
			this.copyFullFileNamesToolStripMenuItem.Click += new System.EventHandler(this.copyFullFileNamesToolStripMenuItem_Click);
			// 
			// sizeFilter
			// 
			this.sizeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sizeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.sizeFilter.FormattingEnabled = true;
			this.sizeFilter.Items.AddRange(new object[] {
            "Size",
            "< 512 B",
            "> 512 B",
            "> 32 KiB",
            "> 1 MiB",
            "> 128 MiB",
            "> 1 GiB"});
			this.sizeFilter.Location = new System.Drawing.Point(553, 11);
			this.sizeFilter.Name = "sizeFilter";
			this.sizeFilter.Size = new System.Drawing.Size(75, 21);
			this.sizeFilter.TabIndex = 10;
			// 
			// SearchAndFind
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(640, 360);
			this.Controls.Add(this.sizeFilter);
			this.Controls.Add(this.fileList);
			this.Controls.Add(this.strategyDropDown);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.searchButton);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.locationEntry);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.keywordsText);
			this.Name = "SearchAndFind";
			this.Text = "Search & Find";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchAndFind_FormClosing);
			this.fileRightClick.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox keywordsText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox locationEntry;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox strategyDropDown;
		private System.Windows.Forms.ListView fileList;
		private System.Windows.Forms.ColumnHeader nameHeader;
		private System.Windows.Forms.ColumnHeader folderHeader;
		private System.Windows.Forms.ColumnHeader sizeHeader;
		private System.Windows.Forms.ColumnHeader typeHeader;
		private System.Windows.Forms.ColumnHeader modifiedHeader;
		private System.Windows.Forms.ContextMenuStrip fileRightClick;
		private System.Windows.Forms.ToolStripMenuItem openSelectedDirectoriesToolStripMenuItem;
		private System.Windows.Forms.ComboBox sizeFilter;
		private System.Windows.Forms.ToolStripMenuItem copyFullFileNamesToolStripMenuItem;
	}
}

