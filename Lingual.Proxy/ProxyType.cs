using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Lingual.Proxy
{
    public class ProxyType
    {
        private readonly string _name;
        private readonly TypeBuilder _typeBuilder;
        private readonly List<KeyValuePair<string, string>> _methodAndFieldNames;

        private Type _completedType;

        public ProxyType(string name, TypeBuilder typeBuilder)
        {
            _name = name;
            _typeBuilder = typeBuilder;
            _methodAndFieldNames = new List<KeyValuePair<string, string>>();
        }

        public void CreateMethodThatExecutionsAnActionDelegate(string methodName)
        {
            var fieldName = Guid.NewGuid().ToString();
            var field = _typeBuilder.DefineField(fieldName, typeof (Delegate), FieldAttributes.Public);
            var method = _typeBuilder.DefineMethod(methodName, MethodAttributes.Public | MethodAttributes.HideBySig, typeof(void), null);
            var ilGen = method.GetILGenerator();
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldfld, field);
            ilGen.EmitCall(OpCodes.Callvirt, typeof(Action).GetMethod("Invoke"), null);
            ilGen.Emit(OpCodes.Ret);

            _methodAndFieldNames.Add(new KeyValuePair<string, string>(methodName, fieldName));
        }

        public Type CompleteType()
        {
            if (_completedType != null)
                throw new TypeHasAlreadyBeenCreatedException(_name);
            _completedType = _typeBuilder.CreateType();
            return _completedType;
        }

        public IList<MethodFieldPair> MethodAndFieldPairs
        {
            get
            {
                if (_completedType == null)
                    throw new TypeHasNotBeenCreatedException(_name);
                return (from pair in _methodAndFieldNames
                        let method = _completedType.GetMethod(pair.Key, BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod)
                        let field = _completedType.GetField(pair.Value)
                        select new MethodFieldPair(method, field)).ToList();
            }
        }
    }
}