using System;
using System.Threading.Tasks;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.Shell32.ShellUtil;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Shell
{
	/// <summary>Exposes methods that get images related to shell items.</summary>
	public class ShellItemImages
	{
		private readonly ShellItem shellItem;

		/// <summary>Initializes a new instance of the <see cref="ShellItemImages"/> class.</summary>
		/// <param name="shellItem">The <see cref="ShellItem"/> instance.</param>
		public ShellItemImages(ShellItem shellItem) => this.shellItem = shellItem;

		/// <summary>
		/// Gets an image that represents this item. The default behavior is to load a thumbnail. If there is no thumbnail for the current
		/// item, it retrieves the icon of the item. The thumbnail or icon is extracted if it is not currently cached.
		/// </summary>
		/// <param name="size">A structure that specifies the size of the image to be received.</param>
		/// <param name="flags">One or more of the option flags.</param>
		/// <param name="forcePreVista">If set to <see langword="true"/>, ignore the use post vista interfaces like <see cref="IShellItemImageFactory"/>.</param>
		/// <returns>The resulting image.</returns>
		/// <exception cref="PlatformNotSupportedException"></exception>
		public async Task<SafeHBITMAP> GetImageAsync(SIZE size, ShellItemGetImageOptions flags = 0, bool forcePreVista = false) => await TaskAgg.Run(() =>
		{
			SafeHBITMAP hbmp = null;
			HRESULT hr = HRESULT.E_FAIL;
			var sz = (uint)size.Width;
			if (!forcePreVista && ShellItem.IsMinVista)
			{
				if (shellItem.IShellItem is IShellItemImageFactory fctry)
				{
					hr = fctry.GetImage(size, (SIIGBF)flags, out hbmp);
					if (hr == 0x8004B200 && flags.IsFlagSet(ShellItemGetImageOptions.ThumbnailOnly))
						throw new InvalidOperationException("Thumbnails are not supported by this item.");
					if (hr.Succeeded)
						return hbmp;
				}

				//hr = LoadImageFromThumbnailProvider(shellItem.IShellItem, ref sz, out hbmp);
			}

			// If before Vista, or if Vista interfaces failed, try using IExtractImage and IExtractIcon
			if (hr != HRESULT.S_OK && !flags.IsFlagSet(ShellItemGetImageOptions.IconOnly))
				hr = LoadImageFromExtractImage(shellItem.Parent.IShellFolder, shellItem.PIDL.LastId, ref sz, out hbmp);
			if (hr != HRESULT.S_OK)
			{
				if (!flags.IsFlagSet(ShellItemGetImageOptions.ThumbnailOnly))
				{
					LoadIconFromExtractIcon(shellItem.Parent.IShellFolder, shellItem.PIDL.LastId, ref sz, out SafeHICON hIcon).ThrowIfFailed();
					using (hIcon)
						hbmp = hIcon.ToHBITMAP();
				}
				else
				{
					throw hr.GetException();
				}
			}

			// If you got a bitmap, resize based on flags
			if (sz == size.Width || (sz > size.Width && flags.IsFlagSet(ShellItemGetImageOptions.BiggerSizeOk)))
				return hbmp;
			if ((sz > size.Width && flags.IsFlagSet(ShellItemGetImageOptions.ResizeToFit)) || (sz < size.Width && flags.IsFlagSet(ShellItemGetImageOptions.ScaleUp)))
			{
				HANDLE hbmpcp = CopyImage(hbmp.DangerousGetHandle(), LoadImageType.IMAGE_BITMAP, size.Width, size.Height, CopyImageOptions.LR_CREATEDIBSECTION);
				if (hbmpcp.IsNull) Win32Error.ThrowLastError();
				hbmp.Dispose();
				hbmp = new SafeHBITMAP((IntPtr)hbmpcp, true);
			}

			return hbmp;
		}, System.Threading.CancellationToken.None);
	}
}