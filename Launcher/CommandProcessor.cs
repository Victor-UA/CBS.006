using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using CBS._006.Base;
using CBS._006.Base.Interfaces;

namespace CBS._006.Launcher
{
    static class CommandProcessor
    {
        static CommandProcessor()
        {
            
        }

        private static IList<ExternalLibrary> _libraries;

        public static int LibrariesCount => _libraries?.Count ?? 0;

        public static void LoadLibraries()
        {
            _libraries = new List<ExternalLibrary>();
            var libDir = new DirectoryInfo("Libraries");
            if (libDir.Exists)
            {
                var libs = libDir.GetFiles("*.dll");
                foreach (var fileInfo in libs)
                {
                    var assembly = Assembly.LoadFile(fileInfo.FullName);
                    var classes = assembly.GetTypes().Where(t =>
                        t.IsClass
                        && t.IsVisible
                        && t.CustomAttributes.Any(a => a.AttributeType == typeof(ExternalLibraryCommandAttribute)));
                    var library = new ExternalLibrary(assembly.FullName);
                    _libraries.Add(library);
                    foreach (var type in classes)
                    {
                        var command = Activator.CreateInstance(type) as CommandBase ??
                                      Activator.CreateInstance(type) as CBS._006.Base.Interfaces.ICommand;

                        library.Commands.Add(type.Name, command as CommandBase);
                    }
                }
            }
        }

        public static void ProcessCommand(string name)
        {
            foreach (var library in _libraries)
            {
                if (library.Commands.Keys.Contains(name))
                {
                    library.Commands[name].Execute();
                }                
            }
        }
    }
}
