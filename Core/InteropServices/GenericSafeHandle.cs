using Vanara.PInvoke;

namespace Vanara.InteropServices;

/// <summary>A <see cref="SafeHandle"/> that takes a delegate in the constructor that closes the supplied handle.</summary>
/// <seealso cref="SafeHandle"/>
public class GenericSafeHandle : SafeHANDLE, IHandle
{
	/// <summary>Initializes a new instance of the <see cref="GenericSafeHandle"/> class.</summary>
	protected GenericSafeHandle() : base() { }

	/// <summary>Initializes a new instance of the <see cref="GenericSafeHandle"/> class.</summary>
	/// <param name="ptr">The pre-existing handle to use.</param>
	/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; <see langword="false"/> to prevent reliable release (not recommended).</param>
	protected GenericSafeHandle(IntPtr ptr, bool ownsHandle) : base(ptr, ownsHandle) { }

	/// <summary>Initializes a new instance of the <see cref="GenericSafeHandle"/> class.</summary>
	/// <param name="closeMethod">The delegate method for closing the handle.</param>
	public GenericSafeHandle(Func<IntPtr, bool> closeMethod) : this(IntPtr.Zero, closeMethod, true) { }

	/// <summary>Initializes a new instance of the <see cref="GenericSafeHandle"/> class.</summary>
	/// <param name="ptr">The pre-existing handle to use.</param>
	/// <param name="closeMethod">The delegate method for closing the handle.</param>
	/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; <see langword="false"/> to prevent reliable release (not recommended).</param>
	/// <exception cref="ArgumentNullException">closeMethod</exception>
	public GenericSafeHandle(IntPtr ptr, Func<IntPtr, bool> closeMethod, bool ownsHandle = true) : base(ptr, ownsHandle) =>
		CloseMethod = closeMethod ?? throw new ArgumentNullException(nameof(closeMethod));

	/// <summary>Gets or sets the close method.</summary>
	/// <value>The close method.</value>
	protected virtual Func<IntPtr, bool>? CloseMethod { get; }

	/// <inheritdoc />
	protected override bool InternalReleaseHandle()
	{
		var ret = CloseMethod?.Invoke(handle) ?? true;
		SetHandle(IntPtr.Zero);
		return ret;
	}
}