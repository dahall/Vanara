namespace Vanara.InteropServices;

/// <summary>Marshals strings that are allocated by native code and must be freed using LocalFree after use.</summary>
/// <seealso cref="ICustomMarshaler"/>
public class LocalStringMarshaler : GenericStringMarshalerBase<LocalMemoryMethods>
{
	private LocalStringMarshaler(CharSet charSet) : base(charSet) { }

	/// <summary>Gets the instance.</summary>
	/// <param name="cookie">The cookie.</param>
	/// <returns>A new instance of this class.</returns>
	public static ICustomMarshaler GetInstance(string cookie) => new LocalStringMarshaler(CharSetFromString(cookie, CharSet.Unicode));
}