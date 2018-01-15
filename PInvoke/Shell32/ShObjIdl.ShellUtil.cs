using System;
using System.Linq;
using System.Security;
using System.Text;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable UnusedMethodReturnValue.Global

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <remarks>Methods in this class will only work on Vista and above.</remarks>
		public static class ShellUtil
		{
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
				if (knownFolder == default(Guid))
					return null;

				var pathBuilder = new StringBuilder(260);
				if (SHGetFolderPathEx(knownFolder, 0, null, pathBuilder, (uint)pathBuilder.Capacity).Failed)
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

				SHCreateItemFromParsingName(path, null, typeof(IShellItem).GUID, out object unk).ThrowIfFailed();
				return (IShellItem)unk;
			}
		}
	}
}