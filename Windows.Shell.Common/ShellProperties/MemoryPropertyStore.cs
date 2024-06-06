using System.Runtime.InteropServices.ComTypes;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.Windows.Shell;

/// <summary>An in-memory property store.</summary>
/// <seealso cref="PropertyStore"/>
public class MemoryPropertyStore : PropertyStore
{
	/// <summary>Initializes a new instance of the <see cref="MemoryPropertyStore"/> class.</summary>
	public MemoryPropertyStore() { }

	/// <summary>Initializes a new instance of the <see cref="MemoryPropertyStore"/> class from a stream.</summary>
	/// <param name="stream">The stream.</param>
	/// <exception cref="ArgumentNullException">stream</exception>
	public MemoryPropertyStore(IStream stream) : this()
	{
		if (stream is null) throw new ArgumentNullException(nameof(stream));
		stream.Stat(out var stat, 0);
		if (stat.cbSize > 128 * 1024)
			throw Marshal.GetExceptionForHR(HRESULT.STG_E_MEDIUMFULL)!;
		else if (stat.cbSize > 0)
			Run(ps => ((IPersistStream)ps!).Load(stream));
	}

	/// <summary>Clones a property store to a memory property store.</summary>
	/// <param name="ps">The property store to clone.</param>
	/// <returns>The cloned memory property store.</returns>
	/// <exception cref="ArgumentNullException">ps</exception>
	public static MemoryPropertyStore ClonePropertyStoreToMemory(IPropertyStore ps)
	{
		if (ps is null) throw new ArgumentNullException(nameof(ps));
		var ms = new MemoryPropertyStore();
		var cnt = ps.GetCount();
		for (var i = 0U; i < cnt; i++)
		{
			var key = ps.GetAt(i);
			ms.Add(key, ps.GetValue(key));
		}
		return ms;
	}

	/// <summary>Saves the contents of this property store to a stream.</summary>
	/// <param name="stream">The stream that recieves the contents of this property store.</param>
	/// <exception cref="ArgumentNullException">stream</exception>
	public void SaveToStream(IStream stream)
	{
		if (stream is null) throw new ArgumentNullException(nameof(stream));
		Run(ps =>
		{
			var psps = (IPersistSerializedPropStorage)ps!;
			var pPersistStream = (IPersistStream)psps;
			pPersistStream.Save(stream, true);
		});
	}

	/// <inheritdoc/>
	protected override IPropertyStore? GetIPropertyStore()
	{
		PSCreateMemoryPropertyStore(typeof(IPropertyStore).GUID, out var ppv).ThrowIfFailed();
		return (IPropertyStore)(ppv ?? throw new InsufficientMemoryException());
	}
}