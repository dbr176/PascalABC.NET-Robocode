using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace robopascal_runner
{
    public partial class QuickMatchWindow : Form
    {
        private RobocodeEngineRunner _engine;
        private Thread _th;
        private readonly CultureInfo _culture = new CultureInfo("en-US");

        public QuickMatchWindow()
        {
            InitializeComponent();
            resolutionComboBox.SelectedIndex = 1;

            // Tooltips
            new ToolTip().SetToolTip(refreshPictureBox, "Перекомпилировать и обновить список роботов.");
            new ToolTip().SetToolTip(hideNamesCheckBox, "Не показывать имена танков во время боя.");
            new ToolTip().SetToolTip(deselectButton, "Убрать выбор со всех участников.");
            new ToolTip().SetToolTip(selectAllButton, "Установить выбор на всех участниках.");
        }

        private void QuickMatch_Shown(object sender, EventArgs e)
        {
            Location = new Point(Owner.Location.X + Owner.Width, Owner.Location.Y);
            UpdateRobotList();
        }

        private void QuickMatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void coolRateTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var isCorrectValue = Utility.IsDouble(coolRateTextBox.Text);
            runButton.Enabled = isCorrectValue;

            coolRateTextBox.BackColor = !isCorrectValue ? Color.Red : SystemColors.Window;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            if (robotListCheckedListBox.CheckedItems.Count > 0)
            {
                _engine = new RobocodeEngineRunner();

                var numRounds = (int)roundsNumericUpDown.Value;
                var inactivityTime = (int)inactiveNumericUpDown.Value;
                var gunCoolingRate = double.Parse(coolRateTextBox.Text, _culture);
                var hideNames = hideNamesCheckBox.Checked;
                var res = Utility.GetResolution(resolutionComboBox.Text);

                var checkedRobots = robotListCheckedListBox.CheckedItems.OfType<FileInfo>(); // or Cast, whatever
                var robotNames = new List<string>();
                foreach (var robot in checkedRobots)
                {
                    // reflection magic
                    var childDomain = AppDomain.CreateDomain(Guid.NewGuid().ToString(), null, new AppDomainSetup
                    {
                        ApplicationBase = AppDomain.CurrentDomain.BaseDirectory
                    });
                    var handle = Activator.CreateInstance(childDomain,
                        typeof(ReferenceLoader).Assembly.FullName,
                        typeof(ReferenceLoader).FullName,
                        false, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, null,
                        CultureInfo.CurrentCulture, new object[0]);
                    var loader = (ReferenceLoader)handle.Unwrap();

                    //This operation is executed in the new AppDomain
                    robotNames.AddRange(loader.LoadClassTypes(robot.FullName));

                    AppDomain.Unload(childDomain);
                }
                var names = robotNames.Aggregate((i, j) => i + "," + j);

                _th = new Thread(() => _engine.Run(numRounds, inactivityTime, gunCoolingRate, hideNames, res, names))
                {
                    IsBackground = true
                };
                _th.Start();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать хотя бы одного робота.", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void checkListMassSelection_Click(object sender, EventArgs e)
        {
            var b = (Button) sender;
            var select = b.Name.StartsWith("select");
            for (var i = 0; i < robotListCheckedListBox.Items.Count; ++i)
                robotListCheckedListBox.SetItemChecked(i, select);
            robotListCheckedListBox.Refresh();
            robotListCheckedListBox.Invalidate();
        }

        private void refreshPictureBox_Click(object sender, EventArgs e) => UpdateRobotList();

        private void terminateButton_Click(object sender, EventArgs e)
        {
            _engine?.Abort();
            _th?.Join();
        }

    private void UpdateRobotList()
        {
            robotListCheckedListBox.Items.Clear();
            Utility.CompileRobots((Owner as MainWindow).Log); // TODO: dirty

            var dir = new DirectoryInfo(Utility.RobotsDir);
            var files = dir.GetFiles("*.dll", SearchOption.AllDirectories).ToList();

            foreach (var file in files)
                robotListCheckedListBox.Items.Add(file);
        }
    }
}

