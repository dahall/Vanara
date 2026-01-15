namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>A flag that can be sent to the disk cleanup manager.</summary>
	[PInvokeData("emptyvc.h", MSDNShortId = "NN:emptyvc.IEmptyVolumeCacheCallBack")]
	[Flags]
	public enum EVCCBF : uint
	{
		/// <summary>
		/// This flag should be set if the handler will not call this method again. It is typically set when the scan is near completion.
		/// </summary>
		EVCCBF_LASTNOTIFICATION = 0x0001
	}

	/// <summary>The flags that are used to pass information to the handler and back to the disk cleanup manager.</summary>
	[PInvokeData("emptyvc.h", MSDNShortId = "NN:emptyvc.IEmptyVolumeCache")]
	[Flags]
	public enum EVCF
	{
		/// <summary>
		/// Set this flag to indicate that the handler can display a UI. An example of a simple UI is a list box that displays the deletable
		/// files and allows the user to select which ones to delete. The disk cleanup manager will then display a button below the cleanup
		/// handler's description. The user clicks this button to request the UI. The default button text is "Settings", but the handler can
		/// specify a different text by setting the AdvancedButtonText value in its registry key.
		/// </summary>
		EVCF_HASSETTINGS = 0x0001,

		/// <summary>
		/// Set this flag to have the handler checked by default in the cleanup manager's list. It will run every time the Disk Cleanup
		/// utility runs, unless the user clears the handler's check box. Once the check box has been cleared, the handler will not be run
		/// until the user selects it again.
		/// </summary>
		EVCF_ENABLEBYDEFAULT = 0x0002,

		/// <summary>
		/// Set this flag to remove the handler from the disk cleanup manager's list. All registry information will be deleted, and the
		/// handler cannot be run again until the key and its values are restored. This flag is used primarily for one-time cleanup operations.
		/// </summary>
		EVCF_REMOVEFROMLIST = 0x0004,

		/// <summary>
		/// Set this flag to have the handler run automatically during scheduled cleanup. This flag should only be set when deletion of the
		/// files is low-risk. As with <c>EVCF_ENABLEBYDEFAULT</c>, the user can choose not to run the handler by clearing its check box in
		/// the disk cleanup manager's list.
		/// </summary>
		EVCF_ENABLEBYDEFAULT_AUTO = 0x0008,

		/// <summary>
		/// Set this flag when there are no files to delete. When IEmptyVolumeCache::GetSpaceUsed is called, set the <c>pdwSpaceUsed</c>
		/// parameter to zero, and the disk cleanup manager will omit the handler from its list.
		/// </summary>
		EVCF_DONTSHOWIFZERO = 0x0010,

		/// <summary>
		/// If the disk cleanup manager is being run on a schedule, it will set this flag. You must assign values to the
		/// <c>ppwszDisplayName</c> and <c>ppwszDescription</c> parameters. If this flag is set, the disk cleanup manager will not call
		/// IEmptyVolumeCache::GetSpaceUsed, IEmptyVolumeCache::Purge, or IEmptyVolumeCache::ShowProperties. Because
		/// <c>IEmptyVolumeCache::Purge</c> will not be called, cleanup must be handled by <c>IEmptyVolumeCache::Initialize</c>. The handler
		/// should ignore the <c>pcwszVolume</c> parameter and clean up any unneeded files regardless of what drive they are on. Because
		/// there is no opportunity for user feedback, only those files that are extremely safe to clean up should be touched.
		/// </summary>
		EVCF_SETTINGSMODE = 0x0020,

		/// <summary>
		/// If this flag is set, the user is out of disk space on the drive. When this flag is received, the handler should be aggressive
		/// about freeing disk space, even if it results in a performance loss. The handler, however, should not delete files that would
		/// cause an application to fail, or the user to lose data.
		/// </summary>
		EVCF_OUTOFDISKSPACE = 0x0040,

		/// <summary/>
		EVCF_USERCONSENTOBTAINED = 0x0080,

		/// <summary/>
		EVCF_SYSTEMAUTORUN = 0x0100,
	}

	/// <summary>
	/// Used by the disk cleanup manager to communicate with a disk cleanup handler. Exposes methods that enable the manager to request
	/// information from a handler, and notify it of events such as the start of a scan or purge.
	/// </summary>
	/// <remarks>
	/// This interface must be implemented by disk cleanup handlers running on Windows 98. Handlers running on Windows 2000 should also
	/// expose IEmptyVolumeCache2.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nn-emptyvc-iemptyvolumecache
	[PInvokeData("emptyvc.h", MSDNShortId = "NN:emptyvc.IEmptyVolumeCache")]
	[ComImport, Guid("8FCE5227-04DA-11d1-A004-00805F8ABE06"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEmptyVolumeCache
	{
		/// <summary>Initializes the disk cleanup handler, based on the information stored under the specified registry key.</summary>
		/// <param name="hkRegKey">
		/// <para>Type: <c>HKEY</c></para>
		/// <para>A handle to the registry key that holds the information about the handler object.</para>
		/// </param>
		/// <param name="pcwszVolume">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated Unicode string with the volume root—for example, "C:".</para>
		/// </param>
		/// <param name="ppwszDisplayName">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>
		/// A pointer to a null-terminated Unicode string with the name that will be displayed in the disk cleanup manager's list of
		/// handlers. If no value is assigned, the registry value will be used.
		/// </para>
		/// </param>
		/// <param name="ppwszDescription">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>
		/// A pointer to a null-terminated Unicode string that will be displayed when this object is selected from the disk cleanup manager's
		/// list of available disk cleanup handlers. If no value is assigned, the registry value will be used.
		/// </para>
		/// </param>
		/// <param name="pdwFlags">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The flags that are used to pass information to the handler and back to the disk cleanup manager.</para>
		/// <para>These flags can be passed in to the object:</para>
		/// <para>EVCF_OUTOFDISKSPACE</para>
		/// <para>
		/// If this flag is set, the user is out of disk space on the drive. When this flag is received, the handler should be aggressive
		/// about freeing disk space, even if it results in a performance loss. The handler, however, should not delete files that would
		/// cause an application to fail, or the user to lose data.
		/// </para>
		/// <para>EVCF_SETTINGSMODE</para>
		/// <para>
		/// If the disk cleanup manager is being run on a schedule, it will set this flag. You must assign values to the
		/// <c>ppwszDisplayName</c> and <c>ppwszDescription</c> parameters. If this flag is set, the disk cleanup manager will not call
		/// IEmptyVolumeCache::GetSpaceUsed, IEmptyVolumeCache::Purge, or IEmptyVolumeCache::ShowProperties. Because
		/// <c>IEmptyVolumeCache::Purge</c> will not be called, cleanup must be handled by <c>IEmptyVolumeCache::Initialize</c>. The handler
		/// should ignore the <c>pcwszVolume</c> parameter and clean up any unneeded files regardless of what drive they are on. Because
		/// there is no opportunity for user feedback, only those files that are extremely safe to clean up should be touched.
		/// </para>
		/// <para>These flags can be passed by the handler back to the disk cleanup manager:</para>
		/// <para>EVCF_DONTSHOWIFZERO</para>
		/// <para>
		/// Set this flag when there are no files to delete. When IEmptyVolumeCache::GetSpaceUsed is called, set the <c>pdwSpaceUsed</c>
		/// parameter to zero, and the disk cleanup manager will omit the handler from its list.
		/// </para>
		/// <para>EVCF_ENABLEBYDEFAULT</para>
		/// <para>
		/// Set this flag to have the handler checked by default in the cleanup manager's list. It will run every time the Disk Cleanup
		/// utility runs, unless the user clears the handler's check box. Once the check box has been cleared, the handler will not be run
		/// until the user selects it again.
		/// </para>
		/// <para>EVCF_ENABLEBYDEFAULT_AUTO</para>
		/// <para>
		/// Set this flag to have the handler run automatically during scheduled cleanup. This flag should only be set when deletion of the
		/// files is low-risk. As with <c>EVCF_ENABLEBYDEFAULT</c>, the user can choose not to run the handler by clearing its check box in
		/// the disk cleanup manager's list.
		/// </para>
		/// <para>EVCF_HASSETTINGS</para>
		/// <para>
		/// Set this flag to indicate that the handler can display a UI. An example of a simple UI is a list box that displays the deletable
		/// files and allows the user to select which ones to delete. The disk cleanup manager will then display a button below the cleanup
		/// handler's description. The user clicks this button to request the UI. The default button text is "Settings", but the handler can
		/// specify a different text by setting the AdvancedButtonText value in its registry key.
		/// </para>
		/// <para>EVCF_REMOVEFROMLIST</para>
		/// <para>
		/// Set this flag to remove the handler from the disk cleanup manager's list. All registry information will be deleted, and the
		/// handler cannot be run again until the key and its values are restored. This flag is used primarily for one-time cleanup operations.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>Success.</description>
		/// </item>
		/// <item>
		/// <description><c>S_FALSE</c></description>
		/// <description>There are no files to delete.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ABORT</c></description>
		/// <description>The cleanup operation was ended prematurely.</description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>The cleanup operation failed.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>This method is used by the Windows 98 disk cleanup manager. Windows 2000 uses the InitializeEx method exported by IEmptyVolumeCache2.</para>
		/// <para>
		/// Use CoTaskMemAlloc to allocate memory for the strings returned through <c>ppwszDisplayName</c> and <c>ppwszDescription</c>. The
		/// disk cleanup manager will free the memory when it is no longer needed.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nf-emptyvc-iemptyvolumecache-initialize HRESULT Initialize( [in] HKEY
		// hkRegKey, [in] LPCWSTR pcwszVolume, [out] PWSTR *ppwszDisplayName, [out] PWSTR *ppwszDescription, [in, out] DWORD *pdwFlags );
		[PreserveSig]
		HRESULT Initialize([In] HKEY hkRegKey, [MarshalAs(UnmanagedType.LPWStr)] string pcwszVolume, [MarshalAs(UnmanagedType.LPWStr)] out string ppwszDisplayName,
			[MarshalAs(UnmanagedType.LPWStr)] out string ppwszDescription, out EVCF pdwFlags);

		/// <summary>Requests the amount of disk space that the disk cleanup handler can free.</summary>
		/// <param name="pdwlSpaceUsed">
		/// <para>Type: <c>DWORDLONG*</c></para>
		/// <para>
		/// The amount of disk space, in bytes, that the handler can free. This value will be displayed in the disk cleanup manager's list,
		/// to the right of the handler's check box. To indicate that you do not know how much disk space can be freed, set this parameter to
		/// -1, and "???MB" will be displayed. If you set the <c>EVCF_DONTSHOWIFZERO</c> flag when Initialize was called, setting
		/// <c>pdwSpaceUsed</c> to zero will notify the disk cleanup manager to omit the handler from its list.
		/// </para>
		/// </param>
		/// <param name="picb">
		/// <para>Type: <c>IEmptyVolumeCacheCallback*</c></para>
		/// <para>
		/// A pointer to the disk cleanup manager's IEmptyVolumeCacheCallback interface. This pointer can be used to call that interface's
		/// ScanProgress method to report on the progress of the operation.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>Success.</description>
		/// </item>
		/// <item>
		/// <description><c>S_FALSE</c></description>
		/// <description>An error occurred when the handler tried to calculate the amount of disk space that could be freed.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ABORT</c></description>
		/// <description>
		/// The scan operation was ended prematurely. This value is usually returned when a call to ScanProgress returns E_ABORT. This return
		/// value indicates that the user canceled the operation by clicking the disk cleanup manager's <c>Cancel</c> button.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When this method is called by the disk cleanup manager, the handler should start scanning its files to determine which of them
		/// can be deleted, and how much disk space will be freed. Handlers should call IEmptyVolumeCache::ScanProgress periodically to keep
		/// the user informed of the progress of the scan, especially if it will take a long time. Calling this method frequently also allows
		/// the handler to determine whether the user has canceled the operation. If <c>ScanProgress</c> returns E_ABORT, the user has
		/// canceled the scan. The handler should immediately stop scanning and return E_ABORT.
		/// </para>
		/// <para>
		/// You should only set the <c>pdwSpaceUsed</c> parameter to -1 as a last resort. The handler is of limited value to a user if they
		/// don't know how much space will be freed.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nf-emptyvc-iemptyvolumecache-getspaceused HRESULT GetSpaceUsed( [out]
		// DWORDLONG *pdwlSpaceUsed, [in] IEmptyVolumeCacheCallBack *picb );
		[PreserveSig]
		HRESULT GetSpaceUsed(out ulong pdwlSpaceUsed, [In, Optional] IEmptyVolumeCacheCallBack? picb);

		/// <summary>Notifies the handler to start deleting its unneeded files.</summary>
		/// <param name="dwlSpaceToFree">
		/// <para>Type: <c>DWORDLONG</c></para>
		/// <para>
		/// The amount of disk space that the handler should free. If this parameter is set to -1, the handler should delete all its files.
		/// </para>
		/// </param>
		/// <param name="picb">
		/// <para>Type: <c>IEmptyVolumeCacheCallback*</c></para>
		/// <para>
		/// A pointer to the disk cleanup manager's IEmptyVolumeCacheCallBack interface. This pointer can be used to call the interface's
		/// PurgeProgress method to report on the progress of the operation.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>Success.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ABORT</c></description>
		/// <description>
		/// The operation was ended prematurely. This value is usually returned when PurgeProgress returns E_ABORT. This typically happens
		/// when the user cancels the operation by clicking the disk cleanup manager's <c>Cancel</c> button.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For Windows 98, the <c>dwSpaceToFree</c> parameter is always set to the value specified by the handler when
		/// IEmptyVolumeCache::GetSpaceUsed was called.
		/// </para>
		/// <para>
		/// In general, handlers should be kept simple and delete all of their files when this function is called. If there are significant
		/// performance advantages to only deleting a portion of the files, the handler should implement the ShowProperties method. When
		/// called, this method displays a UI that allows the user to select the files to be deleted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nf-emptyvc-iemptyvolumecache-purge HRESULT Purge( [in] DWORDLONG
		// dwlSpaceToFree, [in] IEmptyVolumeCacheCallBack *picb );
		[PreserveSig]
		HRESULT Purge(ulong dwlSpaceToFree = ulong.MaxValue, [In] IEmptyVolumeCacheCallBack? picb = null);

		/// <summary>Notifies the handler to display its UI.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The parent window to be used when displaying the UI.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>The user changed one or more settings.</description>
		/// </item>
		/// <item>
		/// <description><c>S_FALSE</c></description>
		/// <description>No settings were changed.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A handler can display a UI, which is typically used to allow the user to select which files are to be cleaned up and how. To do
		/// so, the handler sets the <c>EVCF_HASSETTINGS</c> flag in the <c>pdwFlags</c> parameter when Initialize is called. The disk
		/// cleanup manager will then display a <c>Settings</c> button. When that button is clicked, the disk cleanup manager calls
		/// <c>ShowProperties</c> to notify the handler to display its UI.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nf-emptyvc-iemptyvolumecache-showproperties HRESULT ShowProperties(
		// [in] HWND hwnd );
		[PreserveSig]
		HRESULT ShowProperties([In] HWND hwnd);

		/// <summary>Notifies the handler that the disk cleanup manager is shutting down.</summary>
		/// <param name="pdwFlags">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>A flag that can be set to return information to the disk cleanup manager. It can have the following value.</para>
		/// <para>EVCF_REMOVEFROMLIST</para>
		/// <para>If this flag is set, the disk cleanup manager will delete the handler's registry subkey.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>This value should always be returned.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the <c>EVCF_REMOVEFROMLIST</c> flag is set, the handler will not be run again unless the registry entries are reestablished.
		/// This flag is typically used for a handler that will only run once.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nf-emptyvc-iemptyvolumecache-deactivate HRESULT Deactivate( [out]
		// DWORD *pdwFlags );
		[PreserveSig]
		HRESULT Deactivate(out EVCF pdwFlags);
	}

	/// <summary>
	/// Extends IEmptyVolumeCache. This interface defines one additional method, InitializeEx, that provides better localization support than IEmptyVolumeCache::Initialize.
	/// </summary>
	/// <remarks>
	/// This interface should be exported by disk cleanup handlers running on Windows 2000. Handlers running on Windows 98 must export IEmptyVolumeCache.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nn-emptyvc-iemptyvolumecache2
	[PInvokeData("emptyvc.h", MSDNShortId = "NN:emptyvc.IEmptyVolumeCache2")]
	[ComImport, Guid("02b7e3ba-4db3-11d2-b2d9-00c04f8eec8c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEmptyVolumeCache2 : IEmptyVolumeCache
	{
		/// <summary>Initializes the disk cleanup handler, based on the information stored under the specified registry key.</summary>
		/// <param name="hkRegKey">
		/// <para>Type: <c>HKEY</c></para>
		/// <para>A handle to the registry key that holds the information about the handler object.</para>
		/// </param>
		/// <param name="pcwszVolume">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated Unicode string with the volume root—for example, "C:".</para>
		/// </param>
		/// <param name="ppwszDisplayName">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>
		/// A pointer to a null-terminated Unicode string with the name that will be displayed in the disk cleanup manager's list of
		/// handlers. If no value is assigned, the registry value will be used.
		/// </para>
		/// </param>
		/// <param name="ppwszDescription">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>
		/// A pointer to a null-terminated Unicode string that will be displayed when this object is selected from the disk cleanup manager's
		/// list of available disk cleanup handlers. If no value is assigned, the registry value will be used.
		/// </para>
		/// </param>
		/// <param name="pdwFlags">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>The flags that are used to pass information to the handler and back to the disk cleanup manager.</para>
		/// <para>These flags can be passed in to the object:</para>
		/// <para>EVCF_OUTOFDISKSPACE</para>
		/// <para>
		/// If this flag is set, the user is out of disk space on the drive. When this flag is received, the handler should be aggressive
		/// about freeing disk space, even if it results in a performance loss. The handler, however, should not delete files that would
		/// cause an application to fail, or the user to lose data.
		/// </para>
		/// <para>EVCF_SETTINGSMODE</para>
		/// <para>
		/// If the disk cleanup manager is being run on a schedule, it will set this flag. You must assign values to the
		/// <c>ppwszDisplayName</c> and <c>ppwszDescription</c> parameters. If this flag is set, the disk cleanup manager will not call
		/// IEmptyVolumeCache::GetSpaceUsed, IEmptyVolumeCache::Purge, or IEmptyVolumeCache::ShowProperties. Because
		/// <c>IEmptyVolumeCache::Purge</c> will not be called, cleanup must be handled by <c>IEmptyVolumeCache::Initialize</c>. The handler
		/// should ignore the <c>pcwszVolume</c> parameter and clean up any unneeded files regardless of what drive they are on. Because
		/// there is no opportunity for user feedback, only those files that are extremely safe to clean up should be touched.
		/// </para>
		/// <para>These flags can be passed by the handler back to the disk cleanup manager:</para>
		/// <para>EVCF_DONTSHOWIFZERO</para>
		/// <para>
		/// Set this flag when there are no files to delete. When IEmptyVolumeCache::GetSpaceUsed is called, set the <c>pdwSpaceUsed</c>
		/// parameter to zero, and the disk cleanup manager will omit the handler from its list.
		/// </para>
		/// <para>EVCF_ENABLEBYDEFAULT</para>
		/// <para>
		/// Set this flag to have the handler checked by default in the cleanup manager's list. It will run every time the Disk Cleanup
		/// utility runs, unless the user clears the handler's check box. Once the check box has been cleared, the handler will not be run
		/// until the user selects it again.
		/// </para>
		/// <para>EVCF_ENABLEBYDEFAULT_AUTO</para>
		/// <para>
		/// Set this flag to have the handler run automatically during scheduled cleanup. This flag should only be set when deletion of the
		/// files is low-risk. As with <c>EVCF_ENABLEBYDEFAULT</c>, the user can choose not to run the handler by clearing its check box in
		/// the disk cleanup manager's list.
		/// </para>
		/// <para>EVCF_HASSETTINGS</para>
		/// <para>
		/// Set this flag to indicate that the handler can display a UI. An example of a simple UI is a list box that displays the deletable
		/// files and allows the user to select which ones to delete. The disk cleanup manager will then display a button below the cleanup
		/// handler's description. The user clicks this button to request the UI. The default button text is "Settings", but the handler can
		/// specify a different text by setting the AdvancedButtonText value in its registry key.
		/// </para>
		/// <para>EVCF_REMOVEFROMLIST</para>
		/// <para>
		/// Set this flag to remove the handler from the disk cleanup manager's list. All registry information will be deleted, and the
		/// handler cannot be run again until the key and its values are restored. This flag is used primarily for one-time cleanup operations.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>Success.</description>
		/// </item>
		/// <item>
		/// <description><c>S_FALSE</c></description>
		/// <description>There are no files to delete.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ABORT</c></description>
		/// <description>The cleanup operation was ended prematurely.</description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>The cleanup operation failed.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>This method is used by the Windows 98 disk cleanup manager. Windows 2000 uses the InitializeEx method exported by IEmptyVolumeCache2.</para>
		/// <para>
		/// Use CoTaskMemAlloc to allocate memory for the strings returned through <c>ppwszDisplayName</c> and <c>ppwszDescription</c>. The
		/// disk cleanup manager will free the memory when it is no longer needed.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nf-emptyvc-iemptyvolumecache-initialize HRESULT Initialize( [in] HKEY
		// hkRegKey, [in] LPCWSTR pcwszVolume, [out] PWSTR *ppwszDisplayName, [out] PWSTR *ppwszDescription, [in, out] DWORD *pdwFlags );
		[PreserveSig]
		new HRESULT Initialize([In] HKEY hkRegKey, [MarshalAs(UnmanagedType.LPWStr)] string pcwszVolume, [MarshalAs(UnmanagedType.LPWStr)] out string ppwszDisplayName,
			[MarshalAs(UnmanagedType.LPWStr)] out string ppwszDescription, out EVCF pdwFlags);

		/// <summary>Requests the amount of disk space that the disk cleanup handler can free.</summary>
		/// <param name="pdwlSpaceUsed">
		/// <para>Type: <c>DWORDLONG*</c></para>
		/// <para>
		/// The amount of disk space, in bytes, that the handler can free. This value will be displayed in the disk cleanup manager's list,
		/// to the right of the handler's check box. To indicate that you do not know how much disk space can be freed, set this parameter to
		/// -1, and "???MB" will be displayed. If you set the <c>EVCF_DONTSHOWIFZERO</c> flag when Initialize was called, setting
		/// <c>pdwSpaceUsed</c> to zero will notify the disk cleanup manager to omit the handler from its list.
		/// </para>
		/// </param>
		/// <param name="picb">
		/// <para>Type: <c>IEmptyVolumeCacheCallback*</c></para>
		/// <para>
		/// A pointer to the disk cleanup manager's IEmptyVolumeCacheCallback interface. This pointer can be used to call that interface's
		/// ScanProgress method to report on the progress of the operation.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>Success.</description>
		/// </item>
		/// <item>
		/// <description><c>S_FALSE</c></description>
		/// <description>An error occurred when the handler tried to calculate the amount of disk space that could be freed.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ABORT</c></description>
		/// <description>
		/// The scan operation was ended prematurely. This value is usually returned when a call to ScanProgress returns E_ABORT. This return
		/// value indicates that the user canceled the operation by clicking the disk cleanup manager's <c>Cancel</c> button.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When this method is called by the disk cleanup manager, the handler should start scanning its files to determine which of them
		/// can be deleted, and how much disk space will be freed. Handlers should call IEmptyVolumeCache::ScanProgress periodically to keep
		/// the user informed of the progress of the scan, especially if it will take a long time. Calling this method frequently also allows
		/// the handler to determine whether the user has canceled the operation. If <c>ScanProgress</c> returns E_ABORT, the user has
		/// canceled the scan. The handler should immediately stop scanning and return E_ABORT.
		/// </para>
		/// <para>
		/// You should only set the <c>pdwSpaceUsed</c> parameter to -1 as a last resort. The handler is of limited value to a user if they
		/// don't know how much space will be freed.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nf-emptyvc-iemptyvolumecache-getspaceused HRESULT GetSpaceUsed( [out]
		// DWORDLONG *pdwlSpaceUsed, [in] IEmptyVolumeCacheCallBack *picb );
		[PreserveSig]
		new HRESULT GetSpaceUsed(out ulong pdwlSpaceUsed, [In, Optional] IEmptyVolumeCacheCallBack? picb);

		/// <summary>Notifies the handler to start deleting its unneeded files.</summary>
		/// <param name="dwlSpaceToFree">
		/// <para>Type: <c>DWORDLONG</c></para>
		/// <para>
		/// The amount of disk space that the handler should free. If this parameter is set to -1, the handler should delete all its files.
		/// </para>
		/// </param>
		/// <param name="picb">
		/// <para>Type: <c>IEmptyVolumeCacheCallback*</c></para>
		/// <para>
		/// A pointer to the disk cleanup manager's IEmptyVolumeCacheCallBack interface. This pointer can be used to call the interface's
		/// PurgeProgress method to report on the progress of the operation.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>Success.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ABORT</c></description>
		/// <description>
		/// The operation was ended prematurely. This value is usually returned when PurgeProgress returns E_ABORT. This typically happens
		/// when the user cancels the operation by clicking the disk cleanup manager's <c>Cancel</c> button.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For Windows 98, the <c>dwSpaceToFree</c> parameter is always set to the value specified by the handler when
		/// IEmptyVolumeCache::GetSpaceUsed was called.
		/// </para>
		/// <para>
		/// In general, handlers should be kept simple and delete all of their files when this function is called. If there are significant
		/// performance advantages to only deleting a portion of the files, the handler should implement the ShowProperties method. When
		/// called, this method displays a UI that allows the user to select the files to be deleted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nf-emptyvc-iemptyvolumecache-purge HRESULT Purge( [in] DWORDLONG
		// dwlSpaceToFree, [in] IEmptyVolumeCacheCallBack *picb );
		[PreserveSig]
		new HRESULT Purge(ulong dwlSpaceToFree = ulong.MaxValue, [In] IEmptyVolumeCacheCallBack? picb = null);

		/// <summary>Notifies the handler to display its UI.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The parent window to be used when displaying the UI.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>The user changed one or more settings.</description>
		/// </item>
		/// <item>
		/// <description><c>S_FALSE</c></description>
		/// <description>No settings were changed.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A handler can display a UI, which is typically used to allow the user to select which files are to be cleaned up and how. To do
		/// so, the handler sets the <c>EVCF_HASSETTINGS</c> flag in the <c>pdwFlags</c> parameter when Initialize is called. The disk
		/// cleanup manager will then display a <c>Settings</c> button. When that button is clicked, the disk cleanup manager calls
		/// <c>ShowProperties</c> to notify the handler to display its UI.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nf-emptyvc-iemptyvolumecache-showproperties HRESULT ShowProperties(
		// [in] HWND hwnd );
		[PreserveSig]
		new HRESULT ShowProperties([In] HWND hwnd);

		/// <summary>Notifies the handler that the disk cleanup manager is shutting down.</summary>
		/// <param name="pdwFlags">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>A flag that can be set to return information to the disk cleanup manager. It can have the following value.</para>
		/// <para>EVCF_REMOVEFROMLIST</para>
		/// <para>If this flag is set, the disk cleanup manager will delete the handler's registry subkey.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>This value should always be returned.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the <c>EVCF_REMOVEFROMLIST</c> flag is set, the handler will not be run again unless the registry entries are reestablished.
		/// This flag is typically used for a handler that will only run once.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nf-emptyvc-iemptyvolumecache-deactivate HRESULT Deactivate( [out]
		// DWORD *pdwFlags );
		[PreserveSig]
		new HRESULT Deactivate(out EVCF pdwFlags);

		/// <summary>Initializes the disk cleanup handler. It provides better support for localization than Initialize.</summary>
		/// <param name="hkRegKey">
		/// <para>Type: <c>HKEY</c></para>
		/// <para>A handle to the registry key that holds the information about the handler object.</para>
		/// </param>
		/// <param name="pcwszVolume">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated Unicode string with the volume root—for example, "C:".</para>
		/// </param>
		/// <param name="pcwszKeyName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated Unicode string with the name of the handler's registry key.</para>
		/// </param>
		/// <param name="ppwszDisplayName">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>
		/// A pointer to a null-terminated Unicode string with the name that will be displayed in the disk cleanup manager's list of
		/// handlers. You must assign a value to this parameter.
		/// </para>
		/// </param>
		/// <param name="ppwszDescription">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>
		/// A pointer to a null-terminated Unicode string that will be displayed when this object is selected from the disk cleanup manager's
		/// list of available disk cleaners. You must assign a value to this parameter.
		/// </para>
		/// </param>
		/// <param name="ppwszBtnText">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>
		/// A pointer to a null-terminated Unicode string with the text that will be displayed on the disk cleanup manager's <c>Settings</c>
		/// button. If the <c>EVCF_HASSETTINGS</c> flag is set, you must assign a value to <c>ppwszBtnText</c>. Otherwise, you can set it to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pdwFlags">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>Flags that are used to pass information to the handler, and back to the disk cleanup manager.</para>
		/// <para>These flags can be passed in to the object:</para>
		/// <para>EVCF_OUTOFDISKSPACE</para>
		/// <para>
		/// If this flag is set, the user is out of disk space on the drive. When this flag is received, the handler should be aggressive
		/// about freeing disk space, even if it results in a performance loss. The handler, however, should not delete files that would
		/// cause an application to fail, or the user to lose data.
		/// </para>
		/// <para>EVCF_SETTINGSMODE</para>
		/// <para>
		/// If the disk cleanup manager is run on a schedule, it will set the <c>EVCF_SETTINGSMODE</c> flag. You must assign values to the
		/// <c>ppwszDisplayName</c> and <c>ppwszDescription</c> parameters. If this flag is set, the disk cleanup manager will not call
		/// GetSpaceUsed, Purge, or ShowProperties. Because <c>Purge</c> will not be called, cleanup must be handled by <c>InitializeEx</c>.
		/// The handler should ignore the <c>pcwszVolume</c> parameter and clean up any unneeded files regardless of what drive they are on.
		/// Because there is no opportunity for user feedback, only those files that are extremely safe to clean up should be touched.
		/// </para>
		/// <para>These flags can be passed by the handler back to the disk cleanup manager:</para>
		/// <para>EVCF_DONTSHOWIFZERO</para>
		/// <para>
		/// Set this flag when there are no files to delete. When GetSpaceUsed is called, set the <c>pdwSpaceUsed</c> parameter to zero, and
		/// the disk cleanup manager will omit the handler from its list.
		/// </para>
		/// <para>EVCF_ENABLEBYDEFAULT</para>
		/// <para>
		/// Set this flag to have the handler checked by default in the disk cleanup manager's list. The handler will be run every time the
		/// disk cleanup utility runs, unless the user clears the handler's check box. Once the check box has been cleared, the handler will
		/// not be run until the user selects it again.
		/// </para>
		/// <para>EVCF_ENABLEBYDEFAULT_AUTO</para>
		/// <para>
		/// Set this flag to have the handler run automatically during scheduled cleanup. This flag should only be set when deletion of the
		/// files is low-risk. As with <c>EVCF_ENABLEBYDEFAULT</c>, the user can choose not to run the handler by clearing its check box in
		/// the disk cleanup manager's list.
		/// </para>
		/// <para>EVCF_HASSETTINGS</para>
		/// <para>
		/// Set this flag to indicate that the handler can display a UI. An example of a simple UI is a list box that displays the deletable
		/// files and allows the user to select which ones to delete. The disk cleanup manager will then display a button below the cleanup
		/// handler's description. The user clicks this button to request the UI. Use the <c>ppwszBtnText</c> parameter to specify the
		/// button's text.
		/// </para>
		/// <para>EVCF_REMOVEFROMLIST</para>
		/// <para>
		/// Set this flag to remove the handler from the disk cleanup manager's list. All registry information will be deleted, and the
		/// handler cannot be run again until the key and its values are restored. This flag is used primarily for one-time cleanup operations.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>Success.</description>
		/// </item>
		/// <item>
		/// <description><c>S_FALSE</c></description>
		/// <description>There are no files to delete.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ABORT</c></description>
		/// <description>The cleanup operation was ended prematurely.</description>
		/// </item>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>The cleanup operation failed.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The Windows 2000 disk cleanup manager will first call <c>IEmptyVolumeCache2::InitializeEx</c> to initialize a disk cleanup
		/// handler. It will only call Initialize if the IEmptyVolumeCache2 interface is not implemented. The Windows 98 disk cleanup manager
		/// only supports <c>Initialize</c>.
		/// </para>
		/// <para>
		/// <c>InitializeEx</c> is intended to provide better localization support than Initialize. When <c>InitializeEx</c> is called, the
		/// handler application must assign appropriately localized values to the <c>ppwszDisplayName</c> and <c>ppwszDescription</c>
		/// parameters. If the <c>Settings</c> button is enabled, you must also assign a value to the <c>ppwszBtnText</c> parameter. Unlike
		/// <c>Initialize</c>, if you set these strings to <c>NULL</c> to notify the disk cleanup manager to retrieve the default values from
		/// the registry, <c>InitializeEx</c> will fail.
		/// </para>
		/// <para>
		/// Use CoTaskMemAlloc to allocate memory for the strings returned through <c>ppwszDisplayName</c>, <c>ppwszDescription</c>, and
		/// <c>ppwszBtnText</c>. The disk cleanup manager will free the memory when it is no longer needed.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nf-emptyvc-iemptyvolumecache2-initializeex HRESULT InitializeEx( [in]
		// HKEY hkRegKey, [in] LPCWSTR pcwszVolume, [in] LPCWSTR pcwszKeyName, [out] PWSTR *ppwszDisplayName, [out] PWSTR
		// *ppwszDescription, [out] PWSTR *ppwszBtnText, [in, out] DWORD *pdwFlags );
		[PreserveSig]
		HRESULT InitializeEx([In] HKEY hkRegKey, [MarshalAs(UnmanagedType.LPWStr)] string pcwszVolume, [MarshalAs(UnmanagedType.LPWStr)] string pcwszKeyName,
			[MarshalAs(UnmanagedType.LPWStr)] out string ppwszDisplayName, [MarshalAs(UnmanagedType.LPWStr)] out string ppwszDescription,
			[MarshalAs(UnmanagedType.LPWStr)] out string? ppwszBtnText, out EVCF pdwFlags);
	}

	/// <summary>Exposes methods that are used by a disk cleanup handler to communicate with the disk cleanup manager.</summary>
	/// <remarks>
	/// A disk cleanup handler uses this interface to report to the disk cleanup manager on the progress either of deleting files or of
	/// scanning for deletable files. It also provides a way to query the manager, to find out if the user has canceled the operation. The
	/// handler receives a pointer to this interface when the manager calls the IEmptyVolumeCache::GetSpaceUsed or IEmptyVolumeCache::Purge methods.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nn-emptyvc-iemptyvolumecachecallback
	[PInvokeData("emptyvc.h", MSDNShortId = "NN:emptyvc.IEmptyVolumeCacheCallBack")]
	[ComImport, Guid("6E793361-73C6-11D0-8469-00AA00442901"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEmptyVolumeCacheCallBack
	{
		/// <summary>Called by a disk cleanup handler to update the disk cleanup manager on the progress of a scan for deletable files.</summary>
		/// <param name="dwlSpaceUsed">
		/// <para>Type: <c>DWORDLONG</c></para>
		/// <para>The amount of disk space that the handler can free at this point in the scan.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A flag that can be sent to the disk cleanup manager. This flag can have the following value.</para>
		/// <para>EVCCBF_LASTNOTIFICATION</para>
		/// <para>This flag should be set if the handler will not call this method again. It is typically set when the scan is near completion.</para>
		/// </param>
		/// <param name="pcwszStatus">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>Reserved.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>The handler should continue scanning for deletable files.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ABORT</c></description>
		/// <description>
		/// This value is returned when the user clicks the <c>Cancel</c> button on the disk cleanup manager's dialog box while a scan is in
		/// progress. The handler should stop scanning and shut down.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method is typically called by the handler's GetSpaceUsed method while the handler is scanning for deletable files.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nf-emptyvc-iemptyvolumecachecallback-scanprogress HRESULT
		// ScanProgress( [in] DWORDLONG dwlSpaceUsed, [in] DWORD dwFlags, [in] LPCWSTR pcwszStatus );
		[PreserveSig]
		HRESULT ScanProgress(ulong dwlSpaceUsed, EVCCBF dwFlags, [Optional] string? pcwszStatus);

		/// <summary>
		/// Called periodically by a disk cleanup handler to update the disk cleanup manager on the progress of a purge of deletable files.
		/// </summary>
		/// <param name="dwlSpaceFreed">
		/// <para>Type: <c>DWORDLONG</c></para>
		/// <para>
		/// The amount of disk space, in bytes, that has been freed at this point in the purge. The disk cleanup manager uses this value to
		/// update its progress bar.
		/// </para>
		/// </param>
		/// <param name="dwlSpaceToFree">
		/// <para>Type: <c>DWORDLONG</c></para>
		/// <para>The amount of disk space, in bytes, that remains to be freed at this point in the purge.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A flag that can be sent to the disk cleanup manager. It can have the following value:</para>
		/// <para>EVCCBF_LASTNOTIFICATION</para>
		/// <para>This flag should be set if the handler will not call this method again. It is typically set when the purge is near completion.</para>
		/// </param>
		/// <param name="pcwszStatus">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>Reserved.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>The handler should continue purging deletable files.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ABORT</c></description>
		/// <description>
		/// This value is returned when the user clicks the <c>Cancel</c> button on the disk cleanup manager's dialog box while a scan is in
		/// progress. The handler should stop purging files and shut down.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method is typically called by the handler's Purge method while the handler is purging deletable files. Handlers should call
		/// <c>PurgeProgress</c> periodically to keep the user informed of progress, especially if the purge will take a long time. Calling
		/// this method frequently also allows the handler to shut down promptly if a user cancels a purge.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/emptyvc/nf-emptyvc-iemptyvolumecachecallback-purgeprogress HRESULT
		// PurgeProgress( [in] DWORDLONG dwlSpaceFreed, [in] DWORDLONG dwlSpaceToFree, [in] DWORD dwFlags, [in] LPCWSTR pcwszStatus );
		HRESULT PurgeProgress(ulong dwlSpaceFreed, ulong dwlSpaceToFree, EVCCBF dwFlags, [Optional] string? pcwszStatus);
	}

	/// <summary>Class to get the default system volume cache instance using key in registry.</summary>
	public static class SystemVolumeCache
	{
		/// <summary>Gets and instance of <see cref="IEmptyVolumeCache"/> using the CLSID defined .</summary>
		/// <param name="volume">A string with the volume root—for example, "C:".</param>
		/// <param name="regSubKeyName">The registry key name that holds the information about the handler object.</param>
		/// <returns>A <see cref="IEmptyVolumeCache"/> instance.</returns>
		/// <exception cref="InvalidOperationException"></exception>
		public static IEmptyVolumeCache CreateInitializedInstance(string volume = @"C:\", string regSubKeyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VolumeCaches\Thumbnail Cache")
		{
			AdvApi32.RegOpenKeyEx(HKEY.HKEY_LOCAL_MACHINE, regSubKeyName, 0, AdvApi32.REGSAM.KEY_READ, out var hk).ThrowIfFailed();
			using (hk)
			{
				Type? type = Type.GetTypeFromCLSID(Guid.Parse(AdvApi32.RegQueryValueEx(hk, null)!.ToString()!), true);
				var ievc = (IEmptyVolumeCache?)Activator.CreateInstance(type!) ?? throw new InvalidOperationException();
				ievc.Initialize(hk, volume, out _, out _, out _).ThrowIfFailed();
				return ievc;
			}
		}
	}
}