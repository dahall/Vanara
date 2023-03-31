using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// Exposes a method that initializes a handler, such as a property handler, thumbnail handler, or preview handler, with a stream.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nn-propsys-iinitializewithstream
	[PInvokeData("propsys.h", MSDNShortId = "9050845d-1e70-4e85-8d2f-c8bbb382abe5")]
	[ComImport, Guid("b824b49d-22ac-4161-ac8a-9916e8fa3f7f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IInitializeWithStream
	{
		/// <summary>
		/// <para>Initializes a handler with a stream.</para>
		/// </summary>
		/// <param name="pstream">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>A pointer to an IStream interface that represents the stream source.</para>
		/// </param>
		/// <param name="grfMode">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>One of the following STGM values that indicates the access mode for .</para>
		/// <para>STGM_READ</para>
		/// <para>The stream indicated by is read-only.</para>
		/// <para>STGM_READWRITE</para>
		/// <para>The stream indicated by is read/write accessible.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is preferred to Initialize due to its ability to use streams that are not accessible through a Win32 path, such
		/// as the contents of a compressed file with a .zip file name extension.
		/// </para>
		/// <para>The stream pointed to by must remain open for the lifetime of the handler or until IPropertyStore::Commit is called.</para>
		/// <para>
		/// When first opened, the source stream reference points to the beginning of the stream. The handler can seek and read from the
		/// stream at any time. A handler can be implemented to read all properties from the stream during <c>Initialize</c> or it can
		/// wait until the calling process attempts to enumerate or read properties before fetching them from the stream.
		/// </para>
		/// <para>
		/// A handler instance should be initialized only once in its lifetime. Attempts by the caller to reinitialize the handler should
		/// result in the error .
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-iinitializewithstream-initialize
		[PreserveSig]
		HRESULT Initialize([In] IStream pstream, STGM grfMode);
	}
}