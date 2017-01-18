using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Robocode.Control;
using Robocode.Control.Events;

namespace robopascal_runner
{
    public partial class QuickMatch : Form
    {
        public QuickMatch()
        {
            InitializeComponent();

            resolutionComboBox.SelectedIndex = 1;
            UpdateRobotList();
        }

        private void Run()
        {
            // Create the RobocodeEngine
            var engine = new RobocodeEngine(PascalPath.RobocodeDir);

            // Add battle event handlers
            engine.BattleCompleted += BattleCompleted;
            engine.BattleMessage += BattleMessage;
            engine.BattleError += BattleError;

            // Show the Robocode battle view
            engine.Visible = true;

            var numRounds = (int) roundsNumericUpDown.Value;
            var inactivityTime = (int) inactiveNumericUpDown.Value;
            var gunCoolingRate = double.Parse(coolRateTextBox.Text);
            // run button wont be active if number is not double
            var hideNames = hideNamesCheckBox.Checked;
            var res = GetResolution();
            var battlefieldSize = new BattlefieldSpecification(res.Width, res.Height);

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
                var loader = (ReferenceLoader) handle.Unwrap();

                //This operation is executed in the new AppDomain
                robotNames.AddRange(loader.LoadClassTypes(robot.FullName));
                AppDomain.Unload(childDomain);
            }
            var namesConcat = robotNames.Aggregate((i, j) => i + "," + j);
            var selectedRobots = engine.GetLocalRepository(namesConcat);

            var battleSpec = new BattleSpecification(numRounds, inactivityTime, gunCoolingRate, hideNames,
                battlefieldSize, selectedRobots);

            // Run battle
            engine.RunBattle(battleSpec, true);
            engine.Close();
        }

        // Called when the battle is completed successfully with battle results 
        private static void BattleCompleted(BattleCompletedEvent e)
        {
            Console.WriteLine("-- Battle has completed --");

            // Print out the sorted results with the robot names
            Console.WriteLine("Battle results:");
            foreach (var result in e.SortedResults)
                Console.WriteLine($"  {result.TeamLeaderName}: {result.Score}");
        }

        // Called when the game sends out an information message during the battle 
        private static void BattleMessage(BattleMessageEvent e)
        {
            Console.WriteLine("Msg> " + e.Message);
        }

        // Called when the game sends out an error message during the battle 
        private static void BattleError(BattleErrorEvent e)
        {
            Console.WriteLine("Err> " + e.Error);
        }

        private Size GetResolution()
        {
            var size = resolutionComboBox.Text;
            var split = size.Split('x');
            var w = int.Parse(split[0]);
            var h = int.Parse(split[1]);

            return new Size(w, h);
        }

        private void coolRateTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var isCorrectValue = IsDouble(coolRateTextBox.Text);
            runButton.Enabled = isCorrectValue;

            coolRateTextBox.BackColor = !isCorrectValue ? Color.Red : SystemColors.Window;
        }

        private bool IsDouble(string value)
        {
            var culture = new CultureInfo("en-US");
            try
            {
                var d = double.Parse(value, culture);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            if (robotListCheckedListBox.SelectedItems.Count > 0)
                Run();
            else
                MessageBox.Show("Необходимо выбрать хотя бы одного робота.", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UpdateRobotList();
        }

        private void UpdateRobotList()
        {
            robotListCheckedListBox.Items.Clear();

            var dir = new DirectoryInfo(PascalPath.RobotsDir);
            var files = dir.GetFiles("*.dll", SearchOption.AllDirectories).ToList();

            foreach (var file in files)
                robotListCheckedListBox.Items.Add(file);
        }
    }
}