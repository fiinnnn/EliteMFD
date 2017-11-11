using Vector3D;
using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class SystemInfo : JournalEntry
    {
        #region parameters
        public string StarSystem { get; set; }
        public Vector StarPos { get; set; }
        public string Body { get; set; }
        public string BodyType { get; set; }
        public string SystemFaction { get; set; }
        public string SystemAllegiance { get; set; }
        public string SystemEconomy { get; set; }
        public string SystemGovernment { get; set; }
        public string SystemSecurity { get; set; }
        #endregion

        public SystemInfo(JObject entry) : base(entry)
        {
            StarSystem = entry.Value<string>("StarSystem");
            JArray coords = entry.Value<JArray>("StarPos");
            StarPos = new Vector(coords[0].Value<float>(), coords[1].Value<float>(), coords[2].Value<float>());
            Body = entry.Value<string>("Body");
            BodyType = entry.Value<string>("BodyType");
            SystemFaction = entry.Value<string>("SystemFaction");
            SystemAllegiance = entry.Value<string>("SystemAllegiance");
            SystemEconomy = entry.Value<string>("SystemEconomy_Localised");
            SystemGovernment = entry.Value<string>("SystemGovernment_Localised");
            SystemSecurity = entry.Value<string>("SystemSecurity_Localised");
        }
    }
}
