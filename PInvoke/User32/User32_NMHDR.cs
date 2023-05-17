using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>
	/// Interface to indicate that a structure provides information about a notification and contains a <see cref="NMHDR"/> structure as its
	/// first member.
	/// </summary>
	public interface INotificationInfo
	{
	}

	/// <summary>Contains information about a notification message.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-nmhdr
	// typedef struct tagNMHDR { HWND hwndFrom; UINT_PTR idFrom; UINT code; } NMHDR;
	[PInvokeData("winuser.h", MSDNShortId = "NS:winuser.tagNMHDR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMHDR
	{
		/// <summary>A window handle to the control sending the message.</summary>
		public HWND hwndFrom;

		/// <summary>An identifier of the control sending the message.</summary>
		public IntPtr idFrom;

		/// <summary>
		/// A notification code. This member can be one of the common notification codes (see Notifications under General Control
		/// Reference), or it can be a control-specific notification code.
		/// </summary>
		public int code;

		/// <summary>Creates a <see cref="NMHDR"/> structure from an LPARAM value.</summary>
		/// <param name="lParam">The LPARAM value.</param>
		/// <returns>A <see cref="NMHDR"/> structure.</returns>
		public static NMHDR FromLParam(IntPtr lParam) => lParam.ToStructure<NMHDR>();

#if ALLOWSPAN
		/// <summary>Creates a reference to an <see cref="NMHDR"/> structure from an LPARAM value.</summary>
		/// <param name="lParam">The LPARAM value.</param>
		/// <returns>A <see cref="NMHDR"/> structure reference.</returns>
		public static ref NMHDR LParamAsRef(IntPtr lParam) => ref lParam.AsRef<NMHDR>();
#endif

		/// <summary>Updates the <see cref="NMHDR"/> value pointed to by an LPARAM value from this instance.</summary>
		/// <param name="lParam">The LPARAM value to update.</param>
		public void UpdateLParam(IntPtr lParam) => Marshal.StructureToPtr(this, lParam, false);
	}
}