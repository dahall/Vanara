namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Exposes a general mechanism for objects to offer services to other objects on the same host.</summary>
	/// <remarks>Objects that expose a service first call QueryInterface on their host for this interface, then execute IProfferService::ProfferService.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iprofferservice
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IProfferService")]
	[ComImport, Guid("cb728b20-f786-11ce-92ad-00aa00a74cd0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IProfferService
	{
		/// <summary>Makes a service available to other objects on the same host.</summary>
		/// <param name="guidService">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>A value of type <c>GUID</c> that specifies the service being offered.</para>
		/// </param>
		/// <param name="psp">
		/// <para>Type: <c>IServiceProvider*</c></para>
		/// <para>A pointer to an IServiceProvider interface.</para>
		/// </param>
		/// <param name="pdwCookie">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// A pointer to a <c>DWORD</c> that receives an implementation-defined value used for identification purposes. The calling
		/// application must keep track of this value for possible use in IProfferService::RevokeService.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iprofferservice-profferservice HRESULT
		// ProfferService( REFGUID guidService, IServiceProvider *psp, DWORD *pdwCookie );
		void ProfferService(in Guid guidService, [In] IServiceProvider psp, out uint pdwCookie);

		/// <summary>Makes a service unavailable that had previously been available to other objects through IProfferService::ProfferService.</summary>
		/// <param name="dwCookie">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A value of type <c>DWORD</c> that specifies an implementation-defined value used for identification purposes. The calling
		/// application receives this value from IProfferService::ProfferService.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iprofferservice-revokeservice HRESULT
		// RevokeService( DWORD dwCookie );
		void RevokeService(uint dwCookie);
	}

	/// <summary>Provides a generic access mechanism to locate a GUID-identified service.</summary>
	/// <remarks>
	/// <para>
	/// The <c>IServiceProvider</c> interface is a generic access mechanism to locate a GUID-identified service that is provided through a
	/// control or any other object that the service can communicate with. For example, an embedded object (such as an OLE control)
	/// typically communicates only with its associated client site object in the container through the IOleClientSite interface that is
	/// supplied by using IOleObject::SetClientSite. The embedded object must ask the client site for some other service that the container
	/// supports when that service might not be implemented in the client site.
	/// </para>
	/// <para>
	/// The client site must provide a means by which the control that is managed by the site can access the service when necessary. For
	/// example, the IOleInPlaceSite::GetWindowContext) function can be used by an in-place object or control to access interface pointers
	/// for the document object that contains the site and the frame object that contains the document. Because these interface pointers
	/// exist on separate objects, the control cannot call the site's QueryInterface to obtain those pointers. Instead, use the
	/// IServiceProvider interface.
	/// </para>
	/// <para>
	/// The <c>IServiceProvider</c> interface has to overloads of a single method, QueryService, through which a caller specifies the
	/// service ID (SID, a GUID), the IID of the interface to return, and the address of the caller's interface pointer variable. The second
	/// overload infers the IID from the output pointer passed into the method.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/servprov/nn-servprov-iserviceprovider
	[PInvokeData("servprov.h", MSDNShortId = "NN:servprov.IServiceProvider")]
	[ComImport, Guid("6d5140c1-7436-11ce-8034-00aa006009fa"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[PInvokeData("servprov.h")]
	public interface IServiceProvider
	{
		/// <summary>
		/// <para>The unique identifier of the service (an SID).</para>
		/// <para>The unique identifier of the interface that the caller wants to receive for the service.</para>
		/// <para>
		/// The address of the caller-allocated variable to receive the interface pointer of the service on successful return from this
		/// function. The caller becomes responsible for calling Release through this interface pointer when the service is no longer required.
		/// </para>
		/// </summary>
		/// <param name="guidService">The unique identifier of the service (an SID).</param>
		/// <param name="riid">The unique identifier of the interface that the caller wants to receive for the service.</param>
		/// <param name="ppvObject">
		/// The address of the caller-allocated variable to receive the interface pointer of the service on successful return from this
		/// function. The caller becomes responsible for calling Release through this interface pointer when the service is no longer required.
		/// </param>
		/// <returns>S_OK on success.</returns>
		/// <remarks>
		/// <c>QueryService</c> creates or accesses the implementation of the service identified with guidService. In ppv, it returns the
		/// address of the interface that is specified by riid.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/servprov/nf-servprov-iserviceprovider-queryservice(refguid_refiid_void)
		// HRESULT QueryService( REFGUID guidService, REFIID riid, void **ppvObject );
		[PreserveSig]
		HRESULT QueryService(in Guid guidService, in Guid riid, out IntPtr ppvObject);
	}

	/// <summary>Performs as a factory for services that are exposed through an implementation of IServiceProvider.</summary>
	/// <typeparam name="T">The interface type which the caller wishes to receive for the service.</typeparam>
	/// <param name="this">The <see cref="IServiceProvider"/> instance.</param>
	/// <param name="guidService">A unique identifier of the requested service.</param>
	/// <returns>The interface specified by the <typeparamref name="T" /> parameter.</returns>
	public static T? QueryService<T>(this IServiceProvider @this, in Guid guidService) where T: class
	{
		var hr = @this.QueryService(guidService, typeof(T).GUID, out var ppv);
		return hr.Succeeded ? Marshal.GetObjectForIUnknown(ppv) as T : throw hr.GetException()!;
	}
}