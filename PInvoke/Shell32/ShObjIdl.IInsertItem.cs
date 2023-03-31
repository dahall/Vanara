using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// <para>
	/// [ <c>IInsertItem</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions.]
	/// </para>
	/// <para>Exposes a method that inserts an ITEMIDLIST structure into a list of such structures.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-iinsertitem
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IInsertItem")]
	[ComImport, Guid("D2B57227-3D23-4b95-93C0-492BD454C356"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IInsertItem
	{
		/// <summary>Adds an ITEMIDLIST structure to a list of such structures.</summary>
		/// <param name="pidl">
		/// <para>Type: <c>LPCITEMIDLIST</c></para>
		/// <para>A pointer to an ITEMIDLIST structure that corresponds to an item in a Shell folder.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iinsertitem-insertitem
		// HRESULT InsertItem( PCUIDLIST_RELATIVE pidl );
		[PreserveSig]
		HRESULT InsertItem([In] PIDL pidl);
	}
}