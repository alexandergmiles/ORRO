using Newtonsoft.Json;
using Orro.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Orro
{
    class DeviceConverter : JsonConverter<IDevice>
    {
        public override IDevice ReadJson(JsonReader reader, Type objectType, [AllowNull] IDevice existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] IDevice value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Encryption");
            writer.WriteValue(value.Encryption.ToString());
            writer.WritePropertyName("ConnectionType");
            writer.WriteValue(value.Connection.ToString());
            writer.WritePropertyName("DeviceIP");
            writer.WriteValue(value.DeviceIP.ToString());
            writer.WriteEndObject();
        }
    }
}
