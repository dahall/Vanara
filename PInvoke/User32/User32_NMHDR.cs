using System;
using System.Runtime.InteropServices;
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>
		/// Contains information about a notification message.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct NMHDR
		{
			/// <summary>A window handle to the control sending the message.</summary>
			public IntPtr hwndFrom;
			/// <summary>An identifier of the control sending the message.</summary>
			public IntPtr idFrom;
			/// <summary>A notification code. This member can be one of the common notification codes (see Notifications under General Control Reference), or it can be a control-specific notification code.</summary>
			public int code;
		}
	}
}