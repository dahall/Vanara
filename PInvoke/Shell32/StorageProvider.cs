using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Provides a collection of properties associated with a file or folder.</summary>
	/// <remarks>
	/// <para><c>Caution</c>
	/// <para></para>
	/// You should only implement this interface if you have a specific need to do so.
	/// </para>
	/// <para>
	/// This interface can be implemented by a cloud storage provider sync engine to share properties about a file or file folder. An
	/// instance of <c>IStorageProviderPropertyHandler</c> exists for the lifetime of a storage file created under a sync root. Use
	/// IStorageProviderHandler to retrieve the set of properties associated with an individual file or folder.
	/// </para>
	/// <para>This interface is responsible for keeping track of the following properties:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>StorageProviderFileIdentifier</term>
	/// </item>
	/// <item>
	/// <term>StorageProviderFileRemoteUri</term>
	/// </item>
	/// <item>
	/// <term>StorageProviderFileChecksum</term>
	/// </item>
	/// <item>
	/// <term>StorageProviderFileVersionWaterline</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/storageprovider/nn-storageprovider-istorageproviderpropertyhandler
	[PInvokeData("storageprovider.h", MSDNShortId = "NN:storageprovider.IStorageProviderPropertyHandler")]
	[ComImport, Guid("301DFBE5-524C-4B0F-8B2D-21C40B3A2988"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IStorageProviderPropertyHandler
	{
		/// <summary>Gets the properties managed by the sync engine.</summary>
		/// <param name="propertiesToRetrieve">The identifier for the properties to retrieve.</param>
		/// <param name="propertiesToRetrieveCount">The number of properties to retrieve.</param>
		/// <param name="retrievedProperties">A collection of properties.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// If the file or folder cannot be found, this method should return <c>S_OK</c>, but <c>retrievedProperties</c> should be empty.
		/// </para>
		/// <para>Any properties that are not managed by the sync engine should return <c>VT_EMPTY</c> for those properties.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/storageprovider/nf-storageprovider-istorageproviderpropertyhandler-retrieveproperties
		// HRESULT RetrieveProperties( [in] const PROPERTYKEY *propertiesToRetrieve, [in] ULONG propertiesToRetrieveCount, [out]
		// IPropertyStore **retrievedProperties );
		[PreserveSig]
		HRESULT RetrieveProperties([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] PROPERTYKEY[] propertiesToRetrieve, uint propertiesToRetrieveCount, out IPropertyStore retrievedProperties);

		/// <summary>Saves properties associated with a file or folder.</summary>
		/// <param name="propertiesToSave">The properties to save.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>Attempting to save properties that are not managed by the sync engine should result in the error code <c>E_INVALIDARG</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/storageprovider/nf-storageprovider-istorageproviderpropertyhandler-saveproperties
		// HRESULT SaveProperties( [in] IPropertyStore *propertiesToSave );
		[PreserveSig]
		HRESULT SaveProperties(IPropertyStore propertiesToSave);
	}

	/// <summary>Retrieves the IStorageProviderPropertyHandler associated with a specific file or folder.</summary>
	/// <remarks>
	/// <c>Caution</c>
	/// <para></para>
	/// You should only implement this interface if you have a specific need to do so.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/storageprovider/nn-storageprovider-istorageproviderhandler
	[PInvokeData("storageprovider.h", MSDNShortId = "NN:storageprovider.IStorageProviderHandler")]
	[ComImport, Guid("162C6FB5-44D3-435B-903D-E613FA093FB5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IStorageProviderHandler
	{
		/// <summary>Gets an instance of IStorageProviderPropertyHandler associated with the provided path.</summary>
		/// <param name="path">The path for the relevant file.</param>
		/// <param name="propertyHandler">An IStorageProviderPropertyHandler instance associated with the file specified by <c>path</c>.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/storageprovider/nf-storageprovider-istorageproviderhandler-getpropertyhandlerfrompath
		// HRESULT GetPropertyHandlerFromPath( [in] LPCWSTR path, [out] IStorageProviderPropertyHandler **propertyHandler );
		[PreserveSig]
		HRESULT GetPropertyHandlerFromPath([MarshalAs(UnmanagedType.LPWStr)] string path, out IStorageProviderPropertyHandler propertyHandler);

		/// <summary>Gets an instance of IStorageProviderPropertyHandler associated with the provided URI.</summary>
		/// <param name="uri">The URI for the relevant file.</param>
		/// <param name="propertyHandler">An IStorageProviderPropertyHandler instance associated with the file specified by <c>uri</c>.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// This method is used to convert a remote URI to a local file system path. That path is then used to provide the
		/// <c>propertyHandler</c> to the local file.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/storageprovider/nf-storageprovider-istorageproviderhandler-getpropertyhandlerfromuri
		// HRESULT GetPropertyHandlerFromUri( [in] LPCWSTR uri, [out] IStorageProviderPropertyHandler **propertyHandler );
		[PreserveSig]
		HRESULT GetPropertyHandlerFromUri([MarshalAs(UnmanagedType.LPWStr)] string uri, out IStorageProviderPropertyHandler propertyHandler);

		/// <summary>Gets an instance of IStorageProviderPropertyHandler associated with the provided file identifier.</summary>
		/// <param name="fileId">The identifier for the relevant file.</param>
		/// <param name="propertyHandler">An IStorageProviderPropertyHandler instance associated with the file specified by <c>fileId</c>.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// This method is used to convert a file identifier to a local file system path. That path is then used to provide the
		/// <c>propertyHandler</c> to the local file.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/storageprovider/nf-storageprovider-istorageproviderhandler-getpropertyhandlerfromfileid
		// HRESULT GetPropertyHandlerFromFileId( [in] LPCWSTR fileId, [out] IStorageProviderPropertyHandler **propertyHandler );
		[PreserveSig]
		HRESULT GetPropertyHandlerFromFileId([MarshalAs(UnmanagedType.LPWStr)] string fileId, out IStorageProviderPropertyHandler propertyHandler);
	}
}