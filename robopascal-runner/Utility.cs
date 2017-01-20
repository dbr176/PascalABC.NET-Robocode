using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace robopascal_runner
{
    public static class Utility
    {
        public const string Registry = @"HKEY_CURRENT_USER\SOFTWARE\PascalABC.NET";
        public const string RegistryValue = "Install Directory";
        public const string IniFileName = "pabcworknet.ini";
        public const string CompilerName = "pabcnetcclear.exe";
        public const string RobocodePascalFolder = "robopascal";
        public const string RobocodeFolder = "Robocode";
        public const string RobotsFolder = "robots";
        public const string RobocodeBatFile = "robocode.bat";

        private static string PabcPath
            => Microsoft.Win32.Registry.GetValue(Registry, RegistryValue, null).ToString(); // TODO: исключение
        public static string PabcWork => File.ReadAllText(Path.Combine(PabcPath, IniFileName));
        public static string RobopascalDir => Path.Combine(PabcWork, RobocodeFolder, RobocodePascalFolder);
        public static string RobocodeDir => Path.Combine(PabcWork, RobocodeFolder);
        public static string RobotsDir => Path.Combine(PabcWork, RobocodeFolder, RobotsFolder);

        public static void MoveWithReplace(string sourceFileName, string destFileName)
        {
            if (File.Exists(destFileName))
                File.Delete(destFileName);
            File.Move(sourceFileName, destFileName);
        }

        public static void CompileRobots(BindingList<string> log)
        {
            var date = DateTime.Now;
            log.Add($"Новая компиляция: {date}");
            var dir = new DirectoryInfo(RobopascalDir);
            var files =
                dir.GetFiles("*.pas", SearchOption.AllDirectories).Where(x => x.Name != "PABCSystem.pas").ToList();

            Parallel.ForEach(files, file =>
            {
                var psi = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    FileName = Path.Combine(PabcPath, CompilerName),
                    Arguments = file.FullName
                };

                var process = Process.Start(psi);
                Debug.Assert(process != null, "process != null");
                process.WaitForExit();

                var output = process.StandardOutput.ReadToEnd().Trim();
                var err = process.StandardError.ReadToEnd();

                log.Add(output != "OK"
                    ? $"Файл {file.Name} - {output}"
                    : $"Файл {file.Name} - компиляция прошла успешно");

                if (output == "OK")
                {
                    var newName = file.Name.Replace(".pas", ".dll");
                    var dllStart = Path.Combine(file.DirectoryName, newName); // TODO : исключение
                    var dllEnd = Path.Combine(PabcWork, RobocodeFolder, RobotsFolder,
                        newName);
                    MoveWithReplace(dllStart, dllEnd);
                }
            });
            log.Add("\n");
        }

        public static void RunBat()
        {
            var batPath = $"{Path.Combine(PabcWork, RobocodeFolder, RobocodeBatFile)}";
            var psi = new ProcessStartInfo
            {
                WorkingDirectory = Path.Combine(PabcWork, RobocodeFolder),
                CreateNoWindow = false,
                UseShellExecute = false,
                FileName = batPath
            };

            Process.Start(psi);
        }

        public static bool IsDouble(string value)
        {
            var culture = new CultureInfo("en-US");
            try
            {
                var d = Double.Parse(value, culture);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static Size GetResolution(string resString)
        {
            var size = resString;
            var split = size.Split('x');
            var w = Int32.Parse(split[0]);
            var h = Int32.Parse(split[1]);

            return new Size(w, h);
        }
    }
}