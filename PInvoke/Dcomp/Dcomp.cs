global using System.Runtime.Versioning;
global using static Vanara.PInvoke.DXGI;
global using COMPOSITION_FRAME_ID = System.UInt64;

namespace Vanara.PInvoke;

/// <summary>Items from the Dcomp.dll.</summary>
[SupportedOSPlatform("windows8.0")]
public static partial class Dcomp
{
	internal const string Lib_Dcomp = "dcomp.dll";

	/// <summary>Creates a presentation factory.</summary>
	/// <param name="d3dDevice">
	/// <para>Type: <b><c>IUnknown</c>*</b></para>
	/// <para>The D3D device the presentation factory is bound to.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <b>REFIID</b></para>
	/// <para>A reference to the interface identifier (IID) of the presentation factory.</para>
	/// </param>
	/// <param name="presentationFactory">
	/// <para>Type: <b><c>void</c>**</b></para>
	/// <para>The address of a pointer to an interface with the IID specified in the riid parameter.</para>
	/// </param>
	// https://learn.microsoft.com/en-us/windows/win32/api/presentation/nf-presentation-createpresentationfactory HRESULT
	// CreatePresentationFactory( IUnknown *d3dDevice, REFIID riid, void **presentationFactory );
	[PInvokeData("presentation.h", MSDNShortId = "NF:presentation.CreatePresentationFactory")]
	[DllImport(Lib_Dcomp, SetLastError = false, ExactSpelling = true), DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	public static extern HRESULT CreatePresentationFactory([MarshalAs(UnmanagedType.IUnknown)] object d3dDevice, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object? presentationFactory);

	/// <summary>
	/// Creates an Interaction/InputSink to route mouse button down and any subsequent move and up events to the given HWND. There is no move
	/// thresholding; when enabled, all events including and following the down are unconditionally redirected to the specified window. After
	/// calling this API, the device owning the visual must be committed.
	/// </summary>
	/// <param name="visual">
	/// <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
	/// <para>The visual to route messages from.</para>
	/// </param>
	/// <param name="hwnd">
	/// <para>Type: <b>HWND</b></para>
	/// <para>The HWND to route messages to.</para>
	/// </param>
	/// <param name="enable">
	/// <para>Type: <b>BOOL</b></para>
	/// <para>Boolean value indicating whether to enable or disable routing.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>If this function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-dcompositionattachmousedragtohwnd HRESULT
	// DCompositionAttachMouseDragToHwnd( [in] IDCompositionVisual *visual, [in] HWND hwnd, [in] BOOL enable );
	[PInvokeData("dcomp.h", MSDNShortId = "NF:dcomp.DCompositionAttachMouseDragToHwnd")]
	[DllImport(Lib_Dcomp, SetLastError = false, ExactSpelling = true), DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	public static extern HRESULT DCompositionAttachMouseDragToHwnd([In] IDCompositionVisual visual, [In] HWND hwnd, [MarshalAs(UnmanagedType.Bool)] bool enable);

	/// <summary>
	/// Creates an Interaction/InputSink to route mouse wheel messages to the given HWND. This will fail if there is already an interaction
	/// attached to this visual. After calling this API, the device that owns the visual must be committed.
	/// </summary>
	/// <param name="visual">
	/// <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
	/// <para>The visual to route messages from.</para>
	/// </param>
	/// <param name="hwnd">
	/// <para>Type: <b>HWND</b></para>
	/// <para>The HWND to route messages to.</para>
	/// </param>
	/// <param name="enable">
	/// <para>Type: <b>BOOL</b></para>
	/// <para>Boolean value indicating whether to enable or disable routing.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>If this function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-dcompositionattachmousewheeltohwnd HRESULT
	// DCompositionAttachMouseWheelToHwnd( [in] IDCompositionVisual *visual, [in] HWND hwnd, [in] BOOL enable );
	[PInvokeData("dcomp.h", MSDNShortId = "NF:dcomp.DCompositionAttachMouseWheelToHwnd")]
	[DllImport(Lib_Dcomp, SetLastError = false, ExactSpelling = true), DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	public static extern HRESULT DCompositionAttachMouseWheelToHwnd([In] IDCompositionVisual visual, [In] HWND hwnd, [MarshalAs(UnmanagedType.Bool)] bool enable);

	/// <summary>Requests that the system dynamically switch to a higher refresh rate to enhance latency-sensitive content.</summary>
	/// <param name="enable">
	/// Type: <b><c>BOOL</c></b>
	/// <para><see langword="true"/> to request that the system dynamically switch to a higher refresh rate; otherwise, <see langword="false"/>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>; otherwise, it returns an <c>HRESULT</c> value that indicates the error.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-dcompositionboostcompositorclock HRESULT
	// DCompositionBoostCompositorClock( BOOL enable );
	[PInvokeData("dcomp.h", MSDNShortId = "NF:dcomp.DCompositionBoostCompositorClock")]
	[DllImport(Lib_Dcomp, SetLastError = false, ExactSpelling = true), DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	public static extern HRESULT DCompositionBoostCompositorClock([MarshalAs(UnmanagedType.Bool)] bool enable);

	/// <summary>Creates a new device object that can be used to create other Microsoft DirectComposition objects.</summary>
	/// <param name="dxgiDevice">
	/// <para>Type: <b><c>IDXGIDevice</c>*</b></para>
	/// <para>The DXGI device to use to create DirectComposition surface objects.</para>
	/// </param>
	/// <param name="iid">
	/// <para>Type: <b>REFIID</b></para>
	/// <para>The identifier of the interface to retrieve.</para>
	/// </param>
	/// <param name="dcompositionDevice">
	/// <para>Type: <b>void**</b></para>
	/// <para>
	/// Receives an interface pointer to the newly created device object. The pointer is of the type specified by the <i>iid</i> parameter.
	/// This parameter must not be NULL.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>
	/// If the function succeeds, it returns S_OK. Otherwise, it returns an <b>HRESULT</b> error code. See <c>DirectComposition Error
	/// Codes</c> for a list of error codes.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A device object serves as the factory for all other DirectComposition objects. It also controls transactional composition through the
	/// <c>IDCompositionDevice::Commit</c> method.
	/// </para>
	/// <para>
	/// The DXGI device specified by <i>dxgiDevice</i> is used to create all DirectComposition surface objects. In particular, the
	/// <c>IDCompositionSurface::BeginDraw</c> method returns an interface pointer to a DXGI surface that belongs to the device specified by
	/// the <i>dxgiDevice</i> parameter.
	/// </para>
	/// <para>
	/// When creating the DXGI device, developers must specify the <c>D3D11_CREATE_DEVICE BGRA_SUPPORT</c> or
	/// <c>D3D10_CREATE_DEVICE_BGRA_SUPPORT</c> flag for Direct2D interoperability with Microsoft Direct3D resources.
	/// </para>
	/// <para>
	/// The <i>iid</i> parameter must be <c>__uuidof(IDCompositionDevice)</c>, and the <i>dcompositionDevice</i> parameter receives a pointer
	/// to an <c>IDCompositionDevice</c> interface.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows how to create a device object as part of initialing DirectComposition objects.</para>
	/// <para>
	/// <c>#include &lt;dcomp.h&gt; #include &lt;d3d11.h&gt; HRESULT InitializeDirectCompositionDevice(HWND hwndTarget, ID3D11Device
	/// **ppD3D11Device, IDCompositionDevice **ppDevice, IDCompositionTarget **ppCompTarget) { HRESULT hr = S_OK; D3D_FEATURE_LEVEL
	/// featureLevelSupported; IDXGIDevice *pDXGIDevice = nullptr; // Verify that the arguments are valid. if (hwndTarget == NULL ||
	/// ppD3D11Device == nullptr || ppDevice == nullptr || ppCompTarget == nullptr) { return E_INVALIDARG; } // Create the D3D device object.
	/// Note that the // D3D11_CREATE_DEVICE_BGRA_SUPPORT flag is needed for rendering // on surfaces using Direct2D. hr = D3D11CreateDevice(
	/// nullptr, D3D_DRIVER_TYPE_HARDWARE, NULL, D3D11_CREATE_DEVICE_BGRA_SUPPORT, // needed for rendering on surfaces using Direct2D NULL,
	/// 0, D3D11_SDK_VERSION, ppD3D11Device, &amp;featureLevelSupported, NULL); if (SUCCEEDED(hr)) { // Create the DXGI device used to create
	/// bitmap surfaces. hr = (*ppD3D11Device)-&gt;QueryInterface(&amp;pDXGIDevice); } if (SUCCEEDED(hr)) { // Create the DirectComposition
	/// device object. hr = DCompositionCreateDevice(pDXGIDevice, __uuidof(IDCompositionDevice), reinterpret_cast&lt;void **&gt;(ppDevice));
	/// } if (SUCCEEDED(hr)) { // Bind the DirectComposition device to the target window. hr =
	/// (*ppDevice)-&gt;CreateTargetForHwnd(hwndTarget, TRUE, ppCompTarget); } return hr; }</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-dcompositioncreatedevice HRESULT DCompositionCreateDevice( [in]
	// IDXGIDevice *dxgiDevice, [in] REFIID iid, [out] void **dcompositionDevice );
	[PInvokeData("dcomp.h", MSDNShortId = "NF:dcomp.DCompositionCreateDevice")]
	[DllImport(Lib_Dcomp, SetLastError = false, ExactSpelling = true), DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	public static extern HRESULT DCompositionCreateDevice([In, Optional] IDXGIDevice? dxgiDevice, in Guid iid, [MarshalAs(UnmanagedType.IUnknown)] out object? dcompositionDevice);

	/// <summary>Creates a new device object that can be used to create other Microsoft DirectComposition objects.</summary>
	/// <typeparam name="T">The type of the interface to return in <paramref name="dcompositionDevice"/>.</typeparam>
	/// <param name="dxgiDevice"><para>Type: <b><c>IDXGIDevice</c>*</b></para>
	/// <para>The DXGI device to use to create DirectComposition surface objects.</para></param>
	/// <param name="dcompositionDevice"><para>Type: <b>void**</b></para>
	/// <para>
	/// Receives an interface pointer to the newly created device object. The pointer is of the type specified by the <i>iid</i> parameter.
	/// This parameter must not be NULL.
	/// </para></param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>
	/// If the function succeeds, it returns S_OK. Otherwise, it returns an <b>HRESULT</b> error code. See <c>DirectComposition Error
	/// Codes</c> for a list of error codes.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A device object serves as the factory for all other DirectComposition objects. It also controls transactional composition through the
	/// <c>IDCompositionDevice::Commit</c> method.
	/// </para>
	/// <para>
	/// The DXGI device specified by <i>dxgiDevice</i> is used to create all DirectComposition surface objects. In particular, the
	/// <c>IDCompositionSurface::BeginDraw</c> method returns an interface pointer to a DXGI surface that belongs to the device specified by
	/// the <i>dxgiDevice</i> parameter.
	/// </para>
	/// <para>
	/// When creating the DXGI device, developers must specify the <c>D3D11_CREATE_DEVICE BGRA_SUPPORT</c> or
	/// <c>D3D10_CREATE_DEVICE_BGRA_SUPPORT</c> flag for Direct2D interoperability with Microsoft Direct3D resources.
	/// </para>
	/// <para>
	/// The <i>iid</i> parameter must be <c>__uuidof(IDCompositionDevice)</c>, and the <i>dcompositionDevice</i> parameter receives a pointer
	/// to an <c>IDCompositionDevice</c> interface.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-dcompositioncreatedevice HRESULT DCompositionCreateDevice( [in]
	// IDXGIDevice *dxgiDevice, [in] REFIID iid, [out] void **dcompositionDevice );
	[PInvokeData("dcomp.h", MSDNShortId = "NF:dcomp.DCompositionCreateDevice")]
	public static HRESULT DCompositionCreateDevice<T>([In, Optional] IDXGIDevice? dxgiDevice, out T? dcompositionDevice) where T : class
	{
		var hr = DCompositionCreateDevice(dxgiDevice, typeof(T).GUID, out var ptr);
		dcompositionDevice = hr.Succeeded ? ptr as T : null;
		return hr;
	}

	/// <summary>Creates a new device object that can be used to create other Microsoft DirectComposition objects.</summary>
	/// <param name="renderingDevice">
	/// An optional pointer to a DirectX device to be used to create DirectComposition surface objects. Must be a pointer to an object
	/// implementing the <c>IDXGIDevice</c> or <c>ID2D1Device</c> interfaces.
	/// </param>
	/// <param name="iid">The identifier of the interface to retrieve. This must be one of __uuidof(IDCompositionDevice) or __uuidof(IDCompositionDesktopDevice).</param>
	/// <param name="dcompositionDevice">
	/// Receives an interface pointer to the newly created device object. The pointer is of the type specified by the <i>iid</i> parameter.
	/// This parameter must not be NULL.
	/// </param>
	/// <returns>
	/// If the function succeeds, it returns S_OK. Otherwise, it returns an <b>HRESULT</b> error code. See <c>DirectComposition Error
	/// Codes</c> for a list of error codes.
	/// </returns>
	/// <remarks>
	/// <para>
	/// A device object serves as the factory for all other DirectComposition objects. It also controls transactional composition through the
	/// IDCompositionDevice2::Commit method.
	/// </para>
	/// <para>
	/// The <i>renderingDevice</i> parameter may point to a <c>DXGI</c>, Direct3D, Direct2D device object, or it may be NULL. This parameter
	/// affects the behavior of the IDCompositionDevice2::CreateSurface, IDCompositionDevice2::CreateVirtualSurface and
	/// IDCompositionSurface::BeginDraw methods.
	/// </para>
	/// <para>
	/// If the <i>renderingDevice</i> parameter is NULL then the returned DirectComposition device cannot directly create DirectComposition
	/// surface objects. In particular, IDCompositionDevice2::CreateSurface and IDCompositionDevice2::CreateVirtualSurface methods return
	/// E_INVALIDARG, regardless of the supplied parameters. However, such a DirectComposition device object can still be used to indirectly
	/// create surfaces if the application creates a surface factory object via the IDCompositionDevice2::CreateSurfaceFactory method.
	/// </para>
	/// <para>
	/// If the <i>renderingDevice</i> parameter points to a DXGI device, that device is used to allocate all video memory needed by the
	/// IDCompositionDevice2::CreateSurface and IDCompositionDevice2::CreateVirtualSurface methods. Moreover, the
	/// IDCompositionSurface::BeginDraw method returns an interface pointer to a DXGI surface that belongs to that same DXGI device.
	/// </para>
	/// <para>
	/// If the <i>renderingDevice</i> parameter points to a Direct2D device object, DirectComposition extracts from it the underlying DXGI
	/// device object and uses it as if that DXGI device object had been passed in as the <i>renderingDevice</i> parameter. However, passing
	/// in a Direct2D object further causes IDCompositionSurface::BeginDraw to accept __uuidof(ID2D1DeviceContext) for its <i>iid</i>
	/// parameter for any objects created with the IDCompositionDevice2::CreateSurface or IDCompositionDevice2::CreateVirtualSurface methods.
	/// In that case, the Direct2D device context object returned by IDCompositionSurface::BeginDraw will belong to the same Direct2D device
	/// passed as the <i>renderingDevice</i> parameter.
	/// </para>
	/// <para>
	/// If the <i>iid</i> parameter is __uuidof(IDCompositionDevice), then the dcompositionDevice parameter receives a pointer to a Version 1
	/// IDCompositionDevice interface, but the underlying object is a Version 2 desktop device object. The application can later obtain a
	/// pointer to either the IDCompositionDevice2 or IDCompositionDesktopDevice interfaces by calling the <c>QueryInterface</c> method on
	/// that device. Similarly, all DirectComposition objects created from such a device are Version 2 objects under the covers. For example,
	/// the IDCompositionDevice::CreateVisual method will return an IDCompositionVisual interface to the created visual, but the application
	/// can obtain a pointer to the IDCompositionVisual2 interface via the QueryInterface method. This behavior allows an application written
	/// to the DirectComposition V1 API to incrementally adopt DirectComposition V2 features by changing the device creation method from
	/// DCompositionCreateDevice to DCompositionCreateDevice2, while still requesting the IDCompositionDevice2 interface. This allows the
	/// rest of the code to remain unchanged, while allowing the application to use QueryInterface in just the places where new functionality
	/// is needed.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-dcompositioncreatedevice2 HRESULT DCompositionCreateDevice2( [in,
	// optional] IUnknown *renderingDevice, [in] REFIID iid, [out] void **dcompositionDevice );
	[PInvokeData("dcomp.h", MSDNShortId = "NF:dcomp.DCompositionCreateDevice2")]
	[DllImport(Lib_Dcomp, SetLastError = false, ExactSpelling = true), DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	[SupportedOSPlatform("windows8.1")]
	public static extern HRESULT DCompositionCreateDevice2([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? renderingDevice, in Guid iid, [MarshalAs(UnmanagedType.IUnknown)] out object? dcompositionDevice);

	/// <summary>Creates a new DirectComposition device object, which can be used to create other DirectComposition objects.</summary>
	/// <param name="renderingDevice">
	/// <para>Type: <b>IUnknown*</b></para>
	/// <para>
	/// An optional pointer to a DirectX device to be used to create DirectComposition surface objects. Must be a pointer to an object
	/// implementing the <c>IDXGIDevice</c> or <c>ID2D1Device</c> interfaces.
	/// </para>
	/// </param>
	/// <param name="iid">
	/// <para>Type: <b>REFIID</b></para>
	/// <para>The identifier of the interface to retrieve. This must be one of __uuidof(IDCompositionDevice) or __uuidof(IDCompositionDesktopDevice).</para>
	/// </param>
	/// <param name="dcompositionDevice">
	/// <para>Type: <b>void**</b></para>
	/// <para>
	/// Receives an interface pointer to the newly created device object. The pointer is of the type specified by the <i>iid</i> parameter.
	/// This parameter must not be NULL.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>If this function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-dcompositioncreatedevice3 HRESULT DCompositionCreateDevice3( [in,
	// optional] IUnknown *renderingDevice, [in] REFIID iid, [out] void **dcompositionDevice );
	[PInvokeData("dcomp.h", MSDNShortId = "NF:dcomp.DCompositionCreateDevice3")]
	[DllImport(Lib_Dcomp, SetLastError = false, ExactSpelling = true), DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	[SupportedOSPlatform("windows10.0")]
	public static extern HRESULT DCompositionCreateDevice3([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? renderingDevice, in Guid iid, [MarshalAs(UnmanagedType.IUnknown)] out object? dcompositionDevice);

	/// <summary>
	/// Creates a new composition surface object that can be bound to a Microsoft DirectX swap chain or swap buffer and associated with a visual.
	/// </summary>
	/// <param name="desiredAccess">
	/// <para>Type: <b><c>DWORD</c></b></para>
	/// <para>The requested access to the composition surface object. It can be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description>0x0000L</description>
	/// <description>No access.</description>
	/// </item>
	/// <item>
	/// <description><b>COMPOSITIONOBJECT_READ</b> 0x0001L</description>
	/// <description>Read access. For internal use only.</description>
	/// </item>
	/// <item>
	/// <description><b>COMPOSITIONOBJECT_WRITE</b> 0x0002L</description>
	/// <description>Write access. For internal use only.</description>
	/// </item>
	/// <item>
	/// <description><b>COMPOSITIONOBJECT_ALL_ACCESS</b> 0x0003L</description>
	/// <description>
	/// Read/write access. Always specify this flag except when duplicating a surface in another process, in which case set
	/// <i>desiredAccess</i> to 0.
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="securityAttributes">
	/// <para>Type: <b><c>SECURITY_ATTRIBUTES</c>*</b></para>
	/// <para>
	/// Contains the security descriptor for the composition surface object, and specifies whether the handle of the composition surface
	/// object is inheritable when a child process is created. If this parameter is NULL, the composition surface object is created with
	/// default security attributes that grant read and write access to the current process, but do not enable child processes to inherit the handle.
	/// </para>
	/// </param>
	/// <param name="surfaceHandle">
	/// <para>Type: <b><c>HANDLE</c>*</b></para>
	/// <para>The handle of the new composition surface object. This parameter must not be NULL.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>
	/// If the function succeeds, it returns S_OK. Otherwise, it returns an <b>HRESULT</b> error code. See <c>DirectComposition Error
	/// Codes</c> for a list of error codes.
	/// </para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-dcompositioncreatesurfacehandle HRESULT
	// DCompositionCreateSurfaceHandle( [in] DWORD desiredAccess, [in, optional] SECURITY_ATTRIBUTES *securityAttributes, [out] HANDLE
	// *surfaceHandle );
	[PInvokeData("dcomp.h", MSDNShortId = "NF:dcomp.DCompositionCreateSurfaceHandle")]
	[DllImport(Lib_Dcomp, SetLastError = false, ExactSpelling = true), DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	public static extern HRESULT DCompositionCreateSurfaceHandle(COMPOSITIONOBJECT_ACCESS desiredAccess, [In, Optional] SECURITY_ATTRIBUTES? securityAttributes, out HANDLE surfaceHandle);

	/// <summary>Gets the identifier of the most recent compositor frame of the specified type.</summary>
	/// <param name="frameIdType">
	/// <para>Type: <b><c>COMPOSITION_FRAME_ID_TYPE</c></b></para>
	/// <para>The type of the compositor frame.</para>
	/// </param>
	/// <param name="frameId">
	/// <para>Type: <b>COMPOSITION_FRAME_ID*</b></para>
	/// <para>The identifer of the most recent compositor frame of the specified type.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>; otherwise, it returns an <c>HRESULT</c> value that indicates the error.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-dcompositiongetframeid HRESULT DCompositionGetFrameId(
	// COMPOSITION_FRAME_ID_TYPE frameIdType, COMPOSITION_FRAME_ID *frameId );
	[PInvokeData("dcomp.h", MSDNShortId = "NF:dcomp.DCompositionGetFrameId")]
	[DllImport(Lib_Dcomp, SetLastError = false, ExactSpelling = true), DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	public static extern HRESULT DCompositionGetFrameId(COMPOSITION_FRAME_ID_TYPE frameIdType, out COMPOSITION_FRAME_ID frameId);

	/// <summary>Gets basic information about the composition frame and a list of render target ID's that are part of the frame.</summary>
	/// <param name="frameId">
	/// <para>Type: <b>COMPOSITION_FRAME_ID</b></para>
	/// <para>The identifier of the composition frame about which to get information.</para>
	/// </param>
	/// <param name="frameStats">
	/// <para>Type: <b><c>COMPOSITION_FRAME_STATS</c>*</b></para>
	/// <para>A struct that contains information about the composition frame.</para>
	/// </param>
	/// <param name="targetIdCount">
	/// <para>Type: <b><c>UINT</c></b></para>
	/// <para>The number of render targets about which to get information.</para>
	/// </param>
	/// <param name="targetIds">
	/// <para>Type: <b><c>COMPOSITION_TARGET_ID</c>*</b></para>
	/// <para>The identifiers of the render targets about which to get information.</para>
	/// </param>
	/// <param name="actualTargetIdCount">
	/// <para>Type: <b><c>UINT</c>*</b></para>
	/// <para>The actual number of render targets.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>; otherwise, it returns an <c>HRESULT</c> value that indicates the error.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-dcompositiongetstatistics HRESULT DCompositionGetStatistics(
	// COMPOSITION_FRAME_ID frameId, COMPOSITION_FRAME_STATS *frameStats, UINT targetIdCount, COMPOSITION_TARGET_ID *targetIds, UINT
	// *actualTargetIdCount );
	[PInvokeData("dcomp.h", MSDNShortId = "NF:dcomp.DCompositionGetStatistics")]
	[DllImport(Lib_Dcomp, SetLastError = false, ExactSpelling = true), DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	public static extern HRESULT DCompositionGetStatistics(COMPOSITION_FRAME_ID frameId, out COMPOSITION_FRAME_STATS frameStats, uint targetIdCount, [Out, MarshalAs(UnmanagedType.LPArray), Optional] COMPOSITION_TARGET_ID[]? targetIds, out uint actualTargetIdCount);

	/// <summary>Gets per-target information for the specified composition frame and render target.</summary>
	/// <param name="frameId">
	/// <para>Type: <b>COMPOSITION_FRAME_ID</b></para>
	/// <para>The identifier of the composition frame about which to get information.</para>
	/// </param>
	/// <param name="targetId">
	/// <para>Type: <b><c>COMPOSITION_TARGET_ID</c>*</b></para>
	/// <para>The identifier of the render target about which to get information.</para>
	/// </param>
	/// <param name="targetStats">
	/// <para>Type: <b><c>COMPOSITION_TARGET_STATS</c>*</b></para>
	/// <para>Information about the specified composition frame and render target.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>; otherwise, it returns an <c>HRESULT</c> value that indicates the error.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-dcompositiongettargetstatistics HRESULT
	// DCompositionGetTargetStatistics( COMPOSITION_FRAME_ID frameId, const COMPOSITION_TARGET_ID *targetId, COMPOSITION_TARGET_STATS
	// *targetStats );
	[PInvokeData("dcomp.h", MSDNShortId = "NF:dcomp.DCompositionGetTargetStatistics")]
	[DllImport(Lib_Dcomp, SetLastError = false, ExactSpelling = true), DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	public static extern HRESULT DCompositionGetTargetStatistics(COMPOSITION_FRAME_ID frameId, in COMPOSITION_TARGET_ID targetId, out COMPOSITION_TARGET_STATS targetStats);

	/// <summary>Halts a thread until the next signal from the compositor clock occurs.</summary>
	/// <param name="count">
	/// <para>Type: <b><c>UINT</c></b></para>
	/// <para>The number of <c>handles</c>.</para>
	/// </param>
	/// <param name="handles">
	/// <para>Type: <b><c>HANDLE</c>*</b></para>
	/// <para>Handles to events for which the compositor clock should send signals.</para>
	/// </param>
	/// <param name="timeoutInMs">
	/// <para>Type: <b><c>DWORD</c></b></para>
	/// <para>Amount of time in milliseconds to wait before the operation times out.</para>
	/// </param>
	/// <returns>Type: <b><c>DWORD</c></b></returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-dcompositionwaitforcompositorclock DWORD
	// DCompositionWaitForCompositorClock( UINT count, const HANDLE *handles, DWORD timeoutInMs );
	[PInvokeData("dcomp.h", MSDNShortId = "NF:dcomp.DCompositionWaitForCompositorClock")]
	[DllImport(Lib_Dcomp, SetLastError = false, ExactSpelling = true), DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	public static extern uint DCompositionWaitForCompositorClock(uint count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Optional] HANDLE[]? handles, uint timeoutInMs);
}