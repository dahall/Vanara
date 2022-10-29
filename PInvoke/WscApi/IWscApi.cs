#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class WscApi
{
	public enum SECURITY_PRODUCT_TYPE
	{
		SECURITY_PRODUCT_TYPE_ANTIVIRUS = 0,
		SECURITY_PRODUCT_TYPE_FIREWALL = 1,
		SECURITY_PRODUCT_TYPE_ANTISPYWARE = 2
	}

	/// <summary>Defines the current state of the security product that is made available to Windows Security Center.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/ne-iwscapi-wsc_security_product_state typedef enum
	// WSC_SECURITY_PRODUCT_STATE { WSC_SECURITY_PRODUCT_STATE_ON = 0, WSC_SECURITY_PRODUCT_STATE_OFF = 1, WSC_SECURITY_PRODUCT_STATE_SNOOZED
	// = 2, WSC_SECURITY_PRODUCT_STATE_EXPIRED = 3 } ;
	[PInvokeData("iwscapi.h", MSDNShortId = "NE:iwscapi.WSC_SECURITY_PRODUCT_STATE")]
	public enum WSC_SECURITY_PRODUCT_STATE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The security product software is turned on and protecting the user.</para>
		/// </summary>
		WSC_SECURITY_PRODUCT_STATE_ON,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The security product software is turned off and protection is disabled.</para>
		/// </summary>
		WSC_SECURITY_PRODUCT_STATE_OFF,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The security product software is in the snoozed state, temporarily off, and not actively protecting the computer.</para>
		/// </summary>
		WSC_SECURITY_PRODUCT_STATE_SNOOZED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The security product software has expired and is no longer actively protecting the computer.</para>
		/// </summary>
		WSC_SECURITY_PRODUCT_STATE_EXPIRED,
	}

	public enum WSC_SECURITY_PRODUCT_SUBSTATUS
	{
		WSC_SECURITY_PRODUCT_SUBSTATUS_NOT_SET = 0,
		WSC_SECURITY_PRODUCT_SUBSTATUS_NO_ACTION = 1,
		WSC_SECURITY_PRODUCT_SUBSTATUS_ACTION_RECOMMENDED = 2,
		WSC_SECURITY_PRODUCT_SUBSTATUS_ACTION_NEEDED = 3
	}

	/// <summary>Reports the current version status of the security product to Windows Security Center.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/ne-iwscapi-wsc_security_signature_status typedef enum
	// _WSC_SECURITY_SIGNATURE_STATUS { WSC_SECURITY_PRODUCT_OUT_OF_DATE = 0, WSC_SECURITY_PRODUCT_UP_TO_DATE = 1 } WSC_SECURITY_SIGNATURE_STATUS;
	[PInvokeData("iwscapi.h", MSDNShortId = "NE:iwscapi._WSC_SECURITY_SIGNATURE_STATUS")]
	public enum WSC_SECURITY_SIGNATURE_STATUS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The security software reports that it is not the most recent version.</para>
		/// </summary>
		WSC_SECURITY_PRODUCT_OUT_OF_DATE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The security software reports that it is the most recent version.</para>
		/// </summary>
		WSC_SECURITY_PRODUCT_UP_TO_DATE,
	}

	[PInvokeData("iwscapi.h")]
	[ComImport, Guid("0476d69c-f21a-11e5-9ce9-5e5517507c66"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(WSCDefaultProduct))]
	public interface IWSCDefaultProduct
	{
		[PreserveSig]
		HRESULT SetDefaultProduct(SECURITY_PRODUCT_TYPE eType, [MarshalAs(UnmanagedType.BStr)] string pGuid);
	}

	/// <summary>Provides methods for getting product information for an individual provider to interact with Windows Security Center.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nn-iwscapi-iwscproduct
	[PInvokeData("iwscapi.h", MSDNShortId = "NN:iwscapi.IWscProduct")]
	[ComImport, Guid("8C38232E-3A45-4A27-92B0-1A16A975F669"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IWscProduct
	{
		/// <summary>Returns the current product information for the security product.</summary>
		/// <value>A pointer to the name of the security product. This is displayed in the Windows Security Center user interface.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproduct-get_productname HRESULT get_ProductName( [out]
		// BSTR *pVal );
		string ProductName
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Returns the current state of the signature data for the security product.</summary>
		/// <value>A pointer to the state value of the signature of the security product.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproduct-get_productstate HRESULT get_ProductState(
		// [out] WSC_SECURITY_PRODUCT_STATE *pVal );
		WSC_SECURITY_PRODUCT_STATE ProductState { get; }

		/// <summary>Returns the current status of the signature data for the security product.</summary>
		/// <value>
		/// A pointer to the status value of the signature of the security product. If the security product is a Firewall product, the return
		/// value is always <c>WSC_SECURITY_PRODUCT_UP_TO_DATE</c> because firewalls do not contain signature data.
		/// </value>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproduct-get_signaturestatus HRESULT
		// get_SignatureStatus( [out] WSC_SECURITY_SIGNATURE_STATUS *pVal );
		WSC_SECURITY_SIGNATURE_STATUS SignatureStatus { get; }

		/// <summary>Returns the current remediation path for the security product.</summary>
		/// <value>A pointer to the remediation path for the security product. This is displayed in the Windows Security Center user interface.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproduct-get_remediationpath HRESULT
		// get_RemediationPath( [out] BSTR *pVal );
		string RemediationPath
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Returns the current time stamp for the security product.</summary>
		/// <returns>A pointer to the time stamp of the security product. This is displayed in the Windows Security Center user interface.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproduct-get_productstatetimestamp HRESULT
		// get_ProductStateTimestamp( [out] BSTR *pVal );
		string ProductStateTimestamp
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the product unique identifier.</summary>
		/// <value>The product unique identifier.</value>
		string ProductGuid
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets a value indicating whether [product is default].</summary>
		/// <value><see langword="true"/> if [product is default]; otherwise, <see langword="false"/>.</value>
		bool ProductIsDefault
		{
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}
	}

	[PInvokeData("iwscapi.h")]
	[ComImport, Guid("F896CA54-FE09-4403-86D4-23CB488D81D8"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IWscProduct2 : IWscProduct
	{
		/// <summary>Returns the current product information for the security product.</summary>
		/// <value>A pointer to the name of the security product. This is displayed in the Windows Security Center user interface.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproduct-get_productname HRESULT get_ProductName( [out]
		// BSTR *pVal );
		new string ProductName
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Returns the current state of the signature data for the security product.</summary>
		/// <value>A pointer to the state value of the signature of the security product.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproduct-get_productstate HRESULT get_ProductState(
		// [out] WSC_SECURITY_PRODUCT_STATE *pVal );
		new WSC_SECURITY_PRODUCT_STATE ProductState { get; }

		/// <summary>Returns the current status of the signature data for the security product.</summary>
		/// <value>
		/// A pointer to the status value of the signature of the security product. If the security product is a Firewall product, the return
		/// value is always <c>WSC_SECURITY_PRODUCT_UP_TO_DATE</c> because firewalls do not contain signature data.
		/// </value>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproduct-get_signaturestatus HRESULT
		// get_SignatureStatus( [out] WSC_SECURITY_SIGNATURE_STATUS *pVal );
		new WSC_SECURITY_SIGNATURE_STATUS SignatureStatus { get; }

		/// <summary>Returns the current remediation path for the security product.</summary>
		/// <value>A pointer to the remediation path for the security product. This is displayed in the Windows Security Center user interface.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproduct-get_remediationpath HRESULT
		// get_RemediationPath( [out] BSTR *pVal );
		new string RemediationPath
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Returns the current time stamp for the security product.</summary>
		/// <returns>A pointer to the time stamp of the security product. This is displayed in the Windows Security Center user interface.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproduct-get_productstatetimestamp HRESULT
		// get_ProductStateTimestamp( [out] BSTR *pVal );
		new string ProductStateTimestamp
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the product unique identifier.</summary>
		/// <value>The product unique identifier.</value>
		new string ProductGuid
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets a value indicating whether [product is default].</summary>
		/// <value><see langword="true"/> if [product is default]; otherwise, <see langword="false"/>.</value>
		new bool ProductIsDefault
		{
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		WSC_SECURITY_PRODUCT_SUBSTATUS AntivirusScanSubstatus { get; }
		WSC_SECURITY_PRODUCT_SUBSTATUS AntivirusSettingsSubstatus { get; }
		WSC_SECURITY_PRODUCT_SUBSTATUS AntivirusProtectionUpdateSubstatus { get; }
		WSC_SECURITY_PRODUCT_SUBSTATUS FirewallDomainProfileSubstatus { get; }
		WSC_SECURITY_PRODUCT_SUBSTATUS FirewallPrivateProfileSubstatus { get; }
		WSC_SECURITY_PRODUCT_SUBSTATUS FirewallPublicProfileSubstatus { get; }
	}

	[PInvokeData("iwscapi.h")]
	[ComImport, Guid("55536524-D1D1-4726-8C7C-04996A1904E7"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IWscProduct3 : IWscProduct2
	{
		/// <summary>Returns the current product information for the security product.</summary>
		/// <value>A pointer to the name of the security product. This is displayed in the Windows Security Center user interface.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproduct-get_productname HRESULT get_ProductName( [out]
		// BSTR *pVal );
		new string ProductName
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Returns the current state of the signature data for the security product.</summary>
		/// <value>A pointer to the state value of the signature of the security product.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproduct-get_productstate HRESULT get_ProductState(
		// [out] WSC_SECURITY_PRODUCT_STATE *pVal );
		new WSC_SECURITY_PRODUCT_STATE ProductState { get; }

		/// <summary>Returns the current status of the signature data for the security product.</summary>
		/// <value>
		/// A pointer to the status value of the signature of the security product. If the security product is a Firewall product, the return
		/// value is always <c>WSC_SECURITY_PRODUCT_UP_TO_DATE</c> because firewalls do not contain signature data.
		/// </value>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproduct-get_signaturestatus HRESULT
		// get_SignatureStatus( [out] WSC_SECURITY_SIGNATURE_STATUS *pVal );
		new WSC_SECURITY_SIGNATURE_STATUS SignatureStatus { get; }

		/// <summary>Returns the current remediation path for the security product.</summary>
		/// <value>A pointer to the remediation path for the security product. This is displayed in the Windows Security Center user interface.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproduct-get_remediationpath HRESULT
		// get_RemediationPath( [out] BSTR *pVal );
		new string RemediationPath
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Returns the current time stamp for the security product.</summary>
		/// <returns>A pointer to the time stamp of the security product. This is displayed in the Windows Security Center user interface.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproduct-get_productstatetimestamp HRESULT
		// get_ProductStateTimestamp( [out] BSTR *pVal );
		new string ProductStateTimestamp
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets the product unique identifier.</summary>
		/// <value>The product unique identifier.</value>
		new string ProductGuid
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets a value indicating whether [product is default].</summary>
		/// <value><see langword="true"/> if [product is default]; otherwise, <see langword="false"/>.</value>
		new bool ProductIsDefault
		{
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
		}

		new WSC_SECURITY_PRODUCT_SUBSTATUS AntivirusScanSubstatus { get; }
		new WSC_SECURITY_PRODUCT_SUBSTATUS AntivirusSettingsSubstatus { get; }
		new WSC_SECURITY_PRODUCT_SUBSTATUS AntivirusProtectionUpdateSubstatus { get; }
		new WSC_SECURITY_PRODUCT_SUBSTATUS FirewallDomainProfileSubstatus { get; }
		new WSC_SECURITY_PRODUCT_SUBSTATUS FirewallPrivateProfileSubstatus { get; }
		new WSC_SECURITY_PRODUCT_SUBSTATUS FirewallPublicProfileSubstatus { get; }

		uint AntivirusDaysUntilExpired { get; }
	}

	/// <summary>Provides methods to collect product information for the selected type of providers installed on the computer.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nn-iwscapi-iwscproductlist
	[PInvokeData("iwscapi.h", MSDNShortId = "NN:iwscapi.IWSCProductList")]
	[ComImport, Guid("722A338C-6E8E-4E72-AC27-1417FB0C81C2"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(WSCProductList))]
	public interface IWscProductList
	{
		/// <summary>Gathers information on all of the providers of the specified type on the computer.</summary>
		/// <param name="provider">
		/// <para>
		/// A value from the WSC_SECURITY_PROVIDER enumeration with the name of the provider as one of the following values. Note that the
		/// possible values can't be combined in a logical OR as they can when used with the WscGetSecurityProviderHealth function.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>WSC_SECURITY_PROVIDER_ANTIVIRUS</c></term>
		/// <term>Antivirus products.</term>
		/// </item>
		/// <item>
		/// <term><c>WSC_SECURITY_PROVIDER_ANTISPYWARE</c></term>
		/// <term>Anti-spyware products.</term>
		/// </item>
		/// <item>
		/// <term><c>WSC_SECURITY_PROVIDER_FIREWALL</c></term>
		/// <term>Firewall products.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the method succeeds, returns S_OK.</para>
		/// <para>If the method fails, returns a Win32 error code.</para>
		/// </returns>
		/// <remarks>
		/// Once the client gets an IWSCProductList pointer, they must call <c>Initialize</c> with a provider type, which gathers information
		/// on all the providers of that type installed on the system. Only one type of provider can be specified when calling
		/// <c>Initialize</c>, and the <c>Initialize</c> method may only be called once for each instance of an <c>IWSCProductList</c>
		/// pointer. After the list has been initialized, the user is free to call Count to obtain the number of providers in the list and
		/// Item to retrieve an individual provider.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproductlist-initialize HRESULT Initialize( [in] ULONG
		// provider );
		void Initialize(WSC_SECURITY_PROVIDER provider);

		/// <summary>Gathers the total number of all security product providers of the specified type on the computer.</summary>
		/// <value>The number of providers in the list of security products on the computer.</value>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproductlist-get_count HRESULT get_Count( [out] LONG
		// *pVal );
		int Count { get; }

		/// <summary>Returns one of the types of providers on the computer.</summary>
		/// <param name="index">The list of the providers.</param>
		/// <returns>A pointer to the IWscProduct product information.</returns>
		/// <remarks>
		/// A provider is obtained by calling the <c>Item</c> method, which returns an interface pointer to an initialized IWscProduct
		/// object. The user is then able to retrieve the name, product state, and signature status through the methods of the
		/// <c>IWscProduct</c> interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/iwscapi/nf-iwscapi-iwscproductlist-get_item HRESULT get_Item( [in] ULONG
		// index, [out] IWscProduct **pVal );
		IWscProduct this[uint index] { get; }
	}

	/// <summary>CLSID_WSCDefaultProduct</summary>
	[ComImport, Guid("2981a36e-f22d-11e5-9ce9-5e5517507c66"), ClassInterface(ClassInterfaceType.None)]
	public class WSCDefaultProduct { }

	/// <summary>CLSID_WSCProductList</summary>
	[ComImport, Guid("17072F7B-9ABE-4A74-A261-1EB76B55107A"), ClassInterface(ClassInterfaceType.None)]
	public class WSCProductList { }
}