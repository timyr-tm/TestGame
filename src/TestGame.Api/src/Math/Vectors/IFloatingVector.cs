using System.Numerics;

namespace TestGame.Api.Math.Vectors;

public interface IFloatingVector<TSelf, TItem>:
    IVector<TSelf, TItem>
    where TSelf: IFloatingVector<TSelf, TItem>
    where TItem: IFloatingPoint<TItem>
{
    static virtual TSelf Ceiling(TSelf vector) => TSelf.Round(vector, 0, MidpointRounding.ToPositiveInfinity);
    
    static virtual TSelf Floor(TSelf vector) => TSelf.Round(vector, 0, MidpointRounding.ToNegativeInfinity);
    
    static virtual TSelf Truncate(TSelf vector) => TSelf.Round(vector, 0, MidpointRounding.ToZero);
    
    public static abstract TSelf Round(TSelf vector, int digits = 0, MidpointRounding mode = MidpointRounding.ToEven);
}