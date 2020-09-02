using Newtonsoft.Json;
using Orro.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Orro
{
    class DeviceCollection : IEnumerable, IStorable
    {
        private List<IDevice> Devices = new List<IDevice>();
        public IEnumerator GetEnumerator()
        {
            return Devices.GetEnumerator();
        }
        public void Add(IDevice device)
        {
            Devices.Add(device);
        }
        public void Remove(int index)
        {
            Devices.RemoveAt(index);
        }
        public void Remove(IDevice device)
        {
            Devices.Remove(device);
        }

        public void ToJson<T>(T instance, string location)
        {
            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(location))
            {
                var result = JsonConvert.SerializeObject(instance, Formatting.Indented, new DeviceCollectionConverter());
                file.Write(result);
            }
        }

        public T FromJson<T>(string location)
        {
            var JSON = File.ReadAllText(location);
            var result = JsonConvert.DeserializeObject<T>(JSON, new DeviceCollectionConverter());

            if (result is T)
            {
                return result;
            }
            else
            {
                throw new Exception($"This should ony be used to access {typeof(T)} devices!");
            }
        }
    }
}
