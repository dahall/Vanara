namespace Vanara.PInvoke;

/// <summary>
/// Represents a four-character code (FOURCC) used to identify data formats, such as video or audio codecs, in multimedia file formats or
/// font metric tables.
/// </summary>
/// <param name="value">The 32-bit unsigned integer value representing the four-character code.</param>
[StructLayout(LayoutKind.Sequential)]
public readonly struct FOURCC(uint value)
{
	private readonly uint value = value;

	/// <summary>Initializes a new instance of the FOURCC structure from a four-character string code.</summary>
	/// <param name="value">A string containing exactly four characters to be used as the FOURCC code.</param>
	/// <exception cref="ArgumentException">Thrown if the value parameter is not exactly four characters long.</exception>
	public FOURCC(string value) : this(value.Length == 4 ? Make(value[0], value[1], value[2], value[3]) : throw new ArgumentException("FOURCC string must be 4 characters long.", nameof(value))) { }

	/// <summary>Initializes a new instance of the FOURCC structure using four character codes.</summary>
	/// <remarks>
	/// FOURCC codes are commonly used to identify data formats in multimedia files. Each character typically represents one byte of the code.
	/// </remarks>
	/// <param name="ch0">The first character of the four-character code.</param>
	/// <param name="ch1">The second character of the four-character code.</param>
	/// <param name="ch2">The third character of the four-character code.</param>
	/// <param name="ch3">The fourth character of the four-character code.</param>
	public FOURCC(char ch0, char ch1, char ch2, char ch3) : this(Make(ch0, ch1, ch2, ch3)) { }

	/// <summary>Performs an implicit conversion from <see cref="FOURCC"/> to <see cref="uint"/>.</summary>
	public static implicit operator uint(FOURCC fourCC) => fourCC.value;

	/// <summary>Performs an implicit conversion from <see cref="uint"/> to <see cref="FOURCC"/>.</summary>
	public static implicit operator FOURCC(uint value) => new(value);

	/// <summary>Performs an implicit conversion from <see cref="string"/> to <see cref="FOURCC"/>.</summary>
	public static implicit operator FOURCC(string value) => new(value);

	/// <inheritdoc/>
	public override string ToString() => string.Concat((char)(value & 0xFF), (char)((value >> 8) & 0xFF), (char)((value >> 16) & 0xFF), (char)((value >> 24) & 0xFF));

	private static uint Make(char ch0, char ch1, char ch2, char ch3) => (uint)(ch0 | (ch1 << 8) | (ch2 << 16) | (ch3 << 24));
}