using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

// ReSharper disable UnusedMember.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable UnusedMethodReturnValue.Global

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Specifies the default save location.</summary>
		public enum DEFAULTSAVEFOLDERTYPE
		{
			/// <summary>The current user determines the save folder. If the current user is the library's owner, use the private save location (DSFT_PRIVATE). If the current user is not the library's owner, use the public save location (DSFT_PUBLIC).</summary>
			DSFT_DETECT = 1,
			/// <summary>The library's private save location, which can only be accessed by the library's owner.</summary>
			DSFT_PRIVATE,
			/// <summary>The library's public save location, which can be accessed by all users.</summary>
			DSFT_PUBLIC
		}

		/// <summary>Defines options for filtering folder items.</summary>
		public enum LIBRARYFOLDERFILTER
		{
			/// <summary>Return only file system items.</summary>
			LFF_FORCEFILESYSTEM = 1,
			/// <summary>Return items that can be bound to an IStorage object.</summary>
			LFF_STORAGEITEMS = 2,
			/// <summary>Return all items.</summary>
			LFF_ALLITEMS = 3
		}

		/// <summary>Used by SHShowManageLibraryUI to define options for handling a name collision when saving a library.</summary>
		public enum LIBRARYMANAGEDIALOGOPTIONS
		{
			/// <summary>Show default warning UI to the user.</summary>
			LMD_DEFAULT = 0x00000000,
			/// <summary>Do not display a warning dialog to the user in collisions that concern network locations that cannot be indexed.</summary>
			LMD_ALLOWUNINDEXABLENETWORKLOCATIONS = 0x00000001
		}

		/// <summary>Specifies the library options.</summary>
		[Flags]
		public enum LIBRARYOPTIONFLAGS
		{
			/// <summary>No library options are set.</summary>
			LOF_DEFAULT = 0x00000000,
			/// <summary>Pin the library to the navigation pane.</summary>
			LOF_PINNEDTONAVPANE = 0x00000001,
			/// <summary>All valid library options flags.</summary>
			LOF_MASK_ALL = 0x00000001
		}

		/// <summary>Specifies the options for handling a name collision when saving a library.</summary>
		[Flags]
		public enum LIBRARYSAVEFLAGS
		{
			/// <summary>If a library with the same name already exists, the save operation fails.</summary>
			LSF_FAILIFTHERE = 0x00000000,
			/// <summary>If a library with the same name already exists, the save operation overwrites the existing library.</summary>
			LSF_OVERRIDEEXISTING = 0x00000001,
			/// <summary>If a library with the same name already exists, the save operation generates a new, unique name for the library.</summary>
			LSF_MAKEUNIQUENAME = 0x00000002,
		}

		/// <summary>Exposes methods for creating and managing libraries.</summary>
		[ComImport, Guid("11a66efa-382e-451a-9234-1e0e12ef3085"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(CShellLibrary))]
		public interface IShellLibrary
		{
			/// <summary>Loads the library from a specified library definition file.</summary>
			/// <param name="library">An IShellItem object for the library definition file to load. An error is returned if this object is not a library.</param>
			/// <param name="grfMode">One or more STGM storage medium flags that specify access and sharing modes for the library object.</param>
			void LoadLibraryFromItem([In, MarshalAs(UnmanagedType.Interface)] IShellItem library, [In] STGM grfMode);

			/// <summary>Loads the library that is referenced by a KNOWNFOLDERID.</summary>
			/// <param name="knownfidLibrary">The KNOWNFOLDERID value that identifies the library to load.</param>
			/// <param name="grfMode">One or more STGM storage medium flags that specify access and sharing modes for the library object.</param>
			void LoadLibraryFromKnownFolder(in Guid knownfidLibrary, [In] STGM grfMode);

			/// <summary>Adds a folder to the library.</summary>
			/// <param name="location">An IShellItem object that represents the folder to be added to the library.</param>
			void AddFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem location);

			/// <summary>Removes a folder from the library.</summary>
			/// <param name="location">An IShellItem object that represents the folder to remove.</param>
			void RemoveFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem location);

			/// <summary>Gets the set of child folders that are contained in the library.</summary>
			/// <param name="lff">One of the following LIBRARYFOLDERFILTER values that determines the folders to get.</param>
			/// <param name="riid">A reference to the IID of the interface to get in ppv. This value is typically IID_IShellItemArray, but it can also be IID_IObjectCollection, IID_IObjectArray, or the IID of any other interface that is implemented by CShellItemArray.</param>
			/// <returns>A pointer to the interface requested in riid. If this call fails, this value is NULL.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IShellItemArray GetFolders([In] LIBRARYFOLDERFILTER lff, in Guid riid);

			/// <summary>Resolves the target location of a library folder, even if the folder has been moved or renamed.</summary>
			/// <param name="folderToResolve">An IShellItem object that represents the library folder to locate.</param>
			/// <param name="timeout">The maximum time, in milliseconds, the method will attempt to locate the folder before returning. If the folder could not be located before the specified time elapses, an error is returned.</param>
			/// <param name="riid">A reference to the IID of the interface to get in ppv that will represent the resolved target location. This value is typically IID_IShellItem, but it can also be IID_IShellItem2 or the IID of any other interface that is implemented by CShellItem.</param>
			/// <returns>A pointer to the interface requested in riid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IShellItem ResolveFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem folderToResolve, [In] uint timeout, in Guid riid);

			/// <summary>Retrieves the default target folder that the library uses for save operations.</summary>
			/// <param name="dsft">The DEFAULTSAVEFOLDERTYPE value that specifies the save folder to get.</param>
			/// <param name="riid">A reference to the IID of the interface to get in ppv that will represent the save location. This value is typically IID_IShellItem, but it can also be IID_IShellItem2 or the IID of any other interface that is implemented by CShellItem.</param>
			/// <returns>A pointer to the interface requested in riid.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IShellItem GetDefaultSaveFolder([In] DEFAULTSAVEFOLDERTYPE dsft, in Guid riid);

			/// <summary>Sets the default target folder that the library will use for save operations.</summary>
			/// <param name="dsft">The DEFAULTSAVEFOLDERTYPE value that specifies the default save location to set.</param>
			/// <param name="si">An IShellItem object that represents the folder that to use as the default save location. The folder that this object represents must be a folder that is already in the library.</param>
			void SetDefaultSaveFolder([In] DEFAULTSAVEFOLDERTYPE dsft, [In, MarshalAs(UnmanagedType.Interface)] IShellItem si);

			/// <summary>Gets the library's options.</summary>
			/// <returns>The library options for this library. LIBRARYOPTIONFLAGS is a bitwise enumerator, which means that more than one flag could be set.</returns>
			LIBRARYOPTIONFLAGS GetOptions();

			/// <summary>Sets the library options.</summary>
			/// <param name="lofMask">A bitmask that specifies the LIBRARYOPTIONFLAGS values to change in this call.</param>
			/// <param name="lofOptions">A bitmask that specifies the new value of each LIBRARYOPTIONFLAGS value to change. LIBRARYOPTIONFLAGS values that are not set in lofMask are not changed by this call.</param>
			void SetOptions([In] LIBRARYOPTIONFLAGS lofMask, [In] LIBRARYOPTIONFLAGS lofOptions);

			/// <summary>Gets the library's folder type.</summary>
			/// <returns>The view template that is applied to a folder, usually based on its intended use and contents.</returns>
			[return: MarshalAs(UnmanagedType.LPStruct)]
			Guid GetFolderType();

			/// <summary>Sets the library's folder type.</summary>
			/// <param name="ftid">The GUID or FOLDERTYPEID that represents the view template that is applied to a folder, usually based on its intended use and contents.</param>
			void SetFolderType(in Guid ftid);

			/// <summary>Gets the default icon for the library.</summary>
			/// <returns>A null-terminated Unicode string that describes the location of the default icon. The string is returned as ModuleFileName,ResourceIndex or ModuleFileName,-ResourceID.</returns>
			SafeCoTaskMemString GetIcon();

			/// <summary>Sets the default icon for the library.</summary>
			/// <param name="icon">A null-terminated Unicode string that describes the location of the default icon. The string must be formatted as ModuleFileName,ResourceIndex or ModuleFileName,-ResourceID.</param>
			void SetIcon([In, MarshalAs(UnmanagedType.LPWStr)] string icon);

			/// <summary>Commits library updates to an existing Library Description file.</summary>
			void Commit();

			/// <summary>Saves the library to a new Library Description (*.library-ms) file.</summary>
			/// <param name="folderToSaveIn">The IShellItem object that specifies the folder in which to save the library, or NULL to save the library with the user's default libraries in the FOLDERID_Libraries known folder.</param>
			/// <param name="libraryName">The file name under which to save the library. The file name must not include the file name extension; the file name extension is added automatically.</param>
			/// <param name="lsf">The LIBRARYSAVEFLAGS value that specifies how to handle a library name collision.</param>
			/// <returns>The IShellItem object that represents the library description file into which the library was saved.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IShellItem Save([In, MarshalAs(UnmanagedType.Interface)] IShellItem folderToSaveIn, [In, MarshalAs(UnmanagedType.LPWStr)] string libraryName, [In] LIBRARYSAVEFLAGS lsf);

			/// <summary>Saves the library to a new file in a specified known folder.</summary>
			/// <param name="kfidToSaveIn">The ID of the known folder in which to save the IShellLibrary object. For more information, see KNOWNFOLDERID.</param>
			/// <param name="libraryName">The file name under which to save the library. The file name must not include the file name extension; the file name extension is added automatically.</param>
			/// <param name="lsf">The LIBRARYSAVEFLAGS value that specifies how to handle a library name collision.</param>
			/// <returns>The IShellItem object that represents the library description file into which the library was saved.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IShellItem SaveInKnownFolder(in Guid kfidToSaveIn, [In, MarshalAs(UnmanagedType.LPWStr)] string libraryName, [In] LIBRARYSAVEFLAGS lsf);
		}

		/// <summary>Resolves all locations in a library, even those locations that have been moved or renamed.</summary>
		/// <param name="psiLibrary">A pointer to an IShellItem object that represents the library.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		/// <remarks>This function can block the calling thread for as long as it takes to resolve all the locations in the specified library. Because it blocks the thread from which it is called, it should not be called from a thread that also handles user interface interactions.
		/// <para>This function resolves all locations in the specified library in a single call. To resolve an individual location in a library, see the IShellLibrary::ResolveFolder method or the SHResolveFolderPathInLibrary function.</para></remarks>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378439")]
		public static extern HRESULT SHResolveLibrary([MarshalAs(UnmanagedType.Interface)] IShellItem psiLibrary);

		/// <summary>Shows the library management dialog box, which enables users to manage the library folders and default save location.</summary>
		/// <param name="psiLibrary">A pointer to an IShellItem object that represents the library that is to be managed.</param>
		/// <param name="hwndOwner">The handle for the window that owns the library management dialog box. The value of this parameter can be NULL.</param>
		/// <param name="pszTitle">A pointer to the title for the library management dialog. To display the generic title string, set the value of this parameter to NULL.</param>
		/// <param name="pszInstruction">A pointer to a help string to display below the title string in the library management dialog box. To display the generic help string, set the value of this parameter to NULL.</param>
		/// <param name="lmdOptions">A value from the LIBRARYMANAGEDIALOGOPTIONS enumeration that specifies the behavior of the management dialog box.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.Shell32, ExactSpelling = true)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "dd378433")]
		public static extern HRESULT SHShowManageLibraryUI([MarshalAs(UnmanagedType.Interface)] IShellItem psiLibrary, HWND hwndOwner, [In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle, [In, MarshalAs(UnmanagedType.LPWStr)] string pszInstruction, LIBRARYMANAGEDIALOGOPTIONS lmdOptions);

		/// <summary>Class interface for IShellLibrary</summary>
		[ComImport, Guid("d9b3211d-e57f-4426-aaef-30a806add397"), ClassInterface(ClassInterfaceType.None)]
		public class CShellLibrary { }
	}
}