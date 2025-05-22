using Vanara.Extensions.Reflection;

namespace Vanara.Marshaler;

/// <summary>Indicates the data layout of the marshaled array.</summary>
public enum ArrayLayout
{
	/// <summary>
	/// Array of sequential values with a fixed size specified by SizeConst property. ArraySubType property should be used if marshaling
	/// needed for subtype. SizeConst must be used.
	/// </summary>
	ByValArray,

	/// <summary>
	/// Array of sequential values with a size specified by another field whose first value is the last field in a structure with all
	/// remaining fields appended to the end of the structure in memory. ArraySubType property should be used if marshaling needed for
	/// subtype. StringLenFieldName must be used.
	/// </summary>
	ByValAnySizeArray,

	/// <summary>
	/// Array of sequential values with a size specified by another field whose values are appended to the end of the structure in memory.
	/// ArraySubType property should be used if marshaling needed for subtype. StringLenFieldName must be used.
	/// </summary>
	ByValAppendedArray,

	/// <summary>
	/// Pointer to an array of sequential values with a size specified by another field. ArraySubType property should be used if marshaling
	/// needed for subtype. StringLenFieldName must be used.
	/// </summary>
	LPArray,

	/// <summary>Pointer to an array of pointers to strings. StringLenFieldName must be used.</summary>
	StringPtrArray,

	/// <summary>
	/// Pointer to a null-terminated array of pointers to strings where the final pointer is null. Size is inferred from the array.
	/// </summary>
	StringPtrArrayNullTerm,

	/// <summary>Pointer to a null-terminated array of pointers to strings. Size is inferred from the array.</summary>
	ConcatenatedStringArray,

	/*// OLE defined SAFEARRAY
	SafeArray,*/

	/*// Pointer to an array of sequential values terminated by a null or default value. ArraySubType property should be used if marshaling needed for subtype.
	LPArrayNullTerm,*/
}

/// <summary>Specifies the number of bits in a pointer for a marshaled value.</summary>
public enum Bitness
{
	/// <summary>Selects the bit count automatically based on the current OS.</summary>
	Auto = 0,

	/// <summary>Implies a 32-bit OS.</summary>
	X32bit = 32,

	/// <summary>Implies a 64-bit OS.</summary>
	X64bit = 64,
}

/// <summary>Determines the layout of the structure or class when marshaled.</summary>
public enum LayoutModel
{
	/// <summary>The layout matches the order of the fields in the structure or class.</summary>
	Sequential,

	/// <summary>
	/// The layout is a union of all the fields in the structure or class. In this instance, all field values but one should be set to their
	/// default values.
	/// </summary>
	Union
}

/// <summary>Identifies the type of encoding used to read and write binary representations of strings.</summary>
public enum StringEncoding
{
	/// <summary>The automatic encoding. Typically Unicode.</summary>
	Default = CharSet.Ansi,

	/// <summary>ANSI encoding.</summary>
	[CorrespondingType(typeof(ASCIIEncoding))]
	ASCII = 11,

	/// <summary>Unicode encoding.</summary>
	[CorrespondingType(typeof(UnicodeEncoding))]
	Unicode = CharSet.Unicode,

	/// <summary>UTF-8 encoding.</summary>
	[CorrespondingType(typeof(UTF8Encoding))]
	UTF8 = 12,

	/// <summary>UTF-32 encoding.</summary>
	[CorrespondingType(typeof(UTF32Encoding))]
	UTF32 = 13,
}

/// <summary>Attribute that can be applied to classes and structures to indicate that they support custom marshaling.</summary>
[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class MarshaledAttribute(LayoutModel layout = LayoutModel.Sequential) : Attribute()
{
	private int pack = 0;

	/// <summary>Gets or sets the bitness.</summary>
	/// <value>The bitness.</value>
	public Bitness Bitness { get; set; } = Bitness.Auto;

	/// <summary>Gets the layout.</summary>
	/// <value>The layout.</value>
	public LayoutModel Layout { get; } = layout;

	/// <summary>Gets or sets the pack.</summary>
	/// <value>The pack.</value>
	/// <exception cref="System.ArgumentOutOfRangeException">value</exception>
	public int Pack { get => pack; set => pack = value >= 0 && (value == 0 || value.IsPow2()) ? value : throw new ArgumentOutOfRangeException(nameof(value)); }

	/// <summary>Gets or sets the size.</summary>
	/// <value>The size.</value>
	public int Size { get; set; } = 0;

	/// <summary>Gets or sets the character encoding.</summary>
	/// <value>The character encoding.</value>
	public StringEncoding StringEncoding { get; set; } = StringEncoding.Unicode;

	internal Encoding Encoding => StringEncoding.ToEncoding();
}

/// <summary>A set of attributes to facilitate custom marshaling.</summary>
public static class MarshalFieldAs
{
	internal interface IMarshalAsAttr { }

	/// <summary>
	/// Attribute that is applied to a string as the final field in a structure to indicate that the string value is appended to the end of
	/// the structure. The string is null-terminated. The <paramref name="embeddedCharacters"/> value determines if any characters are
	/// counted in the native size of the structure.
	/// </summary>
	/// <param name="stringLenFieldName">
	/// The name of the field that holds the length of the string, in characters. If <see langword="null"/>, the string will be read until a
	/// <c>'\0'</c> value is found.
	/// </param>
	/// <param name="embeddedCharacters">The number of characters embedded in the structure's native size.</param>
	/// <param name="stringEncoding">The character encoding of the string.</param>
	/// <seealso cref="System.Attribute"/>
	/// <seealso cref="Vanara.Marshaler.MarshalFieldAs.IMarshalAsAttr"/>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class AppendedStringAttribute(string? stringLenFieldName, int embeddedCharacters = 1, StringEncoding stringEncoding = StringEncoding.Unicode) : Attribute, IMarshalAsAttr
	{
		/// <summary>
		/// Gets the number of characters embedded in the structure's native size. For ANYSIZE strings, this value is the default of <c>1</c>.
		/// </summary>
		/// <value>The number of characters embedded in the structure's native size.</value>
		public int EmbeddedCharacters { get; } = embeddedCharacters;

		/// <summary>
		/// Gets or sets the name of the field that holds the length of the string, in characters. If <see langword="null"/>, the string will
		/// be read until a <c>'\0'</c> value is found.
		/// </summary>
		/// <value>The name of the field that holds the length of the string, in characters.</value>
		public string? StringLenFieldName { get; set; } = stringLenFieldName;

		/// <summary>Gets or sets the character encoding.</summary>
		/// <value>The character encoding.</value>
		public StringEncoding StringEncoding { get; set; } = stringEncoding;

		internal Encoding Encoding => StringEncoding.ToEncoding();
	}

	/// <summary>
	/// Attribute that can be applied to fields in a structure or class to indicate that the field is an array of values in a specified
	/// layout and size.
	/// </summary>
	/// <param name="layout">A value that indicates how the array is stored within memory.</param>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class ArrayAttribute(ArrayLayout layout) : Attribute, IMarshalAsAttr
	{
		/// <summary>Gets the layout of the marshaled array.</summary>
		/// <value>The array layout.</value>
		public ArrayLayout Layout { get; } = layout;

		/// <summary>Gets or sets the size of the array as a constant value.</summary>
		/// <value>The size of the array as a constant value.</value>
		public int SizeConst { get; set; } = 0;

		/// <summary>Gets or sets the name of the field that holds the size of the array.</summary>
		/// <value>The name of the field that holds the size of the array.</value>
		public string? SizeFieldName { get; set; } = null;

		/// <summary>Gets or sets the character encoding.</summary>
		/// <value>The character encoding.</value>
		public StringEncoding StringEncoding { get; set; } = StringEncoding.Unicode;

		internal Encoding Encoding => StringEncoding.ToEncoding();
	}

	/// <summary>Attribute that can be applied to fields in a structure or class to indicate that the field is a bitfield.</summary>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class BitFieldAttribute<T> : Attribute, IMarshalAsAttr where T : unmanaged, IConvertible
	{
		/// <summary>Initializes a new instance of the <see cref="BitFieldAttribute{T}"/> class.</summary>
		/// <param name="bitCount">The bit count.</param>
		/// <exception cref="System.ArgumentException">Generic type must be an integral. - T</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">bitCount</exception>
		public BitFieldAttribute(int bitCount = 1)
		{
			if (!typeof(T).IsIntegral()) throw new ArgumentException("Generic type must be an integral.", nameof(T));
			BitCount = bitCount >= 1 && bitCount <= typeof(T).GetBitSize() ? bitCount : throw new ArgumentOutOfRangeException(nameof(bitCount));
		}

		/// <summary>The number of bits in the field. The default is 1. The maximum value is bit size of <typeparamref name="T"/>.</summary>
		public int BitCount { get; }

		/// <summary>If <see langword="true"/>, the field starts a new underlying field in the structure. The default is <see langword="false"/>.</summary>
		public bool StartNewField { get; set; } = false;
	}

	/// <summary>
	/// Attribute that can be applied to fields in a structure or class to indicate that the field is a pointer to a string of a specified length.
	/// </summary>
	/// <param name="length">
	/// The length, in characters, of the string. Whether or not a NULL terminator is included is specified by <paramref name="nullTerm"/>..
	/// </param>
	/// <param name="nullTerm"><see langword="true"/> if the NULL terminator is included in <paramref name="length"/>; otherwise <see langword="false"/>.</param>
	/// <param name="stringEncoding">The character encoding of the string.</param>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FixedStringAttribute(int length, bool nullTerm = true, StringEncoding stringEncoding = StringEncoding.Unicode) : Attribute, IMarshalAsAttr
	{
		/// <summary>The length, in characters, of the string. Whether or not a NULL terminator is included is specified by <see cref="NullTerm"/>.</summary>
		public int Length { get; } = length;

		/// <summary>Determines whether the NULL terminator is included in <see cref="Length"/>. The default is <see langword="true"/>.</summary>
		public bool NullTerm { get; } = nullTerm;

		/// <summary>Gets or sets the character encoding.</summary>
		/// <value>The character encoding.</value>
		public StringEncoding StringEncoding { get; set; } = stringEncoding;

		internal Encoding Encoding => StringEncoding.ToEncoding();
	}

	/// <summary>
	/// Attribute that can be applied to fields in a structure or class to indicate that the field should be initialized with the native size
	/// of the parent structure or class or that indicates the size of the native structure or class on retrieval.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class SizeOfAttribute : Attribute, IMarshalAsAttr
	{
		/// <summary>
		/// If <see langword="false"/>, the default, the field is initialized with the native size of the parent structure or class. When
		/// <see langword="true"/>, the size includes any additional bytes allocated for the last field, which must be a fixed array or fixed
		/// size string.
		/// </summary>
		public bool IncludeAnySizeAllocation { get; set; } = false;
	}

	/// <summary>Attribute that can be applied to fields in a structure or class to indicate that the field is a pointer to a structure.</summary>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class StructPtrAttribute : Attribute, IMarshalAsAttr
	{
	}

	/// <summary>
	/// Attribute that can be applied to fields in a structure or class to indicate that the field is part of a union. If the <see
	/// cref="UnionId"/> is not set, then an id is generated for all union fields that also do not have a unionId specified.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class UnionFieldAttribute(string unionId = "") : Attribute, IMarshalAsAttr
	{
		/// <summary>Gets or sets the union identifier.</summary>
		/// <value>The union identifier.</value>
		public string UnionId { get; set; } = unionId;
	}
}