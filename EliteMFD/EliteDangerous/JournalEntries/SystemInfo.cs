using System;
using System.Windows.Media.Media3D;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface ISystemInfo
    {
        string StarSystem { get; set; }
        Point3D StarPos { get; set; }
        string Body { get; set; }
        string BodyType { get; set; }
        string SystemFaction { get; set; }
        string SystemAllegiance { get; set; }
        string SystemEconomy { get; set; }
        string SystemGovernment { get; set; }
        string SystemSecurity { get; set; }
    }

    partial class JournalEntry : ISystemInfo
    {
        [JsonConverter(typeof(VectorConverter))]
        public Point3D StarPos { get; set; }
        public string Body { get; set; }
        public string BodyType { get; set; }
        public string SystemFaction { get; set; }
        public string SystemAllegiance { get; set; }
        public string SystemEconomy { get; set; }
        public string SystemGovernment { get; set; }
        public string SystemSecurity { get; set; }
    }

    class VectorConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray coords = JArray.Load(reader);
            var x = Math.Round(coords[0].Value<float>(), 3);
            var y = Math.Round(coords[1].Value<float>(), 3);
            var z = Math.Round(coords[2].Value<float>(), 3);
            return new Point3D(x, y, z);
        }

        public override bool CanConvert(Type objectType) => objectType == typeof(Point3D);

        public override bool CanWrite => false;
    }
}
