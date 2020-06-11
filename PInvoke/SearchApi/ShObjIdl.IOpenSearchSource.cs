using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class SearchApi
	{
		/// <summary>Exposes a method to get search results from a custom client-side OpenSearch data source.</summary>
		/// <remarks>
		/// <para>When to Implement</para>
		/// <para>Implement this interface when a server-side only solution will not work, such as the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Remote indexes with authentication methods which Windows 7 search federation does not support, like forms-based authentication or other custom authentication methods.</term>
		/// </item>
		/// <item>
		/// <term>High value public stores of vertical data which are not controlled by the developer (such as the Library of Congress or medical research databases) and which do not provide OpenSearch output support today but have public web API.</term>
		/// </item>
		/// <item>
		/// <term>Proprietary enterprise data stores or indexes and legacy content management stores for which it might not be possible to implement a front end.</term>
		/// </item>
		/// </list>
		/// <para>A client-side OpenSearch data source that sits in between the Windows OpenSearch provider and the external data source.</para>
		/// <para>With a search connector (a .searchconnector-ms file), Windows Explorer calls your implementation with the query parameters. Your implementation returns results formatted in RSS or Atom format. That allows your implementation to provide custom authentication UI and connect to the data source using its proprietary API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iopensearchsource
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IOpenSearchSource")]
		[ComImport, Guid("F0EE7333-E6FC-479b-9F25-A860C234A38E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOpenSearchSource
		{
			/// <summary>Returns search results, from an OpenSearch data source, formatted in RSS or Atom format.</summary>
			/// <param name="hwnd">
			/// <para>Type: <c>HWND</c></para>
			/// <para>The window handle of the caller.</para>
			/// </param>
			/// <param name="pszQuery">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The query as entered by the user. This parameter is equivalent to the OpenSearch {searchTerms} parameter and may be empty.</para>
			/// </param>
			/// <param name="dwStartIndex">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The index of the first result being requested. Equivalent to the OpenSearch {startIndex} parameter. See Remarks below.</para>
			/// </param>
			/// <param name="dwCount">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of results being requested. Equivalent to the OpenSearch {count} parameter.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The IID of the interface being requested. Typically IID_IStream.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>An interface pointer, of type specified by RIID, to the object containing the results in Atom or RSS format.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if successful, or an error value otherwise. B_S_ENDOFROWSET optionally signifies the end of the results. The following errors display appropriate error messages in the info bar:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>INET_E_AUTHENTICATION_REQUIRED (user does not have permission to access this resource)</term>
			/// </item>
			/// <item>
			/// <term>INET_E_RESOURCE_NOT_FOUND (location was unavailable)</term>
			/// </item>
			/// <item>
			/// <term>INET_E_DOWNLOAD_FAILURE (server error)</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>Windows Explorer calls this method with the search query parameters. The IOpenSearchSource implementation returns some or all results after performing required actions, such as providing custom authentication UI or connecting to the data source using a proprietary API.</para>
			/// <para>Paged Results</para>
			/// <para>If you do not want the web service to return more than a limited number of results per request, this method can return just a "page" of results at a time. Windows Explorer can get additional pages of results by calling this method repeatedly and specifying a new index number. When returning results, the first result must be the result at the index requested by dwStartIndex.</para>
			/// <para>Index Numbers and Counts</para>
			/// <para>The index number identifies the first result on a page of results. It is equivalent to the OpenSearch {startIndex} parameter. The count, equivalent to the OpenSearch {count} parameter, identifies the expected or preferred number of items returned per page.</para>
			/// <para>If a web service returns 20 items on the first page of results, the expected page size is 20. To get the next 20 items, Windows Explorer would call <c>IOpenSearchSource::GetResults</c> with the value 21 for dwStartIndex and with the value of 20 for dwCount. When a page of results returned by the web service has fewer items than the expected page size, Windows Explorer assumes it has received the last page of results and stops making requests.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iopensearchsource-getresults
			// HRESULT GetResults( HWND hwnd, LPCWSTR pszQuery, DWORD dwStartIndex, DWORD dwCount, REFIID riid, void **ppv );
			[PreserveSig]
			HRESULT GetResults(HWND hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszQuery, uint dwStartIndex, uint dwCount, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object ppv);
		}
	}
}