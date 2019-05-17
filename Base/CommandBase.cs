using System;
using CBS._006.Base.Interfaces;

namespace CBS._006.Base
{
    public abstract class CommandBase: ICommand
    {
        protected abstract string Id { get; }

        public void Execute()
        {
            Console.WriteLine($"{Id}: Execute");
        }
    }
}
