using Orro.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orro
{
    class Hub
    {
        //Our list of devices
        IList<IDevice> devices = new List<IDevice>();

        //Add a device to the list
        public void Add(IDevice device) => devices.Add(device);
        public void Remove(IDevice device) => devices.Remove(device);
        public void Remove(int index) => devices.Remove(devices[index]);

        //Get the value from the device
        //IHub will have a communication destination
        //AWSHub for example
        //LocalHub
        //public DataItem GetValueFromDevice(IDevice device)
        //{
        //    //Get the current value from the device
        //    return device.GetValuesFromDevice();
        //}

        //public bool WriteToRemoteSource(List<DataItem> dataItems)
        //{
        //    return true;
        //}

        //public DataItem StreamValueFromdDevice(IDevice device)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
