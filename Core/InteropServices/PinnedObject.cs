using System.Diagnostics.CodeAnalysis;

namespace Vanara.InteropServices;

/// <summary>A safe class that represents an object that is pinned in memory.</summary>
/// <seealso cref="IDisposable"/>
public class PinnedObject : IDisposable
{
	private readonly int mOffset;
	private GCHandle pinnedArray;

	/// <summary>Initializes a new instance of the <see cref="PinnedObject"/> class.</summary>
	/// <param name="obj">The object to pin.</param>
	/// <param name="offset">The offset into the pinned bytes used to return a pointer.</param>
	public PinnedObject(object? obj, int offset = 0)
	{
		mOffset = offset;
		SetObject(obj);
	}

	/// <summary>Creates a pinned object from a nullable structure.</summary>
	/// <typeparam name="T">The type of the structure.</typeparam>
	/// <param name="obj">The value to pin.</param>
	/// <param name="offset">The offset into the pinned bytes used to return a pointer.</param>
	/// <returns>A new instance of <see cref="PinnedObject"/>.</returns>
	public static PinnedObject FromNullable<T>(T? obj, int offset = 0) where T : struct => obj.HasValue ? new PinnedObject(obj.Value, offset) : new PinnedObject(null, offset);

	/// <summary>Initializes a new instance of the <see cref="PinnedObject"/> class.</summary>
	[ExcludeFromCodeCoverage]
	protected PinnedObject() { }

	/// <summary>Gets a value indicating whether the object is no longer pinned.</summary>
	/// <value><c>true</c> if the object is no longer pinned; otherwise, <c>false</c>.</value>
	public bool IsInvalid => !pinnedArray.IsAllocated;

	/// <summary>Get a pointer ( <see cref="IntPtr"/>) to the pinned memory of the object with any preset offset.</summary>
	/// <param name="ap">The <see cref="PinnedObject"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator IntPtr(PinnedObject ap) => !ap.IsInvalid ? ap.pinnedArray.AddrOfPinnedObject().Offset(ap.mOffset) : IntPtr.Zero;

	/// <summary>Get an unsafe pointer to the pinned memory of the object with any preset offset.</summary>
	/// <param name="ap">The <see cref="PinnedObject"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static unsafe implicit operator void*(PinnedObject ap) => !ap.IsInvalid ? (void*)ap.pinnedArray.AddrOfPinnedObject().Offset(ap.mOffset) : null;

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		if (pinnedArray.IsAllocated)
			pinnedArray.Free();
	}

	/// <summary>Sets the object. This should only be called once per instance in the constructor.</summary>
	/// <param name="obj">The object to pin.</param>
	protected void SetObject(object? obj)
	{
		if (obj != null)
			pinnedArray = GCHandle.Alloc(obj, GCHandleType.Pinned);
	}
}
