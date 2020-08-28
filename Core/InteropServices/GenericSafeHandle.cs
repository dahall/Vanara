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
		protected GenericSafeHandle(IntPtr ptr, bool ownsHandle) : base(ownsHandle) => SetHandle(ptr);

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
			if (closeMethod == null) throw new ArgumentNullException(nameof(closeMethod));

			SetHandle(ptr);
			CloseMethod = closeMethod;
		}

		/// <summary>Gets or sets the close method.</summary>
		/// <value>The close method.</value>
		protected virtual Func<IntPtr, bool> CloseMethod { get; }

		/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
		/// <returns>
		/// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it generates a
		/// releaseHandleFailed MDA Managed Debugging Assistant.
		/// </returns>
		protected override bool ReleaseHandle()
		{
			var ret = CloseMethod?.Invoke(handle) ?? true;
			SetHandle(IntPtr.Zero);
			return ret;
		}
	}
}