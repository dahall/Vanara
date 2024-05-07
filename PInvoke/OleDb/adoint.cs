namespace Vanara.PInvoke;

public static partial class OleDb
{
	/// <summary>
	/// <para>
	/// <c>IADOConnectionConstruction</c> allows you to create an ADO connection from existing OLE DB objects. Using this interface is only
	/// feasible from C or C++ code that uses a mix of OLE DB and ADO. To do this, you typically create an empty ADO connection by using
	/// <c>CoCreateInstance</c>; query the object for the <c>IADOConnectionConstuction</c> interface; and then call <c>WrapDSOandSession</c>
	/// to initialize from an existing OLE DB data source object and session.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/aa965351(v=vs.85)
	[PInvokeData("adoint.h")]
	[ComImport, Guid("00000516-0000-0010-8000-00AA006D2EA4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IADOConnectionConstruction
	{
		/// <summary>Returns the underlying OLEDB Data Source object for this connection.</summary>
		/// <remarks>In the header file, this method is called ADOCommandConstruction::DSO.</remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/aa965468(v=vs.85) HRESULT get_DSO( IUnknown** ppDSO);
		[PreserveSig]
		HRESULT get_DSO([MarshalAs(UnmanagedType.IUnknown)] out object? ppDSO);

		/// <summary>Returns the underlying OLEDB Session for this connection.</summary>
		/// <remarks>In the header file, this method is called ADOCommandConstruction::Session.</remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/aa965359(v=vs.85) HRESULT get_Session( IUnknown** ppSession);
		[PreserveSig]
		HRESULT get_Session([MarshalAs(UnmanagedType.IUnknown)] out object? ppSession);

		/// <summary>Initializes a connection from an existing OLEDB Data Source object and Session.</summary>
		/// <param name="pDSO">[in] An interface pointer to the Data Source object. It must point to an IDBInitialize interface.</param>
		/// <param name="pSession">
		/// [in] An interface pointer to the Session object. It must be queryable for the ISessionProperties, IBindResource, and ICreateRow interfaces.
		/// </param>
		/// <remarks>In the header file, this method is called ADOCommandConstruction::WrapDSOandSession.</remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/aa965326(v=vs.85) HRESULT WrapDSOandSession( IUnknown* pDSO
		// IUnknown* pSession);
		[PreserveSig]
		HRESULT WrapDSOandSession([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pDSO, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pSession);
	}
}