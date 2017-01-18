using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Robocode;
using Robocode.Control;
using Robocode.Control.Events;

namespace robopascal_runner
{
    public partial class RunBattle : Form
    {
        public RunBattle()
        {
            InitializeComponent();
        }


        private void f()
        {
            // Create the RobocodeEngine
            RobocodeEngine engine = new RobocodeEngine(PascalPath.RobocodeDir);

            // Add battle event handlers
            engine.BattleCompleted += BattleCompleted;
            engine.BattleMessage += BattleMessage;
            engine.BattleError += BattleError;

            // Show the Robocode battle view
            engine.Visible = true;

            // Setup the battle specification

            int numberOfRounds = 5;
            BattlefieldSpecification battlefield = new BattlefieldSpecification(800, 600); // 800x600
            RobotSpecification[] selectedRobots = engine.GetLocalRepository("sample.RamFire,sample.Corners");

            BattleSpecification battleSpec = new BattleSpecification(numberOfRounds, battlefield, selectedRobots);

            // Run our specified battle and let it run till it is over
            engine.RunBattle(battleSpec, true /* wait till the battle is over */);

            // Cleanup our RobocodeEngine
            engine.Close();
        }

        // Called when the battle is completed successfully with battle results 
        private static void BattleCompleted(BattleCompletedEvent e)
        {
            Console.WriteLine("-- Battle has completed --");

            // Print out the sorted results with the robot names
            Console.WriteLine("Battle results:");
            foreach (BattleResults result in e.SortedResults)
            {
                Console.WriteLine($"  {result.TeamLeaderName}: {result.Score}");
            }
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
    }
}
