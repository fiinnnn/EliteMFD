using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class VehicleSwitchEntry : JournalEntry
    {
        #region parameters
        public string To { get; set; }
        #endregion

        public VehicleSwitchEntry(JObject entry) : base(entry)
        {
            To = entry.Value<string>("To");
        }
    }
}