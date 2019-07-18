namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Undocumented, but verifies that</summary>
		/// <returns></returns>
		[PInvokeData("versionhelpers.h")]
		public static bool IsActiveSessionCountLimited()
		{
			var VersionInfo = OSVERSIONINFOEX.Default;
			VersionInfo.wSuiteMask = SuiteMask.VER_SUITE_TERMINAL;

			var dwlConditionMask = VerSetConditionMask(0, VERSION_MASK.VER_SUITENAME, VERSION_CONDITION.VER_AND);
			var fSuiteTerminal = VerifyVersionInfo(ref VersionInfo, VERSION_MASK.VER_SUITENAME, dwlConditionMask);

			VersionInfo.wSuiteMask = SuiteMask.VER_SUITE_SINGLEUSERTS;
			var fSuiteSingleUserTS = VerifyVersionInfo(ref VersionInfo, VERSION_MASK.VER_SUITENAME, dwlConditionMask);

			return !(fSuiteTerminal & !fSuiteSingleUserTS);
		}

		/// <summary>Indicates if the current OS version matches, or is greater than, the Windows 10 version.</summary>
		/// <returns>True if the current OS version matches, or is greater than, the Windows 10 version; otherwise, false.</returns>
		/// <remarks>
		/// <para>
		/// Applications not manifested for Windows 10 return false, even if the current operating system version is Windows 10. To manifest
		/// your applications for Windows 10, see Targeting your application for Windows.
		/// </para>
		/// <para>
		/// The version helper functions do not differentiate between client and server releases. They return <c>true</c> if the current OS
		/// version number is equal to or higher than the version of the client named in the call. For example, a call to
		/// IsWindowsXPSP3OrGreater will return <c>true</c> on Windows Server 2008. Applications that need to distinguish between server and
		/// client versions of Windows should call IsWindowsServer.
		/// </para>
		/// <para>
		/// For situations where a Windows Server version number isn't shared with a Windows client release, you can use
		/// IsWindowsVersionOrGreater to confirm.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The inline functions defined in the <c>VersionHelpers.h</c> header file let you verify the operating system version by returning
		/// a <c>Boolean</c> value when testing for a version of Windows.
		/// </para>
		/// <para>For example, if your application requires Windows 10 or later, use the following test.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/versionhelpers/nf-versionhelpers-iswindows10orgreater VERSIONHELPERAPI
		// IsWindows10OrGreater( );
		[PInvokeData("versionhelpers.h", MSDNShortId = "1F7AE6CA-3E2B-4DF1-A047-58AB9A0B1DA4")]
		public static bool IsWindows10OrGreater() => IsWindowsVersionOrGreater(Macros.HIBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WIN10), Macros.LOBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WIN10), 0);

		/// <summary>Indicates if the current OS version matches, or is greater than, the Windows 7 version.</summary>
		/// <returns>True if the current OS version matches, or is greater than, the Windows 7 version; otherwise, false.</returns>
		/// <remarks>
		/// <para>
		/// This function does not differentiate between client and server releases. It will return <c>true</c> if the current OS version
		/// number is equal to or higher than the version of the client named in the call. For example, a call to IsWindowsXPSP3OrGreater
		/// will return <c>true</c> on Windows Server 2008. Applications that need to distinguish between server and client versions of
		/// Windows should call IsWindowsServer.
		/// </para>
		/// <para>
		/// For situations where a Windows Server version number isn't shared with a Windows client release, you can use
		/// IsWindowsVersionOrGreater to confirm.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The inline functions defined in the <c>VersionHelpers.h</c> header file let you verify the operating system version by returning
		/// a <c>Boolean</c> value when testing for a version of Windows.
		/// </para>
		/// <para>For example, if your application requires Windows 7 or later, use the following test.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/versionhelpers/nf-versionhelpers-iswindows7orgreater VERSIONHELPERAPI
		// IsWindows7OrGreater( );
		[PInvokeData("versionhelpers.h", MSDNShortId = "5C475B5E-1412-4F60-AB81-00BE83E204BF")]
		public static bool IsWindows7OrGreater() => IsWindowsVersionOrGreater(Macros.HIBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WIN7), Macros.LOBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WIN7), 0);

		/// <summary>Indicates if the current OS version matches, or is greater than, the Windows 7 with Service Pack 1 (SP1) version.</summary>
		/// <returns>True if the current OS version matches, or is greater than, the Windows 7 with SP1 version; otherwise, false.</returns>
		/// <remarks>
		/// <para>
		/// This function does not differentiate between client and server releases. It will return <c>true</c> if the current OS version
		/// number is equal to or higher than the version of the client named in the call. For example, a call to IsWindowsXPSP3OrGreater
		/// will return <c>true</c> on Windows Server 2008. Applications that need to distinguish between server and client versions of
		/// Windows should call IsWindowsServer.
		/// </para>
		/// <para>
		/// For situations where a Windows Server version number isn't shared with a Windows client release, you can use
		/// IsWindowsVersionOrGreater to confirm.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The inline functions defined in the <c>VersionHelpers.h</c> header file let you verify the operating system version by returning
		/// a <c>Boolean</c> value when testing for a version of Windows.
		/// </para>
		/// <para>For example, if your application requires Windows 7 with SP1 or later, use the following test.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/versionhelpers/nf-versionhelpers-iswindows7sp1orgreater VERSIONHELPERAPI
		// IsWindows7SP1OrGreater( );
		[PInvokeData("versionhelpers.h", MSDNShortId = "E8AD3423-91EF-4ECE-9EF2-808C68CEA861")]
		public static bool IsWindows7SP1OrGreater() => IsWindowsVersionOrGreater(Macros.HIBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WIN7), Macros.LOBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WIN7), 1);

		/// <summary>Indicates if the current OS version matches, or is greater than, the Windows 8 version.</summary>
		/// <returns>True if the current OS version matches, or is greater than, the Windows 8 version; otherwise, false.</returns>
		/// <remarks>
		/// <para>
		/// This function does not differentiate between client and server releases. It will return <c>true</c> if the current OS version
		/// number is equal to or higher than the version of the client named in the call. For example, a call to IsWindowsXPSP3OrGreater
		/// will return <c>true</c> on Windows Server 2008. Applications that need to distinguish between server and client versions of
		/// Windows should call IsWindowsServer.
		/// </para>
		/// <para>
		/// For situations where a Windows Server version number isn't shared with a Windows client release, you can use
		/// IsWindowsVersionOrGreater to confirm.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The inline functions defined in the <c>VersionHelpers.h</c> header file let you verify the operating system version by returning
		/// a <c>Boolean</c> value when testing for a version of Windows.
		/// </para>
		/// <para>For example, if your application requires Windows 8 or later, use the following test.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/versionhelpers/nf-versionhelpers-iswindows8orgreater VERSIONHELPERAPI
		// IsWindows8OrGreater( );
		[PInvokeData("versionhelpers.h", MSDNShortId = "D11971C8-2E8F-4AD2-BE0B-FEFEC8949125")]
		public static bool IsWindows8OrGreater() => IsWindowsVersionOrGreater(Macros.HIBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WIN8), Macros.LOBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WIN8), 0);

		/// <summary>Indicates if the current OS version matches, or is greater than, the Windows 8.1 version.</summary>
		/// <returns>True if the current OS version matches, or is greater than, the Windows 8.1 version; otherwise, false.</returns>
		/// <remarks>
		/// <para>
		/// Applications not manifested for Windows 8.1 or Windows 10 return false, even if the current operating system version is Windows
		/// 8.1 or Windows 10. To manifest your applications for Windows 8.1 or Windows 10, see Targeting your application for Windows.
		/// </para>
		/// <para>
		/// This function does not differentiate between client and server releases. It will return <c>true</c> if the current OS version
		/// number is equal to or higher than the version of the client named in the call. For example, a call to IsWindowsXPSP3OrGreater
		/// will return <c>true</c> on Windows Server 2008. Applications that need to distinguish between server and client versions of
		/// Windows should call IsWindowsServer.
		/// </para>
		/// <para>
		/// For situations where a Windows Server version number isn't shared with a Windows client release, you can use
		/// IsWindowsVersionOrGreater to confirm.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The inline functions defined in the <c>VersionHelpers.h</c> header file let you verify the operating system version by returning
		/// a <c>Boolean</c> value when testing for a version of Windows.
		/// </para>
		/// <para>For example, if your application requires Windows 8.1 or later, use the following test.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/versionhelpers/nf-versionhelpers-iswindows8point1orgreater VERSIONHELPERAPI
		// IsWindows8Point1OrGreater( );
		[PInvokeData("versionhelpers.h", MSDNShortId = "E391B568-5E43-42C7-B186-8CA524331FFE")]
		public static bool IsWindows8Point1OrGreater() => IsWindowsVersionOrGreater(Macros.HIBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WINBLUE), Macros.LOBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WINBLUE), 0);

		/// <summary>
		/// Indicates if the current OS is a Windows Server release. Applications that need to distinguish between server and client versions
		/// of Windows should call this function.
		/// </summary>
		/// <returns>True if the current OS is a Windows Server version; otherwise, false.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/versionhelpers/nf-versionhelpers-iswindowsserver VERSIONHELPERAPI
		// IsWindowsServer( );
		[PInvokeData("versionhelpers.h", MSDNShortId = "7CC1DD25-762B-489F-AC20-1B57764923A2")]
		public static bool IsWindowsServer()
		{
			var osvi = OSVERSIONINFOEX.Default;
			osvi.wProductType = ProductType.VER_NT_WORKSTATION;

			var dwlConditionMask = VerSetConditionMask(0, VERSION_MASK.VER_PRODUCT_TYPE, VERSION_CONDITION.VER_EQUAL);

			return !VerifyVersionInfo(ref osvi, VERSION_MASK.VER_PRODUCT_TYPE, dwlConditionMask);
		}

		/// <summary>Indicates if the current OS version matches, or is greater than, the most recent Windows version.</summary>
		/// <returns>True if the current OS version matches, or is greater than, the most recent Windows version; otherwise, false.</returns>
		[PInvokeData("versionhelpers.h")]
		public static bool IsWindowsThresholdOrGreater() => IsWindowsVersionOrGreater(Macros.HIBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WINTHRESHOLD), Macros.LOBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WINTHRESHOLD), 0);

		/// <summary>
		/// Indicates if the current OS version matches, or is greater than, the provided version information. This function is useful in
		/// confirming a version of Windows Server that doesn't share a version number with a client release.
		/// </summary>
		/// <param name="wMajorVersion">The major OS version number.</param>
		/// <param name="wMinorVersion">The minor OS version number.</param>
		/// <param name="wServicePackMajor">The major Service Pack version number.</param>
		/// <returns>
		/// <c>TRUE</c> if the specified version matches, or is greater than, the version of the current Windows OS; otherwise, <c>FALSE</c>.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/versionhelpers/nf-versionhelpers-iswindowsversionorgreater VERSIONHELPERAPI
		// IsWindowsVersionOrGreater( WORD wMajorVersion, WORD wMinorVersion, WORD wServicePackMajor );
		[PInvokeData("versionhelpers.h", MSDNShortId = "B28DFEC0-A94E-49F6-9DF0-4EE470EC4AF5")]
		public static bool IsWindowsVersionOrGreater(ushort wMajorVersion, ushort wMinorVersion, ushort wServicePackMajor)
		{
			var osvi = OSVERSIONINFOEX.Default;
			osvi.dwMajorVersion = wMajorVersion;
			osvi.dwMinorVersion = wMinorVersion;
			osvi.wServicePackMajor = wServicePackMajor;

			var dwlConditionMask = VerSetConditionMask(VerSetConditionMask(VerSetConditionMask(0, VERSION_MASK.VER_MAJORVERSION, VERSION_CONDITION.VER_GREATER_EQUAL), VERSION_MASK.VER_MINORVERSION, VERSION_CONDITION.VER_GREATER_EQUAL), VERSION_MASK.VER_SERVICEPACKMAJOR, VERSION_CONDITION.VER_GREATER_EQUAL);

			return VerifyVersionInfo(ref osvi, VERSION_MASK.VER_MAJORVERSION | VERSION_MASK.VER_MINORVERSION | VERSION_MASK.VER_SERVICEPACKMAJOR, dwlConditionMask);
		}

		/// <summary>Indicates if the current OS version matches, or is greater than, the Windows Vista version.</summary>
		/// <returns>True if the current OS version matches, or is greater than, the Windows Vista version; otherwise, false.</returns>
		/// <remarks>
		/// <para>
		/// This function does not differentiate between client and server releases. It will return <c>true</c> if the current OS version
		/// number is equal to or higher than the version of the client named in the call. For example, a call to IsWindowsXPSP3OrGreater
		/// will return <c>true</c> on Windows Server 2008. Applications that need to distinguish between server and client versions of
		/// Windows should call IsWindowsServer.
		/// </para>
		/// <para>
		/// For situations where a Windows Server version number isn't shared with a Windows client release, you can use
		/// IsWindowsVersionOrGreater to confirm.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The inline functions defined in the <c>VersionHelpers.h</c> header file let you verify the operating system version by returning
		/// a <c>Boolean</c> value when testing for a version of Windows.
		/// </para>
		/// <para>For example, if your application requires Windows Vista or later, use the following test.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/versionhelpers/nf-versionhelpers-iswindowsvistaorgreater VERSIONHELPERAPI
		// IsWindowsVistaOrGreater( );
		[PInvokeData("versionhelpers.h", MSDNShortId = "556C70DC-6A44-4D85-BDBF-C1110D63DC69")]
		public static bool IsWindowsVistaOrGreater() => IsWindowsVersionOrGreater(Macros.HIBYTE((ushort)WIN32_WINNT._WIN32_WINNT_VISTA), Macros.LOBYTE((ushort)WIN32_WINNT._WIN32_WINNT_VISTA), 0);

		/// <summary>Indicates if the current OS version matches, or is greater than, the Windows Vista with Service Pack 1 (SP1) version.</summary>
		/// <returns>True if the current OS version matches, or is greater than, the Windows Vista with SP1 version; otherwise, false.</returns>
		/// <remarks>
		/// <para>
		/// This function does not differentiate between client and server releases. It will return <c>true</c> if the current OS version
		/// number is equal to or higher than the version of the client named in the call. For example, a call to IsWindowsXPSP3OrGreater
		/// will return <c>true</c> on Windows Server 2008. Applications that need to distinguish between server and client versions of
		/// Windows should call IsWindowsServer.
		/// </para>
		/// <para>
		/// For situations where a Windows Server version number isn't shared with a Windows client release, you can use
		/// IsWindowsVersionOrGreater to confirm.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The inline functions defined in the <c>VersionHelpers.h</c> header file let you verify the operating system version by returning
		/// a <c>Boolean</c> value when testing for a version of Windows.
		/// </para>
		/// <para>For example, if your application requires Windows Vista with SP1 or later, use the following test.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/versionhelpers/nf-versionhelpers-iswindowsvistasp1orgreater VERSIONHELPERAPI
		// IsWindowsVistaSP1OrGreater( );
		[PInvokeData("versionhelpers.h", MSDNShortId = "7E74A761-E336-4618-B92F-166C3DF1FF66")]
		public static bool IsWindowsVistaSP1OrGreater() => IsWindowsVersionOrGreater(Macros.HIBYTE((ushort)WIN32_WINNT._WIN32_WINNT_VISTA), Macros.LOBYTE((ushort)WIN32_WINNT._WIN32_WINNT_VISTA), 1);

		/// <summary>Indicates if the current OS version matches, or is greater than, the Windows Vista with Service Pack 2 (SP2) version.</summary>
		/// <returns>True if the current OS version matches, or is greater than, the Windows Vista with SP2 version; otherwise, false.</returns>
		/// <remarks>
		/// <para>
		/// This function does not differentiate between client and server releases. It will return <c>true</c> if the current OS version
		/// number is equal to or higher than the version of the client named in the call. For example, a call to IsWindowsXPSP3OrGreater
		/// will return <c>true</c> on Windows Server 2008. Applications that need to distinguish between server and client versions of
		/// Windows should call IsWindowsServer.
		/// </para>
		/// <para>
		/// For situations where a Windows Server version number isn't shared with a Windows client release, you can use
		/// IsWindowsVersionOrGreater to confirm.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The inline functions defined in the <c>VersionHelpers.h</c> header file let you verify the operating system version by returning
		/// a <c>Boolean</c> value when testing for a version of Windows.
		/// </para>
		/// <para>For example, if your application requires Windows Vista with SP2 or later, use the following test.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/versionhelpers/nf-versionhelpers-iswindowsvistasp2orgreater VERSIONHELPERAPI
		// IsWindowsVistaSP2OrGreater( );
		[PInvokeData("versionhelpers.h", MSDNShortId = "8D7F5DA2-8927-4453-A5E3-35A345B099EC")]
		public static bool IsWindowsVistaSP2OrGreater() => IsWindowsVersionOrGreater(Macros.HIBYTE((ushort)WIN32_WINNT._WIN32_WINNT_VISTA), Macros.LOBYTE((ushort)WIN32_WINNT._WIN32_WINNT_VISTA), 2);

		/// <summary>Indicates if the current OS version matches, or is greater than, the Windows XP version.</summary>
		/// <returns>True if the current OS version matches, or is greater than, the Windows XP version; otherwise, false.</returns>
		/// <remarks>
		/// <para>
		/// This function does not differentiate between client and server releases. It will return <c>true</c> if the current OS version
		/// number is equal to or higher than the version of the client named in the call. For example, a call to IsWindowsXPSP3OrGreater
		/// will return <c>true</c> on Windows Server 2008. Applications that need to distinguish between server and client versions of
		/// Windows should call IsWindowsServer.
		/// </para>
		/// <para>
		/// For situations where a Windows Server version number isn't shared with a Windows client release, you can use
		/// IsWindowsVersionOrGreater to confirm.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The inline functions defined in the <c>VersionHelpers.h</c> header file let you verify the operating system version by returning
		/// a <c>Boolean</c> value when testing for a version of Windows.
		/// </para>
		/// <para>For example, if your application requires Windows XP or later, use the following test.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/versionhelpers/nf-versionhelpers-iswindowsxporgreater VERSIONHELPERAPI
		// IsWindowsXPOrGreater( );
		[PInvokeData("versionhelpers.h", MSDNShortId = "48B7FAD6-569F-4CF5-A413-857679363736")]
		public static bool IsWindowsXPOrGreater() => IsWindowsVersionOrGreater(Macros.HIBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WINXP), Macros.LOBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WINXP), 0);

		/// <summary>Indicates if the current OS version matches, or is greater than, the Windows XP with Service Pack 1 (SP1) version.</summary>
		/// <returns>True if the current OS version matches, or is greater than, the Windows XP with SP1 version; otherwise, false.</returns>
		/// <remarks>
		/// <para>
		/// This function does not differentiate between client and server releases. It will return <c>true</c> if the current OS version
		/// number is equal to or higher than the version of the client named in the call. For example, a call to IsWindowsXPSP3OrGreater
		/// will return <c>true</c> on Windows Server 2008. Applications that need to distinguish between server and client versions of
		/// Windows should call IsWindowsServer.
		/// </para>
		/// <para>
		/// For situations where a Windows Server version number isn't shared with a Windows client release, you can use
		/// IsWindowsVersionOrGreater to confirm.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The inline functions defined in the <c>VersionHelpers.h</c> header file let you verify the operating system version by returning
		/// a <c>Boolean</c> value when testing for a version of Windows.
		/// </para>
		/// <para>For example, if your application requires Windows XP with SP1 or later, use the following test.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/versionhelpers/nf-versionhelpers-iswindowsxpsp1orgreater VERSIONHELPERAPI
		// IsWindowsXPSP1OrGreater( );
		[PInvokeData("versionhelpers.h", MSDNShortId = "F8921444-B13D-4522-84F2-4792F4F37EA5")]
		public static bool IsWindowsXPSP1OrGreater() => IsWindowsVersionOrGreater(Macros.HIBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WINXP), Macros.LOBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WINXP), 1);

		/// <summary>Indicates if the current OS version matches, or is greater than, the Windows XP with Service Pack 2 (SP2) version.</summary>
		/// <returns>True if the current OS version matches, or is greater than, the Windows XP with SP2 version number; otherwise, false.</returns>
		/// <remarks>
		/// <para>
		/// This function does not differentiate between client and server releases. It will return <c>true</c> if the current OS version
		/// number is equal to or higher than the version of the client named in the call. For example, a call to IsWindowsXPSP3OrGreater
		/// will return <c>true</c> on Windows Server 2008. Applications that need to distinguish between server and client versions of
		/// Windows should call IsWindowsServer.
		/// </para>
		/// <para>
		/// For situations where a Windows Server version number isn't shared with a Windows client release, you can use
		/// IsWindowsVersionOrGreater to confirm.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The inline functions defined in the <c>VersionHelpers.h</c> header file let you verify the operating system version by returning
		/// a <c>Boolean</c> value when testing for a version of Windows.
		/// </para>
		/// <para>For example, if your application requires Windows XP with SP2 or later, use the following test.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/versionhelpers/nf-versionhelpers-iswindowsxpsp2orgreater VERSIONHELPERAPI
		// IsWindowsXPSP2OrGreater( );
		[PInvokeData("versionhelpers.h", MSDNShortId = "DA957BA8-AD28-4096-8BE5-B77CA55B9324")]
		public static bool IsWindowsXPSP2OrGreater() => IsWindowsVersionOrGreater(Macros.HIBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WINXP), Macros.LOBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WINXP), 2);

		/// <summary>Indicates if the current OS version matches, or is greater than, the Windows XP with Service Pack 3 (SP3) version.</summary>
		/// <returns>True if the current OS version matches, or is greater than, the Windows XP with SP3 version; otherwise, false.</returns>
		/// <remarks>
		/// <para>
		/// This function does not differentiate between client and server releases. It will return <c>true</c> if the current OS version
		/// number is equal to or higher than the version of the client named in the call. For example, a call to
		/// <c>IsWindowsXPSP3OrGreater</c> will return <c>true</c> on Windows Server 2008. Applications that need to distinguish between
		/// server and client versions of Windows should call IsWindowsServer.
		/// </para>
		/// <para>
		/// For situations where a Windows Server version number isn't shared with a Windows client release, you can use
		/// IsWindowsVersionOrGreater to confirm.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The inline functions defined in the <c>VersionHelpers.h</c> header file let you verify the operating system version by returning
		/// a <c>Boolean</c> value when testing for a version of Windows.
		/// </para>
		/// <para>For example, if your application requires Windows XP with SP3 or later, use the following test.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/versionhelpers/nf-versionhelpers-iswindowsxpsp3orgreater VERSIONHELPERAPI
		// IsWindowsXPSP3OrGreater( );
		[PInvokeData("versionhelpers.h", MSDNShortId = "06DC8FF0-8652-4652-855F-600AC53C6301")]
		public static bool IsWindowsXPSP3OrGreater() => IsWindowsVersionOrGreater(Macros.HIBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WINXP), Macros.LOBYTE((ushort)WIN32_WINNT._WIN32_WINNT_WINXP), 3);
	}
}