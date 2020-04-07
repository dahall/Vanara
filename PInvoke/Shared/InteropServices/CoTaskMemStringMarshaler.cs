using System.Runtime.InteropServices;

namespace Vanara.InteropServices
{
	/// <summary>Marshals strings that are allocated by native code and must be freed using CoTaskMemFree after use.</summary>
	/// <seealso cref="System.Runtime.InteropServices.ICustomMarshaler"/>
	public class CoTaskMemStringMarshaler : GenericStringMarshalerBase<CoTaskMemoryMethods>
	{
		private CoTaskMemStringMarshaler(CharSet charSet) : base(charSet) { }

		/// <summary>Gets the instance.</summary>
		/// <param name="cookie">The cookie.</param>
		/// <returns>A new instance of this class.</returns>
		public static ICustomMarshaler GetInstance(string cookie) => new CoTaskMemStringMarshaler(CharSetFromString(cookie, CharSet.Unicode));
	}
}