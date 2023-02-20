using System;

namespace Vanara.PInvoke;

/// <summary>The state of the other mouse buttons plus the SHIFT and CTRL keys.</summary>
[PInvokeData("winuser.h")]
[Flags]
public enum MouseButtonState
{
	/// <summary>The left mouse button is down.</summary>
	MK_LBUTTON = 0x0001,

	/// <summary>The right mouse button is down.</summary>
	MK_RBUTTON = 0x0002,

	/// <summary>The SHIFT key is down.</summary>
	MK_SHIFT = 0x0004,

	/// <summary>The CTRL key is down.</summary>
	MK_CONTROL = 0x0008,

	/// <summary>The middle mouse button is down.</summary>
	MK_MBUTTON = 0x0010,

	/// <summary>The XBUTTON1 button is down.</summary>
	MK_XBUTTON1 = 0x0020,

	/// <summary>The XBUTTON2 button is down.</summary>
	MK_XBUTTON2 = 0x0040,
}