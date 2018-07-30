using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Exposes a method to initialize a handler, such as a property handler, thumbnail handler, or preview handler, with a file path.
		/// </summary>
		/// <remarks>
		/// Whenever possible, it is recommended that initialization be done through a stream using IInitializeWithStream. Benefits of this
		/// include increased security and stability.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nn-propsys-iinitializewithfile
		[PInvokeData("propsys.h", MSDNShortId = "323181ab-1dc2-4b2a-a91f-3eccd7968bcd")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("b7d14566-0509-4cce-a71f-0a554233bd9b")]
		public interface IInitializeWithFile
		{
			/// <summary>
			/// <para>Initializes a handler with a file path.</para>
			/// </summary>
			/// <param name="pszFilePath">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a buffer that contains the file path as a null-terminated Unicode string.</para>
			/// </param>
			/// <param name="grfMode">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>One of the following STGM values that indicates the access mode for .</para>
			/// <para>STGM_READ</para>
			/// <para>The file indicated by <c>IInitializeWithFile::Initialize</c> is read-only.</para>
			/// <para>STGM_READWRITE</para>
			/// <para>The file indicated by <c>IInitializeWithFile::Initialize</c> can be read from and written to.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Initialize is preferred to this method because of its ability to use files that are not accessible through a Win32 path, such
			/// as the contents of a compressed file with a .zip file name extension. Use <c>IInitializeWithFile::Initialize</c> only when
			/// the API used by the handler to access the file accepts file paths only.
			/// </para>
			/// <para>The file pointed to by must remain open for the lifetime of the handler or until IPropertyStore::Commit is called.</para>
			/// <para>If the file cannot be opened according to the method's parameter values, this method returns a suitable error code.</para>
			/// <para>
			/// A handler instance should be initialized only once in its lifetime. Attempts by the calling application to reinitialize the
			/// handler should result in the error .
			/// </para>
			/// </remarks>
			HRESULT Initialize([In, MarshalAs(UnmanagedType.LPWStr)] string pszFilePath, STGM grfMode);
		}
	}
}