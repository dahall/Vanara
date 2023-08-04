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

	/// <summary>Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</summary>
	[ComImport, Guid("6d5140c1-7436-11ce-8034-00aa006009fa"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[PInvokeData("servprov.h")]
	public interface IServiceProvider
	{
		/// <summary>Performs as a factory for services that are exposed through an implementation of IServiceProvider.</summary>
		/// <param name="guidService">A unique identifier of the requested service.</param>
		/// <param name="riid">A unique identifier of the interface which the caller wishes to receive for the service.</param>
		/// <param name="ppvObject">The interface specified by the <paramref name="riid"/> parameter.</param>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PreserveSig]
		HRESULT QueryService(in Guid guidService, in Guid riid, out IntPtr ppvObject); //[MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)] out object ppvObject);
	}
}