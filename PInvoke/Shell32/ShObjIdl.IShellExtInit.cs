using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Exposes a method that initializes Shell extensions for property sheets, shortcut menus, and drag-and-drop handlers (extensions
		/// that add items to shortcut menus during nondefault drag-and-drop operations).
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb775096(v=vs.85).aspx
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775096")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214E8-0000-0000-c000-000000000046")]
		public interface IShellExtInit
		{
			/// <summary>Initializes a property sheet extension, shortcut menu extension, or drag-and-drop handler.</summary>
			/// <param name="pidlFolder">
			/// A pointer to an ITEMIDLIST structure that uniquely identifies a folder. For property sheet extensions, this parameter is
			/// NULL. For shortcut menu extensions, it is the item identifier list for the folder that contains the item whose shortcut menu
			/// is being displayed. For nondefault drag-and-drop menu extensions, this parameter specifies the target folder.
			/// </param>
			/// <param name="pdtobj">
			/// A pointer to an IDataObject interface object that can be used to retrieve the objects being acted upon.
			/// </param>
			/// <param name="hkeyProgId">The registry key for the file object or folder type.</param>
			/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			[PreserveSig]
			HRESULT Initialize([Optional] PIDL pidlFolder, [In, Optional] IDataObject pdtobj, [Optional] HKEY hkeyProgId);
		}
	}
}