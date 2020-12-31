using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	/// <summary>Items from the Msi.dll</summary>
	public static partial class Msi
	{
		private const string Lib_Msi = "Msi.dll";

		private const int MAX_GUID_CHARS = 38;

		/// <summary>Flags used by <c>MsiEnumProductsEx</c>.</summary>
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumProductsExA")]
		[Flags]
		public enum MSIINSTALLCONTEXT : uint
		{
			/// <summary>
			/// Enumeration extended to all per–user–managed installations for the users specified by szUserSid. An invalid SID returns no items.
			/// </summary>
			MSIINSTALLCONTEXT_USERMANAGED = 1,

			/// <summary>
			/// Enumeration extended to all per–user–unmanaged installations for the users specified by szUserSid. An invalid SID returns no items.
			/// </summary>
			MSIINSTALLCONTEXT_USERUNMANAGED = 2,

			/// <summary>
			/// Enumeration extended to all per-machine installations. When dwInstallContext is set to MSIINSTALLCONTEXT_MACHINE only, the
			/// szUserSID parameter must be NULL.
			/// </summary>
			MSIINSTALLCONTEXT_MACHINE = 4,

			/// <summary>All contexts. OR of all valid values</summary>
			MSIINSTALLCONTEXT_ALL = MSIINSTALLCONTEXT_USERMANAGED | MSIINSTALLCONTEXT_USERUNMANAGED | MSIINSTALLCONTEXT_MACHINE,

			/// <summary>All user-managed contexts.</summary>
			MSIINSTALLCONTEXT_ALLUSERMANAGED = 8,
		}

		/// <summary>
		/// The <c>MsiEnumProductsEx</c> function enumerates through one or all the instances of products that are currently advertised or
		/// installed in the specified contexts. This function supersedes MsiEnumProducts.
		/// </summary>
		/// <param name="szProductCode">
		/// ProductCode GUID of the product to be enumerated. Only instances of products within the scope of the context specified by the
		/// szUserSid and dwContext parameters are enumerated. This parameter can be set to <c>NULL</c> to enumerate all products in the
		/// specified context.
		/// </param>
		/// <param name="szUserSid">
		/// <para>
		/// Null-terminated string that specifies a security identifier (SID) that restricts the context of enumeration. The special SID
		/// string s-1-1-0 (Everyone) specifies enumeration across all users in the system. A SID value other than s-1-1-0 is considered a
		/// user-SID and restricts enumeration to the current user or any user in the system. This parameter can be set to <c>NULL</c> to
		/// restrict the enumeration scope to the current user.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>SID type</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NULL</term>
		/// <term>Specifies the currently logged-on user.</term>
		/// </item>
		/// <item>
		/// <term>User SID</term>
		/// <term>Specifies enumeration for a particular user in the system. An example of user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
		/// </item>
		/// <item>
		/// <term>s-1-1-0</term>
		/// <term>Specifies enumeration across all users in the system.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The special SID string s-1-5-18 (System) cannot be used to enumerate products or patches installed as per-machine.
		/// When dwContext is set to MSIINSTALLCONTEXT_MACHINE only, szUserSid must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwContext">
		/// <para>
		/// Restricts the enumeration to a context. This parameter can be any one or a combination of the values shown in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Context</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
		/// <term>
		/// Enumeration extended to all per–user–managed installations for the users specified by szUserSid. An invalid SID returns no items.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
		/// <term>
		/// Enumeration extended to all per–user–unmanaged installations for the users specified by szUserSid. An invalid SID returns no items.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_MACHINE</term>
		/// <term>
		/// Enumeration extended to all per-machine installations. When dwInstallContext is set to MSIINSTALLCONTEXT_MACHINE only, the
		/// szUserSID parameter must be NULL.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwIndex">
		/// Specifies the index of the product to retrieve. This parameter must be zero for the first call to the <c>MsiEnumProductsEx</c>
		/// function and then incremented for subsequent calls. The index should be incremented, only if the previous call has returned
		/// ERROR_SUCCESS. Because products are not ordered, any new product has an arbitrary index. This means that the function can return
		/// products in any order.
		/// </param>
		/// <param name="szInstalledProductCode">
		/// Null-terminated string of <c>TCHAR</c> that gives the ProductCode GUID of the product instance being enumerated. This parameter
		/// can be <c>NULL</c>.
		/// </param>
		/// <param name="pdwInstalledContext">
		/// Returns the context of the product instance being enumerated. The output value can be MSIINSTALLCONTEXT_USERMANAGED,
		/// MSIINSTALLCONTEXT_USERUNMANAGED, or MSIINSTALLCONTEXT_MACHINE. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="szSid">
		/// <para>
		/// An output buffer that receives the string SID of the account under which this product instance exists. This buffer returns an
		/// empty string for an instance installed in a per-machine context.
		/// </para>
		/// <para>
		/// This buffer should be large enough to contain the SID. If the buffer is too small, the function returns ERROR_MORE_DATA and sets
		/// *pcchSid to the number of <c>TCHAR</c> in the SID, not including the terminating NULL character.
		/// </para>
		/// <para>
		/// If szSid is set to <c>NULL</c> and pcchSid is set to a valid pointer, the function returns ERROR_SUCCESS and sets *pcchSid to
		/// the number of <c>TCHAR</c> in the value, not including the terminating <c>NULL</c>. The function can then be called again to
		/// retrieve the value, with the szSid buffer large enough to contain *pcchSid + 1 characters.
		/// </para>
		/// <para>
		/// If szSid and pcchSid are both set to <c>NULL</c>, the function returns ERROR_SUCCESS if the value exists, without retrieving the value.
		/// </para>
		/// </param>
		/// <param name="pcchSid">
		/// <para>
		/// When calling the function, this parameter should be a pointer to a variable that specifies the number of <c>TCHAR</c> in the
		/// szSid buffer. When the function returns, this parameter is set to the size of the requested value whether or not the function
		/// copies the value into the specified buffer. The size is returned as the number of <c>TCHAR</c> in the requested value, not
		/// including the terminating null character.
		/// </para>
		/// <para>This parameter can be set to <c>NULL</c> only if szSid is also <c>NULL</c>, otherwise the function returns ERROR_INVALID_PARAMETER.</para>
		/// </param>
		/// <returns>
		/// <para>The <c>MsiEnumProductsEx</c> function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>If the scope includes users other than the current user, you need administrator privileges.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_CONFIGURATION</term>
		/// <term>The configuration data is corrupt.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid parameter was passed to the function.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_MORE_ITEMS</term>
		/// <term>There are no more products to enumerate.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>A product is enumerated.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>The szSid parameter is too small to get the user SID.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNKNOWN_PRODUCT</term>
		/// <term>The product is not installed on the computer in the specified context.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FUNCTION_FAILED</term>
		/// <term>An unexpected internal failure.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To enumerate products, an application must initially call the <c>MsiEnumProductsEx</c> function with the iIndex parameter set to
		/// zero. The application must then increment the iProductIndex parameter and call <c>MsiEnumProductsEx</c> until it returns
		/// <c>ERROR_NO_MORE_ITEMS</c> and there are no more products to enumerate.
		/// </para>
		/// <para>
		/// When making multiple calls to <c>MsiEnumProductsEx</c> to enumerate all of the products, each call must be made from the same thread.
		/// </para>
		/// <para>
		/// A user must have administrator privileges to enumerate products across all user accounts or a user account other than the
		/// current user account. The enumeration skips products that are advertised only (such as products not installed) in the
		/// per-user-unmanaged context when enumerating across all users or a user other than the current user.
		/// </para>
		/// <para>Use MsiGetProductInfoEx to get the state or other information about each product instance enumerated by <c>MsiEnumProductsEx</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienumproductsexa UINT MsiEnumProductsExA( LPCSTR szProductCode,
		// LPCSTR szUserSid, DWORD dwContext, DWORD dwIndex, CHAR [39] szInstalledProductCode, MSIINSTALLCONTEXT *pdwInstalledContext, LPSTR
		// szSid, LPDWORD pcchSid );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumProductsExA")]
		public static extern Win32Error MsiEnumProductsEx([Optional, MarshalAs(UnmanagedType.LPTStr)] string szProductCode,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string szUserSid, MSIINSTALLCONTEXT dwContext, uint dwIndex,
			[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szInstalledProductCode,
			out MSIINSTALLCONTEXT pdwInstalledContext, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szSid,
			ref uint pcchSid);

		/// <summary>
		/// The <c>MsiEnumProductsEx</c> function enumerates through one or all the instances of products that are currently advertised or
		/// installed in the specified contexts. This function supersedes MsiEnumProducts.
		/// </summary>
		/// <param name="szProductCode">
		/// ProductCode GUID of the product to be enumerated. Only instances of products within the scope of the context specified by the
		/// szUserSid and dwContext parameters are enumerated. This parameter can be set to <c>NULL</c> to enumerate all products in the
		/// specified context.
		/// </param>
		/// <param name="szUserSid">
		/// <para>
		/// Null-terminated string that specifies a security identifier (SID) that restricts the context of enumeration. The special SID
		/// string s-1-1-0 (Everyone) specifies enumeration across all users in the system. A SID value other than s-1-1-0 is considered a
		/// user-SID and restricts enumeration to the current user or any user in the system. This parameter can be set to <c>NULL</c> to
		/// restrict the enumeration scope to the current user.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>SID type</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NULL</term>
		/// <term>Specifies the currently logged-on user.</term>
		/// </item>
		/// <item>
		/// <term>User SID</term>
		/// <term>Specifies enumeration for a particular user in the system. An example of user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
		/// </item>
		/// <item>
		/// <term>s-1-1-0</term>
		/// <term>Specifies enumeration across all users in the system.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The special SID string s-1-5-18 (System) cannot be used to enumerate products or patches installed as per-machine.
		/// When dwContext is set to MSIINSTALLCONTEXT_MACHINE only, szUserSid must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwContext">
		/// <para>
		/// Restricts the enumeration to a context. This parameter can be any one or a combination of the values shown in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Context</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
		/// <term>
		/// Enumeration extended to all per–user–managed installations for the users specified by szUserSid. An invalid SID returns no items.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
		/// <term>
		/// Enumeration extended to all per–user–unmanaged installations for the users specified by szUserSid. An invalid SID returns no items.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_MACHINE</term>
		/// <term>
		/// Enumeration extended to all per-machine installations. When dwInstallContext is set to MSIINSTALLCONTEXT_MACHINE only, the
		/// szUserSID parameter must be NULL.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwIndex">
		/// Specifies the index of the product to retrieve. This parameter must be zero for the first call to the <c>MsiEnumProductsEx</c>
		/// function and then incremented for subsequent calls. The index should be incremented, only if the previous call has returned
		/// ERROR_SUCCESS. Because products are not ordered, any new product has an arbitrary index. This means that the function can return
		/// products in any order.
		/// </param>
		/// <param name="szInstalledProductCode">
		/// Null-terminated string of <c>TCHAR</c> that gives the ProductCode GUID of the product instance being enumerated. This parameter
		/// can be <c>NULL</c>.
		/// </param>
		/// <param name="pdwInstalledContext">
		/// Returns the context of the product instance being enumerated. The output value can be MSIINSTALLCONTEXT_USERMANAGED,
		/// MSIINSTALLCONTEXT_USERUNMANAGED, or MSIINSTALLCONTEXT_MACHINE. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="szSid">
		/// <para>
		/// An output buffer that receives the string SID of the account under which this product instance exists. This buffer returns an
		/// empty string for an instance installed in a per-machine context.
		/// </para>
		/// <para>
		/// This buffer should be large enough to contain the SID. If the buffer is too small, the function returns ERROR_MORE_DATA and sets
		/// *pcchSid to the number of <c>TCHAR</c> in the SID, not including the terminating NULL character.
		/// </para>
		/// <para>
		/// If szSid is set to <c>NULL</c> and pcchSid is set to a valid pointer, the function returns ERROR_SUCCESS and sets *pcchSid to
		/// the number of <c>TCHAR</c> in the value, not including the terminating <c>NULL</c>. The function can then be called again to
		/// retrieve the value, with the szSid buffer large enough to contain *pcchSid + 1 characters.
		/// </para>
		/// <para>
		/// If szSid and pcchSid are both set to <c>NULL</c>, the function returns ERROR_SUCCESS if the value exists, without retrieving the value.
		/// </para>
		/// </param>
		/// <param name="pcchSid">
		/// <para>
		/// When calling the function, this parameter should be a pointer to a variable that specifies the number of <c>TCHAR</c> in the
		/// szSid buffer. When the function returns, this parameter is set to the size of the requested value whether or not the function
		/// copies the value into the specified buffer. The size is returned as the number of <c>TCHAR</c> in the requested value, not
		/// including the terminating null character.
		/// </para>
		/// <para>This parameter can be set to <c>NULL</c> only if szSid is also <c>NULL</c>, otherwise the function returns ERROR_INVALID_PARAMETER.</para>
		/// </param>
		/// <returns>
		/// <para>The <c>MsiEnumProductsEx</c> function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>If the scope includes users other than the current user, you need administrator privileges.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_CONFIGURATION</term>
		/// <term>The configuration data is corrupt.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid parameter was passed to the function.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_MORE_ITEMS</term>
		/// <term>There are no more products to enumerate.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>A product is enumerated.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>The szSid parameter is too small to get the user SID.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNKNOWN_PRODUCT</term>
		/// <term>The product is not installed on the computer in the specified context.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FUNCTION_FAILED</term>
		/// <term>An unexpected internal failure.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To enumerate products, an application must initially call the <c>MsiEnumProductsEx</c> function with the iIndex parameter set to
		/// zero. The application must then increment the iProductIndex parameter and call <c>MsiEnumProductsEx</c> until it returns
		/// <c>ERROR_NO_MORE_ITEMS</c> and there are no more products to enumerate.
		/// </para>
		/// <para>
		/// When making multiple calls to <c>MsiEnumProductsEx</c> to enumerate all of the products, each call must be made from the same thread.
		/// </para>
		/// <para>
		/// A user must have administrator privileges to enumerate products across all user accounts or a user account other than the
		/// current user account. The enumeration skips products that are advertised only (such as products not installed) in the
		/// per-user-unmanaged context when enumerating across all users or a user other than the current user.
		/// </para>
		/// <para>Use MsiGetProductInfoEx to get the state or other information about each product instance enumerated by <c>MsiEnumProductsEx</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienumproductsexa UINT MsiEnumProductsExA( LPCSTR szProductCode,
		// LPCSTR szUserSid, DWORD dwContext, DWORD dwIndex, CHAR [39] szInstalledProductCode, MSIINSTALLCONTEXT *pdwInstalledContext, LPSTR
		// szSid, LPDWORD pcchSid );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumProductsExA")]
		public static extern Win32Error MsiEnumProductsEx([Optional, MarshalAs(UnmanagedType.LPTStr)] string szProductCode,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string szUserSid, MSIINSTALLCONTEXT dwContext, uint dwIndex,
			[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szInstalledProductCode,
			[Out, Optional] IntPtr pdwInstalledContext, [Out, Optional] IntPtr szSid, [Out, Optional] IntPtr pcchSid);

		/// <summary>
		/// The <c>MsiEnumProductsEx</c> function enumerates through one or all the instances of products that are currently advertised or
		/// installed in the specified contexts. This function supersedes MsiEnumProducts.
		/// </summary>
		/// <param name="szProductCode">
		/// ProductCode GUID of the product to be enumerated. Only instances of products within the scope of the context specified by the
		/// szUserSid and dwContext parameters are enumerated. This parameter can be set to <c>NULL</c> to enumerate all products in the
		/// specified context.
		/// </param>
		/// <param name="szUserSid">
		/// <para>
		/// Null-terminated string that specifies a security identifier (SID) that restricts the context of enumeration. The special SID
		/// string s-1-1-0 (Everyone) specifies enumeration across all users in the system. A SID value other than s-1-1-0 is considered a
		/// user-SID and restricts enumeration to the current user or any user in the system. This parameter can be set to <c>NULL</c> to
		/// restrict the enumeration scope to the current user.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>SID type</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <description>NULL</description>
		/// <description>Specifies the currently logged-on user.</description>
		/// </item>
		/// <item>
		/// <description>User SID</description>
		/// <description>Specifies enumeration for a particular user in the system. An example of user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</description>
		/// </item>
		/// <item>
		/// <description>s-1-1-0</description>
		/// <description>Specifies enumeration across all users in the system.</description>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The special SID string s-1-5-18 (System) cannot be used to enumerate products or patches installed as per-machine.
		/// When dwContext is set to MSIINSTALLCONTEXT_MACHINE only, szUserSid must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwContext">
		/// <para>
		/// Restricts the enumeration to a context. This parameter can be any one or a combination of the values shown in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Context</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <description>MSIINSTALLCONTEXT_USERMANAGED</description>
		/// <description>
		/// Enumeration extended to all per–user–managed installations for the users specified by szUserSid. An invalid SID returns no items.
		/// </description>
		/// </item>
		/// <item>
		/// <description>MSIINSTALLCONTEXT_USERUNMANAGED</description>
		/// <description>
		/// Enumeration extended to all per–user–unmanaged installations for the users specified by szUserSid. An invalid SID returns no items.
		/// </description>
		/// </item>
		/// <item>
		/// <description>MSIINSTALLCONTEXT_MACHINE</description>
		/// <description>
		/// Enumeration extended to all per-machine installations. When dwInstallContext is set to MSIINSTALLCONTEXT_MACHINE only, the
		/// szUserSID parameter must be NULL.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>A sequence of tuples which contain:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>szInstalledProductCode</term>
		/// <description>The string value of the ProductCode GUID of the product instance being enumerated.</description>
		/// </item>
		/// <item>
		/// <term>pdwInstalledContext</term>
		/// <description>The context of the product instance being enumerated.</description>
		/// </item>
		/// <item>
		/// <term>szSid</term>
		/// <description>
		/// The string SID of the account under which this product instance exists or <see langword="null"/> for an instance installed in a
		/// per-machine context.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		public static IEnumerable<(string productCode, MSIINSTALLCONTEXT context, string sidString)> MsiEnumProductsEx(
			[Optional] string szProductCode, string szUserSid = null, MSIINSTALLCONTEXT dwContext = MSIINSTALLCONTEXT.MSIINSTALLCONTEXT_ALL)
		{
			StringBuilder prodCode = new StringBuilder(MAX_GUID_CHARS + 1);
			StringBuilder sid = new StringBuilder(1024);
			for (uint i = 0; true; i++)
			{
				prodCode.Length = 0;
				sid.Length = 0;
				var sidSz = (uint)sid.Capacity;
				var err = MsiEnumProductsEx(szProductCode, szUserSid, dwContext, i, prodCode, out var ctx, sid, ref sidSz);
				if (err == Win32Error.ERROR_MORE_DATA)
				{
					sid.Capacity = (int)sidSz;
					err = MsiEnumProductsEx(szProductCode, szUserSid, dwContext, i, prodCode, out ctx, sid, ref sidSz);
				}
				if (err == Win32Error.ERROR_NO_MORE_ITEMS)
					yield break;
				err.ThrowIfFailed();
				yield return (prodCode.ToString(), ctx, sidSz == 0 ? null : sid.ToString());
			}
		}

		/// <summary>
		/// <para>
		/// The <c>MsiGetProductInfoEx</c> function returns product information for advertised and installed products. This function can
		/// retrieve information
		/// </para>
		/// <para>about an instance of a product that is installed under a user account other than the current user.</para>
		/// <para>
		/// The calling process must have administrative privileges for a user who is different from the current user. The
		/// <c>MsiGetProductInfoEx</c> function cannot query an instance of a product that is advertised under a per-user-unmanaged context
		/// for a user account other than the current user.
		/// </para>
		/// <para>This function is an extension of the MsiGetProductInfo function.</para>
		/// </summary>
		/// <param name="szProductCode">The ProductCode GUID of the product instance that is being queried.</param>
		/// <param name="szUserSid">
		/// <para>
		/// The security identifier (SID) of the account under which the instance of the product that is being queried exists. A <c>NULL</c>
		/// specifies the current user SID.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>SID</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NULL</term>
		/// <term>The currently logged-on user.</term>
		/// </item>
		/// <item>
		/// <term>User SID</term>
		/// <term>The enumeration for a specific user in the system. An example of user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The special SID string "S-1-5-18" (system) cannot be used to enumerate products installed as per-machine. If
		/// dwContext is "MSIINSTALLCONTEXT_MACHINE", szUserSid must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwContext">
		/// <para>The installation context of the product instance that is being queried.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
		/// <term>Retrieves the product property for the per–user–managed instance of the product.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
		/// <term>Retrieves the product property for the per–user–unmanaged instance of the product.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_MACHINE</term>
		/// <term>Retrieves the product property for the per-machine instance of the product.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="szProperty">
		/// <para>Property being queried.</para>
		/// <para>
		/// The property to be retrieved. The properties in the following table can only be retrieved from applications that are already
		/// installed. All required properties are guaranteed to be available, but other properties are available only if the property is
		/// set. For more information, see Required Properties and Properties.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Property</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INSTALLPROPERTY_PRODUCTSTATE</term>
		/// <term>The state of the product returned in string form as "1" for advertised and "5" for installed.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_HELPLINK</term>
		/// <term>The support link. For more information, see the ARPHELPLINK property.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_HELPTELEPHONE</term>
		/// <term>The support telephone. For more information, see the ARPHELPTELEPHONE property.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_INSTALLDATE</term>
		/// <term>
		/// The last time this product received service. The value of this property is replaced each time a patch is applied or removed from
		/// the product or the /v Command-Line Option is used to repair the product. If the product has received no repairs or patches this
		/// property contains the time this product was installed on this computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_INSTALLEDLANGUAGE</term>
		/// <term>Installed language. Windows Installer 4.5 and earlier: Not supported.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_INSTALLEDPRODUCTNAME</term>
		/// <term>The installed product name. For more information, see the ProductName property.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_INSTALLLOCATION</term>
		/// <term>The installation location. For more information, see the ARPINSTALLLOCATION property.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_INSTALLSOURCE</term>
		/// <term>The installation source. For more information, see the SourceDir property.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_LOCALPACKAGE</term>
		/// <term>The local cached package.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_PUBLISHER</term>
		/// <term>The publisher. For more information, see the Manufacturer property.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_URLINFOABOUT</term>
		/// <term>URL information. For more information, see the ARPURLINFOABOUT property.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_URLUPDATEINFO</term>
		/// <term>The URL update information. For more information, see the ARPURLUPDATEINFO property.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_VERSIONMINOR</term>
		/// <term>The minor product version that is derived from the ProductVersion property.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_VERSIONMAJOR</term>
		/// <term>The major product version that is derived from the ProductVersion property.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_VERSIONSTRING</term>
		/// <term>The product version. For more information, see the ProductVersion property.</term>
		/// </item>
		/// </list>
		/// <para>
		/// To retrieve the product ID, registered owner, or registered company from applications that are installed, set szProperty to one
		/// of the following text string values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ProductID</term>
		/// <term>The product identifier. For more information, see the ProductID property.</term>
		/// </item>
		/// <item>
		/// <term>RegCompany</term>
		/// <term>The company that is registered to use the product.</term>
		/// </item>
		/// <item>
		/// <term>RegOwner</term>
		/// <term>The owner who is registered to use the product.</term>
		/// </item>
		/// </list>
		/// <para>
		/// To retrieve the instance type of the product, set szProperty to the following value. This property is available for advertised
		/// or installed products.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>InstanceType</term>
		/// <term>
		/// A missing value or a value of 0 (zero) indicates a normal product installation. A value of one (1) indicates a product installed
		/// using a multiple instance transform and the MSINEWINSTANCE property. For more information, see Installing Multiple Instances of
		/// Products and Patches.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The properties in the following table can be retrieved from applications that are advertised or installed. These properties
		/// cannot be retrieved for product instances that are installed under a per-user-unmanaged context for user accounts other than
		/// current user account.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Property</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>INSTALLPROPERTY_TRANSFORMS</term>
		/// <term>Transforms.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_LANGUAGE</term>
		/// <term>Product language.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_PRODUCTNAME</term>
		/// <term>Human readable product name. For more information, see the ProductName property.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_ASSIGNMENTTYPE</term>
		/// <term>
		/// Equals 0 (zero) if the product is advertised or installed per-user. Equals one (1) if the product is advertised or installed
		/// per-computer for all users.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_PACKAGECODE</term>
		/// <term>Identifier of the package that a product is installed from. For more information, see the Package Codes property.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_VERSION</term>
		/// <term>Product version derived from the ProductVersion property.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_PRODUCTICON</term>
		/// <term>Primary icon for the package. For more information, see the ARPPRODUCTICON property.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_PACKAGENAME</term>
		/// <term>Name of the original installation package.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLPROPERTY_AUTHORIZED_LUA_APP</term>
		/// <term>
		/// A value of one (1) indicates a product that can be serviced by non-administrators using User Account Control (UAC) Patching. A
		/// missing value or a value of 0 (zero) indicates that least-privilege patching is not enabled. Available in Windows Installer 3.0
		/// or later.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="szValue">
		/// <para>
		/// A pointer to a buffer that receives the property value. This buffer should be large enough to contain the information. If the
		/// buffer is too small, the function returns <c>ERROR_MORE_DATA</c> and sets *pcchValue to the number of <c>TCHAR</c> in the value,
		/// not including the terminating NULL character.
		/// </para>
		/// <para>
		/// If lpValue is set to <c>NULL</c> and pcchValue is set to a valid pointer, the function returns <c>ERROR_SUCCESS</c> and sets
		/// *pcchValue to the number of <c>TCHAR</c> in the value, not including the terminating NULL character. The function can then be
		/// called again to retrieve the value, with lpValue buffer large enough to contain *pcchValue + 1 characters.
		/// </para>
		/// <para>
		/// If lpValue and pcchValue are both set to <c>NULL</c>, the function returns <c>ERROR_SUCCESS</c> if the value exists, without
		/// retrieving the value.
		/// </para>
		/// </param>
		/// <param name="pcchValue">
		/// <para>
		/// A pointer to a variable that specifies the number of <c>TCHAR</c> in the lpValue buffer. When the function returns, this
		/// parameter is set to the size of the requested value whether or not the function copies the value into the specified buffer. The
		/// size is returned as the number of <c>TCHAR</c> in the requested value, not including the terminating null character.
		/// </para>
		/// <para>This parameter can be set to <c>NULL</c> only if lpValue is also <c>NULL</c>. Otherwise, the function returns <c>ERROR_INVALID_PARAMETER</c>.</para>
		/// </param>
		/// <returns>
		/// <para>The <c>MsiGetProductInfoEx</c> function returns the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// The calling process must have administrative privileges to get information for a product installed for a user other than the
		/// current user.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_CONFIGURATION</term>
		/// <term>The configuration data is corrupt.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid parameter is passed to the function.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>A buffer is too small to hold the requested data.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNKNOWN_PRODUCT</term>
		/// <term>The product is unadvertised or uninstalled.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNKNOWN_PROPERTY</term>
		/// <term>The property is unrecognized.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FUNCTION_FAILED</term>
		/// <term>An unexpected internal failure.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When the <c>MsiGetProductInfoEx</c> function returns, the pcchValue parameter contains the length of the string that is stored
		/// in the buffer. The count returned does not include the terminating null character. If the buffer is not big enough,
		/// <c>MsiGetProductInfoEx</c> returns <c>ERROR_MORE_DATA</c>, and the pcchValue parameter contains the size of the string, in
		/// <c>TCHAR</c>, without counting the null character.
		/// </para>
		/// <para>
		/// The <c>MsiGetProductInfoEx</c> function ( <c>INSTALLPROPERTY_LOCALPACKAGE</c>) returns a path to the cached package. The cached
		/// package is for internal use only. Maintenance mode installations must be invoked through the MsiConfigureFeature,
		/// MsiConfigureProduct, or MsiConfigureProductEx functions.
		/// </para>
		/// <para>
		/// The MsiGetProductInfo function returns <c>ERROR_UNKNOWN_PROPERTY</c> if the application being queried is advertised and not
		/// installed. For example, if the application is advertised and not installed, a query for <c>INSTALLPROPERTY_INSTALLLOCATION</c>
		/// returns an error of <c>ERROR_UNKNOWN_PROPERTY</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetproductinfoexa UINT MsiGetProductInfoExA( LPCSTR
		// szProductCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, LPCSTR szProperty, LPSTR szValue, LPDWORD pcchValue );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetProductInfoExA")]
		public static extern Win32Error MsiGetProductInfoEx([MarshalAs(UnmanagedType.LPTStr)] string szProductCode,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string szUserSid, MSIINSTALLCONTEXT dwContext, [MarshalAs(UnmanagedType.LPTStr)] string szProperty,
			[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szValue, ref uint pcchValue);

		/// <summary>The <c>MsiInstallProduct</c> function installs or uninstalls a product.</summary>
		/// <param name="szPackagePath">
		/// A null-terminated string that specifies the path to the location of the Windows Installer package. The string value can contain
		/// a URL (e.g. <c>http://packageLocation/package/package.msi</c>), a network path (e.g. \packageLocation\package.msi), a file path
		/// (e.g. file://packageLocation/package.msi), or a local path (e.g. D:\packageLocation\package.msi).
		/// </param>
		/// <param name="szCommandLine">
		/// <para>
		/// A null-terminated string that specifies the command line property settings. This should be a list of the format Property=Setting
		/// Property=Setting. For more information, see About Properties.
		/// </para>
		/// <para>
		/// To perform an administrative installation, include ACTION=ADMIN in szCommandLine. For more information, see the ACTION property.
		/// </para>
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function completes successfully.</term>
		/// </item>
		/// <item>
		/// <term>An error relating to an action</term>
		/// <term>For more information, see Error Codes.</term>
		/// </item>
		/// <item>
		/// <term>Initialization Error</term>
		/// <term>An error that relates to initialization occurred.</term>
		/// </item>
		/// </list>
		/// <para>For more information, see Displayed Error Messages.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>MsiInstallProduct</c> function displays the user interface with the current settings and log mode.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>You can change user interface settings by using the MsiSetInternalUI, MsiSetExternalUI, or MsiSetExternalUIRecord functions.</term>
		/// </item>
		/// <item>
		/// <term>You can set the log mode by using the MsiEnableLog function.</term>
		/// </item>
		/// <item>
		/// <term>You can completely remove a product by setting REMOVE=ALL in szCommandLine.</term>
		/// </item>
		/// </list>
		/// <para>For more information, see REMOVE Property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiinstallproducta UINT MsiInstallProductA( LPCSTR szPackagePath,
		// LPCSTR szCommandLine );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiInstallProductA")]
		public static extern Win32Error MsiInstallProduct([MarshalAs(UnmanagedType.LPTStr)] string szPackagePath, [Optional, MarshalAs(UnmanagedType.LPTStr)] string szCommandLine);

		/// <summary>
		/// <para>
		/// The <c>MsiIsProductElevated</c> function returns whether or not the product is managed. Only applications that require elevated
		/// privileges for installation and being installed through advertisement are considered managed, which means that an application
		/// installed per-machine is always considered managed.
		/// </para>
		/// <para>
		/// An application that is installed per-user is only considered managed if it is advertised by a local system process that is
		/// impersonating the user. For more information, see Advertising a Per-User Application to be Installed with Elevated Privileges.
		/// </para>
		/// <para>
		/// <c>MsiIsProductElevated</c> verifies that the local system owns the product registry data. The function does not refer to
		/// account policies such as AlwaysInstallElevated.
		/// </para>
		/// </summary>
		/// <param name="szProduct">
		/// <para>The full product code GUID of the product.</para>
		/// <para>This parameter is required and cannot be <c>NULL</c> or empty.</para>
		/// </param>
		/// <param name="pfElevated">
		/// <para>A pointer to a BOOL for the result.</para>
		/// <para>This parameter cannot be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is ERROR_SUCCESS, and pfElevated is set to <c>TRUE</c> if the product is a managed application.
		/// </para>
		/// <para>If the function fails, the return value is one of the error codes identified in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_UNKNOWN_PRODUCT</term>
		/// <term>The product is not currently known.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid argument is passed to the function.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_CONFIGURATION</term>
		/// <term>The configuration information for the product is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FUNCTION_FAILED</term>
		/// <term>The function failed.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
		/// <term>The function is not available for a specific platform.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks/>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiisproductelevatedw UINT MsiIsProductElevatedW( LPCWSTR
		// szProduct, BOOL *pfElevated );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiIsProductElevatedW")]
		public static extern Win32Error MsiIsProductElevated([MarshalAs(UnmanagedType.LPTStr)] string szProduct, [MarshalAs(UnmanagedType.Bool)] out bool pfElevated);

		/// <summary>Known installation properties.</summary>
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetProductInfoExA")]
		public static class INSTALLPROPERTY
		{
			/// <summary>
			/// Equals 0 (zero) if the product is advertised or installed per-user. Equals one(1) if the product is advertised or installed
			/// per-computer for all users.
			/// </summary>
			public const string INSTALLPROPERTY_ASSIGNMENTTYPE = "AssignmentType";

			/// <summary>
			/// A value of one (1) indicates a product that can be serviced by non-administrators using User Account Control (UAC) Patching.
			/// A missing value or a value of 0 (zero) indicates that least-privilege patching is not enabled. Available in Windows
			/// Installer 3.0 or later.
			/// </summary>
			public const string INSTALLPROPERTY_AUTHORIZED_LUA_APP = "AuthorizedLUAApp";

			/// <summary></summary>
			public const string INSTALLPROPERTY_DISKPROMPT = "DiskPrompt";

			/// <summary></summary>
			public const string INSTALLPROPERTY_DISPLAYNAME = "DisplayName";

			/// <summary>The support link. For more information, see the ARPHELPLINK property.</summary>
			public const string INSTALLPROPERTY_HELPLINK = "HelpLink";

			/// <summary>The support telephone. For more information, see the ARPHELPTELEPHONE property.</summary>
			public const string INSTALLPROPERTY_HELPTELEPHONE = "HelpTelephone";

			/// <summary>
			/// The last time this product received service. The value of this property is replaced each time a patch is applied or removed
			/// from the product or the /v Command-Line Option is used to repair the product. If the product has received no repairs or
			/// patches this property contains the time this product was installed on this computer.
			/// </summary>
			public const string INSTALLPROPERTY_INSTALLDATE = "InstallDate";

			/// <summary>Installed language. Windows Installer 4.5 and earlier: Not supported.</summary>
			public const string INSTALLPROPERTY_INSTALLEDLANGUAGE = "InstalledLanguage";

			/// <summary>The installed product name. For more information, see the ProductName property.</summary>
			public const string INSTALLPROPERTY_INSTALLEDPRODUCTNAME = "InstalledProductName";

			/// <summary>The installation location. For more information, see the ARPINSTALLLOCATION property.</summary>
			public const string INSTALLPROPERTY_INSTALLLOCATION = "InstallLocation";

			/// <summary>The installation source. For more information, see the SourceDir property.</summary>
			public const string INSTALLPROPERTY_INSTALLSOURCE = "InstallSource";

			/// <summary></summary>
			public const string INSTALLPROPERTY_INSTANCETYPE = "InstanceType";

			/// <summary>Product language.</summary>
			public const string INSTALLPROPERTY_LANGUAGE = "Language";

			/// <summary></summary>
			public const string INSTALLPROPERTY_LASTUSEDSOURCE = "LastUsedSource";

			/// <summary></summary>
			public const string INSTALLPROPERTY_LASTUSEDTYPE = "LastUsedType";

			/// <summary>The local cached package.</summary>
			public const string INSTALLPROPERTY_LOCALPACKAGE = "LocalPackage";

			/// <summary></summary>
			public const string INSTALLPROPERTY_LUAENABLED = "LUAEnabled";

			/// <summary></summary>
			public const string INSTALLPROPERTY_MEDIAPACKAGEPATH = "MediaPackagePath";

			/// <summary></summary>
			public const string INSTALLPROPERTY_MOREINFOURL = "MoreInfoURL";

			/// <summary>Identifier of the package that a product is installed from. For more information, see the Package Codes property.</summary>
			public const string INSTALLPROPERTY_PACKAGECODE = "PackageCode";

			/// <summary>Name of the original installation package.</summary>
			public const string INSTALLPROPERTY_PACKAGENAME = "PackageName";

			/// <summary></summary>
			public const string INSTALLPROPERTY_PATCHSTATE = "State";

			/// <summary></summary>
			public const string INSTALLPROPERTY_PATCHTYPE = "PatchType";

			/// <summary>Primary icon for the package. For more information, see the ARPPRODUCTICON property.</summary>
			public const string INSTALLPROPERTY_PRODUCTICON = "ProductIcon";

			/// <summary>The product identifier. For more information, see the ProductID property.</summary>
			public const string INSTALLPROPERTY_PRODUCTID = "ProductID";

			/// <summary>Human readable product name. For more information, see the ProductName property.</summary>
			public const string INSTALLPROPERTY_PRODUCTNAME = "ProductName";

			/// <summary>The state of the product returned in string form as "1" for advertised and "5" for installed.</summary>
			public const string INSTALLPROPERTY_PRODUCTSTATE = "State";

			/// <summary>The publisher. For more information, see the Manufacturer property.</summary>
			public const string INSTALLPROPERTY_PUBLISHER = "Publisher";

			/// <summary>The company that is registered to use the product.</summary>
			public const string INSTALLPROPERTY_REGCOMPANY = "RegCompany";

			/// <summary>The owner who is registered to use the product.</summary>
			public const string INSTALLPROPERTY_REGOWNER = "RegOwner";

			/// <summary>Transforms.</summary>
			public const string INSTALLPROPERTY_TRANSFORMS = "Transforms";

			/// <summary></summary>
			public const string INSTALLPROPERTY_UNINSTALLABLE = "Uninstallable";

			/// <summary>URL information. For more information, see the ARPURLINFOABOUT property.</summary>
			public const string INSTALLPROPERTY_URLINFOABOUT = "URLInfoAbout";

			/// <summary>The URL update information. For more information, see the ARPURLUPDATEINFO property.</summary>
			public const string INSTALLPROPERTY_URLUPDATEINFO = "URLUpdateInfo";

			/// <summary>Product version derived from the ProductVersion property.</summary>
			public const string INSTALLPROPERTY_VERSION = "Version";

			/// <summary>The major product version that is derived from the ProductVersion property.</summary>
			public const string INSTALLPROPERTY_VERSIONMAJOR = "VersionMajor";

			/// <summary>The minor product version that is derived from the ProductVersion property.</summary>
			public const string INSTALLPROPERTY_VERSIONMINOR = "VersionMinor";

			/// <summary>The product version. For more information, see the ProductVersion property.</summary>
			public const string INSTALLPROPERTY_VERSIONSTRING = "VersionString";
		}

		/*
		INSTALLUI_HANDLER_RECORD
		INSTALLUI_HANDLERA
		INSTALLUI_HANDLERW

		MSIFILEHASHINFO
		MSIPATCHSEQUENCEINFOA
		MSIPATCHSEQUENCEINFOW

		MsiAdvertiseProductA
		MsiAdvertiseProductExA
		MsiAdvertiseProductExW
		MsiAdvertiseProductW
		MsiAdvertiseScriptA
		MsiAdvertiseScriptW
		MsiApplyMultiplePatchesA
		MsiApplyMultiplePatchesW
		MsiApplyPatchA
		MsiApplyPatchW
		MsiBeginTransactionA
		MsiBeginTransactionW
		MsiCloseAllHandles
		MsiCloseHandle
		MsiCollectUserInfoA
		MsiCollectUserInfoW
		MsiConfigureFeatureA
		MsiConfigureFeatureW
		MsiConfigureProductA
		MsiConfigureProductExA
		MsiConfigureProductExW
		MsiConfigureProductW
		MsiDetermineApplicablePatchesA
		MsiDetermineApplicablePatchesW
		MsiDeterminePatchSequenceA
		MsiDeterminePatchSequenceW
		MsiEnableLogA
		MsiEnableLogW
		MsiEndTransaction
		MsiEnumClientsA
		MsiEnumClientsExA
		MsiEnumClientsExW
		MsiEnumClientsW
		MsiEnumComponentQualifiersA
		MsiEnumComponentQualifiersW
		MsiEnumComponentsA
		MsiEnumComponentsExA
		MsiEnumComponentsExW
		MsiEnumComponentsW
		MsiEnumFeaturesA
		MsiEnumFeaturesW
		MsiEnumPatchesA
		MsiEnumPatchesExA
		MsiEnumPatchesExW
		MsiEnumPatchesW
		MsiEnumProductsA
		MsiEnumProductsW
		MsiEnumRelatedProductsA
		MsiEnumRelatedProductsW
		MsiExtractPatchXMLDataA
		MsiExtractPatchXMLDataW
		MsiGetComponentPathA
		MsiGetComponentPathExA
		MsiGetComponentPathExW
		MsiGetComponentPathW
		MsiGetFeatureInfoA
		MsiGetFeatureInfoW
		MsiGetFeatureUsageA
		MsiGetFeatureUsageW
		MsiGetFileHashA
		MsiGetFileHashW
		MsiGetFileSignatureInformationA
		MsiGetFileSignatureInformationW
		MsiGetFileVersionA
		MsiGetFileVersionW
		MsiGetPatchFileListA
		MsiGetPatchFileListW
		MsiGetPatchInfoA
		MsiGetPatchInfoExA
		MsiGetPatchInfoExW
		MsiGetPatchInfoW
		MsiGetProductCodeA
		MsiGetProductCodeW
		MsiGetProductInfoA
		MsiGetProductInfoFromScriptA
		MsiGetProductInfoFromScriptW
		MsiGetProductInfoW
		MsiGetProductPropertyA
		MsiGetProductPropertyW
		MsiGetShortcutTargetA
		MsiGetShortcutTargetW
		MsiGetUserInfoA
		MsiGetUserInfoW
		MsiInstallMissingComponentA
		MsiInstallMissingComponentW
		MsiInstallMissingFileA
		MsiInstallMissingFileW
		MsiJoinTransaction
		MsiLocateComponentA
		MsiLocateComponentW
		MsiNotifySidChangeA
		MsiNotifySidChangeW
		MsiOpenPackageA
		MsiOpenPackageExA
		MsiOpenPackageExW
		MsiOpenPackageW
		MsiOpenProductA
		MsiOpenProductW
		MsiProcessAdvertiseScriptA
		MsiProcessAdvertiseScriptW
		MsiProvideAssemblyA
		MsiProvideAssemblyW
		MsiProvideComponentA
		MsiProvideComponentW
		MsiProvideQualifiedComponentA
		MsiProvideQualifiedComponentExA
		MsiProvideQualifiedComponentExW
		MsiProvideQualifiedComponentW
		MsiQueryComponentStateA
		MsiQueryComponentStateW
		MsiQueryFeatureStateA
		MsiQueryFeatureStateExA
		MsiQueryFeatureStateExW
		MsiQueryFeatureStateW
		MsiQueryProductStateA
		MsiQueryProductStateW
		MsiReinstallFeatureA
		MsiReinstallFeatureW
		MsiReinstallProductA
		MsiReinstallProductW
		MsiRemovePatchesA
		MsiRemovePatchesW
		MsiSetExternalUIA
		MsiSetExternalUIRecord
		MsiSetExternalUIW
		MsiSetInternalUI
		MsiSourceListAddMediaDiskA
		MsiSourceListAddMediaDiskW
		MsiSourceListAddSourceA
		MsiSourceListAddSourceExA
		MsiSourceListAddSourceExW
		MsiSourceListAddSourceW
		MsiSourceListClearAllA
		MsiSourceListClearAllExA
		MsiSourceListClearAllExW
		MsiSourceListClearAllW
		MsiSourceListClearMediaDiskA
		MsiSourceListClearMediaDiskW
		MsiSourceListClearSourceA
		MsiSourceListClearSourceW
		MsiSourceListEnumMediaDisksA
		MsiSourceListEnumMediaDisksW
		MsiSourceListEnumSourcesA
		MsiSourceListEnumSourcesW
		MsiSourceListForceResolutionA
		MsiSourceListForceResolutionExA
		MsiSourceListForceResolutionExW
		MsiSourceListForceResolutionW
		MsiSourceListGetInfoA
		MsiSourceListGetInfoW
		MsiSourceListSetInfoA
		MsiSourceListSetInfoW
		MsiUseFeatureA
		MsiUseFeatureExA
		MsiUseFeatureExW
		MsiUseFeatureW
		MsiVerifyPackageA
		MsiVerifyPackageW
		*/
	}
}