using System.Collections.Generic;
using System.Linq;

namespace Vanara.Collections;

/// <summary>Represents a list of objects that disposes its elements when disposed.</summary>
/// <remarks>
/// When the DisposingList is disposed, it attempts to dispose each contained object that either implements IDisposable or is a COM object.
/// For objects that are COM objects but do not implement IDisposable, the COM reference is released using Marshal.ReleaseComObject. After
/// disposal, the list is cleared. This class is useful for managing collections of disposable or COM objects to ensure proper resource cleanup.
/// </remarks>
public class DisposingList : List<object>, IDisposable
{
	private bool disposed;

	/// <summary>Initializes a new instance of the <see cref="DisposingList"/> class that is empty and has the default initial capacity.</summary>
	public DisposingList() : base() { }

	/// <summary>Initializes a new instance of the DisposingList class that contains elements copied from the specified collection.</summary>
	/// <remarks>
	/// Each element in the collection is added to the list in the order returned by the collection's enumerator. The DisposingList is
	/// intended to manage the disposal of its elements when it is disposed. Ensure that the objects in the collection either implement
	/// IDisposable or are COM objects.
	/// </remarks>
	/// <param name="collection">The collection whose elements are copied to the new list. Cannot be null.</param>
	public DisposingList(IEnumerable<object> collection) : base(collection) { }

	/// <summary>Finalizes an instance of the <see cref="DisposingList"/> class.</summary>
	~DisposingList() => Dispose(false);

	/// <summary>Releases the unmanaged resources used by the collection and optionally releases the managed resources.</summary>
	/// <remarks>
	/// This method is called by the public Dispose() method and the finalizer. When disposing is true, this method disposes all managed
	/// objects contained in the collection that implement IDisposable and releases any COM objects. When disposing is false, only unmanaged
	/// resources are released. Override this method to release additional resources in a derived class.
	/// </remarks>
	/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
	protected virtual void Dispose(bool disposing)
	{
		if (disposed)
			return;
		Reverse(); // dispose in reverse order of addition
		foreach (var item in this.WhereNotNull())
		{
			if (item is IDisposable d)
				d.Dispose();
			else if (item.GetType().IsCOMObject)
				Marshal.ReleaseComObject(item);
		}
		Clear();
		disposed = true;
	}

	/// <inheritdoc/>
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
}