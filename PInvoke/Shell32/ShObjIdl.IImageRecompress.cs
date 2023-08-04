using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Exposes a method that recompress images.</summary>
	/// <remarks>
	/// Implement <c>IImageRecompress</c> if you are implementing an image object that may need recompressing. The
	/// <c>IImageRecompress</c> interface is implemented in the ImageRecompress object.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-iimagerecompress
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IImageRecompress")]
	[ComImport, Guid("505f1513-6b3e-4892-a272-59f8889a4d3e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(ImageRecompress))]
	public interface IImageRecompress
	{
		/// <summary>
		/// Recompresses an image. Implemented in an ImageRecompress object, this method accepts x and y dimensions with a designation
		/// of quality. The method creates a stream containing the new image that has been recompressed to the specified size.
		/// </summary>
		/// <param name="psi">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>A pointer to the object containing the stream of the image to read.</para>
		/// </param>
		/// <param name="cx">
		/// <para>Type: <c>int</c></para>
		/// <para>The x dimension of the image to return.</para>
		/// </param>
		/// <param name="cy">
		/// <para>Type: <c>int</c></para>
		/// <para>The y dimension of the image to return.</para>
		/// </param>
		/// <param name="iQuality">
		/// <para>Type: <c>int</c></para>
		/// <para>An indication of recompression quality that can range from 0 to 100.</para>
		/// </param>
		/// <param name="pstg">
		/// <para>Type: <c>IStorage*</c></para>
		/// <para>A pointer to an IStorage interface on the object that contains the stream to be written to.</para>
		/// </param>
		/// <param name="ppstrmOut">
		/// <para>Type: <c>IStream**</c></para>
		/// <para>The address of an IStream interface pointer variable that receives the output stream written to.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK if successful, or a COM-defined error code otherwise. If the image in the input stream is less than the size
		/// specified by cx and cy, then S_FALSE is returned.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iimagerecompress-recompressimage
		// HRESULT RecompressImage( IShellItem *psi, int cx, int cy, int iQuality, IStorage *pstg, IStream **ppstrmOut );
		[PreserveSig]
		HRESULT RecompressImage(IShellItem psi, int cx, int cy, int iQuality, IStorage pstg, out IStream ppstrmOut);
	}

	/// <summary>CoClass for IImageRecompress</summary>
	[PInvokeData("shobjidl.h")]
	[ComImport, Guid("6e33091c-d2f8-4740-b55e-2e11d1477a2c"), ClassInterface(ClassInterfaceType.None)]
	public class ImageRecompress { }
}