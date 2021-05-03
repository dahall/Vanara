using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.SetupAPI;

namespace Vanara.PInvoke
{
	/// <summary>Items from the CfgMgr32.dll</summary>
	public static partial class CfgMgr32
	{
		/// <summary>
		/// Provides a device with backing in the registry and allows the caller to then make calls to Software Device API functions with
		/// the hSwDevice handle.
		/// </summary>
		/// <param name="hSwDevice">The handle for the software device.</param>
		/// <param name="CreateResult">An HRESULT that indicates if the enumeration of the software device was successful.</param>
		/// <param name="pContext">The context that was optionally supplied by the client app to SwDeviceCreate.</param>
		/// <param name="pszDeviceInstanceId">The device instance ID that PnP assigned to the device.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The operating system calls the <c>SW_DEVICE_CREATE_CALLBACK</c> callback function after PnP enumerates the device. After the
		/// callback function is called, the device has backing in the registry and calls to Software Device API functions can be made by
		/// using the hSwDevice handle. You can also use other APIs that work with devices for the device that is created.
		/// </para>
		/// <para>
		/// PnP enumeration of a device is the first step that a device undergoes. After PnP enumeration of the device, the device only has
		/// registry backing, and you can set properties against the device. Just because PnP enumerated the device, the device hasn't
		/// started yet, and no driver for the device has registered or enabled interfaces yet. In many cases, we recommend that apps wait
		/// for device-interface arrival if they want to use the device.
		/// </para>
		/// <para>
		/// <c>Note</c> The callback function supplies the device instance ID for the created device. We recommend that callers of the
		/// Software Device API not try to guess at or construct the device instance ID themselves; always use the value provided by the
		/// callback function.
		/// </para>
		/// <para>
		/// The callback function will execute on an arbitrary thread-pool thread. Client apps can perform as much work as needed in the
		/// callback function.
		/// </para>
		/// <para>
		/// In Windows 8, you can't call SwDeviceClose inside the callback function. Doing so will cause a deadlock. Be careful of releasing
		/// a ref counted object that will call <c>SwDeviceClose</c> when its destructor runs. In Windows 8.1, this restriction is lifted,
		/// and you can call <c>SwDeviceClose</c> inside the callback function.
		/// </para>
		/// <para>Always check the HRESULT that is passed to CreateResult to make sure PnP was able to enumerate the device.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/swdevice/nc-swdevice-sw_device_create_callback SW_DEVICE_CREATE_CALLBACK
		// SwDeviceCreateCallback; void SwDeviceCreateCallback( HSWDEVICE hSwDevice, HRESULT CreateResult, PVOID pContext, PCWSTR
		// pszDeviceInstanceId ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("swdevice.h", MSDNShortId = "NC:swdevice.SW_DEVICE_CREATE_CALLBACK")]
		public delegate void SW_DEVICE_CREATE_CALLBACK([In] HSWDEVICE hSwDevice, HRESULT CreateResult, [In, Optional] IntPtr pContext, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pszDeviceInstanceId);

		/// <summary>Specifies capabilities of the software device.</summary>
		[PInvokeData("swdevicedef.h", MSDNShortId = "NS:swdevicedef._SW_DEVICE_CREATE_INFO")]
		[Flags]
		public enum SW_DEVICE_CAPABILITIES
		{
			/// <summary>No capabilities have been specified.</summary>
			SWDeviceCapabilitiesNone = 0x00000000,

			/// <summary>
			/// This bit specifies that the device is removable from its parent. Setting this flag is equivalent to a bus driver setting the
			/// Removable member of the DEVICE_CAPABILTIES structure for a PDO.
			/// </summary>
			SWDeviceCapabilitiesRemovable = 0x00000001,

			/// <summary>
			/// This bit suppresses UI that would normally be shown during installation. Setting this flag is equivalent to a bus driver
			/// setting the SilentInstall member of the DEVICE_CAPABILTIES structure for a PDO.
			/// </summary>
			SWDeviceCapabilitiesSilentInstall = 0x00000002,

			/// <summary>
			/// This bit prevents the device from being displayed in some UI. Setting this flag is equivalent to a bus driver setting the
			/// NoDisplayInUI member of the DEVICE_CAPABILTIES structure for a PDO.
			/// </summary>
			SWDeviceCapabilitiesNoDisplayInUI = 0x00000004,

			/// <summary>
			/// Specify this bit when the client wants a driver to be loaded on the device and when this driver is required for correct
			/// function of the client’s feature. When this bit is specified, at least one of pszzHardwareIds or pszzCompatibleIds must be
			/// filled in. If this bit is specified and if a driver can't be found, the device shows a yellow bang in Device Manager to
			/// indicate that the device has a problem, and Troubleshooters flag this as a device with a problem. Setting this bit is
			/// equivalent to a bus driver not setting the RawDeviceOK member of the DEVICE_CAPABILTIES structure for a PDO. When this bit
			/// is specified, the driver owns creating interfaces for the device, and you can't call SwDeviceInterfaceRegister for the device.
			/// </summary>
			SWDeviceCapabilitiesDriverRequired = 0x00000008
		}

		/// <summary>Indicates the current lifetime value for the software device.</summary>
		[PInvokeData("swdevicedef.h")]
		public enum SW_DEVICE_LIFETIME
		{
			/// <summary>
			/// Indicates that the lifetime of the software device is determined by the lifetime of the handle that is associated with the
			/// software device. As long as the handle is open, the software device is enumerated by PnP.
			/// </summary>
			SWDeviceLifetimeHandle,

			/// <summary>Indicates that the lifetime of the software device is tied to the lifetime of its parent.</summary>
			SWDeviceLifetimeParentPresent,
		}

		/// <summary>Closes the software device handle. When the handle is closed, PnP will initiate the process of removing the device.</summary>
		/// <param name="hSwDevice">The <c>HSWDEVICE</c> handle to close.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// After <c>SwDeviceClose</c> returns, the operating system is guaranteed to not call the SW_DEVICE_CREATE_CALLBACK callback
		/// function, and any calls to Software Device API functions that were in progress are guaranteed to have completed.
		/// </para>
		/// <para>You can call <c>SwDeviceClose</c> at any time even if the callback function hasn't been called yet.</para>
		/// <para>
		/// In Windows 8, you can't call <c>SwDeviceClose</c> inside the SW_DEVICE_CREATE_CALLBACK callback function. Doing so will cause a
		/// deadlock. Be careful of releasing a ref counted object that will call <c>SwDeviceClose</c> when its destructor runs. In Windows
		/// 8.1, this restriction is lifted, and you can call <c>SwDeviceClose</c> inside the callback function.
		/// </para>
		/// <para>
		/// By calling <c>SwDeviceClose</c>, you initiate the process of removing a device from PnP. The call to <c>SwDeviceClose</c>
		/// returns before this removal is complete. But you can safely call SwDeviceCreate immediately after <c>SwDeviceClose</c>. The new
		/// create will be queued until the previous removal processing completes, and then the device will be re-created.
		/// </para>
		/// <para>
		/// PnP removal makes the device "Not present." PnP removal of a device is the same us unplugging a USB device. All the persisted
		/// property state for the device remains in memory.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/swdevice/nf-swdevice-swdeviceclose void SwDeviceClose( HSWDEVICE hSwDevice );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("swdevice.h", MSDNShortId = "NF:swdevice.SwDeviceClose")]
		public static extern void SwDeviceClose(HSWDEVICE hSwDevice);

		/// <summary>Initiates the enumeration of a software device.</summary>
		/// <param name="pszEnumeratorName">
		/// A string that names the enumerator of the software device. Choose a name that represents the component that enumerates the devices.
		/// </param>
		/// <param name="pszParentDeviceInstance">
		/// <para>A string that specifies the device instance ID of the device that is the parent of the software device.</para>
		/// <para>
		/// This can be HTREE\ROOT\0, but we recommend to keep children of the root device to a minimum. We also recommend that the
		/// preferred parent of a software device be a real device that the software device is extending the functionality for. In
		/// situations where a software device doesn't have such a natural parent, create a device as a child of the root that can collect
		/// all the software devices that a component will enumerate; then, enumerate the actual software devices as children of this device
		/// grouping node. This keeps the children of the root device to a manageable number.
		/// </para>
		/// </param>
		/// <param name="pCreateInfo">A pointer to a SW_DEVICE_CREATE_INFO structure that describes info that PnP uses to create the device.</param>
		/// <param name="cPropertyCount">The number of DEVPROPERTY structures in the pProperties array.</param>
		/// <param name="pProperties">
		/// An optional array of DEVPROPERTY structures. These properties are set on the device after it is created but before a
		/// notification that the device has been created are sent. For more info, see Remarks. This pointer can be <c>NULL</c>.
		/// </param>
		/// <param name="pCallback">
		/// The SW_DEVICE_CREATE_CALLBACK callback function that the operating system calls after PnP enumerates the device.
		/// </param>
		/// <param name="pContext">
		/// An optional client context that the operating system passes to the callback function. This pointer can be <c>NULL</c>.
		/// </param>
		/// <param name="phSwDevice">
		/// A pointer to a variable that receives the <c>HSWDEVICE</c> handle that represents the device. Call SwDeviceClose to close this
		/// handle after the client app wants PnP to remove the device.
		/// </param>
		/// <returns>
		/// S_OK is returned if device enumeration was successfully initiated. This does not mean that the device has been successfully
		/// enumerated. Check the CreateResult parameter of the SW_DEVICE_CREATE_CALLBACK callback function to determine if the device was
		/// successfully enumerated.
		/// </returns>
		/// <remarks>
		/// <para><c>SwDeviceCreate</c> returns a handle that represents the device. After this handle is closed, PnP will remove the device.</para>
		/// <para>The calling process must have Administrator access in order to initiate the enumeration of a software device.</para>
		/// <para>
		/// PnP forms the device instance ID of a software device as "SWD&amp;lt;pszEnumeratorName&gt;&amp;lt;pszInstanceId&gt;," but this
		/// string might change or PnP might decorate the name. Always get the device instance ID from the callback function.
		/// </para>
		/// <para>
		/// There is a subtle difference between properties that are set as part of a <c>SwDeviceCreate</c> call and properties that are
		/// later set by calling SwDevicePropertySet. Properties that are set as part of <c>SwDeviceCreate</c> are stored in memory; if the
		/// device is uninstalled or a null driver wipes out the property stores, these properties are written out again by the Software
		/// Device API feature when PnP re-enumerates the devices. This is all transparent to the client. Properties that are set using
		/// <c>SwDevicePropertySet</c> after the enumeration don't persist in memory. But, if you set a property by using
		/// <c>SwDeviceCreate</c>, you can update the value with <c>SwDevicePropertySet</c>, and this update is applied to the in-memory
		/// value as well as the persisted store.
		/// </para>
		/// <para>
		/// We recommend that all properties be specified as part of the call to <c>SwDeviceCreate</c> when possible and that these
		/// properties be specified for every call to <c>SwDeviceCreate</c>.
		/// </para>
		/// <para>
		/// <c>Note</c> The operating system might possibly call SW_DEVICE_CREATE_CALLBACK before the call to <c>SwDeviceCreate</c> returns.
		/// For this reason, the software device handle for the device is supplied as a parameter to the callback function.
		/// </para>
		/// <para>
		/// You can create a software device as the child of a parent that is not present at the time. PnP will enumerate the software
		/// device after the parent becomes present.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/swdevice/nf-swdevice-swdevicecreate HRESULT SwDeviceCreate( PCWSTR
		// pszEnumeratorName, PCWSTR pszParentDeviceInstance, const SW_DEVICE_CREATE_INFO *pCreateInfo, ULONG cPropertyCount, const
		// DEVPROPERTY *pProperties, SW_DEVICE_CREATE_CALLBACK pCallback, PVOID pContext, PHSWDEVICE phSwDevice );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("swdevice.h", MSDNShortId = "NF:swdevice.SwDeviceCreate")]
		public static extern HRESULT SwDeviceCreate([MarshalAs(UnmanagedType.LPWStr)] string pszEnumeratorName, [MarshalAs(UnmanagedType.LPWStr)] string pszParentDeviceInstance,
			in SW_DEVICE_CREATE_INFO pCreateInfo, uint cPropertyCount, [In, Optional, MarshalAs(UnmanagedType.LPArray)] DEVPROPERTY[] pProperties, SW_DEVICE_CREATE_CALLBACK pCallback,
			[In, Optional] IntPtr pContext, out SafeHSWDEVICE phSwDevice);

		/// <summary>Gets the lifetime of a software device.</summary>
		/// <param name="hSwDevice">The <c>HSWDEVICE</c> handle to the software device to retrieve.</param>
		/// <param name="pLifetime">
		/// <para>
		/// A pointer to a variable that receives a <c>SW_DEVICE_LIFETIME</c>-typed value that indicates the current lifetime value for the
		/// software device. Here are possible values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SWDeviceLifetimeHandle</term>
		/// <term>
		/// Indicates that the lifetime of the software device is determined by the lifetime of the handle that is associated with the
		/// software device. As long as the handle is open, the software device is enumerated by PnP.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SWDeviceLifetimeParentPresent</term>
		/// <term>Indicates that the lifetime of the software device is tied to the lifetime of its parent.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>S_OK is returned if SwDeviceSetLifetime successfully retrieved the lifetime.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/swdevice/nf-swdevice-swdevicegetlifetime HRESULT SwDeviceGetLifetime(
		// HSWDEVICE hSwDevice, PSW_DEVICE_LIFETIME pLifetime );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("swdevice.h", MSDNShortId = "NF:swdevice.SwDeviceGetLifetime")]
		public static extern HRESULT SwDeviceGetLifetime(HSWDEVICE hSwDevice, out SW_DEVICE_LIFETIME pLifetime);

		/// <summary>Sets properties on a software device interface.</summary>
		/// <param name="hSwDevice">The <c>HSWDEVICE</c> handle to the software device of the interface to set properties for.</param>
		/// <param name="pszDeviceInterfaceId">A string that identifies the interface to set properties on.</param>
		/// <param name="cPropertyCount">The number of DEVPROPERTY structures in the pProperties array.</param>
		/// <param name="pProperties">An array of DEVPROPERTY structures containing the properties to set on the interface.</param>
		/// <returns>
		/// S_OK is returned if <c>SwDeviceInterfacePropertySet</c> successfully set the properties on the interface; otherwise, an
		/// appropriate error value.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Typically, only the operating system and Administrators of the computer can set properties on an interface, but the creator of a
		/// device can call <c>SwDeviceInterfacePropertySet</c> to set properties on an interface for that device even if the creator isn't
		/// the operating system or an Administrator.
		/// </para>
		/// <para>
		/// You can call <c>SwDeviceInterfacePropertySet</c> only after the operating system has called your client app's
		/// SW_DEVICE_CREATE_CALLBACK callback function to notify the client app that device enumeration completed.
		/// </para>
		/// <para>
		/// There is a subtle difference between properties that are set as part of a SwDeviceInterfaceRegister call and properties that are
		/// later set by calling <c>SwDeviceInterfacePropertySet</c>. Properties that are set as part of <c>SwDeviceInterfaceRegister</c>
		/// are stored in memory; if the device is uninstalled or a null driver wipes out the property stores, these properties are written
		/// out again by the Software Device API feature when PnP re-enumerates the devices. This is all transparent to the client.
		/// Properties that are set using <c>SwDeviceInterfacePropertySet</c> after the enumeration don't persist in memory. But, if you set
		/// a property by using <c>SwDeviceInterfaceRegister</c>, you can update the value with <c>SwDeviceInterfacePropertySet</c>, and
		/// this update is applied to the in-memory value as well as the persisted store.
		/// </para>
		/// <para>You can use <c>SwDeviceInterfacePropertySet</c> only to set properties in the operating system store for the interface.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/swdevice/nf-swdevice-swdeviceinterfacepropertyset HRESULT
		// SwDeviceInterfacePropertySet( HSWDEVICE hSwDevice, PCWSTR pszDeviceInterfaceId, ULONG cPropertyCount, const DEVPROPERTY
		// *pProperties );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("swdevice.h", MSDNShortId = "NF:swdevice.SwDeviceInterfacePropertySet")]
		public static extern HRESULT SwDeviceInterfacePropertySet(HSWDEVICE hSwDevice, [MarshalAs(UnmanagedType.LPWStr)] string pszDeviceInterfaceId,
			uint cPropertyCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEVPROPERTY[] pProperties);

		/// <summary>Registers a device interface for a software device and optionally sets properties on that interface.</summary>
		/// <param name="hSwDevice">The <c>HSWDEVICE</c> handle to the software device to register a device interface for.</param>
		/// <param name="pInterfaceClassGuid">A pointer to the interface class GUID that names the contract that this interface implements.</param>
		/// <param name="pszReferenceString">
		/// An optional reference string that differentiates multiple interfaces of the same class for this device. This pointer can be <c>NULL</c>.
		/// </param>
		/// <param name="cPropertyCount">The number of DEVPROPERTY structures in the pProperties array.</param>
		/// <param name="pProperties">
		/// <para>An optional array of DEVPROPERTY structures for the properties to set on the interface. This pointer can be <c>NULL</c>.</para>
		/// <para>
		/// Set these properties on the interface after it is created but before a notification that the interface has been created are
		/// sent. For more info, see Remarks. This pointer can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="fEnabled">
		/// A Boolean value that indicates whether to either enable or disable the interface. <c>TRUE</c> to enable; <c>FALSE</c> to disable.
		/// </param>
		/// <param name="ppszDeviceInterfaceId">
		/// A pointer to a variable that receives a pointer to the device interface ID for the interface. The caller must free this value
		/// with SwMemFree. This value can be <c>NULL</c> if the client app doesn't need to retrieve the name.
		/// </param>
		/// <returns>
		/// S_OK is returned if <c>SwDeviceInterfaceRegister</c> successfully registered the interface; otherwise, an appropriate error value.
		/// </returns>
		/// <remarks>
		/// <para>
		/// You can call <c>SwDeviceInterfaceRegister</c> only after the operating system has called your client app's
		/// SW_DEVICE_CREATE_CALLBACK callback function to notify the client app that device enumeration completed.
		/// </para>
		/// <para>
		/// You can't call <c>SwDeviceInterfaceRegister</c> for software devices that specify the SWDeviceCapabilitiesDriverRequired capability.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/swdevice/nf-swdevice-swdeviceinterfaceregister HRESULT
		// SwDeviceInterfaceRegister( HSWDEVICE hSwDevice, const GUID *pInterfaceClassGuid, PCWSTR pszReferenceString, ULONG cPropertyCount,
		// const DEVPROPERTY *pProperties, BOOL fEnabled, PWSTR *ppszDeviceInterfaceId );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("swdevice.h", MSDNShortId = "NF:swdevice.SwDeviceInterfaceRegister")]
		public static extern HRESULT SwDeviceInterfaceRegister(HSWDEVICE hSwDevice, in Guid pInterfaceClassGuid, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pszReferenceString,
			uint cPropertyCount, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEVPROPERTY[] pProperties, [MarshalAs(UnmanagedType.Bool)] bool fEnabled,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SwMemMarshaler))] out string ppszDeviceInterfaceId);

		/// <summary>Enables or disables a device interface for a software device.</summary>
		/// <param name="hSwDevice">The <c>HSWDEVICE</c> handle to the software device to register a device interface for.</param>
		/// <param name="pszDeviceInterfaceId">A string that identifies the interface to enable or disable.</param>
		/// <param name="fEnabled">
		/// A Boolean value that indicates whether to either enable or disable the interface. <c>TRUE</c> to enable; <c>FALSE</c> to disable.
		/// </param>
		/// <returns>
		/// S_OK is returned if <c>SwDeviceInterfaceSetState</c> successfully enabled or disabled the interface; otherwise, an appropriate
		/// error value.
		/// </returns>
		/// <remarks>
		/// <para>
		/// You can call <c>SwDeviceInterfaceSetState</c> only after the operating system has called your client app's
		/// SW_DEVICE_CREATE_CALLBACK callback function to notify the client app that device enumeration completed.
		/// </para>
		/// <para>
		/// You can only use <c>SwDeviceInterfaceSetState</c> to manage interfaces that were previously registered with
		/// SwDeviceInterfaceRegister against the software device that hSwDevice represents.
		/// </para>
		/// <para>
		/// Client apps use <c>SwDeviceInterfaceSetState</c> to manage the state that they want the interface to have. The software device
		/// changes the actual interface state as needed. For example, a client app disables and re-enables the interface if the device is
		/// re-enumerated for any reason. The state always tries to reflect the client app’s required state.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/swdevice/nf-swdevice-swdeviceinterfacesetstate HRESULT
		// SwDeviceInterfaceSetState( HSWDEVICE hSwDevice, PCWSTR pszDeviceInterfaceId, BOOL fEnabled );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("swdevice.h", MSDNShortId = "NF:swdevice.SwDeviceInterfaceSetState")]
		public static extern HRESULT SwDeviceInterfaceSetState(HSWDEVICE hSwDevice, [MarshalAs(UnmanagedType.LPWStr)] string pszDeviceInterfaceId, [MarshalAs(UnmanagedType.Bool)] bool fEnabled);

		/// <summary>Sets properties on a software device.</summary>
		/// <param name="hSwDevice">The <c>HSWDEVICE</c> handle to the software device to set properties for.</param>
		/// <param name="cPropertyCount">The number of DEVPROPERTY structures in the pProperties array.</param>
		/// <param name="pProperties">An array of DEVPROPERTY structures containing the properties to set.</param>
		/// <returns>
		/// S_OK is returned if <c>SwDevicePropertySet</c> successfully set the properties; otherwise, an appropriate error value.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Typically, only the operating system and Administrators of the computer can set properties on a device, but the creator of a
		/// device can call <c>SwDevicePropertySet</c> to set properties on that device even if it isn't the operating system or an Administrator.
		/// </para>
		/// <para>
		/// You can call <c>SwDevicePropertySet</c> only after the operating system has called your client app's SW_DEVICE_CREATE_CALLBACK
		/// callback function to notify the client app that device enumeration completed.
		/// </para>
		/// <para>
		/// There is a subtle difference between properties that are set as part of a SwDeviceCreate call and properties that are later set
		/// by calling <c>SwDevicePropertySet</c>. Properties that are set as part of <c>SwDeviceCreate</c> are stored in memory; if the
		/// device is uninstalled or a null driver wipes out the property stores, these properties are written out again by the Software
		/// Device API feature when PnP re-enumerates the devices. This is all transparent to the client. Properties that are set using
		/// <c>SwDevicePropertySet</c> after the enumeration don't persist in memory. But, if you set a property by using
		/// <c>SwDeviceCreate</c>, you can update the value with <c>SwDevicePropertySet</c>, and this update is applied to the in-memory
		/// value as well as the persisted store.
		/// </para>
		/// <para>You can use <c>SwDevicePropertySet</c> only to set properties in the operating system store for the device.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/swdevice/nf-swdevice-swdevicepropertyset HRESULT SwDevicePropertySet(
		// HSWDEVICE hSwDevice, ULONG cPropertyCount, const DEVPROPERTY *pProperties );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("swdevice.h", MSDNShortId = "NF:swdevice.SwDevicePropertySet")]
		public static extern HRESULT SwDevicePropertySet(HSWDEVICE hSwDevice, uint cPropertyCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEVPROPERTY[] pProperties);

		/// <summary>Manages the lifetime of a software device.</summary>
		/// <param name="hSwDevice">The <c>HSWDEVICE</c> handle to the software device to manage.</param>
		/// <param name="Lifetime">
		/// <para>
		/// A <c>SW_DEVICE_LIFETIME</c>-typed value that indicates the new lifetime value for the software device. Here are possible values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SWDeviceLifetimeHandle</term>
		/// <term>
		/// Indicates that the lifetime of the software device is determined by the lifetime of the handle that is associated with the
		/// software device. As long as the handle is open, the software device is enumerated by PnP.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SWDeviceLifetimeParentPresent</term>
		/// <term>Indicates that the lifetime of the software device is tied to the lifetime of its parent.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>S_OK is returned if <c>SwDeviceSetLifetime</c> successfully updated the lifetime.</returns>
		/// <remarks>
		/// <para>
		/// After a software device is initially created by calling SwDeviceCreate, its default lifetime is set to
		/// <c>SwDeviceLifetimeHandle</c>. When a software device has a lifetime of <c>SwDeviceLifetimeHandle</c>, PnP stops enumerating the
		/// device after the device's handle is closed.
		/// </para>
		/// <para>
		/// You can use <c>SwDeviceSetLifetime</c> to set the lifetime of the software device to <c>SwDeviceLifetimeParentPresent</c>. The
		/// lifetime of the software device is then tied to the lifetime of the closest non-software device parent. The creator of the
		/// software device can then close the handle to the software device and the device will still be enumerated. This can be useful for
		/// services that manage software devices but want to idle stop.
		/// </para>
		/// <para>
		/// A client app can only call <c>SwDeviceSetLifetime</c> after it has received a call to its SW_DEVICE_CREATE_CALLBACK callback
		/// function that is associated with its call to SwDeviceCreate.
		/// </para>
		/// <para>
		/// When a client app calls SwDeviceCreate for a software device that was previously marked for
		/// <c>SwDeviceLifetimeParentPresent</c>, <c>SwDeviceCreate</c> succeeds if there are no open software device handles for the device
		/// (only one handle can be open for a device). A client app can then regain control over a persistent software device for the
		/// purposes of updating properties and interfaces or changing the lifetime.
		/// </para>
		/// <para>
		/// If the client app specifies info in SW_DEVICE_CREATE_INFO that is different form a previous enumeration, the device might stop
		/// being enumerated and immediately re-enumerated to apply the changes. The operating system reports only some properties when PnP
		/// enumerates the device.
		/// </para>
		/// <para>
		/// To uninstall a software device with a lifetime of <c>SwDeviceLifetimeParentPresent</c>, we recommend that you change the
		/// lifetime back to <c>SwDeviceLifetimeHandle</c> before the device is uninstalled.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/swdevice/nf-swdevice-swdevicesetlifetime HRESULT SwDeviceSetLifetime(
		// HSWDEVICE hSwDevice, SW_DEVICE_LIFETIME Lifetime );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("swdevice.h", MSDNShortId = "NF:swdevice.SwDeviceSetLifetime")]
		public static extern HRESULT SwDeviceSetLifetime(HSWDEVICE hSwDevice, SW_DEVICE_LIFETIME Lifetime);

		/// <summary>Frees memory that other Software Device API functions allocated.</summary>
		/// <param name="pMem">A pointer to the block of memory to free.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/swdevice/nf-swdevice-swmemfree void SwMemFree( PVOID pMem );
		[DllImport(Lib_Cfgmgr32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("swdevice.h", MSDNShortId = "NF:swdevice.SwMemFree")]
		public static extern void SwMemFree(IntPtr pMem);

		/// <summary>Provides a handle to a software device.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HSWDEVICE : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HSWDEVICE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HSWDEVICE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HSWDEVICE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HSWDEVICE NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HSWDEVICE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HSWDEVICE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HSWDEVICE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HSWDEVICE(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HSWDEVICE h1, HSWDEVICE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HSWDEVICE h1, HSWDEVICE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HSWDEVICE h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Describes info that PnP uses to create the software device.</summary>
		/// <remarks>
		/// You can only specify this info at creation time, and you can't later call the Software Device API to modify this info, by
		/// setting properties, for example.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/swdevicedef/ns-swdevicedef-sw_device_create_info typedef struct
		// _SW_DEVICE_CREATE_INFO { ULONG cbSize; PCWSTR pszInstanceId; PCZZWSTR pszzHardwareIds; PCZZWSTR pszzCompatibleIds; const GUID
		// *pContainerId; ULONG CapabilityFlags; PCWSTR pszDeviceDescription; PCWSTR pszDeviceLocation; const SECURITY_DESCRIPTOR
		// *pSecurityDescriptor; } SW_DEVICE_CREATE_INFO, *PSW_DEVICE_CREATE_INFO;
		[PInvokeData("swdevicedef.h", MSDNShortId = "NS:swdevicedef._SW_DEVICE_CREATE_INFO")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SW_DEVICE_CREATE_INFO
		{
			/// <summary>The size in bytes of this structure. Use it as a version field. Initialize it to sizeof(SW_DEVICE_CREATE_INFO).</summary>
			public uint cbSize;

			/// <summary>
			/// A string that represents the instance ID portion of the device instance ID. This value is used for IRP_MN_QUERY_ID
			/// <c>BusQueryInstanceID</c>. Because all software devices are considered "UniqueId" devices, this string must be a unique name
			/// for all devices on this software device enumerator. For more info, see Instance IDs.
			/// </summary>
			public string pszInstanceId;

			/// <summary>
			/// A list of strings for the hardware IDs for the software device. This value is used for IRP_MN_QUERY_ID
			/// <c>BusQueryHardwareIDs</c>. If a client expects a driver or device metadata to bind to the device, the client specifies
			/// hardware IDs.
			/// </summary>
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler))]
			public string[] pszzHardwareIds;

			/// <summary>
			/// A list of strings for the compatible IDs for the software device. This value is used for IRP_MN_QUERY_ID
			/// <c>BusQueryCompatibleIDs</c>. If a client expects a class driver to load, the client specifies compatible IDs that match the
			/// class driver. If a driver isn't needed, we recommend to specify a compatible ID to classify the type of software device. In
			/// addition to the compatible IDs specified in this member, SWD\Generic and possibly SWD\GenericRaw will always be added as the
			/// least specific compatible IDs.
			/// </summary>
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler))]
			public string[] pszzCompatibleIds;

			/// <summary>
			/// A value that is used to control the base container ID for the software device. This value will be used for IRP_MN_QUERY_ID
			/// <c>BusQueryContainerIDs</c>. For typical situations, we recommend to set this member to <c>NULL</c> and use the
			/// <c>SWDeviceCapabilitiesRemovable</c> flag to control whether the device inherits the parent's container ID or if PnP assigns
			/// a new random container ID. If the client needs to explicitly control the container ID, specify a <c>GUID</c> in the variable
			/// that this member points to.
			/// </summary>
			public GuidPtr pContainerId;

			/// <summary>
			/// <para>
			/// A combination of <c>SW_DEVICE_CAPABILITIES</c> values that are combined by using a bitwise OR operation. The resulting value
			/// specifies capabilities of the software device. The capability that you can specify when you create a software device are a
			/// subset of the capabilities that a bus driver can specify by using the <c>DEVICE_CAPABILTIES</c> structure. Only capabilities
			/// that make sense to allow changing for a software only device are supported. The rest receive appropriate default values.
			/// Here are possible values:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SWDeviceCapabilitiesNone 0x00000000</term>
			/// <term>No capabilities have been specified.</term>
			/// </item>
			/// <item>
			/// <term>SWDeviceCapabilitiesRemovable 0x00000001</term>
			/// <term>
			/// This bit specifies that the device is removable from its parent. Setting this flag is equivalent to a bus driver setting the
			/// Removable member of the DEVICE_CAPABILTIES structure for a PDO.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SWDeviceCapabilitiesSilentInstall 0x00000002</term>
			/// <term>
			/// This bit suppresses UI that would normally be shown during installation. Setting this flag is equivalent to a bus driver
			/// setting the SilentInstall member of the DEVICE_CAPABILTIES structure for a PDO.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SWDeviceCapabilitiesNoDisplayInUI 0x00000004</term>
			/// <term>
			/// This bit prevents the device from being displayed in some UI. Setting this flag is equivalent to a bus driver setting the
			/// NoDisplayInUI member of the DEVICE_CAPABILTIES structure for a PDO.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SWDeviceCapabilitiesDriverRequired 0x00000008</term>
			/// <term>
			/// Specify this bit when the client wants a driver to be loaded on the device and when this driver is required for correct
			/// function of the client’s feature. When this bit is specified, at least one of pszzHardwareIds or pszzCompatibleIds must be
			/// filled in. If this bit is specified and if a driver can't be found, the device shows a yellow bang in Device Manager to
			/// indicate that the device has a problem, and Troubleshooters flag this as a device with a problem. Setting this bit is
			/// equivalent to a bus driver not setting the RawDeviceOK member of the DEVICE_CAPABILTIES structure for a PDO. When this bit
			/// is specified, the driver owns creating interfaces for the device, and you can't call SwDeviceInterfaceRegister for the device.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public SW_DEVICE_CAPABILITIES CapabilityFlags;

			/// <summary>
			/// <para>
			/// A string that contains the text that is displayed for the device name in the UI. This value is used for
			/// IRP_MN_QUERY_DEVICE_TEXT <c>DeviceTextDescription</c>.
			/// </para>
			/// <para><c>Note</c>
			/// <para></para>
			/// When an INF is matched against the device, the name from the INF overrides this name unless steps are taken to preserve this name.
			/// <para></para>
			/// We recommend that this string be a reference to a localizable resource. For the syntax of referencing resources, see DEVPROP_TYPE_STRING_INDIRECT.
			/// </para>
			/// </summary>
			public string pszDeviceDescription;

			/// <summary>
			/// <para>
			/// A string that contains the text that is displayed for the device location in the UI. This value is used for
			/// IRP_MN_QUERY_DEVICE_TEXT <c>DeviceTextLocationInformation</c>.
			/// </para>
			/// <para><c>Note</c> Specifying a location is uncommon.</para>
			/// </summary>
			public string pszDeviceLocation;

			/// <summary>
			/// A pointer to a SECURITY_DESCRIPTOR structure that contains the security information associated with the software device. If
			/// this member is <c>NULL</c>, the I/O Manager assigns the default security descriptor to the device. If a custom security
			/// descriptor is needed, specify a self-relative security descriptor.
			/// </summary>
			public PSECURITY_DESCRIPTOR pSecurityDescriptor;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HSWDEVICE"/> that is disposed using <see cref="SwDeviceClose"/>.</summary>
		public class SafeHSWDEVICE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHSWDEVICE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHSWDEVICE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHSWDEVICE"/> class.</summary>
			private SafeHSWDEVICE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHSWDEVICE"/> to <see cref="HSWDEVICE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HSWDEVICE(SafeHSWDEVICE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { SwDeviceClose(handle); return true; }
		}

		internal class SwMemMarshaler : ICustomMarshaler
		{
			public static ICustomMarshaler GetInstance() => new SwMemMarshaler();

			void ICustomMarshaler.CleanUpManagedData(object ManagedObj) => throw new NotImplementedException();

			void ICustomMarshaler.CleanUpNativeData(IntPtr pNativeData) => SwMemFree(pNativeData);

			int ICustomMarshaler.GetNativeDataSize() => -1;

			IntPtr ICustomMarshaler.MarshalManagedToNative(object ManagedObj) => throw new NotImplementedException();

			object ICustomMarshaler.MarshalNativeToManaged(IntPtr pNativeData) => StringHelper.GetString(pNativeData, CharSet.Unicode);
		}
	}
}