using System.Runtime.InteropServices;
using static Vanara.PInvoke.D2d1;

namespace Vanara.PInvoke;

public static partial class Dcomp
{
	/// <summary>Serves as a factory for all other Microsoft DirectComposition objects and provides methods to control transactional composition.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositiondevice
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionDevice")]
	[ComImport, Guid("C37EA93A-E7AA-450D-B16F-9746CB0407F3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionDevice
	{
		/// <summary>Commits all DirectComposition commands that are pending on this device.</summary>
		/// <remarks>
		///   <para>Calls to DirectComposition methods are always batched and executed atomically as a single transaction. Calls take effect only when <b>IDCompositionDevice::Commit</b> is called, at which time all pending method calls for a device are executed at once.</para>
		///   <para>An application that uses multiple devices must call <b>Commit</b> for each device separately. However, because the composition engine processes the calls individually, the batch of commands might not take effect at the same time.</para>
		///   <para>Examples</para>
		///   <para>For an example, see <c>How to Build a Simple Visual Tree</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-commit
		// HRESULT Commit();
		void Commit();

		/// <summary>Waits for the composition engine to finish processing the previous call to the <c>IDCompositionDevice::Commit</c> method.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-waitforcommitcompletion
		// HRESULT WaitForCommitCompletion();
		void WaitForCommitCompletion();

		/// <summary>Retrieves information from the composition engine about composition times and the frame rate.</summary>
		/// <returns>
		///   <para>Type: <b><c>DCOMPOSITION_FRAME_STATISTICS</c>*</b></para>
		///   <para>A structure that receives composition times and frame rate information.</para>
		/// </returns>
		/// <remarks>This method retrieves timing information about the composition engine that an application can use to synchronize the rasterization of bitmaps with independent animations.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-getframestatistics
		// HRESULT GetFrameStatistics( [out] DCOMPOSITION_FRAME_STATISTICS *statistics );
		DCOMPOSITION_FRAME_STATISTICS GetFrameStatistics();

		/// <summary>Creates a composition target object that is bound to the window that is represented by the specified window handle (<c>HWND</c>).</summary>
		/// <param name="hwnd">
		/// <para>Type: <b><c>HWND</c></b></para>
		/// <para>The window to which the composition target object should be bound. This parameter must not be NULL.</para>
		/// </param>
		/// <param name="topmost">
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para>TRUE if the visual tree should be displayed on top of the children of the window specified by the <i>hwnd</i> parameter; otherwise, the visual tree is displayed behind the children.</para>
		/// </param>
		/// <param name="target">
		/// <para>Type: <b><c>IDCompositionTarget</c>**</b></para>
		/// <para>The new composition target object. This parameter must not be NULL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See <c>DirectComposition Error Codes</c> for a list of error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>A Microsoft DirectComposition visual tree must be bound to a window before anything can be displayed on screen. The window can be a top-level window or a child window. In either case, the window can be a layered window, but in all cases the window must belong to the calling process. If the window belongs to a different process, this method returns <c>DCOMPOSITION_ERROR_ACCESS_DENIED</c>.</para>
		/// <para>When DirectComposition content is composed to the window, the content is always composed on top of whatever is drawn directly to that window through the device context (<c>HDC</c>) returned by the <c>GetDC</c> function, or by calls to Microsoft DirectX <c>Present</c> methods. However, because window clipping rules apply to DirectComposition content, if the window has child windows, those child windows may clip the visual tree. The <i>topmost</i> parameter determines whether child windows clip the visual tree.</para>
		/// <para>Conceptually, each window consists of four layers:</para>
		/// <list type="number">
		/// <item>
		/// <description>The contents drawn directly to the window handle (this is the bottommost layer).</description>
		/// </item>
		/// <item>
		/// <description>An optional DirectComposition visual tree.</description>
		/// </item>
		/// <item>
		/// <description>The contents of all child windows, if any.</description>
		/// </item>
		/// <item>
		/// <description>Another optional DirectComposition visual tree (this is the topmost layer).</description>
		/// </item>
		/// </list>
		/// <para>All four layers are clipped to the window's visible region.</para>
		/// <para>At most, only two composition targets can be created for each window in the system, one topmost and one not topmost. If a composition target is already bound to the specified window at the specified layer, this method fails. When a composition target object is destroyed, the layer it composed is available for use by a new composition target object.</para>
		/// <para>Examples</para>
		/// <para>The following example creates and initializes a device object, and then binds the device object to a composition target window.</para>
		/// <para><c>#include &lt;dcomp.h&gt; #include &lt;d3d11.h&gt; HRESULT InitializeDirectCompositionDevice(HWND hwndTarget, ID3D11Device **ppD3D11Device, IDCompositionDevice **ppDevice, IDCompositionTarget **ppCompTarget) { HRESULT hr = S_OK; D3D_FEATURE_LEVEL featureLevelSupported; IDXGIDevice *pDXGIDevice = nullptr; // Verify that the arguments are valid. if (hwndTarget == NULL || ppD3D11Device == nullptr || ppDevice == nullptr || ppCompTarget == nullptr) { return E_INVALIDARG; } // Create the D3D device object. Note that the // D3D11_CREATE_DEVICE_BGRA_SUPPORT flag is needed for rendering // on surfaces using Direct2D. hr = D3D11CreateDevice( nullptr, D3D_DRIVER_TYPE_HARDWARE, NULL, D3D11_CREATE_DEVICE_BGRA_SUPPORT, // needed for rendering on surfaces using Direct2D NULL, 0, D3D11_SDK_VERSION, ppD3D11Device, &amp;featureLevelSupported, NULL); if (SUCCEEDED(hr)) { // Create the DXGI device used to create bitmap surfaces. hr = (*ppD3D11Device)-&gt;QueryInterface(&amp;pDXGIDevice); } if (SUCCEEDED(hr)) { // Create the DirectComposition device object. hr = DCompositionCreateDevice(pDXGIDevice, __uuidof(IDCompositionDevice), reinterpret_cast&lt;void **&gt;(ppDevice)); } if (SUCCEEDED(hr)) { // Bind the DirectComposition device to the target window. hr = (*ppDevice)-&gt;CreateTargetForHwnd(hwndTarget, TRUE, ppCompTarget); } return hr; } </c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createtargetforhwnd
		// HRESULT CreateTargetForHwnd( [in] HWND hwnd, [in] BOOL topmost, [out] IDCompositionTarget **target );
		[PreserveSig]
		HRESULT CreateTargetForHwnd([In] HWND hwnd, bool topmost, out IDCompositionTarget target);

		/// <summary>Creates a new visual object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionVisual</c>**</b></para>
		///   <para>The new visual object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A new visual object has a static value of zero for the OffsetX and OffsetY properties, and NULL for the Transform, Clip, and Content properties. Initially, the visual does not cause the contents of a window to change. The visual must be added as a child of another visual, or as the root of a composition target, before it can affect the appearance of a window.</para>
		///   <para>Examples</para>
		///   <para>For an example, see <c>How to Build a Simple Visual Tree</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createvisual
		// HRESULT CreateVisual( [out] IDCompositionVisual **visual );
		IDCompositionVisual CreateVisual();

		/// <summary>Creates an updateable surface object that can be associated with one or more visuals for composition.</summary>
		/// <param name="width">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The width of the surface, in pixels.</para>
		/// </param>
		/// <param name="height">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The height of the surface, in pixels.</para>
		/// </param>
		/// <param name="pixelFormat">
		///   <para>Type: <b><c>DXGI_FORMAT</c></b></para>
		///   <para>The pixel format of the surface.</para>
		/// </param>
		/// <param name="alphaMode">
		///   <para>Type: <b><c>DXGI_ALPHA_MODE</c></b></para>
		///   <para>The format of the alpha channel, if an alpha channel is included in the pixel format. It can be one of the following values:</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <b>DXGI_ALPHA_MODE_UNSPECIFIED</b>
		///       </description>
		///       <description>The alpha channel isn't specified. This value has the same effect as <b>DXGI_ALPHA_MODE_IGNORE</b>.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_ALPHA_MODE_PREMULTIPLIED</b>
		///       </description>
		///       <description>The color channels contain values that are premultiplied with the alpha channel.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_ALPHA_MODE_IGNORE</b>
		///       </description>
		///       <description>The alpha channel should be ignored, and the bitmap should be rendered opaquely.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionSurface</c>**</b></para>
		///   <para>The newly created surface object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A Microsoft DirectComposition surface is a rectangular array of pixels that can be associated with a visual for composition.</para>
		///   <para>A newly created surface object is in an uninitialized state. While it is uninitialized, the surface has no effect on the composition of the visual tree. It behaves exactly like a surface that has 100% transparent pixels.</para>
		///   <para>To initialize the surface with pixel data, use the <b>IDCompositionSurface::BeginDraw</b> method. The first call to this method must cover the entire surface area to provide an initial value for every pixel. Subsequent calls may specify smaller sub-rectangles of the surface to update.</para>
		///   <para>DirectComposition surfaces support the following pixel formats:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_B8G8R8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R8G8B8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R16G16B16A16_FLOAT</b>
		///       </description>
		///     </item>
		///   </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createsurface
		// HRESULT CreateSurface( [in] UINT width, [in] UINT height, [in] DXGI_FORMAT pixelFormat, [in] DXGI_ALPHA_MODE alphaMode, [out] IDCompositionSurface **surface );
		IDCompositionSurface CreateSurface(uint width, uint height, [In] DXGI_FORMAT pixelFormat, [In] DXGI_ALPHA_MODE alphaMode);

		/// <summary>Creates a sparsely populated surface that can be associated with one or more visuals for composition.</summary>
		/// <param name="initialWidth">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The width of the surface, in pixels. The maximum width is 16,777,216 pixels.</para>
		/// </param>
		/// <param name="initialHeight">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The height of the surface, in pixels. The maximum height is 16,777,216 pixels.</para>
		/// </param>
		/// <param name="pixelFormat">
		///   <para>Type: <b><c>DXGI_FORMAT</c></b></para>
		///   <para>The pixel format of the surface.</para>
		/// </param>
		/// <param name="alphaMode">
		///   <para>Type: <b><c>DXGI_ALPHA_MODE</c></b></para>
		///   <para>The meaning of the alpha channel, if the pixel format contains an alpha channel. It can be one of the following values:</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_UNSPECIFIED</b>
		///       </description>
		///       <description>The alpha channel is not specified. This value has the same effect as <b>DXGI_ALPHA_MODE_IGNORE</b>.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_PREMULTIPLIED</b>
		///       </description>
		///       <description>The color channels contain values that are premultiplied with the alpha channel.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_IGNORE</b>
		///       </description>
		///       <description>The alpha channel should be ignored and the bitmap should be rendered opaquely.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionVirtualSurface</c>**</b></para>
		///   <para>The newly created surface object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A Microsoft DirectComposition sparse surface is a logical object that behaves like a rectangular array of pixels that can be associated with a visual for composition. The surface is not necessarily backed by any physical video or system memory for every one of its pixels. The application can realize or virtualize parts of the logical surface at different times.</para>
		///   <para>A newly created surface object is in an uninitialized state. While it is uninitialized, the surface has no effect on the composition of the visual tree. It behaves exactly like a surface that is initialized with 100% transparent pixels.</para>
		///   <para>To initialize the surface with pixel data, use the <c>IDCompositionSurface::BeginDraw</c> method. This method not only provides pixels for the surface, but it also allocates actual storage space for those pixels. The memory allocation persists until the application returns some of the memory to the system. The application can free part or all of the allocated memory by calling the <c>IDComposition::VirtualSurfaceTrim</c> method.</para>
		///   <para>DirectComposition surfaces support the following pixel formats:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_B8G8R8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R8G8B8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R16G16B16A16_FLOAT</b>
		///       </description>
		///     </item>
		///   </list>
		///   <para>This method fails if <i>initialWidth</i> or <i>initialHeight</i> exceeds 16,777,216 pixels.</para>
		///   <para>Examples</para>
		///   <para>The following example shows how to create a virtual surface and associate it with a visual.</para>
		///   <para>
		///     <c>HRESULT RenderAVisual(IDCompositionDevice *pDCompDevice, HWND hwndTarget, UINT surfaceWidth, UINT surfaceHeight) { // Validate the input parameters. if (pDCompDevice == nullptr || hwndTarget == NULL) return E_INVALIDARG; HRESULT hr = S_OK; IDCompositionTarget *pTargetWindow = nullptr; IDCompositionVisual *pVisual = nullptr; IDCompositionVirtualSurface *pVirtualSurface = nullptr; ID3D10Texture2D *pTex2D = nullptr; POINT offset = {0}; // Create the rendering target. hr = pDCompDevice-&gt;CreateTargetForHwnd(hwndTarget, TRUE, &amp;pTargetWindow); if (SUCCEEDED(hr)) { // Create a visual. hr = pDCompDevice-&gt;CreateVisual(&amp;pVisual); } if (SUCCEEDED(hr)) { // Add the visual to the root of the composition tree. hr = pTargetWindow-&gt;SetRoot(pVisual); } if (SUCCEEDED(hr)) { // Create a virtual surface. hr = pDCompDevice-&gt;CreateVirtualSurface(surfaceWidth, surfaceHeight, DXGI_FORMAT_R8G8B8A8_UNORM, DXGI_ALPHA_MODE_IGNORE, &amp;pVirtualSurface); } if (SUCCEEDED(hr)) { // Set the virtual surface as the content of the visual. hr = pVisual-&gt;SetContent(pVirtualSurface); } if (SUCCEEDED(hr)) { // Retrieve and interface pointer for draw on the surface. hr = pVirtualSurface-&gt;BeginDraw(NULL, __uuidof(ID3D10Texture2D), (void **) &amp;pTex2D, &amp;offset); } // // TODO: Draw on the surface. // if (SUCCEEDED(hr)) { // Complete the updates to the surface. hr = pVirtualSurface-&gt;EndDraw(); } // Commit the composition for rendering. hr = pDCompDevice-&gt;Commit(); // Clean up. SafeRelease(&amp;pTargetWindow); SafeRelease(&amp;pVisual); SafeRelease(&amp;pVirtualSurface); SafeRelease(&amp;pTex2D); return hr; } </c>
		///   </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createvirtualsurface
		// HRESULT CreateVirtualSurface( [in] UINT initialWidth, [in] UINT initialHeight, [in] DXGI_FORMAT pixelFormat, [in] DXGI_ALPHA_MODE alphaMode, [out] IDCompositionVirtualSurface **virtualSurface );
		IDCompositionVirtualSurface CreateVirtualSurface(uint initialWidth, uint initialHeight, [In] DXGI_FORMAT pixelFormat, [In] DXGI_ALPHA_MODE alphaMode);

		/// <summary>Creates a new composition surface object that wraps an existing composition surface.</summary>
		/// <param name="handle">
		///   <para>Type: <b><c>HANDLE</c></b></para>
		///   <para>The handle of an existing composition surface that was created by a call to the <c>DCompositionCreateSurfaceHandle</c> function.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IUnknown</c>**</b></para>
		///   <para>The new composition surface object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>This method enables an application to use a shared composition surface in a composition tree.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createsurfacefromhandle
		// HRESULT CreateSurfaceFromHandle( [in] HANDLE handle, [out] IUnknown **surface );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object CreateSurfaceFromHandle([In] HANDLE handle);

		/// <summary>Creates a wrapper object that represents the rasterization of a layered window, and that can be associated with a visual for composition.</summary>
		/// <param name="hwnd">
		///   <para>Type: [in] <b><c>HWND</c></b></para>
		///   <para>The handle of the layered window for which to create a wrapper. A layered window is created by specifying <b>WS_EX_LAYERED</b> when creating the window with the <c>CreateWindowEx</c> function or by setting <b>WS_EX_LAYERED</b> via <c>SetWindowLong</c> after the window has been created.</para>
		/// </param>
		/// <returns>
		///   <para>Type: [out] <b><c>IUnknown</c>**</b></para>
		///   <para>The new composition surface object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>You can use the <i>surface</i> pointer in calls to the <c>IDCompositionVisual::SetContent</c> method to set the content of one or more visuals. After setting the content, the visuals compose the contents of the specified layered window as long as the window is layered. If the window is unlayered, the window content disappears from the output of the composition tree. If the window is later re-layered, the window content reappears as long as it is still associated with a visual.</para>
		///   <para>If the window is resized, the affected visuals are re-composed.</para>
		///   <para>The contents of the window are not cached beyond the life of the window. That is, if the window is destroyed, the affected visuals stop composing the window.</para>
		///   <para>If the window is moved off-screen or resized to zero, the system stops composing the content of visuals. You should use the <c>DwmSetWindowAttribute</c> function with the <b>DWMWA_CLOAK</b> flag to "cloak" the layered child window when you need to hide the original window while allowing the system to continue to compose the content of the visuals. For more information, see <c>How to animate the bitmap of a layered child window</c> and <c>DirectComposition layered child window sample</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createsurfacefromhwnd
		// HRESULT CreateSurfaceFromHwnd( HWND hwnd, IUnknown **surface );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object CreateSurfaceFromHwnd([In] HWND hwnd);

		/// <summary>Creates a 2D translation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTranslateTransform</c>**</b></para>
		///   <para>The new 2D translation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D translation transform object has a static value of zero for the OffsetX and OffsetY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createtranslatetransform
		// HRESULT CreateTranslateTransform( [out] IDCompositionTranslateTransform **translateTransform );
		IDCompositionTranslateTransform CreateTranslateTransform();

		/// <summary>Creates a 2D scale transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionScaleTransform</c>**</b></para>
		///   <para>The new 2D scale transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D scale transform object has a static value of zero for the ScaleX, ScaleY, CenterX, and CenterY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createscaletransform
		// HRESULT CreateScaleTransform( [out] IDCompositionScaleTransform **scaleTransform );
		IDCompositionScaleTransform CreateScaleTransform();

		/// <summary>Creates a 2D rotation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionRotateTransform</c>**</b></para>
		///   <para>The new rotation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D rotation transform object has a static value of zero for the Angle, CenterX, and CenterY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createrotatetransform
		// HRESULT CreateRotateTransform( [out] IDCompositionRotateTransform **rotateTransform );
		IDCompositionRotateTransform CreateRotateTransform();

		/// <summary>Creates a 2D skew transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionSkewTransform</c>**</b></para>
		///   <para>The new 2D skew transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D skew transform object has a static value of zero for the AngleX, AngleY, CenterX, and CenterY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createskewtransform
		// HRESULT CreateSkewTransform( [out] IDCompositionSkewTransform **skewTransform );
		IDCompositionSkewTransform CreateSkewTransform();

		/// <summary>Creates a 2D 3-by-2 matrix transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionMatrixTransform</c>**</b></para>
		///   <para>The new matrix transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A new matrix transform object has the identity matrix as its initial value. The identity matrix is the 3x2 matrix with ones on the main diagonal and zeros elsewhere, as shown in the following illustration.</para>
		///   <para>When an identity transform is applied to an object, it does not change the position, shape, or size of the object. It is similar to the way that multiplying a number by one does not change the number. Any transform other than the identity transform will modify the position, shape, and/or size of objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-creatematrixtransform
		// HRESULT CreateMatrixTransform( [out] IDCompositionMatrixTransform **matrixTransform );
		IDCompositionMatrixTransform CreateMatrixTransform();

		/// <summary>Creates a 2D transform group object that holds an array of 2D transform objects.</summary>
		/// <param name="transforms">
		///   <para>Type: <b><c>IDCompositionTransform</c>**</b></para>
		///   <para>An array of 2D transform objects that make up this transform group.</para>
		/// </param>
		/// <param name="elements">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The number of elements in the <i>transforms</i> array.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTransform</c>**</b></para>
		///   <para>The new transform group object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>The array entries in a transform group cannot be changed. However, each transform in the array can be modified through its own property setting methods. If a transform in the array is modified, the change is reflected in the computed matrix of the transform group.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createtransformgroup
		// HRESULT CreateTransformGroup( [in] IDCompositionTransform **transforms, [in] UINT elements, [out] IDCompositionTransform **transformGroup );
		IDCompositionTransform CreateTransformGroup([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IDCompositionTransform[] transforms, uint elements);

		/// <summary>Creates a 3D translation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTranslateTransform3D</c>**</b></para>
		///   <para>The new 3D translation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A newly created 3D translation transform has a static value of 0 for the OffsetX, OffsetY, and OffsetZ properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createtranslatetransform3d
		// HRESULT CreateTranslateTransform3D( [out] IDCompositionTranslateTransform3D **translateTransform3D );
		IDCompositionTranslateTransform3D CreateTranslateTransform3D();

		/// <summary>Creates a 3D scale transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionScaleTransform3D</c>**</b></para>
		///   <para>The new 3D scale transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 3D scale transform object has a static value of 1.0 for the ScaleX, ScaleY, and ScaleZ properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createscaletransform3d
		// HRESULT CreateScaleTransform3D( [out] IDCompositionScaleTransform3D **scaleTransform3D );
		IDCompositionScaleTransform3D CreateScaleTransform3D();

		/// <summary>Creates a 3D rotation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionRotateTransform3D</c>**</b></para>
		///   <para>The new 3D rotation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 3D rotation transform object has a default static value of zero for the Angle, CenterX, CenterY, AxisX, and AxisY properties, and a default static value of 1.0 for the AxisZ property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createrotatetransform3d
		// HRESULT CreateRotateTransform3D( [out] IDCompositionRotateTransform3D **rotateTransform3D );
		IDCompositionRotateTransform3D CreateRotateTransform3D();

		/// <summary>Creates a 3D 4-by-4 matrix transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionMatrixTransform3D</c>**</b></para>
		///   <para>The new 3D matrix transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>The new 3D matrix transform has the identity matrix as its value. The identity matrix is the 4-by-4 matrix with ones on the main diagonal and zeros elsewhere, as shown in the following illustration.</para>
		///   <para>When an identity transform is applied to an object, it does not change the position, shape, or size of the object. It is similar to the way that multiplying a number by one does not change the number. Any transform other than the identity transform will modify the position, shape, and/or size of objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-creatematrixtransform3d
		// HRESULT CreateMatrixTransform3D( [out] IDCompositionMatrixTransform3D **matrixTransform3D );
		IDCompositionMatrixTransform3D CreateMatrixTransform3D();

		/// <summary>Creates a 3D transform group object that holds an array of 3D transform objects.</summary>
		/// <param name="transforms3D">
		///   <para>Type: <b><c>IDCompositionTransform3D</c>**</b></para>
		///   <para>An array of 3D transform objects that make up this transform group.</para>
		/// </param>
		/// <param name="elements">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The number of elements in the <i>transforms</i> array.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTransform3D</c>**</b></para>
		///   <para>The new 3D transform group object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>The array entries in a 3D transform group cannot be changed. However, each transform in the array can be modified through its own property setting methods. If a transform in the array is modified, the change is reflected in the computed matrix of the transform group.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createtransform3dgroup
		// HRESULT CreateTransform3DGroup( [in] IDCompositionTransform3D **transforms3D, [in] UINT elements, [out] IDCompositionTransform3D **transform3DGroup );
		IDCompositionTransform3D CreateTransform3DGroup([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IDCompositionTransform3D[] transforms3D, uint elements);

		/// <summary>Creates an object that represents multiple effects to be applied to a visual subtree.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionEffectGroup</c>**</b></para>
		///   <para>The new effect group object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>An effect group enables an application to apply multiple effects to a single visual subtree.</para>
		///   <para>A new effect group has a default opacity value of 1.0 and no 3D transformations.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createeffectgroup
		// HRESULT CreateEffectGroup( [out] IDCompositionEffectGroup **effectGroup );
		IDCompositionEffectGroup CreateEffectGroup();

		/// <summary>Creates a clip object that can be used to restrict the rendering of a visual subtree to a rectangular area.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionRectangleClip</c>**</b></para>
		///   <para>The new clip object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A newly created clip object has a value of -2^21 for the left and top properties, and a value of 2^21 for the right and bottom properties, effectively making it a no-op clip object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createrectangleclip
		// HRESULT CreateRectangleClip( [out] IDCompositionRectangleClip **clip );
		IDCompositionRectangleClip CreateRectangleClip();

		/// <summary>Creates an animation object that is used to animate one or more scalar properties of one or more Microsoft DirectComposition objects.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionAnimation</c>**</b></para>
		///   <para>The new animation object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A number of DirectComposition object properties can have an animation object as the value of the property. When a property has an animation object as its value, DirectComposition redraws the visual at the refresh rate to reflect the changing value of the property that is being animated.</para>
		///   <para>A newly created animation object does not have any animation segments associated with it. An application must use the methods of the <c>IDCompositionAnimation</c> interface to build an animation function before setting the animation object as the property of another DirectComposition object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-createanimation
		// HRESULT CreateAnimation( [out] IDCompositionAnimation **animation );
		IDCompositionAnimation CreateAnimation();

		/// <summary>Determines whether the DirectComposition device object is still valid.</summary>
		/// <returns>TRUE if the DirectComposition device object is still valid; otherwise FALSE.</returns>
		/// <remarks>If the Microsoft DirectX Graphics Infrastructure (DXGI) device is lost, the DirectComposition device associated with the DXGI device is also lost. When it detects a lost device, DirectComposition sends the <c>WM_PAINT</c> message to all windows that are composing DirectComposition content using the lost device. An application should call <b>CheckDeviceState</b> in response to each <b>WM_PAINT</b> message to ensure that the DirectComposition device object is still valid. The application must take steps to recover content if the device object becomes invalid. Steps include creating new DXGI and DirectComposition devices, and recreating all content. (It’s not possible to create just a new DXGI device and associate it with the existing DirectComposition device.) The system ensures that the device object remains valid between <b>WM_PAINT</b> messages.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice-checkdevicestate
		// HRESULT CheckDeviceState( [out] BOOL *pfValid );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool CheckDeviceState();
	}

	/// <summary>Represents a binding between a Microsoft DirectComposition visual tree and a destination on top of which the visual tree should be composed.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositiontarget
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionTarget")]
	[ComImport, Guid("eacdd04c-117e-4e17-88f4-d1b12b0e3d89"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionTarget
	{
		/// <summary>Sets a visual object as the new root object of a visual tree.</summary>
		/// <param name="visual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The visual object that is the new root of this visual tree. This parameter can be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>A visual can be either the root of a single visual tree, or a child of another visual, but it cannot be both at the same time. This method fails if the <i>visual</i> parameter is already the root of another visual tree, or is a child of another visual.</para>
		///   <para>If <i>visual</i> is NULL, the visual tree is empty. If there was a previous non-NULL root visual, that visual becomes available for use as the root of another visual tree, or as a child of another visual.</para>
		///   <para>Examples</para>
		///   <para>For an example, see <c>How to Build a Simple Visual Tree</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontarget-setroot
		// HRESULT SetRoot( [in, optional] IDCompositionVisual *visual );
		void SetRoot([In, Optional] IDCompositionVisual? visual);
	}

	/// <summary>Represents a Microsoft DirectComposition visual.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionvisual
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionVisual")]
	[ComImport, Guid("4d93059d-097b-4651-9a60-f0f25116e2f3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionVisual
	{
		/// <summary>Changes the value of the OffsetX property of this visual. The OffsetX property specifies the new offset of the visual along the x-axis, relative to the parent visual.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the OffsetX property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the animation object referenced by the <i>animation</i> parameter is changed after this call, the change does not affect the OffsetX property unless this method is called again. If the OffsetX property was previously animated, this method replaces that animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsetx(idcompositionanimation)
		// HRESULT SetOffsetX( [in] IDCompositionAnimation *animation );
		void SetOffsetX(IDCompositionAnimation animation);

		/// <summary>Changes the value of the OffsetX property of this visual. The OffsetX property specifies the new offset of the visual along the x-axis, relative to the parent visual.</summary>
		/// <param name="offsetX">
		///   <para>Type: <b>float</b></para>
		///   <para>The new offset of the visual along the x-axis, in pixels.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>offsetX</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>Changing the OffsetX property of a visual transforms the coordinate system of the entire visual subtree that is rooted at that visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>A transformation that is specified by the Transform property is applied after the OffsetX property. In other words, the effect of setting the Transform property and the OffsetX property is the same as setting only the Transform property on a transform group object where the first member of the group is an <c>IDCompositionTranslateTransform</c> object that has the same OffsetX value as <i>offsetX</i>. However, you should use <b>IDCompositionVisual::SetOffsetX</b> whenever possible because it is slightly faster.</para>
		///   <para>If the OffsetX and OffsetY properties are set to 0, and the Transform property is set to NULL, the coordinate system of the visual is the same as that of its parent.</para>
		///   <para>If the OffsetX property was previously animated, this method removes the animation and sets the property to the specified static value.</para>
		///   <para>Examples</para>
		///   <para>For an example, see <c>How to Build a Simple Visual Tree</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsetx(float)
		// HRESULT SetOffsetX( [in] float offsetX );
		void SetOffsetX(float offsetX);

		/// <summary>Animates the value of the OffsetY property of this visual. The OffsetY property specifies the new offset of the visual along the y-axis, relative to the parent visual.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the OffsetY property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the animation object referenced by the <i>animation</i> parameter is changed after this call, the change does not affect the OffsetY property unless this method is called again. If the OffsetY property was previously animated, this method replaces that animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsety(idcompositionanimation)
		// HRESULT SetOffsetY( [in] IDCompositionAnimation *animation );
		void SetOffsetY(IDCompositionAnimation animation);

		/// <summary>Changes the value of the OffsetY property of this visual. The OffsetY property specifies the new offset of the visual along the y-axis, relative to the parent visual.</summary>
		/// <param name="offsetY">
		///   <para>Type: <b>float</b></para>
		///   <para>The new offset of the visual along the y-axis, in pixels.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>offsetY</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>Changing the OffsetY property transforms the coordinate system of the entire visual subtree that is rooted at this visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>A transformation that is specified by the Transform property is applied after the OffsetY property. In other words, the effect of setting the Transform property and the OffsetY property is the same as setting only the Transform property on a transform group object where the first member of the group is an <c>IDCompositionTranslateTransform</c> object that has the same OffsetY value as <i>offsetY</i>. However, you should use <b>IDCompositionVisual::SetOffsetY</b> whenever possible because it is slightly faster.</para>
		///   <para>If the OffsetX and OffsetY properties are set to 0, and the Transform property is set to NULL, the coordinate system of the visual is the same as that of its parent.</para>
		///   <para>If the OffsetY property was previously animated, this method removes the animation and sets the property to the specified static value.</para>
		///   <para>Examples</para>
		///   <para>For an example, see <c>How to Build a Simple Visual Tree</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsety(float)
		// HRESULT SetOffsetY( [in] float offsetY );
		void SetOffsetY(float offsetY);

		/// <summary>Sets the Transform property of this visual to the specified 2D transform object.</summary>
		/// <param name="transform">
		///   <para>Type: <b><c>IDCompositionTransform</c>*</b></para>
		///   <para>The transform object that is used to modify the coordinate system of this visual. This parameter can point to an <c>IDCompositionTransform</c> interface or one of its derived interfaces. This parameter can be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Transform property transforms the coordinate system of the entire visual subtree that is rooted at this visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>If the Transform property previously specified a transform matrix, the newly specified transform object replaces the transform matrix.</para>
		///   <para>A transformation specified by the Transform property is applied after the OffsetX and OffsetY properties. In other words, the effect of setting the Transform property and the OffsetX and OffsetY properties is the same as setting only the Transform property on a transform group where the first member of the group is an <c>IDCompositionTranslateTransform</c> object that has those same OffsetX and OffsetY values. However, you should use the <c>IDCompositionVisual::SetOffsetX</c> and <c>SetOffsetY</c> methods whenever possible because they are slightly faster.</para>
		///   <para>This method fails if <i>transform</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		///   <para>If the <i>transform</i> parameter is NULL, the coordinate system of this visual is transformed only by its OffsetX and OffsetY properties. Setting the Transform property to NULL is equivalent to setting it to an <c>IDCompositionMatrixTransform</c> object where the specified matrix is the identity matrix. However, an application should set the Transform property to NULL whenever possible because it is slightly faster.</para>
		///   <para>If the OffsetX and OffsetY properties are set to 0, and the Transform property is set to NULL, the coordinate system of the visual is the same as that of its parent.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-settransform(idcompositiontransform)
		// HRESULT SetTransform( [in, optional] IDCompositionTransform *transform );
		void SetTransform([In, Optional] IDCompositionTransform? transform);

		/// <summary>Sets the Transform property of this visual to the specified 3-by-2 transform matrix.</summary>
		/// <param name="matrix">
		///   <para>Type: <b>const <c>D2D_MATRIX_3X2_F</c></b></para>
		///   <para>The 3-by-2 transform matrix that is used to modify the coordinate system of this visual.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Transform property transforms the coordinate system of the entire visual subtree that is rooted at this visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>If the Transform property previously specified a transform object, the newly specified transform matrix replaces the transform object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-settransform(constd2d_matrix_3x2_f_)
		// HRESULT SetTransform( [in, ref] const D2D_MATRIX_3X2_F &amp; matrix );
		void SetTransform(in D2D_MATRIX_3X2_F matrix);

		/// <summary>Sets the TransformParent property of this visual. The TransformParent property establishes the coordinate system relative to which this visual is composed.</summary>
		/// <param name="visual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The new visual that establishes the base coordinate system for this visual. This parameter can be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>The coordinate system of a visual is modified by the OffsetX, OffsetY, and Transform properties. Normally, these properties define the coordinate system of a visual relative to its immediate parent. This method specifies the visual relative to which the coordinate system for this visual is based. The specified visual must be an ancestor of the current visual. If it is not an ancestor, the coordinate system is based on this visual's immediate parent, just as if the TransformParent property were set to NULL. Because visuals can be reparented, this property can take effect again if the specified visual becomes an ancestor of the target visual through a reparenting operation.</para>
		///   <para>If the <i>visual</i> parameter is NULL, the coordinate system is always transformed relative to the visual's immediate parent. This is the default behavior if this method is not used.</para>
		///   <para>This method fails if the <i>visual</i> parameter is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-settransformparent
		// HRESULT SetTransformParent( [in, optional] IDCompositionVisual *visual );
		void SetTransformParent([In, Optional] IDCompositionVisual? visual);

		/// <summary>Sets the Effect property of this visual. The Effect property modifies how the subtree that is rooted at this visual is blended with the background, and can apply a 3D perspective transform to the visual.</summary>
		/// <param name="effect">
		///   <para>Type: <b><c>IDCompositionEffect</c>*</b></para>
		///   <para>A pointer to an effect object. This parameter can be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method creates an implicit off-screen surface to which the subtree that is rooted at this visual is composed. The surface is used as one of the inputs to the specified effect. The output of the effect is composed directly to the composition target. Some effects also use the composition target as another implicit input. This is typically the case for compositional or blend effects such as opacity, where the composition target is considered to be the "background." In that case, any visuals that are "behind" the current visual are included in the composition target when the current visual is rendered and are considered to be the "background" that this visual composes to.</para>
		///   <para>If this visual is not the root of a visual tree and one of its ancestors also has an effect applied to it, the off-screen surface created by the closest ancestor is the composition target to which this visual's effect is composed. Otherwise, the composition target is the root composition target. As a consequence, the background for compositional and blend effects includes only the visuals up to the closest ancestor that itself has an effect. Conversely, any effects applied to visuals under the current visual use the newly created off-screen surface as the background, which may affect how those visuals ultimately compose on top of what the end user perceives as being "behind" those visuals.</para>
		///   <para>If the <i>effect</i> parameter is NULL, no bitmap effect is applied to this visual. Any previous effects that were associated with this visual are removed. The off-screen surface is also removed and the visual subtree is composed directly to the parent composition target, which may also affect how compositional or blend effects under this visual are rendered.</para>
		///   <para>This method fails if <i>effect</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-seteffect
		// HRESULT SetEffect( [in, optional] IDCompositionEffect *effect );
		void SetEffect([In, Optional] IDCompositionEffect? effect);

		/// <summary>Sets the BitmapInterpolationMode property, which specifies the mode for Microsoft DirectComposition to use when interpolating pixels from bitmaps that are not axis-aligned or drawn exactly at scale.</summary>
		/// <param name="interpolationMode">
		///   <para>Type: <b><c>DCOMPOSITION_BITMAP_INTERPOLATION_MODE</c></b></para>
		///   <para>The interpolation mode to use.</para>
		/// </param>
		/// <remarks>
		///   <para>The interpolation mode affects how a bitmap is composed when it is transformed such that there is no one-to-one correspondence between pixels in the bitmap and pixels on the screen.</para>
		///   <para>By default, a visual inherits the interpolation mode of the parent visual, which may inherit the interpolation mode of its parent visual, and so on. A visual uses the default interpolation mode if this method is never called for the visual, or if this method is called with <c>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_INHERIT</c>. If no visuals set the interpolation mode, the default for the entire visual tree is nearest neighbor interpolation, which offers the lowest visual quality but the highest performance.</para>
		///   <para>If the <i>interpolationMode</i> parameter is anything other than <c>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_INHERIT</c>, this visual's bitmap is composed with the specified interpolation mode, and this mode becomes the new default mode for the children of this visual. That is, if the interpolation mode of this visual's children is unchanged or explicitly set to <b>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_INHERIT</b>, the bitmaps of the child visuals are composed using the interpolation mode of this visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setbitmapinterpolationmode
		// HRESULT SetBitmapInterpolationMode( [in] DCOMPOSITION_BITMAP_INTERPOLATION_MODE interpolationMode );
		void SetBitmapInterpolationMode([In] DCOMPOSITION_BITMAP_INTERPOLATION_MODE interpolationMode);

		/// <summary>Sets the BorderMode property, which specifies how to compose the edges of bitmaps and clips associated with this visual, or with visuals in the subtree rooted at this visual.</summary>
		/// <param name="borderMode">
		///   <para>Type: <b><c>DCOMPOSITION_BORDER_MODE</c></b></para>
		///   <para>The border mode to use.</para>
		/// </param>
		/// <remarks>
		///   <para>The border mode affects how the edges of a bitmap are composed when the bitmap is transformed such that the edges are not exactly axis-aligned and at precise pixel boundaries. It also affects how content is clipped at the corners of a clip that has rounded corners, and at the edge of a clip that is transformed such that the edges are not exactly axis-aligned and at precise pixel boundaries.</para>
		///   <para>By default, a visual inherits the border mode of its parent visual, which may inherit the border mode of its parent visual, and so on. A visual uses the default border mode if this method is never called for the visual, or if this method is called with <c>DCOMPOSITION_BORDER_MODE_INHERIT</c>. If no visuals set the border mode, the default for the entire visual tree is aliased rendering, which offers the lowest visual quality but the highest performance.</para>
		///   <para>If the <i>borderMode</i> parameter is anything other than <c>DCOMPOSITION_BORDER_MODE_INHERIT</c>, this visual's bitmap and clip are composed with the specified border mode. In addition, this border mode becomes the new default for the children of the current visual. That is, if the border mode of this visual's children is unchanged or explicitly set to <b>DCOMPOSITION_BORDER_MODE_INHERIT</b>, the bitmaps and clips of the child visuals are composed using the border mode of this visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setbordermode
		// HRESULT SetBorderMode( [in] DCOMPOSITION_BORDER_MODE borderMode );
		void SetBorderMode([In] DCOMPOSITION_BORDER_MODE borderMode);

		/// <summary>Sets the Clip property of this visual to the specified clip object. The Clip property restricts the rendering of the visual subtree that is rooted at this visual to a rectangular region.</summary>
		/// <param name="clip">
		///   <para>Type: <b><c>IDCompositionClip</c>*</b></para>
		///   <para>The clip object to associate with this visual. This parameter can be NULL. All float properties of IDCompositionRectangleClip have a numerical limit of -2^21 to 2^21. The API accepts numbers outside of this range, but they are always clamped to this range.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Clip property clips this visual along with all visuals in the subtree that is rooted at this visual. The clip is transformed by the OffsetX, OffsetY, and Transform properties.</para>
		///   <para>If the Clip property previously specified a clip rectangle, the newly specified Clip object replaces the clip rectangle.</para>
		///   <para>This method fails if <i>clip</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		///   <para>If <i>clip</i> is NULL, the visual is not clipped relative to its parent. However, the visual is clipped by the clip object of the parent visual, or by the closest ancestor visual that has a clip object. Setting <i>clip</i> to NULL is similar to specifying a clip object whose clip rectangle has the left and top sides set to negative infinity, and the right and bottom sides set to positive infinity. Using a NULL clip object results in slightly better performance.</para>
		///   <para>If <i>clip</i> specifies a clip object that has an empty rectangle, the visual is fully clipped; that is, the visual is included in the visual tree, but it does not render anything. To exclude a particular visual from a composition, remove the visual from the visual tree instead of setting an empty clip rectangle. Removing the visual results in better performance.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setclip(idcompositionclip)
		// HRESULT SetClip( [in, optional] IDCompositionClip *clip );
		void SetClip([In, Optional] IDCompositionClip? clip);

		/// <summary>Sets the Clip property of this visual to the specified rectangle. The Clip property restricts the rendering of the visual subtree that is rooted at this visual to the specified rectangular region.</summary>
		/// <param name="rect">
		///   <para>Type: <b>const <c>D2D_RECT_F</c></b></para>
		///   <para>The rectangle to use to clip this visual. All properties of the rect parameter have a numerical limit of -2^21 to 2^21. The API accepts numbers outside of this range, but they are always clamped to this range.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Clip property clips this visual along with all visuals in the subtree that is rooted at this visual. The clip is transformed by the OffsetX, OffsetY, and Transform properties.</para>
		///   <para>If the Clip property previously specified a clip object, the newly specified clip rectangle replaces the clip object.</para>
		///   <para>This method fails if any members of the <i>rect</i> structure are NaN, positive infinity, or negative infinity.</para>
		///   <para>If the clip rectangle is empty, the visual is fully clipped; that is, the visual is included in the visual tree, but it does not render anything. To exclude a particular visual from a composition, remove the visual from the visual tree instead of setting an empty clip rectangle. Removing the visual results in better performance.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setclip(constd2d_rect_f_)
		// HRESULT SetClip( [in, ref] const D2D_RECT_F &amp; rect );
		void SetClip(in D2D_RECT_F rect);

		/// <summary>Sets the Content property of this visual to the specified bitmap or window wrapper.</summary>
		/// <param name="content">
		/// <para>Type: <b><c>IUnknown</c>*</b></para>
		/// <para>The object that is the new content of this visual. This parameter can be NULL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See <c>DirectComposition Error Codes</c> for a list of error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <i>content</i> parameter must point to one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>An object that implements the <c>IDCompositionSurface</c> interface.</description>
		/// </item>
		/// <item>
		/// <description>An object that implements the <b>IDXGISwapChain1</b> interface.</description>
		/// </item>
		/// <item>
		/// <description>A wrapper object that is returned by the <c>CreateSurfaceFromHandle</c> or <c>CreateSurfaceFromHwnd</c> method.</description>
		/// </item>
		/// </list>
		/// <para>The new content replaces any content that was previously associated with the visual. If the <i>content</i> parameter is NULL, the visual has no associated content.</para>
		/// <para>A visual can be associated with a bitmap object or a window wrapper. A bitmap is either a Microsoft DirectX swap chain or a Microsoft DirectComposition surface.</para>
		/// <para>A window wrapper is created with the <c>CreateSurfaceFromHwnd</c> method and is a stand-in for the rasterization of another window, which must be a top-level window or a layered child window. A window wrapper is conceptually equivalent to a bitmap that is the size of the target window on which the contents of the window are drawn. The contents include the target window's child windows (layered or otherwise), and any DirectComposition content that is drawn in the child windows.</para>
		/// <para>A DirectComposition surface wrapper is created with the <c>CreateSurfaceFromHandle</c> method and is a reference to a swap chain. An application might use a surface wrapper in a cross-process scenario where one process creates the swap chain and another process associates the bitmap with a visual.</para>
		/// <para>The bitmap is always drawn at position (0,0) relative to the visual's coordinate system, although the coordinate system is directly affected by the OffsetX, OffsetY, and Transform properties, as well as indirectly by the transformations on ancestor visuals. The bitmap of a visual is always drawn behind the children of that visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setcontent
		// HRESULT SetContent( [in, optional] IUnknown *content );
		void SetContent([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? content);

		/// <summary>Adds a new child visual to the children list of this visual.</summary>
		/// <param name="visual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The child visual to add. This parameter must not be NULL.</para>
		/// </param>
		/// <param name="insertAbove">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>TRUE to place the new child visual in front of the visual specified by the <i>referenceVisual</i> parameter, or FALSE to place it behind <i>referenceVisual</i>.</para>
		/// </param>
		/// <param name="referenceVisual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The existing child visual next to which the new visual should be added.</para>
		/// </param>
		/// <remarks>
		///   <para>Child visuals are arranged in an ordered list. The contents of a child visual are drawn in front of (or above) the contents of its parent visual, but behind (or below) the contents of its children.</para>
		///   <para>The <i>referenceVisual</i> parameter must be an existing child of the parent visual, or it must be NULL. The <i>insertAbove</i> parameter indicates whether the new child should be rendered immediately above the reference visual in the Z order, or immediately below it.</para>
		///   <para>If the <i>referenceVisual</i> parameter is NULL, the specified visual is rendered above or below all children of the parent visual, depending on the value of the <i>insertAbove</i> parameter. If <i>insertAbove</i> is TRUE, the new child visual is above no sibling, therefore it is rendered below all of its siblings. Conversely, if <i>insertAbove</i> is FALSE, the visual is below no sibling, therefore it is rendered above all of its siblings.</para>
		///   <para>The visual specified by the <i>visual</i> parameter cannot be either a child of a single other visual, or the root of a visual tree that is associated with a composition target. If <i>visual</i> is already a child of another visual, <b>AddVisual</b> fails. The child visual must be removed from the children list of its previous parent before adding it to the children list of the new parent. If <i>visual</i> is the root of a visual tree, the visual must be dissociated from that visual tree before adding it to the children list of the new parent. To dissociate the visual from a visual tree, call the <c>IDCompositionTarget::SetRoot</c> method and specify either a different visual or NULL as the <i>visual</i> parameter.</para>
		///   <para>A child visual need not have been created by the same <c>IDCompositionDevice</c> interface as its parent. When visuals from different devices are combined in the same visual tree, Microsoft DirectComposition composes the tree as it normally would, except that changes to a particular visual take effect only when <c>IDCompositionDevice::Commit</c> is called on the device object that created the visual. The ability to combine visuals from different devices enables multiple threads to create and manipulate a single visual tree while maintaining independent devices that can be used to commit changes asynchronously</para>
		///   <para>This method fails if <i>visual</i> or <i>referenceVisual</i> is an invalid pointer, or if the visual referenced by the <i>referenceVisual</i> parameter is not a child of the parent visual. These interfaces cannot be custom implementations; only interfaces created by DirectComposition can be used with this method.</para>
		///   <para>Examples</para>
		///   <para>For an example, see <c>How to Build a Simple Visual Tree</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-addvisual
		// HRESULT AddVisual( [in] IDCompositionVisual *visual, [in] BOOL insertAbove, [in, optional] IDCompositionVisual *referenceVisual );
		void AddVisual([In] IDCompositionVisual visual, bool insertAbove, [In, Optional] IDCompositionVisual? referenceVisual);

		/// <summary>Removes a child visual from the children list of this visual.</summary>
		/// <param name="visual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The child visual to remove from the children list. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>The child visual is removed from the list of children. The order of the remaining child visuals is not changed.</para>
		///   <para>This method fails if <i>visual</i> is not a child of the parent visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-removevisual
		// HRESULT RemoveVisual( [in] IDCompositionVisual *visual );
		void RemoveVisual([In] IDCompositionVisual visual);

		/// <summary>Removes all visuals from the children list of this visual.</summary>
		/// <remarks>This method can be called even if this visual has no children.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-removeallvisuals
		// HRESULT RemoveAllVisuals();
		void RemoveAllVisuals();

		/// <summary>Sets the blending mode for this visual.</summary>
		/// <param name="compositeMode">
		///   <para>Type: <b><c>DCOMPOSITION_COMPOSITE_MODE</c></b></para>
		///   <para>The blending mode to use when composing the visual to the screen.</para>
		/// </param>
		/// <remarks>The composite mode determines how visual's bitmap is blended with the screen. By default, the visual is blended with "source over" semantics; that is, the colors are blended with per-pixel transparency.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setcompositemode
		// HRESULT SetCompositeMode( [in] DCOMPOSITION_COMPOSITE_MODE compositeMode );
		void SetCompositeMode([In] DCOMPOSITION_COMPOSITE_MODE compositeMode);
	}

	/// <summary>Represents a bitmap effect that modifies the rasterization of a visual's subtree.</summary>
	/// <remarks>
	/// <para><b>IDCompositionEffect</b> is an abstract interface that represents a bitmap effect. An effect applies to the entire visual subtree rooted at the visual that the effect is associated with. An effect object can be associated with multiple visuals. When an effect object is modified, all affected visuals are recomposed to reflect the change.</para>
	/// <para>More than one effect can be simultaneously applied to a visual by using the <c>IDCompositionEffectGroup</c> interface.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositioneffect
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionEffect")]
	[ComImport, Guid("EC81B08F-BFCB-4e8d-B193-A915587999E8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionEffect
	{
	}

	/// <summary>Represents a 3D transformation effect that can be used to modify the rasterization of a visual subtree.</summary>
	/// <remarks>The <b>IDCompositionTransform3D</b> interface is an abstract interface that represents a 3D perspective transformation effect. A 3D transform object can be associated with multiple visuals and multiple effect groups. When a 3D transform object is modified, all affected visuals are recomposed to reflect the change.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositiontransform3d
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionTransform3D")]
	[ComImport, Guid("71185722-246B-41f2-AAD1-0443F7F4BFC2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionTransform3D : IDCompositionEffect
	{
	}

	/// <summary>Represents a 2D transformation that can be used to modify the coordinate space of a visual subtree.</summary>
	/// <remarks>
	/// <para>The <b>IDCompositionTransform</b> interface is an abstract interface that represents a 2D affine transformation. Transformations affect the entire visual subtree that is rooted at the visual that the transform is associated with. A transform object can be associated with multiple visuals. When a transform object is modified, all affected visuals are recomposed to reflect the change.</para>
	/// <para>Transforms operate by modifying the coordinate system for all rendering operations on a visual. For example, ordinarily a bitmap that is associated with a visual draws at position (0,0) and extends the full width and height of the bitmap. If a translation transform is applied, the bitmap draws at a position that is offset by that transform. If a scale transform is applied, the extent covered by the bitmap is affected by the scale transform. More than one transform can be simultaneously applied to a visual by using the <c>IDCompositionDevice::CreateTransformGroup</c> interface.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositiontransform
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionTransform")]
	[ComImport, Guid("FD55FAA7-37E0-4c20-95D2-9BE45BC33F55"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionTransform : IDCompositionTransform3D
	{
	}

	/// <summary>Represents a 2D transformation that affects only the offset of a visual along the x-axis and y-axis.</summary>
	/// <remarks>
	/// <para>A translation transform represents the following 3-by-2 matrix:</para>
	/// <para>The effect is simply to offset the coordinate system by <i>x</i> and <i>y</i>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositiontranslatetransform
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionTranslateTransform")]
	[ComImport, Guid("06791122-C6F0-417d-8323-269E987F5954"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionTranslateTransform : IDCompositionTransform
	{
		/// <summary>Animates the value of the OffsetX property of a 2D translation transform. The OffsetX property specifies the translation along the x-axis.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the OffsetX property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the OffsetX property unless this method is called again. If the OffsetX property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontranslatetransform-setoffsetx(idcompositionanimation)
		// HRESULT SetOffsetX( [in] IDCompositionAnimation *animation );
		void SetOffsetX([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the OffsetX property of a 2D translation transform. The OffsetX property specifies the distance to translate along the x-axis.</summary>
		/// <param name="offsetX">
		///   <para>Type: <b>float</b></para>
		///   <para>The distance to translate along the x-axis, in pixels.</para>
		/// </param>
		/// <remarks>
		///   <para>This method performs an affine transformation, which moves every point by a fixed distance in the same direction. It is similar to shifting the origin of the coordinate space.</para>
		///   <para>This method fails if the <i>offsetX</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the OffsetX property was previously animated, this method removes the animation and sets the OffsetX property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontranslatetransform-setoffsetx(float)
		// HRESULT SetOffsetX( [in] float offsetX );
		void SetOffsetX(float offsetX);

		/// <summary>Animates the value of the OffsetY property of a 2D translation transform. The OffsetY property specifies the translation along the y-axis.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the OffsetY property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the OffsetY property unless this method is called again. If the OffsetY property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontranslatetransform-setoffsety(idcompositionanimation)
		// HRESULT SetOffsetY( [in] IDCompositionAnimation *animation );
		void SetOffsetY([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the OffsetY property of a 2D translation transform. The OffsetY property specifies the distance to translate along the y-axis.</summary>
		/// <param name="offsetY">
		///   <para>Type: <b>float</b></para>
		///   <para>The distance to translate along the y-axis, in pixels.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>offsetY</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the OffsetY property was previously animated, this method removes the animation and sets the OffsetY property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontranslatetransform-setoffsety(float)
		// HRESULT SetOffsetY( [in] float offsetY );
		void SetOffsetY(float offsetY);
	}

	/// <summary>Represents a 2D transformation that affects the scale of a visual along the x-axis and y-axis. The coordinate system is scaled from the specified center point.</summary>
	/// <remarks>
	/// <para>A scale transform represents the following 3-by-3 matrix:</para>
	/// <para>The effect is to scale the coordinate system up or down and apply the corresponding translation such that the center point does not move.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionscaletransform
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionScaleTransform")]
	[ComImport, Guid("71FDE914-40EF-45ef-BD51-68B037C339F9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionScaleTransform : IDCompositionTransform
	{
		/// <summary>Animates the value of the ScaleX property of a 2D scale transform. The ScaleX property specifies the scale factor along the x-axis.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the ScaleX property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the ScaleX property unless this method is called again. If the ScaleX property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform-setscalex(idcompositionanimation)
		// HRESULT SetScaleX( [in] IDCompositionAnimation *animation );
		void SetScaleX([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the ScaleX property of a 2D scale transform. The ScaleX property specifies the scale factor along the x-axis.</summary>
		/// <param name="scaleX">
		///   <para>Type: <b>float</b></para>
		///   <para>The new x-axis scale factor.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>scaleX</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the ScaleX property was previously animated, this method removes the animation and sets the ScaleX property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform-setscalex(float)
		// HRESULT SetScaleX( [in] float scaleX );
		void SetScaleX(float scaleX);

		/// <summary>Animates the value of the ScaleY property of a 2D scale transform. The ScaleY property specifies the scale factor along the y-axis.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the ScaleY property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the ScaleY property unless this method is called again. If the ScaleY property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform-setscaley(idcompositionanimation)
		// HRESULT SetScaleY( [in] IDCompositionAnimation *animation );
		void SetScaleY([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the ScaleY property of a 2D scale transform. The ScaleY property specifies the scale factor along the y-axis.</summary>
		/// <param name="scaleY">
		///   <para>Type: <b>float</b></para>
		///   <para>The new y-axis scale factor.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>scaleY</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the ScaleY property was previously animated, this method removes the animation and sets the ScaleY property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform-setscaley(float)
		// HRESULT SetScaleY( [in] float scaleY );
		void SetScaleY(float scaleY);

		/// <summary>Animates the value of the CenterX property of a 2D scale transform. The CenterX property specifies the x-coordinate of the point about which scaling is performed.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the CenterX property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the CenterX property unless this method is called again. If the CenterX property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform-setcenterx(idcompositionanimation)
		// HRESULT SetCenterX( [in] IDCompositionAnimation *animation );
		void SetCenterX([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the CenterX property of a 2D scale transform. The CenterX property specifies the x-coordinate of the point about which scaling is performed.</summary>
		/// <param name="centerX">
		///   <para>Type: <b>float</b></para>
		///   <para>The new x-coordinate of the center point.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>centerX</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the CenterX property was previously animated, this method removes the animation and sets the CenterX property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform-setcenterx(float)
		// HRESULT SetCenterX( [in] float centerX );
		void SetCenterX(float centerX);

		/// <summary>Animates the value of the CenterY property of a 2D scale transform. The CenterY property specifies the y-coordinate of the point about which scaling is performed.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the CenterY property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the CenterY property unless this method is called again. If the CenterY property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform-setcentery(idcompositionanimation)
		// HRESULT SetCenterY( [in] IDCompositionAnimation *animation );
		void SetCenterY([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the CenterY property of a 2D scale transform. The CenterY property specifies the y-coordinate of the point about which scaling is performed.</summary>
		/// <param name="centerY">
		///   <para>Type: <b>float</b></para>
		///   <para>The new y-coordinate of the center point.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>centerY</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the CenterY property was previously animated, this method removes the animation and sets the CenterY property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform-setcentery(float)
		// HRESULT SetCenterY( [in] float centerY );
		void SetCenterY(float centerY);
	}

	/// <summary>Represents a 2D transformation that affects the rotation of a visual around the z-axis. The coordinate system is rotated around the specified center point.</summary>
	/// <remarks>
	/// <para>A rotate transform represents the following 3-by-3 matrix:</para>
	/// <para>The effect is to rotate the coordinate system clockwise or counter-clockwise, and to apply the corresponding translation such that the center point does not move.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionrotatetransform
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionRotateTransform")]
	[ComImport, Guid("641ED83C-AE96-46c5-90DC-32774CC5C6D5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionRotateTransform : IDCompositionTransform
	{
		/// <summary>Animates the value of the Angle property of a 2D rotation transform. The Angle property specifies the rotation angle.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the Angle property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the Angle property unless this method is called again. If the Angle property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform-setangle(idcompositionanimation)
		// HRESULT SetAngle( [in] IDCompositionAnimation *animation );
		void SetAngle([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the Angle property of a 2D rotation transform. The Angle property specifies the rotation angle.</summary>
		/// <param name="angle">
		///   <para>Type: <b>float</b></para>
		///   <para>The new rotation angle, in degrees. A positive angle creates a clockwise rotation, and a negative angle creates a counterclockwise rotation. For values less than –360 or greater than 360, the values wrap around and are treated as if the mathematical operation mod(360) was applied.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>angle</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the Angle property was previously animated, this method removes the animation and sets the Angle property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform-setangle(float)
		// HRESULT SetAngle( [in] float angle );
		void SetAngle(float angle);

		/// <summary>Animates the value of the CenterX property of a 2D rotation transform. The CenterX property specifies the x-coordinate of the point about which the rotation is performed.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the CenterX property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the CenterX property unless this method is called again. If the CenterX property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform-setcenterx(idcompositionanimation)
		// HRESULT SetCenterX( [in] IDCompositionAnimation *animation );
		void SetCenterX([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the CenterX property of a 2D rotation transform. The CenterX property specifies the x-coordinate of the point about which the rotation is performed.</summary>
		/// <param name="centerX">
		///   <para>Type: <b>float</b></para>
		///   <para>The new x-coordinate of the center point.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>centerX</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the CenterX property was previously animated, this method removes the animation and sets the CenterX property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform-setcenterx(float)
		// HRESULT SetCenterX( [in] float centerX );
		void SetCenterX(float centerX);

		/// <summary>Animates the value of the CenterY property of a 2D rotation transform. The CenterY property specifies the y-coordinate of the point about which the rotation is performed.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the CenterY property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the CenterY property unless this method is called again. If the CenterY property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform-setcentery(idcompositionanimation)
		// HRESULT SetCenterY( [in] IDCompositionAnimation *animation );
		void SetCenterY([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the CenterY property of a 2D rotation transform. The CenterY property specifies the y-coordinate of the point about which the rotation is performed.</summary>
		/// <param name="centerY">
		///   <para>Type: <b>float</b></para>
		///   <para>The new y-coordinate of the center point.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>centerY</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the CenterY property was previously animated, this method removes the animation and sets the CenterY property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform-setcentery(float)
		// HRESULT SetCenterY( [in] float centerY );
		void SetCenterY(float centerY);
	}

	/// <summary>Represents a 2D transformation that affects the skew of a visual along the x-axis and y-axis. The coordinate system is skewed around the specified center point.</summary>
	/// <remarks>
	/// <para>A skew transform represents the following 3-by-3 matrix:</para>
	/// <para>The effect is to slant the coordinate system along the x-axis and y-axis such that a rectangle becomes a parallelogram, and to apply the corresponding translation such that the center point does not move.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionskewtransform
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionSkewTransform")]
	[ComImport, Guid("E57AA735-DCDB-4c72-9C61-0591F58889EE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionSkewTransform : IDCompositionTransform
	{
		/// <summary>Animates the value of the AngleX property of a 2D skew transform. The AngleX property specifies the skew angle along the x-axis.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that represents how the value of the AngleX property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the AngleX property unless this method is called again. If the AngleX property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionskewtransform-setanglex(idcompositionanimation)
		// HRESULT SetAngleX( [in] IDCompositionAnimation *animation );
		void SetAngleX([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the AngleX property of a 2D skew transform. The AngleX property specifies the skew angle along the x-axis.</summary>
		/// <param name="angleX">
		///   <para>Type: <b>float</b></para>
		///   <para>The new skew angle of the x-axis, in degrees. A positive value creates a counterclockwise skew, and a negative value creates a clockwise skew. For values less than –360 or greater than 360, the values wrap around and are treated as if the mathematical operation mod(360) was applied.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>angleX</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the AngleX property was previously animated, this method removes the animation and sets the AngleX property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionskewtransform-setanglex(float)
		// HRESULT SetAngleX( [in] float angleX );
		void SetAngleX(float angleX);

		/// <summary>Animates the value of the AngleY property of a 2D skew transform. The AngleY property specifies the skew angle along the y-axis.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that represents how the value of the AngleY property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the AngleY property unless this method is called again. If the AngleY property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionskewtransform-setangley(idcompositionanimation)
		// HRESULT SetAngleY( [in] IDCompositionAnimation *animation );
		void SetAngleY([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the AngleY property of a 2D skew transform. The AngleY property specifies the skew angle along the y-axis.</summary>
		/// <param name="angleY">
		///   <para>Type: <b>float</b></para>
		///   <para>The new skew angle of the y-axis, in degrees. A positive value creates a counterclockwise skew, and a negative value creates a clockwise skew. For values less than –360 or greater than 360, the values wrap around and are treated as if the mathematical operation mod(360) was applied.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>angleY</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the AngleY property was previously animated, this method removes the animation and sets the AngleY property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionskewtransform-setangley(float)
		// HRESULT SetAngleY( [in] float angleY );
		void SetAngleY(float angleY);

		/// <summary>Animates the value of the CenterX property of a 2D skew transform. The CenterX property specifies the x-coordinate of the point about which the skew is performed.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the CenterX property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the CenterX property unless this method is called again. If the CenterX property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionskewtransform-setcenterx(idcompositionanimation)
		// HRESULT SetCenterX( [in] IDCompositionAnimation *animation );
		void SetCenterX([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the CenterX property of a 2D skew transform. The CenterX property specifies the x-coordinate of the point about which the skew is performed.</summary>
		/// <param name="centerX">
		///   <para>Type: <b>float</b></para>
		///   <para>The new x-coordinate of the center point.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>centerX</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the CenterX property was previously animated, this method removes the animation and sets the CenterX property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionskewtransform-setcenterx(float)
		// HRESULT SetCenterX( [in] float centerX );
		void SetCenterX(float centerX);

		/// <summary>Animates the value of the CenterY property of a 2D skew transform. The CenterY property specifies the y-coordinate of the point about which the skew is performed.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the CenterY property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the CenterY property unless this method is called again. If the CenterY property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionskewtransform-setcentery(idcompositionanimation)
		// HRESULT SetCenterY( [in] IDCompositionAnimation *animation );
		void SetCenterY([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the CenterY property of a 2D skew transform. The CenterY property specifies the y-coordinate of the point about which the skew is performed.</summary>
		/// <param name="centerY">
		///   <para>Type: <b>float</b></para>
		///   <para>The new y-coordinate of the center point.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>centerY</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the CenterY property was previously animated, this method removes the animation and sets the CenterY property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionskewtransform-setcentery(float)
		// HRESULT SetCenterY( [in] float centerY );
		void SetCenterY(float centerY);
	}

	/// <summary>Represents an arbitrary affine 2D transformation defined by a 3-by-2 matrix.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionmatrixtransform
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionMatrixTransform")]
	[ComImport, Guid("16CDFF07-C503-419c-83F2-0965C7AF1FA6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionMatrixTransform : IDCompositionTransform
	{
		/// <summary>Changes all values of the matrix of this 2D transform.</summary>
		/// <param name="matrix">
		///   <para>Type: <b>const <c>D2D_MATRIX_3X2_F</c></b></para>
		///   <para>The new matrix for this 2D transform.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if any of the matrix values are NaN, positive infinity, or negative infinity.</para>
		///   <para>If any of the matrix elements were previously animated, this method removes the animations and sets the elements to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionmatrixtransform-setmatrix
		// HRESULT SetMatrix( [ref] const D2D_MATRIX_3X2_F &amp; matrix );
		void SetMatrix(in D2D_MATRIX_3X2_F matrix);

		/// <summary>Animates the value of one element of the matrix of this 2D transform.</summary>
		/// <param name="row">The row index of the element to change. This value must be between 0 and 2, inclusive.</param>
		/// <param name="column">The column index of the element to change. This value must be between 0 and 1, inclusive.</param>
		/// <param name="animation">An animation that represents how the value of the specified element changes over time. This parameter must not be NULL.</param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the element unless this method is called again. If the element was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected transform. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionmatrixtransform-setmatrixelement(int_int_idcompositionanimation)
		// HRESULT SetMatrixElement( [in] int row, [in] int column, [in] IDCompositionAnimation *animation );
		void SetMatrixElement(int row, int column, [In] IDCompositionAnimation animation);

		/// <summary>Changes the value of one element of the matrix of this transform.</summary>
		/// <param name="row">
		///   <para>Type: <b>int</b></para>
		///   <para>The row index of the element to change. This value must be between 0 and 2, inclusive.</para>
		/// </param>
		/// <param name="column">
		///   <para>Type: <b>int</b></para>
		///   <para>The column index of the element to change. This value must be between 0 and 1, inclusive.</para>
		/// </param>
		/// <param name="value">
		///   <para>Type: <b>float</b></para>
		///   <para>The new value of the specified element.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>value</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the specified element was previously animated, this method removes the animation and sets the element to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionmatrixtransform-setmatrixelement(int_int_float)
		// HRESULT SetMatrixElement( [in] int row, [in] int column, [in] float value );
		void SetMatrixElement(int row, int column, [In] float value);
	}

	/// <summary>Represents a group of bitmap effects that are applied together to modify the rasterization of a visual's subtree.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositioneffectgroup
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionEffectGroup")]
	[ComImport, Guid("A7929A74-E6B2-4bd6-8B95-4040119CA34D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionEffectGroup : IDCompositionEffect
	{
		/// <summary>Animates the value of the Opacity property.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the value of the Opacity property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the Opacity property unless this method is called again. If the Opacity property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected composition effect group. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositioneffectgroup-setopacity(idcompositionanimation)
		// HRESULT SetOpacity( [in] IDCompositionAnimation *animation );
		void SetOpacity([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the Opacity property.</summary>
		/// <param name="opacity">
		///   <para>Type: <b>float</b></para>
		///   <para>The new value of the Opacity property.</para>
		/// </param>
		/// <remarks>
		///   <para>The opacity is interpreted as completely transparent for all values less than or equal to 0, and as completely opaque for all values greater than or equal to 1. All values between 0 and 1 represent partial opacity.</para>
		///   <para>This method fails if the <i>opacity</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the Opacity property was previously animated, this method removes the animation and sets the Opacity property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositioneffectgroup-setopacity(float)
		// HRESULT SetOpacity( [in] float opacity );
		void SetOpacity(float opacity);

		/// <summary>Sets the 3D transformation effect object that modifies the rasterization of the visuals that this effect group is applied to.</summary>
		/// <param name="transform3D">
		///   <para>Type: <b><c>IDCompositionTransform3D</c>*</b></para>
		///   <para>Pointer to an <c>IDCompositionTransform3D</c> interface or one of its derived interfaces. This parameter can be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if <i>transform3D</i> is an invalid pointer, or if the pointer was not created by the same <c>IDCompositionDevice</c> interface as this effect group. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		///   <para>If the <i>transform3D</i> parameter is NULL, the effect group does not apply any perspective transformations to the visuals. Setting the transform to NULL is equivalent to setting the transform to an <c>IDCompositionMatrixTransform3D</c> object where the specified matrix is the identity matrix. However, an application should use a NULL transform whenever possible because it is slightly faster.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositioneffectgroup-settransform3d
		// HRESULT SetTransform3D( [in, optional] IDCompositionTransform3D *transform3D );
		void SetTransform3D([In, Optional] IDCompositionTransform3D? transform3D);
	}

	/// <summary>Represents a 3D transformation that affects the offset of a visual along the x-axis, y-axis, and z-axis.</summary>
	/// <remarks>
	/// <para>A 3D translation transform represents the following 4-by-4 matrix:</para>
	/// <para>The effect is to offset the blending position of the visual's subtree by <i>x</i>, <i>y</i>, and <i>z</i>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositiontranslatetransform3d
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionTranslateTransform3D")]
	[ComImport, Guid("91636D4B-9BA1-4532-AAF7-E3344994D788"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionTranslateTransform3D : IDCompositionTransform3D
	{
		/// <summary>Animates the value of the OffsetX property of a 3D translation transform effect. The OffsetX property specifies the distance to translate along the x-axis.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the OffsetX property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the OffsetX property unless this method is called again. If the OffsetX property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontranslatetransform3d-setoffsetx(idcompositionanimation)
		// HRESULT SetOffsetX( [in] IDCompositionAnimation *animation );
		void SetOffsetX([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the OffsetX property of a 3D translation transform effect. The OffsetX property specifies the distance to translate along the x-axis.</summary>
		/// <param name="offsetX">
		///   <para>Type: <b>float</b></para>
		///   <para>The distance to translate along the x-axis, in pixels.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>offsetX</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the OffsetX property was previously animated, this method removes the animation and sets the OffsetX property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontranslatetransform3d-setoffsetx(float)
		// HRESULT SetOffsetX( [in] float offsetX );
		void SetOffsetX(float offsetX);

		/// <summary>Animates the value of the OffsetY property of a 3D translation transform effect. The OffsetY property specifies the distance to translate along the y-axis.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the OffsetY property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the OffsetY property unless this method is called again. If the OffsetY property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontranslatetransform3d-setoffsety(idcompositionanimation)
		// HRESULT SetOffsetY( [in] IDCompositionAnimation *animation );
		void SetOffsetY([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the OffsetY property of a 3D translation transform effect. The OffsetY property specifies the distance to translate along the y-axis.</summary>
		/// <param name="offsetY">
		///   <para>Type: <b>float</b></para>
		///   <para>The distance to translate along the y-axis, in pixels.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>offsetY</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the OffsetY property was previously animated, this method removes the animation and sets the OffsetY property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontranslatetransform3d-setoffsety(float)
		// HRESULT SetOffsetY( [in] float offsetY );
		void SetOffsetY(float offsetY);

		/// <summary>Animates the value of the OffsetZ property of a 3D translation transform effect. The OffsetZ property specifies the distance to translate along the z-axis.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the OffsetZ property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the OffsetZ property unless this method is called again. If the OffsetZ property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontranslatetransform3d-setoffsetz(idcompositionanimation)
		// HRESULT SetOffsetZ( [in] IDCompositionAnimation *animation );
		void SetOffsetZ([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the OffsetZ property of a 3D translation transform effect. The OffsetZ property specifies the distance to translate along the z-axis.</summary>
		/// <param name="offsetZ">
		///   <para>Type: <b>float</b></para>
		///   <para>The distance to translate along the z-axis, in pixels.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>offsetZ</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the OffsetZ property was previously animated, this method removes the animation and sets the OffsetZ property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontranslatetransform3d-setoffsetz(float)
		// HRESULT SetOffsetZ( [in] float offsetZ );
		void SetOffsetZ(float offsetZ);
	}

	/// <summary>Represents a 3D transformation effect that affects the scale of a visual along the x-axis, y-axis, and z-axis. The coordinate system is scaled from the specified center point.</summary>
	/// <remarks>
	/// <para>A 3D scale transform represents the following 4-by-4 matrix:</para>
	/// <para>The effect is to scale the blending of the visual's subtree up or down, and apply the corresponding translation such that the center point does not move.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionscaletransform3d
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionScaleTransform3D")]
	[ComImport, Guid("2A9E9EAD-364B-4b15-A7C4-A1997F78B389"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionScaleTransform3D : IDCompositionTransform3D
	{
		/// <summary>Animates the value of the ScaleX property of a scale transform. The ScaleX property specifies the scale factor along the x-axis.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the ScaleX property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the ScaleX property unless this method is called again. If the ScaleX property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform3d-setscalex(idcompositionanimation)
		// HRESULT SetScaleX( [in] IDCompositionAnimation *animation );
		void SetScaleX([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the ScaleX property of a 3D scale transform. The ScaleX property specifies the scale factor along the x-axis.</summary>
		/// <param name="scaleX">
		///   <para>Type: <b>float</b></para>
		///   <para>The new x-axis scale factor.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>scaleX</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the ScaleX property was previously animated, this method removes the animation and sets the ScaleX property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform3d-setscalex(float)
		// HRESULT SetScaleX( [in] float scaleX );
		void SetScaleX(float scaleX);

		/// <summary>Animates the value of the ScaleY property of a scale transform. The ScaleY property specifies the scale factor along the y-axis.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the ScaleY property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the ScaleY property unless this method is called again. If the ScaleY property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform3d-setscaley(idcompositionanimation)
		// HRESULT SetScaleY( [in] IDCompositionAnimation *animation );
		void SetScaleY([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the ScaleY property of a 3D scale transform. The ScaleY property specifies the scale factor along the y-axis.</summary>
		/// <param name="scaleY">
		///   <para>Type: <b>float</b></para>
		///   <para>The new y-axis scale factor.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>scaleY</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the ScaleY property was previously animated, this method removes the animation and sets the ScaleY property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform3d-setscaley(float)
		// HRESULT SetScaleY( [in] float scaleY );
		void SetScaleY(float scaleY);

		/// <summary>Animates the value of the ScaleZ property of a scale transform. The ScaleZ property specifies the scale factor along the z-axis.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the ScaleZ property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the ScaleZ property unless this method is called again. If the ScaleZ property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform3d-setscalez(idcompositionanimation)
		// HRESULT SetScaleZ( [in] IDCompositionAnimation *animation );
		void SetScaleZ([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the ScaleZ property of a 3D scale transform. The ScaleZ property specifies the scale factor along the z-axis.</summary>
		/// <param name="scaleZ">
		///   <para>Type: <b>float</b></para>
		///   <para>The new z-axis scale factor.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>scaleZ</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the ScaleZ property was previously animated, this method removes the animation and sets the ScaleZ property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform3d-setscalez(float)
		// HRESULT SetScaleZ( [in] float scaleZ );
		void SetScaleZ(float scaleZ);

		/// <summary>Animates the value of the CenterX property of a 3D scale transform. The CenterX property specifies the x-coordinate of the point about which scaling is performed.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the CenterX property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the CenterX property unless this method is called again. If the CenterX property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform3d-setcenterx(idcompositionanimation)
		// HRESULT SetCenterX( [in] IDCompositionAnimation *animation );
		void SetCenterX([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the CenterX property of a 3D scale transform. The CenterX property specifies the x-coordinate of the point about which scaling is performed.</summary>
		/// <param name="centerX">
		///   <para>Type: <b>float</b></para>
		///   <para>The new x-coordinate of the center point.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>centerX</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the CenterX property was previously animated, this method removes the animation and sets the CenterX property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform3d-setcenterx(float)
		// HRESULT SetCenterX( [in] float centerX );
		void SetCenterX(float centerX);

		/// <summary>Animates the value of the CenterY property of a 3D scale transform. The CenterY property specifies the y-coordinate of the point about which scaling is performed.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the CenterY property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the CenterY property unless this method is called again. If the CenterY property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform3d-setcentery(idcompositionanimation)
		// HRESULT SetCenterY( [in] IDCompositionAnimation *animation );
		void SetCenterY([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the CenterY property of a 3D scale transform. The CenterY property specifies the y-coordinate of the point about which scaling is performed.</summary>
		/// <param name="centerY">
		///   <para>Type: <b>float</b></para>
		///   <para>The new y-coordinate of the center point.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>centerY</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the CenterY property was previously animated, this method removes the animation and sets the CenterY property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform3d-setcentery(float)
		// HRESULT SetCenterY( [in] float centerY );
		void SetCenterY(float centerY);

		/// <summary>Animates the value of the CenterZ property of a 3D scale transform. The CenterZ property specifies the z-coordinate of the point about which scaling is performed.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the CenterZ property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the CenterZ property unless this method is called again. If the CenterZ property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform3d-setcenterz(idcompositionanimation)
		// HRESULT SetCenterZ( [in] IDCompositionAnimation *animation );
		void SetCenterZ([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the CenterZ property of a 3D scale transform. The CenterZ property specifies the z-coordinate of the point about which scaling is performed.</summary>
		/// <param name="centerZ">
		///   <para>Type: <b>float</b></para>
		///   <para>The new z-coordinate of the center point.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>centerZ</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the CenterZ property was previously animated, this method removes the animation and sets the CenterZ property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionscaletransform3d-setcenterz(float)
		// HRESULT SetCenterZ( [in] float centerZ );
		void SetCenterZ(float centerZ);
	}

	/// <summary>Represents a 3D transformation that affects the rotation of a visual along an arbitrary axis in 3D space. The coordinate system is rotated around the specified center point.</summary>
	/// <remarks>
	/// <para>A 3D rotate transform represents the following 4-by-4 matrix:</para>
	/// <para>where the <i>offsetX</i>, <i>offsetY</i>, and <i>offsetZ</i> values of the matrix are the following:</para>
	/// <para>The effect is to rotate the coordinate system clockwise or counter-clockwise around the specified axis, and to apply the corresponding translation such that the center point does not move.</para>
	/// <para>A new 3D rotation transform object has a default static value of zero for the Angle, CenterX, CenterY, AxisX, and AxisY properties, and a default static value of 1.0 for the AxisZ property.</para>
	/// <para>When setting the axis to a non-default value, you should always set all three axis properties (AxisX, AxisY, and AxisZ).</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionrotatetransform3d
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionRotateTransform3D")]
	[ComImport, Guid("D8F5B23F-D429-4a91-B55A-D2F45FD75B18"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionRotateTransform3D : IDCompositionTransform3D
	{
		/// <summary>Animates the value of the Angle property of a 3D rotation transform. The Angle property specifies the rotation angle. The default value is zero.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the Angle property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the Angle property unless this method is called again. If the Angle property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected 3D transform. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform3d-setangle(idcompositionanimation)
		// HRESULT SetAngle( [in] IDCompositionAnimation *animation );
		void SetAngle([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the Angle property of a 3D rotation transform. The Angle property specifies the rotation angle. The default value is zero.</summary>
		/// <param name="angle">
		///   <para>Type: <b>float</b></para>
		///   <para>The new rotation angle, in degrees. Positive values are interpreted as the thumb-down (into the page), right hand rule where the thumb points in the Z direction and the fingers follow a clockwise direction. Negative values are interpreted as the thumb-up (out of the page), right hand rule. For values less than -360 or greater than 360, the values wrap around and are treated as if the mathematical operation mod(360) was applied.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>angle</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the Angle property was previously animated, this method removes the animation and sets the Angle property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform3d-setangle(float)
		// HRESULT SetAngle( [in] float angle );
		void SetAngle(float angle);

		/// <summary>Animates the value of the AxisX property of a 3D rotation transform. The AxisX property specifies the x-coordinate for the axis vector of rotation. The default value is zero.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the AxisX property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>When setting the axis to a non-default value, you should always set all three axis properties (AxisX, AxisY, and AxisZ).</para>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the AxisX property unless this method is called again. If the AxisX property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected 3D transform. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform3d-setaxisx(idcompositionanimation)
		// HRESULT SetAxisX( [in] IDCompositionAnimation *animation );
		void SetAxisX([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the AxisX property of a 3D rotation transform. The AxisX property specifies the x-coordinate for the axis vector of rotation. The default value is zero.</summary>
		/// <param name="axisX">
		///   <para>Type: <b>float</b></para>
		///   <para>The new x-coordinate for the axis vector of rotation.</para>
		/// </param>
		/// <remarks>
		///   <para>When setting the axis to a non-default value, you should always set all three axis properties (AxisX, AxisY, and AxisZ).</para>
		///   <para>This method fails if the <i>axisX</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the AxisX property was previously animated, this method removes the animation and sets the AxisX property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform3d-setaxisx(float)
		// HRESULT SetAxisX( [in] float axisX );
		void SetAxisX(float axisX);

		/// <summary>Animates the value of the AxisY property of a 3D rotation transform. The AxisY property specifies the y-coordinate for the axis vector of rotation. The default value is zero.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the AxisY property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>When setting the axis to a non-default value, you should always set all three axis properties (AxisX, AxisY, and AxisZ).</para>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the AxisY property unless this method is called again. If the AxisY property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected 3D transform. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform3d-setaxisy(idcompositionanimation)
		// HRESULT SetAxisY( [in] IDCompositionAnimation *animation );
		void SetAxisY([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the AxisY property of a 3D rotation transform. The AxisY property specifies the y-coordinate for the axis vector of rotation. The default value is zero.</summary>
		/// <param name="axisY">
		///   <para>Type: <b>float</b></para>
		///   <para>The new y-coordinate for the axis vector of rotation.</para>
		/// </param>
		/// <remarks>
		///   <para>When setting the axis to a non-default value, you should always set all three axis properties (AxisX, AxisY, and AxisZ).</para>
		///   <para>This method fails if the <i>axisY</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the AxisY property was previously animated, this method removes the animation and sets the AxisY property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform3d-setaxisy(float)
		// HRESULT SetAxisY( [in] float axisY );
		void SetAxisY(float axisY);

		/// <summary>Animates the value of the AxisZ property of a 3D rotation transform. The AxisZ property specifies the z-coordinate for the axis vector of rotation. The default value is 1.0.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the AxisZ property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>When setting the axis to a non-default value, you should always set all three axis properties (AxisX, AxisY, and AxisZ).</para>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the AxisZ property unless this method is called again. If the AxisZ property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected 3D transform. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		///   <para>The default value is 0.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform3d-setaxisz(idcompositionanimation)
		// HRESULT SetAxisZ( [in] IDCompositionAnimation *animation );
		void SetAxisZ([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the AxisZ property of a 3D rotation transform. The AxisZ property specifies the z-coordinate for the axis vector of rotation. The default value is 1.0.</summary>
		/// <param name="axisZ">
		///   <para>Type: <b>float</b></para>
		///   <para>The new z-coordinate for the axis vector of rotation.</para>
		/// </param>
		/// <remarks>
		///   <para>When setting the axis to a non-default value, you should always set all three axis properties (AxisX, AxisY, and AxisZ).</para>
		///   <para>This method fails if the <i>axisZ</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the AxisZ property was previously animated, this method removes the animation and sets the AxisX property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform3d-setaxisz(float)
		// HRESULT SetAxisZ( [in] float axisZ );
		void SetAxisZ(float axisZ);

		/// <summary>Animates the value of the CenterX property of a 3D rotation transform. The CenterX property specifies the x-coordinate of the point about which the rotation is performed. The default value is zero.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the CenterX property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the CenterX property unless this method is called again. If the CenterX property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform3d-setcenterx(idcompositionanimation)
		// HRESULT SetCenterX( [in] IDCompositionAnimation *animation );
		void SetCenterX([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the CenterX property of a 3D rotation transform. The CenterX property specifies the x-coordinate of the point about which the rotation is performed. The default value is zero.</summary>
		/// <param name="centerX">
		///   <para>Type: <b>float</b></para>
		///   <para>The new x-coordinate of the center point.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>centerX</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the CenterX property was previously animated, this method removes the animation and sets the CenterX property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform3d-setcenterx(float)
		// HRESULT SetCenterX( [in] float centerX );
		void SetCenterX(float centerX);

		/// <summary>Animates the value of the CenterY property of a 3D rotation transform. The CenterY property specifies the y-coordinate of the point about which the rotation is performed. The default value is zero.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the CenterY property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the CenterY property unless this method is called again. If the CenterY property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform3d-setcentery(idcompositionanimation)
		// HRESULT SetCenterY( [in] IDCompositionAnimation *animation );
		void SetCenterY([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the CenterY property of a 3D rotation transform. The CenterY property specifies the y-coordinate of the point about which the rotation is performed. The default value is zero.</summary>
		/// <param name="centerY">
		///   <para>Type: <b>float</b></para>
		///   <para>The new y-coordinate of the center point.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>centerY</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the CenterY property was previously animated, this method removes the animation and sets the CenterY property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform3d-setcentery(float)
		// HRESULT SetCenterY( [in] float centerY );
		void SetCenterY(float centerY);

		/// <summary>Animates the value of the CenterZ property of a 3D rotation transform. The CenterZ property specifies the z-coordinate of the point about which the rotation is performed. The default value is zero.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the CenterZ property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the CenterZ property unless this method is called again. If the CenterZ property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform3d-setcenterz(idcompositionanimation)
		// HRESULT SetCenterZ( [in] IDCompositionAnimation *animation );
		void SetCenterZ([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the CenterZ property of a 3D rotation transform. The CenterZ property specifies the z-coordinate of the point about which the rotation is performed. The default value is zero.</summary>
		/// <param name="centerZ">
		///   <para>Type: <b>float</b></para>
		///   <para>The new z-coordinate of the center point.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>centerZ</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the CenterZ property was previously animated, this method removes the animation and sets the CenterZ property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrotatetransform3d-setcenterz(float)
		// HRESULT SetCenterZ( [in] float centerZ );
		void SetCenterZ(float centerZ);
	}

	/// <summary>Represents an arbitrary 3D transformation defined by a 4-by-4 matrix.</summary>
	/// <remarks>
	/// <para>A 3D matrix transform represents the following 4-by-4 matrix:</para>
	/// <para>The application can set any of the values in the first three columns. Note that the fourth column is padded to allow for matrix concatenation.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionmatrixtransform3d
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionMatrixTransform3D")]
	[ComImport, Guid("4B3363F0-643B-41b7-B6E0-CCF22D34467C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionMatrixTransform3D : IDCompositionTransform3D
	{
		/// <summary>Changes all values of the matrix of this 3D transformation effect.</summary>
		/// <param name="matrix">
		///   <para>Type: <b>const <c>D3DMATRIX</c></b></para>
		///   <para>The new matrix for this 3D transformation effect.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if any of the matrix values are NaN, positive infinity, or negative infinity.</para>
		///   <para>If any of the matrix elements were previously animated, this method removes the animations and sets the elements to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionmatrixtransform3d-setmatrix
		// HRESULT SetMatrix( [ref] const D3DMATRIX &amp; matrix );
		void SetMatrix(in D2D_MATRIX_4X4_F matrix);

		/// <summary>Animates the value of one element of the matrix of this 3D transform.</summary>
		/// <param name="row">
		///   <para>Type: <b>int</b></para>
		///   <para>The row index of the element to change. This value must be between 0 and 3, inclusive.</para>
		/// </param>
		/// <param name="column">
		///   <para>Type: <b>int</b></para>
		///   <para>The column index of the element to change. This value must be between 0 and 3, inclusive.</para>
		/// </param>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the value of the specified element changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the specified element unless this method is called again. If the specified element was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected transform. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionmatrixtransform3d-setmatrixelement(int_int_idcompositionanimation)
		// HRESULT SetMatrixElement( [in] int row, [in] int column, [in] IDCompositionAnimation *animation );
		void SetMatrixElement(int row, int column, [In] IDCompositionAnimation animation);

		/// <summary>Changes the value of one element of the matrix of this 3D transform.</summary>
		/// <param name="row">
		///   <para>Type: <b>int</b></para>
		///   <para>The row index of the element to change. This value must be between 0 and 3, inclusive.</para>
		/// </param>
		/// <param name="column">
		///   <para>Type: <b>int</b></para>
		///   <para>The column index of the element to change. This value must be between 0 and 3, inclusive.</para>
		/// </param>
		/// <param name="value">
		///   <para>Type: <b>float</b></para>
		///   <para>The new value of the specified element.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>value</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the specified element was previously animated, this method removes the animation and sets the element to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionmatrixtransform3d-setmatrixelement(int_int_float)
		// HRESULT SetMatrixElement( [in] int row, [in] int column, [in] float value );
		void SetMatrixElement(int row, int column, [In] float value);
	}

	/// <summary>Represents a clip object that is used to restrict the rendering of a visual subtree to a rectangular area.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionclip
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionClip")]
	[ComImport, Guid("64AC3703-9D3F-45ec-A109-7CAC0E7A13A7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionClip
	{
	}

	/// <summary>Represents a clip object that restricts the rendering of a visual subtree to the specified rectangular region. Optionally, the clip object may have rounded corners specified.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionrectangleclip
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionRectangleClip")]
	[ComImport, Guid("9842AD7D-D9CF-4908-AED7-48B51DA5E7C2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionRectangleClip : IDCompositionClip
	{
		/// <summary>Animates the value of the Left property of a clip rectangle. The Left property specifies the x-coordinate of the upper-left corner of the clip rectangle.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the Left property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the Left property unless this method is called again. If the Left property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-setleft(idcompositionanimation)
		// HRESULT SetLeft( [in] IDCompositionAnimation *animation );
		void SetLeft([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the Left property of a clip rectangle. The Left property specifies the x-coordinate of the upper-left corner of the clip rectangle.</summary>
		/// <param name="left">
		///   <para>Type: <b>float</b></para>
		///   <para>The new value of the Left property, in pixels. This parameter has a numerical limit of -2^21 to 2^21. The API accepts numbers outside of this range, but they are always clamped to this range.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>left</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the Left property was previously animated, this method removes the animation and sets the Left property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-setleft(float)
		// HRESULT SetLeft( [in] float left );
		void SetLeft(float left);

		/// <summary>Animates the value of the TopLeftRadiusY property of this clip. The TopLeftRadiusY property specifies the y radius of the ellipse that rounds the top-left corner of the clip.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the y radius changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the y radius unless this method is called again. If the y radius was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-settopleftradiusy(idcompositionanimation)
		// HRESULT SetTopLeftRadiusY( [in] IDCompositionAnimation *animation );
		void SetTop([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the Top property of a clip rectangle. The Top property specifies the y-coordinate of the upper-left corner of the clip rectangle.</summary>
		/// <param name="top">
		///   <para>Type: <b>float</b></para>
		///   <para>The new value of the Top property, in pixels. This parameter has a numerical limit of -2^21 to 2^21. The API accepts numbers outside of this range, but they are always clamped to this range.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>top</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the Top property was previously animated, this method removes the animation and sets the Top property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-settop(float)
		// HRESULT SetTop( [in] float top );
		void SetTop(float top);

		/// <summary>Animates the value of the Right property of a clip rectangle. The Right property specifies the x-coordinate of the lower-right corner of the clip rectangle.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the Right property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the Right property unless this method is called again. If the Right property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-setright(idcompositionanimation)
		// HRESULT SetRight( [in] IDCompositionAnimation *animation );
		void SetRight([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the Right property of a clip rectangle. The Right property specifies the x-coordinate of the lower-right corner of the clip rectangle.</summary>
		/// <param name="right">
		///   <para>Type: <b>float</b></para>
		///   <para>The new value of the Right property, in pixels. This parameter has a numerical limit of -2^21 to 2^21. The API accepts numbers outside of this range, but they are always clamped to this range.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>right</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the Right property was previously animated, this method removes the animation and sets the Right property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-setright(float)
		// HRESULT SetRight( [in] float right );
		void SetRight(float right);

		/// <summary>Animates the value of the Bottom property of a clip rectangle. The Bottom property specifies the y-coordinate of the lower-right corner of the clip rectangle.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the Bottom property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the Bottom property unless this method is called again. If the Bottom property was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-setbottom(idcompositionanimation)
		// HRESULT SetBottom( [in] IDCompositionAnimation *animation );
		void SetBottom([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the Bottom property of a clip object. The Bottom property specifies the y-coordinate of the lower-right corner of the clip rectangle.</summary>
		/// <param name="bottom">
		///   <para>Type: <b>float</b></para>
		///   <para>The new value of the Bottom property, in pixels. This parameter has a numerical limit of -2^21 to 2^21. The API accepts numbers outside of this range, but they are always clamped to this range.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>bottom</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>If the Bottom property was previously animated, this method removes the animation and sets the Bottom property to the specified static value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-setbottom(float)
		// HRESULT SetBottom( [in] float bottom );
		void SetBottom(float bottom);

		/// <summary>Animates the value of the TopLeftRadiusX property of this clip. The TopLeftRadiusX property specifies the x radius of the ellipse that rounds the top-left corner of the clip.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the x radius changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the x radius unless this method is called again. If the x radius was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-settopleftradiusx(idcompositionanimation)
		// HRESULT SetTopLeftRadiusX( [in] IDCompositionAnimation *animation );
		void SetTopLeftRadiusX([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the TopLeftRadiusX property of this clip. The TopLeftRadiusX property specifies the x radius of the ellipse that rounds the top-left corner of the clip.</summary>
		/// <param name="radius">
		///   <para>Type: <b><c>float</c>*</b></para>
		///   <para>The new value of the top-left x radius, in pixels.</para>
		/// </param>
		void SetTopLeftRadiusX(float radius);

		/// <summary>Animates the value of the TopLeftRadiusY property of this clip. The TopLeftRadiusY property specifies the y radius of the ellipse that rounds the top-left corner of the clip.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the y radius changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the y radius unless this method is called again. If the y radius was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-settopleftradiusy(idcompositionanimation)
		// HRESULT SetTopLeftRadiusY( [in] IDCompositionAnimation *animation );
		void SetTopLeftRadiusY([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the TopLeftRadiusY property of this clip. The TopLeftRadiusY property specifies the x radius of the ellipse that rounds the top-left corner of the clip.</summary>
		/// <param name="radius">
		///   <para>Type: <b><c>float</c>*</b></para>
		///   <para>The new value of the top-left y radius, in pixels.</para>
		/// </param>
		void SetTopLeftRadiusY(float radius);

		/// <summary>Animates the value of the TopRightRadiusX property of this clip. The TopRightRadiusX property specifies the x radius of the ellipse that rounds the top-right corner of the clip.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the x radius changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the x radius unless this method is called again. If the x radius was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-settoprightradiusx(idcompositionanimation)
		// HRESULT SetTopRightRadiusX( [in] IDCompositionAnimation *animation );
		void SetTopRightRadiusX([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the TopRightRadiusX property of this clip. The TopRightRadiusX property specifies the x radius of the ellipse that rounds the top-right corner of the clip.</summary>
		/// <param name="radius">
		///   <para>Type: <b><c>float</c>*</b></para>
		///   <para>The new value of the top-right x radius, in pixels.</para>
		/// </param>
		void SetTopRightRadiusX(float radius);

		/// <summary>Animates the value of the TopRightRadiusY property of this clip. The TopRightRadiusY property specifies the y radius of the ellipse that rounds the top-right corner of the clip.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the y radius changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the y radius unless this method is called again. If the y radius was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-settoprightradiusy(idcompositionanimation)
		// HRESULT SetTopRightRadiusY( [in] IDCompositionAnimation *animation );
		void SetTopRightRadiusY([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the TopRightRadiusY property of this clip. The TopRightRadiusY property specifies the y radius of the ellipse that rounds the top-right corner of the clip.</summary>
		/// <param name="radius">
		///   <para>Type: <b><c>float</c>*</b></para>
		///   <para>The new value of the top-right y radius, in pixels.</para>
		/// </param>
		void SetTopRightRadiusY(float radius);

		/// <summary>Animates the value of the BottomLeftRadiusX property of this clip. The BottomLeftRadiusX property specifies the x radius of the ellipse that rounds the lower-left corner of the clip.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the x radius changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the x radius unless this method is called again. If the x radius was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-setbottomleftradiusx(idcompositionanimation)
		// HRESULT SetBottomLeftRadiusX( [in] IDCompositionAnimation *animation );
		void SetBottomLeftRadiusX([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the BottomLeftRadiusX property of this clip. The BottomLeftRadiusX property specifies the x radius of the ellipse that rounds the bottom-left corner of the clip.</summary>
		/// <param name="radius">
		///   <para>Type: <b><c>float</c>*</b></para>
		///   <para>The new value of the bottom-left x radius, in pixels.</para>
		/// </param>
		void SetBottomLeftRadiusX(float radius);

		/// <summary>Animates the value of the BottomLeftRadiusY property of this clip. The BottomLeftRadiusY property specifies the y radius of the ellipse that rounds the lower-left corner of the clip.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the y radius changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the y radius unless this method is called again. If the y radius was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-setbottomleftradiusy(idcompositionanimation)
		// HRESULT SetBottomLeftRadiusY( [in] IDCompositionAnimation *animation );
		void SetBottomLeftRadiusY([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the BottomLeftRadiusY property of this clip. The BottomLeftRadiusY property specifies the y radius of the ellipse that rounds the bottom-left corner of the clip.</summary>
		/// <param name="radius">
		///   <para>Type: <b><c>float</c>*</b></para>
		///   <para>The new value of the bottom-left y radius, in pixels.</para>
		/// </param>
		void SetBottomLeftRadiusY(float radius);

		/// <summary>Animates the value of the BottomRightRadiusX property of this clip. The BottomRightRadiusX property specifies the x radius of the ellipse that rounds the lower-right corner of the clip.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the x radius changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the x radius unless this method is called again. If the x radius was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-setbottomrightradiusx(idcompositionanimation)
		// HRESULT SetBottomRightRadiusX( [in] IDCompositionAnimation *animation );
		void SetBottomRightRadiusX([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the BottomRightRadiusX property of this clip. The BottomRightRadiusX property specifies the x radius of the ellipse that rounds the bottom-right corner of the clip.</summary>
		/// <param name="radius">
		///   <para>Type: <b><c>float</c>*</b></para>
		///   <para>The new value of the bottom-right x radius, in pixels.</para>
		/// </param>
		void SetBottomRightRadiusX(float radius);

		/// <summary>Animates the value of the BottomRightRadiusY property of this clip. The BottomRightRadiusY property specifies the y radius of the ellipse that rounds the lower-right corner of the clip.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the y radius changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the object referenced by the <i>animation</i> parameter is changed after calling this method, the change does not affect the y radius unless this method is called again. If the y radius was previously animated, calling this method replaces the previous animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as the affected visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionrectangleclip-setbottomrightradiusy(idcompositionanimation)
		// HRESULT SetBottomRightRadiusY( [in] IDCompositionAnimation *animation );
		void SetBottomRightRadiusY([In] IDCompositionAnimation animation);

		/// <summary>Changes the value of the BottomRightRadiusY property of this clip. The BottomRightRadiusY property specifies the y radius of the ellipse that rounds the bottom-right corner of the clip.</summary>
		/// <param name="radius">
		///   <para>Type: <b><c>float</c>*</b></para>
		///   <para>The new value of the bottom-right y radius, in pixels.</para>
		/// </param>
		void SetBottomRightRadiusY(float radius);
	}

	/// <summary>Represents a physical bitmap that can be associated with a visual for composition in a visual tree. This interface can also be used to update the bitmap contents.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionsurface
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionSurface")]
	[ComImport, Guid("BB8A4953-2C99-4F5A-96F5-4819027FA3AC"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionSurface
	{
		/// <summary>Initiates drawing on this Microsoft DirectComposition surface object. The update rectangle must be within the boundaries of the surface; otherwise, this method fails.</summary>
		/// <param name="updateRect">
		///   <para>Type: <b>const <c>RECT</c>*</b></para>
		///   <para>The rectangle to be updated. If this parameter is NULL, the entire bitmap is updated.</para>
		/// </param>
		/// <param name="iid">
		///   <para>Type: <b>REFIID</b></para>
		///   <para>The identifier of the interface to retrieve.</para>
		/// </param>
		/// <param name="updateObject">
		///   <para>Type: <b>void**</b></para>
		///   <para>Receives an interface pointer of the type specified in the <i>iid</i> parameter. This parameter must not be NULL.</para>
		///   <para>
		///     <b>Note</b>  In Windows 8, this parameter was <i>surface</i>.</para>
		///   <para> </para>
		/// </param>
		/// <param name="updateOffset">
		///   <para>Type: <b><c>POINT</c>*</b></para>
		///   <para>The offset into the surface where the application should draw updated content. This offset will reference the upper left corner of the update rectangle.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>HRESULT</c></b></para>
		///   <para>If the function succeeds, it returns S_OK. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		/// <remarks>
		///   <para>This method enables an application to incrementally update the contents of a DirectComposition surface object. The application must use the following sequence:</para>
		///   <list type="number">
		///     <item>
		///       <description>Call <b>BeginDraw</b> to initiate the incremental update.</description>
		///     </item>
		///     <item>
		///       <description>Use the retrieved surface as a render target and draw the updated contents at the retrieved offset.</description>
		///     </item>
		///     <item>
		///       <description>Call the <c>IDCompositionSurface::EndDraw</c> method to finish the update.</description>
		///     </item>
		///   </list>
		///   <para>The update object returned by this method is either a Direct2D device context or a DXGI surface, depending on the value of the <i>iid</i> parameter and on how the DirectComposition surface object was created. If the <i>iid</i> parameter is __uuidof(ID2D1DeviceContext), then the returned object is a Direct2D device context that already has the DirectComposition surface selected as a render target. Otherwise, it is a DXGI surface which the application may use as a render target. In either case, the returned object is associated with the Direct2D or DXGI device passed by the application to the DCompositionCreateDevice2 function or the <c>IDCompositionDevice2::CreateSurfaceFactory</c> method.</para>
		///   <para>The <i>iid</i> parameter may only be __uuidof(ID2D1DeviceContext) if the DirectComposition surface object was created from a DirectComposition device or surface factory that was, itself, created with an associated Direct2D device. In particular, the application must have called either the DCompositionCreateDevice2 function or the <c>IDCompositionDevice2::CreateSurfaceFactory</c> method with a Direct2D device as the <i>renderingDevice</i> parameter. If the DirectComposition surface was created via a surface factory that was not associated with a Direct2D device, or if it was created directly via the IDCompositionDevice2 interface and the device was not directly associated with a Direct2D device, then passing __uuidof(ID2D1DeviceContext) as the iid parameter causes this method to return E_INVALIDARG.</para>
		///   <para>If the application successfully retrieves a Direct2D device context as the update object, then the application should not call either the ID2D1DeviceContext::BeginDraw or ID2D1DeviceContext::EndDraw methods on the returned Direct2D device context.</para>
		///   <para>The retrieved offset is not necessarily the same as the top-left corner of the requested update rectangle. The application must transform its rendering primitives to draw within a rectangle of the same width and height as the input rectangle, but at the given offset. The application should not draw outside of this rectangle.</para>
		///   <para>If the <i>updateRectangle</i> parameter is NULL, the entire surface is updated. In that case, because the retrieved offset still might not be (0,0), the application still needs to transform its rendering primitives accordingly.</para>
		///   <para>If the surface is not a virtual surface, then the first time the application calls this method for a particular non-virtual surface, the update rectangle must cover the entire surface, either by specifying the full surface in the requested update rectangle, or by specifying NULL as the <i>updateRectangle</i> parameter. For virtual surfaces, the first call may be any sub-rectangle of the surface.</para>
		///   <para>Because each call to this method might retrieve a different object in the <i>updateObject</i> surface, the application should not cache the retrieved surface pointer. The application should release the retrieved pointer as soon as it finishes drawing.</para>
		///   <para>The retrieved surface rectangle does not contain the previous contents of the bitmap. The application must update every pixel in the update rectangle, either by first clearing the render target, or by issuing enough rendering primitives to fully cover the update rectangle. Because the initial contents of the update surface are undefined, failing to update every pixel leads to undefined behavior.</para>
		///   <para>Only one DirectComposition surface can be updated at a time. An application must suspend drawing on one surface before beginning or resuming to draw on another surface. If the application calls <b>BeginDraw</b> twice, either for the same surface or for another surface belonging to the same DirectComposition device, without an intervening call to <c>IDCompositionSurface::EndDraw</c>, the second call fails. If the application calls <c>IDCompositionDevice2::Commit</c> without calling <b>EndDraw</b>, the update remains pending. The update takes effect only after the application calls <b>EndDraw</b> and then calls the <b>IDCompositionDevice2::Commit</b> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionsurface-begindraw
		// HRESULT BeginDraw( [in, optional] const RECT *updateRect, [in] REFIID iid, [out] void **updateObject, [out] POINT *updateOffset );
		[PreserveSig]
		HRESULT BeginDraw([In, Optional] PRECT? updateRect, in Guid iid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? updateObject, out POINT updateOffset);

		/// <summary>Marks the end of drawing on this Microsoft DirectComposition surface object.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns S_OK. Otherwise, it returns an <b>HRESULT</b> error code, which can include <c>DCOMPOSITION_ERROR_SURFACE_NOT_BEING_RENDERED</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method completes an update that was begun by a previous call to the <c>IDCompositionSurface::BeginDraw</c> method. After this method returns, the application can start another update on the same surface object or on a different one.</para>
		/// <para>If the application calls <c>IDCompositionDevice2::Commit</c> before calling <b>IDCompositionSurface::EndDraw</b> for a surface with a pending update, that update is not processed by that Commit call. The update only takes effect on screen after the application calls <b>IDCompositionSurface::EndDraw</b> followed by the IDCompositionDevice2::Commit method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionsurface-enddraw
		// HRESULT EndDraw();
		[PreserveSig]
		HRESULT EndDraw();

		/// <summary>Suspends the drawing on this Microsoft DirectComposition surface object.</summary>
		/// <returns>If the function succeeds, it returns S_OK. Otherwise, it returns an <b>HRESULT</b> error code, which can include <c>DCOMPOSITION_ERROR_SURFACE_BEING_RENDERED</c> and <c>DCOMPOSITION_ERROR_SURFACE_NOT_BEING_RENDERED</c>.</returns>
		/// <remarks>Because only one surface can be open for drawing at a time, calling <b>SuspendDraw</b> allows the user to call <c>IDCompositionSurface::BeginDraw</c> on a different surface. Drawing to this surface can be resumed by calling <c>IDCompositionSurface::ResumeDraw</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionsurface-suspenddraw
		// HRESULT SuspendDraw();
		[PreserveSig]
		HRESULT SuspendDraw();

		/// <summary>Resumes drawing on this Microsoft DirectComposition surface object.</summary>
		/// <returns>If the function succeeds, it returns S_OK. Otherwise, it returns an <b>HRESULT</b> error code, which can include <c>DCOMPOSITION_ERROR_SURFACE_BEING_RENDERED</c> and <c>DCOMPOSITION_ERROR_SURFACE_NOT_BEING_RENDERED</c>.</returns>
		/// <remarks>This method allows the surface update to continue unless there are other surfaces that have active, unsuspended draws.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionsurface-resumedraw
		// HRESULT ResumeDraw();
		[PreserveSig]
		HRESULT ResumeDraw();

		/// <summary>Scrolls a rectangular area of a Microsoft DirectComposition logical surface.</summary>
		/// <param name="scrollRect">The rectangular area of the surface to be scrolled, relative to the upper-left corner of the surface. If this parameter is NULL, the entire surface is scrolled.</param>
		/// <param name="clipRect">The <i>clipRect</i> clips the destination (<i>scrollRect</i> after offset) of the scroll. The only bitmap content that will be scrolled are those that remain inside the clip rectangle after the scroll is completed.</param>
		/// <param name="offsetX">The amount of horizontal scrolling, in pixels. Use positive values to scroll right, and negative values to scroll left.</param>
		/// <param name="offsetY">The amount of vertical scrolling, in pixels. Use positive values to scroll down, and negative values to scroll up.</param>
		/// <remarks>
		///   <para>This method allows an application to blt/copy a sub-rectangle of a DirectComposition surface object. This avoids re-rendering content that is already available.</para>
		///   <para>The <i>scrollRect</i> rectangle must be contained in the boundaries of the surface. If the <i>scrollRect</i> rectangle goes outside the bounds of the surface, this method fails.</para>
		///   <para>The bits copied by the scroll operation (source) are defined by the intersection of the <i>scrollRect</i> and <i>clipRect</i> rectangles.</para>
		///   <para>The bits shown on the screen (destination) are defined by the intersection of the offset source rectangle and <i>clipRect</i>.</para>
		///   <para>Scroll operations can only be called before calling <c>BeginDraw</c> or after calling <c>EndDraw</c>. Suspended or resumed surfaces are not candidates for scrolling because they are still being updated.</para>
		///   <para>The application is responsible for ensuring that the scrollable area for an <c>IDCompositionVirtualSurface</c> is limited to valid pixels. The behavior for invalid pixels in the <i>scrollRect</i> is undefined.</para>
		///   <para>Virtual surface sub-rectangular areas that were discarded by a trim or a resize operation can't be scrolled even if the trim or resize is applied in the same batch. <c>Trim</c> and <c>Resize</c> are applied immediately.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionsurface-scroll
		// HRESULT Scroll( [in] const RECT *scrollRect, [in, optional] const RECT *clipRect, [in] int offsetX, [in] int offsetY );
		void Scroll([In, Optional] PRECT? scrollRect, [In, Optional] PRECT? clipRect, int offsetX, int offsetY);
	}

	/// <summary>Represents a sparsely allocated bitmap that can be associated with a visual for composition in a visual tree.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionvirtualsurface
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionVirtualSurface")]
	[ComImport, Guid("AE471C51-5F53-4A24-8D3E-D0C39C30B3F0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionVirtualSurface : IDCompositionSurface
	{
		/// <summary>Initiates drawing on this Microsoft DirectComposition surface object. The update rectangle must be within the boundaries of the surface; otherwise, this method fails.</summary>
		/// <param name="updateRect">
		///   <para>Type: <b>const <c>RECT</c>*</b></para>
		///   <para>The rectangle to be updated. If this parameter is NULL, the entire bitmap is updated.</para>
		/// </param>
		/// <param name="iid">
		///   <para>Type: <b>REFIID</b></para>
		///   <para>The identifier of the interface to retrieve.</para>
		/// </param>
		/// <param name="updateObject">
		///   <para>Type: <b>void**</b></para>
		///   <para>Receives an interface pointer of the type specified in the <i>iid</i> parameter. This parameter must not be NULL.</para>
		///   <para>
		///     <b>Note</b>  In Windows 8, this parameter was <i>surface</i>.</para>
		///   <para> </para>
		/// </param>
		/// <param name="updateOffset">
		///   <para>Type: <b><c>POINT</c>*</b></para>
		///   <para>The offset into the surface where the application should draw updated content. This offset will reference the upper left corner of the update rectangle.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>HRESULT</c></b></para>
		///   <para>If the function succeeds, it returns S_OK. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		/// <remarks>
		///   <para>This method enables an application to incrementally update the contents of a DirectComposition surface object. The application must use the following sequence:</para>
		///   <list type="number">
		///     <item>
		///       <description>Call <b>BeginDraw</b> to initiate the incremental update.</description>
		///     </item>
		///     <item>
		///       <description>Use the retrieved surface as a render target and draw the updated contents at the retrieved offset.</description>
		///     </item>
		///     <item>
		///       <description>Call the <c>IDCompositionSurface::EndDraw</c> method to finish the update.</description>
		///     </item>
		///   </list>
		///   <para>The update object returned by this method is either a Direct2D device context or a DXGI surface, depending on the value of the <i>iid</i> parameter and on how the DirectComposition surface object was created. If the <i>iid</i> parameter is __uuidof(ID2D1DeviceContext), then the returned object is a Direct2D device context that already has the DirectComposition surface selected as a render target. Otherwise, it is a DXGI surface which the application may use as a render target. In either case, the returned object is associated with the Direct2D or DXGI device passed by the application to the DCompositionCreateDevice2 function or the <c>IDCompositionDevice2::CreateSurfaceFactory</c> method.</para>
		///   <para>The <i>iid</i> parameter may only be __uuidof(ID2D1DeviceContext) if the DirectComposition surface object was created from a DirectComposition device or surface factory that was, itself, created with an associated Direct2D device. In particular, the application must have called either the DCompositionCreateDevice2 function or the <c>IDCompositionDevice2::CreateSurfaceFactory</c> method with a Direct2D device as the <i>renderingDevice</i> parameter. If the DirectComposition surface was created via a surface factory that was not associated with a Direct2D device, or if it was created directly via the IDCompositionDevice2 interface and the device was not directly associated with a Direct2D device, then passing __uuidof(ID2D1DeviceContext) as the iid parameter causes this method to return E_INVALIDARG.</para>
		///   <para>If the application successfully retrieves a Direct2D device context as the update object, then the application should not call either the ID2D1DeviceContext::BeginDraw or ID2D1DeviceContext::EndDraw methods on the returned Direct2D device context.</para>
		///   <para>The retrieved offset is not necessarily the same as the top-left corner of the requested update rectangle. The application must transform its rendering primitives to draw within a rectangle of the same width and height as the input rectangle, but at the given offset. The application should not draw outside of this rectangle.</para>
		///   <para>If the <i>updateRectangle</i> parameter is NULL, the entire surface is updated. In that case, because the retrieved offset still might not be (0,0), the application still needs to transform its rendering primitives accordingly.</para>
		///   <para>If the surface is not a virtual surface, then the first time the application calls this method for a particular non-virtual surface, the update rectangle must cover the entire surface, either by specifying the full surface in the requested update rectangle, or by specifying NULL as the <i>updateRectangle</i> parameter. For virtual surfaces, the first call may be any sub-rectangle of the surface.</para>
		///   <para>Because each call to this method might retrieve a different object in the <i>updateObject</i> surface, the application should not cache the retrieved surface pointer. The application should release the retrieved pointer as soon as it finishes drawing.</para>
		///   <para>The retrieved surface rectangle does not contain the previous contents of the bitmap. The application must update every pixel in the update rectangle, either by first clearing the render target, or by issuing enough rendering primitives to fully cover the update rectangle. Because the initial contents of the update surface are undefined, failing to update every pixel leads to undefined behavior.</para>
		///   <para>Only one DirectComposition surface can be updated at a time. An application must suspend drawing on one surface before beginning or resuming to draw on another surface. If the application calls <b>BeginDraw</b> twice, either for the same surface or for another surface belonging to the same DirectComposition device, without an intervening call to <c>IDCompositionSurface::EndDraw</c>, the second call fails. If the application calls <c>IDCompositionDevice2::Commit</c> without calling <b>EndDraw</b>, the update remains pending. The update takes effect only after the application calls <b>EndDraw</b> and then calls the <b>IDCompositionDevice2::Commit</b> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionsurface-begindraw
		// HRESULT BeginDraw( [in, optional] const RECT *updateRect, [in] REFIID iid, [out] void **updateObject, [out] POINT *updateOffset );
		[PreserveSig]
		new HRESULT BeginDraw([In, Optional] PRECT? updateRect, in Guid iid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? updateObject, out POINT updateOffset);

		/// <summary>Marks the end of drawing on this Microsoft DirectComposition surface object.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns S_OK. Otherwise, it returns an <b>HRESULT</b> error code, which can include <c>DCOMPOSITION_ERROR_SURFACE_NOT_BEING_RENDERED</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method completes an update that was begun by a previous call to the <c>IDCompositionSurface::BeginDraw</c> method. After this method returns, the application can start another update on the same surface object or on a different one.</para>
		/// <para>If the application calls <c>IDCompositionDevice2::Commit</c> before calling <b>IDCompositionSurface::EndDraw</b> for a surface with a pending update, that update is not processed by that Commit call. The update only takes effect on screen after the application calls <b>IDCompositionSurface::EndDraw</b> followed by the IDCompositionDevice2::Commit method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionsurface-enddraw
		// HRESULT EndDraw();
		[PreserveSig]
		new HRESULT EndDraw();

		/// <summary>Suspends the drawing on this Microsoft DirectComposition surface object.</summary>
		/// <returns>If the function succeeds, it returns S_OK. Otherwise, it returns an <b>HRESULT</b> error code, which can include <c>DCOMPOSITION_ERROR_SURFACE_BEING_RENDERED</c> and <c>DCOMPOSITION_ERROR_SURFACE_NOT_BEING_RENDERED</c>.</returns>
		/// <remarks>Because only one surface can be open for drawing at a time, calling <b>SuspendDraw</b> allows the user to call <c>IDCompositionSurface::BeginDraw</c> on a different surface. Drawing to this surface can be resumed by calling <c>IDCompositionSurface::ResumeDraw</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionsurface-suspenddraw
		// HRESULT SuspendDraw();
		[PreserveSig]
		new HRESULT SuspendDraw();

		/// <summary>Resumes drawing on this Microsoft DirectComposition surface object.</summary>
		/// <returns>If the function succeeds, it returns S_OK. Otherwise, it returns an <b>HRESULT</b> error code, which can include <c>DCOMPOSITION_ERROR_SURFACE_BEING_RENDERED</c> and <c>DCOMPOSITION_ERROR_SURFACE_NOT_BEING_RENDERED</c>.</returns>
		/// <remarks>This method allows the surface update to continue unless there are other surfaces that have active, unsuspended draws.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionsurface-resumedraw
		// HRESULT ResumeDraw();
		[PreserveSig]
		new HRESULT ResumeDraw();

		/// <summary>Scrolls a rectangular area of a Microsoft DirectComposition logical surface.</summary>
		/// <param name="scrollRect">The rectangular area of the surface to be scrolled, relative to the upper-left corner of the surface. If this parameter is NULL, the entire surface is scrolled.</param>
		/// <param name="clipRect">The <i>clipRect</i> clips the destination (<i>scrollRect</i> after offset) of the scroll. The only bitmap content that will be scrolled are those that remain inside the clip rectangle after the scroll is completed.</param>
		/// <param name="offsetX">The amount of horizontal scrolling, in pixels. Use positive values to scroll right, and negative values to scroll left.</param>
		/// <param name="offsetY">The amount of vertical scrolling, in pixels. Use positive values to scroll down, and negative values to scroll up.</param>
		/// <remarks>
		///   <para>This method allows an application to blt/copy a sub-rectangle of a DirectComposition surface object. This avoids re-rendering content that is already available.</para>
		///   <para>The <i>scrollRect</i> rectangle must be contained in the boundaries of the surface. If the <i>scrollRect</i> rectangle goes outside the bounds of the surface, this method fails.</para>
		///   <para>The bits copied by the scroll operation (source) are defined by the intersection of the <i>scrollRect</i> and <i>clipRect</i> rectangles.</para>
		///   <para>The bits shown on the screen (destination) are defined by the intersection of the offset source rectangle and <i>clipRect</i>.</para>
		///   <para>Scroll operations can only be called before calling <c>BeginDraw</c> or after calling <c>EndDraw</c>. Suspended or resumed surfaces are not candidates for scrolling because they are still being updated.</para>
		///   <para>The application is responsible for ensuring that the scrollable area for an <c>IDCompositionVirtualSurface</c> is limited to valid pixels. The behavior for invalid pixels in the <i>scrollRect</i> is undefined.</para>
		///   <para>Virtual surface sub-rectangular areas that were discarded by a trim or a resize operation can't be scrolled even if the trim or resize is applied in the same batch. <c>Trim</c> and <c>Resize</c> are applied immediately.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionsurface-scroll
		// HRESULT Scroll( [in] const RECT *scrollRect, [in, optional] const RECT *clipRect, [in] int offsetX, [in] int offsetY );
		new void Scroll([In, Optional] PRECT? scrollRect, [In, Optional] PRECT? clipRect, int offsetX, int offsetY);

		/// <summary>Changes the logical size of this virtual surface object.</summary>
		/// <param name="width">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The new width of the virtual surface, in pixels. The maximum width is 16,777,216 pixels.</para>
		/// </param>
		/// <param name="height">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The new height of the virtual surface, in pixels. The maximum height is 16,777,216 pixels.</para>
		/// </param>
		/// <remarks>
		///   <para>When a virtual surface is resized, its contents are preserved up to the new boundaries of the surface. If the surface is made smaller, any previously allocated pixels that fall outside of the new width or height are discarded.</para>
		///   <para>This method fails if <c>IDCompositionSurface::BeginDraw</c> was called for this bitmap without a corresponding call to <c>IDCompositionSurface::EndDraw</c>.</para>
		///   <para>This method fails if <i>width</i> or <i>height</i> exceeds 16,777,216 pixels.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvirtualsurface-resize
		// HRESULT Resize( [in] UINT width, [in] UINT height );
		void Resize(uint width, uint height);

		/// <summary>Discards pixels that fall outside of the specified trim rectangles.</summary>
		/// <param name="rectangles">
		///   <para>Type: <b>const <c>RECT</c>*</b></para>
		///   <para>An array of rectangles to keep.</para>
		/// </param>
		/// <param name="count">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The number of rectangles in the <i>rectangles</i> array.</para>
		/// </param>
		/// <remarks>
		///   <para>A virtual surface might not have enough storage for every pixel in the surface. An application instructs the composition engine to allocate memory for the surface by calling the <c>IDCompositionSurface::BeginDraw</c> method, and to release memory for the surface by calling the <b>IDCompositionVirtualSurface::Trim</b> method. The array of rectangles represents the regions of the virtual surface that should remain allocated after this method returns. Any pixels that are outside the specified set of rectangles are no longer used for texturing, and their memory may be reclaimed.</para>
		///   <para>If the <i>count</i> parameter is zero, no pixels are kept, and all of the memory allocated for the virtual surface may be reclaimed. The <i>rectangles</i> parameter can be NULL only if the <i>count</i> parameter is zero.</para>
		///   <para>This method fails if <c>IDCompositionSurface::BeginDraw</c> was called for this bitmap without a corresponding call to <c>IDCompositionSurface::EndDraw</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvirtualsurface-trim
		// HRESULT Trim( [in, optional] const RECT *rectangles, [in] UINT count );
		void Trim([In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] RECT[]? rectangles, uint count);
	}

	/// <summary>Serves as a factory for all other Microsoft DirectComposition objects and provides methods to control transactional composition.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositiondevice2
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionDevice2")]
	[ComImport, Guid("75F6468D-1B8E-447C-9BC6-75FEA80B5B25"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.1")]
#endif
	public interface IDCompositionDevice2
	{
		/// <summary>Commits all DirectComposition commands that are pending on this device.</summary>
		/// <remarks>
		///   <para>Calls to DirectComposition methods are always batched and executed atomically as a single transaction. Calls take effect only when <b>IDCompositionDevice2::Commit</b> is called, at which time all pending method calls for a device are executed at once.</para>
		///   <para>An application that uses multiple devices must call <b>Commit</b> for each device separately. However, because the composition engine processes the calls individually, the batch of commands might not take effect at the same time.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-commit
		// HRESULT Commit();
		void Commit();

		/// <summary>Waits for the composition engine to finish processing the previous call to the <c>IDCompositionDevice2::Commit</c> method.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-waitforcommitcompletion
		// HRESULT WaitForCommitCompletion();
		void WaitForCommitCompletion();

		/// <summary>Retrieves information from the composition engine about composition times and the frame rate.</summary>
		/// <returns>
		///   <para>Type: <b><c>DCOMPOSITION_FRAME_STATISTICS</c>*</b></para>
		///   <para>A structure that receives composition times and frame rate information.</para>
		/// </returns>
		/// <remarks>This method retrieves timing information about the composition engine that an application can use to synchronize the rasterization of bitmaps with independent animations.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-getframestatistics
		// HRESULT GetFrameStatistics( [out] DCOMPOSITION_FRAME_STATISTICS *statistics );
		DCOMPOSITION_FRAME_STATISTICS GetFrameStatistics();

		/// <summary>Creates a new visual object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionVisual2</c>**</b></para>
		///   <para>The new visual object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new visual object has a static value of zero for the OffsetX and OffsetY properties, and NULL for the Transform, Clip, and Content properties. Initially, the visual does not cause the contents of a window to change. The visual must be added as a child of another visual, or as the root of a composition target, before it can affect the appearance of a window.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createvisual
		// HRESULT CreateVisual( [out] IDCompositionVisual2 **visual );
		IDCompositionVisual2 CreateVisual();

		/// <summary>Creates a Microsoft DirectComposition surface factory object, which can be used to create other DirectComposition surface or virtual surface objects</summary>
		/// <param name="renderingDevice">A pointer to a DirectX device to be used to create DirectComposition surface objects. Must be a pointer to an object implementing the <c>IDXGIDevice</c> or <c>ID2D1Device</c> interfaces. This parameter must not be NULL.</param>
		/// <returns>The newly created surface factory object. This parameter must not be NULL.</returns>
		/// <remarks>
		///   <para>A surface factory allows an application to simultaneously use more than one single DXGI or Direct2D device with DirectComposition. Each surface factory has a permanent association with one DXGI or Direct2D device, but a DirectComposition device may have any number of surface factories.</para>
		///   <para>Each surface factory manages resources independently from the others. In particular, DirectComposition pools surface allocations to mitigate surface allocation and deallocation costs. This pool is done on a per-surface factory basis.</para>
		///   <para>If the <c>DCompositionCreateDevice2</c> function is called with a non-NULL <i>renderingDevice</i> parameter, the returned DirectComposition device object has an implicit surface factory under the covers associated with the given rendering device. This implicit surface factory is used to service the <c>IDCompositionDevice::CreateSurface</c>, <c>IDCompositionDevice::CreateVirtualSurface</c>, <c>IDCompositionDevice2::CreateSurface</c> and <c>IDCompositionDevice2::CreateVirtualSurface</c> methods.</para>
		///   <para>A surface object remains alive as long as any of the surfaces or virtual surfaces that it created remain alive, either directly because the application holds a direct reference, or indirectly because one or more such surfaces are associated with one or more visual objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createsurfacefactory
		// HRESULT CreateSurfaceFactory( [in] IUnknown *renderingDevice, [out] IDCompositionSurfaceFactory **surfaceFactory );
		IDCompositionSurfaceFactory CreateSurfaceFactory([In, MarshalAs(UnmanagedType.IUnknown)] object renderingDevice);

		/// <summary>Creates an updateable surface object that can be associated with one or more visuals for composition.</summary>
		/// <param name="width">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The width of the surface, in pixels. Constrained by the <c>feature level</c> of the rendering device that was passed in at the time the DirectComposition device was created.</para>
		/// </param>
		/// <param name="height">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The height of the surface, in pixels. Constrained by the <c>feature level</c> of the rendering device that was passed in at the time the DirectComposition device was created.</para>
		/// </param>
		/// <param name="pixelFormat">
		///   <para>Type: <b><c>DXGI_FORMAT</c></b></para>
		///   <para>The pixel format of the surface.</para>
		/// </param>
		/// <param name="alphaMode">
		///   <para>Type: <b><c>DXGI_ALPHA_MODE</c></b></para>
		///   <para>The format of the alpha channel, if an alpha channel is included in the pixel format. It can be one of the following values:</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_UNSPECIFIED</b>
		///       </description>
		///       <description>The alpha channel is not specified. This value has the same effect as <b>DXGI_ALPHA_MODE_IGNORE</b>.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_PREMULTIPLIED</b>
		///       </description>
		///       <description>The color channels contain values that are premultiplied with the alpha channel.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_IGNORE</b>
		///       </description>
		///       <description>The alpha channel should be ignored and the bitmap should be rendered opaquely.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionSurface</c>**</b></para>
		///   <para>The newly created surface object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A Microsoft DirectComposition surface is a rectangular array of pixels that can be associated with a visual for composition.</para>
		///   <para>A newly created surface object is in an uninitialized state. While it is uninitialized, the surface has no effect on the composition of the visual tree. It behaves exactly like a surface that has 100% transparent pixels.</para>
		///   <para>To initialize the surface with pixel data, use the <c>IDCompositionSurface::BeginDraw</c> and <c>IDCompositionSurface::EndDraw</c> methods. The first call to this method must cover the entire surface area to provide an initial value for every pixel. Subsequent calls may specify smaller sub-rectangles of the surface to update.</para>
		///   <para>DirectComposition surfaces support the following pixel formats:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_B8G8R8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R8G8B8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R16G16B16A16_FLOAT</b>
		///       </description>
		///     </item>
		///   </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createsurface
		// HRESULT CreateSurface( [in] UINT width, [in] UINT height, [in] DXGI_FORMAT pixelFormat, [in] DXGI_ALPHA_MODE alphaMode, [out] IDCompositionSurface **surface );
		IDCompositionSurface CreateSurface(uint width, uint height, [In] DXGI_FORMAT pixelFormat, [In] DXGI_ALPHA_MODE alphaMode);

		/// <summary>Creates a sparsely populated surface that can be associated with one or more visuals for composition.</summary>
		/// <param name="initialWidth">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The width of the surface, in pixels. The maximum width is 16,777,216 pixels.</para>
		/// </param>
		/// <param name="initialHeight">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The height of the surface, in pixels. The maximum height is 16,777,216 pixels.</para>
		/// </param>
		/// <param name="pixelFormat">
		///   <para>Type: <b><c>DXGI_FORMAT</c></b></para>
		///   <para>The pixel format of the surface.</para>
		/// </param>
		/// <param name="alphaMode">
		///   <para>Type: <b><c>DXGI_ALPHA_MODE</c></b></para>
		///   <para>The meaning of the alpha channel, if the pixel format contains an alpha channel. It can be one of the following values:</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_UNSPECIFIED</b>
		///       </description>
		///       <description>The alpha channel is not specified. This value has the same effect as <b>DXGI_ALPHA_MODE_IGNORE</b>.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_PREMULTIPLIED</b>
		///       </description>
		///       <description>The color channels contain values that are premultiplied with the alpha channel.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_IGNORE</b>
		///       </description>
		///       <description>The alpha channel should be ignored and the bitmap should be rendered opaquely.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionVirtualSurface</c>**</b></para>
		///   <para>The newly created surface object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A Microsoft DirectComposition sparse surface is a logical object that behaves like a rectangular array of pixels that can be associated with a visual for composition. The surface is not necessarily backed by any physical video or system memory for every one of its pixels. The application can realize or virtualize parts of the logical surface at different times.</para>
		///   <para>A newly created surface object is in an uninitialized state. While it is uninitialized, the surface has no effect on the composition of the visual tree. It behaves exactly like a surface that is initialized with 100% transparent pixels.</para>
		///   <para>To initialize the surface with pixel data, use the <c>IDCompositionSurface::BeginDraw</c> and <c>IDCompositionSurface::EndDraw</c> methods. This method not only provides pixels for the surface, but it also allocates actual storage space for those pixels. The memory allocation persists until the application returns some of the memory to the system. The application can free part or all of the allocated memory by calling the <c>IDCompositionVirtualSurface::Trim</c> method.</para>
		///   <para>DirectComposition surfaces support the following pixel formats:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_B8G8R8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R8G8B8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R16G16B16A16_FLOAT</b>
		///       </description>
		///     </item>
		///   </list>
		///   <para>This method fails if <i>initialWidth</i> or <i>initialHeight</i> exceeds 16,777,216 pixels.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createvirtualsurface
		// HRESULT CreateVirtualSurface( [in] UINT initialWidth, [in] UINT initialHeight, [in] DXGI_FORMAT pixelFormat, [in] DXGI_ALPHA_MODE alphaMode, [out] IDCompositionVirtualSurface **virtualSurface );
		IDCompositionVirtualSurface CreateVirtualSurface(uint initialWidth, uint initialHeight, [In] DXGI_FORMAT pixelFormat, [In] DXGI_ALPHA_MODE alphaMode);

		/// <summary>Creates a 2D translation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTranslateTransform</c>**</b></para>
		///   <para>The new 2D translation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D translation transform object has a static value of zero for the OffsetX and OffsetY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtranslatetransform
		// HRESULT CreateTranslateTransform( [out] IDCompositionTranslateTransform **translateTransform );
		IDCompositionTranslateTransform CreateTranslateTransform();

		/// <summary>Creates a 2D scale transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionScaleTransform</c>**</b></para>
		///   <para>The new 2D scale transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D scale transform object has a static value of zero for the ScaleX, ScaleY, CenterX, and CenterY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createscaletransform
		// HRESULT CreateScaleTransform( [out] IDCompositionScaleTransform **scaleTransform );
		IDCompositionScaleTransform CreateScaleTransform();

		/// <summary>Creates a 2D rotation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionRotateTransform</c>**</b></para>
		///   <para>The new rotation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D rotation transform object has a static value of zero for the Angle, CenterX, and CenterY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createrotatetransform
		// HRESULT CreateRotateTransform( [out] IDCompositionRotateTransform **rotateTransform );
		IDCompositionRotateTransform CreateRotateTransform();

		/// <summary>Creates a 2D skew transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionSkewTransform</c>**</b></para>
		///   <para>The new 2D skew transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D skew transform object has a static value of zero for the AngleX, AngleY, CenterX, and CenterY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createskewtransform
		// HRESULT CreateSkewTransform( [out] IDCompositionSkewTransform **skewTransform );
		IDCompositionSkewTransform CreateSkewTransform();

		/// <summary>Creates a 2D 3-by-2 matrix transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionMatrixTransform</c>**</b></para>
		///   <para>The new matrix transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A new matrix transform object has the identity matrix as its initial value. The identity matrix is the 3x2 matrix with ones on the main diagonal and zeros elsewhere, as shown in the following illustration.</para>
		///   <para>When an identity transform is applied to an object, it does not change the position, shape, or size of the object. It is similar to the way that multiplying a number by one does not change the number. Any transform other than the identity transform will modify the position, shape, and/or size of objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-creatematrixtransform
		// HRESULT CreateMatrixTransform( [out] IDCompositionMatrixTransform **matrixTransform );
		IDCompositionMatrixTransform CreateMatrixTransform();

		/// <summary>Creates a 2D transform group object that holds an array of 2D transform objects.</summary>
		/// <param name="transforms">
		///   <para>Type: <b><c>IDCompositionTransform</c>**</b></para>
		///   <para>An array of 2D transform objects that make up this transform group.</para>
		/// </param>
		/// <param name="elements">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The number of elements in the <i>transforms</i> array.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTransform</c>**</b></para>
		///   <para>The new transform group object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>The array entries in a transform group cannot be changed. However, each transform in the array can be modified through its own property setting methods. If a transform in the array is modified, the change is reflected in the computed matrix of the transform group.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtransformgroup
		// HRESULT CreateTransformGroup( [in] IDCompositionTransform **transforms, [in] UINT elements, [out] IDCompositionTransform **transformGroup );
		IDCompositionTransform CreateTransformGroup([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.Interface)] IDCompositionTransform[] transforms, uint elements);

		/// <summary>Creates a 3D translation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTranslateTransform3D</c>**</b></para>
		///   <para>The new 3D translation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A newly created 3D translation transform has a static value of 0 for the OffsetX, OffsetY, and OffsetZ properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtranslatetransform3d
		// HRESULT CreateTranslateTransform3D( [out] IDCompositionTranslateTransform3D **translateTransform3D );
		IDCompositionTranslateTransform3D CreateTranslateTransform3D();

		/// <summary>Creates a 3D scale transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionScaleTransform3D</c>**</b></para>
		///   <para>The new 3D scale transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 3D scale transform object has a static value of 1.0 for the ScaleX, ScaleY, and ScaleZ properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createscaletransform3d
		// HRESULT CreateScaleTransform3D( [out] IDCompositionScaleTransform3D **scaleTransform3D );
		IDCompositionScaleTransform3D CreateScaleTransform3D();

		/// <summary>Creates a 3D rotation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionRotateTransform3D</c>**</b></para>
		///   <para>The new 3D rotation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 3D rotation transform object has a default static value of zero for the Angle, CenterX, CenterY, CenterZ, AxisX, and AxisY properties, and a default static value of 1.0 for the AxisZ property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createrotatetransform3d
		// HRESULT CreateRotateTransform3D( [out] IDCompositionRotateTransform3D **rotateTransform3D );
		IDCompositionRotateTransform3D CreateRotateTransform3D();

		/// <summary>Creates a 3D 4-by-4 matrix transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionMatrixTransform3D</c>**</b></para>
		///   <para>The new 3D matrix transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>The new 3D matrix transform has the identity matrix as its value. The identity matrix is the 4-by-4 matrix with ones on the main diagonal and zeros elsewhere, as shown in the following illustration.</para>
		///   <para>When an identity transform is applied to an object, it does not change the position, shape, or size of the object. It is similar to the way that multiplying a number by one does not change the number. Any transform other than the identity transform will modify the position, shape, and/or size of objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-creatematrixtransform3d
		// HRESULT CreateMatrixTransform3D( [out] IDCompositionMatrixTransform3D **matrixTransform3D );
		IDCompositionMatrixTransform3D CreateMatrixTransform3D();

		/// <summary>Creates a 3D transform group object that holds an array of 3D transform objects.</summary>
		/// <param name="transforms3D">
		///   <para>Type: <b><c>IDCompositionTransform3D</c>**</b></para>
		///   <para>An array of 3D transform objects that make up this transform group.</para>
		/// </param>
		/// <param name="elements">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The number of elements in the <i>transforms</i> array.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTransform3D</c>**</b></para>
		///   <para>The new 3D transform group object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>The array entries in a 3D transform group cannot be changed. However, each transform in the array can be modified through its own property setting methods. If a transform in the array is modified, the change is reflected in the computed matrix of the transform group.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtransform3dgroup
		// HRESULT CreateTransform3DGroup( [in] IDCompositionTransform3D **transforms3D, [in] UINT elements, [out] IDCompositionTransform3D **transform3DGroup );
		IDCompositionTransform3D CreateTransform3DGroup([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.Interface)] IDCompositionTransform3D[] transforms3D, uint elements);

		/// <summary>Creates an object that represents multiple effects to be applied to a visual subtree.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionEffectGroup</c>**</b></para>
		///   <para>The new effect group object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>An effect group enables an application to apply multiple effects to a single visual subtree.</para>
		///   <para>A new effect group has a default opacity value of 1.0 and no 3D transformations.</para>
		///   <para>To set the opacity and transform values, use the corresponding methods on the <c>IDCompositionEffectGroup</c> that was created.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createeffectgroup
		// HRESULT CreateEffectGroup( [out] IDCompositionEffectGroup **effectGroup );
		IDCompositionEffectGroup CreateEffectGroup();

		/// <summary>Creates a clip object that can be used to restrict the rendering of a visual subtree to a rectangular area.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionRectangleClip</c>**</b></para>
		///   <para>The new clip object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A newly created clip object has a value of -2^21 for the left and top properties, and a value of 2^21 for the right and bottom properties, effectively making it a no-op clip object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createrectangleclip
		// HRESULT CreateRectangleClip( [out] IDCompositionRectangleClip **clip );
		IDCompositionRectangleClip CreateRectangleClip();

		/// <summary>Creates an animation object that is used to animate one or more scalar properties of one or more Microsoft DirectComposition objects.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionAnimation</c>**</b></para>
		///   <para>The new animation object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A number of DirectComposition object properties can have an animation object as the value of the property. When a property has an animation object as its value, DirectComposition redraws the visual at the refresh rate to reflect the changing value of the property that is being animated.</para>
		///   <para>A newly created animation object does not have any animation segments associated with it. An application must use the methods of the <c>IDCompositionAnimation</c> interface to build an animation function before setting the animation object as the property of another DirectComposition object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createanimation
		// HRESULT CreateAnimation( [out] IDCompositionAnimation **animation );
		IDCompositionAnimation CreateAnimation();
	}

	/// <summary>An application must use the IDCompositionDesktopDevice interface in order to use DirectComposition in a Win32 desktop application. This interface allows the application to connect a visual tree to a window and to host layered child windows for composition</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositiondesktopdevice
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionDesktopDevice")]
	[ComImport, Guid("5F4633FE-1E08-4CB8-8C75-CE24333F5602"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.1")]
#endif
	public interface IDCompositionDesktopDevice : IDCompositionDevice2
	{
		/// <summary>Commits all DirectComposition commands that are pending on this device.</summary>
		/// <remarks>
		///   <para>Calls to DirectComposition methods are always batched and executed atomically as a single transaction. Calls take effect only when <b>IDCompositionDevice2::Commit</b> is called, at which time all pending method calls for a device are executed at once.</para>
		///   <para>An application that uses multiple devices must call <b>Commit</b> for each device separately. However, because the composition engine processes the calls individually, the batch of commands might not take effect at the same time.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-commit
		// HRESULT Commit();
		new void Commit();

		/// <summary>Waits for the composition engine to finish processing the previous call to the <c>IDCompositionDevice2::Commit</c> method.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-waitforcommitcompletion
		// HRESULT WaitForCommitCompletion();
		new void WaitForCommitCompletion();

		/// <summary>Retrieves information from the composition engine about composition times and the frame rate.</summary>
		/// <returns>
		///   <para>Type: <b><c>DCOMPOSITION_FRAME_STATISTICS</c>*</b></para>
		///   <para>A structure that receives composition times and frame rate information.</para>
		/// </returns>
		/// <remarks>This method retrieves timing information about the composition engine that an application can use to synchronize the rasterization of bitmaps with independent animations.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-getframestatistics
		// HRESULT GetFrameStatistics( [out] DCOMPOSITION_FRAME_STATISTICS *statistics );
		new DCOMPOSITION_FRAME_STATISTICS GetFrameStatistics();

		/// <summary>Creates a new visual object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionVisual2</c>**</b></para>
		///   <para>The new visual object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new visual object has a static value of zero for the OffsetX and OffsetY properties, and NULL for the Transform, Clip, and Content properties. Initially, the visual does not cause the contents of a window to change. The visual must be added as a child of another visual, or as the root of a composition target, before it can affect the appearance of a window.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createvisual
		// HRESULT CreateVisual( [out] IDCompositionVisual2 **visual );
		new IDCompositionVisual2 CreateVisual();

		/// <summary>Creates a Microsoft DirectComposition surface factory object, which can be used to create other DirectComposition surface or virtual surface objects</summary>
		/// <param name="renderingDevice">A pointer to a DirectX device to be used to create DirectComposition surface objects. Must be a pointer to an object implementing the <c>IDXGIDevice</c> or <c>ID2D1Device</c> interfaces. This parameter must not be NULL.</param>
		/// <returns>The newly created surface factory object. This parameter must not be NULL.</returns>
		/// <remarks>
		///   <para>A surface factory allows an application to simultaneously use more than one single DXGI or Direct2D device with DirectComposition. Each surface factory has a permanent association with one DXGI or Direct2D device, but a DirectComposition device may have any number of surface factories.</para>
		///   <para>Each surface factory manages resources independently from the others. In particular, DirectComposition pools surface allocations to mitigate surface allocation and deallocation costs. This pool is done on a per-surface factory basis.</para>
		///   <para>If the <c>DCompositionCreateDevice2</c> function is called with a non-NULL <i>renderingDevice</i> parameter, the returned DirectComposition device object has an implicit surface factory under the covers associated with the given rendering device. This implicit surface factory is used to service the <c>IDCompositionDevice::CreateSurface</c>, <c>IDCompositionDevice::CreateVirtualSurface</c>, <c>IDCompositionDevice2::CreateSurface</c> and <c>IDCompositionDevice2::CreateVirtualSurface</c> methods.</para>
		///   <para>A surface object remains alive as long as any of the surfaces or virtual surfaces that it created remain alive, either directly because the application holds a direct reference, or indirectly because one or more such surfaces are associated with one or more visual objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createsurfacefactory
		// HRESULT CreateSurfaceFactory( [in] IUnknown *renderingDevice, [out] IDCompositionSurfaceFactory **surfaceFactory );
		new IDCompositionSurfaceFactory CreateSurfaceFactory([In, MarshalAs(UnmanagedType.IUnknown)] object renderingDevice);

		/// <summary>Creates an updateable surface object that can be associated with one or more visuals for composition.</summary>
		/// <param name="width">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The width of the surface, in pixels. Constrained by the <c>feature level</c> of the rendering device that was passed in at the time the DirectComposition device was created.</para>
		/// </param>
		/// <param name="height">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The height of the surface, in pixels. Constrained by the <c>feature level</c> of the rendering device that was passed in at the time the DirectComposition device was created.</para>
		/// </param>
		/// <param name="pixelFormat">
		///   <para>Type: <b><c>DXGI_FORMAT</c></b></para>
		///   <para>The pixel format of the surface.</para>
		/// </param>
		/// <param name="alphaMode">
		///   <para>Type: <b><c>DXGI_ALPHA_MODE</c></b></para>
		///   <para>The format of the alpha channel, if an alpha channel is included in the pixel format. It can be one of the following values:</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_UNSPECIFIED</b>
		///       </description>
		///       <description>The alpha channel is not specified. This value has the same effect as <b>DXGI_ALPHA_MODE_IGNORE</b>.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_PREMULTIPLIED</b>
		///       </description>
		///       <description>The color channels contain values that are premultiplied with the alpha channel.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_IGNORE</b>
		///       </description>
		///       <description>The alpha channel should be ignored and the bitmap should be rendered opaquely.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionSurface</c>**</b></para>
		///   <para>The newly created surface object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A Microsoft DirectComposition surface is a rectangular array of pixels that can be associated with a visual for composition.</para>
		///   <para>A newly created surface object is in an uninitialized state. While it is uninitialized, the surface has no effect on the composition of the visual tree. It behaves exactly like a surface that has 100% transparent pixels.</para>
		///   <para>To initialize the surface with pixel data, use the <c>IDCompositionSurface::BeginDraw</c> and <c>IDCompositionSurface::EndDraw</c> methods. The first call to this method must cover the entire surface area to provide an initial value for every pixel. Subsequent calls may specify smaller sub-rectangles of the surface to update.</para>
		///   <para>DirectComposition surfaces support the following pixel formats:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_B8G8R8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R8G8B8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R16G16B16A16_FLOAT</b>
		///       </description>
		///     </item>
		///   </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createsurface
		// HRESULT CreateSurface( [in] UINT width, [in] UINT height, [in] DXGI_FORMAT pixelFormat, [in] DXGI_ALPHA_MODE alphaMode, [out] IDCompositionSurface **surface );
		new IDCompositionSurface CreateSurface(uint width, uint height, [In] DXGI_FORMAT pixelFormat, [In] DXGI_ALPHA_MODE alphaMode);

		/// <summary>Creates a sparsely populated surface that can be associated with one or more visuals for composition.</summary>
		/// <param name="initialWidth">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The width of the surface, in pixels. The maximum width is 16,777,216 pixels.</para>
		/// </param>
		/// <param name="initialHeight">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The height of the surface, in pixels. The maximum height is 16,777,216 pixels.</para>
		/// </param>
		/// <param name="pixelFormat">
		///   <para>Type: <b><c>DXGI_FORMAT</c></b></para>
		///   <para>The pixel format of the surface.</para>
		/// </param>
		/// <param name="alphaMode">
		///   <para>Type: <b><c>DXGI_ALPHA_MODE</c></b></para>
		///   <para>The meaning of the alpha channel, if the pixel format contains an alpha channel. It can be one of the following values:</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_UNSPECIFIED</b>
		///       </description>
		///       <description>The alpha channel is not specified. This value has the same effect as <b>DXGI_ALPHA_MODE_IGNORE</b>.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_PREMULTIPLIED</b>
		///       </description>
		///       <description>The color channels contain values that are premultiplied with the alpha channel.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_IGNORE</b>
		///       </description>
		///       <description>The alpha channel should be ignored and the bitmap should be rendered opaquely.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionVirtualSurface</c>**</b></para>
		///   <para>The newly created surface object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A Microsoft DirectComposition sparse surface is a logical object that behaves like a rectangular array of pixels that can be associated with a visual for composition. The surface is not necessarily backed by any physical video or system memory for every one of its pixels. The application can realize or virtualize parts of the logical surface at different times.</para>
		///   <para>A newly created surface object is in an uninitialized state. While it is uninitialized, the surface has no effect on the composition of the visual tree. It behaves exactly like a surface that is initialized with 100% transparent pixels.</para>
		///   <para>To initialize the surface with pixel data, use the <c>IDCompositionSurface::BeginDraw</c> and <c>IDCompositionSurface::EndDraw</c> methods. This method not only provides pixels for the surface, but it also allocates actual storage space for those pixels. The memory allocation persists until the application returns some of the memory to the system. The application can free part or all of the allocated memory by calling the <c>IDCompositionVirtualSurface::Trim</c> method.</para>
		///   <para>DirectComposition surfaces support the following pixel formats:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_B8G8R8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R8G8B8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R16G16B16A16_FLOAT</b>
		///       </description>
		///     </item>
		///   </list>
		///   <para>This method fails if <i>initialWidth</i> or <i>initialHeight</i> exceeds 16,777,216 pixels.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createvirtualsurface
		// HRESULT CreateVirtualSurface( [in] UINT initialWidth, [in] UINT initialHeight, [in] DXGI_FORMAT pixelFormat, [in] DXGI_ALPHA_MODE alphaMode, [out] IDCompositionVirtualSurface **virtualSurface );
		new IDCompositionVirtualSurface CreateVirtualSurface(uint initialWidth, uint initialHeight, [In] DXGI_FORMAT pixelFormat, [In] DXGI_ALPHA_MODE alphaMode);

		/// <summary>Creates a 2D translation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTranslateTransform</c>**</b></para>
		///   <para>The new 2D translation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D translation transform object has a static value of zero for the OffsetX and OffsetY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtranslatetransform
		// HRESULT CreateTranslateTransform( [out] IDCompositionTranslateTransform **translateTransform );
		new IDCompositionTranslateTransform CreateTranslateTransform();

		/// <summary>Creates a 2D scale transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionScaleTransform</c>**</b></para>
		///   <para>The new 2D scale transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D scale transform object has a static value of zero for the ScaleX, ScaleY, CenterX, and CenterY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createscaletransform
		// HRESULT CreateScaleTransform( [out] IDCompositionScaleTransform **scaleTransform );
		new IDCompositionScaleTransform CreateScaleTransform();

		/// <summary>Creates a 2D rotation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionRotateTransform</c>**</b></para>
		///   <para>The new rotation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D rotation transform object has a static value of zero for the Angle, CenterX, and CenterY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createrotatetransform
		// HRESULT CreateRotateTransform( [out] IDCompositionRotateTransform **rotateTransform );
		new IDCompositionRotateTransform CreateRotateTransform();

		/// <summary>Creates a 2D skew transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionSkewTransform</c>**</b></para>
		///   <para>The new 2D skew transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D skew transform object has a static value of zero for the AngleX, AngleY, CenterX, and CenterY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createskewtransform
		// HRESULT CreateSkewTransform( [out] IDCompositionSkewTransform **skewTransform );
		new IDCompositionSkewTransform CreateSkewTransform();

		/// <summary>Creates a 2D 3-by-2 matrix transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionMatrixTransform</c>**</b></para>
		///   <para>The new matrix transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A new matrix transform object has the identity matrix as its initial value. The identity matrix is the 3x2 matrix with ones on the main diagonal and zeros elsewhere, as shown in the following illustration.</para>
		///   <para>When an identity transform is applied to an object, it does not change the position, shape, or size of the object. It is similar to the way that multiplying a number by one does not change the number. Any transform other than the identity transform will modify the position, shape, and/or size of objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-creatematrixtransform
		// HRESULT CreateMatrixTransform( [out] IDCompositionMatrixTransform **matrixTransform );
		new IDCompositionMatrixTransform CreateMatrixTransform();

		/// <summary>Creates a 2D transform group object that holds an array of 2D transform objects.</summary>
		/// <param name="transforms">
		///   <para>Type: <b><c>IDCompositionTransform</c>**</b></para>
		///   <para>An array of 2D transform objects that make up this transform group.</para>
		/// </param>
		/// <param name="elements">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The number of elements in the <i>transforms</i> array.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTransform</c>**</b></para>
		///   <para>The new transform group object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>The array entries in a transform group cannot be changed. However, each transform in the array can be modified through its own property setting methods. If a transform in the array is modified, the change is reflected in the computed matrix of the transform group.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtransformgroup
		// HRESULT CreateTransformGroup( [in] IDCompositionTransform **transforms, [in] UINT elements, [out] IDCompositionTransform **transformGroup );
		new IDCompositionTransform CreateTransformGroup([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.Interface)] IDCompositionTransform[] transforms, uint elements);

		/// <summary>Creates a 3D translation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTranslateTransform3D</c>**</b></para>
		///   <para>The new 3D translation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A newly created 3D translation transform has a static value of 0 for the OffsetX, OffsetY, and OffsetZ properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtranslatetransform3d
		// HRESULT CreateTranslateTransform3D( [out] IDCompositionTranslateTransform3D **translateTransform3D );
		new IDCompositionTranslateTransform3D CreateTranslateTransform3D();

		/// <summary>Creates a 3D scale transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionScaleTransform3D</c>**</b></para>
		///   <para>The new 3D scale transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 3D scale transform object has a static value of 1.0 for the ScaleX, ScaleY, and ScaleZ properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createscaletransform3d
		// HRESULT CreateScaleTransform3D( [out] IDCompositionScaleTransform3D **scaleTransform3D );
		new IDCompositionScaleTransform3D CreateScaleTransform3D();

		/// <summary>Creates a 3D rotation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionRotateTransform3D</c>**</b></para>
		///   <para>The new 3D rotation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 3D rotation transform object has a default static value of zero for the Angle, CenterX, CenterY, CenterZ, AxisX, and AxisY properties, and a default static value of 1.0 for the AxisZ property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createrotatetransform3d
		// HRESULT CreateRotateTransform3D( [out] IDCompositionRotateTransform3D **rotateTransform3D );
		new IDCompositionRotateTransform3D CreateRotateTransform3D();

		/// <summary>Creates a 3D 4-by-4 matrix transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionMatrixTransform3D</c>**</b></para>
		///   <para>The new 3D matrix transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>The new 3D matrix transform has the identity matrix as its value. The identity matrix is the 4-by-4 matrix with ones on the main diagonal and zeros elsewhere, as shown in the following illustration.</para>
		///   <para>When an identity transform is applied to an object, it does not change the position, shape, or size of the object. It is similar to the way that multiplying a number by one does not change the number. Any transform other than the identity transform will modify the position, shape, and/or size of objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-creatematrixtransform3d
		// HRESULT CreateMatrixTransform3D( [out] IDCompositionMatrixTransform3D **matrixTransform3D );
		new IDCompositionMatrixTransform3D CreateMatrixTransform3D();

		/// <summary>Creates a 3D transform group object that holds an array of 3D transform objects.</summary>
		/// <param name="transforms3D">
		///   <para>Type: <b><c>IDCompositionTransform3D</c>**</b></para>
		///   <para>An array of 3D transform objects that make up this transform group.</para>
		/// </param>
		/// <param name="elements">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The number of elements in the <i>transforms</i> array.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTransform3D</c>**</b></para>
		///   <para>The new 3D transform group object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>The array entries in a 3D transform group cannot be changed. However, each transform in the array can be modified through its own property setting methods. If a transform in the array is modified, the change is reflected in the computed matrix of the transform group.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtransform3dgroup
		// HRESULT CreateTransform3DGroup( [in] IDCompositionTransform3D **transforms3D, [in] UINT elements, [out] IDCompositionTransform3D **transform3DGroup );
		new IDCompositionTransform3D CreateTransform3DGroup([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.Interface)] IDCompositionTransform3D[] transforms3D, uint elements);

		/// <summary>Creates an object that represents multiple effects to be applied to a visual subtree.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionEffectGroup</c>**</b></para>
		///   <para>The new effect group object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>An effect group enables an application to apply multiple effects to a single visual subtree.</para>
		///   <para>A new effect group has a default opacity value of 1.0 and no 3D transformations.</para>
		///   <para>To set the opacity and transform values, use the corresponding methods on the <c>IDCompositionEffectGroup</c> that was created.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createeffectgroup
		// HRESULT CreateEffectGroup( [out] IDCompositionEffectGroup **effectGroup );
		new IDCompositionEffectGroup CreateEffectGroup();

		/// <summary>Creates a clip object that can be used to restrict the rendering of a visual subtree to a rectangular area.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionRectangleClip</c>**</b></para>
		///   <para>The new clip object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A newly created clip object has a value of -2^21 for the left and top properties, and a value of 2^21 for the right and bottom properties, effectively making it a no-op clip object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createrectangleclip
		// HRESULT CreateRectangleClip( [out] IDCompositionRectangleClip **clip );
		new IDCompositionRectangleClip CreateRectangleClip();

		/// <summary>Creates an animation object that is used to animate one or more scalar properties of one or more Microsoft DirectComposition objects.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionAnimation</c>**</b></para>
		///   <para>The new animation object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A number of DirectComposition object properties can have an animation object as the value of the property. When a property has an animation object as its value, DirectComposition redraws the visual at the refresh rate to reflect the changing value of the property that is being animated.</para>
		///   <para>A newly created animation object does not have any animation segments associated with it. An application must use the methods of the <c>IDCompositionAnimation</c> interface to build an animation function before setting the animation object as the property of another DirectComposition object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createanimation
		// HRESULT CreateAnimation( [out] IDCompositionAnimation **animation );
		new IDCompositionAnimation CreateAnimation();

		/// <summary>Creates a composition target object that is bound to the window that is represented by the specified window handle.</summary>
		/// <param name="hwnd">The window to which the composition target object should be bound. This parameter must not be NULL.</param>
		/// <param name="topmost">TRUE if the visual tree should be displayed on top of the children of the window specified by the hwnd parameter; otherwise, the visual tree is displayed behind the children.</param>
		/// <returns>The new composition target object. This parameter must not be NULL.</returns>
		/// <remarks>
		///   <para>A DirectComposition visual tree must be bound to a window before anything can be displayed on screen. The window can be a top-level window or a child window. In either case, the window can be a layered window, but in all cases the window must belong to the calling process. If the window belongs to a different process, this method returns <c>DCOMPOSITION_ERROR_ACCESS_DENIED</c>.</para>
		///   <para>When DirectComposition content is composed to the window, the content is always composed on top of whatever is drawn directly to that window through the device context returned by the <c>GetDC</c> function, or by calls to DirectX Present methods. However, because window clipping rules apply to DirectComposition content, if the window has child windows, those child windows may clip the visual tree. The topmost parameter determines whether child windows clip the visual tree.</para>
		///   <para>Conceptually, each window consists of four layers:</para>
		///   <list type="number">
		///     <item>
		///       <description>The contents drawn directly to the window handle (this is the bottommost layer).</description>
		///     </item>
		///     <item>
		///       <description>An optional DirectComposition visual tree.</description>
		///     </item>
		///     <item>
		///       <description>The contents of all child windows, if any.</description>
		///     </item>
		///     <item>
		///       <description>Another optional DirectComposition visual tree (this is the topmost layer).</description>
		///     </item>
		///   </list>
		///   <para>All four layers are clipped to the window’s visible region.</para>
		///   <para>At most, only two composition targets can be created for each window in the system, one topmost and one not topmost. If a composition target is already bound to the specified window at the specified layer, this method fails. When a composition target object is destroyed, the layer it composed is available for use by a new composition target object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondesktopdevice-createtargetforhwnd
		// HRESULT CreateTargetForHwnd( [in] HWND hwnd, BOOL topmost, [out] IDCompositionTarget **target );
		IDCompositionTarget CreateTargetForHwnd([In] HWND hwnd, bool topmost);

		/// <summary>Creates a new composition surface object that wraps an existing composition surface.</summary>
		/// <param name="handle">The handle of an existing composition surface that was created by a call to the <c>DCompositionCreateSurfaceHandle</c> function.</param>
		/// <returns>The new composition surface object. This parameter must not be NULL.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondesktopdevice-createsurfacefromhandle
		// HRESULT CreateSurfaceFromHandle( [in] HANDLE handle, [out] IUnknown **surface );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object CreateSurfaceFromHandle([In] HANDLE handle);

		/// <summary>Creates a wrapper object that represents the rasterization of a layered window, and that can be associated with a visual for composition.</summary>
		/// <param name="hwnd">The handle of the layered window for which to create a wrapper. A layered window is created by specifying WS_EX_LAYERED when creating the window with the <c>CreateWindowEx</c> function or by setting WS_EX_LAYERED via <c>SetWindowLong</c> after the window has been created.</param>
		/// <returns>The new composition surface object. This parameter must not be NULL.</returns>
		/// <remarks>
		///   <para>You can use the surface pointer in calls to the IDCompositionVisual::SetContent method to set the content of one or more visuals. After setting the content, the visuals compose the contents of the specified layered window as long as the window is layered. If the window is unlayered, the window content disappears from the output of the composition tree. If the window is later re-layered, the window content reappears as long as it is still associated with a visual. If the window is resized, the affected visuals are re-composed.</para>
		///   <para>The contents of the window are not cached beyond the life of the window. That is, if the window is destroyed, the affected visuals stop composing the window.</para>
		///   <para>If the window is moved off-screen or resized to zero, the system stops composing the content of those visuals. You should use the <c>DwmSetWindowAttribute</c> function with the DWMWA_CLOAK flag to "cloak" the layered child window when you need to hide the original window while allowing the system to continue to compose the content of the visuals.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondesktopdevice-createsurfacefromhwnd
		// HRESULT CreateSurfaceFromHwnd( [in] HWND hwnd, [out] IUnknown **surface );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object CreateSurfaceFromHwnd([In] HWND hwnd);
	}

	/// <summary>Provides access to rendering features that help with application debugging and performance tuning. This interface can be queried from the DirectComposition device interface.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositiondevicedebug
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionDeviceDebug")]
	[ComImport, Guid("A1A3C64A-224F-4A81-9773-4F03A89D3C6C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.1")]
#endif
	public interface IDCompositionDeviceDebug
	{
		/// <summary>Enables display of performance debugging counters.</summary>
		/// <remarks>
		///   <para>Performance counters are displayed on the top-right corner of the screen. From left to right, Microsoft DirectComposition displays the following information:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>The composition engine frame rate, in frames per second, averaged over the last 60 composition frames</description>
		///     </item>
		///     <item>
		///       <description>The overall CPU usage of the composition thread, in milliseconds</description>
		///     </item>
		///   </list>
		///   <para>The DirectComposition composition engine operates on the entire desktop all at once, so the performance counters measure the total cost of desktop composition, not just the cost of any one particular application. If the application occupies the entire screen, however, it is reasonable to assume that all of the composition cost is due to that one application.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevicedebug-enabledebugcounters
		// HRESULT EnableDebugCounters();
		void EnableDebugCounters();

		/// <summary>Disables display of performance debugging counters.</summary>
		/// <remarks>Microsoft DirectComposition keeps a count of how many DirectComposition devices have performance counters enabled, for the entire desktop session. If the count is non-zero, the performance counters are displayed. Therefore, disabling the counters may not make them go away if another device is also requesting display of the counters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevicedebug-disabledebugcounters
		// HRESULT DisableDebugCounters();
		void DisableDebugCounters();
	}

	/// <summary>Creates surface and virtual surface objects associated with an application-provided rendering device.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionsurfacefactory
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionSurfaceFactory")]
	[ComImport, Guid("E334BC12-3937-4E02-85EB-FCF4EB30D2C8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.1")]
#endif
	public interface IDCompositionSurfaceFactory
	{
		/// <summary>Creates a surface object that can be associated with one or more visuals for composition.</summary>
		/// <param name="width">The width of the surface, in pixels.</param>
		/// <param name="height">The height of the surface, in pixels.</param>
		/// <param name="pixelFormat">The pixel format of the surface.</param>
		/// <param name="alphaMode">The format of the alpha channel, if an alpha channel is included in the pixel format. This can be one of DXGI_ALPHA_MODE_PREMULTIPLIED or DXGI_ALPHA_MODE_IGNORE. It can also be DXGI_ALPHA_MODE_UNSPECIFIED, which is interpreted as DXGI_ALPHA_MODE_IGNORE.</param>
		/// <returns>The newly created surface object. This parameter must not be NULL.</returns>
		/// <remarks>
		///   <para>A Microsoft DirectComposition surface is a rectangular array of pixels that can be associated with a visual for composition.</para>
		///   <para>A newly created surface object is in an uninitialized state. While it is uninitialized, the surface has no effect on the composition of the visual tree. It behaves exactly like a surface that has 100% transparent pixels.</para>
		///   <para>To initialize the surface with pixel data, use the <c>IDCompositionSurface::BeginDraw</c> method. The first call to this method must cover the entire surface area to provide an initial value for every pixel. Subsequent calls may specify smaller sub-rectangles of the surface to update.</para>
		///   <para>This method will fail if either the width or height exceed the max texture size. If your scenario requires dimensions beyond the max texture size, use <c>CreateVirtualSurface</c> method.</para>
		///   <para>DirectComposition surfaces support the following pixel formats:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>DXGI_FORMAT_B8G8R8A8_UNORM</description>
		///     </item>
		///     <item>
		///       <description>DXGI_FORMAT_R8G8B8A8_UNORM</description>
		///     </item>
		///     <item>
		///       <description>DXGI_FORMAT_R16G16B16A16_FLOAT</description>
		///     </item>
		///   </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionsurfacefactory-createsurface
		// HRESULT CreateSurface( [in] UINT width, [in] UINT height, [in] DXGI_FORMAT pixelFormat, [in] DXGI_ALPHA_MODE alphaMode, [out] IDCompositionSurface **surface );
		IDCompositionSurface CreateSurface(uint width, uint height, [In] DXGI_FORMAT pixelFormat, [In] DXGI_ALPHA_MODE alphaMode);

		/// <summary>Creates a sparsely populated surface that can be associated with one or more visuals for composition.</summary>
		/// <param name="initialWidth">The width of the surface, in pixels. The maximum width is 16,777,216 pixels.</param>
		/// <param name="initialHeight">The height of the surface, in pixels. The maximum height is 16,777,216 pixels.</param>
		/// <param name="pixelFormat">The pixel format of the surface.</param>
		/// <param name="alphaMode">The format of the alpha channel, if an alpha channel is included in the pixel format. This can be one of DXGI_ALPHA_MODE_PREMULTIPLIED or DXGI_ALPHA_MODE_IGNORE. It can also be DXGI_ALPHA_MODE_UNSPECIFIED, which is interpreted as DXGI_ALPHA_MODE_IGNORE.</param>
		/// <returns>The newly created virtual surface object. This parameter must not be NULL.</returns>
		/// <remarks>
		///   <para>A newly created virtual surface object is in an uninitialized state. While it is uninitialized, the surface has no effect on the composition of the visual tree. It behaves exactly like a surface that is initialized with 100% transparent pixels.</para>
		///   <para>To initialize the surface with pixel data, use the <c>IDCompositionSurface::BeginDraw</c> method. This method not only provides pixels for the surface, but it also allocates actual storage space for those pixels. The memory allocation persists until the application returns some of the memory to the system. The application can free part or all of the allocated memory by calling the <c>IDCompositionVirtualSurface::Trim</c> or <c>IDCompositionVirtualSurface::Resize</c> method.</para>
		///   <para>Microsoft DirectComposition surfaces support the following pixel formats:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>DXGI_FORMAT_B8G8R8A8_UNORM</description>
		///     </item>
		///     <item>
		///       <description>DXGI_FORMAT_R8G8B8A8_UNORM</description>
		///     </item>
		///     <item>
		///       <description>DXGI_FORMAT_R16G16B16A16_FLOAT</description>
		///     </item>
		///   </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionsurfacefactory-createvirtualsurface
		// HRESULT CreateVirtualSurface( [in] UINT initialWidth, [in] UINT initialHeight, [in] DXGI_FORMAT pixelFormat, [in] DXGI_ALPHA_MODE alphaMode, [out] IDCompositionVirtualSurface **virtualSurface );
		IDCompositionVirtualSurface CreateVirtualSurface(uint initialWidth, uint initialHeight, [In] DXGI_FORMAT pixelFormat, [In] DXGI_ALPHA_MODE alphaMode);
	}

	/// <summary>Represents one DirectComposition visual in a visual tree.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionvisual2
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionVisual2")]
	[ComImport, Guid("E8DE1639-4331-4B26-BC5F-6A321D347A85"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.1")]
#endif
	public interface IDCompositionVisual2 : IDCompositionVisual
	{
		/// <summary>Changes the value of the OffsetX property of this visual. The OffsetX property specifies the new offset of the visual along the x-axis, relative to the parent visual.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the OffsetX property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the animation object referenced by the <i>animation</i> parameter is changed after this call, the change does not affect the OffsetX property unless this method is called again. If the OffsetX property was previously animated, this method replaces that animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsetx(idcompositionanimation)
		// HRESULT SetOffsetX( [in] IDCompositionAnimation *animation );
		new void SetOffsetX(IDCompositionAnimation animation);

		/// <summary>Changes the value of the OffsetX property of this visual. The OffsetX property specifies the new offset of the visual along the x-axis, relative to the parent visual.</summary>
		/// <param name="offsetX">
		///   <para>Type: <b>float</b></para>
		///   <para>The new offset of the visual along the x-axis, in pixels.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>offsetX</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>Changing the OffsetX property of a visual transforms the coordinate system of the entire visual subtree that is rooted at that visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>A transformation that is specified by the Transform property is applied after the OffsetX property. In other words, the effect of setting the Transform property and the OffsetX property is the same as setting only the Transform property on a transform group object where the first member of the group is an <c>IDCompositionTranslateTransform</c> object that has the same OffsetX value as <i>offsetX</i>. However, you should use <b>IDCompositionVisual::SetOffsetX</b> whenever possible because it is slightly faster.</para>
		///   <para>If the OffsetX and OffsetY properties are set to 0, and the Transform property is set to NULL, the coordinate system of the visual is the same as that of its parent.</para>
		///   <para>If the OffsetX property was previously animated, this method removes the animation and sets the property to the specified static value.</para>
		///   <para>Examples</para>
		///   <para>For an example, see <c>How to Build a Simple Visual Tree</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsetx(float)
		// HRESULT SetOffsetX( [in] float offsetX );
		new void SetOffsetX(float offsetX);

		/// <summary>Animates the value of the OffsetY property of this visual. The OffsetY property specifies the new offset of the visual along the y-axis, relative to the parent visual.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the OffsetY property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the animation object referenced by the <i>animation</i> parameter is changed after this call, the change does not affect the OffsetY property unless this method is called again. If the OffsetY property was previously animated, this method replaces that animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsety(idcompositionanimation)
		// HRESULT SetOffsetY( [in] IDCompositionAnimation *animation );
		new void SetOffsetY(IDCompositionAnimation animation);

		/// <summary>Changes the value of the OffsetY property of this visual. The OffsetY property specifies the new offset of the visual along the y-axis, relative to the parent visual.</summary>
		/// <param name="offsetY">
		///   <para>Type: <b>float</b></para>
		///   <para>The new offset of the visual along the y-axis, in pixels.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>offsetY</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>Changing the OffsetY property transforms the coordinate system of the entire visual subtree that is rooted at this visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>A transformation that is specified by the Transform property is applied after the OffsetY property. In other words, the effect of setting the Transform property and the OffsetY property is the same as setting only the Transform property on a transform group object where the first member of the group is an <c>IDCompositionTranslateTransform</c> object that has the same OffsetY value as <i>offsetY</i>. However, you should use <b>IDCompositionVisual::SetOffsetY</b> whenever possible because it is slightly faster.</para>
		///   <para>If the OffsetX and OffsetY properties are set to 0, and the Transform property is set to NULL, the coordinate system of the visual is the same as that of its parent.</para>
		///   <para>If the OffsetY property was previously animated, this method removes the animation and sets the property to the specified static value.</para>
		///   <para>Examples</para>
		///   <para>For an example, see <c>How to Build a Simple Visual Tree</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsety(float)
		// HRESULT SetOffsetY( [in] float offsetY );
		new void SetOffsetY(float offsetY);

		/// <summary>Sets the Transform property of this visual to the specified 2D transform object.</summary>
		/// <param name="transform">
		///   <para>Type: <b><c>IDCompositionTransform</c>*</b></para>
		///   <para>The transform object that is used to modify the coordinate system of this visual. This parameter can point to an <c>IDCompositionTransform</c> interface or one of its derived interfaces. This parameter can be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Transform property transforms the coordinate system of the entire visual subtree that is rooted at this visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>If the Transform property previously specified a transform matrix, the newly specified transform object replaces the transform matrix.</para>
		///   <para>A transformation specified by the Transform property is applied after the OffsetX and OffsetY properties. In other words, the effect of setting the Transform property and the OffsetX and OffsetY properties is the same as setting only the Transform property on a transform group where the first member of the group is an <c>IDCompositionTranslateTransform</c> object that has those same OffsetX and OffsetY values. However, you should use the <c>IDCompositionVisual::SetOffsetX</c> and <c>SetOffsetY</c> methods whenever possible because they are slightly faster.</para>
		///   <para>This method fails if <i>transform</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		///   <para>If the <i>transform</i> parameter is NULL, the coordinate system of this visual is transformed only by its OffsetX and OffsetY properties. Setting the Transform property to NULL is equivalent to setting it to an <c>IDCompositionMatrixTransform</c> object where the specified matrix is the identity matrix. However, an application should set the Transform property to NULL whenever possible because it is slightly faster.</para>
		///   <para>If the OffsetX and OffsetY properties are set to 0, and the Transform property is set to NULL, the coordinate system of the visual is the same as that of its parent.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-settransform(idcompositiontransform)
		// HRESULT SetTransform( [in, optional] IDCompositionTransform *transform );
		new void SetTransform([In, Optional] IDCompositionTransform? transform);

		/// <summary>Sets the Transform property of this visual to the specified 3-by-2 transform matrix.</summary>
		/// <param name="matrix">
		///   <para>Type: <b>const <c>D2D_MATRIX_3X2_F</c></b></para>
		///   <para>The 3-by-2 transform matrix that is used to modify the coordinate system of this visual.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Transform property transforms the coordinate system of the entire visual subtree that is rooted at this visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>If the Transform property previously specified a transform object, the newly specified transform matrix replaces the transform object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-settransform(constd2d_matrix_3x2_f_)
		// HRESULT SetTransform( [in, ref] const D2D_MATRIX_3X2_F &amp; matrix );
		new void SetTransform(in D2D_MATRIX_3X2_F matrix);

		/// <summary>Sets the TransformParent property of this visual. The TransformParent property establishes the coordinate system relative to which this visual is composed.</summary>
		/// <param name="visual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The new visual that establishes the base coordinate system for this visual. This parameter can be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>The coordinate system of a visual is modified by the OffsetX, OffsetY, and Transform properties. Normally, these properties define the coordinate system of a visual relative to its immediate parent. This method specifies the visual relative to which the coordinate system for this visual is based. The specified visual must be an ancestor of the current visual. If it is not an ancestor, the coordinate system is based on this visual's immediate parent, just as if the TransformParent property were set to NULL. Because visuals can be reparented, this property can take effect again if the specified visual becomes an ancestor of the target visual through a reparenting operation.</para>
		///   <para>If the <i>visual</i> parameter is NULL, the coordinate system is always transformed relative to the visual's immediate parent. This is the default behavior if this method is not used.</para>
		///   <para>This method fails if the <i>visual</i> parameter is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-settransformparent
		// HRESULT SetTransformParent( [in, optional] IDCompositionVisual *visual );
		new void SetTransformParent([In, Optional] IDCompositionVisual? visual);

		/// <summary>Sets the Effect property of this visual. The Effect property modifies how the subtree that is rooted at this visual is blended with the background, and can apply a 3D perspective transform to the visual.</summary>
		/// <param name="effect">
		///   <para>Type: <b><c>IDCompositionEffect</c>*</b></para>
		///   <para>A pointer to an effect object. This parameter can be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method creates an implicit off-screen surface to which the subtree that is rooted at this visual is composed. The surface is used as one of the inputs to the specified effect. The output of the effect is composed directly to the composition target. Some effects also use the composition target as another implicit input. This is typically the case for compositional or blend effects such as opacity, where the composition target is considered to be the "background." In that case, any visuals that are "behind" the current visual are included in the composition target when the current visual is rendered and are considered to be the "background" that this visual composes to.</para>
		///   <para>If this visual is not the root of a visual tree and one of its ancestors also has an effect applied to it, the off-screen surface created by the closest ancestor is the composition target to which this visual's effect is composed. Otherwise, the composition target is the root composition target. As a consequence, the background for compositional and blend effects includes only the visuals up to the closest ancestor that itself has an effect. Conversely, any effects applied to visuals under the current visual use the newly created off-screen surface as the background, which may affect how those visuals ultimately compose on top of what the end user perceives as being "behind" those visuals.</para>
		///   <para>If the <i>effect</i> parameter is NULL, no bitmap effect is applied to this visual. Any previous effects that were associated with this visual are removed. The off-screen surface is also removed and the visual subtree is composed directly to the parent composition target, which may also affect how compositional or blend effects under this visual are rendered.</para>
		///   <para>This method fails if <i>effect</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-seteffect
		// HRESULT SetEffect( [in, optional] IDCompositionEffect *effect );
		new void SetEffect([In, Optional] IDCompositionEffect? effect);

		/// <summary>Sets the BitmapInterpolationMode property, which specifies the mode for Microsoft DirectComposition to use when interpolating pixels from bitmaps that are not axis-aligned or drawn exactly at scale.</summary>
		/// <param name="interpolationMode">
		///   <para>Type: <b><c>DCOMPOSITION_BITMAP_INTERPOLATION_MODE</c></b></para>
		///   <para>The interpolation mode to use.</para>
		/// </param>
		/// <remarks>
		///   <para>The interpolation mode affects how a bitmap is composed when it is transformed such that there is no one-to-one correspondence between pixels in the bitmap and pixels on the screen.</para>
		///   <para>By default, a visual inherits the interpolation mode of the parent visual, which may inherit the interpolation mode of its parent visual, and so on. A visual uses the default interpolation mode if this method is never called for the visual, or if this method is called with <c>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_INHERIT</c>. If no visuals set the interpolation mode, the default for the entire visual tree is nearest neighbor interpolation, which offers the lowest visual quality but the highest performance.</para>
		///   <para>If the <i>interpolationMode</i> parameter is anything other than <c>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_INHERIT</c>, this visual's bitmap is composed with the specified interpolation mode, and this mode becomes the new default mode for the children of this visual. That is, if the interpolation mode of this visual's children is unchanged or explicitly set to <b>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_INHERIT</b>, the bitmaps of the child visuals are composed using the interpolation mode of this visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setbitmapinterpolationmode
		// HRESULT SetBitmapInterpolationMode( [in] DCOMPOSITION_BITMAP_INTERPOLATION_MODE interpolationMode );
		new void SetBitmapInterpolationMode([In] DCOMPOSITION_BITMAP_INTERPOLATION_MODE interpolationMode);

		/// <summary>Sets the BorderMode property, which specifies how to compose the edges of bitmaps and clips associated with this visual, or with visuals in the subtree rooted at this visual.</summary>
		/// <param name="borderMode">
		///   <para>Type: <b><c>DCOMPOSITION_BORDER_MODE</c></b></para>
		///   <para>The border mode to use.</para>
		/// </param>
		/// <remarks>
		///   <para>The border mode affects how the edges of a bitmap are composed when the bitmap is transformed such that the edges are not exactly axis-aligned and at precise pixel boundaries. It also affects how content is clipped at the corners of a clip that has rounded corners, and at the edge of a clip that is transformed such that the edges are not exactly axis-aligned and at precise pixel boundaries.</para>
		///   <para>By default, a visual inherits the border mode of its parent visual, which may inherit the border mode of its parent visual, and so on. A visual uses the default border mode if this method is never called for the visual, or if this method is called with <c>DCOMPOSITION_BORDER_MODE_INHERIT</c>. If no visuals set the border mode, the default for the entire visual tree is aliased rendering, which offers the lowest visual quality but the highest performance.</para>
		///   <para>If the <i>borderMode</i> parameter is anything other than <c>DCOMPOSITION_BORDER_MODE_INHERIT</c>, this visual's bitmap and clip are composed with the specified border mode. In addition, this border mode becomes the new default for the children of the current visual. That is, if the border mode of this visual's children is unchanged or explicitly set to <b>DCOMPOSITION_BORDER_MODE_INHERIT</b>, the bitmaps and clips of the child visuals are composed using the border mode of this visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setbordermode
		// HRESULT SetBorderMode( [in] DCOMPOSITION_BORDER_MODE borderMode );
		new void SetBorderMode([In] DCOMPOSITION_BORDER_MODE borderMode);

		/// <summary>Sets the Clip property of this visual to the specified clip object. The Clip property restricts the rendering of the visual subtree that is rooted at this visual to a rectangular region.</summary>
		/// <param name="clip">
		///   <para>Type: <b><c>IDCompositionClip</c>*</b></para>
		///   <para>The clip object to associate with this visual. This parameter can be NULL. All float properties of IDCompositionRectangleClip have a numerical limit of -2^21 to 2^21. The API accepts numbers outside of this range, but they are always clamped to this range.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Clip property clips this visual along with all visuals in the subtree that is rooted at this visual. The clip is transformed by the OffsetX, OffsetY, and Transform properties.</para>
		///   <para>If the Clip property previously specified a clip rectangle, the newly specified Clip object replaces the clip rectangle.</para>
		///   <para>This method fails if <i>clip</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		///   <para>If <i>clip</i> is NULL, the visual is not clipped relative to its parent. However, the visual is clipped by the clip object of the parent visual, or by the closest ancestor visual that has a clip object. Setting <i>clip</i> to NULL is similar to specifying a clip object whose clip rectangle has the left and top sides set to negative infinity, and the right and bottom sides set to positive infinity. Using a NULL clip object results in slightly better performance.</para>
		///   <para>If <i>clip</i> specifies a clip object that has an empty rectangle, the visual is fully clipped; that is, the visual is included in the visual tree, but it does not render anything. To exclude a particular visual from a composition, remove the visual from the visual tree instead of setting an empty clip rectangle. Removing the visual results in better performance.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setclip(idcompositionclip)
		// HRESULT SetClip( [in, optional] IDCompositionClip *clip );
		new void SetClip([In, Optional] IDCompositionClip? clip);

		/// <summary>Sets the Clip property of this visual to the specified rectangle. The Clip property restricts the rendering of the visual subtree that is rooted at this visual to the specified rectangular region.</summary>
		/// <param name="rect">
		///   <para>Type: <b>const <c>D2D_RECT_F</c></b></para>
		///   <para>The rectangle to use to clip this visual. All properties of the rect parameter have a numerical limit of -2^21 to 2^21. The API accepts numbers outside of this range, but they are always clamped to this range.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Clip property clips this visual along with all visuals in the subtree that is rooted at this visual. The clip is transformed by the OffsetX, OffsetY, and Transform properties.</para>
		///   <para>If the Clip property previously specified a clip object, the newly specified clip rectangle replaces the clip object.</para>
		///   <para>This method fails if any members of the <i>rect</i> structure are NaN, positive infinity, or negative infinity.</para>
		///   <para>If the clip rectangle is empty, the visual is fully clipped; that is, the visual is included in the visual tree, but it does not render anything. To exclude a particular visual from a composition, remove the visual from the visual tree instead of setting an empty clip rectangle. Removing the visual results in better performance.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setclip(constd2d_rect_f_)
		// HRESULT SetClip( [in, ref] const D2D_RECT_F &amp; rect );
		new void SetClip(in D2D_RECT_F rect);

		/// <summary>Sets the Content property of this visual to the specified bitmap or window wrapper.</summary>
		/// <param name="content">
		/// <para>Type: <b><c>IUnknown</c>*</b></para>
		/// <para>The object that is the new content of this visual. This parameter can be NULL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See <c>DirectComposition Error Codes</c> for a list of error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <i>content</i> parameter must point to one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>An object that implements the <c>IDCompositionSurface</c> interface.</description>
		/// </item>
		/// <item>
		/// <description>An object that implements the <b>IDXGISwapChain1</b> interface.</description>
		/// </item>
		/// <item>
		/// <description>A wrapper object that is returned by the <c>CreateSurfaceFromHandle</c> or <c>CreateSurfaceFromHwnd</c> method.</description>
		/// </item>
		/// </list>
		/// <para>The new content replaces any content that was previously associated with the visual. If the <i>content</i> parameter is NULL, the visual has no associated content.</para>
		/// <para>A visual can be associated with a bitmap object or a window wrapper. A bitmap is either a Microsoft DirectX swap chain or a Microsoft DirectComposition surface.</para>
		/// <para>A window wrapper is created with the <c>CreateSurfaceFromHwnd</c> method and is a stand-in for the rasterization of another window, which must be a top-level window or a layered child window. A window wrapper is conceptually equivalent to a bitmap that is the size of the target window on which the contents of the window are drawn. The contents include the target window's child windows (layered or otherwise), and any DirectComposition content that is drawn in the child windows.</para>
		/// <para>A DirectComposition surface wrapper is created with the <c>CreateSurfaceFromHandle</c> method and is a reference to a swap chain. An application might use a surface wrapper in a cross-process scenario where one process creates the swap chain and another process associates the bitmap with a visual.</para>
		/// <para>The bitmap is always drawn at position (0,0) relative to the visual's coordinate system, although the coordinate system is directly affected by the OffsetX, OffsetY, and Transform properties, as well as indirectly by the transformations on ancestor visuals. The bitmap of a visual is always drawn behind the children of that visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setcontent
		// HRESULT SetContent( [in, optional] IUnknown *content );
		new void SetContent([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? content);

		/// <summary>Adds a new child visual to the children list of this visual.</summary>
		/// <param name="visual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The child visual to add. This parameter must not be NULL.</para>
		/// </param>
		/// <param name="insertAbove">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>TRUE to place the new child visual in front of the visual specified by the <i>referenceVisual</i> parameter, or FALSE to place it behind <i>referenceVisual</i>.</para>
		/// </param>
		/// <param name="referenceVisual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The existing child visual next to which the new visual should be added.</para>
		/// </param>
		/// <remarks>
		///   <para>Child visuals are arranged in an ordered list. The contents of a child visual are drawn in front of (or above) the contents of its parent visual, but behind (or below) the contents of its children.</para>
		///   <para>The <i>referenceVisual</i> parameter must be an existing child of the parent visual, or it must be NULL. The <i>insertAbove</i> parameter indicates whether the new child should be rendered immediately above the reference visual in the Z order, or immediately below it.</para>
		///   <para>If the <i>referenceVisual</i> parameter is NULL, the specified visual is rendered above or below all children of the parent visual, depending on the value of the <i>insertAbove</i> parameter. If <i>insertAbove</i> is TRUE, the new child visual is above no sibling, therefore it is rendered below all of its siblings. Conversely, if <i>insertAbove</i> is FALSE, the visual is below no sibling, therefore it is rendered above all of its siblings.</para>
		///   <para>The visual specified by the <i>visual</i> parameter cannot be either a child of a single other visual, or the root of a visual tree that is associated with a composition target. If <i>visual</i> is already a child of another visual, <b>AddVisual</b> fails. The child visual must be removed from the children list of its previous parent before adding it to the children list of the new parent. If <i>visual</i> is the root of a visual tree, the visual must be dissociated from that visual tree before adding it to the children list of the new parent. To dissociate the visual from a visual tree, call the <c>IDCompositionTarget::SetRoot</c> method and specify either a different visual or NULL as the <i>visual</i> parameter.</para>
		///   <para>A child visual need not have been created by the same <c>IDCompositionDevice</c> interface as its parent. When visuals from different devices are combined in the same visual tree, Microsoft DirectComposition composes the tree as it normally would, except that changes to a particular visual take effect only when <c>IDCompositionDevice::Commit</c> is called on the device object that created the visual. The ability to combine visuals from different devices enables multiple threads to create and manipulate a single visual tree while maintaining independent devices that can be used to commit changes asynchronously</para>
		///   <para>This method fails if <i>visual</i> or <i>referenceVisual</i> is an invalid pointer, or if the visual referenced by the <i>referenceVisual</i> parameter is not a child of the parent visual. These interfaces cannot be custom implementations; only interfaces created by DirectComposition can be used with this method.</para>
		///   <para>Examples</para>
		///   <para>For an example, see <c>How to Build a Simple Visual Tree</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-addvisual
		// HRESULT AddVisual( [in] IDCompositionVisual *visual, [in] BOOL insertAbove, [in, optional] IDCompositionVisual *referenceVisual );
		new void AddVisual([In] IDCompositionVisual visual, bool insertAbove, [In, Optional] IDCompositionVisual? referenceVisual);

		/// <summary>Removes a child visual from the children list of this visual.</summary>
		/// <param name="visual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The child visual to remove from the children list. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>The child visual is removed from the list of children. The order of the remaining child visuals is not changed.</para>
		///   <para>This method fails if <i>visual</i> is not a child of the parent visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-removevisual
		// HRESULT RemoveVisual( [in] IDCompositionVisual *visual );
		new void RemoveVisual([In] IDCompositionVisual visual);

		/// <summary>Removes all visuals from the children list of this visual.</summary>
		/// <remarks>This method can be called even if this visual has no children.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-removeallvisuals
		// HRESULT RemoveAllVisuals();
		new void RemoveAllVisuals();

		/// <summary>Sets the blending mode for this visual.</summary>
		/// <param name="compositeMode">
		///   <para>Type: <b><c>DCOMPOSITION_COMPOSITE_MODE</c></b></para>
		///   <para>The blending mode to use when composing the visual to the screen.</para>
		/// </param>
		/// <remarks>The composite mode determines how visual's bitmap is blended with the screen. By default, the visual is blended with "source over" semantics; that is, the colors are blended with per-pixel transparency.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setcompositemode
		// HRESULT SetCompositeMode( [in] DCOMPOSITION_COMPOSITE_MODE compositeMode );
		new void SetCompositeMode([In] DCOMPOSITION_COMPOSITE_MODE compositeMode);

		/// <summary>Sets the opacity mode for this visual.</summary>
		/// <param name="mode">The opacity mode to use when composing the visual to the screen.</param>
		/// <remarks>
		///   <para>The opacity mode affects how the Opacity property of an effect group object affects the composition of a visual sub-tree. DirectComposition supports two opacity modes: Layer and Multiply. In Layer mode, each visual sub-tree can be logically viewed as a bitmap that contains the opaque rasterization of that entire sub-tree, to which the opacity value is then applied. In this manner, overlapping opaque surfaces blend with the sub-tree’s background, but not with each other. In contrast, in Multiply mode the opacity is applied individually to each surface as it is composed, so surfaces blend with each other. Multiply mode is faster than Layer mode and always preferred if the visual tree contains entirely non-overlapping contents. However, Multiply mode may produce undesired visual results for overlapping elements.</para>
		///   <para>By default, a visual inherits the opacity mode of its parent visual, which may inherit the opacity mode of its parent visual, and so on. A visual uses the DCOMPOSITION_OPACITY_MODE_LAYER mode if this method is never called for the visual, or if this method is called with DCOMPOSITION_OPACITY_MODE_INHERIT. If no visuals set the opacity mode, the default for the entire visual tree is DCOMPOSITION_OPACITY_MODE_LAYER.</para>
		///   <para>If the <i>opacityMode</i> parameter is anything other than DCOMPOSITION_OPACITY_MODE_INHERIT, this visual's surfaces are composed with the specified opacity mode. In addition, this opacity mode becomes the new default for the children of the current visual. That is, if the opacity mode of this visual's children is unchanged or explicitly set to DCOMPOSITION_OPACITY_MODE_INHERIT, the surfaces the child visuals are composed using the opacity mode of this visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual2-setopacitymode
		// HRESULT SetOpacityMode( [in] DCOMPOSITION_OPACITY_MODE mode );
		void SetOpacityMode([In] DCOMPOSITION_OPACITY_MODE mode);

		/// <summary>Specifies whether or not surfaces that have 3D transformations applied to them should be displayed when facing away from the observer.</summary>
		/// <param name="visibility">
		///   <para>[in]</para>
		///   <para>The back face visibility to use when composing surfaces in this visual’s sub-tree to the screen.</para>
		/// </param>
		/// <remarks>
		///   <para>The back face visibility property affects how surfaces that have 3D transformations applied are rendered.</para>
		///   <para>By default, a visual inherits the back face visibility property of its parent visual, which may inherit the back face visibility property of its parent visual, and so on. A visual uses the DCOMPOSITION_BACKFACE_VISIBILITY_VISIBLE mode if this method is never called for the visual, or if this method is called with DCOMPOSITION_BACKFACE_VISIBILITY_INHERIT. If no visuals set the back face visibility property, the default for the entire visual tree is DCOMPOSITION_BACKFACE_VISIBILITY_VISIBLE.</para>
		///   <para>If the <i>visibility</i> parameter is anything other than DCOMPOSITION_BACKFACE_VISIBILITY_INHERIT, this visual's surfaces are composed with the specified visibility mode. In addition, this visibility mode becomes the new default for the children of the current visual. That is, if the visibility mode of this visual's children is unchanged or explicitly set to DCOMPOSITION_BACKFACE_VISIBILITY_INHERIT, the surfaces the child visuals are composed using the visibility mode of this visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual2-setbackfacevisibility
		// HRESULT SetBackFaceVisibility( DCOMPOSITION_BACKFACE_VISIBILITY visibility );
		void SetBackFaceVisibility([In] DCOMPOSITION_BACKFACE_VISIBILITY visibility);
	}

	/// <summary>Represents a debug visual.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionvisualdebug
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionVisualDebug")]
	[ComImport, Guid("FED2B808-5EB4-43A0-AEA3-35F65280F91B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows8.1")]
#endif
	public interface IDCompositionVisualDebug : IDCompositionVisual2
	{
		/// <summary>Changes the value of the OffsetX property of this visual. The OffsetX property specifies the new offset of the visual along the x-axis, relative to the parent visual.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the OffsetX property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the animation object referenced by the <i>animation</i> parameter is changed after this call, the change does not affect the OffsetX property unless this method is called again. If the OffsetX property was previously animated, this method replaces that animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsetx(idcompositionanimation)
		// HRESULT SetOffsetX( [in] IDCompositionAnimation *animation );
		new void SetOffsetX(IDCompositionAnimation animation);

		/// <summary>Changes the value of the OffsetX property of this visual. The OffsetX property specifies the new offset of the visual along the x-axis, relative to the parent visual.</summary>
		/// <param name="offsetX">
		///   <para>Type: <b>float</b></para>
		///   <para>The new offset of the visual along the x-axis, in pixels.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>offsetX</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>Changing the OffsetX property of a visual transforms the coordinate system of the entire visual subtree that is rooted at that visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>A transformation that is specified by the Transform property is applied after the OffsetX property. In other words, the effect of setting the Transform property and the OffsetX property is the same as setting only the Transform property on a transform group object where the first member of the group is an <c>IDCompositionTranslateTransform</c> object that has the same OffsetX value as <i>offsetX</i>. However, you should use <b>IDCompositionVisual::SetOffsetX</b> whenever possible because it is slightly faster.</para>
		///   <para>If the OffsetX and OffsetY properties are set to 0, and the Transform property is set to NULL, the coordinate system of the visual is the same as that of its parent.</para>
		///   <para>If the OffsetX property was previously animated, this method removes the animation and sets the property to the specified static value.</para>
		///   <para>Examples</para>
		///   <para>For an example, see <c>How to Build a Simple Visual Tree</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsetx(float)
		// HRESULT SetOffsetX( [in] float offsetX );
		new void SetOffsetX(float offsetX);

		/// <summary>Animates the value of the OffsetY property of this visual. The OffsetY property specifies the new offset of the visual along the y-axis, relative to the parent visual.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the OffsetY property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the animation object referenced by the <i>animation</i> parameter is changed after this call, the change does not affect the OffsetY property unless this method is called again. If the OffsetY property was previously animated, this method replaces that animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsety(idcompositionanimation)
		// HRESULT SetOffsetY( [in] IDCompositionAnimation *animation );
		new void SetOffsetY(IDCompositionAnimation animation);

		/// <summary>Changes the value of the OffsetY property of this visual. The OffsetY property specifies the new offset of the visual along the y-axis, relative to the parent visual.</summary>
		/// <param name="offsetY">
		///   <para>Type: <b>float</b></para>
		///   <para>The new offset of the visual along the y-axis, in pixels.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>offsetY</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>Changing the OffsetY property transforms the coordinate system of the entire visual subtree that is rooted at this visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>A transformation that is specified by the Transform property is applied after the OffsetY property. In other words, the effect of setting the Transform property and the OffsetY property is the same as setting only the Transform property on a transform group object where the first member of the group is an <c>IDCompositionTranslateTransform</c> object that has the same OffsetY value as <i>offsetY</i>. However, you should use <b>IDCompositionVisual::SetOffsetY</b> whenever possible because it is slightly faster.</para>
		///   <para>If the OffsetX and OffsetY properties are set to 0, and the Transform property is set to NULL, the coordinate system of the visual is the same as that of its parent.</para>
		///   <para>If the OffsetY property was previously animated, this method removes the animation and sets the property to the specified static value.</para>
		///   <para>Examples</para>
		///   <para>For an example, see <c>How to Build a Simple Visual Tree</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsety(float)
		// HRESULT SetOffsetY( [in] float offsetY );
		new void SetOffsetY(float offsetY);

		/// <summary>Sets the Transform property of this visual to the specified 2D transform object.</summary>
		/// <param name="transform">
		///   <para>Type: <b><c>IDCompositionTransform</c>*</b></para>
		///   <para>The transform object that is used to modify the coordinate system of this visual. This parameter can point to an <c>IDCompositionTransform</c> interface or one of its derived interfaces. This parameter can be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Transform property transforms the coordinate system of the entire visual subtree that is rooted at this visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>If the Transform property previously specified a transform matrix, the newly specified transform object replaces the transform matrix.</para>
		///   <para>A transformation specified by the Transform property is applied after the OffsetX and OffsetY properties. In other words, the effect of setting the Transform property and the OffsetX and OffsetY properties is the same as setting only the Transform property on a transform group where the first member of the group is an <c>IDCompositionTranslateTransform</c> object that has those same OffsetX and OffsetY values. However, you should use the <c>IDCompositionVisual::SetOffsetX</c> and <c>SetOffsetY</c> methods whenever possible because they are slightly faster.</para>
		///   <para>This method fails if <i>transform</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		///   <para>If the <i>transform</i> parameter is NULL, the coordinate system of this visual is transformed only by its OffsetX and OffsetY properties. Setting the Transform property to NULL is equivalent to setting it to an <c>IDCompositionMatrixTransform</c> object where the specified matrix is the identity matrix. However, an application should set the Transform property to NULL whenever possible because it is slightly faster.</para>
		///   <para>If the OffsetX and OffsetY properties are set to 0, and the Transform property is set to NULL, the coordinate system of the visual is the same as that of its parent.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-settransform(idcompositiontransform)
		// HRESULT SetTransform( [in, optional] IDCompositionTransform *transform );
		new void SetTransform([In, Optional] IDCompositionTransform? transform);

		/// <summary>Sets the Transform property of this visual to the specified 3-by-2 transform matrix.</summary>
		/// <param name="matrix">
		///   <para>Type: <b>const <c>D2D_MATRIX_3X2_F</c></b></para>
		///   <para>The 3-by-2 transform matrix that is used to modify the coordinate system of this visual.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Transform property transforms the coordinate system of the entire visual subtree that is rooted at this visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>If the Transform property previously specified a transform object, the newly specified transform matrix replaces the transform object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-settransform(constd2d_matrix_3x2_f_)
		// HRESULT SetTransform( [in, ref] const D2D_MATRIX_3X2_F &amp; matrix );
		new void SetTransform(in D2D_MATRIX_3X2_F matrix);

		/// <summary>Sets the TransformParent property of this visual. The TransformParent property establishes the coordinate system relative to which this visual is composed.</summary>
		/// <param name="visual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The new visual that establishes the base coordinate system for this visual. This parameter can be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>The coordinate system of a visual is modified by the OffsetX, OffsetY, and Transform properties. Normally, these properties define the coordinate system of a visual relative to its immediate parent. This method specifies the visual relative to which the coordinate system for this visual is based. The specified visual must be an ancestor of the current visual. If it is not an ancestor, the coordinate system is based on this visual's immediate parent, just as if the TransformParent property were set to NULL. Because visuals can be reparented, this property can take effect again if the specified visual becomes an ancestor of the target visual through a reparenting operation.</para>
		///   <para>If the <i>visual</i> parameter is NULL, the coordinate system is always transformed relative to the visual's immediate parent. This is the default behavior if this method is not used.</para>
		///   <para>This method fails if the <i>visual</i> parameter is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-settransformparent
		// HRESULT SetTransformParent( [in, optional] IDCompositionVisual *visual );
		new void SetTransformParent([In, Optional] IDCompositionVisual? visual);

		/// <summary>Sets the Effect property of this visual. The Effect property modifies how the subtree that is rooted at this visual is blended with the background, and can apply a 3D perspective transform to the visual.</summary>
		/// <param name="effect">
		///   <para>Type: <b><c>IDCompositionEffect</c>*</b></para>
		///   <para>A pointer to an effect object. This parameter can be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method creates an implicit off-screen surface to which the subtree that is rooted at this visual is composed. The surface is used as one of the inputs to the specified effect. The output of the effect is composed directly to the composition target. Some effects also use the composition target as another implicit input. This is typically the case for compositional or blend effects such as opacity, where the composition target is considered to be the "background." In that case, any visuals that are "behind" the current visual are included in the composition target when the current visual is rendered and are considered to be the "background" that this visual composes to.</para>
		///   <para>If this visual is not the root of a visual tree and one of its ancestors also has an effect applied to it, the off-screen surface created by the closest ancestor is the composition target to which this visual's effect is composed. Otherwise, the composition target is the root composition target. As a consequence, the background for compositional and blend effects includes only the visuals up to the closest ancestor that itself has an effect. Conversely, any effects applied to visuals under the current visual use the newly created off-screen surface as the background, which may affect how those visuals ultimately compose on top of what the end user perceives as being "behind" those visuals.</para>
		///   <para>If the <i>effect</i> parameter is NULL, no bitmap effect is applied to this visual. Any previous effects that were associated with this visual are removed. The off-screen surface is also removed and the visual subtree is composed directly to the parent composition target, which may also affect how compositional or blend effects under this visual are rendered.</para>
		///   <para>This method fails if <i>effect</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-seteffect
		// HRESULT SetEffect( [in, optional] IDCompositionEffect *effect );
		new void SetEffect([In, Optional] IDCompositionEffect? effect);

		/// <summary>Sets the BitmapInterpolationMode property, which specifies the mode for Microsoft DirectComposition to use when interpolating pixels from bitmaps that are not axis-aligned or drawn exactly at scale.</summary>
		/// <param name="interpolationMode">
		///   <para>Type: <b><c>DCOMPOSITION_BITMAP_INTERPOLATION_MODE</c></b></para>
		///   <para>The interpolation mode to use.</para>
		/// </param>
		/// <remarks>
		///   <para>The interpolation mode affects how a bitmap is composed when it is transformed such that there is no one-to-one correspondence between pixels in the bitmap and pixels on the screen.</para>
		///   <para>By default, a visual inherits the interpolation mode of the parent visual, which may inherit the interpolation mode of its parent visual, and so on. A visual uses the default interpolation mode if this method is never called for the visual, or if this method is called with <c>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_INHERIT</c>. If no visuals set the interpolation mode, the default for the entire visual tree is nearest neighbor interpolation, which offers the lowest visual quality but the highest performance.</para>
		///   <para>If the <i>interpolationMode</i> parameter is anything other than <c>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_INHERIT</c>, this visual's bitmap is composed with the specified interpolation mode, and this mode becomes the new default mode for the children of this visual. That is, if the interpolation mode of this visual's children is unchanged or explicitly set to <b>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_INHERIT</b>, the bitmaps of the child visuals are composed using the interpolation mode of this visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setbitmapinterpolationmode
		// HRESULT SetBitmapInterpolationMode( [in] DCOMPOSITION_BITMAP_INTERPOLATION_MODE interpolationMode );
		new void SetBitmapInterpolationMode([In] DCOMPOSITION_BITMAP_INTERPOLATION_MODE interpolationMode);

		/// <summary>Sets the BorderMode property, which specifies how to compose the edges of bitmaps and clips associated with this visual, or with visuals in the subtree rooted at this visual.</summary>
		/// <param name="borderMode">
		///   <para>Type: <b><c>DCOMPOSITION_BORDER_MODE</c></b></para>
		///   <para>The border mode to use.</para>
		/// </param>
		/// <remarks>
		///   <para>The border mode affects how the edges of a bitmap are composed when the bitmap is transformed such that the edges are not exactly axis-aligned and at precise pixel boundaries. It also affects how content is clipped at the corners of a clip that has rounded corners, and at the edge of a clip that is transformed such that the edges are not exactly axis-aligned and at precise pixel boundaries.</para>
		///   <para>By default, a visual inherits the border mode of its parent visual, which may inherit the border mode of its parent visual, and so on. A visual uses the default border mode if this method is never called for the visual, or if this method is called with <c>DCOMPOSITION_BORDER_MODE_INHERIT</c>. If no visuals set the border mode, the default for the entire visual tree is aliased rendering, which offers the lowest visual quality but the highest performance.</para>
		///   <para>If the <i>borderMode</i> parameter is anything other than <c>DCOMPOSITION_BORDER_MODE_INHERIT</c>, this visual's bitmap and clip are composed with the specified border mode. In addition, this border mode becomes the new default for the children of the current visual. That is, if the border mode of this visual's children is unchanged or explicitly set to <b>DCOMPOSITION_BORDER_MODE_INHERIT</b>, the bitmaps and clips of the child visuals are composed using the border mode of this visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setbordermode
		// HRESULT SetBorderMode( [in] DCOMPOSITION_BORDER_MODE borderMode );
		new void SetBorderMode([In] DCOMPOSITION_BORDER_MODE borderMode);

		/// <summary>Sets the Clip property of this visual to the specified clip object. The Clip property restricts the rendering of the visual subtree that is rooted at this visual to a rectangular region.</summary>
		/// <param name="clip">
		///   <para>Type: <b><c>IDCompositionClip</c>*</b></para>
		///   <para>The clip object to associate with this visual. This parameter can be NULL. All float properties of IDCompositionRectangleClip have a numerical limit of -2^21 to 2^21. The API accepts numbers outside of this range, but they are always clamped to this range.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Clip property clips this visual along with all visuals in the subtree that is rooted at this visual. The clip is transformed by the OffsetX, OffsetY, and Transform properties.</para>
		///   <para>If the Clip property previously specified a clip rectangle, the newly specified Clip object replaces the clip rectangle.</para>
		///   <para>This method fails if <i>clip</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		///   <para>If <i>clip</i> is NULL, the visual is not clipped relative to its parent. However, the visual is clipped by the clip object of the parent visual, or by the closest ancestor visual that has a clip object. Setting <i>clip</i> to NULL is similar to specifying a clip object whose clip rectangle has the left and top sides set to negative infinity, and the right and bottom sides set to positive infinity. Using a NULL clip object results in slightly better performance.</para>
		///   <para>If <i>clip</i> specifies a clip object that has an empty rectangle, the visual is fully clipped; that is, the visual is included in the visual tree, but it does not render anything. To exclude a particular visual from a composition, remove the visual from the visual tree instead of setting an empty clip rectangle. Removing the visual results in better performance.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setclip(idcompositionclip)
		// HRESULT SetClip( [in, optional] IDCompositionClip *clip );
		new void SetClip([In, Optional] IDCompositionClip? clip);

		/// <summary>Sets the Clip property of this visual to the specified rectangle. The Clip property restricts the rendering of the visual subtree that is rooted at this visual to the specified rectangular region.</summary>
		/// <param name="rect">
		///   <para>Type: <b>const <c>D2D_RECT_F</c></b></para>
		///   <para>The rectangle to use to clip this visual. All properties of the rect parameter have a numerical limit of -2^21 to 2^21. The API accepts numbers outside of this range, but they are always clamped to this range.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Clip property clips this visual along with all visuals in the subtree that is rooted at this visual. The clip is transformed by the OffsetX, OffsetY, and Transform properties.</para>
		///   <para>If the Clip property previously specified a clip object, the newly specified clip rectangle replaces the clip object.</para>
		///   <para>This method fails if any members of the <i>rect</i> structure are NaN, positive infinity, or negative infinity.</para>
		///   <para>If the clip rectangle is empty, the visual is fully clipped; that is, the visual is included in the visual tree, but it does not render anything. To exclude a particular visual from a composition, remove the visual from the visual tree instead of setting an empty clip rectangle. Removing the visual results in better performance.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setclip(constd2d_rect_f_)
		// HRESULT SetClip( [in, ref] const D2D_RECT_F &amp; rect );
		new void SetClip(in D2D_RECT_F rect);

		/// <summary>Sets the Content property of this visual to the specified bitmap or window wrapper.</summary>
		/// <param name="content">
		/// <para>Type: <b><c>IUnknown</c>*</b></para>
		/// <para>The object that is the new content of this visual. This parameter can be NULL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See <c>DirectComposition Error Codes</c> for a list of error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <i>content</i> parameter must point to one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>An object that implements the <c>IDCompositionSurface</c> interface.</description>
		/// </item>
		/// <item>
		/// <description>An object that implements the <b>IDXGISwapChain1</b> interface.</description>
		/// </item>
		/// <item>
		/// <description>A wrapper object that is returned by the <c>CreateSurfaceFromHandle</c> or <c>CreateSurfaceFromHwnd</c> method.</description>
		/// </item>
		/// </list>
		/// <para>The new content replaces any content that was previously associated with the visual. If the <i>content</i> parameter is NULL, the visual has no associated content.</para>
		/// <para>A visual can be associated with a bitmap object or a window wrapper. A bitmap is either a Microsoft DirectX swap chain or a Microsoft DirectComposition surface.</para>
		/// <para>A window wrapper is created with the <c>CreateSurfaceFromHwnd</c> method and is a stand-in for the rasterization of another window, which must be a top-level window or a layered child window. A window wrapper is conceptually equivalent to a bitmap that is the size of the target window on which the contents of the window are drawn. The contents include the target window's child windows (layered or otherwise), and any DirectComposition content that is drawn in the child windows.</para>
		/// <para>A DirectComposition surface wrapper is created with the <c>CreateSurfaceFromHandle</c> method and is a reference to a swap chain. An application might use a surface wrapper in a cross-process scenario where one process creates the swap chain and another process associates the bitmap with a visual.</para>
		/// <para>The bitmap is always drawn at position (0,0) relative to the visual's coordinate system, although the coordinate system is directly affected by the OffsetX, OffsetY, and Transform properties, as well as indirectly by the transformations on ancestor visuals. The bitmap of a visual is always drawn behind the children of that visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setcontent
		// HRESULT SetContent( [in, optional] IUnknown *content );
		new void SetContent([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? content);

		/// <summary>Adds a new child visual to the children list of this visual.</summary>
		/// <param name="visual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The child visual to add. This parameter must not be NULL.</para>
		/// </param>
		/// <param name="insertAbove">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>TRUE to place the new child visual in front of the visual specified by the <i>referenceVisual</i> parameter, or FALSE to place it behind <i>referenceVisual</i>.</para>
		/// </param>
		/// <param name="referenceVisual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The existing child visual next to which the new visual should be added.</para>
		/// </param>
		/// <remarks>
		///   <para>Child visuals are arranged in an ordered list. The contents of a child visual are drawn in front of (or above) the contents of its parent visual, but behind (or below) the contents of its children.</para>
		///   <para>The <i>referenceVisual</i> parameter must be an existing child of the parent visual, or it must be NULL. The <i>insertAbove</i> parameter indicates whether the new child should be rendered immediately above the reference visual in the Z order, or immediately below it.</para>
		///   <para>If the <i>referenceVisual</i> parameter is NULL, the specified visual is rendered above or below all children of the parent visual, depending on the value of the <i>insertAbove</i> parameter. If <i>insertAbove</i> is TRUE, the new child visual is above no sibling, therefore it is rendered below all of its siblings. Conversely, if <i>insertAbove</i> is FALSE, the visual is below no sibling, therefore it is rendered above all of its siblings.</para>
		///   <para>The visual specified by the <i>visual</i> parameter cannot be either a child of a single other visual, or the root of a visual tree that is associated with a composition target. If <i>visual</i> is already a child of another visual, <b>AddVisual</b> fails. The child visual must be removed from the children list of its previous parent before adding it to the children list of the new parent. If <i>visual</i> is the root of a visual tree, the visual must be dissociated from that visual tree before adding it to the children list of the new parent. To dissociate the visual from a visual tree, call the <c>IDCompositionTarget::SetRoot</c> method and specify either a different visual or NULL as the <i>visual</i> parameter.</para>
		///   <para>A child visual need not have been created by the same <c>IDCompositionDevice</c> interface as its parent. When visuals from different devices are combined in the same visual tree, Microsoft DirectComposition composes the tree as it normally would, except that changes to a particular visual take effect only when <c>IDCompositionDevice::Commit</c> is called on the device object that created the visual. The ability to combine visuals from different devices enables multiple threads to create and manipulate a single visual tree while maintaining independent devices that can be used to commit changes asynchronously</para>
		///   <para>This method fails if <i>visual</i> or <i>referenceVisual</i> is an invalid pointer, or if the visual referenced by the <i>referenceVisual</i> parameter is not a child of the parent visual. These interfaces cannot be custom implementations; only interfaces created by DirectComposition can be used with this method.</para>
		///   <para>Examples</para>
		///   <para>For an example, see <c>How to Build a Simple Visual Tree</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-addvisual
		// HRESULT AddVisual( [in] IDCompositionVisual *visual, [in] BOOL insertAbove, [in, optional] IDCompositionVisual *referenceVisual );
		new void AddVisual([In] IDCompositionVisual visual, bool insertAbove, [In, Optional] IDCompositionVisual? referenceVisual);

		/// <summary>Removes a child visual from the children list of this visual.</summary>
		/// <param name="visual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The child visual to remove from the children list. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>The child visual is removed from the list of children. The order of the remaining child visuals is not changed.</para>
		///   <para>This method fails if <i>visual</i> is not a child of the parent visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-removevisual
		// HRESULT RemoveVisual( [in] IDCompositionVisual *visual );
		new void RemoveVisual([In] IDCompositionVisual visual);

		/// <summary>Removes all visuals from the children list of this visual.</summary>
		/// <remarks>This method can be called even if this visual has no children.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-removeallvisuals
		// HRESULT RemoveAllVisuals();
		new void RemoveAllVisuals();

		/// <summary>Sets the blending mode for this visual.</summary>
		/// <param name="compositeMode">
		///   <para>Type: <b><c>DCOMPOSITION_COMPOSITE_MODE</c></b></para>
		///   <para>The blending mode to use when composing the visual to the screen.</para>
		/// </param>
		/// <remarks>The composite mode determines how visual's bitmap is blended with the screen. By default, the visual is blended with "source over" semantics; that is, the colors are blended with per-pixel transparency.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setcompositemode
		// HRESULT SetCompositeMode( [in] DCOMPOSITION_COMPOSITE_MODE compositeMode );
		new void SetCompositeMode([In] DCOMPOSITION_COMPOSITE_MODE compositeMode);

		/// <summary>Sets the opacity mode for this visual.</summary>
		/// <param name="mode">The opacity mode to use when composing the visual to the screen.</param>
		/// <remarks>
		///   <para>The opacity mode affects how the Opacity property of an effect group object affects the composition of a visual sub-tree. DirectComposition supports two opacity modes: Layer and Multiply. In Layer mode, each visual sub-tree can be logically viewed as a bitmap that contains the opaque rasterization of that entire sub-tree, to which the opacity value is then applied. In this manner, overlapping opaque surfaces blend with the sub-tree’s background, but not with each other. In contrast, in Multiply mode the opacity is applied individually to each surface as it is composed, so surfaces blend with each other. Multiply mode is faster than Layer mode and always preferred if the visual tree contains entirely non-overlapping contents. However, Multiply mode may produce undesired visual results for overlapping elements.</para>
		///   <para>By default, a visual inherits the opacity mode of its parent visual, which may inherit the opacity mode of its parent visual, and so on. A visual uses the DCOMPOSITION_OPACITY_MODE_LAYER mode if this method is never called for the visual, or if this method is called with DCOMPOSITION_OPACITY_MODE_INHERIT. If no visuals set the opacity mode, the default for the entire visual tree is DCOMPOSITION_OPACITY_MODE_LAYER.</para>
		///   <para>If the <i>opacityMode</i> parameter is anything other than DCOMPOSITION_OPACITY_MODE_INHERIT, this visual's surfaces are composed with the specified opacity mode. In addition, this opacity mode becomes the new default for the children of the current visual. That is, if the opacity mode of this visual's children is unchanged or explicitly set to DCOMPOSITION_OPACITY_MODE_INHERIT, the surfaces the child visuals are composed using the opacity mode of this visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual2-setopacitymode
		// HRESULT SetOpacityMode( [in] DCOMPOSITION_OPACITY_MODE mode );
		new void SetOpacityMode([In] DCOMPOSITION_OPACITY_MODE mode);

		/// <summary>Specifies whether or not surfaces that have 3D transformations applied to them should be displayed when facing away from the observer.</summary>
		/// <param name="visibility">
		///   <para>[in]</para>
		///   <para>The back face visibility to use when composing surfaces in this visual’s sub-tree to the screen.</para>
		/// </param>
		/// <remarks>
		///   <para>The back face visibility property affects how surfaces that have 3D transformations applied are rendered.</para>
		///   <para>By default, a visual inherits the back face visibility property of its parent visual, which may inherit the back face visibility property of its parent visual, and so on. A visual uses the DCOMPOSITION_BACKFACE_VISIBILITY_VISIBLE mode if this method is never called for the visual, or if this method is called with DCOMPOSITION_BACKFACE_VISIBILITY_INHERIT. If no visuals set the back face visibility property, the default for the entire visual tree is DCOMPOSITION_BACKFACE_VISIBILITY_VISIBLE.</para>
		///   <para>If the <i>visibility</i> parameter is anything other than DCOMPOSITION_BACKFACE_VISIBILITY_INHERIT, this visual's surfaces are composed with the specified visibility mode. In addition, this visibility mode becomes the new default for the children of the current visual. That is, if the visibility mode of this visual's children is unchanged or explicitly set to DCOMPOSITION_BACKFACE_VISIBILITY_INHERIT, the surfaces the child visuals are composed using the visibility mode of this visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual2-setbackfacevisibility
		// HRESULT SetBackFaceVisibility( DCOMPOSITION_BACKFACE_VISIBILITY visibility );
		new void SetBackFaceVisibility([In] DCOMPOSITION_BACKFACE_VISIBILITY visibility);

		/// <summary>Enables a visual heatmap that represents overdraw regions.</summary>
		/// <param name="color" />
		/// <remarks>Heatmaps can be enabled by calling <b>EnableHeatMap</b>. The heatmaps are drawn on the source of the VisualDebug visual and child visuals. The heatmaps are represented in a specified color for all visual content. The heatmap color must have a transparency in order to see the overlaying overdraw regions. The colored surfaces are blended together to visually show all overdraw regions in a single view.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisualdebug-enableheatmap
		// HRESULT EnableHeatMap( [in] const D2D1_COLOR_F &amp; color );
		void EnableHeatMap(in D3DCOLORVALUE color);

		/// <summary>Disables visual heatmaps.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisualdebug-disableheatmap
		// HRESULT DisableHeatMap();
		void DisableHeatMap();

		/// <summary>Enables highlighting visuals when content is being redrawn.</summary>
		/// <remarks>Highlighting redraw regions can be enabled by calling <b>EnableRedrawRegions</b>. With this function, redrawn client areas are visually highlighted every frame the visual is updated. Redraw regions are drawn on the source of the VisualDebug and child visuals. Redraw is triggered when properties of a visual are updated. The updated visual does not necessarily need to visually change to trigger a redraw. The highlighting will cycle through Blue, Yellow, Pink and Green to provide an order of which content is being updated. The redraw regions are only visible while the window of the VisualDebug is being updated.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisualdebug-enableredrawregions
		// HRESULT EnableRedrawRegions();
		void EnableRedrawRegions();

		/// <summary>Disables visual redraw regions.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisualdebug-disableredrawregions
		// HRESULT DisableRedrawRegions();
		void DisableRedrawRegions();
	}

	/// <summary>Represents one DirectComposition visual in a visual tree.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionvisual3
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionVisual3")]
	[ComImport, Guid("2775F462-B6C1-4015-B0BE-B3E7D6A4976D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows10.0")]
#endif
	public interface IDCompositionVisual3 : IDCompositionVisualDebug
	{
		/// <summary>Changes the value of the OffsetX property of this visual. The OffsetX property specifies the new offset of the visual along the x-axis, relative to the parent visual.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the OffsetX property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the animation object referenced by the <i>animation</i> parameter is changed after this call, the change does not affect the OffsetX property unless this method is called again. If the OffsetX property was previously animated, this method replaces that animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsetx(idcompositionanimation)
		// HRESULT SetOffsetX( [in] IDCompositionAnimation *animation );
		new void SetOffsetX(IDCompositionAnimation animation);

		/// <summary>Changes the value of the OffsetX property of this visual. The OffsetX property specifies the new offset of the visual along the x-axis, relative to the parent visual.</summary>
		/// <param name="offsetX">
		///   <para>Type: <b>float</b></para>
		///   <para>The new offset of the visual along the x-axis, in pixels.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>offsetX</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>Changing the OffsetX property of a visual transforms the coordinate system of the entire visual subtree that is rooted at that visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>A transformation that is specified by the Transform property is applied after the OffsetX property. In other words, the effect of setting the Transform property and the OffsetX property is the same as setting only the Transform property on a transform group object where the first member of the group is an <c>IDCompositionTranslateTransform</c> object that has the same OffsetX value as <i>offsetX</i>. However, you should use <b>IDCompositionVisual::SetOffsetX</b> whenever possible because it is slightly faster.</para>
		///   <para>If the OffsetX and OffsetY properties are set to 0, and the Transform property is set to NULL, the coordinate system of the visual is the same as that of its parent.</para>
		///   <para>If the OffsetX property was previously animated, this method removes the animation and sets the property to the specified static value.</para>
		///   <para>Examples</para>
		///   <para>For an example, see <c>How to Build a Simple Visual Tree</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsetx(float)
		// HRESULT SetOffsetX( [in] float offsetX );
		new void SetOffsetX(float offsetX);

		/// <summary>Animates the value of the OffsetY property of this visual. The OffsetY property specifies the new offset of the visual along the y-axis, relative to the parent visual.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation object that determines how the value of the OffsetY property changes over time. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method makes a copy of the specified animation. If the animation object referenced by the <i>animation</i> parameter is changed after this call, the change does not affect the OffsetY property unless this method is called again. If the OffsetY property was previously animated, this method replaces that animation with the new animation.</para>
		///   <para>This method fails if <i>animation</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsety(idcompositionanimation)
		// HRESULT SetOffsetY( [in] IDCompositionAnimation *animation );
		new void SetOffsetY(IDCompositionAnimation animation);

		/// <summary>Changes the value of the OffsetY property of this visual. The OffsetY property specifies the new offset of the visual along the y-axis, relative to the parent visual.</summary>
		/// <param name="offsetY">
		///   <para>Type: <b>float</b></para>
		///   <para>The new offset of the visual along the y-axis, in pixels.</para>
		/// </param>
		/// <remarks>
		///   <para>This method fails if the <i>offsetY</i> parameter is NaN, positive infinity, or negative infinity.</para>
		///   <para>Changing the OffsetY property transforms the coordinate system of the entire visual subtree that is rooted at this visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>A transformation that is specified by the Transform property is applied after the OffsetY property. In other words, the effect of setting the Transform property and the OffsetY property is the same as setting only the Transform property on a transform group object where the first member of the group is an <c>IDCompositionTranslateTransform</c> object that has the same OffsetY value as <i>offsetY</i>. However, you should use <b>IDCompositionVisual::SetOffsetY</b> whenever possible because it is slightly faster.</para>
		///   <para>If the OffsetX and OffsetY properties are set to 0, and the Transform property is set to NULL, the coordinate system of the visual is the same as that of its parent.</para>
		///   <para>If the OffsetY property was previously animated, this method removes the animation and sets the property to the specified static value.</para>
		///   <para>Examples</para>
		///   <para>For an example, see <c>How to Build a Simple Visual Tree</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setoffsety(float)
		// HRESULT SetOffsetY( [in] float offsetY );
		new void SetOffsetY(float offsetY);

		/// <summary>Sets the Transform property of this visual to the specified 2D transform object.</summary>
		/// <param name="transform">
		///   <para>Type: <b><c>IDCompositionTransform</c>*</b></para>
		///   <para>The transform object that is used to modify the coordinate system of this visual. This parameter can point to an <c>IDCompositionTransform</c> interface or one of its derived interfaces. This parameter can be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Transform property transforms the coordinate system of the entire visual subtree that is rooted at this visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>If the Transform property previously specified a transform matrix, the newly specified transform object replaces the transform matrix.</para>
		///   <para>A transformation specified by the Transform property is applied after the OffsetX and OffsetY properties. In other words, the effect of setting the Transform property and the OffsetX and OffsetY properties is the same as setting only the Transform property on a transform group where the first member of the group is an <c>IDCompositionTranslateTransform</c> object that has those same OffsetX and OffsetY values. However, you should use the <c>IDCompositionVisual::SetOffsetX</c> and <c>SetOffsetY</c> methods whenever possible because they are slightly faster.</para>
		///   <para>This method fails if <i>transform</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		///   <para>If the <i>transform</i> parameter is NULL, the coordinate system of this visual is transformed only by its OffsetX and OffsetY properties. Setting the Transform property to NULL is equivalent to setting it to an <c>IDCompositionMatrixTransform</c> object where the specified matrix is the identity matrix. However, an application should set the Transform property to NULL whenever possible because it is slightly faster.</para>
		///   <para>If the OffsetX and OffsetY properties are set to 0, and the Transform property is set to NULL, the coordinate system of the visual is the same as that of its parent.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-settransform(idcompositiontransform)
		// HRESULT SetTransform( [in, optional] IDCompositionTransform *transform );
		new void SetTransform([In, Optional] IDCompositionTransform? transform);

		/// <summary>Sets the Transform property of this visual to the specified 3-by-2 transform matrix.</summary>
		/// <param name="matrix">
		///   <para>Type: <b>const <c>D2D_MATRIX_3X2_F</c></b></para>
		///   <para>The 3-by-2 transform matrix that is used to modify the coordinate system of this visual.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Transform property transforms the coordinate system of the entire visual subtree that is rooted at this visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>If the Transform property previously specified a transform object, the newly specified transform matrix replaces the transform object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-settransform(constd2d_matrix_3x2_f_)
		// HRESULT SetTransform( [in, ref] const D2D_MATRIX_3X2_F &amp; matrix );
		new void SetTransform(in D2D_MATRIX_3X2_F matrix);

		/// <summary>Sets the TransformParent property of this visual. The TransformParent property establishes the coordinate system relative to which this visual is composed.</summary>
		/// <param name="visual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The new visual that establishes the base coordinate system for this visual. This parameter can be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>The coordinate system of a visual is modified by the OffsetX, OffsetY, and Transform properties. Normally, these properties define the coordinate system of a visual relative to its immediate parent. This method specifies the visual relative to which the coordinate system for this visual is based. The specified visual must be an ancestor of the current visual. If it is not an ancestor, the coordinate system is based on this visual's immediate parent, just as if the TransformParent property were set to NULL. Because visuals can be reparented, this property can take effect again if the specified visual becomes an ancestor of the target visual through a reparenting operation.</para>
		///   <para>If the <i>visual</i> parameter is NULL, the coordinate system is always transformed relative to the visual's immediate parent. This is the default behavior if this method is not used.</para>
		///   <para>This method fails if the <i>visual</i> parameter is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface as this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-settransformparent
		// HRESULT SetTransformParent( [in, optional] IDCompositionVisual *visual );
		new void SetTransformParent([In, Optional] IDCompositionVisual? visual);

		/// <summary>Sets the Effect property of this visual. The Effect property modifies how the subtree that is rooted at this visual is blended with the background, and can apply a 3D perspective transform to the visual.</summary>
		/// <param name="effect">
		///   <para>Type: <b><c>IDCompositionEffect</c>*</b></para>
		///   <para>A pointer to an effect object. This parameter can be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>This method creates an implicit off-screen surface to which the subtree that is rooted at this visual is composed. The surface is used as one of the inputs to the specified effect. The output of the effect is composed directly to the composition target. Some effects also use the composition target as another implicit input. This is typically the case for compositional or blend effects such as opacity, where the composition target is considered to be the "background." In that case, any visuals that are "behind" the current visual are included in the composition target when the current visual is rendered and are considered to be the "background" that this visual composes to.</para>
		///   <para>If this visual is not the root of a visual tree and one of its ancestors also has an effect applied to it, the off-screen surface created by the closest ancestor is the composition target to which this visual's effect is composed. Otherwise, the composition target is the root composition target. As a consequence, the background for compositional and blend effects includes only the visuals up to the closest ancestor that itself has an effect. Conversely, any effects applied to visuals under the current visual use the newly created off-screen surface as the background, which may affect how those visuals ultimately compose on top of what the end user perceives as being "behind" those visuals.</para>
		///   <para>If the <i>effect</i> parameter is NULL, no bitmap effect is applied to this visual. Any previous effects that were associated with this visual are removed. The off-screen surface is also removed and the visual subtree is composed directly to the parent composition target, which may also affect how compositional or blend effects under this visual are rendered.</para>
		///   <para>This method fails if <i>effect</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-seteffect
		// HRESULT SetEffect( [in, optional] IDCompositionEffect *effect );
		new void SetEffect([In, Optional] IDCompositionEffect? effect);

		/// <summary>Sets the BitmapInterpolationMode property, which specifies the mode for Microsoft DirectComposition to use when interpolating pixels from bitmaps that are not axis-aligned or drawn exactly at scale.</summary>
		/// <param name="interpolationMode">
		///   <para>Type: <b><c>DCOMPOSITION_BITMAP_INTERPOLATION_MODE</c></b></para>
		///   <para>The interpolation mode to use.</para>
		/// </param>
		/// <remarks>
		///   <para>The interpolation mode affects how a bitmap is composed when it is transformed such that there is no one-to-one correspondence between pixels in the bitmap and pixels on the screen.</para>
		///   <para>By default, a visual inherits the interpolation mode of the parent visual, which may inherit the interpolation mode of its parent visual, and so on. A visual uses the default interpolation mode if this method is never called for the visual, or if this method is called with <c>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_INHERIT</c>. If no visuals set the interpolation mode, the default for the entire visual tree is nearest neighbor interpolation, which offers the lowest visual quality but the highest performance.</para>
		///   <para>If the <i>interpolationMode</i> parameter is anything other than <c>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_INHERIT</c>, this visual's bitmap is composed with the specified interpolation mode, and this mode becomes the new default mode for the children of this visual. That is, if the interpolation mode of this visual's children is unchanged or explicitly set to <b>DCOMPOSITION_BITMAP_INTERPOLATION_MODE_INHERIT</b>, the bitmaps of the child visuals are composed using the interpolation mode of this visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setbitmapinterpolationmode
		// HRESULT SetBitmapInterpolationMode( [in] DCOMPOSITION_BITMAP_INTERPOLATION_MODE interpolationMode );
		new void SetBitmapInterpolationMode([In] DCOMPOSITION_BITMAP_INTERPOLATION_MODE interpolationMode);

		/// <summary>Sets the BorderMode property, which specifies how to compose the edges of bitmaps and clips associated with this visual, or with visuals in the subtree rooted at this visual.</summary>
		/// <param name="borderMode">
		///   <para>Type: <b><c>DCOMPOSITION_BORDER_MODE</c></b></para>
		///   <para>The border mode to use.</para>
		/// </param>
		/// <remarks>
		///   <para>The border mode affects how the edges of a bitmap are composed when the bitmap is transformed such that the edges are not exactly axis-aligned and at precise pixel boundaries. It also affects how content is clipped at the corners of a clip that has rounded corners, and at the edge of a clip that is transformed such that the edges are not exactly axis-aligned and at precise pixel boundaries.</para>
		///   <para>By default, a visual inherits the border mode of its parent visual, which may inherit the border mode of its parent visual, and so on. A visual uses the default border mode if this method is never called for the visual, or if this method is called with <c>DCOMPOSITION_BORDER_MODE_INHERIT</c>. If no visuals set the border mode, the default for the entire visual tree is aliased rendering, which offers the lowest visual quality but the highest performance.</para>
		///   <para>If the <i>borderMode</i> parameter is anything other than <c>DCOMPOSITION_BORDER_MODE_INHERIT</c>, this visual's bitmap and clip are composed with the specified border mode. In addition, this border mode becomes the new default for the children of the current visual. That is, if the border mode of this visual's children is unchanged or explicitly set to <b>DCOMPOSITION_BORDER_MODE_INHERIT</b>, the bitmaps and clips of the child visuals are composed using the border mode of this visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setbordermode
		// HRESULT SetBorderMode( [in] DCOMPOSITION_BORDER_MODE borderMode );
		new void SetBorderMode([In] DCOMPOSITION_BORDER_MODE borderMode);

		/// <summary>Sets the Clip property of this visual to the specified clip object. The Clip property restricts the rendering of the visual subtree that is rooted at this visual to a rectangular region.</summary>
		/// <param name="clip">
		///   <para>Type: <b><c>IDCompositionClip</c>*</b></para>
		///   <para>The clip object to associate with this visual. This parameter can be NULL. All float properties of IDCompositionRectangleClip have a numerical limit of -2^21 to 2^21. The API accepts numbers outside of this range, but they are always clamped to this range.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Clip property clips this visual along with all visuals in the subtree that is rooted at this visual. The clip is transformed by the OffsetX, OffsetY, and Transform properties.</para>
		///   <para>If the Clip property previously specified a clip rectangle, the newly specified Clip object replaces the clip rectangle.</para>
		///   <para>This method fails if <i>clip</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		///   <para>If <i>clip</i> is NULL, the visual is not clipped relative to its parent. However, the visual is clipped by the clip object of the parent visual, or by the closest ancestor visual that has a clip object. Setting <i>clip</i> to NULL is similar to specifying a clip object whose clip rectangle has the left and top sides set to negative infinity, and the right and bottom sides set to positive infinity. Using a NULL clip object results in slightly better performance.</para>
		///   <para>If <i>clip</i> specifies a clip object that has an empty rectangle, the visual is fully clipped; that is, the visual is included in the visual tree, but it does not render anything. To exclude a particular visual from a composition, remove the visual from the visual tree instead of setting an empty clip rectangle. Removing the visual results in better performance.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setclip(idcompositionclip)
		// HRESULT SetClip( [in, optional] IDCompositionClip *clip );
		new void SetClip([In, Optional] IDCompositionClip? clip);

		/// <summary>Sets the Clip property of this visual to the specified rectangle. The Clip property restricts the rendering of the visual subtree that is rooted at this visual to the specified rectangular region.</summary>
		/// <param name="rect">
		///   <para>Type: <b>const <c>D2D_RECT_F</c></b></para>
		///   <para>The rectangle to use to clip this visual. All properties of the rect parameter have a numerical limit of -2^21 to 2^21. The API accepts numbers outside of this range, but they are always clamped to this range.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Clip property clips this visual along with all visuals in the subtree that is rooted at this visual. The clip is transformed by the OffsetX, OffsetY, and Transform properties.</para>
		///   <para>If the Clip property previously specified a clip object, the newly specified clip rectangle replaces the clip object.</para>
		///   <para>This method fails if any members of the <i>rect</i> structure are NaN, positive infinity, or negative infinity.</para>
		///   <para>If the clip rectangle is empty, the visual is fully clipped; that is, the visual is included in the visual tree, but it does not render anything. To exclude a particular visual from a composition, remove the visual from the visual tree instead of setting an empty clip rectangle. Removing the visual results in better performance.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setclip(constd2d_rect_f_)
		// HRESULT SetClip( [in, ref] const D2D_RECT_F &amp; rect );
		new void SetClip(in D2D_RECT_F rect);

		/// <summary>Sets the Content property of this visual to the specified bitmap or window wrapper.</summary>
		/// <param name="content">
		/// <para>Type: <b><c>IUnknown</c>*</b></para>
		/// <para>The object that is the new content of this visual. This parameter can be NULL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns S_OK. Otherwise, it returns an <c>HRESULT</c> error code. See <c>DirectComposition Error Codes</c> for a list of error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <i>content</i> parameter must point to one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>An object that implements the <c>IDCompositionSurface</c> interface.</description>
		/// </item>
		/// <item>
		/// <description>An object that implements the <b>IDXGISwapChain1</b> interface.</description>
		/// </item>
		/// <item>
		/// <description>A wrapper object that is returned by the <c>CreateSurfaceFromHandle</c> or <c>CreateSurfaceFromHwnd</c> method.</description>
		/// </item>
		/// </list>
		/// <para>The new content replaces any content that was previously associated with the visual. If the <i>content</i> parameter is NULL, the visual has no associated content.</para>
		/// <para>A visual can be associated with a bitmap object or a window wrapper. A bitmap is either a Microsoft DirectX swap chain or a Microsoft DirectComposition surface.</para>
		/// <para>A window wrapper is created with the <c>CreateSurfaceFromHwnd</c> method and is a stand-in for the rasterization of another window, which must be a top-level window or a layered child window. A window wrapper is conceptually equivalent to a bitmap that is the size of the target window on which the contents of the window are drawn. The contents include the target window's child windows (layered or otherwise), and any DirectComposition content that is drawn in the child windows.</para>
		/// <para>A DirectComposition surface wrapper is created with the <c>CreateSurfaceFromHandle</c> method and is a reference to a swap chain. An application might use a surface wrapper in a cross-process scenario where one process creates the swap chain and another process associates the bitmap with a visual.</para>
		/// <para>The bitmap is always drawn at position (0,0) relative to the visual's coordinate system, although the coordinate system is directly affected by the OffsetX, OffsetY, and Transform properties, as well as indirectly by the transformations on ancestor visuals. The bitmap of a visual is always drawn behind the children of that visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setcontent
		// HRESULT SetContent( [in, optional] IUnknown *content );
		new void SetContent([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? content);

		/// <summary>Adds a new child visual to the children list of this visual.</summary>
		/// <param name="visual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The child visual to add. This parameter must not be NULL.</para>
		/// </param>
		/// <param name="insertAbove">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>TRUE to place the new child visual in front of the visual specified by the <i>referenceVisual</i> parameter, or FALSE to place it behind <i>referenceVisual</i>.</para>
		/// </param>
		/// <param name="referenceVisual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The existing child visual next to which the new visual should be added.</para>
		/// </param>
		/// <remarks>
		///   <para>Child visuals are arranged in an ordered list. The contents of a child visual are drawn in front of (or above) the contents of its parent visual, but behind (or below) the contents of its children.</para>
		///   <para>The <i>referenceVisual</i> parameter must be an existing child of the parent visual, or it must be NULL. The <i>insertAbove</i> parameter indicates whether the new child should be rendered immediately above the reference visual in the Z order, or immediately below it.</para>
		///   <para>If the <i>referenceVisual</i> parameter is NULL, the specified visual is rendered above or below all children of the parent visual, depending on the value of the <i>insertAbove</i> parameter. If <i>insertAbove</i> is TRUE, the new child visual is above no sibling, therefore it is rendered below all of its siblings. Conversely, if <i>insertAbove</i> is FALSE, the visual is below no sibling, therefore it is rendered above all of its siblings.</para>
		///   <para>The visual specified by the <i>visual</i> parameter cannot be either a child of a single other visual, or the root of a visual tree that is associated with a composition target. If <i>visual</i> is already a child of another visual, <b>AddVisual</b> fails. The child visual must be removed from the children list of its previous parent before adding it to the children list of the new parent. If <i>visual</i> is the root of a visual tree, the visual must be dissociated from that visual tree before adding it to the children list of the new parent. To dissociate the visual from a visual tree, call the <c>IDCompositionTarget::SetRoot</c> method and specify either a different visual or NULL as the <i>visual</i> parameter.</para>
		///   <para>A child visual need not have been created by the same <c>IDCompositionDevice</c> interface as its parent. When visuals from different devices are combined in the same visual tree, Microsoft DirectComposition composes the tree as it normally would, except that changes to a particular visual take effect only when <c>IDCompositionDevice::Commit</c> is called on the device object that created the visual. The ability to combine visuals from different devices enables multiple threads to create and manipulate a single visual tree while maintaining independent devices that can be used to commit changes asynchronously</para>
		///   <para>This method fails if <i>visual</i> or <i>referenceVisual</i> is an invalid pointer, or if the visual referenced by the <i>referenceVisual</i> parameter is not a child of the parent visual. These interfaces cannot be custom implementations; only interfaces created by DirectComposition can be used with this method.</para>
		///   <para>Examples</para>
		///   <para>For an example, see <c>How to Build a Simple Visual Tree</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-addvisual
		// HRESULT AddVisual( [in] IDCompositionVisual *visual, [in] BOOL insertAbove, [in, optional] IDCompositionVisual *referenceVisual );
		new void AddVisual([In] IDCompositionVisual visual, bool insertAbove, [In, Optional] IDCompositionVisual? referenceVisual);

		/// <summary>Removes a child visual from the children list of this visual.</summary>
		/// <param name="visual">
		///   <para>Type: <b><c>IDCompositionVisual</c>*</b></para>
		///   <para>The child visual to remove from the children list. This parameter must not be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>The child visual is removed from the list of children. The order of the remaining child visuals is not changed.</para>
		///   <para>This method fails if <i>visual</i> is not a child of the parent visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-removevisual
		// HRESULT RemoveVisual( [in] IDCompositionVisual *visual );
		new void RemoveVisual([In] IDCompositionVisual visual);

		/// <summary>Removes all visuals from the children list of this visual.</summary>
		/// <remarks>This method can be called even if this visual has no children.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-removeallvisuals
		// HRESULT RemoveAllVisuals();
		new void RemoveAllVisuals();

		/// <summary>Sets the blending mode for this visual.</summary>
		/// <param name="compositeMode">
		///   <para>Type: <b><c>DCOMPOSITION_COMPOSITE_MODE</c></b></para>
		///   <para>The blending mode to use when composing the visual to the screen.</para>
		/// </param>
		/// <remarks>The composite mode determines how visual's bitmap is blended with the screen. By default, the visual is blended with "source over" semantics; that is, the colors are blended with per-pixel transparency.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual-setcompositemode
		// HRESULT SetCompositeMode( [in] DCOMPOSITION_COMPOSITE_MODE compositeMode );
		new void SetCompositeMode([In] DCOMPOSITION_COMPOSITE_MODE compositeMode);

		/// <summary>Sets the opacity mode for this visual.</summary>
		/// <param name="mode">The opacity mode to use when composing the visual to the screen.</param>
		/// <remarks>
		///   <para>The opacity mode affects how the Opacity property of an effect group object affects the composition of a visual sub-tree. DirectComposition supports two opacity modes: Layer and Multiply. In Layer mode, each visual sub-tree can be logically viewed as a bitmap that contains the opaque rasterization of that entire sub-tree, to which the opacity value is then applied. In this manner, overlapping opaque surfaces blend with the sub-tree’s background, but not with each other. In contrast, in Multiply mode the opacity is applied individually to each surface as it is composed, so surfaces blend with each other. Multiply mode is faster than Layer mode and always preferred if the visual tree contains entirely non-overlapping contents. However, Multiply mode may produce undesired visual results for overlapping elements.</para>
		///   <para>By default, a visual inherits the opacity mode of its parent visual, which may inherit the opacity mode of its parent visual, and so on. A visual uses the DCOMPOSITION_OPACITY_MODE_LAYER mode if this method is never called for the visual, or if this method is called with DCOMPOSITION_OPACITY_MODE_INHERIT. If no visuals set the opacity mode, the default for the entire visual tree is DCOMPOSITION_OPACITY_MODE_LAYER.</para>
		///   <para>If the <i>opacityMode</i> parameter is anything other than DCOMPOSITION_OPACITY_MODE_INHERIT, this visual's surfaces are composed with the specified opacity mode. In addition, this opacity mode becomes the new default for the children of the current visual. That is, if the opacity mode of this visual's children is unchanged or explicitly set to DCOMPOSITION_OPACITY_MODE_INHERIT, the surfaces the child visuals are composed using the opacity mode of this visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual2-setopacitymode
		// HRESULT SetOpacityMode( [in] DCOMPOSITION_OPACITY_MODE mode );
		new void SetOpacityMode([In] DCOMPOSITION_OPACITY_MODE mode);

		/// <summary>Specifies whether or not surfaces that have 3D transformations applied to them should be displayed when facing away from the observer.</summary>
		/// <param name="visibility">
		///   <para>[in]</para>
		///   <para>The back face visibility to use when composing surfaces in this visual’s sub-tree to the screen.</para>
		/// </param>
		/// <remarks>
		///   <para>The back face visibility property affects how surfaces that have 3D transformations applied are rendered.</para>
		///   <para>By default, a visual inherits the back face visibility property of its parent visual, which may inherit the back face visibility property of its parent visual, and so on. A visual uses the DCOMPOSITION_BACKFACE_VISIBILITY_VISIBLE mode if this method is never called for the visual, or if this method is called with DCOMPOSITION_BACKFACE_VISIBILITY_INHERIT. If no visuals set the back face visibility property, the default for the entire visual tree is DCOMPOSITION_BACKFACE_VISIBILITY_VISIBLE.</para>
		///   <para>If the <i>visibility</i> parameter is anything other than DCOMPOSITION_BACKFACE_VISIBILITY_INHERIT, this visual's surfaces are composed with the specified visibility mode. In addition, this visibility mode becomes the new default for the children of the current visual. That is, if the visibility mode of this visual's children is unchanged or explicitly set to DCOMPOSITION_BACKFACE_VISIBILITY_INHERIT, the surfaces the child visuals are composed using the visibility mode of this visual.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual2-setbackfacevisibility
		// HRESULT SetBackFaceVisibility( DCOMPOSITION_BACKFACE_VISIBILITY visibility );
		new void SetBackFaceVisibility([In] DCOMPOSITION_BACKFACE_VISIBILITY visibility);

		/// <summary>Enables a visual heatmap that represents overdraw regions.</summary>
		/// <param name="color" />
		/// <remarks>Heatmaps can be enabled by calling <b>EnableHeatMap</b>. The heatmaps are drawn on the source of the VisualDebug visual and child visuals. The heatmaps are represented in a specified color for all visual content. The heatmap color must have a transparency in order to see the overlaying overdraw regions. The colored surfaces are blended together to visually show all overdraw regions in a single view.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisualdebug-enableheatmap
		// HRESULT EnableHeatMap( [in] const D2D1_COLOR_F &amp; color );
		new void EnableHeatMap(in D3DCOLORVALUE color);

		/// <summary>Disables visual heatmaps.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisualdebug-disableheatmap
		// HRESULT DisableHeatMap();
		new void DisableHeatMap();

		/// <summary>Enables highlighting visuals when content is being redrawn.</summary>
		/// <remarks>Highlighting redraw regions can be enabled by calling <b>EnableRedrawRegions</b>. With this function, redrawn client areas are visually highlighted every frame the visual is updated. Redraw regions are drawn on the source of the VisualDebug and child visuals. Redraw is triggered when properties of a visual are updated. The updated visual does not necessarily need to visually change to trigger a redraw. The highlighting will cycle through Blue, Yellow, Pink and Green to provide an order of which content is being updated. The redraw regions are only visible while the window of the VisualDebug is being updated.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisualdebug-enableredrawregions
		// HRESULT EnableRedrawRegions();
		new void EnableRedrawRegions();

		/// <summary>Disables visual redraw regions.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisualdebug-disableredrawregions
		// HRESULT DisableRedrawRegions();
		new void DisableRedrawRegions();

		/// <summary>Sets the depth mode property associated with this visual.</summary>
		/// <param name="mode">
		///   <para>Type: <b>DCOMPOSITION_DEPTH_MODE</b></para>
		///   <para>The new depth mode.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual3-setdepthmode
		// HRESULT SetDepthMode( [in] DCOMPOSITION_DEPTH_MODE mode );
		void SetDepthMode([In] DCOMPOSITION_DEPTH_MODE mode);

		/// <summary>Changes the value of OffsetZ property.</summary>
		/// <param name="offsetZ">
		///   <para>Type: <b>float</b></para>
		///   <para>The new value.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual3-setoffsetz(float)
		// HRESULT SetOffsetZ( float offsetZ );
		void SetOffsetZ(float offsetZ);

		/// <summary>Animates the value of the OffsetZ property.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>The animation to control the OffsetZ property.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual3-setoffsetz(idcompositionanimation)
		// HRESULT SetOffsetZ( [in] IDCompositionAnimation *animation );
		void SetOffsetZ([In] IDCompositionAnimation animation);

		/// <summary>Sets the value of the visual's opacity property.</summary>
		/// <param name="opacity">
		///   <para>Type: <b>float</b></para>
		///   <para>The new value for the opacity property.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual3-setopacity(float)
		// HRESULT SetOpacity( float opacity );
		void SetOpacity(float opacity);

		/// <summary>Animates the value of the visual's opacity property.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>The animation that will be used to control the value of the opacity property.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual3-setopacity(idcompositionanimation)
		// HRESULT SetOpacity( [in] IDCompositionAnimation *animation );
		void SetOpacity([In] IDCompositionAnimation animation);

		/// <summary>Sets the Transform property of this visual to the specified 4-by-4 transform matrix.</summary>
		/// <param name="matrix">
		///   <para>Type: <b>const <c>D2D_MATRIX_4X4_F</c></b></para>
		///   <para>The 4-by-4 transform matrix that is used to modify the coordinate system of this visual.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Transform property transforms the coordinate system of the entire visual subtree that is rooted at this visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>If the Transform property previously specified a transform object, the newly specified transform matrix replaces the transform object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual3-settransform(constd2d_matrix_4x4_f_)
		// HRESULT SetTransform( [in, ref] const D2D_MATRIX_4X4_F &amp; matrix );
		void SetTransform(in D2D_MATRIX_4X4_F matrix);

		/// <summary>Sets the Transform property of this visual to the specified 3D transform object.</summary>
		/// <param name="transform">
		///   <para>Type: <b><c>IDCompositionTransform3D</c>*</b></para>
		///   <para>The transform object that is used to modify the coordinate system of this visual. This parameter can point to an <c>IDCompositionTransform</c> interface or one of its derived interfaces. This parameter can be NULL.</para>
		/// </param>
		/// <remarks>
		///   <para>Setting the Transform property transforms the coordinate system of the entire visual subtree that is rooted at this visual. If the Clip property of this visual is specified, the clip rectangle is also transformed.</para>
		///   <para>If the Transform property previously specified a transform matrix, the newly specified transform object replaces the transform matrix.</para>
		///   <para>A transformation specified by the Transform property is applied after the OffsetX and OffsetY properties. In other words, the effect of setting the Transform property and the OffsetX and OffsetY properties is the same as setting only the Transform property on a transform group where the first member of the group is an <c>IDCompositionTranslateTransform</c> object that has those same OffsetX and OffsetY values. However, you should use the <c>IDCompositionVisual::SetOffsetX</c> and <c>SetOffsetY</c> methods whenever possible because they are slightly faster.</para>
		///   <para>This method fails if <i>transform</i> is an invalid pointer or if it was not created by the same <c>IDCompositionDevice</c> interface that created this visual. The interface cannot be a custom implementation; only interfaces created by Microsoft DirectComposition can be used with this method.</para>
		///   <para>If the <i>transform</i> parameter is NULL, the coordinate system of this visual is transformed only by its OffsetX and OffsetY properties. Setting the Transform property to NULL is equivalent to setting it to an <c>IDCompositionMatrixTransform</c> object where the specified matrix is the identity matrix. However, an application should set the Transform property to NULL whenever possible because it is slightly faster.</para>
		///   <para>If the OffsetX and OffsetY properties are set to 0, and the Transform property is set to NULL, the coordinate system of the visual is the same as that of its parent.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual3-settransform(idcompositiontransform3d)
		// HRESULT SetTransform( [in, optional] IDCompositionTransform3D *transform );
		void SetTransform([In, Optional] IDCompositionTransform3D? transform);

		/// <summary>Changes the value of the visual's Visible property.</summary>
		/// <param name="visible">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>The new value for the visible property.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionvisual3-setvisible
		// HRESULT SetVisible( BOOL visible );
		void SetVisible([MarshalAs(UnmanagedType.Bool)] bool visible);
	}

	/// <summary>Serves as a factory for all other Microsoft DirectComposition objects and provides methods to control transactional composition.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositiondevice3
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionDevice3")]
	[ComImport, Guid("0987CB06-F916-48BF-8D35-CE7641781BD9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !NET5_0
	[SupportedOSPlatform("windows10.0")]
#endif
	public interface IDCompositionDevice3 : IDCompositionDevice2
	{
		/// <summary>Commits all DirectComposition commands that are pending on this device.</summary>
		/// <remarks>
		///   <para>Calls to DirectComposition methods are always batched and executed atomically as a single transaction. Calls take effect only when <b>IDCompositionDevice2::Commit</b> is called, at which time all pending method calls for a device are executed at once.</para>
		///   <para>An application that uses multiple devices must call <b>Commit</b> for each device separately. However, because the composition engine processes the calls individually, the batch of commands might not take effect at the same time.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-commit
		// HRESULT Commit();
		new void Commit();

		/// <summary>Waits for the composition engine to finish processing the previous call to the <c>IDCompositionDevice2::Commit</c> method.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-waitforcommitcompletion
		// HRESULT WaitForCommitCompletion();
		new void WaitForCommitCompletion();

		/// <summary>Retrieves information from the composition engine about composition times and the frame rate.</summary>
		/// <returns>
		///   <para>Type: <b><c>DCOMPOSITION_FRAME_STATISTICS</c>*</b></para>
		///   <para>A structure that receives composition times and frame rate information.</para>
		/// </returns>
		/// <remarks>This method retrieves timing information about the composition engine that an application can use to synchronize the rasterization of bitmaps with independent animations.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-getframestatistics
		// HRESULT GetFrameStatistics( [out] DCOMPOSITION_FRAME_STATISTICS *statistics );
		new DCOMPOSITION_FRAME_STATISTICS GetFrameStatistics();

		/// <summary>Creates a new visual object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionVisual2</c>**</b></para>
		///   <para>The new visual object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new visual object has a static value of zero for the OffsetX and OffsetY properties, and NULL for the Transform, Clip, and Content properties. Initially, the visual does not cause the contents of a window to change. The visual must be added as a child of another visual, or as the root of a composition target, before it can affect the appearance of a window.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createvisual
		// HRESULT CreateVisual( [out] IDCompositionVisual2 **visual );
		new IDCompositionVisual2 CreateVisual();

		/// <summary>Creates a Microsoft DirectComposition surface factory object, which can be used to create other DirectComposition surface or virtual surface objects</summary>
		/// <param name="renderingDevice">A pointer to a DirectX device to be used to create DirectComposition surface objects. Must be a pointer to an object implementing the <c>IDXGIDevice</c> or <c>ID2D1Device</c> interfaces. This parameter must not be NULL.</param>
		/// <returns>The newly created surface factory object. This parameter must not be NULL.</returns>
		/// <remarks>
		///   <para>A surface factory allows an application to simultaneously use more than one single DXGI or Direct2D device with DirectComposition. Each surface factory has a permanent association with one DXGI or Direct2D device, but a DirectComposition device may have any number of surface factories.</para>
		///   <para>Each surface factory manages resources independently from the others. In particular, DirectComposition pools surface allocations to mitigate surface allocation and deallocation costs. This pool is done on a per-surface factory basis.</para>
		///   <para>If the <c>DCompositionCreateDevice2</c> function is called with a non-NULL <i>renderingDevice</i> parameter, the returned DirectComposition device object has an implicit surface factory under the covers associated with the given rendering device. This implicit surface factory is used to service the <c>IDCompositionDevice::CreateSurface</c>, <c>IDCompositionDevice::CreateVirtualSurface</c>, <c>IDCompositionDevice2::CreateSurface</c> and <c>IDCompositionDevice2::CreateVirtualSurface</c> methods.</para>
		///   <para>A surface object remains alive as long as any of the surfaces or virtual surfaces that it created remain alive, either directly because the application holds a direct reference, or indirectly because one or more such surfaces are associated with one or more visual objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createsurfacefactory
		// HRESULT CreateSurfaceFactory( [in] IUnknown *renderingDevice, [out] IDCompositionSurfaceFactory **surfaceFactory );
		new IDCompositionSurfaceFactory CreateSurfaceFactory([In, MarshalAs(UnmanagedType.IUnknown)] object renderingDevice);

		/// <summary>Creates an updateable surface object that can be associated with one or more visuals for composition.</summary>
		/// <param name="width">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The width of the surface, in pixels. Constrained by the <c>feature level</c> of the rendering device that was passed in at the time the DirectComposition device was created.</para>
		/// </param>
		/// <param name="height">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The height of the surface, in pixels. Constrained by the <c>feature level</c> of the rendering device that was passed in at the time the DirectComposition device was created.</para>
		/// </param>
		/// <param name="pixelFormat">
		///   <para>Type: <b><c>DXGI_FORMAT</c></b></para>
		///   <para>The pixel format of the surface.</para>
		/// </param>
		/// <param name="alphaMode">
		///   <para>Type: <b><c>DXGI_ALPHA_MODE</c></b></para>
		///   <para>The format of the alpha channel, if an alpha channel is included in the pixel format. It can be one of the following values:</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_UNSPECIFIED</b>
		///       </description>
		///       <description>The alpha channel is not specified. This value has the same effect as <b>DXGI_ALPHA_MODE_IGNORE</b>.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_PREMULTIPLIED</b>
		///       </description>
		///       <description>The color channels contain values that are premultiplied with the alpha channel.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_IGNORE</b>
		///       </description>
		///       <description>The alpha channel should be ignored and the bitmap should be rendered opaquely.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionSurface</c>**</b></para>
		///   <para>The newly created surface object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A Microsoft DirectComposition surface is a rectangular array of pixels that can be associated with a visual for composition.</para>
		///   <para>A newly created surface object is in an uninitialized state. While it is uninitialized, the surface has no effect on the composition of the visual tree. It behaves exactly like a surface that has 100% transparent pixels.</para>
		///   <para>To initialize the surface with pixel data, use the <c>IDCompositionSurface::BeginDraw</c> and <c>IDCompositionSurface::EndDraw</c> methods. The first call to this method must cover the entire surface area to provide an initial value for every pixel. Subsequent calls may specify smaller sub-rectangles of the surface to update.</para>
		///   <para>DirectComposition surfaces support the following pixel formats:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_B8G8R8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R8G8B8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R16G16B16A16_FLOAT</b>
		///       </description>
		///     </item>
		///   </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createsurface
		// HRESULT CreateSurface( [in] UINT width, [in] UINT height, [in] DXGI_FORMAT pixelFormat, [in] DXGI_ALPHA_MODE alphaMode, [out] IDCompositionSurface **surface );
		new IDCompositionSurface CreateSurface(uint width, uint height, [In] DXGI_FORMAT pixelFormat, [In] DXGI_ALPHA_MODE alphaMode);

		/// <summary>Creates a sparsely populated surface that can be associated with one or more visuals for composition.</summary>
		/// <param name="initialWidth">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The width of the surface, in pixels. The maximum width is 16,777,216 pixels.</para>
		/// </param>
		/// <param name="initialHeight">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The height of the surface, in pixels. The maximum height is 16,777,216 pixels.</para>
		/// </param>
		/// <param name="pixelFormat">
		///   <para>Type: <b><c>DXGI_FORMAT</c></b></para>
		///   <para>The pixel format of the surface.</para>
		/// </param>
		/// <param name="alphaMode">
		///   <para>Type: <b><c>DXGI_ALPHA_MODE</c></b></para>
		///   <para>The meaning of the alpha channel, if the pixel format contains an alpha channel. It can be one of the following values:</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_UNSPECIFIED</b>
		///       </description>
		///       <description>The alpha channel is not specified. This value has the same effect as <b>DXGI_ALPHA_MODE_IGNORE</b>.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_PREMULTIPLIED</b>
		///       </description>
		///       <description>The color channels contain values that are premultiplied with the alpha channel.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_IGNORE</b>
		///       </description>
		///       <description>The alpha channel should be ignored and the bitmap should be rendered opaquely.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionVirtualSurface</c>**</b></para>
		///   <para>The newly created surface object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A Microsoft DirectComposition sparse surface is a logical object that behaves like a rectangular array of pixels that can be associated with a visual for composition. The surface is not necessarily backed by any physical video or system memory for every one of its pixels. The application can realize or virtualize parts of the logical surface at different times.</para>
		///   <para>A newly created surface object is in an uninitialized state. While it is uninitialized, the surface has no effect on the composition of the visual tree. It behaves exactly like a surface that is initialized with 100% transparent pixels.</para>
		///   <para>To initialize the surface with pixel data, use the <c>IDCompositionSurface::BeginDraw</c> and <c>IDCompositionSurface::EndDraw</c> methods. This method not only provides pixels for the surface, but it also allocates actual storage space for those pixels. The memory allocation persists until the application returns some of the memory to the system. The application can free part or all of the allocated memory by calling the <c>IDCompositionVirtualSurface::Trim</c> method.</para>
		///   <para>DirectComposition surfaces support the following pixel formats:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_B8G8R8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R8G8B8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R16G16B16A16_FLOAT</b>
		///       </description>
		///     </item>
		///   </list>
		///   <para>This method fails if <i>initialWidth</i> or <i>initialHeight</i> exceeds 16,777,216 pixels.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createvirtualsurface
		// HRESULT CreateVirtualSurface( [in] UINT initialWidth, [in] UINT initialHeight, [in] DXGI_FORMAT pixelFormat, [in] DXGI_ALPHA_MODE alphaMode, [out] IDCompositionVirtualSurface **virtualSurface );
		new IDCompositionVirtualSurface CreateVirtualSurface(uint initialWidth, uint initialHeight, [In] DXGI_FORMAT pixelFormat, [In] DXGI_ALPHA_MODE alphaMode);

		/// <summary>Creates a 2D translation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTranslateTransform</c>**</b></para>
		///   <para>The new 2D translation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D translation transform object has a static value of zero for the OffsetX and OffsetY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtranslatetransform
		// HRESULT CreateTranslateTransform( [out] IDCompositionTranslateTransform **translateTransform );
		new IDCompositionTranslateTransform CreateTranslateTransform();

		/// <summary>Creates a 2D scale transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionScaleTransform</c>**</b></para>
		///   <para>The new 2D scale transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D scale transform object has a static value of zero for the ScaleX, ScaleY, CenterX, and CenterY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createscaletransform
		// HRESULT CreateScaleTransform( [out] IDCompositionScaleTransform **scaleTransform );
		new IDCompositionScaleTransform CreateScaleTransform();

		/// <summary>Creates a 2D rotation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionRotateTransform</c>**</b></para>
		///   <para>The new rotation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D rotation transform object has a static value of zero for the Angle, CenterX, and CenterY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createrotatetransform
		// HRESULT CreateRotateTransform( [out] IDCompositionRotateTransform **rotateTransform );
		new IDCompositionRotateTransform CreateRotateTransform();

		/// <summary>Creates a 2D skew transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionSkewTransform</c>**</b></para>
		///   <para>The new 2D skew transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D skew transform object has a static value of zero for the AngleX, AngleY, CenterX, and CenterY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createskewtransform
		// HRESULT CreateSkewTransform( [out] IDCompositionSkewTransform **skewTransform );
		new IDCompositionSkewTransform CreateSkewTransform();

		/// <summary>Creates a 2D 3-by-2 matrix transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionMatrixTransform</c>**</b></para>
		///   <para>The new matrix transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A new matrix transform object has the identity matrix as its initial value. The identity matrix is the 3x2 matrix with ones on the main diagonal and zeros elsewhere, as shown in the following illustration.</para>
		///   <para>When an identity transform is applied to an object, it does not change the position, shape, or size of the object. It is similar to the way that multiplying a number by one does not change the number. Any transform other than the identity transform will modify the position, shape, and/or size of objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-creatematrixtransform
		// HRESULT CreateMatrixTransform( [out] IDCompositionMatrixTransform **matrixTransform );
		new IDCompositionMatrixTransform CreateMatrixTransform();

		/// <summary>Creates a 2D transform group object that holds an array of 2D transform objects.</summary>
		/// <param name="transforms">
		///   <para>Type: <b><c>IDCompositionTransform</c>**</b></para>
		///   <para>An array of 2D transform objects that make up this transform group.</para>
		/// </param>
		/// <param name="elements">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The number of elements in the <i>transforms</i> array.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTransform</c>**</b></para>
		///   <para>The new transform group object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>The array entries in a transform group cannot be changed. However, each transform in the array can be modified through its own property setting methods. If a transform in the array is modified, the change is reflected in the computed matrix of the transform group.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtransformgroup
		// HRESULT CreateTransformGroup( [in] IDCompositionTransform **transforms, [in] UINT elements, [out] IDCompositionTransform **transformGroup );
		new IDCompositionTransform CreateTransformGroup([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.Interface)] IDCompositionTransform[] transforms, uint elements);

		/// <summary>Creates a 3D translation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTranslateTransform3D</c>**</b></para>
		///   <para>The new 3D translation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A newly created 3D translation transform has a static value of 0 for the OffsetX, OffsetY, and OffsetZ properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtranslatetransform3d
		// HRESULT CreateTranslateTransform3D( [out] IDCompositionTranslateTransform3D **translateTransform3D );
		new IDCompositionTranslateTransform3D CreateTranslateTransform3D();

		/// <summary>Creates a 3D scale transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionScaleTransform3D</c>**</b></para>
		///   <para>The new 3D scale transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 3D scale transform object has a static value of 1.0 for the ScaleX, ScaleY, and ScaleZ properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createscaletransform3d
		// HRESULT CreateScaleTransform3D( [out] IDCompositionScaleTransform3D **scaleTransform3D );
		new IDCompositionScaleTransform3D CreateScaleTransform3D();

		/// <summary>Creates a 3D rotation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionRotateTransform3D</c>**</b></para>
		///   <para>The new 3D rotation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 3D rotation transform object has a default static value of zero for the Angle, CenterX, CenterY, CenterZ, AxisX, and AxisY properties, and a default static value of 1.0 for the AxisZ property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createrotatetransform3d
		// HRESULT CreateRotateTransform3D( [out] IDCompositionRotateTransform3D **rotateTransform3D );
		new IDCompositionRotateTransform3D CreateRotateTransform3D();

		/// <summary>Creates a 3D 4-by-4 matrix transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionMatrixTransform3D</c>**</b></para>
		///   <para>The new 3D matrix transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>The new 3D matrix transform has the identity matrix as its value. The identity matrix is the 4-by-4 matrix with ones on the main diagonal and zeros elsewhere, as shown in the following illustration.</para>
		///   <para>When an identity transform is applied to an object, it does not change the position, shape, or size of the object. It is similar to the way that multiplying a number by one does not change the number. Any transform other than the identity transform will modify the position, shape, and/or size of objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-creatematrixtransform3d
		// HRESULT CreateMatrixTransform3D( [out] IDCompositionMatrixTransform3D **matrixTransform3D );
		new IDCompositionMatrixTransform3D CreateMatrixTransform3D();

		/// <summary>Creates a 3D transform group object that holds an array of 3D transform objects.</summary>
		/// <param name="transforms3D">
		///   <para>Type: <b><c>IDCompositionTransform3D</c>**</b></para>
		///   <para>An array of 3D transform objects that make up this transform group.</para>
		/// </param>
		/// <param name="elements">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The number of elements in the <i>transforms</i> array.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTransform3D</c>**</b></para>
		///   <para>The new 3D transform group object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>The array entries in a 3D transform group cannot be changed. However, each transform in the array can be modified through its own property setting methods. If a transform in the array is modified, the change is reflected in the computed matrix of the transform group.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtransform3dgroup
		// HRESULT CreateTransform3DGroup( [in] IDCompositionTransform3D **transforms3D, [in] UINT elements, [out] IDCompositionTransform3D **transform3DGroup );
		new IDCompositionTransform3D CreateTransform3DGroup([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.Interface)] IDCompositionTransform3D[] transforms3D, uint elements);

		/// <summary>Creates an object that represents multiple effects to be applied to a visual subtree.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionEffectGroup</c>**</b></para>
		///   <para>The new effect group object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>An effect group enables an application to apply multiple effects to a single visual subtree.</para>
		///   <para>A new effect group has a default opacity value of 1.0 and no 3D transformations.</para>
		///   <para>To set the opacity and transform values, use the corresponding methods on the <c>IDCompositionEffectGroup</c> that was created.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createeffectgroup
		// HRESULT CreateEffectGroup( [out] IDCompositionEffectGroup **effectGroup );
		new IDCompositionEffectGroup CreateEffectGroup();

		/// <summary>Creates a clip object that can be used to restrict the rendering of a visual subtree to a rectangular area.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionRectangleClip</c>**</b></para>
		///   <para>The new clip object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A newly created clip object has a value of -2^21 for the left and top properties, and a value of 2^21 for the right and bottom properties, effectively making it a no-op clip object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createrectangleclip
		// HRESULT CreateRectangleClip( [out] IDCompositionRectangleClip **clip );
		new IDCompositionRectangleClip CreateRectangleClip();

		/// <summary>Creates an animation object that is used to animate one or more scalar properties of one or more Microsoft DirectComposition objects.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionAnimation</c>**</b></para>
		///   <para>The new animation object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A number of DirectComposition object properties can have an animation object as the value of the property. When a property has an animation object as its value, DirectComposition redraws the visual at the refresh rate to reflect the changing value of the property that is being animated.</para>
		///   <para>A newly created animation object does not have any animation segments associated with it. An application must use the methods of the <c>IDCompositionAnimation</c> interface to build an animation function before setting the animation object as the property of another DirectComposition object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createanimation
		// HRESULT CreateAnimation( [out] IDCompositionAnimation **animation );
		new IDCompositionAnimation CreateAnimation();

		/// <summary>Creates an instance of <c>IDCompositionGaussianBlurEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionGaussianBlurEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionGaussianBlurEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-creategaussianblureffect
		// HRESULT CreateGaussianBlurEffect( [out] IDCompositionGaussianBlurEffect **gaussianBlurEffect );
		IDCompositionGaussianBlurEffect CreateGaussianBlurEffect();

		/// <summary>Creates an instance of <c>IDCompositionBrightnessEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionBrightnessEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionBrightnessEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createbrightnesseffect
		// HRESULT CreateBrightnessEffect( [out] IDCompositionBrightnessEffect **brightnessEffect );
		IDCompositionBrightnessEffect CreateBrightnessEffect();

		/// <summary>Creates an instance of <c>IDCompositionColorMatrixEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionColorMatrixEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionColorMatrixEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createcolormatrixeffect
		// HRESULT CreateColorMatrixEffect( [out] IDCompositionColorMatrixEffect **colorMatrixEffect );
		IDCompositionColorMatrixEffect CreateColorMatrixEffect();

		/// <summary>Creates an instance of <c>IDCompositionShadowEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionShadowEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionShadowEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createshadoweffect
		// HRESULT CreateShadowEffect( [out] IDCompositionShadowEffect **shadowEffect );
		IDCompositionShadowEffect CreateShadowEffect();

		/// <summary>Creates an instance of <c>IDCompositionHueRotationEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionHueRotationEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionHueRotationEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createhuerotationeffect
		// HRESULT CreateHueRotationEffect( [out] IDCompositionHueRotationEffect **hueRotationEffect );
		IDCompositionHueRotationEffect CreateHueRotationEffect();

		/// <summary>Creates an instance of <c>IDCompositionSaturationEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionSaturationEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionSaturationEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createsaturationeffect
		// HRESULT CreateSaturationEffect( [out] IDCompositionSaturationEffect **saturationEffect );
		IDCompositionSaturationEffect CreateSaturationEffect();

		/// <summary>Creates an instance of <c>IDCompositionTurbulenceEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTurbulenceEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionTurbulenceEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createturbulenceeffect
		// HRESULT CreateTurbulenceEffect( [out] IDCompositionTurbulenceEffect **turbulenceEffect );
		IDCompositionTurbulenceEffect CreateTurbulenceEffect();

		/// <summary>Creates an instance of <c>IDCompositionLinearTransferEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionLinearTransferEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionLinearTransferEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createlineartransfereffect
		// HRESULT CreateLinearTransferEffect( [out] IDCompositionLinearTransferEffect **linearTransferEffect );
		IDCompositionLinearTransferEffect CreateLinearTransferEffect();

		/// <summary>Creates an instance of <c>IDCompositionTableTransferEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTableTransferEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionTableTransferEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createtabletransfereffect
		// HRESULT CreateTableTransferEffect( [out] IDCompositionTableTransferEffect **tableTransferEffect );
		IDCompositionTableTransferEffect CreateTableTransferEffect();

		/// <summary>Creates an instance of <c>IDCompositionCompositeEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionCompositeEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionCompositeEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createcompositeeffect
		// HRESULT CreateCompositeEffect( [out] IDCompositionCompositeEffect **compositeEffect );
		IDCompositionCompositeEffect CreateCompositeEffect();

		/// <summary>Creates an instance of <c>IDCompositionBlendEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionBlendEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionBlendEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createblendeffect
		// HRESULT CreateBlendEffect( [out] IDCompositionBlendEffect **blendEffect );
		IDCompositionBlendEffect CreateBlendEffect();

		/// <summary>Creates an instance of <c>IDCompositionArithmeticCompositeEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionArithmeticCompositeEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionArithmeticCompositeEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createarithmeticcompositeeffect
		// HRESULT CreateArithmeticCompositeEffect( [out] IDCompositionArithmeticCompositeEffect **arithmeticCompositeEffect );
		IDCompositionArithmeticCompositeEffect CreateArithmeticCompositeEffect();

		/// <summary>Creates an instance of <c>IDCompositionAffineTransform2DEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionAffineTransform2DEffect</c>**</b></para>
		///   <para>Recieves the created instance of <c>IDCompositionAffineTransform2DEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createaffinetransform2deffect
		// HRESULT CreateAffineTransform2DEffect( [out] IDCompositionAffineTransform2DEffect **affineTransform2dEffect );
		IDCompositionAffineTransform2DEffect CreateAffineTransform2DEffect();
	}

	/// <summary>
	/// <para>Represents a filter effect.</para>
	/// <para>IDCompositionFilterEffect exposes a subset of Direct2D's image <c>effects</c> through DirectComposition for use in CSS filters in the browser platform.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionfiltereffect
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionFilterEffect")]
	[ComImport, Guid("30C421D5-8CB2-4E9F-B133-37BE270D4AC2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionFilterEffect : IDCompositionEffect
	{
		/// <summary>Sets the input at an index to the specified filter effect.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Specifies the index the to apply the filter effect at.</para>
		/// </param>
		/// <param name="input">
		///   <para>Type: <b>IUnknown*</b></para>
		///   <para>The filter effect to apply. The following effects are available:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <c>IDCompositionAffineTransform2DEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionArithmeticCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBlendEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBrightnessEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionColorMatrixEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionFloodEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionGaussianBlurEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionHueRotationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionLinearTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionSaturationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionShadowEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTableTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTurbulenceEffect</c>
		///       </description>
		///     </item>
		///   </list>
		/// </param>
		/// <param name="flags">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Flags to apply to the filter effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionfiltereffect-setinput
		// HRESULT SetInput( [in] UINT index, [in, optional] IUnknown *input, [in] UINT flags );
		void SetInput(uint index, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? input, uint flags = 0);
	}

	/// <summary>The Gaussian blur effect is used to blur an image by a Gaussian function, typically to reduce image noise and reduce detail.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositiongaussianblureffect
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionGaussianBlurEffect")]
	[ComImport, Guid("45D4D0B7-1BD4-454E-8894-2BFA68443033"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionGaussianBlurEffect : IDCompositionFilterEffect
	{
		/// <summary>Sets the input at an index to the specified filter effect.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Specifies the index the to apply the filter effect at.</para>
		/// </param>
		/// <param name="input">
		///   <para>Type: <b>IUnknown*</b></para>
		///   <para>The filter effect to apply. The following effects are available:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <c>IDCompositionAffineTransform2DEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionArithmeticCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBlendEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBrightnessEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionColorMatrixEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionFloodEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionGaussianBlurEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionHueRotationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionLinearTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionSaturationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionShadowEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTableTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTurbulenceEffect</c>
		///       </description>
		///     </item>
		///   </list>
		/// </param>
		/// <param name="flags">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Flags to apply to the filter effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionfiltereffect-setinput
		// HRESULT SetInput( [in] UINT index, [in, optional] IUnknown *input, [in] UINT flags );
		new void SetInput(uint index, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? input, uint flags = 0);

		/// <summary>Sets the amount of blur to be applied to the image.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the amount of blur changes over time. You can compute the blur radius of the kernel by multiplying the standard deviation by 3. The units of both the standard deviation and blur radius are DIPs. A value of zero DIPs disables this effect entirely. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiongaussianblureffect-setstandarddeviation(idcompositionanimation)
		// HRESULT SetStandardDeviation( [in] IDCompositionAnimation *animation );
		void SetStandardDeviation([In] IDCompositionAnimation animation);

		/// <summary>Sets the amount of blur to be applied to the image.</summary>
		/// <param name="amount">
		///   <para>Type: <b>float</b></para>
		///   <para>The amount of blur to be applied to the image. You can compute the blur radius of the kernel by multiplying the standard deviation by 3. The units of both the standard deviation and blur radius are DIPs. A value of zero DIPs disables this effect entirely.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiongaussianblureffect-setstandarddeviation(float)
		// HRESULT SetStandardDeviation( [in] float amount );
		void SetStandardDeviation([In] float amount);

		/// <summary>Sets the mode used to calculate the border of the image.</summary>
		/// <param name="mode">
		/// <para>Type: <b><c>D2D1_BORDER_MODE</c></b></para>
		/// <para>The mode used to calculate the border of the image.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiongaussianblureffect-setbordermode
		// HRESULT SetBorderMode( [in] D2D1_BORDER_MODE mode );
		void SetBorderMode([In] D2D1_BORDER_MODE mode);
	}

	/// <summary>The brightness effect controls the brightness of the image.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionbrightnesseffect
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionBrightnessEffect")]
	[ComImport, Guid("6027496E-CB3A-49AB-934F-D798DA4F7DA6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionBrightnessEffect : IDCompositionFilterEffect
	{
		/// <summary>Sets the input at an index to the specified filter effect.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Specifies the index the to apply the filter effect at.</para>
		/// </param>
		/// <param name="input">
		///   <para>Type: <b>IUnknown*</b></para>
		///   <para>The filter effect to apply. The following effects are available:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <c>IDCompositionAffineTransform2DEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionArithmeticCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBlendEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBrightnessEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionColorMatrixEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionFloodEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionGaussianBlurEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionHueRotationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionLinearTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionSaturationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionShadowEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTableTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTurbulenceEffect</c>
		///       </description>
		///     </item>
		///   </list>
		/// </param>
		/// <param name="flags">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Flags to apply to the filter effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionfiltereffect-setinput
		// HRESULT SetInput( [in] UINT index, [in, optional] IUnknown *input, [in] UINT flags );
		new void SetInput(uint index, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? input, uint flags = 0);

		/// <summary>Sets the upper portion of the brightness transfer curve.</summary>
		/// <param name="whitePoint">
		///   <para>Type: <b>const <c>D2D1_VECTOR_2F</c></b></para>
		///   <para>The upper portion of the brightness transfer curve. The white point adjusts the appearance of the brighter portions of the image. This vector is for both the x value and the y value, in that order. Each of the values must be between 0 and 1, inclusive.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionbrightnesseffect-setwhitepoint
		// HRESULT SetWhitePoint( [in, ref] const D2D1_VECTOR_2F &amp; whitePoint );
		void SetWhitePoint(in D2D_VECTOR_2F whitePoint);

		/// <summary>Specifies the lower portion of the brightness transfer curve for the brightness effect.</summary>
		/// <param name="blackPoint">
		///   <para>Type: <b>const <c>D2D1_VECTOR_2F</c></b></para>
		///   <para>The lower portion of the brightness transfer curve. The black point adjusts the appearance of the darker portions of the image. The vector is for both the x value and the y value, in that order. Each of the values must be between 0 and 1, inclusive.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionbrightnesseffect-setblackpoint
		// HRESULT SetBlackPoint( [in, ref] const D2D1_VECTOR_2F &amp; blackPoint );
		void SetBlackPoint(in D2D_VECTOR_2F blackPoint);

		/// <summary>Sets the x value of the white point.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the x value of the white point changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionbrightnesseffect-setwhitepointx(idcompositionanimation)
		// HRESULT SetWhitePointX( [in] IDCompositionAnimation *animation );
		void SetWhitePointX([In] IDCompositionAnimation animation);

		/// <summary>Sets the x value of the white point.</summary>
		/// <param name="whitePointX">
		///   <para>Type: <b>float</b></para>
		///   <para>The x value of the white point. This value must be between 0 and 1.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionbrightnesseffect-setwhitepointx(float)
		// HRESULT SetWhitePointX( [in] float whitePointX );
		void SetWhitePointX([In] float whitePointX);

		/// <summary>Sets the y value of the white point.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the y value of the white point changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionbrightnesseffect-setwhitepointy(idcompositionanimation)
		// HRESULT SetWhitePointY( [in] IDCompositionAnimation *animation );
		void SetWhitePointY([In] IDCompositionAnimation animation);

		/// <summary>Sets the y value of the white point.</summary>
		/// <param name="whitePointY">
		///   <para>Type: <b>float</b></para>
		///   <para>The y value of the white point.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionbrightnesseffect-setwhitepointy(float)
		// HRESULT SetWhitePointY( [in] float whitePointY );
		void SetWhitePointY([In] float whitePointY);

		/// <summary>Sets the x value of the black point.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the x value of the black point changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionbrightnesseffect-setblackpointx(idcompositionanimation)
		// HRESULT SetBlackPointX( [in] IDCompositionAnimation *animation );
		void SetBlackPointX([In] IDCompositionAnimation animation);

		/// <summary>Sets the x value of the black point.</summary>
		/// <param name="blackPointX">
		///   <para>Type: <b>float</b></para>
		///   <para>The x value of the black point.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionbrightnesseffect-setblackpointx(float)
		// HRESULT SetBlackPointX( [in] float blackPointX );
		void SetBlackPointX([In] float blackPointX);

		/// <summary>Sets the y value of the black point.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the y value of the black point changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionbrightnesseffect-setblackpointy(idcompositionanimation)
		// HRESULT SetBlackPointY( [in] IDCompositionAnimation *animation );
		void SetBlackPointY([In] IDCompositionAnimation animation);

		/// <summary>Sets the y value of the black point.</summary>
		/// <param name="blackPointY">
		///   <para>Type: <b>float</b></para>
		///   <para>The y value of the black point.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionbrightnesseffect-setblackpointy(float)
		// HRESULT SetBlackPointY( [in] float blackPointY );
		void SetBlackPointY([In] float blackPointY);
	}

	/// <summary>The color matrix effect alters the RGBA values of a bitmap.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositioncolormatrixeffect
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionColorMatrixEffect")]
	[ComImport, Guid("C1170A22-3CE2-4966-90D4-55408BFC84C4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionColorMatrixEffect : IDCompositionFilterEffect
	{
		/// <summary>Sets the input at an index to the specified filter effect.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Specifies the index the to apply the filter effect at.</para>
		/// </param>
		/// <param name="input">
		///   <para>Type: <b>IUnknown*</b></para>
		///   <para>The filter effect to apply. The following effects are available:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <c>IDCompositionAffineTransform2DEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionArithmeticCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBlendEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBrightnessEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionColorMatrixEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionFloodEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionGaussianBlurEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionHueRotationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionLinearTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionSaturationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionShadowEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTableTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTurbulenceEffect</c>
		///       </description>
		///     </item>
		///   </list>
		/// </param>
		/// <param name="flags">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Flags to apply to the filter effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionfiltereffect-setinput
		// HRESULT SetInput( [in] UINT index, [in, optional] IUnknown *input, [in] UINT flags );
		new void SetInput(uint index, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? input, uint flags = 0);

		/// <summary>Sets the matrix used by the effect to multiply the RGBA values of the image.</summary>
		/// <param name="matrix">
		///   <para>Type: <b>const <c>D2D1_MATRIX_5X4_F</c></b></para>
		///   <para>The matrix used by the effect to multiply the RGBA values of the image. The matrix is column major and is applied as shown in the following equation:</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositioncolormatrixeffect-setmatrix
		// HRESULT SetMatrix( [in, ref] const D2D1_MATRIX_5X4_F &amp; matrix );
		void SetMatrix(in D2D_MATRIX_5X4_F matrix);

		/// <summary>Sets an element of the color matrix.</summary>
		/// <param name="row">
		///   <para>Type: <b>int</b></para>
		///   <para>The row of the element.</para>
		/// </param>
		/// <param name="column">
		///   <para>Type: <b>int</b></para>
		///   <para>The column of the element.</para>
		/// </param>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the element value changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositioncolormatrixeffect-setmatrixelement(int_int_idcompositionanimation)
		// HRESULT SetMatrixElement( [in] int row, [in] int column, [in] IDCompositionAnimation *animation );
		void SetMatrixElement(int row, int column, [In] IDCompositionAnimation animation);

		/// <summary>Sets an element of the color matrix.</summary>
		/// <param name="row">
		///   <para>Type: <b>int</b></para>
		///   <para>The row of the element.</para>
		/// </param>
		/// <param name="column">
		///   <para>Type: <b>int</b></para>
		///   <para>The column of the element.</para>
		/// </param>
		/// <param name="value">
		///   <para>Type: <b>float</b></para>
		///   <para>The new value of the element.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositioncolormatrixeffect-setmatrixelement(int_int_float)
		// HRESULT SetMatrixElement( [in] int row, [in] int column, [in] float value );
		void SetMatrixElement(int row, int column, [In] float value);

		/// <summary>Sets the alpha mode of the output for the color matrix effect.</summary>
		/// <param name="mode">
		///   <para>Type: <b><c>D2D1_COLORMATRIX_ALPHA_MODE</c></b></para>
		///   <para>The alpha mode of the output for the color matrix effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositioncolormatrixeffect-setalphamode
		// HRESULT SetAlphaMode( [in] D2D1_COLORMATRIX_ALPHA_MODE mode );
		void SetAlphaMode([In] D2D1_COLORMATRIX_ALPHA_MODE mode);

		/// <summary>Specifies whether the effect clamps color values to between 0 and 1 before the effects passes the values to the next effect in the chain.</summary>
		/// <param name="clamp">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>A boolean value indicating whether the effect clamps color values to between 0 and 1 before the effects passes the values to the next effect in the chain.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositioncolormatrixeffect-setclampoutput
		// HRESULT SetClampOutput( [in] BOOL clamp );
		void SetClampOutput([MarshalAs(UnmanagedType.Bool)] bool clamp);
	}

	/// <summary>The shadow effect is used to generate a shadow from the alpha channel of an image. The shadow is more opaque for higher alpha values and more transparent for lower alpha values. You can set the amount of blur and the color of the shadow.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionshadoweffect
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionShadowEffect")]
	[ComImport, Guid("4AD18AC0-CFD2-4C2F-BB62-96E54FDB6879"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionShadowEffect : IDCompositionFilterEffect
	{
		/// <summary>Sets the input at an index to the specified filter effect.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Specifies the index the to apply the filter effect at.</para>
		/// </param>
		/// <param name="input">
		///   <para>Type: <b>IUnknown*</b></para>
		///   <para>The filter effect to apply. The following effects are available:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <c>IDCompositionAffineTransform2DEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionArithmeticCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBlendEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBrightnessEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionColorMatrixEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionFloodEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionGaussianBlurEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionHueRotationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionLinearTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionSaturationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionShadowEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTableTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTurbulenceEffect</c>
		///       </description>
		///     </item>
		///   </list>
		/// </param>
		/// <param name="flags">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Flags to apply to the filter effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionfiltereffect-setinput
		// HRESULT SetInput( [in] UINT index, [in, optional] IUnknown *input, [in] UINT flags );
		new void SetInput(uint index, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? input, uint flags = 0);

		/// <summary>Sets the amount of blur to be applied to the alpha channel of the image.</summary>
		/// <param name="amount">
		///   <para>Type: <b>float</b></para>
		///   <para>The amount of blur to be applied to the alpha channel of the image. You can compute the blur radius of the kernel by multiplying the standard deviation by 3. The units of both the standard deviation and blur radius are DIPs.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionshadoweffect-setstandarddeviation(float)
		// HRESULT SetStandardDeviation( [in] float amount );
		void SetStandardDeviation([In] float amount);

		/// <summary>Sets the amount of blur to be applied to the alpha channel of the image.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the amount of blur to be applied to the alpha channel of the image changes over time. You can compute the blur radius of the kernel by multiplying the standard deviation by 3. The units of both the standard deviation and blur radius are DIPs. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionshadoweffect-setstandarddeviation(idcompositionanimation)
		// HRESULT SetStandardDeviation( [in] IDCompositionAnimation *animation );
		void SetStandardDeviation([In] IDCompositionAnimation animation);

		/// <summary>Sets color of the shadow.</summary>
		/// <param name="color">
		///   <para>Type: <b>const <c>D2D1_VECTOR_4F</c></b></para>
		///   <para>The color of the shadow.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionshadoweffect-setcolor
		// HRESULT SetColor( [in, ref] const D2D1_VECTOR_4F &amp; color );
		void SetColor(in D2D_VECTOR_4F color);

		/// <summary>Sets the red value for the color of the shadow.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the red value for the color of the shadow changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionshadoweffect-setred(idcompositionanimation)
		// HRESULT SetRed( [in] IDCompositionAnimation *animation );
		void SetRed([In] IDCompositionAnimation animation);

		/// <summary>Sets the red value for the color of the shadow.</summary>
		/// <param name="amount">
		///   <para>Type: <b>float</b></para>
		///   <para>The red value for the color of the shadow.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionshadoweffect-setred(float)
		// HRESULT SetRed( [in] float amount );
		void SetRed([In] float amount);

		/// <summary>Sets the green value for the color of the shadow.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the green value for the color of the shadow changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionshadoweffect-setgreen(idcompositionanimation)
		// HRESULT SetGreen( [in] IDCompositionAnimation *animation );
		void SetGreen([In] IDCompositionAnimation animation);

		/// <summary>Sets the green value for the color of the shadow.</summary>
		/// <param name="amount">
		///   <para>Type: <b>float</b></para>
		///   <para>The green value for the color of the shadow.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionshadoweffect-setgreen(float)
		// HRESULT SetGreen( [in] float amount );
		void SetGreen([In] float amount);

		/// <summary>Sets the blue value for the color of the shadow.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the blue value for the color of the shadow changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionshadoweffect-setblue(idcompositionanimation)
		// HRESULT SetBlue( [in] IDCompositionAnimation *animation );
		void SetBlue([In] IDCompositionAnimation animation);

		/// <summary>Sets the blue value for the color of the shadow.</summary>
		/// <param name="amount">
		///   <para>Type: <b>float</b></para>
		///   <para>The blue value for the color of the shadow.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionshadoweffect-setblue(float)
		// HRESULT SetBlue( [in] float amount );
		void SetBlue([In] float amount);

		/// <summary>Sets the alpha value for the effect.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the alpha value for the effect changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionshadoweffect-setalpha(idcompositionanimation)
		// HRESULT SetAlpha( [in] IDCompositionAnimation *animation );
		void SetAlpha([In] IDCompositionAnimation animation);

		/// <summary>Sets the alpha value for the effect.</summary>
		/// <param name="amount">
		///   <para>Type: <b>float</b></para>
		///   <para>The alpha value for the effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionshadoweffect-setalpha(float)
		// HRESULT SetAlpha( [in] float amount );
		void SetAlpha([In] float amount);
	}

	/// <summary>The hue rotate effect alters the hue of an image by applying a color matrix based on the rotation angle.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionhuerotationeffect
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionHueRotationEffect")]
	[ComImport, Guid("6DB9F920-0770-4781-B0C6-381912F9D167"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionHueRotationEffect : IDCompositionFilterEffect
	{
		/// <summary>Sets the input at an index to the specified filter effect.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Specifies the index the to apply the filter effect at.</para>
		/// </param>
		/// <param name="input">
		///   <para>Type: <b>IUnknown*</b></para>
		///   <para>The filter effect to apply. The following effects are available:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <c>IDCompositionAffineTransform2DEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionArithmeticCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBlendEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBrightnessEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionColorMatrixEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionFloodEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionGaussianBlurEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionHueRotationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionLinearTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionSaturationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionShadowEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTableTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTurbulenceEffect</c>
		///       </description>
		///     </item>
		///   </list>
		/// </param>
		/// <param name="flags">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Flags to apply to the filter effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionfiltereffect-setinput
		// HRESULT SetInput( [in] UINT index, [in, optional] IUnknown *input, [in] UINT flags );
		new void SetInput(uint index, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? input, uint flags = 0);

		/// <summary>Sets the angle to rotate the hue.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the angle value changes over time. The effect calculates a color matrix based on the rotation angle (?) according to the following matrix equations:</para>
		///   <para>This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionhuerotationeffect-setangle(idcompositionanimation)
		// HRESULT SetAngle( [in] IDCompositionAnimation *animation );
		void SetAngle([In] IDCompositionAnimation animation);

		/// <summary>Sets the angle to rotate the hue.</summary>
		/// <param name="amountDegrees">
		///   <para>Type: <b>float</b></para>
		///   <para>The angle to rotate the hue. The effect calculates a color matrix based on the rotation angle (?) according to the following matrix equations:</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionhuerotationeffect-setangle(float)
		// HRESULT SetAngle( [in] float amountDegrees );
		void SetAngle([In] float amountDegrees);
	}

	/// <summary>This effect is used to alter the saturation of an image. The saturation effect is a specialization of the color matrix effect.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionsaturationeffect
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionSaturationEffect")]
	[ComImport, Guid("A08DEBDA-3258-4FA4-9F16-9174D3FE93B1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionSaturationEffect : IDCompositionFilterEffect
	{
		/// <summary>Sets the input at an index to the specified filter effect.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Specifies the index the to apply the filter effect at.</para>
		/// </param>
		/// <param name="input">
		///   <para>Type: <b>IUnknown*</b></para>
		///   <para>The filter effect to apply. The following effects are available:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <c>IDCompositionAffineTransform2DEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionArithmeticCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBlendEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBrightnessEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionColorMatrixEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionFloodEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionGaussianBlurEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionHueRotationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionLinearTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionSaturationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionShadowEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTableTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTurbulenceEffect</c>
		///       </description>
		///     </item>
		///   </list>
		/// </param>
		/// <param name="flags">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Flags to apply to the filter effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionfiltereffect-setinput
		// HRESULT SetInput( [in] UINT index, [in, optional] IUnknown *input, [in] UINT flags );
		new void SetInput(uint index, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? input, uint flags = 0);

		/// <summary>Sets the saturation of the image.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the saturation of the image changes over time. This parameter must not be NULL. You can set the saturation to a value between 0 and 1. If you set it to 1 the output image is fully saturated. If you set it to 0 the output image is monochrome. The saturation value is unitless. The effect calculates a color matrix based on the saturation value (s in the equation here) using the following equation:</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionsaturationeffect-setsaturation(idcompositionanimation)
		// HRESULT SetSaturation( [in] IDCompositionAnimation *animation );
		void SetSaturation([In] IDCompositionAnimation animation);

		/// <summary>Sets the saturation of the image.</summary>
		/// <param name="ratio">
		///   <para>Type: <b>float</b></para>
		///   <para>The saturation of the image. You can set the saturation to a value between 0 and 1. If you set it to 1 the output image is fully saturated. If you set it to 0 the output image is monochrome. The saturation value is unitless. The effect calculates a color matrix based on the saturation value (s in the equation here) using the following equation:</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionsaturationeffect-setsaturation(float)
		// HRESULT SetSaturation( [in] float ratio );
		void SetSaturation([In] float ratio);
	}

	/// <summary>The turbulence effect is used to generate a bitmap based on the Perlin noise function. The turbulence effect has no input image.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionturbulenceeffect
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionTurbulenceEffect")]
	[ComImport, Guid("A6A55BDA-C09C-49F3-9193-A41922C89715"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionTurbulenceEffect : IDCompositionFilterEffect
	{
		/// <summary>Sets the input at an index to the specified filter effect.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Specifies the index the to apply the filter effect at.</para>
		/// </param>
		/// <param name="input">
		///   <para>Type: <b>IUnknown*</b></para>
		///   <para>The filter effect to apply. The following effects are available:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <c>IDCompositionAffineTransform2DEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionArithmeticCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBlendEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBrightnessEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionColorMatrixEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionFloodEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionGaussianBlurEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionHueRotationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionLinearTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionSaturationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionShadowEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTableTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTurbulenceEffect</c>
		///       </description>
		///     </item>
		///   </list>
		/// </param>
		/// <param name="flags">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Flags to apply to the filter effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionfiltereffect-setinput
		// HRESULT SetInput( [in] UINT index, [in, optional] IUnknown *input, [in] UINT flags );
		new void SetInput(uint index, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? input, uint flags = 0);

		/// <summary>Sets the coordinates where the turbulence output is generated.</summary>
		/// <param name="offset">
		///   <para>Type: <b>const <c>D2D1_VECTOR_2F</c></b></para>
		///   <para>The coordinates where the turbulence output is generated. The algorithm used to generate the Perlin noise is position dependent, so a different offset results in a different output. This value is not bounded and the units are specified in DIPs</para>
		///   <para>
		///     <b>Note</b>  Note The offset does not have the same effect as a translation because the noise function output is infinite and the function will wrap around the tile.</para>
		///   <para> </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionturbulenceeffect-setoffset
		// HRESULT SetOffset( [in, ref] const D2D1_VECTOR_2F &amp; offset );
		void SetOffset(in D2D_VECTOR_2F offset);

		/// <summary>Sets the base frequencies in the X and Y direction.</summary>
		/// <param name="frequency">
		///   <para>Type: <b>const <c>D2D1_VECTOR_2F</c></b></para>
		///   <para>The base frequencies in the X and Y direction. This must be greater than 0. The units are specified in 1/DIPs. A value of 1 (1/DIPs) for the base frequency results in the Perlin noise completing an entire cycle between two pixels. The ease interpolation for these pixels results in completely random pixels, since there is no correlation between the pixels. A value of 0.1(1/DIPs) for the base frequency results in the Perlin noise function repeating every 10 DIPs. This results in correlation between pixels and the typical turbulence effect is visible.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionturbulenceeffect-setbasefrequency
		// HRESULT SetBaseFrequency( [in, ref] const D2D1_VECTOR_2F &amp; frequency );
		[PInvokeData("dcomp.h", MSDNShortId = "NF:dcomp.IDCompositionTurbulenceEffect.SetBaseFrequency")]
		void SetBaseFrequency(in D2D_VECTOR_2F frequency);

		/// <summary>Sets the size of the turbulence output.</summary>
		/// <param name="size">
		///   <para>Type: <b>const <c>D2D1_VECTOR_2F</c></b></para>
		///   <para>The size of the turbulence output</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionturbulenceeffect-setsize
		// HRESULT SetSize( [in, ref] const D2D1_VECTOR_2F &amp; size );
		void SetSize(in D2D_VECTOR_2F size);

		/// <summary>Sets the number of octaves for the noise function.</summary>
		/// <param name="numOctaves">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The number of octaves for the noise function. This value must be greater than 0.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionturbulenceeffect-setnumoctaves
		// HRESULT SetNumOctaves( [in] UINT numOctaves );
		void SetNumOctaves(uint numOctaves);

		/// <summary>Sets the seed for the pseudo random generator.</summary>
		/// <param name="seed">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The seed for the pseudo random generator. This value is unbounded.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionturbulenceeffect-setseed
		// HRESULT SetSeed( [in] UINT seed );
		void SetSeed(uint seed);

		/// <summary>Sets the turbulence noise mode.</summary>
		/// <param name="noise">
		///   <para>Type: <b><c>D2D1_TURBULENCE_NOISE</c></b></para>
		///   <para>The turbulence noise mode. Indicates whether to generate a bitmap based on Fractal Noise or the Turbulence function.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionturbulenceeffect-setnoise
		// HRESULT SetNoise( [in] D2D1_TURBULENCE_NOISE noise );
		void SetNoise([In] D2D1_TURBULENCE_NOISE noise);

		/// <summary>Specifies whether stitching is on or off.</summary>
		/// <param name="stitchable">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>A boolean value that specifies whether stitching is on or off. The base frequency is adjusted so that the output bitmap can be stitched. This is useful if you want to tile multiple copies of the turbulence effect output. If this value is TRUE, the output bitmap can be tiled (using the tile effect) without the appearance of seams and the base frequency is adjusted so that output bitmap can be stitched. If this value is FALSE, the base frequency is not adjusted, so seams may appear between tiles if the bitmap is tiled.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionturbulenceeffect-setstitchable
		// HRESULT SetStitchable( [in] BOOL stitchable );
		void SetStitchable([MarshalAs(UnmanagedType.Bool)] bool stitchable);
	}

	/// <summary>The linear transfer effect is used to map the color intensities of an image using a linear function created from a list of values you provide for each channel.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionlineartransfereffect
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionLinearTransferEffect")]
	[ComImport, Guid("4305EE5B-C4A0-4C88-9385-67124E017683"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionLinearTransferEffect : IDCompositionFilterEffect
	{
		/// <summary>Sets the input at an index to the specified filter effect.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Specifies the index the to apply the filter effect at.</para>
		/// </param>
		/// <param name="input">
		///   <para>Type: <b>IUnknown*</b></para>
		///   <para>The filter effect to apply. The following effects are available:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <c>IDCompositionAffineTransform2DEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionArithmeticCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBlendEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBrightnessEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionColorMatrixEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionFloodEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionGaussianBlurEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionHueRotationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionLinearTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionSaturationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionShadowEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTableTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTurbulenceEffect</c>
		///       </description>
		///     </item>
		///   </list>
		/// </param>
		/// <param name="flags">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Flags to apply to the filter effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionfiltereffect-setinput
		// HRESULT SetInput( [in] UINT index, [in, optional] IUnknown *input, [in] UINT flags );
		new void SetInput(uint index, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? input, uint flags = 0);

		/// <summary>Sets the Y-intercept of the linear function for the red channel.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the Y-intercept of the linear function for the red channel changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setredyintercept(idcompositionanimation)
		// HRESULT SetRedYIntercept( [in] IDCompositionAnimation *animation );
		void SetRedYIntercept([In] IDCompositionAnimation animation);

		/// <summary>Sets the Y-intercept of the linear function for the red channel.</summary>
		/// <param name="redYIntercept">
		///   <para>Type: <b>float</b></para>
		///   <para>The Y-intercept of the linear function for the red channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setredyintercept(float)
		// HRESULT SetRedYIntercept( [in] float redYIntercept );
		void SetRedYIntercept([In] float redYIntercept);

		/// <summary>Sets the slope of the linear function for the red channel.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the slope of the linear function for the red channel changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setredslope(idcompositionanimation)
		// HRESULT SetRedSlope( [in] IDCompositionAnimation *animation );
		void SetRedSlope([In] IDCompositionAnimation animation);

		/// <summary>Sets the slope of the linear function for the red channel.</summary>
		/// <param name="redSlope">
		///   <para>Type: <b>float</b></para>
		///   <para>The slope of the linear function for the red channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setredslope(float)
		// HRESULT SetRedSlope( [in] float redSlope );
		void SetRedSlope([In] float redSlope);

		/// <summary>Specifies whether to apply the transfer function to the red channel.</summary>
		/// <param name="redDisable">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>A boolean value that specifies whether to apply the transfer function to the red channel. If you set this to TRUE the effect does not apply the transfer function to the red channel. If you set this to FALSE the effect applies the RedLinearTransfer function to the red channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setreddisable
		// HRESULT SetRedDisable( [in] BOOL redDisable );
		void SetRedDisable([MarshalAs(UnmanagedType.Bool)] bool redDisable);

		/// <summary>Sets the Y-intercept of the linear function for the green channel.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the Y-intercept of the linear function for the green channel changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setgreenyintercept(idcompositionanimation)
		// HRESULT SetGreenYIntercept( [in] IDCompositionAnimation *animation );
		void SetGreenYIntercept([In] IDCompositionAnimation animation);

		/// <summary>Sets the Y-intercept of the linear function for the green channel.</summary>
		/// <param name="greenYIntercept">
		///   <para>Type: <b>float</b></para>
		///   <para>The Y-intercept of the linear function for the green channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setgreenyintercept(float)
		// HRESULT SetGreenYIntercept( [in] float greenYIntercept );
		void SetGreenYIntercept([In] float greenYIntercept);

		/// <summary>Sets the slope of the linear function for the green channel.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the slope of the linear function for the green channel changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setgreenslope(idcompositionanimation)
		// HRESULT SetGreenSlope( [in] IDCompositionAnimation *animation );
		void SetGreenSlope([In] IDCompositionAnimation animation);

		/// <summary>Sets the slope of the linear function for the green channel.</summary>
		/// <param name="greenSlope">
		///   <para>Type: <b>float</b></para>
		///   <para>The slope of the linear function for the green channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setgreenslope(float)
		// HRESULT SetGreenSlope( [in] float greenSlope );
		void SetGreenSlope([In] float greenSlope);

		/// <summary>Specifies whether to apply the transfer function to the green channel.</summary>
		/// <param name="greenDisable">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>A boolean value that specifies whether to apply the transfer function to the green channel. If you set this to TRUE the effect does not apply the transfer function to the green channel. If you set this to FALSE it applies the GreenLinearTransfer function to the green channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setgreendisable
		// HRESULT SetGreenDisable( [in] BOOL greenDisable );
		void SetGreenDisable([MarshalAs(UnmanagedType.Bool)] bool greenDisable);

		/// <summary>Sets the Y-intercept of the linear function for the blue channel.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the Y-intercept of the linear function for the blue channel changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setblueyintercept(idcompositionanimation)
		// HRESULT SetBlueYIntercept( [in] IDCompositionAnimation *animation );
		void SetBlueYIntercept([In] IDCompositionAnimation animation);

		/// <summary>Sets the Y-intercept of the linear function for the blue channel.</summary>
		/// <param name="blueYIntercept">
		///   <para>Type: <b>float</b></para>
		///   <para>The Y-intercept of the linear function for the blue channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setblueyintercept(float)
		// HRESULT SetBlueYIntercept( [in] float blueYIntercept );
		void SetBlueYIntercept([In] float blueYIntercept);

		/// <summary>Sets the slope of the linear function for the blue channel.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the slope of the linear function for the blue channel changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setblueslope(idcompositionanimation)
		// HRESULT SetBlueSlope( [in] IDCompositionAnimation *animation );
		void SetBlueSlope([In] IDCompositionAnimation animation);

		/// <summary>Sets the slope of the linear function for the blue channel.</summary>
		/// <param name="blueSlope">
		///   <para>Type: <b>float</b></para>
		///   <para>The slope of the linear function for the Blue channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setblueslope(float)
		// HRESULT SetBlueSlope( [in] float blueSlope );
		void SetBlueSlope([In] float blueSlope);

		/// <summary>Specifies whether to apply the transfer function to the blue channel.</summary>
		/// <param name="blueDisable">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>A boolean value that specifies whether to apply the transfer function to the blue channel. If you set this to TRUE the effect does not apply the transfer function to the blue channel. If you set this to FALSE it applies the BlueLinearTransfer function to the blue channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setbluedisable
		// HRESULT SetBlueDisable( [in] BOOL blueDisable );
		void SetBlueDisable([MarshalAs(UnmanagedType.Bool)] bool blueDisable);

		/// <summary>Sets the Y-intercept of the linear function for the Alpha channel.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the Y-intercept of the linear function for the alpha channel. changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setalphayintercept(idcompositionanimation)
		// HRESULT SetAlphaYIntercept( [in] IDCompositionAnimation *animation );
		void SetAlphaYIntercept([In] IDCompositionAnimation animation);

		/// <summary>Sets the Y-intercept of the linear function for the alpha channel.</summary>
		/// <param name="alphaYIntercept">
		///   <para>Type: <b>float</b></para>
		///   <para>The Y-intercept of the linear function for the alpha channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setalphayintercept(float)
		// HRESULT SetAlphaYIntercept( [in] float alphaYIntercept );
		void SetAlphaYIntercept([In] float alphaYIntercept);

		/// <summary>Sets the slope of the linear function for the alpha channel.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the slope of the linear function for the alpha channel changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setalphaslope(idcompositionanimation)
		// HRESULT SetAlphaSlope( [in] IDCompositionAnimation *animation );
		void SetAlphaSlope([In] IDCompositionAnimation animation);

		/// <summary>Sets the slope of the linear function for the alpha channel.</summary>
		/// <param name="alphaSlope">
		///   <para>Type: <b>float</b></para>
		///   <para>The slope of the linear function for the alpha channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setalphaslope(float)
		// HRESULT SetAlphaSlope( [in] float alphaSlope );
		void SetAlphaSlope([In] float alphaSlope);

		/// <summary>Specifies whether to apply the transfer function to the alpha channel.</summary>
		/// <param name="alphaDisable">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>A boolean value that specifies whether to apply the transfer function to the alpha channel. If you set this to TRUE the effect does not apply the transfer function to the Alpha channel. If you set this to FALSE it applies the AlphaLinearTransfer function to the Alpha channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setalphadisable
		// HRESULT SetAlphaDisable( [in] BOOL alphaDisable );
		void SetAlphaDisable([MarshalAs(UnmanagedType.Bool)] bool alphaDisable);

		/// <summary>Specifies whether the effect clamps color values to between 0 and 1 before the effect passes the values to the next effect in the graph.</summary>
		/// <param name="clampOutput">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>A boolean value that specifies whether the effect clamps color values to between 0 and 1 before the effect passes the values to the next effect in the graph. If you set this to TRUE the effect will clamp the values. If you set this to FALSE, the effect will not clamp the color values, but other effects and the output surface may clamp the values if they are not of high enough precision.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionlineartransfereffect-setclampoutput
		// HRESULT SetClampOutput( [in] BOOL clampOutput );
		void SetClampOutput([MarshalAs(UnmanagedType.Bool)] bool clampOutput);
	}

	/// <summary>The table transfer effect is used to map the color intensities of an image using a transfer function created from interpolating a list of values you provide.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositiontabletransfereffect
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionTableTransferEffect")]
	[ComImport, Guid("9B7E82E2-69C5-4EB4-A5F5-A7033F5132CD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionTableTransferEffect : IDCompositionFilterEffect
	{
		/// <summary>Sets the input at an index to the specified filter effect.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Specifies the index the to apply the filter effect at.</para>
		/// </param>
		/// <param name="input">
		///   <para>Type: <b>IUnknown*</b></para>
		///   <para>The filter effect to apply. The following effects are available:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <c>IDCompositionAffineTransform2DEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionArithmeticCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBlendEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBrightnessEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionColorMatrixEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionFloodEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionGaussianBlurEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionHueRotationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionLinearTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionSaturationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionShadowEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTableTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTurbulenceEffect</c>
		///       </description>
		///     </item>
		///   </list>
		/// </param>
		/// <param name="flags">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Flags to apply to the filter effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionfiltereffect-setinput
		// HRESULT SetInput( [in] UINT index, [in, optional] IUnknown *input, [in] UINT flags );
		new void SetInput(uint index, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? input, uint flags = 0);

		/// <summary>Sets the list of values used to define the transfer function for the red channel.</summary>
		/// <param name="tableValues">
		///   <para>Type: <b>const float*</b></para>
		///   <para>The list of values used to define the transfer function for the red channel.</para>
		/// </param>
		/// <param name="count">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The number of values in the tableValues parameter.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setredtable
		// HRESULT SetRedTable( [in] const float *tableValues, [in] UINT count );
		void SetRedTable([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] tableValues, uint count);

		/// <summary>Sets the list of values used to define the transfer function for the green channel.</summary>
		/// <param name="tableValues">
		///   <para>Type: <b>const float*</b></para>
		///   <para>The list of values used to define the transfer function for the green channel.</para>
		/// </param>
		/// <param name="count">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The number of values in the tableValues parameter.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setgreentable
		// HRESULT SetGreenTable( [in] const float *tableValues, [in] UINT count );
		void SetGreenTable([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] tableValues, uint count);

		/// <summary>Sets the list of values used to define the transfer function for the blue channel.</summary>
		/// <param name="tableValues">
		///   <para>Type: <b>const float*</b></para>
		///   <para>The list of values used to define the transfer function for the blue channel.</para>
		/// </param>
		/// <param name="count">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The number of values in the tableValues parameter.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setbluetable
		// HRESULT SetBlueTable( [in] const float *tableValues, [in] UINT count );
		void SetBlueTable([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] tableValues, uint count);

		/// <summary>Sets the list of values used to define the transfer function for the alpha channel.</summary>
		/// <param name="tableValues">
		///   <para>Type: <b>const float*</b></para>
		///   <para>The list of values used to define the transfer function for the alpha channel.</para>
		/// </param>
		/// <param name="count">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The number of values in the tableValues parameter.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setalphatable
		// HRESULT SetAlphaTable( [in] const float *tableValues, [in] UINT count );
		void SetAlphaTable([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] tableValues, uint count);

		/// <summary>Specifies whether to apply the transfer function to the red channel.</summary>
		/// <param name="redDisable">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>A boolean value that specifies whether to apply the transfer function to the red channel. If you set this to TRUE the effect does not apply the transfer function to the red channel. If you set this to FALSE it applies the RedTableTransfer function to the red channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setreddisable
		// HRESULT SetRedDisable( [in] BOOL redDisable );
		void SetRedDisable([MarshalAs(UnmanagedType.Bool)] bool redDisable);

		/// <summary>Specifies whether to apply the transfer function to the green channel.</summary>
		/// <param name="greenDisable">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>A boolean value that specifies whether to apply the transfer function to the green channel. If you set this to TRUE the effect does not apply the transfer function to the green channel. If you set this to FALSE it applies the GreenTableTransfer function to the green channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setgreendisable
		// HRESULT SetGreenDisable( [in] BOOL greenDisable );
		void SetGreenDisable([MarshalAs(UnmanagedType.Bool)] bool greenDisable);

		/// <summary>Specifies whether to apply the transfer function to the blue channel.</summary>
		/// <param name="blueDisable">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>A boolean value that specifies whether to apply the transfer function to the blue channel. If you set this to TRUE the effect does not apply the transfer function to the blue channel. If you set this to FALSE it applies the BlueTableTransfer function to the Blue channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setbluedisable
		// HRESULT SetBlueDisable( [in] BOOL blueDisable );
		void SetBlueDisable([MarshalAs(UnmanagedType.Bool)] bool blueDisable);

		/// <summary>Specifies whether to apply the transfer function to the Alpha channel.</summary>
		/// <param name="alphaDisable">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>A boolean value that specifies whether to apply the transfer function to the alpha channel. If you set this to TRUE the effect does not apply the transfer function to the Alpha channel. If you set this to FALSE it applies the AlphaTableTransfer function to the Alpha channel.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setalphadisable
		// HRESULT SetAlphaDisable( [in] BOOL alphaDisable );
		void SetAlphaDisable([MarshalAs(UnmanagedType.Bool)] bool alphaDisable);

		/// <summary>Specifies whether the effect clamps color values to between 0 and 1 before the effect passes the values to the next effect in the graph.</summary>
		/// <param name="clampOutput">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>A boolean value that specifies whether the effect clamps color values to between 0 and 1 before the effect passes the values to the next effect in the graph. If you set this to TRUE the effect will clamp the values. If you set this to FALSE, the effect will not clamp the color values, but other effects and the output surface may clamp the values if they are not of high enough precision. The effect clamps the values before it premultiplies the alpha.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setclampoutput
		// HRESULT SetClampOutput( [in] BOOL clampOutput );
		void SetClampOutput([MarshalAs(UnmanagedType.Bool)] bool clampOutput);

		/// <summary>Sets a value in the red table.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The index of the value to set.</para>
		/// </param>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the value changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setredtablevalue(uint_idcompositionanimation)
		// HRESULT SetRedTableValue( [in] UINT index, [in] IDCompositionAnimation *animation );
		void SetRedTableValue(uint index, [In] IDCompositionAnimation animation);

		/// <summary>Sets a value in the red table.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The index of the value to set.</para>
		/// </param>
		/// <param name="value">
		///   <para>Type: <b>float</b></para>
		///   <para>The new value.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setredtablevalue(uint_float)
		// HRESULT SetRedTableValue( [in] UINT index, [in] float value );
		void SetRedTableValue(uint index, [In] float value);

		/// <summary>Sets a value in the green table.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The index of the value to set.</para>
		/// </param>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the value changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setgreentablevalue(uint_idcompositionanimation)
		// HRESULT SetGreenTableValue( [in] UINT index, [in] IDCompositionAnimation *animation );
		void SetGreenTableValue(uint index, [In] IDCompositionAnimation animation);

		/// <summary>Sets a value in the green table.</summary>
		/// <param name="index">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The index of the value to set.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <b>float</b></para>
		/// <para>The value to set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setgreentablevalue(uint_float)
		// HRESULT SetGreenTableValue( [in] UINT index, [in] float value );
		void SetGreenTableValue(uint index, [In] float value);

		/// <summary>Sets a value in the blue table.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The index of the value to set.</para>
		/// </param>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the value changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setbluetablevalue(uint_idcompositionanimation)
		// HRESULT SetBlueTableValue( [in] UINT index, [in] IDCompositionAnimation *animation );
		void SetBlueTableValue(uint index, [In] IDCompositionAnimation animation);

		/// <summary>Sets a value in the blue table.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The index of the value to set.</para>
		/// </param>
		/// <param name="value">
		///   <para>Type: <b>float</b></para>
		///   <para>The new value.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setbluetablevalue(uint_float)
		// HRESULT SetBlueTableValue( [in] UINT index, [in] float value );
		void SetBlueTableValue(uint index, [In] float value);

		/// <summary>Sets a value in the alpha table.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Index of the value to change.</para>
		/// </param>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the value in the alpha table changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setalphatablevalue(uint_idcompositionanimation)
		// HRESULT SetAlphaTableValue( [in] UINT index, [in] IDCompositionAnimation *animation );
		void SetAlphaTableValue(uint index, [In] IDCompositionAnimation animation);

		/// <summary>Sets a value in the alpha table.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The index of the value to set.</para>
		/// </param>
		/// <param name="value">
		///   <para>Type: <b>float</b></para>
		///   <para>The new value.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontabletransfereffect-setalphatablevalue(uint_float)
		// HRESULT SetAlphaTableValue( [in] UINT index, [in] float value );
		void SetAlphaTableValue(uint index, [In] float value);
	}

	/// <summary>The composite effect is used to combine 2 or more images. This effect has 13 different composite modes. The composite effect accepts 2 or more inputs. When you specify 2 images, destination is the first input (index 0) and the source is the second input (index 1). If you specify more than 2 inputs, the images are composited starting with the first input and the second and so on.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositioncompositeeffect
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionCompositeEffect")]
	[ComImport, Guid("576616C0-A231-494D-A38D-00FD5EC4DB46"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionCompositeEffect : IDCompositionFilterEffect
	{
		/// <summary>Sets the input at an index to the specified filter effect.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Specifies the index the to apply the filter effect at.</para>
		/// </param>
		/// <param name="input">
		///   <para>Type: <b>IUnknown*</b></para>
		///   <para>The filter effect to apply. The following effects are available:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <c>IDCompositionAffineTransform2DEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionArithmeticCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBlendEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBrightnessEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionColorMatrixEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionFloodEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionGaussianBlurEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionHueRotationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionLinearTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionSaturationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionShadowEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTableTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTurbulenceEffect</c>
		///       </description>
		///     </item>
		///   </list>
		/// </param>
		/// <param name="flags">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Flags to apply to the filter effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionfiltereffect-setinput
		// HRESULT SetInput( [in] UINT index, [in, optional] IUnknown *input, [in] UINT flags );
		new void SetInput(uint index, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? input, uint flags = 0);

		/// <summary>Sets the mode for the composite effect.</summary>
		/// <param name="mode">The mode for the composite effect.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositioncompositeeffect-setmode
		void SetMode([In] D2D1_COMPOSITE_MODE mode);
	}

	/// <summary>The Blend Effect is used to combine 2 images.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionblendeffect
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionBlendEffect")]
	[ComImport, Guid("33ECDC0A-578A-4A11-9C14-0CB90517F9C5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionBlendEffect : IDCompositionFilterEffect
	{
		/// <summary>Sets the input at an index to the specified filter effect.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Specifies the index the to apply the filter effect at.</para>
		/// </param>
		/// <param name="input">
		///   <para>Type: <b>IUnknown*</b></para>
		///   <para>The filter effect to apply. The following effects are available:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <c>IDCompositionAffineTransform2DEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionArithmeticCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBlendEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBrightnessEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionColorMatrixEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionFloodEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionGaussianBlurEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionHueRotationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionLinearTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionSaturationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionShadowEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTableTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTurbulenceEffect</c>
		///       </description>
		///     </item>
		///   </list>
		/// </param>
		/// <param name="flags">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Flags to apply to the filter effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionfiltereffect-setinput
		// HRESULT SetInput( [in] UINT index, [in, optional] IUnknown *input, [in] UINT flags );
		new void SetInput(uint index, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? input, uint flags = 0);

		/// <summary>Sets the blend mode to use when the blend effect combines the two images.</summary>
		/// <param name="mode">
		///   <para>Type: <b><c>D2D1_BLEND_MODE</c></b></para>
		///   <para>The blend mode to use when the blend effect combines the two images.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionblendeffect-setmode
		// HRESULT SetMode( [in] D2D1_BLEND_MODE mode );
		void SetMode([In] D2D1_BLEND_MODE mode);
	}

	/// <summary>The arithmetic composite effect is used to combine 2 images using a weighted sum of pixels from the input images.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionarithmeticcompositeeffect
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionArithmeticCompositeEffect")]
	[ComImport, Guid("3B67DFA8-E3DD-4E61-B640-46C2F3D739DC"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionArithmeticCompositeEffect : IDCompositionFilterEffect
	{
		/// <summary>Sets the input at an index to the specified filter effect.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Specifies the index the to apply the filter effect at.</para>
		/// </param>
		/// <param name="input">
		///   <para>Type: <b>IUnknown*</b></para>
		///   <para>The filter effect to apply. The following effects are available:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <c>IDCompositionAffineTransform2DEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionArithmeticCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBlendEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBrightnessEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionColorMatrixEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionFloodEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionGaussianBlurEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionHueRotationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionLinearTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionSaturationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionShadowEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTableTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTurbulenceEffect</c>
		///       </description>
		///     </item>
		///   </list>
		/// </param>
		/// <param name="flags">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Flags to apply to the filter effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionfiltereffect-setinput
		// HRESULT SetInput( [in] UINT index, [in, optional] IUnknown *input, [in] UINT flags );
		new void SetInput(uint index, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? input, uint flags = 0);

		/// <summary>Sets the coefficients for the equation used to composite the two input images.</summary>
		/// <param name="coefficients">
		///   <para>Type: <b>const <c>D2D1_VECTOR_4F</c></b></para>
		///   <para>The coefficients for the equation used to composite the two input images.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionarithmeticcompositeeffect-setcoefficients
		// HRESULT SetCoefficients( [in, ref] const D2D1_VECTOR_4F &amp; coefficients );
		void SetCoefficients(in D2D_VECTOR_4F coefficients);

		/// <summary>Specifies whether to clamp color values before the effect passes the values to the next effect in the graph.</summary>
		/// <param name="clampoutput">
		///   <para>Type: <b>BOOL</b></para>
		///   <para>A boolean value indicating whether to clamp the color values. A value of TRUE causes color values to be clamped between 0 and 1.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionarithmeticcompositeeffect-setclampoutput
		// HRESULT SetClampOutput( [in] BOOL clampoutput );
		void SetClampOutput([MarshalAs(UnmanagedType.Bool)] bool clampoutput);

		/// <summary>Sets the first coefficient for the equation used to composite the two input images.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the value changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionarithmeticcompositeeffect-setcoefficient1(idcompositionanimation)
		// HRESULT SetCoefficient1( [in] IDCompositionAnimation *animation );
		void SetCoefficient1([In] IDCompositionAnimation animation);

		/// <summary>Sets the first coefficient for the equation used to composite the two input images.</summary>
		/// <param name="Coeffcient1">
		///   <para>Type: <b>float</b></para>
		///   <para>Specifies the first coefficient for the equation used to composite the two input images.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionarithmeticcompositeeffect-setcoefficient1(float)
		// HRESULT SetCoefficient1( [in] float Coeffcient1 );
		void SetCoefficient1([In] float Coeffcient1);

		/// <summary>Sets the second coefficient for the equation used to composite the two input images.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the value of the second coefficient changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionarithmeticcompositeeffect-setcoefficient2(idcompositionanimation)
		// HRESULT SetCoefficient2( [in] IDCompositionAnimation *animation );
		void SetCoefficient2([In] IDCompositionAnimation animation);

		/// <summary>Sets the second coefficient for the equation used to composite the two input images.</summary>
		/// <param name="Coefficient2">
		///   <para>Type: <b>float</b></para>
		///   <para>The second coefficient for the equation used to composite the two input images.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionarithmeticcompositeeffect-setcoefficient2(float)
		// HRESULT SetCoefficient2( [in] float Coefficient2 );
		void SetCoefficient2([In] float Coefficient2);

		/// <summary>Sets the third coefficient for the equation used to composite the two input images.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the value of the third coefficient changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionarithmeticcompositeeffect-setcoefficient3(idcompositionanimation)
		// HRESULT SetCoefficient3( [in] IDCompositionAnimation *animation );
		void SetCoefficient3([In] IDCompositionAnimation animation);

		/// <summary>Sets the third coefficient for the equation used to composite the two input images.</summary>
		/// <param name="Coefficient3">
		///   <para>Type: <b>float</b></para>
		///   <para>The third coefficient for the equation used to composite the two input images.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionarithmeticcompositeeffect-setcoefficient3(float)
		// HRESULT SetCoefficient3( [in] float Coefficient3 );
		void SetCoefficient3([In] float Coefficient3);

		/// <summary>Sets the fourth coefficient for the equation used to composite the two input images.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the value of the fourth coefficient changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionarithmeticcompositeeffect-setcoefficient4(idcompositionanimation)
		// HRESULT SetCoefficient4( [in] IDCompositionAnimation *animation );
		void SetCoefficient4([In] IDCompositionAnimation animation);

		/// <summary>Sets the fourth coefficient for the equation used to composite the two input images.</summary>
		/// <param name="Coefficient4">
		///   <para>Type: <b>float</b></para>
		///   <para>The fourth coefficient for the equation used to composite the two input images.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionarithmeticcompositeeffect-setcoefficient4(float)
		// HRESULT SetCoefficient4( [in] float Coefficient4 );
		void SetCoefficient4([In] float Coefficient4);
	}

	/// <summary>The arithmetic composite effect is used to combine 2 images using a weighted sum of pixels from the input images.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositionaffinetransform2deffect
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionAffineTransform2DEffect")]
	[ComImport, Guid("0B74B9E8-CDD6-492F-BBBC-5ED32157026D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionAffineTransform2DEffect : IDCompositionFilterEffect
	{
		/// <summary>Sets the input at an index to the specified filter effect.</summary>
		/// <param name="index">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Specifies the index the to apply the filter effect at.</para>
		/// </param>
		/// <param name="input">
		///   <para>Type: <b>IUnknown*</b></para>
		///   <para>The filter effect to apply. The following effects are available:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <c>IDCompositionAffineTransform2DEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionArithmeticCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBlendEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionBrightnessEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionColorMatrixEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionCompositeEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionFloodEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionGaussianBlurEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionHueRotationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionLinearTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionSaturationEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionShadowEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTableTransferEffect</c>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>IDCompositionTurbulenceEffect</c>
		///       </description>
		///     </item>
		///   </list>
		/// </param>
		/// <param name="flags">
		///   <para>Type: <b>UINT</b></para>
		///   <para>Flags to apply to the filter effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionfiltereffect-setinput
		// HRESULT SetInput( [in] UINT index, [in, optional] IUnknown *input, [in] UINT flags );
		new void SetInput(uint index, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? input, uint flags = 0);

		/// <summary>Sets the interpolation mode of the effect.</summary>
		/// <param name="interpolationMode">
		///   <para>Type: <b><c>D2D1_2DAFFINETRANSFORM_INTERPOLATION_MODE</c></b></para>
		///   <para>Specifies the interpolation mode of the effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionaffinetransform2deffect-setinterpolationmode
		// HRESULT SetInterpolationMode( [in] D2D1_2DAFFINETRANSFORM_INTERPOLATION_MODE interpolationMode );
		void SetInterpolationMode([In] D2D1_2DAFFINETRANSFORM_INTERPOLATION_MODE interpolationMode);

		/// <summary>Sets the border mode to use with the effect.</summary>
		/// <param name="borderMode">
		///   <para>Type: <b><c>D2D1_BORDER_MODE</c></b></para>
		///   <para>Specifies the border mode to use with the effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionaffinetransform2deffect-setbordermode
		// HRESULT SetBorderMode( [in] D2D1_BORDER_MODE borderMode );
		void SetBorderMode([In] D2D1_BORDER_MODE borderMode);

		/// <summary>Sets the transform matrix of the effect.</summary>
		/// <param name="transformMatrix">
		///   <para>Type: <b>const <c>D2D1_MATRIX_3X2_F</c></b></para>
		///   <para>Specifies the transform matrix for the effect to use.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionaffinetransform2deffect-settransformmatrix
		// HRESULT SetTransformMatrix( [in, ref] const D2D1_MATRIX_3X2_F &amp; transformMatrix );
		void SetTransformMatrix(in D2D_MATRIX_3X2_F transformMatrix);

		/// <summary>Sets an element of the transform matrix of the effect.</summary>
		/// <param name="row">
		///   <para>Type: <b>int</b></para>
		///   <para>The row of the element.</para>
		/// </param>
		/// <param name="column">
		///   <para>Type: <b>int</b></para>
		///   <para>The column of the element.</para>
		/// </param>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the element value changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionaffinetransform2deffect-settransformmatrixelement(int_int_idcompositionanimation)
		// HRESULT SetTransformMatrixElement( [in] int row, [in] int column, [in] IDCompositionAnimation *animation );
		void SetTransformMatrixElement(int row, int column, [In] IDCompositionAnimation animation);

		/// <summary>Sets an element of the transform matrix of the effect.</summary>
		/// <param name="row">
		///   <para>Type: <b>int</b></para>
		///   <para>The row of the element.</para>
		/// </param>
		/// <param name="column">
		///   <para>Type: <b>int</b></para>
		///   <para>The column of the element.</para>
		/// </param>
		/// <param name="value">
		///   <para>Type: <b>float</b></para>
		///   <para>The new value of the element.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionaffinetransform2deffect-settransformmatrixelement(int_int_float)
		// HRESULT SetTransformMatrixElement( [in] int row, [in] int column, [in] float value );
		void SetTransformMatrixElement(int row, int column, [In] float value);

		/// <summary>Sets the sharpness of the effect.</summary>
		/// <param name="animation">
		///   <para>Type: <b><c>IDCompositionAnimation</c>*</b></para>
		///   <para>An animation that represents how the sharpness value changes over time. This parameter must not be NULL.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionaffinetransform2deffect-setsharpness(idcompositionanimation)
		// HRESULT SetSharpness( [in] IDCompositionAnimation *animation );
		void SetSharpness([In] IDCompositionAnimation animation);

		/// <summary>Sets the sharpness of the effect.</summary>
		/// <param name="sharpness">
		///   <para>Type: <b>float</b></para>
		///   <para>Specifies the sharpness of the effect.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositionaffinetransform2deffect-setsharpness(float)
		// HRESULT SetSharpness( [in] float sharpness );
		void SetSharpness([In] float sharpness);
	}

	/// <summary>
	/// <para>Important</para>
	/// <para>Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</para>
	/// </summary>
	[PInvokeData("dcomp.h", MSDNShortId = "NS:dcomp.DCompositionInkTrailPoint")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DCompositionInkTrailPoint
	{
		/// <summary />
		public float x;
		/// <summary />
		public float y;
		/// <summary />
		public float radius;
	}

	/// <summary>
	/// <para>Important</para>
	/// <para>Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositiondelegatedinktrail
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionDelegatedInkTrail")]
	[ComImport, Guid("C2448E9B-547D-4057-8CF5-8144EDE1C2DA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionDelegatedInkTrail
	{
		/// <summary>
		/// <para>Important</para>
		/// <para>Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</para>
		/// </summary>
		/// <param name="inkPoints" />
		/// <param name="inkPointsCount" />
		/// <returns>generationId</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondelegatedinktrail-addtrailpoints
		// HRESULT AddTrailPoints( const DCompositionInkTrailPoint *inkPoints, UINT inkPointsCount, UINT *generationId );
		uint AddTrailPoints([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DCompositionInkTrailPoint[] inkPoints, uint inkPointsCount);

		/// <summary>
		/// <para>Important</para>
		/// <para>Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</para>
		/// </summary>
		/// <param name="inkPoints" />
		/// <param name="inkPointsCount" />
		/// <param name="predictedInkPoints" />
		/// <param name="predictedInkPointsCount" />
		/// <returns>generationId</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondelegatedinktrail-addtrailpointswithprediction
		// HRESULT AddTrailPointsWithPrediction( const DCompositionInkTrailPoint *inkPoints, UINT inkPointsCount, const DCompositionInkTrailPoint *predictedInkPoints, UINT predictedInkPointsCount, UINT *generationId );
		uint AddTrailPointsWithPrediction([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DCompositionInkTrailPoint[] inkPoints, uint inkPointsCount,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DCompositionInkTrailPoint[] predictedInkPoints, uint predictedInkPointsCount);

		/// <summary>
		/// <para>Important</para>
		/// <para>Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</para>
		/// </summary>
		/// <param name="generationId" />
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondelegatedinktrail-removetrailpoints
		// HRESULT RemoveTrailPoints( UINT generationId );
		void RemoveTrailPoints(uint generationId);

		/// <summary>
		/// <para>Important</para>
		/// <para>Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</para>
		/// </summary>
		/// <param name="color" />
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondelegatedinktrail-startnewtrail
		// HRESULT StartNewTrail( const D2D1_COLOR_F &amp; color );
		void StartNewTrail(in D3DCOLORVALUE color);
	}

	/// <summary>
	/// <para>Important</para>
	/// <para>Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositioninktraildevice
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionInkTrailDevice")]
	[ComImport, Guid("DF0C7CEC-CDEB-4D4A-B91C-721BF22F4E6C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionInkTrailDevice
	{
		/// <summary>
		/// <para>Important</para>
		/// <para>Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</para>
		/// </summary>
		/// <returns>inkTrail</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositioninktraildevice-createdelegatedinktrail
		// HRESULT CreateDelegatedInkTrail( IDCompositionDelegatedInkTrail **inkTrail );
		IDCompositionDelegatedInkTrail CreateDelegatedInkTrail();

		/// <summary>
		/// <para>Important</para>
		/// <para>Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</para>
		/// </summary>
		/// <param name="swapChain" />
		/// <returns>inkTrail</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositioninktraildevice-createdelegatedinktrailforswapchain
		// HRESULT CreateDelegatedInkTrailForSwapChain( IUnknown *swapChain, IDCompositionDelegatedInkTrail **inkTrail );
		IDCompositionDelegatedInkTrail CreateDelegatedInkTrailForSwapChain([In, MarshalAs(UnmanagedType.IUnknown)] object swapChain);
	}

	/// <summary>
	/// <para>Important</para>
	/// <para>Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</para>
	/// </summary>
	/// <remarks>The lifetime of a composition texture is designed to work without intervention from your app. Your app doesn't need to keep a texture alive for the sake of what the system might be doing. If your app releases a texture that the system is still displaying in a visual tree, then the system will keep that texture alive until it's no longer necessary to do so. Your app can operate under the assumption that it needs to keep a composition texture alive only if it wants to explicitly reference it again.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nn-dcomp-idcompositiontexture
	[PInvokeData("dcomp.h", MSDNShortId = "NN:dcomp.IDCompositionTexture")]
	[ComImport, Guid("929BB1AA-725F-433B-ABD7-273075A835F2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionTexture
	{
		/// <summary/>
		void SetSourceRect(in D2D_RECT_U sourceRect);

		/// <summary/>
		void SetColorSpace([In] DXGI_COLOR_SPACE_TYPE colorSpace);

		/// <summary/>
		void SetAlphaMode([In] DXGI_ALPHA_MODE alphaMode);

		/// <summary>
		/// <para>Important</para>
		/// <para>Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</para>
		/// </summary>
		/// <param name="fenceValue">
		/// <para>Type: _Out_ <b>UINT64*</b></para>
		/// <para>The returned fence value.</para>
		/// </param>
		/// <param name="iid">
		/// <para>Type: _In_ <b>REFIID</b></para>
		/// <para>An interface identifier.</para>
		/// </param>
		/// <param name="availableFence">
		/// <para>Type: _Outptr_result_maybenull_ <b>void**</b></para>
		/// <para>The returned available fence, or <c>nullptr</c>, depending on the availability state of the composition texture. For details, see the <b>Remarks</b> section.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Here are the availability states, their descriptions, and how <b>GetAvailableFence</b> behaves for each state.</para>
		/// <para><b>immediately available</b>. The composition texture isn't being displayed by the desktop window manager (DWM), nor are application commits queued to have it do so. So the composition texture is safe to write to immediately. <b>GetAvailableFence</b> returns the available fence, which will already match the returned value.</para>
		/// <para><b>soon-to-be available</b>. The composition texture is currently being displayed by DWM, but the application has removed it from its visual tree, and committed to DWM. However, that commit hasn't yet been processed by DWM, so DWM hasn't yet stopped displaying the texture. Your app can render to a soon-to-be available texture if that work is synchronized against the texture’s available fence. <b>GetAvailableFence</b> returns the available fence. The composition texture will be safe to write to when that fence is signaled to the returned value.</para>
		/// <para><b>unavailable</b>. The composition texture is currently being displayed by DWM, or it's queued for display by DWM. So your app shouldn't write to it. <b>GetAvailableFence</b> returns <c>nullptr</c> instead of a fence.</para>
		/// <para>The available fence describes the availability of a single composition texture. Multiple composition textures might reference the same Direct3D texture, if each composition texture takes a different (non-overlapping) region of the larger Direct3D texture by specifying a source rect (a technique known as atlasing). In a case like that, if a composition texture becomes available, then your app must be careful to issue rendering only to the exact subregion of the Direct3D texture; to make sure not to interfere with pixels that might belong to other composition textures (which might not be available). That's because different regions of a single Direct3D texture might have different availability states.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiontexture-getavailablefence
		// HRESULT GetAvailableFence( UINT64 *fenceValue, REFIID iid, void **availableFence );
		void GetAvailableFence(out ulong fenceValue, in Guid iid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? availableFence);
	}

	/// <summary/>
	[ComImport, Guid("85FC5CCA-2DA6-494C-86B6-4A775C049B8A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDCompositionDevice4 : IDCompositionDevice3
	{
		/// <summary>Commits all DirectComposition commands that are pending on this device.</summary>
		/// <remarks>
		///   <para>Calls to DirectComposition methods are always batched and executed atomically as a single transaction. Calls take effect only when <b>IDCompositionDevice2::Commit</b> is called, at which time all pending method calls for a device are executed at once.</para>
		///   <para>An application that uses multiple devices must call <b>Commit</b> for each device separately. However, because the composition engine processes the calls individually, the batch of commands might not take effect at the same time.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-commit
		// HRESULT Commit();
		new void Commit();

		/// <summary>Waits for the composition engine to finish processing the previous call to the <c>IDCompositionDevice2::Commit</c> method.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-waitforcommitcompletion
		// HRESULT WaitForCommitCompletion();
		new void WaitForCommitCompletion();

		/// <summary>Retrieves information from the composition engine about composition times and the frame rate.</summary>
		/// <returns>
		///   <para>Type: <b><c>DCOMPOSITION_FRAME_STATISTICS</c>*</b></para>
		///   <para>A structure that receives composition times and frame rate information.</para>
		/// </returns>
		/// <remarks>This method retrieves timing information about the composition engine that an application can use to synchronize the rasterization of bitmaps with independent animations.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-getframestatistics
		// HRESULT GetFrameStatistics( [out] DCOMPOSITION_FRAME_STATISTICS *statistics );
		new DCOMPOSITION_FRAME_STATISTICS GetFrameStatistics();

		/// <summary>Creates a new visual object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionVisual2</c>**</b></para>
		///   <para>The new visual object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new visual object has a static value of zero for the OffsetX and OffsetY properties, and NULL for the Transform, Clip, and Content properties. Initially, the visual does not cause the contents of a window to change. The visual must be added as a child of another visual, or as the root of a composition target, before it can affect the appearance of a window.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createvisual
		// HRESULT CreateVisual( [out] IDCompositionVisual2 **visual );
		new IDCompositionVisual2 CreateVisual();

		/// <summary>Creates a Microsoft DirectComposition surface factory object, which can be used to create other DirectComposition surface or virtual surface objects</summary>
		/// <param name="renderingDevice">A pointer to a DirectX device to be used to create DirectComposition surface objects. Must be a pointer to an object implementing the <c>IDXGIDevice</c> or <c>ID2D1Device</c> interfaces. This parameter must not be NULL.</param>
		/// <returns>The newly created surface factory object. This parameter must not be NULL.</returns>
		/// <remarks>
		///   <para>A surface factory allows an application to simultaneously use more than one single DXGI or Direct2D device with DirectComposition. Each surface factory has a permanent association with one DXGI or Direct2D device, but a DirectComposition device may have any number of surface factories.</para>
		///   <para>Each surface factory manages resources independently from the others. In particular, DirectComposition pools surface allocations to mitigate surface allocation and deallocation costs. This pool is done on a per-surface factory basis.</para>
		///   <para>If the <c>DCompositionCreateDevice2</c> function is called with a non-NULL <i>renderingDevice</i> parameter, the returned DirectComposition device object has an implicit surface factory under the covers associated with the given rendering device. This implicit surface factory is used to service the <c>IDCompositionDevice::CreateSurface</c>, <c>IDCompositionDevice::CreateVirtualSurface</c>, <c>IDCompositionDevice2::CreateSurface</c> and <c>IDCompositionDevice2::CreateVirtualSurface</c> methods.</para>
		///   <para>A surface object remains alive as long as any of the surfaces or virtual surfaces that it created remain alive, either directly because the application holds a direct reference, or indirectly because one or more such surfaces are associated with one or more visual objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createsurfacefactory
		// HRESULT CreateSurfaceFactory( [in] IUnknown *renderingDevice, [out] IDCompositionSurfaceFactory **surfaceFactory );
		new IDCompositionSurfaceFactory CreateSurfaceFactory([In, MarshalAs(UnmanagedType.IUnknown)] object renderingDevice);

		/// <summary>Creates an updateable surface object that can be associated with one or more visuals for composition.</summary>
		/// <param name="width">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The width of the surface, in pixels. Constrained by the <c>feature level</c> of the rendering device that was passed in at the time the DirectComposition device was created.</para>
		/// </param>
		/// <param name="height">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The height of the surface, in pixels. Constrained by the <c>feature level</c> of the rendering device that was passed in at the time the DirectComposition device was created.</para>
		/// </param>
		/// <param name="pixelFormat">
		///   <para>Type: <b><c>DXGI_FORMAT</c></b></para>
		///   <para>The pixel format of the surface.</para>
		/// </param>
		/// <param name="alphaMode">
		///   <para>Type: <b><c>DXGI_ALPHA_MODE</c></b></para>
		///   <para>The format of the alpha channel, if an alpha channel is included in the pixel format. It can be one of the following values:</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_UNSPECIFIED</b>
		///       </description>
		///       <description>The alpha channel is not specified. This value has the same effect as <b>DXGI_ALPHA_MODE_IGNORE</b>.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_PREMULTIPLIED</b>
		///       </description>
		///       <description>The color channels contain values that are premultiplied with the alpha channel.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_IGNORE</b>
		///       </description>
		///       <description>The alpha channel should be ignored and the bitmap should be rendered opaquely.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionSurface</c>**</b></para>
		///   <para>The newly created surface object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A Microsoft DirectComposition surface is a rectangular array of pixels that can be associated with a visual for composition.</para>
		///   <para>A newly created surface object is in an uninitialized state. While it is uninitialized, the surface has no effect on the composition of the visual tree. It behaves exactly like a surface that has 100% transparent pixels.</para>
		///   <para>To initialize the surface with pixel data, use the <c>IDCompositionSurface::BeginDraw</c> and <c>IDCompositionSurface::EndDraw</c> methods. The first call to this method must cover the entire surface area to provide an initial value for every pixel. Subsequent calls may specify smaller sub-rectangles of the surface to update.</para>
		///   <para>DirectComposition surfaces support the following pixel formats:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_B8G8R8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R8G8B8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R16G16B16A16_FLOAT</b>
		///       </description>
		///     </item>
		///   </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createsurface
		// HRESULT CreateSurface( [in] UINT width, [in] UINT height, [in] DXGI_FORMAT pixelFormat, [in] DXGI_ALPHA_MODE alphaMode, [out] IDCompositionSurface **surface );
		new IDCompositionSurface CreateSurface(uint width, uint height, [In] DXGI_FORMAT pixelFormat, [In] DXGI_ALPHA_MODE alphaMode);

		/// <summary>Creates a sparsely populated surface that can be associated with one or more visuals for composition.</summary>
		/// <param name="initialWidth">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The width of the surface, in pixels. The maximum width is 16,777,216 pixels.</para>
		/// </param>
		/// <param name="initialHeight">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The height of the surface, in pixels. The maximum height is 16,777,216 pixels.</para>
		/// </param>
		/// <param name="pixelFormat">
		///   <para>Type: <b><c>DXGI_FORMAT</c></b></para>
		///   <para>The pixel format of the surface.</para>
		/// </param>
		/// <param name="alphaMode">
		///   <para>Type: <b><c>DXGI_ALPHA_MODE</c></b></para>
		///   <para>The meaning of the alpha channel, if the pixel format contains an alpha channel. It can be one of the following values:</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_UNSPECIFIED</b>
		///       </description>
		///       <description>The alpha channel is not specified. This value has the same effect as <b>DXGI_ALPHA_MODE_IGNORE</b>.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_PREMULTIPLIED</b>
		///       </description>
		///       <description>The color channels contain values that are premultiplied with the alpha channel.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c>
		///         <c></c>
		///         <b>DXGI_ALPHA_MODE_IGNORE</b>
		///       </description>
		///       <description>The alpha channel should be ignored and the bitmap should be rendered opaquely.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionVirtualSurface</c>**</b></para>
		///   <para>The newly created surface object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A Microsoft DirectComposition sparse surface is a logical object that behaves like a rectangular array of pixels that can be associated with a visual for composition. The surface is not necessarily backed by any physical video or system memory for every one of its pixels. The application can realize or virtualize parts of the logical surface at different times.</para>
		///   <para>A newly created surface object is in an uninitialized state. While it is uninitialized, the surface has no effect on the composition of the visual tree. It behaves exactly like a surface that is initialized with 100% transparent pixels.</para>
		///   <para>To initialize the surface with pixel data, use the <c>IDCompositionSurface::BeginDraw</c> and <c>IDCompositionSurface::EndDraw</c> methods. This method not only provides pixels for the surface, but it also allocates actual storage space for those pixels. The memory allocation persists until the application returns some of the memory to the system. The application can free part or all of the allocated memory by calling the <c>IDCompositionVirtualSurface::Trim</c> method.</para>
		///   <para>DirectComposition surfaces support the following pixel formats:</para>
		///   <list type="bullet">
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_B8G8R8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R8G8B8A8_UNORM</b>
		///       </description>
		///     </item>
		///     <item>
		///       <description>
		///         <b>DXGI_FORMAT_R16G16B16A16_FLOAT</b>
		///       </description>
		///     </item>
		///   </list>
		///   <para>This method fails if <i>initialWidth</i> or <i>initialHeight</i> exceeds 16,777,216 pixels.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createvirtualsurface
		// HRESULT CreateVirtualSurface( [in] UINT initialWidth, [in] UINT initialHeight, [in] DXGI_FORMAT pixelFormat, [in] DXGI_ALPHA_MODE alphaMode, [out] IDCompositionVirtualSurface **virtualSurface );
		new IDCompositionVirtualSurface CreateVirtualSurface(uint initialWidth, uint initialHeight, [In] DXGI_FORMAT pixelFormat, [In] DXGI_ALPHA_MODE alphaMode);

		/// <summary>Creates a 2D translation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTranslateTransform</c>**</b></para>
		///   <para>The new 2D translation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D translation transform object has a static value of zero for the OffsetX and OffsetY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtranslatetransform
		// HRESULT CreateTranslateTransform( [out] IDCompositionTranslateTransform **translateTransform );
		new IDCompositionTranslateTransform CreateTranslateTransform();

		/// <summary>Creates a 2D scale transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionScaleTransform</c>**</b></para>
		///   <para>The new 2D scale transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D scale transform object has a static value of zero for the ScaleX, ScaleY, CenterX, and CenterY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createscaletransform
		// HRESULT CreateScaleTransform( [out] IDCompositionScaleTransform **scaleTransform );
		new IDCompositionScaleTransform CreateScaleTransform();

		/// <summary>Creates a 2D rotation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionRotateTransform</c>**</b></para>
		///   <para>The new rotation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D rotation transform object has a static value of zero for the Angle, CenterX, and CenterY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createrotatetransform
		// HRESULT CreateRotateTransform( [out] IDCompositionRotateTransform **rotateTransform );
		new IDCompositionRotateTransform CreateRotateTransform();

		/// <summary>Creates a 2D skew transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionSkewTransform</c>**</b></para>
		///   <para>The new 2D skew transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 2D skew transform object has a static value of zero for the AngleX, AngleY, CenterX, and CenterY properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createskewtransform
		// HRESULT CreateSkewTransform( [out] IDCompositionSkewTransform **skewTransform );
		new IDCompositionSkewTransform CreateSkewTransform();

		/// <summary>Creates a 2D 3-by-2 matrix transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionMatrixTransform</c>**</b></para>
		///   <para>The new matrix transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A new matrix transform object has the identity matrix as its initial value. The identity matrix is the 3x2 matrix with ones on the main diagonal and zeros elsewhere, as shown in the following illustration.</para>
		///   <para>When an identity transform is applied to an object, it does not change the position, shape, or size of the object. It is similar to the way that multiplying a number by one does not change the number. Any transform other than the identity transform will modify the position, shape, and/or size of objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-creatematrixtransform
		// HRESULT CreateMatrixTransform( [out] IDCompositionMatrixTransform **matrixTransform );
		new IDCompositionMatrixTransform CreateMatrixTransform();

		/// <summary>Creates a 2D transform group object that holds an array of 2D transform objects.</summary>
		/// <param name="transforms">
		///   <para>Type: <b><c>IDCompositionTransform</c>**</b></para>
		///   <para>An array of 2D transform objects that make up this transform group.</para>
		/// </param>
		/// <param name="elements">
		///   <para>Type: <b>UINT</b></para>
		///   <para>The number of elements in the <i>transforms</i> array.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTransform</c>**</b></para>
		///   <para>The new transform group object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>The array entries in a transform group cannot be changed. However, each transform in the array can be modified through its own property setting methods. If a transform in the array is modified, the change is reflected in the computed matrix of the transform group.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtransformgroup
		// HRESULT CreateTransformGroup( [in] IDCompositionTransform **transforms, [in] UINT elements, [out] IDCompositionTransform **transformGroup );
		new IDCompositionTransform CreateTransformGroup([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.Interface)] IDCompositionTransform[] transforms, uint elements);

		/// <summary>Creates a 3D translation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTranslateTransform3D</c>**</b></para>
		///   <para>The new 3D translation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A newly created 3D translation transform has a static value of 0 for the OffsetX, OffsetY, and OffsetZ properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtranslatetransform3d
		// HRESULT CreateTranslateTransform3D( [out] IDCompositionTranslateTransform3D **translateTransform3D );
		new IDCompositionTranslateTransform3D CreateTranslateTransform3D();

		/// <summary>Creates a 3D scale transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionScaleTransform3D</c>**</b></para>
		///   <para>The new 3D scale transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 3D scale transform object has a static value of 1.0 for the ScaleX, ScaleY, and ScaleZ properties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createscaletransform3d
		// HRESULT CreateScaleTransform3D( [out] IDCompositionScaleTransform3D **scaleTransform3D );
		new IDCompositionScaleTransform3D CreateScaleTransform3D();

		/// <summary>Creates a 3D rotation transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionRotateTransform3D</c>**</b></para>
		///   <para>The new 3D rotation transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A new 3D rotation transform object has a default static value of zero for the Angle, CenterX, CenterY, CenterZ, AxisX, and AxisY properties, and a default static value of 1.0 for the AxisZ property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createrotatetransform3d
		// HRESULT CreateRotateTransform3D( [out] IDCompositionRotateTransform3D **rotateTransform3D );
		new IDCompositionRotateTransform3D CreateRotateTransform3D();

		/// <summary>Creates a 3D 4-by-4 matrix transform object.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionMatrixTransform3D</c>**</b></para>
		///   <para>The new 3D matrix transform object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>The new 3D matrix transform has the identity matrix as its value. The identity matrix is the 4-by-4 matrix with ones on the main diagonal and zeros elsewhere, as shown in the following illustration.</para>
		///   <para>When an identity transform is applied to an object, it does not change the position, shape, or size of the object. It is similar to the way that multiplying a number by one does not change the number. Any transform other than the identity transform will modify the position, shape, and/or size of objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-creatematrixtransform3d
		// HRESULT CreateMatrixTransform3D( [out] IDCompositionMatrixTransform3D **matrixTransform3D );
		new IDCompositionMatrixTransform3D CreateMatrixTransform3D();

		/// <summary>Creates a 3D transform group object that holds an array of 3D transform objects.</summary>
		/// <param name="transforms3D">
		///   <para>Type: <b><c>IDCompositionTransform3D</c>**</b></para>
		///   <para>An array of 3D transform objects that make up this transform group.</para>
		/// </param>
		/// <param name="elements">
		///   <para>Type: <b><c>UINT</c></b></para>
		///   <para>The number of elements in the <i>transforms</i> array.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTransform3D</c>**</b></para>
		///   <para>The new 3D transform group object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>The array entries in a 3D transform group cannot be changed. However, each transform in the array can be modified through its own property setting methods. If a transform in the array is modified, the change is reflected in the computed matrix of the transform group.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createtransform3dgroup
		// HRESULT CreateTransform3DGroup( [in] IDCompositionTransform3D **transforms3D, [in] UINT elements, [out] IDCompositionTransform3D **transform3DGroup );
		new IDCompositionTransform3D CreateTransform3DGroup([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.Interface)] IDCompositionTransform3D[] transforms3D, uint elements);

		/// <summary>Creates an object that represents multiple effects to be applied to a visual subtree.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionEffectGroup</c>**</b></para>
		///   <para>The new effect group object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>An effect group enables an application to apply multiple effects to a single visual subtree.</para>
		///   <para>A new effect group has a default opacity value of 1.0 and no 3D transformations.</para>
		///   <para>To set the opacity and transform values, use the corresponding methods on the <c>IDCompositionEffectGroup</c> that was created.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createeffectgroup
		// HRESULT CreateEffectGroup( [out] IDCompositionEffectGroup **effectGroup );
		new IDCompositionEffectGroup CreateEffectGroup();

		/// <summary>Creates a clip object that can be used to restrict the rendering of a visual subtree to a rectangular area.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionRectangleClip</c>**</b></para>
		///   <para>The new clip object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>A newly created clip object has a value of -2^21 for the left and top properties, and a value of 2^21 for the right and bottom properties, effectively making it a no-op clip object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createrectangleclip
		// HRESULT CreateRectangleClip( [out] IDCompositionRectangleClip **clip );
		new IDCompositionRectangleClip CreateRectangleClip();

		/// <summary>Creates an animation object that is used to animate one or more scalar properties of one or more Microsoft DirectComposition objects.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionAnimation</c>**</b></para>
		///   <para>The new animation object. This parameter must not be NULL.</para>
		/// </returns>
		/// <remarks>
		///   <para>A number of DirectComposition object properties can have an animation object as the value of the property. When a property has an animation object as its value, DirectComposition redraws the visual at the refresh rate to reflect the changing value of the property that is being animated.</para>
		///   <para>A newly created animation object does not have any animation segments associated with it. An application must use the methods of the <c>IDCompositionAnimation</c> interface to build an animation function before setting the animation object as the property of another DirectComposition object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice2-createanimation
		// HRESULT CreateAnimation( [out] IDCompositionAnimation **animation );
		new IDCompositionAnimation CreateAnimation();

		/// <summary>Creates an instance of <c>IDCompositionGaussianBlurEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionGaussianBlurEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionGaussianBlurEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-creategaussianblureffect
		// HRESULT CreateGaussianBlurEffect( [out] IDCompositionGaussianBlurEffect **gaussianBlurEffect );
		new IDCompositionGaussianBlurEffect CreateGaussianBlurEffect();

		/// <summary>Creates an instance of <c>IDCompositionBrightnessEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionBrightnessEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionBrightnessEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createbrightnesseffect
		// HRESULT CreateBrightnessEffect( [out] IDCompositionBrightnessEffect **brightnessEffect );
		new IDCompositionBrightnessEffect CreateBrightnessEffect();

		/// <summary>Creates an instance of <c>IDCompositionColorMatrixEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionColorMatrixEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionColorMatrixEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createcolormatrixeffect
		// HRESULT CreateColorMatrixEffect( [out] IDCompositionColorMatrixEffect **colorMatrixEffect );
		new IDCompositionColorMatrixEffect CreateColorMatrixEffect();

		/// <summary>Creates an instance of <c>IDCompositionShadowEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionShadowEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionShadowEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createshadoweffect
		// HRESULT CreateShadowEffect( [out] IDCompositionShadowEffect **shadowEffect );
		new IDCompositionShadowEffect CreateShadowEffect();

		/// <summary>Creates an instance of <c>IDCompositionHueRotationEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionHueRotationEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionHueRotationEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createhuerotationeffect
		// HRESULT CreateHueRotationEffect( [out] IDCompositionHueRotationEffect **hueRotationEffect );
		new IDCompositionHueRotationEffect CreateHueRotationEffect();

		/// <summary>Creates an instance of <c>IDCompositionSaturationEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionSaturationEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionSaturationEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createsaturationeffect
		// HRESULT CreateSaturationEffect( [out] IDCompositionSaturationEffect **saturationEffect );
		new IDCompositionSaturationEffect CreateSaturationEffect();

		/// <summary>Creates an instance of <c>IDCompositionTurbulenceEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTurbulenceEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionTurbulenceEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createturbulenceeffect
		// HRESULT CreateTurbulenceEffect( [out] IDCompositionTurbulenceEffect **turbulenceEffect );
		new IDCompositionTurbulenceEffect CreateTurbulenceEffect();

		/// <summary>Creates an instance of <c>IDCompositionLinearTransferEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionLinearTransferEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionLinearTransferEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createlineartransfereffect
		// HRESULT CreateLinearTransferEffect( [out] IDCompositionLinearTransferEffect **linearTransferEffect );
		new IDCompositionLinearTransferEffect CreateLinearTransferEffect();

		/// <summary>Creates an instance of <c>IDCompositionTableTransferEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionTableTransferEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionTableTransferEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createtabletransfereffect
		// HRESULT CreateTableTransferEffect( [out] IDCompositionTableTransferEffect **tableTransferEffect );
		new IDCompositionTableTransferEffect CreateTableTransferEffect();

		/// <summary>Creates an instance of <c>IDCompositionCompositeEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionCompositeEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionCompositeEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createcompositeeffect
		// HRESULT CreateCompositeEffect( [out] IDCompositionCompositeEffect **compositeEffect );
		new IDCompositionCompositeEffect CreateCompositeEffect();

		/// <summary>Creates an instance of <c>IDCompositionBlendEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionBlendEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionBlendEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createblendeffect
		// HRESULT CreateBlendEffect( [out] IDCompositionBlendEffect **blendEffect );
		new IDCompositionBlendEffect CreateBlendEffect();

		/// <summary>Creates an instance of <c>IDCompositionArithmeticCompositeEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionArithmeticCompositeEffect</c>**</b></para>
		///   <para>Receives the created instance of <c>IDCompositionArithmeticCompositeEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createarithmeticcompositeeffect
		// HRESULT CreateArithmeticCompositeEffect( [out] IDCompositionArithmeticCompositeEffect **arithmeticCompositeEffect );
		new IDCompositionArithmeticCompositeEffect CreateArithmeticCompositeEffect();

		/// <summary>Creates an instance of <c>IDCompositionAffineTransform2DEffect</c>.</summary>
		/// <returns>
		///   <para>Type: <b><c>IDCompositionAffineTransform2DEffect</c>**</b></para>
		///   <para>Recieves the created instance of <c>IDCompositionAffineTransform2DEffect</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice3-createaffinetransform2deffect
		// HRESULT CreateAffineTransform2DEffect( [out] IDCompositionAffineTransform2DEffect **affineTransform2dEffect );
		new IDCompositionAffineTransform2DEffect CreateAffineTransform2DEffect();

		/// <summary>Creates an instance of <c>IDCompositionAffineTransform3DEffect</c>.</summary>
		[return: MarshalAs(UnmanagedType.Bool)]
		bool CheckCompositionTextureSupport([In, MarshalAs(UnmanagedType.IUnknown)] object renderingDevice);

		/// <summary>
		/// <para>Important</para>
		/// <para>Some information relates to a prerelease product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.</para>
		/// </summary>
		/// <param name="d3dTexture">
		/// <para>Type: _In_ <b><c>IUnknown</c>*</b></para>
		/// <para>A Direct3D texture (an <c>ID3D11Texture2D</c> resource) to create a composition texture for.</para>
		/// </param>
		/// <param name="compositionTexture">
		/// <para>Type: _In_ <b><c>IDCompositionTexture</c>**</b></para>
		/// <para>Retrieves the composition texture object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c>HRESULT</c> error code. If you try to create a composition texture for a Direct3D texture that's backed by a Direct3D device that doesn't support composition textures, then <b>CreateCompositionTexture</b> returns <b>E_INVALIDARG</b>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dcomp/nf-dcomp-idcompositiondevice4-createcompositiontexture
		// HRESULT CreateCompositionTexture( IUnknown *d3dTexture, IDCompositionTexture **compositionTexture );
		void CreateCompositionTexture([In, MarshalAs(UnmanagedType.IUnknown)] object d3dTexture, out IDCompositionTexture? compositionTexture);
	}
}