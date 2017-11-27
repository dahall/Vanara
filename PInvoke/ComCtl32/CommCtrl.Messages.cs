// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		public const int CCM_FIRST = 0x2000;

		public enum CommonControlMessage
		{
			CCM_SETBKCOLOR        = CCM_FIRST + 1, // lParam is bkColor
			CCM_SETCOLORSCHEME    = CCM_FIRST + 2, // lParam is color scheme
			CCM_GETCOLORSCHEME    = CCM_FIRST + 3, // fills in COLORSCHEME pointed to by lParam
			CCM_GETDROPTARGET     = CCM_FIRST + 4,
			CCM_SETUNICODEFORMAT  = CCM_FIRST + 5,
			CCM_GETUNICODEFORMAT  = CCM_FIRST + 6,
			CCM_SETVERSION        = CCM_FIRST + 0x7,
			CCM_GETVERSION        = CCM_FIRST + 0x8,
			CCM_SETNOTIFYWINDOW   = CCM_FIRST + 0x9, // wParam == hwndParent.
			CCM_SETWINDOWTHEME    = CCM_FIRST + 0xb,
			CCM_DPISCALE          = CCM_FIRST + 0xc, // wParam == Awareness
		}
	}
}