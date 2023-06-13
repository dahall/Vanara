using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Imm32
{
	/// <summary>Provides access to the list of IME plug-in dictionaries.</summary>
	/// <remarks>
	/// This interface is implemented in classes of ProgID="ImePlugInDictDictionaryList1041" for Microsoft Japanese IME and
	/// ProgID="ImePlugInDictDictionaryList2052" for Microsoft Simplified Chinese IME.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msimeapi/nn-msimeapi-iimeplugindictdictionarylist
	[PInvokeData("msimeapi.h", MSDNShortId = "NN:msimeapi.IImePlugInDictDictionaryList")]
	[ComImport, Guid("98752974-b0a6-489b-8f6f-bff3769c8eeb"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IImePlugInDictDictionaryList
	{
		/// <summary>
		/// Obtains the list of Dictionary IDs ( <c>GUID</c>) of the IME plug-in dictionaries which are in use by IME, with their
		/// creation dates and encryption flags.
		/// </summary>
		/// <param name="prgDictionaryGUID">
		/// Array of the dictionary IDs ( <c>GUID</c>) of the IME plug-in dictionaries which are in use by IME.
		/// </param>
		/// <param name="prgDateCreated">Array of the dates of creation for each of the IME plug-in dictionaries returned by <c>prgDictionaryGUID</c>.</param>
		/// <param name="prgfEncrypted">
		/// Array of flags indicating whether each dictionary is encrypted or not for each of the IME plug-in dictionaries returned by <c>prgDictionaryGUID</c>.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>Succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>Out of memory.</term>
		/// </item>
		/// <item>
		/// <term><c>E_FAIL</c></term>
		/// <term>Other errors.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msimeapi/nf-msimeapi-iimeplugindictdictionarylist-getdictionariesinuse
		// HRESULT GetDictionariesInUse( [out] SAFEARRAY **prgDictionaryGUID, [in, out] SAFEARRAY **prgDateCreated, [in, out] SAFEARRAY
		// **prgfEncrypted );
		void GetDictionariesInUse([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out string[] prgDictionaryGUID,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_DATE)] out DateTime[] prgDateCreated,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_I4)] out int[] prgfEncrypted);

		/// <summary>Deletes a dictionary from the IME's plug-in dictionary list.</summary>
		/// <param name="bstrDictionaryGUID">The dictionary ID ( <c>GUID</c>) of the dictionary to be removed from the list.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The specified dictionary existed in the list and was successfully removed.</term>
		/// </item>
		/// <item>
		/// <term><c>S_FALSE</c></term>
		/// <term>The specified dictionary does not exist in the list.</term>
		/// </item>
		/// <item>
		/// <term><c>E_FAIL</c></term>
		/// <term>Other errors.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msimeapi/nf-msimeapi-iimeplugindictdictionarylist-deletedictionary HRESULT
		// DeleteDictionary( [in] BSTR bstrDictionaryGUID );
		[PreserveSig]
		HRESULT DeleteDictionary([MarshalAs(UnmanagedType.BStr)] string bstrDictionaryGUID);
	}

	/// <summary>CLSID_ImePlugInDictDictionaryList_JPN</summary>
	[PInvokeData("msimeapi.h")]
	[ComImport, Guid("4FE2776B-B0F9-4396-B5FC-E9D4CF1EC195"), ClassInterface(ClassInterfaceType.None)]
	public class ImePlugInDictDictionaryList1041 { }

	/// <summary>CLSID_ImePlugInDictDictionaryList_CHS</summary>
	[PInvokeData("msimeapi.h")]
	[ComImport, Guid("7BF0129B-5BEF-4DE4-9B0B-5EDB66AC2FA6"), ClassInterface(ClassInterfaceType.None)]
	public class ImePlugInDictDictionaryList2052 { }
}