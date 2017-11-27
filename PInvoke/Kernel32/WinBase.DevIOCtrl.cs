using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Vanara.Extensions;
using Vanara.InteropServices;

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming

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

		/// <summary>Defined access check value for any access within an I/O control code (IOCTL). The FILE_ACCESS_ANY is generally the correct value.</summary>
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
		/// Starts the asynchronous operation of sending a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.
		/// </summary>
		/// <typeparam name="TIn">The type of the <paramref name="inVal"/>.</typeparam>
		/// <typeparam name="TOut">The type of the <paramref name="outVal"/>.</typeparam>
		/// <param name="hDevice">
		/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream. To retrieve a device
		/// handle, use the CreateFile function. For more information, see Remarks.
		/// </param>
		/// <param name="dwIoControlCode">The control code for the operation. This value identifies the specific operation to be performed and the type of device on which to perform it.</param>
		/// <param name="inVal">A pointer to the input buffer that contains the data required to perform the operation. The format of this data depends on the value of the dwIoControlCode parameter.
		/// <para>This parameter can be NULL if dwIoControlCode specifies an operation that does not require input data.</para>
		/// </param>
		/// <param name="outVal">A pointer to the output buffer that is to receive the data returned by the operation. The format of this data depends on the value of the dwIoControlCode parameter.
		/// <para>This parameter can be NULL if dwIoControlCode specifies an operation that does not return data.</para>
		/// </param>
		/// <param name="userCallback">An AsyncCallback delegate that references the method to invoke when the operation is complete.</param>
		/// <returns>An IAsyncResult instance that references the asynchronous request.</returns>
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static IAsyncResult BeginDeviceIoControl<TIn, TOut>(SafeFileHandle hDevice, uint dwIoControlCode, TIn? inVal, TOut? outVal, AsyncCallback userCallback) where TIn : struct where TOut : struct
		{
			var buffer = Pack(inVal, outVal);
			return BeginDeviceIoControl<TIn, TOut>(hDevice, dwIoControlCode, buffer, userCallback, null);
		}

		/// <summary>This macro is used to create a unique system I/O control code (IOCTL).</summary>
		/// <param name="deviceType">Defines the type of device for the given IOCTL. This parameter can be no bigger then a WORD value. The values used by Microsoft are in the range 0-32767 and the values 32768-65535 are reserved for use by OEMs and IHVs.</param>
		/// <param name="function">Defines an action within the device category. That function codes 0-2047 are reserved for Microsoft, and 2048-4095 are reserved for OEMs and IHVs. The function code can be no larger then 4095.</param>
		/// <param name="method">Defines the method codes for how buffers are passed for I/O and file system controls. The following list shows the possible values for this parameter:
		/// <list type="bullet">
		/// <item><description>METHOD_BUFFERED</description></item>
		/// <item><description>METHOD_IN_DIRECT</description></item>
		/// <item><description>METHOD_OUT_DIRECT</description></item>
		/// <item><description>METHOD_NEITHER</description></item>
		/// </list>
		/// <para>This field is ignored under Windows CE and you should always use the METHOD_BUFFERED value unless compatibility with the desktop is required using a different Method value.</para></param>
		/// <param name="access">Defines the access check value for any access. The following table shows the possible flags for this parameter. The FILE_ACCESS_ANY is generally the correct value.
		/// <list type="table">
		/// <listheader><term>Flag</term><term>Description</term></listheader>
		/// <item><term>FILE_ANY_ACCESS</term><term>Request all access.</term></item>
		/// <item><term>FILE_READ_ACCESS</term><term>Request read access. Can be used with FILE_WRITE_ACCESS.</term></item>
		/// <item><term>FILE_WRITE_ACCESS</term><term>Request write access. Can be used with FILE_READ_ACCESS.</term></item>
		/// </list></param>
		/// <returns>The resulting I/O control code.</returns>
		public static uint CTL_CODE(ushort deviceType, ushort function, byte method, byte access)
		{
			if (function > 0xfff)
				throw new ArgumentOutOfRangeException(nameof(function));
			return (uint)((deviceType << 0x10) | (access << 14) | (function << 2) | method);
		}

		/// <summary>This macro is used to create a unique system I/O control code (IOCTL).</summary>
		/// <param name="deviceType">Defines the type of device for the given IOCTL. This parameter can be no bigger then a WORD value. The values used by Microsoft are in the range 0-32767 and the values 32768-65535 are reserved for use by OEMs and IHVs.</param>
		/// <param name="function">Defines an action within the device category. That function codes 0-2047 are reserved for Microsoft, and 2048-4095 are reserved for OEMs and IHVs. The function code can be no larger then 4095.</param>
		/// <param name="method">Defines the method codes for how buffers are passed for I/O and file system controls.
		/// <para>This field is ignored under Windows CE and you should always use the METHOD_BUFFERED value unless compatibility with the desktop is required using a different Method value.</para></param>
		/// <param name="access">Defines the access check value for any access.</param>
		/// <returns>The resulting I/O control code.</returns>
		public static uint CTL_CODE(DEVICE_TYPE deviceType, ushort function, IOMethod method, IOAccess access) =>
			CTL_CODE((ushort)deviceType, function, (byte)method, (byte)access);

		/// <summary>Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.</summary>
		/// <param name="hDevice">
		/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream. To retrieve a device
		/// handle, use the CreateFile function. For more information, see Remarks.
		/// </param>
		/// <param name="dwIoControlCode">The control code for the operation. This value identifies the specific operation to be performed and the type of device on which to perform it.</param>
		/// <param name="lpInBuffer">A pointer to the input buffer that contains the data required to perform the operation. The format of this data depends on the value of the dwIoControlCode parameter.
		/// <para>This parameter can be NULL if dwIoControlCode specifies an operation that does not require input data.</para>
		/// </param>
		/// <param name="nInBufferSize">The size of the input buffer, in bytes.</param>
		/// <param name="lpOutBuffer">A pointer to the output buffer that is to receive the data returned by the operation. The format of this data depends on the value of the dwIoControlCode parameter.
		/// <para>This parameter can be NULL if dwIoControlCode specifies an operation that does not return data.</para>
		/// </param>
		/// <param name="nOutBufferSize">The size of the output buffer, in bytes.</param>
		/// <param name="lpBytesReturned">A pointer to a variable that receives the size of the data stored in the output buffer, in bytes.
		/// <para>If the output buffer is too small to receive any data, the call fails, GetLastError returns ERROR_INSUFFICIENT_BUFFER, and lpBytesReturned is zero.</para>
		/// <para>
		/// If the output buffer is too small to hold all of the data but can hold some entries, some drivers will return as much data as fits. In this case, the
		/// call fails, GetLastError returns ERROR_MORE_DATA, and lpBytesReturned indicates the amount of data received. Your application should call
		/// DeviceIoControl again with the same operation, specifying a new starting point.
		/// </para>
		/// <para>
		/// If lpOverlapped is NULL, lpBytesReturned cannot be NULL. Even when an operation returns no output data and lpOutBuffer is NULL, DeviceIoControl makes
		/// use of lpBytesReturned. After such an operation, the value of lpBytesReturned is meaningless.
		/// </para>
		/// <para>
		/// If lpOverlapped is not NULL, lpBytesReturned can be NULL. If this parameter is not NULL and the operation returns data, lpBytesReturned is
		/// meaningless until the overlapped operation has completed. To retrieve the number of bytes returned, call GetOverlappedResult. If hDevice is
		/// associated with an I/O completion port, you can retrieve the number of bytes returned by calling GetQueuedCompletionStatus.
		/// </para>
		/// </param>
		/// <param name="lpOverlapped">
		/// A pointer to an OVERLAPPED structure.
		/// <para>If hDevice was opened without specifying FILE_FLAG_OVERLAPPED, lpOverlapped is ignored.</para>
		/// <para>
		/// If hDevice was opened with the FILE_FLAG_OVERLAPPED flag, the operation is performed as an overlapped (asynchronous) operation. In this case,
		/// lpOverlapped must point to a valid OVERLAPPED structure that contains a handle to an event object. Otherwise, the function fails in unpredictable ways.
		/// </para>
		/// <para>
		/// For overlapped operations, DeviceIoControl returns immediately, and the event object is signaled when the operation has been completed. Otherwise,
		/// the function does not return until the operation has been completed or an error occurs.
		/// </para>
		/// </param>
		/// <returns>
		/// If the operation completes successfully, the return value is nonzero.
		/// <para>If the operation fails or is pending, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To retrieve a handle to the device, you must call the CreateFile function with either the name of a device or the name of the driver associated with
		/// a device. To specify a device name, use the following format:
		/// </para>
		/// <para>\\.\DeviceName</para>
		/// <para>
		/// DeviceIoControl can accept a handle to a specific device. For example, to open a handle to the logical drive
		/// A: with CreateFile, specify \\.\a:. Alternatively, you can use the names \\.\PhysicalDrive0, \\.\PhysicalDrive1, and so on, to open handles to the
		/// physical drives on a system.
		/// </para>
		/// <para>
		/// You should specify the FILE_SHARE_READ and FILE_SHARE_WRITE access flags when calling CreateFile to open a handle to a device driver. However, when
		/// you open a communications resource, such as a serial port, you must specify exclusive access. Use the other CreateFile parameters as follows when
		/// opening a device handle:
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
		/// The fdwAttrsAndFlags parameter can specify FILE_FLAG_OVERLAPPED to indicate that the returned handle can be used in overlapped (asynchronous) I/O operations.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static extern bool DeviceIoControl(SafeFileHandle hDevice, uint dwIoControlCode, IntPtr lpInBuffer, uint nInBufferSize, IntPtr lpOutBuffer,
			uint nOutBufferSize, out uint lpBytesReturned, IntPtr lpOverlapped);

		/// <summary>Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.</summary>
		/// <param name="hDevice">
		/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream. To retrieve a device
		/// handle, use the CreateFile function. For more information, see Remarks.
		/// </param>
		/// <param name="dwIoControlCode">
		/// The control code for the operation. This value identifies the specific operation to be performed and the type of device on which to perform it.
		/// </param>
		/// <param name="lpInBuffer">
		/// A pointer to the input buffer that contains the data required to perform the operation. The format of this data depends on the value of the
		/// dwIoControlCode parameter.
		/// <para>This parameter can be NULL if dwIoControlCode specifies an operation that does not require input data.</para>
		/// </param>
		/// <param name="nInBufferSize">The size of the input buffer, in bytes.</param>
		/// <param name="lpOutBuffer">
		/// A pointer to the output buffer that is to receive the data returned by the operation. The format of this data depends on the value of the
		/// dwIoControlCode parameter.
		/// <para>This parameter can be NULL if dwIoControlCode specifies an operation that does not return data.</para>
		/// </param>
		/// <param name="nOutBufferSize">The size of the output buffer, in bytes.</param>
		/// <param name="lpBytesReturned">
		/// A pointer to a variable that receives the size of the data stored in the output buffer, in bytes.
		/// <para>
		/// If the output buffer is too small to receive any data, the call fails, GetLastError returns ERROR_INSUFFICIENT_BUFFER, and lpBytesReturned is zero.
		/// </para>
		/// <para>
		/// If the output buffer is too small to hold all of the data but can hold some entries, some drivers will return as much data as fits. In this case, the
		/// call fails, GetLastError returns ERROR_MORE_DATA, and lpBytesReturned indicates the amount of data received. Your application should call
		/// DeviceIoControl again with the same operation, specifying a new starting point.
		/// </para>
		/// <para>
		/// If lpOverlapped is NULL, lpBytesReturned cannot be NULL. Even when an operation returns no output data and lpOutBuffer is NULL, DeviceIoControl makes
		/// use of lpBytesReturned. After such an operation, the value of lpBytesReturned is meaningless.
		/// </para>
		/// <para>
		/// If lpOverlapped is not NULL, lpBytesReturned can be NULL. If this parameter is not NULL and the operation returns data, lpBytesReturned is
		/// meaningless until the overlapped operation has completed. To retrieve the number of bytes returned, call GetOverlappedResult. If hDevice is
		/// associated with an I/O completion port, you can retrieve the number of bytes returned by calling GetQueuedCompletionStatus.
		/// </para>
		/// </param>
		/// <param name="lpOverlapped">
		/// A pointer to an OVERLAPPED structure.
		/// <para>If hDevice was opened without specifying FILE_FLAG_OVERLAPPED, lpOverlapped is ignored.</para>
		/// <para>
		/// If hDevice was opened with the FILE_FLAG_OVERLAPPED flag, the operation is performed as an overlapped (asynchronous) operation. In this case,
		/// lpOverlapped must point to a valid OVERLAPPED structure that contains a handle to an event object. Otherwise, the function fails in unpredictable ways.
		/// </para>
		/// <para>
		/// For overlapped operations, DeviceIoControl returns immediately, and the event object is signaled when the operation has been completed. Otherwise,
		/// the function does not return until the operation has been completed or an error occurs.
		/// </para>
		/// </param>
		/// <returns>
		/// If the operation completes successfully, the return value is nonzero.
		/// <para>If the operation fails or is pending, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To retrieve a handle to the device, you must call the CreateFile function with either the name of a device or the name of the driver associated with
		/// a device. To specify a device name, use the following format:
		/// </para>
		/// <para>\\.\DeviceName</para>
		/// <para>
		/// DeviceIoControl can accept a handle to a specific device. For example, to open a handle to the logical drive
		/// A: with CreateFile, specify \\.\a:. Alternatively, you can use the names \\.\PhysicalDrive0, \\.\PhysicalDrive1, and so on, to open handles to the
		/// physical drives on a system.
		/// </para>
		/// <para>
		/// You should specify the FILE_SHARE_READ and FILE_SHARE_WRITE access flags when calling CreateFile to open a handle to a device driver. However, when
		/// you open a communications resource, such as a serial port, you must specify exclusive access. Use the other CreateFile parameters as follows when
		/// opening a device handle:
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
		/// The fdwAttrsAndFlags parameter can specify FILE_FLAG_OVERLAPPED to indicate that the returned handle can be used in overlapped (asynchronous) I/O operations.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static extern unsafe bool DeviceIoControl(SafeFileHandle hDevice, uint dwIoControlCode, byte* lpInBuffer, uint nInBufferSize, byte* lpOutBuffer,
					uint nOutBufferSize, out uint lpBytesReturned, NativeOverlapped* lpOverlapped);

		/// <summary>
		/// Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.
		/// </summary>
		/// <typeparam name="TIn">The type of the <paramref name="inVal"/>.</typeparam>
		/// <typeparam name="TOut">The type of the <paramref name="outVal"/>.</typeparam>
		/// <param name="hDev">
		/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream. To retrieve a device
		/// handle, use the CreateFile function. For more information, see Remarks.
		/// </param>
		/// <param name="ioControlCode">The control code for the operation. This value identifies the specific operation to be performed and the type of device on which to perform it.</param>
		/// <param name="inVal">The data required to perform the operation. The format of this data depends on the value of the dwIoControlCode parameter.</param>
		/// <param name="outVal">The data returned by the operation. The format of this data depends on the value of the dwIoControlCode parameter.</param>
		/// <returns><c>true</c> if successful.</returns>
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static bool DeviceIoControl<TIn, TOut>(SafeFileHandle hDev, uint ioControlCode, TIn inVal, out TOut outVal) where TIn : struct where TOut : struct
		{
			using (SafeHGlobalHandle ptrIn = SafeHGlobalHandle.CreateFromStructure(inVal), ptrOut = SafeHGlobalHandle.CreateFromStructure<TOut>())
			{
				var ret = DeviceIoControl(hDev, ioControlCode, (IntPtr)ptrIn, (uint)ptrIn.Size, (IntPtr)ptrOut, (uint)ptrOut.Size, out uint bRet, IntPtr.Zero);
				outVal = ptrOut.ToStructure<TOut>();
				return ret;
			}
		}

		/// <summary>
		/// Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.
		/// </summary>
		/// <typeparam name="TOut">The type of the <paramref name="outVal"/>.</typeparam>
		/// <param name="hDev">
		/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream. To retrieve a device
		/// handle, use the CreateFile function. For more information, see Remarks.
		/// </param>
		/// <param name="ioControlCode">The control code for the operation. This value identifies the specific operation to be performed and the type of device on which to perform it.</param>
		/// <param name="outVal">The data returned by the operation. The format of this data depends on the value of the dwIoControlCode parameter.</param>
		/// <returns><c>true</c> if successful.</returns>
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static bool DeviceIoControl<TOut>(SafeFileHandle hDev, uint ioControlCode, out TOut outVal) where TOut : struct
		{
			using (var ptrOut = SafeHGlobalHandle.CreateFromStructure<TOut>())
			{
				var ret = DeviceIoControl(hDev, ioControlCode, IntPtr.Zero, 0, (IntPtr)ptrOut, (uint)ptrOut.Size, out uint bRet, IntPtr.Zero);
				outVal = ptrOut.ToStructure<TOut>();
				return ret;
			}
		}

		/// <summary>
		/// Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.
		/// </summary>
		/// <typeparam name="TIn">The type of the <paramref name="inVal"/>.</typeparam>
		/// <param name="hDev">
		/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream. To retrieve a device
		/// handle, use the CreateFile function. For more information, see Remarks.
		/// </param>
		/// <param name="ioControlCode">The control code for the operation. This value identifies the specific operation to be performed and the type of device on which to perform it.</param>
		/// <param name="inVal">The data required to perform the operation. The format of this data depends on the value of the dwIoControlCode parameter.</param>
		/// <returns><c>true</c> if successful.</returns>
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static bool DeviceIoControl<TIn>(SafeFileHandle hDev, uint ioControlCode, TIn inVal) where TIn : struct
		{
			using (var ptrIn = SafeHGlobalHandle.CreateFromStructure(inVal))
			{
				return DeviceIoControl(hDev, ioControlCode, (IntPtr)ptrIn, (uint)ptrIn.Size, IntPtr.Zero, 0, out uint bRet, IntPtr.Zero);
			}
		}

		/// <summary>
		/// Ends the asynchronous call to <see cref="BeginDeviceIoControl{TIn, TOut}(SafeFileHandle, uint, TIn?, TOut?, AsyncCallback)"/>.
		/// </summary>
		/// <typeparam name="TIn">The type of the input value.</typeparam>
		/// <typeparam name="TOut">The type of the output value.</typeparam>
		/// <param name="asyncResult">The asynchronous result returned from <see cref="BeginDeviceIoControl{TIn, TOut}(SafeFileHandle, uint, TIn?, TOut?, AsyncCallback)"/>.</param>
		/// <returns>The output value, if exists; <c>null</c> otherwise.</returns>
		[PInvokeData("Winbase.h", MSDNShortId = "aa363216")]
		public static TOut? EndDeviceIoControl<TIn, TOut>(IAsyncResult asyncResult) where TIn : struct where TOut : struct
		{
			var ret = OverlappedAsync.EndOverlappedFunction(asyncResult);
			return Unpack<TIn, TOut>(ret as byte[]).Item2;
		}

		private static unsafe IAsyncResult BeginDeviceIoControl<TIn, TOut>(SafeFileHandle hDevice, uint dwIoControlCode, byte[] buffer, AsyncCallback userCallback, object userState) where TIn : struct where TOut : struct
		{
			var ar = OverlappedAsync.SetupOverlappedFunction(hDevice, userCallback, buffer);
			var inSz = Marshal.SizeOf(typeof(TIn));
			fixed (byte* pIn = buffer, pOut = &buffer[inSz])
			{
				var ret = DeviceIoControl(hDevice, dwIoControlCode, pIn, (uint)inSz, pOut, (uint)(buffer.Length - inSz), out uint bRet, ar.Overlapped);
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