using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Exposes a method that initializes Shell extensions for property sheets, shortcut menus, and drag-and-drop handlers (extensions that add items to
		/// shortcut menus during nondefault drag-and-drop operations).
		/// </summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214E8-0000-0000-c000-000000000046")]
		public interface IShellExtInit
		{
			/// <summary>Initializes a property sheet extension, shortcut menu extension, or drag-and-drop handler.</summary>
			/// <param name="pidlFolder">
			/// A pointer to an ITEMIDLIST structure that uniquely identifies a folder. For property sheet extensions, this parameter is NULL. For shortcut menu
			/// extensions, it is the item identifier list for the folder that contains the item whose shortcut menu is being displayed. For nondefault
			/// drag-and-drop menu extensions, this parameter specifies the target folder.
			/// </param>
			/// <param name="pdtobj">A pointer to an IDataObject interface object that can be used to retrieve the objects being acted upon.</param>
			/// <param name="hkeyProgId">The registry key for the file object or folder type.</param>
			void Initialize(PIDL pidlFolder, [In] IDataObject pdtobj, uint hkeyProgId);
		}
	}
}