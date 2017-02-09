using System;
using System.Collections.Generic;
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


        public void Run(RobocodeEngineParams engineParams)
        {
            _engine = new RobocodeEngine(Utility.RobocodeDir);

            // Event handlers
            _engine.BattleCompleted += BattleCompleted;
            _engine.BattleMessage += BattleMessage;
            _engine.BattleError += BattleError;

            // Setup
            _engine.Visible = true;
            var battlefieldSize = new BattlefieldSpecification(engineParams.Resolution.Width,
                engineParams.Resolution.Height);

            var selectedRobots = _engine.GetLocalRepository(engineParams.RobotNames);
            var battleSpec = new BattleSpecification(engineParams.NumRounds, engineParams.InactivityTime,
                engineParams.GunCoolingRate, engineParams.HideNames,
                battlefieldSize, selectedRobots);

            // Run battle
            _engine.RunBattle(battleSpec, true);
        }

        public void Abort()
        {
            _engine.AbortCurrentBattle();
        }

        // do not call close unless you close application
        // Close dispose evrything and wont re-load libs
        // causing blank battle screen
        public void Close()
        {
            _engine.Close();
        }

        public static string CompileAssembly(IEnumerable<FileInfo> checkedRobots)
        {
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
            return robotNames.Aggregate((i, j) => i + "," + j);
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
    }
}