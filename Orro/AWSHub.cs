using Orro.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orro
{
    sealed class AWSHub : IHub
    {
        IList<IDevice> devices = new List<IDevice>();
        public void Add(IDevice device)
        {
            devices.Add(device);
        }

        public DataItem GetValueFromDevice(IDevice device)
        {
            return device.GetValuesFromDevice();
        }

        public DataItem StreamValueFromDevice(IDevice device)
        {
            return device.GetValuesFromDevice();
        }

        public void Remove(IDevice device)
        {
            devices.Remove(device);
        }

        public void Remove(int index)
        {
            devices.Remove(devices[index]);
        }

        public bool WriteToRemoteSource(List<DataItem> dataItems)
        {
            throw new NotImplementedException();
        }

        public DataItem StreamValueFromdDevice(IDevice device)
        {
            throw new NotImplementedException();
        }
    }
}
