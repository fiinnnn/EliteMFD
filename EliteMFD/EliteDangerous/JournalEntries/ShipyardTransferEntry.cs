using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class ShipyardTransferEntry : JournalEntry
    {
        #region parameters
        public string ShipType { get; set; }
        public string System { get; set; }
        public double Distance { get; set; }
        public long TransferPrice { get; set; }
        public long TransferTime { get; set; }
        #endregion

        public ShipyardTransferEntry(JObject entry) : base(entry)
        {
            ShipType = entry.Value<string>("ShipType");
            System = entry.Value<string>("System");
            Distance = entry.Value<double>("Distance");
            TransferPrice = entry.Value<long>("TransferPrice");
            TransferTime = entry.Value<long>("TransferTime");
        }
    }
}