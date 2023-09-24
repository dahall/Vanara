using System.Runtime.InteropServices.ComTypes;
using Vanara.Collections;
using static Vanara.PInvoke.Ole32;
using LPARAM = System.IntPtr;
using TfClientId = System.UInt32;

using TfEditCookie = System.UInt32;
using TfGuidAtom = System.UInt32;
using WPARAM = System.IntPtr;

namespace Vanara.PInvoke;

public static partial class MSCTF
{
	/// <summary>
	/// The <c>IEnumITfCompositionView</c> interface is implemented by the TSF manager to provide an enumeration of composition view objects.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-ienumitfcompositionview
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.IEnumITfCompositionView")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5EFD22BA-7838-46CB-88E2-CADB14124F8F")]
	public interface IEnumITfCompositionView : ICOMEnum<ITfCompositionView>
	{
		/// <summary>Creates a copy of the enumerator object.</summary>
		/// <returns>Pointer to an IEnumITfCompositionView interface pointer that receives the new enumerator.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumitfcompositionview-clone HRESULT Clone(
		// IEnumITfCompositionView **ppEnum );
		IEnumITfCompositionView Clone();

		/// <summary>Obtains, from the current position, the specified number of elements in the enumeration sequence.</summary>
		/// <param name="ulCount">Specifies the number of elements to obtain.</param>
		/// <param name="rgCompositionView">
		/// Pointer to an array of ITfCompositionView interface pointers that receives the requested objects. This array must be at
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
		/// <term>The method reached the end of the enumeration before the specified number of elements could be obtained.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>rgCompositionView is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumitfcompositionview-next HRESULT Next( ULONG ulCount,
		// ITfCompositionView **rgCompositionView, ULONG *pcFetched );
		[PreserveSig]
		HRESULT Next(uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] ITfCompositionView[] rgCompositionView, [NullAllowed] out uint pcFetched);

		/// <summary>Resets the enumerator object by moving the current position to the beginning of the enumeration sequence.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumitfcompositionview-reset HRESULT Reset();
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumitfcompositionview-skip HRESULT Skip( ULONG ulCount );
		[PreserveSig]
		HRESULT Skip(uint ulCount);
	}

	/// <summary>The <c>IEnumTfContexts</c> interface is implemented by the TSF manager to provide an enumeration of context objects.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-ienumtfcontexts
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.IEnumTfContexts")]
	[ComImport, Guid("8F1A7EA6-1654-4502-A86E-B2902344D507"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumTfContexts : ICOMEnum<ITfContext>
	{
		/// <summary>Creates a copy of the enumerator object.</summary>
		/// <returns>Pointer to an IEnumTfContexts interface pointer that receives the new enumerator.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfcontexts-clone HRESULT Clone( IEnumTfContexts
		// **ppEnum );
		IEnumTfContexts Clone();

		/// <summary>Obtains, from the current position, the specified number of elements in the enumeration sequence.</summary>
		/// <param name="ulCount">Specifies the number of elements to obtain.</param>
		/// <param name="rgContext">
		/// Pointer to an array of ITfContext interface pointers that receives the requested objects. This array must be at least
		/// ulCount elements in size.
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
		/// <term>rgContext is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfcontexts-next HRESULT Next( ULONG ulCount,
		// ITfContext **rgContext, ULONG *pcFetched );
		[PreserveSig]
		HRESULT Next(uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] ITfContext[] rgContext, [NullAllowed] out uint pcFetched);

		/// <summary>Resets the enumerator object by moving the current position to the beginning of the enumeration sequence.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfcontexts-reset HRESULT Reset();
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfcontexts-skip HRESULT Skip( ULONG ulCount );
		[PreserveSig]
		HRESULT Skip(uint ulCount);
	}

	/// <summary>Not implemented.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-ienumtfcontextviews
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.IEnumTfContextViews")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("F0C0F8DD-CF38-44E1-BB0F-68CF0D551C78")]
	public interface IEnumTfContextViews : ICOMEnum<ITfContextView>
	{
		/// <summary>This method has no parameters.</summary>
		/// <returns>This method does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/ienumtfcontextviews-clone void ();
		IEnumTfContextViews Clone();

		/// <summary>Obtains, from the current position, the specified number of elements in the enumeration sequence.</summary>
		/// <param name="ulCount">Specifies the number of elements to obtain.</param>
		/// <param name="rgViews">
		/// Pointer to an array of ITfContextView interface pointers that receives the requested objects. This array must be at least
		/// ulCount elements in size.
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
		/// <term>rgViews is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		[PreserveSig]
		HRESULT Next(uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] ITfContextView[] rgViews, [NullAllowed] out uint pcFetched);

		/// <summary>This method has no parameters.</summary>
		/// <returns>This method does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/ienumtfcontextviews-reset void ();
		void Reset();

		/// <summary>This method has no parameters.</summary>
		/// <returns>This method does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/ienumtfcontextviews-skip void ();
		[PreserveSig]
		HRESULT Skip(uint ulCount);
	}

	/// <summary>
	/// The <c>IEnumTfDisplayAttributeInfo</c> interface is implemented by the TSF manager to provide an enumeration of display
	/// attribute information objects.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-ienumtfdisplayattributeinfo
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.IEnumTfDisplayAttributeInfo")]
	[ComImport, Guid("7CEF04D7-CB75-4E80-A7AB-5F5BC7D332DE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumTfDisplayAttributeInfo : ICOMEnum<ITfDisplayAttributeInfo>
	{
		/// <summary>Creates a copy of the enumerator object.</summary>
		/// <returns>Pointer to an IEnumTfDisplayAttributeInfo interface pointer that receives the new enumerator.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfdisplayattributeinfo-clone HRESULT Clone(
		// IEnumTfDisplayAttributeInfo **ppEnum );
		IEnumTfDisplayAttributeInfo Clone();

		/// <summary>Obtains, from the current position, the specified number of elements in the enumeration sequence.</summary>
		/// <param name="ulCount">Specifies the number of elements to obtain.</param>
		/// <param name="rgInfo">
		/// Pointer to an array of ITfDisplayAttributeInfo interface pointers that receives the requested objects. This array must be at
		/// least ulCount elements in size.
		/// </param>
		/// <param name="pcFetched">
		/// Pointer to a ULONG value that receives the number of elements actually obtained. The number of elements can be less than the
		/// number of items requested. This parameter can be <c>NULL</c>.
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfdisplayattributeinfo-next HRESULT Next( ULONG
		// ulCount, ITfDisplayAttributeInfo **rgInfo, ULONG *pcFetched );
		[PreserveSig]
		HRESULT Next(uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] ITfDisplayAttributeInfo[] rgInfo, [NullAllowed] out uint pcFetched);

		/// <summary>Resets the enumerator object by moving the current position to the beginning of the enumeration sequence.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfdisplayattributeinfo-reset HRESULT Reset();
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfdisplayattributeinfo-skip HRESULT Skip( ULONG
		// ulCount );
		[PreserveSig]
		HRESULT Skip(uint ulCount);
	}

	/// <summary>
	/// The <c>IEnumTfDocumentMgrs</c> interface is implemented by the TSF manager to provide an enumeration of document manager objects.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-ienumtfdocumentmgrs
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.IEnumTfDocumentMgrs")]
	[ComImport, Guid("AA80E808-2021-11D2-93E0-0060B067B86E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumTfDocumentMgrs : ICOMEnum<ITfCompositionView>
	{
		/// <summary>Creates a copy of the enumerator object.</summary>
		/// <returns>Pointer to an IEnumTfDocumentMgrs interface pointer that receives the new enumerator.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfdocumentmgrs-clone HRESULT Clone(
		// IEnumTfDocumentMgrs **ppEnum );
		IEnumTfDocumentMgrs Clone();

		/// <summary>Obtains, from the current position, the specified number of elements in the enumeration sequence.</summary>
		/// <param name="ulCount">Specifies the number of elements to obtain.</param>
		/// <param name="rgDocumentMgr">
		/// Pointer to an array of ITfDocumentMgr interface pointers that receives the requested objects. This array must be at least
		/// ulCount elements in size.
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
		/// <term>The method reached the end of the enumeration before the specified number of elements were obtained.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>rgDocumentMgr is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfdocumentmgrs-next HRESULT Next( ULONG ulCount,
		// ITfDocumentMgr **rgDocumentMgr, ULONG *pcFetched );
		[PreserveSig]
		HRESULT Next(uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] ITfDocumentMgr[] rgDocumentMgr, [NullAllowed] out uint pcFetched);

		/// <summary>Resets the enumerator object by moving the current position to the beginning of the enumeration sequence.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfdocumentmgrs-reset HRESULT Reset();
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfdocumentmgrs-skip HRESULT Skip( ULONG ulCount );
		[PreserveSig]
		HRESULT Skip(uint ulCount);
	}

	/// <summary>
	/// The <c>IEnumTfFunctionProviders</c> interface is implemented by the TSF manager to provide an enumeration of function provider objects.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-ienumtffunctionproviders
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.IEnumTfFunctionProviders")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("E4B24DB0-0990-11D3-8DF0-00105A2799B5")]
	public interface IEnumTfFunctionProviders : ICOMEnum<ITfFunctionProvider>
	{
		/// <summary>Creates a copy of the enumerator object.</summary>
		/// <returns>Pointer to an IEnumTfFunctionProviders interface pointer that receives the new enumerator.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtffunctionproviders-clone HRESULT Clone(
		// IEnumTfFunctionProviders **ppEnum );
		IEnumTfFunctionProviders Clone();

		/// <summary>Obtains, from the current position, the specified number of elements in the enumeration sequence.</summary>
		/// <param name="ulCount">Specifies the number of elements to obtain.</param>
		/// <param name="ppCmdobj">
		/// Pointer to an array of ITfFunctionProvider interface pointers that receives the requested objects. This array must be at
		/// least ulCount elements in size.
		/// </param>
		/// <param name="pcFetch">
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
		/// <term>ppCmdobj is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtffunctionproviders-next HRESULT Next( ULONG ulCount,
		// ITfFunctionProvider **ppCmdobj, ULONG *pcFetch );
		[PreserveSig]
		HRESULT Next(uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] ITfFunctionProvider[] ppCmdobj, [NullAllowed] out uint pcFetch);

		/// <summary>Resets the enumerator object by moving the current position to the beginning of the enumeration sequence.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtffunctionproviders-reset HRESULT Reset();
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtffunctionproviders-skip HRESULT Skip( ULONG ulCount );
		[PreserveSig]
		HRESULT Skip(uint ulCount);
	}

	/// <summary>
	/// The <c>IEnumTfInputProcessorProfiles</c> interface is implemented by TSF manager and used by applications or textservices. This
	/// interface can be retrieved by ITfInputProcessorProfileMgr::EnumProfiles and enumerates the registered profiles.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-ienumtfinputprocessorprofiles
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.IEnumTfInputProcessorProfiles")]
	[ComImport, Guid("71C6E74D-0F28-11D8-A82A-00065B84435C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumTfInputProcessorProfiles : ICOMEnum<TF_INPUTPROCESSORPROFILE>
	{
		/// <summary>The <c>IEnumTfInputProcessorProfiles::Clone</c> method creates a copy of the enumerator object.</summary>
		/// <returns>[out] A pointer to an IEnumTfInputProcessorProfiles interface.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfinputprocessorprofiles-clone HRESULT Clone(
		// IEnumTfInputProcessorProfiles **ppEnum );
		IEnumTfInputProcessorProfiles Clone();

		/// <summary>
		/// The <c>IEnumTfInputProcessorProfiles::Next</c> method obtains, from the current position, the specified number of elements
		/// in the enumeration sequence.
		/// </summary>
		/// <param name="ulCount">[in] Specifies the number of elements to obtain.</param>
		/// <param name="pProfile">
		/// [out] Pointer to an array of TF_INPUTPROCESSORPROFILE structures. This array must be at least ulCount elements in size.
		/// </param>
		/// <param name="pcFetch">
		/// [out] Pointer to a ULONG value that receives the number of elements actually obtained. This value can be less than the
		/// number of items requested. This parameter can be <c>NULL</c>.
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfinputprocessorprofiles-next HRESULT Next( ULONG
		// ulCount, TF_INPUTPROCESSORPROFILE *pProfile, ULONG *pcFetch );
		[PreserveSig]
		HRESULT Next(uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray)] TF_INPUTPROCESSORPROFILE[] pProfile, out uint pcFetch);

		/// <summary>
		/// The IEnumTfInputProcessorProfiles::Reset method resets the enumerator object by moving the current position to the beginning
		/// of the enumeration sequence.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfinputprocessorprofiles-reset HRESULT Reset();
		void Reset();

		/// <summary>
		/// The IEnumTfInputProcessorProfiles::Skip method moves the current position forward in the enumeration sequence by the
		/// specified number of elements.
		/// </summary>
		/// <param name="ulCount">[in] Contains the number of elements to skip.</param>
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
		/// <term>E_FALSE</term>
		/// <term>The method reached the end of the enumeration before the specified number of elements could be skipped.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfinputprocessorprofiles-skip HRESULT Skip( ULONG
		// ulCount );
		[PreserveSig]
		HRESULT Skip(uint ulCount);
	}

	/// <summary>
	/// The <c>IEnumTfLangBarItems</c> interface is implemented by the TSF manager to provide an enumeration of langauge bar item objects.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nn-ctfutb-ienumtflangbaritems
	[PInvokeData("ctfutb.h", MSDNShortId = "NN:ctfutb.IEnumTfLangBarItems")]
	[ComImport, Guid("583F34D0-DE25-11D2-AFDD-00105A2799B5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumTfLangBarItems : ICOMEnum<ITfLangBarItem>
	{
		/// <summary>Creates a copy of the enumerator object.</summary>
		/// <returns>Pointer to an IEnumTfLangBarItems interface pointer that receives the new enumerator.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-ienumtflangbaritems-clone HRESULT Clone(
		// IEnumTfLangBarItems **ppEnum );
		IEnumTfLangBarItems Clone();

		/// <summary>Obtains the specified number of elements in the enumeration sequence from the current position.</summary>
		/// <param name="ulCount">Specifies the number of elements to obtain.</param>
		/// <param name="ppItem">
		/// Pointer to an array of ITfLangBarItem interface pointers that receives the requested objects. This array must be at least
		/// ulCount elements in size.
		/// </param>
		/// <param name="pcFetched">
		/// [in, out] Pointer to a ULONG value that receives the number of elements obtained. This value can be less than the number of
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
		/// <term>ppItem is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-ienumtflangbaritems-next HRESULT Next( ULONG ulCount,
		// ITfLangBarItem **ppItem, ULONG *pcFetched );
		[PreserveSig]
		HRESULT Next(uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] ITfLangBarItem[] ppItem, [NullAllowed] out uint pcFetched);

		/// <summary>Resets the enumerator object by moving the current position to the beginning of the enumeration sequence.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-ienumtflangbaritems-reset HRESULT Reset();
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
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-ienumtflangbaritems-skip HRESULT Skip( ULONG ulCount );
		[PreserveSig]
		HRESULT Skip(uint ulCount);
	}

	/// <summary>
	/// The <c>IEnumTfLanguageProfiles</c> interface is implemented by the TSF manager to provide an enumeration of language profiles.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-ienumtflanguageprofiles
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.IEnumTfLanguageProfiles")]
	[ComImport, Guid("3D61BF11-AC5F-42C8-A4CB-931BCC28C744"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumTfLanguageProfiles : ICOMEnum<TF_LANGUAGEPROFILE>
	{
		/// <summary>Creates a copy of the enumerator object.</summary>
		/// <returns>Pointer to an IEnumTfLanguageProfiles interface pointer that receives the new enumerator.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtflanguageprofiles-clone HRESULT Clone(
		// IEnumTfLanguageProfiles **ppEnum );
		IEnumTfLanguageProfiles Clone();

		/// <summary>Obtains, from the current position, the specified number of elements in the enumeration sequence.</summary>
		/// <param name="ulCount">Specifies the number of elements to obtain.</param>
		/// <param name="pProfile">
		/// Pointer to an array of TF_LANGUAGEPROFILE structures that receives the requested data. This array must be at least ulCount
		/// elements in size.
		/// </param>
		/// <param name="pcFetch">
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
		/// <term>pProfile is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtflanguageprofiles-next HRESULT Next( ULONG ulCount,
		// TF_LANGUAGEPROFILE *pProfile, ULONG *pcFetch );
		[PreserveSig]
		HRESULT Next(uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray)] TF_LANGUAGEPROFILE[] pProfile, [NullAllowed] out uint pcFetch);

		/// <summary>Resets the enumerator object by moving the current position to the beginning of the enumeration sequence.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtflanguageprofiles-reset HRESULT Reset();
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtflanguageprofiles-skip HRESULT Skip( ULONG ulCount );
		[PreserveSig]
		HRESULT Skip(uint ulCount);
	}

	/// <summary>The <c>IEnumTfProperties</c> interface is implemented by the TSF manager to provide an enumeration of property objects.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-ienumtfproperties
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.IEnumTfProperties")]
	[ComImport, Guid("19188CB0-ACA9-11D2-AFC5-00105A2799B5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumTfProperties : ICOMEnum<ITfProperty>
	{
		/// <summary>Creates a copy of the enumerator object.</summary>
		/// <returns>Pointer to an IEnumTfProperties interface pointer that receives the new enumerator.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfproperties-clone HRESULT Clone( IEnumTfProperties
		// **ppEnum );
		IEnumTfProperties Clone();

		/// <summary>Obtains, from the current position, the specified number of elements in the enumeration sequence.</summary>
		/// <param name="ulCount">Specifies the number of elements to obtain.</param>
		/// <param name="ppProp">
		/// Pointer to an array of ITfProperty interface pointers that receives the requested objects. This array must be at least
		/// ulCount elements in size.
		/// </param>
		/// <param name="pcFetched">
		/// Pointer to a ULONG that receives the number of elements obtained. This value can be less than the number of items requested.
		/// This parameter can be <c>NULL</c>.
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
		/// <term>ppProp is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfproperties-next HRESULT Next( ULONG ulCount,
		// ITfProperty **ppProp, ULONG *pcFetched );
		[PreserveSig]
		HRESULT Next(uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] ITfProperty[] ppProp, [NullAllowed] out uint pcFetched);

		/// <summary>Resets the enumerator object by moving the current position to the beginning of the enumeration sequence.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfproperties-reset HRESULT Reset();
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfproperties-skip HRESULT Skip( ULONG ulCount );
		[PreserveSig]
		HRESULT Skip(uint ulCount);
	}

	/// <summary>
	/// The <c>IEnumTfPropertyValue</c> interface is implemented by the TSF manager to provide an enumeration of property values.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-ienumtfpropertyvalue
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.IEnumTfPropertyValue")]
	[ComImport, Guid("8ED8981B-7C10-4D7D-9FB3-AB72E9C75F72"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumTfPropertyValue : ICOMEnum<TF_PROPERTYVAL>
	{
		/// <summary>Creates a copy of the enumerator object.</summary>
		/// <returns>Pointer to an IEnumTfPropertyValue interface pointer that receives the new enumerator.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfpropertyvalue-clone HRESULT Clone(
		// IEnumTfPropertyValue **ppEnum );
		IEnumTfPropertyValue Clone();

		/// <summary>Obtains, from the current position, the specified number of elements in the enumeration sequence.</summary>
		/// <param name="ulCount">Specifies the number of elements to obtain.</param>
		/// <param name="rgValues">
		/// Pointer to an array of TF_PROPERTYVAL structures that receives the requested objects. This array must be at least ulCount
		/// elements in size.
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
		/// <term>rgValues is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfpropertyvalue-next HRESULT Next( ULONG ulCount,
		// TF_PROPERTYVAL *rgValues, ULONG *pcFetched );
		[PreserveSig]
		HRESULT Next(uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray)] TF_PROPERTYVAL[] rgValues, [NullAllowed] out uint pcFetched);

		/// <summary>Resets the enumerator object by moving the current position to the beginning of the enumeration sequence.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfpropertyvalue-reset HRESULT Reset();
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfpropertyvalue-skip HRESULT Skip( ULONG ulCount );
		[PreserveSig]
		HRESULT Skip(uint ulCount);
	}

	/// <summary>The <c>IEnumTfRanges</c> interface is implemented by the TSF manager to provide an enumeration of range objects.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-ienumtfranges
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.IEnumTfRanges")]
	[ComImport, Guid("F99D3F40-8E32-11D2-BF46-00105A2799B5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumTfRanges : ICOMEnum<ITfRange>
	{
		/// <summary>Creates a copy of the enumerator object.</summary>
		/// <returns>Pointer to an IEnumTfRanges interface pointer that receives the new enumerator.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfranges-clone HRESULT Clone( IEnumTfRanges **ppEnum );
		IEnumTfRanges Clone();

		/// <summary>Obtains, from the current position, the specified number of elements in the enumeration sequence.</summary>
		/// <param name="ulCount">Specifies the number of elements to obtain.</param>
		/// <param name="ppRange">
		/// Pointer to an array of ITfRange interface pointers that receives the requested objects. This array must be at least ulCount
		/// elements in size.
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
		/// <term>ppRange is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfranges-next HRESULT Next( ULONG ulCount, ITfRange
		// **ppRange, ULONG *pcFetched );
		[PreserveSig]
		HRESULT Next(uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] ITfRange[] ppRange, [NullAllowed] out uint pcFetched);

		/// <summary>Resets the enumerator object by moving the current position to the beginning of the enumeration sequence.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfranges-reset HRESULT Reset();
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfranges-skip HRESULT Skip( ULONG ulCount );
		[PreserveSig]
		HRESULT Skip(uint ulCount);
	}

	/// <summary>
	/// The <c>IEnumTfUIElements</c> interface is implemented by TSF manager and used by applications or textservices. This interface
	/// can be retrieved by ITfUIElementMgr::EnumUIElements and enumerates the registered UI elements.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-ienumtfuielements
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.IEnumTfUIElements")]
	[ComImport, Guid("887AA91E-ACBA-4931-84DA-3C5208CF543F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumTfUIElements : ICOMEnum<ITfUIElement>
	{
		/// <summary>The <c>IEnumTfUIElements::Clone</c> method creates a copy of the enumerator object.</summary>
		/// <returns>[out] A pointer to a IEnumTfUIElements interface.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfuielements-clone HRESULT Clone( IEnumTfUIElements
		// **ppEnum );
		IEnumTfUIElements Clone();

		/// <summary>
		/// The <c>IEnumTfUIElements::Next</c> method obtains, from the current position, the specified number of elements in the
		/// enumeration sequence.
		/// </summary>
		/// <param name="ulCount">[out] Specifies the number of elements to obtain.</param>
		/// <param name="ppElement">
		/// [out] Pointer to an array of ITfUIElement interface pointer. This array must be at least ulCount elements in size.
		/// </param>
		/// <param name="pcFetched">
		/// [out] Pointer to a ULONG value that receives the number of elements actually obtained. This value can be less than the
		/// number of items requested. This parameter can be <c>NULL</c>.
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
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfuielements-next HRESULT Next( ULONG ulCount,
		// ITfUIElement **ppElement, ULONG *pcFetched );
		[PreserveSig]
		HRESULT Next(uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] ITfUIElement[] ppElement, [NullAllowed] out uint pcFetched);

		/// <summary>
		/// The <c>IEnumTfUIElements::Reset</c> method resets the enumerator object by moving the current position to the beginning of
		/// the enumeration sequence.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfuielements-reset HRESULT Reset();
		void Reset();

		/// <summary>
		/// The <c>IEnumTfUIElements::Skip</c> method obtains, from the current position, the specified number of elements in the
		/// enumeration sequence.
		/// </summary>
		/// <param name="ulCount">[in] Specifies the number of elements to skip.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-ienumtfuielements-skip HRESULT Skip( ULONG ulCount );
		[PreserveSig]
		HRESULT Skip(uint ulCount);
	}

	/// <summary>
	/// The <c>ITextStoreACPServices</c> interface is implemented by the TSF manager to provide various services to an ACP-based
	/// application. To obtain an instance of this interface, an application calls <c>QueryInterface</c> on the punk parameter passed to
	/// ITextStoreACP::AdviseSink with IID_ITextStoreACPServices.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itextstoreacpservices
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITextStoreACPServices")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AA80E901-2021-11D2-93E0-0060B067B86E")]
	public interface ITextStoreACPServices
	{
		/// <summary>Obtains a property from a range of text and writes the property data into a stream object.</summary>
		/// <param name="pProp">Pointer to an ITfProperty interface that identifies the property to serialize.</param>
		/// <param name="pRange">Pointer to an ITfRange interface that identifies the range that the property is obtained from.</param>
		/// <param name="pHdr">Pointer to a TF_PERSISTENT_PROPERTY_HEADER_ACP structure that receives the header data for the property.</param>
		/// <param name="pStream">Pointer to an <c>IStream</c> object that the TSF manager will write the property data to.</param>
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
		/// <term>The property cannot be serialized.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property header data placed in pHdr is generic to all properties and must be preserved with the data written into
		/// pStream. This same data pair must be passed to ITextStoreACPServices::Unserialize to restore the property data.
		/// </para>
		/// <para>An application can save all of the properties for the entire document by performing the following steps.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Enumerate all properties using ITfContext::EnumProperties.</term>
		/// </item>
		/// <item>
		/// <term>Within each property, enumerate the ranges using ITfReadOnlyProperty::EnumRanges.</term>
		/// </item>
		/// <item>
		/// <term>Pass the current property and range to <c>ITextStoreACPServices::Serialize</c>.</term>
		/// </item>
		/// <item>
		/// <term>Write the data placed in pHdr to the file.</term>
		/// </item>
		/// <item>
		/// <term>Write the data added to pStream to the file.</term>
		/// </item>
		/// </list>
		/// <para>When calling this method, the application must be able to grant a synchronous read-only lock.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itextstoreacpservices-serialize HRESULT Serialize(
		// ITfProperty *pProp, ITfRange *pRange, TF_PERSISTENT_PROPERTY_HEADER_ACP *pHdr, IStream *pStream );
		void Serialize([In] ITfProperty pProp, [In] ITfRange pRange, out TF_PERSISTENT_PROPERTY_HEADER_ACP pHdr, [In] IStream pStream);

		/// <summary>Takes previously serialized property data and applies it to a property object.</summary>
		/// <param name="pProp">Pointer to an ITfProperty object that receives the property data.</param>
		/// <param name="pHdr">Pointer to a TF_PERSISTENT_PROPERTY_HEADER_ACP structure that contains the header data for the property.</param>
		/// <param name="pStream">
		/// Pointer to an <c>IStream</c> object that contains the property data. This parameter can be <c>NULL</c> if pLoader is not
		/// <c>NULL</c>. This parameter is ignored if pLoader is not <c>NULL</c>.
		/// </param>
		/// <param name="pLoader">
		/// Pointer to an ITfPersistentPropertyLoaderACP object that the TSF manager will use to obtain the property data. This
		/// parameter can be <c>NULL</c> if pStream is not <c>NULL</c>.
		/// </param>
		/// <remarks>
		/// <para>
		/// If pStream is specified rather than pLoader, the property data will be read from pStream during the call to
		/// <c>Unserialize</c> . If pLoader is specified rather than pStream, the property data will be read from pLoader
		/// asynchronously. Using pStream can cause long delays if the property data is large.
		/// </para>
		/// <para>While calling this method, the application must be able to grant a synchronous read-only lock.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itextstoreacpservices-unserialize HRESULT Unserialize(
		// ITfProperty *pProp, const TF_PERSISTENT_PROPERTY_HEADER_ACP *pHdr, IStream *pStream, ITfPersistentPropertyLoaderACP *pLoader );
		void Unserialize([In] ITfProperty pProp, in TF_PERSISTENT_PROPERTY_HEADER_ACP pHdr, [In, Optional] IStream pStream, [In, Optional] ITfPersistentPropertyLoaderACP pLoader);

		/// <summary>Forces all values of an asynchronously loaded property to be loaded.</summary>
		/// <param name="pProp">Pointer to an ITfProperty object that specifies the property to load.</param>
		/// <remarks>When calling this method, the application must be able to grant a synchronous read-only lock.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itextstoreacpservices-forceloadproperty HRESULT
		// ForceLoadProperty( ITfProperty *pProp );
		void ForceLoadProperty([In] ITfProperty pProp);

		/// <summary>Creates a range object from two ACP values.</summary>
		/// <param name="acpStart">Contains the starting position of the range.</param>
		/// <param name="acpEnd">Contains the ending position of the range.</param>
		/// <returns>Pointer to an ITfRangeACP interface pointer that receives the range object.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itextstoreacpservices-createrange HRESULT CreateRange( LONG
		// acpStart, LONG acpEnd, ITfRangeACP **ppRange );
		ITfRangeACP CreateRange(int acpStart, int acpEnd);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfActiveLanguageProfileNotifySink</c> interface is implemented by an application to receive a notification when the
	/// active language or text service changes.
	/// </para>
	/// <para>
	/// To install the advise sink, obtain an ITfSource object from an ITfThreadMgr object by calling
	/// <c>ITfThreadMgr::QueryInterface</c> with IID_ITfActiveLanguageProfileNotifySink. Then call ITfSource::AdviseSink with IID_ITfActiveLanguageProfileNotifySink.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfactivelanguageprofilenotifysink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfActiveLanguageProfileNotifySink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("B246CB75-A93E-4652-BF8C-B3FE0CFD7E57")]
	public interface ITfActiveLanguageProfileNotifySink
	{
		/// <summary>Called when the active language or text service changes.</summary>
		/// <param name="clsid">CLSID of the TSF text service activated or deactivated. This will be <c>NULL</c> for a language change.</param>
		/// <param name="guidProfile">
		/// Profile GUID for the TSF text service. This is specified by the TSF text service when it is installed. This will be
		/// <c>NULL</c> for a language change.
		/// </param>
		/// <param name="fActivated">TRUE if the TSF text service is activated or FALSE if the TSF text service is deactivated.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfactivelanguageprofilenotifysink-onactivated HRESULT
		// OnActivated( REFCLSID clsid, REFGUID guidProfile, BOOL fActivated );
		[PreserveSig]
		HRESULT OnActivated([In, Optional] GuidPtr clsid, [In, Optional] GuidPtr guidProfile, [MarshalAs(UnmanagedType.Bool)] bool fActivated);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfCandidateList</c> interface is implemented by a text service and is used by the TSF manager or a client (application
	/// or other text service) to obtain and manipulate candidate string objects.
	/// </para>
	/// <para>
	/// The TSF manager implements this interface to provide access to this interface to other clients. This enables the TSF manager to
	/// function as a mediator between the client and the text service.
	/// </para>
	/// <para>To obtain an instance of this interface the TSF manager or client can call ITfFnReconversion::GetReconversion.</para>
	/// </summary>
	/// <remarks>
	/// When a text service must interpret text before it is inserted into a context, there might be more than one possible
	/// interpretation of the text. Speech input is an example of this. If the spoken word is "there", other possible interpretations
	/// might be "their" or "they're". The text service will insert the most appropriate text, but there is still some chance of error
	/// involved. Text reconversion is the process of allowing the user to select alternate text for the inserted text. The alternate
	/// text objects are known as candidates.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nn-ctffunc-itfcandidatelist
	[PInvokeData("ctffunc.h", MSDNShortId = "NN:ctffunc.ITfCandidateList")]
	[ComImport, Guid("A3AD50FB-9BDB-49E3-A843-6C76520FBF5D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfCandidateList
	{
		/// <summary>Obtains an enumerator that contains all the candidate string objects in the candidate list.</summary>
		/// <param name="ppEnum">
		/// Pointer to an IEnumTfCandidates interface pointer that receives the enumerator object. The caller must release this
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
		/// <term>E_INVALIDARG</term>
		/// <term>ppEnum is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itfcandidatelist-enumcandidates HRESULT EnumCandidates(
		// IEnumTfCandidates **ppEnum );
		[PreserveSig]
		HRESULT EnumCandidates(out IEnumTfCandidates ppEnum);

		/// <summary>Obtains a specific candidate string object.</summary>
		/// <param name="nIndex">Specifies the zero-based index of the candidate string to obtain.</param>
		/// <param name="ppCand">
		/// Pointer to an ITfCandidateString interface pointer that receives the candidate string object. The caller must release this
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
		/// <term>E_FAIL</term>
		/// <term>nIndex is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>ppCand is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itfcandidatelist-getcandidate HRESULT GetCandidate(
		// ULONG nIndex, ITfCandidateString **ppCand );
		[PreserveSig]
		HRESULT GetCandidate(uint nIndex, out ITfCandidateString ppCand);

		/// <summary>Obtains the number of candidate string objects in the candidate list.</summary>
		/// <param name="pnCnt">
		/// Pointer to a <c>ULONG</c> value that receives the number of candidate string objects in the candidate list.
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
		/// <term>pnCnt is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itfcandidatelist-getcandidatenum HRESULT
		// GetCandidateNum( ULONG *pnCnt );
		[PreserveSig]
		HRESULT GetCandidateNum(out uint pnCnt);

		/// <summary>Specifies the result of a reconversion operation for s specific candidate string.</summary>
		/// <param name="nIndex">
		/// Specifies the zero-based index of the candidate string to set the result for. This parameter is ignored if imcr contains CAND_CANCELED.
		/// </param>
		/// <param name="imcr">Contains one of the TfCandidateResult values that specifies the result of the reconversion operation.</param>
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
		/// <remarks>
		/// <para>A typical reconversion operation would include the following operations.</para>
		/// <list type="number">
		/// <item>
		/// <term>A list of candidates is obtained and displayed to the user in a dialog box.</term>
		/// </item>
		/// <item>
		/// <term>
		/// When the user selects a candidate, but before the dialog box is dismissed, <c>ITfCandidateList::SetResult</c> is called with
		/// the index of the newly selected candidate and CAND_SELECTED.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If a different candidate is selected, <c>ITfCandidateList::SetResult</c> is called agian with the index of the newly
		/// selected candidate and CAND_SELECTED.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the user chooses to accept the new candidate, <c>ITfCandidateList::SetResult</c> is called with the index of the
		/// currently selected candidate and CAND_FINALIZED.
		/// </term>
		/// </item>
		/// <item>
		/// <term>If the user cancels the dialog, <c>ITfCandidateList::SetResult</c> is called with an index of zero and CAND_CANCELED.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctffunc/nf-ctffunc-itfcandidatelist-setresult HRESULT SetResult( ULONG
		// nIndex, TfCandidateResult imcr );
		[PreserveSig]
		HRESULT SetResult(uint nIndex, [In] TfCandidateResult imcr);
	}

	/// <summary>The <c>ITfCandidateListUIElement</c> interface is implemented by a text service that has the candidate list UI.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcandidatelistuielement
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfCandidateListUIElement")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("EA1EA138-19DF-11D7-A6D2-00065B84435C")]
	public interface ITfCandidateListUIElement : ITfUIElement
	{
		/// <summary>The <c>ITfUIElement::GetDescription</c> method returns the description of the UI element.</summary>
		/// <param name="pbstrDescription">[in] A pointer to BSTR that contains the description of the UI element.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-getdescription HRESULT GetDescription( BSTR
		// *pbstrDescription );
		[PreserveSig]
		new HRESULT GetDescription([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrDescription);

		/// <summary>The <c>ITfUIElement::GetGUID</c> method returns the unique id of this UI element.</summary>
		/// <param name="pguid">[out] A pointer to receive the GUID of the UI element.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-getguid HRESULT GetGUID( GUID *pguid );
		[PreserveSig]
		new HRESULT GetGUID(out Guid pguid);

		/// <summary>The <c>ITfUIElement::Show</c> method shows the text service's UI of this UI element.</summary>
		/// <param name="bShow">
		/// [in] <c>TRUE</c> to show the original UI of the element. <c>FALSE</c> to hide the original UI of the element.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-show HRESULT Show( BOOL bShow );
		[PreserveSig]
		new HRESULT Show([In, MarshalAs(UnmanagedType.Bool)] bool bShow);

		/// <summary>
		/// The <c>ITfUIElement::IsShown</c> method returns true if the UI is currently shown by a text service; otherwise false.
		/// </summary>
		/// <param name="pbShow">[out] A pointer to bool of the current show status of the original UI of this element.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-isshown HRESULT IsShown( BOOL *pbShow );
		[PreserveSig]
		new HRESULT IsShown([Out, MarshalAs(UnmanagedType.Bool)] out bool pbShow);

		/// <summary>
		/// The <c>ITfCandidateListUIElement::GetUpdatedFlags</c> method returns the flag that tells which part of this element was updated.
		/// </summary>
		/// <param name="pdwFlags">
		/// <para>[out] a pointer to receive the flags that is a combination of the following bits:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_CLUIE_DOCUMENTMGR</term>
		/// <term>The target document manager was changed.</term>
		/// </item>
		/// <item>
		/// <term>TF_CLUIE_COUNT</term>
		/// <term>The count of the candidate string was changed.</term>
		/// </item>
		/// <item>
		/// <term>TF_CLUIE_SELECTION</term>
		/// <term>The selection of the candidate was changed.</term>
		/// </item>
		/// <item>
		/// <term>TF_CLUIE_STRING</term>
		/// <term>Some strings in the list were changed.</term>
		/// </item>
		/// <item>
		/// <term>TF_CLUIE_PAGEINDEX</term>
		/// <term>The current page index or some page index was changed.</term>
		/// </item>
		/// <item>
		/// <term>TF_CLUIE_CURRENTPAGE</term>
		/// <term>The page was changed.</term>
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
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-getupdatedflags HRESULT
		// GetUpdatedFlags( DWORD *pdwFlags );
		[PreserveSig]
		HRESULT GetUpdatedFlags(out TF_CLUIE pdwFlags);

		/// <summary>The <c>ITfCandidateListUIElement::GetDocumentMgr</c> method returns the target document manager of this UI.</summary>
		/// <param name="ppdim">[out] A pointer to receive ITfDocumentMgr interface pointer.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-getdocumentmgr HRESULT
		// GetDocumentMgr( ITfDocumentMgr **ppdim );
		[PreserveSig]
		HRESULT GetDocumentMgr(out ITfDocumentMgr ppdim);

		/// <summary>The <c>ITfCandidateListUIElement::GetCount</c> method returns the count of the candidate strings.</summary>
		/// <param name="puCount">[out] A pointer to receive a count of the candidate strings.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-getcount HRESULT GetCount( UINT
		// *puCount );
		[PreserveSig]
		HRESULT GetCount(out uint puCount);

		/// <summary>The <c>ITfCandidateListUIElement::GetSelection</c> method returns the current selection of the candidate list.</summary>
		/// <param name="puIndex">[out] A pointer to receive an index of the current selected candidate string.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-getselection HRESULT
		// GetSelection( UINT *puIndex );
		[PreserveSig]
		HRESULT GetSelection(out uint puIndex);

		/// <summary>The <c>ITfCandidateListUIElement::GetString</c> method returns the string of the index.</summary>
		/// <param name="uIndex">[in] An index of the string to obtain.</param>
		/// <param name="pstr">[out] A pointer to BSTR for the candidate string of the index.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-getstring HRESULT GetString( UINT
		// uIndex, BSTR *pstr );
		[PreserveSig]
		HRESULT GetString(uint uIndex, [Out, MarshalAs(UnmanagedType.BStr)] out string pstr);

		/// <summary>The <c>ITfCandidateListUIElement::GetPageIndex</c> method returns the page index of the list.</summary>
		/// <param name="pIndex">
		/// [out] A pointer that receives an array of the indexes that each page starts from. This can be <c>NULL</c>. The caller calls
		/// this method with <c>NULL</c> for this parameter first to get the number of pages in puPageCnt and allocates the buffer to
		/// receive indexes for all pages.
		/// </param>
		/// <param name="uSize">[in] A buffer size of pIndex.</param>
		/// <param name="puPageCnt">[out] A pointer to receive the page count.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-getpageindex HRESULT
		// GetPageIndex( UINT *pIndex, UINT uSize, UINT *puPageCnt );
		[PreserveSig]
		HRESULT GetPageIndex([Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pIndex, uint uSize, out uint puPageCnt);

		/// <summary>The <c>ITfCandidateListUIElement::SetPageIndex</c> method sets the page index.</summary>
		/// <param name="pIndex">[in] A pointer to an array of the indexes that each page starts from.</param>
		/// <param name="uPageCnt">[in] A page count. The size of the pIndex buffer.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-setpageindex HRESULT
		// SetPageIndex( UINT *pIndex, UINT uPageCnt );
		[PreserveSig]
		HRESULT SetPageIndex([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pIndex, uint uPageCnt);

		/// <summary>The <c>ITfCandidateListUIElement::GetCurrentPage</c> method returns the current page.</summary>
		/// <param name="puPage">[in] A pointer to receive the current page index.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-getcurrentpage HRESULT
		// GetCurrentPage( UINT *puPage );
		[PreserveSig]
		HRESULT GetCurrentPage(out uint puPage);
	}

	/// <summary>
	/// This interface is implemented by a text service that has a candidate list UI and its UI can be controlled by the application.
	/// The application QI this interface from ITfUIElement and controls the candidate list behavior.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcandidatelistuielementbehavior
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfCandidateListUIElementBehavior")]
	[ComImport, Guid("85FAD185-58CE-497A-9460-355366B64B9A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfCandidateListUIElementBehavior : ITfCandidateListUIElement
	{
		/// <summary>The <c>ITfUIElement::GetDescription</c> method returns the description of the UI element.</summary>
		/// <param name="pbstrDescription">[in] A pointer to BSTR that contains the description of the UI element.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-getdescription HRESULT GetDescription( BSTR
		// *pbstrDescription );
		[PreserveSig]
		new HRESULT GetDescription([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrDescription);

		/// <summary>The <c>ITfUIElement::GetGUID</c> method returns the unique id of this UI element.</summary>
		/// <param name="pguid">[out] A pointer to receive the GUID of the UI element.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-getguid HRESULT GetGUID( GUID *pguid );
		[PreserveSig]
		new HRESULT GetGUID(out Guid pguid);

		/// <summary>The <c>ITfUIElement::Show</c> method shows the text service's UI of this UI element.</summary>
		/// <param name="bShow">
		/// [in] <c>TRUE</c> to show the original UI of the element. <c>FALSE</c> to hide the original UI of the element.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-show HRESULT Show( BOOL bShow );
		[PreserveSig]
		new HRESULT Show([In, MarshalAs(UnmanagedType.Bool)] bool bShow);

		/// <summary>
		/// The <c>ITfUIElement::IsShown</c> method returns true if the UI is currently shown by a text service; otherwise false.
		/// </summary>
		/// <param name="pbShow">[out] A pointer to bool of the current show status of the original UI of this element.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfuielement-isshown HRESULT IsShown( BOOL *pbShow );
		[PreserveSig]
		new HRESULT IsShown([Out, MarshalAs(UnmanagedType.Bool)] out bool pbShow);

		/// <summary>
		/// The <c>ITfCandidateListUIElement::GetUpdatedFlags</c> method returns the flag that tells which part of this element was updated.
		/// </summary>
		/// <param name="pdwFlags">
		/// <para>[out] a pointer to receive the flags that is a combination of the following bits:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_CLUIE_DOCUMENTMGR</term>
		/// <term>The target document manager was changed.</term>
		/// </item>
		/// <item>
		/// <term>TF_CLUIE_COUNT</term>
		/// <term>The count of the candidate string was changed.</term>
		/// </item>
		/// <item>
		/// <term>TF_CLUIE_SELECTION</term>
		/// <term>The selection of the candidate was changed.</term>
		/// </item>
		/// <item>
		/// <term>TF_CLUIE_STRING</term>
		/// <term>Some strings in the list were changed.</term>
		/// </item>
		/// <item>
		/// <term>TF_CLUIE_PAGEINDEX</term>
		/// <term>The current page index or some page index was changed.</term>
		/// </item>
		/// <item>
		/// <term>TF_CLUIE_CURRENTPAGE</term>
		/// <term>The page was changed.</term>
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
		/// <term>E_FAIL</term>
		/// <term>An unspecified error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-getupdatedflags HRESULT
		// GetUpdatedFlags( DWORD *pdwFlags );
		[PreserveSig]
		new HRESULT GetUpdatedFlags(out TF_CLUIE pdwFlags);

		/// <summary>The <c>ITfCandidateListUIElement::GetDocumentMgr</c> method returns the target document manager of this UI.</summary>
		/// <param name="ppdim">[out] A pointer to receive ITfDocumentMgr interface pointer.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-getdocumentmgr HRESULT
		// GetDocumentMgr( ITfDocumentMgr **ppdim );
		[PreserveSig]
		new HRESULT GetDocumentMgr(out ITfDocumentMgr ppdim);

		/// <summary>The <c>ITfCandidateListUIElement::GetCount</c> method returns the count of the candidate strings.</summary>
		/// <param name="puCount">[out] A pointer to receive a count of the candidate strings.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-getcount HRESULT GetCount( UINT
		// *puCount );
		[PreserveSig]
		new HRESULT GetCount(out uint puCount);

		/// <summary>The <c>ITfCandidateListUIElement::GetSelection</c> method returns the current selection of the candidate list.</summary>
		/// <param name="puIndex">[out] A pointer to receive an index of the current selected candidate string.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-getselection HRESULT
		// GetSelection( UINT *puIndex );
		[PreserveSig]
		new HRESULT GetSelection(out uint puIndex);

		/// <summary>The <c>ITfCandidateListUIElement::GetString</c> method returns the string of the index.</summary>
		/// <param name="uIndex">[in] An index of the string to obtain.</param>
		/// <param name="pstr">[out] A pointer to BSTR for the candidate string of the index.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-getstring HRESULT GetString( UINT
		// uIndex, BSTR *pstr );
		[PreserveSig]
		new HRESULT GetString(uint uIndex, [Out, MarshalAs(UnmanagedType.BStr)] out string pstr);

		/// <summary>The <c>ITfCandidateListUIElement::GetPageIndex</c> method returns the page index of the list.</summary>
		/// <param name="pIndex">
		/// [out] A pointer that receives an array of the indexes that each page starts from. This can be <c>NULL</c>. The caller calls
		/// this method with <c>NULL</c> for this parameter first to get the number of pages in puPageCnt and allocates the buffer to
		/// receive indexes for all pages.
		/// </param>
		/// <param name="uSize">[in] A buffer size of pIndex.</param>
		/// <param name="puPageCnt">[out] A pointer to receive the page count.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-getpageindex HRESULT
		// GetPageIndex( UINT *pIndex, UINT uSize, UINT *puPageCnt );
		[PreserveSig]
		new HRESULT GetPageIndex([Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pIndex, uint uSize, out uint puPageCnt);

		/// <summary>The <c>ITfCandidateListUIElement::SetPageIndex</c> method sets the page index.</summary>
		/// <param name="pIndex">[in] A pointer to an array of the indexes that each page starts from.</param>
		/// <param name="uPageCnt">[in] A page count. The size of the pIndex buffer.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-setpageindex HRESULT
		// SetPageIndex( UINT *pIndex, UINT uPageCnt );
		[PreserveSig]
		new HRESULT SetPageIndex([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pIndex, uint uPageCnt);

		/// <summary>The <c>ITfCandidateListUIElement::GetCurrentPage</c> method returns the current page.</summary>
		/// <param name="puPage">[in] A pointer to receive the current page index.</param>
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
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielement-getcurrentpage HRESULT
		// GetCurrentPage( UINT *puPage );
		[PreserveSig]
		new HRESULT GetCurrentPage(out uint puPage);

		/// <summary>The <c>ITfCandidateListUIElementBehavior::SetSelection</c> method set the selection of the candidate list.</summary>
		/// <param name="nIndex">[in] An index for the candidate string to be selected.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielementbehavior-setselection HRESULT
		// SetSelection( UINT nIndex );
		[PreserveSig]
		HRESULT SetSelection(uint nIndex);

		/// <summary>
		/// The <c>ITfCandidateListUIElementBehavior::Finalize</c> method finalizes the current selection and close the candidate list.
		/// </summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielementbehavior-finalize HRESULT Finalize();
		[PreserveSig]
		HRESULT Finalize();

		/// <summary>
		/// The <c>ITfCandidateListUIElementBehavior::Abort</c> method closes the candidate list. There is no guarantee that the current
		/// selection will be finalized.
		/// </summary>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcandidatelistuielementbehavior-abort HRESULT Abort();
		[PreserveSig]
		HRESULT Abort();
	}

	/// <summary>
	/// <para>The <c>ITfCategoryMgr</c> interface manages categories of objects for text services. The TSF manager implements this interface.</para>
	/// <para>
	/// TSF categories help organize objects identified by a globally unique identifier ( GUID ). For example, a class identifier (
	/// CLSID ) identifies a text service, and a GUID identifies the TSF compartment, TSF properties, and TSF display attributes. To
	/// group and organize multiple GUIDs, TSF uses category identifiers ( CATIDs).
	/// </para>
	/// <para>
	/// The category manager uses an internal table, accessed with keys called GUID atoms to cache the GUIDs. Access to GUIDs is
	/// efficient using these atoms. When a GUID is obtained using its atom, the GUID description and value can be obtained from the
	/// Windows registry.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcategorymgr
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfCategoryMgr")]
	[ComImport, Guid("C3ACEFB5-F69D-4905-938F-FCADCF4BE830"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(TF_CategoryMgr))]
	public interface ITfCategoryMgr
	{
		/// <summary>Adds a specified GUID to the specified category in the Windows registry.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service that owns the item.</param>
		/// <param name="rcatid">
		/// Contains a GUID value that identifies the category to register the item under. This can be a user-defined category or one of
		/// the predefined category values.
		/// </param>
		/// <param name="rguid">Contains a GUID value that identifies the item to register.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcategorymgr-registercategory HRESULT RegisterCategory(
		// REFCLSID rclsid, REFGUID rcatid, REFGUID rguid );
		void RegisterCategory(in Guid rclsid, in Guid rcatid, in Guid rguid);

		/// <summary>Removes a specified GUID from the specified category in the Windows registry.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service that owns the item.</param>
		/// <param name="rcatid">Contains a GUID that identifies the category that the item is registered under.</param>
		/// <param name="rguid">Contains a GUID that identifies the item to remove.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcategorymgr-unregistercategory HRESULT
		// UnregisterCategory( REFCLSID rclsid, REFGUID rcatid, REFGUID rguid );
		void UnregisterCategory(in Guid rclsid, in Guid rcatid, in Guid rguid);

		/// <summary>Obtains an IEnumGUID interface that enumerates all categories to which the specified GUID belongs.</summary>
		/// <param name="rguid">Contains a GUID value that identifies the item to enumerate the categories for.</param>
		/// <returns>Pointer to an IEnumGUID interface pointer that receives the enumerator.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcategorymgr-enumcategoriesinitem HRESULT
		// EnumCategoriesInItem( REFGUID rguid, IEnumGUID **ppEnum );
		IEnumGUID EnumCategoriesInItem(in Guid rguid);

		/// <summary>Obtains an IEnumGUID interface that enumerates all GUIDs included in the specified category.</summary>
		/// <param name="rcatid">Contains a GUID value that identifies the category to enumerate the items for.</param>
		/// <returns>Pointer to an IEnumGUID interface pointer that receives the enumerator.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcategorymgr-enumitemsincategory HRESULT
		// EnumItemsInCategory( REFGUID rcatid, IEnumGUID **ppEnum );
		IEnumGUID EnumItemsInCategory(in Guid rcatid);

		/// <summary>Finds the category closest to the specified GUID from a list of categories.</summary>
		/// <param name="rguid">Specifies the address of the GUID for which to find the closest category.</param>
		/// <param name="pcatid">Pointer to the <c>GUID</c> that receives the CATID for the closest category.</param>
		/// <param name="ppcatidList">Pointer to a pointer that specifies an array of CATIDs to search for the closest category.</param>
		/// <param name="ulCount">Specifies the number of elements in the array of the ppcatidList parameter.</param>
		/// <remarks>
		/// The closest category to a <c>GUID</c> is chosen in one of two modes. In the first mode, the method receives a non-empty
		/// category list. It chooses the first matching <c>CATID</c> from that list or GUID_NULL if the list does not contain a
		/// category that contains the <c>GUID</c> . In the second mode, it receives an empty category list. It chooses the first
		/// category that contains the <c>GUID</c> or GUID_NULL if no category contains the <c>GUID</c> .
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcategorymgr-findclosestcategory HRESULT
		// FindClosestCategory( REFGUID rguid, GUID *pcatid, const GUID **ppcatidList, ULONG ulCount );
		void FindClosestCategory(in Guid rguid, out Guid pcatid, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] Guid[] ppcatidList, uint ulCount);

		/// <summary>Enters a description for a GUID previously registered in the Windows registry.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service that owns the GUID.</param>
		/// <param name="rguid">Contains the GUID that the description is registered for.</param>
		/// <param name="pchDesc">Pointer to a <c>WCHAR</c> buffer that contains the description for the GUID.</param>
		/// <param name="cch">Contains the length, in characters, of the description string.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcategorymgr-registerguiddescription HRESULT
		// RegisterGUIDDescription( REFCLSID rclsid, REFGUID rguid, const WCHAR *pchDesc, ULONG cch );
		void RegisterGUIDDescription(in Guid rclsid, in Guid rguid, [In, MarshalAs(UnmanagedType.LPWStr)] string pchDesc, uint cch);

		/// <summary>Removes the description for a GUID from the Windows registry.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service that owns the GUID.</param>
		/// <param name="rguid">Contains the GUID that the description is removed for.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcategorymgr-unregisterguiddescription HRESULT
		// UnregisterGUIDDescription( REFCLSID rclsid, REFGUID rguid );
		void UnregisterGUIDDescription(in Guid rclsid, in Guid rguid);

		/// <summary>Obtains the description of the specified GUID from the Windows registry.</summary>
		/// <param name="rguid">Specifies the GUID to obtain the description for.</param>
		/// <returns>
		/// <para>
		/// Pointer to a <c>BSTR</c> value that receives the description string. Allocate using SysAllocString. The caller must free
		/// this memory using SysFreeString when it is no longer required.
		/// </para>
		/// <para>
		/// Pointer to a <c>BSTR</c> value that receives the description string. This must be allocated using <c>SysAllocString</c>. The
		/// caller must free this memory using <c>SysFreeString</c> when it is no longer required.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcategorymgr-getguiddescription HRESULT
		// GetGUIDDescription( REFGUID rguid, BSTR *pbstrDesc );
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetGUIDDescription(in Guid rguid);

		/// <summary>Enters a DWORD value for a GUID previously registered in the Windows registry.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service that owns the GUID.</param>
		/// <param name="rguid">Contains the GUID that the <c>DWORD</c> is registered for.</param>
		/// <param name="dw">Contains the <c>DWORD</c> value registered for the GUID.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcategorymgr-registerguiddword HRESULT RegisterGUIDDWORD(
		// REFCLSID rclsid, REFGUID rguid, DWORD dw );
		void RegisterGUIDDWORD(in Guid rclsid, in Guid rguid, uint dw);

		/// <summary>Removes the DWORD value for a GUID from the Windows registry.</summary>
		/// <param name="rclsid">Contains the CLSID of the text service that owns the GUID.</param>
		/// <param name="rguid">Contains the GUID that the <c>DWORD</c> is removed for.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcategorymgr-unregisterguiddword HRESULT
		// UnregisterGUIDDWORD( REFCLSID rclsid, REFGUID rguid );
		void UnregisterGUIDDWORD(in Guid rclsid, in Guid rguid);

		/// <summary>Obtains the DWORD value of the specified GUID from the Windows registry.</summary>
		/// <param name="rguid">Specifies the address of the GUID for which to get the value.</param>
		/// <returns>Pointer to the <c>DWORD</c> variable that receives the value of the GUID.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcategorymgr-getguiddword HRESULT GetGUIDDWORD( REFGUID
		// rguid, DWORD *pdw );
		uint GetGUIDDWORD(in Guid rguid);

		/// <summary>Adds a GUID to the internal table and obtains an atom for the GUID.</summary>
		/// <param name="rguid">Contains the GUID to obtain the identifier for.</param>
		/// <returns>Pointer to a TfGuidAtom value that receives the identifier of the GUID.</returns>
		/// <remarks>
		/// <para>Identical <c>GUID</c> values receive identical <c>TfGuidAtom</c> values.</para>
		/// <para>A <c>TfGuidAtom</c> value is only valid within the process that <c>ITfCategoryMgr::RegisterGUID</c> is called from.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcategorymgr-registerguid HRESULT RegisterGUID( REFGUID
		// rguid, TfGuidAtom *pguidatom );
		TfGuidAtom RegisterGUID(in Guid rguid);

		/// <summary>Obtains a GUID from the internal table using its atom.</summary>
		/// <param name="guidatom">Contains a <c>TfGuidAtom</c> value that specifies the GUID to obtain.</param>
		/// <returns>
		/// Pointer to a <c>GUID</c> value that receives the <c>GUID</c> for the specified atom. Receives GUID_NULL if the <c>GUID</c>
		/// for the atom cannot be found.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcategorymgr-getguid HRESULT GetGUID( TfGuidAtom
		// guidatom, GUID *pguid );
		Guid GetGUID([In] TfGuidAtom guidatom);

		/// <summary>Determines whether the specified atom represents the specified GUID in the internal table.</summary>
		/// <param name="guidatom">Specifies an atom that represents a GUID in the internal table.</param>
		/// <param name="rguid">Specifies the address of the GUID to compare with the atom in the internal table.</param>
		/// <returns>Pointer to a Boolean variable that receives an indication of whether the atom represents the GUID.</returns>
		/// <remarks>
		/// If the atom specified by the guidatom parameter represents the <c>GUID</c> specified by the rguid parameter, the pfEqual
		/// parameter receives a nonzero value. Otherwise, the pfEqual parameter receives zero.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcategorymgr-isequaltfguidatom HRESULT IsEqualTfGuidAtom(
		// TfGuidAtom guidatom, REFGUID rguid, BOOL *pfEqual );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsEqualTfGuidAtom([In] TfGuidAtom guidatom, in Guid rguid);
	}

	/// <summary>
	/// The <c>ITfCleanupContextDurationSink</c> interface is implemented by a text service to receive notifications when a context
	/// cleanup operation is performed. This notification sink is installed by calling ITfSourceSingle::AdviseSingleSink with IID_ITfCleanupContextDurationSink.
	/// </summary>
	/// <remarks>
	/// <para>A context cleanup occurs when:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The text service is deactivated while a context is still on the context stack. This can occur when the active text service is
	/// changed or when the active language changes while the text service is active.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ITfThreadMgr::Deactivate is called while a context is still on the context stack.</term>
	/// </item>
	/// </list>
	/// <para>
	/// A text service can use the notifications of this interface to prevent itself from performing any context initialization during
	/// the context cleanup operation.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcleanupcontextdurationsink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfCleanupContextDurationSink")]
	[ComImport, Guid("45C35144-154E-4797-BED8-D33AE7BF8794"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfCleanupContextDurationSink
	{
		/// <summary>Called when a context cleanup operation is about to begin.</summary>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>A context cleanup occurs when:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The text service is deactivated while a context is still on the context stack. This can occur when the active text service
		/// is changed or when the active language changes while the text service is active.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ITfThreadMgr::Deactivate is called while a context is still on the context stack.</term>
		/// </item>
		/// </list>
		/// <para>
		/// ITfCleanupContextDurationSink::OnStartCleanupContext is called just before the TSF manager begins making
		/// ITfCleanupContextSink::OnCleanupContext notifications. When all of the OnCleanupContext notifications complete, the TSF
		/// manager calls <c>OnEndCleanupContext</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcleanupcontextdurationsink-onstartcleanupcontext HRESULT OnStartCleanupContext();
		[PreserveSig]
		HRESULT OnStartCleanupContext();

		/// <summary>Called when a context cleanup operation completes.</summary>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>A context cleanup occurs when:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The text service is deactivated while a context is still on the context stack. This can occur when the active text service
		/// is changed or when the active language changes while the text service is active.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ITfThreadMgr::Deactivate is called while a context is still on the context stack.</term>
		/// </item>
		/// </list>
		/// <para>
		/// ITfCleanupContextDurationSink::OnStartCleanupContext is called just before the TSF manager begins making
		/// ITfCleanupContextSink::OnCleanupContext notifications. When all of the OnCleanupContext notifications complete, the TSF
		/// manager calls <c>OnEndCleanupContext</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcleanupcontextdurationsink-onendcleanupcontext HRESULT OnEndCleanupContext();
		[PreserveSig]
		HRESULT OnEndCleanupContext();
	}

	/// <summary>
	/// The <c>ITfCleanupContextSink</c> interface is implemented by a text service to receive notifications when a context cleanup
	/// operation occurs. This notification sink is installed by calling ITfSourceSingle::AdviseSingleSink with IID_ITfCleanupContextSink.
	/// </summary>
	/// <remarks>
	/// <para>A context cleanup occurs when:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The text service is deactivated while a context is still on the context stack. This can occur when the active text service is
	/// changed or when the active language changes while the text service is active.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ITfThreadMgr::Deactivate is called while a context is still on the context stack.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcleanupcontextsink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfCleanupContextSink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("01689689-7ACB-4E9B-AB7C-7EA46B12B522")]
	public interface ITfCleanupContextSink
	{
		/// <summary>Called during a context cleanup operation.</summary>
		/// <param name="ecWrite">
		/// Contains a TfEditCookie value that identifies the edit context cleaned up. The edit context is guaranteed to have a
		/// read/write lock.
		/// </param>
		/// <param name="pic">Pointer to an ITfContext interface that represents the context cleaned up.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>A context cleanup occurs when:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The text service is deactivated while a context is still on the context stack. This can occur when the active text service
		/// is changed or when the active language changes while the text service is active.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ITfThreadMgr::Deactivate is called while a context is still on the context stack.</term>
		/// </item>
		/// </list>
		/// <para>
		/// ITfCleanupContextDurationSink::OnStartCleanupContext is called just before the TSF manager begins making
		/// ITfCleanupContextSink::OnCleanupContext notifications. When all of the OnCleanupContext notifications complete, the TSF
		/// manager calls <c>OnEndCleanupContext</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcleanupcontextsink-oncleanupcontext HRESULT
		// OnCleanupContext( TfEditCookie ecWrite, ITfContext *pic );
		[PreserveSig]
		HRESULT OnCleanupContext([In] TfEditCookie ecWrite, [In] ITfContext pic);
	}

	/// <summary>
	/// The <c>ITfClientId</c> interface is implemented by the TSF manager. This interface is used to obtain a client identifier for TSF
	/// objects. An instance of this interface is obtained by querying the thread manager with IID_ITfClientId.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfclientid
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfClientId")]
	[ComImport, Guid("D60A7B49-1B9F-4BE2-B702-47E9DC05DEC3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfClientId
	{
		/// <summary>Obtains a client identifier for a CLSID.</summary>
		/// <param name="rclsid">CLSID to obtain the client identifier for.</param>
		/// <returns>Pointer to a TfClientId value that receives the client identifier.</returns>
		/// <remarks>
		/// An application obtains its client identifier by calling ITfThreadMgr::Activate and a text service receives its client
		/// identifier in its ITfTextInputProcessor::Activate method. <c>ITfClientId::GetClientId</c> enables TSF objects that do not
		/// fit either of these categories to obtain their own client identifier.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfclientid-getclientid HRESULT GetClientId( REFCLSID
		// rclsid, TfClientId *ptid );
		TfClientId GetClientId(in Guid rclsid);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfCompartment</c> interface is implemented by the TSF manager and is used by clients (applications and text services) to
	/// obtain and set data in a TSF compartment.
	/// </para>
	/// <para>
	/// A client also uses this interface to obtain an ITfSource interface that is used to install an ITfCompartmentEventSink
	/// compartment change notification sink. The client calls <c>ITfCompartment::QueryInterface</c> with IID_ITfSource to obtain the
	/// <c>ITfSource</c> interface.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcompartment
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfCompartment")]
	[ComImport, Guid("BB08F7A9-607A-4384-8623-056892B64371"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfCompartment
	{
		/// <summary>Sets the data for a compartment.</summary>
		/// <param name="tid">Contains a TfClientId value that identifies the client.</param>
		/// <param name="pvarValue">
		/// Pointer to a VARIANT structure that contains the data to be set. Only VT_I4, VT_UNKNOWN and VT_BSTR data types are allowed.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcompartment-setvalue HRESULT SetValue( TfClientId tid,
		// const VARIANT *pvarValue );
		void SetValue([In] TfClientId tid, [In, MarshalAs(UnmanagedType.Struct)] in object pvarValue);

		/// <summary>Obtains the data for a compartment.</summary>
		/// <returns>
		/// Pointer to a <c>VARIANT</c> structure that receives the data. This receives VT_EMPTY if the compartment has no value. The
		/// caller must free this data when it is no longer required by calling VariantClear.
		/// </returns>
		/// <remarks>
		/// The caller must recognize the supplied data format in order to use the data. The compartment installer must publish the data
		/// format to enable other clients to use it.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcompartment-getvalue HRESULT GetValue( VARIANT
		// *pvarValue );
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetValue();
	}

	/// <summary>
	/// The <c>ITfCompartmentEventSink</c> interface is implemented by a client (application or text service) and used by the TSF
	/// manager to notify the client when compartment data changes. This notification sink is installed by obtaining an ITfSource
	/// interface from the ITfCompartment object and calling ITfSource::AdviseSink with IID_ITfCompartmentEventSink and a pointer to the
	/// <c>ITfCompartmentEventSink</c> object.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcompartmenteventsink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfCompartmentEventSink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("743ABD5F-F26D-48DF-8CC5-238492419B64")]
	public interface ITfCompartmentEventSink
	{
		/// <summary>Called when compartment data changes.</summary>
		/// <param name="rguid">Contains a GUID that identifies the compartment that changed.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>When this method is called, the data has changed. The new data can be obtained at this time by calling ITfCompartment::GetValue.</para>
		/// <para>ITfCompartment::SetValue will return E_UNEXPECTED if called from within this notification.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcompartmenteventsink-onchange HRESULT OnChange( REFGUID
		// rguid );
		[PreserveSig]
		HRESULT OnChange(in Guid rguid);
	}

	/// <summary>
	/// The <c>ITfCompartmentMgr</c> interface is implemented by the TSF manager and used by clients (applications and text services) to
	/// obtain and manipulate TSF compartments.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The set of compartments that this interface is responsible for depends upon how the interface was obtained. An instance of this
	/// interface can be obtained in one of the following ways. For more information, see Compartments.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ITfThreadMgr::GetGlobalCompartment - Obtains the global compartment manager.</term>
	/// </item>
	/// <item>
	/// <term>
	/// <c>ITfThreadMgr::QueryInterface</c> with IID_ITfCompartmentMgr - Obtains the compartment manager for this specific thread manager.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <c>ITfDocumentMgr::QueryInterface</c> with IID_ITfCompartmentMgr - Obtains the compartment manager for this specific document manager.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ITfContext::QueryInterface</c> with IID_ITfCompartmentMgr - Obtains the compartment manager for this specific context.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcompartmentmgr
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfCompartmentMgr")]
	[ComImport, Guid("7DCF57AC-18AD-438B-824D-979BFFB74B7C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfCompartmentMgr
	{
		/// <summary>Obtains the compartment object for a specified compartment.</summary>
		/// <param name="rguid">Contains a GUID that identifies the compartment.</param>
		/// <returns>Pointer to an ITfCompartment interface pointer that receives the compartment object.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcompartmentmgr-getcompartment HRESULT GetCompartment(
		// REFGUID rguid, ITfCompartment **ppcomp );
		ITfCompartment GetCompartment(in Guid rguid);

		/// <summary>Removes the specified compartment.</summary>
		/// <param name="tid">Contains a TfClientId value that identifies the client.</param>
		/// <param name="rguid">Contains a GUID that identifies the compartment.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcompartmentmgr-clearcompartment HRESULT
		// ClearCompartment( TfClientId tid, REFGUID rguid );
		void ClearCompartment([In] TfClientId tid, in Guid rguid);

		/// <summary>
		/// The <c>ITfCompartmentMgr::EnumCompartments</c> method obtains an enumerator that contains the GUID of the compartments
		/// within the compartment manager.
		/// </summary>
		/// <returns>Pointer to an <c>IEnumGUID</c> interface pointer that receives the enumerator object.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcompartmentmgr-enumcompartments HRESULT
		// EnumCompartments( IEnumGUID **ppEnum );
		IEnumGUID EnumCompartments();
	}

	/// <summary>
	/// The <c>ITfComposition</c> interface is implemented by the TSF manager and is used by a text service to obtain data about and
	/// terminate a composition. An instance of this interface is provided by the ITfContextComposition::StartComposition method.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcomposition
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfComposition")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("20168D64-5A8F-4A5A-B7BD-CFA29F4D0FD9")]
	public interface ITfComposition
	{
		/// <summary>Obtains a range object that contains the text covered by the composition.</summary>
		/// <returns>
		/// Pointer to an ITfRange interface pointer that receives the range object. It is possible that the range will have zero length.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcomposition-getrange HRESULT GetRange( ITfRange
		// **ppRange );
		ITfRange GetRange();

		/// <summary>Moves the start anchor of a composition.</summary>
		/// <param name="ecWrite">Contains an edit cookie that identifies the edit context obtained from ITfEditSession::DoEditSession.</param>
		/// <param name="pNewStart">
		/// Pointer to an ITfRange object that contains the new start anchor position. The start anchor of the context will be moved to
		/// the start anchor of this range. This method fails if the start anchor of this range is positioned beyond the end anchor of
		/// the composition.
		/// </param>
		/// <remarks>
		/// This method causes the GUID_PROP_COMPOSING property to be removed from any text removed from the composition. Likewise, the
		/// GUID_PROP_COMPOSING property will also be added to any text added to the composition.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcomposition-shiftstart HRESULT ShiftStart( TfEditCookie
		// ecWrite, ITfRange *pNewStart );
		void ShiftStart([In] TfEditCookie ecWrite, [In] ITfRange pNewStart);

		/// <summary>Moves the end anchor of a composition.</summary>
		/// <param name="ecWrite">Contains an edit cookie that identifies the edit context obtained from ITfEditSession::DoEditSession.</param>
		/// <param name="pNewEnd">
		/// Pointer to an ITfRange object that contains the new end anchor position. The end anchor of the context will be moved to the
		/// end anchor of this range. This method fails if the end anchor of this range is positioned prior to the start anchor of the composition.
		/// </param>
		/// <remarks>
		/// This method causes the GUID_PROP_COMPOSING property to be removed from any text removed from the composition. Likewise, the
		/// GUID_PROP_COMPOSING property is also added to any text added to the composition.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcomposition-shiftend HRESULT ShiftEnd( TfEditCookie
		// ecWrite, ITfRange *pNewEnd );
		void ShiftEnd([In] TfEditCookie ecWrite, [In] ITfRange pNewEnd);

		/// <summary>Terminates a composition.</summary>
		/// <param name="ecWrite">Contains an edit cookie that identifies the edit context obtained from ITfEditSession::DoEditSession.</param>
		/// <remarks>
		/// <para>
		/// This method does not release the composition object, but the ITfComposition methods will fail with E_UNEXPECTED after this
		/// method is called.
		/// </para>
		/// <para>Context owners should use the ITFContextOwnerCompositionServices::TerminateComposition method to terminate a composition.</para>
		/// <para>This method causes the GUID_PROP_COMPOSING property to be removed from the text covered by the composition.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcomposition-endcomposition HRESULT EndComposition(
		// TfEditCookie ecWrite );
		void EndComposition([In] TfEditCookie ecWrite);
	}

	/// <summary>
	/// The <c>ITfCompositionSink</c> interface is implemented by a text service to receive a notification when a composition is
	/// terminated. This advise sink is installed by passing a pointer to this interface when the composition is started with the
	/// ITfContextComposition::StartComposition method.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcompositionsink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfCompositionSink")]
	[ComImport, Guid("A781718C-579A-4B15-A280-32B8577ACC5E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfCompositionSink
	{
		/// <summary>Called when a composition is terminated.</summary>
		/// <param name="ecWrite">
		/// Contains a TfEditCookie value that identifies the edit context. This is the same value passed for ecWrite in the call to ITfContextComposition::StartComposition.
		/// </param>
		/// <param name="pComposition">Pointer to the ITfComposition object terminated.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// There is no required action for the TSF text service when this method is called. The TSF text service can use this
		/// notification to revert partially composed text into readable text or erase the composition entirely. The TSF manager will
		/// automatically clear the GUID_PROP_COMPOSING property value over the affected text.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcompositionsink-oncompositionterminated HRESULT
		// OnCompositionTerminated( TfEditCookie ecWrite, ITfComposition *pComposition );
		[PreserveSig]
		HRESULT OnCompositionTerminated([In] TfEditCookie ecWrite, [In] ITfComposition pComposition);
	}

	/// <summary>
	/// The <c>ITfCompositionView</c> interface is implemented by the TSF manager and used by an application to obtain data about a
	/// composition view. An instance of this interface is provided by one of the ITfContextOwnerCompositionSink methods.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcompositionview
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfCompositionView")]
	[ComImport, Guid("D7540241-F9A1-4364-BEFC-DBCD2C4395B7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfCompositionView
	{
		/// <summary>Obtains the class identifier of the text service that created the composition object.</summary>
		/// <returns>Pointer to a CLSID that receives the class identifier of the text service that owns the composition.</returns>
		/// <remarks>This method can be used to enable a text service to filter compositions that it does not own.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcompositionview-getownerclsid HRESULT GetOwnerClsid(
		// CLSID *pclsid );
		Guid GetOwnerClsid();

		/// <summary>Obtains a range object that contains the text covered by the composition.</summary>
		/// <returns>
		/// Pointer to an ITfRange interface pointer that receives the range object. It is possible that the range will have zero length.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcompositionview-getrange HRESULT GetRange( ITfRange
		// **ppRange );
		ITfRange GetRange();
	}

	/// <summary>
	/// The <c>ITfConfigureSystemKeystrokeFeed</c> interface is implemented by the TSF manager to enable and disable the processing of
	/// keystrokes. This interface is obtained by calling the TSF manager's <c>ITfThreadMgr::QueryInterface</c> with IID_ITfConfigureSystemKeystrokeFeed.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfconfiguresystemkeystrokefeed
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfConfigureSystemKeystrokeFeed")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0D2C969A-BC9C-437C-84EE-951C49B1A764")]
	public interface ITfConfigureSystemKeystrokeFeed
	{
		/// <summary>Prevents the TSF manager from processing keystrokes.</summary>
		/// <remarks>
		/// <para>
		/// By default, the TSF manager will process keystrokes and pass them to the text services. An application prevents this by
		/// calling this method. Typically, this method is called when text service input is inappropriate, for example when a menu is displayed.
		/// </para>
		/// <para>Calls to this method are cumulative, so every call to this method requires a subsequent call to ITfConfigureSystemKeystrokeFeed::EnableSystemKeystrokeFeed.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfconfiguresystemkeystrokefeed-disablesystemkeystrokefeed
		// HRESULT DisableSystemKeystrokeFeed();
		void DisableSystemKeystrokeFeed();

		/// <summary>Enables the TSF manager to process keystrokes after being disabled by DisableSystemKeystrokeFeed.</summary>
		/// <remarks>
		/// <para>
		/// By default, the TSF manager will process keystrokes and pass them to the text services. An application prevents this by
		/// calling <c>DisableSystemKeystrokeFeed</c> .
		/// </para>
		/// <para>
		/// Calls to <c>DisableSystemKeystrokeFeed</c> are cumulative, so every call to <c>DisableSystemKeystrokeFeed</c> requires a
		/// subsequent call to <c>EnableSystemKeystrokeFeed</c>. Calling <c>EnableSystemKeystrokeFeed</c> will not enable keystroke
		/// processing if <c>DisableSystemKeystrokeFeed</c> is called more than once.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfconfiguresystemkeystrokefeed-enablesystemkeystrokefeed
		// HRESULT EnableSystemKeystrokeFeed();
		void EnableSystemKeystrokeFeed();
	}

	/// <summary>
	/// The <c>ITfContext</c> interface is implemented by the TSF manager and used by applications and text services to access an edit context.
	/// </summary>
	/// <remarks>
	/// <para>
	/// An edit context object is created by calling ITfDocumentMgr::CreateContext. Often, a text service uses the currently active edit
	/// context. The currently active edit context is the edit context at the top of the stack of the active document manager.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// <code>
	///<![CDATA[HRESULT hr;
	/// ITfDocumentMgr *pFocusDoc;
	///
	/// hr = pThreadMgr->GetFocus(&pFocusDoc);
	/// if(SUCCEEDED(hr))
	/// {
	///    ITfContext *pContext;
	///
	///    hr = pFocusDoc->GetTop(&pContext);
	///    if(SUCCEEDED(hr))
	///    {
	///       //Use the context.
	///
	///       pContext->Release();
	///    }
	///
	///    pFocusDoc->Release();
	/// }]]>
	/// </code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcontext
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfContext")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AA80E7FD-2021-11D2-93E0-0060B067B86E")]
	public interface ITfContext
	{
		/// <summary>Obtains access to the document text and properties.</summary>
		/// <param name="tid">Contains a TfClientId value that identifies the client to establish the edit session with.</param>
		/// <param name="pes">Pointer to an ITfEditSession interface called to perform the edit session.</param>
		/// <param name="dwFlags">
		/// <para>Contains one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TF_ES_ASYNCDONTCARE</term>
		/// <term>
		/// The edit session can occur synchronously or asynchronously, at the discretion of the TSF manager. The manager will attempt
		/// to schedule a synchronous edit session for improved performance. This value cannot be combined with the TF_ES_ASYNC or
		/// TF_ES_SYNC values.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_ES_SYNC</term>
		/// <term>
		/// The edit session must be synchronous or the request will fail (with TF_E_SYNCHRONOUS). This flag should only be used in
		/// documented situations (such as keystroke handling) where it can be expected to succeed. Otherwise the call will likely fail.
		/// This value cannot be combined with the TF_ES_ASYNCDONTCARE or TF_ES_ASYNC values.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TF_ES_READ</term>
		/// <term>Requests read-only access to the context.</term>
		/// </item>
		/// <item>
		/// <term>TF_ES_READWRITE</term>
		/// <term>Requests read/write access to the context.</term>
		/// </item>
		/// <item>
		/// <term>TF_ES_ASYNC</term>
		/// <term>
		/// The edit session must be asynchronous or the request fails. This value cannot be combined with the TF_ES_ASYNCDONTCARE or
		/// TF_ES_SYNC values.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="phrSession">
		/// <para>
		/// Address of an <c>HRESULT</c> value that receives the result of the edit session request. The value received depends upon the
		/// type of edit session requested.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If an asynchronous edit session is requested and can be established, receives TF_S_ASYNC.</term>
		/// </item>
		/// <item>
		/// <term>If a synchronous edit session is requested and cannot be established, receives TF_E_SYNCHRONOUS.</term>
		/// </item>
		/// <item>
		/// <term>If the TF_ES_READWRITE flag is specified and the document is read-only, receives TS_E_READONLY.</term>
		/// </item>
		/// <item>
		/// <term>If a synchronous edit session is established, receives the return value of the ITfEditSession::DoEditSession.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// Pending asynchronous edit sessions are processed in the order received. Synchronous edit sessions are processed before any
		/// pending asynchronous edit sessions.
		/// </para>
		/// <para>
		/// A text service can request an edit session within the context of an existing edit session, provided a write access session
		/// is not requested within a read-only session. Calls to this method within the context of an edit session established by
		/// another text service will fail with TF_E_LOCKED.
		/// </para>
		/// <para>A synchronous read/write request will fail if made when processing one of the following notifications.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>ITfTextEditSink::OnEndEdit</term>
		/// </item>
		/// <item>
		/// <term>ITfTextLayoutSink::OnLayoutChange</term>
		/// </item>
		/// <item>
		/// <term>ITfStatusSink::OnStatusChange</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontext-requesteditsession HRESULT RequestEditSession(
		// TfClientId tid, ITfEditSession *pes, DWORD dwFlags, HRESULT *phrSession );
		void RequestEditSession([In] TfClientId tid, [In] ITfEditSession pes, [In] TF_ES dwFlags, out HRESULT phrSession);

		/// <summary>Determines if a client has a read/write lock on the context.</summary>
		/// <param name="tid">Contains a <c>TfClientID</c> value that identifies the client.</param>
		/// <returns>
		/// Pointer to a <c>BOOL</c> that receives a nonzero value if the client has a read/write lock on the context. Receives zero if
		/// the client does not have an edit session or has a read-only edit session.
		/// </returns>
		/// <remarks>A client uses this method, from inside a notification callback, to determine if it must make the change.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontext-inwritesession HRESULT InWriteSession(
		// TfClientId tid, BOOL *pfWriteSession );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool InWriteSession([In] TfClientId tid);

		/// <summary>Obtains the selection within the document.</summary>
		/// <param name="ec">Contains an edit cookie that identifies the edit session. This is the value passed to ITfEditSession::DoEditSession.</param>
		/// <param name="ulIndex">
		/// Specifies the zero-based index of the first selection to obtain. Use TF_DEFAULT_SELECTION to obtain the default selection.
		/// If TF_DEFAULT_SELECTION is used, only one selection is obtained.
		/// </param>
		/// <param name="ulCount">Specifies the maximum number of selections to obtain.</param>
		/// <param name="pSelection">
		/// An array of TF_SELECTION structures that receives the data for each selection. The array must be able to hold at least
		/// ulCount elements.
		/// </param>
		/// <param name="pcFetched">Pointer to a ULONG value that receives the number of selections obtained.</param>
		/// <remarks>
		/// <para>
		/// A selection is a highlighted range of text, or an insertion point if the range is empty, that identifies the user focus area
		/// within a document.
		/// </para>
		/// <para>
		/// If this method is successful, the caller must release the <c>range</c> member of all <c>TF_SELECTION</c> structures obtained.
		/// </para>
		/// <para>
		/// Normally, a context only supports a single selection. It is possible, however, for a context to support multiple,
		/// simultaneous selections. This method can be used to obtain multiple selections.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontext-getselection HRESULT GetSelection( TfEditCookie
		// ec, ULONG ulIndex, ULONG ulCount, TF_SELECTION *pSelection, ULONG *pcFetched );
		void GetSelection([In] TfEditCookie ec, uint ulIndex, uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] TF_SELECTION[] pSelection, [NullAllowed] out uint pcFetched);

		/// <summary>Sets the selection within the document.</summary>
		/// <param name="ec">Contains an edit cookie that identifies the edit session. This is the value passed to ITfEditSession::DoEditSession.</param>
		/// <param name="ulCount">Specifies the number of selections in the pSelection array.</param>
		/// <param name="pSelection">An array of TF_SELECTION structures that contain the information for each selection.</param>
		/// <remarks>
		/// <para>
		/// A selection is a span of highlighted text, or an insertion point if the span is empty, identifying the user focus area
		/// within a document. Some documents are capable of having multiple selections. There can only be one zero-length selection in
		/// pSelection as it represents the position of the document caret.
		/// </para>
		/// <para>
		/// If an application must adjust the text covered by a selection, it should wait until the caller releases the lock. However,
		/// applications can adjust any of the <c>style</c> members of the <c>TF_SELECTION</c> structures while still returning S_OK.
		/// </para>
		/// <para>
		/// The caller can set the <c>fInterimChar</c> flag only if one selection is set. In this case, the selection should span
		/// exactly one character and the <c>ase</c> member of the <c>TF_SELECTION</c> structure is set to TFAE_NONE.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontext-setselection HRESULT SetSelection( TfEditCookie
		// ec, ULONG ulCount, const TF_SELECTION *pSelection );
		void SetSelection([In] TfEditCookie ec, uint ulCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TF_SELECTION[] pSelection);

		/// <summary>Obtains a range of text positioned at the beginning of the document.</summary>
		/// <param name="ec">Contains an edit cookie that identifies the edit session. This is the value passed to ITfEditSession::DoEditSession.</param>
		/// <returns>Pointer to an ITfRange interface that receives an empty range positioned at the start of the document.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontext-getstart HRESULT GetStart( TfEditCookie ec,
		// ITfRange **ppStart );
		ITfRange GetStart([In] TfEditCookie ec);

		/// <summary>Obtains a range of text positioned at the end of the document.</summary>
		/// <param name="ec">Contains an edit cookie that identifies the edit session. This is the value passed to ITfEditSession::DoEditSession.</param>
		/// <returns>Pointer to an ITfRange interface pointer that receives an empty range positioned at the end of the document.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontext-getend HRESULT GetEnd( TfEditCookie ec, ITfRange
		// **ppEnd );
		ITfRange GetEnd([In] TfEditCookie ec);

		/// <summary>Obtains the active view for the context.</summary>
		/// <returns>Pointer to an ITfContextView interface pointer that receives a reference to the active view.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontext-getactiveview HRESULT GetActiveView(
		// ITfContextView **ppView );
		ITfContextView GetActiveView();

		/// <summary>This method has no parameters.</summary>
		/// <returns>This method does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/itfcontext-enumviews void ();
		IEnumTfContextViews EnumViews();

		/// <summary>Obtains the document status.</summary>
		/// <returns>Pointer to a TF_STATUS structure that receives the document status data.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontext-getstatus HRESULT GetStatus( TF_STATUS *pdcs );
		TS_STATUS GetStatus();

		/// <summary>Obtains a text property.</summary>
		/// <param name="guidProp">
		/// Specifies the property identifier. This can be a custom identifier or one of the predefined property identifiers.
		/// </param>
		/// <returns>Pointer to an ITfProperty interface pointer that receives the property object.</returns>
		/// <remarks>
		/// An application or text service can define unique properties identified by a GUID. Properties are stored as VARIANT data, so
		/// the caller must recognize the format and meaning of unique properties to be able to use them.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontext-getproperty HRESULT GetProperty( REFGUID
		// guidProp, ITfProperty **ppProp );
		ITfProperty GetProperty(in Guid guidProp);

		/// <summary>Obtains an application property.</summary>
		/// <param name="guidProp">
		/// Specifies the property identifier. This can be a custom identifier or one of the predefined property identifiers.
		/// </param>
		/// <returns>Pointer to an ITfReadOnlyProperty interface pointer that receives the property object.</returns>
		/// <remarks>
		/// <para>
		/// Applications can define unique properties identified by a GUID. Properties are stored as VARIANT data, so the caller must
		/// recognize the format and meaning of unique properties to be able to use them.
		/// </para>
		/// <para>
		/// Application properties differ from text properties, obtained by ITfContext::GetProperty, in that, application properties are
		/// maintained by the context owner and cannot be modified by a text service. Application properties can only be modified by the
		/// context owner.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontext-getappproperty HRESULT GetAppProperty( REFGUID
		// guidProp, ITfReadOnlyProperty **ppProp );
		ITfReadOnlyProperty GetAppProperty(in Guid guidProp);

		/// <summary>Obtains a special property that can enumerate multiple properties over multiple ranges.</summary>
		/// <param name="prgProp">Contains an array of property identifiers that specify the properties to track.</param>
		/// <param name="cProp">Contains the number of property identifiers in the prgProp array.</param>
		/// <param name="prgAppProp">
		/// Contains an array of application property identifiers that specify the application properties to track.
		/// </param>
		/// <param name="cAppProp">Contains the number of application property identifiers in the prgAppProp array.</param>
		/// <returns>Pointer to an ITfReadOnlyProperty interface pointer that receives the tracking property.</returns>
		/// <remarks>
		/// <para>
		/// This method is used to quickly identify ranges with consistent property values for multiple properties. While this method
		/// could be duplicated using only the ITfContext::GetProperty method, the TSF manager can accomplish this task more quickly.
		/// </para>
		/// <para>
		/// The property obtained by this method is a VT_UNKNOWN type. This property can be used to obtain an IEnumTfPropertyValue
		/// enumerator by calling the <c>QueryInterface</c> method with IID_IEnumTfPropertyValue. This enumerator contains property
		/// values specified by prgProp and prgAppProp.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// <code>
		///<![CDATA[const GUID *rgGuids[2] = {  &GUID_PROP_COMPOSING, &GUID_PROP_ATTRIBUTE };
		/// HRESULT hr;
		/// ITfReadOnlyProperty *pTrackProperty;
		/// TF_SELECTION sel;
		/// IEnumTfRanges *pEnumRanges;
		/// ITfRange *pRangeValue;
		///
		/// // Get the tracking property.
		/// hr = pContext->TrackProperties(NULL, 0, rgGuids, 2, &pTrackProperty);
		///
		/// // Get the selection range.
		/// hr = pContext->GetSelection(ec, TF_DEFAULT_SELECTION, 1, &sel, &cFetched);
		///
		/// // Use the property from TrackProperties to get an enumeration of the ranges
		/// // within the selection range that have the same property values.
		/// hr = pTrackProperty->EnumRanges(ec, &pEnumRanges, sel.range);
		///
		/// // Enumerate the ranges of text.
		/// while(pEnumRanges->Next(1, &pRangeValue, NULL) == S_OK)
		/// {
		///    VARIANT varTrackerValue;
		///    TF_PROPERTYVAL tfPropertyVal;
		///    IEnumTfPropertyValue *pEnumPropVal;
		///
		///    // Get the values for this range of text.
		///    hr = pTrackProperty->GetValue(ec, pRangeValue, &varTrackerValue);
		///
		///    // Because pTrackProperties originates from TrackProperties,
		///    // varTrackerValue can be identified as a VT_UNKNOWN/IEnumTfPropertyValue.
		///    varTrackerValue.punkVal->QueryInterface(IID_IEnumTfPropertyValue, (void **)&pEnumPropVal);
		///
		///    while(pEnumPropVal->Next(1, &tfPropertyVal, NULL) == S_OK)
		///    {
		///       BOOL fComposingValue;
		///       TfGuidAtom gaDispAttrValue;
		///
		///       // Is this the composition property?
		///       if (IsEqualGUID(tfPropertyVal.guidId, GUID_PROP_COMPOSING))
		///       {
		///          fComposingValue = (BOOL)tfPropertyVal.varValue.lVal;
		///       }
		///       // Or is this the attribute property?
		///       else if (IsEqualGUID(tfPropertyVal.guidId, GUID_PROP_ATTRIBUTE))
		///       {
		///          gaDispAttrValue = (TfGuidAtom)tfPropertyVal.varValue.lVal;
		///       }
		///
		///       // Clear the property.
		///       VariantClear(&tfPropertyVal.varValue);
		///    }
		///
		///    // Clear the tracker property.
		///    VariantClear(&varTrackerValue);
		///
		///    // Release the property enumerator.
		///    pEnumPropVal->Release();
		///
		///    // Release the range.
		///    pRangeValue->Release();
		/// }
		///
		/// // Release the selection range.
		/// sel.range->Release();]]>
		/// </code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontext-trackproperties HRESULT TrackProperties( const
		// GUID **prgProp, ULONG cProp, const GUID **prgAppProp, ULONG cAppProp, ITfReadOnlyProperty **ppProperty );
		ITfReadOnlyProperty TrackProperties([In, Optional] IntPtr prgProp, [In, Optional] uint cProp, [In, Optional] IntPtr prgAppProp, [In, Optional] uint cAppProp);

		/// <summary>Obtains a document property enumerator.</summary>
		/// <returns>Pointer to an IEnumTfProperties interface pointer that receives the enumerator object.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontext-enumproperties HRESULT EnumProperties(
		// IEnumTfProperties **ppEnum );
		IEnumTfProperties EnumProperties();

		/// <summary>Obtains the document manager that contains the context.</summary>
		/// <returns>Pointer to an ITfDocumentMgr interface pointer that receives the document manager.</returns>
		/// <remarks>
		/// If the context is not contained within a document manager, this method returns S_FALSE and ppDm is set to <c>NULL</c>. This
		/// occurs when the context is removed from the context stack through a call to ITfDocumentMgr::Pop.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontext-getdocumentmgr HRESULT GetDocumentMgr(
		// ITfDocumentMgr **ppDm );
		ITfDocumentMgr GetDocumentMgr();

		/// <summary>Creates a backup of a range.</summary>
		/// <param name="ec">Contains an edit cookie that identifies the edit session. This is the value passed to ITfEditSession::DoEditSession.</param>
		/// <param name="pRange">Pointer to the ITfRange object to be backed up.</param>
		/// <returns>Pointer to an ITfRangeBackup interface pointer that receives the backup of pRange.</returns>
		/// <remarks>This method creates a copy of the range that it can use to restore the data in ITfRangeBackup::Restore.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontext-createrangebackup HRESULT CreateRangeBackup(
		// TfEditCookie ec, ITfRange *pRange, ITfRangeBackup **ppBackup );
		ITfRangeBackup CreateRangeBackup([In] TfEditCookie ec, [In] ITfRange pRange);
	}

	/// <summary>
	/// The <c>ITfContextComposition</c> interface is implemented by the TSF manager and is used by a text service to create and
	/// manipulate compositions. An instance of this interface is provided by <c>ITfContext::QueryInterface</c> with IID_ITfContextComposition.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcontextcomposition
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfContextComposition")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("D40C8AAE-AC92-4FC7-9A11-0EE0E23AA39B")]
	public interface ITfContextComposition
	{
		/// <summary>Creates a new composition.</summary>
		/// <param name="ecWrite">Contains an edit cookie that identifies the edit context. This is obtained from ITfEditSession::DoEditSession.</param>
		/// <param name="pCompositionRange">Pointer to an ITfRange object that specifies the text that the composition initially covers.</param>
		/// <param name="pSink">
		/// Pointer to an ITfCompositionSink object that receives composition event notifications. This parameter is optional and can be
		/// <c>NULL</c>. If supplied, the object is released when the composition is terminated.
		/// </param>
		/// <returns>
		/// Pointer to an ITfComposition interface pointer that receives the new composition object. This parameter receives <c>NULL</c>
		/// if the context owner rejects the composition.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the context owner has installed an context owner composition advise sink, the
		/// ITfContextOwnerCompositionSink::OnStartComposition method is called. If the advise sink rejects the new composition, this
		/// method returns S_OK but ppComposition is set to <c>NULL</c>.
		/// </para>
		/// <para>Any text covered by pCompositionRange receives the GUID_PROP_COMPOSING property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextcomposition-startcomposition HRESULT
		// StartComposition( TfEditCookie ecWrite, ITfRange *pCompositionRange, ITfCompositionSink *pSink, ITfComposition
		// **ppComposition );
		ITfComposition StartComposition([In] TfEditCookie ecWrite, [In] ITfRange pCompositionRange, [In, Optional] ITfCompositionSink pSink);

		/// <summary>Creates an enumerator object that contains all compositions in the context.</summary>
		/// <returns>Pointer to an IEnumITfCompositionView interface pointer that receives the enumerator object.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextcomposition-enumcompositions HRESULT
		// EnumCompositions( IEnumITfCompositionView **ppEnum );
		IEnumITfCompositionView EnumCompositions();

		/// <summary>Creates an enumerator object that contains all compositions that intersect a specified range of text.</summary>
		/// <param name="ecRead">Contains an edit cookie that identifies the edit context. This is obtained from ITfEditSession::DoEditSession.</param>
		/// <param name="pTestRange">
		/// Pointer to an ITfRange object that specifies the range to search. This parameter can be <c>NULL</c>. If this parameter is
		/// <c>NULL</c>, the enumerator will contain all compositions in the edit context.
		/// </param>
		/// <returns>Pointer to an IEnumITfCompositionView interface pointer that receives the enumerator object.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextcomposition-findcomposition HRESULT
		// FindComposition( TfEditCookie ecRead, ITfRange *pTestRange, IEnumITfCompositionView **ppEnum );
		IEnumITfCompositionView FindComposition([In] TfEditCookie ecRead, [In, Optional] ITfRange pTestRange);

		/// <summary>Not currently implemented.</summary>
		/// <param name="ecWrite">Not used.</param>
		/// <param name="pComposition">Not used.</param>
		/// <param name="pSink">Not used.</param>
		/// <returns>Not used.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextcomposition-takeownership HRESULT TakeOwnership(
		// TfEditCookie ecWrite, ITfCompositionView *pComposition, ITfCompositionSink *pSink, ITfComposition **ppComposition );
		ITfComposition TakeOwnership([In] TfEditCookie ecWrite, [In] ITfCompositionView pComposition, [In] ITfCompositionSink pSink);
	}

	/// <summary>
	/// <para>
	/// The <c>ITfContextKeyEventSink</c> interface is implemented by a text service to receive keyboard event notifications that occur
	/// in an input context. This keyboard event sink differs from the ITfKeyEventSink keyboard event sink in that the keyboard events
	/// are passed to <c>ITfContextKeyEventSink</c> after having been preprocessed by the <c>ITfKeyEventSink</c> event sink. Preserved
	/// key events and filtered key events are not passed to the <c>ITfContextKeyEventSink</c> event sink.
	/// </para>
	/// <para>This event sink is installed by ITfSource::AdviseSink with IID_ITfContextKeyEventSink.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcontextkeyeventsink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfContextKeyEventSink")]
	[ComImport, Guid("0552BA5D-C835-4934-BF50-846AAA67432F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfContextKeyEventSink
	{
		/// <summary>Called when a key down event occurs.</summary>
		/// <param name="wParam">
		/// Specifies the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="lParam">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="pfEaten">
		/// Pointer to a BOOL value that, on exit, indicates if the key event is handled. If this value receives <c>TRUE</c>, the key
		/// event is handled. If this value is <c>FALSE</c>, the key event is not handled.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextkeyeventsink-onkeydown HRESULT OnKeyDown( WPARAM
		// wParam, LPARAM lParam, BOOL *pfEaten );
		[PreserveSig]
		HRESULT OnKeyDown([In] WPARAM wParam, [In] LPARAM lParam, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfEaten);

		/// <summary>Called when a key up event occurs.</summary>
		/// <param name="wParam">
		/// Specifies the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYUP.
		/// </param>
		/// <param name="lParam">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYUP.
		/// </param>
		/// <param name="pfEaten">
		/// Pointer to a BOOL value that, on exit, indicates if the key event is handled. If this value receives <c>TRUE</c>, the key
		/// event is handled. If this value receives <c>FALSE</c>, the key event is not handled.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextkeyeventsink-onkeyup HRESULT OnKeyUp( WPARAM
		// wParam, LPARAM lParam, BOOL *pfEaten );
		[PreserveSig]
		HRESULT OnKeyUp([In] WPARAM wParam, [In] LPARAM lParam, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfEaten);

		/// <summary>Called to determine if a text service will handle a key down event.</summary>
		/// <param name="wParam">
		/// Specifies the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="lParam">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYDOWN.
		/// </param>
		/// <param name="pfEaten">
		/// Pointer to a BOOL value that, on exit, indicates if the key event is handled. If this value receives <c>TRUE</c>, the key
		/// event is handled. If this value is <c>FALSE</c>, the key event is not handled.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextkeyeventsink-ontestkeydown HRESULT OnTestKeyDown(
		// WPARAM wParam, LPARAM lParam, BOOL *pfEaten );
		[PreserveSig]
		HRESULT OnTestKeyDown([In] WPARAM wParam, [In] LPARAM lParam, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfEaten);

		/// <summary>Called to determine if a text service will handle a key up event.</summary>
		/// <param name="wParam">
		/// Specifies the virtual-key code of the key. For more information about this parameter, see the wParam parameter in WM_KEYUP.
		/// </param>
		/// <param name="lParam">
		/// Specifies the repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag
		/// of the key. For more information about this parameter, see the lParam parameter in WM_KEYUP.
		/// </param>
		/// <param name="pfEaten">
		/// Pointer to a BOOL value that, on exit, indicates if the key event is handled. If this value receives <c>TRUE</c>, the key
		/// event is handled. If this value receives <c>FALSE</c>, the key event would is not handled.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextkeyeventsink-ontestkeyup HRESULT OnTestKeyUp(
		// WPARAM wParam, LPARAM lParam, BOOL *pfEaten );
		[PreserveSig]
		HRESULT OnTestKeyUp([In] WPARAM wParam, [In] LPARAM lParam, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfEaten);
	}

	/// <summary>
	/// The <c>ITfContextOwner</c> interface is implemented by an application or a text service to receive text input without having a
	/// text store. An instance of this interface is obtained when the application calls the ITfSource::AdviseSink method.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcontextowner
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfContextOwner")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AA80E80C-2021-11D2-93E0-0060B067B86E")]
	public interface ITfContextOwner
	{
		/// <summary>
		/// The <c>ITfContextOwner::GetACPFromPoint</c> method converts a point in screen coordinates to an application character position.
		/// </summary>
		/// <param name="ptScreen">Pointer to the <c>POINT</c> structure with the screen coordinates of the point.</param>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies the character position to return based upon the screen coordinates of the point relative to a character bounding
		/// box. By default, the character position returned is the character bounding box containing the screen coordinates of the
		/// point. If the point is outside a character's bounding box, the method returns <c>NULL</c> or TF_E_INVALIDPOINT.
		/// </para>
		/// <para>
		/// If the GXFPF_ROUND_NEAREST flag is specified for this parameter and the screen coordinates of the point are contained in a
		/// character bounding box, the character position returned is the bounding edge closest to the screen coordinates of the point.
		/// </para>
		/// <para>
		/// If the GXFPF_NEAREST flag is specified for this parameter and the screen coordinates of the point are not contained in a
		/// character bounding box, the closest character position is returned.
		/// </para>
		/// <para>The bit flags can be combined.</para>
		/// </param>
		/// <param name="pacp">Receives the character position that corresponds to the screen coordinates of the point</param>
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
		/// <term>TS_E_INVALIDPOINT</term>
		/// <term>The ptScreen parameter is not within the bounding box of any character.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLAYOUT</term>
		/// <term>The application has not calculated a text layout.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Use the illustration to determine the character position returned based on the flags used in the dwFlags parameter.</para>
		/// <para><c>Point 1</c></para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Default-- pacp = 0 --The screen coordinates of the point is inside the character bounding box of Character Position 0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// GXPF_ROUND_NEAREST-- pacp = 1 --The screen coordinates of the point is closest to Range Position 1 which is the starting
		/// range position of Character Position 1.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// GXPF_NEAREST-- pacp = 0 --The default behavior occurs because the point lies within the character bounding box of Character
		/// Position 0.
		/// </term>
		/// </item>
		/// </list>
		/// <para><c>Point 2</c></para>
		/// <list type="bullet">
		/// <item>
		/// <term>Default-- hr = TF_E_INVALIDPOINT --The screen coordinates of the point is outside a character bounding box.</term>
		/// </item>
		/// <item>
		/// <term>
		/// GXPF_ROUND_NEAREST-- hr = TF_E_INVALIDPOINT --The default behavior occurs because the screen coordinates of the point is
		/// outside a character bounding box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// GXPF_NEAREST-- pacp = 1 --The closest character position to the screen coordinates of the point is Character Position 1.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextowner-getacpfrompoint HRESULT GetACPFromPoint(
		// const POINT *ptScreen, DWORD dwFlags, LONG *pacp );
		[PreserveSig]
		HRESULT GetACPFromPoint(in POINT ptScreen, GXFPF dwFlags, out int pacp);

		/// <summary>
		/// The <c>ITfContextOwner::GetTextExt</c> method returns the bounding box, in screen coordinates, of the text at a specified
		/// character position. The caller must have a read-only lock on the document before calling this method.
		/// </summary>
		/// <param name="acpStart">Specifies the starting character position of the text to get in the document.</param>
		/// <param name="acpEnd">Specifies the ending character position of the text to get in the document.</param>
		/// <param name="prc">Receives the bounding box, in screen coordinates, of the text at the specified character positions.</param>
		/// <param name="pfClipped">
		/// Receives the Boolean value that specifies if the text in the bounding box has been clipped. If this parameter is
		/// <c>TRUE</c>, the bounding box contains clipped text and does not include the entire requested range of text. The bounding
		/// box is clipped because of the requested range is not visible.
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
		/// <term>TS_E_INVALIDARG</term>
		/// <term>The specified start and end character positions are equal.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_INVALIDPOS</term>
		/// <term>The range specified by the acpStart and acpEnd parameters extends past the end of the document or the top of the document.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLAYOUT</term>
		/// <term>The application has not calculated a text layout.</term>
		/// </item>
		/// <item>
		/// <term>TS_E_NOLOCK</term>
		/// <term>The caller does not have a read-only lock on the document.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the document window is minimized, or if the specified text is not currently visible, the method returns S_OK with the prc
		/// parameter set to {0,0,0,0}.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextowner-gettextext HRESULT GetTextExt( LONG
		// acpStart, LONG acpEnd, RECT *prc, BOOL *pfClipped );
		[PreserveSig]
		HRESULT GetTextExt(int acpStart, int acpEnd, out RECT prc, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfClipped);

		/// <summary>
		/// The <c>ITfContextOwner::GetScreenExt</c> method returns the bounding box, in screen coordinates, of the display surface
		/// where the text stream is rendered.
		/// </summary>
		/// <param name="prc">Receives the bounding box screen coordinates of the display surface of the document.</param>
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
		/// If the text is not currently displayed, for example if the document window is minimized, prc is set to { 0, 0, 0, 0 }.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextowner-getscreenext HRESULT GetScreenExt( RECT
		// *prc );
		[PreserveSig]
		HRESULT GetScreenExt(out RECT prc);

		/// <summary>
		/// The <c>ITfContextOwner::GetStatus</c> method obtains the status of a document. The document status is returned through the
		/// TS_STATUS structure.
		/// </summary>
		/// <param name="pdcs">Receives the TS_STATUS structure that contains the document status. Cannot be <c>NULL</c>.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextowner-getstatus HRESULT GetStatus( TF_STATUS
		// *pdcs );
		[PreserveSig]
		HRESULT GetStatus(out TS_STATUS pdcs);

		/// <summary>The <c>ITfContextOwner::GetWnd</c> method returns the handle to a window that corresponds to the current document.</summary>
		/// <param name="phwnd">
		/// Receives a pointer to the handle of the window that corresponds to the current document. This parameter can be <c>NULL</c>
		/// if the document does not have the corresponding handle to the window.
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
		/// A document might not have a corresponding window handle if the document is in memory but not displayed on the screen or if
		/// the document is a windowless control and the control does not know the window handle of the owner of the windowless
		/// controls. Callers cannot assume that the phwnd parameter will receive a non- <c>NULL</c> value even if the method is
		/// successful. Callers can also receive a <c>NULL</c> value for the phwnd parameter.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextowner-getwnd HRESULT GetWnd( HWND *phwnd );
		[PreserveSig]
		HRESULT GetWnd(out HWND phwnd);

		/// <summary>
		/// The <c>ITfContextOwner::GetAttribute</c> method returns the value of a supported attribute. If the attribute is unsupported,
		/// the pvarValue parameter is set to VT_EMPTY.
		/// </summary>
		/// <param name="rguidAttribute">Specifies the attribute GUID.</param>
		/// <param name="pvarValue">Receives the attribute value. If the attribute is unsupported, this parameter is set to VT_EMPTY.</param>
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
		/// Context owners using the default text store of the TSF manager can implement a simplified version of attributes with this
		/// method. The supported attributes are application or text service dependent. For more information about predefined attributes
		/// recognized in TSF, see the following topics.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextowner-getattribute HRESULT GetAttribute( REFGUID
		// rguidAttribute, VARIANT *pvarValue );
		[PreserveSig]
		HRESULT GetAttribute(in Guid rguidAttribute, [Out, MarshalAs(UnmanagedType.Struct)] out object pvarValue);
	}

	/// <summary>
	/// The <c>ITfContextOwnerCompositionServices</c> interface is implemented by the TSF manager and used by a context owner to
	/// manipulate compositions created by a text service.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Normally, an application creates a context and is the context owner. On occasion a text service will create a context. In this
	/// case, the text service is the context owner. For more information, see Edit Contexts.
	/// </para>
	/// <para>Obtain this interface by calling <c>ITfContext::QueryInterface</c> with IID_ITfContextOwnerCompositionServices.</para>
	/// <para>Examples</para>
	/// <para>ITfContext</para>
	/// <para>
	/// <code> HRESULT hr; ITfContextOwnerCompositionServices *pCompServices; //Get the ITfContextOwnerCompositionServices interface pointer. hr = m_pContext-&gt;QueryInterface(IID_ITfContextOwnerCompositionServices, (LPVOID*)&amp;pCompServices); if(SUCCEEDED(hr)) { //Use the interface. //Release the interface. pCompServices-&gt;Release(); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcontextownercompositionservices
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfContextOwnerCompositionServices")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("86462810-593B-4916-9764-19C08E9CE110")]
	public interface ITfContextOwnerCompositionServices : ITfContextComposition
	{
		/// <summary>Creates a new composition.</summary>
		/// <param name="ecWrite">Contains an edit cookie that identifies the edit context. This is obtained from ITfEditSession::DoEditSession.</param>
		/// <param name="pCompositionRange">Pointer to an ITfRange object that specifies the text that the composition initially covers.</param>
		/// <param name="pSink">
		/// Pointer to an ITfCompositionSink object that receives composition event notifications. This parameter is optional and can be
		/// <c>NULL</c>. If supplied, the object is released when the composition is terminated.
		/// </param>
		/// <returns>
		/// Pointer to an ITfComposition interface pointer that receives the new composition object. This parameter receives <c>NULL</c>
		/// if the context owner rejects the composition.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the context owner has installed an context owner composition advise sink, the
		/// ITfContextOwnerCompositionSink::OnStartComposition method is called. If the advise sink rejects the new composition, this
		/// method returns S_OK but ppComposition is set to <c>NULL</c>.
		/// </para>
		/// <para>Any text covered by pCompositionRange receives the GUID_PROP_COMPOSING property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextcomposition-startcomposition HRESULT
		// StartComposition( TfEditCookie ecWrite, ITfRange *pCompositionRange, ITfCompositionSink *pSink, ITfComposition
		// **ppComposition );
		new ITfComposition StartComposition([In] TfEditCookie ecWrite, [In] ITfRange pCompositionRange, [In, Optional] ITfCompositionSink pSink);

		/// <summary>Creates an enumerator object that contains all compositions in the context.</summary>
		/// <returns>Pointer to an IEnumITfCompositionView interface pointer that receives the enumerator object.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextcomposition-enumcompositions HRESULT
		// EnumCompositions( IEnumITfCompositionView **ppEnum );
		new IEnumITfCompositionView EnumCompositions();

		/// <summary>Creates an enumerator object that contains all compositions that intersect a specified range of text.</summary>
		/// <param name="ecRead">Contains an edit cookie that identifies the edit context. This is obtained from ITfEditSession::DoEditSession.</param>
		/// <param name="pTestRange">
		/// Pointer to an ITfRange object that specifies the range to search. This parameter can be <c>NULL</c>. If this parameter is
		/// <c>NULL</c>, the enumerator will contain all compositions in the edit context.
		/// </param>
		/// <returns>Pointer to an IEnumITfCompositionView interface pointer that receives the enumerator object.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextcomposition-findcomposition HRESULT
		// FindComposition( TfEditCookie ecRead, ITfRange *pTestRange, IEnumITfCompositionView **ppEnum );
		new IEnumITfCompositionView FindComposition([In] TfEditCookie ecRead, [In, Optional] ITfRange pTestRange);

		/// <summary>Not currently implemented.</summary>
		/// <param name="ecWrite">Not used.</param>
		/// <param name="pComposition">Not used.</param>
		/// <param name="pSink">Not used.</param>
		/// <returns>Not used.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextcomposition-takeownership HRESULT TakeOwnership(
		// TfEditCookie ecWrite, ITfCompositionView *pComposition, ITfCompositionSink *pSink, ITfComposition **ppComposition );
		new ITfComposition TakeOwnership([In] TfEditCookie ecWrite, [In] ITfCompositionView pComposition, [In] ITfCompositionSink pSink);

		/// <summary>Terminates a composition.</summary>
		/// <param name="pComposition">
		/// Pointer to a ITfCompositionView interface that represents the composition to terminate. If this value is <c>NULL</c>, all
		/// compositions in the context are terminated.
		/// </param>
		/// <remarks>
		/// <para>A text service uses ITfComposition::EndComposition to terminate a composition that it created.</para>
		/// <para>
		/// If the context owner implements the text store, the context owner must be able to grant a synchronous write lock before
		/// calling this method.
		/// </para>
		/// <para>This method also does the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// For each composition terminated, ITfCompositionSink::OnCompositionTerminated is called for all installed composition advise sinks.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the context owner installed a context owner composition advise sink, ITfContextOwnerCompositionSink::OnEndComposition is
		/// called for each terminated composition.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The GUID_PROP_COMPOSING property will be cleared for the text covered by each terminated composition.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextownercompositionservices-terminatecomposition
		// HRESULT TerminateComposition( ITfCompositionView *pComposition );
		void TerminateComposition([In, Optional] ITfCompositionView pComposition);
	}

	/// <summary>
	/// The <c>ITfContextOwnerCompositionSink</c> interface is implemented by an application to receive composition-related
	/// notifications. When the application calls ITfDocumentMgr::CreateContext, the TSF manager queries the object for this interface.
	/// If the object supports this interface, the advise sink is installed.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfcontextownercompositionsink
	[PInvokeData("msctf.h", MSDNShortId = "NN:msctf.ITfContextOwnerCompositionSink")]
	[ComImport, Guid("5F20AA40-B57A-4F34-96AB-3576F377CC79"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITfContextOwnerCompositionSink
	{
		/// <summary>Called when a composition is started.</summary>
		/// <param name="pComposition">Pointer to an ITfCompositionView object that represents the new composition.</param>
		/// <param name="pfOk">
		/// Pointer to a <c>BOOL</c> value that receives a value that allows or denies the new composition. Receives a nonzero value to
		/// allow the composition or zero to deny the composition.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextownercompositionsink-onstartcomposition HRESULT
		// OnStartComposition( ITfCompositionView *pComposition, BOOL *pfOk );
		[PreserveSig]
		HRESULT OnStartComposition([In] ITfCompositionView pComposition, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfOk);

		/// <summary>Called when an existing composition is changed.</summary>
		/// <param name="pComposition">Pointer to an ITfCompositionView object that represents the composition updated.</param>
		/// <param name="pRangeNew">
		/// Pointer to an ITfRange object that contains the range of text the composition will cover after the composition is updated.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// To determine what has changed within the composition, compare pRangeNew with the range returned from
		/// ITfCompositionView::GetRange. The range returned by <c>ITfCompositionView::GetRange</c> is not updated until after
		/// <c>ITfContextOwnerCompositionSink::OnUpdateComposition</c> returns.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextownercompositionsink-onupdatecomposition HRESULT
		// OnUpdateComposition( ITfCompositionView *pComposition, ITfRange *pRangeNew );
		[PreserveSig]
		HRESULT OnUpdateComposition([In] ITfCompositionView pComposition, [In] ITfRange pRangeNew);

		/// <summary>Called when a composition is terminated.</summary>
		/// <param name="pComposition">Pointer to an ITfCompositionView object that represents the composition terminated.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontextownercompositionsink-onendcomposition HRESULT
		// OnEndComposition( ITfCompositionView *pComposition );
		[PreserveSig]
		HRESULT OnEndComposition([In] ITfCompositionView pComposition);
	}

	/// <summary>Obtains a special property that can enumerate multiple properties over multiple ranges.</summary>
	/// <param name="ctx">The ITfContext instance.</param>
	/// <param name="prgProp">Contains an array of property identifiers that specify the properties to track.</param>
	/// <param name="cProp">Contains the number of property identifiers in the prgProp array.</param>
	/// <param name="prgAppProp">Contains an array of application property identifiers that specify the application properties to track.</param>
	/// <param name="cAppProp">Contains the number of application property identifiers in the prgAppProp array.</param>
	/// <returns>Pointer to an ITfReadOnlyProperty interface pointer that receives the tracking property.</returns>
	/// <remarks>
	/// <para>
	/// This method is used to quickly identify ranges with consistent property values for multiple properties. While this method could
	/// be duplicated using only the ITfContext::GetProperty method, the TSF manager can accomplish this task more quickly.
	/// </para>
	/// <para>
	/// The property obtained by this method is a VT_UNKNOWN type. This property can be used to obtain an IEnumTfPropertyValue
	/// enumerator by calling the <c>QueryInterface</c> method with IID_IEnumTfPropertyValue. This enumerator contains property values
	/// specified by prgProp and prgAppProp.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfcontext-trackproperties HRESULT TrackProperties( const GUID
	// **prgProp, ULONG cProp, const GUID **prgAppProp, ULONG cAppProp, ITfReadOnlyProperty **ppProperty );
	public static ITfReadOnlyProperty TrackProperties(this ITfContext ctx, [In, Optional] Guid[]? prgProp, [In, Optional] uint cProp, [In, Optional] Guid[]? prgAppProp, [In, Optional] uint cAppProp)
	{
		unsafe
		{
			fixed (Guid* pp = prgProp, pap = prgAppProp)
			{
				Guid*[] pprgProp = cProp == 0 ? null : new Guid*[cProp];
				for (var i = 0; i < cProp; i++)
					pprgProp[i] = &pp[i];
				Guid*[] pprgAppProp = cAppProp == 0 ? null : new Guid*[cAppProp];
				for (var i = 0; i < cAppProp; i++)
					pprgAppProp[i] = &pap[i];
				fixed (Guid** ppp = pprgProp, ppap = pprgAppProp)
					return ctx.TrackProperties((IntPtr)ppp, cProp, (IntPtr)ppap, cAppProp);
			}
		}
	}
}

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
internal class NullAllowedAttribute : Attribute { }