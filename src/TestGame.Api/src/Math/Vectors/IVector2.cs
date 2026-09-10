using System.Numerics;

namespace TestGame.Api.Math.Vectors;

public interface IVector2<TSelf, TItem>:
	IVector<TSelf, TItem>
	where TSelf: IVector2<TSelf, TItem>
	where TItem: INumber<TItem>
{
	public TItem X { get; set; }
	public TItem Y { get; set; }

	public static abstract implicit operator TSelf((TItem X, TItem Y) tuple);
	
	public static abstract explicit operator Tuple<TItem, TItem>(TSelf vector);
}