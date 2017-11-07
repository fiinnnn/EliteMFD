using Vector3D;
using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class FSDJumpEntry : JournalEntry
    {
        #region parameters
        public string StarSystem { get; set; }
        public Vector StarPos { get; set; }
        public double JumpDist { get; set; }
        public double FuelUsed { get; set; }
        public double FuelLevel { get; set; }
        #endregion

        public FSDJumpEntry(JObject entry) : base(entry)
        {
            StarSystem = entry.Value<string>("StarSystem");
            JArray coords = entry.Value<JArray>("StarPos");
            StarPos = new Vector(coords[0].Value<float>(), coords[1].Value<float>(), coords[2].Value<float>());
            JumpDist = entry.Value<double>("JumpDist");
            FuelUsed = entry.Value<double>("FuelUsed");
            FuelLevel = entry.Value<double>("FuelLevel");
        }
    }
}
