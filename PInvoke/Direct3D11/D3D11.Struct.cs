namespace Vanara.PInvoke;

/// <summary>Provides methods and types for working with Direct3D 11.</summary>
public static partial class D3D11
{
	private const string Lib_D3D11 = "d3d11.dll";

	/// <summary>Creates a device that represents the display adapter.</summary>
	/// <param name="pAdapter">
	/// <para>Type: <c>IDXGIAdapter*</c></para>
	/// <para>
	/// A pointer to the video adapter to use when creating a device. Pass <c>NULL</c> to use the default adapter, which is the first
	/// adapter that is enumerated by IDXGIFactory1::EnumAdapters.
	/// </para>
	/// <para>
	/// <c>Note</c>  Do not mix the use of DXGI 1.0 (IDXGIFactory) and DXGI 1.1 (IDXGIFactory1) in an application. Use <c>IDXGIFactory</c>
	/// or <c>IDXGIFactory1</c>, but not both in an application.
	/// </para>
	/// <para></para>
	/// </param>
	/// <param name="DriverType">
	/// <para>Type: <c>D3D_DRIVER_TYPE</c></para>
	/// <para>The D3D_DRIVER_TYPE, which represents the driver type to create.</para>
	/// </param>
	/// <param name="Software">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// A handle to a DLL that implements a software rasterizer. If <c>DriverType</c> is <c>D3D_DRIVER_TYPE_SOFTWARE</c>, <c>Software</c>
	/// must not be <c>NULL</c>. Get the handle by calling LoadLibrary, LoadLibraryEx , or GetModuleHandle.
	/// </para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The runtime layers to enable (see D3D11_CREATE_DEVICE_FLAG); values can be bitwise OR'd together.</para>
	/// </param>
	/// <param name="pFeatureLevels">
	/// <para>Type: <c>const D3D_FEATURE_LEVEL*</c></para>
	/// <para>
	/// A pointer to an array of D3D_FEATURE_LEVELs, which determine the order of feature levels to attempt to create. If
	/// <c>pFeatureLevels</c> is set to <c>NULL</c>, this function uses the following array of feature levels:
	/// </para>
	/// <para>
	/// <c>Note</c>  If the Direct3D 11.1 runtime is present on the computer and <c>pFeatureLevels</c> is set to <c>NULL</c>, this function
	/// won't create a D3D_FEATURE_LEVEL_11_1 device. To create a <c>D3D_FEATURE_LEVEL_11_1</c> device, you must explicitly provide a
	/// <c>D3D_FEATURE_LEVEL</c> array that includes <c>D3D_FEATURE_LEVEL_11_1</c>. If you provide a <c>D3D_FEATURE_LEVEL</c> array that
	/// contains <c>D3D_FEATURE_LEVEL_11_1</c> on a computer that doesn't have the Direct3D 11.1 runtime installed, this function
	/// immediately fails with E_INVALIDARG.
	/// </para>
	/// <para></para>
	/// </param>
	/// <param name="FeatureLevels">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of elements in <c>pFeatureLevels</c>.</para>
	/// </param>
	/// <param name="SDKVersion">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The SDK version; use <c>D3D11_SDK_VERSION</c>.</para>
	/// </param>
	/// <param name="ppDevice">
	/// <para>Type: <c>ID3D11Device**</c></para>
	/// <para>
	/// Returns the address of a pointer to an ID3D11Device object that represents the device created. If this parameter is <c>NULL</c>, no
	/// ID3D11Device will be returned.
	/// </para>
	/// </param>
	/// <param name="pFeatureLevel">
	/// <para>Type: <c>D3D_FEATURE_LEVEL*</c></para>
	/// <para>
	/// If successful, returns the first D3D_FEATURE_LEVEL from the <c>pFeatureLevels</c> array which succeeded. Supply <c>NULL</c> as an
	/// input if you don't need to determine which feature level is supported.
	/// </para>
	/// </param>
	/// <param name="ppImmediateContext">
	/// <para>Type: <c>ID3D11DeviceContext**</c></para>
	/// <para>
	/// Returns the address of a pointer to an ID3D11DeviceContext object that represents the device context. If this parameter is
	/// <c>NULL</c>, no ID3D11DeviceContext will be returned.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method can return one of the Direct3D 11 Return Codes.</para>
	/// <para>
	/// This method returns E_INVALIDARG if you set the <c>pAdapter</c> parameter to a non- <c>NULL</c> value and the <c>DriverType</c>
	/// parameter to the D3D_DRIVER_TYPE_HARDWARE value.
	/// </para>
	/// <para>
	/// This method returns DXGI_ERROR_SDK_COMPONENT_MISSING if you specify D3D11_CREATE_DEVICE_DEBUG in <c>Flags</c> and the incorrect
	/// version of the debug layer is installed on your computer. Install the latest Windows SDK to get the correct version.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This entry-point is supported by the Direct3D 11 runtime, which is available on Windows 7, Windows Server 2008 R2, and as an update
	/// to Windows Vista (KB971644).
	/// </para>
	/// <para>
	/// To create a Direct3D 11.1 device (ID3D11Device1), which is available on Windows 8, Windows Server 2012, and Windows 7 and Windows
	/// Server 2008 R2 with the Platform Update for Windows 7 installed, you first create a ID3D11Device with this function, and then call
	/// the QueryInterface method on the <c>ID3D11Device</c> object to obtain the <c>ID3D11Device1</c> interface.
	/// </para>
	/// <para>
	/// To create a Direct3D 11.2 device (ID3D11Device2), which is available on Windows 8.1 and Windows Server 2012 R2, you first create a
	/// ID3D11Device with this function, and then call the QueryInterface method on the <c>ID3D11Device</c> object to obtain the
	/// <c>ID3D11Device2</c> interface.
	/// </para>
	/// <para>
	/// Set <c>ppDevice</c> and <c>ppImmediateContext</c> to <c>NULL</c> to determine which feature level is supported by looking at
	/// <c>pFeatureLevel</c> without creating a device.
	/// </para>
	/// <para>
	/// For an example, see How To: Create a Device and Immediate Context; to create a device and a swap chain at the same time, use D3D11CreateDeviceAndSwapChain.
	/// </para>
	/// <para>
	/// If you set the <c>pAdapter</c> parameter to a non- <c>NULL</c> value, you must also set the <c>DriverType</c> parameter to the
	/// D3D_DRIVER_TYPE_UNKNOWN value. If you set the <c>pAdapter</c> parameter to a non- <c>NULL</c> value and the <c>DriverType</c>
	/// parameter to the D3D_DRIVER_TYPE_HARDWARE value, <c>D3D11CreateDevice</c> returns an HRESULT of E_INVALIDARG.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>
	/// Differences between Direct3D 10 and Direct3D 11: In Direct3D 10, the presence of <c>pAdapter</c> dictated which adapter to use and
	/// the <c>DriverType</c> could mismatch what the adapter was. In Direct3D 11, if you are trying to create a hardware or a software
	/// device, set <c>pAdapter</c> != <c>NULL</c> which constrains the other inputs to be: On the other hand, if <c>pAdapter</c> ==
	/// <c>NULL</c>, the <c>DriverType</c> cannot be set to D3D_DRIVER_TYPE_UNKNOWN; it can be set to either:
	/// </description>
	/// </listheader>
	/// </list>
	/// <para></para>
	/// <para>
	/// The function signature PFN_D3D11_CREATE_DEVICE is provided as a typedef, so that you can use dynamic linking techniques
	/// (GetProcAddress) instead of statically linking.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This API is supported.</para>
	/// <para><c>Windows Phone 8.1:</c> This API is supported.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-d3d11createdevice HRESULT D3D11CreateDevice( [in, optional]
	// IDXGIAdapter *pAdapter, D3D_DRIVER_TYPE DriverType, HMODULE Software, UINT Flags, [in, optional] const D3D_FEATURE_LEVEL
	// *pFeatureLevels, UINT FeatureLevels, UINT SDKVersion, [out, optional] ID3D11Device **ppDevice, [out, optional] D3D_FEATURE_LEVEL
	// *pFeatureLevel, [out, optional] ID3D11DeviceContext **ppImmediateContext );
	[PInvokeData("d3d11.h", MSDNShortId = "NF:d3d11.D3D11CreateDevice")]
	[DllImport(Lib_D3D11, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3D11CreateDevice([In, Optional] IDXGIAdapter? pAdapter, D3D_DRIVER_TYPE DriverType,
		HINSTANCE Software, D3D11_CREATE_DEVICE_FLAG Flags, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] D3D_FEATURE_LEVEL[]? pFeatureLevels,
		uint FeatureLevels, uint SDKVersion, out ID3D11Device ppDevice, out D3D_FEATURE_LEVEL pFeatureLevel,
		out ID3D11DeviceContext ppImmediateContext);

	/// <summary>Creates a device that represents the display adapter.</summary>
	/// <param name="pAdapter">
	/// <para>Type: <c>IDXGIAdapter*</c></para>
	/// <para>
	/// A pointer to the video adapter to use when creating a device. Pass <c>NULL</c> to use the default adapter, which is the first
	/// adapter that is enumerated by IDXGIFactory1::EnumAdapters.
	/// </para>
	/// <para>
	/// <c>Note</c>  Do not mix the use of DXGI 1.0 (IDXGIFactory) and DXGI 1.1 (IDXGIFactory1) in an application. Use <c>IDXGIFactory</c>
	/// or <c>IDXGIFactory1</c>, but not both in an application.
	/// </para>
	/// <para></para>
	/// </param>
	/// <param name="DriverType">
	/// <para>Type: <c>D3D_DRIVER_TYPE</c></para>
	/// <para>The D3D_DRIVER_TYPE, which represents the driver type to create.</para>
	/// </param>
	/// <param name="Software">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// A handle to a DLL that implements a software rasterizer. If <c>DriverType</c> is <c>D3D_DRIVER_TYPE_SOFTWARE</c>, <c>Software</c>
	/// must not be <c>NULL</c>. Get the handle by calling LoadLibrary, LoadLibraryEx , or GetModuleHandle.
	/// </para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The runtime layers to enable (see D3D11_CREATE_DEVICE_FLAG); values can be bitwise OR'd together.</para>
	/// </param>
	/// <param name="pFeatureLevels">
	/// <para>Type: <c>const D3D_FEATURE_LEVEL*</c></para>
	/// <para>
	/// A pointer to an array of D3D_FEATURE_LEVELs, which determine the order of feature levels to attempt to create. If
	/// <c>pFeatureLevels</c> is set to <c>NULL</c>, this function uses the following array of feature levels:
	/// </para>
	/// <para>
	/// <c>Note</c>  If the Direct3D 11.1 runtime is present on the computer and <c>pFeatureLevels</c> is set to <c>NULL</c>, this function
	/// won't create a D3D_FEATURE_LEVEL_11_1 device. To create a <c>D3D_FEATURE_LEVEL_11_1</c> device, you must explicitly provide a
	/// <c>D3D_FEATURE_LEVEL</c> array that includes <c>D3D_FEATURE_LEVEL_11_1</c>. If you provide a <c>D3D_FEATURE_LEVEL</c> array that
	/// contains <c>D3D_FEATURE_LEVEL_11_1</c> on a computer that doesn't have the Direct3D 11.1 runtime installed, this function
	/// immediately fails with E_INVALIDARG.
	/// </para>
	/// <para></para>
	/// </param>
	/// <param name="FeatureLevels">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of elements in <c>pFeatureLevels</c>.</para>
	/// </param>
	/// <param name="SDKVersion">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The SDK version; use <c>D3D11_SDK_VERSION</c>.</para>
	/// </param>
	/// <param name="ppDevice">
	/// <para>Type: <c>ID3D11Device**</c></para>
	/// <para>
	/// Returns the address of a pointer to an ID3D11Device object that represents the device created. If this parameter is <c>NULL</c>, no
	/// ID3D11Device will be returned.
	/// </para>
	/// </param>
	/// <param name="pFeatureLevel">
	/// <para>Type: <c>D3D_FEATURE_LEVEL*</c></para>
	/// <para>
	/// If successful, returns the first D3D_FEATURE_LEVEL from the <c>pFeatureLevels</c> array which succeeded. Supply <c>NULL</c> as an
	/// input if you don't need to determine which feature level is supported.
	/// </para>
	/// </param>
	/// <param name="ppImmediateContext">
	/// <para>Type: <c>ID3D11DeviceContext**</c></para>
	/// <para>
	/// Returns the address of a pointer to an ID3D11DeviceContext object that represents the device context. If this parameter is
	/// <c>NULL</c>, no ID3D11DeviceContext will be returned.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method can return one of the Direct3D 11 Return Codes.</para>
	/// <para>
	/// This method returns E_INVALIDARG if you set the <c>pAdapter</c> parameter to a non- <c>NULL</c> value and the <c>DriverType</c>
	/// parameter to the D3D_DRIVER_TYPE_HARDWARE value.
	/// </para>
	/// <para>
	/// This method returns DXGI_ERROR_SDK_COMPONENT_MISSING if you specify D3D11_CREATE_DEVICE_DEBUG in <c>Flags</c> and the incorrect
	/// version of the debug layer is installed on your computer. Install the latest Windows SDK to get the correct version.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This entry-point is supported by the Direct3D 11 runtime, which is available on Windows 7, Windows Server 2008 R2, and as an update
	/// to Windows Vista (KB971644).
	/// </para>
	/// <para>
	/// To create a Direct3D 11.1 device (ID3D11Device1), which is available on Windows 8, Windows Server 2012, and Windows 7 and Windows
	/// Server 2008 R2 with the Platform Update for Windows 7 installed, you first create a ID3D11Device with this function, and then call
	/// the QueryInterface method on the <c>ID3D11Device</c> object to obtain the <c>ID3D11Device1</c> interface.
	/// </para>
	/// <para>
	/// To create a Direct3D 11.2 device (ID3D11Device2), which is available on Windows 8.1 and Windows Server 2012 R2, you first create a
	/// ID3D11Device with this function, and then call the QueryInterface method on the <c>ID3D11Device</c> object to obtain the
	/// <c>ID3D11Device2</c> interface.
	/// </para>
	/// <para>
	/// Set <c>ppDevice</c> and <c>ppImmediateContext</c> to <c>NULL</c> to determine which feature level is supported by looking at
	/// <c>pFeatureLevel</c> without creating a device.
	/// </para>
	/// <para>
	/// For an example, see How To: Create a Device and Immediate Context; to create a device and a swap chain at the same time, use D3D11CreateDeviceAndSwapChain.
	/// </para>
	/// <para>
	/// If you set the <c>pAdapter</c> parameter to a non- <c>NULL</c> value, you must also set the <c>DriverType</c> parameter to the
	/// D3D_DRIVER_TYPE_UNKNOWN value. If you set the <c>pAdapter</c> parameter to a non- <c>NULL</c> value and the <c>DriverType</c>
	/// parameter to the D3D_DRIVER_TYPE_HARDWARE value, <c>D3D11CreateDevice</c> returns an HRESULT of E_INVALIDARG.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>
	/// Differences between Direct3D 10 and Direct3D 11: In Direct3D 10, the presence of <c>pAdapter</c> dictated which adapter to use and
	/// the <c>DriverType</c> could mismatch what the adapter was. In Direct3D 11, if you are trying to create a hardware or a software
	/// device, set <c>pAdapter</c> != <c>NULL</c> which constrains the other inputs to be: On the other hand, if <c>pAdapter</c> ==
	/// <c>NULL</c>, the <c>DriverType</c> cannot be set to D3D_DRIVER_TYPE_UNKNOWN; it can be set to either:
	/// </description>
	/// </listheader>
	/// </list>
	/// <para></para>
	/// <para>
	/// The function signature PFN_D3D11_CREATE_DEVICE is provided as a typedef, so that you can use dynamic linking techniques
	/// (GetProcAddress) instead of statically linking.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This API is supported.</para>
	/// <para><c>Windows Phone 8.1:</c> This API is supported.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-d3d11createdevice HRESULT D3D11CreateDevice( [in, optional]
	// IDXGIAdapter *pAdapter, D3D_DRIVER_TYPE DriverType, HMODULE Software, UINT Flags, [in, optional] const D3D_FEATURE_LEVEL
	// *pFeatureLevels, UINT FeatureLevels, UINT SDKVersion, [out, optional] ID3D11Device **ppDevice, [out, optional] D3D_FEATURE_LEVEL
	// *pFeatureLevel, [out, optional] ID3D11DeviceContext **ppImmediateContext );
	[PInvokeData("d3d11.h", MSDNShortId = "NF:d3d11.D3D11CreateDevice")]
	[DllImport(Lib_D3D11, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3D11CreateDevice([In, Optional] IDXGIAdapter? pAdapter, D3D_DRIVER_TYPE DriverType,
		HINSTANCE Software, D3D11_CREATE_DEVICE_FLAG Flags, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] D3D_FEATURE_LEVEL[]? pFeatureLevels,
		uint FeatureLevels, uint SDKVersion, [Out, Optional] IntPtr ppDevice, [Out, Optional] IntPtr pFeatureLevel,
		[Out, Optional] IntPtr ppImmediateContext);

	/// <summary>Creates a device that represents the display adapter and a swap chain used for rendering.</summary>
	/// <param name="pAdapter">
	/// <para>Type: <c>IDXGIAdapter*</c></para>
	/// <para>
	/// A pointer to the video adapter to use when creating a device. Pass <c>NULL</c> to use the default adapter, which is the first
	/// adapter enumerated by IDXGIFactory1::EnumAdapters.
	/// </para>
	/// <para>
	/// <c>Note</c>  Do not mix the use of DXGI 1.0 (IDXGIFactory) and DXGI 1.1 (IDXGIFactory1) in an application. Use <c>IDXGIFactory</c>
	/// or <c>IDXGIFactory1</c>, but not both in an application.
	/// </para>
	/// <para></para>
	/// </param>
	/// <param name="DriverType">
	/// <para>Type: <c>D3D_DRIVER_TYPE</c></para>
	/// <para>The D3D_DRIVER_TYPE, which represents the driver type to create.</para>
	/// </param>
	/// <param name="Software">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// A handle to a DLL that implements a software rasterizer. If <c>DriverType</c> is <c>D3D_DRIVER_TYPE_SOFTWARE</c>, <c>Software</c>
	/// must not be <c>NULL</c>. Get the handle by calling LoadLibrary, LoadLibraryEx , or GetModuleHandle. The value should be non-
	/// <c>NULL</c> when D3D_DRIVER_TYPE is <c>D3D_DRIVER_TYPE_SOFTWARE</c> and <c>NULL</c> otherwise.
	/// </para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The runtime layers to enable (see D3D11_CREATE_DEVICE_FLAG); values can be bitwise OR'd together.</para>
	/// </param>
	/// <param name="pFeatureLevels">
	/// <para>Type: <c>const D3D_FEATURE_LEVEL*</c></para>
	/// <para>
	/// A pointer to an array of D3D_FEATURE_LEVELs, which determine the order of feature levels to attempt to create. If
	/// <c>pFeatureLevels</c> is set to <c>NULL</c>, this function uses the following array of feature levels:
	/// </para>
	/// <para>
	/// <c>Note</c>  If the Direct3D 11.1 runtime is present on the computer and <c>pFeatureLevels</c> is set to <c>NULL</c>, this function
	/// won't create a D3D_FEATURE_LEVEL_11_1 device. To create a <c>D3D_FEATURE_LEVEL_11_1</c> device, you must explicitly provide a
	/// <c>D3D_FEATURE_LEVEL</c> array that includes <c>D3D_FEATURE_LEVEL_11_1</c>. If you provide a <c>D3D_FEATURE_LEVEL</c> array that
	/// contains <c>D3D_FEATURE_LEVEL_11_1</c> on a computer that doesn't have the Direct3D 11.1 runtime installed, this function
	/// immediately fails with E_INVALIDARG.
	/// </para>
	/// <para></para>
	/// </param>
	/// <param name="FeatureLevels">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of elements in <c>pFeatureLevels</c>.</para>
	/// </param>
	/// <param name="SDKVersion">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The SDK version; use <c>D3D11_SDK_VERSION</c>.</para>
	/// </param>
	/// <param name="pSwapChainDesc">
	/// <para>Type: <c>const DXGI_SWAP_CHAIN_DESC*</c></para>
	/// <para>A pointer to a swap chain description (see DXGI_SWAP_CHAIN_DESC) that contains initialization parameters for the swap chain.</para>
	/// </param>
	/// <param name="ppSwapChain">
	/// <para>Type: <c>IDXGISwapChain**</c></para>
	/// <para>Returns the address of a pointer to the IDXGISwapChain object that represents the swap chain used for rendering.</para>
	/// </param>
	/// <param name="ppDevice">
	/// <para>Type: <c>ID3D11Device**</c></para>
	/// <para>
	/// Returns the address of a pointer to an ID3D11Device object that represents the device created. If this parameter is <c>NULL</c>, no
	/// ID3D11Device will be returned'.
	/// </para>
	/// </param>
	/// <param name="pFeatureLevel">
	/// <para>Type: <c>D3D_FEATURE_LEVEL*</c></para>
	/// <para>
	/// Returns a pointer to a D3D_FEATURE_LEVEL, which represents the first element in an array of feature levels supported by the device.
	/// Supply <c>NULL</c> as an input if you don't need to determine which feature level is supported.
	/// </para>
	/// </param>
	/// <param name="ppImmediateContext">
	/// <para>Type: <c>ID3D11DeviceContext**</c></para>
	/// <para>
	/// Returns the address of a pointer to an ID3D11DeviceContext object that represents the device context. If this parameter is
	/// <c>NULL</c>, no ID3D11DeviceContext will be returned.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method can return one of the Direct3D 11 Return Codes.</para>
	/// <para>This method returns DXGI_ERROR_NOT_CURRENTLY_AVAILABLE if you call it in a Session 0 process.</para>
	/// <para>
	/// This method returns E_INVALIDARG if you set the <c>pAdapter</c> parameter to a non- <c>NULL</c> value and the <c>DriverType</c>
	/// parameter to the D3D_DRIVER_TYPE_HARDWARE value.
	/// </para>
	/// <para>
	/// This method returns DXGI_ERROR_SDK_COMPONENT_MISSING if you specify D3D11_CREATE_DEVICE_DEBUG in <c>Flags</c> and the incorrect
	/// version of the debug layer is installed on your computer. Install the latest Windows SDK to get the correct version.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para><c>Note</c>  If you call this method in a Session 0 process, it returns DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.</para>
	/// <para></para>
	/// <para>
	/// This entry-point is supported by the Direct3D 11 runtime, which is available on Windows 7, Windows Server 2008 R2, and as an update
	/// to Windows Vista (KB971644).
	/// </para>
	/// <para>
	/// To create a Direct3D 11.1 device (ID3D11Device1), which is available on Windows 8, Windows Server 2012, and Windows 7 and Windows
	/// Server 2008 R2 with the Platform Update for Windows 7 installed, you first create a ID3D11Device with this function, and then call
	/// the QueryInterface method on the <c>ID3D11Device</c> object to obtain the <c>ID3D11Device1</c> interface.
	/// </para>
	/// <para>
	/// To create a Direct3D 11.2 device (ID3D11Device2), which is available on Windows 8.1 and Windows Server 2012 R2, you first create a
	/// ID3D11Device with this function, and then call the QueryInterface method on the <c>ID3D11Device</c> object to obtain the
	/// <c>ID3D11Device2</c> interface.
	/// </para>
	/// <para>
	/// Also, see the remarks section in D3D11CreateDevice for details about input parameter dependencies. To create a device without
	/// creating a swap chain, use the D3D11CreateDevice function.
	/// </para>
	/// <para>
	/// If you set the <c>pAdapter</c> parameter to a non- <c>NULL</c> value, you must also set the <c>DriverType</c> parameter to the
	/// D3D_DRIVER_TYPE_UNKNOWN value. If you set the <c>pAdapter</c> parameter to a non- <c>NULL</c> value and the <c>DriverType</c>
	/// parameter to the D3D_DRIVER_TYPE_HARDWARE value, <c>D3D11CreateDeviceAndSwapChain</c> returns an HRESULT of E_INVALIDARG.
	/// </para>
	/// <para>
	/// The function signature PFN_D3D11_CREATE_DEVICE_AND_SWAP_CHAIN is provided as a typedef, so that you can use dynamic linking
	/// techniques (GetProcAddress) instead of statically linking.
	/// </para>
	/// <para>Usage notes</para>
	/// <para>
	/// <c>Note</c>  The <c>D3D11CreateDeviceAndSwapChain</c> function does not exist for Windows Store apps. Instead, Windows Store apps
	/// use the D3D11CreateDevice function and then use the IDXGIFactory2::CreateSwapChainForCoreWindow method.
	/// </para>
	/// <para></para>
	/// <para>
	/// <c>Note</c>  This function has not been updated to support recent additional features of swap chain creation. For the most
	/// up-to-date swap chain creation methods, refer to the methods of IDXGIFactory2 (including CreateSwapChainForHwnd,
	/// CreateSwapChainForCoreWindow and CreateSwapChainForComposition).
	/// </para>
	/// <para></para>
	/// <para><c>Windows Phone 8:</c> This API is supported.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-d3d11createdeviceandswapchain HRESULT
	// D3D11CreateDeviceAndSwapChain( [in, optional] IDXGIAdapter *pAdapter, D3D_DRIVER_TYPE DriverType, HMODULE Software, UINT Flags, [in,
	// optional] const D3D_FEATURE_LEVEL *pFeatureLevels, UINT FeatureLevels, UINT SDKVersion, [in, optional] const DXGI_SWAP_CHAIN_DESC
	// *pSwapChainDesc, [out, optional] IDXGISwapChain **ppSwapChain, [out, optional] ID3D11Device **ppDevice, [out, optional]
	// D3D_FEATURE_LEVEL *pFeatureLevel, [out, optional] ID3D11DeviceContext **ppImmediateContext );
	[PInvokeData("d3d11.h", MSDNShortId = "NF:d3d11.D3D11CreateDeviceAndSwapChain")]
	[DllImport(Lib_D3D11, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3D11CreateDeviceAndSwapChain([In, Optional] IDXGIAdapter? pAdapter, D3D_DRIVER_TYPE DriverType, HINSTANCE Software,
		D3D11_CREATE_DEVICE_FLAG Flags, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] D3D_FEATURE_LEVEL[]? pFeatureLevels,
		uint FeatureLevels, uint SDKVersion, in DXGI_SWAP_CHAIN_DESC pSwapChainDesc, out IDXGISwapChain ppSwapChain, out ID3D11Device ppDevice,
		out D3D_FEATURE_LEVEL pFeatureLevel, out ID3D11DeviceContext ppImmediateContext);

	/// <summary>Creates a device that represents the display adapter and a swap chain used for rendering.</summary>
	/// <param name="pAdapter">
	/// <para>Type: <c>IDXGIAdapter*</c></para>
	/// <para>
	/// A pointer to the video adapter to use when creating a device. Pass <c>NULL</c> to use the default adapter, which is the first
	/// adapter enumerated by IDXGIFactory1::EnumAdapters.
	/// </para>
	/// <para>
	/// <c>Note</c>  Do not mix the use of DXGI 1.0 (IDXGIFactory) and DXGI 1.1 (IDXGIFactory1) in an application. Use <c>IDXGIFactory</c>
	/// or <c>IDXGIFactory1</c>, but not both in an application.
	/// </para>
	/// <para></para>
	/// </param>
	/// <param name="DriverType">
	/// <para>Type: <c>D3D_DRIVER_TYPE</c></para>
	/// <para>The D3D_DRIVER_TYPE, which represents the driver type to create.</para>
	/// </param>
	/// <param name="Software">
	/// <para>Type: <c>HMODULE</c></para>
	/// <para>
	/// A handle to a DLL that implements a software rasterizer. If <c>DriverType</c> is <c>D3D_DRIVER_TYPE_SOFTWARE</c>, <c>Software</c>
	/// must not be <c>NULL</c>. Get the handle by calling LoadLibrary, LoadLibraryEx , or GetModuleHandle. The value should be non-
	/// <c>NULL</c> when D3D_DRIVER_TYPE is <c>D3D_DRIVER_TYPE_SOFTWARE</c> and <c>NULL</c> otherwise.
	/// </para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The runtime layers to enable (see D3D11_CREATE_DEVICE_FLAG); values can be bitwise OR'd together.</para>
	/// </param>
	/// <param name="pFeatureLevels">
	/// <para>Type: <c>const D3D_FEATURE_LEVEL*</c></para>
	/// <para>
	/// A pointer to an array of D3D_FEATURE_LEVELs, which determine the order of feature levels to attempt to create. If
	/// <c>pFeatureLevels</c> is set to <c>NULL</c>, this function uses the following array of feature levels:
	/// </para>
	/// <para>
	/// <c>Note</c>  If the Direct3D 11.1 runtime is present on the computer and <c>pFeatureLevels</c> is set to <c>NULL</c>, this function
	/// won't create a D3D_FEATURE_LEVEL_11_1 device. To create a <c>D3D_FEATURE_LEVEL_11_1</c> device, you must explicitly provide a
	/// <c>D3D_FEATURE_LEVEL</c> array that includes <c>D3D_FEATURE_LEVEL_11_1</c>. If you provide a <c>D3D_FEATURE_LEVEL</c> array that
	/// contains <c>D3D_FEATURE_LEVEL_11_1</c> on a computer that doesn't have the Direct3D 11.1 runtime installed, this function
	/// immediately fails with E_INVALIDARG.
	/// </para>
	/// <para></para>
	/// </param>
	/// <param name="FeatureLevels">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of elements in <c>pFeatureLevels</c>.</para>
	/// </param>
	/// <param name="SDKVersion">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The SDK version; use <c>D3D11_SDK_VERSION</c>.</para>
	/// </param>
	/// <param name="pSwapChainDesc">
	/// <para>Type: <c>const DXGI_SWAP_CHAIN_DESC*</c></para>
	/// <para>A pointer to a swap chain description (see DXGI_SWAP_CHAIN_DESC) that contains initialization parameters for the swap chain.</para>
	/// </param>
	/// <param name="ppSwapChain">
	/// <para>Type: <c>IDXGISwapChain**</c></para>
	/// <para>Returns the address of a pointer to the IDXGISwapChain object that represents the swap chain used for rendering.</para>
	/// </param>
	/// <param name="ppDevice">
	/// <para>Type: <c>ID3D11Device**</c></para>
	/// <para>
	/// Returns the address of a pointer to an ID3D11Device object that represents the device created. If this parameter is <c>NULL</c>, no
	/// ID3D11Device will be returned'.
	/// </para>
	/// </param>
	/// <param name="pFeatureLevel">
	/// <para>Type: <c>D3D_FEATURE_LEVEL*</c></para>
	/// <para>
	/// Returns a pointer to a D3D_FEATURE_LEVEL, which represents the first element in an array of feature levels supported by the device.
	/// Supply <c>NULL</c> as an input if you don't need to determine which feature level is supported.
	/// </para>
	/// </param>
	/// <param name="ppImmediateContext">
	/// <para>Type: <c>ID3D11DeviceContext**</c></para>
	/// <para>
	/// Returns the address of a pointer to an ID3D11DeviceContext object that represents the device context. If this parameter is
	/// <c>NULL</c>, no ID3D11DeviceContext will be returned.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method can return one of the Direct3D 11 Return Codes.</para>
	/// <para>This method returns DXGI_ERROR_NOT_CURRENTLY_AVAILABLE if you call it in a Session 0 process.</para>
	/// <para>
	/// This method returns E_INVALIDARG if you set the <c>pAdapter</c> parameter to a non- <c>NULL</c> value and the <c>DriverType</c>
	/// parameter to the D3D_DRIVER_TYPE_HARDWARE value.
	/// </para>
	/// <para>
	/// This method returns DXGI_ERROR_SDK_COMPONENT_MISSING if you specify D3D11_CREATE_DEVICE_DEBUG in <c>Flags</c> and the incorrect
	/// version of the debug layer is installed on your computer. Install the latest Windows SDK to get the correct version.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para><c>Note</c>  If you call this method in a Session 0 process, it returns DXGI_ERROR_NOT_CURRENTLY_AVAILABLE.</para>
	/// <para></para>
	/// <para>
	/// This entry-point is supported by the Direct3D 11 runtime, which is available on Windows 7, Windows Server 2008 R2, and as an update
	/// to Windows Vista (KB971644).
	/// </para>
	/// <para>
	/// To create a Direct3D 11.1 device (ID3D11Device1), which is available on Windows 8, Windows Server 2012, and Windows 7 and Windows
	/// Server 2008 R2 with the Platform Update for Windows 7 installed, you first create a ID3D11Device with this function, and then call
	/// the QueryInterface method on the <c>ID3D11Device</c> object to obtain the <c>ID3D11Device1</c> interface.
	/// </para>
	/// <para>
	/// To create a Direct3D 11.2 device (ID3D11Device2), which is available on Windows 8.1 and Windows Server 2012 R2, you first create a
	/// ID3D11Device with this function, and then call the QueryInterface method on the <c>ID3D11Device</c> object to obtain the
	/// <c>ID3D11Device2</c> interface.
	/// </para>
	/// <para>
	/// Also, see the remarks section in D3D11CreateDevice for details about input parameter dependencies. To create a device without
	/// creating a swap chain, use the D3D11CreateDevice function.
	/// </para>
	/// <para>
	/// If you set the <c>pAdapter</c> parameter to a non- <c>NULL</c> value, you must also set the <c>DriverType</c> parameter to the
	/// D3D_DRIVER_TYPE_UNKNOWN value. If you set the <c>pAdapter</c> parameter to a non- <c>NULL</c> value and the <c>DriverType</c>
	/// parameter to the D3D_DRIVER_TYPE_HARDWARE value, <c>D3D11CreateDeviceAndSwapChain</c> returns an HRESULT of E_INVALIDARG.
	/// </para>
	/// <para>
	/// The function signature PFN_D3D11_CREATE_DEVICE_AND_SWAP_CHAIN is provided as a typedef, so that you can use dynamic linking
	/// techniques (GetProcAddress) instead of statically linking.
	/// </para>
	/// <para>Usage notes</para>
	/// <para>
	/// <c>Note</c>  The <c>D3D11CreateDeviceAndSwapChain</c> function does not exist for Windows Store apps. Instead, Windows Store apps
	/// use the D3D11CreateDevice function and then use the IDXGIFactory2::CreateSwapChainForCoreWindow method.
	/// </para>
	/// <para></para>
	/// <para>
	/// <c>Note</c>  This function has not been updated to support recent additional features of swap chain creation. For the most
	/// up-to-date swap chain creation methods, refer to the methods of IDXGIFactory2 (including CreateSwapChainForHwnd,
	/// CreateSwapChainForCoreWindow and CreateSwapChainForComposition).
	/// </para>
	/// <para></para>
	/// <para><c>Windows Phone 8:</c> This API is supported.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-d3d11createdeviceandswapchain HRESULT
	// D3D11CreateDeviceAndSwapChain( [in, optional] IDXGIAdapter *pAdapter, D3D_DRIVER_TYPE DriverType, HMODULE Software, UINT Flags, [in,
	// optional] const D3D_FEATURE_LEVEL *pFeatureLevels, UINT FeatureLevels, UINT SDKVersion, [in, optional] const DXGI_SWAP_CHAIN_DESC
	// *pSwapChainDesc, [out, optional] IDXGISwapChain **ppSwapChain, [out, optional] ID3D11Device **ppDevice, [out, optional]
	// D3D_FEATURE_LEVEL *pFeatureLevel, [out, optional] ID3D11DeviceContext **ppImmediateContext );
	[PInvokeData("d3d11.h", MSDNShortId = "NF:d3d11.D3D11CreateDeviceAndSwapChain")]
	[DllImport(Lib_D3D11, SetLastError = false, ExactSpelling = true)]
	public static extern unsafe HRESULT D3D11CreateDeviceAndSwapChain([In, Optional] IDXGIAdapter? pAdapter, D3D_DRIVER_TYPE DriverType, HINSTANCE Software,
		D3D11_CREATE_DEVICE_FLAG Flags, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] D3D_FEATURE_LEVEL[]? pFeatureLevels,
		uint FeatureLevels, uint SDKVersion, [In, Optional] DXGI_SWAP_CHAIN_DESC* pSwapChainDesc, [Out, Optional] IntPtr ppSwapChain,
		[Out, Optional] IntPtr ppDevice, [Out, Optional] D3D_FEATURE_LEVEL* pFeatureLevel, [Out, Optional] IntPtr ppImmediateContext);

	/// <summary>
	/// Creates a device that uses Direct3D 11 functionality in Direct3D 12, specifying a pre-existing Direct3D 12 device to use for
	/// Direct3D 11 interop.
	/// </summary>
	/// <param name="pDevice">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>Specifies a pre-existing Direct3D 12 device to use for Direct3D 11 interop. May not be NULL.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// One or more bitwise OR'd flags from D3D11_CREATE_DEVICE_FLAG. These are the same flags as those used by
	/// D3D11CreateDeviceAndSwapChain. Specifies which runtime layers to enable. <c>Flags</c> must be compatible with device flags, and its
	/// <c>NodeMask</c> must be a subset of the <c>NodeMask</c> provided to the present API.
	/// </para>
	/// </param>
	/// <param name="pFeatureLevels">
	/// <para>Type: <c>const D3D_FEATURE_LEVEL*</c></para>
	/// <para>An array of any of the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_12_1</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_12_0</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_11_1</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_11_0</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_10_1</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_10_0</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_9_3</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_9_2</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_9_1</description>
	/// </item>
	/// </list>
	/// <para>
	/// The first feature level that is less than or equal to the Direct3D 12 device's feature level will be used to perform Direct3D 11
	/// validation. Creation will fail if no acceptable feature levels are provided. Providing NULL will default to the Direct3D 12 device's
	/// feature level.
	/// </para>
	/// </param>
	/// <param name="FeatureLevels">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size of (that is, the number of elements in) the pFeatureLevels array.</para>
	/// </param>
	/// <param name="ppCommandQueues">
	/// <para>Type: <c>IUnknown* const *</c></para>
	/// <para>An array of unique queues for D3D11On12 to use. The queues must be of the 3D command queue type.</para>
	/// </param>
	/// <param name="NumQueues">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size of (that is, the number of elements in) the ppCommandQueues array.</para>
	/// </param>
	/// <param name="NodeMask">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Which node of the Direct3D 12 device to use. Only 1 bit may be set.</para>
	/// </param>
	/// <param name="ppDevice">
	/// <para>Type: <c>ID3D11Device**</c></para>
	/// <para>Pointer to the returned ID3D11Device. May be NULL.</para>
	/// </param>
	/// <param name="ppImmediateContext">
	/// <para>Type: <c>ID3D11DeviceContext**</c></para>
	/// <para>A pointer to the returned ID3D11DeviceContext. May be NULL.</para>
	/// </param>
	/// <param name="pChosenFeatureLevel">
	/// <para>Type: <c>D3D_FEATURE_LEVEL*</c></para>
	/// <para>A pointer to the returned feature level. May be NULL.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method returns one of the Direct3D 12 Return Codes that are documented for D3D11CreateDevice.</para>
	/// <para>
	/// This method returns DXGI_ERROR_SDK_COMPONENT_MISSING if you specify D3D11_CREATE_DEVICE_DEBUG in <c>Flags</c> and the incorrect
	/// version of the debug layer is installed on your computer. Install the latest Windows SDK to get the correct version.
	/// </para>
	/// </returns>
	/// <remarks>
	/// The function signature PFN_D3D11ON12_CREATE_DEVICE is provided as a typedef, so that you can use dynamic linking techniques
	/// (GetProcAddress) instead of statically linking.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nf-d3d11on12-d3d11on12createdevice HRESULT D3D11On12CreateDevice( [in]
	// IUnknown *pDevice, UINT Flags, [in, optional] const D3D_FEATURE_LEVEL *pFeatureLevels, UINT FeatureLevels, [in, optional] IUnknown *
	// const *ppCommandQueues, UINT NumQueues, UINT NodeMask, [out, optional] ID3D11Device **ppDevice, [out, optional] ID3D11DeviceContext
	// **ppImmediateContext, [out, optional] D3D_FEATURE_LEVEL *pChosenFeatureLevel );
	[PInvokeData("d3d11on12.h", MSDNShortId = "NF:d3d11on12.D3D11On12CreateDevice")]
	[DllImport(Lib_D3D11, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3D11On12CreateDevice([In, MarshalAs(UnmanagedType.Interface)] object pDevice, D3D11_CREATE_DEVICE_FLAG Flags,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D_FEATURE_LEVEL[]? pFeatureLevels, uint FeatureLevels,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 5)] object[]? ppCommandQueues,
		uint NumQueues, uint NodeMask, [Out, Optional] IntPtr ppDevice, [Out, Optional] IntPtr ppImmediateContext, [Out, Optional] IntPtr pChosenFeatureLevel);

	/// <summary>
	/// Creates a device that uses Direct3D 11 functionality in Direct3D 12, specifying a pre-existing Direct3D 12 device to use for
	/// Direct3D 11 interop.
	/// </summary>
	/// <param name="pDevice">
	/// <para>Type: <c>IUnknown*</c></para>
	/// <para>Specifies a pre-existing Direct3D 12 device to use for Direct3D 11 interop. May not be NULL.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// One or more bitwise OR'd flags from D3D11_CREATE_DEVICE_FLAG. These are the same flags as those used by
	/// D3D11CreateDeviceAndSwapChain. Specifies which runtime layers to enable. <c>Flags</c> must be compatible with device flags, and its
	/// <c>NodeMask</c> must be a subset of the <c>NodeMask</c> provided to the present API.
	/// </para>
	/// </param>
	/// <param name="pFeatureLevels">
	/// <para>Type: <c>const D3D_FEATURE_LEVEL*</c></para>
	/// <para>An array of any of the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_12_1</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_12_0</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_11_1</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_11_0</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_10_1</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_10_0</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_9_3</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_9_2</description>
	/// </item>
	/// <item>
	/// <description>D3D_FEATURE_LEVEL_9_1</description>
	/// </item>
	/// </list>
	/// <para>
	/// The first feature level that is less than or equal to the Direct3D 12 device's feature level will be used to perform Direct3D 11
	/// validation. Creation will fail if no acceptable feature levels are provided. Providing NULL will default to the Direct3D 12 device's
	/// feature level.
	/// </para>
	/// </param>
	/// <param name="FeatureLevels">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size of (that is, the number of elements in) the pFeatureLevels array.</para>
	/// </param>
	/// <param name="ppCommandQueues">
	/// <para>Type: <c>IUnknown* const *</c></para>
	/// <para>An array of unique queues for D3D11On12 to use. The queues must be of the 3D command queue type.</para>
	/// </param>
	/// <param name="NumQueues">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size of (that is, the number of elements in) the ppCommandQueues array.</para>
	/// </param>
	/// <param name="NodeMask">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Which node of the Direct3D 12 device to use. Only 1 bit may be set.</para>
	/// </param>
	/// <param name="ppDevice">
	/// <para>Type: <c>ID3D11Device**</c></para>
	/// <para>Pointer to the returned ID3D11Device. May be NULL.</para>
	/// </param>
	/// <param name="ppImmediateContext">
	/// <para>Type: <c>ID3D11DeviceContext**</c></para>
	/// <para>A pointer to the returned ID3D11DeviceContext. May be NULL.</para>
	/// </param>
	/// <param name="pChosenFeatureLevel">
	/// <para>Type: <c>D3D_FEATURE_LEVEL*</c></para>
	/// <para>A pointer to the returned feature level. May be NULL.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This method returns one of the Direct3D 12 Return Codes that are documented for D3D11CreateDevice.</para>
	/// <para>
	/// This method returns DXGI_ERROR_SDK_COMPONENT_MISSING if you specify D3D11_CREATE_DEVICE_DEBUG in <c>Flags</c> and the incorrect
	/// version of the debug layer is installed on your computer. Install the latest Windows SDK to get the correct version.
	/// </para>
	/// </returns>
	/// <remarks>
	/// The function signature PFN_D3D11ON12_CREATE_DEVICE is provided as a typedef, so that you can use dynamic linking techniques
	/// (GetProcAddress) instead of statically linking.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11on12/nf-d3d11on12-d3d11on12createdevice HRESULT D3D11On12CreateDevice( [in]
	// IUnknown *pDevice, UINT Flags, [in, optional] const D3D_FEATURE_LEVEL *pFeatureLevels, UINT FeatureLevels, [in, optional] IUnknown *
	// const *ppCommandQueues, UINT NumQueues, UINT NodeMask, [out, optional] ID3D11Device **ppDevice, [out, optional] ID3D11DeviceContext
	// **ppImmediateContext, [out, optional] D3D_FEATURE_LEVEL *pChosenFeatureLevel );
	[PInvokeData("d3d11on12.h", MSDNShortId = "NF:d3d11on12.D3D11On12CreateDevice")]
	[DllImport(Lib_D3D11, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3D11On12CreateDevice([In, MarshalAs(UnmanagedType.Interface)] object pDevice, D3D11_CREATE_DEVICE_FLAG Flags,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D_FEATURE_LEVEL[]? pFeatureLevels, uint FeatureLevels,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 5)] object[]? ppCommandQueues,
		uint NumQueues, uint NodeMask, out ID3D11Device ppDevice, out ID3D11DeviceContext ppImmediateContext, out D3D_FEATURE_LEVEL pChosenFeatureLevel);

	/// <summary>Contains the response from the ID3D11VideoContext::ConfigureAuthenticatedChannel method.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_authenticated_configure_output typedef struct
	// D3D11_AUTHENTICATED_CONFIGURE_OUTPUT { D3D11_OMAC omac; GUID ConfigureType; HANDLE hChannel; UINT SequenceNumber; HRESULT ReturnCode;
	// } D3D11_AUTHENTICATED_CONFIGURE_OUTPUT;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_AUTHENTICATED_CONFIGURE_OUTPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_AUTHENTICATED_CONFIGURE_OUTPUT
	{
		/// <summary>
		/// A D3D11_OMAC structure that contains a Message Authentication Code (MAC) of the data. The driver uses AES-based one-key CBC MAC
		/// (OMAC) to calculate this value for the block of data that appears after this structure member.
		/// </summary>
		public D3D11_OMAC omac;

		/// <summary>A GUID that specifies the command. For a list of GUIDs, see D3D11_AUTHENTICATED_CONFIGURE_INPUT.</summary>
		public Guid ConfigureType;

		/// <summary>A handle to the authenticated channel.</summary>
		public HANDLE hChannel;

		/// <summary>The command sequence number.</summary>
		public uint SequenceNumber;

		/// <summary>The result code for the command.</summary>
		public HRESULT ReturnCode;
	}

	/// <summary>Describes the blend state that you use in a call to ID3D11Device::CreateBlendState to create a blend-state object.</summary>
	/// <remarks>
	/// <para>Here are the default values for blend state.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>State</description>
	/// <description>Default Value</description>
	/// </listheader>
	/// <item>
	/// <description>AlphaToCoverageEnable</description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description>IndependentBlendEnable</description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].BlendEnable</description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].SrcBlend</description>
	/// <description>D3D11_BLEND_ONE</description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].DestBlend</description>
	/// <description>D3D11_BLEND_ZERO</description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].BlendOp</description>
	/// <description>D3D11_BLEND_OP_ADD</description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].SrcBlendAlpha</description>
	/// <description>D3D11_BLEND_ONE</description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].DestBlendAlpha</description>
	/// <description>D3D11_BLEND_ZERO</description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].BlendOpAlpha</description>
	/// <description>D3D11_BLEND_OP_ADD</description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].RenderTargetWriteMask</description>
	/// <description>D3D11_COLOR_WRITE_ENABLE_ALL</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para><c>Note</c>   <c>D3D11_BLEND_DESC</c> is identical to D3D10_BLEND_DESC1.</para>
	/// <para></para>
	/// <para>
	/// If the driver type is set to D3D_DRIVER_TYPE_HARDWARE, the feature level is set to less than or equal to D3D_FEATURE_LEVEL_9_3, and
	/// the pixel format of the render target is set to DXGI_FORMAT_R8G8B8A8_UNORM_SRGB, <c>DXGI_FORMAT_B8G8R8A8_UNORM_SRGB</c>, or
	/// <c>DXGI_FORMAT_B8G8R8X8_UNORM_SRGB</c>, the display device performs the blend in standard RGB (sRGB) space and not in linear space.
	/// However, if the feature level is set to greater than <c>D3D_FEATURE_LEVEL_9_3</c>, the display device performs the blend in linear
	/// space, which is ideal.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_blend_desc typedef struct D3D11_BLEND_DESC { BOOL
	// AlphaToCoverageEnable; BOOL IndependentBlendEnable; D3D11_RENDER_TARGET_BLEND_DESC RenderTarget[8]; } D3D11_BLEND_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_BLEND_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_BLEND_DESC
	{
		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Specifies whether to use alpha-to-coverage as a multisampling technique when setting a pixel to a render target. For more info
		/// about using alpha-to-coverage, see Alpha-To-Coverage.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool AlphaToCoverageEnable;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Specifies whether to enable independent blending in simultaneous render targets. Set to <c>TRUE</c> to enable independent
		/// blending. If set to <c>FALSE</c>, only the RenderTarget[0] members are used; RenderTarget[1..7] are ignored.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool IndependentBlendEnable;

		/// <summary>
		/// <para>Type: <c>D3D11_RENDER_TARGET_BLEND_DESC[8]</c></para>
		/// <para>
		/// An array of D3D11_RENDER_TARGET_BLEND_DESC structures that describe the blend states for render targets; these correspond to the
		/// eight render targets that can be bound to the output-merger stage at one time.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public D3D11_RENDER_TARGET_BLEND_DESC[] RenderTarget;
	}

	/// <summary>Defines a 3D box.</summary>
	/// <remarks>
	/// <para>The following diagram shows a 3D box, where the origin is the left, front, top corner.</para>
	/// <para>
	/// The values for <c>right</c>, <c>bottom</c>, and <c>back</c> are each one pixel past the end of the pixels that are included in the
	/// box region. That is, the values for <c>left</c>, <c>top</c>, and <c>front</c> are included in the box region while the values for
	/// right, bottom, and back are excluded from the box region. For example, for a box that is one pixel wide, (right - left) == 1; the
	/// box region includes the left pixel but not the right pixel.
	/// </para>
	/// <para>Coordinates of a box are in bytes for buffers and in texels for textures.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_box typedef struct D3D11_BOX { UINT left; UINT top; UINT
	// front; UINT right; UINT bottom; UINT back; } D3D11_BOX;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_BOX")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_BOX
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The x position of the left hand side of the box.</para>
		/// </summary>
		public uint left;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The y position of the top of the box.</para>
		/// </summary>
		public uint top;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The z position of the front of the box.</para>
		/// </summary>
		public uint front;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The x position of the right hand side of the box.</para>
		/// </summary>
		public uint right;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The y position of the bottom of the box.</para>
		/// </summary>
		public uint bottom;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The z position of the back of the box.</para>
		/// </summary>
		public uint back;
	}

	/// <summary>Describes a buffer resource.</summary>
	/// <remarks>
	/// <para>This structure is used by ID3D11Device::CreateBuffer to create buffer resources.</para>
	/// <para>
	/// In addition to this structure, you can also use the CD3D11_BUFFER_DESC derived structure, which is defined in D3D11.h and behaves
	/// like an inherited class, to help create a buffer description.
	/// </para>
	/// <para>
	/// If the bind flag is D3D11_BIND_CONSTANT_BUFFER, you must set the <c>ByteWidth</c> value in multiples of 16, and less than or equal
	/// to <c>D3D11_REQ_CONSTANT_BUFFER_ELEMENT_COUNT</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_buffer_desc typedef struct D3D11_BUFFER_DESC { UINT
	// ByteWidth; D3D11_USAGE Usage; UINT BindFlags; UINT CPUAccessFlags; UINT MiscFlags; UINT StructureByteStride; } D3D11_BUFFER_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_BUFFER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_BUFFER_DESC
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Size of the buffer in bytes.</para>
		/// </summary>
		public uint ByteWidth;

		/// <summary>
		/// <para>Type: <c>D3D11_USAGE</c></para>
		/// <para>
		/// Identify how the buffer is expected to be read from and written to. Frequency of update is a key factor. The most common value
		/// is typically D3D11_USAGE_DEFAULT; see D3D11_USAGE for all possible values.
		/// </para>
		/// </summary>
		public D3D11_USAGE Usage;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Identify how the buffer will be bound to the pipeline. Flags (see D3D11_BIND_FLAG) can be combined with a bitwise OR.</para>
		/// </summary>
		public D3D11_BIND_FLAG BindFlags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// CPU access flags (see D3D11_CPU_ACCESS_FLAG) or 0 if no CPU access is necessary. Flags can be combined with a bitwise OR.
		/// </para>
		/// </summary>
		public D3D11_CPU_ACCESS_FLAG CPUAccessFlags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Miscellaneous flags (see D3D11_RESOURCE_MISC_FLAG) or 0 if unused. Flags can be combined with a bitwise OR.</para>
		/// </summary>
		public D3D11_RESOURCE_MISC_FLAG MiscFlags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The size of each element in the buffer structure (in bytes) when the buffer represents a structured buffer. For more info about
		/// structured buffers, see Structured Buffer.
		/// </para>
		/// <para>
		/// The size value in <c>StructureByteStride</c> must match the size of the format that you use for views of the buffer. For
		/// example, if you use a shader resource view (SRV) to read a buffer in a pixel shader, the SRV format size must match the size
		/// value in <c>StructureByteStride</c>.
		/// </para>
		/// </summary>
		public uint StructureByteStride;
	}

	/// <summary>Specifies the elements in a buffer resource to use in a render-target view.</summary>
	/// <remarks>
	/// A render-target view is a member of a render-target-view description (see D3D11_RENDER_TARGET_VIEW_DESC). Create a render-target
	/// view by calling ID3D11Device::CreateRenderTargetView.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_buffer_rtv typedef struct D3D11_BUFFER_RTV { union { UINT
	// FirstElement; UINT ElementOffset; }; union { UINT NumElements; UINT ElementWidth; }; } D3D11_BUFFER_RTV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_BUFFER_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_BUFFER_RTV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of bytes between the beginning of the buffer and the first element to access.</para>
		/// </summary>
		public uint FirstElement;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The offset of the first element in the view to access, relative to element 0.</para>
		/// </summary>
		public uint ElementOffset;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The total number of elements in the view.</para>
		/// </summary>
		public uint NumElements;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width of each element (in bytes). This can be determined from the format stored in the render-target-view description.</para>
		/// </summary>
		public uint ElementWidth;
	}

	/// <summary>Specifies the elements in a buffer resource to use in a shader-resource view.</summary>
	/// <remarks>
	/// The <c>D3D11_BUFFER_SRV</c> structure is a member of the D3D11_SHADER_RESOURCE_VIEW_DESC structure, which represents a
	/// shader-resource view description. You can create a shader-resource view by calling the ID3D11Device::CreateShaderResourceView method.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_buffer_srv typedef struct D3D11_BUFFER_SRV { union { UINT
	// FirstElement; UINT ElementOffset; }; union { UINT NumElements; UINT ElementWidth; }; } D3D11_BUFFER_SRV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_BUFFER_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_BUFFER_SRV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Index of the first element to access.</para>
		/// </summary>
		public uint FirstElement;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The offset of the first element in the view to access, relative to element 0.</para>
		/// </summary>
		public uint ElementOffset;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The total number of elements in the view.</para>
		/// </summary>
		public uint NumElements;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The width of each element (in bytes). This can be determined from the format stored in the shader-resource-view description.</para>
		/// </summary>
		public uint ElementWidth;
	}

	/// <summary>Describes the elements in a buffer to use in a unordered-access view.</summary>
	/// <remarks>This structure is used by a D3D11_UNORDERED_ACCESS_VIEW_DESC.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_buffer_uav typedef struct D3D11_BUFFER_UAV { UINT
	// FirstElement; UINT NumElements; UINT Flags; } D3D11_BUFFER_UAV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_BUFFER_UAV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_BUFFER_UAV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The zero-based index of the first element to be accessed.</para>
		/// </summary>
		public uint FirstElement;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in the resource. For structured buffers, this is the number of structures in the buffer.</para>
		/// </summary>
		public uint NumElements;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>View options for the resource (see D3D11_BUFFER_UAV_FLAG).</para>
		/// </summary>
		public D3D11_BUFFER_UAV_FLAG Flags;
	}

	/// <summary>Describes the elements in a raw buffer resource to use in a shader-resource view.</summary>
	/// <remarks>This structure is used by D3D11_SHADER_RESOURCE_VIEW_DESC to create a raw view of a buffer.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_bufferex_srv typedef struct D3D11_BUFFEREX_SRV { UINT
	// FirstElement; UINT NumElements; UINT Flags; } D3D11_BUFFEREX_SRV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_BUFFEREX_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_BUFFEREX_SRV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the first element to be accessed by the view.</para>
		/// </summary>
		public uint FirstElement;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in the resource.</para>
		/// </summary>
		public uint NumElements;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A D3D11_BUFFEREX_SRV_FLAG-typed value that identifies view options for the buffer. Currently, the only option is to identify a
		/// raw view of the buffer. For more info about raw viewing of buffers, see Raw Views of Buffers.
		/// </para>
		/// </summary>
		public D3D11_BUFFEREX_SRV_FLAG Flags;
	}

	/// <summary>Describes an HLSL class instance.</summary>
	/// <remarks>
	/// <para>The D3D11_CLASS_INSTANCE_DESC structure is returned by the ID3D11ClassInstance::GetDesc method.</para>
	/// <para>
	/// The members of this structure except <c>InstanceIndex</c> are valid (non default values) if they describe a class instance acquired
	/// using ID3D11ClassLinkage::CreateClassInstance. The <c>InstanceIndex</c> member is only valid when the class instance is aquired
	/// using ID3D11ClassLinkage::GetClassInstance.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_class_instance_desc typedef struct D3D11_CLASS_INSTANCE_DESC
	// { UINT InstanceId; UINT InstanceIndex; UINT TypeId; UINT ConstantBuffer; UINT BaseConstantBufferOffset; UINT BaseTexture; UINT
	// BaseSampler; BOOL Created; } D3D11_CLASS_INSTANCE_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_CLASS_INSTANCE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_CLASS_INSTANCE_DESC
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The instance ID of an HLSL class; the default value is 0.</para>
		/// </summary>
		public uint InstanceId;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The instance index of an HLSL class; the default value is 0.</para>
		/// </summary>
		public uint InstanceIndex;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The type ID of an HLSL class; the default value is 0.</para>
		/// </summary>
		public uint TypeId;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Describes the constant buffer associated with an HLSL class; the default value is 0.</para>
		/// </summary>
		public uint ConstantBuffer;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The base constant buffer offset associated with an HLSL class; the default value is 0.</para>
		/// </summary>
		public uint BaseConstantBufferOffset;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The base texture associated with an HLSL class; the default value is 127.</para>
		/// </summary>
		public uint BaseTexture;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The base sampler associated with an HLSL class; the default value is 15.</para>
		/// </summary>
		public uint BaseSampler;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if the class was created; the default value is false.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool Created;
	}

	/// <summary>Describes a counter.</summary>
	/// <remarks>This structure is used by ID3D11Counter::GetDesc, ID3D11Device::CheckCounter and ID3D11Device::CreateCounter.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_counter_desc typedef struct D3D11_COUNTER_DESC {
	// D3D11_COUNTER Counter; UINT MiscFlags; } D3D11_COUNTER_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_COUNTER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_COUNTER_DESC
	{
		/// <summary>
		/// <para>Type: <c>D3D11_COUNTER</c></para>
		/// <para>Type of counter (see D3D11_COUNTER).</para>
		/// </summary>
		public D3D11_COUNTER Counter;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Reserved.</para>
		/// </summary>
		public uint MiscFlags;
	}

	/// <summary>Information about the video card's performance counter capabilities.</summary>
	/// <remarks>This structure is returned by ID3D11Device::CheckCounterInfo.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_counter_info typedef struct D3D11_COUNTER_INFO {
	// D3D11_COUNTER LastDeviceDependentCounter; UINT NumSimultaneousCounters; UINT8 NumDetectableParallelUnits; } D3D11_COUNTER_INFO;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_COUNTER_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_COUNTER_INFO
	{
		/// <summary>
		/// <para>Type: <c>D3D11_COUNTER</c></para>
		/// <para>
		/// Largest device-dependent counter ID that the device supports. If none are supported, this value will be 0. Otherwise it will be
		/// greater than or equal to D3D11_COUNTER_DEVICE_DEPENDENT_0. See D3D11_COUNTER.
		/// </para>
		/// </summary>
		public D3D11_COUNTER LastDeviceDependentCounter;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of counters that can be simultaneously supported.</para>
		/// </summary>
		public uint NumSimultaneousCounters;

		/// <summary>
		/// <para>Type: <c>UINT8</c></para>
		/// <para>
		/// Number of detectable parallel units that the counter is able to discern. Values are 1 ~ 4. Use NumDetectableParallelUnits to
		/// interpret the values of the VERTEX_PROCESSING, GEOMETRY_PROCESSING, PIXEL_PROCESSING, and OTHER_GPU_PROCESSING counters.
		/// </para>
		/// </summary>
		public byte NumDetectableParallelUnits;
	}

	/// <summary>Describes depth-stencil state.</summary>
	/// <remarks>
	/// <para>
	/// Pass a pointer to <c>D3D11_DEPTH_STENCIL_DESC</c> to the ID3D11Device::CreateDepthStencilState method to create the depth-stencil
	/// state object.
	/// </para>
	/// <para>Depth-stencil state controls how depth-stencil testing is performed by the output-merger stage.</para>
	/// <para>The following table shows the default values of depth-stencil states.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>State</description>
	/// <description>Default Value</description>
	/// </listheader>
	/// <item>
	/// <description>DepthEnable</description>
	/// <description>TRUE</description>
	/// </item>
	/// <item>
	/// <description>DepthWriteMask</description>
	/// <description>D3D11_DEPTH_WRITE_MASK_ALL</description>
	/// </item>
	/// <item>
	/// <description>DepthFunc</description>
	/// <description>D3D11_COMPARISON_LESS</description>
	/// </item>
	/// <item>
	/// <description>StencilEnable</description>
	/// <description>FALSE</description>
	/// </item>
	/// <item>
	/// <description>StencilReadMask</description>
	/// <description>D3D11_DEFAULT_STENCIL_READ_MASK</description>
	/// </item>
	/// <item>
	/// <description>StencilWriteMask</description>
	/// <description>D3D11_DEFAULT_STENCIL_WRITE_MASK</description>
	/// </item>
	/// <item>
	/// <description>FrontFace.StencilFunc and BackFace.StencilFunc</description>
	/// <description>D3D11_COMPARISON_ALWAYS</description>
	/// </item>
	/// <item>
	/// <description>FrontFace.StencilDepthFailOp and BackFace.StencilDepthFailOp</description>
	/// <description>D3D11_STENCIL_OP_KEEP</description>
	/// </item>
	/// <item>
	/// <description>FrontFace.StencilPassOp and BackFace.StencilPassOp</description>
	/// <description>D3D11_STENCIL_OP_KEEP</description>
	/// </item>
	/// <item>
	/// <description>FrontFace.StencilFailOp and BackFace.StencilFailOp</description>
	/// <description>D3D11_STENCIL_OP_KEEP</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>The formats that support stenciling are DXGI_FORMAT_D24_UNORM_S8_UINT and DXGI_FORMAT_D32_FLOAT_S8X24_UINT.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_depth_stencil_desc typedef struct D3D11_DEPTH_STENCIL_DESC {
	// BOOL DepthEnable; D3D11_DEPTH_WRITE_MASK DepthWriteMask; D3D11_COMPARISON_FUNC DepthFunc; BOOL StencilEnable; UINT8 StencilReadMask;
	// UINT8 StencilWriteMask; D3D11_DEPTH_STENCILOP_DESC FrontFace; D3D11_DEPTH_STENCILOP_DESC BackFace; } D3D11_DEPTH_STENCIL_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_DEPTH_STENCIL_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_DEPTH_STENCIL_DESC
	{
		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Enable depth testing.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool DepthEnable;

		/// <summary>
		/// <para>Type: <c>D3D11_DEPTH_WRITE_MASK</c></para>
		/// <para>Identify a portion of the depth-stencil buffer that can be modified by depth data (see D3D11_DEPTH_WRITE_MASK).</para>
		/// </summary>
		public D3D11_DEPTH_WRITE_MASK DepthWriteMask;

		/// <summary>
		/// <para>Type: <c>D3D11_COMPARISON_FUNC</c></para>
		/// <para>A function that compares depth data against existing depth data. The function options are listed in D3D11_COMPARISON_FUNC.</para>
		/// </summary>
		public D3D11_COMPARISON_FUNC DepthFunc;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Enable stencil testing.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool StencilEnable;

		/// <summary>
		/// <para>Type: <c>UINT8</c></para>
		/// <para>Identify a portion of the depth-stencil buffer for reading stencil data.</para>
		/// </summary>
		public byte StencilReadMask;

		/// <summary>
		/// <para>Type: <c>UINT8</c></para>
		/// <para>Identify a portion of the depth-stencil buffer for writing stencil data.</para>
		/// </summary>
		public byte StencilWriteMask;

		/// <summary>
		/// <para>Type: <c>D3D11_DEPTH_STENCILOP_DESC</c></para>
		/// <para>
		/// Identify how to use the results of the depth test and the stencil test for pixels whose surface normal is facing towards the
		/// camera (see D3D11_DEPTH_STENCILOP_DESC).
		/// </para>
		/// </summary>
		public D3D11_DEPTH_STENCILOP_DESC FrontFace;

		/// <summary>
		/// <para>Type: <c>D3D11_DEPTH_STENCILOP_DESC</c></para>
		/// <para>
		/// Identify how to use the results of the depth test and the stencil test for pixels whose surface normal is facing away from the
		/// camera (see D3D11_DEPTH_STENCILOP_DESC).
		/// </para>
		/// </summary>
		public D3D11_DEPTH_STENCILOP_DESC BackFace;
	}

	/// <summary>Specifies the subresources of a texture that are accessible from a depth-stencil view.</summary>
	/// <remarks>
	/// <para>These are valid formats for a depth-stencil view:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>DXGI_FORMAT_D16_UNORM</description>
	/// </item>
	/// <item>
	/// <description>DXGI_FORMAT_D24_UNORM_S8_UINT</description>
	/// </item>
	/// <item>
	/// <description>DXGI_FORMAT_D32_FLOAT</description>
	/// </item>
	/// <item>
	/// <description>DXGI_FORMAT_D32_FLOAT_S8X24_UINT</description>
	/// </item>
	/// <item>
	/// <description>DXGI_FORMAT_UNKNOWN</description>
	/// </item>
	/// </list>
	/// <para>
	/// A depth-stencil view cannot use a typeless format. If the format chosen is DXGI_FORMAT_UNKNOWN, then the format of the parent
	/// resource is used.
	/// </para>
	/// <para>A depth-stencil-view description is needed when calling ID3D11Device::CreateDepthStencilView.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_depth_stencil_view_desc typedef struct
	// D3D11_DEPTH_STENCIL_VIEW_DESC { DXGI_FORMAT Format; D3D11_DSV_DIMENSION ViewDimension; UINT Flags; union { D3D11_TEX1D_DSV Texture1D;
	// D3D11_TEX1D_ARRAY_DSV Texture1DArray; D3D11_TEX2D_DSV Texture2D; D3D11_TEX2D_ARRAY_DSV Texture2DArray; D3D11_TEX2DMS_DSV Texture2DMS;
	// D3D11_TEX2DMS_ARRAY_DSV Texture2DMSArray; }; } D3D11_DEPTH_STENCIL_VIEW_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_DEPTH_STENCIL_VIEW_DESC")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D11_DEPTH_STENCIL_VIEW_DESC
	{
		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>Resource data format (see DXGI_FORMAT). See remarks for allowable formats.</para>
		/// </summary>
		[FieldOffset(0)]
		public DXGI_FORMAT Format;

		/// <summary>
		/// <para>Type: <c>D3D11_DSV_DIMENSION</c></para>
		/// <para>
		/// Type of resource (see D3D11_DSV_DIMENSION). Specifies how a depth-stencil resource will be accessed; the value is stored in the
		/// union in this structure.
		/// </para>
		/// </summary>
		[FieldOffset(4)]
		public D3D11_DSV_DIMENSION ViewDimension;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A value that describes whether the texture is read only. Pass 0 to specify that it is not read only; otherwise, pass one of the
		/// members of the D3D11_DSV_FLAG enumerated type.
		/// </para>
		/// </summary>
		[FieldOffset(8)]
		public D3D11_DSV_FLAG Flags;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX1D_DSV</c></para>
		/// <para>Specifies a 1D texture subresource (see D3D11_TEX1D_DSV).</para>
		/// </summary>
		[FieldOffset(12)]
		public D3D11_TEX1D_DSV Texture1D;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX1D_ARRAY_DSV</c></para>
		/// <para>Specifies an array of 1D texture subresources (see D3D11_TEX1D_ARRAY_DSV).</para>
		/// </summary>
		[FieldOffset(12)]
		public D3D11_TEX1D_ARRAY_DSV Texture1DArray;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX2D_DSV</c></para>
		/// <para>Specifies a 2D texture subresource (see D3D11_TEX2D_DSV).</para>
		/// </summary>
		[FieldOffset(12)]
		public D3D11_TEX2D_DSV Texture2D;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX2D_ARRAY_DSV</c></para>
		/// <para>Specifies an array of 2D texture subresources (see D3D11_TEX2D_ARRAY_DSV).</para>
		/// </summary>
		[FieldOffset(12)]
		public D3D11_TEX2D_ARRAY_DSV Texture2DArray;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX2DMS_DSV</c></para>
		/// <para>Specifies a multisampled 2D texture (see D3D11_TEX2DMS_DSV).</para>
		/// </summary>
		[FieldOffset(12)]
		public D3D11_TEX2DMS_DSV Texture2DMS;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX2DMS_ARRAY_DSV</c></para>
		/// <para>Specifies an array of multisampled 2D textures (see D3D11_TEX2DMS_ARRAY_DSV).</para>
		/// </summary>
		[FieldOffset(12)]
		public D3D11_TEX2DMS_ARRAY_DSV Texture2DMSArray;
	}

	/// <summary>Stencil operations that can be performed based on the results of stencil test.</summary>
	/// <remarks>
	/// <para>
	/// All stencil operations are specified as a D3D11_STENCIL_OP. The stencil operation can be set differently based on the outcome of the
	/// stencil test (which is referred to as <c>StencilFunc</c> in the stencil test portion of depth-stencil testing.
	/// </para>
	/// <para>This structure is a member of a depth-stencil description.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_depth_stencilop_desc typedef struct
	// D3D11_DEPTH_STENCILOP_DESC { D3D11_STENCIL_OP StencilFailOp; D3D11_STENCIL_OP StencilDepthFailOp; D3D11_STENCIL_OP StencilPassOp;
	// D3D11_COMPARISON_FUNC StencilFunc; } D3D11_DEPTH_STENCILOP_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_DEPTH_STENCILOP_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_DEPTH_STENCILOP_DESC
	{
		/// <summary>
		/// <para>Type: <c>D3D11_STENCIL_OP</c></para>
		/// <para>The stencil operation to perform when stencil testing fails.</para>
		/// </summary>
		public D3D11_STENCIL_OP StencilFailOp;

		/// <summary>
		/// <para>Type: <c>D3D11_STENCIL_OP</c></para>
		/// <para>The stencil operation to perform when stencil testing passes and depth testing fails.</para>
		/// </summary>
		public D3D11_STENCIL_OP StencilDepthFailOp;

		/// <summary>
		/// <para>Type: <c>D3D11_STENCIL_OP</c></para>
		/// <para>The stencil operation to perform when stencil testing and depth testing both pass.</para>
		/// </summary>
		public D3D11_STENCIL_OP StencilPassOp;

		/// <summary>
		/// <para>Type: <c>D3D11_COMPARISON_FUNC</c></para>
		/// <para>A function that compares stencil data against existing stencil data. The function options are listed in D3D11_COMPARISON_FUNC.</para>
		/// </summary>
		public D3D11_COMPARISON_FUNC StencilFunc;
	}

	/// <summary>Arguments for draw indexed instanced indirect.</summary>
	/// <remarks>The members of this structure serve the same purpose as the parameters of ID3D11DeviceContext::DrawIndexedInstanced.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_draw_indexed_instanced_indirect_args typedef struct
	// D3D11_DRAW_INDEXED_INSTANCED_INDIRECT_ARGS { UINT IndexCountPerInstance; UINT InstanceCount; UINT StartIndexLocation; INT
	// BaseVertexLocation; UINT StartInstanceLocation; } D3D11_DRAW_INDEXED_INSTANCED_INDIRECT_ARGS;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_DRAW_INDEXED_INSTANCED_INDIRECT_ARGS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_DRAW_INDEXED_INSTANCED_INDIRECT_ARGS
	{
		/// <summary>The number of indices read from the index buffer for each instance.</summary>
		public uint IndexCountPerInstance;

		/// <summary>The number of instances to draw.</summary>
		public uint InstanceCount;

		/// <summary>The location of the first index read by the GPU from the index buffer.</summary>
		public uint StartIndexLocation;

		/// <summary>A value added to each index before reading a vertex from the vertex buffer.</summary>
		public int BaseVertexLocation;

		/// <summary>A value added to each index before reading per-instance data from a vertex buffer.</summary>
		public uint StartInstanceLocation;
	}

	/// <summary>Arguments for draw instanced indirect.</summary>
	/// <remarks>The members of this structure serve the same purpose as the parameters of ID3D11DeviceContext::DrawInstanced.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_draw_instanced_indirect_args typedef struct
	// D3D11_DRAW_INSTANCED_INDIRECT_ARGS { UINT VertexCountPerInstance; UINT InstanceCount; UINT StartVertexLocation; UINT
	// StartInstanceLocation; } D3D11_DRAW_INSTANCED_INDIRECT_ARGS;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_DRAW_INSTANCED_INDIRECT_ARGS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_DRAW_INSTANCED_INDIRECT_ARGS
	{
		/// <summary>The number of vertices to draw.</summary>
		public uint VertexCountPerInstance;

		/// <summary>The number of instances to draw.</summary>
		public uint InstanceCount;

		/// <summary>The index of the first vertex.</summary>
		public uint StartVertexLocation;

		/// <summary>A value added to each index before reading per-instance data from a vertex buffer.</summary>
		public uint StartInstanceLocation;
	}

	/// <summary>Specifies which bytes in a video surface are encrypted.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_encrypted_block_info typedef struct
	// D3D11_ENCRYPTED_BLOCK_INFO { UINT NumEncryptedBytesAtBeginning; UINT NumBytesInSkipPattern; UINT NumBytesInEncryptPattern; } D3D11_ENCRYPTED_BLOCK_INFO;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_ENCRYPTED_BLOCK_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_ENCRYPTED_BLOCK_INFO
	{
		/// <summary>The number of bytes that are encrypted at the start of the buffer.</summary>
		public uint NumEncryptedBytesAtBeginning;

		/// <summary>
		/// The number of bytes that are skipped after the first <c>NumEncryptedBytesAtBeginning</c> bytes, and then after each block of
		/// <c>NumBytesInEncryptPattern</c> bytes. Skipped bytes are not encrypted.
		/// </summary>
		public uint NumBytesInSkipPattern;

		/// <summary>The number of bytes that are encrypted after each block of skipped bytes.</summary>
		public uint NumBytesInEncryptPattern;
	}

	/// <summary>
	/// Specifies whether a rendering device batches rendering commands and performs multipass rendering into tiles or bins over a render
	/// area. Certain API usage patterns that are fine for TileBasedDefferredRenderers (TBDRs) can perform worse on non-TBDRs and vice
	/// versa. Applications that are careful about rendering can be friendly to both TBDR and non-TBDR architectures. <c>TRUE</c> if the
	/// rendering device batches rendering commands and <c>FALSE</c> otherwise.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_architecture_info typedef struct
	// D3D11_FEATURE_DATA_ARCHITECTURE_INFO { BOOL TileBasedDeferredRenderer; } D3D11_FEATURE_DATA_ARCHITECTURE_INFO;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_ARCHITECTURE_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_ARCHITECTURE_INFO
	{
		/// <summary>
		/// Specifies whether a rendering device batches rendering commands and performs multipass rendering into tiles or bins over a
		/// render area. Certain API usage patterns that are fine for TileBasedDefferredRenderers (TBDRs) can perform worse on non-TBDRs and
		/// vice versa. Applications that are careful about rendering can be friendly to both TBDR and non-TBDR architectures. <c>TRUE</c>
		/// if the rendering device batches rendering commands and <c>FALSE</c> otherwise.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool TileBasedDeferredRenderer;
	}

	/// <summary>Describes compute shader and raw and structured buffer support in the current graphics driver.</summary>
	/// <remarks>
	/// Direct3D 11 devices (D3D_FEATURE_LEVEL_11_0) are required to support Compute Shader model 5.0. Direct3D 10.x devices
	/// (D3D_FEATURE_LEVEL_10_0, D3D_FEATURE_LEVEL_10_1) can optionally support Compute Shader model 4.0 or 4.1.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_d3d10_x_hardware_options typedef struct
	// D3D11_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS { BOOL ComputeShaders_Plus_RawAndStructuredBuffers_Via_Shader_4_x; } D3D11_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS
	{
		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if compute shaders and raw and structured buffers are supported; otherwise <c>FALSE</c>.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool ComputeShaders_Plus_RawAndStructuredBuffers_Via_Shader_4_x;
	}

	/// <summary>
	/// <para>Describes Direct3D 11.1 feature options in the current graphics driver.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>This structure is supported by the Direct3D 11.1 runtime, which is available on Windows 8 and later operating systems.</para>
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// If a Microsoft Direct3D device supports feature level 11.1 (D3D_FEATURE_LEVEL_11_1), when you call ID3D11Device::CheckFeatureSupport
	/// with D3D11_FEATURE_D3D11_OPTIONS, <c>CheckFeatureSupport</c> returns a pointer to <c>D3D11_FEATURE_DATA_D3D11_OPTIONS</c> with all
	/// member set to <c>TRUE</c> except the <c>SAD4ShaderInstructions</c> and <c>ExtendedDoublesShaderInstructions</c> members, which are
	/// optionally supported by the hardware and driver and therefore can be <c>TRUE</c> or <c>FALSE</c>.
	/// </para>
	/// <para>Feature level 11.1 provides the following additional features:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>UAVs at every shader stage with 64 UAV bind slots instead of 8.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Target-independent rasterization, which enables you to set the <c>ForcedSampleCount</c> member of D3D11_RASTERIZER_DESC1 to 1, 4, 8,
	/// or 16 and to render to RTVs with a single sample.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// UAV-only rendering with the <c>ForcedSampleCount</c> member of D3D11_RASTERIZER_DESC1 set to up to 16 (only up to 8 for feature
	/// level 11).
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// The runtime always sets the following groupings of members identically. That is, all the values in a grouping are <c>TRUE</c> or
	/// <c>FALSE</c> together:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>DiscardAPIsSeenByDriver</c> and <c>FlagsForUpdateAndCopySeenByDriver</c></description>
	/// </item>
	/// <item>
	/// <description>
	/// <c>ClearView</c>, <c>CopyWithOverlap</c>, <c>ConstantBufferPartialUpdate</c>, <c>ConstantBufferOffsetting</c>, and <c>MapNoOverwriteOnDynamicConstantBuffer</c>
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>MapNoOverwriteOnDynamicBufferSRV</c> and <c>MultisampleRTVWithForcedSampleCountOne</c></description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_d3d11_options typedef struct
	// D3D11_FEATURE_DATA_D3D11_OPTIONS { BOOL OutputMergerLogicOp; BOOL UAVOnlyRenderingForcedSampleCount; BOOL DiscardAPIsSeenByDriver;
	// BOOL FlagsForUpdateAndCopySeenByDriver; BOOL ClearView; BOOL CopyWithOverlap; BOOL ConstantBufferPartialUpdate; BOOL
	// ConstantBufferOffsetting; BOOL MapNoOverwriteOnDynamicConstantBuffer; BOOL MapNoOverwriteOnDynamicBufferSRV; BOOL
	// MultisampleRTVWithForcedSampleCountOne; BOOL SAD4ShaderInstructions; BOOL ExtendedDoublesShaderInstructions; BOOL
	// ExtendedResourceSharing; } D3D11_FEATURE_DATA_D3D11_OPTIONS;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_D3D11_OPTIONS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_D3D11_OPTIONS
	{
		/// <summary>
		/// Specifies whether logic operations are available in blend state. The runtime sets this member to <c>TRUE</c> if logic operations
		/// are available in blend state and <c>FALSE</c> otherwise. This member is <c>FALSE</c> for feature level 9.1, 9.2, and 9.3. This
		/// member is optional for feature level 10, 10.1, and 11. This member is <c>TRUE</c> for feature level 11.1.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool OutputMergerLogicOp;

		/// <summary>
		/// Specifies whether the driver can render with no render target views (RTVs) or depth stencil views (DSVs), and only unordered
		/// access views (UAVs) bound. The runtime sets this member to <c>TRUE</c> if the driver can render with no RTVs or DSVs and only
		/// UAVs bound and <c>FALSE</c> otherwise. If <c>TRUE</c>, you can set the <c>ForcedSampleCount</c> member of D3D11_RASTERIZER_DESC1
		/// to 1, 4, or 8 when you render with no RTVs or DSV and only UAVs bound. For feature level 11.1, this member is always <c>TRUE</c>
		/// and you can also set <c>ForcedSampleCount</c> to 16 in addition to 1, 4, or 8. The default value of <c>ForcedSampleCount</c> is
		/// 0, which means the same as if the value is set to 1. You can always set <c>ForcedSampleCount</c> to 0 or 1 for UAV-only
		/// rendering independently of how this member is set.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool UAVOnlyRenderingForcedSampleCount;

		/// <summary>
		/// Specifies whether the driver supports the ID3D11DeviceContext1::DiscardView and ID3D11DeviceContext1::DiscardResource methods.
		/// The runtime sets this member to <c>TRUE</c> if the driver supports these methods and <c>FALSE</c> otherwise. How this member is
		/// set does not indicate whether the driver actually uses these methods; that is, the driver might ignore these methods if they are
		/// not useful to the hardware. If <c>FALSE</c>, the runtime does not expose these methods to the driver because the driver does not
		/// support them. You can monitor this member during development to rule out legacy drivers on hardware where these methods might
		/// have otherwise been beneficial. You are not required to write separate code paths based on whether this member is <c>TRUE</c> or
		/// <c>FALSE</c>; you can call these methods whenever applicable.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool DiscardAPIsSeenByDriver;

		/// <summary>
		/// Specifies whether the driver supports new semantics for copy and update that are exposed by the
		/// ID3D11DeviceContext1::CopySubresourceRegion1 and ID3D11DeviceContext1::UpdateSubresource1 methods. The runtime sets this member
		/// to <c>TRUE</c> if the driver supports new semantics for copy and update. The runtime sets this member to <c>FALSE</c> only for
		/// legacy drivers. The runtime handles this member similarly to the <c>DiscardAPIsSeenByDriver</c> member.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool FlagsForUpdateAndCopySeenByDriver;

		/// <summary>
		/// <para>
		/// Specifies whether the driver supports the ID3D11DeviceContext1::ClearView method. The runtime sets this member to <c>TRUE</c> if
		/// the driver supports this method and <c>FALSE</c> otherwise. If <c>FALSE</c>, the runtime does not expose this method to the
		/// driver because the driver does not support it.
		/// </para>
		/// <para>
		/// <c>Note</c>  For feature level 9.1, 9.2, and 9.3, this member is always <c>TRUE</c> because the option is emulated by the runtime.
		/// </para>
		/// <para></para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool ClearView;

		/// <summary>
		/// <para>
		/// Specifies whether you can call ID3D11DeviceContext1::CopySubresourceRegion1 with overlapping source and destination rectangles.
		/// The runtime sets this member to <c>TRUE</c> if you can call <c>CopySubresourceRegion1</c> with overlapping source and
		/// destination rectangles and <c>FALSE</c> otherwise. If <c>FALSE</c>, the runtime does not expose this method to the driver
		/// because the driver does not support it.
		/// </para>
		/// <para>
		/// <c>Note</c>  For feature level 9.1, 9.2, and 9.3, this member is always <c>TRUE</c> because drivers already support the option
		/// for these feature levels.
		/// </para>
		/// <para></para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool CopyWithOverlap;

		/// <summary>
		/// <para>
		/// Specifies whether the driver supports partial updates of constant buffers. The runtime sets this member to <c>TRUE</c> if the
		/// driver supports partial updates of constant buffers and <c>FALSE</c> otherwise. If <c>FALSE</c>, the runtime does not expose
		/// this operation to the driver because the driver does not support it.
		/// </para>
		/// <para>
		/// <c>Note</c>  For feature level 9.1, 9.2, and 9.3, this member is always <c>TRUE</c> because the option is emulated by the runtime.
		/// </para>
		/// <para></para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool ConstantBufferPartialUpdate;

		/// <summary>
		/// <para>
		/// Specifies whether the driver supports new semantics for setting offsets in constant buffers for a shader. The runtime sets this
		/// member to <c>TRUE</c> if the driver supports allowing you to specify offsets when you call new methods like the
		/// ID3D11DeviceContext1::VSSetConstantBuffers1 method and <c>FALSE</c> otherwise. If <c>FALSE</c>, the runtime does not expose this
		/// operation to the driver because the driver does not support it.
		/// </para>
		/// <para>
		/// <c>Note</c>  For feature level 9.1, 9.2, and 9.3, this member is always <c>TRUE</c> because the option is emulated by the runtime.
		/// </para>
		/// <para></para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool ConstantBufferOffsetting;

		/// <summary>
		/// <para>
		/// Specifies whether you can call ID3D11DeviceContext::Map with D3D11_MAP_WRITE_NO_OVERWRITE on a dynamic constant buffer (that is,
		/// whether the driver supports this operation). The runtime sets this member to <c>TRUE</c> if the driver supports this operation
		/// and <c>FALSE</c> otherwise. If <c>FALSE</c>, the runtime fails this method because the driver does not support the operation.
		/// </para>
		/// <para>
		/// <c>Note</c>  For feature level 9.1, 9.2, and 9.3, this member is always <c>TRUE</c> because the option is emulated by the runtime.
		/// </para>
		/// <para></para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool MapNoOverwriteOnDynamicConstantBuffer;

		/// <summary>
		/// Specifies whether you can call ID3D11DeviceContext::Map with D3D11_MAP_WRITE_NO_OVERWRITE on a dynamic buffer SRV (that is,
		/// whether the driver supports this operation). The runtime sets this member to <c>TRUE</c> if the driver supports this operation
		/// and <c>FALSE</c> otherwise. If <c>FALSE</c>, the runtime fails this method because the driver does not support the operation.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool MapNoOverwriteOnDynamicBufferSRV;

		/// <summary>
		/// Specifies whether the driver supports multisample rendering when you render with RTVs bound. If <c>TRUE</c>, you can set the
		/// <c>ForcedSampleCount</c> member of D3D11_RASTERIZER_DESC1 to 1 with a multisample RTV bound. The driver can support this option
		/// on feature level 10 and higher. If <c>FALSE</c>, the rasterizer-state creation will fail because the driver is legacy or the
		/// feature level is too low.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool MultisampleRTVWithForcedSampleCountOne;

		/// <summary>
		/// Specifies whether the hardware and driver support the msad4 intrinsic function in shaders. The runtime sets this member to
		/// <c>TRUE</c> if the hardware and driver support calls to <c>msad4</c> intrinsic functions in shaders. If <c>FALSE</c>, the driver
		/// is legacy or the hardware does not support the option; the runtime will fail shader creation for shaders that use <c>msad4</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool SAD4ShaderInstructions;

		/// <summary>
		/// Specifies whether the hardware and driver support the fma intrinsic function and other extended doubles instructions (
		/// <c>DDIV</c> and <c>DRCP</c>) in shaders. The <c>fma</c> intrinsic function emits an extended doubles <c>DFMA</c> instruction.
		/// The runtime sets this member to <c>TRUE</c> if the hardware and driver support extended doubles instructions in shaders (shader
		/// model 5 and higher). Support of this option implies support of basic double-precision shader instructions as well. You can use
		/// the D3D11_FEATURE_DOUBLES value to query for support of double-precision shaders. If <c>FALSE</c>, the hardware and driver do
		/// not support the option; the runtime will fail shader creation for shaders that use extended doubles instructions.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool ExtendedDoublesShaderInstructions;

		/// <summary>
		/// Specifies whether the hardware and driver have extended support for shared Texture2D resource types and formats. The runtime
		/// sets this member to <c>TRUE</c> if the hardware and driver support extended Texture2D resource sharing.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool ExtendedResourceSharing;
	}

	/// <summary>
	/// <para>Note</para>
	/// <para>This structure is supported by the Direct3D 11.2 runtime, which is available on Windows 8.1 and later operating systems.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// If the Direct3D API is the Direct3D 11.2 runtime and can support 11.2 features, ID3D11Device::CheckFeatureSupport for
	/// <c>D3D11_FEATURE_D3D11_OPTIONS1</c> will return a SUCCESS code when valid parameters are passed. The members of
	/// <c>D3D11_FEATURE_DATA_D3D11_OPTIONS1</c> will be set appropriately based on the system's graphics hardware and graphics driver.
	/// </para>
	/// <para>Mappable default buffers</para>
	/// <para>
	/// When creating a default buffer with D3D11_CPU_ACCESS_FLAG, only the <c>D3D11_BIND_SHADER_RESOURCE</c> and
	/// <c>D3D11_BIND_UNORDERED_ACCESS</c> bind flags may be used.
	/// </para>
	/// <para>The D3D11_RESOURCE_MISC_FLAG cannot be used when creating resources with <c>D3D11_CPU_ACCESS</c> flags.</para>
	/// <para>
	/// On non-unified memory architecture systems (discrete GPUs), apps should not use mappable default buffers if the compute shader code
	/// accesses the same byte in a default buffer more than once - sending the data across the bus multiple times eliminates the
	/// performance gained by mapping the default buffer instead of copying it.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_d3d11_options1 typedef struct
	// D3D11_FEATURE_DATA_D3D11_OPTIONS1 { D3D11_TILED_RESOURCES_TIER TiledResourcesTier; BOOL MinMaxFiltering; BOOL
	// ClearViewAlsoSupportsDepthOnlyFormats; BOOL MapOnDefaultBuffers; } D3D11_FEATURE_DATA_D3D11_OPTIONS1;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_D3D11_OPTIONS1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_D3D11_OPTIONS1
	{
		/// <summary>
		/// <para>Type: <c>D3D11_TILED_RESOURCES_TIER</c></para>
		/// <para>
		/// Specifies whether the hardware and driver support tiled resources. The runtime sets this member to a
		/// D3D11_TILED_RESOURCES_TIER-typed value that indicates if the hardware and driver support tiled resources and at what tier level.
		/// </para>
		/// </summary>
		public D3D11_TILED_RESOURCES_TIER TiledResourcesTier;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Specifies whether the hardware and driver support the filtering options (D3D11_FILTER) of comparing the result to the minimum or
		/// maximum value during texture sampling. The runtime sets this member to <c>TRUE</c> if the hardware and driver support these
		/// filtering options.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool MinMaxFiltering;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Specifies whether the hardware and driver also support the ID3D11DeviceContext1::ClearView method on depth formats. For info
		/// about valid depth formats, see D3D11_DEPTH_STENCIL_VIEW_DESC.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool ClearViewAlsoSupportsDepthOnlyFormats;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Specifies support for creating ID3D11Buffer resources that can be passed to the ID3D11DeviceContext::Map and
		/// ID3D11DeviceContext::Unmap methods. This means that the <c>CPUAccessFlags</c> member of the D3D11_BUFFER_DESC structure may be
		/// set with the desired D3D11_CPU_ACCESS_FLAG elements when the <c>Usage</c> member of <c>D3D11_BUFFER_DESC</c> is set to
		/// <c>D3D11_USAGE_DEFAULT</c>. The runtime sets this member to <c>TRUE</c> if the hardware is capable of at least
		/// <c>D3D_FEATURE_LEVEL_11_0</c> and the graphics device driver supports mappable default buffers.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool MapOnDefaultBuffers;
	}

	/// <summary>Describes Direct3D 11.3 feature options in the current graphics driver.</summary>
	/// <remarks>
	/// <para>
	/// If <c>MapOnDefaultTextures</c> is TRUE, applications may create textures using D3D11_USAGE_DEFAULT in combination with non-zero a
	/// D3D11_CPU_ACCESS_FLAG value. For performance reasons it is typically undesirable to create a default texture with CPU access flags
	/// unless the <c>UnifiedMemoryArchitecture</c> option is TRUE, or CPU / GPU usage of the texture is tightly interleaved.
	/// </para>
	/// <para>
	/// Default textures may not be in a mapped state while either bound to the pipeline to referenced by an operation issued to a context.
	/// Default textures may not be mapped by a deferred context. Default textures may not be created shareable.
	/// </para>
	/// <para>See D3D11_TEXTURE_LAYOUT for texture swizzle options and restrictions.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_d3d11_options2 typedef struct
	// D3D11_FEATURE_DATA_D3D11_OPTIONS2 { BOOL PSSpecifiedStencilRefSupported; BOOL TypedUAVLoadAdditionalFormats; BOOL ROVsSupported;
	// D3D11_CONSERVATIVE_RASTERIZATION_TIER ConservativeRasterizationTier; D3D11_TILED_RESOURCES_TIER TiledResourcesTier; BOOL
	// MapOnDefaultTextures; BOOL StandardSwizzle; BOOL UnifiedMemoryArchitecture; } D3D11_FEATURE_DATA_D3D11_OPTIONS2;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_D3D11_OPTIONS2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_D3D11_OPTIONS2
	{
		/// <summary>
		/// Specifies whether the hardware and driver support <c>PSSpecifiedStencilRef</c>. The runtime sets this member to <c>TRUE</c> if
		/// the hardware and driver support this option.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool PSSpecifiedStencilRefSupported;

		/// <summary>
		/// Specifies whether the hardware and driver support <c>TypedUAVLoadAdditionalFormats</c>. The runtime sets this member to
		/// <c>TRUE</c> if the hardware and driver support this option.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool TypedUAVLoadAdditionalFormats;

		/// <summary>
		/// Specifies whether the hardware and driver support ROVs. The runtime sets this member to <c>TRUE</c> if the hardware and driver
		/// support this option.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool ROVsSupported;

		/// <summary>
		/// Specifies whether the hardware and driver support conservative rasterization. The runtime sets this member to a
		/// D3D11_CONSERVATIVE_RASTERIZATION_TIER-typed value that indicates if the hardware and driver support conservative rasterization
		/// and at what tier level.
		/// </summary>
		public D3D11_CONSERVATIVE_RASTERIZATION_TIER ConservativeRasterizationTier;

		/// <summary>
		/// Specifies whether the hardware and driver support tiled resources. The runtime sets this member to a
		/// D3D11_TILED_RESOURCES_TIER-typed value that indicates if the hardware and driver support tiled resources and at what tier level.
		/// </summary>
		public D3D11_TILED_RESOURCES_TIER TiledResourcesTier;

		/// <summary>
		/// Specifies whether the hardware and driver support mapping on default textures. The runtime sets this member to <c>TRUE</c> if
		/// the hardware and driver support this option.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool MapOnDefaultTextures;

		/// <summary>
		/// Specifies whether the hardware and driver support standard swizzle. The runtime sets this member to <c>TRUE</c> if the hardware
		/// and driver support this option.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool StandardSwizzle;

		/// <summary>
		/// Specifies whether the hardware and driver support Unified Memory Architecture. The runtime sets this member to <c>TRUE</c> if
		/// the hardware and driver support this option.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool UnifiedMemoryArchitecture;
	}

	/// <summary>Describes Direct3D 11.3 feature options in the current graphics driver.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_d3d11_options3 typedef struct
	// D3D11_FEATURE_DATA_D3D11_OPTIONS3 { BOOL VPAndRTArrayIndexFromAnyShaderFeedingRasterizer; } D3D11_FEATURE_DATA_D3D11_OPTIONS3;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_D3D11_OPTIONS3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_D3D11_OPTIONS3
	{
		/// <summary>Whether to use the VP and RT array index from any shader feeding the rasterizer.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool VPAndRTArrayIndexFromAnyShaderFeedingRasterizer;
	}

	/// <summary>Describes the level of support for shared resources in the current graphics driver.</summary>
	/// <remarks>Use this structure with the <c>D3D11_FEATURE_D3D11_OPTIONS5</c> member of D3D11_FEATURE.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_d3d11_options5 typedef struct
	// D3D11_FEATURE_DATA_D3D11_OPTIONS5 { D3D11_SHARED_RESOURCE_TIER SharedResourceTier; } D3D11_FEATURE_DATA_D3D11_OPTIONS5;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_D3D11_OPTIONS5")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_D3D11_OPTIONS5
	{
		/// <summary>
		/// <para>Type: <c>D3D11_SHARED_RESOURCE_TIER</c></para>
		/// <para>The level of support for shared resources in the current graphics driver.</para>
		/// </summary>
		public D3D11_SHARED_RESOURCE_TIER SharedResourceTier;
	}

	/// <summary>
	/// Specifies whether the driver supports the nonpowers-of-2-unconditionally feature. For more information about this feature, see
	/// feature level. The runtime sets this member to <c>TRUE</c> for hardware at Direct3D 10 and higher feature levels. For hardware at
	/// Direct3D 9.3 and lower feature levels, the runtime sets this member to <c>FALSE</c> if the hardware and driver support the
	/// powers-of-2 (2D textures must have widths and heights specified as powers of two) feature or the nonpowers-of-2-conditionally
	/// feature. For more information about this feature, see feature level.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_d3d9_options typedef struct
	// D3D11_FEATURE_DATA_D3D9_OPTIONS { BOOL FullNonPow2TextureSupport; } D3D11_FEATURE_DATA_D3D9_OPTIONS;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_D3D9_OPTIONS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_D3D9_OPTIONS
	{
		/// <summary>
		/// Specifies whether the driver supports the nonpowers-of-2-unconditionally feature. For more information about this feature, see
		/// feature level. The runtime sets this member to <c>TRUE</c> for hardware at Direct3D 10 and higher feature levels. For hardware
		/// at Direct3D 9.3 and lower feature levels, the runtime sets this member to <c>FALSE</c> if the hardware and driver support the
		/// powers-of-2 (2D textures must have widths and heights specified as powers of two) feature or the nonpowers-of-2-conditionally
		/// feature. For more information about this feature, see feature level.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool FullNonPow2TextureSupport;
	}

	/// <summary>
	/// <para>
	/// Specifies whether the driver supports the nonpowers-of-2-unconditionally feature. For more info about this feature, see feature
	/// level. The runtime sets this member to <c>TRUE</c> for hardware at Direct3D 10 and higher feature levels. For hardware at Direct3D
	/// 9.3 and lower feature levels, the runtime sets this member to <c>FALSE</c> if the hardware and driver support the powers-of-2 (2D
	/// textures must have widths and heights specified as powers of two) feature or the nonpowers-of-2-conditionally feature.
	/// </para>
	/// <para>
	/// Specifies whether the driver supports the shadowing feature with the comparison-filtering mode set to less than or equal to. The
	/// runtime sets this member to <c>TRUE</c> for hardware at Direct3D 10 and higher feature levels. For hardware at Direct3D 9.3 and
	/// lower feature levels, the runtime sets this member to <c>TRUE</c> only if the hardware and driver support the shadowing feature;
	/// otherwise <c>FALSE</c>.
	/// </para>
	/// <para>
	/// Specifies whether the hardware and driver support simple instancing. The runtime sets this member to <c>TRUE</c> if the hardware and
	/// driver support simple instancing.
	/// </para>
	/// <para>
	/// Specifies whether the hardware and driver support setting a single face of a TextureCube as a render target while the depth stencil
	/// surface that is bound alongside can be a Texture2D (as opposed to <c>TextureCube</c>). The runtime sets this member to <c>TRUE</c>
	/// if the hardware and driver support this feature; otherwise <c>FALSE</c>.
	/// </para>
	/// <para>
	/// If the hardware and driver don't support this feature, the app must match the render target surface type with the depth stencil
	/// surface type. Because hardware at Direct3D 9.3 and lower feature levels doesn't allow TextureCube depth surfaces, the only way to
	/// render a scene into a <c>TextureCube</c> while having depth buffering enabled is to render each <c>TextureCube</c> face separately
	/// to a Texture2D render target first (because that can be matched with a <c>Texture2D</c> depth), and then copy the results into the
	/// <c>TextureCube</c>. If the hardware and driver support this feature, the app can just render to the <c>TextureCube</c> faces
	/// directly while getting depth buffering out of a <c>Texture2D</c> depth buffer.
	/// </para>
	/// <para>
	/// You only need to query this feature from hardware at Direct3D 9.3 and lower feature levels because hardware at Direct3D 10.0 and
	/// higher feature levels allow TextureCube depth surfaces.
	/// </para>
	/// </summary>
	/// <remarks>
	/// You can use the D3D11_FEATURE_D3D9_OPTIONS1 enumeration value with ID3D11Device::CheckFeatureSupport to query a driver about support
	/// for Direct3D 9 feature options rather than making multiple calls to <c>ID3D11Device::CheckFeatureSupport</c> by using
	/// D3D11_FEATURE_D3D9_OPTIONS, <c>D3D11_FEATURE_D3D9_SHADOW_SUPPORT</c>, and <c>D3D11_FEATURE_D3D9_SIMPLE_INSTANCING_SUPPORT</c>, which
	/// provide identical info about supported Direct3D 9 feature options.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_d3d9_options1 typedef struct
	// D3D11_FEATURE_DATA_D3D9_OPTIONS1 { BOOL FullNonPow2TextureSupported; BOOL DepthAsTextureWithLessEqualComparisonFilterSupported; BOOL
	// SimpleInstancingSupported; BOOL TextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported; } D3D11_FEATURE_DATA_D3D9_OPTIONS1;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_D3D9_OPTIONS1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_D3D9_OPTIONS1
	{
		/// <summary>
		/// Specifies whether the driver supports the nonpowers-of-2-unconditionally feature. For more info about this feature, see feature
		/// level. The runtime sets this member to <c>TRUE</c> for hardware at Direct3D 10 and higher feature levels. For hardware at
		/// Direct3D 9.3 and lower feature levels, the runtime sets this member to <c>FALSE</c> if the hardware and driver support the
		/// powers-of-2 (2D textures must have widths and heights specified as powers of two) feature or the nonpowers-of-2-conditionally feature.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool FullNonPow2TextureSupported;

		/// <summary>
		/// Specifies whether the driver supports the shadowing feature with the comparison-filtering mode set to less than or equal to. The
		/// runtime sets this member to <c>TRUE</c> for hardware at Direct3D 10 and higher feature levels. For hardware at Direct3D 9.3 and
		/// lower feature levels, the runtime sets this member to <c>TRUE</c> only if the hardware and driver support the shadowing feature;
		/// otherwise <c>FALSE</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool DepthAsTextureWithLessEqualComparisonFilterSupported;

		/// <summary>
		/// Specifies whether the hardware and driver support simple instancing. The runtime sets this member to <c>TRUE</c> if the hardware
		/// and driver support simple instancing.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool SimpleInstancingSupported;

		/// <summary>
		/// <para>
		/// Specifies whether the hardware and driver support setting a single face of a TextureCube as a render target while the depth
		/// stencil surface that is bound alongside can be a Texture2D (as opposed to <c>TextureCube</c>). The runtime sets this member to
		/// <c>TRUE</c> if the hardware and driver support this feature; otherwise <c>FALSE</c>.
		/// </para>
		/// <para>
		/// If the hardware and driver don't support this feature, the app must match the render target surface type with the depth stencil
		/// surface type. Because hardware at Direct3D 9.3 and lower feature levels doesn't allow TextureCube depth surfaces, the only way
		/// to render a scene into a <c>TextureCube</c> while having depth buffering enabled is to render each <c>TextureCube</c> face
		/// separately to a Texture2D render target first (because that can be matched with a <c>Texture2D</c> depth), and then copy the
		/// results into the <c>TextureCube</c>. If the hardware and driver support this feature, the app can just render to the
		/// <c>TextureCube</c> faces directly while getting depth buffering out of a <c>Texture2D</c> depth buffer.
		/// </para>
		/// <para>
		/// You only need to query this feature from hardware at Direct3D 9.3 and lower feature levels because hardware at Direct3D 10.0 and
		/// higher feature levels allow TextureCube depth surfaces.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool TextureCubeFaceRenderTargetWithNonCubeDepthStencilSupported;
	}

	/// <summary>
	/// Specifies whether the driver supports the shadowing feature with the comparison-filtering mode set to less than or equal to. The
	/// runtime sets this member to <c>TRUE</c> for hardware at Direct3D 10 and higher feature levels. For hardware at Direct3D 9.3 and
	/// lower feature levels, the runtime sets this member to <c>TRUE</c> only if the hardware and driver support the shadowing feature;
	/// otherwise <c>FALSE</c>.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Shadows are an important element in realistic 3D scenes. You can use the shadow buffer technique to render shadows. The basic
	/// principle of the technique is to use a depth buffer to store the scene depth info from the perspective of the light source, and then
	/// compare each point rendered in the scene with that buffer to determine if it is in shadow.
	/// </para>
	/// <para>
	/// To render objects into the scene with shadows on them, you create sampler state objects with comparison filtering set and the
	/// comparison mode (ComparisonFunc) to LessEqual. You can also set BorderColor addressing on this depth sampler, even though
	/// BorderColor isn't typically allowed on feature levels 9.1 and 9.2. By using the border color and picking 0.0 or 1.0 as the border
	/// color value, you can control whether the regions off the edge of the shadow map appear to be always in shadow or never in shadow
	/// respectively. You can control the shadow filter quality by the Mag and Min filter settings in the comparison sampler. Point sampling
	/// will produce shadows with non-anti-aliased edges. Linear filter sampler settings will result in higher quality shadow edges, but
	/// might affect performance on some power-optimized devices.
	/// </para>
	/// <para>
	/// <c>Note</c>  If you use a separate setting for Mag versus Min filter options, you produce an undefined result. Anisotropic filtering
	/// is not supported. The Mip filter choice is not relevant because feature level 9.x does not allow mipmapped depth buffers.
	/// </para>
	/// <para></para>
	/// <para>
	/// <c>Note</c>  On feature level 9.x, you can't compile a shader with the SampleCmp and SampleCmpLevelZero intrinsic functions by using
	/// older versions of the compiler. For example, you can't use the fxc.exe compiler that ships with the DirectX SDK or use the
	/// <c>D3DCompile**</c> functions (like D3DCompileFromFile) that are implemented in D3DCompiler_43.dll and earlier. These intrinsic
	/// functions on feature level 9.x are only supported in the fxc.exe compiler that ships with the Windows 8 SDK and later and with the
	/// <c>D3DCompile**</c> functions that are implemented in D3DCompiler_44.dll and later. But these intrinsic functions are present in
	/// shader models for feature levels higher than 9.x.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_d3d9_shadow_support typedef struct
	// D3D11_FEATURE_DATA_D3D9_SHADOW_SUPPORT { BOOL SupportsDepthAsTextureWithLessEqualComparisonFilter; } D3D11_FEATURE_DATA_D3D9_SHADOW_SUPPORT;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_D3D9_SHADOW_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_D3D9_SHADOW_SUPPORT
	{
		/// <summary>
		/// Specifies whether the driver supports the shadowing feature with the comparison-filtering mode set to less than or equal to. The
		/// runtime sets this member to <c>TRUE</c> for hardware at Direct3D 10 and higher feature levels. For hardware at Direct3D 9.3 and
		/// lower feature levels, the runtime sets this member to <c>TRUE</c> only if the hardware and driver support the shadowing feature;
		/// otherwise <c>FALSE</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool SupportsDepthAsTextureWithLessEqualComparisonFilter;
	}

	/// <summary>
	/// Specifies whether the hardware and driver support simple instancing. The runtime sets this member to <c>TRUE</c> if the hardware and
	/// driver support simple instancing.
	/// </summary>
	/// <remarks>
	/// <para>
	/// If the Direct3D API is the Direct3D 11.2 runtime and can support 11.2 features, ID3D11Device::CheckFeatureSupport for
	/// <c>D3D11_FEATURE_D3D9_SIMPLE_INSTANCING_SUPPORT</c> will return a SUCCESS code when valid parameters are passed. The
	/// <c>SimpleInstancingSupported</c> member of <c>D3D11_FEATURE_DATA_D3D9_SIMPLE_INSTANCING_SUPPORT</c> will be set to <c>TRUE</c> or <c>FALSE</c>.
	/// </para>
	/// <para>
	/// Simple instancing means that instancing is supported with the caveat that the <c>InstanceDataStepRate</c> member of the
	/// D3D11_INPUT_ELEMENT_DESC structure must be equal to 1. This does not change the full instancing support provided by hardware at
	/// feature level 9.3 and above, and is meant to expose the instancing support that may be available on feature level 9.2 and 9.1 hardware.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_d3d9_simple_instancing_support typedef struct
	// D3D11_FEATURE_DATA_D3D9_SIMPLE_INSTANCING_SUPPORT { BOOL SimpleInstancingSupported; } D3D11_FEATURE_DATA_D3D9_SIMPLE_INSTANCING_SUPPORT;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_D3D9_SIMPLE_INSTANCING_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_D3D9_SIMPLE_INSTANCING_SUPPORT
	{
		/// <summary>
		/// Specifies whether the hardware and driver support simple instancing. The runtime sets this member to <c>TRUE</c> if the hardware
		/// and driver support simple instancing.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool SimpleInstancingSupported;
	}

	/// <summary>Describes the level of displayable surfaces supported in the current graphics driver. See Displayable surfaces.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_displayable typedef struct
	// D3D11_FEATURE_DATA_DISPLAYABLE { BOOL DisplayableTexture; D3D11_SHARED_RESOURCE_TIER SharedResourceTier; } D3D11_FEATURE_DATA_DISPLAYABLE;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_DISPLAYABLE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_DISPLAYABLE
	{
		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>if the driver supports displayable surfaces; otherwise, .</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool DisplayableTexture;

		/// <summary>
		/// <para>Type: <c>D3D11_SHARED_RESOURCE_TIER</c></para>
		/// <para>The level of support for shared resources in the current graphics driver.</para>
		/// </summary>
		public D3D11_SHARED_RESOURCE_TIER SharedResourceTier;
	}

	/// <summary>Describes double data type support in the current graphics driver.</summary>
	/// <remarks>
	/// <para>
	/// If the runtime sets <c>DoublePrecisionFloatShaderOps</c> to <c>TRUE</c>, the hardware and driver support the following Shader Model
	/// 5 instructions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>dadd</description>
	/// </item>
	/// <item>
	/// <description>dmax</description>
	/// </item>
	/// <item>
	/// <description>dmin</description>
	/// </item>
	/// <item>
	/// <description>dmul</description>
	/// </item>
	/// <item>
	/// <description>deq</description>
	/// </item>
	/// <item>
	/// <description>dge</description>
	/// </item>
	/// <item>
	/// <description>dlt</description>
	/// </item>
	/// <item>
	/// <description>dne</description>
	/// </item>
	/// <item>
	/// <description>dmov</description>
	/// </item>
	/// <item>
	/// <description>dmovc</description>
	/// </item>
	/// <item>
	/// <description>dtof</description>
	/// </item>
	/// <item>
	/// <description>ftod</description>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c>  If <c>DoublePrecisionFloatShaderOps</c> is <c>TRUE</c>, the hardware and driver do not necessarily support
	/// double-precision division.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_doubles typedef struct
	// D3D11_FEATURE_DATA_DOUBLES { BOOL DoublePrecisionFloatShaderOps; } D3D11_FEATURE_DATA_DOUBLES;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_DOUBLES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_DOUBLES
	{
		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Specifies whether double types are allowed. If <c>TRUE</c>, double types are allowed; otherwise <c>FALSE</c>. The runtime must
		/// set <c>DoublePrecisionFloatShaderOps</c> to <c>TRUE</c> in order for you to use any HLSL shader that is compiled with a double type.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool DoublePrecisionFloatShaderOps;
	}

	/// <summary>Describes which resources are supported by the current graphics driver for a given format.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_format_support typedef struct
	// D3D11_FEATURE_DATA_FORMAT_SUPPORT { DXGI_FORMAT InFormat; UINT OutFormatSupport; } D3D11_FEATURE_DATA_FORMAT_SUPPORT;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_FORMAT_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_FORMAT_SUPPORT
	{
		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>DXGI_FORMAT to return information on.</para>
		/// </summary>
		public DXGI_FORMAT InFormat;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Combination of D3D11_FORMAT_SUPPORT flags indicating which resources are supported.</para>
		/// </summary>
		public D3D11_FORMAT_SUPPORT OutFormatSupport;
	}

	/// <summary>Describes which unordered resource options are supported by the current graphics driver for a given format.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_format_support2 typedef struct
	// D3D11_FEATURE_DATA_FORMAT_SUPPORT2 { DXGI_FORMAT InFormat; UINT OutFormatSupport2; } D3D11_FEATURE_DATA_FORMAT_SUPPORT2;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_FORMAT_SUPPORT2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_FORMAT_SUPPORT2
	{
		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>DXGI_FORMAT to return information on.</para>
		/// </summary>
		public DXGI_FORMAT InFormat;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Combination of D3D11_FORMAT_SUPPORT2 flags indicating which unordered resource options are supported.</para>
		/// </summary>
		public D3D11_FORMAT_SUPPORT2 OutFormatSupport2;
	}

	/// <summary>Describes feature data GPU virtual address support, including maximum address bits per resource and per process.</summary>
	/// <remarks>See D3D11_FEATURE.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_gpu_virtual_address_support typedef struct
	// D3D11_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT { UINT MaxGPUVirtualAddressBitsPerResource; UINT MaxGPUVirtualAddressBitsPerProcess; } D3D11_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT
	{
		/// <summary>The maximum GPU virtual address bits per resource.</summary>
		public uint MaxGPUVirtualAddressBitsPerResource;

		/// <summary>The maximum GPU virtual address bits per process.</summary>
		public uint MaxGPUVirtualAddressBitsPerProcess;
	}

	/// <summary>
	/// Specifies whether the hardware and driver support a GPU profiling technique that can be used with development tools. The runtime
	/// sets this member to <c>TRUE</c> if the hardware and driver support data marking.
	/// </summary>
	/// <remarks>
	/// If the Direct3D API is the Direct3D 11.2 runtime and can support 11.2 features, ID3D11Device::CheckFeatureSupport for
	/// <c>D3D11_FEATURE_MARKER_SUPPORT</c> will return a SUCCESS code when valid parameters are passed. The <c>Profile</c> member of
	/// <c>D3D11_FEATURE_DATA_MARKER_SUPPORT</c> will be set to <c>TRUE</c> or <c>FALSE</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_marker_support typedef struct
	// D3D11_FEATURE_DATA_MARKER_SUPPORT { BOOL Profile; } D3D11_FEATURE_DATA_MARKER_SUPPORT;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_MARKER_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_MARKER_SUPPORT
	{
		/// <summary>
		/// Specifies whether the hardware and driver support a GPU profiling technique that can be used with development tools. The runtime
		/// sets this member to <c>TRUE</c> if the hardware and driver support data marking.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool Profile;
	}

	/// <summary>Describes the level of shader caching supported in the current graphics driver.</summary>
	/// <remarks>
	/// <para>Use this structure with CheckFeatureSupport to determine the level of support offered for the optional shader-caching features.</para>
	/// <para>See the enumeration constant D3D11_FEATURE_SHADER_CACHE in the D3D11_FEATURE enumeration.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_shader_cache typedef struct
	// D3D11_FEATURE_DATA_SHADER_CACHE { UINT SupportFlags; } D3D11_FEATURE_DATA_SHADER_CACHE;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_SHADER_CACHE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_SHADER_CACHE
	{
		/// <summary>Indicates the level of caching supported.</summary>
		public D3D11_SHADER_CACHE_SUPPORT_FLAGS SupportFlags;
	}

	/// <summary>
	/// <para>
	/// A combination of D3D11_SHADER_MIN_PRECISION_SUPPORT-typed values that are combined by using a bitwise OR operation. The resulting
	/// value specifies minimum precision levels that the driver supports for the pixel shader. A value of zero indicates that the driver
	/// supports only full 32-bit precision for the pixel shader.
	/// </para>
	/// <para>
	/// A combination of D3D11_SHADER_MIN_PRECISION_SUPPORT-typed values that are combined by using a bitwise OR operation. The resulting
	/// value specifies minimum precision levels that the driver supports for all other shader stages. A value of zero indicates that the
	/// driver supports only full 32-bit precision for all other shader stages.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// For hardware at Direct3D 10 and higher feature levels, the runtime sets both members identically. For hardware at Direct3D 9.3 and
	/// lower feature levels, the runtime can set a lower precision support in the <c>PixelShaderMinPrecision</c> member than the
	/// <c>AllOtherShaderStagesMinPrecision</c> member; for 9.3 and lower, all other shader stages represent only the vertex shader.
	/// </para>
	/// <para>For more info about HLSL minimum precision, see using HLSL minimum precision.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_shader_min_precision_support typedef struct
	// D3D11_FEATURE_DATA_SHADER_MIN_PRECISION_SUPPORT { UINT PixelShaderMinPrecision; UINT AllOtherShaderStagesMinPrecision; } D3D11_FEATURE_DATA_SHADER_MIN_PRECISION_SUPPORT;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_SHADER_MIN_PRECISION_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_SHADER_MIN_PRECISION_SUPPORT
	{
		/// <summary>
		/// A combination of D3D11_SHADER_MIN_PRECISION_SUPPORT-typed values that are combined by using a bitwise OR operation. The
		/// resulting value specifies minimum precision levels that the driver supports for the pixel shader. A value of zero indicates that
		/// the driver supports only full 32-bit precision for the pixel shader.
		/// </summary>
		public D3D11_SHADER_MIN_PRECISION_SUPPORT PixelShaderMinPrecision;

		/// <summary>
		/// A combination of D3D11_SHADER_MIN_PRECISION_SUPPORT-typed values that are combined by using a bitwise OR operation. The
		/// resulting value specifies minimum precision levels that the driver supports for all other shader stages. A value of zero
		/// indicates that the driver supports only full 32-bit precision for all other shader stages.
		/// </summary>
		public D3D11_SHADER_MIN_PRECISION_SUPPORT AllOtherShaderStagesMinPrecision;
	}

	/// <summary>Describes the multi-threading features that are supported by the current graphics driver.</summary>
	/// <remarks>
	/// Use the D3D11_FEATURE_DATA_THREADING structure with the ID3D11Device::CheckFeatureSupport method to determine multi-threading support.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_threading typedef struct
	// D3D11_FEATURE_DATA_THREADING { BOOL DriverConcurrentCreates; BOOL DriverCommandLists; } D3D11_FEATURE_DATA_THREADING;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_FEATURE_DATA_THREADING")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_THREADING
	{
		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// <c>TRUE</c> means resources can be created concurrently on multiple threads while drawing; <c>FALSE</c> means that the presence
		/// of coarse synchronization will prevent concurrency.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool DriverConcurrentCreates;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// <c>TRUE</c> means command lists are supported by the current driver; <c>FALSE</c> means that the API will emulate deferred
		/// contexts and command lists with software.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool DriverCommandLists;
	}

	/// <summary>A description of a single element for the input-assembler stage.</summary>
	/// <remarks>
	/// An input-layout object contains an array of structures, each structure defines one element being read from an input slot. Create an
	/// input-layout object by calling ID3D11Device::CreateInputLayout. For an example, see the "Create the Input-Layout Object" subtopic
	/// under the Getting Started with the Input-Assembler Stage topic.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_input_element_desc typedef struct D3D11_INPUT_ELEMENT_DESC {
	// LPCSTR SemanticName; UINT SemanticIndex; DXGI_FORMAT Format; UINT InputSlot; UINT AlignedByteOffset; D3D11_INPUT_CLASSIFICATION
	// InputSlotClass; UINT InstanceDataStepRate; } D3D11_INPUT_ELEMENT_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_INPUT_ELEMENT_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_INPUT_ELEMENT_DESC
	{
		/// <summary>
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The HLSL semantic associated with this element in a shader input-signature. See HLSL Semantics for more info.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string SemanticName;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The semantic index for the element. A semantic index modifies a semantic, with an integer index number. A semantic index is only
		/// needed in a case where there is more than one element with the same semantic. For example, a 4x4 matrix would have four
		/// components each with the semantic name <c>matrix</c>, however each of the four component would have different semantic indices
		/// (0, 1, 2, and 3).
		/// </para>
		/// </summary>
		public uint SemanticIndex;

		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>The data type of the element data. See DXGI_FORMAT.</para>
		/// </summary>
		public DXGI_FORMAT Format;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>An integer value that identifies the input-assembler (see input slot). Valid values are between 0 and 15, defined in D3D11.h.</para>
		/// </summary>
		public uint InputSlot;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Optional. Offset (in bytes) from the start of the vertex. Use D3D11_APPEND_ALIGNED_ELEMENT for convenience to define the current
		/// element directly after the previous one, including any packing if necessary.
		/// </para>
		/// </summary>
		public uint AlignedByteOffset;

		/// <summary>
		/// <para>Type: <c>D3D11_INPUT_CLASSIFICATION</c></para>
		/// <para>Identifies the input data class for a single input slot (see D3D11_INPUT_CLASSIFICATION).</para>
		/// </summary>
		public D3D11_INPUT_CLASSIFICATION InputSlotClass;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The number of instances to draw using the same per-instance data before advancing in the buffer by one element. This value must
		/// be 0 for an element that contains per-vertex data (the slot class is set to D3D11_INPUT_PER_VERTEX_DATA).
		/// </para>
		/// </summary>
		public uint InstanceDataStepRate;
	}

	/// <summary>Provides access to subresource data.</summary>
	/// <remarks>
	/// <para>This structure is used in a call to ID3D11DeviceContext::Map.</para>
	/// <para>The values in these members tell you how much data you can view:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>pData</c> points to row 0 and depth slice 0.</description>
	/// </item>
	/// <item>
	/// <description>
	/// <c>RowPitch</c> contains the value that the runtime adds to <c>pData</c> to move from row to row, where each row contains multiple pixels.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <c>DepthPitch</c> contains the value that the runtime adds to <c>pData</c> to move from depth slice to depth slice, where each depth
	/// slice contains multiple rows.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// When <c>RowPitch</c> and <c>DepthPitch</c> are not appropriate for the resource type, the runtime might set their values to 0. So,
	/// don't use these values for anything other than iterating over rows and depth. Here are some examples:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// For Buffer and Texture1D, the runtime assigns values that aren't 0 to <c>RowPitch</c> and <c>DepthPitch</c>. For example, if a
	/// <c>Buffer</c> contains 8 bytes, the runtime assigns values to <c>RowPitch</c> and <c>DepthPitch</c> that are greater than or equal
	/// to 8.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// For Texture2D, the runtime still assigns a value that isn't 0 to <c>DepthPitch</c>, assuming that the field isn't used.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c>  The runtime might assign values to <c>RowPitch</c> and <c>DepthPitch</c> that are larger than anticipated because there
	/// might be padding between rows and depth.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_mapped_subresource typedef struct D3D11_MAPPED_SUBRESOURCE {
	// void *pData; UINT RowPitch; UINT DepthPitch; } D3D11_MAPPED_SUBRESOURCE;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_MAPPED_SUBRESOURCE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_MAPPED_SUBRESOURCE
	{
		/// <summary>
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// Pointer to the data. When ID3D11DeviceContext::Map provides the pointer, the runtime ensures that the pointer has a specific
		/// alignment, depending on the following feature levels:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>For D3D_FEATURE_LEVEL_10_0 and higher, the pointer is aligned to 16 bytes.</description>
		/// </item>
		/// <item>
		/// <description>For lower than D3D_FEATURE_LEVEL_10_0, the pointer is aligned to 4 bytes.</description>
		/// </item>
		/// </list>
		/// </summary>
		public IntPtr pData;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The row pitch, or width, or physical size (in bytes) of the data.</para>
		/// </summary>
		public uint RowPitch;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The depth pitch, or width, or physical size (in bytes)of the data.</para>
		/// </summary>
		public uint DepthPitch;
	}

	/// <summary>Contains a Message Authentication Code (MAC).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_omac typedef struct D3D11_OMAC { BYTE Omac[16]; } D3D11_OMAC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_OMAC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_OMAC
	{
		/// <summary>A byte array that contains the cryptographic MAC value of the message.</summary>
		public unsafe fixed byte Omac[16];
	}

	/// <summary>Query information about graphics-pipeline activity in between calls to ID3D11DeviceContext::Begin and ID3D11DeviceContext::End.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_query_data_pipeline_statistics typedef struct
	// D3D11_QUERY_DATA_PIPELINE_STATISTICS { UINT64 IAVertices; UINT64 IAPrimitives; UINT64 VSInvocations; UINT64 GSInvocations; UINT64
	// GSPrimitives; UINT64 CInvocations; UINT64 CPrimitives; UINT64 PSInvocations; UINT64 HSInvocations; UINT64 DSInvocations; UINT64
	// CSInvocations; } D3D11_QUERY_DATA_PIPELINE_STATISTICS;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_QUERY_DATA_PIPELINE_STATISTICS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_QUERY_DATA_PIPELINE_STATISTICS
	{
		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>Number of vertices read by input assembler.</para>
		/// </summary>
		public ulong IAVertices;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>
		/// Number of primitives read by the input assembler. This number can be different depending on the primitive topology used. For
		/// example, a triangle strip with 6 vertices will produce 4 triangles, however a triangle list with 6 vertices will produce 2 triangles.
		/// </para>
		/// </summary>
		public ulong IAPrimitives;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>Number of times a vertex shader was invoked. Direct3D invokes the vertex shader once per vertex.</para>
		/// </summary>
		public ulong VSInvocations;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>
		/// Number of times a geometry shader was invoked. When the geometry shader is set to <c>NULL</c>, this statistic may or may not
		/// increment depending on the hardware manufacturer.
		/// </para>
		/// </summary>
		public ulong GSInvocations;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>Number of primitives output by a geometry shader.</para>
		/// </summary>
		public ulong GSPrimitives;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>Number of primitives that were sent to the rasterizer. When the rasterizer is disabled, this will not increment.</para>
		/// </summary>
		public ulong CInvocations;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>
		/// Number of primitives that were rendered. This may be larger or smaller than CInvocations because after a primitive is clipped
		/// sometimes it is either broken up into more than one primitive or completely culled.
		/// </para>
		/// </summary>
		public ulong CPrimitives;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>Number of times a pixel shader was invoked.</para>
		/// </summary>
		public ulong PSInvocations;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>Number of times a hull shader was invoked.</para>
		/// </summary>
		public ulong HSInvocations;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>Number of times a domain shader was invoked.</para>
		/// </summary>
		public ulong DSInvocations;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>Number of times a compute shader was invoked.</para>
		/// </summary>
		public ulong CSInvocations;
	}

	/// <summary>
	/// Query information about the amount of data streamed out to the stream-output buffers in between ID3D11DeviceContext::Begin and ID3D11DeviceContext::End.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_query_data_so_statistics typedef struct
	// D3D11_QUERY_DATA_SO_STATISTICS { UINT64 NumPrimitivesWritten; UINT64 PrimitivesStorageNeeded; } D3D11_QUERY_DATA_SO_STATISTICS;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_QUERY_DATA_SO_STATISTICS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_QUERY_DATA_SO_STATISTICS
	{
		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>Number of primitives (that is, points, lines, and triangles) written to the stream-output buffers.</para>
		/// </summary>
		public ulong NumPrimitivesWritten;

		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>
		/// Number of primitives that would have been written to the stream-output buffers if there had been enough space for them all.
		/// </para>
		/// </summary>
		public ulong PrimitivesStorageNeeded;
	}

	/// <summary>Query information about the reliability of a timestamp query.</summary>
	/// <remarks>For a list of query types see D3D11_QUERY.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_query_data_timestamp_disjoint typedef struct
	// D3D11_QUERY_DATA_TIMESTAMP_DISJOINT { UINT64 Frequency; BOOL Disjoint; } D3D11_QUERY_DATA_TIMESTAMP_DISJOINT;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_QUERY_DATA_TIMESTAMP_DISJOINT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_QUERY_DATA_TIMESTAMP_DISJOINT
	{
		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>How frequently the GPU counter increments in Hz.</para>
		/// </summary>
		public ulong Frequency;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If this is <c>TRUE</c>, something occurred in between the query's ID3D11DeviceContext::Begin and ID3D11DeviceContext::End calls
		/// that caused the timestamp counter to become discontinuous or disjoint, such as unplugging the AC cord on a laptop, overheating,
		/// or throttling up/down due to laptop savings events. The timestamp returned by ID3D11DeviceContext::GetData for a timestamp query
		/// is only reliable if <c>Disjoint</c> is <c>FALSE</c>.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool Disjoint;
	}

	/// <summary>Describes a query.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_query_desc typedef struct D3D11_QUERY_DESC { D3D11_QUERY
	// Query; UINT MiscFlags; } D3D11_QUERY_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_QUERY_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_QUERY_DESC
	{
		/// <summary>
		/// <para>Type: <c>D3D11_QUERY</c></para>
		/// <para>Type of query (see D3D11_QUERY).</para>
		/// </summary>
		public D3D11_QUERY Query;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Miscellaneous flags (see D3D11_QUERY_MISC_FLAG).</para>
		/// </summary>
		public D3D11_QUERY_MISC_FLAG MiscFlags;
	}

	/// <summary>Describes rasterizer state.</summary>
	/// <remarks>
	/// <para>
	/// Rasterizer state defines the behavior of the rasterizer stage. To create a rasterizer-state object, call
	/// ID3D11Device::CreateRasterizerState. To set rasterizer state, call ID3D11DeviceContext::RSSetState.
	/// </para>
	/// <para>If you do not specify some rasterizer state, the Direct3D runtime uses the following default values for rasterizer state.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>State</description>
	/// <description>Default Value</description>
	/// </listheader>
	/// <item>
	/// <description><c>FillMode</c></description>
	/// <description>Solid</description>
	/// </item>
	/// <item>
	/// <description><c>CullMode</c></description>
	/// <description>Back</description>
	/// </item>
	/// <item>
	/// <description><c>FrontCounterClockwise</c></description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description><c>DepthBias</c></description>
	/// <description>0</description>
	/// </item>
	/// <item>
	/// <description><c>SlopeScaledDepthBias</c></description>
	/// <description>0.0f</description>
	/// </item>
	/// <item>
	/// <description><c>DepthBiasClamp</c></description>
	/// <description>0.0f</description>
	/// </item>
	/// <item>
	/// <description><c>DepthClipEnable</c></description>
	/// <description><c>TRUE</c></description>
	/// </item>
	/// <item>
	/// <description><c>ScissorEnable</c></description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description><c>MultisampleEnable</c></description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description><c>AntialiasedLineEnable</c></description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>
	/// <c>Note</c>  For feature levels 9.1, 9.2, 9.3, and 10.0, if you set <c>MultisampleEnable</c> to <c>FALSE</c>, the runtime renders
	/// all points, lines, and triangles without anti-aliasing even for render targets with a sample count greater than 1. For feature
	/// levels 10.1 and higher, the setting of <c>MultisampleEnable</c> has no effect on points and triangles with regard to MSAA and
	/// impacts only the selection of the line-rendering algorithm as shown in this table:
	/// </para>
	/// <para></para>
	/// <list type="table">
	/// <listheader>
	/// <description>Line-rendering algorithm</description>
	/// <description><c>MultisampleEnable</c></description>
	/// <description><c>AntialiasedLineEnable</c></description>
	/// </listheader>
	/// <item>
	/// <description>Aliased</description>
	/// <description><c>FALSE</c></description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description>Alpha antialiased</description>
	/// <description><c>FALSE</c></description>
	/// <description><c>TRUE</c></description>
	/// </item>
	/// <item>
	/// <description>Quadrilateral</description>
	/// <description><c>TRUE</c></description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description>Quadrilateral</description>
	/// <description><c>TRUE</c></description>
	/// <description><c>TRUE</c></description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>
	/// The settings of the <c>MultisampleEnable</c> and <c>AntialiasedLineEnable</c> members apply only to multisample antialiasing (MSAA)
	/// render targets (that is, render targets with sample counts greater than 1). Because of the differences in feature-level behavior and
	/// as long as you aren’t performing any line drawing or don’t mind that lines render as quadrilaterals, we recommend that you always
	/// set <c>MultisampleEnable</c> to <c>TRUE</c> whenever you render on MSAA render targets.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_rasterizer_desc typedef struct D3D11_RASTERIZER_DESC {
	// D3D11_FILL_MODE FillMode; D3D11_CULL_MODE CullMode; BOOL FrontCounterClockwise; INT DepthBias; FLOAT DepthBiasClamp; FLOAT
	// SlopeScaledDepthBias; BOOL DepthClipEnable; BOOL ScissorEnable; BOOL MultisampleEnable; BOOL AntialiasedLineEnable; } D3D11_RASTERIZER_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_RASTERIZER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_RASTERIZER_DESC
	{
		/// <summary>
		/// <para>Type: <c>D3D11_FILL_MODE</c></para>
		/// <para>Determines the fill mode to use when rendering (see D3D11_FILL_MODE).</para>
		/// </summary>
		public D3D11_FILL_MODE FillMode;

		/// <summary>
		/// <para>Type: <c>D3D11_CULL_MODE</c></para>
		/// <para>Indicates triangles facing the specified direction are not drawn (see D3D11_CULL_MODE).</para>
		/// </summary>
		public D3D11_CULL_MODE CullMode;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Determines if a triangle is front- or back-facing. If this parameter is <c>TRUE</c>, a triangle will be considered front-facing
		/// if its vertices are counter-clockwise on the render target and considered back-facing if they are clockwise. If this parameter
		/// is <c>FALSE</c>, the opposite is true.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool FrontCounterClockwise;

		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>Depth value added to a given pixel. For info about depth bias, see Depth Bias.</para>
		/// </summary>
		public int DepthBias;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Maximum depth bias of a pixel. For info about depth bias, see Depth Bias.</para>
		/// </summary>
		public float DepthBiasClamp;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Scalar on a given pixel's slope. For info about depth bias, see Depth Bias.</para>
		/// </summary>
		public float SlopeScaledDepthBias;

		/// <summary>
		///   <para>Type: <c>BOOL</c></para>
		///   <para>Specifies whether to enable clipping based on distance.</para>
		///   <para>The hardware always performs x and y clipping of rasterized coordinates. When <c>DepthClipEnable</c> is set to the default–<c>TRUE</c>, the hardware also clips the z value (that is, the hardware performs the last step of the following algorithm).</para>
		///   <code language="none" title="syntax"><![CDATA[0 < w
		///-w <= x <= w(or arbitrarily wider range if implementation uses a guard band to reduce clipping burden)
		///-w <= y <= w(or arbitrarily wider range if implementation uses a guard band to reduce clipping burden)
		///0 <= z <= w]]></code>
		///   <para>When you set <c>DepthClipEnable</c> to <c>FALSE</c>, the hardware skips the z clipping (that is, the last step in the preceding algorithm). However, the hardware still performs the "0 &lt; w" clipping. When z clipping is disabled, improper depth ordering at the pixel level might result. However, when z clipping is disabled, stencil shadow implementations are simplified. In other words, you can avoid complex special-case handling for geometry that goes beyond the back clipping plane.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool DepthClipEnable;

		/// <summary>
		/// When you set <c>DepthClipEnable</c> to <c>FALSE</c>, the hardware skips the z clipping (that is, the last step in the preceding
		/// algorithm). However, the hardware still performs the "0 &lt; w" clipping. When z clipping is disabled, improper depth ordering
		/// at the pixel level might result. However, when z clipping is disabled, stencil shadow implementations are simplified. In other
		/// words, you can avoid complex special-case handling for geometry that goes beyond the back clipping plane.
		/// </summary>
		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Enable scissor-rectangle culling. All pixels outside an active scissor rectangle are culled.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool ScissorEnable;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Specifies whether to use the quadrilateral or alpha line anti-aliasing algorithm on multisample antialiasing (MSAA) render
		/// targets. Set to <c>TRUE</c> to use the quadrilateral line anti-aliasing algorithm and to <c>FALSE</c> to use the alpha line
		/// anti-aliasing algorithm. For more info about this member, see Remarks.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool MultisampleEnable;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Specifies whether to enable line antialiasing; only applies if doing line drawing and <c>MultisampleEnable</c> is <c>FALSE</c>.
		/// For more info about this member, see Remarks.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool AntialiasedLineEnable;
	}

	/// <summary>Describes the blend state for a render target.</summary>
	/// <remarks>
	/// <para>
	/// You specify an array of <c>D3D11_RENDER_TARGET_BLEND_DESC</c> structures in the <c>RenderTarget</c> member of the D3D11_BLEND_DESC
	/// structure to describe the blend states for render targets; you can bind up to eight render targets to the output-merger stage at one time.
	/// </para>
	/// <para>For info about how blending is done, see the output-merger stage.</para>
	/// <para>Here are the default values for blend state.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>State</description>
	/// <description>Default Value</description>
	/// </listheader>
	/// <item>
	/// <description>BlendEnable</description>
	/// <description>FALSE</description>
	/// </item>
	/// <item>
	/// <description>SrcBlend</description>
	/// <description>D3D11_BLEND_ONE</description>
	/// </item>
	/// <item>
	/// <description>DestBlend</description>
	/// <description>D3D11_BLEND_ZERO</description>
	/// </item>
	/// <item>
	/// <description>BlendOp</description>
	/// <description>D3D11_BLEND_OP_ADD</description>
	/// </item>
	/// <item>
	/// <description>SrcBlendAlpha</description>
	/// <description>D3D11_BLEND_ONE</description>
	/// </item>
	/// <item>
	/// <description>DestBlendAlpha</description>
	/// <description>D3D11_BLEND_ZERO</description>
	/// </item>
	/// <item>
	/// <description>BlendOpAlpha</description>
	/// <description>D3D11_BLEND_OP_ADD</description>
	/// </item>
	/// <item>
	/// <description>RenderTargetWriteMask</description>
	/// <description>D3D11_COLOR_WRITE_ENABLE_ALL</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_render_target_blend_desc typedef struct
	// D3D11_RENDER_TARGET_BLEND_DESC { BOOL BlendEnable; D3D11_BLEND SrcBlend; D3D11_BLEND DestBlend; D3D11_BLEND_OP BlendOp; D3D11_BLEND
	// SrcBlendAlpha; D3D11_BLEND DestBlendAlpha; D3D11_BLEND_OP BlendOpAlpha; UINT8 RenderTargetWriteMask; } D3D11_RENDER_TARGET_BLEND_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_RENDER_TARGET_BLEND_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_RENDER_TARGET_BLEND_DESC
	{
		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Enable (or disable) blending.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool BlendEnable;

		/// <summary>
		/// <para>Type: <c>D3D11_BLEND</c></para>
		/// <para>
		/// This blend option specifies the operation to perform on the RGB value that the pixel shader outputs. The <c>BlendOp</c> member
		/// defines how to combine the <c>SrcBlend</c> and <c>DestBlend</c> operations.
		/// </para>
		/// </summary>
		public D3D11_BLEND SrcBlend;

		/// <summary>
		/// <para>Type: <c>D3D11_BLEND</c></para>
		/// <para>
		/// This blend option specifies the operation to perform on the current RGB value in the render target. The <c>BlendOp</c> member
		/// defines how to combine the <c>SrcBlend</c> and <c>DestBlend</c> operations.
		/// </para>
		/// </summary>
		public D3D11_BLEND DestBlend;

		/// <summary>
		/// <para>Type: <c>D3D11_BLEND_OP</c></para>
		/// <para>This blend operation defines how to combine the <c>SrcBlend</c> and <c>DestBlend</c> operations.</para>
		/// </summary>
		public D3D11_BLEND_OP BlendOp;

		/// <summary>
		/// <para>Type: <c>D3D11_BLEND</c></para>
		/// <para>
		/// This blend option specifies the operation to perform on the alpha value that the pixel shader outputs. Blend options that end in
		/// _COLOR are not allowed. The <c>BlendOpAlpha</c> member defines how to combine the <c>SrcBlendAlpha</c> and <c>DestBlendAlpha</c> operations.
		/// </para>
		/// </summary>
		public D3D11_BLEND SrcBlendAlpha;

		/// <summary>
		/// <para>Type: <c>D3D11_BLEND</c></para>
		/// <para>
		/// This blend option specifies the operation to perform on the current alpha value in the render target. Blend options that end in
		/// _COLOR are not allowed. The <c>BlendOpAlpha</c> member defines how to combine the <c>SrcBlendAlpha</c> and <c>DestBlendAlpha</c> operations.
		/// </para>
		/// </summary>
		public D3D11_BLEND DestBlendAlpha;

		/// <summary>
		/// <para>Type: <c>D3D11_BLEND_OP</c></para>
		/// <para>This blend operation defines how to combine the <c>SrcBlendAlpha</c> and <c>DestBlendAlpha</c> operations.</para>
		/// </summary>
		public D3D11_BLEND_OP BlendOpAlpha;

		/// <summary>
		/// <para>Type: <c>UINT8</c></para>
		/// <para>A write mask.</para>
		/// </summary>
		public byte RenderTargetWriteMask;
	}

	/// <summary>Specifies the subresources from a resource that are accessible using a render-target view.</summary>
	/// <remarks>
	/// <para>A render-target-view description is passed into ID3D11Device::CreateRenderTargetView to create a render target.</para>
	/// <para>A render-target-view cannot use the following formats:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Any typeless format.</description>
	/// </item>
	/// <item>
	/// <description>DXGI_FORMAT_R32G32B32 if the view will be used to bind a buffer (vertex, index, constant, or stream-output).</description>
	/// </item>
	/// </list>
	/// <para>If the format is set to DXGI_FORMAT_UNKNOWN, then the format of the resource that the view binds to the pipeline will be used.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_render_target_view_desc typedef struct
	// D3D11_RENDER_TARGET_VIEW_DESC { DXGI_FORMAT Format; D3D11_RTV_DIMENSION ViewDimension; union { D3D11_BUFFER_RTV Buffer;
	// D3D11_TEX1D_RTV Texture1D; D3D11_TEX1D_ARRAY_RTV Texture1DArray; D3D11_TEX2D_RTV Texture2D; D3D11_TEX2D_ARRAY_RTV Texture2DArray;
	// D3D11_TEX2DMS_RTV Texture2DMS; D3D11_TEX2DMS_ARRAY_RTV Texture2DMSArray; D3D11_TEX3D_RTV Texture3D; }; } D3D11_RENDER_TARGET_VIEW_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_RENDER_TARGET_VIEW_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_RENDER_TARGET_VIEW_DESC
	{
		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>The data format (see DXGI_FORMAT).</para>
		/// </summary>
		public DXGI_FORMAT Format;

		/// <summary>
		/// <para>Type: <c>D3D11_RTV_DIMENSION</c></para>
		/// <para>The resource type (see D3D11_RTV_DIMENSION), which specifies how the render-target resource will be accessed.</para>
		/// </summary>
		public D3D11_RTV_DIMENSION ViewDimension;

		/// <summary>
		/// <para>Type: <c>D3D11_BUFFER_RTV</c></para>
		/// <para>Specifies which buffer elements can be accessed (see D3D11_BUFFER_RTV).</para>
		/// </summary>
		public D3D11_BUFFER_RTV Buffer;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX1D_RTV</c></para>
		/// <para>Specifies the subresources in a 1D texture that can be accessed (see D3D11_TEX1D_RTV).</para>
		/// </summary>
		public D3D11_TEX1D_RTV Texture1D;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX1D_ARRAY_RTV</c></para>
		/// <para>Specifies the subresources in a 1D texture array that can be accessed (see D3D11_TEX1D_ARRAY_RTV).</para>
		/// </summary>
		public D3D11_TEX1D_ARRAY_RTV Texture1DArray;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX2D_RTV</c></para>
		/// <para>Specifies the subresources in a 2D texture that can be accessed (see D3D11_TEX2D_RTV).</para>
		/// </summary>
		public D3D11_TEX2D_RTV Texture2D;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX2D_ARRAY_RTV</c></para>
		/// <para>Specifies the subresources in a 2D texture array that can be accessed (see D3D11_TEX2D_ARRAY_RTV).</para>
		/// </summary>
		public D3D11_TEX2D_ARRAY_RTV Texture2DArray;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX2DMS_RTV</c></para>
		/// <para>Specifies a single subresource because a multisampled 2D texture only contains one subresource (see D3D11_TEX2DMS_RTV).</para>
		/// </summary>
		public D3D11_TEX2DMS_RTV Texture2DMS;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX2DMS_ARRAY_RTV</c></para>
		/// <para>Specifies the subresources in a multisampled 2D texture array that can be accessed (see D3D11_TEX2DMS_ARRAY_RTV).</para>
		/// </summary>
		public D3D11_TEX2DMS_ARRAY_RTV Texture2DMSArray;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX3D_RTV</c></para>
		/// <para>Specifies subresources in a 3D texture that can be accessed (see D3D11_TEX3D_RTV).</para>
		/// </summary>
		public D3D11_TEX3D_RTV Texture3D;
	}

	/// <summary>Describes a sampler state.</summary>
	/// <remarks>
	/// <para>These are the default values for sampler state.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>State</description>
	/// <description>Default Value</description>
	/// </listheader>
	/// <item>
	/// <description>Filter</description>
	/// <description>D3D11_FILTER_MIN_MAG_MIP_LINEAR</description>
	/// </item>
	/// <item>
	/// <description>AddressU</description>
	/// <description>D3D11_TEXTURE_ADDRESS_CLAMP</description>
	/// </item>
	/// <item>
	/// <description>AddressV</description>
	/// <description>D3D11_TEXTURE_ADDRESS_CLAMP</description>
	/// </item>
	/// <item>
	/// <description>AddressW</description>
	/// <description>D3D11_TEXTURE_ADDRESS_CLAMP</description>
	/// </item>
	/// <item>
	/// <description>MinLOD</description>
	/// <description>-3.402823466e+38F (-FLT_MAX)</description>
	/// </item>
	/// <item>
	/// <description>MaxLOD</description>
	/// <description>3.402823466e+38F (FLT_MAX)</description>
	/// </item>
	/// <item>
	/// <description>MipMapLODBias</description>
	/// <description>0.0f</description>
	/// </item>
	/// <item>
	/// <description>MaxAnisotropy</description>
	/// <description>1</description>
	/// </item>
	/// <item>
	/// <description>ComparisonFunc</description>
	/// <description>D3D11_COMPARISON_NEVER</description>
	/// </item>
	/// <item>
	/// <description>BorderColor</description>
	/// <description>float4(1.0f,1.0f,1.0f,1.0f)</description>
	/// </item>
	/// <item>
	/// <description>Texture</description>
	/// <description>N/A</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_sampler_desc typedef struct D3D11_SAMPLER_DESC {
	// D3D11_FILTER Filter; D3D11_TEXTURE_ADDRESS_MODE AddressU; D3D11_TEXTURE_ADDRESS_MODE AddressV; D3D11_TEXTURE_ADDRESS_MODE AddressW;
	// FLOAT MipLODBias; UINT MaxAnisotropy; D3D11_COMPARISON_FUNC ComparisonFunc; FLOAT BorderColor[4]; FLOAT MinLOD; FLOAT MaxLOD; } D3D11_SAMPLER_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_SAMPLER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_SAMPLER_DESC
	{
		/// <summary>
		/// <para>Type: <c>D3D11_FILTER</c></para>
		/// <para>Filtering method to use when sampling a texture (see D3D11_FILTER).</para>
		/// </summary>
		public D3D11_FILTER Filter;

		/// <summary>
		/// <para>Type: <c>D3D11_TEXTURE_ADDRESS_MODE</c></para>
		/// <para>Method to use for resolving a u texture coordinate that is outside the 0 to 1 range (see D3D11_TEXTURE_ADDRESS_MODE).</para>
		/// </summary>
		public D3D11_TEXTURE_ADDRESS_MODE AddressU;

		/// <summary>
		/// <para>Type: <c>D3D11_TEXTURE_ADDRESS_MODE</c></para>
		/// <para>Method to use for resolving a v texture coordinate that is outside the 0 to 1 range.</para>
		/// </summary>
		public D3D11_TEXTURE_ADDRESS_MODE AddressV;

		/// <summary>
		/// <para>Type: <c>D3D11_TEXTURE_ADDRESS_MODE</c></para>
		/// <para>Method to use for resolving a w texture coordinate that is outside the 0 to 1 range.</para>
		/// </summary>
		public D3D11_TEXTURE_ADDRESS_MODE AddressW;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// Offset from the calculated mipmap level. For example, if Direct3D calculates that a texture should be sampled at mipmap level 3
		/// and MipLODBias is 2, then the texture will be sampled at mipmap level 5.
		/// </para>
		/// </summary>
		public float MipLODBias;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Clamping value used if D3D11_FILTER_ANISOTROPIC or D3D11_FILTER_COMPARISON_ANISOTROPIC is specified in Filter. Valid values are
		/// between 1 and 16.
		/// </para>
		/// </summary>
		public uint MaxAnisotropy;

		/// <summary>
		/// <para>Type: <c>D3D11_COMPARISON_FUNC</c></para>
		/// <para>A function that compares sampled data against existing sampled data. The function options are listed in D3D11_COMPARISON_FUNC.</para>
		/// </summary>
		public D3D11_COMPARISON_FUNC ComparisonFunc;

		/// <summary>
		/// <para>Type: <c>FLOAT[4]</c></para>
		/// <para>
		/// Border color to use if D3D11_TEXTURE_ADDRESS_BORDER is specified for AddressU, AddressV, or AddressW. Range must be between 0.0
		/// and 1.0 inclusive.
		/// </para>
		/// </summary>
		public unsafe fixed float BorderColor[4];

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// Lower end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher
		/// than that is less detailed.
		/// </para>
		/// </summary>
		public float MinLOD;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// Upper end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher
		/// than that is less detailed. This value must be greater than or equal to MinLOD. To have no upper limit on LOD set this to a
		/// large value such as D3D11_FLOAT32_MAX.
		/// </para>
		/// </summary>
		public float MaxLOD;
	}

	/// <summary>Describes a shader-resource view.</summary>
	/// <remarks>
	/// <para>
	/// A view is a format-specific way to look at the data in a resource. The view determines what data to look at, and how it is cast when read.
	/// </para>
	/// <para>
	/// When viewing a resource, the resource-view description must specify a typed format, that is compatible with the resource format. So
	/// that means that you cannot create a resource-view description using any format with _TYPELESS in the name. You can however view a
	/// typeless resource by specifying a typed format for the view. For example, a DXGI_FORMAT_R32G32B32_TYPELESS resource can be viewed
	/// with one of these typed formats: DXGI_FORMAT_R32G32B32_FLOAT, DXGI_FORMAT_R32G32B32_UINT, and DXGI_FORMAT_R32G32B32_SINT, since
	/// these typed formats are compatible with the typeless resource.
	/// </para>
	/// <para>
	/// Create a shader-resource-view description by calling ID3D11Device::CreateShaderResourceView. To view a shader-resource-view
	/// description, call ID3D11ShaderResourceView::GetDesc.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_shader_resource_view_desc typedef struct
	// D3D11_SHADER_RESOURCE_VIEW_DESC { DXGI_FORMAT Format; D3D11_SRV_DIMENSION ViewDimension; union { D3D11_BUFFER_SRV Buffer;
	// D3D11_TEX1D_SRV Texture1D; D3D11_TEX1D_ARRAY_SRV Texture1DArray; D3D11_TEX2D_SRV Texture2D; D3D11_TEX2D_ARRAY_SRV Texture2DArray;
	// D3D11_TEX2DMS_SRV Texture2DMS; D3D11_TEX2DMS_ARRAY_SRV Texture2DMSArray; D3D11_TEX3D_SRV Texture3D; D3D11_TEXCUBE_SRV TextureCube;
	// D3D11_TEXCUBE_ARRAY_SRV TextureCubeArray; D3D11_BUFFEREX_SRV BufferEx; }; } D3D11_SHADER_RESOURCE_VIEW_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_SHADER_RESOURCE_VIEW_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_SHADER_RESOURCE_VIEW_DESC
	{
		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>A DXGI_FORMAT specifying the viewing format. See remarks.</para>
		/// </summary>
		public DXGI_FORMAT Format;

		/// <summary>
		/// <para>Type: <c>D3D11_SRV_DIMENSION</c></para>
		/// <para>
		/// The resource type of the view. See D3D11_SRV_DIMENSION. You must set ViewDimension to the same resource type as that of the
		/// underlying resource. This parameter also determines which _SRV to use in the union below.
		/// </para>
		/// </summary>
		public D3D11_SRV_DIMENSION ViewDimension;

		/// <summary>
		/// <para>Type: <c>D3D11_BUFFER_SRV</c></para>
		/// <para>View the resource as a buffer using information from a shader-resource view (see D3D11_BUFFER_SRV).</para>
		/// </summary>
		public D3D11_BUFFER_SRV Buffer;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX1D_SRV</c></para>
		/// <para>View the resource as a 1D texture using information from a shader-resource view (see D3D11_TEX1D_SRV).</para>
		/// </summary>
		public D3D11_TEX1D_SRV Texture1D;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX1D_ARRAY_SRV</c></para>
		/// <para>View the resource as a 1D-texture array using information from a shader-resource view (see D3D11_TEX1D_ARRAY_SRV).</para>
		/// </summary>
		public D3D11_TEX1D_ARRAY_SRV Texture1DArray;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX2D_SRV</c></para>
		/// <para>View the resource as a 2D-texture using information from a shader-resource view (see D3D11_TEX2D_SRV).</para>
		/// </summary>
		public D3D11_TEX2D_SRV Texture2D;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX2D_ARRAY_SRV</c></para>
		/// <para>View the resource as a 2D-texture array using information from a shader-resource view (see D3D11_TEX2D_ARRAY_SRV).</para>
		/// </summary>
		public D3D11_TEX2D_ARRAY_SRV Texture2DArray;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX2DMS_SRV</c></para>
		/// <para>View the resource as a 2D-multisampled texture using information from a shader-resource view (see D3D11_TEX2DMS_SRV).</para>
		/// </summary>
		public D3D11_TEX2DMS_SRV Texture2DMS;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX2DMS_ARRAY_SRV</c></para>
		/// <para>View the resource as a 2D-multisampled-texture array using information from a shader-resource view (see D3D11_TEX2DMS_ARRAY_SRV).</para>
		/// </summary>
		public D3D11_TEX2DMS_ARRAY_SRV Texture2DMSArray;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX3D_SRV</c></para>
		/// <para>View the resource as a 3D texture using information from a shader-resource view (see D3D11_TEX3D_SRV).</para>
		/// </summary>
		public D3D11_TEX3D_SRV Texture3D;

		/// <summary>
		/// <para>Type: <c>D3D11_TEXCUBE_SRV</c></para>
		/// <para>View the resource as a 3D-cube texture using information from a shader-resource view (see D3D11_TEXCUBE_SRV).</para>
		/// </summary>
		public D3D11_TEXCUBE_SRV TextureCube;

		/// <summary>
		/// <para>Type: <c>D3D11_TEXCUBE_ARRAY_SRV</c></para>
		/// <para>View the resource as a 3D-cube-texture array using information from a shader-resource view (see D3D11_TEXCUBE_ARRAY_SRV).</para>
		/// </summary>
		public D3D11_TEXCUBE_ARRAY_SRV TextureCubeArray;

		/// <summary>
		/// <para>Type: <c>D3D11_BUFFEREX_SRV</c></para>
		/// <para>
		/// View the resource as a raw buffer using information from a shader-resource view (see D3D11_BUFFEREX_SRV). For more info about
		/// raw viewing of buffers, see Raw Views of Buffers.
		/// </para>
		/// </summary>
		public D3D11_BUFFEREX_SRV BufferEx;
	}

	/// <summary>Description of a vertex element in a vertex buffer in an output slot.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_so_declaration_entry typedef struct
	// D3D11_SO_DECLARATION_ENTRY { UINT Stream; LPCSTR SemanticName; UINT SemanticIndex; BYTE StartComponent; BYTE ComponentCount; BYTE
	// OutputSlot; } D3D11_SO_DECLARATION_ENTRY;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_SO_DECLARATION_ENTRY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_SO_DECLARATION_ENTRY
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Zero-based, stream number.</para>
		/// </summary>
		public uint Stream;

		/// <summary>
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>
		/// Type of output element; possible values include: <c>"POSITION"</c>, <c>"NORMAL"</c>, or <c>"TEXCOORD0"</c>. Note that if
		/// <c>SemanticName</c> is <c>NULL</c> then <c>ComponentCount</c> can be greater than 4 and the described entry will be a gap in the
		/// stream out where no data will be written.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)] public string SemanticName;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Output element's zero-based index. Should be used if, for example, you have more than one texture coordinate stored in each vertex.
		/// </para>
		/// </summary>
		public uint SemanticIndex;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>
		/// Which component of the entry to begin writing out to. Valid values are 0 to 3. For example, if you only wish to output to the y
		/// and z components of a position, then StartComponent should be 1 and ComponentCount should be 2.
		/// </para>
		/// </summary>
		public byte StartComponent;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>
		/// The number of components of the entry to write out to. Valid values are 1 to 4. For example, if you only wish to output to the y
		/// and z components of a position, then StartComponent should be 1 and ComponentCount should be 2. Note that if <c>SemanticName</c>
		/// is <c>NULL</c> then <c>ComponentCount</c> can be greater than 4 and the described entry will be a gap in the stream out where no
		/// data will be written.
		/// </para>
		/// </summary>
		public byte ComponentCount;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>
		/// The associated stream output buffer that is bound to the pipeline (see ID3D11DeviceContext::SOSetTargets). The valid range for
		/// <c>OutputSlot</c> is 0 to 3.
		/// </para>
		/// </summary>
		public byte OutputSlot;
	}

	/// <summary>Specifies data for initializing a subresource.</summary>
	/// <remarks>
	/// <para>
	/// This structure is used in calls to create buffers (ID3D11Device::CreateBuffer) and textures (ID3D11Device::CreateTexture1D,
	/// ID3D11Device::CreateTexture2D, and ID3D11Device::CreateTexture3D). If the resource you create does not require a system-memory pitch
	/// or a system-memory-slice pitch, you can use those members to pass size information, which might help you when you debug a problem
	/// with creating a resource.
	/// </para>
	/// <para>
	/// A subresource is a single mipmap-level surface. You can pass an array of subresources to one of the preceding methods to create the
	/// resource. A subresource can be 1D, 2D, or 3D. How you set the members of <c>D3D11_SUBRESOURCE_DATA</c> depend on whether the
	/// subresource is 1D, 2D, or 3D.
	/// </para>
	/// <para>
	/// The x, y, and d values are 0-based indices and <c>BytesPerPixel</c> depends on the pixel format. For mipmapped 3D surfaces, the
	/// number of depth slices in each level is half the number of the previous level (minimum 1) and rounded down if dividing by two
	/// results in a non-whole number.
	/// </para>
	/// <para>
	/// <c>Note</c>  An application must not rely on <c>SysMemPitch</c> being exactly equal to the number of texels in a line times the size
	/// of a texel. In some cases, <c>SysMemPitch</c> will include padding to skip past additional data in a line. This could be padding for
	/// alignment or the texture could be a subsection of a larger texture. For example, the <c>D3D11_SUBRESOURCE_DATA</c> structure could
	/// represent a 32 by 32 subsection of a 128 by 128 texture. The value for <c>SysMemSlicePitch</c> will reflect any padding included in <c>SysMemPitch</c>.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_subresource_data typedef struct D3D11_SUBRESOURCE_DATA {
	// const void *pSysMem; UINT SysMemPitch; UINT SysMemSlicePitch; } D3D11_SUBRESOURCE_DATA;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_SUBRESOURCE_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D11_SUBRESOURCE_DATA
	{
		/// <summary>
		/// <para>Type: <c>const void*</c></para>
		/// <para>Pointer to the initialization data.</para>
		/// </summary>
		public IntPtr pSysMem;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The distance (in bytes) from the beginning of one line of a texture to the next line. System-memory pitch is used only for 2D
		/// and 3D texture data as it is has no meaning for the other resource types. Specify the distance from the first pixel of one 2D
		/// slice of a 3D texture to the first pixel of the next 2D slice in that texture in the <c>SysMemSlicePitch</c> member.
		/// </para>
		/// </summary>
		public uint SysMemPitch;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The distance (in bytes) from the beginning of one depth level to the next. System-memory-slice pitch is only used for 3D texture
		/// data as it has no meaning for the other resource types.
		/// </para>
		/// </summary>
		public uint SysMemSlicePitch;
	}

	/// <summary>Specifies the subresources from an array of 1D textures to use in a depth-stencil view.</summary>
	/// <remarks>This structure is one member of a depth-stencil-view description (see D3D11_DEPTH_STENCIL_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex1d_array_dsv typedef struct D3D11_TEX1D_ARRAY_DSV { UINT
	// MipSlice; UINT FirstArraySlice; UINT ArraySize; } D3D11_TEX1D_ARRAY_DSV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX1D_ARRAY_DSV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX1D_ARRAY_DSV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the first mipmap level to use.</para>
		/// </summary>
		public uint MipSlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the first texture to use in an array of textures.</para>
		/// </summary>
		public uint FirstArraySlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of textures to use.</para>
		/// </summary>
		public uint ArraySize;
	}

	/// <summary>Specifies the subresources from an array of 1D textures to use in a render-target view.</summary>
	/// <remarks>This structure is one member of a render-target-view description (see D3D11_RENDER_TARGET_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex1d_array_rtv typedef struct D3D11_TEX1D_ARRAY_RTV { UINT
	// MipSlice; UINT FirstArraySlice; UINT ArraySize; } D3D11_TEX1D_ARRAY_RTV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX1D_ARRAY_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX1D_ARRAY_RTV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the mipmap level to use mip slice.</para>
		/// </summary>
		public uint MipSlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the first texture to use in an array of textures.</para>
		/// </summary>
		public uint FirstArraySlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of textures to use.</para>
		/// </summary>
		public uint ArraySize;
	}

	/// <summary>Specifies the subresources from an array of 1D textures to use in a shader-resource view.</summary>
	/// <remarks>This structure is one member of a shader-resource-view description (see D3D11_SHADER_RESOURCE_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex1d_array_srv typedef struct D3D11_TEX1D_ARRAY_SRV { UINT
	// MostDetailedMip; UINT MipLevels; UINT FirstArraySlice; UINT ArraySize; } D3D11_TEX1D_ARRAY_SRV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX1D_ARRAY_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX1D_ARRAY_SRV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index of the most detailed mipmap level to use; this number is between 0 and <c>MipLevels</c> (from the original Texture1D for
		/// which ID3D11Device::CreateShaderResourceView creates a view) -1.
		/// </para>
		/// </summary>
		public uint MostDetailedMip;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The maximum number of mipmap levels for the view of the texture. See the remarks in D3D11_TEX1D_SRV.</para>
		/// <para>Set to -1 to indicate all the mipmap levels from <c>MostDetailedMip</c> on down to least detailed.</para>
		/// </summary>
		public uint MipLevels;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the first texture to use in an array of textures.</para>
		/// </summary>
		public uint FirstArraySlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of textures in the array.</para>
		/// </summary>
		public uint ArraySize;
	}

	/// <summary>Describes an array of unordered-access 1D texture resources.</summary>
	/// <remarks>This structure is used by a D3D11_UNORDERED_ACCESS_VIEW_DESC.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex1d_array_uav typedef struct D3D11_TEX1D_ARRAY_UAV { UINT
	// MipSlice; UINT FirstArraySlice; UINT ArraySize; } D3D11_TEX1D_ARRAY_UAV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX1D_ARRAY_UAV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX1D_ARRAY_UAV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The mipmap slice index.</para>
		/// </summary>
		public uint MipSlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The zero-based index of the first array slice to be accessed.</para>
		/// </summary>
		public uint FirstArraySlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of slices in the array.</para>
		/// </summary>
		public uint ArraySize;
	}

	/// <summary>Specifies the subresource from a 1D texture that is accessible to a depth-stencil view.</summary>
	/// <remarks>This structure is one member of a depth-stencil-view description (see D3D11_DEPTH_STENCIL_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex1d_dsv typedef struct D3D11_TEX1D_DSV { UINT MipSlice; } D3D11_TEX1D_DSV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX1D_DSV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX1D_DSV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the first mipmap level to use.</para>
		/// </summary>
		public uint MipSlice;
	}

	/// <summary>Specifies the subresource from a 1D texture to use in a render-target view.</summary>
	/// <remarks>This structure is one member of a render-target-view description (see D3D11_RENDER_TARGET_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex1d_rtv typedef struct D3D11_TEX1D_RTV { UINT MipSlice; } D3D11_TEX1D_RTV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX1D_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX1D_RTV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the mipmap level to use mip slice.</para>
		/// </summary>
		public uint MipSlice;
	}

	/// <summary>Specifies the subresource from a 1D texture to use in a shader-resource view.</summary>
	/// <remarks>
	/// <para>This structure is one member of a shader-resource-view description (see D3D11_SHADER_RESOURCE_VIEW_DESC).</para>
	/// <para>
	/// As an example, assuming <c>MostDetailedMip</c> = 6 and <c>MipLevels</c> = 2, the view will have access to 2 mipmap levels, 6 and 7,
	/// of the original texture for which ID3D11Device::CreateShaderResourceView creates the view. In this situation, <c>MostDetailedMip</c>
	/// is greater than the <c>MipLevels</c> in the view. However, <c>MostDetailedMip</c> is not greater than the <c>MipLevels</c> in the
	/// original resource.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex1d_srv typedef struct D3D11_TEX1D_SRV { UINT
	// MostDetailedMip; UINT MipLevels; } D3D11_TEX1D_SRV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX1D_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX1D_SRV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index of the most detailed mipmap level to use; this number is between 0 and <c>MipLevels</c> (from the original Texture1D for
		/// which ID3D11Device::CreateShaderResourceView creates a view) -1.
		/// </para>
		/// </summary>
		public uint MostDetailedMip;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The maximum number of mipmap levels for the view of the texture. See the remarks.</para>
		/// <para>Set to -1 to indicate all the mipmap levels from <c>MostDetailedMip</c> on down to least detailed.</para>
		/// </summary>
		public uint MipLevels;
	}

	/// <summary>Describes a unordered-access 1D texture resource.</summary>
	/// <remarks>This structure is used by a D3D11_UNORDERED_ACCESS_VIEW_DESC.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex1d_uav typedef struct D3D11_TEX1D_UAV { UINT MipSlice; } D3D11_TEX1D_UAV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX1D_UAV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX1D_UAV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The mipmap slice index.</para>
		/// </summary>
		public uint MipSlice;
	}

	/// <summary>Specifies the subresources from an array 2D textures that are accessible to a depth-stencil view.</summary>
	/// <remarks>This structure is one member of a depth-stencil-view description (see D3D11_DEPTH_STENCIL_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2d_array_dsv typedef struct D3D11_TEX2D_ARRAY_DSV { UINT
	// MipSlice; UINT FirstArraySlice; UINT ArraySize; } D3D11_TEX2D_ARRAY_DSV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2D_ARRAY_DSV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2D_ARRAY_DSV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the first mipmap level to use.</para>
		/// </summary>
		public uint MipSlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the first texture to use in an array of textures.</para>
		/// </summary>
		public uint FirstArraySlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of textures to use.</para>
		/// </summary>
		public uint ArraySize;
	}

	/// <summary>Specifies the subresources from an array of 2D textures to use in a render-target view.</summary>
	/// <remarks>This structure is one member of a render-target-view description (see D3D11_RENDER_TARGET_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2d_array_rtv typedef struct D3D11_TEX2D_ARRAY_RTV { UINT
	// MipSlice; UINT FirstArraySlice; UINT ArraySize; } D3D11_TEX2D_ARRAY_RTV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2D_ARRAY_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2D_ARRAY_RTV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the mipmap level to use mip slice.</para>
		/// </summary>
		public uint MipSlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the first texture to use in an array of textures.</para>
		/// </summary>
		public uint FirstArraySlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of textures in the array to use in the render target view, starting from <c>FirstArraySlice</c>.</para>
		/// </summary>
		public uint ArraySize;
	}

	/// <summary>Specifies the subresources from an array of 2D textures to use in a shader-resource view.</summary>
	/// <remarks>This structure is one member of a shader-resource-view description (see D3D11_SHADER_RESOURCE_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2d_array_srv typedef struct D3D11_TEX2D_ARRAY_SRV { UINT
	// MostDetailedMip; UINT MipLevels; UINT FirstArraySlice; UINT ArraySize; } D3D11_TEX2D_ARRAY_SRV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2D_ARRAY_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2D_ARRAY_SRV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index of the most detailed mipmap level to use; this number is between 0 and <c>MipLevels</c> (from the original Texture2D for
		/// which ID3D11Device::CreateShaderResourceView creates a view) -1.
		/// </para>
		/// </summary>
		public uint MostDetailedMip;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The maximum number of mipmap levels for the view of the texture. See the remarks in D3D11_TEX1D_SRV.</para>
		/// <para>Set to -1 to indicate all the mipmap levels from <c>MostDetailedMip</c> on down to least detailed.</para>
		/// </summary>
		public uint MipLevels;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the first texture to use in an array of textures.</para>
		/// </summary>
		public uint FirstArraySlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of textures in the array.</para>
		/// </summary>
		public uint ArraySize;
	}

	/// <summary>Describes an array of unordered-access 2D texture resources.</summary>
	/// <remarks>This structure is used by a D3D11_UNORDERED_ACCESS_VIEW_DESC.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2d_array_uav typedef struct D3D11_TEX2D_ARRAY_UAV { UINT
	// MipSlice; UINT FirstArraySlice; UINT ArraySize; } D3D11_TEX2D_ARRAY_UAV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2D_ARRAY_UAV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2D_ARRAY_UAV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The mipmap slice index.</para>
		/// </summary>
		public uint MipSlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The zero-based index of the first array slice to be accessed.</para>
		/// </summary>
		public uint FirstArraySlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of slices in the array.</para>
		/// </summary>
		public uint ArraySize;
	}

	/// <summary>Identifies a texture resource for a video processor output view.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2d_array_vpov typedef struct D3D11_TEX2D_ARRAY_VPOV {
	// UINT MipSlice; UINT FirstArraySlice; UINT ArraySize; } D3D11_TEX2D_ARRAY_VPOV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2D_ARRAY_VPOV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2D_ARRAY_VPOV
	{
		/// <summary>The zero-based index into the array of subtextures.</summary>
		public uint MipSlice;

		/// <summary>The index of the first texture to use.</summary>
		public uint FirstArraySlice;

		/// <summary>The number of textures in the array.</summary>
		public uint ArraySize;
	}

	/// <summary>Specifies the subresource from a 2D texture that is accessible to a depth-stencil view.</summary>
	/// <remarks>This structure is one member of a depth-stencil-view description (see D3D11_DEPTH_STENCIL_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2d_dsv typedef struct D3D11_TEX2D_DSV { UINT MipSlice; } D3D11_TEX2D_DSV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2D_DSV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2D_DSV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the first mipmap level to use.</para>
		/// </summary>
		public uint MipSlice;
	}

	/// <summary>Specifies the subresource from a 2D texture to use in a render-target view.</summary>
	/// <remarks>This structure is one member of a render-target-view description (see D3D11_RENDER_TARGET_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2d_rtv typedef struct D3D11_TEX2D_RTV { UINT MipSlice; } D3D11_TEX2D_RTV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2D_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2D_RTV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the mipmap level to use mip slice.</para>
		/// </summary>
		public uint MipSlice;
	}

	/// <summary>Specifies the subresource from a 2D texture to use in a shader-resource view.</summary>
	/// <remarks>This structure is one member of a shader-resource-view description (see D3D11_SHADER_RESOURCE_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2d_srv typedef struct D3D11_TEX2D_SRV { UINT
	// MostDetailedMip; UINT MipLevels; } D3D11_TEX2D_SRV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2D_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2D_SRV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index of the most detailed mipmap level to use; this number is between 0 and <c>MipLevels</c> (from the original Texture2D for
		/// which ID3D11Device::CreateShaderResourceView creates a view) -1.
		/// </para>
		/// </summary>
		public uint MostDetailedMip;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The maximum number of mipmap levels for the view of the texture. See the remarks in D3D11_TEX1D_SRV.</para>
		/// <para>Set to -1 to indicate all the mipmap levels from <c>MostDetailedMip</c> on down to least detailed.</para>
		/// </summary>
		public uint MipLevels;
	}

	/// <summary>Describes a unordered-access 2D texture resource.</summary>
	/// <remarks>This structure is used by a D3D11_UNORDERED_ACCESS_VIEW_DESC.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2d_uav typedef struct D3D11_TEX2D_UAV { UINT MipSlice; } D3D11_TEX2D_UAV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2D_UAV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2D_UAV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The mipmap slice index.</para>
		/// </summary>
		public uint MipSlice;
	}

	/// <summary>Identifies the texture resource for a video decoder output view.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2d_vdov typedef struct D3D11_TEX2D_VDOV { UINT
	// ArraySlice; } D3D11_TEX2D_VDOV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2D_VDOV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2D_VDOV
	{
		/// <summary>The zero-based index of the texture.</summary>
		public uint ArraySlice;
	}

	/// <summary>Identifies the texture resource for a video processor input view.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2d_vpiv typedef struct D3D11_TEX2D_VPIV { UINT MipSlice;
	// UINT ArraySlice; } D3D11_TEX2D_VPIV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2D_VPIV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2D_VPIV
	{
		/// <summary>The zero-based index into the array of subtextures.</summary>
		public uint MipSlice;

		/// <summary>The zero-based index of the texture.</summary>
		public uint ArraySlice;
	}

	/// <summary>Identifies a texture resource for a video processor output view.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2d_vpov typedef struct D3D11_TEX2D_VPOV { UINT MipSlice;
	// } D3D11_TEX2D_VPOV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2D_VPOV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2D_VPOV
	{
		/// <summary>The zero-based index into the array of subtextures.</summary>
		public uint MipSlice;
	}

	/// <summary>Specifies the subresources from an array of multisampled 2D textures for a depth-stencil view.</summary>
	/// <remarks>This structure is one member of a depth-stencil-view description (see D3D11_DEPTH_STENCIL_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2dms_array_dsv typedef struct D3D11_TEX2DMS_ARRAY_DSV {
	// UINT FirstArraySlice; UINT ArraySize; } D3D11_TEX2DMS_ARRAY_DSV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2DMS_ARRAY_DSV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2DMS_ARRAY_DSV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the first texture to use in an array of textures.</para>
		/// </summary>
		public uint FirstArraySlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of textures to use.</para>
		/// </summary>
		public uint ArraySize;
	}

	/// <summary>Specifies the subresources from a an array of multisampled 2D textures to use in a render-target view.</summary>
	/// <remarks>This structure is one member of a render-target-view description (see D3D11_RENDER_TARGET_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2dms_array_rtv typedef struct D3D11_TEX2DMS_ARRAY_RTV {
	// UINT FirstArraySlice; UINT ArraySize; } D3D11_TEX2DMS_ARRAY_RTV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2DMS_ARRAY_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2DMS_ARRAY_RTV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the first texture to use in an array of textures.</para>
		/// </summary>
		public uint FirstArraySlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of textures to use.</para>
		/// </summary>
		public uint ArraySize;
	}

	/// <summary>Specifies the subresources from an array of multisampled 2D textures to use in a shader-resource view.</summary>
	/// <remarks>This structure is one member of a shader-resource-view description (see D3D11_SHADER_RESOURCE_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2dms_array_srv typedef struct D3D11_TEX2DMS_ARRAY_SRV {
	// UINT FirstArraySlice; UINT ArraySize; } D3D11_TEX2DMS_ARRAY_SRV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2DMS_ARRAY_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2DMS_ARRAY_SRV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the first texture to use in an array of textures.</para>
		/// </summary>
		public uint FirstArraySlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of textures to use.</para>
		/// </summary>
		public uint ArraySize;
	}

	/// <summary>Specifies the subresource from a multisampled 2D texture that is accessible to a depth-stencil view.</summary>
	/// <remarks>
	/// Because a multisampled 2D texture contains a single subtexture, there is nothing to specify; this unused member is included so that
	/// this structure will compile in C.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2dms_dsv typedef struct D3D11_TEX2DMS_DSV { UINT
	// UnusedField_NothingToDefine; } D3D11_TEX2DMS_DSV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2DMS_DSV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2DMS_DSV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Unused.</para>
		/// </summary>
		public uint UnusedField_NothingToDefine;
	}

	/// <summary>Specifies the subresource from a multisampled 2D texture to use in a render-target view.</summary>
	/// <remarks>
	/// Since a multisampled 2D texture contains a single subresource, there is actually nothing to specify in D3D11_TEX2DMS_RTV.
	/// Consequently, <c>UnusedField_NothingToDefine</c> is included so that this structure will compile in C.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2dms_rtv typedef struct D3D11_TEX2DMS_RTV { UINT
	// UnusedField_NothingToDefine; } D3D11_TEX2DMS_RTV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2DMS_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2DMS_RTV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Integer of any value. See remarks.</para>
		/// </summary>
		public uint UnusedField_NothingToDefine;
	}

	/// <summary>Specifies the subresources from a multisampled 2D texture to use in a shader-resource view.</summary>
	/// <remarks>
	/// Since a multisampled 2D texture contains a single subresource, there is actually nothing to specify in D3D11_TEX2DMS_RTV.
	/// Consequently, <c>UnusedField_NothingToDefine</c> is included so that this structure will compile in C.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2dms_srv typedef struct D3D11_TEX2DMS_SRV { UINT
	// UnusedField_NothingToDefine; } D3D11_TEX2DMS_SRV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX2DMS_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX2DMS_SRV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Integer of any value. See remarks.</para>
		/// </summary>
		public uint UnusedField_NothingToDefine;
	}

	/// <summary>Specifies the subresources from a 3D texture to use in a render-target view.</summary>
	/// <remarks>This structure is one member of a render target view. See D3D11_RENDER_TARGET_VIEW_DESC.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex3d_rtv typedef struct D3D11_TEX3D_RTV { UINT MipSlice;
	// UINT FirstWSlice; UINT WSize; } D3D11_TEX3D_RTV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX3D_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX3D_RTV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the mipmap level to use mip slice.</para>
		/// </summary>
		public uint MipSlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>First depth level to use.</para>
		/// </summary>
		public uint FirstWSlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Number of depth levels to use in the render-target view, starting from <c>FirstWSlice</c>. A value of -1 indicates all of the
		/// slices along the w axis, starting from <c>FirstWSlice</c>.
		/// </para>
		/// </summary>
		public uint WSize;
	}

	/// <summary>Specifies the subresources from a 3D texture to use in a shader-resource view.</summary>
	/// <remarks>This structure is one member of a shader-resource-view description (see D3D11_SHADER_RESOURCE_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex3d_srv typedef struct D3D11_TEX3D_SRV { UINT
	// MostDetailedMip; UINT MipLevels; } D3D11_TEX3D_SRV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX3D_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX3D_SRV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index of the most detailed mipmap level to use; this number is between 0 and <c>MipLevels</c> (from the original Texture3D for
		/// which ID3D11Device::CreateShaderResourceView creates a view) -1.
		/// </para>
		/// </summary>
		public uint MostDetailedMip;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The maximum number of mipmap levels for the view of the texture. See the remarks in D3D11_TEX1D_SRV.</para>
		/// <para>Set to -1 to indicate all the mipmap levels from <c>MostDetailedMip</c> on down to least detailed.</para>
		/// </summary>
		public uint MipLevels;
	}

	/// <summary>Describes a unordered-access 3D texture resource.</summary>
	/// <remarks>This structure is used by a D3D11_UNORDERED_ACCESS_VIEW_DESC.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex3d_uav typedef struct D3D11_TEX3D_UAV { UINT MipSlice;
	// UINT FirstWSlice; UINT WSize; } D3D11_TEX3D_UAV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEX3D_UAV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEX3D_UAV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The mipmap slice index.</para>
		/// </summary>
		public uint MipSlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The zero-based index of the first depth slice to be accessed.</para>
		/// </summary>
		public uint FirstWSlice;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of depth slices.</para>
		/// </summary>
		public uint WSize;
	}

	/// <summary>Specifies the subresources from an array of cube textures to use in a shader-resource view.</summary>
	/// <remarks>This structure is one member of a shader-resource-view description (see D3D11_SHADER_RESOURCE_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_texcube_array_srv typedef struct D3D11_TEXCUBE_ARRAY_SRV {
	// UINT MostDetailedMip; UINT MipLevels; UINT First2DArrayFace; UINT NumCubes; } D3D11_TEXCUBE_ARRAY_SRV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEXCUBE_ARRAY_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEXCUBE_ARRAY_SRV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index of the most detailed mipmap level to use; this number is between 0 and <c>MipLevels</c> (from the original TextureCube for
		/// which ID3D11Device::CreateShaderResourceView creates a view) -1.
		/// </para>
		/// </summary>
		public uint MostDetailedMip;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The maximum number of mipmap levels for the view of the texture. See the remarks in D3D11_TEX1D_SRV.</para>
		/// <para>Set to -1 to indicate all the mipmap levels from <c>MostDetailedMip</c> on down to least detailed.</para>
		/// </summary>
		public uint MipLevels;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Index of the first 2D texture to use.</para>
		/// </summary>
		public uint First2DArrayFace;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of cube textures in the array.</para>
		/// </summary>
		public uint NumCubes;
	}

	/// <summary>Specifies the subresource from a cube texture to use in a shader-resource view.</summary>
	/// <remarks>This structure is one member of a shader-resource-view description (see D3D11_SHADER_RESOURCE_VIEW_DESC).</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_texcube_srv typedef struct D3D11_TEXCUBE_SRV { UINT
	// MostDetailedMip; UINT MipLevels; } D3D11_TEXCUBE_SRV;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEXCUBE_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEXCUBE_SRV
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index of the most detailed mipmap level to use; this number is between 0 and <c>MipLevels</c> (from the original TextureCube for
		/// which ID3D11Device::CreateShaderResourceView creates a view) -1.
		/// </para>
		/// </summary>
		public uint MostDetailedMip;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The maximum number of mipmap levels for the view of the texture. See the remarks in D3D11_TEX1D_SRV.</para>
		/// <para>Set to -1 to indicate all the mipmap levels from <c>MostDetailedMip</c> on down to least detailed.</para>
		/// </summary>
		public uint MipLevels;
	}

	/// <summary>Describes a 1D texture.</summary>
	/// <remarks>
	/// <para>This structure is used in a call to ID3D11Device::CreateTexture1D.</para>
	/// <para>
	/// In addition to this structure, you can also use the CD3D11_TEXTURE1D_DESC derived structure, which is defined in D3D11.h and behaves
	/// like an inherited class, to help create a texture description.
	/// </para>
	/// <para>
	/// The texture size range is determined by the feature level at which you create the device and not the Microsoft Direct3D interface
	/// version. For example, if you use Microsoft Direct3D 10 hardware at feature level 10 (D3D_FEATURE_LEVEL_10_0) and call
	/// D3D11CreateDevice to create an ID3D11Device, you must constrain the maximum texture size to D3D10_REQ_TEXTURE1D_U_DIMENSION (8192)
	/// when you create your 1D texture.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_texture1d_desc typedef struct D3D11_TEXTURE1D_DESC { UINT
	// Width; UINT MipLevels; UINT ArraySize; DXGI_FORMAT Format; D3D11_USAGE Usage; UINT BindFlags; UINT CPUAccessFlags; UINT MiscFlags; } D3D11_TEXTURE1D_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEXTURE1D_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEXTURE1D_DESC
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Texture width (in texels). The range is from 1 to D3D11_REQ_TEXTURE1D_U_DIMENSION (16384). However, the range is actually
		/// constrained by the feature level at which you create the rendering device. For more information about restrictions, see Remarks.
		/// </para>
		/// </summary>
		public uint Width;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The maximum number of mipmap levels in the texture. See the remarks in D3D11_TEX1D_SRV. Use 1 for a multisampled texture; or 0
		/// to generate a full set of subtextures.
		/// </para>
		/// </summary>
		public uint MipLevels;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Number of textures in the array. The range is from 1 to D3D11_REQ_TEXTURE1D_ARRAY_AXIS_DIMENSION (2048). However, the range is
		/// actually constrained by the feature level at which you create the rendering device. For more information about restrictions, see Remarks.
		/// </para>
		/// </summary>
		public uint ArraySize;

		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>Texture format (see DXGI_FORMAT).</para>
		/// </summary>
		public DXGI_FORMAT Format;

		/// <summary>
		/// <para>Type: <c>D3D11_USAGE</c></para>
		/// <para>
		/// Value that identifies how the texture is to be read from and written to. The most common value is D3D11_USAGE_DEFAULT; see
		/// D3D11_USAGE for all possible values.
		/// </para>
		/// </summary>
		public D3D11_USAGE Usage;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Flags (see D3D11_BIND_FLAG) for binding to pipeline stages. The flags can be combined by a bitwise OR. For a 1D texture, the
		/// allowable values are: D3D11_BIND_SHADER_RESOURCE, D3D11_BIND_RENDER_TARGET and D3D11_BIND_DEPTH_STENCIL.
		/// </para>
		/// </summary>
		public D3D11_BIND_FLAG BindFlags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Flags (see D3D11_CPU_ACCESS_FLAG) to specify the types of CPU access allowed. Use 0 if CPU access is not required. These flags
		/// can be combined with a bitwise OR.
		/// </para>
		/// </summary>
		public D3D11_CPU_ACCESS_FLAG CPUAccessFlags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Flags (see D3D11_RESOURCE_MISC_FLAG) that identify other, less common resource options. Use 0 if none of these flags apply.
		/// These flags can be combined with a bitwise OR.
		/// </para>
		/// </summary>
		public D3D11_RESOURCE_MISC_FLAG MiscFlags;
	}

	/// <summary>Describes a 2D texture.</summary>
	/// <remarks>
	/// <para>This structure is used in a call to ID3D11Device::CreateTexture2D.</para>
	/// <para>
	/// In addition to this structure, you can also use the CD3D11_TEXTURE2D_DESC derived structure, which is defined in D3D11.h and behaves
	/// like an inherited class, to help create a texture description.
	/// </para>
	/// <para>
	/// The device places some size restrictions (must be multiples of a minimum size) for a subsampled, block compressed, or bit-format resource.
	/// </para>
	/// <para>
	/// The texture size range is determined by the feature level at which you create the device and not the Microsoft Direct3D interface
	/// version. For example, if you use Microsoft Direct3D 10 hardware at feature level 10 (D3D_FEATURE_LEVEL_10_0) and call
	/// D3D11CreateDevice to create an ID3D11Device, you must constrain the maximum texture size to D3D10_REQ_TEXTURE2D_U_OR_V_DIMENSION
	/// (8192) when you create your 2D texture.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_texture2d_desc typedef struct D3D11_TEXTURE2D_DESC { UINT
	// Width; UINT Height; UINT MipLevels; UINT ArraySize; DXGI_FORMAT Format; DXGI_SAMPLE_DESC SampleDesc; D3D11_USAGE Usage; UINT
	// BindFlags; UINT CPUAccessFlags; UINT MiscFlags; } D3D11_TEXTURE2D_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEXTURE2D_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEXTURE2D_DESC
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Texture width (in texels). The range is from 1 to D3D11_REQ_TEXTURE2D_U_OR_V_DIMENSION (16384). For a texture cube-map, the
		/// range is from 1 to D3D11_REQ_TEXTURECUBE_DIMENSION (16384). However, the range is actually constrained by the feature level at
		/// which you create the rendering device. For more information about restrictions, see Remarks.
		/// </para>
		/// </summary>
		public uint Width;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Texture height (in texels). The range is from 1 to D3D11_REQ_TEXTURE2D_U_OR_V_DIMENSION (16384). For a texture cube-map, the
		/// range is from 1 to D3D11_REQ_TEXTURECUBE_DIMENSION (16384). However, the range is actually constrained by the feature level at
		/// which you create the rendering device. For more information about restrictions, see Remarks.
		/// </para>
		/// </summary>
		public uint Height;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The maximum number of mipmap levels in the texture. See the remarks in D3D11_TEX1D_SRV. Use 1 for a multisampled texture; or 0
		/// to generate a full set of subtextures.
		/// </para>
		/// </summary>
		public uint MipLevels;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Number of textures in the texture array. The range is from 1 to D3D11_REQ_TEXTURE2D_ARRAY_AXIS_DIMENSION (2048). For a texture
		/// cube-map, this value is a multiple of 6 (that is, 6 times the value in the <c>NumCubes</c> member of D3D11_TEXCUBE_ARRAY_SRV),
		/// and the range is from 6 to 2046. The range is actually constrained by the feature level at which you create the rendering
		/// device. For more information about restrictions, see Remarks.
		/// </para>
		/// </summary>
		public uint ArraySize;

		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>Texture format (see DXGI_FORMAT).</para>
		/// </summary>
		public DXGI_FORMAT Format;

		/// <summary>
		/// <para>Type: <c>DXGI_SAMPLE_DESC</c></para>
		/// <para>Structure that specifies multisampling parameters for the texture. See DXGI_SAMPLE_DESC.</para>
		/// </summary>
		public DXGI_SAMPLE_DESC SampleDesc;

		/// <summary>
		/// <para>Type: <c>D3D11_USAGE</c></para>
		/// <para>
		/// Value that identifies how the texture is to be read from and written to. The most common value is D3D11_USAGE_DEFAULT; see
		/// D3D11_USAGE for all possible values.
		/// </para>
		/// </summary>
		public D3D11_USAGE Usage;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Flags (see D3D11_BIND_FLAG) for binding to pipeline stages. The flags can be combined by a bitwise OR.</para>
		/// </summary>
		public D3D11_BIND_FLAG BindFlags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Flags (see D3D11_CPU_ACCESS_FLAG) to specify the types of CPU access allowed. Use 0 if CPU access is not required. These flags
		/// can be combined with a bitwise OR.
		/// </para>
		/// </summary>
		public D3D11_CPU_ACCESS_FLAG CPUAccessFlags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Flags (see D3D11_RESOURCE_MISC_FLAG) that identify other, less common resource options. Use 0 if none of these flags apply.
		/// These flags can be combined by using a bitwise OR. For a texture cube-map, set the D3D11_RESOURCE_MISC_TEXTURECUBE flag.
		/// Cube-map arrays (that is, <c>ArraySize</c> &gt; 6) require feature level D3D_FEATURE_LEVEL_10_1 or higher.
		/// </para>
		/// </summary>
		public D3D11_RESOURCE_MISC_FLAG MiscFlags;
	}

	/// <summary>Describes a 3D texture.</summary>
	/// <remarks>
	/// <para>This structure is used in a call to ID3D11Device::CreateTexture3D.</para>
	/// <para>
	/// In addition to this structure, you can also use the CD3D11_TEXTURE3D_DESC derived structure, which is defined in D3D11.h and behaves
	/// like an inherited class, to help create a texture description.
	/// </para>
	/// <para>
	/// The device restricts the size of subsampled, block compressed, and bit format resources to be multiples of sizes specific to each format.
	/// </para>
	/// <para>
	/// The texture size range is determined by the feature level at which you create the device and not the Microsoft Direct3D interface
	/// version. For example, if you use Microsoft Direct3D 10 hardware at feature level 10 (D3D_FEATURE_LEVEL_10_0) and call
	/// D3D11CreateDevice to create an ID3D11Device, you must constrain the maximum texture size to D3D10_REQ_TEXTURE3D_U_V_OR_W_DIMENSION
	/// (2048) when you create your 3D texture.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_texture3d_desc typedef struct D3D11_TEXTURE3D_DESC { UINT
	// Width; UINT Height; UINT Depth; UINT MipLevels; DXGI_FORMAT Format; D3D11_USAGE Usage; UINT BindFlags; UINT CPUAccessFlags; UINT
	// MiscFlags; } D3D11_TEXTURE3D_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_TEXTURE3D_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_TEXTURE3D_DESC
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Texture width (in texels). The range is from 1 to D3D11_REQ_TEXTURE3D_U_V_OR_W_DIMENSION (2048). However, the range is actually
		/// constrained by the feature level at which you create the rendering device. For more information about restrictions, see Remarks.
		/// </para>
		/// </summary>
		public uint Width;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Texture height (in texels). The range is from 1 to D3D11_REQ_TEXTURE3D_U_V_OR_W_DIMENSION (2048). However, the range is actually
		/// constrained by the feature level at which you create the rendering device. For more information about restrictions, see Remarks.
		/// </para>
		/// </summary>
		public uint Height;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Texture depth (in texels). The range is from 1 to D3D11_REQ_TEXTURE3D_U_V_OR_W_DIMENSION (2048). However, the range is actually
		/// constrained by the feature level at which you create the rendering device. For more information about restrictions, see Remarks.
		/// </para>
		/// </summary>
		public uint Depth;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The maximum number of mipmap levels in the texture. See the remarks in D3D11_TEX1D_SRV. Use 1 for a multisampled texture; or 0
		/// to generate a full set of subtextures.
		/// </para>
		/// </summary>
		public uint MipLevels;

		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>Texture format (see DXGI_FORMAT).</para>
		/// </summary>
		public DXGI_FORMAT Format;

		/// <summary>
		/// <para>Type: <c>D3D11_USAGE</c></para>
		/// <para>
		/// Value that identifies how the texture is to be read from and written to. The most common value is D3D11_USAGE_DEFAULT; see
		/// D3D11_USAGE for all possible values.
		/// </para>
		/// </summary>
		public D3D11_USAGE Usage;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Flags (see D3D11_BIND_FLAG) for binding to pipeline stages. The flags can be combined by a bitwise OR.</para>
		/// </summary>
		public D3D11_BIND_FLAG BindFlags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Flags (see D3D11_CPU_ACCESS_FLAG) to specify the types of CPU access allowed. Use 0 if CPU access is not required. These flags
		/// can be combined with a bitwise OR.
		/// </para>
		/// </summary>
		public D3D11_CPU_ACCESS_FLAG CPUAccessFlags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Flags (see D3D11_RESOURCE_MISC_FLAG) that identify other, less common resource options. Use 0 if none of these flags apply.
		/// These flags can be combined with a bitwise OR.
		/// </para>
		/// </summary>
		public D3D11_RESOURCE_MISC_FLAG MiscFlags;
	}

	/// <summary>Specifies the subresources from a resource that are accessible using an unordered-access view.</summary>
	/// <remarks>An unordered-access-view description is passed into ID3D11Device::CreateUnorderedAccessView to create a view.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_unordered_access_view_desc typedef struct
	// D3D11_UNORDERED_ACCESS_VIEW_DESC { DXGI_FORMAT Format; D3D11_UAV_DIMENSION ViewDimension; union { D3D11_BUFFER_UAV Buffer;
	// D3D11_TEX1D_UAV Texture1D; D3D11_TEX1D_ARRAY_UAV Texture1DArray; D3D11_TEX2D_UAV Texture2D; D3D11_TEX2D_ARRAY_UAV Texture2DArray;
	// D3D11_TEX3D_UAV Texture3D; }; } D3D11_UNORDERED_ACCESS_VIEW_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_UNORDERED_ACCESS_VIEW_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_UNORDERED_ACCESS_VIEW_DESC
	{
		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>The data format (see DXGI_FORMAT).</para>
		/// </summary>
		public DXGI_FORMAT Format;

		/// <summary>
		/// <para>Type: <c>D3D11_UAV_DIMENSION</c></para>
		/// <para>The resource type (see D3D11_UAV_DIMENSION), which specifies how the resource will be accessed.</para>
		/// </summary>
		public D3D11_UAV_DIMENSION ViewDimension;

		/// <summary>
		/// <para>Type: <c>D3D11_BUFFER_UAV</c></para>
		/// <para>Specifies which buffer elements can be accessed (see D3D11_BUFFER_UAV).</para>
		/// </summary>
		public D3D11_BUFFER_UAV Buffer;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX1D_UAV</c></para>
		/// <para>Specifies the subresources in a 1D texture that can be accessed (see D3D11_TEX1D_UAV).</para>
		/// </summary>
		public D3D11_TEX1D_UAV Texture1D;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX1D_ARRAY_UAV</c></para>
		/// <para>Specifies the subresources in a 1D texture array that can be accessed (see D3D11_TEX1D_ARRAY_UAV).</para>
		/// </summary>
		public D3D11_TEX1D_ARRAY_UAV Texture1DArray;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX2D_UAV</c></para>
		/// <para>Specifies the subresources in a 2D texture that can be accessed (see D3D11_TEX2D_UAV).</para>
		/// </summary>
		public D3D11_TEX2D_UAV Texture2D;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX2D_ARRAY_UAV</c></para>
		/// <para>Specifies the subresources in a 2D texture array that can be accessed (see D3D11_TEX2D_ARRAY_UAV).</para>
		/// </summary>
		public D3D11_TEX2D_ARRAY_UAV Texture2DArray;

		/// <summary>
		/// <para>Type: <c>D3D11_TEX3D_UAV</c></para>
		/// <para>Specifies subresources in a 3D texture that can be accessed (see D3D11_TEX3D_UAV).</para>
		/// </summary>
		public D3D11_TEX3D_UAV Texture3D;
	}

	/// <summary>Defines a color value for Microsoft Direct3D 11 video.</summary>
	/// <remarks>The anonymous union can represent both RGB and YCbCr colors. The interpretation of the union depends on the context.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_color typedef struct D3D11_VIDEO_COLOR { union {
	// D3D11_VIDEO_COLOR_YCbCrA YCbCr; D3D11_VIDEO_COLOR_RGBA RGBA; }; } D3D11_VIDEO_COLOR;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_COLOR")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D11_VIDEO_COLOR
	{
		/// <summary>A D3D11_VIDEO_COLOR_YCbCrA structure that contains a YCbCr color value.</summary>
		[FieldOffset(0)]
		public D3D11_VIDEO_COLOR_YCbCrA YCbCr;

		/// <summary>A D3D11_VIDEO_COLOR_RGBA structure that contains an RGB color value.</summary>
		[FieldOffset(0)]
		public D3D11_VIDEO_COLOR_RGBA RGBA;
	}

	/// <summary>Specifies an RGB color value.</summary>
	/// <remarks>
	/// <para>
	/// The RGB values have a nominal range of [0...1]. For an RGB format with <c>n</c> bits per channel, the value of each color component
	/// is calculated as follows:
	/// </para>
	/// <para>For example, for RGB-32 (8 bits per channel), .</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_color_rgba typedef struct D3D11_VIDEO_COLOR_RGBA {
	// float R; float G; float B; float A; } D3D11_VIDEO_COLOR_RGBA;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_COLOR_RGBA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D11_VIDEO_COLOR_RGBA
	{
		/// <summary>The red value.</summary>
		public float R;

		/// <summary>The green value.</summary>
		public float G;

		/// <summary>The blue value.</summary>
		public float B;

		/// <summary>The alpha value. Values range from 0 (transparent) to 1 (opaque).</summary>
		public float A;
	}

	/// <summary>Specifies a YCbCr color value.</summary>
	/// <remarks>
	/// <para>
	/// Values have a nominal range of [0...1]. Given a format with <c>n</c> bits per channel, the value of each color component is
	/// calculated as follows:
	/// </para>
	/// <para>
	/// For example, for 8-bit YUV formats, . Reference black is (0.0625, 0.5, 0.5), which corresponds to (16, 128, 128) in an 8-bit representation.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_color_ycbcra typedef struct D3D11_VIDEO_COLOR_YCbCrA {
	// float Y; float Cb; float Cr; float A; } D3D11_VIDEO_COLOR_YCbCrA;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_COLOR_YCbCrA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D11_VIDEO_COLOR_YCbCrA
	{
		/// <summary>The Y luma value.</summary>
		public float Y;

		/// <summary>The Cb chroma value.</summary>
		public float Cb;

		/// <summary>The Cr chroma value.</summary>
		public float Cr;

		/// <summary>The alpha value. Values range from 0 (transparent) to 1 (opaque).</summary>
		public float A;
	}

	/// <summary>Describes the content-protection capabilities of a graphics driver.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_content_protection_caps typedef struct
	// D3D11_VIDEO_CONTENT_PROTECTION_CAPS { UINT Caps; UINT KeyExchangeTypeCount; UINT BlockAlignmentSize; ULONGLONG ProtectedMemorySize; } D3D11_VIDEO_CONTENT_PROTECTION_CAPS;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_CONTENT_PROTECTION_CAPS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_CONTENT_PROTECTION_CAPS
	{
		/// <summary>A bitwise <c>OR</c> of zero or more flags from the D3D11_CONTENT_PROTECTION_CAPS enumeration.</summary>
		public uint Caps;

		/// <summary>
		/// The number of cryptographic key-exchange types that are supported by the driver. To get the list of key-exchange types, call the
		/// ID3D11VideoDevice::CheckCryptoKeyExchange method.
		/// </summary>
		public uint KeyExchangeTypeCount;

		/// <summary>The encryption block size, in bytes. The size of data to be encrypted must be a multiple of this value.</summary>
		public uint BlockAlignmentSize;

		/// <summary>The total amount of memory, in bytes, that can be used to hold protected surfaces.</summary>
		public ulong ProtectedMemorySize;
	}

	/// <summary>Describes a compressed buffer for decoding.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_decoder_buffer_desc typedef struct
	// D3D11_VIDEO_DECODER_BUFFER_DESC { D3D11_VIDEO_DECODER_BUFFER_TYPE BufferType; UINT BufferIndex; UINT DataOffset; UINT DataSize; UINT
	// FirstMBaddress; UINT NumMBsInBuffer; UINT Width; UINT Height; UINT Stride; UINT ReservedBits; void *pIV; UINT IVSize; BOOL
	// PartialEncryption; D3D11_ENCRYPTED_BLOCK_INFO EncryptedBlockInfo; } D3D11_VIDEO_DECODER_BUFFER_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_DECODER_BUFFER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_DECODER_BUFFER_DESC
	{
		/// <summary>The type of buffer, specified as a member of the D3D11_VIDEO_DECODER_BUFFER_TYPE enumeration.</summary>
		public D3D11_VIDEO_DECODER_BUFFER_TYPE BufferType;

		/// <summary>Reserved.</summary>
		public uint BufferIndex;

		/// <summary>The offset of the relevant data from the beginning of the buffer, in bytes. This value must be zero.</summary>
		public uint DataOffset;

		/// <summary/>
		public uint DataSize;

		/// <summary>The macroblock address of the first macroblock in the buffer. The macroblock address is given in raster scan order.</summary>
		public uint FirstMBaddress;

		/// <summary>The number of macroblocks of data in the buffer. This count includes skipped macroblocks.</summary>
		public uint NumMBsInBuffer;

		/// <summary>Reserved. Set to zero.</summary>
		public uint Width;

		/// <summary>Reserved. Set to zero.</summary>
		public uint Height;

		/// <summary>Reserved. Set to zero.</summary>
		public uint Stride;

		/// <summary>Reserved. Set to zero.</summary>
		public uint ReservedBits;

		/// <summary>
		/// A pointer to a buffer that contains an initialization vector (IV) for encrypted data. If the decode buffer does not contain
		/// encrypted data, set this member to <c>NULL</c>.
		/// </summary>
		public IntPtr pIV;

		/// <summary>The size of the buffer specified in the <c>pIV</c> parameter. If <c>pIV</c> is <c>NULL</c>, set this member to zero.</summary>
		public uint IVSize;

		/// <summary>If <c>TRUE</c>, the video surfaces are partially encrypted.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool PartialEncryption;

		/// <summary>A D3D11_ENCRYPTED_BLOCK_INFO structure that specifies which bytes of the surface are encrypted.</summary>
		public D3D11_ENCRYPTED_BLOCK_INFO EncryptedBlockInfo;
	}

	/// <summary>Describes the configuration of a Microsoft Direct3D 11 decoder device for DirectX Video Acceleration (DXVA).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_decoder_config typedef struct
	// D3D11_VIDEO_DECODER_CONFIG { GUID guidConfigBitstreamEncryption; GUID guidConfigMBcontrolEncryption; GUID
	// guidConfigResidDiffEncryption; UINT ConfigBitstreamRaw; UINT ConfigMBcontrolRasterOrder; UINT ConfigResidDiffHost; UINT
	// ConfigSpatialResid8; UINT ConfigResid8Subtraction; UINT ConfigSpatialHost8or9Clipping; UINT ConfigSpatialResidInterleaved; UINT
	// ConfigIntraResidUnsigned; UINT ConfigResidDiffAccelerator; UINT ConfigHostInverseScan; UINT ConfigSpecificIDCT; UINT
	// Config4GroupedCoefs; USHORT ConfigMinRenderTargetBuffCount; USHORT ConfigDecoderSpecific; } D3D11_VIDEO_DECODER_CONFIG;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_DECODER_CONFIG")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_DECODER_CONFIG
	{
		/// <summary>
		/// If the bitstream data buffers are encrypted using the D3D11CryptoSession mechanism, this GUID should be set to zero. If no
		/// encryption is applied, the value is <c>DXVA_NoEncrypt</c>. If <c>ConfigBitstreamRaw</c> is 0, the value must be <c>DXVA_NoEncrypt</c>.
		/// </summary>
		public Guid guidConfigBitstreamEncryption;

		/// <summary>
		/// If the macroblock control data buffers are encrypted using the D3D11CryptoSession mechanism, this GUID should be set to zero. If
		/// no encryption is applied, the value is <c>DXVA_NoEncrypt</c>. If <c>ConfigBitstreamRaw</c> is 1, the value must be <c>DXVA_NoEncrypt</c>.
		/// </summary>
		public Guid guidConfigMBcontrolEncryption;

		/// <summary>
		/// If the residual difference decoding data buffers are encrypted using the D3D11CryptoSession mechanism, this GUID should be set
		/// to zero. If no encryption is applied, the value is <c>DXVA_NoEncrypt</c>. If <c>ConfigBitstreamRaw</c> is 1, the value must be <c>DXVA_NoEncrypt</c>.
		/// </summary>
		public Guid guidConfigResidDiffEncryption;

		/// <summary>
		/// Indicates whether the host-decoder sends raw bit-stream data. If the value is 1, the data for the pictures will be sent in
		/// bit-stream buffers as raw bit-stream content. If the value is 0, picture data will be sent using macroblock control command
		/// buffers. If either <c>ConfigResidDiffHost</c> or <c>ConfigResidDiffAccelerator</c> is 1, the value must be 0.
		/// </summary>
		public uint ConfigBitstreamRaw;

		/// <summary>
		/// Specifies whether macroblock control commands are in raster scan order or in arbitrary order. If the value is 1, the macroblock
		/// control commands within each macroblock control command buffer are in raster-scan order. If the value is 0, the order is
		/// arbitrary. For some types of bit streams, forcing raster order either greatly increases the number of required macroblock
		/// control buffers that must be processed, or requires host reordering of the control information. Therefore, supporting arbitrary
		/// order can be more efficient.
		/// </summary>
		public uint ConfigMBcontrolRasterOrder;

		/// <summary>
		/// Contains the host residual difference configuration. If the value is 1, some residual difference decoding data may be sent as
		/// blocks in the spatial domain from the host. If the value is 0, spatial domain data will not be sent.
		/// </summary>
		public uint ConfigResidDiffHost;

		/// <summary>
		/// <para>
		/// Indicates the word size used to represent residual difference spatial-domain blocks for predicted (non-intra) pictures when
		/// using host-based residual difference decoding.
		/// </para>
		/// <para>
		/// If <c>ConfigResidDiffHost</c> is 1 and <c>ConfigSpatialResid8</c> is 1, the host will send residual difference spatial-domain
		/// blocks for non-intra macroblocks using 8-bit signed samples and for intra macroblocks in predicted (non-intra) pictures in a
		/// format that depends on the value of <c>ConfigIntraResidUnsigned</c>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// If <c>ConfigIntraResidUnsigned</c> is 0, spatial-domain blocks for intra macroblocks are sent as 8-bit signed integer values
		/// relative to a constant reference value of 2^(BPP–1).
		/// </item>
		/// <item>
		/// If <c>ConfigIntraResidUnsigned</c> is 1, spatial-domain blocks for intra macroblocks are sent as 8-bit unsigned integer values
		/// relative to a constant reference value of 0.
		/// </item>
		/// </list>
		/// <para>
		/// If ConfigResidDiffHost is 1 and ConfigSpatialResid8 is 0, the host will send residual difference spatial-domain blocks of data
		/// for non-intra macroblocks using 16-bit signed samples and for intra macroblocks in predicted (non-intra) pictures in a format
		/// that depends on the value of ConfigIntraResidUnsigned:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// If <c>ConfigIntraResidUnsigned</c> is 0, spatial domain blocks for intra macroblocks are sent as 16-bit signed integer values
		/// relative to a constant reference value of 2^(BPP–1).
		/// </item>
		/// <item>
		/// If <c>ConfigIntraResidUnsigned</c> is 1, spatial domain blocks for intra macroblocks are sent as 16-bit unsigned integer values
		/// relative to a constant reference value of 0.
		/// </item>
		/// </list>
		/// <para>If ConfigResidDiffHost is 0, ConfigSpatialResid8 must be 0.</para>
		/// <para>
		/// For intra pictures, spatial-domain blocks must be sent using 8-bit samples if bits-per-pixel (BPP) is 8, and using 16-bit
		/// samples if BPP &gt; 8. If <c>ConfigIntraResidUnsigned</c> is 0, these samples are sent as signed integer values relative to a
		/// constant reference value of 2^(BPP–1), and if <c>ConfigIntraResidUnsigned</c> is 1, these samples are sent as unsigned integer
		/// values relative to a constant reference value of 0.
		/// </para>
		/// </summary>
		public uint ConfigSpatialResid8;

		/// <summary>
		/// <para>
		/// If the value is 1, 8-bit difference overflow blocks are subtracted rather than added. The value must be 0 unless
		/// <c>ConfigSpatialResid8</c> is 1.
		/// </para>
		/// <para>
		/// The ability to subtract differences rather than add them enables 8-bit difference decoding to be fully compliant with the full
		/// ±255 range of values required in video decoder specifications, because +255 cannot be represented as the addition of two signed
		/// 8-bit numbers, but any number in the range ±255 can be represented as the difference between two signed 8-bit numbers (+255 =
		/// +127 minus –128).
		/// </para>
		/// </summary>
		public uint ConfigResid8Subtraction;

		/// <summary>
		/// <para>
		/// If the value is 1, spatial-domain blocks for intra macroblocks must be clipped to an 8-bit range on the host and spatial-domain
		/// blocks for non-intra macroblocks must be clipped to a 9-bit range on the host. If the value is 0, no such clipping is necessary
		/// by the host.
		/// </para>
		/// <para>The value must be 0 unless <c>ConfigSpatialResid8</c> is 0 and <c>ConfigResidDiffHost</c> is 1.</para>
		/// </summary>
		public uint ConfigSpatialHost8or9Clipping;

		/// <summary>
		/// If the value is 1, any spatial-domain residual difference data must be sent in a chrominance-interleaved form matching the YUV
		/// format chrominance interleaving pattern. The value must be 0 unless <c>ConfigResidDiffHost</c> is 1 and the YUV format is NV12
		/// or NV21.
		/// </summary>
		public uint ConfigSpatialResidInterleaved;

		/// <summary>
		/// <para>
		/// Indicates the method of representation of spatial-domain blocks of residual difference data for intra blocks when using
		/// host-based difference decoding.
		/// </para>
		/// <para>
		/// If <c>ConfigResidDiffHost</c> is 1 and <c>ConfigIntraResidUnsigned</c> is 0, spatial-domain residual difference data blocks for
		/// intra macroblocks must be sent as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// In a non-intra picture, if <c>ConfigSpatialResid8</c> is 0, the spatial-domain residual difference data blocks for intra
		/// macroblocks are sent as 16-bit signed integer values relative to a constant reference value of 2^(BPP–1).
		/// </item>
		/// <item>
		/// In a non-intra picture, if <c>ConfigSpatialResid8</c> is 1, the spatial-domain residual difference data blocks for intra
		/// macroblocks are sent as 8-bit signed integer values relative to a constant reference value of 2^(BPP–1).
		/// </item>
		/// <item>
		/// In an intra picture, if BPP is 8, the spatial-domain residual difference data blocks for intra macroblocks are sent as 8-bit
		/// signed integer values relative to a constant reference value of 2^(BPP–1), regardless of the value of <c>ConfigSpatialResid8</c>.
		/// </item>
		/// </list>
		/// <para>
		/// If ConfigResidDiffHost is 1 and ConfigIntraResidUnsigned is 1, spatial-domain residual difference data blocks for intra
		/// macroblocks must be sent as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// In a non-intra picture, if <c>ConfigSpatialResid8</c> is 0, the spatial-domain residual difference data blocks for intra
		/// macroblocks must be sent as 16-bit unsigned integer values relative to a constant reference value of 0.
		/// </item>
		/// <item>
		/// In a non-intra picture, if <c>ConfigSpatialResid8</c> is 1, the spatial-domain residual difference data blocks for intra
		/// macroblocks are sent as 8-bit unsigned integer values relative to a constant reference value of 0.
		/// </item>
		/// <item>
		/// In an intra picture, if BPP is 8, the spatial-domain residual difference data blocks for intra macroblocks are sent as 8-bit
		/// unsigned integer values relative to a constant reference value of 0, regardless of the value of <c>ConfigSpatialResid8</c>.
		/// </item>
		/// </list>
		/// <para>The value of the member must be 0 unless ConfigResidDiffHost is 1.</para>
		/// </summary>
		public uint ConfigIntraResidUnsigned;

		/// <summary>
		/// <para>
		/// If the value is 1, transform-domain blocks of coefficient data may be sent from the host for accelerator-based IDCT. If the
		/// value is 0, accelerator-based IDCT will not be used. If both <c>ConfigResidDiffHost</c> and <c>ConfigResidDiffAccelerator</c>
		/// are 1, this indicates that some residual difference decoding will be done on the host and some on the accelerator, as indicated
		/// by macroblock-level control commands.
		/// </para>
		/// <para>The value must be 0 if <c>ConfigBitstreamRaw</c> is 1.</para>
		/// </summary>
		public uint ConfigResidDiffAccelerator;

		/// <summary>
		/// <para>
		/// If the value is 1, the inverse scan for transform-domain block processing will be performed on the host, and absolute indices
		/// will be sent instead for any transform coefficients. If the value is 0, the inverse scan will be performed on the accelerator.
		/// </para>
		/// <para>The value must be 0 if <c>ConfigResidDiffAccelerator</c> is 0 or if <c>Config4GroupedCoefs</c> is 1.</para>
		/// </summary>
		public uint ConfigHostInverseScan;

		/// <summary>
		/// <para>
		/// If the value is 1, the IDCT specified in Annex W of ITU-T Recommendation H.263 is used. If the value is 0, any compliant IDCT
		/// can be used for off-host IDCT.
		/// </para>
		/// <para>
		/// The H.263 annex does not comply with the IDCT requirements of MPEG-2 corrigendum 2, so the value must not be 1 for use with
		/// MPEG-2 video.
		/// </para>
		/// <para>The value must be 0 if <c>ConfigResidDiffAccelerator</c> is 0, indicating purely host-based residual difference decoding.</para>
		/// </summary>
		public uint ConfigSpecificIDCT;

		/// <summary>
		/// If the value is 1, transform coefficients for off-host IDCT will be sent using the DXVA_TCoef4Group structure. If the value is
		/// 0, the DXVA_TCoefSingle structure is used. The value must be 0 if <c>ConfigResidDiffAccelerator</c> is 0 or if
		/// <c>ConfigHostInverseScan</c> is 1.
		/// </summary>
		public uint Config4GroupedCoefs;

		/// <summary>Specifies how many frames the decoder device processes at any one time.</summary>
		public ushort ConfigMinRenderTargetBuffCount;

		/// <summary>Contains decoder-specific configuration information.</summary>
		public ushort ConfigDecoderSpecific;
	}

	/// <summary>Describes a video stream for a Microsoft Direct3D 11 video decoder or video processor.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_decoder_desc typedef struct D3D11_VIDEO_DECODER_DESC {
	// GUID Guid; UINT SampleWidth; UINT SampleHeight; DXGI_FORMAT OutputFormat; } D3D11_VIDEO_DECODER_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_DECODER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_DECODER_DESC
	{
		/// <summary>
		/// The decoding profile. To get the list of profiles supported by the device, call the ID3D11VideoDevice::GetVideoDecoderProfile method.
		/// </summary>
		public Guid Guid;

		/// <summary>The width of the video frame, in pixels.</summary>
		public uint SampleWidth;

		/// <summary>The height of the video frame, in pixels.</summary>
		public uint SampleHeight;

		/// <summary>The output surface format, specified as a DXGI_FORMAT value.</summary>
		public DXGI_FORMAT OutputFormat;
	}

	/// <summary>Contains driver-specific data for the ID3D11VideoContext::DecoderExtension method.</summary>
	/// <remarks>The exact meaning of each structure member depends on the value of <c>Function</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_decoder_extension typedef struct
	// D3D11_VIDEO_DECODER_EXTENSION { UINT Function; void *pPrivateInputData; UINT PrivateInputDataSize; void *pPrivateOutputData; UINT
	// PrivateOutputDataSize; UINT ResourceCount; ID3D11Resource **ppResourceList; } D3D11_VIDEO_DECODER_EXTENSION;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_DECODER_EXTENSION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_DECODER_EXTENSION
	{
		/// <summary>The function number. This number identifies the operation to perform. Currently no function numbers are defined.</summary>
		public uint Function;

		/// <summary>A pointer to a buffer that contains input data for the driver.</summary>
		public IntPtr pPrivateInputData;

		/// <summary>The size of the <c>pPrivateInputData</c> buffer, in bytes.</summary>
		public uint PrivateInputDataSize;

		/// <summary>A pointer to a buffer that the driver can use to write output data.</summary>
		public IntPtr pPrivateOutputData;

		/// <summary>The size of the <c>pPrivateOutputData</c> buffer, in bytes.</summary>
		public uint PrivateOutputDataSize;

		/// <summary>
		/// The number of elements in the <c>ppResourceList</c> array. If <c>ppResourceList</c> is <c>NULL</c>, set <c>ResourceCount</c> to zero.
		/// </summary>
		public uint ResourceCount;

		/// <summary>The address of an array of ID3D11Resource pointers. Use this member to pass Direct3D resources to the driver.</summary>
		public IntPtr ppResourceList;

		/// <summary>Sets the array of ID3D11Resource pointers.</summary>
		/// <param name="resources">The optional array of ID3D11Resource pointers.</param>
		/// <returns>The memory allocated to the passed array.</returns>
		public SafeAllocatedMemoryHandle SetResourceList(ID3D11Resource[]? resources)
		{
			SafeAllocatedMemoryHandle ret = resources is null ? SafeCoTaskMemHandle.Null : new SafeNativeArray<IntPtr>(Array.ConvertAll(resources!, Marshal.GetIUnknownForObject));
			ppResourceList = ret.DangerousGetHandle();
			ResourceCount = (uint)(resources?.Length ?? 0);
			return ret;
		}

		/// <summary>Creates an instance of <see cref="D3D11_VIDEO_DECODER_EXTENSION"/> using managed values.</summary>
		/// <param name="inputData">A buffer that contains input data for the driver.</param>
		/// <param name="outputData">A buffer that the driver can use to write output data.</param>
		/// <param name="resources">The optional array of ID3D11Resource pointers.</param>
		/// <param name="function">
		/// The function number. This number identifies the operation to perform. Currently no function numbers are defined.
		/// </param>
		/// <param name="mem">The memory allocated to the passed array.</param>
		/// <returns>An instance of <see cref="D3D11_VIDEO_DECODER_EXTENSION"/> using supplied values.</returns>
		public static D3D11_VIDEO_DECODER_EXTENSION Create(SafeAllocatedMemoryHandleBase inputData, SafeAllocatedMemoryHandleBase outputData, [Optional] ID3D11Resource[]? resources, [Optional] uint function, out SafeAllocatedMemoryHandle mem)
		{
			D3D11_VIDEO_DECODER_EXTENSION vde = new() { Function = function, pPrivateInputData = inputData, PrivateInputDataSize = inputData.Size, pPrivateOutputData = outputData, PrivateOutputDataSize = outputData.Size };
			mem = vde.SetResourceList(resources);
			return vde;
		}
	}

	/// <summary>Describes a video decoder output view.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_decoder_output_view_desc typedef struct
	// D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC { GUID DecodeProfile; D3D11_VDOV_DIMENSION ViewDimension; union { D3D11_TEX2D_VDOV Texture2D; };
	// } D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC
	{
		/// <summary>
		/// The decoding profile. To get the list of profiles supported by the device, call the ID3D11VideoDevice::GetVideoDecoderProfile method.
		/// </summary>
		public Guid DecodeProfile;

		/// <summary>The resource type of the view, specified as a member of the D3D11_VDOV_DIMENSION enumeration.</summary>
		public D3D11_VDOV_DIMENSION ViewDimension;

		/// <summary>A D3D11_TEX2D_VDOV structure that identifies the texture resource for the output view.</summary>
		public D3D11_TEX2D_VDOV Texture2D;
	}

	/// <summary>Describes the capabilities of a Microsoft Direct3D 11 video processor.</summary>
	/// <remarks>
	/// <para>
	/// The video processor stores state information for each input stream. These states persist between blits. With each blit, the
	/// application selects which streams to enable or disable. Disabling a stream does not affect the state information for that stream.
	/// </para>
	/// <para>
	/// The <c>MaxStreamStates</c> member gives the maximum number of stream states that can be saved. The <c>MaxInputStreams</c> member
	/// gives the maximum number of streams that can be enabled during a blit. These two values can differ.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_processor_caps typedef struct
	// D3D11_VIDEO_PROCESSOR_CAPS { UINT DeviceCaps; UINT FeatureCaps; UINT FilterCaps; UINT InputFormatCaps; UINT AutoStreamCaps; UINT
	// StereoCaps; UINT RateConversionCapsCount; UINT MaxInputStreams; UINT MaxStreamStates; } D3D11_VIDEO_PROCESSOR_CAPS;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_PROCESSOR_CAPS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_PROCESSOR_CAPS
	{
		/// <summary>A bitwise <c>OR</c> of zero or more flags from the D3D11_VIDEO_PROCESSOR_DEVICE_CAPS enumeration.</summary>
		public D3D11_VIDEO_PROCESSOR_DEVICE_CAPS DeviceCaps;

		/// <summary>A bitwise <c>OR</c> of zero or more flags from the D3D11_VIDEO_PROCESSOR_FEATURE_CAPS enumeration.</summary>
		public D3D11_VIDEO_PROCESSOR_FEATURE_CAPS FeatureCaps;

		/// <summary>A bitwise <c>OR</c> of zero or more flags from the D3D11_VIDEO_PROCESSPR_FILTER_CAPS enumeration.</summary>
		public D3D11_VIDEO_PROCESSOR_FILTER_CAPS FilterCaps;

		/// <summary>A bitwise <c>OR</c> of zero or more flags from the D3D11_VIDEO_PROCESSOR_FORMAT_CAPS enumeration.</summary>
		public D3D11_VIDEO_PROCESSOR_FORMAT_CAPS InputFormatCaps;

		/// <summary>A bitwise <c>OR</c> of zero or more flags from the D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS enumeration.</summary>
		public D3D11_VIDEO_PROCESSOR_AUTO_STREAM_CAPS AutoStreamCaps;

		/// <summary>A bitwise <c>OR</c> of zero or more flags from the D3D11_VIDEO_PROCESSOR_STEREO_CAPS enumeration.</summary>
		public D3D11_VIDEO_PROCESSOR_STEREO_CAPS StereoCaps;

		/// <summary>
		/// The number of frame-rate conversion capabilities. To enumerate the frame-rate conversion capabilities, call the
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorRateConversionCaps method.
		/// </summary>
		public uint RateConversionCapsCount;

		/// <summary>The maximum number of input streams that can be enabled at the same time.</summary>
		public uint MaxInputStreams;

		/// <summary>The maximum number of input streams for which the device can store state data.</summary>
		public uint MaxStreamStates;
	}

	/// <summary>Specifies the color space for video processing.</summary>
	/// <remarks>
	/// <para>
	/// The <c>RGB_Range</c> member applies to RGB output, while the <c>YCbCr_Matrix</c> and <c>YCbCr_xvYCC</c> members apply to YCbCr
	/// output. If the driver performs color-space conversion on the background color, it uses the values that apply to both color spaces.
	/// </para>
	/// <para>
	/// If the driver supports extended YCbCr (xvYCC), it returns the <c>D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_xvYCC</c> capabilities flag in
	/// the ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps method. Otherwise, the driver ignores the value of <c>YCbCr_xvYCC</c> and
	/// treats all YCbCr output as conventional YCbCr.
	/// </para>
	/// <para>
	/// If extended YCbCr is supported, it can be used with either transfer matrix. Extended YCbCr does not change the black point or white
	/// point—the black point is still 16 and the white point is still 235. However, extended YCbCr explicitly allows blacker-than-black
	/// values in the range 1–15, and whiter-than-white values in the range 236–254. When extended YCbCr is used, the driver should not clip
	/// the luma values to the nominal 16–235 range.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_processor_color_space typedef struct
	// D3D11_VIDEO_PROCESSOR_COLOR_SPACE { UINT Usage : 1; UINT RGB_Range : 1; UINT YCbCr_Matrix : 1; UINT YCbCr_xvYCC : 1; UINT
	// Nominal_Range : 2; UINT Reserved : 26; } D3D11_VIDEO_PROCESSOR_COLOR_SPACE;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_PROCESSOR_COLOR_SPACE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_PROCESSOR_COLOR_SPACE
	{
		private uint bits;

		/// <summary>
		/// <para>
		/// Specifies whether the output is intended for playback or video processing (such as editing or authoring). The device can
		/// optimize the processing based on the type. The default state value is 0 (playback).
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>0</description>
		/// <description>Playback</description>
		/// </item>
		/// <item>
		/// <description>1</description>
		/// <description>Video processing</description>
		/// </item>
		/// </list>
		/// </summary>
		public bool Usage { get => BitHelper.GetBit(bits, 0); set => BitHelper.SetBit(ref bits, 0, value); }

		/// <summary>
		/// <para>Specifies the RGB color range. The default state value is 0 (full range).</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>0</description>
		/// <description>Full range (0-255)</description>
		/// </item>
		/// <item>
		/// <description>1</description>
		/// <description>Limited range (16-235)</description>
		/// </item>
		/// </list>
		/// </summary>
		public bool RGB_Range { get => BitHelper.GetBit(bits, 1); set => BitHelper.SetBit(ref bits, 1, value); }

		/// <summary>
		/// <para>Specifies the YCbCr transfer matrix. The default state value is 0 (BT.601).</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>0</description>
		/// <description>ITU-R BT.601</description>
		/// </item>
		/// <item>
		/// <description>1</description>
		/// <description>ITU-R BT.709</description>
		/// </item>
		/// </list>
		/// </summary>
		public bool YCbCr_Matrix { get => BitHelper.GetBit(bits, 2); set => BitHelper.SetBit(ref bits, 2, value); }

		/// <summary>
		/// <para>
		/// Specifies whether the output uses conventional YCbCr or extended YCbCr (xvYCC). The default state value is zero (conventional YCbCr).
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>0</description>
		/// <description>Conventional YCbCr</description>
		/// </item>
		/// <item>
		/// <description>1</description>
		/// <description>Extended YCbCr (xvYCC)</description>
		/// </item>
		/// </list>
		/// </summary>
		public bool YCbCr_xvYCC { get => BitHelper.GetBit(bits, 3); set => BitHelper.SetBit(ref bits, 3, value); }

		/// <summary>
		/// <para>Specifies the D3D11_VIDEO_PROCESSOR_NOMINAL_RANGE.</para>
		/// <para>Introduced in Windows 8.1.</para>
		/// </summary>
		public byte Nominal_Range { get => (byte)BitHelper.GetBits(bits, 4, 2); set => BitHelper.SetBits(ref bits, 4, 2, value); }
	}

	/// <summary>Describes a video stream for a video processor.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_processor_content_desc typedef struct
	// D3D11_VIDEO_PROCESSOR_CONTENT_DESC { D3D11_VIDEO_FRAME_FORMAT InputFrameFormat; DXGI_RATIONAL InputFrameRate; UINT InputWidth; UINT
	// InputHeight; DXGI_RATIONAL OutputFrameRate; UINT OutputWidth; UINT OutputHeight; D3D11_VIDEO_USAGE Usage; } D3D11_VIDEO_PROCESSOR_CONTENT_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_PROCESSOR_CONTENT_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_PROCESSOR_CONTENT_DESC
	{
		/// <summary>A member of the D3D11_VIDEO_FRAME_FORMAT enumeration that describes how the video stream is interlaced.</summary>
		public D3D11_VIDEO_FRAME_FORMAT InputFrameFormat;

		/// <summary>The frame rate of the input video stream, specified as a DXGI_RATIONAL structure.</summary>
		public DXGI_RATIONAL InputFrameRate;

		/// <summary>The width of the input frames, in pixels.</summary>
		public uint InputWidth;

		/// <summary>The height of the input frames, in pixels.</summary>
		public uint InputHeight;

		/// <summary>The frame rate of the output video stream, specified as a DXGI_RATIONAL structure.</summary>
		public DXGI_RATIONAL OutputFrameRate;

		/// <summary>The width of the output frames, in pixels.</summary>
		public uint OutputWidth;

		/// <summary>The height of the output frames, in pixels.</summary>
		public uint OutputHeight;

		/// <summary>
		/// A member of the D3D11_VIDEO_USAGE enumeration that describes how the video processor will be used. The value indicates the
		/// desired trade-off between speed and video quality. The driver uses this flag as a hint when it creates the video processor.
		/// </summary>
		public D3D11_VIDEO_USAGE Usage;
	}

	/// <summary>Specifies a custom rate for frame-rate conversion or inverse telecine (IVTC).</summary>
	/// <remarks>
	/// The <c>CustomRate</c> member gives the rate conversion factor, while the remaining members define the pattern of input and output samples.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_processor_custom_rate typedef struct
	// D3D11_VIDEO_PROCESSOR_CUSTOM_RATE { DXGI_RATIONAL CustomRate; UINT OutputFrames; BOOL InputInterlaced; UINT InputFramesOrFields; } D3D11_VIDEO_PROCESSOR_CUSTOM_RATE;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_PROCESSOR_CUSTOM_RATE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_PROCESSOR_CUSTOM_RATE
	{
		/// <summary>
		/// The ratio of the output frame rate to the input frame rate, expressed as a DXGI_RATIONAL structure that holds a rational number.
		/// </summary>
		public DXGI_RATIONAL CustomRate;

		/// <summary>The number of output frames that will be generated for every <c>N</c> input samples, where <c>N</c> = <c>InputFramesOrFields</c>.</summary>
		public uint OutputFrames;

		/// <summary>If <c>TRUE</c>, the input stream must be interlaced. Otherwise, the input stream must be progressive.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool InputInterlaced;

		/// <summary>The number of input fields or frames for every <c>N</c> output frames that will be generated, where <c>N</c> = <c>OutputFrames</c>.</summary>
		public uint InputFramesOrFields;
	}

	/// <summary>Defines the range of supported values for an image filter.</summary>
	/// <remarks>
	/// <para>The multiplier enables the filter range to have a fractional step value.</para>
	/// <para>
	/// For example, a hue filter might have an actual range of [–180.0 ... +180.0] with a step size of 0.25. The device would report the
	/// following range and multiplier:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>Minimum: –720</description>
	/// </item>
	/// <item>
	/// <description>Maximum: +720</description>
	/// </item>
	/// <item>
	/// <description>Multiplier: 0.25</description>
	/// </item>
	/// </list>
	/// <para>In this case, a filter value of 2 would be interpreted by the device as 0.50 (or 2 × 0.25).</para>
	/// <para>The device should use a multiplier that can be represented exactly as a base-2 fraction.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_processor_filter_range typedef struct
	// D3D11_VIDEO_PROCESSOR_FILTER_RANGE { int Minimum; int Maximum; int Default; float Multiplier; } D3D11_VIDEO_PROCESSOR_FILTER_RANGE;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_PROCESSOR_FILTER_RANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_PROCESSOR_FILTER_RANGE
	{
		/// <summary>The minimum value of the filter.</summary>
		public int Minimum;

		/// <summary>The maximum value of the filter.</summary>
		public int Maximum;

		/// <summary>The default value of the filter.</summary>
		public int Default;

		/// <summary>
		/// A multiplier. Use the following formula to translate the filter setting into the actual filter value: <c>Actual Value</c> =
		/// <c>Set Value</c> ×  <c>Multiplier</c>.
		/// </summary>
		public float Multiplier;
	}

	/// <summary>Describes a video processor input view.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_processor_input_view_desc typedef struct
	// D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC { UINT FourCC; D3D11_VPIV_DIMENSION ViewDimension; union { D3D11_TEX2D_VPIV Texture2D; }; } D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC
	{
		/// <summary>
		/// The surface format. If zero, the driver uses the DXGI format that was used to create the resource. If you are using feature
		/// level 9, the value must be zero.
		/// </summary>
		public uint FourCC;

		/// <summary>The resource type of the view, specified as a member of the D3D11_VPIV_DIMENSION enumeration.</summary>
		public D3D11_VPIV_DIMENSION ViewDimension;

		/// <summary>A D3D11_TEX2D_VPIV structure that identifies the texture resource.</summary>
		public D3D11_TEX2D_VPIV Texture2D;
	}

	/// <summary>Describes a video processor output view.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_processor_output_view_desc typedef struct
	// D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC { D3D11_VPOV_DIMENSION ViewDimension; union { D3D11_TEX2D_VPOV Texture2D;
	// D3D11_TEX2D_ARRAY_VPOV Texture2DArray; }; } D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC
	{
		/// <summary>The resource type of the view, specified as a member of the D3D11_VPOV_DIMENSION enumeration.</summary>
		public D3D11_VPOV_DIMENSION ViewDimension;

		/// <summary>
		/// <para>A D3D11_TEX2D_VPOV structure that identifies the texture resource for the output view.</para>
		/// <para>Use this member of the union when <c>ViewDimension</c> equals <c>D3D11_VPOV_DIMENSION_TEXTURE2D</c>.</para>
		/// </summary>
		public D3D11_TEX2D_VPOV Texture2D;

		/// <summary>
		/// <para>A D3D11_TEX2D_ARRAY_VPOV structure that identifies the texture array for the output view.</para>
		/// <para>Use this member of the union when <c>ViewDimension</c> equals <c>D3D11_VPOV_DIMENSION_TEXTURE2DARRAY</c>.</para>
		/// </summary>
		public D3D11_TEX2D_ARRAY_VPOV Texture2DArray;
	}

	/// <summary>
	/// Defines a group of video processor capabilities that are associated with frame-rate conversion, including deinterlacing and inverse telecine.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_processor_rate_conversion_caps typedef struct
	// D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS { UINT PastFrames; UINT FutureFrames; UINT ProcessorCaps; UINT ITelecineCaps; UINT
	// CustomRateCount; } D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS
	{
		/// <summary>The number of past reference frames required to perform the optimal video processing.</summary>
		public uint PastFrames;

		/// <summary>The number of future reference frames required to perform the optimal video processing.</summary>
		public uint FutureFrames;

		/// <summary>A bitwise <c>OR</c> of zero or more flags from the D3D11_VIDEO_PROCESSOR_PROCESSOR_CAPS enumeration.</summary>
		public uint ProcessorCaps;

		/// <summary>A bitwise <c>OR</c> of zero or more flags from the D3D11_VIDEO_PROCESSOR_ITELECINE_CAPS enumeration.</summary>
		public uint ITelecineCaps;

		/// <summary>
		/// The number of custom frame rates that the driver supports. To get the list of custom frame rates, call the
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCustomRate method.
		/// </summary>
		public uint CustomRateCount;
	}

	/// <summary>Contains stream-level data for the ID3D11VideoContext::VideoProcessorBlt method.</summary>
	/// <remarks>
	/// If the stereo 3D format is <c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE</c>, the <c>ppPastSurfaces</c>, <c>pInputSurface</c>, and
	/// <c>ppFutureSurfaces</c> members contain the left view.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_processor_stream typedef struct
	// D3D11_VIDEO_PROCESSOR_STREAM { BOOL Enable; UINT OutputIndex; UINT InputFrameOrField; UINT PastFrames; UINT FutureFrames;
	// ID3D11VideoProcessorInputView **ppPastSurfaces; ID3D11VideoProcessorInputView *pInputSurface; ID3D11VideoProcessorInputView
	// **ppFutureSurfaces; ID3D11VideoProcessorInputView **ppPastSurfacesRight; ID3D11VideoProcessorInputView *pInputSurfaceRight;
	// ID3D11VideoProcessorInputView **ppFutureSurfacesRight; } D3D11_VIDEO_PROCESSOR_STREAM;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIDEO_PROCESSOR_STREAM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIDEO_PROCESSOR_STREAM
	{
		/// <summary>
		/// <para>
		/// Specifies whether this input stream is enabled. If the value is <c>TRUE</c>, the VideoProcessorBlt method blits this stream to
		/// the output surface. Otherwise, this stream is not blitted.
		/// </para>
		/// <para>
		/// The maximum number of streams that can be enabled at one time is given in the <c>MaxInputStreams</c> member of the
		/// D3D11_VIDEO_PROCESSOR_CAPS structure.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool Enable;

		/// <summary>The zero-based index number of the output frame.</summary>
		public uint OutputIndex;

		/// <summary>The zero-based index number of the input frame or field.</summary>
		public uint InputFrameOrField;

		/// <summary>The number of past reference frames.</summary>
		public uint PastFrames;

		/// <summary>The number of future reference frames.</summary>
		public uint FutureFrames;

		/// <summary>
		/// A pointer to an array of ID3D11VideoProcessorInputView pointers, allocated by the caller. This array contains the past reference
		/// frames for the video processing operation. The number of elements in the array is equal to <c>PastFrames</c>.
		/// </summary>
		public IntPtr ppPastSurfaces;

		/// <summary>A pointer to the ID3D11VideoProcessorInputView interface of the surface that contains the current input frame.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D11VideoProcessorInputView pInputSurface;

		/// <summary>
		/// A pointer to an array of ID3D11VideoProcessorInputView pointers, allocated by the caller. This array contains the future
		/// reference frames for the video processing operation. The number of elements in the array is equal to <c>FutureFrames</c>.
		/// </summary>
		public IntPtr ppFutureSurfaces;

		/// <summary>
		/// <para>
		/// If the stereo 3D format is <c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE</c>, this member points to an array that contains the
		/// past reference frames for the right view. The number of elements in the array is equal to <c>PastFrames</c>.
		/// </para>
		/// <para>For any other stereo 3D format, set this member to <c>NULL</c>. For more information, see ID3D11VideoContext::VideoProcessorSetStreamStereoFormat.</para>
		/// </summary>
		public IntPtr ppPastSurfacesRight;

		/// <summary>
		/// <para>
		/// If the stereo 3D format is <c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE</c>, this member contains a pointer to the current
		/// input frame for the right view.
		/// </para>
		/// <para>For any other stereo 3D format, set this member to <c>NULL</c>.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D11VideoProcessorInputView pInputSurfaceRight;

		/// <summary>
		/// <para>
		/// If the stereo 3D format is <c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE</c>, this member points to an array that contains the
		/// future reference frames for the right view. The number of elements in the array is equal to <c>FutureFrames</c>.
		/// </para>
		/// <para>For any other stereo 3D format, set this member to <c>NULL</c>.</para>
		/// </summary>
		public IntPtr ppFutureSurfacesRight;
	}

	/// <summary>Defines the dimensions of a viewport.</summary>
	/// <remarks>
	/// <para>
	/// In all cases, <c>Width</c> and <c>Height</c> must be &gt;= 0 and <c>TopLeftX</c> + <c>Width</c> and <c>TopLeftY</c> + <c>Height</c>
	/// must be &lt;= D3D11_VIEWPORT_BOUNDS_MAX.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>
	/// Viewport Sizes and Feature Level Support Differences between Direct3D 11 and Direct3D 10: The range for the minimum and maximum
	/// viewport size is dependent on the feature level defined by D3D_FEATURE_LEVEL.
	/// </description>
	/// </listheader>
	/// </list>
	/// <para></para>
	/// <para>
	/// <c>Note</c>  Even though you specify float values to the members of the <c>D3D11_VIEWPORT</c> structure for the <c>pViewports</c>
	/// array in a call to ID3D11DeviceContext::RSSetViewports for feature levels 9_x, <c>RSSetViewports</c> uses DWORDs internally. Because
	/// of this behavior, when you use a negative top left corner for the viewport, the call to <c>RSSetViewports</c> for feature levels 9_x
	/// fails. This failure occurs because <c>RSSetViewports</c> for 9_x casts the floating point values into unsigned integers without
	/// validation, which results in integer overflow.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_viewport typedef struct D3D11_VIEWPORT { FLOAT TopLeftX;
	// FLOAT TopLeftY; FLOAT Width; FLOAT Height; FLOAT MinDepth; FLOAT MaxDepth; } D3D11_VIEWPORT;
	[PInvokeData("d3d11.h", MSDNShortId = "NS:d3d11.D3D11_VIEWPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_VIEWPORT
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>X position of the left hand side of the viewport. Ranges between D3D11_VIEWPORT_BOUNDS_MIN and D3D11_VIEWPORT_BOUNDS_MAX.</para>
		/// </summary>
		public float TopLeftX;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Y position of the top of the viewport. Ranges between D3D11_VIEWPORT_BOUNDS_MIN and D3D11_VIEWPORT_BOUNDS_MAX.</para>
		/// </summary>
		public float TopLeftY;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Width of the viewport.</para>
		/// </summary>
		public float Width;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Height of the viewport.</para>
		/// </summary>
		public float Height;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Minimum depth of the viewport. Ranges between 0 and 1.</para>
		/// </summary>
		public float MinDepth;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Maximum depth of the viewport. Ranges between 0 and 1.</para>
		/// </summary>
		public float MaxDepth;
	}
}