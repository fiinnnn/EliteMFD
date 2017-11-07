using System;
using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class FuelScoopEntry : JournalEntry
    {
        #region parameters
        public double Scooped { get; set; }
        public double Total { get; set; }
        #endregion

        public FuelScoopEntry(JObject entry) : base(entry)
        {
            Scooped = entry.Value<double>("Scooped");
            Total = entry.Value<double>("Total");
        }
    }
}
