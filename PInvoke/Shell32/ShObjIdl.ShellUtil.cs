using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Text;
using static Vanara.PInvoke.Ole32;
using BIND_OPTS = System.Runtime.InteropServices.ComTypes.BIND_OPTS;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <remarks>Methods in this class will only work on Vista and above.</remarks>
		public static class ShellUtil
		{
			/// <summary></summary>
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

				var hr = SHCreateItemFromParsingName(path, null, typeof(IShellItem).GUID, out var unk);
				if (hr == 0x80070002)
				{
					Ole32.CreateBindCtx(0, out var ibc).ThrowIfFailed();
					using (var _ibc = InteropServices.ComReleaserFactory.Create(ibc))
					{
						var bd = new IntFileSysBindData();
						ibc.RegisterObjectParam(STR_FILE_SYS_BIND_DATA, bd);
						hr = SHCreateItemFromParsingName(path, ibc, typeof(IShellItem).GUID, out unk);
					}
				}
				hr.ThrowIfFailed();
				return (IShellItem)unk;
			}

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

			[ComVisible(true)]
			private class IntFileSysBindData : IFileSystemBindData2
			{
				private static readonly Guid CLSID_UnknownJunction = new Guid("{fc0a77e6-9d70-4258-9783-6dab1d0fe31e}");
				private Guid clsidJunction;
				private WIN32_FIND_DATA fd;
				private long fileId;

				public IntFileSysBindData()
				{
				}

				public HRESULT GetFileID(out long pliFileID) { pliFileID = fileId; return HRESULT.S_OK; }

				public HRESULT GetFindData(out WIN32_FIND_DATA pfd) { pfd = fd; return HRESULT.S_OK; }

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

				public HRESULT SetFileID(long liFileID) { fileId = liFileID; return HRESULT.S_OK; }

				public HRESULT SetFindData(in WIN32_FIND_DATA pfd) { fd = pfd; return HRESULT.S_OK; }

				public HRESULT SetJunctionCLSID(in Guid clsid) { clsidJunction = clsid; return HRESULT.S_OK; }
			}
		}
	}
}