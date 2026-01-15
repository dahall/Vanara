namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Exposes methods that allow the caller to retrieve information entered into a search box.</summary>
	/// <remarks>
	/// <para>The search box is shown here in an Windows Explorer window frame.</para>
	/// <para>The frame that contains the search box might also be hosted in another window or in the common file dialog box.</para>
	/// <para>To access the search dialog, use QueryService using SID_SSearchBoxInfo on a site pointer within the Windows Explorer window.</para>
	/// <para>When to Implement</para>
	/// <para>An implementation of this interface is provided with Windows. Third parties do not need to implement their own version.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-isearchboxinfo
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.ISearchBoxInfo")]
	[ComImport, Guid("6af6e03f-d664-4ef4-9626-f7e0ed36755e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISearchBoxInfo
	{
		/// <summary>Retrieves the contents of the search box as an ICondition object.</summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>A reference to the IID of the interface to retrieve through ppv, typically IID_ICondition.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this method returns successfully, contains the interface pointer requested in riid. This is typically ICondition.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// As opposed to the text string retrieved by ISearchBoxInfo::GetText, <c>GetCondition</c> retrieves the same information as a
		/// structured object, the methods of which can be used to parse and manipulate the search string.
		/// </para>
		/// <para>
		/// We recommend that you use the <c>IID_PPV_ARGS</c> macro, defined in Objbase.h, to package the riid and ppv parameters. This
		/// macro provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a
		/// coding error in riid that could lead to unexpected results.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-isearchboxinfo-getcondition HRESULT GetCondition(
		// REFIID riid, void **ppv );
		void GetCondition(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppv);

		/// <summary>Retrieves the contents of the search box as plain text.</summary>
		/// <param name="ppsz">
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>Pointer to a buffer that, when this method returns successfully, receives the full text entered in the search box.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-isearchboxinfo-gettext HRESULT GetText( LPWSTR *ppsz );
		void GetText(out LPWSTR ppsz);
	}
}