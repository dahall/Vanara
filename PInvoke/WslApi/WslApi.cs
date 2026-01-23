namespace Vanara.PInvoke
{
	/// <summary>Items from the WslApi.dll.</summary>
	public static partial class WslApi
	{
		private const string Lib_WslApi = "wslapi.dll";

		/// <summary>
		/// The <c>WSL_DISTRIBUTION_FLAGS</c> enumeration specifies the behavior of a distribution in the Windows Subsystem for Linux (WSL).
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wslapi/ne-wslapi-wsl_distribution_flags typedef enum {
		// WSL_DISTRIBUTION_FLAGS_NONE = 0x0, WSL_DISTRIBUTION_FLAGS_ENABLE_INTEROP = 0x1, WSL_DISTRIBUTION_FLAGS_APPEND_NT_PATH = 0x2,
		// WSL_DISTRIBUTION_FLAGS_ENABLE_DRIVE_MOUNTING = 0x4 } WSL_DISTRIBUTION_FLAGS;
		[PInvokeData("wslapi.h", MSDNShortId = "NE:wslapi.WSL_DISTRIBUTION_FLAGS")]
		[Flags]
		public enum WSL_DISTRIBUTION_FLAGS
		{
			/// <summary>
			/// <para>Value: 0x0</para>
			/// <para>No flags are being supplied.</para>
			/// </summary>
			WSL_DISTRIBUTION_FLAGS_NONE = 0x0,

			/// <summary>
			/// <para>Value: 0x1</para>
			/// <para>
			/// Allow the distribution to interoperate with Windows processes (for example, the user can invoke "cmd.exe" or "notepad.exe"
			/// from within a WSL session).
			/// </para>
			/// </summary>
			WSL_DISTRIBUTION_FLAGS_ENABLE_INTEROP = 0x1,

			/// <summary>
			/// <para>Value: 0x2</para>
			/// <para>Add the Windows %PATH% environment variable values to WSL sessions.</para>
			/// </summary>
			WSL_DISTRIBUTION_FLAGS_APPEND_NT_PATH = 0x2,

			/// <summary>
			/// <para>Value: 0x4</para>
			/// <para>Automatically mount Windows drives inside of WSL sessions (for example, "C:" will be available under "/mnt/c").</para>
			/// </summary>
			WSL_DISTRIBUTION_FLAGS_ENABLE_DRIVE_MOUNTING = 0x4,

			/// <summary/>
			WSL_DISTRIBUTION_FLAGS_VALID = WSL_DISTRIBUTION_FLAGS_ENABLE_INTEROP | WSL_DISTRIBUTION_FLAGS_APPEND_NT_PATH | WSL_DISTRIBUTION_FLAGS_ENABLE_DRIVE_MOUNTING,

			/// <summary/>
			WSL_DISTRIBUTION_FLAGS_DEFAULT = WSL_DISTRIBUTION_FLAGS_ENABLE_INTEROP | WSL_DISTRIBUTION_FLAGS_APPEND_NT_PATH | WSL_DISTRIBUTION_FLAGS_ENABLE_DRIVE_MOUNTING,
		}

		/// <summary>Modifies the behavior of a distribution registered with the Windows Subsystem for Linux (WSL).</summary>
		/// <param name="distributionName">Unique name representing a distribution (for example, "Fabrikam.Distro.10.01").</param>
		/// <param name="defaultUID">The Linux user ID to use when launching new WSL sessions for this distribution.</param>
		/// <param name="wslDistributionFlags">Flags specifying what behavior to use for this distribution.</param>
		/// <returns>Returns S_OK on success, or a failing HRESULT otherwise.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wslapi/nf-wslapi-wslconfiguredistribution HRESULT WslConfigureDistribution(
		// PCWSTR distributionName, ULONG defaultUID, WSL_DISTRIBUTION_FLAGS wslDistributionFlags );
		[PInvokeData("wslapi.h", MSDNShortId = "NF:wslapi.WslConfigureDistribution")]
		[DllImport(Lib_WslApi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern HRESULT WslConfigureDistribution(string distributionName, uint defaultUID, WSL_DISTRIBUTION_FLAGS wslDistributionFlags);

		/// <summary>Retrieves the current configuration of a distribution registered with the Windows Subsystem for Linux (WSL).</summary>
		/// <param name="distributionName">Unique name representing a distribution (for example, "Fabrikam.Distro.10.01").</param>
		/// <param name="distributionVersion">The version of WSL for which this distribution is configured.</param>
		/// <param name="defaultUID">The default user ID used when launching new WSL sessions for this distribution.</param>
		/// <param name="wslDistributionFlags">The flags governing the behavior of this distribution.</param>
		/// <param name="defaultEnvironmentVariables">
		/// The address of a pointer to an array of default environment variable strings used when launching new WSL sessions for this distribution.
		/// </param>
		/// <param name="defaultEnvironmentVariableCount">The number of elements in <c>pDefaultEnvironmentVariablesArray</c>.</param>
		/// <returns>Returns S_OK on success, or a failing HRESULT otherwise.</returns>
		/// <remarks>
		/// The caller is responsible for freeing each string in <c>pDefaultEnvironmentVariablesArray</c> (and the array itself) via <c>CoTaskMemFree</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wslapi/nf-wslapi-wslgetdistributionconfiguration HRESULT
		// WslGetDistributionConfiguration( [in] PCWSTR distributionName, [out] ULONG *distributionVersion, [out] ULONG *defaultUID, [out]
		// WSL_DISTRIBUTION_FLAGS *wslDistributionFlags, [out] StrPtrAnsi **defaultEnvironmentVariables, [out] ULONG
		// *defaultEnvironmentVariableCount );
		[PInvokeData("wslapi.h", MSDNShortId = "NF:wslapi.WslGetDistributionConfiguration")]
		[DllImport(Lib_WslApi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern HRESULT WslGetDistributionConfiguration(string distributionName, out uint distributionVersion, out uint defaultUID,
			out WSL_DISTRIBUTION_FLAGS wslDistributionFlags,
			[Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 5)] out string[] defaultEnvironmentVariables,
			out uint defaultEnvironmentVariableCount);

		/// <summary>Determines if a distribution is registered with the Windows Subsystem for Linux (WSL).</summary>
		/// <param name="distributionName">Unique name representing a distribution (for example, "Fabrikam.Distro.10.01").</param>
		/// <returns>Returns TRUE if the supplied distribution is currently registered, or FALSE otherwise.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wslapi/nf-wslapi-wslisdistributionregistered BOOL WslIsDistributionRegistered(
		// PCWSTR distributionName );
		[PInvokeData("wslapi.h", MSDNShortId = "NF:wslapi.WslIsDistributionRegistered")]
		[DllImport(Lib_WslApi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WslIsDistributionRegistered(string distributionName);

		/// <summary>Launches a Windows Subsystem for Linux (WSL) process in the context of a particular distribution.</summary>
		/// <param name="distributionName">Unique name representing a distribution (for example, "Fabrikam.Distro.10.01").</param>
		/// <param name="command">Command to execute. If no command is supplied, launches the default shell.</param>
		/// <param name="useCurrentWorkingDirectory">
		/// Governs whether or not the launched process should inherit the calling process's working directory. If FALSE, the process is
		/// started in the WSL default user's home directory ("~").
		/// </param>
		/// <param name="stdIn">Handle to use for <c>STDIN</c>.</param>
		/// <param name="stdOut">Handle to use for <c>STDOUT</c>.</param>
		/// <param name="stdErr">Handle to use for <c>STDERR</c>.</param>
		/// <param name="process">Pointer to address to receive the process HANDLE associated with the newly-launched WSL process.</param>
		/// <returns>Returns S_OK on success, or a failing HRESULT otherwise.</returns>
		/// <remarks>Caller is responsible for calling <c>CloseHandle</c> on the value returned in <c>phProcess</c> on success.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wslapi/nf-wslapi-wsllaunch HRESULT WslLaunch( [in] PCWSTR distributionName,
		// [in, optional] PCWSTR command, [in] BOOL useCurrentWorkingDirectory, [in] HANDLE stdIn, [in] HANDLE stdOut, [in] HANDLE stdErr,
		// [out] HANDLE *process );
		[PInvokeData("wslapi.h", MSDNShortId = "NF:wslapi.WslLaunch")]
		[DllImport(Lib_WslApi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern HRESULT WslLaunch(string distributionName, [In, Optional] string? command,
			[MarshalAs(UnmanagedType.Bool)] bool useCurrentWorkingDirectory, [In] HFILE stdIn, [In] HFILE stdOut,
			[In] HFILE stdErr, out HPROCESS process);

		/// <summary>
		/// Launches an interactive Windows Subsystem for Linux (WSL) process in the context of a particular distribution.This differs from
		/// WslLaunch in that the end user will be able to interact with the newly-created process.
		/// </summary>
		/// <param name="distributionName">Unique name representing a distribution (for example, "Fabrikam.Distro.10.01").</param>
		/// <param name="command">Command to execute. If no command is supplied, launches the default shell.</param>
		/// <param name="useCurrentWorkingDirectory">
		/// Governs whether or not the launched process should inherit the calling process's working directory. If FALSE, the process is
		/// started in the WSL default user's home directory ("~").
		/// </param>
		/// <param name="exitCode">Receives the exit code of the process after it exits.</param>
		/// <returns>Returns S_OK on success, or a failing HRESULT otherwise.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wslapi/nf-wslapi-wsllaunchinteractive HRESULT WslLaunchInteractive( [in]
		// PCWSTR distributionName, [in, optional] PCWSTR command, [in] BOOL useCurrentWorkingDirectory, [out] DWORD *exitCode );
		[PInvokeData("wslapi.h", MSDNShortId = "NF:wslapi.WslLaunchInteractive")]
		[DllImport(Lib_WslApi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern HRESULT WslLaunchInteractive(string distributionName, [In, Optional] string? command,
			[MarshalAs(UnmanagedType.Bool)] bool useCurrentWorkingDirectory, out uint exitCode);

		/// <summary>Registers a new distribution with the Windows Subsystem for Linux (WSL).</summary>
		/// <param name="distributionName">Unique name representing a distribution (for example, "Fabrikam.Distro.10.01").</param>
		/// <param name="tarGzFilename">Full path to a .tar.gz file containing the file system of the distribution to register.</param>
		/// <returns>
		/// <para>
		/// This function can return one of the following values. Use the SUCCEEDED and FAILED macros to test the return value of this function.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Return Code</c></description>
		/// <description><c>Description</c></description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>Distribution successfully registered with the Windows Subsystem for Linux.</description>
		/// </item>
		/// <item>
		/// <description>HRESULT_FROM_WIN32(ERROR_ALREADY_EXISTS)</description>
		/// <description>Failed because a distribution with this name has already been registered.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wslapi/nf-wslapi-wslregisterdistribution HRESULT WslRegisterDistribution( [in]
		// PCWSTR distributionName, [in] PCWSTR tarGzFilename );
		[PInvokeData("wslapi.h", MSDNShortId = "NF:wslapi.WslRegisterDistribution")]
		[DllImport(Lib_WslApi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern HRESULT WslRegisterDistribution(string distributionName, string tarGzFilename);

		/// <summary>Unregisters a distribution from the Windows Subsystem for Linux (WSL).</summary>
		/// <param name="distributionName">Unique name representing a distribution (for example, "Fabrikam.Distro.10.01").</param>
		/// <returns>Returns S_OK on success, or a failing HRESULT otherwise.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wslapi/nf-wslapi-wslunregisterdistribution HRESULT WslUnregisterDistribution(
		// [in] PCWSTR distributionName );
		[PInvokeData("wslapi.h", MSDNShortId = "NF:wslapi.WslUnregisterDistribution")]
		[DllImport(Lib_WslApi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern HRESULT WslUnregisterDistribution(string distributionName);
	}
}