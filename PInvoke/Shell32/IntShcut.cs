using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Interfaces and methods from Url.dll.</summary>
	public static partial class Url
	{
		/// <summary>Flags used by IUniformResourceLocator::InvokeCommand.</summary>
		[PInvokeData("Intshcut.h")]
		[Flags]
		public enum IURL_INVOKECOMMAND_FLAGS
		{
			/// <summary>
			/// Interaction with the user is allowed and the hwndParent member of this structure is valid. If this is not set, interaction
			/// with the user is not allowed and the hwndParent member is ignored.
			/// </summary>
			IURL_INVOKECOMMAND_FL_ALLOW_UI = 0x0001,

			/// <summary>
			/// Default verb for the Internet Shortcut's protocol should be used and the pcszVerb member is ignored. If this bit is not set,
			/// the verb is specified by pcszVerb.
			/// </summary>
			IURL_INVOKECOMMAND_FL_USE_DEFAULT_VERB = 0x0002,

			/// <summary>Wait for the DDE conversation to terminate before returning.</summary>
			IURL_INVOKECOMMAND_FL_DDEWAIT = 0x0004,

			/// <summary>pass SEE_MASK_ASYNCOK to ShellExec</summary>
			IURL_INVOKECOMMAND_FL_ASYNCOK = 0x0008,

			/// <summary>Record launch with UA system</summary>
			IURL_INVOKECOMMAND_FL_LOG_USAGE = 0x0010,
		}

		/// <summary>Flags used by IUniformResourceLocator::SetUrl.</summary>
		[PInvokeData("Intshcut.h")]
		[Flags]
		public enum IURL_SETURL_FLAGS
		{
			/// <summary>
			/// If the protocol scheme is not specified in pcszURL, the system automatically chooses a scheme and adds it to the URL.
			/// </summary>
			IURL_SETURL_FL_GUESS_PROTOCOL = 0x0001,     // Guess protocol if missing

			/// <summary>If the protocol scheme is not specified in pcszURL, the system adds the default protocol scheme to the URL.</summary>
			IURL_SETURL_FL_USE_DEFAULT_PROTOCOL = 0x0002,     // Use default protocol if missing
		}

		/// <summary>Bit flags that specify how the URL string is to be translated.</summary>
		[PInvokeData("intshcut.h", MSDNShortId = "2f089f5a-4d7c-4bb7-961c-5c6e3e73c7b7")]
		[Flags]
		public enum TRANSLATEURL_IN_FLAGS
		{
			/// <summary>
			/// If the protocol scheme is not specified in the pcszURL parameter of TranslateURL, the system automatically chooses a scheme
			/// and adds it to the URL.
			/// </summary>
			TRANSLATEURL_FL_GUESS_PROTOCOL = 0x0001,

			/// <summary>
			/// If the protocol scheme is not specified in the pcszURL parameter of TranslateURL, the system adds the default protocol to
			/// the URL.
			/// </summary>
			TRANSLATEURL_FL_USE_DEFAULT_PROTOCOL = 0x0002,
		}

		/// <summary>The bit flags that specify the behavior of <see cref="URLAssociationDialog"/>.</summary>
		[PInvokeData("intshcut.h", MSDNShortId = "3158e819-f131-4f57-8516-998955100377")]
		[Flags]
		public enum URLASSOCIATIONDIALOG_IN_FLAGS
		{
			/// <summary>Use the default file name (that is, "Internet Shortcut").</summary>
			URLASSOCDLG_FL_USE_DEFAULT_NAME = 0x0001,

			/// <summary>
			/// Register the selected application as the handler for the protocol specified in pcszURL. The application is registered only
			/// if this flag is set and the user indicates that a persistent association is desired.
			/// </summary>
			URLASSOCDLG_FL_REGISTER_ASSOC = 0x0002
		}

		/// <summary>This interface provides methods that retrieve, set, and run commands on an object's URL.</summary>
		[PInvokeData("Intshcut.h")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("CABB0DA0-DA57-11CF-9974-0020AFD79762"), CoClass(typeof(InternetShortcut))]
		public interface IUniformResourceLocator
		{
			/// <summary>Sets an object's URL.</summary>
			/// <param name="pcszUrl">
			/// Address of a zero-terminated string that contains the URL to set. The protocol scheme may be included as part of the URL.
			/// </param>
			/// <param name="dwInFlags">The dw in flags.</param>
			void SetUrl([MarshalAs(UnmanagedType.LPWStr)] string pcszUrl, IURL_SETURL_FLAGS dwInFlags = 0);

			/// <summary>Retrieves an object's URL.</summary>
			/// <param name="ppszUrl">
			/// Address of an LPSTR that will be filled with a pointer to the object's URL. Because this method allocates memory for the
			/// string, you must create and instance of an IMalloc interface and free the memory using IMalloc::Free when it is no longer needed.
			/// </param>
			void GetUrl([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszUrl);

			/// <summary>Runs a command on an object's URL.</summary>
			/// <param name="purlici">Address of a URLINVOKECOMMANDINFO structure that contains command information for the function.</param>
			void InvokeCommand(in URLINVOKECOMMANDINFO purlici);
		}

		/// <summary>Determines whether the system is connected to the Internet.</summary>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The input flags for the function. This must be set to zero.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Returns <c>TRUE</c> if the local system is not currently connected to the Internet. Returns <c>FALSE</c> if the local system is
		/// connected to the Internet or if no attempt has yet been made to connect to the Internet.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/intshcut/nf-intshcut-inetisoffline INTSHCUTAPI BOOL InetIsOffline( DWORD
		// dwFlags );
		[DllImport(Lib.Url, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("intshcut.h", MSDNShortId = "e0afac1c-c083-4b60-a30f-5dfc1a4b8fd3")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InetIsOffline(uint dwFlags = 0);

		/// <summary>
		/// <para>Runs the unregistered MIME content type dialog box.</para>
		/// <para><c>Note</c> Windows XP Service Pack 2 (SP2) or later: This function is no longer supported.</para>
		/// </summary>
		/// <param name="hwndParent">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the parent window of any posted child windows.</para>
		/// </param>
		/// <param name="dwInFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A bit flag value that specifies if an association is to be registered. The bit flag is the value MIMEASSOCDLG_FL_REGISTER_ASSOC
		/// (0x0001). If this bit is set, the selected application is registered as the handler for the given MIME type. If this bit is
		/// clear, no association is registered.
		/// </para>
		/// <para>An application is registered only if this flag is set and the user indicates that a persistent association is to be made.</para>
		/// <para>Registration is impossible if the string at pcszFile does not contain an extension.</para>
		/// </param>
		/// <param name="pcszFile">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>
		/// The address of a null-terminated string that contains the name of the target file. This file must conform to the content type
		/// described by the pcszMIMEContentType parameter.
		/// </para>
		/// </param>
		/// <param name="pcszMIMEContentType">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>The address of a null-terminated string that contains the unregistered content type.</para>
		/// </param>
		/// <param name="pszAppBuf">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// A pointer to a buffer that, when this function returns successfully, receives the path of the application specified by the user.
		/// </para>
		/// </param>
		/// <param name="ucAppBufLen">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Size of pszAppBuf, in characters.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para><c>Note</c> As of Windows XP SP2, this function is not supported and returns E_NOTIMPL in all situations.</para>
		/// <para>
		/// In supported systems, returns S_OK if the content type was successfully associated with the extension. In this case, the
		/// extension is associated as the default for the content type, and pszAppBuf points to the string that contains the path of the
		/// specified application. The function returns S_FALSE if nothing was registered. Otherwise, the return value will be one of the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ABORT</term>
		/// <term>The user canceled the operation.</term>
		/// </item>
		/// <item>
		/// <term>E_FLAGS</term>
		/// <term>The flag combination passed in dwInFlags is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There was insufficient memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>One of the input pointers is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This function does not validate the syntax of the input content type string at pcszMIMEContentType. A successful return value
		/// does not indicate that the specified MIME content type is valid.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/intshcut/nf-intshcut-mimeassociationdialoga INTSHCUTAPI HRESULT
		// MIMEAssociationDialogA( HWND hwndParent, DWORD dwInFlags, PCSTR pcszFile, PCSTR pcszMIMEContentType, PSTR pszAppBuf, UINT
		// ucAppBufLen );
		[DllImport(Lib.Url, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("intshcut.h", MSDNShortId = "0f8ee95a-3f95-47ee-822b-740ba134cd3c")]
		[Obsolete]
		public static extern HRESULT MIMEAssociationDialog(HWND hwndParent, uint dwInFlags, string pcszFile, string pcszMIMEContentType, StringBuilder pszAppBuf, uint ucAppBufLen);

		/// <summary>Applies common translations to a given URL string, creating a new URL string.</summary>
		/// <param name="pcszURL">
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>The address of the URL string to be translated.</para>
		/// </param>
		/// <param name="dwInFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The bit flags that specify how the URL string is to be translated. This value can be a combination of the following:</para>
		/// <para>TRANSLATEURL_FL_GUESS_PROTOCOL</para>
		/// <para>
		/// If the protocol scheme is not specified in the pcszURL parameter to <c>TranslateURL</c>, the system automatically chooses a
		/// scheme and adds it to the URL.
		/// </para>
		/// <para>TRANSLATEURL_FL_USE_DEFAULT_PROTOCOL</para>
		/// <para>
		/// If the protocol scheme is not specified in the pcszURL parameter to <c>TranslateURL</c>, the system adds the default protocol to
		/// the URL.
		/// </para>
		/// </param>
		/// <param name="ppszTranslatedURL">
		/// <para>Type: <c>PTSTR*</c></para>
		/// <para>
		/// A pointer variable that receives the pointer to the newly created, translated URL string, if any. The ppszTranslatedURL
		/// parameter is valid only if the function returns S_OK.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK upon success, or S_FALSE if the URL did not require translation. If an error occurs, the function returns one of
		/// the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_FLAGS</term>
		/// <term>The flag combination passed in dwInFlags is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There was insufficient memory to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>One of the input pointers is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This function does not validate the input URL string. A successful return value does not indicate that the URL strings are valid URLs.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/intshcut/nf-intshcut-translateurla INTSHCUTAPI HRESULT TranslateURLA( PCSTR
		// pcszURL, DWORD dwInFlags, PSTR *ppszTranslatedURL );
		[DllImport(Lib.Url, SetLastError = false, EntryPoint = "TranslateURLW")]
		[PInvokeData("intshcut.h", MSDNShortId = "2f089f5a-4d7c-4bb7-961c-5c6e3e73c7b7")]
		public static extern HRESULT TranslateURL([MarshalAs(UnmanagedType.LPWStr)] string pcszURL, TRANSLATEURL_IN_FLAGS dwInFlags, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszTranslatedURL);

		/// <summary>
		/// <para>
		/// Invokes the unregistered URL protocol dialog box. This dialog box allows the user to select an application to associate with a
		/// previously unknown protocol.
		/// </para>
		/// <para><c>Note</c> Windows XP Service Pack 2 (SP2) or later: This function is no longer supported.</para>
		/// </summary>
		/// <param name="hwndParent">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the parent window.</para>
		/// </param>
		/// <param name="dwInFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The bit flags that specify the behavior of the function. This value can be a combination of the following:</para>
		/// <para>URLASSOCDLG_FL_USE_DEFAULT_NAME</para>
		/// <para>Use the default file name (that is, "Internet Shortcut").</para>
		/// <para>URLASSOCDLG_FL_REGISTER_ASSOC</para>
		/// <para>
		/// Register the selected application as the handler for the protocol specified in pcszURL. The application is registered only if
		/// this flag is set and the user indicates that a persistent association is desired.
		/// </para>
		/// </param>
		/// <param name="pcszFile">
		/// <para>Type: <c>PTCSTR</c></para>
		/// <para>The address of a constant zero-terminated string that contains the file name to associate with the URLs protocol.</para>
		/// </param>
		/// <param name="pcszURL">
		/// <para>Type: <c>PTCSTR</c></para>
		/// <para>The address of a constant zero-terminated string that contains the URL with an unknown protocol.</para>
		/// </param>
		/// <param name="pszAppBuf">
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>The address of a buffer that receives the path of the application specified by the user.</para>
		/// </param>
		/// <param name="ucAppBufLen">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of pszAppBuf, in characters.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para><c>Note</c> As of Windows XP SP2, this function not supported and returns E_NOTIMPL in all situations.</para>
		/// <para>
		/// In supported systems, returns S_OK if the application is registered with the URL protocol, or S_FALSE if nothing is registered.
		/// For example, the function returns S_FALSE when the user elects to perform a one-time execution via the selected application.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/intshcut/nf-intshcut-urlassociationdialoga INTSHCUTAPI HRESULT
		// URLAssociationDialogA( HWND hwndParent, DWORD dwInFlags, PCSTR pcszFile, PCSTR pcszURL, PSTR pszAppBuf, UINT ucAppBufLen );
		[DllImport(Lib.Url, SetLastError = false, EntryPoint = "URLAssociationDialogW")]
		[PInvokeData("intshcut.h", MSDNShortId = "3158e819-f131-4f57-8516-998955100377")]
		[Obsolete]
		public static extern HRESULT URLAssociationDialog(HWND hwndParent, URLASSOCIATIONDIALOG_IN_FLAGS dwInFlags, [MarshalAs(UnmanagedType.LPWStr)] string pcszFile, [MarshalAs(UnmanagedType.LPWStr)] string pcszURL, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszAppBuf, uint ucAppBufLen);

		/// <summary>Contains information for use with the IUniformResourceLocator::InvokeCommand method.</summary>
		[PInvokeData("Intshcut.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct URLINVOKECOMMANDINFO
		{
			private static readonly uint size = (uint)Marshal.SizeOf(typeof(URLINVOKECOMMANDINFO));

			/// <summary>Size of this structure, in bytes.</summary>
			public uint dwcbSize;

			/// <summary>Flag value that specifies how the IUniformResourceLocator::InvokeCommand method will execute.</summary>
			public IURL_INVOKECOMMAND_FLAGS dwFlags;

			/// <summary>Handle to the parent window. If dwFlags is set to IURL_INVOKECOMMAND_FL_USE_DEFAULT_VERB, this member is ignored.</summary>
			public HWND hwndParent;

			/// <summary>
			/// Address of a zero-terminated string that contains the verb to be invoked by IUniformResourceLocator::InvokeCommand. If
			/// dwFlags is set to IURL_INVOKECOMMAND_FL_USE_DEFAULT_VERB, this member is ignored.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pcszVerb;

			/// <summary>Initializes a new instance of the <see cref="URLINVOKECOMMANDINFO"/> struct.</summary>
			/// <param name="verb">The verb to be invoked by IUniformResourceLocator::InvokeCommand.</param>
			/// <param name="parentHwnd">Handle to the parent window.</param>
			public URLINVOKECOMMANDINFO(string verb = null, HWND? parentHwnd = null)
			{
				dwcbSize = size;
				dwFlags = (verb is null ? 0 : IURL_INVOKECOMMAND_FLAGS.IURL_INVOKECOMMAND_FL_USE_DEFAULT_VERB) | (parentHwnd is null ? 0 : IURL_INVOKECOMMAND_FLAGS.IURL_INVOKECOMMAND_FL_ALLOW_UI);
				hwndParent = parentHwnd.GetValueOrDefault();
				pcszVerb = verb;
			}

			/// <summary>Gets a default instance of this structure with the size field set appropriately.</summary>
			public static readonly URLINVOKECOMMANDINFO Default = new URLINVOKECOMMANDINFO { dwcbSize = size };
		}

		/// <summary>CoClass for IUniformResourceLocator.</summary>
		[PInvokeData("Intshcut.h")]
		[ComImport, Guid("FBF23B40-E3F0-101B-8488-00AA003E56F8"), ClassInterface(ClassInterfaceType.None)]
		public class InternetShortcut { }
	}
}