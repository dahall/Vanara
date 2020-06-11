using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Flags for <see cref="INewMenuClient.IncludeItems"/></summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.INewMenuClient")]
		public enum NMCII_FLAGS
		{
			/// <summary>None.</summary>
			NMCII_NONE = 0x0000,

			/// <summary>Non-folder items.</summary>
			NMCII_ITEMS = 0x0001,

			/// <summary>Folder items.</summary>
			NMCII_FOLDERS = 0x0002,
		}

		/// <summary>Flags for <see cref="INewMenuClient.SelectAndEditItem"/></summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.INewMenuClient")]
		public enum NMCSAEI_FLAGS
		{
			/// <summary>Select the item.</summary>
			NMCSAEI_SELECT = 0x0000,

			/// <summary>Edit the item.</summary>
			NMCSAEI_EDIT = 0x0001,
		}

		/// <summary>Exposes methods that allow manipulation of items in a Windows 7 menu.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-inewmenuclient
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.INewMenuClient")]
		[ComImport, Guid("dcb07fdc-3bb5-451c-90be-966644fed7b0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface INewMenuClient
		{
			/// <summary>Allows the view to filter the items shown in the menu.</summary>
			/// <param name="pflags">
			/// <para>Type: <c>NMCII_FLAGS*</c></para>
			/// <para>Pointer to a value that, when this method returns successfully, contains one of the following values:</para>
			/// <para>NMCII_NONE (0x0000)</para>
			/// <para>0x0000.</para>
			/// <para>NMCII_ITEMS (0x0001)</para>
			/// <para>0x0001. Non-folder items.</para>
			/// <para>NMCII_FOLDERS (0x0002)</para>
			/// <para>0x0002. Folder items.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inewmenuclient-includeitems HRESULT
			// IncludeItems( NMCII_FLAGS *pflags );
			[PreserveSig]
			HRESULT IncludeItems(out NMCII_FLAGS pflags);

			/// <summary>Selects or edits the specified item in the menu.</summary>
			/// <param name="pidlItem">Type: <c>PCIDLIST_ABSOLUTE</c></param>
			/// <param name="flags">
			/// <para>Type: <c>NMCSAEI_FLAGS</c></para>
			/// <para>NMCSAEI_SELECT (0x0000)</para>
			/// <para>0x0000. Select the item.</para>
			/// <para>NMCSAEI_EDIT (0x0001)</para>
			/// <para>0x0001. Edit the item.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inewmenuclient-selectandedititem HRESULT
			// SelectAndEditItem( PCIDLIST_ABSOLUTE pidlItem, NMCSAEI_FLAGS flags );
			[PreserveSig]
			HRESULT SelectAndEditItem([In] PIDL pidlItem, NMCSAEI_FLAGS flags);
		}
	}
}