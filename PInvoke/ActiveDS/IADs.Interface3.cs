using System.Reflection;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke;

public static partial class ActiveDS
{
	/// <summary>
	/// <para>
	/// The <c>IADsPrintJobOperations</c> interface is a dual interface that inherits from IADs. It is used to control a print job across a
	/// network. A print job object that implements the IADsPrintJob interface will also support the following features for this interface:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>To examine the operational status and other information.</description>
	/// </item>
	/// <item>
	/// <description>To interrupt a running print job.</description>
	/// </item>
	/// <item>
	/// <description>To resume a paused print job.</description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsprintjoboperations
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsPrintJobOperations")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("9A52DB30-1ECF-11CF-A988-00AA006BC149")]
	public interface IADsPrintJobOperations : IADs
	{
		/// <summary>
		/// The relative name of the object as named within the underlying directory service. This name distinguishes this object from its siblings.
		/// </summary>
		/// <value>The relative name of the object as named within the underlying directory service.</value>
		[DispId(2)]
		new string Name
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The name of the object Schema class.</summary>
		/// <value>The name of the object Schema class.</value>
		[DispId(3)]
		new string Class
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The globally unique identifier of the directory object. The IADs interface converts the GUID from an octet string, as stored on a
		/// directory server, into a string format.
		/// </summary>
		/// <value>The globally unique identifier of the directory object.</value>
		/// <remarks>
		/// <para>
		/// In Active Directory, the GUID returned from GUID is a string of hexadecimals. Use the resultant GUID to bind to the object directly.
		/// </para>
		/// <code language="vb">
		///<![CDATA[
		///Dim x As IADs
		///Set x = GetObject("LDAP://servername/<GUID=xxx>")]]>
		/// </code>
		/// <para>
		/// where xxx is the value returned from the GUID property. For more information, see Using objectGUID to Bind to an Object. Be aware
		/// that if you use a GUID to bind to an object, the ADsPath property method returns values that are different from the normal values
		/// that would be returned if you used a distinguished name (DN) to bind to the same object. For example, the following table lists
		/// the values returned when using the two different binding methods to bind to the same user object.
		/// </para>
		/// </remarks>
		[DispId(4)]
		new string GUID
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The ADsPath string of this object. The string uniquely identifies this object in a network environment. The object can always be
		/// retrieved using this path.
		/// </summary>
		/// <value>The ADsPath string of this object.</value>
		[DispId(5)]
		new string ADsPath
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The ADsPath string of the parent container. Active Directory does not permit the formation of the ADsPath of a given object by
		/// concatenating the Parent and Name properties. While this operation might work in some providers, it is not guaranteed to work for
		/// all implementations. The ADsPath is guaranteed to be valid and should always be used to retrieve an object's interface pointer.
		/// </summary>
		/// <value>The ADsPath string of the parent container.</value>
		[DispId(6)]
		new string Parent
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The ADsPath string of the Schema class object of this object.</summary>
		/// <value>The ADsPath string of the Schema class object of this object.</value>
		[DispId(7)]
		new string Schema
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The <c>IADs::GetInfo</c> method loads into the property cache values of the supported properties of this ADSI object from the
		/// underlying directory store.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>IADs::GetInfo</c> function is called to initialize or refresh the property cache. This is similar to obtaining those
		/// property values of supported properties from the underlying directory store.
		/// </para>
		/// <para>
		/// An uninitialized property cache is not necessarily empty. Call IADs::Put or IADs::PutEx to place a value into the property cache
		/// for any supported property and the cache remains uninitialized.
		/// </para>
		/// <para>
		/// An explicit call to <c>IADs::GetInfo</c> loads or reloads the entire property cache, overwriting all the cached property values.
		/// But an implicit call loads only those properties not set in the cache. Always call <c>IADs::GetInfo</c> explicitly to retrieve
		/// the most current property values of the ADSI object.
		/// </para>
		/// <para>
		/// Because an explicit call to <c>IADs::GetInfo</c> overwrites all the values in the property cache, any change made to the cache
		/// will be lost if an IADs::SetInfo was not invoked before <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>
		/// For an ADSI container object, <c>IADs::GetInfo</c> caches only the property values of the container, but not those of the child objects.
		/// </para>
		/// <para>
		/// It is important to emphasize the differences between the IADs::Get and <c>IADs::GetInfo</c> methods. The former returns values of
		/// a given property from the property cache whereas the latter loads all the supported property values into the property cache from
		/// the underlying directory store.
		/// </para>
		/// <para>The following code example illustrates the differences between the IADs::Get and <c>IADs::GetInfo</c> methods.</para>
		/// <para>
		/// For increased performance, explicitly call IADs::GetInfoEx to refresh specific properties. Also, <c>IADs::GetInfoEx</c> must be
		/// called instead of <c>IADs::GetInfo</c> if the object's operational property values have to be accessed. This function overwrites
		/// any previously cached values of the specified properties.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example uses a computer object served by the WinNT provider. The supported properties include <c>Owner</c>
		/// ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"), <c>Division</c> ("Fabrikam"),
		/// <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping 1"). The default values are shown
		/// in parentheses.
		/// </para>
		/// <para>
		/// The following code example is a client-side script that illustrates the effect of <c>IADs::GetInfo</c> method. The supported
		/// properties include <c>Owner</c> ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"),
		/// <c>Division</c> ("Fabrikam"), <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping
		/// 1"). The default values are shown in parentheses.
		/// </para>
		/// <para>The following code example highlights the effect of Get and GetInfo. For brevity, error checking is omitted.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getinfo HRESULT GetInfo();
		[DispId(8)]
		new void GetInfo();

		/// <summary>The <c>IADs::SetInfo</c> method saves the cached property values of the ADSI object to the underlying directory store.</summary>
		/// <remarks>
		/// <para>
		/// It is important to emphasize the differences between the IADs::Put and <c>IADs::SetInfo</c> methods. The former sets (or
		/// modifies) values of a given property in the property cache whereas the latter propagates the changes from the property cache into
		/// the underlying directory store. Therefore, any property value changes made by <c>IADs::Put</c> will be lost if IADs::GetInfo (or
		/// IADs::GetInfoEx) is invoked before <c>IADs::SetInfo</c> is called.
		/// </para>
		/// <para>
		/// Because <c>IADs::SetInfo</c> sends data across networks, minimize the usage of this method. This reduces the number of trips a
		/// client makes to the server. For example, you should commit all, or most, of the changes to the properties from the cache to the
		/// persistent store in one batch.
		/// </para>
		/// <para>
		/// This guideline pertains only to the relationship of <c>IADs::SetInfo</c> with the IADs::Put method, which differs from the
		/// relationship with the IADs::PutEx method.
		/// </para>
		/// <para>The following code example illustrates the recommended relation between IADs::Put and <c>IADs::SetInfo</c>.</para>
		/// <para>The following code example illustrates what is not recommended between IADs::Put and <c>IADs::SetInfo</c>.</para>
		/// <para>
		/// When used with IADs::PutEx, <c>IADs::SetInfo</c> passes the operational requests specified by control codes, such as
		/// ADS_PROPERTY_UPDATE or ADS_PROPERTY_CLEAR, to the underlying directory store.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following Visual Basic code example uses the <c>IADs::SetInfo</c> method to save the property value of a user to the
		/// underlying directory.
		/// </para>
		/// <para>
		/// The following C++ code example updates property values in the property cache and commits the change to the directory store using
		/// <c>IADs::SetInfo</c>. For brevity, error checking is omitted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-setinfo HRESULT SetInfo();
		[DispId(9)]
		new void SetInfo();

		/// <summary>
		/// The <c>IADs::Get</c> method retrieves a property of a given name from the property cache. The property can be single-valued, or
		/// multi-valued. The property value is represented as either a variant for a single-valued property or a variant array (of
		/// <c>VARIANT</c> or bytes) for a property that allows multiple values.
		/// </summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <returns>
		/// Pointer to a <c>VARIANT</c> that receives the value of the property. For a multi-valued property, <c>pvProp</c> is a variant
		/// array of <c>VARIANT</c>, unless the property is a binary type. In this latter case, <c>pvProp</c> is a variant array of bytes
		/// (VT_U1 or VT_ARRAY). For the property that refers to an object, <c>pvProp</c> is a VT_DISPATCH pointer to the object referred to.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IADs::Get</c> method requires the caller to handle the single- and multi-valued property values differently. Thus, if you
		/// know that the property of interest is either single- or multi-valued, use the <c>IADs::Get</c> method to retrieve the property
		/// value. The following code example shows how you, as a caller, can handle single- and multi-valued properties when calling this method.
		/// </para>
		/// <para>
		/// When a property is uninitialized, calling this method invokes an implicit call to the IADs::GetInfo method. This loads from the
		/// underlying directory store the values of the supported properties that have not been set in the cache. Any subsequent calls to
		/// <c>IADs::Get</c> deals with property values in the cache only. For more information about the behavior of implicit and explicit
		/// calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>
		/// You can also use IADs::GetEx to retrieve property values from the property cache. However, the values are returned as a variant
		/// array of <c>VARIANT</c> s, regardless of whether they are single-valued or multi-valued. That is, ADSI attempts to package the
		/// returned property values in consistent data formats. This saves you, as a caller, the effort of validating the data types when
		/// unsure that the returned data has single or multiple values.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example retrieves the security descriptor for an object using <c>IADs::Get</c>.</para>
		/// <para>The following code example shows how to work with property values of binary data using <c>IADs::Get</c> and IADs::Put.</para>
		/// <para>The following code example shows how to retrieve values of the optional properties of an object using <c>IADs::Get</c>.</para>
		/// <para>The following code example reads attributes with single and multiple values using <c>IADs::Get</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-get HRESULT Get( [in] BSTR bstrName, [out] VARIANT *pvProp );
		[DispId(10)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object? Get([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

		/// <summary>The <c>IADs::Put</c> method sets the values of an attribute in the ADSI attribute cache.</summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <param name="vProp">Contains a <c>VARIANT</c> that specifies the new values of the property.</param>
		/// <remarks>
		/// <para>
		/// The assignment of the new property values, performed by <c>Put</c> takes place in the property cache only. To propagate the
		/// changes to the directory store, call IADs::SetInfo on the object after calling <c>Put</c>.
		/// </para>
		/// <para>
		/// To manipulate the property values beyond a simple assignment, use <c>Put</c> to append or remove a value from an existing array
		/// of attribute values.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use the <c>IADs::Put</c> method.</para>
		/// <para>The following code example shows how to use the <c>IADs::Put</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-put HRESULT Put( [in] BSTR bstrName, [in] VARIANT vProp );
		[DispId(11)]
		new void Put([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);

		/// <summary>
		/// The <c>IADs::GetEx</c> method retrieves, from the property cache, property values of a given attribute. The returned property
		/// values can be single-valued or multi-valued. Unlike the IADs::Get method, the property values are returned as a variant array of
		/// <c>VARIANT</c>, or a variant array of bytes for binary data. A single-valued property is then represented as an array of a single element.
		/// </summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <returns>Pointer to a <c>VARIANT</c> that receives the value, or values, of the property.</returns>
		/// <remarks>
		/// <para>
		/// The IADs::Get and <c>IADs::GetEx</c> methods return a different variant structure for a single-valued property value. If the
		/// property is a string, <c>IADs::Get</c> returns a variant of string (VT_BSTR), whereas <c>IADs::GetEx</c> returns a variant array
		/// of a <c>VARIANT</c> type string with a single element. Thus, if you are not sure that a multi-valued attribute will return a
		/// single value or multiple values, use <c>IADs::GetEx</c>. As it does not require you to validate the result's data structures, you
		/// may want to use <c>IADs::GetEx</c> to retrieve a property when you are not sure whether it has single or multiple values. The
		/// following list compares the two methods.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>IADs::Get version</description>
		/// <description>IADs::GetEx version</description>
		/// </listheader>
		/// <item>
		/// <description/>
		/// <description/>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// Like the IADs::Get method, <c>IADs::GetEx</c> implicitly calls IADs::GetInfo against an uninitialized property cache. For more
		/// information about implicit and explicit calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use <c>IADs::GetEx</c> to retrieve object properties.</para>
		/// <para>The following code example shows how to retrieve values of the optional properties of an object using the IADs::Get method.</para>
		/// <para>The following code example retrieves the "homePhone" property values using <c>IADs::GetEx</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getex HRESULT GetEx( [in] BSTR bstrName, [out] VARIANT
		// *pvProp );
		[DispId(12)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object? GetEx([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

		/// <summary>
		/// The <c>IADs::PutEx</c> method modifies the values of an attribute in the ADSI attribute cache. For example, for properties that
		/// allow multiple values, you can append additional values to an existing set of values, modify the values in the set, remove
		/// specified values from the set, or delete values from the set.
		/// </summary>
		/// <param name="lnControlCode">
		/// Control code that indicates the mode of modification: Append, Replace, Remove, and Delete. For more information and a list of
		/// values, see ADS_PROPERTY_OPERATION_ENUM.
		/// </param>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <param name="vProp">
		/// Contains a <c>VARIANT</c> array that contains the new value or values of the property. A single-valued property is represented as
		/// an array with a single element. If <c>InControlCode</c> is set to <c>ADS_PROPERTY_CLEAR</c>, the value of the property specified
		/// by <c>vProp</c> is irrelevant.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>PutEx</c> is usually used to set values on multi-value attributes. Unlike the IADs::Put method, with <c>PutEx</c>, you are not
		/// required to get the attribute values before you modify them. However, because <c>PutEx</c> only makes changes to attributes
		/// values contained in the ADSI property cache, you must use IADs::SetInfo after each <c>PutEx</c> call in order to commit changes
		/// to the directory.
		/// </para>
		/// <para>
		/// <c>PutEx</c> enables you to append values to an existing set of values in a multi-value attribute using
		/// <c>ADS_PROPERTY_APPEND</c>. When you update, append, or delete values to a multi-value attribute, you must use an array.
		/// </para>
		/// <para>
		/// Active Directory does not accept duplicate values on a multi-valued attribute. If you call <c>PutEx</c> to append a duplicate
		/// value to a multi-valued attribute of an Active Directory object, the <c>PutEx</c> call succeeds, but the duplicate value is ignored.
		/// </para>
		/// <para>
		/// Similarly, if you use <c>PutEx</c> to delete one or more values from a multi-valued property of an Active Directory object, the
		/// operation succeeds, that is, it will not produce an error, even if any or all of the specified values are not set on the property.
		/// </para>
		/// <para>
		/// <c>Note</c>  The WinNT provider ignores the value passed by the <c>InControlCode</c> argument and performs the equivalent of an
		/// <c>ADS_PROPERTY_UPDATE</c> request when using <c>PutEx</c>.
		/// </para>
		/// <para></para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use the <c>IADs.PutEx</c> method.</para>
		/// <para>The following code example shows how to use the <c>IADs::PutEx</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-putex HRESULT PutEx( [in] long lnControlCode, [in] BSTR
		// bstrName, [in] VARIANT vProp );
		[DispId(13)]
		new void PutEx([In] ADS_PROPERTY_OPERATION lnControlCode, [In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);

		/// <summary>
		/// The <c>IADs::GetInfoEx</c> method loads the values of specified properties of the ADSI object from the underlying directory store
		/// into the property cache.
		/// </summary>
		/// <param name="vProperties">
		/// Array of null-terminated Unicode string entries that list the properties to load into the Active Directory property cache. Each
		/// property name must match one in this object's schema class definition.
		/// </param>
		/// <param name="lnReserved">Reserved for future use. Must be set to zero.</param>
		/// <remarks>
		/// <para>
		/// The <c>IADs::GetInfoEx</c> method overwrites any previously cached values of the specified properties with those in the directory
		/// store. Therefore, any change made to the cache will be lost if IADs::SetInfo was not invoked before the call to <c>IADs::GetInfoEx</c>.
		/// </para>
		/// <para>
		/// Use <c>IADs::GetInfoEx</c> to refresh values of the selected property in the property cache of an ADSI object. Use IADs::GetInfo
		/// to refresh all the property values.
		/// </para>
		/// <para>
		/// For an ADSI container object, <c>IADs::GetInfoEx</c> caches only the property values of the container, but not those of the child objects.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to use the <c>IADs::GetInfoEx</c> to obtain values of the selected properties, assuming that
		/// the desired property values can be found in the directory.
		/// </para>
		/// <para>
		/// The following code example shows how to use the <c>IADs::GetInfoEx</c> to obtain values of the selected properties, assuming that
		/// the desired property values can be found in the directory. For brevity, error checking has been omitted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getinfoex HRESULT GetInfoEx( [in] VARIANT vProperties, [in]
		// long lnReserved );
		[DispId(14)]
		new void GetInfoEx([In, MarshalAs(UnmanagedType.Struct)] object vProperties, [In] int lnReserved = 0);

		/// <summary>Gets the current status of the print job as indicated by one of the ADSI Print Job Status Constants values.</summary>
		/// <value>The current status of the print job as indicated by one of the ADSI Print Job Status Constants values.</value>
		[DispId(26)]
		ADS_JOB_STATUS Status
		{
			[DispId(26)]
			get;
		}

		/// <summary>Gets the number of milliseconds elapsed since the print job started.</summary>
		/// <value>The number of milliseconds elapsed since the print job started.</value>
		[DispId(27)]
		int TimeElapsed
		{
			[DispId(27)]
			get;
		}

		/// <summary>Gets the number of pages printed.</summary>
		/// <value>The number of pages printed.</value>
		[DispId(28)]
		int PagesPrinted
		{
			[DispId(28)]
			get;
		}

		/// <summary>Gets or sets the position of this print job in the print queue.</summary>
		/// <value>The position of this print job in the print queue.</value>
		[DispId(29)]
		int Position
		{
			[DispId(29)]
			get;
			[DispId(29)]
			[param: In]
			set;
		}

		/// <summary>
		/// The <c>IADsPrintJobOperations::Pause</c> method halts the processing of the current print job. Call the
		/// IADsPrintJobOperations::Resume method to continue the processing.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsprintjoboperations-pause HRESULT Pause();
		[DispId(30)]
		void Pause();

		/// <summary>
		/// The <c>IADsPrintJobOperations::Resume</c> method continues the print job halted by the IADsPrintJobOperations::Pause method.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsprintjoboperations-resume HRESULT Resume();
		[DispId(31)]
		void Resume();
	}

	/// <summary>
	/// The <c>IADsPrintQueue</c> interface represents a printer on a network. It is a dual interface that inherits from IADs. The property
	/// methods of this interface enables you to access data about a printer, for example printer model, physical location, and network address.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Use this interface to browse a collection of print jobs in the print queue. To control a printer across a network, use the
	/// IADsPrintQueueOperations interface. To obtain a collection of the print jobs, call the IADsPrintQueueOperations::PrintJobs method.
	/// </para>
	/// <para>
	/// In Windows, a printer, or a print queue, is managed by a host computer. If the path to a print queue is known, bind to it as to any
	/// other ADSI objects.
	/// </para>
	/// <para>The following Visual Basic code example shows the bind operation.</para>
	/// <para>The following C++ code example shows the bind operation.</para>
	/// <para><c>To enumerate all print queues on a given computer</c></para>
	/// <list type="number">
	/// <item>
	/// <description>Bind to the computer object.</description>
	/// </item>
	/// <item>
	/// <description>Determine if the computer contains any "PrintQueue" objects.</description>
	/// </item>
	/// <item>
	/// <description>Enumerate all the found printer objects.</description>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>The following code example enumerates printers on a given computer.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsprintqueue
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsPrintQueue")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("B15160D0-1226-11CF-A985-00AA006BC149")]
	public interface IADsPrintQueue : IADs
	{
		/// <summary>
		/// The relative name of the object as named within the underlying directory service. This name distinguishes this object from its siblings.
		/// </summary>
		/// <value>The relative name of the object as named within the underlying directory service.</value>
		[DispId(2)]
		new string Name
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The name of the object Schema class.</summary>
		/// <value>The name of the object Schema class.</value>
		[DispId(3)]
		new string Class
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The globally unique identifier of the directory object. The IADs interface converts the GUID from an octet string, as stored on a
		/// directory server, into a string format.
		/// </summary>
		/// <value>The globally unique identifier of the directory object.</value>
		/// <remarks>
		/// <para>
		/// In Active Directory, the GUID returned from GUID is a string of hexadecimals. Use the resultant GUID to bind to the object directly.
		/// </para>
		/// <code language="vb">
		///<![CDATA[
		///Dim x As IADs
		///Set x = GetObject("LDAP://servername/<GUID=xxx>")]]>
		/// </code>
		/// <para>
		/// where xxx is the value returned from the GUID property. For more information, see Using objectGUID to Bind to an Object. Be aware
		/// that if you use a GUID to bind to an object, the ADsPath property method returns values that are different from the normal values
		/// that would be returned if you used a distinguished name (DN) to bind to the same object. For example, the following table lists
		/// the values returned when using the two different binding methods to bind to the same user object.
		/// </para>
		/// </remarks>
		[DispId(4)]
		new string GUID
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The ADsPath string of this object. The string uniquely identifies this object in a network environment. The object can always be
		/// retrieved using this path.
		/// </summary>
		/// <value>The ADsPath string of this object.</value>
		[DispId(5)]
		new string ADsPath
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The ADsPath string of the parent container. Active Directory does not permit the formation of the ADsPath of a given object by
		/// concatenating the Parent and Name properties. While this operation might work in some providers, it is not guaranteed to work for
		/// all implementations. The ADsPath is guaranteed to be valid and should always be used to retrieve an object's interface pointer.
		/// </summary>
		/// <value>The ADsPath string of the parent container.</value>
		[DispId(6)]
		new string Parent
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The ADsPath string of the Schema class object of this object.</summary>
		/// <value>The ADsPath string of the Schema class object of this object.</value>
		[DispId(7)]
		new string Schema
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The <c>IADs::GetInfo</c> method loads into the property cache values of the supported properties of this ADSI object from the
		/// underlying directory store.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>IADs::GetInfo</c> function is called to initialize or refresh the property cache. This is similar to obtaining those
		/// property values of supported properties from the underlying directory store.
		/// </para>
		/// <para>
		/// An uninitialized property cache is not necessarily empty. Call IADs::Put or IADs::PutEx to place a value into the property cache
		/// for any supported property and the cache remains uninitialized.
		/// </para>
		/// <para>
		/// An explicit call to <c>IADs::GetInfo</c> loads or reloads the entire property cache, overwriting all the cached property values.
		/// But an implicit call loads only those properties not set in the cache. Always call <c>IADs::GetInfo</c> explicitly to retrieve
		/// the most current property values of the ADSI object.
		/// </para>
		/// <para>
		/// Because an explicit call to <c>IADs::GetInfo</c> overwrites all the values in the property cache, any change made to the cache
		/// will be lost if an IADs::SetInfo was not invoked before <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>
		/// For an ADSI container object, <c>IADs::GetInfo</c> caches only the property values of the container, but not those of the child objects.
		/// </para>
		/// <para>
		/// It is important to emphasize the differences between the IADs::Get and <c>IADs::GetInfo</c> methods. The former returns values of
		/// a given property from the property cache whereas the latter loads all the supported property values into the property cache from
		/// the underlying directory store.
		/// </para>
		/// <para>The following code example illustrates the differences between the IADs::Get and <c>IADs::GetInfo</c> methods.</para>
		/// <para>
		/// For increased performance, explicitly call IADs::GetInfoEx to refresh specific properties. Also, <c>IADs::GetInfoEx</c> must be
		/// called instead of <c>IADs::GetInfo</c> if the object's operational property values have to be accessed. This function overwrites
		/// any previously cached values of the specified properties.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example uses a computer object served by the WinNT provider. The supported properties include <c>Owner</c>
		/// ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"), <c>Division</c> ("Fabrikam"),
		/// <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping 1"). The default values are shown
		/// in parentheses.
		/// </para>
		/// <para>
		/// The following code example is a client-side script that illustrates the effect of <c>IADs::GetInfo</c> method. The supported
		/// properties include <c>Owner</c> ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"),
		/// <c>Division</c> ("Fabrikam"), <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping
		/// 1"). The default values are shown in parentheses.
		/// </para>
		/// <para>The following code example highlights the effect of Get and GetInfo. For brevity, error checking is omitted.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getinfo HRESULT GetInfo();
		[DispId(8)]
		new void GetInfo();

		/// <summary>The <c>IADs::SetInfo</c> method saves the cached property values of the ADSI object to the underlying directory store.</summary>
		/// <remarks>
		/// <para>
		/// It is important to emphasize the differences between the IADs::Put and <c>IADs::SetInfo</c> methods. The former sets (or
		/// modifies) values of a given property in the property cache whereas the latter propagates the changes from the property cache into
		/// the underlying directory store. Therefore, any property value changes made by <c>IADs::Put</c> will be lost if IADs::GetInfo (or
		/// IADs::GetInfoEx) is invoked before <c>IADs::SetInfo</c> is called.
		/// </para>
		/// <para>
		/// Because <c>IADs::SetInfo</c> sends data across networks, minimize the usage of this method. This reduces the number of trips a
		/// client makes to the server. For example, you should commit all, or most, of the changes to the properties from the cache to the
		/// persistent store in one batch.
		/// </para>
		/// <para>
		/// This guideline pertains only to the relationship of <c>IADs::SetInfo</c> with the IADs::Put method, which differs from the
		/// relationship with the IADs::PutEx method.
		/// </para>
		/// <para>The following code example illustrates the recommended relation between IADs::Put and <c>IADs::SetInfo</c>.</para>
		/// <para>The following code example illustrates what is not recommended between IADs::Put and <c>IADs::SetInfo</c>.</para>
		/// <para>
		/// When used with IADs::PutEx, <c>IADs::SetInfo</c> passes the operational requests specified by control codes, such as
		/// ADS_PROPERTY_UPDATE or ADS_PROPERTY_CLEAR, to the underlying directory store.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following Visual Basic code example uses the <c>IADs::SetInfo</c> method to save the property value of a user to the
		/// underlying directory.
		/// </para>
		/// <para>
		/// The following C++ code example updates property values in the property cache and commits the change to the directory store using
		/// <c>IADs::SetInfo</c>. For brevity, error checking is omitted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-setinfo HRESULT SetInfo();
		[DispId(9)]
		new void SetInfo();

		/// <summary>
		/// The <c>IADs::Get</c> method retrieves a property of a given name from the property cache. The property can be single-valued, or
		/// multi-valued. The property value is represented as either a variant for a single-valued property or a variant array (of
		/// <c>VARIANT</c> or bytes) for a property that allows multiple values.
		/// </summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <returns>
		/// Pointer to a <c>VARIANT</c> that receives the value of the property. For a multi-valued property, <c>pvProp</c> is a variant
		/// array of <c>VARIANT</c>, unless the property is a binary type. In this latter case, <c>pvProp</c> is a variant array of bytes
		/// (VT_U1 or VT_ARRAY). For the property that refers to an object, <c>pvProp</c> is a VT_DISPATCH pointer to the object referred to.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IADs::Get</c> method requires the caller to handle the single- and multi-valued property values differently. Thus, if you
		/// know that the property of interest is either single- or multi-valued, use the <c>IADs::Get</c> method to retrieve the property
		/// value. The following code example shows how you, as a caller, can handle single- and multi-valued properties when calling this method.
		/// </para>
		/// <para>
		/// When a property is uninitialized, calling this method invokes an implicit call to the IADs::GetInfo method. This loads from the
		/// underlying directory store the values of the supported properties that have not been set in the cache. Any subsequent calls to
		/// <c>IADs::Get</c> deals with property values in the cache only. For more information about the behavior of implicit and explicit
		/// calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>
		/// You can also use IADs::GetEx to retrieve property values from the property cache. However, the values are returned as a variant
		/// array of <c>VARIANT</c> s, regardless of whether they are single-valued or multi-valued. That is, ADSI attempts to package the
		/// returned property values in consistent data formats. This saves you, as a caller, the effort of validating the data types when
		/// unsure that the returned data has single or multiple values.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example retrieves the security descriptor for an object using <c>IADs::Get</c>.</para>
		/// <para>The following code example shows how to work with property values of binary data using <c>IADs::Get</c> and IADs::Put.</para>
		/// <para>The following code example shows how to retrieve values of the optional properties of an object using <c>IADs::Get</c>.</para>
		/// <para>The following code example reads attributes with single and multiple values using <c>IADs::Get</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-get HRESULT Get( [in] BSTR bstrName, [out] VARIANT *pvProp );
		[DispId(10)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object? Get([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

		/// <summary>The <c>IADs::Put</c> method sets the values of an attribute in the ADSI attribute cache.</summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <param name="vProp">Contains a <c>VARIANT</c> that specifies the new values of the property.</param>
		/// <remarks>
		/// <para>
		/// The assignment of the new property values, performed by <c>Put</c> takes place in the property cache only. To propagate the
		/// changes to the directory store, call IADs::SetInfo on the object after calling <c>Put</c>.
		/// </para>
		/// <para>
		/// To manipulate the property values beyond a simple assignment, use <c>Put</c> to append or remove a value from an existing array
		/// of attribute values.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use the <c>IADs::Put</c> method.</para>
		/// <para>The following code example shows how to use the <c>IADs::Put</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-put HRESULT Put( [in] BSTR bstrName, [in] VARIANT vProp );
		[DispId(11)]
		new void Put([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);

		/// <summary>
		/// The <c>IADs::GetEx</c> method retrieves, from the property cache, property values of a given attribute. The returned property
		/// values can be single-valued or multi-valued. Unlike the IADs::Get method, the property values are returned as a variant array of
		/// <c>VARIANT</c>, or a variant array of bytes for binary data. A single-valued property is then represented as an array of a single element.
		/// </summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <returns>Pointer to a <c>VARIANT</c> that receives the value, or values, of the property.</returns>
		/// <remarks>
		/// <para>
		/// The IADs::Get and <c>IADs::GetEx</c> methods return a different variant structure for a single-valued property value. If the
		/// property is a string, <c>IADs::Get</c> returns a variant of string (VT_BSTR), whereas <c>IADs::GetEx</c> returns a variant array
		/// of a <c>VARIANT</c> type string with a single element. Thus, if you are not sure that a multi-valued attribute will return a
		/// single value or multiple values, use <c>IADs::GetEx</c>. As it does not require you to validate the result's data structures, you
		/// may want to use <c>IADs::GetEx</c> to retrieve a property when you are not sure whether it has single or multiple values. The
		/// following list compares the two methods.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>IADs::Get version</description>
		/// <description>IADs::GetEx version</description>
		/// </listheader>
		/// <item>
		/// <description/>
		/// <description/>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// Like the IADs::Get method, <c>IADs::GetEx</c> implicitly calls IADs::GetInfo against an uninitialized property cache. For more
		/// information about implicit and explicit calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use <c>IADs::GetEx</c> to retrieve object properties.</para>
		/// <para>The following code example shows how to retrieve values of the optional properties of an object using the IADs::Get method.</para>
		/// <para>The following code example retrieves the "homePhone" property values using <c>IADs::GetEx</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getex HRESULT GetEx( [in] BSTR bstrName, [out] VARIANT
		// *pvProp );
		[DispId(12)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object? GetEx([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

		/// <summary>
		/// The <c>IADs::PutEx</c> method modifies the values of an attribute in the ADSI attribute cache. For example, for properties that
		/// allow multiple values, you can append additional values to an existing set of values, modify the values in the set, remove
		/// specified values from the set, or delete values from the set.
		/// </summary>
		/// <param name="lnControlCode">
		/// Control code that indicates the mode of modification: Append, Replace, Remove, and Delete. For more information and a list of
		/// values, see ADS_PROPERTY_OPERATION_ENUM.
		/// </param>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <param name="vProp">
		/// Contains a <c>VARIANT</c> array that contains the new value or values of the property. A single-valued property is represented as
		/// an array with a single element. If <c>InControlCode</c> is set to <c>ADS_PROPERTY_CLEAR</c>, the value of the property specified
		/// by <c>vProp</c> is irrelevant.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>PutEx</c> is usually used to set values on multi-value attributes. Unlike the IADs::Put method, with <c>PutEx</c>, you are not
		/// required to get the attribute values before you modify them. However, because <c>PutEx</c> only makes changes to attributes
		/// values contained in the ADSI property cache, you must use IADs::SetInfo after each <c>PutEx</c> call in order to commit changes
		/// to the directory.
		/// </para>
		/// <para>
		/// <c>PutEx</c> enables you to append values to an existing set of values in a multi-value attribute using
		/// <c>ADS_PROPERTY_APPEND</c>. When you update, append, or delete values to a multi-value attribute, you must use an array.
		/// </para>
		/// <para>
		/// Active Directory does not accept duplicate values on a multi-valued attribute. If you call <c>PutEx</c> to append a duplicate
		/// value to a multi-valued attribute of an Active Directory object, the <c>PutEx</c> call succeeds, but the duplicate value is ignored.
		/// </para>
		/// <para>
		/// Similarly, if you use <c>PutEx</c> to delete one or more values from a multi-valued property of an Active Directory object, the
		/// operation succeeds, that is, it will not produce an error, even if any or all of the specified values are not set on the property.
		/// </para>
		/// <para>
		/// <c>Note</c>  The WinNT provider ignores the value passed by the <c>InControlCode</c> argument and performs the equivalent of an
		/// <c>ADS_PROPERTY_UPDATE</c> request when using <c>PutEx</c>.
		/// </para>
		/// <para></para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use the <c>IADs.PutEx</c> method.</para>
		/// <para>The following code example shows how to use the <c>IADs::PutEx</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-putex HRESULT PutEx( [in] long lnControlCode, [in] BSTR
		// bstrName, [in] VARIANT vProp );
		[DispId(13)]
		new void PutEx([In] ADS_PROPERTY_OPERATION lnControlCode, [In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);

		/// <summary>
		/// The <c>IADs::GetInfoEx</c> method loads the values of specified properties of the ADSI object from the underlying directory store
		/// into the property cache.
		/// </summary>
		/// <param name="vProperties">
		/// Array of null-terminated Unicode string entries that list the properties to load into the Active Directory property cache. Each
		/// property name must match one in this object's schema class definition.
		/// </param>
		/// <param name="lnReserved">Reserved for future use. Must be set to zero.</param>
		/// <remarks>
		/// <para>
		/// The <c>IADs::GetInfoEx</c> method overwrites any previously cached values of the specified properties with those in the directory
		/// store. Therefore, any change made to the cache will be lost if IADs::SetInfo was not invoked before the call to <c>IADs::GetInfoEx</c>.
		/// </para>
		/// <para>
		/// Use <c>IADs::GetInfoEx</c> to refresh values of the selected property in the property cache of an ADSI object. Use IADs::GetInfo
		/// to refresh all the property values.
		/// </para>
		/// <para>
		/// For an ADSI container object, <c>IADs::GetInfoEx</c> caches only the property values of the container, but not those of the child objects.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to use the <c>IADs::GetInfoEx</c> to obtain values of the selected properties, assuming that
		/// the desired property values can be found in the directory.
		/// </para>
		/// <para>
		/// The following code example shows how to use the <c>IADs::GetInfoEx</c> to obtain values of the selected properties, assuming that
		/// the desired property values can be found in the directory. For brevity, error checking has been omitted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getinfoex HRESULT GetInfoEx( [in] VARIANT vProperties, [in]
		// long lnReserved );
		[DispId(14)]
		new void GetInfoEx([In, MarshalAs(UnmanagedType.Struct)] object vProperties, [In] int lnReserved = 0);

		/// <summary>Gets or sets the printer path.</summary>
		/// <value>The printer path.</value>
		[DispId(15)]
		string PrinterPath
		{
			[DispId(15)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(15)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the model.</summary>
		/// <value>The model.</value>
		[DispId(16)]
		string Model
		{
			[DispId(16)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(16)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the datatype.</summary>
		/// <value>The datatype.</value>
		[DispId(17)]
		string Datatype
		{
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(17)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the print processor.</summary>
		/// <value>The print processor.</value>
		[DispId(18)]
		string PrintProcessor
		{
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(18)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the description.</summary>
		/// <value>The description.</value>
		[DispId(19)]
		string Description
		{
			[DispId(19)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(19)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the location.</summary>
		/// <value>The location.</value>
		[DispId(20)]
		string Location
		{
			[DispId(20)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(20)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the start time.</summary>
		/// <value>The start time.</value>
		[DispId(21)]
		DateTime StartTime
		{
			[DispId(21)]
			get;
			[DispId(21)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the until time.</summary>
		/// <value>The until time.</value>
		[DispId(22)]
		DateTime UntilTime
		{
			[DispId(22)]
			get;
			[DispId(22)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the default job priority.</summary>
		/// <value>The default job priority.</value>
		[DispId(23)]
		int DefaultJobPriority
		{
			[DispId(23)]
			get;
			[DispId(23)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the priority.</summary>
		/// <value>The priority.</value>
		[DispId(24)]
		int Priority
		{
			[DispId(24)]
			get;
			[DispId(24)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the banner page.</summary>
		/// <value>The banner page.</value>
		[DispId(25)]
		string BannerPage
		{
			[DispId(25)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(25)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the print devices.</summary>
		/// <value>The print devices.</value>
		[DispId(26)]
		object PrintDevices
		{
			[DispId(26)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(26)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets the net addresses.</summary>
		/// <value>The net addresses.</value>
		[DispId(27)]
		object NetAddresses
		{
			[DispId(27)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(27)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}
	}

	/// <summary>
	/// <para>
	/// The <c>IADsPrintQueueOperations</c> interface is a dual interface that inherits from IADs. It is used to control a printer from
	/// across a network.
	/// </para>
	/// <para>The <c>IADsPrintQueueOperations</c> interface supports the following operations:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Retrieve all print jobs submitted to the print queue.</description>
	/// </item>
	/// <item>
	/// <description>Suspend the print queue operation.</description>
	/// </item>
	/// <item>
	/// <description>Resume the print queue operation.</description>
	/// </item>
	/// <item>
	/// <description>Remove all print jobs from the print queue.</description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsprintqueueoperations
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsPrintQueueOperations")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("124BE5C0-156E-11CF-A986-00AA006BC149")]
	public interface IADsPrintQueueOperations : IADs
	{
		/// <summary>
		/// The relative name of the object as named within the underlying directory service. This name distinguishes this object from its siblings.
		/// </summary>
		/// <value>The relative name of the object as named within the underlying directory service.</value>
		[DispId(2)]
		new string Name
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The name of the object Schema class.</summary>
		/// <value>The name of the object Schema class.</value>
		[DispId(3)]
		new string Class
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The globally unique identifier of the directory object. The IADs interface converts the GUID from an octet string, as stored on a
		/// directory server, into a string format.
		/// </summary>
		/// <value>The globally unique identifier of the directory object.</value>
		/// <remarks>
		/// <para>
		/// In Active Directory, the GUID returned from GUID is a string of hexadecimals. Use the resultant GUID to bind to the object directly.
		/// </para>
		/// <code language="vb">
		///<![CDATA[
		///Dim x As IADs
		///Set x = GetObject("LDAP://servername/<GUID=xxx>")]]>
		/// </code>
		/// <para>
		/// where xxx is the value returned from the GUID property. For more information, see Using objectGUID to Bind to an Object. Be aware
		/// that if you use a GUID to bind to an object, the ADsPath property method returns values that are different from the normal values
		/// that would be returned if you used a distinguished name (DN) to bind to the same object. For example, the following table lists
		/// the values returned when using the two different binding methods to bind to the same user object.
		/// </para>
		/// </remarks>
		[DispId(4)]
		new string GUID
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The ADsPath string of this object. The string uniquely identifies this object in a network environment. The object can always be
		/// retrieved using this path.
		/// </summary>
		/// <value>The ADsPath string of this object.</value>
		[DispId(5)]
		new string ADsPath
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The ADsPath string of the parent container. Active Directory does not permit the formation of the ADsPath of a given object by
		/// concatenating the Parent and Name properties. While this operation might work in some providers, it is not guaranteed to work for
		/// all implementations. The ADsPath is guaranteed to be valid and should always be used to retrieve an object's interface pointer.
		/// </summary>
		/// <value>The ADsPath string of the parent container.</value>
		[DispId(6)]
		new string Parent
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The ADsPath string of the Schema class object of this object.</summary>
		/// <value>The ADsPath string of the Schema class object of this object.</value>
		[DispId(7)]
		new string Schema
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The <c>IADs::GetInfo</c> method loads into the property cache values of the supported properties of this ADSI object from the
		/// underlying directory store.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>IADs::GetInfo</c> function is called to initialize or refresh the property cache. This is similar to obtaining those
		/// property values of supported properties from the underlying directory store.
		/// </para>
		/// <para>
		/// An uninitialized property cache is not necessarily empty. Call IADs::Put or IADs::PutEx to place a value into the property cache
		/// for any supported property and the cache remains uninitialized.
		/// </para>
		/// <para>
		/// An explicit call to <c>IADs::GetInfo</c> loads or reloads the entire property cache, overwriting all the cached property values.
		/// But an implicit call loads only those properties not set in the cache. Always call <c>IADs::GetInfo</c> explicitly to retrieve
		/// the most current property values of the ADSI object.
		/// </para>
		/// <para>
		/// Because an explicit call to <c>IADs::GetInfo</c> overwrites all the values in the property cache, any change made to the cache
		/// will be lost if an IADs::SetInfo was not invoked before <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>
		/// For an ADSI container object, <c>IADs::GetInfo</c> caches only the property values of the container, but not those of the child objects.
		/// </para>
		/// <para>
		/// It is important to emphasize the differences between the IADs::Get and <c>IADs::GetInfo</c> methods. The former returns values of
		/// a given property from the property cache whereas the latter loads all the supported property values into the property cache from
		/// the underlying directory store.
		/// </para>
		/// <para>The following code example illustrates the differences between the IADs::Get and <c>IADs::GetInfo</c> methods.</para>
		/// <para>
		/// For increased performance, explicitly call IADs::GetInfoEx to refresh specific properties. Also, <c>IADs::GetInfoEx</c> must be
		/// called instead of <c>IADs::GetInfo</c> if the object's operational property values have to be accessed. This function overwrites
		/// any previously cached values of the specified properties.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example uses a computer object served by the WinNT provider. The supported properties include <c>Owner</c>
		/// ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"), <c>Division</c> ("Fabrikam"),
		/// <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping 1"). The default values are shown
		/// in parentheses.
		/// </para>
		/// <para>
		/// The following code example is a client-side script that illustrates the effect of <c>IADs::GetInfo</c> method. The supported
		/// properties include <c>Owner</c> ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"),
		/// <c>Division</c> ("Fabrikam"), <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping
		/// 1"). The default values are shown in parentheses.
		/// </para>
		/// <para>The following code example highlights the effect of Get and GetInfo. For brevity, error checking is omitted.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getinfo HRESULT GetInfo();
		[DispId(8)]
		new void GetInfo();

		/// <summary>The <c>IADs::SetInfo</c> method saves the cached property values of the ADSI object to the underlying directory store.</summary>
		/// <remarks>
		/// <para>
		/// It is important to emphasize the differences between the IADs::Put and <c>IADs::SetInfo</c> methods. The former sets (or
		/// modifies) values of a given property in the property cache whereas the latter propagates the changes from the property cache into
		/// the underlying directory store. Therefore, any property value changes made by <c>IADs::Put</c> will be lost if IADs::GetInfo (or
		/// IADs::GetInfoEx) is invoked before <c>IADs::SetInfo</c> is called.
		/// </para>
		/// <para>
		/// Because <c>IADs::SetInfo</c> sends data across networks, minimize the usage of this method. This reduces the number of trips a
		/// client makes to the server. For example, you should commit all, or most, of the changes to the properties from the cache to the
		/// persistent store in one batch.
		/// </para>
		/// <para>
		/// This guideline pertains only to the relationship of <c>IADs::SetInfo</c> with the IADs::Put method, which differs from the
		/// relationship with the IADs::PutEx method.
		/// </para>
		/// <para>The following code example illustrates the recommended relation between IADs::Put and <c>IADs::SetInfo</c>.</para>
		/// <para>The following code example illustrates what is not recommended between IADs::Put and <c>IADs::SetInfo</c>.</para>
		/// <para>
		/// When used with IADs::PutEx, <c>IADs::SetInfo</c> passes the operational requests specified by control codes, such as
		/// ADS_PROPERTY_UPDATE or ADS_PROPERTY_CLEAR, to the underlying directory store.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following Visual Basic code example uses the <c>IADs::SetInfo</c> method to save the property value of a user to the
		/// underlying directory.
		/// </para>
		/// <para>
		/// The following C++ code example updates property values in the property cache and commits the change to the directory store using
		/// <c>IADs::SetInfo</c>. For brevity, error checking is omitted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-setinfo HRESULT SetInfo();
		[DispId(9)]
		new void SetInfo();

		/// <summary>
		/// The <c>IADs::Get</c> method retrieves a property of a given name from the property cache. The property can be single-valued, or
		/// multi-valued. The property value is represented as either a variant for a single-valued property or a variant array (of
		/// <c>VARIANT</c> or bytes) for a property that allows multiple values.
		/// </summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <returns>
		/// Pointer to a <c>VARIANT</c> that receives the value of the property. For a multi-valued property, <c>pvProp</c> is a variant
		/// array of <c>VARIANT</c>, unless the property is a binary type. In this latter case, <c>pvProp</c> is a variant array of bytes
		/// (VT_U1 or VT_ARRAY). For the property that refers to an object, <c>pvProp</c> is a VT_DISPATCH pointer to the object referred to.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IADs::Get</c> method requires the caller to handle the single- and multi-valued property values differently. Thus, if you
		/// know that the property of interest is either single- or multi-valued, use the <c>IADs::Get</c> method to retrieve the property
		/// value. The following code example shows how you, as a caller, can handle single- and multi-valued properties when calling this method.
		/// </para>
		/// <para>
		/// When a property is uninitialized, calling this method invokes an implicit call to the IADs::GetInfo method. This loads from the
		/// underlying directory store the values of the supported properties that have not been set in the cache. Any subsequent calls to
		/// <c>IADs::Get</c> deals with property values in the cache only. For more information about the behavior of implicit and explicit
		/// calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>
		/// You can also use IADs::GetEx to retrieve property values from the property cache. However, the values are returned as a variant
		/// array of <c>VARIANT</c> s, regardless of whether they are single-valued or multi-valued. That is, ADSI attempts to package the
		/// returned property values in consistent data formats. This saves you, as a caller, the effort of validating the data types when
		/// unsure that the returned data has single or multiple values.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example retrieves the security descriptor for an object using <c>IADs::Get</c>.</para>
		/// <para>The following code example shows how to work with property values of binary data using <c>IADs::Get</c> and IADs::Put.</para>
		/// <para>The following code example shows how to retrieve values of the optional properties of an object using <c>IADs::Get</c>.</para>
		/// <para>The following code example reads attributes with single and multiple values using <c>IADs::Get</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-get HRESULT Get( [in] BSTR bstrName, [out] VARIANT *pvProp );
		[DispId(10)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object? Get([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

		/// <summary>The <c>IADs::Put</c> method sets the values of an attribute in the ADSI attribute cache.</summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <param name="vProp">Contains a <c>VARIANT</c> that specifies the new values of the property.</param>
		/// <remarks>
		/// <para>
		/// The assignment of the new property values, performed by <c>Put</c> takes place in the property cache only. To propagate the
		/// changes to the directory store, call IADs::SetInfo on the object after calling <c>Put</c>.
		/// </para>
		/// <para>
		/// To manipulate the property values beyond a simple assignment, use <c>Put</c> to append or remove a value from an existing array
		/// of attribute values.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use the <c>IADs::Put</c> method.</para>
		/// <para>The following code example shows how to use the <c>IADs::Put</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-put HRESULT Put( [in] BSTR bstrName, [in] VARIANT vProp );
		[DispId(11)]
		new void Put([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);

		/// <summary>
		/// The <c>IADs::GetEx</c> method retrieves, from the property cache, property values of a given attribute. The returned property
		/// values can be single-valued or multi-valued. Unlike the IADs::Get method, the property values are returned as a variant array of
		/// <c>VARIANT</c>, or a variant array of bytes for binary data. A single-valued property is then represented as an array of a single element.
		/// </summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <returns>Pointer to a <c>VARIANT</c> that receives the value, or values, of the property.</returns>
		/// <remarks>
		/// <para>
		/// The IADs::Get and <c>IADs::GetEx</c> methods return a different variant structure for a single-valued property value. If the
		/// property is a string, <c>IADs::Get</c> returns a variant of string (VT_BSTR), whereas <c>IADs::GetEx</c> returns a variant array
		/// of a <c>VARIANT</c> type string with a single element. Thus, if you are not sure that a multi-valued attribute will return a
		/// single value or multiple values, use <c>IADs::GetEx</c>. As it does not require you to validate the result's data structures, you
		/// may want to use <c>IADs::GetEx</c> to retrieve a property when you are not sure whether it has single or multiple values. The
		/// following list compares the two methods.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>IADs::Get version</description>
		/// <description>IADs::GetEx version</description>
		/// </listheader>
		/// <item>
		/// <description/>
		/// <description/>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// Like the IADs::Get method, <c>IADs::GetEx</c> implicitly calls IADs::GetInfo against an uninitialized property cache. For more
		/// information about implicit and explicit calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use <c>IADs::GetEx</c> to retrieve object properties.</para>
		/// <para>The following code example shows how to retrieve values of the optional properties of an object using the IADs::Get method.</para>
		/// <para>The following code example retrieves the "homePhone" property values using <c>IADs::GetEx</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getex HRESULT GetEx( [in] BSTR bstrName, [out] VARIANT
		// *pvProp );
		[DispId(12)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object? GetEx([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

		/// <summary>
		/// The <c>IADs::PutEx</c> method modifies the values of an attribute in the ADSI attribute cache. For example, for properties that
		/// allow multiple values, you can append additional values to an existing set of values, modify the values in the set, remove
		/// specified values from the set, or delete values from the set.
		/// </summary>
		/// <param name="lnControlCode">
		/// Control code that indicates the mode of modification: Append, Replace, Remove, and Delete. For more information and a list of
		/// values, see ADS_PROPERTY_OPERATION_ENUM.
		/// </param>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <param name="vProp">
		/// Contains a <c>VARIANT</c> array that contains the new value or values of the property. A single-valued property is represented as
		/// an array with a single element. If <c>InControlCode</c> is set to <c>ADS_PROPERTY_CLEAR</c>, the value of the property specified
		/// by <c>vProp</c> is irrelevant.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>PutEx</c> is usually used to set values on multi-value attributes. Unlike the IADs::Put method, with <c>PutEx</c>, you are not
		/// required to get the attribute values before you modify them. However, because <c>PutEx</c> only makes changes to attributes
		/// values contained in the ADSI property cache, you must use IADs::SetInfo after each <c>PutEx</c> call in order to commit changes
		/// to the directory.
		/// </para>
		/// <para>
		/// <c>PutEx</c> enables you to append values to an existing set of values in a multi-value attribute using
		/// <c>ADS_PROPERTY_APPEND</c>. When you update, append, or delete values to a multi-value attribute, you must use an array.
		/// </para>
		/// <para>
		/// Active Directory does not accept duplicate values on a multi-valued attribute. If you call <c>PutEx</c> to append a duplicate
		/// value to a multi-valued attribute of an Active Directory object, the <c>PutEx</c> call succeeds, but the duplicate value is ignored.
		/// </para>
		/// <para>
		/// Similarly, if you use <c>PutEx</c> to delete one or more values from a multi-valued property of an Active Directory object, the
		/// operation succeeds, that is, it will not produce an error, even if any or all of the specified values are not set on the property.
		/// </para>
		/// <para>
		/// <c>Note</c>  The WinNT provider ignores the value passed by the <c>InControlCode</c> argument and performs the equivalent of an
		/// <c>ADS_PROPERTY_UPDATE</c> request when using <c>PutEx</c>.
		/// </para>
		/// <para></para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use the <c>IADs.PutEx</c> method.</para>
		/// <para>The following code example shows how to use the <c>IADs::PutEx</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-putex HRESULT PutEx( [in] long lnControlCode, [in] BSTR
		// bstrName, [in] VARIANT vProp );
		[DispId(13)]
		new void PutEx([In] ADS_PROPERTY_OPERATION lnControlCode, [In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);

		/// <summary>
		/// The <c>IADs::GetInfoEx</c> method loads the values of specified properties of the ADSI object from the underlying directory store
		/// into the property cache.
		/// </summary>
		/// <param name="vProperties">
		/// Array of null-terminated Unicode string entries that list the properties to load into the Active Directory property cache. Each
		/// property name must match one in this object's schema class definition.
		/// </param>
		/// <param name="lnReserved">Reserved for future use. Must be set to zero.</param>
		/// <remarks>
		/// <para>
		/// The <c>IADs::GetInfoEx</c> method overwrites any previously cached values of the specified properties with those in the directory
		/// store. Therefore, any change made to the cache will be lost if IADs::SetInfo was not invoked before the call to <c>IADs::GetInfoEx</c>.
		/// </para>
		/// <para>
		/// Use <c>IADs::GetInfoEx</c> to refresh values of the selected property in the property cache of an ADSI object. Use IADs::GetInfo
		/// to refresh all the property values.
		/// </para>
		/// <para>
		/// For an ADSI container object, <c>IADs::GetInfoEx</c> caches only the property values of the container, but not those of the child objects.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to use the <c>IADs::GetInfoEx</c> to obtain values of the selected properties, assuming that
		/// the desired property values can be found in the directory.
		/// </para>
		/// <para>
		/// The following code example shows how to use the <c>IADs::GetInfoEx</c> to obtain values of the selected properties, assuming that
		/// the desired property values can be found in the directory. For brevity, error checking has been omitted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getinfoex HRESULT GetInfoEx( [in] VARIANT vProperties, [in]
		// long lnReserved );
		[DispId(14)]
		new void GetInfoEx([In, MarshalAs(UnmanagedType.Struct)] object vProperties, [In] int lnReserved = 0);

		/// <summary>Gets the current status of the print queue operations..</summary>
		/// <value>The current status of the print queue operations..</value>
		[DispId(27)]
		ADS_PRINT_QUEUE_STATUS Status
		{
			[DispId(27)]
			get;
		}

		/// <summary>
		/// The <c>IADsPrintQueueOperations::PrintJobs</c> method gets an IADsCollection interface pointer on the collection of the print
		/// jobs processed in this print queue. This collection can be enumerated using the standard Automation enumeration methods on
		/// IEnumVARIANT. To delete a print job, use the IADsCollection::Remove method on the retrieved interface pointer.
		/// </summary>
		/// <returns>
		/// Pointer to a pointer to the IADsCollection interface on the collection of objects added to this print queue. Objects in the
		/// collection implement the IADsPrintJob interface.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsprintqueueoperations-printjobs HRESULT PrintJobs( [out]
		// IADsCollection **pObject );
		[DispId(28)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IADsCollection PrintJobs();

		/// <summary>The <c>IADsPrintQueueOperations::Pause</c> method suspends the processing of print jobs within a print queue service.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsprintqueueoperations-pause HRESULT Pause();
		[DispId(29)]
		void Pause();

		/// <summary>The <c>IADsPrintQueueOperations::Resume</c> method resumes processing of suspended print jobs in the print queue.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsprintqueueoperations-resume HRESULT Resume();
		[DispId(30)]
		void Resume();

		/// <summary>The <c>IADsPrintQueueOperations::Purge</c> method clears the print queue of all print jobs without processing them.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsprintqueueoperations-purge HRESULT Purge();
		[DispId(31)]
		void Purge();
	}

	/// <summary>
	/// <para>
	/// The <c>IADsProperty</c> interface is designed to manage a single attribute definition for a schema class object. An attribute
	/// definition specifies the minimum and maximum values of a property, its syntax, and whether the property supports multiple values.
	/// Other interfaces involved in schema management include IADsClass and IADsSyntax.
	/// </para>
	/// <para>
	/// The <c>IADsProperty</c> interface exposes methods to describe a property by name, syntax, value ranges, and any other defined
	/// attributes. A property can have multiple names associated with it, but providers must ensure that each name is unique.
	/// </para>
	/// <para>
	/// Use the <c>IADsProperty</c> interface to determine at run time the attribute definition of a property supported by a directory
	/// service object.
	/// </para>
	/// <para><c>To determine the attribute definition at run time</c></para>
	/// <list type="number">
	/// <item>
	/// <description>Bind to the schema class object of the ADSI object.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Enumerate mandatory or optional attributes accessible from the schema class object. Skip this step if you know that the object
	/// supports the attribute of your interest.
	/// </description>
	/// </item>
	/// <item>
	/// <description>Bind to the schema container of the schema class object you obtained in first step.</description>
	/// </item>
	/// <item>
	/// <description>Retrieve the attribute definition object of the property of interest from the schema container.</description>
	/// </item>
	/// <item>
	/// <description>Examine the attribute definition of the property. You may have to also inspect the syntax object.</description>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// <para>The <c>IADsProperty</c> interface methods can add new attributes and property objects to a provider-specific implementation.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example shows the procedure above for applying the <c>IADsProperty</c> interface to determine attribute
	/// definitions of a property.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsproperty
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsProperty")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("C8F93DD3-4AE0-11CF-9E73-00AA004A5691")]
	public interface IADsProperty : IADs
	{
		/// <summary>
		/// The relative name of the object as named within the underlying directory service. This name distinguishes this object from its siblings.
		/// </summary>
		/// <value>The relative name of the object as named within the underlying directory service.</value>
		[DispId(2)]
		new string Name
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The name of the object Schema class.</summary>
		/// <value>The name of the object Schema class.</value>
		[DispId(3)]
		new string Class
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The globally unique identifier of the directory object. The IADs interface converts the GUID from an octet string, as stored on a
		/// directory server, into a string format.
		/// </summary>
		/// <value>The globally unique identifier of the directory object.</value>
		/// <remarks>
		/// <para>
		/// In Active Directory, the GUID returned from GUID is a string of hexadecimals. Use the resultant GUID to bind to the object directly.
		/// </para>
		/// <code language="vb">
		///<![CDATA[
		///Dim x As IADs
		///Set x = GetObject("LDAP://servername/<GUID=xxx>")]]>
		/// </code>
		/// <para>
		/// where xxx is the value returned from the GUID property. For more information, see Using objectGUID to Bind to an Object. Be aware
		/// that if you use a GUID to bind to an object, the ADsPath property method returns values that are different from the normal values
		/// that would be returned if you used a distinguished name (DN) to bind to the same object. For example, the following table lists
		/// the values returned when using the two different binding methods to bind to the same user object.
		/// </para>
		/// </remarks>
		[DispId(4)]
		new string GUID
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The ADsPath string of this object. The string uniquely identifies this object in a network environment. The object can always be
		/// retrieved using this path.
		/// </summary>
		/// <value>The ADsPath string of this object.</value>
		[DispId(5)]
		new string ADsPath
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The ADsPath string of the parent container. Active Directory does not permit the formation of the ADsPath of a given object by
		/// concatenating the Parent and Name properties. While this operation might work in some providers, it is not guaranteed to work for
		/// all implementations. The ADsPath is guaranteed to be valid and should always be used to retrieve an object's interface pointer.
		/// </summary>
		/// <value>The ADsPath string of the parent container.</value>
		[DispId(6)]
		new string Parent
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The ADsPath string of the Schema class object of this object.</summary>
		/// <value>The ADsPath string of the Schema class object of this object.</value>
		[DispId(7)]
		new string Schema
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The <c>IADs::GetInfo</c> method loads into the property cache values of the supported properties of this ADSI object from the
		/// underlying directory store.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>IADs::GetInfo</c> function is called to initialize or refresh the property cache. This is similar to obtaining those
		/// property values of supported properties from the underlying directory store.
		/// </para>
		/// <para>
		/// An uninitialized property cache is not necessarily empty. Call IADs::Put or IADs::PutEx to place a value into the property cache
		/// for any supported property and the cache remains uninitialized.
		/// </para>
		/// <para>
		/// An explicit call to <c>IADs::GetInfo</c> loads or reloads the entire property cache, overwriting all the cached property values.
		/// But an implicit call loads only those properties not set in the cache. Always call <c>IADs::GetInfo</c> explicitly to retrieve
		/// the most current property values of the ADSI object.
		/// </para>
		/// <para>
		/// Because an explicit call to <c>IADs::GetInfo</c> overwrites all the values in the property cache, any change made to the cache
		/// will be lost if an IADs::SetInfo was not invoked before <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>
		/// For an ADSI container object, <c>IADs::GetInfo</c> caches only the property values of the container, but not those of the child objects.
		/// </para>
		/// <para>
		/// It is important to emphasize the differences between the IADs::Get and <c>IADs::GetInfo</c> methods. The former returns values of
		/// a given property from the property cache whereas the latter loads all the supported property values into the property cache from
		/// the underlying directory store.
		/// </para>
		/// <para>The following code example illustrates the differences between the IADs::Get and <c>IADs::GetInfo</c> methods.</para>
		/// <para>
		/// For increased performance, explicitly call IADs::GetInfoEx to refresh specific properties. Also, <c>IADs::GetInfoEx</c> must be
		/// called instead of <c>IADs::GetInfo</c> if the object's operational property values have to be accessed. This function overwrites
		/// any previously cached values of the specified properties.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example uses a computer object served by the WinNT provider. The supported properties include <c>Owner</c>
		/// ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"), <c>Division</c> ("Fabrikam"),
		/// <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping 1"). The default values are shown
		/// in parentheses.
		/// </para>
		/// <para>
		/// The following code example is a client-side script that illustrates the effect of <c>IADs::GetInfo</c> method. The supported
		/// properties include <c>Owner</c> ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"),
		/// <c>Division</c> ("Fabrikam"), <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping
		/// 1"). The default values are shown in parentheses.
		/// </para>
		/// <para>The following code example highlights the effect of Get and GetInfo. For brevity, error checking is omitted.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getinfo HRESULT GetInfo();
		[DispId(8)]
		new void GetInfo();

		/// <summary>The <c>IADs::SetInfo</c> method saves the cached property values of the ADSI object to the underlying directory store.</summary>
		/// <remarks>
		/// <para>
		/// It is important to emphasize the differences between the IADs::Put and <c>IADs::SetInfo</c> methods. The former sets (or
		/// modifies) values of a given property in the property cache whereas the latter propagates the changes from the property cache into
		/// the underlying directory store. Therefore, any property value changes made by <c>IADs::Put</c> will be lost if IADs::GetInfo (or
		/// IADs::GetInfoEx) is invoked before <c>IADs::SetInfo</c> is called.
		/// </para>
		/// <para>
		/// Because <c>IADs::SetInfo</c> sends data across networks, minimize the usage of this method. This reduces the number of trips a
		/// client makes to the server. For example, you should commit all, or most, of the changes to the properties from the cache to the
		/// persistent store in one batch.
		/// </para>
		/// <para>
		/// This guideline pertains only to the relationship of <c>IADs::SetInfo</c> with the IADs::Put method, which differs from the
		/// relationship with the IADs::PutEx method.
		/// </para>
		/// <para>The following code example illustrates the recommended relation between IADs::Put and <c>IADs::SetInfo</c>.</para>
		/// <para>The following code example illustrates what is not recommended between IADs::Put and <c>IADs::SetInfo</c>.</para>
		/// <para>
		/// When used with IADs::PutEx, <c>IADs::SetInfo</c> passes the operational requests specified by control codes, such as
		/// ADS_PROPERTY_UPDATE or ADS_PROPERTY_CLEAR, to the underlying directory store.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following Visual Basic code example uses the <c>IADs::SetInfo</c> method to save the property value of a user to the
		/// underlying directory.
		/// </para>
		/// <para>
		/// The following C++ code example updates property values in the property cache and commits the change to the directory store using
		/// <c>IADs::SetInfo</c>. For brevity, error checking is omitted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-setinfo HRESULT SetInfo();
		[DispId(9)]
		new void SetInfo();

		/// <summary>
		/// The <c>IADs::Get</c> method retrieves a property of a given name from the property cache. The property can be single-valued, or
		/// multi-valued. The property value is represented as either a variant for a single-valued property or a variant array (of
		/// <c>VARIANT</c> or bytes) for a property that allows multiple values.
		/// </summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <returns>
		/// Pointer to a <c>VARIANT</c> that receives the value of the property. For a multi-valued property, <c>pvProp</c> is a variant
		/// array of <c>VARIANT</c>, unless the property is a binary type. In this latter case, <c>pvProp</c> is a variant array of bytes
		/// (VT_U1 or VT_ARRAY). For the property that refers to an object, <c>pvProp</c> is a VT_DISPATCH pointer to the object referred to.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IADs::Get</c> method requires the caller to handle the single- and multi-valued property values differently. Thus, if you
		/// know that the property of interest is either single- or multi-valued, use the <c>IADs::Get</c> method to retrieve the property
		/// value. The following code example shows how you, as a caller, can handle single- and multi-valued properties when calling this method.
		/// </para>
		/// <para>
		/// When a property is uninitialized, calling this method invokes an implicit call to the IADs::GetInfo method. This loads from the
		/// underlying directory store the values of the supported properties that have not been set in the cache. Any subsequent calls to
		/// <c>IADs::Get</c> deals with property values in the cache only. For more information about the behavior of implicit and explicit
		/// calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>
		/// You can also use IADs::GetEx to retrieve property values from the property cache. However, the values are returned as a variant
		/// array of <c>VARIANT</c> s, regardless of whether they are single-valued or multi-valued. That is, ADSI attempts to package the
		/// returned property values in consistent data formats. This saves you, as a caller, the effort of validating the data types when
		/// unsure that the returned data has single or multiple values.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example retrieves the security descriptor for an object using <c>IADs::Get</c>.</para>
		/// <para>The following code example shows how to work with property values of binary data using <c>IADs::Get</c> and IADs::Put.</para>
		/// <para>The following code example shows how to retrieve values of the optional properties of an object using <c>IADs::Get</c>.</para>
		/// <para>The following code example reads attributes with single and multiple values using <c>IADs::Get</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-get HRESULT Get( [in] BSTR bstrName, [out] VARIANT *pvProp );
		[DispId(10)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object? Get([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

		/// <summary>The <c>IADs::Put</c> method sets the values of an attribute in the ADSI attribute cache.</summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <param name="vProp">Contains a <c>VARIANT</c> that specifies the new values of the property.</param>
		/// <remarks>
		/// <para>
		/// The assignment of the new property values, performed by <c>Put</c> takes place in the property cache only. To propagate the
		/// changes to the directory store, call IADs::SetInfo on the object after calling <c>Put</c>.
		/// </para>
		/// <para>
		/// To manipulate the property values beyond a simple assignment, use <c>Put</c> to append or remove a value from an existing array
		/// of attribute values.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use the <c>IADs::Put</c> method.</para>
		/// <para>The following code example shows how to use the <c>IADs::Put</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-put HRESULT Put( [in] BSTR bstrName, [in] VARIANT vProp );
		[DispId(11)]
		new void Put([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);

		/// <summary>
		/// The <c>IADs::GetEx</c> method retrieves, from the property cache, property values of a given attribute. The returned property
		/// values can be single-valued or multi-valued. Unlike the IADs::Get method, the property values are returned as a variant array of
		/// <c>VARIANT</c>, or a variant array of bytes for binary data. A single-valued property is then represented as an array of a single element.
		/// </summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <returns>Pointer to a <c>VARIANT</c> that receives the value, or values, of the property.</returns>
		/// <remarks>
		/// <para>
		/// The IADs::Get and <c>IADs::GetEx</c> methods return a different variant structure for a single-valued property value. If the
		/// property is a string, <c>IADs::Get</c> returns a variant of string (VT_BSTR), whereas <c>IADs::GetEx</c> returns a variant array
		/// of a <c>VARIANT</c> type string with a single element. Thus, if you are not sure that a multi-valued attribute will return a
		/// single value or multiple values, use <c>IADs::GetEx</c>. As it does not require you to validate the result's data structures, you
		/// may want to use <c>IADs::GetEx</c> to retrieve a property when you are not sure whether it has single or multiple values. The
		/// following list compares the two methods.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>IADs::Get version</description>
		/// <description>IADs::GetEx version</description>
		/// </listheader>
		/// <item>
		/// <description/>
		/// <description/>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// Like the IADs::Get method, <c>IADs::GetEx</c> implicitly calls IADs::GetInfo against an uninitialized property cache. For more
		/// information about implicit and explicit calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use <c>IADs::GetEx</c> to retrieve object properties.</para>
		/// <para>The following code example shows how to retrieve values of the optional properties of an object using the IADs::Get method.</para>
		/// <para>The following code example retrieves the "homePhone" property values using <c>IADs::GetEx</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getex HRESULT GetEx( [in] BSTR bstrName, [out] VARIANT
		// *pvProp );
		[DispId(12)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object? GetEx([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

		/// <summary>
		/// The <c>IADs::PutEx</c> method modifies the values of an attribute in the ADSI attribute cache. For example, for properties that
		/// allow multiple values, you can append additional values to an existing set of values, modify the values in the set, remove
		/// specified values from the set, or delete values from the set.
		/// </summary>
		/// <param name="lnControlCode">
		/// Control code that indicates the mode of modification: Append, Replace, Remove, and Delete. For more information and a list of
		/// values, see ADS_PROPERTY_OPERATION_ENUM.
		/// </param>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <param name="vProp">
		/// Contains a <c>VARIANT</c> array that contains the new value or values of the property. A single-valued property is represented as
		/// an array with a single element. If <c>InControlCode</c> is set to <c>ADS_PROPERTY_CLEAR</c>, the value of the property specified
		/// by <c>vProp</c> is irrelevant.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>PutEx</c> is usually used to set values on multi-value attributes. Unlike the IADs::Put method, with <c>PutEx</c>, you are not
		/// required to get the attribute values before you modify them. However, because <c>PutEx</c> only makes changes to attributes
		/// values contained in the ADSI property cache, you must use IADs::SetInfo after each <c>PutEx</c> call in order to commit changes
		/// to the directory.
		/// </para>
		/// <para>
		/// <c>PutEx</c> enables you to append values to an existing set of values in a multi-value attribute using
		/// <c>ADS_PROPERTY_APPEND</c>. When you update, append, or delete values to a multi-value attribute, you must use an array.
		/// </para>
		/// <para>
		/// Active Directory does not accept duplicate values on a multi-valued attribute. If you call <c>PutEx</c> to append a duplicate
		/// value to a multi-valued attribute of an Active Directory object, the <c>PutEx</c> call succeeds, but the duplicate value is ignored.
		/// </para>
		/// <para>
		/// Similarly, if you use <c>PutEx</c> to delete one or more values from a multi-valued property of an Active Directory object, the
		/// operation succeeds, that is, it will not produce an error, even if any or all of the specified values are not set on the property.
		/// </para>
		/// <para>
		/// <c>Note</c>  The WinNT provider ignores the value passed by the <c>InControlCode</c> argument and performs the equivalent of an
		/// <c>ADS_PROPERTY_UPDATE</c> request when using <c>PutEx</c>.
		/// </para>
		/// <para></para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use the <c>IADs.PutEx</c> method.</para>
		/// <para>The following code example shows how to use the <c>IADs::PutEx</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-putex HRESULT PutEx( [in] long lnControlCode, [in] BSTR
		// bstrName, [in] VARIANT vProp );
		[DispId(13)]
		new void PutEx([In] ADS_PROPERTY_OPERATION lnControlCode, [In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);

		/// <summary>
		/// The <c>IADs::GetInfoEx</c> method loads the values of specified properties of the ADSI object from the underlying directory store
		/// into the property cache.
		/// </summary>
		/// <param name="vProperties">
		/// Array of null-terminated Unicode string entries that list the properties to load into the Active Directory property cache. Each
		/// property name must match one in this object's schema class definition.
		/// </param>
		/// <param name="lnReserved">Reserved for future use. Must be set to zero.</param>
		/// <remarks>
		/// <para>
		/// The <c>IADs::GetInfoEx</c> method overwrites any previously cached values of the specified properties with those in the directory
		/// store. Therefore, any change made to the cache will be lost if IADs::SetInfo was not invoked before the call to <c>IADs::GetInfoEx</c>.
		/// </para>
		/// <para>
		/// Use <c>IADs::GetInfoEx</c> to refresh values of the selected property in the property cache of an ADSI object. Use IADs::GetInfo
		/// to refresh all the property values.
		/// </para>
		/// <para>
		/// For an ADSI container object, <c>IADs::GetInfoEx</c> caches only the property values of the container, but not those of the child objects.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to use the <c>IADs::GetInfoEx</c> to obtain values of the selected properties, assuming that
		/// the desired property values can be found in the directory.
		/// </para>
		/// <para>
		/// The following code example shows how to use the <c>IADs::GetInfoEx</c> to obtain values of the selected properties, assuming that
		/// the desired property values can be found in the directory. For brevity, error checking has been omitted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getinfoex HRESULT GetInfoEx( [in] VARIANT vProperties, [in]
		// long lnReserved );
		[DispId(14)]
		new void GetInfoEx([In, MarshalAs(UnmanagedType.Struct)] object vProperties, [In] int lnReserved = 0);

		/// <summary>Gets or sets the Directory-specific object identifier.</summary>
		/// <value>The Directory-specific object identifier.</value>
		[DispId(17)]
		string OID
		{
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(17)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the relative path of syntax object.</summary>
		/// <value>The relative path of syntax object.</value>
		[DispId(18)]
		string Syntax
		{
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(18)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the upper limit of values.</summary>
		/// <value>The upper limit of values.</value>
		[DispId(19)]
		int MaxRange
		{
			[DispId(19)]
			get;
			[DispId(19)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the lower limit of values.</summary>
		/// <value>The lower limit of values.</value>
		[DispId(20)]
		int MinRange
		{
			[DispId(20)]
			get;
			[DispId(20)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets a value indicating whether property supports single or multiple values.</summary>
		/// <value>Whether property supports single or multiple values.</value>
		[DispId(21)]
		bool MultiValued
		{
			[DispId(21)]
			get;
			[DispId(21)]
			[param: In]
			set;
		}

		/// <summary>
		/// The <c>IADsProperty::Qualifiers</c> method is an optional method that returns a collection of ADSI objects that describe
		/// additional qualifiers of this property.
		/// </summary>
		/// <returns>
		/// Indirect pointer to the IADsCollection interface on the ADSI collection object that represents additional limits for this property.
		/// </returns>
		/// <remarks>
		/// <para>The qualifier objects are provider-specific. When supported, this method can be used to obtain extended schema data.</para>
		/// <para>This method is not currently supported by any of the providers supplied by Microsoft.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsproperty-qualifiers HRESULT Qualifiers( [out] IADsCollection
		// **ppQualifiers );
		[DispId(22)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IADsCollection Qualifiers();
	}

	/// <summary>
	/// The property methods of the <c>IADsPropertyEntry</c> interface provide access to the following properties. For more information about
	/// property methods, see Interface Property Methods.
	/// </summary>
	/// <remarks>
	/// Each property method supports the standard <c>HRESULT</c> return values, including S_OK. For more information about other return
	/// values, see ADSI Error Codes.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/adsi/iadspropertyentry-property-methods
	[PInvokeData("Iads.h")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("05792C8E-941F-11D0-8529-00C04FD8D503"), CoClass(typeof(PropertyEntry))]
	public interface IADsPropertyEntry
	{
		/// <summary>Clears the current values of the property entry object.</summary>
		// HRESULT Clear();
		[DispId(1)]
		void Clear();

		/// <summary>
		/// Gets or sets the name of the property entry. This name should correspond to the name of an attribute as defined in the schema.
		/// </summary>
		/// <value>The name of the property entry. This name should correspond to the name of an attribute as defined in the schema.</value>
		[DispId(2)]
		string Name
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(2)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the data type of the Name property. The values of the data type is defined in the ADSTYPE enumeration.</summary>
		/// <value>The data type of the Name property. The values of the data type is defined in the ADSTYPE enumeration.</value>
		[DispId(3)]
		ADSTYPE ADsType
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}

		/// <summary>
		/// Gets or sets the operation to be performed on the named property. The value is defined in the ADS_PROPERTY_OPERATION_ENUM enumeration.
		/// </summary>
		/// <value>The operation to be performed on the named property. The value is defined in the ADS_PROPERTY_OPERATION_ENUM enumeration.</value>
		[DispId(4)]
		ADS_PROPERTY_OPERATION ControlCode
		{
			[DispId(4)]
			get;
			[DispId(4)]
			[param: In]
			set;
		}

		/// <summary>
		/// Gets or sets A VARIANT array. Each element in this array represents a value of the named property. Such property values are
		/// represented by ADSI objects implementing the IADsPropertyValue and IADsPropertyValue2 interfaces. Therefore, the VARIANT array
		/// holds an array of pointers to the IDispatch interface on the ADSI objects implementing the IADsPropertyValue and
		/// IADsPropertyValue2 interfaces.
		/// </summary>
		/// <value>
		/// A VARIANT array. Each element in this array represents a value of the named property. Such property values are represented by
		/// ADSI objects implementing the IADsPropertyValue and IADsPropertyValue2 interfaces. Therefore, the VARIANT array holds an array of
		/// pointers to the IDispatch interface on the ADSI objects implementing the IADsPropertyValue and IADsPropertyValue2 interfaces.
		/// </value>
		[DispId(5)]
		object Values
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(5)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}
	}

	/// <summary>
	/// <para>
	/// The <c>IADsPropertyList</c> interface is used to modify, read, and update a list of property entries in the property cache of an
	/// object. It serves to enumerate, modify, and purge the contained property entries. Use the enumeration method of this interface to
	/// identify initialized properties. This is different from using the schema to determine all possible attributes that an ADSI object can
	/// have and which properties have been set.
	/// </para>
	/// <para>
	/// Call the methods of the <c>IADsPropertyList</c> interface to examine and manipulate the property list on the client. Before calling
	/// the methods of this interface, you must call IADs::GetInfo or IADs::GetInfoEx explicitly to load the assigned property values of the
	/// object into the cache. After calling the methods of this interface, you must call IADs::SetInfo to save the changes in the persistent
	/// store of the underlying directory.
	/// </para>
	/// <para>
	/// To obtain the property list of an ADSI object, bind to its <c>IADsPropertyList</c> interface. You must call the GetInfo method before
	/// calling other methods of property list object, if the property cache has not been initialized.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadspropertylist
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsPropertyList")]
	[ComImport, DefaultMember("Item"), Guid("C6F602B6-8F69-11D0-8528-00C04FD8D503"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IADsPropertyList
	{
		/// <summary>Gets the number of items in the property list.</summary>
		/// <value>The number of items in the property list.</value>
		[DispId(2)]
		int PropertyCount
		{
			[DispId(2)]
			get;
		}

		/// <summary>
		/// The <c>IADsPropertyList::Next</c> method gets the next item in the property list. The returned item is a Property Entry object.
		/// </summary>
		/// <returns>
		/// Address of a caller-allocated variable that contains the value of the next item in the property list. The return value of
		/// <c>VT_DISPATCH</c> refers to an IDispatch interface pointer to an object implementing the IADsPropertyEntry interface.
		/// </returns>
		/// <remarks>
		/// <para>
		/// You must clear <c>pVariant</c> using <c>VariantClear</c> when the value returned by the <c>Next</c> method is no longer required.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to walk through a property list using the <c>Next</c> method.</para>
		/// <para>The following C++ code example shows how to work the <c>IADsPropertyList::Next</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspropertylist-next HRESULT Next( [out] VARIANT *pVariant );
		[DispId(3)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object Next();

		/// <summary>
		/// The <c>IADsPropertyList::Skip</c> method skips a specified number of items, counting from the current cursor position, in the
		/// property list.
		/// </summary>
		/// <param name="cElements">Number of elements to be skipped.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspropertylist-skip HRESULT Skip( [in] long cElements );
		[DispId(4)]
		void Skip([In] int cElements);

		/// <summary>The <c>IADsPropertyList::Reset</c> method resets the list to the first item.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspropertylist-reset HRESULT Reset();
		[DispId(5)]
		void Reset();

		/// <summary>The <c>IADsPropertyList::Item</c> method retrieves the specified property item from the list.</summary>
		/// <param name="varIndex">The <c>VARIANT</c> that contains the index or name of the property to be retrieved.</param>
		/// <returns>
		/// Address of a caller-allocated <c>VARIANT</c> variable. On return, the <c>VARIANT</c> contains the IDispatch pointer to the object
		/// which implements the IADsPropertyEntry interface for the attribute retrieved.
		/// </returns>
		/// <remarks>
		/// <para>
		/// You must clear <c>pVariant</c> using <c>VariantClear</c> when the value returned by the <c>Item</c> method is no longer required.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to enumerate all the entries with the <c>Item</c> method.</para>
		/// <para>
		/// The following code example shows how to retrieve the <c>Owner</c> property of a computer using the <c>IADsPropertyList::Item</c>
		/// method. For more information about the <c>GetPropertyCache</c> function and a code example, see IADsPropertyList.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspropertylist-item HRESULT Item( [in] VARIANT varIndex, [in,
		// out] VARIANT *pVariant );
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object Item([In, MarshalAs(UnmanagedType.Struct)] object varIndex);

		/// <summary>The <c>IADsPropertyList::GetPropertyItem</c> method retrieves the item that matches the name from the list.</summary>
		/// <param name="bstrName">Contains the name of the requested property.</param>
		/// <param name="lnADsType">
		/// Contains one of the ADSTYPE enumeration values that determines the data type to be used in interpreting the requested
		/// property. If the type is unknown, this parameter can be set to <c>ADSTYPE_UNKNOWN</c>. For schemaless servers, the user must
		/// specify the type.
		/// </param>
		/// <returns>
		/// <para>
		/// Address of a caller-allocated <c>VARIANT</c> variable. On return, the <c>VARIANT</c> contains the IDispatch interface pointer of
		/// the object which implements the IADsPropertyEntry interface for the retrieved attribute.
		/// </para>
		/// <para>Any memory allocated for this parameter must be released with the VariantClear function when the data is no longer required.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property of the IADsPropertyValue object returned by this method that can be used will depend on the type specified in
		/// <c>lnADsType</c>. The following table maps the data type to the appropriate IADsPropertyEntry property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><c>lnADsType</c> value</description>
		/// <description>IADsPropertyValue property to use</description>
		/// </listheader>
		/// <item>
		/// <description><c>ADSTYPE_INVALID</c></description>
		/// <description>Not available.</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_DN_STRING</c></description>
		/// <description>DNString</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_CASE_EXACT_STRING</c></description>
		/// <description>CaseExactString</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_CASE_IGNORE_STRING</c></description>
		/// <description>CaseIgnoreString</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_PRINTABLE_STRING</c></description>
		/// <description>PrintableString</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_NUMERIC_STRING</c></description>
		/// <description>NumericString</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_BOOLEAN</c></description>
		/// <description>Boolean</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_INTEGER</c></description>
		/// <description>Integer</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_OCTET_STRING</c></description>
		/// <description>OctetString</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_UTC_TIME</c></description>
		/// <description>UTCTime</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_LARGE_INTEGER</c></description>
		/// <description>LargeInteger</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_PROV_SPECIFIC</c></description>
		/// <description>Use IADsPropertyValue2::GetObjectProperty (VT_ARRAY | VT_UI1).</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_OBJECT_CLASS</c></description>
		/// <description>Not available.</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_CASEIGNORE_LIST</c></description>
		/// <description>Use IADsPropertyValue2::GetObjectProperty (IADsCaseIgnoreList).</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_OCTET_LIST</c></description>
		/// <description>Use IADsPropertyValue2::GetObjectProperty (IADsOctetList).</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_PATH</c></description>
		/// <description>Use IADsPropertyValue2::GetObjectProperty (IADsPath).</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_POSTALADDRESS</c></description>
		/// <description>Use IADsPropertyValue2::GetObjectProperty (IADsPostalAddress).</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_TIMESTAMP</c></description>
		/// <description>Use IADsPropertyValue2::GetObjectProperty (IADsTimestamp).</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_BACKLINK</c></description>
		/// <description>Use IADsPropertyValue2::GetObjectProperty (IADsBackLink).</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_TYPEDNAME</c></description>
		/// <description>Use IADsPropertyValue2::GetObjectProperty (IADsTypedName).</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_HOLD</c></description>
		/// <description>Use IADsPropertyValue2::GetObjectProperty (IADsHold).</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_NETADDRESS</c></description>
		/// <description>Use IADsPropertyValue2::GetObjectProperty (IADsNetAddress).</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_REPLICAPOINTER</c></description>
		/// <description>Use IADsPropertyValue2::GetObjectProperty (IADsReplicaPointer).</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_FAXNUMBER</c></description>
		/// <description>Use IADsPropertyValue2::GetObjectProperty (IADsFaxNumber).</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_EMAIL</c></description>
		/// <description>Use IADsPropertyValue2::GetObjectProperty (IADsEmail).</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_NT_SECURITY_DESCRIPTOR</c></description>
		/// <description>SecurityDescriptor</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_UNKNOWN</c></description>
		/// <description>Not available.</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_DN_WITH_BINARY</c></description>
		/// <description>Use IADsPropertyValue2::GetObjectProperty (IADsDNWithBinary).</description>
		/// </item>
		/// <item>
		/// <description><c>ADSTYPE_DN_WITH_STRING</c></description>
		/// <description>Use IADsPropertyValue2::GetObjectProperty (IADsDNWithString).</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to retrieve a property entry using the <c>GetPropertyItem</c> method.</para>
		/// <para>
		/// The following code example shows how to retrieve a property entry using the <c>GetPropertyItem</c> method. It assumes that the
		/// IADsPropertyList interface has been properly retrieved. For more information about how to load the property cache, see the
		/// GetPropertyCache example function in <c>IADsPropertyList</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspropertylist-getpropertyitem HRESULT GetPropertyItem( [in]
		// BSTR bstrName, [in] LONG lnADsType, [in, out] VARIANT *pVariant );
		[DispId(6)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetPropertyItem([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In] ADSTYPE lnADsType);

		/// <summary>The <c>IADsPropertyList::PutPropertyItem</c> method updates the values for an item in the property list.</summary>
		/// <param name="varData">
		/// New property values to be put in the property cache. This should contain the IDispatch pointer to the object which implements the
		/// IADsPropertyEntry that contain the modified property values.
		/// </param>
		/// <remarks>
		/// <para>
		/// The IADsPropertyEntry::put_ControlCode should be set to the desired modify / add / delete operation by using the proper
		/// ADS_PROPERTY_OPERATION_ENUM value. After <c>PutPropertyItem</c> has been called, you must call IADs::SetInfo to persist any
		/// changes in the directory store. The property values are not committed until the <c>IADs::SetInfo</c> method is called.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to add a new entry to a property list using <c>PutPropertyItem</c>.</para>
		/// <para>The following code example adds a new entry to a property list using <c>IADsPropertyList::PutPropertyItem</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspropertylist-putpropertyitem HRESULT PutPropertyItem( [in]
		// VARIANT varData );
		[DispId(7)]
		void PutPropertyItem([In, MarshalAs(UnmanagedType.Struct)] object varData);

		/// <summary>
		/// The <c>IADsPropertyList::ResetPropertyItem</c> method removes the specified item from the list; that is, from the cache. You can
		/// specify the item to be removed by name (as a string) or by index (as an integer).
		/// </summary>
		/// <param name="varEntry">Entry to be reset.</param>
		/// <remarks>
		/// <para>
		/// <c>ResetPropertyItem</c> only affects the contents of the cache and does not affect the properties on the actual object in the
		/// directory; that is calling SetInfo after calling <c>ResetPropertyItem</c> does not delete the properties on the directory object.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to implement <c>ResetPropertyItem</c>.</para>
		/// <para>
		/// The following code example shows the effect produced by a call to <c>IADsPropertyList::ResetPropertyItem</c>. For more
		/// information and the listing of the <c>GetPropertyCache</c> function, see IADsPropertyList. For more information and the listing
		/// of the <c>GetNextEntry</c> and <c>PropertyItem</c> functions, see IADsPropertyList::Next and IADsPropertyList::Item respectively.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspropertylist-resetpropertyitem HRESULT ResetPropertyItem(
		// [in] VARIANT varEntry );
		[DispId(8)]
		void ResetPropertyItem([In, MarshalAs(UnmanagedType.Struct)] object varEntry);

		/// <summary>The <c>IADsPropertyList::PurgePropertyList</c> method deletes all items from the property list.</summary>
		/// <remarks>
		/// <para>
		/// When the <c>PurgePropertyList</c> method is called, all the items are removed from the cache. Thus, calling GetPropertyItem after
		/// that will generate an error. Be aware that <c>PurgePropertyList</c> only affects the contents of the cache and does not affect
		/// the properties on the actual object in the directory; that is, calling SetInfo after calling <c>PurgePropertyList</c> does not
		/// delete the properties on the directory object.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to implement <c>IADsPropertyList::PurgePropertyList</c>.</para>
		/// <para>
		/// The following code example shows the effect produced by a call to <c>IADsPropertyList::PurgePropertyList</c>. For more
		/// information about the <c>GetPropertyCache</c> function and a code example, see IADsPropertyList.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspropertylist-purgepropertylist HRESULT PurgePropertyList();
		[DispId(9)]
		void PurgePropertyList();
	}

	/// <summary>
	/// <para>
	/// The <c>IADsPropertyValue</c> interface is used to represent the value of an IADsPropertyEntry object in a predefined data type. This
	/// interface exposes several properties for obtaining data values in the corresponding data format.
	/// </para>
	/// <para>
	/// The IADsPropertyEntry.Values property contains an array of <c>IADsPropertyValue</c> objects. Each of the <c>IADsPropertyValue</c>
	/// objects contains a single value of the IADsPropertyEntry object. For more information and a code example for creating entirely new
	/// property entries and values, see IADsPropertyList.PutPropertyItem.
	/// </para>
	/// <para>When obtaining values in a format not provided by one of the properties of this interface, use the IADsPropertyValue2 interface.</para>
	/// <para>
	/// Before calling the methods of this interfaces, call IADs.GetInfo or IADs.GetInfoEx explicitly to load the assigned values of the
	/// object into the cache, if the cache has not been initialized. After modifying the properties of this interface, call IADs.SetInfo to
	/// save the changes to the persistent store of the underlying directory.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadspropertyvalue
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsPropertyValue")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("79FA9AD0-A97C-11D0-8534-00C04FD8D503"), CoClass(typeof(PropertyValue))]
	public interface IADsPropertyValue
	{
		/// <summary>The <c>IADsPropertyValue::Clear</c> method clears the current values of the property value object.</summary>
		/// <remarks>
		/// <para>None</para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to use <c>IADsPropertyValue::Clear</c> to clear the value of the "description" property from
		/// a property list.
		/// </para>
		/// <para>
		/// The following code example shows how to use <c>IADsPropertyValue::Clear</c> to clear the value of the "description" property from
		/// a property list.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspropertyvalue-clear HRESULT Clear();
		[DispId(1)]
		void Clear();

		/// <summary>Gets or sets the data type of the value of the property, taken from the ADSTYPE enumeration, of the value property.</summary>
		/// <value>The data type of the value of the property, taken from the ADSTYPE enumeration, of the value property.</value>
		[DispId(2)]
		ADSTYPE ADsType
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the distinguished name (path) of a directory service value object.</summary>
		/// <value>The distinguished name (path) of a directory service value object.</value>
		[DispId(3)]
		string DNString
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(3)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the string to be interpreted. Case-sensitive.</summary>
		/// <value>The string to be interpreted. Case-sensitive.</value>
		[DispId(4)]
		string CaseExactString
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(4)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the string to be interpreted. Case insensitive.</summary>
		/// <value>The string to be interpreted. Case insensitive.</value>
		[DispId(5)]
		string CaseIgnoreString
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(5)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the display or print string.</summary>
		/// <value>The display or print string.</value>
		[DispId(6)]
		string PrintableString
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(6)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the text to be interpreted. Numeric type.</summary>
		/// <value>The text to be interpreted. Numeric type.</value>
		[DispId(7)]
		string NumericString
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(7)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the boolean value.</summary>
		/// <value>The boolean value.</value>
		[DispId(8)]
		bool Boolean
		{
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(8)]
			[param: In, MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>Gets or sets the integer value.</summary>
		/// <value>The integer value.</value>
		[DispId(9)]
		int Integer
		{
			[DispId(9)]
			get;
			[DispId(9)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the variant array of one-byte characters.</summary>
		/// <value>The variant array of one-byte characters.</value>
		[DispId(10)]
		object OctetString
		{
			[DispId(10)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(10)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets the IDispatch interface of the object implementing IADsSecurityDescriptor for this value.</summary>
		/// <value>The IDispatch interface of the object implementing IADsSecurityDescriptor for this value.</value>
		[DispId(11)]
		object SecurityDescriptor
		{
			[DispId(11)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
			[DispId(11)]
			[param: In, MarshalAs(UnmanagedType.IDispatch)]
			set;
		}

		/// <summary>Gets or sets the IDispatch interface of the object implementing IADsLargeInteger for this value.</summary>
		/// <value>The IDispatch interface of the object implementing IADsLargeInteger for this value.</value>
		[DispId(12)]
		object LargeInteger
		{
			[DispId(12)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
			[DispId(12)]
			[param: In, MarshalAs(UnmanagedType.IDispatch)]
			set;
		}

		/// <summary>Gets or sets a date of the VT_DATE type expressed in Coordinated Universal Time (UTC) format.</summary>
		/// <value>A date of the VT_DATE type expressed in Coordinated Universal Time (UTC) format.</value>
		[DispId(13)]
		DateTime UTCTime
		{
			[DispId(13)]
			get;
			[DispId(13)]
			[param: In]
			set;
		}
	}

	/// <summary>
	/// <para>
	/// The <c>IADsPropertyValue2</c> interface is used to represent the value of an IADsPropertyEntry object in any data format, including
	/// new or customer-defined data types. This interface is also useful for handling attribute values for multiple directory services.
	/// </para>
	/// <para>
	/// The IADsPropertyEntry.Values property contains an array of <c>IADsPropertyValue2</c> objects. Each of the IADsPropertyValue objects
	/// contains a single value of the IADsPropertyEntry object. For more information and a code example for creating entirely new property
	/// entries and values, see IADsPropertyList.PutPropertyItem.
	/// </para>
	/// <para>
	/// Before calling the methods of this interfaces, you must call IADs.GetInfo or IADs.GetInfoEx explicitly to load the assigned values of
	/// the object into the cache, if the cache has not been initialized. After modifying the values of the object, you must call
	/// IADs.SetInfo to save the changes to the persistent store of the underlying directory.
	/// </para>
	/// <para>
	/// This interface is more versatile than the IADsPropertyValue because this interface can be used to obtain any data type. The
	/// <c>IADsPropertyValue</c> interface can only be used to obtain a limited number of data types.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The following table lists the <c>lnADsType</c> parameter values in the GetObjectProperty and PutObjectProperty methods to the
	/// corresponding <c>pvProp</c> data type.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description><c>lnADsType</c> value</description>
	/// <description><c>pvProp</c> data type</description>
	/// </listheader>
	/// <item>
	/// <description><c>ADSTYPE_INVALID</c></description>
	/// <description>Not available.</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_DN_STRING</c></description>
	/// <description><c>VT_BSTR</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_CASE_EXACT_STRING</c></description>
	/// <description><c>VT_BSTR</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_CASE_IGNORE_STRING</c></description>
	/// <description><c>VT_BSTR</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_PRINTABLE_STRING</c></description>
	/// <description><c>VT_BSTR</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_NUMERIC_STRING</c></description>
	/// <description><c>VT_BSTR</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_BOOLEAN</c></description>
	/// <description><c>VT_BOOL</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_INTEGER</c></description>
	/// <description><c>VT_I4</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_OCTET_STRING</c></description>
	/// <description><c>VT_ARRAY</c> | <c>VT_UI4</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_UTC_TIME</c></description>
	/// <description><c>VT_DATE</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_LARGE_INTEGER</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsLargeInteger)</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_PROV_SPECIFIC</c></description>
	/// <description><c>VT_ARRAY</c> | <c>VT_UI1</c></description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_OBJECT_CLASS</c></description>
	/// <description>Not available.</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_CASEIGNORE_LIST</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsCaseIgnoreList)</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_OCTET_LIST</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsOctetList)</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_PATH</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsPath)</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_POSTALADDRESS</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsPostalAddress)</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_TIMESTAMP</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsTimestamp)</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_BACKLINK</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsBackLink)</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_TYPEDNAME</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsTypedName)</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_HOLD</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsHold)</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_NETADDRESS</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsNetAddress)</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_REPLICAPOINTER</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsReplicaPointer)</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_FAXNUMBER</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsFaxNumber)</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_EMAIL</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsEmail)</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_NT_SECURITY_DESCRIPTOR</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsSecurityDescriptor)</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_UNKNOWN</c></description>
	/// <description>Not available.</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_DN_WITH_BINARY</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsDNWithBinary)</description>
	/// </item>
	/// <item>
	/// <description><c>ADSTYPE_DN_WITH_STRING</c></description>
	/// <description><c>VT_DISPATCH</c> (IADsDNWithString)</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadspropertyvalue2
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsPropertyValue2")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("306E831C-5BC7-11D1-A3B8-00C04FB950DC"), CoClass(typeof(PropertyValue))]
	public interface IADsPropertyValue2
	{
		/// <summary>The <c>IADsPropertyValue2::GetObjectProperty</c> method retrieves an attribute value.</summary>
		/// <param name="lnADsType">
		/// <para>
		/// Pointer to a variable that, on entry, contains one of the ADSTYPE values that specifies the data format that the value should
		/// be returned.
		/// </para>
		/// <para>
		/// If the data type is not known, set this to <c>ADSTYPE_UNKNOWN</c>. In this case, this method will obtain the attribute value in
		/// the default data type and set this variable to the corresponding ADSTYPE value. If any other <c>ADSTYPE</c> value is
		/// specified, ADSI will return the attribute value only if the data type matches the format of the value.
		/// </para>
		/// </param>
		/// <returns>
		/// Pointer to a <c>VARIANT</c> that receives the requested attribute value. The variant type of this data will depend on the value
		/// returned in <c>lnADsType</c>. For more information and a list of the <c>lnADsType</c> values and corresponding <c>pvProp</c>
		/// variant types, see IADsPropertyValue2.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspropertyvalue2-getobjectproperty HRESULT GetObjectProperty(
		// [in, out] long *lnADsType, [out] VARIANT *pvProp );
		[DispId(1)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object? GetObjectProperty([In, Out] ref ADSTYPE lnADsType);

		/// <summary>The <c>IADsPropertyValue2::PutObjectProperty</c> method sets an attribute value.</summary>
		/// <param name="lnADsType">
		/// Contains one of the ADSTYPE values that specifies the data format of the value set. This value must correspond to the
		/// <c>pvProp</c> variant type. For more information and a list of the <c>lnADsType</c> values and corresponding <c>pvProp</c>
		/// variant types, see IADsPropertyValue2.
		/// </param>
		/// <param name="vProp">
		/// Pointer to a <c>VARIANT</c> that contains the new attribute value. The variant type of this data must correspond to the value in
		/// <c>lnADsType</c>. For more information and a list of the <c>lnADsType</c> values and corresponding <c>pvProp</c> variant types,
		/// see IADsPropertyValue2.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspropertyvalue2-putobjectproperty HRESULT PutObjectProperty(
		// [in] long lnADsType, [in] VARIANT vProp );
		[DispId(2)]
		void PutObjectProperty([In] ADSTYPE lnADsType, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);
	}

	/// <summary>
	/// <para>The <c>IADsReplicaPointer</c> interface provides methods for an ADSI client to access the <c>Replica Pointer</c> attribute.</para>
	/// <para>You can call the property methods of this interface to obtain and modify the attribute.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsreplicapointer
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsReplicaPointer")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("F60FB803-4080-11D1-A3AC-00C04FB950DC"), CoClass(typeof(ReplicaPointer))]
	public interface IADsReplicaPointer
	{
		/// <summary>Gets or sets the name server holding the replica.</summary>
		/// <value>The name server holding the replica.</value>
		[DispId(2)]
		string ServerName
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(2)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the type of the replica (master, secondary, or read-only.)</summary>
		/// <value>The type of the replica (master, secondary, or read-only.)</value>
		[DispId(3)]
		int ReplicaType
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the identification number of the replica.</summary>
		/// <value>The identification number of the replica.</value>
		[DispId(4)]
		int ReplicaNumber
		{
			[DispId(4)]
			get;
			[DispId(4)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the number of existing replicas.</summary>
		/// <value>The number of existing replicas.</value>
		[DispId(5)]
		int Count
		{
			[DispId(5)]
			get;
			[DispId(5)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the network address suggested as a likely reference to a node leading to the name server.</summary>
		/// <value>The network address suggested as a likely reference to a node leading to the name server.</value>
		[DispId(6)]
		object ReplicaAddressHints
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(6)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}
	}

	/// <summary>
	/// The <c>IADsResource</c> interface is a dual interface that inherits from IADs. It is designed to manage an open resource for a file
	/// service across a network.
	/// </summary>
	/// <remarks>
	/// <para>
	/// When a remote user opens a folder or a subfolder on a public share point on the target computer, ADSI considers this folder to be an
	/// open resource and represents it with a resource object that implements this interface.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code example shows how to obtain the collection of resource objects from a file service operations object.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsresource
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsResource")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("34A05B20-4AAB-11CF-AE2C-00AA006EBFB9")]
	public interface IADsResource : IADs
	{
		/// <summary>
		/// The relative name of the object as named within the underlying directory service. This name distinguishes this object from its siblings.
		/// </summary>
		/// <value>The relative name of the object as named within the underlying directory service.</value>
		[DispId(2)]
		new string Name
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The name of the object Schema class.</summary>
		/// <value>The name of the object Schema class.</value>
		[DispId(3)]
		new string Class
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The globally unique identifier of the directory object. The IADs interface converts the GUID from an octet string, as stored on a
		/// directory server, into a string format.
		/// </summary>
		/// <value>The globally unique identifier of the directory object.</value>
		/// <remarks>
		/// <para>
		/// In Active Directory, the GUID returned from GUID is a string of hexadecimals. Use the resultant GUID to bind to the object directly.
		/// </para>
		/// <code language="vb">
		///<![CDATA[
		///Dim x As IADs
		///Set x = GetObject("LDAP://servername/<GUID=xxx>")]]>
		/// </code>
		/// <para>
		/// where xxx is the value returned from the GUID property. For more information, see Using objectGUID to Bind to an Object. Be aware
		/// that if you use a GUID to bind to an object, the ADsPath property method returns values that are different from the normal values
		/// that would be returned if you used a distinguished name (DN) to bind to the same object. For example, the following table lists
		/// the values returned when using the two different binding methods to bind to the same user object.
		/// </para>
		/// </remarks>
		[DispId(4)]
		new string GUID
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The ADsPath string of this object. The string uniquely identifies this object in a network environment. The object can always be
		/// retrieved using this path.
		/// </summary>
		/// <value>The ADsPath string of this object.</value>
		[DispId(5)]
		new string ADsPath
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The ADsPath string of the parent container. Active Directory does not permit the formation of the ADsPath of a given object by
		/// concatenating the Parent and Name properties. While this operation might work in some providers, it is not guaranteed to work for
		/// all implementations. The ADsPath is guaranteed to be valid and should always be used to retrieve an object's interface pointer.
		/// </summary>
		/// <value>The ADsPath string of the parent container.</value>
		[DispId(6)]
		new string Parent
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The ADsPath string of the Schema class object of this object.</summary>
		/// <value>The ADsPath string of the Schema class object of this object.</value>
		[DispId(7)]
		new string Schema
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The <c>IADs::GetInfo</c> method loads into the property cache values of the supported properties of this ADSI object from the
		/// underlying directory store.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>IADs::GetInfo</c> function is called to initialize or refresh the property cache. This is similar to obtaining those
		/// property values of supported properties from the underlying directory store.
		/// </para>
		/// <para>
		/// An uninitialized property cache is not necessarily empty. Call IADs::Put or IADs::PutEx to place a value into the property cache
		/// for any supported property and the cache remains uninitialized.
		/// </para>
		/// <para>
		/// An explicit call to <c>IADs::GetInfo</c> loads or reloads the entire property cache, overwriting all the cached property values.
		/// But an implicit call loads only those properties not set in the cache. Always call <c>IADs::GetInfo</c> explicitly to retrieve
		/// the most current property values of the ADSI object.
		/// </para>
		/// <para>
		/// Because an explicit call to <c>IADs::GetInfo</c> overwrites all the values in the property cache, any change made to the cache
		/// will be lost if an IADs::SetInfo was not invoked before <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>
		/// For an ADSI container object, <c>IADs::GetInfo</c> caches only the property values of the container, but not those of the child objects.
		/// </para>
		/// <para>
		/// It is important to emphasize the differences between the IADs::Get and <c>IADs::GetInfo</c> methods. The former returns values of
		/// a given property from the property cache whereas the latter loads all the supported property values into the property cache from
		/// the underlying directory store.
		/// </para>
		/// <para>The following code example illustrates the differences between the IADs::Get and <c>IADs::GetInfo</c> methods.</para>
		/// <para>
		/// For increased performance, explicitly call IADs::GetInfoEx to refresh specific properties. Also, <c>IADs::GetInfoEx</c> must be
		/// called instead of <c>IADs::GetInfo</c> if the object's operational property values have to be accessed. This function overwrites
		/// any previously cached values of the specified properties.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example uses a computer object served by the WinNT provider. The supported properties include <c>Owner</c>
		/// ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"), <c>Division</c> ("Fabrikam"),
		/// <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping 1"). The default values are shown
		/// in parentheses.
		/// </para>
		/// <para>
		/// The following code example is a client-side script that illustrates the effect of <c>IADs::GetInfo</c> method. The supported
		/// properties include <c>Owner</c> ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"),
		/// <c>Division</c> ("Fabrikam"), <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping
		/// 1"). The default values are shown in parentheses.
		/// </para>
		/// <para>The following code example highlights the effect of Get and GetInfo. For brevity, error checking is omitted.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getinfo HRESULT GetInfo();
		[DispId(8)]
		new void GetInfo();

		/// <summary>The <c>IADs::SetInfo</c> method saves the cached property values of the ADSI object to the underlying directory store.</summary>
		/// <remarks>
		/// <para>
		/// It is important to emphasize the differences between the IADs::Put and <c>IADs::SetInfo</c> methods. The former sets (or
		/// modifies) values of a given property in the property cache whereas the latter propagates the changes from the property cache into
		/// the underlying directory store. Therefore, any property value changes made by <c>IADs::Put</c> will be lost if IADs::GetInfo (or
		/// IADs::GetInfoEx) is invoked before <c>IADs::SetInfo</c> is called.
		/// </para>
		/// <para>
		/// Because <c>IADs::SetInfo</c> sends data across networks, minimize the usage of this method. This reduces the number of trips a
		/// client makes to the server. For example, you should commit all, or most, of the changes to the properties from the cache to the
		/// persistent store in one batch.
		/// </para>
		/// <para>
		/// This guideline pertains only to the relationship of <c>IADs::SetInfo</c> with the IADs::Put method, which differs from the
		/// relationship with the IADs::PutEx method.
		/// </para>
		/// <para>The following code example illustrates the recommended relation between IADs::Put and <c>IADs::SetInfo</c>.</para>
		/// <para>The following code example illustrates what is not recommended between IADs::Put and <c>IADs::SetInfo</c>.</para>
		/// <para>
		/// When used with IADs::PutEx, <c>IADs::SetInfo</c> passes the operational requests specified by control codes, such as
		/// ADS_PROPERTY_UPDATE or ADS_PROPERTY_CLEAR, to the underlying directory store.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following Visual Basic code example uses the <c>IADs::SetInfo</c> method to save the property value of a user to the
		/// underlying directory.
		/// </para>
		/// <para>
		/// The following C++ code example updates property values in the property cache and commits the change to the directory store using
		/// <c>IADs::SetInfo</c>. For brevity, error checking is omitted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-setinfo HRESULT SetInfo();
		[DispId(9)]
		new void SetInfo();

		/// <summary>
		/// The <c>IADs::Get</c> method retrieves a property of a given name from the property cache. The property can be single-valued, or
		/// multi-valued. The property value is represented as either a variant for a single-valued property or a variant array (of
		/// <c>VARIANT</c> or bytes) for a property that allows multiple values.
		/// </summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <returns>
		/// Pointer to a <c>VARIANT</c> that receives the value of the property. For a multi-valued property, <c>pvProp</c> is a variant
		/// array of <c>VARIANT</c>, unless the property is a binary type. In this latter case, <c>pvProp</c> is a variant array of bytes
		/// (VT_U1 or VT_ARRAY). For the property that refers to an object, <c>pvProp</c> is a VT_DISPATCH pointer to the object referred to.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IADs::Get</c> method requires the caller to handle the single- and multi-valued property values differently. Thus, if you
		/// know that the property of interest is either single- or multi-valued, use the <c>IADs::Get</c> method to retrieve the property
		/// value. The following code example shows how you, as a caller, can handle single- and multi-valued properties when calling this method.
		/// </para>
		/// <para>
		/// When a property is uninitialized, calling this method invokes an implicit call to the IADs::GetInfo method. This loads from the
		/// underlying directory store the values of the supported properties that have not been set in the cache. Any subsequent calls to
		/// <c>IADs::Get</c> deals with property values in the cache only. For more information about the behavior of implicit and explicit
		/// calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>
		/// You can also use IADs::GetEx to retrieve property values from the property cache. However, the values are returned as a variant
		/// array of <c>VARIANT</c> s, regardless of whether they are single-valued or multi-valued. That is, ADSI attempts to package the
		/// returned property values in consistent data formats. This saves you, as a caller, the effort of validating the data types when
		/// unsure that the returned data has single or multiple values.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example retrieves the security descriptor for an object using <c>IADs::Get</c>.</para>
		/// <para>The following code example shows how to work with property values of binary data using <c>IADs::Get</c> and IADs::Put.</para>
		/// <para>The following code example shows how to retrieve values of the optional properties of an object using <c>IADs::Get</c>.</para>
		/// <para>The following code example reads attributes with single and multiple values using <c>IADs::Get</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-get HRESULT Get( [in] BSTR bstrName, [out] VARIANT *pvProp );
		[DispId(10)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object? Get([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

		/// <summary>The <c>IADs::Put</c> method sets the values of an attribute in the ADSI attribute cache.</summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <param name="vProp">Contains a <c>VARIANT</c> that specifies the new values of the property.</param>
		/// <remarks>
		/// <para>
		/// The assignment of the new property values, performed by <c>Put</c> takes place in the property cache only. To propagate the
		/// changes to the directory store, call IADs::SetInfo on the object after calling <c>Put</c>.
		/// </para>
		/// <para>
		/// To manipulate the property values beyond a simple assignment, use <c>Put</c> to append or remove a value from an existing array
		/// of attribute values.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use the <c>IADs::Put</c> method.</para>
		/// <para>The following code example shows how to use the <c>IADs::Put</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-put HRESULT Put( [in] BSTR bstrName, [in] VARIANT vProp );
		[DispId(11)]
		new void Put([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);

		/// <summary>
		/// The <c>IADs::GetEx</c> method retrieves, from the property cache, property values of a given attribute. The returned property
		/// values can be single-valued or multi-valued. Unlike the IADs::Get method, the property values are returned as a variant array of
		/// <c>VARIANT</c>, or a variant array of bytes for binary data. A single-valued property is then represented as an array of a single element.
		/// </summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <returns>Pointer to a <c>VARIANT</c> that receives the value, or values, of the property.</returns>
		/// <remarks>
		/// <para>
		/// The IADs::Get and <c>IADs::GetEx</c> methods return a different variant structure for a single-valued property value. If the
		/// property is a string, <c>IADs::Get</c> returns a variant of string (VT_BSTR), whereas <c>IADs::GetEx</c> returns a variant array
		/// of a <c>VARIANT</c> type string with a single element. Thus, if you are not sure that a multi-valued attribute will return a
		/// single value or multiple values, use <c>IADs::GetEx</c>. As it does not require you to validate the result's data structures, you
		/// may want to use <c>IADs::GetEx</c> to retrieve a property when you are not sure whether it has single or multiple values. The
		/// following list compares the two methods.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>IADs::Get version</description>
		/// <description>IADs::GetEx version</description>
		/// </listheader>
		/// <item>
		/// <description/>
		/// <description/>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// Like the IADs::Get method, <c>IADs::GetEx</c> implicitly calls IADs::GetInfo against an uninitialized property cache. For more
		/// information about implicit and explicit calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use <c>IADs::GetEx</c> to retrieve object properties.</para>
		/// <para>The following code example shows how to retrieve values of the optional properties of an object using the IADs::Get method.</para>
		/// <para>The following code example retrieves the "homePhone" property values using <c>IADs::GetEx</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getex HRESULT GetEx( [in] BSTR bstrName, [out] VARIANT
		// *pvProp );
		[DispId(12)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object? GetEx([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

		/// <summary>
		/// The <c>IADs::PutEx</c> method modifies the values of an attribute in the ADSI attribute cache. For example, for properties that
		/// allow multiple values, you can append additional values to an existing set of values, modify the values in the set, remove
		/// specified values from the set, or delete values from the set.
		/// </summary>
		/// <param name="lnControlCode">
		/// Control code that indicates the mode of modification: Append, Replace, Remove, and Delete. For more information and a list of
		/// values, see ADS_PROPERTY_OPERATION_ENUM.
		/// </param>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <param name="vProp">
		/// Contains a <c>VARIANT</c> array that contains the new value or values of the property. A single-valued property is represented as
		/// an array with a single element. If <c>InControlCode</c> is set to <c>ADS_PROPERTY_CLEAR</c>, the value of the property specified
		/// by <c>vProp</c> is irrelevant.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>PutEx</c> is usually used to set values on multi-value attributes. Unlike the IADs::Put method, with <c>PutEx</c>, you are not
		/// required to get the attribute values before you modify them. However, because <c>PutEx</c> only makes changes to attributes
		/// values contained in the ADSI property cache, you must use IADs::SetInfo after each <c>PutEx</c> call in order to commit changes
		/// to the directory.
		/// </para>
		/// <para>
		/// <c>PutEx</c> enables you to append values to an existing set of values in a multi-value attribute using
		/// <c>ADS_PROPERTY_APPEND</c>. When you update, append, or delete values to a multi-value attribute, you must use an array.
		/// </para>
		/// <para>
		/// Active Directory does not accept duplicate values on a multi-valued attribute. If you call <c>PutEx</c> to append a duplicate
		/// value to a multi-valued attribute of an Active Directory object, the <c>PutEx</c> call succeeds, but the duplicate value is ignored.
		/// </para>
		/// <para>
		/// Similarly, if you use <c>PutEx</c> to delete one or more values from a multi-valued property of an Active Directory object, the
		/// operation succeeds, that is, it will not produce an error, even if any or all of the specified values are not set on the property.
		/// </para>
		/// <para>
		/// <c>Note</c>  The WinNT provider ignores the value passed by the <c>InControlCode</c> argument and performs the equivalent of an
		/// <c>ADS_PROPERTY_UPDATE</c> request when using <c>PutEx</c>.
		/// </para>
		/// <para></para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use the <c>IADs.PutEx</c> method.</para>
		/// <para>The following code example shows how to use the <c>IADs::PutEx</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-putex HRESULT PutEx( [in] long lnControlCode, [in] BSTR
		// bstrName, [in] VARIANT vProp );
		[DispId(13)]
		new void PutEx([In] ADS_PROPERTY_OPERATION lnControlCode, [In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);

		/// <summary>
		/// The <c>IADs::GetInfoEx</c> method loads the values of specified properties of the ADSI object from the underlying directory store
		/// into the property cache.
		/// </summary>
		/// <param name="vProperties">
		/// Array of null-terminated Unicode string entries that list the properties to load into the Active Directory property cache. Each
		/// property name must match one in this object's schema class definition.
		/// </param>
		/// <param name="lnReserved">Reserved for future use. Must be set to zero.</param>
		/// <remarks>
		/// <para>
		/// The <c>IADs::GetInfoEx</c> method overwrites any previously cached values of the specified properties with those in the directory
		/// store. Therefore, any change made to the cache will be lost if IADs::SetInfo was not invoked before the call to <c>IADs::GetInfoEx</c>.
		/// </para>
		/// <para>
		/// Use <c>IADs::GetInfoEx</c> to refresh values of the selected property in the property cache of an ADSI object. Use IADs::GetInfo
		/// to refresh all the property values.
		/// </para>
		/// <para>
		/// For an ADSI container object, <c>IADs::GetInfoEx</c> caches only the property values of the container, but not those of the child objects.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to use the <c>IADs::GetInfoEx</c> to obtain values of the selected properties, assuming that
		/// the desired property values can be found in the directory.
		/// </para>
		/// <para>
		/// The following code example shows how to use the <c>IADs::GetInfoEx</c> to obtain values of the selected properties, assuming that
		/// the desired property values can be found in the directory. For brevity, error checking has been omitted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getinfoex HRESULT GetInfoEx( [in] VARIANT vProperties, [in]
		// long lnReserved );
		[DispId(14)]
		new void GetInfoEx([In, MarshalAs(UnmanagedType.Struct)] object vProperties, [In] int lnReserved = 0);

		/// <summary>Gets the name of the user who opened the resource.</summary>
		/// <value>The name of the user who opened the resource.</value>
		[DispId(15)]
		string User
		{
			[DispId(15)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the ADsPath of the user object for the user who opened the resource.</summary>
		/// <value>The ADsPath of the user object for the user who opened the resource.</value>
		[DispId(16)]
		string UserPath
		{
			[DispId(16)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the file system path of the opened resource.</summary>
		/// <value>The file system path of the opened resource.</value>
		[DispId(17)]
		string Path
		{
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the number of locks on the resource.</summary>
		/// <value>The number of locks on the resource.</value>
		[DispId(18)]
		int LockCount
		{
			[DispId(18)]
			get;
		}
	}

	/// <summary>The <c>IADsSecurityDescriptor</c> interface provides access to properties on an ADSI security descriptor object.</summary>
	/// <remarks>
	/// <para>
	/// Use this interface to examine and change the access controls to an Active Directory directory service object. You can also use it to
	/// create copies of a security descriptor. To get this interface, use the IADs.Get method to obtain the <c>ntSecurityDescriptor</c>
	/// attribute of the object. For more information about how to create a new security descriptor and set it on an object, see Creating a
	/// Security Descriptor for a New Directory Object and Null DACLs and Empty DACLs.
	/// </para>
	/// <para>
	/// Often, it is not possible to modify all portions of the security descriptor. For example, if the current user has full control of an
	/// object, but is not an administrator and does not own the object, the user can modify the DACL, but cannot modify the owner. This will
	/// cause an error when the <c>ntSecurityDescriptor</c> is updated. To avoid this problem, the IADsObjectOptions interface can be used to
	/// specify the specific portions of the security descriptor that should be modified.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example shows how to use the IADsObjectOptions interface to only modify specific portions of the security descriptor.
	/// </para>
	/// <para>The following code example shows how to display data from a security descriptor.</para>
	/// <para>The following code example shows how to display data from a security descriptor of a directory object.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadssecuritydescriptor
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsSecurityDescriptor")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("B8C787CA-9BDD-11D0-852C-00C04FD8D503"), CoClass(typeof(SecurityDescriptor))]
	public interface IADsSecurityDescriptor
	{
		/// <summary>
		/// Gets or sets the Revision level of the security descriptor. This value is taken from the Win32 ACL_REVISION_INFORMATION
		/// structure. All ACEs in an ACL must be at the same revision level.
		/// </summary>
		/// <value>
		/// Revision level of the security descriptor. This value is taken from the Win32 <see cref="ACL_REVISION_INFORMATION"/> structure.
		/// All ACEs in an ACL must be at the same revision level.
		/// </value>
		[DispId(2)]
		uint Revision
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		/// <summary>
		/// Gets or sets the flags that qualify the meaning of the security descriptor. Values are taken from the Win32
		/// SECURITY_DESCRIPTOR_CONTROL structure..
		/// </summary>
		/// <value>
		/// The flags that qualify the meaning of the security descriptor. Values are taken from the Win32 <see
		/// cref="SECURITY_DESCRIPTOR_CONTROL"/> structure..
		/// </value>
		[DispId(3)]
		SECURITY_DESCRIPTOR_CONTROL Control
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the object owner.</summary>
		/// <value>The object owner.</value>
		[DispId(4)]
		string Owner
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(4)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// Gets or sets a flag of the BOOL type that indicates that the owner data is derived from a default mechanism, rather than being
		/// explicitly provided by the original provider of the security descriptor.
		/// </summary>
		/// <value>
		/// A flag of the BOOL type that indicates that the owner data is derived from a default mechanism, rather than being explicitly
		/// provided by the original provider of the security descriptor.
		/// </value>
		[DispId(5)]
		bool OwnerDefaulted
		{
			[DispId(5)]
			get;
			[DispId(5)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the group to which the owner's security ID belongs.</summary>
		/// <value>The group to which the owner's security ID belongs.</value>
		[DispId(6)]
		string Group
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(6)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// Gets or sets a flag of the BOOL type that indicates if the group data is derived from a default mechanism, rather than being
		/// explicitly provided by the original provider of the security descriptor.
		/// </summary>
		/// <value>
		/// A flag of the BOOL type that indicates if the group data is derived from a default mechanism, rather than being explicitly
		/// provided by the original provider of the security descriptor.
		/// </value>
		[DispId(7)]
		bool GroupDefaulted
		{
			[DispId(7)]
			get;
			[DispId(7)]
			[param: In]
			set;
		}

		/// <summary>
		/// Gets or sets the Discretionary access-control list (DACL) that specifies the types of access granted to the object for specified
		/// users and groups. For more information about DACLs, see Null DACLs and Empty DACLs.
		/// </summary>
		/// <value>
		/// Discretionary access-control list (DACL) that specifies the types of access granted to the object for specified users and groups.
		/// For more information about DACLs, see Null DACLs and Empty DACLs.
		/// </value>
		[DispId(8)]
		object DiscretionaryAcl
		{
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
			[DispId(8)]
			[param: In, MarshalAs(UnmanagedType.IDispatch)]
			set;
		}

		/// <summary>
		/// Gets or sets a flag of the BOOL type that indicates if the DACL is derived from a default mechanism, rather than being provided
		/// explicitly by the original provider of the security descriptor. For example, if an object's creator does not specify a DACL, the
		/// object receives the default DACL from the creator's access token. This flag can affect how the system treats the DACL, with
		/// respect to ACE inheritance. The system ignores this flag if the SE_DACL_PRESENT flag is not set.
		/// </summary>
		/// <value>
		/// A flag of the BOOL type that indicates if the DACL is derived from a default mechanism, rather than being provided explicitly by
		/// the original provider of the security descriptor. For example, if an object's creator does not specify a DACL, the object
		/// receives the default DACL from the creator's access token. This flag can affect how the system treats the DACL, with respect to
		/// ACE inheritance. The system ignores this flag if the SE_DACL_PRESENT flag is not set.
		/// </value>
		[DispId(9)]
		bool DaclDefaulted
		{
			[DispId(9)]
			get;
			[DispId(9)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the system access-control list used to generate audit records for the object.</summary>
		/// <value>The system access-control list used to generate audit records for the object.</value>
		[DispId(10)]
		object SystemAcl
		{
			[DispId(10)]
			[return: MarshalAs(UnmanagedType.IDispatch)]
			get;
			[DispId(10)]
			[param: In, MarshalAs(UnmanagedType.IDispatch)]
			set;
		}

		/// <summary>
		/// Gets or sets a flag of the BOOL type that indicates that the SACL is derived from a default mechanism, rather than being
		/// explicitly provided by the original provider of the security descriptor. This flag can affect how the system handles the SACL,
		/// with respect to ACE inheritance. The system ignores this flag if the SE_SACL_PRESENT flag is not set.
		/// </summary>
		/// <value>
		/// A flag of the BOOL type that indicates that the SACL is derived from a default mechanism, rather than being explicitly provided
		/// by the original provider of the security descriptor. This flag can affect how the system handles the SACL, with respect to ACE
		/// inheritance. The system ignores this flag if the SE_SACL_PRESENT flag is not set.
		/// </value>
		[DispId(11)]
		bool SaclDefaulted
		{
			[DispId(11)]
			get;
			[DispId(11)]
			[param: In]
			set;
		}

		/// <summary>
		/// The <c>IADsSecurityDescriptor::CopySecurityDescriptor</c> method copies an ADSI security descriptor object that holds security
		/// data about an object.
		/// </summary>
		/// <returns>Pointer to a pointer to a security descriptor object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadssecuritydescriptor-copysecuritydescriptor HRESULT
		// CopySecurityDescriptor( [out] IDispatch **ppSecurityDescriptor );
		[DispId(12)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object CopySecurityDescriptor();
	}

	/// <summary>
	/// The <c>IADsSecurityUtility</c> interface is used to get, set, or retrieve the security descriptor on a file, fileshare, or registry
	/// key. You can also use it to convert the security descriptor to or from raw or hexadecimal mode and you can limit the scope of the
	/// security descriptor data retrieved or set by indicating whether you want it for the owner, group, DACL, or SACL.
	/// </summary>
	/// <remarks>
	/// <para>
	/// To read the system access-control list (SACL) of a file or directory, the <c>SE_SECURITY_NAME</c> privilege must be enabled for the
	/// calling process. For more information about retrieving the SACL for an object, see Retrieving an Object's SACL.
	/// </para>
	/// <para>
	/// For more information and a code example that shows how to use the <c>IADsSecurityUtility</c> interface to add an ACE to a file, see
	/// Example Code for Adding an ACE to a File.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadssecurityutility
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsSecurityUtility")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("A63251B2-5F21-474B-AB52-4A8EFAD10895"), CoClass(typeof(ADsSecurityUtility))]
	public interface IADsSecurityUtility
	{
		/// <summary>
		/// The <c>GetSecurityDescriptor</c> method retrieves a security descriptor for the specified file, fileshare, or registry key.
		/// </summary>
		/// <param name="varPath">
		/// <para>A <c>VARIANT</c> string that contains the path of the object to retrieve the security descriptor for.</para>
		/// <para>File</para>
		/// <para>A valid file path syntax. For example: "c:\specs\public\adxml.doc" or "\adsi\public\dsclient.exe".</para>
		/// <para>File share</para>
		/// <para>A valid file path syntax for a file share. For example: "\adsi\public".</para>
		/// <para>Registry key</para>
		/// <para>A valid registry syntax. For example, "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\ADs".</para>
		/// </param>
		/// <param name="lPathFormat">Contains one of the ADS_PATHTYPE_ENUM values which specifies the format of the <c>varPath</c> parameter.</param>
		/// <param name="lFormat">
		/// <para>
		/// Contains one of the ADS_SD_FORMAT_ENUM values which specifies the format of the security descriptor returned in the
		/// <c>pVariant</c> parameter. The following list identifies the possible values for this parameter and the format that is supplied
		/// in the <c>pVariant</c> parameter.
		/// </para>
		/// <para>ADS_SD_FORMAT_IID</para>
		/// <para><c>pVariant</c> receives a <c>VT_DISPATCH</c> that can be queried for the IADsSecurityDescriptor interface.</para>
		/// <para>ADS_SD_FORMAT_RAW</para>
		/// <para>
		/// <c>pVariant</c> receives a <c>VT_I1</c> | <c>VT_ARRAY</c> that contains the security descriptor in raw data format. This is in
		/// the format of a SECURITY_DESCRIPTOR structure.
		/// </para>
		/// <para>ADS_SD_FORMAT_HEXSTRING</para>
		/// <para><c>pVariant</c> receives a <c>VT_BSTR</c> that contains the raw security descriptor in hex encode string format.</para>
		/// </param>
		/// <returns>
		/// Pointer to a <c>VARIANT</c> that receives the returned security descriptor. The format of the retrieved security descriptor is
		/// specified by the <c>lFormat</c> parameter.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadssecurityutility-getsecuritydescriptor HRESULT
		// GetSecurityDescriptor( [in] VARIANT varPath, [in] long lPathFormat, [in] long lFormat, [out] VARIANT *pVariant );
		[DispId(2)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetSecurityDescriptor([In, MarshalAs(UnmanagedType.Struct)] object varPath, [In] ADS_PATHTYPE lPathFormat, [In] ADS_SD_FORMAT lFormat);

		/// <summary>
		/// The <c>SetSecurityDescriptor</c> method sets the security descriptor for the specified file, file share, or registry key.
		/// </summary>
		/// <param name="varPath">
		/// <para>
		/// A <c>VARIANT</c> string that contains the path of the object to set the security descriptor for. Possible values are listed in
		/// the following list.
		/// </para>
		/// <para>File</para>
		/// <para>A valid file path syntax. For example: "c:\specs\public\adxml.doc" or "\adsi\public\dsclient.exe".</para>
		/// <para>File share</para>
		/// <para>A valid file path syntax for a file share. For example: "\adsi\public".</para>
		/// <para>Registry key</para>
		/// <para>A valid registry syntax. For example, "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\ADs".</para>
		/// </param>
		/// <param name="lPathFormat">Contains one of the ADS_PATHTYPE_ENUM values which specifies the format of the <c>varPath</c> parameter.</param>
		/// <param name="varData">
		/// A <c>VARIANT</c> that contains the new security descriptor. The format of the security descriptor is specified by the
		/// <c>lDataFormat</c> parameter.
		/// </param>
		/// <param name="lDataFormat">
		/// Contains one of the ADS_SD_FORMAT_ENUM values which specifies the format of the security descriptor contained in the
		/// <c>VarData</c> parameter. The following list identifies the possible values for this parameter and the format of the
		/// <c>VarData</c> parameter.
		/// </param>
		/// <remarks>
		/// <para>Access control entries must appear in the following order in a security descriptor's access control list:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Access-denied ACEs that apply to the object itself</description>
		/// </item>
		/// <item>
		/// <description>Access-denied ACEs that apply to a child of the object, such as a property set or property</description>
		/// </item>
		/// <item>
		/// <description>Access-allowed ACEs that apply to the object itself</description>
		/// </item>
		/// <item>
		/// <description>Access-allowed ACEs that apply to a child of the object, such as a property set or property</description>
		/// </item>
		/// <item>
		/// <description>All inherited ACEs</description>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>The following code example shows how to set a security descriptor for a file.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadssecurityutility-setsecuritydescriptor HRESULT
		// SetSecurityDescriptor( [in] VARIANT varPath, [in] long lPathFormat, [in] VARIANT varData, [in] long lDataFormat );
		[DispId(3)]
		void SetSecurityDescriptor([In, MarshalAs(UnmanagedType.Struct)] object varPath, [In] ADS_PATHTYPE lPathFormat,
			[In, MarshalAs(UnmanagedType.Struct)] object varData, [In] ADS_SD_FORMAT lDataFormat);

		/// <summary>The <c>ConvertSecurityDescriptor</c> method converts a security descriptor from one format to another.</summary>
		/// <param name="varSD">
		/// A <c>VARIANT</c> that contains the security descriptor to convert. The format of this <c>VARIANT</c> is defined by the
		/// <c>lDataFormat</c> parameter.
		/// </param>
		/// <param name="lDataFormat">
		/// <para>
		/// Contains one of the ADS_SD_FORMAT_ENUM values which specifies the format of the security descriptor in the <c>varSD</c>
		/// parameter. The following list identifies the possible values for this parameter and the format of the <c>varSD</c> parameter.
		/// </para>
		/// <para>ADS_SD_FORMAT_IID</para>
		/// <para><c>varSD</c> contains a <c>VT_DISPATCH</c> that can be queried for the IADsSecurityDescriptor interface.</para>
		/// <para>ADS_SD_FORMAT_RAW</para>
		/// <para>
		/// <c>varSD</c> contains a <c>VT_I1</c> | <c>VT_ARRAY</c> that contains the security descriptor in raw data format. This is in the
		/// format of a SECURITY_DESCRIPTOR structure.
		/// </para>
		/// <para>ADS_SD_FORMAT_HEXSTRING</para>
		/// <para><c>varSD</c> contains a <c>VT_BSTR</c> that contains the raw security descriptor in hex encode string format.</para>
		/// </param>
		/// <param name="lOutFormat">
		/// <para>
		/// Contains one of the ADS_SD_FORMAT_ENUM values which specifies the format that the security descriptor should be converted to. The
		/// following list identifies the possible values for this parameter and the format of the <c>pvResult</c> parameter.
		/// </para>
		/// <para>ADS_SD_FORMAT_IID</para>
		/// <para><c>pvResult</c> receives a <c>VT_DISPATCH</c> that can be queried for the IADsSecurityDescriptor interface.</para>
		/// <para>ADS_SD_FORMAT_RAW</para>
		/// <para>
		/// <c>pvResult</c> receives a <c>VT_I1</c> | <c>VT_ARRAY</c> that contains the security descriptor in raw data format. This is in
		/// the format of a SECURITY_DESCRIPTOR structure.
		/// </para>
		/// <para>ADS_SD_FORMAT_HEXSTRING</para>
		/// <para><c>pvResult</c> receives a <c>VT_BSTR</c> that contains the raw security descriptor in hex encode string format.</para>
		/// </param>
		/// <returns>
		/// Pointer to a <c>VARIANT</c> that receives the converted security descriptor. The format of the retrieved security descriptor is
		/// specified by the <c>lOutFormat</c> parameter.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadssecurityutility-convertsecuritydescriptor HRESULT
		// ConvertSecurityDescriptor( [in] VARIANT varSD, [in] long lDataFormat, [in] long lOutFormat, [out] VARIANT *pResult );
		[DispId(4)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object ConvertSecurityDescriptor([In, MarshalAs(UnmanagedType.Struct)] object varSD, [In] ADS_SD_FORMAT lDataFormat, [In] ADS_SD_FORMAT lOutFormat);

		/// <summary>
		/// Determines which elements of the security descriptor to retrieve or set. This property must be set prior to calling
		/// IADsSecurityUtility.GetSecurityDescriptor or IADsSecurityUtility.SetSecurityDescriptor.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadssecurityutility-get_securitymask HRESULT get_SecurityMask(
		// long *retval );
		[DispId(5)]
		int SecurityMask
		{
			[DispId(5)]
			get;
			[DispId(5)]
			[param: In]
			set;
		}
	}

	/// <summary>
	/// The <c>IADsService</c> interface is a dual interface that inherits from IADs. It is designed to maintain data about system services
	/// running on a host computer. Examples of such services include "FAX" for Microsoft Fax Service, "RemoteAccess" for Routing and
	/// RemoteAccess Service, and "seclogon" for Secondary Logon Service. Examples of the data about any system service include the path to
	/// the executable file on the host computer, the type of the service, other services or load group required to run a particular service,
	/// and others. <c>IADsService</c> exposes several properties to represent such data.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The system services are published in the underlying directory. Some may be running, others may not. To verify the status or to
	/// operate on any of the services, use the properties and methods of the IADsServiceOperations interface.
	/// </para>
	/// <para>
	/// File service is a special case of the system service. The IADsFileService and IADsFileServiceOperations interfaces support additional
	/// features unique to file services.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// To identify services available on a host computer, first bind to the computer and then enumerate the services available on that
	/// computer. The following code example shows how to do this.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsservice
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsService")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("68AF66E0-31CA-11CF-A98A-00AA006BC149")]
	public interface IADsService : IADs
	{
		/// <summary>
		/// The relative name of the object as named within the underlying directory service. This name distinguishes this object from its siblings.
		/// </summary>
		/// <value>The relative name of the object as named within the underlying directory service.</value>
		[DispId(2)]
		new string Name
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The name of the object Schema class.</summary>
		/// <value>The name of the object Schema class.</value>
		[DispId(3)]
		new string Class
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The globally unique identifier of the directory object. The IADs interface converts the GUID from an octet string, as stored on a
		/// directory server, into a string format.
		/// </summary>
		/// <value>The globally unique identifier of the directory object.</value>
		/// <remarks>
		/// <para>
		/// In Active Directory, the GUID returned from GUID is a string of hexadecimals. Use the resultant GUID to bind to the object directly.
		/// </para>
		/// <code language="vb">
		///<![CDATA[
		///Dim x As IADs
		///Set x = GetObject("LDAP://servername/<GUID=xxx>")]]>
		/// </code>
		/// <para>
		/// where xxx is the value returned from the GUID property. For more information, see Using objectGUID to Bind to an Object. Be aware
		/// that if you use a GUID to bind to an object, the ADsPath property method returns values that are different from the normal values
		/// that would be returned if you used a distinguished name (DN) to bind to the same object. For example, the following table lists
		/// the values returned when using the two different binding methods to bind to the same user object.
		/// </para>
		/// </remarks>
		[DispId(4)]
		new string GUID
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The ADsPath string of this object. The string uniquely identifies this object in a network environment. The object can always be
		/// retrieved using this path.
		/// </summary>
		/// <value>The ADsPath string of this object.</value>
		[DispId(5)]
		new string ADsPath
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The ADsPath string of the parent container. Active Directory does not permit the formation of the ADsPath of a given object by
		/// concatenating the Parent and Name properties. While this operation might work in some providers, it is not guaranteed to work for
		/// all implementations. The ADsPath is guaranteed to be valid and should always be used to retrieve an object's interface pointer.
		/// </summary>
		/// <value>The ADsPath string of the parent container.</value>
		[DispId(6)]
		new string Parent
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The ADsPath string of the Schema class object of this object.</summary>
		/// <value>The ADsPath string of the Schema class object of this object.</value>
		[DispId(7)]
		new string Schema
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The <c>IADs::GetInfo</c> method loads into the property cache values of the supported properties of this ADSI object from the
		/// underlying directory store.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>IADs::GetInfo</c> function is called to initialize or refresh the property cache. This is similar to obtaining those
		/// property values of supported properties from the underlying directory store.
		/// </para>
		/// <para>
		/// An uninitialized property cache is not necessarily empty. Call IADs::Put or IADs::PutEx to place a value into the property cache
		/// for any supported property and the cache remains uninitialized.
		/// </para>
		/// <para>
		/// An explicit call to <c>IADs::GetInfo</c> loads or reloads the entire property cache, overwriting all the cached property values.
		/// But an implicit call loads only those properties not set in the cache. Always call <c>IADs::GetInfo</c> explicitly to retrieve
		/// the most current property values of the ADSI object.
		/// </para>
		/// <para>
		/// Because an explicit call to <c>IADs::GetInfo</c> overwrites all the values in the property cache, any change made to the cache
		/// will be lost if an IADs::SetInfo was not invoked before <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>
		/// For an ADSI container object, <c>IADs::GetInfo</c> caches only the property values of the container, but not those of the child objects.
		/// </para>
		/// <para>
		/// It is important to emphasize the differences between the IADs::Get and <c>IADs::GetInfo</c> methods. The former returns values of
		/// a given property from the property cache whereas the latter loads all the supported property values into the property cache from
		/// the underlying directory store.
		/// </para>
		/// <para>The following code example illustrates the differences between the IADs::Get and <c>IADs::GetInfo</c> methods.</para>
		/// <para>
		/// For increased performance, explicitly call IADs::GetInfoEx to refresh specific properties. Also, <c>IADs::GetInfoEx</c> must be
		/// called instead of <c>IADs::GetInfo</c> if the object's operational property values have to be accessed. This function overwrites
		/// any previously cached values of the specified properties.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example uses a computer object served by the WinNT provider. The supported properties include <c>Owner</c>
		/// ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"), <c>Division</c> ("Fabrikam"),
		/// <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping 1"). The default values are shown
		/// in parentheses.
		/// </para>
		/// <para>
		/// The following code example is a client-side script that illustrates the effect of <c>IADs::GetInfo</c> method. The supported
		/// properties include <c>Owner</c> ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"),
		/// <c>Division</c> ("Fabrikam"), <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping
		/// 1"). The default values are shown in parentheses.
		/// </para>
		/// <para>The following code example highlights the effect of Get and GetInfo. For brevity, error checking is omitted.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getinfo HRESULT GetInfo();
		[DispId(8)]
		new void GetInfo();

		/// <summary>The <c>IADs::SetInfo</c> method saves the cached property values of the ADSI object to the underlying directory store.</summary>
		/// <remarks>
		/// <para>
		/// It is important to emphasize the differences between the IADs::Put and <c>IADs::SetInfo</c> methods. The former sets (or
		/// modifies) values of a given property in the property cache whereas the latter propagates the changes from the property cache into
		/// the underlying directory store. Therefore, any property value changes made by <c>IADs::Put</c> will be lost if IADs::GetInfo (or
		/// IADs::GetInfoEx) is invoked before <c>IADs::SetInfo</c> is called.
		/// </para>
		/// <para>
		/// Because <c>IADs::SetInfo</c> sends data across networks, minimize the usage of this method. This reduces the number of trips a
		/// client makes to the server. For example, you should commit all, or most, of the changes to the properties from the cache to the
		/// persistent store in one batch.
		/// </para>
		/// <para>
		/// This guideline pertains only to the relationship of <c>IADs::SetInfo</c> with the IADs::Put method, which differs from the
		/// relationship with the IADs::PutEx method.
		/// </para>
		/// <para>The following code example illustrates the recommended relation between IADs::Put and <c>IADs::SetInfo</c>.</para>
		/// <para>The following code example illustrates what is not recommended between IADs::Put and <c>IADs::SetInfo</c>.</para>
		/// <para>
		/// When used with IADs::PutEx, <c>IADs::SetInfo</c> passes the operational requests specified by control codes, such as
		/// ADS_PROPERTY_UPDATE or ADS_PROPERTY_CLEAR, to the underlying directory store.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following Visual Basic code example uses the <c>IADs::SetInfo</c> method to save the property value of a user to the
		/// underlying directory.
		/// </para>
		/// <para>
		/// The following C++ code example updates property values in the property cache and commits the change to the directory store using
		/// <c>IADs::SetInfo</c>. For brevity, error checking is omitted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-setinfo HRESULT SetInfo();
		[DispId(9)]
		new void SetInfo();

		/// <summary>
		/// The <c>IADs::Get</c> method retrieves a property of a given name from the property cache. The property can be single-valued, or
		/// multi-valued. The property value is represented as either a variant for a single-valued property or a variant array (of
		/// <c>VARIANT</c> or bytes) for a property that allows multiple values.
		/// </summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <returns>
		/// Pointer to a <c>VARIANT</c> that receives the value of the property. For a multi-valued property, <c>pvProp</c> is a variant
		/// array of <c>VARIANT</c>, unless the property is a binary type. In this latter case, <c>pvProp</c> is a variant array of bytes
		/// (VT_U1 or VT_ARRAY). For the property that refers to an object, <c>pvProp</c> is a VT_DISPATCH pointer to the object referred to.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IADs::Get</c> method requires the caller to handle the single- and multi-valued property values differently. Thus, if you
		/// know that the property of interest is either single- or multi-valued, use the <c>IADs::Get</c> method to retrieve the property
		/// value. The following code example shows how you, as a caller, can handle single- and multi-valued properties when calling this method.
		/// </para>
		/// <para>
		/// When a property is uninitialized, calling this method invokes an implicit call to the IADs::GetInfo method. This loads from the
		/// underlying directory store the values of the supported properties that have not been set in the cache. Any subsequent calls to
		/// <c>IADs::Get</c> deals with property values in the cache only. For more information about the behavior of implicit and explicit
		/// calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>
		/// You can also use IADs::GetEx to retrieve property values from the property cache. However, the values are returned as a variant
		/// array of <c>VARIANT</c> s, regardless of whether they are single-valued or multi-valued. That is, ADSI attempts to package the
		/// returned property values in consistent data formats. This saves you, as a caller, the effort of validating the data types when
		/// unsure that the returned data has single or multiple values.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example retrieves the security descriptor for an object using <c>IADs::Get</c>.</para>
		/// <para>The following code example shows how to work with property values of binary data using <c>IADs::Get</c> and IADs::Put.</para>
		/// <para>The following code example shows how to retrieve values of the optional properties of an object using <c>IADs::Get</c>.</para>
		/// <para>The following code example reads attributes with single and multiple values using <c>IADs::Get</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-get HRESULT Get( [in] BSTR bstrName, [out] VARIANT *pvProp );
		[DispId(10)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object? Get([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

		/// <summary>The <c>IADs::Put</c> method sets the values of an attribute in the ADSI attribute cache.</summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <param name="vProp">Contains a <c>VARIANT</c> that specifies the new values of the property.</param>
		/// <remarks>
		/// <para>
		/// The assignment of the new property values, performed by <c>Put</c> takes place in the property cache only. To propagate the
		/// changes to the directory store, call IADs::SetInfo on the object after calling <c>Put</c>.
		/// </para>
		/// <para>
		/// To manipulate the property values beyond a simple assignment, use <c>Put</c> to append or remove a value from an existing array
		/// of attribute values.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use the <c>IADs::Put</c> method.</para>
		/// <para>The following code example shows how to use the <c>IADs::Put</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-put HRESULT Put( [in] BSTR bstrName, [in] VARIANT vProp );
		[DispId(11)]
		new void Put([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);

		/// <summary>
		/// The <c>IADs::GetEx</c> method retrieves, from the property cache, property values of a given attribute. The returned property
		/// values can be single-valued or multi-valued. Unlike the IADs::Get method, the property values are returned as a variant array of
		/// <c>VARIANT</c>, or a variant array of bytes for binary data. A single-valued property is then represented as an array of a single element.
		/// </summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <returns>Pointer to a <c>VARIANT</c> that receives the value, or values, of the property.</returns>
		/// <remarks>
		/// <para>
		/// The IADs::Get and <c>IADs::GetEx</c> methods return a different variant structure for a single-valued property value. If the
		/// property is a string, <c>IADs::Get</c> returns a variant of string (VT_BSTR), whereas <c>IADs::GetEx</c> returns a variant array
		/// of a <c>VARIANT</c> type string with a single element. Thus, if you are not sure that a multi-valued attribute will return a
		/// single value or multiple values, use <c>IADs::GetEx</c>. As it does not require you to validate the result's data structures, you
		/// may want to use <c>IADs::GetEx</c> to retrieve a property when you are not sure whether it has single or multiple values. The
		/// following list compares the two methods.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>IADs::Get version</description>
		/// <description>IADs::GetEx version</description>
		/// </listheader>
		/// <item>
		/// <description/>
		/// <description/>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// Like the IADs::Get method, <c>IADs::GetEx</c> implicitly calls IADs::GetInfo against an uninitialized property cache. For more
		/// information about implicit and explicit calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use <c>IADs::GetEx</c> to retrieve object properties.</para>
		/// <para>The following code example shows how to retrieve values of the optional properties of an object using the IADs::Get method.</para>
		/// <para>The following code example retrieves the "homePhone" property values using <c>IADs::GetEx</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getex HRESULT GetEx( [in] BSTR bstrName, [out] VARIANT
		// *pvProp );
		[DispId(12)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object? GetEx([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

		/// <summary>
		/// The <c>IADs::PutEx</c> method modifies the values of an attribute in the ADSI attribute cache. For example, for properties that
		/// allow multiple values, you can append additional values to an existing set of values, modify the values in the set, remove
		/// specified values from the set, or delete values from the set.
		/// </summary>
		/// <param name="lnControlCode">
		/// Control code that indicates the mode of modification: Append, Replace, Remove, and Delete. For more information and a list of
		/// values, see ADS_PROPERTY_OPERATION_ENUM.
		/// </param>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <param name="vProp">
		/// Contains a <c>VARIANT</c> array that contains the new value or values of the property. A single-valued property is represented as
		/// an array with a single element. If <c>InControlCode</c> is set to <c>ADS_PROPERTY_CLEAR</c>, the value of the property specified
		/// by <c>vProp</c> is irrelevant.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>PutEx</c> is usually used to set values on multi-value attributes. Unlike the IADs::Put method, with <c>PutEx</c>, you are not
		/// required to get the attribute values before you modify them. However, because <c>PutEx</c> only makes changes to attributes
		/// values contained in the ADSI property cache, you must use IADs::SetInfo after each <c>PutEx</c> call in order to commit changes
		/// to the directory.
		/// </para>
		/// <para>
		/// <c>PutEx</c> enables you to append values to an existing set of values in a multi-value attribute using
		/// <c>ADS_PROPERTY_APPEND</c>. When you update, append, or delete values to a multi-value attribute, you must use an array.
		/// </para>
		/// <para>
		/// Active Directory does not accept duplicate values on a multi-valued attribute. If you call <c>PutEx</c> to append a duplicate
		/// value to a multi-valued attribute of an Active Directory object, the <c>PutEx</c> call succeeds, but the duplicate value is ignored.
		/// </para>
		/// <para>
		/// Similarly, if you use <c>PutEx</c> to delete one or more values from a multi-valued property of an Active Directory object, the
		/// operation succeeds, that is, it will not produce an error, even if any or all of the specified values are not set on the property.
		/// </para>
		/// <para>
		/// <c>Note</c>  The WinNT provider ignores the value passed by the <c>InControlCode</c> argument and performs the equivalent of an
		/// <c>ADS_PROPERTY_UPDATE</c> request when using <c>PutEx</c>.
		/// </para>
		/// <para></para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use the <c>IADs.PutEx</c> method.</para>
		/// <para>The following code example shows how to use the <c>IADs::PutEx</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-putex HRESULT PutEx( [in] long lnControlCode, [in] BSTR
		// bstrName, [in] VARIANT vProp );
		[DispId(13)]
		new void PutEx([In] ADS_PROPERTY_OPERATION lnControlCode, [In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);

		/// <summary>
		/// The <c>IADs::GetInfoEx</c> method loads the values of specified properties of the ADSI object from the underlying directory store
		/// into the property cache.
		/// </summary>
		/// <param name="vProperties">
		/// Array of null-terminated Unicode string entries that list the properties to load into the Active Directory property cache. Each
		/// property name must match one in this object's schema class definition.
		/// </param>
		/// <param name="lnReserved">Reserved for future use. Must be set to zero.</param>
		/// <remarks>
		/// <para>
		/// The <c>IADs::GetInfoEx</c> method overwrites any previously cached values of the specified properties with those in the directory
		/// store. Therefore, any change made to the cache will be lost if IADs::SetInfo was not invoked before the call to <c>IADs::GetInfoEx</c>.
		/// </para>
		/// <para>
		/// Use <c>IADs::GetInfoEx</c> to refresh values of the selected property in the property cache of an ADSI object. Use IADs::GetInfo
		/// to refresh all the property values.
		/// </para>
		/// <para>
		/// For an ADSI container object, <c>IADs::GetInfoEx</c> caches only the property values of the container, but not those of the child objects.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to use the <c>IADs::GetInfoEx</c> to obtain values of the selected properties, assuming that
		/// the desired property values can be found in the directory.
		/// </para>
		/// <para>
		/// The following code example shows how to use the <c>IADs::GetInfoEx</c> to obtain values of the selected properties, assuming that
		/// the desired property values can be found in the directory. For brevity, error checking has been omitted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getinfoex HRESULT GetInfoEx( [in] VARIANT vProperties, [in]
		// long lnReserved );
		[DispId(14)]
		new void GetInfoEx([In, MarshalAs(UnmanagedType.Struct)] object vProperties, [In] int lnReserved = 0);

		/// <summary>Gets or sets the ADsPath string of the host of this service.</summary>
		/// <value>The ADsPath string of the host of this service.</value>
		[DispId(15)]
		string HostComputer
		{
			[DispId(15)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(15)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the friendly name of the service.</summary>
		/// <value>The friendly name of the service.</value>
		[DispId(16)]
		string DisplayName
		{
			[DispId(16)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(16)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the version of the service.</summary>
		/// <value>The version of the service.</value>
		[DispId(17)]
		string Version
		{
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(17)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// Gets or sets the description of how a service presents itself on the host computer. This property can be zero or a combination of
		/// one or more of the following values.
		/// </summary>
		/// <value>
		/// Description of how a service presents itself on the host computer. This property can be zero or a combination of one or more of
		/// the following values.
		/// </value>
		[DispId(18)]
		ADS_SERVICE_TYPE ServiceType
		{
			[DispId(18)]
			get;
			[DispId(18)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets a value that determines how to start the service. The following are valid values for this property.</summary>
		/// <value>Determines how to start the service. The following are valid values for this property.</value>
		[DispId(19)]
		ADS_SERVICE_START StartType
		{
			[DispId(19)]
			get;
			[DispId(19)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the path and filename to the executable of this service.</summary>
		/// <value>Path and filename to the executable of this service.</value>
		[DispId(20)]
		string Path
		{
			[DispId(20)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(20)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the parameters passed to the service at startup.</summary>
		/// <value>Parameters passed to the service at startup.</value>
		[DispId(21)]
		string StartupParameters
		{
			[DispId(21)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(21)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// Gets or sets the action to be performed if this service fails on startup. The following are valid values for this property.
		/// </summary>
		/// <value>The action to be performed if this service fails on startup. The following are valid values for this property.</value>
		[DispId(22)]
		ADS_SERVICE_ERR ErrorControl
		{
			[DispId(22)]
			get;
			[DispId(22)]
			[param: In]
			set;
		}

		/// <summary>
		/// Gets or sets the name of the load order group that this service is a membername of the load order group that this service is a member.
		/// </summary>
		/// <value>Name of the load order group that this service is a member.</value>
		[DispId(23)]
		string LoadOrderGroup
		{
			[DispId(23)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(23)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the name of the account that this service uses to authenticate itself on startup.</summary>
		/// <value>Name of the account that this service uses to authenticate itself on startup.</value>
		[DispId(24)]
		string ServiceAccountName
		{
			[DispId(24)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(24)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the path of the account specified by the ServiceAccountPath property.</summary>
		/// <value>Path of the account specified by the ServiceAccountPath property.</value>
		[DispId(25)]
		string ServiceAccountPath
		{
			[DispId(25)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(25)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// Gets or sets an array of BSTR names of services or load groups that must be loaded for this service to load. The syntax for the
		/// entry is "Service:" followed by the service name or "Group:" followed by the load group name.
		/// </summary>
		/// <value>
		/// Array of BSTR names of services or load groups that must be loaded for this service to load. The syntax for the entry is
		/// "Service:" followed by the service name or "Group:" followed by the load group name.
		/// </value>
		[DispId(26)]
		object Dependencies
		{
			[DispId(26)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(26)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}
	}

	/// <summary>
	/// <para>
	/// The <c>IADsServiceOperations</c> interface is a dual interface that inherits from IADs. It is designed to manage system services
	/// installed on a computer. You can use this interface to start, pause, and stop a system service, change the password, and examine the
	/// status of a given service across a network.
	/// </para>
	/// <para>
	/// Of the system services and their operations, file service and file service operations are a special case. They are represented and
	/// managed by IADsFileService and IADsFileServiceOperations.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsserviceoperations
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsServiceOperations")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("5D7B33F0-31CA-11CF-A98A-00AA006BC149")]
	public interface IADsServiceOperations : IADs
	{
		/// <summary>
		/// The relative name of the object as named within the underlying directory service. This name distinguishes this object from its siblings.
		/// </summary>
		/// <value>The relative name of the object as named within the underlying directory service.</value>
		[DispId(2)]
		new string Name
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The name of the object Schema class.</summary>
		/// <value>The name of the object Schema class.</value>
		[DispId(3)]
		new string Class
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The globally unique identifier of the directory object. The IADs interface converts the GUID from an octet string, as stored on a
		/// directory server, into a string format.
		/// </summary>
		/// <value>The globally unique identifier of the directory object.</value>
		/// <remarks>
		/// <para>
		/// In Active Directory, the GUID returned from GUID is a string of hexadecimals. Use the resultant GUID to bind to the object directly.
		/// </para>
		/// <code language="vb">
		///<![CDATA[
		///Dim x As IADs
		///Set x = GetObject("LDAP://servername/<GUID=xxx>")]]>
		/// </code>
		/// <para>
		/// where xxx is the value returned from the GUID property. For more information, see Using objectGUID to Bind to an Object. Be aware
		/// that if you use a GUID to bind to an object, the ADsPath property method returns values that are different from the normal values
		/// that would be returned if you used a distinguished name (DN) to bind to the same object. For example, the following table lists
		/// the values returned when using the two different binding methods to bind to the same user object.
		/// </para>
		/// </remarks>
		[DispId(4)]
		new string GUID
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The ADsPath string of this object. The string uniquely identifies this object in a network environment. The object can always be
		/// retrieved using this path.
		/// </summary>
		/// <value>The ADsPath string of this object.</value>
		[DispId(5)]
		new string ADsPath
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The ADsPath string of the parent container. Active Directory does not permit the formation of the ADsPath of a given object by
		/// concatenating the Parent and Name properties. While this operation might work in some providers, it is not guaranteed to work for
		/// all implementations. The ADsPath is guaranteed to be valid and should always be used to retrieve an object's interface pointer.
		/// </summary>
		/// <value>The ADsPath string of the parent container.</value>
		[DispId(6)]
		new string Parent
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The ADsPath string of the Schema class object of this object.</summary>
		/// <value>The ADsPath string of the Schema class object of this object.</value>
		[DispId(7)]
		new string Schema
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// The <c>IADs::GetInfo</c> method loads into the property cache values of the supported properties of this ADSI object from the
		/// underlying directory store.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>IADs::GetInfo</c> function is called to initialize or refresh the property cache. This is similar to obtaining those
		/// property values of supported properties from the underlying directory store.
		/// </para>
		/// <para>
		/// An uninitialized property cache is not necessarily empty. Call IADs::Put or IADs::PutEx to place a value into the property cache
		/// for any supported property and the cache remains uninitialized.
		/// </para>
		/// <para>
		/// An explicit call to <c>IADs::GetInfo</c> loads or reloads the entire property cache, overwriting all the cached property values.
		/// But an implicit call loads only those properties not set in the cache. Always call <c>IADs::GetInfo</c> explicitly to retrieve
		/// the most current property values of the ADSI object.
		/// </para>
		/// <para>
		/// Because an explicit call to <c>IADs::GetInfo</c> overwrites all the values in the property cache, any change made to the cache
		/// will be lost if an IADs::SetInfo was not invoked before <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>
		/// For an ADSI container object, <c>IADs::GetInfo</c> caches only the property values of the container, but not those of the child objects.
		/// </para>
		/// <para>
		/// It is important to emphasize the differences between the IADs::Get and <c>IADs::GetInfo</c> methods. The former returns values of
		/// a given property from the property cache whereas the latter loads all the supported property values into the property cache from
		/// the underlying directory store.
		/// </para>
		/// <para>The following code example illustrates the differences between the IADs::Get and <c>IADs::GetInfo</c> methods.</para>
		/// <para>
		/// For increased performance, explicitly call IADs::GetInfoEx to refresh specific properties. Also, <c>IADs::GetInfoEx</c> must be
		/// called instead of <c>IADs::GetInfo</c> if the object's operational property values have to be accessed. This function overwrites
		/// any previously cached values of the specified properties.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example uses a computer object served by the WinNT provider. The supported properties include <c>Owner</c>
		/// ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"), <c>Division</c> ("Fabrikam"),
		/// <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping 1"). The default values are shown
		/// in parentheses.
		/// </para>
		/// <para>
		/// The following code example is a client-side script that illustrates the effect of <c>IADs::GetInfo</c> method. The supported
		/// properties include <c>Owner</c> ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"),
		/// <c>Division</c> ("Fabrikam"), <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping
		/// 1"). The default values are shown in parentheses.
		/// </para>
		/// <para>The following code example highlights the effect of Get and GetInfo. For brevity, error checking is omitted.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getinfo HRESULT GetInfo();
		[DispId(8)]
		new void GetInfo();

		/// <summary>The <c>IADs::SetInfo</c> method saves the cached property values of the ADSI object to the underlying directory store.</summary>
		/// <remarks>
		/// <para>
		/// It is important to emphasize the differences between the IADs::Put and <c>IADs::SetInfo</c> methods. The former sets (or
		/// modifies) values of a given property in the property cache whereas the latter propagates the changes from the property cache into
		/// the underlying directory store. Therefore, any property value changes made by <c>IADs::Put</c> will be lost if IADs::GetInfo (or
		/// IADs::GetInfoEx) is invoked before <c>IADs::SetInfo</c> is called.
		/// </para>
		/// <para>
		/// Because <c>IADs::SetInfo</c> sends data across networks, minimize the usage of this method. This reduces the number of trips a
		/// client makes to the server. For example, you should commit all, or most, of the changes to the properties from the cache to the
		/// persistent store in one batch.
		/// </para>
		/// <para>
		/// This guideline pertains only to the relationship of <c>IADs::SetInfo</c> with the IADs::Put method, which differs from the
		/// relationship with the IADs::PutEx method.
		/// </para>
		/// <para>The following code example illustrates the recommended relation between IADs::Put and <c>IADs::SetInfo</c>.</para>
		/// <para>The following code example illustrates what is not recommended between IADs::Put and <c>IADs::SetInfo</c>.</para>
		/// <para>
		/// When used with IADs::PutEx, <c>IADs::SetInfo</c> passes the operational requests specified by control codes, such as
		/// ADS_PROPERTY_UPDATE or ADS_PROPERTY_CLEAR, to the underlying directory store.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following Visual Basic code example uses the <c>IADs::SetInfo</c> method to save the property value of a user to the
		/// underlying directory.
		/// </para>
		/// <para>
		/// The following C++ code example updates property values in the property cache and commits the change to the directory store using
		/// <c>IADs::SetInfo</c>. For brevity, error checking is omitted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-setinfo HRESULT SetInfo();
		[DispId(9)]
		new void SetInfo();

		/// <summary>
		/// The <c>IADs::Get</c> method retrieves a property of a given name from the property cache. The property can be single-valued, or
		/// multi-valued. The property value is represented as either a variant for a single-valued property or a variant array (of
		/// <c>VARIANT</c> or bytes) for a property that allows multiple values.
		/// </summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <returns>
		/// Pointer to a <c>VARIANT</c> that receives the value of the property. For a multi-valued property, <c>pvProp</c> is a variant
		/// array of <c>VARIANT</c>, unless the property is a binary type. In this latter case, <c>pvProp</c> is a variant array of bytes
		/// (VT_U1 or VT_ARRAY). For the property that refers to an object, <c>pvProp</c> is a VT_DISPATCH pointer to the object referred to.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IADs::Get</c> method requires the caller to handle the single- and multi-valued property values differently. Thus, if you
		/// know that the property of interest is either single- or multi-valued, use the <c>IADs::Get</c> method to retrieve the property
		/// value. The following code example shows how you, as a caller, can handle single- and multi-valued properties when calling this method.
		/// </para>
		/// <para>
		/// When a property is uninitialized, calling this method invokes an implicit call to the IADs::GetInfo method. This loads from the
		/// underlying directory store the values of the supported properties that have not been set in the cache. Any subsequent calls to
		/// <c>IADs::Get</c> deals with property values in the cache only. For more information about the behavior of implicit and explicit
		/// calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>
		/// You can also use IADs::GetEx to retrieve property values from the property cache. However, the values are returned as a variant
		/// array of <c>VARIANT</c> s, regardless of whether they are single-valued or multi-valued. That is, ADSI attempts to package the
		/// returned property values in consistent data formats. This saves you, as a caller, the effort of validating the data types when
		/// unsure that the returned data has single or multiple values.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example retrieves the security descriptor for an object using <c>IADs::Get</c>.</para>
		/// <para>The following code example shows how to work with property values of binary data using <c>IADs::Get</c> and IADs::Put.</para>
		/// <para>The following code example shows how to retrieve values of the optional properties of an object using <c>IADs::Get</c>.</para>
		/// <para>The following code example reads attributes with single and multiple values using <c>IADs::Get</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-get HRESULT Get( [in] BSTR bstrName, [out] VARIANT *pvProp );
		[DispId(10)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object? Get([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

		/// <summary>The <c>IADs::Put</c> method sets the values of an attribute in the ADSI attribute cache.</summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <param name="vProp">Contains a <c>VARIANT</c> that specifies the new values of the property.</param>
		/// <remarks>
		/// <para>
		/// The assignment of the new property values, performed by <c>Put</c> takes place in the property cache only. To propagate the
		/// changes to the directory store, call IADs::SetInfo on the object after calling <c>Put</c>.
		/// </para>
		/// <para>
		/// To manipulate the property values beyond a simple assignment, use <c>Put</c> to append or remove a value from an existing array
		/// of attribute values.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use the <c>IADs::Put</c> method.</para>
		/// <para>The following code example shows how to use the <c>IADs::Put</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-put HRESULT Put( [in] BSTR bstrName, [in] VARIANT vProp );
		[DispId(11)]
		new void Put([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);

		/// <summary>
		/// The <c>IADs::GetEx</c> method retrieves, from the property cache, property values of a given attribute. The returned property
		/// values can be single-valued or multi-valued. Unlike the IADs::Get method, the property values are returned as a variant array of
		/// <c>VARIANT</c>, or a variant array of bytes for binary data. A single-valued property is then represented as an array of a single element.
		/// </summary>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <returns>Pointer to a <c>VARIANT</c> that receives the value, or values, of the property.</returns>
		/// <remarks>
		/// <para>
		/// The IADs::Get and <c>IADs::GetEx</c> methods return a different variant structure for a single-valued property value. If the
		/// property is a string, <c>IADs::Get</c> returns a variant of string (VT_BSTR), whereas <c>IADs::GetEx</c> returns a variant array
		/// of a <c>VARIANT</c> type string with a single element. Thus, if you are not sure that a multi-valued attribute will return a
		/// single value or multiple values, use <c>IADs::GetEx</c>. As it does not require you to validate the result's data structures, you
		/// may want to use <c>IADs::GetEx</c> to retrieve a property when you are not sure whether it has single or multiple values. The
		/// following list compares the two methods.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>IADs::Get version</description>
		/// <description>IADs::GetEx version</description>
		/// </listheader>
		/// <item>
		/// <description/>
		/// <description/>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// Like the IADs::Get method, <c>IADs::GetEx</c> implicitly calls IADs::GetInfo against an uninitialized property cache. For more
		/// information about implicit and explicit calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use <c>IADs::GetEx</c> to retrieve object properties.</para>
		/// <para>The following code example shows how to retrieve values of the optional properties of an object using the IADs::Get method.</para>
		/// <para>The following code example retrieves the "homePhone" property values using <c>IADs::GetEx</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getex HRESULT GetEx( [in] BSTR bstrName, [out] VARIANT
		// *pvProp );
		[DispId(12)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object? GetEx([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

		/// <summary>
		/// The <c>IADs::PutEx</c> method modifies the values of an attribute in the ADSI attribute cache. For example, for properties that
		/// allow multiple values, you can append additional values to an existing set of values, modify the values in the set, remove
		/// specified values from the set, or delete values from the set.
		/// </summary>
		/// <param name="lnControlCode">
		/// Control code that indicates the mode of modification: Append, Replace, Remove, and Delete. For more information and a list of
		/// values, see ADS_PROPERTY_OPERATION_ENUM.
		/// </param>
		/// <param name="bstrName">Contains a <c>BSTR</c> that specifies the property name.</param>
		/// <param name="vProp">
		/// Contains a <c>VARIANT</c> array that contains the new value or values of the property. A single-valued property is represented as
		/// an array with a single element. If <c>InControlCode</c> is set to <c>ADS_PROPERTY_CLEAR</c>, the value of the property specified
		/// by <c>vProp</c> is irrelevant.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>PutEx</c> is usually used to set values on multi-value attributes. Unlike the IADs::Put method, with <c>PutEx</c>, you are not
		/// required to get the attribute values before you modify them. However, because <c>PutEx</c> only makes changes to attributes
		/// values contained in the ADSI property cache, you must use IADs::SetInfo after each <c>PutEx</c> call in order to commit changes
		/// to the directory.
		/// </para>
		/// <para>
		/// <c>PutEx</c> enables you to append values to an existing set of values in a multi-value attribute using
		/// <c>ADS_PROPERTY_APPEND</c>. When you update, append, or delete values to a multi-value attribute, you must use an array.
		/// </para>
		/// <para>
		/// Active Directory does not accept duplicate values on a multi-valued attribute. If you call <c>PutEx</c> to append a duplicate
		/// value to a multi-valued attribute of an Active Directory object, the <c>PutEx</c> call succeeds, but the duplicate value is ignored.
		/// </para>
		/// <para>
		/// Similarly, if you use <c>PutEx</c> to delete one or more values from a multi-valued property of an Active Directory object, the
		/// operation succeeds, that is, it will not produce an error, even if any or all of the specified values are not set on the property.
		/// </para>
		/// <para>
		/// <c>Note</c>  The WinNT provider ignores the value passed by the <c>InControlCode</c> argument and performs the equivalent of an
		/// <c>ADS_PROPERTY_UPDATE</c> request when using <c>PutEx</c>.
		/// </para>
		/// <para></para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use the <c>IADs.PutEx</c> method.</para>
		/// <para>The following code example shows how to use the <c>IADs::PutEx</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-putex HRESULT PutEx( [in] long lnControlCode, [in] BSTR
		// bstrName, [in] VARIANT vProp );
		[DispId(13)]
		new void PutEx([In] ADS_PROPERTY_OPERATION lnControlCode, [In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);

		/// <summary>
		/// The <c>IADs::GetInfoEx</c> method loads the values of specified properties of the ADSI object from the underlying directory store
		/// into the property cache.
		/// </summary>
		/// <param name="vProperties">
		/// Array of null-terminated Unicode string entries that list the properties to load into the Active Directory property cache. Each
		/// property name must match one in this object's schema class definition.
		/// </param>
		/// <param name="lnReserved">Reserved for future use. Must be set to zero.</param>
		/// <remarks>
		/// <para>
		/// The <c>IADs::GetInfoEx</c> method overwrites any previously cached values of the specified properties with those in the directory
		/// store. Therefore, any change made to the cache will be lost if IADs::SetInfo was not invoked before the call to <c>IADs::GetInfoEx</c>.
		/// </para>
		/// <para>
		/// Use <c>IADs::GetInfoEx</c> to refresh values of the selected property in the property cache of an ADSI object. Use IADs::GetInfo
		/// to refresh all the property values.
		/// </para>
		/// <para>
		/// For an ADSI container object, <c>IADs::GetInfoEx</c> caches only the property values of the container, but not those of the child objects.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to use the <c>IADs::GetInfoEx</c> to obtain values of the selected properties, assuming that
		/// the desired property values can be found in the directory.
		/// </para>
		/// <para>
		/// The following code example shows how to use the <c>IADs::GetInfoEx</c> to obtain values of the selected properties, assuming that
		/// the desired property values can be found in the directory. For brevity, error checking has been omitted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getinfoex HRESULT GetInfoEx( [in] VARIANT vProperties, [in]
		// long lnReserved );
		[DispId(14)]
		new void GetInfoEx([In, MarshalAs(UnmanagedType.Struct)] object vProperties, [In] int lnReserved = 0);

		/// <summary>Gets the status of service.</summary>
		/// <value>The status of service.</value>
		[DispId(27)]
		ADS_SERVICE_STATUS Status
		{
			[DispId(27)]
			get;
		}

		/// <summary>The <c>IADsServiceOperations::Start</c> method starts a network service.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsserviceoperations-start HRESULT Start();
		[DispId(28)]
		void Start();

		/// <summary>The <c>IADsServiceOperations::Stop</c> method stops a currently active network service.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsserviceoperations-stop HRESULT Stop();
		[DispId(29)]
		void Stop();

		/// <summary>The <c>IADsServiceOperations::Pause</c> method pauses a service started with the IADsServiceOperations::Start method.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsserviceoperations-pause HRESULT Pause();
		[DispId(30)]
		void Pause();

		/// <summary>
		/// The <c>IADsServiceOperations::Continue</c> method resumes a service operation paused by the IADsServiceOperations::Pause method.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsserviceoperations-continue HRESULT Continue();
		[DispId(31)]
		void Continue();

		/// <summary>
		/// The <c>IADsServiceOperations::SetPassword</c> method sets the password for the account used by the service manager. This method
		/// is called when the security context for this service is created.
		/// </summary>
		/// <param name="bstrNewPassword">The null-terminated Unicode string to be stored as the new password.</param>
		/// <remarks>
		/// <para>The property IADsService::get_ServiceAccountName identifies the account for which this password is to be set.</para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to set a password for the Microsoft Fax Service running on Windows 2000.</para>
		/// <para>The following code example shows how to set a password for the Microsoft Fax Service running on Windows 2000.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsserviceoperations-setpassword HRESULT SetPassword( [in] BSTR
		// bstrNewPassword );
		[DispId(32)]
		void SetPassword([In, MarshalAs(UnmanagedType.BStr)] string bstrNewPassword);
	}
}