using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Provides a set of flags to be used with IAttachmentExecute::Prompt to indicate the action to be performed upon user confirmation.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-attachment_action typedef enum
		// ATTACHMENT_ACTION { ATTACHMENT_ACTION_CANCEL, ATTACHMENT_ACTION_SAVE, ATTACHMENT_ACTION_EXEC } ;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NE:shobjidl_core.ATTACHMENT_ACTION")]
		public enum ATTACHMENT_ACTION
		{
			/// <summary>Cancel</summary>
			ATTACHMENT_ACTION_CANCEL,

			/// <summary>Save</summary>
			ATTACHMENT_ACTION_SAVE,

			/// <summary>Execute</summary>
			ATTACHMENT_ACTION_EXEC,
		}

		/// <summary>Provides a set of flags to be used with IAttachmentExecute::Prompt to indicate the type of prompt UI to display.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-attachment_prompt typedef enum
		// ATTACHMENT_PROMPT { ATTACHMENT_PROMPT_NONE, ATTACHMENT_PROMPT_SAVE, ATTACHMENT_PROMPT_EXEC, ATTACHMENT_PROMPT_EXEC_OR_SAVE } ;
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NE:shobjidl_core.ATTACHMENT_PROMPT")]
		public enum ATTACHMENT_PROMPT
		{
			/// <summary>Do not use.</summary>
			ATTACHMENT_PROMPT_NONE,

			/// <summary>Displays a prompt asking whether the user would like to save the attachment.</summary>
			ATTACHMENT_PROMPT_SAVE,

			/// <summary>Displays a prompt asking whether the user would like to execute the attachment.</summary>
			ATTACHMENT_PROMPT_EXEC,

			/// <summary>Displays a prompt giving the user a choice of executing or saving the attachment.</summary>
			ATTACHMENT_PROMPT_EXEC_OR_SAVE,
		}

		/// <summary>
		/// Exposes methods that work with client applications to present a user environment that provides safe download and exchange of
		/// files through email and messaging attachments.
		/// </summary>
		/// <remarks>
		/// <para>This interface assumes the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The client has policies or settings for attachment support and behavior.</term>
		/// </item>
		/// <item>
		/// <term>The client interacts with the user.</term>
		/// </item>
		/// </list>
		/// <para>The IID for this interface is <c>IID_IAttachmentExecute</c>.</para>
		/// <para>Here is an example of how an email client might use <c>IAttachmentExecute</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iattachmentexecute
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IAttachmentExecute")]
		[ComImport, Guid("73db1241-1e85-4581-8e4f-a81e1d0f8c57"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(AttachmentServices))]
		public interface IAttachmentExecute
		{
			/// <summary>Specifies and stores the title of the prompt window.</summary>
			/// <param name="pszTitle">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a string that contains the title text.</para>
			/// </param>
			/// <remarks>
			/// If <c>IAttachmentExecute::SetClientTitle</c> is not called, a default title of <c>File Download</c> is used in the prompt's
			/// title bar.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iattachmentexecute-setclienttitle HRESULT
			// SetClientTitle( LPCWSTR pszTitle );
			void SetClientTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

			/// <summary>Specifies and stores the GUID for the client.</summary>
			/// <param name="guid">
			/// <para>Type: <c>REFGUID</c></para>
			/// <para>The GUID that represents the client.</para>
			/// </param>
			/// <remarks>
			/// A user can choose not to display certain prompts. That information is stored in the registry on a per-client basis, indexed
			/// by guid.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iattachmentexecute-setclientguid HRESULT
			// SetClientGuid( REFGUID guid );
			void SetClientGuid(in Guid guid);

			/// <summary>Sets and stores the path to the file.</summary>
			/// <param name="pszLocalPath">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a string that contains the local path where the attachment file is to be stored.</para>
			/// </param>
			/// <remarks>
			/// <para>Calling <c>IAttachmentExecute::SetLocalPath</c> is required.</para>
			/// <para>
			/// When the attachment is approved for execution by the user (either through policy or prompt), the path specified by this
			/// method is used. If only IAttachmentExecute::SetFileName was called before calling IAttachmentExecute::CheckPolicy and
			/// IAttachmentExecute::Prompt, that trust could be revoked if the assumed local path was different from that set by
			/// <c>IAttachmentExecute::SetLocalPath</c>. Trust can be granted by various Zone APIs, antivirus services, file type
			/// information, policies as well as other system trust providers.
			/// </para>
			/// <para><c>IAttachmentExecute::SetLocalPath</c> must be called before calling IAttachmentExecute::Execute.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iattachmentexecute-setlocalpath HRESULT
			// SetLocalPath( LPCWSTR pszLocalPath );
			void SetLocalPath([MarshalAs(UnmanagedType.LPWStr)] string pszLocalPath);

			/// <summary>Specifies and stores the proposed name of the file.</summary>
			/// <param name="pszFileName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a string that contains the file name.</para>
			/// </param>
			/// <remarks>
			/// <para>No path information should be included at pszFileName, just the file's name.</para>
			/// <para>
			/// <c>IAttachmentExecute::SetFileName</c> can be used by the calling application to check the validity of the file name before
			/// copying the file locally. The file name is checked for name collisions against other files stored at the local path location.
			/// </para>
			/// <para><c>IAttachmentExecute::SetFileName</c> is optional.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iattachmentexecute-setfilename HRESULT
			// SetFileName( LPCWSTR pszFileName );
			void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszFileName);

			/// <summary>Sets an alternate path or URL for the source of a file transfer.</summary>
			/// <param name="pszSource">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a string containing the path or URL to use as the source.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// The path or URL declared here is used as the primary zone determinant. The policy under which the attachment is handled is
			/// based partially on the perceived zone. If pszSource is <c>NULL</c>, the default is Restricted Zone.
			/// </para>
			/// <para>Calling <c>IAttachmentExecute::SetSource</c> is optional.</para>
			/// <para>The path or URL declared here can also be used in the prompt UI as the <c>From</c> field.</para>
			/// <para>The path or URL declared here can also be sent to handlers that can process URLs.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iattachmentexecute-setsource HRESULT
			// SetSource( LPCWSTR pszSource );
			void SetSource([MarshalAs(UnmanagedType.LPWStr)] string pszSource);

			/// <summary>Sets the security zone associated with the attachment file based on the referring file.</summary>
			/// <param name="pszReferrer">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a string containing the path of the referring file.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// <c>IAttachmentExecute::SetReferrer</c> and IAttachmentExecute::SetSource have similar functionality. If both are set, the
			/// least-trusted zone of the two is used.
			/// </para>
			/// <para>
			/// <c>IAttachmentExecute::SetReferrer</c> is used by container files to indicate indirect inheritance and avoid zone elevation.
			/// It can also be used with shortcut files to limit elevation based on parameters.
			/// </para>
			/// <para>Calling <c>IAttachmentExecute::SetReferrer</c> is optional.</para>
			/// <para><c>IAttachmentExecute::SetReferrer</c> is only used to determine the security zone and its associated policies.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iattachmentexecute-setreferrer HRESULT
			// SetReferrer( LPCWSTR pszReferrer );
			void SetReferrer([MarshalAs(UnmanagedType.LPWStr)] string pszReferrer);

			/// <summary>Provides a Boolean test that can be used to make decisions based on the attachment's execution policy.</summary>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Enable</term>
			/// </item>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>Prompt</term>
			/// </item>
			/// <item>
			/// <term>Any other failure code</term>
			/// <term>Disable</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>IAttachmentExecute::CheckPolicy</c> examines a set of properties known collectively as evidence. Anything used to
			/// determine trust level is considered evidence. These properties are set using the following methods.
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>IAttachmentExecute::SetFileName</term>
			/// </item>
			/// <item>
			/// <term>IAttachmentExecute::SetLocalPath</term>
			/// </item>
			/// <item>
			/// <term>IAttachmentExecute::SetReferrer</term>
			/// </item>
			/// <item>
			/// <term>IAttachmentExecute::SetSource</term>
			/// </item>
			/// </list>
			/// <para>
			/// The information returned by <c>IAttachmentExecute::CheckPolicy</c> enables an application to modify its UI appropriately for
			/// the situation.
			/// </para>
			/// <para>
			/// <c>IAttachmentExecute::CheckPolicy</c> requires the application first to call either IAttachmentExecute::SetFileName or IAttachmentExecute::SetLocalPath.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iattachmentexecute-checkpolicy HRESULT CheckPolicy();
			[PreserveSig]
			HRESULT CheckPolicy();

			/// <summary>Presents a prompt UI to the user.</summary>
			/// <param name="hwnd">
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the parent window.</para>
			/// </param>
			/// <param name="prompt">
			/// <para>Type: <c>ATTACHMENT_PROMPT</c></para>
			/// <para>A member of the ATTACHMENT_PROMPT enumeration that indicates what type of prompt UI to display to the user.</para>
			/// </param>
			/// <param name="paction">
			/// <para>Type: <c>ATTACHMENT_ACTION*</c></para>
			/// <para>A member of the ATTACHMENT_ACTION enumeration that indicates the action to be performed upon user confirmation.</para>
			/// </param>
			/// <remarks>
			/// <para>You must call IAttachmentExecute::SetFileName or IAttachmentExecute::SetLocalPath before calling <c>IAttachmentExecute::Prompt</c>.</para>
			/// <para>
			/// <c>IAttachmentExecute::Prompt</c> can be called by the application to force UI presentation before the file has been copied
			/// to disk.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iattachmentexecute-prompt HRESULT Prompt(
			// HWND hwnd, ATTACHMENT_PROMPT prompt, ATTACHMENT_ACTION *paction );
			void Prompt([In] HWND hwnd, [In] ATTACHMENT_PROMPT prompt, out ATTACHMENT_ACTION paction);

			/// <summary>Saves the attachment.</summary>
			/// <remarks>
			/// <para>
			/// Before calling <c>IAttachmentExecute::Save</c>, you must call IAttachmentExecute::SetLocalPath with a valid path. The file
			/// should be copied to that local path before <c>IAttachmentExecute::Save</c> is called.
			/// </para>
			/// <para>
			/// <c>IAttachmentExecute::Save</c> should always be called if the local path declared in IAttachmentExecute::SetLocalPath is
			/// not the path of a temporary directory.
			/// </para>
			/// <para>
			/// <c>IAttachmentExecute::Save</c> may run virus scanners or other trust services to validate the file before saving it. Note
			/// that these services can delete or alter the file.
			/// </para>
			/// <para><c>IAttachmentExecute::Save</c> may attach evidence to the local path in its NTFS alternate data stream (ADS).</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iattachmentexecute-save HRESULT Save();
			void Save();

			/// <summary>Executes an action on an attachment.</summary>
			/// <param name="hwnd">
			/// <para>Type: <c>HWND</c></para>
			/// <para>The handle of the parent window.</para>
			/// </param>
			/// <param name="pszVerb">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// A pointer to a null-terminated string that contains a verb specifying the action to be performed on the file. See the
			/// lpOperation parameter in ShellExecute for valid strings. This value can be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="phProcess">
			/// <para>Type: <c>HANDLE*</c></para>
			/// <para>A pointer to a handle to the source process, used for synchronous operation. This value can be <c>NULL</c>.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// Before calling <c>IAttachmentExecute::Execute</c>, IAttachmentExecute::SetLocalPath must be called with a valid local path
			/// and the file must be copied to that location.
			/// </para>
			/// <para>
			/// If a prompt is indicated, <c>IAttachmentExecute::Execute</c> calls IAttachmentExecute::Prompt using the
			/// ATTACHMENT_ACTION_EXEC value.
			/// </para>
			/// <para>
			/// <c>IAttachmentExecute::Execute</c> may run virus scanners or other trust services to validate the file before executing it.
			/// Note that these services can delete or alter the file.
			/// </para>
			/// <para><c>IAttachmentExecute::Execute</c> may attach evidence to the local path in its NTFS alternate data stream (ADS).</para>
			/// <para>
			/// If phProcess is not <c>NULL</c>, <c>IAttachmentExecute::Execute</c> operates as a synchronous process and returns an
			/// <c>HPROCESS</c>, if available. If phProcess is <c>NULL</c>, <c>IAttachmentExecute::Execute</c> operates as an asynchronous
			/// process. This implies that the calling application has a message pump and a long-lived window.
			/// </para>
			/// <para>
			/// If the handle pointed to by phProcess is non- <c>NULL</c> when the method returns, the calling application is responsible
			/// for calling CloseHandle to free the handle when it is no longer needed.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iattachmentexecute-execute HRESULT Execute(
			// HWND hwnd, LPCWSTR pszVerb, HANDLE *phProcess );
			void Execute([In] HWND hwnd, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pszVerb, [Out, Optional] out HPROCESS phProcess);

			/// <summary>Presents the user with explanatory error UI if the save action fails.</summary>
			/// <param name="hwnd">
			/// <para>Type: <c>HWND</c></para>
			/// <para>The handle of the parent window.</para>
			/// </param>
			/// <remarks>
			/// <para><c>IAttachmentExecute::SaveWithUI</c> does not call IAttachmentExecute::Prompt.</para>
			/// <para>
			/// Before calling <c>IAttachmentExecute::SaveWithUI</c>, you must call IAttachmentExecute::SetLocalPath with a valid path. The
			/// file is copied to that local path before <c>IAttachmentExecute::SaveWithUI</c> is called.
			/// </para>
			/// <para>
			/// <c>IAttachmentExecute::SaveWithUI</c> may run virus scanners or other trust services to validate the file before saving it.
			/// Note that these services can delete or alter the file.
			/// </para>
			/// <para><c>IAttachmentExecute::SaveWithUI</c> may attach evidence to the local path in its NTFS alternate data stream (ADS).</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iattachmentexecute-savewithui HRESULT
			// SaveWithUI( HWND hwnd );
			void SaveWithUI([In] HWND hwnd);

			/// <summary>
			/// Removes any stored state that is based on the client's GUID. An example might be a setting based on a checked box that
			/// indicates a prompt should not be displayed again for a particular file type.
			/// </summary>
			/// <remarks>IAttachmentExecute::SetClientGuid must be called before using <c>IAttachmentExecute::ClearClientState</c>.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iattachmentexecute-clearclientstate HRESULT ClearClientState();
			void ClearClientState();
		}

		/// <summary>CLSID_AttachmentServices</summary>
		[ComImport, Guid("4125dd96-e03a-4103-8f70-e0597d803b9c"), ClassInterface(ClassInterfaceType.None)]
		public class AttachmentServices { }
	}
}