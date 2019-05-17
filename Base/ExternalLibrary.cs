using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBS._006.Base.Interfaces;

namespace CBS._006.Base
{
    public class ExternalLibrary
    {
        public ExternalLibrary(string name)
        {
            Name = name;
            Commands = new Dictionary<string, ICommand>();
        }

        public string Name { get; }
        public IDictionary<string, CBS._006.Base.Interfaces.ICommand> Commands { get; }
    }
}
