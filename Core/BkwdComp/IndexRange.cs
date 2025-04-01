#if NETSTANDARD2_0 || NETFRAMEWORK
namespace System
{
	/// <summary>Represent a type can be used to index a collection either from the start or the end.</summary>
	/// <remarks>
	/// Index is used by the C# compiler to support the new index syntax
	/// <code>
	///int[] someArray = new int[5] { 1, 2, 3, 4, 5 } ;
	///int lastElement = someArray[^1]; // lastElement = 5
	/// </code>
	/// </remarks>
	public readonly struct Index
	{
		private readonly int _value;

		/// <summary>Construct an Index using a value and indicating if the index is from the start or from the end.</summary>
		/// <param name="value">The index value. it has to be zero or positive number.</param>
		/// <param name="fromEnd">Indicating if the index is from the start or from the end.</param>
		/// <remarks>
		/// If the Index constructed from the end, index value 1 means pointing at the last element and index value 0 means pointing at
		/// beyond last element.
		/// </remarks>
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public Index(int value, bool fromEnd = false)
		{
			if (value < 0)
				throw new ArgumentOutOfRangeException(nameof(value), "Index must be non-negative.");
			_value = fromEnd ? ~value : value;
		}
		/// <summary>Indicates whether the index is from the start or the end.</summary>
		public bool IsFromEnd => _value < 0;
		/// <summary>Returns the index value.</summary>
		public int Value => _value < 0 ? ~_value : _value;
		/// <summary>Calculate the offset from the start using the giving collection length.</summary>
		/// <param name="length">The length of the collection that the Index will be used with. length has to be a positive value</param>
		/// <remarks>
		/// For performance reason, we don't validate the input length parameter and the returned offset value against negative values. we
		/// don't validate either the returned offset is greater than the input length. It is expected Index will be used with collections
		/// which always have non negative length/count. If the returned offset is negative and then used to index a collection will get out
		/// of range exception which will be same affect as the validation.
		/// </remarks>
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public int GetOffset(int length) => IsFromEnd ? length + _value + 1 : _value;
		/// <summary>Converts integer number to an Index.</summary>
		public static implicit operator Index(int value) => new(value);
	}

	/// <summary>Represent a range has start and end indexes.</summary>
	/// <remarks>
	/// Range is used by the C# compiler to support the range syntax.
	/// <code>
	///int[] someArray = new int[5] { 1, 2, 3, 4, 5 };
	///int[] subArray1 = someArray[0..2]; // { 1, 2 }
	///int[] subArray2 = someArray[1..^0]; // { 2, 3, 4, 5 }
	/// </code>
	/// </remarks>
	/// <remarks>Construct a Range object using the start and end indexes.</remarks>
	/// <param name="start">Represent the inclusive start index of the range.</param>
	/// <param name="end">Represent the exclusive end index of the range.</param>
	public readonly struct Range(Index start, Index end)
	{
		/// <summary>Represent the inclusive start index of the Range.</summary>
		public Index Start => start;
		/// <summary>Represent the exclusive end index of the Range.</summary>
		public Index End => end;
		/// <summary>Calculate the start offset and length of range object using a collection length.</summary>
		/// <param name="length">The length of the collection that the range will be used with. length has to be a positive value.</param>
		/// <remarks>
		/// For performance reason, we don't validate the input length parameter against negative values. It is expected Range will be used
		/// with collections which always have non negative length/count. We validate the range is inside the length scope though.
		/// </remarks>
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public (int Offset, int Length) GetOffsetAndLength(int length)
		{
			int start = Start.GetOffset(length);
			int end = End.GetOffset(length);
			if ((uint)end > (uint)length || (uint)start > (uint)end)
				throw new ArgumentOutOfRangeException(nameof(length));
			return (start, end - start);
		}
	}
}

//namespace System.Runtime.CompilerServices
//{
//	/// <summary/>
//	internal static partial class RuntimeHelpers
//	{
//		/// <summary>Slices the specified array using the specified range.</summary>
//		public static T[] GetSubArray<T>(T[] array, Range range)
//		{
//			if (array is null)
//				throw new ArgumentNullException(nameof(array));

//			(int offset, int length) = range.GetOffsetAndLength(array.Length);

//			if (length == 0)
//				return [];

//			T[] dest = new T[length];
//			Array.ConstrainedCopy(array, offset, dest, 0, length);
//			return dest;
//		}
//	}
//}
#endif