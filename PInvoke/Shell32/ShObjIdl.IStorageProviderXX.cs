using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Undocumented.</summary>
	[ComImport, Guid("5efb46d7-47C0-4b68-acda-ded47c90ec91"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(StorageProviderBanners))]
	public interface IStorageProviderBanners
	{
		/// <summary>[Undocumented] Sets the banner.</summary>
		/// <param name="providerIdentity">The provider identity.</param>
		/// <param name="subscriptionId">The subscription identifier.</param>
		/// <param name="contentId">The content identifier.</param>
		/// <returns>Returns <c>S_OK</c> if successful, or an error code otherwise.</returns>
		HRESULT SetBanner([MarshalAs(UnmanagedType.LPWStr)] string providerIdentity,
			[MarshalAs(UnmanagedType.LPWStr)] string subscriptionId, [MarshalAs(UnmanagedType.LPWStr)] string contentId);

		/// <summary>[Undocumented] Clears the banner.</summary>
		/// <param name="providerIdentity">The provider identity.</param>
		/// <param name="subscriptionId">The subscription identifier.</param>
		/// <returns>Returns <c>S_OK</c> if successful, or an error code otherwise.</returns>
		HRESULT ClearBanner([MarshalAs(UnmanagedType.LPWStr)] string providerIdentity,
			[MarshalAs(UnmanagedType.LPWStr)] string subscriptionId);

		/// <summary>[Undocumented] Clears all banners.</summary>
		/// <param name="providerIdentity">The provider identity.</param>
		/// <returns>Returns <c>S_OK</c> if successful, or an error code otherwise.</returns>
		HRESULT ClearAllBanners([MarshalAs(UnmanagedType.LPWStr)] string providerIdentity);

		/// <summary>[Undocumented] Gets the banner.</summary>
		/// <param name="providerIdentity">The provider identity.</param>
		/// <param name="subscriptionId">The subscription identifier.</param>
		/// <param name="contentId">The content identifier.</param>
		/// <returns>Returns <c>S_OK</c> if successful, or an error code otherwise.</returns>
		HRESULT GetBanner([MarshalAs(UnmanagedType.LPWStr)] string providerIdentity,
			[MarshalAs(UnmanagedType.LPWStr)] string subscriptionId, [MarshalAs(UnmanagedType.LPWStr)] out string contentId);
	}

	/// <summary>
	/// Exposes a method that determines whether the Shell will be allowed to move, copy, delete, or rename a folder in a cloud
	/// provider's sync root.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/shell/nn-shobjidl-istorageprovidercopyhook
	[PInvokeData("shobjidl.h")]
	[ComImport, Guid("7bf992a9-af7a-4dba-b2e5-4d080b1ecbc6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IStorageProviderCopyHook
	{
		/// <summary>
		/// Determines whether the Shell will be allowed to move, copy, delete, or rename a folder in a cloud provider's sync root.
		/// </summary>
		/// <param name="hwnd">
		/// A handle to the window that the copy hook handler should use as the parent for any user interface elements the handler may
		/// need to display. If <c>FOF_SILENT</c> is specified in operation, the method should ignore this parameter.
		/// </param>
		/// <param name="operation">
		/// The operation to perform. This parameter can be one of the values listed under the <see cref="SHFILEOPSTRUCT.wFunc"/> member.
		/// </param>
		/// <param name="flags">
		/// <para>
		/// The flags that control the operation. This parameter can be one or more of the values listed under the the <see
		/// cref="SHFILEOPSTRUCT.fFlags"/> member.
		/// </para>
		/// <para>For printer copy hooks, this value is one of the following values defined in shellapi.h.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PO_DELETE</term>
		/// <term>A printer is being deleted. The srcFile parameter points to the full path to the specified printer.</term>
		/// </item>
		/// <item>
		/// <term>PO_RENAME</term>
		/// <term>
		/// A printer is being renamed. The srcFile parameter points to the printer's new name. The destFile parameter points to the old name.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PO_PORTCHANGE</term>
		/// <term>Not supported. Do not use.</term>
		/// </item>
		/// <item>
		/// <term>PO_REN_PORT</term>
		/// <term>Not supported. Do not use.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="srcFile">A pointer to a string that contains the name of the source folder.</param>
		/// <param name="srcAttribs">
		/// <para>[in]</para>
		/// <para>
		/// <para>
		/// The attributes of the source folder. This parameter can be a combination of any of the file attribute flags
		/// (FILE_ATTRIBUTE_*) defined in the header files. See File Attribute Constants.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="destFile">
		/// <para>[in]</para>
		/// <para>
		/// <para>A pointer to a string that contains the name of the destination folder.</para>
		/// </para>
		/// </param>
		/// <param name="destAttribs">
		/// <para>[in]</para>
		/// <para>
		/// <para>
		/// The attributes of the destination folder. This parameter can be a combination of any of the file attribute flags
		/// (FILE_ATTRIBUTE_*) defined in the header files. See File Attribute Constants.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="result">
		/// <para>[out]</para>
		/// <para>
		/// <para>The integer value that indicates whether the Shell should perform the operation. One of the following:</para>
		/// </para>
		/// </param>
		/// <returns>Returns <c>S_OK</c> if successful, or an error code otherwise.</returns>
		/// <remarks>
		/// <para>
		/// The Shell calls the cloud provider's copy hook handler for every folder under the registered sync root. To register a copy
		/// hook handler for cloud folders, set the <c>CopyHook</c> value under the
		/// <c>HKEY_LOCAL_MACHINE/Software/Microsoft/Windows/CurrentVersion/Explorer/SyncRootManager/{SyncRootId}</c> key to the CLSID
		/// of the copy hook object.
		/// </para>
		/// <para>
		/// When the <c>CopyCallback</c> method is called, the Shell initializes the IStorageProviderCopyHook interface directly without
		/// using an IShellExtInit interface first.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/nf-shobjidl-istorageprovidercopyhook-copycallback
		[PreserveSig]
		HRESULT CopyCallback([Optional] HWND hwnd, ShellFileOperation operation, FILEOP_FLAGS flags, [MarshalAs(UnmanagedType.LPWStr)] string srcFile,
			FileFlagsAndAttributes srcAttribs, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? destFile, FileFlagsAndAttributes destAttribs,
			out MB_RESULT result);
	}

	/// <summary>CLSID_StorageProviderBanners</summary>
	[ComImport, Guid("7CCDF9F4-E576-455A-8BC7-F6EC68D6F063"), ClassInterface(ClassInterfaceType.None)]
	public class StorageProviderBanners { }
}