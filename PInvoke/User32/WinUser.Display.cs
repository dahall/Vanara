using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>The type of information to retrieve.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "5ec7f521-28b5-4922-a3fc-aa4433de69e0")]
	[Flags]
	public enum QDC
	{
		/// <summary>The caller requests the table sizes to hold all the possible path combinations.</summary>
		QDC_ALL_PATHS = 0x00000001,

		/// <summary>The caller requests the table sizes to hold only active paths.</summary>
		QDC_ONLY_ACTIVE_PATHS = 0x00000002,

		/// <summary>
		/// The caller requests the table sizes to hold the active paths as defined in the persistence database for the currently
		/// connected monitors.
		/// </summary>
		QDC_DATABASE_CURRENT = 0x00000004,

		/// <summary>Undocumented.</summary>
		QDC_VIRTUAL_MODE_AWARE = 0x00000010,

		/// <summary>Undocumented.</summary>
		QDC_INCLUDE_HMD = 0x00000020,
	}

	/// <summary>Flag values that indicates the behavior of SetDisplayConfig.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "9f649fa0-ffb2-44c6-9a66-049f888e3b04")]
	[Flags]
	public enum SDC
	{
		/// <summary>The caller requests the last internal configuration from the persistence database.</summary>
		SDC_TOPOLOGY_INTERNAL = 0x00000001,

		/// <summary>The caller requests the last clone configuration from the persistence database.</summary>
		SDC_TOPOLOGY_CLONE = 0x00000002,

		/// <summary>The caller requests the last extended configuration from the persistence database.</summary>
		SDC_TOPOLOGY_EXTEND = 0x00000004,

		/// <summary>The caller requests the last external configuration from the persistence database.</summary>
		SDC_TOPOLOGY_EXTERNAL = 0x00000008,

		/// <summary>
		/// The caller provides the path data so the function only queries the persistence database to find and use the source and target mode.
		/// </summary>
		SDC_TOPOLOGY_SUPPLIED = 0x00000010,

		/// <summary>
		/// The caller requests a combination of all four SDC_TOPOLOGY_XXX configurations. This value informs the API to set the last
		/// known display configuration for the current connected monitors.
		/// </summary>
		SDC_USE_DATABASE_CURRENT = SDC_TOPOLOGY_INTERNAL | SDC_TOPOLOGY_CLONE | SDC_TOPOLOGY_EXTEND | SDC_TOPOLOGY_EXTERNAL,

		/// <summary>
		/// The topology, source, and target mode information that are supplied in the pathArray and the modeInfoArray parameters are
		/// used, rather than looking up the configuration in the database.
		/// </summary>
		SDC_USE_SUPPLIED_DISPLAY_CONFIG = 0x00000020,

		/// <summary>
		/// The system tests for the requested topology, source, and target mode information to determine whether it can be set.
		/// </summary>
		SDC_VALIDATE = 0x00000040,

		/// <summary>The resulting topology, source, and target mode is set.</summary>
		SDC_APPLY = 0x00000080,

		/// <summary>
		/// A modifier to the SDC_APPLY flag. This causes the change mode to be forced all the way down to the driver for each active display.
		/// </summary>
		SDC_NO_OPTIMIZATION = 0x00000100,

		/// <summary>The resulting topology, source, and target mode are saved to the database.</summary>
		SDC_SAVE_TO_DATABASE = 0x00000200,

		/// <summary>
		/// If required, the function can modify the specified source and target mode information in order to create a functional display
		/// path set.
		/// </summary>
		SDC_ALLOW_CHANGES = 0x00000400,

		/// <summary>
		/// When the function processes a SDC_TOPOLOGY_XXX request, it can force path persistence on a target to satisfy the request if
		/// necessary. For information about the other flags that this flag can be combined with, see the following list.
		/// </summary>
		SDC_PATH_PERSIST_IF_REQUIRED = 0x00000800,

		/// <summary>
		/// The caller requests that the driver is given an opportunity to update the GDI mode list while SetDisplayConfig sets the new
		/// display configuration. This flag value is only valid when the SDC_USE_SUPPLIED_DISPLAY_CONFIG and SDC_APPLY flag values are
		/// also specified.
		/// </summary>
		SDC_FORCE_MODE_ENUMERATION = 0x00001000,

		/// <summary>
		/// A modifier to the SDC_TOPOLOGY_SUPPLIED flag that indicates that SetDisplayConfig should ignore the path order of the
		/// supplied topology when searching the database. When this flag is set, the topology set is the most recent topology that
		/// contains all the paths regardless of the path order.
		/// </summary>
		SDC_ALLOW_PATH_ORDER_CHANGES = 0x00002000,

		/// <summary>Undocumented.</summary>
		SDC_VIRTUAL_MODE_AWARE = 0x00008000,
	}

	/// <summary>The <c>DisplayConfigGetDeviceInfo</c> function retrieves display configuration information about the device.</summary>
	/// <param name="requestPacket">
	/// A pointer to a DISPLAYCONFIG_DEVICE_INFO_HEADER structure. This structure contains information about the request, which includes
	/// the packet type in the <c>type</c> member. The type and size of additional data that <c>DisplayConfigGetDeviceInfo</c> returns
	/// after the header structure depend on the packet type.
	/// </param>
	/// <returns>
	/// <para>The function returns one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function succeeded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The combination of parameters and flags specified are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// The system is not running a graphics driver that was written according to the Windows Display Driver Model (WDDM). The function
	/// is only supported on a system with a WDDM driver running.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have access to the console session. This error occurs if the calling process does not have access to the
	/// current desktop or is running on a remote session.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The size of the packet that the caller passes is not big enough for the information that the caller requests.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_GEN_FAILURE</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use the <c>DisplayConfigGetDeviceInfo</c> function to obtain additional information about a source or target for an adapter, such
	/// as the display name, the preferred display mode, and source device name.
	/// </para>
	/// <para>
	/// The caller can call <c>DisplayConfigGetDeviceInfo</c> to obtain more friendly names to display in the user interface. The caller
	/// can obtain names for the adapter, the source, and the target. The caller can also call <c>DisplayConfigGetDeviceInfo</c> to
	/// obtain the best resolution of the connected display device.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-displayconfiggetdeviceinfo LONG
	// DisplayConfigGetDeviceInfo( DISPLAYCONFIG_DEVICE_INFO_HEADER *requestPacket );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "249dcb1a-4ce3-4478-8331-fb81e91313b0")]
	public static extern Win32Error DisplayConfigGetDeviceInfo(IntPtr requestPacket);

	/// <summary>The <c>DisplayConfigGetDeviceInfo</c> function retrieves display configuration information about the device.</summary>
	/// <typeparam name="T">The type of structure to return. This must match the type supported by <paramref name="type"/>.</typeparam>
	/// <param name="adapterId">
	/// A locally unique identifier (LUID) that identifies the adapter that the device information packet refers to.
	/// </param>
	/// <param name="id">
	/// The source or target identifier to get or set the device information for. The meaning of this identifier is related to the type
	/// of information being requested. For example, in the case of DISPLAYCONFIG_DEVICE_INFO_GET_SOURCE_NAME, this is the source identifier.
	/// </param>
	/// <param name="type">
	/// A DISPLAYCONFIG_DEVICE_INFO_TYPE enumerated value that determines the type of device information to retrieve or set. The
	/// remainder of the packet for the retrieve or set operation follows immediately after the DISPLAYCONFIG_DEVICE_INFO_HEADER
	/// structure. Leave this value as the default (0) to have the value inferred from <typeparamref name="T"/>.
	/// </param>
	/// <returns>The value of type <typeparamref name="T"/> for the information provided.</returns>
	/// <exception cref="ArgumentException">Request type does not match type param value.</exception>
	public static T DisplayConfigGetDeviceInfo<T>(ulong adapterId, uint id, DISPLAYCONFIG_DEVICE_INFO_TYPE type = 0) where T : struct
	{
		if (type == 0)
		{
			if (!CorrespondingTypeAttribute.CanGet<T, DISPLAYCONFIG_DEVICE_INFO_TYPE>(out type)) throw new ArgumentException("Unable to find enum value matching supplied type param.");
		}
		else if (!CorrespondingTypeAttribute.CanGet(type, typeof(T))) throw new ArgumentException("Request type does not match type param value.");
		var hdr = new DISPLAYCONFIG_DEVICE_INFO_HEADER { size = (uint)Marshal.SizeOf(typeof(T)), type = type, adapterId = adapterId, id = id };
		var mem = new SafeHGlobalHandle((int)hdr.size);
		mem.Zero();
		Marshal.StructureToPtr(hdr, (IntPtr)mem, false);
		var hdr2 = mem.ToStructure<T>();
		var err = DisplayConfigGetDeviceInfo((IntPtr)mem);
		err.ThrowIfFailed();
		return mem.ToStructure<T>();
	}

	/// <summary>The <c>DisplayConfigSetDeviceInfo</c> function sets the properties of a target.</summary>
	/// <param name="setPacket">
	/// A pointer to a DISPLAYCONFIG_DEVICE_INFO_HEADER structure that contains information to set for the device. The type and size of
	/// additional data that <c>DisplayConfigSetDeviceInfo</c> uses for the configuration comes after the header structure. This
	/// additional data depends on the packet type, as specified by the <c>type</c> member of DISPLAYCONFIG_DEVICE_INFO_HEADER. For
	/// example, if the caller wants to change the boot persistence, that caller allocates and fills a
	/// DISPLAYCONFIG_SET_TARGET_PERSISTENCE structure and passes a pointer to this structure in setPacket. Note that the first member of
	/// the DISPLAYCONFIG_SET_TARGET_PERSISTENCE structure is the DISPLAYCONFIG_DEVICE_INFO_HEADER.
	/// </param>
	/// <returns>
	/// <para>The function returns one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function succeeded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The combination of parameters and flags specified are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// The system is not running a graphics driver that was written according to the Windows Display Driver Model (WDDM). The function
	/// is only supported on a system with a WDDM driver running.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have access to the console session. This error occurs if the calling process does not have access to the
	/// current desktop or is running on a remote session.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The size of the packet that the caller passes is not big enough.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_GEN_FAILURE</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>DisplayConfigSetDeviceInfo</c> can currently only be used to start and stop boot persisted force projection on an analog
	/// target. For more information about boot persistence, see Forced Versus Connected Targets.
	/// </para>
	/// <para>
	/// <c>DisplayConfigSetDeviceInfo</c> can only be used to set DISPLAYCONFIG_DEVICE_INFO_SET_XXX type of information.
	/// <c>DisplayConfigSetDeviceInfo</c> fails if the <c>type</c> member of DISPLAYCONFIG_DEVICE_INFO_HEADER is set to one of the
	/// DISPLAYCONFIG_DEVICE_INFO_GET_XXX values.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-displayconfigsetdeviceinfo LONG
	// DisplayConfigSetDeviceInfo( DISPLAYCONFIG_DEVICE_INFO_HEADER *setPacket );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "4050b1f0-a588-427c-a0df-eefdc488fc20")]
	public static extern Win32Error DisplayConfigSetDeviceInfo(IntPtr setPacket);

	/// <summary>The <c>DisplayConfigSetDeviceInfo</c> function sets the properties of a target.</summary>
	/// <typeparam name="T">The type of the value to set.</typeparam>
	/// <param name="value">Contains information to set for the device.</param>
	/// <exception cref="ArgumentException">Supplied type does not match valid set value.</exception>
	public static void DisplayConfigSetDeviceInfo<T>(T value) where T : struct
	{
		if (!CorrespondingTypeAttribute.CanSet(typeof(DISPLAYCONFIG_DEVICE_INFO_TYPE), typeof(T))) throw new ArgumentException("Supplied type does not match valid set value.");
		var mem = SafeHGlobalHandle.CreateFromStructure(value);
		DisplayConfigSetDeviceInfo((IntPtr)mem).ThrowIfFailed();
	}

	/// <summary>
	/// The <c>GetDisplayConfigBufferSizes</c> function retrieves the size of the buffers that are required to call the
	/// QueryDisplayConfig function.
	/// </summary>
	/// <param name="flags">
	/// <para>The type of information to retrieve. The value for the Flags parameter must be one of the following values.</para>
	/// <para>QDC_ALL_PATHS</para>
	/// <para>The caller requests the table sizes to hold all the possible path combinations.</para>
	/// <para>QDC_ONLY_ACTIVE_PATHS</para>
	/// <para>The caller requests the table sizes to hold only active paths.</para>
	/// <para>QDC_DATABASE_CURRENT</para>
	/// <para>
	/// The caller requests the table sizes to hold the active paths as defined in the persistence database for the currently connected monitors.
	/// </para>
	/// </param>
	/// <param name="numPathArrayElements">
	/// Pointer to a variable that receives the number of elements in the path information table. The pNumPathArrayElements parameter
	/// value is then used by a subsequent call to the QueryDisplayConfig function. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="numModeInfoArrayElements">
	/// Pointer to a variable that receives the number of elements in the mode information table. The pNumModeInfoArrayElements parameter
	/// value is then used by a subsequent call to the QueryDisplayConfig function. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>The function returns one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function succeeded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The combination of parameters and flags that are specified is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// The system is not running a graphics driver that was written according to the Windows Display Driver Model (WDDM). The function
	/// is only supported on a system with a WDDM driver running.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have access to the console session. This error occurs if the calling process does not have access to the
	/// current desktop or is running on a remote session.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_GEN_FAILURE</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Given the current display path configuration and the requested flags, <c>GetDisplayConfigBufferSizes</c> returns the size of the
	/// path and mode tables that are required to store the information. <c>GetDisplayConfigBufferSizes</c> can return values that are
	/// slightly larger than are actually required because it determines that all source and target paths are valid; whereas, the driver
	/// might place some restrictions on the possible combinations.
	/// </para>
	/// <para>
	/// As <c>GetDisplayConfigBufferSizes</c> can only determine the required array size of that moment in time, it is possible that
	/// between calls to <c>GetDisplayConfigBufferSizes</c> and QueryDisplayConfig the system configuration has changed and the provided
	/// array sizes are no longer sufficient to store the new path data.
	/// </para>
	/// <para>
	/// If a caller is aware that it must enable additional sources and targets, the caller can allocate a larger mode information array
	/// than is returned from <c>GetDisplayConfigBufferSizes</c> so that it has the space to add the additional source and target modes
	/// after calling <c>QueryDisplayConfig</c> and before calling SetDisplayConfig.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdisplayconfigbuffersizes LONG
	// GetDisplayConfigBufferSizes( UINT32 flags, UINT32 *numPathArrayElements, UINT32 *numModeInfoArrayElements );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "5ec7f521-28b5-4922-a3fc-aa4433de69e0")]
	public static extern Win32Error GetDisplayConfigBufferSizes(QDC flags, out uint numPathArrayElements, out uint numModeInfoArrayElements);

	/// <summary>
	/// The <c>QueryDisplayConfig</c> function retrieves information about all possible display paths for all display devices, or views,
	/// in the current setting.
	/// </summary>
	/// <param name="flags">
	/// <para>The type of information to retrieve. The value for the Flags parameter must be one of the following values.</para>
	/// <para>QDC_ALL_PATHS</para>
	/// <para>All the possible path combinations of sources to targets.</para>
	/// <para>
	/// <c>Note</c> In the case of any temporary modes, the QDC_ALL_PATHS setting means the mode data returned may not be the same as
	/// that which is stored in the persistence database.
	/// </para>
	/// <para>QDC_ONLY_ACTIVE_PATHS</para>
	/// <para>Currently active paths only.</para>
	/// <para>
	/// <c>Note</c> In the case of any temporary modes, the QDC_ONLY_ACTIVE_PATHS setting means the mode data returned may not be the
	/// same as that which is stored in the persistence database.
	/// </para>
	/// <para>QDC_DATABASE_CURRENT</para>
	/// <para>Active path as defined in the CCD database for the currently connected displays.</para>
	/// </param>
	/// <param name="numPathArrayElements">
	/// Pointer to a variable that contains the number of elements in pPathInfoArray. This parameter cannot be <c>NULL</c>. If
	/// <c>QueryDisplayConfig</c> returns ERROR_SUCCESS, pNumPathInfoElements is updated with the number of valid entries in pPathInfoArray.
	/// </param>
	/// <param name="pathArray">
	/// Pointer to a variable that contains an array of DISPLAYCONFIG_PATH_INFO elements. Each element in pPathInfoArray describes a
	/// single path from a source to a target. The source and target mode information indexes are only valid in combination with the
	/// pmodeInfoArray tables that are returned for the API at the same time. This parameter cannot be <c>NULL</c>. The pPathInfoArray is
	/// always returned in path priority order. For more information about path priority order, see Path Priority Order.
	/// </param>
	/// <param name="numModeInfoArrayElements">
	/// Pointer to a variable that specifies the number in element of the mode information table. This parameter cannot be <c>NULL</c>.
	/// If <c>QueryDisplayConfig</c> returns ERROR_SUCCESS, pNumModeInfoArrayElements is updated with the number of valid entries in pModeInfoArray.
	/// </param>
	/// <param name="modeInfoArray">
	/// Pointer to a variable that contains an array of DISPLAYCONFIG_MODE_INFO elements. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="currentTopologyId">
	/// <para>
	/// Pointer to a variable that receives the identifier of the currently active topology in the CCD database. For a list of possible
	/// values, see the DISPLAYCONFIG_TOPOLOGY_ID enumerated type.
	/// </para>
	/// <para>The pCurrentTopologyId parameter is only set when the Flags parameter value is QDC_DATABASE_CURRENT.</para>
	/// <para>
	/// If the Flags parameter value is set to QDC_DATABASE_CURRENT, the pCurrentTopologyId parameter must not be <c>NULL</c>. If the
	/// Flags parameter value is not set to QDC_DATABASE_CURRENT, the pCurrentTopologyId parameter value must be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>The function returns one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function succeeded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The combination of parameters and flags that are specified is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// The system is not running a graphics driver that was written according to the Windows Display Driver Model (WDDM). The function
	/// is only supported on a system with a WDDM driver running.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have access to the console session. This error occurs if the calling process does not have access to the
	/// current desktop or is running on a remote session.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_GEN_FAILURE</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The supplied path and mode buffer are too small.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// As the GetDisplayConfigBufferSizes function can only determine the required array size at a particular moment in time, it is
	/// possible that between calls to <c>GetDisplayConfigBufferSizes</c> and <c>QueryDisplayConfig</c> the system configuration will
	/// change and the provided array sizes will no longer be sufficient to store the new path data. In this situation,
	/// <c>QueryDisplayConfig</c> fails with ERROR_INSUFFICIENT_BUFFER, and the caller should call <c>GetDisplayConfigBufferSizes</c>
	/// again to get the new array sizes. The caller should then allocate the correct amount of memory.
	/// </para>
	/// <para>
	/// <c>QueryDisplayConfig</c> returns paths in the path array that the pPathInfoArray parameter specifies and the source and target
	/// modes in the mode array that the pModeInfoArray parameter specifies. <c>QueryDisplayConfig</c> always returns paths in path
	/// priority order. If QDC_ALL_PATHS is set in the Flags parameter, <c>QueryDisplayConfig</c> returns all the inactive paths after
	/// the active paths.
	/// </para>
	/// <para>
	/// Full path, source mode, and target mode information is available for all active paths. The <c>ModeInfoIdx</c> members in the
	/// DISPLAYCONFIG_PATH_SOURCE_INFO and DISPLAYCONFIG_PATH_TARGET_INFO structures for the source and target are set up for these
	/// active paths. For inactive paths, returned source and target mode information is not available; therefore, the target information
	/// in the path structure is set to default values, and the source and target mode indexes are marked as invalid. For database
	/// queries, if the current connect monitors have an entry, <c>QueryDisplayConfig</c> returns full path, source mode, and target mode
	/// information (same as for active paths). However, if the database does not have a entry, <c>QueryDisplayConfig</c> returns just
	/// the path information with the default target details (same as for inactive paths).
	/// </para>
	/// <para>
	/// For an example of how source and target mode information relates to path information, see Relationship of Mode Information to
	/// Path Information.
	/// </para>
	/// <para>
	/// The caller can use DisplayConfigGetDeviceInfo to obtain additional information about the source or target device, for example,
	/// the monitor names and monitor preferred mode and source device name.
	/// </para>
	/// <para>
	/// If a target is currently being force projected, the <c>statusFlags</c> member of the DISPLAYCONFIG_PATH_TARGET_INFO structure has
	/// one of the DISPLAYCONFIG_TARGET_FORCED_XXX flags set.
	/// </para>
	/// <para>
	/// If the QDC_DATABASE_CURRENT flag is set in the Flags parameter, <c>QueryDisplayConfig</c> returns the topology identifier of the
	/// active database topology in the variable that the pCurrentTopologyId parameter points to. If the QDC_ALL_PATHS or
	/// QDC_ONLY_ACTIVE_PATHS flag is set in the Flags parameter, the pCurrentTopologyId parameter must be set to <c>NULL</c>; otherwise,
	/// <c>QueryDisplayConfig</c> returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// <para>
	/// If a caller calls <c>QueryDisplayConfig</c> with the QDC_DATABASE_CURRENT flag set in the Flags parameter,
	/// <c>QueryDisplayConfig</c> initializes the DISPLAYCONFIG_2DREGION structure that is specified in the <c>totalSize</c> member of
	/// the DISPLAYCONFIG_VIDEO_SIGNAL_INFO structure to zeros and does not complete DISPLAYCONFIG_2DREGION.
	/// </para>
	/// <para>
	/// The DEVMODE structure that is returned by the EnumDisplaySettings Win32 function (described in the Windows SDK documentation)
	/// contains information that relates to both the source and target modes. However, the CCD APIs explicitly separate the source and
	/// target mode components.
	/// </para>
	/// <para>DPI Virtualization</para>
	/// <para>
	/// This API does not participate in DPI virtualization. All sizes in the DEVMODE structure are in terms of physical pixels, and are
	/// not related to the calling context.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-querydisplayconfig LONG QueryDisplayConfig( UINT32 flags,
	// UINT32 *numPathArrayElements, DISPLAYCONFIG_PATH_INFO *pathArray, UINT32 *numModeInfoArrayElements, DISPLAYCONFIG_MODE_INFO
	// *modeInfoArray, DISPLAYCONFIG_TOPOLOGY_ID *currentTopologyId );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "b1792d7f-f216-4250-a6b6-a11b251a9cec")]
	public static extern Win32Error QueryDisplayConfig(QDC flags, ref uint numPathArrayElements, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DISPLAYCONFIG_PATH_INFO[] pathArray,
		ref uint numModeInfoArrayElements, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DISPLAYCONFIG_MODE_INFO[] modeInfoArray, IntPtr currentTopologyId = default);

	/// <summary>
	/// The <c>QueryDisplayConfig</c> function retrieves information about all possible display paths for all display devices, or views,
	/// in the current setting.
	/// </summary>
	/// <param name="flags">
	/// <para>The type of information to retrieve. The value for the Flags parameter must be one of the following values.</para>
	/// <para>QDC_ALL_PATHS</para>
	/// <para>All the possible path combinations of sources to targets.</para>
	/// <para>
	/// <c>Note</c> In the case of any temporary modes, the QDC_ALL_PATHS setting means the mode data returned may not be the same as
	/// that which is stored in the persistence database.
	/// </para>
	/// <para>QDC_ONLY_ACTIVE_PATHS</para>
	/// <para>Currently active paths only.</para>
	/// <para>
	/// <c>Note</c> In the case of any temporary modes, the QDC_ONLY_ACTIVE_PATHS setting means the mode data returned may not be the
	/// same as that which is stored in the persistence database.
	/// </para>
	/// <para>QDC_DATABASE_CURRENT</para>
	/// <para>Active path as defined in the CCD database for the currently connected displays.</para>
	/// </param>
	/// <param name="numPathArrayElements">
	/// Pointer to a variable that contains the number of elements in pPathInfoArray. This parameter cannot be <c>NULL</c>. If
	/// <c>QueryDisplayConfig</c> returns ERROR_SUCCESS, pNumPathInfoElements is updated with the number of valid entries in pPathInfoArray.
	/// </param>
	/// <param name="pathArray">
	/// Pointer to a variable that contains an array of DISPLAYCONFIG_PATH_INFO elements. Each element in pPathInfoArray describes a
	/// single path from a source to a target. The source and target mode information indexes are only valid in combination with the
	/// pmodeInfoArray tables that are returned for the API at the same time. This parameter cannot be <c>NULL</c>. The pPathInfoArray is
	/// always returned in path priority order. For more information about path priority order, see Path Priority Order.
	/// </param>
	/// <param name="numModeInfoArrayElements">
	/// Pointer to a variable that specifies the number in element of the mode information table. This parameter cannot be <c>NULL</c>.
	/// If <c>QueryDisplayConfig</c> returns ERROR_SUCCESS, pNumModeInfoArrayElements is updated with the number of valid entries in pModeInfoArray.
	/// </param>
	/// <param name="modeInfoArray">
	/// Pointer to a variable that contains an array of DISPLAYCONFIG_MODE_INFO elements. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="currentTopologyId">
	/// <para>
	/// Pointer to a variable that receives the identifier of the currently active topology in the CCD database. For a list of possible
	/// values, see the DISPLAYCONFIG_TOPOLOGY_ID enumerated type.
	/// </para>
	/// <para>The pCurrentTopologyId parameter is only set when the Flags parameter value is QDC_DATABASE_CURRENT.</para>
	/// <para>
	/// If the Flags parameter value is set to QDC_DATABASE_CURRENT, the pCurrentTopologyId parameter must not be <c>NULL</c>. If the
	/// Flags parameter value is not set to QDC_DATABASE_CURRENT, the pCurrentTopologyId parameter value must be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>The function returns one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function succeeded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The combination of parameters and flags that are specified is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// The system is not running a graphics driver that was written according to the Windows Display Driver Model (WDDM). The function
	/// is only supported on a system with a WDDM driver running.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have access to the console session. This error occurs if the calling process does not have access to the
	/// current desktop or is running on a remote session.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_GEN_FAILURE</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The supplied path and mode buffer are too small.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// As the GetDisplayConfigBufferSizes function can only determine the required array size at a particular moment in time, it is
	/// possible that between calls to <c>GetDisplayConfigBufferSizes</c> and <c>QueryDisplayConfig</c> the system configuration will
	/// change and the provided array sizes will no longer be sufficient to store the new path data. In this situation,
	/// <c>QueryDisplayConfig</c> fails with ERROR_INSUFFICIENT_BUFFER, and the caller should call <c>GetDisplayConfigBufferSizes</c>
	/// again to get the new array sizes. The caller should then allocate the correct amount of memory.
	/// </para>
	/// <para>
	/// <c>QueryDisplayConfig</c> returns paths in the path array that the pPathInfoArray parameter specifies and the source and target
	/// modes in the mode array that the pModeInfoArray parameter specifies. <c>QueryDisplayConfig</c> always returns paths in path
	/// priority order. If QDC_ALL_PATHS is set in the Flags parameter, <c>QueryDisplayConfig</c> returns all the inactive paths after
	/// the active paths.
	/// </para>
	/// <para>
	/// Full path, source mode, and target mode information is available for all active paths. The <c>ModeInfoIdx</c> members in the
	/// DISPLAYCONFIG_PATH_SOURCE_INFO and DISPLAYCONFIG_PATH_TARGET_INFO structures for the source and target are set up for these
	/// active paths. For inactive paths, returned source and target mode information is not available; therefore, the target information
	/// in the path structure is set to default values, and the source and target mode indexes are marked as invalid. For database
	/// queries, if the current connect monitors have an entry, <c>QueryDisplayConfig</c> returns full path, source mode, and target mode
	/// information (same as for active paths). However, if the database does not have a entry, <c>QueryDisplayConfig</c> returns just
	/// the path information with the default target details (same as for inactive paths).
	/// </para>
	/// <para>
	/// For an example of how source and target mode information relates to path information, see Relationship of Mode Information to
	/// Path Information.
	/// </para>
	/// <para>
	/// The caller can use DisplayConfigGetDeviceInfo to obtain additional information about the source or target device, for example,
	/// the monitor names and monitor preferred mode and source device name.
	/// </para>
	/// <para>
	/// If a target is currently being force projected, the <c>statusFlags</c> member of the DISPLAYCONFIG_PATH_TARGET_INFO structure has
	/// one of the DISPLAYCONFIG_TARGET_FORCED_XXX flags set.
	/// </para>
	/// <para>
	/// If the QDC_DATABASE_CURRENT flag is set in the Flags parameter, <c>QueryDisplayConfig</c> returns the topology identifier of the
	/// active database topology in the variable that the pCurrentTopologyId parameter points to. If the QDC_ALL_PATHS or
	/// QDC_ONLY_ACTIVE_PATHS flag is set in the Flags parameter, the pCurrentTopologyId parameter must be set to <c>NULL</c>; otherwise,
	/// <c>QueryDisplayConfig</c> returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// <para>
	/// If a caller calls <c>QueryDisplayConfig</c> with the QDC_DATABASE_CURRENT flag set in the Flags parameter,
	/// <c>QueryDisplayConfig</c> initializes the DISPLAYCONFIG_2DREGION structure that is specified in the <c>totalSize</c> member of
	/// the DISPLAYCONFIG_VIDEO_SIGNAL_INFO structure to zeros and does not complete DISPLAYCONFIG_2DREGION.
	/// </para>
	/// <para>
	/// The DEVMODE structure that is returned by the EnumDisplaySettings Win32 function (described in the Windows SDK documentation)
	/// contains information that relates to both the source and target modes. However, the CCD APIs explicitly separate the source and
	/// target mode components.
	/// </para>
	/// <para>DPI Virtualization</para>
	/// <para>
	/// This API does not participate in DPI virtualization. All sizes in the DEVMODE structure are in terms of physical pixels, and are
	/// not related to the calling context.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-querydisplayconfig LONG QueryDisplayConfig( UINT32 flags,
	// UINT32 *numPathArrayElements, DISPLAYCONFIG_PATH_INFO *pathArray, UINT32 *numModeInfoArrayElements, DISPLAYCONFIG_MODE_INFO
	// *modeInfoArray, DISPLAYCONFIG_TOPOLOGY_ID *currentTopologyId );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "b1792d7f-f216-4250-a6b6-a11b251a9cec")]
	public static extern Win32Error QueryDisplayConfig(QDC flags, ref uint numPathArrayElements, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DISPLAYCONFIG_PATH_INFO[] pathArray,
		ref uint numModeInfoArrayElements, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DISPLAYCONFIG_MODE_INFO[] modeInfoArray, out DISPLAYCONFIG_TOPOLOGY_ID currentTopologyId);

	/// <summary>
	/// The <c>QueryDisplayConfig</c> function retrieves information about all possible display paths for all display devices, or views,
	/// in the current setting. This method also calls GetDisplayConfigBufferSizes to determine output sizing.
	/// </summary>
	/// <param name="flags">
	/// <para>The type of information to retrieve. The value for the Flags parameter must be one of the following values.</para>
	/// <para>QDC_ALL_PATHS</para>
	/// <para>All the possible path combinations of sources to targets.</para>
	/// <para>
	/// <c>Note</c> In the case of any temporary modes, the QDC_ALL_PATHS setting means the mode data returned may not be the same as
	/// that which is stored in the persistence database.
	/// </para>
	/// <para>QDC_ONLY_ACTIVE_PATHS</para>
	/// <para>Currently active paths only.</para>
	/// <para>
	/// <c>Note</c> In the case of any temporary modes, the QDC_ONLY_ACTIVE_PATHS setting means the mode data returned may not be the
	/// same as that which is stored in the persistence database.
	/// </para>
	/// <para>QDC_DATABASE_CURRENT</para>
	/// <para>Active path as defined in the CCD database for the currently connected displays.</para>
	/// </param>
	/// <param name="pathArray">
	/// The resulting array of DISPLAYCONFIG_PATH_INFO elements. Each element in pPathInfoArray describes a single path from a source to
	/// a target. The source and target mode information indexes are only valid in combination with the pmodeInfoArray tables that are
	/// returned for the API at the same time. This parameter cannot be <c>NULL</c>. The pPathInfoArray is always returned in path
	/// priority order. For more information about path priority order, see Path Priority Order.
	/// </param>
	/// <param name="modeInfoArray">The resulting array of DISPLAYCONFIG_MODE_INFO elements.</param>
	/// <param name="currentTopologyId">
	/// <para>
	/// Pointer to a variable that receives the identifier of the currently active topology in the CCD database. For a list of possible
	/// values, see the DISPLAYCONFIG_TOPOLOGY_ID enumerated type.
	/// </para>
	/// <para>The pCurrentTopologyId parameter is only set when the Flags parameter value is QDC_DATABASE_CURRENT.</para>
	/// <para>
	/// If the Flags parameter value is set to QDC_DATABASE_CURRENT, the pCurrentTopologyId parameter must not be <c>NULL</c>. If the
	/// Flags parameter value is not set to QDC_DATABASE_CURRENT, the pCurrentTopologyId parameter value must be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>The function returns one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function succeeded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The combination of parameters and flags that are specified is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// The system is not running a graphics driver that was written according to the Windows Display Driver Model (WDDM). The function
	/// is only supported on a system with a WDDM driver running.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have access to the console session. This error occurs if the calling process does not have access to the
	/// current desktop or is running on a remote session.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_GEN_FAILURE</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The supplied path and mode buffer are too small.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>QueryDisplayConfig</c> returns paths in the path array that the pPathInfoArray parameter specifies and the source and target
	/// modes in the mode array that the pModeInfoArray parameter specifies. <c>QueryDisplayConfig</c> always returns paths in path
	/// priority order. If QDC_ALL_PATHS is set in the Flags parameter, <c>QueryDisplayConfig</c> returns all the inactive paths after
	/// the active paths.
	/// </para>
	/// <para>
	/// Full path, source mode, and target mode information is available for all active paths. The <c>ModeInfoIdx</c> members in the
	/// DISPLAYCONFIG_PATH_SOURCE_INFO and DISPLAYCONFIG_PATH_TARGET_INFO structures for the source and target are set up for these
	/// active paths. For inactive paths, returned source and target mode information is not available; therefore, the target information
	/// in the path structure is set to default values, and the source and target mode indexes are marked as invalid. For database
	/// queries, if the current connect monitors have an entry, <c>QueryDisplayConfig</c> returns full path, source mode, and target mode
	/// information (same as for active paths). However, if the database does not have a entry, <c>QueryDisplayConfig</c> returns just
	/// the path information with the default target details (same as for inactive paths).
	/// </para>
	/// <para>
	/// For an example of how source and target mode information relates to path information, see Relationship of Mode Information to
	/// Path Information.
	/// </para>
	/// <para>
	/// The caller can use DisplayConfigGetDeviceInfo to obtain additional information about the source or target device, for example,
	/// the monitor names and monitor preferred mode and source device name.
	/// </para>
	/// <para>
	/// If a target is currently being force projected, the <c>statusFlags</c> member of the DISPLAYCONFIG_PATH_TARGET_INFO structure has
	/// one of the DISPLAYCONFIG_TARGET_FORCED_XXX flags set.
	/// </para>
	/// <para>
	/// If the QDC_DATABASE_CURRENT flag is set in the Flags parameter, <c>QueryDisplayConfig</c> returns the topology identifier of the
	/// active database topology in the variable that the pCurrentTopologyId parameter points to. If the QDC_ALL_PATHS or
	/// QDC_ONLY_ACTIVE_PATHS flag is set in the Flags parameter, the pCurrentTopologyId parameter must be set to <c>NULL</c>; otherwise,
	/// <c>QueryDisplayConfig</c> returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// <para>
	/// If a caller calls <c>QueryDisplayConfig</c> with the QDC_DATABASE_CURRENT flag set in the Flags parameter,
	/// <c>QueryDisplayConfig</c> initializes the DISPLAYCONFIG_2DREGION structure that is specified in the <c>totalSize</c> member of
	/// the DISPLAYCONFIG_VIDEO_SIGNAL_INFO structure to zeros and does not complete DISPLAYCONFIG_2DREGION.
	/// </para>
	/// <para>
	/// The DEVMODE structure that is returned by the EnumDisplaySettings Win32 function (described in the Windows SDK documentation)
	/// contains information that relates to both the source and target modes. However, the CCD APIs explicitly separate the source and
	/// target mode components.
	/// </para>
	/// <para>DPI Virtualization</para>
	/// <para>
	/// This API does not participate in DPI virtualization. All sizes in the DEVMODE structure are in terms of physical pixels, and are
	/// not related to the calling context.
	/// </para>
	/// </remarks>
	[PInvokeData("winuser.h", MSDNShortId = "b1792d7f-f216-4250-a6b6-a11b251a9cec")]
	public static Win32Error QueryDisplayConfig(QDC flags, out DISPLAYCONFIG_PATH_INFO[] pathArray, out DISPLAYCONFIG_MODE_INFO[] modeInfoArray, out DISPLAYCONFIG_TOPOLOGY_ID currentTopologyId)
	{
		Win32Error err;
		do
		{
			err = GetDisplayConfigBufferSizes(flags, out var cPath, out var cMode);
			pathArray = new DISPLAYCONFIG_PATH_INFO[err.Failed ? 0 : cPath];
			modeInfoArray = new DISPLAYCONFIG_MODE_INFO[err.Failed ? 0 : cMode];
			currentTopologyId = 0;
			if (err.Failed) return err;
			if (flags.IsFlagSet(QDC.QDC_DATABASE_CURRENT))
				err = QueryDisplayConfig(flags, ref cPath, pathArray, ref cMode, modeInfoArray, out currentTopologyId);
			else
				err = QueryDisplayConfig(flags, ref cPath, pathArray, ref cMode, modeInfoArray);
			if (err.Succeeded || err != Win32Error.ERROR_INSUFFICIENT_BUFFER) return err;
		} while (err == Win32Error.ERROR_INSUFFICIENT_BUFFER);
		return err;
	}

	/// <summary>
	/// The <c>SetDisplayConfig</c> function modifies the display topology, source, and target modes by exclusively enabling the
	/// specified paths in the current session.
	/// </summary>
	/// <param name="numPathArrayElements">Number of elements in pathArray.</param>
	/// <param name="pathArray">
	/// Array of all display paths that are to be set. Only the paths within this array that have the DISPLAYCONFIG_PATH_ACTIVE flag set
	/// in the <c>flags</c> member of DISPLAYCONFIG_PATH_INFO are set. This parameter can be <c>NULL</c>. The order in which active paths
	/// appear in this array determines the path priority. For more information about path priority order, see Path Priority Order.
	/// </param>
	/// <param name="numModeInfoArrayElements">Number of elements in modeInfoArray.</param>
	/// <param name="modeInfoArray">
	/// Array of display source and target mode information (DISPLAYCONFIG_MODE_INFO) that is referenced by the <c>modeInfoIdx</c> member
	/// of DISPLAYCONFIG_PATH_SOURCE_INFO and DISPLAYCONFIG_PATH_TARGET_INFO element of path information from pathArray. This parameter
	/// can be <c>NULL</c>.
	/// </param>
	/// <param name="flags">
	/// <para>
	/// A bitwise OR of flag values that indicates the behavior of this function. This parameter can be one the following values, or a
	/// combination of the following values; 0 is not valid.
	/// </para>
	/// <para>SDC_APPLY</para>
	/// <para>The resulting topology, source, and target mode is set.</para>
	/// <para>SDC_NO_OPTIMIZATION</para>
	/// <para>
	/// A modifier to the SDC_APPLY flag. This causes the change mode to be forced all the way down to the driver for each active display.
	/// </para>
	/// <para>SDC_USE_SUPPLIED_DISPLAY_CONFIG</para>
	/// <para>
	/// The topology, source, and target mode information that are supplied in the pathArray and the modeInfoArray parameters are used,
	/// rather than looking up the configuration in the database.
	/// </para>
	/// <para>SDC_SAVE_TO_DATABASE</para>
	/// <para>The resulting topology, source, and target mode are saved to the database.</para>
	/// <para>SDC_VALIDATE</para>
	/// <para>The system tests for the requested topology, source, and target mode information to determine whether it can be set.</para>
	/// <para>SDC_ALLOW_CHANGES</para>
	/// <para>
	/// If required, the function can modify the specified source and target mode information in order to create a functional display
	/// path set.
	/// </para>
	/// <para>SDC_TOPOLOGY_CLONE</para>
	/// <para>The caller requests the last clone configuration from the persistence database.</para>
	/// <para>SDC_TOPOLOGY_EXTEND</para>
	/// <para>The caller requests the last extended configuration from the persistence database.</para>
	/// <para>SDC_TOPOLOGY_INTERNAL</para>
	/// <para>The caller requests the last internal configuration from the persistence database.</para>
	/// <para>SDC_TOPOLOGY_EXTERNAL</para>
	/// <para>The caller requests the last external configuration from the persistence database.</para>
	/// <para>SDC_TOPOLOGY_SUPPLIED</para>
	/// <para>
	/// The caller provides the path data so the function only queries the persistence database to find and use the source and target mode.
	/// </para>
	/// <para>SDC_USE_DATABASE_CURRENT</para>
	/// <para>
	/// The caller requests a combination of all four SDC_TOPOLOGY_XXX configurations. This value informs the API to set the last known
	/// display configuration for the current connected monitors.
	/// </para>
	/// <para>SDC_PATH_PERSIST_IF_REQUIRED</para>
	/// <para>
	/// When the function processes a SDC_TOPOLOGY_XXX request, it can force path persistence on a target to satisfy the request if
	/// necessary. For information about the other flags that this flag can be combined with, see the following list.
	/// </para>
	/// <para>SDC_FORCE_MODE_ENUMERATION</para>
	/// <para>
	/// The caller requests that the driver is given an opportunity to update the GDI mode list while <c>SetDisplayConfig</c> sets the
	/// new display configuration. This flag value is only valid when the SDC_USE_SUPPLIED_DISPLAY_CONFIG and SDC_APPLY flag values are
	/// also specified.
	/// </para>
	/// <para>SDC_ALLOW_PATH_ORDER_CHANGES</para>
	/// <para>
	/// A modifier to the SDC_TOPOLOGY_SUPPLIED flag that indicates that <c>SetDisplayConfig</c> should ignore the path order of the
	/// supplied topology when searching the database. When this flag is set, the topology set is the most recent topology that contains
	/// all the paths regardless of the path order.
	/// </para>
	/// <para>The following list contains valid combinations of values for the Flags parameter:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Either SDC_APPLY or SDC_VALIDATE must be set, but not both.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Either SDC_USE_SUPPLIED_DISPLAY_CONFIG or any combinations of SDC_TOPOLOGY_XXX must be set. SDC_USE_SUPPLIED_DISPLAY_CONFIG
	/// cannot be set with any SDC_TOPOLOGY_XXX flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SDC_NO_OPTIMIZATION can only be set with SDC_APPLY.</term>
	/// </item>
	/// <item>
	/// <term>SDC_ALLOW_CHANGES is allowed with any other valid combination.</term>
	/// </item>
	/// <item>
	/// <term>SDC_SAVE_TO_DATABASE can only be set with SDC_USE_SUPPLIED_DISPLAY_CONFIG.</term>
	/// </item>
	/// <item>
	/// <term>SDC_PATH_PERSIST_IF_REQUIRED cannot be used with SDC_USE_SUPPLIED_DISPLAY_CONFIG or SDC_TOPOLOGY_SUPPLIED.</term>
	/// </item>
	/// <item>
	/// <term>SDC_FORCE_MODE_ENUMERATION is only valid when SDC_APPLY and SDC_USE_SUPPLIED_DISPLAY_CONFIG are specified.</term>
	/// </item>
	/// <item>
	/// <term>SDC_ALLOW_PATH_ORDER_CHANGES is allowed only when SDC_TOPOLOGY_SUPPLIED is specified.</term>
	/// </item>
	/// <item>
	/// <term>
	/// SDC_TOPOLOGY_SUPPLIED cannot be used with any other SDC_TOPOLOGY_XXX flag. Because of a validation issue, if a caller violates
	/// this rule, <c>SetDisplayConfig</c> does not fail. However, <c>SetDisplayConfig</c> ignores the SDC_TOPOLOGY_SUPPLIED flag.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// SDC_TOPOLOGY_XXX flags can be used in combinations. For example, if SDC_TOPOLOGY_CLONE and SDC_TOPOLOGY_EXTEND are set, the API
	/// uses the most recent clone or extend topology, which every topology was set with most recently for the current connected monitors.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>The function returns one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function succeeded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The combination of parameters and flags specified is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// The system is not running a graphics driver that was written according to the Windows Display Driver Model (WDDM). The function
	/// is only supported on a system with a WDDM driver running.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have access to the console session. This error occurs if the calling process does not have access to the
	/// current desktop or is running on a remote session.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_GEN_FAILURE</term>
	/// <term>An unspecified error occurred.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The function could not find a workable solution for the source and target modes that the caller did not specify.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SetDisplayConfig</c> function takes the active display paths with any specified source and target mode information and
	/// uses best mode logic to generate any missing source and target mode information. This function then sets the complete display path.
	/// </para>
	/// <para>
	/// The <c>ModeInfoIdx</c> members in the DISPLAYCONFIG_PATH_SOURCE_INFO and DISPLAYCONFIG_PATH_TARGET_INFO structures are used to
	/// indicate whether source and target mode are supplied for a given active path. If the index value is
	/// DISPLAYCONFIG_PATH_MODE_IDX_INVALID for either, this indicates the mode information is not being specified. It is valid for the
	/// path plus source mode or the path plus source and target mode information to be specified for a given path. However, it is not
	/// valid for the path plus target mode to be specified without the source mode.
	/// </para>
	/// <para>
	/// The source and target modes for each source and target identifiers can only appear in the modeInfoArray array once. For example,
	/// a source mode for source identifier S1 can only appear in the table once; if multiple paths reference the same source, they have
	/// to use the same <c>ModeInfoIdx</c>.
	/// </para>
	/// <para>
	/// The expectation is that most callers use QueryDisplayConfig to get the current configuration along with other valid possibilities
	/// and then use <c>SetDisplayConfig</c> to test and set the configuration.
	/// </para>
	/// <para>The order in which the active paths appear in the PathArray array determines the path priority.</para>
	/// <para>
	/// By default, <c>SetDisplayConfig</c> never changes any supplied path, source mode, or target mode information. If best mode logic
	/// cannot find a solution without changing the specified display path information, <c>SetDisplayConfig</c> fails with
	/// ERROR_BAD_CONFIGURATION. In this case, the caller should specify the SDC_ALLOW_CHANGES flag to allow the function to tweak some
	/// of the specified source and mode details to allow the display path change to be successful.
	/// </para>
	/// <para>
	/// If the specified or calculated source and target modes have the same dimensions, <c>SetDisplayConfig</c> automatically sets the
	/// path scaling to DISPLAYCONFIG_PPR_IDENTITY before setting the display path and saving it in the database. For information about
	/// how <c>SetDisplayConfig</c> handles scaling, see Scaling the Desktop Image.
	/// </para>
	/// <para>
	/// When the caller specifies the SDC_USE_SUPPLIED_DISPLAY_CONFIG flag to set a clone path and if any source mode indexes are invalid
	/// in the path array, <c>SetDisplayConfig</c> determines that all of the source mode indexes from that source are invalid.
	/// <c>SetDisplayConfig</c> uses the best mode logic to determine the source mode information.
	/// </para>
	/// <para>
	/// Except for the SDC_TOPOLOGY_SUPPLIED flag (for more information about SDC_TOPOLOGY_SUPPLIED, see the following paragraph), the
	/// SDC_TOPOLOGY_XXX flags set last display path settings, including the source and target mode information for that topology type.
	/// For information about valid SDC_TOPOLOGY_XXX flag combinations, see the Flags parameter description. The pathArray and
	/// modeInfoArray parameters must be <c>NULL</c>, and their associated sizes must be zero. For example, if SDC_TOPOLOGY_CLONE and
	/// SDC_TOPOLOGY_EXTEND are set, this function uses the most recent clone or extend display path configuration. If a single topology
	/// type is requested, the last configuration of that type is used. If that topology had never been set before,
	/// <c>SetDisplayConfig</c> uses the best topology logic to find the best topology, and then best mode logic to find the best source
	/// and target mode to use. If a combination of the topology flags had been set and none of them had database entries, the following
	/// priority is used. For laptops: clone, extend, internal, and then external; for desktops the priority is extend and then clone.
	/// </para>
	/// <para>
	/// The caller can specify the SDC_TOPOLOGY_SUPPLIED flag to indicate that it sets just the path information (topology) and requests
	/// that <c>SetDisplayConfig</c> obtains and then uses the source and target mode information from the persistence database. If the
	/// active paths that the caller supplies do not have an entry in the persistence database, <c>SetDisplayConfig</c> fails. In this
	/// case, if the caller calls <c>SetDisplayConfig</c> again with the same path data but with the SDC_USE_SUPPLIED_DISPLAY_CONFIG flag
	/// set, <c>SetDisplayConfig</c> uses best mode logic to create the source and target mode information. When the caller specifies
	/// SDC_TOPOLOGY_SUPPLIED, the caller must set the numModeInfoArrayElements parameter to zero and the modeInfoArray parameter to
	/// <c>NULL</c>; however, the caller must set the pathArray and numPathArrayElements parameters for the path information that the
	/// caller requires. The caller must mark all the source and target mode indexes as invalid (DISPLAYCONFIG_PATH_MODE_IDX_INVALID) in
	/// this path data.
	/// </para>
	/// <para>
	/// The following table provides some common scenarios where <c>SetDisplayConfig</c> is called along with the flag combinations that
	/// the caller passes to the Flags parameter to achieve the scenarios.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Scenario</term>
	/// <term>Flag combination</term>
	/// </listheader>
	/// <item>
	/// <term>Test whether a specified display configuration is supported on the computer</term>
	/// <term>SDC_VALIDATE | SDC_USE_SUPPLIED_DISPLAY_CONFIG</term>
	/// </item>
	/// <item>
	/// <term>Set a specified display configuration and save to the database</term>
	/// <term>SDC_APPLY | SDC_USE_SUPPLIED_DISPLAY_CONFIG | SDC_SAVE_TO_DATABASE</term>
	/// </item>
	/// <item>
	/// <term>Set a temporary display configuration (that is, the display configuration will not be saved)</term>
	/// <term>SDC_APPLY | SDC_USE_SUPPLIED_DISPLAY_CONFIG</term>
	/// </item>
	/// <item>
	/// <term>Test whether clone is supported on the computer</term>
	/// <term>SDC_VALIDATE | SDC_TOPOLOGY_CLONE</term>
	/// </item>
	/// <item>
	/// <term>Set clone topology</term>
	/// <term>SDC_APPLY | SDC_TOPOLOGY_CLONE</term>
	/// </item>
	/// <item>
	/// <term>Set clone topology and allow path persistence to be enabled if required to satisfy the request</term>
	/// <term>SDC_APPLY | SDC_TOPOLOGY_CLONE | SDC_PATH_PERSIST_IF_REQUIRED</term>
	/// </item>
	/// <item>
	/// <term>Return from a temporary mode to the last saved display configuration</term>
	/// <term>SDC_APPLY| SDC_USE_DATABASE_CURRENT</term>
	/// </item>
	/// <item>
	/// <term>
	/// Given only the path information, set the display configuration with the source and target information from the database for the
	/// paths and ignore the path order
	/// </term>
	/// <term>SDC_APPLY | SDC_TOPOLOGY_SUPPLIED | SDC_ALLOW_PATH_ORDER_CHANGES</term>
	/// </item>
	/// </list>
	/// <para>DPI Virtualization</para>
	/// <para>
	/// This API does not participate in DPI virtualization. All sizes in the DEVMODE structure are in terms of physical pixels, and are
	/// not related to the calling context.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setdisplayconfig LONG SetDisplayConfig( UINT32
	// numPathArrayElements, DISPLAYCONFIG_PATH_INFO *pathArray, UINT32 numModeInfoArrayElements, DISPLAYCONFIG_MODE_INFO *modeInfoArray,
	// UINT32 flags );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "9f649fa0-ffb2-44c6-9a66-049f888e3b04")]
	public static extern Win32Error SetDisplayConfig(uint numPathArrayElements, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Optional] DISPLAYCONFIG_PATH_INFO[]? pathArray,
		uint numModeInfoArrayElements, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2), Optional] DISPLAYCONFIG_MODE_INFO[]? modeInfoArray, SDC flags);
}