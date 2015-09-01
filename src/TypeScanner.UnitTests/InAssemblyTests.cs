using System;
using FluentAssertions;
using Xunit;

namespace TypeScanner.UnitTests
{
    public class InAssemblyTests
    {
        [Fact]
        public void InAssembly_ShouldThrowArgumentNullExceptionWhenAssemblyIsNull()
        {
            Action callingInAssemblyWithNullAssembly = () => Types.InAssembly(null);

            callingInAssemblyWithNullAssembly
                .ShouldThrow<ArgumentNullException>()
                .Where(exception => exception.ParamName == "assembly");
        }
    }
}