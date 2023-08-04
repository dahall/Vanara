namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// <para>
	/// Exposes methods that set notification information and then display that notification to the user in a balloon that appears in
	/// conjunction with the notification area of the taskbar.
	/// </para>
	/// <para>
	/// <c>Note</c> IUserNotification2 differs from <c>IUserNotification</c> only in its Show method, which adds an additional parameter
	/// for a callback interface to communicate with the notification. Otherwise the two interfaces are identical in form and function.
	/// CLSID_UserNotification implements both versions of <c>Show</c> as an overload.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>When to Implement</para>
	/// <para>An implementation of this interface is provided in Windows as CLSID_UserNotification.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iusernotification
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IUserNotification")]
	[ComImport, Guid("ba9711ba-5893-4787-a7e1-41277151550b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IUserNotification
	{
		/// <summary>Sets the information to be displayed in a balloon notification.</summary>
		/// <param name="pszTitle">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a Unicode string that specifies the title of the notification.</para>
		/// </param>
		/// <param name="pszText">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a Unicode string that specifies the text to be displayed in the body of the balloon.</para>
		/// </param>
		/// <param name="dwInfoFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>One or more of the following values that indicate an icon to display in the notification balloon.</para>
		/// <para>NIIF_NONE (0x00000000)</para>
		/// <para>0x00000000. Do not display an icon.</para>
		/// <para>NIIF_INFO (0x00000001)</para>
		/// <para>0x00000001. Display an information icon.</para>
		/// <para>NIIF_WARNING (0x00000002)</para>
		/// <para>0x00000002. Display a warning icon.</para>
		/// <para>NIIF_ERROR (0x00000003)</para>
		/// <para>0x00000003. Display an error icon.</para>
		/// <para>NIIF_USER (0x00000004)</para>
		/// <para>0x00000004. <c>Windows XP SP2 and later</c>. Use the icon identified in <c>hIcon</c> in the notification balloon.</para>
		/// <para>NIIF_NOSOUND (0x00000010)</para>
		/// <para>
		/// 0x00000010. <c>Windows XP and later</c>. Do not play the associated sound. This value applies only to balloon notifications
		/// and not to standard user notifications.
		/// </para>
		/// <para>NIIF_LARGE_ICON (0x00000010)</para>
		/// <para>
		/// 0x00000010. <c>Windows Vista and later</c>. The large version of the icon should be used as the icon in the notification
		/// balloon. This corresponds to the icon with dimensions SM_CXICON x SM_CYICON. If this flag is not set, the icon with
		/// dimensions XM_CXSMICON x SM_CYSMICON is used.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>This flag can be used with all stock icons.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Applications that use older customized icons (NIIF_USER with <c>hIcon</c>) must provide a new SM_CXICON x SM_CYICON version
		/// in the tray icon specified in the <c>hIcon</c> member of the NOTIFYICONDATA structure. These icons are scaled down when they
		/// are displayed in the notification area.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// New customized icons (NIIF_USER with <c>hBalloonIcon</c>) must supply an SM_CXICON x SM_CYICON version in the supplied icon
		/// ( <c>hBalloonIcon</c>).
		/// </term>
		/// </item>
		/// </list>
		/// <para>NIIF_RESPECT_QUIET_TIME (0x00000080)</para>
		/// <para>
		/// 0x00000080. <c>Windows 7 and later</c>. Do not display the notification balloon if the current user is in "quiet time",
		/// which is the first hour after a new user logs into his or her account for the first time. During this time, most
		/// notifications should not be sent or shown. This lets a user become accustomed to a new computer system without those
		/// distractions. Quiet time also occurs for each user after an operating system upgrade or clean installation. A notification
		/// sent with this flag during quiet time is not queued; it is simply dismissed unshown. The application can resend the
		/// notification later if it is still valid at that time.
		/// </para>
		/// <para>
		/// Because an application cannot predict when it might encounter quiet time, we recommended that this flag always be set on all
		/// appropriate notifications by any application that means to honor quiet time.
		/// </para>
		/// <para>If the current user is not in quiet time, this flag has no effect.</para>
		/// <para>NIIF_ICON_MASK (0x0000000F)</para>
		/// <para>0x0000000F. <c>Windows XP</c> (Shell32.dll version 6.0 <c>) and later</c>. Reserved.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iusernotification-setballooninfo HRESULT
		// SetBalloonInfo( LPCWSTR pszTitle, LPCWSTR pszText, DWORD dwInfoFlags );
		void SetBalloonInfo([MarshalAs(UnmanagedType.LPWStr)] string pszTitle, [MarshalAs(UnmanagedType.LPWStr)] string pszText, NIIF dwInfoFlags);

		/// <summary>Specifies the conditions for trying to display user information when the first attempt fails.</summary>
		/// <param name="dwShowTime">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The amount of time, in milliseconds, to display the user information.</para>
		/// </param>
		/// <param name="dwInterval">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The interval of time, in milliseconds, between attempts to display the user information.</para>
		/// </param>
		/// <param name="cRetryCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of times the system should try to display the user information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iusernotification-setballoonretry HRESULT
		// SetBalloonRetry( DWORD dwShowTime, DWORD dwInterval, UINT cRetryCount );
		void SetBalloonRetry(uint dwShowTime, uint dwInterval, uint cRetryCount);

		/// <summary>Sets the notification area icon associated with specific user information.</summary>
		/// <param name="hIcon">
		/// <para>Type: <c>HICON</c></para>
		/// <para>A handle to the icon.</para>
		/// </param>
		/// <param name="pszToolTip">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>
		/// A pointer to a string that contains the tooltip text to display for the specified icon. This value can be <c>NULL</c>,
		/// although it is not recommended.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iusernotification-seticoninfo HRESULT
		// SetIconInfo( HICON hIcon, LPCWSTR pszToolTip );
		void SetIconInfo(HICON hIcon, [MarshalAs(UnmanagedType.LPWStr)] string? pszToolTip);

		/// <summary>Displays the notification.</summary>
		/// <param name="pqc">
		/// <para>Type: <c>IQueryContinue*</c></para>
		/// <para>
		/// An IQueryContinue interface pointer, used to determine whether the notification display can continue or should stop (for
		/// example, if the user closes the notification). This value can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwContinuePollInterval">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The length of time, in milliseconds, to display user information.</para>
		/// </param>
		/// <remarks>This method is equivalent to calling Show with pSink= <c>NULL</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iusernotification-show HRESULT Show(
		// IQueryContinue *pqc, DWORD dwContinuePollInterval );
		void Show(IQueryContinue? pqc, uint dwContinuePollInterval);

		/// <summary>Plays a sound in conjunction with the notification.</summary>
		/// <param name="pszSoundName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated Unicode string that specifies the alias of the sound file to play.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The string pointed to by pszSoundNamepqc contains an alias for a system event found in the registry or the Win.ini file; for
		/// instance, "SystemExit".
		/// </para>
		/// <para>
		/// The specified sound is played asynchronously and the method returns immediately after beginning the sound. To stop an
		/// asynchronous waveform sound, call <c>IUserNotification::PlaySound</c> with pszSoundNamepqc set to <c>NULL</c>.
		/// </para>
		/// <para>
		/// The specified sound event will yield to another sound event that is already playing. If a sound cannot be played because the
		/// resource needed to play that sound is busy, the method immediately returns S_FALSE without playing the requested sound.
		/// </para>
		/// <para>If the specified sound cannot be found, <c>IUserNotification::PlaySound</c> uses the system default sound.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iusernotification-playsound HRESULT
		// PlaySound( LPCWSTR pszSoundName );
		void PlaySound([MarshalAs(UnmanagedType.LPWStr)] string? pszSoundName);
	}
}