using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	/// <summary>
	/// CLIPFORMAT is a 2-byte value representing a clipboard format.
	/// <para>
	/// This cannot be used as a drop-in replacement for many of the winuser.h function as they expect a 4-byte value. However, this can
	/// automatically convert between the 4-byte values and the 2-byte value.
	/// </para>
	/// </summary>
	/// <seealso cref="System.IComparable"/>
	/// <seealso cref="System.IComparable{CLIPFORMAT}"/>
	/// <seealso cref="System.IEquatable{CLIPFORMAT}"/>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("wtypes.h", MSDNShortId = "fe42baec-6b00-4816-b379-7f335da8a197")]
	public partial struct CLIPFORMAT : IComparable, IComparable<CLIPFORMAT>, IEquatable<CLIPFORMAT>
	{
		internal readonly ushort _value;

		/// <summary>Initializes a new instance of the <see cref="CLIPFORMAT"/> structure.</summary>
		/// <param name="rawValue">The raw clipboard format value.</param>
		public CLIPFORMAT(ushort rawValue) => _value = rawValue;

		/// <summary>Compares the current object with another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following
		/// meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal
		/// to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
		/// </returns>
		public int CompareTo(CLIPFORMAT other) => _value.CompareTo(other._value);

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
		public int CompareTo(object obj)
		{
			if (obj is not IConvertible c) throw new ArgumentException(@"Object cannot be converted to a UInt16 value for comparison.", nameof(obj));
			return _value.CompareTo(c.ToUInt16(null));
		}

		/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) => obj is IConvertible c && _value.Equals(c.ToUInt16(null));

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(CLIPFORMAT other) => other._value == _value;

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => _value.GetHashCode();

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString()
		{
			var type = GetType();
			foreach (var fi in type.GetFields(BindingFlags.Static | BindingFlags.Public).Where(f => f.FieldType == type && f.IsInitOnly))
				if (fi.GetValue(null) is CLIPFORMAT cf && cf._value == _value)
					return $"{fi.Name} ({HexStr(this)})";
			return HexStr(this);

			static string HexStr(in CLIPFORMAT cf) => string.Format(CultureInfo.InvariantCulture, "0x{0:X4}", cf._value);
		}

		/// <summary>Implements the operator ==.</summary>
		/// <param name="hrLeft">The first <see cref="CLIPFORMAT"/>.</param>
		/// <param name="hrRight">The second <see cref="CLIPFORMAT"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(CLIPFORMAT hrLeft, CLIPFORMAT hrRight) => hrLeft._value == hrRight._value;

		/// <summary>Implements the operator ==.</summary>
		/// <param name="hrLeft">The first <see cref="CLIPFORMAT"/>.</param>
		/// <param name="hrRight">The second <see cref="ushort"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(CLIPFORMAT hrLeft, ushort hrRight) => hrLeft._value == hrRight;

		/// <summary>Implements the operator !=.</summary>
		/// <param name="hrLeft">The first <see cref="CLIPFORMAT"/>.</param>
		/// <param name="hrRight">The second <see cref="CLIPFORMAT"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(CLIPFORMAT hrLeft, CLIPFORMAT hrRight) => !(hrLeft == hrRight);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="hrLeft">The first <see cref="CLIPFORMAT"/>.</param>
		/// <param name="hrRight">The second <see cref="ushort"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(CLIPFORMAT hrLeft, ushort hrRight) => !(hrLeft == hrRight);

		/// <summary>Performs an implicit conversion from <see cref="ushort"/> to <see cref="CLIPFORMAT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator CLIPFORMAT(ushort value) => new(value);

		/// <summary>Performs an implicit conversion from <see cref="short"/> to <see cref="CLIPFORMAT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator CLIPFORMAT(short value) => new(unchecked((ushort)value));

		/// <summary>Performs an implicit conversion from <see cref="uint"/> to <see cref="CLIPFORMAT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator CLIPFORMAT(uint value) => new((ushort)value);

		/// <summary>Performs an implicit conversion from <see cref="uint"/> to <see cref="CLIPFORMAT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator CLIPFORMAT(int value) => new((ushort)value);

		/// <summary>Performs an explicit conversion from <see cref="CLIPFORMAT"/> to <see cref="System.UInt16"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ushort(CLIPFORMAT value) => value._value;

		/// <summary>Performs an explicit conversion from <see cref="CLIPFORMAT"/> to <see cref="System.Int16"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator short(CLIPFORMAT value) => unchecked((short)value._value);

		/// <summary>Performs an explicit conversion from <see cref="CLIPFORMAT"/> to <see cref="System.UInt32"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator uint(CLIPFORMAT value) => value._value;

		/// <summary>Performs an explicit conversion from <see cref="CLIPFORMAT"/> to <see cref="System.Int32"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator int(CLIPFORMAT value) => value._value;

		/// <summary>A handle to a bitmap (HBITMAP).</summary>
		[ClipCorrespondingType(typeof(HBITMAP))]
		public static readonly CLIPFORMAT CF_BITMAP = 2;

		/// <summary>A memory object containing a BITMAPINFO structure followed by the bitmap bits.</summary>
		public static readonly CLIPFORMAT CF_DIB = 8;

		/// <summary>
		/// A memory object containing a BITMAPV5HEADER structure followed by the bitmap color space information and the bitmap bits.
		/// </summary>
		public static readonly CLIPFORMAT CF_DIBV5 = 17;

		/// <summary>Software Arts' Data Interchange Format.</summary>
		public static readonly CLIPFORMAT CF_DIF = 5;

		/// <summary>
		/// Bitmap display format associated with a private format. The hMem parameter must be a handle to data that can be displayed in
		/// bitmap format in lieu of the privately formatted data.
		/// </summary>
		public static readonly CLIPFORMAT CF_DSPBITMAP = 0x0082;

		/// <summary>
		/// Enhanced metafile display format associated with a private format. The hMem parameter must be a handle to data that can be
		/// displayed in enhanced metafile format in lieu of the privately formatted data.
		/// </summary>
		public static readonly CLIPFORMAT CF_DSPENHMETAFILE = 0x008E;

		/// <summary>
		/// Metafile-picture display format associated with a private format. The hMem parameter must be a handle to data that can be
		/// displayed in metafile-picture format in lieu of the privately formatted data.
		/// </summary>
		public static readonly CLIPFORMAT CF_DSPMETAFILEPICT = 0x0083;

		/// <summary>
		/// Text display format associated with a private format. The hMem parameter must be a handle to data that can be displayed in text
		/// format in lieu of the privately formatted data.
		/// </summary>
		public static readonly CLIPFORMAT CF_DSPTEXT = 0x0081;

		/// <summary>A handle to an enhanced metafile (HENHMETAFILE).</summary>
		[ClipCorrespondingType(typeof(HENHMETAFILE), TYMED.TYMED_ENHMF)]
		public static readonly CLIPFORMAT CF_ENHMETAFILE = 14;

		/// <summary>
		/// Start of a range of integer values for application-defined GDI object clipboard formats. The end of the range is CF_GDIOBJLAST.
		/// <para>
		/// Handles associated with clipboard formats in this range are not automatically deleted using the GlobalFree function when the
		/// clipboard is emptied. Also, when using values in this range, the hMem parameter is not a handle to a GDI object, but is a handle
		/// allocated by the GlobalAlloc function with the GMEM_MOVEABLE flag.
		/// </para>
		/// </summary>
		[ClipCorrespondingType(typeof(int))]
		public static readonly CLIPFORMAT CF_GDIOBJFIRST = 0x0300;

		/// <summary>See CF_GDIOBJFIRST.</summary>
		[ClipCorrespondingType(typeof(int))]
		public static readonly CLIPFORMAT CF_GDIOBJLAST = 0x03FF;

		/// <summary>
		/// A handle to type HDROP that identifies a list of files. An application can retrieve information about the files by passing the
		/// handle to the DragQueryFile function.
		/// </summary>
		public static readonly CLIPFORMAT CF_HDROP = 15;

		/// <summary>
		/// The data is a handle to the locale identifier associated with text in the clipboard. When you close the clipboard, if it contains
		/// CF_TEXT data but no CF_LOCALE data, the system automatically sets the CF_LOCALE format to the current input language. You can use
		/// the CF_LOCALE format to associate a different locale with the clipboard text.
		/// <para>
		/// An application that pastes text from the clipboard can retrieve this format to determine which character set was used to generate
		/// the text.
		/// </para>
		/// <para>
		/// Note that the clipboard does not support plain text in multiple character sets. To achieve this, use a formatted text data type
		/// such as RTF instead.
		/// </para>
		/// <para>
		/// The system uses the code page associated with CF_LOCALE to implicitly convert from CF_TEXT to CF_UNICODETEXT. Therefore, the
		/// correct code page table is used for the conversion.
		/// </para>
		/// </summary>
		[ClipCorrespondingType(typeof(LCID))]
		public static readonly CLIPFORMAT CF_LOCALE = 16;

		/// <summary>
		/// Handle to a metafile picture format as defined by the METAFILEPICT structure. When passing a CF_METAFILEPICT handle by means of
		/// DDE, the application responsible for deleting hMem should also free the metafile referred to by the CF_METAFILEPICT handle.
		/// </summary>
		[ClipCorrespondingType(typeof(HMETAFILE), TYMED.TYMED_MFPICT)]
		public static readonly CLIPFORMAT CF_METAFILEPICT = 3;

		/// <summary>
		/// Text format containing characters in the OEM character set. Each line ends with a carriage return/linefeed (CR-LF) combination. A
		/// null character signals the end of the data.
		/// </summary>
		[ClipCorrespondingType(typeof(string), TYMED.TYMED_HGLOBAL, EncodingType = typeof(System.Text.ASCIIEncoding))]
		public static readonly CLIPFORMAT CF_OEMTEXT = 7;

		/// <summary>
		/// Owner-display format. The clipboard owner must display and update the clipboard viewer window, and receive the
		/// WM_ASKCBFORMATNAME, WM_HSCROLLCLIPBOARD, WM_PAINTCLIPBOARD, WM_SIZECLIPBOARD, and WM_VSCROLLCLIPBOARD messages. The hMem
		/// parameter must be NULL.
		/// </summary>
		[ClipCorrespondingType(null, TYMED.TYMED_NULL)]
		public static readonly CLIPFORMAT CF_OWNERDISPLAY = 0x0080;

		/// <summary>
		/// Handle to a color palette. Whenever an application places data in the clipboard that depends on or assumes a color palette, it
		/// should place the palette on the clipboard as well.
		/// <para>
		/// If the clipboard contains data in the CF_PALETTE (logical color palette) format, the application should use the SelectPalette and
		/// RealizePalette functions to realize (compare) any other data in the clipboard against that logical palette.
		/// </para>
		/// <para>
		/// When displaying clipboard data, the clipboard always uses as its current palette any object on the clipboard that is in the
		/// CF_PALETTE format.
		/// </para>
		/// </summary>
		public static readonly CLIPFORMAT CF_PALETTE = 9;

		/// <summary>Data for the pen extensions to the Microsoft Windows for Pen Computing.</summary>
		public static readonly CLIPFORMAT CF_PENDATA = 10;

		/// <summary>
		/// Start of a range of integer values for private clipboard formats. The range ends with CF_PRIVATELAST. Handles associated with
		/// private clipboard formats are not freed automatically; the clipboard owner must free such handles, typically in response to the
		/// WM_DESTROYCLIPBOARD message.
		/// </summary>
		[ClipCorrespondingType(typeof(int))]
		public static readonly CLIPFORMAT CF_PRIVATEFIRST = 0x0200;

		/// <summary>See CF_PRIVATEFIRST.</summary>
		[ClipCorrespondingType(typeof(int))]
		public static readonly CLIPFORMAT CF_PRIVATELAST = 0x02FF;

		/// <summary>Represents audio data more complex than can be represented in a CF_WAVE standard wave format.</summary>
		public static readonly CLIPFORMAT CF_RIFF = 11;

		/// <summary>Microsoft Symbolic Link (SYLK) format.</summary>
		public static readonly CLIPFORMAT CF_SYLK = 4;

		/// <summary>
		/// Text format. Each line ends with a carriage return/linefeed (CR-LF) combination. A null character signals the end of the data.
		/// Use this format for ANSI text.
		/// </summary>
		[ClipCorrespondingType(typeof(string), TYMED.TYMED_HGLOBAL, EncodingType = typeof(System.Text.ASCIIEncoding))]
		public static readonly CLIPFORMAT CF_TEXT = 1;

		/// <summary>Tagged-image file format.</summary>
		public static readonly CLIPFORMAT CF_TIFF = 6;

		/// <summary>
		/// Unicode text format. Each line ends with a carriage return/linefeed (CR-LF) combination. A null character signals the end of the data.
		/// </summary>
		[ClipCorrespondingType(typeof(string), TYMED.TYMED_HGLOBAL, EncodingType = typeof(System.Text.UnicodeEncoding))]
		public static readonly CLIPFORMAT CF_UNICODETEXT = 13;

		/// <summary>Represents audio data in one of the standard wave formats, such as 11 kHz or 22 kHz PCM.</summary>
		public static readonly CLIPFORMAT CF_WAVE = 12;
	}

	/// <summary>Indicates the type, medium and method for getting and setting the payload associated with known clipboard formats.</summary>
	/// <seealso cref="Vanara.InteropServices.CorrespondingTypeAttribute"/>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
	public class ClipCorrespondingTypeAttribute : Vanara.InteropServices.CorrespondingTypeAttribute
	{
		/// <summary>Initializes a new instance of the <see cref="ClipCorrespondingTypeAttribute"/> class.</summary>
		/// <param name="typeRef">The type that corresponds to this entity.</param>
		/// <param name="medium">The medium type used to store the payload.</param>
		public ClipCorrespondingTypeAttribute(Type typeRef, TYMED medium = TYMED.TYMED_HGLOBAL) : base(typeRef)
		{
			Medium = medium;
		}

		/// <summary>Gets the medium type used to store the payload.</summary>
		/// <value>The medium type.</value>
		public TYMED Medium { get; }

		/// <summary>
		/// Gets or sets the formatter type used to place the contents of the object of <see
		/// cref="InteropServices.CorrespondingTypeAttribute.TypeRef"/>. If not specified, it can be assumed the type will be directly marshaled.
		/// </summary>
		/// <value>The optional formatter type.</value>
		public Type Formatter { get; set; }
	}

	/// <summary>A formatter used to get and set objects on the clipboard. When implemented, use the <see cref="ClipCorrespondingTypeAttribute.Formatter"/> property to 
	/// associate a clipboard format </summary>
	public interface IClipboardFormatter
	{
		/// <summary>Extracts the object from an HGLOBAL handle.</summary>
		/// <param name="hGlobal">The HGLOBAL handle.</param>
		/// <returns>The extracted object.</returns>
		public object Read(IntPtr hGlobal);

		/// <summary>Inserts the specified object into an allocated HGLOBAL handle.</summary>
		/// <param name="value">The object value.</param>
		/// <returns>
		/// A pointer to allocated memory holding the content. This should be created using GlobalAlloc with the GMEM_MOVEABLE flag.
		/// </returns>
		public IntPtr Write(object value);
	}
}