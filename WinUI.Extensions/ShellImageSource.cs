using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Vanara.Windows.Shell;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.Shell32.ShellUtil;
using System.IO;
using System.Windows.Media.Imaging;

namespace Vanara.PInvoke;

/*internal class ShellImageSource : BitmapSource
{
	public ShellImageSource(string path, System.Drawing.Size imageSize)
	{
		SHCreateItemFromParsingName(path, null, typeof(IShellItemImageFactory).GUID, out var ppv).ThrowIfFailed();
		((IShellItemImageFactory)ppv!).GetImage(imageSize, SIIGBF.SIIGBF_INCACHEONLY, out var hbmp).ThrowIfFailed();

		if (LoadImageFromImageFactory(path, ref imageSize, SIIGBF.SIIGBF_INCACHEONLY, out var hbmp).Succeeded && hbmp != null)
			if (cache.TryGetValue(path, out var bmp))
			Bitmap = bmp;
		bool? isDir = IsDirFile(path);

		
		var hico = ShellImageList.GetFileIcon(path, iconType) ?? ShellImageList.GetSystemIcon(path, iconType);
	}

	private static IShellItemImageFactory GetFactory(string path)
	{
		SHCreateItemFromParsingName(path, null, typeof(IShellItemImageFactory).GUID, out var ppv).ThrowIfFailed();
		return (IShellItemImageFactory)ppv!;
	}

	private static IShellItemImageFactory GetFactory(PIDL pidl)
	{
		SHCreateItemFromIDList(pidl, typeof(IShellItemImageFactory).GUID, out var ppv).ThrowIfFailed();
		return (IShellItemImageFactory)ppv!;
	}

	private static async Task<Bitmap> GetImageAsync(IShellItemImageFactory siif, System.Drawing.Size imageSize)
	{
		siif.GetImage(imageSize, SIIGBF.SIIGBF_INCACHEONLY, out var hbmp).ThrowIfFailed();

	}

	protected override Freezable CreateInstanceCore() => throw new NotImplementedException();
}*/