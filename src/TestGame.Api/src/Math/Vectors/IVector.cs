using System.Numerics;

namespace TestGame.Api.Math.Vectors;

public interface IVector<TSelf, in TItem>:
	IEquatable<TSelf>,
	IMinMaxValue<TSelf>
	where TSelf: IVector<TSelf, TItem>
	where TItem: INumber<TItem>
{
	public float Length();

	public float LengthSquared();

	public TSelf Abs();

	public TSelf Clamp(TSelf min, TSelf max);
	
	public TSelf Clamp(TItem min, TItem max);

	public float DistanceTo(TSelf vector);

	public void operator += (TSelf vector);
	public void operator += (TItem number);

	public void operator -= (TSelf vector);
	public void operator -= (TItem number);

	public void operator *= (TSelf vector);
	public void operator *= (TItem number);

	public void operator /= (TSelf vector);
	public void operator /= (TItem number);

	public static abstract TSelf operator + (TSelf left, TSelf right);
	public static abstract TSelf operator + (TSelf left, TItem right);
	
	public static abstract TSelf operator - (TSelf left, TSelf right);
	public static abstract TSelf operator - (TSelf left, TItem right);
	
	public static abstract TSelf operator * (TSelf left, TSelf right);
	public static abstract TSelf operator * (TSelf left, TItem right);
	
	public static abstract TSelf operator / (TSelf left, TSelf right);
	public static abstract TSelf operator / (TSelf left, TItem right);
	
	public static abstract TSelf operator + (TSelf vector);
	public static abstract TSelf operator - (TSelf vector);
	
	public static abstract TSelf operator ++ (TSelf vector);
	public static abstract TSelf operator -- (TSelf vector);

	public static abstract bool operator == (TSelf left, TSelf right);
	public static abstract bool operator != (TSelf left, TSelf right);

	public static abstract bool operator > (TSelf left, TSelf right);
	public static abstract bool operator < (TSelf left, TSelf right);

	public static abstract bool operator >= (TSelf left, TSelf right);
	public static abstract bool operator <= (TSelf left, TSelf right);
}