using System;
using System.Collections.Generic;
using FluentAssertions;

namespace TypeScanner.UnitTests
{
    public static class TypeAssertions
    {
        public static void ShouldOnlyContainTypes<T1,T2, T3>(this IEnumerable<Type> types)
        {
            types.Should().BeEquivalentTo(typeof (T1), typeof (T2), typeof(T3));
        }
    }
}