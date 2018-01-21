using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.Windows.Shell
{
	public sealed class ShellItemPropertyStore : PropertyStore
	{
		private readonly ShellItem shellItem;
		private GETPROPERTYSTOREFLAGS flags = GETPROPERTYSTOREFLAGS.GPS_DEFAULT;

		internal ShellItemPropertyStore(ShellItem item, PropertyChangedEventHandler propChangedHandler = null)
		{
			shellItem = item;
			Refresh();
			if (propChangedHandler != null)
				PropertyChanged += propChangedHandler;
		}

		[DefaultValue(false)]
		public bool NoInheritedProperties
		{
			get => flags.IsFlagSet(GETPROPERTYSTOREFLAGS.GPS_HANDLERPROPERTIESONLY);
			set
			{
				if (NoInheritedProperties == value) return;
				flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_HANDLERPROPERTIESONLY, value);
				Refresh();
			}
		}

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
				Refresh();
			}
		}

		public override bool IsReadOnly => ReadOnly;

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
					flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_DELAYCREATION | GETPROPERTYSTOREFLAGS.GPS_TEMPORARY, false);
				Refresh();
			}
		}

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
					flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_READWRITE, true);
					flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_DELAYCREATION | GETPROPERTYSTOREFLAGS.GPS_OPENSLOWITEM, false);
				}
				Refresh();
			}
		}

		/// <summary>Gets the CLSID of a supplied property key.</summary>
		/// <param name="propertyKey">The property key.</param>
		/// <returns>The CLSID related to the property key.</returns>
		public Guid GetCLSID(PROPERTYKEY propertyKey)
		{
			shellItem.ThrowIfNoShellItem2();
			return shellItem.iShellItem2.GetCLSID(ref propertyKey);
		}

		public void Refresh()
		{
			shellItem.ThrowIfNoShellItem2();
			if (iprops != null)
				Marshal.ReleaseComObject(iprops);
			iprops = shellItem.iShellItem2.GetPropertyStore(flags, typeof(IPropertyStore).GUID);
		}
	}
}