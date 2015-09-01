using System;
using System.Reflection;

namespace TypeScanner
{
    internal static class TypeExtensions
    {
        internal static bool IsAssignableTo(this Type type, Type typeToCompare)
        {
#if PORTABLE
            return typeToCompare.GetTypeInfo().IsAssignableFrom(type.GetTypeInfo());
#else
            return typeToCompare.IsAssignableFrom(type);
#endif
        }
    }
}
