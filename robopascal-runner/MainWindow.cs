using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace robopascal_runner
{
    public partial class MainWindow : Form
    {
        private readonly About _aboutWindow = new About {StartPosition = FormStartPosition.CenterParent};

        private readonly FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();
        private readonly QuickMatch _runBattleWindow = new QuickMatch {StartPosition = FormStartPosition.CenterParent};


        public MainWindow()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            _folderBrowserDialog.SelectedPath = PascalPath.RobopascalDir;
            PascalPath.CompileRobots();
        }

        private void openPathButton_Click(object sender, EventArgs e)
            => Process.Start("explorer.exe", PascalPath.RobopascalDir);

        private void runSpecialButton_Click(object sender, EventArgs e) => _runBattleWindow.ShowDialog();

        private void runRobocodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PascalPath.CompileRobots();
            PascalPath.RunBat();
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e) => PascalPath.CompileRobots();
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();  // TODO: make menu
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => _aboutWindow.ShowDialog();
        private void MainWindow_Load(object sender, EventArgs e) => PascalPath.CompileRobots();
    }
}