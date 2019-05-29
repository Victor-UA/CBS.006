using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS._006.Base
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExternalLibraryCommandAttribute : Attribute
    {
        public ExternalLibraryCommandAttribute()
        {
            MethodName = null;
        }
        public ExternalLibraryCommandAttribute(string methodName)
        {
            MethodName = methodName;
        }

        public string MethodName { get; }
    }
}
