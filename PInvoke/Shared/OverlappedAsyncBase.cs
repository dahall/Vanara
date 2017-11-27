using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace Vanara.PInvoke
{
	/// <summary>Helper methods to work with asynchronous methods using <see cref="NativeOverlapped"/>.</summary>
	public static class OverlappedAsync
	{
		/// <summary>Cleans up at the end of the <see cref="Overlapped.Pack(IOCompletionCallback, object)"/> callback method.</summary>
		/// <param name="asyncResult">The asynchronous result.</param>
		/// <returns>The object passed into the <see cref="Overlapped.Pack(IOCompletionCallback, object)"/> method.</returns>
		/// <exception cref="System.ArgumentNullException">asyncResult</exception>
		/// <exception cref="System.ArgumentException">Argument must be of type AsyncResult - asyncResult</exception>
		/// <exception cref="System.InvalidOperationException">Asynchronous end method called twice.</exception>
		/// <exception cref="Win32Exception">Another Win32 error.</exception>
		public static object EndOverlappedFunction(IAsyncResult asyncResult)
		{
			if (asyncResult == null)
				throw new ArgumentNullException(nameof(asyncResult));
			if (!(asyncResult is OverlappedAsyncResult result))
				throw new ArgumentException("Argument must be of type AsyncResult", nameof(asyncResult));
			if (1 == Interlocked.CompareExchange(ref result.endCalled, 1, 0))
				throw new InvalidOperationException("Asynchronous end method called twice.");
			var handle = result.AsyncWaitHandle;
			if (!handle.SafeWaitHandle.IsClosed)
				try
				{
					handle.WaitOne();
				}
				finally
				{
					handle.Close();
				}
			if (result.errorCode != 0)
				throw new Win32Exception(result.errorCode);
			return result.AsyncState;
		}

		/// <summary>Cleans up and handles end of 'Begin' method and handles immediate return values.</summary>
		/// <param name="asyncResult">The asynchronous result.</param>
		/// <param name="functionResult">if set to <c>true</c> sets the return value as Complete.</param>
		/// <returns>A completed or errored <see cref="IAsyncResult"/> for the function</returns>
		/// <exception cref="Win32Exception">Thrown when <paramref name="functionResult"/> is false and the system is reporting a Win32 error.</exception>
		public static IAsyncResult EvaluateOverlappedFunction(OverlappedAsyncResult asyncResult, bool functionResult)
		{
			if (functionResult)
			{
				asyncResult.Complete();
				return asyncResult;
			}
			var errorCode = Marshal.GetLastWin32Error();
			if (errorCode == Win32Error.ERROR_IO_PENDING)
				return asyncResult;
			asyncResult.FreeOverlapped();
			throw new Win32Exception(errorCode);
		}

		/// <summary>Setups the class that holds the overlapped call details. Use at the start of the 'Begin' method.</summary>
		/// <param name="hDevice">The handle to bind to.</param>
		/// <param name="userCallback">The user callback method.</param>
		/// <param name="userState">
		/// A variable that is passed to all receiving methods in the asynchronous methods. Can be use to hold any user defined object.
		/// </param>
		/// <returns>An <see cref="OverlappedAsyncResult"/> instance for the asynchronous calls.</returns>
		public static unsafe OverlappedAsyncResult SetupOverlappedFunction(SafeFileHandle hDevice, AsyncCallback userCallback, object userState)
		{
			ThreadPool.BindHandle(hDevice);
			var ar = new OverlappedAsyncResult(userState, userCallback, hDevice);
			var o = new Overlapped(0, 0, IntPtr.Zero, ar);
			ar.Overlapped = o.Pack((code, bytes, pOverlapped) =>
			{
				var asyncResult = (OverlappedAsyncResult) Overlapped.Unpack(pOverlapped).AsyncResult;
				if (asyncResult.IsCompleted) return;
				asyncResult.FreeOverlapped();
				if (code == 0x217) code = 0;
				asyncResult.Complete(true, (int) code);
			}, userState);
			return ar;
		}

		/// <summary>Holds all pertinent information for handling results and errors in an overlapped set of method calls.</summary>
		/// <seealso cref="System.IAsyncResult"/>
		public sealed class OverlappedAsyncResult : IAsyncResult
		{
			internal int endCalled;
			internal int errorCode;

			[SecurityCritical] private readonly SafeFileHandle handle;
			private readonly object lockObj = new object();
			private ManualResetEvent evt;
			[SecurityCritical] private unsafe NativeOverlapped* overlapped;

			/// <summary>Initializes a new instance of the <see cref="OverlappedAsyncResult"/> class.</summary>
			/// <param name="userState">State of the user.</param>
			/// <param name="callback">The callback method.</param>
			/// <param name="hFile">The binding handle.</param>
			internal OverlappedAsyncResult(object userState, AsyncCallback callback, SafeFileHandle hFile)
			{
				AsyncState = userState;
				AsyncCallback = callback;
				handle = hFile;
			}

			/// <summary>Gets the asynchronous callback method.</summary>
			/// <value>The asynchronous callback method.</value>
			public AsyncCallback AsyncCallback { get; }

			/// <summary>Gets a user-defined object that qualifies or contains information about an asynchronous operation.</summary>
			public object AsyncState { get; }

			/// <summary>Gets a <see cref="T:System.Threading.WaitHandle"/> that is used to wait for an asynchronous operation to complete.</summary>
			public WaitHandle AsyncWaitHandle
			{
				get
				{
					lock (lockObj)
					{
						if (evt != null) return evt;
						evt = new ManualResetEvent(false);
						if (IsCompleted) evt.Set();
						return evt;
					}
				}
			}

			/// <summary>Gets a value that indicates whether the asynchronous operation completed synchronously.</summary>
			public bool CompletedSynchronously { get; internal set; } = true;

			/// <summary>Gets the handle to which this operation is bound.</summary>
			/// <value>The handle.</value>
			public SafeFileHandle Handle => handle;

			/// <summary>Gets a value that indicates whether the asynchronous operation has completed.</summary>
			public bool IsCompleted { get; private set; }

			/// <summary>Gets the <see cref="NativeOverlapped"/> pointer.</summary>
			/// <value>The <see cref="NativeOverlapped"/> pointer.</value>
			public unsafe NativeOverlapped* Overlapped
			{
				get => overlapped;
				internal set => overlapped = value;
			}

			/// <summary>Completes the specified synch.</summary>
			/// <param name="synch">The value for the <see cref="CompletedSynchronously"/> property.</param>
			/// <param name="error">The error code, if necessary.</param>
			internal void Complete(bool synch = false, int error = 0)
			{
				CompletedSynchronously = synch;
				errorCode = error;
				if (IsCompleted) return;
				IsCompleted = true;
				lock (lockObj)
				{
					evt?.Set();
					AsyncCallback?.Invoke(this);
				}
			}

			/// <summary>Frees the <see cref="NativeOverlapped"/> pointer.</summary>
			internal unsafe void FreeOverlapped()
			{
				System.Threading.Overlapped.Free(overlapped);
				overlapped = null;
			}
		}
	}
}