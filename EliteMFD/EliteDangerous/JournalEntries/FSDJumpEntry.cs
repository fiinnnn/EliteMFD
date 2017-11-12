using Vector3D;
using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class FSDJumpEntry : SystemInfo
    {
        #region parameters
        public double JumpDist { get; set; }
        public double FuelUsed { get; set; }
        public double FuelLevel { get; set; }
        public bool BoostUsed { get; set; }
        #endregion

        public FSDJumpEntry(JObject entry) : base(entry)
        {
            JumpDist = entry.Value<double>("JumpDist");
            FuelUsed = entry.Value<double>("FuelUsed");
            FuelLevel = entry.Value<double>("FuelLevel");
            BoostUsed = entry.Value<bool>("BoostUsed");
        }
    }
}
