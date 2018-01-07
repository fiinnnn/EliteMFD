namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface ILoadGameEntry : IJournalEntry
    {
        string Commander { get; set; }
        string Ship { get; set; }
        string ShipName { get; set; } // player-defined ship name
        string ShipIdent { get; set; } // player-defined ship id
        double FuelLevel { get; set; }
        double FuelCapacity { get; set; }
        string GameMode { get; set; }
        string Group { get; set; }
        long Credits { get; set; }
        long Loan { get; set; }
    }

    partial class JournalEntry : ILoadGameEntry
    {
        public string Commander { get; set; }
        public string Ship { get; set; }
        public string ShipName { get; set; }
        public string ShipIdent { get; set; }
        public double FuelCapacity { get; set; }
        public string GameMode { get; set; }
        public string Group { get; set; }
        public long Credits { get; set; }
        public long Loan { get; set; }
    }
}
