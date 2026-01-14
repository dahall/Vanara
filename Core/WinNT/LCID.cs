using System.Globalization;

namespace Vanara.PInvoke;

/// <summary>
/// An LCID is a 4-byte value. The value supplied in an LCID is a standard numeric substitution for the international [RFC5646] string.
/// </summary>
/// <seealso cref="IComparable{T}"/>
/// <seealso cref="IConvertible"/>
/// <seealso cref="IEquatable{T}"/>
/// <seealso cref="IEquatable{T}"/>
/// <seealso cref="IComparable"/>
/// <seealso cref="IComparable{T}"/>
/// <seealso cref="IEquatable{T}"/>
[StructLayout(LayoutKind.Sequential)]
[PInvokeData("winnls.h")]
public partial struct LCID : IComparable, IComparable<LCID>, IConvertible, IEquatable<LCID>, IEquatable<uint>
{
	/// <summary>Sort order identifiers.</summary>
	public enum SORT : byte
	{
		/// <summary>sorting default</summary>
		SORT_DEFAULT = 0x0,

		/// <summary>Invariant (Mathematical Symbols)</summary>
		SORT_INVARIANT_MATH = 0x1,

		/// <summary>Japanese XJIS order</summary>
		SORT_JAPANESE_XJIS = 0x0,

		/// <summary>Japanese Unicode order (no longer supported)</summary>
		SORT_JAPANESE_UNICODE = 0x1,

		/// <summary>Japanese radical/stroke order</summary>
		SORT_JAPANESE_RADICALSTROKE = 0x4,

		/// <summary>Chinese BIG5 order</summary>
		SORT_CHINESE_BIG5 = 0x0,

		/// <summary>PRC Chinese Phonetic order</summary>
		SORT_CHINESE_PRCP = 0x0,

		/// <summary>Chinese Unicode order (no longer supported)</summary>
		SORT_CHINESE_UNICODE = 0x1,

		/// <summary>PRC Chinese Stroke Count order</summary>
		SORT_CHINESE_PRC = 0x2,

		/// <summary>Traditional Chinese Bopomofo order</summary>
		SORT_CHINESE_BOPOMOFO = 0x3,

		/// <summary>Traditional Chinese radical/stroke order.</summary>
		SORT_CHINESE_RADICALSTROKE = 0x4,

		/// <summary>Korean KSC order</summary>
		SORT_KOREAN_KSC = 0x0,

		/// <summary>Korean Unicode order (no longer supported)</summary>
		SORT_KOREAN_UNICODE = 0x1,

		/// <summary>German Phone Book order</summary>
		SORT_GERMAN_PHONE_BOOK = 0x1,

		/// <summary>Hungarian Default order</summary>
		SORT_HUNGARIAN_DEFAULT = 0x0,

		/// <summary>Hungarian Technical order</summary>
		SORT_HUNGARIAN_TECHNICAL = 0x1,

		/// <summary>Georgian Traditional order</summary>
		SORT_GEORGIAN_TRADITIONAL = 0x0,

		/// <summary>Georgian Modern order</summary>
		SORT_GEORGIAN_MODERN = 0x1,
	}

	internal uint _value;

	private const int langMask = 0x0FFFF;
	private const uint sortMask = 0xF0000;
	private const int sortShift = 16;

	/// <summary>Initializes a new instance of the <see cref="LCID"/> structure.</summary>
	/// <param name="rawValue">The raw LCID value.</param>
	public LCID(uint rawValue) => _value = rawValue;

	/// <summary>Initializes a new instance of the <see cref="LCID"/> structure.</summary>
	/// <param name="lgid">
	/// Language identifier. This parameter is a combination of a primary language identifier and a sublanguage identifier.
	/// </param>
	/// <param name="srtid">Sort order identifier.</param>
	public LCID(LANGID lgid, SORT srtid) => _value = (((uint)(ushort)srtid) << sortShift) | lgid;

	/// <summary>Retrieves a language identifier from a locale identifier.</summary>
	public LANGID LANGID => (LANGID)_value;

	/// <summary>Retrieves a sort order identifier from a locale identifier.</summary>
	public SORT SORTID => (SORT)(((_value) >> sortShift) & 0xf);

	/// <summary>Gets the value.</summary>
	/// <value>The value.</value>
	public uint Value { get => _value; private set => _value = value; }

	/// <summary>Compares the current object with another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>
	/// A value that indicates the relative order of the objects being compared. The return value has the following
	/// meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal
	/// to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
	/// </returns>
	public int CompareTo(LCID other) => _value.CompareTo(other._value);

	/// <summary>
	/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current
	/// instance precedes, follows, or occurs in the same position in the sort order as the other object.
	/// </summary>
	/// <param name="obj">An object to compare with this instance.</param>
	/// <returns>
	/// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less
	/// than zero This instance precedes <paramref name="obj"/> in the sort order. Zero This instance occurs in the same position in the
	/// sort order as <paramref name="obj"/> . Greater than zero This instance follows <paramref name="obj"/> in the sort order.
	/// </returns>
	public int CompareTo(object? obj) => obj is IConvertible c ? _value.CompareTo(c.ToUInt32(null)) :
		throw new ArgumentException(@"Object cannot be converted to a UInt32 value for comparison.", nameof(obj));

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override bool Equals(object? obj) => obj is IConvertible c && _value.Equals(c.ToUInt32(null));

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public bool Equals(LCID other) => other._value == _value;

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public bool Equals(uint other) => other == _value;

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override int GetHashCode() => _value.GetHashCode();

	/// <inheritdoc/>
	public TypeCode GetTypeCode() => Value.GetTypeCode();

	/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
	/// <returns>A <see cref="string"/> that represents this instance.</returns>
	public override string ToString() => ToString(CultureInfo.InvariantCulture);

	/// <inheritdoc/>
	public string ToString(IFormatProvider? provider) => string.Format(provider, "0x{0:X8}", _value);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="hrLeft">The first <see cref="LCID"/>.</param>
	/// <param name="hrRight">The second <see cref="LCID"/>.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(LCID hrLeft, LCID hrRight) => hrLeft._value == hrRight._value;

	/// <summary>Implements the operator ==.</summary>
	/// <param name="hrLeft">The first <see cref="LCID"/>.</param>
	/// <param name="hrRight">The second <see cref="uint"/>.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(LCID hrLeft, uint hrRight) => hrLeft._value == hrRight;

	/// <summary>Implements the operator !=.</summary>
	/// <param name="hrLeft">The first <see cref="LCID"/>.</param>
	/// <param name="hrRight">The second <see cref="LCID"/>.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(LCID hrLeft, LCID hrRight) => !(hrLeft == hrRight);

	/// <summary>Implements the operator !=.</summary>
	/// <param name="hrLeft">The first <see cref="LCID"/>.</param>
	/// <param name="hrRight">The second <see cref="uint"/>.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(LCID hrLeft, uint hrRight) => !(hrLeft == hrRight);

	/// <summary>Performs an implicit conversion from <see cref="int"/> to <see cref="LCID"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator LCID(uint value) => new(value);

	/// <summary>Performs an explicit conversion from <see cref="LCID"/> to <see cref="int"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator uint(LCID value) => value._value;

	/// <summary>The default locale for the operating system. The value of this constant is 0x0800.</summary>
	public static LCID LOCALE_SYSTEM_DEFAULT = new(LANGID.LANG_SYSTEM_DEFAULT, SORT.SORT_DEFAULT);

	/// <summary>The default locale for the user or process. The value of this constant is 0x0400.</summary>
	public static LCID LOCALE_USER_DEFAULT = new(LANGID.LANG_USER_DEFAULT, SORT.SORT_DEFAULT);

	/// <summary>
	/// Windows Vista and later: The default custom locale. When an NLS function must return a locale identifier for a supplemental
	/// locale for the current user, the function returns this value instead of LOCALE_USER_DEFAULT. The value of LOCALE_CUSTOM_DEFAULT
	/// is 0x0C00.
	/// </summary>
	public static LCID LOCALE_CUSTOM_DEFAULT => new(new LANGID(LANGID.LANG.LANG_NEUTRAL, LANGID.SUBLANG.SUBLANG_CUSTOM_DEFAULT), SORT.SORT_DEFAULT);

	/// <summary>
	/// Windows Vista and later: An unspecified custom locale, used to identify all supplemental locales except the locale for the
	/// current user. Supplemental locales cannot be distinguished from one another by their locale identifiers, but can be
	/// distinguished by their locale names. Certain NLS functions can return this constant to indicate that they cannot provide a
	/// useful identifier for a particular locale. The value of LOCALE_CUSTOM_UNSPECIFIED is 0x1000.
	/// </summary>
	public static LCID LOCALE_CUSTOM_UNSPECIFIED => new(new LANGID(LANGID.LANG.LANG_NEUTRAL, LANGID.SUBLANG.SUBLANG_CUSTOM_UNSPECIFIED), SORT.SORT_DEFAULT);

	/// <summary>
	/// Windows Vista and later: The default custom locale for MUI. The user preferred UI languages and the system preferred UI
	/// languages can include at most a single language that is implemented by a Language Interface Pack (LIP) and for which the
	/// language identifier corresponds to a supplemental locale. If there is such a language in a list, the constant is used to refer
	/// to that language in certain contexts. The value of LOCALE_CUSTOM_UI_DEFAULT is 0x1400.
	/// </summary>
	public static LCID LOCALE_CUSTOM_UI_DEFAULT => new(new LANGID(LANGID.LANG.LANG_NEUTRAL, LANGID.SUBLANG.SUBLANG_UI_CUSTOM_DEFAULT), SORT.SORT_DEFAULT);

	/// <summary>
	/// The neutral locale. This constant is generally not used when calling NLS APIs. Instead, use either LOCALE_SYSTEM_DEFAULT or
	/// LOCALE_USER_DEFAULT. The value of LOCALE_NEUTRAL is 0x0000.
	/// </summary>
	public static LCID LOCALE_NEUTRAL => new(new LANGID(LANGID.LANG.LANG_NEUTRAL, LANGID.SUBLANG.SUBLANG_NEUTRAL), SORT.SORT_DEFAULT);

	/// <summary>
	/// Windows XP: The locale used for operating system-level functions that require consistent and locale-independent results. For
	/// example, the invariant locale is used when an application compares character strings using the CompareString function and
	/// expects a consistent result regardless of the user locale. The settings of the invariant locale are similar to those for English
	/// (United States) but should not be used to display formatted data. Typically, an application does not use LOCALE_INVARIANT
	/// because it expects the results of an action to depend on the rules governing each individual locale. The value of
	/// LOCALE_INVARIANT IS 0x007f.
	/// </summary>
	public static LCID LOCALE_INVARIANT => new(new LANGID(LANGID.LANG.LANG_INVARIANT, LANGID.SUBLANG.SUBLANG_NEUTRAL), SORT.SORT_DEFAULT);

	/// <inheritdoc/>
	bool IConvertible.ToBoolean(IFormatProvider? provider) => ((IConvertible)Value).ToBoolean(provider);

	/// <inheritdoc/>
	byte IConvertible.ToByte(IFormatProvider? provider) => ((IConvertible)Value).ToByte(provider);

	/// <inheritdoc/>
	char IConvertible.ToChar(IFormatProvider? provider) => ((IConvertible)Value).ToChar(provider);

	/// <inheritdoc/>
	DateTime IConvertible.ToDateTime(IFormatProvider? provider) => ((IConvertible)Value).ToDateTime(provider);

	/// <inheritdoc/>
	decimal IConvertible.ToDecimal(IFormatProvider? provider) => ((IConvertible)Value).ToDecimal(provider);

	/// <inheritdoc/>
	double IConvertible.ToDouble(IFormatProvider? provider) => ((IConvertible)Value).ToDouble(provider);

	/// <inheritdoc/>
	short IConvertible.ToInt16(IFormatProvider? provider) => ((IConvertible)Value).ToInt16(provider);

	/// <inheritdoc/>
	int IConvertible.ToInt32(IFormatProvider? provider) => ((IConvertible)Value).ToInt32(provider);

	/// <inheritdoc/>
	long IConvertible.ToInt64(IFormatProvider? provider) => ((IConvertible)Value).ToInt64(provider);

	/// <inheritdoc/>
	sbyte IConvertible.ToSByte(IFormatProvider? provider) => ((IConvertible)Value).ToSByte(provider);

	/// <inheritdoc/>
	float IConvertible.ToSingle(IFormatProvider? provider) => ((IConvertible)Value).ToSingle(provider);

	/// <inheritdoc/>
	object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ((IConvertible)Value).ToBoolean(provider);

	/// <inheritdoc/>
	ushort IConvertible.ToUInt16(IFormatProvider? provider) => ((IConvertible)Value).ToUInt16(provider);

	/// <inheritdoc/>
	uint IConvertible.ToUInt32(IFormatProvider? provider) => ((IConvertible)Value).ToUInt32(provider);

	/// <inheritdoc/>
	ulong IConvertible.ToUInt64(IFormatProvider? provider) => ((IConvertible)Value).ToUInt64(provider);
}