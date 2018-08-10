using System;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Vanara.InteropServices
{
	/// <summary>A <see cref="SafeHandle"/> that takes a delegate in the constructor that closes the supplied handle.</summary>
	/// <seealso cref="SafeHandle"/>
	public class GenericSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		/// <summary>Initializes a new instance of the <see cref="GenericSafeHandle"/> class.</summary>
		protected GenericSafeHandle() : base(true) { }

		/// <summary>Initializes a new instance of the <see cref="GenericSafeHandle"/> class.</summary>
		/// <param name="ptr">The pre-existing handle to use.</param>
		/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; <see langword="false"/> to prevent reliable release (not recommended).</param>
		protected GenericSafeHandle(IntPtr ptr, bool ownsHandle) : base(ownsHandle) { SetHandle(ptr); }

		/// <summary>Initializes a new instance of the <see cref="GenericSafeHandle"/> class.</summary>
		/// <param name="closeMethod">The delegate method for closing the handle.</param>
		public GenericSafeHandle(Func<IntPtr, bool> closeMethod) : this(IntPtr.Zero, closeMethod, true) { }

		/// <summary>Initializes a new instance of the <see cref="GenericSafeHandle"/> class.</summary>
		/// <param name="ptr">The pre-existing handle to use.</param>
		/// <param name="closeMethod">The delegate method for closing the handle.</param>
		/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; <see langword="false"/> to prevent reliable release (not recommended).</param>
		/// <exception cref="System.ArgumentNullException">closeMethod</exception>
		public GenericSafeHandle(IntPtr ptr, Func<IntPtr, bool> closeMethod, bool ownsHandle = true) : base(ownsHandle)
		{
			SetHandle(ptr);
			CloseMethod = closeMethod ?? throw new ArgumentNullException(nameof(closeMethod));
		}

		/// <summary>Gets or sets the close method.</summary>
		/// <value>The close method.</value>
		protected virtual Func<IntPtr, bool> CloseMethod { get; }

		/// <summary>Performs an implicit conversion from <see cref="GenericSafeHandle"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The <see cref="GenericSafeHandle"/> instance.</param>
		/// <returns>The value of the handle. Use caution when using this value as it can be closed by the disposal of the parent <see cref="GenericSafeHandle"/>.</returns>
		public static implicit operator IntPtr(GenericSafeHandle h) => h.DangerousGetHandle();

		/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
		/// <returns>
		/// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it generates a
		/// releaseHandleFailed MDA Managed Debugging Assistant.
		/// </returns>
		protected override bool ReleaseHandle()
		{
			if (IsInvalid) return true;
			var ret = CloseMethod?.Invoke(handle) ?? true;
			SetHandle(IntPtr.Zero);
			return ret;
		}
	}
}