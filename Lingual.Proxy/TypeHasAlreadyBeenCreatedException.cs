using System;

namespace Lingual.Proxy
{
    public class TypeHasAlreadyBeenCreatedException : InvalidOperationException
    {
        public string TypeName { get; private set; }

        public TypeHasAlreadyBeenCreatedException(string typeName)
            : base("The type \"" + typeName + "\" has already been created.")
        {
            TypeName = typeName;
        }
    }
}