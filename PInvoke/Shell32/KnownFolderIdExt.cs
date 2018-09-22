using System;
using System.Linq;
using Vanara.Extensions;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Shell32;
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	/// <summary>Extension methods for <see cref="KNOWNFOLDERID"/>.</summary>
	public static class KnownFolderIdExt
	{
		private const string RegPath =
			@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\FolderDescriptions\";

		private const KNOWN_FOLDER_FLAG stdGetFlags =
			KNOWN_FOLDER_FLAG.KF_FLAG_DEFAULT_PATH | KNOWN_FOLDER_FLAG.KF_FLAG_NOT_PARENT_RELATIVE |
			KNOWN_FOLDER_FLAG.KF_FLAG_NO_ALIAS | KNOWN_FOLDER_FLAG.KF_FLAG_DONT_VERIFY;

		/// <summary>Retrieves the full path associated with a <see cref="KNOWNFOLDERID"/>.</summary>
		/// <param name="id">The known folder.</param>
		/// <returns>The path.</returns>
		public static string FullPath(this KNOWNFOLDERID id)
		{
			SHGetKnownFolderPath(id.Guid(), stdGetFlags, HTOKEN.NULL, out var path);
			return path.ToString(-1);
		}

		/// <summary>Gets a registry property associated with this known folder.</summary>
		/// <typeparam name="T">Return type.</typeparam>
		/// <param name="id">The known folder.</param>
		/// <param name="valueName">Name of the property (value under registry key).</param>
		/// <returns>Retrieved value or default(T) if no value exists.</returns>
		public static T GetRegistryProperty<T>(this KNOWNFOLDERID id, string valueName) =>
			(T)Microsoft.Win32.Registry.GetValue(RegPath + id.Guid().ToString("B"), valueName, default(T));

		/// <summary>Retrieves the Guid associated with a <see cref="KNOWNFOLDERID"/>.</summary>
		/// <param name="id">The known folder.</param>
		/// <returns>The GUID associated with the <paramref name="id"/> or <see cref="Guid.Empty"/> if no association exists.</returns>
		public static Guid Guid(this KNOWNFOLDERID id) => AssociateAttribute.GetGuidFromEnum(id);

		/// <summary>Retrieves the IShellItem associated with a <see cref="KNOWNFOLDERID"/>.</summary>
		/// <param name="id">The known folder.</param>
		/// <returns>The <see cref="IShellItem"/> instance.</returns>
		public static IShellItem GetIShellItem(this KNOWNFOLDERID id)
		{
			SHGetKnownFolderItem(id.Guid(), KNOWN_FOLDER_FLAG.KF_FLAG_DEFAULT, HTOKEN.NULL, typeof(IShellItem).GUID, out var ppv).ThrowIfFailed();
			return (IShellItem) ppv;
		}

		/// <summary>Retrieves the <see cref="KNOWNFOLDERID"/> associated with the <see cref="Environment.SpecialFolder"/>.</summary>
		/// <param name="spFolder">The <see cref="Environment.SpecialFolder"/>.</param>
		/// <returns>Matching <see cref="KNOWNFOLDERID"/>.</returns>
		public static KNOWNFOLDERID KnownFolderId(this System.Environment.SpecialFolder spFolder)
		{
			if (spFolder == Environment.SpecialFolder.Personal) return KNOWNFOLDERID.FOLDERID_Documents;
			if (spFolder == Environment.SpecialFolder.DesktopDirectory) return KNOWNFOLDERID.FOLDERID_Desktop;
			foreach (KNOWNFOLDERID val in Enum.GetValues(typeof(KNOWNFOLDERID)))
				if (val.SpecialFolder() == spFolder) return val;
			throw new InvalidCastException(@"There is not a Known Folder equivalent to this SpecialFolder.");
		}

		/// <summary>Retrieves the name associated with a <see cref="KNOWNFOLDERID"/>.</summary>
		/// <param name="id">The known folder.</param>
		/// <returns>The name.</returns>
		public static string Name(this KNOWNFOLDERID id) => id.GetRegistryProperty<string>("Name");

		/// <summary>Retrieves the PIDL associated with a <see cref="KNOWNFOLDERID"/>.</summary>
		/// <param name="id">The known folder.</param>
		/// <returns>The PIDL.</returns>
		public static PIDL PIDL(this KNOWNFOLDERID id)
		{
			SHGetKnownFolderIDList(id.Guid(), stdGetFlags, HTOKEN.NULL, out var pidl);
			return pidl;
		}

		/// <summary>Retrieves the <see cref="Environment.SpecialFolder"/> associated with a <see cref="KNOWNFOLDERID"/> if it exists.</summary>
		/// <param name="id">The known folder.</param>
		/// <returns>The <see cref="Environment.SpecialFolder"/> if defined, <c>null</c> otherwise.</returns>
		public static Environment.SpecialFolder? SpecialFolder(this KNOWNFOLDERID id) =>
			typeof(KNOWNFOLDERID).GetField(id.ToString()).GetCustomAttributes<KnownFolderDetailAttribute>().Select(a => (Environment.SpecialFolder?)a.Equivalent).FirstOrDefault();
	}
}