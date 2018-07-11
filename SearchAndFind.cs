using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace ktsaf
{
	public partial class SearchAndFind : Form
	{
		public SearchAndFind()
		{
			InitializeComponent();
			this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
			strategyDropDown.SelectedIndex = 1;
			sizeFilter.SelectedIndex = 0;
		}

		int sizeMinimum = 0;
		int sizeMaximum = int.MaxValue;
		string[] keywords = null;
		DirectoryInfo searchDirectory;
		Thread searchThread = null;

		private void searchButtonStart(object sender, EventArgs e)
		{
			SearchStart();
		}

		private void searchButtonStop(object sender, EventArgs e)
		{
			SearchStop();
		}

		void SearchStart()
		{
			try
			{
				keywordsText.Enabled = false;
				locationEntry.Enabled = false;
				strategyDropDown.Enabled = false;
				browseButton.Enabled = false;
				searchButton.Text = "Stop";
				searchButton.Click -= searchButtonStart;
				searchButton.Click += searchButtonStop;
				if (keywordsText.Text.Length <= 0)
				{
					if (sizeFilter.SelectedIndex != 0)
					{
						keywords = new string[0];
						goto SkipKeywords;
					}
					goto FailKeywords;
				}
				keywords = keywordsText.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				if (keywords.Length <= 0 && sizeFilter.SelectedIndex == 0) goto FailKeywords;
				for (int i = 0; i < keywords.Length; ++i)
					keywords[i] = keywords[i].ToLower();
			SkipKeywords:
				searchDirectory = new DirectoryInfo(locationEntry.Text);
				if (!searchDirectory.Exists) goto FailDirectory;
				switch (sizeFilter.SelectedIndex)
				{
					case 2:
						sizeMinimum = 512;
						break;
					case 3:
						sizeMinimum = 32 * 1024;
						break;
					case 4:
						sizeMinimum = 1 * 1024 * 1024;
						break;
					case 5:
						sizeMinimum = 128 * 1024 * 1024;
						break;
					case 6:
						sizeMinimum = 1024 * 1024 * 1024;
						break;
					default:
						sizeMinimum = 0;
						break;
				}
				switch (sizeFilter.SelectedIndex)
				{
					case 1:
						sizeMaximum = 512;
						break;
					default:
						sizeMaximum = int.MaxValue;
						break;
				}
				progressBar.Style = ProgressBarStyle.Marquee;
				fileList.Items.Clear();

				// ...
				switch (strategyDropDown.SelectedIndex)
				{
					case 0:
						searchThread = new Thread(new ThreadStart(NoSubSearch));
						searchThread.Start();
						break;
					case 1:
						searchThread = new Thread(new ThreadStart(IterativeSearch));
						searchThread.Start();
						break;
					case 2:
						searchThread = new Thread(new ThreadStart(DepthFirstSearch));
						searchThread.Start();
						break;
					default:
						goto FailStrategy; 
				}
				// ...

				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				SearchEnded();
				return;
			}
		FailKeywords:
			MessageBox.Show("You must enter at least one keyword.", "Enter keywords", MessageBoxButtons.OK, MessageBoxIcon.Error);
			SearchEnded();
			return;
		FailDirectory:
			MessageBox.Show("The selected search directory does not exist. Please enter the correct path.", "Directory does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
			SearchEnded();
			return;
		FailStrategy:
			MessageBox.Show("The search strategy is invalid. Select a search strategy from the drop down menu.", "Invalid search strategy", MessageBoxButtons.OK, MessageBoxIcon.Error);
			SearchEnded();
			return;
		}

		void SearchStop()
		{
			try
			{
				searchThread.Abort();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Abort failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		void SearchEnded()
		{
			keywordsText.Enabled = true;
			locationEntry.Enabled = true;
			strategyDropDown.Enabled = true;
			browseButton.Enabled = true;
			searchButton.Text = "Start";
			searchButton.Click += searchButtonStart;
			searchButton.Click -= searchButtonStop;
			progressBar.Style = ProgressBarStyle.Blocks;
			searchThread = null;
			keywords = null;
		}

		delegate void EmptyFunction();
		delegate void ExceptionFunction(Exception ex);
		void InvokeSearchEndedAbort()
		{
			if (InvokeRequired) { Invoke(new EmptyFunction(InvokeSearchEndedAbort)); return; }
			if (!isClosing) MessageBox.Show("The search process has been aborted.", "Search aborted", MessageBoxButtons.OK, MessageBoxIcon.Information);
			SearchEnded();
		}

		void InvokeSearchEndedException(Exception ex)
		{
			if (InvokeRequired) { Invoke(new ExceptionFunction(InvokeSearchEndedException), ex); return; }
			if (!isClosing) MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			SearchEnded();
		}

		void InvokeSearchEnded()
		{
			if (InvokeRequired) { Invoke(new EmptyFunction(InvokeSearchEnded)); return; }
			SearchEnded();
		}

		void NoSubSearch()
		{
			try
			{
				foreach (DirectoryInfo subDir in searchDirectory.GetDirectories())
				{
					try
					{
						TestDirectory(subDir);
					}
					catch { }
				}
				foreach (FileInfo subFile in searchDirectory.GetFiles())
				{
					try
					{
						TestFile(subFile);
					}
					catch { }
				}
			}
			catch (ThreadAbortException)
			{
				InvokeSearchEndedAbort();
				return;
			}
			catch (Exception ex)
			{
				InvokeSearchEndedException(ex);
				return;
			}
			InvokeSearchEnded();
			return;
		}

		void IterativeSearch()
		{
			try
			{
				for (int searchDepth = 0; IterativeSearch(searchDirectory, 0, searchDepth) > 0; ++searchDepth) ;
			}
			catch (ThreadAbortException)
			{
				InvokeSearchEndedAbort();
				return;
			}
			catch (Exception ex)
			{
				InvokeSearchEndedException(ex);
				return;
			}
			InvokeSearchEnded();
			return;
		}

		int IterativeSearch(DirectoryInfo dirInfo, int currentDepth, int searchDepth)
		{
			int subDirCount = 0;
			if (currentDepth == searchDepth)
			{
				foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
				{
					try
					{
						TestDirectory(subDir);
						++subDirCount;
					}
					catch { }
				}
				foreach (FileInfo subFile in dirInfo.GetFiles())
				{
					try
					{
						TestFile(subFile);
					}
					catch { }
				}
			}
			else
			{
				foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
				{
					try
					{
						subDirCount += IterativeSearch(subDir, currentDepth + 1, searchDepth);
					}
					catch { }
				}
			}
			return subDirCount;
		}

		void DepthFirstSearch()
		{
			try
			{
				DepthFirstSearch(searchDirectory);
			}
			catch (ThreadAbortException)
			{
				InvokeSearchEndedAbort();
				return;
			}
			catch (Exception ex)
			{
				InvokeSearchEndedException(ex);
				return;
			}
			InvokeSearchEnded();
			return;
		}

		void DepthFirstSearch(DirectoryInfo dirInfo)
		{
			foreach (FileInfo subFile in dirInfo.GetFiles())
			{
				try
				{
					TestFile(subFile);
				}
				catch { }
			}
			foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
			{
				try
				{
					TestDirectory(subDir);
				}
				catch { }
				try
				{
					DepthFirstSearch(subDir);
				}
				catch { }
			}
		}

		void TestFile(FileInfo fileInfo)
		{
			if (fileInfo.Length < sizeMinimum || fileInfo.Length > sizeMaximum)
				return;
			string name = fileInfo.Name.ToLower();
			foreach (string keyword in keywords)
			{
				if (!name.Contains(keyword))
				{
					return;
				}
			}
			InvokeFoundFile(fileInfo);
		}

		void TestDirectory(DirectoryInfo dirInfo)
		{
			if (keywords.Length == 0) return;
			string name = dirInfo.Name.ToLower();
			foreach (string keyword in keywords)
			{
				if (!name.Contains(keyword))
				{
					return;
				}
			}
			InvokeFoundDir(dirInfo);
		}

		delegate void FileInfoFunction(FileInfo fileInfo);
		void InvokeFoundFile(FileInfo fileInfo)
		{
			if (InvokeRequired) { Invoke(new FileInfoFunction(InvokeFoundFile), fileInfo); return; }
			fileList.Items.Add(new ListViewItem(new string[] { fileInfo.Name, fileInfo.Directory.FullName, fileInfo.Length.ToString(), fileInfo.Extension, fileInfo.LastWriteTime.ToString() }));
		}

		delegate void DirectoryInfoFunction(DirectoryInfo dirInfo);
		void InvokeFoundDir(DirectoryInfo dirInfo)
		{
			if (InvokeRequired) { Invoke(new DirectoryInfoFunction(InvokeFoundDir), dirInfo); return; }
			fileList.Items.Add(new ListViewItem(new string[] { dirInfo.Name, dirInfo.FullName, "", "<DIR>", dirInfo.LastWriteTime.ToString() }));
		}


		private void openSelectedDirectoriesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in fileList.SelectedItems)
			{
				System.Diagnostics.Process.Start(lvi.SubItems[1].Text);
			}
		}


		private void copyFullFileNamesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder builder = new StringBuilder();
			foreach (ListViewItem lvi in fileList.SelectedItems)
			{
				builder.Append(lvi.SubItems[1].Text);
				builder.Append("\\");
				builder.Append(lvi.SubItems[0].Text);
				builder.Append("\r\n");
			}
			builder.Length -= 2;
			Clipboard.SetText(builder.ToString());
		}


		bool isClosing = false;
		private void SearchAndFind_FormClosing(object sender, FormClosingEventArgs e)
		{
			isClosing = true;
			if (searchThread != null)
			{
				if (e.CloseReason == CloseReason.UserClosing)
				{
					if (MessageBox.Show("A search is still in progress.\r\nAre you sure you want to close?", "Search in progress", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					{
						isClosing = false;
						e.Cancel = true;
						return;
					}
				}
				searchThread.Abort();
			}
		}
	}
}
