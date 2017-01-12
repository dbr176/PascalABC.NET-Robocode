using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace robopascal_runner
{
    public partial class MainWindow : Form
    {
        private const string PabcRegPath = @"HKEY_CURRENT_USER\SOFTWARE\PascalABC.NET";
        private const string PabcRegInst = "Install Directory";
        private const string PabcIni = "pabcworknet.ini";
        private const string PabcCompiler = "pabcnetcclear.exe";

        private const string RcFolder = "robopascal";
        private const string RcRobocode = "Robocode";
        private const string RcRobots = "robots";
        private const string RcStart = "robocode.bat";

        private string PabcPath => Registry.GetValue(PabcRegPath, PabcRegInst, "NotFound").ToString(); // TODO: исключение
        private string PabcWork => File.ReadAllText(Path.Combine(PabcPath, PabcIni));

        private readonly FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();

        private string RobopascalDir => Path.Combine(PabcWork, RcRobocode, RcFolder);

        private static void MoveWithReplace(string sourceFileName, string destFileName)
        {
            if (File.Exists(destFileName))
            {
                File.Delete(destFileName);
            }
            File.Move(sourceFileName, destFileName);
        }

        public MainWindow()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            _folderBrowserDialog.SelectedPath = RobopascalDir;
        }

        private void compileButton_Click(object sender, EventArgs e)
        {
            logboxListBox.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(RobopascalDir);
            var files = dir.GetFiles("*.pas", SearchOption.AllDirectories).Where(x => x.Name != "PABCSystem.pas").ToList();

            foreach (var file in files)
            {
                var psi = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    FileName = Path.Combine(PabcPath, PabcCompiler),
                    Arguments = file.FullName
                };

                var process = Process.Start(psi);
                Debug.Assert(process != null, "process != null");
                process.WaitForExit();

                string output = process.StandardOutput.ReadToEnd().Trim();
                string err = process.StandardError.ReadToEnd();

                logboxListBox.Items.Add(file.Name + " - " + output);

                if (output == "OK")
                {
                    var newName = file.Name.Replace(".pas", ".dll");
                    var dllStart = Path.Combine(file.DirectoryName, newName); // TODO : исключение
                    var dllEnd = Path.Combine(PabcWork, RcRobocode, RcRobots, newName);
                    MoveWithReplace(dllStart, dllEnd);
                }
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            var batPath = $"{Path.Combine(PabcWork, RcRobocode, RcStart)}";
            var psi = new ProcessStartInfo
            {
                WorkingDirectory = Path.Combine(PabcWork, RcRobocode),
                CreateNoWindow = false,
                UseShellExecute = false,
                FileName = batPath
            };
            
            Process.Start(psi);
        }

        private void openPathButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", RobopascalDir);
        }
    }
}
