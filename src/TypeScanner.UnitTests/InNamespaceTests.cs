using FluentAssertions;
using TypeScanner.UnitTests.TestAssembly;
using TypeScanner.UnitTests.TestAssembly.NamespaceTests;
using Xunit;

namespace TypeScanner.UnitTests
{
    public class InNamespaceTests
    {
        [Fact]
        public void InNamespace_ShouldOnlyReturnTypesInTheProvidedNamespace()
        {
            var namespaceToSearchFor = typeof (NamespaceTestsTypeA).Namespace;

            Types
                .InAssemblyContaining<IAmTheTestAssembly>()
                .InNamespace(namespaceToSearchFor)
                .ShouldOnlyContainTypes<
                    NamespaceTestsTypeA,
                    NamespaceTestsTypeB, 
                    NamespaceTestsTypeC
                >();
        }

        [Fact]
        public void InNamespace_ShouldOnlyReturnTypesInTheProvidedNamespace_CaseInsensitive()
        {
            var upperCaseNamespaceToSearchFor = typeof(NamespaceTestsTypeA).Namespace.ToUpper();

            Types
                .InAssemblyContaining<IAmTheTestAssembly>()
                .InNamespace(upperCaseNamespaceToSearchFor)
                .ShouldOnlyContainTypes<
                    NamespaceTestsTypeA,
                    NamespaceTestsTypeB,
                    NamespaceTestsTypeC
                >();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("\t")]
        [InlineData("")]
        public void InNamespace_ShouldReturnEmptyEnumerableWhenNamespaceNameNullEmptyOrWhitespace(string namespaceName)
        {
            Types
                .InAssemblyContaining<IAmTheTestAssembly>()
                .InNamespace(namespaceName)
                .Should()
                .BeEmpty();
        }
    }
}