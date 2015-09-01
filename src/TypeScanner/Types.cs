using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class Types
{
    public static IEnumerable<Type> InAssembly(Assembly assembly)
    {
        return GetLoadableTypes(assembly);
    }

    public static IEnumerable<Type> InAssemblyContainingType<T>()
    {
        var assembly = GetAssemblyFromType<T>();
        return GetLoadableTypes(assembly);
    }

    private static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
    {
        try
        {
            return GetTypes(assembly);
        }
        catch (ReflectionTypeLoadException ex)
        {
            // The exception is thrown if some types cannot be loaded in partial trust.
            // For our purposes we just want to get the types that are loaded, which are
            // provided in the Types property of the exception.
            return ex.Types.Where(type => type != null);
        }
    }

    private static IEnumerable<Type> GetTypes(Assembly assembly)
    {
#if PORTABLE
        return assembly.DefinedTypes.Select(t => t.AsType());
#else
        return assembly.GetTypes();
#endif
    }

    private static Assembly GetAssemblyFromType<T>()
    {
#if PORTABLE
        return typeof (T).GetTypeInfo().Assembly;
#else
        return typeof(T).Assembly;
#endif
    }
}