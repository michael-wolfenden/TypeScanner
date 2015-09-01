using System;
using System.Collections.Generic;
using System.Linq;

namespace TypeScanner
{
    public static class TypesExtensions
    {
        public static IEnumerable<Type> InNamespace(this IEnumerable<Type> types, string namespaceName)
        {
            if (namespaceName.IsNullOrWhiteSpace())
            {
                return Enumerable.Empty<Type>();
            }

            return types.Where(type => 
                !type.Namespace.IsNullOrWhiteSpace() && 
                type.Namespace.EqualsIgnoreCase(namespaceName)
            );
        }

        public static IEnumerable<Type> Implementing<TInterface>(this IEnumerable<Type> types)
        {
            return types.Implementing(typeof (TInterface));
        }

        public static IEnumerable<Type> Implementing(this IEnumerable<Type> types, Type interfaceType)
        {
            return types.Where(type =>
                type != interfaceType &&
                type.IsAssignableTo(interfaceType)
            );
        }
    }
}