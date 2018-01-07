namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface ISetUserShipName : IJournalEntry
    {
        string Ship { get; set; }
        string UserShipName { get; set; }
        string UserShipId { get; set; }
    }
    
    partial class JournalEntry : ISetUserShipName
    {
        public string UserShipName { get; set; }
        public string UserShipId { get; set; }
    }
}
