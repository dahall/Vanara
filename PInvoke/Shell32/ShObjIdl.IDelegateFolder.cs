namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Exposes a method through which a delegate folder is given the IMalloc interface required to allocate and free item IDs.</summary>
	/// <remarks>The IDs allocated by the delegate folder are in the form of DELEGATEITEMID structures. It is the delegate's job to pack its data into the pointer to an item identifier list (PIDL) in the <c>DELEGATEITEMID</c> format.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-idelegatefolder
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDelegateFolder")]
	[ComImport, Guid("ADD8BA80-002B-11D0-8F0F-00C04FD7D062"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDelegateFolder
	{
		/// <summary>Provides the delegate folder an IMalloc interface used to allocate and free item IDs.</summary>
		/// <param name="pmalloc">
		/// <para>Type: <c>IMalloc*</c></para>
		/// <para>A pointer to an IMalloc interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idelegatefolder-setitemalloc
		// HRESULT SetItemAlloc( IMalloc *pmalloc );
		[PreserveSig]
		HRESULT SetItemAlloc([In] Ole32.IMalloc pmalloc);
	}
}