using System.Reflection;

namespace Lingual.Proxy
{
    public struct MethodFieldPair
    {
        public readonly MethodInfo Method;
        public readonly FieldInfo Field;

        public MethodFieldPair(MethodInfo method, FieldInfo field) : this()
        {
            Method = method;
            Field = field;
        }
    }
}