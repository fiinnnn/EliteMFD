namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IVehicleSwitchEntry : IJournalEntry
    {
        string To { get; set; }
    }

    partial class JournalEntry : IVehicleSwitchEntry
    {
        public string To { get; set; }
    }
}
