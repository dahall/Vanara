using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using DISPPARAMS = System.Runtime.InteropServices.ComTypes.DISPPARAMS;
using EXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;
using FUNCDESC = System.Runtime.InteropServices.ComTypes.FUNCDESC;
using IDLDESC = System.Runtime.InteropServices.ComTypes.IDLDESC;
using INVOKEKIND = System.Runtime.InteropServices.ComTypes.INVOKEKIND;
using TYPEDESC = System.Runtime.InteropServices.ComTypes.TYPEDESC;
using TYPEKIND = System.Runtime.InteropServices.ComTypes.TYPEKIND;
using VARDESC = System.Runtime.InteropServices.ComTypes.VARDESC;

namespace Vanara.PInvoke
{
	public static partial class OleAut32
	{
		/// <summary>Returns error information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nn-oaidl-icreateerrorinfo
		[PInvokeData("oaidl.h", MSDNShortId = "2e7c5ad5-9018-413e-8826-ef752ebf302c")]
		[ComImport, Guid("22F03340-547D-101B-8E65-08002B2BD119"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ICreateErrorInfo
		{
			/// <summary>Sets the globally unique identifier (GUID) of the interface that defined the error.</summary>
			/// <param name="rguid">
			/// The GUID of the interface that defined the error, or GUID_NULL if the error was defined by the operating system.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method sets the GUID of the interface that defined the error. If the error was defined by the system, set
			/// <c>ICreateErrorInfo::SetGUID</c> to GUID_NULL.
			/// </para>
			/// <para>
			/// This GUID does not necessarily represent the source of the error; however, the source is the class or application that
			/// raised the error. Using the GUID, applications can handle errors in an interface, independent of the class that implements
			/// the interface.
			/// </para>
			/// <para>Use of this function is demonstrated in the file Main.cpp of the COM Fundamentals Hello sample.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreateerrorinfo-setguid HRESULT SetGUID(REFGUID rguid);
			[PreserveSig]
			HRESULT SetGUID(in Guid rguid);

			/// <summary>Sets the language-dependent programmatic identifier (ProgID) for the class or application that raised the error.</summary>
			/// <param name="szSource">A ProgID in the form progname.objectname.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method should be used to identify the class or application that is the source of the error. The language for the
			/// returned ProgID depends on the locale identifier (LCID) that was passed to the method at the time of invocation.
			/// </para>
			/// <para>Use of this function is demonstrated in the file Main.cpp of the COM Fundamentals Hello sample.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreateerrorinfo-setsource HRESULT SetSource(LPOLESTR szSource);
			[PreserveSig]
			HRESULT SetSource([MarshalAs(UnmanagedType.LPWStr)] string szSource);

			/// <summary>Sets the textual description of the error.</summary>
			/// <param name="szDescription">A brief description of the error.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The text should be supplied in the language specified by the locale ID (LCID) that was passed to the method raising the
			/// error. For more information, see LCID Attribute in Type Libraries and the Object Description Language.
			/// </para>
			/// <para>Use of this function is demonstrated in the file Main.cpp of the COM Fundamentals Hello sample.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreateerrorinfo-setdescription HRESULT SetDescription(//
			// LPOLESTR szDescription);
			[PreserveSig]
			HRESULT SetDescription([MarshalAs(UnmanagedType.LPWStr)] string szDescription);

			/// <summary>Sets the path of the Help file that describes the error.</summary>
			/// <param name="szHelpFile">The fully qualified path of the Help file that describes the error.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// This method sets the fully qualified path of the Help file that describes the current error. Use
			/// ICreateErrorInfo::SetHelpContext to set the Help context ID for the error in the Help file.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreateerrorinfo-sethelpfile HRESULT SetHelpFile(LPOLESTR szHelpFile);
			[PreserveSig]
			HRESULT SetHelpFile([MarshalAs(UnmanagedType.LPWStr)] string szHelpFile);

			/// <summary>Sets the Help context identifier (ID) for the error.</summary>
			/// <param name="dwHelpContext">The Help context ID for the error.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>This method sets the Help context ID for the error. To establish the Help file to which it applies, use ICreateErrorInfo::SetHelpFile.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreateerrorinfo-sethelpcontext HRESULT SetHelpContext(//
			// DWORD dwHelpContext);
			[PreserveSig]
			HRESULT SetHelpContext(uint dwHelpContext);
		}

		/// <summary>Provides the tools for creating and administering the type information defined through the type description.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nn-oaidl-icreatetypeinfo
		[PInvokeData("oaidl.h", MSDNShortId = "c8bbb677-2666-4900-8fb9-788742eef656")]
		[ComImport, Guid("00020405-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ICreateTypeInfo
		{
			/// <summary>Sets the globally unique identifier (GUID) associated with the type description.</summary>
			/// <param name="guid">The globally unique ID to be associated with the type description.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// For an interface, this is an interface ID (IID); for a coclass, it is a class ID (CLSID). For information on GUIDs, see Type
			/// Libraries and the Object Description Language.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setguid HRESULT SetGuid(REFGUID guid);
			[PreserveSig]
			HRESULT SetGuid(in Guid guid);

			/// <summary>Sets type flags of the type description being created.</summary>
			/// <param name="uTypeFlags">The settings for the type flags. For details, see TYPEFLAGS.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-settypeflags HRESULT SetTypeFlags(UINT uTypeFlags);
			[PreserveSig]
			HRESULT SetTypeFlags(uint uTypeFlags);

			/// <summary>Sets the documentation string displayed by type browsers.</summary>
			/// <param name="pStrDoc">A brief description of the type description.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setdocstring HRESULT SetDocString(LPOLESTR pStrDoc);
			[PreserveSig]
			HRESULT SetDocString([MarshalAs(UnmanagedType.LPWStr)] string pStrDoc);

			/// <summary>Sets the Help context ID of the type information.</summary>
			/// <param name="dwHelpContext">A handle to the Help context.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-sethelpcontext HRESULT SetHelpContext(//
			// DWORD dwHelpContext);
			[PreserveSig]
			HRESULT SetHelpContext(uint dwHelpContext);

			/// <summary>Sets the major and minor version number of the type information.</summary>
			/// <param name="wMajorVerNum">The major version number.</param>
			/// <param name="wMinorVerNum">The minor version number.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setversion HRESULT SetVersion(WORD
			// wMajorVerNum, WORD wMinorVerNum);
			[PreserveSig]
			HRESULT SetVersion(ushort wMajorVerNum, ushort wMinorVerNum);

			/// <summary>Adds a type description to those referenced by the type description being created.</summary>
			/// <param name="pTInfo">The type description to be referenced.</param>
			/// <param name="phRefType">The handle that this type description associates with the referenced type information.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// The second parameter returns a pointer to the handle of the added type information. If <c>AddRefTypeInfo</c> has been called
			/// previously for the same type information, the index that was returned by the previous call is returned in phRefType. If the
			/// referenced type description is in the type library being created, its type information can be obtained by calling
			/// IUnknown::QueryInterface(IID_ITypeInfo, ...) on the ICreateTypeInfo interface of that type description.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-addreftypeinfo HRESULT AddRefTypeInfo(//
			// ITypeInfo *pTInfo, HREFTYPE *phRefType);
			[PreserveSig]
			HRESULT AddRefTypeInfo([In] ITypeInfo pTInfo, in uint phRefType);

			/// <summary>Adds a function description to the type description.</summary>
			/// <param name="index">The index of the new FUNCDESC in the type information.</param>
			/// <param name="pFuncDesc">
			/// A FUNCDESC structure that describes the function. The <c>bstrIDLInfo</c> field in the FUNCDESC should be null.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The index specifies the order of the functions within the type information. The first function has an index of zero. If an
			/// index is specified that exceeds one less than the number of functions in the type information, an error is returned. Calling
			/// this function does not pass ownership of the FUNCDESC structure to ICreateTypeInfo. Therefore, the caller must still
			/// de-allocate the FUNCDESC structure.
			/// </para>
			/// <para>
			/// The passed-in virtual function table (VTBL) field (oVft) of the FUNCDESC is ignored if the TYPEKIND is TKIND_MODULE or if
			/// oVft is -1 or 0. This attribute is set when ICreateTypeInfo::LayOut is called. The oVft value is used if the TYPEKIND is
			/// TKIND_DISPATCH and a dual interface or if the TYPEKIND is TKIND_INTERFACE. If the oVft is used, it must be a multiple of the
			/// sizeof(VOID *) on the machine, otherwise the function fails and E_INVALIDARG is returned as the HRESULT.
			/// </para>
			/// <para>
			/// The function <c>AddFuncDesc</c> uses the passed-in member identifier (memid) fields within each FUNCDESC for classes with
			/// TYPEKIND = TKIND_DISPATCH or TKIND_INTERFACE. If the member IDs are set to MEMBERID_NIL, <c>AddFuncDesc</c> assigns member
			/// IDs to the functions. Otherwise, the member ID fields within each FUNCDESC are ignored.
			/// </para>
			/// <para>
			/// Any HREFTYPE fields in the FUNCDESC structure must have been produced by the same instance of ITypeInfo for which
			/// <c>AddFuncDesc</c> is called.
			/// </para>
			/// <para>The get and put accessor functions for the same property must have the same dispatch identifier (DISPID).</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-addfuncdesc HRESULT AddFuncDesc(UINT index,
			// FUNCDESC *pFuncDesc);
			[PreserveSig]
			HRESULT AddFuncDesc(uint index, in FUNCDESC pFuncDesc);

			/// <summary>Specifies an inherited interface, or an interface implemented by a component object class (coclass).</summary>
			/// <param name="index">
			/// The index of the implementation class to be added. Specifies the order of the type relative to the other type.
			/// </param>
			/// <param name="hRefType">A handle to the referenced type description obtained from the AddRefType description.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// To specify an inherited interface, use index = 0. For a dispinterface with Syntax 2, call
			/// <c>ICreateTypeInfo::AddImplType</c> twice, once with index = 0 for the inherited IDispatch and once with index = 1 for the
			/// interface that is being wrapped. For a dual interface, call <c>ICreateTypeInfo::AddImplType</c> with index = -1 for the
			/// TKIND_INTERFACE type information component of the dual interface.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-addimpltype HRESULT AddImplType(UINT index,
			// HREFTYPE hRefType);
			[PreserveSig]
			HRESULT AddImplType(uint index, uint hRefType);

			/// <summary>Sets the attributes for an implemented or inherited interface of a type.</summary>
			/// <param name="index">The index of the interface for which to set type flags.</param>
			/// <param name="implTypeFlags">IMPLTYPE flags to be set.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setimpltypeflags HRESULT
			// SetImplTypeFlags(// UINT index, INT implTypeFlags);
			[PreserveSig]
			HRESULT SetImplTypeFlags(uint index, int implTypeFlags);

			/// <summary>Specifies the data alignment for an item of TYPEKIND=TKIND_RECORD.</summary>
			/// <param name="cbAlignment">
			/// Alignment method for the type. A value of 0 indicates alignment on the 64K boundary; 1 indicates no special alignment. For
			/// other values, n indicates alignment on byte n.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// The alignment is the minimum of the natural alignment (for example, byte data on byte boundaries, word data on word
			/// boundaries, and so on), and the alignment denoted by cbAlignment.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setalignment HRESULT SetAlignment(WORD cbAlignment);
			[PreserveSig]
			HRESULT SetAlignment(ushort cbAlignment);

			/// <summary>Reserved for future use.</summary>
			/// <param name="pStrSchema">The schema.</param>
			[PreserveSig]
			HRESULT SetSchema([MarshalAs(UnmanagedType.LPWStr)] string pStrSchema);

			/// <summary>Adds a variable or data member description to the type description.</summary>
			/// <param name="index">The index of the variable or data member to be added to the type description.</param>
			/// <param name="pVarDesc">A pointer to the variable or data member description to be added.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The index specifies the order of the variables. The first variable has an index of zero. <c>ICreateTypeInfo::AddVarDesc</c>
			/// returns an error if the specified index is greater than the number of variables currently in the type information. Calling
			/// this function does not pass ownership of the VARDESC structure to ICreateTypeInfo. The instance field (oInst) of the VARDESC
			/// structure is ignored. This attribute is set only when ICreateTypeInfo::LayOut is called. Also, the member ID fields within
			/// the VARDESCs are ignored unless the TYPEKIND of the class is TKIND_DISPATCH.
			/// </para>
			/// <para>
			/// Any HREFTYPE fields in the VARDESC structure must have been produced by the same instance of ITypeInfo for which
			/// <c>AddVarDesc</c> is called.
			/// </para>
			/// <para><c>AddVarDesc</c> ignores the contents of the idldesc field of the ELEMDESC.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-addvardesc HRESULT AddVarDesc(UINT index,
			// VARDESC *pVarDesc);
			[PreserveSig]
			HRESULT AddVarDesc(uint index, in VARDESC pVarDesc);

			/// <summary>Sets the name of a function and the names of its parameters to the specified names.</summary>
			/// <param name="index">The index of the function whose function name and parameter names are to be set.</param>
			/// <param name="rgszNames">
			/// An array of pointers to names. The first element is the function name. Subsequent elements are names of parameters.
			/// </param>
			/// <param name="cNames">The number of elements in the rgszNames array.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// This method must be used once for each property. The last parameter for put and putref accessor functions is unnamed.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setfuncandparamnames HRESULT
			// SetFuncAndParamNames(UINT index, LPOLESTR *rgszNames, UINT cNames);
			[PreserveSig]
			HRESULT SetFuncAndParamNames(uint index, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.LPWStr)] string[] rgszNames, uint cNames);

			/// <summary>Sets the name of a variable.</summary>
			/// <param name="index">The index of the variable.</param>
			/// <param name="szName">The name.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setvarname HRESULT SetVarName(UINT index,
			// LPOLESTR szName);
			[PreserveSig]
			HRESULT SetVarName(uint index, [MarshalAs(UnmanagedType.LPWStr)] string szName);

			/// <summary>Sets the type description for which this type description is an alias, if TYPEKIND=TKIND_ALIAS.</summary>
			/// <param name="pTDescAlias">The type description.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>To set the type for an alias, call <c>SetTypeDescAlias</c> for a type description whose TYPEKIND is TKIND_ALIAS.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-settypedescalias HRESULT
			// SetTypeDescAlias(// TYPEDESC *pTDescAlias);
			[PreserveSig]
			HRESULT SetTypeDescAlias(in TYPEDESC pTDescAlias);

			/// <summary>Associates a DLL entry point with the function that has the specified index.</summary>
			/// <param name="index">The index of the function.</param>
			/// <param name="szDllName">The name of the DLL that contains the entry point.</param>
			/// <param name="szProcName">The name of the entry point or an ordinal (if the high word is zero).</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// If the high word of szProcName is zero, then the low word must contain the ordinal of the entry point; otherwise, szProcName
			/// points to the zero-terminated name of the entry point.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-definefuncasdllentry HRESULT
			// DefineFuncAsDllEntry(UINT index, LPOLESTR szDllName, LPOLESTR szProcName);
			[PreserveSig]
			HRESULT DefineFuncAsDllEntry(uint index, [MarshalAs(UnmanagedType.LPWStr)] string szDllName, [MarshalAs(UnmanagedType.LPWStr)] string szProcName);

			/// <summary>Sets the documentation string for the function with the specified index.</summary>
			/// <param name="index">The index of the function.</param>
			/// <param name="szDocString">The documentation string.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// The documentation string is a brief description of the function intended for use by tools such as type browsers.
			/// <c>SetFuncDocString</c> only needs to be used once for each property, because all property accessor functions are identified
			/// by one name.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setfuncdocstring HRESULT
			// SetFuncDocString(// UINT index, LPOLESTR szDocString);
			[PreserveSig]
			HRESULT SetFuncDocString(uint index, [MarshalAs(UnmanagedType.LPWStr)] string szDocString);

			/// <summary>Sets the documentation string for the variable with the specified index.</summary>
			/// <param name="index">The index of the variable.</param>
			/// <param name="szDocString">The documentation string.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setvardocstring HRESULT SetVarDocString(//
			// UINT index, LPOLESTR szDocString);
			[PreserveSig]
			HRESULT SetVarDocString(uint index, [MarshalAs(UnmanagedType.LPWStr)] string szDocString);

			/// <summary>Sets the Help context ID for the function with the specified index.</summary>
			/// <param name="index">The index of the function.</param>
			/// <param name="dwHelpContext">The Help context ID for the Help topic.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <c>SetFuncHelpContext</c> only needs to be set once for each property, because all property accessor functions are
			/// identified by one name.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setfunchelpcontext HRESULT
			// SetFuncHelpContext(UINT index, DWORD dwHelpContext);
			[PreserveSig]
			HRESULT SetFuncHelpContext(uint index, uint dwHelpContext);

			/// <summary>Sets the Help context ID for the variable with the specified index.</summary>
			/// <param name="index">The index of the variable.</param>
			/// <param name="dwHelpContext">The handle to the Help context ID for the Help topic on the variable.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setvarhelpcontext HRESULT
			// SetVarHelpContext(UINT index, DWORD dwHelpContext);
			[PreserveSig]
			HRESULT SetVarHelpContext(uint index, uint dwHelpContext);

			/// <summary>Sets the marshaling opcode string associated with the type description or the function.</summary>
			/// <param name="index">
			/// The index of the member for which to set the opcode string. If index is –1, sets the opcode string for the type description.
			/// </param>
			/// <param name="bstrMops">The marshaling opcode string.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setmops HRESULT SetMops(UINT index, BSTR bstrMops);
			[PreserveSig]
			HRESULT SetMops(uint index, [MarshalAs(UnmanagedType.BStr)] string bstrMops);

			/// <summary>Reserved for future use.</summary>
			/// <param name="pIdlDesc">The IDLDESC.</param>
			[PreserveSig]
			HRESULT SetTypeIdldesc(in IDLDESC pIdlDesc);

			/// <summary>
			/// Assigns VTBL offsets for virtual functions and instance offsets for per-instance data members, and creates the two type
			/// descriptions for dual interfaces.
			/// </summary>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_UNDEFINEDTYPE</term>
			/// <term>Bound to unrecognized type.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_AMBIGUOUSNAME</term>
			/// <term>More than one item exists with this name.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_SIZETOOBIG</term>
			/// <term>The type information is too long.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_TYPEMISMATCH</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>LayOut</c> also assigns member ID numbers to the functions and variables, unless the TYPEKIND of the class is
			/// TKIND_DISPATCH. Call <c>LayOut</c> after all members of the type information are defined, and before the type library is saved.
			/// </para>
			/// <para>
			/// Use ICreateTypeLib::SaveAllChanges to save the type information after calling <c>LayOut</c>. Other members of the
			/// ICreateTypeInfo interface should not be called after calling <c>LayOut</c>.
			/// </para>
			/// <para>
			/// <c>Note</c> Different implementations of ICreateTypeLib::SaveAllChanges or other interfaces that create type information are
			/// free to assign any member ID numbers, provided that all members (including inherited members), have unique IDs. For
			/// examples, see ICreateTypeInfo2.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-layout HRESULT LayOut();
			[PreserveSig]
			HRESULT LayOut();
		}

		/// <summary>
		/// <para>
		/// Provides the tools for creating and administering the type information defined through the type description. Derives from
		/// ICreateTypeInfo, and adds methods for deleting items that have been added through ICreateTypeInfo.
		/// </para>
		/// <para>
		/// The ICreateTypeInfo::LayOut method provides a way for the creator of the type information to check for any errors. A call to
		/// QueryInterface can be made to the ICreateTypeInfo instance at any time for its ITypeInfo interface. Calling any of the methods
		/// in the ITypeInfointerface that require layout information lays out the type information automatically.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nn-oaidl-icreatetypeinfo2
		[PInvokeData("oaidl.h", MSDNShortId = "34dc6f52-6864-4edb-b22d-80eef05d4c8c")]
		[ComImport, Guid("0002040E-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ICreateTypeInfo2 : ICreateTypeInfo
		{
			/// <summary>Sets the globally unique identifier (GUID) associated with the type description.</summary>
			/// <param name="guid">The globally unique ID to be associated with the type description.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// For an interface, this is an interface ID (IID); for a coclass, it is a class ID (CLSID). For information on GUIDs, see Type
			/// Libraries and the Object Description Language.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setguid HRESULT SetGuid(REFGUID guid);
			[PreserveSig]
			new HRESULT SetGuid(in Guid guid);

			/// <summary>Sets type flags of the type description being created.</summary>
			/// <param name="uTypeFlags">The settings for the type flags. For details, see TYPEFLAGS.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-settypeflags HRESULT SetTypeFlags(UINT uTypeFlags);
			[PreserveSig]
			new HRESULT SetTypeFlags(uint uTypeFlags);

			/// <summary>Sets the documentation string displayed by type browsers.</summary>
			/// <param name="pStrDoc">A brief description of the type description.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setdocstring HRESULT SetDocString(LPOLESTR pStrDoc);
			[PreserveSig]
			new HRESULT SetDocString([MarshalAs(UnmanagedType.LPWStr)] string pStrDoc);

			/// <summary>Sets the Help context ID of the type information.</summary>
			/// <param name="dwHelpContext">A handle to the Help context.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-sethelpcontext HRESULT SetHelpContext(//
			// DWORD dwHelpContext);
			[PreserveSig]
			new HRESULT SetHelpContext(uint dwHelpContext);

			/// <summary>Sets the major and minor version number of the type information.</summary>
			/// <param name="wMajorVerNum">The major version number.</param>
			/// <param name="wMinorVerNum">The minor version number.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setversion HRESULT SetVersion(WORD
			// wMajorVerNum, WORD wMinorVerNum);
			[PreserveSig]
			new HRESULT SetVersion(ushort wMajorVerNum, ushort wMinorVerNum);

			/// <summary>Adds a type description to those referenced by the type description being created.</summary>
			/// <param name="pTInfo">The type description to be referenced.</param>
			/// <param name="phRefType">The handle that this type description associates with the referenced type information.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// The second parameter returns a pointer to the handle of the added type information. If <c>AddRefTypeInfo</c> has been called
			/// previously for the same type information, the index that was returned by the previous call is returned in phRefType. If the
			/// referenced type description is in the type library being created, its type information can be obtained by calling
			/// IUnknown::QueryInterface(IID_ITypeInfo, ...) on the ICreateTypeInfo interface of that type description.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-addreftypeinfo HRESULT AddRefTypeInfo(//
			// ITypeInfo *pTInfo, HREFTYPE *phRefType);
			[PreserveSig]
			new HRESULT AddRefTypeInfo([In] ITypeInfo pTInfo, in uint phRefType);

			/// <summary>Adds a function description to the type description.</summary>
			/// <param name="index">The index of the new FUNCDESC in the type information.</param>
			/// <param name="pFuncDesc">
			/// A FUNCDESC structure that describes the function. The <c>bstrIDLInfo</c> field in the FUNCDESC should be null.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The index specifies the order of the functions within the type information. The first function has an index of zero. If an
			/// index is specified that exceeds one less than the number of functions in the type information, an error is returned. Calling
			/// this function does not pass ownership of the FUNCDESC structure to ICreateTypeInfo. Therefore, the caller must still
			/// de-allocate the FUNCDESC structure.
			/// </para>
			/// <para>
			/// The passed-in virtual function table (VTBL) field (oVft) of the FUNCDESC is ignored if the TYPEKIND is TKIND_MODULE or if
			/// oVft is -1 or 0. This attribute is set when ICreateTypeInfo::LayOut is called. The oVft value is used if the TYPEKIND is
			/// TKIND_DISPATCH and a dual interface or if the TYPEKIND is TKIND_INTERFACE. If the oVft is used, it must be a multiple of the
			/// sizeof(VOID *) on the machine, otherwise the function fails and E_INVALIDARG is returned as the HRESULT.
			/// </para>
			/// <para>
			/// The function <c>AddFuncDesc</c> uses the passed-in member identifier (memid) fields within each FUNCDESC for classes with
			/// TYPEKIND = TKIND_DISPATCH or TKIND_INTERFACE. If the member IDs are set to MEMBERID_NIL, <c>AddFuncDesc</c> assigns member
			/// IDs to the functions. Otherwise, the member ID fields within each FUNCDESC are ignored.
			/// </para>
			/// <para>
			/// Any HREFTYPE fields in the FUNCDESC structure must have been produced by the same instance of ITypeInfo for which
			/// <c>AddFuncDesc</c> is called.
			/// </para>
			/// <para>The get and put accessor functions for the same property must have the same dispatch identifier (DISPID).</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-addfuncdesc HRESULT AddFuncDesc(UINT index,
			// FUNCDESC *pFuncDesc);
			[PreserveSig]
			new HRESULT AddFuncDesc(uint index, in FUNCDESC pFuncDesc);

			/// <summary>Specifies an inherited interface, or an interface implemented by a component object class (coclass).</summary>
			/// <param name="index">
			/// The index of the implementation class to be added. Specifies the order of the type relative to the other type.
			/// </param>
			/// <param name="hRefType">A handle to the referenced type description obtained from the AddRefType description.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// To specify an inherited interface, use index = 0. For a dispinterface with Syntax 2, call
			/// <c>ICreateTypeInfo::AddImplType</c> twice, once with index = 0 for the inherited IDispatch and once with index = 1 for the
			/// interface that is being wrapped. For a dual interface, call <c>ICreateTypeInfo::AddImplType</c> with index = -1 for the
			/// TKIND_INTERFACE type information component of the dual interface.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-addimpltype HRESULT AddImplType(UINT index,
			// HREFTYPE hRefType);
			[PreserveSig]
			new HRESULT AddImplType(uint index, uint hRefType);

			/// <summary>Sets the attributes for an implemented or inherited interface of a type.</summary>
			/// <param name="index">The index of the interface for which to set type flags.</param>
			/// <param name="implTypeFlags">IMPLTYPE flags to be set.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setimpltypeflags HRESULT
			// SetImplTypeFlags(// UINT index, INT implTypeFlags);
			[PreserveSig]
			new HRESULT SetImplTypeFlags(uint index, int implTypeFlags);

			/// <summary>Specifies the data alignment for an item of TYPEKIND=TKIND_RECORD.</summary>
			/// <param name="cbAlignment">
			/// Alignment method for the type. A value of 0 indicates alignment on the 64K boundary; 1 indicates no special alignment. For
			/// other values, n indicates alignment on byte n.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// The alignment is the minimum of the natural alignment (for example, byte data on byte boundaries, word data on word
			/// boundaries, and so on), and the alignment denoted by cbAlignment.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setalignment HRESULT SetAlignment(WORD cbAlignment);
			[PreserveSig]
			new HRESULT SetAlignment(ushort cbAlignment);

			/// <summary>Reserved for future use.</summary>
			/// <param name="pStrSchema">The schema.</param>
			[PreserveSig]
			new HRESULT SetSchema([MarshalAs(UnmanagedType.LPWStr)] string pStrSchema);

			/// <summary>Adds a variable or data member description to the type description.</summary>
			/// <param name="index">The index of the variable or data member to be added to the type description.</param>
			/// <param name="pVarDesc">A pointer to the variable or data member description to be added.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The index specifies the order of the variables. The first variable has an index of zero. <c>ICreateTypeInfo::AddVarDesc</c>
			/// returns an error if the specified index is greater than the number of variables currently in the type information. Calling
			/// this function does not pass ownership of the VARDESC structure to ICreateTypeInfo. The instance field (oInst) of the VARDESC
			/// structure is ignored. This attribute is set only when ICreateTypeInfo::LayOut is called. Also, the member ID fields within
			/// the VARDESCs are ignored unless the TYPEKIND of the class is TKIND_DISPATCH.
			/// </para>
			/// <para>
			/// Any HREFTYPE fields in the VARDESC structure must have been produced by the same instance of ITypeInfo for which
			/// <c>AddVarDesc</c> is called.
			/// </para>
			/// <para><c>AddVarDesc</c> ignores the contents of the idldesc field of the ELEMDESC.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-addvardesc HRESULT AddVarDesc(UINT index,
			// VARDESC *pVarDesc);
			[PreserveSig]
			new HRESULT AddVarDesc(uint index, in VARDESC pVarDesc);

			/// <summary>Sets the name of a function and the names of its parameters to the specified names.</summary>
			/// <param name="index">The index of the function whose function name and parameter names are to be set.</param>
			/// <param name="rgszNames">
			/// An array of pointers to names. The first element is the function name. Subsequent elements are names of parameters.
			/// </param>
			/// <param name="cNames">The number of elements in the rgszNames array.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// This method must be used once for each property. The last parameter for put and putref accessor functions is unnamed.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setfuncandparamnames HRESULT
			// SetFuncAndParamNames(UINT index, LPOLESTR *rgszNames, UINT cNames);
			[PreserveSig]
			new HRESULT SetFuncAndParamNames(uint index, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.LPWStr)] string[] rgszNames, uint cNames);

			/// <summary>Sets the name of a variable.</summary>
			/// <param name="index">The index of the variable.</param>
			/// <param name="szName">The name.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setvarname HRESULT SetVarName(UINT index,
			// LPOLESTR szName);
			[PreserveSig]
			new HRESULT SetVarName(uint index, [MarshalAs(UnmanagedType.LPWStr)] string szName);

			/// <summary>Sets the type description for which this type description is an alias, if TYPEKIND=TKIND_ALIAS.</summary>
			/// <param name="pTDescAlias">The type description.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>To set the type for an alias, call <c>SetTypeDescAlias</c> for a type description whose TYPEKIND is TKIND_ALIAS.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-settypedescalias HRESULT
			// SetTypeDescAlias(// TYPEDESC *pTDescAlias);
			[PreserveSig]
			new HRESULT SetTypeDescAlias(in TYPEDESC pTDescAlias);

			/// <summary>Associates a DLL entry point with the function that has the specified index.</summary>
			/// <param name="index">The index of the function.</param>
			/// <param name="szDllName">The name of the DLL that contains the entry point.</param>
			/// <param name="szProcName">The name of the entry point or an ordinal (if the high word is zero).</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// If the high word of szProcName is zero, then the low word must contain the ordinal of the entry point; otherwise, szProcName
			/// points to the zero-terminated name of the entry point.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-definefuncasdllentry HRESULT
			// DefineFuncAsDllEntry(UINT index, LPOLESTR szDllName, LPOLESTR szProcName);
			[PreserveSig]
			new HRESULT DefineFuncAsDllEntry(uint index, [MarshalAs(UnmanagedType.LPWStr)] string szDllName, [MarshalAs(UnmanagedType.LPWStr)] string szProcName);

			/// <summary>Sets the documentation string for the function with the specified index.</summary>
			/// <param name="index">The index of the function.</param>
			/// <param name="szDocString">The documentation string.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// The documentation string is a brief description of the function intended for use by tools such as type browsers.
			/// <c>SetFuncDocString</c> only needs to be used once for each property, because all property accessor functions are identified
			/// by one name.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setfuncdocstring HRESULT
			// SetFuncDocString(// UINT index, LPOLESTR szDocString);
			[PreserveSig]
			new HRESULT SetFuncDocString(uint index, [MarshalAs(UnmanagedType.LPWStr)] string szDocString);

			/// <summary>Sets the documentation string for the variable with the specified index.</summary>
			/// <param name="index">The index of the variable.</param>
			/// <param name="szDocString">The documentation string.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setvardocstring HRESULT SetVarDocString(//
			// UINT index, LPOLESTR szDocString);
			[PreserveSig]
			new HRESULT SetVarDocString(uint index, [MarshalAs(UnmanagedType.LPWStr)] string szDocString);

			/// <summary>Sets the Help context ID for the function with the specified index.</summary>
			/// <param name="index">The index of the function.</param>
			/// <param name="dwHelpContext">The Help context ID for the Help topic.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <c>SetFuncHelpContext</c> only needs to be set once for each property, because all property accessor functions are
			/// identified by one name.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setfunchelpcontext HRESULT
			// SetFuncHelpContext(UINT index, DWORD dwHelpContext);
			[PreserveSig]
			new HRESULT SetFuncHelpContext(uint index, uint dwHelpContext);

			/// <summary>Sets the Help context ID for the variable with the specified index.</summary>
			/// <param name="index">The index of the variable.</param>
			/// <param name="dwHelpContext">The handle to the Help context ID for the Help topic on the variable.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setvarhelpcontext HRESULT
			// SetVarHelpContext(UINT index, DWORD dwHelpContext);
			[PreserveSig]
			new HRESULT SetVarHelpContext(uint index, uint dwHelpContext);

			/// <summary>Sets the marshaling opcode string associated with the type description or the function.</summary>
			/// <param name="index">
			/// The index of the member for which to set the opcode string. If index is –1, sets the opcode string for the type description.
			/// </param>
			/// <param name="bstrMops">The marshaling opcode string.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-setmops HRESULT SetMops(UINT index, BSTR bstrMops);
			[PreserveSig]
			new HRESULT SetMops(uint index, [MarshalAs(UnmanagedType.BStr)] string bstrMops);

			/// <summary>Reserved for future use.</summary>
			/// <param name="pIdlDesc">The IDLDESC.</param>
			[PreserveSig]
			new HRESULT SetTypeIdldesc(in IDLDESC pIdlDesc);

			/// <summary>
			/// Assigns VTBL offsets for virtual functions and instance offsets for per-instance data members, and creates the two type
			/// descriptions for dual interfaces.
			/// </summary>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_ACCESSDENIED</term>
			/// <term>Cannot write to the destination.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_UNDEFINEDTYPE</term>
			/// <term>Bound to unrecognized type.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_ELEMENTNOTFOUND</term>
			/// <term>The element cannot be found.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_AMBIGUOUSNAME</term>
			/// <term>More than one item exists with this name.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_SIZETOOBIG</term>
			/// <term>The type information is too long.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_TYPEMISMATCH</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>LayOut</c> also assigns member ID numbers to the functions and variables, unless the TYPEKIND of the class is
			/// TKIND_DISPATCH. Call <c>LayOut</c> after all members of the type information are defined, and before the type library is saved.
			/// </para>
			/// <para>
			/// Use ICreateTypeLib::SaveAllChanges to save the type information after calling <c>LayOut</c>. Other members of the
			/// ICreateTypeInfo interface should not be called after calling <c>LayOut</c>.
			/// </para>
			/// <para>
			/// <c>Note</c> Different implementations of ICreateTypeLib::SaveAllChanges or other interfaces that create type information are
			/// free to assign any member ID numbers, provided that all members (including inherited members), have unique IDs. For
			/// examples, see ICreateTypeInfo2.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo-layout HRESULT LayOut();
			[PreserveSig]
			new HRESULT LayOut();

			/// <summary>Deletes a function description specified by the index number.</summary>
			/// <param name="index">
			/// The index of the function whose description is to be deleted. The index should be in the range of 0 to 1 less than the
			/// number of functions in this type.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo2-deletefuncdesc HRESULT DeleteFuncDesc(//
			// UINT index);
			[PreserveSig]
			HRESULT DeleteFuncDesc(uint index);

			/// <summary>Deletes the specified function description (FUNCDESC).</summary>
			/// <param name="memid">The member identifier of the FUNCDESC to delete.</param>
			/// <param name="invKind">The type of the invocation.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo2-deletefuncdescbymemid HRESULT
			// DeleteFuncDescByMemId(MEMBERID memid, INVOKEKIND invKind);
			[PreserveSig]
			HRESULT DeleteFuncDescByMemId(int memid, INVOKEKIND invKind);

			/// <summary>Deletes the specified VARDESC structure.</summary>
			/// <param name="index">The index number of the VARDESC structure.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_IOERROR</term>
			/// <term>The function cannot read from the file.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVDATAREAD</term>
			/// <term>The function cannot read from the file.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_UNSUPFORMAT</term>
			/// <term>The type library has an old format.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The type library cannot be opened.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo2-deletevardesc HRESULT DeleteVarDesc(UINT index);
			[PreserveSig]
			HRESULT DeleteVarDesc(uint index);

			/// <summary>Deletes the specified VARDESC structure.</summary>
			/// <param name="memid">The member identifier of the VARDESC to be deleted.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_IOERROR</term>
			/// <term>The function cannot read from the file.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVDATAREAD</term>
			/// <term>The function cannot read from the file.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_UNSUPFORMAT</term>
			/// <term>The type library has an old format.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The type library cannot be opened.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo2-deletevardescbymemid HRESULT
			// DeleteVarDescByMemId(MEMBERID memid);
			[PreserveSig]
			HRESULT DeleteVarDescByMemId(int memid);

			/// <summary>Deletes the IMPLTYPE flags for the indexed interface.</summary>
			/// <param name="index">The index of the interface for which to delete the type flags.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo2-deleteimpltype HRESULT DeleteImplType(//
			// UINT index);
			[PreserveSig]
			HRESULT DeleteImplType(uint index);

			/// <summary>Sets a value for custom data.</summary>
			/// <param name="guid">The unique identifier that can be used to identify the data.</param>
			/// <param name="pVarVal">The data to store (any variant except an object).</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo2-setcustdata HRESULT SetCustData(REFGUID
			// guid, VARIANT *pVarVal);
			[PreserveSig]
			HRESULT SetCustData(in Guid guid, [In, MarshalAs(UnmanagedType.Struct)] object pVarVal);

			/// <summary>Sets a value for custom data for the specified function.</summary>
			/// <param name="index">The index of the function for which to set the custom data.</param>
			/// <param name="guid">The unique identifier used to identify the data.</param>
			/// <param name="pVarVal">The data to store (any variant except an object).</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo2-setfunccustdata HRESULT SetFuncCustData(//
			// UINT index, REFGUID guid, VARIANT *pVarVal);
			[PreserveSig]
			HRESULT SetFuncCustData(uint index, in Guid guid, [In, MarshalAs(UnmanagedType.Struct)] object pVarVal);

			/// <summary>Sets a value for the custom data for the specified parameter.</summary>
			/// <param name="indexFunc">The index of the function for which to set the custom data.</param>
			/// <param name="indexParam">The index of the parameter of the function for which to set the custom data.</param>
			/// <param name="guid">The globally unique identifier (GUID) used to identify the data.</param>
			/// <param name="pVarVal">The data to store (any variant except an object).</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo2-setparamcustdata HRESULT
			// SetParamCustData(// UINT indexFunc, UINT indexParam, REFGUID guid, VARIANT *pVarVal);
			[PreserveSig]
			HRESULT SetParamCustData(uint indexFunc, uint indexParam, in Guid guid, [In, MarshalAs(UnmanagedType.Struct)] object pVarVal);

			/// <summary>Sets a value for custom data for the specified variable.</summary>
			/// <param name="index">The index of the variable for which to set the custom data.</param>
			/// <param name="guid">The globally unique ID (GUID) used to identify the data.</param>
			/// <param name="pVarVal">The data to store (any variant except an object).</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo2-setvarcustdata HRESULT SetVarCustData(//
			// UINT index, REFGUID guid, VARIANT *pVarVal);
			[PreserveSig]
			HRESULT SetVarCustData(uint index, in Guid guid, [In, MarshalAs(UnmanagedType.Struct)] object pVarVal);

			/// <summary>Sets a value for custom data for the specified implementation type.</summary>
			/// <param name="index">The index of the variable for which to set the custom data.</param>
			/// <param name="guid">The unique identifier used to identify the data.</param>
			/// <param name="pVarVal">The data to store (any variant except an object).</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo2-setimpltypecustdata HRESULT
			// SetImplTypeCustData(UINT index, REFGUID guid, VARIANT *pVarVal);
			[PreserveSig]
			HRESULT SetImplTypeCustData(uint index, in Guid guid, [In, MarshalAs(UnmanagedType.Struct)] object pVarVal);

			/// <summary>Sets the context number for the specified Help string.</summary>
			/// <param name="dwHelpStringContext">The Help string context number.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo2-sethelpstringcontext HRESULT
			// SetHelpStringContext(ULONG dwHelpStringContext);
			[PreserveSig]
			HRESULT SetHelpStringContext(uint dwHelpStringContext);

			/// <summary>Sets a Help context value for a specified function.</summary>
			/// <param name="index">The index of the function for which to set the help string context.</param>
			/// <param name="dwHelpStringContext">The Help string context for a localized string.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo2-setfunchelpstringcontext HRESULT
			// SetFuncHelpStringContext(UINT index, ULONG dwHelpStringContext);
			[PreserveSig]
			HRESULT SetFuncHelpStringContext(uint index, uint dwHelpStringContext);

			/// <summary>Sets a Help context value for a specified variable.</summary>
			/// <param name="index">The index of the variable.</param>
			/// <param name="dwHelpStringContext">The Help string context for a localized string.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo2-setvarhelpstringcontext HRESULT
			// SetVarHelpStringContext(UINT index, ULONG dwHelpStringContext);
			[PreserveSig]
			HRESULT SetVarHelpStringContext(uint index, uint dwHelpStringContext);

			/// <summary>Reserved for future use.</summary>
			[PreserveSig]
			HRESULT Invalidate();

			/// <summary>Sets the name of the typeinfo.</summary>
			/// <param name="szName">The name to be assigned.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypeinfo2-setname HRESULT SetName(LPOLESTR szName);
			[PreserveSig]
			HRESULT SetName([In, MarshalAs(UnmanagedType.LPWStr)]  string szName);
		}

		/// <summary>
		/// Provides the methods for creating and managing the component or file that contains type information. Type libraries are created
		/// from type descriptions using the MIDL compiler. These type libraries are accessed through the ITypeLib interface.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nn-oaidl-icreatetypelib
		[PInvokeData("oaidl.h", MSDNShortId = "d245cd25-ce31-42da-a42d-dc412d5b98e7")]
		[ComImport, Guid("00020406-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ICreateTypeLib
		{
			/// <summary>Creates a new type description instance within the type library.</summary>
			/// <param name="szName">The name of the new type.</param>
			/// <param name="tkind">TYPEKIND of the type description to be created.</param>
			/// <param name="ppCTInfo">The type description.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_NAMECONFLICT</term>
			/// <term>The provided name is not unique.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// Use ICreateTypeLib to create a new type description instance within the library. An error is returned if the specified name
			/// already appears in the library. Valid tkind values are described in TYPEKIND. To get the type information of the type
			/// description that is being created, call on the returned <c>ICreateTypeLib</c>. This type information can be used by other
			/// type descriptions that reference it by using ICreateTypeInfo::AddRefTypeInfo.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-createtypeinfo HRESULT
			// CreateTypeInfo(LPOLESTR szName, TYPEKIND tkind, ICreateTypeInfo **ppCTInfo);
			[PreserveSig]
			HRESULT CreateTypeInfo([In, MarshalAs(UnmanagedType.LPWStr)] string szName, TYPEKIND tkind, out ICreateTypeInfo ppCTInfo);

			/// <summary>Sets the name of the type library.</summary>
			/// <param name="szName">The name to be assigned to the library.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-setname HRESULT SetName(LPOLESTR szName);
			[PreserveSig]
			HRESULT SetName([In, MarshalAs(UnmanagedType.LPWStr)] string szName);

			/// <summary>Sets the major and minor version numbers of the type library.</summary>
			/// <param name="wMajorVerNum">The major version number for the library.</param>
			/// <param name="wMinorVerNum">The minor version number for the library.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-setversion HRESULT SetVersion(WORD
			// wMajorVerNum, WORD wMinorVerNum);
			[PreserveSig]
			HRESULT SetVersion(ushort wMajorVerNum, ushort wMinorVerNum);

			/// <summary>
			/// Sets the universal unique identifier (UUID) associated with the type library (Also known as the globally unique identifier (GUID)).
			/// </summary>
			/// <param name="guid">The globally unique identifier to be assigned to the library.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-setguid HRESULT SetGuid(REFGUID guid);
			[PreserveSig]
			HRESULT SetGuid(in Guid guid);

			/// <summary>Sets the documentation string associated with the library.</summary>
			/// <param name="szDoc">A brief description of the type library.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// The documentation string is a brief description of the library intended for use by type information browsing tools.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-setdocstring HRESULT SetDocString(LPOLESTR szDoc);
			[PreserveSig]
			HRESULT SetDocString([MarshalAs(UnmanagedType.LPWStr)] string szDoc);

			/// <summary>Sets the name of the Help file.</summary>
			/// <param name="szHelpFileName">The name of the Help file for the library.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>Each type library can reference a single Help file.</para>
			/// <para>
			/// The GetDocumentation method of the created ITypeLib returns a fully qualified path for the Help file, which is formed by
			/// appending the name passed into szHelpFileName to the registered Help directory for the type library. The Help directory is
			/// registered under:
			/// </para>
			/// <para>\TYPELIB&amp;lt;guid of library&gt;&amp;lt;Major.Minor version &gt;\HELPDIR</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-sethelpfilename HRESULT
			// SetHelpFileName(LPOLESTR szHelpFileName);
			[PreserveSig]
			HRESULT SetHelpFileName([MarshalAs(UnmanagedType.LPWStr)] string szHelpFileName);

			/// <summary>Sets the Help context ID for retrieving general Help information for the type library.</summary>
			/// <param name="dwHelpContext">The Help context ID.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// Calling <c>SetHelpContext</c> with a Help context of zero is equivalent to not calling it at all, because zero indicates a
			/// null Help context.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-sethelpcontext HRESULT SetHelpContext(DWORD dwHelpContext);
			[PreserveSig]
			HRESULT SetHelpContext(uint dwHelpContext);

			/// <summary>Sets the binary Microsoft national language ID associated with the library.</summary>
			/// <param name="lcid">The locale ID for the type library.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// For more information on national language IDs, see Supporting Multiple National Languages and the National Language Support
			/// (NLS) API.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-setlcid HRESULT SetLcid(LCID lcid);
			[PreserveSig]
			HRESULT SetLcid(LCID lcid);

			/// <summary>Sets library flags.</summary>
			/// <param name="uLibFlags">The flags to set.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>Valid uLibFlags values are listed in LIBFLAGS.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-setlibflags HRESULT SetLibFlags(UINT uLibFlags);
			[PreserveSig]
			HRESULT SetLibFlags(uint uLibFlags);

			/// <summary>Saves the ICreateTypeLib instance following the layout of type information.</summary>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_IOERROR</term>
			/// <term>The function cannot write to the file.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>You should not call any other ICreateTypeLib methods after calling <c>SaveAllChanges</c>.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-saveallchanges HRESULT SaveAllChanges();
			[PreserveSig]
			HRESULT SaveAllChanges();
		}

		/// <summary>
		/// Provides the methods for creating and managing the component or file that contains type information. Derives from
		/// ICreateTypeLib. The ICreateTypeInfo instance returned from <c>ICreateTypeLib</c> can be accessed through a <c>QueryInterface</c>
		/// call to ICreateTypeInfo2.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nn-oaidl-icreatetypelib2
		[PInvokeData("oaidl.h", MSDNShortId = "97378353-8c2d-493a-8ee9-42d33ab47d18")]
		[ComImport, Guid("0002040F-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ICreateTypeLib2 : ICreateTypeLib
		{
			/// <summary>Creates a new type description instance within the type library.</summary>
			/// <param name="szName">The name of the new type.</param>
			/// <param name="tkind">TYPEKIND of the type description to be created.</param>
			/// <param name="ppCTInfo">The type description.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_NAMECONFLICT</term>
			/// <term>The provided name is not unique.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_WRONGTYPEKIND</term>
			/// <term>Type mismatch.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// Use ICreateTypeLib to create a new type description instance within the library. An error is returned if the specified name
			/// already appears in the library. Valid tkind values are described in TYPEKIND. To get the type information of the type
			/// description that is being created, call on the returned <c>ICreateTypeLib</c>. This type information can be used by other
			/// type descriptions that reference it by using ICreateTypeInfo::AddRefTypeInfo.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-createtypeinfo HRESULT
			// CreateTypeInfo(LPOLESTR szName, TYPEKIND tkind, ICreateTypeInfo **ppCTInfo);
			[PreserveSig]
			new HRESULT CreateTypeInfo([In, MarshalAs(UnmanagedType.LPWStr)] string szName, TYPEKIND tkind, out ICreateTypeInfo ppCTInfo);

			/// <summary>Sets the name of the type library.</summary>
			/// <param name="szName">The name to be assigned to the library.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-setname HRESULT SetName(LPOLESTR szName);
			[PreserveSig]
			new HRESULT SetName([In, MarshalAs(UnmanagedType.LPWStr)] string szName);

			/// <summary>Sets the major and minor version numbers of the type library.</summary>
			/// <param name="wMajorVerNum">The major version number for the library.</param>
			/// <param name="wMinorVerNum">The minor version number for the library.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-setversion HRESULT SetVersion(WORD
			// wMajorVerNum, WORD wMinorVerNum);
			[PreserveSig]
			new HRESULT SetVersion(ushort wMajorVerNum, ushort wMinorVerNum);

			/// <summary>
			/// Sets the universal unique identifier (UUID) associated with the type library (Also known as the globally unique identifier (GUID)).
			/// </summary>
			/// <param name="guid">The globally unique identifier to be assigned to the library.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-setguid HRESULT SetGuid(REFGUID guid);
			[PreserveSig]
			new HRESULT SetGuid(in Guid guid);

			/// <summary>Sets the documentation string associated with the library.</summary>
			/// <param name="szDoc">A brief description of the type library.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// The documentation string is a brief description of the library intended for use by type information browsing tools.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-setdocstring HRESULT SetDocString(LPOLESTR szDoc);
			[PreserveSig]
			new HRESULT SetDocString([MarshalAs(UnmanagedType.LPWStr)] string szDoc);

			/// <summary>Sets the name of the Help file.</summary>
			/// <param name="szHelpFileName">The name of the Help file for the library.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>Each type library can reference a single Help file.</para>
			/// <para>
			/// The GetDocumentation method of the created ITypeLib returns a fully qualified path for the Help file, which is formed by
			/// appending the name passed into szHelpFileName to the registered Help directory for the type library. The Help directory is
			/// registered under:
			/// </para>
			/// <para>\TYPELIB&amp;lt;guid of library&gt;&amp;lt;Major.Minor version &gt;\HELPDIR</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-sethelpfilename HRESULT
			// SetHelpFileName(LPOLESTR szHelpFileName);
			[PreserveSig]
			new HRESULT SetHelpFileName([MarshalAs(UnmanagedType.LPWStr)] string szHelpFileName);

			/// <summary>Sets the Help context ID for retrieving general Help information for the type library.</summary>
			/// <param name="dwHelpContext">The Help context ID.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// Calling <c>SetHelpContext</c> with a Help context of zero is equivalent to not calling it at all, because zero indicates a
			/// null Help context.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-sethelpcontext HRESULT SetHelpContext(DWORD dwHelpContext);
			[PreserveSig]
			new HRESULT SetHelpContext(uint dwHelpContext);

			/// <summary>Sets the binary Microsoft national language ID associated with the library.</summary>
			/// <param name="lcid">The locale ID for the type library.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// For more information on national language IDs, see Supporting Multiple National Languages and the National Language Support
			/// (NLS) API.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-setlcid HRESULT SetLcid(LCID lcid);
			[PreserveSig]
			new HRESULT SetLcid(LCID lcid);

			/// <summary>Sets library flags.</summary>
			/// <param name="uLibFlags">The flags to set.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>Valid uLibFlags values are listed in LIBFLAGS.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-setlibflags HRESULT SetLibFlags(UINT uLibFlags);
			[PreserveSig]
			new HRESULT SetLibFlags(uint uLibFlags);

			/// <summary>Saves the ICreateTypeLib instance following the layout of type information.</summary>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>STG_E_INSUFFICIENTMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_IOERROR</term>
			/// <term>The function cannot write to the file.</term>
			/// </item>
			/// <item>
			/// <term>TYPE_E_INVALIDSTATE</term>
			/// <term>The state of the type library is not valid for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>You should not call any other ICreateTypeLib methods after calling <c>SaveAllChanges</c>.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib-saveallchanges HRESULT SaveAllChanges();
			[PreserveSig]
			new HRESULT SaveAllChanges();

			/// <summary>Deletes a specified type information from the type library.</summary>
			/// <param name="szName">The name of the type information to remove.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib2-deletetypeinfo HRESULT DeleteTypeInfo(
			// LPOLESTR szName );
			[PreserveSig]
			HRESULT DeleteTypeInfo([MarshalAs(UnmanagedType.LPWStr)] string szName);

			/// <summary>Sets a value to custom data.</summary>
			/// <param name="guid">The unique identifier for the data.</param>
			/// <param name="pVarVal">The data to store (any variant except an object).</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib2-setcustdata HRESULT SetCustData( REFGUID
			// guid, VARIANT *pVarVal );
			[PreserveSig]
			HRESULT SetCustData(in Guid guid, [In, MarshalAs(UnmanagedType.Struct)] object pVarVal);

			/// <summary>Sets the Help string context number.</summary>
			/// <param name="dwHelpStringContext">The Help string context number.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib2-sethelpstringcontext HRESULT
			// SetHelpStringContext( ULONG dwHelpStringContext );
			[PreserveSig]
			HRESULT SetHelpStringContext(uint dwHelpStringContext);

			/// <summary>Sets the DLL name to be used for Help string lookup (for localization purposes).</summary>
			/// <param name="szFileName">The DLL file name.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-icreatetypelib2-sethelpstringdll HRESULT SetHelpStringDll(
			// LPOLESTR szFileName );
			[PreserveSig]
			HRESULT SetHelpStringDll([MarshalAs(UnmanagedType.LPWStr)] string szFileName);
		}

		/// <summary>
		/// Exposes objects, methods and properties to programming tools and other applications that support Automation. COM components
		/// implement the <c>IDispatch</c> interface to enable access by Automation clients, such as Visual Basic.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nn-oaidl-idispatch
		[PInvokeData("oaidl.h", MSDNShortId = "ebbff4bc-36b2-4861-9efa-ffa45e013eb5")]
		[System.Security.SuppressUnmanagedCodeSecurity, ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00020400-0000-0000-C000-000000000046")]
		public interface IDispatch
		{
			/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
			/// <param name="pctinfo">
			/// The number of type information interfaces provided by the object. If the object provides type information, this number is 1;
			/// otherwise the number is 0.
			/// </param>
			/// <remarks>
			/// The method may return zero, which indicates that the object does not provide any type information. In this case, the object
			/// may still be programmable through <c>IDispatch</c> or a VTBL, but does not provide run-time type information for browsers,
			/// compilers, or other programming tools that access type information. This can be useful for hiding an object from browsers.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-idispatch-gettypeinfocount HRESULT GetTypeInfoCount(UINT
			// *pctinfo);
			[System.Security.SecurityCritical]
			void GetTypeInfoCount(out uint pctinfo);

			/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
			/// <param name="iTInfo">The type information to return. Pass 0 to retrieve type information for the IDispatch implementation.</param>
			/// <param name="lcid">
			/// The locale identifier for the type information. An object may be able to return different type information for different
			/// languages. This is important for classes that support localized member names. For classes that do not support localized
			/// member names, this parameter can be ignored.
			/// </param>
			/// <param name="ppTInfo">The requested type information object.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-idispatch-gettypeinfo HRESULT GetTypeInfo(UINT iTInfo, LCID
			// lcid, ITypeInfo **ppTInfo);
			[System.Security.SecurityCritical]
			void GetTypeInfo(uint iTInfo, LCID lcid, out ITypeInfo ppTInfo);

			/// <summary>
			/// Maps a single member and an optional set of argument names to a corresponding set of integer DISPIDs, which can be used on
			/// subsequent calls to Invoke. The dispatch function DispGetIDsOfNames provides a standard implementation of <c>GetIDsOfNames</c>.
			/// </summary>
			/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
			/// <param name="rgszNames">The array of names to be mapped.</param>
			/// <param name="cNames">The count of the names to be mapped.</param>
			/// <param name="lcid">The locale context in which to interpret the names.</param>
			/// <param name="rgDispId">
			/// Caller-allocated array, each element of which contains an identifier (ID) corresponding to one of the names passed in the
			/// rgszNames array. The first element represents the member name. The subsequent elements represent each of the member's parameters.
			/// </param>
			/// <remarks>
			/// <para>
			/// An IDispatch implementation can associate any positive integer ID value with a given name. Zero is reserved for the default,
			/// or <c>Value</c> property; –1 is reserved to indicate an unknown name; and other negative values are defined for other
			/// purposes. For example, if <c>GetIDsOfNames</c> is called, and the implementation does not recognize one or more of the
			/// names, it returns DISP_E_UNKNOWNNAME, and the rgDispId array contains DISPID_UNKNOWN for the entries that correspond to the
			/// unknown names.
			/// </para>
			/// <para>
			/// The member and parameter DISPIDs must remain constant for the lifetime of the object. This allows a client to obtain the
			/// DISPIDs once, and cache them for later use.
			/// </para>
			/// <para>
			/// When <c>GetIDsOfNames</c> is called with more than one name, the first name (rgszNames[0]) corresponds to the member name,
			/// and subsequent names correspond to the names of the member's parameters.
			/// </para>
			/// <para>
			/// The same name may map to different DISPIDs, depending on context. For example, a name may have a DISPID when it is used as a
			/// member name with a particular interface, a different ID as a member of a different interface, and different mapping for each
			/// time it appears as a parameter.
			/// </para>
			/// <para>
			/// <c>GetIDsOfNames</c> is used when an IDispatch client binds to names at run time. To bind at compile time instead, an
			/// <c>IDispatch</c> client can map names to DISPIDs by using the type information interfaces described in Type Description
			/// Interfaces. This allows a client to bind to members at compile time and avoid calling <c>GetIDsOfNames</c> at run time. For
			/// a description of binding at compile time, see Type Description Interfaces.
			/// </para>
			/// <para>
			/// The implementation of <c>GetIDsOfNames</c> is case insensitive. Users that need case-sensitive name mapping should use type
			/// information interfaces to map names to DISPIDs, rather than call <c>GetIDsOfNames</c>.
			/// </para>
			/// <para>
			/// <c>Caution</c> You cannot use this method to access values that have been added dynamically, such as values added through
			/// JavaScript. Instead, use the GetDispID of the IDispatchEx interface. For more information, see the IDispatchEx interface.
			/// </para>
			/// <para>Examples</para>
			/// <para>
			/// The following code from the Lines sample file Lines.cpp implements the <c>GetIDsOfNames</c> member function for the CLine
			/// class. The ActiveX or OLE object uses the standard implementation, DispGetIDsOfNames. This implementation relies on
			/// <c>DispGetIdsOfNames</c> to validate input arguments. To help minimize security risks, include code that performs more
			/// robust validation of the input arguments.
			/// </para>
			/// <para>
			/// The following code might appear in an ActiveX client that calls <c>GetIDsOfNames</c> to get the DISPID of the
			/// <c>CLine</c><c>Color</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-idispatch-getidsofnames HRESULT GetIDsOfNames(REFIID riid,
			// LPOLESTR *rgszNames, UINT cNames, LCID lcid, DISPID *rgDispId);
			[System.Security.SecurityCritical]
			void GetIDsOfNames([Optional] in Guid riid, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 2)] string[] rgszNames,
				uint cNames, LCID lcid, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4, SizeParamIndex = 2)] int[] rgDispId);

			/// <summary>
			/// Provides access to properties and methods exposed by an object. The dispatch function DispInvoke provides a standard
			/// implementation of <c>Invoke</c>.
			/// </summary>
			/// <param name="dispIdMember">
			/// Identifies the member. Use GetIDsOfNames or the object's documentation to obtain the dispatch identifier.
			/// </param>
			/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
			/// <param name="lcid">
			/// <para>
			/// The locale context in which to interpret arguments. The <paramref name="lcid"/> is used by the GetIDsOfNames function, and
			/// is also passed to <c>Invoke</c> to allow the object to interpret its arguments specific to a locale.
			/// </para>
			/// <para>
			/// Applications that do not support multiple national languages can ignore this parameter. For more information, refer to
			/// Supporting Multiple National Languages and Exposing ActiveX Objects.
			/// </para>
			/// </param>
			/// <param name="wFlags">
			/// <para>Flags describing the context of the <c>Invoke</c> call.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DISPATCH_METHOD</term>
			/// <term>
			/// The member is invoked as a method. If a property has the same name, both this and the DISPATCH_PROPERTYGET flag can be set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>DISPATCH_PROPERTYGET</term>
			/// <term>The member is retrieved as a property or data member.</term>
			/// </item>
			/// <item>
			/// <term>DISPATCH_PROPERTYPUT</term>
			/// <term>The member is changed as a property or data member.</term>
			/// </item>
			/// <item>
			/// <term>DISPATCH_PROPERTYPUTREF</term>
			/// <term>
			/// The member is changed by a reference assignment, rather than a value assignment. This flag is valid only when the property
			/// accepts a reference to an object.
			/// </term>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pDispParams">
			/// Pointer to a DISPPARAMS structure containing an array of arguments, an array of argument DISPIDs for named arguments, and
			/// counts for the number of elements in the arrays.
			/// </param>
			/// <param name="pVarResult">
			/// Pointer to the location where the result is to be stored, or NULL if the caller expects no result. This argument is ignored
			/// if DISPATCH_PROPERTYPUT or DISPATCH_PROPERTYPUTREF is specified.
			/// </param>
			/// <param name="pExcepInfo">
			/// Pointer to a structure that contains exception information. This structure should be filled in if DISP_E_EXCEPTION is
			/// returned. Can be NULL.
			/// </param>
			/// <param name="puArgErr">
			/// The index within rgvarg of the first argument that has an error. Arguments are stored in pDispParams-&gt;rgvarg in reverse
			/// order, so the first argument is the one with the highest index in the array. This parameter is returned only when the
			/// resulting return value is DISP_E_TYPEMISMATCH or DISP_E_PARAMNOTFOUND. This argument can be set to null. For details, see
			/// Returning Errors.
			/// </param>
			/// <remarks>
			/// <para>
			/// Generally, you should not implement <c>Invoke</c> directly. Instead, use the dispatch interface to create functions
			/// CreateStdDispatch and DispInvoke. For details, refer to <c>CreateStdDispatch</c>, <c>DispInvoke</c>, Creating the IDispatch
			/// Interface and Exposing ActiveX Objects.
			/// </para>
			/// <para>
			/// If some application-specific processing needs to be performed before calling a member, the code should perform the necessary
			/// actions, and then call ITypeInfo::Invoke to invoke the member. <c>ITypeInfo::Invoke</c> acts exactly like <c>Invoke</c>. The
			/// standard implementations of <c>Invoke</c> created by <c>CreateStdDispatch</c> and <c>DispInvoke</c> defer to <c>ITypeInfo::Invoke</c>.
			/// </para>
			/// <para>
			/// In an ActiveX client, <c>Invoke</c> should be used to get and set the values of properties, or to call a method of an
			/// ActiveX object. The dispIdMember argument identifies the member to invoke. The DISPIDs that identify members are defined by
			/// the implementor of the object and can be determined by using the object's documentation, the IDispatch::GetIDsOfNames
			/// function, or the ITypeInfo interface.
			/// </para>
			/// <para>
			/// When you use <c>IDispatch::Invoke()</c> with DISPATCH_PROPERTYPUT or DISPATCH_PROPERTYPUTREF, you have to specially
			/// initialize the <c>cNamedArgs</c> and <c>rgdispidNamedArgs</c> elements of your DISPPARAMS structure with the following:
			/// </para>
			/// <para>
			/// The information that follows addresses developers of ActiveX clients and others who use code to expose ActiveX objects. It
			/// describes the behavior that users of exposed objects should expect.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-idispatch-invoke HRESULT Invoke(DISPID dispIdMember, REFIID
			// riid, LCID lcid, WORD wFlags, DISPPARAMS *pDispParams, VARIANT *pVarResult, EXCEPINFO *pExcepInfo, UINT *puArgErr);
			[System.Security.SecurityCritical]
			void Invoke(int dispIdMember, [Optional] in Guid riid, LCID lcid, INVOKEKIND wFlags, ref DISPPARAMS pDispParams, [Optional] IntPtr pVarResult, [Optional] IntPtr pExcepInfo, [Optional] IntPtr puArgErr);
		}

		/// <summary>Provides detailed contextual error information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nn-oaidl-ierrorinfo
		[PInvokeData("oaidl.h", MSDNShortId = "4dda6909-2d9a-4727-ae0c-b5f90dcfa447")]
		[ComImport, Guid("1CF2B120-547D-101B-8E65-08002B2BD119"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IErrorInfo
		{
			/// <summary>Returns the globally unique identifier (GUID) of the interface that defined the error.</summary>
			/// <param name="pGUID">A pointer to a GUID, or GUID_NULL, if the error was defined by the operating system.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			/// <remarks>
			/// <para>
			/// <c>IErrorInfo::GetGUID</c> returns the GUID of the interface that defined the error. If the error was defined by the system,
			/// <c>IErrorInfo::GetGUID</c> returns GUID_NULL.
			/// </para>
			/// <para>
			/// This GUID does not necessarily represent the source of the error. The source is the class or application that raised the
			/// error. Using the GUID, an application can handle errors in an interface, independent of the class that implements the interface.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-ierrorinfo-getguid HRESULT GetGUID(GUID *pGUID);
			[PreserveSig]
			HRESULT GetGUID(out Guid pGUID);

			/// <summary>Returns the language-dependent programmatic ID (ProgID) for the class or application that raised the error.</summary>
			/// <param name="pBstrSource">A ProgID, in the form progname.objectname.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			/// <remarks>
			/// Use <c>IErrorInfo::GetSource</c> to determine the class or application that is the source of the error. The language for the
			/// returned ProgID depends on the locale ID (LCID) that was passed into the method at the time of invocation.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-ierrorinfo-getsource HRESULT GetSource(BSTR *pBstrSource);
			[PreserveSig]
			HRESULT GetSource([MarshalAs(UnmanagedType.BStr)] out string pBstrSource);

			/// <summary>Returns a textual description of the error.</summary>
			/// <param name="pBstrDescription">A brief description of the error.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			/// <remarks>
			/// The text is returned in the language specified by the locale identifier (LCID) that was passed to IDispatch::Invoke for the
			/// method that encountered the error.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-ierrorinfo-getdescription HRESULT GetDescription(BSTR
			// *pBstrDescription);
			[PreserveSig]
			HRESULT GetDescription([MarshalAs(UnmanagedType.BStr)] out string pBstrDescription);

			/// <summary>Returns the path of the Help file that describes the error.</summary>
			/// <param name="pBstrHelpFile">The fully qualified path of the Help file.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			/// <remarks>
			/// This method returns the fully qualified path of the Help file that describes the current error. IErrorInfo::GetHelpContext
			/// should be used to find the Help context ID for the error in the Help file.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-ierrorinfo-gethelpfile HRESULT GetHelpFile(BSTR
			// *pBstrHelpFile);
			[PreserveSig]
			HRESULT GetHelpFile([MarshalAs(UnmanagedType.BStr)] out string pBstrHelpFile);

			/// <summary>Returns the Help context identifier (ID) for the error.</summary>
			/// <param name="pdwHelpContext">The Help context ID for the error.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			/// <remarks>This method returns the Help context ID for the error. To find the Help file to which it applies, use IErrorInfo::GetHelpFile.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-ierrorinfo-gethelpcontext HRESULT GetHelpContext(DWORD
			// *pdwHelpContext);
			[PreserveSig]
			HRESULT GetHelpContext(out uint pdwHelpContext);
		}

		/// <summary>Communicates detailed error information between a client and an object.</summary>
		[ComImport, Guid("3127CA40-446E-11CE-8135-00AA004BB851"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("OAIdl.h")]
		public interface IErrorLog
		{
			/// <summary>Logs an error (using an EXCEPINFO structure) in the error log for a named property.</summary>
			/// <param name="pszPropName">
			/// A pointer to a string containing the name of the property involved with the error. This cannot be NULL.
			/// </param>
			/// <param name="pExcepInfo">
			/// A pointer to the caller-initialized EXCEPINFO structure that describes the error to log. This cannot be NULL.
			/// </param>
			void AddError([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropName, in EXCEPINFO pExcepInfo);
		}

		/// <summary>Provides an object with a property bag in which the object can save its properties persistently.</summary>
		/// <remarks>
		/// To read a property in IPersistPropertyBag::Load, the object calls IPropertyBag::Read. When the object saves properties in
		/// IPersistPropertyBag::Save, it calls IPropertyBag::Write. Each property is described with a name, whose value is stored in a
		/// VARIANT. This information allows a client to save the property values as text, for example; which is the primary reason why a
		/// client might choose to support IPersistPropertyBag.
		/// </remarks>
		[ComImport, Guid("55272A00-42CB-11CE-8135-00AA004BB851"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("OAIdl.h")]
		public interface IPropertyBag
		{
			/// <summary>Tells the property bag to read the named property into a caller-initialized VARIANT.</summary>
			/// <param name="pszPropName">The address of the name of the property to read. This cannot be NULL.</param>
			/// <param name="pVar">
			/// The address of the caller-initialized VARIANT that receives the property value on output. The function must set the type
			/// field and the value field in the VARIANT before it returns. If the caller initialized the pVar-&gt;vt field on entry, the
			/// property bag attempts to change its corresponding value to this type. If the caller sets pVar-&gt;vt to VT_EMPTY, the
			/// property bag can use whatever type is convenient.
			/// </param>
			/// <param name="pErrorLog">
			/// The address of the caller's error log in which the property bag stores any errors that occur during reads. This can be NULL;
			/// in which case, the caller does not receive errors.
			/// </param>
			/// <remarks>
			/// The Read method tells the property bag to read the property named in pszPropName to the caller-initialized VARIANT in pVar.
			/// Errors are logged in the error log that is pointed to by pErrorLog. When pVar-&gt;vt specifies another object pointer
			/// (VT_UNKNOWN), the property bag is responsible for creating and initializing the object described by pszPropName.
			/// </remarks>
			void Read([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropName, [In, Out] ref object pVar, [In] IErrorLog pErrorLog);

			/// <summary>Tells the property bag to save the named property in a caller-initialized VARIANT.</summary>
			/// <param name="pszPropName">The address of a string containing the name of the property to write. This cannot be NULL.</param>
			/// <param name="pVar">
			/// The address of the caller-initialized VARIANT that holds the property value to save. The caller owns this VARIANT, and is
			/// responsible for all of its allocations. That is, the property bag does not attempt to free data in the VARIANT.
			/// </param>
			/// <remarks>
			/// The Write method tells the property bag to save the property named with pszPropName by using the type and value in the
			/// caller-initialized VARIANT in pVar. In some cases, the caller might be telling the property bag to save another object, for
			/// example, when pVar-&gt;vt is VT_UNKNOWN. In such cases, the property bag queries this object pointer for a persistence
			/// interface, such as IPersistStream or IPersistPropertyBag, and has that object save its data as well. Usually this results in
			/// the property bag having some byte array for this object, which can be saved as encoded text, such as hexadecimal string,
			/// MIME, and so on. When the property bag is later used to reinitialize a control, the client that owns the property bag must
			/// re-create the object when the caller asks for it, initializing that object with the previously saved bits.
			/// <para>
			/// This allows efficient persistence operations for Binary Large Object (BLOB) properties, such as a picture, where the owner
			/// of the property bag tells the picture object (which is managed as a property in the control that is saved) to save to a
			/// specific location. This avoids potential extra copy operations that might be involved with other property-based persistence mechanisms.
			/// </para>
			/// </remarks>
			void Write([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropName, in object pVar);
		}

		/// <summary>
		/// Describes the structure of a particular UDT. You can use IRecordInfo any time you need to access the description of UDTs
		/// contained in type libraries. IRecordInfo can be reused as needed; there can be many instances of the UDT for a single
		/// IRecordInfo pointer.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nn-oaidl-irecordinfo
		[PInvokeData("OAIdl.h")]
		[ComImport, Guid("0000002F-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IRecordInfo
		{
			/// <summary>
			/// <para>Initializes a new instance of a record.</para>
			/// </summary>
			/// <param name="pvNew">
			/// <para>An instance of a record.</para>
			/// </param>
			/// <remarks>
			/// <para>The caller must allocate the memory of the record by its appropriate size using the GetSize method.</para>
			/// <para><c>RecordInit</c> sets all contents of the record to 0 and the record should hold no resources.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-recordinit
			void RecordInit(IntPtr pvNew);

			/// <summary>
			/// <para>Releases object references and other values of a record without deallocating the record.</para>
			/// </summary>
			/// <param name="pvExisting">
			/// <para>The record to be cleared.</para>
			/// </param>
			/// <remarks>
			/// <c>RecordClear</c> releases memory blocks held by VT_PTR or VT_SAFEARRAY instance fields. The caller needs to free the
			/// instance fields memory, <c>RecordClear</c> will do nothing if there are no resources held.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-recordclear
			void RecordClear(IntPtr pvExisting);

			/// <summary>
			/// <para>Copies an existing record into the passed in buffer.</para>
			/// </summary>
			/// <param name="pvExisting">
			/// <para>The current record instance.</para>
			/// </param>
			/// <param name="pvNew">
			/// <para>The destination where the record will be copied.</para>
			/// </param>
			/// <remarks>
			/// <c>RecordCopy</c> will release the resources in the destination first. The caller is responsible for allocating sufficient
			/// memory in the destination by calling GetSize or RecordCreate. If <c>RecordCopy</c> fails to copy any of the fields then all
			/// fields will be cleared, as though RecordClear had been called.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-recordcopy
			void RecordCopy(IntPtr pvExisting, IntPtr pvNew);

			/// <summary>
			/// <para>Gets the GUID of the record type.</para>
			/// </summary>
			/// <returns>
			/// <para>The class GUID of the TypeInfo that describes the UDT.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-getguid
			Guid GetGuid();

			/// <summary>
			/// <para>
			/// Gets the name of the record type. This is useful if you want to print out the type of the record, because each UDT has it's
			/// own IRecordInfo.
			/// </para>
			/// </summary>
			/// <returns>
			/// <para>The name.</para>
			/// </returns>
			/// <remarks>
			/// <para>The caller must free the BSTR by calling SysFreeString.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-getname
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetName();

			/// <summary>
			/// <para>
			/// Gets the number of bytes of memory necessary to hold the record instance. This allows you to allocate memory for a record
			/// instance rather than calling RecordCreate.
			/// </para>
			/// </summary>
			/// <returns>
			/// <para>The size of a record instance, in bytes.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-getsize
			uint GetSize();

			/// <summary>Retrieves the type information that describes a UDT or safearray of UDTs.</summary>
			/// <param name="ppTypeInfo">The type information.</param>
			/// <remarks><c>AddRef</c> is called on the pointer ppTypeInfo.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-gettypeinfo
			void GetTypeInfo([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler")] out Type ppTypeInfo);

			/// <summary>
			/// <para>Returns a pointer to the VARIANT containing the value of a given field name.</para>
			/// </summary>
			/// <param name="pvData">
			/// <para>The instance of a record.</para>
			/// </param>
			/// <param name="szFieldName">
			/// <para>The field name.</para>
			/// </param>
			/// <returns>
			/// The VARIANT that you want to hold the value of the field name, szFieldName. On return, places a copy of the field's value in
			/// the variant.
			/// </returns>
			/// <remarks>
			/// <para>
			/// The VARIANT that you pass in contains a copy of the field's value upon return. If you modify the VARIANT then the underlying
			/// record field does not change.
			/// </para>
			/// <para>The caller allocates memory of the VARIANT.</para>
			/// <para>The method VariantClear is called for pvarField before copying.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-getfield
			[return: MarshalAs(UnmanagedType.Struct)]
			object GetField(IntPtr pvData, [MarshalAs(UnmanagedType.LPWStr)] string szFieldName);

			/// <summary>
			/// <para>Returns a pointer to the value of a given field name without copying the value and allocating resources.</para>
			/// </summary>
			/// <param name="pvData">
			/// <para>The instance of a record.</para>
			/// </param>
			/// <param name="szFieldName">
			/// <para>The name of the field.</para>
			/// </param>
			/// <param name="pvarField">
			/// <para>The VARIANT that will contain the UDT upon return.</para>
			/// </param>
			/// <returns>
			/// <para>Receives the value of the field upon return.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Upon return, the VARIANT you pass contains a direct pointer to the record's field, ppvDataCArray. If you modify the VARIANT,
			/// then the underlying record field will change.
			/// </para>
			/// <para>
			/// The caller allocates memory of the VARIANT, but does not own the memory so cannot free pvarField. This method calls
			/// VariantClear for pvarField before filling in the requested field.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-getfieldnocopy
			IntPtr GetFieldNoCopy(IntPtr pvData, [MarshalAs(UnmanagedType.LPWStr)] string szFieldName, [MarshalAs(UnmanagedType.Struct)] out object pvarField);

			/// <summary>
			/// <para>Puts a variant into a field.</para>
			/// </summary>
			/// <param name="wFlags">
			/// <para>The only legal values for the wFlags parameter is INVOKE_PROPERTYPUT or INVOKE_PROPERTYPUTREF.</para>
			/// <para>
			/// If INVOKE_PROPERTYPUTREF is passed in then <c>PutField</c> just assigns the value of the variant that is passed in to the
			/// field using normal coercion rules.
			/// </para>
			/// <para>
			/// If INVOKE_PROPERTYPUT is passed in then specific rules apply. If the field is declared as a class that derives from
			/// IDispatch and the field's value is NULL then an error will be returned. If the field's value is not NULL then the variant
			/// will be passed to the default property supported by the object referenced by the field. If the field is not declared as a
			/// class derived from <c>IDispatch</c> then an error will be returned. If the field is declared as a variant of type
			/// VT_Dispatch then the default value of the object is assigned to the field. Otherwise, the variant's value is assigned to the field.
			/// </para>
			/// </param>
			/// <param name="pvData">
			/// <para>The pointer to an instance of the record.</para>
			/// </param>
			/// <param name="szFieldName">
			/// <para>The name of the field of the record.</para>
			/// </param>
			/// <param name="pvarField">
			/// <para>The pointer to the variant.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-putfield
			void PutField(uint wFlags, IntPtr pvData, [MarshalAs(UnmanagedType.LPWStr)] string szFieldName, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarField);

			/// <summary>
			/// <para>
			/// Passes ownership of the data to the assigned field by placing the actual data into the field. <c>PutFieldNoCopy</c> is
			/// useful for saving resources because it allows you to place your data directly into a record field. <c>PutFieldNoCopy</c>
			/// differs from PutField because it does not copy the data referenced by the variant.
			/// </para>
			/// </summary>
			/// <param name="wFlags">
			/// <para>The only legal values for the wFlags parameter is INVOKE_PROPERTYPUT or INVOKE_PROPERTYPUTREF.</para>
			/// </param>
			/// <param name="pvData">
			/// <para>An instance of the record described by IRecordInfo.</para>
			/// </param>
			/// <param name="szFieldName">
			/// <para>The name of the field of the record.</para>
			/// </param>
			/// <param name="pvarField">
			/// <para>The variant to be put into the field.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-putfieldnocopy
			void PutFieldNoCopy(uint wFlags, IntPtr pvData, [MarshalAs(UnmanagedType.LPWStr)] string szFieldName, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarField);

			/// <summary>
			/// <para>Gets the names of the fields of the record.</para>
			/// </summary>
			/// <param name="pcNames">
			/// <para>The number of names to return.</para>
			/// </param>
			/// <param name="rgBstrNames">
			/// <para>The name of the array of type BSTR.</para>
			/// <para>If the rgBstrNames parameter is NULL, then pcNames is returned with the number of field names.</para>
			/// <para>
			/// It the rgBstrNames parameter is not NULL, then the string names contained in rgBstrNames are returned. If the number of
			/// names in pcNames and rgBstrNames are not equal then the lesser number of the two is the number of returned field names. The
			/// caller needs to free the BSTRs inside the array returned in rgBstrNames.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para>
			/// The caller should allocate memory for the array of BSTRs. If the array is larger than needed, set the unused portion to 0.
			/// </para>
			/// <para>On return, the caller will need to free each contained BSTR using SysFreeString.</para>
			/// <para>In case of out of memory, pcNames points to error code.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-getfieldnames
			void GetFieldNames(ref uint pcNames, [In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.BStr, SizeParamIndex = 0)] string[] rgBstrNames);

			/// <summary>
			/// <para>Determines whether the record that is passed in matches that of the current record information.</para>
			/// </summary>
			/// <param name="pRecordInfo">
			/// <para>The information of the record.</para>
			/// </param>
			/// <returns>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The record that is passed in matches the current record information.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The record that is passed in does not match the current record information.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-ismatchingtype
			[PreserveSig] [return: MarshalAs(UnmanagedType.Bool)] bool IsMatchingType([In] IRecordInfo pRecordInfo);

			/// <summary>
			/// <para>Allocates memory for a new record, initializes the instance and returns a pointer to the record.</para>
			/// </summary>
			/// <returns>
			/// <para>This method returns a pointer to the created record.</para>
			/// </returns>
			/// <remarks>
			/// <para>The memory is set to zeros before it is returned.</para>
			/// <para>The records created must be freed by calling RecordDestroy.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-recordcreate
			[PreserveSig] IntPtr RecordCreate();

			/// <summary>
			/// <para>Creates a copy of an instance of a record to the specified location.</para>
			/// </summary>
			/// <param name="pvSource">
			/// <para>An instance of the record to be copied.</para>
			/// </param>
			/// <param name="ppvDest">
			/// <para>The new record with data copied from pvSource.</para>
			/// </param>
			/// <remarks>
			/// <para>The records created must be freed by calling RecordDestroy.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-recordcreatecopy
			void RecordCreateCopy(IntPtr pvSource, out IntPtr ppvDest);

			/// <summary>
			/// <para>Releases the resources and deallocates the memory of the record.</para>
			/// </summary>
			/// <param name="pvRecord">
			/// <para>An instance of the record to be destroyed.</para>
			/// </param>
			/// <remarks>
			/// <para>RecordClear is called to release the resources held by the instance of a record without deallocating memory.</para>
			/// <para>
			/// <c>Note</c> This method can only be called on records allocated through RecordCreate and RecordCreateCopy. If you allocate
			/// the record yourself, you cannot call this method.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oaidl/nf-oaidl-irecordinfo-recorddestroy
			void RecordDestroy(IntPtr pvRecord);
		}

		/// <summary>
		/// Ensures that error information can be propagated up the call chain correctly. Automation objects that use the error handling
		/// interfaces must implement <c>ISupportErrorInfo</c>.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nn-oaidl-isupporterrorinfo
		[PInvokeData("oaidl.h", MSDNShortId = "42d33066-36b4-4a5b-aa5d-46682e560f32")]
		[ComImport, Guid("DF0B3D60-548F-101B-8E65-08002B2BD119"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISupportErrorInfo
		{
			/// <summary>Indicates whether an interface supports the IErrorInfo interface.</summary>
			/// <param name="riid">An interface identifier (IID).</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The interface supports IErrorInfo.</term>
			/// </item>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>The interface does not support IErrorInfo.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>Objects that support the IErrorInfo interface must also implement this interface.</para>
			/// <para>
			/// Programs that receive an error return value should call <c>QueryInterface</c> to get a pointer to the
			/// ISupportErrorInfointerface, and then call <c>InterfaceSupportsErrorInfo</c> with the riid of the interface that returned the
			/// return value. If <c>InterfaceSupportsErrorInfo</c> returns S_FALSE, then the error object does not represent an error
			/// returned from the caller, but from somewhere else. In this case, the error object can be considered incorrect and should be discarded.
			/// </para>
			/// <para>If ISupportErrorInfo returns S_OK, use the GetErrorInfo function to get a pointer to the error object.</para>
			/// <para>
			/// For an example that demonstrates implementing <c>InterfaceSupportsErrorInfo</c>, see the ErrorInfo.cpp file in the COM
			/// Fundamentals Lines sample.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-isupporterrorinfo-interfacesupportserrorinfo HRESULT
			// InterfaceSupportsErrorInfo(REFIID riid);
			[PreserveSig]
			HRESULT InterfaceSupportsErrorInfo(in Guid riid);
		}

		/// <summary>
		/// Enables clients to subscribe to type change notifications on objects that implement the ITypeInfo, ITypeInfo2, ICreateTypeInfo,
		/// and ICreateTypeInfo2 interfaces. When ITypeChangeEvents is implemented on an object, it acts as an incoming interface that
		/// enables the object to receive calls from external clients and engage in bidirectional communication with those clients. For more
		/// information, see Events in COM and Connectable Objects.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nn-oaidl-itypechangeevents
		[PInvokeData("oaidl.h", MSDNShortId = "5e286a4b-b36b-40d6-9a39-d572086e5a2d")]
		[ComImport, Guid("00020410-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ITypeChangeEvents
		{
			/// <summary>Raised when a request has been made to change a type. The change can be disallowed.</summary>
			/// <param name="changeKind">
			/// <para>The type of change.</para>
			/// <para>CHANGEKIND_ADDMEMBER</para>
			/// <para>CHANGEKIND_DELETEMEMBER</para>
			/// <para>CHANGEKIND_SETNAMES</para>
			/// <para>CHANGEKIND_SETDOCUMENTATION</para>
			/// <para>CHANGEKIND_GENERAL</para>
			/// <para>CHANGEKIND_INVALIDATE</para>
			/// <para>CHANGEKIND_CHANGEFAILED</para>
			/// </param>
			/// <param name="pTInfoBefore">
			/// An object that implements the ITypeInfo, ITypeInfo2, ICreateTypeInfo, or ICreateTypeInfo2 interface and that contains the
			/// type information before the change was made. The client subscribes to this object to receive notifications about any changes.
			/// </param>
			/// <param name="pStrName">The name of the change. This value may be null.</param>
			/// <param name="pfCancel">False to disallow the change; otherwise, true.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-itypechangeevents-requesttypechange HRESULT
			// RequestTypeChange( CHANGEKIND changeKind, ITypeInfo *pTInfoBefore, LPOLESTR pStrName, INT *pfCancel );
			[PreserveSig]
			HRESULT RequestTypeChange([In] CHANGEKIND changeKind, [In] ITypeInfo pTInfoBefore, [MarshalAs(UnmanagedType.LPWStr)] string pStrName, out int pfCancel);

			/// <summary>Raised after a type has been changed.</summary>
			/// <param name="changeKind">
			/// <para>The type of change.</para>
			/// <para>CHANGEKIND_ADDMEMBER</para>
			/// <para>CHANGEKIND_DELETEMEMBER</para>
			/// <para>CHANGEKIND_SETNAMES</para>
			/// <para>CHANGEKIND_SETDOCUMENTATION</para>
			/// <para>CHANGEKIND_GENERAL</para>
			/// <para>CHANGEKIND_INVALIDATE</para>
			/// <para>CHANGEKIND_CHANGEFAILED</para>
			/// </param>
			/// <param name="pTInfoAfter">
			/// An object that implements the ITypeInfo, ITypeInfo2, ICreateTypeInfo, or ICreateTypeInfo2 interface and that contains the
			/// type information before the change was made. The client subscribes to this object to receive notifications about any changes.
			/// </param>
			/// <param name="pStrName">The name of the change. This value may be null.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Success.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more of the arguments is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory to complete the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oaidl/nf-oaidl-itypechangeevents-aftertypechange HRESULT AfterTypeChange(
			// CHANGEKIND changeKind, ITypeInfo *pTInfoAfter, LPOLESTR pStrName );
			[PreserveSig]
			HRESULT AfterTypeChange([In] CHANGEKIND changeKind, [In] ITypeInfo pTInfoAfter, [MarshalAs(UnmanagedType.LPWStr)] string pStrName);
		}
	}
}