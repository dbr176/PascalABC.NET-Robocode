using System;
using System.Linq;
using System.Reflection;

namespace robopascal_runner
{
    public class ReferenceLoader : MarshalByRefObject
    {
        public string[] LoadReferences(string assemblyPath)
        {
            var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);
            var paths = assembly.GetReferencedAssemblies().Select(x => x.FullName).ToArray();
            return paths;
        }

        public string[] LoadClassTypes(string assemblyPath)
        {
            var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);
            var paths = assembly.GetTypes().Where(x => x.IsClass).Select(x => x.FullName).ToArray();
            return paths;
        }
    }
}