﻿using System.Collections.Generic;

namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>
	/// <para>An application-defined callback function used with the <c>EnumDesktops</c> function. It receives a desktop name.</para>
	/// <para>
	/// The DESKTOPENUMPROC type defines a pointer to this callback function. <c>EnumDesktopProc</c> is a placeholder for the
	/// application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="lpszDesktop">The name of the desktop.</param>
	/// <param name="lParam">An application-defined value specified in the <c>EnumDesktops</c> function.</param>
	/// <returns>To continue enumeration, the callback function must return TRUE. To stop enumeration, it must return FALSE.</returns>
	// BOOL CALLBACK EnumDesktopProc( _In_ LPTSTR lpszDesktop, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682612(v=vs.85).aspx
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms682612")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool EnumDesktopProc(string lpszDesktop, [In] IntPtr lParam);

	/// <summary>
	/// <para>
	/// An application-defined callback function used with the <c>EnumWindowStations</c> function. It receives a window station name.
	/// </para>
	/// <para>
	/// The <c>WINSTAENUMPROC</c> type defines a pointer to this callback function. <c>EnumWindowStationProc</c> is a placeholder for the
	/// application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="lpszWindowStation">The name of the window station.</param>
	/// <param name="lParam">An application-defined value specified in the <c>EnumWindowStations</c> function.</param>
	/// <returns>To continue enumeration, the callback function must return TRUE. To stop enumeration, it must return FALSE.</returns>
	// BOOL CALLBACK EnumWindowStationProc( _In_ LPTSTR lpszWindowStation, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682643(v=vs.85).aspx
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
	[PInvokeData("Winuser.h", MSDNShortId = "ms682643")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool EnumWindowStationProc(string lpszWindowStation, [In] IntPtr lParam);

	/// <summary>Flags used by CreateDesktop.</summary>
	[Flags]
	public enum CreateDesktopFlags
	{
		/// <summary>Enables processes running in other accounts on the desktop to set hooks in this process.</summary>
		DF_ALLOWOTHERACCOUNTHOOK = 0x0001
	}

	/// <summary>Flags used by CreateWindowStation.</summary>
	[Flags]
	public enum CreateWindowStationFlags
	{
		/// <summary>
		/// If used and the window station already exists, the call fails. If this flag is not specified and the window station already
		/// exists, the function succeeds and returns a new handle to the existing window station.
		/// </summary>
		CWF_CREATE_ONLY = 0x00000001,
	}

	/// <summary>The information to be retrieved by GetUserObjectInformation or set by SetUserObjectInformation.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "64f7361d-1a94-4d5b-86f1-a2a21737668a")]
	public enum UserObjectInformationType
	{
		/// <summary>The handle flags. The pvInfo parameter must point to a USEROBJECTFLAGS structure.</summary>
		[CorrespondingType(typeof(USEROBJECTFLAGS))]
		UOI_FLAGS = 1,

		/// <summary>
		/// The size of the desktop heap, in KB, as a ULONG value. The hObj parameter must be a handle to a desktop object, otherwise,
		/// the function fails.
		/// <para>Windows Server 2003 and Windows XP/2000: This value is not supported.</para>
		/// </summary>
		[CorrespondingType(typeof(uint))]
		UOI_HEAPSIZE = 5,

		/// <summary>
		/// TRUE if the hObj parameter is a handle to the desktop object that is receiving input from the user. FALSE otherwise.
		/// <para>Windows Server 2003 and Windows XP/2000: This value is not supported.</para>
		/// </summary>
		[CorrespondingType(typeof(uint))]
		UOI_IO = 6,

		/// <summary>The name of the object, as a string.</summary>
		[CorrespondingType(typeof(string))]
		UOI_NAME = 2,

		/// <summary>The type name of the object, as a string.</summary>
		[CorrespondingType(typeof(string))]
		UOI_TYPE = 3,

		/// <summary>
		/// The SID structure that identifies the user that is currently associated with the specified object. If no user is associated
		/// with the object, the value returned in the buffer pointed to by lpnLengthNeeded is zero. Note that SID is a variable length
		/// structure. You will usually make a call to GetUserObjectInformation to determine the length of the SID before retrieving its value.
		/// </summary>
		[CorrespondingType(typeof(IntPtr))]
		UOI_USER_SID = 4,
	}

	/// <summary>
	/// <para>Closes an open handle to a desktop object.</para>
	/// </summary>
	/// <param name="hDesktop">
	/// <para>
	/// A handle to the desktop to be closed. This can be a handle returned by the CreateDesktop, OpenDesktop, or OpenInputDesktop
	/// functions. Do not specify the handle returned by the GetThreadDesktop function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CloseDesktop</c> function will fail if any thread in the calling process is using the specified desktop handle or if the
	/// handle refers to the initial desktop of the calling process.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-closedesktop BOOL CloseDesktop( HDESK hDesktop );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "861e57b2-061c-4598-ad38-6aef7b79ca54")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseDesktop(HDESK hDesktop);

	/// <summary>
	/// <para>Closes an open window station handle.</para>
	/// </summary>
	/// <param name="hWinSta">
	/// <para>
	/// A handle to the window station to be closed. This handle is returned by the CreateWindowStation or OpenWindowStation function. Do
	/// not specify the handle returned by the GetProcessWindowStation function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para><c>Windows Server 2003 and Windows XP/2000:</c> This function does not set the last error code on failure.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CloseWindowStation</c> function will fail if the handle being closed is for the window station assigned to the calling process.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-closewindowstation BOOL CloseWindowStation( HWINSTA
	// hWinSta );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "417cb01b-c206-4b5b-9516-94e5d90717f4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseWindowStation(HWINSTA hWinSta);

	/// <summary>
	/// <para>
	/// Creates a new desktop, associates it with the current window station of the calling process, and assigns it to the calling
	/// thread. The calling process must have an associated window station, either assigned by the system at process creation time or set
	/// by the SetProcessWindowStation function.
	/// </para>
	/// <para>To specify the size of the heap for the desktop, use the CreateDesktopEx function.</para>
	/// </summary>
	/// <param name="lpszDesktop">
	/// <para>The name of the desktop to be created. Desktop names are case-insensitive and may not contain backslash characters ().</para>
	/// </param>
	/// <param name="lpszDevice">
	/// <para>Reserved; must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="pDevmode">
	/// <para>Reserved; must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DF_ALLOWOTHERACCOUNTHOOK 0x0001</term>
	/// <term>Enables processes running in other accounts on the desktop to set hooks in this process.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>The access to the desktop. For a list of values, see Desktop Security and Access Rights.</para>
	/// <para>
	/// This parameter must include the <c>DESKTOP_CREATEWINDOW</c> access right, because internally <c>CreateDesktop</c> uses the handle
	/// to create a window.
	/// </para>
	/// </param>
	/// <param name="lpsa">
	/// <para>
	/// A pointer to a SECURITY_ATTRIBUTES structure that determines whether the returned handle can be inherited by child processes. If
	/// lpsa is NULL, the handle cannot be inherited.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new desktop. If this parameter is
	/// NULL, the desktop inherits its security descriptor from the parent window station.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to the newly created desktop. If the specified desktop already exists, the
	/// function succeeds and returns a handle to the existing desktop. When you are finished using the handle, call the CloseDesktop
	/// function to close it.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the dwDesiredAccess parameter specifies the <c>READ_CONTROL</c>, <c>WRITE_DAC</c>, or <c>WRITE_OWNER</c> standard access
	/// rights, you must also request the <c>DESKTOP_READOBJECTS</c> and <c>DESKTOP_WRITEOBJECTS</c> access rights.
	/// </para>
	/// <para>
	/// The number of desktops that can be created is limited by the size of the system desktop heap, which is 48 MB. Desktop objects use
	/// the heap to store resources. You can increase the number of desktops that can be created by reducing the default heap reserved
	/// for each desktop in the interactive window station. This value is specified in the "SharedSection" substring of the following
	/// registry value: <c>HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\SubSystems\Windows</c>. The default data
	/// for this registry value is as follows:
	/// </para>
	/// <para>
	/// "%SystemRoot%\system32\csrss.exe ObjectDirectory=\Windows SharedSection=1024,3072,512 Windows=On SubSystemType=Windows
	/// ServerDll=basesrv,1 ServerDll=winsrv:UserServerDllInitialization,3 ServerDll=winsrv:ConServerDllInitialization,2
	/// ProfileControl=Off MaxRequestThreads=16"
	/// </para>
	/// <para>The values for the "SharedSection" substring are described as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The first "SharedSection" value is the size of the shared heap common to all desktops, in kilobytes.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The second "SharedSection" value is the size of the desktop heap needed for each desktop that is created in the interactive
	/// window station, WinSta0, in kilobytes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The third "SharedSection" value is the size of the desktop heap needed for each desktop that is created in a noninteractive
	/// window station, in kilobytes.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createdesktopa HDESK CreateDesktopA( LPCSTR lpszDesktop,
	// LPCSTR lpszDevice, DEVMODEA *pDevmode, DWORD dwFlags, ACCESS_MASK dwDesiredAccess, LPSECURITY_ATTRIBUTES lpsa );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "c6ed40c5-13a9-4697-a727-730adc6a912d")]
	public static extern SafeHDESK CreateDesktop(string lpszDesktop, [Optional] string? lpszDevice, [Optional] IntPtr pDevmode, CreateDesktopFlags dwFlags, ACCESS_MASK dwDesiredAccess, SECURITY_ATTRIBUTES lpsa);

	/// <summary>
	/// <para>
	/// Creates a new desktop with the specified heap, associates it with the current window station of the calling process, and assigns
	/// it to the calling thread. The calling process must have an associated window station, either assigned by the system at process
	/// creation time or set by the SetProcessWindowStation function.
	/// </para>
	/// </summary>
	/// <param name="lpszDesktop">
	/// <para>The name of the desktop to be created. Desktop names are case-insensitive and may not contain backslash characters ().</para>
	/// </param>
	/// <param name="lpszDevice">
	/// <para>This parameter is reserved and must be NULL.</para>
	/// </param>
	/// <param name="pDevmode">
	/// <para>This parameter is reserved and must be NULL.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DF_ALLOWOTHERACCOUNTHOOK 0x0001</term>
	/// <term>Enables processes running in other accounts on the desktop to set hooks in this process.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>The requested access to the desktop. For a list of values, see Desktop Security and Access Rights.</para>
	/// <para>
	/// This parameter must include the DESKTOP_CREATEWINDOW access right, because internally CreateDesktop uses the handle to create a window.
	/// </para>
	/// </param>
	/// <param name="lpsa">
	/// <para>
	/// A pointer to a SECURITY_ATTRIBUTES structure that determines whether the returned handle can be inherited by child processes. If
	/// lpsa is NULL, the handle cannot be inherited.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new desktop. If this parameter is
	/// NULL, the desktop inherits its security descriptor from the parent window station.
	/// </para>
	/// </param>
	/// <param name="ulHeapSize">
	/// <para>The size of the desktop heap, in kilobytes.</para>
	/// </param>
	/// <param name="pvoid">
	/// <para>This parameter is reserved and must be NULL.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to the newly created desktop. If the specified desktop already exists, the
	/// function succeeds and returns a handle to the existing desktop. When you are finished using the handle, call the CloseDesktop
	/// function to close it.
	/// </para>
	/// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the dwDesiredAccess parameter specifies the READ_CONTROL, WRITE_DAC, or WRITE_OWNER standard access rights, you must also
	/// request the DESKTOP_READOBJECTS and DESKTOP_WRITEOBJECTS access rights.
	/// </para>
	/// <para>
	/// The number of desktops that can be created is limited by the size of the system desktop heap. Desktop objects use the heap to
	/// store resources. You can increase the number of desktops that can be created by increasing the size of the desktop heap or by
	/// reducing the default heap reserved for each desktop in the interactive window station. This value is specified in the
	/// SharedSection substring of the following registry value: <c>HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session
	/// Manager\SubSystems\Windows</c>. The default data for this registry value is as follows:
	/// </para>
	/// <para>
	/// %SystemRoot%\system32\csrss.exe ObjectDirectory=\Windows SharedSection=1024,3072,512 Windows=On SubSystemType=Windows
	/// ServerDll=basesrv,1 ServerDll=winsrv:UserServerDllInitialization,3 ServerDll=winsrv:ConServerDllInitialization,2
	/// ProfileControl=Off MaxRequestThreads=16
	/// </para>
	/// <para>The values for the SharedSection substring are described as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The first SharedSection value is the size of the shared heap common to all desktops, in kilobytes.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The second SharedSection value is the size of the desktop heap needed for each desktop that is created in the interactive window
	/// station, WinSta0, in kilobytes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The third SharedSection value is the size of the desktop heap needed for each desktop that is created in a noninteractive window
	/// station, in kilobytes.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The default size of the desktop heap depends on factors such as hardware architecture. To retrieve the size of the desktop heap,
	/// call the GetUserObjectInformation function with UOI_HEAPSIZE.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createdesktopexa HDESK CreateDesktopExA( LPCSTR
	// lpszDesktop, LPCSTR lpszDevice, DEVMODEA *pDevmode, DWORD dwFlags, ACCESS_MASK dwDesiredAccess, LPSECURITY_ATTRIBUTES lpsa, ULONG
	// ulHeapSize, PVOID pvoid );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "2fe8859d-1fe3-4f44-aa97-58e61779c4cc")]
	public static extern SafeHDESK CreateDesktopEx(string lpszDesktop, [Optional] string? lpszDevice, [Optional] IntPtr pDevmode, CreateDesktopFlags dwFlags, ACCESS_MASK dwDesiredAccess, SECURITY_ATTRIBUTES lpsa, uint ulHeapSize, [Optional] IntPtr pvoid);

	/// <summary>
	/// <para>Creates a window station object, associates it with the calling process, and assigns it to the current session.</para>
	/// </summary>
	/// <param name="lpwinsta">
	/// <para>
	/// The name of the window station to be created. Window station names are case-insensitive and cannot contain backslash characters
	/// (). Only members of the Administrators group are allowed to specify a name. If lpwinsta is <c>NULL</c> or an empty string, the
	/// system forms a window station name using the logon session identifier for the calling process. To get this name, call the
	/// GetUserObjectInformation function.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// If this parameter is <c>CWF_CREATE_ONLY</c> and the window station already exists, the call fails. If this flag is not specified
	/// and the window station already exists, the function succeeds and returns a new handle to the existing window station.
	/// </para>
	/// <para><c>Windows XP/2000:</c> This parameter is reserved and must be zero.</para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>
	/// The type of access the returned handle has to the window station. In addition, you can specify any of the standard access rights,
	/// such as <c>READ_CONTROL</c> or <c>WRITE_DAC</c>, and a combination of the window station-specific access rights. For more
	/// information, see Window Station Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="lpsa">
	/// <para>
	/// A pointer to a SECURITY_ATTRIBUTES structure that determines whether the returned handle can be inherited by child processes. If
	/// lpsa is <c>NULL</c>, the handle cannot be inherited.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new window station. If lpsa is
	/// <c>NULL</c>, the window station (and any desktops created within the window) gets a security descriptor that grants
	/// <c>GENERIC_ALL</c> access to all users.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to the newly created window station. If the specified window station
	/// already exists, the function succeeds and returns a handle to the existing window station.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>After you are done with the handle, you must call CloseWindowStation to free the handle.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createwindowstationa HWINSTA CreateWindowStationA( LPCSTR
	// lpwinsta, DWORD dwFlags, ACCESS_MASK dwDesiredAccess, LPSECURITY_ATTRIBUTES lpsa );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "c1aee546-decd-46c9-8d02-d6792f5a6a0d")]
	public static extern SafeHWINSTA CreateWindowStation(string? lpwinsta, CreateWindowStationFlags dwFlags, ACCESS_MASK dwDesiredAccess, SECURITY_ATTRIBUTES lpsa);

	/// <summary>
	/// <para>
	/// Enumerates all desktops associated with the specified window station of the calling process. The function passes the name of each
	/// desktop, in turn, to an application-defined callback function.
	/// </para>
	/// </summary>
	/// <param name="hwinsta">
	/// <para>
	/// A handle to the window station whose desktops are to be enumerated. This handle is returned by the CreateWindowStation,
	/// GetProcessWindowStation, or OpenWindowStation function, and must have the WINSTA_ENUMDESKTOPS access right. For more information,
	/// see Window Station Security and Access Rights.
	/// </para>
	/// <para>If this parameter is NULL, the current window station is used.</para>
	/// </param>
	/// <param name="lpEnumFunc">
	/// <para>A pointer to an application-defined EnumDesktopProc callback function.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>An application-defined value to be passed to the callback function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns the nonzero value returned by the callback function that was pointed to by lpEnumFunc.</para>
	/// <para>
	/// If the function is unable to perform the enumeration, the return value is zero. Call GetLastError to get extended error information.
	/// </para>
	/// <para>
	/// If the callback function fails, the return value is zero. The callback function can call SetLastError to set an error code for
	/// the caller to retrieve by calling GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>EnumDesktops</c> function enumerates only those desktops for which the calling process has the DESKTOP_ENUMERATE access
	/// right. For more information, see Desktop Security and Access Rights.
	/// </para>
	/// <para>
	/// The <c>EnumDesktops</c> function repeatedly invokes the lpEnumFunc callback function until the last desktop is enumerated or the
	/// callback function returns FALSE.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enumdesktopsa BOOL EnumDesktopsA( HWINSTA hwinsta,
	// DESKTOPENUMPROCA lpEnumFunc, LPARAM lParam );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "3e900b34-2c60-4281-881f-13a746674aec")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumDesktops([Optional] HWINSTA hwinsta, EnumDesktopProc lpEnumFunc, IntPtr lParam);

	/// <summary>Enumerates all desktops associated with the specified window station of the calling process.</summary>
	/// <param name="hwinsta">
	/// <para>
	/// A handle to the window station whose desktops are to be enumerated. This handle is returned by the CreateWindowStation,
	/// GetProcessWindowStation, or OpenWindowStation function, and must have the WINSTA_ENUMDESKTOPS access right. For more information,
	/// see Window Station Security and Access Rights.
	/// </para>
	/// <para>If this parameter is NULL, the current window station is used.</para>
	/// </param>
	/// <returns>The list of desktop names in the specified window station of the calling process.</returns>
	/// <remarks>
	/// <para>
	/// The <c>EnumDesktops</c> function enumerates only those desktops for which the calling process has the DESKTOP_ENUMERATE access
	/// right. For more information, see Desktop Security and Access Rights.
	/// </para>
	/// </remarks>
	public static IEnumerable<string> EnumDesktops([Optional] HWINSTA hwinsta)
	{
		var ret = new List<string>();
		if (!EnumDesktops(hwinsta, EnumProc, IntPtr.Zero))
			Win32Error.ThrowLastError();
		return ret;

		bool EnumProc(string desktopName, IntPtr lParam)
		{
			ret.Add(desktopName);
			return true;
		}
	}

	/// <summary>
	/// <para>
	/// Enumerates all top-level windows associated with the specified desktop. It passes the handle to each window, in turn, to an
	/// application-defined callback function.
	/// </para>
	/// </summary>
	/// <param name="hDesktop">
	/// <para>
	/// A handle to the desktop whose top-level windows are to be enumerated. This handle is returned by the CreateDesktop,
	/// GetThreadDesktop, OpenDesktop, or OpenInputDesktop function, and must have the <c>DESKTOP_READOBJECTS</c> access right. For more
	/// information, see Desktop Security and Access Rights.
	/// </para>
	/// <para>If this parameter is NULL, the current desktop is used.</para>
	/// </param>
	/// <param name="lpfn">
	/// <para>A pointer to an application-defined EnumWindowsProc callback function.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>An application-defined value to be passed to the callback function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function fails or is unable to perform the enumeration, the return value is zero.</para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// <para>You must ensure that the callback function sets SetLastError if it fails.</para>
	/// <para><c>Windows Server 2003 and Windows XP/2000:</c> If there are no windows on the desktop, GetLastError returns <c>ERROR_INVALID_HANDLE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>EnumDesktopWindows</c> function repeatedly invokes the lpfn callback function until the last top-level window is
	/// enumerated or the callback function returns <c>FALSE</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enumdesktopwindows BOOL EnumDesktopWindows( HDESK
	// hDesktop, WNDENUMPROC lpfn, LPARAM lParam );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "b399ff19-e2e5-4509-8bb5-9647734881b3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumDesktopWindows([Optional] HDESK hDesktop, EnumWindowsProc lpfn, IntPtr lParam);

	/// <summary>
	/// <para>
	/// Enumerates all window stations in the current session. The function passes the name of each window station, in turn, to an
	/// application-defined callback function.
	/// </para>
	/// </summary>
	/// <param name="lpEnumFunc">
	/// <para>A pointer to an application-defined EnumWindowStationProc callback function.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>An application-defined value to be passed to the callback function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns the nonzero value returned by the callback function that was pointed to by lpEnumFunc.</para>
	/// <para>
	/// If the function is unable to perform the enumeration, the return value is zero. Call GetLastError to get extended error information.
	/// </para>
	/// <para>
	/// If the callback function fails, the return value is zero. The callback function can call SetLastError to set an error code for
	/// the caller to retrieve by calling GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>EnumWindowStations</c> function enumerates only those window stations for which the calling process has the
	/// WINSTA_ENUMERATE access right. For more information, see Window Station Security and Access Rights.
	/// </para>
	/// <para>
	/// <c>EnumWindowStations</c> repeatedly invokes the lpEnumFunc callback function until the last window station is enumerated or the
	/// callback function returns FALSE.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enumwindowstationsa BOOL EnumWindowStationsA(
	// WINSTAENUMPROCA lpEnumFunc, LPARAM lParam );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "418d4d6a-9e4d-4fe3-8e1b-398c732c6e23")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumWindowStations(EnumWindowStationProc lpEnumFunc, IntPtr lParam);

	/// <summary>
	/// <para>Retrieves a handle to the current window station for the calling process.</para>
	/// </summary>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the window station.</para>
	/// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The system associates a window station with a process when the process is created. A process can use the SetProcessWindowStation
	/// function to change its window station.
	/// </para>
	/// <para>
	/// The calling process can use the returned handle in calls to the GetUserObjectInformation, GetUserObjectSecurity,
	/// SetUserObjectInformation, and SetUserObjectSecurity functions.
	/// </para>
	/// <para>Do not close the handle returned by this function.</para>
	/// <para>
	/// A service application is created with an associated window station and desktop, so there is no need to call a USER or GDI
	/// function to connect the service to a window station and desktop.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getprocesswindowstation HWINSTA GetProcessWindowStation( );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "f8929122-d277-4260-b2a7-5e76eb3ca876")]
	// SafeHWINSTA not used as this handle should not be closed.
	public static extern HWINSTA GetProcessWindowStation();

	/// <summary>
	/// <para>Retrieves a handle to the desktop assigned to the specified thread.</para>
	/// </summary>
	/// <param name="dwThreadId">
	/// <para>The thread identifier. The GetCurrentThreadId and CreateProcess functions return thread identifiers.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to the desktop associated with the specified thread. You do not need to
	/// call the CloseDesktop function to close the returned handle.
	/// </para>
	/// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The system associates a desktop with a thread when that thread is created. A thread can use the SetThreadDesktop function to
	/// change its desktop. The desktop associated with a thread must be on the window station associated with the thread's process.
	/// </para>
	/// <para>
	/// The calling process can use the returned handle in calls to the GetUserObjectInformation, GetUserObjectSecurity,
	/// SetUserObjectInformation, and SetUserObjectSecurity functions.
	/// </para>
	/// <para>
	/// A service application is created with an associated window station and desktop, so there is no need to call a USER or GDI
	/// function to connect the service to a window station and desktop.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getthreaddesktop HDESK GetThreadDesktop( DWORD dwThreadId );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "51eec935-43c7-495b-b1fc-2bd5ba1e0090")]
	// SafeHDESK not used as this handle should not be closed.
	public static extern HDESK GetThreadDesktop(uint dwThreadId);

	/// <summary>
	/// <para>Retrieves information about the specified window station or desktop object.</para>
	/// </summary>
	/// <param name="hObj">
	/// <para>
	/// A handle to the window station or desktop object. This handle is returned by the CreateWindowStation, OpenWindowStation,
	/// CreateDesktop, or OpenDesktop function.
	/// </para>
	/// </param>
	/// <param name="nIndex">
	/// <para>The information to be retrieved. The parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>UOI_FLAGS 1</term>
	/// <term>The handle flags. The pvInfo parameter must point to a USEROBJECTFLAGS structure.</term>
	/// </item>
	/// <item>
	/// <term>UOI_HEAPSIZE 5</term>
	/// <term>
	/// The size of the desktop heap, in KB, as a ULONG value. The hObj parameter must be a handle to a desktop object, otherwise, the
	/// function fails. Windows Server 2003 and Windows XP/2000: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>UOI_IO 6</term>
	/// <term>
	/// TRUE if the hObj parameter is a handle to the desktop object that is receiving input from the user. FALSE otherwise. Windows
	/// Server 2003 and Windows XP/2000: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>UOI_NAME 2</term>
	/// <term>The name of the object, as a string.</term>
	/// </item>
	/// <item>
	/// <term>UOI_TYPE 3</term>
	/// <term>The type name of the object, as a string.</term>
	/// </item>
	/// <item>
	/// <term>UOI_USER_SID 4</term>
	/// <term>
	/// The SID structure that identifies the user that is currently associated with the specified object. If no user is associated with
	/// the object, the value returned in the buffer pointed to by lpnLengthNeeded is zero. Note that SID is a variable length structure.
	/// You will usually make a call to GetUserObjectInformation to determine the length of the SID before retrieving its value.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvInfo">
	/// <para>A pointer to a buffer to receive the object information.</para>
	/// </param>
	/// <param name="nLength">
	/// <para>The size of the buffer pointed to by the pvInfo parameter, in bytes.</para>
	/// </param>
	/// <param name="lpnLengthNeeded">
	/// <para>
	/// A pointer to a variable receiving the number of bytes required to store the requested information. If this variable's value is
	/// greater than the value of the nLength parameter when the function returns, the function returns FALSE, and none of the
	/// information is copied to the pvInfo buffer. If the value of the variable pointed to by lpnLengthNeeded is less than or equal to
	/// the value of nLength, the entire information block is copied.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getuserobjectinformationa BOOL GetUserObjectInformationA(
	// HANDLE hObj, int nIndex, PVOID pvInfo, DWORD nLength, LPDWORD lpnLengthNeeded );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "64f7361d-1a94-4d5b-86f1-a2a21737668a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetUserObjectInformation(IntPtr hObj, UserObjectInformationType nIndex, IntPtr pvInfo, uint nLength, out uint lpnLengthNeeded);

	/// <summary>
	/// <para>Retrieves information about the specified window station or desktop object.</para>
	/// </summary>
	/// <param name="hObj">
	/// <para>
	/// A handle to the window station or desktop object. This handle is returned by the CreateWindowStation, OpenWindowStation,
	/// CreateDesktop, or OpenDesktop function.
	/// </para>
	/// </param>
	/// <param name="nIndex">
	/// <para>The information to be retrieved. The parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>UOI_FLAGS 1</term>
	/// <term>The handle flags. The pvInfo parameter must point to a USEROBJECTFLAGS structure.</term>
	/// </item>
	/// <item>
	/// <term>UOI_HEAPSIZE 5</term>
	/// <term>
	/// The size of the desktop heap, in KB, as a ULONG value. The hObj parameter must be a handle to a desktop object, otherwise, the
	/// function fails. Windows Server 2003 and Windows XP/2000: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>UOI_IO 6</term>
	/// <term>
	/// TRUE if the hObj parameter is a handle to the desktop object that is receiving input from the user. FALSE otherwise. Windows
	/// Server 2003 and Windows XP/2000: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>UOI_NAME 2</term>
	/// <term>The name of the object, as a string.</term>
	/// </item>
	/// <item>
	/// <term>UOI_TYPE 3</term>
	/// <term>The type name of the object, as a string.</term>
	/// </item>
	/// <item>
	/// <term>UOI_USER_SID 4</term>
	/// <term>
	/// The SID structure that identifies the user that is currently associated with the specified object. If no user is associated with
	/// the object, the value returned in the buffer pointed to by lpnLengthNeeded is zero. Note that SID is a variable length structure.
	/// You will usually make a call to GetUserObjectInformation to determine the length of the SID before retrieving its value.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>The value specified by <typeparamref name="T"/> and <paramref name="nIndex"/>.</returns>
	[PInvokeData("winuser.h", MSDNShortId = "64f7361d-1a94-4d5b-86f1-a2a21737668a")]
	public static T GetUserObjectInformation<T>(IntPtr hObj, UserObjectInformationType nIndex)
	{
		if (!CorrespondingTypeAttribute.CanGet(nIndex, typeof(T))) throw new ArgumentException("Type mismatch");
		GetUserObjectInformation(hObj, nIndex, IntPtr.Zero, 0, out var sz);
		var mem = new SafeHGlobalHandle((int)sz);
		if (!GetUserObjectInformation(hObj, nIndex, (IntPtr)mem, sz, out var _))
			Win32Error.ThrowLastError();
		return typeof(T) == typeof(string) ? (T)(object)mem.ToString(-1)! : mem.ToStructure<T>()!;
	}

	/// <summary>
	/// <para>Opens the specified desktop object.</para>
	/// </summary>
	/// <param name="lpszDesktop">
	/// <para>The name of the desktop to be opened. Desktop names are case-insensitive.</para>
	/// <para>This desktop must belong to the current window station.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DF_ALLOWOTHERACCOUNTHOOK 0x0001</term>
	/// <term>Allows processes running in other accounts on the desktop to set hooks in this process.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="fInherit">
	/// <para>
	/// If this value is <c>TRUE</c>, processes created by this process will inherit the handle. Otherwise, the processes do not inherit
	/// this handle.
	/// </para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>The access to the desktop. For a list of access rights, see Desktop Security and Access Rights.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to the opened desktop. When you are finished using the handle, call the
	/// CloseDesktop function to close it.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The calling process must have an associated window station, either assigned by the system at process creation time or set by the
	/// SetProcessWindowStation function.
	/// </para>
	/// <para>
	/// If the dwDesiredAccess parameter specifies the <c>READ_CONTROL</c>, <c>WRITE_DAC</c>, or <c>WRITE_OWNER</c> standard access
	/// rights, you must also request the <c>DESKTOP_READOBJECTS</c> and <c>DESKTOP_WRITEOBJECTS</c> access rights.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-opendesktopa HDESK OpenDesktopA( LPCSTR lpszDesktop, DWORD
	// dwFlags, BOOL fInherit, ACCESS_MASK dwDesiredAccess );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "7f805f47-1737-4f4b-a74a-9c1423b65f2c")]
	public static extern SafeHDESK OpenDesktop(string lpszDesktop, CreateDesktopFlags dwFlags, [MarshalAs(UnmanagedType.Bool)] bool fInherit, ACCESS_MASK dwDesiredAccess);

	/// <summary>
	/// <para>Opens the desktop that receives user input.</para>
	/// </summary>
	/// <param name="dwFlags">
	/// <para>This parameter can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DF_ALLOWOTHERACCOUNTHOOK 0x0001</term>
	/// <term>Allows processes running in other accounts on the desktop to set hooks in this process.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="fInherit">
	/// <para>
	/// If this value is <c>TRUE</c>, processes created by this process will inherit the handle. Otherwise, the processes do not inherit
	/// this handle.
	/// </para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>The access to the desktop. For a list of access rights, see Desktop Security and Access Rights.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a handle to the desktop that receives user input. When you are finished using the
	/// handle, call the CloseDesktop function to close it.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The calling process must have an associated window station, either assigned by the system when the process is created, or set by
	/// the SetProcessWindowStation function. The window station associated with the calling process must be capable of receiving input.
	/// </para>
	/// <para>
	/// If the calling process is running in a disconnected session, the function returns a handle to the desktop that becomes active
	/// when the user restores the connection.
	/// </para>
	/// <para>An application can use the SwitchDesktop function to change the input desktop.</para>
	/// <para>
	/// If the dwDesiredAccess parameter specifies the <c>READ_CONTROL</c>, <c>WRITE_DAC</c>, or <c>WRITE_OWNER</c> standard access
	/// rights, you must also request the <c>DESKTOP_READOBJECTS</c> and <c>DESKTOP_WRITEOBJECTS</c> access rights.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-openinputdesktop HDESK OpenInputDesktop( DWORD dwFlags,
	// BOOL fInherit, ACCESS_MASK dwDesiredAccess );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "023d421e-bf32-4e08-b5b3-b7b2ca6c4e00")]
	public static extern SafeHDESK OpenInputDesktop(CreateDesktopFlags dwFlags, [MarshalAs(UnmanagedType.Bool)] bool fInherit, ACCESS_MASK dwDesiredAccess);

	/// <summary>
	/// <para>Opens the specified window station.</para>
	/// </summary>
	/// <param name="lpszWinSta">
	/// <para>The name of the window station to be opened. Window station names are case-insensitive.</para>
	/// <para>This window station must belong to the current session.</para>
	/// </param>
	/// <param name="fInherit">
	/// <para>
	/// If this value is <c>TRUE</c>, processes created by this process will inherit the handle. Otherwise, the processes do not inherit
	/// this handle.
	/// </para>
	/// </param>
	/// <param name="dwDesiredAccess">
	/// <para>The access to the window station. For a list of access rights, see Window Station Security and Access Rights.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the handle to the specified window station.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>After you are done with the handle, you must call CloseWindowStation to free the handle.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-openwindowstationa HWINSTA OpenWindowStationA( LPCSTR
	// lpszWinSta, BOOL fInherit, ACCESS_MASK dwDesiredAccess );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "78ee7100-1bad-4c2d-b923-c5e67191bd41")]
	public static extern SafeHWINSTA OpenWindowStation(string lpszWinSta, [MarshalAs(UnmanagedType.Bool)] bool fInherit, ACCESS_MASK dwDesiredAccess);

	/// <summary>
	/// <para>
	/// Assigns the specified window station to the calling process. This enables the process to access objects in the window station
	/// such as desktops, the clipboard, and global atoms. All subsequent operations on the window station use the access rights granted
	/// to hWinSta.
	/// </para>
	/// </summary>
	/// <param name="hWinSta">
	/// <para>
	/// A handle to the window station. This can be a handle returned by the CreateWindowStation, OpenWindowStation, or
	/// GetProcessWindowStation function.
	/// </para>
	/// <para>This window station must be associated with the current session.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setprocesswindowstation BOOL SetProcessWindowStation(
	// HWINSTA hWinSta );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "d64814a7-945c-4e73-a977-5f696d60610e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetProcessWindowStation(HWINSTA hWinSta);

	/// <summary>
	/// <para>
	/// Assigns the specified desktop to the calling thread. All subsequent operations on the desktop use the access rights granted to
	/// the desktop.
	/// </para>
	/// </summary>
	/// <param name="hDesktop">
	/// <para>
	/// A handle to the desktop to be assigned to the calling thread. This handle is returned by the CreateDesktop, GetThreadDesktop,
	/// OpenDesktop, or OpenInputDesktop function.
	/// </para>
	/// <para>This desktop must be associated with the current window station for the process.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SetThreadDesktop</c> function will fail if the calling thread has any windows or hooks on its current desktop (unless the
	/// hDesktop parameter is a handle to the current desktop).
	/// </para>
	/// <para>
	/// <c>Warning</c> There is a significant security risk for any service that opens a window on the interactive desktop. By opening a
	/// desktop window, a service makes itself vulnerable to attack from the logged-on user, whose application could send malicious
	/// messages to the service's desktop window and affect its ability to function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setthreaddesktop BOOL SetThreadDesktop( HDESK hDesktop );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "619c591f-54b7-4b61-aa07-fc57e05ee37a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetThreadDesktop(HDESK hDesktop);

	/// <summary>
	/// <para>Sets information about the specified window station or desktop object.</para>
	/// </summary>
	/// <param name="hObj">
	/// <para>
	/// A handle to the window station, desktop object or a current process pseudo handle. This handle can be returned by the
	/// CreateWindowStation, OpenWindowStation, CreateDesktop, OpenDesktop or GetCurrentProcess function.
	/// </para>
	/// </param>
	/// <param name="nIndex">
	/// <para>The object information to be set. This parameter can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>UOI_FLAGS 1</term>
	/// <term>Sets the object's handle flags. The pvInfo parameter must point to a USEROBJECTFLAGS structure.</term>
	/// </item>
	/// <item>
	/// <term>UOI_TIMERPROC_EXCEPTION_SUPPRESSION 7</term>
	/// <term>
	/// Sets the exception handling behavior when calling TimerProc. hObj must be the process handle returned by the GetCurrentProcess
	/// function. The pvInfo parameter must point to a BOOL. If TRUE, Windows will enclose its calls to TimerProc with an exception
	/// handler that consumes and discards all exceptions. This has been the default behavior since Windows 2000, although that may
	/// change in future versions of Windows. If pvInfo points to FALSE, Windows will not enclose its calls to TimerProc with an
	/// exception handler. A setting of FALSE is recommended. Otherwise, the application could behave unpredictably, and could be more
	/// vulnerable to security exploits.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvInfo">
	/// <para>A pointer to a buffer containing the object information, or a BOOL.</para>
	/// </param>
	/// <param name="nLength">
	/// <para>The size of the information contained in the buffer pointed to by pvInfo, in bytes.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setuserobjectinformationa BOOL SetUserObjectInformationA(
	// HANDLE hObj, int nIndex, PVOID pvInfo, DWORD nLength );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "42ce6946-1659-41a3-8ba7-21588583b4bd")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetUserObjectInformation(IntPtr hObj, UserObjectInformationType nIndex, IntPtr pvInfo, uint nLength);

	/// <summary>Sets information about the specified window station or desktop object.</summary>
	/// <typeparam name="T">The type being set.</typeparam>
	/// <param name="hObj">
	/// A handle to the window station, desktop object or a current process pseudo handle. This handle can be returned by the
	/// CreateWindowStation, OpenWindowStation, CreateDesktop, OpenDesktop or GetCurrentProcess function.
	/// </param>
	/// <param name="nIndex">
	/// <para>The object information to be set. This parameter can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>UOI_FLAGS 1</term>
	/// <term>Sets the object's handle flags. The pvInfo parameter must point to a USEROBJECTFLAGS structure.</term>
	/// </item>
	/// <item>
	/// <term>UOI_TIMERPROC_EXCEPTION_SUPPRESSION 7</term>
	/// <term>
	/// Sets the exception handling behavior when calling TimerProc. hObj must be the process handle returned by the GetCurrentProcess
	/// function. The pvInfo parameter must point to a BOOL. If TRUE, Windows will enclose its calls to TimerProc with an exception
	/// handler that consumes and discards all exceptions. This has been the default behavior since Windows 2000, although that may
	/// change in future versions of Windows. If pvInfo points to FALSE, Windows will not enclose its calls to TimerProc with an
	/// exception handler. A setting of FALSE is recommended. Otherwise, the application could behave unpredictably, and could be more
	/// vulnerable to security exploits.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="info">A buffer containing the object information, or a BOOL.</param>
	/// <exception cref="ArgumentException">Type mismatch</exception>
	public static void SetUserObjectInformation<T>(IntPtr hObj, UserObjectInformationType nIndex, T info)
	{
		if (!CorrespondingTypeAttribute.CanSet(nIndex, typeof(T))) throw new ArgumentException("Type mismatch");
		var mem = typeof(T) == typeof(string) ? new SafeHGlobalHandle(info?.ToString() ?? "") : SafeHGlobalHandle.CreateFromStructure(info);
		if (!SetUserObjectInformation(hObj, nIndex, (IntPtr)mem, (uint)mem.Size))
			Win32Error.ThrowLastError();
	}

	/// <summary>
	/// <para>
	/// Makes the specified desktop visible and activates it. This enables the desktop to receive input from the user. The calling
	/// process must have DESKTOP_SWITCHDESKTOP access to the desktop for the <c>SwitchDesktop</c> function to succeed.
	/// </para>
	/// </summary>
	/// <param name="hDesktop">
	/// <para>A handle to the desktop. This handle is returned by the CreateDesktop and OpenDesktop functions.</para>
	/// <para>This desktop must be associated with the current window station for the process.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. However,
	/// <c>SwitchDesktop</c> only sets the last error for the following cases:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>When the desktop belongs to an invisible window station</term>
	/// </item>
	/// <item>
	/// <term>
	/// When hDesktop is an invalid handle, refers to a destroyed desktop, or belongs to a different session than that of the calling process
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SwitchDesktop</c> function fails if the desktop belongs to an invisible window station. <c>SwitchDesktop</c> also fails
	/// when called from a process that is associated with a secured desktop such as the WinLogon and ScreenSaver desktops. Processes
	/// that are associated with a secured desktop include custom UserInit processes. Such calls typically fail with an "access denied" error.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-switchdesktop BOOL SwitchDesktop( HDESK hDesktop );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "401be515-ada9-42be-b8e8-4e86f513bb8d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SwitchDesktop(HDESK hDesktop);

	/// <summary>
	/// <para>Contains information about a window station or desktop handle.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-taguserobjectflags typedef struct tagUSEROBJECTFLAGS {
	// BOOL fInherit; BOOL fReserved; DWORD dwFlags; } USEROBJECTFLAGS, *PUSEROBJECTFLAGS;
	[PInvokeData("winuser.h", MSDNShortId = "5a973d45-5ff4-47e7-a927-72d3fdd61dc9")]
	[StructLayout(LayoutKind.Sequential)]
	public struct USEROBJECTFLAGS
	{
		/// <summary>
		/// <para>If this member is TRUE, new processes inherit the handle. Otherwise, the handle is not inherited.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fInherit;

		/// <summary>
		/// <para>Reserved for future use. This member must be FALSE.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fReserved;

		/// <summary>
		/// <para>For window stations, this member can contain the following window station attribute.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSF_VISIBLE 0x0001L</term>
		/// <term>Window station has visible display surfaces.</term>
		/// </item>
		/// </list>
		/// <para>For desktops, the <c>dwFlags</c> member can contain the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DF_ALLOWOTHERACCOUNTHOOK 0x0001L</term>
		/// <term>Allows processes running in other accounts on the desktop to set hooks in this process.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwFlags;
	}
}