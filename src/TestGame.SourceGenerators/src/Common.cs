using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace TestGame.SourceGenerators;

internal static class Common {
    extension(ITypeSymbol type) {
        internal bool IsInheritsFrom(ITypeSymbol baseType, IEqualityComparer<ITypeSymbol> comparer) {
            for (ITypeSymbol? symbol = type.BaseType; symbol != null; symbol = symbol.BaseType)
                if (comparer.Equals(symbol, baseType))
                    return true;
            return false;
        }

        internal bool IsInheritsFrom(ITypeSymbol baseType) {
            return type.IsInheritsFrom(baseType, SymbolEqualityComparer.Default);
        }
    }
}
