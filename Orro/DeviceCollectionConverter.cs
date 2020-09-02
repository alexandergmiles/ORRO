using Newtonsoft.Json;
using Orro.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Orro
{
    class DeviceCollectionConverter : JsonConverter<DeviceCollection>
    {
        public override DeviceCollection ReadJson(JsonReader reader, Type objectType, [AllowNull] DeviceCollection existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] DeviceCollection value, JsonSerializer serializer)
        {
            //writer.WriteStartObject();
            writer.WriteStartArray();
            foreach(var item in value)
            {
                var newItem = item as IDevice;
                writer.WriteStartObject();
                writer.WritePropertyName("Encryption");
                writer.WriteValue(newItem.Encryption.ToString());
                writer.WritePropertyName("ConnectionType");
                writer.WriteValue(newItem.Connection.ToString());
                writer.WritePropertyName("DeviceIP");
                writer.WriteValue(newItem.DeviceIP.ToString());
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
            //writer.WriteEndObject();
        }
    }
}
