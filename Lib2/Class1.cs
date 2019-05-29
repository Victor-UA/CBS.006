using System;
using CBS._006.Base;

namespace CBS._006.Lib2
{
    [ExternalLibraryCommand]
    public class Class1: CommandBase
    {
        protected override string Id => typeof(Class1).FullName;

        [ExternalLibraryCommand(nameof(Internal))]
        protected void Internal() { }

    }
}
