namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// Exposes a method to discover objects that are named with a <c>GUID</c> from another object. Unlike QueryService this interface
	/// will not delegate its functionality on to other objects.
	/// </summary>
	/// <remarks>
	/// Similar to IServiceProvider, except that this method does not imply that unhandled or unknown requests should be forwarded.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iobjectprovider
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IObjectProvider")]
	[ComImport, Guid("a6087428-3be3-4d73-b308-7c04a540bf1a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IObjectProvider
	{
		/// <summary>Queries for a specified object.</summary>
		/// <param name="guidObject">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>A reference to the <c>GUID</c> used to identify the object.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>Specifies the desired interface ID.</para>
		/// </param>
		/// <param name="ppvOut">
		/// <para>Type: <c>void**</c></para>
		/// <para>On success, contains the address of a pointer to the object specified by riid.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// Object implementers that want to enable the discovery of other objects that they can produce or that they hold should
		/// implement <c>IObjectProvider::QueryObject</c> and publish the <c>GUID</c> values that name those objects for clients of that
		/// object. Note that objects should not pass on the request for an object to other objects like QueryService.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iobjectprovider-queryobject HRESULT
		// QueryObject( REFGUID guidObject, REFIID riid, void **ppvOut );
		[PreserveSig]
		HRESULT QueryObject(in Guid guidObject, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvOut);
	}
}