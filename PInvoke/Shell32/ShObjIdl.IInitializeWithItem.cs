using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Exposes a method used to initialize a handler, such as a property handler, thumbnail handler, or preview handler, with an <c>IShellItem</c>.
		/// </summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb761814(v=vs.85).aspx
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761814")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("7f73be3f-fb79-493c-a6c7-7ee14e245841")]
		public interface IInitializeWithItem
		{
			/// <summary>Initializes a handler with an <c>IShellItem</c>.</summary>
			/// <param name="psi">
			/// <para>Type: <c><c>IShellItem</c>*</c></para>
			/// <para>A pointer to an <c>IShellItem</c>.</para>
			/// </param>
			/// <param name="grfMode">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>One of the following <c>STGM</c> values that indicate the access mode for psi.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			[PreserveSig]
			HRESULT Initialize(IShellItem psi, STGM grfMode);
		}
	}
}