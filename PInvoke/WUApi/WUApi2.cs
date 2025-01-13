namespace Vanara.PInvoke;

/// <summary>PInvoke API (methods, structures and constants) imported from Windows Update API.</summary>
public static partial class WUApi
{
	/// <summary>Contains the properties and methods that are available to an update.</summary>
	/// <remarks>
	/// If the BundledUpdates property contains an IUpdateCollection, some properties and methods of the update may only be available on the
	/// bundled updates, for example, DownloadContents or CopyFromCache.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdate
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdate")]
	[ComImport, Guid("6A92B07A-D821-4682-B423-5C805022CC4D"), DefaultMember("Title")]
	public interface IUpdate
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
		string Title
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
		bool AutoSelectOnWebSites
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
		IUpdateCollection BundledUpdates
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
		bool CanRequireSource
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
		ICategoryCollection Categories
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
		object? Deadline
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
		bool DeltaCompressedContentAvailable
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
		bool DeltaCompressedContentPreferred
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
		string? Description
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
		bool EulaAccepted
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
		string? EulaText
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
		string? HandlerID
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
		IUpdateIdentity Identity
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
		IImageInformation? Image
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
		IInstallationBehavior InstallationBehavior
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
		bool IsBeta
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
		bool IsDownloaded
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
		bool IsHidden
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
		bool IsInstalled
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
		bool IsMandatory
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
		bool IsUninstallable
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
		IStringCollection Languages
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
		DateTime LastDeploymentChangeTime
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
		decimal MaxDownloadSize
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
		decimal MinDownloadSize
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
		IStringCollection MoreInfoUrls
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
		string? MsrcSeverity
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
		int RecommendedCpuSpeed
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
		int RecommendedHardDiskSpace
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
		int RecommendedMemory
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
		string? ReleaseNotes
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
		IStringCollection SecurityBulletinIDs
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
		IStringCollection SupersededUpdateIDs
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
		string? SupportUrl
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
		UpdateType Type
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
		string? UninstallationNotes
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
		IInstallationBehavior? UninstallationBehavior
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
		IStringCollection UninstallationSteps
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
		IStringCollection KBArticleIDs
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
		void AcceptEula();

		/// <summary>
		/// <para>Gets the action for which the update is deployed.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_deploymentaction HRESULT get_DeploymentAction(
		// DeploymentAction *retval );
		[ComAliasName("WUApiLib.DeploymentAction"), DispId(1610743849)]
		DeploymentAction DeploymentAction
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
		void CopyFromCache([In, MarshalAs(UnmanagedType.BStr)] string path, [In] bool toExtractCabFiles);

		/// <summary>
		/// <para>Gets the suggested download priority of the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate-get_downloadpriority HRESULT get_DownloadPriority(
		// DownloadPriority *retval );
		[DispId(1610743851), ComAliasName("WUApiLib.DownloadPriority")]
		DownloadPriority DownloadPriority
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
		IUpdateDownloadContentCollection DownloadContents
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610743852)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	/// <summary>Contains the properties and methods that are available to an update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdate2
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdate2")]
	[ComImport, Guid("144FE9B0-D23D-4A8B-8634-FB4457533B7A"), DefaultMember("Title")]
	public interface IUpdate2 : IUpdate
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
		new string? HandlerID
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
		/// <para>
		/// Gets a Boolean value that indicates whether a system restart is required on a computer to complete the installation or the
		/// uninstallation of an update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-get_rebootrequired HRESULT get_RebootRequired(
		// VARIANT_BOOL *retval );
		[DispId(1610809345)]
		bool RebootRequired
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update is present on a computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// An update is considered present if it is installed for one or more products. For example, if an update applies to both Microsoft
		/// Office Word and to Microsoft Office Excel, the <c>IsPresent</c> property returns <c>VARIANT_TRUE</c> if the update is installed
		/// for one or both of the products.
		/// </para>
		/// <para>
		/// If an update applies to only one product, the <c>IsPresent</c> and IsInstalled properties are equivalent. An update is considered
		/// installed if the update is installed for all the products to which it applies.
		/// </para>
		/// <para>
		/// If <c>IsPresent</c> returns <c>VARIANT_TRUE</c> and IsInstalled returns <c>VARIANT_FALSE</c>, the update can be uninstalled for
		/// the product that installed it.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-get_ispresent HRESULT get_IsPresent( VARIANT_BOOL
		// *retval );
		[DispId(1610809347)]
		bool IsPresent
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809347)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of common vulnerabilities and exposures (CVE) IDs that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-get_cveids HRESULT get_CveIDs( IStringCollection
		// **retval );
		[DispId(1610809348)]
		IStringCollection CveIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809348)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>Copies files for an update from a specified source location to the internal Windows Update Agent (WUA) download cache.</summary>
		/// <param name="pFiles">
		/// <para>
		/// An IStringCollection interface that represents a collection of strings that contain the full paths of the files for an update.
		/// </para>
		/// <para>
		/// The strings must give the full paths of the files that are being copied. The strings cannot give only the directory that contains
		/// the files.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>This method returns <c>WU_E_INVALID_OPERATION</c> if the object that is implementing the interface has been locked down.</para>
		/// <para>
		/// <c>Note</c>  We don't recommend or support the use of the IUpdate::CopyFromCache and <c>IUpdate2::CopyToCache</c> methods to move
		/// downloaded updates from one computer to another computer. When the Windows Update Agent (WUA) downloads an update, it might only
		/// download the portions of the update’s payload that are necessary for a particular client computer. The necessary portions of the
		/// update’s payload can often vary from one computer to another computer, even if the computers have similar hardware and software
		/// configurations. <c>IUpdate2::CopyToCache</c> only works if the provided files are an exact match for the files that Windows
		/// Update would have normally downloaded on that computer; if you called <c>IUpdate::CopyFromCache</c> to obtain the files on a
		/// different computer, the files are likely not to match the files that Windows Update would have normally downloaded so
		/// <c>IUpdate2::CopyToCache</c> might fail.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-copytocache HRESULT CopyToCache( [in]
		// IStringCollection *pFiles );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809346)]
		void CopyToCache([In, MarshalAs(UnmanagedType.Interface)] IStringCollection pFiles);
	}

	/// <summary>Contains the properties and methods that are available to an update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdate3
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdate3")]
	[ComImport, Guid("112EDA6B-95B3-476F-9D90-AEE82C6B8181"), DefaultMember("Title")]
	public interface IUpdate3 : IUpdate2
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
		new string? HandlerID
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
		/// <para>
		/// Gets a Boolean value that indicates whether a system restart is required on a computer to complete the installation or the
		/// uninstallation of an update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-get_rebootrequired HRESULT get_RebootRequired(
		// VARIANT_BOOL *retval );
		[DispId(1610809345)]
		new bool RebootRequired
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update is present on a computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// An update is considered present if it is installed for one or more products. For example, if an update applies to both Microsoft
		/// Office Word and to Microsoft Office Excel, the <c>IsPresent</c> property returns <c>VARIANT_TRUE</c> if the update is installed
		/// for one or both of the products.
		/// </para>
		/// <para>
		/// If an update applies to only one product, the <c>IsPresent</c> and IsInstalled properties are equivalent. An update is considered
		/// installed if the update is installed for all the products to which it applies.
		/// </para>
		/// <para>
		/// If <c>IsPresent</c> returns <c>VARIANT_TRUE</c> and IsInstalled returns <c>VARIANT_FALSE</c>, the update can be uninstalled for
		/// the product that installed it.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-get_ispresent HRESULT get_IsPresent( VARIANT_BOOL
		// *retval );
		[DispId(1610809347)]
		new bool IsPresent
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809347)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of common vulnerabilities and exposures (CVE) IDs that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-get_cveids HRESULT get_CveIDs( IStringCollection
		// **retval );
		[DispId(1610809348)]
		new IStringCollection CveIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809348)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>Copies files for an update from a specified source location to the internal Windows Update Agent (WUA) download cache.</summary>
		/// <param name="pFiles">
		/// <para>
		/// An IStringCollection interface that represents a collection of strings that contain the full paths of the files for an update.
		/// </para>
		/// <para>
		/// The strings must give the full paths of the files that are being copied. The strings cannot give only the directory that contains
		/// the files.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>This method returns <c>WU_E_INVALID_OPERATION</c> if the object that is implementing the interface has been locked down.</para>
		/// <para>
		/// <c>Note</c>  We don't recommend or support the use of the IUpdate::CopyFromCache and <c>IUpdate2::CopyToCache</c> methods to move
		/// downloaded updates from one computer to another computer. When the Windows Update Agent (WUA) downloads an update, it might only
		/// download the portions of the update’s payload that are necessary for a particular client computer. The necessary portions of the
		/// update’s payload can often vary from one computer to another computer, even if the computers have similar hardware and software
		/// configurations. <c>IUpdate2::CopyToCache</c> only works if the provided files are an exact match for the files that Windows
		/// Update would have normally downloaded on that computer; if you called <c>IUpdate::CopyFromCache</c> to obtain the files on a
		/// different computer, the files are likely not to match the files that Windows Update would have normally downloaded so
		/// <c>IUpdate2::CopyToCache</c> might fail.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-copytocache HRESULT CopyToCache( [in]
		// IStringCollection *pFiles );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809346)]
		new void CopyToCache([In, MarshalAs(UnmanagedType.Interface)] IStringCollection pFiles);

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update can be discovered only by browsing through the available updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate3-get_browseonly HRESULT get_BrowseOnly( VARIANT_BOOL
		// *retval );
		[DispId(1610874881)]
		bool BrowseOnly
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874881)]
			get;
		}
	}

	/// <summary>Contains the properties and methods that are available to an update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdate4
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdate4")]
	[ComImport, Guid("27E94B0D-5139-49A2-9A61-93522DC54652"), DefaultMember("Title")]
	public interface IUpdate4 : IUpdate3
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
		new string? HandlerID
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
		/// <para>
		/// Gets a Boolean value that indicates whether a system restart is required on a computer to complete the installation or the
		/// uninstallation of an update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-get_rebootrequired HRESULT get_RebootRequired(
		// VARIANT_BOOL *retval );
		[DispId(1610809345)]
		new bool RebootRequired
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update is present on a computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// An update is considered present if it is installed for one or more products. For example, if an update applies to both Microsoft
		/// Office Word and to Microsoft Office Excel, the <c>IsPresent</c> property returns <c>VARIANT_TRUE</c> if the update is installed
		/// for one or both of the products.
		/// </para>
		/// <para>
		/// If an update applies to only one product, the <c>IsPresent</c> and IsInstalled properties are equivalent. An update is considered
		/// installed if the update is installed for all the products to which it applies.
		/// </para>
		/// <para>
		/// If <c>IsPresent</c> returns <c>VARIANT_TRUE</c> and IsInstalled returns <c>VARIANT_FALSE</c>, the update can be uninstalled for
		/// the product that installed it.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-get_ispresent HRESULT get_IsPresent( VARIANT_BOOL
		// *retval );
		[DispId(1610809347)]
		new bool IsPresent
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809347)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of common vulnerabilities and exposures (CVE) IDs that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-get_cveids HRESULT get_CveIDs( IStringCollection
		// **retval );
		[DispId(1610809348)]
		new IStringCollection CveIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809348)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>Copies files for an update from a specified source location to the internal Windows Update Agent (WUA) download cache.</summary>
		/// <param name="pFiles">
		/// <para>
		/// An IStringCollection interface that represents a collection of strings that contain the full paths of the files for an update.
		/// </para>
		/// <para>
		/// The strings must give the full paths of the files that are being copied. The strings cannot give only the directory that contains
		/// the files.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>This method returns <c>WU_E_INVALID_OPERATION</c> if the object that is implementing the interface has been locked down.</para>
		/// <para>
		/// <c>Note</c>  We don't recommend or support the use of the IUpdate::CopyFromCache and <c>IUpdate2::CopyToCache</c> methods to move
		/// downloaded updates from one computer to another computer. When the Windows Update Agent (WUA) downloads an update, it might only
		/// download the portions of the update’s payload that are necessary for a particular client computer. The necessary portions of the
		/// update’s payload can often vary from one computer to another computer, even if the computers have similar hardware and software
		/// configurations. <c>IUpdate2::CopyToCache</c> only works if the provided files are an exact match for the files that Windows
		/// Update would have normally downloaded on that computer; if you called <c>IUpdate::CopyFromCache</c> to obtain the files on a
		/// different computer, the files are likely not to match the files that Windows Update would have normally downloaded so
		/// <c>IUpdate2::CopyToCache</c> might fail.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-copytocache HRESULT CopyToCache( [in]
		// IStringCollection *pFiles );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809346)]
		new void CopyToCache([In, MarshalAs(UnmanagedType.Interface)] IStringCollection pFiles);

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update can be discovered only by browsing through the available updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate3-get_browseonly HRESULT get_BrowseOnly( VARIANT_BOOL
		// *retval );
		[DispId(1610874881)]
		new bool BrowseOnly
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874881)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether this is a per-user update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// Per-user updates are designed to alter the current user’s environment only; not the environment of the machine as a whole. For
		/// example, an update which only alters files in the current user’s user directory could be a per-user update; an update which
		/// alters files in the Program Files directory or the Windows directory would not be a per-user update. Per-user updates are
		/// currently not processed by Automatic Updates or displayed in the Windows Update user interface. Instead, they are only available
		/// to callers who specifically request them in searches by using the IUpdateSearcher3 interface. On computers running versions of
		/// Windows Update Agent that do not implement the IUpdate4 interface, only per-machine updates will be available; per-user updates
		/// will never be detected.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate4-get_peruser HRESULT get_PerUser( VARIANT_BOOL *retval );
		[DispId(1610940417)]
		bool PerUser
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610940417)]
			get;
		}
	}

	/// <summary>Contains the properties and methods that are available to an update.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdate5
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdate5")]
	[ComImport, Guid("C1C2F21A-D2F4-4902-B5C6-8A081C19A890"), DefaultMember("Title")]
	public interface IUpdate5 : IUpdate4
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
		new string? HandlerID
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
		/// <para>
		/// Gets a Boolean value that indicates whether a system restart is required on a computer to complete the installation or the
		/// uninstallation of an update.
		/// </para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-get_rebootrequired HRESULT get_RebootRequired(
		// VARIANT_BOOL *retval );
		[DispId(1610809345)]
		new bool RebootRequired
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809345)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update is present on a computer.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// An update is considered present if it is installed for one or more products. For example, if an update applies to both Microsoft
		/// Office Word and to Microsoft Office Excel, the <c>IsPresent</c> property returns <c>VARIANT_TRUE</c> if the update is installed
		/// for one or both of the products.
		/// </para>
		/// <para>
		/// If an update applies to only one product, the <c>IsPresent</c> and IsInstalled properties are equivalent. An update is considered
		/// installed if the update is installed for all the products to which it applies.
		/// </para>
		/// <para>
		/// If <c>IsPresent</c> returns <c>VARIANT_TRUE</c> and IsInstalled returns <c>VARIANT_FALSE</c>, the update can be uninstalled for
		/// the product that installed it.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-get_ispresent HRESULT get_IsPresent( VARIANT_BOOL
		// *retval );
		[DispId(1610809347)]
		new bool IsPresent
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809347)]
			get;
		}

		/// <summary>
		/// <para>Gets a collection of common vulnerabilities and exposures (CVE) IDs that are associated with the update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-get_cveids HRESULT get_CveIDs( IStringCollection
		// **retval );
		[DispId(1610809348)]
		new IStringCollection CveIDs
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809348)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>Copies files for an update from a specified source location to the internal Windows Update Agent (WUA) download cache.</summary>
		/// <param name="pFiles">
		/// <para>
		/// An IStringCollection interface that represents a collection of strings that contain the full paths of the files for an update.
		/// </para>
		/// <para>
		/// The strings must give the full paths of the files that are being copied. The strings cannot give only the directory that contains
		/// the files.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>This method returns <c>WU_E_INVALID_OPERATION</c> if the object that is implementing the interface has been locked down.</para>
		/// <para>
		/// <c>Note</c>  We don't recommend or support the use of the IUpdate::CopyFromCache and <c>IUpdate2::CopyToCache</c> methods to move
		/// downloaded updates from one computer to another computer. When the Windows Update Agent (WUA) downloads an update, it might only
		/// download the portions of the update’s payload that are necessary for a particular client computer. The necessary portions of the
		/// update’s payload can often vary from one computer to another computer, even if the computers have similar hardware and software
		/// configurations. <c>IUpdate2::CopyToCache</c> only works if the provided files are an exact match for the files that Windows
		/// Update would have normally downloaded on that computer; if you called <c>IUpdate::CopyFromCache</c> to obtain the files on a
		/// different computer, the files are likely not to match the files that Windows Update would have normally downloaded so
		/// <c>IUpdate2::CopyToCache</c> might fail.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate2-copytocache HRESULT CopyToCache( [in]
		// IStringCollection *pFiles );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610809346)]
		new void CopyToCache([In, MarshalAs(UnmanagedType.Interface)] IStringCollection pFiles);

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether an update can be discovered only by browsing through the available updates.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate3-get_browseonly HRESULT get_BrowseOnly( VARIANT_BOOL
		// *retval );
		[DispId(1610874881)]
		new bool BrowseOnly
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874881)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether this is a per-user update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// Per-user updates are designed to alter the current user’s environment only; not the environment of the machine as a whole. For
		/// example, an update which only alters files in the current user’s user directory could be a per-user update; an update which
		/// alters files in the Program Files directory or the Windows directory would not be a per-user update. Per-user updates are
		/// currently not processed by Automatic Updates or displayed in the Windows Update user interface. Instead, they are only available
		/// to callers who specifically request them in searches by using the IUpdateSearcher3 interface. On computers running versions of
		/// Windows Update Agent that do not implement the IUpdate4 interface, only per-machine updates will be available; per-user updates
		/// will never be detected.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate4-get_peruser HRESULT get_PerUser( VARIANT_BOOL *retval );
		[DispId(1610940417)]
		new bool PerUser
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610940417)]
			get;
		}

		/// <summary>
		/// <para>Gets a value indicating the automatic selection mode of update in the Control Panel of Windows Update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The AutoSelection property indicates whether the update will be automatically selected when the user views the available updates
		/// in the Windows Update user interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate5-get_autoselection HRESULT get_AutoSelection(
		// AutoSelectionMode *retval );
		[DispId(1611005953), ComAliasName("WUApiLib.AutoSelectionMode")]
		AutoSelectionMode AutoSelection
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1611005953)]
			[return: ComAliasName("WUApiLib.AutoSelectionMode")]
			get;
		}

		/// <summary>
		/// <para>Gets a value indicating the automatic download mode of update.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>The AutoDownload property indicates whether the update will be automatically downloaded by Automatic Updates.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdate5-get_autodownload HRESULT get_AutoDownload(
		// AutoDownloadMode *retval );
		[ComAliasName("WUApiLib.AutoDownloadMode"), DispId(1611005954)]
		AutoDownloadMode AutoDownload
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1611005954)]
			[return: ComAliasName("WUApiLib.AutoDownloadMode")]
			get;
		}
	}

	/// <summary>Represents an ordered list of updates.</summary>
	/// <remarks>
	/// You can create an instance of this interface by using the UpdateCollection coclass. Use the Microsoft.Update.UpdateColl program
	/// identifier to create the object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nn-wuapi-iupdatecollection
	[PInvokeData("wuapi.h", MSDNShortId = "NN:wuapi.IUpdateCollection")]
	[ComImport, Guid("07F7438C-7709-4CA5-B518-91279288134E")/*, CoClass(typeof(UpdateCollectionClass))*/]
	public interface IUpdateCollection : IEnumerable
	{
		/// <summary>
		/// <para>Gets or sets an IUpdate interface in a collection.</para>
		/// <para>This property is read/write.</para>
		/// </summary>
		/// <param name="index"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatecollection-get_item HRESULT get_Item( LONG index,
		// IUpdate **retval );
		[DispId(0)]
		IUpdate this[[In] int index]
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
			[param: In, MarshalAs(UnmanagedType.Interface)]
			set;
		}

		/// <summary>
		/// <para>Gets an IEnumVARIANT interface that can be used to enumerate the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatecollection-get__newenum HRESULT get__NewEnum( IUnknown
		// **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		new IEnumerator GetEnumerator();

		/// <summary>
		/// <para>Gets the number of elements in the collection.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatecollection-get_count HRESULT get_Count( LONG *retval );
		[DispId(0x60020001)]
		int Count
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020001)]
			get;
		}

		/// <summary>
		/// <para>Gets a Boolean value that indicates whether the update collection is read-only.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatecollection-get_readonly HRESULT get_ReadOnly(
		// VARIANT_BOOL *retval );
		[DispId(0x60020002)]
		bool ReadOnly
		{
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020002)]
			get;
		}

		/// <summary>Adds an item to the collection.</summary>
		/// <param name="value">An IUpdate interface to be added to the collection.</param>
		/// <returns>The index of the added interface in the collection.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatecollection-add HRESULT Add( [in] IUpdate *value, [out]
		// LONG *retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020003)]
		int Add([In, MarshalAs(UnmanagedType.Interface)] IUpdate value);

		/// <summary>Removes all the elements from the collection.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatecollection-clear HRESULT Clear();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020004)]
		void Clear();

		/// <summary>Creates a shallow read/write copy of the collection.</summary>
		/// <returns>A shallow read/write copy of the collection.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatecollection-copy HRESULT Copy( [out] IUpdateCollection
		// **retval );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020005)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IUpdateCollection Copy();

		/// <summary>Inserts an item into the collection at the specified position.</summary>
		/// <param name="index">The position at which a new interface will be inserted.</param>
		/// <param name="value">The IUpdate interface that will be inserted.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatecollection-insert HRESULT Insert( [in] LONG index, [in]
		// IUpdate *value );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020006)]
		void Insert([In] int index, [In, MarshalAs(UnmanagedType.Interface)] IUpdate value);

		/// <summary>Removes the item at the specified index from the collection.</summary>
		/// <param name="index">The index of the interface to be removed.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdatecollection-removeat HRESULT RemoveAt( [in] LONG index );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020007)]
		void RemoveAt([In] int index);
	}
}