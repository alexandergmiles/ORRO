using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Interfaces
{
    public interface ICommand
    {
        string GetCommandString();

        string Execute(IDevice device);
    }
}
