using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class USSDropEntry : JournalEntry
    {
        #region parameters
        public string USSType { get; set; }
        public int USSThreat { get; set; }
        #endregion

        public USSDropEntry(JObject entry) : base(entry)
        {
            USSType = entry.Value<string>("USSType");
            USSThreat = entry.Value<int>("USSThreat");
        }
    }
}