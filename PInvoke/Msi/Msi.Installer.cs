using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	/// <summary>Items from the Msi.dll</summary>
	public static partial class Msi
	{
		/// <summary>The maximum characters in a feature name, not including the null-terminator.</summary>
		public const int MAX_FEATURE_CHARS = 38;

		/// <summary>The maximum characters in a GUID buffer, not including the null-terminator.</summary>
		public const int MAX_GUID_CHARS = 38;

		/// <summary>
		/// The <c>INSTALLUI_HANDLER</c> function prototype defines a callback function that the installer calls for progress notification
		/// and error messages. For more information on the usage of this function prototype, a sample code snippet is available in Handling
		/// Progress Messages Using MsiSetExternalUI.
		/// </summary>
		/// <param name="pvContext">
		/// Pointer to an application context passed to the MsiSetExternalUI function. This parameter can be used for error checking.
		/// </param>
		/// <param name="iMessageType">
		/// <para>
		/// Specifies a combination of one message box style, one message box icon type, one default button, and one installation message
		/// type. This parameter must be one of the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Message box StylesFlag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MB_ABORTRETRYIGNORE</term>
		/// <term>The message box contains the Abort, Retry, and Ignore buttons.</term>
		/// </item>
		/// <item>
		/// <term>MB_OK</term>
		/// <term>The message box contains the OK button. This is the default.</term>
		/// </item>
		/// <item>
		/// <term>MB_OKCANCEL</term>
		/// <term>The message box contains the OK and Cancel buttons.</term>
		/// </item>
		/// <item>
		/// <term>MB_RETRYCANCEL</term>
		/// <term>The message box contains the Retry and Cancel buttons.</term>
		/// </item>
		/// <item>
		/// <term>MB_YESNO</term>
		/// <term>The message box contains the Yes and No buttons.</term>
		/// </item>
		/// <item>
		/// <term>MB_YESNOCANCEL</term>
		/// <term>The message box contains the Yes, No, and Cancel buttons.</term>
		/// </item>
		/// </list>
		/// <list type="table">
		/// <listheader>
		/// <term>Message box IconTypesFlag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MB_ICONEXCLAMATION, MB_ICONWARNING</term>
		/// <term>An exclamation point appears in the message box.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONINFORMATION, MB_ICONASTERISK</term>
		/// <term>The information sign appears in the message box.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONQUESTION</term>
		/// <term>A question mark appears in the message box.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONSTOP, MB_ICONERROR, MB_ICONHAND</term>
		/// <term>A stop sign appears in the message box.</term>
		/// </item>
		/// </list>
		/// <list type="table">
		/// <listheader>
		/// <term>Default ButtonsFlag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MB_DEFBUTTON1</term>
		/// <term>The first button is the default button.</term>
		/// </item>
		/// <item>
		/// <term>MB_DEFBUTTON2</term>
		/// <term>The second button is the default button.</term>
		/// </item>
		/// <item>
		/// <term>MB_DEFBUTTON3</term>
		/// <term>The third button is the default button.</term>
		/// </item>
		/// </list>
		/// <list type="table">
		/// <listheader>
		/// <term>Install message TypesFlag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INSTALLMESSAGE_FATALEXIT</term>
		/// <term>Premature termination</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_ERROR</term>
		/// <term>Formatted error message</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_WARNING</term>
		/// <term>Formatted warning message</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_USER</term>
		/// <term>User request message.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_INFO</term>
		/// <term>Informative message for log</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_FILESINUSE</term>
		/// <term>List of files currently in use that must be closed before being replaced.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_RESOLVESOURCE</term>
		/// <term>Request to determine a valid source location</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_RMFILESINUSE</term>
		/// <term>
		/// List of files currently in use that must be closed before being replaced. Available beginning with Windows Installer 4.0. For
		/// more information about this message see Using Restart Manager with an External UI.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_OUTOFDISKSPACE</term>
		/// <term>Insufficient disk space message</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_ACTIONSTART</term>
		/// <term>Start of action message. This message includes the action name and description.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_ACTIONDATA</term>
		/// <term>Formatted data associated with the individual action item.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_PROGRESS</term>
		/// <term>Progress gauge information. This message includes information on units so far and total number of units.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_COMMONDATA</term>
		/// <term>Formatted dialog information for user interface.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_INITIALIZE</term>
		/// <term>Sent prior to UI initialization, no string data</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_TERMINATE</term>
		/// <term>Sent after UI termination, no string data</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_SHOWDIALOG</term>
		/// <term>Sent prior to display of authored dialog or wizard</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_INSTALLSTART</term>
		/// <term>Sent prior to installation of product.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_INSTALLEND</term>
		/// <term>Sent after installation of product.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The following defaults should be used if any of the preceding messages are missing: MB_OK, no icon, and MB_DEFBUTTON1. There is
		/// no default installation message type; a message type is always specified.
		/// </para>
		/// </param>
		/// <param name="szMessage">Specifies the message text.</param>
		/// <returns>
		/// <para>The following return values map to the buttons specified by the message box style:</para>
		/// <para>IDOKIDCANCELIDABORTIDRETRYIDIGNOREIDYESIDNO</para>
		/// </returns>
		/// <remarks>
		/// For more information on returning values from an external user interface handler, see the Returning Values from an External User
		/// Interface Handler topic.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nc-msi-installui_handlera INSTALLUI_HANDLERA InstalluiHandlera; int
		// InstalluiHandlera( LPVOID pvContext, UINT iMessageType, LPCSTR szMessage ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NC:msi.INSTALLUI_HANDLERA")]
		public delegate int INSTALLUI_HANDLER(IntPtr pvContext, uint iMessageType, [MarshalAs(UnmanagedType.LPTStr)] string szMessage);

		/// <summary>
		/// <para>
		/// The <c>INSTALLUI_HANDLER_RECORD</c> function prototype defines a callback function that the installer calls for progress
		/// notification and error messages. Call the <c>MsiSetExternalUIRecord</c> function to enable a record-base external user-interface
		/// (UI) handler.
		/// </para>
		/// <para>
		/// <c>Windows Installer 3.0 and Windows Installer 2.0:</c> Not supported. Available beginning with Windows Installer version 3.1
		/// and later.
		/// </para>
		/// </summary>
		/// <param name="pvContext">
		/// Pointer to an application context passed to the MsiSetExternalUIRecord function. This parameter can be used for error checking.
		/// </param>
		/// <param name="iMessageType">
		/// <para>
		/// Specifies a combination of one message box style, one message box icon type, one default button, and one installation message
		/// type. This parameter must be one of the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Message box StylesFlag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MB_ABORTRETRYIGNORE</term>
		/// <term>The message box contains the Abort, Retry, and Ignore buttons.</term>
		/// </item>
		/// <item>
		/// <term>MB_OK</term>
		/// <term>The message box contains the OK button. This is the default.</term>
		/// </item>
		/// <item>
		/// <term>MB_OKCANCEL</term>
		/// <term>The message box contains the OK and Cancel buttons.</term>
		/// </item>
		/// <item>
		/// <term>MB_RETRYCANCEL</term>
		/// <term>The message box contains the Retry and Cancel buttons.</term>
		/// </item>
		/// <item>
		/// <term>MB_YESNO</term>
		/// <term>The message box contains the Yes and No buttons.</term>
		/// </item>
		/// <item>
		/// <term>MB_YESNOCANCEL</term>
		/// <term>The message box contains the Yes, No, and Cancel buttons.</term>
		/// </item>
		/// </list>
		/// <list type="table">
		/// <listheader>
		/// <term>Message box IconTypesFlag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MB_ICONEXCLAMATION, MB_ICONWARNING</term>
		/// <term>An exclamation point appears in the message box.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONINFORMATION, MB_ICONASTERISK</term>
		/// <term>The information sign appears in the message box.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONQUESTION</term>
		/// <term>A question mark appears in the message box.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONSTOP, MB_ICONERROR, MB_ICONHAND</term>
		/// <term>A stop sign appears in the message box.</term>
		/// </item>
		/// </list>
		/// <list type="table">
		/// <listheader>
		/// <term>Default ButtonsFlag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MB_DEFBUTTON1</term>
		/// <term>The first button is the default button.</term>
		/// </item>
		/// <item>
		/// <term>MB_DEFBUTTON2</term>
		/// <term>The second button is the default button.</term>
		/// </item>
		/// <item>
		/// <term>MB_DEFBUTTON3</term>
		/// <term>The third button is the default button.</term>
		/// </item>
		/// </list>
		/// <list type="table">
		/// <listheader>
		/// <term>Install message TypesFlag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INSTALLMESSAGE_FATALEXIT</term>
		/// <term>Premature termination</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_ERROR</term>
		/// <term>Formatted error message</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_WARNING</term>
		/// <term>Formatted warning message</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_USER</term>
		/// <term>User request message.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_INFO</term>
		/// <term>Informative message for log</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_FILESINUSE</term>
		/// <term>List of files currently in use that must be closed before being replaced</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_RESOLVESOURCE</term>
		/// <term>Request to determine a valid source location</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_RMFILESINUSE</term>
		/// <term>
		/// List of files currently in use that must be closed before being replaced. Available beginning with Windows Installer version
		/// 4.0. For more information about this message see Using Restart Manager with an External UI.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_OUTOFDISKSPACE</term>
		/// <term>Insufficient disk space message</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_ACTIONSTART</term>
		/// <term>Start of action message. This message includes the action name and description.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_ACTIONDATA</term>
		/// <term>Formatted data associated with the individual action item.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_PROGRESS</term>
		/// <term>Progress gauge information. This message includes information on units so far and total number of units.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_COMMONDATA</term>
		/// <term>Formatted dialog information for user interface.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_INITIALIZE</term>
		/// <term>Sent prior to UI initialization, no string data</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_TERMINATE</term>
		/// <term>Sent after UI termination, no string data</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_SHOWDIALOG</term>
		/// <term>Sent prior to display of authored dialog or wizard</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_INSTALLSTART</term>
		/// <term>Sent prior to installation of product.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLMESSAGE_INSTALLEND</term>
		/// <term>Sent after installation of product.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The following defaults should be used if any of the preceding messages are missing: MB_OK, no icon, and MB_DEFBUTTON1. There is
		/// no default installation message type; a message type is always specified.
		/// </para>
		/// </param>
		/// <param name="hRecord">
		/// Specifies a handle to the record object. For information about record objects, see the Record Processing Functions.
		/// </param>
		/// <returns>
		/// <para>The following return values map to the buttons specified by the message box style:</para>
		/// <para>IDOKIDCANCELIDABORTIDRETRYIDIGNOREIDYESIDNO</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This type of external UI handler should be used when it is known what type of errors or messages the caller is interested in,
		/// and wants to avoid the overhead of parsing the string message that is sent to an external UI handler of INSTALLUI_HANDLER type,
		/// but retrieve the data of interest from fields of hRecord.
		/// </para>
		/// <para>
		/// For more information on returning values from an external user interface handler, see the Returning Values from an External User
		/// Interface Handler topic. The hRecord object sent to the record-based external UI handler is owned by Windows Installer and is
		/// valid only for the callback's lifetime. The callback should extract from the record any data it needs and it should not close
		/// that handle.
		/// </para>
		/// <para>Any attempt by a record-based external UI handler to alter the data in the hRecord object will be ignored by Windows Installer.</para>
		/// <para>For more information about using a record-based external handler, see Monitoring an Installation Using MsiSetExternalUIRecord.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nc-msi-installui_handler_record INSTALLUI_HANDLER_RECORD
		// InstalluiHandlerRecord; int InstalluiHandlerRecord( LPVOID pvContext, UINT iMessageType, MSIHANDLE hRecord ) {...}
		[PInvokeData("msi.h", MSDNShortId = "NC:msi.INSTALLUI_HANDLER_RECORD")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate int INSTALLUI_HANDLER_RECORD(IntPtr pvContext, uint iMessageType, MSIHANDLE hRecord);

		/// <summary>
		/// The <c>MsiAdvertiseProduct</c> function generates an advertise script or advertises a product to the computer. The
		/// <c>MsiAdvertiseProduct</c> function enables the installer to write to a script the registry and shortcut information used to
		/// assign or publish a product. The script can be written to be consistent with a specified platform by using MsiAdvertiseProductEx.
		/// </summary>
		/// <param name="szPackagePath">The full path to the package of the product being advertised.</param>
		/// <param name="szScriptfilePath">
		/// <para>
		/// The full path to script file that will be created with the advertise information. To advertise the product locally to the
		/// computer, set ADVERTISEFLAGS_MACHINEASSIGN or ADVERTISEFLAGS_USERASSIGN.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ADVERTISEFLAGS_MACHINEASSIGN 0</term>
		/// <term>Set to advertise a per-machine installation of the product available to all users.</term>
		/// </item>
		/// <item>
		/// <term>ADVERTISEFLAGS_USERASSIGN 1</term>
		/// <term>Set to advertise a per-user installation of the product available to a particular user.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="szTransforms">
		/// A semicolon-delimited list of transforms to be applied. The list of transforms can be prefixed with the @ or | character to
		/// specify the secure caching of transforms. The @ prefix specifies secure-at-source transforms and the | prefix indicates secure
		/// full path transforms. For more information, see Secured Transforms. This parameter may be null.
		/// </param>
		/// <param name="lgidLanguage">The installation language to use if the source supports multiple languages.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>An error relating to an action</term>
		/// <term>See Error Codes.</term>
		/// </item>
		/// <item>
		/// <term>Initialization Error</term>
		/// <term>An initialization error occurred.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
		/// <term>
		/// This error is returned if an attempt is made to generate an advertise script on any platform other than Windows 2000 or Windows
		/// XP. Advertisement to the local computer is supported on all platforms.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks/>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiadvertiseproducta UINT MsiAdvertiseProductA( LPCSTR
		// szPackagePath, LPCSTR szScriptfilePath, LPCSTR szTransforms, LANGID lgidLanguage );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiAdvertiseProductA")]
		public static extern Win32Error MsiAdvertiseProduct([MarshalAs(UnmanagedType.LPTStr)] string szPackagePath,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string szScriptfilePath, [Optional, MarshalAs(UnmanagedType.LPTStr)] string szTransforms,
			ushort lgidLanguage);

		/// <summary>
		/// The <c>MsiAdvertiseProductEx</c> function generates an advertise script or advertises a product to the computer. This function
		/// enables Windows Installer to write to a script the registry and shortcut information used to assign or publish a product. The
		/// script can be written to be consistent with a specified platform by using <c>MsiAdvertiseProductEx</c>. The
		/// <c>MsiAdvertiseProductEx</c> function provides the same functionality as MsiAdvertiseProduct.
		/// </summary>
		/// <param name="szPackagePath">The full path to the package of the product being advertised.</param>
		/// <param name="szScriptfilePath">
		/// <para>
		/// The full path to the script file to be created with the advertised information. To advertise the product locally to the
		/// computer, set ADVERTISEFLAGS_MACHINEASSIGN or ADVERTISEFLAGS_USERASSIGN.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ADVERTISEFLAGS_MACHINEASSIGN 0</term>
		/// <term>Set to advertise a per-computer installation of the product available to all users.</term>
		/// </item>
		/// <item>
		/// <term>ADVERTISEFLAGS_USERASSIGN 1</term>
		/// <term>Set to advertise a per-user installation of the product available to a particular user.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="szTransforms">
		/// A semicolon–delimited list of transforms to be applied. The list of transforms can be prefixed with the @ or | character to
		/// specify the secure caching of transforms. The @ prefix specifies secure-at-source transforms and the | prefix indicates secure
		/// full path–transforms. For more information, see Secured Transforms. This parameter may be null.
		/// </param>
		/// <param name="lgidLanguage">The language to use if the source supports multiple languages.</param>
		/// <param name="dwPlatform">
		/// <para>
		/// Bit flags that control for which platform the installer should create the script. This parameter is ignored if szScriptfilePath
		/// is null. If dwPlatform is zero (0), then the script is created based on the current platform. This is the same functionality as
		/// MsiAdvertiseProduct. If dwPlatform is 1 or 2, the installer creates script for the specified platform.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>none 0</term>
		/// <term>Creates a script for the current platform.</term>
		/// </item>
		/// <item>
		/// <term>MSIARCHITECTUREFLAGS_X86 1</term>
		/// <term>Creates a script for the x86 platform.</term>
		/// </item>
		/// <item>
		/// <term>MSIARCHITECTUREFLAGS_IA64 2</term>
		/// <term>Creates a script for Itanium-based systems.</term>
		/// </item>
		/// <item>
		/// <term>MSIARCHITECTUREFLAGS_AMD64 4</term>
		/// <term>Creates a script for the x64 platform.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwOptions">
		/// <para>
		/// Bit flags that specify extra advertisement options. Nonzero value is only available in Windows Installer versions shipped with
		/// Windows Server 2003 and Windows XP with SP1 and later.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIADVERTISEOPTIONS_INSTANCE 1</term>
		/// <term>
		/// Multiple instances through product code changing transform support flag. Advertises a new instance of the product. Requires that
		/// the szTransforms parameter includes the instance transform that changes the product code. For more information, see Installing
		/// Multiple Instances of Products and Patches.
		/// </term>
		/// </item>
		/// </list>
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
		/// <term>An error that relates to an action</term>
		/// <term>For more information, see Error Codes.</term>
		/// </item>
		/// <item>
		/// <term>Initialization Error</term>
		/// <term>An initialization error has occurred.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
		/// <term>
		/// This error is returned if an attempt is made to generate an advertise script on any platform other than Windows 2000 or Windows
		/// XP. Advertisement to the local computer is supported on all platforms.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Multiple instances through product code–changing transforms is only available for Windows Installer versions shipping with
		/// Windows Server 2003 and Windows XP with SP1 and later.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiadvertiseproductexa UINT MsiAdvertiseProductExA( LPCSTR
		// szPackagePath, LPCSTR szScriptfilePath, LPCSTR szTransforms, LANGID lgidLanguage, DWORD dwPlatform, DWORD dwOptions );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiAdvertiseProductExA")]
		public static extern Win32Error MsiAdvertiseProductEx([MarshalAs(UnmanagedType.LPTStr)] string szPackagePath,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string szScriptfilePath, [Optional, MarshalAs(UnmanagedType.LPTStr)] string szTransforms,
			ushort lgidLanguage, MSIARCHITECTUREFLAGS dwPlatform, MSIADVERTISEOPTIONFLAGS dwOptions);

		/// <summary>The <c>MsiAdvertiseScript</c> function copies an advertised script file into the specified locations.</summary>
		/// <param name="szScriptFile">The full path to a script file generated by MsiAdvertiseProduct or MsiAdvertiseProductEx.</param>
		/// <param name="dwFlags">
		/// <para>
		/// The following bit flags from SCRIPTFLAGS control advertisement. The value of dwFlags can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SCRIPTFLAGS_CACHEINFO 0x001</term>
		/// <term>Include this flag if the icons need to be created or removed.</term>
		/// </item>
		/// <item>
		/// <term>SCRIPTFLAGS_SHORTCUTS 0x004</term>
		/// <term>Include this flag if the shortcuts need to be created or removed.</term>
		/// </item>
		/// <item>
		/// <term>SCRIPTFLAGS_MACHINEASSIGN 0x008</term>
		/// <term>Include this flag if the product to be assigned to a computer.</term>
		/// </item>
		/// <item>
		/// <term>SCRIPTFLAGS_REGDATA_CNFGINFO 0x020</term>
		/// <term>Include this flag if the configuration and management information in the registry data needs to be written or removed.</term>
		/// </item>
		/// <item>
		/// <term>SCRIPTFLAGS_VALIDATE_TRANSFORMS_LIST 0x040</term>
		/// <term>
		/// Include this flag to force validation of the transforms listed in the script against previously registered transforms for this
		/// product. Note that transform conflicts are detected using a string comparison that is case insensitive and are evaluated between
		/// per-user and per-machine installations across all contexts. If the list of transforms in the script does not match the
		/// transforms registered for the product, the function returns ERROR_INSTALL_TRANSFORM_FAILURE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SCRIPTFLAGS_REGDATA_CLASSINFO 0x080</term>
		/// <term>Include this flag if advertisement information in the registry related to COM classes needs to be written or removed.</term>
		/// </item>
		/// <item>
		/// <term>SCRIPTFLAGS_REGDATA_EXTENSIONINFO 0x100</term>
		/// <term>Include this flag if advertisement information in the registry related to an extension needs to be written or removed.</term>
		/// </item>
		/// <item>
		/// <term>SCRIPTFLAGS_REGDATA_APPINFO 0x180</term>
		/// <term>Include this flag if the advertisement information in the registry needs to be written or removed.</term>
		/// </item>
		/// <item>
		/// <term>SCRIPTFLAGS_REGDATA 0x1A0</term>
		/// <term>Include this flag if the advertisement information in the registry needs to be written or removed.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="phRegData">
		/// <para>
		/// A registry key under which temporary information about registry data is to be written. If this parameter is null, the registry
		/// data is placed under the appropriate key, based on whether the advertisement is per-user or per-machine. If this parameter is
		/// non-null, the script will write the registry data under the specified registry key rather than the normal location. In this
		/// case, the application will not get advertised to the user.
		/// </para>
		/// <para>
		/// Note that this registry key cannot be used when generating an advertisement of a product for a user or a computer because the
		/// provider of the registry key generally deletes the key. The registry key is located outside of the normal registry locations for
		/// shell, class, and .msi configuration information and it is not under <c>HKEY_CLASSES_ROOT</c>. This registry key is only
		/// intended for getting temporary information about registry data in a script.
		/// </para>
		/// </param>
		/// <param name="fRemoveItems">TRUE if specified items are to be removed instead of being created.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The calling process was not running under the LocalSystem account.</term>
		/// </item>
		/// <item>
		/// <term>An error relating to an action</term>
		/// <term>See Error Codes.</term>
		/// </item>
		/// <item>
		/// <term>Initialization Error</term>
		/// <term>An error relating to initialization occurred.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
		/// <term>This function is only available on Windows 2000 and Windows XP.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The process calling this function must be running under the LocalSystem account. To advertise an application for per-user
		/// installation to a targeted user, the thread that calls this function must impersonate the targeted user. If the thread calling
		/// this function is not impersonating a targeted user, the application is advertised to all users for installation with elevated privileges.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiadvertisescripta UINT MsiAdvertiseScriptA( LPCSTR szScriptFile,
		// DWORD dwFlags, PHKEY phRegData, BOOL fRemoveItems );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiAdvertiseScriptA")]
		public static extern Win32Error MsiAdvertiseScript([MarshalAs(UnmanagedType.LPTStr)] string szScriptFile,
			SCRIPTFLAGS dwFlags, [In, Optional] HKEY phRegData, [MarshalAs(UnmanagedType.Bool)] bool fRemoveItems);

		/// <summary>
		/// The <c>MsiApplyMultiplePatches</c> function applies one or more patches to products eligible to receive the patches. The
		/// <c>MsiApplyMultiplePatches</c> function sets the PATCH property with a list of patches delimited by semicolons and invokes the
		/// patching of the target products. Other properties can be set using a properties list.
		/// </summary>
		/// <param name="szPatchPackages">
		/// A semicolon-delimited list of the paths to patch files as a single string. For example: ""c:\sus\download\cache\Office\sp1.msp;
		/// c:\sus\download\cache\Office\QFE1.msp; c:\sus\download\cache\Office\QFEn.msp" "
		/// </param>
		/// <param name="szProductCode">
		/// This parameter is the ProductCode GUID of the product to be patched. The user or application calling
		/// <c>MsiApplyMultiplePatches</c> must have privileges to apply patches. When this parameter is <c>NULL</c>, the patches are
		/// applied to all eligible products. When this parameter is non- <c>NULL</c>, the patches are applied only to the specified product.
		/// </param>
		/// <param name="szPropertiesList">
		/// <para>
		/// A null-terminated string that specifies command–line property settings used during the patching of products. If there are no
		/// command–line property settings, pass in a <c>NULL</c> pointer. An empty string is an invalid parameter. These properties are
		/// shared by all target products. For more information, see About Properties and Setting Public Property Values on the Command Line.
		/// </para>
		/// <para>
		/// <c>Note</c> The properties list should not contain the PATCH property. If the <c>PATCH</c> property is set in the command line
		/// the value is ignored and is overwritten with the patches being applied.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>The <c>MsiApplyMultiplePatches</c> function returns the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>Some arguments passed in are incorrect or contradicting.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>
		/// The function completed and all products are successfully patched. ERROR_SUCCESS is returned only if all the products eligible
		/// for the patches are patched successfully. If none of the new patches are applicable, MsiApplyMultiplePatches returns
		/// ERROR_SUCCESS and product state remains unchanged.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS_REBOOT_INITIATED</term>
		/// <term>
		/// The restart initiated by the last transaction terminated this call to MsiApplyMultiplePatches. All the target products may not
		/// have been patched.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS_REBOOT_REQUIRED</term>
		/// <term>
		/// The restart required by the last transaction terminated this call to MsiApplyMultiplePatches. All target products may not have
		/// been patched.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATCH_PACKAGE_OPEN_FAILED</term>
		/// <term>One of the patch packages provide could not be opened.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATCH_PACKAGE_INVALID</term>
		/// <term>One of the patch packages provide is not a valid one.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATCH_PACKAGE_UNSUPPORTED</term>
		/// <term>One of the patch packages is unsupported.</term>
		/// </item>
		/// <item>
		/// <term>Any error in Winerror.h</term>
		/// <term>Implies possible partial completion or that one or more transactions failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks/>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiapplymultiplepatchesa UINT MsiApplyMultiplePatchesA( LPCSTR
		// szPatchPackages, LPCSTR szProductCode, LPCSTR szPropertiesList );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiApplyMultiplePatchesA")]
		public static extern Win32Error MsiApplyMultiplePatches([MarshalAs(UnmanagedType.LPTStr)] string szPatchPackages,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string szProductCode, [Optional, MarshalAs(UnmanagedType.LPTStr)] string szPropertiesList);

		/// <summary>
		/// For each product listed by the patch package as eligible to receive the patch, the <c>MsiApplyPatch</c> function invokes an
		/// installation and sets the PATCH property to the path of the patch package.
		/// </summary>
		/// <param name="szPatchPackage">A null-terminated string specifying the full path to the patch package.</param>
		/// <param name="szInstallPackage">
		/// <para>
		/// If eInstallType is set to INSTALLTYPE_NETWORK_IMAGE, this parameter is a null-terminated string that specifies a path to the
		/// product that is to be patched. The installer applies the patch to every eligible product listed in the patch package if
		/// szInstallPackage is set to null and eInstallType is set to INSTALLTYPE_DEFAULT.
		/// </para>
		/// <para>
		/// If eInstallType is INSTALLTYPE_SINGLE_INSTANCE, the installer applies the patch to the product specified by szInstallPackage. In
		/// this case, other eligible products listed in the patch package are ignored and the szInstallPackage parameter contains the
		/// null-terminated string representing the product code of the instance to patch. This type of installation requires the installer
		/// running Windows Server 2003 or Windows XP.
		/// </para>
		/// </param>
		/// <param name="eInstallType">
		/// <para>This parameter specifies the type of installation to patch.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Type of installation</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INSTALLTYPE_NETWORK_IMAGE</term>
		/// <term>
		/// Specifies an administrative installation. In this case, szInstallPackage must be set to a package path. A value of 1 for
		/// INSTALLTYPE_NETWORK_IMAGE sets this for an administrative installation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INSTALLTYPE_DEFAULT</term>
		/// <term>Searches system for products to patch. In this case, szInstallPackage must be 0.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLTYPE_SINGLE_INSTANCE</term>
		/// <term>
		/// Patch the product specified by szInstallPackage. szInstallPackage is the product code of the instance to patch. This type of
		/// installation requires the installer running Windows Server 2003 or Windows XP with SP1. For more information see, Installing
		/// Multiple Instances of Products and Patches.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="szCommandLine">
		/// A null-terminated string that specifies command line property settings. See About Properties and Setting Public Property Values
		/// on the Command Line. See the Remarks section.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATCH_PACKAGE_OPEN_FAILED</term>
		/// <term>Patch package could not be opened.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATCH_PACKAGE_INVALID</term>
		/// <term>The patch package is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATCH_PACKAGE_UNSUPPORTED</term>
		/// <term>The patch package is unsupported.</term>
		/// </item>
		/// <item>
		/// <term>An error relating to an action</term>
		/// <term>See Error Codes.</term>
		/// </item>
		/// <item>
		/// <term>Initialization Error</term>
		/// <term>An initialization error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Because the list delimiter for transforms, sources, and patches is a semicolon, this character should not be used for file names
		/// or paths.
		/// </para>
		/// <para>
		/// <c>Note</c> You must set the REINSTALL property on the command line when applying a small update or minor upgrade patch. Without
		/// this property, the patch is registered on the system but cannot update files. For patches that do not use a Custom Action Type
		/// 51 to automatically set the <c>REINSTALL</c> and REINSTALLMODE properties, the <c>REINSTALL</c> property must be explicitly set
		/// with the szCommandLine parameter. Set the <c>REINSTALL</c> property to list the features affected by the patch, or use a
		/// practical default setting of "REINSTALL=ALL". The default value of the <c>REINSTALLMODE</c> property is "omus". Beginning with
		/// Windows Installer version 3.0, the <c>REINSTALL</c> property is configured by the installer and does not need to be set on the
		/// command line.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiapplypatcha UINT MsiApplyPatchA( LPCSTR szPatchPackage, LPCSTR
		// szInstallPackage, INSTALLTYPE eInstallType, LPCSTR szCommandLine );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiApplyPatchA")]
		public static extern Win32Error MsiApplyPatch([MarshalAs(UnmanagedType.LPTStr)] string szPatchPackage,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string szInstallPackage, INSTALLTYPE eInstallType,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string szCommandLine);

		/// <summary>
		/// <para>
		/// The <c>MsiBeginTransaction</c> function starts transaction processing of a multiple-package installation and returns an
		/// identifier for the transaction. The MsiEndTransaction function ends the transaction.
		/// </para>
		/// <para><c>Windows Installer 4.0 and earlier:</c> Not supported. This function is available beginning with Windows Installer 4.5.</para>
		/// </summary>
		/// <param name="szName">Name of the multiple-package installation.</param>
		/// <param name="dwTransactionAttributes">
		/// <para>Attributes of the multiple-package installation.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>When 0 or no value is set it Windows Installer closes the UI from the previous installation.</term>
		/// </item>
		/// <item>
		/// <term>MSITRANSACTION_CHAIN_EMBEDDEDUI</term>
		/// <term>Set this attribute to request that the Windows Installer not shutdown the embedded UI until the transaction is complete.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="phTransactionHandle">
		/// Transaction ID is a <c>MSIHANDLE</c> value that identifies the transaction. Only one process can own a transaction at a time.
		/// </param>
		/// <param name="phChangeOfOwnerEvent">
		/// This parameter returns a handle to an event that is set when the MsiJoinTransaction function changes the owner of the
		/// transaction to a new owner. The current owner can use this to determine when ownership of the transaction has changed. Leaving a
		/// transaction without an owner will roll back the transaction.
		/// </param>
		/// <returns>
		/// <para>The <c>MsiBeginTransaction</c> function returns the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSTALL_SERVICE_FAILURE</term>
		/// <term>The installation service could not be accessed. This function requires the Windows Installer service.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSTALL_ALREADY_RUNNING</term>
		/// <term>
		/// Only one transaction can be open on a system at a time. The function returns this error if called while another transaction is running.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid parameter is passed to the function.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ROLLBACK_DISABLED</term>
		/// <term>Rollback Installations have been disabled by the DISABLEROLLBACK property or DisableRollback policy.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks/>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msibegintransactiona UINT MsiBeginTransactionA( LPCSTR szName,
		// DWORD dwTransactionAttributes, MSIHANDLE *phTransactionHandle, HANDLE *phChangeOfOwnerEvent );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiBeginTransactionA")]
		public static extern Win32Error MsiBeginTransaction([MarshalAs(UnmanagedType.LPTStr)] string szName, MSITRANSACTION dwTransactionAttributes,
			out PMSIHANDLE phTransactionHandle, out System.Threading.EventWaitHandle phChangeOfOwnerEvent);

		/// <summary>
		/// The <c>MsiCloseAllHandles</c> function closes all open installation handles allocated by the current thread. This is a
		/// diagnostic function and should not be used for cleanup.
		/// </summary>
		/// <returns>
		/// This function returns 0 if all handles are closed. Otherwise, the function returns the number of handles open prior to its call.
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>MsiCloseAllHandles</c> only closes handles allocated by the calling thread, and does not affect handles allocated by other
		/// threads, such as the install handle passed to custom actions.
		/// </para>
		/// <para>
		/// The MsiOpenPackage function opens a handle to a package and the MsiOpenProduct function opens a handle to a product. These
		/// function are for use with functions that access the product database.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msicloseallhandles UINT MsiCloseAllHandles();
		[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiCloseAllHandles")]
		public static extern uint MsiCloseAllHandles();

		/// <summary>The <c>MsiCloseHandle</c> function closes an open installation handle.</summary>
		/// <param name="hAny">Specifies any open installation handle.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>An invalid handle was passed to the function.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function succeeded.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para><c>MsiCloseHandle</c> must be called from the same thread that requested the creation of the handle.</para>
		/// <para>The following functions supply handles that should be closed after use by calling <c>MsiCloseHandle</c>:</para>
		/// <para>
		/// MsiCreateRecord MsiGetActiveDatabase MsiGetLastErrorRecord MsiOpenPackage MsiOpenProduct MsiOpenDatabase MsiDatabaseOpenView
		/// MsiViewFetch MsiViewGetColumnInfo MsiDatabaseGetPrimaryKeys MsiGetSummaryInformation MsiEnableUIPreview Note that when writing
		/// custom actions, it is recommended to use variables of type PMSIHANDLE because the installer closes PMSIHANDLE objects as they go
		/// out of scope, whereas you must close MSIHANDLE objects by calling <c>MsiCloseHandle</c>.
		/// </para>
		/// <para>For example, if you use code like this:</para>
		/// <para>MSIHANDLE hRec = MsiCreateRecord(3);</para>
		/// <para>Change it to:</para>
		/// <para>PMSIHANDLE hRec = MsiCreateRecord(3);</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiclosehandle UINT MsiCloseHandle( MSIHANDLE hAny );
		[DllImport(Lib_Msi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiCloseHandle")]
		public static extern Win32Error MsiCloseHandle(MSIHANDLE hAny);

		/// <summary>
		/// The <c>MsiCollectUserInfo</c> function obtains and stores the user information and product ID from an installation wizard.
		/// </summary>
		/// <param name="szProduct">Specifies the product code of the product for which the user information is collected.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid parameter was passed to the function.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function succeeded.</term>
		/// </item>
		/// <item>
		/// <term>An error relating to an action</term>
		/// <term>See Error Codes.</term>
		/// </item>
		/// <item>
		/// <term>Initialization Error</term>
		/// <term>An error relating to initialization occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>MsiCollectUserInfo</c> function is typically called by an application during the first run of the application. The
		/// application first calls MsiGetUserInfo. If that call fails, the application calls <c>MsiCollectUserInfo</c>.
		/// <c>MsiCollectUserInfo</c> opens the product's installation package and invokes a wizard sequence that collects user information.
		/// Upon completion of the sequence, user information is registered. Since this API requires an authored user interface, the user
		/// interface level should be set to full by calling MsiSetInternalUI as INSTALLUILEVEL_FULL.
		/// </para>
		/// <para>The <c>MsiCollectUserInfo</c> invokes a FirstRun Dialog.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msicollectuserinfow UINT MsiCollectUserInfoW( LPCWSTR szProduct );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiCollectUserInfoW")]
		public static extern Win32Error MsiCollectUserInfo([MarshalAs(UnmanagedType.LPTStr)] string szProduct);

		/// <summary>The <c>MsiConfigureFeature</c> function configures the installed state for a product feature.</summary>
		/// <param name="szProduct">Specifies the product code for the product to be configured.</param>
		/// <param name="szFeature">Specifies the feature ID for the feature to be configured.</param>
		/// <param name="eInstallState">
		/// <para>Specifies the installation state for the feature. This parameter must be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INSTALLSTATE_ADVERTISED</term>
		/// <term>The feature is advertised</term>
		/// </item>
		/// <item>
		/// <term>INSTALLSTATE_LOCAL</term>
		/// <term>The feature is installed locally.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLSTATE_ABSENT</term>
		/// <term>The feature is uninstalled.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLSTATE_SOURCE</term>
		/// <term>The feature is installed to run from source.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLSTATE_DEFAULT</term>
		/// <term>The feature is installed to its default location.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid parameter is passed to the function.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function succeeds.</term>
		/// </item>
		/// <item>
		/// <term>An error relating to an action</term>
		/// <term>For more information, see Error Codes.</term>
		/// </item>
		/// <item>
		/// <term>Initialization Error</term>
		/// <term>An error that relates to the initialization has occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks/>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiconfigurefeaturew UINT MsiConfigureFeatureW( LPCWSTR szProduct,
		// LPCWSTR szFeature, INSTALLSTATE eInstallState );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiConfigureFeatureW")]
		public static extern Win32Error MsiConfigureFeature([MarshalAs(UnmanagedType.LPTStr)] string szProduct,
			[MarshalAs(UnmanagedType.LPTStr)] string szFeature, INSTALLSTATE eInstallState);

		/// <summary>The <c>MsiConfigureProduct</c> function installs or uninstalls a product.</summary>
		/// <param name="szProduct">Specifies the product code for the product to be configured.</param>
		/// <param name="iInstallLevel">
		/// <para>
		/// Specifies how much of the product should be installed when installing the product to its default state. The iInstallLevel
		/// parameter is ignored, and all features are installed, if the eInstallState parameter is set to any other value than INSTALLSTATE_DEFAULT.
		/// </para>
		/// <para>This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INSTALLLEVEL_DEFAULT</term>
		/// <term>The authored default features are installed.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLLEVEL_MINIMUM</term>
		/// <term>
		/// Only the required features are installed. You can specify a value between INSTALLLEVEL_MINIMUM and INSTALLLEVEL_MAXIMUM to
		/// install a subset of available features.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INSTALLLEVEL_MAXIMUM</term>
		/// <term>
		/// All features are installed. You can specify a value between INSTALLLEVEL_MINIMUM and INSTALLLEVEL_MAXIMUM to install a subset of
		/// available features.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="eInstallState">
		/// <para>Specifies the installation state for the product. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INSTALLSTATE_LOCAL</term>
		/// <term>The product is to be installed with all features installed locally.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLSTATE_ABSENT</term>
		/// <term>The product is uninstalled.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLSTATE_SOURCE</term>
		/// <term>The product is to be installed with all features installed to run from source.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLSTATE_DEFAULT</term>
		/// <term>The product is to be installed with all features installed to the default states specified in the Feature Table.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLSTATE_ADVERTISED</term>
		/// <term>The product is advertised.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid parameter is passed to the function.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function succeeds.</term>
		/// </item>
		/// <item>
		/// <term>An error that relates to an action</term>
		/// <term>For more information, see Error Codes.</term>
		/// </item>
		/// <item>
		/// <term>Initialization Error</term>
		/// <term>An error that relates to initialization.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>MsiConfigureProduct</c> function displays the user interface (UI) using the current settings. User interface settings can
		/// be changed by using MsiSetInternalUI, MsiSetExternalUI or MsiSetExternalUIRecord.
		/// </para>
		/// <para>
		/// The iInstallLevel parameter is ignored, and all features of the product are installed, if the eInstallState parameter is set to
		/// any other value than INSTALLSTATE_DEFAULT. To control the installation of individual features when the eInstallState parameter
		/// is not set to INSTALLSTATE_DEFAULT, use MsiConfigureFeature.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiconfigureproducta UINT MsiConfigureProductA( LPCSTR szProduct,
		// int iInstallLevel, INSTALLSTATE eInstallState );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiConfigureProductA")]
		public static extern Win32Error MsiConfigureProduct([MarshalAs(UnmanagedType.LPTStr)] string szProduct, INSTALLLEVEL iInstallLevel,
			INSTALLSTATE eInstallState);

		/// <summary>The <c>MsiConfigureProductEx</c> function installs or uninstalls a product. A product command line can also be specified.</summary>
		/// <param name="szProduct">Specifies the product code for the product to be configured.</param>
		/// <param name="iInstallLevel">
		/// <para>
		/// Specifies how much of the product should be installed when installing the product to its default state. The iInstallLevel
		/// parameters are ignored, and all features are installed, if the eInstallState parameter is set to any value other than <c>INSTALLSTATE_DEFAULT</c>.
		/// </para>
		/// <para>This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INSTALLLEVEL_DEFAULT</term>
		/// <term>The authored default features are installed.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLLEVEL_MINIMUM</term>
		/// <term>
		/// Only the required features are installed. You can specify a value between INSTALLLEVEL_MINIMUM and INSTALLLEVEL_MAXIMUM to
		/// install a subset of available features.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INSTALLLEVEL_MAXIMUM</term>
		/// <term>
		/// All features are installed. You can specify a value between INSTALLLEVEL_MINIMUM and INSTALLLEVEL_MAXIMUM to install a subset of
		/// available features.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="eInstallState">
		/// <para>Specifies the installation state for the product. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INSTALLSTATE_LOCAL</term>
		/// <term>The product is to be installed with all features installed locally.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLSTATE_ABSENT</term>
		/// <term>The product is uninstalled.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLSTATE_SOURCE</term>
		/// <term>The product is to be installed with all features installed to run from source.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLSTATE_DEFAULT</term>
		/// <term>The product is to be installed with all features installed to the default states specified in the Feature Table.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLSTATE_ADVERTISED</term>
		/// <term>The product is advertised.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="szCommandLine">
		/// Specifies the command-line property settings. This should be a list of the format Property=Setting Property=Setting. For more
		/// information, see About Properties.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid parameter is passed to the function.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function succeeded.</term>
		/// </item>
		/// <item>
		/// <term>An error that relates to an action</term>
		/// <term>For more information, see Error Codes.</term>
		/// </item>
		/// <item>
		/// <term>Initialization Error</term>
		/// <term>An error relating to initialization occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The command line passed in as szCommandLine can contain any of the Feature Installation Options Properties. In this case, the
		/// eInstallState passed must be <c>INSTALLSTATE_DEFAULT</c>.
		/// </para>
		/// <para>
		/// The iInstallLevel parameter is ignored and all features of the product are installed if the eInstallState parameter is set to
		/// any other value than <c>INSTALLSTATE_DEFAULT</c>. To control the installation of individual features when the eInstallState
		/// parameter is not set to <c>INSTALLSTATE_DEFAULT</c> use MsiConfigureFeature.
		/// </para>
		/// <para>
		/// The <c>MsiConfigureProductEx</c> function displays the user interface using the current settings. User interface settings can be
		/// changed with MsiSetInternalUI, MsiSetExternalUI, or MsiSetExternalUIRecord.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiconfigureproductexa UINT MsiConfigureProductExA( LPCSTR
		// szProduct, int iInstallLevel, INSTALLSTATE eInstallState, LPCSTR szCommandLine );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiConfigureProductExA")]
		public static extern Win32Error MsiConfigureProductEx([MarshalAs(UnmanagedType.LPTStr)] string szProduct, INSTALLLEVEL iInstallLevel,
			INSTALLSTATE eInstallState, [Optional, MarshalAs(UnmanagedType.LPTStr)] string szCommandLine);

		/// <summary>
		/// The <c>MsiDetermineApplicablePatches</c> function takes a set of patch files, XML files, and XML blobs and determines which
		/// patches apply to a specified Windows Installer package and in what sequence. The function can account for superseded or obsolete
		/// patches. This function does not account for products or patches that are installed on the system that are not specified in the set.
		/// </summary>
		/// <param name="szProductPackagePath">
		/// Full path to an .msi file. The function determines the patches that are applicable to this package and in what sequence.
		/// </param>
		/// <param name="cPatchInfo">Number of patches in the array. Must be greater than zero.</param>
		/// <param name="pPatchInfo">Pointer to an array of MSIPATCHSEQUENCEINFO structures.</param>
		/// <returns>
		/// <para>The <c>MsiDetermineApplicablePatches</c> function returns the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_FUNCTION_FAILED</term>
		/// <term>The function failed in a manner not covered in the other error codes.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An argument is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATCH_NO_SEQUENCE</term>
		/// <term>No valid sequence could be found for the set of patches.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The patches were successfully sorted.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>The .msi file was not found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATH_NOT_FOUND</term>
		/// <term>The path to the .msi file was not found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PATCH_XML</term>
		/// <term>The XML patch data is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSTALL_PACKAGE_OPEN_FAILED</term>
		/// <term>An installation package referenced by path cannot be opened.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
		/// <term>This error can be returned if the function was called from a custom action or if MSXML 3.0 is not installed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If this function is called from a custom action it fails and returns ERROR_CALL_NOT_IMPLEMENTED. The function requires MSXML
		/// version 3.0 to process XML and returns ERROR_CALL_NOT_IMPLEMENTED if MSXML 3.0 is not installed.
		/// </para>
		/// <para>
		/// The <c>MsiDetermineApplicablePatches</c> function sets the <c>uStatus</c> and <c>dwOrder</c> members of each
		/// MSIPATCHSEQUENCEINFO structure pointed to by pPatchInfo. Each structure contains information about a particular patch.
		/// </para>
		/// <para>
		/// If the function succeeds, the MSIPATCHSEQUENCEINFO structure of every patch that can be applied to the product returns with a
		/// <c>uStatus</c> of ERROR_SUCCESS and a <c>dwOrder</c> greater than or equal to zero. The values of <c>dwOrder</c> greater than or
		/// equal to zero indicate the best application sequence for the patches starting with zero.
		/// </para>
		/// <para>
		/// If the function succeeds, patches excluded from the best patching sequence return a MSIPATCHSEQUENCEINFO structure with a
		/// <c>dwOrder</c> equal to -1. In these cases, a <c>uStatus</c> field of ERROR_SUCCESS indicates a patch that is obsolete or
		/// superseded for the product. A <c>uStatus</c> field of ERROR_PATCH_TARGET_NOT_FOUND indicates a patch that is inapplicable to the product.
		/// </para>
		/// <para>
		/// If the function fails, the MSIPATCHSEQUENCEINFO structure for every patch returns a <c>dwOrder</c> equal to -1. In this case,
		/// the <c>uStatus</c> fields can contain errors with more information about individual patches. For example,
		/// ERROR_PATCH_NO_SEQUENCE is returned for patches that have circular sequencing information.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msidetermineapplicablepatchesa UINT MsiDetermineApplicablePatchesA(
		// LPCSTR szProductPackagePath, DWORD cPatchInfo, PMSIPATCHSEQUENCEINFOA pPatchInfo );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiDetermineApplicablePatchesA")]
		public static extern Win32Error MsiDetermineApplicablePatches([MarshalAs(UnmanagedType.LPTStr)] string szProductPackagePath,
			uint cPatchInfo, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] MSIPATCHSEQUENCEINFO[] pPatchInfo);

		/// <summary>
		/// The <c>MsiDeterminePatchSequence</c> function takes a set of patch files, XML files, and XML blobs and determines the best
		/// sequence of application for the patches to a specified installed product. This function accounts for patches that have already
		/// been applied to the product and accounts for obsolete and superseded patches.
		/// </summary>
		/// <param name="szProductCode">
		/// The product that is the target for the set of patches. The value must be the ProductCode GUID for the product.
		/// </param>
		/// <param name="szUserSid">
		/// Null-terminated string that specifies a security identifier (SID) of a user. This parameter restricts the context of enumeration
		/// for this user account. This parameter cannot be the special SID strings "S-1-1-0" (everyone) or "S-1-5-18" (local system). For
		/// the machine context dwContext is set to <c>MSIINSTALLCONTEXT_MACHINE</c> and szUserSid must be <c>NULL</c>. For the current user
		/// context szUserSid can be null and dwContext can be set to <c>MSIINSTALLCONTEXT_USERMANAGED</c> or <c>MSIINSTALLCONTEXT_USERUNMANAGED</c>.
		/// </param>
		/// <param name="dwContext">
		/// <para>
		/// Restricts the enumeration to a per-user-unmanaged, per-user-managed, or per-machine context. This parameter can be any one of
		/// the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Type of context</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
		/// <term>
		/// Patches are considered for all per-user-managed installations of the product for the user specified by szUserSid. A null
		/// szUserSid with this context means the current user.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
		/// <term>
		/// Patches are considered for all per-user-unmanaged installations for the user specified by szUserSid. A null szUserSid with this
		/// context means the current user.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_MACHINE</term>
		/// <term>
		/// Patches are considered for the per-machine installation. When dwContext is set to MSIINSTALLCONTEXT_MACHINE the szUserSid
		/// parameter must be null.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="cPatchInfo">The number of patches in the array.</param>
		/// <param name="pPatchInfo">Pointer to an array of MSIPATCHSEQUENCEINFO structures.</param>
		/// <returns>
		/// <para>The <c>MsiDeterminePatchSequence</c> function returns the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_FUNCTION_FAILED</term>
		/// <term>The function failed in a manner not covered in the other error codes.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An argument is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATCH_NO_SEQUENCE</term>
		/// <term>No valid sequence could be found for the set of patches.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSTALL_PACKAGE_OPEN_FAILED</term>
		/// <term>An installation package referenced by path cannot be opened.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The patches were successfully sorted.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>The .msi file was not found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATH_NOT_FOUND</term>
		/// <term>The path to the .msi file was not found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PATCH_XML</term>
		/// <term>The XML patch data is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSTALL_PACKAGE_INVALID</term>
		/// <term>The installation package was invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>A user that is not an administrator attempted to call the function with a context of a different user.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_CONFIGURATION</term>
		/// <term>The configuration data for a registered patch or product is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNKNOWN_PRODUCT</term>
		/// <term>The ProductCode GUID specified is not registered.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FUNCTION_NOT_CALLED</term>
		/// <term>
		/// Windows Installer version 3.0 is required to determine the best patch sequence. The function was called with szProductCode not
		/// yet installed with Windows Installer version 3.0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
		/// <term>This error can be returned if the function was called from a custom action or if MSXML 3.0 is not installed.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNKNOWN_PATCH</term>
		/// <term>The specified patch is unknown.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Users that do not have administrator privileges can call this function only in their own or machine context. Users that are
		/// administrators can call it for other users.
		/// </para>
		/// <para>
		/// If this function is called from a custom action it fails and returns <c>ERROR_CALL_NOT_IMPLEMENTED</c>. The function requires
		/// MSXML version 3.0 to process XML and returns <c>ERROR_CALL_NOT_IMPLEMENTED</c> if MSXML 3.0 is not installed.
		/// </para>
		/// <para>
		/// The <c>MsiDeterminePatchSequence</c> function sets the <c>uStatus</c> and <c>dwOrder</c> members of each MSIPATCHSEQUENCEINFO
		/// structure pointed to by pPatchInfo. Each structure contains information about a particular patch.
		/// </para>
		/// <para>
		/// If the function succeeds, the MSIPATCHSEQUENCEINFO structure of every patch that can be applied to the product returns with a
		/// <c>uStatus</c> of <c>ERROR_SUCCESS</c> and a <c>dwOrder</c> greater than or equal to zero. The values of <c>dwOrder</c> greater
		/// than or equal to zero indicate the best application sequence for the patches starting with zero.
		/// </para>
		/// <para>
		/// If the function succeeds, patches excluded from the best patching sequence return a MSIPATCHSEQUENCEINFO structure with a
		/// <c>dwOrder</c> equal to -1. In these cases, a <c>uStatus</c> field of <c>ERROR_SUCCESS</c> indicates a patch that is obsolete or
		/// superseded for the product. A <c>uStatus</c> field of <c>ERROR_PATCH_TARGET_NOT_FOUND</c> indicates a patch that is inapplicable
		/// to the product.
		/// </para>
		/// <para>
		/// If the function fails, the MSIPATCHSEQUENCEINFO structure for every patch returns a <c>dwOrder</c> equal to -1. In this case,
		/// the <c>uStatus</c> fields can contain errors with more information about individual patches. For example,
		/// <c>ERROR_PATCH_NO_SEQUENCE</c> is returned for patches that have circular sequencing information.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msideterminepatchsequencea UINT MsiDeterminePatchSequenceA( LPCSTR
		// szProductCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, DWORD cPatchInfo, PMSIPATCHSEQUENCEINFOA pPatchInfo );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiDeterminePatchSequenceA")]
		public static extern Win32Error MsiDeterminePatchSequence([MarshalAs(UnmanagedType.LPTStr)] string szProductCode,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string szUserSid, MSIINSTALLCONTEXT dwContext, uint cPatchInfo,
			[In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] MSIPATCHSEQUENCEINFO[] pPatchInfo);

		/// <summary>
		/// The <c>MsiEnableLog</c> function sets the log mode for all subsequent installations that are initiated in the calling process.
		/// </summary>
		/// <param name="dwLogMode">
		/// <para>Specifies the log mode. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INSTALLLOGMODE_FATALEXIT</term>
		/// <term>Logs out of memory or fatal exit information.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLLOGMODE_ERROR</term>
		/// <term>Logs the error messages.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLLOGMODE_EXTRADEBUG</term>
		/// <term>
		/// Sends extra debugging information, such as handle creation information, to the log file. Windows 2000 and Windows XP: This
		/// feature is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INSTALLLOGMODE_WARNING</term>
		/// <term>Logs the warning messages.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLLOGMODE_USER</term>
		/// <term>Logs the user requests.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLLOGMODE_INFO</term>
		/// <term>Logs the status messages that are not displayed.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLLOGMODE_RESOLVESOURCE</term>
		/// <term>Request to determine a valid source location.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLLOGMODE_OUTOFDISKSPACE</term>
		/// <term>Indicates insufficient disk space.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLLOGMODE_ACTIONSTART</term>
		/// <term>Logs the start of new installation actions.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLLOGMODE_ACTIONDATA</term>
		/// <term>Logs the data record with the installation action.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLLOGMODE_COMMONDATA</term>
		/// <term>Logs the parameters for user-interface initialization.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLLOGMODE_PROPERTYDUMP</term>
		/// <term>Logs the property values at termination.</term>
		/// </item>
		/// <item>
		/// <term>INSTALLLOGMODE_VERBOSE</term>
		/// <term>
		/// Logs the information in all the other log modes, except for INSTALLLOGMODE_EXTRADEBUG. This sends large amounts of information
		/// to a log file not generally useful to users. May be used for technical support.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INSTALLLOGMODE_LOGONLYONERROR</term>
		/// <term>
		/// Logging information is collected but is is less frequently saved to the log file. This can improve the performance of some
		/// installations, but may have little benefit for large installations. The log file is removed when the installation succeeds. If
		/// the installation fails, all logging information is saved to the log file. Windows Installer 2.0: This log mode is not available.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="szLogFile">
		/// Specifies the string that holds the full path to the log file. Entering a null disables logging, in which case dwlogmode is
		/// ignored. If a path is supplied, then dwlogmode must not be zero.
		/// </param>
		/// <param name="dwLogAttributes">
		/// <para>Specifies how frequently the log buffer is to be flushed.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INSTALLLOGATTRIBUTES_APPEND</term>
		/// <term>
		/// If this value is set, the installer appends the existing log specified by szLogFile. If not set, any existing log specified by
		/// szLogFile is overwritten.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INSTALLLOGATTRIBUTES_FLUSHEACHLINE</term>
		/// <term>
		/// Forces the log buffer to be flushed after each line. If this value is not set, the installer flushes the log buffer after 20
		/// lines by calling FlushFileBuffers.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid log mode was specified.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function succeeded.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>For a description of the Logging policy, see System Policy.</para>
		/// <para>
		/// The path to the log file location must already exist when using this function. The Installer does not create the directory
		/// structure for the log file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienableloga UINT MsiEnableLogA( DWORD dwLogMode, LPCSTR
		// szLogFile, DWORD dwLogAttributes );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnableLogA")]
		public static extern Win32Error MsiEnableLog(INSTALLLOGMODE dwLogMode, [Optional, MarshalAs(UnmanagedType.LPTStr)] string szLogFile,
			INSTALLLOGATTRIBUTES dwLogAttributes);

		/// <summary>
		/// <para>
		/// The <c>MsiEndTransaction</c> function can commit or roll back all the installations belonging to the transaction opened by the
		/// MsiBeginTransaction function. This function should be called by the current owner of the transaction.
		/// </para>
		/// <para><c>Windows Installer 4.0 and earlier:</c> Not supported. This function is available beginning with Windows Installer 4.5.</para>
		/// </summary>
		/// <param name="dwTransactionState">
		/// <para>
		/// The value of this parameter determines whether the installer commits or rolls back all the installations belonging to the
		/// transaction. The value can be one of the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSITRANSACTIONSTATE_ROLLBACK</term>
		/// <term>
		/// Performs a Rollback Installation to undo changes to the system belonging to the transaction opened by the MsiBeginTransaction function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSITRANSACTIONSTATE_COMMIT</term>
		/// <term>
		/// Commits all changes to the system belonging to the transaction. Runs any Commit Custom Actions and commits to the system any
		/// changes to Win32 or common language runtime assemblies. Deletes the rollback script, and after using this option, the
		/// transaction's changes can no longer be undone with a Rollback Installation.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>The <c>MsiEndTransaction</c> function returns the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>A transaction can be ended only by the current owner.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSTALL_FAILURE</term>
		/// <term>An installation belonging to the transaction could not be completed.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSTALL_ALREADY_RUNNING</term>
		/// <term>An installation belonging to the transaction is still in progress.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ROLLBACK_DISABLED</term>
		/// <term>
		/// An installation belonging to the transaction did not complete. During the installation, the DisableRollback action disabled
		/// rollback installations of the package. The installer rolls back the installation up to the point where rollback was disabled,
		/// and the function returns this error.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiendtransaction UINT MsiEndTransaction( DWORD dwTransactionState );
		[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEndTransaction")]
		public static extern Win32Error MsiEndTransaction(MSITRANSACTIONSTATE dwTransactionState);

		/// <summary>
		/// The <c>MsiEnumClients</c> function enumerates the clients for a given installed component. The function retrieves one product
		/// code each time it is called.
		/// </summary>
		/// <param name="szComponent">Specifies the component whose clients are to be enumerated.</param>
		/// <param name="iProductIndex">
		/// Specifies the index of the client to retrieve. This parameter should be zero for the first call to the <c>MsiEnumClients</c>
		/// function and then incremented for subsequent calls. Because clients are not ordered, any new client has an arbitrary index. This
		/// means that the function can return clients in any order.
		/// </param>
		/// <param name="lpProductBuf">
		/// Pointer to a buffer that receives the product code. This buffer must be 39 characters long. The first 38 characters are for the
		/// GUID, and the last character is for the terminating null character.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
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
		/// <term>There are no clients to return.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>The system does not have enough memory to complete the operation. Available with Windows Server 2003.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>A value was enumerated.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNKNOWN_COMPONENT</term>
		/// <term>The specified component is unknown.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To enumerate clients, an application should initially call the <c>MsiEnumClients</c> function with the iProductIndex parameter
		/// set to zero. The application should then increment the iProductIndexparameter and call <c>MsiEnumClients</c> until there are no
		/// more clients (that is, until the function returns ERROR_NO_MORE_ITEMS).
		/// </para>
		/// <para>
		/// When making multiple calls to <c>MsiEnumClients</c> to enumerate all of the component's clients, each call should be made from
		/// the same thread.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienumclientsa UINT MsiEnumClientsA( LPCSTR szComponent, DWORD
		// iProductIndex, LPSTR lpProductBuf );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumClientsA")]
		public static extern Win32Error MsiEnumClients([MarshalAs(UnmanagedType.LPTStr)] string szComponent, uint iProductIndex,
			[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpProductBuf);

		/// <summary>
		/// <para>
		/// The <c>MsiEnumClientsEx</c> function enumerates the installed applications that use a specified component. The function
		/// retrieves a product code for an application each time it is called.
		/// </para>
		/// <para><c>Windows Installer 4.5 or earlier:</c> Not supported. This function is available beginning with Windows Installer 5.0.</para>
		/// </summary>
		/// <param name="szComponent">
		/// The component code GUID that identifies the component. The function enumerates the applications that use this component.
		/// </param>
		/// <param name="szUserSid">
		/// <para>
		/// A null-terminated string value that contains a security identifier (SID.) The enumeration of applications extends to users
		/// identified by this SID. The special SID string s-1-1-0 (Everyone) enumerates all applications for all users in the system. A SID
		/// value other than s-1-1-0 specifies a user SID for a particular user and enumerates the instances of applications installed by
		/// the specified user.
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
		/// <term>Specifies an enumeration for a particular user. An example of an user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
		/// </item>
		/// <item>
		/// <term>s-1-1-0</term>
		/// <term>Specifies an enumeration for all users in the system.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The special SID string s-1-5-18 (System) cannot be used to enumerate applications that exist in the per-machine
		/// installation context. Setting the SID value to s-1-5-18 returns <c>ERROR_INVALID_PARAMETER</c>. When dwContext is set to
		/// <c>MSIINSTALLCONTEXT_MACHINE</c> only, the value of szUserSid must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwContext">
		/// <para>
		/// A flag that extends the enumeration to instances of applications installed in the specified installation context. The
		/// enumeration includes only instances of applications that are installed by the users identified by szUserSid.
		/// </para>
		/// <para>This can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Context</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERMANAGED 1</term>
		/// <term>Include applications installed in the per–user–managed installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERUNMANAGED 2</term>
		/// <term>Include applications installed in the per–user–unmanaged installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_MACHINE 4</term>
		/// <term>
		/// Include applications installed in the per-machine installation context. When dwInstallContext is set to
		/// MSIINSTALLCONTEXT_MACHINE only, the value of the szUserSID parameter must be NULL.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwProductIndex">
		/// Specifies the index of the application to retrieve. The value of this parameter must be zero (0) in the first call to the
		/// function. For each subsequent call, the index must be incremented by 1. The index should only be incremented if the previous
		/// call to the function returns <c>ERROR_SUCCESS</c>.
		/// </param>
		/// <param name="szProductBuf">
		/// A string value that receives the product code for the application. The length of the buffer at this location should be large
		/// enough to hold a null-terminated string value containing the product code. The first 38 <c>TCHAR</c> characters receives the
		/// GUID for the component, and the 39th character receives a terminating NULL character.
		/// </param>
		/// <param name="pdwInstalledContext">
		/// <para>A flag that gives the installation context of the application.</para>
		/// <para>This can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Context</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERMANAGED 1</term>
		/// <term>The application is installed in the per–user–managed installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERUNMANAGED 2</term>
		/// <term>The application is installed in the per–user–unmanaged installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_MACHINE 4</term>
		/// <term>The application is in the per-machine installation installation context.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="szSid">
		/// <para>
		/// Receives the security identifier (SID) that identifies the user that installed the application. The location receives an empty
		/// string value if this instance of the application exists in a per-machine installation context.
		/// </para>
		/// <para>
		/// The length of the buffer should be large enough to hold a null-terminated string value containing the SID. If the buffer is too
		/// small, the function returns <c>ERROR_MORE_DATA</c> and the location pointed to by pcchSid receives the number of <c>TCHAR</c> in
		/// the SID, not including the terminating NULL character.
		/// </para>
		/// <para>
		/// If szSid is set to <c>NULL</c> and pcchSid is a valid pointer to a location in memory, the function returns <c>ERROR_SUCCESS</c>
		/// and the location receives the number of <c>TCHAR</c> in the SID, not including the terminating null character. The function can
		/// then be called again to retrieve the value, with the szSid buffer resized large enough to contain *pcchSid + 1 characters.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>SID type</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Empty string</term>
		/// <term>The application is installed in a per-machine installation context.</term>
		/// </item>
		/// <item>
		/// <term>User SID</term>
		/// <term>The SID for the user that installed the product.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pcchSid">
		/// <para>
		/// Pointer to a location in memory that contains a variable that specifies the number of <c>TCHAR</c> in the SID, not including the
		/// terminating null character. When the function returns, this variable is set to the size of the requested SID whether or not the
		/// function can successfully copy the SID and terminating null character into the buffer location pointed to by szSid. The size is
		/// returned as the number of TCHAR in the requested value, not including the terminating null character.
		/// </para>
		/// <para>
		/// This parameter can be set to <c>NULL</c> only if szSid is also <c>NULL</c>, otherwise the function returns
		/// <c>ERROR_INVALID_PARAMETER</c>. If szSid and pcchSid are both set to <c>NULL</c>, the function returns <c>ERROR_SUCCESS</c> if
		/// the SID exists, without retrieving the SID value.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>The <c>MsiEnumClientsEx</c> function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Administrtator privileges are required to enumerate components of applications installed by users other than the current user.
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
		/// <term>ERROR_NO_MORE_ITEMS</term>
		/// <term>There are no more applications to enumerate.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function succeeded.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>The provided buffer was too small to hold the entire value.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FUNCTION_FAILED</term>
		/// <term>The function failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks/>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienumclientsexa UINT MsiEnumClientsExA( LPCSTR szComponent,
		// LPCSTR szUserSid, DWORD dwContext, DWORD dwProductIndex, CHAR [39] szProductBuf, MSIINSTALLCONTEXT *pdwInstalledContext, LPSTR
		// szSid, LPDWORD pcchSid );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumClientsExA")]
		public static extern Win32Error MsiEnumClientsEx([MarshalAs(UnmanagedType.LPTStr)] string szComponent,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string szUserSid, MSIINSTALLCONTEXT dwContext, uint dwProductIndex,
			[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szProductBuf, out MSIINSTALLCONTEXT pdwInstalledContext,
			[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szSid, ref uint pcchSid);

		/// <summary>
		/// <para>
		/// The <c>MsiEnumClientsEx</c> function enumerates the installed applications that use a specified component. The function
		/// retrieves a product code for an application each time it is called.
		/// </para>
		/// <para><c>Windows Installer 4.5 or earlier:</c> Not supported. This function is available beginning with Windows Installer 5.0.</para>
		/// </summary>
		/// <param name="szComponent">
		/// The component code GUID that identifies the component. The function enumerates the applications that use this component.
		/// </param>
		/// <param name="szUserSid">
		/// <para>
		/// A null-terminated string value that contains a security identifier (SID.) The enumeration of applications extends to users
		/// identified by this SID. The special SID string s-1-1-0 (Everyone) enumerates all applications for all users in the system. A SID
		/// value other than s-1-1-0 specifies a user SID for a particular user and enumerates the instances of applications installed by
		/// the specified user.
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
		/// <term>Specifies an enumeration for a particular user. An example of an user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
		/// </item>
		/// <item>
		/// <term>s-1-1-0</term>
		/// <term>Specifies an enumeration for all users in the system.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The special SID string s-1-5-18 (System) cannot be used to enumerate applications that exist in the per-machine
		/// installation context. Setting the SID value to s-1-5-18 returns <c>ERROR_INVALID_PARAMETER</c>. When dwContext is set to
		/// <c>MSIINSTALLCONTEXT_MACHINE</c> only, the value of szUserSid must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwContext">
		/// <para>
		/// A flag that extends the enumeration to instances of applications installed in the specified installation context. The
		/// enumeration includes only instances of applications that are installed by the users identified by szUserSid.
		/// </para>
		/// <para>This can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Context</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERMANAGED 1</term>
		/// <term>Include applications installed in the per–user–managed installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERUNMANAGED 2</term>
		/// <term>Include applications installed in the per–user–unmanaged installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_MACHINE 4</term>
		/// <term>
		/// Include applications installed in the per-machine installation context. When dwInstallContext is set to
		/// MSIINSTALLCONTEXT_MACHINE only, the value of the szUserSID parameter must be NULL.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwProductIndex">
		/// Specifies the index of the application to retrieve. The value of this parameter must be zero (0) in the first call to the
		/// function. For each subsequent call, the index must be incremented by 1. The index should only be incremented if the previous
		/// call to the function returns <c>ERROR_SUCCESS</c>.
		/// </param>
		/// <param name="szProductBuf">
		/// A string value that receives the product code for the application. The length of the buffer at this location should be large
		/// enough to hold a null-terminated string value containing the product code. The first 38 <c>TCHAR</c> characters receives the
		/// GUID for the component, and the 39th character receives a terminating NULL character.
		/// </param>
		/// <param name="pdwInstalledContext">
		/// <para>A flag that gives the installation context of the application.</para>
		/// <para>This can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Context</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERMANAGED 1</term>
		/// <term>The application is installed in the per–user–managed installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERUNMANAGED 2</term>
		/// <term>The application is installed in the per–user–unmanaged installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_MACHINE 4</term>
		/// <term>The application is in the per-machine installation installation context.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="szSid">
		/// <para>
		/// Receives the security identifier (SID) that identifies the user that installed the application. The location receives an empty
		/// string value if this instance of the application exists in a per-machine installation context.
		/// </para>
		/// <para>
		/// The length of the buffer should be large enough to hold a null-terminated string value containing the SID. If the buffer is too
		/// small, the function returns <c>ERROR_MORE_DATA</c> and the location pointed to by pcchSid receives the number of <c>TCHAR</c> in
		/// the SID, not including the terminating NULL character.
		/// </para>
		/// <para>
		/// If szSid is set to <c>NULL</c> and pcchSid is a valid pointer to a location in memory, the function returns <c>ERROR_SUCCESS</c>
		/// and the location receives the number of <c>TCHAR</c> in the SID, not including the terminating null character. The function can
		/// then be called again to retrieve the value, with the szSid buffer resized large enough to contain *pcchSid + 1 characters.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>SID type</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Empty string</term>
		/// <term>The application is installed in a per-machine installation context.</term>
		/// </item>
		/// <item>
		/// <term>User SID</term>
		/// <term>The SID for the user that installed the product.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pcchSid">
		/// <para>
		/// Pointer to a location in memory that contains a variable that specifies the number of <c>TCHAR</c> in the SID, not including the
		/// terminating null character. When the function returns, this variable is set to the size of the requested SID whether or not the
		/// function can successfully copy the SID and terminating null character into the buffer location pointed to by szSid. The size is
		/// returned as the number of TCHAR in the requested value, not including the terminating null character.
		/// </para>
		/// <para>
		/// This parameter can be set to <c>NULL</c> only if szSid is also <c>NULL</c>, otherwise the function returns
		/// <c>ERROR_INVALID_PARAMETER</c>. If szSid and pcchSid are both set to <c>NULL</c>, the function returns <c>ERROR_SUCCESS</c> if
		/// the SID exists, without retrieving the SID value.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>The <c>MsiEnumClientsEx</c> function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Administrtator privileges are required to enumerate components of applications installed by users other than the current user.
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
		/// <term>ERROR_NO_MORE_ITEMS</term>
		/// <term>There are no more applications to enumerate.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function succeeded.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>The provided buffer was too small to hold the entire value.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FUNCTION_FAILED</term>
		/// <term>The function failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks/>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienumclientsexa UINT MsiEnumClientsExA( LPCSTR szComponent,
		// LPCSTR szUserSid, DWORD dwContext, DWORD dwProductIndex, CHAR [39] szProductBuf, MSIINSTALLCONTEXT *pdwInstalledContext, LPSTR
		// szSid, LPDWORD pcchSid );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumClientsExA")]
		public static extern Win32Error MsiEnumClientsEx([MarshalAs(UnmanagedType.LPTStr)] string szComponent,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string szUserSid, MSIINSTALLCONTEXT dwContext, uint dwProductIndex,
			[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szProductBuf, [Out, Optional] IntPtr pdwInstalledContext,
			[Out, Optional] IntPtr szSid, [Out, Optional] IntPtr pcchSid);

		/// <summary>
		/// <para>
		/// The <c>MsiEnumClientsEx</c> function enumerates the installed applications that use a specified component and retrieves a
		/// product code for an application.
		/// </para>
		/// <para><c>Windows Installer 4.5 or earlier:</c> Not supported. This function is available beginning with Windows Installer 5.0.</para>
		/// </summary>
		/// <param name="szComponent">
		/// The component code GUID that identifies the component. The function enumerates the applications that use this component.
		/// </param>
		/// <param name="szUserSid">
		/// <para>
		/// A null-terminated string value that contains a security identifier (SID.) The enumeration of applications extends to users
		/// identified by this SID. The special SID string s-1-1-0 (Everyone) enumerates all applications for all users in the system. A SID
		/// value other than s-1-1-0 specifies a user SID for a particular user and enumerates the instances of applications installed by
		/// the specified user.
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
		/// <description>Specifies an enumeration for a particular user. An example of an user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</description>
		/// </item>
		/// <item>
		/// <description>s-1-1-0</description>
		/// <description>Specifies an enumeration for all users in the system.</description>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The special SID string s-1-5-18 (System) cannot be used to enumerate applications that exist in the per-machine
		/// installation context. Setting the SID value to s-1-5-18 returns <c>ERROR_INVALID_PARAMETER</c>. When dwContext is set to
		/// <c>MSIINSTALLCONTEXT_MACHINE</c> only, the value of szUserSid must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwContext">
		/// <para>
		/// A flag that extends the enumeration to instances of applications installed in the specified installation context. The
		/// enumeration includes only instances of applications that are installed by the users identified by szUserSid.
		/// </para>
		/// <para>This can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Context</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <description>MSIINSTALLCONTEXT_USERMANAGED 1</description>
		/// <description>Include applications installed in the per–user–managed installation context.</description>
		/// </item>
		/// <item>
		/// <description>MSIINSTALLCONTEXT_USERUNMANAGED 2</description>
		/// <description>Include applications installed in the per–user–unmanaged installation context.</description>
		/// </item>
		/// <item>
		/// <description>MSIINSTALLCONTEXT_MACHINE 4</description>
		/// <description>
		/// Include applications installed in the per-machine installation context. When dwInstallContext is set to
		/// MSIINSTALLCONTEXT_MACHINE only, the value of the szUserSID parameter must be NULL.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>A sequence of tuples for each application containing these items:</para>
		/// <para><strong>product</strong> - A string value that receives the product code for the application.</para>
		/// <para><strong>context</strong> - A flag that gives the installation context of the application.</para>
		/// <para>This can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Context</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <description>MSIINSTALLCONTEXT_USERMANAGED 1</description>
		/// <description>The application is installed in the per–user–managed installation context.</description>
		/// </item>
		/// <item>
		/// <description>MSIINSTALLCONTEXT_USERUNMANAGED 2</description>
		/// <description>The application is installed in the per–user–unmanaged installation context.</description>
		/// </item>
		/// <item>
		/// <description>MSIINSTALLCONTEXT_MACHINE 4</description>
		/// <description>The application is in the per-machine installation installation context.</description>
		/// </item>
		/// </list>
		/// <para>
		/// <strong>sid</strong> - The security identifier (SID) that identifies the user that installed the application. The string value
		/// is null if this instance of the application exists in a per-machine installation context.
		/// </para>
		/// </returns>
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumClientsExA")]
		public static IEnumerable<(string product, MSIINSTALLCONTEXT context, string sid)> MsiEnumClientsEx(string szComponent,
			[Optional] string szUserSid, MSIINSTALLCONTEXT dwContext)
		{
			StringBuilder prodCode = new StringBuilder(MAX_GUID_CHARS + 1);
			StringBuilder sid = new StringBuilder(1024);
			for (uint i = 0; true; i++)
			{
				prodCode.Length = 0;
				sid.Length = 0;
				var sidSz = (uint)sid.Capacity;
				var err = MsiEnumClientsEx(szComponent, szUserSid, dwContext, i, prodCode, out var ctx, sid, ref sidSz);
				if (err == Win32Error.ERROR_MORE_DATA)
				{
					sid.Capacity = (int)sidSz;
					err = MsiEnumClientsEx(szComponent, szUserSid, dwContext, i, prodCode, out ctx, sid, ref sidSz);
				}
				if (err == Win32Error.ERROR_NO_MORE_ITEMS)
					yield break;
				err.ThrowIfFailed();
				yield return (prodCode.ToString(), ctx, sidSz == 0 ? null : sid.ToString());
			}
		}

		/// <summary>
		/// The <c>MsiEnumComponentQualifiers</c> function enumerates the advertised qualifiers for the given component. This function
		/// retrieves one qualifier each time it is called.
		/// </summary>
		/// <param name="szComponent">Specifies component whose qualifiers are to be enumerated.</param>
		/// <param name="iIndex">
		/// Specifies the index of the qualifier to retrieve. This parameter should be zero for the first call to the
		/// <c>MsiEnumComponentQualifiers</c> function and then incremented for subsequent calls. Because qualifiers are not ordered, any
		/// new qualifier has an arbitrary index. This means that the function can return qualifiers in any order.
		/// </param>
		/// <param name="lpQualifierBuf">Pointer to a buffer that receives the qualifier code.</param>
		/// <param name="pcchQualifierBuf">
		/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpQualifierBuf parameter. On
		/// input, this size should include the terminating null character. On return, the value does not include the null character.
		/// </param>
		/// <param name="lpApplicationDataBuf">
		/// Pointer to a buffer that receives the application registered data for the qualifier. This parameter can be null.
		/// </param>
		/// <param name="pcchApplicationDataBuf">
		/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpApplicationDataBuf parameter. On
		/// input, this size should include the terminating null character. On return, the value does not include the null character. This
		/// parameter can be null only if the lpApplicationDataBuf parameter is null.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_CONFIGURATION</term>
		/// <term>The configuration data is corrupt.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid parameter was passed to the function.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>A buffer is to small to hold the requested data.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_MORE_ITEMS</term>
		/// <term>There are no qualifiers to return.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>The system does not have enough memory to complete the operation. Available with Windows Server 2003.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>A value was enumerated.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNKNOWN_COMPONENT</term>
		/// <term>The specified component is unknown.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To enumerate qualifiers, an application should initially call the <c>MsiEnumComponentQualifiers</c> function with the iIndex
		/// parameter set to zero. The application should then increment the iIndex parameter and call <c>MsiEnumComponentQualifiers</c>
		/// until there are no more qualifiers (that is, until the function returns ERROR_NO_MORE_ITEMS).
		/// </para>
		/// <para>
		/// When <c>MsiEnumComponentQualifiers</c> returns, the pcchQualifierBuf parameter contains the length of the qualifier string
		/// stored in the buffer. The count returned does not include the terminating null character. If the buffer is not big enough,
		/// <c>MsiEnumComponentQualifiers</c> returns ERROR_MORE_DATA, and this parameter contains the size of the string, in characters,
		/// without counting the null character. The same mechanism applies to pcchDescriptionBuf.
		/// </para>
		/// <para>
		/// When making multiple calls to <c>MsiEnumComponentQualifiers</c> to enumerate all of the component's advertised qualifiers, each
		/// call should be made from the same thread.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienumcomponentqualifiersa UINT MsiEnumComponentQualifiersA(
		// LPCSTR szComponent, DWORD iIndex, LPSTR lpQualifierBuf, LPDWORD pcchQualifierBuf, LPSTR lpApplicationDataBuf, LPDWORD
		// pcchApplicationDataBuf );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumComponentQualifiersA")]
		public static extern Win32Error MsiEnumComponentQualifiers([MarshalAs(UnmanagedType.LPTStr)] string szComponent, uint iIndex,
			[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpQualifierBuf, ref uint pcchQualifierBuf,
			[Out, Optional] IntPtr lpApplicationDataBuf, [Out, Optional] IntPtr pcchApplicationDataBuf);

		/// <summary>
		/// The <c>MsiEnumComponents</c> function enumerates the installed components for all products. This function retrieves one
		/// component code each time it is called.
		/// </summary>
		/// <param name="iComponentIndex">
		/// Specifies the index of the component to retrieve. This parameter should be zero for the first call to the
		/// <c>MsiEnumComponents</c> function and then incremented for subsequent calls. Because components are not ordered, any new
		/// component has an arbitrary index. This means that the function can return components in any order.
		/// </param>
		/// <param name="lpComponentBuf">
		/// Pointer to a buffer that receives the component code. This buffer must be 39 characters long. The first 38 characters are for
		/// the GUID, and the last character is for the terminating null character.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
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
		/// <term>There are no components to return.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>The system does not have enough memory to complete the operation. Available with Windows Server 2003.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>A value was enumerated.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To enumerate components, an application should initially call the <c>MsiEnumComponents</c> function with the iComponentIndex
		/// parameter set to zero. The application should then increment the iComponentIndex parameter and call <c>MsiEnumComponents</c>
		/// until there are no more components (that is, until the function returns ERROR_NO_MORE_ITEMS).
		/// </para>
		/// <para>
		/// When making multiple calls to <c>MsiEnumComponents</c> to enumerate all of the product's components, each call should be made
		/// from the same thread.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienumcomponentsa UINT MsiEnumComponentsA( DWORD iComponentIndex,
		// LPSTR lpComponentBuf );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumComponentsA")]
		public static extern Win32Error MsiEnumComponents(uint iComponentIndex, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpComponentBuf);

		/// <summary>
		/// <para>
		/// The <c>MsiEnumComponentsEx</c> function enumerates installed components. The function retrieves the component code for one
		/// component each time it is called. The component code is the string GUID unique to the component, version, and language.
		/// </para>
		/// <para><c>Windows Installer 4.5 or earlier:</c> Not supported. This function is available beginning with Windows Installer 5.0.</para>
		/// </summary>
		/// <param name="szUserSid">
		/// <para>
		/// A null-terminated string that contains a security identifier (SID.) The enumeration of installed components extends to users
		/// identified by this SID. The special SID string s-1-1-0 (Everyone) specifies an enumeration of all installed components across
		/// all products of all users in the system. A SID value other than s-1-1-0 specifies a user SID for a particular user and restricts
		/// the enumeration to instances of applications installed by the specified user.
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
		/// <term>An enumeration for a specific user in the system. An example of an user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
		/// </item>
		/// <item>
		/// <term>s-1-1-0</term>
		/// <term>Specifies all users in the system.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The special SID string s-1-5-18 (System) cannot be used to enumerate applications installed in the per-machine
		/// installation context. Setting the SID value to s-1-5-18 returns ERROR_INVALID_PARAMETER. When dwContext is set to
		/// MSIINSTALLCONTEXT_MACHINE only, szUserSid must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwContext">
		/// <para>
		/// A flag that restricts the enumeration of installed component to instances of products installed in the specified installation
		/// context. The enumeration includes only product instances installed by the users specified by szUserSid.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERMANAGED 1</term>
		/// <term>Include products that exist in the per–user–managed installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERUNMANAGED 2</term>
		/// <term>Include products that exist in the per–user–unmanaged installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_MACHINE 4</term>
		/// <term>
		/// Include products that exist in the per-machine installation context. When dwInstallContext is set to MSIINSTALLCONTEXT_MACHINE
		/// only, the szUserSID parameter must be NULL.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwIndex">
		/// Specifies the index of the component to retrieve. This parameter must be zero (0) for the first call to
		/// <c>MsiEnumComponentsEx</c> function. For each subsequent call, the index must be incremented by 1. The index should only be
		/// incremented if the previous call to the function returns ERROR_SUCCESS. Components are not ordered and can be returned by the
		/// function in any order.
		/// </param>
		/// <param name="szInstalledComponentCode">
		/// An output buffer that receives the component code GUID for the installed component. The length of the buffer should be large
		/// enough to hold a null-terminated string value containing the component code. The first 38 <c>TCHAR</c> characters receives the
		/// GUID for the component, and the 39th character receives a terminating NULL character.
		/// </param>
		/// <param name="pdwInstalledContext">
		/// <para>A flag that gives the installation context the application that installed the component.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERMANAGED 1</term>
		/// <term>The application is installed in the per–user–managed installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERUNMANAGED 2</term>
		/// <term>The application is installed in the per–user–unmanaged installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_MACHINE 4</term>
		/// <term>The application is installed in the per-machine installation installation context.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="szSid">
		/// <para>
		/// Receives the security identifier (SID) that identifies the user that installed the application that owns the component. The
		/// location receives an empty string if this instance of the application is installed in a per-machine installation context.
		/// </para>
		/// <para>
		/// The length of the buffer at this location should be large enough to hold a null-terminated string value containing the SID. If
		/// the buffer is too small, the function returns <c>ERROR_MORE_DATA</c> and the location pointed to by pcchSid receives the number
		/// of <c>TCHAR</c> in the SID, not including the terminating NULL character.
		/// </para>
		/// <para>
		/// If szSid is set to <c>NULL</c> and pcchSid is a valid pointer to a location in memory, the function returns <c>ERROR_SUCCESS</c>
		/// and the location receives the number of <c>TCHAR</c> in the SID, not including the terminating null character. The function can
		/// then be called again to retrieve the value, with the szSid buffer resized large enough to contain *pcchSid + 1 characters.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>SID type</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Empty string</term>
		/// <term>The application is installed in a per-machine installation context.</term>
		/// </item>
		/// <item>
		/// <term>User SID</term>
		/// <term>The SID for the user in the system that installed the application.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pcchSid">
		/// <para>
		/// Receives the number of <c>TCHAR</c> in the SID, not including the terminating null character. When the function returns, this
		/// variable is set to the size of the requested SID whether or not the function can successfully copy the SID and terminating null
		/// character into the buffer location pointed to by szSid. The size is returned as the number of <c>TCHAR</c> in the requested
		/// value, not including the terminating null character.
		/// </para>
		/// <para>
		/// This parameter can be set to <c>NULL</c> only if szSid is also <c>NULL</c>, otherwise the function returns
		/// <c>ERROR_INVALID_PARAMETER</c>. If szSid and pcchSid are both set to <c>NULL</c>, the function returns <c>ERROR_SUCCESS</c> if
		/// the SID exists, without retrieving the SID value.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>The MsiEnumProductsEx function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Administrator privileges are required to enumerate components of applications installed by users other than the current user.
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
		/// <term>ERROR_NO_MORE_ITEMS</term>
		/// <term>There are no more components to enumerate.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function succeeded.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>The provided buffer was too small to hold the entire value.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FUNCTION_FAILED</term>
		/// <term>The function failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks/>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienumcomponentsexa UINT MsiEnumComponentsExA( LPCSTR szUserSid,
		// DWORD dwContext, DWORD dwIndex, CHAR [39] szInstalledComponentCode, MSIINSTALLCONTEXT *pdwInstalledContext, LPSTR szSid, LPDWORD
		// pcchSid );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumComponentsExA")]
		public static extern Win32Error MsiEnumComponentsEx([Optional, MarshalAs(UnmanagedType.LPTStr)] string szUserSid, MSIINSTALLCONTEXT dwContext,
			uint dwIndex, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szInstalledComponentCode,
			out MSIINSTALLCONTEXT pdwInstalledContext, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szSid, ref uint pcchSid);

		/// <summary>
		/// <para>
		/// The <c>MsiEnumComponentsEx</c> function enumerates installed components. The function retrieves the component code for one
		/// component each time it is called. The component code is the string GUID unique to the component, version, and language.
		/// </para>
		/// <para><c>Windows Installer 4.5 or earlier:</c> Not supported. This function is available beginning with Windows Installer 5.0.</para>
		/// </summary>
		/// <param name="szUserSid">
		/// <para>
		/// A null-terminated string that contains a security identifier (SID.) The enumeration of installed components extends to users
		/// identified by this SID. The special SID string s-1-1-0 (Everyone) specifies an enumeration of all installed components across
		/// all products of all users in the system. A SID value other than s-1-1-0 specifies a user SID for a particular user and restricts
		/// the enumeration to instances of applications installed by the specified user.
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
		/// <term>An enumeration for a specific user in the system. An example of an user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
		/// </item>
		/// <item>
		/// <term>s-1-1-0</term>
		/// <term>Specifies all users in the system.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The special SID string s-1-5-18 (System) cannot be used to enumerate applications installed in the per-machine
		/// installation context. Setting the SID value to s-1-5-18 returns ERROR_INVALID_PARAMETER. When dwContext is set to
		/// MSIINSTALLCONTEXT_MACHINE only, szUserSid must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwContext">
		/// <para>
		/// A flag that restricts the enumeration of installed component to instances of products installed in the specified installation
		/// context. The enumeration includes only product instances installed by the users specified by szUserSid.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERMANAGED 1</term>
		/// <term>Include products that exist in the per–user–managed installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERUNMANAGED 2</term>
		/// <term>Include products that exist in the per–user–unmanaged installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_MACHINE 4</term>
		/// <term>
		/// Include products that exist in the per-machine installation context. When dwInstallContext is set to MSIINSTALLCONTEXT_MACHINE
		/// only, the szUserSID parameter must be NULL.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwIndex">
		/// Specifies the index of the component to retrieve. This parameter must be zero (0) for the first call to
		/// <c>MsiEnumComponentsEx</c> function. For each subsequent call, the index must be incremented by 1. The index should only be
		/// incremented if the previous call to the function returns ERROR_SUCCESS. Components are not ordered and can be returned by the
		/// function in any order.
		/// </param>
		/// <param name="szInstalledComponentCode">
		/// An output buffer that receives the component code GUID for the installed component. The length of the buffer should be large
		/// enough to hold a null-terminated string value containing the component code. The first 38 <c>TCHAR</c> characters receives the
		/// GUID for the component, and the 39th character receives a terminating NULL character.
		/// </param>
		/// <param name="pdwInstalledContext">
		/// <para>A flag that gives the installation context the application that installed the component.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERMANAGED 1</term>
		/// <term>The application is installed in the per–user–managed installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERUNMANAGED 2</term>
		/// <term>The application is installed in the per–user–unmanaged installation context.</term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_MACHINE 4</term>
		/// <term>The application is installed in the per-machine installation installation context.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="szSid">
		/// <para>
		/// Receives the security identifier (SID) that identifies the user that installed the application that owns the component. The
		/// location receives an empty string if this instance of the application is installed in a per-machine installation context.
		/// </para>
		/// <para>
		/// The length of the buffer at this location should be large enough to hold a null-terminated string value containing the SID. If
		/// the buffer is too small, the function returns <c>ERROR_MORE_DATA</c> and the location pointed to by pcchSid receives the number
		/// of <c>TCHAR</c> in the SID, not including the terminating NULL character.
		/// </para>
		/// <para>
		/// If szSid is set to <c>NULL</c> and pcchSid is a valid pointer to a location in memory, the function returns <c>ERROR_SUCCESS</c>
		/// and the location receives the number of <c>TCHAR</c> in the SID, not including the terminating null character. The function can
		/// then be called again to retrieve the value, with the szSid buffer resized large enough to contain *pcchSid + 1 characters.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>SID type</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Empty string</term>
		/// <term>The application is installed in a per-machine installation context.</term>
		/// </item>
		/// <item>
		/// <term>User SID</term>
		/// <term>The SID for the user in the system that installed the application.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pcchSid">
		/// <para>
		/// Receives the number of <c>TCHAR</c> in the SID, not including the terminating null character. When the function returns, this
		/// variable is set to the size of the requested SID whether or not the function can successfully copy the SID and terminating null
		/// character into the buffer location pointed to by szSid. The size is returned as the number of <c>TCHAR</c> in the requested
		/// value, not including the terminating null character.
		/// </para>
		/// <para>
		/// This parameter can be set to <c>NULL</c> only if szSid is also <c>NULL</c>, otherwise the function returns
		/// <c>ERROR_INVALID_PARAMETER</c>. If szSid and pcchSid are both set to <c>NULL</c>, the function returns <c>ERROR_SUCCESS</c> if
		/// the SID exists, without retrieving the SID value.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>The MsiEnumProductsEx function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Administrator privileges are required to enumerate components of applications installed by users other than the current user.
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
		/// <term>ERROR_NO_MORE_ITEMS</term>
		/// <term>There are no more components to enumerate.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function succeeded.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>The provided buffer was too small to hold the entire value.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FUNCTION_FAILED</term>
		/// <term>The function failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks/>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienumcomponentsexa UINT MsiEnumComponentsExA( LPCSTR szUserSid,
		// DWORD dwContext, DWORD dwIndex, CHAR [39] szInstalledComponentCode, MSIINSTALLCONTEXT *pdwInstalledContext, LPSTR szSid, LPDWORD
		// pcchSid );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumComponentsExA")]
		public static extern Win32Error MsiEnumComponentsEx([Optional, MarshalAs(UnmanagedType.LPTStr)] string szUserSid, MSIINSTALLCONTEXT dwContext,
			uint dwIndex, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szInstalledComponentCode,
			[Out, Optional] IntPtr pdwInstalledContext, [Out, Optional] IntPtr szSid, [Out, Optional] IntPtr pcchSid);

		/// <summary>
		/// The <c>MsiEnumFeatures</c> function enumerates the published features for a given product. This function retrieves one feature
		/// ID each time it is called.
		/// </summary>
		/// <param name="szProduct">Null-terminated string specifying the product code of the product whose features are to be enumerated.</param>
		/// <param name="iFeatureIndex">
		/// Specifies the index of the feature to retrieve. This parameter should be zero for the first call to the <c>MsiEnumFeatures</c>
		/// function and then incremented for subsequent calls. Because features are not ordered, any new feature has an arbitrary index.
		/// This means that the function can return features in any order.
		/// </param>
		/// <param name="lpFeatureBuf">
		/// Pointer to a buffer that receives the feature ID. The size of the buffer must hold a string value of length MAX_FEATURE_CHARS+1.
		/// The function returns <c>ERROR_MORE_DATA</c> if the length of the feature ID exceeds <c>MAX_FEATURE_CHARS</c>.
		/// </param>
		/// <param name="lpParentBuf">
		/// Pointer to a buffer that receives the feature ID of the parent of the feature. The size of the buffer must hold a string value
		/// of length MAX_FEATURE_CHARS+1. If the length of the feature ID of the parent feature exceeds <c>MAX_FEATURE_CHARS</c>, only the
		/// first <c>MAX_FEATURE_CHARS</c> characters get copied into the buffer.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_CONFIGURATION</term>
		/// <term>The configuration data is corrupt.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid parameter was passed to the function.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>A buffer is too small to hold the requested data.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_MORE_ITEMS</term>
		/// <term>There are no features to return.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>A value was enumerated.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNKNOWN_PRODUCT</term>
		/// <term>The specified product is unknown.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// To enumerate features, an application should initially call the <c>MsiEnumFeatures</c> function with the iFeatureIndex parameter
		/// set to zero. The application should then increment the iFeatureIndex parameter and call <c>MsiEnumFeatures</c> until there are
		/// no more features (that is, until the function returns ERROR_NO_MORE_ITEMS).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienumfeaturesa UINT MsiEnumFeaturesA( LPCSTR szProduct, DWORD
		// iFeatureIndex, LPSTR lpFeatureBuf, LPSTR lpParentBuf );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumFeaturesA")]
		public static extern Win32Error MsiEnumFeatures([MarshalAs(UnmanagedType.LPTStr)] string szProduct, uint iFeatureIndex,
			[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpFeatureBuf, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpParentBuf);

		/// <summary>
		/// <para>
		/// The <c>MsiEnumPatches</c> function enumerates all of the patches that have been applied to a product. The function returns the
		/// patch code GUID for each patch that has been applied to the product and returns a list of transforms from each patch that apply
		/// to the product. Note that patches may have many transforms only some of which are applicable to a particular product. The list
		/// of transforms are returned in the same format as the value of the TRANSFORMS property.
		/// </para>
		/// <para>
		/// <c>Note</c> pcchTransformsBuf is not set to the number of characters copied to lpTransformsBuf upon a successful return of <c>MsiEnumPatches</c>.
		/// </para>
		/// </summary>
		/// <param name="szProduct">Specifies the product code of the product for which patches are to be enumerated.</param>
		/// <param name="iPatchIndex">
		/// Specifies the index of the patch to retrieve. This parameter should be zero for the first call to the <c>MsiEnumPatches</c>
		/// function and then incremented for subsequent calls.
		/// </param>
		/// <param name="lpPatchBuf">Pointer to a buffer that receives the patch's GUID. This argument is required.</param>
		/// <param name="lpTransformsBuf">
		/// Pointer to a buffer that receives the list of transforms in the patch that are applicable to the product. This argument is
		/// required and cannot be Null.
		/// </param>
		/// <param name="pcchTransformsBuf">
		/// Set to the number of characters copied to lpTransformsBuf upon an unsuccessful return of the function. Not set for a successful
		/// return. On input, this is the full size of the buffer, including a space for a terminating null character. If the buffer passed
		/// in is too small, the count returned does not include the terminating null character.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
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
		/// <term>There are no patches to return.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>A value was enumerated.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>A buffer is too small to hold the requested data.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To enumerate patches, an application should initially call the <c>MsiEnumPatches</c> function with the iPatchIndex parameter set
		/// to zero. The application should then increment the iPatchIndex parameter and call <c>MsiEnumPatches</c> until there are no more
		/// products (until the function returns ERROR_NO_MORE_ITEMS).
		/// </para>
		/// <para>
		/// If the buffer is too small to hold the requested data, <c>MsiEnumPatches</c> returns ERROR_MORE_DATA and pcchTransformsBuf
		/// contains the number of characters copied to lpTransformsBuf, without counting the Null character.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienumpatchesa UINT MsiEnumPatchesA( LPCSTR szProduct, DWORD
		// iPatchIndex, LPSTR lpPatchBuf, LPSTR lpTransformsBuf, LPDWORD pcchTransformsBuf );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumPatchesA")]
		public static extern Win32Error MsiEnumPatches([MarshalAs(UnmanagedType.LPTStr)] string szProduct, uint iPatchIndex,
			[MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpPatchBuf, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpTransformsBuf,
			ref uint pcchTransformsBuf);

		/// <summary>
		/// The <c>MsiEnumPatchesEx</c> function enumerates all patches in a specific context or across all contexts. Patches already
		/// applied to products are enumerated. Patches that have been registered but not yet applied to products are also enumerated.
		/// </summary>
		/// <param name="szProductCode">
		/// A null-terminated string that specifies the ProductCode GUID of the product whose patches are enumerated. If non- <c>NULL</c>,
		/// patch enumeration is restricted to instances of this product under the user and context specified by szUserSid and dwContext. If
		/// <c>NULL</c>, the patches for all products under the specified context are enumerated.
		/// </param>
		/// <param name="szUserSid">
		/// <para>
		/// A null-terminated string that specifies a security identifier (SID) that restricts the context of enumeration. The special SID
		/// string "S-1-1-0" (Everyone) specifies enumeration across all users in the system. A SID value other than "S-1-1-0" is considered
		/// a user SID and restricts enumeration to that user. When enumerating for a user other than current user, any patches that were
		/// applied in a per-user-unmanaged context using a version less than Windows Installer version 3.0, are not enumerated. This
		/// parameter can be set to <c>NULL</c> to specify the current user.
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
		/// <term>An enumeration for a specific user in the system. An example of user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
		/// </item>
		/// <item>
		/// <term>s-1-1-0</term>
		/// <term>An enumeration across all users in the system.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The special SID string "S-1-5-18" (System) cannot be used to enumerate products or patches installed as per-machine.
		/// Setting the SID value to "S-1-5-18" returns <c>ERROR_INVALID_PARAMETER</c>. When dwContext is set to
		/// <c>MSIINSTALLCONTEXT_MACHINE</c> only, szUserSid must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwContext">
		/// <para>
		/// Restricts the enumeration to one or a combination of contexts. This parameter can be any one or a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Context</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
		/// <term>
		/// The enumeration that is extended to all per-user-managed installations for the users that szUserSid specifies. An invalid SID
		/// returns no items.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
		/// <term>
		/// In this context, only patches installed with Windows Installer version 3.0 are enumerated for users that are not the current
		/// user. For the current user, the function enumerates all installed and new patches. An invalid SID for szUserSid returns no items.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_MACHINE</term>
		/// <term>
		/// An enumeration that is extended to all per-machine installations. When dwContext is set to MSIINSTALLCONTEXT_MACHINE only, the
		/// szUserSid parameter must be NULL.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFilter">
		/// <para>The filter for enumeration. This parameter can be one or a combination of the following parameters.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Filter</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIPATCHSTATE_APPLIED 1</term>
		/// <term>The enumeration includes patches that have been applied. Enumeration does not include superseded or obsolete patches.</term>
		/// </item>
		/// <item>
		/// <term>MSIPATCHSTATE_SUPERSEDED 2</term>
		/// <term>The enumeration includes patches that are marked as superseded.</term>
		/// </item>
		/// <item>
		/// <term>MSIPATCHSTATE_OBSOLETED 4</term>
		/// <term>The enumeration includes patches that are marked as obsolete.</term>
		/// </item>
		/// <item>
		/// <term>MSIPATCHSTATE_REGISTERED 8</term>
		/// <term>
		/// The enumeration includes patches that are registered but not yet applied. The MsiSourceListAddSourceEx function can register new patches.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSIPATCHSTATE_ALL 15</term>
		/// <term>The enumeration includes all applied, obsolete, superseded, and registered patches.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwIndex">
		/// The index of the patch to retrieve. This parameter must be zero for the first call to the <c>MsiEnumPatchesEx</c> function and
		/// then incremented for subsequent calls. The dwIndex parameter should be incremented only if the previous call returned ERROR_SUCCESS.
		/// </param>
		/// <param name="szPatchCode">
		/// An output buffer to contain the GUID of the patch being enumerated. The buffer should be large enough to hold the GUID. This
		/// parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="szTargetProductCode">
		/// An output buffer to contain the ProductCode GUID of the product that receives this patch. The buffer should be large enough to
		/// hold the GUID. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pdwTargetProductContext">
		/// Returns the context of the patch being enumerated. The output value can be <c>MSIINSTALLCONTEXT_USERMANAGED</c>,
		/// <c>MSIINSTALLCONTEXT_USERUNMANAGED</c>, or <c>MSIINSTALLCONTEXT_MACHINE</c>. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="szTargetUserSid">
		/// <para>
		/// An output buffer that receives the string SID of the account under which this patch instance exists. This buffer returns an
		/// empty string for a per-machine context.
		/// </para>
		/// <para>
		/// This buffer should be large enough to contain the SID. If the buffer is too small, the function returns <c>ERROR_MORE_DATA</c>
		/// and sets *pcchTargetUserSid to the number of <c>TCHAR</c> in the value, not including the terminating NULL character.
		/// </para>
		/// <para>
		/// If the szTargetUserSid is set to <c>NULL</c> and pcchTargetUserSid is set to a valid pointer, the function returns
		/// <c>ERROR_SUCCESS</c> and sets *pcchTargetUserSid to the number of <c>TCHAR</c> in the value, not including the terminating
		/// <c>NULL</c> character. The function can then be called again to retrieve the value, with szTargetUserSid buffer large enough to
		/// contain *pcchTargetUserSid + 1 characters.
		/// </para>
		/// <para>
		/// If szTargetUserSid and pcchTargetUserSid are both set to <c>NULL</c>, the function returns <c>ERROR_SUCCESS</c> if the value
		/// exists, without retrieving the value.
		/// </para>
		/// </param>
		/// <param name="pcchTargetUserSid">
		/// <para>
		/// A pointer to a variable that specifies the number of <c>TCHAR</c> in the szTargetUserSid buffer. When the function returns, this
		/// parameter is set to the size of the requested value whether or not the function copies the value into the specified buffer. The
		/// size is returned as the number of <c>TCHAR</c> in the requested value, not including the terminating null character.
		/// </para>
		/// <para>This parameter can be set to <c>NULL</c> only if szTargetUserSid is also <c>NULL</c>, otherwise the function returns ERROR_INVALID_PARAMETER.</para>
		/// </param>
		/// <returns>
		/// <para>The <c>MsiEnumPatchesEx</c> function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The function fails trying to access a resource with insufficient privileges.</term>
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
		/// <term>ERROR_NO_MORE_ITEMS</term>
		/// <term>There are no more patches to enumerate.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The patch is successfully enumerated.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNKNOWN_PRODUCT</term>
		/// <term>The product that szProduct specifies is not installed on the computer in the specified contexts.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// This is returned when pcchTargetUserSid points to a buffer size less than required to copy the SID. In this case, the user can
		/// fix the buffer and call MsiEnumPatchesEx again for the same index value.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Non-administrators can enumerate patches within their visibility only. Administrators can enumerate patches for other user contexts.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienumpatchesexa UINT MsiEnumPatchesExA( LPCSTR szProductCode,
		// LPCSTR szUserSid, DWORD dwContext, DWORD dwFilter, DWORD dwIndex, CHAR [39] szPatchCode, CHAR [39] szTargetProductCode,
		// MSIINSTALLCONTEXT *pdwTargetProductContext, LPSTR szTargetUserSid, LPDWORD pcchTargetUserSid );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumPatchesExA")]
		public static extern Win32Error MsiEnumPatchesEx([MarshalAs(UnmanagedType.LPTStr)] string szProductCode,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string szUserSid, MSIINSTALLCONTEXT dwContext, MSIPATCHSTATE dwFilter,
			uint dwIndex, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szPatchCode,
			[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szTargetProductCode, out MSIINSTALLCONTEXT pdwTargetProductContext,
			[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szTargetUserSid, ref uint pcchTargetUserSid);

		/// <summary>
		/// The <c>MsiEnumPatchesEx</c> function enumerates all patches in a specific context or across all contexts. Patches already
		/// applied to products are enumerated. Patches that have been registered but not yet applied to products are also enumerated.
		/// </summary>
		/// <param name="szProductCode">
		/// A null-terminated string that specifies the ProductCode GUID of the product whose patches are enumerated. If non- <c>NULL</c>,
		/// patch enumeration is restricted to instances of this product under the user and context specified by szUserSid and dwContext. If
		/// <c>NULL</c>, the patches for all products under the specified context are enumerated.
		/// </param>
		/// <param name="szUserSid">
		/// <para>
		/// A null-terminated string that specifies a security identifier (SID) that restricts the context of enumeration. The special SID
		/// string "S-1-1-0" (Everyone) specifies enumeration across all users in the system. A SID value other than "S-1-1-0" is considered
		/// a user SID and restricts enumeration to that user. When enumerating for a user other than current user, any patches that were
		/// applied in a per-user-unmanaged context using a version less than Windows Installer version 3.0, are not enumerated. This
		/// parameter can be set to <c>NULL</c> to specify the current user.
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
		/// <term>An enumeration for a specific user in the system. An example of user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
		/// </item>
		/// <item>
		/// <term>s-1-1-0</term>
		/// <term>An enumeration across all users in the system.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The special SID string "S-1-5-18" (System) cannot be used to enumerate products or patches installed as per-machine.
		/// Setting the SID value to "S-1-5-18" returns <c>ERROR_INVALID_PARAMETER</c>. When dwContext is set to
		/// <c>MSIINSTALLCONTEXT_MACHINE</c> only, szUserSid must be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwContext">
		/// <para>
		/// Restricts the enumeration to one or a combination of contexts. This parameter can be any one or a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Context</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
		/// <term>
		/// The enumeration that is extended to all per-user-managed installations for the users that szUserSid specifies. An invalid SID
		/// returns no items.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
		/// <term>
		/// In this context, only patches installed with Windows Installer version 3.0 are enumerated for users that are not the current
		/// user. For the current user, the function enumerates all installed and new patches. An invalid SID for szUserSid returns no items.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSIINSTALLCONTEXT_MACHINE</term>
		/// <term>
		/// An enumeration that is extended to all per-machine installations. When dwContext is set to MSIINSTALLCONTEXT_MACHINE only, the
		/// szUserSid parameter must be NULL.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFilter">
		/// <para>The filter for enumeration. This parameter can be one or a combination of the following parameters.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Filter</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIPATCHSTATE_APPLIED 1</term>
		/// <term>The enumeration includes patches that have been applied. Enumeration does not include superseded or obsolete patches.</term>
		/// </item>
		/// <item>
		/// <term>MSIPATCHSTATE_SUPERSEDED 2</term>
		/// <term>The enumeration includes patches that are marked as superseded.</term>
		/// </item>
		/// <item>
		/// <term>MSIPATCHSTATE_OBSOLETED 4</term>
		/// <term>The enumeration includes patches that are marked as obsolete.</term>
		/// </item>
		/// <item>
		/// <term>MSIPATCHSTATE_REGISTERED 8</term>
		/// <term>
		/// The enumeration includes patches that are registered but not yet applied. The MsiSourceListAddSourceEx function can register new patches.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSIPATCHSTATE_ALL 15</term>
		/// <term>The enumeration includes all applied, obsolete, superseded, and registered patches.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwIndex">
		/// The index of the patch to retrieve. This parameter must be zero for the first call to the <c>MsiEnumPatchesEx</c> function and
		/// then incremented for subsequent calls. The dwIndex parameter should be incremented only if the previous call returned ERROR_SUCCESS.
		/// </param>
		/// <param name="szPatchCode">
		/// An output buffer to contain the GUID of the patch being enumerated. The buffer should be large enough to hold the GUID. This
		/// parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="szTargetProductCode">
		/// An output buffer to contain the ProductCode GUID of the product that receives this patch. The buffer should be large enough to
		/// hold the GUID. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pdwTargetProductContext">
		/// Returns the context of the patch being enumerated. The output value can be <c>MSIINSTALLCONTEXT_USERMANAGED</c>,
		/// <c>MSIINSTALLCONTEXT_USERUNMANAGED</c>, or <c>MSIINSTALLCONTEXT_MACHINE</c>. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="szTargetUserSid">
		/// <para>
		/// An output buffer that receives the string SID of the account under which this patch instance exists. This buffer returns an
		/// empty string for a per-machine context.
		/// </para>
		/// <para>
		/// This buffer should be large enough to contain the SID. If the buffer is too small, the function returns <c>ERROR_MORE_DATA</c>
		/// and sets *pcchTargetUserSid to the number of <c>TCHAR</c> in the value, not including the terminating NULL character.
		/// </para>
		/// <para>
		/// If the szTargetUserSid is set to <c>NULL</c> and pcchTargetUserSid is set to a valid pointer, the function returns
		/// <c>ERROR_SUCCESS</c> and sets *pcchTargetUserSid to the number of <c>TCHAR</c> in the value, not including the terminating
		/// <c>NULL</c> character. The function can then be called again to retrieve the value, with szTargetUserSid buffer large enough to
		/// contain *pcchTargetUserSid + 1 characters.
		/// </para>
		/// <para>
		/// If szTargetUserSid and pcchTargetUserSid are both set to <c>NULL</c>, the function returns <c>ERROR_SUCCESS</c> if the value
		/// exists, without retrieving the value.
		/// </para>
		/// </param>
		/// <param name="pcchTargetUserSid">
		/// <para>
		/// A pointer to a variable that specifies the number of <c>TCHAR</c> in the szTargetUserSid buffer. When the function returns, this
		/// parameter is set to the size of the requested value whether or not the function copies the value into the specified buffer. The
		/// size is returned as the number of <c>TCHAR</c> in the requested value, not including the terminating null character.
		/// </para>
		/// <para>This parameter can be set to <c>NULL</c> only if szTargetUserSid is also <c>NULL</c>, otherwise the function returns ERROR_INVALID_PARAMETER.</para>
		/// </param>
		/// <returns>
		/// <para>The <c>MsiEnumPatchesEx</c> function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The function fails trying to access a resource with insufficient privileges.</term>
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
		/// <term>ERROR_NO_MORE_ITEMS</term>
		/// <term>There are no more patches to enumerate.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The patch is successfully enumerated.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNKNOWN_PRODUCT</term>
		/// <term>The product that szProduct specifies is not installed on the computer in the specified contexts.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// This is returned when pcchTargetUserSid points to a buffer size less than required to copy the SID. In this case, the user can
		/// fix the buffer and call MsiEnumPatchesEx again for the same index value.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Non-administrators can enumerate patches within their visibility only. Administrators can enumerate patches for other user contexts.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienumpatchesexa UINT MsiEnumPatchesExA( LPCSTR szProductCode,
		// LPCSTR szUserSid, DWORD dwContext, DWORD dwFilter, DWORD dwIndex, CHAR [39] szPatchCode, CHAR [39] szTargetProductCode,
		// MSIINSTALLCONTEXT *pdwTargetProductContext, LPSTR szTargetUserSid, LPDWORD pcchTargetUserSid );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumPatchesExA")]
		public static extern Win32Error MsiEnumPatchesEx([MarshalAs(UnmanagedType.LPTStr)] string szProductCode,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string szUserSid, MSIINSTALLCONTEXT dwContext, MSIPATCHSTATE dwFilter,
			uint dwIndex, [Out, Optional] IntPtr szPatchCode, [Out, Optional] IntPtr szTargetProductCode, [Out, Optional] IntPtr pdwTargetProductContext,
			[Out, Optional] IntPtr szTargetUserSid, [Out, Optional] IntPtr pcchTargetUserSid);

		/// <summary>
		/// The <c>MsiEnumProducts</c> function enumerates through all the products currently advertised or installed. Products that are
		/// installed in both the per-user and per-machine installation context and advertisements are enumerated.
		/// </summary>
		/// <param name="iProductIndex">
		/// Specifies the index of the product to retrieve. This parameter should be zero for the first call to the <c>MsiEnumProducts</c>
		/// function and then incremented for subsequent calls. Because products are not ordered, any new product has an arbitrary index.
		/// This means that the function can return products in any order.
		/// </param>
		/// <param name="lpProductBuf">
		/// Pointer to a buffer that receives the product code. This buffer must be 39 characters long. The first 38 characters are for the
		/// GUID, and the last character is for the terminating null character.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
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
		/// <term>There are no products to return.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>The system does not have enough memory to complete the operation. Available with Windows Server 2003.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>A value was enumerated.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To enumerate products, an application should initially call the <c>MsiEnumProducts</c> function with the iProductIndex parameter
		/// set to zero. The application should then increment the iProductIndex parameter and call <c>MsiEnumProducts</c> until there are
		/// no more products (until the function returns ERROR_NO_MORE_ITEMS).
		/// </para>
		/// <para>
		/// When making multiple calls to <c>MsiEnumProducts</c> to enumerate all of the products, each call should be made from the same thread.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienumproductsa UINT MsiEnumProductsA( DWORD iProductIndex, LPSTR
		// lpProductBuf );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumProductsA")]
		public static extern Win32Error MsiEnumProducts(uint iProductIndex, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpProductBuf);

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
		/// The <c>MsiEnumRelatedProducts</c> function enumerates products with a specified upgrade code. This function lists the currently
		/// installed and advertised products that have the specified UpgradeCode property in their Property table.
		/// </summary>
		/// <param name="lpUpgradeCode">
		/// The null-terminated string specifying the upgrade code of related products that the installer is to enumerate.
		/// </param>
		/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
		/// <param name="iProductIndex">The zero-based index into the registered products.</param>
		/// <param name="lpProductBuf">
		/// A buffer to receive the product code GUID. This buffer must be 39 characters long. The first 38 characters are for the GUID, and
		/// the last character is for the terminating null character.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
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
		/// <term>There are no products to return.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>The system does not have enough memory to complete the operation. Available starting with Windows Server 2003.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>A value was enumerated.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>See UpgradeCode property.</para>
		/// <para>
		/// To enumerate currently installed and advertised products that have a specific upgrade code, an application should initially call
		/// the <c>MsiEnumRelatedProducts</c> function with the iProductIndex parameter set to zero. The application should then increment
		/// the iProductIndex parameter and call <c>MsiEnumRelatedProducts</c> until the function returns ERROR_NO_MORE_ITEMS, which means
		/// there are no more products with the specified upgrade code.
		/// </para>
		/// <para>
		/// When making multiple calls to <c>MsiEnumRelatedProducts</c> to enumerate all of the related products, each call should be made
		/// from the same thread.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msienumrelatedproductsa UINT MsiEnumRelatedProductsA( LPCSTR
		// lpUpgradeCode, DWORD dwReserved, DWORD iProductIndex, LPSTR lpProductBuf );
		[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumRelatedProductsA")]
		public static extern Win32Error MsiEnumRelatedProducts([MarshalAs(UnmanagedType.LPTStr)] string lpUpgradeCode, [Optional] uint dwReserved,
			uint iProductIndex, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpProductBuf);
	}
}