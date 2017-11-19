namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IHullDamageEntry : IJournalEntry
    {
        double Health { get; set; }
        bool PlayerPilot { get; set; }
        bool Fighter { get; set; }
    }

    partial class JournalEntry : IHullDamageEntry
    {
        public double Health { get; set; }
        public bool PlayerPilot { get; set; }
        public bool Fighter { get; set; }
    }
}
