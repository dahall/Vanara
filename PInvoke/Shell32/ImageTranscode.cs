using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Indicates the format of the resulting image.</summary>
	[PInvokeData("imagetranscode.h", MSDNShortId = "NN:imagetranscode.ITranscodeImage")]
	public enum TI_FLAGS
	{
		/// <summary>Convert the image to BMP format.</summary>
		TI_BITMAP = 1,

		/// <summary>Convert the image to JPEG format.</summary>
		TI_JPEG = 2
	}

	/// <summary>Exposes a method that allows conversion to JPEG or bitmap (BMP) image formats from any image type supported by Windows.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagetranscode/nn-imagetranscode-itranscodeimage
	[PInvokeData("imagetranscode.h", MSDNShortId = "NN:imagetranscode.ITranscodeImage")]
	[ComImport, Guid("BAE86DDD-DC11-421c-B7AB-CC55D1D65C44"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(ImageTranscode))]
	public interface ITranscodeImage
	{
		/// <summary>Converts an image to JPEG or bitmap (BMP) image format.</summary>
		/// <param name="pShellItem">
		/// <para>Type: <c>IShellItem*</c></para>
		/// <para>The Shell Item for the image to convert.</para>
		/// </param>
		/// <param name="uiMaxWidth">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The requested height in pixels. Should be less than or equal to the actual height of the original image. See Remarks.</para>
		/// </param>
		/// <param name="uiMaxHeight">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The requested width in pixels. Should be less than or equal to the actual width of the original image. See Remarks.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c>TI_FLAGS</c></para>
		/// <para>One of the following flags.</para>
		/// <para>TI_BITMAP</para>
		/// <para>Convert the image to BMP format.</para>
		/// <para>TI_JPEG</para>
		/// <para>Convert the image to JPEG format.</para>
		/// </param>
		/// <param name="pvImage">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>A stream to receive the converted image. The stream must be created by the calling code prior to calling <c>TranscodeImage</c>.</para>
		/// </param>
		/// <param name="puiWidth">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual width of the converted image.</para>
		/// </param>
		/// <param name="puiHeight">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The actual height of the converted image.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The aspect ratio of the original image is preserved. The new image is resized so that it will fit into a box of width
		/// <c>uiMaxWidth</c> and height <c>uiMaxHeight</c>.
		/// </para>
		/// <para>The image size will not be changed if the original image already fits in this bounding box.</para>
		/// <para>If both uiMaxWidth and uiMaxHeight are zero, the returned image will be the same size as the original.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imagetranscode/nf-imagetranscode-itranscodeimage-transcodeimage HRESULT
		// TranscodeImage( [in] IShellItem *pShellItem, UINT uiMaxWidth, UINT uiMaxHeight, DWORD flags, IStream *pvImage, [out, optional]
		// UINT *puiWidth, [out, optional] UINT *puiHeight );
		void TranscodeImage([In] IShellItem pShellItem, uint uiMaxWidth, uint uiMaxHeight, TI_FLAGS flags, [In, Out] IStream pvImage, out uint puiWidth, out uint puiHeight);
	}

	/// <summary>CLSID_ImageTranscode</summary>
	[ComImport, Guid("17B75166-928F-417d-9685-64AA135565C1"), ClassInterface(ClassInterfaceType.None)]
	public class ImageTranscode { }
}