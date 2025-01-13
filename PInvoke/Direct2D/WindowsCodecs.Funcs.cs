namespace Vanara.PInvoke;

public static partial class WindowsCodecs
{
	/// <summary>Application defined callback function called when codec component progress is made.</summary>
	/// <param name="pvData">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>Component data passed to the callback function.</para>
	/// </param>
	/// <param name="uFrameNum">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>The current frame number.</para>
	/// </param>
	/// <param name="operation">
	/// <para>Type: <c>WICProgressOperation</c></para>
	/// <para>The current operation the component is in.</para>
	/// </param>
	/// <param name="dblProgress">
	/// <para>Type: <c>double</c></para>
	/// <para>The progress value. The range is 0.0 to 1.0.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this callback function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>An operation can be canceled by returning .</para>
	/// <para>
	/// To register your callback function, query the encoder or decoder for the IWICBitmapCodecProgressNotification interface and call RegisterProgressNotification.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nc-wincodec-pfnprogressnotification PFNProgressNotification
	// Pfnprogressnotification; HRESULT Pfnprogressnotification( LPVOID pvData, ULONG uFrameNum, WICProgressOperation operation, double
	// dblProgress ) {...}
	[PInvokeData("wincodec.h", MSDNShortId = "10dd9fbe-abff-4fc9-a3a5-7c01ecc10a7f")]
	public delegate HRESULT PFNProgressNotification([In] IntPtr pvData, uint uFrameNum, WICProgressOperation operation, double dblProgress);

	/// <summary>Obtains a IWICBitmapSource in the desired pixel format from a given <c>IWICBitmapSource</c>.</summary>
	/// <param name="dstFormat">
	/// <para>Type: <c>REFWICPixelFormatGUID</c></para>
	/// <para>The pixel format to convert to.</para>
	/// </param>
	/// <param name="pISrc">
	/// <para>Type: <c>IWICBitmapSource*</c></para>
	/// <para>The source bitmap.</para>
	/// </param>
	/// <param name="ppIDst">
	/// <para>Type: <c>IWICBitmapSource**</c></para>
	/// <para>A pointer to the <c>null</c>-initialized destination bitmap pointer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// If the pISrc bitmap is already in the desired format, then pISrc is copied to the destination bitmap pointer and a reference is
	/// added. If it is not in the desired format however, <c>WICConvertBitmapSource</c> will instantiate a dstFormat format converter
	/// and initialize it with pISrc.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-wicconvertbitmapsource HRESULT WICConvertBitmapSource(
	// REFWICPixelFormatGUID dstFormat, IWICBitmapSource *pISrc, IWICBitmapSource **ppIDst );
	[DllImport(Lib.Windowscodecs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincodec.h", MSDNShortId = "ea735296-1bfd-4175-b8c9-cb5a61ab4203")]
	public static extern HRESULT WICConvertBitmapSource(in Guid dstFormat, [In] IWICBitmapSource pISrc, out IWICBitmapSource? ppIDst);

	/// <summary>Returns a IWICBitmapSource that is backed by the pixels of a Windows Graphics Device Interface (GDI) section handle.</summary>
	/// <param name="width">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The width of the bitmap pixels.</para>
	/// </param>
	/// <param name="height">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The height of the bitmap pixels.</para>
	/// </param>
	/// <param name="pixelFormat">
	/// <para>Type: <c>REFWICPixelFormatGUID</c></para>
	/// <para>The pixel format of the bitmap.</para>
	/// </param>
	/// <param name="hSection">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>The section handle. This is a file mapping object handle returned by the CreateFileMapping function.</para>
	/// </param>
	/// <param name="stride">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The byte count of each scanline.</para>
	/// </param>
	/// <param name="offset">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The offset into the section.</para>
	/// </param>
	/// <param name="ppIBitmap">
	/// <para>Type: <c>IWICBitmap**</c></para>
	/// <para>A pointer that receives the bitmap.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// The <c>WICCreateBitmapFromSection</c> function calls the WICCreateBitmapFromSectionEx function with the desiredAccessLevel
	/// parameter set to <c>WICSectionAccessLevelRead</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-wiccreatebitmapfromsection HRESULT
	// WICCreateBitmapFromSection( UINT width, UINT height, REFWICPixelFormatGUID pixelFormat, HANDLE hSection, UINT stride, UINT
	// offset, IWICBitmap **ppIBitmap );
	[DllImport(Lib.Windowscodecs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincodec.h", MSDNShortId = "a14022a0-7af6-4c06-9afa-4709b81efc96")]
	public static extern HRESULT WICCreateBitmapFromSection(uint width, uint height, in Guid pixelFormat, HSECTION hSection, uint stride, uint offset, out IWICBitmap? ppIBitmap);

	/// <summary>Returns a IWICBitmapSource that is backed by the pixels of a Windows Graphics Device Interface (GDI) section handle.</summary>
	/// <param name="width">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The width of the bitmap pixels.</para>
	/// </param>
	/// <param name="height">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The height of the bitmap pixels.</para>
	/// </param>
	/// <param name="pixelFormat">
	/// <para>Type: <c>REFWICPixelFormatGUID</c></para>
	/// <para>The pixel format of the bitmap.</para>
	/// </param>
	/// <param name="hSection">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>The section handle. This is a file mapping object handle returned by the CreateFileMapping function.</para>
	/// </param>
	/// <param name="stride">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The byte count of each scanline.</para>
	/// </param>
	/// <param name="offset">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The offset into the section.</para>
	/// </param>
	/// <param name="desiredAccessLevel">
	/// <para>Type: <c>WICSectionAccessLevel</c></para>
	/// <para>The desired access level.</para>
	/// </param>
	/// <param name="ppIBitmap">
	/// <para>Type: <c>IWICBitmap**</c></para>
	/// <para>A pointer that receives the bitmap.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-wiccreatebitmapfromsectionex HRESULT
	// WICCreateBitmapFromSectionEx( UINT width, UINT height, REFWICPixelFormatGUID pixelFormat, HANDLE hSection, UINT stride, UINT
	// offset, WICSectionAccessLevel desiredAccessLevel, IWICBitmap **ppIBitmap );
	[DllImport(Lib.Windowscodecs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincodec.h", MSDNShortId = "0c9892a5-c136-41f6-8161-8077afe1a9da")]
	public static extern HRESULT WICCreateBitmapFromSectionEx(uint width, uint height, in Guid pixelFormat, HSECTION hSection, uint stride, uint offset, WICSectionAccessLevel desiredAccessLevel, out IWICBitmap? ppIBitmap);

	/// <summary>Obtains the short name associated with a given GUID.</summary>
	/// <param name="guid">
	/// <para>Type: <c>REFGUID</c></para>
	/// <para>The GUID to retrieve the short name for.</para>
	/// </param>
	/// <param name="cchName">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size of the wzName buffer.</para>
	/// </param>
	/// <param name="wzName">
	/// <para>Type: <c>WCHAR*</c></para>
	/// <para>A pointer that receives the short name associated with the GUID.</para>
	/// </param>
	/// <param name="pcchActual">
	/// <para>Type: <c>UINT*</c></para>
	/// <para>The actual size needed to retrieve the entire short name associated with the GUID.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>Windows Imaging Component (WIC) short name mappings can be found within the following registry key:</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-wicmapguidtoshortname HRESULT WICMapGuidToShortName(
	// REFGUID guid, UINT cchName, WCHAR *wzName, UINT *pcchActual );
	[DllImport(Lib.Windowscodecs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincodec.h", MSDNShortId = "ae1e4680-2c20-4a3e-b931-206d26f4d09c")]
	public static extern HRESULT WICMapGuidToShortName(in Guid guid, uint cchName, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzName, out uint pcchActual);

	/// <summary>Obtains the name associated with a given schema.</summary>
	/// <param name="guidMetadataFormat">
	/// <para>Type: <c>REFGUID</c></para>
	/// <para>The metadata format GUID.</para>
	/// </param>
	/// <param name="pwzSchema">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>The URI string of the schema for which the name is to be retrieved.</para>
	/// </param>
	/// <param name="cchName">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size of the wzName buffer.</para>
	/// </param>
	/// <param name="wzName">
	/// <para>Type: <c>WCHAR*</c></para>
	/// <para>A pointer to a buffer that receives the schema's name.</para>
	/// <para>To obtain the required buffer size, call <c>WICMapSchemaToName</c> with cchName set to 0 and wzName set to <c>NULL</c>.</para>
	/// </param>
	/// <param name="pcchActual">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The actual buffer size needed to retrieve the entire schema name.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>You can extend the schema name mapping by adding to the following registry key:</para>
	/// <para><c>HKEY_CLASSES_ROOT</c><c>CLSID</c><c>{FAE3D380-FEA4-4623-8C75-C6B61110B681}</c><c>Schemas</c><c>BB5ACC38-F216-4CEC-A6C5-5F6E739763A9</c><c>...</c></para>
	/// <para>For more information, see How to Write a WIC-Enabled Codec.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-wicmapschematoname HRESULT WICMapSchemaToName( REFGUID
	// guidMetadataFormat, LPWSTR pwzSchema, UINT cchName, WCHAR *wzName, UINT *pcchActual );
	[DllImport(Lib.Windowscodecs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincodec.h", MSDNShortId = "6e71b75a-a542-459c-9935-b05f3ce39217")]
	public static extern HRESULT WICMapSchemaToName(in Guid guidMetadataFormat, [MarshalAs(UnmanagedType.LPWStr)] string pwzSchema, uint cchName, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzName, out uint pcchActual);

	/// <summary>Obtains the GUID associated with the given short name.</summary>
	/// <param name="wzName">
	/// <para>Type: <c>const WCHAR*</c></para>
	/// <para>A pointer to the short name.</para>
	/// </param>
	/// <param name="pguid">
	/// <para>Type: <c>GUID*</c></para>
	/// <para>A pointer that receives the GUID associated with the given short name.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>You can extend the short name mapping by adding to the following registry key:</para>
	/// <para><c>HKEY_CLASSES_ROOT</c><c>CLSID</c><c>{FAE3D380-FEA4-4623-8C75-C6B61110B681}</c><c>Namespace</c><c>...</c></para>
	/// <para>For more information, see How to Write a WIC-Enabled Codec.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincodec/nf-wincodec-wicmapshortnametoguid HRESULT WICMapShortNameToGuid(
	// PCWSTR wzName, GUID *pguid );
	[DllImport(Lib.Windowscodecs, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincodec.h", MSDNShortId = "ceefa802-7930-4b01-b1a2-6db530032e88")]
	public static extern HRESULT WICMapShortNameToGuid([MarshalAs(UnmanagedType.LPWStr)] string wzName, out Guid pguid);
}