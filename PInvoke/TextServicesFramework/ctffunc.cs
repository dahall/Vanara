using Vanara.Collections;
using LPARAM = System.IntPtr;

using WPARAM = System.IntPtr;

namespace Vanara.PInvoke;

public static partial class MSCTF
{
	/// <summary>Specifies the actual confidence for this element.</summary>
	[PInvokeData("sapi.h")]
	public enum SP_CONFIDENCE
	{
		/// <summary>The speech engine has low confidence in the element.</summary>
		SP_LOW_CONFIDENCE = -1,

		/// <summary>The speech engine has normal confidence in the element.</summary>
		SP_NORMAL_CONFIDENCE = 0,

		/// <summary>The speech engine has high confidence in the element.</summary>
		SP_HIGH_CONFIDENCE = 1
	}

	/// <summary>The property UI status.</summary>
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnPropertyUIStatus")]
	public enum TF_PROPUI_STATUS
	{
		/// <summary>The property can be serialized. If this value is not present, the property cannot be serialized.</summary>
		TF_PROPUI_STATUS_SAVETOFILE = 1
	}

	/// <summary>
	/// Elements of the <c>TfCandidateResult</c> enumeration are used with the ITfCandidateList::SetResult method to specify the result
	/// of a reconversion operation performed on a given candidate string.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/ne-ctffunc-tfcandidateresult
	[PInvokeData("ctffunc.h", MSDNShortId = "NE:ctffunc.__MIDL_ITfCandidateList_0001")]
	[Guid("BAA898F2-0207-4643-92CA-F3F7B0CF6F80")]
	public enum TfCandidateResult : uint
	{
		/// <summary>
		/// The candidate string has been selected and accepted. The previous text should be replaced with the specified candidate.
		/// </summary>
		CAND_FINALIZED,

		/// <summary>The candidate string has been selected, but the selection is not yet final.</summary>
		CAND_SELECTED,

		/// <summary>The reconversion operation has been canceled.</summary>
		CAND_CANCELED,
	}

	/// <summary>
	/// Elements of the <c>TfIntegratableCandidateListSelectionStyle</c> enumeration specify the integratable candidate list selection styles.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/ne-ctffunc-tfintegratablecandidatelistselectionstyle
	[PInvokeData("ctffunc.h", MSDNShortId = "NE:ctffunc.__MIDL___MIDL_itf_ctffunc_0000_0022_0001")]
	[Guid("AF8F5D86-0615-4af3-90FA-5DCBB407A5D4")]
	public enum TfIntegratableCandidateListSelectionStyle : uint
	{
		/// <summary>The selection can be changed with the arrow keys.</summary>
		STYLE_ACTIVE_SELECTION,

		/// <summary>The default selection key will choose the selection.</summary>
		STYLE_IMPLIED_SELECTION,
	}

	/// <summary>
	/// Elements of the <c>TfSapiObject</c> enumeration are used with the ITfFnGetSAPIObject::Get method to specify a specific type of
	/// Speech API (SAPI) object.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/ne-ctffunc-tfsapiobject
	[PInvokeData("ctffunc.h", MSDNShortId = "NE:ctffunc.__MIDL___MIDL_itf_ctffunc_0000_0011_0001")]
	[Guid("36ADB6D9-DA1F-45D8-A499-86167E0F936B")]
	public enum TfSapiObject : uint
	{
		/// <summary>Specifies an ISpResourceManager object.</summary>
		GETIF_RESMGR,

		/// <summary>Specifies an ISpRecoContext object.</summary>
		GETIF_RECOCONTEXT,

		/// <summary>Specifies an ISpRecognizer object.</summary>
		GETIF_RECOGNIZER,

		/// <summary>Specifies an ISpVoice object.</summary>
		GETIF_VOICE,

		/// <summary>Specifies an ISpRecoGrammar object.</summary>
		GETIF_DICTGRAM,

		/// <summary>Specifies an ISpRecognizer object. SAPI will not be initialized if it is not already.</summary>
		GETIF_RECOGNIZERNOINIT,
	}

	/// <summary>
	/// Each identifier is specific to a certain language, and these are all specific to the touch keyboard. There is no way to request
	/// support for other layouts, or to add new touch optimized layouts dynamically.
	/// </summary>
	[PInvokeData("ctffunc.h")]
	public enum TKBLayoutId : ushort
	{
		TKBLT_UNDEFINED = 0,
		TKBL_CLASSIC_TRADITIONAL_CHINESE_PHONETIC = 0x0404,
		TKBL_CLASSIC_TRADITIONAL_CHINESE_CHANGJIE = 0xF042,
		TKBL_CLASSIC_TRADITIONAL_CHINESE_DAYI = 0xF043,
		TKBL_OPT_JAPANESE_ABC = 0x0411,
		TKBL_OPT_KOREAN_HANGUL_2_BULSIK = 0x0412,
		TKBL_OPT_SIMPLIFIED_CHINESE_PINYIN = 0x0804,
		TKBL_OPT_TRADITIONAL_CHINESE_PHONETIC = 0x0404,

/* Unmerged change from project 'Vanara.PInvoke.TextServicesFramework (netstandard2.0)'
Before:
#pragma warning restore CA1069 // Enums values should not be duplicated
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
After:
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
*/

/* Unmerged change from project 'Vanara.PInvoke.TextServicesFramework (net48)'
Before:
#pragma warning restore CA1069 // Enums values should not be duplicated
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
After:
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
*/

/* Unmerged change from project 'Vanara.PInvoke.TextServicesFramework (net45)'
Before:
#pragma warning restore CA1069 // Enums values should not be duplicated
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
After:
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
*/
	}

	/// <summary>
	/// Elements of the <c>TKBLayoutType</c> enumeration are passed by an IME in a call to
	/// ITfFnGetPreferredTouchKeyboardLayout::GetLayout to specify the type of layout.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/ne-ctffunc-tkblayouttype
	[PInvokeData("ctffunc.h", MSDNShortId = "NE:ctffunc.__MIDL_ITfFnGetPreferredTouchKeyboardLayout_0001")]
	[Guid("5F309A41-590A-4ACC-A97F-D8EFFF13FDFC")]
	public enum TKBLayoutType : uint
	{
		/// <summary>Undefined. If specified, it will cause the layout to fallback to a classic layout.</summary>
		TKBLT_UNDEFINED,

		/// <summary>The touch keyboard is to use a classic layout.</summary>
		TKBLT_CLASSIC,

		/// <summary>The touch keyboard is to use a touch-optimized layout.</summary>
		TKBLT_OPTIMIZED,
	}

	/// <summary>Undocumented.</summary>
	/// <seealso cref="Vanara.Collections.ICOMEnum{T}"/>
	[PInvokeData("ctffunc.h")]
	[ComImport, Guid("8C5DAC4F-083C-4B85-A4C9-71746048ADCA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumSpeechCommands : ICOMEnum<string>
	{
		/// <summary>Creates a copy of the enumerator object.</summary>
		/// <returns>Pointer to an IEnumSpeechCommands interface pointer that receives the new enumerator.</returns>
		IEnumSpeechCommands Clone();

		/// <summary>Obtains, from the current position, the specified number of elements in the enumeration sequence.</summary>
		/// <param name="ulCount">Specifies the number of elements to obtain.</param>
		/// <param name="pSpCmds">
		/// Pointer to an array of string pointers that receives the requested objects. This array must be at least ulCount elements in size.
		/// </param>
		/// <param name="pcFetched">
		/// Pointer to a ULONG value that receives the number of elements obtained. This value can be less than the number of items
		/// requested. This parameter can be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The method reached the end of the enumeration before the specified number of elements could be obtained.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pSpCmds is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		[PreserveSig]
		HRESULT Next([In] uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pSpCmds, [NullAllowed] out uint pcFetched);

		/// <summary>Resets the enumerator object by moving the current position to the beginning of the enumeration sequence.</summary>
		void Reset();

		/// <summary>Moves the current position forward in the enumeration sequence by the specified number of elements.</summary>
		/// <param name="ulCount">Contains the number of elements to skip.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The method reached the end of the enumeration before the specified number of elements could be skipped.</term>
		/// </item>
		/// </list>
		/// </returns>
		[PreserveSig]
		HRESULT Skip([In] uint ulCount);
	}

	/// <summary>
	/// The <c>IEnumTfCandidates</c> interface is implemented by a text service and used by the TSF manager to provide an enumeration of
	/// candidate string objects.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-ienumtfcandidates
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.IEnumTfCandidates")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("DEFB1926-6C80-4CE8-87D4-D6B72B812BDE")]
	public interface IEnumTfCandidates : ICOMEnum<ITfCandidateString>
	{
		/// <summary>Creates a copy of the enumerator object.</summary>
		/// <param name="ppEnum">Pointer to an IEnumTfCandidates interface pointer that receives the new enumerator.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-ienumtfcandidates-clone HRESULT Clone(
		// IEnumTfCandidates **ppEnum );
		[PreserveSig]
		HRESULT Clone([Out, MarshalAs(UnmanagedType.Interface)] out IEnumTfCandidates ppEnum);

		/// <summary>Obtains, from the current position, the specified number of elements in the enumeration sequence.</summary>
		/// <param name="ulCount">Specifies the number of elements to obtain.</param>
		/// <param name="ppCand">
		/// Pointer to an array of ITfCandidateString interface pointers that receives the requested objects. This array must be at
		/// least ulCount elements in size.
		/// </param>
		/// <param name="pcFetched">
		/// Pointer to a ULONG value that receives the number of elements obtained. This value can be less than the number of items
		/// requested. This parameter can be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The method reached the end of the enumeration before the specified number of elements were obtained.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>ppCand is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-ienumtfcandidates-next HRESULT Next( ULONG ulCount,
		// ITfCandidateString **ppCand, ULONG *pcFetched );
		[PreserveSig]
		HRESULT Next([In] uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] ITfCandidateString[] ppCand, [NullAllowed] out uint pcFetched);

		/// <summary>Resets the enumerator object by moving the current position to the beginning of the enumeration sequence.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-ienumtfcandidates-reset HRESULT Reset();
		[PreserveSig]
		HRESULT Reset();

		/// <summary>Moves the current position forward in the enumeration sequence by the specified number of elements.</summary>
		/// <param name="ulCount">Contains the number of elements to skip.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The method reached the end of the enumeration before the specified number of elements could be skipped.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-ienumtfcandidates-skip HRESULT Skip( ULONG ulCount );
		[PreserveSig]
		HRESULT Skip([In] uint ulCount);
	}

	/// <summary>
	/// The <c>IEnumTfLatticeElements</c> interface is implemented by the TSF manager to provide an enumeration of lattice elements.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-ienumtflatticeelements
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.IEnumTfLatticeElements")]
	[ComImport, Guid("56988052-47DA-4A05-911A-E3D941F17145"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumTfLatticeElements : ICOMEnum<ITfCompositionView>
	{
		/// <summary>Creates a copy of the enumerator object.</summary>
		/// <returns>Pointer to an IEnumTfLatticeElements interface pointer that receives the new enumerator.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-ienumtflatticeelements-clone HRESULT Clone(
		// IEnumTfLatticeElements **ppEnum );
		IEnumTfLatticeElements Clone();

		/// <summary>Obtains the specified number of elements in the enumeration sequence from the current position.</summary>
		/// <param name="ulCount">Specifies the number of elements to obtain.</param>
		/// <param name="rgsElements">
		/// <para>
		/// Pointer to an array of TF_LMLATTELEMENT structures that receives the requested data. This array must be at least ulCount
		/// elements in size.
		/// </para>
		/// <para>
		/// The caller must free the <c>bstrText</c> member of every structure obtained using SysFreeString when it is no longer required.
		/// </para>
		/// </param>
		/// <param name="pcFetched">
		/// Pointer to a ULONG value that receives the number of elements actually obtained. This value can be less than the number of
		/// items requested. This parameter can be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The method reached the end of the enumeration before the specified number of elements could be obtained.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>rgsElements is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-ienumtflatticeelements-next HRESULT Next( ULONG
		// ulCount, TF_LMLATTELEMENT *rgsElements, ULONG *pcFetched );
		[PreserveSig]
		HRESULT Next([In] uint ulCount, [Out] TF_LMLATTELEMENT[] rgsElements, [NullAllowed] out uint pcFetched);

		/// <summary>Resets the enumerator object by moving the current position to the beginning of the enumeration sequence.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-ienumtflatticeelements-reset HRESULT Reset();
		void Reset();

		/// <summary>Moves the current position forward in the enumeration sequence by the specified number of elements.</summary>
		/// <param name="ulCount">Contains the number of elements to skip.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The method reached the end of the enumeration before the specified number of elements could be skipped.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-ienumtflatticeelements-skip HRESULT Skip( ULONG ulCount );
		[PreserveSig]
		HRESULT Skip([In] uint ulCount);
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("ctffunc.h")]
	[ComImport, Guid("38E09D4C-586D-435A-B592-C8A86691DEC6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpeechCommandProvider
	{
		/// <summary>Undocumented.</summary>
		/// <param name="langid">The langid.</param>
		/// <param name="ppEnum">The pp enum.</param>
		/// <returns></returns>
		[PreserveSig]
		HRESULT EnumSpeechCommands([In] LANGID langid, [Out, MarshalAs(UnmanagedType.Interface)] out IEnumSpeechCommands ppEnum);

		/// <summary>Undocumented.</summary>
		/// <param name="pszCommand">The PSZ command.</param>
		/// <param name="cch">The CCH.</param>
		/// <param name="langid">The langid.</param>
		/// <returns></returns>
		[PreserveSig]
		HRESULT ProcessCommand([In, MarshalAs(UnmanagedType.LPWStr)] string pszCommand, [In] uint cch, [In] LANGID langid);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfCandidateString</c> interface is implemented by a text service and is used by the TSF manager or a client to obtain
	/// information about a candidate string object.
	/// </para>
	/// <para>
	/// The TSF manager implements this interface to provide access to this interface to other clients. This enables the TSF manager to
	/// function as a mediator between the client and the text service.
	/// </para>
	/// <para>To obtain an instance of this interface, the TSF manager or client can call ITfCandidateList::GetCandidate.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itfcandidatestring
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfCandidateString")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("581F317E-FD9D-443F-B972-ED00467C5D40")]
	public interface ITfCandidateString
	{
		/// <summary>Obtains the text of the candidate string object.</summary>
		/// <param name="pbstr">
		/// Pointer to a <c>BSTR</c> value that receives the text of the candidate string object. The caller must release this memory
		/// using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstr is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itfcandidatestring-getstring HRESULT GetString( BSTR
		// *pbstr );
		[PreserveSig]
		HRESULT GetString([Out, MarshalAs(UnmanagedType.BStr)] out string pbstr);

		/// <summary>
		/// <para>
		/// <code>pnIndex</code>
		/// </para>
		/// <para>
		/// Pointer to a <c>ULONG</c> value that receives the zero-based index of the candidate string object within the candidate list.
		/// </para>
		/// </summary>
		/// <param name="pnIndex">
		/// Pointer to a <c>ULONG</c> value that receives the zero-based index of the candidate string object within the candidate list.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pnIndex is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itfcandidatestring-getindex HRESULT GetIndex( ULONG
		// *pnIndex );
		[PreserveSig]
		HRESULT GetIndex(out uint pnIndex);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfFnAdviseText</c> interface is implemented by a text service and used by the TSF manager to supply notifications when
	/// the text or lattice element in a context changes.
	/// </para>
	/// <para>
	/// The manager obtains this interface from the text service by calling the text service ITfFunctionProvider::GetFunction interface
	/// with IID_ITfFnAdviseText.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itffnadvisetext
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnAdviseText")]
	[ComImport, Guid("3527268B-7D53-4DD9-92B7-7296AE461249"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfFnAdviseText : ITfFunction
	{
		/// <summary>Obtains the function display name.</summary>
		/// <param name="pbstrName">
		/// Pointer to a BSTR value that receives the display name. This value must be allocated using SysAllocString. The caller must
		/// free this memory using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrName is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunction-getdisplayname HRESULT GetDisplayName( BSTR
		// *pbstrName );
		[PreserveSig]
		new HRESULT GetDisplayName([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

		/// <summary>Called when the text within a context changes.</summary>
		/// <param name="pRange">Pointer to an ITfRange object that represents the range of text that has changed.</param>
		/// <param name="pchText">Pointer to a <c>WCHAR</c> buffer that contains the new text for the range.</param>
		/// <param name="cch">Specifies the number of characters contained in pchText.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnadvisetext-ontextupdate HRESULT OnTextUpdate(
		// ITfRange *pRange, const WCHAR *pchText, LONG cch );
		[PreserveSig]
		HRESULT OnTextUpdate([In] ITfRange pRange, [In, MarshalAs(UnmanagedType.LPWStr)] string pchText, int cch);

		/// <summary>Called when a lattice element within a context changes.</summary>
		/// <param name="pRange">Pointer to an ITfRange object that represents the range of text that changed.</param>
		/// <param name="pLattice">Pointer to an ITfLMLattice object that represents the new lattice element.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnadvisetext-onlatticeupdate HRESULT
		// OnLatticeUpdate( ITfRange *pRange, ITfLMLattice *pLattice );
		[PreserveSig]
		HRESULT OnLatticeUpdate([In] ITfRange pRange, [In] ITfLMLattice pLattice);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfFnBalloon</c> interface is implemented by a text service and is used by an application or other text service to update
	/// the balloon item that the text service adds to the language bar.
	/// </para>
	/// <para>
	/// An application or text service obtains an instance of this interface by calling ITfThreadMgr::GetFunctionProvider with the class
	/// identifier of the text service and then calling ITfFunctionProvider::GetFunction with GUID_NULL and IID_ITfFnBalloon.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itffnballoon
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnBalloon")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("3BAB89E4-5FBE-45F4-A5BC-DCA36AD225A8")]
	public interface ITfFnBalloon
	{
		/// <summary>Changes the style and text of a language bar balloon item.</summary>
		/// <param name="style">Contains one of the TfLBBalloonStyle values that specifies the new balloon style.</param>
		/// <param name="pch">Pointer to a <c>WCHAR</c> buffer that contains the new text for the balloon.</param>
		/// <param name="cch">Contains the number of characters of the new text in pch.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The language bar balloon implementation should update its style and text by modifying the values returned from
		/// ITfLangBarItemBalloon::GetBalloonInfo and then call ITfLangBarItemSink::OnUpdate with TF_LBI_BALLOON to cause the language
		/// bar to obtain the updated information.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnballoon-updateballoon HRESULT UpdateBalloon(
		// TfLBBalloonStyle style, const WCHAR *pch, ULONG cch );
		[PreserveSig]
		HRESULT UpdateBalloon([In] TfLBBalloonStyle style, [In, MarshalAs(UnmanagedType.LPWStr)] string pch, uint cch);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfFnConfigure</c> interface is implemented by a text service to enable the Text Services control panel application to
	/// allow the text service to display a configuration dialog box.
	/// </para>
	/// <para>
	/// The Text Services control panel application obtains an instance of this interface by calling CoCreateInstance with the class
	/// identifier passed to ITfInputProcessorProfiles::Register and IID_ITfFnConfigure.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itffnconfigure
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnConfigure")]
	[ComImport, Guid("88F567C6-1757-49F8-A1B2-89234C1EEFF9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfFnConfigure : ITfFunction
	{
		/// <summary>Obtains the function display name.</summary>
		/// <param name="pbstrName">
		/// Pointer to a BSTR value that receives the display name. This value must be allocated using SysAllocString. The caller must
		/// free this memory using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrName is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunction-getdisplayname HRESULT GetDisplayName( BSTR
		// *pbstrName );
		[PreserveSig]
		new HRESULT GetDisplayName([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

		/// <summary>
		/// Called when the user opens the Text Services control panel application, selects the text service from the list and presses
		/// the Properties pushbutton.
		/// </summary>
		/// <param name="hwndParent">
		/// Handle of the parent window. The text service typically uses this as the parent or owner window when creating a dialog box.
		/// </param>
		/// <param name="langid">
		/// Contains a <c>LANGID</c> value that specifies the identifier of the language selected in the Text Services control panel application.
		/// </param>
		/// <param name="rguidProfile">
		/// Contains a GUID value that specifies the language profile identifier that the text service is under. This is the value
		/// specified in ITfInputProcessorProfiles::AddLanguageProfile when the profile was added.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>This method should not return until the user closes the dialog box or property sheet.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnconfigure-show HRESULT Show( HWND hwndParent,
		// LANGID langid, REFGUID rguidProfile );
		[PreserveSig]
		HRESULT Show([In] HWND hwndParent, [In] LANGID langid, in Guid rguidProfile);
	}

	/// <summary>
	/// The <c>ITfFnConfigureRegisterEudc</c> interface is implemented by a text service to provide the UI to register the key sequence
	/// for the given EUDC.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itffnconfigureregistereudc
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnConfigureRegisterEudc")]
	[ComImport, Guid("B5E26FF5-D7AD-4304-913F-21A2ED95A1B0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfFnConfigureRegisterEudc : ITfFunction
	{
		/// <summary>Obtains the function display name.</summary>
		/// <param name="pbstrName">
		/// Pointer to a BSTR value that receives the display name. This value must be allocated using SysAllocString. The caller must
		/// free this memory using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrName is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunction-getdisplayname HRESULT GetDisplayName( BSTR
		// *pbstrName );
		[PreserveSig]
		new HRESULT GetDisplayName([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

		/// <summary>The ITfFnConfigureRegisterEudc::Show method shows the EUDC key sequence register UI.</summary>
		/// <param name="hwndParent">
		/// [in] Handle of the parent window. The text service typically uses this as the parent or owner window when creating a dialog box.
		/// </param>
		/// <param name="langid">[in] Contains a LANGID value that specifies the identifier of the language.</param>
		/// <param name="rguidProfile">
		/// [in] Contains a GUID value that specifies the language profile identifier that the text service is under.
		/// </param>
		/// <param name="bstrRegistered">
		/// [in, unique] Contains a BSTR that contains the EUDC to be registered with the text service. This is optional and can be
		/// <c>NULL</c>. If <c>NULL</c>, the text service should display a default register EUDC dialog box.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnconfigureregistereudc-show HRESULT Show( HWND
		// hwndParent, LANGID langid, REFGUID rguidProfile, BSTR bstrRegistered );
		[PreserveSig]
		HRESULT Show([In] HWND hwndParent, [In] LANGID langid, in Guid rguidProfile, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? bstrRegistered);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfFnConfigureRegisterWord</c> interface is implemented by a text service to enable the Active Input Method Editor (IME)
	/// to cause the text service to display a word registration dialog box.
	/// </para>
	/// <para>To obtain an instance of this interface the IME can call ITfFunctionProvider::GetFunction with IID_ITfFnConfigureRegisterWord.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itffnconfigureregisterword
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnConfigureRegisterWord")]
	[ComImport, Guid("BB95808A-6D8F-4BCA-8400-5390B586AEDF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfFnConfigureRegisterWord : ITfFunction
	{
		/// <summary>Obtains the function display name.</summary>
		/// <param name="pbstrName">
		/// Pointer to a BSTR value that receives the display name. This value must be allocated using SysAllocString. The caller must
		/// free this memory using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrName is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunction-getdisplayname HRESULT GetDisplayName( BSTR
		// *pbstrName );
		[PreserveSig]
		new HRESULT GetDisplayName([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

		/// <summary>Called to cause the text service to display a dialog box to register a word with the text service.</summary>
		/// <param name="hwndParent">
		/// Handle of the parent window. The text service typically uses this as the parent or owner window when creating the dialog box.
		/// </param>
		/// <param name="langid">
		/// Contains a <c>LANGID</c> that specifies the identifier of the language currently used by the Input Method Editor (IME).
		/// </param>
		/// <param name="rguidProfile">
		/// Contains a GUID that specifies the language profile identifier that the text service is under. This is the value specified
		/// in ITfInputProcessorProfiles::AddLanguageProfile when the profile was added.
		/// </param>
		/// <param name="bstrRegistered">
		/// Contains a <c>BSTR</c> that contains the word to be registered with the text service. This is optional and can be NULL. If
		/// NULL, the text service should display a default register word dialog box.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The text service does not implement this method.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnconfigureregisterword-show HRESULT Show( HWND
		// hwndParent, LANGID langid, REFGUID rguidProfile, BSTR bstrRegistered );
		[PreserveSig]
		HRESULT Show([In] HWND hwndParent, [In] LANGID langid, in Guid rguidProfile, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? bstrRegistered);
	}

	/// <summary>Undocumented.</summary>
	/// <seealso cref="Vanara.PInvoke.MSCTF.ITfFunction"/>
	[PInvokeData("ctffunc.h")]
	[ComImport, Guid("FCA6C349-A12F-43A3-8DD6-5A5A4282577B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfFnCustomSpeechCommand : ITfFunction
	{
		/// <summary>Obtains the function display name.</summary>
		/// <param name="pbstrName">
		/// Pointer to a BSTR value that receives the display name. This value must be allocated using SysAllocString. The caller must
		/// free this memory using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrName is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunction-getdisplayname HRESULT GetDisplayName( BSTR
		// *pbstrName );
		[PreserveSig]
		new HRESULT GetDisplayName([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

		/// <summary>Undocumented.</summary>
		/// <param name="pspcmdProvider">Undocumented.</param>
		/// <returns>Undocumented.</returns>
		[PreserveSig]
		HRESULT SetSpeechCommandProvider([In, MarshalAs(UnmanagedType.IUnknown)] object pspcmdProvider);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfFnGetPreferredTouchKeyboardLayout</c> interface is implemented by a text service to specify the use of a particular
	/// keyboard layout supported by the inbox Windows 8 touch keyboard.
	/// </para>
	/// <para>
	/// When an IME is active the touch keyboard will use ITfFunctionProvider::GetFunction with
	/// <c>IID_ITfFnGetPreferredTouchKeyboardLayout</c> to query the IME for this function.
	/// </para>
	/// <para>If the function is not supported by the IME, then the touch keyboard will show the default layout for the language.</para>
	/// </summary>
	/// <remarks>
	/// <para>For more information on the layouts which can be specified, see GetLayout.</para>
	/// <para>
	/// This interface applies only to IMEs written using the Text Services Framework and not to legacy IMM32 IMEs, and it only applies
	/// to the following input languages:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Japanese</term>
	/// </item>
	/// <item>
	/// <term>Korean</term>
	/// </item>
	/// <item>
	/// <term>Simplified Chinese</term>
	/// </item>
	/// <item>
	/// <term>Traditional Chinese</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itffngetpreferredtouchkeyboardlayout
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnGetPreferredTouchKeyboardLayout")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5F309A41-590A-4ACC-A97F-D8EFFF13FDFC")]
	public interface ITfFnGetPreferredTouchKeyboardLayout
	{
		/// <summary>
		/// Obtains the touch keyboard layout identifier of the layout that the IME directs the touch keyboard to show while the IME is active.
		/// </summary>
		/// <param name="pTKBLayoutType">Pointer to a TKBLayoutType enumeration that receives the layout type.</param>
		/// <param name="pwPreferredLayoutId">Pointer to a <c>WORD</c> value that receives the layout identifier.</param>
		/// <returns>The touch keyboard always expects S_OK.</returns>
		/// <remarks>
		/// <para>TKBLayoutType is an enumeration with the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>TKBLT_UNDEFINED</term>
		/// <term>Undefined.</term>
		/// </listheader>
		/// <item>
		/// <term>TKBLT_CLASSIC</term>
		/// <term>The touch keyboard is to use a classic layout. Classic layouts represent the legacy layouts of physical keyboards.</term>
		/// </item>
		/// <item>
		/// <term>TKBLT_OPTIMIZED</term>
		/// <term>
		/// The touch keyboard is to use a touch-optimized layout. Touch-optimized layouts have been specifically designed with touch in mind.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The layout identifiers returned by this API must be one from the following list. Each identifier is specific to a certain
		/// language, and these are all specific to the touch keyboard. There is no way to request support for other layouts, or to add
		/// new touch optimized layouts dynamically.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Layout Definition</term>
		/// <term>Value</term>
		/// <term>Supported Input Language</term>
		/// </listheader>
		/// <item>
		/// <term>TKBL_UNDEFINED</term>
		/// <term>0</term>
		/// <term>n/a</term>
		/// </item>
		/// <item>
		/// <term>TKBL_CLASSIC_TRADITIONAL_CHINESE_PHONETIC</term>
		/// <term>0x0404</term>
		/// <term>CHT</term>
		/// </item>
		/// <item>
		/// <term>TKBL_CLASSIC_TRADITIONAL_CHINESE_CHANGJIE</term>
		/// <term>0xF042</term>
		/// <term>CHT</term>
		/// </item>
		/// <item>
		/// <term>TKBL_CLASSIC_TRADITIONAL_CHINESE_DAYI</term>
		/// <term>0xF043</term>
		/// <term>CHT</term>
		/// </item>
		/// <item>
		/// <term>TKBL_OPT_JAPANESE_ABC</term>
		/// <term>0x0411</term>
		/// <term>JPN</term>
		/// </item>
		/// <item>
		/// <term>TKBL_OPT_KOREAN_HANGUL_2_BULSIK</term>
		/// <term>0x0412</term>
		/// <term>KOR</term>
		/// </item>
		/// <item>
		/// <term>TKBL_OPT_SIMPLIFIED_CHINESE_PINYIN</term>
		/// <term>0x0804</term>
		/// <term>CHS</term>
		/// </item>
		/// <item>
		/// <term>TKBL_OPT_TRADITIONAL_CHINESE_PHONETIC</term>
		/// <term>0x0404</term>
		/// <term>CHT</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffngetpreferredtouchkeyboardlayout-getlayout HRESULT
		// GetLayout( TKBLayoutType *pTKBLayoutType, WORD *pwPreferredLayoutId );
		[PreserveSig]
		HRESULT GetLayout(out TKBLayoutType pTKBLayoutType, out TKBLayoutId pwPreferredLayoutId);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfFnGetSAPIObject</c> interface is implemented by the Speech API (SAPI) text service. This interface is used by the TSF
	/// manager or a client (application or other text service) to obtain various SAPI objects.
	/// </para>
	/// <para>
	/// A client obtains an instance of this interface by obtaining the ITfFunctionProvider for the SAPI text service and calling
	/// ITfFunctionProvider::GetFunction with IID_ITfFnGetSAPIObject.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itffngetsapiobject
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnGetSAPIObject")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5C0AB7EA-167D-4F59-BFB5-4693755E90CA")]
	public interface ITfFnGetSAPIObject : ITfFunction
	{
		/// <summary>Obtains the function display name.</summary>
		/// <param name="pbstrName">
		/// Pointer to a BSTR value that receives the display name. This value must be allocated using SysAllocString. The caller must
		/// free this memory using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrName is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunction-getdisplayname HRESULT GetDisplayName( BSTR
		// *pbstrName );
		[PreserveSig]
		new HRESULT GetDisplayName([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

		/// <summary>Obtains a specified SAPI object.</summary>
		/// <param name="sObj">Contains a TfSapiObject value that specifies the SAPI object to obtain.</param>
		/// <param name="ppunk">
		/// Pointer to an <c>IUnknown</c> interface pointer that receives the requested SAPI object. The caller must release this
		/// interface when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The requested object cannot be obtained.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The requested object is not implemented.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffngetsapiobject-get HRESULT Get( TfSapiObject sObj,
		// IUnknown **ppunk );
		[PreserveSig]
		HRESULT Get([In] TfSapiObject sObj, [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppunk);
	}

	/// <summary>
	/// The <c>ITfFnLangProfileUtil</c> interface is implemented by the speech text service and used to provide utility methods for the
	/// speech text service. A text service can create an instance of this interface by calling CoCreateInstance with CLSID_SapiLayr and IID_ITfFnLangProfileUtil.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itffnlangprofileutil
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnLangProfileUtil")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("A87A8574-A6C1-4E15-99F0-3D3965F548EB")]
	public interface ITfFnLangProfileUtil : ITfFunction
	{
		/// <summary>Obtains the function display name.</summary>
		/// <param name="pbstrName">
		/// Pointer to a BSTR value that receives the display name. This value must be allocated using SysAllocString. The caller must
		/// free this memory using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrName is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunction-getdisplayname HRESULT GetDisplayName( BSTR
		// *pbstrName );
		[PreserveSig]
		new HRESULT GetDisplayName([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

		/// <summary>Causes the speech text service to register its active profiles.</summary>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The speech text service removed its active profiles based on user actions.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlangprofileutil-registeractiveprofiles HRESULT RegisterActiveProfiles();
		[PreserveSig]
		HRESULT RegisterActiveProfiles();

		/// <summary>Determines if the speech text service has a profile available for a specific language.</summary>
		/// <param name="langid">Contains a <c>LANGID</c> that specifies the language that the query applies to.</param>
		/// <param name="pfAvailable">
		/// Pointer to a <c>BOOL</c> that receives nonzero if a profile is available for the language identified by langid or zero otherwise.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pfAvailable is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlangprofileutil-isprofileavailableforlang HRESULT
		// IsProfileAvailableForLang( LANGID langid, BOOL *pfAvailable );
		[PreserveSig]
		HRESULT IsProfileAvailableForLang([In] LANGID langid, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfAvailable);
	}

	/// <summary>The <c>ITfFnLMInternal</c> interface is not used.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itffnlminternal
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnLMInternal")]
	[ComImport, Guid("04B825B1-AC9A-4F7B-B5AD-C7168F1EE445"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfFnLMInternal : ITfFnLMProcessor
	{
		/// <summary>Obtains the function display name.</summary>
		/// <param name="pbstrName">
		/// Pointer to a BSTR value that receives the display name. This value must be allocated using SysAllocString. The caller must
		/// free this memory using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrName is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunction-getdisplayname HRESULT GetDisplayName( BSTR
		// *pbstrName );
		[PreserveSig]
		new HRESULT GetDisplayName([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

		/// <summary>Obtains the range of text that a reconversion applies to.</summary>
		/// <param name="pRange">Pointer to an ITfRange object that covers all or part of the text to be reconverted.</param>
		/// <param name="ppNewRange">
		/// <para>
		/// Pointer to an ITfRange pointer that receives a range object that covers all of the text that can be reconverted. If none of
		/// the text covered by pRange can be reconverted, this parameters receives <c>NULL</c>. In this case, the method will return
		/// S_OK; the caller must verify that this parameter is not <c>NULL</c> before using the pointer.
		/// </para>
		/// <para>This parameter is optional and can be <c>NULL</c>. In this case, the range is not required.</para>
		/// </param>
		/// <param name="pfAccepted">
		/// Pointer to a <c>BOOL</c> value that receives zero if none of the text covered by pRange can be reconverted or nonzero otherwise.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method is identical to ITfFnReconversion::QueryRange. When <c>ITfFnReconversion::QueryRange</c> is called in the text
		/// service, the text service should forward the call to this method if a language model processor is installed. If no language
		/// model processor is installed, the text service should perform its default processing.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlmprocessor-queryrange HRESULT QueryRange(
		// ITfRange *pRange, ITfRange **ppNewRange, BOOL *pfAccepted );
		[PreserveSig]
		new HRESULT QueryRange([In] ITfRange pRange, out ITfRange ppNewRange, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfAccepted);

		/// <summary>Determines if the language model text service supports a particular language.</summary>
		/// <param name="langid">Contains a <c>LANGID</c> that specifies the identifier of the language that the query applies to.</param>
		/// <param name="pfAccepted">
		/// Pointer to a <c>BOOL</c> value that receives nonzero if the language model text service supports the language identified by
		/// langid or zero otherwise.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pfAccepted is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>If a client can possibly generate more than one language identifier of text, it should query all with this method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlmprocessor-querylangid HRESULT QueryLangID(
		// LANGID langid, BOOL *pfAccepted );
		[PreserveSig]
		new HRESULT QueryLangID([In] LANGID langid, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfAccepted);

		/// <summary>Obtains an ITfCandidateList object for a range from the language model text service.</summary>
		/// <param name="pRange">
		/// Pointer to an ITfRange object that covers the text to be reconverted. To obtain this range object, call ITfFnReconversion::QueryRange.
		/// </param>
		/// <param name="ppCandList">Pointer to an <c>ITfCandidateList</c> pointer that receives the candidate list object.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method is identical to ITfFnReconversion::GetReconversion. When <c>ITfFnReconversion::GetReconversion</c> is called in
		/// the text service, the text service should forward the call to this method if a language model processor is installed. If no
		/// language model processor is installed, the text service should perform its default processing.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlmprocessor-getreconversion HRESULT
		// GetReconversion( ITfRange *pRange, ITfCandidateList **ppCandList );
		[PreserveSig]
		new HRESULT GetReconversion([In] ITfRange pRange, out ITfCandidateList ppCandList);

		/// <summary>Invokes the reconversion process in the language model text service for a range.</summary>
		/// <param name="pRange">Pointer to an ITfRange object that covers the text to reconvert.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pRange is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method is identical to ITfFnReconversion::Reconvet. When <c>ITfFnReconversion::Reconvet</c> is called in the text
		/// service, the text service should forward the call to this method if a language model processor is installed. If no language
		/// model processor is installed, the text service should perform its default processing.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlmprocessor-reconvert HRESULT Reconvert( ITfRange
		// *pRange );
		[PreserveSig]
		new HRESULT Reconvert([In] ITfRange pRange);

		/// <summary>Called to determine if the language model text service handles a key event.</summary>
		/// <param name="fUp">
		/// Contains a <c>BOOL</c> that specifies if this is a key-down or a key-up event. Contains zero if this is a key-down event or
		/// nonzero otherwise.
		/// </param>
		/// <param name="vKey">
		/// Contains the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="lparamKeydata">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="pfInterested">
		/// Pointer to a <c>BOOL</c> that receives nonzero if the language model text service will handle the key event or zero otherwise.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlmprocessor-querykey HRESULT QueryKey( BOOL fUp,
		// WPARAM vKey, LPARAM lparamKeydata, BOOL *pfInterested );
		[PreserveSig]
		new HRESULT QueryKey(int fUp, [In] WPARAM vKey, [In] LPARAM lparamKeydata, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfInterested);

		/// <summary>Called to enable the language model text service to process a key event.</summary>
		/// <param name="fUp">
		/// Contains a <c>BOOL</c> that specifies if this is a key-down or a key-up event. Contains zero if this is a key-down event or
		/// nonzero otherwise.
		/// </param>
		/// <param name="vKey">
		/// Contains the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="lparamKeydata">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYDOWN.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlmprocessor-invokekey HRESULT InvokeKey( BOOL fUp,
		// WPARAM vKey, LPARAM lparamKeyData );
		[PreserveSig]
		new HRESULT InvokeKey(int fUp, [In] WPARAM vKey, [In] LPARAM lparamKeydata);

		/// <summary>Invokes a function of the language model text service.</summary>
		/// <param name="pic">Pointer to an ITfContext interface that represents context to perform the function on.</param>
		/// <param name="refguidFunc">
		/// Contains a GUID that specifies the function to invoke. Possible values for this parameter are defined by the language model
		/// text service provider.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlmprocessor-invokefunc HRESULT InvokeFunc(
		// ITfContext *pic, REFGUID refguidFunc );
		[PreserveSig]
		new HRESULT InvokeFunc([In] ITfContext pic, in Guid refguidFunc);

		/// <summary>Not used.</summary>
		/// <param name="pRange">Not used.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlminternal-processlattice HRESULT ProcessLattice(
		// ITfRange *pRange );
		[PreserveSig]
		HRESULT ProcessLattice([In] ITfRange pRange);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfFnLMProcessor</c> interface is implemented by the language model text service and is used by an application or text
	/// service to enable alternate language model processing.
	/// </para>
	/// <para>
	/// The application or text service obtains this interface from a thread manager object by calling ITfThreadMgr::GetFunctionProvider
	/// with GUID_MASTERLM_FUNCTIONPROVIDER and then calling ITfFunctionProvider::GetFunction interface with IID_ITfFnLMProcessor. If
	/// <c>ITfThreadMgr::GetFunctionProvider</c> fails, then no language model processor is installed.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itffnlmprocessor
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnLMProcessor")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("7AFBF8E7-AC4B-4082-B058-890899D3A010")]
	public interface ITfFnLMProcessor : ITfFunction
	{
		/// <summary>Obtains the function display name.</summary>
		/// <param name="pbstrName">
		/// Pointer to a BSTR value that receives the display name. This value must be allocated using SysAllocString. The caller must
		/// free this memory using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrName is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunction-getdisplayname HRESULT GetDisplayName( BSTR
		// *pbstrName );
		[PreserveSig]
		new HRESULT GetDisplayName([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

		/// <summary>Obtains the range of text that a reconversion applies to.</summary>
		/// <param name="pRange">Pointer to an ITfRange object that covers all or part of the text to be reconverted.</param>
		/// <param name="ppNewRange">
		/// <para>
		/// Pointer to an ITfRange pointer that receives a range object that covers all of the text that can be reconverted. If none of
		/// the text covered by pRange can be reconverted, this parameters receives <c>NULL</c>. In this case, the method will return
		/// S_OK; the caller must verify that this parameter is not <c>NULL</c> before using the pointer.
		/// </para>
		/// <para>This parameter is optional and can be <c>NULL</c>. In this case, the range is not required.</para>
		/// </param>
		/// <param name="pfAccepted">
		/// Pointer to a <c>BOOL</c> value that receives zero if none of the text covered by pRange can be reconverted or nonzero otherwise.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method is identical to ITfFnReconversion::QueryRange. When <c>ITfFnReconversion::QueryRange</c> is called in the text
		/// service, the text service should forward the call to this method if a language model processor is installed. If no language
		/// model processor is installed, the text service should perform its default processing.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlmprocessor-queryrange HRESULT QueryRange(
		// ITfRange *pRange, ITfRange **ppNewRange, BOOL *pfAccepted );
		[PreserveSig]
		HRESULT QueryRange([In] ITfRange pRange, out ITfRange ppNewRange, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfAccepted);

		/// <summary>Determines if the language model text service supports a particular language.</summary>
		/// <param name="langid">Contains a <c>LANGID</c> that specifies the identifier of the language that the query applies to.</param>
		/// <param name="pfAccepted">
		/// Pointer to a <c>BOOL</c> value that receives nonzero if the language model text service supports the language identified by
		/// langid or zero otherwise.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pfAccepted is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>If a client can possibly generate more than one language identifier of text, it should query all with this method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlmprocessor-querylangid HRESULT QueryLangID(
		// LANGID langid, BOOL *pfAccepted );
		[PreserveSig]
		HRESULT QueryLangID([In] LANGID langid, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfAccepted);

		/// <summary>Obtains an ITfCandidateList object for a range from the language model text service.</summary>
		/// <param name="pRange">
		/// Pointer to an ITfRange object that covers the text to be reconverted. To obtain this range object, call ITfFnReconversion::QueryRange.
		/// </param>
		/// <param name="ppCandList">Pointer to an <c>ITfCandidateList</c> pointer that receives the candidate list object.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method is identical to ITfFnReconversion::GetReconversion. When <c>ITfFnReconversion::GetReconversion</c> is called in
		/// the text service, the text service should forward the call to this method if a language model processor is installed. If no
		/// language model processor is installed, the text service should perform its default processing.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlmprocessor-getreconversion HRESULT
		// GetReconversion( ITfRange *pRange, ITfCandidateList **ppCandList );
		[PreserveSig]
		HRESULT GetReconversion([In] ITfRange pRange, out ITfCandidateList ppCandList);

		/// <summary>Invokes the reconversion process in the language model text service for a range.</summary>
		/// <param name="pRange">Pointer to an ITfRange object that covers the text to reconvert.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pRange is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method is identical to ITfFnReconversion::Reconvet. When <c>ITfFnReconversion::Reconvet</c> is called in the text
		/// service, the text service should forward the call to this method if a language model processor is installed. If no language
		/// model processor is installed, the text service should perform its default processing.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlmprocessor-reconvert HRESULT Reconvert( ITfRange
		// *pRange );
		[PreserveSig]
		HRESULT Reconvert([In] ITfRange pRange);

		/// <summary>Called to determine if the language model text service handles a key event.</summary>
		/// <param name="fUp">
		/// Contains a <c>BOOL</c> that specifies if this is a key-down or a key-up event. Contains zero if this is a key-down event or
		/// nonzero otherwise.
		/// </param>
		/// <param name="vKey">
		/// Contains the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="lparamKeydata">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="pfInterested">
		/// Pointer to a <c>BOOL</c> that receives nonzero if the language model text service will handle the key event or zero otherwise.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlmprocessor-querykey HRESULT QueryKey( BOOL fUp,
		// WPARAM vKey, LPARAM lparamKeydata, BOOL *pfInterested );
		[PreserveSig]
		HRESULT QueryKey(int fUp, [In] WPARAM vKey, [In] LPARAM lparamKeydata, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfInterested);

		/// <summary>Called to enable the language model text service to process a key event.</summary>
		/// <param name="fUp">
		/// Contains a <c>BOOL</c> that specifies if this is a key-down or a key-up event. Contains zero if this is a key-down event or
		/// nonzero otherwise.
		/// </param>
		/// <param name="vKey">
		/// Contains the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="lparamKeydata">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYDOWN.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlmprocessor-invokekey HRESULT InvokeKey( BOOL fUp,
		// WPARAM vKey, LPARAM lparamKeyData );
		[PreserveSig]
		HRESULT InvokeKey(int fUp, [In] WPARAM vKey, [In] LPARAM lparamKeydata);

		/// <summary>Invokes a function of the language model text service.</summary>
		/// <param name="pic">Pointer to an ITfContext interface that represents context to perform the function on.</param>
		/// <param name="refguidFunc">
		/// Contains a GUID that specifies the function to invoke. Possible values for this parameter are defined by the language model
		/// text service provider.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnlmprocessor-invokefunc HRESULT InvokeFunc(
		// ITfContext *pic, REFGUID refguidFunc );
		[PreserveSig]
		HRESULT InvokeFunc([In] ITfContext pic, in Guid refguidFunc);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfFnPlayBack</c> interface is implemented by the Speech API (SAPI) text service. This interface is used by the TSF
	/// manager or a client (application or other text service) to control the audio data for speech input text.
	/// </para>
	/// <para>
	/// Each spoken word or phrase has audio data stored with the text. This interface is used to obtain the range that covers the
	/// spoken text and to play back the audio data.
	/// </para>
	/// <para>
	/// A client obtains an instance of this interface by obtaining the ITfFunctionProvider for the SAPI text service and calling
	/// ITfFunctionProvider::GetFunction with IID_ITfFnPlayBack.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itffnplayback
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnPlayBack")]
	[ComImport, Guid("A3A416A4-0F64-11D3-B5B7-00C04FC324A1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfFnPlayBack : ITfFunction
	{
		/// <summary>Obtains the function display name.</summary>
		/// <param name="pbstrName">
		/// Pointer to a BSTR value that receives the display name. This value must be allocated using SysAllocString. The caller must
		/// free this memory using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrName is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunction-getdisplayname HRESULT GetDisplayName( BSTR
		// *pbstrName );
		[PreserveSig]
		new HRESULT GetDisplayName([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

		/// <summary>Obtains the range of text for a word or phrase that contains audio data.</summary>
		/// <param name="pRange">Pointer to an ITfRange object that covers all or part of the text that contains audio data.</param>
		/// <param name="ppNewRange">
		/// Pointer to an ITfRange pointer that receives a range object that covers all of the text that contains audio data. If there
		/// is no audio data for the text covered by pRange, this parameters receives <c>NULL</c>. In this case, the method returns
		/// S_OK, so the caller must verify that this parameter is not <c>NULL</c> before using the pointer.
		/// </param>
		/// <param name="pfPlayable">
		/// Pointer to a <c>BOOL</c> that receives zero if none of the text covered by pRange has any audio data or nonzero otherwise.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The current implementation of this method is simple. It clones pRange, places the clone in ppNewRange, sets pfPlayable to
		/// <c>TRUE</c> and returns S_OK.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnplayback-queryrange HRESULT QueryRange( ITfRange
		// *pRange, ITfRange **ppNewRange, BOOL *pfPlayable );
		[PreserveSig]
		HRESULT QueryRange([In] ITfRange pRange, out ITfRange ppNewRange, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfPlayable);

		/// <summary>Causes the audio data for a range of text to be played.</summary>
		/// <param name="pRange">
		/// <para>
		/// Pointer to an ITfRange object that covers the text to play the audio data for. This range object is obtained by calling ITfFnPlayBack::QueryRange.
		/// </para>
		/// <para>
		/// If the range has zero length, the range played is expanded to cover the entire spoken phrase. If the range has a nonzero
		/// length, the range played is expanded to include the entire word, or words, that the range partially covers.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnplayback-play HRESULT Play( ITfRange *pRange );
		[PreserveSig]
		HRESULT Play([In] ITfRange pRange);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfFnPropertyUIStatus</c> interface is implemented by a text service and used by an application or text service to obtain
	/// and set the status of the text service property UI.
	/// </para>
	/// <para>
	/// An application or text service obtains an instance of this interface by obtaining the ITfFunctionProvider for the text service
	/// and calling ITfFunctionProvider::GetFunction with IID_ITfFnPropertyUIStatus.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itffnpropertyuistatus
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnPropertyUIStatus")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("2338AC6E-2B9D-44C0-A75E-EE64F256B3BD")]
	public interface ITfFnPropertyUIStatus : ITfFunction
	{
		/// <summary>Obtains the function display name.</summary>
		/// <param name="pbstrName">
		/// Pointer to a BSTR value that receives the display name. This value must be allocated using SysAllocString. The caller must
		/// free this memory using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrName is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunction-getdisplayname HRESULT GetDisplayName( BSTR
		// *pbstrName );
		[PreserveSig]
		new HRESULT GetDisplayName([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

		/// <summary>Obtains the status of a text service property UI.</summary>
		/// <param name="refguidProp">
		/// Specifies the property identifier. This can be a custom identifier or one of the predefined property identifiers.
		/// </param>
		/// <param name="pdw">
		/// <para>Pointer to a <c>DWORD</c> that recevies the property UI status. This can be zero or the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_PROPUI_STATUS_SAVETOFILE</term>
		/// <term>The property can be serialized. If this value is not present, the property cannot be serialized.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pdw is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The text service does not support this method.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnpropertyuistatus-getstatus HRESULT GetStatus(
		// REFGUID refguidProp, DWORD *pdw );
		[PreserveSig]
		HRESULT GetStatus(in Guid refguidProp, out TF_PROPUI_STATUS pdw);

		/// <summary>Modifies the status of a text service property UI.</summary>
		/// <param name="refguidProp">
		/// Specifies the property identifier. This can be a custom identifier or one of the predefined property identifiers.
		/// </param>
		/// <param name="dw">
		/// Contains the new property UI status. See the pdw parameter of ITfFnPropertyUIStatus::GetStatus for possible values.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The text service does not support this method.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnpropertyuistatus-setstatus HRESULT SetStatus(
		// REFGUID refguidProp, DWORD dw );
		[PreserveSig]
		HRESULT SetStatus(in Guid refguidProp, TF_PROPUI_STATUS dw);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfFnReconversion</c> interface is implemented by a text service and is used by the TSF manager or a client to support
	/// reconversion of text provided by the text service.
	/// </para>
	/// <para>
	/// The TSF manager implements this interface to provide access to this interface to other clients. This allows the TSF manager to
	/// function as a mediator between the client and the text service.
	/// </para>
	/// <para>The TSF manager obtains this interface by calling the text service ITfFunctionProvider::GetFunction method with IID_ITfFnReconversion.</para>
	/// <para>An application obtains this interface by calling the TSF manager <c>ITfFunctionProvider::GetFunction</c> method with IID_ITfFnReconversion.</para>
	/// </summary>
	/// <remarks>
	/// When a text service must interpret text before it is inserted into a context, there might be more than one possible
	/// interpretation of the text. Speech input is an example of this. If the spoken word is "there", other possible interpretations
	/// might be "their" or "they're". The text service will insert the most appropriate text, but there is still some chance of error
	/// involved. Text reconversion is the process of allowing the user to select alternate text for the inserted text.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itffnreconversion
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnReconversion")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("4CEA93C0-0A58-11D3-8DF0-00105A2799B5")]
	public interface ITfFnReconversion : ITfFunction
	{
		/// <summary>Obtains the function display name.</summary>
		/// <param name="pbstrName">
		/// Pointer to a BSTR value that receives the display name. This value must be allocated using SysAllocString. The caller must
		/// free this memory using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrName is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunction-getdisplayname HRESULT GetDisplayName( BSTR
		// *pbstrName );
		[PreserveSig]
		new HRESULT GetDisplayName([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

		/// <summary>The <c>ITfFnReconversion::QueryRange</c> method obtains the range of text that the reconversion applies to.</summary>
		/// <param name="pRange">Pointer to an ITfRange object that covers all or part of the text to be reconverted.</param>
		/// <param name="ppNewRange">
		/// <para>
		/// [in, out] Pointer to an ITfRange pointer that receives a range object that covers all of text that can be reconverted. If
		/// none of the text covered by pRange can be reconverted, this parameters receives NULL. In this case, the method will return
		/// S_OK, so the caller must verify that this parameter is not NULL before using the pointer.
		/// </para>
		/// <para>
		/// When this method is implemented by a text service, this parameter is optional and can be NULL. In this case, the range is
		/// not required.
		/// </para>
		/// <para>When the TSF manager implementation of this method is called, this parameter is not optional and cannot be NULL.</para>
		/// </param>
		/// <param name="pfConvertable">
		/// Pointer to a <c>BOOL</c> value that receives zero if none of the text covered by pRange can be reconverted or nonzero otherwise.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnreconversion-queryrange HRESULT QueryRange(
		// ITfRange *pRange, ITfRange **ppNewRange, BOOL *pfConvertable );
		[PreserveSig]
		HRESULT QueryRange([In] ITfRange pRange, out ITfRange ppNewRange, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfConvertable);

		/// <summary>Obtains an ITfCandidateList object for a range of text.</summary>
		/// <param name="pRange">
		/// Pointer to an ITfRange object that covers the text to be reconverted. This range object is obtained by calling ITfFnReconversion::QueryRange.
		/// </param>
		/// <param name="ppCandList">Pointer to an <c>ITfCandidateList</c> pointer that receives the candidate list object.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnreconversion-getreconversion HRESULT
		// GetReconversion( ITfRange *pRange, ITfCandidateList **ppCandList );
		[PreserveSig]
		HRESULT GetReconversion([In] ITfRange pRange, out ITfCandidateList ppCandList);

		/// <summary>Invokes the reconversion process for a range of text.</summary>
		/// <param name="pRange">
		/// Pointer to an ITfRange object that covers the text to be reconverted. To obtain this range object call ITfFnReconversion::QueryRange.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If this method causes some type of user interface to be displayed, such as a dialog box, this method must not wait for the
		/// UI to be dismissed before returning.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnreconversion-reconvert HRESULT Reconvert( ITfRange
		// *pRange );
		[PreserveSig]
		HRESULT Reconvert([In] ITfRange pRange);
	}

	/// <summary>Enables an integrated search experience in an Input Method Editor (IME).</summary>
	/// <remarks>
	/// <para>
	/// Implement the <c>ITfFnSearchCandidateProvider</c> interface in your Input Method Editor (IME) to enable an integrated search
	/// experience. Implementing this interface enables searches with meaningful results to begin before IME input has been completed,
	/// by providing a set of possible IME conversion candidates for a given input string. Apps can use this interface to obtain IME
	/// conversions for a string, so the <c>ITfFnSearchCandidateProvider</c> interface, along with ITfFnGetLinguisticAlternates,
	/// provides a TSF-based replacement for the ImmGetConversionList function. Typically IMEs implement either
	/// <c>ITfFnGetLinguisticAlternates</c> or <c>ITfFnSearchCandidateProvider</c> (or neither).
	/// </para>
	/// <para>
	/// Call GetFunctionProvider with the CLSID of a text service to get an ITfFunctionProvider instance. Use the following call to the
	/// ITfFunctionProvider::GetFunction method to get the <c>ITfFnSearchCandidateProvider</c> interface pointer.
	/// </para>
	/// <para>
	/// <code>ITfFunctionProvider::GetFunction(GUID_NULL, IID_ITfFnSearchCandidateProvider, &amp;pSearchCandidate)</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itffnsearchcandidateprovider
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnSearchCandidateProvider")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("87a2ad8f-f27b-4920-8501-67602280175d")]
	public interface ITfFnSearchCandidateProvider : ITfFunction
	{
		/// <summary>Obtains the function display name.</summary>
		/// <param name="pbstrName">
		/// Pointer to a BSTR value that receives the display name. This value must be allocated using SysAllocString. The caller must
		/// free this memory using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrName is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunction-getdisplayname HRESULT GetDisplayName( BSTR
		// *pbstrName );
		[PreserveSig]
		new HRESULT GetDisplayName([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

		/// <summary>Gets a list of conversion candidates for a given string without generating any IME-related messages or events.</summary>
		/// <param name="bstrQuery">A string that specifies the reading string that the text service attempts to convert.</param>
		/// <param name="bstrApplicationId">
		/// App-specified string that enables a text service to optionally provide different candidates to different apps or contexts
		/// based on input history. You can pass an empty <c>BSTR</c>, L””, for a generic context.
		/// </param>
		/// <param name="pplist">An ITfCandidateList that receives the requested candidate data.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>No candidates could be returned for the input string, pplist may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnsearchcandidateprovider-getsearchcandidates
		// HRESULT GetSearchCandidates( BSTR bstrQuery, BSTR bstrApplicationId, ITfCandidateList **pplist );
		[PreserveSig]
		HRESULT GetSearchCandidates([In, MarshalAs(UnmanagedType.BStr)] string bstrQuery, [In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationId, out ITfCandidateList pplist);

		/// <summary>Provides a text Service or IME with history data when a candidate is chosen by the user.</summary>
		/// <param name="bstrQuery">The reading string for the text service or IME to convert.</param>
		/// <param name="bstrApplicationID">
		/// App-specified string that enables a text service or IME to optionally provide different candidates to different apps or
		/// contexts based on input history. You can pass an empty <c>BSTR</c>, L””, for a generic context.
		/// </param>
		/// <param name="bstrResult">
		/// A string that represents the candidate string chosen by the user. It should be one of the candidate string values returned
		/// by the GetSearchCandidates method.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Implementing and calling the SetResult method is optional.</para>
		/// <para>
		/// A text service or IME can return <c>E_PENDING</c> if no corresponding call to GetSearchCandidates has been made yet for the
		/// value of bstrQuery.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnsearchcandidateprovider-setresult HRESULT
		// SetResult( BSTR bstrQuery, BSTR bstrApplicationID, BSTR bstrResult );
		[PreserveSig]
		HRESULT SetResult([In, MarshalAs(UnmanagedType.BStr)] string bstrQuery, [In, MarshalAs(UnmanagedType.BStr)] string bstrApplicationID, [In, MarshalAs(UnmanagedType.BStr)] string bstrResult);
	};

	/// <summary>
	/// The <c>ITfFnShowHelp</c> interface is implemented by a text service to enable the language bar to place a help command for the
	/// text service in the language bar help menu.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The TSF manager obtains this interface from the text service by calling the text service ITfFunctionProvider::GetFunction
	/// interface with IID_ITfFnShowHelp.
	/// </para>
	/// <para>The TSF manager obtains the help menu text by calling the text service's ITfFunction::GetDisplayName.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itffnshowhelp
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfFnShowHelp")]
	[ComImport, Guid("5AB1D30C-094D-4C29-8EA5-0BF59BE87BF3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfFnShowHelp : ITfFunction
	{
		/// <summary>Obtains the function display name.</summary>
		/// <param name="pbstrName">
		/// Pointer to a BSTR value that receives the display name. This value must be allocated using SysAllocString. The caller must
		/// free this memory using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrName is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunction-getdisplayname HRESULT GetDisplayName( BSTR
		// *pbstrName );
		[PreserveSig]
		new HRESULT GetDisplayName([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);

		/// <summary>Called when the user selects a text service help menu item.</summary>
		/// <param name="hwndParent">Handle of the parent window. This value can be <c>NULL</c>.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>The text service should not wait for the help UI to be complete before returning from this method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itffnshowhelp-show HRESULT Show( HWND hwndParent );
		[PreserveSig]
		HRESULT Show([In] HWND hwndParent);
	}

	/// <summary>
	/// The <c>ITfFunction</c> interface is the base interface for the individual function interfaces. This interface is implemented by
	/// the provider of the function object and used by any component to obtain the display name of the function object. Instances of
	/// this interface are not obtained directly. This interface is always part of a derived interface, such as ITfFnShowHelp.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itffunction
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfFunction")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("DB593490-098F-11D3-8DF0-00105A2799B5")]
	public interface ITfFunction
	{
		/// <summary>Obtains the function display name.</summary>
		/// <param name="pbstrName">
		/// Pointer to a BSTR value that receives the display name. This value must be allocated using SysAllocString. The caller must
		/// free this memory using SysFreeString when it is no longer required.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pbstrName is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itffunction-getdisplayname HRESULT GetDisplayName( BSTR
		// *pbstrName );
		[PreserveSig]
		HRESULT GetDisplayName([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);
	}

	/// <summary>Enables text services and Input Method Editors (IMEs) to adjust UI-less mode behavior.</summary>
	/// <remarks>
	/// <para>
	/// The <c>ITfIntegratableCandidateListUIElement</c> interface is implemented by text services and Input Method Editors (IMEs) to
	/// adjust UI-less mode behavior for a better UI and keyboarding experience in IME-integrated controls, like the Windows 8 Search
	/// box. The interface is used by apps that need a more streamlined UI and keyboarding experience with IME languages.
	/// </para>
	/// <para>
	/// You can get an <c>ITfIntegratableCandidateListUIElement</c> interface pointer by calling QueryInterface on the ITfUIElement
	/// interface pointer that's provided by using the dwUIElementId parameters of the ITfUIElementSink callback functions to obtain the
	/// interface from ITfUIElementMgr.
	/// </para>
	/// <para>
	/// The <c>ITfIntegratableCandidateListUIElement</c> interface is an optional interface that's implemented by a text service or IME
	/// that needs greater control over how its UI is presented in UI-less mode. Apps can use it to implement more streamlined,
	/// special-purpose input controls, as in auto-complete or search suggestions.
	/// </para>
	/// <para>
	/// Implement the <c>ITfIntegratableCandidateListUIElement</c> interface in the same class that implements the ITfUIElement,
	/// ITfCandidateListUIElement, and ITfCandidateListUIElementBehavior interfaces. These interfaces work together to create a fully
	/// integrated experience in which the app renders candidate list UI for the text service or IME and can also have some IME-specific
	/// UI customization and keyboard interaction behavior.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itfintegratablecandidatelistuielement
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfIntegratableCandidateListUIElement")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("C7A6F54F-B180-416F-B2BF-7BF2E4683D7B")]
	public interface ITfIntegratableCandidateListUIElement
	{
		/// <summary>Sets the integration style.</summary>
		/// <param name="guidIntegrationStyle">The desired type of keyboard integration experience.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The text service supports the integration style.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The text service does not support the integration style.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If an app needs a keyboard-integrated experience, it can set a <c>GUID</c> for the desired type of integration experience.
		/// If the text service supports the integration style, it should return <c>S_OK</c>. If it's not supported, it should return
		/// <c>E_NOTIMPL</c>. When called, the text service may adjust its respond to keyboard interaction for the lifetime of the
		/// ITfCandidateListUIElement object, for example, until ITfUIElementSink::EndUIElement is called.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itfintegratablecandidatelistuielement-setintegrationstyle
		// HRESULT SetIntegrationStyle( GUID guidIntegrationStyle );
		[PreserveSig]
		HRESULT SetIntegrationStyle(in Guid guidIntegrationStyle);

		/// <summary>Retrieves the selection style.</summary>
		/// <param name="ptfSelectionStyle">A value that specifies the selection style.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The active selection style usually indicates that the selection can be changed with the arrow keys. The implied selection
		/// style indicates the default selection key chooses it. If the app supports changing selection styles, this method should be
		/// called when the UpdateUIElement method is called.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itfintegratablecandidatelistuielement-getselectionstyle
		// HRESULT GetSelectionStyle( TfIntegratableCandidateListSelectionStyle *ptfSelectionStyle );
		[PreserveSig]
		HRESULT GetSelectionStyle(out TfIntegratableCandidateListSelectionStyle ptfSelectionStyle);

		/// <summary>Processes a key press.</summary>
		/// <param name="wParam">
		/// Specifies the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="lParam">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="pfEaten"><c>TRUE</c> if the key event was handled; otherwise, <c>FALSE</c>.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The OnKeyDown method enables an app to ask query the text service if it wants to process a given key in an integration
		/// style. The behavior of the <c>OnKeyDown</c> method can depend on the integration style. If the text service returns
		/// *pfEaten= <c>TRUE</c>, then the app should do no processing of the key. If <c>FALSE</c> is returned, the app can perform its
		/// own action in response to the key.
		/// </para>
		/// <para>
		/// <c>GUID_INTEGRATIONSTYLE_SEARCHBOX</c> ({E6D1BD11-82F7-4903-AE21-1A6397CDE2EB}) enables an implementation of a keyboarding
		/// experience in which the user can move perceived keyboard focus from the search box to the candidate list to search
		/// suggestions. The text service can process keys like <c>VK_UP</c> and <c>VK_DOWN</c> before Search handles them to change its
		/// internal state.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itfintegratablecandidatelistuielement-onkeydown HRESULT
		// OnKeyDown( WPARAM wParam, LPARAM lParam, BOOL *pfEaten );
		[PreserveSig]
		HRESULT OnKeyDown([In] WPARAM wParam, [In] LPARAM lParam, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfEaten);

		/// <summary>Specifies whether candidate numbers should be shown.</summary>
		/// <param name="pfShow"><c>TRUE</c> if candidate numbers should be shown; otherwise <c>FALSE</c>.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itfintegratablecandidatelistuielement-showcandidatenumbers
		// HRESULT ShowCandidateNumbers( BOOL *pfShow );
		[PreserveSig]
		HRESULT ShowCandidateNumbers([Out, MarshalAs(UnmanagedType.Bool)] out bool pfShow);

		/// <summary>Enables text services and Input Method Editors (IMEs) to adjust UI-less mode behavior.</summary>
		/// <remarks>
		/// <para>
		/// The <c>ITfIntegratableCandidateListUIElement</c> interface is implemented by text services and Input Method Editors (IMEs)
		/// to adjust UI-less mode behavior for a better UI and keyboarding experience in IME-integrated controls, like the Windows 8
		/// Search box. The interface is used by apps that need a more streamlined UI and keyboarding experience with IME languages.
		/// </para>
		/// <para>
		/// You can get an <c>ITfIntegratableCandidateListUIElement</c> interface pointer by calling QueryInterface on the ITfUIElement
		/// interface pointer that's provided by using the dwUIElementId parameters of the ITfUIElementSink callback functions to obtain
		/// the interface from ITfUIElementMgr.
		/// </para>
		/// <para>
		/// The <c>ITfIntegratableCandidateListUIElement</c> interface is an optional interface that's implemented by a text service or
		/// IME that needs greater control over how its UI is presented in UI-less mode. Apps can use it to implement more streamlined,
		/// special-purpose input controls, as in auto-complete or search suggestions.
		/// </para>
		/// <para>
		/// Implement the <c>ITfIntegratableCandidateListUIElement</c> interface in the same class that implements the ITfUIElement,
		/// ITfCandidateListUIElement, and ITfCandidateListUIElementBehavior interfaces. These interfaces work together to create a
		/// fully integrated experience in which the app renders candidate list UI for the text service or IME and can also have some
		/// IME-specific UI customization and keyboard interaction behavior.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itfintegratablecandidatelistuielement
		[PreserveSig]
		HRESULT FinalizeExactCompositionString();
	}

	/// <summary>
	/// The <c>ITfLMLattice</c> interface is implemented by the speech text service to provide information about lattice element
	/// properties and is used by a client (application or other text service). A client obtains this interface from the
	/// GUID_PROP_LMLATTICE property by calling ITfReadOnlyProperty::GetValue. For more information, see Predefined Properties.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itflmlattice
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfLMLattice")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("D4236675-A5BF-4570-9D42-5D6D7B02D59B")]
	public interface ITfLMLattice
	{
		/// <summary>Determines if a specific lattice element type is supported by the lattice property.</summary>
		/// <param name="rguidType">Specifies the lattice type identifier. This can be one of the Lattice Type values.</param>
		/// <returns>
		/// Pointer to a <c>BOOL</c> that receives a value that indicates if the lattice type is supported. If the lattice type is
		/// supported, this parameter receives a nonzero value and the method returns S_OK. If the lattice type is unsupported, this
		/// parameter receives zero and the method returns E_INVALIDARG.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itflmlattice-querytype HRESULT QueryType( REFGUID
		// rguidType, BOOL *pfSupported );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool QueryType(in Guid rguidType);

		/// <summary>
		/// Obtains an enumerator that contains all lattice elements contained in the lattice property that start at or after a specific
		/// offset from the start of the frame.
		/// </summary>
		/// <param name="dwFrameStart">
		/// Specifies the offset, in 100-nanosecond units, relative to the start of the phrase, of the first element to obtain.
		/// </param>
		/// <param name="rguidType">Specifies the lattice type identifier. This can be one of the Lattice Type values.</param>
		/// <returns>Pointer to an IEnumTfLatticeElements interface pointer that receives the enumerator object.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itflmlattice-enumlatticeelements HRESULT
		// EnumLatticeElements( DWORD dwFrameStart, REFGUID rguidType, IEnumTfLatticeElements **ppEnum );
		IEnumTfLatticeElements EnumLatticeElements(uint dwFrameStart, in Guid rguidType);
	}

	/// <summary>
	/// The <c>TF_LMLATTELEMENT</c> structure contains information about a lattice element. A lattice element is used in speech
	/// recognition. This structure is used with the IEnumTfLatticeElements::Next method.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/ns-ctffunc-tf_lmlattelement typedef struct TF_LMLATTELEMENT { DWORD
	// dwFrameStart; DWORD dwFrameLen; DWORD dwFlags; union { INT iCost; }; BSTR bstrText; } TF_LMLATTELEMENT;
	[PInvokeData("ctffunc.h", MSDNShortId = "NS:ctffunc.TF_LMLATTELEMENT")]
	[StructLayout(LayoutKind.Sequential, Pack = 4), Guid("1B646EFE-3CE3-4CE2-B41F-35B93FE5552F")]
	public struct TF_LMLATTELEMENT
	{
		/// <summary>Contains the starting offset, in 100-nanosecond units, of the element relative to the start of the phrase.</summary>
		public uint dwFrameStart;

		/// <summary>Contains the length, in 100-nanosecond units, of the element.</summary>
		public uint dwFrameLen;

		/// <summary>Not currently used.</summary>
		public uint dwFlags;

		/// <summary>
		/// <para>Specifies the actual confidence for this element. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SP_LOW_CONFIDENCE</term>
		/// <term>The speech engine has low confidence in the element.</term>
		/// </item>
		/// <item>
		/// <term>SP_NORMAL_CONFIDENCE</term>
		/// <term>The speech engine has normal confidence in the element.</term>
		/// </item>
		/// <item>
		/// <term>SP_HIGH_CONFIDENCE</term>
		/// <term>The speech engine has high confidence in the element.</term>
		/// </item>
		/// </list>
		/// </summary>
		public SP_CONFIDENCE iCost;

		/// <summary>
		/// Contains the display text for the element. If the spoken word is "two", the display text will be "2". The caller must free
		/// this string using SysFreeString when it is no longer required.
		/// </summary>
		[MarshalAs(UnmanagedType.BStr)]
		public string bstrText;
	}
}