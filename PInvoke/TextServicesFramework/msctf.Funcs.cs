namespace Vanara.PInvoke;

/// <summary>Methods, constants, structures and interfaces for Microsoft Text Services Framework.</summary>
public static partial class MSCTF
{
	/// <summary>CLSID_SapiLayr</summary>
	public static readonly Guid CLSID_SapiLayr = new(0xdcbd6fa8, 0x032f, 0x11d3, 0xb5, 0xb1, 0x00, 0xc0, 0x4f, 0xc3, 0x24, 0xa1);

	private const string Lib_Msctf = "msctf.dll";
	private const string Lib_msimtf = "msimtf.dll";

	/// <summary>Flags for DoMsCtfMonitor()</summary>
	[PInvokeData("msctfmonitorapi.h", MSDNShortId = "NF:msctfmonitorapi.InitLocalMsCtfMonitor")]
	[Flags]
	public enum DCM_FLAGS : uint
	{
		/// <summary>Undocumented.</summary>
		DCM_FLAGS_TASKENG = 0x00000001,

		/// <summary>Undocumented.</summary>
		DCM_FLAGS_CTFMON = 0x00000002,

		/// <summary>Undocumented.</summary>
		DCM_FLAGS_LOCALTHREADTSF = 0x00000004,
	}

	/// <summary>Flags for InitLocalMsCtfMonitor()</summary>
	[PInvokeData("msctfmonitorapi.h", MSDNShortId = "NF:msctfmonitorapi.InitLocalMsCtfMonitor")]
	[Flags]
	public enum ILMCM : uint
	{
		/// <term>
		/// InitLocalMsCtfMonitor forcefully checks the available keyboard layout or text service. If there is no secondary keyboard
		/// layout or text services, it does not initialize TextServicesFramework on the desktop.
		/// </term>
		ILMCM_CHECKLAYOUTANDTIPENABLED = 0x00001,

		/// <term>Starting with Windows 8: A local language bar is not started for the current desktop.</term>
		ILMCM_LANGUAGEBAROFF = 0x00002
	}

	/// <summary>Bitfield options for <c>InstallLayoutOrTip</c>.</summary>
	[PInvokeData("")]
	[Flags]
	public enum ILOT
	{
		/// <summary>Same as ILOT_DISABLED.</summary>
		ILOT_UNINSTALL = 0x00000001,

		/// <summary>Sets the specified layout or tip as a default item.</summary>
		ILOT_DEFPROFILE = 0x00000002,

		/// <summary>Changes the setting of .Default.</summary>
		ILOT_DEFUSER4 = 0x00000004,

		/// <summary>Unused.</summary>
		ILOT_SYSLOCALE = 0x00000008,

		/// <summary>Unused.</summary>
		ILOT_NOLOCALETOENUMERATE = 0x00000010,

		/// <summary>The setting is saved but is not applied to the current session.</summary>
		ILOT_NOAPPLYTOCURRENTSESSION = 0x00000020,

		/// <summary>Disables all of the current keyboard layouts and text services.</summary>
		ILOT_CLEANINSTALL = 0x00000040,

		/// <summary>Disables the specified keyboard layout and text service.</summary>
		ILOT_DISABLED = 0x00000080,
	}

	/// <summary>Flags for <see cref="LAYOUTORTIP"/></summary>
	public enum LOT
	{
		/// <summary>If this is on, this is a default item.</summary>
		LOT_DEFAULT = 0x0001,

		/// <summary>if this is on, this is not enabled.</summary>
		LOT_DISABLED = 0x0002,
	}

	/// <summary>Flags for <see cref="LAYOUTORTIPPROFILE"/></summary>
	public enum LOTP
	{
		/// <summary/>
		LOTP_INPUTPROCESSOR = 1,

		/// <summary/>
		LOTP_KEYBOARDLAYOUT = 2
	}

	/// <summary>Flags for <c>SetDefaultLayoutOrTip()</c>.</summary>
	[PInvokeData("")]
	[Flags]
	public enum SDLOT : uint
	{
		/// <summary>
		/// Stores the setting in the registry but dose not update the runtime keyboard setting of the current session. If the
		/// alternative registry path is set in SetDefaultLayoutOrTipUserReg, this flag should be set.
		/// </summary>
		SDLOT_NOAPPLYTOCURRENTSESSION = 0x00000001,

		/// <summary>Applies the setting immediately on the current thread.</summary>
		SDLOT_APPLYTOCURRENTTHREAD = 0x00000002,
	}

	/// <summary>Undocumented.</summary>
	/// <param name="dwFlags"/>
	/// <param name="hEventForServiceStop"/>
	/// <returns/>
	[PInvokeData("msctfmonitorapi.h", MSDNShortId = "NF:msctfmonitorapi.InitLocalMsCtfMonitor")]
	[DllImport(Lib_Msctf, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DoMsCtfMonitor(DCM_FLAGS dwFlags, HEVENT hEventForServiceStop);

	/// <summary>Enumerates all enabled keyboard layouts or text services of the specified user setting.</summary>
	/// <param name="pszUserReg">The registry path of the user. If this parameter is <c>NULL</c>, HKEY_CURRENT_USER is used.</param>
	/// <param name="pszSystemReg">
	/// The registry path of the system. If this parameter is <c>NULL</c>, HKEY_LOCAL_MACHINE\System is used.
	/// </param>
	/// <param name="pszSoftwareReg">
	/// The registry path of the software. If this parameter is <c>NULL</c>, HKEY_LOCAL_MACHINE\Software is used.
	/// </param>
	/// <param name="pLayoutOrTipProfile">Pointer to the buffer that receives the LAYOUTORTIPPROFILE array.</param>
	/// <param name="uBufLength">The length of the buffer pointed to by pLayoutOrTipProfile.</param>
	/// <returns>
	/// <para>
	/// If pLayoutOrTipProfile is <c>NULL</c>, the number of keyboard items that are enabled in the user setting; otherwise, the number
	/// of keyboard items that are copied into pLayoutOrTipProfile.
	/// </para>
	/// <para>
	/// For Input Method Editor (IME) languages, all IMEs are returned, even when only one IME is enabled. For example, if a user has
	/// the CHT New Quick IME enabled, the <c>EnumEnabledLayoutOrTip</c> function returns all 5 CHT IMEs.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/enumenabledlayoutortip UINT EnumEnabledLayoutOrTip( _In_opt_ LPCWSTR
	// pszUserReg, _In_opt_ LPCWSTR pszSystemReg, _In_opt_ LPCWSTR pszSoftwareReg, _Out_ LAYOUTORTIPPROFILE *pLayoutOrTipProfile, _In_
	// UINT uBufLength );
	[DllImport(Lib_input, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("")]
	public static extern uint EnumEnabledLayoutOrTip([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszUserReg,
		[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszSystemReg,
		[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszSoftwareReg, out LAYOUTORTIPPROFILE pLayoutOrTipProfile,
		uint uBufLength);

	/// <summary>Enumerates the installed keyboard layouts and text services of the setup UI or OOBE.</summary>
	/// <param name="langid">The language id of the item to be enumerated.</param>
	/// <param name="pLayoutOrTip">
	/// Pointer to the buffer that receives the array of LAYOUTORTIP structures. This can be <c>NULL</c> to get the number of items.
	/// </param>
	/// <param name="uBufLength">The length of the buffer pointed to by pLayoutOrTip. This is ignored if pLayoutOrTip is <c>NULL</c>.</param>
	/// <param name="dwFlags">Not used. This must be zero.</param>
	/// <returns>
	/// If pLayoutOrTip is <c>NULL</c>, the number of keyboard items that are registered in System; otherwise, the number of keyboard
	/// items that are copied into pLayoutOrTip.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/enumlayoutortipforsetup UINT CALLBACK EnumLayoutOrTipForSetup( _In_ LANGID
	// langid, _Out_ LAYOUTORTIP *pLayoutOrTip, _In_ UINT uBufLength, _In_ DWORD dwFlags );
	[DllImport(Lib_input, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("")]
	public static extern uint EnumLayoutOrTipForSetup([In] LANGID langid, out LAYOUTORTIP pLayoutOrTip, uint uBufLength, uint dwFlags = 0);

	/// <summary>
	/// The <c>InitLocalMsCtfMonitor</c> function initializes TextServicesFramework on the current desktop and prepares the floating
	/// language bar, if necessary. This function must be called on the app's desktop.
	/// </summary>
	/// <param name="dwFlags">
	/// <para>This is a combination of the following flags:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ILMCM_CHECKLAYOUTANDTIPENABLED</term>
	/// <term>
	/// InitLocalMsCtfMonitor forcefully checks the available keyboard layout or text service. If there is no secondary keyboard layout
	/// or text services, it does not initialize TextServicesFramework on the desktop.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ILMCM_LANGUAGEBAROFF</term>
	/// <term>Starting with Windows 8: A local language bar is not started for the current desktop.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// If this function was successful, UninitLocalMsCtfMonitor needs to be called before the caller thread is terminated or the
	/// desktop is switched.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctfmonitorapi/nf-msctfmonitorapi-initlocalmsctfmonitor HRESULT
	// InitLocalMsCtfMonitor( DWORD dwFlags );
	[DllImport(Lib_Msctf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msctfmonitorapi.h", MSDNShortId = "NF:msctfmonitorapi.InitLocalMsCtfMonitor")]
	public static extern HRESULT InitLocalMsCtfMonitor(ILMCM dwFlags);

	/// <summary>Enables the specified keyboard layouts or text services.</summary>
	/// <param name="psz">A string that represents the keyboard layout list or text services profile list.</param>
	/// <param name="dwFlags">
	/// <para>A bitfield.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The string format of the layout list is:</para>
	/// <para>&lt;LangID 1&gt;:&lt;KLID 1&gt;;[...:</para>
	/// <para>The string format of the text service profile list is:</para>
	/// <para>&lt;LangID 1&gt;:{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx};</para>
	/// <para>The following is an example of a value for the psz parameter:</para>
	/// <para>
	/// <code>"0x0407:0x00000407" "0x0407:0x00000407;0x040C:0x0000040C" "0x0407:0x00000407;0x0412:{A028AE76-01B1-46C2-99C4-ACD9858AE02F}{B5FE1F02-D5F2-4445-9C03-C568F23C99A1};0x040C:0x0000040C"</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/installlayoutortip BOOL CALLBACK InstallLayoutOrTip( _In_ LPCWSTR psz, _In_
	// DWORD dwFlags );
	[DllImport(Lib_input, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InstallLayoutOrTip([In, MarshalAs(UnmanagedType.LPWStr)] string psz, [In] ILOT dwFlags);

	/// <summary>Enables the specified keyboard layouts or text services for the specified user.</summary>
	/// <param name="pszUserReg">The registry path of the user. If this parameter is <c>NULL</c>, HKEY_CURRENT_USER is used.</param>
	/// <param name="pszSystemReg">
	/// The registry path of the system. If this parameter is <c>NULL</c>, HKEY_LOCAL_MACHINE\System is used.
	/// </param>
	/// <param name="pszSoftwareReg">
	/// The registry path of the software. If this parameter is <c>NULL</c>, HKEY_LOCAL_MACHINE\Software is used.
	/// </param>
	/// <param name="psz">A string that represents the keyboard layout list or text services profile list.</param>
	/// <param name="dwFlags">
	/// <para>A bitfield that specifies the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ILOT_UNINSTALL 0x00000001</term>
	/// <term>Same as ILOT_DISABLED.</term>
	/// </item>
	/// <item>
	/// <term>ILOT_DEFPROFILE 0x00000002</term>
	/// <term>Sets the specified layout or tip as a default item.</term>
	/// </item>
	/// <item>
	/// <term>ILOT_NOAPPLYTOCURRENTSESSION 0x00000020</term>
	/// <term>The setting is saved but is not applied to the current session.</term>
	/// </item>
	/// <item>
	/// <term>ILOT_CLEANINSTALL 0x00000040</term>
	/// <term>Disables all of the current keyboard layouts and text services.</term>
	/// </item>
	/// <item>
	/// <term>ILOT_DISABLED 0x00000080</term>
	/// <term>Disables the specified keyboard layout and text service.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>FASE</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The string format of the layout list is:</para>
	/// <para>&lt;LangID 1&gt;:&lt;KLID 1&gt;;[...:</para>
	/// <para>The string format of the text service profile list is:</para>
	/// <para>&lt;LangID 1&gt;:{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx};</para>
	/// <para>The following is an example of a value for the psz parameter:</para>
	/// <para>
	/// <code>"0x0407:0x00000407" "0x0407:0x00000407;0x040C:0x0000040C" "0x0407:0x00000407;0x0412:{A028AE76-01B1-46C2-99C4-ACD9858AE02F}{B5FE1F02-D5F2-4445-9C03-C568F23C99A1};0x040C:0x0000040C"</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/installlayoutortipuserreg BOOL CALLBACK InstallLayoutOrTipUserReg( _In_opt_
	// LPCWSTR pszUserReg, _In_opt_ LPCWSTR pszSystemReg, _In_opt_ LPCWSTR pszSoftwareReg, _In_ LPCWSTR psz, _In_ DWORD dwFlags );
	[DllImport(Lib_input, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InstallLayoutOrTipUserReg([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszUserReg,
		[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszSystemReg,
		[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszSoftwareReg,
		[In, MarshalAs(UnmanagedType.LPWStr)] string psz, [In] ILOT dwFlags);

	/// <summary>The <c>MsimtfIsWindowFiltered</c> function tests if the given window is filtered by AIMM (Active Input Method Manager).</summary>
	/// <param name="hwnd">A window handle to be tested.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>If this window is filtered by Active Input Method Manager.</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>If this window is not filtered by Active Input Method Manager.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>A window can be filtered by IActiveIMMApp::FilterClientWindows.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/msimtfiswindowfiltered BOOL CALLBACK MsimtfIsWindowFiltered( _In_ HWND hwnd );
	[DllImport(Lib_msimtf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool MsimtfIsWindowFiltered([In] HWND hwnd);

	/// <summary>Queries the specified string which represents the format of a keyboard layout list or text services profile list.</summary>
	/// <param name="psz">A string that represents a keyboard layout list or a text services profile list.</param>
	/// <param name="dwFlags">This must be 0.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>All layouts or profiles defined in psz are valid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more of the layouts or profiles defined in psz are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The string format of the layout list is:</para>
	/// <para>&lt;LangID 1&gt;:&lt;KLID 1&gt;;[...:</para>
	/// <para>The string format of the text service profile list is:</para>
	/// <para>&lt;LangID 1&gt;:{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx};</para>
	/// <para>The following is an example of a value for the psz parameter:</para>
	/// <para>
	/// <code>"0x0407:0x00000407" "0x0407:0x00000407;0x040C:0x0000040C" "0x0407:0x00000407;0x0412:{A028AE76-01B1-46C2-99C4-ACD9858AE02F}{B5FE1F02-D5F2-4445-9C03-C568F23C99A1};0x040C:0x0000040C"</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/querylayoutortipstring HRESULT CALLBACK QueryLayoutOrTipString( _In_ LPCWSTR
	// psz, _In_ DWORD dwFlags );
	[DllImport(Lib_input, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("")]
	public static extern HRESULT QueryLayoutOrTipString([In, MarshalAs(UnmanagedType.LPWStr)] string psz, uint dwFlags = 0);

	/// <summary>
	/// Queries the specified string which represents the format of a keyboard layout list or text services profile list of the
	/// specified registry path.
	/// </summary>
	/// <param name="pszUserReg">The registry path of the user. If this parameter is <c>NULL</c>, HKEY_CURRENT_USER is used.</param>
	/// <param name="pszSystemReg">
	/// The registry path of the system. If this parameter is <c>NULL</c>, HKEY_LOCAL_MACHINE\System is used.
	/// </param>
	/// <param name="pszSoftwareReg">
	/// The registry path of the software. If this parameter is <c>NULL</c>, HKEY_LOCAL_MACHINE\Software is used.
	/// </param>
	/// <param name="psz">A string that represents a keyboard layout list or a text services profile list.</param>
	/// <param name="dwFlags">This must be 0.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>All layouts or profiles defined in psz are valid.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more of the layouts or profiles defined in psz are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The string format of the layout list is:</para>
	/// <para>&lt;LangID 1&gt;:&lt;KLID 1&gt;;[...:</para>
	/// <para>The string format of the text service profile list is:</para>
	/// <para>&lt;LangID 1&gt;:{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx};</para>
	/// <para>The following is an example of a value for the psz parameter:</para>
	/// <para>
	/// <code>"0x0407:0x00000407" "0x0407:0x00000407;0x040C:0x0000040C" "0x0407:0x00000407;0x0412:{A028AE76-01B1-46C2-99C4-ACD9858AE02F}{B5FE1F02-D5F2-4445-9C03-C568F23C99A1};0x040C:0x0000040C"</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/querylayoutortipstringuserreg HRESULT CALLBACK QueryLayoutOrTipStringUserReg(
	// _In_ LPCWSTR pszUserReg, _In_ LPCWSTR pszSystemReg, _In_ LPCWSTR pszSoftwareReg, _In_ LPCWSTR psz, _In_ DWORD dwFlags );
	[DllImport(Lib_input, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("")]
	public static extern HRESULT QueryLayoutOrTipStringUserReg([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszUserReg,
		[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszSystemReg,
		[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszSoftwareReg,
		[In, MarshalAs(UnmanagedType.LPWStr)] string psz, [In] uint dwFlags = 0);

	/// <summary>Applies the user keyboard layout and text service setting to the default user hive.</summary>
	/// <param name="hwndParent">
	/// The parent window for the warning dialog box. The warning dialog box is not always shown and appears appropriately. If this
	/// parameter is NULL, the warning dialog box will not be shown.
	/// </param>
	/// <param name="hSourceRegKey">The root registry key of the user setting to be copied.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/savedefaultuserinputsettings BOOL CALLBACK SaveDefaultUserInputSettings( _In_
	// HWND hwndParent, _In_ HKEY hSourceRegKey );
	[DllImport(Lib_input, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SaveDefaultUserInputSettings([In] HWND hwndParent, [In] HKEY hSourceRegKey);

	/// <summary>Applies the user keyboard layout and text service setting to the system accounts hive.</summary>
	/// <param name="hwndParent">
	/// The parent window for the warning dialog box. The warning dialog box is not always shown and appears appropriately. If this
	/// parameter is <c>NULL</c>, the warning dialog box will not be shown.
	/// </param>
	/// <param name="hSourceRegKey">The root registry key of the user setting to be copied.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The system account hive is HKEY_USERS\.DEFAULT, HKEY_USERS\S-1-5-19, and HKEY_USERS\S-1-5-20.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/savesystemacctinputsettings BOOL CALLBACK SaveSystemAcctInputSettings( _In_
	// HWND hwndParent, _In_ HKEY hSourceRegKey );
	[DllImport(Lib_input, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SaveSystemAcctInputSettings([In] HWND hwndParent, [In] HKEY hSourceRegKey);

	/// <summary>Sets the specified keyboard layout or a text service as the default input item of the current user.</summary>
	/// <param name="psz">A string that represents a keyboard layout list or a text services profile list.</param>
	/// <param name="dwFlags">
	/// <para>A bitfield that specifies the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SDLOT_NOAPPLYTOCURRENTSESSION 0x00000001</term>
	/// <term>
	/// Stores the setting in the registry but dose not update the runtime keyboard setting of the current session. If the alternative
	/// registry path is set in SetDefaultLayoutOrTipUserReg, this flag should be set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SDLOT_APPLYTOCURRENTTHREAD 0x00000002</term>
	/// <term>Applies the setting immediately on the current thread.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The string format of the layout list is:</para>
	/// <para>&lt;LangID 1&gt;:&lt;KLID 1&gt;;[...:</para>
	/// <para>The string format of the text service profile list is:</para>
	/// <para>&lt;LangID 1&gt;:{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx};</para>
	/// <para>The following is an example of a value for the psz parameter:</para>
	/// <para>
	/// <code>"0x0407:0x00000407" "0x0407:0x00000407;0x040C:0x0000040C" "0x0407:0x00000407;0x0412:{A028AE76-01B1-46C2-99C4-ACD9858AE02F}{B5FE1F02-D5F2-4445-9C03-C568F23C99A1};0x040C:0x0000040C"</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/setdefaultlayoutortip BOOL CALLBACK SetDefaultLayoutOrTip( _In_ LPCWSTR psz,
	// _In_ LPCWSTR psz DWORD dwFlags );
	[DllImport(Lib_input, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetDefaultLayoutOrTip([In, MarshalAs(UnmanagedType.LPWStr)] string psz, SDLOT dwFlags);

	/// <summary>Sets the specified keyboard layout or a text service as a default input item of the user registry.</summary>
	/// <param name="pszUserReg">The registry path of the user. If this parameter is <c>NULL</c>, HKEY_CURRENT_USER is used.</param>
	/// <param name="pszSystemReg">
	/// The registry path of the system. If this parameter is <c>NULL</c>, HKEY_LOCAL_MACHINE\System is used.
	/// </param>
	/// <param name="pszSoftwareReg">
	/// The registry path of the software. If this parameter is <c>NULL</c>, HKEY_LOCAL_MACHINE\Software is used.
	/// </param>
	/// <param name="psz">A string that represents the keyboard layout list or text services profile list.</param>
	/// <param name="dwFlags">
	/// <para>A bitfield that specifies the following flags:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SDLOT_NOAPPLYTOCURRENTSESSION 0x00000001</term>
	/// <term>
	/// Stores the setting in the registry but dose not update the runtime keyboard setting of the current session. If the alternative
	/// registry path is set in SetDefaultLayoutOrTipUserReg, this flag should be set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SDLOT_APPLYTOCURRENTTHREAD 0x00000002</term>
	/// <term>Applies the setting immediately on the current thread.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The string format of the layout list is:</para>
	/// <para>&lt;LangID 1&gt;:&lt;KLID 1&gt;;[...:</para>
	/// <para>The string format of the text service profile list is:</para>
	/// <para>&lt;LangID 1&gt;:{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx};</para>
	/// <para>The following is an example of a value for the psz parameter:</para>
	/// <para>
	/// <code>"0x0407:0x00000407" "0x0407:0x00000407;0x040C:0x0000040C" "0x0407:0x00000407;0x0412:{A028AE76-01B1-46C2-99C4-ACD9858AE02F}{B5FE1F02-D5F2-4445-9C03-C568F23C99A1};0x040C:0x0000040C"</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/setdefaultlayoutortipuserreg BOOL CALLBACK SetDefaultLayoutOrTipUserReg(
	// _In_opt_ LPCWSTR pszUserReg, _In_opt_ LPCWSTR pszSystemReg, _In_opt_ LPCWSTR pszSoftwareReg, _In_ LPCWSTR psz, _In_ DWORD dwFlags );
	[DllImport(Lib_input, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetDefaultLayoutOrTipUserReg([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszUserReg,
		[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszSystemReg,
		[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszSoftwareReg,
		[In, MarshalAs(UnmanagedType.LPWStr)] string psz, [In] SDLOT dwFlags);

	/// <summary>
	/// The <c>TF_CreateCategoryMgr</c> function creates a category manager object without having to initialize COM. Usage must be done
	/// carefully because the calling thread must maintain the reference count on an object that is owned by MSCTF.DLL.
	/// </summary>
	/// <param name="ppcat">Pointer to ITFCategoryMgr interface pointer that receives the category manager object.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-tf_createcategorymgr HRESULT TF_CreateCategoryMgr(
	// ITfCategoryMgr **ppcat );
	[DllImport(Lib_Msctf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msctf.h", MSDNShortId = "NF:msctf.TF_CreateCategoryMgr")]
	public static extern HRESULT TF_CreateCategoryMgr(out ITfCategoryMgr ppcat);

	/// <summary>
	/// <para>
	/// The <c>TF_CreateDisplayAttributeMgr</c> function is used to create a display attribute manager object without having to
	/// initialize COM. Usage of this method is not recommended, because the calling process must maintain a proper reference count on
	/// an object that is owned by Msctf.dll.
	/// </para>
	/// <para>
	/// It is instead recommended that display attribute manager objects be created using CoCreateInstance , as demonstrated in ITfDisplayAttributeMgr.
	/// </para>
	/// </summary>
	/// <param name="ppdam">
	/// Pointer to an <c>ITfDisplayAttributeMgr</c> interface pointer that receives the display attribute manager object.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>ppdam is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-tf_createdisplayattributemgr HRESULT
	// TF_CreateDisplayAttributeMgr( ITfDisplayAttributeMgr **ppdam );
	[DllImport(Lib_Msctf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msctf.h", MSDNShortId = "NF:msctf.TF_CreateDisplayAttributeMgr")]
	public static extern HRESULT TF_CreateDisplayAttributeMgr(out ITfDisplayAttributeMgr ppdam);

	/// <summary>
	/// <para>
	/// The <c>TF_CreateInputProcessorProfiles</c> function is used to create a input processor profile object without having to
	/// initialize COM. Usage of this method is not recommended, because the calling process must maintain a proper reference count on
	/// an object that is owned by Msctf.dll.
	/// </para>
	/// <para>
	/// It is instead recommended that input processor profile objects be created using CoCreateInstance , as demonstrated in ITfInputProcessorProfiles.
	/// </para>
	/// </summary>
	/// <param name="ppipr">
	/// Pointer to an <c>ITfInputProcessorProfiles</c> interface pointer that receives the input processor profile object.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>ppipr is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-tf_createinputprocessorprofiles HRESULT
	// TF_CreateInputProcessorProfiles( ITfInputProcessorProfiles **ppipr );
	[DllImport(Lib_Msctf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msctf.h", MSDNShortId = "NF:msctf.TF_CreateInputProcessorProfiles")]
	public static extern HRESULT TF_CreateInputProcessorProfiles(out ITfInputProcessorProfiles ppipr);

	/// <summary>
	/// <para>
	/// The <c>TF_CreateLangBarItemMgr</c> function is used to create a language bar item manager object without having to initialize
	/// COM. Usage of this method is not recommended, because the calling process must maintain a proper reference count on an object
	/// that is owned by Msctf.dll.
	/// </para>
	/// <para>
	/// It is instead recommended that language bar item manager objects be created using CoCreateInstance , as demonstrated in ITfLangBarItemMgr.
	/// </para>
	/// </summary>
	/// <param name="pplbim">Pointer to an <c>ITfLangBarItemMgr</c> interface pointer that receives the language bar item manager object.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>pplbim is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-tf_createlangbaritemmgr HRESULT TF_CreateLangBarItemMgr(
	// ITfLangBarItemMgr **pplbim );
	[DllImport(Lib_Msctf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msctf.h", MSDNShortId = "NF:msctf.TF_CreateLangBarItemMgr")]
	public static extern HRESULT TF_CreateLangBarItemMgr(out ITfLangBarItemMgr pplbim);

	/// <summary>
	/// <para>
	/// The <c>TF_CreateLangBarMgr</c> function creates a language bar manager object without having to initialize COM. Usage of this
	/// method is not recommended, because the calling process must maintain a proper reference count on an object that is owned by Msctf.dll.
	/// </para>
	/// <para>It is instead recommended that language bar manager objects be created using CoCreateInstance , as demonstrated in ITfLangBarMgr.</para>
	/// </summary>
	/// <param name="pppbm">Pointer to an <c>ITfLangBarMgr</c> interface pointer that receives the language bar manager object.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>pppbm is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-tf_createlangbarmgr HRESULT TF_CreateLangBarMgr( ITfLangBarMgr
	// **pppbm );
	[DllImport(Lib_Msctf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msctf.h", MSDNShortId = "NF:msctf.TF_CreateLangBarMgr")]
	public static extern HRESULT TF_CreateLangBarMgr(out ITfLangBarMgr pppbm);

	/// <summary>
	/// <para>
	/// The <c>TF_CreateThreadMgr</c> function creates a thread manager object without having to initialize COM. Usage of this method is
	/// not recommended, because the calling process must maintain a proper reference count on an object that is owned by Msctf.dll.
	/// </para>
	/// <para>It is instead recommended that thread manager objects be created using CoCreateInstance , as demonstrated in ITfThreadMgr.</para>
	/// </summary>
	/// <param name="pptim">Pointer to an <c>ITfThreadMgr</c> interface pointer that receives the thread manager object.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>pptim is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-tf_createthreadmgr HRESULT TF_CreateThreadMgr( ITfThreadMgr
	// **pptim );
	[DllImport(Lib_Msctf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msctf.h", MSDNShortId = "NF:msctf.TF_CreateThreadMgr")]
	public static extern HRESULT TF_CreateThreadMgr(out ITfThreadMgr pptim);

	/// <summary>
	/// The <c>TF_GetThreadMgr</c> function obtains a copy of a thread manager object previously created within the calling thread.
	/// </summary>
	/// <param name="pptim">
	/// Pointer to an ITfThreadMgr interface pointer that receives the thread manager object. This receives <c>NULL</c> if no thread
	/// manager is created within the calling thread.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function was successful. pptim will be NULL if no thread manager is created within the calling thread.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If no thread manager is created within the calling thread, this function will set pptim to <c>NULL</c> and return S_OK.
	/// Therefore, it is necessary to verify that the function succeeded and that pptim is not <c>NULL</c> before using pptim.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// There is no import library available that defines this function, so it is necessary to manually obtain a pointer to this
	/// function using LoadLibrary and GetProcAddress. The following code example demonstrates how to accomplish this.
	/// </para>
	/// <para>
	/// The following example demonstrates a function that will attempt to obtain a copy of a previously created thread manager object.
	/// If no thread manager object exists within the calling thread, the function will create one.
	/// </para>
	/// <para><c>Note</c>
	/// <para></para>
	/// Using <c>LoadLibrary</c> incorrectly can compromise the security of your application by loading the wrong DLL. Refer to the
	/// <c>LoadLibrary</c> documentation for information on how to correctly load DLLs with different versions of Windows.
	/// </para>
	/// <para>
	/// <code> typedef HRESULT (WINAPI *PTF_GETTHREADMGR)(ITfThreadMgr **pptim); HRESULT GetThreadMgr(ITfThreadMgr **pptm) { HRESULT hr = E_FAIL; HMODULE hMSCTF = LoadLibrary(TEXT("msctf.dll")); ITfThreadMgr *pThreadMgr = NULL; if(hMSCTF == NULL) { //Error loading module -- fail as securely as possible } else { PTF_GETTHREADMGR pfnGetThreadMgr; pfnGetThreadMgr = (PTF_GETTHREADMGR)GetProcAddress(hMSCTF, "TF_GetThreadMgr"); if(pfnGetThreadMgr) { hr = (*pfnGetThreadMgr)(&amp;pThreadMgr); } FreeLibrary(hMSCTF); } //If no object could be obtained, try to create one. if(NULL == pThreadMgr) { //CoInitialize or OleInitialize must already have been called. hr = CoCreateInstance( CLSID_TF_ThreadMgr, NULL, CLSCTX_INPROC_SERVER, IID_ITfThreadMgr, (void**)&amp;pThreadMgr); } *pptm = pThreadMgr; return hr; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-tf_getthreadmgr HRESULT TF_GetThreadMgr( ITfThreadMgr **pptim );
	[DllImport(Lib_Msctf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msctf.h", MSDNShortId = "NF:msctf.TF_GetThreadMgr")]
	public static extern HRESULT TF_GetThreadMgr(out ITfThreadMgr pptim);

	/// <summary>
	/// The <c>TF_InvalidAssemblyListCacheIfExist</c> function invalidates the text input processor's description cache. It is not
	/// necessary to call this function if the input processor setup program requires you to restart or log on. The cache is valid until
	/// the user logs off.
	/// </summary>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/tsf/tf-invalidassemblylistcacheifexist HRESULT TF_InvalidAssemblyListCacheIfExist(void);
	[DllImport(Lib_Msctf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("")]
	public static extern HRESULT TF_InvalidAssemblyListCacheIfExist();

	/// <summary>The UninitLocalMsCtfMonitor function uninitializes TextServicesFramework on the current desktop.</summary>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctfmonitorapi/nf-msctfmonitorapi-uninitlocalmsctfmonitor HRESULT UninitLocalMsCtfMonitor();
	[DllImport(Lib_Msctf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msctfmonitorapi.h", MSDNShortId = "NF:msctfmonitorapi.UninitLocalMsCtfMonitor")]
	public static extern HRESULT UninitLocalMsCtfMonitor();

	/// <summary/>
	[PInvokeData("")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct LAYOUTORTIP
	{
		/// <summary/>
		public LOT dwFlags;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Kernel32.MAX_PATH)]
		public string szId; // Id of the keyboard item in the string format.

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Kernel32.MAX_PATH)]
		public string szName; // The description of the keyboard item.
	}

	/// <summary/>
	[PInvokeData("")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct LAYOUTORTIPPROFILE
	{
		/// <summary/>
		public LOTP dwProfileType; // InputProcessor or HKL

		/// <summary/>
		public LANGID langid; // language id

		/// <summary/>
		public Guid clsid; // in Guid of tip

		/// <summary/>
		public Guid guidProfile; // profile description

		/// <summary/>
		public Guid catid; // category of tip

		/// <summary/>
		public uint dwSubstituteLayout; // substitute hkl

		/// <summary/>
		public uint dwFlags; // Flags

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Kernel32.MAX_PATH)]
		public string szId; // KLID or TIP profile for string
	}
}