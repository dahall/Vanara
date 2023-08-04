using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// Provides methods that enable you to set or retrieve a DataPackage object's IDataObject interface, which the DataPackage uses to
	/// support interoperability. The DataPackage object is used by an app to provide data to another app.
	/// </summary>
	/// <remarks>
	/// <para>When to implement</para>
	/// <para>Do not implement this interface. An implementation is provided as part of the DataPackage object.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-idataobjectprovider
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDataObjectProvider")]
	[ComImport, Guid("3D25F6D6-4B2A-433c-9184-7C33AD35D001"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDataObjectProvider
	{
		/// <summary>Gets an IDataObject representation of the current DataPackage object.</summary>
		/// <returns>
		/// <para>Type: <c>IDataObject**</c></para>
		/// <para>
		/// The address of an IDataObject interface pointer that, when this method returns successfully, points to the
		/// <c>IDataObject</c> representation of the DataPackage object.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idataobjectprovider-getdataobject HRESULT
		// GetDataObject( IDataObject **dataObject );
		IDataObject GetDataObject();

		/// <summary>Wraps an IDataObject instance as a Windows Runtime DataPackage.</summary>
		/// <param name="dataObject">An IDataObject interface pointer to the data object from which to build the DataPackage object.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idataobjectprovider-setdataobject HRESULT
		// SetDataObject( IDataObject *dataObject );
		void SetDataObject([In] IDataObject dataObject);
	}
}