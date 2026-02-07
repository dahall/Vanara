using System.Collections.Generic;
using System.Linq;

namespace Vanara.PInvoke;

public static partial class ActiveDS
{
	/// <summary>
	/// The <c>IADsSession</c> interface is a dual interface that inherits from IADs. It is designed to represent an active session for file
	/// service across a network.
	/// </summary>
	/// <remarks>
	/// <para>
	/// When a remote user opens resources on a target computer, an active session is established between the remote user and that computer.
	/// Many resources can be opened in a single active session. ADSI represents this process with a session object that implements this interface.
	/// </para>
	/// <para>
	/// Call the methods of this interface to examine session-specific data, for example, who is using the session, which computer is used,
	/// and the time elapsed for the current session.
	/// </para>
	/// <para>Sessions are managed by the file service. To obtain session objects, first bind to this service ("LanmanServer" or "FPNW").</para>
	/// <para>Examples</para>
	/// <para>The following code example shows how to bind to a session.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadssession
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsSession")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("398B7DA0-4AAB-11CF-AE2C-00AA006EBFB9")]
	public interface IADsSession : IADs
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

		/// <summary>Gets the name of the user of the session.</summary>
		/// <value>The name of the user of the session.</value>
		[DispId(15)]
		string User
		{
			[DispId(15)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the ADsPath of the user object for the user of this session.</summary>
		/// <value>The ADsPath of the user object for the user of this session.</value>
		[DispId(16)]
		string UserPath
		{
			[DispId(16)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the name of the client workstation.</summary>
		/// <value>The name of the client workstation.</value>
		[DispId(17)]
		string Computer
		{
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the ADsPath of the computer object for the client workstation.</summary>
		/// <value>The ADsPath of the computer object for the client workstation.</value>
		[DispId(18)]
		string ComputerPath
		{
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the elapsed time, in seconds, since the session started.</summary>
		/// <value>The elapsed time, in seconds, since the session started.</value>
		[DispId(19)]
		int ConnectTime
		{
			[DispId(19)]
			get;
		}

		/// <summary>Gets the idle time, in seconds, of the session.</summary>
		/// <value>The idle time, in seconds, of the session.</value>
		[DispId(20)]
		int IdleTime
		{
			[DispId(20)]
			get;
		}
	}

	/// <summary>
	/// <para>
	/// The <c>IADsSyntax</c> interface specifies methods to identify and modify the available Automation data types used to represent its
	/// data. ADSI defines a standard set of syntax objects that can be used uniformly across multiple directory service implementations.
	/// </para>
	/// <para>Use the <c>IADsSyntax</c> interface to process the property values of any instance of ADSI schema class object.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadssyntax
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsSyntax")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("C8F93DD2-4AE0-11CF-9E73-00AA004A5691")]
	public interface IADsSyntax : IADs
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
		/// Retrieves and sets a LONG that contains the value of the VT_xxx constant for the Automation data type that represents this syntax.
		/// </summary>
		/// <value>A LONG that contains the value of the VT_xxx constant for the Automation data type that represents this syntax.</value>
		[DispId(15)]
		int OleAutoDataType
		{
			[DispId(15)]
			get;
			[DispId(15)]
			[param: In]
			set;
		}
	}

	/// <summary>
	/// <para>The <c>IADsTimestamp</c> interface provides methods for an ADSI client to access the <c>Timestamp</c> attribute.</para>
	/// <para>You can call the property methods of this interface to obtain and modify the attribute.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadstimestamp
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsTimestamp")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("B2F5A901-4080-11D1-A3AC-00C04FB950DC"), CoClass(typeof(Timestamp))]
	public interface IADsTimestamp
	{
		/// <summary>Gets or sets the number of seconds with zero value being 12:00 AM, January 1970, UTC.</summary>
		/// <value>Number of seconds with zero value being 12:00 AM, January 1970, UTC.</value>
		[DispId(2)]
		int WholeSeconds
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets an event identifier.</summary>
		/// <value>An event identifier.</value>
		[DispId(3)]
		int EventID
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}
	}

	/// <summary>
	/// <para>The <c>IADsTypedName</c> interface provides methods for an ADSI client to access the <c>Typed Name</c> attribute.</para>
	/// <para>You can call the property methods of this interface to obtain and modify the attribute.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadstypedname
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsTypedName")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("B371A349-4080-11D1-A3AC-00C04FB950DC"), CoClass(typeof(TypedName))]
	public interface IADsTypedName
	{
		/// <summary>Gets or sets the name of the object.</summary>
		/// <value>The name of the object.</value>
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

		/// <summary>Gets or sets the priority level associated with the object.</summary>
		/// <value>The priority level associated with the object.</value>
		[DispId(3)]
		int Level
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the frequency of reference of the object.</summary>
		/// <value>The frequency of reference of the object.</value>
		[DispId(4)]
		int Interval
		{
			[DispId(4)]
			get;
			[DispId(4)]
			[param: In]
			set;
		}
	}

	/// <summary>
	/// <para>
	/// The <c>IADsUser</c> interface is a dual interface that inherits from IADs. It is designed to represent and manage an end-user account
	/// on a network. Call the methods of this interface to access and manipulate end-user account data. Such data includes names of the
	/// user, telephone numbers, job title, and so on. This interface supports features for determining the group association of the user,
	/// and for setting or changing the password.
	/// </para>
	/// <para>
	/// To bind to a domain user through a WinNT provider, use the domain name as part of the ADsPath, as shown in the following code example.
	/// </para>
	/// <para>Similarly, use the computer name as part of the ADsPath to bind to a local user.</para>
	/// <para>
	/// In Active Directory, domain users reside in the directory. The following code example shows how to bind to a domain user through an
	/// LDAP provider.
	/// </para>
	/// <para>
	/// However, local accounts reside in the local SAM database and the LDAP provider does not communicate with the local database. Thus, to
	/// bind to a local user, you must go through a WinNT provider as described in the second code example.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// As with any other ADSI object, the container object creates a Windows user account object. First, bind to a container object. Then,
	/// call the IADsContainer::Create method and specify mandatory or optional attributes.
	/// </para>
	/// <para>
	/// With WinNT, you do not have to specify any additional attributes when creating a user. You may call the IADsContainer::Create method
	/// to create the user object directly.
	/// </para>
	/// <para>In this case, a domain user is created with the following default values.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Property</description>
	/// <description>Value</description>
	/// </listheader>
	/// <item>
	/// <description><c>Full Name</c></description>
	/// <description>SAM Account Name (such as jeffsmith)</description>
	/// </item>
	/// <item>
	/// <description><c>Password</c></description>
	/// <description>Empty</description>
	/// </item>
	/// <item>
	/// <description><c>User Must Change Password</c></description>
	/// <description><c>TRUE</c></description>
	/// </item>
	/// <item>
	/// <description><c>User Cannot Change Password</c></description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description><c>Password Never Expires</c></description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description><c>Account Disabled</c></description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description><c>Group</c></description>
	/// <description>Domain User</description>
	/// </item>
	/// <item>
	/// <description><c>Profile</c></description>
	/// <description>Empty</description>
	/// </item>
	/// <item>
	/// <description><c>Account Never Expires</c></description>
	/// <description><c>TRUE</c></description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>To create a local user, bind to a target computer, as shown in the following code example.</para>
	/// <para>
	/// The newly created local user will have the same default properties as the domain user. The group membership, however, will be
	/// "users", instead of "domain user".
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsuser
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsUser")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("3E37E320-17E2-11CF-ABC4-02608C9E7553")]
	public interface IADsUser : IADs
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

		/// <summary>Gets the last node that is considered a possible intruder; this is available if Intruder detection is active.</summary>
		/// <value>The last node that is considered a possible intruder; this is available if Intruder detection is active.</value>
		[DispId(53)]
		string BadLoginAddress
		{
			[DispId(53)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the number of bad logon attempts since the last reset.</summary>
		/// <value>The number of bad logon attempts since the last reset.</value>
		[DispId(54)]
		int BadLoginCount
		{
			[DispId(54)]
			get;
		}

		/// <summary>Gets the date and time of the last network login.</summary>
		/// <value>The date and time of the last network login.</value>
		[DispId(56)]
		DateTime LastLogin
		{
			[DispId(56)]
			get;
		}

		/// <summary>Gets the date and time of the last network logoff.</summary>
		/// <value>The date and time of the last network logoff.</value>
		[DispId(57)]
		DateTime LastLogoff
		{
			[DispId(57)]
			get;
		}

		/// <summary>Gets the date and time of the last failed network login.</summary>
		/// <value>The date and time of the last failed network login.</value>
		[DispId(58)]
		DateTime LastFailedLogin
		{
			[DispId(58)]
			get;
		}

		/// <summary>Gets the last time the password was changed.</summary>
		/// <value>The last time the password was changed.</value>
		[DispId(59)]
		DateTime PasswordLastChanged
		{
			[DispId(59)]
			get;
		}

		/// <summary>Gets or sets the text description of the user.</summary>
		/// <value>The text description of the user.</value>
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

		/// <summary>Gets or sets the division within a company or organization.</summary>
		/// <value>The division within a company or organization.</value>
		[DispId(19)]
		string Division
		{
			[DispId(19)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(19)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the department, an organizational unit (OU), within the company to which the user belongs.</summary>
		/// <value>The department, an organizational unit (OU), within the company to which the user belongs.</value>
		[DispId(122)]
		string Department
		{
			[DispId(122)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(122)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the employee identifier of the user.</summary>
		/// <value>The employee identifier of the user.</value>
		[DispId(20)]
		string EmployeeID
		{
			[DispId(20)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(20)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the full name of the user.</summary>
		/// <value>The full name of the user.</value>
		[DispId(23)]
		string FullName
		{
			[DispId(23)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(23)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the first name of the user.</summary>
		/// <value>The first name of the user.</value>
		[DispId(22)]
		string FirstName
		{
			[DispId(22)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(22)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the last name of the user.</summary>
		/// <value>The last name of the user.</value>
		[DispId(25)]
		string LastName
		{
			[DispId(25)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(25)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets an additional name, for example, the middle name, for the user.</summary>
		/// <value>An additional name, for example, the middle name, for the user.</value>
		[DispId(27)]
		string OtherName
		{
			[DispId(27)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(27)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the name prefix of the user, for example "Ms.", or "Hon.".</summary>
		/// <value>The name prefix of the user, for example "Ms.", or "Hon.".</value>
		[DispId(114)]
		string NamePrefix
		{
			[DispId(114)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(114)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the name suffix of the user, for example "Jr.", or "III".</summary>
		/// <value>The name suffix of the user, for example "Jr.", or "III".</value>
		[DispId(115)]
		string NameSuffix
		{
			[DispId(115)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(115)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the title of the user.</summary>
		/// <value>The title of the user.</value>
		[DispId(36)]
		string Title
		{
			[DispId(36)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(36)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the manager of the user.</summary>
		/// <value>The manager of the user.</value>
		[DispId(26)]
		string Manager
		{
			[DispId(26)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(26)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// Gets or sets an array of home phone numbers of the user. In Active Directory, this property is single-valued and the array has
		/// one element.
		/// </summary>
		/// <value>
		/// An array of home phone numbers of the user. In Active Directory, this property is single-valued and the array has one element.
		/// </value>
		[DispId(32)]
		object TelephoneHome
		{
			[DispId(32)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(32)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>
		/// Gets or sets an array of mobile phone numbers of the user. In Active Directory this property is single-valued and the array has
		/// one element only.
		/// </summary>
		/// <value>
		/// An array of mobile phone numbers of the user. In Active Directory this property is single-valued and the array has one element only.
		/// </value>
		[DispId(33)]
		object TelephoneMobile
		{
			[DispId(33)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(33)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>
		/// Gets or sets an array of, usually work-related, phone numbers associated with the user. In Active Directory this property is
		/// single-valued and the array is of a single element.
		/// </summary>
		/// <value>
		/// An array of, usually work-related, phone numbers associated with the user. In Active Directory this property is single-valued and
		/// the array is of a single element.
		/// </value>
		[DispId(34)]
		object TelephoneNumber
		{
			[DispId(34)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(34)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>
		/// Gets or sets an array of pager numbers of the user. In Active Directory this property is single-valued and the array is of a
		/// single element.
		/// </summary>
		/// <value>
		/// An array of pager numbers of the user. In Active Directory this property is single-valued and the array is of a single element.
		/// </value>
		[DispId(17)]
		object TelephonePager
		{
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(17)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>
		/// Gets or sets the fax number, or numbers, of the user. In Active Directory, this property is single-valued and the VARIANT array
		/// has one element.
		/// </summary>
		/// <value>
		/// The fax number, or numbers, of the user. In Active Directory, this property is single-valued and the VARIANT array has one element.
		/// </value>
		[DispId(16)]
		object FaxNumber
		{
			[DispId(16)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(16)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>
		/// Gets or sets the office locations as a BSTR array for the user. For Active Directory, this property is single-valued and the
		/// array has one element.
		/// </summary>
		/// <value>
		/// The office locations as a BSTR array for the user. For Active Directory, this property is single-valued and the array has one element.
		/// </value>
		[DispId(28)]
		object OfficeLocations
		{
			[DispId(28)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(28)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>
		/// Gets or sets the postal address as a BSTR array. This property is multi-valued to hold more than addresses of the user. The
		/// internal format of a PostalAddress should comply with CCITT F.401 as referenced in X.521-1993, which defines a PostalAddress as
		/// six elements of 30 bytes each, holding a street address, (optionally) Post Office Box, city or locality, state or province,
		/// Postal Code, and Country/Region.
		/// </summary>
		/// <value>
		/// Postal address as a BSTR array. This property is multi-valued to hold more than addresses of the user. The internal format of a
		/// PostalAddress should comply with CCITT F.401 as referenced in X.521-1993, which defines a PostalAddress as six elements of 30
		/// bytes each, holding a street address, (optionally) Post Office Box, city or locality, state or province, Postal Code, and Country/Region.
		/// </value>
		[DispId(30)]
		object PostalAddresses
		{
			[DispId(30)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(30)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>
		/// Gets or sets the postal codes as a BSTR array. Postal codes are positionally linked to the PostalAddresses array. In Active
		/// Directory, however, this property is single-valued and the array has a single element.
		/// </summary>
		/// <value>
		/// The postal codes as a BSTR array. Postal codes are positionally linked to the PostalAddresses array. In Active Directory,
		/// however, this property is single-valued and the array has a single element.
		/// </value>
		[DispId(31)]
		object PostalCodes
		{
			[DispId(31)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(31)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets an array of ADsPaths of other objects related to the user.</summary>
		/// <value>An array of ADsPaths of other objects related to the user.</value>
		[DispId(117)]
		object SeeAlso
		{
			[DispId(117)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(117)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets a flag to indicate if the account is, or should be, disabled.</summary>
		/// <value>A flag to indicate if the account is, or should be, disabled.</value>
		[DispId(37)]
		bool AccountDisabled
		{
			[DispId(37)]
			get;
			[DispId(37)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the date and time after which the user cannot log on.</summary>
		/// <value>The date and time after which the user cannot log on.</value>
		[DispId(38)]
		DateTime AccountExpirationDate
		{
			[DispId(38)]
			get;
			[DispId(38)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the number of times the user can log on after the password has expired.</summary>
		/// <value>The number of times the user can log on after the password has expired.</value>
		[DispId(41)]
		int GraceLoginsAllowed
		{
			[DispId(41)]
			get;
			[DispId(41)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the number of logons allowed before the account is locked.</summary>
		/// <value>The number of logons allowed before the account is locked.</value>
		[DispId(42)]
		int GraceLoginsRemaining
		{
			[DispId(42)]
			get;
			[DispId(42)]
			[param: In]
			set;
		}

		/// <summary>
		/// Gets or sets a flag that indicates if the account is locked because of intruder detection. This property has limited usage when
		/// used with the LDAP ADSI provider. For more information about these limitations, see Account Lockout (LDAP Provider).
		/// </summary>
		/// <value>
		/// A flag that indicates if the account is locked because of intruder detection. This property has limited usage when used with the
		/// LDAP ADSI provider. For more information about these limitations, see Account Lockout (LDAP Provider).
		/// </value>
		[DispId(43)]
		bool IsAccountLocked
		{
			[DispId(43)]
			get;
			[DispId(43)]
			[param: In]
			set;
		}

		/// <summary>
		/// Gets or sets the time periods for each day of the week during which logons are permitted for the user. Represented as a table of
		/// Boolean values for the week, each indicating if that time slot is a valid logon time. Be aware that the representation is
		/// provider and directory-specific..
		/// </summary>
		/// <value>
		/// The time periods for each day of the week during which logons are permitted for the user. Represented as a table of Boolean
		/// values for the week, each indicating if that time slot is a valid logon time. Be aware that the representation is provider and directory-specific..
		/// </value>
		[DispId(45)]
		object LoginHours
		{
			[DispId(45)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(45)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets the addresses or names of workstations, of the BSTR data type, from which the user can log on.</summary>
		/// <value>The addresses or names of workstations, of the BSTR data type, from which the user can log on.</value>
		[DispId(46)]
		object LoginWorkstations
		{
			[DispId(46)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(46)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets the number of simultaneous login sessions allowed.</summary>
		/// <value>The number of simultaneous login sessions allowed.</value>
		[DispId(47)]
		int MaxLogins
		{
			[DispId(47)]
			get;
			[DispId(47)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the maximum amount of disk space, in kilobytes, that the user can use.</summary>
		/// <value>The maximum amount of disk space, in kilobytes, that the user can use.</value>
		[DispId(48)]
		int MaxStorage
		{
			[DispId(48)]
			get;
			[DispId(48)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the date and time when the password expires.</summary>
		/// <value>The date and time when the password expires.</value>
		[DispId(49)]
		DateTime PasswordExpirationDate
		{
			[DispId(49)]
			get;
			[DispId(49)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the minimum length of the password.</summary>
		/// <value>The minimum length of the password.</value>
		[DispId(50)]
		int PasswordMinimumLength
		{
			[DispId(50)]
			get;
			[DispId(50)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets a flag that indicates if the password is required.</summary>
		/// <value>A flag that indicates if the password is required.</value>
		[DispId(51)]
		bool PasswordRequired
		{
			[DispId(51)]
			get;
			[DispId(51)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets a flag that indicates if a new password should be different from those known through a password history.</summary>
		/// <value>A flag that indicates if a new password should be different from those known through a password history.</value>
		[DispId(52)]
		bool RequireUniquePassword
		{
			[DispId(52)]
			get;
			[DispId(52)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the email address of the user.</summary>
		/// <value>The email address of the user.</value>
		[DispId(60)]
		string EmailAddress
		{
			[DispId(60)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(60)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the home directory of the user.</summary>
		/// <value>The home directory of the user.</value>
		[DispId(61)]
		string HomeDirectory
		{
			[DispId(61)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(61)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets an array of BSTR language names for the user.</summary>
		/// <value>An array of BSTR language names for the user.</value>
		[DispId(62)]
		object Languages
		{
			[DispId(62)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(62)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets the path to the user profile.</summary>
		/// <value>The path to the user profile.</value>
		[DispId(63)]
		string Profile
		{
			[DispId(63)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(63)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the login script path.</summary>
		/// <value>The login script path.</value>
		[DispId(64)]
		string LoginScript
		{
			[DispId(64)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(64)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets an OctetString array of bytes that store an image.</summary>
		/// <value>An OctetString array of bytes that store an image.</value>
		[DispId(65)]
		object Picture
		{
			[DispId(65)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(65)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets the URL for the home page of the user.</summary>
		/// <value>The URL for the home page of the user.</value>
		[DispId(120)]
		string HomePage
		{
			[DispId(120)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(120)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// The <c>IADsUser::Groups</c> method obtains a collection of the ADSI group objects to which this user belongs. The method returns
		/// an IADsMembers interface pointer through which you can enumerate all the groups in the collection.
		/// </summary>
		/// <returns>
		/// Pointer to a pointer to the IADsMembers interface on a members object that can be enumerated using IEnumVARIANT to determine the
		/// groups to which this end-user belongs.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsuser-groups HRESULT Groups( [out] IADsMembers **ppGroups );
		[DispId(66)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IADsMembers Groups();

		/// <summary>
		/// <para>
		/// The <c>IADsUser::SetPassword</c> method sets the user password to a specified value. For the LDAP provider, the user account must
		/// have been created and stored in the underlying directory using IADs::SetInfo before <c>IADsUser::SetPassword</c> is called.
		/// </para>
		/// <para>
		/// The WinNT provider, however, enables you to set the password on a newly created user object prior to calling SetInfo. This
		/// ensures that you create passwords that comply with the system password policy before you create the user account.
		/// </para>
		/// </summary>
		/// <param name="NewPassword">A <c>BSTR</c> that contains the new password.</param>
		/// <remarks>
		/// <para>
		/// The LDAP provider for Active Directory uses one of three processes to set the password; third-party LDAP directories such as
		/// iPlanet do not use this password authentication process. The method may vary according to the network configuration. Attempts to
		/// set the password occur in the following order:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// First, the LDAP provider attempts to use LDAP over a 128-bit SSL connection. For LDAP SSL to operate successfully, the LDAP
		/// server must have the appropriate server authentication certificate installed and the clients running the ADSI code must trust the
		/// authority that issued those certificates. Both the server and the client must support 128-bit encryption.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Second, if the SSL connection is unsuccessful, the LDAP provider attempts to use Kerberos.</description>
		/// </item>
		/// <item>
		/// <description>
		/// Third, if Kerberos is unsuccessful, the LDAP provider attempts a NetUserSetInfo API call. In previous releases, ADSI called
		/// <c>NetUserSetInfo</c> in the security context in which the thread was running, and not the security context specified in the call
		/// to IADsOpenDSObject::OpenDSObject or ADsOpenObject. In later releases, this was changed so that the ADSI LDAP provider would
		/// impersonate the user specified in the <c>OpenDSObject</c> call when it calls NetUserSetInfo.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// In Active Directory, the caller must have the Reset Password extended control access right to set the password with this method.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to set the user password, if you have the permission to do so.</para>
		/// <para>The following code example shows how to set the user password, if you have the permission to do so.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsuser-setpassword HRESULT SetPassword( BSTR NewPassword );
		[DispId(67)]
		void SetPassword([In, MarshalAs(UnmanagedType.BStr)] string NewPassword);

		/// <summary>The <c>IADsUser::ChangePassword</c> method changes the user password from the specified old value to a new value.</summary>
		/// <param name="bstrOldPassword">A <c>BSTR</c> that contains the current password.</param>
		/// <param name="bstrNewPassword">A <c>BSTR</c> that contains the new password.</param>
		/// <remarks>
		/// <para>
		/// <c>IADsUser::ChangePassword</c> functions similarly to IADsUser::SetPassword in that it will use one of three methods to try to
		/// change the password. Initially, the LDAP provider will attempt an LDAP change password operation, if a secure SSL connection to
		/// the server is established. If this attempt fails, the LDAP provider will next try to use Kerberos (see
		/// <c>IADsUser::SetPassword</c> for some problems that may result on Windows with cross-forest authentication), and if this also
		/// fails, it will finally call the Active Directory specific network management API, NetUserChangePassword.
		/// </para>
		/// <para>
		/// In Active Directory, the caller must have the Change Password extended control access right to change the password with this method.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to change a user password.</para>
		/// <para>The following code example shows how to change a user password.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsuser-changepassword HRESULT ChangePassword( [in] BSTR
		// bstrOldPassword, [out] BSTR bstrNewPassword );
		[DispId(68)]
		void ChangePassword([In, MarshalAs(UnmanagedType.BStr)] string bstrOldPassword, [In, MarshalAs(UnmanagedType.BStr)] string bstrNewPassword);
	}

	/// <summary>
	/// <para>
	/// The <c>IADsWinNTSystemInfo</c> interface retrieves the WinNT system information about a computer. Such system information includes
	/// user account name, user domain, host name, and the primary domain controller of the host computer.
	/// </para>
	/// <para>
	/// The <c>IADsWinNTSystemInfo</c> interface is implemented on the <c>WinNTSystemInfo</c> object residing in Activeds.dll, which is
	/// included in the standard installation of ADSI for domain-capable editions of Windows. You must explicitly create an instance of the
	/// <c>WinNTSystemInfo</c> object to call the methods on the <c>IADsWinNTSystemInfo</c> interface. This requirement means creating an
	/// <c>WinNTSystemInfo</c> instance with the CoCreateInstance function in C/C++.
	/// </para>
	/// <para>You can also use the <c>New</c> operator in Visual Basic.</para>
	/// <para>You can also call the <c>CreateObject</c> function in a scripting environment, supplying "WinNTSystemInfo" as the ProgID.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadswinntsysteminfo
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsWinNTSystemInfo")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("6C6D65DC-AFD1-11D2-9CB9-0000F87A369E"), CoClass(typeof(WinNTSystemInfo))]
	public interface IADsWinNTSystemInfo
	{
		/// <summary>Gets the name of the user account under which the WinNTSystemInfo object is created.</summary>
		/// <value>The name of the user account under which the WinNTSystemInfo object is created.</value>
		[DispId(2)]
		string UserName
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the name of the host computer where the application is running.</summary>
		/// <value>Name of the host computer where the application is running.</value>
		[DispId(3)]
		string ComputerName
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the name of the domain to which the user belongs.</summary>
		/// <value>The name of the domain to which the user belongs.</value>
		[DispId(4)]
		string DomainName
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the name of the primary domain controller to which the host computer belongs.</summary>
		/// <value>The name of the primary domain controller to which the host computer belongs.</value>
		[DispId(5)]
		string? PDC
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	/// <summary>
	/// <para>
	/// The <c>IDirectoryObject</c> interface is a non-Automation COM interface that provides clients with direct access to directory service
	/// objects. The interface enables access by means of a direct over-the-wire protocol, rather than through the ADSI attribute cache.
	/// Using the over-the-wire protocol optimizes performance. With <c>IDirectoryObject</c>, a client can get, or set, any number of object
	/// attributes with one method call. Unlike the corresponding Automation methods, which are invoked in batch, those of
	/// <c>IDirectoryObject</c> are executed when they are called. <c>IDirectoryObject</c> performs no attribute caching.
	/// </para>
	/// <para>
	/// Non-Automation clients can call the methods of <c>IDirectoryObject</c> to optimize performance and take advantage of native directory
	/// service interfaces. Automation clients cannot use <c>IDirectoryObject</c>. Instead, they should use the IADs interface.
	/// </para>
	/// <para>Of the ADSI system-supplied providers, only the LDAP provider supports this interface.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-idirectoryobject
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IDirectoryObject")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("E798DE2C-22E4-11D0-84FE-00C04FD8D503")]
	public interface IDirectoryObject
	{
		/// <summary>
		/// The <c>IDirectoryObject::GetObjectInformation</c> method retrieves a pointer to an ADS_OBJECT_INFO structure that contains data
		/// regarding the identity and location of a directory service object.
		/// </summary>
		/// <param name="ppObjInfo">
		/// Provides the address of a pointer to an ADS_OBJECT_INFO structure that contains data regarding the requested directory service
		/// object. If <c>ppObjInfo</c> is <c>NULL</c> on return, <c>GetObjectInformation</c> cannot obtain the requested data.
		/// </param>
		/// <remarks>
		/// <para>
		/// The caller should call the FreeADsMem helper function to release the ADS_OBJECT_INFO structure created by the
		/// <c>GetObjectInformation</c> function.
		/// </para>
		/// <para>Automation clients must call IADs::GetInfo.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following C++ code example shows how to retrieve the object data (ADS_OBJECT_INFO) using the <c>GetObjectInformation</c>
		/// method of an object (m_pDirObject) that implements the IDirectoryObject interface.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-idirectoryobject-getobjectinformation HRESULT
		// GetObjectInformation( [out] PADS_OBJECT_INFO *ppObjInfo );
		void GetObjectInformation(out ManagedStructPointer<ADS_OBJECT_INFO> ppObjInfo);

		/// <summary>
		/// The <c>IDirectoryObject::GetObjectAttributes</c> method retrieves one or more specified attributes of the directory service object.
		/// </summary>
		/// <param name="pAttributeNames">
		/// <para>Specifies an array of names of the requested attributes.</para>
		/// <para>
		/// To request all of the object's attributes, set <c>pAttributeNames</c> to <c>NULL</c> and set the <c>dwNumberAttributes</c>
		/// parameter to (DWORD)-1.
		/// </para>
		/// </param>
		/// <param name="dwNumberAttributes">
		/// Specifies the size of the <c>pAttributeNames</c> array. If -1, all of the object's attributes are requested.
		/// </param>
		/// <param name="ppAttributeEntries">
		/// Pointer to a variable that receives a pointer to an array of ADS_ATTR_INFO structures that contain the requested attribute
		/// values. If no attributes could be obtained from the directory service object, the returned pointer is <c>NULL</c>.
		/// </param>
		/// <param name="pdwNumAttributesReturned">
		/// Pointer to a <c>DWORD</c> variable that receives the number of attributes retrieved in the <c>ppAttributeEntries</c> array.
		/// </param>
		/// <remarks>
		/// <para>
		/// ADSI allocates the memory for the array of ADS_ATTR_INFO structures returned in the <c>ppAttributeEntries</c> parameter. The
		/// caller must call FreeADsMem to free the array.
		/// </para>
		/// <para>The order of attributes returned in <c>ppAttributeEntries</c> is not necessarily the same as requested in <c>pAttributeNames</c>.</para>
		/// <para>
		/// The <c>IDirectoryObject::GetObjectAttributes</c> method attempts to read the schema definition of the requested attributes so it
		/// can return the attribute values in the appropriate format in the ADSVALUE structures contained in the ADS_ATTR_INFO structures.
		/// However, <c>GetObjectAttributes</c> can succeed even when the schema definition is not available, in which case the
		/// <c>dwADsType</c> member of the <c>ADS_ATTR_INFO</c> structure returns ADSTYPE_PROV_SPECIFIC and the value is returned in an
		/// ADS_PROV_SPECIFIC structure. When you process the results of a <c>GetObjectAttributes</c> call, verify <c>dwADsType</c> to ensure
		/// that the data was returned in the expected format.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how the <c>IDirectoryObject::GetObjectAttributes</c> method can be used.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-idirectoryobject-getobjectattributes HRESULT GetObjectAttributes(
		// [in] StrPtrUni *pAttributeNames, [in] DWORD dwNumberAttributes, [out] PADS_ATTR_INFO *ppAttributeEntries, [out] DWORD
		// *pdwNumAttributesReturned );
		void GetObjectAttributes([In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] string[]? pAttributeNames,
			[In] uint dwNumberAttributes, out ManagedArrayPointer<ADS_ATTR_INFO> ppAttributeEntries, out uint pdwNumAttributesReturned);

		/// <summary>
		/// The <c>IDirectoryObject::SetObjectAttributes</c> method modifies data in one or more specified object attributes defined in the
		/// ADS_ATTR_INFO structure.
		/// </summary>
		/// <param name="pAttributeEntries">
		/// Provides an array of attributes to be modified. Each attribute contains the name of the attribute, the operation to perform, and
		/// the attribute value, if applicable. For more information, see the ADS_ATTR_INFO structure.
		/// </param>
		/// <param name="dwNumAttributes">
		/// Provides the number of attributes to be modified. This value should correspond to the size of the <c>pAttributeEntries</c> array.
		/// </param>
		/// <param name="pdwNumAttributesModified">
		/// Provides a pointer to a <c>DWORD</c> variable that contains the number of attributes modified by the <c>SetObjectAttributes</c> method.
		/// </param>
		/// <remarks>
		/// <para>
		/// In Active Directory (LDAP provider), the <c>IDirectoryObject::SetObjectAttributes</c> method is a transacted call. The attributes
		/// are either all committed or discarded. Other directory providers may not transact the call.
		/// </para>
		/// <para>
		/// Active Directory does not allow duplicate values on a multi-valued attribute. However, if you call <c>SetObjectAttributes</c> to
		/// append a duplicate value to a multi-valued attribute of an Active Directory object, the <c>SetObjectAttributes</c> call succeeds
		/// but the duplicate value is ignored.
		/// </para>
		/// <para>
		/// Similarly, if you use <c>SetObjectAttributes</c> to delete one or more values from a multi-valued property of an Active Directory
		/// object, the operation succeeds even if any or all of the specified values are not set for the property
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following C++ code example sets the <c>sn</c> attribute of a user object to the value of <c>Price</c> as a case-insensitive string.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-idirectoryobject-setobjectattributes HRESULT SetObjectAttributes(
		// [in] PADS_ATTR_INFO pAttributeEntries, [in] DWORD dwNumAttributes, [out] DWORD *pdwNumAttributesModified );
		void SetObjectAttributes([In] ManagedArrayPointer<ADS_ATTR_INFO> pAttributeEntries, [In] uint dwNumAttributes, out uint pdwNumAttributesModified);

		/// <summary>The <c>IDirectoryObject::CreateDSObject</c> method creates a child of the current directory service object.</summary>
		/// <param name="pszRDNName">Provides the relative distinguished name (relative path) of the object to be created.</param>
		/// <param name="pAttributeEntries">
		/// An array of ADS_ATTR_INFO structures that contain attribute definitions to be set when the object is created.
		/// </param>
		/// <param name="dwNumAttributes">Provides a number of attributes set when the object is created.</param>
		/// <param name="ppObject">Provides a pointer to the IDispatch interface on the created object.</param>
		/// <remarks>
		/// <para>
		/// Specify all attributes to be initialized on creation in the <c>pAttributeEntries</c> array. You may also specify optional
		/// attributes. When creating a directory object with this method, attributes with any of the string data types cannot be empty or zero-length.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following C/C++ code example shows how to create a user object using the <c>IDirectoryObject::CreateDSObject</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-idirectoryobject-createdsobject HRESULT CreateDSObject( [in]
		// StrPtrUni pszRDNName, [in] PADS_ATTR_INFO pAttributeEntries, [in] DWORD dwNumAttributes, [out] IDispatch **ppObject );
		void CreateDSObject([In, MarshalAs(UnmanagedType.LPWStr)] string pszRDNName, [In] ManagedArrayPointer<ADS_ATTR_INFO> pAttributeEntries, [In] uint dwNumAttributes, [MarshalAs(UnmanagedType.IDispatch)] out object ppObject);

		/// <summary>The <c>IDirectoryObject::DeleteDSObject</c> method deletes a leaf object in a directory tree.</summary>
		/// <param name="pszRDNName">The relative distinguished name (relative path) of the object to be deleted.</param>
		/// <remarks>
		/// <para>To delete a container object and its children, use the IADsDeleteOps::DeleteObject method.</para>
		/// <para>Examples</para>
		/// <para>The following C/C++ code example shows how to delete a user object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-idirectoryobject-deletedsobject HRESULT DeleteDSObject( StrPtrUni
		// pszRDNName );
		void DeleteDSObject([In, MarshalAs(UnmanagedType.LPWStr)] string pszRDNName);
	}

	/// <summary>
	/// The <c>IDirectoryObject::GetObjectInformation</c> method retrieves a pointer to an ADS_OBJECT_INFO structure that contains data
	/// regarding the identity and location of a directory service object.
	/// </summary>
	/// <param name="ido">The <see cref="IDirectoryObject"/> instance.</param>
	/// <returns>
	/// An ADS_OBJECT_INFO structure that contains data regarding the requested directory service object. If <see langword="null"/> on
	/// return, <c>GetObjectInformation</c> cannot obtain the requested data.
	/// </returns>
	public static ADS_OBJECT_INFO? GetObjectInformation(this IDirectoryObject ido)
	{
		try
		{
			ido.GetObjectInformation(out var p);
			var ret = p.Value;
			FreeADsMem((IntPtr)p);
			return ret;
		}
		catch { }
		return default;
	}

	/// <summary>
	/// The <c>IDirectoryObject::GetObjectAttributes</c> method retrieves one or more specified attributes of the directory service object.
	/// </summary>
	/// <param name="ido">The <see cref="IDirectoryObject"/> instance.</param>
	/// <param name="pAttributeNames">
	/// <para>Specifies an array of names of the requested attributes.</para>
	/// <para>To request all of the object's attributes, set <c>pAttributeNames</c> to <see langword="null"/>.</para>
	/// </param>
	/// <returns>
	/// An array of ADS_ATTR_INFO structures that contain the requested attribute values. If no attributes could be obtained from the
	/// directory service object, the returned array is empty.
	/// </returns>
	/// <remarks>
	/// <para>The order of attributes returned in <c>ppAttributeEntries</c> is not necessarily the same as requested in <c>pAttributeNames</c>.</para>
	/// <para>
	/// The <c>IDirectoryObject::GetObjectAttributes</c> method attempts to read the schema definition of the requested attributes so it can
	/// return the attribute values in the appropriate format in the ADSVALUE structures contained in the ADS_ATTR_INFO structures. However,
	/// <c>GetObjectAttributes</c> can succeed even when the schema definition is not available, in which case the <c>dwADsType</c> member
	/// of the <c>ADS_ATTR_INFO</c> structure returns ADSTYPE_PROV_SPECIFIC and the value is returned in an ADS_PROV_SPECIFIC structure.
	/// When you process the results of a <c>GetObjectAttributes</c> call, verify <c>dwADsType</c> to ensure that the data was returned in
	/// the expected format.
	/// </para>
	/// </remarks>
	public static ADS_ATTR_INFO[] GetObjectAttributes(this IDirectoryObject ido, params string[] pAttributeNames)
	{
		try
		{
			ido.GetObjectAttributes(pAttributeNames, unchecked((uint)(pAttributeNames?.Length ?? -1)), out var p, out var c);
			ADS_ATTR_INFO[] ret = p.ToArray(c) ?? [];
			FreeADsMem((IntPtr)p);
			return ret;
		}
		catch { }
		return [];
	}

	/// <summary>
	/// The <c>IDirectoryObject::SetObjectAttributes</c> method modifies data in one or more specified object attributes defined in the
	/// ADS_ATTR_INFO structure.
	/// </summary>
	/// <param name="ido">The <see cref="IDirectoryObject"/> instance.</param>
	/// <param name="pAttributeEntries">
	/// Provides an sequence of attributes to be modified. Each attribute contains the name of the attribute, the operation to perform, and
	/// the attribute value, if applicable. For more information, see the ADS_ATTR_INFO structure.
	/// </param>
	/// <returns>The number of attributes modified by the <c>SetObjectAttributes</c> method.</returns>
	/// <remarks>
	/// <para>
	/// In Active Directory (LDAP provider), the <c>IDirectoryObject::SetObjectAttributes</c> method is a transacted call. The attributes
	/// are either all committed or discarded. Other directory providers may not transact the call.
	/// </para>
	/// <para>
	/// Active Directory does not allow duplicate values on a multi-valued attribute. However, if you call <c>SetObjectAttributes</c> to
	/// append a duplicate value to a multi-valued attribute of an Active Directory object, the <c>SetObjectAttributes</c> call succeeds but
	/// the duplicate value is ignored.
	/// </para>
	/// <para>
	/// Similarly, if you use <c>SetObjectAttributes</c> to delete one or more values from a multi-valued property of an Active Directory
	/// object, the operation succeeds even if any or all of the specified values are not set for the property
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following C++ code example sets the <c>sn</c> attribute of a user object to the value of <c>Price</c> as a case-insensitive string.
	/// </para>
	/// </remarks>
	public static uint SetObjectAttributes(this IDirectoryObject ido, params ADS_ATTR_INFO[] pAttributeEntries)
	{
		uint ret = 0;
		try
		{
			using SafeNativeArray<ADS_ATTR_INFO> p = new(pAttributeEntries);
			ido.SetObjectAttributes(p, (uint)p.Count, out ret);
			return ret;
		}
		catch { }
		return ret;
	}

	/// <summary>
	/// The <c>IDirectoryObject::CreateDSObject</c> method creates a child of the current directory service object.
	/// </summary>
	/// <param name="ido">The <see cref="IDirectoryObject"/> instance.</param>
	/// <param name="pszRDNName">Provides the relative distinguished name (relative path) of the object to be created.</param>
	/// <param name="pAttributeEntries">
	/// An array of ADS_ATTR_INFO structures that contain attribute definitions to be set when the object is created.
	/// </param>
	/// <returns>On success, returns the IDispatch interface on the created object.</returns>
	/// <remarks>
	/// <para>
	/// Specify all attributes to be initialized on creation in the <c>pAttributeEntries</c> array. You may also specify optional
	/// attributes. When creating a directory object with this method, attributes with any of the string data types cannot be empty or zero-length.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following C/C++ code example shows how to create a user object using the <c>IDirectoryObject::CreateDSObject</c> method.</para>
	/// </remarks>
	public static object? CreateDSObject(this IDirectoryObject ido, string pszRDNName, [In, Optional] ADS_ATTR_INFO[]? pAttributeEntries)
	{
		object? ret = null;
		try
		{
			if (pAttributeEntries is null || pAttributeEntries.Length == 0)
			{
				ido.CreateDSObject(pszRDNName, IntPtr.Zero, 0, out ret);
			}
			else
			{
				using SafeNativeArray<ADS_ATTR_INFO> p = new(pAttributeEntries!);
				ido.CreateDSObject(pszRDNName, p, (uint)p.Count, out ret);
			}
		}
		catch { }
		return ret;
	}

	/// <summary>
	/// <para>
	/// The <c>IDirectorySearch</c> interface is a pure COM interface that provides a low overhead method that non-Automation clients can use
	/// to perform queries in the underlying directory.
	/// </para>
	/// <para>Of the ADSI system-supplied providers, only the LDAP provider supports this interface.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-idirectorysearch
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IDirectorySearch")]
	[ComImport, Guid("109BA8EC-92F0-11D0-A790-00C04FD8D5A8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDirectorySearch
	{
		/// <summary>
		/// The <c>IDirectorySearch::SetSearchPreference</c> method specifies a search preference for obtaining data in a subsequent search.
		/// </summary>
		/// <param name="pSearchPrefs">
		/// Provides a caller-allocated array of ADS_SEARCHPREF_INFO structures that contain the search preferences to be set.
		/// </param>
		/// <param name="dwNumPrefs">Provides the size of the <c>pSearchPrefs</c> array.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-idirectorysearch-setsearchpreference HRESULT SetSearchPreference(
		// [in] PADS_SEARCHPREF_INFO pSearchPrefs, [in] DWORD dwNumPrefs );
		[PreserveSig]
		HRESULT SetSearchPreference([In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ADS_SEARCHPREF_INFO[] pSearchPrefs, [In] int dwNumPrefs);

		/// <summary>
		/// The <c>IDirectorySearch::ExecuteSearch</c> method executes a search and passes the results to the caller. Some providers, such as
		/// LDAP, will defer the actual execution until the caller invokes the IDirectorySearch::GetFirstRow method or the
		/// IDirectorySearch::GetNextRow method.
		/// </summary>
		/// <param name="pszSearchFilter">A search filter string in LDAP format, such as "(objectClass=user)".</param>
		/// <param name="pAttributeNames">
		/// An array of attribute names for which data is requested. If <c>NULL</c>, <c>dwNumberAttributes</c> must be 0 or 0xFFFFFFFF.
		/// </param>
		/// <param name="dwNumberAttributes">
		/// The size of the <c>pAttributeNames</c> array. The special value 0xFFFFFFFF indicates that <c>pAttributeNames</c> is ignored and
		/// can be <c>NULL</c>. This special value means that all attributes that are set are requested. If this value is 0 the
		/// <c>pAttributeNames</c> array can be <c>NULL</c>. No attribute will be requested.
		/// </param>
		/// <param name="phSearchResult">
		/// The address of a method-allocated handle to the search context. The caller passes this handle to other methods of
		/// IDirectorySearch to examine the search result. If <c>NULL</c>, the search cannot be executed.
		/// </param>
		/// <remarks>
		/// <para>
		/// When the search filter ( <c>pszSearchFilter</c>) contains an attribute of <c>ADS_UTC_TIME</c> type, it value must be of the
		/// "yymmddhhmmssZ" format where "y", "m", "d", "h", "m" and "s" stand for year, month, day, hour, minute, and second, respectively.
		/// In this format, for example, "10:20:00 May 13, 1999" becomes "990513102000Z". The final letter "Z" is the required syntax and
		/// indicated Zulu Time or Universal Coordinated Time.
		/// </para>
		/// <para>
		/// The caller must call IDirectorySearch::CloseSearchHandle to release the memory allocated for the search handle and the result.
		/// </para>
		/// <para>
		/// When using the special value of 0xFFFFFFFF for <c>dwNumberAttributes</c>, LDAP retrieval of ADsPath or distinguishedName has no
		/// extra resource or time cost.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following C++ code example shows how to invoke <c>IDirectorySearch::ExecuteSearch</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-idirectorysearch-executesearch HRESULT ExecuteSearch( [in] StrPtrUni
		// pszSearchFilter, [in] StrPtrUni *pAttributeNames, [in] DWORD dwNumberAttributes, [out] PADS_SEARCH_HANDLE phSearchResult );
		void ExecuteSearch([In, MarshalAs(UnmanagedType.LPWStr)] string pszSearchFilter,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 2)] string[]? pAttributeNames,
			[In, Optional] uint dwNumberAttributes, out ADS_SEARCH_HANDLE phSearchResult);

		/// <summary>
		/// The <c>IDirectorySearch::AbandonSearch</c> method abandons a search initiated by an earlier call to the ExecuteSearch method.
		/// </summary>
		/// <param name="phSearchResult">Provides a handle to the search context.</param>
		/// <remarks>
		/// <para>
		/// <c>IDirectorySearch::AbandonSearch</c> may be used if the Page_Size or Asynchronous options can be specified through
		/// IDirectorySearch::SetSearchPreference before the search is executed.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-idirectorysearch-abandonsearch HRESULT AbandonSearch( [in]
		// ADS_SEARCH_HANDLE phSearchResult );
		void AbandonSearch([In] ADS_SEARCH_HANDLE phSearchResult);

		/// <summary>
		/// The <c>GetFirstRow</c> method gets the first row of a search result. This method will issue or reissue a new search, even if this
		/// method has been called before.
		/// </summary>
		/// <param name="hSearchResult">Contains the search handle obtained by calling IDirectorySearch::ExecuteSearch.</param>
		/// <remarks>
		/// <para>
		/// When the <c>ADS_SEARCHPREF_CACHE_RESULTS</c> flag is not set, that is, <c>FALSE</c>, only forward scrolling is permitted, because
		/// the client might not cache all the query results. Calling <c>GetFirstRow</c> more than once from the same row requires some
		/// back-scrolling and could result in erroneous outcomes for a paged or an asynchronous search initiated through OLE DB when the
		/// results are not guaranteed to remain in the cache.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-idirectorysearch-getfirstrow HRESULT GetFirstRow( [in]
		// ADS_SEARCH_HANDLE hSearchResult );
		[PreserveSig]
		HRESULT GetFirstRow([In] ADS_SEARCH_HANDLE hSearchResult);

		/// <summary>The <c>GetNextRow</c> method gets the next row of the search result. If IDirectorySearch::GetFirstRow has not been called, <c>GetNextRow</c> will issue a new search beginning from the first row. Otherwise, this method will advance to the next row.</summary>
		/// <param name="hSearchResult">Contains the search handle obtained by calling IDirectorySearch::ExecuteSearch.</param>
		/// <returns>
		/// <para>This method returns the standard return values, as well as the following:</para>
		/// <para>For more information, see ADSI Error Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>When the <c>ADS_SEARCHPREF_CACHE_RESULTS</c> flag is not set, only forward scrolling is permitted, because the client might not cache all the query results.</para>
		/// <para>The directory provider may limit the maximum number of rows available in a search. For example, on a Windows domain, the maximum number of rows that will be provided in an Active Directory search is 1000 rows. If the search results in more than the row limit, a paged search must be performed to obtain all rows in the search. For more information about paged searches, see Paging with IDirectorySearch.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-idirectorysearch-getnextrow
		// HRESULT GetNextRow( [in] ADS_SEARCH_HANDLE hSearchResult );
		[PreserveSig]
		HRESULT GetNextRow([In] ADS_SEARCH_HANDLE hSearchResult);

		/// <summary>
		/// The <c>IDirectorySearch::GetPreviousRow</c> method gets the previous row of the search result. If the provider does not provide
		/// cursor support, it should return <c>E_NOTIMPL</c>.
		/// </summary>
		/// <param name="hSearchResult">Provides a handle to the search context.</param>
		/// <remarks>
		/// <para>
		/// When the <c>ADS_SEARCHPREF_CACHE_RESULTS</c> flag is not set, only forward scrolling is permitted, because the client might not
		/// cache all the query results.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-idirectorysearch-getpreviousrow HRESULT GetPreviousRow( [in]
		// ADS_SEARCH_HANDLE hSearchResult );
		[PreserveSig]
		HRESULT GetPreviousRow([In] ADS_SEARCH_HANDLE hSearchResult);

		/// <summary>
		/// The <c>IDirectorySearch::GetNextColumnName</c> method gets the name of the next column in the search result that contains data.
		/// </summary>
		/// <param name="hSearchHandle">Provides a handle to the search context.</param>
		/// <param name="ppszColumnName">
		/// Provides the address of a pointer to a method-allocated string containing the requested column name. If <c>NULL</c>, no
		/// subsequent rows contain data. The caller does NOT need to free this memory.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-idirectorysearch-getnextcolumnname HRESULT GetNextColumnName(
		// [in] ADS_SEARCH_HANDLE hSearchHandle, [out] StrPtrUni *ppszColumnName );
		[PreserveSig]
		HRESULT GetNextColumnName([In] ADS_SEARCH_HANDLE hSearchHandle, [Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(AdsUnicodeStringMarshaler))] out string? ppszColumnName);

		/// <summary>The <c>IDirectorySearch::GetColumn</c> method gets data from a named column of the search result.</summary>
		/// <param name="hSearchResult">Provides a handle to the search context.</param>
		/// <param name="szColumnName">Provides the name of the column for which data is requested.</param>
		/// <param name="pSearchColumn">
		/// Provides the address of a method-allocated ADS_SEARCH_COLUMN structure that contains the column from the current row of the
		/// search result.
		/// </param>
		/// <remarks>
		/// <para>
		/// The method allocates the memory for the ADS_SEARCH_COLUMN structure to hold the data of the column. But the caller must free the
		/// memory by calling IDirectorySearch::FreeColumn.
		/// </para>
		/// <para>
		/// The <c>IDirectorySearch::GetColumn</c> method tries to read the schema definition of the requested attribute so it can return the
		/// attribute values in the appropriate format in the ADSVALUE structures, contained in the ADS_SEARCH_COLUMN structure. However,
		/// <c>GetColumn</c> can succeed even when the schema definition is not available, in which case the <c>dwADsType</c> member of the
		/// <c>ADS_SEARCH_COLUMN</c> structure returns ADSTYPE_PROV_SPECIFIC and the value is returned in an ADS_PROV_SPECIFIC structure.
		/// When you process the results of a <c>GetColumn</c> call, you must verify <c>dwADsType</c> to ensure that the data was returned in
		/// the expected format.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-idirectorysearch-getcolumn HRESULT GetColumn( [in]
		// ADS_SEARCH_HANDLE hSearchResult, [in] StrPtrUni szColumnName, [out] PADS_SEARCH_COLUMN pSearchColumn );
		[PreserveSig]
		HRESULT GetColumn([In] ADS_SEARCH_HANDLE hSearchResult, [In, MarshalAs(UnmanagedType.LPWStr)] string szColumnName, [Out] IntPtr pSearchColumn);

		/// <summary>
		/// The <c>IDirectorySearch::FreeColumn</c> method releases memory that the IDirectorySearch::GetColumn method allocated for data for
		/// the column.
		/// </summary>
		/// <param name="pSearchColumn">Provides a pointer to the column to be freed.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-idirectorysearch-freecolumn HRESULT FreeColumn( [in]
		// PADS_SEARCH_COLUMN pSearchColumn );
		void FreeColumn(IntPtr pSearchColumn);

		/// <summary>
		/// The <c>IDirectorySearch::CloseSearchHandle</c> method closes the handle to a search result and frees the associated memory.
		/// </summary>
		/// <param name="hSearchResult">Provides a handle to the search result to be closed.</param>
		/// <remarks>
		/// <para>
		/// The process that implements the <c>IDirectorySearch::CloseSearchHandle</c> method must also be responsible for freeing all memory
		/// allocated by the IDirectorySearch::ExecuteSearch method, including the search result and the search result handle.
		/// </para>
		/// <para>
		/// The caller may call this method only once for each opened search handle and must use the IDirectorySearch::ExecuteSearch method
		/// to obtain a new search handle after issuing <c>IDirectorySearch::CloseSearchHandle</c>.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-idirectorysearch-closesearchhandle HRESULT CloseSearchHandle(
		// [in] ADS_SEARCH_HANDLE hSearchResult );
		void CloseSearchHandle([In] ADS_SEARCH_HANDLE hSearchResult);
	}

	/// <summary>
	/// The <c>IDirectorySearch::ExecuteSearch</c> method executes a search and passes the results to the caller. Some providers, such as
	/// LDAP, will defer the actual execution until the caller invokes the IDirectorySearch::GetFirstRow method or the
	/// IDirectorySearch::GetNextRow method.
	/// </summary>
	/// <param name="ids">The <see cref="IDirectorySearch"/> instance.</param>
	/// <param name="pszSearchFilter">A search filter string in LDAP format, such as "(objectClass=user)".</param>
	/// <param name="pAttributeNames">An array of attribute names for which data is requested.</param>
	/// <returns>
	/// A handle to the search context. The caller passes this handle to other methods of IDirectorySearch to examine the search result. If
	/// <see cref="SafeHANDLE.IsNull"/> is <see langword="true"/>, the search cannot be executed.
	/// </returns>
	/// <remarks>
	/// When the search filter (<paramref name="pszSearchFilter"/>) contains an attribute of <c>ADS_UTC_TIME</c> type, it value must be of
	/// the "yymmddhhmmssZ" format where "y", "m", "d", "h", "m" and "s" stand for year, month, day, hour, minute, and second, respectively.
	/// In this format, for example, "10:20:00 May 13, 1999" becomes "990513102000Z". The final letter "Z" is the required syntax and
	/// indicated Zulu Time or Universal Coordinated Time.
	/// </remarks>
	public static SafeADS_SEARCH_HANDLE ExecuteSearch(this IDirectorySearch ids, string pszSearchFilter, params string[] pAttributeNames)
	{
		uint attrCnt;
		if (pAttributeNames.Length == 1 && pAttributeNames[0] is "*" or null)
		{
			attrCnt = 0xFFFFFFFF;
			pAttributeNames = [];
		}
		else
			attrCnt = (uint)pAttributeNames.Length;
		ids.ExecuteSearch(pszSearchFilter, pAttributeNames.Length > 0 ? pAttributeNames : null, attrCnt, out var h);
		return new(ids, h);
	}

	/// <summary>
	/// Gets a list of the names of the all the columns in the search result that contains data.
	/// </summary>
	/// <param name="ids">The <see cref="IDirectorySearch"/> instance.</param>
	/// <param name="hSearchHandle">Provides a handle to the search context.</param>
	/// <returns>A list of all the names of the columns.</returns>
	public static List<string> GetColumnNames(this IDirectorySearch ids, [In] ADS_SEARCH_HANDLE hSearchHandle)
	{
		List<string> ret = [];
		string? cn = null;
		while ((cn = ids.GetNextColumnName(hSearchHandle)) is not null)
			ret.Add(cn);
		return ret;
	}

	/// <summary>
	/// The <c>IDirectorySearch::GetNextColumnName</c> method gets the name of the next column in the search result that contains data.
	/// </summary>
	/// <param name="ids">The <see cref="IDirectorySearch"/> instance.</param>
	/// <param name="hSearchHandle">Provides a handle to the search context.</param>
	/// <returns>The requested column name. If <see langword="null"/>, no subsequent rows contain data.</returns>
	public static string? GetNextColumnName(this IDirectorySearch ids, [In] ADS_SEARCH_HANDLE hSearchHandle)
	{
		try
		{
			ids.GetNextColumnName(hSearchHandle, out var s).ThrowIfFailed();
			return s;
		}
		catch { }
		return null;
	}

	/// <summary>
	/// The <c>IDirectorySearch::GetColumn</c> method gets data from a named column of the search result.
	/// </summary>
	/// <param name="ids">The <see cref="IDirectorySearch"/> instance.</param>
	/// <param name="hSearchResult">Provides a handle to the search context.</param>
	/// <param name="szColumnName">Provides the name of the column for which data is requested.</param>
	/// <returns>A ADS_SEARCH_COLUMN structure that contains the column from the current row of the search result.</returns>
	/// <remarks>
	/// The <c>IDirectorySearch::GetColumn</c> method tries to read the schema definition of the requested attribute so it can return the
	/// attribute values in the appropriate format in the ADSVALUE structures, contained in the ADS_SEARCH_COLUMN structure. However,
	/// <c>GetColumn</c> can succeed even when the schema definition is not available, in which case the <c>dwADsType</c> member of the
	/// <c>ADS_SEARCH_COLUMN</c> structure returns ADSTYPE_PROV_SPECIFIC and the value is returned in an ADS_PROV_SPECIFIC structure. When
	/// you process the results of a <c>GetColumn</c> call, you must verify <c>dwADsType</c> to ensure that the data was returned in the
	/// expected format.
	/// </remarks>
	public static ADS_SEARCH_COLUMN? GetColumn(this IDirectorySearch ids, [In] ADS_SEARCH_HANDLE hSearchResult, string szColumnName)
	{
		ADS_SEARCH_COLUMN? ret;
		unsafe
		{
			ADS_SEARCH_COLUMN.ADS_SEARCH_COLUMN_UNMGD col = new();
			ids.GetColumn(hSearchResult, szColumnName, (IntPtr)(void*)&col).ThrowIfFailed();
			ret = ((IntPtr)(void*)&col).ToNullableStructure<ADS_SEARCH_COLUMN>();
			ids.FreeColumn((IntPtr)(void*)&col);
		}
		return ret;
	}

	/// <summary>Gets the data for each column in a sequence of all rows from a search query.</summary>
	/// <param name="ids">The <see cref="IDirectorySearch"/> instance.</param>
	/// <param name="hSearchHandle">Provides a handle to the search context.</param>
	/// <returns>A seqence of row data where each item is a list of column details for all columns.</returns>
	public static IEnumerable<IReadOnlyList<ADS_SEARCH_COLUMN>> GetRowData(this IDirectorySearch ids, [In] ADS_SEARCH_HANDLE hSearchHandle)
	{
		ids.GetFirstRow(hSearchHandle).ThrowIfFailed();
		var cols = ids.GetColumnNames(hSearchHandle);
		while (ids.GetNextRow(hSearchHandle) != HRESULT.S_ADS_NOMORE_ROWS)
		{
			var row = new List<ADS_SEARCH_COLUMN>();
			foreach (var cn in cols)
				row.Add(ids.GetColumn(hSearchHandle, cn).GetValueOrDefault());
			yield return row;
		}
	}

	/// <summary>Provides a handle to an ADs Search session.</summary>
	[AutoHandle]
	public partial struct ADS_SEARCH_HANDLE { }

	/// <summary>
	/// Provides a <see cref="SafeHandle"/> for <see cref="ADS_SEARCH_HANDLE"/> that is disposed using <see cref="IDirectorySearch.CloseSearchHandle"/>.
	/// </summary>
	public class SafeADS_SEARCH_HANDLE : SafeHANDLE
	{
		private readonly IDirectorySearch? ids;

		/// <summary>Initializes a new instance of the <see cref="SafeADS_SEARCH_HANDLE"/> class.</summary>
		internal SafeADS_SEARCH_HANDLE(IDirectorySearch? ids = null, ADS_SEARCH_HANDLE h = default) : base((IntPtr)h, true) => this.ids = ids;

		/// <summary>Performs an implicit conversion from <see cref="SafeADS_SEARCH_HANDLE"/> to <see cref="ADS_SEARCH_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ADS_SEARCH_HANDLE(SafeADS_SEARCH_HANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { try { ids?.CloseSearchHandle(handle); return true; } catch { return false; } }
	}

	/// <summary>CLSID_AccessControlEntry</summary>
	[ComImport, Guid("B75AC000-9BDD-11D0-852C-00C04FD8D503"), ClassInterface(ClassInterfaceType.None)]
	public class AccessControlEntry
	{ }

	/// <summary>CLSID_AccessControlList</summary>
	[ComImport, Guid("B85EA052-9BDD-11D0-852C-00C04FD8D503"), ClassInterface(ClassInterfaceType.None)]
	public class AccessControlList
	{ }

	/// <summary>CLSID_ADsSecurityUtility</summary>
	[ComImport, Guid("F270C64A-FFB8-4AE4-85FE-3A75E5347966"), ClassInterface(ClassInterfaceType.None)]
	public class ADsSecurityUtility
	{ }

	/// <summary>CLSID_ADSystemInfo</summary>
	[ComImport, Guid("50B6327F-AFD1-11D2-9CB9-0000F87A369E"), ClassInterface(ClassInterfaceType.None)]
	public class ADSystemInfo
	{ }

	/// <summary>CLSID_BackLink</summary>
	[ComImport, Guid("FCBF906F-4080-11D1-A3AC-00C04FB950DC"), ClassInterface(ClassInterfaceType.None)]
	public class BackLink
	{ }

	/// <summary>CLSID_CaseIgnoreList</summary>
	[ComImport, Guid("15F88A55-4680-11D1-A3B4-00C04FB950DC"), ClassInterface(ClassInterfaceType.None)]
	public class CaseIgnoreList
	{ }

	/// <summary>CLSID_DNWithBinary</summary>
	[ComImport, Guid("7E99C0A3-F935-11D2-BA96-00C04FB6D0D1"), ClassInterface(ClassInterfaceType.None)]
	public class DNWithBinary
	{ }

	/// <summary>CLSID_DNWithString</summary>
	[ComImport, Guid("334857CC-F934-11D2-BA96-00C04FB6D0D1"), ClassInterface(ClassInterfaceType.None)]
	public class DNWithString
	{ }

	/// <summary>CLSID_Email</summary>
	[ComImport, Guid("8F92A857-478E-11D1-A3B4-00C04FB950DC"), ClassInterface(ClassInterfaceType.None)]
	public class Email
	{ }

	/// <summary>CLSID_FaxNumber</summary>
	[ComImport, Guid("A5062215-4681-11D1-A3B4-00C04FB950DC"), ClassInterface(ClassInterfaceType.None)]
	public class FaxNumber
	{ }

	/// <summary>CLSID_Hold</summary>
	[ComImport, Guid("B3AD3E13-4080-11D1-A3AC-00C04FB950DC"), ClassInterface(ClassInterfaceType.None)]
	public class Hold
	{ }

	/// <summary>CLSID_LargeInteger</summary>
	[ComImport, Guid("927971F5-0939-11D1-8BE1-00C04FD8D503"), ClassInterface(ClassInterfaceType.None)]
	public class LargeInteger
	{ }

	/// <summary>CLSID_NameTranslate</summary>
	[ComImport, Guid("274FAE1F-3626-11D1-A3A4-00C04FB950DC"), ClassInterface(ClassInterfaceType.None)]
	public class NameTranslate
	{ }

	/// <summary>CLSID_NetAddress</summary>
	[ComImport, Guid("B0B71247-4080-11D1-A3AC-00C04FB950DC"), ClassInterface(ClassInterfaceType.None)]
	public class NetAddress
	{ }

	/// <summary>CLSID_OctetList</summary>
	[ComImport, Guid("1241400F-4680-11D1-A3B4-00C04FB950DC"), ClassInterface(ClassInterfaceType.None)]
	public class OctetList
	{ }

	/// <summary>CLSID_Path</summary>
	[ComImport, Guid("B2538919-4080-11D1-A3AC-00C04FB950DC"), ClassInterface(ClassInterfaceType.None)]
	public class Path
	{ }

	/// <summary>CLSID_Pathname</summary>
	[ComImport, Guid("080D0D78-F421-11D0-A36E-00C04FB950DC"), ClassInterface(ClassInterfaceType.None)]
	public class Pathname
	{ }

	/// <summary>CLSID_PostalAddress</summary>
	[ComImport, Guid("0A75AFCD-4680-11D1-A3B4-00C04FB950DC"), ClassInterface(ClassInterfaceType.None)]
	public class PostalAddress
	{ }

	/// <summary>CLSID_PropertyEntry</summary>
	[ComImport, Guid("72D3EDC2-A4C4-11D0-8533-00C04FD8D503"), ClassInterface(ClassInterfaceType.None)]
	public class PropertyEntry
	{ }

	/// <summary>CLSID_PropertyValue</summary>
	[ComImport, Guid("7B9E38B0-A97C-11D0-8534-00C04FD8D503"), ClassInterface(ClassInterfaceType.None)]
	public class PropertyValue
	{ }

	/// <summary>CLSID_ReplicaPointer</summary>
	[ComImport, Guid("F5D1BADF-4080-11D1-A3AC-00C04FB950DC"), ClassInterface(ClassInterfaceType.None)]
	public class ReplicaPointer
	{ }

	/// <summary>CLSID_SecurityDescriptor</summary>
	[ComImport, Guid("B958F73C-9BDD-11D0-852C-00C04FD8D503"), ClassInterface(ClassInterfaceType.None)]
	public class SecurityDescriptor
	{ }

	/// <summary>CLSID_Timestamp</summary>
	[ComImport, Guid("B2BED2EB-4080-11D1-A3AC-00C04FB950DC"), ClassInterface(ClassInterfaceType.None)]
	public class Timestamp
	{ }

	/// <summary>CLSID_TypedName</summary>
	[ComImport, Guid("B33143CB-4080-11D1-A3AC-00C04FB950DC"), ClassInterface(ClassInterfaceType.None)]
	public class TypedName
	{ }

	/// <summary>CLSID_WinNTSystemInfo</summary>
	[ComImport, Guid("66182EC4-AFD1-11D2-9CB9-0000F87A369E"), ClassInterface(ClassInterfaceType.None)]
	public class WinNTSystemInfo
	{ }
}