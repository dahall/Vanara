using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class MSCTF
	{
		private const string Lib_input = "input.dll";

		/// <summary>The InputScope enumeration contains values that specify which input scopes are applied to a given field.</summary>
		/// <remarks>Whether a given input scope value is supported can vary across technologies.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/ne-inputscope-inputscope typedef enum
		// __MIDL___MIDL_itf_inputscope_0000_0000_0001 { IS_DEFAULT, IS_URL, IS_FILE_FULLFILEPATH, IS_FILE_FILENAME, IS_EMAIL_USERNAME,
		// IS_EMAIL_SMTPEMAILADDRESS, IS_LOGINNAME, IS_PERSONALNAME_FULLNAME, IS_PERSONALNAME_PREFIX, IS_PERSONALNAME_GIVENNAME,
		// IS_PERSONALNAME_MIDDLENAME, IS_PERSONALNAME_SURNAME, IS_PERSONALNAME_SUFFIX, IS_ADDRESS_FULLPOSTALADDRESS, IS_ADDRESS_POSTALCODE,
		// IS_ADDRESS_STREET, IS_ADDRESS_STATEORPROVINCE, IS_ADDRESS_CITY, IS_ADDRESS_COUNTRYNAME, IS_ADDRESS_COUNTRYSHORTNAME,
		// IS_CURRENCY_AMOUNTANDSYMBOL, IS_CURRENCY_AMOUNT, IS_DATE_FULLDATE, IS_DATE_MONTH, IS_DATE_DAY, IS_DATE_YEAR, IS_DATE_MONTHNAME,
		// IS_DATE_DAYNAME, IS_DIGITS, IS_NUMBER, IS_ONECHAR, IS_PASSWORD, IS_TELEPHONE_FULLTELEPHONENUMBER, IS_TELEPHONE_COUNTRYCODE,
		// IS_TELEPHONE_AREACODE, IS_TELEPHONE_LOCALNUMBER, IS_TIME_FULLTIME, IS_TIME_HOUR, IS_TIME_MINORSEC, IS_NUMBER_FULLWIDTH,
		// IS_ALPHANUMERIC_HALFWIDTH, IS_ALPHANUMERIC_FULLWIDTH, IS_CURRENCY_CHINESE, IS_BOPOMOFO, IS_HIRAGANA, IS_KATAKANA_HALFWIDTH,
		// IS_KATAKANA_FULLWIDTH, IS_HANJA, IS_HANGUL_HALFWIDTH, IS_HANGUL_FULLWIDTH, IS_SEARCH, IS_FORMULA, IS_SEARCH_INCREMENTAL,
		// IS_CHINESE_HALFWIDTH, IS_CHINESE_FULLWIDTH, IS_NATIVE_SCRIPT, IS_YOMI, IS_TEXT, IS_CHAT, IS_NAME_OR_PHONENUMBER,
		// IS_EMAILNAME_OR_ADDRESS, IS_PRIVATE, IS_MAPS, IS_NUMERIC_PASSWORD, IS_NUMERIC_PIN, IS_ALPHANUMERIC_PIN, IS_ALPHANUMERIC_PIN_SET,
		// IS_FORMULA_NUMBER, IS_CHAT_WITHOUT_EMOJI, IS_PHRASELIST, IS_REGULAREXPRESSION, IS_SRGS, IS_XML, IS_ENUMSTRING } InputScope;
		[PInvokeData("inputscope.h", MSDNShortId = "NE:inputscope.__MIDL___MIDL_itf_inputscope_0000_0000_0001")]
		public enum InputScope : int
		{
			/// <summary>
			/// Indicates the standard recognition bias. Treated as default and uses the default lexicon. If combined with another input
			/// scope, it does not force coercion on the other input scope.
			/// </summary>
			IS_DEFAULT = 0,

			/// <summary>Indicates a URL, File, or FTP format. Examples include the following.</summary>
			IS_URL,

			/// <summary>Indicates a file path. The following conditions are enforced.</summary>
			IS_FILE_FULLFILEPATH,

			/// <summary>Indicates a file name. The following conditions are enforced.</summary>
			IS_FILE_FILENAME,

			/// <summary>Indicates email user names. Examples include the following.</summary>
			IS_EMAIL_USERNAME,

			/// <summary>Indicates a complete SMTP email address, for example, someone@example.com.</summary>
			IS_EMAIL_SMTPEMAILADDRESS,

			/// <summary>Indicates a log-in name and domain. The following conditions are enforced.Examples include the following.</summary>
			IS_LOGINNAME,

			/// <summary>
			/// Indicates a combination of first, middle, and last names. Examples include the following, formatted for English (United States).
			/// </summary>
			IS_PERSONALNAME_FULLNAME,

			/// <summary>
			/// Indicates a honorific or title preceding a name. Examples include the following, formatted for English (United States).
			/// </summary>
			IS_PERSONALNAME_PREFIX,

			/// <summary>Indicates a first name or initial. Examples include the following, formatted for English (United States).</summary>
			IS_PERSONALNAME_GIVENNAME,

			/// <summary>Indicates a middle name or initial. Examples include the following.</summary>
			IS_PERSONALNAME_MIDDLENAME,

			/// <summary>Indicates a last name. Examples include the following, formatted for English (United States).</summary>
			IS_PERSONALNAME_SURNAME,

			/// <summary>Indicates a name suffix abbreviation or Roman numerals. Examples include the following.</summary>
			IS_PERSONALNAME_SUFFIX,

			/// <summary>Indicates a full address, including numbers. Examples include the following, formatted for English (United States).</summary>
			IS_ADDRESS_FULLPOSTALADDRESS,

			/// <summary>
			/// Indicates an alphanumeric postal code. The value is alphanumeric to support international zip codes. Examples include the
			/// following, formatted for English (United States).
			/// </summary>
			IS_ADDRESS_POSTALCODE,

			/// <summary>
			/// Indicates a house number, street number, apartment name and number, and/or postal box. Examples include the following.
			/// </summary>
			IS_ADDRESS_STREET,

			/// <summary>
			/// Indicates a full name or abbreviation of state or province. Examples include the following, formatted for English (United States).
			/// </summary>
			IS_ADDRESS_STATEORPROVINCE,

			/// <summary>
			/// Indicates the name or abbreviation of a city. Examples include the following, formatted for English (United States).
			/// </summary>
			IS_ADDRESS_CITY,

			/// <summary>Indicates the name of a country/region. Examples include the following, formatted for English (United States).</summary>
			IS_ADDRESS_COUNTRYNAME,

			/// <summary>
			/// Indicates the abbreviation of the name of a country/region. Examples include the following, formatted for English (United States).
			/// </summary>
			IS_ADDRESS_COUNTRYSHORTNAME,

			/// <summary>Indicates currency symbols and numbers. Examples include the following, formatted for English (United States).</summary>
			IS_CURRENCY_AMOUNTANDSYMBOL,

			/// <summary>Indicates a numeric value for currency, excluding currency symbols. For example, 2,100.25.</summary>
			IS_CURRENCY_AMOUNT,

			/// <summary>
			/// Indicates a full date, in a variety of formats. Examples include the following, formatted for English (United States).
			/// </summary>
			IS_DATE_FULLDATE,

			/// <summary>Indicates a numeric representation of months, constrained to 1-12. Examples include the following.</summary>
			IS_DATE_MONTH,

			/// <summary>Indicates a numeric representation of days, constrained to 1-31. Examples include the following.</summary>
			IS_DATE_DAY,

			/// <summary>Indicates a numeric representation of years. Examples include the following.</summary>
			IS_DATE_YEAR,

			/// <summary>
			/// Indicates a character representation of months. Examples include the following, formatted for English (United States).
			/// </summary>
			IS_DATE_MONTHNAME,

			/// <summary>
			/// Indicates a character representation of days. Examples include the following, formatted for English (United States).
			/// </summary>
			IS_DATE_DAYNAME,

			/// <summary>Indicates positive whole numbers, constrained to 0-9.</summary>
			IS_DIGITS,

			/// <summary>
			/// Indicates numbers, including commas, negative sign, and decimal. For United States locations, the following conditions are enforced.
			/// </summary>
			IS_NUMBER,

			/// <summary>Indicates a single ANSI character, codepage 1252. For United States locations, this includes the following characters.ABCDEFGHIJKLMNOPQRSTUVWXYZabcdEfghijklmnopqrstuvwxyz0123456789!"#$%&amp;'()*+,-./:;&lt;=&gt;?@[]^_`{</summary>
			IS_ONECHAR,

			/// <summary>Indicates a password. IS_PASSWORD is not supported and may be altered or unavailable in the future.</summary>
			IS_PASSWORD,

			/// <summary>
			/// Indicates a telephone number. Alphabetical input is not allowed. Examples include the following, formatted for English
			/// (United States).
			/// </summary>
			IS_TELEPHONE_FULLTELEPHONENUMBER,

			/// <summary>Indicates telephone country codes. Examples include the following, formatted for English (United States).</summary>
			IS_TELEPHONE_COUNTRYCODE,

			/// <summary>Indicates telephone area codes. Examples include the following, formatted for English (United States).</summary>
			IS_TELEPHONE_AREACODE,

			/// <summary>
			/// Indicates a telephone number, excluding country or area code. Examples include the following, formatted for English (United States).
			/// </summary>
			IS_TELEPHONE_LOCALNUMBER,

			/// <summary>
			/// Indicates hours, minutes, seconds, and alphabetical time abbreviations. US English uses the 12 hour clock. Leading zeros are
			/// optional for hours but required for minutes and seconds. Hours are constrained to 0-24; minutes and seconds are constrained
			/// to 0-59. Examples include the following, formatted for English (United States).
			/// </summary>
			IS_TIME_FULLTIME,

			/// <summary>Indicates a numeric representation of hours, constrained to 0-24.</summary>
			IS_TIME_HOUR,

			/// <summary>Indicates a numeric representation of minutes or seconds, constrained to 0-59.</summary>
			IS_TIME_MINORSEC,

			/// <summary>Indicates full-width number, used for Japanese only. Constrained to full-width numbers and Kanji numbers.</summary>
			IS_NUMBER_FULLWIDTH,

			/// <summary>
			/// Indicates half-width alphanumeric characters for East-Asian languages, constrained to half-width alphabetical characters and numbers.
			/// </summary>
			IS_ALPHANUMERIC_HALFWIDTH,

			/// <summary>
			/// Indicates full-width alphanumeric characters for East-Asian languages, constrained to full-width alphabet characters and numbers.
			/// </summary>
			IS_ALPHANUMERIC_FULLWIDTH,

			/// <summary>Indicates Chinese currency.</summary>
			IS_CURRENCY_CHINESE,

			/// <summary>Indicates Bopomofo characters.</summary>
			IS_BOPOMOFO,

			/// <summary>Indicates Hiragana characters.</summary>
			IS_HIRAGANA,

			/// <summary>Indicates half-width Katakana characters.</summary>
			IS_KATAKANA_HALFWIDTH,

			/// <summary>Indicates full-width Katakana characters.</summary>
			IS_KATAKANA_FULLWIDTH,

			/// <summary>Indicates Hanja characters.</summary>
			IS_HANJA,

			/// <summary>Indicates half-width Hangul characters.</summary>
			IS_HANGUL_HALFWIDTH,

			/// <summary>Indicates full-width Hangul characters.</summary>
			IS_HANGUL_FULLWIDTH,

			/// <summary>Starting with Windows 8: Indicates a search string.</summary>
			IS_SEARCH,

			/// <summary>Starting with Windows 8: Indicates a formula control, for example, a spreadsheet field.</summary>
			IS_FORMULA,

			/// <summary>
			/// Starting with Windows 10: Indicates input scope is intended for search boxes where incremental results are displayed as the
			/// user types.
			/// </summary>
			IS_SEARCH_INCREMENTAL,

			/// <summary>Starting with Windows 10: Indicates input scope is intended for Chinese half-width characters.</summary>
			IS_CHINESE_HALFWIDTH,

			/// <summary>Starting with Windows 10: Indicates input scope is intended for Chinese full-width characters.</summary>
			IS_CHINESE_FULLWIDTH,

			/// <summary>Starting with Windows 10: Indicates input scope is intended for native script.</summary>
			IS_NATIVE_SCRIPT,

			/// <summary>Starting with Windows 10: Indicates input scope is intended for Japanese names.</summary>
			IS_YOMI,

			/// <summary>Starting with Windows 10: Indicates input scope is intended for working with text.</summary>
			IS_TEXT,

			/// <summary>Starting with Windows 10: Indicates input scope is intended for chat strings.</summary>
			IS_CHAT,

			/// <summary>Starting with Windows 10: Indicates input scope is intended for working with a name or telephone number.</summary>
			IS_NAME_OR_PHONENUMBER,

			/// <summary>Starting with Windows 10: Indicates input scope is intended for working with an email name or full email address.</summary>
			IS_EMAILNAME_OR_ADDRESS,

			/// <summary>Starting with Windows 10: Indicates input scope is intended for working with private data.</summary>
			IS_PRIVATE,

			/// <summary>Starting with Windows 10: Indicates input scope is intended for working with a map location.</summary>
			IS_MAPS,

			/// <summary>Starting with Windows 10: Indicates expected input is a numeric password, or PIN.</summary>
			IS_NUMERIC_PASSWORD,

			/// <summary>Starting with Windows 10: Indicates expected input is a numeric PIN.</summary>
			IS_NUMERIC_PIN,

			/// <summary>Starting with Windows 10: Indicates expected input is an alphanumeric PIN.</summary>
			IS_ALPHANUMERIC_PIN,

			/// <summary>Starting with Windows 10: Indicates expected input is an alphanumeric PIN for lock screen.</summary>
			IS_ALPHANUMERIC_PIN_SET,

			/// <summary>Starting with Windows 10: Indicates expected input is a mathematical formula.</summary>
			IS_FORMULA_NUMBER,

			/// <summary>Starting with Windows 10: Indicates expected input does not include emoji.</summary>
			IS_CHAT_WITHOUT_EMOJI,

			/// <summary>Indicates a phrase list.</summary>
			IS_PHRASELIST = -1,

			/// <summary>Indicates a regular expression.</summary>
			IS_REGULAREXPRESSION = -2,

			/// <summary>
			/// Indicates an XML string that conforms to the Speech Recognition Grammar Specification (SRGS) standard. Information on SRGS
			/// can be found at http://www.w3.org/TR/speech-grammar.
			/// </summary>
			IS_SRGS = -3,

			/// <summary>Indicates a custom xml string.</summary>
			IS_XML = -4,

			/// <summary>
			/// The scope contains the IEnumString interface pointer. The Text Input Processor (TIP) can call ITfInputScope2::EnumWordList
			/// to retrieve it.
			/// </summary>
			IS_ENUMSTRING = -5,
		}

		/// <summary>
		/// <para>
		/// The <c>ITfInputScope</c> interface is used by the text input processors to get the InputScope value that represents a document
		/// context associated with a window. The input scope provides rules to help speech and handwriting recognition. For instance, if a
		/// text box on a form is used to enter an address, the input scope for that text box can be set to recognize and accept only those
		/// characters that are valid for an address.
		/// </para>
		/// <para>The interface ID is IID_ITfInputScope.</para>
		/// <para>
		/// The document context is used by the speech and handwriting recognition engine and is set by a text input processor by calling
		/// the SetInputScope method. A TSF-aware application does not call <c>SetInputScope</c> directly, but rather implements either
		/// ITextStoreACP or ITfContextOwner to get a pointer to <c>ITfInputScope</c>.
		/// </para>
		/// <para>
		/// To get the pointer to the <c>ITfInputScope</c> interface, the text input processor or TSF-aware application calls
		/// ITfContext::GetAppProperty, passing in <c>GUID_PROP_INPUTSCOPE</c> and a pointer to the ITFReadOnlyProperty interface, as in the
		/// following example.
		/// </para>
		/// <para>
		/// <code> extern const GUID GUID_PROP_INPUTSCOPE; // // The TIP can call this to get the input scope of the document mgr. // HRESULT GetInputScope(ITfContext *pic, ITfRange *pRange, TfEditCookie ec, ITfInutScope **ppiscope){ ITFReadOnlyProperty *prop; HRESULT hr; If (SUCCEEDED(hr = pic-&gt;GetAppProperty(GUID_PROP_INPUTSCOPE, &amp;prop)) { VARIANT var; If (SUCCEEDED(hr = prop-&gt;GetValue(ec, pRange, &amp;var))) { hr = var.punkVal-&gt;QueryInterface(IID_ITfInputScope, (void **)ppiscope); } prop-&gt;Release(); } return hr }</code>
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>To use this interface with window-less controls, an application has two options.</para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// <c>Make the application TSF-aware:</c> A TSF-aware application must implement either ITextStoreACP or ITfContextOwner to get a
		/// pointer to <c>ITfInputScope</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// SetInputScopes This is not recommended, but if the application is not TSF-aware, there is no other way to maintain the
		/// association between the input scope and the application. In this case, the application must call SetInputScopes whenever focus
		/// changes among window-less controls.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nn-inputscope-itfinputscope
		[PInvokeData("inputscope.h", MSDNShortId = "NN:inputscope.ITfInputScope")]
		[ComImport, Guid("FDE1EAEE-6924-4CDF-91E7-DA38CFF5559D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ITfInputScope
		{
			/// <summary>Gets the input scopes that are associated with this context.</summary>
			/// <param name="pprgInputScopes">
			/// Pointer to an array of pointers to the input scopes. The calling function must call <c>CoTaskMemFree()</c> to free the buffer.
			/// </param>
			/// <param name="pcCount">Pointer to the number of input scopes returned.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nf-inputscope-itfinputscope-getinputscopes HRESULT
			// GetInputScopes( InputScope **pprgInputScopes, UINT *pcCount );
			[PreserveSig]
			HRESULT GetInputScopes(out SafeCoTaskMemHandle pprgInputScopes, out uint pcCount);

			/// <summary>Gets the phrase list set to this context.</summary>
			/// <param name="ppbstrPhrases">
			/// Pointer to an array of pointers to strings containing phrases. The calling function must call <c>SystFreeString()</c> to
			/// free the memory allocated to the strings and <c>CoTaskMemFree</c> to free the buffer.
			/// </param>
			/// <param name="pcCount">Pointer to the number of phrases returned.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nf-inputscope-itfinputscope-getphrase HRESULT GetPhrase( BSTR
			// **ppbstrPhrases, UINT *pcCount );
			[PreserveSig]
			HRESULT GetPhrase(out SafeCoTaskMemHandle ppbstrPhrases, out uint pcCount);

			/// <summary>Gets the regular expression string to be rssecognized.</summary>
			/// <param name="pbstrRegExp">
			/// Pointer to a string containing the regular expression. The calling function must call <c>SystFreeString()</c> to free the
			/// memory allocated to the strings.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nf-inputscope-itfinputscope-getregularexpression HRESULT
			// GetRegularExpression( BSTR *pbstrRegExp );
			[PreserveSig]
			HRESULT GetRegularExpression([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrRegExp);

			/// <summary>Gets the Speech Recognition Grammar Specification (SRGS) string to be recognized.</summary>
			/// <param name="pbstrSRGS">The xml string. The calling function must call <c>SysFreeString()</c> to free the buffer.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>http://www.w3.org/TR/speech-grammar</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nf-inputscope-itfinputscope-getsrgs HRESULT GetSRGS( BSTR
			// *pbstrSRGS );
			[PreserveSig]
			HRESULT GetSRGS([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrSRGS);

			/// <summary>Gets the custom XML string to be recognized.</summary>
			/// <param name="pbstrXML">
			/// Pointer to a string containing the xml string. The calling function must call <c>SysFreeString()</c> to free the buffer.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nf-inputscope-itfinputscope-getxml HRESULT GetXML( BSTR
			// *pbstrXML );
			[PreserveSig]
			HRESULT GetXML([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrXML);
		}

		/// <summary>
		/// The <c>ITfInputScope2</c> interface is used by the text input processors to get the IEnumString interface pointer and this
		/// IEnumString interface enumerates the word list that the application specified for this context.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nn-inputscope-itfinputscope2
		[PInvokeData("inputscope.h", MSDNShortId = "NN:inputscope.ITfInputScope2")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5731EAA0-6BC2-4681-A532-92FBB74D7C41")]
		public interface ITfInputScope2 : ITfInputScope
		{
			/// <summary>Gets the input scopes that are associated with this context.</summary>
			/// <param name="pprgInputScopes">
			/// Pointer to an array of pointers to the input scopes. The calling function must call <c>CoTaskMemFree()</c> to free the buffer.
			/// </param>
			/// <param name="pcCount">Pointer to the number of input scopes returned.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nf-inputscope-itfinputscope-getinputscopes HRESULT
			// GetInputScopes( InputScope **pprgInputScopes, UINT *pcCount );
			[PreserveSig]
			new HRESULT GetInputScopes(out SafeCoTaskMemHandle pprgInputScopes, out uint pcCount);

			/// <summary>Gets the phrase list set to this context.</summary>
			/// <param name="ppbstrPhrases">
			/// Pointer to an array of pointers to strings containing phrases. The calling function must call <c>SystFreeString()</c> to
			/// free the memory allocated to the strings and <c>CoTaskMemFree</c> to free the buffer.
			/// </param>
			/// <param name="pcCount">Pointer to the number of phrases returned.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nf-inputscope-itfinputscope-getphrase HRESULT GetPhrase( BSTR
			// **ppbstrPhrases, UINT *pcCount );
			[PreserveSig]
			new HRESULT GetPhrase(out SafeCoTaskMemHandle ppbstrPhrases, out uint pcCount);

			/// <summary>Gets the regular expression string to be rssecognized.</summary>
			/// <param name="pbstrRegExp">
			/// Pointer to a string containing the regular expression. The calling function must call <c>SystFreeString()</c> to free the
			/// memory allocated to the strings.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nf-inputscope-itfinputscope-getregularexpression HRESULT
			// GetRegularExpression( BSTR *pbstrRegExp );
			[PreserveSig]
			new HRESULT GetRegularExpression([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrRegExp);

			/// <summary>Gets the Speech Recognition Grammar Specification (SRGS) string to be recognized.</summary>
			/// <param name="pbstrSRGS">The xml string. The calling function must call <c>SysFreeString()</c> to free the buffer.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>http://www.w3.org/TR/speech-grammar</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nf-inputscope-itfinputscope-getsrgs HRESULT GetSRGS( BSTR
			// *pbstrSRGS );
			[PreserveSig]
			new HRESULT GetSRGS([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrSRGS);

			/// <summary>Gets the custom XML string to be recognized.</summary>
			/// <param name="pbstrXML">
			/// Pointer to a string containing the xml string. The calling function must call <c>SysFreeString()</c> to free the buffer.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nf-inputscope-itfinputscope-getxml HRESULT GetXML( BSTR
			// *pbstrXML );
			[PreserveSig]
			new HRESULT GetXML([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrXML);

			/// <summary>Return a pointer to obtain the IEnumString interface pointer.</summary>
			/// <param name="ppEnumString">A pointer to obtain the IEnumString interface pointer.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_FAIL</term>
			/// <term>An unspecified error occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nf-inputscope-itfinputscope2-enumwordlist HRESULT EnumWordList(
			// IEnumString **ppEnumString );
			[PreserveSig]
			HRESULT EnumWordList(out IEnumString ppEnumString);
		}

		/// <summary>Sets an input scope for the specified window.</summary>
		/// <param name="hwnd">The window to set the scope on.</param>
		/// <param name="inputscope">
		/// The input scope to associate with the window. To remove the input scope association, pass IS_DEFAULT to this parameter.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Calling this method replaces whatever scope is associated with the window.</para>
		/// <para>
		/// An application must call this method, passing in IS_DEFAULT to the hwnd parameter, to remove the input scope association before
		/// the window is destroyed.
		/// </para>
		/// <para>
		/// This API works only when the window (hwnd parameter) and the calling thread are in the same thread. If you call this API for a
		/// different thread's window, it fails with E_INVALIDARG.
		/// </para>
		/// <para>
		/// If you call this method on a window (hwnd parameter) that has not been associated with a Document Manager, then no text service
		/// notifications are sent to interested clients (such as the touch keyboard) that may want to respond to the scope change.
		/// </para>
		/// <para>Examples</para>
		/// <para>[C++]</para>
		/// <para>The following code illustrates how to set an input scope for a window.</para>
		/// <para>
		/// <code> SetInputScope(hwnd, IS_EMAIL_USERNAME);</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nf-inputscope-setinputscope HRESULT SetInputScope( HWND hwnd,
		// InputScope inputscope );
		[DllImport(Lib_Msctf, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("inputscope.h", MSDNShortId = "NF:inputscope.SetInputScope")]
		public static extern HRESULT SetInputScope(HWND hwnd, InputScope inputscope);

		/// <summary>
		/// Sets a combination of one input scope, multiple input scopes, one phrase list, a regular expression, and/or Speech Recognition
		/// Grammar Specification (SRGS) rules for the specified window.
		/// </summary>
		/// <param name="hwnd">The window to set the scope on.</param>
		/// <param name="pInputScopes">
		/// Pointer to an array of input scopes. Can be <c>NULL</c>. If not <c>NULL</c>, all of the input scopes in the array are set as the
		/// input scope of the window with equal weighting. Use IS_DEFAULT to accept all other input scopes as well.
		/// </param>
		/// <param name="cInputScopes">
		/// The number of input scopes in the array pointed to by *pInputScopes. This value must be zero if the array is <c>NULL</c>.
		/// </param>
		/// <param name="ppszPhraseList">Pointer to an array of pointers to <c>NULL</c>-terminated phrases. Can be <c>NULL</c>.</param>
		/// <param name="cPhrases">Number of pointers pointed to by **ppszPhraseList, which represents the number of phrases.</param>
		/// <param name="pszRegExp">
		/// Pointer to a <c>NULL</c>-terminated string containing the regular expression to be recognized. Can be <c>NULL</c>.
		/// </param>
		/// <param name="pszSRGS">
		/// Pointer to a <c>NULL</c>-terminated XML string that provides speech-specific hints and rules to aid in speech recognition. The
		/// XML format conforms to the Speech Recognition Grammar Specification (SRGS) standard, outlined at
		/// http://www.w3.org/TR/speech-grammar. Can be <c>NULL</c>. $
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method was successful.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Calling this method replaces whatever scope is associated with the window.</para>
		/// <para>
		/// This API works only when the window (hwnd parameter) and the calling thread are in the same thread. If you call this API for a
		/// different thread's window, it fails with E_INVALIDARG.
		/// </para>
		/// <para>
		/// If you call this method on a window (hwnd parameter) that has not been associated with a Document Manager, then no text service
		/// notifications are sent to interested clients (such as the touch keyboard) that may want to respond to the scope change.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nf-inputscope-setinputscopes HRESULT SetInputScopes( HWND hwnd,
		// const InputScope *pInputScopes, UINT cInputScopes, PWSTR *ppszPhraseList, UINT cPhrases, PWSTR pszRegExp, PWSTR pszSRGS );
		[DllImport(Lib_Msctf, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("inputscope.h", MSDNShortId = "NF:inputscope.SetInputScopes")]
		public static extern HRESULT SetInputScopes(HWND hwnd, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] InputScope[] pInputScopes, uint cInputScopes,
			[Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 4)] string[] ppszPhraseList,
			uint cPhrases, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pszRegExp, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pszSRGS);

		/// <summary>
		/// The application must call SetInputScope with IS_DEFAULT before a window is destroyed to clear the reference of the interface.
		/// </summary>
		/// <param name="hwnd">The window to set the scope on. This call will replace whatever scope may have been on the hwnd before.</param>
		/// <param name="pInputScopes">
		/// Pointer to an array of input scopes. May be <c>NULL</c>. If not <c>NULL</c>, all of the scopes contained within will be set as
		/// the input scope of the hwnd with equal weighting. Use IS_DEFAULT to accept all other input as well (this is the "don’t coerce" option).
		/// </param>
		/// <param name="cInputScopes">
		/// A count of the number of input scopes in pInputScopes. Must be zero if rgScopes is <c>NULL</c>, must be nonzero if pInputScopes
		/// is non- <c>NULL</c>.
		/// </param>
		/// <param name="pEnumString">IenumString interface pointer of the phrase list.</param>
		/// <param name="pszRegExp">
		/// Pointer to a <c>NULL</c>-terminated string describing the regular expression to be recognized. May be <c>NULL</c>.
		/// </param>
		/// <param name="pszSRGS">
		/// Pointer to a <c>NULL</c>-terminated XML string that provides speech-specific hints and rules to aid in speech recognition. The
		/// XML format conforms to the Speech Recognition Grammar Specification (SRGS) standard, outlined at
		/// http://www.w3.org/TR/speech-grammar. Can be <c>NULL</c>. $
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The input scope set or cleared successfully.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The application must call SetInputScope with IS_DEFAULT before a window is destroyed to clear the reference of the interface.</para>
		/// <para>
		/// If you call this method on a window (hwnd parameter) that has not been associated with a Document Manager, then no text service
		/// notifications are sent to interested clients (such as the touch keyboard) that may want to respond to the scope change.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nf-inputscope-setinputscopes2 HRESULT SetInputScopes2( HWND hwnd,
		// const InputScope *pInputScopes, UINT cInputScopes, IEnumString *pEnumString, PWSTR pszRegExp, PWSTR pszSRGS );
		[DllImport(Lib_Msctf, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("inputscope.h", MSDNShortId = "NF:inputscope.SetInputScopes2")]
		public static extern HRESULT SetInputScopes2(HWND hwnd, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] InputScope[] pInputScopes, uint cInputScopes,
			IEnumString pEnumString, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pszRegExp, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pszSRGS);

		/// <summary>Do not use.</summary>
		/// <param name="hwnd">N/A</param>
		/// <param name="pszXML">N/A</param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/inputscope/nf-inputscope-setinputscopexml HRESULT SetInputScopeXML( HWND hwnd,
		// PWSTR pszXML );
		[DllImport(Lib_Msctf, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("inputscope.h", MSDNShortId = "NF:inputscope.SetInputScopeXML")]
		public static extern HRESULT SetInputScopeXML(HWND hwnd, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pszXML);
	}
}