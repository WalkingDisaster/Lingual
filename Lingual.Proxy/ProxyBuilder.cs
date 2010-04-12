using System;
using System.Configuration.Assemblies;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace Lingual.Proxy
{
    public class ProxyBuilder
    {
        private readonly AssemblyBuilder _assemblyBuilder;
        private readonly ModuleBuilder _moduleBuilder;
        private readonly string _assemblyName;

        public ProxyBuilder(string assemblyName)
        {
            _assemblyBuilder =
                AppDomain.CurrentDomain.DefineDynamicAssembly(
                    new AssemblyName
                        {
                            CodeBase = Directory.GetCurrentDirectory(),
                            CultureInfo = CultureInfo.CurrentCulture,
                            HashAlgorithm = AssemblyHashAlgorithm.SHA1,
                            Name = assemblyName,
                            Version = new Version(1, 0, 0, 0)
                        },
                    AssemblyBuilderAccess.RunAndSave);
            _assemblyName = assemblyName + ".dll";
            _moduleBuilder = _assemblyBuilder.DefineDynamicModule(assemblyName, _assemblyName);
        }

        public ProxyType CreateClass(string name)
        {
            return new ProxyType(name, _moduleBuilder.DefineType(name, TypeAttributes.Public));
        }

        public void SaveAssembly()
        {
            _assemblyBuilder.Save(_assemblyName);
        }
    }
}
