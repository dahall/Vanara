using static Vanara.PInvoke.PropSys;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>The transfer state. One of the following values.</summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NF:shobjidl_core.ITransferAdviseSink.UpdateTransferState")]
	[Flags]
	public enum TRANSFER_ADVISE_STATE
	{
		/// <summary>No transfer is in progress.</summary>
		TS_NONE = 0x00000000,

		/// <summary>The transfer is being performed.</summary>
		TS_PERFORMING = 0x00000001,

		/// <summary>The transfer is preparing to begin. For example, this flag would be set when space requirements are being calculated.</summary>
		TS_PREPARING = 0x00000002,

		/// <summary>Length of the transfer is unknown.</summary>
		TS_INDETERMINATE = 0x00000004,
	}

	/// <summary>Exposes methods supporting status collection and failure information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-itransferadvisesink
	[ComImport, Guid("d594d0d8-8da7-457b-b3b4-ce5dbaac0b88"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITransferAdviseSink
	{
		/// <summary>Updates the transfer progress status in the UI.</summary>
		/// <param name="ullSizeCurrent">
		/// <para>Type: <c>ULONGLONG</c></para>
		/// <para>The number of bytes processed in the current operation.</para>
		/// </param>
		/// <param name="ullSizeTotal">
		/// <para>Type: <c>ULONGLONG</c></para>
		/// <para>The total number of bytes in the current operation.</para>
		/// </param>
		/// <param name="nFilesCurrent">
		/// <para>Type: <c>int</c></para>
		/// <para>The number of files processed in the current operation.</para>
		/// </param>
		/// <param name="nFilesTotal">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The total number of files in the operation. Set to 0 to indicate that the value has not changed since the last call to this method.
		/// </para>
		/// </param>
		/// <param name="nFoldersCurrent">
		/// <para>Type: <c>int</c></para>
		/// <para>The number of folders processed in the current operation.</para>
		/// </param>
		/// <param name="nFoldersTotal">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The total number of folders in the operation. Set to 0 to indicate that the value has not changed since the last call to
		/// this method.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Set ullSizeTotal, nFilesTotal, and nFoldersTotal all to 0 to indicate that the totals have not changed since the last call
		/// to this method.
		/// </para>
		/// <para>Set all six parameters to 0 to indicate that progress has not changed since the last call to this method.</para>
		/// <para>Note to Implementers</para>
		/// <para>
		/// Implementers of this function should return an erorr code when the operation needs to terminate before it is complete, such
		/// as when the user clicks the <c>Cancel</c> button.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransferadvisesink-updateprogress HRESULT
		// UpdateProgress( ULONGLONG ullSizeCurrent, ULONGLONG ullSizeTotal, int nFilesCurrent, int nFilesTotal, int nFoldersCurrent,
		// int nFoldersTotal );
		[PreserveSig]
		HRESULT UpdateProgress(ulong ullSizeCurrent, ulong ullSizeTotal, int nFilesCurrent, int nFilesTotal, int nFoldersCurrent, int nFoldersTotal);

		/// <summary>Updates the transfer state.</summary>
		/// <param name="ts">
		/// <para>Type: <c>TRANSFER_ADVISE_STATE</c></para>
		/// <para>The transfer state. One of the following values.</para>
		/// <para>TS_NONE (0x00000000)</para>
		/// <para>0x00000000. No transfer is in progress.</para>
		/// <para>TS_PERFORMING (0x00000001)</para>
		/// <para>0x00000001. The transfer is being performed.</para>
		/// <para>TS_PREPARING (0x00000002)</para>
		/// <para>
		/// 0x00000002. The transfer is preparing to begin. For example, this flag would be set when space requirements are being calculated.
		/// </para>
		/// <para>TS_INDETERMINATE (0x00000004)</para>
		/// <para>0x00000004. Length of the transfer is unknown.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransferadvisesink-updatetransferstate
		// HRESULT UpdateTransferState( TRANSFER_ADVISE_STATE ts );
		[PreserveSig]
		HRESULT UpdateTransferState(TRANSFER_ADVISE_STATE ts);

		/// <summary>Displays a message to the user confirming that overwriting existing items is acceptable.</summary>
		/// <param name="psiSource">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the source IShellItem .</para>
		/// </param>
		/// <param name="psiDestParent">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the destination parent folder IShellItem.</para>
		/// </param>
		/// <param name="pszName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>
		/// A pointer to a wide-string containing the desired name of the item at the destination. If <c>NULL</c>, the name is the same
		/// as the Shell item pointed to by psiSource.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// The return values listed below are emitted specifically by this method to inform the calling process of how the operation
		/// ended. If other results or errors are emitted during the operation of this method, they should be returned to the calling process.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>COPYENGINE_S_USER_IGNORED</term>
		/// <term>The user clicked Ignore. Allows the calling process to continue processing other files as appropriate.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_E_USER_CANCELLED</term>
		/// <term>The user clicked Cancel. Stops processing of the current document and ends the current process.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransferadvisesink-confirmoverwrite
		// HRESULT ConfirmOverwrite( IShellItem *psiSource, IShellItem *psiDestParent, LPCWSTR pszName );
		[PreserveSig]
		HRESULT ConfirmOverwrite(IShellItem psiSource, IShellItem psiDestParent, [MarshalAs(UnmanagedType.LPWStr)] string? pszName);

		/// <summary>Displays a message to the user confirming that loss of encryption is acceptable for this operation.</summary>
		/// <param name="psiSource">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to an IShellItem of the file in which encryption information will be lost.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following specific Shell codes, or a system error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>COPYENGINE_S_YES</term>
		/// <term>User responded "Yes" to the dialog. Copy continues without encryption.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_USER_IGNORED</term>
		/// <term>User responded "No" to the dialog.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_PENDING</term>
		/// <term>Error has been queued and will display later. Operation on this file will be skipped.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransferadvisesink-confirmencryptionloss
		// HRESULT ConfirmEncryptionLoss( IShellItem *psiSource );
		[PreserveSig]
		HRESULT ConfirmEncryptionLoss(IShellItem psiSource);

		/// <summary>Called when there is a failure and user interaction is needed.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>The IShellItem on which the operation failed.</para>
		/// </param>
		/// <param name="pszItem">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>
		/// Optional. A pointer to a null-terminated buffer that contains the name of the file. If this value is <c>NULL</c>, the name
		/// given by the psi parameter is used.
		/// </para>
		/// </param>
		/// <param name="hrError">
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The error code generated by the failure. This error must be handled by the copy engine.</para>
		/// </param>
		/// <param name="pszRename">
		/// <para>Type: <c>PWSTR</c></para>
		/// <para>
		/// Optional. When this method returns, contains a pointer to a null-terminated buffer that contains a new name for the file.
		/// The name cannot exceed length cchRename. If this parameter is <c>NULL</c>, no option to rename will be available.
		/// </para>
		/// </param>
		/// <param name="cchRename">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The size of the pszRenamebuffer, in characters.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Any other <c>HRESULT</c> should be returned to the calling process. If the failure is not handled, the return value should
		/// be hrError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>COPYENGINE_S_USER_RETRY</term>
		/// <term>The user clicked Retry. The handler should retry the file operation.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_E_USERCANCELLED</term>
		/// <term>
		/// The user clicked Cancel. The entire copy job is being terminated. The handler should return this code back to the copy engine.
		/// </term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_USER_IGNORED</term>
		/// <term>The user clicked Ignore. The handler should skip creating the item and return this code back to the copy engine.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransferadvisesink-filefailure HRESULT
		// FileFailure( IShellItem *psi, LPCWSTR pszItem, HRESULT hrError, PWSTR pszRename, ULONG cchRename );
		[PreserveSig]
		HRESULT FileFailure(IShellItem psi, [MarshalAs(UnmanagedType.LPWStr)] string? pszItem, HRESULT hrError, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder? pszRename, uint cchRename);

		/// <summary>Called when there is a failure that involves secondary streams and user interaction is needed.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem that caused the failure.</para>
		/// </param>
		/// <param name="pszStreamName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The name of the data that will be lost in the operation.</para>
		/// </param>
		/// <param name="hrError">
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The error code that was generated. It must be handled by the copy engine.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Any other <c>HRESULT</c> should be passed up. If the failure is not handled, the return value should be hrError.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>COPYENGINE_S_USERRETRY</term>
		/// <term>The handler should retry the file operation.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_USERRETRYWITHNEWNAME</term>
		/// <term>The handler should retry the file operation using the name returned in the pszRename buffer.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_OVERWRITE</term>
		/// <term>The user has indicated that the handler should overwrite the existing file.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_RETRYWITHOUTSECURITY</term>
		/// <term>The user has indicated that the handler should try the operation again without the security descriptor.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_E_USERCANCELLED</term>
		/// <term>
		/// The user clicked Cancel. The entire copy job is being terminated. The handler should return this code back to the copy engine.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransferadvisesink-substreamfailure
		// HRESULT SubStreamFailure( IShellItem *psi, LPCWSTR pszStreamName, HRESULT hrError );
		[PreserveSig]
		HRESULT SubStreamFailure(IShellItem psi, [MarshalAs(UnmanagedType.LPWStr)] string pszStreamName, HRESULT hrError);

		/// <summary>Called when there is a failure that involves file properties and user interaction is needed.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem that caused the failure.</para>
		/// </param>
		/// <param name="pkey">
		/// <para>Type: <c>const PROPERTYKEY*</c></para>
		/// <para>
		/// A value that corresponds to the property that will be lost. A <c>NULL</c> value indicates that all properties were lost.
		/// </para>
		/// </param>
		/// <param name="hrError">
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The error code generated by the failure. It must be handled by the copy engine.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Any other <c>HRESULT</c> should be passed up. If the failure is not handled, the return value should be hrError.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>COPYENGINE_S_USERRETRY</term>
		/// <term>The handler should retry the file operation.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_USERRETRYWITHNEWNAME</term>
		/// <term>The handler should retry the file operation using the name returned in the pszRename buffer.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_OVERWRITE</term>
		/// <term>The user has indicated that the handler should overwrite the existing file.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_RETRYWITHOUTSECURITY</term>
		/// <term>The user has indicated that the handler should try the operation again without the security descriptor.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_E_USERCANCELLED</term>
		/// <term>
		/// The user clicked Cancel. The entire copy job is being terminated. The handler should return this code back to the copy engine.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransferadvisesink-propertyfailure HRESULT
		// PropertyFailure( IShellItem *psi, const PROPERTYKEY *pkey, HRESULT hrError );
		[PreserveSig]
		unsafe HRESULT PropertyFailure(IShellItem psi, [In, Optional] Ole32.PROPERTYKEY* pkey, HRESULT hrError);
	}

	/// <summary>
	/// Exposes methods that create a destination Shell item for a copy or move operation. This interface is provided to allow more
	/// control over file operations by providing an ITransferDestination::Advise method.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-itransferdestination
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.ITransferDestination")]
	[ComImport, Guid("48addd32-3ca5-4124-abe3-b5a72531b207"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITransferDestination
	{
		/// <summary>Sets up an advisory connection for notifications on the status of file operations.</summary>
		/// <param name="psink">
		/// <para>Type: <c>ITransferAdviseSink*</c></para>
		/// <para>
		/// A pointer to an ITransferAdviseSink notification interface to update the calling application using methods on this interface.
		/// </para>
		/// </param>
		/// <param name="pdwCookie">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// A pointer to a returned token that uniquely identifies this connection. The calling application uses this token later to
		/// delete the connection by passing it to the ITransferDestination::Unadvise method. If the connection is not successfully
		/// established, this value is zero.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Any HRESULTs other than listed indicate a failure.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The Interface successfully associated.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The handler can only handle one sink interface.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Call <c>ITransferDestination::Advise</c> before calling any other ITransferDestination methods so the handler can callback
		/// for any errors that might occur. If not set, the handler should consider it an indication that no feedback is available and
		/// do the "default" operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransferdestination-advise HRESULT Advise(
		// ITransferAdviseSink *psink, DWORD *pdwCookie );
		[PreserveSig]
		HRESULT Advise([In] ITransferAdviseSink psink, out uint pdwCookie);

		/// <summary>Terminates an advisory connection.</summary>
		/// <param name="dwCookie">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A connection token previously returned from ITransferDestination::Advise. Identifies the connection to be terminated.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Any HRESULTs other than those listed here indicate a failure.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The connection was successfully terminated.</term>
		/// </item>
		/// <item>
		/// <term>CONNECT_E_NOCONNECTION</term>
		/// <term>The value in dwCookie does not represent a valid connection.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>Terminates an advisory connection previously established through the ITransferDestination::Advise method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransferdestination-unadvise HRESULT
		// Unadvise( DWORD dwCookie );
		[PreserveSig]
		HRESULT Unadvise(uint dwCookie);

		/// <summary>Creates the specified file.</summary>
		/// <param name="pszName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated buffer that contains the name of the file relative to the current directory.</para>
		/// </param>
		/// <param name="dwAttributes">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// One or more of the FILE_ATTRIBUTE flags defined in the BY_HANDLE_FILE_INFORMATION structure. The most significant value is
		/// FILE_ATTRIBUTE_DIRECTORY, which indicates that a folder should be created.
		/// </para>
		/// </param>
		/// <param name="ullSize">
		/// <para>Type: <c>ULONGLONG</c></para>
		/// <para>The size, in bytes, of the file to create. This value can be 0 if the size is unknown.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c>TRANSFER_SOURCE_FLAGS</c></para>
		/// <para>Flags that control the file operation. One or more of the TRANSFER_SOURCE_FLAGS flags.</para>
		/// </param>
		/// <param name="riidItem">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// A reference to the IID of the interface to retrieve through ppvItem, typically IID_IShellItem or another interface that
		/// derives from it.
		/// </para>
		/// </param>
		/// <param name="ppvItem">
		/// <para>Type: <c>void**</c></para>
		/// <para>
		/// When this method returns, contains the interface pointer requested in riidItem. This is typically IShellItem or a derived interface.
		/// </para>
		/// </param>
		/// <param name="riidResources">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// A reference to the IID of the interface to retrieve through ppvResources, typically IID_IShellItemResources or another
		/// interface that derives from it.
		/// </para>
		/// </param>
		/// <param name="ppvResources">
		/// <para>Type: <c>void**</c></para>
		/// <para>
		/// When this method returns, contains the interface pointer requested in riidResources. This is typically IShellItemResources
		/// or a derived interface.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns a success code if successful, or an error value otherwise. Success codes include:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>S_OK</c>: The move succeeded and ppvItem and ppvResources both point to valid objects.</term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>COPYENGINE_S_USER_IGNORED</c>: The destination item already exists and has not been overwritten. The values pointed to by
		/// ppvItem and ppvResources are <c>NULL</c>. If the caller is implementing a move as a copy and delete operation, the caller
		/// should complete the move by deleting the source item.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method may be used to create a Shell item object representing the destination folder for a copy or move operation. The
		/// ITransferSource interface provides methods to actually move objects of IShellItem to the destination.
		/// </para>
		/// <para>
		/// Call ITransferDestination::Advise before calling any other ITransferDestination methods so the handler can callback on any
		/// errors that might occur. If not set, the handler should consider it an indication that no feedback is available and to do
		/// the "default" operation.
		/// </para>
		/// <para>
		/// It is recommended that you use the <c>IID_PPV_ARGS</c> macro, defined in Objbase.h, to package the riidResources and
		/// ppvResources parameters. This macro provides the correct IID based on the interface pointed to by the value in ppvResources,
		/// which eliminates the possibility of a coding error.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransferdestination-createitem HRESULT
		// CreateItem( LPCWSTR pszName, DWORD dwAttributes, ULONGLONG ullSize, TRANSFER_SOURCE_FLAGS flags, REFIID riidItem, void
		// **ppvItem, REFIID riidResources, void **ppvResources );
		[PreserveSig, SuppressAutoGen]
		HRESULT CreateItem([MarshalAs(UnmanagedType.LPWStr)] string pszName, FileFlagsAndAttributes dwAttributes, ulong ullSize, TRANSFER_SOURCE_FLAGS flags, in Guid riidItem,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object? ppvItem, in Guid riidResources, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object? ppvResources);
	}

	/// <summary>
	/// Exposes methods to manipulate IShellItem, including copy, move, recycle, and others. This interface is offered to provide more
	/// control over file operations by providing an ITransferSource::Advise method.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-itransfersource
	[ComImport, Guid("00adb003-bde9-45c6-8e29-d09f9353e108"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITransferSource
	{
		/// <summary>Sets up an advisory connection for notifications on the status of file operations.</summary>
		/// <param name="psink">
		/// <para>Type: <c>ITransferAdviseSink*</c></para>
		/// <para>A pointer to notification interface ITransferAdviseSink to update the calling application using methods on this interface.</para>
		/// </param>
		/// <param name="pdwCookie">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// A pointer to a returned token that uniquely identifies this connection. The calling application uses this token later to
		/// delete the connection by passing it to the ITransferSource::Unadvise method. If the connection was not successfully
		/// established, this value is zero.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Any HRESULTs other than listed indicate a failure.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The Interface successfully associated.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The handler can only handle one sink interface.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Call <c>ITransferSource::Advise</c> before calling any other methods in this interface to enable an advisory session. If not
		/// set, the handler should consider it an indication that no feedback is available and to do the "default" operation without
		/// consulting the calling application.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransfersource-advise HRESULT Advise(
		// ITransferAdviseSink *psink, DWORD *pdwCookie );
		[PreserveSig]
		HRESULT Advise([In] ITransferAdviseSink psink, out uint pdwCookie);

		/// <summary>Terminates an advisory connection.</summary>
		/// <param name="dwCookie">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The connection token previously returned from method ITransferSource::Advise.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Any HRESULTs other than listed indicate a failure.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The connection was successfully terminated.</term>
		/// </item>
		/// <item>
		/// <term>CONNECT_E_NOCONNECTION</term>
		/// <term>The value in dwCookie does not represent a valid connection.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Terminates an advisory connection previously established through method ITransferSource::Advise. The dwCookie parameter
		/// identifies the connection to terminate.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransfersource-unadvise HRESULT Unadvise(
		// DWORD dwCookie );
		[PreserveSig]
		HRESULT Unadvise([In] uint dwCookie);

		/// <summary>Sets properties that should be applied to an item.</summary>
		/// <param name="pproparray">
		/// <para>Type: <c>IPropertyChangeArray*</c></para>
		/// <para>An array of properties and their changed values.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Any return value other than S_OK indicates a failure.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransfersource-setproperties HRESULT
		// SetProperties( IPropertyChangeArray *pproparray );
		[PreserveSig]
		HRESULT SetProperties([In] IPropertyChangeArray pproparray);

		/// <summary>Opens the item for copying. Returns an object that can be enumerated for resources (IShellItemResources).</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem to be opened.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c>TRANSFER_SOURCE_FLAGS</c></para>
		/// <para>The flags that control the file operation. One or more of the TRANSFER_SOURCE_FLAGS constants.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// A reference to the IID (the interface ID or GUID) of the interface to return in ppv. This should be an IShellItemResources
		/// or an interface derived from <c>IShellItemResources</c>.
		/// </para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the interface specified by riid.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful, or one of the following specific Shell codes, or a system error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>COPYENGINE_S_YES</term>
		/// <term>User responded "Yes" to the dialog.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_USER_RETRY</term>
		/// <term>User responded to retry the current action.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_USER_IGNORED</term>
		/// <term>User responded "No" to the dialog.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_MERGE</term>
		/// <term>User responded to merge folders.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_USER_RETRY_WITH_NEW_NAME</term>
		/// <term>User responded to retry the file with new name.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_DONT_PROCESS_CHILDREN</term>
		/// <term>Child items should not be processed.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_PENDING</term>
		/// <term>Error has been queued and will display later.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_E_USER_CANCELLED</term>
		/// <term>User canceled the current action.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_E_REQUIRES_ELEVATION</term>
		/// <term>Operation requires elevated privileges.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransfersource-openitem HRESULT OpenItem(
		// IShellItem *psi, TRANSFER_SOURCE_FLAGS flags, REFIID riid, void **ppv );
		[PreserveSig]
		HRESULT OpenItem([In] IShellItem psi, [In] TRANSFER_SOURCE_FLAGS flags, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppv);

		/// <summary>Moves the item within the volume/namespace, returning the IShellItem in its new location.</summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem to be moved.</para>
		/// </param>
		/// <param name="psiParentDst">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem that represents the new parent item at the destination.</para>
		/// </param>
		/// <param name="pszNameDst">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>Pointer to a null-terminated buffer that contains the destination path.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c>TRANSFER_SOURCE_FLAGS</c></para>
		/// <para>Flags that control the file operation. One or more of the TRANSFER_SOURCE_FLAGS constants.</para>
		/// </param>
		/// <param name="ppsiNew">
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>When this method returns successfully, contains an address of a pointer to the IShellItem in its new location.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns <c>S_OK</c> if the move succeeded. In that case, ppsiNew points to the address of the new item. Other possible
		/// return values, both success and failure codes, include the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>COPYENGINE_S_USER_IGNORED</term>
		/// <term>
		/// The destination item already exists and has not been overwritten. In this case, ppsiNew is NULL and the caller should delete
		/// the source item.
		/// </term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_MERGE</term>
		/// <term>
		/// The destination item already exists and the user has chosen to merge the source and destination folders. In this case,
		/// ppsiNew points to a NULL value and the caller should delete the source item.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>When the item being moved is a folder, the caller should convert a move operation into a copy and delete operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SAME_DEVICE</term>
		/// <term>The caller should convert a move operation into a copy and delete operation. This error is seen as .</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_EXISTS</term>
		/// <term>
		/// When moving a folder, the caller should convert the move operation into a copy and delete operation. The destination item
		/// must support ITransferDestination. This error is seen as .
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_ALREADY_EXISTS</term>
		/// <term>
		/// When moving a folder, the caller should convert the move operation into a copy and delete operation. The destination item
		/// must support ITransferDestination. This error is seen as .
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransfersource-moveitem HRESULT MoveItem(
		// IShellItem *psi, IShellItem *psiParentDst, LPCWSTR pszNameDst, TRANSFER_SOURCE_FLAGS flags, IShellItem **ppsiNew );
		[PreserveSig]
		HRESULT MoveItem([In] IShellItem psi, [In] IShellItem psiParentDst, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNameDst, TRANSFER_SOURCE_FLAGS flags, out IShellItem? ppsiNew);

		/// <summary>Recycle the item into the provided recycle location and return the item in its new location.</summary>
		/// <param name="psiSource">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem to be recycled.</para>
		/// </param>
		/// <param name="psiParentDest">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem of the recycle location (the new parent of the item).</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c>TRANSFER_SOURCE_FLAGS</c></para>
		/// <para>The flags that control the file operation. One or more of the TRANSFER_SOURCE_FLAGS constants.</para>
		/// </param>
		/// <param name="ppsiNewDest">
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>When the method returns, contains the address of a pointer to the recycled IShellItem.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following, or an error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>COPYENGINE_S_YES</term>
		/// <term>User responded "Yes" to the dialog.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_USER_RETRY</term>
		/// <term>User responded to retry the current action.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_USER_IGNORED</term>
		/// <term>User responded "No" to the dialog.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_DONT_PROCESS_CHILDREN</term>
		/// <term>Children items should not be processed.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_PENDING</term>
		/// <term>Error has been queued and will display later.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_E_USER_CANCELLED</term>
		/// <term>User canceled the current action.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_E_REQUIRES_ELEVATION</term>
		/// <term>Operation requires elevated privileges.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransfersource-recycleitem HRESULT
		// RecycleItem( IShellItem *psiSource, IShellItem *psiParentDest, TRANSFER_SOURCE_FLAGS flags, IShellItem **ppsiNewDest );
		[PreserveSig]
		HRESULT RecycleItem([In] IShellItem psiSource, [In] IShellItem psiParentDest, [In] TRANSFER_SOURCE_FLAGS flags, out IShellItem ppsiNewDest);

		/// <summary>Removes the item without moving the item to the Recycle Bin.</summary>
		/// <param name="psiSource">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem to be removed.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c>TRANSFER_SOURCE_FLAGS</c></para>
		/// <para>Flags that control the file operation. One or more of the TRANSFER_SOURCE_FLAGS constants.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following, or an error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>COPYENGINE_S_YES</term>
		/// <term>User responded "Yes" to the dialog</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_USER_RETRY</term>
		/// <term>User responded to retry the current action</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_USER_IGNORED</term>
		/// <term>User responded "No" to the dialog.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_MERGE</term>
		/// <term>User responded to merge folders.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_USER_RETRY_WITH_NEW_NAME</term>
		/// <term>User responded to retry the file with new name.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_DONT_PROCESS_CHILDREN</term>
		/// <term>Child items should not be processed.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_PENDING</term>
		/// <term>Error has been queued and will display later.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_E_USER_CANCELLED</term>
		/// <term>User canceled the current action.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_E_REQUIRES_ELEVATION</term>
		/// <term>Operation requires elevated privileges.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransfersource-removeitem HRESULT
		// RemoveItem( IShellItem *psiSource, TRANSFER_SOURCE_FLAGS flags );
		[PreserveSig]
		HRESULT RemoveItem([In] IShellItem psiSource, [In] TRANSFER_SOURCE_FLAGS flags);

		/// <summary>Changes the name of an item, returning the IShellItem with the new name.</summary>
		/// <param name="psiSource">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem object to be renamed.</para>
		/// </param>
		/// <param name="pszNewName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated, Unicode string containing the new name.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c>TRANSFER_SOURCE_FLAGS</c></para>
		/// <para>Flags that control the file operation. One or more of the TRANSFER_SOURCE_FLAGS constants.</para>
		/// </param>
		/// <param name="ppsiNewDest">
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the IShellItem object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following, or an error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>COPYENGINE_S_YES</term>
		/// <term>User responded "Yes" to the dialog.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_USER_RETRY</term>
		/// <term>User responded to retry the current action.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_USER_IGNORED</term>
		/// <term>User responded "No" to the dialog.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_MERGE</term>
		/// <term>User responded to merge folders.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_USER_RETRY_WITH_NEW_NAME</term>
		/// <term>User responded to retry the file with new name.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_DONT_PROCESS_CHILDREN</term>
		/// <term>Child items should not be processed.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_S_PENDING</term>
		/// <term>Error has been queued and will display later.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_E_USER_CANCELLED</term>
		/// <term>User canceled the current action.</term>
		/// </item>
		/// <item>
		/// <term>COPYENGINE_E_REQUIRES_ELEVATION</term>
		/// <term>Operation requires elevated privileges.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransfersource-renameitem HRESULT
		// RenameItem( IShellItem *psiSource, LPCWSTR pszNewName, TRANSFER_SOURCE_FLAGS flags, IShellItem **ppsiNewDest );
		[PreserveSig]
		HRESULT RenameItem([In] IShellItem psiSource, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName, [In] TRANSFER_SOURCE_FLAGS flags, out IShellItem ppsiNewDest);

		/// <summary>Not implemented.</summary>
		/// <param name="psiSource">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to an IShellItem that represents the source item.</para>
		/// </param>
		/// <param name="psiParentDest">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem as parent to link.</para>
		/// </param>
		/// <param name="pszNewName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated, Unicode string containing the name for the link.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The flags that control the file operation. Value is one or more of the TRANSFER_SOURCE_FLAGS constants.</para>
		/// </param>
		/// <param name="ppsiNewDest">
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>When the method returns, contains the address of a pointer to the IShellItem of the link.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransfersource-linkitem HRESULT LinkItem(
		// IShellItem *psiSource, IShellItem *psiParentDest, LPCWSTR pszNewName, TRANSFER_SOURCE_FLAGS flags, IShellItem **ppsiNewDest );
		[PreserveSig]
		HRESULT LinkItem([In] IShellItem psiSource, [In] IShellItem psiParentDest, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszNewName, [In] TRANSFER_SOURCE_FLAGS flags, out IShellItem ppsiNewDest);

		/// <summary>Apply a set of property changes to an item.</summary>
		/// <param name="psiSource">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem to be altered.</para>
		/// </param>
		/// <param name="ppsiNew">
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the changed IShellItem.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransfersource-applypropertiestoitem
		// HRESULT ApplyPropertiesToItem( IShellItem *psiSource, IShellItem **ppsiNew );
		[PreserveSig]
		HRESULT ApplyPropertiesToItem([In] IShellItem psiSource, out IShellItem ppsiNew);

		/// <summary>Gets the default name for a Shell item.</summary>
		/// <param name="psiSource">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem.</para>
		/// </param>
		/// <param name="psiParentDest">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the parent IShellItem of the destination target of the file operation.</para>
		/// </param>
		/// <param name="ppszDestinationName">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>When the method returns, contains a pointer to a null-terminated, Unicode string containing the default name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>Gets the default name for a Shell item, if different than the item's parsing name.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransfersource-getdefaultdestinationname
		// HRESULT GetDefaultDestinationName( IShellItem *psiSource, IShellItem *psiParentDest, PWSTR *ppszDestinationName );
		[PreserveSig]
		HRESULT GetDefaultDestinationName([In] IShellItem psiSource, [In] IShellItem psiParentDest, [MarshalAs(UnmanagedType.LPWStr)] out string ppszDestinationName);

		/// <summary>Notifies that a folder is the destination of a file operation.</summary>
		/// <param name="psiChildFolderDest">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem destination folder.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// This method is called when beginning to process a folder or subfolder in a recursive operation. For instance, when a source
		/// folder is copied to a destination folder, method <c>ITransferSource::EnterFolder</c> should be called with
		/// psiChildFolderDest set to the destination folder.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransfersource-enterfolder HRESULT
		// EnterFolder( IShellItem *psiChildFolderDest );
		[PreserveSig]
		HRESULT EnterFolder([In] IShellItem psiChildFolderDest);

		/// <summary>Sends notification that a folder is no longer the destination of a file operation.</summary>
		/// <param name="psiChildFolderDest">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the IShellItem destination folder.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>This method is called at the end of recursive file operations on a destination folder.</remarks>
		// https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/nf-shobjidl_core-itransfersource-leavefolder HRESULT
		// LeaveFolder( IShellItem *psiChildFolderDest );
		[PreserveSig]
		HRESULT LeaveFolder([In] IShellItem psiChildFolderDest);
	}
}