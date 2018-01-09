using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable UnusedMember.Global

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>A value that specifies the desired format of the string.</summary>
		[PInvokeData("Shtypes.h", MSDNShortId = "bb759820")]
		public enum STRRET_TYPE : uint
		{
			/// <summary>The string is at the address specified by pOleStr member.</summary>
			STRRET_WSTR = 0x0000,

			/// <summary>The uOffset member value indicates the number of bytes from the beginning of the item identifier list where the string is located.</summary>
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

		/// <summary>Defines an item identifier.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Shtypes.h", MSDNShortId = "bb759800")]
		public struct SHITEMID
		{
			/// <summary>The size of identifier, in bytes, including <see cref="cb" /> itself.</summary>
			public ushort cb;

			/// <summary>A variable-length item identifier.</summary>
			public byte[] abID;
		}

		/// <summary>Contains strings returned from the IShellFolder interface methods.</summary>
		[StructLayout(LayoutKind.Explicit, Size = 264)]
		[PInvokeData("Shtypes.h", MSDNShortId = "bb759820")]
		public struct STRRET
		{
			/// <summary>A value that specifies the desired format of the string.</summary>
			[FieldOffset(0)] public STRRET_TYPE uType;

			/// <summary>
			/// A pointer to the string. This memory must be allocated with CoTaskMemAlloc. It is the calling application's responsibility to free this memory
			/// with CoTaskMemFree when it is no longer needed.
			/// </summary>
			[FieldOffset(4), MarshalAs(UnmanagedType.BStr)]
			public StrPtrUni pOleStr; // must be freed by caller of GetDisplayNameOf

			/// <summary>The offset into the item identifier list.</summary>
			[FieldOffset(4)] public uint uOffset; // Offset into SHITEMID

			/// <summary>The buffer to receive the display name. CHAR[MAX_PATH]</summary>
			[FieldOffset(4), MarshalAs(UnmanagedType.LPStr, SizeConst = Kernel32.MAX_PATH)]
			public string cStr; // Buffer to fill in (ANSI)

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString() => uType == STRRET_TYPE.STRRET_CSTR
				? cStr
				: (uType == STRRET_TYPE.STRRET_WSTR ? pOleStr.ToString() : string.Empty);
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
				if (!(ManagedObj is string s)) throw new InvalidCastException();
				var sr = new STRRET {uType = STRRET_TYPE.STRRET_WSTR};
				sr.pOleStr.Assign(s);
				return sr.StructureToPtr(Marshal.AllocCoTaskMem, out int _);
			}

			public object MarshalNativeToManaged(IntPtr pNativeData)
			{
				if (pNativeData == IntPtr.Zero) return null;
				var sr = pNativeData.ToStructure<STRRET>();
				var s = sr.ToString().Clone() as string;
				if (sr.uType == STRRET_TYPE.STRRET_WSTR)
					sr.pOleStr.Free();
				return s;
			}
		}
	}
}
