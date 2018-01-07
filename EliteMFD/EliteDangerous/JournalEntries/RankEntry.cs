namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IRankEntry : IJournalEntry
    {
        int? Combat { get; set; }
        int? Trade { get; set; }
        int? Explore { get; set; }
        int? Empire { get; set; }
        int? Federation { get; set; }
        int? CQC { get; set; }
    }

    partial class JournalEntry : IRankEntry
    {
        public int? Combat { get; set; }
        public int? Trade { get; set; }
        public int? Explore { get; set; }
        public int? Empire { get; set; }
        public int? Federation { get; set; }
        public int? CQC { get; set; }
    }
}
