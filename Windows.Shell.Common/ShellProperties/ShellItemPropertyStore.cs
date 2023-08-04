using System.Collections.Generic;
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
	private ShellItem shellItem;

	/// <summary>The flags.</summary>
	private GETPROPERTYSTOREFLAGS flags = GETPROPERTYSTOREFLAGS.GPS_BESTEFFORT;

	/// <summary>Initializes a new instance of the <see cref="ShellItemPropertyStore"/> class.</summary>
	/// <param name="item">The ShellItem instance.</param>
	/// <param name="propChangedHandler">The optional property changed handler.</param>
	internal ShellItemPropertyStore(ShellItem item, PropertyChangedEventHandler propChangedHandler = null)
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
	public ICreateObject Creator { get; set; }

	/// <summary>Gets or sets a value indicating whether to include slow properties.</summary>
	/// <value><c>true</c> if including slow properties; otherwise, <c>false</c>.</value>
	[DefaultValue(false)]
	public bool IncludeSlow
	{
		get => flags.IsFlagSet(GETPROPERTYSTOREFLAGS.GPS_OPENSLOWITEM);
		set
		{
			if (IncludeSlow == value) return;
			flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_OPENSLOWITEM, value);
			if (value)
				flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_TEMPORARY | GETPROPERTYSTOREFLAGS.GPS_FASTPROPERTIESONLY, false);
		}
	}

	/// <summary>Gets a value indicating whether the <see cref="ICollection{T}"/> is read-only.</summary>
	public override bool IsReadOnly => ReadOnly;

	/// <summary>Gets or sets a value indicating whether to include only properties directly from the property handler.</summary>
	/// <value><c>true</c> if no inherited properties; otherwise, <c>false</c>.</value>
	[DefaultValue(false)]
	public bool NoInheritedProperties
	{
		get => flags.IsFlagSet(GETPROPERTYSTOREFLAGS.GPS_HANDLERPROPERTIESONLY);
		set
		{
			if (NoInheritedProperties == value) return;
			flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_HANDLERPROPERTIESONLY, value);
			if (value)
				flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_TEMPORARY | GETPROPERTYSTOREFLAGS.GPS_BESTEFFORT | GETPROPERTYSTOREFLAGS.GPS_FASTPROPERTIESONLY, false);
		}
	}

	/// <summary>
	/// Gets or sets a set of properties used to filter the property store. This value can be <see langword="null"/>. This value will be
	/// ignored if <see cref="Creator"/> is also set.
	/// </summary>
	/// <value>The list of properties used to filter.</value>
	[DefaultValue(null)]
	public PROPERTYKEY[] PropertyFilter { get; set; }

	/// <summary>Gets or sets a value indicating whether properties can be read and written.</summary>
	/// <value><c>true</c> if properties are read/write; otherwise, <c>false</c>.</value>
	[DefaultValue(true)]
	public bool ReadOnly
	{
		get => !flags.IsFlagSet(GETPROPERTYSTOREFLAGS.GPS_READWRITE);
		set
		{
			if (ReadOnly == value) return;
			flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_READWRITE, !value);
			if (!value)
				flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_DELAYCREATION | GETPROPERTYSTOREFLAGS.GPS_TEMPORARY | GETPROPERTYSTOREFLAGS.GPS_BESTEFFORT | GETPROPERTYSTOREFLAGS.GPS_FASTPROPERTIESONLY, false);
			else
				flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_HANDLERPROPERTIESONLY);
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="ShellItemPropertyStore"/> provides a writable store, with no initial
	/// properties, that exists for the lifetime of the Shell item instance; basically, a property bag attached to the item instance.
	/// </summary>
	/// <value><c>true</c> if temporary; otherwise, <c>false</c>.</value>
	[DefaultValue(false)]
	public bool Temporary
	{
		get => flags.IsFlagSet(GETPROPERTYSTOREFLAGS.GPS_TEMPORARY);
		set
		{
			if (Temporary == value) return;
			flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_TEMPORARY, value);
			if (value)
			{
				flags = GETPROPERTYSTOREFLAGS.GPS_TEMPORARY;
				ReadOnly = false;
			}
			else
			{
				flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_TEMPORARY, false);
			}
		}
	}

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public override void Dispose()
	{
		shellItem = null;
		base.Dispose();
	}

	/// <summary>Gets the CLSID of a supplied property key.</summary>
	/// <param name="propertyKey">The property key.</param>
	/// <returns>The CLSID related to the property key.</returns>
	public Guid GetCLSID(PROPERTYKEY propertyKey) => shellItem?.iShellItem2?.GetCLSID(propertyKey) ?? Guid.Empty;

	/// <summary>The IPropertyStore instance. This can be null.</summary>
	protected override IPropertyStore GetIPropertyStore()
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