using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Robocode.Control;
using Robocode.Control.Events;

namespace robopascal_runner
{
    public class RobocodeEngineRunner
    {
        private RobocodeEngine _engine;
        

        public void Run(int numRounds, int inactivityTime, double gunCoolingRate, bool hideNames, Size res,
            string names)
        {
            _engine = new RobocodeEngine(Utility.RobocodeDir);

            // Event handlers
            _engine.BattleCompleted += BattleCompleted;
            _engine.BattleMessage += BattleMessage;
            _engine.BattleError += BattleError;

            // Setup
            _engine.Visible = true;
            var battlefieldSize = new BattlefieldSpecification(res.Width, res.Height);

            Console.WriteLine(names);
            var selectedRobots = _engine.GetLocalRepository(names);
            var battleSpec = new BattleSpecification(numRounds, inactivityTime, gunCoolingRate, hideNames,
                battlefieldSize, selectedRobots);

            // Run battle
            _engine.RunBattle(battleSpec, true);
            _engine.Close();
        }

        public void Abort() => _engine.AbortCurrentBattle();

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
    }
}