using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Flags that indicate how the values included in <see cref="ACTCTX"/> are to be used.</summary>
		[Flags]
		[PInvokeData("Winbase.h")]
		public enum ActCtxFlags
		{
			/// <summary>No values are set.</summary>
			ACTCTX_FLAG_NONE = 0x00000000,

			/// <summary>The <see cref="ACTCTX.wProcessorArchitecture"/> value is set.</summary>
			ACTCTX_FLAG_PROCESSOR_ARCHITECTURE_VALID = 0x00000001,

			/// <summary>The <see cref="ACTCTX.wLangId"/> value is set.</summary>
			ACTCTX_FLAG_LANGID_VALID = 0x00000002,

			/// <summary>The <see cref="ACTCTX.lpAssemblyDirectory"/> value is set.</summary>
			ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID = 0x00000004,

			/// <summary>The <see cref="ACTCTX.lpResourceName"/> value is set.</summary>
			ACTCTX_FLAG_RESOURCE_NAME_VALID = 0x00000008,

			/// <summary>Set the activation context to be the process default when calling <see cref="CreateActCtx"/>.</summary>
			ACTCTX_FLAG_SET_PROCESS_DEFAULT = 0x00000010,

			/// <summary>The <see cref="ACTCTX.lpApplicationName"/> value is set.</summary>
			ACTCTX_FLAG_APPLICATION_NAME_VALID = 0x00000020,

			/// <summary>Use when calling <see cref="CreateActCtx"/> to identify that <see cref="ACTCTX.lpSource"/> contains an assembly identifier.</summary>
			ACTCTX_FLAG_SOURCE_IS_ASSEMBLYREF = 0x00000040,

			/// <summary>The <see cref="ACTCTX.hModule"/> value is set.</summary>
			ACTCTX_FLAG_HMODULE_VALID = 0x00000080
		}

		/// <summary></summary>
		[Flags]
		[PInvokeData("Winbase.h", MSDNShortId = "aa373344")]
		public enum ApplicationRestartFlags
		{
			/// <summary>Do not restart the process if it terminates due to an unhandled exception.</summary>
			RESTART_NO_CRASH = 1,

			/// <summary>Do not restart the process if it terminates due to the application not responding.</summary>
			RESTART_NO_HANG = 2,

			/// <summary>Do not restart the process if it terminates due to the installation of an update.</summary>
			RESTART_NO_PATCH = 4,

			/// <summary>Do not restart the process if the computer is restarted as the result of an update.</summary>
			RESTART_NO_REBOOT = 8,
		}

		[PInvokeData("Winbase.h")]
		public enum DeactivateActCtxFlag
		{
			/// <summary>
			/// If this value is set and the cookie specified in the ulCookie parameter is in the top frame of the activation stack, the activation context is
			/// popped from the stack and thereby deactivated.
			/// <para>
			/// If this value is set and the cookie specified in the ulCookie parameter is not in the top frame of the activation stack, this function searches
			/// down the stack for the cookie.
			/// </para>
			/// <para>If the cookie is found, a STATUS_SXS_EARLY_DEACTIVATION exception is thrown.</para>
			/// <para>If the cookie is not found, a STATUS_SXS_INVALID_DEACTIVATION exception is thrown.</para>
			/// <para>This value should be specified in most cases.</para>
			/// </summary>
			None = 0,

			/// <summary>
			/// If this value is set and the cookie specified in the ulCookie parameter is in the top frame of the activation stack, the function returns an
			/// ERROR_INVALID_PARAMETER error code. Call GetLastError to obtain this code.
			/// <para>If this value is set and the cookie is not on the activation stack, a STATUS_SXS_INVALID_DEACTIVATION exception will be thrown.</para>
			/// <para>
			/// If this value is set and the cookie is in a lower frame of the activation stack, all of the frames down to and including the frame the cookie is
			/// in is popped from the stack.
			/// </para>
			/// </summary>
			DEACTIVATE_ACTCTX_FLAG_FORCE_EARLY_DEACTIVATION = 1
		}

		/// <summary>
		/// Application-defined callback function used to save data and application state information in the event the application encounters an unhandled
		/// exception or becomes unresponsive.
		/// </summary>
		/// <param name="pvParameter">Context information specified when you called the RegisterApplicationRecoveryCallback function to register for recovery.</param>
		/// <returns>The return value is not used and should be 0.</returns>
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa373202")]
		public delegate uint ApplicationRecoveryCallback(IntPtr pvParameter);

		/// <summary>
		/// The ActivateActCtx function activates the specified activation context. It does this by pushing the specified activation context to the top of the
		/// activation stack. The specified activation context is thus associated with the current thread and any appropriate side-by-side API functions.
		/// </summary>
		/// <param name="hActCtx">Handle to an ACTCTX structure that contains information on the activation context that is to be made active.</param>
		/// <param name="lpCookie">Pointer to a ULONG_PTR that functions as a cookie, uniquely identifying a specific, activated activation context.</param>
		/// <returns>If the function succeeds, it returns TRUE. Otherwise, it returns FALSE. This function sets errors that can be retrieved by calling GetLastError.</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa374151")]
		public static extern bool ActivateActCtx(ActCtxSafeHandle hActCtx, out IntPtr lpCookie);

		/// <summary>Indicates that the calling application has completed its data recovery.</summary>
		/// <param name="bSuccess">Specify TRUE to indicate that the data was successfully recovered; otherwise, FALSE.</param>
		[DllImport(Lib.Kernel32, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa373328")]
		public static extern void ApplicationRecoveryFinished([MarshalAs(UnmanagedType.Bool)] bool bSuccess);

		/// <summary>Indicates that the calling application is continuing to recover data.</summary>
		/// <param name="pbCanceled">Indicates whether the user has canceled the recovery process. Set by WER if the user clicks the Cancel button.</param>
		/// <returns>This function returns S_OK on success or one of the following error codes.</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa373329")]
		public static extern HRESULT ApplicationRecoveryInProgress([Out, MarshalAs(UnmanagedType.Bool)] out bool pbCanceled);

		/// <summary>The CreateActCtx function creates an activation context.</summary>
		/// <param name="actctx">Pointer to an ACTCTX structure that contains information about the activation context to be created.</param>
		/// <returns>If the function succeeds, it returns a handle to the returned activation context. Otherwise, it returns INVALID_HANDLE_VALUE.</returns>
		[DllImport(Lib.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa375125")]
		public static extern ActCtxSafeHandle CreateActCtx(ref ACTCTX actctx);

		/// <summary>The DeactivateActCtx function deactivates the activation context corresponding to the specified cookie.</summary>
		/// <param name="dwFlags">Flags that indicate how the deactivation is to occur.</param>
		/// <param name="lpCookie">
		/// The ULONG_PTR that was passed into the call to ActivateActCtx. This value is used as a cookie to identify a specific activated activation context.
		/// </param>
		/// <returns>If the function succeeds, it returns TRUE. Otherwise, it returns FALSE. This function sets errors that can be retrieved by calling GetLastError.</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa375140")]
		public static extern bool DeactivateActCtx(DeactivateActCtxFlag dwFlags, IntPtr lpCookie);

		/// <summary>
		/// Retrieves a pointer to the callback routine registered for the specified process. The address returned is in the virtual address space of the process.
		/// </summary>
		/// <param name="hProcess">A handle to the process. This handle must have the PROCESS_VM_READ access right.</param>
		/// <param name="pRecoveryCallback">A pointer to the recovery callback function. For more information, see ApplicationRecoveryCallback.</param>
		/// <param name="ppvParameter">A pointer to the callback parameter.</param>
		/// <param name="pdwPingInterval">The recovery ping interval, in 100-nanosecond intervals.</param>
		/// <param name="pdwFlags">Reserved for future use.</param>
		/// <returns>This function returns S_OK on success.</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa373343")]
		public static extern HRESULT GetApplicationRecoveryCallback(IntPtr hProcess, out ApplicationRecoveryCallback pRecoveryCallback, out IntPtr ppvParameter, out uint pdwPingInterval, out int pdwFlags);

		/// <summary>Retrieves the restart information registered for the specified process.</summary>
		/// <param name="hProcess">A handle to the process. This handle must have the PROCESS_VM_READ access right.</param>
		/// <param name="pwzCommandline">
		/// A pointer to a buffer that receives the restart command line specified by the application when it called the RegisterApplicationRestart function. The
		/// maximum size of the command line, in characters, is RESTART_MAX_CMD_LINE. Can be NULL if pcchSize is zero.
		/// </param>
		/// <param name="pcchSize">
		/// On input, specifies the size of the pwzCommandLine buffer, in characters.
		/// <para>
		/// If the buffer is not large enough to receive the command line, the function fails with HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) and sets this
		/// parameter to the required buffer size, in characters.
		/// </para>
		/// <para>On output, specifies the size of the buffer that was used.</para>
		/// <para>
		/// To determine the required buffer size, set pwzCommandLine to NULL and this parameter to zero. The size includes one for the null-terminator
		/// character. Note that the function returns S_OK, not HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER) in this case.
		/// </para>
		/// </param>
		/// <param name="pdwFlags">
		/// A pointer to a variable that receives the flags specified by the application when it called the RegisterApplicationRestart function.
		/// </param>
		/// <returns>This function returns S_OK on success</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa373344")]
		public static extern HRESULT GetApplicationRestartSettings(IntPtr hProcess, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwzCommandline, ref uint pcchSize, out ApplicationRestartFlags pdwFlags);

		/// <summary>The GetCurrentActCtx function returns the handle to the active activation context of the calling thread.</summary>
		/// <param name="handle">Pointer to the returned ACTCTX structure that contains information on the active activation context.</param>
		/// <returns>If the function succeeds, it returns TRUE. Otherwise, it returns FALSE. This function sets errors that can be retrieved by calling GetLastError.</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa375152")]
		public static extern bool GetCurrentActCtx(out ActCtxSafeHandle handle);

		/// <summary>Registers the active instance of an application for recovery.</summary>
		/// <param name="pRecoveryCallback">A pointer to the recovery callback function. For more information, see ApplicationRecoveryCallback.</param>
		/// <param name="pvParameter">A pointer to a variable to be passed to the callback function. Can be NULL.</param>
		/// <param name="dwPingInterval">
		/// The recovery ping interval, in milliseconds. By default, the interval is 5 seconds (RECOVERY_DEFAULT_PING_INTERVAL). The maximum interval is 5
		/// minutes. If you specify zero, the default interval is used.
		/// <para>
		/// You must call the ApplicationRecoveryInProgress function within the specified interval to indicate to ARR that you are still actively recovering;
		/// otherwise, WER terminates recovery. Typically, you perform recovery in a loop with each iteration lasting no longer than the ping interval. Each
		/// iteration performs a block of recovery work followed by a call to ApplicationRecoveryInProgress. Since you also use ApplicationRecoveryInProgress to
		/// determine if the user wants to cancel recovery, you should consider a smaller interval, so you do not perform a lot of work unnecessarily.
		/// </para>
		/// </param>
		/// <param name="dwFlags">Reserved for future use. Set to zero.</param>
		/// <returns>This function returns S_OK on success</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa373345")]
		public static extern HRESULT RegisterApplicationRecoveryCallback(ApplicationRecoveryCallback pRecoveryCallback, IntPtr pvParameter, uint dwPingInterval, uint dwFlags);

		/// <summary>Registers the active instance of an application for restart.</summary>
		/// <param name="pwzCommandline">
		/// A string that specifies the command-line arguments for the application when it is restarted. The maximum size of the command line that you can
		/// specify is RESTART_MAX_CMD_LINE characters. Do not include the name of the executable in the command line; this function adds it for you.
		/// <para>
		/// If this parameter is NULL or an empty string, the previously registered command line is removed. If the argument contains spaces, use quotes around
		/// the argument.
		/// </para>
		/// </param>
		/// <param name="dwFlags">Options</param>
		/// <returns>This function returns S_OK on success</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa373347")]
		public static extern HRESULT RegisterApplicationRestart([MarshalAs(UnmanagedType.BStr)] string pwzCommandline, ApplicationRestartFlags dwFlags);

		/// <summary>The ReleaseActCtx function decrements the reference count of the specified activation context.</summary>
		/// <param name="hActCtx">
		/// Handle to the ACTCTX structure that contains information on the activation context for which the reference count is to be decremented.
		/// </param>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa375713")]
		public static extern void ReleaseActCtx(IntPtr hActCtx);

		/// <summary>Removes the active instance of an application from the recovery list.</summary>
		/// <remarks>You do not need to call this function before exiting. You need to remove the registration only if you choose to not recover data.</remarks>
		/// <returns>This function returns S_OK on success</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa373348")]
		public static extern HRESULT UnregisterApplicationRecoveryCallback();

		/// <summary>Removes the active instance of an application from the restart list.</summary>
		/// <remarks>
		/// You do not need to call this function before exiting. You need to remove the registration only if you choose to not restart the application. For
		/// example, you could remove the registration if your application entered a corrupted state where a future restart would also fail. You must call this
		/// function before the application fails abnormally.
		/// </remarks>
		/// <returns>This function returns S_OK on success</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa373349")]
		public static extern HRESULT UnregisterApplicationRestart();

		/// <summary>The ACTCTX structure is used by the CreateActCtx function to create the activation context.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa374149")]
		public struct ACTCTX
		{
			/// <summary>The size, in bytes, of this structure. This is used to determine the version of this structure.</summary>
			public int cbSize;

			/// <summary>
			/// Flags that indicate how the values included in this structure are to be used. Set any undefined bits in dwFlags to 0. If any undefined bits are
			/// not set to 0, the call to CreateActCtx that creates the activation context fails and returns an invalid parameter error code.
			/// </summary>
			public ActCtxFlags dwFlags;

			/// <summary>
			/// Null-terminated string specifying the path of the manifest file or PE image to be used to create the activation context. If this path refers to
			/// an EXE or DLL file, the lpResourceName member is required.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpSource;

			/// <summary>Identifies the type of processor used. Specifies the system's processor architecture.</summary>
			public ProcessorArchitecture wProcessorArchitecture;

			/// <summary>
			/// Specifies the language manifest that should be used. The default is the current user's current UI language.
			/// <para>If the requested language cannot be found, an approximation is searched for using the following order:</para>
			/// <list type="bullet">
			/// <item>
			/// <description>The current user's specific language. For example, for US English (1033).</description>
			/// </item>
			/// <item>
			/// <description>The current user's primary language. For example, for English (9).</description>
			/// </item>
			/// <item>
			/// <description>The current system's specific language.</description>
			/// </item>
			/// <item>
			/// <description>The current system's primary language.</description>
			/// </item>
			/// <item>
			/// <description>A nonspecific worldwide language. Language neutral (0).</description>
			/// </item>
			/// </list>
			/// </summary>
			public ushort wLangId;

			/// <summary>
			/// The base directory in which to perform private assembly probing if assemblies in the activation context are not present in the system-wide store.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpAssemblyDirectory;

			/// <summary>
			/// Pointer to a null-terminated string that contains the resource name to be loaded from the PE specified in hModule or lpSource. If the resource
			/// name is an integer, set this member using MAKEINTRESOURCE. This member is required if lpSource refers to an EXE or DLL.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpResourceName;

			/// <summary>
			/// The name of the current application. If the value of this member is set to null, the name of the executable that launched the current process is used.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpApplicationName;

			/// <summary>
			/// Use this member rather than lpSource if you have already loaded a DLL and wish to use it to create activation contexts rather than using a path
			/// in lpSource. See lpResourceName for the rules of looking up resources in this module.
			/// </summary>
			public IntPtr hModule;

			/// <summary>Initializes a new instance of the <see cref="ACTCTX"/> struct.</summary>
			/// <param name="source">The source.</param>
			public ACTCTX(string source) : this()
			{
				cbSize = Marshal.SizeOf(typeof(ACTCTX));
				lpSource = source;
			}

			/// <summary>The empty</summary>
			public static ACTCTX Empty = new ACTCTX { cbSize = Marshal.SizeOf(typeof(ACTCTX)) };
		}

		/// <summary>A safe handle for an Activation Context.</summary>
		/// <seealso cref="GenericSafeHandle"/>
		[PInvokeData("Winbase.h")]
		public class ActCtxSafeHandle : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="ActCtxSafeHandle"/> class.</summary>
			public ActCtxSafeHandle() : base(ReleaseHandle) { }

			/// <summary>Initializes a new instance of the <see cref="ActCtxSafeHandle"/> class.</summary>
			/// <param name="hActCtx">The h act CTX.</param>
			/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
			public ActCtxSafeHandle(IntPtr hActCtx, bool ownsHandle) : base(hActCtx, ReleaseHandle, ownsHandle) { }

			private static bool ReleaseHandle(IntPtr handle)
			{
				ReleaseActCtx(handle);
				return true;
			}
		}
	}
}