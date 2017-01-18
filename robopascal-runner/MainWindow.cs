using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace robopascal_runner
{
    public partial class MainWindow : Form
    {
        private readonly AboutWindow _aboutWindow = new AboutWindow {StartPosition = FormStartPosition.CenterParent};
        private readonly LogWindow _logWindow = new LogWindow();
        private readonly QuickMatchWindow _runBattleWindow = new QuickMatchWindow();

        public BindingList<string> Log = new BindingList<string>();


        public MainWindow()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            AddOwnedForm(_runBattleWindow);
            AddOwnedForm(_logWindow);

            Utility.CompileRobots(Log);
        }

        private void openPathButton_Click(object sender, EventArgs e)
            => Process.Start("explorer.exe", Utility.RobopascalDir);

        private void runSpecialButton_Click(object sender, EventArgs e) => _runBattleWindow.Show();

        private void runRobocodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.CompileRobots(Log);
            Utility.RunBat();
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e) => Utility.CompileRobots(Log);
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => _aboutWindow.ShowDialog();
        private void logButton_Click(object sender, EventArgs e) => _logWindow.Show();
    }
}