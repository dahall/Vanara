namespace Vanara.PInvoke;

public static partial class UxTheme
{
	/// <summary>Must be called on a window to use the <c>UpdatePanningFeedback</c> method for boundary feedback.</summary>
	/// <param name="hwnd">A handle to the window that will have boundary feedback on it.</param>
	/// <returns>Indicates whether the function was successful.</returns>
	// BOOL WINAPI BeginPanningFeedback(_In_ HWND hwnd); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317331(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "dd317331", MinClient = PInvokeClient.Windows7)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool BeginPanningFeedback(HWND hwnd);

	/// <summary>Initializes the window position information for window panning.</summary>
	/// <param name="hwnd">A handle to the window to end boundary feedback on.</param>
	/// <param name="fAnimateBack">Indicates whether the window positioning reset should incorporate a smooth animation.</param>
	/// <returns>Indicates whether the function succeeded. Returns <c>TRUE</c> on success; otherwise, returns <c>FALSE</c>.</returns>
	// BOOL WINAPI EndPanningFeedback( _In_ HWND hwnd, BOOL fAnimateBack); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317327(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "dd317327", MinClient = PInvokeClient.Windows7)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EndPanningFeedback(HWND hwnd, [MarshalAs(UnmanagedType.Bool)] bool fAnimateBack);

	/// <summary>Triggers repositioning on a window's position when a user pans past a boundary.</summary>
	/// <param name="hwnd">A handle to the window that will have boundary feedback on it.</param>
	/// <param name="lTotalOverpanOffsetX">Indicates how far past the horizontal end of the pannable region the pan has gone.</param>
	/// <param name="lTotalOverpanOffsetY">Indicates how far past the vertical end of the pannable region the pan has gone.</param>
	/// <param name="fInInertia">A flag indicating whether the boundary feedback incorporates inertia.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</para>
	/// </returns>
	// BOOL WINAPI UpdatePanningFeedback( _In_ HWND hwnd, _In_ LONG lTotalOverpanOffsetX, _In_ LONG lTotalOverpanOffsetY, _In_ BOOL
	// fInInertia); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317336(v=vs.85).aspx
	[DllImport(Lib.UxTheme, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Uxtheme.h", MSDNShortId = "dd317336", MinClient = PInvokeClient.Windows7)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UpdatePanningFeedback(HWND hwnd, int lTotalOverpanOffsetX, int lTotalOverpanOffsetY, [MarshalAs(UnmanagedType.Bool)] bool fInInertia);
}