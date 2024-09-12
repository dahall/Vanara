using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Vanara.Extensions.Reflection;
using static System.Net.Mime.MediaTypeNames;
using static Vanara.PInvoke.OleAut32;

namespace Vanara.PInvoke;

public static partial class ActiveDS
{
	/// <summary>
	/// <para>
	/// The <c>IADs</c> interface defines the basic object features, that is, properties and methods, of any ADSI object. Examples of ADSI
	/// objects include users, computers, services, organization of user accounts and computers, file systems, and file service operations.
	/// Every ADSI object must support this interface, which serves to do the following:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>Provides object identification by name, class, or ADsPath</description>
	/// </item>
	/// <item>
	/// <description>Identifies the object's container that manages the object's creation and deletion</description>
	/// </item>
	/// <item>
	/// <description>Retrieves the object's schema definition</description>
	/// </item>
	/// <item>
	/// <description>Loads object's attributes to the property cache and commits changes to the persistent directory store</description>
	/// </item>
	/// <item>
	/// <description>Accesses and modifies the object's attribute values in the property cache</description>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>IADs</c> interface is designed to ensure that ADSI objects provide network administrators and directory service providers with
	/// a simple and consistent representation of various underlying directory services.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iads
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADs")]
	[ComImport, Guid("FD8256D0-FD15-11CE-ABC4-02608C9E7553"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IADs
	{
		/// <summary>
		/// The relative name of the object as named within the underlying directory service. This name distinguishes this object from its siblings.
		/// </summary>
		/// <value>The relative name of the object as named within the underlying directory service.</value>
		[DispId(2)]
		string Name
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The name of the object Schema class.</summary>
		/// <value>The name of the object Schema class.</value>
		[DispId(3)]
		string Class
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
		///<![CDATA[///Dim x As IADs
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
		string GUID
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
		string ADsPath
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
		string Parent
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The ADsPath string of the Schema class object of this object.</summary>
		/// <value>The ADsPath string of the Schema class object of this object.</value>
		[DispId(7)]
		string Schema
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
		void GetInfo();

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
		void SetInfo();

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
		object? Get([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

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
		void Put([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vProp);

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
		/// <description><code language="vb"><![CDATA[Dim x as IADs
		///  
		/// otherNumbers = x.Get("otherHomePhone")
		/// If VarType(otherNumbers) = vbString Then
		///   Debug.Print otherNumbers
		/// Else
		///   For Each homeNum In otherNumbers
		/// 
		/// 	Debug.Print homeNum
		///   Next
		/// End If]]></code></description>
		/// <description><code language="vb"><![CDATA[Dim x as IADs
		///  
		/// otherNumbers = x.GetEx("otherHomePhone")
		/// For Each homeNum In otherNumbers
		///   Debug.Print homeNum
		/// Next]]></code></description>
		/// </item>
		/// </list>
		/// <para>
		/// Like the IADs::Get method, <c>IADs::GetEx</c> implicitly calls IADs::GetInfo against an uninitialized property cache. For more
		/// information about implicit and explicit calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use <c>IADs::GetEx</c> to retrieve object properties.</para>
		/// <code language="vb"><![CDATA[Dim x As IADs
		/// On Error GoTo ErrTest:
		///  
		/// Set x = GetObject("LDAP://CN=Administrator,CN=Users,DC=Fabrikam,DC=com")
		///  
		/// ' Single value property.
		/// Debug.Print "Home Phone Number is: " 
		/// phoneNumber = x.GetEx(""homePhone")
		/// For Each homeNum in phoneNumber
		///     Debug.Print homeNum
		/// Next
		///  
		/// ' Multiple value property.
		/// Debug.Print "Other Phone Numbers are: "
		/// otherNumbers = x.GetEx("otherHomePhone")
		/// For Each homeNum In otherNumbers
		///     Debug.Print homeNum
		/// Next
		/// Exit Sub
		///  
		/// ErrTest:
		///     Debug.Print Hex(Err.Number)
		///     Set x = Nothing]]></code>
		/// <para>The following code example shows how to retrieve values of the optional properties of an object using the IADs::Get method.</para>
		/// <code language="vb"><![CDATA[Dim x 
		///
		/// On Error Resume Next
		/// Set x = GetObject("WinNT://Fabrikam/Administrator")
		/// Response.Write "Object Name: " & x.Name & "<br>"
		/// Response.Write "Object Class: " & x.Class & "<br>"
		///  
		/// ' Get the optional property values for this object.
		/// Set cls = GetObject(x.Schema)
		/// For Each op In cls.OptionalProperties
		///    vals = obj.GetEx(op)
		///    if err.Number = 0 then
		///        Response.Write "Optional Property: & op & "=" 
		///        for each v in vals 
		///           Response.Write v & " "
		///        next
		///        Response.Write "<br>"
		///    end if
		/// Next]]></code>
		/// <para>The following code example retrieves the "homePhone" property values using <c>IADs::GetEx</c>.</para>
		/// <code language="vb"><![CDATA[IADs *pADs = NULL;
		/// 
		/// hr = ADsGetObject(L"LDAP://CN=Administrator,CN=Users,DC=Fabrikam,DC=Com", IID_IADs, (void**) &pADs );
		/// if ( !SUCCEEDED(hr) ) { return hr;}
		///  
		/// hr = pADs->GetEx(CComBSTR("homePhone"), &var);
		/// if ( SUCCEEDED(hr) )
		/// {
		///     LONG lstart, lend;
		///     SAFEARRAY *sa = V_ARRAY( &var );
		///     VARIANT varItem;
		///  
		///     // Get the lower and upper bound.
		///     hr = SafeArrayGetLBound( sa, 1, &lstart );
		///     hr = SafeArrayGetUBound( sa, 1, &lend );
		///  
		///     // Iterate and print the content.
		///     VariantInit(&varItem);
		///     printf("Getting Home Phone using IADs::Get.\n");
		///     for ( long idx=lstart; idx <= lend; idx++ )
		///     {
		///         hr = SafeArrayGetElement( sa, &idx, &varItem );
		///         printf("%S ", V_BSTR(&varItem));
		///         VariantClear(&varItem);
		///     }
		///     printf("\n");
		///  
		///     VariantClear(&var);
		/// }
		///  
		/// // Cleanup.
		/// if ( pADs )
		/// {
		///     pADs->Release();
		/// }]]></code>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iads-getex HRESULT GetEx( [in] BSTR bstrName, [out] VARIANT
		// *pvProp );
		[DispId(12)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object? GetEx([In, MarshalAs(UnmanagedType.BStr)] string bstrName);

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
		void PutEx([In] ADS_PROPERTY_OPERATION lnControlCode, [In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, Optional, MarshalAs(UnmanagedType.Struct)] object? vProp);

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
		void GetInfoEx([In, MarshalAs(UnmanagedType.Struct)] object vProperties, [In] int lnReserved = 0);
	}

	/// <summary>
	/// The <c>IADs::Get</c> method retrieves a property of a given name from the property cache. The property can be single-valued, or
	/// multi-valued. The property value is represented as either a variant for a single-valued property or a variant array (of
	/// <c>VARIANT</c> or bytes) for a property that allows multiple values.
	/// </summary>
	/// <typeparam name="T">The type of the value to retrieve.</typeparam>
	/// <param name="o">The <see cref="IADs"/> instance.</param>
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
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T? Get<T>(this IADs o, string bstrName) => (T?)o.Get(bstrName);

	/// <summary>
	/// The <c>IADs::GetEx</c> method retrieves, from the property cache, property values of a given attribute. The returned property values
	/// can be single-valued or multi-valued. Unlike the IADs::Get method, the property values are returned as a variant array of
	/// <c>VARIANT</c>, or a variant array of bytes for binary data. A single-valued property is then represented as an array of a single element.
	/// </summary>
	/// <typeparam name="T">The type of the value to retrieve.</typeparam>
	/// <param name="o">The <see cref="IADs"/> instance.</param>
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
	/// <description><code language="vb"><![CDATA[Dim x as IADs
	///  
	/// otherNumbers = x.Get("otherHomePhone")
	/// If VarType(otherNumbers) = vbString Then
	///   Debug.Print otherNumbers
	/// Else
	///   For Each homeNum In otherNumbers
	/// 
	/// 	Debug.Print homeNum
	///   Next
	/// End If]]></code></description>
	/// <description><code language="vb"><![CDATA[Dim x as IADs
	///  
	/// otherNumbers = x.GetEx("otherHomePhone")
	/// For Each homeNum In otherNumbers
	///   Debug.Print homeNum
	/// Next]]></code></description>
	/// </item>
	/// </list>
	/// <para>
	/// Like the IADs::Get method, <c>IADs::GetEx</c> implicitly calls IADs::GetInfo against an uninitialized property cache. For more
	/// information about implicit and explicit calls to <c>IADs::GetInfo</c>, see <c>IADs::GetInfo</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code example shows how to use <c>IADs::GetEx</c> to retrieve object properties.</para>
	/// <code language="vb"><![CDATA[Dim x As IADs
	/// On Error GoTo ErrTest:
	///  
	/// Set x = GetObject("LDAP://CN=Administrator,CN=Users,DC=Fabrikam,DC=com")
	///  
	/// ' Single value property.
	/// Debug.Print "Home Phone Number is: " 
	/// phoneNumber = x.GetEx(""homePhone")
	/// For Each homeNum in phoneNumber
	///     Debug.Print homeNum
	/// Next
	///  
	/// ' Multiple value property.
	/// Debug.Print "Other Phone Numbers are: "
	/// otherNumbers = x.GetEx("otherHomePhone")
	/// For Each homeNum In otherNumbers
	///     Debug.Print homeNum
	/// Next
	/// Exit Sub
	///  
	/// ErrTest:
	///     Debug.Print Hex(Err.Number)
	///     Set x = Nothing]]></code>
	/// <para>The following code example shows how to retrieve values of the optional properties of an object using the IADs::Get method.</para>
	/// <code language="vb"><![CDATA[Dim x 
	///
	/// On Error Resume Next
	/// Set x = GetObject("WinNT://Fabrikam/Administrator")
	/// Response.Write "Object Name: " & x.Name & "<br>"
	/// Response.Write "Object Class: " & x.Class & "<br>"
	///  
	/// ' Get the optional property values for this object.
	/// Set cls = GetObject(x.Schema)
	/// For Each op In cls.OptionalProperties
	///    vals = obj.GetEx(op)
	///    if err.Number = 0 then
	///        Response.Write "Optional Property: & op & "=" 
	///        for each v in vals 
	///           Response.Write v & " "
	///        next
	///        Response.Write "<br>"
	///    end if
	/// Next]]></code>
	/// <para>The following code example retrieves the "homePhone" property values using <c>IADs::GetEx</c>.</para>
	/// <code language="vb"><![CDATA[IADs *pADs = NULL;
	/// 
	/// hr = ADsGetObject(L"LDAP://CN=Administrator,CN=Users,DC=Fabrikam,DC=Com", IID_IADs, (void**) &pADs );
	/// if ( !SUCCEEDED(hr) ) { return hr;}
	///  
	/// hr = pADs->GetEx(CComBSTR("homePhone"), &var);
	/// if ( SUCCEEDED(hr) )
	/// {
	///     LONG lstart, lend;
	///     SAFEARRAY *sa = V_ARRAY( &var );
	///     VARIANT varItem;
	///  
	///     // Get the lower and upper bound.
	///     hr = SafeArrayGetLBound( sa, 1, &lstart );
	///     hr = SafeArrayGetUBound( sa, 1, &lend );
	///  
	///     // Iterate and print the content.
	///     VariantInit(&varItem);
	///     printf("Getting Home Phone using IADs::Get.\n");
	///     for ( long idx=lstart; idx <= lend; idx++ )
	///     {
	///         hr = SafeArrayGetElement( sa, &idx, &varItem );
	///         printf("%S ", V_BSTR(&varItem));
	///         VariantClear(&varItem);
	///     }
	///     printf("\n");
	///  
	///     VariantClear(&var);
	/// }
	///  
	/// // Cleanup.
	/// if ( pADs )
	/// {
	///     pADs->Release();
	/// }]]></code>
	/// </remarks>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T? GetEx<T>(this IADs o, string bstrName) => (T?)o.GetEx(bstrName);

	/// <summary>
	/// The <c>IADs::GetInfoEx</c> method loads the values of specified properties of the ADSI object from the underlying directory store
	/// into the property cache.
	/// </summary>
	/// <param name="o">The <see cref="IADs"/> instance.</param>
	/// <param name="vProperties">
	/// Array of null-terminated Unicode string entries that list the properties to load into the Active Directory property cache. Each
	/// property name must match one in this object's schema class definition.
	/// </param>
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
	public static void GetInfoEx(this IADs o, params string[] vProperties)
	{
		if (vProperties is null || vProperties.Length < 1)
			o.GetInfo();
		else
			o.GetInfoEx(vProperties, 0);
	}

	/// <summary>
	/// <para>
	/// The <c>IADsAccessControlEntry</c> interface is a dual interface that enables directory clients to access and manipulate individual
	/// access-control entries (ACEs) of the owning object. An ACE stipulates who can access the object and what type of access granted and
	/// specifies whether the access control settings can be propagated from the object to any of its children. An ACE exposes a set of
	/// properties through this interface to provide such services.
	/// </para>
	/// <para>
	/// An object can have a number of ACEs, one for each client or a group of clients. ACEs are maintained in an access-control list (ACL)
	/// which implements the IADsAccessControlList interface. That is, a client must use an ACL to access an ACE. To access the ACL, retrieve
	/// the security descriptor of the object that implements the IADsSecurityDescriptor interface. The following procedures describe how to
	/// manage access controls over an ADSI object.
	/// </para>
	/// <para>
	/// Some of the <c>IADsAccessControlEntry</c> property values, such as AccessMask and <c>AceFlags</c>, will be different for different
	/// object types. For example, an Active Directory object will use the <c>ADS_RIGHT_GENERIC_READ</c> member of the ADS_RIGHTS_ENUM
	/// enumeration for the <c>IADsAccessControlEntry.AccessMask</c> property, but the equivalent access right for a file object is
	/// <c>FILE_GENERIC_READ</c>. It is not safe to assume that all property values will be the same for Active Directory objects and
	/// non-Active Directory objects. For more information, see Security Descriptors on Files and Registry Keys.
	/// </para>
	/// <para><c>To managing access controls over an ADSI object</c></para>
	/// <list type="number">
	/// <item>
	/// <description>Retrieve the security descriptor for the object that implements the IADsSecurityDescriptor interface.</description>
	/// </item>
	/// <item>
	/// <description>Retrieve the ACL from the security descriptor.</description>
	/// </item>
	/// <item>
	/// <description>Work with the ACE, or ACEs, of the object in the ACL.</description>
	/// </item>
	/// </list>
	/// <para><c>To set a new or modified ACE as persistent</c></para>
	/// <list type="number">
	/// <item>
	/// <description>Add the ACE to the ACL.</description>
	/// </item>
	/// <item>
	/// <description>Assign the ACL to the security descriptor.</description>
	/// </item>
	/// <item>
	/// <description>Commit the security descriptor to the directory store.</description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsaccesscontrolentry
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsAccessControlEntry")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("B4F3A14C-9BDD-11D0-852C-00C04FD8D503"), CoClass(typeof(AccessControlEntry))]
	public interface IADsAccessControlEntry
	{
		/// <summary>
		/// <para>
		/// Contains a set of flags that specifies access privileges for the object. Valid values for Active Directory objects are defined in
		/// the ADS_RIGHTS_ENUM enumeration.
		/// </para>
		/// <para>For more information and a list of possible values for file or file share objects, see File Security and Access Rights.</para>
		/// <para>For more information and a list of possible values for registry objects, see Registry Key Security and Access Rights.</para>
		/// <para>Access type: Read/write</para>
		/// </summary>
		[DispId(2)]
		int AccessMask
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// Contains a value that indicates the type of ACE. Valid values for Active Directory objects are defined in the ADS_ACETYPE_ENUM enumeration.
		/// </para>
		/// <para>
		/// For more information and possible values for file, file share, and registry objects, see the AceType member of the ACE_HEADER structure.
		/// </para>
		/// <para>Access type: Read/write</para>
		/// </summary>
		[DispId(3)]
		AdvApi32.ACE_TYPE AceType
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// Contains a set of flags that specifies if other containers or objects can inherit the ACE. Valid values for Active Directory
		/// object are defined in the ADS_ACEFLAG_ENUM enumeration.
		/// </para>
		/// <para>
		/// For more information and possible values for file, file share, and registry objects, see the AceFlags member of the ACE_HEADER structure.
		/// </para>
		/// <para>Access type: Read/write</para>
		/// </summary>
		[DispId(4)]
		AdvApi32.ACE_FLAG AceFlags
		{
			[DispId(4)]
			get;
			[DispId(4)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// A flag that indicates if the ACE has an object type or inherited object type. Valid flags are defined in the ADS_FLAGTYPE_ENUM enumeration.
		/// </para>
		/// <para>Access type: Read/write</para>
		/// </summary>
		[DispId(5)]
		ADS_FLAGTYPE Flags
		{
			[DispId(5)]
			get;
			[DispId(5)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// A flag that indicates the ADSI object type. Its value is a GUID to a property or an object in string format. The GUID refers to a
		/// property when ADS_RIGHT_DS_READ_PROP and ADS_RIGHT_DS_WRITE_PROP access masks are used. The GUID specifies an object when
		/// ADS_RIGHT_DS_CREATE_CHILD and ADS_RIGHT_DS_DELETE_CHILD access masks are used.
		/// </para>
		/// <para>Access type: Read/write</para>
		/// </summary>
		[DispId(6)]
		string ObjectType
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(6)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// A flag that indicates the type of a child object of an ADSI object. Its value is a GUID to an object in string format. When such
		/// a GUID is set, the ACE applies only to the object referred to by the GUID.
		/// </para>
		/// <para>Access type: Read/write</para>
		/// </summary>
		[DispId(7)]
		string? InheritedObjectType
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(7)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>Contains the name of the account that the ACE applies to.</para>
		/// <para>Access type: Read/write</para>
		/// </summary>
		[DispId(8)]
		string Trustee
		{
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(8)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}
	}

	/// <summary>The <c>IADsAccessControlList</c> interface is a dual interface that manages individual access-control entries (ACEs).</summary>
	/// <remarks>
	/// <para>
	/// An access-control list (ACL) is a collection of ACEs that can provide more specific access control to the same ADSI object for
	/// different clients. In general, different providers implement different access controls and therefore the behavior of the object is
	/// specific to the provider. For more information, see the provider documentation. For more information about Microsoft providers, see
	/// ADSI System Providers. Currently, only the LDAP provider supports access controls.
	/// </para>
	/// <para>
	/// Before you can work with an object ACE, first obtain the ACL to which they belong. ACLs are managed by security descriptors and can
	/// be of either discretionary ACL and system ACL. For more information, see IADsSecurityDescriptor.
	/// </para>
	/// <para>
	/// Using the properties and methods of the <c>IADsAccessControlList</c> interface, you can retrieve and enumerate ACEs, add new entries
	/// to the list, or remove existing entries.
	/// </para>
	/// <para><c>To manage access controls over an ADSI</c></para>
	/// <list type="number">
	/// <item>
	/// <description>First, retrieve the security descriptor of the object that implements the IADsSecurityDescriptor interface.</description>
	/// </item>
	/// <item>
	/// <description>Second, retrieve the ACL from the security descriptor.</description>
	/// </item>
	/// <item>
	/// <description>Third, work with the ACE, or ACEs, of the object in the ACL.</description>
	/// </item>
	/// </list>
	/// <para><c>To make any new or modified ACEs persistent</c></para>
	/// <list type="number">
	/// <item>
	/// <description>First, add the ACE to the ACL.</description>
	/// </item>
	/// <item>
	/// <description>Second, assign the ACL to the security descriptor.</description>
	/// </item>
	/// <item>
	/// <description>Third, commit the security descriptor to the directory store.</description>
	/// </item>
	/// </list>
	/// <para>For more information about DACLs, see Null DACLs and Empty DACLs.</para>
	/// <para>Examples</para>
	/// <para>The following code example shows how to work with access control entries of a discretionary ACL.</para>
	/// <para>The following code example enumerates ACEs from a DACL.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsaccesscontrollist
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsAccessControlList")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("B7EE91CC-9BDD-11D0-852C-00C04FD8D503"), CoClass(typeof(AccessControlList))]
	public interface IADsAccessControlList : IEnumerable
	{
		/// <summary>
		/// <para>
		/// The revision level of an access-control list. This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS if the ACL
		/// contains an object-specific ACE. All ACEs in an ACL must be at the same revision level.
		/// </para>
		/// <para>Access type: Read/write</para>
		/// </summary>
		[DispId(3)]
		int AclRevision
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>The number of access control entries in the access-control list.</para>
		/// <para>Access type: Read/write</para>
		/// </summary>
		[DispId(4)]
		int AceCount
		{
			[DispId(4)]
			get;
			[DispId(4)]
			[param: In]
			set;
		}

		/// <summary>
		/// The <c>IADsAccessControlList::AddAce</c> method adds an IADsAccessControlEntry object to the IADsAccessControlList object.
		/// </summary>
		/// <param name="pAccessControlEntry">
		/// Pointer to the IDispatch interface of the IADsAccessControlEntry object to be added. This parameter cannot be <c>NULL</c>.
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
		/// <para>This method adds the ACE to the front of the ACL, which does not necessarily result in correct ordering.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following Visual Basic code example shows how to use the <c>IADsAccessControlList::AddAce</c> method to add two ACEs to an ACL.
		/// </para>
		/// <para>
		/// The following C++ code example adds an ACE to an ACL using the <c>IADsAccessControlList::AddAce</c> method. The added ACE has
		/// allowed access rights with the full permission.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsaccesscontrollist-addace HRESULT AddAce( [in] IDispatch
		// *pAccessControlEntry );
		[DispId(5)]
		void AddAce([In, MarshalAs(UnmanagedType.IDispatch)] IADsAccessControlEntry pAccessControlEntry);

		/// <summary>
		/// The <c>IADsAccessControlList::RemoveAce</c> method removes an access-control entry (ACE) from the access-control list (ACL).
		/// </summary>
		/// <param name="pAccessControlEntry">Pointer to the <c>IDispatch</c> interface of the ACE to be removed from the ACL.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsaccesscontrollist-removeace HRESULT RemoveAce( [in] IDispatch
		// *pAccessControlEntry );
		[DispId(6)]
		void RemoveAce([In, MarshalAs(UnmanagedType.IDispatch)] IADsAccessControlEntry pAccessControlEntry);

		/// <summary>
		/// The <c>IADsAccessControlList::CopyAccessList</c> method copies every access control entry (ACE) in the access-control list (ACL)
		/// to the caller's process space.
		/// </summary>
		/// <returns>
		/// Address of an IDispatch interface pointer to an ACL as the copy of the original access list. If this parameter is <c>NULL</c> on
		/// return, no copies of the ACL could be made.
		/// </returns>
		/// <remarks>
		/// <para>The caller must call <c>Release</c> on the copy of ACEs through their IDispatch pointers.</para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to copy an ACL from one ADSI object to another.</para>
		/// <para>The following code example copies the ACL from the source object to the target object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsaccesscontrollist-copyaccesslist HRESULT CopyAccessList(
		// [out] IDispatch **ppAccessControlList );
		[DispId(7)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		IADsAccessControlList? CopyAccessList();

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();
	}

	/// <summary>
	/// The <c>IADsAcl</c> interface provides methods for an ADSI client to access and manipulate the <c>ACL</c> or <c>Inherited ACL</c>
	/// attribute values. This interface manipulates the attributes.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsacl
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsAcl")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("8452D3AB-0869-11D1-A377-00C04FB950DC")]
	public interface IADsAcl
	{
		/// <summary>Gets or sets the name of the protected attribute.</summary>
		/// <value>The name of the protected attribute.</value>
		[DispId(2)]
		string ProtectedAttrName
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(2)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the name of the subject.</summary>
		/// <value>The name of the subject.</value>
		[DispId(3)]
		string SubjectName
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(3)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the privilege settings.</summary>
		[DispId(4)]
		int Privileges
		{
			[DispId(4)]
			get;
			[DispId(4)]
			[param: In]
			set;
		}

		/// <summary>The <c>IADsAcl::CopyAcl</c> method makes a copy of the existing ACL.</summary>
		/// <returns>Pointer to the newly created copy of the existing ACL.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsacl-copyacl HRESULT CopyAcl( IDispatch **ppAcl );
		[DispId(5)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		IADsAcl CopyAcl();
	}

	/// <summary>
	/// <para>
	/// The <c>IADsADSystemInfo</c> interface retrieves data about the local computer if it is running a Windows operating system in a
	/// Windows domain. For example, you can get the domain, site, and distinguished name of the local computer.
	/// </para>
	/// <para>
	/// The <c>IADsADSystemInfo</c> interface is implemented on the <c>ADSystemInfo</c> object residing in adsldp.dll, which is included with
	/// the standard installation of ADSI on Windows 2000. You must explicitly create an instance of the <c>ADSystemInfo</c> object in order
	/// to call the methods on the <c>IADsADSystemInfo</c> interface. This requirement amounts to creating an <c>ADSystemInfo</c> instance
	/// with the CoCreateInstance function in C/C++.
	/// </para>
	/// <para>You can also use the <c>New</c> operator in Visual Basic.</para>
	/// <para>Or you can call the <c>CreateObject</c> function in a scripting environment, supplying "ADSystemInfo" as the ProgID.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsadsysteminfo
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsADSystemInfo")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("5BB11929-AFD1-11D2-9CB9-0000F87A369E"), CoClass(typeof(ADSystemInfo))]
	public interface IADsADSystemInfo
	{
		/// <summary>
		/// Gets the Active Directory distinguished name of the current user, which is the logged-on user or the user impersonated by the
		/// calling thread.
		/// </summary>
		/// <value>
		/// The Active Directory distinguished name of the current user, which is the logged-on user or the user impersonated by the calling thread.
		/// </value>
		[DispId(2)]
		string UserName
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the distinguished name of the local computer.</summary>
		/// <value>The distinguished name of the local computer.</value>
		[DispId(3)]
		string ComputerName
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the site name of the local computer.</summary>
		/// <value>The site name of the local computer.</value>
		[DispId(4)]
		string SiteName
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the short name of the local computer's domain, such as "domainName".</summary>
		/// <value>The short name of the local computer's domain, such as "domainName".</value>
		[DispId(5)]
		string DomainShortName
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the DNS name of the local computer's domain, such as "domainName.companyName.com".</summary>
		/// <value>The DNS name of the local computer's domain, such as "domainName.companyName.com".</value>
		[DispId(6)]
		string DomainDNSName
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the DNS name of the local computer's forest.</summary>
		/// <value>The DNS name of the local computer's forest.</value>
		[DispId(7)]
		string ForestDNSName
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// Gets the distinguished name of the directory service agent (DSA) object for the DC that owns the primary domain controller role
		/// in the local computer's domain.
		/// </summary>
		/// <value>
		/// The distinguished name of the directory service agent (DSA) object for the DC that owns the primary domain controller role in the
		/// local computer's domain.
		/// </value>
		[DispId(8)]
		string PDCRoleOwner
		{
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// Gets the distinguished name of the directory service agent (DSA) object for the DC that owns the schema master role in the local
		/// computer's forest.
		/// </summary>
		/// <value>
		/// The distinguished name of the directory service agent (DSA) object for the DC that owns the schema master role in the local
		/// computer's forest.
		/// </value>
		[DispId(9)]
		string SchemaRoleOwner
		{
			[DispId(9)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Determines whether the local computer's domain is in native or mixed mode.</summary>
		/// <value><see langword="true"/> if this instance is native mode; otherwise, <see langword="false"/>.</value>
		[DispId(10)]
		bool IsNativeMode
		{
			[DispId(10)]
			get;
		}

		/// <summary>
		/// The <c>IADsADSystemInfo::GetAnyDCName</c> method retrieves the DNS name of a domain controller in the local computer's domain.
		/// </summary>
		/// <returns>Name of a domain controller, such as "ADServer1.domain1.Fabrikam.com".</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsadsysteminfo-getanydcname HRESULT GetAnyDCName( [out] BSTR
		// *pszDCName );
		[DispId(11)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetAnyDCName();

		/// <summary>
		/// The <c>IADsADSystemInfo::GetDCSiteName</c> method retrieves the name of the Active Directory site that contains the local computer.
		/// </summary>
		/// <param name="szServer">Name of the Active Directory site.</param>
		/// <returns>DNS name of the service server.</returns>
		/// <remarks>
		/// <para>
		/// An Active Directory site is one or more well-connected TCP/IP subnets holding Active Directory domain controllers. For more
		/// information, see Active Directory Core Concepts.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following C++ code example retrieves the Active Directory site name. For brevity, error checking is omitted.</para>
		/// <para>The following Visual Basic code example retrieves the name of the Active Directory domain controller site.</para>
		/// <para>The following VBScript/ASP code example retrieves the name of the Active Directory domain controller site.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsadsysteminfo-getdcsitename HRESULT GetDCSiteName( [out] BSTR
		// szServer, [in] BSTR *pszSiteName );
		[DispId(12)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetDCSiteName([In, MarshalAs(UnmanagedType.BStr)] string szServer);

		/// <summary>The <c>IADsADSystemInfo::RefreshSchemaCache</c> method refreshes the Active Directory schema cache.</summary>
		/// <remarks>
		/// When you call this method, it does a Put() of the <c>schemaUpdateNow</c> function on the RootDSE. Normally, when you make changes
		/// to the schema, they are not updated to the RootDSE until the next automatic update. This method does an immediate update to the
		/// schema so that you can view the changes to the schema.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsadsysteminfo-refreshschemacache HRESULT RefreshSchemaCache();
		[DispId(13)]
		void RefreshSchemaCache();

		/// <summary>
		/// The <c>IADsADSystemInfo::GetTrees</c> method retrieves the DNS names of all the directory trees in the local computer's forest.
		/// </summary>
		/// <returns>A Variant array of strings that contains the names of the directory trees within the forest.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsadsysteminfo-gettrees HRESULT GetTrees( [out] VARIANT
		// *pvTrees );
		[DispId(14)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetTrees();
	}

	/// <summary>
	/// The <c>IADsBackLink</c> interface provides methods for an ADSI client to access the <c>Back Link</c> attribute. You can call the
	/// property methods of this interface to obtain and modify the attribute.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsbacklink
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsBackLink")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("FD1302BD-4080-11D1-A3AC-00C04FB950DC"), CoClass(typeof(BackLink))]
	public interface IADsBackLink
	{
		/// <summary>Gets or sets the identifier of the remote server that requires an external reference of the object specified by ObjectName.</summary>
		/// <value>The identifier of the remote server that requires an external reference of the object specified by ObjectName.</value>
		[DispId(2)]
		int RemoteID
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the name of an object the Back Link attribute is attached to.</summary>
		/// <value>The name of an object the Back Link attribute is attached to.</value>
		[DispId(3)]
		string ObjectName
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(3)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}
	}

	/// <summary>
	/// The <c>IADsCaseIgnoreList</c> interface provides methods for an ADSI client to access the Case Ignore List attribute. You can call
	/// the property methods of this interface to obtain and modify the attribute.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadscaseignorelist
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsCaseIgnoreList")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("7B66B533-4680-11D1-A3B4-00C04FB950DC"), CoClass(typeof(CaseIgnoreList))]
	public interface IADsCaseIgnoreList
	{
		/// <summary>Gets or sets an ordered sequence of case insensitive strings.</summary>
		/// <value>An ordered sequence of case insensitive strings.</value>
		[DispId(2)]
		object CaseIgnoreList
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
	/// The <c>IADsClass</c> interface is designed for managing schema class objects that provide class definitions for any ADSI object.
	/// Other schema management interfaces include IADsProperty for attribute definitions and IADsSyntax for attribute syntax.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Schema objects are organized in the schema container of a given directory. To access an object's schema class, use the object's
	/// <c>Schema</c> property (namely, call the IADs::get_Schema property method) to obtain the ADsPath string and use that string to bind
	/// to its schema class object.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code example shows how to implement the <c>IADsClass</c> interface.</para>
	/// <para>The following code example shows how to implement the <c>IADsClass</c> interface.</para>
	/// <para>The following code example shows how to implement the <c>printVarArray</c> function.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsclass
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsClass")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("C8F93DD0-4AE0-11CF-9E73-00AA004A5691")]
	public interface IADsClass : IADs
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
		/// Gets the optional provider-specific identifier GUID that associates an interface to objects of this schema class. For example,
		/// the "User" class that supports IADsUser and PrimaryInterface is identified by IID_IADsUser. This must be in the standard string
		/// format of a GUID, as defined by COM. This GUID is the value that appears in the IADs::get_GUID property in instances of this
		/// class for providers that implement this property. Identifying a schema class by IID of the class code's primary interface enables
		/// the use of QueryInterface at run time to determine whether an object is of the desired class.
		/// </summary>
		/// <value>
		/// Optional provider-specific identifier GUID that associates an interface to objects of this schema class. For example, the "User"
		/// class that supports IADsUser and PrimaryInterface is identified by IID_IADsUser. This must be in the standard string format of a
		/// GUID, as defined by COM. This GUID is the value that appears in the IADs::get_GUID property in instances of this class for
		/// providers that implement this property. Identifying a schema class by IID of the class code's primary interface enables the use
		/// of QueryInterface at run time to determine whether an object is of the desired class.
		/// </value>
		[DispId(15)]
		string? PrimaryInterface
		{
			[DispId(15)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets or sets the optional provider-specific CLSID identifying the COM object that implements this class..</summary>
		/// <value>The CLSID.</value>
		[DispId(16)]
		string? CLSID
		{
			[DispId(16)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(16)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// Gets or sets the Provider-specific Object Identifier that defines this class. This is provided to allow schema extension, using
		/// Active Directory, in directory services that require provider-specific OIDs for classes.
		/// </summary>
		/// <value>
		/// Provider-specific Object Identifier that defines this class. This is provided to allow schema extension, using Active Directory,
		/// in directory services that require provider-specific OIDs for classes.
		/// </value>
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

		/// <summary>
		/// Gets or sets a boolean value that indicates if this class is Abstract or non-abstract. When TRUE, this class is an Abstract class
		/// and cannot be directly instantiated in the directory service. Abstract classes can only be used as super classes.
		/// </summary>
		/// <value><see langword="true"/> if abstract; otherwise, <see langword="false"/>.</value>
		[DispId(18)]
		bool Abstract
		{
			[DispId(18)]
			get;
			[DispId(18)]
			[param: In]
			set;
		}

		/// <summary>
		/// Gets or sets a Boolean value that indicates whether or not this class is Auxiliary. When TRUE, this class is an Auxiliary class
		/// and cannot be directly instantiated in the directory service. Auxiliary classes can only be used as super classes of other
		/// Auxiliary classes or as a source of additional properties on structural classes.
		/// </summary>
		/// <value><see langword="true"/> if auxiliary; otherwise, <see langword="false"/>.</value>
		[DispId(26)]
		bool Auxiliary
		{
			[DispId(26)]
			get;
			[DispId(26)]
			[param: In]
			set;
		}

		/// <summary>
		/// Gets or sets the SAFEARRAY of VARIANTs that lists the properties that must be set for this class to be written to storage. If the
		/// class only contains one property, then get_MandatoryProperties will return a BSTR.
		/// </summary>
		/// <value>
		/// SAFEARRAY of VARIANTs that lists the properties that must be set for this class to be written to storage. If the class only
		/// contains one property, then get_MandatoryProperties will return a BSTR.
		/// </value>
		[DispId(19)]
		object MandatoryProperties
		{
			[DispId(19)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(19)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>
		/// Gets or sets SAFEARRAY of VARIANTs that lists the optional properties for this schema class. If the class only contains one
		/// property, then get_OptionalProperties will return a BSTR.
		/// </summary>
		/// <value>
		/// SAFEARRAY of VARIANTs that lists the optional properties for this schema class. If the class only contains one property, then
		/// get_OptionalProperties will return a BSTR.
		/// </value>
		[DispId(29)]
		object OptionalProperties
		{
			[DispId(29)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(29)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets a SAFEARRAY of BSTRs that lists the properties used to name attributes of this schema class.</summary>
		/// <value>SAFEARRAY of BSTRs that lists the properties used to name attributes of this schema class.</value>
		[DispId(30)]
		object NamingProperties
		{
			[DispId(30)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(30)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets the array of ADsPath strings that indicate which classes this class was derived from.</summary>
		/// <value>Array of ADsPath strings that indicate which classes this class was derived from.</value>
		[DispId(20)]
		object DerivedFrom
		{
			[DispId(20)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(20)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets the array of ADsPath strings that indicate the super Auxiliary classes this class derives from.</summary>
		/// <value>The array of ADsPath strings that indicate the super Auxiliary classes this class derives from.</value>
		[DispId(27)]
		object AuxDerivedFrom
		{
			[DispId(27)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(27)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets an array of ADsPath strings that indicate the schema classes that can contain instances of this class.</summary>
		/// <value>Array of ADsPath strings that indicate the schema classes that can contain instances of this class.</value>
		[DispId(28)]
		object PossibleSuperiors
		{
			[DispId(28)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(28)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets a BSTR array in which each element is the name of an object class that this class can contain.</summary>
		/// <value>A BSTR array in which each element is the name of an object class that this class can contain.</value>
		[DispId(21)]
		object Containment
		{
			[DispId(21)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(21)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>
		/// Gets or sets a Boolean value that indicates if this class can be a container of other object classes. If this value is TRUE, you
		/// can call the get_Container method to get an array of the object classes that this class can contain.
		/// </summary>
		/// <value><see langword="true"/> if container; otherwise, <see langword="false"/>.</value>
		[DispId(22)]
		bool Container
		{
			[DispId(22)]
			get;
			[DispId(22)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the name of a help file that contains more information about objects of this class.</summary>
		/// <value>Name of a help file that contains more information about objects of this class.</value>
		[DispId(23)]
		string HelpFileName
		{
			[DispId(23)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(23)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the Context ID inside HelpFileName where specific information for this class can be found.</summary>
		/// <value>Context ID inside HelpFileName where specific information for this class can be found.</value>
		[DispId(24)]
		int HelpFileContext
		{
			[DispId(24)]
			get;
			[DispId(24)]
			[param: In]
			set;
		}

		/// <summary>
		/// The <c>IADsClass::Qualifiers</c> method is an optional method that returns a collection of ADSI objects that describe additional
		/// qualifiers for this schema class.
		/// </summary>
		/// <returns>
		/// Address of an IADsCollection pointer variable that receives the interface pointer to the ADSI collection object that represents
		/// additional limits for this schema class.
		/// </returns>
		/// <remarks>
		/// <para>The qualifier objects are provider-specific. When supported, this method can be used to obtain extended schema data.</para>
		/// <para>This method is not currently supported by any of Microsoft providers.</para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsclass-qualifiers HRESULT Qualifiers( [out] IADsCollection
		// **ppQualifiers );
		[DispId(25)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IADsCollection Qualifiers();
	}

	/// <summary>
	/// <para>
	/// The <c>IADsCollection</c> interface is a dual interface that enables its hosting ADSI object to define and manage an arbitrary set of
	/// named data elements for a directory service. Collections differ from arrays of elements in that individual items can be added or
	/// deleted without reordering the entire array.
	/// </para>
	/// <para>
	/// Collection objects can represent one or more items that correspond to volatile data, such as processes or active communication
	/// sessions, as well as persistent data, such as physical entities for a directory service. For example, a collection object can
	/// represent a list of print jobs in a queue or a list of active sessions connected to a server. Although a collection object can
	/// represent arbitrary data sets, all elements in a collection must be of the same type. The data are of <c>Variant</c> types.
	/// </para>
	/// <para>
	/// ADSI also exposes the IADsMembers and IADsContainer interfaces for manipulating two special cases of collection objects.
	/// <c>IADsMembers</c> is used for a collection of objects that share a common membership. An example of such objects are users that
	/// belong to a group. <c>IADsContainer</c> applies to an ADSI object that contains other objects. An example of this is a directory tree
	/// or a network topology.
	/// </para>
	/// </summary>
	/// <remarks>
	/// Of the ADSI system providers, only the WinNT provider supports this interface to handle active file service sessions, resources and
	/// print jobs.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadscollection
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsCollection")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("72B945E0-253B-11CF-A988-00AA006BC149")]
	public interface IADsCollection : IEnumerable
	{
		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();

		/// <summary>The <c>IADsCollection::Add</c> method adds a named item to the collection.</summary>
		/// <param name="bstrName">
		/// The <c>BSTR</c> value that specifies the item name. IADsCollection::GetObject and IADsCollection::Remove reference the item by
		/// this name.
		/// </param>
		/// <param name="vItem">Item value. When the item is an object, this parameter holds the IDispatch interface pointer on the object.</param>
		/// <remarks>
		/// <para>Collections for a directory service can also consist of a set of immutable objects.</para>
		/// <para>This method is not supported in any of the ADSI system providers.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadscollection-add HRESULT Add( [in] BSTR bstrName, [in] VARIANT
		// vItem );
		[DispId(4)]
		void Add([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] object? vItem);

		/// <summary>The <c>IADsCollection::Remove</c> method removes the named item from this ADSI collection object.</summary>
		/// <param name="bstrItemToBeRemoved">
		/// The null-terminated Unicode string that specifies the name of the item as it was specified by IADsCollection::Add.
		/// </param>
		/// <remarks>
		/// <para>Collections for a directory service can also consist of a set of immutable objects.</para>
		/// <para>Collections that do not support direct removal of items are required to return <c>E_NOTIMPL</c>.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following Visual Basic code example shows how to remove a named session object from a collection of active file service sessions.
		/// </para>
		/// <para>The following C++ code example shows how to remove a named session object from a collection of active file service sessions.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadscollection-remove HRESULT Remove( [in] BSTR
		// bstrItemToBeRemoved );
		[DispId(5)]
		void Remove([In, MarshalAs(UnmanagedType.BStr)] string bstrItemToBeRemoved);

		/// <summary>The <c>IADsCollection::GetObject</c> method retrieves an item of the collection.</summary>
		/// <param name="bstrName">
		/// The null-terminated Unicode string that specifies the name of the item. This is the same name passed to IADsCollection::Add when
		/// the item is added to the collection.
		/// </param>
		/// <returns>Current value of the item. For an object, this corresponds to the IDispatch interface pointer on the object.</returns>
		/// <remarks>
		/// <para>
		/// If you know the name of a session in the <c>Sessions</c> collection, call the <c>IADsCollection::GetObject</c> method explicitly
		/// to retrieve the session object.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following Visual Basic code example shows how to retrieve a named session object from a collection of active file service sessions.
		/// </para>
		/// <para>The following C++ code example shows how to retrieve a named session object from a collection of active file service sessions.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadscollection-getobject HRESULT GetObject( [in] BSTR bstrName,
		// [in] VARIANT *pvItem );
		[DispId(6)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetObject([In, MarshalAs(UnmanagedType.BStr)] string bstrName);
	}

	/// <summary>
	/// <para>
	/// The <c>IADsComputer</c> interface is a dual interface that inherits from IADs. It is designed to represent and manage a computer,
	/// such as a server, client, workstation, and so on, on a network. You can manipulate the properties of this interface to access data
	/// about a computer. The data includes the operating system, the make and model, processor, computer identifier, its network addresses,
	/// and so on.
	/// </para>
	/// <para>
	/// <c>Note</c>  The <c>IADsComputer</c> interface is not implemented by the LDAP ADSI provider. For more information, see ADSI Objects
	/// of LDAP.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadscomputer
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsComputer")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("EFE3CC70-1D9F-11CF-B1F3-02608C9E7553")]
	public interface IADsComputer : IADs
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

		/// <summary>Gets the globally unique identifier assigned to each computer.</summary>
		/// <value>The globally unique identifier assigned to each computer.</value>
		[DispId(16)]
		string ComputerID
		{
			[DispId(16)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// Gets the globally unique identifier that identifies the site that this computer was installed in. A site is a physical region of
		/// good connectivity in a network.
		/// </summary>
		/// <value>
		/// The globally unique identifier that identifies the site that this computer was installed in. A site is a physical region of good
		/// connectivity in a network.
		/// </value>
		[DispId(18)]
		string Site
		{
			[DispId(18)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets or sets the description of this computer.</summary>
		/// <value>The description of this computer.</value>
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

		/// <summary>Gets or sets the assigned physical location of this computer.</summary>
		/// <value>The assigned physical location of this computer.</value>
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

		/// <summary>Gets or sets the name of the contact person, such as an administrator, for this computer.</summary>
		/// <value>The name of the contact person, such as an administrator, for this computer.</value>
		[DispId(21)]
		string PrimaryUser
		{
			[DispId(21)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(21)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// Gets or sets the person to whom this computer is assigned. This person should also have a license to run the installed software.
		/// </summary>
		/// <value>The person to whom this computer is assigned. This person should also have a license to run the installed software.</value>
		[DispId(22)]
		string Owner
		{
			[DispId(22)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(22)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the division, within an organization, that this computer belongs to.</summary>
		/// <value>The division, within an organization, that this computer belongs to.</value>
		[DispId(23)]
		string Division
		{
			[DispId(23)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(23)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the organizational unit (OU), such as department, that this computer belongs to.</summary>
		/// <value>The organizational unit (OU), such as department, that this computer belongs to.</value>
		[DispId(24)]
		string Department
		{
			[DispId(24)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(24)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the role of this computer, for example, workstation, server, or domain controller.</summary>
		/// <value>The role of this computer, for example, workstation, server, or domain controller.</value>
		[DispId(25)]
		string Role
		{
			[DispId(25)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(25)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the operating system used on this computer.</summary>
		/// <value>The operating system used on this computer.</value>
		[DispId(26)]
		string OperatingSystem
		{
			[DispId(26)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(26)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the version of the operating system used on this computer.</summary>
		/// <value>The version of the operating system used on this computer.</value>
		[DispId(27)]
		string OperatingSystemVersion
		{
			[DispId(27)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(27)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the make and model of this computer.</summary>
		/// <value>The make and model of this computer.</value>
		[DispId(28)]
		string Model
		{
			[DispId(28)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(28)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the processor type.</summary>
		/// <value>The processor type.</value>
		[DispId(29)]
		string Processor
		{
			[DispId(29)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(29)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the number of installed processors.</summary>
		/// <value>The number of installed processors.</value>
		[DispId(30)]
		string ProcessorCount
		{
			[DispId(30)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(30)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the size, in megabytes, of random access memory for this computer..</summary>
		/// <value>The size, in megabytes, of random access memory for this computer.</value>
		[DispId(31)]
		string MemorySize
		{
			[DispId(31)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(31)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the size, in megabytes, of the disk.</summary>
		/// <value>The size, in megabytes, of the disk.</value>
		[DispId(32)]
		string StorageCapacity
		{
			[DispId(32)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(32)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// Gets or sets an array of NetAddress fields that represent the addresses by which this computer can be reached. NetAddress is a
		/// provider-specific BSTR composed of two substrings separated by a colon (:). The left substring indicates the address type, and
		/// the right substring is a string representation of an address of that type. For example, TCP/IP addresses are of the form:
		/// IP:100.201.301.45. IPX type addresses are of the form: IPX:10.123456.80.
		/// </summary>
		/// <value>
		/// An array of NetAddress fields that represent the addresses by which this computer can be reached. NetAddress is a
		/// provider-specific BSTR composed of two substrings separated by a colon (:). The left substring indicates the address type, and
		/// the right substring is a string representation of an address of that type. For example, TCP/IP addresses are of the form:
		/// IP:100.201.301.45. IPX type addresses are of the form: IPX:10.123456.80.
		/// </value>
		[DispId(17)]
		object NetAddresses
		{
			[DispId(17)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(17)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}
	}

	/// <summary>
	/// The <c>IADsComputerOperations</c> interface is a dual interface that inherits from IADs. It exposes methods for retrieving the status
	/// of a computer over a network and to enable remote shutdown. Directory service providers may choose to implement this interface to
	/// support basic system administration over a network through ADSI.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadscomputeroperations
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsComputerOperations")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("EF497680-1D9F-11CF-B1F3-02608C9E7553")]
	public interface IADsComputerOperations : IADs
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

		/// <summary>The <c>IADsComputerOperations::Status</c> method retrieves the status of a computer.</summary>
		/// <returns>Pointer to an IDispatch interface that reports the status code of computer operations. The status code is provider-specific.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadscomputeroperations-status HRESULT Status( [out] IDispatch
		// **ppObject );
		[DispId(33)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object Status();

		/// <summary>
		/// The <c>IADsComputerOperations::Shutdown</c> method causes a computer under ADSI control to execute the shutdown operation with an
		/// optional reboot.
		/// </summary>
		/// <param name="bReboot">If <c>TRUE</c>, then reboot the computer after the shutdown is complete.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadscomputeroperations-shutdown HRESULT Shutdown( [in]
		// VARIANT_BOOL bReboot );
		[DispId(34)]
		void Shutdown([In] bool bReboot);
	}

	/// <summary>
	/// <para>
	/// The <c>IADsContainer</c> interface enables an ADSI container object to create, delete, and manage contained ADSI objects. Container
	/// objects represent hierarchical directory trees, such as in a file system, and to organize the directory hierarchy.
	/// </para>
	/// <para>
	/// You can use the <c>IADsContainer</c> interface to either enumerate contained objects or manage their lifecycle. An example would be
	/// to recursively navigate a directory tree. By querying the <c>IADsContainer</c> interface on an ADSI object, you can determine if the
	/// object has any children. If the interface is not supported, the object is a leaf. Otherwise, it is a container. You can continue this
	/// process for the newly found container objects. To create, copy, or delete an object, send the request to the container object to
	/// perform the task.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>To determine if an object is a container, use the IADsClass.Container property of the object.</para>
	/// <para>
	/// When you bind to a container object using its GUID (or SID), you can only perform specific operations on the container object. These
	/// operations include examination of the object attributes and enumeration of the object's immediate children. These operations are
	/// shown in the following code example.
	/// </para>
	/// <para>
	/// All other operations, that is, <c>GetObject</c>, <c>Create</c>, <c>Delete</c>, <c>CopyHere</c>, and <c>MoveHere</c> are not supported
	/// in the container's GUID representation. For example, the last line of the following code example will result in an error.
	/// </para>
	/// <para>Binding, using GUID (or SID), is intended for low overhead and, thus, fast binds, which are often used for object introspection.</para>
	/// <para>To call these methods of the container bound with its GUID (or SID), rebind to the object using its distinguished name.</para>
	/// <para>For more information about object GUID representation, see IADs.GUID.</para>
	/// <para>Examples</para>
	/// <para>The following code example determines if an ADSI object is a container.</para>
	/// <para>The following code example determines if an ADSI object is a container.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadscontainer
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsContainer")]
	[ComImport, Guid("001677d0-fd16-11ce-abc4-02608c9e7553"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IADsContainer : IEnumerable
	{
		/// <summary>Retrieves the number of items in the container. When Filter is set, Count returns only the number of filtered items.</summary>
		/// <value>The count.</value>
		[DispId(2)]
		int Count
		{
			[DispId(2)]
			get;
		}

		/// <summary>
		/// The <c>IADsContainer::get__NewEnum</c> method Retrieves an enumerator object for the container. The enumerator object implements
		/// the IEnumVARIANT interface to enumerate the children of the container object.
		/// </summary>
		/// <returns>The enumerator object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadscontainer-get__newenum HRESULT get__NewEnum( [out] IUnknown
		// **retval );
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();

		/// <summary>
		/// Retrieves or sets the filter used to select object classes in a given enumeration. This is a variant array, each element of which
		/// is the name of a schema class. If Filter is not set or set to empty, all objects of all classes are retrieved by the enumerator.
		/// </summary>
		/// <value>The filter.</value>
		[DispId(3)]
		object? Filter
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Struct)] //CustomMarshaler, MarshalTypeRef = typeof(VariantMarshaler<string?[]>))]
			get;
			[DispId(3)]
			[param: In, MarshalAs(UnmanagedType.Struct)] //CustomMarshaler, MarshalTypeRef = typeof(VariantMarshaler<string?[]>))]
			set;
		}

		/// <summary>
		/// A variant array of BSTR strings. Each element identifies the name of a property found in the schema definition. The vHints
		/// parameter enables the client to indicate which attributes to load for each enumerated object. Such data may be used to optimize
		/// network access. The exact implementation, however, is provider-specific, and is currently not used by the WinNT provider.
		/// </summary>
		/// <value>The hints.</value>
		[DispId(4)]
		object? Hints
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Struct)] //CustomMarshaler, MarshalTypeRef = typeof(VariantMarshaler<string?[]>))]
			get;

			[DispId(4)]
			[param: In, MarshalAs(UnmanagedType.Struct)] //CustomMarshaler, MarshalTypeRef = typeof(VariantMarshaler<string?[]>))]
			set;
		}

		/// <summary>The <c>IADsContainer::GetObject</c> method retrieves an interface for a directory object in the container.</summary>
		/// <param name="ClassName">
		/// A <c>BSTR</c> that specifies the name of the object class as of the object to retrieve. If this parameter is <c>NULL</c>, the
		/// provider returns the first item found in the container.
		/// </param>
		/// <param name="RelativeName">A <c>BSTR</c> that specifies the relative distinguished name of the object to retrieve.</param>
		/// <returns>A pointer to a pointer to the IDispatch interface on the specified object.</returns>
		/// <remarks>
		/// <para>
		/// For the LDAP provider, the <c>bstrRelativeName</c> parameter must contain the name prefix, such as "CN=Jeff Smith". The
		/// <c>bstrRelativeName</c> parameter can also contain more than one level of name, such as "CN=Jeff Smith,OU=Sales".
		/// </para>
		/// <para>
		/// In C++, when <c>GetObject</c> has succeeded, the caller must query the IDispatch interface for the desired interface using the
		/// QueryInterface method.
		/// </para>
		/// <para>
		/// The <c>bstrClassName</c> parameter can be either a valid class name or <c>NULL</c>. If the class name is not valid, including
		/// when it contains a blank space, this method will throw an E_ADS_UNKNOWN_OBJECT error.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example retrieves a user object from a container object.</para>
		/// <para>This is equivalent to:</para>
		/// <para>The following code example retrieves a user object from a container object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadscontainer-getobject HRESULT GetObject( [in] BSTR ClassName,
		// [in] BSTR RelativeName, [out] IDispatch **ppObject );
		[DispId(5)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object GetObject([MarshalAs(UnmanagedType.BStr)] string? ClassName, [MarshalAs(UnmanagedType.BStr)] string RelativeName);

		/// <summary>
		/// The <c>IADsContainer::Create</c> method sets up a request to create a directory object of the specified schema class and a given
		/// name in the container. The object is not made persistent until IADs::SetInfo is called on the new object. This allows for setting
		/// mandatory properties on the new object.
		/// </summary>
		/// <param name="ClassName">
		/// Name of the schema class object to be created. The name is that returned from the IADs::get_Schema property method.
		/// </param>
		/// <param name="RelativeName">
		/// Relative name of the object as it is known in the underlying directory and identical to the one retrieved through the
		/// IADs::get_Name property method.
		/// </param>
		/// <returns>Indirect pointer to the IDispatch interface on the newly created object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadscontainer-create HRESULT Create( [in] BSTR ClassName, [in]
		// BSTR RelativeName, [out] IDispatch **ppObject );
		[DispId(6)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object Create([MarshalAs(UnmanagedType.BStr)] string ClassName, [MarshalAs(UnmanagedType.BStr)] string RelativeName);

		/// <summary>The <c>IADsContainer::Delete</c> method deletes a specified directory object from this container.</summary>
		/// <param name="bstrClassName">
		/// The schema class object to delete. The name is that returned from the IADs::get_Class method. Also, <c>NULL</c> is a valid option
		/// for this parameter. Providing <c>NULL</c> for this parameter is the only way to deal with defunct schema classes. If an instance
		/// was created before the class became defunct, the only way to delete the instance of the defunct class is to call
		/// <c>IADsContainer::Delete</c> and provide <c>NULL</c> for this parameter.
		/// </param>
		/// <param name="bstrRelativeName">
		/// Name of the object as it is known in the underlying directory and identical to the name retrieved with the IADs::get_Name method.
		/// </param>
		/// <remarks>
		/// <para>
		/// The object to be deleted must be a leaf object or a childless subcontainer. To delete a container and its children, that is, a
		/// subtree, use IADsDeleteOps::DeleteObject.
		/// </para>
		/// <para>
		/// The specified object is immediately removed after calling <c>IADsContainer::Delete</c> and calling IADs::SetInfo on the container
		/// object is unnecessary.
		/// </para>
		/// <para>
		/// When using the <c>IADsContainer::Delete</c> method to delete an object in C/C++ applications, release the interface pointers to
		/// that object as well. This is because the method removes the object from the underlying directory immediately, but leave intact
		/// any interface pointers held, in memory, by the application, for the deleted object. If not released, confusion can occur in that
		/// you may call IADs::Get and IADs::Put on the deleted object without error, but will receive an error when you call IADs::SetInfo
		/// or IADs::GetInfo on the deleted object.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example deletes a user object from the container in Active Directory.</para>
		/// <para>The following code example deletes a user object from the container under WinNT provider.</para>
		/// <para>The following code example deletes a user using <c>IADsContainer::Delete</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadscontainer-delete HRESULT Delete( [in] BSTR bstrClassName,
		// [in] BSTR bstrRelativeName );
		[DispId(7)]
		void Delete([MarshalAs(UnmanagedType.BStr)] string? bstrClassName, [MarshalAs(UnmanagedType.BStr)] string bstrRelativeName);

		/// <summary>The <c>IADsContainer::CopyHere</c> method creates a copy of the specified directory object in this container.</summary>
		/// <param name="SourceName">The ADsPath of the object to copy.</param>
		/// <param name="NewName">
		/// Optional name of the new object within the container. If a new name is not specified for the object, set to <c>NULL</c>; the new
		/// object will have the same name as the source object.
		/// </param>
		/// <returns>Indirect pointer to the IADs interface on the copied object.</returns>
		/// <remarks>
		/// <para>
		/// The destination container must be in the same directory service as the source container. An object cannot be copied across a
		/// directory service implementation.
		/// </para>
		/// <para>The providers supplied with ADSI return the <c>E_NOTIMPL</c> error message.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadscontainer-copyhere HRESULT CopyHere( [in] BSTR SourceName,
		// [in] BSTR NewName, [out] IDispatch **ppObject );
		[DispId(8)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object CopyHere([MarshalAs(UnmanagedType.BStr)] string SourceName, [MarshalAs(UnmanagedType.BStr)] string? NewName);

		/// <summary>
		/// The <c>IADsContainer::MoveHere</c> method moves a specified object to the container that implements this interface.The method can
		/// be used to rename an object.
		/// </summary>
		/// <param name="SourceName">The null-terminated Unicode string that specifies the <c>ADsPath</c> of the object to be moved.</param>
		/// <param name="NewName">
		/// The null-terminated Unicode string that specifies the relative name of the new object within the container. This can be
		/// <c>NULL</c>, in which case the object is moved. If it is not <c>NULL</c>, the object is renamed accordingly in the process.
		/// </param>
		/// <returns>Pointer to a pointer to the IDispatch interface on the moved object.</returns>
		/// <remarks>
		/// <para>
		/// In Active Directory, you can move an object within the same domain or from different domains in the same directory forest. For
		/// the cross domain move, the following restrictions apply:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>The destination domain must be in the native mode.</description>
		/// </item>
		/// <item>
		/// <description>Objects to be moved must be a leaf object or an empty container.</description>
		/// </item>
		/// <item>
		/// <description>
		/// NT LAN Manager (NTLM) cannot perform authentication; use Kerberos authentication or delegation. Be aware that if Kerberos
		/// authentication is not used, the password transmits in plaintext over the network. To avoid this, use delegation with secure authentication.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// You cannot move security principals (for example, user, group, computer, and so on) belonging to a global group. When a security
		/// principal is moved, a new SID is created for the object at the destination. However, its old SID from the source, stored in the
		/// <c>sIDHistory</c> attribute, is preserved, as well as the password of the object.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c>  Use the Movetree.exe utility to move a subtree among different domains. To move objects from a source domain to a
		/// destination domain using the Movetree command-line tool, you must connect to the domain controller holding the source domain's
		/// RID master role. If the RID master is unavailable then objects cannot be moved to other domains. If you attempt to move an object
		/// from one domain to another using the Movetree.exe tool and you specify a source domain controller that is not the RID master, a
		/// nonspecific "Movetree failed" error message results.
		/// </para>
		/// <para></para>
		/// <para>
		/// <c>Note</c>  When using the ADsOpenObject function to bind to an ADSI object, you must use the <c>ADS_USE_DELEGATION</c> flag of
		/// the ADS_AUTHENTICATION_ENUM in the <c>dwReserved</c> parameter of this function in order to create cross-domain moves with
		/// <c>IADsContainer::MoveHere</c>. The <c>ADsOpenObject</c> function is equivalent to the IADsOpenDSObject::OpenDsObject method.
		/// Likewise, using the <c>OpenDsObject</c> method to bind to an ADSI object, the <c>InReserved</c> parameter of this method must
		/// contain the <c>ADS_USE_DELEGATION</c> flag of the <c>ADS_AUTHENTICATION_ENUM</c> in order to make cross-domain moves with <c>IADsContainer::MoveHere</c>.
		/// </para>
		/// <para></para>
		/// <para>
		/// The following code example moves the user, "jeffsmith" from the "South.Fabrikam.Com" domain to the "North.Fabrikam.Com" domain.
		/// First, it gets an IADsContainer pointer to the destination container, then the <c>MoveHere</c> call specifies the path of the
		/// object to move.
		/// </para>
		/// <para>A serverless ADsPath can be used for either the source or the destination or both.</para>
		/// <para>
		/// The <c>IADsContainer::MoveHere</c> method can be used either to rename an object within the same container or to move an object
		/// among different containers. Moving an object retains the object RDN, whereas renaming an object alters the RDN.
		/// </para>
		/// <para>For example, the following code example performs the rename action.</para>
		/// <para>The following code example performs the move.</para>
		/// <para>
		/// In Visual Basic applications, you can pass <c>vbNullString</c> as the second parameter when moving an object from one container
		/// to another.
		/// </para>
		/// <para>
		/// However, you cannot do the same with VBScript. This is because VBScript maps <c>vbNullString</c> to an empty string instead of to
		/// a null string, as does Visual Basic. You must use the RDN explicitly, as shown in the previous example.
		/// </para>
		/// <para>
		/// <c>Note</c>  The WinNT provider supports <c>IADsContainer::MoveHere</c>, but only for renaming users &amp; groups within a domain.
		/// </para>
		/// <para></para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use this method to rename an object.</para>
		/// <para>The following code example moves a user object using the <c>IADsContainer::MoveHere</c> method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadscontainer-movehere HRESULT MoveHere( [in] BSTR SourceName,
		// [in] BSTR NewName, [out] IDispatch **ppObject );
		[DispId(9)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object MoveHere([MarshalAs(UnmanagedType.BStr)] string SourceName, [MarshalAs(UnmanagedType.BStr)] string? NewName);
	}

	/// <summary>
	/// <para>
	/// The <c>IADsDeleteOps</c> interface specifies a method an object can use to delete itself from the underlying directory. For a
	/// container object, the method deletes its children and the entire subtree.
	/// </para>
	/// <para>
	/// The interface is designed to offer features that complement IADsContainer. To remove an object from the directory store, request its
	/// parent object to perform the operation. That amounts to calling the IADsContainer::Delete method on the contained object. When the
	/// object also implements the <c>IADsDeleteOps</c> interface, you can instruct the object to remove itself, and all the contained
	/// objects, by calling the IADsDeleteOps::DeleteObject method directly on the object.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsdeleteops
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsDeleteOps")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("B2BD0902-8878-11D1-8C21-00C04FD8D503")]
	public interface IADsDeleteOps
	{
		/// <summary>The <c>IADsDeleteOps::DeleteObject</c> method deletes an ADSI object.</summary>
		/// <param name="lnFlags">Reserved.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsdeleteops-deleteobject HRESULT DeleteObject( long lnFlags );
		[DispId(2)]
		void DeleteObject([In] int lnFlags = 0);
	}

	/// <summary>
	/// The <c>IADsDNWithBinary</c> interface provides methods for an ADSI client to associate a distinguished name (DN) with the GUID of an object.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsdnwithbinary
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsDNWithBinary")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("7E99C0A2-F935-11D2-BA96-00C04FB6D0D1"), CoClass(typeof(DNWithBinary))]
	public interface IADsDNWithBinary
	{
		/// <summary>Gets or sets the GUID of an object associated with a DN.</summary>
		/// <value>The GUID of an object associated with a DN.</value>
		[DispId(2)]
		object BinaryValue
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(2)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets the DN string associated with the GUID of an object.</summary>
		/// <value>The DN string associated with the GUID of an object.</value>
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
	}

	/// <summary>
	/// The <c>IADsDNWithString</c> interface provides methods for an ADSI client to associate a distinguished name (DN) to a string value.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsdnwithstring
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsDNWithString")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("370DF02E-F934-11D2-BA96-00C04FB6D0D1"), CoClass(typeof(DNWithString))]
	public interface IADsDNWithString
	{
		/// <summary>Gets or sets the string value associated with a DN of an object.</summary>
		/// <value>The string value associated with a DN of an object.</value>
		[DispId(2)]
		string StringValue
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(2)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the DN string associated with a string value.</summary>
		/// <value>The DN string associated with a string value.</value>
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
	}

	/// <summary>
	/// The <c>IADsDomain</c> interface is a dual interface that inherits from IADs. It is designed to represent a network domain and manage
	/// domain accounts. Use this interface to determine whether the domain is actually a Workgroup, to specify how frequently a user must
	/// change a password, and to specify the maximum number of invalid password logins allowed before a lockout on the account is set. To
	/// change a password, call the <c>ChangePassword</c> method on an ADSI object that supports password controls. For example, to change
	/// the password of a user account, call IADsUser::ChangePassword on the user object.
	/// </summary>
	/// <remarks>For the WinNT provider supplied by Microsoft, this interface is implemented on the <c>WinNTDomain</c> object.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsdomain
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsDomain")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("00E4C220-FD16-11CE-ABC4-02608C9E7553")]
	public interface IADsDomain : IADs
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

		/// <summary>This property is no longer implemented.</summary>
		[DispId(15), Obsolete]
		bool IsWorkgroup
		{
			[DispId(15)]
			get;
		}

		/// <summary>Gets or sets the minimum number of characters that must be used for a password.</summary>
		/// <value>Indicates the minimum number of characters that must be used for a password.</value>
		[DispId(16)]
		int MinPasswordLength
		{
			[DispId(16)]
			get;
			[DispId(16)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the minimum time interval, in seconds, before the password can be changed.</summary>
		/// <value>Indicates the minimum time interval, in seconds, before the password can be changed.</value>
		[DispId(17)]
		int MinPasswordAge
		{
			[DispId(17)]
			get;
			[DispId(17)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the maximum time interval, in seconds, after which the password must be changed by the user.</summary>
		/// <value>Indicates the maximum time interval, in seconds, after which the password must be changed by the user.</value>
		[DispId(18)]
		int MaxPasswordAge
		{
			[DispId(18)]
			get;
			[DispId(18)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the maximum number of bad password logins allowed before an account lockout.</summary>
		/// <value>Indicates the maximum number of bad password logins allowed before an account lockout.</value>
		[DispId(19)]
		int MaxBadPasswordsAllowed
		{
			[DispId(19)]
			get;
			[DispId(19)]
			[param: In]
			set;
		}

		/// <summary>
		/// Gets or sets the number of previous passwords saved in the history list. The user cannot reuse a password in the history list.
		/// </summary>
		/// <value>
		/// Indicates the number of previous passwords saved in the history list. The user cannot reuse a password in the history list.
		/// </value>
		[DispId(20)]
		int PasswordHistoryLength
		{
			[DispId(20)]
			get;
			[DispId(20)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets restrictions on passwords, as defined by the following list of attributes and values.</summary>
		/// <value>Indicates restrictions on passwords, as defined by the following list of attributes and values.</value>
		[DispId(21)]
		int PasswordAttributes
		{
			[DispId(21)]
			get;
			[DispId(21)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the minimum time that must elapse before the account is automatically reenabled.</summary>
		/// <value>Indicates the minimum time that must elapse before the account is automatically reenabled.</value>
		[DispId(22)]
		int AutoUnlockInterval
		{
			[DispId(22)]
			get;
			[DispId(22)]
			[param: In]
			set;
		}

		/// <summary>
		/// Gets or sets the time window during which the bad password count is monitored and accumulated before determining whether the
		/// account needs to be locked out. For example, if the number of bad password attempts on an account exceed the threshold (Maximum
		/// Bad Passwords Allowed) during the specified time period (Lockout Observation Interval) the account will be locked out by setting
		/// the appropriate property in the Login Parameter property set.
		/// </summary>
		/// <value>
		/// Indicates the time window during which the bad password count is monitored and accumulated before determining whether the account
		/// needs to be locked out. For example, if the number of bad password attempts on an account exceed the threshold (Maximum Bad
		/// Passwords Allowed) during the specified time period (Lockout Observation Interval) the account will be locked out by setting the
		/// appropriate property in the Login Parameter property set.
		/// </value>
		[DispId(23)]
		int LockoutObservationInterval
		{
			[DispId(23)]
			get;
			[DispId(23)]
			[param: In]
			set;
		}
	}

	/// <summary>
	/// <para>The <c>IADsEmail</c> interface provides methods for an ADSI client to access the Email Address attribute.</para>
	/// <para>You can call the property methods of this interface to obtain and modify the attribute.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsemail
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsEmail")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("97AF011A-478E-11D1-A3B4-00C04FB950DC"), CoClass(typeof(Email))]
	public interface IADsEmail
	{
		/// <summary>Gets or sets the type of the email message.</summary>
		/// <value>The type of the email message.</value>
		[DispId(2)]
		int Type
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		/// <summary>Gets or sets the email address of the user.</summary>
		/// <value>The email address of the user.</value>
		[DispId(3)]
		string Address
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(3)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}
	}

	/// <summary>
	/// <para>
	/// The <c>IADsExtension</c> interface forms the basis of the ADSI application extension model. It enables an independent software vendor
	/// (ISV) to add application-specific behaviors, such as methods or functions, into an existing ADSI object. Multiple vendors can
	/// independently extend the features of the same object to perform similar, but unrelated operations.
	/// </para>
	/// <para>
	/// The extension model is based on the aggregation model in COM. An aggregator, or outer object, can add to its base of methods, those
	/// of an aggregate object, or inner object. An ADSI extension object, which implements the <c>IADsExtension</c> interface, is an
	/// aggregate object, whereas an ADSI provider is an aggregator.
	/// </para>
	/// <para>
	/// <c>Note</c>  When implementing an extension module, release an interface when finished with it. Otherwise, the aggregator cannot
	/// release the interface even when no longer required.
	/// </para>
	/// <para></para>
	/// <para>The <c>IADsExtension</c> interface can be used as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// The extension component requires an initialization notification as defined by <c>dwCode</c> in the Operate method. In this case, an
	/// extension client must call the <c>Operate</c> method. The other two methods, namely, PrivateInvoke and PrivateGetIDsOfNames, usually
	/// return <c>E_NOTIMPL</c> in the <c>HRESULT</c> value.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// The extension component supports any dual or dispatch interface. In this case, an extension client must call the PrivateGetIDsOfNames
	/// or PrivateInvoke methods. Operate usually ignores the data and returns <c>E_NOTIMPL</c> in the <c>HRESULT</c> value.
	/// </description>
	/// </item>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsextension
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsExtension")]
	[ComImport, Guid("3D35553C-D2B0-11D1-B17B-0000F87593A0"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComConversionLoss]
	public interface IADsExtension
	{
		/// <summary>
		/// The <c>IADsExtension::Operate</c> method is invoked by the aggregator to perform the extended functionality. The method
		/// interprets the control code and input parameters according to the specifications of the provider. For more information, see the
		/// provider documentation.
		/// </summary>
		/// <param name="dwCode">
		/// <para>A value of the ADSI extension control code. ADSI defines the following code value.</para>
		/// <para>ADS_EXT_INITCREDENTIALS</para>
		/// <para>Verifies user credentials in the extension object.</para>
		/// </param>
		/// <param name="varData1">
		/// Provider-supplied data the extension object will operate on. The value depends upon the control code value and is presently undefined.
		/// </param>
		/// <param name="varData2">
		/// Provider-supplied data the extension object will operate on. The value depends upon the control code value and is presently undefined.
		/// </param>
		/// <param name="varData3">
		/// Provider-supplied data the extension object will operate on. The value depends upon the control code value and is presently undefined.
		/// </param>
		/// <remarks>
		/// <para>The aggregator will ignore the <c>E_FAIL</c> and <c>E_NOTIMPL</c> return values.</para>
		/// <para>Examples</para>
		/// <para>The following C/C++ code example shows a generic implementation.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsextension-operate HRESULT Operate( [in] DWORD dwCode, [in]
		// VARIANT varData1, [in] VARIANT varData2, [in] VARIANT varData3 );
		void Operate([In] ADS_EXT dwCode, [In, MarshalAs(UnmanagedType.Struct)] object? varData1, [In, MarshalAs(UnmanagedType.Struct)] object? varData2, [In, MarshalAs(UnmanagedType.Struct)] object? varData3);

		/// <summary>
		/// The <c>IADsExtension::PrivateGetIDsOfNames</c> method is called by the aggregator, ADSI, after ADSI determines that the extension
		/// is used to support a dual or dispatch interface. The method can use the type data to get DISPID using IDispatch::GetIDsOfNames.
		/// </summary>
		/// <param name="riid">Reserved for future use. It must be IID_NULL.</param>
		/// <param name="rgszNames">Passed-in array of names to be mapped.</param>
		/// <param name="cNames">Count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispid">
		/// Caller-allocated array, each element of which contains an identifier that corresponds to one of the names passed in the
		/// <c>rgszNames</c> array. The first element represents the member name. The subsequent elements represent each of the member's parameters.
		/// </param>
		/// <remarks>
		/// <para>
		/// All the parameters have the same meaning as the corresponding ones in the standard IDispatch::GetIDsOfNames(). The extension
		/// component returns a unique identifier ( <c>rgDispID</c>) for each method or property defined in the supported dual interfaces.
		/// The uniqueness is enforced within the extension component. The ADSI provider must ensure the uniqueness of the DISPIDs of all
		/// extension objects and the aggregator (ADSI) itself. The <c>rgDispID</c> parameter must be between 1 and 16777215 (2^24-1), or -1 (DISPID_UNKNOWN).
		/// </para>
		/// <para>Examples</para>
		/// <para>The following C/C++ code example shows a generic implementation of this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsextension-privategetidsofnames HRESULT PrivateGetIDsOfNames(
		// REFIID riid, OLECHAR **rgszNames, unsigned int cNames, LCID lcid, DISPID *rgDispid );
		void PrivateGetIDsOfNames(in Guid riid, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 2)] string[] rgszNames,
			[In] uint cNames, [In] LCID lcid, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] rgDispid);

		/// <summary>
		/// The <c>IADsExtension::PrivateInvoke</c> method is normally called by ADSI after the IADsExtension::PrivateGetIDsOfNames method.
		/// This method can either have a custom implementation or it can delegate the operation to IDispatch::DispInvoke method.
		/// </summary>
		/// <param name="dispidMember">
		/// Identifies the member. Use the IADsExtension::PrivateGetIDsOfNames method to obtain the dispatch identifier.
		/// </param>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="lcid">
		/// The locale context in which to interpret arguments. The IADsExtension::PrivateGetIDsOfNames function uses <c>lcid</c>. It is also
		/// passed to the <c>PrivateInvoke</c> method to allow the object to interpret the arguments that are specific to a locale.
		/// </param>
		/// <param name="wFlags">
		/// <para>Flags that describe the context of the <c>PrivateInvoke</c> call, include.</para>
		/// <para>DISPATCH_METHOD</para>
		/// <para>
		/// The member is invoked as a method. If a property has the same name, both this and the <c>DISPATCH_PROPERTYGET</c> flag may be set.
		/// </para>
		/// <para>DISPATCH_PROPERTYGET</para>
		/// <para>The member is retrieved as a property or data member.</para>
		/// <para>DISPATCH_PROPERTYPUT</para>
		/// <para>The member is changed as a property or data member.</para>
		/// <para>DISPATCH_PROPERTYPUTREF</para>
		/// <para>
		/// The member is changed by a reference assignment, rather than a value assignment. This flag is valid only when the property
		/// accepts a reference to an object.
		/// </para>
		/// </param>
		/// <param name="pdispparams">
		/// Pointer to a DISPPARAMS structure that receives an array of arguments, an array of argument DISPIDs for named arguments, and
		/// counts for the number of elements in the arrays.
		/// </param>
		/// <param name="pvarResult">
		/// Pointer to the location where the result is to be stored, or <c>NULL</c> if the caller expects no result. This argument is
		/// ignored if <c>DISPATCH_PROPERTYPUT</c> or <c>DISPATCH_PROPERTYPUTREF</c> is specified.
		/// </param>
		/// <param name="pexcepinfo">
		/// Pointer to a structure that contains exception data. This structure should be filled in if <c>DISP_E_EXCEPTION</c> is returned.
		/// Can be <c>NULL</c>.
		/// </param>
		/// <param name="puArgErr">
		/// The index within the <c>rgvarg</c> member of the DISPPARAMS structure in <c>pdispparams</c> for the first argument that has an
		/// error. Arguments are stored in the <c>rgvarg</c> array in reverse order, so the first argument is the one with the highest index
		/// in the array. This parameter is returned only when the resulting return value is <c>DISP_E_TYPEMISMATCH</c> or <c>DISP_E_PARAMNOTFOUND</c>.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/iads/nf-iads-iadsextension-privateinvoke HRESULT PrivateInvoke( [in] DISPID
		// dispidMember, [in] REFIID riid, [in] LCID lcid, [in] WORD wFlags, [in] DISPPARAMS *pdispparams, [out] VARIANT *pvarResult, [out]
		// EXCEPINFO *pexcepinfo, [out] unsigned int *puArgErr );
		void PrivateInvoke([In] int dispidMember, [In] in Guid riid, [In] LCID lcid, [In] DispInvokeFlags wFlags, in System.Runtime.InteropServices.ComTypes.DISPPARAMS pdispparams,
			[MarshalAs(UnmanagedType.Struct)] out object? pvarResult, out System.Runtime.InteropServices.ComTypes.EXCEPINFO pexcepinfo, out uint puArgErr);
	}

	/// <summary>
	/// <para>The <c>IADsFaxNumber</c> interface provides methods for an ADSI client to access the Facsimile Telephone Number attribute.</para>
	/// <para>You can call the property methods of this interface to obtain and modify the attribute.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsfaxnumber
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsFaxNumber")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("A910DEA9-4680-11D1-A3B4-00C04FB950DC"), CoClass(typeof(FaxNumber))]
	public interface IADsFaxNumber
	{
		/// <summary>Gets or sets the telephone number of the fax machine.</summary>
		/// <value>The telephone number of the fax machine.</value>
		[DispId(2)]
		string TelephoneNumber
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(2)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the parameters for the fax machine.</summary>
		/// <value>The parameters for the fax machine.</value>
		[DispId(3)]
		object Parameters
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
	/// The <c>IADsFileService</c> interface is a dual interface that inherits from IADsService. It is designed for representing file
	/// services supported in the directory service. Through this interface you can discover and modify the maximum number of users
	/// simultaneously running a file service.
	/// </para>
	/// <para>
	/// To access active sessions or open resources used by the file service, you must go through the IADsFileServiceOperations interface to
	/// retrieve sessions or resources.
	/// </para>
	/// <para>
	/// To examine the status of the file service or to perform service management operations, you use the IADsServiceOperations interface,
	/// which is inherited by IADsFileServiceOperations.
	/// </para>
	/// </summary>
	/// <remarks>Under the WinNT provider, this interface is implemented on the <c>WinNTService</c> object.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/iads/nn-iads-iadsfileservice
	[PInvokeData("iads.h", MSDNShortId = "NN:iads.IADsFileService")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("A89D1900-31CA-11CF-A98A-00AA006BC149")]
	public interface IADsFileService : IADsService
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
		new string HostComputer
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
		new string DisplayName
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
		new string Version
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
		new ADS_SERVICE_TYPE ServiceType
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
		new ADS_SERVICE_START StartType
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
		new string Path
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
		new string StartupParameters
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
		new ADS_SERVICE_ERR ErrorControl
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
		new string LoadOrderGroup
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
		new string ServiceAccountName
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
		new string ServiceAccountPath
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
		new object Dependencies
		{
			[DispId(26)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(26)]
			[param: In, MarshalAs(UnmanagedType.Struct)]
			set;
		}

		/// <summary>Gets or sets the description of the file service.</summary>
		/// <value>The description of the file service.</value>
		[DispId(33)]
		string Description
		{
			[DispId(33)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(33)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Gets or sets the maximum number of users allowed on the service at any time.</summary>
		/// <value>The maximum number of users allowed on the service at any time.</value>
		[DispId(34)]
		int MaxUserCount
		{
			[DispId(34)]
			get;
			[DispId(34)]
			[param: In]
			set;
		}
	}
}