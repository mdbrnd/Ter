using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ter.Commands
{
    internal interface ICommand
    {
        string Name { get; }
        string Docs { get; }
        void Execute(string[] args);
    }
}
