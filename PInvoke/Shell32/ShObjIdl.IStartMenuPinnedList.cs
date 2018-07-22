using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Exposes a method that unpins an application shortcut from the Start menu or the taskbar.</summary>
		[ComImport, Guid("4CD19ADA-25A5-4A32-B3B7-347BEE5BE36B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(StartMenuPin))]
		[PInvokeData("shobjidl.h")]
		public interface IStartMenuPinnedList
		{
			/// <summary>
			/// <c>Windows Vista:</c> Removes an item from the Start menu pinned list, which is the list in the upper left position of the Start menu.
			/// <para><c>Windows 7:</c> Removes an item from the Start menu pinned list and unpins the item from the taskbar.</para>
			/// <para><c>Windows 8:</c> Unpins the item from the taskbar but does not remove the item from the Start screen. Items cannot be programmatically removed from Start; they can only be unpinned by the user or removed as part of a program's uninstallation.</para></summary>
			/// <param name="pitem">A pointer to an IShellItem object that represents the item to unpin.</param>
			/// <returns>
			/// <list type="bullet">
			/// <item><term>Returns S_OK if the item was successfully removed from the list of pinned items and/or the taskbar.</term></item>
			/// <item><term>Returns S_OK if the item was not pinned at all.</term></item>
			/// <item><term>Returns a standard error code otherwise.</term></item>
			/// </list>
			/// </returns>
			[PreserveSig]
			HRESULT RemoveFromList([In] IShellItem pitem);
		}

		/// <summary>CoClass for IStartMenuPinnedList (CLSID_StartMenuPin).</summary>
		[PInvokeData("shobjidl.h")]
		[ComImport, Guid("a2a9545d-a0c2-42b4-9708-a0b2badd77c8"), ClassInterface(ClassInterfaceType.None)]
		public class StartMenuPin { }
	}
}