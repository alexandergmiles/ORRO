using System;
using System.Collections.Generic;
using System.Text;

namespace Orro.Interfaces
{
    interface ICommand
    {
        string GetCommandString();

        void Execute(IDevice device);
    }
}
