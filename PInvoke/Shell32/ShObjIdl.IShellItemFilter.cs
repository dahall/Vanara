using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Exposed by a client to specify how to filter the enumeration of a Shell item by a server application.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishellitemfilter
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("2659B475-EEB8-48b7-8F07-B378810F48CF")]
		public interface IShellItemFilter
		{
			/// <summary>Sets a given Shell item status to inclusion in the view.</summary>
			/// <param name="psi">
			/// <para>Type: <c>IShellItem*</c></para>
			/// <para>A pointer to the Shell item that is to be included in the view.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// The host calls this method for each item in the folder. Returns S_OK to have the item enumerated for inclusion in the view.
			/// Returns S_FALSE to prevent the item from being enumerated for inclusion in the view.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitemfilter-includeitem HRESULT
			// IncludeItem( IShellItem *psi );
			[PreserveSig]
			HRESULT IncludeItem([In] IShellItem psi);

			/// <summary>
			/// Allows a client to specify which classes of objects in a Shell item should be enumerated for inclusion in the view.
			/// </summary>
			/// <param name="psi">
			/// <para>Type: <c>IShellItem*</c></para>
			/// <para>A pointer to the Shell item for which the SHCONTF enum flags are to be retrieved.</para>
			/// </param>
			/// <param name="pgrfFlags">
			/// <para>Type: <c>SHCONTF*</c></para>
			/// <para>
			/// A pointer to the SHCONTF enum flags for the given Shell item that specifies which classes of objects to enumerate for
			/// inclusion in the view.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitemfilter-getenumflagsforitem
			// HRESULT GetEnumFlagsForItem( IShellItem *psi, SHCONTF *pgrfFlags );
			[PreserveSig]
			HRESULT GetEnumFlagsForItem([In] IShellItem psi, out SHCONTF pgrfFlags);
		}
	}
}