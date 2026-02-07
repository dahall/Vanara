namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Specifies application management actions supported by an application publisher. These flags are bitmasks passed to IShellApp::GetPossibleActions.</summary>
	/// <remarks>
	/// The Add or Remove Programs application in Control Panel uses only <c><c>APPACTION_INSTALL</c></c> and
	/// <c><c>APPACTION_ADDLATER</c></c> for published applications.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/ne-shappmgr-appactionflags typedef enum _tagAppActionFlags {
	// APPACTION_INSTALL = 0x1, APPACTION_UNINSTALL = 0x2, APPACTION_MODIFY = 0x4, APPACTION_REPAIR = 0x8, APPACTION_UPGRADE = 0x10,
	// APPACTION_CANGETSIZE = 0x20, APPACTION_MODIFYREMOVE = 0x80, APPACTION_ADDLATER = 0x100, APPACTION_UNSCHEDULE = 0x200 } APPACTIONFLAGS;
	[PInvokeData("shappmgr.h", MSDNShortId = "NE:shappmgr._tagAppActionFlags")]
	[Flags]
	public enum APPACTIONFLAGS : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Indicates that the application can be installed. Published applications always set this bit.</para>
		/// </summary>
		APPACTION_INSTALL = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		APPACTION_UNINSTALL = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		APPACTION_MODIFY = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		APPACTION_REPAIR = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		APPACTION_UPGRADE = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		APPACTION_CANGETSIZE = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		APPACTION_MODIFYREMOVE = 0x80,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100</para>
		/// <para>
		/// Indicates that the application supports scheduled installation. If this bit is set, then the Control Panel's Add or Remove
		/// Programs application presents the user an
		/// </para>
		/// <para>Add Later</para>
		/// <para>button. If you select</para>
		/// <para>Add Later</para>
		/// <para>, you are prompted to select the desired time of installation. The</para>
		/// <para>IPublishedApp::Install</para>
		/// <para>method is then called with the installation time.</para>
		/// </summary>
		APPACTION_ADDLATER = 0x100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x200</para>
		/// <para>Obsolete.</para>
		/// </summary>
		APPACTION_UNSCHEDULE = 0x200,
	}

	/// <summary>
	/// Specifies application information to return from IShellApp::GetAppInfo. These flags are bitmasks used in the dwMask member of the
	/// <c>APPINFODATA</c> structure.
	/// </summary>
	/// <remarks>Add/Remove Programs in Control Panel uses only <c>AIM_DISPLAYNAME</c> and <c>AIM_SUPPORTURL.</c></remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/ne-shappmgr-appinfodataflags typedef enum _tagAppInfoFlags {
	// AIM_DISPLAYNAME = 0x1, AIM_VERSION = 0x2, AIM_PUBLISHER = 0x4, AIM_PRODUCTID = 0x8, AIM_REGISTEREDOWNER = 0x10, AIM_REGISTEREDCOMPANY
	// = 0x20, AIM_LANGUAGE = 0x40, AIM_SUPPORTURL = 0x80, AIM_SUPPORTTELEPHONE = 0x100, AIM_HELPLINK = 0x200, AIM_INSTALLLOCATION = 0x400,
	// AIM_INSTALLSOURCE = 0x800, AIM_INSTALLDATE = 0x1000, AIM_CONTACT = 0x4000, AIM_COMMENTS = 0x8000, AIM_IMAGE = 0x20000, AIM_READMEURL =
	// 0x40000, AIM_UPDATEINFOURL = 0x80000 } APPINFODATAFLAGS;
	[PInvokeData("shappmgr.h", MSDNShortId = "NE:shappmgr._tagAppInfoFlags")]
	[Flags]
	public enum APPINFODATAFLAGS : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>Returns the display name.</para>
		/// </summary>
		AIM_DISPLAYNAME = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>Returns the version.</para>
		/// </summary>
		AIM_VERSION = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Returns the application publisher.</para>
		/// </summary>
		AIM_PUBLISHER = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>Returns the application's product ID.</para>
		/// </summary>
		AIM_PRODUCTID = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>Returns the application's registered owner.</para>
		/// </summary>
		AIM_REGISTEREDOWNER = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>Returns the application's registered company.</para>
		/// </summary>
		AIM_REGISTEREDCOMPANY = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>Returns the language.</para>
		/// </summary>
		AIM_LANGUAGE = 0x40,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80</para>
		/// <para>Returns the support URL.</para>
		/// </summary>
		AIM_SUPPORTURL = 0x80,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x100</para>
		/// <para>Returns the support telephone number.</para>
		/// </summary>
		AIM_SUPPORTTELEPHONE = 0x100,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x200</para>
		/// <para>Returns the Help link.</para>
		/// </summary>
		AIM_HELPLINK = 0x200,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x400</para>
		/// <para>Returns the application's install location.</para>
		/// </summary>
		AIM_INSTALLLOCATION = 0x400,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x800</para>
		/// <para>Returns the install source.</para>
		/// </summary>
		AIM_INSTALLSOURCE = 0x800,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1000</para>
		/// <para>Returns the application's install date.</para>
		/// </summary>
		AIM_INSTALLDATE = 0x1000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4000</para>
		/// <para>Returns the application's contact information.</para>
		/// </summary>
		AIM_CONTACT = 0x4000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8000</para>
		/// <para>Returns application comments.</para>
		/// </summary>
		AIM_COMMENTS = 0x8000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20000</para>
		/// <para>Returns the application image.</para>
		/// </summary>
		AIM_IMAGE = 0x20000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40000</para>
		/// <para>Returns the URL of the application's ReadMe file.</para>
		/// </summary>
		AIM_READMEURL = 0x40000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000</para>
		/// <para>Returns the URL of the application's update information.</para>
		/// </summary>
		AIM_UPDATEINFOURL = 0x80000,
	}

	/// <summary>
	/// Specifies which members in the PUBAPPINFO structure are valid. These flags are bitmasks set in the <c>dwMask</c> member and passed to IPublishedApp::GetPublishedAppInfo.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/ne-shappmgr-pubappinfoflags typedef enum _tagPublishedAppInfoFlags {
	// PAI_SOURCE = 0x1, PAI_ASSIGNEDTIME = 0x2, PAI_PUBLISHEDTIME = 0x4, PAI_SCHEDULEDTIME = 0x8, PAI_EXPIRETIME = 0x10 } PUBAPPINFOFLAGS;
	[PInvokeData("shappmgr.h", MSDNShortId = "NE:shappmgr._tagPublishedAppInfoFlags")]
	[Flags]
	public enum PUBAPPINFOFLAGS : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The</para>
		/// <para>pszSource</para>
		/// <para>
		/// string is valid and contains the display name of the publishing source. If multiple sources publish an application of the same
		/// name, Add/Remove Programs identifies them by "&lt;application name&gt; : &lt;publishing source&gt;".
		/// </para>
		/// </summary>
		PAI_SOURCE = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The</para>
		/// <para>stAssigned</para>
		/// <para>member is valid and contains the time that the application should be installed as assigned by an application administrator.</para>
		/// </summary>
		PAI_ASSIGNEDTIME = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>Not used.</para>
		/// </summary>
		PAI_PUBLISHEDTIME = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>The</para>
		/// <para>stScheduled</para>
		/// <para>member is valid and contains the time that the application should be installed as assigned by the user.</para>
		/// </summary>
		PAI_SCHEDULEDTIME = 0x8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>The</para>
		/// <para>stExpired</para>
		/// <para>member is valid and contains the time after which Add/Remove Programs should no longer install the program.</para>
		/// </summary>
		PAI_EXPIRETIME = 0x10,
	}

	/// <summary>
	/// Exposes methods for publishing applications through <c>Add/Remove Programs</c> in Control Panel. This is the principal interface
	/// implemented for this purpose.
	/// </summary>
	/// <remarks>
	/// <para>
	/// <c>Add/Remove Programs</c> in Control Panel creates a registered publisher object and requests its <c>IAppPublisher</c> interface.
	/// You can create published application objects using the application enumerator, which you create using <c>IAppPublisher</c>.
	/// </para>
	/// <para>
	/// <c>Add/Remove Programs</c> gathers a list of published applications from publishers and then uses a publisher to display these
	/// applications with Microsoft Active Directory. When the user clicks <c>Add New Programs</c> in <c>Add/Remove Programs,</c> a list of
	/// published applications appears.
	/// </para>
	/// <para>You can publish applications in <c>Add/Remove Programs</c> using the following Component Object Model (COM) interfaces.</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>IAppPublisher</c></term>
	/// </item>
	/// <item>
	/// <term>IEnumPublishedApps</term>
	/// </item>
	/// <item>
	/// <term>IPublishedApp</term>
	/// </item>
	/// </list>
	/// <para>
	/// When you implement these interfaces, you must register your COM object in the registry. To register your publisher, add your object's
	/// class identifier (CLSID) under the following registry key.
	/// </para>
	/// <para><c>HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\AppManagement\Publishers</c></para>
	/// <para>
	/// For example, if your publisher is named "My Publisher", you create a new key under "Publishers" named "My Publisher" with its default
	/// REG_SZ value as the publisher's CLSID:
	/// </para>
	/// <para><c>HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\AppManagement\Publishers\My Publisher (Default) = {4D05CD3D-FFED-46bb-B9F1-321C26BE6362}</c></para>
	/// <para>You can also create the typical COM server registration entries as follows:</para>
	/// <para>
	/// <c>HKEY_CLASSES_ROOT\CLSID\{469EE8CE-1B86-4524-9042-AAA44FD9C8F2} (Default) = Sample Applications Publisher</c>
	/// <c>InProcServer32</c> (Default) = pubdemo.dll <c>ThreadingModel</c> = Apartment
	/// </para>
	/// <para>
	/// With the publisher registered in this way, <c>Add/Remove Programs</c> creates an instance of your object by calling CoCreateInstance
	/// for your object and requesting the appropriate <c>IAppPublisher</c> interface when the <c>Add New Programs</c> view is populated.
	/// Using <c>IAppPublisher</c>, Add/Remove Programs retrieves the application enumerator (IEnumPublishedApps) and information that
	/// describes the published applications. Your implementation of IPublishedApp is responsible for installing the associated application
	/// in its IPublishedApp::Install method. Add/Remove Programs calls this method when the user clicks the <c>Add</c> or the <c>Add
	/// Later</c> button in the user interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nn-shappmgr-iapppublisher
	[PInvokeData("shappmgr.h", MSDNShortId = "NN:shappmgr.IAppPublisher")]
	[ComImport, Guid("07250A10-9CF9-11D1-9076-006008059382"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAppPublisher
	{
		/// <summary>Obsolete. Clients of the Add/Remove Programs Control Panel Application may return E_NOTIMPL.</summary>
		/// <param name="pdwCat">This parameter is unused.</param>
		/// <returns>This method does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-iapppublisher-getnumberofcategories HRESULT
		// GetNumberOfCategories( DWORD *pdwCat );
		[PreserveSig, Obsolete]
		HRESULT GetNumberOfCategories(out uint pdwCat);

		/// <summary>Retrieves a structure listing the categories provided by an application publisher.</summary>
		/// <param name="pAppCategoryList">
		/// <para>Type: <c>APPCATEGORYINFOLIST*</c></para>
		/// <para>
		/// A pointer to an APPCATEGORYINFOLIST structure. This structure's <c>cCategory</c> member returns the count of supported
		/// categories. The <c>pCategoryInfo</c> member returns a pointer to an array of APPCATEGORYINFO structures. This array contains all
		/// the categories an application publisher supports and must be allocated using CoTaskMemAlloc and freed using CoTaskMemFree.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The Add/Remove Programs Control Panel Application passes the ID returned for a category to the IAppPublisher::EnumApps method to
		/// identify which category is to be enumerated.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example shows how to calculate the size of the array of APPCATEGORYINFO structures that is returned by <c>IAppPublisher::GetCategories</c>.</para>
		/// <para>
		/// <code>size_t CategoryListArraySize = sizeof(APPCATEGORYINFO) * pInfoList-&gt;cCategory;</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-iapppublisher-getcategories HRESULT GetCategories( [out]
		// APPCATEGORYINFOLIST *pAppCategoryList );
		[PreserveSig]
		HRESULT GetCategories(out APPCATEGORYINFOLIST pAppCategoryList);

		/// <summary>Obsolete. Clients of Add/Remove Programs Control Panel Application can return E_NOTIMPL.</summary>
		/// <param name="pdwApps">This parameter is unused.</param>
		/// <returns>This method does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-iapppublisher-getnumberofapps HRESULT GetNumberOfApps(
		// DWORD *pdwApps );
		[PreserveSig, Obsolete]
		HRESULT GetNumberOfApps(out uint pdwApps);

		/// <summary>Creates an enumerator for enumerating all applications published by an application publisher for a given category.</summary>
		/// <param name="pAppCategoryId">
		/// <para>Type: <c>GUID*</c></para>
		/// <para>
		/// A pointer to a GUID that specifies the application category to be enumerated. This must be one of the categories provided through
		/// IAppPublisher::GetCategories. If <c>pAppCategoryID</c> identifies a category not provided through
		/// <c>IAppPublisher::GetCategories</c>, creation of the enumerator succeeds with the enumerator returning zero items. If this
		/// parameter value is <c>NULL</c>, the enumerator returns applications published for all categories.
		/// </para>
		/// </param>
		/// <param name="ppepa">
		/// <para>Type: <c>IEnumPublishedApps**</c></para>
		/// <para>
		/// The address of a pointer to an IEnumPublishedApps reference variable that points to a <c>IEnumPublishedApps</c> interface.
		/// Application publishers must create an enumeration object that supports the <c>IEnumPublishedApps</c> interface, and return its
		/// pointer value through this parameter.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <c>Note</c> IEnumPublishedApps is not a standard enumeration interface. It does not support a Skip method nor does its Next
		/// method support retrieval of multiple items.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-iapppublisher-enumapps HRESULT EnumApps( [in] GUID
		// *pAppCategoryId, [out] IEnumPublishedApps **ppepa );
		[PreserveSig]
		unsafe HRESULT EnumApps([In, Optional] Guid* pAppCategoryId, out IEnumPublishedApps ppepa);
	}

	/// <summary>
	/// Exposes methods that enumerate published applications to Add/Remove Programs in the Control Panel. The object exposing this interface
	/// is requested through IAppPublisher::EnumApps.
	/// </summary>
	/// <remarks>
	/// To publish applications to Add/Remove Programs in the Control Panel, you must support <c>IEnumPublishedApps</c>, IAppPublisher and IPublishedApp.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nn-shappmgr-ienumpublishedapps
	[PInvokeData("shappmgr.h", MSDNShortId = "NN:shappmgr.IEnumPublishedApps")]
	[ComImport, Guid("0B124F8C-91F0-11D1-B8B5-006008059382"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumPublishedApps
	{
		/// <summary>Gets the next IPublishedApp object in the enumeration.</summary>
		/// <param name="pia">
		/// <para>Type: <c>IPublishedApp**</c></para>
		/// <para>
		/// A pointer to an IPublishedApp interface reference variable that returns the next application object. Note that the category of
		/// the application object returned must match that passed into EnumApps.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if an item is returned, S_FALSE if there are no more items to enumerate, a COM-defined error value otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <c>Note</c> IEnumPublishedApps is not a standard enumeration interface. It does not support a Skip method, nor does its Next
		/// method support retrieval of multiple items.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ienumpublishedapps-next HRESULT Next( [out] IPublishedApp
		// **pia );
		[PreserveSig]
		HRESULT Next(out IPublishedApp pia);

		/// <summary>Resets the enumeration of IPublishedApp objects to the first item.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>This method only returns S_OK.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para><c>Note</c> IEnumPublishedApps is not a standard enumeration interface.</para>
		/// <para>It does not support a Skip method nor does its Next method support retrieval of multiple items.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ienumpublishedapps-reset HRESULT Reset();
		[PreserveSig]
		HRESULT Reset();
	}

	/// <summary>Exposes methods that represent applications to Add/Remove Programs in Control Panel.</summary>
	/// <remarks>
	/// To publish applications to Add/Remove Programs in Control Panel, you must support IEnumPublishedApps, IAppPublisher and <c>IPublishedApp</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nn-shappmgr-ipublishedapp
	[PInvokeData("shappmgr.h", MSDNShortId = "NN:shappmgr.IPublishedApp")]
	[ComImport, Guid("1BC752E0-9046-11D1-B8B3-006008059382"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPublishedApp : IShellApp
	{
		/// <summary>Gets general information about an application.</summary>
		/// <param name="pai">
		/// <para>Type: <c>APPINFODATA*</c></para>
		/// <para>A pointer to an APPINFODATA structure that returns the application information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>Note</c> Add/Remove Programs in the Control Panel sets the cbSize and dwMask members of the APPINFODATA structure.</para>
		/// <para>
		/// Your implementation should validate cbSize by comparing it with the size of APPINFODATA. If cbSize does not equal the size of
		/// <c>APPINFODATA</c>, this method should return a COM error value like E_FAIL.
		/// </para>
		/// <para>
		/// Add/Remove Programs in the Control Panel will set the dwMask member of the APPINFODATA structure to indicate that you should
		/// return AIM_DISPLAYNAME and AIM_SUPPORTURL. For each value that you return in APPINFODATA, you must set the corresponding bit in
		/// dwMask. All other bits should be cleared.
		/// </para>
		/// <para>Examples</para>
		/// <para>Here is a sample of how to use the dwMask bits::</para>
		/// <para>
		/// <code>HRESULT CPubApp::GetAppInfo(APPINFODATA *pData) { if (sizeof(APPINFODATA) != pData-&gt;cbSize) return E_FAIL; // First save off the mask of requested data items. const DWORD dwMask = pData-&gt;dwMask; // Zero-out the mask. Bits will be set as items are obtained. pData-&gt;dwMask = 0; // Call an internal function that obtains data and sets // bits in pData-&gt;dwMask for each item obtained. return get_app_info_data(pData, dwMask); }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ishellapp-getappinfo HRESULT GetAppInfo( [out]
		// PAPPINFODATA pai );
		[PreserveSig]
		new HRESULT GetAppInfo(ref APPINFODATA pai);

		/// <summary>Gets a bitmask of management actions allowed for an application.</summary>
		/// <param name="pdwActions">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// A pointer to a variable of type <c>DWORD</c> that returns the bitmask of supported actions. The bit flags are described in APPACTIONFLAGS.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>Of the set of APPACTIONFLAGS bitmasks, Add/Remove Programs only recognizes APPACTION_INSTALL and APPACTION_ADDLATER.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ishellapp-getpossibleactions HRESULT GetPossibleActions(
		// [out] DWORD *pdwActions );
		[PreserveSig]
		new HRESULT GetPossibleActions(out APPACTIONFLAGS pdwActions);

		/// <summary>
		/// Returns information to the application that originates from a slow source. This method is not applicable to published applications.
		/// </summary>
		/// <param name="psaid">
		/// <para>Type: <c>PSLOWAPPINFO</c></para>
		/// <para>A pointer to a SLOWAPPINFO structure in which to return application information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// Implementations of IPublishedApp should return E_NOTIMPL. This method is used internally by Add/Remove Programs for installed applications.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ishellapp-getslowappinfo HRESULT GetSlowAppInfo( [out]
		// PSLOWAPPINFO psaid );
		[PreserveSig]
		new HRESULT GetSlowAppInfo(out SLOWAPPINFO psaid);

		/// <summary>
		/// Returns information to the application that originates from a slow source. Unlike IShellApp::GetSlowAppInfo, this method can
		/// return information that has been cached. This method is not applicable to published applications.
		/// </summary>
		/// <param name="psaid">
		/// <para>Type: <c>PSLOWAPPINFO</c></para>
		/// <para>A pointer to a SLOWAPPINFO structure in which to return application information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// Implementations of IPublishedApp return E_NOTIMPL. This method is used internally by Add/Remove Programs for installed applications.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ishellapp-getcachedslowappinfo HRESULT
		// GetCachedSlowAppInfo( [out] PSLOWAPPINFO psaid );
		[PreserveSig]
		new HRESULT GetCachedSlowAppInfo(out SLOWAPPINFO psaid);

		/// <summary>Gets a value indicating whether a specified application is currently installed.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The application is installed.</term>
		/// </item>
		/// <item>
		/// <term><c>S_FALSE</c></term>
		/// <term>The application is not installed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Application publishers should determine if the application is currently installed and return S_OK if so, or S_FALSE if not.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ishellapp-isinstalled HRESULT IsInstalled();
		[PreserveSig]
		new HRESULT IsInstalled();

		/// <summary>
		/// Installs an application published by an application publisher. This method is invoked when the user selects <c>Add</c> or <c>Add
		/// Later</c> in <c>Add/Remove Programs</c> in Control Panel.
		/// </summary>
		/// <param name="pstInstall">
		/// <para>Type: <c>LPSYSTEMTIME</c></para>
		/// <para>
		/// A pointer to a SYSTEMTIME structure that specifies the time the user elected to schedule installation through the <c>Add
		/// Later</c> button in <c>Add/Remove Programs</c>. This option is only available if the application supports scheduled installation
		/// (compare GetPossibleActions). If this parameter is <c>NULL</c>, the application should be installed immediately.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ipublishedapp-install HRESULT Install( [in] LPSYSTEMTIME
		// pstInstall );
		[PreserveSig]
		unsafe HRESULT Install([In, Optional] SYSTEMTIME* pstInstall);

		/// <summary>Gets publishing-related information about an application published by an application publisher.</summary>
		/// <param name="ppai">
		/// <para>Type: <c>PUBAPPINFO*</c></para>
		/// <para>A pointer to an PUBAPPINFO structure that returns the application information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The dwMask member of the PUBAPPINFO structure indicates which members have been requested. Note that Add/Remove Programs will not
		/// set the PAI_SCHEDULEDTIME and PAI_EXPIREDTIME bits. However, the corresponding values stScheduled and stExpired will be used when
		/// applicable if the implementation provides them. A publisher should provide this data if it is available.
		/// </para>
		/// <para>Examples</para>
		/// <para>The example shows a sample implementation:</para>
		/// <para>
		/// <code>HRESULT CPubApp::GetPublishedAppInfo(PUBAPPINFO *pInfo) { if (sizeof(PUBAPPINFO) != pInfo-&gt;cbSize) return E_FAIL; // Add/Remove Programs will use these items but will not ask for them. pInfo-&gt;dwMask |= (PAI_EXPIRETIME | PAI_SCHEDULEDTIME); // First save off the mask of requested data items. const DWORD dwMask = pInfo-&gt;dwMask; // Zero-out the mask. The bits should be set as items are retrieved. pInfo-&gt;dwMask = 0; // Call an internal function that obtains data and sets // bits in pInfo-&gt;dwMask for each item obtained. return get_pub_app_info(pInfo, dwMask); }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ipublishedapp-getpublishedappinfo HRESULT
		// GetPublishedAppInfo( [out] PPUBAPPINFO ppai );
		[PreserveSig]
		HRESULT GetPublishedAppInfo(ref PUBAPPINFO ppai);

		/// <summary>Cancels the installation of an application published by an application publisher.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is called in each of the following circumstances.</para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// The user selected the <c>Do Not Add Program</c> option in the <c>Add Later</c> dialog box in <c>Add/Remove Programs</c> in
		/// Control Panel.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The user has selected an installation time later than either the expiration time or the assigned time as specified in the
		/// published application information. In these circumstances, implementations are expected to cancel any scheduled installation for
		/// the application.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ipublishedapp-unschedule HRESULT Unschedule();
		[PreserveSig]
		HRESULT Unschedule();
	}

	/// <summary>Extends the IPublishedApp interface by providing an additional installation method.</summary>
	/// <remarks>This interface also provides the methods of the IPublishedApp interface, from which it inherits.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nn-shappmgr-ipublishedapp2
	[PInvokeData("shappmgr.h", MSDNShortId = "NN:shappmgr.IPublishedApp2")]
	[ComImport, Guid("12B81347-1B3A-4A04-AA61-3F768B67FD7E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPublishedApp2 : IPublishedApp
	{
		/// <summary>Gets general information about an application.</summary>
		/// <param name="pai">
		/// <para>Type: <c>APPINFODATA*</c></para>
		/// <para>A pointer to an APPINFODATA structure that returns the application information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>Note</c> Add/Remove Programs in the Control Panel sets the cbSize and dwMask members of the APPINFODATA structure.</para>
		/// <para>
		/// Your implementation should validate cbSize by comparing it with the size of APPINFODATA. If cbSize does not equal the size of
		/// <c>APPINFODATA</c>, this method should return a COM error value like E_FAIL.
		/// </para>
		/// <para>
		/// Add/Remove Programs in the Control Panel will set the dwMask member of the APPINFODATA structure to indicate that you should
		/// return AIM_DISPLAYNAME and AIM_SUPPORTURL. For each value that you return in APPINFODATA, you must set the corresponding bit in
		/// dwMask. All other bits should be cleared.
		/// </para>
		/// <para>Examples</para>
		/// <para>Here is a sample of how to use the dwMask bits::</para>
		/// <para>
		/// <code>HRESULT CPubApp::GetAppInfo(APPINFODATA *pData) { if (sizeof(APPINFODATA) != pData-&gt;cbSize) return E_FAIL; // First save off the mask of requested data items. const DWORD dwMask = pData-&gt;dwMask; // Zero-out the mask. Bits will be set as items are obtained. pData-&gt;dwMask = 0; // Call an internal function that obtains data and sets // bits in pData-&gt;dwMask for each item obtained. return get_app_info_data(pData, dwMask); }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ishellapp-getappinfo HRESULT GetAppInfo( [out]
		// PAPPINFODATA pai );
		[PreserveSig]
		new HRESULT GetAppInfo(ref APPINFODATA pai);

		/// <summary>Gets a bitmask of management actions allowed for an application.</summary>
		/// <param name="pdwActions">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// A pointer to a variable of type <c>DWORD</c> that returns the bitmask of supported actions. The bit flags are described in APPACTIONFLAGS.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>Of the set of APPACTIONFLAGS bitmasks, Add/Remove Programs only recognizes APPACTION_INSTALL and APPACTION_ADDLATER.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ishellapp-getpossibleactions HRESULT GetPossibleActions(
		// [out] DWORD *pdwActions );
		[PreserveSig]
		new HRESULT GetPossibleActions(out APPACTIONFLAGS pdwActions);

		/// <summary>
		/// Returns information to the application that originates from a slow source. This method is not applicable to published applications.
		/// </summary>
		/// <param name="psaid">
		/// <para>Type: <c>PSLOWAPPINFO</c></para>
		/// <para>A pointer to a SLOWAPPINFO structure in which to return application information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// Implementations of IPublishedApp should return E_NOTIMPL. This method is used internally by Add/Remove Programs for installed applications.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ishellapp-getslowappinfo HRESULT GetSlowAppInfo( [out]
		// PSLOWAPPINFO psaid );
		[PreserveSig]
		new HRESULT GetSlowAppInfo(out SLOWAPPINFO psaid);

		/// <summary>
		/// Returns information to the application that originates from a slow source. Unlike IShellApp::GetSlowAppInfo, this method can
		/// return information that has been cached. This method is not applicable to published applications.
		/// </summary>
		/// <param name="psaid">
		/// <para>Type: <c>PSLOWAPPINFO</c></para>
		/// <para>A pointer to a SLOWAPPINFO structure in which to return application information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// Implementations of IPublishedApp return E_NOTIMPL. This method is used internally by Add/Remove Programs for installed applications.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ishellapp-getcachedslowappinfo HRESULT
		// GetCachedSlowAppInfo( [out] PSLOWAPPINFO psaid );
		[PreserveSig]
		new HRESULT GetCachedSlowAppInfo(out SLOWAPPINFO psaid);

		/// <summary>Gets a value indicating whether a specified application is currently installed.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The application is installed.</term>
		/// </item>
		/// <item>
		/// <term><c>S_FALSE</c></term>
		/// <term>The application is not installed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Application publishers should determine if the application is currently installed and return S_OK if so, or S_FALSE if not.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ishellapp-isinstalled HRESULT IsInstalled();
		[PreserveSig]
		new HRESULT IsInstalled();

		/// <summary>
		/// Installs an application published by an application publisher. This method is invoked when the user selects <c>Add</c> or <c>Add
		/// Later</c> in <c>Add/Remove Programs</c> in Control Panel.
		/// </summary>
		/// <param name="pstInstall">
		/// <para>Type: <c>LPSYSTEMTIME</c></para>
		/// <para>
		/// A pointer to a SYSTEMTIME structure that specifies the time the user elected to schedule installation through the <c>Add
		/// Later</c> button in <c>Add/Remove Programs</c>. This option is only available if the application supports scheduled installation
		/// (compare GetPossibleActions). If this parameter is <c>NULL</c>, the application should be installed immediately.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ipublishedapp-install HRESULT Install( [in] LPSYSTEMTIME
		// pstInstall );
		[PreserveSig]
		new unsafe HRESULT Install([In, Optional] SYSTEMTIME* pstInstall);

		/// <summary>Gets publishing-related information about an application published by an application publisher.</summary>
		/// <param name="ppai">
		/// <para>Type: <c>PUBAPPINFO*</c></para>
		/// <para>A pointer to an PUBAPPINFO structure that returns the application information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The dwMask member of the PUBAPPINFO structure indicates which members have been requested. Note that Add/Remove Programs will not
		/// set the PAI_SCHEDULEDTIME and PAI_EXPIREDTIME bits. However, the corresponding values stScheduled and stExpired will be used when
		/// applicable if the implementation provides them. A publisher should provide this data if it is available.
		/// </para>
		/// <para>Examples</para>
		/// <para>The example shows a sample implementation:</para>
		/// <para>
		/// <code>HRESULT CPubApp::GetPublishedAppInfo(PUBAPPINFO *pInfo) { if (sizeof(PUBAPPINFO) != pInfo-&gt;cbSize) return E_FAIL; // Add/Remove Programs will use these items but will not ask for them. pInfo-&gt;dwMask |= (PAI_EXPIRETIME | PAI_SCHEDULEDTIME); // First save off the mask of requested data items. const DWORD dwMask = pInfo-&gt;dwMask; // Zero-out the mask. The bits should be set as items are retrieved. pInfo-&gt;dwMask = 0; // Call an internal function that obtains data and sets // bits in pInfo-&gt;dwMask for each item obtained. return get_pub_app_info(pInfo, dwMask); }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ipublishedapp-getpublishedappinfo HRESULT
		// GetPublishedAppInfo( [out] PPUBAPPINFO ppai );
		[PreserveSig]
		new HRESULT GetPublishedAppInfo(ref PUBAPPINFO ppai);

		/// <summary>Cancels the installation of an application published by an application publisher.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is called in each of the following circumstances.</para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// The user selected the <c>Do Not Add Program</c> option in the <c>Add Later</c> dialog box in <c>Add/Remove Programs</c> in
		/// Control Panel.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The user has selected an installation time later than either the expiration time or the assigned time as specified in the
		/// published application information. In these circumstances, implementations are expected to cancel any scheduled installation for
		/// the application.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ipublishedapp-unschedule HRESULT Unschedule();
		[PreserveSig]
		new HRESULT Unschedule();

		/// <summary>
		/// Installs an application published by an application publisher, while preventing multiple windows from being active on the same thread.
		/// </summary>
		/// <param name="pstInstall">
		/// <para>Type: <c>LPSYSTEMTIME</c></para>
		/// <para>A pointer to a SYSTEMTIME structure.</para>
		/// </param>
		/// <param name="hwndParent">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the parent window.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ipublishedapp2-install2 HRESULT Install2( [in]
		// LPSYSTEMTIME pstInstall, [in] HWND hwndParent );
		[PreserveSig]
		unsafe HRESULT Install2([In, Optional] SYSTEMTIME* pstInstall, [In, Optional] HWND* hwndParent);
	}

	/// <summary>
	/// Exposes methods that provide general information about an application to the Add/Remove Programs Application. You cannot use it
	/// outside the Add/Remove Programs application. The information given by this interface includes a list of supported management actions
	/// and whether the application is currently installed.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nn-shappmgr-ishellapp
	[PInvokeData("shappmgr.h", MSDNShortId = "NN:shappmgr.IShellApp")]
	[ComImport, Guid("A3E14960-935F-11D1-B8B8-006008059382"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IShellApp
	{
		/// <summary>Gets general information about an application.</summary>
		/// <param name="pai">A pointer to an APPINFODATA structure that returns the application information.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para><c>Note</c> Add/Remove Programs in the Control Panel sets the cbSize and dwMask members of the APPINFODATA structure.</para>
		/// <para>
		/// Your implementation should validate cbSize by comparing it with the size of APPINFODATA. If cbSize does not equal the size of
		/// <c>APPINFODATA</c>, this method should return a COM error value like E_FAIL.
		/// </para>
		/// <para>
		/// Add/Remove Programs in the Control Panel will set the dwMask member of the APPINFODATA structure to indicate that you should
		/// return AIM_DISPLAYNAME and AIM_SUPPORTURL. For each value that you return in APPINFODATA, you must set the corresponding bit in
		/// dwMask. All other bits should be cleared.
		/// </para>
		/// <para>Examples</para>
		/// <para>Here is a sample of how to use the dwMask bits::</para>
		/// <para>
		/// <code>HRESULT CPubApp::GetAppInfo(APPINFODATA *pData)
		/// {
		///    if (sizeof(APPINFODATA) != pData-&gt;cbSize)
		///       return E_FAIL;
		///    // First save off the mask of requested data items.
		///    const DWORD dwMask = pData-&gt;dwMask;
		///    // Zero-out the mask. Bits will be set as items are obtained.
		///    pData-&gt;dwMask = 0;
		///    // Call an internal function that obtains data and sets
		///    // bits in pData-&gt;dwMask for each item obtained.
		///    return get_app_info_data(pData, dwMask);
		/// }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ishellapp-getappinfo HRESULT GetAppInfo( [out]
		// PAPPINFODATA pai );
		[PreserveSig]
		HRESULT GetAppInfo(ref APPINFODATA pai);

		/// <summary>Gets a bitmask of management actions allowed for an application.</summary>
		/// <param name="pdwActions">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// A pointer to a variable of type <c>DWORD</c> that returns the bitmask of supported actions. The bit flags are described in APPACTIONFLAGS.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>Of the set of APPACTIONFLAGS bitmasks, Add/Remove Programs only recognizes APPACTION_INSTALL and APPACTION_ADDLATER.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ishellapp-getpossibleactions HRESULT GetPossibleActions(
		// [out] DWORD *pdwActions );
		[PreserveSig]
		HRESULT GetPossibleActions(out APPACTIONFLAGS pdwActions);

		/// <summary>
		/// Returns information to the application that originates from a slow source. This method is not applicable to published applications.
		/// </summary>
		/// <param name="psaid">
		/// <para>Type: <c>PSLOWAPPINFO</c></para>
		/// <para>A pointer to a SLOWAPPINFO structure in which to return application information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// Implementations of IPublishedApp should return E_NOTIMPL. This method is used internally by Add/Remove Programs for installed applications.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ishellapp-getslowappinfo HRESULT GetSlowAppInfo( [out]
		// PSLOWAPPINFO psaid );
		[PreserveSig]
		HRESULT GetSlowAppInfo(out SLOWAPPINFO psaid);

		/// <summary>
		/// Returns information to the application that originates from a slow source. Unlike IShellApp::GetSlowAppInfo, this method can
		/// return information that has been cached. This method is not applicable to published applications.
		/// </summary>
		/// <param name="psaid">
		/// <para>Type: <c>PSLOWAPPINFO</c></para>
		/// <para>A pointer to a SLOWAPPINFO structure in which to return application information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// Implementations of IPublishedApp return E_NOTIMPL. This method is used internally by Add/Remove Programs for installed applications.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ishellapp-getcachedslowappinfo HRESULT
		// GetCachedSlowAppInfo( [out] PSLOWAPPINFO psaid );
		[PreserveSig]
		HRESULT GetCachedSlowAppInfo(out SLOWAPPINFO psaid);

		/// <summary>Gets a value indicating whether a specified application is currently installed.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The application is installed.</term>
		/// </item>
		/// <item>
		/// <term><c>S_FALSE</c></term>
		/// <term>The application is not installed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Application publishers should determine if the application is currently installed and return S_OK if so, or S_FALSE if not.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/nf-shappmgr-ishellapp-isinstalled HRESULT IsInstalled();
		[PreserveSig]
		HRESULT IsInstalled();
	}

	/// <summary>
	/// Provides application category information to Add/Remove Programs in Control Panel. The APPCATEGORYINFOLIST structure is used create a
	/// complete list of categories for an application publisher.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmgmt/ns-appmgmt-appcategoryinfo typedef struct _APPCATEGORYINFO { LCID Locale;
	// StrPtrUni pszDescription; GUID AppCategoryId; } APPCATEGORYINFO;
	[PInvokeData("appmgmt.h", MSDNShortId = "NS:appmgmt._APPCATEGORYINFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct APPCATEGORYINFO
	{
		/// <summary>
		/// <para>Type: <c>LCID</c></para>
		/// <para>Unused.</para>
		/// </summary>
		public LCID Locale;

		internal StrPtrUni pszDescription;

		/// <summary>
		/// A string containing the display name of the category. This string displays in the <c>Category</c> list in Add/Remove
		/// Programs.
		/// </summary>
		public string Description
		{
			get => pszDescription.ToString();
			set => pszDescription.Assign(value);
		}

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>A GUID identifying the application category.</para>
		/// </summary>
		public Guid AppCategoryId;
	}

	/// <summary>Provides a list of supported application categories from an application publisher to Add/Remove Programs in Control Panel.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmgmt/ns-appmgmt-appcategoryinfolist typedef struct _APPCATEGORYINFOLIST { DWORD
	// cCategory; APPCATEGORYINFO *pCategoryInfo; } APPCATEGORYINFOLIST;
	[PInvokeData("appmgmt.h", MSDNShortId = "NS:appmgmt._APPCATEGORYINFOLIST")]
	[StructLayout(LayoutKind.Sequential)]
	public struct APPCATEGORYINFOLIST
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A value of type <c>DWORD</c> that specifies the count of APPCATEGORYINFO elements in the array pointed to by <c>pCategoryInfo</c>.</para>
		/// </summary>
		public int cCategory;

		private IntPtr pCategoryInfo;

		/// <summary>An array of APPCATEGORYINFO structures. This array contains all the categories an application publisher supports.</summary>
		public APPCATEGORYINFO[]? CategoryInfo
		{
			readonly get => pCategoryInfo.ToArray<APPCATEGORYINFO>(cCategory);
			set { Free(); pCategoryInfo = value is null ? default : value.MarshalToPtr(Marshal.AllocCoTaskMem, out _); cCategory = value?.Length ?? 0; }
		}

		/// <summary>Releases the memory allocated for <see cref="pCategoryInfo"/>.</summary>
		public void Free()
		{
			if (pCategoryInfo == default) return;
			foreach (var i in CategoryInfo!)
				i.pszDescription.Free();
			Marshal.FreeCoTaskMem(pCategoryInfo);
			pCategoryInfo = default;
		}
	}

	/// <summary>Provides information about a published application to the Add/Remove Programs Control Panel utility.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/ns-shappmgr-appinfodata typedef struct _AppInfoData { DWORD cbSize; DWORD
	// dwMask; StrPtrUni pszDisplayName; StrPtrUni pszVersion; StrPtrUni pszPublisher; StrPtrUni pszProductID; StrPtrUni pszRegisteredOwner; StrPtrUni
	// pszRegisteredCompany; StrPtrUni pszLanguage; StrPtrUni pszSupportUrl; StrPtrUni pszSupportTelephone; StrPtrUni pszHelpLink; StrPtrUni
	// pszInstallLocation; StrPtrUni pszInstallSource; StrPtrUni pszInstallDate; StrPtrUni pszContact; StrPtrUni pszComments; StrPtrUni pszImage; StrPtrUni
	// pszReadmeUrl; StrPtrUni pszUpdateInfoUrl; } APPINFODATA, *PAPPINFODATA;
	[PInvokeData("shappmgr.h", MSDNShortId = "NS:shappmgr._AppInfoData")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct APPINFODATA
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A value of type <c>DWORD</c> that specifies the size of the <c>APPINFODATA</c> data structure. This field is set by the
		/// Add/Remove Program executable code.
		/// </para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A value of type <c>DWORD</c> that specifies the bitmask that indicates which items in the structure are desired or valid.
		/// Implementations of GetAppInfo should inspect this value for bits that are set and attempt to provide values corresponding to
		/// those bits. Implementations should also return with bits set for only those members that are being returned.
		/// </para>
		/// </summary>
		public APPINFODATAFLAGS dwMask;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>
		/// A pointer to a string that contains the application display name. Memory for this string must be allocated using CoTaskMemAlloc
		/// and freed using CoTaskMemFree.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszDisplayName;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszVersion;

		/// <summary/>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszPublisher;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszProductID;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszRegisteredOwner;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszRegisteredCompany;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszLanguage;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>
		/// A URL to support information. This string is displayed as a link with the application name in Control Panel Add/Remove Programs.
		/// Memory for this string must be allocated using CoTaskMemAlloc and freed using CoTaskMemFree.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszSupportUrl;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszSupportTelephone;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszHelpLink;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszInstallLocation;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszInstallSource;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszInstallDate;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszContact;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszComments;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszImage;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszReadmeUrl;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Not applicable to published applications.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszUpdateInfoUrl;
	}

	/// <summary>
	/// Provides information about a published application from an application publisher to <c>Add/Remove Programs</c> in Control Panel.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/ns-shappmgr-pubappinfo typedef struct _PubAppInfo { DWORD cbSize; DWORD
	// dwMask; StrPtrUni pszSource; SYSTEMTIME stAssigned; SYSTEMTIME stPublished; SYSTEMTIME stScheduled; SYSTEMTIME stExpire; } PUBAPPINFO, *PPUBAPPINFO;
	[PInvokeData("shappmgr.h", MSDNShortId = "NS:shappmgr._PubAppInfo")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PUBAPPINFO
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A value of type <c>DWORD</c> that specifies the size of the structure. This member is set by the <c>Add/Remove Programs</c> utility.
		/// </para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A bitmask that indicates which items in the structure are valid. This member can contain one or more PUBAPPINFOFLAGS.</para>
		/// </summary>
		public PUBAPPINFOFLAGS dwMask;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>
		/// A pointer to a string containing the display name of the publisher. This name appears in <c>Add/Remove Programs</c> if duplicate
		/// application names are encountered. The string buffer must be allocated using the Shell task allocator.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszSource;

		/// <summary>
		/// <para>Type: <c>SYSTEMTIME</c></para>
		/// <para>
		/// The time when an application manager schedules the application installation. <c>Add/Remove Programs</c> does not allow the user
		/// to schedule an installation time later than the value in this member. This member is ignored if it describes a time prior to the
		/// current time.
		/// </para>
		/// </summary>
		public SYSTEMTIME stAssigned;

		/// <summary>Type: <c>SYSTEMTIME</c></summary>
		public SYSTEMTIME stPublished;

		/// <summary>
		/// <para>Type: <c>SYSTEMTIME</c></para>
		/// <para>
		/// The installation time that the user sets by clicking <c>Add Later</c>. <c>Add/Remove Programs</c> calls the
		/// IPublishedApp::Install method with the <c>pInstallTime</c> parameter pointing to a SYSTEMTIME structure that contains the time
		/// the user entered. The application publisher maintains this value for installation scheduling. IPublishedApp::GetPublishedAppInfo
		/// returns the scheduled installation time in this member if the scheduled time has not been canceled using IPublishedApp::Unschedule.
		/// </para>
		/// </summary>
		public SYSTEMTIME stScheduled;

		/// <summary>
		/// <para>Type: <c>SYSTEMTIME</c></para>
		/// <para>The time after which you cannot install the published application using <c>Add/Remove Programs</c>.</para>
		/// </summary>
		public SYSTEMTIME stExpire;
	}

	/// <summary>
	/// Provides specialized application information to <c>Add/Remove Programs</c> in Control Panel. This structure is not applicable to
	/// published applications.
	/// </summary>
	/// <remarks>
	/// This structure is used by the IShellApp::GetSlowAppInfo and IShellApp::GetCachedSlowAppInfo interfaces, neither of which are
	/// applicable to published applications. Therefore, this structure is also not applicable to published applications.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shappmgr/ns-shappmgr-slowappinfo typedef struct _tagSlowAppInfo { ULONGLONG
	// ullSize; FILETIME ftLastUsed; int iTimesUsed; StrPtrUni pszImage; } SLOWAPPINFO, *PSLOWAPPINFO;
	[PInvokeData("shappmgr.h", MSDNShortId = "NS:shappmgr._tagSlowAppInfo")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SLOWAPPINFO
	{
		/// <summary>
		/// <para>Type: <c>ULONGLONG</c></para>
		/// <para>The size of the application in bytes.</para>
		/// </summary>
		public ulong ullSize;

		/// <summary>
		/// <para>Type: <c>FILETIME</c></para>
		/// <para>The time the application was last used.</para>
		/// </summary>
		public FILETIME ftLastUsed;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The count of times the application has been used.</para>
		/// </summary>
		public int iTimesUsed;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>
		/// A pointer to a string containing the path to the image that represents the application. The string buffer must be allocated using
		/// CoTaskMemAlloc and freed using CoTaskMemFree.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszImage;
	}
}