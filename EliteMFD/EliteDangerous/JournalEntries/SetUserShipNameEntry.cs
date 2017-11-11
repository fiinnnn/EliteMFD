using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class SetUserShipName : JournalEntry
    {
        #region parameters
        public string Ship { get; set; }
        public string UserShipName { get; set; }
        public string UserShipId { get; set; }
        #endregion

        public SetUserShipName(JObject entry) : base(entry)
        {
            Ship = entry.Value<string>("Ship");
            UserShipName = entry.Value<string>("UserShipName");
            UserShipId = entry.Value<string>("UserShipId");
        }
    }
}