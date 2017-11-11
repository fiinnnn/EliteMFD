using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class HullDamageEntry : JournalEntry
    {
        #region parameters
        public double Health { get; set; }
        public bool PlayerPilot { get; set; }
        public bool Fighter { get; set; }
        #endregion

        public HullDamageEntry(JObject entry) : base(entry)
        {
            Health = entry.Value<double>("Health");
            PlayerPilot = entry.Value<bool>("PlayerPilot");
            Fighter = entry.Value<bool>("Fighter");
        }
    }
}
