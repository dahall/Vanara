using System.Diagnostics.CodeAnalysis;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary>
	/// <para>
	/// Creates a new process and its primary thread. The new process runs in the security context of the user represented by the
	/// specified token.
	/// </para>
	/// <para>
	/// Typically, the process that calls the <c>CreateProcessAsUser</c> function must have the <c>SE_INCREASE_QUOTA_NAME</c> privilege
	/// and may require the <c>SE_ASSIGNPRIMARYTOKEN_NAME</c> privilege if the token is not assignable. If this function fails with
	/// <c>ERROR_PRIVILEGE_NOT_HELD</c> (1314), use the CreateProcessWithLogonW function instead. <c>CreateProcessWithLogonW</c> requires
	/// no special privileges, but the specified user account must be allowed to log on interactively. Generally, it is best to use
	/// <c>CreateProcessWithLogonW</c> to create a process with alternate credentials.
	/// </para>
	/// </summary>
	/// <param name="hToken">
	/// <para>
	/// A handle to the primary token that represents a user. The handle must have the <c>TOKEN_QUERY</c>, <c>TOKEN_DUPLICATE</c>, and
	/// <c>TOKEN_ASSIGN_PRIMARY</c> access rights. For more information, see Access Rights for Access-Token Objects. The user represented
	/// by the token must have read and execute access to the application specified by the lpApplicationName or the lpCommandLine parameter.
	/// </para>
	/// <para>
	/// To get a primary token that represents the specified user, call the LogonUser function. Alternatively, you can call the
	/// DuplicateTokenEx function to convert an impersonation token into a primary token. This allows a server application that is
	/// impersonating a client to create a process that has the security context of the client.
	/// </para>
	/// <para>
	/// If hToken is a restricted version of the caller's primary token, the <c>SE_ASSIGNPRIMARYTOKEN_NAME</c> privilege is not required.
	/// If the necessary privileges are not already enabled, <c>CreateProcessAsUser</c> enables them for the duration of the call. For
	/// more information, see Running with Special Privileges.
	/// </para>
	/// <para>
	/// <c>Terminal Services:</c> The process is run in the session specified in the token. By default, this is the same session that
	/// called LogonUser. To change the session, use the SetTokenInformation function.
	/// </para>
	/// </param>
	/// <param name="lpApplicationName">
	/// <para>
	/// The name of the module to be executed. This module can be a Windows-based application. It can be some other type of module (for
	/// example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
	/// </para>
	/// <para>
	/// The string can specify the full path and file name of the module to execute or it can specify a partial name. In the case of a
	/// partial name, the function uses the current drive and current directory to complete the specification. The function will not use
	/// the search path. This parameter must include the file name extension; no default extension is assumed.
	/// </para>
	/// <para>
	/// The lpApplicationName parameter can be <c>NULL</c>. In that case, the module name must be the first white space–delimited token
	/// in the lpCommandLine string. If you are using a long file name that contains a space, use quoted strings to indicate where the
	/// file name ends and the arguments begin; otherwise, the file name is ambiguous. For example, consider the string "c:\program
	/// files\sub dir\program name". This string can be interpreted in a number of ways. The system tries to interpret the possibilities
	/// in the following order:
	/// </para>
	/// <para>
	/// <c>c:\program.exe</c><c>c:\program files\sub.exe</c><c>c:\program files\sub dir\program.exe</c><c>c:\program files\sub
	/// dir\program name.exe</c> If the executable module is a 16-bit application, lpApplicationName should be <c>NULL</c>, and the
	/// string pointed to by lpCommandLine should specify the executable module as well as its arguments. By default, all 16-bit
	/// Windows-based applications created by <c>CreateProcessAsUser</c> are run in a separate VDM (equivalent to
	/// <c>CREATE_SEPARATE_WOW_VDM</c> in CreateProcess).
	/// </para>
	/// </param>
	/// <param name="lpCommandLine">
	/// <para>
	/// The command line to be executed. The maximum length of this string is 32K characters. If lpApplicationName is <c>NULL</c>, the
	/// module name portion of lpCommandLine is limited to <c>MAX_PATH</c> characters.
	/// </para>
	/// <para>
	/// The Unicode version of this function, <c>CreateProcessAsUserW</c>, can modify the contents of this string. Therefore, this
	/// parameter cannot be a pointer to read-only memory (such as a <c>const</c> variable or a literal string). If this parameter is a
	/// constant string, the function may cause an access violation.
	/// </para>
	/// <para>
	/// The lpCommandLine parameter can be <c>NULL</c>. In that case, the function uses the string pointed to by lpApplicationName as the
	/// command line.
	/// </para>
	/// <para>
	/// If both lpApplicationName and lpCommandLine are non- <c>NULL</c>, *lpApplicationName specifies the module to execute, and
	/// *lpCommandLine specifies the command line. The new process can use GetCommandLine to retrieve the entire command line. Console
	/// processes written in C can use the argc and argv arguments to parse the command line. Because argv[0] is the module name, C
	/// programmers generally repeat the module name as the first token in the command line.
	/// </para>
	/// <para>
	/// If lpApplicationName is <c>NULL</c>, the first white space–delimited token of the command line specifies the module name. If you
	/// are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin
	/// (see the explanation for the lpApplicationName parameter). If the file name does not contain an extension, .exe is appended.
	/// Therefore, if the file name extension is .com, this parameter must include the .com extension. If the file name ends in a period
	/// (.) with no extension, or if the file name contains a path, .exe is not appended. If the file name does not contain a directory
	/// path, the system searches for the executable file in the following sequence:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>The directory from which the application loaded.</term>
	/// </item>
	/// <item>
	/// <term>The current directory for the parent process.</term>
	/// </item>
	/// <item>
	/// <term>The 32-bit Windows system directory. Use the GetSystemDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>The 16-bit Windows system directory. There is no function that obtains the path of this directory, but it is searched.</term>
	/// </item>
	/// <item>
	/// <term>The Windows directory. Use the GetWindowsDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The directories that are listed in the PATH environment variable. Note that this function does not search the per-application
	/// path specified by the <c>App Paths</c> registry key. To include this per-application path in the search sequence, use the
	/// ShellExecute function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The system adds a null character to the command line string to separate the file name from the arguments. This divides the
	/// original string into two strings for internal processing.
	/// </para>
	/// </param>
	/// <param name="lpProcessAttributes">
	/// A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new process object and determines
	/// whether child processes can inherit the returned handle to the process. If lpProcessAttributes is <c>NULL</c> or
	/// <c>lpSecurityDescriptor</c> is <c>NULL</c>, the process gets a default security descriptor and the handle cannot be inherited.
	/// The default security descriptor is that of the user referenced in the hToken parameter. This security descriptor may not allow
	/// access for the caller, in which case the process may not be opened again after it is run. The process handle is valid and will
	/// continue to have full access rights.
	/// </param>
	/// <param name="lpThreadAttributes">
	/// A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new thread object and determines
	/// whether child processes can inherit the returned handle to the thread. If lpThreadAttributes is <c>NULL</c> or
	/// <c>lpSecurityDescriptor</c> is <c>NULL</c>, the thread gets a default security descriptor and the handle cannot be inherited. The
	/// default security descriptor is that of the user referenced in the hToken parameter. This security descriptor may not allow access
	/// for the caller.
	/// </param>
	/// <param name="bInheritHandles">
	/// <para>
	/// If this parameter is <c>TRUE</c>, each inheritable handle in the calling process is inherited by the new process. If the
	/// parameter is <c>FALSE</c>, the handles are not inherited. Note that inherited handles have the same value and access rights as
	/// the original handles.
	/// </para>
	/// <para>
	/// <c>Terminal Services:</c> You cannot inherit handles across sessions. Additionally, if this parameter is <c>TRUE</c>, you must
	/// create the process in the same session as the caller.
	/// </para>
	/// <para>
	/// <c>Protected Process Light (PPL) processes:</c> The generic handle inheritance is blocked when a PPL process creates a non-PPL
	/// process since PROCESS_DUP_HANDLE is not allowed from a non-PPL process to a PPL process. See Process Security and Access Rights
	/// </para>
	/// </param>
	/// <param name="dwCreationFlags">
	/// <para>
	/// The flags that control the priority class and the creation of the process. For a list of values, see Process Creation Flags.
	/// </para>
	/// <para>
	/// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the
	/// process's threads. For a list of values, see GetPriorityClass. If none of the priority class flags is specified, the priority
	/// class defaults to <c>NORMAL_PRIORITY_CLASS</c> unless the priority class of the creating process is <c>IDLE_PRIORITY_CLASS</c> or
	/// <c>BELOW_NORMAL_PRIORITY_CLASS</c>. In this case, the child process receives the default priority class of the calling process.
	/// </para>
	/// </param>
	/// <param name="lpEnvironment">
	/// <para>
	/// A pointer to an environment block for the new process. If this parameter is <c>NULL</c>, the new process uses the environment of
	/// the calling process.
	/// </para>
	/// <para>An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:</para>
	/// <para>name=value\0</para>
	/// <para>Because the equal sign is used as a separator, it must not be used in the name of an environment variable.</para>
	/// <para>
	/// An environment block can contain either Unicode or ANSI characters. If the environment block pointed to by lpEnvironment contains
	/// Unicode characters, be sure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>. If this parameter is <c>NULL</c> and
	/// the environment block of the parent process contains Unicode characters, you must also ensure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>.
	/// </para>
	/// <para>
	/// The ANSI version of this function, <c>CreateProcessAsUserA</c> fails if the total size of the environment block for the process
	/// exceeds 32,767 characters.
	/// </para>
	/// <para>
	/// Note that an ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block. A
	/// Unicode environment block is terminated by four zero bytes: two for the last string, two more to terminate the block.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> If the size of the combined user and system environment variable exceeds 8192 bytes,
	/// the process created by <c>CreateProcessAsUser</c> no longer runs with the environment block passed to the function by the parent
	/// process. Instead, the child process runs with the environment block returned by the CreateEnvironmentBlock function.
	/// </para>
	/// <para>To retrieve a copy of the environment block for a given user, use the CreateEnvironmentBlock function.</para>
	/// </param>
	/// <param name="lpCurrentDirectory">
	/// <para>The full path to the current directory for the process. The string can also specify a UNC path.</para>
	/// <para>
	/// If this parameter is NULL, the new process will have the same current drive and directory as the calling process. (This feature
	/// is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
	/// </para>
	/// </param>
	/// <param name="lpStartupInfo">
	/// <para>A pointer to a STARTUPINFO or STARTUPINFOEX structure.</para>
	/// <para>
	/// The user must have full access to both the specified window station and desktop. If you want the process to be interactive,
	/// specify winsta0\default. If the <c>lpDesktop</c> member is NULL, the new process inherits the desktop and window station of its
	/// parent process. If this member is an empty string, "", the new process connects to a window station using the rules described in
	/// Process Connection to a Window Station.
	/// </para>
	/// <para>
	/// To set extended attributes, use a STARTUPINFOEX structure and specify <c>EXTENDED_STARTUPINFO_PRESENT</c> in the dwCreationFlags parameter.
	/// </para>
	/// <para>Handles in STARTUPINFO or STARTUPINFOEX must be closed with CloseHandle when they are no longer needed.</para>
	/// <para>
	/// <c>Important</c> The caller is responsible for ensuring that the standard handle fields in STARTUPINFO contain valid handle
	/// values. These fields are copied unchanged to the child process without validation, even when the <c>dwFlags</c> member specifies
	/// <c>STARTF_USESTDHANDLES</c>. Incorrect values can cause the child process to misbehave or crash. Use the Application Verifier
	/// runtime verification tool to detect invalid handles.
	/// </para>
	/// </param>
	/// <param name="lpProcessInformation">
	/// <para>A pointer to a PROCESS_INFORMATION structure that receives identification information about the new process.</para>
	/// <para>Handles in PROCESS_INFORMATION must be closed with CloseHandle when they are no longer needed.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// Note that the function returns before the process has finished initialization. If a required DLL cannot be located or fails to
	/// initialize, the process is terminated. To get the termination status of a process, call GetExitCodeProcess.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>CreateProcessAsUser</c> must be able to open the primary token of the calling process with the <c>TOKEN_DUPLICATE</c> and
	/// <c>TOKEN_IMPERSONATE</c> access rights.
	/// </para>
	/// <para>
	/// By default, <c>CreateProcessAsUser</c> creates the new process on a noninteractive window station with a desktop that is not
	/// visible and cannot receive user input. To enable user interaction with the new process, you must specify the name of the default
	/// interactive window station and desktop, "winsta0\default", in the <c>lpDesktop</c> member of the STARTUPINFO structure. In
	/// addition, before calling <c>CreateProcessAsUser</c>, you must change the discretionary access control list (DACL) of both the
	/// default interactive window station and the default desktop. The DACLs for the window station and desktop must grant access to the
	/// user or the logon session represented by the hToken parameter.
	/// </para>
	/// <para>
	/// <c>CreateProcessAsUser</c> does not load the specified user's profile into the <c>HKEY_USERS</c> registry key. Therefore, to
	/// access the information in the <c>HKEY_CURRENT_USER</c> registry key, you must load the user's profile information into
	/// <c>HKEY_USERS</c> with the LoadUserProfile function before calling <c>CreateProcessAsUser</c>. Be sure to call UnloadUserProfile
	/// after the new process exits.
	/// </para>
	/// <para>
	/// If the lpEnvironment parameter is NULL, the new process inherits the environment of the calling process.
	/// <c>CreateProcessAsUser</c> does not automatically modify the environment block to include environment variables specific to the
	/// user represented by hToken. For example, the USERNAME and USERDOMAIN variables are inherited from the calling process if
	/// lpEnvironment is NULL. It is your responsibility to prepare the environment block for the new process and specify it in lpEnvironment.
	/// </para>
	/// <para>
	/// The CreateProcessWithLogonW and CreateProcessWithTokenW functions are similar to <c>CreateProcessAsUser</c>, except that the
	/// caller does not need to call the LogonUser function to authenticate the user and get a token.
	/// </para>
	/// <para>
	/// <c>CreateProcessAsUser</c> allows you to access the specified directory and executable image in the security context of the
	/// caller or the target user. By default, <c>CreateProcessAsUser</c> accesses the directory and executable image in the security
	/// context of the caller. In this case, if the caller does not have access to the directory and executable image, the function
	/// fails. To access the directory and executable image using the security context of the target user, specify hToken in a call to
	/// the ImpersonateLoggedOnUser function before calling <c>CreateProcessAsUser</c>.
	/// </para>
	/// <para>
	/// The process is assigned a process identifier. The identifier is valid until the process terminates. It can be used to identify
	/// the process, or specified in the OpenProcess function to open a handle to the process. The initial thread in the process is also
	/// assigned a thread identifier. It can be specified in the OpenThread function to open a handle to the thread. The identifier is
	/// valid until the thread terminates and can be used to uniquely identify the thread within the system. These identifiers are
	/// returned in the PROCESS_INFORMATION structure.
	/// </para>
	/// <para>
	/// The calling thread can use the WaitForInputIdle function to wait until the new process has finished its initialization and is
	/// waiting for user input with no input pending. This can be useful for synchronization between parent and child processes, because
	/// <c>CreateProcessAsUser</c> returns without waiting for the new process to finish its initialization. For example, the creating
	/// process would use <c>WaitForInputIdle</c> before trying to find a window associated with the new process.
	/// </para>
	/// <para>
	/// The preferred way to shut down a process is by using the ExitProcess function, because this function sends notification of
	/// approaching termination to all DLLs attached to the process. Other means of shutting down a process do not notify the attached
	/// DLLs. Note that when a thread calls <c>ExitProcess</c>, other threads of the process are terminated without an opportunity to
	/// execute any additional code (including the thread termination code of attached DLLs). For more information, see Terminating a Process.
	/// </para>
	/// <para>Security Remarks</para>
	/// <para>
	/// The lpApplicationName parameter can be NULL, in which case the executable name must be the first white space–delimited string in
	/// lpCommandLine. If the executable or path name has a space in it, there is a risk that a different executable could be run because
	/// of the way the function parses spaces. The following example is dangerous because the function will attempt to run "Program.exe",
	/// if it exists, instead of "MyApp.exe".
	/// </para>
	/// <para>
	/// If a malicious user were to create an application called "Program.exe" on a system, any program that incorrectly calls
	/// <c>CreateProcessAsUser</c> using the Program Files directory will run this application instead of the intended application.
	/// </para>
	/// <para>
	/// To avoid this problem, do not pass NULL for lpApplicationName. If you do pass <c>NULL</c> for lpApplicationName, use quotation
	/// marks around the executable path in lpCommandLine, as shown in the example below.
	/// </para>
	/// <para>
	/// <c>PowerShell:</c> When the <c>CreateProcessAsUser</c> function is used to implement a cmdlet in PowerShell version 2.0, the
	/// cmdlet operates correctly for both fan-in and fan-out remote sessions. Because of certain security scenarios, however, a cmdlet
	/// implemented with <c>CreateProcessAsUser</c> only operates correctly in PowerShell version 3.0 for fan-in remote sessions; fan-out
	/// remote sessions will fail because of insufficient client security privileges. To implement a cmdlet that works for both fan-in
	/// and fan-out remote sessions in PowerShell version 3.0, use the CreateProcess function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Starting an Interactive Client Process.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/processthreadsapi/nf-processthreadsapi-createprocessasusera BOOL
	// CreateProcessAsUserA( HANDLE hToken, LPCSTR lpApplicationName, PSTR lpCommandLine, LPSECURITY_ATTRIBUTES lpProcessAttributes,
	// LPSECURITY_ATTRIBUTES lpThreadAttributes, BOOL bInheritHandles, DWORD dwCreationFlags, LPVOID lpEnvironment, LPCSTR
	// lpCurrentDirectory, LPSTARTUPINFOA lpStartupInfo, LPPROCESS_INFORMATION lpProcessInformation );
	[PInvokeData("processthreadsapi.h", MSDNShortId = "6b3f4dd9-500b-420e-804a-401a9e188be8")]
	public static bool CreateProcessAsUser(HTOKEN hToken, [Optional] string? lpApplicationName, [Optional] StringBuilder? lpCommandLine, [Optional] SECURITY_ATTRIBUTES? lpProcessAttributes,
		[Optional] SECURITY_ATTRIBUTES? lpThreadAttributes, bool bInheritHandles, CREATE_PROCESS dwCreationFlags, [In, Optional] string[]? lpEnvironment, [Optional] string? lpCurrentDirectory,
		in STARTUPINFO lpStartupInfo, [NotNullWhen(true)] out SafePROCESS_INFORMATION lpProcessInformation)
	{
		var ret = CreateProcessAsUser(hToken, lpApplicationName, lpCommandLine, lpProcessAttributes, lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment,
			lpCurrentDirectory, lpStartupInfo, out PROCESS_INFORMATION pi);
		lpProcessInformation = ret ? new(pi) : new();
		return ret;
	}

	/// <summary>
	/// <para>
	/// Creates a new process and its primary thread. The new process runs in the security context of the user represented by the
	/// specified token.
	/// </para>
	/// <para>
	/// Typically, the process that calls the <c>CreateProcessAsUser</c> function must have the <c>SE_INCREASE_QUOTA_NAME</c> privilege
	/// and may require the <c>SE_ASSIGNPRIMARYTOKEN_NAME</c> privilege if the token is not assignable. If this function fails with
	/// <c>ERROR_PRIVILEGE_NOT_HELD</c> (1314), use the CreateProcessWithLogonW function instead. <c>CreateProcessWithLogonW</c> requires
	/// no special privileges, but the specified user account must be allowed to log on interactively. Generally, it is best to use
	/// <c>CreateProcessWithLogonW</c> to create a process with alternate credentials.
	/// </para>
	/// </summary>
	/// <param name="hToken">
	/// <para>
	/// A handle to the primary token that represents a user. The handle must have the <c>TOKEN_QUERY</c>, <c>TOKEN_DUPLICATE</c>, and
	/// <c>TOKEN_ASSIGN_PRIMARY</c> access rights. For more information, see Access Rights for Access-Token Objects. The user represented
	/// by the token must have read and execute access to the application specified by the lpApplicationName or the lpCommandLine parameter.
	/// </para>
	/// <para>
	/// To get a primary token that represents the specified user, call the LogonUser function. Alternatively, you can call the
	/// DuplicateTokenEx function to convert an impersonation token into a primary token. This allows a server application that is
	/// impersonating a client to create a process that has the security context of the client.
	/// </para>
	/// <para>
	/// If hToken is a restricted version of the caller's primary token, the <c>SE_ASSIGNPRIMARYTOKEN_NAME</c> privilege is not required.
	/// If the necessary privileges are not already enabled, <c>CreateProcessAsUser</c> enables them for the duration of the call. For
	/// more information, see Running with Special Privileges.
	/// </para>
	/// <para>
	/// <c>Terminal Services:</c> The process is run in the session specified in the token. By default, this is the same session that
	/// called LogonUser. To change the session, use the SetTokenInformation function.
	/// </para>
	/// </param>
	/// <param name="lpApplicationName">
	/// <para>
	/// The name of the module to be executed. This module can be a Windows-based application. It can be some other type of module (for
	/// example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
	/// </para>
	/// <para>
	/// The string can specify the full path and file name of the module to execute or it can specify a partial name. In the case of a
	/// partial name, the function uses the current drive and current directory to complete the specification. The function will not use
	/// the search path. This parameter must include the file name extension; no default extension is assumed.
	/// </para>
	/// <para>
	/// The lpApplicationName parameter can be <c>NULL</c>. In that case, the module name must be the first white space–delimited token
	/// in the lpCommandLine string. If you are using a long file name that contains a space, use quoted strings to indicate where the
	/// file name ends and the arguments begin; otherwise, the file name is ambiguous. For example, consider the string "c:\program
	/// files\sub dir\program name". This string can be interpreted in a number of ways. The system tries to interpret the possibilities
	/// in the following order:
	/// </para>
	/// <para>
	/// <c>c:\program.exe</c><c>c:\program files\sub.exe</c><c>c:\program files\sub dir\program.exe</c><c>c:\program files\sub
	/// dir\program name.exe</c> If the executable module is a 16-bit application, lpApplicationName should be <c>NULL</c>, and the
	/// string pointed to by lpCommandLine should specify the executable module as well as its arguments. By default, all 16-bit
	/// Windows-based applications created by <c>CreateProcessAsUser</c> are run in a separate VDM (equivalent to
	/// <c>CREATE_SEPARATE_WOW_VDM</c> in CreateProcess).
	/// </para>
	/// </param>
	/// <param name="lpCommandLine">
	/// <para>
	/// The command line to be executed. The maximum length of this string is 32K characters. If lpApplicationName is <c>NULL</c>, the
	/// module name portion of lpCommandLine is limited to <c>MAX_PATH</c> characters.
	/// </para>
	/// <para>
	/// The Unicode version of this function, <c>CreateProcessAsUserW</c>, can modify the contents of this string. Therefore, this
	/// parameter cannot be a pointer to read-only memory (such as a <c>const</c> variable or a literal string). If this parameter is a
	/// constant string, the function may cause an access violation.
	/// </para>
	/// <para>
	/// The lpCommandLine parameter can be <c>NULL</c>. In that case, the function uses the string pointed to by lpApplicationName as the
	/// command line.
	/// </para>
	/// <para>
	/// If both lpApplicationName and lpCommandLine are non- <c>NULL</c>, *lpApplicationName specifies the module to execute, and
	/// *lpCommandLine specifies the command line. The new process can use GetCommandLine to retrieve the entire command line. Console
	/// processes written in C can use the argc and argv arguments to parse the command line. Because argv[0] is the module name, C
	/// programmers generally repeat the module name as the first token in the command line.
	/// </para>
	/// <para>
	/// If lpApplicationName is <c>NULL</c>, the first white space–delimited token of the command line specifies the module name. If you
	/// are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin
	/// (see the explanation for the lpApplicationName parameter). If the file name does not contain an extension, .exe is appended.
	/// Therefore, if the file name extension is .com, this parameter must include the .com extension. If the file name ends in a period
	/// (.) with no extension, or if the file name contains a path, .exe is not appended. If the file name does not contain a directory
	/// path, the system searches for the executable file in the following sequence:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>The directory from which the application loaded.</term>
	/// </item>
	/// <item>
	/// <term>The current directory for the parent process.</term>
	/// </item>
	/// <item>
	/// <term>The 32-bit Windows system directory. Use the GetSystemDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>The 16-bit Windows system directory. There is no function that obtains the path of this directory, but it is searched.</term>
	/// </item>
	/// <item>
	/// <term>The Windows directory. Use the GetWindowsDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The directories that are listed in the PATH environment variable. Note that this function does not search the per-application
	/// path specified by the <c>App Paths</c> registry key. To include this per-application path in the search sequence, use the
	/// ShellExecute function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The system adds a null character to the command line string to separate the file name from the arguments. This divides the
	/// original string into two strings for internal processing.
	/// </para>
	/// </param>
	/// <param name="lpProcessAttributes">
	/// A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new process object and determines
	/// whether child processes can inherit the returned handle to the process. If lpProcessAttributes is <c>NULL</c> or
	/// <c>lpSecurityDescriptor</c> is <c>NULL</c>, the process gets a default security descriptor and the handle cannot be inherited.
	/// The default security descriptor is that of the user referenced in the hToken parameter. This security descriptor may not allow
	/// access for the caller, in which case the process may not be opened again after it is run. The process handle is valid and will
	/// continue to have full access rights.
	/// </param>
	/// <param name="lpThreadAttributes">
	/// A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new thread object and determines
	/// whether child processes can inherit the returned handle to the thread. If lpThreadAttributes is <c>NULL</c> or
	/// <c>lpSecurityDescriptor</c> is <c>NULL</c>, the thread gets a default security descriptor and the handle cannot be inherited. The
	/// default security descriptor is that of the user referenced in the hToken parameter. This security descriptor may not allow access
	/// for the caller.
	/// </param>
	/// <param name="bInheritHandles">
	/// <para>
	/// If this parameter is <c>TRUE</c>, each inheritable handle in the calling process is inherited by the new process. If the
	/// parameter is <c>FALSE</c>, the handles are not inherited. Note that inherited handles have the same value and access rights as
	/// the original handles.
	/// </para>
	/// <para>
	/// <c>Terminal Services:</c> You cannot inherit handles across sessions. Additionally, if this parameter is <c>TRUE</c>, you must
	/// create the process in the same session as the caller.
	/// </para>
	/// <para>
	/// <c>Protected Process Light (PPL) processes:</c> The generic handle inheritance is blocked when a PPL process creates a non-PPL
	/// process since PROCESS_DUP_HANDLE is not allowed from a non-PPL process to a PPL process. See Process Security and Access Rights
	/// </para>
	/// </param>
	/// <param name="dwCreationFlags">
	/// <para>
	/// The flags that control the priority class and the creation of the process. For a list of values, see Process Creation Flags.
	/// </para>
	/// <para>
	/// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the
	/// process's threads. For a list of values, see GetPriorityClass. If none of the priority class flags is specified, the priority
	/// class defaults to <c>NORMAL_PRIORITY_CLASS</c> unless the priority class of the creating process is <c>IDLE_PRIORITY_CLASS</c> or
	/// <c>BELOW_NORMAL_PRIORITY_CLASS</c>. In this case, the child process receives the default priority class of the calling process.
	/// </para>
	/// </param>
	/// <param name="lpEnvironment">
	/// <para>
	/// A pointer to an environment block for the new process. If this parameter is <c>NULL</c>, the new process uses the environment of
	/// the calling process.
	/// </para>
	/// <para>An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:</para>
	/// <para>name=value\0</para>
	/// <para>Because the equal sign is used as a separator, it must not be used in the name of an environment variable.</para>
	/// <para>
	/// An environment block can contain either Unicode or ANSI characters. If the environment block pointed to by lpEnvironment contains
	/// Unicode characters, be sure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>. If this parameter is <c>NULL</c> and
	/// the environment block of the parent process contains Unicode characters, you must also ensure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>.
	/// </para>
	/// <para>
	/// The ANSI version of this function, <c>CreateProcessAsUserA</c> fails if the total size of the environment block for the process
	/// exceeds 32,767 characters.
	/// </para>
	/// <para>
	/// Note that an ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block. A
	/// Unicode environment block is terminated by four zero bytes: two for the last string, two more to terminate the block.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> If the size of the combined user and system environment variable exceeds 8192 bytes,
	/// the process created by <c>CreateProcessAsUser</c> no longer runs with the environment block passed to the function by the parent
	/// process. Instead, the child process runs with the environment block returned by the CreateEnvironmentBlock function.
	/// </para>
	/// <para>To retrieve a copy of the environment block for a given user, use the CreateEnvironmentBlock function.</para>
	/// </param>
	/// <param name="lpCurrentDirectory">
	/// <para>The full path to the current directory for the process. The string can also specify a UNC path.</para>
	/// <para>
	/// If this parameter is NULL, the new process will have the same current drive and directory as the calling process. (This feature
	/// is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
	/// </para>
	/// </param>
	/// <param name="lpStartupInfo">
	/// <para>A pointer to a STARTUPINFO or STARTUPINFOEX structure.</para>
	/// <para>
	/// The user must have full access to both the specified window station and desktop. If you want the process to be interactive,
	/// specify winsta0\default. If the <c>lpDesktop</c> member is NULL, the new process inherits the desktop and window station of its
	/// parent process. If this member is an empty string, "", the new process connects to a window station using the rules described in
	/// Process Connection to a Window Station.
	/// </para>
	/// <para>
	/// To set extended attributes, use a STARTUPINFOEX structure and specify <c>EXTENDED_STARTUPINFO_PRESENT</c> in the dwCreationFlags parameter.
	/// </para>
	/// <para>Handles in STARTUPINFO or STARTUPINFOEX must be closed with CloseHandle when they are no longer needed.</para>
	/// <para>
	/// <c>Important</c> The caller is responsible for ensuring that the standard handle fields in STARTUPINFO contain valid handle
	/// values. These fields are copied unchanged to the child process without validation, even when the <c>dwFlags</c> member specifies
	/// <c>STARTF_USESTDHANDLES</c>. Incorrect values can cause the child process to misbehave or crash. Use the Application Verifier
	/// runtime verification tool to detect invalid handles.
	/// </para>
	/// </param>
	/// <param name="lpProcessInformation">
	/// <para>A pointer to a PROCESS_INFORMATION structure that receives identification information about the new process.</para>
	/// <para>Handles in PROCESS_INFORMATION must be closed with CloseHandle when they are no longer needed.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// Note that the function returns before the process has finished initialization. If a required DLL cannot be located or fails to
	/// initialize, the process is terminated. To get the termination status of a process, call GetExitCodeProcess.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>CreateProcessAsUser</c> must be able to open the primary token of the calling process with the <c>TOKEN_DUPLICATE</c> and
	/// <c>TOKEN_IMPERSONATE</c> access rights.
	/// </para>
	/// <para>
	/// By default, <c>CreateProcessAsUser</c> creates the new process on a noninteractive window station with a desktop that is not
	/// visible and cannot receive user input. To enable user interaction with the new process, you must specify the name of the default
	/// interactive window station and desktop, "winsta0\default", in the <c>lpDesktop</c> member of the STARTUPINFO structure. In
	/// addition, before calling <c>CreateProcessAsUser</c>, you must change the discretionary access control list (DACL) of both the
	/// default interactive window station and the default desktop. The DACLs for the window station and desktop must grant access to the
	/// user or the logon session represented by the hToken parameter.
	/// </para>
	/// <para>
	/// <c>CreateProcessAsUser</c> does not load the specified user's profile into the <c>HKEY_USERS</c> registry key. Therefore, to
	/// access the information in the <c>HKEY_CURRENT_USER</c> registry key, you must load the user's profile information into
	/// <c>HKEY_USERS</c> with the LoadUserProfile function before calling <c>CreateProcessAsUser</c>. Be sure to call UnloadUserProfile
	/// after the new process exits.
	/// </para>
	/// <para>
	/// If the lpEnvironment parameter is NULL, the new process inherits the environment of the calling process.
	/// <c>CreateProcessAsUser</c> does not automatically modify the environment block to include environment variables specific to the
	/// user represented by hToken. For example, the USERNAME and USERDOMAIN variables are inherited from the calling process if
	/// lpEnvironment is NULL. It is your responsibility to prepare the environment block for the new process and specify it in lpEnvironment.
	/// </para>
	/// <para>
	/// The CreateProcessWithLogonW and CreateProcessWithTokenW functions are similar to <c>CreateProcessAsUser</c>, except that the
	/// caller does not need to call the LogonUser function to authenticate the user and get a token.
	/// </para>
	/// <para>
	/// <c>CreateProcessAsUser</c> allows you to access the specified directory and executable image in the security context of the
	/// caller or the target user. By default, <c>CreateProcessAsUser</c> accesses the directory and executable image in the security
	/// context of the caller. In this case, if the caller does not have access to the directory and executable image, the function
	/// fails. To access the directory and executable image using the security context of the target user, specify hToken in a call to
	/// the ImpersonateLoggedOnUser function before calling <c>CreateProcessAsUser</c>.
	/// </para>
	/// <para>
	/// The process is assigned a process identifier. The identifier is valid until the process terminates. It can be used to identify
	/// the process, or specified in the OpenProcess function to open a handle to the process. The initial thread in the process is also
	/// assigned a thread identifier. It can be specified in the OpenThread function to open a handle to the thread. The identifier is
	/// valid until the thread terminates and can be used to uniquely identify the thread within the system. These identifiers are
	/// returned in the PROCESS_INFORMATION structure.
	/// </para>
	/// <para>
	/// The calling thread can use the WaitForInputIdle function to wait until the new process has finished its initialization and is
	/// waiting for user input with no input pending. This can be useful for synchronization between parent and child processes, because
	/// <c>CreateProcessAsUser</c> returns without waiting for the new process to finish its initialization. For example, the creating
	/// process would use <c>WaitForInputIdle</c> before trying to find a window associated with the new process.
	/// </para>
	/// <para>
	/// The preferred way to shut down a process is by using the ExitProcess function, because this function sends notification of
	/// approaching termination to all DLLs attached to the process. Other means of shutting down a process do not notify the attached
	/// DLLs. Note that when a thread calls <c>ExitProcess</c>, other threads of the process are terminated without an opportunity to
	/// execute any additional code (including the thread termination code of attached DLLs). For more information, see Terminating a Process.
	/// </para>
	/// <para>Security Remarks</para>
	/// <para>
	/// The lpApplicationName parameter can be NULL, in which case the executable name must be the first white space–delimited string in
	/// lpCommandLine. If the executable or path name has a space in it, there is a risk that a different executable could be run because
	/// of the way the function parses spaces. The following example is dangerous because the function will attempt to run "Program.exe",
	/// if it exists, instead of "MyApp.exe".
	/// </para>
	/// <para>
	/// If a malicious user were to create an application called "Program.exe" on a system, any program that incorrectly calls
	/// <c>CreateProcessAsUser</c> using the Program Files directory will run this application instead of the intended application.
	/// </para>
	/// <para>
	/// To avoid this problem, do not pass NULL for lpApplicationName. If you do pass <c>NULL</c> for lpApplicationName, use quotation
	/// marks around the executable path in lpCommandLine, as shown in the example below.
	/// </para>
	/// <para>
	/// <c>PowerShell:</c> When the <c>CreateProcessAsUser</c> function is used to implement a cmdlet in PowerShell version 2.0, the
	/// cmdlet operates correctly for both fan-in and fan-out remote sessions. Because of certain security scenarios, however, a cmdlet
	/// implemented with <c>CreateProcessAsUser</c> only operates correctly in PowerShell version 3.0 for fan-in remote sessions; fan-out
	/// remote sessions will fail because of insufficient client security privileges. To implement a cmdlet that works for both fan-in
	/// and fan-out remote sessions in PowerShell version 3.0, use the CreateProcess function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Starting an Interactive Client Process.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/processthreadsapi/nf-processthreadsapi-createprocessasusera BOOL
	// CreateProcessAsUserA( HANDLE hToken, LPCSTR lpApplicationName, PSTR lpCommandLine, LPSECURITY_ATTRIBUTES lpProcessAttributes,
	// LPSECURITY_ATTRIBUTES lpThreadAttributes, BOOL bInheritHandles, DWORD dwCreationFlags, LPVOID lpEnvironment, LPCSTR
	// lpCurrentDirectory, LPSTARTUPINFOA lpStartupInfo, LPPROCESS_INFORMATION lpProcessInformation );
	[PInvokeData("processthreadsapi.h", MSDNShortId = "6b3f4dd9-500b-420e-804a-401a9e188be8")]
	public static bool CreateProcessAsUser(HTOKEN hToken, [Optional] string? lpApplicationName, [Optional] StringBuilder? lpCommandLine, [Optional] SECURITY_ATTRIBUTES? lpProcessAttributes,
		[Optional] SECURITY_ATTRIBUTES? lpThreadAttributes, bool bInheritHandles, CREATE_PROCESS dwCreationFlags, [In, Optional] string[]? lpEnvironment, [Optional] string? lpCurrentDirectory,
		in STARTUPINFOEX lpStartupInfo, [NotNullWhen(true)] out SafePROCESS_INFORMATION lpProcessInformation)
	{
		var ret = CreateProcessAsUser(hToken, lpApplicationName, lpCommandLine, lpProcessAttributes, lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment,
			lpCurrentDirectory, lpStartupInfo, out PROCESS_INFORMATION pi);
		lpProcessInformation = ret ? new(pi) : new();
		return ret;
	}

	/// <summary>The OpenProcessToken function opens the access token associated with a process.</summary>
	/// <param name="ProcessHandle">
	/// A handle to the process whose access token is opened. The process must have the PROCESS_QUERY_INFORMATION access permission.
	/// </param>
	/// <param name="DesiredAccess">
	/// Specifies an access mask that specifies the requested types of access to the access token. These requested access types are
	/// compared with the discretionary access control list (DACL) of the token to determine which accesses are granted or denied.
	/// </param>
	/// <param name="TokenHandle">A pointer to a handle that identifies the newly opened access token when the function returns.</param>
	/// <returns>
	/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error
	/// information, call GetLastError.
	/// </returns>
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	[PInvokeData("processthreadsapi.h", MSDNShortId = "aa379295")]
	public static extern bool OpenProcessToken([In] HPROCESS ProcessHandle, TokenAccess DesiredAccess, out SafeHTOKEN TokenHandle);

	/// <summary>The <c>OpenThreadToken</c> function opens the access token associated with a thread.</summary>
	/// <param name="ThreadHandle">A handle to the thread whose access token is opened.</param>
	/// <param name="DesiredAccess">
	/// <para>
	/// Specifies an access mask that specifies the requested types of access to the access token. These requested access types are
	/// reconciled against the token's discretionary access control list (DACL) to determine which accesses are granted or denied.
	/// </para>
	/// <para>For a list of access rights for access tokens, see Access Rights for Access-Token Objects.</para>
	/// </param>
	/// <param name="OpenAsSelf">
	/// <para>TRUE if the access check is to be made against the process-level security context.</para>
	/// <para>
	/// <c>FALSE</c> if the access check is to be made against the current security context of the thread calling the
	/// <c>OpenThreadToken</c> function.
	/// </para>
	/// <para>
	/// The OpenAsSelf parameter allows the caller of this function to open the access token of a specified thread when the caller is
	/// impersonating a token at <c>SecurityIdentification</c> level. Without this parameter, the calling thread cannot open the access
	/// token on the specified thread because it is impossible to open executive-level objects by using the <c>SecurityIdentification</c>
	/// impersonation level.
	/// </para>
	/// </param>
	/// <param name="TokenHandle">A pointer to a variable that receives the handle to the newly opened access token.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. If the token has
	/// the anonymous impersonation level, the token will not be opened and <c>OpenThreadToken</c> sets ERROR_CANT_OPEN_ANONYMOUS as the error.
	/// </para>
	/// </returns>
	// BOOL WINAPI OpenThreadToken( _In_ HANDLE ThreadHandle, _In_ DWORD DesiredAccess, _In_ BOOL OpenAsSelf, _Out_ PHANDLE TokenHandle); https://msdn.microsoft.com/en-us/library/windows/desktop/aa379296(v=vs.85).aspx
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("processthreadsapi.h", MSDNShortId = "aa379296")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool OpenThreadToken([In] HTHREAD ThreadHandle, TokenAccess DesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool OpenAsSelf, out SafeHTOKEN TokenHandle);

	/// <summary>
	/// The <c>SetThreadToken</c> function assigns an impersonation token to a thread. The function can also cause a thread to stop using
	/// an impersonation token.
	/// </summary>
	/// <param name="Thread">
	/// <para>A pointer to a handle to the thread to which the function assigns the impersonation token.</para>
	/// <para>If Thread is <c>NULL</c>, the function assigns the impersonation token to the calling thread.</para>
	/// </param>
	/// <param name="Token">
	/// <para>
	/// A handle to the impersonation token to assign to the thread. This handle must have been opened with TOKEN_IMPERSONATE access
	/// rights. For more information, see Access Rights for Access-Token Objects.
	/// </para>
	/// <para>If Token is <c>NULL</c>, the function causes the thread to stop using an impersonation token.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetThreadToken( _In_opt_ PHANDLE Thread, _In_opt_ HANDLE Token); https://msdn.microsoft.com/en-us/library/windows/desktop/aa379590(v=vs.85).aspx
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("processthreadsapi.h", MSDNShortId = "aa379590")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetThreadToken(in HTHREAD Thread, [Optional] HTOKEN Token);

	/// <summary>
	/// The <c>SetThreadToken</c> function assigns an impersonation token to a thread. The function can also cause a thread to stop using
	/// an impersonation token.
	/// </summary>
	/// <param name="Thread">
	/// <para>A pointer to a handle to the thread to which the function assigns the impersonation token.</para>
	/// <para>If Thread is <c>NULL</c>, the function assigns the impersonation token to the calling thread.</para>
	/// </param>
	/// <param name="Token">
	/// <para>
	/// A handle to the impersonation token to assign to the thread. This handle must have been opened with TOKEN_IMPERSONATE access
	/// rights. For more information, see Access Rights for Access-Token Objects.
	/// </para>
	/// <para>If Token is <c>NULL</c>, the function causes the thread to stop using an impersonation token.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetThreadToken( _In_opt_ PHANDLE Thread, _In_opt_ HANDLE Token); https://msdn.microsoft.com/en-us/library/windows/desktop/aa379590(v=vs.85).aspx
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("processthreadsapi.h", MSDNShortId = "aa379590")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetThreadToken([Optional] IntPtr Thread, [Optional] HTOKEN Token);

	/// <summary>
	/// <para>
	/// Creates a new process and its primary thread. The new process runs in the security context of the user represented by the
	/// specified token.
	/// </para>
	/// <para>
	/// Typically, the process that calls the <c>CreateProcessAsUser</c> function must have the <c>SE_INCREASE_QUOTA_NAME</c> privilege
	/// and may require the <c>SE_ASSIGNPRIMARYTOKEN_NAME</c> privilege if the token is not assignable. If this function fails with
	/// <c>ERROR_PRIVILEGE_NOT_HELD</c> (1314), use the CreateProcessWithLogonW function instead. <c>CreateProcessWithLogonW</c> requires
	/// no special privileges, but the specified user account must be allowed to log on interactively. Generally, it is best to use
	/// <c>CreateProcessWithLogonW</c> to create a process with alternate credentials.
	/// </para>
	/// </summary>
	/// <param name="hToken">
	/// <para>
	/// A handle to the primary token that represents a user. The handle must have the <c>TOKEN_QUERY</c>, <c>TOKEN_DUPLICATE</c>, and
	/// <c>TOKEN_ASSIGN_PRIMARY</c> access rights. For more information, see Access Rights for Access-Token Objects. The user represented
	/// by the token must have read and execute access to the application specified by the lpApplicationName or the lpCommandLine parameter.
	/// </para>
	/// <para>
	/// To get a primary token that represents the specified user, call the LogonUser function. Alternatively, you can call the
	/// DuplicateTokenEx function to convert an impersonation token into a primary token. This allows a server application that is
	/// impersonating a client to create a process that has the security context of the client.
	/// </para>
	/// <para>
	/// If hToken is a restricted version of the caller's primary token, the <c>SE_ASSIGNPRIMARYTOKEN_NAME</c> privilege is not required.
	/// If the necessary privileges are not already enabled, <c>CreateProcessAsUser</c> enables them for the duration of the call. For
	/// more information, see Running with Special Privileges.
	/// </para>
	/// <para>
	/// <c>Terminal Services:</c> The process is run in the session specified in the token. By default, this is the same session that
	/// called LogonUser. To change the session, use the SetTokenInformation function.
	/// </para>
	/// </param>
	/// <param name="lpApplicationName">
	/// <para>
	/// The name of the module to be executed. This module can be a Windows-based application. It can be some other type of module (for
	/// example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
	/// </para>
	/// <para>
	/// The string can specify the full path and file name of the module to execute or it can specify a partial name. In the case of a
	/// partial name, the function uses the current drive and current directory to complete the specification. The function will not use
	/// the search path. This parameter must include the file name extension; no default extension is assumed.
	/// </para>
	/// <para>
	/// The lpApplicationName parameter can be <c>NULL</c>. In that case, the module name must be the first white space–delimited token
	/// in the lpCommandLine string. If you are using a long file name that contains a space, use quoted strings to indicate where the
	/// file name ends and the arguments begin; otherwise, the file name is ambiguous. For example, consider the string "c:\program
	/// files\sub dir\program name". This string can be interpreted in a number of ways. The system tries to interpret the possibilities
	/// in the following order:
	/// </para>
	/// <para>
	/// <c>c:\program.exe</c><c>c:\program files\sub.exe</c><c>c:\program files\sub dir\program.exe</c><c>c:\program files\sub
	/// dir\program name.exe</c> If the executable module is a 16-bit application, lpApplicationName should be <c>NULL</c>, and the
	/// string pointed to by lpCommandLine should specify the executable module as well as its arguments. By default, all 16-bit
	/// Windows-based applications created by <c>CreateProcessAsUser</c> are run in a separate VDM (equivalent to
	/// <c>CREATE_SEPARATE_WOW_VDM</c> in CreateProcess).
	/// </para>
	/// </param>
	/// <param name="lpCommandLine">
	/// <para>
	/// The command line to be executed. The maximum length of this string is 32K characters. If lpApplicationName is <c>NULL</c>, the
	/// module name portion of lpCommandLine is limited to <c>MAX_PATH</c> characters.
	/// </para>
	/// <para>
	/// The Unicode version of this function, <c>CreateProcessAsUserW</c>, can modify the contents of this string. Therefore, this
	/// parameter cannot be a pointer to read-only memory (such as a <c>const</c> variable or a literal string). If this parameter is a
	/// constant string, the function may cause an access violation.
	/// </para>
	/// <para>
	/// The lpCommandLine parameter can be <c>NULL</c>. In that case, the function uses the string pointed to by lpApplicationName as the
	/// command line.
	/// </para>
	/// <para>
	/// If both lpApplicationName and lpCommandLine are non- <c>NULL</c>, *lpApplicationName specifies the module to execute, and
	/// *lpCommandLine specifies the command line. The new process can use GetCommandLine to retrieve the entire command line. Console
	/// processes written in C can use the argc and argv arguments to parse the command line. Because argv[0] is the module name, C
	/// programmers generally repeat the module name as the first token in the command line.
	/// </para>
	/// <para>
	/// If lpApplicationName is <c>NULL</c>, the first white space–delimited token of the command line specifies the module name. If you
	/// are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin
	/// (see the explanation for the lpApplicationName parameter). If the file name does not contain an extension, .exe is appended.
	/// Therefore, if the file name extension is .com, this parameter must include the .com extension. If the file name ends in a period
	/// (.) with no extension, or if the file name contains a path, .exe is not appended. If the file name does not contain a directory
	/// path, the system searches for the executable file in the following sequence:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>The directory from which the application loaded.</term>
	/// </item>
	/// <item>
	/// <term>The current directory for the parent process.</term>
	/// </item>
	/// <item>
	/// <term>The 32-bit Windows system directory. Use the GetSystemDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>The 16-bit Windows system directory. There is no function that obtains the path of this directory, but it is searched.</term>
	/// </item>
	/// <item>
	/// <term>The Windows directory. Use the GetWindowsDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The directories that are listed in the PATH environment variable. Note that this function does not search the per-application
	/// path specified by the <c>App Paths</c> registry key. To include this per-application path in the search sequence, use the
	/// ShellExecute function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The system adds a null character to the command line string to separate the file name from the arguments. This divides the
	/// original string into two strings for internal processing.
	/// </para>
	/// </param>
	/// <param name="lpProcessAttributes">
	/// A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new process object and determines
	/// whether child processes can inherit the returned handle to the process. If lpProcessAttributes is <c>NULL</c> or
	/// <c>lpSecurityDescriptor</c> is <c>NULL</c>, the process gets a default security descriptor and the handle cannot be inherited.
	/// The default security descriptor is that of the user referenced in the hToken parameter. This security descriptor may not allow
	/// access for the caller, in which case the process may not be opened again after it is run. The process handle is valid and will
	/// continue to have full access rights.
	/// </param>
	/// <param name="lpThreadAttributes">
	/// A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new thread object and determines
	/// whether child processes can inherit the returned handle to the thread. If lpThreadAttributes is <c>NULL</c> or
	/// <c>lpSecurityDescriptor</c> is <c>NULL</c>, the thread gets a default security descriptor and the handle cannot be inherited. The
	/// default security descriptor is that of the user referenced in the hToken parameter. This security descriptor may not allow access
	/// for the caller.
	/// </param>
	/// <param name="bInheritHandles">
	/// <para>
	/// If this parameter is <c>TRUE</c>, each inheritable handle in the calling process is inherited by the new process. If the
	/// parameter is <c>FALSE</c>, the handles are not inherited. Note that inherited handles have the same value and access rights as
	/// the original handles.
	/// </para>
	/// <para>
	/// <c>Terminal Services:</c> You cannot inherit handles across sessions. Additionally, if this parameter is <c>TRUE</c>, you must
	/// create the process in the same session as the caller.
	/// </para>
	/// <para>
	/// <c>Protected Process Light (PPL) processes:</c> The generic handle inheritance is blocked when a PPL process creates a non-PPL
	/// process since PROCESS_DUP_HANDLE is not allowed from a non-PPL process to a PPL process. See Process Security and Access Rights
	/// </para>
	/// </param>
	/// <param name="dwCreationFlags">
	/// <para>
	/// The flags that control the priority class and the creation of the process. For a list of values, see Process Creation Flags.
	/// </para>
	/// <para>
	/// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the
	/// process's threads. For a list of values, see GetPriorityClass. If none of the priority class flags is specified, the priority
	/// class defaults to <c>NORMAL_PRIORITY_CLASS</c> unless the priority class of the creating process is <c>IDLE_PRIORITY_CLASS</c> or
	/// <c>BELOW_NORMAL_PRIORITY_CLASS</c>. In this case, the child process receives the default priority class of the calling process.
	/// </para>
	/// </param>
	/// <param name="lpEnvironment">
	/// <para>
	/// A pointer to an environment block for the new process. If this parameter is <c>NULL</c>, the new process uses the environment of
	/// the calling process.
	/// </para>
	/// <para>An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:</para>
	/// <para>name=value\0</para>
	/// <para>Because the equal sign is used as a separator, it must not be used in the name of an environment variable.</para>
	/// <para>
	/// An environment block can contain either Unicode or ANSI characters. If the environment block pointed to by lpEnvironment contains
	/// Unicode characters, be sure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>. If this parameter is <c>NULL</c> and
	/// the environment block of the parent process contains Unicode characters, you must also ensure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>.
	/// </para>
	/// <para>
	/// The ANSI version of this function, <c>CreateProcessAsUserA</c> fails if the total size of the environment block for the process
	/// exceeds 32,767 characters.
	/// </para>
	/// <para>
	/// Note that an ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block. A
	/// Unicode environment block is terminated by four zero bytes: two for the last string, two more to terminate the block.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> If the size of the combined user and system environment variable exceeds 8192 bytes,
	/// the process created by <c>CreateProcessAsUser</c> no longer runs with the environment block passed to the function by the parent
	/// process. Instead, the child process runs with the environment block returned by the CreateEnvironmentBlock function.
	/// </para>
	/// <para>To retrieve a copy of the environment block for a given user, use the CreateEnvironmentBlock function.</para>
	/// </param>
	/// <param name="lpCurrentDirectory">
	/// <para>The full path to the current directory for the process. The string can also specify a UNC path.</para>
	/// <para>
	/// If this parameter is NULL, the new process will have the same current drive and directory as the calling process. (This feature
	/// is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
	/// </para>
	/// </param>
	/// <param name="lpStartupInfo">
	/// <para>A pointer to a STARTUPINFO or STARTUPINFOEX structure.</para>
	/// <para>
	/// The user must have full access to both the specified window station and desktop. If you want the process to be interactive,
	/// specify winsta0\default. If the <c>lpDesktop</c> member is NULL, the new process inherits the desktop and window station of its
	/// parent process. If this member is an empty string, "", the new process connects to a window station using the rules described in
	/// Process Connection to a Window Station.
	/// </para>
	/// <para>
	/// To set extended attributes, use a STARTUPINFOEX structure and specify <c>EXTENDED_STARTUPINFO_PRESENT</c> in the dwCreationFlags parameter.
	/// </para>
	/// <para>Handles in STARTUPINFO or STARTUPINFOEX must be closed with CloseHandle when they are no longer needed.</para>
	/// <para>
	/// <c>Important</c> The caller is responsible for ensuring that the standard handle fields in STARTUPINFO contain valid handle
	/// values. These fields are copied unchanged to the child process without validation, even when the <c>dwFlags</c> member specifies
	/// <c>STARTF_USESTDHANDLES</c>. Incorrect values can cause the child process to misbehave or crash. Use the Application Verifier
	/// runtime verification tool to detect invalid handles.
	/// </para>
	/// </param>
	/// <param name="lpProcessInformation">
	/// <para>A pointer to a PROCESS_INFORMATION structure that receives identification information about the new process.</para>
	/// <para>Handles in PROCESS_INFORMATION must be closed with CloseHandle when they are no longer needed.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// Note that the function returns before the process has finished initialization. If a required DLL cannot be located or fails to
	/// initialize, the process is terminated. To get the termination status of a process, call GetExitCodeProcess.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>CreateProcessAsUser</c> must be able to open the primary token of the calling process with the <c>TOKEN_DUPLICATE</c> and
	/// <c>TOKEN_IMPERSONATE</c> access rights.
	/// </para>
	/// <para>
	/// By default, <c>CreateProcessAsUser</c> creates the new process on a noninteractive window station with a desktop that is not
	/// visible and cannot receive user input. To enable user interaction with the new process, you must specify the name of the default
	/// interactive window station and desktop, "winsta0\default", in the <c>lpDesktop</c> member of the STARTUPINFO structure. In
	/// addition, before calling <c>CreateProcessAsUser</c>, you must change the discretionary access control list (DACL) of both the
	/// default interactive window station and the default desktop. The DACLs for the window station and desktop must grant access to the
	/// user or the logon session represented by the hToken parameter.
	/// </para>
	/// <para>
	/// <c>CreateProcessAsUser</c> does not load the specified user's profile into the <c>HKEY_USERS</c> registry key. Therefore, to
	/// access the information in the <c>HKEY_CURRENT_USER</c> registry key, you must load the user's profile information into
	/// <c>HKEY_USERS</c> with the LoadUserProfile function before calling <c>CreateProcessAsUser</c>. Be sure to call UnloadUserProfile
	/// after the new process exits.
	/// </para>
	/// <para>
	/// If the lpEnvironment parameter is NULL, the new process inherits the environment of the calling process.
	/// <c>CreateProcessAsUser</c> does not automatically modify the environment block to include environment variables specific to the
	/// user represented by hToken. For example, the USERNAME and USERDOMAIN variables are inherited from the calling process if
	/// lpEnvironment is NULL. It is your responsibility to prepare the environment block for the new process and specify it in lpEnvironment.
	/// </para>
	/// <para>
	/// The CreateProcessWithLogonW and CreateProcessWithTokenW functions are similar to <c>CreateProcessAsUser</c>, except that the
	/// caller does not need to call the LogonUser function to authenticate the user and get a token.
	/// </para>
	/// <para>
	/// <c>CreateProcessAsUser</c> allows you to access the specified directory and executable image in the security context of the
	/// caller or the target user. By default, <c>CreateProcessAsUser</c> accesses the directory and executable image in the security
	/// context of the caller. In this case, if the caller does not have access to the directory and executable image, the function
	/// fails. To access the directory and executable image using the security context of the target user, specify hToken in a call to
	/// the ImpersonateLoggedOnUser function before calling <c>CreateProcessAsUser</c>.
	/// </para>
	/// <para>
	/// The process is assigned a process identifier. The identifier is valid until the process terminates. It can be used to identify
	/// the process, or specified in the OpenProcess function to open a handle to the process. The initial thread in the process is also
	/// assigned a thread identifier. It can be specified in the OpenThread function to open a handle to the thread. The identifier is
	/// valid until the thread terminates and can be used to uniquely identify the thread within the system. These identifiers are
	/// returned in the PROCESS_INFORMATION structure.
	/// </para>
	/// <para>
	/// The calling thread can use the WaitForInputIdle function to wait until the new process has finished its initialization and is
	/// waiting for user input with no input pending. This can be useful for synchronization between parent and child processes, because
	/// <c>CreateProcessAsUser</c> returns without waiting for the new process to finish its initialization. For example, the creating
	/// process would use <c>WaitForInputIdle</c> before trying to find a window associated with the new process.
	/// </para>
	/// <para>
	/// The preferred way to shut down a process is by using the ExitProcess function, because this function sends notification of
	/// approaching termination to all DLLs attached to the process. Other means of shutting down a process do not notify the attached
	/// DLLs. Note that when a thread calls <c>ExitProcess</c>, other threads of the process are terminated without an opportunity to
	/// execute any additional code (including the thread termination code of attached DLLs). For more information, see Terminating a Process.
	/// </para>
	/// <para>Security Remarks</para>
	/// <para>
	/// The lpApplicationName parameter can be NULL, in which case the executable name must be the first white space–delimited string in
	/// lpCommandLine. If the executable or path name has a space in it, there is a risk that a different executable could be run because
	/// of the way the function parses spaces. The following example is dangerous because the function will attempt to run "Program.exe",
	/// if it exists, instead of "MyApp.exe".
	/// </para>
	/// <para>
	/// If a malicious user were to create an application called "Program.exe" on a system, any program that incorrectly calls
	/// <c>CreateProcessAsUser</c> using the Program Files directory will run this application instead of the intended application.
	/// </para>
	/// <para>
	/// To avoid this problem, do not pass NULL for lpApplicationName. If you do pass <c>NULL</c> for lpApplicationName, use quotation
	/// marks around the executable path in lpCommandLine, as shown in the example below.
	/// </para>
	/// <para>
	/// <c>PowerShell:</c> When the <c>CreateProcessAsUser</c> function is used to implement a cmdlet in PowerShell version 2.0, the
	/// cmdlet operates correctly for both fan-in and fan-out remote sessions. Because of certain security scenarios, however, a cmdlet
	/// implemented with <c>CreateProcessAsUser</c> only operates correctly in PowerShell version 3.0 for fan-in remote sessions; fan-out
	/// remote sessions will fail because of insufficient client security privileges. To implement a cmdlet that works for both fan-in
	/// and fan-out remote sessions in PowerShell version 3.0, use the CreateProcess function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Starting an Interactive Client Process.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/processthreadsapi/nf-processthreadsapi-createprocessasusera BOOL
	// CreateProcessAsUserA( HANDLE hToken, LPCSTR lpApplicationName, PSTR lpCommandLine, LPSECURITY_ATTRIBUTES lpProcessAttributes,
	// LPSECURITY_ATTRIBUTES lpThreadAttributes, BOOL bInheritHandles, DWORD dwCreationFlags, LPVOID lpEnvironment, LPCSTR
	// lpCurrentDirectory, LPSTARTUPINFOA lpStartupInfo, LPPROCESS_INFORMATION lpProcessInformation );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("processthreadsapi.h", MSDNShortId = "6b3f4dd9-500b-420e-804a-401a9e188be8")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool CreateProcessAsUser(HTOKEN hToken, [Optional] string? lpApplicationName, [Optional] StringBuilder? lpCommandLine,
		[Optional] SECURITY_ATTRIBUTES? lpProcessAttributes, [Optional] SECURITY_ATTRIBUTES? lpThreadAttributes, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandles,
		CREATE_PROCESS dwCreationFlags, [In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")] string[]? lpEnvironment,
		[Optional] string? lpCurrentDirectory, in STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);

	/// <summary>
	/// <para>
	/// Creates a new process and its primary thread. The new process runs in the security context of the user represented by the
	/// specified token.
	/// </para>
	/// <para>
	/// Typically, the process that calls the <c>CreateProcessAsUser</c> function must have the <c>SE_INCREASE_QUOTA_NAME</c> privilege
	/// and may require the <c>SE_ASSIGNPRIMARYTOKEN_NAME</c> privilege if the token is not assignable. If this function fails with
	/// <c>ERROR_PRIVILEGE_NOT_HELD</c> (1314), use the CreateProcessWithLogonW function instead. <c>CreateProcessWithLogonW</c> requires
	/// no special privileges, but the specified user account must be allowed to log on interactively. Generally, it is best to use
	/// <c>CreateProcessWithLogonW</c> to create a process with alternate credentials.
	/// </para>
	/// </summary>
	/// <param name="hToken">
	/// <para>
	/// A handle to the primary token that represents a user. The handle must have the <c>TOKEN_QUERY</c>, <c>TOKEN_DUPLICATE</c>, and
	/// <c>TOKEN_ASSIGN_PRIMARY</c> access rights. For more information, see Access Rights for Access-Token Objects. The user represented
	/// by the token must have read and execute access to the application specified by the lpApplicationName or the lpCommandLine parameter.
	/// </para>
	/// <para>
	/// To get a primary token that represents the specified user, call the LogonUser function. Alternatively, you can call the
	/// DuplicateTokenEx function to convert an impersonation token into a primary token. This allows a server application that is
	/// impersonating a client to create a process that has the security context of the client.
	/// </para>
	/// <para>
	/// If hToken is a restricted version of the caller's primary token, the <c>SE_ASSIGNPRIMARYTOKEN_NAME</c> privilege is not required.
	/// If the necessary privileges are not already enabled, <c>CreateProcessAsUser</c> enables them for the duration of the call. For
	/// more information, see Running with Special Privileges.
	/// </para>
	/// <para>
	/// <c>Terminal Services:</c> The process is run in the session specified in the token. By default, this is the same session that
	/// called LogonUser. To change the session, use the SetTokenInformation function.
	/// </para>
	/// </param>
	/// <param name="lpApplicationName">
	/// <para>
	/// The name of the module to be executed. This module can be a Windows-based application. It can be some other type of module (for
	/// example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
	/// </para>
	/// <para>
	/// The string can specify the full path and file name of the module to execute or it can specify a partial name. In the case of a
	/// partial name, the function uses the current drive and current directory to complete the specification. The function will not use
	/// the search path. This parameter must include the file name extension; no default extension is assumed.
	/// </para>
	/// <para>
	/// The lpApplicationName parameter can be <c>NULL</c>. In that case, the module name must be the first white space–delimited token
	/// in the lpCommandLine string. If you are using a long file name that contains a space, use quoted strings to indicate where the
	/// file name ends and the arguments begin; otherwise, the file name is ambiguous. For example, consider the string "c:\program
	/// files\sub dir\program name". This string can be interpreted in a number of ways. The system tries to interpret the possibilities
	/// in the following order:
	/// </para>
	/// <para>
	/// <c>c:\program.exe</c><c>c:\program files\sub.exe</c><c>c:\program files\sub dir\program.exe</c><c>c:\program files\sub
	/// dir\program name.exe</c> If the executable module is a 16-bit application, lpApplicationName should be <c>NULL</c>, and the
	/// string pointed to by lpCommandLine should specify the executable module as well as its arguments. By default, all 16-bit
	/// Windows-based applications created by <c>CreateProcessAsUser</c> are run in a separate VDM (equivalent to
	/// <c>CREATE_SEPARATE_WOW_VDM</c> in CreateProcess).
	/// </para>
	/// </param>
	/// <param name="lpCommandLine">
	/// <para>
	/// The command line to be executed. The maximum length of this string is 32K characters. If lpApplicationName is <c>NULL</c>, the
	/// module name portion of lpCommandLine is limited to <c>MAX_PATH</c> characters.
	/// </para>
	/// <para>
	/// The Unicode version of this function, <c>CreateProcessAsUserW</c>, can modify the contents of this string. Therefore, this
	/// parameter cannot be a pointer to read-only memory (such as a <c>const</c> variable or a literal string). If this parameter is a
	/// constant string, the function may cause an access violation.
	/// </para>
	/// <para>
	/// The lpCommandLine parameter can be <c>NULL</c>. In that case, the function uses the string pointed to by lpApplicationName as the
	/// command line.
	/// </para>
	/// <para>
	/// If both lpApplicationName and lpCommandLine are non- <c>NULL</c>, *lpApplicationName specifies the module to execute, and
	/// *lpCommandLine specifies the command line. The new process can use GetCommandLine to retrieve the entire command line. Console
	/// processes written in C can use the argc and argv arguments to parse the command line. Because argv[0] is the module name, C
	/// programmers generally repeat the module name as the first token in the command line.
	/// </para>
	/// <para>
	/// If lpApplicationName is <c>NULL</c>, the first white space–delimited token of the command line specifies the module name. If you
	/// are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin
	/// (see the explanation for the lpApplicationName parameter). If the file name does not contain an extension, .exe is appended.
	/// Therefore, if the file name extension is .com, this parameter must include the .com extension. If the file name ends in a period
	/// (.) with no extension, or if the file name contains a path, .exe is not appended. If the file name does not contain a directory
	/// path, the system searches for the executable file in the following sequence:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>The directory from which the application loaded.</term>
	/// </item>
	/// <item>
	/// <term>The current directory for the parent process.</term>
	/// </item>
	/// <item>
	/// <term>The 32-bit Windows system directory. Use the GetSystemDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>The 16-bit Windows system directory. There is no function that obtains the path of this directory, but it is searched.</term>
	/// </item>
	/// <item>
	/// <term>The Windows directory. Use the GetWindowsDirectory function to get the path of this directory.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The directories that are listed in the PATH environment variable. Note that this function does not search the per-application
	/// path specified by the <c>App Paths</c> registry key. To include this per-application path in the search sequence, use the
	/// ShellExecute function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The system adds a null character to the command line string to separate the file name from the arguments. This divides the
	/// original string into two strings for internal processing.
	/// </para>
	/// </param>
	/// <param name="lpProcessAttributes">
	/// A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new process object and determines
	/// whether child processes can inherit the returned handle to the process. If lpProcessAttributes is <c>NULL</c> or
	/// <c>lpSecurityDescriptor</c> is <c>NULL</c>, the process gets a default security descriptor and the handle cannot be inherited.
	/// The default security descriptor is that of the user referenced in the hToken parameter. This security descriptor may not allow
	/// access for the caller, in which case the process may not be opened again after it is run. The process handle is valid and will
	/// continue to have full access rights.
	/// </param>
	/// <param name="lpThreadAttributes">
	/// A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new thread object and determines
	/// whether child processes can inherit the returned handle to the thread. If lpThreadAttributes is <c>NULL</c> or
	/// <c>lpSecurityDescriptor</c> is <c>NULL</c>, the thread gets a default security descriptor and the handle cannot be inherited. The
	/// default security descriptor is that of the user referenced in the hToken parameter. This security descriptor may not allow access
	/// for the caller.
	/// </param>
	/// <param name="bInheritHandles">
	/// <para>
	/// If this parameter is <c>TRUE</c>, each inheritable handle in the calling process is inherited by the new process. If the
	/// parameter is <c>FALSE</c>, the handles are not inherited. Note that inherited handles have the same value and access rights as
	/// the original handles.
	/// </para>
	/// <para>
	/// <c>Terminal Services:</c> You cannot inherit handles across sessions. Additionally, if this parameter is <c>TRUE</c>, you must
	/// create the process in the same session as the caller.
	/// </para>
	/// <para>
	/// <c>Protected Process Light (PPL) processes:</c> The generic handle inheritance is blocked when a PPL process creates a non-PPL
	/// process since PROCESS_DUP_HANDLE is not allowed from a non-PPL process to a PPL process. See Process Security and Access Rights
	/// </para>
	/// </param>
	/// <param name="dwCreationFlags">
	/// <para>
	/// The flags that control the priority class and the creation of the process. For a list of values, see Process Creation Flags.
	/// </para>
	/// <para>
	/// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the
	/// process's threads. For a list of values, see GetPriorityClass. If none of the priority class flags is specified, the priority
	/// class defaults to <c>NORMAL_PRIORITY_CLASS</c> unless the priority class of the creating process is <c>IDLE_PRIORITY_CLASS</c> or
	/// <c>BELOW_NORMAL_PRIORITY_CLASS</c>. In this case, the child process receives the default priority class of the calling process.
	/// </para>
	/// </param>
	/// <param name="lpEnvironment">
	/// <para>
	/// A pointer to an environment block for the new process. If this parameter is <c>NULL</c>, the new process uses the environment of
	/// the calling process.
	/// </para>
	/// <para>An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:</para>
	/// <para>name=value\0</para>
	/// <para>Because the equal sign is used as a separator, it must not be used in the name of an environment variable.</para>
	/// <para>
	/// An environment block can contain either Unicode or ANSI characters. If the environment block pointed to by lpEnvironment contains
	/// Unicode characters, be sure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>. If this parameter is <c>NULL</c> and
	/// the environment block of the parent process contains Unicode characters, you must also ensure that dwCreationFlags includes <c>CREATE_UNICODE_ENVIRONMENT</c>.
	/// </para>
	/// <para>
	/// The ANSI version of this function, <c>CreateProcessAsUserA</c> fails if the total size of the environment block for the process
	/// exceeds 32,767 characters.
	/// </para>
	/// <para>
	/// Note that an ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block. A
	/// Unicode environment block is terminated by four zero bytes: two for the last string, two more to terminate the block.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> If the size of the combined user and system environment variable exceeds 8192 bytes,
	/// the process created by <c>CreateProcessAsUser</c> no longer runs with the environment block passed to the function by the parent
	/// process. Instead, the child process runs with the environment block returned by the CreateEnvironmentBlock function.
	/// </para>
	/// <para>To retrieve a copy of the environment block for a given user, use the CreateEnvironmentBlock function.</para>
	/// </param>
	/// <param name="lpCurrentDirectory">
	/// <para>The full path to the current directory for the process. The string can also specify a UNC path.</para>
	/// <para>
	/// If this parameter is NULL, the new process will have the same current drive and directory as the calling process. (This feature
	/// is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
	/// </para>
	/// </param>
	/// <param name="lpStartupInfo">
	/// <para>A pointer to a STARTUPINFO or STARTUPINFOEX structure.</para>
	/// <para>
	/// The user must have full access to both the specified window station and desktop. If you want the process to be interactive,
	/// specify winsta0\default. If the <c>lpDesktop</c> member is NULL, the new process inherits the desktop and window station of its
	/// parent process. If this member is an empty string, "", the new process connects to a window station using the rules described in
	/// Process Connection to a Window Station.
	/// </para>
	/// <para>
	/// To set extended attributes, use a STARTUPINFOEX structure and specify <c>EXTENDED_STARTUPINFO_PRESENT</c> in the dwCreationFlags parameter.
	/// </para>
	/// <para>Handles in STARTUPINFO or STARTUPINFOEX must be closed with CloseHandle when they are no longer needed.</para>
	/// <para>
	/// <c>Important</c> The caller is responsible for ensuring that the standard handle fields in STARTUPINFO contain valid handle
	/// values. These fields are copied unchanged to the child process without validation, even when the <c>dwFlags</c> member specifies
	/// <c>STARTF_USESTDHANDLES</c>. Incorrect values can cause the child process to misbehave or crash. Use the Application Verifier
	/// runtime verification tool to detect invalid handles.
	/// </para>
	/// </param>
	/// <param name="lpProcessInformation">
	/// <para>A pointer to a PROCESS_INFORMATION structure that receives identification information about the new process.</para>
	/// <para>Handles in PROCESS_INFORMATION must be closed with CloseHandle when they are no longer needed.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// Note that the function returns before the process has finished initialization. If a required DLL cannot be located or fails to
	/// initialize, the process is terminated. To get the termination status of a process, call GetExitCodeProcess.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>CreateProcessAsUser</c> must be able to open the primary token of the calling process with the <c>TOKEN_DUPLICATE</c> and
	/// <c>TOKEN_IMPERSONATE</c> access rights.
	/// </para>
	/// <para>
	/// By default, <c>CreateProcessAsUser</c> creates the new process on a noninteractive window station with a desktop that is not
	/// visible and cannot receive user input. To enable user interaction with the new process, you must specify the name of the default
	/// interactive window station and desktop, "winsta0\default", in the <c>lpDesktop</c> member of the STARTUPINFO structure. In
	/// addition, before calling <c>CreateProcessAsUser</c>, you must change the discretionary access control list (DACL) of both the
	/// default interactive window station and the default desktop. The DACLs for the window station and desktop must grant access to the
	/// user or the logon session represented by the hToken parameter.
	/// </para>
	/// <para>
	/// <c>CreateProcessAsUser</c> does not load the specified user's profile into the <c>HKEY_USERS</c> registry key. Therefore, to
	/// access the information in the <c>HKEY_CURRENT_USER</c> registry key, you must load the user's profile information into
	/// <c>HKEY_USERS</c> with the LoadUserProfile function before calling <c>CreateProcessAsUser</c>. Be sure to call UnloadUserProfile
	/// after the new process exits.
	/// </para>
	/// <para>
	/// If the lpEnvironment parameter is NULL, the new process inherits the environment of the calling process.
	/// <c>CreateProcessAsUser</c> does not automatically modify the environment block to include environment variables specific to the
	/// user represented by hToken. For example, the USERNAME and USERDOMAIN variables are inherited from the calling process if
	/// lpEnvironment is NULL. It is your responsibility to prepare the environment block for the new process and specify it in lpEnvironment.
	/// </para>
	/// <para>
	/// The CreateProcessWithLogonW and CreateProcessWithTokenW functions are similar to <c>CreateProcessAsUser</c>, except that the
	/// caller does not need to call the LogonUser function to authenticate the user and get a token.
	/// </para>
	/// <para>
	/// <c>CreateProcessAsUser</c> allows you to access the specified directory and executable image in the security context of the
	/// caller or the target user. By default, <c>CreateProcessAsUser</c> accesses the directory and executable image in the security
	/// context of the caller. In this case, if the caller does not have access to the directory and executable image, the function
	/// fails. To access the directory and executable image using the security context of the target user, specify hToken in a call to
	/// the ImpersonateLoggedOnUser function before calling <c>CreateProcessAsUser</c>.
	/// </para>
	/// <para>
	/// The process is assigned a process identifier. The identifier is valid until the process terminates. It can be used to identify
	/// the process, or specified in the OpenProcess function to open a handle to the process. The initial thread in the process is also
	/// assigned a thread identifier. It can be specified in the OpenThread function to open a handle to the thread. The identifier is
	/// valid until the thread terminates and can be used to uniquely identify the thread within the system. These identifiers are
	/// returned in the PROCESS_INFORMATION structure.
	/// </para>
	/// <para>
	/// The calling thread can use the WaitForInputIdle function to wait until the new process has finished its initialization and is
	/// waiting for user input with no input pending. This can be useful for synchronization between parent and child processes, because
	/// <c>CreateProcessAsUser</c> returns without waiting for the new process to finish its initialization. For example, the creating
	/// process would use <c>WaitForInputIdle</c> before trying to find a window associated with the new process.
	/// </para>
	/// <para>
	/// The preferred way to shut down a process is by using the ExitProcess function, because this function sends notification of
	/// approaching termination to all DLLs attached to the process. Other means of shutting down a process do not notify the attached
	/// DLLs. Note that when a thread calls <c>ExitProcess</c>, other threads of the process are terminated without an opportunity to
	/// execute any additional code (including the thread termination code of attached DLLs). For more information, see Terminating a Process.
	/// </para>
	/// <para>Security Remarks</para>
	/// <para>
	/// The lpApplicationName parameter can be NULL, in which case the executable name must be the first white space–delimited string in
	/// lpCommandLine. If the executable or path name has a space in it, there is a risk that a different executable could be run because
	/// of the way the function parses spaces. The following example is dangerous because the function will attempt to run "Program.exe",
	/// if it exists, instead of "MyApp.exe".
	/// </para>
	/// <para>
	/// If a malicious user were to create an application called "Program.exe" on a system, any program that incorrectly calls
	/// <c>CreateProcessAsUser</c> using the Program Files directory will run this application instead of the intended application.
	/// </para>
	/// <para>
	/// To avoid this problem, do not pass NULL for lpApplicationName. If you do pass <c>NULL</c> for lpApplicationName, use quotation
	/// marks around the executable path in lpCommandLine, as shown in the example below.
	/// </para>
	/// <para>
	/// <c>PowerShell:</c> When the <c>CreateProcessAsUser</c> function is used to implement a cmdlet in PowerShell version 2.0, the
	/// cmdlet operates correctly for both fan-in and fan-out remote sessions. Because of certain security scenarios, however, a cmdlet
	/// implemented with <c>CreateProcessAsUser</c> only operates correctly in PowerShell version 3.0 for fan-in remote sessions; fan-out
	/// remote sessions will fail because of insufficient client security privileges. To implement a cmdlet that works for both fan-in
	/// and fan-out remote sessions in PowerShell version 3.0, use the CreateProcess function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Starting an Interactive Client Process.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/processthreadsapi/nf-processthreadsapi-createprocessasusera BOOL
	// CreateProcessAsUserA( HANDLE hToken, LPCSTR lpApplicationName, PSTR lpCommandLine, LPSECURITY_ATTRIBUTES lpProcessAttributes,
	// LPSECURITY_ATTRIBUTES lpThreadAttributes, BOOL bInheritHandles, DWORD dwCreationFlags, LPVOID lpEnvironment, LPCSTR
	// lpCurrentDirectory, LPSTARTUPINFOA lpStartupInfo, LPPROCESS_INFORMATION lpProcessInformation );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("processthreadsapi.h", MSDNShortId = "6b3f4dd9-500b-420e-804a-401a9e188be8")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool CreateProcessAsUser(HTOKEN hToken, [Optional] string? lpApplicationName, [Optional] StringBuilder? lpCommandLine,
		[Optional] SECURITY_ATTRIBUTES? lpProcessAttributes, [Optional] SECURITY_ATTRIBUTES? lpThreadAttributes, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandles,
		CREATE_PROCESS dwCreationFlags, [In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")] string[]? lpEnvironment,
		[Optional] string? lpCurrentDirectory, in STARTUPINFOEX lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);
}