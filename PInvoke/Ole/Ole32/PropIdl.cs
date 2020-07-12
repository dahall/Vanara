using System;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>
		/// The PROPSETFLAG constants define characteristics of a property set. The values, listed in the following table, are used in the
		/// grfFlags parameter of <c>IPropertySetStorage</c> methods, the <c>StgCreatePropStg</c> function, and the <c>StgOpenPropStg</c> function.
		/// </summary>
		/// <remarks>
		/// <para>
		/// These values can be set and checked using bitwise operations that determine how property sets are created and opened. Property
		/// sets are created using the <c>IPropertySetStorage::Create</c> method or the <c>StgCreatePropStg</c> function. They are opened
		/// using the <c>IPropertySetStorage::Open</c> method or the <c>StgOpenPropStg</c> function.
		/// </para>
		/// <para>
		/// It is recommended that property sets be created as Unicode by not setting the <c>PROPSETFLAG_ANSI</c> flag in the grfFlags
		/// parameter. It is also recommended that you avoid using VT_LPSTR values, and use VT_LPWSTR values instead. When the property set
		/// code page is Unicode, VT_LPSTR string values are converted to Unicode when stored, and converted back to multibyte string values
		/// when retrieved. When the code page of the property set is not Unicode, property names, VT_BSTR strings, and nonsimple property
		/// values are converted to multibyte strings when stored, and converted back to Unicode when retrieved, all using the current system
		/// ANSI code page.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/Stg/propsetflag-constants
		[PInvokeData("Propidl.h", MSDNShortId = "6f865c8f-bbca-4122-b076-14f2bc56f292")]
		[Flags]
		public enum PROPSETFLAG : uint
		{
			/// <summary>
			/// If left unspecified, by default only simple property values may be written to the property set. Using simple property values
			/// prevents property sets from being transacted in the compound file and stand-alone implementations of IPropertySetStorage.
			/// Non-e property values must be used for this purpose.
			/// </summary>
			PROPSETFLAG_DEFAULT = 0,

			/// <summary>
			/// If specified, nonsimple property values can be written to the property set and the property set is saved in a storage object.
			/// Non-simple property values include those with a VARTYPE of VT_STORAGE, VT_STREAM, VT_STORED_OBJECT, or VT_STREAMED_OBJECT. If
			/// this flag is not specified, non-simple types cannot be written into the property set. In the compound file and stand-alone
			/// implementations, property sets may be transacted only if PROPSETFLAG_NONSIMPLE is specified.
			/// </summary>
			PROPSETFLAG_NONSIMPLE = 1,

			/// <summary>
			/// If specified, all string values in the property set that are not explicitly Unicode, that is, those other than VT_LPWSTR, are
			/// stored with the current system ANSI code page. For more information, see GetACP. Use of this value is not recommended. For
			/// more information, see Remarks.
			/// <para>
			/// If this value is absent, string values in the new property set are stored in Unicode. The degree of control that this value
			/// provides is necessary so that clients using the property-related interfaces can interoperate with standard property sets such
			/// as the OLE2 summary information, which may exist in the ANSI code page.
			/// </para>
			/// </summary>
			PROPSETFLAG_ANSI = 2,

			/// <summary>
			/// Used only with the StgCreatePropStg and StgOpenPropStg functions; that is, in the stand-alone implementations of property set
			/// interfaces. If specified in these functions, changes to the property set are not buffered. Instead, changes are always
			/// written directly to the property set. Calls to a property set IPropertyStorage methods will change it. However, by default,
			/// changes are buffered in an internal property set cache and are subsequently written to the property set when the
			/// IPropertyStorage::Commit method is called.
			/// <para>
			/// Setting PROPSETFLAG_UNBUFFERED decreases performance because the property set internal buffer is automatically flushed after
			/// every change to the property set.However, writing changes directly will prevent coordination problems.For example, if the
			/// storage object is opened in transacted mode, and the property set is buffered.Then, if you call the IStorage::Commit method
			/// on the storage object, the property set changes will not be picked up as part of the transaction, because they are in a
			/// buffer that has not been flushed yet. You must call IPropertyStorage::Commit prior to calling IStorage::Commit to flush the
			/// property set buffer before committing changes to the storage.As an alternative to making two calls, you can set
			/// PROPSETFLAG_UNBUFFERED so that changes are always written directly to the property set and are never buffered in the property
			/// set's internal cache. Then, the changes will be picked up when the transacted storage is committed.
			/// </para>
			/// </summary>
			PROPSETFLAG_UNBUFFERED = 4,

			/// <summary>
			/// If specified, property names are case sensitive. Case-sensitive property names are only possible in the version 1 property
			/// set serialization format. For more information, see Property Set Serialization.
			/// </summary>
			PROPSETFLAG_CASE_SENSITIVE = 8
		}

		/// <summary>Values used in PROPSPEC.</summary>
		[PInvokeData("propidl.h", MSDNShortId = "5bb3b9c6-ab82-498c-94f9-13a9ffa7452b")]
		public enum PRSPEC
		{
			/// <summary>The lpwstr member is used and set to a string name.</summary>
			PRSPEC_LPWSTR = 0,

			/// <summary>The propid member is used and set to a property ID value.</summary>
			PRSPEC_PROPID = 1
		}

		/// <summary>
		/// <para>
		/// The <c>IEnumSTATPROPSETSTG</c> interface iterates through an array of STATPROPSETSTG structures. The <c>STATPROPSETSTG</c>
		/// structures contain statistical data about the property sets managed by the current IPropertySetStorage instance.
		/// <c>IEnumSTATPROPSETSTG</c> has the same methods as all enumerator interfaces: Next, Skip, Reset, and Clone.
		/// </para>
		/// <para>
		/// The implementation defines the order in which the property sets are enumerated. Property sets that are present when the
		/// enumerator is created, and are not removed during the enumeration, will be enumerated only once. Property sets added or deleted
		/// while the enumeration is in progress may or may not be enumerated, but, if enumerated, will not be enumerated more than once.
		/// </para>
		/// <para>
		/// For more information about how the COM compound document implementation of IEnumSTATPROPSETSTG::Next supplies members of the
		/// STATPROPSETSTG structure, see IEnumSTATPROPSETSTG--Compound File Implementation.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nn-propidl-ienumstatpropsetstg
		[PInvokeData("propidl.h", MSDNShortId = "0000013B-0000-0000-C000-000000000046")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0e6d4d92-6738-11cf-9608-00aa00680db4")]
		public interface IEnumSTATPROPSETSTG
		{
			/// <summary>
			/// The <c>Next</c> method retrieves a specified number of STATPROPSETSTG structures that follow subsequently in the enumeration
			/// sequence. If fewer than the requested number of STATPROPSETSTG structures exist in the enumeration sequence, it retrieves the
			/// remaining <c>STATPROPSETSTG</c> structures.
			/// </summary>
			/// <param name="celt">The number of STATPROPSETSTG structures requested.</param>
			/// <param name="rgelt">An array of STATPROPSETSTG structures returned.</param>
			/// <param name="pceltFetched">The number of STATPROPSETSTG structures retrieved in the rgelt parameter.</param>
			/// <returns>
			/// <para>This method supports the following return values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The number of STATPROPSETSTG structures returned equals the number specified in the celt parameter.</term>
			/// </item>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>The number of STATPROPSETSTG structures returned is less than the number specified in the celt parameter.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ienumstatpropsetstg-next HRESULT Next( ULONG celt,
			// STATPROPSETSTG *rgelt, ULONG *pceltFetched );
			[PInvokeData("propidl.h", MSDNShortId = "3af3c518-3db4-4436-b1c1-86587ce8fbf3")]
			[PreserveSig]
			HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] STATPROPSETSTG[] rgelt, out uint pceltFetched);

			/// <summary>The <c>Skip</c> method skips a specified number of STATPROPSETSTG structures in the enumeration sequence.</summary>
			/// <param name="celt">The number of STATPROPSETSTG structures to skip.</param>
			/// <returns>This method supports the following return values:</returns>
			/// <remarks>
			/// A positive value for the celt parameter skips forward in the STATPROPSETSTG structure enumeration. A negative value for the
			/// celt parameter skips backward in the <c>STATPROPSETSTG</c> structure enumeration.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ienumstatpropsetstg-skip HRESULT Skip( ULONG celt );
			[PInvokeData("propidl.h", MSDNShortId = "48275ca5-f9d1-42cb-b218-f51488a91bf8")]
			[PreserveSig]
			HRESULT Skip(uint celt);

			/// <summary>The <c>Reset</c> method resets the enumeration sequence to the beginning of the STATPROPSETSTG structure array.</summary>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ienumstatpropsetstg-reset HRESULT Reset( );
			[PInvokeData("propidl.h", MSDNShortId = "41207be6-81ec-4dfc-a737-eb56792edb6d")]
			void Reset();

			/// <summary>
			/// The <c>Clone</c> method creates an enumerator that contains the same enumeration state as the current STATPROPSETSTG
			/// structure enumerator. Using this method, a client can record a particular point in the enumeration sequence and then return
			/// to that point later. The new enumerator supports the same IEnumSTATPROPSETSTG interface.
			/// </summary>
			/// <returns>The variable that receives the IEnumSTATPROPSETSTG interface pointer.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ienumstatpropsetstg-clone HRESULT Clone(
			// IEnumSTATPROPSETSTG **ppenum );
			[PInvokeData("propidl.h", MSDNShortId = "f875d5e9-fac0-4961-9570-342f55cf307e")]
			IEnumSTATPROPSETSTG Clone();
		}

		/// <summary>
		/// <para>
		/// The <c>IEnumSTATPROPSTG</c> interface iterates through an array of STATPROPSTG structures. The <c>STATPROPSTG</c> structures
		/// contain statistical data about properties in a property set. <c>IEnumSTATPROPSTG</c> has the same methods as all enumerator
		/// interfaces: Next, Skip, Reset, and Clone.
		/// </para>
		/// <para>
		/// The implementation defines the order in which the properties in the set are enumerated. Properties that are present when the
		/// enumerator is created, and are not removed during the enumeration, will be enumerated only once. Properties added or deleted
		/// while the enumeration is in progress may or may not be enumerated, but will never be enumerated more than once.
		/// </para>
		/// <para>
		/// Reserved property identifiers, properties with a property ID of 0 (dictionary), 1 (code page indicator), or greater than or equal
		/// to 0x80000000 are not enumerated.
		/// </para>
		/// <para>
		/// Enumeration of a nonsimple property does not necessarily indicate that the property can be read successfully through a call to
		/// IPropertyStorage::ReadMultiple. This is because the performance overhead of checking existence of the indirect stream or storage
		/// is prohibitive during property enumeration.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidlbase/nn-propidlbase-ienumstatpropstg
		[PInvokeData("propidlbase.h", MSDNShortId = "e625e52a-5628-4d18-9282-aa1c141c83af")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000139-0000-0000-C000-000000000046")]
		public interface IEnumSTATPROPSTG
		{
			/// <summary>
			/// The <c>Next</c> method retrieves a specified number of STATPROPSTG structures, that follow subsequently in the enumeration
			/// sequence. If fewer than the requested number of STATPROPSTG structures exist in the enumeration sequence, it retrieves the
			/// remaining <c>STATPROPSTG</c> structures.
			/// </summary>
			/// <param name="celt">The number of STATPROPSTG structures requested.</param>
			/// <param name="rgelt">An array of STATPROPSTG structures returned.</param>
			/// <param name="pceltFetched">The number of STATPROPSTG structures retrieved in the rgelt parameter.</param>
			/// <returns>
			/// <para>This method supports the following return values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The number of STATPROPSTG structures returned is equal to the number specified in the celt parameter.</term>
			/// </item>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>The number of STATPROPSTG structures returned is less than the number specified in the celt parameter.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ienumstatpropstg-next HRESULT Next( ULONG celt,
			// STATPROPSTG *rgelt, ULONG *pceltFetched );
			[PInvokeData("propidl.h", MSDNShortId = "8e911da9-0056-4267-b9d0-c4ba929ddb94")]
			[PreserveSig]
			HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] STATPROPSTG[] rgelt, out uint pceltFetched);

			/// <summary>The <c>Skip</c> method skips the specified number of STATPROPSTG structures in the enumeration sequence.</summary>
			/// <param name="celt">The number of STATPROPSTG structures to skip.</param>
			/// <returns>This method supports the following return values:</returns>
			/// <remarks>
			/// A positive value for the celt parameter skips forward in the STATPROPSTG structure enumeration. A negative value for the celt
			/// parameter skips backward in the <c>STATPROPSTG</c> structure enumeration.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ienumstatpropstg-skip HRESULT Skip( ULONG celt );
			[PInvokeData("propidl.h", MSDNShortId = "e70e4668-d52c-4135-948b-c8f5d141e6a2")]
			[PreserveSig]
			HRESULT Skip(uint celt);

			/// <summary>The <c>Reset</c> method resets the enumeration sequence to the beginning of the STATPROPSTG structure array.</summary>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ienumstatpropstg-reset HRESULT Reset( );
			[PInvokeData("propidl.h", MSDNShortId = "e742e3ee-6261-4d6d-85ca-8df770aa58ad")]
			void Reset();

			/// <summary>
			/// The <c>Clone</c> method creates an enumerator that contains the same enumeration state as the current STATPROPSTG structure
			/// enumerator. Using this method, a client can record a particular point in the enumeration sequence and then return to that
			/// point later. The new enumerator supports the same IEnumSTATPROPSTG interface.
			/// </summary>
			/// <returns>
			/// <para>This method supports the following return values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>The ppenum parameter is NULL.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory.</term>
			/// </item>
			/// <item>
			/// <term>E_UNEXPECTED</term>
			/// <term>An unexpected exception occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ienumstatpropstg-clone HRESULT Clone( IEnumSTATPROPSTG
			// **ppenum );
			[PInvokeData("propidl.h", MSDNShortId = "e06e109a-3f9d-4b08-bde9-888cb795287c")]
			IEnumSTATPROPSTG Clone();
		}

		/// <summary>
		/// The IPropertySetStorage interface creates, opens, deletes, and enumerates property set storages that support instances of the
		/// IPropertyStorage interface. The IPropertyStorage interface manages a single property set in a property storage subobject; and the
		/// IPropertySetStorage interface manages the storage of groups of such property sets. Any file system entity can support
		/// IPropertySetStorage that is currently implemented in the COM compound file object.
		/// <para>
		/// The IPropertySetStorage and IPropertyStorage interfaces provide a uniform way to create and manage property sets, whether or not
		/// these sets reside in a storage object that supports IStorage.When called through an object supporting IStorage (such as
		/// structured and compound files) or IStream, the property sets created conform to the COM property set format, described in detail
		/// in Structured Storage Serialized Property Set Format.Similarly, properties written using IStorage to the COM property set format
		/// are visible through IPropertySetStorage and IPropertyStorage.
		/// </para>
		/// <para>
		/// IPropertySetStorage methods identify property sets through a globally unique identifier (GUID) called a format identifier
		/// (FMTID). The FMTID for a property set identifies the property identifiers in the property set, their meaning, and any constraints
		/// on the values. The FMTID of a property set should also provide the means to manipulate that property set. Only one instance of a
		/// given FMTID may exist at a time within a single property storage.
		/// </para>
		/// </summary>
		[PInvokeData("Propidl.h", MSDNShortId = "0ea3e1e0-c135-4138-81e4-f72412fc3128")]
		[ComImport, Guid("0000013A-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IPropertySetStorage
		{
			/// <summary>
			/// <para>The <c>Create</c> method creates and opens a new property set in the property set storage object.</para>
			/// </summary>
			/// <param name="rfmtid"/>
			/// <param name="pclsid">
			/// <para>
			/// A pointer to the initial class identifier CLSID for this property set. May be <c>NULL</c>, in which case it is set to all
			/// zeroes. The CLSID is the CLSID of a class that displays and/or provides programmatic access to the property values. If there
			/// is no such class, it is recommended that the FMTID be used.
			/// </para>
			/// </param>
			/// <param name="grfFlags">
			/// <para>The values from PROPSETFLAG Constants.</para>
			/// </param>
			/// <param name="grfMode">
			/// <para>
			/// An access mode in which the newly created property set is to be opened, taken from certain values of STGM_Constants, as
			/// described in the following Remarks section.
			/// </para>
			/// </param>
			/// <param name="ppprstg"/>
			/// <returns>
			/// <para>This method supports the standard return value E_UNEXPECTED, as well as the following:</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>IPropertySetStorage::Create</c> creates and opens a new property set subobject (supporting the IPropertyStorage interface)
			/// contained in this property set storage object. The property set automatically contains code page and locale ID properties.
			/// These are set to the Unicode and the current user default, respectively.
			/// </para>
			/// <para>
			/// The parameter is a combination of values taken from PROPSETFLAG Constants. If the PROPSETFLAG_ANSI value from this
			/// enumeration is used, the code page is set to the current system default, rather than Unicode.
			/// </para>
			/// <para>
			/// The parameter specifies the access mode in which the newly created set is to be opened. Values for this parameter are as in
			/// the parameter to IPropertySetStorage::Open, with the addition of the values listed in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>STGM_FAILIFTHERE</term>
			/// <term>
			/// If another property set with the specified parameter exists, the call fails. This is the default action; that is, unless
			/// STGM_CREATE is specified, STGM_FAILIFTHERE is implied.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STGM_CREATE</term>
			/// <term>If another property set with the specified parameter already exists, it is removed and replaced with this new one.</term>
			/// </item>
			/// </list>
			/// <para>
			/// The created property set is simple by default, but the caller may request a nonsimple property set by specifying the
			/// PROPSETFLAG_NONSIMPLE value in the parameter. For more information about simple and nonsimple property sets, see Storage and
			/// Stream Objects for a Property Set.
			/// </para>
			/// <para>
			/// This method is subject to the constraints of the underlying IStorage::CreateStream (for simple property sets) or
			/// IStorage::CreateStorage (for nonsimple property sets). For example, when using the IPropertySetStorage-Compound File
			/// Implementation, specify STGM_SHARE_EXCLUSIVE in the parameter to <c>IPropertySetStorage::Create</c>. Conversely, if using the
			/// IPropertySetStorage-Stand-alone Implementation, <c>IPropertySetStorage::Create</c> is subject to constraints that apply to
			/// the caller-specified IStorage.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertysetstorage-create
			[PreserveSig]
			HRESULT Create(in Guid rfmtid, [In] IntPtr pclsid, [In] STGM grfFlags, [In] STGM grfMode, out IPropertyStorage ppprstg);

			/// <summary>
			/// <para>The <c>Open</c> method opens a property set contained in the property set storage object.</para>
			/// </summary>
			/// <param name="rfmtid"/>
			/// <param name="grfMode">
			/// <para>
			/// The access mode in which the newly created property set is to be opened. These flags are taken from STGM Constants. Flags
			/// that may be used and their meanings in the context of this method are described in the following Remarks section.
			/// </para>
			/// </param>
			/// <param name="ppprstg"/>
			/// <returns>
			/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The mode in which the property set is to be opened is specified in the parameter . These flags are taken from STGM Constants,
			/// but, for this method, legal values and their meanings are as follows (only certain combinations of these flag values are legal).
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>STGM_DIRECT</term>
			/// <term>
			/// Opens the property set without an additional level of transaction nesting. This is the default (the behavior if neither
			/// STGM_DIRECT nor STGM_TRANSACTED is specified).
			/// </term>
			/// </item>
			/// <item>
			/// <term>STGM_TRANSACTED</term>
			/// <term>
			/// Opens the property set with an additional level of transaction nesting (beyond the transaction, if any, on this property set
			/// storage object). Transacted mode is available only for nonsimple property sets. Changes in the property set must be committed
			/// with a call to IPropertyStorage::Commit before they are visible to the transaction on this property set storage.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STGM_READ</term>
			/// <term>Opens the property set with read access. Read permission is required on the property set storage.</term>
			/// </item>
			/// <item>
			/// <term>STGM_WRITE</term>
			/// <term>Opens the property set with write access. Not all implementations of IPropertyStorage support this mode.</term>
			/// </item>
			/// <item>
			/// <term>STGM_READWRITE</term>
			/// <term>
			/// Opens the property set with read and write access. Be aware that this flag is not the binary OR of the values STGM_READ and STGM_WRITE.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STGM_SHARE_DENY_NONE</term>
			/// <term>
			/// Subsequent openings of the property set from this property set storage are not denied read or write access. (Not available in
			/// all implementations.)
			/// </term>
			/// </item>
			/// <item>
			/// <term>STGM_SHARE_DENY_READ</term>
			/// <term>
			/// Subsequent openings of the property set from this property set storage are denied read access. Not available in all implementations.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STGM_SHARE_DENY_WRITE</term>
			/// <term>
			/// Subsequent openings of the property set from this property set storage are denied write access. This value is typically used
			/// in the transacted mode to prevent making unnecessary copies of an object opened by multiple users. That is, if
			/// STGM_TRANSACTED is specified, but this value is not specified, a snapshot is made, whether there are subsequent openings or
			/// not. Thus, you can improve performance by specifying this value. Not available in all implementations.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STGM_SHARE_EXCLUSIVE</term>
			/// <term>
			/// Subsequent openings of the property set from this property set storage are not possible. Be aware that this value is not a
			/// simple binary OR of the STGM_SHARE_DENY_READ and STGM_SHARE_DENY_WRITE elements.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// This method is subject to the constraints of the underlying IStorage::OpenStream (for simple property sets) or
			/// IStorage::OpenStorage (for nonsimple property sets). For more information about simple and nonsimple property sets, see
			/// Storage and Stream Objects for a Property Set. For example, when using the IPropertySetStorage-Compound File Implementation,
			/// you must specify STGM_SHARE_EXCLUSIVE in the parameter to <c>IPropertySetStorage::Open</c>. Conversely, if using the
			/// IPropertySetStorage-Stand-alone Implementation, <c>IPropertySetStorage::Open</c> is subject to constraints that apply to the
			/// caller-specified IStorage.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertysetstorage-open
			[PreserveSig]
			HRESULT Open(in Guid rfmtid, [In] STGM grfMode, out IPropertyStorage ppprstg);

			/// <summary>
			/// <para>The <c>Delete</c> method deletes one of the property sets contained in the property set storage object.</para>
			/// </summary>
			/// <param name="rfmtid"/>
			/// <returns>
			/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>IPropertySetStorage::Delete</c> deletes the property set specified by its FMTID. Specifying a property set that does not
			/// exist returns an error. Open substorages and streams(opened through one of the storage- or stream-valued properties) are put
			/// into the reverted state.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertysetstorage-delete
			[PreserveSig]
			HRESULT Delete(in Guid rfmtid);

			/// <summary>
			/// <para>
			/// The <c>Enum</c> method creates an enumerator object which contains information on the property sets stored in this property
			/// set storage. On return, this method supplies a pointer to the IEnumSTATPROPSETSTG pointer on the enumerator object.
			/// </para>
			/// </summary>
			/// <param name="ppenum">
			/// <para>
			/// Pointer to IEnumSTATPROPSETSTG pointer variable that receives the interface pointer to the newly created enumerator object.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>IPropertySetStorage::Enum</c> creates an enumerator object that can be used to iterate through STATPROPSETSTG structures.
			/// These sometimes provide information on the property sets managed by IPropertySetStorage. This method, on return, supplies a
			/// pointer to the IEnumSTATPROPSETSTG interface on this enumerator object on return.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertysetstorage-enum
			[PreserveSig]
			HRESULT Enum(out IEnumSTATPROPSETSTG ppenum);
		}

		/// <summary>
		/// <para>
		/// The <c>IPropertyStorage</c> interface manages the persistent properties of a single property set. Persistent properties consist
		/// of information that can be stored persistently in a property set, such as the summary information associated with a file. This
		/// contrasts with run-time properties associated with Controls and Automation, which can be used to affect system behavior. Use the
		/// methods of the IPropertySetStorage interface to create or open a persistent property set. An instance of the
		/// <c>IPropertySetStorage</c> interface can manage zero or more <c>IPropertyStorage</c> instances.
		/// </para>
		/// <para>
		/// Each property within a property set is identified by a property identifier (ID), a four-byte <c>ULONG</c> value unique to that
		/// set. You can also assign a string name to a property through the <c>IPropertyStorage</c> interface.
		/// </para>
		/// <para>
		/// Property IDs differ from the dispatch IDs used in Automation <c>dispid</c> property name tags. One difference is that the
		/// general-purpose use of property ID values zero and one is prohibited in <c>IPropertyStorage</c>, while no such restriction exists
		/// in <c>IDispatch</c>. In addition, while there is significant overlap among the data types for property values that may be used in
		/// <c>IPropertyStorage</c> and <c>IDispatch</c>, the property sets are not identical. Persistent property data types used in
		/// <c>IPropertyStorage</c> methods are defined in the PROPVARIANT structure.
		/// </para>
		/// <para>
		/// The <c>IPropertyStorage</c> interface can be used to access both simple and nonsimple property sets. Nonsimple property sets can
		/// hold several complex property types that cannot be held in a simple property set. For more information see Storage and Stream
		/// Objects for a Property Set.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nn-propidl-ipropertystorage
		[PInvokeData("propidl.h", MSDNShortId = "c021f695-db54-4861-9f30-35a81d2dccd5")]
		[ComImport, Guid("00000138-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IPropertyStorage
		{
			/// <summary>
			/// <para>The <c>ReadMultiple</c> method reads specified properties from the current property set.</para>
			/// </summary>
			/// <param name="cpspec">
			/// <para>
			/// The numeric count of properties to be specified in the array. The value of this parameter can be set to zero; however, that
			/// defeats the purpose of the method as no properties are thereby read, regardless of the values set in .
			/// </para>
			/// </param>
			/// <param name="rgpspec">
			/// <para>
			/// An array of PROPSPEC structures specifies which properties are read. Properties can be specified either by a property ID or
			/// by an optional string name. It is not necessary to specify properties in any particular order in the array. The array can
			/// contain duplicate properties, resulting in duplicate property values on return for simple properties. Nonsimple properties
			/// should return access denied on an attempt to open them a second time. The array can contain a mixture of property IDs and
			/// string IDs.
			/// </para>
			/// </param>
			/// <param name="rgpropvar">
			/// <para>
			/// Caller-allocated array of a PROPVARIANT structure that, on return, contains the values of the properties specified by the
			/// corresponding elements in the array. The array must be at least large enough to hold values of the parameter of the
			/// <c>PROPVARIANT</c> structure. The parameter specifies the number of properties set in the array. The caller is not required
			/// to initialize these <c>PROPVARIANT</c> structure values in any specific order. However, the implementation must fill all
			/// members correctly on return. If there is no other appropriate value, the implementation must set the <c>vt</c> member of each
			/// <c>PROPVARIANT</c> structure to <c>VT_EMPTY</c>.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>This method supports the standard return value <c>E_UNEXPECTED</c>, as well as the following:</para>
			/// <para>
			/// This function can also return any file system errors or Win32 errors wrapped in an <c>HRESULT</c> data type. For more
			/// information, see Error Handling Strategies.
			/// </para>
			/// <para>For more information, see Property Storage Considerations.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-readmultiple
			[PreserveSig]
			HRESULT ReadMultiple(uint cpspec, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PROPSPEC[] rgpspec, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PROPVARIANT[] rgpropvar);

			/// <summary>
			/// <para>
			/// The <c>WriteMultiple</c> method writes a specified group of properties to the current property set. If a property with a
			/// specified name or property identifier already exists, it is replaced, even when the old and new types for the property value
			/// are different. If a property of a given name or property ID does not exist, it is created.
			/// </para>
			/// </summary>
			/// <param name="cpspec">
			/// <para>
			/// The number of properties set. The value of this parameter can be set to zero; however, this defeats the purpose of the method
			/// as no properties are then written.
			/// </para>
			/// </param>
			/// <param name="rgpspec">
			/// <para>
			/// An array of the property IDs (PROPSPEC) to which properties are set. These need not be in any particular order, and may
			/// contain duplicates, however the last specified property ID is the one that takes effect. A mixture of property IDs and string
			/// names is permitted.
			/// </para>
			/// </param>
			/// <param name="rgpropvar">
			/// <para>
			/// An array (of size ) of PROPVARIANT structures that contain the property values to be written. The array must be the size
			/// specified by .
			/// </para>
			/// </param>
			/// <param name="propidNameFirst">
			/// <para>
			/// The minimum value for the property IDs that the method must assign if the parameter specifies string-named properties for
			/// which no property IDs currently exist. If all string-named properties specified already exist in this set, and thus already
			/// have property IDs, this value is ignored. When not ignored, this value must be greater than, or equal to, two and less than
			/// 0x80000000. Property IDs 0 and 1 and greater than 0x80000000 are reserved for special use.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
			/// <para>
			/// This function can also return any file system errors or Win32 errors wrapped in an <c>HRESULT</c> data type. For more
			/// information, see Error Handling Strategies.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// If a specified property already exists, its value is replaced with the one specified in , even when the old and new types for
			/// the property value are different. If the specified property does not already exist, that property is created. The changes are
			/// not persisted to the underlying storage until IPropertyStorage::Commit has been called.
			/// </para>
			/// <para>
			/// Property names are stored in a special dictionary section of the property set, which maps such names to property IDs. All
			/// properties have an ID, but names are optional. A string name is supplied by specifying PRSPEC_LPWSTR in the <c>ulKind</c>
			/// member of the PROPSPEC structure. If a string name is supplied for a property, and the name does not already exist in the
			/// dictionary, the method will allocate a property ID, and add the property ID and the name to the dictionary. The property ID
			/// is allocated in such a way that it does not conflict with other IDs in the property set. The value of the property ID also is
			/// no less than the value specified by the parameter. If the parameter specifies string-named properties for which no property
			/// IDs currently exist, the parameter specifies the minimum value for the property IDs that the <c>WriteMultiple</c> method must assign.
			/// </para>
			/// <para>
			/// When a new property set is created, the special <c>codepage (</c> Property ID 1 <c>)</c> and <c>Locale ID (</c> Property ID
			/// 0x80000000 <c>)</c> properties are written to the property set automatically. These properties can subsequently be read,
			/// using the IPropertyStorage::ReadMultiple method, by specifying property IDs with the header-defined PID_CODEPAGE and
			/// PID_LOCALE values, respectively. If a property set is non-empty — has one or more properties in addition to the
			/// <c>codepage</c> and <c>Locale ID</c> properties or has one or more names in its dictionary — the special <c>codepage</c> and
			/// <c>Locale ID</c> properties cannot be modified by calling <c>IPropertyStorage::WriteMultiple</c>. However, if the property
			/// set is empty, one or both of these special properties can be modified.
			/// </para>
			/// <para>
			/// If an element in the array is set with a PRSPEC_PROPID value of 0xffffffff (PID_ILLEGAL), the corresponding value in the
			/// array is ignored by <c>IPropertyStorage::WriteMultiple</c>. For example, if this method is called with the parameter set to
			/// 3, but is set to PRSPEC_PROPID and is set to PID_ILLEGAL, only two properties will be written. The element is silently ignored.
			/// </para>
			/// <para>Use the PropVariantInit macro to initialize PROPVARIANT structures.</para>
			/// <para>
			/// Property sets, not including the data for nonsimple properties, are limited to 256 KB in size for Windows NT 4.0 and earlier.
			/// For Windows 2000, Windows XP and Windows Server 2003, OLE property sets are limited to 1 MB. If these limits are exceeded,
			/// the operation fails and the caller receives an error message. There is no possibility of a memory leak or overrun. For more
			/// information, see Managing Property Sets.
			/// </para>
			/// <para>
			/// Unless PROPSETFLAG_CASE_SENSITIVE is passed to IPropertySetStorage::Create, property set names are case insensitive.
			/// Specifying a property by its name in <c>IPropertyStorage::WriteMultiple</c> will result in a case-insensitive search of the
			/// names in the property set. To compare case-insensitive strings, the locale of the strings must be known. For more
			/// information, see IPropertyStorage::WritePropertyNames.
			/// </para>
			/// <para>For more information, see Property Storage Considerations.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-writemultiple
			[PreserveSig]
			HRESULT WriteMultiple(uint cpspec, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PROPSPEC[] rgpspec, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PROPVARIANT[] rgpropvar, uint propidNameFirst);

			/// <summary>
			/// <para>The <c>DeleteMultiple</c> method deletes as many of the indicated properties as exist in this property set.</para>
			/// </summary>
			/// <param name="cpspec">
			/// <para>
			/// The numerical count of properties to be deleted. The value of this parameter can legally be set to zero, however that defeats
			/// the purpose of the method as no properties are thereby deleted, regardless of the value set in .
			/// </para>
			/// </param>
			/// <param name="rgpspec">
			/// <para>
			/// Properties to be deleted. A mixture of property identifiers and string-named properties is permitted. There may be
			/// duplicates, and there is no requirement that properties be specified in any order.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>IPropertyStorage::DeleteMultiple</c> must delete as many of the indicated properties as are in the current property set.
			/// If a deletion of a stream- or storage-valued property occurs while that property is open, the deletion will succeed and place
			/// the previously returned IStream or IStorage pointer in the reverted state.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-deletemultiple
			[PreserveSig]
			HRESULT DeleteMultiple(uint cpspec, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PROPSPEC[] rgpspec);

			/// <summary>
			/// <para>The <c>ReadPropertyNames</c> method retrieves any existing string names for the specified property IDs.</para>
			/// </summary>
			/// <param name="cpropid">
			/// <para>
			/// The number of elements on input of the array . The value of this parameter can be set to zero, however that defeats the
			/// purpose of this method as no property names are thereby read.
			/// </para>
			/// </param>
			/// <param name="rgpropid">
			/// <para>An array of property IDs for which names are to be retrieved.</para>
			/// </param>
			/// <param name="rglpwstrName">
			/// <para>
			/// A caller-allocated array of size of <c>LPWSTR</c> members. On return, the implementation fills in this array. A given entry
			/// contains either the corresponding string name of a property ID or it can be empty if the property ID has no string names.
			/// </para>
			/// <para>Each <c>LPWSTR</c> member of the array should be freed using the CoTaskMemFree function.</para>
			/// </param>
			/// <returns>
			/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// For each property ID in the list of property IDs supplied in the array, <c>ReadPropertyNames</c> retrieves the corresponding
			/// string name, if there is one. String names are created either by specifying the names in calls to
			/// IPropertyStorage::WriteMultiple when creating the property, or through a call to IPropertyStorage::WritePropertyNames. In
			/// either case, the string name is optional, however all properties must have a property ID.
			/// </para>
			/// <para>String names mapped to property IDs must be unique within the set.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-readpropertynames
			[PreserveSig]
			HRESULT ReadPropertyNames(uint cpropid, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] rgpropid, [In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] string[] rglpwstrName);

			/// <summary>
			/// <para>
			/// The <c>WritePropertyNames</c> method assigns string IPropertyStoragenames to a specified array of property IDs in the current
			/// property set.
			/// </para>
			/// </summary>
			/// <param name="cpropid">
			/// <para>The size on input of the array . Can be zero. However, making it zero causes this method to become non-operational.</para>
			/// </param>
			/// <param name="rgpropid">
			/// <para>An array of the property IDs for which names are to be set.</para>
			/// </param>
			/// <param name="rglpwstrName">
			/// <para>
			/// An array of new names to be assigned to the corresponding property IDs in the array. These names may not exceed 255
			/// characters (not including the <c>NULL</c> terminator).
			/// </para>
			/// </param>
			/// <returns>
			/// <para>This method supports the standard return value <c>E_UNEXPECTED</c>, in addition to the following:</para>
			/// </returns>
			/// <remarks>
			/// <para>For more information about property sets and memory management, see Managing Property Sets.</para>
			/// <para>
			/// <c>IPropertyStorage::WritePropertyNames</c> assigns string names to property IDs passed to the method in the array. It
			/// associates each string name in the array with the respective property ID in . It is explicitly valid to define a name for a
			/// property ID that is not currently present in the property storage object.
			/// </para>
			/// <para>
			/// It is also valid to change the mapping for an existing string name (determined by a case-insensitive match). That is, you can
			/// use the <c>WritePropertyNames</c> method to map an existing name to a new property ID, or to map a new name to a property ID
			/// that already has a name in the dictionary. In either case, the original mapping is deleted. Property names must be unique (as
			/// are property IDs) within the property set.
			/// </para>
			/// <para>
			/// The storage of string property names preserves the case. Unless <c>PROPSETFLAG_CASE_SENSITIVE</c> is passed to
			/// IPropertySetStorage::Create, property set names are case insensitive by default. With case-insensitive property sets, the
			/// name strings passed by the caller are interpreted according to the locale of the property set, as specified by the
			/// <c>PID_LOCALE</c> property. If the property set has no locale property, the current user is assumed by default. String
			/// property names are limited in length to 128 characters. Property names that begin with the binary Unicode characters 0x0001
			/// through 0x001F are reserved for future use.
			/// </para>
			/// <para>
			/// If the value of an element in the array parameter is set to 0xffffffff (PID_ILLEGAL), the corresponding name is ignored by
			/// <c>IPropertyStorage::WritePropertyNames</c>. For example, if this method is called with a parameter of 3, but the first
			/// element of the array, , is set to <c>PID_ILLEGAL</c>, then only two property names are written. The element is ignored.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-writepropertynames
			[PreserveSig]
			HRESULT WritePropertyNames(uint cpropid, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] rgpropid, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] string[] rglpwstrName);

			/// <summary>
			/// <para>The <c>DeletePropertyNames</c> method deletes specified string names from the current property set.</para>
			/// </summary>
			/// <param name="cpropid">
			/// <para>The size on input of the array . If 0, no property names are deleted.</para>
			/// </param>
			/// <param name="rgpropid">
			/// <para>Property identifiers for which string names are to be deleted.</para>
			/// </param>
			/// <returns>
			/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// For each property identifier in , <c>IPropertyStorage::DeletePropertyNames</c> removes any corresponding name-to-property ID
			/// mapping. An attempt is silently ignored to delete the name of a property that either does not exist or does not currently
			/// have a string name associated with it. This method has no effect on the properties themselves.
			/// </para>
			/// <para>
			/// <c>Note</c> All the stored string property names can be deleted by deleting property identifier zero, but must be equal to 1
			/// for this to be a valid parameter error.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-deletepropertynames
			[PreserveSig]
			HRESULT DeletePropertyNames(uint cpropid, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] rgpropid);

			/// <summary>
			/// <para>The <c>IPropertyStorage::Commit</c> method saves changes made to a property storage object to the parent storage object.</para>
			/// </summary>
			/// <param name="grfCommitFlags">
			/// <para>
			/// The flags that specify the conditions under which the commit is to be performed. For more information about specific flags
			/// and their meanings, see the Remarks section.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>This method supports the standard return value E_UNEXPECTED, as well as the following:</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Like IStorage::Commit, the <c>IPropertyStorage::Commit</c> method ensures that any changes made to a property storage object
			/// are reflected in the parent storage.
			/// </para>
			/// <para>
			/// In direct mode in the compound file implementation, a call to this method causes any changes currently in the memory buffers
			/// to be flushed to the underlying property stream. In the compound-file implementation for nonsimple property sets,
			/// IStorage::Commit is also called on the underlying substorage object with the passed parameter.
			/// </para>
			/// <para>
			/// In transacted mode, this method causes the changes to be permanently reflected in the persistent image of the storage object.
			/// The changes that are committed must have been made to this property set since it was opened or since the last commit on this
			/// opening of the property set. The <c>commit</c> method publishes the changes made on one object level to the next level. Of
			/// course, this remains subject to any outer-level transaction that may be present on the object in which this property set is
			/// contained. Write permission must be specified when the property set is opened (through IPropertySetStorage) on the property
			/// set opening for the commit operation to succeed.
			/// </para>
			/// <para>
			/// If the commit operation fails for any reason, the state of the property storage object remains as it was before the commit.
			/// </para>
			/// <para>
			/// This call has no effect on existing storage- or stream-valued properties opened from this property storage, but it does
			/// commit them.
			/// </para>
			/// <para>Valid values for the parameter are listed in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>STGC_DEFAULT</term>
			/// <term>Commits per the usual transaction semantics. Last writer wins. This flag may not be specified with other flag values.</term>
			/// </item>
			/// <item>
			/// <term>STGC_ONLYIFCURRENT</term>
			/// <term>
			/// Commits the changes only if the current persistent contents of the property set are the ones on which the changes about to be
			/// committed are based. That is, does not commit changes if the contents of the property set have been changed by a commit from
			/// another opening of the property set. The error STG_E_NOTCURRENT is returned if the commit does not succeed for this reason.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STGC_OVERWRITE</term>
			/// <term>
			/// Useful only when committing a transaction that has no further outer nesting level of transactions, though acceptable in all cases.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// <c>Note</c> Using <c>IPropertyStorage::Commit</c> to write properties to image files on Windows XP does not work. Affected
			/// image file formats include:Due to a bug in the image file property handler on Windows XP, calling
			/// <c>IPropertyStorage::Commit</c> actually discards any changes made rather than persisting them.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-commit
			[PreserveSig]
			HRESULT Commit(uint grfCommitFlags);

			/// <summary>
			/// <para>
			/// The <c>Revert</c> method discards all changes to the named property set since it was last opened or discards changes that
			/// were last committed to the property set. This method has no effect on a direct-mode property set.
			/// </para>
			/// </summary>
			/// <returns>
			/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// For transacted-mode property sets, this method discards all changes that have been made in this property set since the set
			/// was opened or since the time it was last committed, (whichever is later). After this operation, any existing storage- or
			/// stream-valued properties that have been opened from the property set being reverted are no longer valid and cannot be used.
			/// The error STG_E_REVERTED will be returned on all calls, except those to <c>Release</c>, using these streams or storages.
			/// </para>
			/// <para>For direct-mode property sets, this request is ignored and returns S_OK.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-revert
			[PreserveSig]
			HRESULT Revert();

			/// <summary>
			/// <para>
			/// The <c>Enum</c> method creates an enumerator object designed to enumerate data of type STATPROPSTG, which contains
			/// information on the current property set. On return, this method supplies a pointer to the IEnumSTATPROPSTG pointer on this object.
			/// </para>
			/// </summary>
			/// <param name="ppenum">
			/// <para>Pointer to IEnumSTATPROPSTG pointer variable that receives the interface pointer to the new enumerator object.</para>
			/// </param>
			/// <returns>
			/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>IPropertyStorage::Enum</c> creates an enumeration object that can be used to iterate STATPROPSTG structures. On return,
			/// this method supplies a pointer to an instance of the IEnumSTATPROPSTG interface on this object, whose methods you can call to
			/// obtain information about the current property set.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-enum
			[PreserveSig]
			HRESULT Enum(out IEnumSTATPROPSTG ppenum);

			/// <summary>
			/// <para>
			/// The <c>SetTimes</c> method sets the modification, access, and creation times of this property set, if supported by the
			/// implementation. Not all implementations support all these time values.
			/// </para>
			/// </summary>
			/// <param name="pctime">
			/// <para>
			/// Pointer to the new creation time for the property set. May be <c>NULL</c>, indicating that this time is not to be modified by
			/// this call.
			/// </para>
			/// </param>
			/// <param name="patime">
			/// <para>
			/// Pointer to the new access time for the property set. May be <c>NULL</c>, indicating that this time is not to be modified by
			/// this call.
			/// </para>
			/// </param>
			/// <param name="pmtime">
			/// <para>
			/// Pointer to the new modification time for the property set. May be <c>NULL</c>, indicating that this time is not to be
			/// modified by this call.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Sets the modification, access, and creation times of the current open property set, if supported by the implementation (not
			/// all implementations support all these time values). Unsupported time stamps are always reported as zero, enabling the caller
			/// to test for support. A call to IPropertyStorage::Stat supplies (among other data) time-stamp information.
			/// </para>
			/// <para>
			/// Notice that this functionality is provided as an IPropertyStorage method on a property-storage object that is already open,
			/// in contrast to being provided as a method in IPropertySetStorage. Normally, when the <c>SetTimes</c> method is not explicitly
			/// called, the access and modification times are updated as a side effect of reading and writing the property set. When
			/// <c>SetTimes</c> is used, the latest specified times supersede either default times or time values specified in previous calls
			/// to <c>SetTimes</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-settimes
			[PreserveSig]
			HRESULT SetTimes(in FILETIME pctime, in FILETIME patime, in FILETIME pmtime);

			/// <summary>
			/// <para>
			/// The <c>SetClass</c> method assigns a new CLSID to the current property storage object, and persistently stores the CLSID with
			/// the object.
			/// </para>
			/// </summary>
			/// <param name="clsid">
			/// <para>New CLSID to be associated with the property set.</para>
			/// </param>
			/// <returns>
			/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Assigns a CLSID to the current property storage object. The CLSID has no relationship to the stored property IDs. Assigning a
			/// CLSID allows a piece of code to be associated with a given instance of a property set; such code, for example, might manage
			/// the user interface (UI). Different CLSIDs can be associated with different property set instances that have the same FMTID.
			/// </para>
			/// <para>
			/// If the property set is created with the parameter of the IPropertySetStorage::Create method specified as <c>NULL</c>, the
			/// CLSID is set to all zeroes.
			/// </para>
			/// <para>
			/// The current CLSID on a property storage object can be retrieved with a call to IPropertyStorage::Stat. The initial value for
			/// the CLSID can be specified at the time that the storage is created with a call to IPropertySetStorage::Create.
			/// </para>
			/// <para>
			/// Setting the CLSID on a nonsimple property set (one that can legally contain storage- or stream-valued properties, as
			/// described in IPropertySetStorage::Create) also sets the CLSID on the underlying sub-storage.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-setclass
			[PreserveSig]
			HRESULT SetClass(in Guid clsid);

			/// <summary>
			/// <para>The <c>Stat</c> method retrieves information about the current open property set.</para>
			/// </summary>
			/// <param name="pstatpsstg">
			/// <para>Pointer to a STATPROPSETSTG structure, which contains statistics about the current open property set.</para>
			/// </param>
			/// <returns>
			/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>IPropertyStorage::Stat</c> fills in and returns a pointer to a STATPROPSETSTG structure, containing statistics about the
			/// current property set.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-stat
			[PreserveSig]
			HRESULT Stat(out STATPROPSETSTG pstatpsstg);
		}

		/// <summary>
		/// The PropVariantClear function frees all elements that can be freed in a given PROPVARIANT structure. For complex elements with
		/// known element pointers, the underlying elements are freed prior to freeing the containing element.
		/// </summary>
		/// <param name="pvar">
		/// A pointer to an initialized PROPVARIANT structure for which any deallocatable elements are to be freed. On return, all zeroes are
		/// written to the PROPVARIANT structure.
		/// </param>
		/// <returns>
		/// <list type="definition">
		/// <item>
		/// <term>S_OK</term>
		/// <definition>The VT types are recognized and all items that can be freed have been freed.</definition>
		/// </item>
		/// <item>
		/// <term>STG_E_INVALID_PARAMETER</term>
		/// <definition>The variant has an unknown VT type.</definition>
		/// </item>
		/// </list>
		/// </returns>
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Propidl.h", MSDNShortId = "aa380073")]
		public static extern HRESULT PropVariantClear([In, Out] PROPVARIANT pvar);

		/// <summary>The PropVariantCopy function copies the contents of one PROPVARIANT structure to another.</summary>
		/// <param name="pDst">Pointer to an uninitialized PROPVARIANT structure that receives the copy.</param>
		/// <param name="pSrc">Pointer to the PROPVARIANT structure to be copied.</param>
		/// <returns>
		/// <list type="definition">
		/// <item>
		/// <term>S_OK</term>
		/// <definition>The VT types are recognized and all items that can be freed have been freed.</definition>
		/// </item>
		/// <item>
		/// <term>STG_E_INVALID_PARAMETER</term>
		/// <definition>The variant has an unknown VT type.</definition>
		/// </item>
		/// </list>
		/// </returns>
		[DllImport(Lib.Ole32, ExactSpelling = true)]
		[PInvokeData("Propidl.h", MSDNShortId = "aa380192")]
		public static extern HRESULT PropVariantCopy([In, Out] PROPVARIANT pDst, [In] PROPVARIANT pSrc);

		/// <summary>
		/// <para>
		/// The <c>PROPSPEC</c> structure is used by many of the methods of IPropertyStorage to specify a property either by its property
		/// identifier (ID) or the associated string name.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// String names are optional and can be assigned to a set of properties when the property is created with a call to
		/// IPropertyStorage::WriteMultiple or later with a call to IPropertyStorage::WritePropertyNames.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/ns-propidl-tagpropspec typedef struct tagPROPSPEC { ULONG ulKind;
		// union { PROPID propid; LPOLESTR lpwstr; } DUMMYUNIONNAME; } PROPSPEC;
		[PInvokeData("propidl.h", MSDNShortId = "5bb3b9c6-ab82-498c-94f9-13a9ffa7452b")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct PROPSPEC
		{
			/// <summary>
			/// <para>Indicates the union member used. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PRSPEC_LPWSTR Value: 0</term>
			/// <term>The lpwstr member is used and set to a string name.</term>
			/// </item>
			/// <item>
			/// <term>PRSPEC_PROPID Value: 1</term>
			/// <term>The propid member is used and set to a property ID value.</term>
			/// </item>
			/// </list>
			/// </summary>
			public PRSPEC ulKind;

			/// <summary>PROPSPECunion</summary>
			public PROPSPECunion union;

			/// <summary>PROPSPECunion</summary>
			[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
			public struct PROPSPECunion
			{
				/// <summary>
				/// <para>Specifies the value of the property ID. Use either this value or the following <c>lpwstr</c>, not both.</para>
				/// </summary>
				[FieldOffset(0)]
				public uint propid;

				/// <summary>
				/// <para>Specifies the string name of the property as a null-terminated Unicode string.</para>
				/// </summary>
				[FieldOffset(0)]
				public StrPtrUni lpwstr;
			}
		}

		/// <summary>
		/// <para>
		/// The <c>STATPROPSETSTG</c> structure contains information about a property set. To get this information, call
		/// IPropertyStorage::Stat, which fills in a buffer containing the information describing the current property set. To enumerate the
		/// <c>STATPROPSETSTG</c> structures for the property sets in the current property-set storage, call IPropertySetStorage::Enum to get
		/// a pointer to an enumerator. You can then call the enumeration methods of the IEnumSTATPROPSETSTG interface on the enumerator. The
		/// structure is defined as follows:
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/ns-propidl-tagstatpropsetstg typedef struct tagSTATPROPSETSTG { FMTID
		// fmtid; CLSID clsid; DWORD grfFlags; FILETIME mtime; FILETIME ctime; FILETIME atime; DWORD dwOSVersion; } STATPROPSETSTG;
		[PInvokeData("propidl.h", MSDNShortId = "8e5cc502-9f96-4f4b-8729-cac4a1ffcd6f")]
		[StructLayout(LayoutKind.Sequential)]
		public struct STATPROPSETSTG
		{
			/// <summary>
			/// <para>FMTID of the current property set, specified when the property set was initially created.</para>
			/// </summary>
			public Guid fmtid;

			/// <summary>
			/// <para>
			/// <c>CLSID</c> associated with this property set, specified when the property set was initially created and possibly modified
			/// thereafter with IPropertyStorage::SetClass. If not set, the value will be <c>CLSID_NULL</c>.
			/// </para>
			/// </summary>
			public Guid clsid;

			/// <summary>
			/// <para>Flag values of the property set, as specified in IPropertySetStorage::Create.</para>
			/// </summary>
			public uint grfFlags;

			/// <summary>
			/// <para>Time in Universal Coordinated Time (UTC) when the property set was last modified.</para>
			/// </summary>
			public FILETIME mtime;

			/// <summary>
			/// <para>Time in UTC when this property set was created.</para>
			/// </summary>
			public FILETIME ctime;

			/// <summary>
			/// <para>Time in UTC when this property set was last accessed.</para>
			/// </summary>
			public FILETIME atime;

			/// <summary>The OS version.</summary>
			public uint dwOSVersion;
		}

		/// <summary>
		/// <para>
		/// The <c>STATPROPSTG</c> structure contains data about a single property in a property set. This data is the property ID and type
		/// tag, and the optional string name that may be associated with the property.
		/// </para>
		/// <para>
		/// IPropertyStorage::Enum supplies a pointer to the IEnumSTATPROPSTG interface on an enumerator object that can be used to enumerate
		/// the <c>STATPROPSTG</c> structures for the properties in the current property set. <c>STATPROPSTG</c> is defined as:
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/ns-propidl-tagstatpropstg typedef struct tagSTATPROPSTG { LPOLESTR
		// lpwstrName; PROPID propid; VARTYPE vt; } STATPROPSTG;
		[PInvokeData("propidl.h", MSDNShortId = "3b8de6d3-18a3-4c0a-94d1-04bcec05d41a")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct STATPROPSTG
		{
			/// <summary>
			/// <para>
			/// A wide-character null-terminated Unicode string that contains the optional string name associated with the property. May be
			/// <c>NULL</c>. This member must be freed using CoTaskMemFree.
			/// </para>
			/// </summary>
			public string lpwstrName;

			/// <summary>
			/// <para>
			/// A 32-bit identifier that uniquely identifies the property within the property set. All properties within property sets must
			/// have unique property identifiers.
			/// </para>
			/// </summary>
			public uint propid;

			/// <summary>
			/// <para>The property type.</para>
			/// </summary>
			public VARTYPE vt;
		}
	}
}