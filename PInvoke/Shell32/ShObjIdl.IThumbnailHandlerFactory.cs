using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Exposes a method for retrieving the thumbnail handler of an item. Implement this interface if you want to specify what extractor
		/// is used for a child IDList.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ithumbnailhandlerfactory
		[ComImport, Guid("e35b4b2e-00da-4bc1-9f13-38bc11f5d417"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IThumbnailHandlerFactory
		{
			/// <summary>Gets the requested thumbnail handler for the thumbnail of a given item.</summary>
			/// <param name="pidlChild">
			/// <para>Type: <c>PCUITEMID_CHILD</c></para>
			/// <para>The item within the namespace for which the thumbnail handler is being retrieved.</para>
			/// </param>
			/// <param name="pbc">
			/// <para>Type: <c>IBindCtx*</c></para>
			/// <para>A pointer to an IBindCtx to be used during the moniker binding operation of this process.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to the IID of the interface requested. This is usually IThumbnailProvider or IExtractImage.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>
			/// When this method returns, contains the address of a pointer to the requested thumbnail handler. If this method fails, this
			/// value is <c>NULL</c>.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>Windows Vista calls the <c>IThumbnailHandlerFactory::GetThumbnailHandler</c> method before falling back on GetUIObjectOf.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ithumbnailhandlerfactory-getthumbnailhandler
			// HRESULT GetThumbnailHandler( PCUITEMID_CHILD pidlChild, IBindCtx *pbc, REFIID riid, void **ppv );
			[PreserveSig]
			HRESULT GetThumbnailHandler([In] PIDL pidlChild, IBindCtx pbc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object ppv);
		}
	}
}