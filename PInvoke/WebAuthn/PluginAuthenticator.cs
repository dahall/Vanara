namespace Vanara.PInvoke;

public static partial class WebAuthn
{
	/// <summary>Specifies whether a plugin authenticator is locked.</summary>
	/// <remarks>Use this enumeration with <c>IPluginAuthenticator::GetLockStatus</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/pluginauthenticator/ne-pluginauthenticator-plugin_lock_status
	// typedef enum _PLUGIN_LOCK_STATUS { PluginLocked = 0, PluginUnlocked = 1 } PLUGIN_LOCK_STATUS;
	[PInvokeData("pluginauthenticator.h", MSDNShortId = "NE:pluginauthenticator._PLUGIN_LOCK_STATUS")]
	public enum PLUGIN_LOCK_STATUS
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>The plugin authenticator is locked.</para>
		/// </summary>
		PluginLocked,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>The plugin authenticator is unlocked.</para>
		/// </summary>
		PluginUnlocked,
	}

	/// <summary>Specifies the encoding used for a plugin authenticator request payload.</summary>
	/// <remarks>Windows currently sends CTAP2 CBOR payloads to plugin authenticators.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/pluginauthenticator/ne-pluginauthenticator-webauthn_plugin_request_type
	// typedef enum _WEBAUTHN_PLUGIN_REQUEST_TYPE { WEBAUTHN_PLUGIN_REQUEST_TYPE_CTAP2_CBOR = 0x1 } WEBAUTHN_PLUGIN_REQUEST_TYPE;
	[PInvokeData("pluginauthenticator.h", MSDNShortId = "NE:pluginauthenticator._WEBAUTHN_PLUGIN_REQUEST_TYPE")]
	public enum WEBAUTHN_PLUGIN_REQUEST_TYPE
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x1</para>
		///   <para>The request payload is encoded as CTAP2 CBOR.</para>
		/// </summary>
		WEBAUTHN_PLUGIN_REQUEST_TYPE_CTAP2_CBOR = 0x1,
	}

	/// <summary>Defines the COM contract that a WebAuthn plugin authenticator implements so Windows can dispatch WebAuthn operations to it.</summary>
	/// <remarks>Implement this interface in the COM class registered as the plugin authenticator. Windows calls these methods to perform makeCredential and getAssertion operations, cancel in-flight work, and query whether the plugin is locked.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/pluginauthenticator/nn-pluginauthenticator-ipluginauthenticator
	[PInvokeData("pluginauthenticator.h", MSDNShortId = "NN:pluginauthenticator.IPluginAuthenticator")]
	[ComImport, Guid("d26bcf6f-b54c-43ff-9f06-d5bf148625f7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPluginAuthenticator
	{
		/// <summary>Creates a credential for a plugin authenticator request.</summary>
		/// <param name="request">A pointer to a <c>WEBAUTHN_PLUGIN_OPERATION_REQUEST</c> structure that describes the operation request.</param>
		/// <param name="response">A pointer to a <c>WEBAUTHN_PLUGIN_OPERATION_RESPONSE</c> structure that receives the encoded response.</param>
		/// <returns>The return value is an <b>HRESULT</b>. A value of <b>S_OK</b> indicates that the call was successful.</returns>
		/// <remarks>This method is typically implemented by decoding the CTAP CBOR request, performing the authenticator operation, and encoding the result into <b>response</b>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/pluginauthenticator/nf-pluginauthenticator-ipluginauthenticator-makecredential
		// HRESULT MakeCredential( PCWEBAUTHN_PLUGIN_OPERATION_REQUEST request, PWEBAUTHN_PLUGIN_OPERATION_RESPONSE response );
		HRESULT MakeCredential(in WEBAUTHN_PLUGIN_OPERATION_REQUEST request, out WEBAUTHN_PLUGIN_OPERATION_RESPONSE response);

		/// <summary>Gets an assertion for a plugin authenticator request.</summary>
		/// <param name="request">A pointer to a <c>WEBAUTHN_PLUGIN_OPERATION_REQUEST</c> structure that describes the operation request.</param>
		/// <param name="response">A pointer to a <c>WEBAUTHN_PLUGIN_OPERATION_RESPONSE</c> structure that receives the encoded response.</param>
		/// <returns>The return value is an <b>HRESULT</b>. A value of <b>S_OK</b> indicates that the call was successful.</returns>
		/// <remarks>This method is typically implemented by decoding the CTAP CBOR request, performing the authenticator operation, and encoding the result into <b>response</b>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/pluginauthenticator/nf-pluginauthenticator-ipluginauthenticator-getassertion
		// HRESULT GetAssertion( PCWEBAUTHN_PLUGIN_OPERATION_REQUEST request, PWEBAUTHN_PLUGIN_OPERATION_RESPONSE response );
		HRESULT GetAssertion(in WEBAUTHN_PLUGIN_OPERATION_REQUEST request, out WEBAUTHN_PLUGIN_OPERATION_RESPONSE response);

		/// <summary>Cancels an in-progress plugin authenticator operation.</summary>
		/// <param name="request">A pointer to a <c>WEBAUTHN_PLUGIN_CANCEL_OPERATION_REQUEST</c> structure that identifies the operation to cancel.</param>
		/// <returns>The return value is an <b>HRESULT</b>. A value of <b>S_OK</b> indicates that the call was successful.</returns>
		/// <remarks>Use the transaction identifier in the request to locate and cancel the matching in-progress operation.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/pluginauthenticator/nf-pluginauthenticator-ipluginauthenticator-canceloperation
		// HRESULT CancelOperation( PCWEBAUTHN_PLUGIN_CANCEL_OPERATION_REQUEST request );
		HRESULT CancelOperation(in WEBAUTHN_PLUGIN_CANCEL_OPERATION_REQUEST request);

		/// <summary>Gets the current lock state of the plugin authenticator.</summary>
		/// <param name="lockStatus">Receives a <c>PLUGIN_LOCK_STATUS</c> value that indicates whether the plugin is locked.</param>
		/// <returns>The return value is an <b>HRESULT</b>. A value of <b>S_OK</b> indicates that the call was successful.</returns>
		/// <remarks>Windows can use the returned lock state to determine whether the plugin authenticator is ready for WebAuthn operations.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/pluginauthenticator/nf-pluginauthenticator-ipluginauthenticator-getlockstatus
		// HRESULT GetLockStatus( PLUGIN_LOCK_STATUS *lockStatus );
		HRESULT GetLockStatus(out PLUGIN_LOCK_STATUS lockStatus);
	}

	/// <summary>Identifies an in-progress plugin authenticator operation to cancel.</summary>
	/// <remarks>Windows passes this structure to <c>IPluginAuthenticator::CancelOperation</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/pluginauthenticator/ns-pluginauthenticator-webauthn_plugin_cancel_operation_request
	// typedef struct _WEBAUTHN_PLUGIN_CANCEL_OPERATION_REQUEST { GUID transactionId; DWORD cbRequestSignature; byte *pbRequestSignature; } WEBAUTHN_PLUGIN_CANCEL_OPERATION_REQUEST, *PWEBAUTHN_PLUGIN_CANCEL_OPERATION_REQUEST;
	[PInvokeData("pluginauthenticator.h", MSDNShortId = "NS:pluginauthenticator._WEBAUTHN_PLUGIN_CANCEL_OPERATION_REQUEST")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_PLUGIN_CANCEL_OPERATION_REQUEST
	{
		/// <summary>The transaction identifier of the operation to cancel.</summary>
		public Guid transactionId;

		/// <summary>The size, in bytes, of the request signature pointed to by <b>pbRequestSignature</b>.</summary>
		public uint cbRequestSignature;

		/// <summary>A pointer to the request signature buffer.</summary>
		[SizeDef(nameof(cbRequestSignature))]
		public ArrayPointer<byte> pbRequestSignature;
	}

	/// <summary>Describes a WebAuthn operation request sent to a plugin authenticator.</summary>
	/// <remarks>Windows passes this structure to <c>IPluginAuthenticator::MakeCredential</c> and <c>IPluginAuthenticator::GetAssertion</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/pluginauthenticator/ns-pluginauthenticator-webauthn_plugin_operation_request
	// typedef struct _WEBAUTHN_PLUGIN_OPERATION_REQUEST { HWND hWnd; GUID transactionId; DWORD cbRequestSignature; byte *pbRequestSignature; WEBAUTHN_PLUGIN_REQUEST_TYPE requestType; DWORD cbEncodedRequest; byte *pbEncodedRequest; } WEBAUTHN_PLUGIN_OPERATION_REQUEST, *PWEBAUTHN_PLUGIN_OPERATION_REQUEST;
	[PInvokeData("pluginauthenticator.h", MSDNShortId = "NS:pluginauthenticator._WEBAUTHN_PLUGIN_OPERATION_REQUEST")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_PLUGIN_OPERATION_REQUEST
	{
		/// <summary>The window handle associated with the request.</summary>
		public HWND hWnd;

		/// <summary>The transaction identifier for the operation.</summary>
		public Guid transactionId;

		/// <summary>The size, in bytes, of the request signature pointed to by <b>pbRequestSignature</b>.</summary>
		public uint cbRequestSignature;

		/// <summary>A pointer to the request signature buffer.</summary>
		[SizeDef(nameof(cbRequestSignature))]
		public ArrayPointer<byte> pbRequestSignature;

		/// <summary>A <c>WEBAUTHN_PLUGIN_REQUEST_TYPE</c> value that identifies the encoding of the request payload.</summary>
		public WEBAUTHN_PLUGIN_REQUEST_TYPE requestType;

		/// <summary>The size, in bytes, of the encoded request payload pointed to by <b>pbEncodedRequest</b>.</summary>
		public uint cbEncodedRequest;

		/// <summary>A pointer to the encoded request payload.</summary>
		[SizeDef(nameof(cbEncodedRequest))]
		public ArrayPointer<byte> pbEncodedRequest;
	}

	/// <summary>Contains the encoded response returned by a plugin authenticator.</summary>
	/// <remarks>A plugin authenticator implementation fills this structure before returning from <c>IPluginAuthenticator::MakeCredential</c> or <c>IPluginAuthenticator::GetAssertion</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/pluginauthenticator/ns-pluginauthenticator-webauthn_plugin_operation_response
	// typedef struct _WEBAUTHN_PLUGIN_OPERATION_RESPONSE { DWORD cbEncodedResponse; byte *pbEncodedResponse; } WEBAUTHN_PLUGIN_OPERATION_RESPONSE, *PWEBAUTHN_PLUGIN_OPERATION_RESPONSE;
	[PInvokeData("pluginauthenticator.h", MSDNShortId = "NS:pluginauthenticator._WEBAUTHN_PLUGIN_OPERATION_RESPONSE")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WEBAUTHN_PLUGIN_OPERATION_RESPONSE
	{
		/// <summary>The size, in bytes, of the encoded response pointed to by <b>pbEncodedResponse</b>.</summary>
		public uint cbEncodedResponse;

		/// <summary>A pointer to the encoded response payload.</summary>
		[SizeDef(nameof(cbEncodedResponse))]
		public ArrayPointer<byte> pbEncodedResponse;
	}
}