using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.Diagnostics;

/// <summary>Represents a system I/O completion port.</summary>
/// <remarks>To use this class, create an instance with the <see cref="Create"/> method and then add one or more handlers.</remarks>
/// <seealso cref="System.IDisposable"/>
public class IoCompletionPort : IDisposable
{
	private readonly ConcurrentDictionary<IntPtr, Action<uint, IntPtr, IntPtr>> handlers = new ConcurrentDictionary<IntPtr, Action<uint, IntPtr, IntPtr>>();
	private bool disposedValue = false;
	private HANDLE hComplPort;

	private IoCompletionPort(HANDLE hValidPort)
	{
		hComplPort = hValidPort;
		Task.Factory.StartNew(PollCompletionPortThread);
	}

	/// <summary>Finalizes an instance of the <see cref="IoCompletionPort"/> class.</summary>
	~IoCompletionPort() => Dispose(false);

	/// <summary>Gets the handle for the I/O completion port.</summary>
	/// <value>The handle.</value>
	public IntPtr Handle => (IntPtr)hComplPort;

	/// <summary>
	/// Creates an input/output (I/O) completion port that is not yet associated with a file handle, allowing association at a later time.
	/// </summary>
	/// <returns>An <see cref="IoCompletionPort"/> instance.</returns>
	public static IoCompletionPort Create()
	{
		var hComplPort = CreateIoCompletionPort((IntPtr)HFILE.INVALID_HANDLE_VALUE, HANDLE.NULL, default, 0);
		if (hComplPort.IsNull)
			Win32Error.ThrowLastError();

		return new IoCompletionPort(hComplPort);
	}

	/// <summary>Adds key and handler to the I/O completion port.</summary>
	/// <param name="key">A unique completion key to be passed to the handler when called.</param>
	/// <param name="handler">An action to perform when an I/O operation is complete.</param>
	/// <exception cref="ArgumentOutOfRangeException">The value for <paramref name="key"/> cannot be <c>IntPtr.Zero</c>.</exception>
	/// <exception cref="InvalidOperationException">Key already exists.</exception>
	public void AddKeyHandler(IntPtr key, Action<uint, IntPtr, IntPtr> handler)
	{
		if (key == IntPtr.Zero)
			throw new ArgumentOutOfRangeException(nameof(key), "Key value cannot be 0.");

		if (!handlers.TryAdd(key, handler))
			throw new InvalidOperationException("Key already exists.");
	}

	/// <summary>Adds an overlapped handle, key and handler to the I/O completion port.</summary>
	/// <param name="overlappedHandle">
	/// An open handle to an object that supports overlapped I/O.
	/// <para>
	/// The provided handle has to have been opened for overlapped I/O completion. For example, you must specify the FILE_FLAG_OVERLAPPED
	/// flag when using the CreateFile function to obtain the handle.
	/// </para>
	/// </param>
	/// <param name="key">A unique completion key to be passed to the handler when called.</param>
	/// <param name="handler">An action to perform when an I/O operation is complete.</param>
	/// <exception cref="ArgumentOutOfRangeException">The value for <paramref name="key"/> cannot be <c>IntPtr.Zero</c>.</exception>
	/// <exception cref="InvalidOperationException">Key already exists.</exception>
	public void AddKeyHandler(IntPtr overlappedHandle, IntPtr key, Action<uint, IntPtr, IntPtr> handler)
	{
		AddKeyHandler(key, handler);

		if (CreateIoCompletionPort(overlappedHandle, hComplPort, key, 0).IsNull)
			Win32Error.ThrowLastError();
	}

	// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	/// <summary>Posts an I/O completion packet to an I/O completion port.</summary>
	/// <param name="completionKey">
	/// The value to be returned through the lpCompletionKey parameter of the <c>GetQueuedCompletionStatus</c> function.
	/// </param>
	/// <param name="numberOfBytesTransferred">
	/// The value to be returned through the lpNumberOfBytesTransferred parameter of the <c>GetQueuedCompletionStatus</c> function.
	/// </param>
	/// <param name="lpOverlapped">
	/// The value to be returned through the lpOverlapped parameter of the <c>GetQueuedCompletionStatus</c> function.
	/// </param>
	public void PostQueuedStatus(IntPtr completionKey, uint numberOfBytesTransferred = 0, IntPtr lpOverlapped = default)
	{
		if (completionKey == IntPtr.Zero)
			throw new ArgumentOutOfRangeException(nameof(completionKey), "Key value cannot be 0.");

		if (!PostQueuedCompletionStatus(hComplPort, numberOfBytesTransferred, completionKey, lpOverlapped))
			Win32Error.ThrowLastError();
	}

	/// <summary>Posts an I/O completion packet to an I/O completion port.</summary>
	/// <param name="completionKey">
	/// The value to be returned through the lpCompletionKey parameter of the <c>GetQueuedCompletionStatus</c> function.
	/// </param>
	/// <param name="numberOfBytesTransferred">
	/// The value to be returned through the lpNumberOfBytesTransferred parameter of the <c>GetQueuedCompletionStatus</c> function.
	/// </param>
	/// <param name="lpOverlapped">
	/// The value to be returned through the lpOverlapped parameter of the <c>GetQueuedCompletionStatus</c> function.
	/// </param>
	public unsafe void PostQueuedStatus(IntPtr completionKey, uint numberOfBytesTransferred, NativeOverlapped* lpOverlapped)
	{
		if (completionKey == IntPtr.Zero)
			throw new ArgumentOutOfRangeException(nameof(completionKey), "Key value cannot be 0.");

		if (!PostQueuedCompletionStatus(hComplPort, numberOfBytesTransferred, completionKey, lpOverlapped))
			Win32Error.ThrowLastError();
	}

	/// <summary>Removes the handler associated with <paramref name="key"/>.</summary>
	/// <param name="key">The key of the handler to remove.</param>
	/// <exception cref="InvalidOperationException">Key does not exist.</exception>
	public void RemoveKeyHandler(IntPtr key)
	{
		if (!handlers.TryRemove(key, out _))
			throw new InvalidOperationException("Key does not exist.");
	}

	/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
	/// <param name="disposing">
	/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
	/// </param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				// TODO: dispose managed state (managed objects).
			}

			if (!hComplPort.IsNull)
			{
				// Shut down background thread processing completion port messages.
				PostQueuedCompletionStatus(hComplPort, 0);

				// Close the completion port handle
				CloseHandle((IntPtr)hComplPort);
				hComplPort = HANDLE.NULL;
			}

			disposedValue = true;
		}
	}

	private void PollCompletionPortThread()
	{
		while (true)
		{
			// Wait forever to get the next completion status
			if (!GetQueuedCompletionStatus(hComplPort, out var byteCount, out var completionKey, out var overlapped, INFINITE) && overlapped == IntPtr.Zero)
			{
				var err = Win32Error.GetLastError();
				if (err == Win32Error.ERROR_ABANDONED_WAIT_0)
					break;
				throw err.GetException();
			}

			// End the thread if terminating completion key signals
			if (byteCount == 0 && completionKey == IntPtr.Zero && overlapped == IntPtr.Zero)
				break;

			// Spin this off so we don't hang the completion port.
			if (handlers.TryGetValue(completionKey, out var action))
				Task.Factory.StartNew(o => { if (o is Tuple<uint, IntPtr, IntPtr> t) action(t.Item1, t.Item2, t.Item3); }, new Tuple<uint, IntPtr, IntPtr>(byteCount, completionKey, overlapped));
		}
	}
}