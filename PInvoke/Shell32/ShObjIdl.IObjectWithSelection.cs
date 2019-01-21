using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Exposes methods that get or set selected items represented by a Shell item array.</summary>
		/// <remarks>
		/// <para>When to Implement</para>
		/// <para>
		/// This interface is implemented by verbs that implement IExecuteCommand. This allows objects to invoke the verb on the selection
		/// through IExecuteCommand::Execute.
		/// </para>
		/// <para>When to Use</para>
		/// <para>
		/// <c>IObjectWithSelection</c> is used by Windows Explorer to invoke a verb on the selected items. Do not call this interface directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-iobjectwithselection
		[PInvokeData("shobjidl_core.h", MSDNShortId = "8fb248eb-73e7-4db0-8585-4accafe332d0")]
		[ComImport, Guid("1c9cd5bb-98e9-4491-a60f-31aacc72b83c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IObjectWithSelection
		{
			/// <summary>Provides the Shell item array that specifies the items included in the selection.</summary>
			/// <param name="psia">
			/// <para>Type: <c>IShellItemArray*</c></para>
			/// <para>A pointer to an IShellItemArray that represents the selected items.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iobjectwithselection-setselection HRESULT
			// SetSelection( IShellItemArray *psia );
			[PreserveSig]
			HRESULT SetSelection([In] IShellItemArray psia);

			/// <summary>Gets the Shell item array that contains the selected items.</summary>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to the IID of the interface to retrieve through ppv, typically IID_IShellItemArray.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>When this method returns successfully, contains the interface pointer requested in riid. This is typically an IShellItemArray.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// We recommend that you use the <c>IID_PPV_ARGS</c> macro, defined in Objbase.h, to package the riid and ppv parameters. This
			/// macro provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a
			/// coding error in riid that could lead to unexpected results.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iobjectwithselection-getselection HRESULT
			// GetSelection( REFIID riid, void **ppv );
			[PreserveSig]
			HRESULT GetSelection(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object ppv);
		}
	}
}