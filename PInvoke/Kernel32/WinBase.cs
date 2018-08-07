using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/*/// <summary>
		/// Formats a message string. The function requires a message definition as input. The message definition can come from a message
		/// table resource in an already-loaded module. Or the caller can ask the function to search the system's message table resource(s)
		/// for the message definition. The function finds the message definition in a message table resource based on a message identifier
		/// and a language identifier. The function returns the formatted message text, processing any embedded insert sequences if
		/// requested. </summary> <param name="formatString">Pointer to a string that consists of unformatted message text. It will be
		/// scanned for inserts and formatted accordingly.</param> <param name="args"> An array of values that are used as insert values in
		/// the formatted message. A %1 in the format string indicates the first value in the Arguments array; a %2 indicates the second
		/// argument; and so on. The interpretation of each value depends on the formatting information associated with the insert in the
		/// message definition. Each insert must have a corresponding element in the array. </param> <param name="flags"> The formatting
		/// options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function handles line
		/// breaks in the output buffer. The low-order byte can also specify the maximum width of a formatted output line. </param> <returns>
		/// If the function succeeds, the return value is the string that specifies the formatted message. To get extended error information,
		/// call GetLastError. </returns>
		[PInvokeData("WinBase.h", MSDNShortId = "ms679351")]
		private static string FormatMessage(string formatString, object[] args, FormatMessageFlags flags = 0)
		{
			if (string.IsNullOrEmpty(formatString) || args == null || args.Length == 0 || flags.IsFlagSet(FormatMessageFlags.FORMAT_MESSAGE_IGNORE_INSERTS)) return formatString;
			flags &= ~(FormatMessageFlags.FORMAT_MESSAGE_FROM_HMODULE | FormatMessageFlags.FORMAT_MESSAGE_FROM_SYSTEM);
			flags |= FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING | FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER | FormatMessageFlags.FORMAT_MESSAGE_ARGUMENT_ARRAY;
			var ptr = IntPtr.Zero;
			var s = new SafeCoTaskMemString(formatString);
			var m = new DynamicMethod("FormatMessage", typeof(void), new Type[0], typeof(Kernel32), true);
			var il = m.GetILGenerator();

			// TODO: Finish work here to push args onto stack and dynamically call method.
			il.Emit(OpCodes.Ldstr, formatString);
			il.Emit(OpCodes.Ldind_I, 0);
			il.Emit(OpCodes.Ldind_U4, 0);
			il.Emit(OpCodes.Ldind_U4, 0);
			il.EmitCall(OpCodes.Call, typeof(Kernel32).GetMethod("FormatMessage", BindingFlags.Public | BindingFlags.Static), new Type[] { typeof(string), typeof(IntPtr), typeof(uint), typeof(uint), typeof(int) });
			il.Emit(OpCodes.Pop);
			il.Emit(OpCodes.Ret);

			//var action = (Action)m.CreateDelegate(Action);
			//action.Invoke();

			//if (ret == 0) Win32Error.ThrowLastError();
			return new SafeLocalHandle(ptr, 0).ToString(-1);
		}*/

		/// <summary>All active processors in the system.</summary>
		public const ushort ALL_PROCESSOR_GROUPS = 0xffff;

		/// <summary>
		/// An application-defined callback function used with the CopyFileEx, MoveFileTransacted, and MoveFileWithProgress functions. It is
		/// called when a portion of a copy or move operation is completed. The <c>LPPROGRESS_ROUTINE</c> type defines a pointer to this
		/// callback function. <c>CopyProgressRoutine</c> is a placeholder for the application-defined function name.
		/// </summary>
		/// <param name="TotalFileSize">
		/// <para>The total size of the file, in bytes.</para>
		/// </param>
		/// <param name="TotalBytesTransferred">
		/// <para>The total number of bytes transferred from the source file to the destination file since the copy operation began.</para>
		/// </param>
		/// <param name="StreamSize">
		/// <para>The total size of the current file stream, in bytes.</para>
		/// </param>
		/// <param name="StreamBytesTransferred">
		/// <para>
		/// The total number of bytes in the current stream that have been transferred from the source file to the destination file since the
		/// copy operation began.
		/// </para>
		/// </param>
		/// <param name="dwStreamNumber">
		/// <para>A handle to the current stream. The first time <c>CopyProgressRoutine</c> is called, the stream number is 1.</para>
		/// </param>
		/// <param name="dwCallbackReason">
		/// <para>The reason that <c>CopyProgressRoutine</c> was called. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CALLBACK_CHUNK_FINISHED 0x00000000</term>
		/// <term>Another part of the data file was copied.</term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_STREAM_SWITCH 0x00000001</term>
		/// <term>
		/// Another stream was created and is about to be copied. This is the callback reason given when the callback routine is first invoked.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hSourceFile">
		/// <para>A handle to the source file.</para>
		/// </param>
		/// <param name="hDestinationFile">
		/// <para>A handle to the destination file</para>
		/// </param>
		/// <param name="lpData">
		/// <para>Argument passed to <c>CopyProgressRoutine</c> by CopyFileEx, MoveFileTransacted, or MoveFileWithProgress.</para>
		/// </param>
		/// <returns>
		/// <para>The <c>CopyProgressRoutine</c> function should return one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PROGRESS_CANCEL 1</term>
		/// <term>Cancel the copy operation and delete the destination file.</term>
		/// </item>
		/// <item>
		/// <term>PROGRESS_CONTINUE 0</term>
		/// <term>Continue the copy operation.</term>
		/// </item>
		/// <item>
		/// <term>PROGRESS_QUIET 3</term>
		/// <term>Continue the copy operation, but stop invoking CopyProgressRoutine to report progress.</term>
		/// </item>
		/// <item>
		/// <term>PROGRESS_STOP 2</term>
		/// <term>Stop the copy operation. It can be restarted at a later time.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can use this information to display a progress bar that shows the total number of bytes copied as a percent of the
		/// total file size.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nc-winbase-lpprogress_routine LPPROGRESS_ROUTINE LpprogressRoutine;
		// DWORD LpprogressRoutine( LARGE_INTEGER TotalFileSize, LARGE_INTEGER TotalBytesTransferred, LARGE_INTEGER StreamSize, LARGE_INTEGER
		// StreamBytesTransferred, DWORD dwStreamNumber, DWORD dwCallbackReason, HANDLE hSourceFile, HANDLE hDestinationFile, LPVOID lpData ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "2c02b212-d4ac-4b01-8955-2561d8c42b1b")]
		public delegate COPYFILE_CALLBACK_RESULT LpprogressRoutine(long TotalFileSize, long TotalBytesTransferred, long StreamSize, long StreamBytesTransferred, uint dwStreamNumber, COPYFILE_CALLBACK dwCallbackReason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData);

		/// <summary>
		/// <para>
		/// An application-defined callback function used with the CopyFile2 function. It is called when a portion of a copy or move
		/// operation is completed. The <c>PCOPYFILE2_PROGRESS_ROUTINE</c> type defines a pointer to this callback function.
		/// <c>CopyFile2ProgressRoutine</c> is a placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="pMessage">
		/// <para>Pointer to a COPYFILE2_MESSAGE structure.</para>
		/// </param>
		/// <param name="pvCallbackContext">
		/// <para>Copy of value passed in the <c>pvCallbackContext</c> member of the COPYFILE2_EXTENDED_PARAMETERS structure passed to CopyFile2.</para>
		/// </param>
		/// <returns>
		/// <para>Value from the COPYFILE2_MESSAGE_ACTION enumeration indicating what action should be taken.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>COPYFILE2_PROGRESS_CONTINUE 0</term>
		/// <term>Continue the copy operation.</term>
		/// </item>
		/// <item>
		/// <term>COPYFILE2_PROGRESS_CANCEL 1</term>
		/// <term>Cancel the copy operation. The CopyFile2 function will fail, return and any partially copied fragments will be deleted.</term>
		/// </item>
		/// <item>
		/// <term>COPYFILE2_PROGRESS_STOP 2</term>
		/// <term>
		/// Stop the copy operation. The CopyFile2 function will fail, return and any partially copied fragments will be left intact. The
		/// operation can be restarted using the COPY_FILE_RESUME_FROM_PAUSE flag only if COPY_FILE_RESTARTABLE was set in the dwCopyFlags
		/// member of the COPYFILE2_EXTENDED_PARAMETERS structure passed to the CopyFile2 function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>COPYFILE2_PROGRESS_QUIET 3</term>
		/// <term>Continue the copy operation but do not call the CopyFile2ProgressRoutine callback function again for this operation.</term>
		/// </item>
		/// <item>
		/// <term>COPYFILE2_PROGRESS_PAUSE 4</term>
		/// <term>
		/// Pause the copy operation. In most cases the CopyFile2 function will fail and return and any partially copied fragments will be
		/// left intact (except for the header written that is used to resume the copy operation later.) In case the copy operation was
		/// complete at the time the pause request is processed the CopyFile2 call will complete successfully and no resume header will be written.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>COPYFILE2_CALLBACK_STREAM_FINISHED</c> message is the last message for a paused copy. If <c>COPYFILE2_PROGRESS_PAUSE</c>
		/// is returned in response to a <c>COPYFILE2_CALLBACK_STREAM_FINISHED</c> message then no further callbacks will be sent.
		/// </para>
		/// <para>
		/// To compile an application that uses the <c>PCOPYFILE2_PROGRESS_ROUTINE</c> function pointer type, define the <c>_WIN32_WINNT</c>
		/// macro as 0x0601 or later. For more information, see Using the Windows Headers.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nc-winbase-pcopyfile2_progress_routine PCOPYFILE2_PROGRESS_ROUTINE
		// Pcopyfile2ProgressRoutine; COPYFILE2_MESSAGE_ACTION Pcopyfile2ProgressRoutine( const COPYFILE2_MESSAGE *pMessage, PVOID
		// pvCallbackContext ) {...}
		[PInvokeData("winbase.h", MSDNShortId = "d14b5f5b-c353-49e8-82bb-a695a3ec76fd")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate COPYFILE2_MESSAGE_ACTION Pcopyfile2ProgressRoutine(ref COPYFILE2_MESSAGE pMessage, IntPtr pvCallbackContext);

		/// <summary>Flags for SetSearchPathMode.</summary>
		[PInvokeData("winbase.h", MSDNShortId = "1874933d-92c3-4945-a3e4-e6dede232d5e")]
		[Flags]
		public enum BASE_SEARCH_PATH
		{
			/// <summary>Enable safe process search mode for the process.</summary>
			BASE_SEARCH_PATH_ENABLE_SAFE_SEARCHMODE = 0x00000001,

			/// <summary>Disable safe process search mode for the process.</summary>
			BASE_SEARCH_PATH_DISABLE_SAFE_SEARCHMODE = 0x00010000,

			/// <summary>
			/// Optional flag to use in combination with BASE_SEARCH_PATH_ENABLE_SAFE_SEARCHMODE to make this mode permanent for this
			/// process. This is done by bitwise OR operation:
			/// <para>(BASE_SEARCH_PATH_ENABLE_SAFE_SEARCHMODE | BASE_SEARCH_PATH_PERMANENT)</para>
			/// <para>This flag cannot be combined with the BASE_SEARCH_PATH_DISABLE_SAFE_SEARCHMODE flag.</para>
			/// </summary>
			BASE_SEARCH_PATH_PERMANENT = 0x00008000,
		}

		/// <summary>Used by <see cref="LpprogressRoutine"/>.</summary>
		public enum COPYFILE_CALLBACK
		{
			/// <summary>Another part of the data file was copied.</summary>
			CALLBACK_CHUNK_FINISHED = 0x00000000,

			/// <summary>
			/// Another stream was created and is about to be copied. This is the callback reason given when the callback routine is first invoked.
			/// </summary>
			CALLBACK_STREAM_SWITCH = 0x00000001,
		}

		/// <summary>Returned by <see cref="LpprogressRoutine"/>.</summary>
		public enum COPYFILE_CALLBACK_RESULT
		{
			/// <summary>Cancel the copy operation and delete the destination file.</summary>
			PROGRESS_CANCEL = 1,

			/// <summary>Continue the copy operation.</summary>
			PROGRESS_CONTINUE = 0,

			/// <summary>Continue the copy operation, but stop invoking CopyProgressRoutine to report progress.</summary>
			PROGRESS_QUIET = 3,

			/// <summary>Stop the copy operation. It can be restarted at a later time.</summary>
			PROGRESS_STOP = 2,
		}

		/// <summary>
		/// <para>
		/// Indicates the phase of a copy at the time of an error. This is used in the <c>Error</c> structure embedded in the
		/// COPYFILE2_MESSAGE structure.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To compile an application that uses this enumeration, define the <c>_WIN32_WINNT</c> macro as 0x0601 or later. For more
		/// information, see Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ne-winbase-_copyfile2_copy_phase typedef enum _COPYFILE2_COPY_PHASE {
		// COPYFILE2_PHASE_NONE , COPYFILE2_PHASE_PREPARE_SOURCE , COPYFILE2_PHASE_PREPARE_DEST , COPYFILE2_PHASE_READ_SOURCE ,
		// COPYFILE2_PHASE_WRITE_DESTINATION , COPYFILE2_PHASE_SERVER_COPY , COPYFILE2_PHASE_NAMEGRAFT_COPY , COPYFILE2_PHASE_MAX } COPYFILE2_COPY_PHASE;
		[PInvokeData("winbase.h", MSDNShortId = "92bf9028-78a3-4ea3-bfbb-b53a8df557ab")]
		// public enum _COPYFILE2_COPY_PHASE{COPYFILE2_PHASE_NONE, COPYFILE2_PHASE_PREPARE_SOURCE, COPYFILE2_PHASE_PREPARE_DEST,
		// COPYFILE2_PHASE_READ_SOURCE, COPYFILE2_PHASE_WRITE_DESTINATION, COPYFILE2_PHASE_SERVER_COPY, COPYFILE2_PHASE_NAMEGRAFT_COPY,
		// COPYFILE2_PHASE_MAX, COPYFILE2_COPY_PHASE}
		public enum COPYFILE2_COPY_PHASE
		{
			/// <summary>The copy had not yet started processing.</summary>
			COPYFILE2_PHASE_NONE,

			/// <summary>
			/// The source was being prepared including opening a handle to the source. This phase happens once per stream copy operation.
			/// </summary>
			COPYFILE2_PHASE_PREPARE_SOURCE,

			/// <summary>
			/// The destination was being prepared including opening a handle to the destination. This phase happens once per stream copy operation.
			/// </summary>
			COPYFILE2_PHASE_PREPARE_DEST,

			/// <summary>The source file was being read. This phase happens one or more times per stream copy operation.</summary>
			COPYFILE2_PHASE_READ_SOURCE,

			/// <summary>The destination file was being written. This phase happens one or more times per stream copy operation.</summary>
			COPYFILE2_PHASE_WRITE_DESTINATION,

			/// <summary>
			/// Both the source and destination were on the same remote server and the copy was being processed remotely. This phase happens
			/// once per stream copy operation.
			/// </summary>
			COPYFILE2_PHASE_SERVER_COPY,

			/// <summary>
			/// The copy operation was processing symbolic links and/or reparse points. This phase happens once per file copy operation.
			/// </summary>
			COPYFILE2_PHASE_NAMEGRAFT_COPY,

			/// <summary>One greater than the maximum value. Valid values for this enumeration will be less than this value.</summary>
			COPYFILE2_PHASE_MAX,
		}

		/// <summary>
		/// <para>
		/// Returned by the CopyFile2ProgressRoutine callback function to indicate what action should be taken for the pending copy operation.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To compile an application that uses this enumeration, define the <c>_WIN32_WINNT</c> macro as 0x0601 or later. For more
		/// information, see Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ne-winbase-_copyfile2_message_action typedef enum
		// _COPYFILE2_MESSAGE_ACTION { COPYFILE2_PROGRESS_CONTINUE , COPYFILE2_PROGRESS_CANCEL , COPYFILE2_PROGRESS_STOP ,
		// COPYFILE2_PROGRESS_QUIET , COPYFILE2_PROGRESS_PAUSE } COPYFILE2_MESSAGE_ACTION;
		[PInvokeData("winbase.h", MSDNShortId = "0beae28e-f493-4ae1-a4d9-3df69de166b7")]
		public enum COPYFILE2_MESSAGE_ACTION
		{
			/// <summary>Continue the copy operation.</summary>
			COPYFILE2_PROGRESS_CONTINUE,

			/// <summary>
			/// Cancel the copy operation. The CopyFile2 call will fail and return and any partially copied fragments will be deleted.
			/// </summary>
			COPYFILE2_PROGRESS_CANCEL,

			/// <summary>
			/// Stop the copy operation. The CopyFile2 call will fail and return and any partially copied fragments will be left intact. The
			/// operation can be restarted using the COPY_FILE_RESUME_FROM_PAUSE flag only if the COPY_FILE_RESTARTABLE flag was set in the
			/// dwCopyFlags member of the COPYFILE2_EXTENDED_PARAMETERS structure passed to the CopyFile2 function.
			/// </summary>
			COPYFILE2_PROGRESS_STOP,

			/// <summary>Continue the copy operation but do not call the CopyFile2ProgressRoutine callback function again for this operation.</summary>
			COPYFILE2_PROGRESS_QUIET,

			/// <summary>
			/// Pause the copy operation and write a restart header. This value is not compatible with the COPY_FILE_RESTARTABLE flag for the
			/// dwCopyFlags member of the COPYFILE2_EXTENDED_PARAMETERS structure. In most cases the CopyFile2 call will fail and return and
			/// any partially copied fragments will be left intact (except for the header written that is used to resume the copy operation
			/// later.) In case the copy operation was complete at the time the pause request is processed the CopyFile2 call will complete
			/// successfully and no resume header will be written. After this value is processed one more callback will be made to the
			/// CopyFile2ProgressRoutine with the message specifying a COPYFILE2_CALLBACK_STREAM_FINISHED (4) value in the Type member of the
			/// COPYFILE2_MESSAGE structure. After the callback has returned CopyFile2 will fail with .
			/// </summary>
			COPYFILE2_PROGRESS_PAUSE,
		}

		/// <summary>
		/// <para>Indicates the type of message passed in the COPYFILE2_MESSAGE structure to the CopyFile2ProgressRoutine callback function.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To compile an application that uses this enumeration, define the <c>_WIN32_WINNT</c> macro as 0x0601 or later. For more
		/// information, see Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ne-winbase-_copyfile2_message_type typedef enum
		// _COPYFILE2_MESSAGE_TYPE { COPYFILE2_CALLBACK_NONE , COPYFILE2_CALLBACK_CHUNK_STARTED , COPYFILE2_CALLBACK_CHUNK_FINISHED ,
		// COPYFILE2_CALLBACK_STREAM_STARTED , COPYFILE2_CALLBACK_STREAM_FINISHED , COPYFILE2_CALLBACK_POLL_CONTINUE ,
		// COPYFILE2_CALLBACK_ERROR , COPYFILE2_CALLBACK_MAX } COPYFILE2_MESSAGE_TYPE;
		[PInvokeData("winbase.h", MSDNShortId = "3a16ca3b-79af-4064-82d5-c073d2aa531c")]
		public enum COPYFILE2_MESSAGE_TYPE
		{
			/// <summary>Not a valid value.</summary>
			COPYFILE2_CALLBACK_NONE,

			/// <summary>Indicates a single chunk of a stream has started to be copied.</summary>
			COPYFILE2_CALLBACK_CHUNK_STARTED,

			/// <summary>Indicates the copy of a single chunk of a stream has completed.</summary>
			COPYFILE2_CALLBACK_CHUNK_FINISHED,

			/// <summary>
			/// Indicates both source and destination handles for a stream have been opened and the copy of the stream is about to be started.
			/// </summary>
			COPYFILE2_CALLBACK_STREAM_STARTED,

			/// <summary>Indicates the copy operation for a stream have started to be completed.</summary>
			COPYFILE2_CALLBACK_STREAM_FINISHED,

			/// <summary>May be sent periodically.</summary>
			COPYFILE2_CALLBACK_POLL_CONTINUE,

			/// <summary/>
			COPYFILE2_CALLBACK_ERROR,

			/// <summary>An error was encountered during the copy operation.</summary>
			COPYFILE2_CALLBACK_MAX,
		}

		/// <summary>Return values for GetSystemDEPPolicy.</summary>
		[PInvokeData("winbase.h", MSDNShortId = "82cb1d4e-c0e5-4601-aa55-9171a106c286")]
		public enum DEP_SYSTEM_POLICY_TYPE
		{
			/// <summary>
			/// DEP is disabled for all parts of the system, regardless of hardware support for DEP. The processor runs in PAE mode with
			/// 32-bit versions of Windows unless PAE is disabled in the boot configuration data.
			/// </summary>
			AlwaysOff = 0,

			/// <summary>
			/// DEP is enabled for all parts of the system. All processes always run with DEP enabled. DEP cannot be explicitly disabled for
			/// selected applications. System compatibility fixes are ignored.
			/// </summary>
			AlwaysOn = 1,

			/// <summary>
			/// On systems with processors that are capable of hardware-enforced DEP, DEP is automatically enabled only for operating system
			/// components. This is the default setting for client versions of Windows. DEP can be explicitly enabled for selected
			/// applications or the current process.
			/// </summary>
			OptIn = 2,

			/// <summary>
			/// DEP is automatically enabled for operating system components and all processes. This is the default setting for Windows
			/// Server versions. DEP can be explicitly disabled for selected applications or the current process. System compatibility fixes
			/// for DEP are in effect.
			/// </summary>
			OptOut = 3,
		}

		/// <summary>The modes to be set in SetFileCompletionNotificationModes.</summary>
		[PInvokeData("winbase.h", MSDNShortId = "23796484-ee47-4f80-856d-5a5d5635547c")]
		[Flags]
		public enum FILE_NOTIFICATION_MODE : byte
		{
			/// <summary>
			/// If the following three conditions are true, the I/O Manager does not queue a completion entry to the port, when it would
			/// ordinarily do so. The conditions are: When the FileHandle parameter is a socket, this mode is only compatible with Layered
			/// Service Providers (LSP) that return Installable File Systems (IFS) handles. To detect whether a non-IFS LSP is installed, use
			/// the WSAEnumProtocols function and examine the dwServiceFlag1 member in each returned WSAPROTOCOL_INFO structure. If the
			/// XP1_IFS_HANDLES (0x20000) bit is cleared then the specified LSP is not an IFS LSP. Vendors that have non-IFS LSPs are
			/// encouraged to migrate to the Windows Filtering Platform (WFP).
			/// </summary>
			FILE_SKIP_COMPLETION_PORT_ON_SUCCESS = 0x1,

			/// <summary>
			/// The I/O Manager does not set the event for the file object if a request returns with a success code, or the error returned is
			/// ERROR_PENDING and the function that is called is not a synchronous function. If an explicit event is provided for the
			/// request, it is still signaled.
			/// </summary>
			FILE_SKIP_SET_EVENT_ON_HANDLE = 0x2
		}

		/// <summary>
		/// <para>The <c>HARDWARE_COUNTER_TYPE</c> enumeration specifies the type of a hardware counter.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>Type</c> member of the HARDWARE_COUNTER structure contains a <c>HARDWARE_COUNTER_TYPE</c> enumeration value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/ntddk/ne-ntddk-_hardware_counter_type typedef enum
		// _HARDWARE_COUNTER_TYPE { PMCCounter , MaxHardwareCounterType } HARDWARE_COUNTER_TYPE, *PHARDWARE_COUNTER_TYPE;
		[PInvokeData("ntddk.h", MSDNShortId = "837f5a55-ca07-4462-85d7-203d02df168c")]
		public enum HARDWARE_COUNTER_TYPE
		{
			/// <summary>Performance monitor counter. This type of counter is used by thread-profiling applications.</summary>
			PMCCounter,

			/// <summary>The maximum value in this enumeration type.</summary>
			MaxHardwareCounterType
		}

		/// <summary>
		/// <para>The <c>POWER_REQUEST_TYPE</c> enumeration indicates the power request type.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This enumeration is used by the kernel-mode PoClearPowerRequest and PoSetPowerRequest routines. Drivers that call these routines
		/// must specify the <c>PowerRequestSystemRequired</c> enumeration value.
		/// </para>
		/// <para>
		/// The other three enumeration values— <c>PowerRequestDisplayRequired</c>, <c>PowerRequestAwayModeRequired</c>, and
		/// <c>PowerRequestExecutionRequired</c>—are not used by drivers. Applications specify these power request types in calls to the
		/// PowerSetRequest and PowerClearRequest functions.
		/// </para>
		/// <para>A <c>PowerRequestDisplayRequired</c> power request has the following effects:</para>
		/// <para>
		/// While a <c>PowerRequestAwayModeRequired</c> power request is in effect, if the user tries to put the computer into sleep mode
		/// (for example, by clicking <c>Start</c> and then clicking <c>Sleep</c>), the power manager turns off audio and video so that the
		/// computer appears to be in sleep mode, but the computer continues to run.
		/// </para>
		/// <para>
		/// While a <c>PowerRequestExecutionRequired</c> power request is in effect, the calling process continues to run instead of being
		/// suspended or terminated by process lifetime management (PLM) mechanisms. When and how long the process is allowed to run depends
		/// on the operating system and power policy settings. This type of power request is supported starting with Windows 8.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ne-wdm-_power_request_type typedef enum
		// _POWER_REQUEST_TYPE { PowerRequestDisplayRequired , PowerRequestSystemRequired , PowerRequestAwayModeRequired ,
		// PowerRequestExecutionRequired } POWER_REQUEST_TYPE, *PPOWER_REQUEST_TYPE;
		[PInvokeData("wdm.h", MSDNShortId = "266cdf1a-6122-4f46-8e93-8f76fceb0180")]
		public enum POWER_REQUEST_TYPE
		{
			/// <summary>Not used by drivers. For more information, see Remarks.</summary>
			PowerRequestDisplayRequired,

			/// <summary>Prevents the computer from automatically entering sleep mode after a period of user inactivity.</summary>
			PowerRequestSystemRequired,

			/// <summary>Not used by drivers. For more information, see Remarks.</summary>
			PowerRequestAwayModeRequired,

			/// <summary>Not used by drivers. For more information, see Remarks.</summary>
			PowerRequestExecutionRequired,
		}

		/// <summary>Values returned by <see cref="GetProcessDEPPolicy"/>.</summary>
		[PInvokeData("winbase.h", MSDNShortId = "adf15b9c-24f4-49ea-9283-0db5f3f13e65")]
		[Flags]
		public enum PROCESS_DEP
		{
			/// <summary>DEP is disabled for the specified process.</summary>
			PROCESS_DEP_DISABLE = 0,

			/// <summary>DEP is enabled for the specified process.</summary>
			PROCESS_DEP_ENABLE = 0x00000001,

			/// <summary>
			/// DEP-ATL thunk emulation is disabled for the specified process. For information about DEP-ATL thunk emulation, see SetProcessDEPPolicy.
			/// </summary>
			PROCESS_DEP_DISABLE_ATL_THUNK_EMULATION = 0x00000002,
		}

		/// <summary>Used by QueryFullProcessImageName.</summary>
		[PInvokeData("winbase.h", MSDNShortId = "49a9d1aa-30f3-45ea-a4ec-9f55df692b8b")]
		public enum PROCESS_NAME
		{
			/// <summary>The name should use the Win32 path format.</summary>
			PROCESS_NAME_WIN32,

			/// <summary>The name should use the native system path format.</summary>
			PROCESS_NAME_NATIVE
		}

		/// <summary>Used by ReadThreadProfilingData.</summary>
		[PInvokeData("Winbase.h", MSDNShortId = "dd796403")]
		[Flags]
		public enum READ_THREAD_PROFILING_FLAG
		{
			/// <summary>Get the thread profiling data.</summary>
			READ_THREAD_PROFILING_FLAG_DISPATCHING = 0x00000001,

			/// <summary>Get the hardware performance counters data.</summary>
			READ_THREAD_PROFILING_FLAG_HARDWARE_COUNTERS = 0x00000002,
		}

		/// <summary>System executable types.</summary>
		[PInvokeData("winbase.h", MSDNShortId = "ec937372-ee99-4505-a5dd-7c111405cbc6")]
		public enum SCS
		{
			/// <summary>A 32-bit Windows-based application</summary>
			SCS_32BIT_BINARY = 0,

			/// <summary>A 64-bit Windows-based application.</summary>
			SCS_64BIT_BINARY = 6,

			/// <summary>An MS-DOS – based application</summary>
			SCS_DOS_BINARY = 1,

			/// <summary>A 16-bit OS/2-based application</summary>
			SCS_OS216_BINARY = 5,

			/// <summary>A PIF file that executes an MS-DOS – based application</summary>
			SCS_PIF_BINARY = 3,

			/// <summary>A POSIX – based application</summary>
			SCS_POSIX_BINARY = 4,

			/// <summary>A 16-bit Windows-based application</summary>
			SCS_WOW_BINARY = 2,
		}

		/// <summary>Used by <see cref="EnableThreadProfiling"/>.</summary>
		[PInvokeData("Winbase.h", MSDNShortId = "dd796393")]
		public enum THREAD_PROFILING_FLAG
		{
			/// <summary>Receive no data.</summary>
			THREAD_PROFILING_FLAG_NO_DATA = 0,

			/// <summary>Receive thread profiling data such as context switch count.</summary>
			THREAD_PROFILING_FLAG_DISPATCH = 1
		}

		/// <summary>Flags used by UMS_SYSTEM_THREAD_INFORMATION.</summary>
		[PInvokeData("winbase.h", MSDNShortId = "eecdc592-5046-47c3-a4c6-ecb10899db3c")]
		public enum ThreadUmsFlags : uint
		{
			/// <summary>
			/// <para>
			/// A bitfield that specifies a UMS scheduler thread. If <c>IsUmsSchedulerThread</c> is set, <c>IsUmsWorkerThread</c> must be clear.
			/// </para>
			/// </summary>
			IsUmsSchedulerThread = 0x1,

			/// <summary>
			/// <para>
			/// A bitfield that specifies a UMS worker thread. If <c>IsUmsWorkerThread</c> is set, <c>IsUmsSchedulerThread</c> must be clear.
			/// </para>
			/// </summary>
			IsUmsWorkerThread = 0x2,
		}

		/// <summary>
		/// <para>Represents classes of information about user-mode scheduling (UMS) threads.</para>
		/// <para>This enumeration is used by the <c>QueryUmsThreadInformation</c> and <c>SetUmsThreadInformation</c> functions.</para>
		/// </summary>
		// typedef enum _UMS_THREAD_INFO_CLASS { UmsThreadInvalidInfoClass = 0, UmsThreadUserContext = 1, UmsThreadPriority = 2,
		// UmsThreadAffinity = 3, UmsThreadTeb = 4, UmsThreadIsSuspended = 5, UmsThreadIsTerminated = 6, UmsThreadMaxInfoClass = 7}
		// UMS_THREAD_INFO_CLASS, *PUMS_THREAD_INFO_CLASS; https://msdn.microsoft.com/en-us/library/windows/desktop/dd627186(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "dd627186")]
		public enum UMS_THREAD_INFO_CLASS
		{
			/// <summary>Reserved.</summary>
			UmsThreadInvalidInfoClass,

			/// <summary>Application-defined information stored in a UMS thread context.</summary>
			UmsThreadUserContext,

			/// <summary>Reserved.</summary>
			UmsThreadPriority,

			/// <summary>Reserved.</summary>
			UmsThreadAffinity,

			/// <summary>
			/// The thread execution block ( <c>TEB</c>) for a UMS thread. This information class can only be queried; it cannot be set.
			/// </summary>
			UmsThreadTeb,

			/// <summary>The suspension status of the thread. This information can only be queried; it cannot be set.</summary>
			UmsThreadIsSuspended,

			/// <summary>The termination status of the thread. This information can only be queried; it cannot be set.</summary>
			UmsThreadIsTerminated,

			/// <summary>Reserved.</summary>
			UmsThreadMaxInfoClass,
		}

		/// <summary>Firmware environment variable flags.</summary>
		[PInvokeData("winbase.h", MSDNShortId = "D3C2F03F-66F6-40A4-830E-058BBA925ACD")]
		[Flags]
		public enum VARIABLE_ATTRIBUTE
		{
			/// <summary>The firmware environment variable is stored in non-volatile memory (e.g. NVRAM).</summary>
			VARIABLE_ATTRIBUTE_NON_VOLATILE = 0x00000001,

			/// <summary>The firmware environment variable can be accessed during boot service.</summary>
			VARIABLE_ATTRIBUTE_BOOTSERVICE_ACCESS = 0x00000002,

			/// <summary>
			/// The firmware environment variable can be accessed at runtime. Note Variables with this attribute set, must also have
			/// VARIABLE_ATTRIBUTE_BOOTSERVICE_ACCESS set.
			/// </summary>
			VARIABLE_ATTRIBUTE_RUNTIME_ACCESS = 0x00000004,

			/// <summary>Indicates hardware related errors encountered at runtime.</summary>
			VARIABLE_ATTRIBUTE_HARDWARE_ERROR_RECORD = 0x00000008,

			/// <summary>
			/// Indicates an authentication requirement that must be met before writing to this firmware environment variable. For more
			/// information see, UEFI spec 2.3.1.
			/// </summary>
			VARIABLE_ATTRIBUTE_AUTHENTICATED_WRITE_ACCESS = 0x00000010,

			/// <summary>
			/// Indicates authentication and time stamp requirements that must be met before writing to this firmware environment variable.
			/// When this attribute is set, the buffer, represented by pValue, will begin with an instance of a complete (and serialized)
			/// EFI_VARIABLE_AUTHENTICATION_2 descriptor. For more information see, UEFI spec 2.3.1.
			/// </summary>
			VARIABLE_ATTRIBUTE_TIME_BASED_AUTHENTICATED_WRITE_ACCESS = 0x00000020,

			/// <summary>
			/// Append an existing environment variable with the value of pValue. If the firmware does not support the operation, then
			/// SetFirmwareEnvironmentVariableEx will return ERROR_INVALID_FUNCTION.
			/// </summary>
			VARIABLE_ATTRIBUTE_APPEND_WRITE = 0x00000040,
		}

		/// <summary/>
		public enum WOW64_CONTEXT_FLAGS : uint
		{
			/// <summary>this assumes that i386 and</summary>
			WOW64_CONTEXT_i386 = 0x00010000,

			/// <summary>i486 have identical context records</summary>
			WOW64_CONTEXT_i486 = 0x00010000,

			/// <summary>SS:SP, CS:IP, FLAGS, BP</summary>
			WOW64_CONTEXT_CONTROL = (WOW64_CONTEXT_i386 | 0x00000001),

			/// <summary>AX, BX, CX, DX, SI, DI</summary>
			WOW64_CONTEXT_INTEGER = (WOW64_CONTEXT_i386 | 0x00000002),

			/// <summary>DS, ES, FS, GS</summary>
			WOW64_CONTEXT_SEGMENTS = (WOW64_CONTEXT_i386 | 0x00000004),

			/// <summary>387 state</summary>
			WOW64_CONTEXT_FLOATING_POINT = (WOW64_CONTEXT_i386 | 0x00000008),

			/// <summary>DB 0-3,6,7</summary>
			WOW64_CONTEXT_DEBUG_REGISTERS = (WOW64_CONTEXT_i386 | 0x00000010),

			/// <summary>cpu specific extensions</summary>
			WOW64_CONTEXT_EXTENDED_REGISTERS = (WOW64_CONTEXT_i386 | 0x00000020),

			/// <summary></summary>
			WOW64_CONTEXT_FULL = (WOW64_CONTEXT_CONTROL | WOW64_CONTEXT_INTEGER | WOW64_CONTEXT_SEGMENTS),

			/// <summary></summary>
			WOW64_CONTEXT_ALL = (WOW64_CONTEXT_CONTROL | WOW64_CONTEXT_INTEGER | WOW64_CONTEXT_SEGMENTS | WOW64_CONTEXT_FLOATING_POINT | WOW64_CONTEXT_DEBUG_REGISTERS | WOW64_CONTEXT_EXTENDED_REGISTERS),

			/// <summary></summary>
			WOW64_CONTEXT_XSTATE = (WOW64_CONTEXT_i386 | 0x00000040),

			/// <summary></summary>
			WOW64_CONTEXT_EXCEPTION_ACTIVE = 0x08000000,

			/// <summary></summary>
			WOW64_CONTEXT_SERVICE_ACTIVE = 0x10000000,

			/// <summary></summary>
			WOW64_CONTEXT_EXCEPTION_REQUEST = 0x40000000,

			/// <summary></summary>
			WOW64_CONTEXT_EXCEPTION_REPORTING = 0x80000000,
		}

		/// <summary>
		/// <para>Adds a new required security identifier (SID) to the specified boundary descriptor.</para>
		/// </summary>
		/// <param name="BoundaryDescriptor">
		/// <para>A handle to the boundary descriptor. The CreateBoundaryDescriptor function returns this handle.</para>
		/// </param>
		/// <param name="IntegrityLabel">
		/// <para>
		/// A pointer to a SID structure that represents the mandatory integrity level for the namespace. Use one of the following RID values
		/// to create the SID:
		/// </para>
		/// <para>
		/// <c>SECURITY_MANDATORY_UNTRUSTED_RID</c><c>SECURITY_MANDATORY_LOW_RID</c><c>SECURITY_MANDATORY_MEDIUM_RID</c><c>SECURITY_MANDATORY_SYSTEM_RID</c><c>SECURITY_MANDATORY_PROTECTED_PROCESS_RID</c>
		/// For more information, see Well-Known SIDs.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A process can create a private namespace only with an integrity level that is equal to or lower than the current integrity level
		/// of the process. Therefore, a high integrity-level process can create a high, medium or low integrity-level namespace. A medium
		/// integrity-level process can create only a medium or low integrity-level namespace.
		/// </para>
		/// <para>
		/// A process would usually specify a namespace at the same integrity level as the process for protection against squatting attacks
		/// by lower integrity-level processes.
		/// </para>
		/// <para>
		/// The security descriptor that the creator places on the namespace determines who can open the namespace. So a low or medium
		/// integrity-level process could be given permission to open a high integrity level namespace if the security descriptor of the
		/// namespace permits it.
		/// </para>
		/// <para>To compile an application that uses this function, define <c>_WIN32_WINNT</c> as 0x0601 or later.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-addintegritylabeltoboundarydescriptor BOOL
		// AddIntegrityLabelToBoundaryDescriptor( HANDLE *BoundaryDescriptor, PSID IntegrityLabel );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "6b56e664-7795-4e30-8bca-1e4df2764606")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddIntegrityLabelToBoundaryDescriptor(ref IntPtr BoundaryDescriptor, IntPtr IntegrityLabel);

		/// <summary>
		/// <para>Adds an alternate local network name for the computer from which it is called.</para>
		/// </summary>
		/// <returns>
		/// <para>
		/// If the function succeeds, the function returns <c>ERROR_SUCCESS</c>. If the function fails, it returns a nonzero error code.
		/// Among the error codes that it returns are the following:
		/// </para>
		/// <list type="table"/>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/DevNotes/addlocalalternatecomputername DWORD AddLocalAlternateComputerName( _In_
		// LPCTSTR lpDnsFQHostname, _In_ ULONG ulFlags );
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("", MSDNShortId = "e4d8355b-0492-4b6f-988f-3887e63a2bba")]
		public static extern Win32Error AddLocalAlternateComputerName(string lpDnsFQHostname, uint ulFlags = 0);

		/// <summary>
		/// <para>Registers a callback function to be called when a secured memory range is freed or its protections are changed.</para>
		/// </summary>
		/// <param name="pfnCallBack">
		/// <para>A pointer to the application-defined SecureMemoryCacheCallback function to register.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it registers the callback function and returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application that performs I/O directly to a high-performance device typically caches a virtual-to-physical memory mapping for
		/// the buffer it uses for the I/O. The device's driver typically secures this memory address range by calling the
		/// MmSecureVirtualMemory routine, which prevents the memory range from being freed or its protections changed until the driver
		/// unsecures the memory.
		/// </para>
		/// <para>
		/// An application can use <c>AddSecureMemoryCacheCallback</c> to register a callback function that will be called when the memory is
		/// freed or its protections are changed, so the application can invalidate its cached memory mapping. For more information, see SecureMemoryCacheCallback.
		/// </para>
		/// <para>
		/// To compile an application that uses this function, define <c>_WIN32_WINNT</c> as 0x0600 or later. For more information, see Using
		/// the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-addsecurememorycachecallback BOOL
		// AddSecureMemoryCacheCallback( PSECURE_MEMORY_CACHE_CALLBACK pfnCallBack );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "6c89d6f3-182e-4b10-931c-8d55d603c9dc")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddSecureMemoryCacheCallback(PsecureMemoryCacheCallback pfnCallBack);

		/// <summary>
		/// <para>Flushes the application compatibility cache.</para>
		/// </summary>
		/// <returns>
		/// <para>The function returns <c>TRUE</c> if it succeeds and <c>FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>The caller must be an administrator.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/DevNotes/baseflushappcompatcache BOOL WINAPI BaseFlushAppcompatCache(void);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("", MSDNShortId = "03f47813-87f6-4b71-b453-77a2facab019")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool BaseFlushAppcompatCache();

		/// <summary>
		/// <para>Copies a source context structure (including any XState) onto an initialized destination context structure.</para>
		/// </summary>
		/// <param name="Destination">
		/// <para>
		/// A pointer to a CONTEXT structure that receives the context copied from the . The <c>CONTEXT</c> structure should be initialized
		/// by calling InitializeContext before calling this function.
		/// </para>
		/// </param>
		/// <param name="ContextFlags">
		/// <para>
		/// Flags specifying the pieces of the CONTEXT structure that will be copied into the destination. This must be a subset of the
		/// specified when calling InitializeContext on the <c>CONTEXT</c>.
		/// </para>
		/// </param>
		/// <param name="Source">
		/// <para>A pointer to a CONTEXT structure from which to copy processor context data.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// This function returns <c>TRUE</c> if the context was copied successfully, otherwise <c>FALSE</c>. To get extended error
		/// information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The function copies data from the CONTEXT over the corresponding data in the <c>CONTEXT</c>, including extended context if any is
		/// present. The <c>CONTEXT</c> must have been initialized with InitializeContext to ensure proper alignment and initialization. If
		/// any data is present in the <c>CONTEXT</c> and the corresponding flag is not set in the <c>CONTEXT</c> or in the parameter, the
		/// data remains valid in the .
		/// </para>
		/// <para>
		/// <c>Windows 7 with SP1 and Windows Server 2008 R2 with SP1:</c> The AVX API is first implemented on Windows 7 with SP1 and Windows
		/// Server 2008 R2 with SP1 . Since there is no SDK for SP1, that means there are no available headers and library files to work
		/// with. In this situation, a caller must declare the needed functions from this documentation and get pointers to them using
		/// GetModuleHandle on "Kernel32.dll", followed by calls to GetProcAddress. See Working with XState Context for details.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-copycontext BOOL CopyContext( PCONTEXT Destination, DWORD
		// ContextFlags, PCONTEXT Source );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "805CD02A-53BC-487C-83F8-FE804368C770")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CopyContext(ref CONTEXT Destination, CONTEXT_FLAG ContextFlags, ref CONTEXT Source);

		/// <summary>
		/// <para>Copies an existing file to a new file, notifying the application of its progress through a callback function.</para>
		/// </summary>
		/// <param name="pwszExistingFileName">
		/// <para>The name of an existing file.</para>
		/// <para>
		/// To extend this limit to 32,767 wide characters, prepend "\?" to the path. For more information, see Naming Files, Paths, and Namespaces.
		/// </para>
		/// <para>
		/// <c>Tip</c> Starting in Windows 10, version 1607, you can opt-in to remove the <c>MAX_PATH</c> character limitation without
		/// prepending "\\?\". See the "Maximum Path Limitation" section of Naming Files, Paths, and Namespaces for details.
		/// </para>
		/// <para>If</para>
		/// <para>lpExistingFileName</para>
		/// <para>does not exist, the</para>
		/// <para>CopyFile2</para>
		/// <para>function fails returns</para>
		/// <para>HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND)</para>
		/// <para>.</para>
		/// </param>
		/// <param name="pwszNewFileName">
		/// <para>The name of the new file.</para>
		/// <para>
		/// To extend this limit to 32,767 wide characters, prepend "\?" to the path. For more information, see Naming Files, Paths, and Namespaces.
		/// </para>
		/// <para>
		/// <c>Tip</c> Starting in Windows 10, version 1607, you can opt-in to remove the <c>MAX_PATH</c> character limitation without
		/// prepending "\\?\". See the "Maximum Path Limitation" section of Naming Files, Paths, and Namespaces for details.
		/// </para>
		/// </param>
		/// <param name="pExtendedParameters">
		/// <para>Optional address of a COPYFILE2_EXTENDED_PARAMETERS structure.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value will return <c>TRUE</c> when passed to the SUCCEEDED macro.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The copy operation completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_REQUEST_PAUSED)</term>
		/// <term>The copy operation was paused by a COPYFILE2_PROGRESS_PAUSE return from the CopyFile2ProgressRoutine callback function.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_REQUEST_ABORTED)</term>
		/// <term>
		/// The copy operation was paused by a COPYFILE2_PROGRESS_CANCEL or COPYFILE2_PROGRESS_STOP return from the CopyFile2ProgressRoutine
		/// callback function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_ALREADY_EXISTS)</term>
		/// <term>
		/// The dwCopyFlags member of the COPYFILE2_EXTENDED_PARAMETERS structure passed through the parameter contains the
		/// COPY_FILE_FAIL_IF_EXISTS flag and a conflicting name existed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_FILE_EXISTS)</term>
		/// <term>
		/// The dwCopyFlags member of the COPYFILE2_EXTENDED_PARAMETERS structure passed through the parameter contains the
		/// COPY_FILE_FAIL_IF_EXISTS flag and a conflicting name existed.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function preserves extended attributes, OLE structured storage, NTFS file system alternate data streams, and file
		/// attributes. Security attributes for the existing file are not copied to the new file. To copy security attributes, use the
		/// SHFileOperation function.
		/// </para>
		/// <para>
		/// This function fails with if the destination file already exists and has the <c>FILE_ATTRIBUTE_HIDDEN</c> or
		/// <c>FILE_ATTRIBUTE_READONLY</c> attribute set.
		/// </para>
		/// <para>
		/// To compile an application that uses this function, define the <c>_WIN32_WINNT</c> macro as <c>_WIN32_WINNT_WIN8</c> or later. For
		/// more information, see Using the Windows Headers.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-copyfile2 HRESULT CopyFile2( PCWSTR pwszExistingFileName,
		// PCWSTR pwszNewFileName, COPYFILE2_EXTENDED_PARAMETERS *pExtendedParameters );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("winbase.h", MSDNShortId = "aa2df686-4b61-4d90-ba0b-c78c5a0d2d59")]
		public static extern HRESULT CopyFile2(string pwszExistingFileName, string pwszNewFileName, ref COPYFILE2_EXTENDED_PARAMETERS pExtendedParameters);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see
		/// </para>
		/// <para>Alternatives to using Transactional NTFS</para>
		/// <para>.]</para>
		/// <para>
		/// Copies an existing file to a new file as a transacted operation, notifying the application of its progress through a callback function.
		/// </para>
		/// </summary>
		/// <param name="lpExistingFileName">
		/// <para>The name of an existing file.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>If does not exist, the <c>CopyFileTransacted</c> function fails, and the GetLastError function returns <c>ERROR_FILE_NOT_FOUND</c>.</para>
		/// <para>The file must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="lpNewFileName">
		/// <para>The name of the new file.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="lpProgressRoutine">
		/// <para>
		/// The address of a callback function of type <c>LPPROGRESS_ROUTINE</c> that is called each time another portion of the file has
		/// been copied. This parameter can be <c>NULL</c>. For more information on the progress callback function, see the
		/// CopyProgressRoutine function.
		/// </para>
		/// </param>
		/// <param name="lpData">
		/// <para>The argument to be passed to the callback function. This parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="pbCancel">
		/// <para>
		/// If this flag is set to <c>TRUE</c> during the copy operation, the operation is canceled. Otherwise, the copy operation will
		/// continue to completion.
		/// </para>
		/// </param>
		/// <param name="dwCopyFlags">
		/// <para>Flags that specify how the file is to be copied. This parameter can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>COPY_FILE_COPY_SYMLINK 0x00000800</term>
		/// <term>
		/// If the source file is a symbolic link, the destination file is also a symbolic link pointing to the same file that the source
		/// symbolic link is pointing to.
		/// </term>
		/// </item>
		/// <item>
		/// <term>COPY_FILE_FAIL_IF_EXISTS 0x00000001</term>
		/// <term>The copy operation fails immediately if the target file already exists.</term>
		/// </item>
		/// <item>
		/// <term>COPY_FILE_OPEN_SOURCE_FOR_WRITE 0x00000004</term>
		/// <term>The file is copied and the original file is opened for write access.</term>
		/// </item>
		/// <item>
		/// <term>COPY_FILE_RESTARTABLE 0x00000002</term>
		/// <term>
		/// Progress of the copy is tracked in the target file in case the copy fails. The failed copy can be restarted at a later time by
		/// specifying the same values for and as those used in the call that failed. This can significantly slow down the copy operation as
		/// the new file may be flushed multiple times during the copy operation.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information call GetLastError.</para>
		/// <para>
		/// If returns <c>PROGRESS_CANCEL</c> due to the user canceling the operation, <c>CopyFileTransacted</c> will return zero and
		/// GetLastError will return <c>ERROR_REQUEST_ABORTED</c>. In this case, the partially copied destination file is deleted.
		/// </para>
		/// <para>
		/// If returns <c>PROGRESS_STOP</c> due to the user stopping the operation, <c>CopyFileTransacted</c> will return zero and
		/// GetLastError will return <c>ERROR_REQUEST_ABORTED</c>. In this case, the partially copied destination file is left intact.
		/// </para>
		/// <para>
		/// If you attempt to call this function with a handle to a transaction that has already been rolled back, <c>CopyFileTransacted</c>
		/// will return either <c>ERROR_TRANSACTION_NOT_ACTIVE</c> or <c>ERROR_INVALID_TRANSACTION</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function preserves extended attributes, OLE structured storage, NTFS file system alternate data streams, security
		/// attributes, and file attributes.
		/// </para>
		/// <para>
		/// <c>Windows 7, Windows Server 2008 R2, Windows Server 2008 and Windows Vista:</c> Security resource attributes (
		/// <c>ATTRIBUTE_SECURITY_INFORMATION</c>) for the existing file are not copied to the new file until Windows 8 and Windows Server 2012.
		/// </para>
		/// <para>
		/// This function fails with <c>ERROR_ACCESS_DENIED</c> if the destination file already exists and has the
		/// <c>FILE_ATTRIBUTE_HIDDEN</c> or <c>FILE_ATTRIBUTE_READONLY</c> attribute set.
		/// </para>
		/// <para>Encrypted files are not supported by TxF.</para>
		/// <para>If <c>COPY_FILE_COPY_SYMLINK</c> is specified, the following rules apply:</para>
		/// <list type="bullet">
		/// <item>If the source file is a symbolic link, the symbolic link is copied, not the target file.</item>
		/// <item>If the source file is not a symbolic link, there is no change in behavior.</item>
		/// <item>If the destination file is an existing symbolic link, the symbolic link is overwritten, not the target file.</item>
		/// <item>
		/// If <c>COPY_FILE_FAIL_IF_EXISTS</c> is also specified, and the destination file is an existing symbolic link, the operation fails
		/// in all cases.
		/// </item>
		/// </list>
		/// <para>If</para>
		/// <para>COPY_FILE_COPY_SYMLINK</para>
		/// <para>is not specified, the following rules apply:</para>
		/// <list type="bullet">
		/// <item>
		/// If <c>COPY_FILE_FAIL_IF_EXISTS</c> is also specified, and the destination file is an existing symbolic link, the operation fails
		/// only if the target of the symbolic link exists.
		/// </item>
		/// <item>If <c>COPY_FILE_FAIL_IF_EXISTS</c> is not specified, there is no change in behavior.</item>
		/// </list>
		/// <para>Link tracking is not supported by TxF.</para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>Note that SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-copyfiletransacteda BOOL CopyFileTransactedA( LPCSTR
		// lpExistingFileName, LPCSTR lpNewFileName, LPPROGRESS_ROUTINE lpProgressRoutine, LPVOID lpData, LPBOOL pbCancel, DWORD dwCopyFlags,
		// HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "118392de-166b-413e-99c9-b3deb756de0e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CopyFileTransacted(string lpExistingFileName, string lpNewFileName, LpprogressRoutine lpProgressRoutine, IntPtr lpData, [MarshalAs(UnmanagedType.Bool)] ref bool pbCancel, COPY_FILE dwCopyFlags, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see
		/// </para>
		/// <para>Alternatives to using Transactional NTFS</para>
		/// <para>.]</para>
		/// <para>
		/// Creates a new directory as a transacted operation, with the attributes of a specified template directory. If the underlying file
		/// system supports security on files and directories, the function applies a specified security descriptor to the new directory. The
		/// new directory retains the other attributes of the specified template directory.
		/// </para>
		/// </summary>
		/// <param name="lpTemplateDirectory">
		/// <para>The path of the directory to use as a template when creating the new directory. This parameter can be <c>NULL</c>.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>The directory must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="lpNewDirectory">
		/// <para>The path of the directory to be created.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="lpSecurityAttributes">
		/// <para>
		/// A pointer to a SECURITY_ATTRIBUTES structure. The <c>lpSecurityDescriptor</c> member of the structure specifies a security
		/// descriptor for the new directory.
		/// </para>
		/// <para>
		/// If is <c>NULL</c>, the directory gets a default security descriptor. The access control lists (ACL) in the default security
		/// descriptor for a directory are inherited from its parent directory.
		/// </para>
		/// <para>
		/// The target file system must support security on files and directories for this parameter to have an effect. This is indicated
		/// when GetVolumeInformation returns <c>FS_PERSISTENT_ACLS</c>.
		/// </para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. Possible errors
		/// include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ALREADY_EXISTS</term>
		/// <term>The specified directory already exists.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_EFS_NOT_ALLOWED_IN_TRANSACTION</term>
		/// <term>You cannot create a child directory with a parent directory that has encryption disabled.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATH_NOT_FOUND</term>
		/// <term>One or more intermediate directories do not exist. This function only creates the final directory in the path.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CreateDirectoryTransacted</c> function allows you to create directories that inherit stream information from other
		/// directories. This function is useful, for example, when you are using Macintosh directories, which have a resource stream that is
		/// needed to properly identify directory contents as an attribute.
		/// </para>
		/// <para>
		/// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories. On
		/// volumes formatted for such a file system, a new directory inherits the compression and encryption attributes of its parent directory.
		/// </para>
		/// <para>
		/// This function fails with <c>ERROR_EFS_NOT_ALLOWED_IN_TRANSACTION</c> if you try to create a child directory with a parent
		/// directory that has encryption disabled.
		/// </para>
		/// <para>
		/// You can obtain a handle to a directory by calling the CreateFileTransacted function with the <c>FILE_FLAG_BACKUP_SEMANTICS</c>
		/// flag set.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createdirectorytransacteda BOOL
		// CreateDirectoryTransactedA( LPCSTR lpTemplateDirectory, LPCSTR lpNewDirectory, LPSECURITY_ATTRIBUTES lpSecurityAttributes, HANDLE
		// hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "75663b30-5bd9-4de7-8e4f-dc58016c2c40")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateDirectoryTransacted(string lpTemplateDirectory, string lpNewDirectory, SECURITY_ATTRIBUTES lpSecurityAttributes, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see
		/// </para>
		/// <para>Alternatives to using Transactional NTFS</para>
		/// <para>.]</para>
		/// <para>
		/// Creates or opens a file, file stream, or directory as a transacted operation. The function returns a handle that can be used to
		/// access the object.
		/// </para>
		/// <para>
		/// To perform this operation as a nontransacted operation or to access objects other than files (for example, named pipes, physical
		/// devices, mailslots), use the CreateFile function.
		/// </para>
		/// <para>For more information about transactions, see the Remarks section of this topic.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of an object to be created or opened.</para>
		/// <para>The object must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File. For
		/// information on special device names, see Defining an MS-DOS Device Name.
		/// </para>
		/// <para>
		/// To create a file stream, specify the name of the file, a colon, and then the name of the stream. For more information, see File Streams.
		/// </para>
		/// </param>
		/// <param name="dwDesiredAccess">
		/// <para>
		/// The access to the object, which can be summarized as read, write, both or neither (zero). The most commonly used values are
		/// <c>GENERIC_READ</c>, <c>GENERIC_WRITE</c>, or both ( <c>GENERIC_READ</c> | <c>GENERIC_WRITE</c>). For more information, see
		/// Generic Access Rights and File Security and Access Rights.
		/// </para>
		/// <para>
		/// If this parameter is zero, the application can query file, directory, or device attributes without accessing that file or device.
		/// For more information, see the Remarks section of this topic.
		/// </para>
		/// <para>
		/// You cannot request an access mode that conflicts with the sharing mode that is specified in an open request that has an open
		/// handle. For more information, see Creating and Opening Files.
		/// </para>
		/// </param>
		/// <param name="dwShareMode">
		/// <para>The sharing mode of an object, which can be read, write, both, delete, all of these, or none (refer to the following table).</para>
		/// <para>
		/// If this parameter is zero and <c>CreateFileTransacted</c> succeeds, the object cannot be shared and cannot be opened again until
		/// the handle is closed. For more information, see the Remarks section of this topic.
		/// </para>
		/// <para>
		/// You cannot request a sharing mode that conflicts with the access mode that is specified in an open request that has an open
		/// handle, because that would result in the following sharing violation: <c>ERROR_SHARING_VIOLATION</c>. For more information, see
		/// Creating and Opening Files.
		/// </para>
		/// <para>
		/// To enable a process to share an object while another process has the object open, use a combination of one or more of the
		/// following values to specify the access mode they can request to open the object.
		/// </para>
		/// <para>
		/// <c>Note</c> The sharing options for each open handle remain in effect until that handle is closed, regardless of process context.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0 0x00000000</term>
		/// <term>Disables subsequent open operations on an object to request any type of access to that object.</term>
		/// </item>
		/// <item>
		/// <term>FILE_SHARE_DELETE 0x00000004</term>
		/// <term>
		/// Enables subsequent open operations on an object to request delete access. Otherwise, other processes cannot open the object if
		/// they request delete access. If this flag is not specified, but the object has been opened for delete access, the function fails.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_SHARE_READ 0x00000001</term>
		/// <term>
		/// Enables subsequent open operations on an object to request read access. Otherwise, other processes cannot open the object if they
		/// request read access. If this flag is not specified, but the object has been opened for read access, the function fails.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_SHARE_WRITE 0x00000002</term>
		/// <term>
		/// Enables subsequent open operations on an object to request write access. Otherwise, other processes cannot open the object if
		/// they request write access. If this flag is not specified, but the object has been opened for write access or has a file mapping
		/// with write access, the function fails.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpSecurityAttributes">
		/// <para>
		/// A pointer to a SECURITY_ATTRIBUTES structure that contains an optional security descriptor and also determines whether or not the
		/// returned handle can be inherited by child processes. The parameter can be <c>NULL</c>.
		/// </para>
		/// <para>
		/// If the parameter is <c>NULL</c>, the handle returned by <c>CreateFileTransacted</c> cannot be inherited by any child processes
		/// your application may create and the object associated with the returned handle gets a default security descriptor.
		/// </para>
		/// <para>The <c>bInheritHandle</c> member of the structure specifies whether the returned handle can be inherited.</para>
		/// <para>
		/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for an object, but may also be <c>NULL</c>.
		/// </para>
		/// <para>
		/// If <c>lpSecurityDescriptor</c> member is <c>NULL</c>, the object associated with the returned handle is assigned a default
		/// security descriptor.
		/// </para>
		/// <para>
		/// <c>CreateFileTransacted</c> ignores the <c>lpSecurityDescriptor</c> member when opening an existing file, but continues to use
		/// the <c>bInheritHandle</c> member.
		/// </para>
		/// <para>For more information, see the Remarks section of this topic.</para>
		/// </param>
		/// <param name="dwCreationDisposition">
		/// <para>An action to take on files that exist and do not exist.</para>
		/// <para>For more information, see the Remarks section of this topic.</para>
		/// <para>This parameter must be one of the following values, which cannot be combined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CREATE_ALWAYS 2</term>
		/// <term>
		/// Creates a new file, always. If the specified file exists and is writable, the function overwrites the file, the function
		/// succeeds, and last-error code is set to ERROR_ALREADY_EXISTS (183). If the specified file does not exist and is a valid path, a
		/// new file is created, the function succeeds, and the last-error code is set to zero. For more information, see the Remarks section
		/// of this topic.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CREATE_NEW 1</term>
		/// <term>
		/// Creates a new file, only if it does not already exist. If the specified file exists, the function fails and the last-error code
		/// is set to ERROR_FILE_EXISTS (80). If the specified file does not exist and is a valid path to a writable location, a new file is created.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OPEN_ALWAYS 4</term>
		/// <term>
		/// Opens a file, always. If the specified file exists, the function succeeds and the last-error code is set to ERROR_ALREADY_EXISTS
		/// (183). If the specified file does not exist and is a valid path to a writable location, the function creates a file and the
		/// last-error code is set to zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OPEN_EXISTING 3</term>
		/// <term>
		/// Opens a file or device, only if it exists. If the specified file does not exist, the function fails and the last-error code is
		/// set to ERROR_FILE_NOT_FOUND (2). For more information, see the Remarks section of this topic.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TRUNCATE_EXISTING 5</term>
		/// <term>
		/// Opens a file and truncates it so that its size is zero bytes, only if it exists. If the specified file does not exist, the
		/// function fails and the last-error code is set to ERROR_FILE_NOT_FOUND (2). The calling process must open the file with the
		/// GENERIC_WRITE bit set as part of the parameter.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFlagsAndAttributes">
		/// <para>The file attributes and flags, <c>FILE_ATTRIBUTE_NORMAL</c> being the most common default value.</para>
		/// <para>
		/// This parameter can include any combination of the available file attributes ( <c>FILE_ATTRIBUTE_*</c>). All other file attributes
		/// override <c>FILE_ATTRIBUTE_NORMAL</c>.
		/// </para>
		/// <para>
		/// This parameter can also contain combinations of flags ( <c>FILE_FLAG_</c>) for control of buffering behavior, access modes, and
		/// other special-purpose flags. These combine with any <c>FILE_ATTRIBUTE_</c> values.
		/// </para>
		/// <para>
		/// This parameter can also contain Security Quality of Service (SQOS) information by specifying the <c>SECURITY_SQOS_PRESENT</c>
		/// flag. Additional SQOS-related flags information is presented in the table following the attributes and flags tables.
		/// </para>
		/// <para>
		/// <c>Note</c> When <c>CreateFileTransacted</c> opens an existing file, it generally combines the file flags with the file
		/// attributes of the existing file, and ignores any file attributes supplied as part of . Special cases are detailed in Creating and
		/// Opening Files.
		/// </para>
		/// <para>The following file attributes and flags are used only for file objects, not other types of objects that</para>
		/// <para>CreateFileTransacted</para>
		/// <para>
		/// opens (additional information can be found in the Remarks section of this topic). For more advanced access to file attributes, see
		/// </para>
		/// <para>SetFileAttributes</para>
		/// <para>. For a complete list of all file attributes with their values and descriptions, see</para>
		/// <para>File Attribute Constants</para>
		/// <para>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_ATTRIBUTE_ARCHIVE 32 (0x20)</term>
		/// <term>The file should be archived. Applications use this attribute to mark files for backup or removal.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_ENCRYPTED 16384 (0x4000)</term>
		/// <term>
		/// The file or directory is encrypted. For a file, this means that all data in the file is encrypted. For a directory, this means
		/// that encryption is the default for newly created files and subdirectories. For more information, see File Encryption. This flag
		/// has no effect if FILE_ATTRIBUTE_SYSTEM is also specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_HIDDEN 2 (0x2)</term>
		/// <term>The file is hidden. Do not include it in an ordinary directory listing.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_NORMAL 128 (0x80)</term>
		/// <term>The file does not have other attributes set. This attribute is valid only if used alone.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_OFFLINE 4096 (0x1000)</term>
		/// <term>
		/// The data of a file is not immediately available. This attribute indicates that file data is physically moved to offline storage.
		/// This attribute is used by Remote Storage, the hierarchical storage management software. Applications should not arbitrarily
		/// change this attribute.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_READONLY 1 (0x1)</term>
		/// <term>The file is read only. Applications can read the file, but cannot write to or delete it.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_SYSTEM 4 (0x4)</term>
		/// <term>The file is part of or used exclusively by an operating system.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_TEMPORARY 256 (0x100)</term>
		/// <term>
		/// The file is being used for temporary storage. File systems avoid writing data back to mass storage if sufficient cache memory is
		/// available, because an application deletes a temporary file after a handle is closed. In that case, the system can entirely avoid
		/// writing the data. Otherwise, the data is written after the handle is closed.
		/// </term>
		/// </item>
		/// </list>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_FLAG_BACKUP_SEMANTICS 0x02000000</term>
		/// <term>
		/// The file is being opened or created for a backup or restore operation. The system ensures that the calling process overrides file
		/// security checks when the process has SE_BACKUP_NAME and SE_RESTORE_NAME privileges. For more information, see Changing Privileges
		/// in a Token. You must set this flag to obtain a handle to a directory. A directory handle can be passed to some functions instead
		/// of a file handle. For more information, see Directory Handles.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_DELETE_ON_CLOSE 0x04000000</term>
		/// <term>
		/// The file is to be deleted immediately after the last transacted writer handle to the file is closed, provided that the
		/// transaction is still active. If a file has been marked for deletion and a transacted writer handle is still open after the
		/// transaction completes, the file will not be deleted. If there are existing open handles to a file, the call fails unless they
		/// were all opened with the FILE_SHARE_DELETE share mode. Subsequent open requests for the file fail, unless the FILE_SHARE_DELETE
		/// share mode is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_NO_BUFFERING 0x20000000</term>
		/// <term>
		/// The file is being opened with no system caching. This flag does not affect hard disk caching or memory mapped files. When
		/// combined with FILE_FLAG_OVERLAPPED, the flag gives maximum asynchronous performance, because the I/O does not rely on the
		/// synchronous operations of the memory manager. However, some I/O operations take more time, because data is not being held in the
		/// cache. Also, the file metadata may still be cached. To flush the metadata to disk, use the FlushFileBuffers function. An
		/// application must meet certain requirements when working with files that are opened with FILE_FLAG_NO_BUFFERING: One way to align
		/// buffers on integer multiples of the volume sector size is to use VirtualAlloc to allocate the buffers. It allocates memory that
		/// is aligned on addresses that are integer multiples of the operating system's memory page size. Because both memory page and
		/// volume sector sizes are powers of 2, this memory is also aligned on addresses that are integer multiples of a volume sector size.
		/// Memory pages are 4 or 8 KB in size; sectors are 512 bytes (hard disks), 2048 bytes (CD), or 4096 bytes (hard disks), and
		/// therefore, volume sectors can never be larger than memory pages. An application can determine a volume sector size by calling the
		/// GetDiskFreeSpace function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_OPEN_NO_RECALL 0x00100000</term>
		/// <term>
		/// The file data is requested, but it should continue to be located in remote storage. It should not be transported back to local
		/// storage. This flag is for use by remote storage systems.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_OPEN_REPARSE_POINT 0x00200000</term>
		/// <term>
		/// Normal reparse point processing will not occur; CreateFileTransacted will attempt to open the reparse point. When a file is
		/// opened, a file handle is returned, whether or not the filter that controls the reparse point is operational. This flag cannot be
		/// used with the CREATE_ALWAYS flag. If the file is not a reparse point, then this flag is ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_OVERLAPPED 0x40000000</term>
		/// <term>
		/// The file is being opened or created for asynchronous I/O. When the operation is complete, the event specified in the OVERLAPPED
		/// structure is set to the signaled state. Operations that take a significant amount of time to process return ERROR_IO_PENDING. If
		/// this flag is specified, the file can be used for simultaneous read and write operations. The system does not maintain the file
		/// pointer, therefore you must pass the file position to the read and write functions in the OVERLAPPED structure or update the file
		/// pointer. If this flag is not specified, then I/O operations are serialized, even if the calls to the read and write functions
		/// specify an OVERLAPPED structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_POSIX_SEMANTICS 0x0100000</term>
		/// <term>
		/// The file is to be accessed according to POSIX rules. This includes allowing multiple files with names, differing only in case,
		/// for file systems that support that naming. Use care when using this option, because files created with this flag may not be
		/// accessible by applications that are written for MS-DOS or 16-bit Windows.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_RANDOM_ACCESS 0x10000000</term>
		/// <term>The file is to be accessed randomly. The system can use this as a hint to optimize file caching.</term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_SESSION_AWARE 0x00800000</term>
		/// <term>
		/// The file or device is being opened with session awareness. If this flag is not specified, then per-session devices (such as a
		/// device using RemoteFX USB Redirection) cannot be opened by processes running in session 0. This flag has no effect for callers
		/// not in session 0. This flag is supported only on server editions of Windows. Windows Server 2008 R2 and Windows Server 2008: This
		/// flag is not supported before Windows Server 2012.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_SEQUENTIAL_SCAN 0x08000000</term>
		/// <term>
		/// The file is to be accessed sequentially from beginning to end. The system can use this as a hint to optimize file caching. If an
		/// application moves the file pointer for random access, optimum caching may not occur. However, correct operation is still
		/// guaranteed. Specifying this flag can increase performance for applications that read large files using sequential access.
		/// Performance gains can be even more noticeable for applications that read large files mostly sequentially, but occasionally skip
		/// over small ranges of bytes. This flag has no effect if the file system does not support cached I/O and FILE_FLAG_NO_BUFFERING.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_WRITE_THROUGH 0x80000000</term>
		/// <term>
		/// Write operations will not go through any intermediate cache, they will go directly to disk. If FILE_FLAG_NO_BUFFERING is not also
		/// specified, so that system caching is in effect, then the data is written to the system cache, but is flushed to disk without
		/// delay. If FILE_FLAG_NO_BUFFERING is also specified, so that system caching is not in effect, then the data is immediately flushed
		/// to disk without going through the system cache. The operating system also requests a write-through the hard disk cache to
		/// persistent media. However, not all hardware supports this write-through capability.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The parameter can also specify Security Quality of Service information. For more information, see Impersonation Levels. When the
		/// calling application specifies the <c>SECURITY_SQOS_PRESENT</c> flag as part of , it can also contain one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Security flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SECURITY_ANONYMOUS</term>
		/// <term>Impersonates a client at the Anonymous impersonation level.</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_CONTEXT_TRACKING</term>
		/// <term>The security tracking mode is dynamic. If this flag is not specified, the security tracking mode is static.</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_DELEGATION</term>
		/// <term>Impersonates a client at the Delegation impersonation level.</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_EFFECTIVE_ONLY</term>
		/// <term>
		/// Only the enabled aspects of the client's security context are available to the server. If you do not specify this flag, all
		/// aspects of the client's security context are available. This allows the client to limit the groups and privileges that a server
		/// can use while impersonating the client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECURITY_IDENTIFICATION</term>
		/// <term>Impersonates a client at the Identification impersonation level.</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_IMPERSONATION</term>
		/// <term>
		/// Impersonate a client at the impersonation level. This is the default behavior if no other flags are specified along with the
		/// SECURITY_SQOS_PRESENT flag.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hTemplateFile">
		/// <para>
		/// A valid handle to a template file with the <c>GENERIC_READ</c> access right. The template file supplies file attributes and
		/// extended attributes for the file that is being created. This parameter can be <c>NULL</c>.
		/// </para>
		/// <para>When opening an existing file, <c>CreateFileTransacted</c> ignores the template file.</para>
		/// <para>When opening a new EFS-encrypted file, the file inherits the DACL from its parent directory.</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <param name="pusMiniVersion">
		/// <para>
		/// The miniversion to be opened. If the transaction specified in is not the transaction that is modifying the file, this parameter
		/// should be <c>NULL</c>. Otherwise, this parameter can be a miniversion identifier returned by the FSCTL_TXFS_CREATE_MINIVERSION
		/// control code, or one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TXFS_MINIVERSION_COMMITTED_VIEW 0x0000</term>
		/// <term>The view of the file as of its last commit.</term>
		/// </item>
		/// <item>
		/// <term>TXFS_MINIVERSION_DIRTY_VIEW 0xFFFF</term>
		/// <term>The view of the file as it is being modified by the transaction.</term>
		/// </item>
		/// <item>
		/// <term>TXFS_MINIVERSION_DEFAULT_VIEW 0xFFFE</term>
		/// <term>
		/// Either the committed or dirty view of the file, depending on the context. A transaction that is modifying the file gets the dirty
		/// view, while a transaction that is not modifying the file gets the committed view.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpExtendedParameter">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.</para>
		/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When using the handle returned by <c>CreateFileTransacted</c>, use the transacted version of file I/O functions instead of the
		/// standard file I/O functions where appropriate. For more information, see Programming Considerations for Transactional NTFS.
		/// </para>
		/// <para>
		/// When opening a transacted handle to a directory, that handle must have <c>FILE_WRITE_DATA</c> ( <c>FILE_ADD_FILE</c>) and
		/// <c>FILE_APPEND_DATA</c> ( <c>FILE_ADD_SUBDIRECTORY</c>) permissions. These are included in <c>FILE_GENERIC_WRITE</c> permissions.
		/// You should open directories with fewer permissions if you are just using the handle to create files or subdirectories; otherwise,
		/// sharing violations can occur.
		/// </para>
		/// <para>
		/// You cannot open a file with <c>FILE_EXECUTE</c> access level when that file is a part of another transaction (that is, another
		/// application opened it by calling <c>CreateFileTransacted</c>). This means that <c>CreateFileTransacted</c> fails if the access
		/// level <c>FILE_EXECUTE</c> or <c>FILE_ALL_ACCESS</c> is specified
		/// </para>
		/// <para>
		/// When a non-transacted application calls <c>CreateFileTransacted</c> with <c>MAXIMUM_ALLOWED</c> specified for , a handle is
		/// opened with the same access level every time. When a transacted application calls <c>CreateFileTransacted</c> with
		/// <c>MAXIMUM_ALLOWED</c> specified for , a handle is opened with a differing amount of access based on whether the file is locked
		/// by a transaction. For example, if the calling application has <c>FILE_EXECUTE</c> access level for a file, the application only
		/// obtains this access if the file that is being opened is either not locked by a transaction, or is locked by a transaction and the
		/// application is already a transacted reader for that file.
		/// </para>
		/// <para>See Transactional NTFS for a complete description of transacted operations.</para>
		/// <para>
		/// Use the CloseHandle function to close an object handle returned by <c>CreateFileTransacted</c> when the handle is no longer
		/// needed, and prior to committing or rolling back the transaction.
		/// </para>
		/// <para>
		/// Some file systems, such as the NTFS file system, support compression or encryption for individual files and directories. On
		/// volumes that are formatted for that kind of file system, a new file inherits the compression and encryption attributes of its directory.
		/// </para>
		/// <para>
		/// You cannot use <c>CreateFileTransacted</c> to control compression on a file or directory. For more information, see File
		/// Compression and Decompression, and File Encryption.
		/// </para>
		/// <para>Symbolic link behavior—If the call to this function creates a new file, there is no change in behavior.</para>
		/// <para>If <c>FILE_FLAG_OPEN_REPARSE_POINT</c> is specified:</para>
		/// <list type="bullet">
		/// <item>If an existing file is opened and it is a symbolic link, the handle returned is a handle to the symbolic link.</item>
		/// <item>If <c>TRUNCATE_EXISTING</c> or <c>FILE_FLAG_DELETE_ON_CLOSE</c> are specified, the file affected is a symbolic link.</item>
		/// </list>
		/// <para>If</para>
		/// <para>FILE_FLAG_OPEN_REPARSE_POINT</para>
		/// <para>is not specified:</para>
		/// <list type="bullet">
		/// <item>If an existing file is opened and it is a symbolic link, the handle returned is a handle to the target.</item>
		/// <item>
		/// If <c>CREATE_ALWAYS</c>, <c>TRUNCATE_EXISTING</c>, or <c>FILE_FLAG_DELETE_ON_CLOSE</c> are specified, the file affected is the target.
		/// </item>
		/// </list>
		/// <para>
		/// A multi-sector write is not guaranteed to be atomic unless you are using a transaction (that is, the handle created is a
		/// transacted handle). A single-sector write is atomic. Multi-sector writes that are cached may not always be written to the disk;
		/// therefore, specify
		/// </para>
		/// <para>FILE_FLAG_WRITE_THROUGH</para>
		/// <para>to ensure that an entire multi-sector write is written to the disk without caching.</para>
		/// <para>
		/// As stated previously, if the parameter is <c>NULL</c>, the handle returned by <c>CreateFileTransacted</c> cannot be inherited by
		/// any child processes your application may create. The following information regarding this parameter also applies:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// If <c>bInheritHandle</c> is not <c>FALSE</c>, which is any nonzero value, then the handle can be inherited. Therefore it is
		/// critical this structure member be properly initialized to <c>FALSE</c> if you do not intend the handle to be inheritable.
		/// </item>
		/// <item>
		/// The access control lists (ACL) in the default security descriptor for a file or directory are inherited from its parent directory.
		/// </item>
		/// <item>
		/// The target file system must support security on files and directories for the <c>lpSecurityDescriptor</c> to have an effect on
		/// them, which can be determined by using GetVolumeInformation
		/// </item>
		/// </list>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>Note that SMB 3.0 does not support TxF.</para>
		/// <para>Files</para>
		/// <para>
		/// If you try to create a file on a floppy drive that does not have a floppy disk or a CD-ROM drive that does not have a CD, the
		/// system displays a message for the user to insert a disk or a CD. To prevent the system from displaying this message, call the
		/// </para>
		/// <para>SetErrorMode</para>
		/// <para>function with</para>
		/// <para>SEM_FAILCRITICALERRORS</para>
		/// <para>.</para>
		/// <para>For more information, see Creating and Opening Files.</para>
		/// <para>
		/// If you rename or delete a file and then restore it shortly afterward, the system searches the cache for file information to
		/// restore. Cached information includes its short/long name pair and creation time.
		/// </para>
		/// <para>
		/// If you call <c>CreateFileTransacted</c> on a file that is pending deletion as a result of a previous call to DeleteFile, the
		/// function fails. The operating system delays file deletion until all handles to the file are closed. GetLastError returns <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>
		/// The parameter can be zero, allowing the application to query file attributes without accessing the file if the application is
		/// running with adequate security settings. This is useful to test for the existence of a file without opening it for read and/or
		/// write access, or to obtain other statistics about the file or directory. See Obtaining and Setting File Information and GetFileInformationByHandle.
		/// </para>
		/// <para>
		/// When an application creates a file across a network, it is better to use <c>GENERIC_READ</c> | <c>GENERIC_WRITE</c> than to use
		/// <c>GENERIC_WRITE</c> alone. The resulting code is faster, because the redirector can use the cache manager and send fewer SMBs
		/// with more data. This combination also avoids an issue where writing to a file across a network can occasionally return <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>File Streams</para>
		/// <para>On NTFS file systems, you can use</para>
		/// <para>CreateFileTransacted</para>
		/// <para>to create separate streams within a file.</para>
		/// <para>For more information, see File Streams.</para>
		/// <para>Directories</para>
		/// <para>An application cannot create a directory by using</para>
		/// <para>CreateFileTransacted</para>
		/// <para>, therefore only the</para>
		/// <para>OPEN_EXISTING</para>
		/// <para>value is valid for</para>
		/// <para>dwCreationDisposition</para>
		/// <para>for this use case. To create a directory, the application must call</para>
		/// <para>CreateDirectoryTransacted</para>
		/// <para>,</para>
		/// <para>CreateDirectory</para>
		/// <para>or</para>
		/// <para>CreateDirectoryEx</para>
		/// <para>.</para>
		/// <para>
		/// To open a directory using <c>CreateFileTransacted</c>, specify the <c>FILE_FLAG_BACKUP_SEMANTICS</c> flag as part of .
		/// Appropriate security checks still apply when this flag is used without <c>SE_BACKUP_NAME</c> and <c>SE_RESTORE_NAME</c> privileges.
		/// </para>
		/// <para>
		/// When using <c>CreateFileTransacted</c> to open a directory during defragmentation of a FAT or FAT32 file system volume, do not
		/// specify the <c>MAXIMUM_ALLOWED</c> access right. Access to the directory is denied if this is done. Specify the
		/// <c>GENERIC_READ</c> access right instead.
		/// </para>
		/// <para>For more information, see About Directory Management.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createfiletransacteda HANDLE CreateFileTransactedA( LPCSTR
		// lpFileName, DWORD dwDesiredAccess, DWORD dwShareMode, LPSECURITY_ATTRIBUTES lpSecurityAttributes, DWORD dwCreationDisposition,
		// DWORD dwFlagsAndAttributes, HANDLE hTemplateFile, HANDLE hTransaction, PUSHORT pusMiniVersion, PVOID lpExtendedParameter );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "0cbc081d-8787-409b-84bc-a6a28d8f83a0")]
		public static extern SafeFileHandle CreateFileTransacted(string lpFileName, FileAccess dwDesiredAccess, FileShare dwShareMode, SECURITY_ATTRIBUTES lpSecurityAttributes, FileMode dwCreationDisposition, FileFlagsAndAttributes dwFlagsAndAttributes,
			IntPtr hTemplateFile, IntPtr hTransaction, ref ushort pusMiniVersion, IntPtr lpExtendedParameter);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see
		/// </para>
		/// <para>Alternatives to using Transactional NTFS</para>
		/// <para>.]</para>
		/// <para>
		/// Establishes a hard link between an existing file and a new file as a transacted operation. This function is only supported on the
		/// NTFS file system, and only for files, not directories.
		/// </para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of the new file.</para>
		/// <para>This parameter cannot specify the name of a directory.</para>
		/// </param>
		/// <param name="lpExistingFileName">
		/// <para>The name of the existing file.</para>
		/// <para>This parameter cannot specify the name of a directory.</para>
		/// </param>
		/// <param name="lpSecurityAttributes">
		/// <para>Reserved; must be <c>NULL</c>.</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero (0). To get extended error information, call GetLastError.</para>
		/// <para>
		/// The maximum number of hard links that can be created with this function is 1023 per file. If more than 1023 links are created for
		/// a file, an error results.
		/// </para>
		/// <para>The files must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any directory entry for a file that is created with CreateFileTransacted or <c>CreateHardLinkTransacted</c> is a hard link to an
		/// associated file. An additional hard link that is created with the <c>CreateHardLinkTransacted</c> function allows you to have
		/// multiple directory entries for a file, that is, multiple hard links to the same file, which can be different names in the same
		/// directory, or the same or different names in different directories. However, all hard links to a file must be on the same volume.
		/// </para>
		/// <para>
		/// Because hard links are only directory entries for a file, when an application modifies a file through any hard link, all
		/// applications that use any other hard link to the file see the changes. Also, all of the directory entries are updated if the file
		/// changes. For example, if a file size changes, all of the hard links to the file show the new file size.
		/// </para>
		/// <para>
		/// The security descriptor belongs to the file to which a hard link points. The link itself is only a directory entry, and does not
		/// have a security descriptor. Therefore, when you change the security descriptor of a hard link, you a change the security
		/// descriptor of the underlying file, and all hard links that point to the file allow the newly specified access. You cannot give a
		/// file different security descriptors on a per-hard-link basis.
		/// </para>
		/// <para>
		/// This function does not modify the security descriptor of the file to be linked to, even if security descriptor information is
		/// passed in the parameter.
		/// </para>
		/// <para>
		/// Use DeleteFileTransacted to delete hard links. You can delete them in any order regardless of the order in which they are created.
		/// </para>
		/// <para>
		/// Flags, attributes, access, and sharing that are specified in CreateFileTransacted operate on a per-file basis. That is, if you
		/// open a file that does not allow sharing, another application cannot share the file by creating a new hard link to the file.
		/// </para>
		/// <para>
		/// When you create a hard link on the NTFS file system, the file attribute information in the directory entry is refreshed only when
		/// the file is opened, or when GetFileInformationByHandle is called with the handle of a specific file.
		/// </para>
		/// <para><c>Symbolic links:</c> If the path points to a symbolic link, the function creates a hard link to the target.</para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>Note that SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createhardlinktransacteda BOOL CreateHardLinkTransactedA(
		// LPCSTR lpFileName, LPCSTR lpExistingFileName, LPSECURITY_ATTRIBUTES lpSecurityAttributes, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "27dd5b0a-08ef-4757-8f51-03d9918028c8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateHardLinkTransacted(string lpFileName, string lpExistingFileName, SECURITY_ATTRIBUTES lpSecurityAttributes, IntPtr hTransaction);

		/// <summary>
		/// <para>Creates a user-mode scheduling (UMS) completion list.</para>
		/// </summary>
		/// <param name="UmsCompletionList">
		/// <para>A <c>PUMS_COMPLETION_LIST</c> variable. On output, this parameter receives a pointer to an empty UMS completion list.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible error values
		/// include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to create the completion list.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A completion list is associated with a UMS scheduler thread when the EnterUmsSchedulingMode function is called to create the
		/// scheduler thread. The system queues newly created UMS worker threads to the completion list. It also queues previously blocked
		/// UMS worker threads to the completion list when the threads are no longer blocked.
		/// </para>
		/// <para>
		/// When an application's UmsSchedulerProc entry point function is called, the application's scheduler should retrieve items from the
		/// completion list by calling DequeueUmsCompletionListItems.
		/// </para>
		/// <para>
		/// Each completion list has an associated completion list event which is signaled whenever the system queues items to an empty list.
		/// Use the GetUmsCompletionListEvent to obtain a handle to the event for a specified completion list.
		/// </para>
		/// <para>
		/// When a completion list is no longer needed, use the DeleteUmsCompletionList to release the list. The list must be empty before it
		/// can be released.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createumscompletionlist BOOL CreateUmsCompletionList(
		// PUMS_COMPLETION_LIST *UmsCompletionList );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "6e77b793-a82e-4e23-8c8b-7aff79d69346")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateUmsCompletionList(out IntPtr UmsCompletionList);

		/// <summary>
		/// <para>Creates a user-mode scheduling (UMS) thread context to represent a UMS worker thread.</para>
		/// </summary>
		/// <param name="lpUmsThread">
		/// <para>A PUMS_CONTEXT variable. On output, this parameter receives a pointer to a UMS thread context.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible error values
		/// include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to create the UMS thread context.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A UMS thread context represents the state of a UMS worker thread. Thread contexts are used to specify UMS worker threads in
		/// function calls.
		/// </para>
		/// <para>
		/// A UMS worker thread is created by calling the CreateRemoteThreadEx function after using InitializeProcThreadAttributeList and
		/// UpdateProcThreadAttribute to prepare a list of UMS attributes for the thread.
		/// </para>
		/// <para>
		/// The underlying structures for a UMS thread context are managed by the system and should not be modified directly. To get and set
		/// information about a UMS worker thread, use the QueryUmsThreadInformation and SetUmsThreadInformation functions.
		/// </para>
		/// <para>After a UMS worker thread terminates, its thread context should be released by calling DeleteUmsThreadContext.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createumsthreadcontext BOOL CreateUmsThreadContext(
		// PUMS_CONTEXT *lpUmsThread );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "b27ce81a-8463-46af-8acf-2de091f625df")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateUmsThreadContext(out IntPtr lpUmsThread);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Deletes an existing file as a transacted operation.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of the file to be deleted.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>The file must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If an application attempts to delete a file that does not exist, the <c>DeleteFileTransacted</c> function fails with
		/// <c>ERROR_FILE_NOT_FOUND</c>. If the file is a read-only file, the function fails with <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>The following list identifies some tips for deleting, removing, or closing files:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>To delete a read-only file, first you must remove the read-only attribute.</term>
		/// </item>
		/// <item>
		/// <term>
		/// To delete or rename a file, you must have either delete permission on the file, or delete child permission in the parent directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>To recursively delete the files in a directory, use the SHFileOperation function.</term>
		/// </item>
		/// <item>
		/// <term>To remove an empty directory, use the RemoveDirectoryTransacted function.</term>
		/// </item>
		/// <item>
		/// <term>To close an open file, use the CloseHandle function.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If you set up a directory with all access except delete and delete child, and the access control lists (ACL) of new files are
		/// inherited, then you can create a file without being able to delete it. However, then you can create a file, and then get all the
		/// access you request on the handle that is returned to you at the time you create the file.
		/// </para>
		/// <para>
		/// If you request delete permission at the time you create a file, you can delete or rename the file with that handle, but not with
		/// any other handle. For more information, see File Security and Access Rights.
		/// </para>
		/// <para>
		/// The <c>DeleteFileTransacted</c> function fails if an application attempts to delete a file that has other handles open for normal
		/// I/O or as a memory-mapped file ( <c>FILE_SHARE_DELETE</c> must have been specified when other handles were opened).
		/// </para>
		/// <para>
		/// The <c>DeleteFileTransacted</c> function marks a file for deletion on close. The file is deleted after the last transacted writer
		/// handle to the file is closed, provided that the transaction is still active. If a file has been marked for deletion and a
		/// transacted writer handle is still open after the transaction completes, the file will not be deleted.
		/// </para>
		/// <para>
		/// <c>Symbolic links:</c> If the path points to a symbolic link, the symbolic link is deleted, not the target. To delete a target,
		/// you must call CreateFile and specify <c>FILE_FLAG_DELETE_ON_CLOSE</c>.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-deletefiletransacteda BOOL DeleteFileTransactedA( LPCSTR
		// lpFileName, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "e0a6230b-2da1-4746-95fe-80f7b6bae41f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteFileTransacted(string lpFileName, IntPtr hTransaction);

		/// <summary>
		/// <para>Deletes the specified user-mode scheduling (UMS) completion list. The list must be empty.</para>
		/// </summary>
		/// <param name="UmsCompletionList">
		/// <para>A pointer to the UMS completion list to be deleted. The CreateUmsCompletionList function provides this pointer.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the completion list is shared, the caller is responsible for ensuring that no active UMS thread holds a reference to the list
		/// before deleting it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-deleteumscompletionlist BOOL DeleteUmsCompletionList(
		// PUMS_COMPLETION_LIST UmsCompletionList );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "98124359-ddd1-468c-9f99-74dd3f631fa1")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteUmsCompletionList(IntPtr UmsCompletionList);

		/// <summary>
		/// <para>Deletes the specified user-mode scheduling (UMS) thread context. The thread must be terminated.</para>
		/// </summary>
		/// <param name="UmsThread">
		/// <para>A pointer to the UMS thread context to be deleted. The CreateUmsThreadContext function provides this pointer.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>A UMS thread context cannot be deleted until the associated thread has terminated.</para>
		/// <para>
		/// When a UMS worker thread finishes running (for example, by returning from its thread entry point function), the system terminates
		/// the thread, sets the termination status in the thread's UMS thread context, and queues the UMS thread context to the associated
		/// completion list.
		/// </para>
		/// <para>Any attempt to execute the UMS thread will fail because the thread is already terminated.</para>
		/// <para>
		/// To check the termination status of a thread, the application's scheduler should call QueryUmsThreadInformation with the
		/// <c>UmsIsThreadTerminated</c> information class.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-deleteumsthreadcontext BOOL DeleteUmsThreadContext(
		// PUMS_CONTEXT UmsThread );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "cdd118fc-f664-44ce-958d-857216ceb9a7")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteUmsThreadContext(IntPtr UmsThread);

		/// <summary>
		/// <para>Retrieves user-mode scheduling (UMS) worker threads from the specified UMS completion list.</para>
		/// </summary>
		/// <param name="UmsCompletionList">
		/// <para>A pointer to the completion list from which to retrieve worker threads.</para>
		/// </param>
		/// <param name="WaitTimeOut">
		/// <para>
		/// The time-out interval for the retrieval operation, in milliseconds. The function returns if the interval elapses, even if no
		/// worker threads are queued to the completion list.
		/// </para>
		/// <para>
		/// If the WaitTimeOut parameter is zero, the completion list is checked for available worker threads without waiting for worker
		/// threads to become available. If the WaitTimeOut parameter is INFINITE, the function's time-out interval never elapses. This is
		/// not recommended, however, because it causes the function to block until one or more worker threads become available.
		/// </para>
		/// </param>
		/// <param name="UmsThreadList">
		/// <para>
		/// A pointer to a UMS_CONTEXT variable. On output, this parameter receives a pointer to the first UMS thread context in a list of
		/// UMS thread contexts.
		/// </para>
		/// <para>
		/// If no worker threads are available before the time-out specified by the WaitTimeOut parameter, this parameter is set to NULL.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible error values
		/// include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_TIMEOUT</term>
		/// <term>No threads became available before the specified time-out interval elapsed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The system queues a UMS worker thread to a completion list when the worker thread is created or when a previously blocked worker
		/// thread becomes unblocked. The <c>DequeueUmsCompletionListItems</c> function retrieves a pointer to a list of all thread contexts
		/// in the specified completion list. The GetNextUmsListItem function can be used to pop UMS thread contexts off the list into the
		/// scheduler's own ready thread queue. The scheduler is responsible for selecting threads to run based on priorities chosen by the application.
		/// </para>
		/// <para>
		/// Do not run UMS threads directly from the list provided by <c>DequeueUmsCompletionListItems</c>, or run a thread transferred from
		/// the list to the ready thread queue before the list is completely empty. This can cause unpredictable behavior in the application.
		/// </para>
		/// <para>
		/// If more than one caller attempts to retrieve threads from a shared completion list, only the first caller retrieves the threads.
		/// For subsequent callers, the <c>DequeueUmsCompletionListItems</c> function returns success but the UmsThreadList parameter is set
		/// to NULL.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-dequeueumscompletionlistitems BOOL
		// DequeueUmsCompletionListItems( PUMS_COMPLETION_LIST UmsCompletionList, DWORD WaitTimeOut, PUMS_CONTEXT *UmsThreadList );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "91499eb9-9fc5-4135-95f6-1bced78f1e07")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DequeueUmsCompletionListItems(IntPtr UmsCompletionList, uint WaitTimeOut, out IntPtr UmsThreadList);

		/// <summary>Disables thread profiling.</summary>
		/// <param name="PerformanceDataHandle">The handle that the <c>EnableThreadProfiling</c> function returned.</param>
		/// <returns>Returns ERROR_SUCCESS if the call is successful; otherwise, a system error code (see Winerror.h).</returns>
		// DWORD APIENTRY DisableThreadProfiling( _In_ HANDLE PerformanceDataHandle); https://msdn.microsoft.com/en-us/library/windows/desktop/dd796392(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "dd796392")]
		public static extern Win32Error DisableThreadProfiling(IntPtr PerformanceDataHandle);

		/// <summary>Enables thread profiling on the specified thread.</summary>
		/// <param name="ThreadHandle">The handle to the thread on which you want to enable profiling. This must be the current thread.</param>
		/// <param name="Flags">
		/// To receive thread profiling data such as context switch count, set this parameter to THREAD_PROFILING_FLAG_DISPATCH; otherwise,
		/// set to 0.
		/// </param>
		/// <param name="HardwareCounters">
		/// To receive hardware performance counter data, set this parameter to a bitmask that identifies the hardware counters to collect.
		/// You can specify up to 16 performance counters. Each bit relates directly to the zero-based hardware counter index for the
		/// hardware performance counters that you configured. Set to zero if you are not collecting hardware counter data. If you set a bit
		/// for a hardware counter that has not been configured, the counter value that is read for that counter is zero.
		/// </param>
		/// <param name="PerformanceDataHandle">
		/// An opaque handle that you use when calling the <c>ReadThreadProfilingData</c> and <c>DisableThreadProfiling</c> functions.
		/// </param>
		/// <returns>Returns ERROR_SUCCESS if the call is successful; otherwise, a system error code (see Winerror.h).</returns>
		// DWORD APIENTRY EnableThreadProfiling( _In_ HANDLE ThreadHandle, _In_ DWORD Flags, _In_ DWORD64 HardwareCounters, _Out_ HANDLE
		// PerformanceDataHandle); https://msdn.microsoft.com/en-us/library/windows/desktop/dd796393(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "dd796393")]
		public static extern Win32Error EnableThreadProfiling(IntPtr ThreadHandle, THREAD_PROFILING_FLAG Flags, ulong HardwareCounters, IntPtr PerformanceDataHandle);

		/// <summary>
		/// <para>Converts the calling thread into a user-mode scheduling (UMS) scheduler thread.</para>
		/// </summary>
		/// <param name="SchedulerStartupInfo">
		/// <para>
		/// A pointer to a UMS_SCHEDULER_STARTUP_INFO structure that specifies UMS attributes for the thread, including a completion list and
		/// a UmsSchedulerProc entry point function.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application's UMS scheduler creates one UMS scheduler thread for each processor that will be used to run UMS threads. The
		/// scheduler typically sets the affinity of the scheduler thread for a single processor, effectively reserving the processor for the
		/// use of that scheduler thread. For more information about thread affinity, see Multiple Processors.
		/// </para>
		/// <para>
		/// When a UMS scheduler thread is created, the system calls the UmsSchedulerProc entry point function specified with the
		/// <c>EnterUmsSchedulingMode</c> function call. The application's scheduler is responsible for finishing any application-specific
		/// initialization of the scheduler thread and selecting a UMS worker thread to run.
		/// </para>
		/// <para>
		/// The application's scheduler selects a UMS worker thread to run by calling ExecuteUmsThread with the worker thread's UMS thread
		/// context. The worker thread runs until it yields control by calling UmsThreadYield, blocks, or terminates. The scheduler thread is
		/// then available to run another worker thread.
		/// </para>
		/// <para>
		/// A scheduler thread should continue to run until all of its worker threads reach a natural stopping point: that is, all worker
		/// threads have yielded, blocked, or terminated.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-enterumsschedulingmode BOOL EnterUmsSchedulingMode(
		// PUMS_SCHEDULER_STARTUP_INFO SchedulerStartupInfo );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "792bd7fa-0ae9-4c38-a664-5fb3e3d0c52b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnterUmsSchedulingMode(ref UMS_SCHEDULER_STARTUP_INFO SchedulerStartupInfo);

		/// <summary>
		/// <para>Runs the specified UMS worker thread.</para>
		/// </summary>
		/// <param name="UmsThread">
		/// <para>A pointer to the UMS thread context of the worker thread to run.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it does not return a value.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible error codes
		/// include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_RETRY</term>
		/// <term>The specified UMS worker thread is temporarily locked by the system. The caller can retry the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>ExecuteUmsThread</c> function loads the state of the specified UMS worker thread over the state of the calling UMS
		/// scheduler thread so that the worker thread can run. The worker thread runs until it yields by calling the UmsThreadYield
		/// function, blocks, or terminates.
		/// </para>
		/// <para>
		/// When a worker thread yields or blocks, the system calls the scheduler thread's UmsSchedulerProc entry point function. When a
		/// previously blocked worker thread becomes unblocked, the system queues the worker thread to the completion list specified with the
		/// UpdateProcThreadAttribute function when the worker thread was created.
		/// </para>
		/// <para>
		/// The <c>ExecuteUmsThread</c> function does not return unless an error occurs. If the function returns ERROR_RETRY, the error is
		/// transitory and the operation can be retried.
		/// </para>
		/// <para>
		/// If the function returns an error other than ERROR_RETRY, the application's scheduler should check whether the thread is suspended
		/// or terminated by calling QueryUmsThreadInformation with <c>UmsThreadIsSuspended</c> or <c>UmsThreadIsTerminated</c>,
		/// respectively. Other possible errors include calling the function on a thread that is not a UMS scheduler thread, passing an
		/// invalid UMS worker thread context, or specifying a worker thread that is already executing on another scheduler thread.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-executeumsthread BOOL ExecuteUmsThread( PUMS_CONTEXT
		// UmsThread );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "e4265351-e8e9-4878-bd42-93258b4cd1a0")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ExecuteUmsThread(IntPtr UmsThread);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>
		/// Creates an enumeration of all the hard links to the specified file as a transacted operation. The function returns a handle to
		/// the enumeration that can be used on subsequent calls to the FindNextFileNameW function.
		/// </para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of the file.</para>
		/// <para>
		/// The file must reside on the local computer; otherwise, the function fails and the last error code is set to
		/// <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c> (6805).
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Reserved; specify zero (0).</para>
		/// </param>
		/// <param name="StringLength">
		/// <para>
		/// The size of the buffer pointed to by the LinkName parameter, in characters. If this call fails and the error is
		/// <c>ERROR_MORE_DATA</c> (234), the value that is returned by this parameter is the size that the buffer pointed to by LinkName
		/// must be to contain all the data.
		/// </para>
		/// </param>
		/// <param name="LinkName">
		/// <para>A pointer to a buffer to store the first link name found for lpFileName.</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is a search handle that can be used with the FindNextFileNameW function or closed with
		/// the FindClose function.
		/// </para>
		/// <para>
		/// If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c> (0xffffffff). To get extended error information, call the
		/// GetLastError function.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-findfirstfilenametransactedw HANDLE
		// FindFirstFileNameTransactedW( LPCWSTR lpFileName, DWORD dwFlags, LPDWORD StringLength, PWSTR LinkName, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("winbase.h", MSDNShortId = "79c7d32d-3cb7-4e27-9db1-f24282bf606a")]
		public static extern IntPtr FindFirstFileNameTransactedW(string lpFileName, uint dwFlags, ref uint StringLength, StringBuilder LinkName, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Searches a directory for a file or subdirectory with a name that matches a specific name as a transacted operation.</para>
		/// <para>This function is the transacted form of the FindFirstFileEx function.</para>
		/// <para>For the most basic version of this function, see FindFirstFile.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>
		/// The directory or path, and the file name. The file name can include wildcard characters, for example, an asterisk (*) or a
		/// question mark (?).
		/// </para>
		/// <para>
		/// This parameter should not be <c>NULL</c>, an invalid string (for example, an empty string or a string that is missing the
		/// terminating null character), or end in a trailing backslash ().
		/// </para>
		/// <para>
		/// If the string ends with a wildcard, period (.), or directory name, the user must have access to the root and all subdirectories
		/// on the path.
		/// </para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>The file must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="fInfoLevelId">
		/// <para>The information level of the returned data.</para>
		/// <para>This parameter is one of the FINDEX_INFO_LEVELS enumeration values.</para>
		/// </param>
		/// <param name="lpFindFileData">
		/// <para>A pointer to the WIN32_FIND_DATA structure that receives information about a found file or subdirectory.</para>
		/// </param>
		/// <param name="fSearchOp">
		/// <para>The type of filtering to perform that is different from wildcard matching.</para>
		/// <para>This parameter is one of the FINDEX_SEARCH_OPS enumeration values.</para>
		/// </param>
		/// <param name="lpSearchFilter">
		/// <para>A pointer to the search criteria if the specified fSearchOp needs structured search information.</para>
		/// <para>
		/// At this time, none of the supported fSearchOp values require extended search information. Therefore, this pointer must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwAdditionalFlags">
		/// <para>Specifies additional flags that control the search.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FIND_FIRST_EX_CASE_SENSITIVE 1</term>
		/// <term>Searches are case-sensitive.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is a search handle used in a subsequent call to FindNextFile or FindClose, and the
		/// lpFindFileData parameter contains information about the first file or directory found.
		/// </para>
		/// <para>
		/// If the function fails or fails to locate files from the search string in the lpFileName parameter, the return value is
		/// <c>INVALID_HANDLE_VALUE</c> and the contents of lpFindFileData are indeterminate. To get extended error information, call the
		/// GetLastError function.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>FindFirstFileTransacted</c> function opens a search handle and returns information about the first file that the file
		/// system finds with a name that matches the specified pattern. This may or may not be the first file or directory that appears in a
		/// directory-listing application (such as the dir command) when given the same file name string pattern. This is because
		/// <c>FindFirstFileTransacted</c> does no sorting of the search results. For additional information, see FindNextFile.
		/// </para>
		/// <para>The following list identifies some other search characteristics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The search is performed strictly on the name of the file, not on any attributes such as a date or a file type.</term>
		/// </item>
		/// <item>
		/// <term>The search includes the long and short file names.</term>
		/// </item>
		/// <item>
		/// <term>An attempt to open a search with a trailing backslash always fails.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Passing an invalid string, <c>NULL</c>, or empty string for the lpFileName parameter is not a valid use of this function. Results
		/// in this case are undefined.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> In rare cases, file information on NTFS file systems may not be current at the time you call this function. To be
		/// assured of getting the current file information, call the GetFileInformationByHandle function.
		/// </para>
		/// <para>
		/// If the underlying file system does not support the specified type of filtering, other than directory filtering,
		/// <c>FindFirstFileTransacted</c> fails with the error <c>ERROR_NOT_SUPPORTED</c>. The application must use FINDEX_SEARCH_OPS type
		/// <c>FileExSearchNameMatch</c> and perform its own filtering.
		/// </para>
		/// <para>
		/// After the search handle is established, use it in the FindNextFile function to search for other files that match the same pattern
		/// with the same filtering that is being performed. When the search handle is not needed, it should be closed by using the FindClose function.
		/// </para>
		/// <para>
		/// As stated previously, you cannot use a trailing backslash () in the lpFileName input string for <c>FindFirstFileTransacted</c>,
		/// therefore it may not be obvious how to search root directories. If you want to see files or get the attributes of a root
		/// directory, the following options would apply:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>To examine files in a root directory, you can use "C:\*" and step through the directory by using FindNextFile.</term>
		/// </item>
		/// <item>
		/// <term>To get the attributes of a root directory, use the GetFileAttributes function.</term>
		/// </item>
		/// </list>
		/// <para><c>Note</c> Prepending the string "\\?\" does not allow access to the root directory.</para>
		/// <para>
		/// On network shares, you can use an lpFileName in the form of the following: "\\server\service\*". However, you cannot use an
		/// lpFileName that points to the share itself; for example, "\\server\service" is not valid.
		/// </para>
		/// <para>
		/// To examine a directory that is not a root directory, use the path to that directory, without a trailing backslash. For example,
		/// an argument of "C:\Windows" returns information about the directory "C:\Windows", not about a directory or file in "C:\Windows".
		/// To examine the files and directories in "C:\Windows", use an lpFileName of "C:\Windows*".
		/// </para>
		/// <para>
		/// Be aware that some other thread or process could create or delete a file with this name between the time you query for the result
		/// and the time you act on the information. If this is a potential concern for your application, one possible solution is to use the
		/// CreateFile function with <c>CREATE_NEW</c> (which fails if the file exists) or <c>OPEN_EXISTING</c> (which fails if the file does
		/// not exist).
		/// </para>
		/// <para>
		/// If you are writing a 32-bit application to list all the files in a directory and the application may be run on a 64-bit computer,
		/// you should call Wow64DisableWow64FsRedirection before calling <c>FindFirstFileTransacted</c> and call
		/// Wow64RevertWow64FsRedirection after the last call to FindNextFile. For more information, see File System Redirector.
		/// </para>
		/// <para>
		/// If the path points to a symbolic link, the WIN32_FIND_DATA buffer contains information about the symbolic link, not the target.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-findfirstfiletransacteda HANDLE FindFirstFileTransactedA(
		// LPCSTR lpFileName, FINDEX_INFO_LEVELS fInfoLevelId, LPVOID lpFindFileData, FINDEX_SEARCH_OPS fSearchOp, LPVOID lpSearchFilter,
		// DWORD dwAdditionalFlags, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "d94bf32b-f14b-44b4-824b-ed453d0424ef")]
		public static extern IntPtr FindFirstFileTransacted(string lpFileName, FINDEX_INFO_LEVELS fInfoLevelId, out WIN32_FIND_DATA lpFindFileData, FINDEX_SEARCH_OPS fSearchOp, IntPtr lpSearchFilter, FIND_FIRST dwAdditionalFlags, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Enumerates the first stream in the specified file or directory as a transacted operation.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The fully qualified file name.</para>
		/// <para>
		/// The file must reside on the local computer; otherwise, the function fails and the last error code is set to
		/// <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c> (6805).
		/// </para>
		/// </param>
		/// <param name="InfoLevel">
		/// <para>
		/// The information level of the returned data. This parameter is one of the values in the STREAM_INFO_LEVELS enumeration type.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FindStreamInfoStandard 0</term>
		/// <term>The data is returned in a WIN32_FIND_STREAM_DATA structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpFindStreamData">
		/// <para>A pointer to a buffer that receives the file data. The format of this data depends on the value of the InfoLevel parameter.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Reserved for future use. This parameter must be zero.</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a search handle that can be used in subsequent calls to the FindNextStreamWfunction.</para>
		/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// All files contain a default data stream. On NTFS, files can also contain one or more named data streams. On FAT file systems,
		/// files cannot have more that the default data stream, and therefore, this function will not return valid results when used on FAT
		/// filesystem files. This function works on all file systems that supports hard links; otherwise, the function returns
		/// <c>ERROR_STATUS_NOT_IMPLEMENTED</c> (6805).
		/// </para>
		/// <para>
		/// The <c>FindFirstStreamTransactedW</c> function opens a search handle and returns information about the first stream in the
		/// specified file or directory. For files, this is always the default data stream, ::$DATA. After the search handle has been
		/// established, use it in the FindNextStreamW function to search for other streams in the specified file or directory. When the
		/// search handle is no longer needed, it should be closed using the FindClosefunction.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-findfirststreamtransactedw HANDLE
		// FindFirstStreamTransactedW( LPCWSTR lpFileName, STREAM_INFO_LEVELS InfoLevel, LPVOID lpFindStreamData, DWORD dwFlags, HANDLE
		// hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("winbase.h", MSDNShortId = "76c64aa9-0501-457d-b774-c209fbac4ccc")]
		public static extern IntPtr FindFirstStreamTransactedW(string lpFileName, STREAM_INFO_LEVELS InfoLevel, out WIN32_FIND_STREAM_DATA lpFindStreamData, uint dwFlags, IntPtr hTransaction);

		/// <summary>
		/// <para>Returns the number of active processors in a processor group or in the system.</para>
		/// </summary>
		/// <param name="GroupNumber">
		/// <para>
		/// The processor group number. If this parameter is ALL_PROCESSOR_GROUPS, the function returns the number of active processors in
		/// the system.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the number of active processors in the specified group.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, use GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To compile an application that uses this function, set _WIN32_WINNT &gt;= 0x0601. For more information, see Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getactiveprocessorcount DWORD GetActiveProcessorCount(
		// WORD GroupNumber );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "f4ebb0a7-1c05-4478-85e3-80e6327ef8a4")]
		public static extern uint GetActiveProcessorCount(ushort GroupNumber);

		/// <summary>
		/// <para>Returns the number of active processor groups in the system.</para>
		/// </summary>
		/// <returns>
		/// <para>If the function succeeds, the return value is the number of active processor groups in the system.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To compile an application that uses this function, set _WIN32_WINNT &gt;= 0x0601. For more information, see Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getactiveprocessorgroupcount WORD
		// GetActiveProcessorGroupCount( );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "566c6abe-9269-4e0e-9c98-e4607c808452")]
		public static extern ushort GetActiveProcessorGroupCount();

		/// <summary>
		/// <para>Determines whether a file is an executable (.exe) file, and if so, which subsystem runs the executable file.</para>
		/// </summary>
		/// <param name="lpApplicationName">
		/// <para>The full path of the file whose executable type is to be determined.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="lpBinaryType">
		/// <para>
		/// A pointer to a variable to receive information about the executable type of the file specified by lpApplicationName. The
		/// following constants are defined.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SCS_32BIT_BINARY 0</term>
		/// <term>A 32-bit Windows-based application</term>
		/// </item>
		/// <item>
		/// <term>SCS_64BIT_BINARY 6</term>
		/// <term>A 64-bit Windows-based application.</term>
		/// </item>
		/// <item>
		/// <term>SCS_DOS_BINARY 1</term>
		/// <term>An MS-DOS – based application</term>
		/// </item>
		/// <item>
		/// <term>SCS_OS216_BINARY 5</term>
		/// <term>A 16-bit OS/2-based application</term>
		/// </item>
		/// <item>
		/// <term>SCS_PIF_BINARY 3</term>
		/// <term>A PIF file that executes an MS-DOS – based application</term>
		/// </item>
		/// <item>
		/// <term>SCS_POSIX_BINARY 4</term>
		/// <term>A POSIX – based application</term>
		/// </item>
		/// <item>
		/// <term>SCS_WOW_BINARY 2</term>
		/// <term>A 16-bit Windows-based application</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>
		/// If the file is executable, the return value is nonzero. The function sets the variable pointed to by lpBinaryType to indicate the
		/// file's executable type.
		/// </para>
		/// <para>
		/// If the file is not executable, or if the function fails, the return value is zero. To get extended error information, call
		/// GetLastError. If the file is a DLL, the last error code is <c>ERROR_BAD_EXE_FORMAT</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// As an alternative, you can obtain the same information by calling the SHGetFileInfo function, passing the <c>SHGFI_EXETYPE</c>
		/// flag in the uFlags parameter.
		/// </para>
		/// <para>Symbolic link behavior—If the path points to a symbolic link, the target file is used.</para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getbinarytypea BOOL GetBinaryTypeA( LPCSTR
		// lpApplicationName, LPDWORD lpBinaryType );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "ec937372-ee99-4505-a5dd-7c111405cbc6")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetBinaryType(string lpApplicationName, out SCS lpBinaryType);

		/// <summary>
		/// <para>Indicates whether the 64-bit Common Language Runtime (CLR) is installed.</para>
		/// </summary>
		/// <returns>
		/// This method returns 0 if 32-bit Common Language Runtime(CLR) is installed and 0x00000001 if the 64-bit Common Language
		/// Runtime(CLR) is installed.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/cossdk/getcompluspackageinstallstatus ULONG WINAPI GetComPlusPackageInstallStatus(void);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("", MSDNShortId = "c68af270-6a40-4026-9725-5fe657123fd5")]
		public static extern uint GetComPlusPackageInstallStatus();

		/// <summary>
		/// <para>Returns the user-mode scheduling (UMS) thread context of the calling UMS thread.</para>
		/// </summary>
		/// <returns>
		/// <para>The function returns a pointer to the UMS thread context of the calling thread.</para>
		/// <para>If calling thread is not a UMS thread, the function returns NULL. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetCurrentUmsThread</c> function can be called for a UMS scheduler thread or UMS worker thread.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getcurrentumsthread PUMS_CONTEXT GetCurrentUmsThread( );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "f2e20816-919a-443d-96d3-94e98afc28f2")]
		public static extern IntPtr GetCurrentUmsThread();

		/// <summary>
		/// Gets a range, expressed in years, for which a <c>DYNAMIC_TIME_ZONE_INFORMATION</c> has valid entries. Use the returned value to
		/// identify the specific years to request when calling <c>GetTimeZoneInformationForYear</c> to retrieve time zone information for a
		/// time zone that experiences annual boundary changes due to daylight saving time adjustments.
		/// </summary>
		/// <param name="lpTimeZoneInformation">Specifies settings for a time zone and dynamic daylight saving time.</param>
		/// <param name="FirstYear">The year that marks the beginning of the range to pass to <c>GetTimeZoneInformationForYear</c>.</param>
		/// <param name="LastYear">The year that marks the end of the range to pass to <c>GetTimeZoneInformationForYear</c>.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>The system cannot find the effective years.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term>Any other value</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		// DWORD WINAPI GetDynamicTimeZoneInformationEffectiveYears( _In_ const PDYNAMIC_TIME_ZONE_INFORMATION lpTimeZoneInformation, _Out_
		// LPDWORD FirstYear, _Out_ LPDWORD LastYear); https://msdn.microsoft.com/en-us/library/windows/desktop/hh706894(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "hh706894")]
		public static extern Win32Error GetDynamicTimeZoneInformationEffectiveYears(ref DYNAMIC_TIME_ZONE_INFORMATION lpTimeZoneInformation, out uint FirstYear, out uint LastYear);

		/// <summary>
		/// <para>Gets a mask of enabled XState features on x86 or x64 processors.</para>
		/// <para>
		/// The definition of XState feature bits are processor vendor specific. Please refer to the relevant processor reference manuals for
		/// additional information on a particular feature.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>This function returns a bitmask in which each bit represents an XState feature that is enabled on the system.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application should call this function to determine what features are present and enabled on the system before using an XState
		/// processor feature or attempting to manipulate XState contexts. Bits 0 and 1 refer to the X87 FPU and the presence of SSE
		/// registers, respectively. The meanings of specific feature bits beyond 0 and 1 are defined in the Programmer Reference Manuals
		/// released by the processor vendors.
		/// </para>
		/// <para>
		/// <c>Windows 7 with SP1 and Windows Server 2008 R2 with SP1:</c> The AVX API is first implemented on Windows 7 with SP1 and Windows
		/// Server 2008 R2 with SP1 . Since there is no SDK for SP1, that means there are no available headers and library files to work
		/// with. In this situation, a caller must declare the needed functions from this documentation and get pointers to them using
		/// GetModuleHandle on "Kernel32.dll", followed by calls to GetProcAddress. See Working with XState Context for details.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getenabledxstatefeatures DWORD64 GetEnabledXStateFeatures( );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "E7DE090F-F83E-440D-B2A3-BCF160889F2E")]
		public static extern ulong GetEnabledXStateFeatures();

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Retrieves file system attributes for a specified file or directory as a transacted operation.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of the file or directory.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>
		/// The file or directory must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.
		/// </para>
		/// </param>
		/// <param name="fInfoLevelId">
		/// <para>The level of attribute information to retrieve.</para>
		/// <para>This parameter can be the following value from the GET_FILEEX_INFO_LEVELS enumeration.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GetFileExInfoStandard</term>
		/// <term>The lpFileInformation parameter is a WIN32_FILE_ATTRIBUTE_DATA structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpFileInformation">
		/// <para>A pointer to a buffer that receives the attribute information.</para>
		/// <para>
		/// The type of attribute information that is stored into this buffer is determined by the value of fInfoLevelId. If the fInfoLevelId
		/// parameter is <c>GetFileExInfoStandard</c> then this parameter points to a WIN32_FILE_ATTRIBUTE_DATA structure
		/// </para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero (0). To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When <c>GetFileAttributesTransacted</c> is called on a directory that is a mounted folder, it returns the attributes of the
		/// directory, not those of the root directory in the volume that the mounted folder associates with the directory. To obtain the
		/// file attributes of the associated volume, call GetVolumeNameForVolumeMountPoint to obtain the name of the associated volume. Then
		/// use the resulting name in a call to <c>GetFileAttributesTransacted</c>. The results are the attributes of the root directory on
		/// the associated volume.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// <para><c>Symbolic links:</c> If the path points to a symbolic link, the function returns attributes for the symbolic link.</para>
		/// <para>Transacted Operations</para>
		/// <para>
		/// If a file is open for modification in a transaction, no other thread can open the file for modification until the transaction is
		/// committed. Conversely, if a file is open for modification outside of a transaction, no transacted thread can open the file for
		/// modification until the non-transacted handle is closed. If a non-transacted thread has a handle opened to modify a file, a call
		/// to <c>GetFileAttributesTransacted</c> for that file will fail with an <c>ERROR_TRANSACTIONAL_CONFLICT</c> error.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getfileattributestransacteda BOOL
		// GetFileAttributesTransactedA( LPCSTR lpFileName, GET_FILEEX_INFO_LEVELS fInfoLevelId, LPVOID lpFileInformation, HANDLE
		// hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "dd1435da-93e5-440a-913a-9e40e39b4a01")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetFileAttributesTransacted(string lpFileName, GET_FILEEX_INFO_LEVELS fInfoLevelId, ref WIN32_FILE_ATTRIBUTE_DATA lpFileInformation, IntPtr hTransaction);

		/// <summary>
		/// <para>Retrieves the bandwidth reservation properties of the volume on which the specified file resides.</para>
		/// </summary>
		/// <param name="hFile">
		/// <para>A handle to the file.</para>
		/// </param>
		/// <param name="lpPeriodMilliseconds">
		/// <para>
		/// A pointer to a variable that receives the period of the reservation, in milliseconds. The period is the time from which the I/O
		/// is issued to the kernel until the time the I/O should be completed. If no bandwidth has been reserved for this handle, then the
		/// value returned is the minimum reservation period supported for this volume.
		/// </para>
		/// </param>
		/// <param name="lpBytesPerPeriod">
		/// <para>
		/// A pointer to a variable that receives the maximum number of bytes per period that can be reserved on the volume. If no bandwidth
		/// has been reserved for this handle, then the value returned is the maximum number of bytes per period supported for the volume.
		/// </para>
		/// </param>
		/// <param name="pDiscardable">
		/// <para>
		/// <c>TRUE</c> if I/O should be completed with an error if a driver is unable to satisfy an I/O operation before the period expires.
		/// <c>FALSE</c> if the underlying subsystem does not support failing in this manner.
		/// </para>
		/// </param>
		/// <param name="lpTransferSize">
		/// <para>
		/// The minimum size of any individual I/O request that may be issued by the application. All I/O requests should be multiples of
		/// TransferSize. If no bandwidth has been reserved for this handle, then the value returned is the minimum transfer size supported
		/// for this volume.
		/// </para>
		/// </param>
		/// <param name="lpNumOutstandingRequests">
		/// <para>The number of TransferSize chunks allowed to be outstanding with the operating system.</para>
		/// </param>
		/// <returns>
		/// <para>Returns nonzero if successful or zero otherwise.</para>
		/// <para>To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getfilebandwidthreservation BOOL
		// GetFileBandwidthReservation( HANDLE hFile, LPDWORD lpPeriodMilliseconds, LPDWORD lpBytesPerPeriod, LPBOOL pDiscardable, LPDWORD
		// lpTransferSize, LPDWORD lpNumOutstandingRequests );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "3caf38f6-e853-4057-a192-71cda4443dbd")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetFileBandwidthReservation(SafeFileHandle hFile, out uint lpPeriodMilliseconds, out uint lpBytesPerPeriod, [MarshalAs(UnmanagedType.Bool)] out bool pDiscardable, out uint lpTransferSize, out uint lpNumOutstandingRequests);

		/// <summary>
		/// <para>Retrieves file information for the specified file.</para>
		/// <para>For a more basic version of this function for desktop apps, see GetFileInformationByHandle.</para>
		/// <para>To set file information using a file handle, see SetFileInformationByHandle.</para>
		/// </summary>
		/// <param name="hFile">
		/// <para>A handle to the file that contains the information to be retrieved.</para>
		/// <para>This handle should not be a pipe handle.</para>
		/// </param>
		/// <param name="FileInformationClass">
		/// <para>A FILE_INFO_BY_HANDLE_CLASS enumeration value that specifies the type of information to be retrieved.</para>
		/// <para>For a table of valid values, see the Remarks section.</para>
		/// </param>
		/// <param name="lpFileInformation">
		/// <para>
		/// A pointer to the buffer that receives the requested file information. The structure that is returned corresponds to the class
		/// that is specified by FileInformationClass. For a table of valid structure types, see the Remarks section.
		/// </para>
		/// </param>
		/// <param name="dwBufferSize">
		/// <para>The size of the lpFileInformation buffer, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero and file information data is contained in the buffer pointed to by the
		/// lpFileInformation parameter.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If FileInformationClass is <c>FileStreamInfo</c> and the calls succeed but no streams are returned, the error that is returned by
		/// GetLastError is <c>ERROR_HANDLE_EOF</c>.
		/// </para>
		/// <para>
		/// Certain file information classes behave slightly differently on different operating system releases. These classes are supported
		/// by the underlying drivers, and any information they return is subject to change between operating system releases.
		/// </para>
		/// <para>
		/// The following table shows the valid file information class types and their corresponding data structure types for use with this function.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>FileInformationClass value</term>
		/// <term>lpFileInformation type</term>
		/// </listheader>
		/// <item>
		/// <term>FileBasicInfo (0)</term>
		/// <term>FILE_BASIC_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileStandardInfo (1)</term>
		/// <term>FILE_STANDARD_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileNameInfo (2)</term>
		/// <term>FILE_NAME_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileStreamInfo (7)</term>
		/// <term>FILE_STREAM_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileCompressionInfo (8)</term>
		/// <term>FILE_COMPRESSION_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileAttributeTagInfo (9)</term>
		/// <term>FILE_ATTRIBUTE_TAG_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileIdBothDirectoryInfo (0xa)</term>
		/// <term>FILE_ID_BOTH_DIR_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileIdBothDirectoryRestartInfo (0xb)</term>
		/// <term>FILE_ID_BOTH_DIR_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileRemoteProtocolInfo (0xd)</term>
		/// <term>FILE_REMOTE_PROTOCOL_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileFullDirectoryInfo (0xe)</term>
		/// <term>FILE_FULL_DIR_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileFullDirectoryRestartInfo (0xf)</term>
		/// <term>FILE_FULL_DIR_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileStorageInfo (0x10)</term>
		/// <term>FILE_STORAGE_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileAlignmentInfo (0x11)</term>
		/// <term>FILE_ALIGNMENT_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileIdInfo (0x12)</term>
		/// <term>FILE_ID_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileIdExtdDirectoryInfo (0x13)</term>
		/// <term>FILE_ID_EXTD_DIR_INFO</term>
		/// </item>
		/// <item>
		/// <term>FileIdExtdDirectoryRestartInfo (0x14)</term>
		/// <term>FILE_ID_EXTD_DIR_INFO</term>
		/// </item>
		/// </list>
		/// <para>Transacted Operations</para>
		/// <para>
		/// If there is a transaction bound to the thread at the time of the call, then the function returns the compressed file size of the
		/// isolated file view. For more information, see About Transactional NTFS.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getfileinformationbyhandleex BOOL
		// GetFileInformationByHandleEx( HANDLE hFile, FILE_INFO_BY_HANDLE_CLASS FileInformationClass, LPVOID lpFileInformation, DWORD
		// dwBufferSize );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "e261ea45-d084-490e-94b4-129bd76f6a04")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetFileInformationByHandleEx(SafeFileHandle hFile, FILE_INFO_BY_HANDLE_CLASS FileInformationClass, IntPtr lpFileInformation, uint dwBufferSize);

		/// <summary>
		/// <para>Retrieves the value of the specified firmware environment variable and its attributes.</para>
		/// </summary>
		/// <param name="lpName">
		/// <para>The name of the firmware environment variable. The pointer must not be <c>NULL</c>.</para>
		/// </param>
		/// <param name="lpGuid">
		/// <para>
		/// The GUID that represents the namespace of the firmware environment variable. The GUID must be a string in the format
		/// "{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}" where 'x' represents a hexadecimal value. The pointer must not be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pBuffer">
		/// <para>TBD</para>
		/// </param>
		/// <param name="nSize">
		/// <para>The size of the pValue buffer, in bytes.</para>
		/// </param>
		/// <param name="pdwAttribubutes">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the number of bytes stored in the pValue buffer.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible error codes
		/// include ERROR_INVALID_FUNCTION.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Starting with Windows 10, version 1803, Universal Windows apps can read and write UEFI firmware variables. See Access UEFI
		/// firmware variables from a Universal Windows App for details.
		/// </para>
		/// <para>
		/// To read a UEFI firmware environment variable, the user account that the app is running under must have the
		/// SE_SYSTEM_ENVIRONMENT_NAME privilege. A Universal Windows app must be run from an administrator account and follow the
		/// requirements outlined in Access UEFI firmware variables from a Universal Windows App .
		/// </para>
		/// <para>
		/// Starting with Windows 10, version 1803, reading Unified Extensible Firmware Interface (UEFI) variables is also supported from
		/// User-Mode Driver Framework (UMDF) drivers. Writing UEFI variables from UMDF drivers is not supported.
		/// </para>
		/// <para>
		/// The exact set of firmware environment variables is determined by the boot firmware. The location of these environment variables
		/// is also specified by the firmware. For example, on a UEFI-based system, NVRAM contains firmware environment variables that
		/// specify system boot settings. For information about specific variables used, see the UEFI specification. For more information
		/// about UEFI and Windows, see UEFI and Windows.
		/// </para>
		/// <para>
		/// Firmware variables are not supported on a legacy BIOS-based system. The <c>GetFirmwareEnvironmentVariableEx</c> function will
		/// always fail on a legacy BIOS-based system, or if Windows was installed using legacy BIOS on a system that supports both legacy
		/// BIOS and UEFI. To identify these conditions, call the function with a dummy firmware environment name such as an empty string
		/// ("") for the lpName parameter and a dummy GUID such as "{00000000-0000-0000-0000-000000000000}" for the lpGuid parameter. On a
		/// legacy BIOS-based system, or on a system that supports both legacy BIOS and UEFI where Windows was installed using legacy BIOS,
		/// the function will fail with ERROR_INVALID_FUNCTION. On a UEFI-based system, the function will fail with an error specific to the
		/// firmware, such as ERROR_NOACCESS, to indicate that the dummy GUID namespace does not exist.
		/// </para>
		/// <para>
		/// If you are creating a backup application, you can use this function to save all the boot settings for the system so they can be
		/// restored using the SetFirmwareEnvironmentVariable function if needed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getfirmwareenvironmentvariableexa DWORD
		// GetFirmwareEnvironmentVariableExA( LPCSTR lpName, LPCSTR lpGuid, PVOID pBuffer, DWORD nSize, PDWORD pdwAttribubutes );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "B093BA68-C68B-4ED6-9902-058650A191FD")]
		public static extern Win32Error GetFirmwareEnvironmentVariableEx(string lpName, string lpGuid, IntPtr pBuffer, uint nSize, ref uint pdwAttribubutes);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Retrieves the full path and file name of the specified file as a transacted operation.</para>
		/// <para>To perform this operation without transactions, use the GetFullPathName function.</para>
		/// <para>For more information about file and path names, see File Names, Paths, and Namespaces.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of the file.</para>
		/// <para>This string can use short (the 8.3 form) or long file names. This string can be a share or volume name.</para>
		/// <para>The file must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="nBufferLength">
		/// <para>The size of the buffer to receive the null-terminated string for the drive and path, in <c>TCHARs</c>.</para>
		/// </param>
		/// <param name="lpBuffer">
		/// <para>A pointer to a buffer that receives the null-terminated string for the drive and path.</para>
		/// </param>
		/// <param name="lpFilePart">
		/// <para>
		/// A pointer to a buffer that receives the address (in lpBuffer) of the final file name component in the path. Specify <c>NULL</c>
		/// if you do not need to receive this information.
		/// </para>
		/// <para>If lpBuffer points to a directory and not a file, lpFilePart receives 0 (zero).</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the length, in <c>TCHARs</c>, of the string copied to lpBuffer, not including the
		/// terminating null character.
		/// </para>
		/// <para>
		/// If the lpBuffer buffer is too small to contain the path, the return value is the size, in <c>TCHARs</c>, of the buffer that is
		/// required to hold the path and the terminating null character.
		/// </para>
		/// <para>If the function fails for any other reason, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>GetFullPathNameTransacted</c> merges the name of the current drive and directory with a specified file name to determine the
		/// full path and file name of a specified file. It also calculates the address of the file name portion of the full path and file
		/// name. This function does not verify that the resulting path and file name are valid, or that they see an existing file on the
		/// associated volume.
		/// </para>
		/// <para>
		/// Share and volume names are valid input for lpFileName. For example, the following list identities the returned path and file
		/// names if test-2 is a remote computer and U: is a network mapped drive:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If you specify "\\test-2\q$\lh" the path returned is "\\test-2\q$\lh"</term>
		/// </item>
		/// <item>
		/// <term>If you specify "\\?\UNC\test-2\q$\lh" the path returned is "\\?\UNC\test-2\q$\lh"</term>
		/// </item>
		/// <item>
		/// <term>If you specify "U:" the path returned is "U:\"</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>GetFullPathNameTransacted</c> does not convert the specified file name, lpFileName. If the specified file name exists, you can
		/// use GetLongPathNameTransacted, GetLongPathName, or GetShortPathName to convert to long or short path names, respectively.
		/// </para>
		/// <para>
		/// If the return value is greater than the value specified in nBufferLength, you can call the function again with a buffer that is
		/// large enough to hold the path. For an example of this case as well as using zero length buffer for dynamic allocation, see the
		/// Example Code section.
		/// </para>
		/// <para>
		/// <c>Note</c> Although the return value in this case is a length that includes the terminating null character, the return value on
		/// success does not include the terminating null character in the count.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getfullpathnametransacteda DWORD
		// GetFullPathNameTransactedA( LPCSTR lpFileName, DWORD nBufferLength, LPSTR lpBuffer, LPSTR *lpFilePart, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "63cbcec6-e9f0-4db3-bf2f-03a987000af1")]
		public static extern uint GetFullPathNameTransacted(string lpFileName, uint nBufferLength, StringBuilder lpBuffer, ref IntPtr lpFilePart, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Converts the specified path to its long form as a transacted operation.</para>
		/// <para>To perform this operation without a transaction, use the GetLongPathName function.</para>
		/// <para>For more information about file and path names, see Naming Files, Paths, and Namespaces.</para>
		/// </summary>
		/// <param name="lpszShortPath">
		/// <para>The path to be converted.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> (260) characters. To extend this limit to 32,767
		/// wide characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming Files,
		/// Paths, and Namespaces.
		/// </para>
		/// <para>The path must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="lpszLongPath">
		/// <para>A pointer to the buffer to receive the long path.</para>
		/// <para>You can use the same buffer you used for the lpszShortPath parameter.</para>
		/// </param>
		/// <param name="cchBuffer">
		/// <para>The size of the buffer lpszLongPath points to, in <c>TCHAR</c> s.</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the length, in <c>TCHAR</c> s, of the string copied to lpszLongPath, not including
		/// the terminating null character.
		/// </para>
		/// <para>
		/// If the lpBuffer buffer is too small to contain the path, the return value is the size, in <c>TCHAR</c> s, of the buffer that is
		/// required to hold the path and the terminating null character.
		/// </para>
		/// <para>
		/// If the function fails for any other reason, such as if the file does not exist, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>On many file systems, a short file name contains a tilde () character.</para>
		/// <para>
		/// If a long path is not found, this function returns the name specified in the lpszShortPath parameter in the lpszLongPath parameter.
		/// </para>
		/// <para>
		/// If the return value is greater than the value specified in cchBuffer, you can call the function again with a buffer that is large
		/// enough to hold the path. For an example of this case, see the Example Code section for GetFullPathName.
		/// </para>
		/// <para>
		/// <c>Note</c> Although the return value in this case is a length that includes the terminating null character, the return value on
		/// success does not include the terminating null character in the count.
		/// </para>
		/// <para>
		/// It is possible to have access to a file or directory but not have access to some of the parent directories of that file or
		/// directory. As a result, <c>GetLongPathNameTransacted</c> may fail when it is unable to query the parent directory of a path
		/// component to determine the long name for that component. This check can be skipped for directory components that have file
		/// extensions longer than 3 characters, or total lengths longer than 12 characters. For more information, see the Short vs. Long
		/// Names section of Naming Files, Paths, and Namespaces.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getlongpathnametransacteda DWORD
		// GetLongPathNameTransactedA( LPCSTR lpszShortPath, LPSTR lpszLongPath, DWORD cchBuffer, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "8523cde9-f0dd-4832-8d9d-9e68bac89344")]
		public static extern uint GetLongPathNameTransacted(string lpszShortPath, StringBuilder lpszLongPath, uint cchBuffer, IntPtr hTransaction);

		/// <summary>
		/// <para>Returns the maximum number of logical processors that a processor group or the system can have.</para>
		/// </summary>
		/// <param name="GroupNumber">
		/// <para>
		/// The processor group number. If this parameter is ALL_PROCESSOR_GROUPS, the function returns the maximum number of processors that
		/// the system can have.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the maximum number of processors that the specified group can have.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, use GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To compile an application that uses this function, set _WIN32_WINNT &gt;= 0x0601. For more information, see Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getmaximumprocessorcount DWORD GetMaximumProcessorCount(
		// WORD GroupNumber );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "71ce4fb4-ef63-4750-a842-bbfb1a5b0543")]
		public static extern uint GetMaximumProcessorCount(ushort GroupNumber);

		/// <summary>
		/// <para>Returns the maximum number of processor groups that the system can have.</para>
		/// </summary>
		/// <returns>
		/// <para>If the function succeeds, the return value is the maximum number of processor groups that the system can have.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To compile an application that uses this function, set _WIN32_WINNT &gt;= 0x0601. For more information, see Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getmaximumprocessorgroupcount WORD
		// GetMaximumProcessorGroupCount( );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "7762ec89-5892-4af3-9032-bf084aef9075")]
		public static extern ushort GetMaximumProcessorGroupCount();

		/// <summary>
		/// <para>Retrieves the client process identifier for the specified named pipe.</para>
		/// </summary>
		/// <param name="Pipe">
		/// <para>A handle to an instance of a named pipe. This handle must be created by the CreateNamedPipe function.</para>
		/// </param>
		/// <param name="ClientProcessId">
		/// <para>The process identifier.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Windows 10, version 1709:</c> Pipes are only supported within an app-container; ie, from one UWP process to another UWP
		/// process that's part of the same app. Also, named pipes must use the syntax "\.\pipe\LOCAL" for the pipe name.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getnamedpipeclientprocessid BOOL
		// GetNamedPipeClientProcessId( HANDLE Pipe, PULONG ClientProcessId );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "7001eb89-3d91-44e3-b245-b19e8ab5f9fe")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNamedPipeClientProcessId(IntPtr Pipe, out uint ClientProcessId);

		/// <summary>
		/// <para>Retrieves the client session identifier for the specified named pipe.</para>
		/// </summary>
		/// <param name="Pipe">
		/// <para>A handle to an instance of a named pipe. This handle must be created by the CreateNamedPipe function.</para>
		/// </param>
		/// <param name="ClientSessionId">
		/// <para>The session identifier.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Windows 10, version 1709:</c> Pipes are only supported within an app-container; ie, from one UWP process to another UWP
		/// process that's part of the same app. Also, named pipes must use the syntax "\.\pipe\LOCAL" for the pipe name.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getnamedpipeclientsessionid BOOL
		// GetNamedPipeClientSessionId( HANDLE Pipe, PULONG ClientSessionId );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "b3ea0b7f-fead-4369-b87a-2f522a2a1984")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNamedPipeClientSessionId(IntPtr Pipe, out uint ClientSessionId);

		/// <summary>
		/// <para>Retrieves the server process identifier for the specified named pipe.</para>
		/// </summary>
		/// <param name="Pipe">
		/// <para>A handle to an instance of a named pipe. This handle must be created by the CreateNamedPipe function.</para>
		/// </param>
		/// <param name="ServerProcessId">
		/// <para>The process identifier.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Windows 10, version 1709:</c> Pipes are only supported within an app-container; ie, from one UWP process to another UWP
		/// process that's part of the same app. Also, named pipes must use the syntax "\.\pipe\LOCAL" for the pipe name.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getnamedpipeserverprocessid BOOL
		// GetNamedPipeServerProcessId( HANDLE Pipe, PULONG ServerProcessId );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "1ee33a66-a71c-4c34-b907-aab7860294c4")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNamedPipeServerProcessId(IntPtr Pipe, out uint ServerProcessId);

		/// <summary>
		/// <para>Retrieves the server session identifier for the specified named pipe.</para>
		/// </summary>
		/// <param name="Pipe">
		/// <para>A handle to an instance of a named pipe. This handle must be created by the CreateNamedPipe function.</para>
		/// </param>
		/// <param name="ServerSessionId">
		/// <para>The session identifier.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Windows 10, version 1709:</c> Pipes are only supported within an app-container; ie, from one UWP process to another UWP
		/// process that's part of the same app. Also, named pipes must use the syntax "\.\pipe\LOCAL" for the pipe name.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getnamedpipeserversessionid BOOL
		// GetNamedPipeServerSessionId( HANDLE Pipe, PULONG ServerSessionId );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "cd628d6d-aa13-4762-893b-42f6cf7a2ba6")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNamedPipeServerSessionId(IntPtr Pipe, out uint ServerSessionId);

		/// <summary>
		/// <para>Retrieves the amount of memory that is available in a node specified as a <c>USHORT</c> value.</para>
		/// </summary>
		/// <param name="Node">
		/// <para>The number of the node.</para>
		/// </param>
		/// <param name="AvailableBytes">
		/// <para>The amount of available memory for the node, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetNumaAvailableMemoryNodeEx</c> function returns the amount of memory consumed by free and zeroed pages on the specified
		/// node. On systems with more than one node, this memory does not include standby pages. Therefore, the sum of the available memory
		/// values for all nodes in the system is equal to the value of the Free &amp; Zero Page List Bytes memory performance counter. On
		/// systems with only one node, the value returned by GetNumaAvailableMemoryNode includes standby pages and is equal to the value of
		/// the Available Bytes memory performance counter. For more information about performance counters, see Memory Performance Information.
		/// </para>
		/// <para>
		/// The only difference between the <c>GetNumaAvailableMemoryNodeEx</c> function and the GetNumaAvailableMemoryNode function is the
		/// data type of the Node parameter.
		/// </para>
		/// <para>
		/// To compile an application that uses this function, set _WIN32_WINNT &gt;= 0x0601. For more information, see Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getnumaavailablememorynodeex BOOL
		// GetNumaAvailableMemoryNodeEx( USHORT Node, PULONGLONG AvailableBytes );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "59382114-f3da-45e0-843e-51c0fd52a164")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNumaAvailableMemoryNodeEx(ushort Node, out ulong AvailableBytes);

		/// <summary>
		/// <para>Retrieves the NUMA node associated with the file or I/O device represented by the specified file handle.</para>
		/// </summary>
		/// <param name="hFile">
		/// <para>
		/// A handle to a file or I/O device. Examples of I/O devices include files, file streams, volumes, physical disks, and sockets. For
		/// more information, see the CreateFile function.
		/// </para>
		/// </param>
		/// <param name="NodeNumber">
		/// <para>A pointer to a variable to receive the number of the NUMA node associated with the specified file handle.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, use GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the specified handle does not have a node associated with it, the function returns FALSE. The value of the NodeNumber
		/// parameter is undetermined and should not be used.
		/// </para>
		/// <para>
		/// To compile an application that uses this function, set _WIN32_WINNT &gt;= 0x0601. For more information, see Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getnumanodenumberfromhandle BOOL
		// GetNumaNodeNumberFromHandle( HANDLE hFile, PUSHORT NodeNumber );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "7622f7c9-2dfc-4ab7-b3e9-48d483c6cc0e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNumaNodeNumberFromHandle(IntPtr hFile, out ushort NodeNumber);

		/// <summary>
		/// <para>Retrieves the node number as a <c>USHORT</c> value for the specified logical processor.</para>
		/// </summary>
		/// <param name="Processor">
		/// <para>
		/// A pointer to a PROCESSOR_NUMBER structure that represents the logical processor and the processor group to which it is assigned.
		/// </para>
		/// </param>
		/// <param name="NodeNumber">
		/// <para>
		/// A pointer to a variable to receive the node number. If the specified processor does not exist, this parameter is set to MAXUSHORT.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To compile an application that uses this function, set _WIN32_WINNT &gt;= 0x0601. For more information, see Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getnumaprocessornodeex BOOL GetNumaProcessorNodeEx(
		// PPROCESSOR_NUMBER Processor, PUSHORT NodeNumber );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "6b843cd8-eeb5-4aa1-aad4-ce98916346b1")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNumaProcessorNodeEx(ref PROCESSOR_NUMBER Processor, out ushort NodeNumber);

		/// <summary>
		/// <para>Retrieves the NUMA node number that corresponds to the specified proximity domain identifier.</para>
		/// <para>Use the GetNumaProximityNodeEx function to retrieve the node number as a <c>USHORT</c> value.</para>
		/// </summary>
		/// <param name="ProximityId">
		/// <para>The proximity domain identifier of the node.</para>
		/// </param>
		/// <param name="NodeNumber">
		/// <para>The node number. If the processor does not exist, this parameter is 0xFF.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A proximity domain identifier is an index to a NUMA node on a NUMA system. Proximity domain identifiers are found in the ACPI
		/// System Resource Affinity Table (SRAT), where they are used to associate processors and memory regions with a particular NUMA
		/// node. Proximity domain identifiers are also found in the ACPI namespace, where they are used to associate a device with a
		/// particular NUMA node. Proximity domain identifiers are typically used only by management applications provided by system
		/// manufacturers. Windows does not use proximity domain identifiers to identify NUMA nodes; instead, it assigns a unique number to
		/// each NUMA node in the system.
		/// </para>
		/// <para>
		/// The relative distance between nodes on a system is stored in the ACPI System Locality Distance Information Table (SLIT), which is
		/// not exposed by any Windows functions. For more information about ACPI tables, see the ACPI specifications.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getnumaproximitynode BOOL GetNumaProximityNode( ULONG
		// ProximityId, PUCHAR NodeNumber );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "9a2dbfe3-13e7-442d-a5f6-b2632878f618")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNumaProximityNode(uint ProximityId, out byte NodeNumber);

		/// <summary>
		/// <para>
		/// Gets the data execution prevention (DEP) and DEP-ATL thunk emulation settings for the specified 32-bit process. <c>Windows XP
		/// with SP3:</c> Gets the DEP and DEP-ATL thunk emulation settings for the current process.
		/// </para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>A handle to the process. <c>PROCESS_QUERY_INFORMATION</c> privilege is required to get the DEP policy of a process.</para>
		/// <para><c>Windows XP with SP3:</c> The hProcess parameter is ignored.</para>
		/// </param>
		/// <param name="lpFlags">
		/// <para>A <c>DWORD</c> that receives one or more of the following flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>DEP is disabled for the specified process.</term>
		/// </item>
		/// <item>
		/// <term>PROCESS_DEP_ENABLE 0x00000001</term>
		/// <term>DEP is enabled for the specified process.</term>
		/// </item>
		/// <item>
		/// <term>PROCESS_DEP_DISABLE_ATL_THUNK_EMULATION 0x00000002</term>
		/// <term>DEP-ATL thunk emulation is disabled for the specified process. For information about DEP-ATL thunk emulation, see SetProcessDEPPolicy.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpPermanent">
		/// <para>
		/// <c>TRUE</c> if DEP is enabled or disabled permanently for the specified process; otherwise <c>FALSE</c>. If lpPermanent is
		/// <c>TRUE</c>, the current DEP setting persists for the life of the process and cannot be changed by calling SetProcessDEPPolicy.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>. To retrieve error values defined for this function, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>GetProcessDEPPolicy</c> is supported for 32-bit processes only. If this function is called on a 64-bit process, it fails with <c>ERROR_NOT_SUPPORTED</c>.
		/// </para>
		/// <para>
		/// To compile an application that calls this function, define <c>_WIN32_WINNT</c> as 0x0600 or later. For more information, see
		/// Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getprocessdeppolicy BOOL GetProcessDEPPolicy( HANDLE
		// hProcess, LPDWORD lpFlags, PBOOL lpPermanent );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "adf15b9c-24f4-49ea-9283-0db5f3f13e65")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetProcessDEPPolicy(IntPtr hProcess, out PROCESS_DEP lpFlags, [MarshalAs(UnmanagedType.Bool)] out bool lpPermanent);

		/// <summary>
		/// <para>Gets the data execution prevention (DEP) policy setting for the system.</para>
		/// </summary>
		/// <returns>
		/// <para>This function returns a value of type <c>DEP_SYSTEM_POLICY_TYPE</c>, which can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AlwaysOff 0</term>
		/// <term>
		/// DEP is disabled for all parts of the system, regardless of hardware support for DEP. The processor runs in PAE mode with 32-bit
		/// versions of Windows unless PAE is disabled in the boot configuration data.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AlwaysOn 1</term>
		/// <term>
		/// DEP is enabled for all parts of the system. All processes always run with DEP enabled. DEP cannot be explicitly disabled for
		/// selected applications. System compatibility fixes are ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OptIn 2</term>
		/// <term>
		/// On systems with processors that are capable of hardware-enforced DEP, DEP is automatically enabled only for operating system
		/// components. This is the default setting for client versions of Windows. DEP can be explicitly enabled for selected applications
		/// or the current process.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OptOut 3</term>
		/// <term>
		/// DEP is automatically enabled for operating system components and all processes. This is the default setting for Windows Server
		/// versions. DEP can be explicitly disabled for selected applications or the current process. System compatibility fixes for DEP are
		/// in effect.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The system-wide DEP policy is configured at boot time according to the policy setting in the boot configuration data. To change
		/// the system-wide DEP policy setting, use the BCDEdit /set command to set the <c>nx</c> boot entry option.
		/// </para>
		/// <para>
		/// If the system DEP policy is OptIn or OptOut, DEP can be selectively enabled or disabled for the current process by calling the
		/// SetProcessDEPPolicy function. This function works only for 32-bit processes.
		/// </para>
		/// <para>
		/// A user with administrative privileges can disable DEP for selected applications by using the <c>System</c> Control Panel
		/// application. If the system DEP policy is OptOut, DEP is disabled for these applications.
		/// </para>
		/// <para>
		/// The Application Compatibility Toolkit can be used to create a list of individual applications that are exempt from DEP. If the
		/// system DEP policy is OptOut, DEP is automatically disabled for applications on the list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getsystemdeppolicy DEP_SYSTEM_POLICY_TYPE
		// GetSystemDEPPolicy( );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "82cb1d4e-c0e5-4601-aa55-9171a106c286")]
		public static extern DEP_SYSTEM_POLICY_TYPE GetSystemDEPPolicy();

		/// <summary>
		/// <para>Retrieves a handle to the event associated with the specified user-mode scheduling (UMS) completion list.</para>
		/// </summary>
		/// <param name="UmsCompletionList">
		/// <para>A pointer to a UMS completion list. The CreateUmsCompletionList function provides this pointer.</para>
		/// </param>
		/// <param name="UmsCompletionEvent">
		/// <para>
		/// A pointer to a HANDLE variable. On output, the UmsCompletionEvent parameter is set to a handle to the event associated with the
		/// specified completion list.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The system signals a UMS completion list event when the system queues items to an empty completion list. A completion list event
		/// handle can be used with any wait function that takes a handle to an event. When the event is signaled, an application typically
		/// calls DequeueUmsCompletionListItems to retrieve the contents of the completion list.
		/// </para>
		/// <para>
		/// The event handle remains valid until its completion list is deleted. Do not use the event handle to wait on a completion list
		/// that has been deleted or is in the process of being deleted.
		/// </para>
		/// <para>When the handle is no longer needed, use the CloseHandle function to close the handle.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getumscompletionlistevent BOOL GetUmsCompletionListEvent(
		// PUMS_COMPLETION_LIST UmsCompletionList, PHANDLE UmsCompletionEvent );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "393f6e0a-fbea-4aa0-9c18-f96da18e61e9")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetUmsCompletionListEvent(IntPtr UmsCompletionList, out IntPtr UmsCompletionEvent);

		/// <summary>
		/// <para>Queries whether the specified thread is a UMS scheduler thread, a UMS worker thread, or a non-UMS thread.</para>
		/// </summary>
		/// <param name="ThreadHandle">
		/// <para>
		/// A handle to a thread. The thread handle must have the THREAD_QUERY_INFORMATION access right. For more information, see Thread
		/// Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="SystemThreadInfo">
		/// <para>A pointer to an initialized UMS_SYSTEM_THREAD_INFORMATION structure that specifies the kind of thread for the query.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns TRUE if the specified thread matches the kind of thread specified by the SystemThreadInfo parameter. Otherwise, the
		/// function returns FALSE.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetUmsSystemThreadInformation</c> function is intended for use in debuggers, troubleshooting tools, and profiling
		/// applications. For example, thread-isolated tracing or single-stepping through instructions might involve suspending all other
		/// threads in the process. However, if the thread to be traced is a UMS worker thread, suspending UMS scheduler threads might cause
		/// a deadlock because a UMS worker thread requires the intervention of a UMS scheduler thread in order to run. A debugger can call
		/// <c>GetUmsSystemThreadInformation</c> for each thread that it might suspend to determine the kind of thread, and then suspend it
		/// or not as needed for the code being debugged.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getumssystemthreadinformation BOOL
		// GetUmsSystemThreadInformation( HANDLE ThreadHandle, PUMS_SYSTEM_THREAD_INFORMATION SystemThreadInfo );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "7c8347b6-6546-4ea9-9b2a-11794782f482")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetUmsSystemThreadInformation(IntPtr ThreadHandle, ref UMS_SYSTEM_THREAD_INFORMATION SystemThreadInfo);

		/// <summary>
		/// <para>Returns the mask of XState features set within a CONTEXT structure.</para>
		/// </summary>
		/// <param name="Context">
		/// <para>A pointer to a CONTEXT structure that has been initialized with InitializeContext.</para>
		/// </param>
		/// <param name="FeatureMask">
		/// <para>A pointer to a variable that receives the mask of XState features which are present in the specified <c>CONTEXT</c> structure.</para>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>TRUE</c> if successful, otherwise <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetXStateFeaturesMask</c> function returns the mask of valid features in the specified context. If a CONTEXT is to be
		/// passed to GetThreadContext or Wow64GetThreadContext, the application must call SetXStateFeaturesMask to set which features are to
		/// be retrieved. <c>GetXStateFeaturesMask</c> should then be called on the <c>CONTEXT</c> returned by <c>GetThreadContext</c> or
		/// <c>Wow64GetThreadContext</c> to determine which feature areas contain valid data. If a particular feature bit is not set, the
		/// corresponding state is in a processor-specific <c>INITIALIZED</c> state and the contents of the feature area retrieved by
		/// LocateXStateFeature are undefined.
		/// </para>
		/// <para>
		/// The definition of XState features are processor vendor specific. Please refer to the relevant processor reference manuals for
		/// additional information on a particular feature.
		/// </para>
		/// <para>
		/// <c>Note</c> The value returned by <c>GetXStateFeaturesMask</c> on a CONTEXT after a context operation will always be a subset of
		/// the mask specified in a call to SetXStateFeaturesMask prior to the context operation.
		/// </para>
		/// <para>
		/// <c>Windows 7 with SP1 and Windows Server 2008 R2 with SP1:</c> The AVX API is first implemented on Windows 7 with SP1 and Windows
		/// Server 2008 R2 with SP1 . Since there is no SDK for SP1, that means there are no available headers and library files to work
		/// with. In this situation, a caller must declare the needed functions from this documentation and get pointers to them using
		/// GetModuleHandle on "Kernel32.dll", followed by calls to GetProcAddress. See Working with XState Context for details.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getxstatefeaturesmask BOOL GetXStateFeaturesMask( PCONTEXT
		// Context, PDWORD64 FeatureMask );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "D9A8D0B6-21E3-46B7-AB88-CE2FF4025A17")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetXStateFeaturesMask(IntPtr Context, out ulong FeatureMask);

		/// <summary>
		/// <para>Initializes a CONTEXT structure inside a buffer with the necessary size and alignment.</para>
		/// </summary>
		/// <param name="Buffer">
		/// <para>
		/// A pointer to a buffer within which to initialize a CONTEXT structure. This parameter can be <c>NULL</c> to determine the buffer
		/// size required to hold a context record with the specified .
		/// </para>
		/// </param>
		/// <param name="ContextFlags">
		/// <para>
		/// A value indicating which portions of the structure should be initialized. This parameter influences the size of the initialized structure.
		/// </para>
		/// <para>
		/// <c>Note</c><c>CONTEXT_XSTATE</c> is not part of <c>CONTEXT_FULL</c> or <c>CONTEXT_ALL</c>. It must be specified separately if an
		/// XState context is desired.
		/// </para>
		/// </param>
		/// <param name="Context">
		/// <para>A pointer to a variable which receives the address of the initialized CONTEXT structure within the .</para>
		/// <para>
		/// <c>Note</c> Due to alignment requirements of CONTEXT structures, the value returned in may not be at the beginning of the
		/// supplied buffer.
		/// </para>
		/// </param>
		/// <param name="ContextLength">
		/// <para>
		/// On input, specifies the length of the buffer pointed to by , in bytes. If the buffer is not large enough to contain the specified
		/// portions of the CONTEXT, the function fails, GetLastError returns <c>ERROR_INSUFFICIENT_BUFFER</c>, and is set to the required
		/// size of the buffer. If the function fails with an error other than <c>ERROR_INSUFFICIENT_BUFFER</c>, the contents of are undefined.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>TRUE</c> if successful, otherwise <c>FALSE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// can be used to initialize a CONTEXT structure within a buffer with the required size and alignment characteristics. This routine
		/// is required if the <c>CONTEXT_XSTATE</c> is specified since the required context size and alignment may change depending on which
		/// processor features are enabled on the system.
		/// </para>
		/// <para>
		/// First, call this function with the parameter set to the maximum number of features you will be using and the parameter to
		/// <c>NULL</c>. The function returns the required buffer size in bytes in the parameter. Allocate enough space for the data in the
		/// and call the function again to initialize the . Upon successful completion of this routine, the member of the structure is
		/// initialized, but the remaining contents of the structure are undefined. Some bits specified in the parameter may not be set in
		/// -&gt; if they are not supported by the system. Applications may subsequently remove, but must never add, bits from the member of CONTEXT.
		/// </para>
		/// <para>
		/// <c>Windows 7 with SP1 and Windows Server 2008 R2 with SP1:</c> The AVX API is first implemented on Windows 7 with SP1 and Windows
		/// Server 2008 R2 with SP1 . Since there is no SDK for SP1, that means there are no available headers and library files to work
		/// with. In this situation, a caller must declare the needed functions from this documentation and get pointers to them using
		/// GetModuleHandle on "Kernel32.dll", followed by calls to GetProcAddress. See Working with XState Context for details.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-initializecontext BOOL InitializeContext( PVOID Buffer,
		// DWORD ContextFlags, PCONTEXT *Context, PDWORD ContextLength );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "909BF5F7-0622-4B22-A2EC-27722389700A")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InitializeContext(IntPtr Buffer, CONTEXT_FLAG ContextFlags, out IntPtr Context, ref uint ContextLength);

		/// <summary>
		/// <para>Indicates if the OS was booted from a VHD container.</para>
		/// </summary>
		/// <param name="NativeVhdBoot">
		/// <para>Pointer to a variable that receives a boolean indicating if the OS was booted from a VHD.</para>
		/// </param>
		/// <returns>
		/// <para>TRUE if the OS was a native VHD boot; otherwise, FALSE.</para>
		/// <para>Call GetLastError to get extended error information.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-isnativevhdboot BOOL IsNativeVhdBoot( PBOOL NativeVhdBoot );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "8198D4AF-553D-42B3-AF22-EC2C63C0E9AE")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsNativeVhdBoot([MarshalAs(UnmanagedType.Bool)] out bool NativeVhdBoot);

		/// <summary>
		/// <para>Loads the specified packaged module and its dependencies into the address space of the calling process.</para>
		/// </summary>
		/// <param name="lpwLibFileName">
		/// <para>
		/// The file name of the packaged module to load. The module can be a library module (a .dll file) or an executable module (an .exe file).
		/// </para>
		/// <para>
		/// If this parameter specifies a module name without a path and the file name extension is omitted, the function appends the default
		/// library extension .dll to the module name. To prevent the function from appending .dll to the module name, include a trailing
		/// point character (.) in the module name string.
		/// </para>
		/// <para>
		/// If this parameter specifies a path, the function searches that path for the module. The path cannot be an absolute path or a
		/// relative path that contains ".." in the path. When specifying a path, be sure to use backslashes (), not forward slashes (/). For
		/// more information about paths, see Naming Files, Paths, and Namespaces.
		/// </para>
		/// <para>
		/// If the specified module is already loaded in the process, the function returns a handle to the loaded module. The module must
		/// have been originally loaded from the package dependency graph of the process.
		/// </para>
		/// <para>
		/// If loading the specified module causes the system to load other associated modules, the function first searches loaded modules,
		/// then it searches the package dependency graph of the process. For more information, see Remarks.
		/// </para>
		/// </param>
		/// <param name="Reserved">
		/// <para>This parameter is reserved. It must be 0.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the loaded module.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>LoadPackagedLibrary</c> function is a simplified version of LoadLibraryEx. Windows Runtime apps can use
		/// <c>LoadPackagedLibrary</c> to load packaged modules. Desktop applications cannot use <c>LoadPackagedLibrary</c>; if a desktop
		/// application calls this function it fails with <c>APPMODEL_ERROR_NO_PACKAGE</c>.
		/// </para>
		/// <para>
		/// <c>LoadPackagedLibrary</c> returns a handle to the specified module and increments its reference count. If the module is already
		/// loaded, the function returns a handle to the loaded module. The calling process can use the handle returned by
		/// <c>LoadPackagedLibrary</c> to identify the module in calls to the GetProcAddress function. Use the FreeLibrary function to free a
		/// loaded module and decrement its reference count.
		/// </para>
		/// <para>
		/// If the function must search for the specified module or its dependencies, it searches only the package dependency graph of the
		/// process. This is the application's package plus any dependencies specified as in the section of the application's package
		/// manifest. Dependencies are searched in the order they appear in the manifest. The package dependency graph is specified in the
		/// section of the application's package manifest. Dependencies are searched in the order they appear in the manifest. The search
		/// proceeds as follows:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// The function first searches modules that are already loaded. If the specified module was originally loaded from the package
		/// dependency graph of the process, the function returns a handle to the loaded module. If the specified module was not loaded from
		/// the package dependency graph of the process, the function returns <c>NULL</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>If the module is not already loaded, the function searches the package dependency graph of the process.</term>
		/// </item>
		/// <item>
		/// <term>If the function cannot find the specified module or one of its dependencies, the function fails.</term>
		/// </item>
		/// </list>
		/// <para>It is not safe to call <c>LoadPackagedLibrary</c> from DllMain. For more information, see the Remarks section in <c>DllMain</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-loadpackagedlibrary HMODULE LoadPackagedLibrary( LPCWSTR
		// lpwLibFileName, DWORD Reserved );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "4a103753-a2c9-487f-b797-01d5f5d489f3")]
		public static extern SafeLibraryHandle LoadPackagedLibrary([MarshalAs(UnmanagedType.LPWStr)] string lpwLibFileName, uint Reserved = 0);

		/// <summary>
		/// <para>Retrieves a pointer to the processor state for an XState feature within a CONTEXT structure.</para>
		/// <para>
		/// The definition of XState feature bits are processor vendor specific. Please refer to the relevant processor reference manuals for
		/// additional information on a particular feature.
		/// </para>
		/// </summary>
		/// <param name="Context">
		/// <para>
		/// A pointer to a CONTEXT structure containing the state to retrieve or set. This <c>CONTEXT</c> should have been initialized with
		/// InitializeContext with the <c>CONTEXT_XSTATE</c> flag set in the ContextFlags parameter.
		/// </para>
		/// </param>
		/// <param name="FeatureId">
		/// <para>The number of the feature to locate within the CONTEXT structure.</para>
		/// </param>
		/// <param name="Length">
		/// <para>
		/// A pointer to a variable which receives the length of the feature area in bytes. The contents of this variable are undefined if
		/// this function returns <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the specified feature is supported by the system and the specified CONTEXT structure has been initialized with the
		/// <c>CONTEXT_XSTATE</c> flag, this function returns a pointer to the feature area for the specified feature. The contents and
		/// layout of this area is processor-specific.
		/// </para>
		/// <para>
		/// If the <c>CONTEXT_XSTATE</c> flag is not set in the CONTEXT structure or the FeatureID is not supported by the system, the return
		/// value is <c>NULL</c>. No additional error information is available.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>LocateXStateFeature</c> function must be used to find an individual XState feature within an extensible CONTEXT structure.
		/// Features are not necessarily contiguous in memory and applications should not assume the offset between two consecutive features
		/// will remain constant in the future.
		/// </para>
		/// <para>
		/// The FeatureID parameter of the function corresponds to a bit within the feature mask. For example, FeatureId 2 corresponds to a
		/// FeatureMask of 4 in SetXStateFeaturesMask. FeatureID values of 0 and 1 correspond to X87 FPU state and SSE state, respectively.
		/// </para>
		/// <para>
		/// If you are setting XState on a thread via the SetThreadContext or Wow64SetThreadContext APIs, you must also call
		/// SetXStateFeaturesMask on the CONTEXT structure with the mask value of the filled-in feature to mark the feature as active.
		/// </para>
		/// <para>
		/// <c>Windows 7 with SP1 and Windows Server 2008 R2 with SP1:</c> The AVX API is first implemented on Windows 7 with SP1 and Windows
		/// Server 2008 R2 with SP1 . Since there is no SDK for SP1, that means there are no available headers and library files to work
		/// with. In this situation, a caller must declare the needed functions from this documentation and get pointers to them using
		/// GetModuleHandle on "Kernel32.dll", followed by calls to GetProcAddress. See Working with XState Context for details.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-locatexstatefeature PVOID LocateXStateFeature( PCONTEXT
		// Context, DWORD FeatureId, PDWORD Length );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "7AAEA13B-E4A4-4410-BFC7-09B81B92FF26")]
		public static extern IntPtr LocateXStateFeature(IntPtr Context, uint FeatureId, out uint Length);

		/// <summary>
		/// <para>Compares two character strings. The comparison is case-sensitive.</para>
		/// <para>To perform a comparison that is not case-sensitive, use the lstrcmpi function.</para>
		/// </summary>
		/// <param name="lpString1">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The first null-terminated string to be compared.</para>
		/// </param>
		/// <param name="lpString2">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The second null-terminated string to be compared.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// If the string pointed to by lpString1 is less than the string pointed to by lpString2, the return value is negative. If the
		/// string pointed to by lpString1 is greater than the string pointed to by lpString2, the return value is positive. If the strings
		/// are equal, the return value is zero.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>lstrcmp</c> function compares two strings by checking the first characters against each other, the second characters
		/// against each other, and so on until it finds an inequality or reaches the ends of the strings.
		/// </para>
		/// <para>Note that the lpString1 and lpString2 parameters must be null-terminated, otherwise the string comparison can be incorrect.</para>
		/// <para>
		/// The function calls CompareStringEx, using the current thread locale, and subtracts 2 from the result, to maintain the C run-time
		/// conventions for comparing strings.
		/// </para>
		/// <para>
		/// The language (user locale) selected by the user at setup time, or through Control Panel, determines which string is greater (or
		/// whether the strings are the same). If no language (user locale) is selected, the system performs the comparison by using default values.
		/// </para>
		/// <para>With a double-byte character set (DBCS) version of the system, this function can compare two DBCS strings.</para>
		/// <para>
		/// The <c>lstrcmp</c> function uses a word sort, rather than a string sort. A word sort treats hyphens and apostrophes differently
		/// than it treats other symbols that are not alphanumeric, in order to ensure that words such as "coop" and "co-op" stay together
		/// within a sorted list. For a detailed discussion of word sorts and string sorts, see Handling Sorting in Your Applications.
		/// </para>
		/// <para>Security Remarks</para>
		/// <para>See Security Considerations: International Features for security considerations regarding</para>
		/// <para>choice of comparison functions.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-lstrcmpa int lstrcmpA( LPCSTR lpString1, LPCSTR lpString2 );
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "windows/desktop/api/winbase/nf-winbase-lstrcmpa")]
		public static extern int lstrcmp(string lpString1, string lpString2);

		/// <summary>
		/// <para>Compares two character strings. The comparison is not case-sensitive.</para>
		/// <para>To perform a comparison that is case-sensitive, use the lstrcmp function.</para>
		/// </summary>
		/// <param name="lpString1">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The first null-terminated string to be compared.</para>
		/// </param>
		/// <param name="lpString2">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The second null-terminated string to be compared.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// If the string pointed to by lpString1 is less than the string pointed to by lpString2, the return value is negative. If the
		/// string pointed to by lpString1 is greater than the string pointed to by lpString2, the return value is positive. If the strings
		/// are equal, the return value is zero.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>lstrcmpi</c> function compares two strings by checking the first characters against each other, the second characters
		/// against each other, and so on until it finds an inequality or reaches the ends of the strings.
		/// </para>
		/// <para>Note that the lpString1 and lpString2 parameters must be null-terminated, otherwise the string comparison can be incorrect.</para>
		/// <para>
		/// The function calls CompareStringEx, using the current thread locale, and subtracts 2 from the result, to maintain the C run-time
		/// conventions for comparing strings.
		/// </para>
		/// <para>
		/// For some locales, the <c>lstrcmpi</c> function may be insufficient. If this occurs, use CompareStringEx to ensure proper
		/// comparison. For example, in Japan call with the <c>NORM_IGNORECASE</c>, <c>NORM_IGNOREKANATYPE</c>, and <c>NORM_IGNOREWIDTH</c>
		/// values to achieve the most appropriate non-exact string comparison. The <c>NORM_IGNOREKANATYPE</c> and <c>NORM_IGNOREWIDTH</c>
		/// values are ignored in non-Asian locales, so you can set these values for all locales and be guaranteed to have a culturally
		/// correct "insensitive" sorting regardless of the locale. Note that specifying these values slows performance, so use them only
		/// when necessary.
		/// </para>
		/// <para>With a double-byte character set (DBCS) version of the system, this function can compare two DBCS strings.</para>
		/// <para>
		/// The <c>lstrcmpi</c> function uses a word sort, rather than a string sort. A word sort treats hyphens and apostrophes differently
		/// than it treats other symbols that are not alphanumeric, in order to ensure that words such as "coop" and "co-op" stay together
		/// within a sorted list. For a detailed discussion of word sorts and string sorts, see Handling Sorting in Your Applications.
		/// </para>
		/// <para>Security Remarks</para>
		/// <para>See Security Considerations: International Features for security considerations regarding</para>
		/// <para>choice of comparison functions.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-lstrcmpia int lstrcmpiA( LPCSTR lpString1, LPCSTR
		// lpString2 );
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "windows/desktop/api/winbase/nf-winbase-lstrcmpia")]
		public static extern int lstrcmpi(string lpString1, string lpString2);

		/// <summary>
		/// <para>Copies a specified number of characters from a source string into a buffer.</para>
		/// <para><c>Warning</c> Do not use. Consider using StringCchCopy instead. See Remarks.</para>
		/// </summary>
		/// <param name="lpString1">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// The destination buffer, which receives the copied characters. The buffer must be large enough to contain the number of
		/// <c>TCHAR</c> values specified by iMaxLength, including room for a terminating null character.
		/// </para>
		/// </param>
		/// <param name="lpString2">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The source string from which the function is to copy characters.</para>
		/// </param>
		/// <param name="iMaxLength">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The number of <c>TCHAR</c> values to be copied from the string pointed to by lpString2 into the buffer pointed to by lpString1,
		/// including a terminating null character.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// If the function succeeds, the return value is a pointer to the buffer. The function can succeed even if the source string is
		/// greater than iMaxLength characters.
		/// </para>
		/// <para>If the function fails, the return value is <c>NULL</c> and lpString1 may not be null-terminated.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The buffer pointed to by lpString1 must be large enough to include a terminating null character, and the string length value
		/// specified by iMaxLength includes room for a terminating null character.
		/// </para>
		/// <para>The <c>lstrcpyn</c> function has an undefined behavior if source and destination buffers overlap.</para>
		/// <para>Security Warning</para>
		/// <para>
		/// Using this function incorrectly can compromise the security of your application. This function uses structured exception handling
		/// (SEH) to catch access violations and other errors. When this function catches SEH errors, it returns <c>NULL</c> without
		/// null-terminating the string and without notifying the caller of the error. The caller is not safe to assume that insufficient
		/// space is the error condition.
		/// </para>
		/// <para>
		/// If the buffer pointed to by lpString1 is not large enough to contain the copied string, a buffer overrun can occur. When copying
		/// an entire string, note that <c>sizeof</c> returns the number of bytes. For example, if lpString1 points to a buffer szString1
		/// which is declared as , then sizeof(szString1) gives the size of the buffer in bytes rather than <c>WCHAR</c>, which could lead to
		/// a buffer overflow for the Unicode version of the function.
		/// </para>
		/// <para>
		/// Buffer overflow situations are the cause of many security problems in applications and can cause a denial of service attack
		/// against the application if an access violation occurs. In the worst case, a buffer overrun may allow an attacker to inject
		/// executable code into your process, especially if lpString1 is a stack-based buffer.
		/// </para>
		/// <para>Using gives the proper size of the buffer.</para>
		/// <para>
		/// Consider using StringCchCopy instead; use either , being aware that must not be a pointer or use , being aware that, when copying
		/// to a pointer, the caller is responsible for passing in the size of the pointed-to memory in characters.
		/// </para>
		/// <para>Review Security Considerations: Windows User Interface before continuing.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-lstrcpyna LPSTR lstrcpynA( LPSTR lpString1, LPCSTR
		// lpString2, int iMaxLength );
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "windows/desktop/api/winbase/nf-winbase-lstrcpyna")]
		public static extern IntPtr lstrcpyn(StringBuilder lpString1, string lpString2, int iMaxLength);

		/// <summary>Determines the length of the specified string (not including the terminating null character).</summary>
		/// <param name="lpString">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The null-terminated string to be checked.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>The function returns the length of the string, in characters. If lpString is <c>NULL</c>, the function returns 0.</para>
		/// </returns>
		// int WINAPI lstrlen( _In_ LPCTSTR lpString); https://msdn.microsoft.com/en-us/library/windows/desktop/ms647492(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms647492")]
		public static extern int lstrlen(string lpString);

		/// <summary>
		/// <para>
		/// Maps a view of a file mapping into the address space of a calling process and specifies the NUMA node for the physical memory.
		/// </para>
		/// </summary>
		/// <param name="hFileMappingObject">
		/// <para>A handle to a file mapping object. The CreateFileMappingNuma and OpenFileMapping functions return this handle.</para>
		/// </param>
		/// <param name="dwDesiredAccess">
		/// <para>
		/// The type of access to a file mapping object, which determines the page protection of the pages. This parameter can be one of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_MAP_ALL_ACCESS</term>
		/// <term>
		/// A read/write view of the file is mapped. The file mapping object must have been created with PAGE_READWRITE or
		/// PAGE_EXECUTE_READWRITE protection. When used with the MapViewOfFileExNuma function, FILE_MAP_ALL_ACCESS is equivalent to FILE_MAP_WRITE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_MAP_COPY</term>
		/// <term>
		/// A copy-on-write view of the file is mapped. The file mapping object must have been created with PAGE_READONLY, PAGE_READ_EXECUTE,
		/// PAGE_WRITECOPY, PAGE_EXECUTE_WRITECOPY, PAGE_READWRITE, or PAGE_EXECUTE_READWRITE protection. When a process writes to a
		/// copy-on-write page, the system copies the original page to a new page that is private to the process. The new page is backed by
		/// the paging file. The protection of the new page changes from copy-on-write to read/write. When copy-on-write access is specified,
		/// the system and process commit charge taken is for the entire view because the calling process can potentially write to every page
		/// in the view, making all pages private. The contents of the new page are never written back to the original file and are lost when
		/// the view is unmapped.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_MAP_READ</term>
		/// <term>
		/// A read-only view of the file is mapped. An attempt to write to the file view results in an access violation. The file mapping
		/// object must have been created with PAGE_READONLY, PAGE_READWRITE, PAGE_EXECUTE_READ, or PAGE_EXECUTE_READWRITE protection.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_MAP_WRITE</term>
		/// <term>
		/// A read/write view of the file is mapped. The file mapping object must have been created with PAGE_READWRITE or
		/// PAGE_EXECUTE_READWRITE protection. When used with MapViewOfFileExNuma, and FILE_MAP_ALL_ACCESS are equivalent to FILE_MAP_WRITE.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Each of the preceding values can be combined with the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_MAP_EXECUTE</term>
		/// <term>
		/// An executable view of the file is mapped (mapped memory can be run as code). The file mapping object must have been created with
		/// PAGE_EXECUTE_READ, PAGE_EXECUTE_WRITECOPY, or PAGE_EXECUTE_READWRITE protection.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// For file mapping objects created with the <c>SEC_IMAGE</c> attribute, the dwDesiredAccess parameter has no effect and should be
		/// set to any valid value such as <c>FILE_MAP_READ</c>.
		/// </para>
		/// <para>For more information about access to file mapping objects, see File Mapping Security and Access Rights.</para>
		/// </param>
		/// <param name="dwFileOffsetHigh">
		/// <para>The high-order <c>DWORD</c> of the file offset where the view is to begin.</para>
		/// </param>
		/// <param name="dwFileOffsetLow">
		/// <para>
		/// The low-order <c>DWORD</c> of the file offset where the view is to begin. The combination of the high and low offsets must
		/// specify an offset within the file mapping. They must also match the memory allocation granularity of the system. That is, the
		/// offset must be a multiple of the allocation granularity. To obtain the memory allocation granularity of the system, use the
		/// GetSystemInfo function, which fills in the members of a SYSTEM_INFO structure.
		/// </para>
		/// </param>
		/// <param name="dwNumberOfBytesToMap">
		/// <para>
		/// The number of bytes of a file mapping to map to a view. All bytes must be within the maximum size specified by CreateFileMapping.
		/// If this parameter is 0 (zero), the mapping extends from the specified offset to the end of the file mapping.
		/// </para>
		/// </param>
		/// <param name="lpBaseAddress">
		/// <para>
		/// A pointer to the memory address in the calling process address space where mapping begins. This must be a multiple of the
		/// system's memory allocation granularity, or the function fails. To determine the memory allocation granularity of the system, use
		/// the GetSystemInfo function. If there is not enough address space at the specified address, the function fails.
		/// </para>
		/// <para>If the lpBaseAddress parameter is <c>NULL</c>, the operating system chooses the mapping address.</para>
		/// <para>
		/// While it is possible to specify an address that is safe now (not used by the operating system), there is no guarantee that the
		/// address will remain safe over time. Therefore, it is better to let the operating system choose the address. In this case, you
		/// would not store pointers in the memory mapped file; you would store offsets from the base of the file mapping so that the mapping
		/// can be used at any address.
		/// </para>
		/// </param>
		/// <param name="nndPreferred">
		/// <para>The NUMA node where the physical memory should reside.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NUMA_NO_PREFERRED_NODE 0xffffffff</term>
		/// <term>No NUMA node is preferred. This is the same as calling the MapViewOfFileEx function.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the starting address of the mapped view.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// <para>Mapping a file makes the specified portion of the file visible in the address space of the calling process.</para>
		/// <para>
		/// For files that are larger than the address space, you can map only a small portion of the file data at one time. When the first
		/// view is complete, then you unmap it and map a new view.
		/// </para>
		/// <para>To obtain the size of a view, use the VirtualQueryEx function.</para>
		/// <para>The initial contents of the pages in a file mapping object backed by the page file are 0 (zero).</para>
		/// <para>
		/// If a suggested mapping address is supplied, the file is mapped at the specified address (rounded down to the nearest 64-KB
		/// boundary) if there is enough address space at the specified address. If there is not enough address space, the function fails.
		/// </para>
		/// <para>
		/// Typically, the suggested address is used to specify that a file should be mapped at the same address in multiple processes. This
		/// requires the region of address space to be available in all involved processes. No other memory allocation can take place in the
		/// region that is used for mapping, including the use of the VirtualAllocExNuma function to reserve memory.
		/// </para>
		/// <para>
		/// If the lpBaseAddress parameter specifies a base offset, the function succeeds if the specified memory region is not already in
		/// use by the calling process. The system does not ensure that the same memory region is available for the memory mapped file in
		/// other 32-bit processes.
		/// </para>
		/// <para>
		/// Multiple views of a file (or a file mapping object and its mapped file) are coherent if they contain identical data at a
		/// specified time. This occurs if the file views are derived from the same file mapping object. A process can duplicate a file
		/// mapping object handle into another process by using the DuplicateHandle function, or another process can open a file mapping
		/// object by name by using the OpenFileMapping function.
		/// </para>
		/// <para>
		/// With one important exception, file views derived from any file mapping object that is backed by the same file are coherent or
		/// identical at a specific time. Coherency is guaranteed for views within a process and for views that are mapped by different processes.
		/// </para>
		/// <para>
		/// The exception is related to remote files. Although <c>MapViewOfFileExNuma</c> works with remote files, it does not keep them
		/// coherent. For example, if two computers both map a file as writable, and both change the same page, each computer only sees its
		/// own writes to the page. When the data gets updated on the disk, it is not merged.
		/// </para>
		/// <para>A mapped view of a file is not guaranteed to be coherent with a file being accessed by the ReadFile or WriteFile function.</para>
		/// <para>
		/// To guard against <c>EXCEPTION_IN_PAGE_ERROR</c> exceptions, use structured exception handling to protect any code that writes to
		/// or reads from a memory mapped view of a file other than the page file. For more information, see Reading and Writing From a File View.
		/// </para>
		/// <para>
		/// When modifying a file through a mapped view, the last modification timestamp may not be updated automatically. If required, the
		/// caller should use SetFileTime to set the timestamp.
		/// </para>
		/// <para>
		/// To have a file with executable permissions, an application must call the CreateFileMappingNuma function with either
		/// <c>PAGE_EXECUTE_READWRITE</c> or <c>PAGE_EXECUTE_READ</c> and then call the <c>MapViewOfFileExNuma</c> function with
		/// <c>FILE_MAP_EXECUTE</c> | <c>FILE_MAP_WRITE</c> or <c>FILE_MAP_EXECUTE</c> | <c>FILE_MAP_READ</c>.
		/// </para>
		/// <para>In Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-mapviewoffileexnuma LPVOID MapViewOfFileExNuma( HANDLE
		// hFileMappingObject, DWORD dwDesiredAccess, DWORD dwFileOffsetHigh, DWORD dwFileOffsetLow, SIZE_T dwNumberOfBytesToMap, LPVOID
		// lpBaseAddress, DWORD nndPreferred );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "1e28c8db-112d-481d-b470-8ca618e125ce")]
		public static extern IntPtr MapViewOfFileExNuma(IntPtr hFileMappingObject, FileAccess dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, SizeT dwNumberOfBytesToMap, IntPtr lpBaseAddress, uint nndPreferred);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Moves an existing file or a directory, including its children, as a transacted operation.</para>
		/// </summary>
		/// <param name="lpExistingFileName">
		/// <para>The current name of the existing file or directory on the local computer.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="lpNewFileName">
		/// <para>
		/// The new name for the file or directory. The new name must not already exist. A new file may be on a different file system or
		/// drive. A new directory must be on the same drive.
		/// </para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="lpProgressRoutine">
		/// <para>
		/// A pointer to a CopyProgressRoutine callback function that is called each time another portion of the file has been moved. The
		/// callback function can be useful if you provide a user interface that displays the progress of the operation. This parameter can
		/// be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="lpData">
		/// <para>An argument to be passed to the CopyProgressRoutine callback function. This parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>The move options. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MOVEFILE_COPY_ALLOWED 2 (0x2)</term>
		/// <term>
		/// If the file is to be moved to a different volume, the function simulates the move by using the CopyFile and DeleteFile functions.
		/// If the file is successfully copied to a different volume and the original file is unable to be deleted, the function succeeds
		/// leaving the source file intact. This value cannot be used with MOVEFILE_DELAY_UNTIL_REBOOT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_CREATE_HARDLINK 16 (0x10)</term>
		/// <term>Reserved for future use.</term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_DELAY_UNTIL_REBOOT 4 (0x4)</term>
		/// <term>
		/// The system does not move the file until the operating system is restarted. The system moves the file immediately after AUTOCHK is
		/// executed, but before creating any paging files. Consequently, this parameter enables the function to delete paging files from
		/// previous startups. This value can only be used if the process is in the context of a user who belongs to the administrators group
		/// or the LocalSystem account. This value cannot be used with MOVEFILE_COPY_ALLOWED. The write operation to the registry value as
		/// detailed in the Remarks section is what is transacted. The file move is finished when the computer restarts, after the
		/// transaction is complete.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_REPLACE_EXISTING 1 (0x1)</term>
		/// <term>
		/// If a file named lpNewFileName exists, the function replaces its contents with the contents of the lpExistingFileName file. This
		/// value cannot be used if lpNewFileName or lpExistingFileName names a directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOVEFILE_WRITE_THROUGH 8 (0x8)</term>
		/// <term>
		/// A call to MoveFileTransacted means that the move file operation is complete when the commit operation is completed. This flag is
		/// unnecessary; there are no negative affects if this flag is specified, other than an operation slowdown. The function does not
		/// return until the file has actually been moved on the disk. Setting this value guarantees that a move performed as a copy and
		/// delete operation is flushed to disk before the function returns. The flush occurs at the end of the copy operation. This value
		/// has no effect if MOVEFILE_DELAY_UNTIL_REBOOT is set.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// <para>
		/// When moving a file across volumes, if lpProgressRoutine returns <c>PROGRESS_CANCEL</c> due to the user canceling the operation,
		/// <c>MoveFileTransacted</c> will return zero and GetLastError will return <c>ERROR_REQUEST_ABORTED</c>. The existing file is left intact.
		/// </para>
		/// <para>
		/// When moving a file across volumes, if lpProgressRoutine returns <c>PROGRESS_STOP</c> due to the user stopping the operation,
		/// <c>MoveFileTransacted</c> will return zero and GetLastError will return <c>ERROR_REQUEST_ABORTED</c>. The existing file is left intact.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the dwFlags parameter specifies <c>MOVEFILE_DELAY_UNTIL_REBOOT</c>, <c>MoveFileTransacted</c> fails if it cannot access the
		/// registry. The function transactionally stores the locations of the files to be renamed at restart in the following registry
		/// value: <c>HKEY_LOCAL_MACHINE</c>&lt;b&gt;SYSTEM&lt;b&gt;CurrentControlSet&lt;b&gt;Control&lt;b&gt;Session Manager&lt;b&gt;PendingFileRenameOperations
		/// </para>
		/// <para>
		/// This registry value is of type <c>REG_MULTI_SZ</c>. Each rename operation stores one of the following <c>NULL</c>-terminated
		/// strings, depending on whether the rename is a delete or not:
		/// </para>
		/// <para>szDstFile\0\0</para>
		/// <para>szSrcFile\0szDstFile\0</para>
		/// <para>The string szDstFile\0\0 indicates that the file szDstFile is to be deleted on reboot.</para>
		/// <para>The string szSrcFile\0szDstFile\0 indicates that szSrcFile is to be renamed szDstFile on reboot.</para>
		/// <para>
		/// <c>Note</c> Although \0\0 is technically not allowed in a <c>REG_MULTI_SZ</c> node, it can because the file is considered to be
		/// renamed to a null name.
		/// </para>
		/// <para>
		/// The system uses these registry entries to complete the operations at restart in the same order that they were issued. For more
		/// information about using the <c>MOVEFILE_DELAY_UNTIL_REBOOT</c> flag, see MoveFileWithProgress.
		/// </para>
		/// <para>
		/// If a file is moved across volumes, <c>MoveFileTransacted</c> does not move the security descriptor with the file. The file is
		/// assigned the default security descriptor in the destination directory.
		/// </para>
		/// <para>
		/// This function always fails if you specify the <c>MOVEFILE_FAIL_IF_NOT_TRACKABLE</c> flag; tracking is not supported by TxF.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-movefiletransacteda BOOL MoveFileTransactedA( LPCSTR
		// lpExistingFileName, LPCSTR lpNewFileName, LPPROGRESS_ROUTINE lpProgressRoutine, LPVOID lpData, DWORD dwFlags, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "466d733b-30d2-4297-a0e6-77038f1a21d5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MoveFileTransacted(string lpExistingFileName, string lpNewFileName, LpprogressRoutine lpProgressRoutine, IntPtr lpData, MOVEFILE dwFlags, IntPtr hTransaction);

		/// <summary>
		/// Multiplies two 32-bit values and then divides the 64-bit result by a third 32-bit value. The final result is rounded to the
		/// nearest integer.
		/// </summary>
		/// <param name="nNumber">The multiplicand.</param>
		/// <param name="nNumerator">The multiplier.</param>
		/// <param name="nDenominator">The number by which the result of the multiplication operation is to be divided.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the result of the multiplication and division, rounded to the nearest integer. If
		/// the result is a positive half integer (ends in .5), it is rounded up. If the result is a negative half integer, it is rounded down.
		/// </para>
		/// <para>If either an overflow occurred or nDenominator was 0, the return value is -1.</para>
		/// </returns>
		// int MulDiv( _In_ int nNumber, _In_ int nNumerator, _In_ int nDenominator); https://msdn.microsoft.com/en-us/library/windows/desktop/aa383718(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa383718")]
		public static extern int MulDiv(int nNumber, int nNumerator, int nDenominator);

		/// <summary>
		/// <para>Opens the file that matches the specified identifier.</para>
		/// </summary>
		/// <param name="hVolumeHint">
		/// <para>TBD</para>
		/// </param>
		/// <param name="lpFileId">
		/// <para>TBD</para>
		/// </param>
		/// <param name="dwDesiredAccess">
		/// <para>The access to the object. Access can be read, write, or both.</para>
		/// <para>
		/// For more information, see File Security and Access Rights. You cannot request an access mode that conflicts with the sharing mode
		/// that is specified in an open request that has an open handle.
		/// </para>
		/// <para>
		/// If this parameter is zero (0), the application can query file and device attributes without accessing a device. This is useful
		/// for an application to determine the size of a floppy disk drive and the formats it supports without requiring a floppy in a
		/// drive. It can also be used to test for the existence of a file or directory without opening them for read or write access.
		/// </para>
		/// </param>
		/// <param name="dwShareMode">
		/// <para>The sharing mode of an object, which can be read, write, both, or none.</para>
		/// <para>
		/// You cannot request a sharing mode that conflicts with the access mode that is specified in an open request that has an open
		/// handle, because that would result in the following sharing violation: ( <c>ERROR_SHARING_VIOLATION</c>). For more information,
		/// see Creating and Opening Files.
		/// </para>
		/// <para>
		/// If this parameter is zero (0) and <c>OpenFileById</c> succeeds, the object cannot be shared and cannot be opened again until the
		/// handle is closed. For more information, see the Remarks section of this topic.
		/// </para>
		/// <para>The sharing options remain in effect until you close the handle to an object.</para>
		/// <para>
		/// To enable a processes to share an object while another process has the object open, use a combination of one or more of the
		/// following values to specify the access mode they can request to open the object.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_SHARE_DELETE 0x00000004</term>
		/// <term>
		/// Enables subsequent open operations on an object to request delete access. Otherwise, other processes cannot open the object if
		/// they request delete access. If this flag is not specified, but the object has been opened for delete access, the function fails.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_SHARE_READ 0x00000001</term>
		/// <term>
		/// Enables subsequent open operations on an object to request read access. Otherwise, other processes cannot open the object if they
		/// request read access. If this flag is not specified, but the object has been opened for read access, the function fails.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_SHARE_WRITE 0x00000002</term>
		/// <term>
		/// Enables subsequent open operations on an object to request write access. Otherwise, other processes cannot open the object if
		/// they request write access. If this flag is not specified, but the object has been opened for write access or has a file mapping
		/// with write access, the function fails.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpSecurityAttributes">
		/// <para>Reserved.</para>
		/// </param>
		/// <param name="dwFlagsAndAttributes">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to a specified file.</para>
		/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>Use the CloseHandle function to close an object handle that <c>OpenFileById</c> returns.</para>
		/// <para>
		/// If you call <c>OpenFileById</c> on a file that is pending deletion as a result of a previous call to DeleteFile, the function
		/// fails. The operating system delays file deletion until all handles to the file are closed. GetLastError returns <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-openfilebyid HANDLE OpenFileById( HANDLE hVolumeHint,
		// LPFILE_ID_DESCRIPTOR lpFileId, DWORD dwDesiredAccess, DWORD dwShareMode, LPSECURITY_ATTRIBUTES lpSecurityAttributes, DWORD
		// dwFlagsAndAttributes );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "caa757a2-fc3f-4883-8d3e-b98d28f92517")]
		public static extern IntPtr OpenFileById(IntPtr hVolumeHint, IntPtr lpFileId, FileAccess dwDesiredAccess, FileShare dwShareMode, ref SECURITY_ATTRIBUTES lpSecurityAttributes, FileFlagsAndAttributes dwFlagsAndAttributes);

		/// <summary>
		/// <para>Decrements the count of power requests of the specified type for a power request object.</para>
		/// </summary>
		/// <param name="PowerRequest">
		/// <para>A handle to a power request object.</para>
		/// </param>
		/// <param name="RequestType">
		/// <para>The power request type to be decremented. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PowerRequestDisplayRequired</term>
		/// <term>The display remains on even if there is no user input for an extended period of time.</term>
		/// </item>
		/// <item>
		/// <term>PowerRequestSystemRequired</term>
		/// <term>The system continues to run instead of entering sleep after a period of user inactivity.</term>
		/// </item>
		/// <item>
		/// <term>PowerRequestAwayModeRequired</term>
		/// <term>
		/// The system enters away mode instead of sleep. In away mode, the system continues to run but turns off audio and video to give the
		/// appearance of sleep.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PowerRequestExecutionRequired</term>
		/// <term>
		/// The calling process continues to run instead of being suspended or terminated by process lifetime management mechanisms. When and
		/// how long the process is allowed to run depends on the operating system and power policy settings. When a
		/// PowerRequestExecutionRequired request is active, it implies PowerRequestSystemRequired. The PowerRequestExecutionRequired request
		/// type can be used only by applications. Services cannot use this request type. Windows 7 and Windows Server 2008 R2: This request
		/// type is supported starting with Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-powerclearrequest BOOL PowerClearRequest( HANDLE
		// PowerRequest, POWER_REQUEST_TYPE RequestType );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "794248b1-5aa8-495e-aca6-1a1f35dc9c7f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PowerClearRequest(IntPtr PowerRequest, POWER_REQUEST_TYPE RequestType);

		/// <summary>
		/// <para>Creates a new power request object.</para>
		/// </summary>
		/// <param name="Context">
		/// <para>Points to a REASON_CONTEXT structure that contains information about the power request.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the power request object.</para>
		/// <para>If the function fails, the return value is INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>When the power request object is no longer needed, use the CloseHandle function to free the handle and clean up the object.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-powercreaterequest HANDLE PowerCreateRequest(
		// PREASON_CONTEXT Context );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "2122bf00-9e6b-48ab-89b0-f53dd6804902")]
		public static extern IntPtr PowerCreateRequest(ref REASON_CONTEXT Context);

		/// <summary>
		/// <para>Increments the count of power requests of the specified type for a power request object.</para>
		/// </summary>
		/// <param name="PowerRequest">
		/// <para>A handle to a power request object.</para>
		/// </param>
		/// <param name="RequestType">
		/// <para>The power request type to be incremented. This parameter can be one of the following values.</para>
		/// <para>PowerRequestDisplayRequired</para>
		/// <para>The display remains on even if there is no user input for an extended period of time.</para>
		/// <para>PowerRequestSystemRequired</para>
		/// <para>The system continues to run instead of entering sleep after a period of user inactivity.</para>
		/// <para>PowerRequestAwayModeRequired</para>
		/// <para>
		/// The system enters away mode instead of sleep in response to explicit action by the user. In away mode, the system continues to
		/// run but turns off audio and video to give the appearance of sleep.
		/// </para>
		/// <para>PowerRequestExecutionRequired</para>
		/// <para>
		/// The calling process continues to run instead of being suspended or terminated by process lifetime management mechanisms. When and
		/// how long the process is allowed to run depends on the operating system and power policy settings.
		/// </para>
		/// <para>On systems not capable of connected standby, an active <c>PowerRequestExecutionRequired</c> request implies <c>PowerRequestSystemRequired</c>.</para>
		/// <para><c>Note</c><c>PowerRequestExecutionRequired</c> is supported starting with Windows 8 and Windows Server 2012.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To conserve power and provide the best user experience, applications that use power requests should follow these best practices:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// When creating a power request, provide a localized text string that describes the reason for the request in the REASON_CONTEXT structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Call <c>PowerSetRequest</c> immediately before the scenario that requires the request.</term>
		/// </item>
		/// <item>
		/// <term>Call PowerClearRequest to decrement the reference count for the request as soon as the scenario is finished.</term>
		/// </item>
		/// <item>
		/// <term>Clean up all request objects and associated handles before the process exits or the service stops.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-powersetrequest BOOL PowerSetRequest( HANDLE PowerRequest,
		// POWER_REQUEST_TYPE RequestType );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "85249de8-5832-4f25-bbd9-3576cfd1caa0")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PowerSetRequest(IntPtr PowerRequest, POWER_REQUEST_TYPE RequestType);

		/// <summary>
		/// <para>Retrieves the full name of the executable image for the specified process.</para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process. This handle must be created with the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION
		/// access right. For more information, see Process Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The name should use the Win32 path format.</term>
		/// </item>
		/// <item>
		/// <term>PROCESS_NAME_NATIVE 0x00000001</term>
		/// <term>The name should use the native system path format.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpExeName">
		/// <para>The path to the executable image. If the function succeeds, this string is null-terminated.</para>
		/// </param>
		/// <param name="lpdwSize">
		/// <para>
		/// On input, specifies the size of the lpExeName buffer, in characters. On success, receives the number of characters written to the
		/// buffer, not including the null-terminating character.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-queryfullprocessimagenamea BOOL
		// QueryFullProcessImageNameA( HANDLE hProcess, DWORD dwFlags, LPSTR lpExeName, PDWORD lpdwSize );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "49a9d1aa-30f3-45ea-a4ec-9f55df692b8b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryFullProcessImageName(IntPtr hProcess, PROCESS_NAME dwFlags, StringBuilder lpExeName, ref uint lpdwSize);

		/// <summary>Determines whether thread profiling is enabled for the specified thread.</summary>
		/// <param name="ThreadHandle">The handle to the thread of interest.</param>
		/// <param name="Enabled">Is <c>TRUE</c> if thread profiling is enabled for the specified thread; otherwise, <c>FALSE</c>.</param>
		/// <returns>Returns ERROR_SUCCESS if the call is successful; otherwise, a system error code (see Winerror.h).</returns>
		// DWORD APIENTRY QueryThreadProfiling( _In_ HANDLE ThreadHandle, _Out_ PBOOLEAN Enabled); https://msdn.microsoft.com/en-us/library/windows/desktop/dd796402(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "dd796402")]
		public static extern Win32Error QueryThreadProfiling(IntPtr ThreadHandle, [MarshalAs(UnmanagedType.U1)] out bool Enabled);

		/// <summary>
		/// <para>Retrieves information about the specified user-mode scheduling (UMS) worker thread.</para>
		/// </summary>
		/// <param name="UmsThread">
		/// <para>A pointer to a UMS thread context.</para>
		/// </param>
		/// <param name="UmsThreadInfoClass">
		/// <para>A UMS_THREAD_INFO_CLASS value that specifies the kind of information to retrieve.</para>
		/// </param>
		/// <param name="UmsThreadInformation">
		/// <para>
		/// A pointer to a buffer to receive the specified information. The required size of this buffer depends on the specified information class.
		/// </para>
		/// <para>If the information class is <c>UmsThreadContext</c> or <c>UmsThreadTeb</c>, the buffer must be .</para>
		/// <para>If the information class is <c>UmsThreadIsSuspended</c> or <c>UmsThreadIsTerminated</c>, the buffer must be .</para>
		/// </param>
		/// <param name="UmsThreadInformationLength">
		/// <para>The size of the UmsThreadInformation buffer, in bytes.</para>
		/// </param>
		/// <param name="ReturnLength">
		/// <para>
		/// A pointer to a ULONG variable. On output, this parameter receives the number of bytes written to the UmsThreadInformation buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible error values
		/// include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INFO_LENGTH_MISMATCH</term>
		/// <term>The buffer is too small for the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_INFO_CLASS</term>
		/// <term>The specified information class is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>QueryUmsThreadInformation</c> function retrieves information about the specified UMS worker thread such as its
		/// application-defined context, its thread execution block (TEB), and whether the thread is suspended or terminated.
		/// </para>
		/// <para>
		/// The underlying structures for UMS worker threads are managed by the system. Information that is not exposed through
		/// <c>QueryUmsThreadInformation</c> should be considered reserved.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-queryumsthreadinformation BOOL QueryUmsThreadInformation(
		// PUMS_CONTEXT UmsThread, UMS_THREAD_INFO_CLASS UmsThreadInfoClass, PVOID UmsThreadInformation, ULONG UmsThreadInformationLength,
		// PULONG ReturnLength );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "5f694edf-ba5e-45a2-a938-5013edddcae2")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryUmsThreadInformation(IntPtr UmsThread, RTL_UMS_THREAD_INFO_CLASS UmsThreadInfoClass, IntPtr UmsThreadInformation, uint UmsThreadInformationLength, out uint ReturnLength);

		/// <summary>Reads the specified profiling data associated with the thread.</summary>
		/// <param name="PerformanceDataHandle">The handle that the <c>EnableThreadProfiling</c> function returned.</param>
		/// <param name="Flags">
		/// <para>
		/// One or more of the following flags that specify the counter data to read. The flags must have been set when you called the
		/// <c>EnableThreadProfiling</c> function.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>READ_THREAD_PROFILING_FLAG_DISPATCHING0x00000001</term>
		/// <term>Get the thread profiling data.</term>
		/// </item>
		/// <item>
		/// <term>READ_THREAD_PROFILING_FLAG_HARDWARE_COUNTERS0x00000002</term>
		/// <term>Get the hardware performance counters data.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="PerformanceData">A <c>PERFORMANCE_DATA</c> structure that contains the thread profiling and hardware counter data.</param>
		/// <returns>Returns ERROR_SUCCESS if the call is successful; otherwise, a system error code (see Winerror.h).</returns>
		// DWORD APIENTRY ReadThreadProfilingData( _In_ HANDLE PerformanceDataHandle, _In_ DWORD Flags, _Out_ PPERFORMANCE_DATA
		// PerformanceData); https://msdn.microsoft.com/en-us/library/windows/desktop/dd796403(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "dd796403")]
		public static extern Win32Error ReadThreadProfilingData(IntPtr PerformanceDataHandle, uint Flags, out PERFORMANCE_DATA PerformanceData);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Deletes an existing empty directory as a transacted operation.</para>
		/// </summary>
		/// <param name="lpPathName">
		/// <para>
		/// The path of the directory to be removed. The path must specify an empty directory, and the calling process must have delete
		/// access to the directory.
		/// </para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see Naming a File.
		/// </para>
		/// <para>The directory must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>RemoveDirectoryTransacted</c> function marks a directory for deletion on close. Therefore, the directory is not removed
		/// until the last handle to the directory is closed.
		/// </para>
		/// <para>
		/// RemoveDirectory removes a directory junction, even if the contents of the target are not empty; the function removes directory
		/// junctions regardless of the state of the target object.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF .</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-removedirectorytransacteda BOOL
		// RemoveDirectoryTransactedA( LPCSTR lpPathName, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "e8600166-62dc-4398-9e16-43b07f7f0b89")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RemoveDirectoryTransacted(string lpPathName, IntPtr hTransaction);

		/// <summary>
		/// <para>Unregisters a callback function that was previously registered with the AddSecureMemoryCacheCallback function.</para>
		/// </summary>
		/// <param name="pfnCallBack">
		/// <para>A pointer to the application-defined SecureMemoryCacheCallback function to remove.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later. For more information, see Using the
		/// Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-removesecurememorycachecallback BOOL
		// RemoveSecureMemoryCacheCallback( PSECURE_MEMORY_CACHE_CALLBACK pfnCallBack );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "8be6ff04-34c7-4942-a38c-507584c8bbeb")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RemoveSecureMemoryCacheCallback(PsecureMemoryCacheCallback pfnCallBack);

		/// <summary>
		/// <para>Reopens the specified file system object with different access rights, sharing mode, and flags.</para>
		/// </summary>
		/// <param name="hOriginalFile">
		/// <para>A handle to the object to be reopened. The object must have been created by the CreateFile function.</para>
		/// </param>
		/// <param name="dwDesiredAccess">
		/// <para>
		/// The required access to the object. For a list of values, see File Security and Access Rights. You cannot request an access mode
		/// that conflicts with the sharing mode specified in a previous open request whose handle is still open.
		/// </para>
		/// <para>
		/// If this parameter is zero (0), the application can query device attributes without accessing the device. This is useful if an
		/// application wants to determine the size of a floppy disk drive and the formats it supports without requiring a floppy in the drive.
		/// </para>
		/// </param>
		/// <param name="dwShareMode">
		/// <para>
		/// The sharing mode of the object. You cannot request a sharing mode that conflicts with the access mode specified in a previous
		/// open request whose handle is still open.
		/// </para>
		/// <para>
		/// If this parameter is zero (0) and CreateFile succeeds, the object cannot be shared and cannot be opened again until the handle is closed.
		/// </para>
		/// <para>
		/// To enable other processes to share the object while your process has it open, use a combination of one or more of the following
		/// values to specify the type of access they can request when they open the object. These sharing options remain in effect until you
		/// close the handle to the object.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_SHARE_DELETE 0x00000004</term>
		/// <term>
		/// Enables subsequent open operations on the object to request delete access. Otherwise, other processes cannot open the object if
		/// they request delete access. If the object has already been opened with delete access, the sharing mode must include this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_SHARE_READ 0x00000001</term>
		/// <term>
		/// Enables subsequent open operations on the object to request read access. Otherwise, other processes cannot open the object if
		/// they request read access. If the object has already been opened with read access, the sharing mode must include this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_SHARE_WRITE 0x00000002</term>
		/// <term>
		/// Enables subsequent open operations on the object to request write access. Otherwise, other processes cannot open the object if
		/// they request write access. If the object has already been opened with write access, the sharing mode must include this flag.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFlagsAndAttributes">
		/// <para>TBD</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the specified file.</para>
		/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The dwFlags parameter cannot contain any of the file attribute flags ( <c>FILE_ATTRIBUTE_*</c>). These can only be specified when
		/// the file is created.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-reopenfile HANDLE ReOpenFile( HANDLE hOriginalFile, DWORD
		// dwDesiredAccess, DWORD dwShareMode, DWORD dwFlagsAndAttributes );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "56d8a4b1-e3b5-4134-8d21-bf40761e9dcc")]
		public static extern SafeFileHandle ReOpenFile(IntPtr hOriginalFile, FileAccess dwDesiredAccess, FileShare dwShareMode, FileFlagsAndAttributes dwFlagsAndAttributes);

		/// <summary>
		/// <para>
		/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
		/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available in
		/// future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
		/// Transactional NTFS.]
		/// </para>
		/// <para>Sets the attributes for a file or directory as a transacted operation.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>The name of the file whose attributes are to be set.</para>
		/// <para>
		/// In the ANSI version of this function, the name is limited to <c>MAX_PATH</c> characters. To extend this limit to 32,767 wide
		/// characters, call the Unicode version of the function and prepend "\?" to the path. For more information, see File Names, Paths,
		/// and Namespaces.
		/// </para>
		/// <para>The file must reside on the local computer; otherwise, the function fails and the last error code is set to <c>ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</c>.</para>
		/// </param>
		/// <param name="dwFileAttributes">
		/// <para>The file attributes to set for the file.</para>
		/// <para>
		/// For a list of file attribute value and their descriptions, see File Attribute Constants. This parameter can be one or more
		/// values, combined using the bitwise-OR operator. However, all other values override <c>FILE_ATTRIBUTE_NORMAL</c>.
		/// </para>
		/// <para>Not all attributes are supported by this function. For more information, see the Remarks section.</para>
		/// <para>The following is a list of supported attribute values.</para>
		/// <para>FILE_ATTRIBUTE_ARCHIVE (32 (0x20))</para>
		/// <para>FILE_ATTRIBUTE_HIDDEN (2 (0x2))</para>
		/// <para>FILE_ATTRIBUTE_NORMAL (128 (0x80))</para>
		/// <para>FILE_ATTRIBUTE_NOT_CONTENT_INDEXED (8192 (0x2000))</para>
		/// <para>FILE_ATTRIBUTE_OFFLINE (4096 (0x1000))</para>
		/// <para>FILE_ATTRIBUTE_READONLY (1 (0x1))</para>
		/// <para>FILE_ATTRIBUTE_SYSTEM (4 (0x4))</para>
		/// <para>FILE_ATTRIBUTE_TEMPORARY (256 (0x100))</para>
		/// </param>
		/// <param name="hTransaction">
		/// <para>A handle to the transaction. This handle is returned by the CreateTransaction function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The following table describes how to set the attributes that cannot be set using <c>SetFileAttributesTransacted</c>. Note that
		/// these are not transacted operations.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>How to Set</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_ATTRIBUTE_COMPRESSED 0x800</term>
		/// <term>To set a file's compression state, use the DeviceIoControl function with the FSCTL_SET_COMPRESSION operation.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_DEVICE 0x40</term>
		/// <term>Reserved; do not use.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_DIRECTORY 0x10</term>
		/// <term>Files cannot be converted into directories. To create a directory, use the CreateDirectory or CreateDirectoryEx function.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_ENCRYPTED 0x4000</term>
		/// <term>
		/// To create an encrypted file, use the CreateFile function with the FILE_ATTRIBUTE_ENCRYPTED attribute. To convert an existing file
		/// into an encrypted file, use the EncryptFile function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_REPARSE_POINT 0x400</term>
		/// <term>
		/// To associate a reparse point with a file or directory, use the DeviceIoControl function with the FSCTL_SET_REPARSE_POINT operation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_SPARSE_FILE 0x200</term>
		/// <term>To set a file's sparse attribute, use the DeviceIoControl function with the FSCTL_SET_SPARSE operation.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If a file is open for modification in a transaction, no other thread can successfully open the file for modification until the
		/// transaction is committed. If a transacted thread opens the file first, any subsequent threads that attempt to open the file for
		/// modification before the transaction is committed will receive a sharing violation. If a non-transacted thread opens the file for
		/// modification before the transacted thread does, and it is still open when the transacted thread attempts to open it, the
		/// transaction will receive the <c>ERROR_TRANSACTIONAL_CONFLICT</c> error.
		/// </para>
		/// <para>For more information on transactions, see Transactional NTFS.</para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>SMB 3.0 does not support TxF.</para>
		/// <para>Transacted Operations</para>
		/// <para>
		/// If a file is open for modification in a transaction, no other thread can open the file for modification until the transaction is
		/// committed. So if a transacted thread opens the file first, any subsequent threads that try modifying the file before the
		/// transaction is committed receives a sharing violation. If a non-transacted thread modifies the file before the transacted thread
		/// does, and the file is still open when the transaction attempts to open it, the transaction receives the error <c>ERROR_TRANSACTIONAL_CONFLICT</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-setfileattributestransacteda BOOL
		// SetFileAttributesTransactedA( LPCSTR lpFileName, DWORD dwFileAttributes, HANDLE hTransaction );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "e25e77b2-a6ad-4ce4-8589-d7ff6c4074f6")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetFileAttributesTransacted(string lpFileName, FileFlagsAndAttributes dwFileAttributes, IntPtr hTransaction);

		/// <summary>
		/// <para>
		/// Requests that bandwidth for the specified file stream be reserved. The reservation is specified as a number of bytes in a period
		/// of milliseconds for I/O requests on the specified file handle.
		/// </para>
		/// </summary>
		/// <param name="hFile">
		/// <para>A handle to the file.</para>
		/// </param>
		/// <param name="nPeriodMilliseconds">
		/// <para>
		/// The period of the reservation, in milliseconds. The period is the time from which the I/O is issued to the kernel until the time
		/// the I/O should be completed. The minimum supported value for the file stream can be determined by looking at the value returned
		/// through the lpPeriodMilliseconds parameter to the GetFileBandwidthReservation function, on a handle that has not had a bandwidth
		/// reservation set.
		/// </para>
		/// </param>
		/// <param name="nBytesPerPeriod">
		/// <para>
		/// The bandwidth to reserve, in bytes per period. The maximum supported value for the file stream can be determined by looking at
		/// the value returned through the lpBytesPerPeriod parameter to the GetFileBandwidthReservation function, on a handle that has not
		/// had a bandwidth reservation set.
		/// </para>
		/// </param>
		/// <param name="bDiscardable">
		/// <para>
		/// Indicates whether I/O should be completed with an error if a driver is unable to satisfy an I/O operation before the period
		/// expires. If one of the drivers for the specified file stream does not support this functionality, this function may return
		/// success and ignore the flag. To verify whether the setting will be honored, call the GetFileBandwidthReservation function using
		/// the same hFile handle and examine the *pDiscardable return value.
		/// </para>
		/// </param>
		/// <param name="lpTransferSize">
		/// <para>
		/// A pointer to a variable that receives the minimum size of any individual I/O request that may be issued by the application. All
		/// I/O requests should be multiples of TransferSize.
		/// </para>
		/// </param>
		/// <param name="lpNumOutstandingRequests">
		/// <para>
		/// A pointer to a variable that receives the number of TransferSize chunks the application should allow to be outstanding with the
		/// operating system. This allows the storage stack to keep the device busy and allows maximum throughput.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Returns nonzero if successful or zero otherwise.</para>
		/// <para>
		/// A reservation can fail if there is not enough bandwidth available on the volume because of existing reservations; in this case
		/// <c>ERROR_NO_SYSTEM_RESOURCES</c> is returned.
		/// </para>
		/// <para>To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The requested bandwidth reservation must be greater than or equal to one packet per period. The minimum period, in milliseconds,
		/// maximum bytes per period, and minimum transfer size, in bytes, for a specific volume are returned through the
		/// lpPeriodMilliseconds, lpBytesPerPeriod, and lpTransferSize parameters to GetFileBandwidthReservation on a handle that has not
		/// been used in a call to <c>SetFileBandwidthReservation</c>. In other words:
		/// </para>
		/// <para>1 ≤ (nBytesPerPeriod)×(lpPeriodMilliseconds)/(lpTransferSize)/(nPeriodMilliseconds)</para>
		/// <para>IIn Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-setfilebandwidthreservation BOOL
		// SetFileBandwidthReservation( HANDLE hFile, DWORD nPeriodMilliseconds, DWORD nBytesPerPeriod, BOOL bDiscardable, LPDWORD
		// lpTransferSize, LPDWORD lpNumOutstandingRequests );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "a22bd8f3-4fbf-4f77-b8b6-7e786942615a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetFileBandwidthReservation(SafeFileHandle hFile, uint nPeriodMilliseconds, uint nBytesPerPeriod, [MarshalAs(UnmanagedType.Bool)] bool bDiscardable, out uint lpTransferSize, out uint lpNumOutstandingRequests);

		/// <summary>
		/// <para>
		/// Sets the notification modes for a file handle, allowing you to specify how completion notifications work for the specified file.
		/// </para>
		/// </summary>
		/// <param name="FileHandle">
		/// <para>A handle to the file.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>
		/// The modes to be set. One or more modes can be set at the same time; however, after a mode has been set for a file handle, it
		/// cannot be removed.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_SKIP_COMPLETION_PORT_ON_SUCCESS 0x1</term>
		/// <term>
		/// If the following three conditions are true, the I/O Manager does not queue a completion entry to the port, when it would
		/// ordinarily do so. The conditions are: When the FileHandle parameter is a socket, this mode is only compatible with Layered
		/// Service Providers (LSP) that return Installable File Systems (IFS) handles. To detect whether a non-IFS LSP is installed, use the
		/// WSAEnumProtocols function and examine the dwServiceFlag1 member in each returned WSAPROTOCOL_INFO structure. If the
		/// XP1_IFS_HANDLES (0x20000) bit is cleared then the specified LSP is not an IFS LSP. Vendors that have non-IFS LSPs are encouraged
		/// to migrate to the Windows Filtering Platform (WFP).
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_SKIP_SET_EVENT_ON_HANDLE 0x2</term>
		/// <term>
		/// The I/O Manager does not set the event for the file object if a request returns with a success code, or the error returned is
		/// ERROR_PENDING and the function that is called is not a synchronous function. If an explicit event is provided for the request, it
		/// is still signaled.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns nonzero if successful or zero otherwise.</para>
		/// <para>To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To compile an application that uses this function, define the <c>_WIN32_WINNT</c> macro as 0x0600 or later. For more information,
		/// see Using the Windows Headers.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-setfilecompletionnotificationmodes BOOL
		// SetFileCompletionNotificationModes( HANDLE FileHandle, UCHAR Flags );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "23796484-ee47-4f80-856d-5a5d5635547c")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetFileCompletionNotificationModes(SafeFileHandle FileHandle, FILE_NOTIFICATION_MODE Flags);

		/// <summary>
		/// <para>
		/// Sets the value of the specified firmware environment variable as the attributes that indicate how this variable is stored and maintained.
		/// </para>
		/// </summary>
		/// <param name="lpName">
		/// <para>The name of the firmware environment variable. The pointer must not be <c>NULL</c>.</para>
		/// </param>
		/// <param name="lpGuid">
		/// <para>
		/// The GUID that represents the namespace of the firmware environment variable. The GUID must be a string in the format
		/// "{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}". If the system does not support GUID-based namespaces, this parameter is ignored. The
		/// pointer must not be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pValue">
		/// <para>A pointer to the new value for the firmware environment variable.</para>
		/// </param>
		/// <param name="nSize">
		/// <para>
		/// The size of the pValue buffer, in bytes. Unless the VARIABLE_ATTRIBUTE_APPEND_WRITE,
		/// VARIABLE_ATTRIBUTE_AUTHENTICATED_WRITE_ACCESS, or VARIABLE_ATTRIBUTE_TIME_BASED_AUTHENTICATED_WRITE_ACCESS variable attribute is
		/// set via dwAttributes, setting this value to zero will result in the deletion of this variable.
		/// </para>
		/// </param>
		/// <param name="dwAttributes">
		/// <para>Bitmask to set UEFI variable attributes associated with the variable. See also UEFI Spec 2.3.1, Section 7.2.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>VARIABLE_ATTRIBUTE_NON_VOLATILE 0x00000001</term>
		/// <term>The firmware environment variable is stored in non-volatile memory (e.g. NVRAM).</term>
		/// </item>
		/// <item>
		/// <term>VARIABLE_ATTRIBUTE_BOOTSERVICE_ACCESS 0x00000002</term>
		/// <term>The firmware environment variable can be accessed during boot service.</term>
		/// </item>
		/// <item>
		/// <term>VARIABLE_ATTRIBUTE_RUNTIME_ACCESS 0x00000004</term>
		/// <term>The firmware environment variable can be accessed at runtime.</term>
		/// </item>
		/// <item>
		/// <term>VARIABLE_ATTRIBUTE_HARDWARE_ERROR_RECORD 0x00000008</term>
		/// <term>Indicates hardware related errors encountered at runtime.</term>
		/// </item>
		/// <item>
		/// <term>VARIABLE_ATTRIBUTE_AUTHENTICATED_WRITE_ACCESS 0x00000010</term>
		/// <term>
		/// Indicates an authentication requirement that must be met before writing to this firmware environment variable. For more
		/// information see, UEFI spec 2.3.1.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VARIABLE_ATTRIBUTE_TIME_BASED_AUTHENTICATED_WRITE_ACCESS 0x00000020</term>
		/// <term>
		/// Indicates authentication and time stamp requirements that must be met before writing to this firmware environment variable. When
		/// this attribute is set, the buffer, represented by pValue, will begin with an instance of a complete (and serialized)
		/// EFI_VARIABLE_AUTHENTICATION_2 descriptor. For more information see, UEFI spec 2.3.1.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VARIABLE_ATTRIBUTE_APPEND_WRITE 0x00000040</term>
		/// <term>
		/// Append an existing environment variable with the value of pValue. If the firmware does not support the operation, then
		/// SetFirmwareEnvironmentVariableEx will return ERROR_INVALID_FUNCTION.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible error codes
		/// include ERROR_INVALID_FUNCTION.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Starting with Windows 10, version 1803, Universal Windows apps can read and write UEFI firmware variables. See Access UEFI
		/// firmware variables from a Universal Windows Appfor details.
		/// </para>
		/// <para>
		/// Starting with Windows 10, version 1803, reading UEFI firmware variables is also supported from User-Mode Driver Framework (UMDF)
		/// drivers. Writing UEFI firmware variables from UMDF drivers is not supported.
		/// </para>
		/// <para>
		/// To write a firmware environment variable, the user account that the app is running under must have the SE_SYSTEM_ENVIRONMENT_NAME
		/// privilege. A Universal Windows app must be run from an administrator account and follow the requirements outlined in Access UEFI
		/// firmware variables from a Universal Windows App.
		/// </para>
		/// <para>The correct method of changing the attributes of a variable is to delete the variable and recreate it with different attributes.</para>
		/// <para>
		/// The exact set of firmware environment variables is determined by the boot firmware. The location of these environment variables
		/// is also specified by the firmware. For example, on a UEFI-based system, NVRAM contains firmware environment variables that
		/// specify system boot settings. For information about specific variables used, see the UEFI specification. For more information
		/// about UEFI and Windows, see UEFI and Windows.
		/// </para>
		/// <para>
		/// Firmware variables are not supported on a legacy BIOS-based system. The <c>SetFirmwareEnvironmentVariableEx</c> function will
		/// always fail on a legacy BIOS-based system, or if Windows was installed using legacy BIOS on a system that supports both legacy
		/// BIOS and UEFI. To identify these conditions, call the function with a dummy firmware environment name such as an empty string
		/// ("") for the lpName parameter and a dummy GUID such as "{00000000-0000-0000-0000-000000000000}" for the lpGuid parameter. On a
		/// legacy BIOS-based system, or on a system that supports both legacy BIOS and UEFI where Windows was installed using legacy BIOS,
		/// the function will fail with ERROR_INVALID_FUNCTION. On a UEFI-based system, the function will fail with an error specific to the
		/// firmware, such as ERROR_NOACCESS, to indicate that the dummy GUID namespace does not exist.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-setfirmwareenvironmentvariableexa BOOL
		// SetFirmwareEnvironmentVariableExA( LPCSTR lpName, LPCSTR lpGuid, PVOID pValue, DWORD nSize, DWORD dwAttributes );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "D3C2F03F-66F6-40A4-830E-058BBA925ACD")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetFirmwareEnvironmentVariableEx(string lpName, string lpGuid, IntPtr pValue, uint nSize, VARIABLE_ATTRIBUTE dwAttributes);

		/// <summary>
		/// <para>Changes data execution prevention (DEP) and DEP-ATL thunk emulation settings for a 32-bit process.</para>
		/// </summary>
		/// <param name="dwFlags">
		/// <para>A <c>DWORD</c> that can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// If the DEP system policy is OptIn or OptOut and DEP is enabled for the process, setting dwFlags to 0 disables DEP for the process.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROCESS_DEP_ENABLE 0x00000001</term>
		/// <term>
		/// Enables DEP permanently on the current process. After DEP has been enabled for the process by setting PROCESS_DEP_ENABLE, it
		/// cannot be disabled for the life of the process.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROCESS_DEP_DISABLE_ATL_THUNK_EMULATION 0x00000002</term>
		/// <term>
		/// Disables DEP-ATL thunk emulation for the current process, which prevents the system from intercepting NX faults that originate
		/// from the Active Template Library (ATL) thunk layer. For more information, see the Remarks section. This flag can be specified
		/// only with PROCESS_DEP_ENABLE.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>. To retrieve error values defined for this function, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SetProcessDEPPolicy</c> function overrides the system DEP policy for the current process unless its DEP policy was
		/// specified at process creation. The system DEP policy setting must be OptIn or OptOut. If the system DEP policy is AlwaysOff or
		/// AlwaysOn, <c>SetProcessDEPPolicy</c> returns an error. After DEP is enabled for a process, subsequent calls to
		/// <c>SetProcessDEPPolicy</c> are ignored.
		/// </para>
		/// <para>
		/// DEP policy specified at process creation with the PROC_THREAD_ATTRIBUTE_MITIGATION_POLICY attribute cannot be changed for the
		/// life of the process. In this case, calls to <c>SetProcessDEPPolicy</c> fail with <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>
		/// <c>SetProcessDEPPolicy</c> is supported for 32-bit processes only. If this function is called on a 64-bit process, it fails with <c>ERROR_NOT_SUPPORTED</c>.
		/// </para>
		/// <para>
		/// Applications written to ATL 7.1 and earlier can attempt to execute code on pages marked as non-executable, which triggers an NX
		/// fault and terminates the application. DEP-ATL thunk emulation allows an application that would otherwise trigger an NX fault to
		/// run with DEP enabled. For information about ATL versions, see ATL and MFC Version Numbers.
		/// </para>
		/// <para>
		/// If DEP-ATL thunk emulation is enabled, the system intercepts NX faults, emulates the instructions, and handles the exceptions so
		/// the application can continue to run. If DEP-ATL thunk emulation is disabled by setting
		/// <c>PROCESS_DEP_DISABLE_ATL_THUNK_EMULATION</c> for the process, NX faults are not intercepted, which is useful when testing
		/// applications for compatibility with DEP.
		/// </para>
		/// <para>
		/// The following table summarizes the interactions between system DEP policy, DEP-ATL thunk emulation, and
		/// <c>SetProcessDEPPolicy</c>. To get the system DEP policy setting, use the GetSystemDEPPolicy function.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>System DEP policy</term>
		/// <term>DEP behavior</term>
		/// <term>DEP_ATL thunk emulation behavior</term>
		/// <term>SetProcessDEPPolicy behavior</term>
		/// </listheader>
		/// <item>
		/// <term>AlwaysOff 0</term>
		/// <term>Disabled for the operating system and all processes.</term>
		/// <term>Not applicable.</term>
		/// <term>Returns an error.</term>
		/// </item>
		/// <item>
		/// <term>AlwaysOn 1</term>
		/// <term>Enabled for the operating system and all processes.</term>
		/// <term>Disabled.</term>
		/// <term>Returns an error.</term>
		/// </item>
		/// <item>
		/// <term>OptIn 2 Default configuration for Windows client versions.</term>
		/// <term>
		/// Enabled for the operating system and disabled for nonsystem processes. Administrators can explicitly enable DEP for selected
		/// executable files.
		/// </term>
		/// <term>Not applicable.</term>
		/// <term>
		/// DEP can be enabled for the current process. If DEP is enabled for the current process, DEP-ATL thunk emulation can be disabled
		/// for that process.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OptOut 3 Default configuration for Windows Server versions.</term>
		/// <term>
		/// Enabled for the operating system and all processes. Administrators can explicitly disable DEP for selected executable files.
		/// </term>
		/// <term>Enabled.</term>
		/// <term>
		/// DEP can be disabled for the current process. If DEP is disabled for the current process, DEP-ATL thunk emulation is automatically
		/// disabled for that process.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// To compile an application that calls this function, define <c>_WIN32_WINNT</c> as 0x0600 or later. For more information, see
		/// Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-setprocessdeppolicy BOOL SetProcessDEPPolicy( DWORD
		// dwFlags );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "17c9f522-fd64-4061-9212-8fc91cc96b18")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetProcessDEPPolicy(PROCESS_DEP dwFlags);

		/// <summary>
		/// <para>Sets the per-process mode that the SearchPath function uses when locating files.</para>
		/// </summary>
		/// <param name="Flags">
		/// <para>The search mode to use.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>BASE_SEARCH_PATH_ENABLE_SAFE_SEARCHMODE 0x00000001</term>
		/// <term>Enable safe process search mode for the process.</term>
		/// </item>
		/// <item>
		/// <term>BASE_SEARCH_PATH_DISABLE_SAFE_SEARCHMODE 0x00010000</term>
		/// <term>Disable safe process search mode for the process.</term>
		/// </item>
		/// <item>
		/// <term>BASE_SEARCH_PATH_PERMANENT 0x00008000</term>
		/// <term>
		/// Optional flag to use in combination with BASE_SEARCH_PATH_ENABLE_SAFE_SEARCHMODE to make this mode permanent for this process.
		/// This is done by bitwise OR operation: This flag cannot be combined with the BASE_SEARCH_PATH_DISABLE_SAFE_SEARCHMODE flag.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the operation completes successfully, the <c>SetSearchPathMode</c> function returns a nonzero value.</para>
		/// <para>
		/// If the operation fails, the <c>SetSearchPathMode</c> function returns zero. To get extended error information, call the
		/// GetLastError function.
		/// </para>
		/// <para>
		/// If the <c>SetSearchPathMode</c> function fails because a parameter value is not valid, the value returned by the GetLastError
		/// function will be <c>ERROR_INVALID_PARAMETER</c>.
		/// </para>
		/// <para>
		/// If the <c>SetSearchPathMode</c> function fails because the combination of current state and parameter value is not valid, the
		/// value returned by the GetLastError function will be <c>ERROR_ACCESS_DENIED</c>. For more information, see the Remarks section.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the <c>SetSearchPathMode</c> function has not been successfully called for the current process, the search mode used by the
		/// SearchPath function is obtained from the system registry. For more information, see SearchPath.
		/// </para>
		/// <para>
		/// After the <c>SetSearchPathMode</c> function has been successfully called for the current process, the setting in the system
		/// registry is ignored in favor of the mode most recently set successfully.
		/// </para>
		/// <para>
		/// If the <c>SetSearchPathMode</c> function has been successfully called for the current process with Flags set to , safe mode is
		/// set permanently for the calling process. Any subsequent calls to the <c>SetSearchPathMode</c> function from within that process
		/// that attempt to change the search mode will fail with <c>ERROR_ACCESS_DENIED</c> from the GetLastError function.
		/// </para>
		/// <para>
		/// <c>Note</c> Because setting safe search mode permanently cannot be disabled for the life of the process for which is was set, it
		/// should be used with careful consideration. This is particularly true for DLL development, where the user of the DLL will be
		/// affected by this process-wide setting.
		/// </para>
		/// <para>It is not possible to permanently disable safe search mode.</para>
		/// <para>This function does not modify the system registry.</para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-setsearchpathmode BOOL SetSearchPathMode( DWORD Flags );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "1874933d-92c3-4945-a3e4-e6dede232d5e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetSearchPathMode(BASE_SEARCH_PATH Flags);

		/// <summary>
		/// <para>Sets application-specific context information for the specified user-mode scheduling (UMS) worker thread.</para>
		/// </summary>
		/// <param name="UmsThread">
		/// <para>A pointer to a UMS thread context.</para>
		/// </param>
		/// <param name="UmsThreadInfoClass">
		/// <para>A UMS_THREAD_INFO_CLASS value that specifies the kind of information to set. This parameter must be <c>UmsThreadUserContext</c>.</para>
		/// </param>
		/// <param name="UmsThreadInformation">
		/// <para>A pointer to a buffer that contains the information to set.</para>
		/// </param>
		/// <param name="UmsThreadInformationLength">
		/// <para>The size of the UmsThreadInformation buffer, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible error values
		/// include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INFO_LENGTH_MISMATCH</term>
		/// <term>The buffer size does not match the required size for the specified information class.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_INFO_CLASS</term>
		/// <term>The UmsThreadInfoClass parameter specifies an information class that is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SetUmsThreadInformation</c> function can be used to set an application-defined context for the specified UMS worker
		/// thread. The context information can consist of anything the application might find useful to track, such as per-scheduler or
		/// per-worker thread state. The underlying structures for UMS worker threads are managed by the system and should not be modified directly.
		/// </para>
		/// <para>
		/// The QueryUmsThreadInformation function can be used to retrieve other exposed information about the specified thread, such as its
		/// thread execution block (TEB) and whether the thread is suspended or terminated. Information that is not exposed through
		/// <c>QueryUmsThreadInformation</c> should be considered reserved.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-setumsthreadinformation BOOL SetUmsThreadInformation(
		// PUMS_CONTEXT UmsThread, UMS_THREAD_INFO_CLASS UmsThreadInfoClass, PVOID UmsThreadInformation, ULONG UmsThreadInformationLength );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "19f190fd-1f78-4bb6-93eb-73a5c522b44d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetUmsThreadInformation(IntPtr UmsThread, UMS_THREAD_INFO_CLASS UmsThreadInfoClass, IntPtr UmsThreadInformation, uint UmsThreadInformationLength);

		/// <summary>
		/// <para>Sets the mask of XState features set within a CONTEXT structure.</para>
		/// </summary>
		/// <param name="Context">
		/// <para>A pointer to a CONTEXT structure that has been initialized with InitializeContext.</para>
		/// </param>
		/// <param name="FeatureMask">
		/// <para>A mask of XState features to set in the specified CONTEXT structure.</para>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>TRUE</c> if successful, otherwise <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SetXStateFeaturesMask</c> function sets the mask of valid features in the specified context. Before calling
		/// GetThreadContext, Wow64GetThreadContext, SetThreadContext, or Wow64SetThreadContext the application must call
		/// <c>SetXStateFeaturesMask</c> to specify which set of features to retrieve or set. The system silently ignores any feature
		/// specified in the FeatureMask which is not enabled on the processor.
		/// </para>
		/// <para>
		/// <c>Windows 7 with SP1 and Windows Server 2008 R2 with SP1:</c> The AVX API is first implemented on Windows 7 with SP1 and Windows
		/// Server 2008 R2 with SP1 . Since there is no SDK for SP1, that means there are no available headers and library files to work
		/// with. In this situation, a caller must declare the needed functions from this documentation and get pointers to them using
		/// GetModuleHandle on "Kernel32.dll", followed by calls to GetProcAddress. See Working with XState Context for details.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-setxstatefeaturesmask BOOL SetXStateFeaturesMask( PCONTEXT
		// Context, DWORD64 FeatureMask );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "64ADEA8A-DE78-437E-AE68-A68E7214C5FD")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetXStateFeaturesMask(IntPtr Context, ulong FeatureMask);

		/// <summary>
		/// <para>[This function is not supported and should not be used. It may change or disappear completely without advance notice.]</para>
		/// <para>Determines whether the Terminal Server is in the INSTALL mode.</para>
		/// </summary>
		/// <returns>
		/// <para>This function returns <c>TRUE</c> if the Terminal Server is in INSTALL mode and <c>FALSE</c> if it is in EXECUTE mode.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/devnotes/termsrvappinstallmode BOOL TermsrvAppInstallMode(void);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("", MSDNShortId = "edf362e6-c1a4-49fe-8e07-1188c66616be")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TermsrvAppInstallMode();

		/// <summary>
		/// <para>Yields control to the user-mode scheduling (UMS) scheduler thread on which the calling UMS worker thread is running.</para>
		/// </summary>
		/// <param name="SchedulerParam">
		/// <para>A parameter to pass to the scheduler thread's UmsSchedulerProc function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A UMS worker thread calls the <c>UmsThreadYield</c> function to cooperatively yield control to the UMS scheduler thread on which
		/// the worker thread is running. If a UMS worker thread never calls <c>UmsThreadYield</c>, the worker thread runs until it either
		/// blocks or is terminated.
		/// </para>
		/// <para>
		/// When control switches to the UMS scheduler thread, the system calls the associated scheduler entry point function with the reason
		/// <c>UmsSchedulerThreadYield</c> and the ScheduleParam parameter specified by the worker thread in the <c>UmsThreadYield</c> call.
		/// </para>
		/// <para>The application's scheduler is responsible for rescheduling the worker thread.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-umsthreadyield BOOL UmsThreadYield( PVOID SchedulerParam );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "d7c94ed5-9536-4c39-8658-27e4237cc9ba")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UmsThreadYield(IntPtr SchedulerParam);

		/// <summary>
		/// <para>Enables or disables file system redirection for the calling thread.</para>
		/// <para>
		/// This function may not work reliably when there are nested calls. Therefore, this function has been replaced by the
		/// Wow64DisableWow64FsRedirection and Wow64RevertWow64FsRedirection functions.
		/// </para>
		/// <para>
		/// <c>Note</c> These two methods of controlling file system redirection cannot be combined in any way. Do not use the
		/// <c>Wow64EnableWow64FsRedirection</c> function with either the Wow64DisableWow64FsRedirection or the Wow64RevertWow64FsRedirection function.
		/// </para>
		/// </summary>
		/// <param name="Wow64FsEnableRedirection">
		/// <para>
		/// Indicates the type of request for WOW64 system folder redirection. If <c>TRUE</c>, requests redirection be enabled; if
		/// <c>FALSE</c>, requests redirection be disabled.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Boolean value indicating whether the function succeeded. If <c>TRUE</c>, the function succeeded; if <c>FALSE</c>, the function failed.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is useful for 32-bit applications that want to gain access to the native system32 directory. By default, WOW64 file
		/// system redirection is enabled.
		/// </para>
		/// <para>
		/// <c>Note</c> The <c>Wow64EnableWow64FsRedirection</c> function affects all file operations performed by the current thread, which
		/// can have unintended consequences if file system redirection is disabled for any length of time. For example, DLL loading depends
		/// on file system redirection, so disabling file system redirection will cause DLL loading to fail. Also, many feature
		/// implementations use delayed loading and will fail while redirection is disabled. The failure state of the initial delay-load
		/// operation is persisted, so any subsequent use of the delay-load function will fail even after file system redirection is
		/// re-enabled. To avoid these problems, disable file system redirection immediately before calls to specific file I/O functions
		/// (such as CreateFile) that must not be redirected, and re-enable file system redirection immediately afterward using .
		/// </para>
		/// <para>
		/// File redirection is enabled or disabled only for the thread calling this function. This affects only operations made by the
		/// current thread. Some functions, such as CreateProcessAsUser, do their work on another thread, which is not affected by the state
		/// of file system redirection in the calling thread.
		/// </para>
		/// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-wow64enablewow64fsredirection BOOLEAN
		// Wow64EnableWow64FsRedirection( BOOLEAN Wow64FsEnableRedirection );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "8d11a7ba-540d-4bd0-881a-a61605357dd8")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool Wow64EnableWow64FsRedirection([MarshalAs(UnmanagedType.U1)] bool Wow64FsEnableRedirection);

		/// <summary>
		/// <para>Retrieves the context of the specified WOW64 thread.</para>
		/// </summary>
		/// <param name="hThread">
		/// <para>
		/// A handle to the thread whose context is to be retrieved. The handle must have <c>THREAD_GET_CONTEXT</c> access to the thread. For
		/// more information, see Thread Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="lpContext">
		/// <para>A WOW64_CONTEXT structure. The caller must initialize the <c>ContextFlags</c> member of this structure.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is used to retrieve the thread context of the specified thread. The function retrieves a selective context based on
		/// the value of the <c>ContextFlags</c> member of the context structure. The thread identified by the hThread parameter is typically
		/// being debugged, but the function can also operate when the thread is not being debugged.
		/// </para>
		/// <para>
		/// You cannot get a valid context for a running thread. Use the Wow64SuspendThread function to suspend the thread before calling <c>Wow64GetThreadContext</c>.
		/// </para>
		/// <para>
		/// If you call <c>Wow64GetThreadContext</c> for the current thread, the function returns successfully; however, the context returned
		/// is not valid.
		/// </para>
		/// <para>
		/// This function is intended for 64-bit applications. It is not supported on 32-bit Windows; such calls fail and set the last error
		/// code to <c>ERROR_INVALID_FUNCTION</c>. A 32-bit application can call this function on a WOW64 thread; the result is the same as
		/// calling the GetThreadContext function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-wow64getthreadcontext BOOL Wow64GetThreadContext( HANDLE
		// hThread, PWOW64_CONTEXT lpContext );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "1bac28e1-3558-43c4-97e4-d8bb9514c38e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Wow64GetThreadContext(IntPtr hThread, IntPtr lpContext);

		/// <summary>
		/// <para>Retrieves a descriptor table entry for the specified selector and WOW64 thread.</para>
		/// </summary>
		/// <param name="hThread">
		/// <para>
		/// A handle to the thread containing the specified selector. The handle must have been created with THREAD_QUERY_INFORMATION access
		/// to the thread. For more information, see Thread Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="dwSelector">
		/// <para>The global or local selector value to look up in the thread's descriptor tables.</para>
		/// </param>
		/// <param name="lpSelectorEntry">
		/// <para>
		/// A pointer to a WOW64_LDT_ENTRY structure that receives a copy of the descriptor table entry if the specified selector has an
		/// entry in the specified thread's descriptor table. This information can be used to convert a segment-relative address to a linear
		/// virtual address.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero. In that case, the structure pointed to by the lpSelectorEntry parameter
		/// receives a copy of the specified descriptor table entry.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>Wow64GetThreadSelectorEntry</c> function is functional only on 64-bit systems and can be called only by 64-bit processes.
		/// If this function is called by a 32-bit process, the function fails with ERROR_NOT_SUPPORTED. A 32-bit process should use the
		/// GetThreadSelectorEntry function instead.
		/// </para>
		/// <para>
		/// Debuggers use this function to convert segment-relative addresses to linear virtual addresses. The ReadProcessMemory and
		/// WriteProcessMemory functions use linear virtual addresses.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-wow64getthreadselectorentry BOOL
		// Wow64GetThreadSelectorEntry( HANDLE hThread, DWORD dwSelector, PWOW64_LDT_ENTRY lpSelectorEntry );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "68393913-6725-4cc6-90b9-57da2a96c91e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Wow64GetThreadSelectorEntry(IntPtr hThread, uint dwSelector, ref WOW64_LDT_ENTRY lpSelectorEntry);

		/// <summary>
		/// <para>Sets the context of the specified WOW64 thread.</para>
		/// </summary>
		/// <param name="hThread">
		/// <para>A handle to the thread whose context is to be set.</para>
		/// </param>
		/// <param name="lpContext">
		/// <para>A WOW64_CONTEXT structure. The caller must initialize the <c>ContextFlags</c> member of this structure.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function allows the selective context to be set based on the value of the <c>ContextFlags</c> member of the context
		/// structure. The thread handle identified by the hThread parameter is typically being debugged, but the function can also operate
		/// even when it is not being debugged.
		/// </para>
		/// <para>
		/// This function is intended for 64-bit applications. It is not supported on 32-bit Windows; such calls fail and set the last error
		/// code to <c>ERROR_INVALID_FUNCTION</c>. A 32-bit application can call this function on a WOW64 thread; the result is the same as
		/// calling the SetThreadContext function.
		/// </para>
		/// <para>
		/// Do not try to set the context for a running thread; the results are unpredictable. Use the Wow64SuspendThread function to suspend
		/// the thread before calling <c>Wow64SetThreadContext</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-wow64setthreadcontext BOOL Wow64SetThreadContext( HANDLE
		// hThread, CONST WOW64_CONTEXT *lpContext );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "4119c945-b654-4634-a88b-e41bc762018a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Wow64SetThreadContext(IntPtr hThread, ref WOW64_CONTEXT lpContext);

		/// <summary>
		/// <para>Suspends the specified WOW64 thread.</para>
		/// </summary>
		/// <param name="hThread">
		/// <para>A handle to the thread that is to be suspended.</para>
		/// <para>The handle must have the THREAD_SUSPEND_RESUME access right. For more information, see Thread Security and Access Rights.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the thread's previous suspend count; otherwise, it is (DWORD) -1. To get extended
		/// error information, use the GetLastError function.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the function succeeds, execution of the specified thread is suspended and the thread's suspend count is incremented.
		/// Suspending a thread causes the thread to stop executing user-mode (application) code.
		/// </para>
		/// <para>
		/// This function is primarily designed for use by debuggers. It is not intended to be used for thread synchronization. Calling
		/// <c>Wow64SuspendThread</c> on a thread that owns a synchronization object, such as a mutex or critical section, can lead to a
		/// deadlock if the calling thread tries to obtain a synchronization object owned by a suspended thread. To avoid this situation, a
		/// thread within an application that is not a debugger should signal the other thread to suspend itself. The target thread must be
		/// designed to watch for this signal and respond appropriately.
		/// </para>
		/// <para>
		/// Each thread has a suspend count (with a maximum value of MAXIMUM_SUSPEND_COUNT). If the suspend count is greater than zero, the
		/// thread is suspended; otherwise, the thread is not suspended and is eligible for execution. Calling <c>Wow64SuspendThread</c>
		/// causes the target thread's suspend count to be incremented. Attempting to increment past the maximum suspend count causes an
		/// error without incrementing the count.
		/// </para>
		/// <para>The ResumeThread function decrements the suspend count of a suspended thread.</para>
		/// <para>
		/// This function is intended for 64-bit applications. It is not supported on 32-bit Windows; such calls fail and set the last error
		/// code to ERROR_INVALID_FUNCTION. A 32-bit application can call this function on a WOW64 thread; the result is the same as calling
		/// the SuspendThread function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-wow64suspendthread DWORD Wow64SuspendThread( HANDLE
		// hThread );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "d976675a-5400-41ac-a11d-c39a1b2dd50d")]
		public static extern uint Wow64SuspendThread(IntPtr hThread);

		/// <summary>
		/// <para>Contains extended parameters for the CopyFile2 function.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To compile an application that uses this structure, define the <c>_WIN32_WINNT</c> macro as <c>_WIN32_WINNT_WIN8</c> or later.
		/// For more information, see Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-copyfile2_extended_parameters typedef struct
		// COPYFILE2_EXTENDED_PARAMETERS { DWORD dwSize; DWORD dwCopyFlags; BOOL *pfCancel; PCOPYFILE2_PROGRESS_ROUTINE pProgressRoutine;
		// PVOID pvCallbackContext; };
		[PInvokeData("winbase.h", MSDNShortId = "a8da62e5-bc49-4aff-afaa-e774393b7120")]
		[StructLayout(LayoutKind.Sequential)]
		public struct COPYFILE2_EXTENDED_PARAMETERS
		{
			/// <summary>
			/// <para>Contains the size of this structure, .</para>
			/// </summary>
			public uint dwSize;

			/// <summary>
			/// <para>Contains a combination of zero or more of these flag values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>COPY_FILE_ALLOW_DECRYPTED_DESTINATION 0x00000008</term>
			/// <term>The copy will be attempted even if the destination file cannot be encrypted.</term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_COPY_SYMLINK 0x00000800</term>
			/// <term>
			/// If the source file is a symbolic link, the destination file is also a symbolic link pointing to the same file as the source
			/// symbolic link.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_FAIL_IF_EXISTS 0x00000001</term>
			/// <term>
			/// If the destination file exists the copy operation fails immediately. If a file or directory exists with the destination name
			/// then the CopyFile2 function call will fail with either or . If COPY_FILE_RESUME_FROM_PAUSE is also specified then a failure
			/// is only triggered if the destination file does not have a valid restart header.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_NO_BUFFERING 0x00001000</term>
			/// <term>
			/// The copy is performed using unbuffered I/O, bypassing the system cache resources. This flag is recommended for very large
			/// file copies. It is not recommended to pause copies that are using this flag.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_NO_OFFLOAD 0x00040000</term>
			/// <term>Do not attempt to use the Windows Copy Offload mechanism. This is not generally recommended.</term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_OPEN_SOURCE_FOR_WRITE 0x00000004</term>
			/// <term>The file is copied and the source file is opened for write access.</term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_RESTARTABLE 0x00000002</term>
			/// <term>
			/// The file is copied in a manner that can be restarted if the same source and destination filenames are used again. This is slower.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_REQUEST_SECURITY_PRIVILEGES 0x00002000</term>
			/// <term>
			/// The copy is attempted, specifying for the source file and for the destination file. If these requests are denied the access
			/// request will be reduced to the highest privilege level for which access is granted. For more information see SACL Access
			/// Right. This can be used to allow the CopyFile2ProgressRoutine callback to perform operations requiring higher privileges,
			/// such as copying the security attributes for the file.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPY_FILE_RESUME_FROM_PAUSE 0x00004000</term>
			/// <term>
			/// The destination file is examined to see if it was copied using COPY_FILE_RESTARTABLE. If so the copy is resumed. If not the
			/// file will be fully copied.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public COPY_FILE dwCopyFlags;

			/// <summary>
			/// <para>If this flag is set to <c>TRUE</c> during the copy operation then the copy operation is canceled.</para>
			/// </summary>
			public IntPtr pfCancel;

			/// <summary>
			/// <para>
			/// The optional address of a callback function of type <c>PCOPYFILE2_PROGRESS_ROUTINE</c> that is called each time another
			/// portion of the file has been copied. This parameter can be <c>NULL</c>. For more information on the progress callback
			/// function, see the CopyFile2ProgressRoutine callback function.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public Pcopyfile2ProgressRoutine pProgressRoutine;

			/// <summary>
			/// <para>A pointer to application-specific context information to be passed to the CopyFile2ProgressRoutine.</para>
			/// </summary>
			public IntPtr pvCallbackContext;
		}

		/// <summary>
		/// <para>Passed to the CopyFile2ProgressRoutine callback function with information about a pending copy operation.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To compile an application that uses the <c>COPYFILE2_MESSAGE</c> structure, define the <c>_WIN32_WINNT</c> macro as 0x0601 or
		/// later. For more information, see Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-copyfile2_message
		[PInvokeData("winbase.h", MSDNShortId = "ab841bee-90a0-4beb-99d3-764e608c3872")]
		[StructLayout(LayoutKind.Sequential)]
		public struct COPYFILE2_MESSAGE
		{
			/// <summary>
			/// <para>Value from the COPYFILE2_MESSAGE_TYPE enumeration used as a discriminant for the <c>Info</c> union within this structure.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>COPYFILE2_CALLBACK_CHUNK_STARTED 1</term>
			/// <term>
			/// Indicates a single chunk of a stream has started to be copied. Information is in the ChunkStarted structure within the Info union.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPYFILE2_CALLBACK_CHUNK_FINISHED 2</term>
			/// <term>
			/// Indicates the copy of a single chunk of a stream has completed. Information is in the ChunkFinished structure within the Info union.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPYFILE2_CALLBACK_STREAM_STARTED 3</term>
			/// <term>
			/// Indicates both source and destination handles for a stream have been opened and the copy of the stream is about to be
			/// started. Information is in the StreamStarted structure within the Info union. This does not indicate that the copy has
			/// started for that stream.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPYFILE2_CALLBACK_STREAM_FINISHED 4</term>
			/// <term>
			/// Indicates the copy operation for a stream have started to be completed, either successfully or due to a
			/// COPYFILE2_PROGRESS_STOP return from CopyFile2ProgressRoutine. Information is in the StreamFinished structure within the Info union.
			/// </term>
			/// </item>
			/// <item>
			/// <term>COPYFILE2_CALLBACK_POLL_CONTINUE 5</term>
			/// <term>May be sent periodically. Information is in the PollContinue structure within the Info union.</term>
			/// </item>
			/// <item>
			/// <term>COPYFILE2_CALLBACK_ERROR 6</term>
			/// <term>An error was encountered during the copy operation. Information is in the Error structure within the Info union.</term>
			/// </item>
			/// </list>
			/// </summary>
			public COPYFILE2_MESSAGE_TYPE Type;

			private uint dwPadding;

			/// <summary>Union</summary>
			public Union Info;

			/// <summary>Undocumented.</summary>
			[StructLayout(LayoutKind.Explicit)]
			public struct Union
			{
				/// <summary>Undocumented.</summary>
				[FieldOffset(0)]
				public ChunkStarted ChunkStarted;

				/// <summary>Undocumented.</summary>
				[FieldOffset(0)]
				public ChunkFinished ChunkFinished;

				/// <summary>Undocumented.</summary>
				[FieldOffset(0)]
				public StreamStarted StreamStarted;

				/// <summary>Undocumented.</summary>
				[FieldOffset(0)]
				public StreamFinished StreamFinished;

				/// <summary>Undocumented.</summary>
				[FieldOffset(0)]
				public PollContinue PollContinue;

				/// <summary>Undocumented.</summary>
				[FieldOffset(0)]
				public Error Error;
			}

			/// <summary>Undocumented.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct ChunkStarted
			{
				/// <summary>
				/// <para>
				/// Indicates which stream within the file is about to be copied. The value used for identifying a stream within a file will
				/// start at one (1) and will always be higher than any previous stream for that file.
				/// </para>
				/// </summary>
				public uint dwStreamNumber;

				/// <summary>
				/// <para>This member is reserved for internal use.</para>
				/// </summary>
				public uint dwReserved;

				/// <summary>
				/// <para>Handle to the source stream.</para>
				/// </summary>
				public IntPtr hSourceFile;

				/// <summary>
				/// <para>Handle to the destination stream.</para>
				/// </summary>
				public IntPtr hDestinationFile;

				/// <summary>
				/// <para>
				/// Indicates which chunk within the current stream is about to be copied. The value used for a chunk will start at zero (0)
				/// and will always be higher than that of any previous chunk for the current stream.
				/// </para>
				/// </summary>
				public ulong uliChunkNumber;

				/// <summary>
				/// <para>Size of the copied chunk, in bytes.</para>
				/// </summary>
				public ulong uliChunkSize;

				/// <summary>
				/// <para>Size of the current stream, in bytes.</para>
				/// </summary>
				public ulong uliStreamSize;

				/// <summary>
				/// <para>Size of all streams for this file, in bytes.</para>
				/// </summary>
				public ulong uliTotalFileSize;
			}

			/// <summary>Undocumented.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct ChunkFinished
			{
				/// <summary>
				/// <para>
				/// Indicates which stream within the file is about to be copied. The value used for identifying a stream within a file will
				/// start at one (1) and will always be higher than any previous stream for that file.
				/// </para>
				/// </summary>
				public uint dwStreamNumber;

				/// <summary>
				/// <para>This member is reserved for internal use.</para>
				/// </summary>
				public uint dwFlags;

				/// <summary>
				/// <para>Handle to the source stream.</para>
				/// </summary>
				public IntPtr hSourceFile;

				/// <summary>
				/// <para>Handle to the destination stream.</para>
				/// </summary>
				public IntPtr hDestinationFile;

				/// <summary>
				/// <para>
				/// Indicates which chunk within the current stream is in process. The value used for a chunk will start at zero (0) and will
				/// always be higher than that of any previous chunk for the current stream.
				/// </para>
				/// </summary>
				public ulong uliChunkNumber;

				/// <summary>
				/// <para>Size of the copied chunk, in bytes.</para>
				/// </summary>
				public ulong uliChunkSize;

				/// <summary>
				/// <para>Size of the current stream, in bytes.</para>
				/// </summary>
				public ulong uliStreamSize;

				/// <summary>
				/// <para>Total bytes copied for this stream so far.</para>
				/// </summary>
				public ulong uliStreamBytesTransferred;

				/// <summary>
				/// <para>Size of all streams for this file, in bytes.</para>
				/// </summary>
				public ulong uliTotalFileSize;

				/// <summary>
				/// <para>Total bytes copied for this file so far.</para>
				/// </summary>
				public ulong uliTotalBytesTransferred;
			}

			/// <summary>Undocumented.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct StreamStarted
			{
				/// <summary>
				/// <para>
				/// Indicates which stream within the file is about to be copied. The value used for identifying a stream within a file will
				/// start at one (1) and will always be higher than any previous stream for that file.
				/// </para>
				/// </summary>
				public uint dwStreamNumber;

				/// <summary>
				/// <para>This member is reserved for internal use.</para>
				/// </summary>
				public uint dwReserved;

				/// <summary>
				/// <para>Handle to the source stream.</para>
				/// </summary>
				public IntPtr hSourceFile;

				/// <summary>
				/// <para>Handle to the destination stream.</para>
				/// </summary>
				public IntPtr hDestinationFile;

				/// <summary>
				/// <para>Size of the current stream, in bytes.</para>
				/// </summary>
				public ulong uliStreamSize;

				/// <summary>
				/// <para>Size of all streams for this file, in bytes.</para>
				/// </summary>
				public ulong uliTotalFileSize;
			}

			/// <summary>Undocumented.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct StreamFinished
			{
				/// <summary>
				/// <para>
				/// Indicates which stream within the file is about to be copied. The value used for identifying a stream within a file will
				/// start at one (1) and will always be higher than any previous stream for that file.
				/// </para>
				/// </summary>
				public uint dwStreamNumber;

				/// <summary>
				/// <para>This member is reserved for internal use.</para>
				/// </summary>
				public uint dwReserved;

				/// <summary>
				/// <para>Handle to the source stream.</para>
				/// </summary>
				public IntPtr hSourceFile;

				/// <summary>
				/// <para>Handle to the destination stream.</para>
				/// </summary>
				public IntPtr hDestinationFile;

				/// <summary>
				/// <para>Size of the current stream, in bytes.</para>
				/// </summary>
				public ulong uliStreamSize;

				/// <summary>
				/// <para>Total bytes copied for this stream so far.</para>
				/// </summary>
				public ulong uliStreamBytesTransferred;

				/// <summary>
				/// <para>Size of all streams for this file, in bytes.</para>
				/// </summary>
				public ulong uliTotalFileSize;

				/// <summary>
				/// <para>Total bytes copied for this file so far.</para>
				/// </summary>
				public ulong uliTotalBytesTransferred;
			}

			/// <summary>Undocumented.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct PollContinue
			{
				/// <summary>
				/// <para>This member is reserved for internal use.</para>
				/// </summary>
				public uint dwReserved;
			}

			/// <summary>Undocumented.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct Error
			{
				/// <summary>
				/// <para>Value from the COPYFILE2_COPY_PHASE enumeration indicating the current phase of the copy at the time of the error.</para>
				/// </summary>
				public COPYFILE2_COPY_PHASE CopyPhase;

				/// <summary>
				/// <para>The number of the stream that was being processed at the time of the error.</para>
				/// </summary>
				public uint dwStreamNumber;

				/// <summary>
				/// <para>Value indicating the problem.</para>
				/// </summary>
				public HRESULT hrFailure;

				/// <summary>
				/// <para>This member is reserved for internal use.</para>
				/// </summary>
				public uint dwReserved;

				/// <summary>
				/// <para>
				/// Indicates which chunk within the current stream was being processed at the time of the error. The value used for a chunk
				/// will start at zero (0) and will always be higher than that of any previous chunk for the current stream.
				/// </para>
				/// </summary>
				public ulong uliChunkNumber;

				/// <summary>
				/// <para>Size, in bytes, of the stream being processed.</para>
				/// </summary>
				public ulong uliStreamSize;

				/// <summary>
				/// <para>Number of bytes that had been successfully transferred for the stream being processed.</para>
				/// </summary>
				public ulong uliStreamBytesTransferred;

				/// <summary>
				/// <para>Size, in bytes, of the total file being processed.</para>
				/// </summary>
				public ulong uliTotalFileSize;

				/// <summary>
				/// <para>Number of bytes that had been successfully transferred for the entire copy operation.</para>
				/// </summary>
				public ulong uliTotalBytesTransferred;
			}
		}

		/// <summary>
		/// <para>
		/// Specifies attributes for a user-mode scheduling (UMS) scheduler thread. The EnterUmsSchedulingMode function uses this structure.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_ums_scheduler_startup_info typedef struct
		// _UMS_SCHEDULER_STARTUP_INFO { ULONG UmsVersion; PUMS_COMPLETION_LIST CompletionList; PUMS_SCHEDULER_ENTRY_POINT SchedulerProc;
		// PVOID SchedulerParam; } UMS_SCHEDULER_STARTUP_INFO, *PUMS_SCHEDULER_STARTUP_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "e3f7b1b7-d2b8-432d-bce7-3633292e855b")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct UMS_SCHEDULER_STARTUP_INFO
		{
			/// <summary>
			/// <para>The UMS version for which the application was built. This parameter must be <c>UMS_VERSION (0x0100)</c>.</para>
			/// </summary>
			public uint UmsVersion;

			/// <summary>
			/// <para>A pointer to a UMS completion list to associate with the calling thread.</para>
			/// </summary>
			public IntPtr CompletionList;

			/// <summary>
			/// <para>
			/// A pointer to an application-defined UmsSchedulerProc entry point function. The system calls this function when the calling
			/// thread has been converted to UMS and is ready to run UMS worker threads. Subsequently, it calls this function when a UMS
			/// worker thread running on the calling thread yields or blocks.
			/// </para>
			/// </summary>
			public RtlUmsSchedulerEntryPoint SchedulerProc;

			/// <summary>
			/// <para>An application-defined parameter to pass to the specified UmsSchedulerProc function.</para>
			/// </summary>
			public IntPtr SchedulerParam;
		}

		/// <summary>
		/// <para>
		/// Specifies a UMS scheduler thread, UMS worker thread, or non-UMS thread. The GetUmsSystemThreadInformation function uses this structure.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>If both <c>IsUmsSchedulerThread</c> and <c>IsUmsWorkerThread</c> are clear, the structure specifies a non-UMS thread.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_ums_system_thread_information typedef struct
		// _UMS_SYSTEM_THREAD_INFORMATION { ULONG UmsVersion; union { struct { ULONG IsUmsSchedulerThread : 1; ULONG IsUmsWorkerThread : 1; }
		// DUMMYSTRUCTNAME; ULONG ThreadUmsFlags; } DUMMYUNIONNAME; } UMS_SYSTEM_THREAD_INFORMATION, *PUMS_SYSTEM_THREAD_INFORMATION;
		[PInvokeData("winbase.h", MSDNShortId = "eecdc592-5046-47c3-a4c6-ecb10899db3c")]
		[StructLayout(LayoutKind.Sequential)]
		public struct UMS_SYSTEM_THREAD_INFORMATION
		{
			/// <summary>
			/// <para>The UMS version. This member must be UMS_VERSION.</para>
			/// </summary>
			public uint UmsVersion;

			/// <summary>A bitfield that specifies a UMS thread type.</summary>
			public ThreadUmsFlags ThreadUmsFlags;
		}

		/// <summary>SafeHandle instance using <see cref="CloseHandle"/> upon disposal.</summary>
		public class SafeObjectHandle : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeObjectHandle"/> class.</summary>
			public SafeObjectHandle() : this(IntPtr.Zero) { }

			/// <summary>Initializes a new instance of the <see cref="SafeObjectHandle"/> class.</summary>
			/// <param name="handle">The handle.</param>
			public SafeObjectHandle(IntPtr handle) : base(handle, CloseHandle) { }
		}
	}
}