using System;
using System.Collections.Generic;
using System.Text;

namespace Orro.Interfaces
{
    interface IHub
    {
        public void Add(IDevice device);
        public void Remove(IDevice device);
        public void Remove(int index);
        public DataItem GetValueFromDevice(IDevice device);

        public DataItem StreamValueFromdDevice(IDevice device);

        public bool WriteToRemoteSource(List<DataItem> dataItems);
    }
}
