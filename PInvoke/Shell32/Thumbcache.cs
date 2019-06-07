using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Alpha channel type information.</summary>
		[PInvokeData("thumbcache.h")]
		public enum WTS_ALPHATYPE
		{
			/// <summary>The bitmap is an unknown format. The Shell tries nonetheless to detect whether the image has an alpha channel.</summary>
			WTSAT_UNKNOWN = 0x0,

			/// <summary>The bitmap is an RGB image without alpha. The alpha channel is invalid and the Shell ignores it.</summary>
			WTSAT_RGB = 0x1,

			/// <summary>The bitmap is an ARGB image with a valid alpha channel.</summary>
			WTSAT_ARGB = 0x2
		}

		/// <summary>
		/// <para>
		/// Exposes a method for getting a thumbnail image and is intended to be implemented for thumbnail handlers. The object that
		/// implements this interface must also implement IInitializeWithStream.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The Shell calls IThumbnailProvider::GetThumbnail to obtain an image to use as a representation of the item.</para>
		/// <para>
		/// An implementation of this interface for photo thumbnails is supplied in Microsoft Windows as CLSID_PhotoThumbnailProvider.
		/// Applications that use the supplied implementation must define a constant CLSID identifier using the GUID {C7657C4A-9F68-40fa-A4DF-96BC08EB3551}.
		/// </para>
		/// <para>Initializing</para>
		/// <para>
		/// The object that implements this interface must also implement IInitializeWithStream . The Shell calls
		/// IInitializeWithStream::Initialize with the stream of the item, and IInitializeWithStream is the only initialization interface
		/// used when IThumbnailProvider instances are loaded out-of-proc (for isolation purposes). This is the primary code path for Windows
		/// for all IThumbnailCache code paths.
		/// </para>
		/// <para>
		/// It is possible for a thumbnail implementation to be initialized with IInitializeWithItem or IInitializeWithFile when the handler
		/// is request by a 3rd party without using the IThumbnailCache API, but this is uncommon. If you implement
		/// <c>IInitializeWithItem</c>, the Shell calls IInitializeWithItem::Initialize with the IShellItem representation of the item. If
		/// you implement <c>IInitializeWithFile</c>, the Shell calls IInitializeWithFile::Initialize with the path of the file.
		/// </para>
		/// <para>If none of these interfaces is present, <c>IThumbnailProvider</c> is not called.</para>
		/// <para><c>Client apps</c> If you're developing a client app, you should use IShellItemImageFactory instead.</para>
		/// <para>
		/// <c>Windows Vista</c> IThumbnailProivder is new for Vista and replaces IExtractImage. Vista still supports IExtractImage but lacks
		/// the ability to return the image type (alpha or not).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/thumbcache/nn-thumbcache-ithumbnailprovider
		[PInvokeData("thumbcache.h", MSDNShortId = "55c4739a-4835-4f53-a435-804ddf06ffcf")]
		[ComImport, Guid("e357fccd-a995-4576-b01f-234630154e96"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(PhotoThumbnailProvider))]
		public interface IThumbnailProvider
		{
			/// <summary>Gets a thumbnail image and alpha type.</summary>
			/// <param name="cx">
			/// The maximum thumbnail size, in pixels. The Shell draws the returned bitmap at this size or smaller. The returned bitmap
			/// should fit into a square of width and height cx, though it does not need to be a square image. The Shell scales the bitmap to
			/// render at lower sizes. For example, if the image has a 6:4 aspect ratio, then the returned bitmap should also have a 6:4
			/// aspect ratio.
			/// </param>
			/// <param name="phbmp">
			/// When this method returns, contains a pointer to the thumbnail image handle. The image must be a DIB section and 32 bits per
			/// pixel. The Shell scales down the bitmap if its width or height is larger than the size specified by cx. The Shell always
			/// respects the aspect ratio and never scales a bitmap larger than its original size.
			/// </param>
			/// <param name="pdwAlpha">
			/// When this method returns, contains a pointer to one of the following values from the WTS_ALPHATYPE enumeration.
			/// </param>
			/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			[PreserveSig]
			HRESULT GetThumbnail(uint cx, out HBITMAP phbmp, out WTS_ALPHATYPE pdwAlpha);
		}

		/// <summary>An implementation of IThumbnailProvider for photo thumbnails is supplied in Microsoft Windows as CLSID_PhotoThumbnailProvider.</summary>
		[ComImport, Guid("C7657C4A-9F68-40fa-A4DF-96BC08EB3551"), ClassInterface(ClassInterfaceType.None)]
		[PInvokeData("thumbcache.h")]
		public class PhotoThumbnailProvider { }
	}
}