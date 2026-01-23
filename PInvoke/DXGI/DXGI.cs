global using D3DCOLOR = Vanara.PInvoke.COLORREF;
global using D3DRECT = Vanara.PInvoke.RECT;
global using DXGI_MATRIX_3X2_F = Vanara.PInvoke.DXGI.D2D_MATRIX_3X2_F;
#if !NET45
using CommunityToolkit.HighPerformance;
#endif

namespace Vanara.PInvoke;

/// <summary>
/// The Microsoft DirectX Graphics Infrastructure (DXGI) manages low-level tasks that can be independent of the Direct3D graphics runtime.
/// DXGI provides a common framework for several versions of Direct3D.
/// </summary>
public static partial class DXGI
{
	/// <summary>The resource is unused and can be evicted as soon as another resource requires the memory that the resource occupies.</summary>
	public const uint DXGI_RESOURCE_PRIORITY_MINIMUM = 0x28000000;

	/// <summary>
	/// The eviction priority of the resource is low. The placement of the resource is not critical, and minimal work is performed to find a
	/// location for the resource. For example, if a GPU can render with a vertex buffer from either local or non-local memory with little
	/// difference in performance, that vertex buffer is low priority. Other more critical resources (for example, a render target or
	/// texture) can then occupy the faster memory.
	/// </summary>
	public const uint DXGI_RESOURCE_PRIORITY_LOW = 0x50000000;

	/// <summary>
	/// The eviction priority of the resource is normal. The placement of the resource is important, but not critical, for performance. The
	/// resource is placed in its preferred location instead of a low-priority resource.
	/// </summary>
	public const uint DXGI_RESOURCE_PRIORITY_NORMAL = 0x78000000;

	/// <summary>
	/// The eviction priority of the resource is high. The resource is placed in its preferred location instead of a low-priority or
	/// normal-priority resource.
	/// </summary>
	public const uint DXGI_RESOURCE_PRIORITY_HIGH = 0xa0000000;

	/// <summary>The resource is evicted from memory only if there is no other way of resolving the memory requirement.</summary>
	public const uint DXGI_RESOURCE_PRIORITY_MAXIMUM = 0xc8000000;

	/// <summary>Identifies the type of DXGI adapter.</summary>
	/// <remarks>
	/// The <c>DXGI_ADAPTER_FLAG</c> enumerated type is used by the <c>Flags</c> member of the DXGI_ADAPTER_DESC1 or DXGI_ADAPTER_DESC2
	/// structure to identify the type of DXGI adapter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ne-dxgi-dxgi_adapter_flag typedef enum DXGI_ADAPTER_FLAG {
	// DXGI_ADAPTER_FLAG_NONE, DXGI_ADAPTER_FLAG_REMOTE, DXGI_ADAPTER_FLAG_SOFTWARE, DXGI_ADAPTER_FLAG_FORCE_DWORD } ;
	[PInvokeData("dxgi.h", MSDNShortId = "9c3c78cd-4f4e-4753-969a-54ea63583be1"), Flags]
	public enum DXGI_ADAPTER_FLAG : uint
	{
		/// <summary>Specifies no flags.</summary>
		DXGI_ADAPTER_FLAG_NONE = 0,

		/// <summary>Value always set to 0. This flag is reserved.</summary>
		DXGI_ADAPTER_FLAG_REMOTE = 1,

		/// <summary>
		/// Specifies a software adapter. For more info about this flag, see new info in Windows 8 about enumerating adapters.Direct3D
		/// 11: This enumeration value is supported starting with Windows 8.
		/// </summary>
		DXGI_ADAPTER_FLAG_SOFTWARE = 2,

		/// <summary>
		/// Forces this enumeration to compile to 32 bits in size. Without this value, some compilers would allow this enumeration to
		/// compile to a size other than 32 bits. This value is not used.
		/// </summary>
		DXGI_ADAPTER_FLAG_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>
	/// <para>Options for enumerating display modes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>DXGI_ENUM_MODES_INTERLACED 1UL</term>
	/// <term>Include interlaced modes.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_ENUM_MODES_SCALING 2UL</term>
	/// <term>Include stretched-scaling modes.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_ENUM_MODES_STEREO 4UL</term>
	/// <term>Include stereo modes. Direct3D 11: This enumeration value is supported starting with Windows 8.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_ENUM_MODES_DISABLED_STEREO 8UL</term>
	/// <term>
	/// Include stereo modes that are hidden because the user has disabled stereo. Control panel applications can use this option to show
	/// stereo capabilities that have been disabled as part of a user interface that enables and disables stereo. Direct3D 11: This
	/// enumeration value is supported starting with Windows 8.
	/// </term>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// <para>These flag options are used in <c>IDXGIOutput::GetDisplayModeList</c> to enumerate display modes.</para>
	/// <para>These flag options are also used in <c>IDXGIOutput1::GetDisplayModeList1</c> to enumerate display modes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-enum-modes
	[PInvokeData("dxgi.h", MSDNShortId = "7e0f5629-f8e2-478b-b8eb-00780a3dcf1f"), Flags]
	public enum DXGI_ENUM_MODES : uint
	{
		/// <summary>Include interlaced modes.</summary>
		DXGI_ENUM_MODES_INTERLACED = 1,

		/// <summary>Include stretched-scaling modes.</summary>
		DXGI_ENUM_MODES_SCALING = 2,

		/// <summary>
		/// Include stereo modes.
		/// <para>Direct3D 11: This enumeration value is supported starting with Windows 8.</para>
		/// </summary>
		DXGI_ENUM_MODES_STEREO = 4,

		/// <summary>
		/// Include stereo modes that are hidden because the user has disabled stereo. Control panel applications can use this option to
		/// show stereo capabilities that have been disabled as part of a user interface that enables and disables stereo.
		/// <para>Direct3D 11: This enumeration value is supported starting with Windows 8.</para>
		/// </summary>
		DXGI_ENUM_MODES_DISABLED_STEREO = 8,
	}

	/// <summary>CPU read-write flags.</summary>
	[PInvokeData("dxgi.h"), Flags]
	public enum DXGI_MAP : uint
	{
		/// <summary>Allow CPU read access.</summary>
		DXGI_MAP_READ = 0x1,

		/// <summary>Allow CPU write access.</summary>
		DXGI_MAP_WRITE = 0x2,

		/// <summary>Discard the previous contents of a resource when it is mapped.</summary>
		DXGI_MAP_DISCARD = 0x4
	}

	/// <summary>Flags that indicate how the back buffers should be rotated to fit the physical rotation of a monitor.</summary>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173065(v=vs.85) typedef enum DXGI_MODE_ROTATION {
	// DXGI_MODE_ROTATION_UNSPECIFIED = 0, DXGI_MODE_ROTATION_IDENTITY = 1, DXGI_MODE_ROTATION_ROTATE90 = 2, DXGI_MODE_ROTATION_ROTATE180 =
	// 3, DXGI_MODE_ROTATION_ROTATE270 = 4 } DXGI_MODE_ROTATION;
	[PInvokeData("DXGI.h")]
	public enum DXGI_MODE_ROTATION
	{
		/// <summary>Unspecified rotation.</summary>
		DXGI_MODE_ROTATION_UNSPECIFIED = 0,

		/// <summary>Specifies no rotation.</summary>
		DXGI_MODE_ROTATION_IDENTITY,

		/// <summary>Specifies 90 degrees of rotation.</summary>
		DXGI_MODE_ROTATION_ROTATE90,

		/// <summary>Specifies 180 degrees of rotation.</summary>
		DXGI_MODE_ROTATION_ROTATE180,

		/// <summary>Specifies 270 degrees of rotation.</summary>
		DXGI_MODE_ROTATION_ROTATE270,
	}

	/// <summary>Flags indicating how an image is stretched to fit a given monitor's resolution.</summary>
	/// <remarks>
	/// <para>
	/// Selecting the CENTERED or STRETCHED modes can result in a mode change even if you specify the native resolution of the display in
	/// the DXGI_MODE_DESC. If you know the native resolution of the display and want to make sure that you do not initiate a mode change
	/// when transitioning a swap chain to full screen (either via ALT+ENTER or <c>IDXGISwapChain::SetFullscreenState</c>), you should use UNSPECIFIED.
	/// </para>
	/// <para>This enum is used by the <c>DXGI_MODE_DESC1</c> and <c>DXGI_SWAP_CHAIN_FULLSCREEN_DESC</c> structures.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173066(v=vs.85) typedef enum DXGI_MODE_SCALING {
	// DXGI_MODE_SCALING_UNSPECIFIED = 0, DXGI_MODE_SCALING_CENTERED = 1, DXGI_MODE_SCALING_STRETCHED = 2 } DXGI_MODE_SCALING;
	[PInvokeData("DXGI.h")]
	public enum DXGI_MODE_SCALING
	{
		/// <summary>Unspecified scaling.</summary>
		DXGI_MODE_SCALING_UNSPECIFIED = 0,

		/// <summary>
		/// Specifies no scaling. The image is centered on the display. This flag is typically used for a fixed-dot-pitch display (such as
		/// an LED display).
		/// </summary>
		DXGI_MODE_SCALING_CENTERED,

		/// <summary>Specifies stretched scaling.</summary>
		DXGI_MODE_SCALING_STRETCHED,
	}

	/// <summary>Flags indicating the method the raster uses to create an image on a surface.</summary>
	/// <remarks>This enum is used by the <c>DXGI_MODE_DESC1</c> and <c>DXGI_SWAP_CHAIN_FULLSCREEN_DESC</c> structures.</remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173067(v=vs.85) typedef enum DXGI_MODE_SCANLINE_ORDER {
	// DXGI_MODE_SCANLINE_ORDER_UNSPECIFIED = 0, DXGI_MODE_SCANLINE_ORDER_PROGRESSIVE = 1, DXGI_MODE_SCANLINE_ORDER_UPPER_FIELD_FIRST
	// = 2, DXGI_MODE_SCANLINE_ORDER_LOWER_FIELD_FIRST = 3 } DXGI_MODE_SCANLINE_ORDER;
	[PInvokeData("DXGI.h")]
	public enum DXGI_MODE_SCANLINE_ORDER
	{
		/// <summary>Scanline order is unspecified.</summary>
		DXGI_MODE_SCANLINE_ORDER_UNSPECIFIED = 0,

		/// <summary>The image is created from the first scanline to the last without skipping any.</summary>
		DXGI_MODE_SCANLINE_ORDER_PROGRESSIVE,

		/// <summary>The image is created beginning with the upper field.</summary>
		DXGI_MODE_SCANLINE_ORDER_UPPER_FIELD_FIRST,

		/// <summary>The image is created beginning with the lower field.</summary>
		DXGI_MODE_SCANLINE_ORDER_LOWER_FIELD_FIRST,
	}

	/// <summary>Flags for <see cref="IDXGIFactory.MakeWindowAssociation"/></summary>
	[PInvokeData("dxgi.h"), Flags]
	public enum DXGI_MWA
	{
		/// <summary>Prevent DXGI from monitoring an applications message queue; this makes DXGI unable to respond to mode changes.</summary>
		DXGI_MWA_NO_WINDOW_CHANGES = 1 << 0,

		/// <summary>Prevent DXGI from responding to an alt-enter sequence.</summary>
		DXGI_MWA_NO_ALT_ENTER = 1 << 1,

		/// <summary>Prevent DXGI from responding to a print-screen key.</summary>
		DXGI_MWA_NO_PRINT_SCREEN = 1 << 2,
	}

	/// <summary>
	/// <para>The <c>DXGI_PRESENT</c> constants specify options for presenting frames to the output.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Present a frame from each buffer (starting with the current buffer) to the output.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_DO_NOT_SEQUENCE 0x00000002UL</term>
	/// <term>
	/// Present a frame from the current buffer to the output. Use this flag so that the presentation can use vertical-blank synchronization
	/// instead of sequencing buffers in the chain in the usual manner.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_TEST 0x00000001UL</term>
	/// <term>
	/// Do not present the frame to the output. The status of the swap chain will be tested and appropriate errors returned.
	/// DXGI_PRESENT_TEST is intended for use only when switching from the idle state; do not use it to determine when to switch to the idle
	/// state because doing so can leave the swap chain unable to exit full-screen mode.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_RESTART 0x00000004UL</term>
	/// <term>Specifies that the runtime will discard outstanding queued presents.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_DO_NOT_WAIT 0x00000008UL</term>
	/// <term>
	/// Specifies that the runtime will fail the presentation (that is, fail a call to IDXGISwapChain1::Present1) with the
	/// DXGI_ERROR_WAS_STILL_DRAWING error code if the calling thread is blocked; the runtime returns DXGI_ERROR_WAS_STILL_DRAWING instead
	/// of sleeping until the dependency is resolved. Direct3D 11: This enumeration value is supported starting with Windows 8.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_RESTRICT_TO_OUTPUT 0x00000010UL</term>
	/// <term>
	/// Indicates that presentation content will be shown only on the particular output. The content will not be visible on other outputs.
	/// For example, if the user tries to relocate video content on another output, the video content will not be visible. Direct3D 11: This
	/// enumeration value is supported starting with Windows 8.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_STEREO_PREFER_RIGHT 0x00000020UL</term>
	/// <term>
	/// Indicates that if the stereo present must be reduced to mono, right-eye viewing is used rather than left-eye viewing. Direct3D
	/// 11: This enumeration value is supported starting with Windows 8.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_STEREO_TEMPORARY_MONO 0x00000040UL</term>
	/// <term>
	/// Indicates that the presentation should use the left buffer as a mono buffer. An application calls the
	/// IDXGISwapChain1::IsTemporaryMonoSupported method to determine whether a swap chain supports "temporary mono". Direct3D 11: This
	/// enumeration value is supported starting with Windows 8.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_USE_DURATION 0x00000100UL</term>
	/// <term>This flag must be set by media apps that are currently using a custom present duration (custom refresh rate). See IDXGISwapChainMedia.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_PRESENT_ALLOW_TEARING 0x00000200UL</term>
	/// <term>
	/// Allowing tearing is a requirement of variable refresh rate displays. The conditions for using DXGI_PRESENT_ALLOW_TEARING during
	/// Present are as follows: Calling Present (or Present1) with this flag and not meeting the conditions above will result in a
	/// DXGI_ERROR_INVALID_CALL error being returned to the calling application.
	/// </term>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Presentation options are supplied during the <c>IDXGISwapChain::Present</c> or <c>IDXGISwapChain1::Present1</c> call. The buffers
	/// are specified in the swap chain description (see <c>DXGI_SWAP_CHAIN_DESC</c> or <c>DXGI_SWAP_CHAIN_DESC1</c>).
	/// </para>
	/// <para>
	/// DXGI_PRESENT_RESTART is valid only for flip-model swap chains and full screen. Applications can use DXGI_PRESENT_RESTART to recover
	/// from glitches in playback, as well as to discard previously queued presentations. Discarding previously queued presentations is
	/// useful if those queued presentations are windowed scenarios. In particular, the previously queued presentation might have assumed
	/// that the window is an old size (that is, a resize operation occurred after submission).
	/// </para>
	/// <para>
	/// DXGI_PRESENT_RESTRICT_TO_OUTPUT is valid only for swap chains that specified a particular output to restrict content to when those
	/// swap chains were created ( <c>IDXGIFactory2::CreateSwapChainForHwnd</c>). If there is no output to restrict to, the flag is invalid.
	/// </para>
	/// <para>
	/// DXGI_PRESENT_STEREO_PREFER_RIGHT indicates that if the stereo present must be reduced to mono the right eye should be used rather
	/// than the left (default) eye. You can use this flag if one side is higher quality (for example, if the stereo pair is synthesized
	/// from a standard image.)
	/// </para>
	/// <para>
	/// DXGI_PRESENT_STEREO_TEMPORARY_MONO indicates that the present should use the left buffer as a mono buffer. You can use this flag to
	/// avoid updating the right buffer when an application temporarily has no stereo content. You should use this flag whenever possible
	/// because it enables significant optimization by the operating system and under some circumstances it can avoid visible mode change artifacts.
	/// </para>
	/// <para>
	/// You should use the DXGI_PRESENT_STEREO_TEMPORARY_MONO flag in preference to switching to a mono swap chain for most applications
	/// that you anticipate will use stereo again. You need to balance the use of this flag in applications that are extremely long running
	/// or that rarely display stereo against the disadvantage of unused memory.
	/// </para>
	/// <para>
	/// The DXGI_PRESENT_STEREO_PREFER_RIGHT and DXGI_PRESENT_STEREO_TEMPORARY_MONO flags apply only to stereo swap chains. If you use them
	/// when you present mono swap chains, an invalid operation occurs.
	/// </para>
	/// <para>
	/// If you use the DXGI_PRESENT_STEREO_TEMPORARY_MONO flag when you present a stereo swap chain that does not support temporary mono, an
	/// error occurs, the swap chain does not display, and the presentation returns DXGI_ERROR_INVALID_CALL.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-present
	[PInvokeData("dxgi.h", MSDNShortId = "1ddf8643-ea3e-4c9f-8439-c245942f7333"), Flags]
	public enum DXGI_PRESENT
	{
		/// <summary>
		/// Do not present the frame to the output. The status of the swap chain will be tested and appropriate errors returned.
		/// DXGI_PRESENT_TEST is intended for use only when switching from the idle state; do not use it to determine when to switch to the
		/// idle state because doing so can leave the swap chain unable to exit full-screen mode.
		/// </summary>
		DXGI_PRESENT_TEST = 0x00000001,

		/// <summary>
		/// Present a frame from the current buffer to the output. Use this flag so that the presentation can use vertical-blank
		/// synchronization instead of sequencing buffers in the chain in the usual manner.
		/// </summary>
		DXGI_PRESENT_DO_NOT_SEQUENCE = 0x00000002,

		/// <summary>Specifies that the runtime will discard outstanding queued presents.</summary>
		DXGI_PRESENT_RESTART = 0x00000004,

		/// <summary>
		/// Specifies that the runtime will fail the presentation (that is, fail a call to IDXGISwapChain1::Present1) with the
		/// DXGI_ERROR_WAS_STILL_DRAWING error code if the calling thread is blocked; the runtime returns DXGI_ERROR_WAS_STILL_DRAWING
		/// instead of sleeping until the dependency is resolved. Direct3D 11: This enumeration value is supported starting with Windows 8.
		/// </summary>
		DXGI_PRESENT_DO_NOT_WAIT = 0x00000008,

		/// <summary>
		/// Indicates that if the stereo present must be reduced to mono, right-eye viewing is used rather than left-eye viewing. Direct3D
		/// 11: This enumeration value is supported starting with Windows 8.
		/// </summary>
		DXGI_PRESENT_STEREO_PREFER_RIGHT = 0x00000010,

		/// <summary>
		/// Indicates that the presentation should use the left buffer as a mono buffer. An application calls the
		/// IDXGISwapChain1::IsTemporaryMonoSupported method to determine whether a swap chain supports "temporary mono". Direct3D 11: This
		/// enumeration value is supported starting with Windows 8.
		/// </summary>
		DXGI_PRESENT_STEREO_TEMPORARY_MONO = 0x00000020,

		/// <summary>
		/// Indicates that presentation content will be shown only on the particular output. The content will not be visible on other
		/// outputs. For example, if the user tries to relocate video content on another output, the video content will not be visible.
		/// Direct3D 11: This enumeration value is supported starting with Windows 8.
		/// </summary>
		DXGI_PRESENT_RESTRICT_TO_OUTPUT = 0x00000040,

		/// <summary>
		/// This flag must be set by media apps that are currently using a custom present duration (custom refresh rate). See IDXGISwapChainMedia.
		/// </summary>
		DXGI_PRESENT_USE_DURATION = 0x00000100,

		/// <summary>
		/// Allowing tearing is a requirement of variable refresh rate displays. The conditions for using DXGI_PRESENT_ALLOW_TEARING during
		/// Present are as follows: Calling Present (or Present1) with this flag and not meeting the conditions above will result in a
		/// DXGI_ERROR_INVALID_CALL error being returned to the calling application.
		/// </summary>
		DXGI_PRESENT_ALLOW_TEARING = 0x00000200,
	}

	/// <summary>Flags indicating the memory location of a resource.</summary>
	/// <remarks>This enum is used by QueryResourceResidency.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ne-dxgi-dxgi_residency typedef enum DXGI_RESIDENCY {
	// DXGI_RESIDENCY_FULLY_RESIDENT, DXGI_RESIDENCY_RESIDENT_IN_SHARED_MEMORY, DXGI_RESIDENCY_EVICTED_TO_DISK } ;
	[PInvokeData("dxgi.h")]
	public enum DXGI_RESIDENCY
	{
		/// <summary>The resource is located in video memory.</summary>
		DXGI_RESIDENCY_FULLY_RESIDENT = 1,

		/// <summary>At least some of the resource is located in CPU memory.</summary>
		DXGI_RESIDENCY_RESIDENT_IN_SHARED_MEMORY,

		/// <summary>At least some of the resource has been paged out to the hard drive.</summary>
		DXGI_RESIDENCY_EVICTED_TO_DISK,
	}

	/// <summary>Shared resource constants.</summary>
	[PInvokeData("dxgi.h"), Flags]
	public enum DXGI_SHARED_RESOURCE_RW : uint
	{
		/// <summary>Shared resource is read-only.</summary>
		DXGI_SHARED_RESOURCE_READ = 0x80000000,

		/// <summary>Shared resource is writeable.</summary>
		DXGI_SHARED_RESOURCE_WRITE = 1,
	}

	/// <summary>Status codes that can be returned by DXGI functions.</summary>
	/// <remarks>
	/// <para>The <c>HRESULT</c> value for each <c>DXGI_STATUS</c> value is determined from this macro that is defined in DXGItype.h:</para>
	/// <para>For example, <c>DXGI_STATUS_OCCLUDED</c> is defined as <c>0x087A0001</c>:</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-status
	[PInvokeData("DXGI.h")]
	public enum DXGI_STATUS
	{
		/// <summary>
		/// The window content is not visible. When receiving this status, an application can stop rendering and use DXGI_PRESENT_TEST to
		/// determine when to resume rendering. You will not receive DXGI_STATUS_OCCLUDED if you're using a flip model swap chain.
		/// </summary>
		DXGI_STATUS_OCCLUDED = 0x087A0001,

		/// <summary>
		/// The desktop display mode has been changed, there might be color conversion/stretching. The application should call
		/// IDXGISwapChain::ResizeBuffers to match the new display mode.
		/// </summary>
		DXGI_STATUS_MODE_CHANGED = 0x087A0007,

		/// <summary>
		/// IDXGISwapChain::ResizeTarget and IDXGISwapChain::SetFullscreenState will return DXGI_STATUS_MODE_CHANGE_IN_PROGRESS if a
		/// fullscreen/windowed mode transition is occurring when either API is called.
		/// </summary>
		DXGI_STATUS_MODE_CHANGE_IN_PROGRESS = 0x087A0008,
	}

	/// <summary>Converts a <see cref="DXGI_STATUS"/> to its corresponding <see cref="HRESULT"/> value.</summary>
	/// <param name="code">The status.</param>
	/// <returns>The HRESULT value.</returns>
	public static HRESULT ToHRESULT(this DXGI_STATUS code) => HRESULT.Make(true, 0x87a /*_FACDXGI*/, (uint)code);

	/// <summary>Options for swap-chain behavior.</summary>
	/// <remarks>
	/// <para>This enumeration is used by the DXGI_SWAP_CHAIN_DESC structure and the IDXGISwapChain::ResizeTarget method.</para>
	/// <para>This enumeration is also used by the DXGI_SWAP_CHAIN_DESC1 structure.</para>
	/// <para>
	/// You don't need to set <c>DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY</c> for swap chains that you create in full-screen mode with the
	/// IDXGIFactory::CreateSwapChain method because those swap chains already behave as if <c>DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY</c> is set.
	/// That is, presented content is not accessible by remote access or through the desktop duplication APIs.
	/// </para>
	/// <para>
	/// Swap chains that you create with the IDXGIFactory2::CreateSwapChainForHwnd, IDXGIFactory2::CreateSwapChainForCoreWindow, and
	/// IDXGIFactory2::CreateSwapChainForComposition methods are not protected if <c>DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY</c> is not set and
	/// are protected if <c>DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY</c> is set. When swap chains are protected, screen scraping is prevented and,
	/// in full-screen mode, presented content is not accessible through the desktop duplication APIs.
	/// </para>
	/// <para>
	/// When you call IDXGISwapChain::ResizeBuffers to change the swap chain's back buffer, you can reset or change all
	/// <c>DXGI_SWAP_CHAIN_FLAG</c> flags.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ne-dxgi-dxgi_swap_chain_flag typedef enum DXGI_SWAP_CHAIN_FLAG {
	// DXGI_SWAP_CHAIN_FLAG_NONPREROTATED, DXGI_SWAP_CHAIN_FLAG_ALLOW_MODE_SWITCH, DXGI_SWAP_CHAIN_FLAG_GDI_COMPATIBLE,
	// DXGI_SWAP_CHAIN_FLAG_RESTRICTED_CONTENT, DXGI_SWAP_CHAIN_FLAG_RESTRICT_SHARED_RESOURCE_DRIVER, DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY,
	// DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT, DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER, DXGI_SWAP_CHAIN_FLAG_FULLSCREEN_VIDEO,
	// DXGI_SWAP_CHAIN_FLAG_YUV_VIDEO, DXGI_SWAP_CHAIN_FLAG_HW_PROTECTED, DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING,
	// DXGI_SWAP_CHAIN_FLAG_RESTRICTED_TO_ALL_HOLOGRAPHIC_DISPLAYS } ;
	[PInvokeData("dxgi.h"), Flags]
	public enum DXGI_SWAP_CHAIN_FLAG
	{
		/// <summary>
		/// Set this flag to turn off automatic image rotation; that is, do not perform a rotation when transferring the contents of the
		/// front buffer to the monitor. Use this flag to avoid a bandwidth penalty when an application expects to handle rotation. This
		/// option is valid only during full-screen mode.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_NONPREROTATED = 1,

		/// <summary>
		/// Set this flag to enable an application to switch modes by calling IDXGISwapChain::ResizeTarget. When switching from windowed to
		/// full-screen mode, the display mode (or monitor resolution) will be changed to match the dimensions of the application window.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_ALLOW_MODE_SWITCH = 2,

		/// <summary>
		/// Set this flag to enable an application to render using GDI on a swap chain or a surface. This will allow the application to call
		/// IDXGISurface1::GetDC on the 0th back buffer or a surface.This flag is not applicable for Direct3D 12.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_GDI_COMPATIBLE = 4,

		/// <summary>
		/// Set this flag to indicate that the swap chain might contain protected content; therefore, the operating system supports the
		/// creation of the swap chain only when driver and hardware protection is used. If the driver and hardware do not support content
		/// protection, the call to create a resource for the swap chain fails.Direct3D 11: This enumeration value is supported starting
		/// with Windows 8.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_RESTRICTED_CONTENT = 8,

		/// <summary>
		/// Set this flag to indicate that shared resources that are created within the swap chain must be protected by using the driver’s
		/// mechanism for restricting access to shared surfaces.Direct3D 11: This enumeration value is supported starting with Windows 8.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_RESTRICT_SHARED_RESOURCE_DRIVER = 16,

		/// <summary>
		/// Set this flag to restrict presented content to the local displays. Therefore, the presented content is not accessible via remote
		/// accessing or through the desktop duplication APIs. This flag supports the window content protection features of Windows.
		/// Applications can use this flag to protect their own onscreen window content from being captured or copied through a specific set
		/// of public operating system features and APIs.If you use this flag with windowed (HWND or IWindow) swap chains where another
		/// process created the HWND, the owner of the HWND must use the SetWindowDisplayAffinity function appropriately in order to allow
		/// calls to IDXGISwapChain::Present or IDXGISwapChain1::Present1 to succeed.Direct3D 11: This enumeration value is supported
		/// starting with Windows 8.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY = 32,

		/// <summary>
		/// Set this flag to create a waitable object you can use to ensure rendering does not begin while a frame is still being presented.
		/// When this flag is used, the swapchain's latency must be set with the IDXGISwapChain2::SetMaximumFrameLatency API instead of
		/// IDXGIDevice1::SetMaximumFrameLatency.Note This enumeration value is supported starting with Windows 8.1.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT = 64,

		/// <summary>
		/// Set this flag to create a swap chain in the foreground layer for multi-plane rendering. This flag can only be used with
		/// CoreWindow swap chains, which are created with CreateSwapChainForCoreWindow. Apps should not create foreground swap chains if
		/// IDXGIOutput2::SupportsOverlays indicates that hardware support for overlays is not available.Note that
		/// IDXGISwapChain::ResizeBuffers cannot be used to add or remove this flag.Note This enumeration value is supported starting with
		/// Windows 8.1.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER = 128,

		/// <summary>
		/// Set this flag to create a swap chain for full-screen video. Note This enumeration value is supported starting with Windows 8.1.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_FULLSCREEN_VIDEO = 256,

		/// <summary>
		/// Set this flag to create a swap chain for YUV video.Note This enumeration value is supported starting with Windows 8.1.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_YUV_VIDEO = 512,

		/// <summary>
		/// Indicates that the swap chain should be created such that all underlying resources can be protected by the hardware. Resource
		/// creation will fail if hardware content protection is not supported.This flag has the following restrictions:Note This
		/// enumeration value is supported starting with Windows 10.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_HW_PROTECTED = 1024,

		/// <summary>
		/// Tearing support is a requirement to enable displays that support variable refresh rates to function properly when the
		/// application presents a swap chain tied to a full screen borderless window. Win32 apps can already achieve tearing in fullscreen
		/// exclusive mode by calling SetFullscreenState(TRUE), but the recommended approach for Win32 developers is to use this tearing
		/// flag instead. This flag requires the use of a DXGI_SWAP_EFFECT_FLIP_* swap effect.To check for hardware support of this feature,
		/// refer to IDXGIFactory5::CheckFeatureSupport. For usage information refer to IDXGISwapChain::Present and the DXGI_PRESENT flags.
		/// </summary>
		DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING = 2048,

		/// <summary/>
		DXGI_SWAP_CHAIN_FLAG_RESTRICTED_TO_ALL_HOLOGRAPHIC_DISPLAYS = 4096,
	}

	/// <summary>Options for handling pixels in a display surface after calling IDXGISwapChain1::Present1.</summary>
	/// <remarks>
	/// <para>This enumeration is used by the DXGI_SWAP_CHAIN_DESC and DXGI_SWAP_CHAIN_DESC1structures.</para>
	/// <para>
	/// To use multisampling with <c>DXGI_SWAP_EFFECT_SEQUENTIAL</c> or <c>DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</c>, you must perform the
	/// multisampling in a separate render target. For example, create a multisampled texture by calling ID3D11Device::CreateTexture2D with
	/// a filled D3D11_TEXTURE2D_DESC structure ( <c>BindFlags</c> member set to D3D11_BIND_RENDER_TARGET and <c>SampleDesc</c> member with
	/// multisampling parameters). Next call ID3D11Device::CreateRenderTargetView to create a render-target view for the texture, and render
	/// your scene into the texture. Finally call ID3D11DeviceContext::ResolveSubresource to resolve the multisampled texture into your
	/// non-multisampled swap chain.
	/// </para>
	/// <para>
	/// The primary difference between presentation models is how back-buffer contents get to the Desktop Window Manager (DWM) for
	/// composition. In the bitblt model, which is used with the <c>DXGI_SWAP_EFFECT_DISCARD</c> and <c>DXGI_SWAP_EFFECT_SEQUENTIAL</c>
	/// values, contents of the back buffer get copied into the redirection surface on each call to IDXGISwapChain1::Present1. In the flip
	/// model, which is used with the <c>DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</c> value, all back buffers are shared with the DWM. Therefore,
	/// the DWM can compose straight from those back buffers without any additional copy operations. In general, the flip model is the more
	/// efficient model. The flip model also provides more features, such as enhanced present statistics.
	/// </para>
	/// <para>
	/// When you call IDXGISwapChain1::Present1 on a flip model swap chain ( <c>DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</c>) with 0 specified in
	/// the SyncInterval parameter, <c>IDXGISwapChain1::Present1</c>'s behavior is the same as the behavior of Direct3D 9Ex's
	/// IDirect3DDevice9Ex::PresentEx with D3DSWAPEFFECT_FLIPEX and D3DPRESENT_FORCEIMMEDIATE. That is, the runtime not only presents the
	/// next frame instead of any previously queued frames, it also terminates any remaining time left on the previously queued frames.
	/// </para>
	/// <para>
	/// Regardless of whether the flip model is more efficient, an application still might choose the bitblt model because the bitblt model
	/// is the only way to mix GDI and DirectX presentation. In the flip model, the application must create the swap chain with
	/// DXGI_SWAP_CHAIN_FLAG_GDI_COMPATIBLE, and then must use GetDC on the back buffer explicitly. After the first successful call to
	/// IDXGISwapChain1::Present1 on a flip-model swap chain, GDI no longer works with the HWND that is associated with that swap chain,
	/// even after the destruction of the swap chain. This restriction even extends to methods like ScrollWindowEx.
	/// </para>
	/// <para>
	/// For more info about the flip-model swap chain and optimizing presentation, see Enhancing presentation with the flip model, dirty
	/// rectangles, and scrolled areas.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// To create a swap chain in UWP, you just need to create a new instance of the DX11 template and look at the implementation of in the
	/// D3D12 samples.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ne-dxgi-dxgi_swap_effect typedef enum DXGI_SWAP_EFFECT {
	// DXGI_SWAP_EFFECT_DISCARD, DXGI_SWAP_EFFECT_SEQUENTIAL, DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL, DXGI_SWAP_EFFECT_FLIP_DISCARD } ;
	[PInvokeData("dxgi.h")]
	public enum DXGI_SWAP_EFFECT
	{
		/// <summary>
		/// Use this flag to specify the bit-block transfer (bitblt) model and to specify that DXGI discard the contents of the back buffer
		/// after you call IDXGISwapChain1::Present1. This flag is valid for a swap chain with more than one back buffer, although,
		/// applications only have read and write access to buffer 0. Use this flag to enable the display driver to select the most
		/// efficient presentation technique for the swap chain.
		/// </summary>
		DXGI_SWAP_EFFECT_DISCARD = 0,

		/// <summary>
		/// Use this flag to specify the bitblt model and to specify that DXGI persist the contents of the back buffer after you call
		/// IDXGISwapChain1::Present1. Use this option to present the contents of the swap chain in order, from the first buffer (buffer
		/// 0) to the last buffer. This flag cannot be used with multisampling.
		/// </summary>
		DXGI_SWAP_EFFECT_SEQUENTIAL = 1,

		/// <summary>
		/// Use this flag to specify the flip presentation model and to specify that DXGI persist the contents of the back buffer after you
		/// call IDXGISwapChain1::Present1. This flag cannot be used with multisampling. Direct3D 11: This enumeration value is supported
		/// starting with Windows 8.
		/// </summary>
		DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL = 3,

		/// <summary>
		/// Use this flag to specify the flip presentation model and to specify that DXGI discard the contents of the back buffer after you
		/// call IDXGISwapChain1::Present1. This flag cannot be used with multisampling and partial presentation. See DXGI 1.4 Improvements.
		/// Direct3D 11: This enumeration value is supported starting with Windows 10.
		/// </summary>
		DXGI_SWAP_EFFECT_FLIP_DISCARD = 4,
	}

	/// <summary>
	/// <para>Flags for surface and resource creation options.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>DXGI_USAGE_BACK_BUFFER 1L &lt;&lt; (2 + 4)</term>
	/// <term>
	/// The surface or resource is used as a back buffer. You don’t need to pass DXGI_USAGE_BACK_BUFFER when you create a swap chain. But
	/// you can determine whether a resource belongs to a swap chain when you call IDXGIResource::GetUsage and get DXGI_USAGE_BACK_BUFFER.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DXGI_USAGE_DISCARD_ON_PRESENT 1L &lt;&lt; (5 + 4)</term>
	/// <term>This flag is for internal use only.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_USAGE_READ_ONLY 1L &lt;&lt; (4 + 4)</term>
	/// <term>Use the surface or resource for reading only.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_USAGE_RENDER_TARGET_OUTPUT 1L &lt;&lt; (1 + 4)</term>
	/// <term>Use the surface or resource as an output render target.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_USAGE_SHADER_INPUT 1L &lt;&lt; (0 + 4)</term>
	/// <term>Use the surface or resource as an input to a shader.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_USAGE_SHARED 1L &lt;&lt; (3 + 4)</term>
	/// <term>Share the surface or resource.</term>
	/// </item>
	/// <item>
	/// <term>DXGI_USAGE_UNORDERED_ACCESS 1L &lt;&lt; (6 + 4)</term>
	/// <term>Use the surface or resource for unordered access.</term>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// <para>Each flag is defined as an unsigned integer.</para>
	/// <para>
	/// These flag options are used in a call to the <c>IDXGIFactory::CreateSwapChain</c>, <c>IDXGIFactory2::CreateSwapChainForHwnd</c>,
	/// <c>IDXGIFactory2::CreateSwapChainForCoreWindow</c>, or <c>IDXGIFactory2::CreateSwapChainForComposition</c> method to describe the
	/// surface usage and CPU access options for the back buffer of a swap chain. You can't use the <c>DXGI_USAGE_SHARED</c>,
	/// <c>DXGI_USAGE_DISCARD_ON_PRESENT</c>, and <c>DXGI_USAGE_READ_ONLY</c> values as input to create a swap chain. However, DXGI can set
	/// <c>DXGI_USAGE_DISCARD_ON_PRESENT</c> and <c>DXGI_USAGE_READ_ONLY</c> for some of the swap chain's back buffers on the application's
	/// behalf. You can call the <c>IDXGIResource::GetUsage</c> method to retrieve the usage of these back buffers. Swap chain's only
	/// support the <c>DXGI_CPU_ACCESS_NONE</c> value in the <c>DXGI_CPU_ACCESS_FIELD</c> part of <c>DXGI_USAGE</c>.
	/// </para>
	/// <para>These flag options are also used by the <c>IDXGIDevice::CreateSurface</c> method.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-usage
	[PInvokeData("", MSDNShortId = "b5026566-89b5-458e-b36d-a55e5f8c10c1"), Flags]
	public enum DXGI_USAGE : uint
	{
		/// <summary/>
		DXGI_CPU_ACCESS_NONE = 0,

		/// <summary/>
		DXGI_CPU_ACCESS_DYNAMIC = 1,

		/// <summary/>
		DXGI_CPU_ACCESS_READ_WRITE = 2,

		/// <summary/>
		DXGI_CPU_ACCESS_SCRATCH = 3,

		/// <summary/>
		DXGI_CPU_ACCESS_FIELD = 15,

		/// <summary>Use the surface or resource as an input to a shader.</summary>
		DXGI_USAGE_SHADER_INPUT = 0x00000010,

		/// <summary>Use the surface or resource as an output render target.</summary>
		DXGI_USAGE_RENDER_TARGET_OUTPUT = 0x00000020,

		/// <summary>
		/// The surface or resource is used as a back buffer. You don’t need to pass DXGI_USAGE_BACK_BUFFER when you create a swap chain.
		/// But you can determine whether a resource belongs to a swap chain when you call IDXGIResource::GetUsage and get DXGI_USAGE_BACK_BUFFER.
		/// </summary>
		DXGI_USAGE_BACK_BUFFER = 0x00000040,

		/// <summary>Share the surface or resource.</summary>
		DXGI_USAGE_SHARED = 0x00000080,

		/// <summary/>
		DXGI_USAGE_READ_ONLY = 0x00000100,

		/// <summary>This flag is for internal use only.</summary>
		DXGI_USAGE_DISCARD_ON_PRESENT = 0x00000200,

		/// <summary>Use the surface or resource for unordered access.</summary>
		DXGI_USAGE_UNORDERED_ACCESS = 0x00000400,
	}

	/// <summary>Creates a DXGI 1.0 factory that you can use to generate other DXGI objects.</summary>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>The globally unique identifier (GUID) of the IDXGIFactory object referenced by the ppFactory parameter.</para>
	/// </param>
	/// <param name="ppFactory">
	/// <para>Type: <c>void**</c></para>
	/// <para>Address of a pointer to an IDXGIFactory object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns <c>S_OK</c> if successful; otherwise, returns one of the following DXGI_ERROR.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use a DXGI factory to generate objects that enumerate adapters, create swap chains, and associate a window with the alt+enter key
	/// sequence for toggling to and from the fullscreen display mode.
	/// </para>
	/// <para>
	/// If the <c>CreateDXGIFactory</c> function succeeds, the reference count on the IDXGIFactory interface is incremented. To avoid a
	/// memory leak, when you finish using the interface, call the IDXGIFactory::Release method to release the interface.
	/// </para>
	/// <para>
	/// <c>Note</c> Do not mix the use of DXGI 1.0 (IDXGIFactory) and DXGI 1.1 (IDXGIFactory1) in an application. Use <c>IDXGIFactory</c> or
	/// <c>IDXGIFactory1</c>, but not both in an application.
	/// </para>
	/// <para>
	/// <c>Note</c><c>CreateDXGIFactory</c> fails if your app's DllMain function calls it. For more info about how DXGI responds from
	/// <c>DllMain</c>, see DXGI Responses from DLLMain.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, all DXGI factories (regardless if they were created with <c>CreateDXGIFactory</c> or
	/// CreateDXGIFactory1) enumerate adapters identically. The enumeration order of adapters, which you retrieve with
	/// IDXGIFactory::EnumAdapters or IDXGIFactory1::EnumAdapters1, is as follows:
	/// </para>
	/// <para>
	/// The <c>CreateDXGIFactory</c> function does not exist for Windows Store apps. Instead, Windows Store apps use the CreateDXGIFactory1 function.
	/// </para>
	/// <para>Examples</para>
	/// <para>Creating a DXGI 1.0 Factory</para>
	/// <para>
	/// The following code example demonstrates how to create a DXGI 1.0 factory. This example uses the __uuidof() intrinsic to obtain the
	/// REFIID, or GUID, of the IDXGIFactory interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-createdxgifactory HRESULT CreateDXGIFactory( REFIID riid, void
	// **ppFactory );
	[DllImport(Lib.DXGI, SetLastError = false, ExactSpelling = true), PInvokeData("dxgi.h")]
	public static extern HRESULT CreateDXGIFactory(in Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppFactory);

	/// <summary>Creates a DXGI 1.0 factory that you can use to generate other DXGI objects.</summary>
	/// <returns>An IDXGIFactory object.</returns>
	/// <remarks>
	/// <para>
	/// Use a DXGI factory to generate objects that enumerate adapters, create swap chains, and associate a window with the alt+enter key
	/// sequence for toggling to and from the fullscreen display mode.
	/// </para>
	/// <para>
	/// If the <c>CreateDXGIFactory</c> function succeeds, the reference count on the IDXGIFactory interface is incremented. To avoid a
	/// memory leak, when you finish using the interface, call the IDXGIFactory::Release method to release the interface.
	/// </para>
	/// <para>
	/// <c>Note</c> Do not mix the use of DXGI 1.0 (IDXGIFactory) and DXGI 1.1 (IDXGIFactory1) in an application. Use <c>IDXGIFactory</c> or
	/// <c>IDXGIFactory1</c>, but not both in an application.
	/// </para>
	/// <para>
	/// <c>Note</c><c>CreateDXGIFactory</c> fails if your app's DllMain function calls it. For more info about how DXGI responds from
	/// <c>DllMain</c>, see DXGI Responses from DLLMain.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, all DXGI factories (regardless if they were created with <c>CreateDXGIFactory</c> or
	/// CreateDXGIFactory1) enumerate adapters identically. The enumeration order of adapters, which you retrieve with
	/// IDXGIFactory::EnumAdapters or IDXGIFactory1::EnumAdapters1, is as follows:
	/// </para>
	/// <para>
	/// The <c>CreateDXGIFactory</c> function does not exist for Windows Store apps. Instead, Windows Store apps use the CreateDXGIFactory1 function.
	/// </para>
	/// </remarks>
	public static IDXGIFactory CreateDXGIFactory()
	{
#pragma warning disable IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
		CreateDXGIFactory(typeof(IDXGIFactory).GUID, out var f).ThrowIfFailed();
#pragma warning restore IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
		return (IDXGIFactory)f;
	}

	/// <summary>Creates a DXGI 1.1 factory that you can use to generate other DXGI objects.</summary>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>The globally unique identifier (GUID) of the IDXGIFactory1 object referenced by the ppFactory parameter.</para>
	/// </param>
	/// <param name="ppFactory">
	/// <para>Type: <c>void**</c></para>
	/// <para>Address of a pointer to an IDXGIFactory1 object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns S_OK if successful; an error code otherwise. For a list of error codes, see DXGI_ERROR.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use a DXGI 1.1 factory to generate objects that enumerate adapters, create swap chains, and associate a window with the alt+enter
	/// key sequence for toggling to and from the full-screen display mode.
	/// </para>
	/// <para>
	/// If the <c>CreateDXGIFactory1</c> function succeeds, the reference count on the IDXGIFactory1 interface is incremented. To avoid a
	/// memory leak, when you finish using the interface, call the IDXGIFactory1::Release method to release the interface.
	/// </para>
	/// <para>
	/// This entry point is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008. DXGI 1.1 support is required,
	/// which is available on Windows 7, Windows Server 2008 R2, and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644) and
	/// Windows Server 2008 (KB 971512).
	/// </para>
	/// <para>
	/// <c>Note</c> Do not mix the use of DXGI 1.0 (IDXGIFactory) and DXGI 1.1 (IDXGIFactory1) in an application. Use <c>IDXGIFactory</c> or
	/// <c>IDXGIFactory1</c>, but not both in an application.
	/// </para>
	/// <para>
	/// <c>Note</c><c>CreateDXGIFactory1</c> fails if your app's DllMain function calls it. For more info about how DXGI responds from
	/// <c>DllMain</c>, see DXGI Responses from DLLMain.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting with Windows 8, all DXGI factories (regardless if they were created with CreateDXGIFactory or
	/// <c>CreateDXGIFactory1</c>) enumerate adapters identically. The enumeration order of adapters, which you retrieve with
	/// IDXGIFactory::EnumAdapters or IDXGIFactory1::EnumAdapters1, is as follows:
	/// </para>
	/// <para>Examples</para>
	/// <para>Creating a DXGI 1.1 Factory</para>
	/// <para>
	/// The following code example demonstrates how to create a DXGI 1.1 factory. This example uses the __uuidof() intrinsic to obtain the
	/// REFIID, or GUID, of the IDXGIFactory1 interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-createdxgifactory1 HRESULT CreateDXGIFactory1( REFIID riid, void
	// **ppFactory );
	[DllImport(Lib.DXGI, SetLastError = false, ExactSpelling = true), PInvokeData("dxgi.h", MSDNShortId = "6fb9d7a3-0b59-4b7a-8871-b99d59811d46")]
	public static extern HRESULT CreateDXGIFactory1(in Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppFactory);

	/// <summary>Represents a color value with alpha, which is used for transparency.</summary>
	/// <remarks>
	/// <para>
	/// You can set the members of this structure to values outside the range of 0 through 1 to implement some unusual effects. Values
	/// greater than 1 produce strong lights that tend to wash out a scene. Negative values produce dark lights that actually remove light
	/// from a scene.
	/// </para>
	/// <para>The DXGItype.h header type-defines <c>DXGI_RGBA</c> as an alias of <c>D3DCOLORVALUE</c>, as follows:</para>
	/// <para>
	/// You can use D3DCOLORVALUE or <c>DXGI_RGBA</c> with <c>IDXGISwapChain1::SetBackgroundColor</c>,
	/// <c>IDXGISwapChain1::GetBackgroundColor</c>, and <c>DXGI_ALPHA_MODE</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3ddxgi/d3dcolorvalue typedef struct D3DCOLORVALUE { float r; float g; float b;
	// float a; } D3DCOLORVALUE;
	[PInvokeData("d3dtypes.h"), StructLayout(LayoutKind.Sequential)]
	public struct D3DCOLORVALUE(float r, float g, float b, float a = 1.0f) : IEquatable<D3DCOLORVALUE>
	{
		/// <summary>
		/// Floating-point value that specifies the red component of a color. This value generally is in the range from 0.0 through 1.0. A
		/// value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.
		/// </summary>
		public float r = r;

		/// <summary>
		/// Floating-point value that specifies the green component of a color. This value generally is in the range from 0.0 through 1.0. A
		/// value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.
		/// </summary>
		public float g = g;

		/// <summary>
		/// Floating-point value that specifies the blue component of a color. This value generally is in the range from 0.0 through 1.0. A
		/// value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.
		/// </summary>
		public float b = b;

		/// <summary>
		/// Floating-point value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A
		/// value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.
		/// </summary>
		public float a = a;

		/// <summary>Initializes a new instance of the <see cref="D3DCOLORVALUE"/> struct.</summary>
		/// <param name="color">The color.</param>
		public D3DCOLORVALUE(System.Drawing.Color color) : this(color.R / 255f, color.G / 255f, color.B / 255f, color.A)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="D3DCOLORVALUE" /> struct.</summary>
		/// <param name="color">The color.</param>
		/// <param name="a">The alpha value.</param>
		public D3DCOLORVALUE(COLORREF color, float a = 1f) : this(color.R / 255f, color.G / 255f, color.B / 255f, a)
		{
		}

#if !NETSTANDARD2_0
		/// <summary>Initializes a new instance of the <see cref="D3DCOLORVALUE"/> struct.</summary>
		/// <param name="color">The color.</param>
		/// <param name="a">The alpha value.</param>
		public D3DCOLORVALUE(System.Drawing.KnownColor color, float a = 1.0f) : this(System.Drawing.Color.FromKnownColor(color)) => this.a = a;
#endif

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is D3DCOLORVALUE dCOLORVALUE && Equals(dCOLORVALUE);

		/// <summary>Equalses the specified other.</summary>
		/// <param name="other">The other.</param>
		/// <returns></returns>
		public bool Equals(D3DCOLORVALUE other) => r == other.r && g == other.g && b == other.b && a == other.a;

		/// <inheritdoc/>
		public override int GetHashCode()
		{
			int hashCode = -490236692;
			hashCode = hashCode * -1521134295 + r.GetHashCode();
			hashCode = hashCode * -1521134295 + g.GetHashCode();
			hashCode = hashCode * -1521134295 + b.GetHashCode();
			hashCode = hashCode * -1521134295 + a.GetHashCode();
			return hashCode;
		}

		/// <inheritdoc/>
		public override string ToString() => $"r:{r}, g:{g}, b:{b}, a:{a}";

		/// <summary>Implements the operator op_Equality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(D3DCOLORVALUE left, D3DCOLORVALUE right) => left.Equals(right);

		/// <summary>Implements the operator op_Inequality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(D3DCOLORVALUE left, D3DCOLORVALUE right) => !(left == right);

		/// <summary>Performs an explicit conversion from <see cref="Vanara.PInvoke.COLORREF"/> to <see cref="D3DCOLORVALUE"/>.</summary>
		/// <param name="c">The color.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator D3DCOLORVALUE(D3DCOLOR c) => new(c.R / 255f, c.G / 255f, c.B / 255f, c.A / 255f);

		/// <summary>Performs an explicit conversion from <see cref="D3DCOLORVALUE"/> to <see cref="Vanara.PInvoke.COLORREF"/>.</summary>
		/// <param name="cv">The color value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator D3DCOLOR(D3DCOLORVALUE cv) => new((byte)(cv.r * 255), (byte)(cv.g * 255), (byte)(cv.b * 255), (byte)(cv.a * 255));

		/// <summary>Performs an explicit conversion from <see cref="D3DCOLORVALUE"/> to <see cref="float"/>[].</summary>
		/// <param name="cv">The color value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator float[](D3DCOLORVALUE cv) => [cv.r, cv.g, cv.b, cv.a];

		/// <summary>Performs an explicit conversion from <see cref="Vanara.PInvoke.COLORREF"/> to <see cref="D3DCOLORVALUE"/>.</summary>
		/// <param name="c">The color.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator D3DCOLORVALUE(System.Drawing.Color c) => new(c);

		/// <summary>Performs an explicit conversion from <see cref="float"/>[] to <see cref="D3DCOLORVALUE"/>.</summary>
		/// <param name="cv">The color value array.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D3DCOLORVALUE(float[] cv) => cv is not null && cv.Length == 4 ? new(cv[0], cv[1], cv[2], cv[3]) : throw new ArgumentException("An array of four values is required.", nameof(cv));
	}

	/// <summary>Describes an adapter (or video card) by using DXGI 1.0.</summary>
	/// <remarks>
	/// The <c>DXGI_ADAPTER_DESC</c> structure provides a description of an adapter. This structure is initialized by using the
	/// IDXGIAdapter::GetDesc method.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_adapter_desc typedef struct DXGI_ADAPTER_DESC { WCHAR
	// Description[128]; UINT VendorId; UINT DeviceId; UINT SubSysId; UINT Revision; SizeT DedicatedVideoMemory; SizeT
	// DedicatedSystemMemory; SizeT SharedSystemMemory; LUID AdapterLuid; } DXGI_ADAPTER_DESC;
	[PInvokeData("dxgi.h"), StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DXGI_ADAPTER_DESC
	{
		/// <summary>
		/// <para>Type: <c>WCHAR[128]</c></para>
		/// <para>
		/// A string that contains the adapter description. On feature level 9 graphics hardware, GetDesc returns “Software Adapter” for the
		/// description string.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string Description;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The PCI ID of the hardware vendor. On feature level 9 graphics hardware, GetDesc returns zeros for the PCI ID of the hardware vendor.
		/// </para>
		/// </summary>
		public uint VendorId;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The PCI ID of the hardware device. On feature level 9 graphics hardware, GetDesc returns zeros for the PCI ID of the hardware device.
		/// </para>
		/// </summary>
		public uint DeviceId;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The PCI ID of the sub system. On feature level 9 graphics hardware, GetDesc returns zeros for the PCI ID of the sub system.</para>
		/// </summary>
		public uint SubSysId;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The PCI ID of the revision number of the adapter. On feature level 9 graphics hardware, GetDesc returns zeros for the PCI ID of
		/// the revision number of the adapter.
		/// </para>
		/// </summary>
		public uint Revision;

		/// <summary>
		/// <para>Type: <c>SizeT</c></para>
		/// <para>The number of bytes of dedicated video memory that are not shared with the CPU.</para>
		/// </summary>
		public SizeT DedicatedVideoMemory;

		/// <summary>
		/// <para>Type: <c>SizeT</c></para>
		/// <para>
		/// The number of bytes of dedicated system memory that are not shared with the CPU. This memory is allocated from available system
		/// memory at boot time.
		/// </para>
		/// </summary>
		public SizeT DedicatedSystemMemory;

		/// <summary>
		/// <para>Type: <c>SizeT</c></para>
		/// <para>
		/// The number of bytes of shared system memory. This is the maximum value of system memory that may be consumed by the adapter
		/// during operation. Any incidental memory consumed by the driver as it manages and uses video memory is additional.
		/// </para>
		/// </summary>
		public SizeT SharedSystemMemory;

		/// <summary>
		/// <para>Type: <c>LUID</c></para>
		/// <para>A unique value that identifies the adapter. See LUID for a definition of the structure. <c>LUID</c> is defined in dxgi.h.</para>
		/// </summary>
		public LUID AdapterLuid;
	}

	/// <summary>Describes an adapter (or video card) using DXGI 1.1.</summary>
	/// <remarks>
	/// The <c>DXGI_ADAPTER_DESC1</c> structure provides a DXGI 1.1 description of an adapter. This structure is initialized by using the
	/// IDXGIAdapter1::GetDesc1 method.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_adapter_desc1 typedef struct DXGI_ADAPTER_DESC1 { WCHAR
	// Description[128]; UINT VendorId; UINT DeviceId; UINT SubSysId; UINT Revision; SizeT DedicatedVideoMemory; SizeT
	// DedicatedSystemMemory; SizeT SharedSystemMemory; LUID AdapterLuid; UINT Flags; } DXGI_ADAPTER_DESC1;
	[PInvokeData("dxgi.h", MSDNShortId = "0ae3bdb1-b122-439a-8f62-c831a9dd87e2"), StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DXGI_ADAPTER_DESC1
	{
		/// <summary>
		/// <para>Type: <c>WCHAR[128]</c></para>
		/// <para>
		/// A string that contains the adapter description. On feature level 9 graphics hardware, GetDesc1 returns “Software Adapter” for
		/// the description string.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string Description;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The PCI ID of the hardware vendor. On feature level 9 graphics hardware, GetDesc1 returns zeros for the PCI ID of the hardware vendor.
		/// </para>
		/// </summary>
		public uint VendorId;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The PCI ID of the hardware device. On feature level 9 graphics hardware, GetDesc1 returns zeros for the PCI ID of the hardware device.
		/// </para>
		/// </summary>
		public uint DeviceId;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The PCI ID of the sub system. On feature level 9 graphics hardware, GetDesc1 returns zeros for the PCI ID of the sub system.</para>
		/// </summary>
		public uint SubSysId;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The PCI ID of the revision number of the adapter. On feature level 9 graphics hardware, GetDesc1 returns zeros for the PCI ID of
		/// the revision number of the adapter.
		/// </para>
		/// </summary>
		public uint Revision;

		/// <summary>
		/// <para>Type: <c>SizeT</c></para>
		/// <para>The number of bytes of dedicated video memory that are not shared with the CPU.</para>
		/// </summary>
		public SizeT DedicatedVideoMemory;

		/// <summary>
		/// <para>Type: <c>SizeT</c></para>
		/// <para>
		/// The number of bytes of dedicated system memory that are not shared with the CPU. This memory is allocated from available system
		/// memory at boot time.
		/// </para>
		/// </summary>
		public SizeT DedicatedSystemMemory;

		/// <summary>
		/// <para>Type: <c>SizeT</c></para>
		/// <para>
		/// The number of bytes of shared system memory. This is the maximum value of system memory that may be consumed by the adapter
		/// during operation. Any incidental memory consumed by the driver as it manages and uses video memory is additional.
		/// </para>
		/// </summary>
		public SizeT SharedSystemMemory;

		/// <summary>
		/// <para>Type: <c>LUID</c></para>
		/// <para>A unique value that identifies the adapter. See LUID for a definition of the structure. <c>LUID</c> is defined in dxgi.h.</para>
		/// </summary>
		public LUID AdapterLuid;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A value of the DXGI_ADAPTER_FLAG enumerated type that describes the adapter type. The <c>DXGI_ADAPTER_FLAG_REMOTE</c> flag is reserved.
		/// </para>
		/// </summary>
		public DXGI_ADAPTER_FLAG Flags;
	}

	/// <summary>Describes timing and presentation statistics for a frame.</summary>
	/// <remarks>
	/// <para>
	/// You initialize the <c>DXGI_FRAME_STATISTICS</c> structure with the IDXGIOutput::GetFrameStatistics or
	/// IDXGISwapChain::GetFrameStatistics method.
	/// </para>
	/// <para>
	/// You can only use IDXGISwapChain::GetFrameStatistics for swap chains that either use the flip presentation model or draw in
	/// full-screen mode. You set the DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL value in the <c>SwapEffect</c> member of the DXGI_SWAP_CHAIN_DESC1
	/// structure to specify that the swap chain uses the flip presentation model.
	/// </para>
	/// <para>
	/// The values in the <c>PresentCount</c> and <c>PresentRefreshCount</c> members indicate information about when a frame was presented
	/// on the display screen. You can use these values to determine whether a glitch occurred. The values in the <c>SyncRefreshCount</c>
	/// and <c>SyncQPCTime</c> members indicate timing information that you can use for audio and video synchronization or very precise
	/// animation. If the swap chain draws in full-screen mode, these values are based on when the computer booted. If the swap chain draws
	/// in windowed mode, these values are based on when the swap chain is created.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_frame_statistics typedef struct DXGI_FRAME_STATISTICS { UINT
	// PresentCount; UINT PresentRefreshCount; UINT SyncRefreshCount; LARGE_INTEGER SyncQPCTime; LARGE_INTEGER SyncGPUTime; } DXGI_FRAME_STATISTICS;
	[PInvokeData("dxgi.h"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_FRAME_STATISTICS
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A value that represents the running total count of times that an image was presented to the monitor since the computer booted.
		/// </para>
		/// <para>
		/// <c>Note</c> The number of times that an image was presented to the monitor is not necessarily the same as the number of times
		/// that you called IDXGISwapChain::Present or IDXGISwapChain1::Present1.
		/// </para>
		/// </summary>
		public uint PresentCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A value that represents the running total count of v-blanks at which the last image was presented to the monitor and that have
		/// happened since the computer booted (for windowed mode, since the swap chain was created).
		/// </para>
		/// </summary>
		public uint PresentRefreshCount;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A value that represents the running total count of v-blanks when the scheduler last sampled the machine time by calling
		/// QueryPerformanceCounter and that have happened since the computer booted (for windowed mode, since the swap chain was created).
		/// </para>
		/// </summary>
		public uint SyncRefreshCount;

		/// <summary>
		/// <para>Type: <c>LARGE_INTEGER</c></para>
		/// <para>
		/// A value that represents the high-resolution performance counter timer. This value is the same as the value returned by the
		/// QueryPerformanceCounter function.
		/// </para>
		/// </summary>
		public int SyncQPCTime;

		/// <summary>
		/// <para>Type: <c>LARGE_INTEGER</c></para>
		/// <para>Reserved. Always returns 0.</para>
		/// </summary>
		public int SyncGPUTime;
	}

	/// <summary>Controls the settings of a gamma curve.</summary>
	/// <remarks>
	/// <para>The <c>DXGI_GAMMA_CONTROL</c> structure is used by the <c>IDXGIOutput::SetGammaControl</c> method.</para>
	/// <para>For info about using gamma correction, see Using gamma correction.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173061(v=vs.85) typedef struct DXGI_GAMMA_CONTROL {
	// DXGI_RGB Scale; DXGI_RGB Offset; DXGI_RGB GammaCurve[1025]; } DXGI_GAMMA_CONTROL;
	[PInvokeData("DXGI.h"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_GAMMA_CONTROL
	{
		/// <summary>A DXGI_RGB structure with scalar values that are applied to rgb values before being sent to the gamma look up table.</summary>
		public DXGI_RGB Scale;

		/// <summary>
		/// A DXGI_RGB structure with offset values that are applied to the rgb values before being sent to the gamma look up table.
		/// </summary>
		public DXGI_RGB Offset;

		/// <summary>An array of DXGI_RGB structures that control the points of a gamma curve.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1025)]
		public DXGI_RGB[] GammaCurve;
	}

	/// <summary>The DXGI_GAMMA_CONTROL_CAPABILIITES structure describes gamma capabilities.</summary>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/dxgitype/ns-dxgitype-dxgi_gamma_control_capabilities typedef struct
	// DXGI_GAMMA_CONTROL_CAPABILITIES { BOOL ScaleAndOffsetSupported; float MaxConvertedValue; float MinConvertedValue; UINT
	// NumGammaControlPoints; float ControlPointPositions[1025]; } DXGI_GAMMA_CONTROL_CAPABILITIES;
	[PInvokeData("dxgitype.h", MSDNShortId = "7a91311e-c8b9-4f28-b72e-9f93d459aac2"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_GAMMA_CONTROL_CAPABILITIES
	{
		/// <summary>
		/// [out] A BOOL value that indicates whether the device supports scale and offset. <c>TRUE</c> indicates that the device supports
		/// scale and offset; <c>FALSE</c> indicates that the device does not support scale and offset.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool ScaleAndOffsetSupported;

		/// <summary>[out] A single-precision float vector for the maximum converted value for the gamma control.</summary>
		public float MaxConvertedValue;

		/// <summary>[out] A single-precision float vector for the minimum converted value for the gamma control.</summary>
		public float MinConvertedValue;

		/// <summary>[out] The number of elements in the array that the <c>ControlPointPositions</c> member specifies.</summary>
		public uint NumGammaControlPoints;

		/// <summary>[out] An array of single-precision float vectors that describe the gamma control point positions.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1025)]
		public float[] ControlPointPositions;
	}

	/// <summary>Describes a mapped rectangle that is used to access a surface.</summary>
	/// <remarks>The <c>DXGI_MAPPED_RECT</c> structure is initialized by the IDXGISurface::Map method.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_mapped_rect typedef struct DXGI_MAPPED_RECT { INT Pitch; BYTE
	// *pBits; } DXGI_MAPPED_RECT;
	[PInvokeData("dxgi.h"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_MAPPED_RECT
	{
		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>A value that describes the width, in bytes, of the surface.</para>
		/// </summary>
		public int Pitch;

		/// <summary>
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>A pointer to the image buffer of the surface.</para>
		/// </summary>
		public IntPtr pBits;
	}

	/// <summary>Describes a display mode.</summary>
	/// <remarks>
	/// <para>This structure is used by the <c>GetDisplayModeList</c> and <c>FindClosestMatchingMode</c> methods.</para>
	/// <para>
	/// The following format values are valid for display modes and when you create a bit-block transfer (bitblt) model swap chain. The
	/// valid values depend on the feature level that you are working with.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// </list>
	/// <para>
	/// You can pass one of these format values to <c>ID3D11Device::CheckFormatSupport</c> to determine if it is a valid format for
	/// displaying on screen. If <c>ID3D11Device::CheckFormatSupport</c> returns <c>D3D11_FORMAT_SUPPORT_DISPLAY</c> in the bit field to
	/// which the pFormatSupport parameter points, the format is valid for displaying on screen.
	/// </para>
	/// <para>
	/// Starting with Windows 8 for a flip model swap chain (that is, a swap chain that has the <c>DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL</c>
	/// value set in the <c>SwapEffect</c> member of <c>DXGI_SWAP_CHAIN_DESC</c>), you must set the <c>Format</c> member of
	/// <c>DXGI_MODE_DESC</c> to <c>DXGI_FORMAT_R16G16B16A16_FLOAT</c>, <c>DXGI_FORMAT_B8G8R8A8_UNORM</c>, or <c>DXGI_FORMAT_R8G8B8A8_UNORM</c>.
	/// </para>
	/// <para>
	/// Because of the relaxed render target creation rules that Direct3D 11 has for back buffers, applications can create a
	/// <c>DXGI_FORMAT_B8G8R8A8_UNORM_SRGB</c> render target view from a <c>DXGI_FORMAT_B8G8R8A8_UNORM</c> swap chain so they can use
	/// automatic color space conversion when they render the swap chain.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173064(v=vs.85) typedef struct DXGI_MODE_DESC { UINT
	// Width; UINT Height; DXGI_RATIONAL RefreshRate; DXGI_FORMAT Format; DXGI_MODE_SCANLINE_ORDER ScanlineOrdering; DXGI_MODE_SCALING
	// Scaling; } DXGI_MODE_DESC;
	[PInvokeData("DXGI.h"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_MODE_DESC
	{
		/// <summary>
		/// A value that describes the resolution width. If you specify the width as zero when you call the IDXGIFactory::CreateSwapChain
		/// method to create a swap chain, the runtime obtains the width from the output window and assigns this width value to the
		/// swap-chain description. You can subsequently call the IDXGISwapChain::GetDesc method to retrieve the assigned width value.
		/// </summary>
		public uint Width;

		/// <summary>
		/// A value describing the resolution height. If you specify the height as zero when you call the IDXGIFactory::CreateSwapChain
		/// method to create a swap chain, the runtime obtains the height from the output window and assigns this height value to the
		/// swap-chain description. You can subsequently call the IDXGISwapChain::GetDesc method to retrieve the assigned height value.
		/// </summary>
		public uint Height;

		/// <summary>A DXGI_RATIONAL structure describing the refresh rate in hertz</summary>
		public DXGI_RATIONAL RefreshRate;

		/// <summary>A DXGI_FORMAT structure describing the display format.</summary>
		public DXGI_FORMAT Format;

		/// <summary>A member of the DXGI_MODE_SCANLINE_ORDER enumerated type describing the scanline drawing mode.</summary>
		public DXGI_MODE_SCANLINE_ORDER ScanlineOrdering;

		/// <summary>A member of the DXGI_MODE_SCALING enumerated type describing the scaling mode.</summary>
		public DXGI_MODE_SCALING Scaling;
	}

	/// <summary>Describes an output or physical connection between the adapter (video card) and a device.</summary>
	/// <remarks>The <c>DXGI_OUTPUT_DESC</c> structure is initialized by the IDXGIOutput::GetDesc method.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_output_desc typedef struct DXGI_OUTPUT_DESC { WCHAR
	// DeviceName[32]; RECT DesktopCoordinates; BOOL AttachedToDesktop; DXGI_MODE_ROTATION Rotation; HMONITOR Monitor; } DXGI_OUTPUT_DESC;
	[PInvokeData("dxgi.h"), StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DXGI_OUTPUT_DESC
	{
		/// <summary>
		/// <para>Type: <c>WCHAR[32]</c></para>
		/// <para>A string that contains the name of the output device.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string DeviceName;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>
		/// A RECT structure containing the bounds of the output in desktop coordinates. Desktop coordinates depend on the dots per inch
		/// (DPI) of the desktop. For info about writing DPI-aware Win32 apps, see High DPI.
		/// </para>
		/// </summary>
		public RECT DesktopCoordinates;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if the output is attached to the desktop; otherwise, false.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool AttachedToDesktop;

		/// <summary>
		/// <para>Type: <c>DXGI_MODE_ROTATION</c></para>
		/// <para>A member of the DXGI_MODE_ROTATION enumerated type describing on how an image is rotated by the output.</para>
		/// </summary>
		public DXGI_MODE_ROTATION Rotation;

		/// <summary>
		/// <para>Type: <c>HMONITOR</c></para>
		/// <para>An HMONITOR handle that represents the display monitor. For more information, see HMONITOR and the Device Context.</para>
		/// </summary>
		public HMONITOR Monitor;
	}

	/// <summary>Represents a rational number.</summary>
	/// <remarks>
	/// <para>This structure is a member of the DXGI_MODE_DESC structure.</para>
	/// <para>The <c>DXGI_RATIONAL</c> structure operates under the following rules:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>0/0 is legal and will be interpreted as 0/1.</term>
	/// </item>
	/// <item>
	/// <term>0/anything is interpreted as zero.</term>
	/// </item>
	/// <item>
	/// <term>If you are representing a whole number, the denominator should be 1.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgicommon/ns-dxgicommon-dxgi_rational typedef struct DXGI_RATIONAL { UINT
	// Numerator; UINT Denominator; } DXGI_RATIONAL;
	[PInvokeData("dxgicommon.h"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_RATIONAL
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>An unsigned integer value representing the top of the rational number.</para>
		/// </summary>
		public uint Numerator;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>An unsigned integer value representing the bottom of the rational number.</para>
		/// </summary>
		public uint Denominator;
	}

	/// <summary>Represents an RGB color.</summary>
	/// <remarks>This structure is a member of the <c>DXGI_GAMMA_CONTROL</c> structure.</remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173071(v=vs.85) typedef struct DXGI_RGB { float Red;
	// float Green; float Blue; } DXGI_RGB;
	[PInvokeData("DXGI.h"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_RGB
	{
		/// <summary>A value representing the color of the red component. The range of this value is between 0 and 1.</summary>
		public float Red;

		/// <summary>A value representing the color of the green component. The range of this value is between 0 and 1.</summary>
		public float Green;

		/// <summary>A value representing the color of the blue component. The range of this value is between 0 and 1.</summary>
		public float Blue;
	}

	/// <summary>Describes multi-sampling parameters for a resource.</summary>
	/// <remarks>
	/// <para>This structure is a member of the DXGI_SWAP_CHAIN_DESC1 structure.</para>
	/// <para>The default sampler mode, with no anti-aliasing, has a count of 1 and a quality level of 0.</para>
	/// <para>
	/// If multi-sample antialiasing is being used, all bound render targets and depth buffers must have the same sample counts and quality levels.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>
	/// Differences between Direct3D 10.0 and Direct3D 10.1 and between Direct3D 10.0 and Direct3D 11: Direct3D 10.1 has defined two
	/// standard quality levels: D3D10_STANDARD_MULTISAMPLE_PATTERN and D3D10_CENTER_MULTISAMPLE_PATTERN in the
	/// D3D10_STANDARD_MULTISAMPLE_QUALITY_LEVELS enumeration in D3D10_1.h. Direct3D 11 has defined two standard quality levels:
	/// D3D11_STANDARD_MULTISAMPLE_PATTERN and D3D11_CENTER_MULTISAMPLE_PATTERN in the D3D11_STANDARD_MULTISAMPLE_QUALITY_LEVELS enumeration
	/// in D3D11.h.
	/// </term>
	/// </listheader>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgicommon/ns-dxgicommon-dxgi_sample_desc typedef struct DXGI_SAMPLE_DESC { UINT
	// Count; UINT Quality; } DXGI_SAMPLE_DESC;
	[PInvokeData("dxgicommon.h"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_SAMPLE_DESC(uint count, uint quality)
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of multisamples per pixel.</para>
		/// </summary>
		public uint Count = count;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The image quality level. The higher the quality, the lower the performance. The valid range is between zero and one less than
		/// the level returned by ID3D10Device::CheckMultisampleQualityLevels for Direct3D 10 or ID3D11Device::CheckMultisampleQualityLevels
		/// for Direct3D 11.
		/// </para>
		/// <para>
		/// For Direct3D 10.1 and Direct3D 11, you can use two special quality level values. For more information about these quality level
		/// values, see Remarks.
		/// </para>
		/// </summary>
		public uint Quality = quality;
	}

	/// <summary>Represents a handle to a shared resource.</summary>
	/// <remarks>To create a shared surface, pass a shared-resource handle into the IDXGIDevice::CreateSurface method.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_shared_resource typedef struct DXGI_SHARED_RESOURCE { HANDLE
	// Handle; } DXGI_SHARED_RESOURCE;
	[PInvokeData("dxgi.h"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_SHARED_RESOURCE
	{
		/// <summary>
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>A handle to a shared resource.</para>
		/// </summary>
		public HANDLE Handle;
	}

	/// <summary>Describes a surface.</summary>
	/// <remarks>This structure is used by the GetDesc and CreateSurface methods.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_surface_desc typedef struct DXGI_SURFACE_DESC { UINT Width; UINT
	// Height; DXGI_FORMAT Format; DXGI_SAMPLE_DESC SampleDesc; } DXGI_SURFACE_DESC;
	[PInvokeData("dxgi.h"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_SURFACE_DESC
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>A value describing the surface width.</para>
		/// </summary>
		public uint Width;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>A value describing the surface height.</para>
		/// </summary>
		public uint Height;

		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>A member of the DXGI_FORMAT enumerated type that describes the surface format.</para>
		/// </summary>
		public DXGI_FORMAT Format;

		/// <summary>
		/// <para>Type: <c>DXGI_SAMPLE_DESC</c></para>
		/// <para>A member of the DXGI_SAMPLE_DESC structure that describes multi-sampling parameters for the surface.</para>
		/// </summary>
		public DXGI_SAMPLE_DESC SampleDesc;
	}

	/// <summary>Describes a swap chain.</summary>
	/// <remarks>
	/// <para>This structure is used by the GetDesc and CreateSwapChain methods.</para>
	/// <para>In full-screen mode, there is a dedicated front buffer; in windowed mode, the desktop is the front buffer.</para>
	/// <para>
	/// If you create a swap chain with one buffer, specifying <c>DXGI_SWAP_EFFECT_SEQUENTIAL</c> does not cause the contents of the single
	/// buffer to be swapped with the front buffer.
	/// </para>
	/// <para>
	/// For performance information about flipping swap-chain buffers in full-screen application, see Full-Screen Application Performance Hints.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_swap_chain_desc typedef struct DXGI_SWAP_CHAIN_DESC {
	// DXGI_MODE_DESC BufferDesc; DXGI_SAMPLE_DESC SampleDesc; DXGI_USAGE BufferUsage; UINT BufferCount; HWND OutputWindow; BOOL Windowed;
	// DXGI_SWAP_EFFECT SwapEffect; UINT Flags; } DXGI_SWAP_CHAIN_DESC;
	[PInvokeData("dxgi.h"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_SWAP_CHAIN_DESC
	{
		/// <summary>
		/// <para>Type: <c>DXGI_MODE_DESC</c></para>
		/// <para>A DXGI_MODE_DESC structure that describes the backbuffer display mode.</para>
		/// </summary>
		public DXGI_MODE_DESC BufferDesc;

		/// <summary>
		/// <para>Type: <c>DXGI_SAMPLE_DESC</c></para>
		/// <para>A DXGI_SAMPLE_DESC structure that describes multi-sampling parameters.</para>
		/// </summary>
		public DXGI_SAMPLE_DESC SampleDesc;

		/// <summary>
		/// <para>Type: <c>DXGI_USAGE</c></para>
		/// <para>
		/// A member of the DXGI_USAGE enumerated type that describes the surface usage and CPU access options for the back buffer. The back
		/// buffer can be used for shader input or render-target output.
		/// </para>
		/// </summary>
		public DXGI_USAGE BufferUsage;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A value that describes the number of buffers in the swap chain. When you call IDXGIFactory::CreateSwapChain to create a
		/// full-screen swap chain, you typically include the front buffer in this value. For more information about swap-chain buffers, see Remarks.
		/// </para>
		/// </summary>
		public uint BufferCount;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>An HWND handle to the output window. This member must not be <c>NULL</c>.</para>
		/// </summary>
		public HWND OutputWindow;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A Boolean value that specifies whether the output is in windowed mode. <c>TRUE</c> if the output is in windowed mode; otherwise, <c>FALSE</c>.
		/// </para>
		/// <para>
		/// We recommend that you create a windowed swap chain and allow the end user to change the swap chain to full screen through
		/// IDXGISwapChain::SetFullscreenState; that is, do not set this member to FALSE to force the swap chain to be full screen. However,
		/// if you create the swap chain as full screen, also provide the end user with a list of supported display modes through the
		/// <c>BufferDesc</c> member because a swap chain that is created with an unsupported display mode might cause the display to go
		/// black and prevent the end user from seeing anything.
		/// </para>
		/// <para>For more information about choosing windowed verses full screen, see IDXGIFactory::CreateSwapChain.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool Windowed;

		/// <summary>
		/// <para>Type: <c>DXGI_SWAP_EFFECT</c></para>
		/// <para>
		/// A member of the DXGI_SWAP_EFFECT enumerated type that describes options for handling the contents of the presentation buffer
		/// after presenting a surface.
		/// </para>
		/// </summary>
		public DXGI_SWAP_EFFECT SwapEffect;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>A member of the DXGI_SWAP_CHAIN_FLAG enumerated type that describes options for swap-chain behavior.</para>
		/// </summary>
		public DXGI_SWAP_CHAIN_FLAG Flags;
	}

	/// <summary>Globally unique identifier (GUID) values that identify producers of debug messages.</summary>
	/// <remarks>
	/// <para>Use these values with the <c>IDXGIInfoQueue</c> interface.</para>
	/// <para>To use any of these GUID values, include DXGIDebug.h in your code and link to dxguid.lib.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-debug-id
	[PInvokeData("DXGIDebug.h"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_DEBUG_ID
	{
		private Guid id;

		/// <summary>All Direct3D and DXGI objects and private apps.</summary>
		public static readonly Guid DXGI_DEBUG_ALL = new(0xe48ae283, 0xda80, 0x490b, 0x87, 0xe6, 0x43, 0xe9, 0xa9, 0xcf, 0xda, 0x8);

		/// <summary>Direct3D and DXGI objects.</summary>
		public static readonly Guid DXGI_DEBUG_DX = new(0x35cdd7fc, 0x13b2, 0x421d, 0xa5, 0xd7, 0x7e, 0x44, 0x51, 0x28, 0x7d, 0x64);

		/// <summary>DXGI.</summary>
		public static readonly Guid DXGI_DEBUG_DXGI = new(0x25cddaa4, 0xb1c6, 0x47e1, 0xac, 0x3e, 0x98, 0x87, 0x5b, 0x5a, 0x2e, 0x2a);

		/// <summary>Private apps. Any messages that you add with IDXGIInfoQueue::AddApplicationMessage.</summary>
		public static readonly Guid DXGI_DEBUG_APP = new(0x6cd6e01, 0x4219, 0x4ebd, 0x87, 0x9, 0x27, 0xed, 0x23, 0x36, 0xc, 0x62);

		/// <summary>Private apps. Any messages that you add with IDXGIInfoQueue::AddApplicationMessage.</summary>
		public static readonly Guid DXGI_DEBUG_D3D11 = new(0x4b99317b, 0xac39, 0x4aa6, 0xbb, 0xb, 0xba, 0xa0, 0x47, 0x84, 0x79, 0x8f);

		/// <summary>Performs an implicit conversion from <see cref="System.Guid"/> to <see cref="Vanara.PInvoke.DXGI.DXGI_DEBUG_ID"/>.</summary>
		/// <param name="id">The identifier.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator DXGI_DEBUG_ID(Guid id) => new() { id = id };
	}

	/// <summary>Specifies color space types.</summary>
	/// <remarks>
	/// <para>
	/// This enum is used within DXGI in the CheckColorSpaceSupport, SetColorSpace1 and CheckOverlayColorSpaceSupport methods. It is also
	/// referenced in D3D11 video methods such as ID3D11VideoContext1::VideoProcessorSetOutputColorSpace1, and D2D methods such as ID2D1DeviceContext2::CreateImageSourceFromDxgi.
	/// </para>
	/// <para>The following color parameters are defined:</para>
	/// <para>Colorspace</para>
	/// <para>Defines the color space of the color channel data.</para>
	/// <list type="table">
	/// <listheader>
	/// <description><c>Defined Values</c></description>
	/// <description><c>Notation in color space enumeration</c></description>
	/// <description><c>Comments</c></description>
	/// </listheader>
	/// <item>
	/// <description>RGB</description>
	/// <description>_RGB_</description>
	/// <description>The red/green/blue color space color channel.</description>
	/// </item>
	/// <item>
	/// <description>YCbCr</description>
	/// <description>_YCbCr_</description>
	/// <description>
	/// Three channel color model which splits luma (brightness) from chroma (color). YUV technically refers to analog signals and YCbCr to
	/// digital, but they are used interchangeably.
	/// </description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>Range</para>
	/// <para>
	/// Indicates which integer range corresponds to the floating point [0..1] range of the data. For video, integer YCbCr data with ranges
	/// of [16..235] or [8..247] are usually mapped to normalized YCbCr with ranges of [0..1] or [-0.5..0.5].
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description><c>Defined_Values</c></description>
	/// <description><c>Notation in color space numeration</c></description>
	/// <description><c>Comments</c></description>
	/// </listheader>
	/// <item>
	/// <description>8 bit: 0-255 10 bit: 0-1023 12 bit: 0-4095</description>
	/// <description>_FULL_</description>
	/// <description>PC desktop content and images.</description>
	/// </item>
	/// <item>
	/// <description>8 bit:16-235 10 bit: 64-940 12 bit: 256 - 3760</description>
	/// <description>_STUDIO_</description>
	/// <description>Often used in video. Enables the calibration of white and black between displays.</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>Gamma</para>
	/// <list type="table">
	/// <listheader>
	/// <description><c>Defined Values</c></description>
	/// <description><c>Notation in color space numeration</c></description>
	/// <description><c>Comments</c></description>
	/// </listheader>
	/// <item>
	/// <description>1.0</description>
	/// <description>_G10_</description>
	/// <description>Linear light levels.</description>
	/// </item>
	/// <item>
	/// <description>2.2</description>
	/// <description>_G22_</description>
	/// <description>Commonly used for sRGB and BT.709 (linear segment + 2.4).</description>
	/// </item>
	/// <item>
	/// <description>2084</description>
	/// <description>_G2084_</description>
	/// <description>See SMPTE ST.2084 (Perceptual Quantization)</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>Siting</para>
	/// <para>
	/// "Siting" indicates a horizontal or vertical shift of the chrominance channels relative to the luminance channel. "Cositing"
	/// indicates values are sited between pixels in the vertical or horizontal direction (also known as being "sited interstitially").
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description><c>Defined Values</c></description>
	/// <description><c>Notation in color space enumeration</c></description>
	/// <description><c>Comments</c></description>
	/// <description><c>For Example</c></description>
	/// </listheader>
	/// <item>
	/// <description>Image</description>
	/// <description>_NONE_</description>
	/// <description>The U and V planes are aligned vertically.</description>
	/// <description>MPEG1, JPG</description>
	/// </item>
	/// <item>
	/// <description>Video</description>
	/// <description>_LEFT_</description>
	/// <description>
	/// Chroma samples are aligned horizontally with the luma samples, or with multiples of the luma samples. The U and V planes are aligned vertically.
	/// </description>
	/// <description>MPEG2, MPEG4</description>
	/// </item>
	/// <item>
	/// <description>Video</description>
	/// <description>_TOPLEFT_</description>
	/// <description>
	/// "Top left" means that the sampling point is the top left pixel (usually of a 2x2 pixel block). Chroma samples are aligned
	/// horizontally with the luma samples, or with multiples of the luma samples. Chroma samples are also aligned vertically with the luma
	/// samples, or with multiples of the luma samples.
	/// </description>
	/// <description>UHD Blu-Ray</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>For more information on siting, refer to the MFVideoChromaSubsampling enum.</para>
	/// <para>Primaries</para>
	/// <list type="table">
	/// <listheader>
	/// <description><c>Defined Values</c></description>
	/// <description><c>Notation in color space enumeration</c></description>
	/// <description><c>Comments</c></description>
	/// </listheader>
	/// <item>
	/// <description>BT.601</description>
	/// <description>_P601</description>
	/// <description>Standard defining digital encoding of SDTV video.</description>
	/// </item>
	/// <item>
	/// <description>BT.709</description>
	/// <description>_P709</description>
	/// <description>Standard defining digital encoding of HDTV video.</description>
	/// </item>
	/// <item>
	/// <description>BT.2020</description>
	/// <description>_P2020</description>
	/// <description>Standard defining ultra-high definition television (UHDTV).</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>Transfer Matrix</para>
	/// <para>
	/// In most cases, the transfer matrix can be determined from the primaries. For some cases it must be explicitly specified as described below:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description><c>Defined Values</c></description>
	/// <description><c>Notation in color space enumeration</c></description>
	/// <description><c>Comments</c></description>
	/// </listheader>
	/// <item>
	/// <description>BT.601</description>
	/// <description>_X601</description>
	/// <description>Standard defining digital encoding of SDTV video.</description>
	/// </item>
	/// <item>
	/// <description>BT.709</description>
	/// <description>_X709</description>
	/// <description>Standard defining digital encoding of HDTV video.</description>
	/// </item>
	/// <item>
	/// <description>BT.2020</description>
	/// <description>_X2020</description>
	/// <description>Standard defining ultra-high definition television (UHDTV).</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>Subsampling and the layout of the color channels are inferred from the surface format.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgicommon/ne-dxgicommon-dxgi_color_space_type typedef enum DXGI_COLOR_SPACE_TYPE
	// { DXGI_COLOR_SPACE_RGB_FULL_G22_NONE_P709 = 0, DXGI_COLOR_SPACE_RGB_FULL_G10_NONE_P709 = 1, DXGI_COLOR_SPACE_RGB_STUDIO_G22_NONE_P709
	// = 2, DXGI_COLOR_SPACE_RGB_STUDIO_G22_NONE_P2020 = 3, DXGI_COLOR_SPACE_RESERVED = 4, DXGI_COLOR_SPACE_YCBCR_FULL_G22_NONE_P709_X601 =
	// 5, DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P601 = 6, DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P601 = 7,
	// DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P709 = 8, DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P709 = 9,
	// DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P2020 = 10, DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P2020 = 11,
	// DXGI_COLOR_SPACE_RGB_FULL_G2084_NONE_P2020 = 12, DXGI_COLOR_SPACE_YCBCR_STUDIO_G2084_LEFT_P2020 = 13,
	// DXGI_COLOR_SPACE_RGB_STUDIO_G2084_NONE_P2020 = 14, DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_TOPLEFT_P2020 = 15,
	// DXGI_COLOR_SPACE_YCBCR_STUDIO_G2084_TOPLEFT_P2020 = 16, DXGI_COLOR_SPACE_RGB_FULL_G22_NONE_P2020 = 17,
	// DXGI_COLOR_SPACE_YCBCR_STUDIO_GHLG_TOPLEFT_P2020 = 18, DXGI_COLOR_SPACE_YCBCR_FULL_GHLG_TOPLEFT_P2020 = 19,
	// DXGI_COLOR_SPACE_RGB_STUDIO_G24_NONE_P709 = 20, DXGI_COLOR_SPACE_RGB_STUDIO_G24_NONE_P2020 = 21,
	// DXGI_COLOR_SPACE_YCBCR_STUDIO_G24_LEFT_P709 = 22, DXGI_COLOR_SPACE_YCBCR_STUDIO_G24_LEFT_P2020 = 23,
	// DXGI_COLOR_SPACE_YCBCR_STUDIO_G24_TOPLEFT_P2020 = 24, DXGI_COLOR_SPACE_CUSTOM = 0xFFFFFFFF } ;
	[PInvokeData("dxgicommon.h", MSDNShortId = "NE:dxgicommon.DXGI_COLOR_SPACE_TYPE")]
	public enum DXGI_COLOR_SPACE_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>RGB</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>0-255</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.2</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Image</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.709</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is the standard definition for sRGB.</para>
		/// <para>
		/// <para>NOTE</para>
		/// <para>
		/// This is intended to be implemented with sRGB gamma (linear segment + 2.4 power), which is approximately aligned with a gamma 2.2
		/// curve. This is usually used with 8 or 10 bit color channels.
		/// </para>
		/// </para>
		/// </summary>
		DXGI_COLOR_SPACE_RGB_FULL_G22_NONE_P709,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>RGB</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>0-255</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>1.0</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Image</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.709</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// This is the standard definition for scRGB, and is usually used with 16 bit integer, 16 bit floating point, or 32 bit floating
		/// point color channels.
		/// </para>
		/// </summary>
		DXGI_COLOR_SPACE_RGB_FULL_G10_NONE_P709,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>RGB</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>16-235</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.2</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Image</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.709</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// This is the standard definition for ITU-R Recommendation BT.709. Note that due to the inclusion of a linear segment, the
		/// transfer curve looks similar to a pure exponential gamma of 1.9.
		/// </para>
		/// <para>This is usually used with 8 or 10 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_RGB_STUDIO_G22_NONE_P709,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>RGB</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>16-235</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.2</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Image</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.2020</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is usually used with 10 or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_RGB_STUDIO_G22_NONE_P2020,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Reserved.</para>
		/// </summary>
		DXGI_COLOR_SPACE_RESERVED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>YCbCr</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>0-255</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.2</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Image</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.709</description>
		/// </item>
		/// <item>
		/// <description>Transfer Matrix</description>
		/// <description>BT.601</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This definition is commonly used for JPG, and is usually used with 8, 10, or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_YCBCR_FULL_G22_NONE_P709_X601,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>YCbCr</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>16-235</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.2</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Video</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.601</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This definition is commonly used for MPEG2, and is usually used with 8, 10, or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P601,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>YCbCr</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>0-255</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.2</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Video</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.601</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is sometimes used for H.264 camera capture, and is usually used with 8, 10, or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P601,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>YCbCr</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>16-235</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.2</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Video</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.709</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This definition is commonly used for H.264 and HEVC, and is usually used with 8, 10, or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P709,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>YCbCr</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>0-255</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.2</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Video</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.709</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is sometimes used for H.264 camera capture, and is usually used with 8, 10, or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P709,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>YCbCr</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>16-235</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.2</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Video</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.2020</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This definition may be used by HEVC, and is usually used with 10 or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_LEFT_P2020,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>YCbCr</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>0-255</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.2</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Video</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.2020</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is usually used with 10 or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_YCBCR_FULL_G22_LEFT_P2020,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>RGB</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>0-255</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2084</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Image</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.2020</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is usually used with 10 or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_RGB_FULL_G2084_NONE_P2020,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>YCbCr</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>16-235</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2084</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Video</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.2020</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is usually used with 10 or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_YCBCR_STUDIO_G2084_LEFT_P2020,

		/// <summary>
		/// <para>Value:</para>
		/// <para>14</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>RGB</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>16-235</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2084</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Image</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.2020</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is usually used with 10 or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_RGB_STUDIO_G2084_NONE_P2020,

		/// <summary>
		/// <para>Value:</para>
		/// <para>15</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>YCbCr</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>16-235</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.2</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Video</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.2020</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is usually used with 10 or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_YCBCR_STUDIO_G22_TOPLEFT_P2020,

		/// <summary>
		/// <para>Value:</para>
		/// <para>16</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>YCbCr</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>16-235</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2084</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Video</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.2020</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is usually used with 10 or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_YCBCR_STUDIO_G2084_TOPLEFT_P2020,

		/// <summary>
		/// <para>Value:</para>
		/// <para>17</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>RGB</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>0-255</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.2</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Image</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.2020</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is usually used with 10 or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_RGB_FULL_G22_NONE_P2020,

		/// <summary>
		/// <para>Value:</para>
		/// <para>18</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>YCBCR</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>16-235</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>HLG</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Video</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.2020</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is usually used with 10 or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_YCBCR_STUDIO_GHLG_TOPLEFT_P2020,

		/// <summary>
		/// <para>Value:</para>
		/// <para>19</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>YCBCR</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>0-255</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>HLG</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Video</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.2020</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is usually used with 10 or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_YCBCR_FULL_GHLG_TOPLEFT_P2020,

		/// <summary>
		/// <para>Value:</para>
		/// <para>20</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>RGB</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>16-235</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.4</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Image</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.709</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is usually used with 8, 10, or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_RGB_STUDIO_G24_NONE_P709,

		/// <summary>
		/// <para>Value:</para>
		/// <para>21</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>RGB</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>16-235</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.4</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Image</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.2020</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is usually used with 10 or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_RGB_STUDIO_G24_NONE_P2020,

		/// <summary>
		/// <para>Value:</para>
		/// <para>22</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>YCBCR</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>16-235</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.4</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Video</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.709</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is usually used with 8, 10, or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_YCBCR_STUDIO_G24_LEFT_P709,

		/// <summary>
		/// <para>Value:</para>
		/// <para>23</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>YCBCR</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>16-235</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.4</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Video</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.2020</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is usually used with 10 or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_YCBCR_STUDIO_G24_LEFT_P2020,

		/// <summary>
		/// <para>Value:</para>
		/// <para>24</para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>Property</c></description>
		/// <description><c>Value</c></description>
		/// </listheader>
		/// <item>
		/// <description>Colorspace</description>
		/// <description>YCBCR</description>
		/// </item>
		/// <item>
		/// <description>Range</description>
		/// <description>16-235</description>
		/// </item>
		/// <item>
		/// <description>Gamma</description>
		/// <description>2.4</description>
		/// </item>
		/// <item>
		/// <description>Siting</description>
		/// <description>Video</description>
		/// </item>
		/// <item>
		/// <description>Primaries</description>
		/// <description>BT.2020</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>This is usually used with 10 or 12 bit color channels.</para>
		/// </summary>
		DXGI_COLOR_SPACE_YCBCR_STUDIO_G24_TOPLEFT_P2020,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xFFFFFFFF</para>
		/// <para>A custom color definition is used.</para>
		/// </summary>
		DXGI_COLOR_SPACE_CUSTOM = -1,
	}

	/// <summary>Don't use this structure; it is not supported and it will be removed from the header in a future release.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_display_color_space typedef struct DXGI_DISPLAY_COLOR_SPACE {
	// FLOAT PrimaryCoordinates[8, 2]; FLOAT WhitePoints[16, 2]; } DXGI_DISPLAY_COLOR_SPACE;
	[PInvokeData("dxgi.h", MSDNShortId = "NS:dxgi.DXGI_DISPLAY_COLOR_SPACE"), StructLayout(LayoutKind.Sequential), Obsolete]
	public struct DXGI_DISPLAY_COLOR_SPACE
	{
		private unsafe fixed float primaryCoordinates[8 * 2];
		private unsafe fixed float whitePoints[16 * 2];

		/// <summary>The primary coordinates, as an 8 by 2 array of FLOAT values.</summary>
		public readonly float[,] PrimaryCoordinates
#if NET45
			=> throw new NotImplementedException();

#else
			{ get { unsafe { fixed (float* p = primaryCoordinates) return new Span2D<float>(p, 8, 2, 0).ToArray(); } } }
#endif

		/// <summary>The white points, as a 16 by 2 array of FLOAT values.</summary>
		public readonly float[,] WhitePoints
#if NET45
			=> throw new NotImplementedException();

#else
			{ get { unsafe { fixed (float* p = primaryCoordinates) return new Span2D<float>(p, 16, 2, 0).ToArray(); } } }
#endif
	}

	/// <summary>Describes a JPEG AC huffman table.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-jpeg-ac-huffman-table typedef struct DXGI_JPEG_AC_HUFFMAN_TABLE {
	// BYTE CodeCounts[16]; BYTE CodeValues[162]; } DXGI_JPEG_AC_HUFFMAN_TABLE;
	[PInvokeData("Dxgitype.h"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_JPEG_AC_HUFFMAN_TABLE
	{
		/// <summary>The number of codes for each code length.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] CodeCounts;

		/// <summary>The Huffman code values, in order of increasing code length.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 162)]
		public byte[] CodeValues;
	}

	/// <summary>Describes a JPEG DC huffman table.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-jpeg-dc-huffman-table typedef struct DXGI_JPEG_DC_HUFFMAN_TABLE {
	// BYTE CodeCounts[12]; BYTE CodeValues[12]; } DXGI_JPEG_DC_HUFFMAN_TABLE;
	[PInvokeData("Dxgitype.h"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_JPEG_DC_HUFFMAN_TABLE
	{
		/// <summary>The number of codes for each code length.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		public byte[] CodeCounts;

		/// <summary>The Huffman code values, in order of increasing code length.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		public byte[] CodeValues;
	}

	/// <summary>Describes a JPEG quantization table.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-jpeg-quantization-table typedef struct DXGI_JPEG_QUANTIZATION_TABLE
	// { BYTE Elements[64]; } DXGI_JPEG_QUANTIZATION_TABLE;
	[PInvokeData("Dxgitype.h"), StructLayout(LayoutKind.Sequential)]
	public struct DXGI_JPEG_QUANTIZATION_TABLE
	{
		/// <summary>An array of bytes containing the elements of the quantization table.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] Elements;
	}

	/// <summary>Describes the current video memory budgeting parameters.</summary>
	/// <remarks>
	/// <para>Use this structure with QueryVideoMemoryInfo.</para>
	/// <para>Refer to the remarks for D3D12_MEMORY_POOL.</para>
	/// </remarks>
	/// <summary>Represents a color value with alpha, which is used for transparency.</summary>
	/// <remarks>
	/// <para>
	/// You can set the members of this structure to values outside the range of 0 through 1 to implement some unusual effects. Values
	/// greater than 1 produce strong lights that tend to wash out a scene. Negative values produce dark lights that actually remove light
	/// from a scene.
	/// </para>
	/// <para>The DXGItype.h header type-defines <c>DXGI_RGBA</c> as an alias of <c>D3DCOLORVALUE</c>, as follows:</para>
	/// <para>
	/// You can use <c>DXGI_RGBA</c> with <c>IDXGISwapChain1::SetBackgroundColor</c>, <c>IDXGISwapChain1::GetBackgroundColor</c>, and <c>DXGI_ALPHA_MODE</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-rgba typedef struct DXGI_RGBA { float r; float g; float b; float
	// a; } DXGI_RGBA;
	[PInvokeData("DXGItype.h"), StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct DXGI_RGBA
	{
		/// <summary>
		/// Floating-point value that specifies the red component of a color. This value generally is in the range from 0.0 through 1.0. A
		/// value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.
		/// </summary>
		public float r;

		/// <summary>
		/// Floating-point value that specifies the green component of a color. This value generally is in the range from 0.0 through 1.0. A
		/// value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.
		/// </summary>
		public float g;

		/// <summary>
		/// Floating-point value that specifies the blue component of a color. This value generally is in the range from 0.0 through 1.0. A
		/// value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.
		/// </summary>
		public float b;

		/// <summary>
		/// Floating-point value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A
		/// value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.
		/// </summary>
		public float a;
	}
}