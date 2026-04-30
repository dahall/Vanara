#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Collections;

namespace Vanara.PInvoke;

/// <summary>Contains the <see cref="IAzApplication"/>, <see cref="IAzApplication2"/>, and <see cref="IAzApplication3"/> interfaces.</summary>
public static partial class AzRoles
{
	/// <summary>Contains information about a Business Rule (BizRule) operation.</summary>
	/// <remarks>The <c>IAzClientContext::AccessCheck</c> method creates an <b>AzBizRuleContext</b> object before it calls a BizRule script.</remarks>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazbizrulecontext
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzBizRuleContext")]
	[ComImport, Guid("E192F17D-D59F-455E-A152-940316CD77B2"), CoClass(typeof(AzBizRuleContext))]
	public interface IAzBizRuleContext
	{
		/// <summary>
		/// <para>
		/// The <b>BusinessRuleResult</b> property sets a value that indicates whether the Business Rule (BizRule) allows the user to perform
		/// the requested task.
		/// </para>
		/// <para>This property is write-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazbizrulecontext-put_businessruleresult HRESULT
		// put_BusinessRuleResult( BOOL bResult );
		[DispId(1610743808)]
		bool BusinessRuleResult
		{
			[DispId(1610743808)]
			[param: In, MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>The <b>BusinessRuleString</b> property sets or retrieves an application-specific string for the Business Rule (BizRule).</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This property is returned to the application that called the <c>IAzClientContext::AccessCheck</c> method. One possible use of
		/// this property is to explain the reason that the BizRule denied access to the user.
		/// </para>
		/// <para>The maximum length of this property is 65,536 characters.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazbizrulecontext-put_businessrulestring HRESULT
		// put_BusinessRuleString( BSTR bstrBusinessRuleString );
		[DispId(1610743809)]
		string BusinessRuleString
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743809)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// The <b>GetParameter</b> method gets the specified value from the <i>varParameterValues</i> parameter of the
		/// <c>IAzClientContext::AccessCheck</c> method.
		/// </summary>
		/// <param name="bstrParameterName">
		/// <para>
		/// Name of the value to return. The name must match the name in one of the elements in the array passed into the
		/// <i>varParameterNames</i> parameter of the <c>AccessCheck</c> method.
		/// </para>
		/// <para>
		/// <b>Important</b>  Users of VBScript must be aware that the comparison between this parameter and the names in the
		/// <i>varParameterNames</i> parameter is case sensitive.
		/// </para>
		/// <para></para>
		/// </param>
		/// <returns>
		/// Parameter value from the <i>varParameterValues</i> parameter of the <c>AccessCheck</c> method that corresponds to the name
		/// specified by the <i>bstrParameterName</i> parameter, if found; otherwise, <b>NULL</b>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazbizrulecontext-getparameter HRESULT GetParameter( [in]
		// BSTR bstrParameterName, [out] VARIANT *pvarParameterValue );
		[DispId(1610743811)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object? GetParameter([In, MarshalAs(UnmanagedType.BStr)] string bstrParameterName);
	}

	/// <summary>
	/// Provides methods and properties used to manage a list of IDispatch interfaces that can be called by business rule (BizRule) scripts.
	/// </summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazbizruleinterfaces
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzBizRuleInterfaces")]
	[ComImport, Guid("E94128C7-E9DA-44CC-B0BD-53036F3AAB3D")]
	public interface IAzBizRuleInterfaces
	{
		/// <summary>
		/// The <b>AddInterface</b> method adds the specified interface to the list of <c>IDispatch</c> interfaces that can be called by
		/// business rule (BizRule) scripts. To add the specified interface, AzMan calls the <c>AddNamedItem</c> method of the
		/// <c>IActiveScript</c> interface.
		/// </summary>
		/// <param name="bstrInterfaceName">
		/// A string that contains the name used by scripts to call the interface specified by the <i>varInterface</i> parameter.
		/// </param>
		/// <param name="lInterfaceFlag">
		/// Flags sent to the <c>AddNamedItem</c> method of the <c>IActiveScript</c> interface. The <b>AddNamedItem</b> always behaves as if
		/// the <b>SCRIPTITEM_ISVISIBLE</b> flag is set, and the <b>SCRIPTITEM_ISPERSISTENT</b> flag is not set.
		/// </param>
		/// <param name="varInterface">The ID of the interface to be added.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazbizruleinterfaces-addinterface HRESULT AddInterface(
		// [in] BSTR bstrInterfaceName, [in] LONG lInterfaceFlag, [in] VARIANT varInterface );
		[DispId(1610743808)]
		void AddInterface([In, MarshalAs(UnmanagedType.BStr)] string bstrInterfaceName, [In] AZ_PROP_CONSTANTS lInterfaceFlag, [In, MarshalAs(UnmanagedType.Struct)] object varInterface);

		/// <summary>
		/// The <b>AddInterfaces</b> method adds the specified interfaces to the list of <c>IDispatch</c> interfaces that can be called by
		/// business rule (BizRule) scripts. To add the specified interfaces, AzMan calls the <c>AddNamedItem</c> method of the
		/// <c>IActiveScript</c> interface once for each specified interface.
		/// </summary>
		/// <param name="varInterfaceNames">
		/// A <c>SAFEARRAY</c> that specifies the names that scripts use to call the interfaces specified by the <i>varInterfaces</i> array.
		/// </param>
		/// <param name="varInterfaceFlags">
		/// A <c>SAFEARRAY</c> that specifies flags sent to the <c>AddNamedItem</c> method of the <c>IActiveScript</c> interface. The
		/// <b>AddNamedItem</b> always behaves as if the <b>SCRIPTITEM_ISVISIBLE</b> flag is set, and the <b>SCRIPTITEM_ISPERSISTENT</b> flag
		/// is not set.
		/// </param>
		/// <param name="varInterfaces">A <c>SAFEARRAY</c> that specifies the IDs of the interfaces to be added.</param>
		/// <remarks>
		/// The names of the interfaces specified by the <i>varInterfaceNames</i> array are in the same order as the corresponding interface
		/// IDs specified by the <i>varInterfaces</i> array.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazbizruleinterfaces-addinterfaces HRESULT AddInterfaces(
		// [in] VARIANT varInterfaceNames, [in] VARIANT varInterfaceFlags, [in] VARIANT varInterfaces );
		[DispId(1610743809)]
		void AddInterfaces([In, MarshalAs(UnmanagedType.Struct)] object varInterfaceNames, [In, MarshalAs(UnmanagedType.Struct)] object varInterfaceFlags, [In, MarshalAs(UnmanagedType.Struct)] object varInterfaces);

		/// <summary>
		/// The <b>GetInterfaceValue</b> method gets the ID and flags of the interface that corresponds to the specified interface name.
		/// </summary>
		/// <param name="bstrInterfaceName">A string that contains the interface name.</param>
		/// <param name="lInterfaceFlag">A pointer to the flags associated with the interface name.</param>
		/// <param name="varInterface">A pointer to the ID associated with the interface name.</param>
		// https://learn.microsoft.com/is-is/windows/win32/api/azroles/nf-azroles-iazbizruleinterfaces-getinterfacevalue HRESULT
		// GetInterfaceValue( [in] BSTR bstrInterfaceName, [out] LONG *lInterfaceFlag, [out] VARIANT *varInterface );
		[DispId(1610743810)]
		void GetInterfaceValue([In, MarshalAs(UnmanagedType.BStr)] string bstrInterfaceName, out AZ_PROP_CONSTANTS lInterfaceFlag, [MarshalAs(UnmanagedType.Struct)] out object varInterface);

		/// <summary>
		/// The <b>Remove</b> method removes the specified interface from the list of interfaces The number of interfaces in the list of
		/// interfaces that can be called by BizRule scripts.
		/// </summary>
		/// <param name="bstrInterfaceName">The name of the interface to remove.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazbizruleinterfaces-remove HRESULT Remove( [in] BSTR
		// bstrInterfaceName );
		[DispId(1610743811)]
		void Remove([In, MarshalAs(UnmanagedType.BStr)] string bstrInterfaceName);

		/// <summary>
		/// The <b>RemoveAll</b> method removes all interfaces from the list of interfaces that can be called by business rule (BizRule) scripts.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazbizruleinterfaces-removeall?view=vs-2019 HRESULT RemoveAll();
		[DispId(1610743812)]
		void RemoveAll();

		/// <summary>
		/// <para>The <b>Count</b> property specifies the number of interfaces that can be called by business rule (BizRule) scripts.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazbizruleinterfaces-get_count HRESULT get_Count( unsigned
		// long *plCount );
		[DispId(1610743813)]
		uint Count
		{
			[DispId(1610743813)]
			get;
		}
	}

	/// <summary>Provides methods and properties used to manage a list of parameters that can be passed to business rule (BizRule) scripts.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazbizruleparameters
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzBizRuleParameters")]
	[ComImport, Guid("FC17685F-E25D-4DCD-BAE1-276EC9533CB5")]
	public interface IAzBizRuleParameters
	{
		/// <summary>The <b>AddParameter</b> method adds a parameter to the list of parameters available to business rule (BizRule) scripts.</summary>
		/// <param name="bstrParameterName">A string that contains the parameter name.</param>
		/// <param name="varParameterValue">The data type of the parameter value.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazbizruleparameters-addparameter HRESULT AddParameter(
		// [in] BSTR bstrParameterName, [in] VARIANT varParameterValue );
		[DispId(1610743808)]
		void AddParameter([In, MarshalAs(UnmanagedType.BStr)] string bstrParameterName, [In, MarshalAs(UnmanagedType.Struct)] object varParameterValue);

		/// <summary>The <b>AddParameters</b> method adds parameters to the list of parameters available to business rule (BizRule) scripts.</summary>
		/// <param name="varParameterNames">
		/// The parameter names. This is a variant that contains either a <c>SAFEARRAY</c> or the JScript <c>Array</c> object. Each element
		/// of the array holds a <b>VT_BSTR</b> that contains a parameter name. This array must be sorted alphabetically; the sort order is
		/// as defined by a case-sensitive <c>VarCmp</c>. The order of the <i>varParameterValues</i> array must match the order of this array.
		/// </param>
		/// <param name="varParameterValues">
		/// The values of the parameters that are available to BizRule scripts. This is a variant that contains either a <c>SAFEARRAY</c> or
		/// the JScript <c>Array</c> object. Each element of the array holds a value that corresponds to an element in the
		/// <i>varParameterNames</i> array. The default value is <b>VT_NULL</b>. The entries in the array can hold any type except
		/// <b>VT_UNKNOWN</b> and <b>VT_DISPATCH</b>.
		/// </param>
		// https://learn.microsoft.com/nb-no/windows/win32/api/azroles/nf-azroles-iazbizruleparameters-addparameters HRESULT AddParameters(
		// [in] VARIANT varParameterNames, [in] VARIANT varParameterValues );
		[DispId(1610743809)]
		void AddParameters([In, MarshalAs(UnmanagedType.Struct)] object varParameterNames, [In, MarshalAs(UnmanagedType.Struct)] object varParameterValues);

		/// <summary>
		/// The <b>GetParameterValue</b> method gets the value type of the business rule (BizRule) parameter with the specified name.
		/// </summary>
		/// <param name="bstrParameterName">A string that contains the parameter name.</param>
		/// <returns>A pointer to the data type of the parameter value.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazbizruleparameters-getparametervalue HRESULT
		// GetParameterValue( [in] BSTR bstrParameterName, [out] VARIANT *pvarParameterValue );
		[DispId(1610743810)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetParameterValue([In, MarshalAs(UnmanagedType.BStr)] string bstrParameterName);

		/// <summary>
		/// The <b>Remove</b> method removes the specified parameter from the list of parameters available to business rule (BizRule) scripts.
		/// </summary>
		/// <param name="varParameterName">The name of the parameter to remove.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazbizruleparameters-remove HRESULT Remove( [in] BSTR
		// varParameterName );
		[DispId(1610743811)]
		void Remove([In, MarshalAs(UnmanagedType.BStr)] string varParameterName);

		/// <summary>
		/// The <b>IAzBizRuleParameters::RemoveAll</b> method removes all parameters from the list of parameters available to business rule
		/// (BizRule) scripts.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazbizruleparameters-removeall HRESULT RemoveAll();
		[DispId(1610743812)]
		void RemoveAll();

		/// <summary>
		/// <para>The <b>Count</b> property gets the number of parameters available to business rule (BizRule) scripts.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazbizruleparameters-get_count HRESULT get_Count( unsigned
		// long *plCount );
		[DispId(1610743813)]
		uint Count
		{
			[DispId(1610743813)]
			get;
		}
	}

	/// <summary>Maintains the state that describes a particular client.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazclientcontext
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzClientContext")]
	[ComImport, Guid("EFF1F00B-488A-466D-AFD9-A401C5F9EEF5")]
	public interface IAzClientContext
	{
		/// <summary>The AccessCheck method determines whether the current client context is allowed to perform the specified operations.</summary>
		/// <param name="bstrObjectName">The name of the accessed object. This string is used in audits.</param>
		/// <param name="varScopeNames">
		/// A variant that contains either a SAFEARRAY or the JScript Array object. Each element of the array holds a VT_BSTR that contains
		/// the name of a scope that the object specified by the bstrObjectName parameter matches. The array can contain only one element. To
		/// use the default application level scope, set the first entry in the array to an empty string ("") or VT_EMPTY, or pass VT_EMPTY
		/// in to this parameter.
		/// </param>
		/// <param name="varOperations">
		/// The operations for which access by the client context is checked. This is a variant that contains either a SAFEARRAY or the
		/// JScript Array object. Each element of the array holds a VT_I2 or VT_I4 that represents the OperationID property of an
		/// IAzOperation object in the IAzApplication policy.
		/// </param>
		/// <param name="varParameterNames">
		/// The names of the parameters available to business rules (BizRules) through the AzBizRuleContext::GetParameter method. This is a
		/// variant that contains either a SAFEARRAY or the JScript Array object. Each element of the array holds a VT_BSTR that contains a
		/// parameter name. This array must be sorted alphabetically by the caller; the sort order is as defined by a case-sensitive VarCmp.
		/// The order of the varParameterValues array must match the order of this array. The default value is VT_NULL.
		/// </param>
		/// <param name="varParameterValues">
		/// The values of the parameters that are available to business rules (BizRules) through the AzBizRuleContext::GetParameter method.
		/// This is a variant that contains either a SAFEARRAY or the JScript Array object. Each element of the array holds a value that
		/// corresponds to an element in the varParameterNames array. The default value is VT_NULL. The entries in the array can hold any
		/// type except VT_UNKNOWN and VT_DISPATCH.
		/// </param>
		/// <param name="varInterfaceNames">
		/// The names by which the interfaces in the varInterfaces array will be known in a BizRule script. This is a variant that contains
		/// either a SAFEARRAY or the JScript Array object. Each element of the array holds a string variant that contains an interface name.
		/// This method calls the IActiveScript::AddNamedItem method for each entry in the array. The default value is VT_NULL.
		/// </param>
		/// <param name="varInterfaceFlags">
		/// Flags that will be passed in the call to IActiveScript::AddNamedItem. This is a variant that contains either a SAFEARRAY or the
		/// JScript Array object. Each element of the array holds a VT_I4. The SCRIPTITEM_ISVISIBLE flag is implied; the
		/// SCRIPTITEM_ISPERSISTENT flag is ignored. Each entry in the array must match the corresponding element in the varInterfaceNames
		/// array. The default value is VT_NULL.
		/// </param>
		/// <param name="varInterfaces">
		/// The IDispatch interfaces that will be made available to the BizRule script. This is a variant that contains either a SAFEARRAY or
		/// the JScript Array object. Each element of the array holds an IDispatch interface. Each entry in the array must match the
		/// corresponding element in the varInterfaceNames array. The default value is VT_NULL.
		/// </param>
		/// <returns>
		/// A pointer to a VARIANT used to return a SAFEARRAY that contains the results of the access check. Each element of the SAFEARRAY is
		/// a VARIANT of type VT_I4. Each entry in the array matches the corresponding element in the varOperations array. If access to an
		/// operation is granted to the client context, a value of NO_ERROR is returned in the corresponding element in the pvarResults
		/// array. Any other value indicates that access to that operation is not granted. A typical value that indicates failure is ERROR_ACCESS_DENIED.
		/// </returns>
		[DispId(1610743808)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object AccessCheck([In, MarshalAs(UnmanagedType.BStr)] string bstrObjectName, [In, MarshalAs(UnmanagedType.Struct)] object varScopeNames, [In, MarshalAs(UnmanagedType.Struct)] object varOperations, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varParameterNames, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varParameterValues, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varInterfaceNames, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varInterfaceFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varInterfaces);

		/// <summary>The <b>GetBusinessRuleString</b> method returns the application-specific string for the business rule (BizRule).</summary>
		/// <returns>String that contains information about the BizRule. The format and contents of the string are defined by the application.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-getbusinessrulestring HRESULT
		// GetBusinessRuleString( [out] BSTR *pbstrBusinessRuleString );
		[DispId(1610743809)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetBusinessRuleString();

		/// <summary>
		/// <para>The <b>UserDn</b> property retrieves the name of the current client in distinguished name (DN) format.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The DN client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameFullyQualifiedDN</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in DN format is "CN=Ben Smith, OU=Software, OU=Example, O=FourthCoffee, C=US".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_userdn HRESULT get_UserDn( BSTR
		// *pbstrProp );
		[DispId(1610743810)]
		string UserDn
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>UserSamCompat</b> property retrieves the name of the current client in a format compatible with
		/// Windows Security Account Manager (SAM).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The SAM-compatible client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameSamCompatible</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in SAM-compatible format is "ExampleDomain\UserName".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_usersamcompat HRESULT
		// get_UserSamCompat( BSTR *pbstrProp );
		[DispId(1610743811)]
		string UserSamCompat
		{
			[DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>The <b>UserDisplay</b> property retrieves the name of the current client in user display name format.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The user display client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameCanonical</b> specified for the <i>NameDisplay</i> parameter.
		/// </para>
		/// <para>An example of a client name in user display name format is "Ben Smith".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_userdisplay HRESULT get_UserDisplay(
		// BSTR *pbstrProp );
		[DispId(1610743812)]
		string UserDisplay
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>The <b>UserGuid</b> property retrieves the name of the current client in GUID format.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The GUID client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameUniqueId</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in GUID format is "{4fa050f0-f561-11cf-bdd9-00aa003a77b6}Ben Smith".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_userguid HRESULT get_UserGuid( BSTR
		// *pbstrProp );
		[DispId(1610743813)]
		string UserGuid
		{
			[DispId(1610743813)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>The <b>UserCanonical</b> property retrieves the name of the current client in canonical format.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The canonical client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameCanonical</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in canonical format is "example.fourthcoffee.com/software/Ben Smith".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_usercanonical HRESULT
		// get_UserCanonical( BSTR *pbstrProp );
		[DispId(1610743814)]
		string UserCanonical
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>The <b>UserUpn</b> property retrieves the name of the current client in user principal name (UPN) format.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The UPN client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameUserPrincipal</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in UPN format is "someone@example.com".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_userupn HRESULT get_UserUpn( BSTR
		// *pbstrProp );
		[DispId(1610743815)]
		string UserUpn
		{
			[DispId(1610743815)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>UserDnsSamCompat</b> property retrieves the name of the current client in a DNS format compatible with
		/// Windows Security Account Manager (SAM).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The SAM-compatible DNS client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function
		/// with <b>NameDnsDomain</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in SAM-compatible DNS format is "example.fourthcoffee.com\Username".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_userdnssamcompat HRESULT
		// get_UserDnsSamCompat( BSTR *pbstrProp );
		[DispId(1610743816)]
		string UserDnsSamCompat
		{
			[DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The GetProperty method returns the IAzClientContext object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the IAzClientContext object property to return. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AZ_PROP_CHILD_CREATE</term>
		/// <description>
		/// Determines whether the current user has permission to create child objects. This value will always be FALSE because this object
		/// cannot have child objects.
		/// </description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_ROLE_FOR_ACCESS_CHECK</term>
		/// <description>Also accessed through the RoleForAccessCheck property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_CANONICAL</term>
		/// <description>Also accessed through the UserCanonical property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_DISPLAY</term>
		/// <description>Also accessed through the UserDisplay property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_DN</term>
		/// <description>Also accessed through the UserDn property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_DNS_SAM_COMPAT</term>
		/// <description>Also accessed through the UserDnsSamCompat property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_GUID</term>
		/// <description>Also accessed through the UserGuid property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_SAM_COMPAT</term>
		/// <description>Also accessed through the UserSamCompat property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_UPN</term>
		/// <description>Also accessed through the UserUpn property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to the returned IAzClientContext object property.</returns>
		[DispId(1610743817)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>GetRoles</b> method returns the roles for the client context.</summary>
		/// <param name="bstrScopeName">
		/// Name of the <c>IAzScope</c> object from which the roles returned in the <i>pvarRoleNames</i> parameter are applicable. If this
		/// property is <b>NULL</b>, the roles from the application scope are returned; otherwise, the roles from the specified scope are
		/// returned instead of the roles from the application scope.
		/// </param>
		/// <returns>
		/// A pointer to a <b>VARIANT</b> used to return a <c>SAFEARRAY</c>. Each element of the <b>SAFEARRAY</b> is a <b>VARIANT</b> of type
		/// <b>BSTR</b> that contains the name of a role to which the client belongs at the scope specified by the <i>bstrScopeName</i> parameter.
		/// </returns>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-getroles HRESULT GetRoles( [in, optional]
		// BSTR bstrScopeName, [out] VARIANT *pvarRoleNames );
		[DispId(1610743818)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetRoles([In, MarshalAs(UnmanagedType.BStr)] string? bstrScopeName = null);

		/// <summary>
		/// <para>The <b>RoleForAccessCheck</b> property sets or retrieves the role that is used to perform the access check.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// If this property is set, the role specified by this property will be the only role used in the access check; otherwise, all roles
		/// contained in the context will be used.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-put_roleforaccesscheck HRESULT
		// put_RoleForAccessCheck( BSTR bstrProp );
		[DispId(1610743819)]
		string RoleForAccessCheck
		{
			[DispId(1610743819)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743819)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}
	}

	/// <summary>Inherits from the IAzClientContext interface and implements new methods that manipulate the client context.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazclientcontext2
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzClientContext2")]
	[ComImport, Guid("2B0C92B8-208A-488A-8F81-E4EDB22111CD")]
	public interface IAzClientContext2 : IAzClientContext
	{
		/// <summary>The AccessCheck method determines whether the current client context is allowed to perform the specified operations.</summary>
		/// <param name="bstrObjectName">The name of the accessed object. This string is used in audits.</param>
		/// <param name="varScopeNames">
		/// A variant that contains either a SAFEARRAY or the JScript Array object. Each element of the array holds a VT_BSTR that contains
		/// the name of a scope that the object specified by the bstrObjectName parameter matches. The array can contain only one element. To
		/// use the default application level scope, set the first entry in the array to an empty string ("") or VT_EMPTY, or pass VT_EMPTY
		/// in to this parameter.
		/// </param>
		/// <param name="varOperations">
		/// The operations for which access by the client context is checked. This is a variant that contains either a SAFEARRAY or the
		/// JScript Array object. Each element of the array holds a VT_I2 or VT_I4 that represents the OperationID property of an
		/// IAzOperation object in the IAzApplication policy.
		/// </param>
		/// <param name="varParameterNames">
		/// The names of the parameters available to business rules (BizRules) through the AzBizRuleContext::GetParameter method. This is a
		/// variant that contains either a SAFEARRAY or the JScript Array object. Each element of the array holds a VT_BSTR that contains a
		/// parameter name. This array must be sorted alphabetically by the caller; the sort order is as defined by a case-sensitive VarCmp.
		/// The order of the varParameterValues array must match the order of this array. The default value is VT_NULL.
		/// </param>
		/// <param name="varParameterValues">
		/// The values of the parameters that are available to business rules (BizRules) through the AzBizRuleContext::GetParameter method.
		/// This is a variant that contains either a SAFEARRAY or the JScript Array object. Each element of the array holds a value that
		/// corresponds to an element in the varParameterNames array. The default value is VT_NULL. The entries in the array can hold any
		/// type except VT_UNKNOWN and VT_DISPATCH.
		/// </param>
		/// <param name="varInterfaceNames">
		/// The names by which the interfaces in the varInterfaces array will be known in a BizRule script. This is a variant that contains
		/// either a SAFEARRAY or the JScript Array object. Each element of the array holds a string variant that contains an interface name.
		/// This method calls the IActiveScript::AddNamedItem method for each entry in the array. The default value is VT_NULL.
		/// </param>
		/// <param name="varInterfaceFlags">
		/// Flags that will be passed in the call to IActiveScript::AddNamedItem. This is a variant that contains either a SAFEARRAY or the
		/// JScript Array object. Each element of the array holds a VT_I4. The SCRIPTITEM_ISVISIBLE flag is implied; the
		/// SCRIPTITEM_ISPERSISTENT flag is ignored. Each entry in the array must match the corresponding element in the varInterfaceNames
		/// array. The default value is VT_NULL.
		/// </param>
		/// <param name="varInterfaces">
		/// The IDispatch interfaces that will be made available to the BizRule script. This is a variant that contains either a SAFEARRAY or
		/// the JScript Array object. Each element of the array holds an IDispatch interface. Each entry in the array must match the
		/// corresponding element in the varInterfaceNames array. The default value is VT_NULL.
		/// </param>
		/// <returns>
		/// A pointer to a VARIANT used to return a SAFEARRAY that contains the results of the access check. Each element of the SAFEARRAY is
		/// a VARIANT of type VT_I4. Each entry in the array matches the corresponding element in the varOperations array. If access to an
		/// operation is granted to the client context, a value of NO_ERROR is returned in the corresponding element in the pvarResults
		/// array. Any other value indicates that access to that operation is not granted. A typical value that indicates failure is ERROR_ACCESS_DENIED.
		/// </returns>
		[DispId(1610743808)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object AccessCheck([In, MarshalAs(UnmanagedType.BStr)] string bstrObjectName, [In, MarshalAs(UnmanagedType.Struct)] object varScopeNames, [In, MarshalAs(UnmanagedType.Struct)] object varOperations, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varParameterNames, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varParameterValues, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varInterfaceNames, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varInterfaceFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varInterfaces);

		/// <summary>The <b>GetBusinessRuleString</b> method returns the application-specific string for the business rule (BizRule).</summary>
		/// <returns>String that contains information about the BizRule. The format and contents of the string are defined by the application.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-getbusinessrulestring HRESULT
		// GetBusinessRuleString( [out] BSTR *pbstrBusinessRuleString );
		[DispId(1610743809)]
		[return: MarshalAs(UnmanagedType.BStr)]
		new string GetBusinessRuleString();

		/// <summary>
		/// <para>The <b>UserDn</b> property retrieves the name of the current client in distinguished name (DN) format.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The DN client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameFullyQualifiedDN</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in DN format is "CN=Ben Smith, OU=Software, OU=Example, O=FourthCoffee, C=US".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_userdn HRESULT get_UserDn( BSTR
		// *pbstrProp );
		[DispId(1610743810)]
		new string UserDn
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>UserSamCompat</b> property retrieves the name of the current client in a format compatible with
		/// Windows Security Account Manager (SAM).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The SAM-compatible client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameSamCompatible</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in SAM-compatible format is "ExampleDomain\UserName".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_usersamcompat HRESULT
		// get_UserSamCompat( BSTR *pbstrProp );
		[DispId(1610743811)]
		new string UserSamCompat
		{
			[DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>The <b>UserDisplay</b> property retrieves the name of the current client in user display name format.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The user display client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameCanonical</b> specified for the <i>NameDisplay</i> parameter.
		/// </para>
		/// <para>An example of a client name in user display name format is "Ben Smith".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_userdisplay HRESULT get_UserDisplay(
		// BSTR *pbstrProp );
		[DispId(1610743812)]
		new string UserDisplay
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>The <b>UserGuid</b> property retrieves the name of the current client in GUID format.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The GUID client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameUniqueId</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in GUID format is "{4fa050f0-f561-11cf-bdd9-00aa003a77b6}Ben Smith".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_userguid HRESULT get_UserGuid( BSTR
		// *pbstrProp );
		[DispId(1610743813)]
		new string UserGuid
		{
			[DispId(1610743813)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>The <b>UserCanonical</b> property retrieves the name of the current client in canonical format.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The canonical client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameCanonical</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in canonical format is "example.fourthcoffee.com/software/Ben Smith".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_usercanonical HRESULT
		// get_UserCanonical( BSTR *pbstrProp );
		[DispId(1610743814)]
		new string UserCanonical
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>The <b>UserUpn</b> property retrieves the name of the current client in user principal name (UPN) format.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The UPN client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameUserPrincipal</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in UPN format is "someone@example.com".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_userupn HRESULT get_UserUpn( BSTR
		// *pbstrProp );
		[DispId(1610743815)]
		new string UserUpn
		{
			[DispId(1610743815)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>UserDnsSamCompat</b> property retrieves the name of the current client in a DNS format compatible with
		/// Windows Security Account Manager (SAM).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The SAM-compatible DNS client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function
		/// with <b>NameDnsDomain</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in SAM-compatible DNS format is "example.fourthcoffee.com\Username".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_userdnssamcompat HRESULT
		// get_UserDnsSamCompat( BSTR *pbstrProp );
		[DispId(1610743816)]
		new string UserDnsSamCompat
		{
			[DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The GetProperty method returns the IAzClientContext object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the IAzClientContext object property to return. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AZ_PROP_CHILD_CREATE</term>
		/// <description>
		/// Determines whether the current user has permission to create child objects. This value will always be FALSE because this object
		/// cannot have child objects.
		/// </description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_ROLE_FOR_ACCESS_CHECK</term>
		/// <description>Also accessed through the RoleForAccessCheck property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_CANONICAL</term>
		/// <description>Also accessed through the UserCanonical property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_DISPLAY</term>
		/// <description>Also accessed through the UserDisplay property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_DN</term>
		/// <description>Also accessed through the UserDn property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_DNS_SAM_COMPAT</term>
		/// <description>Also accessed through the UserDnsSamCompat property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_GUID</term>
		/// <description>Also accessed through the UserGuid property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_SAM_COMPAT</term>
		/// <description>Also accessed through the UserSamCompat property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_UPN</term>
		/// <description>Also accessed through the UserUpn property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to the returned IAzClientContext object property.</returns>
		[DispId(1610743817)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>GetRoles</b> method returns the roles for the client context.</summary>
		/// <param name="bstrScopeName">
		/// Name of the <c>IAzScope</c> object from which the roles returned in the <i>pvarRoleNames</i> parameter are applicable. If this
		/// property is <b>NULL</b>, the roles from the application scope are returned; otherwise, the roles from the specified scope are
		/// returned instead of the roles from the application scope.
		/// </param>
		/// <returns>
		/// A pointer to a <b>VARIANT</b> used to return a <c>SAFEARRAY</c>. Each element of the <b>SAFEARRAY</b> is a <b>VARIANT</b> of type
		/// <b>BSTR</b> that contains the name of a role to which the client belongs at the scope specified by the <i>bstrScopeName</i> parameter.
		/// </returns>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-getroles HRESULT GetRoles( [in, optional]
		// BSTR bstrScopeName, [out] VARIANT *pvarRoleNames );
		[DispId(1610743818)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object GetRoles([In, MarshalAs(UnmanagedType.BStr)] string? bstrScopeName = null);

		/// <summary>
		/// <para>The <b>RoleForAccessCheck</b> property sets or retrieves the role that is used to perform the access check.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// If this property is set, the role specified by this property will be the only role used in the access check; otherwise, all roles
		/// contained in the context will be used.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-put_roleforaccesscheck HRESULT
		// put_RoleForAccessCheck( BSTR bstrProp );
		[DispId(1610743819)]
		new string RoleForAccessCheck
		{
			[DispId(1610743819)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743819)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// The <b>GetAssignedScopesPage</b> method retrieves a list of the scopes in which the client represented by the current
		/// <c>IAzClientContext2</c> object is assigned to at least one role.
		/// </summary>
		/// <param name="lOptions">
		/// <para>
		/// A flag that specifies whether this method checks LDAP query groups for scope assignment. Previously cached LDAP query groups are
		/// checked regardless of the value of this flag.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_CLIENT_CONTEXT_SKIP_LDAP_QUERY</b> 1</description>
		/// <description>LDAP query groups that were not previously cached are not checked.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="PageSize">The number of elements in each page result.</param>
		/// <param name="pvarCursor">
		/// A pointer to a <b>VARIANT</b> that represents the current page of results. For the first call to the <b>GetAssignedScopesPage</b>
		/// method, pass <b>VT_EMPTY</b> as the value for this parameter to retrieve the first page of results. The number of elements on a
		/// page is determined by the value of the <i>PageSize</i> parameter. On output, this parameter contains the value to be passed in
		/// the next call to <b>GetAssignedScopesPage</b> to retrieve the next page of results. If the value of this parameter on output is
		/// <b>EMPTY</b>, there are no more result pages.
		/// </param>
		/// <returns>
		/// On return, contains an array of variables of type <b>VARIANT</b>. Each element of the array is of type <b>VT_BSTR</b> and
		/// contains the name of a scope to which the current client is assigned. The number of elements in the array is specified by the
		/// <i>PageSize</i> parameter.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If multiple threads access the same authorization store, a call to the <b>GetAssignedScopesPage</b> method on one of the threads
		/// might not return accurate results if the other thread modifies the store.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> values must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext2-getassignedscopespage HRESULT
		// GetAssignedScopesPage( [in] LONG lOptions, [in] LONG PageSize, [in, out] VARIANT *pvarCursor, VARIANT *pvarScopeNames );
		[DispId(1610809344)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetAssignedScopesPage([In] AZ_PROP_CONSTANTS lOptions, [In] int PageSize, [In, Out, MarshalAs(UnmanagedType.Struct)] ref object pvarCursor);

		/// <summary>The <b>AddRoles</b> method adds the specified array of existing <c>IAzRole</c> objects to the client context.</summary>
		/// <param name="varRoles">The array of role names that specify the <c>IAzRole</c> objects to add to the client context.</param>
		/// <param name="bstrScopeName">The scope to which the array of roles applies.</param>
		/// <remarks>
		/// <para>The <c>IAzRole</c> objects associated with the names in the <i>varRoles</i> array must already exist in the specified scope.</para>
		/// <para>The added roles are used in subsequent calls to the <c>AccessCheck</c> and <c>GetRoles</c> methods.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext2-addroles HRESULT AddRoles( [in] VARIANT
		// varRoles, [in] BSTR bstrScopeName );
		[DispId(1610809345)]
		void AddRoles([In, MarshalAs(UnmanagedType.Struct)] object varRoles, [In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName);

		/// <summary>
		/// The <b>AddApplicationGroups</b> method adds the specified array of existing <c>IAzApplicationGroup</c> objects to the client
		/// context object.
		/// </summary>
		/// <param name="varApplicationGroups">The array of <c>IAzApplicationGroup</c> objects to add.</param>
		/// <remarks>
		/// <para>
		/// The <c>IAzApplicationGroup</c> objects in the <i>varApplicationGroups</i> array must already exist in the authorization store.
		/// </para>
		/// <para>The added roles are used in subsequent calls to the <c>AccessCheck</c> and <c>GetRoles</c> methods.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext2-addapplicationgroups HRESULT
		// AddApplicationGroups( [in] VARIANT varApplicationGroups );
		[DispId(1610809346)]
		void AddApplicationGroups([In, MarshalAs(UnmanagedType.Struct)] object varApplicationGroups);

		/// <summary>
		/// The <b>AddStringSids</b> method adds an array of string representations of <c>security identifiers</c> (SIDs) to the client context.
		/// </summary>
		/// <param name="varStringSids">The array of string representations of SIDs to add to the client context.</param>
		// https://learn.microsoft.com/sl-si/windows/win32/api/azroles/nf-azroles-iazclientcontext2-addstringsids HRESULT AddStringSids( [in]
		// VARIANT varStringSids );
		[DispId(1610809347)]
		void AddStringSids([In, MarshalAs(UnmanagedType.Struct)] object varStringSids);

		/// <summary>
		/// <para>
		/// The <b>LDAPQueryDN</b> property retrieves or sets the domain name of the directory object to be used during evaluation of LDAP
		/// query groups.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext2-put_ldapquerydn HRESULT put_LDAPQueryDN(
		// BSTR bstrLDAPQueryDN );
		[DispId(1610809348)]
		string LDAPQueryDN
		{
			[DispId(1610809348)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610809348)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}
	}

	/// <summary>Extends the IAzClientContext2 interface.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazclientcontext3
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzClientContext3")]
	[ComImport, Guid("11894FDE-1DEB-4B4B-8907-6D1CDA1F5D4F")]
	public interface IAzClientContext3 : IAzClientContext2
	{
		/// <summary>The AccessCheck method determines whether the current client context is allowed to perform the specified operations.</summary>
		/// <param name="bstrObjectName">The name of the accessed object. This string is used in audits.</param>
		/// <param name="varScopeNames">
		/// A variant that contains either a SAFEARRAY or the JScript Array object. Each element of the array holds a VT_BSTR that contains
		/// the name of a scope that the object specified by the bstrObjectName parameter matches. The array can contain only one element. To
		/// use the default application level scope, set the first entry in the array to an empty string ("") or VT_EMPTY, or pass VT_EMPTY
		/// in to this parameter.
		/// </param>
		/// <param name="varOperations">
		/// The operations for which access by the client context is checked. This is a variant that contains either a SAFEARRAY or the
		/// JScript Array object. Each element of the array holds a VT_I2 or VT_I4 that represents the OperationID property of an
		/// IAzOperation object in the IAzApplication policy.
		/// </param>
		/// <param name="varParameterNames">
		/// The names of the parameters available to business rules (BizRules) through the AzBizRuleContext::GetParameter method. This is a
		/// variant that contains either a SAFEARRAY or the JScript Array object. Each element of the array holds a VT_BSTR that contains a
		/// parameter name. This array must be sorted alphabetically by the caller; the sort order is as defined by a case-sensitive VarCmp.
		/// The order of the varParameterValues array must match the order of this array. The default value is VT_NULL.
		/// </param>
		/// <param name="varParameterValues">
		/// The values of the parameters that are available to business rules (BizRules) through the AzBizRuleContext::GetParameter method.
		/// This is a variant that contains either a SAFEARRAY or the JScript Array object. Each element of the array holds a value that
		/// corresponds to an element in the varParameterNames array. The default value is VT_NULL. The entries in the array can hold any
		/// type except VT_UNKNOWN and VT_DISPATCH.
		/// </param>
		/// <param name="varInterfaceNames">
		/// The names by which the interfaces in the varInterfaces array will be known in a BizRule script. This is a variant that contains
		/// either a SAFEARRAY or the JScript Array object. Each element of the array holds a string variant that contains an interface name.
		/// This method calls the IActiveScript::AddNamedItem method for each entry in the array. The default value is VT_NULL.
		/// </param>
		/// <param name="varInterfaceFlags">
		/// Flags that will be passed in the call to IActiveScript::AddNamedItem. This is a variant that contains either a SAFEARRAY or the
		/// JScript Array object. Each element of the array holds a VT_I4. The SCRIPTITEM_ISVISIBLE flag is implied; the
		/// SCRIPTITEM_ISPERSISTENT flag is ignored. Each entry in the array must match the corresponding element in the varInterfaceNames
		/// array. The default value is VT_NULL.
		/// </param>
		/// <param name="varInterfaces">
		/// The IDispatch interfaces that will be made available to the BizRule script. This is a variant that contains either a SAFEARRAY or
		/// the JScript Array object. Each element of the array holds an IDispatch interface. Each entry in the array must match the
		/// corresponding element in the varInterfaceNames array. The default value is VT_NULL.
		/// </param>
		/// <returns>
		/// A pointer to a VARIANT used to return a SAFEARRAY that contains the results of the access check. Each element of the SAFEARRAY is
		/// a VARIANT of type VT_I4. Each entry in the array matches the corresponding element in the varOperations array. If access to an
		/// operation is granted to the client context, a value of NO_ERROR is returned in the corresponding element in the pvarResults
		/// array. Any other value indicates that access to that operation is not granted. A typical value that indicates failure is ERROR_ACCESS_DENIED.
		/// </returns>
		[DispId(1610743808)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object AccessCheck([In, MarshalAs(UnmanagedType.BStr)] string bstrObjectName, [In, MarshalAs(UnmanagedType.Struct)] object varScopeNames, [In, MarshalAs(UnmanagedType.Struct)] object varOperations, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varParameterNames, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varParameterValues, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varInterfaceNames, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varInterfaceFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varInterfaces);

		/// <summary>The <b>GetBusinessRuleString</b> method returns the application-specific string for the business rule (BizRule).</summary>
		/// <returns>String that contains information about the BizRule. The format and contents of the string are defined by the application.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-getbusinessrulestring HRESULT
		// GetBusinessRuleString( [out] BSTR *pbstrBusinessRuleString );
		[DispId(1610743809)]
		[return: MarshalAs(UnmanagedType.BStr)]
		new string GetBusinessRuleString();

		/// <summary>
		/// <para>The <b>UserDn</b> property retrieves the name of the current client in distinguished name (DN) format.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The DN client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameFullyQualifiedDN</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in DN format is "CN=Ben Smith, OU=Software, OU=Example, O=FourthCoffee, C=US".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_userdn HRESULT get_UserDn( BSTR
		// *pbstrProp );
		[DispId(1610743810)]
		new string UserDn
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>UserSamCompat</b> property retrieves the name of the current client in a format compatible with
		/// Windows Security Account Manager (SAM).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The SAM-compatible client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameSamCompatible</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in SAM-compatible format is "ExampleDomain\UserName".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_usersamcompat HRESULT
		// get_UserSamCompat( BSTR *pbstrProp );
		[DispId(1610743811)]
		new string UserSamCompat
		{
			[DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>The <b>UserDisplay</b> property retrieves the name of the current client in user display name format.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The user display client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameCanonical</b> specified for the <i>NameDisplay</i> parameter.
		/// </para>
		/// <para>An example of a client name in user display name format is "Ben Smith".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_userdisplay HRESULT get_UserDisplay(
		// BSTR *pbstrProp );
		[DispId(1610743812)]
		new string UserDisplay
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>The <b>UserGuid</b> property retrieves the name of the current client in GUID format.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The GUID client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameUniqueId</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in GUID format is "{4fa050f0-f561-11cf-bdd9-00aa003a77b6}Ben Smith".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_userguid HRESULT get_UserGuid( BSTR
		// *pbstrProp );
		[DispId(1610743813)]
		new string UserGuid
		{
			[DispId(1610743813)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>The <b>UserCanonical</b> property retrieves the name of the current client in canonical format.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The canonical client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameCanonical</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in canonical format is "example.fourthcoffee.com/software/Ben Smith".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_usercanonical HRESULT
		// get_UserCanonical( BSTR *pbstrProp );
		[DispId(1610743814)]
		new string UserCanonical
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>The <b>UserUpn</b> property retrieves the name of the current client in user principal name (UPN) format.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The UPN client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function with
		/// <b>NameUserPrincipal</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in UPN format is "someone@example.com".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_userupn HRESULT get_UserUpn( BSTR
		// *pbstrProp );
		[DispId(1610743815)]
		new string UserUpn
		{
			[DispId(1610743815)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>UserDnsSamCompat</b> property retrieves the name of the current client in a DNS format compatible with
		/// Windows Security Account Manager (SAM).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The SAM-compatible DNS client name is retrieved by impersonating the client token and calling the <c>GetUserNameEx</c> function
		/// with <b>NameDnsDomain</b> specified for the <i>NameFormat</i> parameter.
		/// </para>
		/// <para>An example of a client name in SAM-compatible DNS format is "example.fourthcoffee.com\Username".</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-get_userdnssamcompat HRESULT
		// get_UserDnsSamCompat( BSTR *pbstrProp );
		[DispId(1610743816)]
		new string UserDnsSamCompat
		{
			[DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The GetProperty method returns the IAzClientContext object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the IAzClientContext object property to return. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AZ_PROP_CHILD_CREATE</term>
		/// <description>
		/// Determines whether the current user has permission to create child objects. This value will always be FALSE because this object
		/// cannot have child objects.
		/// </description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_ROLE_FOR_ACCESS_CHECK</term>
		/// <description>Also accessed through the RoleForAccessCheck property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_CANONICAL</term>
		/// <description>Also accessed through the UserCanonical property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_DISPLAY</term>
		/// <description>Also accessed through the UserDisplay property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_DN</term>
		/// <description>Also accessed through the UserDn property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_DNS_SAM_COMPAT</term>
		/// <description>Also accessed through the UserDnsSamCompat property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_GUID</term>
		/// <description>Also accessed through the UserGuid property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_SAM_COMPAT</term>
		/// <description>Also accessed through the UserSamCompat property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CLIENT_CONTEXT_USER_UPN</term>
		/// <description>Also accessed through the UserUpn property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to the returned IAzClientContext object property.</returns>
		[DispId(1610743817)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>GetRoles</b> method returns the roles for the client context.</summary>
		/// <param name="bstrScopeName">
		/// Name of the <c>IAzScope</c> object from which the roles returned in the <i>pvarRoleNames</i> parameter are applicable. If this
		/// property is <b>NULL</b>, the roles from the application scope are returned; otherwise, the roles from the specified scope are
		/// returned instead of the roles from the application scope.
		/// </param>
		/// <returns>
		/// A pointer to a <b>VARIANT</b> used to return a <c>SAFEARRAY</c>. Each element of the <b>SAFEARRAY</b> is a <b>VARIANT</b> of type
		/// <b>BSTR</b> that contains the name of a role to which the client belongs at the scope specified by the <i>bstrScopeName</i> parameter.
		/// </returns>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-getroles HRESULT GetRoles( [in, optional]
		// BSTR bstrScopeName, [out] VARIANT *pvarRoleNames );
		[DispId(1610743818)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object GetRoles([In, MarshalAs(UnmanagedType.BStr)] string? bstrScopeName = null);

		/// <summary>
		/// <para>The <b>RoleForAccessCheck</b> property sets or retrieves the role that is used to perform the access check.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// If this property is set, the role specified by this property will be the only role used in the access check; otherwise, all roles
		/// contained in the context will be used.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext-put_roleforaccesscheck HRESULT
		// put_RoleForAccessCheck( BSTR bstrProp );
		[DispId(1610743819)]
		new string RoleForAccessCheck
		{
			[DispId(1610743819)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743819)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// The <b>GetAssignedScopesPage</b> method retrieves a list of the scopes in which the client represented by the current
		/// <c>IAzClientContext2</c> object is assigned to at least one role.
		/// </summary>
		/// <param name="lOptions">
		/// <para>
		/// A flag that specifies whether this method checks LDAP query groups for scope assignment. Previously cached LDAP query groups are
		/// checked regardless of the value of this flag.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_CLIENT_CONTEXT_SKIP_LDAP_QUERY</b> 1</description>
		/// <description>LDAP query groups that were not previously cached are not checked.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="PageSize">The number of elements in each page result.</param>
		/// <param name="pvarCursor">
		/// A pointer to a <b>VARIANT</b> that represents the current page of results. For the first call to the <b>GetAssignedScopesPage</b>
		/// method, pass <b>VT_EMPTY</b> as the value for this parameter to retrieve the first page of results. The number of elements on a
		/// page is determined by the value of the <i>PageSize</i> parameter. On output, this parameter contains the value to be passed in
		/// the next call to <b>GetAssignedScopesPage</b> to retrieve the next page of results. If the value of this parameter on output is
		/// <b>EMPTY</b>, there are no more result pages.
		/// </param>
		/// <returns>
		/// On return, contains an array of variables of type <b>VARIANT</b>. Each element of the array is of type <b>VT_BSTR</b> and
		/// contains the name of a scope to which the current client is assigned. The number of elements in the array is specified by the
		/// <i>PageSize</i> parameter.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If multiple threads access the same authorization store, a call to the <b>GetAssignedScopesPage</b> method on one of the threads
		/// might not return accurate results if the other thread modifies the store.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> values must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext2-getassignedscopespage HRESULT
		// GetAssignedScopesPage( [in] LONG lOptions, [in] LONG PageSize, [in, out] VARIANT *pvarCursor, VARIANT *pvarScopeNames );
		[DispId(1610809344)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object GetAssignedScopesPage([In] AZ_PROP_CONSTANTS lOptions, [In] int PageSize, [In, Out, MarshalAs(UnmanagedType.Struct)] ref object pvarCursor);

		/// <summary>The <b>AddRoles</b> method adds the specified array of existing <c>IAzRole</c> objects to the client context.</summary>
		/// <param name="varRoles">The array of role names that specify the <c>IAzRole</c> objects to add to the client context.</param>
		/// <param name="bstrScopeName">The scope to which the array of roles applies.</param>
		/// <remarks>
		/// <para>The <c>IAzRole</c> objects associated with the names in the <i>varRoles</i> array must already exist in the specified scope.</para>
		/// <para>The added roles are used in subsequent calls to the <c>AccessCheck</c> and <c>GetRoles</c> methods.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext2-addroles HRESULT AddRoles( [in] VARIANT
		// varRoles, [in] BSTR bstrScopeName );
		[DispId(1610809345)]
		new void AddRoles([In, MarshalAs(UnmanagedType.Struct)] object varRoles, [In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName);

		/// <summary>
		/// The <b>AddApplicationGroups</b> method adds the specified array of existing <c>IAzApplicationGroup</c> objects to the client
		/// context object.
		/// </summary>
		/// <param name="varApplicationGroups">The array of <c>IAzApplicationGroup</c> objects to add.</param>
		/// <remarks>
		/// <para>
		/// The <c>IAzApplicationGroup</c> objects in the <i>varApplicationGroups</i> array must already exist in the authorization store.
		/// </para>
		/// <para>The added roles are used in subsequent calls to the <c>AccessCheck</c> and <c>GetRoles</c> methods.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext2-addapplicationgroups HRESULT
		// AddApplicationGroups( [in] VARIANT varApplicationGroups );
		[DispId(1610809346)]
		new void AddApplicationGroups([In, MarshalAs(UnmanagedType.Struct)] object varApplicationGroups);

		/// <summary>
		/// The <b>AddStringSids</b> method adds an array of string representations of <c>security identifiers</c> (SIDs) to the client context.
		/// </summary>
		/// <param name="varStringSids">The array of string representations of SIDs to add to the client context.</param>
		// https://learn.microsoft.com/sl-si/windows/win32/api/azroles/nf-azroles-iazclientcontext2-addstringsids HRESULT AddStringSids( [in]
		// VARIANT varStringSids );
		[DispId(1610809347)]
		new void AddStringSids([In, MarshalAs(UnmanagedType.Struct)] object varStringSids);

		/// <summary>
		/// <para>
		/// The <b>LDAPQueryDN</b> property retrieves or sets the domain name of the directory object to be used during evaluation of LDAP
		/// query groups.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext2-put_ldapquerydn HRESULT put_LDAPQueryDN(
		// BSTR bstrLDAPQueryDN );
		[DispId(1610809348)]
		new string LDAPQueryDN
		{
			[DispId(1610809348)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610809348)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// The <b>AccessCheck2</b> method returns a value that specifies whether the principal represented by the current client context is
		/// allowed to perform the specified operation.
		/// </summary>
		/// <param name="bstrObjectName">The name of the accessed object. This string is used in audits.</param>
		/// <param name="bstrScopeName">The name of the scope that contains the operation specified by the <i>lOperation</i> parameter.</param>
		/// <param name="lOperation">The <c>OperationID</c> property of the <c>IAzOperation</c> object for which to check access.</param>
		/// <returns>
		/// <para>
		/// A pointer to a value that indicates whether the principal represented by the current client context is allowed to perform the
		/// operation specified by the <i>lOperation</i> parameter.
		/// </para>
		/// <para>
		/// A value of <b>NO_ERROR</b> indicates that the principal does have permission. Any other value indicates that the principal does
		/// not have permission.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext3-accesscheck2 HRESULT AccessCheck2( [in]
		// BSTR bstrObjectName, [in] BSTR bstrScopeName, [in] long lOperation, [out] unsigned long *plResult );
		[DispId(1610874880)]
		uint AccessCheck2([In, MarshalAs(UnmanagedType.BStr)] string bstrObjectName, [In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName, [In] AZ_PROP_CONSTANTS lOperation);

		/// <summary>
		/// The <b>IsInRoleAssignment</b> method checks whether the principal represented by the current client context is a member of the
		/// specified role in the specified scope.
		/// </summary>
		/// <param name="bstrScopeName">The name of the scope to check.</param>
		/// <param name="bstrRoleName">The name of the role to check.</param>
		/// <returns>
		/// <b>VARIANT_TRUE</b> if the principal represented by the current client context is a member of the role specified by the
		/// <i>bstrRoleName</i> parameter in the scope specified by the <i>bstrScopeName</i> parameter; otherwise, <b>VARIANT_FALSE</b>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext3-isinroleassignment?view=vs-2017 HRESULT
		// IsInRoleAssignment( [in] BSTR bstrScopeName, [in] BSTR bstrRoleName, [out] VARIANT_BOOL *pbIsInRole );
		[DispId(1610874881)]
		bool IsInRoleAssignment([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName, [In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName);

		/// <summary>
		/// The <b>GetOperations</b> method returns a collection of the operations, within the specified scope, that the principal
		/// represented by the current client context has permission to perform.
		/// </summary>
		/// <param name="bstrScopeName">The name of the scope to check.</param>
		/// <returns>
		/// The address of a pointer to the collection of operations that the principal represented by the current client context has
		/// permission to perform.
		/// </returns>
		// https://learn.microsoft.com/et-ee/windows/win32/api/azroles/nf-azroles-iazclientcontext3-getoperations HRESULT GetOperations( [in]
		// BSTR bstrScopeName, [out] IAzOperations **ppOperationCollection );
		[DispId(1610874882)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzOperations GetOperations([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName);

		/// <summary>
		/// The <b>GetTasks</b> method returns a collection of the tasks, within the specified scope, that the principal represented by the
		/// current client context has permission to perform.
		/// </summary>
		/// <param name="bstrScopeName">The name of the scope to check.</param>
		/// <returns>
		/// The address of a pointer to the collection of tasks that the principal represented by the current client context has permission
		/// to perform.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext3-gettasks HRESULT GetTasks( [in] BSTR
		// bstrScopeName, [out] IAzTasks **ppTaskCollection );
		[DispId(1610874883)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzTasks GetTasks([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName);

		/// <summary>
		/// <para>
		/// The <b>IAzClientContext3::BizRuleParameters</b> method gets the collection of parameters that can be passed by the business rule
		/// (BizRule) script associated with this client context.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext3-get_bizruleparameters HRESULT
		// get_BizRuleParameters( IAzBizRuleParameters **ppBizRuleParam );
		[DispId(1610874884)]
		IAzBizRuleParameters BizRuleParameters
		{
			[DispId(1610874884)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>IAzClientContext3::BizRuleInterfaces</b> method gets the collection of <c>IDispatch</c> interfaces that can be called by
		/// the business rule (BizRule) script associated with this client context.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext3-get_bizruleinterfaces HRESULT
		// get_BizRuleInterfaces( IAzBizRuleInterfaces **ppBizRuleInterfaces );
		[DispId(1610874885)]
		IAzBizRuleInterfaces BizRuleInterfaces
		{
			[DispId(1610874885)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>GetGroups</b> method returns an array of the application groups associated with this client context.</summary>
		/// <param name="bstrScopeName">
		/// The name of the scope in which to check for application groups. This parameter is ignored if the value of the ulOptions parameter
		/// is set to <b>AZ_CLIENT_CONTEXT_GET_GROUPS_STORE_LEVEL_ONLY</b>.
		/// </param>
		/// <param name="ulOptions">
		/// <para>
		/// A set of flags that modify the behavior of this method. This can be zero or a combination of one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_CLIENT_CONTEXT_GET_GROUPS_STORE_LEVEL_ONLY</b> 0x2</description>
		/// <description>This method checks only for application groups at the store level.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>A pointer to an array of the names of application groups associated with this client context.</para>
		/// <para>
		/// This is a variant that contains either a <c>SAFEARRAY</c> or the JScript <c>Array</c> object. Each element of the array holds a
		/// <b>VT_BSTR</b> that contains the name of an application group.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext3-getgroups HRESULT GetGroups( [in] BSTR
		// bstrScopeName, [in] ULONG ulOptions, [out] VARIANT *pGroupArray );
		[DispId(1610874886)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetGroups([In, MarshalAs(UnmanagedType.BStr)] string bstrScopeName, [In] uint ulOptions);

		/// <summary>
		/// <para>The <b>Sids</b> property gets an array of the <c>security identifiers</c> (SIDs) associated with this client context.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazclientcontext3-get_sids HRESULT get_Sids( VARIANT
		// *pStringSidArray );
		[DispId(1610874887)]
		object Sids
		{
			[DispId(1610874887)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	/// <summary>Translates security identifiers (SIDs) into principal display names.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iaznameresolver
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzNameResolver")]
	[ComImport, Guid("504D0F15-73E2-43DF-A870-A64F40714F53")]
	public interface IAzNameResolver
	{
		/// <summary>
		/// The <b>NameFromSid</b> method gets the display name that corresponds to the specified <c>security identifier</c> (SID).
		/// </summary>
		/// <param name="bstrSid">The string representation of the SID to translate.</param>
		/// <param name="pSidType">An element of the <c>SID_NAME_USE</c> enumeration that specifies the type of SID being translated.</param>
		/// <returns>A pointer to the display name of the principal that corresponds to the SID specified by the <i>bstrSid</i> parameter.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaznameresolver-namefromsid HRESULT NameFromSid( [in] BSTR
		// bstrSid, [out] long *pSidType, [out] BSTR *pbstrName );
		[DispId(1610743808)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string NameFromSid([In, MarshalAs(UnmanagedType.BStr)] string bstrSid, out AdvApi32.SID_NAME_USE pSidType);

		/// <summary>
		/// The <b>NamesFromSids</b> method gets the display names that correspond to the specified <c>security identifiers</c> (SIDs).
		/// </summary>
		/// <param name="vSids">
		/// <para>An array of string representations of the SIDs to translate.</para>
		/// <para>
		/// This is a variant that contains either a <c>SAFEARRAY</c> or the JScript <c>Array</c> object. Each element of the array holds a
		/// <b>VT_BSTR</b> that contains a string representation of a SID.
		/// </para>
		/// </param>
		/// <param name="pvSidTypes">
		/// <para>A pointer to an array of elements of the <c>SID_NAME_USE</c> enumeration that specify the types of SIDs being translated.</para>
		/// <para>
		/// This is a variant that contains either a <c>SAFEARRAY</c> or the JScript <c>Array</c> object. Each element of the array holds a
		/// <b>VT_I4</b> value that specifies an element of the <c>SID_NAME_USE</c> enumeration.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// A pointer to an array of strings that contain the display names of the principals that correspond to the SIDs specified by the
		/// <i>vSids</i> parameter.
		/// </para>
		/// <para>
		/// This is a variant that contains either a <c>SAFEARRAY</c> or the JScript <c>Array</c> object. Each element of the array holds a
		/// <b>VT_BSTR</b> that contains a display name. If a name could not be found for one or more of the SIDs, the corresponding array
		/// element contains an empty string.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaznameresolver-namesfromsids HRESULT NamesFromSids( [in]
		// VARIANT vSids, [out] VARIANT *pvSidTypes, [out] VARIANT *pvNames );
		[DispId(1610743809)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object NamesFromSids([In, MarshalAs(UnmanagedType.Struct)] object vSids, [MarshalAs(UnmanagedType.Struct)] out object pvSidTypes);
	}

	/// <summary>Displays a dialog box that allows users to select one or more principals from a list.</summary>
	/// <remarks>Implement this interface when you need a custom dialog box that allows users to choose principals.</remarks>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazobjectpicker
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzObjectPicker")]
	[ComImport, Guid("63130A48-699A-42D8-BF01-C62AC3FB79F9")]
	public interface IAzObjectPicker
	{
		/// <summary>
		/// The <b>GetPrincipals</b> method displays a dialog box from which users can choose one or more principals, and then returns the
		/// chosen list of principals and their corresponding <c>security identifiers</c> (SIDs).
		/// </summary>
		/// <param name="hParentWnd">A handle to the parent window of the dialog box.</param>
		/// <param name="bstrTitle">The display title of the dialog box.</param>
		/// <param name="pvSidTypes">
		/// <para>
		/// A pointer to an array of elements of the <c>SID_NAME_USE</c> enumeration that specify the types of the SIDs that correspond to
		/// the principals chosen by the user.
		/// </para>
		/// <para>
		/// This is a variant that contains either a <c>SAFEARRAY</c> or the JScript <c>Array</c> object. Each element of the array holds a
		/// <b>VT_I4</b> value that specifies an element of the <c>SID_NAME_USE</c> enumeration.
		/// </para>
		/// </param>
		/// <param name="pvNames">
		/// <para>A pointer to an array of display names of the principals chosen by the user.</para>
		/// <para>
		/// This is a variant that contains either a <c>SAFEARRAY</c> or the JScript <c>Array</c> object. Each element of the array holds a
		/// <b>VT_BSTR</b> that contains a display name.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>A pointer to an array of string representations of the SIDs that correspond to the principals chosen by the user.</para>
		/// <para>
		/// This is a variant that contains either a <c>SAFEARRAY</c> or the JScript <c>Array</c> object. Each element of the array holds a
		/// <b>VT_BSTR</b> that contains a string representation of a SID.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazobjectpicker-getprincipals HRESULT GetPrincipals( [in]
		// HWND hParentWnd, [in] BSTR bstrTitle, [out] VARIANT *pvSidTypes, [out] VARIANT *pvNames, [out] VARIANT *pvSids );
		[DispId(1610743808)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetPrincipals([In] HWND hParentWnd, [In, MarshalAs(UnmanagedType.BStr)] string bstrTitle, [MarshalAs(UnmanagedType.Struct)] out object pvSidTypes, [MarshalAs(UnmanagedType.Struct)] out object pvNames);

		/// <summary>
		/// <para>The <b>Name</b> property gets the name of the <c>IAzObjectPicker</c> object.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazobjectpicker-get_name HRESULT get_Name( BSTR *pbstrName );
		[DispId(1610743809)]
		string Name
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	/// <summary>Defines a low-level operation supported by an application.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazoperation
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzOperation")]
	[ComImport, Guid("5E56B24F-EA01-4D61-BE44-C49B5E4EAF74")]
	public interface IAzOperation
	{
		/// <summary>
		/// <para>The <b>Name</b> property sets or retrieves the name of the operation.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Name</b> property is 64 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-put_name HRESULT put_Name( BSTR bstrName );
		[DispId(1610743808)]
		string Name
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the operation.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-put_description HRESULT put_Description( BSTR
		// bstrDescription );
		[DispId(1610743810)]
		string Description
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>ApplicationData</b> property sets or retrieves an opaque field that can be used by the application to store information.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// <b>Important</b>  Policy administrators can read from and write to this property. Applications should not store data in the
		/// <b>ApplicationData</b> property that should not be available to the policy administrator.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-put_applicationdata HRESULT
		// put_ApplicationData( BSTR bstrApplicationData );
		[DispId(1610743812)]
		string ApplicationData
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>OperationID</b> property sets or retrieves an application-specific value that uniquely identifies the operation within the application.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-put_operationid HRESULT put_OperationID( LONG
		// lProp );
		[DispId(1610743814)]
		int OperationID
		{
			[DispId(1610743814)]
			get;
			[DispId(1610743814)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the operation can be modified by the user context that
		/// initialized it.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-get_writable HRESULT get_Writable( BOOL
		// *pfProp );
		[DispId(1610743816)]
		bool Writable
		{
			[DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>The <b>GetProperty</b> method returns the <c>IAzOperation</c> object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzOperation</c> object property to return. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><b>AZ_PROP_CHILD_CREATE</b></description>
		/// <description>
		/// Determines whether the current user has permission to create child objects. This value will always be FALSE because this object
		/// cannot have child objects.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// <item>
		/// <description><b>AZ_PROP_OPERATION_ID</b></description>
		/// <description>Also accessed through the <c>OperationID</c> property</description>
		/// </item>
		/// <item>
		/// <description><b>AZ_PROP_WRITABLE</b></description>
		/// <description>Also accessed through the Writable property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to the returned IAzOperation object property.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-getproperty
		[DispId(1610743817)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzOperation</c> object property with the specified property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzOperation</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_OPERATION_ID</b></description>
		/// <description>Also accessed through the <c>OperationID</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// The value to set to the <c>IAzOperation</c> object property specified by the <i>lPropId</i> parameter. The following table shows
		/// the type of data that must be used depending on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type (C++/Visual Basic)</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_OPERATION_ID</b></description>
		/// <description><b>LONG</b>/ <b>Long</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-setproperty HRESULT SetProperty( [in] LONG
		// lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743818)]
		void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>IAzOperation</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// Any additions or modifications to an <c>IAzOperation</c> object are not persisted until the <b>Submit</b> method is called.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-submit HRESULT Submit( [in, optional] LONG
		// lFlags, [in, optional] VARIANT varReserved );
		[DispId(1610743819)]
		void Submit([Optional, DefaultParameterValue((AZ_PROP_CONSTANTS)0), In] AZ_PROP_CONSTANTS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);
	}

	/// <summary>Extends the IAzOperation with a method that returns the role assignments associated with the operation.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazoperation2
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzOperation2")]
	[ComImport, Guid("1F5EA01F-44A2-4184-9C48-A75B4DCC8CCC")]
	public interface IAzOperation2 : IAzOperation
	{
		/// <summary>
		/// <para>The <b>Name</b> property sets or retrieves the name of the operation.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Name</b> property is 64 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-put_name HRESULT put_Name( BSTR bstrName );
		[DispId(1610743808)]
		new string Name
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the operation.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-put_description HRESULT put_Description( BSTR
		// bstrDescription );
		[DispId(1610743810)]
		new string Description
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>ApplicationData</b> property sets or retrieves an opaque field that can be used by the application to store information.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// <b>Important</b>  Policy administrators can read from and write to this property. Applications should not store data in the
		/// <b>ApplicationData</b> property that should not be available to the policy administrator.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-put_applicationdata HRESULT
		// put_ApplicationData( BSTR bstrApplicationData );
		[DispId(1610743812)]
		new string ApplicationData
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>OperationID</b> property sets or retrieves an application-specific value that uniquely identifies the operation within the application.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-put_operationid HRESULT put_OperationID( LONG
		// lProp );
		[DispId(1610743814)]
		new int OperationID
		{
			[DispId(1610743814)]
			get;
			[DispId(1610743814)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the operation can be modified by the user context that
		/// initialized it.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-get_writable HRESULT get_Writable( BOOL
		// *pfProp );
		[DispId(1610743816)]
		new bool Writable
		{
			[DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>The <b>GetProperty</b> method returns the <c>IAzOperation</c> object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzOperation</c> object property to return. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><b>AZ_PROP_CHILD_CREATE</b></description>
		/// <description>
		/// Determines whether the current user has permission to create child objects. This value will always be FALSE because this object
		/// cannot have child objects.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// <item>
		/// <description><b>AZ_PROP_OPERATION_ID</b></description>
		/// <description>Also accessed through the <c>OperationID</c> property</description>
		/// </item>
		/// <item>
		/// <description><b>AZ_PROP_WRITABLE</b></description>
		/// <description>Also accessed through the Writable property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to the returned IAzOperation object property.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-getproperty
		[DispId(1610743817)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzOperation</c> object property with the specified property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzOperation</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_OPERATION_ID</b></description>
		/// <description>Also accessed through the <c>OperationID</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// The value to set to the <c>IAzOperation</c> object property specified by the <i>lPropId</i> parameter. The following table shows
		/// the type of data that must be used depending on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type (C++/Visual Basic)</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_OPERATION_ID</b></description>
		/// <description><b>LONG</b>/ <b>Long</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-setproperty HRESULT SetProperty( [in] LONG
		// lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743818)]
		new void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>IAzOperation</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// Any additions or modifications to an <c>IAzOperation</c> object are not persisted until the <b>Submit</b> method is called.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation-submit HRESULT Submit( [in, optional] LONG
		// lFlags, [in, optional] VARIANT varReserved );
		[DispId(1610743819)]
		new void Submit([Optional, DefaultParameterValue((AZ_PROP_CONSTANTS)0), In] AZ_PROP_CONSTANTS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>RoleAssignments</b> method returns a collection of the role assignments associated with this operation.</summary>
		/// <param name="bstrScopeName">
		/// The name of the scope in which to check for role assignments. If the value of this parameter is an empty string, the method
		/// checks for role assignments at the application level.
		/// </param>
		/// <param name="bRecursive">
		/// <b>TRUE</b> if the method checks all scopes within the application; otherwise, <b>FALSE</b>. This parameter is ignored if the
		/// value of the <i>bstrScopeName</i> parameter is not <b>NULL</b>.
		/// </param>
		/// <returns>
		/// The address of a pointer to an <c>IAzRoleAssignments</c> interface that represents the collection of <c>IAzRoleAssignment</c>
		/// objects associated with this operation.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperation2-roleassignments HRESULT RoleAssignments( [in]
		// BSTR bstrScopeName, [in] VARIANT_BOOL bRecursive, [out] IAzRoleAssignments **ppRoleAssignments );
		[DispId(1610809344)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRoleAssignments RoleAssignments([In, MarshalAs(UnmanagedType.BStr)] string? bstrScopeName, [In] bool bRecursive);
	}

	/// <summary>Represents a collection of IAzOperation objects.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazoperations
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzOperations")]
	[ComImport, Guid("90EF9C07-9706-49D9-AF80-0438A5F3EC35")]
	public interface IAzOperations : IEnumerable
	{
		/// <summary>
		/// <para>
		/// The <b>Item</b> property retrieves the <c>IAzOperation</c> object at the specified index into the <c>IAzOperations</c> collection.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="Index"/>
		// https://learn.microsoft.com/fi-fi/windows/win32/api/azroles/nf-azroles-iazoperations-get_item HRESULT get_Item( LONG Index,
		// VARIANT *pvarObtPtr );
		[DispId(0)]
		object this[[In] int Index]
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Count</b> property retrieves the number of <c>IAzOperation</c> objects in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// The <b>Count</b> property can be used to specify the last <c>IAzOperation</c> object in a collection when retrieving a specific
		/// <b>IAzOperation</b> object using the <c>IAzOperations.Item</c> property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazoperations-get_count HRESULT get_Count( LONG *plCount );
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		/// <summary>
		/// The _NewEnum property retrieves an IEnumVARIANT interface on an object that can be used to enumerate the collection. This
		/// property is hidden within Visual Basic and Visual Basic Scripting Edition (VBScript).
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/secauthz/microsoft-interop-security-azroles-iazoperations-interface
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();
	}

	/// <summary>Locates and chooses ADAM principals in Authorization Manager.</summary>
	/// <remarks>
	/// <para>
	/// An <b>IAzPrincipalLocator</b> object can contain a name resolver and an object picker. A name resolver translates <c>security
	/// identifiers</c> (SIDs) into display names. An object picker displays a dialog box that enables a user to select from a list of ADAM
	/// principals. The dialog box can appear when a user modifies application groups or roles through the Authorization Manager user interface.
	/// </para>
	/// <para>
	/// The <b>IAzPrincipalLocator</b> interface must be registered under the following key. <b>HKEY_LOCAL_MACHINE</b>\ <b>Software</b>\
	/// <b>Microsoft</b>\ <b>AzMan</b>\ <b>ObjectPicker</b>
	/// </para>
	/// Under this registry key, create a subkey with a value of the COM class ID of the <b>IAzPrincipalLocator</b> interface. Authorization
	/// Manager supports only one registered principal locator.
	/// </remarks>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazprincipallocator
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzPrincipalLocator")]
	[ComImport, Guid("E5C3507D-AD6A-4992-9C7F-74AB480B44CC"), CoClass(typeof(AzPrincipalLocator))]
	public interface IAzPrincipalLocator
	{
		/// <summary>
		/// <para>
		/// The <b>NameResolver</b> method gets a pointer to the <c>IAzNameResolver</c> interface associated with this
		/// <c>IAzPrincipalLocator</c> object.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/ga-ie/windows/win32/api/azroles/nf-azroles-iazprincipallocator-get_nameresolver HRESULT
		// get_NameResolver( IAzNameResolver **ppNameResolver );
		[DispId(1610743808)]
		IAzNameResolver NameResolver
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>ObjectPicker</b> method gets a pointer to the <c>IAzObjectPicker</c> interface associated with this
		/// <c>IAzPrincipalLocator</c> object.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazprincipallocator-get_objectpicker HRESULT
		// get_ObjectPicker( IAzObjectPicker **ppObjectPicker );
		[DispId(1610743809)]
		IAzObjectPicker ObjectPicker
		{
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	/// <summary>Defines the set of operations that can be performed by a set of users within a scope.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazrole
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzRole")]
	[ComImport, Guid("859E0D8D-62D7-41D8-A034-C0CD5D43FDFA")]
	public interface IAzRole
	{
		/// <summary>
		/// <para>The <b>Name</b> property sets or retrieves the name of the role.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Name</b> property is 64 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-put_name HRESULT put_Name( BSTR bstrName );
		[DispId(1610743808)]
		string Name
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the role.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-put_description HRESULT put_Description( BSTR
		// bstrDescription );
		[DispId(1610743810)]
		string Description
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>ApplicationData</b> property sets or retrieves an opaque field that can be used by the application to store information.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// <b>Important</b>  Policy administrators can read from and write to this property. Applications should not store data in the
		/// <b>ApplicationData</b> property that should not be available to the policy administrator.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/nb-no/windows/win32/api/azroles/nf-azroles-iazrole-put_applicationdata HRESULT put_ApplicationData(
		// BSTR bstrApplicationData );
		[DispId(1610743812)]
		string ApplicationData
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// The <b>AddAppMember</b> method adds the specified <c>IAzApplicationGroup</c> object to the list of application groups that belong
		/// to this role.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to add to the list of the application
		/// groups that belong to this role.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>To view the list of application groups that belong to this role, use the <c>AppMembers</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-addappmember HRESULT AddAppMember( [in] BSTR
		// bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743814)]
		void AddAppMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteAppMember</b> method removes the specified <c>IAzApplicationGroup</c> object from the list of application groups
		/// that belong to the role.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to remove from the list of application
		/// groups that belong to the role.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>To view the list of application groups that belong to the role, use the <c>AppMembers</c> property.</remarks>
		// https://learn.microsoft.com/en-us/windows/desktop/api/Azroles/nf-azroles-iazrole-deleteappmember HRESULT DeleteAppMember( [in]
		// BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743815)]
		void DeleteAppMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddTask</b> method adds the <c>IAzTask</c> object with the specified name to the role.</summary>
		/// <param name="bstrProp">Name of the <c>IAzTask</c> object to add to the role.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-addtask HRESULT AddTask( [in] BSTR bstrProp, [in,
		// optional] VARIANT varReserved );
		[DispId(1610743816)]
		void AddTask([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeleteTask</b> method removes the <c>IAzTask</c> object with the specified name from the role.</summary>
		/// <param name="bstrProp">Name of the <c>IAzTask</c> object to remove from the role.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzTask</c> references to an <b>IAzTask</b> object that has been deleted from the cache, the <b>IAzTask</b>
		/// object can no longer be used. In C++, you must release references to deleted <b>IAzTask</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-deletetask HRESULT DeleteTask( [in] BSTR bstrProp,
		// [in, optional] VARIANT varReserved );
		[DispId(1610743817)]
		void DeleteTask([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddOperation</b> method adds the <c>IAzOperation</c> object with the specified name to the role.</summary>
		/// <param name="bstrProp">Name of the <c>IAzOperation</c> object to add to the role.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-addoperation HRESULT AddOperation( [in] BSTR
		// bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743818)]
		void AddOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeleteOperation</b> method removes the <c>IAzOperation</c> object with the specified name from the role.</summary>
		/// <param name="bstrProp">Name of the <c>IAzOperation</c> object to remove from the role.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzOperation</c> references to an <b>IAzOperation</b> object that has been deleted from the cache, the
		/// <b>IAzOperation</b> object can no longer be used. In C++, you must release references to deleted <b>IAzOperation</b> objects by
		/// calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-deleteoperation HRESULT DeleteOperation( [in] BSTR
		// bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743819)]
		void DeleteOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddMember</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of Windows accounts that
		/// belong to the role.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the text form of the SID to add to the list of Windows accounts that belong to the role.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>To view the list of SIDs of Windows accounts that belong to this role in text form, use the <c>Members</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-addmember HRESULT AddMember( [in] BSTR bstrProp,
		// [in, optional] VARIANT varReserved );
		[DispId(1610743820)]
		void AddMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteMember</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of Windows
		/// accounts that belong to the role.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the text form of the SID to remove from the list of Windows accounts that belong to the role.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>To view the list of SIDs of Windows accounts that belong to the role in text form, use the <c>Members</c> property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-deletemember HRESULT DeleteMember( [in] BSTR
		// bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743821)]
		void DeleteMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the role can be modified by the user context that
		/// initialized it.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-get_writable HRESULT get_Writable( BOOL *pfProp );
		[DispId(1610743822)]
		bool Writable
		{
			[DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>The <b>GetProperty</b> method returns the <c>IAzRole</c> object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzRole</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AZ_PROP_APPLICATION_DATA</term>
		/// <description>Also accessed through the ApplicationData property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CHILD_CREATE</term>
		/// <description>
		/// Determines whether the current user has permission to create child objects. This value will always be FALSE because this object
		/// cannot have child objects.
		/// </description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_DESCRIPTION</term>
		/// <description>Also accessed through the Description property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_NAME</term>
		/// <description>Also accessed through the Name property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_ROLE_APP_MEMBERS</term>
		/// <description>Also accessed through the AppMembers property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_ROLE_MEMBERS</term>
		/// <description>Also accessed through the Members property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_ROLE_MEMBERS_NAME</term>
		/// <description>Also accessed through the MembersName property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_ROLE_OPERATIONS</term>
		/// <description>Also accessed through the Operations property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_ROLE_TASKS</term>
		/// <description>Also accessed through the Tasks property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_WRITABLE</term>
		/// <description>Also accessed through the Writable property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>The return value is an HRESULT. A value of S_OK indicates success. Any other value indicates that the operation failed.</returns>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-getproperty
		[DispId(1610743823)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzRole</c> object property with the specified property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzRole</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// The value to set to the <c>IAzRole</c> object property specified by the <i>lPropId</i> parameter. The following table shows the
		/// type of data that must be used depending on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type (C++/Visual Basic)</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-setproperty HRESULT SetProperty( [in] LONG lPropId,
		// [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743824)]
		void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>AppMembers</b> property retrieves the application groups that belong to the role.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-get_appmembers HRESULT get_AppMembers( VARIANT
		// *pvarProp );
		[DispId(1610743825)]
		object AppMembers
		{
			[DispId(1610743825)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>Members</b> property retrieves the <c>security identifiers</c> (SIDs), in text form, of Windows accounts that belong to
		/// the role.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-get_members HRESULT get_Members( VARIANT *pvarProp );
		[DispId(1610743826)]
		object Members
		{
			[DispId(1610743826)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Operations</b> property retrieves the operations associated with the role.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-get_operations HRESULT get_Operations( VARIANT
		// *pvarProp );
		[DispId(1610743827)]
		object Operations
		{
			[DispId(1610743827)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Tasks</b> property retrieves the tasks associated with the role.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-get_tasks HRESULT get_Tasks( VARIANT *pvarProp );
		[DispId(1610743828)]
		object Tasks
		{
			[DispId(1610743828)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>The <b>AddPropertyItem</b> method adds the specified entity to the specified list.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list to which to add the entity specified by the <i>varProp</i> parameter. The following table shows the
		/// possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_APP_MEMBERS</b></description>
		/// <description>Can also be added using the <c>AddAppMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_MEMBERS</b></description>
		/// <description>Can also be added using the <c>AddMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_MEMBERS_NAME</b></description>
		/// <description>Can also be added using the <c>AddMemberName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_OPERATIONS</b></description>
		/// <description>Can also be added using the <c>AddOperation</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_TASKS</b></description>
		/// <description>Can also be added using the <c>AddTask</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Entity to add to the list specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_ROLE_MEMBERS is specified for the <i>lPropId</i> parameter, the string is the text form of the <c>security
		/// identifier</c> (SID) of the Windows account to add to the list. If AZ_PROP_ROLE_MEMBERS_NAME is specified for the <i>lPropId</i>
		/// parameter, the string is the account name of the account to add to the list. The account name can be in either user principal
		/// name (UPN) format (for example, "someone@example.com") or in the "ExampleDomain\UserName" format. If AZ_PROP_ROLE_APP_MEMBERS is
		/// specified for the <i>lPropId</i> parameter, the string is the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to
		/// add to the list.
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-addpropertyitem HRESULT AddPropertyItem( [in] LONG
		// lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743829)]
		void AddPropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeletePropertyItem</b> method removes the specified entity from the specified list.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list from which to remove the entity specified by the <i>varProp</i> parameter. The following table shows the
		/// possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_APP_MEMBERS</b></description>
		/// <description>Can also be removed using the <c>DeleteAppMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_MEMBERS</b></description>
		/// <description>Can also be removed using the <c>DeleteMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_MEMBERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeleteMemberName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_OPERATIONS</b></description>
		/// <description>Can also be removed using the <c>DeleteOperation</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_TASKS</b></description>
		/// <description>Can also be removed using the <c>DeleteTask</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Entity to remove from the list specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_ROLE_MEMBERS is specified for the <i>lPropId</i> parameter, the string is the <c>security identifier</c> (SID) of the
		/// Windows account to remove from the list. If AZ_PROP_ROLE_MEMBERS_NAME is specified for the <i>lPropId</i> parameter, the string
		/// is the account name of the account to remove from the list. The account name can be in either user principal name (UPN) format
		/// (for example, "someone@example.com") or in the "ExampleDomain\UserName" format. If AZ_PROP_ROLE_APP_MEMBERS is specified for the
		/// <i>lPropId</i> parameter, the string is the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to remove from the list.
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-deletepropertyitem HRESULT DeletePropertyItem( [in]
		// LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743830)]
		void DeletePropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>IAzRole</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>Any additions or modifications to an <c>IAzRole</c> object are not persisted until the <b>Submit</b> method is called.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-submit HRESULT Submit( [in, optional] LONG lFlags,
		// [in, optional] VARIANT varReserved );
		[DispId(1610743831)]
		void Submit([Optional, DefaultParameterValue((AZ_PROP_CONSTANTS)0), In] AZ_PROP_CONSTANTS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddMemberName</b> method adds the specified account name to the list of accounts that belong to the role.</summary>
		/// <param name="bstrProp">
		/// String that contains the account name to add to the list of accounts that belong to the role. The account name can be in either
		/// user principal name (UPN) format (for example, <c>someone@example.com</c>) or in the <c>ExampleDomain\UserName</c> format. If the
		/// domain is not in the <c>ExampleDomain\UserName</c> format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>To view the list of account names of accounts that belong to this role, use the <c>MembersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-addmembername HRESULT AddMemberName( [in] BSTR
		// bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743832)]
		void AddMemberName([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteMemberName</b> method removes the specified account name from the list of accounts that belong to the role.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the account name to remove from the list of accounts that belong to the role. The account name can be in
		/// either user principal name (UPN) format (for example, <c>someone@example.com</c>) or in the <c>ExampleDomain\UserName</c> format.
		/// If the domain is not in the <c>ExampleDomain\UserName</c> format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>To view the list of account names of accounts that belong to the role, use the <c>MembersName</c> property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-deletemembername HRESULT DeleteMemberName( [in]
		// BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743833)]
		void DeleteMemberName([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>MembersName</b> property retrieves the account names of accounts that belong to the role.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-get_membersname HRESULT get_MembersName( VARIANT
		// *pvarProp );
		[DispId(1610743834)]
		object MembersName
		{
			[DispId(1610743834)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	/// <summary>Represents a role to which users and groups can be assigned.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazroleassignment
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzRoleAssignment")]
	[ComImport, Guid("55647D31-0D5A-4FA3-B4AC-2B5F9AD5AB76")]
	public interface IAzRoleAssignment : IAzRole
	{
		/// <summary>
		/// <para>The <b>Name</b> property sets or retrieves the name of the role.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Name</b> property is 64 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-put_name HRESULT put_Name( BSTR bstrName );
		[DispId(1610743808)]
		new string Name
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the role.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-put_description HRESULT put_Description( BSTR
		// bstrDescription );
		[DispId(1610743810)]
		new string Description
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>ApplicationData</b> property sets or retrieves an opaque field that can be used by the application to store information.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// <b>Important</b>  Policy administrators can read from and write to this property. Applications should not store data in the
		/// <b>ApplicationData</b> property that should not be available to the policy administrator.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/nb-no/windows/win32/api/azroles/nf-azroles-iazrole-put_applicationdata HRESULT put_ApplicationData(
		// BSTR bstrApplicationData );
		[DispId(1610743812)]
		new string ApplicationData
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// The <b>AddAppMember</b> method adds the specified <c>IAzApplicationGroup</c> object to the list of application groups that belong
		/// to this role.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to add to the list of the application
		/// groups that belong to this role.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>To view the list of application groups that belong to this role, use the <c>AppMembers</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-addappmember HRESULT AddAppMember( [in] BSTR
		// bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743814)]
		new void AddAppMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteAppMember</b> method removes the specified <c>IAzApplicationGroup</c> object from the list of application groups
		/// that belong to the role.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to remove from the list of application
		/// groups that belong to the role.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>To view the list of application groups that belong to the role, use the <c>AppMembers</c> property.</remarks>
		// https://learn.microsoft.com/en-us/windows/desktop/api/Azroles/nf-azroles-iazrole-deleteappmember HRESULT DeleteAppMember( [in]
		// BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743815)]
		new void DeleteAppMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddTask</b> method adds the <c>IAzTask</c> object with the specified name to the role.</summary>
		/// <param name="bstrProp">Name of the <c>IAzTask</c> object to add to the role.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-addtask HRESULT AddTask( [in] BSTR bstrProp, [in,
		// optional] VARIANT varReserved );
		[DispId(1610743816)]
		new void AddTask([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeleteTask</b> method removes the <c>IAzTask</c> object with the specified name from the role.</summary>
		/// <param name="bstrProp">Name of the <c>IAzTask</c> object to remove from the role.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzTask</c> references to an <b>IAzTask</b> object that has been deleted from the cache, the <b>IAzTask</b>
		/// object can no longer be used. In C++, you must release references to deleted <b>IAzTask</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-deletetask HRESULT DeleteTask( [in] BSTR bstrProp,
		// [in, optional] VARIANT varReserved );
		[DispId(1610743817)]
		new void DeleteTask([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddOperation</b> method adds the <c>IAzOperation</c> object with the specified name to the role.</summary>
		/// <param name="bstrProp">Name of the <c>IAzOperation</c> object to add to the role.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-addoperation HRESULT AddOperation( [in] BSTR
		// bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743818)]
		new void AddOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeleteOperation</b> method removes the <c>IAzOperation</c> object with the specified name from the role.</summary>
		/// <param name="bstrProp">Name of the <c>IAzOperation</c> object to remove from the role.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzOperation</c> references to an <b>IAzOperation</b> object that has been deleted from the cache, the
		/// <b>IAzOperation</b> object can no longer be used. In C++, you must release references to deleted <b>IAzOperation</b> objects by
		/// calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-deleteoperation HRESULT DeleteOperation( [in] BSTR
		// bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743819)]
		new void DeleteOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddMember</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of Windows accounts that
		/// belong to the role.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the text form of the SID to add to the list of Windows accounts that belong to the role.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>To view the list of SIDs of Windows accounts that belong to this role in text form, use the <c>Members</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-addmember HRESULT AddMember( [in] BSTR bstrProp,
		// [in, optional] VARIANT varReserved );
		[DispId(1610743820)]
		new void AddMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteMember</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of Windows
		/// accounts that belong to the role.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the text form of the SID to remove from the list of Windows accounts that belong to the role.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>To view the list of SIDs of Windows accounts that belong to the role in text form, use the <c>Members</c> property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-deletemember HRESULT DeleteMember( [in] BSTR
		// bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743821)]
		new void DeleteMember([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the role can be modified by the user context that
		/// initialized it.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-get_writable HRESULT get_Writable( BOOL *pfProp );
		[DispId(1610743822)]
		new bool Writable
		{
			[DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>The <b>GetProperty</b> method returns the <c>IAzRole</c> object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzRole</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AZ_PROP_APPLICATION_DATA</term>
		/// <description>Also accessed through the ApplicationData property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CHILD_CREATE</term>
		/// <description>
		/// Determines whether the current user has permission to create child objects. This value will always be FALSE because this object
		/// cannot have child objects.
		/// </description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_DESCRIPTION</term>
		/// <description>Also accessed through the Description property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_NAME</term>
		/// <description>Also accessed through the Name property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_ROLE_APP_MEMBERS</term>
		/// <description>Also accessed through the AppMembers property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_ROLE_MEMBERS</term>
		/// <description>Also accessed through the Members property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_ROLE_MEMBERS_NAME</term>
		/// <description>Also accessed through the MembersName property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_ROLE_OPERATIONS</term>
		/// <description>Also accessed through the Operations property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_ROLE_TASKS</term>
		/// <description>Also accessed through the Tasks property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_WRITABLE</term>
		/// <description>Also accessed through the Writable property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>The return value is an HRESULT. A value of S_OK indicates success. Any other value indicates that the operation failed.</returns>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-getproperty
		[DispId(1610743823)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzRole</c> object property with the specified property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzRole</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// The value to set to the <c>IAzRole</c> object property specified by the <i>lPropId</i> parameter. The following table shows the
		/// type of data that must be used depending on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type (C++/Visual Basic)</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-setproperty HRESULT SetProperty( [in] LONG lPropId,
		// [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743824)]
		new void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>AppMembers</b> property retrieves the application groups that belong to the role.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-get_appmembers HRESULT get_AppMembers( VARIANT
		// *pvarProp );
		[DispId(1610743825)]
		new object AppMembers
		{
			[DispId(1610743825)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>Members</b> property retrieves the <c>security identifiers</c> (SIDs), in text form, of Windows accounts that belong to
		/// the role.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-get_members HRESULT get_Members( VARIANT *pvarProp );
		[DispId(1610743826)]
		new object Members
		{
			[DispId(1610743826)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Operations</b> property retrieves the operations associated with the role.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-get_operations HRESULT get_Operations( VARIANT
		// *pvarProp );
		[DispId(1610743827)]
		new object Operations
		{
			[DispId(1610743827)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Tasks</b> property retrieves the tasks associated with the role.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-get_tasks HRESULT get_Tasks( VARIANT *pvarProp );
		[DispId(1610743828)]
		new object Tasks
		{
			[DispId(1610743828)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>The <b>AddPropertyItem</b> method adds the specified entity to the specified list.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list to which to add the entity specified by the <i>varProp</i> parameter. The following table shows the
		/// possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_APP_MEMBERS</b></description>
		/// <description>Can also be added using the <c>AddAppMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_MEMBERS</b></description>
		/// <description>Can also be added using the <c>AddMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_MEMBERS_NAME</b></description>
		/// <description>Can also be added using the <c>AddMemberName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_OPERATIONS</b></description>
		/// <description>Can also be added using the <c>AddOperation</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_TASKS</b></description>
		/// <description>Can also be added using the <c>AddTask</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Entity to add to the list specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_ROLE_MEMBERS is specified for the <i>lPropId</i> parameter, the string is the text form of the <c>security
		/// identifier</c> (SID) of the Windows account to add to the list. If AZ_PROP_ROLE_MEMBERS_NAME is specified for the <i>lPropId</i>
		/// parameter, the string is the account name of the account to add to the list. The account name can be in either user principal
		/// name (UPN) format (for example, "someone@example.com") or in the "ExampleDomain\UserName" format. If AZ_PROP_ROLE_APP_MEMBERS is
		/// specified for the <i>lPropId</i> parameter, the string is the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to
		/// add to the list.
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-addpropertyitem HRESULT AddPropertyItem( [in] LONG
		// lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743829)]
		new void AddPropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeletePropertyItem</b> method removes the specified entity from the specified list.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list from which to remove the entity specified by the <i>varProp</i> parameter. The following table shows the
		/// possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_APP_MEMBERS</b></description>
		/// <description>Can also be removed using the <c>DeleteAppMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_MEMBERS</b></description>
		/// <description>Can also be removed using the <c>DeleteMember</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_MEMBERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeleteMemberName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_OPERATIONS</b></description>
		/// <description>Can also be removed using the <c>DeleteOperation</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_ROLE_TASKS</b></description>
		/// <description>Can also be removed using the <c>DeleteTask</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Entity to remove from the list specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_ROLE_MEMBERS is specified for the <i>lPropId</i> parameter, the string is the <c>security identifier</c> (SID) of the
		/// Windows account to remove from the list. If AZ_PROP_ROLE_MEMBERS_NAME is specified for the <i>lPropId</i> parameter, the string
		/// is the account name of the account to remove from the list. The account name can be in either user principal name (UPN) format
		/// (for example, "someone@example.com") or in the "ExampleDomain\UserName" format. If AZ_PROP_ROLE_APP_MEMBERS is specified for the
		/// <i>lPropId</i> parameter, the string is the <c>Name</c> property of the <c>IAzApplicationGroup</c> object to remove from the list.
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-deletepropertyitem HRESULT DeletePropertyItem( [in]
		// LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743830)]
		new void DeletePropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>IAzRole</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>Any additions or modifications to an <c>IAzRole</c> object are not persisted until the <b>Submit</b> method is called.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-submit HRESULT Submit( [in, optional] LONG lFlags,
		// [in, optional] VARIANT varReserved );
		[DispId(1610743831)]
		new void Submit([Optional, DefaultParameterValue((AZ_PROP_CONSTANTS)0), In] AZ_PROP_CONSTANTS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddMemberName</b> method adds the specified account name to the list of accounts that belong to the role.</summary>
		/// <param name="bstrProp">
		/// String that contains the account name to add to the list of accounts that belong to the role. The account name can be in either
		/// user principal name (UPN) format (for example, <c>someone@example.com</c>) or in the <c>ExampleDomain\UserName</c> format. If the
		/// domain is not in the <c>ExampleDomain\UserName</c> format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>To view the list of account names of accounts that belong to this role, use the <c>MembersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-addmembername HRESULT AddMemberName( [in] BSTR
		// bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743832)]
		new void AddMemberName([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteMemberName</b> method removes the specified account name from the list of accounts that belong to the role.
		/// </summary>
		/// <param name="bstrProp">
		/// String that contains the account name to remove from the list of accounts that belong to the role. The account name can be in
		/// either user principal name (UPN) format (for example, <c>someone@example.com</c>) or in the <c>ExampleDomain\UserName</c> format.
		/// If the domain is not in the <c>ExampleDomain\UserName</c> format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>To view the list of account names of accounts that belong to the role, use the <c>MembersName</c> property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-deletemembername HRESULT DeleteMemberName( [in]
		// BSTR bstrProp, [in, optional] VARIANT varReserved );
		[DispId(1610743833)]
		new void DeleteMemberName([In, MarshalAs(UnmanagedType.BStr)] string bstrProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>MembersName</b> property retrieves the account names of accounts that belong to the role.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-get_membersname HRESULT get_MembersName( VARIANT
		// *pvarProp );
		[DispId(1610743834)]
		new object MembersName
		{
			[DispId(1610743834)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddRoleDefinition</b> method adds the specified <c>IAzRoleDefinition</c> object to this <c>IAzRoleAssignment</c> object.
		/// </summary>
		/// <param name="bstrRoleDefinition">The name of the <c>IAzRoleDefinition</c> to add.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroleassignment-addroledefinition HRESULT
		// AddRoleDefinition( [in] BSTR bstrRoleDefinition );
		[DispId(1610809344)]
		void AddRoleDefinition([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleDefinition);

		/// <summary>
		/// The <b>DeleteRoleDefinition</b> method removes the <c>IAzRoleDefinition</c> object with the specified name from this
		/// <c>IAzRoleAssignment</c> object.
		/// </summary>
		/// <param name="bstrRoleDefinition">The name of the <c>IAzRoleDefinition</c> object to delete.</param>
		/// <remarks>
		/// If there are any references to an <c>IAzRoleDefinition</c> object that has been deleted from the cache, the
		/// <b>IAzRoleDefinition</b> object can no longer be used. In C++, you must release references to deleted <b>IAzRoleDefinition</b>
		/// objects by calling the <c>IUnknown::Release</c> method. In Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroleassignment-deleteroledefinition HRESULT
		// DeleteRoleDefinition( [in] BSTR bstrRoleDefinition );
		[DispId(1610809345)]
		void DeleteRoleDefinition([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleDefinition);

		/// <summary>
		/// <para>
		/// The <b>RoleDefinitions</b> property retrieves a collection of the <c>IAzRoleDefinition</c> objects associated with this
		/// <c>IAzRoleAssignment</c> object.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroleassignment-get_roledefinitions HRESULT
		// get_RoleDefinitions( IAzRoleDefinitions **ppRoleDefinitions );
		[DispId(1610809346)]
		IAzRoleDefinitions RoleDefinitions
		{
			[DispId(1610809346)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>Scope</b> property retrieves the <c>IAzScope</c> object that represents the scope in which this <c>IAzRoleAssignment</c>
		/// object is defined.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroleassignment-get_scope HRESULT get_Scope( IAzScope
		// **ppScope );
		[DispId(1610809347)]
		IAzScope Scope
		{
			[DispId(1610809347)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	/// <summary>Represents a collection of IAzRoleAssignment objects.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazroleassignments
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzRoleAssignments")]
	[ComImport, Guid("9C80B900-FCEB-4D73-A0F4-C83B0BBF2481")]
	public interface IAzRoleAssignments : IEnumerable
	{
		/// <summary>
		/// <para>
		/// The <b>Item</b> property retrieves the <c>IAzRoleAssignment</c> object at the specified index in the <c>IAzRoleAssignments</c> collection.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="Index"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroleassignments-get_item HRESULT get_Item( LONG Index,
		// VARIANT *pvarObtPtr );
		[DispId(0)]
		object this[[In] int Index]
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Count</b> property retrieves the number of <c>IAzRoleAssignments</c> objects in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroleassignments-get_count HRESULT get_Count( LONG
		// *plCount );
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>_NewEnum</b> property retrieves an <c>IEnumVARIANT</c> interface on an object that can be used to enumerate the
		/// <c>IAzRoleAssignments</c> collection. This property is hidden within Visual Basic and Visual Basic Scripting Edition (VBScript).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <returns></returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroleassignments-get__newenum HRESULT get__NewEnum(
		// LPUNKNOWN *ppEnumPtr );
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();
	}

	/// <summary>Represents one or more IAzRoleDefinition, IAzTask, and IAzOperation objects that specify a set of operations.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazroledefinition
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzRoleDefinition")]
	[ComImport, Guid("D97FCEA1-2599-44F1-9FC3-58E9FBE09466")]
	public interface IAzRoleDefinition : IAzTask
	{
		/// <summary>
		/// <para>The <b>Name</b> property sets or retrieves the name of the task.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Name</b> property is 64 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_name HRESULT put_Name( BSTR bstrName );
		[DispId(1610743808)]
		new string Name
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the task.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_description HRESULT put_Description( BSTR
		// bstrDescription );
		[DispId(1610743810)]
		new string Description
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>ApplicationData</b> property sets or retrieves an opaque field that can be used by the application to store information.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// <b>Important</b>  Policy administrators can read from and write to this property. Applications should not store data in the
		/// <b>ApplicationData</b> property that should not be available to the policy administrator.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_applicationdata?view=vs-2019 HRESULT
		// put_ApplicationData( BSTR bstrApplicationData );
		[DispId(1610743812)]
		new string ApplicationData
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>BizRule</b> property sets or retrieves the text of the script that implements the business rule (BizRule).</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>The maximum length of this property is 65,536 characters.</para>
		/// <para><b>Important</b>  The <c>BizRuleLanguage</c> property must be set before this property is set.</para>
		/// <para></para>
		/// <para>An <c>IAzTask</c> object that is a child object of a delegated <c>IAzScope</c> object cannot have an associated BizRule.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_bizrule HRESULT put_BizRule( BSTR bstrProp );
		[DispId(1610743814)]
		new string BizRule
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743814)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>BizRuleLanguage</b> property sets or retrieves the scripting language in which the business rule (BizRule) is implemented.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>This property must be set before the <c>BizRule</c> property is set.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_bizrulelanguage HRESULT put_BizRuleLanguage(
		// BSTR bstrProp );
		[DispId(1610743816)]
		new string BizRuleLanguage
		{
			[DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743816)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>BizRuleImportedPath</b> property sets or retrieves the path to the file from which the business rule (BizRule) is imported.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The path information is stored for use by the UI. The UI should supply a mechanism to synchronize the contents of the file and
		/// this property.
		/// </para>
		/// <para>The maximum length of this property is 512 characters.</para>
		/// </remarks>
		// https://learn.microsoft.com/nl-nl/windows/win32/api/azroles/nf-azroles-iaztask-put_bizruleimportedpath HRESULT
		// put_BizRuleImportedPath( BSTR bstrProp );
		[DispId(1610743818)]
		new string BizRuleImportedPath
		{
			[DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743818)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>IsRoleDefinition</b> property sets or retrieves a value that indicates whether the task is a role definition.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>This property represents a user interface abstraction and does not affect the functionality of the task.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_isroledefinition HRESULT put_IsRoleDefinition(
		// BOOL fProp );
		[DispId(1610743820)]
		new bool IsRoleDefinition
		{
			[DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(1610743820)]
			[param: In, MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>The <b>Operations</b> property retrieves the operations associated with the task.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-get_operations HRESULT get_Operations( VARIANT
		// *pvarProp );
		[DispId(1610743822)]
		new object Operations
		{
			[DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Tasks</b> property retrieves the tasks associated with the task.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>This property shows the nesting of <c>IAzTask</c> objects within another <b>IAzTask</b> object.</para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-get_tasks HRESULT get_Tasks( VARIANT *pvarProp );
		[DispId(1610743823)]
		new object Tasks
		{
			[DispId(1610743823)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>The <b>AddOperation</b> method adds the <c>IAzOperation</c> object with the specified name to the task.</summary>
		/// <param name="bstrOp">Name of the <c>IAzOperation</c> object to add to the task.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-addoperation HRESULT AddOperation( [in] BSTR
		// bstrOp, [in, optional] VARIANT varReserved );
		[DispId(1610743824)]
		new void AddOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrOp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeleteOperation</b> method removes the <c>IAzOperation</c> object with the specified name from the task.</summary>
		/// <param name="bstrOp">Name of the <c>IAzOperation</c> object to remove from the task.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzOperation</c> references to an <b>IAzOperation</b> object that has been deleted from the cache, the
		/// <b>IAzOperation</b> object can no longer be used. In C++, you must release references to deleted <b>IAzOperation</b> objects by
		/// calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-deleteoperation HRESULT DeleteOperation( [in] BSTR
		// bstrOp, [in, optional] VARIANT varReserved );
		[DispId(1610743825)]
		new void DeleteOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrOp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddTask</b> method adds the <c>IAzTask</c> object with the specified name to the task.</summary>
		/// <param name="bstrTask">Name of the <c>IAzTask</c> object to add to the task.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>This method allows the nesting of <c>IAzTask</c> objects within another <b>IAzTask</b> object.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-addtask HRESULT AddTask( [in] BSTR bstrTask, [in,
		// optional] VARIANT varReserved );
		[DispId(1610743826)]
		new void AddTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTask, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeleteTask</b> method removes the <c>IAzTask</c> object with the specified name from the task.</summary>
		/// <param name="bstrTask">Name of the <c>IAzTask</c> object to remove from the task.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzTask</c> references to an <b>IAzTask</b> object that has been deleted from the cache, the <b>IAzTask</b>
		/// object can no longer be used. In C++, you must release references to deleted <b>IAzTask</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-deletetask HRESULT DeleteTask( [in] BSTR bstrTask,
		// [in, optional] VARIANT varReserved );
		[DispId(1610743827)]
		new void DeleteTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTask, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the task can be modified by the user context that
		/// initialized it.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-get_writable HRESULT get_Writable( BOOL *pfProp );
		[DispId(1610743828)]
		new bool Writable
		{
			[DispId(1610743828)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzTask</c> object property with the specified property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzTask</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AZ_PROP_APPLICATION_DATA</term>
		/// <description>Also accessed through the ApplicationData property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CHILD_CREATE</term>
		/// <description>
		/// Determines whether the current user has permission to create child objects. This value is TRUE if the current user has
		/// permission; otherwise, FALSE.
		/// </description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_DESCRIPTION</term>
		/// <description>Also accessed through the Description property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_NAME</term>
		/// <description>Also accessed through the Name property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_TASK_BIZRULE</term>
		/// <description>Also accessed through the BizRule property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_TASK_BIZRULE_LANGUAGE</term>
		/// <description>Also accessed through the BizRuleLanguage property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_TASK_IS_ROLE_DEFINITION</term>
		/// <description>Also accessed through the IsRoleDefinition property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_TASK_OPERATIONS</term>
		/// <description>Also accessed through the Operations property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_TASK_TASKS</term>
		/// <description>Also accessed through the Tasks property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_WRITABLE</term>
		/// <description>Also accessed through the Writable property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to the returned IAzTask object property.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-getproperty
		[DispId(1610743829)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzTask</c> object property with the specified property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzTask</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_BIZRULE</b></description>
		/// <description>Also accessed through the <c>BizRule</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_BIZRULE_LANGUAGE</b></description>
		/// <description>Also accessed through the <c>BizRuleLanguage</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_IS_ROLE_DEFINITION</b></description>
		/// <description>Also accessed through the <c>IsRoleDefinition</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// Value to set to the <c>IAzTask</c> object property specified by the <i>lPropId</i> parameter. The following table shows the type
		/// of data that must be used depending on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_BIZRULE</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_BIZRULE_LANGUAGE</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_IS_ROLE_DEFINITION</b></description>
		/// <description><b>BOOL</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-setproperty HRESULT SetProperty( [in] LONG lPropId,
		// [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743830)]
		new void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddPropertyItem</b> method adds the specified entity to the specified list.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list to which to add the entity specified by the <i>varProp</i> parameter. The following table shows the
		/// possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_OPERATIONS</b></description>
		/// <description>Can also be added using the <c>AddOperation</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_TASKS</b></description>
		/// <description>Can also be added using the <c>AddTask</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Name of the entity to add to the list specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-addpropertyitem HRESULT AddPropertyItem( [in] LONG
		// lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743831)]
		new void AddPropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeletePropertyItem</b> method removes the specified entity from the specified list.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list from which to remove the entity specified by the <i>varProp</i> parameter. The following table shows the
		/// possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_OPERATIONS</b></description>
		/// <description>Can also be removed using the <c>DeleteOperation</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_TASKS</b></description>
		/// <description>Can also be removed using the <c>DeleteTask</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Name of the entity to remove from the list specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-deletepropertyitem HRESULT DeletePropertyItem( [in]
		// LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743832)]
		new void DeletePropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>IAzTask</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>Any additions or modifications to an <c>IAzTask</c> object are not persisted until the <b>Submit</b> method is called.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-submit HRESULT Submit( [in, optional] LONG lFlags,
		// [in, optional] VARIANT varReserved );
		[DispId(1610743833)]
		new void Submit([Optional, DefaultParameterValue((AZ_PROP_CONSTANTS)0), In] AZ_PROP_CONSTANTS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>RoleAssignments</b> function retrieves a collection of <c>IAzRoleAssignment</c> objects that represent the role
		/// assignments associated with this <c>IAzRoleDefinition</c> object.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="bstrScopeName">
		/// Provides a scope name to include in the search for <b>IAzRoleAssignment</b> objects. If this parameter is <b>NULL</b>, the search
		/// is performed in the global scope.
		/// </param>
		/// <param name="bRecursive">Indicates if the search for <b>IAzRoleAssignment</b> objects should be performed recursively.</param>
		/// <returns>
		/// The collection of <b>IAzRoleAssignment</b> objects that represent the role assignments associated with this
		/// <b>IAzRoleDefinition</b> object.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroledefinition-roleassignments HRESULT RoleAssignments(
		// BSTR bstrScopeName, VARIANT_BOOL bRecursive, IAzRoleAssignments **ppRoleAssignments );
		[DispId(1610809344)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRoleAssignments RoleAssignments([In, MarshalAs(UnmanagedType.BStr)] string? bstrScopeName, [In] bool bRecursive);

		/// <summary>
		/// The <b>AddRoleDefinition</b> method adds the specified <c>IAzRoleDefinition</c> object to this <b>IAzRoleDefinition</b> object.
		/// </summary>
		/// <param name="bstrRoleDefinition">The name of the <c>IAzRoleDefinition</c> to add.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroledefinition-addroledefinition HRESULT
		// AddRoleDefinition( [in] BSTR bstrRoleDefinition );
		[DispId(1610809345)]
		void AddRoleDefinition([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleDefinition);

		/// <summary>
		/// The <b>DeleteRoleDefinition</b> method removes the <c>IAzRoleDefinition</c> object with the specified name from this
		/// <b>IAzRoleDefinition</b> object.
		/// </summary>
		/// <param name="bstrRoleDefinition">The name of the <c>IAzRoleDefinition</c> object to delete.</param>
		/// <remarks>
		/// If there are any references to an <c>IAzRoleDefinition</c> object that has been deleted from the cache, the
		/// <b>IAzRoleDefinition</b> object can no longer be used. In C++, you must release references to deleted <b>IAzRoleDefinition</b>
		/// objects by calling the <c>IUnknown::Release</c> method. In Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroledefinition-deleteroledefinition HRESULT
		// DeleteRoleDefinition( [in] BSTR bstrRoleDefinition );
		[DispId(1610809346)]
		void DeleteRoleDefinition([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleDefinition);

		/// <summary>
		/// <para>
		/// The <b>RoleDefinitions</b> property retrieves a collection of the <c>IAzRoleDefinition</c> objects associated with this
		/// <b>IAzRoleDefinition</b> object.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroledefinition-get_roledefinitions HRESULT
		// get_RoleDefinitions( IAzRoleDefinitions **ppRoleDefinitions );
		[DispId(1610809347)]
		IAzRoleDefinitions RoleDefinitions
		{
			[DispId(1610809347)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	/// <summary>Represents a collection of IAzRoleDefinition objects.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazroledefinitions
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzRoleDefinitions")]
	[ComImport, Guid("881F25A5-D755-4550-957A-D503A3B34001")]
	public interface IAzRoleDefinitions : IEnumerable
	{
		/// <summary>
		/// <para>
		/// The <b>Item</b> property retrieves the <c>IAzRoleDefinition</c> object at the specified index in the <c>IAzRoleDefinitions</c> collection.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="Index"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroledefinitions-get_item HRESULT get_Item( LONG Index,
		// VARIANT *pvarObtPtr );
		[DispId(0)]
		object this[[In] int Index]
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Count</b> property retrieves the number of <c>IAzRoleDefinitions</c> objects in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroledefinitions-get_count HRESULT get_Count( LONG
		// *plCount );
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>_NewEnum</b> property retrieves an <c>IEnumVARIANT</c> interface on an object that can be used to enumerate the
		/// <c>IAzRoleDefinitions</c> collection. This property is hidden within Visual Basic and Visual Basic Scripting Edition (VBScript).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroledefinitions-get__newenum HRESULT get__NewEnum(
		// LPUNKNOWN *ppEnumPtr );
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();
	}

	/// <summary>Represents a collection of IAzRole objects.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazroles
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzRoles")]
	[ComImport, Guid("95E0F119-13B4-4DAE-B65F-2F7D60D822E4")]
	public interface IAzRoles : IEnumerable
	{
		/// <summary>
		/// <para>The <b>Item</b> property retrieves the <c>IAzRole</c> object at the specified index into the <c>IAzRoles</c> collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="Index"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroles-get_item HRESULT get_Item( LONG Index, VARIANT
		// *pvarObtPtr );
		[DispId(0)]
		object this[[In] int Index]
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Count</b> property retrieves the number of <c>IAzRole</c> objects in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// The <b>Count</b> property can be used to specify the last <c>IAzRole</c> object in a collection when retrieving a specific
		/// <b>IAzRole</b> object using the <c>IAzRoles.Item</c> property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroles-get_count HRESULT get_Count( LONG *plCount );
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>_NewEnum</b> property retrieves an <c>IEnumVARIANT</c> interface on an object that can be used to enumerate the
		/// collection. This property is hidden within Visual Basic and Visual Basic Scripting Edition (VBScript).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property is provided for use by the <c>For Each</c> keyword in Visual Basic and the <c>foreach</c> keyword in Visual C#.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazroles-get__newenum HRESULT get__NewEnum( LPUNKNOWN
		// *ppEnumPtr );
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();
	}

	/// <summary>Defines a logical container of resources to which the application manages access.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazscope
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzScope")]
	[ComImport, Guid("00E52487-E08D-4514-B62E-877D5645F5AB")]
	public interface IAzScope
	{
		/// <summary>
		/// <para>The <b>Name</b> property sets or retrieves the name of the scope.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Name</b> property is 512 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-put_name HRESULT put_Name( BSTR bstrName );
		[DispId(1610743808)]
		string Name
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the scope.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-put_description HRESULT put_Description( BSTR
		// bstrDescription );
		[DispId(1610743810)]
		string Description
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>ApplicationData</b> property sets or retrieves an opaque field that can be used by the application to store information.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// <b>Important</b>  Policy administrators can read from and write to this property. Applications should not store data in the
		/// <b>ApplicationData</b> property that should not be available to the policy administrator.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-put_applicationdata HRESULT put_ApplicationData(
		// BSTR bstrApplicationData );
		[DispId(1610743812)]
		string ApplicationData
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the scope can be modified by the user context that
		/// initialized it.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_writable HRESULT get_Writable( BOOL *pfProp );
		[DispId(1610743814)]
		bool Writable
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>The <b>GetProperty</b> method returns the <c>IAzScope</c> object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzScope</c> object property to return. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AZ_PROP_APPLICATION_DATA</term>
		/// <description>Also accessed through the ApplicationData property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CHILD_CREATE</term>
		/// <description>
		/// Determines whether the current user has permission to create child objects. This value is TRUE if the current user has
		/// permission; otherwise, FALSE.
		/// </description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_DESCRIPTION</term>
		/// <description>Also accessed through the Description property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_NAME</term>
		/// <description>Also accessed through the Name property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_POLICY_ADMINS</term>
		/// <description>Also accessed through the PolicyAdministrators property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_POLICY_ADMINS_NAME</term>
		/// <description>Also accessed through the PolicyAdministratorsName property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_POLICY_READERS</term>
		/// <description>Also accessed through the PolicyReaders property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_POLICY_READERS_NAME</term>
		/// <description>Also accessed through the PolicyReadersName property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_SCOPE_BIZRULES_WRITABLE</term>
		/// <description>Also accessed through the BizrulesWritable property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_SCOPE_CAN_BE_DELEGATED</term>
		/// <description>Also accessed through the CanBeDelegated property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_WRITABLE</term>
		/// <description>Also accessed through the Writable property</description>
		/// </item>
		/// ///
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to the returned IAzScope object property.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-getproperty
		[DispId(1610743815)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzScope</c> object property with the specified property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzScope</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// Value to set to the <c>IAzScope</c> object property specified by the <i>lPropId</i> parameter. The following table shows the type
		/// of data that must be used depending on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type (C++/Visual Basic)</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-setproperty HRESULT SetProperty( [in] LONG
		// lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743816)]
		void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddPropertyItem</b> method adds the specified principal to the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals to which to add the principal specified by the <i>varProp</i> parameter. The following
		/// table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be added using the <c>AddPolicyAdministrator</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be added using the <c>AddPolicyAdministratorName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be added using the <c>AddPolicyReader</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be added using the <c>AddPolicyReaderName</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Principal to add to the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS or AZ_PROP_POLICY_READERS is specified for the <i>lPropId</i> parameter, the string is the text form of
		/// the <c>security identifier</c> (SID) of the Windows account to add to the list. If AZ_PROP_POLICY_ADMINS_NAME or
		/// AZ_PROP_POLICY_READERS_NAME is specified for the <i>lPropId</i> parameter, the string is the account name of the account to add
		/// to the list. The account name can be in either user principal name (UPN) format (for example, "someone@example.com") or in the
		/// "ExampleDomain\UserName" format.
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-addpropertyitem HRESULT AddPropertyItem( [in] LONG
		// lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743817)]
		void AddPropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeletePropertyItem</b> method removes the specified principal from the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals from which to remove the principal specified by the <i>varProp</i> parameter. The following
		/// table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministrator</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministratorName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReader</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReaderName</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Principal to remove from the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS or AZ_PROP_POLICY_READERS is specified for the <i>lPropId</i> parameter, the string is the text form of
		/// the <c>security identifier</c> (SID) of the Windows account to remove from the list. If AZ_PROP_POLICY_ADMINS_NAME or
		/// AZ_PROP_POLICY_READERS_NAME is specified for the <i>lPropId</i> parameter, the string is the account name of the account to
		/// remove from the list. The account name can be in either user principal name (UPN) format (for example, "someone@example.com") or
		/// in the "ExampleDomain\UserName" format.
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deletepropertyitem HRESULT DeletePropertyItem(
		// [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743818)]
		void DeletePropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>PolicyAdministrators</b> property retrieves the <c>security identifiers</c> (SIDs), in text form, of principals that act
		/// as policy administrators.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_policyadministrators HRESULT
		// get_PolicyAdministrators( VARIANT *pvarAdmins );
		[DispId(1610743819)]
		object PolicyAdministrators
		{
			[DispId(1610743819)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>PolicyReaders</b> property retrieves the <c>security identifiers</c> (SIDs), in text form, of principals that act as
		/// policy readers.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_policyreaders HRESULT get_PolicyReaders(
		// VARIANT *pvarReaders );
		[DispId(1610743820)]
		object PolicyReaders
		{
			[DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddPolicyAdministrator</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to add to the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-addpolicyadministrator HRESULT
		// AddPolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743821)]
		void AddPolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministrator</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to remove from the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deletepolicyadministrator HRESULT
		// DeletePolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743822)]
		void DeletePolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReader</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of principals that
		/// act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to add to the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-addpolicyreader HRESULT AddPolicyReader( [in] BSTR
		// bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743823)]
		void AddPolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReader</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to remove from the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deletepolicyreader HRESULT DeletePolicyReader(
		// [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743824)]
		void DeletePolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>ApplicationGroups</b> property retrieves an <c>IAzApplicationGroups</c> object that is used to enumerate
		/// <c>IAzApplicationGroup</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzApplicationGroup</c> objects that are direct child objects of the
		/// <c>IAzScope</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_applicationgroups HRESULT
		// get_ApplicationGroups( IAzApplicationGroups **ppGroupCollection );
		[DispId(1610743825)]
		IAzApplicationGroups ApplicationGroups
		{
			[DispId(1610743825)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenApplicationGroup</b> method opens an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzApplicationGroup</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-openapplicationgroup HRESULT OpenApplicationGroup(
		// [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743826)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzApplicationGroup OpenApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateApplicationGroup</b> method creates an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name for the new <c>IAzApplicationGroup</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzApplicationGroup</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzApplicationGroup::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzApplicationGroup</c> object is an immediate child object of the <c>IAzScope</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-createapplicationgroup HRESULT
		// CreateApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743827)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzApplicationGroup CreateApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteApplicationGroup</b> method removes the <c>IAzApplicationGroup</c> object with the specified name from the
		/// <c>IAzScope</c> object.
		/// </summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzApplicationGroup</c> references to an <b>IAzApplicationGroup</b> object that has been deleted from the
		/// cache, the <b>IAzApplicationGroup</b> object can no longer be used. In C++, you must release references to deleted
		/// <b>IAzApplicationGroup</b> objects by calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted
		/// objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deleteapplicationgroup HRESULT
		// DeleteApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved );
		[DispId(1610743828)]
		void DeleteApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>Microsoft.Interop.Security.Azroles.IAzScope</b> interoperability wrapper methods and properties are documented under the
		/// COM version of the method or property. A link to the correlating COM documentation follows each member name.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/secauthz/microsoft-interop-security-azroles-iazscope-interface
		[DispId(1610743829)]
		IAzRoles Roles
		{
			[DispId(1610743829)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenRole</b> method opens an <c>IAzRole</c> object with the specified name.</summary>
		/// <param name="bstrRoleName">Name of the <c>IAzRole</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzRole</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-openrole HRESULT OpenRole( [in] BSTR bstrRoleName,
		// [in, optional] VARIANT varReserved, [out] IAzRole **ppRole );
		[DispId(1610743830)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRole OpenRole([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateRole</b> method creates an <c>IAzRole</c> object with the specified name.</summary>
		/// <param name="bstrRoleName">Name for the new <c>IAzRole</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzRole</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzRole::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzRole</c> object is an immediate child object of the <c>IAzScope</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-createrole HRESULT CreateRole( [in] BSTR
		// bstrRoleName, [in, optional] VARIANT varReserved, [out] IAzRole **ppRole );
		[DispId(1610743831)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRole CreateRole([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeleteRole</b> method removes the <c>IAzRole</c> object with the specified name from the <c>IAzScope</c> object.</summary>
		/// <param name="bstrRoleName">Name of the <c>IAzRole</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzRole</c> references to an <b>IAzRole</b> object that has been deleted from the cache, the <b>IAzRole</b>
		/// object can no longer be used. In C++, you must release references to deleted <b>IAzRole</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deleterole HRESULT DeleteRole( [in] BSTR
		// bstrRoleName, [in, optional] VARIANT varReserved );
		[DispId(1610743832)]
		void DeleteRole([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Tasks</b> property retrieves an <c>IAzTasks</c> object that is used to enumerate <c>IAzTask</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzTask</c> objects that are direct child objects of the <c>IAzScope</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_tasks HRESULT get_Tasks( IAzTasks
		// **ppTaskCollection );
		[DispId(1610743833)]
		IAzTasks Tasks
		{
			[DispId(1610743833)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenTask</b> method opens an <c>IAzTask</c> object with the specified name.</summary>
		/// <param name="bstrTaskName">Name of the <c>IAzTask</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzTask</c> object.</returns>
		// https://learn.microsoft.com/nl-be/windows/win32/api/azroles/nf-azroles-iazscope-opentask HRESULT OpenTask( [in] BSTR bstrTaskName,
		// [in, optional] VARIANT varReserved, [out] IAzTask **ppTask );
		[DispId(1610743834)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzTask OpenTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTaskName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateTask</b> method creates an <c>IAzTask</c> object with the specified name.</summary>
		/// <param name="bstrTaskName">Name for the new <c>IAzTask</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzTask</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzTask::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzTask</c> object is an immediate child object of the <c>IAzScope</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-createtask HRESULT CreateTask( [in] BSTR
		// bstrTaskName, [in, optional] VARIANT varReserved, [out] IAzTask **ppTask );
		[DispId(1610743835)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzTask CreateTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTaskName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeleteTask</b> method removes the <c>IAzTask</c> object with the specified name from the <c>IAzScope</c> object.</summary>
		/// <param name="bstrTaskName">Name of the <c>IAzTask</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzTask</c> references to an <b>IAzTask</b> object that has been deleted from the cache, the <b>IAzTask</b>
		/// object can no longer be used. In C++, you must release references to deleted <b>IAzTask</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deletetask HRESULT DeleteTask( [in] BSTR
		// bstrTaskName, [in, optional] VARIANT varReserved );
		[DispId(1610743836)]
		void DeleteTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTaskName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>IAzScope</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Any additions or modifications to an <c>IAzScope</c> object are not persisted until the <b>Submit</b> method is called.</para>
		/// <para>
		/// The <b>Submit</b> method does not extend to child objects; child objects must be individually persisted to the policy store. A
		/// created <c>IAzScope</c> object must be submitted before it can be referenced or become a parent object. The destructor for an
		/// object silently discards unsubmitted changes.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-submit HRESULT Submit( [in] LONG lFlags, [in,
		// optional] VARIANT varReserved );
		[DispId(1610743837)]
		void Submit([Optional, DefaultParameterValue((AZ_PROP_CONSTANTS)0), In] AZ_PROP_CONSTANTS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>CanBeDelegated</b> property retrieves a value that indicates whether the scope can be delegated.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/is-is/windows/win32/api/azroles/nf-azroles-iazscope-get_canbedelegated HRESULT get_CanBeDelegated(
		// BOOL *pfProp );
		[DispId(1610743838)]
		bool CanBeDelegated
		{
			[DispId(1610743838)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>
		/// <para>The <b>BizrulesWritable</b> property retrieves a value that indicates whether a non-delegated scope is writable.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_bizruleswritable HRESULT get_BizrulesWritable(
		// BOOL *pfProp );
		[DispId(1610743839)]
		bool BizrulesWritable
		{
			[DispId(1610743839)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>
		/// <para>The <b>PolicyAdministratorsName</b> property retrieves the account names of principals that act as policy administrators.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_policyadministratorsname HRESULT
		// get_PolicyAdministratorsName( VARIANT *pvarAdmins );
		[DispId(1610743840)]
		object PolicyAdministratorsName
		{
			[DispId(1610743840)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>PolicyReadersName</b> property retrieves the account names of principals that act as policy readers.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_policyreadersname HRESULT
		// get_PolicyReadersName( VARIANT *pvarReaders );
		[DispId(1610743841)]
		object PolicyReadersName
		{
			[DispId(1610743841)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddPolicyAdministratorName</b> method adds the specified account name to the list of principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">
		/// The account name to add to the list of policy administrators. The account name can be in either user principal name (UPN) format
		/// (for example, <c>someone@example.com</c>) or in the <c>ExampleDomain\UserName</c> format. If the domain is not in the
		/// <c>ExampleDomain\UserName</c> format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-addpolicyadministratorname HRESULT
		// AddPolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743842)]
		void AddPolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministratorName</b> method removes the specified account name from the list of principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">
		/// Account name to remove from the list of policy administrators. The account name can be in either user principal name (UPN) format
		/// (for example, <c>someone@example.com</c>) or in the <c>ExampleDomain\UserName</c> format. If the domain is not in the
		/// <c>ExampleDomain\UserName</c> format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deletepolicyadministratorname HRESULT
		// DeletePolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743843)]
		void DeletePolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReaderName</b> method adds the specified account name to the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// Account name to add to the list of policy readers. The account name can be in either user principal name (UPN) format (for
		/// example, <c>someone@example.com</c>) or in the <c>ExampleDomain\UserName</c> format. If the domain is not in the
		/// <c>ExampleDomain\UserName</c> format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-addpolicyreadername HRESULT AddPolicyReaderName(
		// [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743844)]
		void AddPolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReaderName</b> method removes the specified account name from the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// Account name to remove from the list of policy readers. The account name can be in either user principal name (UPN) format (for
		/// example, <c>someone@example.com</c>) or in the <c>ExampleDomain\UserName</c> format. If the domain is not in the
		/// <c>ExampleDomain\UserName</c> format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deletepolicyreadername HRESULT
		// DeletePolicyReaderName( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743845)]
		void DeletePolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);
	}

	/// <summary>Extends the IAzScope interface to manage IAzRoleAssignment and IAzRoleDefinition objects.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazscope2
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzScope2")]
	[ComImport, Guid("EE9FE8C9-C9F3-40E2-AA12-D1D8599727FD")]
	public interface IAzScope2 : IAzScope
	{
		/// <summary>
		/// <para>The <b>Name</b> property sets or retrieves the name of the scope.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Name</b> property is 512 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-put_name HRESULT put_Name( BSTR bstrName );
		[DispId(1610743808)]
		new string Name
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the scope.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-put_description HRESULT put_Description( BSTR
		// bstrDescription );
		[DispId(1610743810)]
		new string Description
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>ApplicationData</b> property sets or retrieves an opaque field that can be used by the application to store information.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// <b>Important</b>  Policy administrators can read from and write to this property. Applications should not store data in the
		/// <b>ApplicationData</b> property that should not be available to the policy administrator.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-put_applicationdata HRESULT put_ApplicationData(
		// BSTR bstrApplicationData );
		[DispId(1610743812)]
		new string ApplicationData
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the scope can be modified by the user context that
		/// initialized it.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_writable HRESULT get_Writable( BOOL *pfProp );
		[DispId(1610743814)]
		new bool Writable
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>The <b>GetProperty</b> method returns the <c>IAzScope</c> object property with the specified property ID.</summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzScope</c> object property to return. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AZ_PROP_APPLICATION_DATA</term>
		/// <description>Also accessed through the ApplicationData property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CHILD_CREATE</term>
		/// <description>
		/// Determines whether the current user has permission to create child objects. This value is TRUE if the current user has
		/// permission; otherwise, FALSE.
		/// </description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_DESCRIPTION</term>
		/// <description>Also accessed through the Description property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_NAME</term>
		/// <description>Also accessed through the Name property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_POLICY_ADMINS</term>
		/// <description>Also accessed through the PolicyAdministrators property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_POLICY_ADMINS_NAME</term>
		/// <description>Also accessed through the PolicyAdministratorsName property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_POLICY_READERS</term>
		/// <description>Also accessed through the PolicyReaders property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_POLICY_READERS_NAME</term>
		/// <description>Also accessed through the PolicyReadersName property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_SCOPE_BIZRULES_WRITABLE</term>
		/// <description>Also accessed through the BizrulesWritable property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_SCOPE_CAN_BE_DELEGATED</term>
		/// <description>Also accessed through the CanBeDelegated property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_WRITABLE</term>
		/// <description>Also accessed through the Writable property</description>
		/// </item>
		/// ///
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to the returned IAzScope object property.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-getproperty
		[DispId(1610743815)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzScope</c> object property with the specified property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzScope</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// Value to set to the <c>IAzScope</c> object property specified by the <i>lPropId</i> parameter. The following table shows the type
		/// of data that must be used depending on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type (C++/Visual Basic)</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description><b>BSTR</b>/ <b>String</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-setproperty HRESULT SetProperty( [in] LONG
		// lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743816)]
		new void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddPropertyItem</b> method adds the specified principal to the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals to which to add the principal specified by the <i>varProp</i> parameter. The following
		/// table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be added using the <c>AddPolicyAdministrator</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be added using the <c>AddPolicyAdministratorName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be added using the <c>AddPolicyReader</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be added using the <c>AddPolicyReaderName</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Principal to add to the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS or AZ_PROP_POLICY_READERS is specified for the <i>lPropId</i> parameter, the string is the text form of
		/// the <c>security identifier</c> (SID) of the Windows account to add to the list. If AZ_PROP_POLICY_ADMINS_NAME or
		/// AZ_PROP_POLICY_READERS_NAME is specified for the <i>lPropId</i> parameter, the string is the account name of the account to add
		/// to the list. The account name can be in either user principal name (UPN) format (for example, "someone@example.com") or in the
		/// "ExampleDomain\UserName" format.
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-addpropertyitem HRESULT AddPropertyItem( [in] LONG
		// lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743817)]
		new void AddPropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeletePropertyItem</b> method removes the specified principal from the specified list of principals.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list of principals from which to remove the principal specified by the <i>varProp</i> parameter. The following
		/// table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministrator</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_ADMINS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyAdministratorName</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReader</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_POLICY_READERS_NAME</b></description>
		/// <description>Can also be removed using the <c>DeletePolicyReaderName</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Principal to remove from the list of principals specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// <para>
		/// If AZ_PROP_POLICY_ADMINS or AZ_PROP_POLICY_READERS is specified for the <i>lPropId</i> parameter, the string is the text form of
		/// the <c>security identifier</c> (SID) of the Windows account to remove from the list. If AZ_PROP_POLICY_ADMINS_NAME or
		/// AZ_PROP_POLICY_READERS_NAME is specified for the <i>lPropId</i> parameter, the string is the account name of the account to
		/// remove from the list. The account name can be in either user principal name (UPN) format (for example, "someone@example.com") or
		/// in the "ExampleDomain\UserName" format.
		/// </para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deletepropertyitem HRESULT DeletePropertyItem(
		// [in] LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743818)]
		new void DeletePropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>PolicyAdministrators</b> property retrieves the <c>security identifiers</c> (SIDs), in text form, of principals that act
		/// as policy administrators.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_policyadministrators HRESULT
		// get_PolicyAdministrators( VARIANT *pvarAdmins );
		[DispId(1610743819)]
		new object PolicyAdministrators
		{
			[DispId(1610743819)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>PolicyReaders</b> property retrieves the <c>security identifiers</c> (SIDs), in text form, of principals that act as
		/// policy readers.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_policyreaders HRESULT get_PolicyReaders(
		// VARIANT *pvarReaders );
		[DispId(1610743820)]
		new object PolicyReaders
		{
			[DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddPolicyAdministrator</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to add to the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-addpolicyadministrator HRESULT
		// AddPolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743821)]
		new void AddPolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministrator</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">Text form of the SID to remove from the list of policy administrators.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deletepolicyadministrator HRESULT
		// DeletePolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743822)]
		new void DeletePolicyAdministrator([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReader</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of principals that
		/// act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to add to the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-addpolicyreader HRESULT AddPolicyReader( [in] BSTR
		// bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743823)]
		new void AddPolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReader</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
		/// principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">Text form of the SID to remove from the list of policy readers.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deletepolicyreader HRESULT DeletePolicyReader(
		// [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743824)]
		new void DeletePolicyReader([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>ApplicationGroups</b> property retrieves an <c>IAzApplicationGroups</c> object that is used to enumerate
		/// <c>IAzApplicationGroup</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzApplicationGroup</c> objects that are direct child objects of the
		/// <c>IAzScope</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_applicationgroups HRESULT
		// get_ApplicationGroups( IAzApplicationGroups **ppGroupCollection );
		[DispId(1610743825)]
		new IAzApplicationGroups ApplicationGroups
		{
			[DispId(1610743825)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenApplicationGroup</b> method opens an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzApplicationGroup</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-openapplicationgroup HRESULT OpenApplicationGroup(
		// [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743826)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplicationGroup OpenApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateApplicationGroup</b> method creates an <c>IAzApplicationGroup</c> object with the specified name.</summary>
		/// <param name="bstrGroupName">Name for the new <c>IAzApplicationGroup</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzApplicationGroup</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzApplicationGroup::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzApplicationGroup</c> object is an immediate child object of the <c>IAzScope</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-createapplicationgroup HRESULT
		// CreateApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved, [out] IAzApplicationGroup **ppGroup );
		[DispId(1610743827)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzApplicationGroup CreateApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeleteApplicationGroup</b> method removes the <c>IAzApplicationGroup</c> object with the specified name from the
		/// <c>IAzScope</c> object.
		/// </summary>
		/// <param name="bstrGroupName">Name of the <c>IAzApplicationGroup</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzApplicationGroup</c> references to an <b>IAzApplicationGroup</b> object that has been deleted from the
		/// cache, the <b>IAzApplicationGroup</b> object can no longer be used. In C++, you must release references to deleted
		/// <b>IAzApplicationGroup</b> objects by calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted
		/// objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deleteapplicationgroup HRESULT
		// DeleteApplicationGroup( [in] BSTR bstrGroupName, [in, optional] VARIANT varReserved );
		[DispId(1610743828)]
		new void DeleteApplicationGroup([In, MarshalAs(UnmanagedType.BStr)] string bstrGroupName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>Microsoft.Interop.Security.Azroles.IAzScope</b> interoperability wrapper methods and properties are documented under the
		/// COM version of the method or property. A link to the correlating COM documentation follows each member name.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/secauthz/microsoft-interop-security-azroles-iazscope-interface
		[DispId(1610743829)]
		new IAzRoles Roles
		{
			[DispId(1610743829)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenRole</b> method opens an <c>IAzRole</c> object with the specified name.</summary>
		/// <param name="bstrRoleName">Name of the <c>IAzRole</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzRole</c> object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-openrole HRESULT OpenRole( [in] BSTR bstrRoleName,
		// [in, optional] VARIANT varReserved, [out] IAzRole **ppRole );
		[DispId(1610743830)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzRole OpenRole([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateRole</b> method creates an <c>IAzRole</c> object with the specified name.</summary>
		/// <param name="bstrRoleName">Name for the new <c>IAzRole</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzRole</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzRole::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzRole</c> object is an immediate child object of the <c>IAzScope</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-createrole HRESULT CreateRole( [in] BSTR
		// bstrRoleName, [in, optional] VARIANT varReserved, [out] IAzRole **ppRole );
		[DispId(1610743831)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzRole CreateRole([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeleteRole</b> method removes the <c>IAzRole</c> object with the specified name from the <c>IAzScope</c> object.</summary>
		/// <param name="bstrRoleName">Name of the <c>IAzRole</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzRole</c> references to an <b>IAzRole</b> object that has been deleted from the cache, the <b>IAzRole</b>
		/// object can no longer be used. In C++, you must release references to deleted <b>IAzRole</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deleterole HRESULT DeleteRole( [in] BSTR
		// bstrRoleName, [in, optional] VARIANT varReserved );
		[DispId(1610743832)]
		new void DeleteRole([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Tasks</b> property retrieves an <c>IAzTasks</c> object that is used to enumerate <c>IAzTask</c> objects from the policy data.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// This property can be used only to enumerate <c>IAzTask</c> objects that are direct child objects of the <c>IAzScope</c> object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_tasks HRESULT get_Tasks( IAzTasks
		// **ppTaskCollection );
		[DispId(1610743833)]
		new IAzTasks Tasks
		{
			[DispId(1610743833)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The <b>OpenTask</b> method opens an <c>IAzTask</c> object with the specified name.</summary>
		/// <param name="bstrTaskName">Name of the <c>IAzTask</c> object to open.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the opened <c>IAzTask</c> object.</returns>
		// https://learn.microsoft.com/nl-be/windows/win32/api/azroles/nf-azroles-iazscope-opentask HRESULT OpenTask( [in] BSTR bstrTaskName,
		// [in, optional] VARIANT varReserved, [out] IAzTask **ppTask );
		[DispId(1610743834)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzTask OpenTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTaskName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>CreateTask</b> method creates an <c>IAzTask</c> object with the specified name.</summary>
		/// <param name="bstrTaskName">Name for the new <c>IAzTask</c> object.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to a pointer to the created <c>IAzTask</c> object.</returns>
		/// <remarks>
		/// <para>You must call the <c>IAzTask::Submit</c> method to persist any changes made to the returned object.</para>
		/// <para>The returned <c>IAzTask</c> object is an immediate child object of the <c>IAzScope</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-createtask HRESULT CreateTask( [in] BSTR
		// bstrTaskName, [in, optional] VARIANT varReserved, [out] IAzTask **ppTask );
		[DispId(1610743835)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IAzTask CreateTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTaskName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeleteTask</b> method removes the <c>IAzTask</c> object with the specified name from the <c>IAzScope</c> object.</summary>
		/// <param name="bstrTaskName">Name of the <c>IAzTask</c> object to delete.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzTask</c> references to an <b>IAzTask</b> object that has been deleted from the cache, the <b>IAzTask</b>
		/// object can no longer be used. In C++, you must release references to deleted <b>IAzTask</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deletetask HRESULT DeleteTask( [in] BSTR
		// bstrTaskName, [in, optional] VARIANT varReserved );
		[DispId(1610743836)]
		new void DeleteTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTaskName, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>IAzScope</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Any additions or modifications to an <c>IAzScope</c> object are not persisted until the <b>Submit</b> method is called.</para>
		/// <para>
		/// The <b>Submit</b> method does not extend to child objects; child objects must be individually persisted to the policy store. A
		/// created <c>IAzScope</c> object must be submitted before it can be referenced or become a parent object. The destructor for an
		/// object silently discards unsubmitted changes.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-submit HRESULT Submit( [in] LONG lFlags, [in,
		// optional] VARIANT varReserved );
		[DispId(1610743837)]
		new void Submit([Optional, DefaultParameterValue((AZ_PROP_CONSTANTS)0), In] AZ_PROP_CONSTANTS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>The <b>CanBeDelegated</b> property retrieves a value that indicates whether the scope can be delegated.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/is-is/windows/win32/api/azroles/nf-azroles-iazscope-get_canbedelegated HRESULT get_CanBeDelegated(
		// BOOL *pfProp );
		[DispId(1610743838)]
		new bool CanBeDelegated
		{
			[DispId(1610743838)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>
		/// <para>The <b>BizrulesWritable</b> property retrieves a value that indicates whether a non-delegated scope is writable.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_bizruleswritable HRESULT get_BizrulesWritable(
		// BOOL *pfProp );
		[DispId(1610743839)]
		new bool BizrulesWritable
		{
			[DispId(1610743839)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>
		/// <para>The <b>PolicyAdministratorsName</b> property retrieves the account names of principals that act as policy administrators.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_policyadministratorsname HRESULT
		// get_PolicyAdministratorsName( VARIANT *pvarAdmins );
		[DispId(1610743840)]
		new object PolicyAdministratorsName
		{
			[DispId(1610743840)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>PolicyReadersName</b> property retrieves the account names of principals that act as policy readers.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-get_policyreadersname HRESULT
		// get_PolicyReadersName( VARIANT *pvarReaders );
		[DispId(1610743841)]
		new object PolicyReadersName
		{
			[DispId(1610743841)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// The <b>AddPolicyAdministratorName</b> method adds the specified account name to the list of principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">
		/// The account name to add to the list of policy administrators. The account name can be in either user principal name (UPN) format
		/// (for example, <c>someone@example.com</c>) or in the <c>ExampleDomain\UserName</c> format. If the domain is not in the
		/// <c>ExampleDomain\UserName</c> format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-addpolicyadministratorname HRESULT
		// AddPolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743842)]
		new void AddPolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyAdministratorName</b> method removes the specified account name from the list of principals that act as policy administrators.
		/// </summary>
		/// <param name="bstrAdmin">
		/// Account name to remove from the list of policy administrators. The account name can be in either user principal name (UPN) format
		/// (for example, <c>someone@example.com</c>) or in the <c>ExampleDomain\UserName</c> format. If the domain is not in the
		/// <c>ExampleDomain\UserName</c> format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>Policy administrators for an object can perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Read the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to the object</description>
		/// </item>
		/// <item>
		/// <description>Read attributes of child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Write attributes to child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Delete the object</description>
		/// </item>
		/// <item>
		/// <description>Delete child objects of the object</description>
		/// </item>
		/// <item>
		/// <description>Create child objects of the object</description>
		/// </item>
		/// </list>
		/// <para>To view the list of policy administrators in account name format, use the <c>PolicyAdministratorsName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deletepolicyadministratorname HRESULT
		// DeletePolicyAdministratorName( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
		[DispId(1610743843)]
		new void DeletePolicyAdministratorName([In, MarshalAs(UnmanagedType.BStr)] string bstrAdmin, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>AddPolicyReaderName</b> method adds the specified account name to the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// Account name to add to the list of policy readers. The account name can be in either user principal name (UPN) format (for
		/// example, <c>someone@example.com</c>) or in the <c>ExampleDomain\UserName</c> format. If the domain is not in the
		/// <c>ExampleDomain\UserName</c> format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-addpolicyreadername HRESULT AddPolicyReaderName(
		// [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743844)]
		new void AddPolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>DeletePolicyReaderName</b> method removes the specified account name from the list of principals that act as policy readers.
		/// </summary>
		/// <param name="bstrReader">
		/// Account name to remove from the list of policy readers. The account name can be in either user principal name (UPN) format (for
		/// example, <c>someone@example.com</c>) or in the <c>ExampleDomain\UserName</c> format. If the domain is not in the
		/// <c>ExampleDomain\UserName</c> format, the <c>LookupAccountName</c> function is called to retrieve the domain.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>
		/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
		/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
		/// </para>
		/// <para>To view the list of policy readers in account name format, use the <c>PolicyReadersName</c> property.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope-deletepolicyreadername HRESULT
		// DeletePolicyReaderName( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
		[DispId(1610743845)]
		new void DeletePolicyReaderName([In, MarshalAs(UnmanagedType.BStr)] string bstrReader, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>RoleDefinitions</b> property retrieves an <c>IAzRoleDefinitions</c> object that represents the collection of
		/// <c>IAzRoleDefinition</c> objects associated with this scope.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope2-get_roledefinitions HRESULT get_RoleDefinitions(
		// IAzRoleDefinitions **ppRoleDefinitions );
		[DispId(1610809344)]
		IAzRoleDefinitions RoleDefinitions
		{
			[DispId(1610809344)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// The <b>CreateRoleDefinition</b> method creates a new <c>IAzRoleDefinition</c> object with the specified name in this scope.
		/// </summary>
		/// <param name="bstrRoleDefinitionName">A string that contains the name of the new <c>IAzRoleDefinition</c> object.</param>
		/// <returns>
		/// <para>The address of a pointer to the <c>IAzRoleDefinition</c> object that this method creates.</para>
		/// <para>When you have finished using the <c>IAzRoleDefinition</c> object, release it by calling the <c>IUnknown::Release</c> method.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope2-createroledefinition HRESULT
		// CreateRoleDefinition( [in] BSTR bstrRoleDefinitionName, [out] IAzRoleDefinition **ppRoleDefinitions );
		[DispId(1610809345)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRoleDefinition CreateRoleDefinition([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleDefinitionName);

		/// <summary>The <b>OpenRoleDefinition</b> method opens an <c>IAzRoleDefinition</c> object with the specified name in this scope.</summary>
		/// <param name="bstrRoleDefinitionName">A string that contains the name of the <c>IAzRoleDefinition</c> object to open.</param>
		/// <returns>
		/// <para>The address of a pointer to the <c>IAzRoleDefinition</c> object that this method opens.</para>
		/// <para>When you have finished using the <c>IAzRoleDefinition</c> object, release it by calling the <c>IUnknown::Release</c> method.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope2-openroledefinition HRESULT OpenRoleDefinition(
		// [in] BSTR bstrRoleDefinitionName, [out] IAzRoleDefinition **ppRoleDefinitions );
		[DispId(1610809346)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRoleDefinition OpenRoleDefinition([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleDefinitionName);

		/// <summary>The <b>DeleteRoleDefinition</b> method removes the specified <c>IAzRoleDefinition</c> object from this scope.</summary>
		/// <param name="bstrRoleDefinitionName">A string that contains the name of the <c>IAzRoleDefinition</c> object to remove.</param>
		/// <remarks>
		/// If any references to an <c>IAzRoleDefinition</c> object have been deleted from the cache, that object can no longer be used. In
		/// C++, you must release references to deleted <b>IAzRoleDefinition</b> objects by calling the <c>IUnknown::Release</c> method. In
		/// Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope2-deleteroledefinition HRESULT
		// DeleteRoleDefinition( [in] BSTR bstrRoleDefinitionName );
		[DispId(1610809347)]
		void DeleteRoleDefinition([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleDefinitionName);

		/// <summary>
		/// <para>
		/// The <b>RoleAssignments</b> property retrieves an <c>IAzRoleAssignments</c> object that represents the collection of
		/// <c>IAzRoleAssignment</c> objects associated with this scope.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope2-get_roleassignments HRESULT get_RoleAssignments(
		// IAzRoleAssignments **ppRoleAssignments );
		[DispId(1610809348)]
		IAzRoleAssignments RoleAssignments
		{
			[DispId(1610809348)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// The <b>CreateRoleAssignment</b> method creates a new <c>IAzRoleAssignment</c> object with the specified name in this scope.
		/// </summary>
		/// <param name="bstrRoleAssignmentName">A string that contains the name of the new <c>IAzRoleAssignment</c> object.</param>
		/// <returns>
		/// <para>The address of a pointer to the <c>IAzRoleAssignment</c> object that this method creates.</para>
		/// <para>When you have finished using the <c>IAzRoleAssignment</c> object, release it by calling the <c>IUnknown::Release</c> method.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope2-createroleassignment HRESULT
		// CreateRoleAssignment( [in] BSTR bstrRoleAssignmentName, [out] IAzRoleAssignment **ppRoleAssignment );
		[DispId(1610809349)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRoleAssignment CreateRoleAssignment([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleAssignmentName);

		/// <summary>The <b>OpenRoleAssignment</b> method opens an <c>IAzRoleAssignment</c> object with the specified name in this scope.</summary>
		/// <param name="bstrRoleAssignmentName">A string that contains the name of the <c>IAzRoleAssignment</c> object to open.</param>
		/// <returns>
		/// <para>The address of a pointer to the <c>IAzRoleAssignment</c> object that this method opens.</para>
		/// <para>When you have finished using the <c>IAzRoleAssignment</c> object, release it by calling the <c>IUnknown::Release</c> method.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscope2-openroleassignment HRESULT OpenRoleAssignment(
		// [in] BSTR bstrRoleAssignmentName, [out] IAzRoleAssignment **ppRoleAssignment );
		[DispId(1610809350)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRoleAssignment OpenRoleAssignment([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleAssignmentName);

		/// <summary>The <b>DeleteRoleAssignment</b> method removes the specified <c>IAzRoleAssignment</c> object from this scope.</summary>
		/// <param name="bstrRoleAssignmentName">A string that contains the name of the <c>IAzRoleAssignment</c> object to remove.</param>
		/// <remarks>
		/// If any references to an <c>IAzRoleAssignment</c> object have been deleted from the cache, the <b>IAzRoleAssignment</b> object can
		/// no longer be used. In C++, you must release references to deleted <b>IAzRoleAssignment</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/lb-lu/windows/win32/api/azroles/nf-azroles-iazscope2-deleteroleassignment HRESULT
		// DeleteRoleAssignment( [in] BSTR bstrRoleAssignmentName );
		[DispId(1610809351)]
		void DeleteRoleAssignment([In, MarshalAs(UnmanagedType.BStr)] string bstrRoleAssignmentName);
	}

	/// <summary>Represents a collection of IAzScope objects.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iazscopes
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzScopes")]
	[ComImport, Guid("78E14853-9F5E-406D-9B91-6BDBA6973510")]
	public interface IAzScopes : IEnumerable
	{
		/// <summary>
		/// <para>The <b>Item</b> property retrieves the <c>IAzScope</c> object at the specified index into the <c>IAzScopes</c> collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="Index"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscopes-get_item HRESULT get_Item( LONG Index, VARIANT
		// *pvarObtPtr );
		[DispId(0)]
		object this[[In] int Index]
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Count</b> property retrieves the number of <c>IAzScope</c> objects in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// The <b>Count</b> property can be used to specify the last <c>IAzScope</c> object in a collection when retrieving a specific
		/// <b>IAzScope</b> object using the <c>IAzScopes.Item</c> property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscopes-get_count HRESULT get_Count( LONG *plCount );
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>NewEnum</b> property retrieves an <c>IEnumVARIANT</c> interface on an object that can be used to enumerate the collection.
		/// This property is hidden within Visual Basic and Visual Basic Scripting Edition (VBScript).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property is provided for use by the <c>For Each</c> keyword in Visual Basic and the <c>foreach</c> keyword in Visual C#.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazscopes-get__newenum HRESULT get__NewEnum( LPUNKNOWN
		// *ppEnumPtr );
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();
	}

	/// <summary>Describes a set of operations.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iaztask
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzTask")]
	[ComImport, Guid("CB94E592-2E0E-4A6C-A336-B89A6DC1E388")]
	public interface IAzTask
	{
		/// <summary>
		/// <para>The <b>Name</b> property sets or retrieves the name of the task.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Name</b> property is 64 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_name HRESULT put_Name( BSTR bstrName );
		[DispId(1610743808)]
		string Name
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the task.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_description HRESULT put_Description( BSTR
		// bstrDescription );
		[DispId(1610743810)]
		string Description
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>ApplicationData</b> property sets or retrieves an opaque field that can be used by the application to store information.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// <b>Important</b>  Policy administrators can read from and write to this property. Applications should not store data in the
		/// <b>ApplicationData</b> property that should not be available to the policy administrator.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_applicationdata?view=vs-2019 HRESULT
		// put_ApplicationData( BSTR bstrApplicationData );
		[DispId(1610743812)]
		string ApplicationData
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>BizRule</b> property sets or retrieves the text of the script that implements the business rule (BizRule).</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>The maximum length of this property is 65,536 characters.</para>
		/// <para><b>Important</b>  The <c>BizRuleLanguage</c> property must be set before this property is set.</para>
		/// <para></para>
		/// <para>An <c>IAzTask</c> object that is a child object of a delegated <c>IAzScope</c> object cannot have an associated BizRule.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_bizrule HRESULT put_BizRule( BSTR bstrProp );
		[DispId(1610743814)]
		string BizRule
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743814)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>BizRuleLanguage</b> property sets or retrieves the scripting language in which the business rule (BizRule) is implemented.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>This property must be set before the <c>BizRule</c> property is set.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_bizrulelanguage HRESULT put_BizRuleLanguage(
		// BSTR bstrProp );
		[DispId(1610743816)]
		string BizRuleLanguage
		{
			[DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743816)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>BizRuleImportedPath</b> property sets or retrieves the path to the file from which the business rule (BizRule) is imported.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The path information is stored for use by the UI. The UI should supply a mechanism to synchronize the contents of the file and
		/// this property.
		/// </para>
		/// <para>The maximum length of this property is 512 characters.</para>
		/// </remarks>
		// https://learn.microsoft.com/nl-nl/windows/win32/api/azroles/nf-azroles-iaztask-put_bizruleimportedpath HRESULT
		// put_BizRuleImportedPath( BSTR bstrProp );
		[DispId(1610743818)]
		string BizRuleImportedPath
		{
			[DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743818)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>IsRoleDefinition</b> property sets or retrieves a value that indicates whether the task is a role definition.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>This property represents a user interface abstraction and does not affect the functionality of the task.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_isroledefinition HRESULT put_IsRoleDefinition(
		// BOOL fProp );
		[DispId(1610743820)]
		bool IsRoleDefinition
		{
			[DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(1610743820)]
			[param: In, MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>The <b>Operations</b> property retrieves the operations associated with the task.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-get_operations HRESULT get_Operations( VARIANT
		// *pvarProp );
		[DispId(1610743822)]
		object Operations
		{
			[DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Tasks</b> property retrieves the tasks associated with the task.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>This property shows the nesting of <c>IAzTask</c> objects within another <b>IAzTask</b> object.</para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-get_tasks HRESULT get_Tasks( VARIANT *pvarProp );
		[DispId(1610743823)]
		object Tasks
		{
			[DispId(1610743823)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>The <b>AddOperation</b> method adds the <c>IAzOperation</c> object with the specified name to the task.</summary>
		/// <param name="bstrOp">Name of the <c>IAzOperation</c> object to add to the task.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-addoperation HRESULT AddOperation( [in] BSTR
		// bstrOp, [in, optional] VARIANT varReserved );
		[DispId(1610743824)]
		void AddOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrOp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeleteOperation</b> method removes the <c>IAzOperation</c> object with the specified name from the task.</summary>
		/// <param name="bstrOp">Name of the <c>IAzOperation</c> object to remove from the task.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzOperation</c> references to an <b>IAzOperation</b> object that has been deleted from the cache, the
		/// <b>IAzOperation</b> object can no longer be used. In C++, you must release references to deleted <b>IAzOperation</b> objects by
		/// calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-deleteoperation HRESULT DeleteOperation( [in] BSTR
		// bstrOp, [in, optional] VARIANT varReserved );
		[DispId(1610743825)]
		void DeleteOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrOp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddTask</b> method adds the <c>IAzTask</c> object with the specified name to the task.</summary>
		/// <param name="bstrTask">Name of the <c>IAzTask</c> object to add to the task.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>This method allows the nesting of <c>IAzTask</c> objects within another <b>IAzTask</b> object.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-addtask HRESULT AddTask( [in] BSTR bstrTask, [in,
		// optional] VARIANT varReserved );
		[DispId(1610743826)]
		void AddTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTask, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeleteTask</b> method removes the <c>IAzTask</c> object with the specified name from the task.</summary>
		/// <param name="bstrTask">Name of the <c>IAzTask</c> object to remove from the task.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzTask</c> references to an <b>IAzTask</b> object that has been deleted from the cache, the <b>IAzTask</b>
		/// object can no longer be used. In C++, you must release references to deleted <b>IAzTask</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-deletetask HRESULT DeleteTask( [in] BSTR bstrTask,
		// [in, optional] VARIANT varReserved );
		[DispId(1610743827)]
		void DeleteTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTask, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the task can be modified by the user context that
		/// initialized it.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-get_writable HRESULT get_Writable( BOOL *pfProp );
		[DispId(1610743828)]
		bool Writable
		{
			[DispId(1610743828)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzTask</c> object property with the specified property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzTask</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AZ_PROP_APPLICATION_DATA</term>
		/// <description>Also accessed through the ApplicationData property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CHILD_CREATE</term>
		/// <description>
		/// Determines whether the current user has permission to create child objects. This value is TRUE if the current user has
		/// permission; otherwise, FALSE.
		/// </description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_DESCRIPTION</term>
		/// <description>Also accessed through the Description property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_NAME</term>
		/// <description>Also accessed through the Name property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_TASK_BIZRULE</term>
		/// <description>Also accessed through the BizRule property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_TASK_BIZRULE_LANGUAGE</term>
		/// <description>Also accessed through the BizRuleLanguage property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_TASK_IS_ROLE_DEFINITION</term>
		/// <description>Also accessed through the IsRoleDefinition property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_TASK_OPERATIONS</term>
		/// <description>Also accessed through the Operations property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_TASK_TASKS</term>
		/// <description>Also accessed through the Tasks property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_WRITABLE</term>
		/// <description>Also accessed through the Writable property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to the returned IAzTask object property.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-getproperty
		[DispId(1610743829)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzTask</c> object property with the specified property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzTask</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_BIZRULE</b></description>
		/// <description>Also accessed through the <c>BizRule</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_BIZRULE_LANGUAGE</b></description>
		/// <description>Also accessed through the <c>BizRuleLanguage</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_IS_ROLE_DEFINITION</b></description>
		/// <description>Also accessed through the <c>IsRoleDefinition</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// Value to set to the <c>IAzTask</c> object property specified by the <i>lPropId</i> parameter. The following table shows the type
		/// of data that must be used depending on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_BIZRULE</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_BIZRULE_LANGUAGE</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_IS_ROLE_DEFINITION</b></description>
		/// <description><b>BOOL</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-setproperty HRESULT SetProperty( [in] LONG lPropId,
		// [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743830)]
		void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddPropertyItem</b> method adds the specified entity to the specified list.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list to which to add the entity specified by the <i>varProp</i> parameter. The following table shows the
		/// possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_OPERATIONS</b></description>
		/// <description>Can also be added using the <c>AddOperation</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_TASKS</b></description>
		/// <description>Can also be added using the <c>AddTask</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Name of the entity to add to the list specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-addpropertyitem HRESULT AddPropertyItem( [in] LONG
		// lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743831)]
		void AddPropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeletePropertyItem</b> method removes the specified entity from the specified list.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list from which to remove the entity specified by the <i>varProp</i> parameter. The following table shows the
		/// possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_OPERATIONS</b></description>
		/// <description>Can also be removed using the <c>DeleteOperation</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_TASKS</b></description>
		/// <description>Can also be removed using the <c>DeleteTask</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Name of the entity to remove from the list specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-deletepropertyitem HRESULT DeletePropertyItem( [in]
		// LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743832)]
		void DeletePropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>IAzTask</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>Any additions or modifications to an <c>IAzTask</c> object are not persisted until the <b>Submit</b> method is called.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-submit HRESULT Submit( [in, optional] LONG lFlags,
		// [in, optional] VARIANT varReserved );
		[DispId(1610743833)]
		void Submit([Optional, DefaultParameterValue((AZ_PROP_CONSTANTS)0), In] AZ_PROP_CONSTANTS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);
	}

	/// <summary>Extends the IAzTask interface with a method that returns the role assignments associated with the task.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iaztask2
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzTask2")]
	[ComImport, Guid("03A9A5EE-48C8-4832-9025-AAD503C46526")]
	public interface IAzTask2 : IAzTask
	{
		/// <summary>
		/// <para>The <b>Name</b> property sets or retrieves the name of the task.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Name</b> property is 64 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_name HRESULT put_Name( BSTR bstrName );
		[DispId(1610743808)]
		new string Name
		{
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743808)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>Description</b> property sets or retrieves a comment that describes the task.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>The maximum length of the <b>Description</b> property is 1,024 characters.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_description HRESULT put_Description( BSTR
		// bstrDescription );
		[DispId(1610743810)]
		new string Description
		{
			[DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743810)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>ApplicationData</b> property sets or retrieves an opaque field that can be used by the application to store information.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// <b>Important</b>  Policy administrators can read from and write to this property. Applications should not store data in the
		/// <b>ApplicationData</b> property that should not be available to the policy administrator.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_applicationdata?view=vs-2019 HRESULT
		// put_ApplicationData( BSTR bstrApplicationData );
		[DispId(1610743812)]
		new string ApplicationData
		{
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743812)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>BizRule</b> property sets or retrieves the text of the script that implements the business rule (BizRule).</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>The maximum length of this property is 65,536 characters.</para>
		/// <para><b>Important</b>  The <c>BizRuleLanguage</c> property must be set before this property is set.</para>
		/// <para></para>
		/// <para>An <c>IAzTask</c> object that is a child object of a delegated <c>IAzScope</c> object cannot have an associated BizRule.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_bizrule HRESULT put_BizRule( BSTR bstrProp );
		[DispId(1610743814)]
		new string BizRule
		{
			[DispId(1610743814)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743814)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>BizRuleLanguage</b> property sets or retrieves the scripting language in which the business rule (BizRule) is implemented.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>This property must be set before the <c>BizRule</c> property is set.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_bizrulelanguage HRESULT put_BizRuleLanguage(
		// BSTR bstrProp );
		[DispId(1610743816)]
		new string BizRuleLanguage
		{
			[DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743816)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>
		/// The <b>BizRuleImportedPath</b> property sets or retrieves the path to the file from which the business rule (BizRule) is imported.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>
		/// The path information is stored for use by the UI. The UI should supply a mechanism to synchronize the contents of the file and
		/// this property.
		/// </para>
		/// <para>The maximum length of this property is 512 characters.</para>
		/// </remarks>
		// https://learn.microsoft.com/nl-nl/windows/win32/api/azroles/nf-azroles-iaztask-put_bizruleimportedpath HRESULT
		// put_BizRuleImportedPath( BSTR bstrProp );
		[DispId(1610743818)]
		new string BizRuleImportedPath
		{
			[DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(1610743818)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The <b>IsRoleDefinition</b> property sets or retrieves a value that indicates whether the task is a role definition.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <value/>
		/// <remarks>This property represents a user interface abstraction and does not affect the functionality of the task.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-put_isroledefinition HRESULT put_IsRoleDefinition(
		// BOOL fProp );
		[DispId(1610743820)]
		new bool IsRoleDefinition
		{
			[DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[DispId(1610743820)]
			[param: In, MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// <para>The <b>Operations</b> property retrieves the operations associated with the task.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-get_operations HRESULT get_Operations( VARIANT
		// *pvarProp );
		[DispId(1610743822)]
		new object Operations
		{
			[DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Tasks</b> property retrieves the tasks associated with the task.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// <para>This property shows the nesting of <c>IAzTask</c> objects within another <b>IAzTask</b> object.</para>
		/// <para>In JScript, the returned <c>SAFEARRAY</c> must be converted to the JScript <c>Array</c> object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-get_tasks HRESULT get_Tasks( VARIANT *pvarProp );
		[DispId(1610743823)]
		new object Tasks
		{
			[DispId(1610743823)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>The <b>AddOperation</b> method adds the <c>IAzOperation</c> object with the specified name to the task.</summary>
		/// <param name="bstrOp">Name of the <c>IAzOperation</c> object to add to the task.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-addoperation HRESULT AddOperation( [in] BSTR
		// bstrOp, [in, optional] VARIANT varReserved );
		[DispId(1610743824)]
		new void AddOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrOp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeleteOperation</b> method removes the <c>IAzOperation</c> object with the specified name from the task.</summary>
		/// <param name="bstrOp">Name of the <c>IAzOperation</c> object to remove from the task.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzOperation</c> references to an <b>IAzOperation</b> object that has been deleted from the cache, the
		/// <b>IAzOperation</b> object can no longer be used. In C++, you must release references to deleted <b>IAzOperation</b> objects by
		/// calling the <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-deleteoperation HRESULT DeleteOperation( [in] BSTR
		// bstrOp, [in, optional] VARIANT varReserved );
		[DispId(1610743825)]
		new void DeleteOperation([In, MarshalAs(UnmanagedType.BStr)] string bstrOp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddTask</b> method adds the <c>IAzTask</c> object with the specified name to the task.</summary>
		/// <param name="bstrTask">Name of the <c>IAzTask</c> object to add to the task.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// <para>This method allows the nesting of <c>IAzTask</c> objects within another <b>IAzTask</b> object.</para>
		/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-addtask HRESULT AddTask( [in] BSTR bstrTask, [in,
		// optional] VARIANT varReserved );
		[DispId(1610743826)]
		new void AddTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTask, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeleteTask</b> method removes the <c>IAzTask</c> object with the specified name from the task.</summary>
		/// <param name="bstrTask">Name of the <c>IAzTask</c> object to remove from the task.</param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>
		/// If there are any <c>IAzTask</c> references to an <b>IAzTask</b> object that has been deleted from the cache, the <b>IAzTask</b>
		/// object can no longer be used. In C++, you must release references to deleted <b>IAzTask</b> objects by calling the
		/// <c>IUnknown::Release</c> method. In C# and Visual Basic, references to deleted objects are automatically released.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-deletetask HRESULT DeleteTask( [in] BSTR bstrTask,
		// [in, optional] VARIANT varReserved );
		[DispId(1610743827)]
		new void DeleteTask([In, MarshalAs(UnmanagedType.BStr)] string bstrTask, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// <para>
		/// The <b>Writable</b> property retrieves a value that indicates whether the task can be modified by the user context that
		/// initialized it.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-get_writable HRESULT get_Writable( BOOL *pfProp );
		[DispId(1610743828)]
		new bool Writable
		{
			[DispId(1610743828)]
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzTask</c> object property with the specified property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzTask</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AZ_PROP_APPLICATION_DATA</term>
		/// <description>Also accessed through the ApplicationData property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_CHILD_CREATE</term>
		/// <description>
		/// Determines whether the current user has permission to create child objects. This value is TRUE if the current user has
		/// permission; otherwise, FALSE.
		/// </description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_DESCRIPTION</term>
		/// <description>Also accessed through the Description property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_NAME</term>
		/// <description>Also accessed through the Name property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_TASK_BIZRULE</term>
		/// <description>Also accessed through the BizRule property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_TASK_BIZRULE_LANGUAGE</term>
		/// <description>Also accessed through the BizRuleLanguage property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_TASK_IS_ROLE_DEFINITION</term>
		/// <description>Also accessed through the IsRoleDefinition property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_TASK_OPERATIONS</term>
		/// <description>Also accessed through the Operations property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_TASK_TASKS</term>
		/// <description>Also accessed through the Tasks property</description>
		/// </item>
		/// <item>
		/// <term>AZ_PROP_WRITABLE</term>
		/// <description>Also accessed through the Writable property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <returns>A pointer to the returned IAzTask object property.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-getproperty
		[DispId(1610743829)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object GetProperty([In] AZ_PROP_CONSTANTS lPropId, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>
		/// The <b>SetProperty</b> method sets the specified value to the <c>IAzTask</c> object property with the specified property ID.
		/// </summary>
		/// <param name="lPropId">
		/// <para>Property ID of the <c>IAzTask</c> object property to set. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description>Also accessed through the <c>ApplicationData</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description>Also accessed through the <c>Description</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description>Also accessed through the <c>Name</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_BIZRULE</b></description>
		/// <description>Also accessed through the <c>BizRule</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_BIZRULE_LANGUAGE</b></description>
		/// <description>Also accessed through the <c>BizRuleLanguage</c> property</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_IS_ROLE_DEFINITION</b></description>
		/// <description>Also accessed through the <c>IsRoleDefinition</c> property</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>
		/// Value to set to the <c>IAzTask</c> object property specified by the <i>lPropId</i> parameter. The following table shows the type
		/// of data that must be used depending on the value of the <i>lPropId</i> parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description><i>lPropId</i> value</description>
		/// <description>Data type</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_APPLICATION_DATA</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_DESCRIPTION</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_NAME</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_BIZRULE</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_BIZRULE_LANGUAGE</b></description>
		/// <description><b>BSTR</b></description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_IS_ROLE_DEFINITION</b></description>
		/// <description><b>BOOL</b></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-setproperty HRESULT SetProperty( [in] LONG lPropId,
		// [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743830)]
		new void SetProperty([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>AddPropertyItem</b> method adds the specified entity to the specified list.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list to which to add the entity specified by the <i>varProp</i> parameter. The following table shows the
		/// possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_OPERATIONS</b></description>
		/// <description>Can also be added using the <c>AddOperation</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_TASKS</b></description>
		/// <description>Can also be added using the <c>AddTask</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Name of the entity to add to the list specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>You must call the <c>Submit</c> method to persist any changes made by this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-addpropertyitem HRESULT AddPropertyItem( [in] LONG
		// lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743831)]
		new void AddPropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>DeletePropertyItem</b> method removes the specified entity from the specified list.</summary>
		/// <param name="lPropId">
		/// <para>
		/// Property ID of the list from which to remove the entity specified by the <i>varProp</i> parameter. The following table shows the
		/// possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_OPERATIONS</b></description>
		/// <description>Can also be removed using the <c>DeleteOperation</c> method</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>AZ_PROP_TASK_TASKS</b></description>
		/// <description>Can also be removed using the <c>DeleteTask</c> method</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="varProp">
		/// <para>Name of the entity to remove from the list specified by the <i>lPropId</i> parameter.</para>
		/// <para>The variant must be a <b>BSTR</b> variant.</para>
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-deletepropertyitem HRESULT DeletePropertyItem( [in]
		// LONG lPropId, [in] VARIANT varProp, [in, optional] VARIANT varReserved );
		[DispId(1610743832)]
		new void DeletePropertyItem([In] AZ_PROP_CONSTANTS lPropId, [In, MarshalAs(UnmanagedType.Struct)] object varProp, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>Submit</b> method persists changes made to the <c>IAzTask</c> object.</summary>
		/// <param name="lFlags">
		/// Flags that modify the behavior of the <b>Submit</b> method. The default value is zero. If the <b>AZ_SUBMIT_FLAG_ABORT</b> flag is
		/// specified, the changes to the object are discarded and the object is updated to match the underlying policy store.
		/// </param>
		/// <param name="varReserved">Reserved for future use.</param>
		/// <remarks>Any additions or modifications to an <c>IAzTask</c> object are not persisted until the <b>Submit</b> method is called.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask-submit HRESULT Submit( [in, optional] LONG lFlags,
		// [in, optional] VARIANT varReserved );
		[DispId(1610743833)]
		new void Submit([Optional, DefaultParameterValue((AZ_PROP_CONSTANTS)0), In] AZ_PROP_CONSTANTS lFlags, [Optional, In, MarshalAs(UnmanagedType.Struct)] object? varReserved);

		/// <summary>The <b>RoleAssignments</b> method returns a collection of the role assignments associated with this task.</summary>
		/// <param name="bstrScopeName">
		/// The name of the scope in which to check for role assignments. If the value of this parameter is an empty string, the method
		/// checks for role assignments at the application level.
		/// </param>
		/// <param name="bRecursive">
		/// <b>TRUE</b> if the method checks all scopes within the application; otherwise, <b>FALSE</b>. This parameter is ignored if the
		/// value of the <i>bstrScopeName</i> parameter is not <b>NULL</b>.
		/// </param>
		/// <returns>
		/// The address of a pointer to an <c>IAzRoleAssignments</c> interface that represents the collection of <c>IAzRoleAssignment</c>
		/// objects associated with this task.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztask2-roleassignments HRESULT RoleAssignments( [in] BSTR
		// bstrScopeName, [in] VARIANT_BOOL bRecursive, [out] IAzRoleAssignments **ppRoleAssignments );
		[DispId(1610809344)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IAzRoleAssignments RoleAssignments([In, MarshalAs(UnmanagedType.BStr)] string? bstrScopeName, [In] bool bRecursive);
	}

	/// <summary>Represents a collection of IAzTask objects.</summary>
	// https://learn.microsoft.com/windows/win32/api/azroles/nn-azroles-iaztasks
	[PInvokeData("azroles.h", MSDNShortId = "NN:azroles.IAzTasks")]
	[ComImport, Guid("B338CCAB-4C85-4388-8C0A-C58592BAD398")]
	public interface IAzTasks : IEnumerable
	{
		/// <summary>
		/// <para>The <b>Item</b> property retrieves the <c>IAzTask</c> object at the specified index into the <c>IAzTasks</c> collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="Index"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztasks-get_item HRESULT get_Item( LONG Index, VARIANT
		// *pvarObtPtr );
		[DispId(0)]
		object this[[In] int Index]
		{
			[DispId(0)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The <b>Count</b> property retrieves the number of <c>IAzTask</c> objects in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <value/>
		/// <remarks>
		/// The <b>Count</b> property can be used to specify the last <c>IAzTask</c> object in a collection when retrieving a specific
		/// <b>IAzTask</b> object using the <c>IAzTasks.Item</c> property.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztasks-get_count HRESULT get_Count( LONG *plCount );
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		/// <summary>
		/// <para>
		/// The <b>_NewEnum</b> property retrieves an <c>IEnumVARIANT</c> interface on an object that can be used to enumerate the
		/// collection. This property is hidden within Visual Basic and Visual Basic Scripting Edition (VBScript).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property is provided for use by the <c>For Each</c> keyword in Visual Basic and the <c>foreach</c> keyword in Visual C#.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iaztasks-get__newenum HRESULT get__NewEnum( LPUNKNOWN
		// *ppEnumPtr );
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();
	}

	/// <summary>
	/// The <b>AddDelegatedPolicyUser</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of principals
	/// that act as delegated policy users.
	/// </summary>
	/// <param name="app">The <c>IAzApplication</c> object to which to add the delegated policy user.</param>
	/// <param name="delegatedPolicyUser">The SID to add to the list of delegated policy users.</param>
	/// <remarks>
	/// <para>
	/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
	/// <c>IAzApplication</c> object uses to administer the delegated object.
	/// </para>
	/// <para><b>Note</b>  Delegated policy users are not supported for XML stores.</para>
	/// <para></para>
	/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
	/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-adddelegatedpolicyuser HRESULT
	// AddDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
	public static void AddDelegatedPolicyUser(this IAzApplication app, [In] PSID delegatedPolicyUser) => app.AddDelegatedPolicyUser(delegatedPolicyUser.ToString("D"), null);

	/// <summary>
	/// The <b>AddPolicyAdministrator</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of principals
	/// that act as policy administrators.
	/// </summary>
	/// <param name="app">The <c>IAzApplication</c> object to which to add the delegated policy user.</param>
	/// <param name="admin">The SID to add to the list of policy administrators.</param>
	/// <remarks>
	/// <para>Policy administrators for an object can perform the following tasks:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Read the object</description>
	/// </item>
	/// <item>
	/// <description>Write attributes to the object</description>
	/// </item>
	/// <item>
	/// <description>Read attributes of child objects of the object</description>
	/// </item>
	/// <item>
	/// <description>Write attributes to child objects of the object</description>
	/// </item>
	/// <item>
	/// <description>Delete the object</description>
	/// </item>
	/// <item>
	/// <description>Delete child objects of the object</description>
	/// </item>
	/// <item>
	/// <description>Create child objects of the object</description>
	/// </item>
	/// </list>
	/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
	/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
	/// </remarks>
	public static void AddPolicyAdministrator(this IAzApplication app, PSID admin) => app.AddPolicyAdministrator(admin.ToString("D"), null);

	/// <summary>
	/// The <b>AddPolicyReader</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of principals that act
	/// as policy readers.
	/// </summary>
	/// <param name="app">The <c>IAzApplication</c> object to which to add the delegated policy user.</param>
	/// <param name="reader">The SID to add to the list of policy readers.</param>
	/// <remarks>
	/// <para>
	/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the policy;
	/// for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
	/// </para>
	/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
	/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-addpolicyreader HRESULT AddPolicyReader( [in]
	// BSTR bstrReader, [in, optional] VARIANT varReserved );
	public static void AddPolicyReader(this IAzApplication app, PSID reader) => app.AddPolicyReader(reader.ToString("D"), null);

	/// <summary>
	/// The <b>DeleteDelegatedPolicyUser</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
	/// principals that act as delegated policy users.
	/// </summary>
	/// <param name="app">The <c>IAzApplication</c> object from which to remove the delegated policy user.</param>
	/// <param name="delegatedPolicyUser">The SID to remove from the list of delegated policy users.</param>
	/// <remarks>
	/// <para>
	/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
	/// <c>IAzApplication</c> object uses to administer the delegated object.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para> Delegated policy users are not supported for XML stores.</para>
	/// </para>
	/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletedelegatedpolicyuser HRESULT
	// DeleteDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
	public static void DeleteDelegatedPolicyUser(this IAzApplication app, [In] PSID delegatedPolicyUser) => app.DeleteDelegatedPolicyUser(delegatedPolicyUser.ToString("D"), null);

	/// <summary>
	/// The <b>DeletePolicyAdministrator</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
	/// principals that act as policy administrators.
	/// </summary>
	/// <param name="app">The <c>IAzApplication</c> object to which to add the delegated policy user.</param>
	/// <param name="admin">The SID to remove from the list of policy administrators.</param>
	/// <remarks>
	/// <para>Policy administrators for an object can perform the following tasks:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Read the object</description>
	/// </item>
	/// <item>
	/// <description>Write attributes to the object</description>
	/// </item>
	/// <item>
	/// <description>Read attributes of child objects of the object</description>
	/// </item>
	/// <item>
	/// <description>Write attributes to child objects of the object</description>
	/// </item>
	/// <item>
	/// <description>Delete the object</description>
	/// </item>
	/// <item>
	/// <description>Delete child objects of the object</description>
	/// </item>
	/// <item>
	/// <description>Create child objects of the object</description>
	/// </item>
	/// </list>
	/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepolicyadministrator HRESULT
	// DeletePolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
	public static void DeletePolicyAdministrator(this IAzApplication app, PSID admin) => app.DeletePolicyAdministrator(admin.ToString("D"), null);

	/// <summary>
	/// The <b>DeletePolicyReader</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of principals
	/// that act as policy readers.
	/// </summary>
	/// <param name="app">The <c>IAzApplication</c> object to which to add the delegated policy user.</param>
	/// <param name="reader">The SID to remove from the list of policy readers.</param>
	/// <remarks>
	/// <para>
	/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the policy;
	/// for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
	/// </para>
	/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-deletepolicyreader HRESULT DeletePolicyReader(
	// [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
	public static void DeletePolicyReader(this IAzApplication app, PSID reader) => app.DeletePolicyReader(reader.ToString("D"), null);

	/// <summary>
	/// <para>
	/// The <b>InitializeClientContextFromStringSid</b> method gets an <c>IAzClientContext</c> object pointer from the specified <c>security
	/// identifier</c> (SID) in text form.
	/// </para>
	/// <para>
	/// <b>Note</b>  If possible, call the <c>InitializeClientContextFromToken</c> function instead of
	/// <b>InitializeClientContextFromStringSid</b>. For more information, see Remarks.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <param name="app">The <c>IAzApplication</c> object to which to add the delegated policy user.</param>
	/// <param name="sid">A <c>PSID</c> that contains the security identifier of the security principal.</param>
	/// <param name="lOptions">
	/// <para>Options for the context creation.</para>
	/// <para>
	/// If AZ_CLIENT_CONTEXT_SKIP_GROUP is specified, the SID specified in the <i>SidString</i> parameter is not necessarily a valid user
	/// account. The SID will be used to create the context without validation. The created context will be flagged as having been created
	/// from a SID, the SID string will be stored in the client name field, and the domain name field will be empty. Token groups will not be
	/// used in the client context creation. <c>Lightweight Directory Access Protocol</c> (LDAP) query groups are not supported when
	/// AZ_CLIENT_CONTEXT_SKIP_GROUP is specified. Because the account is not validated in Active Directory, the client context's user
	/// information properties, such as <c>UserSamCompat</c>, will not be valid, and when accessed, they will return ERROR_INVALID_HANDLE.
	/// The <c>RoleForAccessCheck</c> property and the <c>AccessCheck</c> method of <c>IAzClientContext</c> can still be used to specify a
	/// role for access checking. The <c>GetRoles</c> method of <b>IAzClientContext</b> can still be used to enumerate roles assigned to the
	/// context within a specific scope.
	/// </para>
	/// <para>If AZ_CLIENT_CONTEXT_SKIP_GROUP is not specified, the SID must represent a valid user account.</para>
	/// </param>
	/// <returns>A pointer to a pointer to the returned <c>IAzClientContext</c> object.</returns>
	/// <remarks>
	/// <para>
	/// If possible, call the <c>InitializeClientContextFromToken</c> function instead of <b>InitializeClientContextFromStringSid</b>.
	/// <b>InitializeClientContextFromStringSid</b> attempts to retrieve the information available in a logon token had the client actually
	/// logged on. An actual logon token provides more information, such as logon type and logon properties, and reflects the behavior of the
	/// authentication package used for the logon. The client context created by <b>InitializeClientContextFromToken</b> uses a logon token,
	/// and the resulting client context is more complete and accurate than a client context created by <b>InitializeClientContextFromStringSid</b>.
	/// </para>
	/// <para>
	/// <b>Important</b>  Applications should not assume that the calling context has permission to use this function. The
	/// <c>AuthzInitializeContextFromSid</c> function reads the tokenGroupsGlobalAndUniversal attribute of the SID specified in the call to
	/// determine the current user's group memberships. If the user's object is in <c>Active Directory</c>, the calling context must have
	/// read access to the tokenGroupsGlobalAndUniversal attribute on the user object. Read access to the tokenGroupsGlobalAndUniversal
	/// attribute is granted to the <b>Pre-Windows 2000 Compatible Access</b> group, but new domains contain an empty <b>Pre-Windows 2000
	/// Compatible Access</b> group by default because the default setup selection is <b>Permissions compatible with Windows 2000 and Windows
	/// Server 2003</b>. Therefore, applications may not have access to the tokenGroupsGlobalAndUniversal attribute; in this case, the
	/// <b>AuthzInitializeContextFromSid</b> function fails with ACCESS_DENIED. Applications that use this function should correctly handle
	/// this error and provide supporting documentation. To simplify granting accounts permission to query a user's group information, add
	/// accounts that need the ability to look up group information to the Windows Authorization Access Group.
	/// </para>
	/// <para></para>
	/// <para>
	/// Applications calling this function should use the fully qualified domain name or <c>user principal name</c> (UPN). Otherwise, this
	/// method might fail across forests if the NetBIOS domain name is used and the two domains do not have a direct trust relationship.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazapplication-initializeclientcontextfromstringsid HRESULT
	// InitializeClientContextFromStringSid( [in] BSTR SidString, [in] LONG lOptions, [in, optional] VARIANT varReserved, [out]
	// IAzClientContext **ppClientContext );
	public static IAzClientContext InitializeClientContextFromStringSid(this IAzApplication app, [In] PSID sid, [In] AZ_PROP_CONSTANTS lOptions) => app.InitializeClientContextFromStringSid(sid.ToString("D"), lOptions, null);

	/// <summary>
	/// The <b>AddPolicyAdministrator</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
	/// principals that act as policy administrators.
	/// </summary>
	/// <param name="store">The <c>IAzAuthorizationStore</c> instance.</param>
	/// <param name="admin">The <c>PSID</c> of the administrator to add.</param>
	/// <remarks>
	/// <para>Policy administrators for an object can perform the following tasks:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Read the object</description>
	/// </item>
	/// <item>
	/// <description>Write attributes to the object</description>
	/// </item>
	/// <item>
	/// <description>Read attributes of child objects of the object</description>
	/// </item>
	/// <item>
	/// <description>Write attributes to child objects of the object</description>
	/// </item>
	/// <item>
	/// <description>Delete the object</description>
	/// </item>
	/// <item>
	/// <description>Delete child objects of the object</description>
	/// </item>
	/// <item>
	/// <description>Create child objects of the object</description>
	/// </item>
	/// </list>
	/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
	/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpolicyadministrator HRESULT
	// AddPolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
	public static void AddPolicyAdministrator(this IAzAuthorizationStore store, [In] PSID admin) => store.AddPolicyAdministrator(admin.ToString("D"));

	/// <summary>
	/// The <b>DeletePolicyAdministrator</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
	/// principals that act as policy administrators.
	/// </summary>
	/// <param name="store">The <c>IAzAuthorizationStore</c> instance.</param>
	/// <param name="admin">The <c>PSID</c> of the administrator to remove.</param>
	/// <remarks>
	/// <para>Policy administrators for an object can perform the following tasks:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Read the object</description>
	/// </item>
	/// <item>
	/// <description>Write attributes to the object</description>
	/// </item>
	/// <item>
	/// <description>Read attributes of child objects of the object</description>
	/// </item>
	/// <item>
	/// <description>Write attributes to child objects of the object</description>
	/// </item>
	/// <item>
	/// <description>Delete the object</description>
	/// </item>
	/// <item>
	/// <description>Delete child objects of the object</description>
	/// </item>
	/// <item>
	/// <description>Create child objects of the object</description>
	/// </item>
	/// </list>
	/// <para>To view the list of policy administrators, use the <c>PolicyAdministrators</c> property.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepolicyadministrator HRESULT
	// DeletePolicyAdministrator( [in] BSTR bstrAdmin, [in, optional] VARIANT varReserved );
	public static void DeletePolicyAdministrator(this IAzAuthorizationStore store, [In] PSID admin) => store.DeletePolicyAdministrator(admin.ToString("D"));

	/// <summary>
	/// The <b>AddPolicyReader</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of principals that
	/// act as policy readers.
	/// </summary>
	/// <param name="store">The <c>IAzAuthorizationStore</c> instance.</param>
	/// <param name="reader">The <c>PSID</c> of the reader to add.</param>
	/// <remarks>
	/// <para>
	/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
	/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
	/// </para>
	/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
	/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-addpolicyreader HRESULT
	// AddPolicyReader( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
	public static void AddPolicyReader(this IAzAuthorizationStore store, [In] PSID reader) => store.AddPolicyReader(reader.ToString("D"));

	/// <summary>
	/// The <b>DeletePolicyReader</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
	/// principals that act as policy readers.
	/// </summary>
	/// <param name="store">The <c>IAzAuthorizationStore</c> instance.</param>
	/// <param name="reader">The <c>PSID</c> of the reader to remove.</param>
	/// <remarks>
	/// <para>
	/// Policy readers for an object can read attributes for the object and for child objects of the object. Readers can also use the
	/// policy; for example, readers can call the <c>AccessCheck</c> method. Readers cannot modify the object or its child objects.
	/// </para>
	/// <para>To view the list of policy readers, use the <c>PolicyReaders</c> property.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletepolicyreader HRESULT
	// DeletePolicyReader( [in] BSTR bstrReader, [in, optional] VARIANT varReserved );
	public static void DeletePolicyReader(this IAzAuthorizationStore store, [In] PSID reader) => store.DeletePolicyReader(reader.ToString("D"));

	/// <summary>
	/// The <b>AddDelegatedPolicyUser</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of
	/// principals that act as delegated policy users.
	/// </summary>
	/// <param name="store">The <c>IAzAuthorizationStore</c> instance.</param>
	/// <param name="delegatedPolicyUser">The <c>PSID</c> of the delegated policy user to add.</param>
	/// <remarks>
	/// <para>
	/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
	/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>Delegated policy users are not supported for XML stores.</para>
	/// </para>
	/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
	/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
	/// </remarks>
	// https://learn.microsoft.com/da-dk/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-adddelegatedpolicyuser HRESULT
	// AddDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
	public static void AddDelegatedPolicyUser(this IAzAuthorizationStore store, [In] PSID delegatedPolicyUser) => store.AddDelegatedPolicyUser(delegatedPolicyUser.ToString("D"));

	/// <summary>
	/// The <b>DeleteDelegatedPolicyUser</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of
	/// principals that act as delegated policy users.
	/// </summary>
	/// <param name="store">The <c>IAzAuthorizationStore</c> instance.</param>
	/// <param name="delegatedPolicyUser">The <c>PSID</c> of the delegated policy user to remove.</param>
	/// <remarks>
	/// <para>
	/// Delegated policy users are principals that are allowed to read the subset of the policy data that the policy administrator of an
	/// <c>IAzApplication</c> or <c>IAzScope</c> object uses to administer the delegated object.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>Delegated policy users are not supported for XML stores.</para>
	/// </para>
	/// <para>To view the list of delegated policy users, use the <c>DelegatedPolicyUsers</c> property.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazauthorizationstore-deletedelegatedpolicyuser?view=vs-2017
	// HRESULT DeleteDelegatedPolicyUser( [in] BSTR bstrDelegatedPolicyUser, [in, optional] VARIANT varReserved );
	public static void DeleteDelegatedPolicyUser(this IAzAuthorizationStore store, [In] PSID delegatedPolicyUser) => store.DeleteDelegatedPolicyUser(delegatedPolicyUser.ToString("D"));

	/// <summary>
	/// The <b>AddMember</b> method adds the specified <c>security identifier</c> (SID) in text form to the list of Windows accounts that
	/// belong to the role.
	/// </summary>
	/// <param name="role">The <c>IAzRole</c> instance.</param>
	/// <param name="prop">The SID to add to the list of Windows accounts that belong to the role.</param>
	/// <remarks>
	/// <para>To view the list of SIDs of Windows accounts that belong to this role in text form, use the <c>Members</c> property.</para>
	/// <para>You must call the <c>Submit</c> method to persist any changes made by this method.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-addmember HRESULT AddMember( [in] BSTR bstrProp,
	// [in, optional] VARIANT varReserved );
	[DispId(1610743820)]
	public static void AddMember(this IAzRole role, [In] PSID prop) => role.AddMember(prop);

	/// <summary>
	/// The <b>DeleteMember</b> method removes the specified <c>security identifier</c> (SID) in text form from the list of Windows
	/// accounts that belong to the role.
	/// </summary>
	/// <param name="role">The <c>IAzRole</c> instance.</param>
	/// <param name="prop">The SID to remove from the list of Windows accounts that belong to the role.</param>
	/// <remarks>To view the list of SIDs of Windows accounts that belong to the role in text form, use the <c>Members</c> property.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/azroles/nf-azroles-iazrole-deletemember HRESULT DeleteMember( [in] BSTR
	// bstrProp, [in, optional] VARIANT varReserved );
	[DispId(1610743821)]
	public static void DeleteMember(this IAzRole role, [In] PSID prop) => role.DeleteMember(prop);

	/// <summary>Contains the <see cref="IAzApplication"/>, <see cref="IAzApplication2"/>, and <see cref="IAzApplication3"/> interfaces.</summary>
	[ComImport, Guid("B2BCFF59-A757-4B0B-A1BC-EA69981DA69E"), ClassInterface(ClassInterfaceType.None)]
	public class AzAuthorizationStore { }

	/// <summary>Contains the <see cref="AzBizRuleContext"/> class.</summary>
	[ComImport, Guid("5C2DC96F-8D51-434B-B33C-379BCCAE77C3"), ClassInterface(ClassInterfaceType.None)]
	public class AzBizRuleContext { }

	/// <summary>Contains the <see cref="AzPrincipalLocator"/> class.</summary>
	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("483AFB5D-70DF-4E16-ABDC-A1DE4D015A3E")]
	public class AzPrincipalLocator { }
}