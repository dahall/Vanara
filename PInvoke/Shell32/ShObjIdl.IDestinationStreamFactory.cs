using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke;

/// <summary>Exposes a method for manually copying a stream or file before applying changes to properties.</summary>
/// <remarks>
/// The default copy-on-write behavior provided by IPropertyStore causes the entire source stream to be duplicated during a write
/// operation. This can be costly for large streams, especially when a large portion of the stream is to be changed.
/// <c>IDestinationStreamFactory</c> provides an alternative for the property handler author, who can use it manually to ensure that
/// property changes do not corrupt the stream in case of failure. To do this, the author marks the handler as NoTransactedMode in the
/// handler's CoClass registry key, and queries the stream for this interface.
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-idestinationstreamfactory
[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDestinationStreamFactory")]
[ComImport, Guid("8a87781b-39a7-4a1f-aab3-a39b9c34a7d9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IDestinationStreamFactory
{
	/// <summary>Gets an empty stream that receives the new version of the file being copied.</summary>
	/// <param name="ppstm">
	/// <para>Type: <c>IStream**</c></para>
	/// <para>The address of a pointer to the new stream.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// The property handler author calls <c>IDestinationStreamFactory::GetDestinationStream</c> to get a new empty stream that the new
	/// version of the file will write to. The handler builds the destination stream manually, copying from the source stream as necessary.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idestinationstreamfactory-getdestinationstream
	// HRESULT GetDestinationStream( IStream **ppstm );
	[PreserveSig]
	HRESULT GetDestinationStream(out IStream ppstm);
}