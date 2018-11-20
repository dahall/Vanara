using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;

namespace Vanara.PInvoke
{
	/// <summary>Specifies values used by IAutoComplete2::GetOptions and IAutoComplete2::SetOptions for options surrounding autocomplete.</summary>
	[Flags]
	public enum AUTOCOMPLETEOPTIONS
	{
		/// <summary>Do not autocomplete.</summary>
		ACO_NONE = 0,

		/// <summary>Enable the autosuggest drop-down list.</summary>
		ACO_AUTOSUGGEST = 0x1,

		/// <summary>Enable autoappend.</summary>
		ACO_AUTOAPPEND = 0x2,

		/// <summary>Add a search item to the list of completed strings. When the user selects this item, it launches a search engine.</summary>
		ACO_SEARCH = 0x4,

		/// <summary>Do not match common prefixes, such as "www." or "http://".</summary>
		ACO_FILTERPREFIXES = 0x8,

		/// <summary>Use the TAB key to select an item from the drop-down list.</summary>
		ACO_USETAB = 0x10,

		/// <summary>Use the UP ARROW and DOWN ARROW keys to display the autosuggest drop-down list.</summary>
		ACO_UPDOWNKEYDROPSLIST = 0x20,

		/// <summary>
		/// Normal windows display text left-to-right (LTR). Windows can be mirrored to display languages such as Hebrew or Arabic that read
		/// right-to-left (RTL). Typically, control text is displayed in the same direction as the text in its parent window. If
		/// ACO_RTLREADING is set, the text reads in the opposite direction from the text in the parent window.
		/// </summary>
		ACO_RTLREADING = 0x40,

		/// <summary>
		/// Windows Vista and later. If set, the autocompleted suggestion is treated as a phrase for search purposes. The suggestion,
		/// Microsoft Office, would be treated as "Microsoft Office" (where both Microsoft AND Office must appear in the search results).
		/// </summary>
		ACO_WORD_FILTER = 0x80,

		/// <summary>Windows Vista and later. Disable prefix filtering when displaying the autosuggest dropdown. Always display all suggestions.</summary>
		ACO_NOPREFIXFILTERING = 0x100
	}

	/// <summary>
	/// Exposed by the autocomplete object (CLSID_AutoComplete). This interface allows applications to initialize, enable, and disable the object.
	/// </summary>
	[ComImport, SuppressUnmanagedCodeSecurity, Guid("00bb2762-6a77-11d0-a535-00c04fd7d062"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(CAutoComplete))]
	public interface IAutoComplete
	{
		/// <summary>Initializes the autocomplete object.</summary>
		/// <param name="hwndEdit">A handle to the window for the system edit control for which autocompletion will be enabled.</param>
		/// <param name="punkAcl">
		/// A pointer to the IUnknown interface of the string list object that generates candidates for the completed string. The object must
		/// expose an IEnumString interface.
		/// </param>
		/// <param name="pwszRegKeyPath">
		/// A pointer to an optional, null-terminated Unicode string that gives the registry path, including the value name, where the format
		/// string is stored as a REG_SZ value. The autocomplete object first looks for the path under HKEY_CURRENT_USER. If it fails, it
		/// tries HKEY_LOCAL_MACHINE. For a discussion of the format string, see the definition of pwszQuickComplete.
		/// </param>
		/// <param name="pwszQuickComplete">
		/// A pointer to an optional null-terminated Unicode string that specifies the format to be used if the user enters text and presses
		/// CTRL+ENTER. Set this parameter to NULL to disable quick completion. Otherwise, the autocomplete object treats pwszQuickComplete
		/// as a StringCchPrintf format string and the text in the edit box as its associated argument, to produce a new string. For example,
		/// set pwszQuickComplete to "http://www.%s.com/". When a user enters "MyURL" into the edit box and presses CTRL+ENTER, the text in
		/// the edit box is updated to "http://www.MyURL.com/".
		/// </param>
		void Init(HWND hwndEdit, IEnumString punkAcl, [MarshalAs(UnmanagedType.LPWStr)] string pwszRegKeyPath, [MarshalAs(UnmanagedType.LPWStr)] string pwszQuickComplete);

		/// <summary>Enables or disables autocompletion.</summary>
		/// <param name="fEnable">A value that is set to TRUE to enable autocompletion, or FALSE to disable it.</param>
		void Enable([MarshalAs(UnmanagedType.Bool)] bool fEnable);
	}

	/// <summary>
	/// Extends IAutoComplete. This interface enables clients of the autocomplete object to retrieve and set a number of options that control
	/// how autocompletion operates.
	/// </summary>
	/// <seealso cref="Vanara.PInvoke.IAutoComplete"/>
	[ComImport, SuppressUnmanagedCodeSecurity, Guid("EAC04BC0-3791-11D2-BB95-0060977B464C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(CAutoComplete))]
	public interface IAutoComplete2 : IAutoComplete
	{
		/// <summary>Initializes the autocomplete object.</summary>
		/// <param name="hwndEdit">A handle to the window for the system edit control for which autocompletion will be enabled.</param>
		/// <param name="punkAcl">
		/// A pointer to the IUnknown interface of the string list object that generates candidates for the completed string. The object must
		/// expose an IEnumString interface.
		/// </param>
		/// <param name="pwszRegKeyPath">
		/// A pointer to an optional, null-terminated Unicode string that gives the registry path, including the value name, where the format
		/// string is stored as a REG_SZ value. The autocomplete object first looks for the path under HKEY_CURRENT_USER. If it fails, it
		/// tries HKEY_LOCAL_MACHINE. For a discussion of the format string, see the definition of pwszQuickComplete.
		/// </param>
		/// <param name="pwszQuickComplete">
		/// A pointer to an optional null-terminated Unicode string that specifies the format to be used if the user enters text and presses
		/// CTRL+ENTER. Set this parameter to NULL to disable quick completion. Otherwise, the autocomplete object treats pwszQuickComplete
		/// as a StringCchPrintf format string and the text in the edit box as its associated argument, to produce a new string. For example,
		/// set pwszQuickComplete to "http://www.%s.com/". When a user enters "MyURL" into the edit box and presses CTRL+ENTER, the text in
		/// the edit box is updated to "http://www.MyURL.com/".
		/// </param>
		new void Init(HWND hwndEdit, IEnumString punkAcl, [MarshalAs(UnmanagedType.LPWStr)] string pwszRegKeyPath, [MarshalAs(UnmanagedType.LPWStr)] string pwszQuickComplete);

		/// <summary>Enables or disables autocompletion.</summary>
		/// <param name="fEnable">A value that is set to TRUE to enable autocompletion, or FALSE to disable it.</param>
		new void Enable([MarshalAs(UnmanagedType.Bool)] bool fEnable);

		/// <summary>Sets the current autocomplete options.</summary>
		/// <param name="dwFlag">One or more flags from the AUTOCOMPLETEOPTIONS enumeration that specify autocomplete options.</param>
		void SetOptions(AUTOCOMPLETEOPTIONS dwFlag);

		/// <summary>Gets the current autocomplete options.</summary>
		/// <param name="dwFlag">
		/// One or more flags from the AUTOCOMPLETEOPTIONS enumeration that indicate the options that are currently set.
		/// </param>
		void GetOptions(out AUTOCOMPLETEOPTIONS dwFlag);
	}

	/// <summary>An autocomplete object (CLSID_AutoComplete).</summary>
	[ComImport, SuppressUnmanagedCodeSecurity, Guid("00BB2763-6A77-11D0-A535-00C04FD7D062"), ClassInterface(ClassInterfaceType.None)]
	public class CAutoComplete { }
}