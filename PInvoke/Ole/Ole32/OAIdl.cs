using System;
using System.Runtime.InteropServices;
using EXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
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
			/// This allows efficient persistence operations for Binary Large Object (BLOB) properties, such as a picture, where the owner of
			/// the property bag tells the picture object (which is managed as a property in the control that is saved) to save to a specific
			/// location. This avoids potential extra copy operations that might be involved with other property-based persistence mechanisms.
			/// </para>
			/// </remarks>
			void Write([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropName, in object pVar);
		}

		/// <summary>
		/// Describes the structure of a particular UDT. You can use IRecordInfo any time you need to access the description of UDTs
		/// contained in type libraries. IRecordInfo can be reused as needed; there can be many instances of the UDT for a single IRecordInfo pointer.
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
			/// If INVOKE_PROPERTYPUT is passed in then specific rules apply. If the field is declared as a class that derives from IDispatch
			/// and the field's value is NULL then an error will be returned. If the field's value is not NULL then the variant will be
			/// passed to the default property supported by the object referenced by the field. If the field is not declared as a class
			/// derived from <c>IDispatch</c> then an error will be returned. If the field is declared as a variant of type VT_Dispatch then
			/// the default value of the object is assigned to the field. Otherwise, the variant's value is assigned to the field.
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
			/// Passes ownership of the data to the assigned field by placing the actual data into the field. <c>PutFieldNoCopy</c> is useful
			/// for saving resources because it allows you to place your data directly into a record field. <c>PutFieldNoCopy</c> differs
			/// from PutField because it does not copy the data referenced by the variant.
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
			/// It the rgBstrNames parameter is not NULL, then the string names contained in rgBstrNames are returned. If the number of names
			/// in pcNames and rgBstrNames are not equal then the lesser number of the two is the number of returned field names. The caller
			/// needs to free the BSTRs inside the array returned in rgBstrNames.
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
	}
}