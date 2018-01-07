namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IShipyardTransferEntry : IJournalEntry
    {
        string ShipType { get; set; }
        string System { get; set; }
        double Distance { get; set; }
        long TransferPrice { get; set; }
        long TransferTime { get; set; }
    }

    partial class JournalEntry : IShipyardTransferEntry
    {
        public string ShipType { get; set; }
        public string System { get; set; }
        public double Distance { get; set; }
        public long TransferPrice { get; set; }
        public long TransferTime { get; set; }
    }
}
