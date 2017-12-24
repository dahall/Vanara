using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class UxTheme
	{
		/// <summary>Must be called on a window to use the UpdatePanningFeedback method for boundary feedback.</summary>
		/// <param name="hwnd">A handle to the window that will have boundary feedback on it.</param>
		/// <returns>Indicates whether the function was successful.</returns>
		[PInvokeData("UxTheme.h", MinClient = PInvokeClient.Windows7)]
		[DllImport(Lib.UxTheme, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool BeginPanningFeedback(HandleRef hwnd);

		/// <summary>Initializes the window position information for window panning.</summary>
		/// <param name="hwnd">A handle to the window to end boundary feedback on.</param>
		/// <param name="fAnimateBack">Indicates whether the window positioning reset should incorporate a smooth animation.</param>
		/// <returns>Indicates whether the function succeeded. Returns TRUE on success; otherwise, returns FALSE.</returns>
		[PInvokeData("UxTheme.h", MinClient = PInvokeClient.Windows7)]
		[DllImport(Lib.UxTheme, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EndPanningFeedback(HandleRef hwnd, [MarshalAs(UnmanagedType.Bool)] bool fAnimateBack);

		/// <summary>Triggers repositioning on a window's position when a user pans past a boundary.</summary>
		/// <param name="hwnd">A handle to the window that will have boundary feedback on it.</param>
		/// <param name="lTotalOverpanOffsetX">Indicates how far past the horizontal end of the pannable region the pan has gone.</param>
		/// <param name="lTotalOverpanOffsetY">Indicates how far past the vertical end of the pannable region the pan has gone.</param>
		/// <param name="fInInertia">A flag indicating whether the boundary feedback incorporates inertia.</param>
		/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</returns>
		[PInvokeData("UxTheme.h", MinClient = PInvokeClient.Windows7)]
		[DllImport(Lib.UxTheme, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UpdatePanningFeedback(HandleRef hwnd, int lTotalOverpanOffsetX, int lTotalOverpanOffsetY, [MarshalAs(UnmanagedType.Bool)] bool fInInertia);
	}
}