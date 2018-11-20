using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// <para>Exposes a method that unpins an application shortcut from the <c>Start</c> menu or the taskbar.</para>
		/// </summary>
		/// <remarks>
		/// <para>When to Implement</para>
		/// <para>Windows provides an implementation of this interface as CLSID_StartMenuPin. Third parties do not provide their own implementation.</para>
		/// <para>When to Use</para>
		/// <para>
		/// Any shortcut installed by an application might have been subsequently pinned by the user, and there is no way for an application
		/// to know this. Therefore, we recommend that, during uninstallation, all applications call IStartMenuPinnedList::RemoveFromList on
		/// each shortcut they installed.
		/// </para>
		/// <para>
		/// Note that <c>IStartMenuPinnedList</c> does not remove the shortcuts themselves, it only unpins them. Applications first call
		/// IStartMenuPinnedList::RemoveFromList on a shortcut, then delete that shortcut.
		/// </para>
		/// <para>Compatibility</para>
		/// <para>
		/// In Windows 8, the Start screen replaces the legacy Start menu. CLSID_StartMenuPin and IStartMenuPinnedList are present in Windows
		/// 8 to provide backward compatibility with existing applications, but they do not affect tiles pinned to the Windows 8 Start
		/// screen. CLSID_StartMenuPin and IStartMenuPinnedList do continue to impact items pinned to the Windows 8 desktop taskbar.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl/nn-shobjidl-istartmenupinnedlist
		[PInvokeData("shobjidl.h", MSDNShortId = "e1f4dbdb-34c0-4bf5-bb8b-a622a81c1617")]
		[ComImport, Guid("4CD19ADA-25A5-4A32-B3B7-347BEE5BE36B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(StartMenuPin))]
		public interface IStartMenuPinnedList
		{
			/// <summary>
			/// <c>Windows Vista:</c> Removes an item from the Start menu pinned list, which is the list in the upper left position of the
			/// Start menu.
			/// <para><c>Windows 7:</c> Removes an item from the Start menu pinned list and unpins the item from the taskbar.</para>
			/// <para>
			/// <c>Windows 8:</c> Unpins the item from the taskbar but does not remove the item from the Start screen. Items cannot be
			/// programmatically removed from Start; they can only be unpinned by the user or removed as part of a program's uninstallation.
			/// </para>
			/// </summary>
			/// <param name="pitem">A pointer to an IShellItem object that represents the item to unpin.</param>
			/// <returns>
			/// <list type="bullet">
			/// <item>
			/// <term>Returns S_OK if the item was successfully removed from the list of pinned items and/or the taskbar.</term>
			/// </item>
			/// <item>
			/// <term>Returns S_OK if the item was not pinned at all.</term>
			/// </item>
			/// <item>
			/// <term>Returns a standard error code otherwise.</term>
			/// </item>
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