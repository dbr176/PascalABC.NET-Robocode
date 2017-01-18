using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace robopascal_runner
{
    public partial class MainWindow : Form
    {
        private readonly About _aboutWindow = new About { StartPosition = FormStartPosition.CenterParent };
        private readonly RunBattle _runBattleWindow = new RunBattle { StartPosition = FormStartPosition.CenterParent };


        private readonly FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();


        public MainWindow()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            _folderBrowserDialog.SelectedPath = PascalPath.RobopascalDir;
        }

        private void CompileRobots()
        {
            //logboxListBox.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(PascalPath.RobopascalDir);
            var files = dir.GetFiles("*.pas", SearchOption.AllDirectories).Where(x => x.Name != "PABCSystem.pas").ToList();

            Parallel.ForEach(files, file =>
            {
                var psi = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    FileName = Path.Combine(PascalPath.PabcPath, PascalPath.CompilerName),
                    Arguments = file.FullName
                };

                var process = Process.Start(psi);
                Debug.Assert(process != null, "process != null");
                process.WaitForExit();

                string output = process.StandardOutput.ReadToEnd().Trim();
                string err = process.StandardError.ReadToEnd();

                //logboxListBox.Items.Add(file.Name + " - " + output);

                if (output == "OK")
                {
                    var newName = file.Name.Replace(".pas", ".dll");
                    var dllStart = Path.Combine(file.DirectoryName, newName); // TODO : исключение
                    var dllEnd = Path.Combine(PascalPath.PabcWork, PascalPath.RobocodeFolder, PascalPath.RobotsFolder, newName);
                    PascalPath.MoveWithReplace(dllStart, dllEnd);
                }
            });
        }

        private void openPathButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", PascalPath.RobopascalDir);
        }

        private void runSpecialButton_Click(object sender, EventArgs e)
        {
            _runBattleWindow.ShowDialog();
        }

        private void runRobocodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // compile before run
            CompileRobots();

            var batPath = $"{Path.Combine(PascalPath.PabcWork, PascalPath.RobocodeFolder, PascalPath.RobocodeBatFile)}";
            var psi = new ProcessStartInfo
            {
                WorkingDirectory = Path.Combine(PascalPath.PabcWork, PascalPath.RobocodeFolder),
                CreateNoWindow = false,
                UseShellExecute = false,
                FileName = batPath
            };

            Process.Start(psi);
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e) => CompileRobots();
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();


        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _aboutWindow.ShowDialog();
        }
    }
}
