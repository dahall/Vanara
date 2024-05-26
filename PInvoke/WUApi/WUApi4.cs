namespace Vanara.PInvoke;

/// <summary>PInvoke API (methods, structures and constants) imported from Windows Update API.</summary>
public static partial class WUApi
{
	/// <summary>Adds or removes the registration of the update service with Windows Update Agent or Automatic Updates.</summary>
	/// <remarks>
	/// You can create an instance of this interface by using the UpdateServiceManager coclass. Use the Microsoft.Update.ServiceManager
	/// program identifier to create the object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdateservicemanager
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateServiceManager")]
	[ComImport, Guid("23857E3C-02BA-44A3-9423-B1C900805F37"), CoClass(typeof(UpdateServiceManagerClass))]
	public interface IUpdateServiceManager
	{
		/// <summary>
		/// <para>Gets an IUpdateServiceCollection of the services that are registered with WUA.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager-get_services HRESULT get_Services(
		// IUpdateServiceCollection **retval );
		[DispId(1610743809)]
		IUpdateServiceCollection Services
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>Registers a service with Windows Update Agent (WUA).</summary>
		/// <param name="serviceID">An identifier for a service to be registered.</param>
		/// <param name="authorizationCabPath">
		/// The path of the Microsoft signed local cabinet file that has the information that is required for a service registration.
		/// </param>
		/// <returns>An IUpdateService interface that represents an added service.</returns>
		/// <remarks>
		/// This method returns <c>WU_E_DS_INVALIDOPERATION</c> if the requested change in the state of Automatic Updates is contrary to the
		/// specifications in the Authorization Cab. An error is returned by WinVerifyTrust if the Authorization Cab has not been signed.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager-addservice HRESULT AddService( [in] BSTR
		// serviceID, [in] BSTR authorizationCabPath, [out] IUpdateService **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IUpdateService AddService([In, MarshalAs(UnmanagedType.BStr)] string serviceID, [In, MarshalAs(UnmanagedType.BStr)] string authorizationCabPath = "");

		/// <summary>Registers a service with Automatic Updates.</summary>
		/// <param name="serviceID">An identifier for the service to be registered.</param>
		/// <remarks>
		/// <para>This method returns <c>WU_E_DS_UNKNOWNSERVICE</c> if the service to be registered is unknown to Automatic Updates.</para>
		/// <para>
		/// This method returns <c>WU_E_INVALID_OPERATION</c> if the method is called with an invalid service ID. This method also returns
		/// <c>WU_E_INVALID_OPERATION</c> if the service ID is valid but the service can't register with Automatic Updates. That is, the
		/// requested change in the state of Automatic Updates is contrary to the specifications in the authorization cabinet file (for
		/// example, CanRegisterWithAU property is set to <c>FALSE</c>). An error is returned by WinVerifyTrust function if the authorization
		/// cabinet file has not been signed.
		/// </para>
		/// <para>This method returns <c>WU_E_DS_NEEDWINDOWSSERVICE</c> if you try to remove the Windows Update service.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager-registerservicewithau HRESULT
		// RegisterServiceWithAU( [in] BSTR serviceID );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
		void RegisterServiceWithAU([In, MarshalAs(UnmanagedType.BStr)] string serviceID);

		/// <summary>Removes a service registration from Windows Update Agent (WUA).</summary>
		/// <param name="serviceID">An identifier for the service to be unregistered.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager-removeservice HRESULT RemoveService( [in]
		// BSTR serviceID );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
		void RemoveService([In, MarshalAs(UnmanagedType.BStr)] string serviceID);

		/// <summary>Unregisters a service with Automatic Updates.</summary>
		/// <param name="serviceID">An identifier for the service to be unregistered.</param>
		/// <remarks>
		/// <para>
		/// This method returns <c>WU_E_DS_INVALIDOPERATION</c> if the requested change in the state of Automatic Updates is contrary to the
		/// specifications in the Authorization Cab. An error is returned by WinVerifyTrust function if the Authorization Cab has not been signed.
		/// </para>
		/// <para>This method returns <c>WU_E_DS_UNKNOWNSERVICE</c> if the service to be removed does not exist.</para>
		/// <para>
		/// This method returns <c>WU_E_DS_NEEDWINDOWSSERVICE</c> if you attempt to remove the Windows Update service and if it is the only
		/// service that is registered with Automatic Updates.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager-unregisterservicewithau HRESULT
		// UnregisterServiceWithAU( BSTR serviceID );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
		void UnregisterServiceWithAU([In, MarshalAs(UnmanagedType.BStr)] string serviceID);

		/// <summary>Registers a scan package as a service with Windows Update Agent (WUA) and then returns an IUpdateService interface.</summary>
		/// <param name="serviceName">A descriptive name for the scan package service.</param>
		/// <param name="scanFileLocation">The path of the Microsoft signed scan file that has to be registered as a service.</param>
		/// <param name="flags">
		/// <para>Determines how to remove the service registration of the scan package.</para>
		/// <para>For possible values, see UpdateServiceOption.</para>
		/// </param>
		/// <returns>A pointer to an IUpdateService interface that contains service registration information.</returns>
		/// <remarks>
		/// <para>You can use the ID of the service in searches by passing the ID as the ServiceID property of the IUpdateSearcher interface.</para>
		/// <para>To free resources, remove the service after it is no longer needed. Use the RemoveService method to remove the service.</para>
		/// <para>Do not call the RegisterServiceWithAU method for the service that the <c>AddScanPackageService</c> method registers.</para>
		/// <para>
		/// The service that is returned by <c>AddScanPackageService</c> is in the collection of services that the Services property of the
		/// IUpdateServiceManager interface returns. This service has the special IsScanPackageService property.
		/// </para>
		/// <para>An error is returned by WinVerifyTrust if the Authorization Cab is not signed.</para>
		/// <para>This method returns <c>WU_E_INVALID_OPERATION</c> if the object that implements the interface has been locked down.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager-addscanpackageservice HRESULT
		// AddScanPackageService( [in] BSTR serviceName, [in] BSTR scanFileLocation, [in] LONG flags, [out] IUpdateService **ppService );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IUpdateService AddScanPackageService([In, MarshalAs(UnmanagedType.BStr)] string serviceName,
			[In, MarshalAs(UnmanagedType.BStr)] string scanFileLocation, [In] int flags = 0);

		/// <summary>
		/// Set options for the object that specifies the service ID. The <c>SetOption</c> method is also used to determine whether a warning
		/// is displayed when you change the registration of Automatic Updates.
		/// </summary>
		/// <param name="optionName">
		/// <para>Set this parameter to AllowedServiceID to specify the form of the service ID that is provided to the object.</para>
		/// <para>Set to AllowWarningUI to display a warning when changing the Automatic Updates registration.</para>
		/// </param>
		/// <param name="optionValue">
		/// <para>
		/// If the <c>optionName</c> parameter is set to AllowServiceID, the <c>optionValue</c> parameter is set to the service ID that is
		/// provided as a <c>VT_BSTR</c> value.
		/// </para>
		/// <para>
		/// If <c>optionName</c> is set to AllowWarningUI, <c>optionValue</c> is a <c>VT_BOOL</c> value that specifies whether to display a
		/// warning when changing the registration of Automatic Updates.
		/// </para>
		/// <para>
		/// Set the optionValue parameter to VARIANT_TRUE to display the warning UI. Set it to VARIANT_FALSE to suppress the warning UI.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager-setoption HRESULT SetOption( [in] BSTR
		// optionName, [in] VARIANT optionValue );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610678279)]
		void SetOption([In, MarshalAs(UnmanagedType.BStr)] string optionName, [In, MarshalAs(UnmanagedType.Struct)] object optionValue);
	}

	/// <summary>Adds or removes the registration of the update service with Windows Update Agent or Automatic Updates.</summary>
	/// <remarks>
	/// You can create an instance of this interface by using the UpdateServiceManager coclass. Use the Microsoft.Update.ServiceManager
	/// program identifier to create the object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdateservicemanager2
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateServiceManager2")]
	[ComImport, Guid("0BB8531D-7E8D-424F-986C-A0B8F60A3E7B"), CoClass(typeof(UpdateServiceManagerClass))]
	public interface IUpdateServiceManager2 : IUpdateServiceManager
	{
		/// <summary>
		/// <para>Gets an IUpdateServiceCollection of the services that are registered with WUA.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager-get_services HRESULT get_Services(
		// IUpdateServiceCollection **retval );
		[DispId(1610743809)]
		new IUpdateServiceCollection Services
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>Registers a service with Windows Update Agent (WUA).</summary>
		/// <param name="serviceID">An identifier for a service to be registered.</param>
		/// <param name="authorizationCabPath">
		/// The path of the Microsoft signed local cabinet file that has the information that is required for a service registration.
		/// </param>
		/// <returns>An IUpdateService interface that represents an added service.</returns>
		/// <remarks>
		/// This method returns <c>WU_E_DS_INVALIDOPERATION</c> if the requested change in the state of Automatic Updates is contrary to the
		/// specifications in the Authorization Cab. An error is returned by WinVerifyTrust if the Authorization Cab has not been signed.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager-addservice HRESULT AddService( [in] BSTR
		// serviceID, [in] BSTR authorizationCabPath, [out] IUpdateService **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IUpdateService AddService([In, MarshalAs(UnmanagedType.BStr)] string serviceID, [In, MarshalAs(UnmanagedType.BStr)] string authorizationCabPath = "");

		/// <summary>Registers a service with Automatic Updates.</summary>
		/// <param name="serviceID">An identifier for the service to be registered.</param>
		/// <remarks>
		/// <para>This method returns <c>WU_E_DS_UNKNOWNSERVICE</c> if the service to be registered is unknown to Automatic Updates.</para>
		/// <para>
		/// This method returns <c>WU_E_INVALID_OPERATION</c> if the method is called with an invalid service ID. This method also returns
		/// <c>WU_E_INVALID_OPERATION</c> if the service ID is valid but the service can't register with Automatic Updates. That is, the
		/// requested change in the state of Automatic Updates is contrary to the specifications in the authorization cabinet file (for
		/// example, CanRegisterWithAU property is set to <c>FALSE</c>). An error is returned by WinVerifyTrust function if the authorization
		/// cabinet file has not been signed.
		/// </para>
		/// <para>This method returns <c>WU_E_DS_NEEDWINDOWSSERVICE</c> if you try to remove the Windows Update service.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager-registerservicewithau HRESULT
		// RegisterServiceWithAU( [in] BSTR serviceID );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
		new void RegisterServiceWithAU([In, MarshalAs(UnmanagedType.BStr)] string serviceID);

		/// <summary>Removes a service registration from Windows Update Agent (WUA).</summary>
		/// <param name="serviceID">An identifier for the service to be unregistered.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager-removeservice HRESULT RemoveService( [in]
		// BSTR serviceID );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
		new void RemoveService([In, MarshalAs(UnmanagedType.BStr)] string serviceID);

		/// <summary>Unregisters a service with Automatic Updates.</summary>
		/// <param name="serviceID">An identifier for the service to be unregistered.</param>
		/// <remarks>
		/// <para>
		/// This method returns <c>WU_E_DS_INVALIDOPERATION</c> if the requested change in the state of Automatic Updates is contrary to the
		/// specifications in the Authorization Cab. An error is returned by WinVerifyTrust function if the Authorization Cab has not been signed.
		/// </para>
		/// <para>This method returns <c>WU_E_DS_UNKNOWNSERVICE</c> if the service to be removed does not exist.</para>
		/// <para>
		/// This method returns <c>WU_E_DS_NEEDWINDOWSSERVICE</c> if you attempt to remove the Windows Update service and if it is the only
		/// service that is registered with Automatic Updates.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager-unregisterservicewithau HRESULT
		// UnregisterServiceWithAU( BSTR serviceID );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
		new void UnregisterServiceWithAU([In, MarshalAs(UnmanagedType.BStr)] string serviceID);

		/// <summary>Registers a scan package as a service with Windows Update Agent (WUA) and then returns an IUpdateService interface.</summary>
		/// <param name="serviceName">A descriptive name for the scan package service.</param>
		/// <param name="scanFileLocation">The path of the Microsoft signed scan file that has to be registered as a service.</param>
		/// <param name="flags">
		/// <para>Determines how to remove the service registration of the scan package.</para>
		/// <para>For possible values, see UpdateServiceOption.</para>
		/// </param>
		/// <returns>A pointer to an IUpdateService interface that contains service registration information.</returns>
		/// <remarks>
		/// <para>You can use the ID of the service in searches by passing the ID as the ServiceID property of the IUpdateSearcher interface.</para>
		/// <para>To free resources, remove the service after it is no longer needed. Use the RemoveService method to remove the service.</para>
		/// <para>Do not call the RegisterServiceWithAU method for the service that the <c>AddScanPackageService</c> method registers.</para>
		/// <para>
		/// The service that is returned by <c>AddScanPackageService</c> is in the collection of services that the Services property of the
		/// IUpdateServiceManager interface returns. This service has the special IsScanPackageService property.
		/// </para>
		/// <para>An error is returned by WinVerifyTrust if the Authorization Cab is not signed.</para>
		/// <para>This method returns <c>WU_E_INVALID_OPERATION</c> if the object that implements the interface has been locked down.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager-addscanpackageservice HRESULT
		// AddScanPackageService( [in] BSTR serviceName, [in] BSTR scanFileLocation, [in] LONG flags, [out] IUpdateService **ppService );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IUpdateService AddScanPackageService([In, MarshalAs(UnmanagedType.BStr)] string serviceName,
			[In, MarshalAs(UnmanagedType.BStr)] string scanFileLocation, [In] int flags = 0);

		/// <summary>
		/// Set options for the object that specifies the service ID. The <c>SetOption</c> method is also used to determine whether a warning
		/// is displayed when you change the registration of Automatic Updates.
		/// </summary>
		/// <param name="optionName">
		/// <para>Set this parameter to AllowedServiceID to specify the form of the service ID that is provided to the object.</para>
		/// <para>Set to AllowWarningUI to display a warning when changing the Automatic Updates registration.</para>
		/// </param>
		/// <param name="optionValue">
		/// <para>
		/// If the <c>optionName</c> parameter is set to AllowServiceID, the <c>optionValue</c> parameter is set to the service ID that is
		/// provided as a <c>VT_BSTR</c> value.
		/// </para>
		/// <para>
		/// If <c>optionName</c> is set to AllowWarningUI, <c>optionValue</c> is a <c>VT_BOOL</c> value that specifies whether to display a
		/// warning when changing the registration of Automatic Updates.
		/// </para>
		/// <para>
		/// Set the optionValue parameter to VARIANT_TRUE to display the warning UI. Set it to VARIANT_FALSE to suppress the warning UI.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager-setoption HRESULT SetOption( [in] BSTR
		// optionName, [in] VARIANT optionValue );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610678279)]
		new void SetOption([In, MarshalAs(UnmanagedType.BStr)] string optionName, [In, MarshalAs(UnmanagedType.Struct)] object optionValue);

		/// <summary>
		/// <para>Gets and sets the identifier of the current client application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>Returns the Unknown value if the client application has not set the property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager2-get_clientapplicationid HRESULT
		// get_ClientApplicationID( BSTR *retval );
		[DispId(1610809345)]
		string? ClientApplicationID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Returns a pointer to an IUpdateServiceRegistration interface.</summary>
		/// <param name="serviceID">An identifier for the service to be registered.</param>
		/// <returns>A pointer to an IUpdateServiceRegistration interface that represents an added service.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager2-queryserviceregistration HRESULT
		// QueryServiceRegistration( [in] BSTR serviceID, [out] IUpdateServiceRegistration **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809346)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IUpdateServiceRegistration QueryServiceRegistration([In, MarshalAs(UnmanagedType.BStr)] string serviceID);

		/// <summary>
		/// Registers a service with Windows Update Agent (WUA) without requiring an authorization cabinet file (.cab). This method also
		/// returns a pointer to an IUpdateServiceRegistration interface.
		/// </summary>
		/// <param name="serviceID">An identifier for the service to be registered.</param>
		/// <param name="flags">
		/// A combination of AddServiceFlag values that are combined by using a bitwise OR operation. The resulting value specifies options
		/// for service registration. For more info, see Remarks.
		/// </param>
		/// <param name="authorizationCabPath">
		/// The path of the Microsoft signed local cabinet file (.cab) that has the information that is required for a service registration.
		/// If empty, the update agent searches for the authorization cabinet file (.cab) during service registration when a network
		/// connection is available.
		/// </param>
		/// <returns>A pointer to an IUpdateServiceRegistration interface that represents an added service.</returns>
		/// <remarks>
		/// <para>This method may return networking error codes when the <c>asfAllowOnlineRegistration</c> flag is specified.</para>
		/// <para>
		/// The <c>authorizationCabPath</c> parameter is optional for this method. If the <c>authorizationCabPath</c> parameter is not
		/// specified, it will be retrieved from the Windows Update server.
		/// </para>
		/// <para>
		/// This method returns <c>E_INVALIDARG</c> if the <c>asfAllowOnlineRegistration</c> or <c>asfAllowPendingRegistration</c> flags are
		/// specified and if the value of the <c>authorizationCabPath</c> parameter is not an empty string.
		/// </para>
		/// <para>
		/// This method returns <c>WU_E_DS_INVALIDOPERATION</c> if the requested change in the state of Automatic Updates is contrary to the
		/// specifications in the authorization cabinet file (.cab) when the <c>asfRegisterServiceWithAU</c> flag is specified. An error is
		/// returned by the WinVerifyTrust function if the authorization cabinet file has not been signed.
		/// </para>
		/// <para>
		/// The update agent and <c>AddService2</c> behave in the following ways depending on the AddServiceFlag values that you specify in
		/// the <c>flags</c> parameter:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If you specify <c>asfAllowOnlineRegistration</c> without <c>asfAllowPendingRegistration</c>, the update agent immediately
		/// attempts to go online to register the service. <c>AddService2</c> returns an HRESULT value that reflects the success or failure
		/// of the registration. If the registration fails, the update agent makes no future attempts to register the service.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If you specify <c>asfAllowPendingRegistration</c> without <c>asfAllowOnlineRegistration</c>, the update agent doesn't register
		/// the service immediately. <c>AddService2</c> returns S_OK to indicate that the update agent will attempt to register the service
		/// at a later time, which doesn't guarantee that the registration will eventually succeed.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If you specify <c>asfAllowPendingRegistration</c> and <c>asfAllowOnlineRegistration</c> together, the update agent immediately
		/// attempts to go online to register the service. <c>AddService2</c> returns S_OK if the registration succeeds. <c>AddService2</c>
		/// returns a failure HRESULT value if the registration fails, but the update agent still attempts to register the service at a later time.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If you specify <c>asfAllowPendingRegistration</c>, <c>asfAllowOnlineRegistration</c>, or both, also specify <c>NULL</c> for the
		/// <c>authorizationCabPath</c> parameter.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If you specify neither <c>asfAllowPendingRegistration</c> nor <c>asfAllowOnlineRegistration</c> (in other words, if <c>flags</c>
		/// is either zero or <c>asfRegisterServiceWithAU</c>), you must specify a non- <c>NULL</c> path in the <c>authorizationCabPath</c>
		/// parameter. In this mode, <c>AddService2</c> processes the cabinet file (.cab) and registers the service in the same way as IUpdateServiceManager::AddService.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If you specify <c>asfRegisterServiceWithAU</c>, the change to the default Automatic Updates service doesn't occur (and isn't
		/// reflected in the Windows Update user interface) until the service registration succeeds. This means that if the registration
		/// succeeds immediately (because you specified <c>asfAllowPendingRegistration</c> or supplied a cabinet file (.cab)), the Automatic
		/// Updates service change also occurs immediately. If the registration doesn't succeed until later (because you specified
		/// <c>asfAllowPendingRegistration</c>), the Automatic Updates service change doesn't occur unless the pending service registration
		/// eventually succeeds.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateservicemanager2-addservice2
		// HRESULT AddService2( [in] BSTR serviceID, [in] LONG flags, [in] BSTR authorizationCabPath, [out] IUpdateServiceRegistration **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809347)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IUpdateServiceRegistration AddService2([In, MarshalAs(UnmanagedType.BStr)] string serviceID,
			[In] AddServiceFlag flags, [In, MarshalAs(UnmanagedType.BStr)] string authorizationCabPath);
	}

	/// <summary>Contains information about the registration state of a service.</summary>
	/// <remarks>
	/// You can create an instance of this interface by using the UpdateServiceRegistration coclass. Use the
	/// Microsoft.Update.ServiceRegistration program identifier to create the object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdateserviceregistration
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateServiceRegistration")]
	[ComImport, DefaultMember("RegistrationState"), Guid("DDE02280-12B3-4E0B-937B-6747F6ACB286")]
	public interface IUpdateServiceRegistration
	{
		/// <summary>
		/// <para>Gets an UpdateServiceRegistrationState value that indicates the current state of the service registration.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateserviceregistration-get_registrationstate HRESULT
		// get_RegistrationState( UpdateServiceRegistrationState *retval );
		[DispId(0), ComAliasName("WUApiLib.UpdateServiceRegistrationState")]
		UpdateServiceRegistrationState RegistrationState
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: ComAliasName("WUApiLib.UpdateServiceRegistrationState")]
			get;
		}

		/// <summary>Gets the service identifier.</summary>
		/// <value>The service identifier.</value>
		[DispId(1610743809)]
		string ServiceID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether the service will also be registered with Automatic Updates, when added. The
		/// authorization cabinet file (.cab) of the service determines whether the service can be added.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// If the RegistrationState property is <c>usrsRegistrationPending</c>, registration with Automatic Updates is subject to the
		/// allowed settings that are specified in the authorization cabinet file (.cab) for the service. If the authorization cabinet file
		/// does not allow registration with Automatic Updates, the service will be registered with Windows Update Agent (WUA). However, the
		/// service will not be registered with Automatic Updates.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateserviceregistration-get_ispendingregistrationwithau
		// HRESULT get_IsPendingRegistrationWithAU( VARIANT_BOOL *retval );
		[DispId(1610743810)]
		bool IsPendingRegistrationWithAU
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>
		/// <para>Gets a pointer to an IUpdateService2 interface. This property is the default property.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateserviceregistration-get_service HRESULT get_Service(
		// IUpdateService2 **retval );
		[DispId(1610743811)]
		IUpdateService2 Service
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	/// <summary>
	/// Represents a session in which the caller can perform operations that involve updates. For example, this interface represents sessions
	/// in which the caller performs a search, download, installation, or uninstallation operation.
	/// </summary>
	/// <remarks>
	/// You can create an instance of this interface by using the UpdateSession coclass. Use the Microsoft.Update.Session program identifier
	/// to create the object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatesession
	[ComImport, Guid("816858A4-260D-4260-933A-2585F1ABC76B"), CoClass(typeof(UpdateSessionClass))]
	public interface IUpdateSession
	{
		/// <summary>
		/// <para>Gets and sets the current client application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>Returns the Unknown value if the client application has not set the property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-put_clientapplicationid HRESULT
		// put_ClientApplicationID( BSTR value );
		[DispId(1610743809)]
		string? ClientApplicationID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the session object is read-only.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-get_readonly HRESULT get_ReadOnly( VARIANT_BOOL
		// *retval );
		[DispId(1610743810)]
		bool ReadOnly
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>
		/// <para>Gets and sets the proxy settings that are used to access the server.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-get_webproxy HRESULT get_WebProxy( IWebProxy
		// **retval );
		[DispId(1610743811)]
		IWebProxy WebProxy
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[param: In, MarshalAs(UnmanagedType.Interface)]
			set;
		}

		/// <summary>Returns an IUpdateSearcher interface for this session.</summary>
		/// <returns>An IUpdateSearcher interface for this session.</returns>
		/// <remarks>An IUpdateSearcher interface can also be created by using the UpdateSearcher coclass.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-createupdatesearcher HRESULT
		// CreateUpdateSearcher( [out] IUpdateSearcher **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IUpdateSearcher CreateUpdateSearcher();

		/// <summary>Returns an IUpdateDownloader interface for this session.</summary>
		/// <returns>An IUpdateDownloader interface for this session.</returns>
		/// <remarks>An IUpdateDownloader interface can also be created by using the UpdateDownloader coclass.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-createupdatedownloader HRESULT
		// CreateUpdateDownloader( [out] IUpdateDownloader **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IUpdateDownloader CreateUpdateDownloader();

		/// <summary>Returns an IUpdateInstaller interface for this session.</summary>
		/// <returns>An IUpdateInstaller interface for this session.</returns>
		/// <remarks>An IUpdateInstaller interface can also be created by using the UpdateInstaller coclass.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-createupdateinstaller HRESULT
		// CreateUpdateInstaller( [out] IUpdateInstaller **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IUpdateInstaller CreateUpdateInstaller();
	}

	/// <summary>
	/// Represents a session in which the caller can perform operations that involve updates. For example, this interface represents sessions
	/// in which the caller performs a search, download, installation, or uninstallation operation.
	/// </summary>
	/// <remarks>
	/// You can create an instance of this interface by using the UpdateSession coclass. Use the Microsoft.Update.Session program identifier
	/// to create the object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatesession2
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateSession2")]
	[ComImport, Guid("91CAF7B0-EB23-49ED-9937-C52D817F46F7"), CoClass(typeof(UpdateSessionClass))]
	public interface IUpdateSession2 : IUpdateSession
	{
		/// <summary>
		/// <para>Gets and sets the current client application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>Returns the Unknown value if the client application has not set the property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-put_clientapplicationid HRESULT
		// put_ClientApplicationID( BSTR value );
		[DispId(1610743809)]
		new string? ClientApplicationID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the session object is read-only.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-get_readonly HRESULT get_ReadOnly( VARIANT_BOOL
		// *retval );
		[DispId(1610743810)]
		new bool ReadOnly
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>
		/// <para>Gets and sets the proxy settings that are used to access the server.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-get_webproxy HRESULT get_WebProxy( IWebProxy
		// **retval );
		[DispId(1610743811)]
		new IWebProxy WebProxy
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[param: In, MarshalAs(UnmanagedType.Interface)]
			set;
		}

		/// <summary>Returns an IUpdateSearcher interface for this session.</summary>
		/// <returns>An IUpdateSearcher interface for this session.</returns>
		/// <remarks>An IUpdateSearcher interface can also be created by using the UpdateSearcher coclass.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-createupdatesearcher HRESULT
		// CreateUpdateSearcher( [out] IUpdateSearcher **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IUpdateSearcher CreateUpdateSearcher();

		/// <summary>Returns an IUpdateDownloader interface for this session.</summary>
		/// <returns>An IUpdateDownloader interface for this session.</returns>
		/// <remarks>An IUpdateDownloader interface can also be created by using the UpdateDownloader coclass.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-createupdatedownloader HRESULT
		// CreateUpdateDownloader( [out] IUpdateDownloader **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IUpdateDownloader CreateUpdateDownloader();

		/// <summary>Returns an IUpdateInstaller interface for this session.</summary>
		/// <returns>An IUpdateInstaller interface for this session.</returns>
		/// <remarks>An IUpdateInstaller interface can also be created by using the UpdateInstaller coclass.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-createupdateinstaller HRESULT
		// CreateUpdateInstaller( [out] IUpdateInstaller **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IUpdateInstaller CreateUpdateInstaller();

		/// <summary>
		/// <para>Gets and sets the preferred locale for which update information is retrieved..</para>
		/// <para>
		/// If you do not specify the locale, the default is the user locale that GetUserDefaultUILanguage returns. If the information is not
		/// available in a specified locale or in the user locale, Windows Update Agent (WUA) tries to retrieve the information from the
		/// default update locale.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A search from an <c>UpdateSearch</c> object that was created from the <c>UpdateSession</c> object fails if the following
		/// conditions are true:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>A user or a power user set the <c>UserLocale</c> property for the IUpdateSession2 interface to a locale.</description>
		/// </item>
		/// <item>
		/// <description>The locale corresponds to a language that is not installed on the computer.</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession2-put_userlocale HRESULT put_UserLocale( LCID
		// lcid );
		[DispId(1610809345)]
		LCID UserLocale
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[param: In]
			set;
		}
	}

	/// <summary>
	/// Represents a session in which the caller can perform operations that involve updates. For example, this interface represents sessions
	/// in which the caller performs a search, download, installation, or uninstallation operation.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatesession3
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateSession3")]
	[ComImport, Guid("918EFD1E-B5D8-4C90-8540-AEB9BDC56F9D"), CoClass(typeof(UpdateSessionClass))]
	public interface IUpdateSession3 : IUpdateSession2
	{
		/// <summary>
		/// <para>Gets and sets the current client application.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>Returns the Unknown value if the client application has not set the property.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-put_clientapplicationid HRESULT
		// put_ClientApplicationID( BSTR value );
		[DispId(1610743809)]
		new string? ClientApplicationID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the session object is read-only.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-get_readonly HRESULT get_ReadOnly( VARIANT_BOOL
		// *retval );
		[DispId(1610743810)]
		new bool ReadOnly
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			get;
		}

		/// <summary>
		/// <para>Gets and sets the proxy settings that are used to access the server.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-get_webproxy HRESULT get_WebProxy( IWebProxy
		// **retval );
		[DispId(1610743811)]
		new IWebProxy WebProxy
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[param: In, MarshalAs(UnmanagedType.Interface)]
			set;
		}

		/// <summary>Returns an IUpdateSearcher interface for this session.</summary>
		/// <returns>An IUpdateSearcher interface for this session.</returns>
		/// <remarks>An IUpdateSearcher interface can also be created by using the UpdateSearcher coclass.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-createupdatesearcher HRESULT
		// CreateUpdateSearcher( [out] IUpdateSearcher **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IUpdateSearcher CreateUpdateSearcher();

		/// <summary>Returns an IUpdateDownloader interface for this session.</summary>
		/// <returns>An IUpdateDownloader interface for this session.</returns>
		/// <remarks>An IUpdateDownloader interface can also be created by using the UpdateDownloader coclass.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-createupdatedownloader HRESULT
		// CreateUpdateDownloader( [out] IUpdateDownloader **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IUpdateDownloader CreateUpdateDownloader();

		/// <summary>Returns an IUpdateInstaller interface for this session.</summary>
		/// <returns>An IUpdateInstaller interface for this session.</returns>
		/// <remarks>An IUpdateInstaller interface can also be created by using the UpdateInstaller coclass.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession-createupdateinstaller HRESULT
		// CreateUpdateInstaller( [out] IUpdateInstaller **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IUpdateInstaller CreateUpdateInstaller();

		/// <summary>
		/// <para>Gets and sets the preferred locale for which update information is retrieved..</para>
		/// <para>
		/// If you do not specify the locale, the default is the user locale that GetUserDefaultUILanguage returns. If the information is not
		/// available in a specified locale or in the user locale, Windows Update Agent (WUA) tries to retrieve the information from the
		/// default update locale.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A search from an <c>UpdateSearch</c> object that was created from the <c>UpdateSession</c> object fails if the following
		/// conditions are true:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>A user or a power user set the <c>UserLocale</c> property for the IUpdateSession2 interface to a locale.</description>
		/// </item>
		/// <item>
		/// <description>The locale corresponds to a language that is not installed on the computer.</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession2-put_userlocale HRESULT put_UserLocale( LCID
		// lcid );
		[DispId(1610809345)]
		new LCID UserLocale
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[param: In]
			set;
		}

		/// <summary>Returns a pointer to an IUpdateServiceManager2 interface for the session.</summary>
		/// <returns>A pointer to an IUpdateServiceManager2 interface for the session.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession3-createupdateservicemanager HRESULT
		// CreateUpdateServiceManager( [out] IUpdateServiceManager2 **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874881)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IUpdateServiceManager CreateUpdateServiceManager();

		/// <summary>
		/// Synchronously queries the computer for the history of update events. This method returns a pointer to an
		/// IUpdateHistoryEntryCollection interface that contains matching event records on the computer.
		/// </summary>
		/// <param name="criteria">A string that specifies the search criteria.</param>
		/// <param name="startIndex">The index of the first event to retrieve.</param>
		/// <param name="count">The number of events to retrieve.</param>
		/// <returns>
		/// A pointer to an IUpdateHistoryEntryCollection interface that contains the matching event records on the computer in descending
		/// chronological order.
		/// </returns>
		/// <remarks>
		/// <para>The collection of events that is returned is sorted by the date in descending order.</para>
		/// <para>
		/// The string that is used for the <c>criteria</c> parameter must match the custom search language for <c>QueryHistory</c>. The
		/// string contains criteria that are evaluated to determine which history events to return.
		/// </para>
		/// <para>Note that <c>QueryHistory</c> supports per-machine updates only.</para>
		/// <para>For a complete description of search criteria syntax, see Search.</para>
		/// <para>
		/// The following table identifies all the public support criteria, in the order of evaluation precedence. More criteria may be added
		/// to this list in the future.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Criterion</description>
		/// <description>Type</description>
		/// <description>Allowed operators</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>UpdateID</description>
		/// <description><c>string(UUID)</c></description>
		/// <description><c>=</c></description>
		/// <description>
		/// Finds updates that have an UpdateIdentity.UpdateID of the specified value. For example,
		/// "UpdateID='12345678-9abc-def0-1234-56789abcdef0'" finds updates for UpdateIdentity.UpdateID that equal 12345678-9abc-def0-1234-56789abcdef0.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatesession3-queryhistory HRESULT QueryHistory( [in] BSTR
		// criteria, [in] LONG startIndex, [in] LONG count, [out] IUpdateHistoryEntryCollection **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874882)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IUpdateHistoryEntryCollection QueryHistory([In, MarshalAs(UnmanagedType.BStr)] string criteria, [In] int startIndex, [In] int count);
	}

	/// <summary>
	/// <para>Contains the HTTP proxy settings.</para>
	/// <para><c>Important</c>  This interface is not supported on Windows 10 and Windows Server 2016. See the remarks for more details.</para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// You can create an instance of this interface by using the WebProxy coclass. Use the Microsoft.Update.WebProxy program identifier to
	/// create the object.
	/// </para>
	/// <para>
	/// <c>Important</c>  This interface is not supported on Windows 10 and Windows Server 2016. To configure proxy settings on these
	/// operating systems (including proxy settings for Windows Update Agent), use the <c>Proxy</c> page of the <c>Network &amp; Internet</c>
	/// section in <c>Settings</c>. You can optionally use a proxy auto-config script to apply settings. If you configure proxy settings, be
	/// sure to allow access to the domains used by Windows Update listed in this article.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iwebproxy
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IWebProxy")]
	[ComImport, Guid("174C81FE-AECD-4DAE-B8A0-2C6318DD86A8"), CoClass(typeof(WebProxyClass))]
	public interface IWebProxy
	{
		/// <summary>
		/// <para>Gets and sets the address and the decimal port number of the proxy server.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// The value of the <c>Address</c> property is ignored if the value of the AutoDetect property is set to <c>VARIANT_TRUE</c>. When
		/// <c>Address</c> is a null reference (for example, if you specified Nothing in Visual Basic), all the requests bypass the proxy.
		/// The requests connect directly to the destination host.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwebproxy-get_address HRESULT get_Address( BSTR *retval );
		[DispId(1610743809)]
		string? Address
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>Gets and sets a collection of addresses that do not use the proxy server.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>The value of the <c>BypassList</c> property is ignored if the value of the AutoDetect property is set to <c>VARIANT_TRUE</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwebproxy-get_bypasslist HRESULT get_BypassList(
		// IStringCollection **retval );
		[DispId(1610743810)]
		IStringCollection BypassList
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[param: In, MarshalAs(UnmanagedType.Interface)]
			set;
		}

		/// <summary>
		/// <para>Gets and sets a Boolean value that indicates whether local addresses bypass the proxy server.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// The value of the <c>BypassProxyOnLocal</c> property is ignored if the value of the AutoDetect property is set to <c>VARIANT_TRUE</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwebproxy-get_bypassproxyonlocal HRESULT
		// get_BypassProxyOnLocal( VARIANT_BOOL *retval );
		[DispId(1610743811)]
		bool BypassProxyOnLocal
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the WebProxy object is read-only.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwebproxy-get_readonly HRESULT get_ReadOnly( VARIANT_BOOL
		// *retval );
		[DispId(1610743812)]
		bool ReadOnly
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			get;
		}

		/// <summary>
		/// <para>Gets and sets the user name to submit to the proxy server for authentication.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwebproxy-get_username HRESULT get_UserName( BSTR *retval );
		[DispId(1610743813)]
		string? UserName
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			[param: In, MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>Sets the password to submit to the proxy server for authentication.</summary>
		/// <param name="value">The password to submit to the proxy server for authentication.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwebproxy-setpassword HRESULT SetPassword( BSTR value );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
		void SetPassword([In, MarshalAs(UnmanagedType.BStr)] string? value);

		/// <summary>Prompts the user for the password to use for proxy authentication.</summary>
		/// <param name="parentWindow">The parent window of the dialog box in which the user enters the credentials.</param>
		/// <param name="title">The title to use for the dialog box in which the user enters the credentials.</param>
		/// <remarks>
		/// <para>This method can be changed only by a user on the computer. This method can be accessed through the IDispatch interface.</para>
		/// <para>
		/// If null is specified for the parent window (for example, if you specified Nothing in Visual Basic), the dialog box is displayed
		/// on the desktop.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwebproxy-promptforcredentials HRESULT PromptForCredentials(
		// [in] IUnknown *parentWindow, [in] BSTR title );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
		void PromptForCredentials([In, MarshalAs(UnmanagedType.IUnknown)] object? parentWindow, [In, MarshalAs(UnmanagedType.BStr)] string? title);

		/// <summary>Prompts the user for a password to use for proxy authentication using the <c>hWnd</c> property of the parent window.</summary>
		/// <param name="parentWindow">The parent window of the dialog box in which the user enters the credentials.</param>
		/// <param name="title">The title to use for the dialog box in which the user enters the credentials.</param>
		/// <remarks>
		/// <para>This method can be changed only by a user on the computer. This method can be accessed through the IDispatch interface.</para>
		/// <para>
		/// If null is specified for the parent window (for example, if you specified Nothing in Visual Basic), the dialog box is displayed
		/// on the desktop.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwebproxy-promptforcredentialsfromhwnd HRESULT
		// PromptForCredentialsFromHwnd( [in] HWND parentWindow, [in] BSTR title );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743816)]
		void PromptForCredentialsFromHwnd([In, Optional] HWND parentWindow, [In, MarshalAs(UnmanagedType.BStr)] string? title);

		/// <summary>
		/// <para>Gets and sets a Boolean value that indicates whether IWebProxy automatically detects proxy settings.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>
		/// The values of the Address, BypassList, and BypassProxyOnLocal properties are ignored if the value of the <c>AutoDetect</c>
		/// property is set to <c>VARIANT_TRUE</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwebproxy-get_autodetect HRESULT get_AutoDetect( VARIANT_BOOL
		// *retval );
		[DispId(1610743817)]
		bool AutoDetect
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743817)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743817)]
			[param: In]
			set;
		}
	}

	/// <summary>Contains the properties and the methods that are available only from a Windows driver update.</summary>
	/// <remarks>
	/// This interface can be obtained by calling the QueryInterface method on an IUpdate interface only if the interface represents a
	/// Windows driver update.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iwindowsdriverupdate
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IWindowsDriverUpdate")]
	[ComImport, Guid("B383CD1A-5CE9-4504-9F63-764B1236F191"), DefaultMember("Title")]
	public interface IWindowsDriverUpdate : IUpdate
	{
		/// <summary>
		/// <para>Gets the localized title of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_title HRESULT get_Title( BSTR *retval );
		[DispId(0)]
		new string Title
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update is flagged to be automatically selected by Windows Update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_autoselectonwebsites HRESULT
		// get_AutoSelectOnWebSites( VARIANT_BOOL *retval );
		[DispId(1610743809)]
		new bool AutoSelectOnWebSites
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains information about the ordered list of the bundled updates for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_bundledupdates HRESULT get_BundledUpdates(
		// IUpdateCollection **retval );
		[DispId(1610743810)]
		new IUpdateCollection BundledUpdates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the source media of the update is required for installation or uninstallation.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_canrequiresource HRESULT get_CanRequireSource(
		// VARIANT_BOOL *retval );
		[DispId(1610743811)]
		new bool CanRequireSource
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains a collection of categories to which the update belongs.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property of the IUpdateSession2 interface of the session
		/// that was used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that this property returns is for the default user
		/// interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the
		/// default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// <para>
		/// Because there is a <c>Categories</c> property of IUpdate and a Categories property of IUpdateHistoryEntry2, the information that
		/// is used by the localized properties of the ICategory interface depend on the WUA object that owns the <c>ICategory</c> interface.
		/// If the <c>ICategory</c> interface is returned from the <c>Categories</c> property of <c>IUpdate</c>, it follows the localization
		/// rules of <c>IUpdate</c>. If the <c>ICategory</c> interface is returned from the <c>Categories</c> property of
		/// <c>IUpdateHistoryEntry2</c>, it follows the localization rules of <c>IUpdateHistoryEntry2</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_categories HRESULT get_Categories(
		// ICategoryCollection **retval );
		[DispId(1610743812)]
		new ICategoryCollection Categories
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the date by which the update must be installed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// In COM, if the update has a deadline, the return value is of type VT_DATE and contains a DATE value that specifies the deadline.
		/// Otherwise, the return value is of type VT_EMPTY.
		/// </para>
		/// <para>In the Microsoft .NET Framework, the return value is <c>NULL</c> if the update has no deadline.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deadline HRESULT get_Deadline( VARIANT *retval );
		[DispId(1610743813)]
		new object? Deadline
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether delta-compressed content is available on a server for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deltacompressedcontentavailable HRESULT
		// get_DeltaCompressedContentAvailable( VARIANT_BOOL *retval );
		[DispId(1610743814)]
		new bool DeltaCompressedContentAvailable
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether to prefer delta-compressed content during the download and install or uninstall of
		/// the update if delta-compressed content is available.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deltacompressedcontentpreferred HRESULT
		// get_DeltaCompressedContentPreferred( VARIANT_BOOL *retval );
		[DispId(1610743815)]
		new bool DeltaCompressedContentPreferred
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			get;
		}

		/// <summary>
		/// <para>Gets the localized description of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_description HRESULT get_Description( BSTR *retval );
		[DispId(1610743816)]
		new string? Description
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether the Microsoft Software License Terms that are associated with the update are accepted
		/// for the computer.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_eulaaccepted HRESULT get_EulaAccepted( VARIANT_BOOL
		// *retval );
		[DispId(1610743817)]
		new bool EulaAccepted
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743817)]
			get;
		}

		/// <summary>
		/// <para>Gets the full localized text of the Microsoft Software License Terms that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_eulatext HRESULT get_EulaText( BSTR *retval );
		[DispId(1610743818)]
		new string? EulaText
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the install handler of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The valid values for the <c>HandlerID</c> property include the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The Command Line Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/CommandLineInstallation</description>
		/// </item>
		/// <item>
		/// <description>The Inf Based Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/InfBasedInstallation</description>
		/// </item>
		/// <item>
		/// <description>The Windows Installer Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/WindowsInstaller</description>
		/// </item>
		/// <item>
		/// <description>
		/// The Package Installer for Microsoft Windows Operating Systems and Windows Components (update.exe) Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/WindowsPatch
		/// </description>
		/// </item>
		/// <item>
		/// <description>The Component Based Servicing (CBS) Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/Cbs</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_handlerid HRESULT get_HandlerID( BSTR *retval );
		[DispId(1610743819)]
		new string HandlerID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743819)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the unique identifier of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_identity HRESULT get_Identity( IUpdateIdentity
		// **retval );
		[DispId(1610743820)]
		new IUpdateIdentity Identity
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains information about an image that is associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// <para>This API can return a null pointer as the output, even when the return value is S_OK.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_image HRESULT get_Image( IImageInformation **retval );
		[DispId(1610743821)]
		new IImageInformation? Image
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743821)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the installation options of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// If the current update represents a bundle, the <c>InstallationBehavior</c> property of the bundle will be determined by the
		/// <c>InstallationBehavior</c> property of the child updates of the bundle. This API can return a null pointer as the output, even
		/// when the return value is S_OK.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_installationbehavior HRESULT
		// get_InstallationBehavior( IInstallationBehavior **retval );
		[DispId(1610743822)]
		new IInstallationBehavior InstallationBehavior
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update is a beta release.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isbeta HRESULT get_IsBeta( VARIANT_BOOL *retval );
		[DispId(1610743823)]
		new bool IsBeta
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743823)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether all the update content is cached on the computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isdownloaded HRESULT get_IsDownloaded( VARIANT_BOOL
		// *retval );
		[DispId(1610743824)]
		new bool IsDownloaded
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743824)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether an update is hidden by a user. Administrators, users, and power users can retrieve
		/// the value of this property. However, only administrators and members of the Power Users administrative group can set the value of
		/// this property.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>An attempt to mark a mandatory update as hidden causes an error.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-put_ishidden HRESULT put_IsHidden( VARIANT_BOOL value );
		[DispId(1610743825)]
		new bool IsHidden
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743825)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743825)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update is installed on a computer when the search is performed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isinstalled HRESULT get_IsInstalled( VARIANT_BOOL
		// *retval );
		[DispId(1610743826)]
		new bool IsInstalled
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743826)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the installation of the update is mandatory.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>If you try to mark a mandatory update as hidden, an error occurs.</para>
		/// <para>
		/// Mandatory updates are updates to the Windows Update Agent (WUA) infrastructure. WUA may not require all mandatory updates to
		/// continue operating. However, these updates frequently improve performance or increase the number of products that WUA can offer.
		/// We recommend that you install all mandatory updates.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_ismandatory HRESULT get_IsMandatory( VARIANT_BOOL
		// *retval );
		[DispId(1610743827)]
		new bool IsMandatory
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743827)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether a user can uninstall the update from a computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isuninstallable HRESULT get_IsUninstallable(
		// VARIANT_BOOL *retval );
		[DispId(1610743828)]
		new bool IsUninstallable
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743828)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the languages that are supported by the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property refers to the language of the update itself. The language that is used for the title and description of the update
		/// is not necessarily the language of the update itself.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_languages HRESULT get_Languages( IStringCollection
		// **retval );
		[DispId(1610743829)]
		new IStringCollection Languages
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743829)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the last published date of the update, in Coordinated Universal Time (UTC) date and time, on the server that deploys the update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// On computers that are running Windows XP, the <c>LastDeploymentChangeTime</c> property retrieves the same date and time that are
		/// retrieved by the CreationDate property of the <c>IUpdateApproval</c> interface. The CreationDate property is used on computers
		/// that are running Windows Server 2003.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_lastdeploymentchangetime HRESULT
		// get_LastDeploymentChangeTime( DATE *retval );
		[DispId(1610743830)]
		new DateTime LastDeploymentChangeTime
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743830)]
			get;
		}

		/// <summary>
		/// <para>Gets the maximum download size of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The MinDownloadSize property of an update is always downloaded. However, the <c>MaxDownloadSize</c> property is not always
		/// downloaded. The <c>MaxDownloadSize</c> property is downloaded based on the configuration of the computer that receives the update.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_maxdownloadsize HRESULT get_MaxDownloadSize(
		// DECIMAL *retval );
		[DispId(1610743831)]
		new decimal MaxDownloadSize
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743831)]
			get;
		}

		/// <summary>
		/// <para>Gets the minimum download size of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The <c>MinDownloadSize</c> property of an update is always downloaded. However, the MaxDownloadSize property is not always
		/// downloaded. The <c>MaxDownloadSize</c> property is downloaded based on the configuration of the computer that receives the update.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_mindownloadsize HRESULT get_MinDownloadSize(
		// DECIMAL *retval );
		[DispId(1610743832)]
		new decimal MinDownloadSize
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743832)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of language-specific strings that specify the hyperlinks to more information about the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_moreinfourls HRESULT get_MoreInfoUrls(
		// IStringCollection **retval );
		[DispId(1610743833)]
		new IStringCollection MoreInfoUrls
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743833)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the Microsoft Security Response Center severity rating of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The following ratings are the possible severity ratings of a security issue that is fixed by an update. These ratings were
		/// revised by the Microsoft Security Response Center in November 2002.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Term</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>Critical</description>
		/// <description>A security issue whose exploitation could allow the propagation of an Internet worm without user action.</description>
		/// </item>
		/// <item>
		/// <description>Important</description>
		/// <description>
		/// A security issue whose exploitation could result in compromise of the confidentiality, integrity, or availability of users' data,
		/// or of the integrity or availability of processing resources.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Moderate</description>
		/// <description>
		/// Exploitation is mitigated to a significant degree by factors such as default configuration, auditing, or difficulty of exploitation.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Low</description>
		/// <description>A security issue whose exploitation is extremely difficult, or whose impact is minimal.</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_msrcseverity HRESULT get_MsrcSeverity( BSTR *retval );
		[DispId(1610743834)]
		new string? MsrcSeverity
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743834)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the recommended CPU speed used to install the update, in megahertz (MHz).</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following properties of the IUpdate interface return 0 (zero) when the information is not available:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>RecommendedCpuSpeed</c></description>
		/// </item>
		/// <item>
		/// <description>RecommendedHardDiskSpace</description>
		/// </item>
		/// <item>
		/// <description>RecommendedMemory</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_recommendedcpuspeed HRESULT
		// get_RecommendedCpuSpeed( LONG *retval );
		[DispId(1610743835)]
		new int RecommendedCpuSpeed
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743835)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the recommended free space that should be available on the hard disk before you install the update. The free space is
		/// specified in megabytes (MB).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following properties of the IUpdate interface return 0 (zero) when the information is not available:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>RecommendedCpuSpeed</description>
		/// </item>
		/// <item>
		/// <description><c>RecommendedHardDiskSpace</c></description>
		/// </item>
		/// <item>
		/// <description>RecommendedMemory</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_recommendedharddiskspace HRESULT
		// get_RecommendedHardDiskSpace( LONG *retval );
		[DispId(1610743836)]
		new int RecommendedHardDiskSpace
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743836)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the recommended physical memory size that should be available in your computer before you install the update. The physical
		/// memory size is specified in megabytes (MB).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following properties of the IUpdate interface return 0 (zero) when the information is not available:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>RecommendedCpuSpeed</description>
		/// </item>
		/// <item>
		/// <description>RecommendedHardDiskSpace</description>
		/// </item>
		/// <item>
		/// <description><c>RecommendedMemory</c></description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_recommendedmemory HRESULT get_RecommendedMemory(
		// LONG *retval );
		[DispId(1610743837)]
		new int RecommendedMemory
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743837)]
			get;
		}

		/// <summary>
		/// <para>Gets the localized release notes for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_releasenotes HRESULT get_ReleaseNotes( BSTR *retval );
		[DispId(1610743838)]
		new string? ReleaseNotes
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743838)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of string values that contain the security bulletin IDs that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_securitybulletinids HRESULT
		// get_SecurityBulletinIDs( IStringCollection **retval );
		[DispId(1610743839)]
		new IStringCollection SecurityBulletinIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743839)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a collection of update identifiers. This collection of identifiers specifies the updates that are superseded by the update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_supersededupdateids HRESULT
		// get_SupersededUpdateIDs( IStringCollection **retval );
		[DispId(1610743841)]
		new IStringCollection SupersededUpdateIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743841)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a hyperlink to the language-specific support information for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_supporturl HRESULT get_SupportUrl( BSTR *retval );
		[DispId(1610743842)]
		new string? SupportUrl
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743842)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the type of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_type HRESULT get_Type( UpdateType *retval );
		[ComAliasName("WUApiLib.UpdateType"), DispId(1610743843)]
		new UpdateType Type
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743843)]
			[return: ComAliasName("WUApiLib.UpdateType")]
			get;
		}

		/// <summary>
		/// <para>Gets the uninstallation notes for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_uninstallationnotes HRESULT
		// get_UninstallationNotes( BSTR *retval );
		[DispId(1610743844)]
		new string? UninstallationNotes
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743844)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the uninstallation options for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>This API can return a null pointer as the output, even when the return value is S_OK.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_uninstallationbehavior HRESULT
		// get_UninstallationBehavior( IInstallationBehavior **retval );
		[DispId(1610743845)]
		new IInstallationBehavior? UninstallationBehavior
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743845)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the uninstallation steps for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_uninstallationsteps HRESULT
		// get_UninstallationSteps( IStringCollection **retval );
		[DispId(1610743846)]
		new IStringCollection UninstallationSteps
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743846)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of Microsoft Knowledge Base article IDs that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_kbarticleids HRESULT get_KBArticleIDs(
		// IStringCollection **retval );
		[DispId(1610743848)]
		new IStringCollection KBArticleIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743848)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// Accepts the Microsoft Software License Terms that are associated with Windows Update. Administrators and power users can call
		/// this method.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-accepteula HRESULT AcceptEula();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743847)]
		new void AcceptEula();

		/// <summary>
		/// <para>Gets the action for which the update is deployed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deploymentaction HRESULT get_DeploymentAction(
		// DeploymentAction *retval );
		[ComAliasName("WUApiLib.DeploymentAction"), DispId(1610743849)]
		new DeploymentAction DeploymentAction
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743849)]
			[return: ComAliasName("WUApiLib.DeploymentAction")]
			get;
		}

		/// <summary>Copies the contents of an update to a specified path.</summary>
		/// <param name="path">The path of the location where the update contents are to be copied.</param>
		/// <param name="toExtractCabFiles">
		/// <para>Reserved for future use.</para>
		/// <para>You must set <c>toExtractCabFiles</c> to <c>VARIANT_TRUE</c> or <c>VARIANT_FALSE</c>.</para>
		/// </param>
		/// <remarks>
		/// <para>To copy bundled updates, call this method on the individual updates that are bundled in this update.</para>
		/// <para>
		/// <c>Note</c>  We don't recommend or support the use of the <c>IUpdate::CopyFromCache</c> and IUpdate2::CopyToCache methods to move
		/// downloaded updates from one computer to another computer. When the Windows Update Agent (WUA) downloads an update, it might only
		/// download the portions of the update’s payload that are necessary for a particular client computer. The necessary portions of the
		/// update’s payload can often vary from one computer to another computer, even if the computers have similar hardware and software
		/// configurations. <c>IUpdate2::CopyToCache</c> only works if the provided files are an exact match for the files that Windows
		/// Update would have normally downloaded on that computer; if you called <c>IUpdate::CopyFromCache</c> to obtain the files on a
		/// different computer, the files are likely not to match the files that Windows Update would have normally downloaded so
		/// <c>IUpdate2::CopyToCache</c> might fail.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-copyfromcache HRESULT CopyFromCache( [in] BSTR path,
		// [in] VARIANT_BOOL toExtractCabFiles );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743850)]
		new void CopyFromCache([In, MarshalAs(UnmanagedType.BStr)] string path, [In] bool toExtractCabFiles);

		/// <summary>
		/// <para>Gets the suggested download priority of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_downloadpriority HRESULT get_DownloadPriority(
		// DownloadPriority *retval );
		[DispId(1610743851), ComAliasName("WUApiLib.DownloadPriority")]
		new DownloadPriority DownloadPriority
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743851)]
			[return: ComAliasName("WUApiLib.DownloadPriority")]
			get;
		}

		/// <summary>
		/// <para>Gets file information about the download contents of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_downloadcontents HRESULT get_DownloadContents(
		// IUpdateDownloadContentCollection **retval );
		[DispId(1610743852)]
		new IUpdateDownloadContentCollection DownloadContents
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743852)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the class of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driverclass HRESULT get_DriverClass(
		// BSTR *retval );
		[DispId(1610809345)]
		string? DriverClass
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the hardware ID or compatible ID that the Windows driver update must match to be installable.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driverhardwareid HRESULT
		// get_DriverHardwareID( BSTR *retval );
		[DispId(1610809346)]
		string? DriverHardwareID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809346)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant name of the manufacturer of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_drivermanufacturer HRESULT
		// get_DriverManufacturer( BSTR *retval );
		[DispId(1610809347)]
		string? DriverManufacturer
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809347)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant model name of the device for which the Windows driver update is intended.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_drivermodel HRESULT get_DriverModel(
		// BSTR *retval );
		[DispId(1610809348)]
		string? DriverModel
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809348)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant name of the provider of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driverprovider HRESULT
		// get_DriverProvider( BSTR *retval );
		[DispId(1610809349)]
		string? DriverProvider
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809349)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the driver version date of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driververdate HRESULT
		// get_DriverVerDate( DATE *retval );
		[DispId(1610809350)]
		DateTime DriverVerDate
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809350)]
			get;
		}

		/// <summary>
		/// <para>Gets the problem number of the matching device for the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_deviceproblemnumber HRESULT
		// get_DeviceProblemNumber( LONG *retval );
		[DispId(1610809351)]
		int DeviceProblemNumber
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809351)]
			get;
		}

		/// <summary>
		/// <para>Gets the status of the matching device for the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_devicestatus HRESULT get_DeviceStatus(
		// LONG *retval );
		[DispId(1610809352)]
		int DeviceStatus
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809352)]
			get;
		}
	}

	/// <summary>Contains the properties and methods that are available only from a Windows driver update.</summary>
	/// <remarks>This interface can be obtained by calling QueryInterface method on an IUpdate interface only if the interface represents a Windows Driver update.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iwindowsdriverupdate2
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IWindowsDriverUpdate2")]
	[ComImport, Guid("615C4269-7A48-43BD-96B7-BF6CA27D6C3E"), DefaultMember("Title")]
	public interface IWindowsDriverUpdate2 : IWindowsDriverUpdate
	{
		/// <summary>
		/// <para>Gets the localized title of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_title HRESULT get_Title( BSTR *retval );
		[DispId(0)]
		new string Title
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update is flagged to be automatically selected by Windows Update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_autoselectonwebsites HRESULT
		// get_AutoSelectOnWebSites( VARIANT_BOOL *retval );
		[DispId(1610743809)]
		new bool AutoSelectOnWebSites
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains information about the ordered list of the bundled updates for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_bundledupdates HRESULT get_BundledUpdates(
		// IUpdateCollection **retval );
		[DispId(1610743810)]
		new IUpdateCollection BundledUpdates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the source media of the update is required for installation or uninstallation.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_canrequiresource HRESULT get_CanRequireSource(
		// VARIANT_BOOL *retval );
		[DispId(1610743811)]
		new bool CanRequireSource
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains a collection of categories to which the update belongs.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property of the IUpdateSession2 interface of the session
		/// that was used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that this property returns is for the default user
		/// interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the
		/// default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// <para>
		/// Because there is a <c>Categories</c> property of IUpdate and a Categories property of IUpdateHistoryEntry2, the information that
		/// is used by the localized properties of the ICategory interface depend on the WUA object that owns the <c>ICategory</c> interface.
		/// If the <c>ICategory</c> interface is returned from the <c>Categories</c> property of <c>IUpdate</c>, it follows the localization
		/// rules of <c>IUpdate</c>. If the <c>ICategory</c> interface is returned from the <c>Categories</c> property of
		/// <c>IUpdateHistoryEntry2</c>, it follows the localization rules of <c>IUpdateHistoryEntry2</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_categories HRESULT get_Categories(
		// ICategoryCollection **retval );
		[DispId(1610743812)]
		new ICategoryCollection Categories
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the date by which the update must be installed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// In COM, if the update has a deadline, the return value is of type VT_DATE and contains a DATE value that specifies the deadline.
		/// Otherwise, the return value is of type VT_EMPTY.
		/// </para>
		/// <para>In the Microsoft .NET Framework, the return value is <c>NULL</c> if the update has no deadline.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deadline HRESULT get_Deadline( VARIANT *retval );
		[DispId(1610743813)]
		new object? Deadline
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether delta-compressed content is available on a server for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deltacompressedcontentavailable HRESULT
		// get_DeltaCompressedContentAvailable( VARIANT_BOOL *retval );
		[DispId(1610743814)]
		new bool DeltaCompressedContentAvailable
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether to prefer delta-compressed content during the download and install or uninstall of
		/// the update if delta-compressed content is available.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deltacompressedcontentpreferred HRESULT
		// get_DeltaCompressedContentPreferred( VARIANT_BOOL *retval );
		[DispId(1610743815)]
		new bool DeltaCompressedContentPreferred
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			get;
		}

		/// <summary>
		/// <para>Gets the localized description of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_description HRESULT get_Description( BSTR *retval );
		[DispId(1610743816)]
		new string? Description
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether the Microsoft Software License Terms that are associated with the update are accepted
		/// for the computer.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_eulaaccepted HRESULT get_EulaAccepted( VARIANT_BOOL
		// *retval );
		[DispId(1610743817)]
		new bool EulaAccepted
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743817)]
			get;
		}

		/// <summary>
		/// <para>Gets the full localized text of the Microsoft Software License Terms that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_eulatext HRESULT get_EulaText( BSTR *retval );
		[DispId(1610743818)]
		new string? EulaText
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the install handler of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The valid values for the <c>HandlerID</c> property include the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The Command Line Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/CommandLineInstallation</description>
		/// </item>
		/// <item>
		/// <description>The Inf Based Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/InfBasedInstallation</description>
		/// </item>
		/// <item>
		/// <description>The Windows Installer Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/WindowsInstaller</description>
		/// </item>
		/// <item>
		/// <description>
		/// The Package Installer for Microsoft Windows Operating Systems and Windows Components (update.exe) Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/WindowsPatch
		/// </description>
		/// </item>
		/// <item>
		/// <description>The Component Based Servicing (CBS) Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/Cbs</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_handlerid HRESULT get_HandlerID( BSTR *retval );
		[DispId(1610743819)]
		new string HandlerID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743819)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the unique identifier of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_identity HRESULT get_Identity( IUpdateIdentity
		// **retval );
		[DispId(1610743820)]
		new IUpdateIdentity Identity
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains information about an image that is associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// <para>This API can return a null pointer as the output, even when the return value is S_OK.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_image HRESULT get_Image( IImageInformation **retval );
		[DispId(1610743821)]
		new IImageInformation? Image
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743821)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the installation options of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// If the current update represents a bundle, the <c>InstallationBehavior</c> property of the bundle will be determined by the
		/// <c>InstallationBehavior</c> property of the child updates of the bundle. This API can return a null pointer as the output, even
		/// when the return value is S_OK.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_installationbehavior HRESULT
		// get_InstallationBehavior( IInstallationBehavior **retval );
		[DispId(1610743822)]
		new IInstallationBehavior InstallationBehavior
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update is a beta release.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isbeta HRESULT get_IsBeta( VARIANT_BOOL *retval );
		[DispId(1610743823)]
		new bool IsBeta
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743823)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether all the update content is cached on the computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isdownloaded HRESULT get_IsDownloaded( VARIANT_BOOL
		// *retval );
		[DispId(1610743824)]
		new bool IsDownloaded
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743824)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether an update is hidden by a user. Administrators, users, and power users can retrieve
		/// the value of this property. However, only administrators and members of the Power Users administrative group can set the value of
		/// this property.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>An attempt to mark a mandatory update as hidden causes an error.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-put_ishidden HRESULT put_IsHidden( VARIANT_BOOL value );
		[DispId(1610743825)]
		new bool IsHidden
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743825)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743825)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update is installed on a computer when the search is performed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isinstalled HRESULT get_IsInstalled( VARIANT_BOOL
		// *retval );
		[DispId(1610743826)]
		new bool IsInstalled
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743826)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the installation of the update is mandatory.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>If you try to mark a mandatory update as hidden, an error occurs.</para>
		/// <para>
		/// Mandatory updates are updates to the Windows Update Agent (WUA) infrastructure. WUA may not require all mandatory updates to
		/// continue operating. However, these updates frequently improve performance or increase the number of products that WUA can offer.
		/// We recommend that you install all mandatory updates.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_ismandatory HRESULT get_IsMandatory( VARIANT_BOOL
		// *retval );
		[DispId(1610743827)]
		new bool IsMandatory
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743827)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether a user can uninstall the update from a computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isuninstallable HRESULT get_IsUninstallable(
		// VARIANT_BOOL *retval );
		[DispId(1610743828)]
		new bool IsUninstallable
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743828)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the languages that are supported by the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property refers to the language of the update itself. The language that is used for the title and description of the update
		/// is not necessarily the language of the update itself.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_languages HRESULT get_Languages( IStringCollection
		// **retval );
		[DispId(1610743829)]
		new IStringCollection Languages
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743829)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the last published date of the update, in Coordinated Universal Time (UTC) date and time, on the server that deploys the update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// On computers that are running Windows XP, the <c>LastDeploymentChangeTime</c> property retrieves the same date and time that are
		/// retrieved by the CreationDate property of the <c>IUpdateApproval</c> interface. The CreationDate property is used on computers
		/// that are running Windows Server 2003.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_lastdeploymentchangetime HRESULT
		// get_LastDeploymentChangeTime( DATE *retval );
		[DispId(1610743830)]
		new DateTime LastDeploymentChangeTime
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743830)]
			get;
		}

		/// <summary>
		/// <para>Gets the maximum download size of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The MinDownloadSize property of an update is always downloaded. However, the <c>MaxDownloadSize</c> property is not always
		/// downloaded. The <c>MaxDownloadSize</c> property is downloaded based on the configuration of the computer that receives the update.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_maxdownloadsize HRESULT get_MaxDownloadSize(
		// DECIMAL *retval );
		[DispId(1610743831)]
		new decimal MaxDownloadSize
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743831)]
			get;
		}

		/// <summary>
		/// <para>Gets the minimum download size of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The <c>MinDownloadSize</c> property of an update is always downloaded. However, the MaxDownloadSize property is not always
		/// downloaded. The <c>MaxDownloadSize</c> property is downloaded based on the configuration of the computer that receives the update.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_mindownloadsize HRESULT get_MinDownloadSize(
		// DECIMAL *retval );
		[DispId(1610743832)]
		new decimal MinDownloadSize
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743832)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of language-specific strings that specify the hyperlinks to more information about the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_moreinfourls HRESULT get_MoreInfoUrls(
		// IStringCollection **retval );
		[DispId(1610743833)]
		new IStringCollection MoreInfoUrls
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743833)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the Microsoft Security Response Center severity rating of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The following ratings are the possible severity ratings of a security issue that is fixed by an update. These ratings were
		/// revised by the Microsoft Security Response Center in November 2002.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Term</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>Critical</description>
		/// <description>A security issue whose exploitation could allow the propagation of an Internet worm without user action.</description>
		/// </item>
		/// <item>
		/// <description>Important</description>
		/// <description>
		/// A security issue whose exploitation could result in compromise of the confidentiality, integrity, or availability of users' data,
		/// or of the integrity or availability of processing resources.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Moderate</description>
		/// <description>
		/// Exploitation is mitigated to a significant degree by factors such as default configuration, auditing, or difficulty of exploitation.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Low</description>
		/// <description>A security issue whose exploitation is extremely difficult, or whose impact is minimal.</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_msrcseverity HRESULT get_MsrcSeverity( BSTR *retval );
		[DispId(1610743834)]
		new string? MsrcSeverity
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743834)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the recommended CPU speed used to install the update, in megahertz (MHz).</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following properties of the IUpdate interface return 0 (zero) when the information is not available:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>RecommendedCpuSpeed</c></description>
		/// </item>
		/// <item>
		/// <description>RecommendedHardDiskSpace</description>
		/// </item>
		/// <item>
		/// <description>RecommendedMemory</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_recommendedcpuspeed HRESULT
		// get_RecommendedCpuSpeed( LONG *retval );
		[DispId(1610743835)]
		new int RecommendedCpuSpeed
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743835)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the recommended free space that should be available on the hard disk before you install the update. The free space is
		/// specified in megabytes (MB).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following properties of the IUpdate interface return 0 (zero) when the information is not available:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>RecommendedCpuSpeed</description>
		/// </item>
		/// <item>
		/// <description><c>RecommendedHardDiskSpace</c></description>
		/// </item>
		/// <item>
		/// <description>RecommendedMemory</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_recommendedharddiskspace HRESULT
		// get_RecommendedHardDiskSpace( LONG *retval );
		[DispId(1610743836)]
		new int RecommendedHardDiskSpace
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743836)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the recommended physical memory size that should be available in your computer before you install the update. The physical
		/// memory size is specified in megabytes (MB).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following properties of the IUpdate interface return 0 (zero) when the information is not available:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>RecommendedCpuSpeed</description>
		/// </item>
		/// <item>
		/// <description>RecommendedHardDiskSpace</description>
		/// </item>
		/// <item>
		/// <description><c>RecommendedMemory</c></description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_recommendedmemory HRESULT get_RecommendedMemory(
		// LONG *retval );
		[DispId(1610743837)]
		new int RecommendedMemory
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743837)]
			get;
		}

		/// <summary>
		/// <para>Gets the localized release notes for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_releasenotes HRESULT get_ReleaseNotes( BSTR *retval );
		[DispId(1610743838)]
		new string? ReleaseNotes
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743838)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of string values that contain the security bulletin IDs that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_securitybulletinids HRESULT
		// get_SecurityBulletinIDs( IStringCollection **retval );
		[DispId(1610743839)]
		new IStringCollection SecurityBulletinIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743839)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a collection of update identifiers. This collection of identifiers specifies the updates that are superseded by the update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_supersededupdateids HRESULT
		// get_SupersededUpdateIDs( IStringCollection **retval );
		[DispId(1610743841)]
		new IStringCollection SupersededUpdateIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743841)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a hyperlink to the language-specific support information for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_supporturl HRESULT get_SupportUrl( BSTR *retval );
		[DispId(1610743842)]
		new string? SupportUrl
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743842)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the type of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_type HRESULT get_Type( UpdateType *retval );
		[ComAliasName("WUApiLib.UpdateType"), DispId(1610743843)]
		new UpdateType Type
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743843)]
			[return: ComAliasName("WUApiLib.UpdateType")]
			get;
		}

		/// <summary>
		/// <para>Gets the uninstallation notes for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_uninstallationnotes HRESULT
		// get_UninstallationNotes( BSTR *retval );
		[DispId(1610743844)]
		new string? UninstallationNotes
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743844)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the uninstallation options for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>This API can return a null pointer as the output, even when the return value is S_OK.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_uninstallationbehavior HRESULT
		// get_UninstallationBehavior( IInstallationBehavior **retval );
		[DispId(1610743845)]
		new IInstallationBehavior? UninstallationBehavior
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743845)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the uninstallation steps for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_uninstallationsteps HRESULT
		// get_UninstallationSteps( IStringCollection **retval );
		[DispId(1610743846)]
		new IStringCollection UninstallationSteps
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743846)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of Microsoft Knowledge Base article IDs that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_kbarticleids HRESULT get_KBArticleIDs(
		// IStringCollection **retval );
		[DispId(1610743848)]
		new IStringCollection KBArticleIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743848)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// Accepts the Microsoft Software License Terms that are associated with Windows Update. Administrators and power users can call
		/// this method.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-accepteula HRESULT AcceptEula();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743847)]
		new void AcceptEula();

		/// <summary>
		/// <para>Gets the action for which the update is deployed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deploymentaction HRESULT get_DeploymentAction(
		// DeploymentAction *retval );
		[ComAliasName("WUApiLib.DeploymentAction"), DispId(1610743849)]
		new DeploymentAction DeploymentAction
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743849)]
			[return: ComAliasName("WUApiLib.DeploymentAction")]
			get;
		}

		/// <summary>Copies the contents of an update to a specified path.</summary>
		/// <param name="path">The path of the location where the update contents are to be copied.</param>
		/// <param name="toExtractCabFiles">
		/// <para>Reserved for future use.</para>
		/// <para>You must set <c>toExtractCabFiles</c> to <c>VARIANT_TRUE</c> or <c>VARIANT_FALSE</c>.</para>
		/// </param>
		/// <remarks>
		/// <para>To copy bundled updates, call this method on the individual updates that are bundled in this update.</para>
		/// <para>
		/// <c>Note</c>  We don't recommend or support the use of the <c>IUpdate::CopyFromCache</c> and IUpdate2::CopyToCache methods to move
		/// downloaded updates from one computer to another computer. When the Windows Update Agent (WUA) downloads an update, it might only
		/// download the portions of the update’s payload that are necessary for a particular client computer. The necessary portions of the
		/// update’s payload can often vary from one computer to another computer, even if the computers have similar hardware and software
		/// configurations. <c>IUpdate2::CopyToCache</c> only works if the provided files are an exact match for the files that Windows
		/// Update would have normally downloaded on that computer; if you called <c>IUpdate::CopyFromCache</c> to obtain the files on a
		/// different computer, the files are likely not to match the files that Windows Update would have normally downloaded so
		/// <c>IUpdate2::CopyToCache</c> might fail.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-copyfromcache HRESULT CopyFromCache( [in] BSTR path,
		// [in] VARIANT_BOOL toExtractCabFiles );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743850)]
		new void CopyFromCache([In, MarshalAs(UnmanagedType.BStr)] string path, [In] bool toExtractCabFiles);

		/// <summary>
		/// <para>Gets the suggested download priority of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_downloadpriority HRESULT get_DownloadPriority(
		// DownloadPriority *retval );
		[DispId(1610743851), ComAliasName("WUApiLib.DownloadPriority")]
		new DownloadPriority DownloadPriority
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743851)]
			[return: ComAliasName("WUApiLib.DownloadPriority")]
			get;
		}

		/// <summary>
		/// <para>Gets file information about the download contents of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_downloadcontents HRESULT get_DownloadContents(
		// IUpdateDownloadContentCollection **retval );
		[DispId(1610743852)]
		new IUpdateDownloadContentCollection DownloadContents
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743852)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the class of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driverclass HRESULT get_DriverClass(
		// BSTR *retval );
		[DispId(1610809345)]
		new string? DriverClass
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the hardware ID or compatible ID that the Windows driver update must match to be installable.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driverhardwareid HRESULT
		// get_DriverHardwareID( BSTR *retval );
		[DispId(1610809346)]
		new string? DriverHardwareID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809346)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant name of the manufacturer of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_drivermanufacturer HRESULT
		// get_DriverManufacturer( BSTR *retval );
		[DispId(1610809347)]
		new string? DriverManufacturer
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809347)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant model name of the device for which the Windows driver update is intended.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_drivermodel HRESULT get_DriverModel(
		// BSTR *retval );
		[DispId(1610809348)]
		new string? DriverModel
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809348)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant name of the provider of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driverprovider HRESULT
		// get_DriverProvider( BSTR *retval );
		[DispId(1610809349)]
		new string? DriverProvider
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809349)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the driver version date of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driververdate HRESULT
		// get_DriverVerDate( DATE *retval );
		[DispId(1610809350)]
		new DateTime DriverVerDate
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809350)]
			get;
		}

		/// <summary>
		/// <para>Gets the problem number of the matching device for the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_deviceproblemnumber HRESULT
		// get_DeviceProblemNumber( LONG *retval );
		[DispId(1610809351)]
		new int DeviceProblemNumber
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809351)]
			get;
		}

		/// <summary>
		/// <para>Gets the status of the matching device for the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_devicestatus HRESULT get_DeviceStatus(
		// LONG *retval );
		[DispId(1610809352)]
		new int DeviceStatus
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809352)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the computer must be restarted after you install or uninstall an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-get_rebootrequired
		// HRESULT get_RebootRequired( VARIANT_BOOL *retval );
		[DispId(1610874881)]
		bool RebootRequired
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874881)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update is installed on a computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-get_ispresent
		// HRESULT get_IsPresent( VARIANT_BOOL *retval );
		[DispId(1610874883)]
		bool IsPresent
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874883)]
			get;
		}

		/// <summary>
		/// <para>Contains a collection of the Common Vulnerabilities and Exposures (CVE) identifiers that are associated with an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-get_cveids
		// HRESULT get_CveIDs( IStringCollection **retval );
		[DispId(1610874884)]
		IStringCollection CveIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874884)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>Copies the external update binaries to an update.</summary>
		/// <param name="pFiles">An IStringCollection interface that contains the strings to be copied to an update.</param>
		/// <remarks>This method returns <c>WU_E_INVALID_OPERATION</c> if the object that is implementing the interface has been locked down.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-copytocache
		// HRESULT CopyToCache( [in] IStringCollection *pFiles );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874882)]
		void CopyToCache([In, MarshalAs(UnmanagedType.Interface)] IStringCollection pFiles);
	}

	/// <summary>Contains the properties and methods that are available only from a Windows driver update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iwindowsdriverupdate3
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IWindowsDriverUpdate3")]
	[ComImport, Guid("49EBD502-4A96-41BD-9E3E-4C5057F4250C"), DefaultMember("Title")]
	public interface IWindowsDriverUpdate3 : IWindowsDriverUpdate2
	{
		/// <summary>
		/// <para>Gets the localized title of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_title HRESULT get_Title( BSTR *retval );
		[DispId(0)]
		new string Title
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update is flagged to be automatically selected by Windows Update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_autoselectonwebsites HRESULT
		// get_AutoSelectOnWebSites( VARIANT_BOOL *retval );
		[DispId(1610743809)]
		new bool AutoSelectOnWebSites
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains information about the ordered list of the bundled updates for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_bundledupdates HRESULT get_BundledUpdates(
		// IUpdateCollection **retval );
		[DispId(1610743810)]
		new IUpdateCollection BundledUpdates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the source media of the update is required for installation or uninstallation.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_canrequiresource HRESULT get_CanRequireSource(
		// VARIANT_BOOL *retval );
		[DispId(1610743811)]
		new bool CanRequireSource
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains a collection of categories to which the update belongs.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property of the IUpdateSession2 interface of the session
		/// that was used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that this property returns is for the default user
		/// interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the
		/// default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// <para>
		/// Because there is a <c>Categories</c> property of IUpdate and a Categories property of IUpdateHistoryEntry2, the information that
		/// is used by the localized properties of the ICategory interface depend on the WUA object that owns the <c>ICategory</c> interface.
		/// If the <c>ICategory</c> interface is returned from the <c>Categories</c> property of <c>IUpdate</c>, it follows the localization
		/// rules of <c>IUpdate</c>. If the <c>ICategory</c> interface is returned from the <c>Categories</c> property of
		/// <c>IUpdateHistoryEntry2</c>, it follows the localization rules of <c>IUpdateHistoryEntry2</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_categories HRESULT get_Categories(
		// ICategoryCollection **retval );
		[DispId(1610743812)]
		new ICategoryCollection Categories
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the date by which the update must be installed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// In COM, if the update has a deadline, the return value is of type VT_DATE and contains a DATE value that specifies the deadline.
		/// Otherwise, the return value is of type VT_EMPTY.
		/// </para>
		/// <para>In the Microsoft .NET Framework, the return value is <c>NULL</c> if the update has no deadline.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deadline HRESULT get_Deadline( VARIANT *retval );
		[DispId(1610743813)]
		new object? Deadline
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether delta-compressed content is available on a server for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deltacompressedcontentavailable HRESULT
		// get_DeltaCompressedContentAvailable( VARIANT_BOOL *retval );
		[DispId(1610743814)]
		new bool DeltaCompressedContentAvailable
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether to prefer delta-compressed content during the download and install or uninstall of
		/// the update if delta-compressed content is available.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deltacompressedcontentpreferred HRESULT
		// get_DeltaCompressedContentPreferred( VARIANT_BOOL *retval );
		[DispId(1610743815)]
		new bool DeltaCompressedContentPreferred
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			get;
		}

		/// <summary>
		/// <para>Gets the localized description of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_description HRESULT get_Description( BSTR *retval );
		[DispId(1610743816)]
		new string? Description
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether the Microsoft Software License Terms that are associated with the update are accepted
		/// for the computer.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_eulaaccepted HRESULT get_EulaAccepted( VARIANT_BOOL
		// *retval );
		[DispId(1610743817)]
		new bool EulaAccepted
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743817)]
			get;
		}

		/// <summary>
		/// <para>Gets the full localized text of the Microsoft Software License Terms that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_eulatext HRESULT get_EulaText( BSTR *retval );
		[DispId(1610743818)]
		new string? EulaText
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the install handler of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The valid values for the <c>HandlerID</c> property include the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The Command Line Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/CommandLineInstallation</description>
		/// </item>
		/// <item>
		/// <description>The Inf Based Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/InfBasedInstallation</description>
		/// </item>
		/// <item>
		/// <description>The Windows Installer Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/WindowsInstaller</description>
		/// </item>
		/// <item>
		/// <description>
		/// The Package Installer for Microsoft Windows Operating Systems and Windows Components (update.exe) Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/WindowsPatch
		/// </description>
		/// </item>
		/// <item>
		/// <description>The Component Based Servicing (CBS) Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/Cbs</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_handlerid HRESULT get_HandlerID( BSTR *retval );
		[DispId(1610743819)]
		new string HandlerID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743819)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the unique identifier of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_identity HRESULT get_Identity( IUpdateIdentity
		// **retval );
		[DispId(1610743820)]
		new IUpdateIdentity Identity
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains information about an image that is associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// <para>This API can return a null pointer as the output, even when the return value is S_OK.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_image HRESULT get_Image( IImageInformation **retval );
		[DispId(1610743821)]
		new IImageInformation? Image
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743821)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the installation options of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// If the current update represents a bundle, the <c>InstallationBehavior</c> property of the bundle will be determined by the
		/// <c>InstallationBehavior</c> property of the child updates of the bundle. This API can return a null pointer as the output, even
		/// when the return value is S_OK.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_installationbehavior HRESULT
		// get_InstallationBehavior( IInstallationBehavior **retval );
		[DispId(1610743822)]
		new IInstallationBehavior InstallationBehavior
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update is a beta release.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isbeta HRESULT get_IsBeta( VARIANT_BOOL *retval );
		[DispId(1610743823)]
		new bool IsBeta
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743823)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether all the update content is cached on the computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isdownloaded HRESULT get_IsDownloaded( VARIANT_BOOL
		// *retval );
		[DispId(1610743824)]
		new bool IsDownloaded
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743824)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether an update is hidden by a user. Administrators, users, and power users can retrieve
		/// the value of this property. However, only administrators and members of the Power Users administrative group can set the value of
		/// this property.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>An attempt to mark a mandatory update as hidden causes an error.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-put_ishidden HRESULT put_IsHidden( VARIANT_BOOL value );
		[DispId(1610743825)]
		new bool IsHidden
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743825)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743825)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update is installed on a computer when the search is performed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isinstalled HRESULT get_IsInstalled( VARIANT_BOOL
		// *retval );
		[DispId(1610743826)]
		new bool IsInstalled
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743826)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the installation of the update is mandatory.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>If you try to mark a mandatory update as hidden, an error occurs.</para>
		/// <para>
		/// Mandatory updates are updates to the Windows Update Agent (WUA) infrastructure. WUA may not require all mandatory updates to
		/// continue operating. However, these updates frequently improve performance or increase the number of products that WUA can offer.
		/// We recommend that you install all mandatory updates.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_ismandatory HRESULT get_IsMandatory( VARIANT_BOOL
		// *retval );
		[DispId(1610743827)]
		new bool IsMandatory
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743827)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether a user can uninstall the update from a computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isuninstallable HRESULT get_IsUninstallable(
		// VARIANT_BOOL *retval );
		[DispId(1610743828)]
		new bool IsUninstallable
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743828)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the languages that are supported by the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property refers to the language of the update itself. The language that is used for the title and description of the update
		/// is not necessarily the language of the update itself.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_languages HRESULT get_Languages( IStringCollection
		// **retval );
		[DispId(1610743829)]
		new IStringCollection Languages
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743829)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the last published date of the update, in Coordinated Universal Time (UTC) date and time, on the server that deploys the update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// On computers that are running Windows XP, the <c>LastDeploymentChangeTime</c> property retrieves the same date and time that are
		/// retrieved by the CreationDate property of the <c>IUpdateApproval</c> interface. The CreationDate property is used on computers
		/// that are running Windows Server 2003.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_lastdeploymentchangetime HRESULT
		// get_LastDeploymentChangeTime( DATE *retval );
		[DispId(1610743830)]
		new DateTime LastDeploymentChangeTime
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743830)]
			get;
		}

		/// <summary>
		/// <para>Gets the maximum download size of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The MinDownloadSize property of an update is always downloaded. However, the <c>MaxDownloadSize</c> property is not always
		/// downloaded. The <c>MaxDownloadSize</c> property is downloaded based on the configuration of the computer that receives the update.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_maxdownloadsize HRESULT get_MaxDownloadSize(
		// DECIMAL *retval );
		[DispId(1610743831)]
		new decimal MaxDownloadSize
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743831)]
			get;
		}

		/// <summary>
		/// <para>Gets the minimum download size of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The <c>MinDownloadSize</c> property of an update is always downloaded. However, the MaxDownloadSize property is not always
		/// downloaded. The <c>MaxDownloadSize</c> property is downloaded based on the configuration of the computer that receives the update.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_mindownloadsize HRESULT get_MinDownloadSize(
		// DECIMAL *retval );
		[DispId(1610743832)]
		new decimal MinDownloadSize
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743832)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of language-specific strings that specify the hyperlinks to more information about the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_moreinfourls HRESULT get_MoreInfoUrls(
		// IStringCollection **retval );
		[DispId(1610743833)]
		new IStringCollection MoreInfoUrls
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743833)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the Microsoft Security Response Center severity rating of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The following ratings are the possible severity ratings of a security issue that is fixed by an update. These ratings were
		/// revised by the Microsoft Security Response Center in November 2002.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Term</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>Critical</description>
		/// <description>A security issue whose exploitation could allow the propagation of an Internet worm without user action.</description>
		/// </item>
		/// <item>
		/// <description>Important</description>
		/// <description>
		/// A security issue whose exploitation could result in compromise of the confidentiality, integrity, or availability of users' data,
		/// or of the integrity or availability of processing resources.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Moderate</description>
		/// <description>
		/// Exploitation is mitigated to a significant degree by factors such as default configuration, auditing, or difficulty of exploitation.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Low</description>
		/// <description>A security issue whose exploitation is extremely difficult, or whose impact is minimal.</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_msrcseverity HRESULT get_MsrcSeverity( BSTR *retval );
		[DispId(1610743834)]
		new string? MsrcSeverity
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743834)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the recommended CPU speed used to install the update, in megahertz (MHz).</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following properties of the IUpdate interface return 0 (zero) when the information is not available:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>RecommendedCpuSpeed</c></description>
		/// </item>
		/// <item>
		/// <description>RecommendedHardDiskSpace</description>
		/// </item>
		/// <item>
		/// <description>RecommendedMemory</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_recommendedcpuspeed HRESULT
		// get_RecommendedCpuSpeed( LONG *retval );
		[DispId(1610743835)]
		new int RecommendedCpuSpeed
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743835)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the recommended free space that should be available on the hard disk before you install the update. The free space is
		/// specified in megabytes (MB).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following properties of the IUpdate interface return 0 (zero) when the information is not available:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>RecommendedCpuSpeed</description>
		/// </item>
		/// <item>
		/// <description><c>RecommendedHardDiskSpace</c></description>
		/// </item>
		/// <item>
		/// <description>RecommendedMemory</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_recommendedharddiskspace HRESULT
		// get_RecommendedHardDiskSpace( LONG *retval );
		[DispId(1610743836)]
		new int RecommendedHardDiskSpace
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743836)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the recommended physical memory size that should be available in your computer before you install the update. The physical
		/// memory size is specified in megabytes (MB).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following properties of the IUpdate interface return 0 (zero) when the information is not available:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>RecommendedCpuSpeed</description>
		/// </item>
		/// <item>
		/// <description>RecommendedHardDiskSpace</description>
		/// </item>
		/// <item>
		/// <description><c>RecommendedMemory</c></description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_recommendedmemory HRESULT get_RecommendedMemory(
		// LONG *retval );
		[DispId(1610743837)]
		new int RecommendedMemory
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743837)]
			get;
		}

		/// <summary>
		/// <para>Gets the localized release notes for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_releasenotes HRESULT get_ReleaseNotes( BSTR *retval );
		[DispId(1610743838)]
		new string? ReleaseNotes
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743838)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of string values that contain the security bulletin IDs that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_securitybulletinids HRESULT
		// get_SecurityBulletinIDs( IStringCollection **retval );
		[DispId(1610743839)]
		new IStringCollection SecurityBulletinIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743839)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a collection of update identifiers. This collection of identifiers specifies the updates that are superseded by the update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_supersededupdateids HRESULT
		// get_SupersededUpdateIDs( IStringCollection **retval );
		[DispId(1610743841)]
		new IStringCollection SupersededUpdateIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743841)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a hyperlink to the language-specific support information for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_supporturl HRESULT get_SupportUrl( BSTR *retval );
		[DispId(1610743842)]
		new string? SupportUrl
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743842)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the type of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_type HRESULT get_Type( UpdateType *retval );
		[ComAliasName("WUApiLib.UpdateType"), DispId(1610743843)]
		new UpdateType Type
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743843)]
			[return: ComAliasName("WUApiLib.UpdateType")]
			get;
		}

		/// <summary>
		/// <para>Gets the uninstallation notes for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_uninstallationnotes HRESULT
		// get_UninstallationNotes( BSTR *retval );
		[DispId(1610743844)]
		new string? UninstallationNotes
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743844)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the uninstallation options for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>This API can return a null pointer as the output, even when the return value is S_OK.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_uninstallationbehavior HRESULT
		// get_UninstallationBehavior( IInstallationBehavior **retval );
		[DispId(1610743845)]
		new IInstallationBehavior? UninstallationBehavior
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743845)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the uninstallation steps for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_uninstallationsteps HRESULT
		// get_UninstallationSteps( IStringCollection **retval );
		[DispId(1610743846)]
		new IStringCollection UninstallationSteps
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743846)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of Microsoft Knowledge Base article IDs that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_kbarticleids HRESULT get_KBArticleIDs(
		// IStringCollection **retval );
		[DispId(1610743848)]
		new IStringCollection KBArticleIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743848)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// Accepts the Microsoft Software License Terms that are associated with Windows Update. Administrators and power users can call
		/// this method.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-accepteula HRESULT AcceptEula();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743847)]
		new void AcceptEula();

		/// <summary>
		/// <para>Gets the action for which the update is deployed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deploymentaction HRESULT get_DeploymentAction(
		// DeploymentAction *retval );
		[ComAliasName("WUApiLib.DeploymentAction"), DispId(1610743849)]
		new DeploymentAction DeploymentAction
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743849)]
			[return: ComAliasName("WUApiLib.DeploymentAction")]
			get;
		}

		/// <summary>Copies the contents of an update to a specified path.</summary>
		/// <param name="path">The path of the location where the update contents are to be copied.</param>
		/// <param name="toExtractCabFiles">
		/// <para>Reserved for future use.</para>
		/// <para>You must set <c>toExtractCabFiles</c> to <c>VARIANT_TRUE</c> or <c>VARIANT_FALSE</c>.</para>
		/// </param>
		/// <remarks>
		/// <para>To copy bundled updates, call this method on the individual updates that are bundled in this update.</para>
		/// <para>
		/// <c>Note</c>  We don't recommend or support the use of the <c>IUpdate::CopyFromCache</c> and IUpdate2::CopyToCache methods to move
		/// downloaded updates from one computer to another computer. When the Windows Update Agent (WUA) downloads an update, it might only
		/// download the portions of the update’s payload that are necessary for a particular client computer. The necessary portions of the
		/// update’s payload can often vary from one computer to another computer, even if the computers have similar hardware and software
		/// configurations. <c>IUpdate2::CopyToCache</c> only works if the provided files are an exact match for the files that Windows
		/// Update would have normally downloaded on that computer; if you called <c>IUpdate::CopyFromCache</c> to obtain the files on a
		/// different computer, the files are likely not to match the files that Windows Update would have normally downloaded so
		/// <c>IUpdate2::CopyToCache</c> might fail.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-copyfromcache HRESULT CopyFromCache( [in] BSTR path,
		// [in] VARIANT_BOOL toExtractCabFiles );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743850)]
		new void CopyFromCache([In, MarshalAs(UnmanagedType.BStr)] string path, [In] bool toExtractCabFiles);

		/// <summary>
		/// <para>Gets the suggested download priority of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_downloadpriority HRESULT get_DownloadPriority(
		// DownloadPriority *retval );
		[DispId(1610743851), ComAliasName("WUApiLib.DownloadPriority")]
		new DownloadPriority DownloadPriority
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743851)]
			[return: ComAliasName("WUApiLib.DownloadPriority")]
			get;
		}

		/// <summary>
		/// <para>Gets file information about the download contents of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_downloadcontents HRESULT get_DownloadContents(
		// IUpdateDownloadContentCollection **retval );
		[DispId(1610743852)]
		new IUpdateDownloadContentCollection DownloadContents
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743852)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the class of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driverclass HRESULT get_DriverClass(
		// BSTR *retval );
		[DispId(1610809345)]
		new string? DriverClass
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the hardware ID or compatible ID that the Windows driver update must match to be installable.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driverhardwareid HRESULT
		// get_DriverHardwareID( BSTR *retval );
		[DispId(1610809346)]
		new string? DriverHardwareID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809346)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant name of the manufacturer of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_drivermanufacturer HRESULT
		// get_DriverManufacturer( BSTR *retval );
		[DispId(1610809347)]
		new string? DriverManufacturer
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809347)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant model name of the device for which the Windows driver update is intended.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_drivermodel HRESULT get_DriverModel(
		// BSTR *retval );
		[DispId(1610809348)]
		new string? DriverModel
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809348)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant name of the provider of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driverprovider HRESULT
		// get_DriverProvider( BSTR *retval );
		[DispId(1610809349)]
		new string? DriverProvider
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809349)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the driver version date of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driververdate HRESULT
		// get_DriverVerDate( DATE *retval );
		[DispId(1610809350)]
		new DateTime DriverVerDate
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809350)]
			get;
		}

		/// <summary>
		/// <para>Gets the problem number of the matching device for the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_deviceproblemnumber HRESULT
		// get_DeviceProblemNumber( LONG *retval );
		[DispId(1610809351)]
		new int DeviceProblemNumber
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809351)]
			get;
		}

		/// <summary>
		/// <para>Gets the status of the matching device for the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_devicestatus HRESULT get_DeviceStatus(
		// LONG *retval );
		[DispId(1610809352)]
		new int DeviceStatus
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809352)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the computer must be restarted after you install or uninstall an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-get_rebootrequired
		// HRESULT get_RebootRequired( VARIANT_BOOL *retval );
		[DispId(1610874881)]
		new bool RebootRequired
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874881)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update is installed on a computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-get_ispresent
		// HRESULT get_IsPresent( VARIANT_BOOL *retval );
		[DispId(1610874883)]
		new bool IsPresent
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874883)]
			get;
		}

		/// <summary>
		/// <para>Contains a collection of the Common Vulnerabilities and Exposures (CVE) identifiers that are associated with an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-get_cveids
		// HRESULT get_CveIDs( IStringCollection **retval );
		[DispId(1610874884)]
		new IStringCollection CveIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874884)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>Copies the external update binaries to an update.</summary>
		/// <param name="pFiles">An IStringCollection interface that contains the strings to be copied to an update.</param>
		/// <remarks>This method returns <c>WU_E_INVALID_OPERATION</c> if the object that is implementing the interface has been locked down.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-copytocache
		// HRESULT CopyToCache( [in] IStringCollection *pFiles );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874882)]
		new void CopyToCache([In, MarshalAs(UnmanagedType.Interface)] IStringCollection pFiles);

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update can be discovered only by browsing through the available updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate3-get_browseonly
		// HRESULT get_BrowseOnly( VARIANT_BOOL *retval );
		[DispId(1610940417)]
		bool BrowseOnly
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610940417)]
			get;
		}
	}

	/// <summary>Contains the properties and methods that are available only from a Windows driver update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iwindowsdriverupdate4
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IWindowsDriverUpdate4")]
	[ComImport, DefaultMember("Title"), Guid("004C6A2B-0C19-4C69-9F5C-A269B2560DB9")]
	public interface IWindowsDriverUpdate4 : IWindowsDriverUpdate3
	{
		/// <summary>
		/// <para>Gets the localized title of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_title HRESULT get_Title( BSTR *retval );
		[DispId(0)]
		new string Title
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update is flagged to be automatically selected by Windows Update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_autoselectonwebsites HRESULT
		// get_AutoSelectOnWebSites( VARIANT_BOOL *retval );
		[DispId(1610743809)]
		new bool AutoSelectOnWebSites
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains information about the ordered list of the bundled updates for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_bundledupdates HRESULT get_BundledUpdates(
		// IUpdateCollection **retval );
		[DispId(1610743810)]
		new IUpdateCollection BundledUpdates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the source media of the update is required for installation or uninstallation.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_canrequiresource HRESULT get_CanRequireSource(
		// VARIANT_BOOL *retval );
		[DispId(1610743811)]
		new bool CanRequireSource
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains a collection of categories to which the update belongs.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property of the IUpdateSession2 interface of the session
		/// that was used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that this property returns is for the default user
		/// interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the
		/// default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// <para>
		/// Because there is a <c>Categories</c> property of IUpdate and a Categories property of IUpdateHistoryEntry2, the information that
		/// is used by the localized properties of the ICategory interface depend on the WUA object that owns the <c>ICategory</c> interface.
		/// If the <c>ICategory</c> interface is returned from the <c>Categories</c> property of <c>IUpdate</c>, it follows the localization
		/// rules of <c>IUpdate</c>. If the <c>ICategory</c> interface is returned from the <c>Categories</c> property of
		/// <c>IUpdateHistoryEntry2</c>, it follows the localization rules of <c>IUpdateHistoryEntry2</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_categories HRESULT get_Categories(
		// ICategoryCollection **retval );
		[DispId(1610743812)]
		new ICategoryCollection Categories
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the date by which the update must be installed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// In COM, if the update has a deadline, the return value is of type VT_DATE and contains a DATE value that specifies the deadline.
		/// Otherwise, the return value is of type VT_EMPTY.
		/// </para>
		/// <para>In the Microsoft .NET Framework, the return value is <c>NULL</c> if the update has no deadline.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deadline HRESULT get_Deadline( VARIANT *retval );
		[DispId(1610743813)]
		new object? Deadline
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether delta-compressed content is available on a server for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deltacompressedcontentavailable HRESULT
		// get_DeltaCompressedContentAvailable( VARIANT_BOOL *retval );
		[DispId(1610743814)]
		new bool DeltaCompressedContentAvailable
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether to prefer delta-compressed content during the download and install or uninstall of
		/// the update if delta-compressed content is available.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deltacompressedcontentpreferred HRESULT
		// get_DeltaCompressedContentPreferred( VARIANT_BOOL *retval );
		[DispId(1610743815)]
		new bool DeltaCompressedContentPreferred
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			get;
		}

		/// <summary>
		/// <para>Gets the localized description of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_description HRESULT get_Description( BSTR *retval );
		[DispId(1610743816)]
		new string? Description
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether the Microsoft Software License Terms that are associated with the update are accepted
		/// for the computer.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_eulaaccepted HRESULT get_EulaAccepted( VARIANT_BOOL
		// *retval );
		[DispId(1610743817)]
		new bool EulaAccepted
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743817)]
			get;
		}

		/// <summary>
		/// <para>Gets the full localized text of the Microsoft Software License Terms that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_eulatext HRESULT get_EulaText( BSTR *retval );
		[DispId(1610743818)]
		new string? EulaText
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the install handler of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The valid values for the <c>HandlerID</c> property include the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The Command Line Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/CommandLineInstallation</description>
		/// </item>
		/// <item>
		/// <description>The Inf Based Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/InfBasedInstallation</description>
		/// </item>
		/// <item>
		/// <description>The Windows Installer Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/WindowsInstaller</description>
		/// </item>
		/// <item>
		/// <description>
		/// The Package Installer for Microsoft Windows Operating Systems and Windows Components (update.exe) Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/WindowsPatch
		/// </description>
		/// </item>
		/// <item>
		/// <description>The Component Based Servicing (CBS) Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/Cbs</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_handlerid HRESULT get_HandlerID( BSTR *retval );
		[DispId(1610743819)]
		new string HandlerID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743819)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the unique identifier of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_identity HRESULT get_Identity( IUpdateIdentity
		// **retval );
		[DispId(1610743820)]
		new IUpdateIdentity Identity
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains information about an image that is associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// <para>This API can return a null pointer as the output, even when the return value is S_OK.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_image HRESULT get_Image( IImageInformation **retval );
		[DispId(1610743821)]
		new IImageInformation? Image
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743821)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the installation options of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// If the current update represents a bundle, the <c>InstallationBehavior</c> property of the bundle will be determined by the
		/// <c>InstallationBehavior</c> property of the child updates of the bundle. This API can return a null pointer as the output, even
		/// when the return value is S_OK.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_installationbehavior HRESULT
		// get_InstallationBehavior( IInstallationBehavior **retval );
		[DispId(1610743822)]
		new IInstallationBehavior InstallationBehavior
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update is a beta release.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isbeta HRESULT get_IsBeta( VARIANT_BOOL *retval );
		[DispId(1610743823)]
		new bool IsBeta
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743823)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether all the update content is cached on the computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isdownloaded HRESULT get_IsDownloaded( VARIANT_BOOL
		// *retval );
		[DispId(1610743824)]
		new bool IsDownloaded
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743824)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether an update is hidden by a user. Administrators, users, and power users can retrieve
		/// the value of this property. However, only administrators and members of the Power Users administrative group can set the value of
		/// this property.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>An attempt to mark a mandatory update as hidden causes an error.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-put_ishidden HRESULT put_IsHidden( VARIANT_BOOL value );
		[DispId(1610743825)]
		new bool IsHidden
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743825)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743825)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update is installed on a computer when the search is performed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isinstalled HRESULT get_IsInstalled( VARIANT_BOOL
		// *retval );
		[DispId(1610743826)]
		new bool IsInstalled
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743826)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the installation of the update is mandatory.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>If you try to mark a mandatory update as hidden, an error occurs.</para>
		/// <para>
		/// Mandatory updates are updates to the Windows Update Agent (WUA) infrastructure. WUA may not require all mandatory updates to
		/// continue operating. However, these updates frequently improve performance or increase the number of products that WUA can offer.
		/// We recommend that you install all mandatory updates.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_ismandatory HRESULT get_IsMandatory( VARIANT_BOOL
		// *retval );
		[DispId(1610743827)]
		new bool IsMandatory
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743827)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether a user can uninstall the update from a computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isuninstallable HRESULT get_IsUninstallable(
		// VARIANT_BOOL *retval );
		[DispId(1610743828)]
		new bool IsUninstallable
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743828)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the languages that are supported by the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property refers to the language of the update itself. The language that is used for the title and description of the update
		/// is not necessarily the language of the update itself.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_languages HRESULT get_Languages( IStringCollection
		// **retval );
		[DispId(1610743829)]
		new IStringCollection Languages
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743829)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the last published date of the update, in Coordinated Universal Time (UTC) date and time, on the server that deploys the update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// On computers that are running Windows XP, the <c>LastDeploymentChangeTime</c> property retrieves the same date and time that are
		/// retrieved by the CreationDate property of the <c>IUpdateApproval</c> interface. The CreationDate property is used on computers
		/// that are running Windows Server 2003.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_lastdeploymentchangetime HRESULT
		// get_LastDeploymentChangeTime( DATE *retval );
		[DispId(1610743830)]
		new DateTime LastDeploymentChangeTime
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743830)]
			get;
		}

		/// <summary>
		/// <para>Gets the maximum download size of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The MinDownloadSize property of an update is always downloaded. However, the <c>MaxDownloadSize</c> property is not always
		/// downloaded. The <c>MaxDownloadSize</c> property is downloaded based on the configuration of the computer that receives the update.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_maxdownloadsize HRESULT get_MaxDownloadSize(
		// DECIMAL *retval );
		[DispId(1610743831)]
		new decimal MaxDownloadSize
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743831)]
			get;
		}

		/// <summary>
		/// <para>Gets the minimum download size of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The <c>MinDownloadSize</c> property of an update is always downloaded. However, the MaxDownloadSize property is not always
		/// downloaded. The <c>MaxDownloadSize</c> property is downloaded based on the configuration of the computer that receives the update.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_mindownloadsize HRESULT get_MinDownloadSize(
		// DECIMAL *retval );
		[DispId(1610743832)]
		new decimal MinDownloadSize
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743832)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of language-specific strings that specify the hyperlinks to more information about the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_moreinfourls HRESULT get_MoreInfoUrls(
		// IStringCollection **retval );
		[DispId(1610743833)]
		new IStringCollection MoreInfoUrls
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743833)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the Microsoft Security Response Center severity rating of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The following ratings are the possible severity ratings of a security issue that is fixed by an update. These ratings were
		/// revised by the Microsoft Security Response Center in November 2002.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Term</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>Critical</description>
		/// <description>A security issue whose exploitation could allow the propagation of an Internet worm without user action.</description>
		/// </item>
		/// <item>
		/// <description>Important</description>
		/// <description>
		/// A security issue whose exploitation could result in compromise of the confidentiality, integrity, or availability of users' data,
		/// or of the integrity or availability of processing resources.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Moderate</description>
		/// <description>
		/// Exploitation is mitigated to a significant degree by factors such as default configuration, auditing, or difficulty of exploitation.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Low</description>
		/// <description>A security issue whose exploitation is extremely difficult, or whose impact is minimal.</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_msrcseverity HRESULT get_MsrcSeverity( BSTR *retval );
		[DispId(1610743834)]
		new string? MsrcSeverity
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743834)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the recommended CPU speed used to install the update, in megahertz (MHz).</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following properties of the IUpdate interface return 0 (zero) when the information is not available:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>RecommendedCpuSpeed</c></description>
		/// </item>
		/// <item>
		/// <description>RecommendedHardDiskSpace</description>
		/// </item>
		/// <item>
		/// <description>RecommendedMemory</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_recommendedcpuspeed HRESULT
		// get_RecommendedCpuSpeed( LONG *retval );
		[DispId(1610743835)]
		new int RecommendedCpuSpeed
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743835)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the recommended free space that should be available on the hard disk before you install the update. The free space is
		/// specified in megabytes (MB).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following properties of the IUpdate interface return 0 (zero) when the information is not available:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>RecommendedCpuSpeed</description>
		/// </item>
		/// <item>
		/// <description><c>RecommendedHardDiskSpace</c></description>
		/// </item>
		/// <item>
		/// <description>RecommendedMemory</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_recommendedharddiskspace HRESULT
		// get_RecommendedHardDiskSpace( LONG *retval );
		[DispId(1610743836)]
		new int RecommendedHardDiskSpace
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743836)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the recommended physical memory size that should be available in your computer before you install the update. The physical
		/// memory size is specified in megabytes (MB).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following properties of the IUpdate interface return 0 (zero) when the information is not available:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>RecommendedCpuSpeed</description>
		/// </item>
		/// <item>
		/// <description>RecommendedHardDiskSpace</description>
		/// </item>
		/// <item>
		/// <description><c>RecommendedMemory</c></description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_recommendedmemory HRESULT get_RecommendedMemory(
		// LONG *retval );
		[DispId(1610743837)]
		new int RecommendedMemory
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743837)]
			get;
		}

		/// <summary>
		/// <para>Gets the localized release notes for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_releasenotes HRESULT get_ReleaseNotes( BSTR *retval );
		[DispId(1610743838)]
		new string? ReleaseNotes
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743838)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of string values that contain the security bulletin IDs that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_securitybulletinids HRESULT
		// get_SecurityBulletinIDs( IStringCollection **retval );
		[DispId(1610743839)]
		new IStringCollection SecurityBulletinIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743839)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a collection of update identifiers. This collection of identifiers specifies the updates that are superseded by the update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_supersededupdateids HRESULT
		// get_SupersededUpdateIDs( IStringCollection **retval );
		[DispId(1610743841)]
		new IStringCollection SupersededUpdateIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743841)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a hyperlink to the language-specific support information for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_supporturl HRESULT get_SupportUrl( BSTR *retval );
		[DispId(1610743842)]
		new string? SupportUrl
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743842)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the type of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_type HRESULT get_Type( UpdateType *retval );
		[ComAliasName("WUApiLib.UpdateType"), DispId(1610743843)]
		new UpdateType Type
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743843)]
			[return: ComAliasName("WUApiLib.UpdateType")]
			get;
		}

		/// <summary>
		/// <para>Gets the uninstallation notes for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_uninstallationnotes HRESULT
		// get_UninstallationNotes( BSTR *retval );
		[DispId(1610743844)]
		new string? UninstallationNotes
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743844)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the uninstallation options for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>This API can return a null pointer as the output, even when the return value is S_OK.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_uninstallationbehavior HRESULT
		// get_UninstallationBehavior( IInstallationBehavior **retval );
		[DispId(1610743845)]
		new IInstallationBehavior? UninstallationBehavior
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743845)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the uninstallation steps for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_uninstallationsteps HRESULT
		// get_UninstallationSteps( IStringCollection **retval );
		[DispId(1610743846)]
		new IStringCollection UninstallationSteps
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743846)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of Microsoft Knowledge Base article IDs that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_kbarticleids HRESULT get_KBArticleIDs(
		// IStringCollection **retval );
		[DispId(1610743848)]
		new IStringCollection KBArticleIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743848)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// Accepts the Microsoft Software License Terms that are associated with Windows Update. Administrators and power users can call
		/// this method.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-accepteula HRESULT AcceptEula();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743847)]
		new void AcceptEula();

		/// <summary>
		/// <para>Gets the action for which the update is deployed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deploymentaction HRESULT get_DeploymentAction(
		// DeploymentAction *retval );
		[ComAliasName("WUApiLib.DeploymentAction"), DispId(1610743849)]
		new DeploymentAction DeploymentAction
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743849)]
			[return: ComAliasName("WUApiLib.DeploymentAction")]
			get;
		}

		/// <summary>Copies the contents of an update to a specified path.</summary>
		/// <param name="path">The path of the location where the update contents are to be copied.</param>
		/// <param name="toExtractCabFiles">
		/// <para>Reserved for future use.</para>
		/// <para>You must set <c>toExtractCabFiles</c> to <c>VARIANT_TRUE</c> or <c>VARIANT_FALSE</c>.</para>
		/// </param>
		/// <remarks>
		/// <para>To copy bundled updates, call this method on the individual updates that are bundled in this update.</para>
		/// <para>
		/// <c>Note</c>  We don't recommend or support the use of the <c>IUpdate::CopyFromCache</c> and IUpdate2::CopyToCache methods to move
		/// downloaded updates from one computer to another computer. When the Windows Update Agent (WUA) downloads an update, it might only
		/// download the portions of the update’s payload that are necessary for a particular client computer. The necessary portions of the
		/// update’s payload can often vary from one computer to another computer, even if the computers have similar hardware and software
		/// configurations. <c>IUpdate2::CopyToCache</c> only works if the provided files are an exact match for the files that Windows
		/// Update would have normally downloaded on that computer; if you called <c>IUpdate::CopyFromCache</c> to obtain the files on a
		/// different computer, the files are likely not to match the files that Windows Update would have normally downloaded so
		/// <c>IUpdate2::CopyToCache</c> might fail.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-copyfromcache HRESULT CopyFromCache( [in] BSTR path,
		// [in] VARIANT_BOOL toExtractCabFiles );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743850)]
		new void CopyFromCache([In, MarshalAs(UnmanagedType.BStr)] string path, [In] bool toExtractCabFiles);

		/// <summary>
		/// <para>Gets the suggested download priority of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_downloadpriority HRESULT get_DownloadPriority(
		// DownloadPriority *retval );
		[DispId(1610743851), ComAliasName("WUApiLib.DownloadPriority")]
		new DownloadPriority DownloadPriority
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743851)]
			[return: ComAliasName("WUApiLib.DownloadPriority")]
			get;
		}

		/// <summary>
		/// <para>Gets file information about the download contents of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_downloadcontents HRESULT get_DownloadContents(
		// IUpdateDownloadContentCollection **retval );
		[DispId(1610743852)]
		new IUpdateDownloadContentCollection DownloadContents
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743852)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the class of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driverclass HRESULT get_DriverClass(
		// BSTR *retval );
		[DispId(1610809345)]
		new string? DriverClass
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the hardware ID or compatible ID that the Windows driver update must match to be installable.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driverhardwareid HRESULT
		// get_DriverHardwareID( BSTR *retval );
		[DispId(1610809346)]
		new string? DriverHardwareID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809346)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant name of the manufacturer of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_drivermanufacturer HRESULT
		// get_DriverManufacturer( BSTR *retval );
		[DispId(1610809347)]
		new string? DriverManufacturer
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809347)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant model name of the device for which the Windows driver update is intended.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_drivermodel HRESULT get_DriverModel(
		// BSTR *retval );
		[DispId(1610809348)]
		new string? DriverModel
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809348)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant name of the provider of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driverprovider HRESULT
		// get_DriverProvider( BSTR *retval );
		[DispId(1610809349)]
		new string? DriverProvider
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809349)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the driver version date of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driververdate HRESULT
		// get_DriverVerDate( DATE *retval );
		[DispId(1610809350)]
		new DateTime DriverVerDate
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809350)]
			get;
		}

		/// <summary>
		/// <para>Gets the problem number of the matching device for the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_deviceproblemnumber HRESULT
		// get_DeviceProblemNumber( LONG *retval );
		[DispId(1610809351)]
		new int DeviceProblemNumber
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809351)]
			get;
		}

		/// <summary>
		/// <para>Gets the status of the matching device for the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_devicestatus HRESULT get_DeviceStatus(
		// LONG *retval );
		[DispId(1610809352)]
		new int DeviceStatus
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809352)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the computer must be restarted after you install or uninstall an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-get_rebootrequired
		// HRESULT get_RebootRequired( VARIANT_BOOL *retval );
		[DispId(1610874881)]
		new bool RebootRequired
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874881)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update is installed on a computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-get_ispresent
		// HRESULT get_IsPresent( VARIANT_BOOL *retval );
		[DispId(1610874883)]
		new bool IsPresent
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874883)]
			get;
		}

		/// <summary>
		/// <para>Contains a collection of the Common Vulnerabilities and Exposures (CVE) identifiers that are associated with an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-get_cveids
		// HRESULT get_CveIDs( IStringCollection **retval );
		[DispId(1610874884)]
		new IStringCollection CveIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874884)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>Copies the external update binaries to an update.</summary>
		/// <param name="pFiles">An IStringCollection interface that contains the strings to be copied to an update.</param>
		/// <remarks>This method returns <c>WU_E_INVALID_OPERATION</c> if the object that is implementing the interface has been locked down.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-copytocache
		// HRESULT CopyToCache( [in] IStringCollection *pFiles );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874882)]
		new void CopyToCache([In, MarshalAs(UnmanagedType.Interface)] IStringCollection pFiles);

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update can be discovered only by browsing through the available updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate3-get_browseonly
		// HRESULT get_BrowseOnly( VARIANT_BOOL *retval );
		[DispId(1610940417)]
		new bool BrowseOnly
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610940417)]
			get;
		}

		/// <summary>
		/// <para>Gets the driver update entries that are applicable for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate4-get_windowsdriverupdateentries
		// HRESULT get_WindowsDriverUpdateEntries( IWindowsDriverUpdateEntryCollection **retval );
		[DispId(1611005953)]
		IWindowsDriverUpdateEntryCollection WindowsDriverUpdateEntries
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1611005953)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update is a per-user update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate4-get_peruser
		// HRESULT get_PerUser( VARIANT_BOOL *retval );
		[DispId(1611005954)]
		bool PerUser
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1611005954)]
			get;
		}
	}

	/// <summary>Contains the properties and methods that are available only from a Windows driver update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iwindowsdriverupdate5
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IWindowsDriverUpdate5")]
	[ComImport, DefaultMember("Title"), Guid("70CF5C82-8642-42BB-9DBC-0CFD263C6C4F")]
	public interface IWindowsDriverUpdate5 : IWindowsDriverUpdate4
	{
		/// <summary>
		/// <para>Gets the localized title of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_title HRESULT get_Title( BSTR *retval );
		[DispId(0)]
		new string Title
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update is flagged to be automatically selected by Windows Update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_autoselectonwebsites HRESULT
		// get_AutoSelectOnWebSites( VARIANT_BOOL *retval );
		[DispId(1610743809)]
		new bool AutoSelectOnWebSites
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743809)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains information about the ordered list of the bundled updates for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_bundledupdates HRESULT get_BundledUpdates(
		// IUpdateCollection **retval );
		[DispId(1610743810)]
		new IUpdateCollection BundledUpdates
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743810)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the source media of the update is required for installation or uninstallation.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_canrequiresource HRESULT get_CanRequireSource(
		// VARIANT_BOOL *retval );
		[DispId(1610743811)]
		new bool CanRequireSource
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743811)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains a collection of categories to which the update belongs.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property of the IUpdateSession2 interface of the session
		/// that was used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that this property returns is for the default user
		/// interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the
		/// default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// <para>
		/// Because there is a <c>Categories</c> property of IUpdate and a Categories property of IUpdateHistoryEntry2, the information that
		/// is used by the localized properties of the ICategory interface depend on the WUA object that owns the <c>ICategory</c> interface.
		/// If the <c>ICategory</c> interface is returned from the <c>Categories</c> property of <c>IUpdate</c>, it follows the localization
		/// rules of <c>IUpdate</c>. If the <c>ICategory</c> interface is returned from the <c>Categories</c> property of
		/// <c>IUpdateHistoryEntry2</c>, it follows the localization rules of <c>IUpdateHistoryEntry2</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_categories HRESULT get_Categories(
		// ICategoryCollection **retval );
		[DispId(1610743812)]
		new ICategoryCollection Categories
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the date by which the update must be installed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// In COM, if the update has a deadline, the return value is of type VT_DATE and contains a DATE value that specifies the deadline.
		/// Otherwise, the return value is of type VT_EMPTY.
		/// </para>
		/// <para>In the Microsoft .NET Framework, the return value is <c>NULL</c> if the update has no deadline.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deadline HRESULT get_Deadline( VARIANT *retval );
		[DispId(1610743813)]
		new object? Deadline
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743813)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether delta-compressed content is available on a server for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deltacompressedcontentavailable HRESULT
		// get_DeltaCompressedContentAvailable( VARIANT_BOOL *retval );
		[DispId(1610743814)]
		new bool DeltaCompressedContentAvailable
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743814)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether to prefer delta-compressed content during the download and install or uninstall of
		/// the update if delta-compressed content is available.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deltacompressedcontentpreferred HRESULT
		// get_DeltaCompressedContentPreferred( VARIANT_BOOL *retval );
		[DispId(1610743815)]
		new bool DeltaCompressedContentPreferred
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743815)]
			get;
		}

		/// <summary>
		/// <para>Gets the localized description of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_description HRESULT get_Description( BSTR *retval );
		[DispId(1610743816)]
		new string? Description
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743816)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether the Microsoft Software License Terms that are associated with the update are accepted
		/// for the computer.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_eulaaccepted HRESULT get_EulaAccepted( VARIANT_BOOL
		// *retval );
		[DispId(1610743817)]
		new bool EulaAccepted
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743817)]
			get;
		}

		/// <summary>
		/// <para>Gets the full localized text of the Microsoft Software License Terms that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_eulatext HRESULT get_EulaText( BSTR *retval );
		[DispId(1610743818)]
		new string? EulaText
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743818)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the install handler of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The valid values for the <c>HandlerID</c> property include the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The Command Line Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/CommandLineInstallation</description>
		/// </item>
		/// <item>
		/// <description>The Inf Based Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/InfBasedInstallation</description>
		/// </item>
		/// <item>
		/// <description>The Windows Installer Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/WindowsInstaller</description>
		/// </item>
		/// <item>
		/// <description>
		/// The Package Installer for Microsoft Windows Operating Systems and Windows Components (update.exe) Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/WindowsPatch
		/// </description>
		/// </item>
		/// <item>
		/// <description>The Component Based Servicing (CBS) Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/Cbs</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_handlerid HRESULT get_HandlerID( BSTR *retval );
		[DispId(1610743819)]
		new string HandlerID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743819)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the unique identifier of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_identity HRESULT get_Identity( IUpdateIdentity
		// **retval );
		[DispId(1610743820)]
		new IUpdateIdentity Identity
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743820)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains information about an image that is associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// <para>This API can return a null pointer as the output, even when the return value is S_OK.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_image HRESULT get_Image( IImageInformation **retval );
		[DispId(1610743821)]
		new IImageInformation? Image
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743821)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the installation options of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// If the current update represents a bundle, the <c>InstallationBehavior</c> property of the bundle will be determined by the
		/// <c>InstallationBehavior</c> property of the child updates of the bundle. This API can return a null pointer as the output, even
		/// when the return value is S_OK.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_installationbehavior HRESULT
		// get_InstallationBehavior( IInstallationBehavior **retval );
		[DispId(1610743822)]
		new IInstallationBehavior InstallationBehavior
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743822)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update is a beta release.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isbeta HRESULT get_IsBeta( VARIANT_BOOL *retval );
		[DispId(1610743823)]
		new bool IsBeta
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743823)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether all the update content is cached on the computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isdownloaded HRESULT get_IsDownloaded( VARIANT_BOOL
		// *retval );
		[DispId(1610743824)]
		new bool IsDownloaded
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743824)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a Boolean value that indicates whether an update is hidden by a user. Administrators, users, and power users can retrieve
		/// the value of this property. However, only administrators and members of the Power Users administrative group can set the value of
		/// this property.
		/// </para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <remarks>An attempt to mark a mandatory update as hidden causes an error.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-put_ishidden HRESULT put_IsHidden( VARIANT_BOOL value );
		[DispId(1610743825)]
		new bool IsHidden
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743825)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743825)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update is installed on a computer when the search is performed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isinstalled HRESULT get_IsInstalled( VARIANT_BOOL
		// *retval );
		[DispId(1610743826)]
		new bool IsInstalled
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743826)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the installation of the update is mandatory.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>If you try to mark a mandatory update as hidden, an error occurs.</para>
		/// <para>
		/// Mandatory updates are updates to the Windows Update Agent (WUA) infrastructure. WUA may not require all mandatory updates to
		/// continue operating. However, these updates frequently improve performance or increase the number of products that WUA can offer.
		/// We recommend that you install all mandatory updates.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_ismandatory HRESULT get_IsMandatory( VARIANT_BOOL
		// *retval );
		[DispId(1610743827)]
		new bool IsMandatory
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743827)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether a user can uninstall the update from a computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_isuninstallable HRESULT get_IsUninstallable(
		// VARIANT_BOOL *retval );
		[DispId(1610743828)]
		new bool IsUninstallable
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743828)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the languages that are supported by the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// This property refers to the language of the update itself. The language that is used for the title and description of the update
		/// is not necessarily the language of the update itself.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_languages HRESULT get_Languages( IStringCollection
		// **retval );
		[DispId(1610743829)]
		new IStringCollection Languages
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743829)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the last published date of the update, in Coordinated Universal Time (UTC) date and time, on the server that deploys the update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// On computers that are running Windows XP, the <c>LastDeploymentChangeTime</c> property retrieves the same date and time that are
		/// retrieved by the CreationDate property of the <c>IUpdateApproval</c> interface. The CreationDate property is used on computers
		/// that are running Windows Server 2003.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_lastdeploymentchangetime HRESULT
		// get_LastDeploymentChangeTime( DATE *retval );
		[DispId(1610743830)]
		new DateTime LastDeploymentChangeTime
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743830)]
			get;
		}

		/// <summary>
		/// <para>Gets the maximum download size of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The MinDownloadSize property of an update is always downloaded. However, the <c>MaxDownloadSize</c> property is not always
		/// downloaded. The <c>MaxDownloadSize</c> property is downloaded based on the configuration of the computer that receives the update.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_maxdownloadsize HRESULT get_MaxDownloadSize(
		// DECIMAL *retval );
		[DispId(1610743831)]
		new decimal MaxDownloadSize
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743831)]
			get;
		}

		/// <summary>
		/// <para>Gets the minimum download size of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The <c>MinDownloadSize</c> property of an update is always downloaded. However, the MaxDownloadSize property is not always
		/// downloaded. The <c>MaxDownloadSize</c> property is downloaded based on the configuration of the computer that receives the update.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_mindownloadsize HRESULT get_MinDownloadSize(
		// DECIMAL *retval );
		[DispId(1610743832)]
		new decimal MinDownloadSize
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743832)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of language-specific strings that specify the hyperlinks to more information about the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_moreinfourls HRESULT get_MoreInfoUrls(
		// IStringCollection **retval );
		[DispId(1610743833)]
		new IStringCollection MoreInfoUrls
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743833)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the Microsoft Security Response Center severity rating of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The following ratings are the possible severity ratings of a security issue that is fixed by an update. These ratings were
		/// revised by the Microsoft Security Response Center in November 2002.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Term</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>Critical</description>
		/// <description>A security issue whose exploitation could allow the propagation of an Internet worm without user action.</description>
		/// </item>
		/// <item>
		/// <description>Important</description>
		/// <description>
		/// A security issue whose exploitation could result in compromise of the confidentiality, integrity, or availability of users' data,
		/// or of the integrity or availability of processing resources.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Moderate</description>
		/// <description>
		/// Exploitation is mitigated to a significant degree by factors such as default configuration, auditing, or difficulty of exploitation.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Low</description>
		/// <description>A security issue whose exploitation is extremely difficult, or whose impact is minimal.</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_msrcseverity HRESULT get_MsrcSeverity( BSTR *retval );
		[DispId(1610743834)]
		new string? MsrcSeverity
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743834)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the recommended CPU speed used to install the update, in megahertz (MHz).</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following properties of the IUpdate interface return 0 (zero) when the information is not available:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>RecommendedCpuSpeed</c></description>
		/// </item>
		/// <item>
		/// <description>RecommendedHardDiskSpace</description>
		/// </item>
		/// <item>
		/// <description>RecommendedMemory</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_recommendedcpuspeed HRESULT
		// get_RecommendedCpuSpeed( LONG *retval );
		[DispId(1610743835)]
		new int RecommendedCpuSpeed
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743835)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the recommended free space that should be available on the hard disk before you install the update. The free space is
		/// specified in megabytes (MB).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following properties of the IUpdate interface return 0 (zero) when the information is not available:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>RecommendedCpuSpeed</description>
		/// </item>
		/// <item>
		/// <description><c>RecommendedHardDiskSpace</c></description>
		/// </item>
		/// <item>
		/// <description>RecommendedMemory</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_recommendedharddiskspace HRESULT
		// get_RecommendedHardDiskSpace( LONG *retval );
		[DispId(1610743836)]
		new int RecommendedHardDiskSpace
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743836)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets the recommended physical memory size that should be available in your computer before you install the update. The physical
		/// memory size is specified in megabytes (MB).
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>The following properties of the IUpdate interface return 0 (zero) when the information is not available:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>RecommendedCpuSpeed</description>
		/// </item>
		/// <item>
		/// <description>RecommendedHardDiskSpace</description>
		/// </item>
		/// <item>
		/// <description><c>RecommendedMemory</c></description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_recommendedmemory HRESULT get_RecommendedMemory(
		// LONG *retval );
		[DispId(1610743837)]
		new int RecommendedMemory
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743837)]
			get;
		}

		/// <summary>
		/// <para>Gets the localized release notes for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_releasenotes HRESULT get_ReleaseNotes( BSTR *retval );
		[DispId(1610743838)]
		new string? ReleaseNotes
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743838)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of string values that contain the security bulletin IDs that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_securitybulletinids HRESULT
		// get_SecurityBulletinIDs( IStringCollection **retval );
		[DispId(1610743839)]
		new IStringCollection SecurityBulletinIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743839)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>
		/// Gets a collection of update identifiers. This collection of identifiers specifies the updates that are superseded by the update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_supersededupdateids HRESULT
		// get_SupersededUpdateIDs( IStringCollection **retval );
		[DispId(1610743841)]
		new IStringCollection SupersededUpdateIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743841)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a hyperlink to the language-specific support information for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_supporturl HRESULT get_SupportUrl( BSTR *retval );
		[DispId(1610743842)]
		new string? SupportUrl
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743842)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the type of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_type HRESULT get_Type( UpdateType *retval );
		[ComAliasName("WUApiLib.UpdateType"), DispId(1610743843)]
		new UpdateType Type
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743843)]
			[return: ComAliasName("WUApiLib.UpdateType")]
			get;
		}

		/// <summary>
		/// <para>Gets the uninstallation notes for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_uninstallationnotes HRESULT
		// get_UninstallationNotes( BSTR *retval );
		[DispId(1610743844)]
		new string? UninstallationNotes
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743844)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the uninstallation options for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>This API can return a null pointer as the output, even when the return value is S_OK.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_uninstallationbehavior HRESULT
		// get_UninstallationBehavior( IInstallationBehavior **retval );
		[DispId(1610743845)]
		new IInstallationBehavior? UninstallationBehavior
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743845)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets an interface that contains the uninstallation steps for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IUpdateSearcher interface is created by using the IUpdateSession::CreateUpdateSearcher method, the information that this
		/// property returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
		/// IUpdateSession2 interface of the session that is used to create <c>IUpdateSearcher</c>.
		/// </para>
		/// <para>
		/// If a language preference is not specified by the UserLocale property of IUpdateSession2, or if the IUpdateSearcher interface is
		/// not created by using IUpdateSession::CreateUpdateSearcher, the information that is returned by this property is for the default
		/// user interface (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses
		/// the default UI language of the computer. If the default language of the computer is unavailable, WUA uses the language that the
		/// provider of the update recommends.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_uninstallationsteps HRESULT
		// get_UninstallationSteps( IStringCollection **retval );
		[DispId(1610743846)]
		new IStringCollection UninstallationSteps
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743846)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of Microsoft Knowledge Base article IDs that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_kbarticleids HRESULT get_KBArticleIDs(
		// IStringCollection **retval );
		[DispId(1610743848)]
		new IStringCollection KBArticleIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743848)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// Accepts the Microsoft Software License Terms that are associated with Windows Update. Administrators and power users can call
		/// this method.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-accepteula HRESULT AcceptEula();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743847)]
		new void AcceptEula();

		/// <summary>
		/// <para>Gets the action for which the update is deployed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deploymentaction HRESULT get_DeploymentAction(
		// DeploymentAction *retval );
		[ComAliasName("WUApiLib.DeploymentAction"), DispId(1610743849)]
		new DeploymentAction DeploymentAction
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743849)]
			[return: ComAliasName("WUApiLib.DeploymentAction")]
			get;
		}

		/// <summary>Copies the contents of an update to a specified path.</summary>
		/// <param name="path">The path of the location where the update contents are to be copied.</param>
		/// <param name="toExtractCabFiles">
		/// <para>Reserved for future use.</para>
		/// <para>You must set <c>toExtractCabFiles</c> to <c>VARIANT_TRUE</c> or <c>VARIANT_FALSE</c>.</para>
		/// </param>
		/// <remarks>
		/// <para>To copy bundled updates, call this method on the individual updates that are bundled in this update.</para>
		/// <para>
		/// <c>Note</c>  We don't recommend or support the use of the <c>IUpdate::CopyFromCache</c> and IUpdate2::CopyToCache methods to move
		/// downloaded updates from one computer to another computer. When the Windows Update Agent (WUA) downloads an update, it might only
		/// download the portions of the update’s payload that are necessary for a particular client computer. The necessary portions of the
		/// update’s payload can often vary from one computer to another computer, even if the computers have similar hardware and software
		/// configurations. <c>IUpdate2::CopyToCache</c> only works if the provided files are an exact match for the files that Windows
		/// Update would have normally downloaded on that computer; if you called <c>IUpdate::CopyFromCache</c> to obtain the files on a
		/// different computer, the files are likely not to match the files that Windows Update would have normally downloaded so
		/// <c>IUpdate2::CopyToCache</c> might fail.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-copyfromcache HRESULT CopyFromCache( [in] BSTR path,
		// [in] VARIANT_BOOL toExtractCabFiles );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743850)]
		new void CopyFromCache([In, MarshalAs(UnmanagedType.BStr)] string path, [In] bool toExtractCabFiles);

		/// <summary>
		/// <para>Gets the suggested download priority of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_downloadpriority HRESULT get_DownloadPriority(
		// DownloadPriority *retval );
		[DispId(1610743851), ComAliasName("WUApiLib.DownloadPriority")]
		new DownloadPriority DownloadPriority
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743851)]
			[return: ComAliasName("WUApiLib.DownloadPriority")]
			get;
		}

		/// <summary>
		/// <para>Gets file information about the download contents of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_downloadcontents HRESULT get_DownloadContents(
		// IUpdateDownloadContentCollection **retval );
		[DispId(1610743852)]
		new IUpdateDownloadContentCollection DownloadContents
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743852)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets the class of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driverclass HRESULT get_DriverClass(
		// BSTR *retval );
		[DispId(1610809345)]
		new string? DriverClass
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the hardware ID or compatible ID that the Windows driver update must match to be installable.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driverhardwareid HRESULT
		// get_DriverHardwareID( BSTR *retval );
		[DispId(1610809346)]
		new string? DriverHardwareID
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809346)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant name of the manufacturer of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_drivermanufacturer HRESULT
		// get_DriverManufacturer( BSTR *retval );
		[DispId(1610809347)]
		new string? DriverManufacturer
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809347)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant model name of the device for which the Windows driver update is intended.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_drivermodel HRESULT get_DriverModel(
		// BSTR *retval );
		[DispId(1610809348)]
		new string? DriverModel
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809348)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the language-invariant name of the provider of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driverprovider HRESULT
		// get_DriverProvider( BSTR *retval );
		[DispId(1610809349)]
		new string? DriverProvider
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809349)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>
		/// <para>Gets the driver version date of the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_driververdate HRESULT
		// get_DriverVerDate( DATE *retval );
		[DispId(1610809350)]
		new DateTime DriverVerDate
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809350)]
			get;
		}

		/// <summary>
		/// <para>Gets the problem number of the matching device for the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_deviceproblemnumber HRESULT
		// get_DeviceProblemNumber( LONG *retval );
		[DispId(1610809351)]
		new int DeviceProblemNumber
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809351)]
			get;
		}

		/// <summary>
		/// <para>Gets the status of the matching device for the Windows driver update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate-get_devicestatus HRESULT get_DeviceStatus(
		// LONG *retval );
		[DispId(1610809352)]
		new int DeviceStatus
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809352)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the computer must be restarted after you install or uninstall an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-get_rebootrequired
		// HRESULT get_RebootRequired( VARIANT_BOOL *retval );
		[DispId(1610874881)]
		new bool RebootRequired
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874881)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update is installed on a computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-get_ispresent
		// HRESULT get_IsPresent( VARIANT_BOOL *retval );
		[DispId(1610874883)]
		new bool IsPresent
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874883)]
			get;
		}

		/// <summary>
		/// <para>Contains a collection of the Common Vulnerabilities and Exposures (CVE) identifiers that are associated with an update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-get_cveids
		// HRESULT get_CveIDs( IStringCollection **retval );
		[DispId(1610874884)]
		new IStringCollection CveIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874884)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>Copies the external update binaries to an update.</summary>
		/// <param name="pFiles">An IStringCollection interface that contains the strings to be copied to an update.</param>
		/// <remarks>This method returns <c>WU_E_INVALID_OPERATION</c> if the object that is implementing the interface has been locked down.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate2-copytocache
		// HRESULT CopyToCache( [in] IStringCollection *pFiles );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874882)]
		new void CopyToCache([In, MarshalAs(UnmanagedType.Interface)] IStringCollection pFiles);

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update can be discovered only by browsing through the available updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate3-get_browseonly
		// HRESULT get_BrowseOnly( VARIANT_BOOL *retval );
		[DispId(1610940417)]
		new bool BrowseOnly
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610940417)]
			get;
		}

		/// <summary>
		/// <para>Gets the driver update entries that are applicable for the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate4-get_windowsdriverupdateentries
		// HRESULT get_WindowsDriverUpdateEntries( IWindowsDriverUpdateEntryCollection **retval );
		[DispId(1611005953)]
		new IWindowsDriverUpdateEntryCollection WindowsDriverUpdateEntries
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1611005953)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update is a per-user update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate4-get_peruser
		// HRESULT get_PerUser( VARIANT_BOOL *retval );
		[DispId(1611005954)]
		new bool PerUser
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1611005954)]
			get;
		}

		/// <summary>
		/// <para>Gets an AutoSelectionMode value indicating the automatic selection mode of an update in the Control Panel of Windows Update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>The AutoSelection property indicates whether the update will be automatically selected when the user views the available updates in the Windows Update user interface.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate5-get_autoselection
		// HRESULT get_AutoSelection( AutoSelectionMode *retval );
		[ComAliasName("WUApiLib.AutoSelectionMode"), DispId(1611071489)]
		AutoSelectionMode AutoSelection
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1611071489)]
			[return: ComAliasName("WUApiLib.AutoSelectionMode")]
			get;
		}

		/// <summary>
		/// <para>Gets an AutoDownloadMode value that indicates the automatic download mode of update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>The AutoDownload property indicates whether the update will be automatically downloaded by Automatic Updates.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iwindowsdriverupdate5-get_autodownload
		// HRESULT get_AutoDownload( AutoDownloadMode *retval );
		[DispId(1611071490), ComAliasName("WUApiLib.AutoDownloadMode")]
		AutoDownloadMode AutoDownload
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1611071490)]
			[return: ComAliasName("WUApiLib.AutoDownloadMode")]
			get;
		}
	}
}