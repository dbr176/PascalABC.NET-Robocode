using System.Drawing;

namespace robopascal_runner
{
    public struct RobocodeEngineParams
    {
        public int NumRounds { get; set; }
        public int InactivityTime { get; set; }
        public double GunCoolingRate { get; set; }
        public bool HideNames { get; set; }
        public Size Resolution { get; set; }
        public string RobotNames { get; set; }
    }
}