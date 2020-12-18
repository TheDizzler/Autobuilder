using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DesktopBuilder
{
	public partial class ConsoleOutputUserControl : UserControl
	{
		private delegate void UpdateButtonVisibilityCallback(Button button);

		private string logFilePath;
		private string buildPath;



		public ConsoleOutputUserControl()
		{
			InitializeComponent();
		}

		public void EnableViewLogButton(string logPath)
		{
			logFilePath = logPath;
			ShowButton(OpenLog_button);
		}

		public void EnableOpenBuildFolder(string folderPath)
		{
			buildPath = folderPath;
			ShowButton(viewBuildFolder_button);
		}

		private void ShowButton(Button button)
		{
			if (button.InvokeRequired)
			{
				UpdateButtonVisibilityCallback d = new UpdateButtonVisibilityCallback(ShowButton);
				this.Invoke(d, new Object[] { button });
			}
			else
				button.Visible = true;
		}

		private void OpenLog_button_Click(object sender, EventArgs e)
		{
			Process.Start(logFilePath);
		}

		private void ViewBuildFolder_button_Click(object sender, EventArgs e)
		{
			Process.Start(buildPath);
		}
	}
}
