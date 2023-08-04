using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>Contains structures, enumerations and functions from COMCTL32.DLL.</summary>
public static partial class ComCtl32
{
	/// <summary>Used in the <see cref="BUTTON_IMAGELIST"/> structure himl member to indicate that no glyph should be displayed.</summary>
	public static IntPtr BCCL_NOGLYPH = new(-1);

	/// <summary>Used by the <see cref="BUTTON_IMAGELIST.uAlign"/> member to specify alignment.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775953")]
	public enum ButtonImageListAlign
	{
		/// <summary>Align the image with the left margin.</summary>
		BUTTON_IMAGELIST_ALIGN_LEFT = 0,

		/// <summary>Align the image with the right margin.</summary>
		BUTTON_IMAGELIST_ALIGN_RIGHT = 1,

		/// <summary>Align the image with the top margin.</summary>
		BUTTON_IMAGELIST_ALIGN_TOP = 2,

		/// <summary>Align the image with the bottom margin.</summary>
		BUTTON_IMAGELIST_ALIGN_BOTTOM = 3,

		/// <summary>Center the image.</summary>
		BUTTON_IMAGELIST_ALIGN_CENTER = 4  // Doesn't draw text
	}

	/// <summary>
	/// A set of flags that specify which members of <see cref="BUTTON_SPLITINFO"/> contain data to be set or which members are being requested.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775955")]
	[Flags]
	public enum SplitButtonInfoMask
	{
		/// <summary>himlGlyph is valid.</summary>
		BCSIF_GLYPH = 0x1,

		/// <summary>himlGlyph is valid. Use when uSplitStyle is set to BCSS_IMAGE.</summary>
		BCSIF_IMAGE = 0x2,

		/// <summary>uSplitStyle is valid.</summary>
		BCSIF_STYLE = 0x4,

		/// <summary>size is valid.</summary>
		BCSIF_SIZE = 0x8
	}

	/// <summary>The split button style for the uSplitStyle member of <see cref="BUTTON_SPLITINFO"/>.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775955")]
	[Flags]
	public enum SplitButtonInfoStyle
	{
		/// <summary>No split.</summary>
		BCSS_NOSPLIT = 0x1,

		/// <summary>Stretch glyph, but try to retain aspect ratio.</summary>
		BCSS_STRETCH = 0x2,

		/// <summary>Align the image or glyph horizontally with the left margin.</summary>
		BCSS_ALIGNLEFT = 0x4,

		/// <summary>Draw an icon image as the glyph.</summary>
		BCSS_IMAGE = 0x8
	}

	/// <summary>Contains information about an image list that is used with a button control.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775953")]
	[StructLayout(LayoutKind.Sequential)]
	public struct BUTTON_IMAGELIST
	{
		/// <summary>
		/// A handle to the image list. The provider retains ownership of the image list and is ultimately responsible for its disposal.
		/// Under Windows Vista, you can pass BCCL_NOGLYPH in this parameter to indicate that no glyph should be displayed.
		/// </summary>
		public HIMAGELIST himl;

		/// <summary>A RECT that specifies the margin around the icon.</summary>
		public RECT margin;

		/// <summary>A UINT that specifies the alignment to use.</summary>
		public ButtonImageListAlign uAlign;
	}

	/// <summary>
	/// Contains information that defines a split button (BS_SPLITBUTTON and BS_DEFSPLITBUTTON styles). Used with the BCM_GETSPLITINFO
	/// and BCM_SETSPLITINFO messages.
	/// </summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775955")]
	[StructLayout(LayoutKind.Sequential)]
	public struct BUTTON_SPLITINFO
	{
		/// <summary>
		/// A set of flags that specify which members of this structure contain data to be set or which members are being requested.
		/// </summary>
		public SplitButtonInfoMask mask;

		/// <summary>
		/// A handle to the image list. The provider retains ownership of the image list and is ultimately responsible for its disposal.
		/// </summary>
		public HIMAGELIST himlGlyph;

		/// <summary>The split button style.</summary>
		public SplitButtonInfoStyle uSplitButtonInfoStyle;

		/// <summary>A SIZE structure that specifies the size of the glyph in himlGlyph.</summary>
		public SIZE size;

		/// <summary>Initializes a new instance of the <see cref="BUTTON_SPLITINFO"/> struct and sets the uSplitStyle value.</summary>
		/// <param name="buttonInfoStyle">The style.</param>
		public BUTTON_SPLITINFO(SplitButtonInfoStyle buttonInfoStyle) : this() { uSplitButtonInfoStyle = buttonInfoStyle; mask = SplitButtonInfoMask.BCSIF_STYLE; }

		/// <summary>Initializes a new instance of the <see cref="BUTTON_SPLITINFO"/> struct and sets an ImageList</summary>
		/// <param name="hImageList">The h image list.</param>
		public BUTTON_SPLITINFO(HIMAGELIST hImageList) : this() { himlGlyph = hImageList; mask = SplitButtonInfoMask.BCSIF_IMAGE; }
	}

	/// <summary>Contains information about a BCN_DROPDOWN notification.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775957")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMBCDROPDOWN : INotificationInfo
	{
		/// <summary>An NMHDR structure containing information about the notification.</summary>
		public NMHDR hdr;

		/// <summary>A RECT structure that contains the client area of the button.</summary>
		public RECT rcButton;
	}

	/// <summary>Contains information about the movement of the mouse over a button control.</summary>
	[PInvokeData("Commctrl.h", MSDNShortId = "bb775959")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NMBCHOTITEM : INotificationInfo
	{
		/// <summary>An NMHDR structure.</summary>
		public NMHDR hdr;

		/// <summary>The action of the mouse. This parameter can be one of the following values combined with HICF_MOUSE.</summary>
		public HotItemChangeFlags dwFlags;
	}
}