using System;
using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class LoadGameEntry : JournalEntry
    {
        #region parameters
        public string Commander { get; set; }
        public string Ship { get; set; }
        public string ShipName { get; set; } // player-defined ship name
        public string ShipIdent { get; set; } // player-defined ship id
        public double FuelLevel { get; set; }
        public double FuelCapacity { get; set; }
        public string GameMode { get; set; }
        public string Group { get; set; }
        public long Credits { get; set; }
        public long Loan { get; set; }
        #endregion

        public LoadGameEntry(JObject entry) : base(entry)
        {
            Commander = entry.Value<string>("Commander");
            Ship = entry.Value<string>("Ship");
            ShipName = entry.Value<string>("ShipName");
            ShipIdent = entry.Value<string>("ShipIdent");
            FuelLevel = entry.Value<double>("FuelLevel");
            FuelCapacity = entry.Value<double>("FuelCapacity");
            GameMode = entry.Value<string>("GameMode");
            if (GameMode == "Group")
                Group = entry.Value<string>("Group");
            Credits = entry.Value<long>("Credits");
            Loan = entry.Value<long>("Loan");
        }
    }
}
