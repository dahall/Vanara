namespace Vanara.Pinvoke;

/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HANDLE"/> that is disposed using <c>true</c>.</summary>
/// <remarks>Initializes a new instance of the <see cref="SafeHANDLE"/> class and assigns an existing handle.</remarks>
/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
/// <param name="ownsHandle">
/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
/// </param>
public partial class SafeHANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : SafeHandleV(preexistingHandle, ownsHandle)
{
	/// <summary>Performs an implicit conversion from <see cref="SafeHANDLE"/> to <see cref="HANDLE"/>.</summary>
	/// <param name="h">The safe handle instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HANDLE(SafeHANDLE h) => h.handle;

	/// <inheritdoc/>
	protected override bool InternalReleaseHandle() => true;
}