namespace Vanara.PInvoke;

/// <summary>Methods and data types found in TokenBinding.dll.</summary>
public static partial class TokenBinding
{
	/// <summary>
	/// <para>Specifies the formats that are available to interpret extension data.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/tokenbinding/ne-tokenbinding-tokenbinding_extension_format typedef enum
	// TOKENBINDING_EXTENSION_FORMAT { TOKENBINDING_EXTENSION_FORMAT_UNDEFINED } ;
	[PInvokeData("tokenbinding.h", MSDNShortId = "EBF14890-3F7D-4814-93E1-570E81E05DF2")]
	public enum TOKENBINDING_EXTENSION_FORMAT
	{
		/// <summary>The format for interpreting the extension data is undefined.</summary>
		TOKENBINDING_EXTENSION_FORMAT_UNDEFINED,
	}

	/// <summary>Undocumented.</summary>
	public enum TOKENBINDING_KEY_PARAMETERS_TYPE
	{
		/// <summary>Undocumented.</summary>
		TOKENBINDING_KEY_PARAMETERS_TYPE_RSA2048_PKCS = 0,

		/// <summary>Undocumented.</summary>
		TOKENBINDING_KEY_PARAMETERS_TYPE_RSA2048_PSS = 1,

		/// <summary>Undocumented.</summary>
		TOKENBINDING_KEY_PARAMETERS_TYPE_ECDSAP256 = 2,
	}

	/// <summary>
	/// <para>Specifies the possible types for a token binding.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// More information about the use of these Token Binding types can be found in the <c>Token Binding over HTTP Internet</c> draft.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/tokenbinding/ne-tokenbinding-tokenbinding_type typedef enum TOKENBINDING_TYPE
	// { TOKENBINDING_TYPE_PROVIDED, TOKENBINDING_TYPE_REFERRED } ;
	[PInvokeData("tokenbinding.h", MSDNShortId = "7F126B3E-1033-4C0A-AD5F-0FAD951C85C6")]
	public enum TOKENBINDING_TYPE
	{
		/// <summary>
		/// This type of Token Binding is used to protect tokens issued by the Identity Provider for the client to present with
		/// subsequent requests back to this Identity Provider.
		/// </summary>
		TOKENBINDING_TYPE_PROVIDED,

		/// <summary>
		/// This type of Token Binding is used to protect tokens issued by the Identity Provider for the client to present to a Relying Party.
		/// </summary>
		TOKENBINDING_TYPE_REFERRED,
	}

	/// <summary>
	/// <para>Deletes all token binding keys that are associated with the calling user or app container.</para>
	/// </summary>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// </returns>
	/// <remarks>
	/// <para>You can call <c>TokenBindingDeleteAllBindings</c> from user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/tokenbinding/nf-tokenbinding-tokenbindingdeleteallbindings SECURITY_STATUS
	// TokenBindingDeleteAllBindings( );
	[DllImport(Lib.Tokenbinding, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("tokenbinding.h", MSDNShortId = "0446F62F-96B4-4F4B-9789-0CD12173E601")]
	public static extern HRESULT TokenBindingDeleteAllBindings();

	/// <summary>
	/// <para>Deletes the token binding key that is associated with the specified target string.</para>
	/// </summary>
	/// <param name="targetURL">
	/// <para>The target string for which <c>TokenBindingDeleteBinding</c> should delete the associated token binding key.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// </returns>
	/// <remarks>
	/// <para>You can call <c>TokenBindingDeleteBinding</c> from user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/tokenbinding/nf-tokenbinding-tokenbindingdeletebinding SECURITY_STATUS
	// TokenBindingDeleteBinding( PCWSTR targetURL );
	[DllImport(Lib.Tokenbinding, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("tokenbinding.h", MSDNShortId = "4258CC92-580E-403C-9AE4-4BB726255464")]
	public static extern HRESULT TokenBindingDeleteBinding([MarshalAs(UnmanagedType.LPWStr)] string targetURL);

	/// <summary>
	/// <para>
	/// Constructs one token binding that contains the exported public key and signature by using the specified key type for the token
	/// binding, a target identifier string for creating and retrieving the token binding key, and the unique data. This function also
	/// returns the token binding identifier, if needed.
	/// </para>
	/// </summary>
	/// <param name="keyType">
	/// <para>
	/// The negotiated key type to use. Use a value from the list of key types that you retrieved by calling the
	/// TokenBindingGetKeyTypesClient function.
	/// </para>
	/// </param>
	/// <param name="targetURL">
	/// <para>
	/// The target string to use in conjunction with the key type to generate or retrieve a token binding key for the NCrypt operations
	/// that build the buffer for the tokenBinding parameter.
	/// </para>
	/// </param>
	/// <param name="bindingType">
	/// <para>The type of token binding that <c>TokenBindingGenerateBinding</c> should generate.</para>
	/// </param>
	/// <param name="tlsEKM">
	/// <para>A pointer to the buffer that contains unique data.</para>
	/// </param>
	/// <param name="tlsEKMSize">
	/// <para>The size of the buffer that the tlsUnique parameter points to, in bytes.</para>
	/// </param>
	/// <param name="extensionFormat">
	/// <para>The format to use to interpret the data in the extensionData parameter. This value must be <c>TOKENBINDING_EXTENSION_FORMAT_UNDEFINED</c>.</para>
	/// </param>
	/// <param name="extensionData">
	/// <para>
	/// A pointer to a buffer that contains extension data. The value of the extensionFormat parameter determines how to interpret this data.
	/// </para>
	/// </param>
	/// <param name="tokenBinding">
	/// <para>
	/// A pointer that receives the address of the token binding buffer. Use the HeapAlloc function to allocate the memory for this
	/// buffer, and the HeapFree function to free that memory.
	/// </para>
	/// </param>
	/// <param name="tokenBindingSize">
	/// <para>Pointer to a variable that receives the size of the buffer allocated for the tokenBinding parameter, in bytes.</para>
	/// </param>
	/// <param name="resultData">
	/// <para>
	/// A pointer that receives the address of the buffer that contains result data that includes the token binding identifier of the
	/// token binding that <c>TokenBindingGenerateBinding</c> generates. Use the HeapAlloc function to allocate the memory for this
	/// buffer, and the HeapFree function to free that memory. Specify NULL is you do not need this information.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// </returns>
	/// <remarks>
	/// <para>You can call <c>TokenBindingGenerateBinding</c> from user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/tokenbinding/nf-tokenbinding-tokenbindinggeneratebinding SECURITY_STATUS
	// TokenBindingGenerateBinding( TOKENBINDING_KEY_PARAMETERS_TYPE keyType, PCWSTR targetURL, TOKENBINDING_TYPE bindingType, const void
	// *tlsEKM, DWORD tlsEKMSize, TOKENBINDING_EXTENSION_FORMAT extensionFormat, const void *extensionData, void **tokenBinding, DWORD
	// *tokenBindingSize, TOKENBINDING_RESULT_DATA **resultData );
	[DllImport(Lib.Tokenbinding, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("tokenbinding.h", MSDNShortId = "4289E3F0-17AC-485B-A326-2C8BECD5CABB")]
	public static extern HRESULT TokenBindingGenerateBinding(TOKENBINDING_KEY_PARAMETERS_TYPE keyType, [MarshalAs(UnmanagedType.LPWStr)] string targetURL, TOKENBINDING_TYPE bindingType, [In] IntPtr tlsEKM,
		uint tlsEKMSize, TOKENBINDING_EXTENSION_FORMAT extensionFormat, [In] IntPtr extensionData, out IntPtr tokenBinding, out uint tokenBindingSize, out IntPtr resultData);

	/// <summary>
	/// <para>
	/// Constructs the token binding identifier by extracting the signature algorithm from the key type and copying the exported public key.
	/// </para>
	/// </summary>
	/// <param name="keyType">
	/// <para>
	/// The negotiated key type to use. Use a value from the list of key types that you retrieved by calling the
	/// TokenBindingGetKeyTypesClient function.
	/// </para>
	/// </param>
	/// <param name="publicKey">
	/// <para>An exported public key blob.</para>
	/// </param>
	/// <param name="publicKeySize">
	/// <para>The size of the exported public key blob.</para>
	/// </param>
	/// <param name="resultData">
	/// <para>
	/// A pointer that receives the address of the buffer that is allocated for the token binding result data. The token binding result
	/// data contains the token binding identifier.
	/// </para>
	/// <para>Use the HeapAlloc function to allocate the memory for this buffer, and the HeapFree method to free that memory.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// </returns>
	/// <remarks>
	/// <para>You can call <c>TokenBindingGenerateID</c> from user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/tokenbinding/nf-tokenbinding-tokenbindinggenerateid SECURITY_STATUS
	// TokenBindingGenerateID( TOKENBINDING_KEY_PARAMETERS_TYPE keyType, const void *publicKey, DWORD publicKeySize,
	// TOKENBINDING_RESULT_DATA **resultData );
	[DllImport(Lib.Tokenbinding, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("tokenbinding.h", MSDNShortId = "F3E30DF8-2A1D-445E-914B-62999428BB6F")]
	public static extern HRESULT TokenBindingGenerateID(TOKENBINDING_KEY_PARAMETERS_TYPE keyType, [In] IntPtr publicKey, uint publicKeySize, out IntPtr resultData);

	/// <summary>
	/// <para>Assembles the list of token bindings and generates the final message for the client device to the server.</para>
	/// </summary>
	/// <param name="tokenBindings">
	/// <para>Pointer to an array of token binding structures.</para>
	/// </param>
	/// <param name="tokenBindingsSize">
	/// <para>
	/// An array that contains the sizes of the corresponding token binding structures that the array in the tokenBindings parameter
	/// contains, in bytes.
	/// </para>
	/// </param>
	/// <param name="tokenBindingsCount">
	/// <para>The number of elements that the array in the tokenBindings parameter contains. This value cannot be 0.</para>
	/// </param>
	/// <param name="tokenBindingMessage">
	/// <para>
	/// A pointer that receives the address of the buffer that is allocated for the token binding message. Use the HeapAlloc function to
	/// allocate the memory for this buffer, and the HeapFree method to free that memory.
	/// </para>
	/// </param>
	/// <param name="tokenBindingMessageSize">
	/// <para>A pointer to a variable that contains the size of the buffer allocated for the tokenBindingMessage parameter.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// </returns>
	/// <remarks>
	/// <para>You can call <c>TokenBindingGenerateMessage</c> from user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/tokenbinding/nf-tokenbinding-tokenbindinggeneratemessage SECURITY_STATUS
	// TokenBindingGenerateMessage( const void * [] tokenBindings, const DWORD [] tokenBindingsSize, DWORD tokenBindingsCount, void
	// **tokenBindingMessage, DWORD *tokenBindingMessageSize );
	[DllImport(Lib.Tokenbinding, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("tokenbinding.h", MSDNShortId = "7A268C6D-952B-482A-835D-89D6452D986D")]
	public static extern HRESULT TokenBindingGenerateMessage([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] tokenBindings,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] tokenBindingsSize, uint tokenBindingsCount, out IntPtr tokenBindingMessage, out uint tokenBindingMessageSize);

	/// <summary>
	/// <para>Retrieves a list of the key types that the client device supports.</para>
	/// </summary>
	/// <param name="keyTypes">
	/// <para>
	/// A pointer to a buffer that contains the list of key types that the client device supports. <c>TokenBindingGetKeyTypesClient</c>
	/// returns the string identifiers for well-known algorithms that correspond to the keys that the client device supports. Use
	/// HeapAlloc to allocate the memory for the buffer, and HeapFree to free that memory.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// </returns>
	/// <remarks>
	/// <para>You can call <c>TokenBindingGetKeyTypesClient</c> from user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/tokenbinding/nf-tokenbinding-tokenbindinggetkeytypesclient SECURITY_STATUS
	// TokenBindingGetKeyTypesClient( TOKENBINDING_KEY_TYPES **keyTypes );
	[DllImport(Lib.Tokenbinding, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("tokenbinding.h", MSDNShortId = "583687B6-5A87-4616-A5EE-4FECFF06749E")]
	public static extern HRESULT TokenBindingGetKeyTypesClient(out IntPtr keyTypes);

	/// <summary>
	/// <para>Retrieves a list of the key types that the server supports.</para>
	/// </summary>
	/// <param name="keyTypes">
	/// <para>
	/// A pointer to a buffer that contains the list of key types that the server supports. <c>TokenBindingGetKeyTypesServer</c> returns
	/// the string identifiers for well-known algorithms that correspond to the keys that the server supports.
	/// </para>
	/// <para>
	/// In user mode, use HeapAlloc to allocate the memory for the buffer, and HeapFree to free that memory. In kernel mode, use
	/// ExAllocatePoolWithTag to allocate the memory for the buffer, and ExFreePool to free that memory.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You can call <c>TokenBindingGetKeyTypesServer</c> from both user mode and kernel mode. To call this function in kernel mode, link
	/// to Ksecdd.sys, and use the functions mentioned in the description for the keyTypes parameter for allocating and freeing memory.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/tokenbinding/nf-tokenbinding-tokenbindinggetkeytypesserver SECURITY_STATUS
	// TokenBindingGetKeyTypesServer( TOKENBINDING_KEY_TYPES **keyTypes );
	[DllImport(Lib.Tokenbinding, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("tokenbinding.h", MSDNShortId = "8ABAC0AF-AF68-4742-9C36-3FB17D303409")]
	public static extern HRESULT TokenBindingGetKeyTypesServer(out IntPtr keyTypes);

	/// <summary>
	/// <para>Validates the token binding message and verifies the token bindings that the message contains.</para>
	/// </summary>
	/// <param name="tokenBindingMessage">
	/// <para>A pointer to the buffer that contains the token binding message.</para>
	/// </param>
	/// <param name="tokenBindingMessageSize">
	/// <para>The size of the buffer that the tokenBindingMessage parameter points to, in bytes.</para>
	/// </param>
	/// <param name="keyType">
	/// <para>
	/// The negotiated key algorithm to use. Use a value from the list of key types that you retrieved by calling the
	/// TokenBindingGetKeyTypesServer function.
	/// </para>
	/// </param>
	/// <param name="tlsEKM">
	/// <para>A pointer to a buffer that contains unique data.</para>
	/// </param>
	/// <param name="tlsEKMSize">
	/// <para>The size of the buffer that the tlsUnique parameter points to, in bytes.</para>
	/// </param>
	/// <param name="resultList">
	/// <para>
	/// A pointer that receives the address for the buffer that contains the results for each of the token bindings that
	/// <c>TokenBindingVerifyMessage</c> verifies.
	/// </para>
	/// <para>
	/// In user mode, use HeapAlloc to allocate the memory for the buffer, and HeapFree to free that memory. In kernel mode, use
	/// ExAllocatePoolWithTag to allocate the memory for the buffer, and ExFreePool to free that memory.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You can call <c>TokenBindingVerifyMessage</c> from both user mode and kernel mode. o call this function in kernel mode, link to
	/// Ksecdd.sys, and use the functions mentioned in the description for the resultList parameter for allocating and freeing memory.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/tokenbinding/nf-tokenbinding-tokenbindingverifymessage SECURITY_STATUS
	// TokenBindingVerifyMessage( const void *tokenBindingMessage, DWORD tokenBindingMessageSize, TOKENBINDING_KEY_PARAMETERS_TYPE
	// keyType, const void *tlsEKM, DWORD tlsEKMSize, TOKENBINDING_RESULT_LIST **resultList );
	[DllImport(Lib.Tokenbinding, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("tokenbinding.h", MSDNShortId = "D6827DA3-75DC-4F31-B57A-4ED5B5F03112")]
	public static extern HRESULT TokenBindingVerifyMessage([In] IntPtr tokenBindingMessage, uint tokenBindingMessageSize, TOKENBINDING_KEY_PARAMETERS_TYPE keyType, [In] IntPtr tlsEKM,
		uint tlsEKMSize, out IntPtr resultList);

	/// <summary>
	/// <para>Contains the information for representing a token binding identifier that results from a token binding message exchange.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/tokenbinding/ns-tokenbinding-tokenbinding_identifier typedef struct
	// TOKENBINDING_IDENTIFIER { BYTE keyType; } TOKENBINDING_IDENTIFIER;
	[PInvokeData("tokenbinding.h", MSDNShortId = "301E099E-B621-41E1-BF9B-3AF8C53F9227")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct TOKENBINDING_IDENTIFIER
	{
		/// <summary/>
		public byte keyType;
	}

	/// <summary>
	/// <para>Contains all of the combinations of types of token binding keys that a client device or server supports.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/tokenbinding/ns-tokenbinding-tokenbinding_key_types typedef struct
	// TOKENBINDING_KEY_TYPES { DWORD keyCount; TOKENBINDING_KEY_PARAMETERS_TYPE *keyType; } TOKENBINDING_KEY_TYPES;
	[PInvokeData("tokenbinding.h", MSDNShortId = "E5029CE3-CD23-4566-A951-35374DC7BC57")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct TOKENBINDING_KEY_TYPES
	{
		/// <summary>
		/// <para>The number of elements in the array that the <c>key</c> member contains.</para>
		/// </summary>
		public uint keyCount;

		/// <summary/>
		public IntPtr keyType;
	}

	/// <summary>
	/// <para>
	/// Contains data about the result of generating a token binding or verifying one of the token bindings in a token binding message.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/tokenbinding/ns-tokenbinding-tokenbinding_result_data typedef struct
	// TOKENBINDING_RESULT_DATA { TOKENBINDING_TYPE bindingType; DWORD identifierSize; TOKENBINDING_IDENTIFIER *identifierData;
	// TOKENBINDING_EXTENSION_FORMAT extensionFormat; DWORD extensionSize; PVOID extensionData; } TOKENBINDING_RESULT_DATA;
	[PInvokeData("tokenbinding.h", MSDNShortId = "6C34E174-CCC4-451D-82C3-C410C8C92C8C")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct TOKENBINDING_RESULT_DATA
	{
		/// <summary/>
		public TOKENBINDING_TYPE bindingType;

		/// <summary>
		/// <para>The size of the TOKENBINDING_IDENTIFIER structure that the <c>identifierData</c> member points to, in bytes.</para>
		/// </summary>
		public uint identifierSize;

		/// <summary>
		/// <para>Pointer to the token binding identifier for the token binding that was generated or verified.</para>
		/// </summary>
		public IntPtr identifierData;

		/// <summary>
		/// <para>The format to use to interpret the data in the extensionData parameter. This value must be <c>TOKENBINDING_EXTENSION_FORMAT_UNDEFINED</c>.</para>
		/// </summary>
		public TOKENBINDING_EXTENSION_FORMAT extensionFormat;

		/// <summary>
		/// <para>The size of the buffer that the <c>extensionData</c> member points to, in bytes.</para>
		/// </summary>
		public uint extensionSize;

		/// <summary>
		/// <para>
		/// A pointer to a buffer that contains extension data. The value of the extensionFormat parameter determines how to interpret
		/// this data.
		/// </para>
		/// </summary>
		public IntPtr extensionData;
	}

	/// <summary>
	/// <para>Contains the results for each of the token bindings that TokenBindingVerifyMessage verified.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/tokenbinding/ns-tokenbinding-tokenbinding_result_list typedef struct
	// TOKENBINDING_RESULT_LIST { DWORD resultCount; TOKENBINDING_RESULT_DATA *resultData; } TOKENBINDING_RESULT_LIST;
	[PInvokeData("tokenbinding.h", MSDNShortId = "D14CBEA3-5F46-4C45-8C11-407D6E70FD56")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct TOKENBINDING_RESULT_LIST
	{
		/// <summary>
		/// <para>The number of elements in the array that the <c>resultData</c> member contains.</para>
		/// </summary>
		public uint resultCount;

		/// <summary>
		/// <para>An array of results, one for each of the token bindings that TokenBindingVerifyMessage verified.</para>
		/// </summary>
		public IntPtr resultData;
	}
}