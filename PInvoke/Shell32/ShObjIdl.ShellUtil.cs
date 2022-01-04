using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Text;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.User32;
using BIND_OPTS = System.Runtime.InteropServices.ComTypes.BIND_OPTS;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <remarks>Methods in this class will only work on Vista and above.</remarks>
		public static class ShellUtil
		{
			private const string REGSTR_PATH_METRICS = "Control Panel\\Desktop\\WindowMetrics";
			private static readonly Dictionary<SHIL, ushort> g_rgshil;
			private static readonly int SHIL_COUNT;

			static ShellUtil()
			{
				SHIL_COUNT = Enum.GetValues(typeof(SHIL)).Length;
				g_rgshil = new Dictionary<SHIL, ushort>(SHIL_COUNT); // new ushort[SHIL_COUNT];
				var sysCxIco = GetSystemMetrics(SystemMetric.SM_CXICON);
				g_rgshil[SHIL.SHIL_LARGE] = (ushort)(int)Microsoft.Win32.Registry.CurrentUser.GetValue($"{REGSTR_PATH_METRICS}\\Shell Icon Size", sysCxIco);
				g_rgshil[SHIL.SHIL_SMALL] = (ushort)(int)Microsoft.Win32.Registry.CurrentUser.GetValue($"{REGSTR_PATH_METRICS}\\Shell Small Icon Size", sysCxIco / 2);
				g_rgshil[SHIL.SHIL_EXTRALARGE] = (ushort)(3 * sysCxIco / 2);
				g_rgshil[SHIL.SHIL_SYSSMALL] = (ushort)GetSystemMetrics(SystemMetric.SM_CXSMICON);
				g_rgshil[SHIL.SHIL_JUMBO] = 256;
			}

			/// <summary>Wrapper for native <c>CreateBindCtx</c> and <c>SetBindOptions</c>.</summary>
			/// <param name="openMode">
			/// Represents flags that should be used when opening the file that contains the object identified by the moniker.
			/// </param>
			/// <param name="timeout">
			/// Indicates the amount of time (clock time in milliseconds) that the caller specified to complete the binding operation.
			/// </param>
			/// <param name="bindFlags">Flags that control aspects of moniker binding operations.</param>
			public static IBindCtx CreateBindCtx(STGM openMode = STGM.STGM_READWRITE, TimeSpan timeout = default, BIND_FLAGS bindFlags = 0)
			{
				Ole32.CreateBindCtx(0, out var ctx).ThrowIfFailed();
				if (openMode != STGM.STGM_READWRITE || timeout != TimeSpan.Zero || bindFlags != 0)
				{
					var opts = new BIND_OPTS { cbStruct = Marshal.SizeOf(typeof(BIND_OPTS)), grfMode = (int)openMode, dwTickCountDeadline = (int)timeout.TotalMilliseconds, grfFlags = (int)bindFlags };
					ctx.SetBindOptions(ref opts);
				}
				return ctx;
			}

			/// <summary>Gets the KNOWNFOLDERID enum from a KNOWNFOLDERID Guid.</summary>
			/// <param name="knownFolder">The KNOWNFOLDERID Guid.</param>
			/// <returns>The KNOWNFOLDERID enum.</returns>
			public static KNOWNFOLDERID GetKnownFolderFromGuid(Guid knownFolder) =>
				Enum.GetValues(typeof(KNOWNFOLDERID)).Cast<KNOWNFOLDERID>().Single(k => k.Guid() == knownFolder);

			/// <summary>Gets the KNOWNFOLDERID enum from a path.</summary>
			/// <param name="path">The folder path.</param>
			/// <returns>The KNOWNFOLDERID enum.</returns>
			public static KNOWNFOLDERID GetKnownFolderFromPath(string path)
			{
				if (Environment.OSVersion.Version.Major < 6)
					return Enum.GetValues(typeof(KNOWNFOLDERID)).Cast<KNOWNFOLDERID>().Single(k => string.Equals(k.FullPath(), path, StringComparison.InvariantCultureIgnoreCase));
				var ikfm = new IKnownFolderManager();
				return GetKnownFolderFromGuid(ikfm.FindFolderFromPath(path, FFFP_MODE.FFFP_EXACTMATCH).GetId());
			}

			/// <summary>Gets the parent and item for the supplied IShellItem regardless of support by IShellItem.</summary>
			/// <param name="psi">The IShellItem instance.</param>
			/// <returns>An IParentAndItem reference for the shell item.</returns>
			public static IParentAndItem GetParentAndItem(IShellItem psi) => psi is IParentAndItem pi ? pi : new ManualParentAndItem(psi);

			/// <summary>Gets the path for a KNOWNFOLDERID Guid.</summary>
			/// <param name="knownFolder">The KNOWNFOLDERID Guid.</param>
			/// <returns>The file system path.</returns>
			[SecurityCritical]
			public static string GetPathForKnownFolder(Guid knownFolder)
			{
				if (knownFolder == default)
					return null;

				var pathBuilder = new StringBuilder(260);
				if (SHGetFolderPathEx(knownFolder, 0, HTOKEN.NULL, pathBuilder, (uint)pathBuilder.Capacity).Failed)
					return null;
				return pathBuilder.ToString();
			}

			/// <summary>Gets the path from shell item.</summary>
			/// <param name="item">The shell item.</param>
			/// <returns>The file system path.</returns>
			[SecurityCritical]
			public static string GetPathFromShellItem(IShellItem item) => item.GetDisplayName(SIGDN.SIGDN_DESKTOPABSOLUTEEDITING);

			/// <summary>Gets the shell item for a file system path.</summary>
			/// <returns>The file system path.</returns>
			/// <returns>The corresponding IShellItem.</returns>
			[SecurityCritical]
			public static IShellItem GetShellItemForPath(string path)
			{
				if (string.IsNullOrEmpty(path))
					return null;

				// Handle case of a 'shell' URI and convert GUID to known folder
				//if (path.StartsWith("shell:::", StringComparison.InvariantCultureIgnoreCase))
				//{
				//	path = path.Substring(8);
				//	var separatorIndex = path.IndexOf('/');
				//	var kf = new Guid(separatorIndex == -1 ? path : path.Substring(0, separatorIndex));
				//	var fullPath = GetPathForKnownFolder(kf);
				//	if (separatorIndex != -1)
				//		fullPath += path.Substring(separatorIndex).Replace('/', '\\');
				//	path = fullPath;
				//}

				var hr = SHCreateItemFromParsingName(path, null, typeof(IShellItem).GUID, out var unk);
				if (hr == (HRESULT)Win32Error.ERROR_FILE_NOT_FOUND)
				{
					using var ibc = InteropServices.ComReleaserFactory.Create(CreateBindCtx());
					var bd = new IntFileSysBindData();
					ibc.Item.RegisterObjectParam(STR_FILE_SYS_BIND_DATA, bd);
					return SHCreateItemFromParsingName<IShellItem>(path, ibc.Item);
				}
				hr.ThrowIfFailed();
				return (IShellItem)unk;
			}

			/// <summary>Gets the icon for the item using the specified characteristics.</summary>
			/// <param name="psf">The IShellFolder from which to request the IExtractIcon instance.</param>
			/// <param name="pidl">The PIDL of the item within <paramref name="psf"/>.</param>
			/// <param name="imgSz">The width, in pixels, of the icon.</param>
			/// <param name="hico">The resulting icon handle, on success, or <c>null</c> on failure.</param>
			/// <returns>The result of function.</returns>
			public static HRESULT LoadIconFromExtractIcon(IShellFolder psf, PIDL pidl, ref uint imgSz, out SafeHICON hico)
			{
				hico = default;
				HRESULT hr = psf.GetUIObjectOf<IExtractIconW>((IntPtr)pidl, out var ieiw);
				if (hr.Succeeded)
				{
					try
					{
						return LoadIconFromExtractIcon(ieiw, ref imgSz, out hico);
					}
					finally
					{
						Marshal.ReleaseComObject(ieiw);
					}
				}
				else if ((hr = psf.GetUIObjectOf<IExtractIconA>((IntPtr)pidl, out var iei)).Succeeded)
				{
					try
					{
						return LoadIconFromExtractIcon(iei, ref imgSz, out hico);
					}
					finally
					{
						Marshal.ReleaseComObject(iei);
					}
				}
				return hr;
			}

			/// <summary>Gets the icon for the item using the specified characteristics.</summary>
			/// <param name="iei">The IExtractIconW from which to retrieve the icon.</param>
			/// <param name="imgSz">The width, in pixels, of the icon.</param>
			/// <param name="hico">The resulting icon handle, on success, or <c>null</c> on failure.</param>
			/// <returns>The result of function.</returns>
			public static HRESULT LoadIconFromExtractIcon(IExtractIconW iei, ref uint imgSz, out SafeHICON hico)
			{
				var szIconFile = new StringBuilder(Kernel32.MAX_PATH);
				var hr = iei.GetIconLocation(GetIconLocationFlags.GIL_FORSHELL, szIconFile, szIconFile.Capacity, out var iIdx, out _);
				if (hr.Succeeded)
				{
					if (szIconFile.ToString() != "*")
						hr = iei.Extract(szIconFile.ToString(), (uint)iIdx, (ushort)imgSz, out hico);
					else
						hr = LoadIconFromSystemImageList(iIdx, ref imgSz, out hico);
				}
				else
					hico = null;
				return hr;
			}

			/// <summary>Gets the icon for the item using the specified characteristics.</summary>
			/// <param name="iei">The IExtractIconA from which to retrieve the icon.</param>
			/// <param name="imgSz">The width, in pixels, of the icon.</param>
			/// <param name="hico">The resulting icon handle, on success, or <c>null</c> on failure.</param>
			/// <returns>The result of function.</returns>
			public static HRESULT LoadIconFromExtractIcon(IExtractIconA iei, ref uint imgSz, out SafeHICON hico)
			{
				var szIconFile = new StringBuilder(Kernel32.MAX_PATH);
				var hr = iei.GetIconLocation(GetIconLocationFlags.GIL_FORSHELL, szIconFile, szIconFile.Capacity, out var iIdx, out _);
				if (hr.Succeeded)
				{
					if (szIconFile.ToString() != "*")
						hr = iei.Extract(szIconFile.ToString(), (uint)iIdx, (ushort)imgSz, out hico);
					else
						hr = LoadIconFromSystemImageList(iIdx, ref imgSz, out hico);
				}
				else
					hico = null;
				return hr;
			}

			/// <summary>Loads an icon from the system image list.</summary>
			/// <param name="iIdx">A value of type int that contains the index of the image.</param>
			/// <param name="imgSz">The width, in pixels, of the icon.</param>
			/// <param name="hico">The resulting icon handle, on success, or <c>null</c> on failure.</param>
			/// <returns>The result of function.</returns>
			public static HRESULT LoadIconFromSystemImageList(int iIdx, ref uint imgSz, out SafeHICON hico)
			{
				HRESULT hr;
				if ((hr = SHGetImageList(PixelsToSHIL((int)imgSz), typeof(IImageList).GUID, out var obj)).Succeeded)
				{
					try
					{
						var il = (IImageList)obj;
						hico = il.GetIcon(iIdx, IMAGELISTDRAWFLAGS.ILD_TRANSPARENT);
						using var icoInfo = new ICONINFO();
						if (GetIconInfo(hico, icoInfo))
							imgSz = (uint)GetObject<BITMAP>(icoInfo.hbmColor).bmWidth;
					}
					catch (COMException e)
					{
						hico = null;
						return e.ErrorCode;
					}
					finally
					{
						Marshal.ReleaseComObject(obj);
					}
				}
				else
					hico = default;
				return hr;
			}

			/// <summary>Gets the image for the item using the specified characteristics.</summary>
			/// <param name="psf">The IShellFolder from which to request the IExtractImage instance.</param>
			/// <param name="pidl">The PIDL of the item within <paramref name="psf"/>.</param>
			/// <param name="imgSz">The width, in pixels, of the Bitmap.</param>
			/// <param name="hbmp">The resulting Bitmap, on success, or <c>null</c> on failure.</param>
			/// <returns>The result of function.</returns>
			public static HRESULT LoadImageFromExtractImage(IShellFolder psf, PIDL pidl, ref uint imgSz, out SafeHBITMAP hbmp)
			{
				HRESULT hr = psf.GetUIObjectOf<IExtractImage>((IntPtr)pidl, out var iei);
				hbmp = default;
				if (hr.Succeeded)
				{
					try
					{
						var szIconFile = new StringBuilder(Kernel32.MAX_PATH);
						var sz = new SIZE((int)imgSz, (int)imgSz);
						IEIFLAG flags = 0;
						if ((hr = iei.GetLocation(szIconFile, (uint)szIconFile.Capacity, default, ref sz, 0, ref flags)).Succeeded &&
							szIconFile.Length > 0 &&
							(hr = iei.Extract(out hbmp)).Succeeded)
							imgSz = (uint)sz.cx;
						return hr;
					}
					finally
					{
						Marshal.ReleaseComObject(iei);
					}
				}
				return hr;
			}

			/// <summary>Gets the thumbnail image for the item using the specified characteristics.</summary>
			/// <param name="psi">The IShellItem from which to request the IThumbnailProvider instance.</param>
			/// <param name="imgSz">The width, in pixels, of the Bitmap.</param>
			/// <param name="hbmp">The resulting Bitmap, on success, or <c>null</c> on failure.</param>
			/// <returns>The result of function.</returns>
			public static HRESULT LoadImageFromThumbnailProvider(IShellItem psi, ref uint imgSz, out SafeHBITMAP hbmp)
			{
				try
				{
					var itp = psi.BindToHandler<IThumbnailProvider>(null, BHID.BHID_ThumbnailHandler);
					return LoadImageFromThumbnailProvider(itp, ref imgSz, out hbmp);
				}
				catch (COMException e)
				{
					hbmp = null;
					return e.ErrorCode;
				}
			}

			/// <summary>Gets the thumbnail image for the item using the specified characteristics.</summary>
			/// <param name="psf">The IShellFolder from which to request the IThumbnailProvider instance.</param>
			/// <param name="pidl">The PIDL of the item within <paramref name="psf"/>.</param>
			/// <param name="imgSz">The width, in pixels, of the Bitmap.</param>
			/// <param name="hbmp">The resulting Bitmap, on success, or <c>null</c> on failure.</param>
			/// <returns>The result of function.</returns>
			public static HRESULT LoadImageFromThumbnailProvider(IShellFolder psf, PIDL pidl, ref uint imgSz, out SafeHBITMAP hbmp)
			{
				HRESULT hr = psf.GetUIObjectOf<IThumbnailProvider>((IntPtr)pidl, out var itp);
				if (hr.Succeeded)
					hr = LoadImageFromThumbnailProvider(itp, ref imgSz, out hbmp);
				else
					hbmp = null;
				return hr;
			}

			/// <summary>Gets the thumbnail image for the item using the specified characteristics.</summary>
			/// <param name="itp">The itp.</param>
			/// <param name="imgSz">The width, in pixels, of the Bitmap.</param>
			/// <param name="hbmp">The resulting Bitmap, on success, or <c>null</c> on failure.</param>
			/// <returns>The result of function.</returns>
			public static HRESULT LoadImageFromThumbnailProvider(IThumbnailProvider itp, ref uint imgSz, out SafeHBITMAP hbmp)
			{
				try
				{
					var hr = itp.GetThumbnail(imgSz, out hbmp, out _);
					if (hr.Succeeded)
						imgSz = (uint)GetObject<BITMAP>(hbmp).bmWidth;
					return hr;
				}
				finally
				{
					Marshal.ReleaseComObject(itp);
				}
			}

			/// <summary>Given a pixel size, return the ShellImageSize value with the closest size.</summary>
			/// <param name="pixels">Size, in pixels, of the image list size to search for.</param>
			/// <returns>An image list size.</returns>
			public static SHIL PixelsToSHIL(int pixels) => g_rgshil.Aggregate((x, y) => Math.Abs(x.Value - pixels) < Math.Abs(y.Value - pixels) ? x : y).Key;

			/// <summary>Requests a specified interface from a COM object.</summary>
			/// <param name="iUnk">The interface to be queried.</param>
			/// <param name="riid">The interface identifier (IID) of the requested interface.</param>
			/// <returns>The returned interface.</returns>
			public static object QueryInterface(in object iUnk, in Guid riid)
			{
				QueryInterface(iUnk, riid, out var ppv).ThrowIfFailed();
				return ppv;
			}

			/// <summary>Requests a specified interface from a COM object.</summary>
			/// <param name="iUnk">The interface to be queried.</param>
			/// <param name="riid">The interface identifier (IID) of the requested interface.</param>
			/// <param name="ppv">When this method returns, contains the returned interface.</param>
			/// <returns>An HRESULT that indicates the success or failure of the call.</returns>
			public static HRESULT QueryInterface(in object iUnk, in Guid riid, out object ppv)
			{
				var tmp = riid;
				HRESULT hr = Marshal.QueryInterface(Marshal.GetIUnknownForObject(iUnk), ref tmp, out var ippv);
				ppv = hr.Succeeded ? Marshal.GetObjectForIUnknown(ippv) : null;
				System.Diagnostics.Debug.WriteLine($"Successful QI:\t{riid}");
				return hr;
			}

			/// <summary>Given an image list size, return the related size, in pixels, of that size defined on the system.</summary>
			/// <param name="imageListSize">Size of the image list.</param>
			/// <returns>Pixel size of corresponding system value.</returns>
			public static int SHILToPixels(SHIL imageListSize) => g_rgshil[imageListSize];

			[ComVisible(true)]
			private class IntFileSysBindData : IFileSystemBindData2
			{
				private static readonly Guid CLSID_UnknownJunction = new("{fc0a77e6-9d70-4258-9783-6dab1d0fe31e}");
				private Guid clsidJunction;
				private WIN32_FIND_DATA fd;
				private long fileId;

				public IntFileSysBindData()
				{
				}

				public HRESULT GetFileID(out long pliFileID)
				{
					pliFileID = fileId; return HRESULT.S_OK;
				}

				public HRESULT GetFindData(out WIN32_FIND_DATA pfd)
				{
					pfd = fd; return HRESULT.S_OK;
				}

				public HRESULT GetJunctionCLSID(out Guid pclsid)
				{
					if (clsidJunction != CLSID_UnknownJunction)
					{
						pclsid = clsidJunction;
						return HRESULT.S_OK;
					}
					pclsid = Guid.Empty;
					return HRESULT.E_FAIL;
				}

				public HRESULT SetFileID(long liFileID)
				{
					fileId = liFileID; return HRESULT.S_OK;
				}

				public HRESULT SetFindData(in WIN32_FIND_DATA pfd)
				{
					fd = pfd; return HRESULT.S_OK;
				}

				public HRESULT SetJunctionCLSID(in Guid clsid)
				{
					clsidJunction = clsid; return HRESULT.S_OK;
				}
			}

			private class ManualParentAndItem : IParentAndItem, IDisposable
			{
				private readonly PIDL pChild;
				private IShellFolder psf;

				public ManualParentAndItem(IShellItem psi)
				{
					psf = psi.BindToHandler<IShellFolder>(null, BHID.BHID_SFObject);
					SHGetIDListFromObject(psi, out var pItem).ThrowIfFailed();
					pChild = pItem.LastId;
					pItem.Dispose();
				}

				void IDisposable.Dispose()
				{
					psf = null;
					pChild.Dispose();
				}

				HRESULT IParentAndItem.GetParentAndItem(out PIDL ppidlParent, out IShellFolder ppsf, out PIDL ppidlChild)
				{
					SHGetIDListFromObject(psf, out ppidlParent).ThrowIfFailed();
					ppsf = psf;
					ppidlChild = new PIDL(pChild.GetBytes());
					return HRESULT.S_OK;
				}

				HRESULT IParentAndItem.SetParentAndItem([In] PIDL pidlParent, [In] IShellFolder psf, [In] PIDL pidlChild) => HRESULT.E_NOTIMPL;
			}
		}
	}
}