using CBS._006.Base;

namespace CBS._006.Lib1
{
    [ExternalLibraryCommand]
    public class Class1: CommandBase
    {
        protected override string Id => typeof(Class1).FullName;
    }
}
