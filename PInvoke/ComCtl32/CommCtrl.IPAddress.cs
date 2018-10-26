using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		/// <summary>
		/// Creates IP address controls. These controls are similar to an edit control, but they enable you to enter a numeric address in
		/// Internet protocol (IP) format.
		/// </summary>
		public const string WC_IPADDRESS = "SysIPAddress32";

		private const int IPN_FIRST = -860;

#pragma warning disable 1584, 1711, 1572, 1581, 1580

		/// <summary>IP Address Messages</summary>
		public enum IPAddressMessage
		{
			/// <summary>Clears the contents of the IP address control.</summary>
			/// <param name="wParam">Must be zero.</param>
			/// <param name="lParam">Must be zero.</param>
			/// <returns>The return value is not used.</returns>
			IPM_CLEARADDRESS = WindowMessage.WM_USER + 100,

			/// <summary>Sets the address values for all four fields in the IP address control.</summary>
			/// <param name="wParam">Must be zero.</param>
			/// <param name="lParam">
			/// A DWORD value that contains the new address. The field 3 value is contained in bits 0 through 7. The field 2 value is
			/// contained in bits 8 through 15. The field 1 value is contained in bits 16 through 23. The field 0 value is contained in bits
			/// 24 through 31. The MAKEIPADDRESS macro can also be used to create the address information.
			/// </param>
			/// <returns>The return value is not used.</returns>
			IPM_SETADDRESS = WindowMessage.WM_USER + 101,

			/// <summary>Gets the address values for all four fields in the IP address control.</summary>
			/// <param name="wParam">Must be zero.</param>
			/// <param name="lParam">
			/// A pointer to a DWORD value that receives the address. The field 3 value will be contained in bits 0 through 7. The field 2
			/// value will be contained in bits 8 through 15. The field 1 value will be contained in bits 16 through 23. The field 0 value
			/// will be contained in bits 24 through 31. The FIRST_IPADDRESS, SECOND_IPADDRESS, THIRD_IPADDRESS, and FOURTH_IPADDRESS macros
			/// can also be used to extract the address information. Zero will be returned as the address for any blank fields.
			/// </param>
			/// <returns>Returns the number of nonblank fields.</returns>
			IPM_GETADDRESS = WindowMessage.WM_USER + 102,

			/// <summary>ets the valid range for the specified field in the IP address control.</summary>
			/// <remarks>
			/// If the user enters a value in the field that is outside of this range, the control will send the IPN_FIELDCHANGED
			/// notification with the entered value. If the value is still outside of the range after sending the notification, the control
			/// will attempt to change the entered value to the closest range limit.
			/// </remarks>
			/// <param name="wParam">A zero-based field index to which the range will be applied.</param>
			/// <param name="lParam">
			/// A WORD value that contains the lower limit of the range in the low-order byte and the upper limit in the high-order byte.
			/// Both of these values are inclusive. The MAKEIPRANGE macro can also be used to create the range.
			/// </param>
			/// <returns>Returns nonzero if successful, or zero otherwise.</returns>
			IPM_SETRANGE = WindowMessage.WM_USER + 103,

			/// <summary>
			/// Sets the keyboard focus to the specified field in the IP address control. All of the text in that field will be selected.
			/// </summary>
			/// <param name="wParam">
			/// A zero-based field index to which the focus should be set. If this value is greater than the number of fields, focus is set
			/// to the first blank field. If all fields are nonblank, focus is set to the first field.
			/// </param>
			/// <param name="lParam">Must be zero.</param>
			/// <returns>The return value is not used.</returns>
			IPM_SETFOCUS = WindowMessage.WM_USER + 104,

			/// <summary>Determines if all fields in the IP address control are blank.</summary>
			/// <param name="wParam">Must be zero.</param>
			/// <param name="lParam">Must be zero.</param>
			/// <returns>Returns nonzero if all fields are blank, or zero otherwise.</returns>
			IPM_ISBLANK = WindowMessage.WM_USER + 105,
		}

		/// <summary>IP Address Notifications</summary>
		public enum IPAddressNotification
		{
			/// <summary>
			/// Sent when the user changes a field in the control or moves from one field to another. This notification code is sent in the
			/// form of a WM_NOTIFY message.
			/// </summary>
			/// <param name="lParam">
			/// A pointer to an NMIPADDRESS structure that contains information about the changed address. The iValue member of this
			/// structure will contain the entered value, even if it is out of the range of the field. You can modify this member to any
			/// value that is within the range for the field in response to this notification code.
			/// </param>
			/// <returns>The return value is ignored.</returns>
			IPN_FIELDCHANGED = IPN_FIRST - 0
		}

#pragma warning restore 1584, 1711, 1572, 1581, 1580

		/// <summary>Gets the IP address represented as a byte array from an unsigned pointer.</summary>
		/// <param name="ipAddress">The IP address.</param>
		/// <returns>The IP address represented as a byte array.</returns>
		public static byte[] GET_IPADDRESS(uint ipAddress) => new[] { (byte)((ipAddress >> 24) & 0xff), (byte)((ipAddress >> 16) & 0xff), (byte)((ipAddress >> 8) & 0xff), (byte)(ipAddress & 0xff) };

		/// <summary>Packs four byte-values into a single LPARAM suitable for use with the IPM_SETADDRESS message.</summary>
		/// <param name="b0">The field 0 address.</param>
		/// <param name="b1">The field 1 address.</param>
		/// <param name="b2">The field 2 address.</param>
		/// <param name="b3">The field 3 address.</param>
		/// <returns>Returns an LPARAM value that contains the address.</returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
		public static uint MAKEIPADDRESS(byte b0, byte b1, byte b2, byte b3) => (((uint)b0 << 24) | ((uint)b1 << 16) | ((uint)b2 << 8) | b3);

		/// <summary>Packs four byte-values into a single LPARAM suitable for use with the IPM_SETADDRESS message.</summary>
		/// <param name="bytes">The bytes ordered 0-3.</param>
		/// <returns>Returns an LPARAM value that contains the address.</returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761385")]
		public static uint MAKEIPADDRESS(byte[] bytes)
		{
			if (bytes != null && bytes.Length != 4)
				throw new ArgumentOutOfRangeException(nameof(bytes), "Array must contain exactly four items.");
			return bytes == null ? 0 : MAKEIPADDRESS(bytes[0], bytes[1], bytes[2], bytes[3]);
		}

		/// <summary>Packs two byte-values into a single LPARAM suitable for use with the IPM_SETRANGE message.</summary>
		/// <param name="low">The lower limit of the range.</param>
		/// <param name="high">The upper limit of the range.</param>
		/// <returns>Returns an LPARAM value that contains the range.</returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761386")]
		public static uint MAKEIPRANGE(byte low, byte high) => (uint)((high << 8) + low);

		/// <summary>Contains information for the IPN_FIELDCHANGED notification code.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761375")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMIPADDRESS
		{
			/// <summary>An NMHDR structure that contains additional information about the notification.</summary>
			public NMHDR hdr;

			/// <summary>The zero-based number of the field that was changed.</summary>
			public int iField;

			/// <summary>
			/// The new value of the field specified in the iField member. While processing the IPN_FIELDCHANGED notification, this member
			/// can be set to any value that is within the range of the field and the control will place this new value in the field.
			/// </summary>
			public int iValue;
		}
	}
}