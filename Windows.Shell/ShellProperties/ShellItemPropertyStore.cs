using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.Windows.Shell
{
	/// <summary>A property store for a <see cref="ShellItem"/>.</summary>
	/// <seealso cref="Vanara.Windows.Shell.PropertyStore"/>
	public sealed class ShellItemPropertyStore : PropertyStore
	{
		/// <summary>The shell item</summary>
		private readonly ShellItem shellItem;
		/// <summary>The flags.</summary>
		private GETPROPERTYSTOREFLAGS flags = GETPROPERTYSTOREFLAGS.GPS_DEFAULT;

		/// <summary>Initializes a new instance of the <see cref="ShellItemPropertyStore"/> class.</summary>
		/// <param name="item">The ShellItem instance.</param>
		/// <param name="propChangedHandler">The optional property changed handler.</param>
		internal ShellItemPropertyStore(ShellItem item, PropertyChangedEventHandler propChangedHandler = null)
		{
			shellItem = item;
			Refresh();
			if (propChangedHandler != null)
				PropertyChanged += propChangedHandler;
		}

		/// <summary>Gets a property description list object containing descriptions of all properties.</summary>
		/// <returns>A complete <see cref="PropertyDescriptionList"/> instance.</returns>
		public PropertyDescriptionList Descriptions => shellItem.PropertyDescriptions;

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
				Refresh();
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="ICollection{T}" /> is read-only.</summary>
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
				Refresh();
			}
		}

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
				Refresh();
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ShellItemPropertyStore"/> provides a writable store, with no initial properties, that exists
		/// for the lifetime of the Shell item instance; basically, a property bag attached to the item instance..
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
					Refresh();
				}
			}
		}

		/// <summary>Gets the CLSID of a supplied property key.</summary>
		/// <param name="propertyKey">The property key.</param>
		/// <returns>The CLSID related to the property key.</returns>
		public Guid GetCLSID(PROPERTYKEY propertyKey)
		{
			shellItem.ThrowIfNoShellItem2();
			return shellItem.iShellItem2.GetCLSID(propertyKey);
		}

		/// <summary>Refreshes this instance. This call is intended for internal use only and should not need to be called.</summary>
		public void Refresh()
		{
			shellItem.ThrowIfNoShellItem2();
			if (iprops != null)
				Marshal.ReleaseComObject(iprops);
			iprops = shellItem.iShellItem2.GetPropertyStore(flags, typeof(IPropertyStore).GUID);
		}
	}
}