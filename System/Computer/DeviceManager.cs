using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vanara.Collections;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.SetupAPI;

namespace Vanara.Diagnostics
{
	/// <summary>A dictionary of properties.</summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
	/// <seealso cref="System.Collections.Generic.IDictionary{TKey, TValue}"/>
	public interface IPropertyProvider<TKey, TValue> : IDictionary<TKey, TValue>
	{
	}

	/// <summary>Extension methods for SetupAPI functions and structs.</summary>
	public static class DeviceExtensions
	{
		/// <summary>
		/// Trys to get friendly name for the property key. If not available via <c>PSGetNameFromPropertyKey</c>, then the name of the
		/// defined field is returned (i.e. "DEVPKEY_Device_Class"). If not available, then the Guid and ID are returned.
		/// </summary>
		/// <param name="propKey">The property key.</param>
		/// <returns>The best string representation available.</returns>
		public static string LookupName(this DEVPROPKEY propKey)
		{
			if (PropSys.PSGetNameFromPropertyKey(new Ole32.PROPERTYKEY(propKey.fmtid, propKey.pid), out var str).Succeeded)
				return str;
			return LookupField(propKey)?.Name ?? $"{propKey.fmtid:B}[{propKey.pid}]";
		}

		internal static IEnumerable<Type> GetCorrespondingTypes(this DEVPROPKEY propKey)
		{
			var fi = LookupField(propKey);
			if (fi is null) return Enumerable.Empty<Type>();
			return fi.GetCustomAttributes<CorrespondingTypeAttribute>().Select(a => a.TypeRef);
		}

		internal static System.Reflection.FieldInfo LookupField(this DEVPROPKEY propKey) =>
			typeof(SetupAPI).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).
			Where(fi => fi.FieldType == typeof(DEVPROPKEY) && fi.Name.StartsWith("DEVPKEY") && propKey.Equals((DEVPROPKEY)fi.GetValue(null))).FirstOrDefault();
	}

	/// <summary>A class that represents a device on a machine.</summary>
	public class Device : IDisposable
	{
		private readonly SafeHDEVINFO hdi;
		private readonly Lazy<SP_DEVINSTALL_PARAMS> instParam;
		private readonly Lazy<string> name, desc, instId;
		private SP_DEVINFO_DATA data;
		private DeviceProperties props;
		private DeviceRegProperties rprops;

		internal Device(SafeHDEVINFO hdi, SP_DEVINFO_DATA data)
		{
			this.hdi = hdi;
			this.data = data;
			name = new Lazy<string>(() => Properties[DEVPKEY_NAME]?.ToString() ?? "");
			desc = new Lazy<string>(() => RegistryProperties[SPDRP.SPDRP_DEVICEDESC]?.ToString() ?? "");
			instId = new Lazy<string>(() => Properties[DEVPKEY_Device_InstanceId]?.ToString() ?? "");
			instParam = new Lazy<SP_DEVINSTALL_PARAMS>(GetInstallParams);
		}

		/// <summary>The GUID of the device's setup class.</summary>
		public Guid ClassGuid => data.ClassGuid;

		/// <summary>Gets the data the identifies the device.</summary>
		/// <value>A SP_DEVINFO_DATA structure with identifying device information.</value>
		public SP_DEVINFO_DATA Data => data;

		/// <summary>The description of the device instance.</summary>
		/// <value>The description.</value>
		public string Description => desc.Value;

		/// <summary>Gets the driver path.</summary>
		public string DriverPath => instParam.Value.DriverPath;

		/// <summary>Gets the handle to the device.</summary>
		/// <value>A HDEVINFO handle.</value>
		public HDEVINFO Handle => hdi;

		/// <summary>
		/// Gets the flags that control installation and user interface operations. Some flags can be set before sending the device
		/// installation request while other flags are set automatically during the processing of some requests.
		/// </summary>
		public DI_FLAGS InstallFlags => instParam.Value.Flags;

		/// <summary>
		/// Gets additional flags that provide control over installation and user interface operations. Some flags can be set before calling
		/// the device installer functions while other flags are set automatically during the processing of some functions.
		/// </summary>
		public DI_FLAGSEX InstallFlagsEx => instParam.Value.FlagsEx;

		/// <summary>The instance identifier of the device instance.</summary>
		/// <value>The instance identifier.</value>
		public string InstanceId => instId.Value;

		/// <summary>
		/// A string that contains the name of the remote computer. If the device information set is for the local computer, this member is
		/// <see langword="null"/>.
		/// </summary>
		public string MachineName => hdi.MachineName;

		/// <summary>The name of the device instance.</summary>
		/// <value>The name.</value>
		public string Name => name.Value;

		/// <summary>Gets a dictionary of properties.</summary>
		/// <value>The properties.</value>
		public IPropertyProvider<DEVPROPKEY, object> Properties =>
			props ??= (MachineName is null ? new DeviceProperties(this) : throw new InvalidOperationException("Properties cannot be retrieved for remote devices."));

		/// <summary>Gets a dictionary of registry properties.</summary>
		/// <value>The registry properties.</value>
		public IPropertyProvider<SPDRP, object> RegistryProperties =>
			rprops ??= (MachineName is null ? new DeviceRegProperties(this) : throw new InvalidOperationException("Properties cannot be retrieved for remote devices."));

		/// <inheritdoc/>
		public void Dispose() { }

		/// <summary>Retrieves a specified custom device property from the registry.</summary>
		/// <param name="propName">A registry value name representing a custom property.</param>
		/// <param name="combine">
		/// If <see langword="true"/>, the function retrieves both device instance-specific property values and hardware ID-specific
		/// property values, concatenated as a REG_MULTI_SZ-typed string.
		/// </param>
		/// <returns>The requested property information or <see langword="null"/> if the property does not exist.</returns>
		public object GetCustomProperty(string propName, bool combine = false)
		{
			if (!SetupDiGetCustomDeviceProperty(hdi, data, propName, combine ? DICUSTOMDEVPROP.DICUSTOMDEVPROP_MERGE_MULTISZ : 0, out _, default, 0, out var bufSz) &&
				Win32Error.GetLastError() == Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				using var mem = new SafeCoTaskMemHandle(bufSz);
				Win32Error.ThrowLastErrorIfFalse(SetupDiGetCustomDeviceProperty(hdi, data, propName, combine ? DICUSTOMDEVPROP.DICUSTOMDEVPROP_MERGE_MULTISZ : 0, out var regType, mem, mem.Size, out bufSz));
				return DeviceClass.DeviceClassRegProperties.GetRegValue(mem, regType);
			}
			return null;
		}

		/// <summary>Retrieves an icon for this device.</summary>
		/// <param name="iconSize">
		/// The size, in pixels, of the icon to be retrieved. Use the system metric index SM_CXICON to specify a default-sized icon or use
		/// the system metric index SM_CXSMICON to specify a small icon.
		/// </param>
		/// <returns>A safe handle to the icon that this function retrieves.</returns>
		/// <remarks>
		/// <para><c>GetIcon</c> attempts to retrieve an icon for the device as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If the DEVPKEY_DrvPkg_Icon device property of the device includes a list of resource-identifier strings, the function attempts
		/// to retrieve the icon that is specified by the first resource-identifier string in the list.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the function cannot retrieve a device-specific icon, it will then attempt to retrieve the class icon for the device. For
		/// information about class icons, see SetupDiLoadClassIcon.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the function cannot retrieve the class icon for the device, it will then attempt to retrieve the icon for the Unknown device
		/// setup class, where the icon for the Unknown device setup class includes the image of a question mark (?).
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		public User32.SafeHICON GetIcon(System.Drawing.Size iconSize)
		{
			Win32Error.ThrowLastErrorIfFalse(SetupDiLoadDeviceIcon(hdi, data, (uint)iconSize.Width, (uint)iconSize.Height, 0, out var hIcon));
			return new User32.SafeHICON((IntPtr)hIcon);
		}

		private SP_DEVINSTALL_PARAMS GetInstallParams()
		{
			var p = StructHelper.InitWithSize<SP_DEVINSTALL_PARAMS>();
			Win32Error.ThrowLastErrorIfFalse(SetupDiGetDeviceInstallParams(hdi, data, ref p));
			return p;
		}

		/// <summary>Accesses properties with a device.</summary>
		public class DeviceProperties : VirtualDictionary<DEVPROPKEY, object>, IPropertyProvider<DEVPROPKEY, object>
		{
			private readonly Device parent;

			internal DeviceProperties(Device dev) : base(false) => parent = dev;

			private DeviceProperties() : base(false) => throw new InvalidOperationException();

			/// <inheritdoc/>
			public override int Count
			{
				get
				{
					SetupDiGetDevicePropertyKeys(parent.hdi, parent.data, null, 0, out var cnt);
					Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
					return (int)cnt;
				}
			}

			/// <inheritdoc/>
			public override ICollection<DEVPROPKEY> Keys
			{
				get
				{
					SetupDiGetDevicePropertyKeys(parent.hdi, parent.data, null, 0, out var cnt);
					Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
					var propKeys = new DEVPROPKEY[(int)cnt];
					Win32Error.ThrowLastErrorIfFalse(SetupDiGetDevicePropertyKeys(parent.hdi, parent.data, propKeys, cnt, out _));
					return propKeys;
				}
			}

			/// <inheritdoc/>
			public override bool Remove(DEVPROPKEY key) =>
				SetupDiSetDeviceProperty(parent.hdi, parent.data, key, 0, default, 0);

			/// <inheritdoc/>
			public override bool TryGetValue(DEVPROPKEY key, out object value) => GetValue(key, out value).Succeeded;

			/// <inheritdoc/>
			protected override void SetValue(DEVPROPKEY key, object value)
			{
				value = DeviceClass.DeviceClassProperties.CommonPropConv(value);
				var type = GetPropType(key, value?.GetType());
				var mem = DeviceClass.DeviceClassProperties.PrepValue(value, type);
				try
				{
					if (mem is null)
						throw new ArgumentException("Unable to convert object to property type.", nameof(value));
					Win32Error.ThrowLastErrorIfFalse(SetupDiSetDeviceProperty(parent.hdi, parent.data, key, type, mem.DangerousGetHandle(), mem.Size));
				}
				finally
				{
					mem?.Dispose();
				}
			}

			private DEVPROPTYPE GetPropType(DEVPROPKEY propKey, Type valType)
			{
				if (SetupDiGetDeviceProperty(parent.hdi, parent.data, propKey, out var type, default, default, out _))
					return type;
				var fi = typeof(DEVPROPTYPE).GetFields().Where(fi => fi.IsLiteral && fi.GetCustomAttributes<CorrespondingTypeAttribute>(false, a => a.TypeRef == valType).Any()).FirstOrDefault();
				return fi is not null ? (DEVPROPTYPE)fi.GetValue(null) : throw new ArgumentException("Unable to determine DEVPROPTYPE.");
			}

			private Win32Error GetValue(in DEVPROPKEY propKey, out object value)
			{
				value = null;
				if (!SetupDiGetDeviceProperty(parent.hdi, parent.data, propKey, out _, default, 0, out var bufSz))
				{
					var err = Win32Error.GetLastError();
					if (err != Win32Error.ERROR_INSUFFICIENT_BUFFER)
						return err;
					using var mem = new SafeCoTaskMemHandle(bufSz);
					if (!SetupDiGetDeviceProperty(parent.hdi, parent.data, propKey, out var propType, mem, mem.Size, out bufSz))
						return Win32Error.GetLastError();
					value = SetupDiPropertyToManagedObject(mem, propType, propKey.GetCorrespondingTypes().FirstOrDefault());
				}
				return Win32Error.ERROR_SUCCESS;
			}
		}

		/// <summary>Accesses registry properties with a device class.</summary>
		public class DeviceRegProperties : VirtualDictionary<SPDRP, object>, IPropertyProvider<SPDRP, object>
		{
			private readonly Device parent;

			internal DeviceRegProperties(Device dev) : base(false) => parent = dev;

			private DeviceRegProperties() : base(false) => throw new InvalidOperationException();

			/// <inheritdoc/>
			public override int Count => Enum.GetValues(typeof(SPDRP)).Length;

			/// <inheritdoc/>
			public override ICollection<SPDRP> Keys => (ICollection<SPDRP>)Enum.GetValues(typeof(SPDRP));

			/// <inheritdoc/>
			public override bool Remove(SPDRP key) => SetupDiSetDeviceRegistryProperty(parent.hdi, ref parent.data, key, default, 0);

			/// <inheritdoc/>
			public override bool TryGetValue(SPDRP key, out object value) => GetValue(key, out value).Succeeded;

			/// <inheritdoc/>
			protected override void SetValue(SPDRP key, object value)
			{
				if (value is null)
					throw new ArgumentNullException(nameof(value));
				value = DeviceClass.DeviceClassRegProperties.CommonPropConv(value);
				if (!CorrespondingTypeAttribute.CanSet(key, value.GetType()))
					throw new ArgumentException("Value type not valid for key.");
				SafeAllocatedMemoryHandle mem = value switch
				{
					var v when v.GetType().IsValueType && !v.GetType().IsEnum => SafeCoTaskMemHandle.CreateFromStructure(value),
					var v when v.GetType().IsValueType && v.GetType().IsEnum => SafeCoTaskMemHandle.CreateFromStructure((uint)value),
					IEnumerable<string> ies => SafeCoTaskMemHandle.CreateFromStringList(ies),
					byte[] ba => new SafeCoTaskMemHandle(ba),
					string s => new SafeCoTaskMemString(s, System.Runtime.InteropServices.CharSet.Auto),
					_ => throw new ArgumentException("Unable to convert object to property type.", nameof(value))
				};
				try
				{
					Win32Error.ThrowLastErrorIfFalse(SetupDiSetDeviceRegistryProperty(parent.hdi, ref parent.data, key, mem.DangerousGetHandle(), mem.Size));
				}
				finally
				{
					mem?.Dispose();
				}
			}

			private Win32Error GetValue(SPDRP propKey, out object value)
			{
				value = null;
				if (!SetupDiGetDeviceRegistryProperty(parent.hdi, parent.data, propKey, out _, default, 0, out var bufSz))
				{
					if (bufSz == 0)
						return Win32Error.ERROR_NOT_FOUND;
					using var mem = new SafeCoTaskMemHandle(bufSz);
					if (!SetupDiGetDeviceRegistryProperty(parent.hdi, parent.data, propKey, out var propType, mem, mem.Size, out bufSz))
						return Win32Error.GetLastError();
					value = DeviceClass.DeviceClassRegProperties.GetRegValue(propKey, mem, propType);
				}
				return Win32Error.ERROR_SUCCESS;
			}
		}
	}

	/// <summary>A class that provides detail about a device setup class available on a machine.</summary>
	/// <remarks>
	/// Device setup classes provide a mechanism for grouping devices that are installed and configured in the same way. A setup class
	/// identifies the class installer and class co-installers that are involved in installing the devices that belong to the class. For
	/// example, all CD-ROM drives belong to the CDROM setup class and will use the same co-installer when installed.
	/// </remarks>
	public class DeviceClass : IDisposable
	{
		private static readonly Dictionary<string, SP_CLASSIMAGELIST_DATA> imgListData = new();
#pragma warning disable IDE0052 // Remove unread private members
		private static readonly FinalizeImgLists imgListFinalizer = new();
#pragma warning restore IDE0052 // Remove unread private members
		private readonly Lazy<int?> bmpIdx, imgIdx;
		private readonly Lazy<string> name, desc;
		private DeviceClassProperties props;
		private DeviceClassRegProperties rprops;

		/// <summary>Initializes a new instance of the <see cref="DeviceClass"/> class with its GUID and optional machine name.</summary>
		/// <param name="guid">The GUID for the device setup class.</param>
		/// <param name="machineName">
		/// The name of the machine on which devices are managed. <see langword="null"/> indicates the local machine.
		/// </param>
		public DeviceClass(Guid guid, string machineName = null)
		{
			Guid = guid;
			MachineName = machineName;
			name = new Lazy<string>(() => GetClassString(SetupDiClassNameFromGuidEx, 32));
			desc = new Lazy<string>(() => GetClassString(SetupDiGetClassDescriptionEx, 256));
			bmpIdx = new Lazy<int?>(() => SetupDiGetClassBitmapIndex(Guid, out var idx) ? idx : null);
			imgIdx = new Lazy<int?>(() => SetupDiGetClassImageIndex(GetImageList(), Guid, out var idx) ? idx : null);
		}

		/// <summary>Initializes a new instance of the <see cref="DeviceClass"/> class from its class name and optional machine name.</summary>
		/// <param name="name">The name of the class.</param>
		/// <param name="machineName">
		/// The name of the machine on which devices are managed. <see langword="null"/> indicates the local machine.
		/// </param>
		public DeviceClass(string name, string machineName = null) : this(FromName(name, machineName), machineName)
		{
		}

		private delegate bool GetClassStringDelegate(in Guid ClassGuid, StringBuilder ClassName, uint ClassNameSize, out uint RequiredSize,
			string MachineName, IntPtr Reserved = default);

		/// <summary>Gets the index of the mini-icon supplied for this class.</summary>
		/// <value>The index of the mini-icon supplied for this class.</value>
		public int? BitmapIndex => bmpIdx.Value;

		/// <summary>Gets the class description associated with the specified setup class GUID.</summary>
		/// <value>The class description associated with the specified setup class GUID.</value>
		/// <remarks>
		/// If there is a friendly name in the registry key for the class, this routine returns the friendly name. Otherwise, this routine
		/// returns the class name.
		/// </remarks>
		public string Description => desc.Value;

		/// <summary>Gets the GUID for this setup class.</summary>
		/// <value>The GUID for this setup class.</value>
		public Guid Guid { get; }

		/// <summary>Gets the index within the class image list.</summary>
		/// <value>The index within the class image list.</value>
		public int? ImageIndex => imgIdx.Value;

		/// <summary>Gets the image list of bitmaps for every class installed on this system.</summary>
		/// <value>The image list handle of bitmaps for every class installed on this system.</value>
		public HIMAGELIST ImageListHandle => GetImageList().ImageList;

		/// <summary>Gets the name of the machine on which devices are managed. <see langword="null"/> indicates the local machine.</summary>
		/// <value>The machine name for this manager.</value>
		public string MachineName { get; }

		/// <summary>Gets the class name associated with a class GUID.</summary>
		/// <value>The class name associated with a class GUID.</value>
		public string Name => name.Value;

		/// <summary>Gets a value that controls whether devices in this setup class are displayed by the Device Manager.</summary>
		public bool? NoDisplay => (bool?)Properties[DEVPKEY_DeviceClass_NoDisplayClass];

		/// <summary>Gets a value that controls whether devices in this device setup class are displayed in the <c>Add Hardware Wizard</c>.</summary>
		public bool? NoInstall => (bool?)Properties[DEVPKEY_DeviceClass_NoInstallClass];

		/// <summary>Gets a dictionary of properties.</summary>
		/// <value>The properties.</value>
		public IPropertyProvider<DEVPROPKEY, object> Properties => props ??= new DeviceClassProperties(Guid, MachineName);

		/// <summary>Gets a dictionary of registry properties.</summary>
		/// <value>The registry properties.</value>
		public IPropertyProvider<SPCRP, object> RegistryProperties => rprops ??= new DeviceClassRegProperties(Guid, MachineName);

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
		}

		/// <summary>Gets the devices associated with this device class.</summary>
		/// <returns>A sequence of <see cref="Device"/> instances with this device class.</returns>
		public IEnumerable<Device> GetDevices() => new DeviceCollection(Guid, null, MachineName);

		private static Guid FromName(string name, string machine)
		{
			SetupDiClassGuidsFromNameEx(name, null, 0, out var len, machine);
			if (len == 0) Win32Error.ThrowLastError();
			var guids = new Guid[(int)len];
			Win32Error.ThrowLastErrorIfFalse(SetupDiClassGuidsFromNameEx(name, guids, len, out _, machine));
			return guids[0];
		}

		private string GetClassString(GetClassStringDelegate f, uint initSz)
		{
			var sz = initSz;
			var sb = new StringBuilder((int)sz);
			if (!f(Guid, sb, sz, out sz, MachineName))
			{
				Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
				sb.Capacity = (int)sz;
				Win32Error.ThrowLastErrorIfFalse(f(Guid, sb, sz, out _, MachineName));
			}
			return sb.ToString();
		}

		private SP_CLASSIMAGELIST_DATA GetImageList()
		{
			if (!imgListData.TryGetValue(MachineName ?? "", out var data))
			{
				data = StructHelper.InitWithSize<SP_CLASSIMAGELIST_DATA>();
				Win32Error.ThrowLastErrorIfFalse(SetupDiGetClassImageListEx(ref data, MachineName));
				imgListData.Add(MachineName ?? "", data);
			}
			return data;
		}

		/// <summary>Accesses properties with a device class.</summary>
		public class DeviceClassProperties : VirtualDictionary<DEVPROPKEY, object>, IPropertyProvider<DEVPROPKEY, object>
		{
			private readonly Guid Guid;

			private readonly string MachineName;

			internal DeviceClassProperties(Guid guid, string machineName) : base(false)
			{
				Guid = guid;
				MachineName = machineName;
			}

			private DeviceClassProperties() : base(false) => throw new InvalidOperationException();

			/// <inheritdoc/>
			public override int Count
			{
				get
				{
					SetupDiGetClassPropertyKeysEx(Guid, null, 0, out var cnt, DICLASSPROP.DICLASSPROP_INSTALLER, MachineName);
					Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
					return (int)cnt;
				}
			}

			/// <inheritdoc/>
			public override ICollection<DEVPROPKEY> Keys
			{
				get
				{
					SetupDiGetClassPropertyKeysEx(Guid, null, 0, out var cnt, DICLASSPROP.DICLASSPROP_INSTALLER, MachineName);
					Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
					var propKeys = new DEVPROPKEY[(int)cnt];
					Win32Error.ThrowLastErrorIfFalse(SetupDiGetClassPropertyKeysEx(Guid, propKeys, cnt, out _, DICLASSPROP.DICLASSPROP_INSTALLER, MachineName));
					return propKeys;
				}
			}

			/// <inheritdoc/>
			public override bool Remove(DEVPROPKEY key) =>
				SetupDiSetClassPropertyEx(Guid, key, 0, default, 0, DICLASSPROP.DICLASSPROP_INSTALLER, MachineName);

			/// <inheritdoc/>
			public override bool TryGetValue(DEVPROPKEY key, out object value) => GetValue(key, out value).Succeeded;

			internal static object CommonPropConv(object value) => value switch
			{
				bool b => (BOOLEAN)b,
				DateTime dt => dt.ToFileTimeStruct(),
				decimal dec => new CY(dec),
				ISafeMemoryHandle h => h.GetBytes(0, h.Size),
				_ => value,
			};

			internal static ISafeMemoryHandle PrepValue(object value, DEVPROPTYPE type)
			{
				// Changes types that need conversion or quick outs
				if (value is null)
					return SafeCoTaskMemHandle.Null;
				if (value is IEnumerable<string> sa && (type.IsFlagSet(DEVPROPTYPE.DEVPROP_TYPEMOD_LIST) && (type.IsFlagSet(DEVPROPTYPE.DEVPROP_TYPE_STRING) || type.IsFlagSet(DEVPROPTYPE.DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING))))
					return SafeCoTaskMemHandle.CreateFromStringList(sa, StringListPackMethod.Concatenated, System.Runtime.InteropServices.CharSet.Unicode);
				var valType = value.GetType();

				// Validate type of property against supplied type
				if (type.IsFlagSet(DEVPROPTYPE.DEVPROP_TYPEMOD_LIST))
					throw new ArgumentException("Invalid list.", nameof(value));
				if (type.IsFlagSet(DEVPROPTYPE.DEVPROP_TYPEMOD_ARRAY))
				{
					if (!valType.IsArray)
						throw new ArgumentException("Array required.", nameof(value));
					valType = valType.GetElementType();
					type &= DEVPROPTYPE.DEVPROP_MASK_TYPE;
				}
				var cTypes = CorrespondingTypeAttribute.GetCorrespondingTypes(type & DEVPROPTYPE.DEVPROP_MASK_TYPE).ToArray();
				if (cTypes.Length > 0 && Array.IndexOf(cTypes, valType) < 0)
					throw new ArgumentException($"Value type or element type cannot be {valType.Name}", nameof(value));

				// Push value into mem
				switch (value)
				{
					case byte[] ba:
						return new SafeCoTaskMemHandle(ba);

					case string s:
						return new SafeCoTaskMemHandle(s);

					default:
						var sz = InteropExtensions.SizeOf(valType);
						if (valType.IsArray) sz *= ((Array)value).Length;
						var mem = new SafeCoTaskMemHandle(sz);
						mem.DangerousGetHandle().Write(value, 0, mem.Size);
						return mem;
				}
			}

			/// <inheritdoc/>
			protected override void SetValue(DEVPROPKEY key, object value)
			{
				value = CommonPropConv(value);
				var type = GetPropType(key, value?.GetType());
				var mem = PrepValue(value, type);
				try
				{
					if (mem is null)
						throw new ArgumentException("Unable to convert object to property type.", nameof(value));
					Win32Error.ThrowLastErrorIfFalse(SetupDiSetClassPropertyEx(Guid, key, type, mem.DangerousGetHandle(), mem.Size, DICLASSPROP.DICLASSPROP_INSTALLER, MachineName));
				}
				finally
				{
					mem?.Dispose();
				}
			}

			private DEVPROPTYPE GetPropType(DEVPROPKEY propKey, Type valType)
			{
				if (SetupDiGetClassPropertyEx(Guid, propKey, out var type, default, default, out _, DICLASSPROP.DICLASSPROP_INSTALLER, MachineName))
					return type;
				var fi = typeof(DEVPROPTYPE).GetFields().Where(fi => fi.IsLiteral && fi.GetCustomAttributes<CorrespondingTypeAttribute>(false, a => a.TypeRef == valType).Any()).FirstOrDefault();
				return fi is not null ? (DEVPROPTYPE)fi.GetValue(null) : throw new ArgumentException("Unable to determine DEVPROPTYPE.");
			}

			private Win32Error GetValue(in DEVPROPKEY propKey, out object value)
			{
				value = null;
				if (!SetupDiGetClassPropertyEx(Guid, propKey, out _, default, 0, out var bufSz, DICLASSPROP.DICLASSPROP_INSTALLER, MachineName))
				{
					var err = Win32Error.GetLastError();
					if (err != Win32Error.ERROR_INSUFFICIENT_BUFFER)
						return err;
					using var mem = new SafeCoTaskMemHandle(bufSz);
					if (!SetupDiGetClassPropertyEx(Guid, propKey, out var propType, mem, mem.Size, out bufSz, DICLASSPROP.DICLASSPROP_INSTALLER, MachineName))
						return Win32Error.GetLastError();
					value = SetupDiPropertyToManagedObject(mem, propType, propKey.GetCorrespondingTypes().FirstOrDefault());
				}
				return Win32Error.ERROR_SUCCESS;
			}
		}

		/// <summary>Accesses registry properties with a device class.</summary>
		public class DeviceClassRegProperties : VirtualDictionary<SPCRP, object>, IPropertyProvider<SPCRP, object>
		{
			private readonly Guid Guid;

			private readonly string MachineName;

			internal DeviceClassRegProperties(Guid guid, string machineName) : base(false)
			{
				Guid = guid;
				MachineName = machineName;
			}

			private DeviceClassRegProperties() : base(false) => throw new InvalidOperationException();

			/// <inheritdoc/>
			public override int Count => Enum.GetValues(typeof(SPCRP)).Length;

			/// <inheritdoc/>
			public override ICollection<SPCRP> Keys => (ICollection<SPCRP>)Enum.GetValues(typeof(SPCRP));

			/// <inheritdoc/>
			public override bool Remove(SPCRP key) => SetupDiSetClassRegistryProperty(Guid, key, default, 0, MachineName);

			/// <inheritdoc/>
			public override bool TryGetValue(SPCRP key, out object value) => GetValue(key, out value).Succeeded;

			internal static object CommonPropConv(object value) => value switch
			{
				bool b => (BOOL)b,
				ISafeMemoryHandle h => h.GetBytes(0, h.Size),
				_ => value,
			};

			internal static object GetRegValue<T>(T key, SafeAllocatedMemoryHandle mem, REG_VALUE_TYPE propType) where T : Enum =>
							GetRegValue(mem, propType, CorrespondingTypeAttribute.GetCorrespondingTypes(key).FirstOrDefault());

			internal static object GetRegValue(SafeAllocatedMemoryHandle mem, REG_VALUE_TYPE propType, Type cType = null) => propType switch
			{
				REG_VALUE_TYPE.REG_DWORD when cType is not null => ((IntPtr)mem).Convert(mem.Size, cType),
				REG_VALUE_TYPE.REG_BINARY when cType is not null && cType != typeof(byte[]) => ((IntPtr)mem).Convert(mem.Size, cType),
				_ => propType.GetValue(mem, mem.Size),
			};

			/// <inheritdoc/>
			protected override void SetValue(SPCRP key, object value)
			{
				if (value is null)
					throw new ArgumentNullException(nameof(value));
				value = CommonPropConv(value);
				if (!CorrespondingTypeAttribute.CanSet(key, value.GetType()))
					throw new ArgumentException("Value type not valid for key.");
				SafeAllocatedMemoryHandle mem = key switch
				{
					SPCRP.SPCRP_UPPERFILTERS => value is IEnumerable<string> uf ? SafeCoTaskMemHandle.CreateFromStringList(uf) : null,
					SPCRP.SPCRP_LOWERFILTERS => value is IEnumerable<string> lf ? SafeCoTaskMemHandle.CreateFromStringList(lf) : null,
					SPCRP.SPCRP_SECURITY => value is byte[] ba ? new SafeCoTaskMemHandle(ba) : null,
					SPCRP.SPCRP_SECURITY_SDS => value is string s ? new SafeCoTaskMemString(s, System.Runtime.InteropServices.CharSet.Auto) : null,
					SPCRP.SPCRP_DEVTYPE => value is FILE_DEVICE fd ? SafeCoTaskMemHandle.CreateFromStructure(fd) : null,
					SPCRP.SPCRP_EXCLUSIVE => value is BOOL b ? SafeCoTaskMemHandle.CreateFromStructure(b) : null,
					SPCRP.SPCRP_CHARACTERISTICS => value is uint u ? SafeCoTaskMemHandle.CreateFromStructure(u) : null,
					_ => null,
				};
				try
				{
					if (mem is null)
						throw new ArgumentException("Unable to convert object to property type.", nameof(value));
					Win32Error.ThrowLastErrorIfFalse(SetupDiSetClassRegistryProperty(Guid, key, mem.DangerousGetHandle(), mem.Size, MachineName));
				}
				finally
				{
					mem?.Dispose();
				}
			}

			private Win32Error GetValue(SPCRP propKey, out object value)
			{
				value = null;
				if (!SetupDiGetClassRegistryProperty(Guid, propKey, out _, default, 0, out var bufSz, MachineName))
				{
					_ = Win32Error.GetLastError();
					if (bufSz == 0)
						return Win32Error.ERROR_NOT_FOUND;
					using var mem = new SafeCoTaskMemHandle(bufSz);
					if (!SetupDiGetClassRegistryProperty(Guid, propKey, out var propType, mem, mem.Size, out bufSz, MachineName))
						return Win32Error.GetLastError();
					value = GetRegValue(propKey, mem, propType);
				}
				return Win32Error.ERROR_SUCCESS;
			}
		}

		private sealed class FinalizeImgLists
		{
			~FinalizeImgLists()
			{
				foreach (var val in imgListData.Values)
					SetupDiDestroyClassImageList(val);
			}
		}
	}

	/// <summary>A class that provides the collection of device setup classes available on a machine.</summary>
	public class DeviceClassCollection : IReadOnlyCollection<DeviceClass>, IDisposable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DeviceClassCollection"/> class with the flags and machine name to be used by <see
		/// cref="SetupDiBuildClassInfoListEx"/> to retrieve the classes.
		/// </summary>
		/// <param name="flags">
		/// <para>
		/// Flags used to control exclusion of classes from the list. If no flags are specified, all setup classes are included in the list.
		/// Can be a combination of the following values:
		/// </para>
		/// <para>DIBCI_NOINSTALLCLASS</para>
		/// <para>Exclude a class if it has the <c>NoInstallClass</c> value entry in its registry key.</para>
		/// <para>DIBCI_NODISPLAYCLASS</para>
		/// <para>Exclude a class if it has the <c>NoDisplayClass</c> value entry in its registry key.</para>
		/// </param>
		/// <param name="machineName">
		/// A string that contains the name of a remote computer from which to retrieve installed setup classes. This parameter is optional
		/// and can be <see langword="null"/>. If MachineName is <see langword="null"/>, this class provides a list of classes installed on
		/// the local computer.
		/// </param>
		public DeviceClassCollection(DIBCI flags = 0, string machineName = null)
		{
			Flags = flags;
			MachineName = machineName;
		}

		/// <summary>Gets the number of elements in the collection.</summary>
		/// <value>The number of elements in the collection.</value>
		public int Count
		{
			get
			{
				SetupDiBuildClassInfoListEx(Flags, null, 0, out var len, MachineName);
				return (int)len;
			}
		}

		/// <summary>
		/// Gets the flags used to control exclusion of classes from the list. If no flags are specified, all setup classes are included in
		/// the list.
		/// </summary>
		/// <value>
		/// Flags used to control exclusion of classes from the list. If no flags are specified, all setup classes are included in the list.
		/// </value>
		public DIBCI Flags { get; }

		/// <summary>Gets the name of the machine on which devices are managed. <see langword="null"/> indicates the local machine.</summary>
		/// <value>The machine name for this manager.</value>
		public string MachineName { get; }

		// TODO
		//bool ICollection<DeviceClass>.IsReadOnly => false;
		//public void Add(DeviceClass item) => throw new NotImplementedException();
		//public void Clear() => throw new NotImplementedException();
		//public bool Contains(DeviceClass item) => throw new NotImplementedException();
		//public void CopyTo(DeviceClass[] array, int arrayIndex) => throw new NotImplementedException();
		//public bool Remove(DeviceClass item) => throw new NotImplementedException();

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
		}

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<DeviceClass> GetEnumerator()
		{
			SetupDiBuildClassInfoListEx(Flags, null, 0, out var len, MachineName);
			if (len == 0) Win32Error.ThrowLastError();

			var guids = new Guid[(int)len];
			Win32Error.ThrowLastErrorIfFalse(SetupDiBuildClassInfoListEx(Flags, guids, len, out _, MachineName));
			for (int i = 0; i < len; i++)
				yield return new DeviceClass(guids[i], MachineName);
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	/// <summary>A class that provides the collection of devices available on a machine.</summary>
	/// <seealso cref="System.Collections.Generic.IEnumerable{T}"/>
	/// <seealso cref="System.IDisposable"/>
	public class DeviceCollection : IEnumerable<Device>, IDisposable
	{
		private SafeHDEVINFO devInfoSet;

		/// <summary>Initializes a new instance of the <see cref="DeviceCollection"/> class.</summary>
		/// <param name="classGuid">
		/// The GUID for a device setup class or a device interface class. This value is optional and can be <see langword="null"/>. If a
		/// GUID value is not used to select devices, set <paramref name="classGuid"/> to <see langword="null"/>.
		/// </param>
		/// <param name="enumerator">
		/// <para>A string that specifies:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// An identifier (ID) of a Plug and Play (PnP) enumerator. This ID can either be the enumerator's globally unique identifier (GUID)
		/// or symbolic name. For example, "PCI" can be used to specify the PCI PnP enumerator. Other examples of symbolic names for PnP
		/// enumerators include "USB", "PCMCIA", and "SCSI".
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// A PnP device instance IDs. When specifying a PnP device instance ID, DIGCF_DEVICEINTERFACE must be set in the <see
		/// cref="Filter"/> property.
		/// </term>
		/// </item>
		/// </list>
		/// <para>This value is optional and can be <see langword="null"/>.</para>
		/// </param>
		/// <param name="machineName">
		/// A string that contains the name of a remote computer on which the devices reside. A value of <see langword="null"/> for
		/// <paramref name="machineName"/> specifies that the device is installed on the local computer.
		/// </param>
		/// <param name="filter">
		/// Specifies control options that filter the device information elements that are added to the device information set. This
		/// property can be a bitwise OR of one or more of the <see cref="DIGCF"/> flags.
		/// </param>
		public DeviceCollection(Guid? classGuid = null, string enumerator = null, string machineName = null, DIGCF filter = DIGCF.DIGCF_PRESENT)
		{
			ClassGuid = classGuid;
			PnPEnumeratorOrDevInstId = enumerator;
			MachineName = machineName;
			Filter = PnPEnumeratorOrDevInstId is null ? filter : filter.SetFlags(DIGCF.DIGCF_DEVICEINTERFACE, PnPEnumeratorOrDevInstId.Contains("\\"));
			Reset();
		}

		/// <summary>Gets the GUID for the device's setup class or interface class. This value is optional and may be <see langword="null"/>.</summary>
		/// <value>The GUID for the device's setup class or interface class. This value is optional and may be <see langword="null"/>.</value>
		public Guid? ClassGuid { get; }

		/// <summary>
		/// Gets a value that specifies control options that filter the device information elements that are added to the device information
		/// set. This property can be a bitwise OR of one or more of the <see cref="DIGCF"/> flags.
		/// </summary>
		/// <value>The filter options.</value>
		public DIGCF Filter { get; }

		/// <summary>
		/// Gets the name of a remote computer on which the devices reside. A value of <see langword="null"/> specifies that the device is
		/// installed on the local computer.
		/// </summary>
		/// <value>
		/// The name of a remote computer on which the devices reside. A value of <see langword="null"/> specifies that the device is
		/// installed on the local computer.
		/// </value>
		public string MachineName { get; }

		/// <summary>
		/// <para>Gets a string that specifies:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// An identifier (ID) of a Plug and Play (PnP) enumerator. This ID can either be the enumerator's globally unique identifier (GUID)
		/// or symbolic name. For example, "PCI" can be used to specify the PCI PnP enumerator. Other examples of symbolic names for PnP
		/// enumerators include "USB", "PCMCIA", and "SCSI".
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// A PnP device instance IDs. When specifying a PnP device instance ID, DIGCF_DEVICEINTERFACE must be set in the <see
		/// cref="Filter"/> property.
		/// </term>
		/// </item>
		/// </list>
		/// <para>This value is optional and can be <see langword="null"/>.</para>
		/// </summary>
		/// <value>The PnP enumerator or device instance ID.</value>
		public string PnPEnumeratorOrDevInstId { get; }

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		public void Dispose() { }

		/// <inheritdoc/>
		public IEnumerator<Device> GetEnumerator()
		{
			var data = StructHelper.InitWithSize<SP_DEVINFO_DATA>();
			for (uint i = 0; SetupDiEnumDeviceInfo(devInfoSet, i, ref data); i++)
				yield return new Device(devInfoSet, data);
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_NO_MORE_ITEMS);
		}

		/// <inheritdoc/>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		private void Reset()
		{
			devInfoSet?.Dispose();
			devInfoSet = SafeHDEVINFO.Create(ClassGuid, Filter, PnPEnumeratorOrDevInstId, MachineName);
			Win32Error.ThrowLastErrorIfInvalid(devInfoSet);
		}
	}

	/// <summary>Class to manage local and remote devices.</summary>
	public class DeviceManager
	{
		private static readonly Lazy<DeviceManager> local = new(() => new DeviceManager(null));

		/// <summary>Initializes a new instance of the <see cref="DeviceManager"/> class on a specified machine.</summary>
		/// <param name="machineName">Name of the machine on which to manage devices. Specify <see langword="null"/> for the local machine.</param>
		public DeviceManager(string machineName = null) => MachineName = machineName;

		/// <summary>Provides access to the local machine's devices.</summary>
		public static DeviceManager LocalInstance => local.Value;

		/// <summary>Gets the name of the machine on which devices are managed. <see langword="null"/> indicates the local machine.</summary>
		/// <value>The machine name for this manager.</value>
		public string MachineName { get; }

		/// <summary>Gets the devices associated with this machine.</summary>
		/// <returns>A sequence of <see cref="Device"/> instances on this machine.</returns>
		public IEnumerable<Device> GetDevices(DIGCF filter = DIGCF.DIGCF_PRESENT) => new DeviceCollection(null, null, MachineName, filter);

		/// <summary>Gets the setup classes available on the machine.</summary>
		/// <value>A class that provides the collection of setup classes.</value>
		public IEnumerable<DeviceClass> GetSetupClasses() => new DeviceClassCollection(0, MachineName);

		internal static SP_DEVINFO_LIST_DETAIL_DATA GetDevInfoDetail(HDEVINFO hdi)
		{
			var disData = StructHelper.InitWithSize<SP_DEVINFO_LIST_DETAIL_DATA>();
			Win32Error.ThrowLastErrorIfFalse(SetupDiGetDeviceInfoListDetail(hdi, ref disData));
			return disData;
		}
	}

	// TODO
	internal class DeviceInterface
	{
	}
}