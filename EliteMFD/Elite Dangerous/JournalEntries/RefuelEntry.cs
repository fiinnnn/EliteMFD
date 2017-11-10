using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class RefuelEntry : JournalEntry
    {
        #region parameters
        public long Cost { get; set; }
        public double Amount { get; set; }
        #endregion

        public RefuelEntry(JObject entry) : base(entry)
        {
            Cost = entry.Value<long>("Cost");
            Amount = entry.Value<double>("Amount");
        }
    }
}
