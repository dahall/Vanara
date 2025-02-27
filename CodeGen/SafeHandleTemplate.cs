namespace Namespace;

/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HandleName"/> that is disposed using <c>CloseCode</c>.</summary>
/// <remarks>Initializes a new instance of the <see cref="ClassName"/> class and assigns an existing handle.</remarks>
/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
/// <param name="ownsHandle">
/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
/// </param>
public partial class ClassName(IntPtr preexistingHandle, bool ownsHandle = true) : BaseClassName(preexistingHandle, ownsHandle)
{
	/// <summary>Performs an implicit conversion from <see cref="ClassName"/> to <see cref="HandleName"/>.</summary>
	/// <param name="h">The safe handle instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HandleName(ClassName h) => h.handle;

	/// <inheritdoc/>
	protected override bool InternalReleaseHandle() => CloseCode;
}