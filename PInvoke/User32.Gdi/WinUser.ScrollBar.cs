namespace Vanara.PInvoke
{
	public static partial class User32_Gdi
	{
		/// <summary>Flags used to enable or disable scroll bars.</summary>
		[PInvokeData("winuser.h")]
		public enum ESB_FLAGS : uint
		{
			/// <summary>Disables both direction buttons on the specified scroll bar.</summary>
			ESB_DISABLE_BOTH = 0x0003,

			/// <summary>Disables the down direction button on the vertical scroll bar.</summary>
			ESB_DISABLE_DOWN = 0x0002,

			/// <summary>Disables the left direction button on the horizontal scroll bar.</summary>
			ESB_DISABLE_LEFT = 0x0001,

			/// <summary>
			/// Disables the left direction button on the horizontal scroll bar or the up direction button on the vertical scroll bar.
			/// </summary>
			ESB_DISABLE_LTUP = ESB_DISABLE_LEFT,

			/// <summary>Disables the right direction button on the horizontal scroll bar.</summary>
			ESB_DISABLE_RIGHT = 0x0002,

			/// <summary>
			/// Disables the right direction button on the horizontal scroll bar or the down direction button on the vertical scroll bar.
			/// </summary>
			ESB_DISABLE_RTDN = ESB_DISABLE_RIGHT,

			/// <summary>Disables the up direction button on the vertical scroll bar.</summary>
			ESB_DISABLE_UP = 0x0001,

			/// <summary>Enables both direction buttons on the specified scroll bar.</summary>
			ESB_ENABLE_BOTH = 0x0000,
		}

		/// <summary>Specifies the scroll bar type.</summary>
		[PInvokeData("winuser.h")]
		public enum SB
		{
			/// <summary>The horizontal and vertical scroll bars.</summary>
			SB_BOTH = 3,

			/// <summary>The horizontal scroll bar.</summary>
			SB_HORZ = 0,

			/// <summary>The vertical scroll bar.</summary>
			SB_VERT = 1,

			/// <summary>The scroll bar control.</summary>
			SB_CTL = 2,
		}
	}
}