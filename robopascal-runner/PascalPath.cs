using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace robopascal_runner
{
    public static class PascalPath
    {
        public const string Registry = @"HKEY_CURRENT_USER\SOFTWARE\PascalABC.NET";
        public const string RegistryValue = "Install Directory";
        public const string IniFileName = "pabcworknet.ini";
        public const string CompilerName = "pabcnetcclear.exe";
        public const string RobocodePascalFolder = "robopascal";
        public const string RobocodeFolder = "Robocode";
        public const string RobotsFolder = "robots";
        public const string RobocodeBatFile = "robocode.bat";

        public static void MoveWithReplace(string sourceFileName, string destFileName)
        {
            if (File.Exists(destFileName))
            {
                File.Delete(destFileName);
            }
            File.Move(sourceFileName, destFileName);
        }

        public static string PabcPath => Microsoft.Win32.Registry.GetValue(Registry, RegistryValue, "NotFound").ToString(); // TODO: исключение
        public static string PabcWork => File.ReadAllText(Path.Combine(PabcPath, IniFileName));
        public static string RobopascalDir => Path.Combine(PabcWork, RobocodeFolder, RobocodePascalFolder);
        public static string RobocodeDir => Path.Combine(PabcWork, RobocodeFolder);


    }
}
