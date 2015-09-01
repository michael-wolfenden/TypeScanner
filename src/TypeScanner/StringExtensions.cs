using System;

namespace TypeScanner
{
    internal static class StringExtensions
    {
        internal static bool EqualsIgnoreCase(this string self, string other)
        {
            return string.Equals(self, other, StringComparison.OrdinalIgnoreCase);
        }

        internal static bool IsNullOrWhiteSpace(this string self)
        {
            return string.IsNullOrWhiteSpace(self);
        }
    }
}
