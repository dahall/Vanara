using System.ComponentModel;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.Windows.Shell;

/// <summary>A property store for a <see cref="ShellItem"/>.</summary>
/// <seealso cref="PropertyStore"/>
public sealed class ShellItemPropertyStore : PropertyStore
{
	/// <summary>The shell item</summary>
	private readonly ShellItem shellItem;

	/// <summary>Initializes a new instance of the <see cref="ShellItemPropertyStore"/> class.</summary>
	/// <param name="item">The ShellItem instance.</param>
	/// <param name="propChangedHandler">The optional property changed handler.</param>
	internal ShellItemPropertyStore(ShellItem item, PropertyChangedEventHandler? propChangedHandler = null)
	{
		//item.ThrowIfNoShellItem2();
		shellItem = item;
		if (propChangedHandler != null)
			PropertyChanged += propChangedHandler;
	}

	/// <summary>
	/// Gets or sets the ICreateObject used instead of CoCreateInstance to create an instance of the property handler associated with
	/// the Shell item on which this method is called. If this value is set, <see cref="PropertyFilter"/> will be ignored.
	/// </summary>
	/// <value>The creator object.</value>
	[DefaultValue(null)]
	public ICreateObject? Creator { get; set; }

	/// <summary>
	/// Gets or sets a set of properties used to filter the property store. This value can be <see langword="null"/>. This value will be
	/// ignored if <see cref="Creator"/> is also set.
	/// </summary>
	/// <value>The list of properties used to filter.</value>
	[DefaultValue(null)]
	public PROPERTYKEY[]? PropertyFilter { get; set; }

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public override void Dispose()
	{
		base.Dispose();
		GC.SuppressFinalize(this);
	}

	/// <summary>Gets the CLSID of a supplied property key.</summary>
	/// <param name="propertyKey">The property key.</param>
	/// <returns>The CLSID related to the property key.</returns>
	public Guid GetCLSID(PROPERTYKEY propertyKey) => shellItem?.iShellItem2?.GetCLSID(propertyKey) ?? Guid.Empty;

	/// <summary>The IPropertyStore instance. This can be null.</summary>
	protected override IPropertyStore? GetIPropertyStore()
	{
		if (shellItem is ShellLink lnk)
			return (IPropertyStore)lnk.link;
		try
		{
			if (Creator != null)
				return shellItem?.iShellItem2?.GetPropertyStoreWithCreateObject(flags, Creator, typeof(IPropertyStore).GUID);
			if (PropertyFilter != null && PropertyFilter.Length > 0)
				return shellItem?.iShellItem2?.GetPropertyStoreForKeys(PropertyFilter, (uint)PropertyFilter.Length, flags, typeof(IPropertyStore).GUID);
			return shellItem?.iShellItem2?.GetPropertyStore(flags, typeof(IPropertyStore).GUID);
		}
		catch (COMException comex) when (comex.ErrorCode == HRESULT.E_FAIL)
		{
			throw new InvalidOperationException($"The ShellItem does not support a property store with the flags: {flags}", comex);
		}
	}
}