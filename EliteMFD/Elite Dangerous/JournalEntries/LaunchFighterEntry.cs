using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class LaunchFighterEntry : JournalEntry
    {
        #region parameters
        public bool PlayerControlled { get; set; }
        #endregion

        public LaunchFighterEntry(JObject entry) : base(entry)
        {
            PlayerControlled = entry.Value<bool>("PlayerControlled");
        }
    }
}
