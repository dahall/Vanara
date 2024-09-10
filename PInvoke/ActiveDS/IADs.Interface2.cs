using System.Collections;

namespace Vanara.PInvoke;

public static partial class ActiveDS
{
	/// <summary>
	/// The <c>IADsFileServiceOperations</c> interface is a dual interface that inherits from IADsServiceOperations. It extends the
	/// functionality, as exposed in the <c>IADsServiceOperations</c> interface, for managing the file service across a network.
	/// Specifically, it serves to maintain and manage open resources and active sessions of the file service.
	/// </summary>
	/// <remarks>
	/// <para>
	/// To bind to a file service operations object, use the ADsPath string that identifies the "LanmanServer" service on the host computer,
	/// as shown in the following code example.
	/// </para>
	/// <para>
	/// From this point, you can handle the file service object as just a service object, applying any of the methods of
	/// IADsServiceOperations to the file service object. For example, you can examine the operational status of the file service, start or
	/// stop the file service, or change its password.
	/// </para>
	/// <para>
	/// However, the <c>IADsFileServiceOperations</c> interface allows you to work with open resources and active sessions of the file
	/// service. See the following example.
	/// </para>
	/// <para>For more information about active sessions and open resources, see IADsSession and IADsResource.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsfileserviceoperations
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsFileServiceOperations")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("A02DED10-31CA-11CF-A98A-00AA006BC149")]
	public interface IADsFileServiceOperations : IADsServiceOperations
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
		new ADS_SERVICE_STATUS Status
		{
			[DispId(27)]
			get;
		}

		/// <summary>The <c>IADsServiceOperations::Start</c> method starts a network service.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsserviceoperations-start HRESULT Start();
		[DispId(28)]
		new void Start();

		/// <summary>The <c>IADsServiceOperations::Stop</c> method stops a currently active network service.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsserviceoperations-stop HRESULT Stop();
		[DispId(29)]
		new void Stop();

		/// <summary>The <c>IADsServiceOperations::Pause</c> method pauses a service started with the IADsServiceOperations::Start method.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsserviceoperations-pause HRESULT Pause();
		[DispId(30)]
		new void Pause();

		/// <summary>
		/// The <c>IADsServiceOperations::Continue</c> method resumes a service operation paused by the IADsServiceOperations::Pause method.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsserviceoperations-continue HRESULT Continue();
		[DispId(31)]
		new void Continue();

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
		new void SetPassword([In, MarshalAs(UnmanagedType.BStr)] string bstrNewPassword);

		/// <summary>
		/// The <c>IADsFileServiceOperations::Sessions</c> method gets a pointer to a pointer to the IADsCollection interface on a collection
		/// of the session objects that represent the current open sessions for this file service.
		/// </summary>
		/// <returns>
		/// Pointer to a pointer to the IADsCollection interface used to enumerate objects that implement the IADsSession interface and
		/// represent the current open sessions for this file service.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Traditional directory services supply data only about directory service elements represented in the underlying data store. Data
		/// about sessions for file services may not be available from the underlying store.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to enumerate active sessions managed by a file service.</para>
		/// <para>For a code example using the <c>IADsFileServiceOperations::Sessions</c> interface, see the code example given in IADsSession.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsfileserviceoperations-sessions HRESULT Sessions( [out]
		// IADsCollection **ppSessions );
		[DispId(35)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IADsCollection Sessions();

		/// <summary>
		/// The <c>IADsFileServiceOperations::Resources</c> method gets a pointer to a pointer to the IADsCollection interface on a
		/// collection of the resource objects representing the current open resources on this file service.
		/// </summary>
		/// <returns>
		/// Pointer to a pointer to the IADsCollection interface that can then be used to enumerate objects implementing the IADsResource
		/// interface and representing the current open resources for this file service.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Traditional directory services supply data only about directory service elements represented in the underlying data store. Data
		/// about resources for file services may not be available from the underlying directory store.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to enumerate open resources managed by a file service.</para>
		/// <para>For a code example using the <c>IADsFileServiceOperations::Resources</c> method, see the code example given in IADsResource.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsfileserviceoperations-resources HRESULT Resources( [out]
		// IADsCollection **ppResources );
		[DispId(36)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IADsCollection Resources();
	}

	/// <summary>
	/// The <c>IADsFileShare</c> interface is a dual interface that inherits from IADs. It is designed for representing a published file
	/// share across the network. Call the methods on <c>IADsFileShare</c> to access or publish data about a file share point.
	/// </summary>
	/// <remarks>
	/// <para>
	/// <c>IADsFileShare</c> is supported by WinNT system provider only. Using the WinNT provider, you can also bind to a FPNW share by
	/// substituting "FPNW" for "LanmanServer" in the code examples below.
	/// </para>
	/// <para>
	/// To bind to a file share, using the WinNT system provider, you can explicitly bind to the file service "LanmanServer" on the host
	/// machine, and then enumerate the container to reach the file share of interest, or bind directly to the file share.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example demonstrates how to bind to the file service and enumerate the container to display the names of the
	/// shares in that container.
	/// </para>
	/// <para>The following code example demonstrates how to bind directly to a file share.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsfileshare
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsFileShare")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("EB6DCAF0-4B83-11CF-A995-00AA006BC149")]
	public interface IADsFileShare : IADs
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

		/// <summary>Gets the number of users connected to the share.</summary>
		/// <value>The number of users connected to the share.</value>
		[DispId(15)]
		int CurrentUserCount
		{
			[DispId(15)]
			get;
		}

		/// <summary>Gets or sets the description of the file share.</summary>
		/// <value>The description of the file share.</value>
		[DispId(16)]
		string Description
		{
			[DispId(16)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(16)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the ADsPath reference to the host computer.</summary>
		/// <value>The ADsPath reference to the host computer.</value>
		[DispId(17)]
		string HostComputer
		{
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(17)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the file system path to the shared directory.</summary>
		/// <value>The file system path to the shared directory.</value>
		[DispId(18)]
		string Path
		{
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(18)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the maximum number of users allowed to access the share at one time.</summary>
		/// <value>The maximum number of users allowed to access the share at one time.</value>
		[DispId(19)]
		int MaxUserCount
		{
			[DispId(19)]
			get;
			[DispId(19)]
			[param: In]
			set;
		}
	}

	/// <summary>
	/// The <c>IADsGroup</c> interface is a dual interface that inherits from IADs. It manages group membership data in a directory service.
	/// It enables you to get member objects, test if a given object belongs to the group, and to add, or remove, an object to, or from, the group.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsgroup
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsGroup")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("27636B00-410F-11CF-B1FF-02608C9E7553")]
	public interface IADsGroup : IADs
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

		/// <summary>Gets or sets the textual description of the group membership.</summary>
		/// <value>The textual description of the group membership.</value>
		[DispId(15)]
		string Description
		{
			[DispId(15)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(15)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <c>IADsGroup::Members</c> method retrieves a collection of the immediate members of the group. The collection does not
		/// include the members of other groups that are nested within the group.
		/// </para>
		/// <para>
		/// The default implementation of this method uses LsaLookupSids to query name information for the group members. LsaLookupSids has a
		/// maximum limitation of 20480 SIDs it can convert, therefore that limitation also applies to this method.
		/// </para>
		/// </summary>
		/// <returns>
		/// Pointer to an IADsMembers interface pointer that receives the collection of group members. The caller must release this interface
		/// when it is no longer required.
		/// </returns>
		/// <remarks>
		/// <para>The IADsMembers <c>Members</c> method will use the same provider.</para>
		/// <para>Examples</para>
		/// <para>The following code example enumerates all members of a group.</para>
		/// <para>The following code example enumerates all members of a group.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsgroup-members HRESULT Members( [out] IADsMembers **ppMembers );
		[DispId(16)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IADsMembers Members();

		/// <summary>
		/// The <c>IADsGroup::IsMember</c> method determines if a directory service object is an immediate member of the group. This method
		/// does not verify membership in any nested groups.
		/// </summary>
		/// <param name="bstrMember">
		/// Contains the ADsPath of the directory service object to verify membership. This ADsPath must use the same ADSI provider used to
		/// bind to the group. For example, if the group was bound to using the LDAP provider, this ADsPath must also use the LDAP provider.
		/// </param>
		/// <returns>
		/// Pointer to a <c>VARIANT_BOOL</c> value that receives <c>VARIANT_TRUE</c> if the object is an immediate member of the group or
		/// <c>VARIANT_FALSE</c> otherwise.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Although you can add or remove a security principal to or from a group using the member SID through the WinNT provider, the
		/// <c>IADsGroup.IsMember</c> method does not support using a SID ADsPath for verification if a member belongs to a group through the
		/// WinNT provider.
		/// </para>
		/// <para>
		/// The <c>IADsGroup::IsMember</c> method will only work correctly if the group and the object are in the same domain. If the object
		/// is in a different domain than the group, <c>IADsGroup::IsMember</c> will always return <c>VARIANT_FALSE</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example adds the "jeffsmith" user to the "Administrators" group on the "Fabrikam" domain and then reports that
		/// the user is now a member of the group.
		/// </para>
		/// <para>The following code example verifies that a user belongs to a group before adding it to the group.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsgroup-ismember HRESULT IsMember( BSTR bstrMember, [out]
		// VARIANT_BOOL *bMember );
		[DispId(17)]
		bool IsMember([In, MarshalAs(UnmanagedType.BStr)] string bstrMember);

		/// <summary>The <c>IADsGroup::Add</c> method adds an ADSI object to an existing group.</summary>
		/// <param name="bstrNewItem">
		/// Contains a <c>BSTR</c> that specifies the ADsPath of the object to add to the group. For more information, see Remarks.
		/// </param>
		/// <remarks>
		/// <para>
		/// If the LDAP provider is used to bind to the IADsGroup object, the same form of ADsPath must be specified in the
		/// <c>bstrNewItem</c> parameter. For example, if the ADsPath used to bind to the <c>IADsGroup</c> object includes a server, the
		/// ADsPath in the <c>bstrNewItem</c> parameter must contain the same server prefix. Likewise, if a serverless path is used to bind
		/// to the <c>IADsGroup</c> object, the <c>bstrNewItem</c> parameter must also contain a serverless path. When using server prefix,
		/// delays may occur if the group and the new member are from different domains, as requests may be sent to the wrong domain
		/// controller and referred to a domain controller of the correct domain and retried there. An exception occurs when adding or
		/// removing a member using a GUID or security identifier (SID) ADsPath. In this case, a serverless path should always be used in <c>bstrNewItem</c>.
		/// </para>
		/// <para>
		/// The LDAP provider for Active Directory enables a member to be added to a group using the string form of the member SID. The
		/// <c>bstrNewItem</c> parameter can contain a SID string in the following form.
		/// </para>
		/// <para>For more information about SID strings in Active Directory, see Binding to an Object Using a SID.</para>
		/// <para>
		/// The WinNT provider for Active Directory also enables a member to be added to a group using the string form of the member's SID.
		/// The <c>bstrNewItem</c> parameter can contain a SID string in the following form.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to add a user object ("jeff") to the group ("Administrators") on the "Fabrikam" domain,
		/// using the WinNT provider.
		/// </para>
		/// <para>The following code example shows how to add a user object to a group using the LDAP provider.</para>
		/// <para>The following code example adds an existing user account to the Administrators group.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsgroup-add HRESULT Add( [in] BSTR bstrNewItem );
		[DispId(18)]
		void Add([In, MarshalAs(UnmanagedType.BStr)] string bstrNewItem);

		/// <summary>
		/// The <c>IADsGroup::Remove</c> method removes the specified user object from this group. The operation does not remove the group
		/// object itself even when there is no member remaining in the group.
		/// </summary>
		/// <param name="bstrItemToBeRemoved">
		/// Contains a <c>BSTR</c> that specifies the ADsPath of the object to remove from the group. For more information about this
		/// parameter, see the Remarks section.
		/// </param>
		/// <remarks>
		/// <para>
		/// If the LDAP provider is used to bind to the IADsGroup object, the same form of ADsPath must be specified in the
		/// <c>bstrItemToBeRemoved</c> parameter. For example, if the ADsPath used to bind to the <c>IADsGroup</c> object includes a server,
		/// the ADsPath in the <c>bstrItemToBeRemoved</c> parameter must contain the same server prefix. Likewise, if a serverless path is
		/// used to bind to the <c>IADsGroup</c> object, the <c>bstrItemToBeRemoved</c> parameter must also contain a serverless path. The
		/// exception is when adding or removing a member using a GUID or SID ADsPath. In this case, a serverless path should always be used
		/// in <c>bstrItemToBeRemoved</c>.
		/// </para>
		/// <para>
		/// You can use a SID in the ADsPath to remove a security principal from the group through the WinNT provider. For example, suppose
		/// the SID of a user, "Fabrikam\jeffsmith", is S-1-5-21-35135249072896, the following statement:
		/// </para>
		/// <para>is equivalent to</para>
		/// <para>Removing a member using its SID through the WinNT provider is a new feature in Windows 2000 and the DSCLIENT package.</para>
		/// <para>Examples</para>
		/// <para>The following code example removes a user account from a group.</para>
		/// <para>The following code example removes a user from a group.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsgroup-remove HRESULT Remove( [in] BSTR bstrItemToBeRemoved );
		[DispId(19)]
		void Remove([In, MarshalAs(UnmanagedType.BStr)] string bstrItemToBeRemoved);
	}

	/// <summary>
	/// <para>The <c>IADsHold</c> interface provides methods for an ADSI client to access the <c>Hold</c> attribute.</para>
	/// <para>You can call the property methods of this interface to obtain and modify the attribute.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadshold
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsHold")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("B3EB3B37-4080-11D1-A3AC-00C04FB950DC"), CoClass(typeof(Hold))]
	public interface IADsHold
	{
		/// <summary>Gets or sets the name of the object representing a user on hold.</summary>
		/// <value>The name of the object representing a user on hold.</value>
		[DispId(2)]
		string ObjectName
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(2)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// Gets or sets the amount of charges levied against the user for the period on hold while the server checks the account balance of
		/// the user.
		/// </summary>
		/// <value>
		/// The amount of charges levied against the user for the period on hold while the server checks the account balance of the user.
		/// </value>
		[DispId(3)]
		int Amount
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}
	}

	/// <summary>The <c>IADsLargeInteger</c> interface is used to manipulate 64-bit integers of the <c>LargeInteger</c> type.</summary>
	/// <remarks>
	/// <para>
	/// Handling the <c>IADsLargeInteger</c> in Visual Basic is made difficult by the fact that Visual Basic has no native unsigned numeric
	/// data type. This can cause errors in data conversion if either the LowPart or <c>HighPart</c> has the high bit set, which causes
	/// Visual Basic to handle the number as negative. The Visual Basic code examples below show how to properly handle the
	/// <c>IADsLargeInteger</c> in Visual Basic.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows how to convert an <c>IADsLargeInteger</c> object to a hex string.</para>
	/// <para>
	/// In Visual Basic, it is possible to convert an <c>IADsLargeInteger</c> objects that represents a date and/or time into a time Variant
	/// using the FileTimeToSystemTime and SystemTimeToVariantTime APIs. This is shown in the following code example.
	/// </para>
	/// <para>The following example shows how to convert an <c>IADsLargeInteger</c> to a 64-bit integer.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadslargeinteger
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsLargeInteger")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("9068270B-0939-11D1-8BE1-00C04FD8D503"), CoClass(typeof(LargeInteger))]
	public interface IADsLargeInteger
	{
		/// <summary>Gets or sets the high part of the integer.</summary>
		/// <value>The high part of the integer.</value>
		[DispId(2)]
		int HighPart
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the low part of the integer.</summary>
		/// <value>The low part of the integer.</value>
		[DispId(3)]
		int LowPart
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}
	}

	/// <summary>Converts interface values to <see cref="Int64"/>.</summary>
	/// <param name="li">The <see cref="IADsLargeInteger"/> instance.</param>
	/// <returns>A <see cref="long"/> value.</returns>
	public static long ToInt64(this IADsLargeInteger li) => Macros.MAKELONG64(unchecked((uint)li.LowPart), li.HighPart);

	/// <summary>
	/// <para>
	/// The <c>IADsLocality</c> interface is a dual interface that inherits from IADs. It is designed to represent the geographical location,
	/// or region, of a directory entity. This interface is one of several that provide support for directory services to organize accounts
	/// by country/region, locality (state/city/region), organization (company), or organizational unit (department). This interface manages
	/// locality, the IADsO interface manages organization, and the IADsOU interface manages the organization unit.
	/// </para>
	/// <para>
	/// When a directory service provides hierarchical groupings of directory entries by country/region, locality, organization, or
	/// organization unit, you can use this and the related interfaces to expand the directory tree accordingly. In this case, the
	/// <c>IADsLocality</c> interface is implemented by a locality object that implements the IADsContainer interface.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadslocality
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsLocality")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("A05E03A2-EFFE-11CF-8ABC-00C04FD8D503")]
	public interface IADsLocality : IADs
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

		/// <summary>Gets or sets the text that describes the locality.</summary>
		/// <value>The text that describes the locality.</value>
		[DispId(15)]
		string Description
		{
			[DispId(15)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(15)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the name of the geographical region as represented by this locality object.</summary>
		/// <value>The name of the geographical region as represented by this locality object.</value>
		[DispId(16)]
		string LocalityName
		{
			[DispId(16)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(16)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the main postal address of the locality.</summary>
		/// <value>The main postal address of the locality.</value>
		[DispId(17)]
		string PostalAddress
		{
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(17)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets an array of ADsPath names of directory objects relevant to this object.</summary>
		/// <value>An array of ADsPath names of directory objects relevant to this object.</value>
		[DispId(18)]
		object SeeAlso
		{
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(18)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}
	}

	/// <summary>
	/// <para>
	/// The <c>IADsMembers</c> interface is a dual interface. It is designed for managing a list of ADSI object references. It is implemented
	/// to support group membership for individual accounts. It can be used to manage a collection of ADSI objects belonging to a group. To
	/// access the collection of group members, use the IADsGroup::get_Members property method implemented by the ADSI group object.
	/// </para>
	/// <para>
	/// The <c>IADsMembers</c> interface serves a slightly different purpose from the IADsCollection and IADsContainer interfaces, which also
	/// works with a set of data or objects. <c>IADsCollection</c> manages sets of arbitrary data elements that are not object references,
	/// whereas <c>IADsContainer</c> manages objects that are part of the directory tree structure or the network topology.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsmembers
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsMembers")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("451A0030-72EC-11CF-B03B-00AA006E0975")]
	public interface IADsMembers : IEnumerable
	{
		/// <summary>
		/// Gets the number of items in the container. If the filter is set then count returns only the number of items that fit the filter description.
		/// </summary>
		/// <value>
		/// The number of items in the container. If the filter is set then count returns only the number of items that fit the filter description.
		/// </value>
		[DispId(2)]
		int Count
		{
			[DispId(2)]
			get;
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();

		/// <summary>
		/// Gets or sets the filter. The syntax of the entries in the filter array is the same as the Filter used on the IADsContainer interface.
		/// </summary>
		/// <value>The filter. The syntax of the entries in the filter array is the same as the Filter used on the IADsContainer interface.</value>
		[DispId(3)]
		object Filter
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(3)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}
	}

	/// <summary>
	/// <para>
	/// The <c>IADsNamespaces</c> interface is implemented by the ADs provider and is used for managing namespace objects. A namespace object
	/// is a provider-specific top-level container and corresponds to the root node of a directory tree. The ADSI namespaces object serves as
	/// an entry point into the underlying directory and allows directory service administrators to enumerate the currently installed
	/// namespace objects.
	/// </para>
	/// <para>
	/// This interface supports two property methods to get and set the DefaultContainer property which holds the path to a container object.
	/// The default container is the base node from which browsing of the directory tree proceeds. References of any children objects can be
	/// made relative to this default container. The <c>DefaultContainer</c> property makes it more efficient and convenient for a client to
	/// reference repetitively a contained object.
	/// </para>
	/// <para>Obtain a pointer to the <c>IADsNamespaces</c> interface when you bind to the object using the "ADs:" string:</para>
	/// <para>Non-Automation clients can use the ADsGetObject helper function instead.</para>
	/// <para>In addition to the <c>IADsNamespaces</c> interface, the ADSI namespaces object also implements the IADsContainer interface.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsnamespaces
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsNamespaces")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("28B96BA0-B330-11CF-A9AD-00AA006BC149")]
	public interface IADsNamespaces : IADs
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

		/// <summary>
		/// The DefaultContainer property identifies a base container object to which you can bind and use as a starting point when browsing.
		/// This data is stored and retrieved from the following registry value.
		/// <code language="none">
		///<![CDATA[HKEY_CURRENT_USER
		///Software
		///Microsoft
		///ADs
		///DefaultContainer]]>
		/// </code>
		/// <para>
		/// ADSI defines the DefaultContainer property to provide a quick way of getting a pointer to a previously defined ADSI container object.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Providers must supply this property on a per-user basis. The default container is set immediately after the invocation of
		/// IADsNamespaces::put_DefaultContainer. Calling IADs.SetInfo is not required. In fact, the system-supplied namespaces object
		/// returns E_NOTIMPL for the IADs.SetInfo method called on this object. When a container is the namespaces object, an enumeration
		/// operation always results in a list of provider-specific namespace objects. When IADsContainer.GetObject is used to obtain a
		/// namespace object, the bstrClass parameter is ignored. This is because the container, that is, the namespaces object, contains
		/// only one type of object, namely, provider-specific namespace objects.
		/// </remarks>
		[DispId(1)]
		string DefaultContainer
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}
	}

	/// <summary>
	/// <para>
	/// The <c>IADsNameTranslate</c> interface translates distinguished names (DNs) among various formats as defined in the
	/// ADS_NAME_TYPE_ENUM enumeration. The feature is available to objects in Active Directory.
	/// </para>
	/// <para>
	/// Name translations are performed on the directory server. To translate a DN, communicate with the server by means of an
	/// <c>IADsNameTranslate</c> object, and specify which object is of interest and what format is desired. The following is the general
	/// process for using the <c>IADsNameTranslate</c> interface.
	/// </para>
	/// <para>First, create an instance of the <c>IADsNameTranslate</c> object.</para>
	/// <para>
	/// Second, initialize the <c>IADsNameTranslate</c> object by specifying the directory server using the IADsNameTranslate::Init or
	/// IADsNameTranslate::InitEx methods.
	/// </para>
	/// <para>
	/// Third, set the directory object on the server by specifying the name with the IADsNameTranslate::Set method and the format with the
	/// IADsNameTranslate::SetEx method.
	/// </para>
	/// <para>Fourth, retrieve the object name in the specified format with the IADsNameTranslate::Get or IADsNameTranslate::GetEx method.</para>
	/// <para>
	/// The following code example shows how to create an <c>IADsNameTranslate</c> object in Visual C++, Visual Basic, and VBScript/Active
	/// Server Pages.
	/// </para>
	/// <para>
	/// <c>Note</c>  The format elements as defined in the ADS_NAME_TYPE_ENUM enumeration and used by <c>IADsNameTranslate</c> are not
	/// equivalent and are non-interchangeable with the format elements used by the DsCrackName function. Do not confuse the proper use of
	/// these similarly named but non-interchangeable element formats.
	/// </para>
	/// <para></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsnametranslate
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsNameTranslate")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("B1B272A3-3625-11D1-A3A4-00C04FB950DC"), CoClass(typeof(NameTranslate))]
	public interface IADsNameTranslate
	{
		/// <summary>
		/// Options of referral chasing as defined in ADS_CHASE_REFERRALS_ENUM. When referral chasing is set, the name translation is
		/// performed on objects that do not belong to this directory and are the referrals returned from referral chasing.
		/// </summary>
		[DispId(1)]
		int ChaseReferral
		{
			[DispId(1)]
			[param: In]
			set;
		}

		/// <summary>
		/// The <c>IADsNameTranslate::Init</c> method initializes a name translate object by binding to a specified directory server, domain,
		/// or global catalog, using the credentials of the current user. To initialize the object with a different user credential, use IADsNameTranslate::InitEx.
		/// </summary>
		/// <param name="lnSetType">A type of initialization to be performed. Possible values are defined in ADS_NAME_INITTYPE_ENUM.</param>
		/// <param name="bstrADsPath">
		/// The name of the server or domain, depending on the value of <c>lnInitType</c>. When <c>ADS_NAME_INITTYPE_GC</c> is issued, this
		/// parameter is ignored. The global catalog server of the domain of the current computer will perform the name translate operations.
		/// This method will fail if the computer is not part of a domain as no global catalog will be found in this scenario. For more
		/// information, see ADS_NAME_INITTYPE_ENUM.
		/// </param>
		/// <remarks>
		/// <para>
		/// After the successful initialization, you can proceed to use the name translate object to submit requests of name translations of
		/// objects in the directory. For more information, see IADsNameTranslate::Set, or IADsNameTranslate::Get.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following C/C++ code example uses the <c>IADsNameTranslate::Init</c> method to initialize an IADsNameTranslate object before
		/// the distinguished name of a user object is rendered in the s format.
		/// </para>
		/// <para>
		/// The following Visual Basic code example uses the <c>IADsNameTranslate::Init</c> method to initialize an IADsNameTranslate object
		/// in order to have the distinguished name of a user object rendered in the s user name format.
		/// </para>
		/// <para>
		/// The following VBScript/ASP code example uses the <c>IADsNameTranslate::Init</c> method to initialize an IADsNameTranslate object
		/// in order to have the distinguished name of a user object rendered in the s user name format.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsnametranslate-init HRESULT Init( long lnSetType, BSTR
		// bstrADsPath );
		[DispId(2)]
		void Init([In] int lnSetType, [In, MarshalAs(UnmanagedType.BStr)] string bstrADsPath);

		/// <summary>
		/// <para>
		/// The <c>IADsNameTranslate::InitEx</c> method initializes a name translate object by binding to a specified directory server,
		/// domain, or global catalog, using the specified user credential. To initialize the object without an explicit user credential, use IADsNameTranslate::Init.
		/// </para>
		/// <para>
		/// The <c>IADsNameTranslate::InitEx</c> method initializes the object by setting the server or domain that the object will point to
		/// and supplying a user credential.
		/// </para>
		/// </summary>
		/// <param name="lnSetType">A type of initialization to be performed. Possible values are defined in ADS_NAME_INITTYPE_ENUM.</param>
		/// <param name="bstrADsPath">
		/// The name of the server or domain, depending on the value of <c>lnInitType</c>. When <c>ADS_NAME_INITTYPE_GC</c> is issued, this
		/// parameter is ignored. The global catalog server of the domain of the current machine will be used to carry out the name translate
		/// operations. This method will fail if the computer is not part of a domain, as no global catalog will be found in this scenario.
		/// For more information, see ADS_NAME_INITTYPE_ENUM.
		/// </param>
		/// <param name="bstrUserID">User name.</param>
		/// <param name="bstrDomain">User domain name.</param>
		/// <param name="bstrPassword">User password.</param>
		/// <remarks>
		/// <para>
		/// After the successful initialization, use the name translate object to submit requests of name translations of directory objects.
		/// For more information see IADsNameTranslate::Set, IADsNameTranslate::Get, IADsNameTranslate::SetEx, or IADsNameTranslate::GetEx.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following C/C++ code example uses the <c>IADsNameTranslate::InitEx</c> method to initialize an IADsNameTranslate object
		/// before the distinguished name of a user object is rendered in the s format.
		/// </para>
		/// <para>
		/// The following Visual Basic code example uses the <c>IADsNameTranslate::InitEx</c> method to initialize an IADsNameTranslate
		/// object in order to have the distinguished name of a user object rendered in the s user name format.
		/// </para>
		/// <para>
		/// The following VBScript/ASP code example uses the <c>IADsNameTranslate::InitEx</c> method to initialize an IADsNameTranslate
		/// object in order to have the distinguished name of a user object rendered in the s user name format.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsnametranslate-initex HRESULT InitEx( long lnSetType, BSTR
		// bstrADsPath, BSTR bstrUserID, BSTR bstrDomain, BSTR bstrPassword );
		[DispId(3)]
		void InitEx([In] int lnSetType, [In, MarshalAs(UnmanagedType.BStr)] string bstrADsPath, [In, MarshalAs(UnmanagedType.BStr)] string bstrUserID, [In, MarshalAs(UnmanagedType.BStr)] string bstrDomain, [In, MarshalAs(UnmanagedType.BStr)] string bstrPassword);

		/// <summary>
		/// The <c>IADsNameTranslate::Set</c> method directs the directory service to set up a specified object for name translation. To set
		/// the names and format of multiple objects, use IADsnametranslate::SetEx.
		/// </summary>
		/// <param name="lnSetType">The format of the name of a directory object. For more information, see ADS_NAME_TYPE_ENUM.</param>
		/// <param name="bstrADsPath">The object name, for example, "CN=Administrator, CN=users, DC=Fabrikam, DC=com".</param>
		/// <remarks>
		/// <para>
		/// Before calling this method to set the object name, you should have established a connection to the directory service using either
		/// IADsNameTranslate::Init or IADsNameTranslate::InitEx.
		/// </para>
		/// <para>
		/// You can use the <c>IADsNameTranslate::Set</c> method to set name translation for objects residing on the directory server. When
		/// the referral chasing is on, this method will also set any object found on other servers. For more information about referral
		/// chasing, see IADsNameTranslate Property Methods.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following C/C++ code example uses the <c>IADsNameTranslate::Set</c> method to set an object so that its name can be
		/// translated from the RFC 1779 format to the s user name format.
		/// </para>
		/// <para>
		/// The following Visual Basic code example uses the <c>IADsNameTranslate::Set</c> method to set an object so that its name can be
		/// translated from the RFC 1779 format to the s user name format.
		/// </para>
		/// <para>
		/// The following VBScript/ASP code example uses the <c>IADsNameTranslate::Set</c> method to set an object to have its name
		/// translated from the RFC 1779 format to the s user name format.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsnametranslate-set HRESULT Set( long lnSetType, BSTR
		// bstrADsPath );
		[DispId(4)]
		void Set([In] int lnSetType, [In, MarshalAs(UnmanagedType.BStr)] string bstrADsPath);

		/// <summary>
		/// The <c>IADsNameTranslate::Get</c> method retrieves the name of a directory object in the specified format. The distinguished name
		/// must have been set in the appropriate format by the IADsNameTranslate::Set method.
		/// </summary>
		/// <param name="lnFormatType">
		/// The format type of the output name. For more information, see ADS_NAME_TYPE_ENUM. This method does not support the
		/// <c>ADS_NAME_TYPE_SID_OR_SID_HISTORY_NAME</c> element in <c>ADS_NAME_TYPE_ENUM</c>.
		/// </param>
		/// <returns>The name of the returned object.</returns>
		/// <remarks>
		/// <para>This method lets you retrieve the name of a single directory object. To retrieve names of multiple objects use IADsNameTranslate::GetEx.</para>
		/// <para>
		/// When referral chasing is on, this method will attempt to chase and resolve the path of a specified object that is not residing on
		/// the connected server.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following C/C++ code example shows how to translate a distinguished name that is compliant with RFC 1779 to a GUID format.
		/// The computer name of the directory server is "myServer".
		/// </para>
		/// <para>
		/// The following Visual Basic code example shows how to translate a distinguished name that is compliant RFC 1779 to a GUID format.
		/// The computer name of the directory server is "myServer".
		/// </para>
		/// <para>
		/// The following VBScript/ASP code example shows how to translate a distinguished name that is compliant with RFC 1779 to a GUID
		/// format. The machine name of the directory server is "myServer".
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsnametranslate-get HRESULT Get( long lnFormatType, BSTR
		// *pbstrADsPath );
		[DispId(5)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string Get([In] int lnFormatType);

		/// <summary>
		/// The <c>IADsNameTranslate::SetEx</c> method establishes an array of objects for name translation. The specified objects must exist
		/// in the connected directory server. To set the name and format of a single directory object, use the IADsNameTranslate::Set method.
		/// </summary>
		/// <param name="lnFormatType">The format type of the input names. For more information, see ADS_NAME_TYPE_ENUM.</param>
		/// <param name="pVar">A variant array of strings that hold object names.</param>
		/// <remarks>
		/// <para>
		/// You cannot use the <c>IADsNameTranslate::SetEx</c> method to set name translation for objects residing on other servers, even
		/// when the referral chasing option is enabled. For more information about referral chasing, see IADsNameTranslate Property Methods.
		/// </para>
		/// <para>
		/// You can use <c>IADsNameTranslate::SetEx</c> to set names for multiple objects. All the names, however, must be of the same format.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following C/C++ code example uses the <c>IADsNameTranslate::SetEx</c> method to set up an array of objects whose names are to
		/// be translated from the RFC 1779 format to the Windows user name format.
		/// </para>
		/// <para>
		/// The following Visual Basic code example uses the <c>IADsNameTranslate::SetEx</c> method to set up an array of objects whose names
		/// are to be translated from the RFC 1779 format to the s user name format.
		/// </para>
		/// <para>
		/// The following VBScript/ASP code example uses the <c>IADsNameTranslate::SetEx</c> method to set up an array of objects whose names
		/// are to be translated from the RFC 1779 format to the s user name format.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsnametranslate-setex HRESULT SetEx( long lnFormatType, VARIANT
		// pvar );
		[DispId(6)]
		void SetEx([In] int lnFormatType, [In, MarshalAs(UnmanagedType.Struct)] object pVar);

		/// <summary>
		/// The <c>IADsNameTranslate::GetEx</c> method gets the object names in the specified format. The object names must be set by IADsNameTranslate::SetEx.
		/// </summary>
		/// <param name="lnFormatType">
		/// The format type used for the output names. For more information about the various types of formats you can use, see
		/// ADS_NAME_TYPE_ENUM. This method does not support the ADS_NAME_TYPE_SID_OR_SID_HISTORY_NAME element in <c>ADS_NAME_TYPE_ENUM</c>.
		/// </param>
		/// <returns>A variant array of strings that hold names of the objects returned.</returns>
		/// <remarks>
		/// <para>This method gets the names of multiple objects. However, all of the names returned use a single format.</para>
		/// <para>
		/// When referral chasing is on, this method will not attempt to chase and resolve the path of a specified object not residing on the
		/// connected server.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following C/C++ code example shows how to translate a distinguished names that is compliant with RFC 1779 to the GUID format.
		/// The computer name of the directory server is "myServer".
		/// </para>
		/// <para>
		/// The following code example shows how to convert multiple names from the RFC 1779 type to the GUID type. The computer name of the
		/// directory server is "myServer".
		/// </para>
		/// <para>
		/// The following VBScript/ASP code example translates two distinguished names compliant with RFC 1779 to the GUID format. The
		/// computer name of the directory server is "myServer".
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsnametranslate-getex HRESULT GetEx( long lnFormatType, VARIANT
		// *pvar );
		[DispId(7)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object? GetEx([In] int lnFormatType);
	}

	/// <summary>
	/// <para>The <c>IADsNetAddress</c> interface provides methods for an ADSI client to access the Net Address attribute.</para>
	/// <para>You can call the property methods of this interface to obtain and modify the attribute.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsnetaddress
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsNetAddress")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("B21A50A9-4080-11D1-A3AC-00C04FB950DC"), CoClass(typeof(NetAddress))]
	public interface IADsNetAddress
	{
		/// <summary>Gets or sets the type of communication protocols.</summary>
		/// <value>The type of communication protocols.</value>
		[DispId(2)]
		int AddressType
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the network address.</summary>
		/// <value>The network address.</value>
		[DispId(3)]
		object Address
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(3)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}
	}

	/// <summary>
	/// <para>
	/// The <c>IADsO</c> interface is a dual interface that inherits from IADs. It is designed for representing and managing the organization
	/// to which an account belongs. This interface is one of several that provide support for directory services to organize accounts by
	/// country/region, locality (state/city/region), organization (company), and organizational unit (department). Organization is managed
	/// by this interface, locality by the IADsLocality interface, and organization unit by IADsOU.
	/// </para>
	/// <para>
	/// When a directory service provides hierarchical groupings of directory entries by country/region, locality, organization, and
	/// organization unit, you can use this, and the related interfaces, to expand the directory tree accordingly. In this case, the
	/// <c>IADsO</c> interface is implemented by an organization object that implements the IADsContainer interface as well.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadso
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsO")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("A1CD2DC6-EFFE-11CF-8ABC-00C04FD8D503")]
	public interface IADsO : IADs
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

		/// <summary>Gets or sets the description of the organization.</summary>
		/// <value>The description of the organization.</value>
		[DispId(15)]
		string Description
		{
			[DispId(15)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(15)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the name of the place in which the organization is located.</summary>
		/// <value>The name of the place in which the organization is located.</value>
		[DispId(16)]
		string LocalityName
		{
			[DispId(16)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(16)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the postal address of the organization.</summary>
		/// <value>The postal address of the organization.</value>
		[DispId(17)]
		string PostalAddress
		{
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(17)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the telephone number of the organization.</summary>
		/// <value>The telephone number of the organization.</value>
		[DispId(18)]
		string TelephoneNumber
		{
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(18)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the facsimile (fax) number of the organization.</summary>
		/// <value>The facsimile (fax) number of the organization.</value>
		[DispId(19)]
		string FaxNumber
		{
			[DispId(19)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(19)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets an array of ADsPath names of other ADSI objects which may be relevant to this object.</summary>
		/// <value>An array of ADsPath names of other ADSI objects which may be relevant to this object.</value>
		[DispId(20)]
		object SeeAlso
		{
			[DispId(20)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(20)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}
	}

	/// <summary>
	/// The <c>IADsObjectOptions</c> interface provides a direct mechanism to specify and obtain provider-specific options for manipulating
	/// an ADSI object. Typically, the options apply to search operations of the underlying directory store. The supported options are provider-specific.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsobjectoptions
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsObjectOptions")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("46F14FDA-232B-11D1-A808-00C04FD8D5A8")]
	public interface IADsObjectOptions
	{
		/// <summary>The <c>IADsOptions.GetOption</c> method gets a provider-specific option for a directory object.</summary>
		/// <param name="lnOption">
		/// Indicates the provider-specific option to get. This parameter can be any value in the ADS_OPTION_ENUM enumeration.
		/// </param>
		/// <returns>
		/// Pointer to a <c>VARIANT</c> variable that receives the current value for the option specified in the <c>lnOption</c> parameter.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsobjectoptions-getoption HRESULT GetOption( long lnOption,
		// VARIANT *pvValue );
		[DispId(2)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetOption([In] int lnOption);

		/// <summary>The <c>IADsOptions.SetOption</c> method sets a provider-specific option for manipulating a directory object.</summary>
		/// <param name="lnOption">
		/// Indicates the provider-specific option to set. This parameter can be any value in the ADS_OPTION_ENUM enumeration except
		/// <c>ADS_OPTION_SERVERNAME</c> or <c>ADS_OPTION_MUTUAL_AUTH_STATUS</c>.
		/// </param>
		/// <param name="vValue">Specifies the value to set for the option specified in the <c>lnOption</c> parameter.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsobjectoptions-setoption HRESULT SetOption( long lnOption,
		// VARIANT vValue );
		[DispId(3)]
		void SetOption([In] int lnOption, [In, MarshalAs(UnmanagedType.Struct)] object vValue);
	}

	/// <summary>
	/// <para>The <c>IADsOctetList</c> interface provides methods for an ADSI client to access the Octet List attribute.</para>
	/// <para>You can call the property methods of this interface to obtain and modify the attribute.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsoctetlist
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsOctetList")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("7B28B80F-4680-11D1-A3B4-00C04FB950DC"), CoClass(typeof(OctetList))]
	public interface IADsOctetList
	{
		/// <summary>Gets or sets an ordered sequence of byte arrays.</summary>
		/// <value>An ordered sequence of byte arrays.</value>
		[DispId(2)]
		object OctetList
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(2)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}
	}

	/// <summary>Gets the byte array from <see cref="IADsOctetList"/>.</summary>
	/// <param name="l">The <see cref="IADsOctetList"/> instance.</param>
	/// <returns>A byte array.</returns>
	public static byte[] GetBytes(this IADsOctetList l) => l.OctetList is null ? [] : (byte[])l.OctetList;

	/// <summary>
	/// <para>
	/// The <c>IADsOpenDSObject</c> interface is designed to supply a security context for binding to an object in the underlying directory
	/// store. It provides a means for specifying credentials of a client. Use this interface to bind to an ADSI object when you must supply
	/// a set of credentials for authentication in any directory service.
	/// </para>
	/// <para>
	/// ADSI maintains the security context in its cache. Thus, throughout the connection within a process, Once authenticated, the supplied
	/// user credentials are applied to any actions performed on this object and its children. This credential caching model applies to
	/// binding to different objects as well, provided that the binding takes place within the same connection and process.
	/// </para>
	/// <para>
	/// Calling the OpenDSObject method of this interface yields the cache handle. Releasing this cache handle releases the security context
	/// as well.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsopendsobject
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsOpenDSObject")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("DDF2891E-0F9C-11D0-8AD4-00C04FD8D503")]
	public interface IADsOpenDSObject
	{
		/// <summary>
		/// <para>
		/// The <c>IADsOpenDSObject::OpenDSObject</c> method binds to an ADSI object, using the given credentials, and retrieves an IDispatch
		/// pointer to the specified object.
		/// </para>
		/// <para>
		/// <c>Important</c>  It is not recommended that you use this method with the WinNT Provider. For more information, please see KB
		/// article 218497, User Authentication Issues with the Active Directory Service Interfaces WinNT Provider.
		/// </para>
		/// <para></para>
		/// </summary>
		/// <param name="lpszDNName">
		/// The null-terminated Unicode string that specifies the ADsPath of the ADSI object. For more information and examples of binding
		/// strings for this parameter, see LDAP ADsPath. When using the LDAP provider with an ADsPath that includes a specific server name,
		/// the <c>lnReserved</c> parameter should include the <c>ADS_SERVER_BIND</c> flag.
		/// </param>
		/// <param name="lpszUserName">
		/// The null-terminated Unicode string that specifies the user name to be used for securing permission from the namespace server. For
		/// more information, see the following Remarks section.
		/// </param>
		/// <param name="lpszPassword">
		/// The null-terminated Unicode string that specifies the password to be used to obtain permission from the namespace server.
		/// </param>
		/// <param name="lnReserved">Authentication flags used to define the binding options. For more information, see ADS_AUTHENTICATION_ENUM.</param>
		/// <returns>Pointer to a pointer to an IDispatch interface on the requested object.</returns>
		/// <remarks>
		/// <para>This method should not be used just to validate user credentials.</para>
		/// <para>
		/// When <c>lnReserved</c> is set, the behavior of <c>OpenDSObject</c> depends on the provider it connects to. High security
		/// namespaces may ignore these flags and always require authentication.
		/// </para>
		/// <para>
		/// The <c>IADsOpenDSObject::OpenDSObject</c> method maintains the authenticated and encrypted user credentials in the cache. Cached
		/// credentials may be used in subsequent operations for binding to any other directory objects. The ADSI client applications should
		/// not cache the credentials supplied by the user. Instead, they should rely on ADSI infrastructure to perform caching. To use the
		/// cached credentials, <c>lpszPassword</c> and <c>lpszUserName</c> must remain unchanged in any subsequent calls of
		/// <c>OpenDSObject</c>. The following code example shows this operation.
		/// </para>
		/// <para>
		/// The credentials passed to the <c>IADsOpenDSObject::OpenDSObject</c> function are used only with the particular object bound to
		/// and do not affect the security context of the calling thread. This means that, in the following code example, the call to
		/// <c>IADsOpenDSObject::OpenDSObject</c> will use different credentials than the call to <c>GetObject</c>.
		/// </para>
		/// <para>
		/// With a serverless binding, the server name, "server1", is not stated explicitly. The default server is used instead. Only the
		/// LDAP provider supports the serverless binding. To use this feature, the client computer must be on an Active Directory domain. To
		/// attempt a serverless binding from a computer, you must bind as a domain user.
		/// </para>
		/// <para>
		/// For credential caching to work properly, it is important to keep an object reference outstanding to maintain the cache handle. In
		/// the example given above, an attempt to open "obj2" after releasing "obj1" will result in an authentication failure.
		/// </para>
		/// <para>The IADsOpenDSObject method uses the default credentials when <c>lpszUserName</c> and <c>lpszPassword</c> are set to <c>NULL</c>.</para>
		/// <para>
		/// If Kerberos authentication is required for the successful completion of a specific directory request using the LDAP provider, the
		/// <c>lpszDNName</c> binding string must use either a serverless ADsPath, such as "LDAP://CN=Jeff
		/// Smith,CN=admin,DC=Fabrikam,DC=com", or it must use an ADsPath with a fully qualified DNS server name, such as
		/// "LDAP://central3.corp.Fabrikam.com/CN=Jeff Smith,CN=admin,DC=Fabrikam,DC=com". Binding to the server using a flat NETBIOS name or
		/// a short DNS name, for example, using the short name "central3" instead of "central3.corp.Fabrikam.com", may or may not yield
		/// Kerberos authentication.
		/// </para>
		/// <para>The ADsOpenObject helper function offers the same features as the <c>IADsOpenDSObject::OpenDSObject</c> method.</para>
		/// <para>With the LDAP provider for Active Directory, you may pass in <c>lpszUserName</c> as one of the following strings:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// The name of a user account, such as "jeffsmith". To use a user name by itself, you must set only the
		/// <c>ADS_SECURE_AUTHENTICATION</c> flag in the <c>lnReserved</c> parameter.
		/// </description>
		/// </item>
		/// <item>
		/// <description>The user path from a previous version of Windows, such as "Fabrikam\jeffsmith".</description>
		/// </item>
		/// <item>
		/// <description>
		/// Distinguished Name, such as "CN=Jeff Smith,OU=Sales,DC=Fabrikam,DC=Com". To use a DN, the <c>lnReserved</c> parameter must be
		/// zero or it must include the <c>ADS_USE_SSL</c> flag
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// User Principal Name (UPN), such as "jeffsmith@Fabrikam.com". To use a UPN, you must assign the appropriate UPN value for the
		/// <c>userPrincipalName</c> attribute of the target user object.
		/// </description>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to use IADsOpenDSObject to open the "Administrator" user object on "Fabrikam" with Secure
		/// Authentication through the LDAP provider.
		/// </para>
		/// <para>The following code example uses IADsOpenDSObject to open an Active Directory object through the LDAP provider.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsopendsobject-opendsobject HRESULT OpenDSObject( [in] BSTR
		// lpszDNName, [in] BSTR lpszUserName, [in] BSTR lpszPassword, [in] long lnReserved, [out] IDispatch **ppOleDsObj );
		[DispId(1)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		IADs OpenDSObject([In, MarshalAs(UnmanagedType.BStr)] string lpszDNName, [In, Optional, MarshalAs(UnmanagedType.BStr)] string? lpszUserName,
			[In, Optional, MarshalAs(UnmanagedType.BStr)] string? lpszPassword, [In] ADS_AUTHENTICATION lnReserved = ADS_AUTHENTICATION.ADS_SECURE_AUTHENTICATION);
	}

	/// <summary>
	/// The <c>IADsOU</c> interface is a dual interface that is used to manage organizationalUnit objects. All organizationalUnit objects
	/// that implement this interface also implement the IADsContainer interface.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsou
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsOU")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("A2F733B8-EFFE-11CF-8ABC-00C04FD8D503")]
	public interface IADsOU : IADs
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

		/// <summary>Gets or sets the textual description of the organizational unit.</summary>
		/// <value>The textual description of the organizational unit.</value>
		[DispId(15)]
		string Description
		{
			[DispId(15)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(15)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the name of the geographic region of the organizational unit.</summary>
		/// <value>The name of the geographic region of the organizational unit.</value>
		[DispId(16)]
		string LocalityName
		{
			[DispId(16)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(16)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the postal address of the organizational unit.</summary>
		/// <value>The postal address of the organizational unit.</value>
		[DispId(17)]
		string PostalAddress
		{
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(17)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the telephone number of the organizational unit.</summary>
		/// <value>The telephone number of the organizational unit.</value>
		[DispId(18)]
		string TelephoneNumber
		{
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(18)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the facsimile number of the organizational unit.</summary>
		/// <value>The facsimile number of the organizational unit.</value>
		[DispId(19)]
		string FaxNumber
		{
			[DispId(19)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(19)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// Gets or sets an array of strings that contains the distinguished names of other directory objects which may be relevant to this object.
		/// </summary>
		/// <value>An array of strings that contains the distinguished names of other directory objects which may be relevant to this object.</value>
		[DispId(20)]
		object SeeAlso
		{
			[DispId(20)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(20)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets the general business function or functions performed by the organizational unit, for example "Accounting".</summary>
		/// <value>The general business function or functions performed by the organizational unit, for example "Accounting".</value>
		[DispId(21)]
		string BusinessCategory
		{
			[DispId(21)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(21)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}
	}

	/// <summary>
	/// <para>The <c>IADsPath</c> interface provides methods for an ADSI client to access the <c>Path</c> attribute.</para>
	/// <para>You can call the property methods of this interface to obtain and modify the attribute.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadspath
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsPath")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("B287FCD5-4080-11D1-A3AC-00C04FB950DC"), CoClass(typeof(Path))]
	public interface IADsPath
	{
		/// <summary>Gets or sets the file type of the file system.</summary>
		/// <value>File type of the file system.</value>
		[DispId(2)]
		int Type
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the name of an existing volume of the file system.</summary>
		/// <value>Name of an existing volume of the file system.</value>
		[DispId(3)]
		string VolumeName
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(3)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the path of a directory of the file system..</summary>
		/// <value>Path of a directory of the file system.</value>
		[DispId(4)]
		string Path
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(4)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}
	}

	/// <summary>
	/// <para>The <c>IADsPathname</c> interface parses the X.500 and Windows path in ADSI.</para>
	/// <para>The <c>IADsPathname</c> interface can be used to:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Set and get paths of ADSI objects in different formats.</description>
	/// </item>
	/// <item>
	/// <description>Extract or add each element for a given ADsPath.</description>
	/// </item>
	/// <item>
	/// <description>Construct ADsPaths to be used in queries of directory objects.</description>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>IADsPathname</c> interface is implemented on a <c>Pathname</c> object. You must instantiate the <c>Pathname</c> object to use
	/// the methods defined in the <c>IADsPathname</c> interface. This requirement is similar to calling the CoCreateInstance() function in C++.
	/// </para>
	/// <para>You can also invoke the <c>New</c> operator in Visual Basic:</para>
	/// <para>Or use the <c>CreateObject</c> function in VBScript, supplying "Pathname" as the ProgID.</para>
	/// <para>The <c>IADsPathname</c> interface uses two enumeration types: ADS_SETTYPE_ENUM, and ADS_FORMAT_ENUM.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadspathname
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsPathname")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("D592AED4-F420-11D0-A36E-00C04FB950DC"), CoClass(typeof(Pathname))]
	public interface IADsPathname
	{
		/// <summary>
		/// The <c>IADsPathname::Set</c> method sets up the Pathname object for parsing a directory path. The path is set with a format as
		/// defined in ADS_SETTYPE_ENUM.
		/// </summary>
		/// <param name="bstrADsPath">Path of an ADSI object.</param>
		/// <param name="lnSetType">An ADS_SETTYPE_ENUM option that defines the format type to be retrieved.</param>
		/// <remarks>
		/// <para>
		/// This method will set the namespace as specified and identify the appropriate provider for performing the path cracking operation.
		/// Resetting to a different namespace will lose data already set by this method.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following Visual Basic code example sets a full ADSI path on the Pathname object.</para>
		/// <para>The following VBScript/ASP code example sets a full ADSI path on the Pathname object.</para>
		/// <para>The following C++ code example sets a full ADSI path on the Pathname object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspathname-set HRESULT Set( [in] BSTR bstrADsPath, [in] long
		// lnSetType );
		[DispId(2)]
		void Set([In, MarshalAs(UnmanagedType.BStr)] string bstrADsPath, [In] ADS_SETTYPE lnSetType);

		/// <summary>
		/// The <c>IADsPathname::SetDisplayType</c> method specifies how to display the path of an object. It can query for the path to be
		/// displayed in a string with both naming attributes and values, that is, "CN=Jeff Smith" or with values only, that is, "Jeff Smith".
		/// </summary>
		/// <param name="lnDisplayType">The display type of a path as defined in ADS_DISPLAY_ENUM.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspathname-setdisplaytype HRESULT SetDisplayType( long
		// lnDisplayType );
		[DispId(3)]
		void SetDisplayType([In] ADS_DISPLAY lnDisplayType);

		/// <summary>The <c>IADsPathname::Retrieve</c> method retrieves the path of the object with different format types.</summary>
		/// <param name="lnFormatType">
		/// Specifies the format that the path should be retrieved in. This can be one of the values specified in the ADS_FORMAT_ENUM enumeration.
		/// </param>
		/// <returns>
		/// Contains a pointer to a <c>BSTR</c> value the receives the object path. The caller must free this memory with the SysFreeString
		/// function when it is no longer required.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspathname-retrieve HRESULT Retrieve( [in] long lnFormatType,
		// [out] BSTR *pbstrADsPath );
		[DispId(4)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string Retrieve([In] ADS_FORMAT lnFormatType);

		/// <summary>The <c>IADsPathname::GetNumElements</c> method retrieves the number of elements in the path.</summary>
		/// <returns>The number of elements in the path.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspathname-getnumelements HRESULT GetNumElements( [out] long
		// *plnNumPathElements );
		[DispId(5)]
		int GetNumElements();

		/// <summary>The <c>IADsPathname::GetElement</c> method retrieves an element of a directory path.</summary>
		/// <param name="lnElementIndex">The index of the element.</param>
		/// <returns>The returned element.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspathname-getelement HRESULT GetElement( [in] long
		// lnElementIndex, [out] BSTR *pbstrElement );
		[DispId(6)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetElement([In] int lnElementIndex);

		/// <summary>
		/// The <c>IADsPathname::AddLeafElement</c> method adds an element to the end of the directory path already set on the Pathname object.
		/// </summary>
		/// <param name="bstrLeafElement">The name of the leaf element.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspathname-addleafelement HRESULT AddLeafElement( [in] BSTR
		// bstrLeafElement );
		[DispId(7)]
		void AddLeafElement([In, MarshalAs(UnmanagedType.BStr)] string bstrLeafElement);

		/// <summary>
		/// The <c>IADsPathname::RemoveLeafElement</c> method removes the last element from the directory path that has been set on the
		/// Pathname object.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspathname-removeleafelement HRESULT RemoveLeafElement();
		[DispId(8)]
		void RemoveLeafElement();

		/// <summary>The <c>IADsPathname::CopyPath</c> method creates a copy of the Pathname object.</summary>
		/// <returns>The IDispatch interface pointer on the returned IADsPathname object.</returns>
		/// <remarks>
		/// <para>This method is used to modify the object path and retain the original object path.</para>
		/// <para>Examples</para>
		/// <para>The following Visual Basic code example shows how to make a copy of a pathname.</para>
		/// <para>The following VBScript/ASP code example shows how to make a copy of a pathname.</para>
		/// <para>
		/// The following C++ code example creates a copy of a pathname object. For more information and a code example of the
		/// <c>GetPathnameObject</c> function, see IADsPathname.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspathname-copypath HRESULT CopyPath( [out] IDispatch
		// **ppAdsPath );
		[DispId(9)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object CopyPath();

		/// <summary>The <c>IADsPathname::GetEscapedElement</c> method is used to escape special characters in the input path.</summary>
		/// <param name="lnReserved">Reserved for future use.</param>
		/// <param name="bstrInStr">An input string.</param>
		/// <returns>An output string.</returns>
		/// <remarks>
		/// <para>
		/// This method is used to handle a path that contains special characters in a unescaped string as input from a user interface. The
		/// input string must be a single element (name-value pair) of the path; that is, "CN=Smith,Jeff".
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following Visual Basic code example shows the effect produced by <c>IADsPathname::GetEscapedElement</c>. After this code is
		/// executed, rdn will contain "cn=smith,jeff".
		/// </para>
		/// <para>
		/// The following VBScript code example shows the effect produced by <c>IADsPathname::GetEscapedElement</c>. After this code is
		/// executed, rdn will contain "cn=smith,jeff".
		/// </para>
		/// <para>
		/// The following C++ code example shows the effect produced by <c>IADsPathname::GetEscapedElement</c>. After this code is executed,
		/// rdn will contain "cn=smith,jeff".
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadspathname-getescapedelement HRESULT GetEscapedElement( [in]
		// long lnReserved, [in] BSTR bstrInStr, [out] BSTR *pbstrOutStr );
		[DispId(10)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetEscapedElement([In, Optional] int lnReserved, [In, MarshalAs(UnmanagedType.BStr)] string bstrInStr);

		/// <summary>Gets or sets how escaped characters are handled in a pathname.</summary>
		/// <value>Examine or specify how escaped characters are handled in a pathname. For more information and defined options, see ADS_ESCAPE_MODE_ENUM.</value>
		[DispId(11)]
		ADS_ESCAPE_MODE EscapedMode
		{
			[DispId(11)]
			get;
			[DispId(11)]
			[param: In]
			set;
		}
	}

	/// <summary>
	/// <para>The <c>IADsPostalAddress</c> interface provides methods for an ADSI client to access the <c>Postal Address</c> attribute.</para>
	/// <para>You can call the property methods of this interface to obtain and modify the attribute.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadspostaladdress
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsPostalAddress")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("7ADECF29-4680-11D1-A3B4-00C04FB950DC"), CoClass(typeof(PostalAddress))]
	public interface IADsPostalAddress
	{
		/// <summary>Gets or sets an array of six strings holding the postal address of the user.</summary>
		/// <value>An array of six strings holding the postal address of the user.</value>
		[DispId(2)]
		object PostalAddress
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(2)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}
	}

	/// <summary>
	/// The <c>IADsPrintJob</c> interface is a dual interface that inherits from IADs. It is designed for representing a print job. When a
	/// user submits a request to a printer to print a document, a print job is created in the print queue. The property methods allow you to
	/// access the information about a print job. Such information includes which printer performs the printing, who submitted the document,
	/// when the document was submitted, and how many pages will be printed.
	/// </summary>
	/// <remarks>
	/// <para>
	/// To manage a print job across a network, use the IADsPrintJobOperations interface, which supports the functionality to examine the
	/// status of a print job and to pause or resume the operation of printing the document, and so on.
	/// </para>
	/// <para>
	/// To access any print jobs in a print queue, call the IADsPrintQueueOperations::PrintJobs method to obtain the collection object
	/// holding all the print jobs in the print queue.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code example shows how to manage a print job submitted to the printer, "\aMachine\aPrinter".</para>
	/// <para>The following code example shows how to manage a print job submitted to the printer, "\aMachine\aPrinter".</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsprintjob
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsPrintJob")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("32FB6780-1ED0-11CF-A988-00AA006BC149")]
	public interface IADsPrintJob : IADs
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

		/// <summary>Gets the ADsPath string of the Print Queue that processes the print job.</summary>
		/// <value>The ADsPath string of the Print Queue that processes the print job.</value>
		[DispId(15)]
		string HostPrintQueue
		{
			[DispId(15)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the name of user who submitted the print job.</summary>
		/// <value>The name of user who submitted the print job.</value>
		[DispId(16)]
		string User
		{
			[DispId(16)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the ADsPath string of the user object that submitted this print job.</summary>
		/// <value>The ADsPath string of the user object that submitted this print job.</value>
		[DispId(17)]
		string UserPath
		{
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the time when the job was submitted to the queue.</summary>
		/// <value>The time when the job was submitted to the queue.</value>
		[DispId(18)]
		DateTime TimeSubmitted
		{
			[DispId(18)]
			get;
		}

		/// <summary>Gets the total number of pages in the print job.</summary>
		/// <value>The total number of pages in the print job.</value>
		[DispId(19)]
		int TotalPages
		{
			[DispId(19)]
			get;
		}

		/// <summary>Gets the size, in bytes, of the print job.</summary>
		/// <value>The size, in bytes, of the print job.</value>
		[DispId(234)]
		int Size
		{
			[DispId(234)]
			get;
		}

		/// <summary>Gets or sets the description of the print job.</summary>
		/// <value>The description of the print job.</value>
		[DispId(20)]
		string Description
		{
			[DispId(20)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(20)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the priority of the print job.</summary>
		/// <value>The priority of the print job.</value>
		[DispId(21)]
		int Priority
		{
			[DispId(21)]
			get;
			[DispId(21)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the earliest time when the print job should be started.</summary>
		/// <value>The earliest time when the print job should be started.</value>
		[DispId(22)]
		DateTime StartTime
		{
			[DispId(22)]
			get;
			[DispId(22)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the latest time when the print job should be started.</summary>
		/// <value>The latest time when the print job should be started.</value>
		[DispId(23)]
		DateTime UntilTime
		{
			[DispId(23)]
			get;
			[DispId(23)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the user to be notified when job is completed.</summary>
		/// <value>The user to be notified when job is completed.</value>
		[DispId(24)]
		string Notify
		{
			[DispId(24)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(24)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the ADsPath string of the user object to be notified when the print job is completed.</summary>
		/// <value>The ADsPath string of the user object to be notified when the print job is completed.</value>
		[DispId(25)]
		string NotifyPath
		{
			[DispId(25)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(25)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}
	}
}