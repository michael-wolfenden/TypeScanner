using TypeScanner.UnitTests.TestAssembly.NamespaceTests;
using Xunit;

namespace TypeScanner.UnitTests
{
    public class InSameNamespaceAsTests
    {
        [Fact]
        public void InSameNamespaceAs_ShouldOnlyReturnTypesInTheSameNamespaceAsTheProvidedType()
        {
            Types
                .InSameNamespaceAs<NamespaceTestsTypeA>()
                .ShouldOnlyContainTypes<
                    NamespaceTestsTypeA,
                    NamespaceTestsTypeB, 
                    NamespaceTestsTypeC
                >();
        }
    }
}