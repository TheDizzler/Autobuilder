using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace DesktopBuilder
{
	public partial class BuildSetupForm : Form
	{
		public enum Platform { None, Xbox, Switch, PS4 };
		public enum BuildType { None, Development, Shipping };

		private const string defaultGameIniFilePath = "./TheVagrant/Config/DefaultGame.ini";
		private const string logFilePath = "./Engine/Programs/AutomationTool/Saved/Logs/Log.txt";
		private const string savedLogsPath = "./Builds/Logs/";
		private const string buildUAT = "./Engine/Build/BatchFiles/RunUAT.bat BuildCookRun"
			+ " -project=TheVagrant -nop4 %OptionalBuild%-cook -stage -package -archive"
			+ " -archivedirectory=\"./Builds/\" -clientconfig=%BuildType%"
			+ " -ue4exe=UE4Editor-Cmd.exe -SKIPEDITORCONTENT -prereqs -utf8output"
			+ " -compressed -pak -targetplatform=%Platform%";


		private delegate void SetTextCallback(string msg, Color fontColor);
		private delegate void SetTabControlCallback(Platform currentPlatform);
		private delegate void SetProcessOutputCallback(string newLine);


		private List<Platform> platforms = new List<Platform>();
		private BuildType buildType = BuildType.None;
		private ConsoleOutputUserControl currentTabControl;
		private Platform currentPlatform = Platform.None;
		private Process currentProcess = null;

		private string rootFolder = @"ERROR";
		private string defaultGameIni;
		private string currentBuildPath;


		public BuildSetupForm()
		{
			InitializeComponent();
			rootFolder = Directory.GetCurrentDirectory() + "\\";
			rootFolder_textBox.Text = rootFolder;
		}

		private void BuildSetupForm_Load(object sender, EventArgs e)
		{

		}

		private void StartBuild_button_Click(object sender, EventArgs e)
		{
			platforms.Clear();
			consoleOutput_tabControl.TabPages.Clear();

			foreach (var item in platform_checkedListBox.CheckedItems)
			{
				switch (item.ToString().ToLower())
				{
					case "xbox":
						platforms.Add(Platform.Xbox);
						break;
					case "switch":
						platforms.Add(Platform.Switch);
						break;
					case "ps4":
						platforms.Add(Platform.PS4);
						break;
					default:
						warning_label.Text = "Invalid platform selection";
						warning_label.ForeColor = System.Drawing.Color.Red;
						return;
				}
			}

			if (platforms.Count == 0)
			{
				warning_label.Text = "Must select a platform to build";
				warning_label.ForeColor = Color.Red;
				return;
			}

			if (devBuild_radioButton.Checked)
			{
				buildType = BuildType.Development;
			}
			else if (shipBuild_radioButton.Checked)
			{
				buildType = BuildType.Shipping;
			}
			else
			{
				warning_label.Text = "Must select a build type";
				warning_label.ForeColor = Color.Red;
				return;
			}

			try
			{
				defaultGameIni = File.ReadAllText(rootFolder + defaultGameIniFilePath);
			}
			catch (Exception ex)
			{
				warning_label.Text = "Error parsing DefaultGame.ini:\n" + ex.Message;
				warning_label.ForeColor = System.Drawing.Color.Red;
				return;
			}

			warning_label.ForeColor = System.Drawing.Color.Black;
			warning_label.Text = "Builds count: " + platforms.Count + " for " + buildType;
			InitBuilds();

			stopBuild_button.Visible = true;
			startBuild_button.Visible = false;
		}


		private void InitBuilds()
		{
			if (platforms.Count > 1)
			{
				// check the last build type. Could save time on first build.
				bool wasXbox = !defaultGameIni.Contains("/Game/Splash/Xbox");
				bool wasPS4 = !defaultGameIni.Contains("/Game/Splash/PS4");
				bool wasSwitch = !defaultGameIni.Contains("/Game/Splash/Switch");

				if (wasXbox)
				{
					// xbox was last
					if (platforms.Contains(Platform.Xbox))
					{
						platforms.Remove(Platform.Xbox);
						platforms.Insert(0, Platform.Xbox);
					}
				}
				else if (wasPS4)
				{
					// ps4 was last
					if (platforms.Contains(Platform.PS4))
					{
						platforms.Remove(Platform.PS4);
						platforms.Insert(0, Platform.PS4);
					}
				}
				else if (wasSwitch)
				{
					// switch was last
					if (platforms.Contains(Platform.Switch))
					{
						platforms.Remove(Platform.Switch);
						platforms.Insert(0, Platform.Switch);
					}
				}
				else
				{
					warning_label.Text = "DefaultGame.ini may be malformed";
					warning_label.ForeColor = System.Drawing.Color.Red;
					return;
				}
			}

			BuildNext();
		}


		private void BuildNext()
		{
			currentPlatform = platforms[0];
			AddNewTab(currentPlatform);
			currentProcess = CreateBuildProcess(currentPlatform);

			if (currentProcess == null)
			{
				UpdateWarningLabel(
					"Could not initialize " + buildType + " build for " + currentPlatform,
					System.Drawing.Color.Red);
				return;
			}

			platforms.Remove(currentPlatform);
			string newLabel = "Building " + buildType + " for " + currentPlatform;

			currentProcess.OutputDataReceived += Proc_DataReceived;
			currentProcess.Exited += new EventHandler(BuildDone);

			if (platforms.Count > 0)
				UpdateWarningLabel(newLabel += "\nNext build platform " + platforms[0], Color.Black);
			else
				UpdateWarningLabel(newLabel += "\nThis is the last build", Color.Black);

			
			if (Directory.Exists(currentBuildPath))
				currentTabControl.EnableOpenBuildFolder(currentBuildPath);

			currentProcess.Start();
			currentProcess.BeginOutputReadLine();
		}

		private void BuildDone(object sender, EventArgs e)
		{
			// back up last build log
			if (!Directory.Exists(rootFolder + savedLogsPath))
				Directory.CreateDirectory(rootFolder + savedLogsPath);
			string copyFrom = rootFolder + logFilePath;
			string copyTo = rootFolder + savedLogsPath
				+ Enum.GetName(typeof(Platform), currentPlatform) + "_"
				+ DateTime.Now.ToString().Replace(':', '.') + "_Log.txt";
			File.Copy(copyFrom, copyTo);

			currentTabControl.EnableViewLogButton(copyTo);
			if (File.Exists(currentBuildPath))
				currentTabControl.EnableOpenBuildFolder(currentBuildPath);

			currentProcess.OutputDataReceived -= Proc_DataReceived;
			currentProcess.Dispose();

			if (platforms.Count > 0)
			{
				BuildNext();
			}
			else
			{
				UpdateWarningLabel("Builds finished", Color.Black);
				stopBuild_button.Visible = false;
				startBuild_button.Visible = true;
			}
		}

		private void StopBuild_button_Click(object sender, EventArgs e)
		{
			currentProcess.StandardInput.WriteLine("\x3");
			currentProcess.StandardInput.WriteLine("y");
			currentProcess.CloseMainWindow();
			//currentProcess.Kill();
			currentProcess.OutputDataReceived -= Proc_DataReceived;
			currentProcess.Dispose();

			UpdateProcessOutput("Builds canceled by user");
			UpdateWarningLabel("Builds canceled", Color.Black);
			stopBuild_button.Visible = false;
			startBuild_button.Visible = true;
		}

		private Process CreateBuildProcess(Platform platform)
		{
			string platformName;

			switch (platform)
			{
				case Platform.Xbox:
					platformName = "XBoxOne";
					currentBuildPath = rootFolder + "Builds/XboxOne/";
					break;
				case Platform.Switch:
					platformName = "Switch";
					currentBuildPath = rootFolder + "Builds/Switch/";
					break;
				case Platform.PS4:
					platformName = "PS4";
					currentBuildPath = rootFolder + "Builds/PS4/";
					break;
				default:
					return null;
			}

			string tempUAT = buildUAT.Replace("%BuildType%", Enum.GetName(typeof(BuildType), buildType));
			tempUAT = tempUAT.Replace("%OptionalBuild%", cookOnly_checkBox.Checked ? "" : "-build ");
			tempUAT = tempUAT.Replace("%Platform%", platformName);
			string args = @"/c " + rootFolder + tempUAT;

			PrepareBuildFor(platform);

			ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", args);
			//psi.CreateNoWindow = true; // can not kill process if this is true.
			//psi.WindowStyle = ProcessWindowStyle.Minimized; // does nothing
			psi.UseShellExecute = false;
			psi.RedirectStandardOutput = true;
			psi.RedirectStandardInput = true;
			psi.RedirectStandardError = true;


			Process process = new Process();
			process.EnableRaisingEvents = true;
			process.StartInfo = psi;
			return process;
		}

		private void Proc_DataReceived(object sender, DataReceivedEventArgs e)
		{
			if (e.Data != null)
				UpdateProcessOutput(e.Data.ToString());
			else
				UpdateWarningLabel("Done with this build", Color.Black);
		}


		private void PrepareBuildFor(Platform platform)
		{
			switch (platform)
			{
				case Platform.Xbox:
					ReplaceCheck("Xbox", "PS4", "Switch");
					break;

				case Platform.Switch:
					ReplaceCheck("Switch", "Xbox", "PS4");
					break;

				case Platform.PS4:
					ReplaceCheck("PS4", "Xbox", "Switch");
					break;
			}
		}

		private void ReplaceCheck(string platformBuildingFor, string nonBuildPlatform1, string nonBuildPlatform2)
		{
			if (defaultGameIni.Contains("/Game/Splash/" + platformBuildingFor))
			{
				if (!defaultGameIni.Contains("/Game/Splash/" + nonBuildPlatform1))
				{
					Replace(platformBuildingFor, nonBuildPlatform1);
				}
				else if (!defaultGameIni.Contains("/Game/Splash/" + nonBuildPlatform2))
				{
					Replace(platformBuildingFor, nonBuildPlatform2);
				}
				else
				{
					throw new Exception("Error in DefaultGame.ini");
				}
			}
			else
			{
				UpdateProcessOutput("Nothing to change in DefaultGame.ini");
			}
		}

		private void Replace(string oldValue, string newValue)
		{
			defaultGameIni = defaultGameIni.Replace("/Game/Splash/" + oldValue, "/Game/Splash/" + newValue);
			defaultGameIni = defaultGameIni.Replace("/Game/UI/Font/RichText/" + oldValue, "/Game/UI/Font/RichText/" + newValue);
			defaultGameIni = defaultGameIni.Replace("/Game/UI/Materials/Keymap/" + oldValue, "/Game/UI/Materials/Keymap/" + newValue);
			defaultGameIni = defaultGameIni.Replace("/Game/UI/Blueprints/Keymappings/" + oldValue, "/Game/UI/Blueprints/Keymappings/" + newValue);

			File.WriteAllText(rootFolder + defaultGameIniFilePath, defaultGameIni);
		}

		private void SelectFolder_button_Click(object sender, EventArgs e)
		{
			CommonOpenFileDialog dialog = new CommonOpenFileDialog();
			dialog.InitialDirectory = rootFolder;
			dialog.IsFolderPicker = true;
			if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
			{
				rootFolder = dialog.FileName + "\\";
				rootFolder_textBox.Text = rootFolder;
			}
		}




		/// Thread safe updates 
		private void UpdateProcessOutput(string newLine)
		{
			if (currentTabControl.processOutput_textBox.InvokeRequired)
			{
				SetProcessOutputCallback d = new SetProcessOutputCallback(UpdateProcessOutput);
				this.Invoke(d, new object[] { newLine });
			}
			else
			{
				currentTabControl.processOutput_textBox.AppendText(newLine);
				currentTabControl.processOutput_textBox.AppendText(Environment.NewLine);
			}
		}

		private void AddNewTab(Platform currentPlatform)
		{
			TabPage newPage = new TabPage(Enum.GetName(typeof(Platform), currentPlatform));
			currentTabControl = new ConsoleOutputUserControl() { Dock = DockStyle.Fill };
			newPage.Controls.Add(currentTabControl);
			if (consoleOutput_tabControl.InvokeRequired)
			{
				SetTabControlCallback d = new SetTabControlCallback(AddNewTab);
				this.Invoke(d, new object[] { currentPlatform });
			}
			else
			{
				consoleOutput_tabControl.TabPages.Add(newPage);
				consoleOutput_tabControl.SelectedTab = newPage;
			}
		}

		private void UpdateWarningLabel(string msg, Color fontColor)
		{
			if (warning_label.InvokeRequired)
			{
				SetTextCallback d = new SetTextCallback(UpdateWarningLabel);
				this.Invoke(d, new object[] { msg, fontColor });
			}
			else
			{
				warning_label.Text = msg;
				warning_label.ForeColor = fontColor;
			}
		}
	}
}
