namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IFSDJumpEntry : ISystemInfo
    {
        double JumpDist { get; set; }
        double FuelUsed { get; set; }
        double FuelLevel { get; set; }
        bool BoostUsed { get; set; }
    }

    partial class JournalEntry : IFSDJumpEntry
    {
        public double JumpDist { get; set; }
        public double FuelUsed { get; set; }
        public double FuelLevel { get; set; }
        public bool BoostUsed { get; set; }
    }
}
