using System;

namespace Lingual.Proxy
{
    public class TypeHasNotBeenCreatedException : ApplicationException
    {
        public string TypeName { get; private set; }

        public TypeHasNotBeenCreatedException(string typeName)
            : base("The type \"" + typeName + "\" has not yet been created.  You must call \"CompleteType\" before continuing.")
        {
            TypeName = typeName;
        }
    }
}