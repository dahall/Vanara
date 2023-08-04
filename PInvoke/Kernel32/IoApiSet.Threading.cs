using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>
	/// Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.
	/// </summary>
	/// <param name="hDev">
	/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream.
	/// To retrieve a device handle, use the CreateFile function. For more information, see Remarks.
	/// </param>
	/// <param name="ioControlCode">
	/// The control code for the operation. This value identifies the specific operation to be performed and the type of device on which
	/// to perform it.
	/// </param>
	/// <param name="inputBuffer">The input buffer required to perform the operation. Can be null if unnecessary.</param>
	/// <param name="outputBuffer">The output buffer that is to receive the data returned by the operation. Can be null if unnecessary.</param>
	/// <returns>An asynchronous empty result.</returns>
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
	public static async Task DeviceIoControlAsync(HFILE hDev, uint ioControlCode, byte[]? inputBuffer, byte[]? outputBuffer)
	{
		var buf = Pack(inputBuffer, outputBuffer);
		var outputBytes = await Task.Factory.FromAsync(BeginDeviceIoControl, EndDeviceIoControl, hDev, ioControlCode, buf, null);
		if (outputBuffer is not null)
			outputBytes?.CopyTo(outputBuffer, 0);
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
	/// The input value required to perform the operation. The type of this data depends on the value of the <paramref
	/// name="ioControlCode"/> parameter.
	/// </param>
	/// <returns>An asynchronous empty result.</returns>
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
	public static Task DeviceIoControlAsync<TIn>(HFILE hDev, uint ioControlCode, TIn inVal) where TIn : struct =>
		DeviceIoControlAsync<TIn, int>(hDev, ioControlCode, inVal);

	/// <summary>
	/// Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.
	/// </summary>
	/// <typeparam name="TOut">The type of the return value.</typeparam>
	/// <param name="hDev">
	/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream.
	/// To retrieve a device handle, use the CreateFile function. For more information, see Remarks.
	/// </param>
	/// <param name="ioControlCode">
	/// The control code for the operation. This value identifies the specific operation to be performed and the type of device on which
	/// to perform it.
	/// </param>
	/// <returns>An asynchronous result containing the resulting value of type <typeparamref name="TOut"/>.</returns>
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
	public static Task<TOut?> DeviceIoControlAsync<TOut>(HFILE hDev, uint ioControlCode) where TOut : struct => DeviceIoControlAsync<int, TOut>(hDev, ioControlCode, null);

	/// <summary>
	/// Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.
	/// </summary>
	/// <typeparam name="TIn">The type of the <paramref name="inVal"/>.</typeparam>
	/// <typeparam name="TOut">The type of the <paramref name="outVal"/>.</typeparam>
	/// <param name="hDevice">
	/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream.
	/// To retrieve a device handle, use the CreateFile function. For more information, see Remarks.
	/// </param>
	/// <param name="ioControlCode">
	/// The control code for the operation. This value identifies the specific operation to be performed and the type of device on which
	/// to perform it.
	/// </param>
	/// <param name="inVal">
	/// The input value required to perform the operation. The type of this data depends on the value of the <paramref
	/// name="ioControlCode"/> parameter.
	/// </param>
	/// <param name="outVal">
	/// The output value that is to receive the data returned by the operation. The type of this data depends on the value of the
	/// dwIoControlCode parameter.
	/// </param>
	/// <returns>An asynchronous result containing the populated data supplied by <paramref name="outVal"/>.</returns>
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
	[Obsolete("Use 'Task<TOut?> DeviceIoControlAsync<TIn, TOut>(HFILE hDevice, uint ioControlCode, TIn? inVal)' instead.")]
	public static Task<TOut?> DeviceIoControlAsync<TIn, TOut>(HFILE hDevice, uint ioControlCode, TIn? inVal, TOut? outVal) where TIn : struct where TOut : struct =>
		new TaskFactory().FromAsync(BeginDeviceIoControl<TIn, TOut>, EndDeviceIoControl<TIn, TOut>, hDevice, ioControlCode, Pack(inVal, outVal), null);

	/// <summary>
	/// Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.
	/// </summary>
	/// <typeparam name="TIn">The type of the <paramref name="inVal"/>.</typeparam>
	/// <typeparam name="TOut">The type of the return value.</typeparam>
	/// <param name="hDevice">
	/// A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream.
	/// To retrieve a device handle, use the CreateFile function. For more information, see Remarks.
	/// </param>
	/// <param name="ioControlCode">
	/// The control code for the operation. This value identifies the specific operation to be performed and the type of device on which
	/// to perform it.
	/// </param>
	/// <param name="inVal">
	/// The input value required to perform the operation. The type of this data depends on the value of the <paramref
	/// name="ioControlCode"/> parameter.
	/// </param>
	/// <returns>An asynchronous result containing the populated data supplied by <typeparamref name="TOut"/>.</returns>
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
	public static Task<TOut?> DeviceIoControlAsync<TIn, TOut>(HFILE hDevice, uint ioControlCode, TIn? inVal) where TIn : struct where TOut : struct
	{
		TOut? outValue = default(TOut);
		var buf = Pack(inVal, outValue);
		return Task.Factory.FromAsync(BeginDeviceIoControl<TIn, TOut>, EndDeviceIoControl<TIn, TOut>, hDevice, ioControlCode, buf, null);
	}

	/// <summary>Explicits the device io control asynchronous.</summary>
	/// <typeparam name="TIn">The type of the in.</typeparam>
	/// <typeparam name="TOut">The type of the out.</typeparam>
	/// <param name="hDevice">The h device.</param>
	/// <param name="ioControlCode">The io control code.</param>
	/// <param name="inVal">The in value.</param>
	/// <param name="outVal">The out value.</param>
	/// <returns></returns>
	/// <exception cref="Win32Exception"></exception>
	private static unsafe Task<TOut?> ExplicitDeviceIoControlAsync<TIn, TOut>(HFILE hDevice, uint ioControlCode, TIn? inVal, TOut? outVal) where TIn : struct where TOut : struct
	{
#pragma warning disable CS0618 // Type or member is obsolete
		ThreadPool.BindHandle((IntPtr)hDevice);
#pragma warning restore CS0618 // Type or member is obsolete
		var tcs = new TaskCompletionSource<TOut?>();
		var buffer = Pack(inVal, outVal);
		var nativeOverlapped = new Overlapped().Pack((code, bytes, overlap) =>
		{
			try
			{
				switch (code)
				{
					case Win32Error.ERROR_SUCCESS:
						outVal = Unpack<TIn, TOut>(buffer).Item2;
						tcs.TrySetResult(outVal);
						break;

					case Win32Error.ERROR_OPERATION_ABORTED:
						tcs.TrySetCanceled();
						break;

					default:
						tcs.TrySetException(new Win32Exception((int)code));
						break;
				}
			}
			finally
			{
				Overlapped.Unpack(overlap);
				Overlapped.Free(overlap);
			}
		}, buffer);

		var unpack = true;
		try
		{
			var inSz = Marshal.SizeOf(typeof(TIn));
			fixed (byte* pIn = buffer, pOut = &buffer[inSz])
			{
				var ret = DeviceIoControl(hDevice, ioControlCode, pIn, (uint)inSz, pOut, (uint)(buffer.Length - inSz), out var bRet,
					nativeOverlapped);
				if (ret)
				{
					outVal = Unpack<TIn, TOut>(buffer).Item2;
					tcs.SetResult(outVal);
					return tcs.Task;
				}
			}

			var lastWin32Error = Marshal.GetLastWin32Error();
			if (lastWin32Error is not (int)Win32Error.ERROR_IO_PENDING and not (int)Win32Error.ERROR_SUCCESS)
				throw new Win32Exception(lastWin32Error);
			unpack = false;
			return tcs.Task;
		}
		finally
		{
			if (unpack)
			{
				Overlapped.Unpack(nativeOverlapped);
				Overlapped.Free(nativeOverlapped);
			}
		}
	}
}