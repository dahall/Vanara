using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		/// <summary>
		/// Contains information about a balloon tip associated with a button control.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775466")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EDITBALLOONTIP
		{
			/// <summary>
			/// A DWORD that contains the size, in bytes, of the structure.
			/// </summary>
			public int cbStruct;
			/// <summary>
			/// A pointer to a Unicode string that contains the title of the balloon tip.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pszTitle;
			/// <summary>
			/// A pointer to a Unicode string that contains the balloon tip text.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pszText;
			/// <summary>
			/// A value of type INT that specifies the type of icon to associate with the balloon tip.
			/// </summary>
			public ToolTipIcon ttiIcon;

			/// <summary>
			/// Initializes a new instance of the <see cref="EDITBALLOONTIP"/> struct.
			/// </summary>
			/// <param name="title">The title.</param>
			/// <param name="text">The text.</param>
			/// <param name="icon">The icon.</param>
			public EDITBALLOONTIP(string title, string text, ToolTipIcon icon = ToolTipIcon.TTI_NONE)
			{
				cbStruct = Marshal.SizeOf(typeof(EDITBALLOONTIP));
				pszText = text;
				pszTitle = title;
				ttiIcon = icon;
			}
		}
	}
}