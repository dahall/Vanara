using System;
using System.Drawing;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Gdi32;

// ReSharper disable FieldCanBeMadeReadOnly.Global ReSharper disable InconsistentNaming ReSharper disable FieldCanBeMadeReadOnly.Global

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
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

		[PInvokeData("Commctrl.h", MSDNShortId = "bb761486")]
		public enum IMAGELISTITEMFLAG
		{
			/// <summary>Indicates that the item in the imagelist has an alpha channel.</summary>
			ILIF_ALPHA = 1,
			/// <summary>Windows Vista and later. Indicates that the item in the imagelist was generated via a StretchBlt function, consequently image quality may have degraded.</summary>
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

		/// <summary>
		/// Draws an image list item In the specified device context. The function uses the specified drawing style and blends the image with the specified color.
		/// </summary>
		/// <param name="himl">A handle to the image list</param>
		/// <param name="i">The index of the image to draw.</param>
		/// <param name="hdcDst">A handle to the destination device context.</param>
		/// <param name="x">The x-coordinate at which to draw within the specified device context.</param>
		/// <param name="y">The y-coordinate at which to draw within the specified device context.</param>
		/// <param name="dx">
		/// The width of the portion of the image to draw relative to the upper-left corner of the image. If dx and dy are zero, the function draws the entire
		/// image. The function does not ensure that the parameters are valid.
		/// </param>
		/// <param name="dy">
		/// The height of the portion of the image to draw, relative to the upper-left corner of the image. If dx and dy are zero, the function draws the entire
		/// image. The function does not ensure that the parameters are valid.
		/// </param>
		/// <param name="rgbBk">
		/// The background color of the image. This parameter can be an application-defined RGB value or one of the following
		/// values: <see cref="CLR_NONE"/> or <see cref="CLR_DEFAULT"/>.
		/// </param>
		/// <param name="rgbFg">
		/// The foreground color of the image. This parameter can be an application-defined RGB value or one of the following
		/// values: <see cref="CLR_NONE"/> or <see cref="CLR_DEFAULT"/>.
		/// </param>
		/// <param name="fStyle">
		/// The drawing style and, optionally, the overlay image. For information about specifying an overlay image index, see the comments section at the end of
		/// this topic. This parameter can be a combination of an overlay image index and one or more of the <see cref="IMAGELISTDRAWFLAGS"/> values.
		/// </param>
		/// <returns>Returns nonzero if successful, or zero otherwise.</returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761536")]
		[DllImport(Lib.ComCtl32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ImageList_DrawEx(HandleRef himl, int i, SafeDCHandle hdcDst, int x, int y, int dx, int dy,
			uint rgbBk, uint rgbFg, IMAGELISTDRAWFLAGS fStyle);

		/// <summary>Creates an icon from an image and mask in an image list.</summary>
		/// <param name="himl">A handle to the image list.</param>
		/// <param name="i">An index of the image.</param>
		/// <param name="flags">A combination of flags that specify the drawing style.</param>
		/// <returns>Returns the handle to the icon if successful, or NULL otherwise.</returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761548")]
		[DllImport(Lib.ComCtl32, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr ImageList_GetIcon(IntPtr himl, int i, IMAGELISTDRAWFLAGS flags);

		/// <summary>
		/// Adds a specified image to the list of images to be used as overlay masks. An image list can have up to four overlay masks In version 4.70 and earlier
		/// and up to 15 In version 4.71. The function assigns an overlay mask index to the specified image.
		/// </summary>
		/// <param name="himl">A handle to the image list</param>
		/// <param name="iImage">The zero-based index of an image In the himl image list. This index identifies the image to use as an overlay mask.</param>
		/// <param name="iOverlay">The one-based index of the overlay mask.</param>
		/// <returns>Returns nonzero if successful, or zero otherwise.</returns>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775227")]
		[DllImport(Lib.ComCtl32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ImageList_SetOverlayImage(HandleRef himl, int iImage, int iOverlay);

		/// <summary>Exposes methods that manipulate and interact with image lists.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb761490")]
		[ComImport, Guid("46EB5926-582E-4017-9FDF-E8998DAA0950"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IImageList
		{
			/// <summary>Adds an image or images to an image list.</summary>
			/// <param name="hbmImage">A handle to the bitmap that contains the image or images. The number of images is inferred from the width of the bitmap.</param>
			/// <param name="hbmMask">A handle to the bitmap that contains the mask. If no mask is used with the image list, this parameter is ignored.</param>
			/// <returns>When this method returns, contains a pointer to the index of the first new image. If the method fails to successfully add the new image, this value is -1.</returns>
			int Add(IntPtr hbmImage, [Optional] IntPtr hbmMask);
			/// <summary>Replaces an image with an icon or cursor.</summary>
			/// <param name="i">A value of type int that contains the index of the image to replace. If i is -1, the function adds the image to the end of the list.</param>
			/// <param name="hicon">A handle to the icon or cursor that contains the bitmap and mask for the new image.</param>
			/// <returns>A pointer to an int that will contain the index of the image on return if successful, or -1 otherwise.</returns>
			int ReplaceIcon(int i, IntPtr hicon);
			/// <summary>Adds a specified image to the list of images used as overlay masks. An image list can have up to four overlay masks in Common Controls version 4.70 and earlier, and up to 15 in version 4.71 or later. The method assigns an overlay mask index to the specified image.</summary>
			/// <param name="iImage">A value of type int that contains the zero-based index of an image in the image list. This index identifies the image to use as an overlay mask.</param>
			/// <param name="iOverlay">A value of type int that contains the one-based index of the overlay mask.</param>
			void SetOverlayImage(int iImage, int iOverlay);
			/// <summary>Replaces an image in an image list with a new image.</summary>
			/// <param name="i">A value of type int that contains the index of the image to replace.</param>
			/// <param name="hbmImage">A handle to the bitmap that contains the image.</param>
			/// <param name="hbmMask">A handle to the bitmap that contains the mask. If no mask is used with the image list, this parameter is ignored.</param>
			void Replace(int i, IntPtr hbmImage, [Optional] IntPtr hbmMask);
			/// <summary>Adds an image or images to an image list, generating a mask from the specified bitmap.</summary>
			/// <param name="hbmImage">A handle to the bitmap that contains one or more images. The number of images is inferred from the width of the bitmap.</param>
			/// <param name="crMask">The color used to generate the mask. Each pixel of this color in the specified bitmap is changed to black, and the corresponding bit in the mask is set to 1.</param>
			/// <returns>A pointer to an int that contains the index of the first new image when it returns, if successful, or -1 otherwise.</returns>
			int AddMasked(IntPtr hbmImage, uint crMask);
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
			/// <returns>A pointer to an IMAGEINFO structure that receives information about the image. The information in this structure can directly manipulate the bitmaps of the image.</returns>
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
			/// <param name="cx">A value of type int that contains the width, in pixels, of the images in the image list. All images in an image list have the same dimensions.</param>
			/// <param name="cy">A value of type int that contains the height, in pixels, of the images in the image list. All images in an image list have the same dimensions.</param>
			void SetIconSize(int cx, int cy);
			/// <summary>Gets the number of images in an image list.</summary>
			/// <returns>A pointer to an int that contains the number of images when the method returns.</returns>
			int GetImageCount();
			/// <summary>Resizes an existing image list.</summary>
			/// <param name="uNewCount">A value that specifies the new size of the image list.</param>
			void SetImageCount(int uNewCount);
			/// <summary>Sets the background color for an image list. This method only functions if you add an icon to the image list or use the IImageList::AddMasked method to add a black and white bitmap. Without a mask, the entire image draws, and the background color is not visible.</summary>
			/// <param name="clrBk">The background color to set. If this parameter is set to CLR_NONE, then images draw transparently using the mask.</param>
			/// <param name="pclr">A pointer to a COLORREF that contains the previous background color on return if successful, or CLR_NONE otherwise.</param>
			void SetBkColor(uint clrBk, ref uint pclr);
			/// <summary>Gets the current background color for an image list.</summary>
			/// <returns>A pointer to a COLORREF that contains the background color when the method returns.</returns>
			uint GetBkColor();
			/// <summary>Begins dragging an image.</summary>
			/// <param name="iTrack">A value of type int that contains the index of the image to drag.</param>
			/// <param name="dxHotspot">A value of type int that contains the x-component of the drag position relative to the upper-left corner of the image.</param>
			/// <param name="dyHotspot">A value of type int that contains the y-component of the drag position relative to the upper-left corner of the image.</param>
			void BeginDrag(int iTrack, int dxHotspot, int dyHotspot);
			/// <summary>Ends a drag operation.</summary>
			void EndDrag();
			/// <summary>Locks updates to the specified window during a drag operation and displays the drag image at the specified position within the window.</summary>
			/// <param name="hwndLock">A handle to the window that owns the drag image.</param>
			/// <param name="x">The x-coordinate at which to display the drag image. The coordinate is relative to the upper-left corner of the window, not the client area.</param>
			/// <param name="y">The y-coordinate at which to display the drag image. The coordinate is relative to the upper-left corner of the window, not the client area.</param>
			void DragEnter(HandleRef hwndLock, int x, int y);
			/// <summary>Unlocks the specified window and hides the drag image, which enables the window to update.</summary>
			/// <param name="hwndLock">A handle to the window that contains the drag image.</param>
			void DragLeave(HandleRef hwndLock);
			/// <summary>Moves the image that is being dragged during a drag-and-drop operation. This function is typically called in response to a WM_MOUSEMOVE message.</summary>
			/// <param name="x">A value of type int that contains the x-coordinate where the drag image appears. The coordinate is relative to the upper-left corner of the window, not the client area.</param>
			/// <param name="y">A value of type int that contains the y-coordinate where the drag image appears. The coordinate is relative to the upper-left corner of the window, not the client area.</param>
			void DragMove(int x, int y);
			/// <summary>Creates a new drag image by combining the specified image, which is typically a mouse cursor image, with the current drag image.</summary>
			/// <param name="punk">A pointer to the IUnknown interface that accesses the image list interface, which contains the new image to combine with the drag image.</param>
			/// <param name="iDrag">A value of type int that contains the index of the new image to combine with the drag image.</param>
			/// <param name="dxHotspot">A value of type int that contains the x-component of the hot spot within the new image.</param>
			/// <param name="dyHotspot">A value of type int that contains the x-component of the hot spot within the new image.</param>
			void SetDragCursorImage(IImageList punk, int iDrag, int dxHotspot, int dyHotspot);
			/// <summary>Shows or hides the image being dragged.</summary>
			/// <param name="fShow">A value that specifies whether to show or hide the image being dragged. Specify TRUE to show the image or FALSE to hide the image.</param>
			void DragShowNolock([MarshalAs(UnmanagedType.Bool)] bool fShow);
			/// <summary>Gets the temporary image list that is used for the drag image. The function also retrieves the current drag position and the offset of the drag image relative to the drag position.</summary>
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

		/// <summary>Contains information about an image list draw operation and is used with the IImageList::Draw function.</summary>
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
			public int rgbBk;
			/// <summary>
			/// The image foreground color. This member is used only if fStyle includes the ILD_BLEND25 or ILD_BLEND50 flag. This parameter can be an
			/// application-defined RGB value or <see cref="CLR_DEFAULT"/> or <see cref="CLR_NONE"/>.
			/// </summary>
			public int rgbFg;
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
			public int Frame;
			/// <summary>A color used for the glow and shadow effects. You must use comctl32.dll version 6 to use this member. See the Remarks.</summary>
			public int crEffect;
		}
	}
}