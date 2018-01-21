using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.User32_Gdi;

// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Global ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		[Flags]
		public enum TBSTATE : byte
		{
			/// <summary>The button has the TBSTYLE_CHECK style and is being clicked.</summary>
			TBSTATE_CHECKED = 0x01,
			/// <summary>Version 4.70. The button's text is cut off and an ellipsis is displayed.</summary>
			TBSTATE_ELLIPSES = 0x40,
			/// <summary>The button accepts user input. A button that does not have this state is grayed.</summary>
			TBSTATE_ENABLED = 0x04,
			/// <summary>The button is not visible and cannot receive user input.</summary>
			TBSTATE_HIDDEN = 0x08,
			/// <summary>The button is grayed.</summary>
			TBSTATE_INDETERMINATE = 0x10,
			/// <summary>Version 4.71. The button is marked. The interpretation of a marked item is dependent upon the application.</summary>
			TBSTATE_MARKED = 0x80,
			/// <summary>The button is being clicked.</summary>
			TBSTATE_PRESSED = 0x02,
			/// <summary>The button is followed by a line break. The button must also have the TBSTATE_ENABLED state.</summary>
			TBSTATE_WRAP = 0x20,
		}

		[Flags]
		public enum TBSTYLE : ushort
		{
			/// <summary>Allows users to change a toolbar button's position by dragging it while holding down the ALT key. If this style is not specified, the user must hold down the SHIFT key while dragging a button. Note that the CCS_ADJUSTABLE style must be specified to enable toolbar buttons to be dragged.</summary>
			TBSTYLE_ALTDRAG = 0x0400,
			/// <summary>Equivalent to BTNS_AUTOSIZE. Use TBSTYLE_AUTOSIZE for version 4.72 and earlier.</summary>
			TBSTYLE_AUTOSIZE = 0x0010,
			/// <summary>Equivalent to BTNS_BUTTON. Use TBSTYLE_BUTTON for version 4.72 and earlier.</summary>
			TBSTYLE_BUTTON = 0x0000,
			/// <summary>Equivalent to BTNS_CHECK. Use TBSTYLE_CHECK for version 4.72 and earlier.</summary>
			TBSTYLE_CHECK = 0x0002,
			/// <summary>Equivalent to BTNS_CHECKGROUP. Use TBSTYLE_CHECKGROUP for version 4.72 and earlier.</summary>
			TBSTYLE_CHECKGROUP = (TBSTYLE_GROUP | TBSTYLE_CHECK),
			/// <summary>Version 4.70. Generates NM_CUSTOMDRAW notification codes when the toolbar processes WM_ERASEBKGND messages.</summary>
			TBSTYLE_CUSTOMERASE = 0x2000,
			/// <summary>Equivalent to BTNS_DROPDOWN. Use TBSTYLE_DROPDOWN for version 4.72 and earlier.</summary>
			TBSTYLE_DROPDOWN = 0x0008,
			/// <summary>Version 4.70. Creates a flat toolbar. In a flat toolbar, both the toolbar and the buttons are transparent and hot-tracking is enabled. Button text appears under button bitmaps. To prevent repainting problems, this style should be set before the toolbar control becomes visible.</summary>
			TBSTYLE_FLAT = 0x0800,
			/// <summary>Equivalent to BTNS_GROUP. Use TBSTYLE_GROUP for version 4.72 and earlier.</summary>
			TBSTYLE_GROUP = 0x0004,
			/// <summary>Version 4.70. Creates a flat toolbar with button text to the right of the bitmap. Otherwise, this style is identical to TBSTYLE_FLAT. To prevent repainting problems, this style should be set before the toolbar control becomes visible.</summary>
			TBSTYLE_LIST = 0x1000,
			/// <summary>Equivalent to BTNS_NOPREFIX. Use TBSTYLE_NOPREFIX for version 4.72 and earlier.</summary>
			TBSTYLE_NOPREFIX = 0x0020,
			/// <summary>Version 4.71. Generates TBN_GETOBJECT notification codes to request drop target objects when the cursor passes over toolbar buttons.</summary>
			TBSTYLE_REGISTERDROP = 0x4000,
			/// <summary>Equivalent to BTNS_SEP. Use TBSTYLE_SEP for version 4.72 and earlier.</summary>
			TBSTYLE_SEP = 0x0001,
			/// <summary>Creates a tooltip control that an application can use to display descriptive text for the buttons in the toolbar.</summary>
			TBSTYLE_TOOLTIPS = 0x0100,
			/// <summary>Version 4.71. Creates a transparent toolbar. In a transparent toolbar, the toolbar is transparent but the buttons are not. Button text appears under button bitmaps. To prevent repainting problems, this style should be set before the toolbar control becomes visible.</summary>
			TBSTYLE_TRANSPARENT = 0x8000,
			/// <summary>Creates a toolbar that can have multiple lines of buttons. Toolbar buttons can "wrap" to the next line when the toolbar becomes too narrow to include all buttons on the same line. When the toolbar is wrapped, the break will occur on either the rightmost separator or the rightmost button if there are no separators on the bar. This style must be set to display a vertical toolbar control when the toolbar is part of a vertical rebar control. This style cannot be combined with CCS_VERT.</summary>
			TBSTYLE_WRAPABLE = 0x0200,
		}

		/// <summary>Contains information about a button in a toolbar.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TBBUTTON
		{
			/// <summary>Zero-based index of the button image. Set this member to I_IMAGECALLBACK, and the toolbar will send the TBN_GETDISPINFO notification code to retrieve the image index when it is needed.
			/// <para>Version 5.81. Set this member to I_IMAGENONE to indicate that the button does not have an image.The button layout will not include any space for a bitmap, only text.</para>
			/// <para>If the button is a separator, that is, if fsStyle is set to BTNS_SEP, iBitmap determines the width of the separator, in pixels.For information on selecting button images from image lists, see TB_SETIMAGELIST message.</para></summary>
			public int iBitmap;
			/// <summary>Command identifier associated with the button. This identifier is used in a WM_COMMAND message when the button is chosen.</summary>
			public int idCommand;
			// Funky holder to make preprocessor directives work
			private TBBUTTON_U union;
			/// <summary>Button state flags.</summary>
			public TBSTATE fsState { get => union.fsState; set => union.fsState = value; }
			/// <summary>Button style.</summary>
			public TBSTYLE fsStyle { get => union.fsStyle; set => union.fsStyle = value; }
			/// <summary>Application-defined value.</summary>
			public IntPtr dwData;
			/// <summary>Zero-based index of the button string, or a pointer to a string buffer that contains text for the button.</summary>
			public IntPtr iString;

			[StructLayout(LayoutKind.Explicit, Pack = 1)]
			private struct TBBUTTON_U
			{
				[FieldOffset(0)] private IntPtr bReserved;
				[FieldOffset(0)] public TBSTATE fsState;
				[FieldOffset(1)] public TBSTYLE fsStyle;
			}
		}
	}
}