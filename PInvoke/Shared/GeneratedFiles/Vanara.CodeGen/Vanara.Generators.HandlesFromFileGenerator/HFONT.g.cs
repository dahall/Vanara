namespace Vanara.Pinvoke;

/// <summary>Provides a handle to a font.</summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct HFONT : IGraphicsObjectHandle
{
	private readonly IntPtr handle;

	/// <summary>Initializes a new instance of the <see cref="HFONT"/> struct.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	public HFONT(IntPtr preexistingHandle) => handle = preexistingHandle;

	/// <summary>Returns an invalid handle by instantiating a <see cref="HFONT"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static HFONT NULL => new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether the handle is invalid.</summary>
	/// <value><see langword="true"/> if the handle is invalid; otherwise, <see langword="false"/>.</value>
	public readonly bool IsInvalid => handle == IntPtr.Zero || handle == new IntPtr(-1);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public readonly bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HFONT"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HFONT h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFONT"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HFONT(IntPtr h) => new(h);

	/// <summary>Implements the operator !=.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(HFONT h1, HFONT h2) => !(h1 == h2);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(HFONT h1, HFONT h2) => h1.Equals(h2);

	/// <summary>Implements the operator !.</summary>
	/// <param name="h1">The handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HFONT h1) => h1.IsNull;

#if !NETSTANDARD
	/// <summary>Implements the operator <see langword="true"/>.</summary>
	/// <param name="h">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator true(HFONT h) => !h.IsInvalid;

	/// <summary>Implements the operator <see langword="false"/>.</summary>
	/// <param name="h">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator false(HFONT h) => h.IsInvalid;
#endif

	/// <inheritdoc/>
	public readonly override bool Equals(object obj) => obj is HFONT h && handle == h.handle;

	/// <inheritdoc/>
	public readonly override int GetHashCode() => handle.GetHashCode();

	/// <inheritdoc/>
	public readonly IntPtr DangerousGetHandle() => handle;
}