using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

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

		/// <summary>Infinite timeout.</summary>
		public const uint INFINITE = 0xffffffff;

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

		/// <summary>
		/// <para>Discriminator for the union in the FILE_ID_DESCRIPTOR structure.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ne-winbase-_file_id_type typedef enum _FILE_ID_TYPE { FileIdType ,
		// ObjectIdType , ExtendedFileIdType , MaximumFileIdType } FILE_ID_TYPE, *PFILE_ID_TYPE;
		[PInvokeData("winbase.h", MSDNShortId = "7e46ba94-e3cd-4d6c-962f-5d5bd55d45a1")]
		public enum FILE_ID_TYPE
		{
			/// <summary>Use the FileId member of the union.</summary>
			FileIdType,

			/// <summary>Use the ObjectId member of the union.</summary>
			ObjectIdType,

			/// <summary>
			/// Use the ExtendedFileId member of the union. Windows XP, Windows Server 2003, Windows Vista, Windows Server 2008, Windows 7
			/// and Windows Server 2008 R2: This value is not supported before Windows 8 and Windows Server 2012.
			/// </summary>
			ExtendedFileIdType,

			/// <summary>This value is used for comparison only. All valid values are less than this value.</summary>
			MaximumFileIdType,
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

		/// <summary>Adds an alternate local network name for the computer from which it is called.</summary>
		/// <param name="lpDnsFQHostname">
		/// The alternate name to be added. The name must be in the ComputerNameDnsFullyQualified format as defined in the
		/// COMPUTER_NAME_FORMAT enumeration, and the DnsValidateName_W function must be able to validate it with its format set to DnsNameHostnameFull.
		/// </param>
		/// <param name="ulFlags">This parameter is reserved and must be set to zero.</param>
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
		[PInvokeData("winbase.h", MSDNShortId = "e4d8355b-0492-4b6f-988f-3887e63a2bba")]
		// public static extern uint AddLocalAlternateComputerName([In] string lpDnsFQHostname, [In] uint ulFlags);
		public static extern Win32Error AddLocalAlternateComputerName(string lpDnsFQHostname, [Optional] uint ulFlags);

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
		public static extern bool AddSecureMemoryCacheCallback(SecureMemoryCacheCallback pfnCallBack);

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
		public static extern bool CopyContext(SafeCONTEXT Destination, uint ContextFlags, IntPtr Source);

		/// <summary>Disables thread profiling.</summary>
		/// <param name="PerformanceDataHandle">The handle that the <c>EnableThreadProfiling</c> function returned.</param>
		/// <returns>Returns ERROR_SUCCESS if the call is successful; otherwise, a system error code (see Winerror.h).</returns>
		// DWORD APIENTRY DisableThreadProfiling( _In_ HANDLE PerformanceDataHandle); https://msdn.microsoft.com/en-us/library/windows/desktop/dd796392(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "dd796392")]
		public static extern Win32Error DisableThreadProfiling(PerformanceDataHandle PerformanceDataHandle);

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
		public static extern Win32Error EnableThreadProfiling(HTHREAD ThreadHandle, THREAD_PROFILING_FLAG Flags, ulong HardwareCounters, out PerformanceDataHandle PerformanceDataHandle);

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
		public static extern Win32Error GetFirmwareEnvironmentVariableEx(string lpName, string lpGuid, IntPtr pBuffer, uint nSize, out VARIABLE_ATTRIBUTE pdwAttribubutes);

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
		public static extern bool GetProcessDEPPolicy(HPROCESS hProcess, out PROCESS_DEP lpFlags, [MarshalAs(UnmanagedType.Bool)] out bool lpPermanent);

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
		public static extern bool GetXStateFeaturesMask(SafeCONTEXT Context, out ulong FeatureMask);

		/// <summary>
		/// <para>Initializes a CONTEXT structure inside a buffer with the necessary size and alignment.</para>
		/// </summary>
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
		[PInvokeData("winbase.h", MSDNShortId = "909BF5F7-0622-4B22-A2EC-27722389700A")]
		public static bool InitializeContext(uint ContextFlags, out SafeCONTEXT Context) { Context = new SafeCONTEXT(ContextFlags); return true; }

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
		public static extern SafeHINSTANCE LoadPackagedLibrary([MarshalAs(UnmanagedType.LPWStr)] string lpwLibFileName, uint Reserved = 0);

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
		public static extern IntPtr LocateXStateFeature(SafeCONTEXT Context, uint FeatureId, out uint Length);

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
		// https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-lstrcpyna
		// LPSTR lstrcpynA( LPSTR lpString1, LPCSTR lpString2, int iMaxLength );
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h")]
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
		/// <para>A handle to any file on a volume or share on which the file to be opened is stored.</para>
		/// </param>
		/// <param name="lpFileId">
		/// <para>A pointer to a FILE_ID_DESCRIPTOR that identifies the file to open.</para>
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
		/// <para>The file flags.</para>
		/// <para>
		/// When <c>OpenFileById</c> opens a file, it combines the file flags with existing file attributes, and ignores any supplied file
		/// attributes. This parameter can include any combination of the following flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_FLAG_BACKUP_SEMANTICS 0x02000000</term>
		/// <term>
		/// A file is being opened for a backup or restore operation. The system ensures that the calling process overrides file security
		/// checks when the process has SE_BACKUP_NAME and SE_RESTORE_NAME privileges. For more information, see Changing Privileges in a
		/// Token. You must set this flag to obtain a handle to a directory. A directory handle can be passed to some functions instead of a
		/// file handle. For more information, see Directory Handles.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_NO_BUFFERING 0x20000000</term>
		/// <term>
		/// The system opens a file with no system caching. This flag does not affect hard disk caching. When combined with
		/// FILE_FLAG_OVERLAPPED, the flag gives maximum asynchronous performance, because the I/O does not rely on the synchronous
		/// operations of the memory manager. However, some I/O operations take more time, because data is not being held in the cache. Also,
		/// the file metadata may still be cached. To flush the metadata to disk, use the FlushFileBuffers function. An application must meet
		/// certain requirements when working with files that are opened with FILE_FLAG_NO_BUFFERING: One way to align buffers on integer
		/// multiples of the volume sector size is to use VirtualAlloc to allocate the buffers. It allocates memory that is aligned on
		/// addresses that are integer multiples of the operating system's memory page size. Because both memory page and volume sector sizes
		/// are powers of 2, this memory is also aligned on addresses that are integer multiples of a volume sector size. Memory pages are
		/// 4-8 KB in size; sectors are 512 bytes (hard disks) or 2048 bytes (CD), and therefore, volume sectors can never be larger than
		/// memory pages. An application can determine a volume sector size by calling the GetDiskFreeSpace function.
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
		/// When this flag is used, normal reparse point processing does not occur, and OpenFileById attempts to open the reparse point. When
		/// a file is opened, a file handle is returned, whether or not the filter that controls the reparse point is operational. This flag
		/// cannot be used with the CREATE_ALWAYS flag. If the file is not a reparse point, then this flag is ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_OVERLAPPED 0x40000000</term>
		/// <term>
		/// The file is being opened or created for asynchronous I/O. When the operation is complete, the event specified to the call in the
		/// OVERLAPPED structure is set to the signaled state. Operations that take a significant amount of time to process return
		/// ERROR_IO_PENDING. If this flag is specified, the file can be used for simultaneous read and write operations. The system does not
		/// maintain the file pointer, therefore you must pass the file position to the read and write functions in the OVERLAPPED structure
		/// or update the file pointer. If this flag is not specified, then I/O operations are serialized, even if the calls to the read and
		/// write functions specify an OVERLAPPED structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_RANDOM_ACCESS 0x10000000</term>
		/// <term>A file is accessed randomly. The system can use this as a hint to optimize file caching.</term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_SEQUENTIAL_SCAN 0x08000000</term>
		/// <term>
		/// A file is accessed sequentially from beginning to end. The system can use this as a hint to optimize file caching. If an
		/// application moves the file pointer for random access, optimum caching may not occur. However, correct operation is still
		/// guaranteed. Specifying this flag can increase performance for applications that read large files using sequential access.
		/// Performance gains can be even more noticeable for applications that read large files mostly sequentially, but occasionally skip
		/// over small ranges of bytes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILE_FLAG_WRITE_THROUGH 0x80000000</term>
		/// <term>
		/// The system writes through any intermediate cache and goes directly to disk. If FILE_FLAG_NO_BUFFERING is not also specified, so
		/// that system caching is in effect, then the data is written to the system cache, but is flushed to disk without delay. If
		/// FILE_FLAG_NO_BUFFERING is also specified, so that system caching is not in effect, then the data is immediately flushed to disk
		/// without going through the system cache. The operating system also requests a write-through the hard disk cache to persistent
		/// media. However, not all hardware supports this write-through capability.
		/// </term>
		/// </item>
		/// </list>
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
		public static extern IntPtr OpenFileById(HFILE hVolumeHint, in FILE_ID_DESCRIPTOR lpFileId, FileAccess dwDesiredAccess, FileShare dwShareMode, SECURITY_ATTRIBUTES lpSecurityAttributes, FileFlagsAndAttributes dwFlagsAndAttributes);

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
		public static extern bool PowerClearRequest(SafePowerRequestObject PowerRequest, POWER_REQUEST_TYPE RequestType);

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
		public static extern SafePowerRequestObject PowerCreateRequest([In] REASON_CONTEXT Context);

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
		public static extern bool PowerSetRequest(SafePowerRequestObject PowerRequest, POWER_REQUEST_TYPE RequestType);

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
		public static extern bool QueryFullProcessImageName(HPROCESS hProcess, PROCESS_NAME dwFlags, StringBuilder lpExeName, ref uint lpdwSize);

		/// <summary>Determines whether thread profiling is enabled for the specified thread.</summary>
		/// <param name="ThreadHandle">The handle to the thread of interest.</param>
		/// <param name="Enabled">Is <c>TRUE</c> if thread profiling is enabled for the specified thread; otherwise, <c>FALSE</c>.</param>
		/// <returns>Returns ERROR_SUCCESS if the call is successful; otherwise, a system error code (see Winerror.h).</returns>
		// DWORD APIENTRY QueryThreadProfiling( _In_ HANDLE ThreadHandle, _Out_ PBOOLEAN Enabled); https://msdn.microsoft.com/en-us/library/windows/desktop/dd796402(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "dd796402")]
		public static extern Win32Error QueryThreadProfiling(HTHREAD ThreadHandle, [MarshalAs(UnmanagedType.U1)] out bool Enabled);

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
		public static extern Win32Error ReadThreadProfilingData(PerformanceDataHandle PerformanceDataHandle, uint Flags, ref PERFORMANCE_DATA PerformanceData);

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
		public static extern bool RemoveSecureMemoryCacheCallback(SecureMemoryCacheCallback pfnCallBack);

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
		public static extern bool SetXStateFeaturesMask(SafeCONTEXT Context, ulong FeatureMask);

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
		public static extern bool Wow64GetThreadContext(HTHREAD hThread, ref WOW64_CONTEXT lpContext);

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
		public static extern bool Wow64GetThreadSelectorEntry(HTHREAD hThread, uint dwSelector, out WOW64_LDT_ENTRY lpSelectorEntry);

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
		public static extern bool Wow64SetThreadContext(HTHREAD hThread, in WOW64_CONTEXT lpContext);

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
		public static extern uint Wow64SuspendThread(HTHREAD hThread);

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
		private static extern bool InitializeContext(IntPtr Buffer, uint ContextFlags, out IntPtr Context, ref uint ContextLength);

		/// <summary>A performance data handle.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct PerformanceDataHandle
		{
			private readonly IntPtr handle;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> to a that releases a created PowerRequestObject instance at disposal using CloseHandle.</summary>
		public class SafePowerRequestObject : SafeKernelHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafePowerRequestObject"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafePowerRequestObject(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafePowerRequestObject"/> class.</summary>
			private SafePowerRequestObject() : base() { }
		}
	}
}