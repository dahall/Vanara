using static Vanara.PInvoke.ComCtl32;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Describes how a property should be treated.</summary>
	[PInvokeData("Shtypes.h")]
	[Flags]
	public enum SHCOLSTATE
	{
		/// <summary>The value is displayed according to default settings for the column.</summary>
		SHCOLSTATE_DEFAULT = 0x00000000,

		/// <summary>The value is displayed as a string.</summary>
		SHCOLSTATE_TYPE_STR = 0x00000001,

		/// <summary>The value is displayed as an integer.</summary>
		SHCOLSTATE_TYPE_INT = 0x00000002,

		/// <summary>The value is displayed as a date/time.</summary>
		SHCOLSTATE_TYPE_DATE = 0x00000003,

		/// <summary>A mask for display type values SHCOLSTATE_TYPE_STR, SHCOLSTATE_TYPE_STR, and SHCOLSTATE_TYPE_DATE.</summary>
		SHCOLSTATE_TYPEMASK = 0x0000000f,

		/// <summary>The column should be on by default in Details view.</summary>
		SHCOLSTATE_ONBYDEFAULT = 0x00000010,

		/// <summary>Will be slow to compute. Perform on a background thread.</summary>
		SHCOLSTATE_SLOW = 0x00000020,

		/// <summary>Provided by a handler, not the folder.</summary>
		SHCOLSTATE_EXTENDED = 0x00000040,

		/// <summary>Not displayed in the context menu, but is listed in the More... dialog.</summary>
		SHCOLSTATE_SECONDARYUI = 0x00000080,

		/// <summary>Not displayed in the UI.</summary>
		SHCOLSTATE_HIDDEN = 0x00000100,

		/// <summary>VarCmp produces same result as IShellFolder::CompareIDs.</summary>
		SHCOLSTATE_PREFER_VARCMP = 0x00000200,

		/// <summary>PSFormatForDisplay produces same result as IShellFolder::CompareIDs.</summary>
		SHCOLSTATE_PREFER_FMTCMP = 0x00000400,

		/// <summary>Do not sort folders separately.</summary>
		SHCOLSTATE_NOSORTBYFOLDERNESS = 0x00000800,

		/// <summary>Only displayed in the UI.</summary>
		SHCOLSTATE_VIEWONLY = 0x00010000,

		/// <summary>Marks columns with values that should be read in a batch.</summary>
		SHCOLSTATE_BATCHREAD = 0x00020000,

		/// <summary>Grouping is disabled for this column.</summary>
		SHCOLSTATE_NO_GROUPBY = 0x00040000,

		/// <summary>Can't resize the column.</summary>
		SHCOLSTATE_FIXED_WIDTH = 0x00001000,

		/// <summary>The width is the same in all dpi.</summary>
		SHCOLSTATE_NODPISCALE = 0x00002000,

		/// <summary>Fixed width and height ratio.</summary>
		SHCOLSTATE_FIXED_RATIO = 0x00004000,

		/// <summary>Filters out new display flags.</summary>
		SHCOLSTATE_DISPLAYMASK = 0x0000F000,
	}

	/// <summary>A value that specifies the desired format of the string.</summary>
	[PInvokeData("Shtypes.h", MSDNShortId = "bb759820")]
	public enum STRRET_TYPE : uint
	{
		/// <summary>The string is at the address specified by pOleStr member.</summary>
		STRRET_WSTR = 0x0000,

		/// <summary>
		/// The uOffset member value indicates the number of bytes from the beginning of the item identifier list where the string is located.
		/// </summary>
		STRRET_OFFSET = 0x0001,

		/// <summary>The string is returned in the cStr member.</summary>
		STRRET_CSTR = 0x0002,
	}

	/// <summary>Contains a list of item identifiers.</summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("Shtypes.h", MSDNShortId = "bb773321")]
	public struct ITEMIDLIST
	{
		/// <summary>A list of item identifiers.</summary>
		public SHITEMID mkid;
	}

	/// <summary>Reports detailed information on an item in a Shell folder.</summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("Shtypes.h", MSDNShortId = "bb759781")]
	public struct SHELLDETAILS
	{
		/// <summary>The alignment of the column heading and the subitem text in the column.</summary>
		public ListViewColumnFormat fmt;

		/// <summary>he number of average-sized characters in the header.</summary>
		public int cxChar;

		/// <summary>
		/// An STRRET structure that includes a string with the requested information. To convert this structure to a string, use
		/// StrRetToBuf or StrRetToStr.
		/// </summary>
		public STRRET str;
	}

	/// <summary>Defines an item identifier.</summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("Shtypes.h", MSDNShortId = "bb759800")]
	public struct SHITEMID
	{
		/// <summary>The size of identifier, in bytes, including <see cref="cb"/> itself.</summary>
		public ushort cb;

		/// <summary>A variable-length item identifier.</summary>
		public byte[] abID;
	}

	/// <summary>Contains strings returned from the IShellFolder interface methods.</summary>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("Shtypes.h", MSDNShortId = "bb759820")]
	public struct STRRET
	{
		const int strlenbuf = 260;

		/// <summary>A value that specifies the desired format of the string.</summary>
		public STRRET_TYPE uType;

		private DUMMYUNIONNAME union;

		/// <summary>
		/// A pointer to the string. This memory must be allocated with CoTaskMemAlloc. It is the calling application's responsibility to
		/// free this memory with CoTaskMemFree when it is no longer needed.
		/// </summary>
		public StrPtrUni pOleStr => union.pOleStr; // must be freed by caller of GetDisplayNameOf

		/// <summary>The offset into the item identifier list.</summary>
		public uint uOffset => union.uOffset; // Offset into SHITEMID

		/// <summary>The buffer to receive the display name. CHAR[MAX_PATH]</summary>
		public string? cStr => uType == STRRET_TYPE.STRRET_CSTR ? union.cStr : null;

		/// <summary>Initializes a new instance of the <see cref="STRRET"/> struct.</summary>
		/// <param name="lpstr">The initial string.</param>
		public STRRET(string? lpstr)
		{
			uType = STRRET_TYPE.STRRET_WSTR;
			union.pOleStr = Marshal.StringToCoTaskMemUni(lpstr);
		}

		/// <summary>Initializes a new instance of the <see cref="STRRET" /> struct.</summary>
		/// <param name="offset">The offset into the item identifier list.</param>
		public STRRET(uint offset)
		{
			uType = STRRET_TYPE.STRRET_OFFSET;
			union.uOffset = offset;
		}

		[StructLayout(LayoutKind.Explicit, Size = strlenbuf)]
		private struct DUMMYUNIONNAME
		{
			[FieldOffset(0)]
			public StrPtrUni pOleStr;
			[FieldOffset(0)]
			public uint uOffset;
			[FieldOffset(0)]
			public StrPtrAnsi cStr;
		}

		/// <summary>Performs an implicit conversion from <see cref="STRRET"/> to <see cref="System.String"/>.</summary>
		/// <param name="s">The <see cref="STRRET"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator string?(in STRRET s) => s.uType switch
		{
			STRRET_TYPE.STRRET_OFFSET => ShlwApi.StrRetToBSTR(new PinnedObject(s), default, out var ret).Succeeded ? ret : null,
			STRRET_TYPE.STRRET_WSTR => s.pOleStr.ToString(),
			STRRET_TYPE.STRRET_CSTR => s.cStr,
			_ => throw new ArgumentException("Invalid STRRET type", nameof(s)),
		};

		/// <summary>Frees any memory associated with this instance.</summary>
		public void Free() { if (uType == STRRET_TYPE.STRRET_WSTR) { Marshal.FreeCoTaskMem((IntPtr)union.pOleStr); union.pOleStr = IntPtr.Zero; } }

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => (string?)this ?? "";
	}

	internal class STRRETMarshaler : ICustomMarshaler
	{
		public static ICustomMarshaler GetInstance(string cookie) => new STRRETMarshaler();

		public void CleanUpManagedData(object ManagedObj)
		{
		}

		public void CleanUpNativeData(IntPtr pNativeData)
		{
			if (pNativeData == IntPtr.Zero) return;
			pNativeData.ToStructure<STRRET>().pOleStr.Free();
			Marshal.FreeCoTaskMem(pNativeData);
		}

		public int GetNativeDataSize() => Marshal.SizeOf(typeof(STRRET));

		public IntPtr MarshalManagedToNative(object ManagedObj)
		{
			if (ManagedObj is not string s) throw new InvalidCastException();
			var sr = new STRRET(s);
			return sr.MarshalToPtr(Marshal.AllocCoTaskMem, out var _);
		}

		public object MarshalNativeToManaged(IntPtr pNativeData) =>
			pNativeData != IntPtr.Zero && ShlwApi.StrRetToBSTR(pNativeData, default, out var ret).Succeeded ? ret : string.Empty;
	}
}