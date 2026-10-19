using System.Numerics;

namespace TestGame.Api.Math.Vectors;

public interface IVector<TSelf, TItem>:
	IFormattable,
	IComparable<TSelf>,
	IEquatable<TSelf>,
	IMinMaxValue<TSelf>,
	IIncrementOperators<TSelf>,
	IDecrementOperators<TSelf>,
	IUnaryPlusOperators<TSelf, TSelf>,
	IUnaryNegationOperators<TSelf, TSelf>,
	IAdditionOperators<TSelf, TSelf, TSelf>,
	ISubtractionOperators<TSelf, TSelf, TSelf>,
	IMultiplyOperators<TSelf, TSelf, TSelf>,
	IDivisionOperators<TSelf, TSelf, TSelf>,
	IModulusOperators<TSelf, TSelf, TSelf>,
	IComparisonOperators<TSelf, TSelf, bool>
	where TSelf: IVector<TSelf, TItem>
	where TItem: INumber<TItem>
{
	public float Length { get; }
	
	public TItem this[int index] { get; }
	
	public TItem this[char name] { get; }
	
	public static abstract TSelf Abs(TSelf value);
	
	public static abstract TSelf Min(TSelf first, TSelf second);
	
	public static abstract TSelf Max(TSelf first, TSelf second);

	public static abstract TSelf Clamp(TSelf value, TSelf min, TSelf max);
	
	public static abstract TSelf Clamp(TSelf value, TItem min, TItem max);
}