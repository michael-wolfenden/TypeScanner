using TypeScanner.UnitTests.TestAssembly;
using Xunit;

namespace TypeScanner.UnitTests
{
    public class ImplementingTests
    {
        [Fact]
        public void Implementing_ShouldOnlyReturnTypesThatImplementTheInterfaceNotIncludeTheInterfaceItself_GenericTypeParameter()
        {
            Types
                .InAssemblyContaining<IAmTheTestAssembly>()
                .Implementing<IImplementingTests>()
                .ShouldOnlyContainTypes<
                    ImplementingTestsTypeA,
                    ImplementingTestsTypeB,
                    ImplementingTestsTypeC
                >();
        }

        [Fact]
        public void Implementing_ShouldOnlyReturnTypesThatImplementTheInterfaceNotIncludeTheInterfaceItself_Type()
        {
            Types
                .InAssemblyContaining<IAmTheTestAssembly>()
                .Implementing(typeof(IImplementingTests))
                .ShouldOnlyContainTypes<
                    ImplementingTestsTypeA,
                    ImplementingTestsTypeB,
                    ImplementingTestsTypeC
                >();
        }
    }
}