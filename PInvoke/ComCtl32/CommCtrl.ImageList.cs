using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.InteropServices;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32_Gdi;

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Global

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		/// <summary><para>The set of bit flags that specifies the type of image list to create. This parameter can be a combination of the following values, but it can include only one of the ILC_COLOR values. Used by <c>ImageList_Create</c> and <c>IImageList2::Initialize</c>.</para><para><list type="table"><listheader><term>Constant/value</term><term>Description</term></listheader><item><term>ILC_MASK0x00000001</term><term>Use a mask. The image list contains two bitmaps, one of which is a monochrome bitmap used as a mask. If this value is not included, the image list contains only one bitmap.</term></item><item><term>ILC_COLOR0x00000000</term><term>Use the default behavior if none of the other ILC_COLORx flags is specified. Typically, the default is ILC_COLOR4, but for older display drivers, the default is ILC_COLORDDB.</term></item><item><term>ILC_COLORDDB0x000000FE</term><term>Use a device-dependent bitmap.</term></item><item><term>ILC_COLOR40x00000004</term><term>Use a 4-bit (16-color) device-independent bitmap (DIB) section as the bitmap for the image list.</term></item><item><term>ILC_COLOR80x00000008</term><term>Use an 8-bit DIB section. The colors used for the color table are the same colors as the halftone palette.</term></item><item><term>ILC_COLOR160x00000010</term><term>Use a 16-bit (32/64k-color) DIB section.</term></item><item><term>ILC_COLOR240x00000018</term><term>Use a 24-bit DIB section.</term></item><item><term>ILC_COLOR320x00000020</term><term>Use a 32-bit DIB section.</term></item><item><term>ILC_PALETTE0x00000800</term><term>Not implemented.</term></item><item><term>ILC_MIRROR0x00002000</term><term>Mirror the icons contained, if the process is mirrored</term></item><item><term>ILC_PERITEMMIRROR0x00008000</term><term>Causes the mirroring code to mirror each item when inserting a set of images, versus the whole strip.</term></item><item><term>ILC_ORIGINALSIZE0x00010000</term><term>Windows Vista and later. Imagelist should accept smaller than set images and apply original size based on image added.</term></item><item><term>ILC_HIGHQUALITYSCALE0x00020000</term><term>Windows Vista and later. Reserved.</term></item></list></para></summary><returns></returns>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb775232(v=vs.85).aspx
		[PInvokeData("Shlobj.h", MSDNShortId = "bb775232")]
		[Flags]
		public enum ILC : uint
		{
			/// <summary>Use a mask. The image list contains two bitmaps, one of which is a monochrome bitmap used as a mask. If this value is not included, the image list contains only one bitmap.</summary>
			ILC_MASK = 0x00000001,
			/// <summary>Use the default behavior if none of the other ILC_COLORx flags is specified. Typically, the default is ILC_COLOR4, but for older display drivers, the default is ILC_COLORDDB.</summary>
			ILC_COLOR = 0x00000000,
			/// <summary>Use a device-dependent bitmap.</summary>
			ILC_COLORDDB = 0x000000FE,
			/// <summary>Use a 4-bit (16-color) device-independent bitmap (DIB) section as the bitmap for the image list.</summary>
			ILC_COLOR4 = 0x00000004,
			/// <summary>Use an 8-bit DIB section. The colors used for the color table are the same colors as the halftone palette.</summary>
			ILC_COLOR8 = 0x00000008,
			/// <summary>Use a 16-bit (32/64k-color) DIB section.</summary>
			ILC_COLOR16 = 0x00000010,
			/// <summary>Use a 24-bit DIB section.</summary>
			ILC_COLOR24 = 0x00000018,
			/// <summary>Use a 32-bit DIB section.</summary>
			ILC_COLOR32 = 0x00000020,
			/// <summary>Not implemented.</summary>
			ILC_PALETTE = 0x00000800,
			/// <summary>Mirror the icons contained, if the process is mirrored</summary>
			ILC_MIRROR = 0x00002000,
			/// <summary>Causes the mirroring code to mirror each item when inserting a set of images, versus the whole strip.</summary>
			ILC_PERITEMMIRROR = 0x00008000,
			/// <summary>Windows Vista and later. Imagelist should accept smaller than set images and apply original size based on image added.</summary>
			ILC_ORIGINALSIZE = 0x00010000,
			/// <summary>Windows Vista and later. Reserved.</summary>
			ILC_HIGHQUALITYSCALE = 0x00020000,
		}

		/// <summary>Discard images flags.</summary>
		[Flags]
		public enum ILDI : uint
		{
			/// <summary>Discard and purge.</summary>
			ILDI_PURGE = 0x00000001,
			/// <summary>Discard to standby list.</summary>
			ILDI_STANDBY = 0x00000002,
			/// <summary>Reset the "has been accessed" flag.</summary>
			ILDI_RESETACCESS = 0x00000004,
			/// <summary>Ask whether access flag is set (but do not reset).</summary>
			ILDI_QUERYACCESS = 0x00000008,
		}

		/// <summary>Force image flags.</summary>
		public enum ILFIP
		{
			/// <summary>Always get the image (can be slow).</summary>
			ILFIP_ALWAYS = 0x00000000,
			/// <summary>Only get if on standby.</summary>
			ILFIP_FROMSTANDBY = 0x00000001,
		}

		/// <summary>Flags for getting original size.</summary>
		public enum ILGOS
		{
			/// <summary>Always get the original size (can be slow).</summary>
			ILGOS_ALWAYS = 0x00000000,
			/// <summary>Only get if present or on standby.</summary>
			ILGOS_FROMSTANDBY = 0x00000001,
		}

		/// <summary>A flag that specifies how the stream is read.</summary>
		public enum ILP
		{
			/// <summary>Expects an image list that was written with the ILP_NORMAL flag specified.</summary>
			ILP_NORMAL,
			/// <summary>Expects an image list that was written with the ILP_DOWNLEVEL flag specified.</summary>
			ILP_DOWNLEVEL
		}

		/// <summary>Specifies how the mask is applied to the image as one or a bitwise combination of the following decoration flags.</summary>
		[Flags]
		public enum ILR
		{
			/// <summary>Not used.</summary>
			ILR_DEFAULT = 0x0000,
			/// <summary>Horizontally align to left.</summary>
			ILR_HORIZONTAL_LEFT = 0x0000,
			/// <summary>Horizontally center.</summary>
			ILR_HORIZONTAL_CENTER = 0x0001,
			/// <summary>Horizontally align to right.</summary>
			ILR_HORIZONTAL_RIGHT = 0x0002,
			/// <summary>Vertically align to top.</summary>
			ILR_VERTICAL_TOP = 0x0000,
			/// <summary>Vertically align to center.</summary>
			ILR_VERTICAL_CENTER = 0x0010,
			/// <summary>Vertically align to bottom.</summary>
			ILR_VERTICAL_BOTTOM = 0x0020,
			/// <summary>Do nothing.</summary>
			ILR_SCALE_CLIP = 0x0000,
			/// <summary>Scale.</summary>
			ILR_SCALE_ASPECTRATIO = 0x0100,
		}

		/// <summary>Flags used when copying image lists.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775230")]
		public enum IMAGELISTCOPYFLAG
		{
			/// <summary>The source image is copied to the destination image's index. This operation results in multiple instances of a given image.</summary>
			ILCF_MOVE = 0,
			/// <summary>The source and destination images exchange positions within the image list.</summary>
			ILCF_SWAP = 1
		}

		/// <summary>Passed to the IImageList::Draw method in the fStyle member of IMAGELISTDRAWPARAMS.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775230")]
		[Flags]
		public enum IMAGELISTDRAWFLAGS : uint
		{
			/// <summary>
			/// Draws the image using the background color for the image list. If the background color is the CLR_NONE value, the image is drawn transparently
			/// using the mask.
			/// </summary>
			ILD_NORMAL = 0X00000000,
			/// <summary>
			/// Draws the image transparently using the mask, regardless of the background color. This value has no effect if the image list does not contain a mask.
			/// </summary>
			ILD_TRANSPARENT = 0x00000001,
			/// <summary>
			/// Draws the image, blending 25 percent with the blend color specified by rgbFg. This value has no effect if the image list does not contain a mask.
			/// </summary>
			ILD_BLEND25 = 0X00000002,
			/// <summary>Same as ILD_BLEND25</summary>
			ILD_FOCUS = ILD_BLEND25,
			/// <summary>
			/// Draws the image, blending 50 percent with the blend color specified by rgbFg. This value has no effect if the image list does not contain a mask.
			/// </summary>
			ILD_BLEND50 = 0X00000004,
			/// <summary>Same as ILD_BLEND50</summary>
			ILD_SELECTED = ILD_BLEND50,
			/// <summary>Same as ILD_BLEND50</summary>
			ILD_BLEND = ILD_BLEND50,
			/// <summary>Draws the mask.</summary>
			ILD_MASK = 0X00000010,
			/// <summary>If the overlay does not require a mask to be drawn, set this flag.</summary>
			ILD_IMAGE = 0X00000020,
			/// <summary>Draws the image using the raster operation code specified by the dwRop member.</summary>
			ILD_ROP = 0X00000040,
			/// <summary>To extract the overlay image from the fStyle member, use the logical AND to combine fStyle with the ILD_OVERLAYMASK value.</summary>
			ILD_OVERLAYMASK = 0x00000F00,
			/// <summary>Preserves the alpha channel in the destination.</summary>
			ILD_PRESERVEALPHA = 0x00001000,
			/// <summary>Causes the image to be scaled to cx, cy instead of being clipped.</summary>
			ILD_SCALE = 0X00002000,
			/// <summary>Scales the image to the current dpi of the display.</summary>
			ILD_DPISCALE = 0X00004000,
			/// <summary>
			/// <c>Windows Vista and later.</c> Draw the image if it is available in the cache. Do not extract it automatically. The called draw method returns
			/// E_PENDING to the calling component, which should then take an alternative action, such as, provide another image and queue a background task to
			/// force the image to be loaded via ForceImagePresent using the ILFIP_ALWAYS flag. The ILD_ASYNC flag then prevents the extraction operation from
			/// blocking the current thread and is especially important if a draw method is called from the user interface (UI) thread.
			/// </summary>
			ILD_ASYNC = 0X00008000
		}

		/// <summary>Item flags.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761486")]
		public enum IMAGELISTITEMFLAG
		{
			/// <summary>Indicates that the item in the imagelist has an alpha channel.</summary>
			ILIF_ALPHA = 1,
			/// <summary>
			/// Windows Vista and later. Indicates that the item in the imagelist was generated via a StretchBlt function, consequently image quality may have degraded.
			/// </summary>
			ILIF_LOWQUALITY = 2
		}

		/// <summary>The following flags are passed to the IImageList::Draw method in the fState member of IMAGELISTDRAWPARAMS.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775231")]
		[Flags]
		public enum IMAGELISTSTATEFLAGS
		{
			/// <summary>The image state is not modified.</summary>
			ILS_NORMAL = 0x00000000,
			/// <summary>Not supported.</summary>
			ILS_GLOW = 0x00000001,
			/// <summary>Not supported.</summary>
			ILS_SHADOW = 0x00000002,
			/// <summary>Reduces the color saturation of the icon to grayscale. This only affects 32bpp images.</summary>
			ILS_SATURATE = 0x00000004,
			/// <summary>
			/// Alpha blends the icon. Alpha blending controls the transparency level of an icon, according to the value of its alpha channel. The value of the
			/// alpha channel is indicated by the frame member in the IMAGELISTDRAWPARAMS method. The alpha channel can be from 0 to 255, with 0 being completely
			/// transparent, and 255 being completely opaque.
			/// </summary>
			ILS_ALPHA = 0x00000008,
		}

		/// <summary>Exposes methods that manipulate and interact with image lists.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761490")]
		[ComImport, Guid("46EB5926-582E-4017-9FDF-E8998DAA0950"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(CImageList))]
		public interface IImageList
		{
			/// <summary>Adds an image or images to an image list.</summary>
			/// <param name="hbmImage">A handle to the bitmap that contains the image or images. The number of images is inferred from the width of the bitmap.</param>
			/// <param name="hbmMask">A handle to the bitmap that contains the mask. If no mask is used with the image list, this parameter is ignored.</param>
			/// <returns>
			/// When this method returns, contains a pointer to the index of the first new image. If the method fails to successfully add the new image, this
			/// value is -1.
			/// </returns>
			int Add(IntPtr hbmImage, [Optional] IntPtr hbmMask);

			/// <summary>Replaces an image with an icon or cursor.</summary>
			/// <param name="i">
			/// A value of type int that contains the index of the image to replace. If i is -1, the function adds the image to the end of the list.
			/// </param>
			/// <param name="hicon">A handle to the icon or cursor that contains the bitmap and mask for the new image.</param>
			/// <returns>A pointer to an int that will contain the index of the image on return if successful, or -1 otherwise.</returns>
			int ReplaceIcon(int i, IntPtr hicon);

			/// <summary>
			/// Adds a specified image to the list of images used as overlay masks. An image list can have up to four overlay masks in Common Controls version
			/// 4.70 and earlier, and up to 15 in version 4.71 or later. The method assigns an overlay mask index to the specified image.
			/// </summary>
			/// <param name="iImage">
			/// A value of type int that contains the zero-based index of an image in the image list. This index identifies the image to use as an overlay mask.
			/// </param>
			/// <param name="iOverlay">A value of type int that contains the one-based index of the overlay mask.</param>
			void SetOverlayImage(int iImage, int iOverlay);

			/// <summary>Replaces an image in an image list with a new image.</summary>
			/// <param name="i">A value of type int that contains the index of the image to replace.</param>
			/// <param name="hbmImage">A handle to the bitmap that contains the image.</param>
			/// <param name="hbmMask">A handle to the bitmap that contains the mask. If no mask is used with the image list, this parameter is ignored.</param>
			void Replace(int i, IntPtr hbmImage, [Optional] IntPtr hbmMask);

			/// <summary>Adds an image or images to an image list, generating a mask from the specified bitmap.</summary>
			/// <param name="hbmImage">A handle to the bitmap that contains one or more images. The number of images is inferred from the width of the bitmap.</param>
			/// <param name="crMask">
			/// The color used to generate the mask. Each pixel of this color in the specified bitmap is changed to black, and the corresponding bit in the mask
			/// is set to 1.
			/// </param>
			/// <returns>A pointer to an int that contains the index of the first new image when it returns, if successful, or -1 otherwise.</returns>
			int AddMasked(IntPtr hbmImage, COLORREF crMask);

			/// <summary>Draws an image list item in the specified device context.</summary>
			/// <param name="pimldp">A pointer to an IMAGELISTDRAWPARAMS structure that contains the drawing parameters.</param>
			void Draw(IMAGELISTDRAWPARAMS pimldp);

			/// <summary>Removes an image from an image list.</summary>
			/// <param name="i">A value of type int that contains the index of the image to remove. If this parameter is -1, the method removes all images.</param>
			void Remove(int i);

			/// <summary>Creates an icon from an image and a mask in an image list.</summary>
			/// <param name="i">A value of type int that contains the index of the image.</param>
			/// <param name="flags">A combination of flags that specify the drawing style. For a list of values, see IImageList::Draw.</param>
			/// <returns>A pointer to an int that contains the handle to the icon if successful, or NULL if otherwise.</returns>
			IntPtr GetIcon(int i, IMAGELISTDRAWFLAGS flags);

			/// <summary>Gets information about an image.</summary>
			/// <param name="i">A value of type int that contains the index of the image.</param>
			/// <returns>
			/// A pointer to an IMAGEINFO structure that receives information about the image. The information in this structure can directly manipulate the
			/// bitmaps of the image.
			/// </returns>
			IMAGEINFO GetImageInfo(int i);

			/// <summary>Copies images from a given image list.</summary>
			/// <param name="iDst">A value of type int that contains the zero-based index of the destination image for the copy operation.</param>
			/// <param name="punkSrc">A pointer to the IUnknown interface for the source image list.</param>
			/// <param name="iSrc">A value of type int that contains the zero-based index of the source image for the copy operation.</param>
			/// <param name="uFlags">A value that specifies the type of copy operation to be made.</param>
			void Copy(int iDst, IImageList punkSrc, int iSrc, IMAGELISTCOPYFLAG uFlags);

			/// <summary>Creates a new image by combining two existing images. This method also creates a new image list in which to store the image.</summary>
			/// <param name="i1">A value of type int that contains the index of the first existing image.</param>
			/// <param name="punk2">A pointer to the IUnknown interface of the image list that contains the second image.</param>
			/// <param name="i2">A value of type int that contains the index of the second existing image.</param>
			/// <param name="dx">A value of type int that contains the x-component of the offset of the second image relative to the first image.</param>
			/// <param name="dy">A value of type int that contains the y-component of the offset of the second image relative to the first image.</param>
			/// <param name="riid">An IID of the interface for the new image list.</param>
			/// <returns>A raw pointer to the interface for the new image list.</returns>
			IImageList Merge(int i1, IImageList punk2, int i2, int dx, int dy, [MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Clones an existing image list.</summary>
			/// <param name="riid">An IID for the new image list.</param>
			/// <returns>The address of a pointer to the interface for the new image list.</returns>
			IImageList Clone([MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets an image's bounding rectangle.</summary>
			/// <param name="i">A value of type int that contains the index of the image.</param>
			/// <returns>A pointer to a RECT that contains the bounding rectangle when the method returns.</returns>
			RECT GetImageRect(int i);

			/// <summary>Gets the dimensions of images in an image list. All images in an image list have the same dimensions.</summary>
			/// <param name="cx">A pointer to an int that receives the width, in pixels, of each image.</param>
			/// <param name="cy">A pointer to an int that receives the height, in pixels, of each image.</param>
			void GetIconSize(out int cx, out int cy);

			/// <summary>Sets the dimensions of images in an image list and removes all images from the list.</summary>
			/// <param name="cx">
			/// A value of type int that contains the width, in pixels, of the images in the image list. All images in an image list have the same dimensions.
			/// </param>
			/// <param name="cy">
			/// A value of type int that contains the height, in pixels, of the images in the image list. All images in an image list have the same dimensions.
			/// </param>
			void SetIconSize(int cx, int cy);

			/// <summary>Gets the number of images in an image list.</summary>
			/// <returns>A pointer to an int that contains the number of images when the method returns.</returns>
			int GetImageCount();

			/// <summary>Resizes an existing image list.</summary>
			/// <param name="uNewCount">A value that specifies the new size of the image list.</param>
			void SetImageCount(int uNewCount);

			/// <summary>
			/// Sets the background color for an image list. This method only functions if you add an icon to the image list or use the IImageList::AddMasked
			/// method to add a black and white bitmap. Without a mask, the entire image draws, and the background color is not visible.
			/// </summary>
			/// <param name="clrBk">The background color to set. If this parameter is set to CLR_NONE, then images draw transparently using the mask.</param>
			/// <param name="pclr">A pointer to a COLORREF that contains the previous background color on return if successful, or CLR_NONE otherwise.</param>
			void SetBkColor(COLORREF clrBk, out COLORREF pclr);

			/// <summary>Gets the current background color for an image list.</summary>
			/// <returns>A pointer to a COLORREF that contains the background color when the method returns.</returns>
			COLORREF GetBkColor();

			/// <summary>Begins dragging an image.</summary>
			/// <param name="iTrack">A value of type int that contains the index of the image to drag.</param>
			/// <param name="dxHotspot">A value of type int that contains the x-component of the drag position relative to the upper-left corner of the image.</param>
			/// <param name="dyHotspot">A value of type int that contains the y-component of the drag position relative to the upper-left corner of the image.</param>
			void BeginDrag(int iTrack, int dxHotspot, int dyHotspot);

			/// <summary>Ends a drag operation.</summary>
			void EndDrag();

			/// <summary>Locks updates to the specified window during a drag operation and displays the drag image at the specified position within the window.</summary>
			/// <param name="hwndLock">A handle to the window that owns the drag image.</param>
			/// <param name="x">
			/// The x-coordinate at which to display the drag image. The coordinate is relative to the upper-left corner of the window, not the client area.
			/// </param>
			/// <param name="y">
			/// The y-coordinate at which to display the drag image. The coordinate is relative to the upper-left corner of the window, not the client area.
			/// </param>
			void DragEnter(HandleRef hwndLock, int x, int y);

			/// <summary>Unlocks the specified window and hides the drag image, which enables the window to update.</summary>
			/// <param name="hwndLock">A handle to the window that contains the drag image.</param>
			void DragLeave(HandleRef hwndLock);

			/// <summary>
			/// Moves the image that is being dragged during a drag-and-drop operation. This function is typically called in response to a WM_MOUSEMOVE message.
			/// </summary>
			/// <param name="x">
			/// A value of type int that contains the x-coordinate where the drag image appears. The coordinate is relative to the upper-left corner of the
			/// window, not the client area.
			/// </param>
			/// <param name="y">
			/// A value of type int that contains the y-coordinate where the drag image appears. The coordinate is relative to the upper-left corner of the
			/// window, not the client area.
			/// </param>
			void DragMove(int x, int y);

			/// <summary>Creates a new drag image by combining the specified image, which is typically a mouse cursor image, with the current drag image.</summary>
			/// <param name="punk">
			/// A pointer to the IUnknown interface that accesses the image list interface, which contains the new image to combine with the drag image.
			/// </param>
			/// <param name="iDrag">A value of type int that contains the index of the new image to combine with the drag image.</param>
			/// <param name="dxHotspot">A value of type int that contains the x-component of the hot spot within the new image.</param>
			/// <param name="dyHotspot">A value of type int that contains the x-component of the hot spot within the new image.</param>
			void SetDragCursorImage(IImageList punk, int iDrag, int dxHotspot, int dyHotspot);

			/// <summary>Shows or hides the image being dragged.</summary>
			/// <param name="fShow">
			/// A value that specifies whether to show or hide the image being dragged. Specify TRUE to show the image or FALSE to hide the image.
			/// </param>
			void DragShowNolock([MarshalAs(UnmanagedType.Bool)] bool fShow);

			/// <summary>
			/// Gets the temporary image list that is used for the drag image. The function also retrieves the current drag position and the offset of the drag
			/// image relative to the drag position.
			/// </summary>
			/// <param name="ppt">A pointer to a POINT structure that receives the current drag position. Can be NULL.</param>
			/// <param name="pptHotspot">A pointer to a POINT structure that receives the offset of the drag image relative to the drag position. Can be NULL.</param>
			/// <param name="riid">An IID for the image list.</param>
			/// <returns>The address of a pointer to the interface for the image list if successful, NULL otherwise.</returns>
			IImageList GetDragImage(out Point ppt, out Point pptHotspot, [MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets the flags of an image.</summary>
			/// <param name="i">A value of type int that contains the index of the images whose flags need to be retrieved.</param>
			/// <returns>A pointer to a DWORD that contains the flags when the method returns.</returns>
			IMAGELISTITEMFLAG GetItemFlags(int i);

			/// <summary>Gets the overlay image.</summary>
			/// <param name="iOverlay">The i overlay.</param>
			/// <returns></returns>
			int GetOverlayImage(int iOverlay);
		}

		/// <summary>Gets the dimensions of images in an image list. All images in an image list have the same dimensions.</summary>
		/// <param name="il">The <see cref="IImageList"/> instance.</param>
		/// <returns>The size of images.</returns>
		public static Size GetIconSize(this IImageList il)
		{
			il.GetIconSize(out int cx, out int cy);
			return new Size(cx, cy);
		}

		/// <summary>Sets the dimensions of images in an image list and removes all images from the list.</summary>
		/// <param name="il">The <see cref="IImageList"/> instance.</param>
		/// <param name="size">
		/// A value that contains the width and height, in pixels, of the images in the image list. All images in an image list have the same dimensions.
		/// </param>
		public static void SetIconSize(this IImageList il, Size size) => il.SetIconSize(size.Width, size.Height);

		/// <summary>Extends IImageList by providing additional methods for manipulating and interacting with image lists.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761419")]
		[ComImport, Guid("192b9d83-50fc-457b-90a0-2b82a8b5dae1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(CImageList))]
		public interface IImageList2 : IImageList
		{
			/// <summary>Adds an image or images to an image list.</summary>
			/// <param name="hbmImage">A handle to the bitmap that contains the image or images. The number of images is inferred from the width of the bitmap.</param>
			/// <param name="hbmMask">A handle to the bitmap that contains the mask. If no mask is used with the image list, this parameter is ignored.</param>
			/// <returns>
			/// When this method returns, contains a pointer to the index of the first new image. If the method fails to successfully add the new image, this
			/// value is -1.
			/// </returns>
			new int Add(IntPtr hbmImage, [Optional] IntPtr hbmMask);

			/// <summary>Replaces an image with an icon or cursor.</summary>
			/// <param name="i">
			/// A value of type int that contains the index of the image to replace. If i is -1, the function adds the image to the end of the list.
			/// </param>
			/// <param name="hicon">A handle to the icon or cursor that contains the bitmap and mask for the new image.</param>
			/// <returns>A pointer to an int that will contain the index of the image on return if successful, or -1 otherwise.</returns>
			new int ReplaceIcon(int i, IntPtr hicon);

			/// <summary>
			/// Adds a specified image to the list of images used as overlay masks. An image list can have up to four overlay masks in Common Controls version
			/// 4.70 and earlier, and up to 15 in version 4.71 or later. The method assigns an overlay mask index to the specified image.
			/// </summary>
			/// <param name="iImage">
			/// A value of type int that contains the zero-based index of an image in the image list. This index identifies the image to use as an overlay mask.
			/// </param>
			/// <param name="iOverlay">A value of type int that contains the one-based index of the overlay mask.</param>
			new void SetOverlayImage(int iImage, int iOverlay);

			/// <summary>Replaces an image in an image list with a new image.</summary>
			/// <param name="i">A value of type int that contains the index of the image to replace.</param>
			/// <param name="hbmImage">A handle to the bitmap that contains the image.</param>
			/// <param name="hbmMask">A handle to the bitmap that contains the mask. If no mask is used with the image list, this parameter is ignored.</param>
			new void Replace(int i, IntPtr hbmImage, [Optional] IntPtr hbmMask);

			/// <summary>Adds an image or images to an image list, generating a mask from the specified bitmap.</summary>
			/// <param name="hbmImage">A handle to the bitmap that contains one or more images. The number of images is inferred from the width of the bitmap.</param>
			/// <param name="crMask">
			/// The color used to generate the mask. Each pixel of this color in the specified bitmap is changed to black, and the corresponding bit in the mask
			/// is set to 1.
			/// </param>
			/// <returns>A pointer to an int that contains the index of the first new image when it returns, if successful, or -1 otherwise.</returns>
			new int AddMasked(IntPtr hbmImage, COLORREF crMask);

			/// <summary>Draws an image list item in the specified device context.</summary>
			/// <param name="pimldp">A pointer to an IMAGELISTDRAWPARAMS structure that contains the drawing parameters.</param>
			new void Draw(IMAGELISTDRAWPARAMS pimldp);

			/// <summary>Removes an image from an image list.</summary>
			/// <param name="i">A value of type int that contains the index of the image to remove. If this parameter is -1, the method removes all images.</param>
			new void Remove(int i);

			/// <summary>Creates an icon from an image and a mask in an image list.</summary>
			/// <param name="i">A value of type int that contains the index of the image.</param>
			/// <param name="flags">A combination of flags that specify the drawing style. For a list of values, see IImageList::Draw.</param>
			/// <returns>A pointer to an int that contains the handle to the icon if successful, or NULL if otherwise.</returns>
			new IntPtr GetIcon(int i, IMAGELISTDRAWFLAGS flags);

			/// <summary>Gets information about an image.</summary>
			/// <param name="i">A value of type int that contains the index of the image.</param>
			/// <returns>
			/// A pointer to an IMAGEINFO structure that receives information about the image. The information in this structure can directly manipulate the
			/// bitmaps of the image.
			/// </returns>
			new IMAGEINFO GetImageInfo(int i);

			/// <summary>Copies images from a given image list.</summary>
			/// <param name="iDst">A value of type int that contains the zero-based index of the destination image for the copy operation.</param>
			/// <param name="punkSrc">A pointer to the IUnknown interface for the source image list.</param>
			/// <param name="iSrc">A value of type int that contains the zero-based index of the source image for the copy operation.</param>
			/// <param name="uFlags">A value that specifies the type of copy operation to be made.</param>
			new void Copy(int iDst, IImageList punkSrc, int iSrc, IMAGELISTCOPYFLAG uFlags);

			/// <summary>Creates a new image by combining two existing images. This method also creates a new image list in which to store the image.</summary>
			/// <param name="i1">A value of type int that contains the index of the first existing image.</param>
			/// <param name="punk2">A pointer to the IUnknown interface of the image list that contains the second image.</param>
			/// <param name="i2">A value of type int that contains the index of the second existing image.</param>
			/// <param name="dx">A value of type int that contains the x-component of the offset of the second image relative to the first image.</param>
			/// <param name="dy">A value of type int that contains the y-component of the offset of the second image relative to the first image.</param>
			/// <param name="riid">An IID of the interface for the new image list.</param>
			/// <returns>A raw pointer to the interface for the new image list.</returns>
			new IImageList Merge(int i1, IImageList punk2, int i2, int dx, int dy, [MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Clones an existing image list.</summary>
			/// <param name="riid">An IID for the new image list.</param>
			/// <returns>The address of a pointer to the interface for the new image list.</returns>
			new IImageList Clone([MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets an image's bounding rectangle.</summary>
			/// <param name="i">A value of type int that contains the index of the image.</param>
			/// <returns>A pointer to a RECT that contains the bounding rectangle when the method returns.</returns>
			new RECT GetImageRect(int i);

			/// <summary>Gets the dimensions of images in an image list. All images in an image list have the same dimensions.</summary>
			/// <param name="cx">A pointer to an int that receives the width, in pixels, of each image.</param>
			/// <param name="cy">A pointer to an int that receives the height, in pixels, of each image.</param>
			new void GetIconSize(out int cx, out int cy);

			/// <summary>Sets the dimensions of images in an image list and removes all images from the list.</summary>
			/// <param name="cx">
			/// A value of type int that contains the width, in pixels, of the images in the image list. All images in an image list have the same dimensions.
			/// </param>
			/// <param name="cy">
			/// A value of type int that contains the height, in pixels, of the images in the image list. All images in an image list have the same dimensions.
			/// </param>
			new void SetIconSize(int cx, int cy);

			/// <summary>Gets the number of images in an image list.</summary>
			/// <returns>A pointer to an int that contains the number of images when the method returns.</returns>
			new int GetImageCount();

			/// <summary>Resizes an existing image list.</summary>
			/// <param name="uNewCount">A value that specifies the new size of the image list.</param>
			new void SetImageCount(int uNewCount);

			/// <summary>
			/// Sets the background color for an image list. This method only functions if you add an icon to the image list or use the IImageList::AddMasked
			/// method to add a black and white bitmap. Without a mask, the entire image draws, and the background color is not visible.
			/// </summary>
			/// <param name="clrBk">The background color to set. If this parameter is set to CLR_NONE, then images draw transparently using the mask.</param>
			/// <param name="pclr">A pointer to a COLORREF that contains the previous background color on return if successful, or CLR_NONE otherwise.</param>
			new void SetBkColor(COLORREF clrBk, out COLORREF pclr);

			/// <summary>Gets the current background color for an image list.</summary>
			/// <returns>A pointer to a COLORREF that contains the background color when the method returns.</returns>
			new COLORREF GetBkColor();


			/// <summary>Begins dragging an image.</summary>
			/// <param name="iTrack">A value of type int that contains the index of the image to drag.</param>
			/// <param name="dxHotspot">A value of type int that contains the x-component of the drag position relative to the upper-left corner of the image.</param>
			/// <param name="dyHotspot">A value of type int that contains the y-component of the drag position relative to the upper-left corner of the image.</param>
			new void BeginDrag(int iTrack, int dxHotspot, int dyHotspot);

			/// <summary>Ends a drag operation.</summary>
			new void EndDrag();

			/// <summary>Locks updates to the specified window during a drag operation and displays the drag image at the specified position within the window.</summary>
			/// <param name="hwndLock">A handle to the window that owns the drag image.</param>
			/// <param name="x">
			/// The x-coordinate at which to display the drag image. The coordinate is relative to the upper-left corner of the window, not the client area.
			/// </param>
			/// <param name="y">
			/// The y-coordinate at which to display the drag image. The coordinate is relative to the upper-left corner of the window, not the client area.
			/// </param>
			new void DragEnter(HandleRef hwndLock, int x, int y);

			/// <summary>Unlocks the specified window and hides the drag image, which enables the window to update.</summary>
			/// <param name="hwndLock">A handle to the window that contains the drag image.</param>
			new void DragLeave(HandleRef hwndLock);

			/// <summary>
			/// Moves the image that is being dragged during a drag-and-drop operation. This function is typically called in response to a WM_MOUSEMOVE message.
			/// </summary>
			/// <param name="x">
			/// A value of type int that contains the x-coordinate where the drag image appears. The coordinate is relative to the upper-left corner of the
			/// window, not the client area.
			/// </param>
			/// <param name="y">
			/// A value of type int that contains the y-coordinate where the drag image appears. The coordinate is relative to the upper-left corner of the
			/// window, not the client area.
			/// </param>
			new void DragMove(int x, int y);

			/// <summary>Creates a new drag image by combining the specified image, which is typically a mouse cursor image, with the current drag image.</summary>
			/// <param name="punk">
			/// A pointer to the IUnknown interface that accesses the image list interface, which contains the new image to combine with the drag image.
			/// </param>
			/// <param name="iDrag">A value of type int that contains the index of the new image to combine with the drag image.</param>
			/// <param name="dxHotspot">A value of type int that contains the x-component of the hot spot within the new image.</param>
			/// <param name="dyHotspot">A value of type int that contains the x-component of the hot spot within the new image.</param>
			new void SetDragCursorImage(IImageList punk, int iDrag, int dxHotspot, int dyHotspot);

			/// <summary>Shows or hides the image being dragged.</summary>
			/// <param name="fShow">
			/// A value that specifies whether to show or hide the image being dragged. Specify TRUE to show the image or FALSE to hide the image.
			/// </param>
			new void DragShowNolock([MarshalAs(UnmanagedType.Bool)] bool fShow);

			/// <summary>
			/// Gets the temporary image list that is used for the drag image. The function also retrieves the current drag position and the offset of the drag
			/// image relative to the drag position.
			/// </summary>
			/// <param name="ppt">A pointer to a POINT structure that receives the current drag position. Can be NULL.</param>
			/// <param name="pptHotspot">A pointer to a POINT structure that receives the offset of the drag image relative to the drag position. Can be NULL.</param>
			/// <param name="riid">An IID for the image list.</param>
			/// <returns>The address of a pointer to the interface for the image list if successful, NULL otherwise.</returns>
			new IImageList GetDragImage(out Point ppt, out Point pptHotspot, [MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Gets the flags of an image.</summary>
			/// <param name="i">A value of type int that contains the index of the images whose flags need to be retrieved.</param>
			/// <returns>A pointer to a DWORD that contains the flags when the method returns.</returns>
			new IMAGELISTITEMFLAG GetItemFlags(int i);

			/// <summary>Retrieves a specified image from the list of images used as overlay masks.</summary>
			/// <param name="iOverlay">A value of type int that contains the one-based index of the overlay mask.</param>
			/// <returns>
			/// A pointer to an int that receives the zero-based index of an image in the image list. This index identifies the image that is used as an overlay mask.
			/// </returns>
			new int GetOverlayImage(int iOverlay);

			/// <summary>Resizes the current image.</summary>
			/// <param name="cxNewIconSize">The x-axis count, in pixels, for the new size.</param>
			/// <param name="cyNewIconSize">The y-axis count, in pixels, for the new size.</param>
			void Resize(int cxNewIconSize, int cyNewIconSize);

			/// <summary>Gets the original size of a specified image.</summary>
			/// <param name="iImage">The index of desired image.</param>
			/// <param name="dwFlags">Flags for getting original size.</param>
			/// <param name="pcx">A pointer to the x-axis count.</param>
			/// <param name="pcy">A pointer to the y-axis count.</param>
			void GetOriginalSize(int iImage, ILGOS dwFlags, out int pcx, out int pcy);

			/// <summary>Sets the original size of a specified image.</summary>
			/// <param name="iImage">An index of desired image.</param>
			/// <param name="cx">The x-axis count.</param>
			/// <param name="cy">The y-axis count.</param>
			void SetOriginalSize(int iImage, int cx, int cy);

			/// <summary>Sets an image list callback.</summary>
			/// <param name="punk">A pointer to the callback interface.</param>
			void SetCallback([MarshalAs(UnmanagedType.IUnknown)] object punk);

			/// <summary>Gets an image list callback object.</summary>
			/// <param name="riid">Reference to a desired IID.</param>
			/// <returns>Contains the address of a pointer to a callback object.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object GetCallback([MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			/// <summary>Forces an image present, as specified.</summary>
			/// <param name="iImage">An index of image to force present.</param>
			/// <param name="dwFlags">Force image flags.</param>
			void ForceImagePresent(int iImage, uint dwFlags);

			/// <summary>Discards images from list, as specified.</summary>
			/// <param name="iFirstImage">An index of first image to discard.</param>
			/// <param name="iLastImage">An index of last image to discard.</param>
			/// <param name="dwFlags">Discard images flags. ILDI_STANDBY and ILDI_PURGE are mutually exclusive. ILDI_RESETACCESS can be combined with either.</param>
			void DiscardImages(int iFirstImage, int iLastImage, ILDI dwFlags);

			/// <summary>Preloads images, as specified.</summary>
			/// <param name="pimldp">A pointer to an IMAGELISTDRAWPARAMS structure containing information about an image list draw operation.</param>
			void PreloadImages(ref IMAGELISTDRAWPARAMS pimldp);

			/// <summary>Gets an image list statistics structure.</summary>
			/// <returns>A pointer to the IMAGELISTSTATS structure.</returns>
			IMAGELISTSTATS GetStatistics();

			/// <summary>Initializes an image list.</summary>
			/// <param name="cx">Width, in pixels, of each image.</param>
			/// <param name="cy">Height, in pixels, of each image.</param>
			/// <param name="flags">A combination of Image List Creation Flags.</param>
			/// <param name="cInitial">Number of images that the image list initially contains.</param>
			/// <param name="cGrow">Number of new images that the image list can contain.</param>
			void Initialize(int cx, int cy, uint flags, int cInitial, int cGrow);

			/// <summary>Replaces an image in an image list.</summary>
			/// <param name="i">The index of the image to replace.</param>
			/// <param name="hbmImage">A handle to the bitmap that contains the image.</param>
			/// <param name="hbmMask">A handle to the bitmap that contains the mask. If no mask is used with the image list, this parameter is ignored.</param>
			/// <param name="punk">A pointer to the IUnknown interface.</param>
			/// <param name="dwFlags">Specifies how the mask is applied to the image as one or a bitwise combination of the following decoration flags.</param>
			void Replace2(int i, IntPtr hbmImage, IntPtr hbmMask, [MarshalAs(UnmanagedType.IUnknown)] object punk, ILR dwFlags);

			/// <summary>Replaces an image in one image list with an image from another image list.</summary>
			/// <param name="i">The index of the destination image in the image list. This is the image that is overwritten by the new image.</param>
			/// <param name="pil">A pointer to the source image list.</param>
			/// <param name="iSrc">The index of the source image in the image list pointed to by pil.</param>
			/// <param name="punk">A pointer to the IUnknown interface.</param>
			/// <param name="dwFlags">Not used; must be 0.</param>
			void ReplaceFromImageList(int i, IImageList pil, int iSrc, [MarshalAs(UnmanagedType.IUnknown)] object punk, uint dwFlags = 0);
		}

		/// <summary>Get an image list interface from an image list handle.</summary>
		/// <param name="himl">
		/// <para>Type: <c>HIMAGELIST</c></para>
		/// <para>A handle to the image list to query.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>Reference to the desired interface ID.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>
		/// When this method returns, contains the interface pointer requested in riid. This is normally <c>IImageList2</c>, which provides the <c>Initialize</c> method.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h")]
		public static extern HRESULT HIMAGELIST_QueryInterface(IntPtr himl, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		/// <summary>Get an image list interface from an image list handle.</summary>
		/// <param name="himl">
		/// <para>Type: <c>HIMAGELIST</c></para>
		/// <para>A handle to the image list to query.</para>
		/// </param>
		/// <returns>
		/// When this method returns, contains the interface pointer requested. This is normally <c>IImageList2</c>, which provides the <c>Initialize</c> method.
		/// </returns>
		[PInvokeData("Commctrl.h")]
		public static TIntf HIMAGELIST_QueryInterface<TIntf>(IntPtr himl)
		{
			if (himl == IntPtr.Zero) throw new ArgumentNullException(nameof(himl));
			return (TIntf)Marshal.GetTypedObjectForIUnknown(himl, typeof(TIntf));
		}

		/// <summary>Get an image list handle from an image list interface.</summary>
		/// <param name="himl">
		/// <para>Type: <c>HIMAGELIST</c></para>
		/// <para>An IImageList object.</para>
		/// </param>
		/// <returns>An image list handle.</returns>
		public static IntPtr IImageListToHIMAGELIST(IImageList himl) => Marshal.GetIUnknownForObject(himl);

		/// <summary>Creates a single instance of an imagelist and returns an interface pointer to it.</summary>
		/// <param name="rclsid">
		/// <para>Type: <c>REFCLSID</c></para>
		/// <para>A reference to the CLSID—a GUID that identifies the COM object to be created. This should be <c>CLSID_ImageList</c>.</para>
		/// </param>
		/// <param name="punkOuter">
		/// <para>Type: <c>const <c>IUnknown</c>*</c></para>
		/// <para>
		/// A pointer to the outer <c>IUnknown</c> interface that aggregates the object created by this function, or <c>NULL</c> if no aggregation is desired.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>Reference to the desired interface ID.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>
		/// When this method returns, contains the interface pointer requested in riid. This is normally <c>IImageList2</c>, which provides the <c>Initialize</c> method.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT ImageList_CoCreateInstance( _In_ REFCLSID rclsid, _In_opt_ const IUnknown *punkOuter, _In_ REFIID riid, _Out_ void **ppv);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761518(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("CommonControls.h", MSDNShortId = "bb761518")]
		public static extern HRESULT ImageList_CoCreateInstance([MarshalAs(UnmanagedType.LPStruct)] Guid rclsid, [MarshalAs(UnmanagedType.IUnknown)] object punkOuter, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		/// <summary>Creates a new image list.</summary>
		/// <param name="cx">
		/// <para>Type: <c>int</c></para>
		/// <para>The width, in pixels, of each image.</para>
		/// </param>
		/// <param name="cy">
		/// <para>Type: <c>int</c></para>
		/// <para>The height, in pixels, of each image.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c><c>UINT</c></c></para>
		/// <para>A set of bit flags that specify the type of image list to create. This parameter can be a combination of the <c>Image List Creation Flags</c>.</para>
		/// </param>
		/// <param name="cInitial">
		/// <para>Type: <c>int</c></para>
		/// <para>The number of images that the image list initially contains.</para>
		/// </param>
		/// <param name="cGrow">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The number of images by which the image list can grow when the system needs to make room for new images. This parameter represents the number of new
		/// images that the resized image list can contain.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HIMAGELIST</c></para>
		/// <para>Returns the handle to the image list if successful, or <c>NULL</c> otherwise.</para>
		/// </returns>
		// HIMAGELIST ImageList_Create( int cx, int cy, UINT flags, int cInitial, int cGrow);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761522(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761522")]
		public static extern SafeImageListHandle ImageList_Create(int cx, int cy, ILC flags, int cInitial, int cGrow);

		/// <summary>Destroys an image list.</summary>
		/// <param name="himl">
		/// <para>Type: <c>HIMAGELIST</c></para>
		/// <para>A handle to the image list to destroy.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>BOOL</c></c></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </returns>
		// BOOL ImageList_Destroy( _In_opt_ HIMAGELIST himl);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761524(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761524")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ImageList_Destroy(IntPtr himl);

		/// <summary>Creates a duplicate of an existing image list.</summary><param name="himl"><para>Type: <c>HIMAGELIST</c></para><para>A handle to the image list to be duplicated. All information contained in the original image list for normal images is copied to the new image list. Overlay images are not copied.</para></param><returns><para>Type: <c>HIMAGELIST</c></para><para>Returns the handle to the new duplicate image list if successful, or <c>NULL</c> otherwise.</para></returns>
		// HIMAGELIST ImageList_Duplicate( HIMAGELIST himl);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761540(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761540")]
		public static extern IntPtr ImageList_Duplicate(IntPtr himl);

		/// <summary>Creates an icon from an image and mask in an image list.</summary>
		/// <param name="himl">
		/// <para>Type: <c>HIMAGELIST</c></para>
		/// <para>A handle to the image list.</para>
		/// </param>
		/// <param name="i">
		/// <para>Type: <c>int</c></para>
		/// <para>An index of the image.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c><c>UINT</c></c></para>
		/// <para>
		/// A combination of flags that specify the drawing style. For a list of values, see the description of the fStyle parameter of the <c>ImageList_Draw</c> function.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HICON</c></c></para>
		/// <para>Returns the handle to the icon if successful, or <c>NULL</c> otherwise.</para>
		/// </returns>
		// HICON ImageList_GetIcon( HIMAGELIST himl, int i, UINT flags);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761548(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761548")]
		public static extern IntPtr ImageList_GetIcon(IntPtr himl, int i, IMAGELISTDRAWFLAGS flags);

		/// <summary>Creates an image list from the specified bitmap.</summary><param name="hi"><para>Type: <c><c>HINSTANCE</c></c></para><para>A handle to the instance that contains the resource. This parameter can be <c>NULL</c> if you are loading an image from a file or loading an OEM resource.</para></param><param name="lpbmp"><para>Type: <c><c>LPCTSTR</c></c></para><para>The image to load.</para><para>If the uFlags parameter includes LR_LOADFROMFILE, lpbmp is the address of a null-terminated string that names the file containing the image to load.</para><para>If the hi parameter is non-<c>NULL</c> and LR_LOADFROMFILE is not specified, lpbmp is the address of a null-terminated string that contains the name of the image resource in the hi module.</para><para>If hi is <c>NULL</c> and LR_LOADFROMFILE is not specified, the <c>LOWORD</c> of this parameter must be the identifier of an OEM image to load. To create this value, use the <c>MAKEINTRESOURCE</c> macro with one of the OEM image identifiers defined in Winuser.h. These identifiers have the following prefixes.</para><para><list type="table"><listheader><term>Value</term><term>Meaning</term></listheader><item><term>OBM_ for OEM bitmaps</term><term /></item><item><term>OIC_ for OEM icons</term><term /></item><item><term>OCR_ for OEM cursors</term><term /></item></list></para></param><param name="cx"><para>Type: <c>int</c></para><para>The width of each image. The height of each image and the initial number of images are inferred by the dimensions of the specified resource.</para></param><param name="cGrow"><para>Type: <c>int</c></para><para>The number of images by which the image list can grow when the system needs to make room for new images. This parameter represents the number of new images that the resized image list can contain.</para></param><param name="crMask"><para>Type: <c><c>COLORREF</c></c></para><para>The color used to generate a mask. Each pixel of this color in the specified bitmap, cursor, or icon is changed to black, and the corresponding bit in the mask is set to 1. If this parameter is the CLR_NONE value, no mask is generated. If this parameter is the CLR_DEFAULT value, the color of the pixel at the upper-left corner of the image is treated as the mask color.</para></param><param name="uType"><para>Type: <c><c>UINT</c></c></para><para>A flag that specifies the type of image to load. This parameter must be IMAGE_BITMAP to indicate that a bitmap is being loaded.</para><para><list type="table"><listheader><term>Value</term><term>Meaning</term></listheader><item><term>IMAGE_BITMAP</term><term>Loads a bitmap.</term></item></list></para></param><param name="uFlags"><para>Type: <c><c>UINT</c></c></para><para>Flags that specify how to load the image. This parameter can be a combination of the following values.</para><para><list type="table"><listheader><term>Value</term><term>Meaning</term></listheader><item><term>LR_CREATEDIBSECTION</term><term>Causes the function to return a DIB section bitmap rather than a compatible bitmap when the uType parameter specifies IMAGE_BITMAP. LR_CREATEDIBSECTION is useful for loading a bitmap without mapping it to the colors of the display device.</term></item><item><term>LR_DEFAULTCOLOR</term><term>Uses the color format of the display.</term></item><item><term>LR_DEFAULTSIZE</term><term>Uses the width or height specified by the system metric values for cursors and icons if the cx parameter is set to zero. If this value is not specified and cx is set to zero, the function sets the size to the one specified in the resource. If the resource contains multiple images, the function sets the size to that of the first image. </term></item><item><term>LR_LOADFROMFILE</term><term>Loads the image from the file specified by the lpbmp parameter.</term></item><item><term>LR_LOADMAP3DCOLORS</term><term>Searches the color table for the image and replaces the following shades of gray with the corresponding three-dimensional color: Dk Gray: RGB(128, 128, 128)COLOR_3DSHADOW Gray: RGB(192, 192, 192)COLOR_3DFACE Lt Gray: RGB(223, 223, 223)COLOR_3DLIGHT For more information, see the Remarks section.</term></item><item><term>LR_LOADTRANSPARENT</term><term>Retrieves the color value of the first pixel in the image and replaces the corresponding entry in the color table with the default window color (the COLOR_WINDOW display color). All pixels in the image that use that color become the default window value color. This value applies only to images that have a corresponding color table. For more information, see the Remarks section.</term></item><item><term>LR_MONOCHROME</term><term>Loads the image in black and white.</term></item><item><term>LR_SHARED</term><term>Shares the image handle if the image is loaded multiple times. Do not use this value for images that have nontraditional sizes that might change after loading or for images that are loaded from a file. </term></item></list></para></param><returns><para>Type: <c>HIMAGELIST</c></para><para>Returns the handle to the image list if successful, or <c>NULL</c> otherwise.</para></returns>
		// HIMAGELIST ImageList_LoadImage( HINSTANCE hi, LPCTSTR lpbmp, int cx, int cGrow, COLORREF crMask, UINT uType, UINT uFlags);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761557(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761557")]
		public static extern SafeImageListHandle ImageList_LoadImage(SafeLibraryHandle hi, string lpbmp, int cx, int cGrow, COLORREF crMask, LoadImageType uType, LoadImageOptions uFlags);

		/// <summary>Reads an image list from a stream.</summary><param name="pstm"><para>Type: <c>LPSTREAM</c></para><para>A pointer to the stream.</para></param><returns><para>Type: <c>HIMAGELIST</c></para><para>Returns the handle to the image list if successful, or <c>NULL</c> otherwise.</para></returns>
		// HIMAGELIST ImageList_Read( LPSTREAM pstm);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761560(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761560")]
		public static extern SafeImageListHandle ImageList_Read(IStream pstm);

		/// <summary>Reads an image list from a stream, and returns an <c>IImageList</c> interface to the image list.</summary>
		/// <param name="dwFlags">
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>A flag that specifies how the stream is read.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ILP_NORMAL</term>
		/// <term>Expects an image list that was written with the ILP_NORMAL flag specified.</term>
		/// </item>
		/// <item>
		/// <term>ILP_DOWNLEVEL</term>
		/// <term>Expects an image list that was written with the ILP_DOWNLEVEL flag specified.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="pstm">
		/// <para>Type: <c>LPSTREAM</c></para>
		/// <para>The address of the stream.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>An IID for the image list.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>The address of a pointer to the interface for the image list if successful, <c>NULL</c> otherwise.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT ImageList_ReadEx( _In_ DWORD dwFlags, _In_ LPSTREAM pstm, _Out_ REFIID riid, _Out_ void **ppv);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761562(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761562")]
		public static extern void ImageList_ReadEx(ILP dwFlags, IStream pstm, out Guid riid, [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		/// <summary>Writes an image list to a stream.</summary>
		/// <param name="himl">
		/// <para>Type: <c>HIMAGELIST</c></para>
		/// <para>A handle to the image list.</para>
		/// </param>
		/// <param name="pstm">
		/// <para>Type: <c>LPSTREAM</c></para>
		/// <para>A pointer to the stream.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>BOOL</c></c></para>
		/// <para>Returns nonzero if successful, or zero otherwise.</para>
		/// </returns>
		// BOOL ImageList_Write( HIMAGELIST himl, LPSTREAM pstm);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb775228(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775228")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ImageList_Write(IntPtr himl, IStream pstm);

		/// <summary>Writes an image list to a stream.</summary>
		/// <param name="himl">
		/// <para>Type: <c>HIMAGELIST</c></para>
		/// <para>A handle to the image list.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>A flag that specifies how the stream is written.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ILP_NORMAL</term>
		/// <term>Writes to the stream using the file format for Common Controls 6.0, which includes information about image list attributes new to this version.</term>
		/// </item>
		/// <item>
		/// <term>ILP_DOWNLEVEL</term>
		/// <term>
		/// Writes to the stream using a file format previous to version 6.0. Specify this flag if you need to save image lists loaded under Common Controls
		/// versions earlier than version 6.0.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="pstm">
		/// <para>Type: <c>LPSTREAM</c></para>
		/// <para>The address of the stream.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT ImageList_WriteEx( _In_ HIMAGELIST himl, _In_ DWORD dwFlags, _In_ LPSTREAM pstm);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb775229(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775229")]
		public static extern HRESULT ImageList_WriteEx(IntPtr himl, ILP dwFlags, IStream pstm);

		/// <summary>Prepares the index of an overlay mask so that the <c>ImageList_Draw</c> function can use it.</summary>
		/// <param name="iOverlay">
		/// <para>Type: <c><c>UINT</c></c></para>
		/// <para>An index of an overlay mask.</para>
		/// </param>
		/// <returns>No return value.</returns>
		// UINT INDEXTOOVERLAYMASK( UINT iOverlay);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761408(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761408")]
		public static int INDEXTOOVERLAYMASK(int iOverlay) => iOverlay << 8;

		/// <summary>Contains information about an image in an image list. This structure is used with the IImageList::GetImageInfo function.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761393")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IMAGEINFO
		{
			/// <summary>A handle to the bitmap that contains the images.</summary>
			public IntPtr hbmImage;
			/// <summary>
			/// A handle to a monochrome bitmap that contains the masks for the images. If the image list does not contain a mask, this member is NULL.
			/// </summary>
			public IntPtr hbmMask;
			/// <summary>Not used. This member should always be zero.</summary>
			public int Unused1;
			/// <summary>Not used. This member should always be zero.</summary>
			public int Unused2;
			/// <summary>The bounding rectangle of the specified image within the bitmap specified by hbmImage.</summary>
			public RECT rcImage;
		}

		/// <summary>Contains image list statistics. Used by <c>GetStatistics</c>.</summary>
		// typedef struct tagIMAGELISTSTATS { DWORD cbSize; int cAlloc; int cUsed; int cStandby;} IMAGELISTSTATS;
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761397(v=vs.85).aspx
		[PInvokeData("Commoncontrols.h", MSDNShortId = "bb761397")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IMAGELISTSTATS
		{
			/// <summary>
			/// <para>Type: <c><c>DWORD</c></c></para>
			/// <para>The image list size.</para>
			/// </summary>
			public uint cbSize;
			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>The number of images allocated.</para>
			/// </summary>
			public int cAlloc;
			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>The number of images in use.</para>
			/// </summary>
			public int cUsed;
			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>The number of standby images.</para>
			/// </summary>
			public int cStandby;
		}

		/// <summary>Image list class.</summary>
		[ComImport, Guid("7C476BA2-02B1-48f4-8048-B24619DDC058"), ClassInterface(ClassInterfaceType.None)]
		[PInvokeData("CommonControls.h")]
		public class CImageList { }

		/// <summary>Contains information about an image list draw operation and is used with the <c>IImageList::Draw</c> function.</summary>
		// typedef struct _IMAGELISTDRAWPARAMS { DWORD cbSize; HIMAGELIST himl; int i; HDC hdcDst; int x; int y; int cx; int cy; int xBitmap; int yBitmap; COLORREF rgbBk; COLORREF rgbFg; UINT fStyle; DWORD dwRop; DWORD fState; DWORD Frame; DWORD crEffect;} IMAGELISTDRAWPARAMS;
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761395(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761395")]
		[StructLayout(LayoutKind.Sequential)]
		public class IMAGELISTDRAWPARAMS
		{
			/// <summary>The size of this structure, in bytes.</summary>
			public int cbSize;
			/// <summary>A handle to the image list that contains the image to be drawn.</summary>
			public IntPtr himl;
			/// <summary>The zero-based index of the image to be drawn.</summary>
			public int i;
			/// <summary>A handle to the destination device context.</summary>
			public IntPtr hdcDst;
			/// <summary>The x-coordinate that specifies where the image is drawn.</summary>
			public int x;
			/// <summary>The y-coordinate that specifies where the image is drawn.</summary>
			public int y;
			/// <summary>
			/// A value that specifies the number of pixels to draw, relative to the upper-left corner of the drawing operation as specified by xBitmap and
			/// yBitmap. If cx and cy are zero, then Draw draws the entire valid section. The method does not ensure that the parameters are valid.
			/// </summary>
			public int cx;
			/// <summary>
			/// A value that specifies the number of pixels to draw, relative to the upper-left corner of the drawing operation as specified by xBitmap and
			/// yBitmap. If cx and cy are zero, then Draw draws the entire valid section. The method does not ensure that the parameters are valid.
			/// </summary>
			public int cy;
			/// <summary>
			/// The x-coordinate that specifies the upper-left corner of the drawing operation in reference to the image itself. Pixels of the image that are to
			/// the left of xBitmap and above yBitmap do not appear.
			/// </summary>
			public int xBitmap;
			/// <summary>
			/// The y-coordinate that specifies the upper-left corner of the drawing operation in reference to the image itself. Pixels of the image that are to
			/// the left of xBitmap and above yBitmap do not appear.
			/// </summary>
			public int yBitmap;
			/// <summary>The image background color. This parameter can be an application-defined RGB value or <see cref="CLR_DEFAULT"/> or <see cref="CLR_NONE"/>.</summary>
			public COLORREF rgbBk;
			/// <summary>
			/// The image foreground color. This member is used only if fStyle includes the ILD_BLEND25 or ILD_BLEND50 flag. This parameter can be an
			/// application-defined RGB value or <see cref="CLR_DEFAULT"/> or <see cref="CLR_NONE"/>.
			/// </summary>
			public COLORREF rgbFg;
			/// <summary>
			/// A flag specifying the drawing style and, optionally, the overlay image. See the comments section at the end of this topic for information on the
			/// overlay image. This member can contain one or more image list drawing flags.
			/// </summary>
			public IMAGELISTDRAWFLAGS fStyle;
			/// <summary>
			/// A value specifying a raster operation code. These codes define how the color data for the source rectangle will be combined with the color data
			/// for the destination rectangle to achieve the final color. This member is ignored if fStyle does not include the ILD_ROP flag.
			/// </summary>
			public RasterOperationMode dwRop;
			/// <summary>
			/// A flag that specifies the drawing state. This member can contain one or more image list state flags. You must use comctl32.dll version 6 to use
			/// this member.
			/// </summary>
			public IMAGELISTSTATEFLAGS fState;
			/// <summary>
			/// Used with the alpha blending effect.
			/// <para>
			/// When used with ILS_ALPHA, this member holds the value for the alpha channel. This value can be from 0 to 255, with 0 being completely
			/// transparent, and 255 being completely opaque.
			/// </para>
			/// <para>You must use comctl32.dll version 6 to use this member. See the Remarks.</para>
			/// </summary>
			public uint Frame;
			/// <summary>A color used for the glow and shadow effects. You must use comctl32.dll version 6 to use this member. See the Remarks.</summary>
			public COLORREF crEffect;

			/// <summary>Initializes a new instance of the <see cref="IMAGELISTDRAWPARAMS"/> class.</summary>
			public IMAGELISTDRAWPARAMS() { cbSize = Marshal.SizeOf(this); }

			/// <summary>Initializes a new instance of the <see cref="IMAGELISTDRAWPARAMS"/> class.</summary>
			/// <param name="hdcDst">A handle to the destination device context.</param>
			/// <param name="bounds">The bounds that specifiy where the image is drawn.</param>
			/// <param name="index">The zero-based index of the image to be drawn.</param>
			/// <param name="bgColor">The image background color.</param>
			/// <param name="style">A flag specifying the drawing style and, optionally, the overlay image.</param>
			public IMAGELISTDRAWPARAMS(IntPtr hdcDst, RECT bounds, int index, COLORREF bgColor, IMAGELISTDRAWFLAGS style = IMAGELISTDRAWFLAGS.ILD_NORMAL) : this()
			{
				i = index;
				this.hdcDst = hdcDst;
				x = bounds.X;
				y = bounds.Y;
				cx = bounds.Width;
				cy = bounds.Height;
				rgbBk = bgColor;
				fStyle = style;
			}
		}

		/// <summary>Safe image list handle. Be aware that if this is instantiated with ownership of the handle, it will be destroyed on disposal.</summary>
		/// <seealso cref="Vanara.InteropServices.GenericSafeHandle"/>
		public class SafeImageListHandle : GenericSafeHandle
		{
			private IImageList iImageList;

			/// <summary>Initializes a new instance of the <see cref="SafeImageListHandle"/> class.</summary>
			public SafeImageListHandle() : this(IntPtr.Zero) { }
			/// <summary>Initializes a new instance of the <see cref="SafeImageListHandle"/> class.</summary>
			/// <param name="handle">The handle.</param>
			/// <param name="owns">if set to <c>true</c> the handle will be destroyed on disposal.</param>
			public SafeImageListHandle(IntPtr handle, bool owns = true) : base(handle, ImageList_Destroy, owns) { }
			/// <summary>Initializes a new instance of the <see cref="SafeImageListHandle"/> class.</summary>
			/// <param name="iil">An IImageList object.</param>
			public SafeImageListHandle(IImageList iil) : this(ImageList_Duplicate(IImageListToHIMAGELIST(iil)), true) { }

			/// <summary>Gets the IImageList interface for this handle.</summary>
			/// <value>The interface.</value>
			public IImageList Interface => iImageList ?? (iImageList = HIMAGELIST_QueryInterface<IImageList>(handle));
		}
	}
}