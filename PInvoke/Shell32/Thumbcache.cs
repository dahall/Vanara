using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
    public static partial class Shell32
	{
        /// <summary>Alpha channel type information.</summary>
        public enum WTS_ALPHATYPE
        {
            /// <summary>The bitmap is an unknown format. The Shell tries nonetheless to detect whether the image has an alpha channel.</summary>
            WTSAT_UNKNOWN = 0x0,
            /// <summary>The bitmap is an RGB image without alpha. The alpha channel is invalid and the Shell ignores it.</summary>
            WTSAT_RGB = 0x1,
            /// <summary>The bitmap is an ARGB image with a valid alpha channel.</summary>
            WTSAT_ARGB = 0x2
        }

        /// <summary>Exposes a method for getting a thumbnail image.</summary>
        [ComImport, Guid("e357fccd-a995-4576-b01f-234630154e96"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IThumbnailProvider
        {
            /// <summary>Gets a thumbnail image and alpha type.</summary>
            /// <param name="cx">
            /// The maximum thumbnail size, in pixels. The Shell draws the returned bitmap at this size or smaller. The returned bitmap should fit into a square
            /// of width and height cx, though it does not need to be a square image. The Shell scales the bitmap to render at lower sizes. For example, if the
            /// image has a 6:4 aspect ratio, then the returned bitmap should also have a 6:4 aspect ratio.
            /// </param>
            /// <param name="phbmp">
            /// When this method returns, contains a pointer to the thumbnail image handle. The image must be a DIB section and 32 bits per pixel. The Shell
            /// scales down the bitmap if its width or height is larger than the size specified by cx. The Shell always respects the aspect ratio and never
            /// scales a bitmap larger than its original size.
            /// </param>
            /// <param name="pdwAlpha">When this method returns, contains a pointer to one of the following values from the WTS_ALPHATYPE enumeration.</param>
            /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
            void GetThumbnail(uint cx, out IntPtr phbmp, out WTS_ALPHATYPE pdwAlpha);
        }
    }
}