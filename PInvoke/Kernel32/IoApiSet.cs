using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Device types defined by the system.</summary>
		[PInvokeData("WinIOCtl.h")]
		public enum DEVICE_TYPE : ushort
		{
			FILE_DEVICE_BEEP = 0x00000001,
			FILE_DEVICE_CD_ROM = 0x00000002,
			FILE_DEVICE_CD_ROM_FILE_SYSTEM = 0x00000003,
			FILE_DEVICE_CONTROLLER = 0x00000004,
			FILE_DEVICE_DATALINK = 0x00000005,
			FILE_DEVICE_DFS = 0x00000006,
			FILE_DEVICE_DISK = 0x00000007,
			FILE_DEVICE_DISK_FILE_SYSTEM = 0x00000008,
			FILE_DEVICE_FILE_SYSTEM = 0x00000009,
			FILE_DEVICE_INPORT_PORT = 0x0000000a,
			FILE_DEVICE_KEYBOARD = 0x0000000b,
			FILE_DEVICE_MAILSLOT = 0x0000000c,
			FILE_DEVICE_MIDI_IN = 0x0000000d,
			FILE_DEVICE_MIDI_OUT = 0x0000000e,
			FILE_DEVICE_MOUSE = 0x0000000f,
			FILE_DEVICE_MULTI_UNC_PROVIDER = 0x00000010,
			FILE_DEVICE_NAMED_PIPE = 0x00000011,
			FILE_DEVICE_NETWORK = 0x00000012,
			FILE_DEVICE_NETWORK_BROWSER = 0x00000013,
			FILE_DEVICE_NETWORK_FILE_SYSTEM = 0x00000014,
			FILE_DEVICE_NULL = 0x00000015,
			FILE_DEVICE_PARALLEL_PORT = 0x00000016,
			FILE_DEVICE_PHYSICAL_NETCARD = 0x00000017,
			FILE_DEVICE_PRINTER = 0x00000018,
			FILE_DEVICE_SCANNER = 0x00000019,
			FILE_DEVICE_SERIAL_MOUSE_PORT = 0x0000001a,
			FILE_DEVICE_SERIAL_PORT = 0x0000001b,
			FILE_DEVICE_SCREEN = 0x0000001c,
			FILE_DEVICE_SOUND = 0x0000001d,
			FILE_DEVICE_STREAMS = 0x0000001e,
			FILE_DEVICE_TAPE = 0x0000001f,
			FILE_DEVICE_TAPE_FILE_SYSTEM = 0x00000020,
			FILE_DEVICE_TRANSPORT = 0x00000021,
			FILE_DEVICE_UNKNOWN = 0x00000022,
			FILE_DEVICE_VIDEO = 0x00000023,
			FILE_DEVICE_VIRTUAL_DISK = 0x00000024,
			FILE_DEVICE_WAVE_IN = 0x00000025,
			FILE_DEVICE_WAVE_OUT = 0x00000026,
			FILE_DEVICE_8042_PORT = 0x00000027,
			FILE_DEVICE_NETWORK_REDIRECTOR = 0x00000028,
			FILE_DEVICE_BATTERY = 0x00000029,
			FILE_DEVICE_BUS_EXTENDER = 0x0000002a,
			FILE_DEVICE_MODEM = 0x0000002b,
			FILE_DEVICE_VDM = 0x0000002c,
			FILE_DEVICE_MASS_STORAGE = 0x0000002d,
			FILE_DEVICE_SMB = 0x0000002e,
			FILE_DEVICE_KS = 0x0000002f,
			FILE_DEVICE_CHANGER = 0x00000030,
			FILE_DEVICE_SMARTCARD = 0x00000031,
			FILE_DEVICE_ACPI = 0x00000032,
			FILE_DEVICE_DVD = 0x00000033,
			FILE_DEVICE_FULLSCREEN_VIDEO = 0x00000034,
			FILE_DEVICE_DFS_FILE_SYSTEM = 0x00000035,
			FILE_DEVICE_DFS_VOLUME = 0x00000036,
			FILE_DEVICE_SERENUM = 0x00000037,
			FILE_DEVICE_TERMSRV = 0x00000038,
			FILE_DEVICE_KSEC = 0x00000039,
			FILE_DEVICE_FIPS = 0x0000003A,
			FILE_DEVICE_INFINIBAND = 0x0000003B,
			FILE_DEVICE_VMBUS = 0x0000003E,
			FILE_DEVICE_CRYPT_PROVIDER = 0x0000003F,
			FILE_DEVICE_WPD = 0x00000040,
			FILE_DEVICE_BLUETOOTH = 0x00000041,
			FILE_DEVICE_MT_COMPOSITE = 0x00000042,
			FILE_DEVICE_MT_TRANSPORT = 0x00000043,
			FILE_DEVICE_BIOMETRIC = 0x00000044,
			FILE_DEVICE_PMI = 0x00000045,
			FILE_DEVICE_EHSTOR = 0x00000046,
			FILE_DEVICE_DEVAPI = 0x00000047,
			FILE_DEVICE_GPIO = 0x00000048,
			FILE_DEVICE_USBEX = 0x00000049,
			FILE_DEVICE_CONSOLE = 0x00000050,
			FILE_DEVICE_NFP = 0x00000051,
			FILE_DEVICE_SYSENV = 0x00000052,
			FILE_DEVICE_VIRTUAL_BLOCK = 0x00000053,
			FILE_DEVICE_POINT_OF_SERVICE = 0x00000054,
			FILE_DEVICE_STORAGE_REPLICATION = 0x00000055,
			FILE_DEVICE_TRUST_ENV = 0x00000056,
			FILE_DEVICE_UCM = 0x00000057,
			FILE_DEVICE_UCMTCPCI = 0x00000058,
			IOCTL_STORAGE_BASE = FILE_DEVICE_MASS_STORAGE,
		}

		/// <summary>
		/// Defined access check value for any access within an I/O control code (IOCTL). The FILE_ACCESS_ANY is generally the correct value.
		/// </summary>
		[Flags]
		[PInvokeData("WinIOCtl.h")]
		public enum IOAccess : byte
		{
			/// <summary>Request all access.</summary>
			FILE_ANY_ACCESS = 0,

			/// <summary>Request read access. Can be used with FILE_WRITE_ACCESS.</summary>
			FILE_READ_ACCESS = 1,

			/// <summary>Request write access. Can be used with FILE_READ_ACCESS.</summary>
			FILE_WRITE_ACCESS = 2,

			/// <summary>Request read and write access. This value is equivalent to (FILE_READ_ACCESS | FILE_WRITE_ACCESS).</summary>
			FILE_READ_WRITE_ACCESS = 3,
		}

		/// <summary>Defined method codes for how buffers are passed for I/O and file system controls within an I/O control code (IOCTL).</summary>
		[PInvokeData("WinIOCtl.h")]
		public enum IOMethod : byte
		{
			METHOD_BUFFERED = 0,
			METHOD_IN_DIRECT = 1,
			METHOD_OUT_DIRECT = 2,
			METHOD_NEITHER = 3,
		}

		/// <summary>
		/// Starts the asynchronous operation of sending a control code directly to a specified device driver, causing the corresponding
		/// device to perform the corresponding operation.
		/// </summary>
		/// <typeparam name="TIn">The type of the <paramref name="inVal"/>.</typeparam>
		/// <typeparam name="TOut">The type of the <paramref name="outVal"/>.</typeparam>
		/// <param name="hDevice">
		/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream.
		/// To retrieve a device handle, use the CreateFile function. For more information, see Remarks.
		/// </param>
		/// <param name="dwIoControlCode">
		/// The control code for the operation. This value identifies the specific operation to be performed and the type of device on which
		/// to perform it.
		/// </param>
		/// <param name="inVal">
		/// A pointer to the input buffer that contains the data required to perform the operation. The format of this data depends on the
		/// value of the dwIoControlCode parameter.
		/// <para>This parameter can be NULL if dwIoControlCode specifies an operation that does not require input data.</para>
		/// </param>
		/// <param name="outVal">
		/// A pointer to the output buffer that is to receive the data returned by the operation. The format of this data depends on the
		/// value of the dwIoControlCode parameter.
		/// <para>This parameter can be NULL if dwIoControlCode specifies an operation that does not return data.</para>
		/// </param>
		/// <param name="userCallback">An AsyncCallback delegate that references the method to invoke when the operation is complete.</param>
		/// <returns>An IAsyncResult instance that references the asynchronous request.</returns>
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static IAsyncResult BeginDeviceIoControl<TIn, TOut>(HFILE hDevice, uint dwIoControlCode, TIn? inVal, TOut? outVal, AsyncCallback userCallback) where TIn : struct where TOut : struct
		{
			var buffer = Pack(inVal, outVal);
			return BeginDeviceIoControl<TIn, TOut>(hDevice, dwIoControlCode, buffer, userCallback, null);
		}

		/// <summary>
		/// Starts the asynchronous operation of sending a control code directly to a specified device driver, causing the corresponding
		/// device to perform the corresponding operation.
		/// </summary>
		/// <param name="hDevice">
		/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream.
		/// To retrieve a device handle, use the CreateFile function. For more information, see Remarks.
		/// </param>
		/// <param name="dwIoControlCode">
		/// The control code for the operation. This value identifies the specific operation to be performed and the type of device on which
		/// to perform it.
		/// </param>
		/// <param name="inputBuffer">The input buffer required to perform the operation. Can be null if unnecessary.</param>
		/// <param name="outputBuffer">The output buffer that is to receive the data returned by the operation. Can be null if unnecessary.</param>
		/// <param name="userCallback">An AsyncCallback delegate that references the method to invoke when the operation is complete.</param>
		/// <returns>An IAsyncResult instance that references the asynchronous request.</returns>
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static IAsyncResult BeginDeviceIoControl(HFILE hDevice, uint dwIoControlCode, byte[] inputBuffer, byte[] outputBuffer, AsyncCallback userCallback)
		{
			var buffer = Pack(inputBuffer, outputBuffer);
			return BeginDeviceIoControl(hDevice, dwIoControlCode, buffer, userCallback, null);
		}

		/// <summary>
		/// <para>
		/// Cancels all pending input and output (I/O) operations that are issued by the calling thread for the specified file. The function
		/// does not cancel I/O operations that other threads issue for a file handle.
		/// </para>
		/// <para>To cancel I/O operations from another thread, use the <c>CancelIoEx</c> function.</para>
		/// </summary>
		/// <param name="hFile">
		/// <para>A handle to the file.</para>
		/// <para>The function cancels all pending I/O operations for this file handle.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero. The cancel operation for all pending I/O operations issued by the calling
		/// thread for the specified file handle was successfully requested. The thread can use the <c>GetOverlappedResult</c> function to
		/// determine when the I/O operations themselves have been completed.
		/// </para>
		/// <para>If the function fails, the return value is zero (0). To get extended error information, call the <c>GetLastError</c> function.</para>
		/// </returns>
		// BOOL WINAPI CancelIo( _In_ HANDLE hFile);// https://msdn.microsoft.com/en-us/library/windows/desktop/aa363791(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("IoAPI.h", MSDNShortId = "aa363791")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CancelIo([In] HFILE hFile);

		/// <summary>
		/// Marks any outstanding I/O operations for the specified file handle. The function only cancels I/O operations in the current
		/// process, regardless of which thread created the I/O operation.
		/// </summary>
		/// <param name="hFile">A handle to the file.</param>
		/// <param name="lpOverlapped">
		/// <para>A pointer to an <c>OVERLAPPED</c> data structure that contains the data used for asynchronous I/O.</para>
		/// <para>If this parameter is <c>NULL</c>, all I/O requests for the hFile parameter are canceled.</para>
		/// <para>
		/// If this parameter is not <c>NULL</c>, only those specific I/O requests that were issued for the file with the specified
		/// lpOverlapped overlapped structure are marked as canceled, meaning that you can cancel one or more requests, while the
		/// <c>CancelIo</c> function cancels all outstanding requests on a file handle.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero. The cancel operation for all pending I/O operations issued by the calling
		/// process for the specified file handle was successfully requested. The application must not free or reuse the <c>OVERLAPPED</c>
		/// structure associated with the canceled I/O operations until they have completed. The thread can use the
		/// <c>GetOverlappedResult</c> function to determine when the I/O operations themselves have been completed.
		/// </para>
		/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call the <c>GetLastError</c> function.</para>
		/// <para>If this function cannot find a request to cancel, the return value is 0 (zero), and <c>GetLastError</c> returns <c>ERROR_NOT_FOUND</c>.</para>
		/// </returns>
		// BOOL WINAPI CancelIoEx( _In_ HANDLE hFile, _In_opt_ LPOVERLAPPED lpOverlapped);// https://msdn.microsoft.com/en-us/library/windows/desktop/aa363792(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("IoAPI.h", MSDNShortId = "aa363792")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern unsafe bool CancelIoEx([In] HFILE hFile, [In] NativeOverlapped* lpOverlapped);

		/// <summary>Marks pending synchronous I/O operations that are issued by the specified thread as canceled.</summary>
		/// <param name="hThread">A handle to the thread.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call the <c>GetLastError</c> function.</para>
		/// <para>If this function cannot find a request to cancel, the return value is 0 (zero), and <c>GetLastError</c> returns <c>ERROR_NOT_FOUND</c>.</para>
		/// </returns>
		// BOOL WINAPI CancelSynchronousIo( _In_ HANDLE hThread); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363794(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("IoAPI.h", MSDNShortId = "aa363794")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern unsafe bool CancelSynchronousIo([In] HTHREAD hThread);

		/// <summary>
		/// <para>
		/// Creates an input/output (I/O) completion port and associates it with a specified file handle, or creates an I/O completion port
		/// that is not yet associated with a file handle, allowing association at a later time.
		/// </para>
		/// <para>
		/// Associating an instance of an opened file handle with an I/O completion port allows a process to receive notification of the
		/// completion of asynchronous I/O operations involving that file handle.
		/// </para>
		/// </summary>
		/// <param name="FileHandle">
		/// <para>An open file handle or <c>INVALID_HANDLE_VALUE</c>.</para>
		/// <para>The handle must be to an object that supports overlapped I/O.</para>
		/// <para>
		/// If a handle is provided, it has to have been opened for overlapped I/O completion. For example, you must specify the
		/// <c>FILE_FLAG_OVERLAPPED</c> flag when using the <c>CreateFile</c> function to obtain the handle.
		/// </para>
		/// <para>
		/// If <c>INVALID_HANDLE_VALUE</c> is specified, the function creates an I/O completion port without associating it with a file
		/// handle. In this case, the ExistingCompletionPort parameter must be <c>NULL</c> and the CompletionKey parameter is ignored.
		/// </para>
		/// </param>
		/// <param name="ExistingCompletionPort">
		/// <para>A handle to an existing I/O completion port or <c>NULL</c>.</para>
		/// <para>
		/// If this parameter specifies an existing I/O completion port, the function associates it with the handle specified by the
		/// FileHandle parameter. The function returns the handle of the existing I/O completion port if successful; it does not create a new
		/// I/O completion port.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the function creates a new I/O completion port and, if the FileHandle parameter is valid,
		/// associates it with the new I/O completion port. Otherwise no file handle association occurs. The function returns the handle to
		/// the new I/O completion port if successful.
		/// </para>
		/// </param>
		/// <param name="CompletionKey">
		/// The per-handle user-defined completion key that is included in every I/O completion packet for the specified file handle. For
		/// more information, see the Remarks section.
		/// </param>
		/// <param name="NumberOfConcurrentThreads">
		/// <para>
		/// The maximum number of threads that the operating system can allow to concurrently process I/O completion packets for the I/O
		/// completion port. This parameter is ignored if the ExistingCompletionPort parameter is not <c>NULL</c>.
		/// </para>
		/// <para>If this parameter is zero, the system allows as many concurrently running threads as there are processors in the system.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the handle to an I/O completion port:</para>
		/// <list type="bullet">
		/// <item>
		/// <term/>
		/// </item>
		/// <item>
		/// <term/>
		/// </item>
		/// <item>
		/// <term/>
		/// </item>
		/// </list>
		/// <para>
		/// If the function fails, the return value is <c>NULL</c>. To get extended error information, call the <c>GetLastError</c> function.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The I/O system can be instructed to send I/O completion notification packets to I/O completion ports, where they are queued. The
		/// <c>CreateIoCompletionPort</c> function provides this functionality.
		/// </para>
		/// <para>
		/// An I/O completion port and its handle are associated with the process that created it and is not sharable between processes.
		/// However, a single handle is sharable between threads in the same process.
		/// </para>
		/// <para><c>CreateIoCompletionPort</c> can be used in three distinct modes:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Create only an I/O completion port without associating it with a file handle.</term>
		/// </item>
		/// <item>
		/// <term>Associate an existing I/O completion port with a file handle.</term>
		/// </item>
		/// <item>
		/// <term>Perform both creation and association in a single call.</term>
		/// </item>
		/// </list>
		/// <para>
		/// To create an I/O completion port without associating it, set the FileHandle parameter to <c>INVALID_HANDLE_VALUE</c>, the
		/// ExistingCompletionPort parameter to <c>NULL</c>, and the CompletionKey parameter to zero (which is ignored in this case). Set the
		/// NumberOfConcurrentThreads parameter to the desired concurrency value for the new I/O completion port, or zero for the default
		/// (the number of processors in the system).
		/// </para>
		/// <para>
		/// The handle passed in the FileHandle parameter can be any handle that supports overlapped I/O. Most commonly, this is a handle
		/// opened by the <c>CreateFile</c> function using the <c>FILE_FLAG_OVERLAPPED</c> flag (for example, files, mail slots, and pipes).
		/// Objects created by other functions such as <c>socket</c> can also be associated with an I/O completion port. For an example using
		/// sockets, see <c>AcceptEx</c>. A handle can be associated with only one I/O completion port, and after the association is made,
		/// the handle remains associated with that I/O completion port until it is closed.
		/// </para>
		/// <para>For more information on I/O completion port theory, usage, and associated functions, see I/O Completion Ports.</para>
		/// <para>
		/// Multiple file handles can be associated with a single I/O completion port by calling <c>CreateIoCompletionPort</c> multiple times
		/// with the same I/O completion port handle in the ExistingCompletionPort parameter and a different file handle in the FileHandle
		/// parameter each time.
		/// </para>
		/// <para>
		/// Use the CompletionKey parameter to help your application track which I/O operations have completed. This value is not used by
		/// <c>CreateIoCompletionPort</c> for functional control; rather, it is attached to the file handle specified in the FileHandle
		/// parameter at the time of association with an I/O completion port. This completion key should be unique for each file handle, and
		/// it accompanies the file handle throughout the internal completion queuing process. It is returned in the
		/// <c>GetQueuedCompletionStatus</c> function call when a completion packet arrives. The CompletionKey parameter is also used by the
		/// <c>PostQueuedCompletionStatus</c> function to queue your own special-purpose completion packets.
		/// </para>
		/// <para>
		/// After an instance of an open handle is associated with an I/O completion port, it cannot be used in the <c>ReadFileEx</c> or
		/// <c>WriteFileEx</c> function because these functions have their own asynchronous I/O mechanisms.
		/// </para>
		/// <para>
		/// It is best not to share a file handle associated with an I/O completion port by using either handle inheritance or a call to the
		/// <c>DuplicateHandle</c> function. Operations performed with such duplicate handles generate completion notifications. Careful
		/// consideration is advised.
		/// </para>
		/// <para>
		/// The I/O completion port handle and every file handle associated with that particular I/O completion port are known as references
		/// to the I/O completion port. The I/O completion port is released when there are no more references to it. Therefore, all of these
		/// handles must be properly closed to release the I/O completion port and its associated system resources. After these conditions
		/// are satisfied, close the I/O completion port handle by calling the <c>CloseHandle</c> function.
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
		// https://docs.microsoft.com/en-us/windows/desktop/FileIO/createiocompletionport
		// HANDLE WINAPI CreateIoCompletionPort( _In_ HANDLE FileHandle, _In_opt_ HANDLE ExistingCompletionPort, _In_ ULONG_PTR CompletionKey, _In_ DWORD NumberOfConcurrentThreads );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("IoAPI.h", MSDNShortId = "40cb47fc-7b15-47f6-bee2-2611d4686053")]
		public static extern HANDLE CreateIoCompletionPort([In] HANDLE FileHandle, [In, Optional] HANDLE ExistingCompletionPort, UIntPtr CompletionKey, uint NumberOfConcurrentThreads);

		/// <summary>This macro is used to create a unique system I/O control code (IOCTL).</summary>
		/// <param name="deviceType">
		/// Defines the type of device for the given IOCTL. This parameter can be no bigger then a WORD value. The values used by Microsoft
		/// are in the range 0-32767 and the values 32768-65535 are reserved for use by OEMs and IHVs.
		/// </param>
		/// <param name="function">
		/// Defines an action within the device category. That function codes 0-2047 are reserved for Microsoft, and 2048-4095 are reserved
		/// for OEMs and IHVs. The function code can be no larger then 4095.
		/// </param>
		/// <param name="method">
		/// Defines the method codes for how buffers are passed for I/O and file system controls. The following list shows the possible
		/// values for this parameter:
		/// <list type="bullet">
		/// <item>
		/// <description>METHOD_BUFFERED</description>
		/// </item>
		/// <item>
		/// <description>METHOD_IN_DIRECT</description>
		/// </item>
		/// <item>
		/// <description>METHOD_OUT_DIRECT</description>
		/// </item>
		/// <item>
		/// <description>METHOD_NEITHER</description>
		/// </item>
		/// </list>
		/// <para>
		/// This field is ignored under Windows CE and you should always use the METHOD_BUFFERED value unless compatibility with the desktop
		/// is required using a different Method value.
		/// </para>
		/// </param>
		/// <param name="access">
		/// Defines the access check value for any access. The following table shows the possible flags for this parameter. The
		/// FILE_ACCESS_ANY is generally the correct value.
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_ANY_ACCESS</term>
		/// <term>Request all access.</term>
		/// </item>
		/// <item>
		/// <term>FILE_READ_ACCESS</term>
		/// <term>Request read access. Can be used with FILE_WRITE_ACCESS.</term>
		/// </item>
		/// <item>
		/// <term>FILE_WRITE_ACCESS</term>
		/// <term>Request write access. Can be used with FILE_READ_ACCESS.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The resulting I/O control code.</returns>
		/// <exception cref="ArgumentOutOfRangeException">function</exception>
		public static uint CTL_CODE(ushort deviceType, ushort function, byte method, byte access)
		{
			if (function > 0xfff)
				throw new ArgumentOutOfRangeException(nameof(function));
			return (uint)((deviceType << 0x10) | (access << 14) | (function << 2) | method);
		}

		/// <summary>This macro is used to create a unique system I/O control code (IOCTL).</summary>
		/// <param name="deviceType">
		/// Defines the type of device for the given IOCTL. This parameter can be no bigger then a WORD value. The values used by Microsoft
		/// are in the range 0-32767 and the values 32768-65535 are reserved for use by OEMs and IHVs.
		/// </param>
		/// <param name="function">
		/// Defines an action within the device category. That function codes 0-2047 are reserved for Microsoft, and 2048-4095 are reserved
		/// for OEMs and IHVs. The function code can be no larger then 4095.
		/// </param>
		/// <param name="method">
		/// Defines the method codes for how buffers are passed for I/O and file system controls.
		/// <para>
		/// This field is ignored under Windows CE and you should always use the METHOD_BUFFERED value unless compatibility with the desktop
		/// is required using a different Method value.
		/// </para>
		/// </param>
		/// <param name="access">Defines the access check value for any access.</param>
		/// <returns>The resulting I/O control code.</returns>
		public static uint CTL_CODE(DEVICE_TYPE deviceType, ushort function, IOMethod method, IOAccess access) =>
			CTL_CODE((ushort)deviceType, function, (byte)method, (byte)access);

		/// <summary>
		/// Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.
		/// </summary>
		/// <param name="hDevice">
		/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream.
		/// To retrieve a device handle, use the CreateFile function. For more information, see Remarks.
		/// </param>
		/// <param name="dwIoControlCode">
		/// The control code for the operation. This value identifies the specific operation to be performed and the type of device on which
		/// to perform it.
		/// </param>
		/// <param name="lpInBuffer">
		/// A pointer to the input buffer that contains the data required to perform the operation. The format of this data depends on the
		/// value of the dwIoControlCode parameter.
		/// <para>This parameter can be NULL if dwIoControlCode specifies an operation that does not require input data.</para>
		/// </param>
		/// <param name="nInBufferSize">The size of the input buffer, in bytes.</param>
		/// <param name="lpOutBuffer">
		/// A pointer to the output buffer that is to receive the data returned by the operation. The format of this data depends on the
		/// value of the dwIoControlCode parameter.
		/// <para>This parameter can be NULL if dwIoControlCode specifies an operation that does not return data.</para>
		/// </param>
		/// <param name="nOutBufferSize">The size of the output buffer, in bytes.</param>
		/// <param name="lpBytesReturned">
		/// A pointer to a variable that receives the size of the data stored in the output buffer, in bytes.
		/// <para>
		/// If the output buffer is too small to receive any data, the call fails, GetLastError returns ERROR_INSUFFICIENT_BUFFER, and
		/// lpBytesReturned is zero.
		/// </para>
		/// <para>
		/// If the output buffer is too small to hold all of the data but can hold some entries, some drivers will return as much data as
		/// fits. In this case, the call fails, GetLastError returns ERROR_MORE_DATA, and lpBytesReturned indicates the amount of data
		/// received. Your application should call DeviceIoControl again with the same operation, specifying a new starting point.
		/// </para>
		/// <para>
		/// If lpOverlapped is NULL, lpBytesReturned cannot be NULL. Even when an operation returns no output data and lpOutBuffer is NULL,
		/// DeviceIoControl makes use of lpBytesReturned. After such an operation, the value of lpBytesReturned is meaningless.
		/// </para>
		/// <para>
		/// If lpOverlapped is not NULL, lpBytesReturned can be NULL. If this parameter is not NULL and the operation returns data,
		/// lpBytesReturned is meaningless until the overlapped operation has completed. To retrieve the number of bytes returned, call
		/// GetOverlappedResult. If hDevice is associated with an I/O completion port, you can retrieve the number of bytes returned by
		/// calling GetQueuedCompletionStatus.
		/// </para>
		/// </param>
		/// <param name="lpOverlapped">
		/// A pointer to an OVERLAPPED structure.
		/// <para>If hDevice was opened without specifying FILE_FLAG_OVERLAPPED, lpOverlapped is ignored.</para>
		/// <para>
		/// If hDevice was opened with the FILE_FLAG_OVERLAPPED flag, the operation is performed as an overlapped (asynchronous) operation.
		/// In this case, lpOverlapped must point to a valid OVERLAPPED structure that contains a handle to an event object. Otherwise, the
		/// function fails in unpredictable ways.
		/// </para>
		/// <para>
		/// For overlapped operations, DeviceIoControl returns immediately, and the event object is signaled when the operation has been
		/// completed. Otherwise, the function does not return until the operation has been completed or an error occurs.
		/// </para>
		/// </param>
		/// <returns>
		/// If the operation completes successfully, the return value is nonzero.
		/// <para>If the operation fails or is pending, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To retrieve a handle to the device, you must call the CreateFile function with either the name of a device or the name of the
		/// driver associated with a device. To specify a device name, use the following format:
		/// </para>
		/// <para>\\.\DeviceName</para>
		/// <para>
		/// DeviceIoControl can accept a handle to a specific device. For example, to open a handle to the logical drive
		/// A: with CreateFile, specify \\.\a:. Alternatively, you can use the names \\.\PhysicalDrive0, \\.\PhysicalDrive1, and so on, to
		/// open handles to the physical drives on a system.
		/// </para>
		/// <para>
		/// You should specify the FILE_SHARE_READ and FILE_SHARE_WRITE access flags when calling CreateFile to open a handle to a device
		/// driver. However, when you open a communications resource, such as a serial port, you must specify exclusive access. Use the other
		/// CreateFile parameters as follows when opening a device handle:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>The fdwCreate parameter must specify OPEN_EXISTING.</description>
		/// </item>
		/// <item>
		/// <description>The hTemplateFile parameter must be NULL.</description>
		/// </item>
		/// <item>
		/// <description>
		/// The fdwAttrsAndFlags parameter can specify FILE_FLAG_OVERLAPPED to indicate that the returned handle can be used in overlapped
		/// (asynchronous) I/O operations.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static extern bool DeviceIoControl(HFILE hDevice, uint dwIoControlCode, IntPtr lpInBuffer, uint nInBufferSize, IntPtr lpOutBuffer,
			uint nOutBufferSize, out uint lpBytesReturned, IntPtr lpOverlapped);

		/// <summary>
		/// Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.
		/// </summary>
		/// <param name="hDevice">
		/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream.
		/// To retrieve a device handle, use the CreateFile function. For more information, see Remarks.
		/// </param>
		/// <param name="dwIoControlCode">
		/// The control code for the operation. This value identifies the specific operation to be performed and the type of device on which
		/// to perform it.
		/// </param>
		/// <param name="lpInBuffer">
		/// A pointer to the input buffer that contains the data required to perform the operation. The format of this data depends on the
		/// value of the dwIoControlCode parameter.
		/// <para>This parameter can be NULL if dwIoControlCode specifies an operation that does not require input data.</para>
		/// </param>
		/// <param name="nInBufferSize">The size of the input buffer, in bytes.</param>
		/// <param name="lpOutBuffer">
		/// A pointer to the output buffer that is to receive the data returned by the operation. The format of this data depends on the
		/// value of the dwIoControlCode parameter.
		/// <para>This parameter can be NULL if dwIoControlCode specifies an operation that does not return data.</para>
		/// </param>
		/// <param name="nOutBufferSize">The size of the output buffer, in bytes.</param>
		/// <param name="lpBytesReturned">
		/// A pointer to a variable that receives the size of the data stored in the output buffer, in bytes.
		/// <para>
		/// If the output buffer is too small to receive any data, the call fails, GetLastError returns ERROR_INSUFFICIENT_BUFFER, and
		/// lpBytesReturned is zero.
		/// </para>
		/// <para>
		/// If the output buffer is too small to hold all of the data but can hold some entries, some drivers will return as much data as
		/// fits. In this case, the call fails, GetLastError returns ERROR_MORE_DATA, and lpBytesReturned indicates the amount of data
		/// received. Your application should call DeviceIoControl again with the same operation, specifying a new starting point.
		/// </para>
		/// <para>
		/// If lpOverlapped is NULL, lpBytesReturned cannot be NULL. Even when an operation returns no output data and lpOutBuffer is NULL,
		/// DeviceIoControl makes use of lpBytesReturned. After such an operation, the value of lpBytesReturned is meaningless.
		/// </para>
		/// <para>
		/// If lpOverlapped is not NULL, lpBytesReturned can be NULL. If this parameter is not NULL and the operation returns data,
		/// lpBytesReturned is meaningless until the overlapped operation has completed. To retrieve the number of bytes returned, call
		/// GetOverlappedResult. If hDevice is associated with an I/O completion port, you can retrieve the number of bytes returned by
		/// calling GetQueuedCompletionStatus.
		/// </para>
		/// </param>
		/// <param name="lpOverlapped">
		/// A pointer to an OVERLAPPED structure.
		/// <para>If hDevice was opened without specifying FILE_FLAG_OVERLAPPED, lpOverlapped is ignored.</para>
		/// <para>
		/// If hDevice was opened with the FILE_FLAG_OVERLAPPED flag, the operation is performed as an overlapped (asynchronous) operation.
		/// In this case, lpOverlapped must point to a valid OVERLAPPED structure that contains a handle to an event object. Otherwise, the
		/// function fails in unpredictable ways.
		/// </para>
		/// <para>
		/// For overlapped operations, DeviceIoControl returns immediately, and the event object is signaled when the operation has been
		/// completed. Otherwise, the function does not return until the operation has been completed or an error occurs.
		/// </para>
		/// </param>
		/// <returns>
		/// If the operation completes successfully, the return value is nonzero.
		/// <para>If the operation fails or is pending, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To retrieve a handle to the device, you must call the CreateFile function with either the name of a device or the name of the
		/// driver associated with a device. To specify a device name, use the following format:
		/// </para>
		/// <para>\\.\DeviceName</para>
		/// <para>
		/// DeviceIoControl can accept a handle to a specific device. For example, to open a handle to the logical drive
		/// A: with CreateFile, specify \\.\a:. Alternatively, you can use the names \\.\PhysicalDrive0, \\.\PhysicalDrive1, and so on, to
		/// open handles to the physical drives on a system.
		/// </para>
		/// <para>
		/// You should specify the FILE_SHARE_READ and FILE_SHARE_WRITE access flags when calling CreateFile to open a handle to a device
		/// driver. However, when you open a communications resource, such as a serial port, you must specify exclusive access. Use the other
		/// CreateFile parameters as follows when opening a device handle:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>The fdwCreate parameter must specify OPEN_EXISTING.</description>
		/// </item>
		/// <item>
		/// <description>The hTemplateFile parameter must be NULL.</description>
		/// </item>
		/// <item>
		/// <description>
		/// The fdwAttrsAndFlags parameter can specify FILE_FLAG_OVERLAPPED to indicate that the returned handle can be used in overlapped
		/// (asynchronous) I/O operations.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static extern unsafe bool DeviceIoControl(HFILE hDevice, uint dwIoControlCode, byte* lpInBuffer, uint nInBufferSize, byte* lpOutBuffer,
			uint nOutBufferSize, out uint lpBytesReturned, NativeOverlapped* lpOverlapped);

		/// <summary>
		/// Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.
		/// </summary>
		/// <typeparam name="TIn">The type of the <paramref name="inVal"/>.</typeparam>
		/// <typeparam name="TOut">The type of the <paramref name="outVal"/>.</typeparam>
		/// <param name="hDev">
		/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream.
		/// To retrieve a device handle, use the CreateFile function. For more information, see Remarks.
		/// </param>
		/// <param name="ioControlCode">
		/// The control code for the operation. This value identifies the specific operation to be performed and the type of device on which
		/// to perform it.
		/// </param>
		/// <param name="inVal">
		/// The data required to perform the operation. The format of this data depends on the value of the dwIoControlCode parameter.
		/// </param>
		/// <param name="outVal">
		/// The data returned by the operation. The format of this data depends on the value of the dwIoControlCode parameter.
		/// </param>
		/// <returns><c>true</c> if successful.</returns>
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static bool DeviceIoControl<TIn, TOut>(HFILE hDev, uint ioControlCode, TIn inVal, out TOut outVal) where TIn : struct where TOut : struct
		{
			using (SafeHGlobalHandle ptrIn = SafeHGlobalHandle.CreateFromStructure(inVal), ptrOut = SafeHGlobalHandle.CreateFromStructure<TOut>())
			{
				var ret = DeviceIoControl(hDev, ioControlCode, (IntPtr)ptrIn, (uint)ptrIn.Size, (IntPtr)ptrOut, (uint)ptrOut.Size, out var bRet, IntPtr.Zero);
				outVal = ptrOut.ToStructure<TOut>();
				return ret;
			}
		}

		/// <summary>
		/// Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.
		/// </summary>
		/// <typeparam name="TOut">The type of the <paramref name="outVal"/>.</typeparam>
		/// <param name="hDev">
		/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream.
		/// To retrieve a device handle, use the CreateFile function. For more information, see Remarks.
		/// </param>
		/// <param name="ioControlCode">
		/// The control code for the operation. This value identifies the specific operation to be performed and the type of device on which
		/// to perform it.
		/// </param>
		/// <param name="outVal">
		/// The data returned by the operation. The format of this data depends on the value of the dwIoControlCode parameter.
		/// </param>
		/// <returns><c>true</c> if successful.</returns>
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static bool DeviceIoControl<TOut>(HFILE hDev, uint ioControlCode, out TOut outVal) where TOut : struct
		{
			using (var ptrOut = SafeHGlobalHandle.CreateFromStructure<TOut>())
			{
				var ret = DeviceIoControl(hDev, ioControlCode, IntPtr.Zero, 0, (IntPtr)ptrOut, (uint)ptrOut.Size, out var bRet, IntPtr.Zero);
				outVal = ptrOut.ToStructure<TOut>();
				return ret;
			}
		}

		/// <summary>
		/// Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.
		/// </summary>
		/// <typeparam name="TIn">The type of the <paramref name="inVal"/>.</typeparam>
		/// <param name="hDev">
		/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream.
		/// To retrieve a device handle, use the CreateFile function. For more information, see Remarks.
		/// </param>
		/// <param name="ioControlCode">
		/// The control code for the operation. This value identifies the specific operation to be performed and the type of device on which
		/// to perform it.
		/// </param>
		/// <param name="inVal">
		/// The data required to perform the operation. The format of this data depends on the value of the dwIoControlCode parameter.
		/// </param>
		/// <returns><c>true</c> if successful.</returns>
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static bool DeviceIoControl<TIn>(HFILE hDev, uint ioControlCode, TIn inVal) where TIn : struct
		{
			using (var ptrIn = SafeHGlobalHandle.CreateFromStructure(inVal))
			{
				return DeviceIoControl(hDev, ioControlCode, (IntPtr)ptrIn, (uint)ptrIn.Size, IntPtr.Zero, 0, out var bRet, IntPtr.Zero);
			}
		}

		/// <summary>Ends the asynchronous call to <c>BeginDeviceIoControl&lt;TIn, TOut&gt;(HFILE, uint, TIn?, TOut?, AsyncCallback)</c>.</summary>
		/// <typeparam name="TIn">The type of the input value.</typeparam>
		/// <typeparam name="TOut">The type of the output value.</typeparam>
		/// <param name="asyncResult">The asynchronous result returned from <c>BeginDeviceIoControl&gt;TIn, TOut&lt;(HFILE, uint, TIn?, TOut?, AsyncCallback)</c>.</param>
		/// <returns>The output value, if exists; <c>null</c> otherwise.</returns>
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static TOut? EndDeviceIoControl<TIn, TOut>(IAsyncResult asyncResult) where TIn : struct where TOut : struct
		{
			var ret = OverlappedAsync.EndOverlappedFunction(asyncResult);
			return Unpack<TIn, TOut>(ret as byte[]).Item2;
		}

		/// <summary>Ends the asynchronous call to <c>BeginDeviceIoControl&lt;TIn, TOut&gt;(HFILE, uint, TIn?, TOut?, AsyncCallback)</c>.</summary>
		/// <param name="asyncResult">
		/// The asynchronous result returned from <c>BeginDeviceIoControl&lt;TIn, TOut&gt;(HFILE, uint, TIn?, TOut?, AsyncCallback)</c>.
		/// </param>
		/// <returns>The output buffer, if exists; <c>null</c> otherwise.</returns>
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static byte[] EndDeviceIoControl(IAsyncResult asyncResult)
		{
			var ret = OverlappedAsync.EndOverlappedFunction(asyncResult);
			return Unpack(ret as byte[]).Item2;
		}

		/// <summary>
		/// Retrieves the results of an overlapped operation on the specified file, named pipe, or communications device. To specify a
		/// timeout interval or wait on an alertable thread, use <c>GetOverlappedResultEx</c>.
		/// </summary>
		/// <param name="hFile">
		/// A handle to the file, named pipe, or communications device. This is the same handle that was specified when the overlapped
		/// operation was started by a call to the <c>ReadFile</c>, <c>WriteFile</c>, <c>ConnectNamedPipe</c>, <c>TransactNamedPipe</c>,
		/// <c>DeviceIoControl</c>, or <c>WaitCommEvent</c> function.
		/// </param>
		/// <param name="lpOverlapped">
		/// A pointer to an <c>OVERLAPPED</c> structure that was specified when the overlapped operation was started.
		/// </param>
		/// <param name="lpNumberOfBytesTransferred">
		/// A pointer to a variable that receives the number of bytes that were actually transferred by a read or write operation. For a
		/// <c>TransactNamedPipe</c> operation, this is the number of bytes that were read from the pipe. For a <c>DeviceIoControl</c>
		/// operation, this is the number of bytes of output data returned by the device driver. For a <c>ConnectNamedPipe</c> or
		/// <c>WaitCommEvent</c> operation, this value is undefined.
		/// </param>
		/// <param name="bWait">
		/// If this parameter is <c>TRUE</c>, and the <c>Internal</c> member of the lpOverlapped structure is <c>STATUS_PENDING</c>, the
		/// function does not return until the operation has been completed. If this parameter is <c>FALSE</c> and the operation is still
		/// pending, the function returns <c>FALSE</c> and the <c>GetLastError</c> function returns <c>ERROR_IO_INCOMPLETE</c>.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetOverlappedResult( _In_ HANDLE hFile, _In_ LPOVERLAPPED lpOverlapped, _Out_ LPDWORD lpNumberOfBytesTransferred, _In_
		// BOOL bWait); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683209(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683209")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern unsafe bool GetOverlappedResult([In] HFILE hFile, [In] NativeOverlapped* lpOverlapped, out uint lpNumberOfBytesTransferred, [MarshalAs(UnmanagedType.Bool)] bool bWait);

		/// <summary>
		/// Retrieves the results of an overlapped operation on the specified file, named pipe, or communications device within the specified
		/// time-out interval. The calling thread can perform an alertable wait.
		/// </summary>
		/// <param name="hFile">
		/// A handle to the file, named pipe, or communications device. This is the same handle that was specified when the overlapped
		/// operation was started by a call to the <c>ReadFile</c>, <c>WriteFile</c>, <c>ConnectNamedPipe</c>, <c>TransactNamedPipe</c>,
		/// <c>DeviceIoControl</c>, or <c>WaitCommEvent</c> function.
		/// </param>
		/// <param name="lpOverlapped">
		/// A pointer to an <c>OVERLAPPED</c> structure that was specified when the overlapped operation was started.
		/// </param>
		/// <param name="lpNumberOfBytesTransferred">
		/// A pointer to a variable that receives the number of bytes that were actually transferred by a read or write operation. For a
		/// <c>TransactNamedPipe</c> operation, this is the number of bytes that were read from the pipe. For a <c>DeviceIoControl</c>
		/// operation, this is the number of bytes of output data returned by the device driver. For a <c>ConnectNamedPipe</c> or
		/// <c>WaitCommEvent</c> operation, this value is undefined.
		/// </param>
		/// <param name="dwMilliseconds">
		/// <para>The time-out interval, in milliseconds.</para>
		/// <para>
		/// If dwMilliseconds is zero and the operation is still in progress, the function returns immediately and the <c>GetLastError</c>
		/// function returns <c>ERROR_IO_INCOMPLETE</c>.
		/// </para>
		/// <para>
		/// If dwMilliseconds is nonzero and the operation is still in progress, the function waits until the object is signaled, an I/O
		/// completion routine or APC is queued, or the interval elapses before returning. Use <c>GetLastError</c> to get extended error information.
		/// </para>
		/// <para>
		/// If dwMilliseconds is <c>INFINITE</c>, the function returns only when the object is signaled or an I/O completion routine or APC
		/// is queued.
		/// </para>
		/// </param>
		/// <param name="bAlertable">
		/// <para>
		/// If this parameter is <c>TRUE</c> and the calling thread is in the waiting state, the function returns when the system queues an
		/// I/O completion routine or APC. The calling thread then runs the routine or function. Otherwise, the function does not return, and
		/// the completion routine or APC function is not executed.
		/// </para>
		/// <para>
		/// A completion routine is queued when the <c>ReadFileEx</c> or <c>WriteFileEx</c> function in which it was specified has completed.
		/// The function returns and the completion routine is called only if bAlertable is <c>TRUE</c>, and the calling thread is the thread
		/// that initiated the read or write operation. An APC is queued when you call <c>QueueUserAPC</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. Common error codes
		/// include the following:
		/// </para>
		/// </returns>
		// WINBASEAPI BOOL WINAPI GetOverlappedResultEx( _In_ HANDLE hFile, _In_ LPOVERLAPPED lpOverlapped, _Out_ LPDWORD
		// lpNumberOfBytesTransferred, _In_ DWORD dwMilliseconds, _In_ BOOL bAlertable); https://msdn.microsoft.com/en-us/library/windows/desktop/hh448542(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Ioapiset.h", MSDNShortId = "hh448542")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern unsafe bool GetOverlappedResultEx([In] HFILE hFile, [In] NativeOverlapped* lpOverlapped, out uint lpNumberOfBytesTransferred, uint dwMilliseconds, [MarshalAs(UnmanagedType.Bool)] bool bAlertable);

		/// <summary>
		/// <para>
		/// Attempts to dequeue an I/O completion packet from the specified I/O completion port. If there is no completion packet queued, the
		/// function waits for a pending I/O operation associated with the completion port to complete.
		/// </para>
		/// <para>To dequeue multiple I/O completion packets at once, use the <c>GetQueuedCompletionStatusEx</c> function.</para>
		/// </summary>
		/// <param name="CompletionPort">
		/// A handle to the completion port. To create a completion port, use the <c>CreateIoCompletionPort</c> function.
		/// </param>
		/// <param name="lpNumberOfBytes">
		/// A pointer to a variable that receives the number of bytes transferred during an I/O operation that has completed.
		/// </param>
		/// <param name="lpCompletionKey">
		/// A pointer to a variable that receives the completion key value associated with the file handle whose I/O operation has completed.
		/// A completion key is a per-file key that is specified in a call to <c>CreateIoCompletionPort</c>.
		/// </param>
		/// <param name="lpOverlapped">
		/// <para>
		/// A pointer to a variable that receives the address of the <c>OVERLAPPED</c> structure that was specified when the completed I/O
		/// operation was started.
		/// </para>
		/// <para>
		/// Even if you have passed the function a file handle associated with a completion port and a valid <c>OVERLAPPED</c> structure, an
		/// application can prevent completion port notification. This is done by specifying a valid event handle for the <c>hEvent</c>
		/// member of the <c>OVERLAPPED</c> structure, and setting its low-order bit. A valid event handle whose low-order bit is set keeps
		/// I/O completion from being queued to the completion port.
		/// </para>
		/// </param>
		/// <param name="dwMilliseconds">
		/// <para>
		/// The number of milliseconds that the caller is willing to wait for a completion packet to appear at the completion port. If a
		/// completion packet does not appear within the specified time, the function times out, returns <c>FALSE</c>, and sets *lpOverlapped
		/// to <c>NULL</c>.
		/// </para>
		/// <para>
		/// If dwMilliseconds is <c>INFINITE</c>, the function will never time out. If dwMilliseconds is zero and there is no I/O operation
		/// to dequeue, the function will time out immediately.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Returns nonzero ( <c>TRUE</c>) if successful or zero ( <c>FALSE</c>) otherwise.</para>
		/// <para>To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>For more information, see the Remarks section.</para>
		/// </returns>
		// BOOL WINAPI GetQueuedCompletionStatus( _In_ HANDLE CompletionPort, _Out_ LPDWORD lpNumberOfBytes, _Out_ PULONG_PTR
		// lpCompletionKey, _Out_ LPOVERLAPPED
		// *lpOverlapped, _In_ DWORD dwMilliseconds); https://msdn.microsoft.com/en-us/library/windows/desktop/aa364986(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa364986")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern unsafe bool GetQueuedCompletionStatus([In] HANDLE CompletionPort, out uint lpNumberOfBytes, out uint lpCompletionKey, NativeOverlapped** lpOverlapped, uint dwMilliseconds);

		/// <summary>
		/// <para>
		/// Retrieves multiple completion port entries simultaneously. It waits for pending I/O operations that are associated with the
		/// specified completion port to complete.
		/// </para>
		/// <para>To dequeue I/O completion packets one at a time, use the <c>GetQueuedCompletionStatus</c> function.</para>
		/// </summary>
		/// <param name="CompletionPort">
		/// A handle to the completion port. To create a completion port, use the <c>CreateIoCompletionPort</c> function.
		/// </param>
		/// <param name="lpCompletionPortEntries">
		/// <para>On input, points to a pre-allocated array of <c>OVERLAPPED_ENTRY</c> structures.</para>
		/// <para>
		/// On output, receives an array of <c>OVERLAPPED_ENTRY</c> structures that hold the entries. The number of array elements is
		/// provided by ulNumEntriesRemoved.
		/// </para>
		/// <para>
		/// The number of bytes transferred during each I/O, the completion key that indicates on which file each I/O occurred, and the
		/// overlapped structure address used in each original I/O are all returned in the lpCompletionPortEntries array.
		/// </para>
		/// </param>
		/// <param name="ulCount">The maximum number of entries to remove.</param>
		/// <param name="ulNumEntriesRemoved">A pointer to a variable that receives the number of entries actually removed.</param>
		/// <param name="dwMilliseconds">
		/// <para>
		/// The number of milliseconds that the caller is willing to wait for a completion packet to appear at the completion port. If a
		/// completion packet does not appear within the specified time, the function times out and returns <c>FALSE</c>.
		/// </para>
		/// <para>
		/// If dwMilliseconds is <c>INFINITE</c> (0xFFFFFFFF), the function will never time out. If dwMilliseconds is zero and there is no
		/// I/O operation to dequeue, the function will time out immediately.
		/// </para>
		/// </param>
		/// <param name="fAlertable">
		/// <para>If this parameter is <c>FALSE</c>, the function does not return until the time-out period has elapsed or an entry is retrieved.</para>
		/// <para>
		/// If the parameter is <c>TRUE</c> and there are no available entries, the function performs an alertable wait. The thread returns
		/// when the system queues an I/O completion routine or APC to the thread and the thread executes the function.
		/// </para>
		/// <para>
		/// A completion routine is queued when the <c>ReadFileEx</c> or <c>WriteFileEx</c> function in which it was specified has completed,
		/// and the calling thread is the thread that initiated the operation. An APC is queued when you call <c>QueueUserAPC</c>.
		/// </para>
		/// </param>
		// BOOL WINAPI GetQueuedCompletionStatusEx( _In_ HANDLE CompletionPort, _Out_ LPOVERLAPPED_ENTRY lpCompletionPortEntries, _In_ ULONG
		// ulCount, _Out_ PULONG ulNumEntriesRemoved, _In_ DWORD dwMilliseconds, _In_ BOOL fAlertable); https://msdn.microsoft.com/en-us/library/windows/desktop/aa364988(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("IoAPI.h", MSDNShortId = "aa364988")]
		public static extern void GetQueuedCompletionStatusEx(HANDLE CompletionPort, IntPtr lpCompletionPortEntries, uint ulCount, out uint ulNumEntriesRemoved, uint dwMilliseconds, [MarshalAs(UnmanagedType.Bool)] bool fAlertable);

		/// <summary>Posts an I/O completion packet to an I/O completion port.</summary>
		/// <param name="CompletionPort">A handle to an I/O completion port to which the I/O completion packet is to be posted.</param>
		/// <param name="dwNumberOfBytesTransferred">
		/// The value to be returned through the lpNumberOfBytesTransferred parameter of the <c>GetQueuedCompletionStatus</c> function.
		/// </param>
		/// <param name="dwCompletionKey">
		/// The value to be returned through the lpCompletionKey parameter of the <c>GetQueuedCompletionStatus</c> function.
		/// </param>
		/// <param name="lpOverlapped">
		/// The value to be returned through the lpOverlapped parameter of the <c>GetQueuedCompletionStatus</c> function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c> .</para>
		/// </returns>
		// BOOL WINAPI PostQueuedCompletionStatus( _In_ HANDLE CompletionPort, _In_ DWORD dwNumberOfBytesTransferred, _In_ ULONG_PTR
		// dwCompletionKey, _In_opt_ LPOVERLAPPED lpOverlapped); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365458(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("IoAPI.h", MSDNShortId = "aa365458")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern unsafe bool PostQueuedCompletionStatus([In] HANDLE CompletionPort, uint dwNumberOfBytesTransferred, UIntPtr dwCompletionKey, NativeOverlapped* lpOverlapped);

		private static unsafe IAsyncResult BeginDeviceIoControl<TIn, TOut>(HFILE hDevice, uint dwIoControlCode, byte[] buffer, AsyncCallback userCallback, object userState) where TIn : struct where TOut : struct =>
			BeginDeviceIoControl(hDevice, dwIoControlCode, buffer, userCallback, userState);

		private static unsafe IAsyncResult BeginDeviceIoControl(HFILE hDevice, uint dwIoControlCode, byte[] buffer, AsyncCallback userCallback, object userState)
		{
			var ar = OverlappedAsync.SetupOverlappedFunction(hDevice, userCallback, buffer);
			var intSz = Marshal.SizeOf(typeof(int));
			var inSz = BitConverter.ToInt32(buffer, 0);
			var outSz = BitConverter.ToInt32(buffer, intSz);
			fixed (byte* pIn = &buffer[intSz * 2], pOut = &buffer[outSz == 0 ? 0 : intSz * 2 + inSz])
			{
				var ret = DeviceIoControl(hDevice, dwIoControlCode, pIn, (uint)inSz, pOut, (uint)outSz, out var bRet, ar.Overlapped);
				return OverlappedAsync.EvaluateOverlappedFunction(ar, ret);
			}
		}

		private static T MemRead<T>(byte[] buffer, ref int startIndex) where T : struct
		{
			using (var pin = new PinnedObject(buffer, startIndex))
			{
				startIndex += Marshal.SizeOf(typeof(T));
				return ((IntPtr)pin).ToStructure<T>();
			}
		}

		private static int MemWrite<T>(byte[] buffer, T value, int startIndex = 0) where T : struct
		{
			var sz = Marshal.SizeOf(typeof(T));
			using (var pin = new PinnedObject(value))
				Marshal.Copy(pin, buffer, startIndex, sz);
			return sz;
		}

		private static byte[] Pack<TIn, TOut>(TIn? inVal, TOut? outVal) where TIn : struct where TOut : struct
		{
			using (var ms = new MemoryStream())
			using (var wtr = new BinaryWriter(ms))
			{
				wtr.Write(inVal.HasValue ? Marshal.SizeOf(typeof(TIn)) : 0);
				wtr.Write(outVal.HasValue ? Marshal.SizeOf(typeof(TOut)) : 0);
				if (inVal.HasValue) wtr.Write(inVal.Value);
				if (outVal.HasValue) wtr.Write(outVal.Value);
				return ms.ToArray();
			}
		}

		private static byte[] Pack(byte[] inputBuffer, byte[] outputBuffer)
		{
			using (var ms = new MemoryStream())
			using (var wtr = new BinaryWriter(ms))
			{
				wtr.Write(inputBuffer != null ? inputBuffer.Length : 0);
				wtr.Write(outputBuffer != null ? outputBuffer.Length : 0);
				if (inputBuffer != null && inputBuffer.Length > 0)
					wtr.Write(inputBuffer);
				if (outputBuffer != null && outputBuffer.Length > 0)
					wtr.Write(outputBuffer);
				return ms.ToArray();
			}
		}

		private static Tuple<TIn?, TOut?> Unpack<TIn, TOut>(byte[] buffer) where TIn : struct where TOut : struct
		{
			using (var ms = new MemoryStream(buffer))
			using (var rdr = new BinaryReader(ms))
			{
				var inLen = rdr.ReadInt32();
				var outLen = rdr.ReadInt32();
				return new Tuple<TIn?, TOut?>(inLen > 0 ? rdr.Read<TIn>() : (TIn?)null, outLen > 0 ? rdr.Read<TOut>() : (TOut?)null);
			}
		}

		private static Tuple<byte[], byte[]> Unpack(byte[] buffer)
		{
			using (var ms = new MemoryStream(buffer))
			using (var rdr = new BinaryReader(ms))
			{
				var inLen = rdr.ReadInt32();
				var outLen = rdr.ReadInt32();
				return new Tuple<byte[], byte[]>(rdr.ReadBytes(inLen), rdr.ReadBytes(outLen));
			}
		}

		[PInvokeData("WinIOCtl.h")]
		public static class IOControlCode
		{
			public static uint FSCTL_GET_COMPRESSION
				=> CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 15, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint FSCTL_SET_COMPRESSION
				=> CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 16, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_ALLOCATE_BC_STREAM
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0601, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_ATTRIBUTE_MANAGEMENT
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0727, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_BREAK_RESERVATION
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0405, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			public static uint IOCTL_STORAGE_CHECK_PRIORITY_HINT_SUPPORT
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0620, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_CHECK_VERIFY
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0200, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			public static uint IOCTL_STORAGE_CHECK_VERIFY2
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0200, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_DEVICE_POWER_CAP
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0725, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_DEVICE_TELEMETRY_NOTIFY
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0471, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_DEVICE_TELEMETRY_QUERY_CAPS
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0472, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_EJECT_MEDIA
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0202, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			public static uint IOCTL_STORAGE_EJECTION_CONTROL
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0250, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_ENABLE_IDLE_POWER
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0720, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_EVENT_NOTIFICATION
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0724, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_FAILURE_PREDICTION_CONFIG
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0441, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_FIND_NEW_DEVICES
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0206, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			public static uint IOCTL_STORAGE_FIRMWARE_ACTIVATE
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0702, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_FIRMWARE_DOWNLOAD
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0701, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_FIRMWARE_GET_INFO
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0700, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_FREE_BC_STREAM
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0602, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_GET_BC_PROPERTIES
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0600, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			public static uint IOCTL_STORAGE_GET_COUNTERS
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x442, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_GET_DEVICE_NUMBER
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0420, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_GET_DEVICE_TELEMETRY
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0470, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_GET_DEVICE_TELEMETRY_RAW
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0473, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_GET_HOTPLUG_INFO
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0305, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_GET_IDLE_POWERUP_REASON
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0721, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_GET_LB_PROVISIONING_MAP_RESOURCES
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0502, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			public static uint IOCTL_STORAGE_GET_MEDIA_SERIAL_NUMBER
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0304, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_GET_MEDIA_TYPES
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0300, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_GET_MEDIA_TYPES_EX
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0301, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_LOAD_MEDIA
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0203, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			public static uint IOCTL_STORAGE_LOAD_MEDIA2
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0203, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0501, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_MCN_CONTROL
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0251, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_MEDIA_REMOVAL
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0201, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			public static uint IOCTL_STORAGE_PERSISTENT_RESERVE_IN
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0406, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			public static uint IOCTL_STORAGE_PERSISTENT_RESERVE_OUT
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0407, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_POWER_ACTIVE
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0722, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_POWER_IDLE
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0723, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_PREDICT_FAILURE
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0440, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_PROTOCOL_COMMAND
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x04F0, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_QUERY_PROPERTY
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0500, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_READ_CAPACITY
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0450, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			public static uint IOCTL_STORAGE_REINITIALIZE_MEDIA
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0590, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_RELEASE
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0205, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			public static uint IOCTL_STORAGE_RESERVE
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0204, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			public static uint IOCTL_STORAGE_RESET_BUS
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0400, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			public static uint IOCTL_STORAGE_RESET_DEVICE
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0401, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			public static uint IOCTL_STORAGE_RPMB_COMMAND
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0726, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_STORAGE_SET_HOTPLUG_INFO
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0306, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_SET_TEMPERATURE_THRESHOLD
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0480, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_START_DATA_INTEGRITY_CHECK
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0621, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);

			public static uint IOCTL_STORAGE_STOP_DATA_INTEGRITY_CHECK
				=> CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0622, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
		}
	}
}