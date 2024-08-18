using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.SpellCheck;

namespace Vanara.PInvoke;

/// <summary>Functions, constants, and interfaces for the Spell Checking API provider.</summary>
public static partial class SpellCheckProvider
{
	/// <summary>Allows the provider to optionally support a more comprehensive spell checking functionality.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nn-spellcheckprovider-icomprehensivespellcheckprovider
	[PInvokeData("spellcheckprovider.h", MSDNShortId = "NN:spellcheckprovider.IComprehensiveSpellCheckProvider")]
	[ComImport, Guid("0C58F8DE-8E94-479E-9717-70C42C4AD2C3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IComprehensiveSpellCheckProvider
	{
		/// <summary>Spell-check the provider text in a more thorough manner than <c>ISpellCheckProvider::Check</c>.</summary>
		/// <param name="text">The text to check.</param>
		/// <param name="result">The result of checking this text, as an enumeration of spelling errors ( <c>IEnumSpellingError</c>), if any.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>Successful.</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description><c>text</c> is an empty string.</description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description><c>text</c> is a null pointer.</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// </returns>
		/// <remarks>
		/// This interface isn't required to be implemented by a spell check provider. But if the provider supports two "modes" of spell checking
		/// (a faster one and a slower but more thorough one), it should implement this interface in the same object that implements
		/// <c>ISpellCheckProvider</c> to support the more thorough checking mode. When a client calls <c>ISpellChecker::ComprehensiveCheck</c>,
		/// the spell checking functionality will <c>QueryInterface</c> the provider for <c>IComprehensiveSpellCheckProvider</c>, and call
		/// <c>IComprehensiveSpellCheckProvider.ComprehensiveCheck</c> if the interface is supported. If the interface isn't supported, it will
		/// silently fall back to <c>ISpellCheckProvider::Check</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/intl/icomprehensivespellcheckprovider-comprehensivecheck HRESULT ComprehensiveCheck(
		// [in]PCWSTR text, [out]IEnumSpellingError **result );
		[PreserveSig]
		HRESULT ComprehensiveCheck(string text, out IEnumSpellingError? result);
	}

	/// <summary>Represents a particular spell checker provider for a particular language, to be used by the spell checking infrastructure.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nn-spellcheckprovider-ispellcheckprovider
	[PInvokeData("spellcheckprovider.h", MSDNShortId = "NN:spellcheckprovider.ISpellCheckProvider")]
	[ComImport, Guid("73E976E0-8ED4-4EB1-80D7-1BE0A16B0C38"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpellCheckProvider
	{
		/// <summary>
		/// <para>Gets the BCP47 language tag this instance of the spell checker supports.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nf-spellcheckprovider-ispellcheckprovider-get_languagetag
		// HRESULT get_LanguageTag( LPWSTR *value );
		[PreserveSig]
		HRESULT get_LanguageTag(out string? value);

		/// <summary>Checks the spelling of the supplied text and returns a collection of spelling errors.</summary>
		/// <param name="text">The text to check.</param>
		/// <param name="value">The result of checking this text, returned as an IEnumSpellingError object.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>Successful.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ INVALIDARG</c></description>
		/// <description><c>text</c> is an empty string.</description>
		/// </item>
		/// <item>
		/// <description><c>E_POINTER</c></description>
		/// <description><c>text</c> is a null pointer.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The returned IEnumSpellingError should contain the results of spell checking. A correct <c>text</c> should return an empty (not a
		/// null) enumeration.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nf-spellcheckprovider-ispellcheckprovider-check HRESULT Check(
		// [in] LPCWSTR text, [out, retval] IEnumSpellingError **value );
		[PreserveSig]
		HRESULT Check(string text, out IEnumSpellingError? value);

		/// <summary>Retrieves spelling suggestions for the supplied text.</summary>
		/// <param name="word">The word or phrase to get suggestions for.</param>
		/// <param name="value">The list of suggestions, returned as an IEnumString object.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>Successful.</description>
		/// </item>
		/// <item>
		/// <description><c>S_FALSE</c></description>
		/// <description><c>word</c> is correctly spelled. <c>value</c> contains one entry, which is the text that was passed in.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ INVALIDARG</c></description>
		/// <description><c>word</c> is an empty string.</description>
		/// </item>
		/// <item>
		/// <description><c>E_POINTER</c></description>
		/// <description><c>word</c> is a null pointer.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nf-spellcheckprovider-ispellcheckprovider-suggest HRESULT
		// Suggest( [in] LPCWSTR word, [out, retval] IEnumString **value );
		[PreserveSig]
		HRESULT Suggest(string word, out IEnumString? value);

		/// <summary>Retrieves the value associated with the given option.</summary>
		/// <param name="optionId">The option identifier.</param>
		/// <param name="value">The value associated with <c>optionId</c>.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>Successful.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ INVALIDARG</c></description>
		/// <description><c>optionId</c> is an empty string, or it is not one of the available options.</description>
		/// </item>
		/// <item>
		/// <description><c>E_POINTER</c></description>
		/// <description><c>optionId</c> is a null pointer.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nf-spellcheckprovider-ispellcheckprovider-getoptionvalue
		// HRESULT GetOptionValue( [in] LPCWSTR optionId, [out, retval] BYTE *value );
		[PreserveSig]
		HRESULT GetOptionValue(string optionId, out byte value);

		/// <summary>Sets the value associated with the given option.</summary>
		/// <param name="optionId">The option identifier.</param>
		/// <param name="value">The value to associate with <c>optionId</c>.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>Successful.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ INVALIDARG</c></description>
		/// <description><c>optionId</c> is an empty string, or it is not one of the available options.</description>
		/// </item>
		/// <item>
		/// <description><c>E_POINTER</c></description>
		/// <description><c>optionId</c> is a null pointer.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method is called by the system, which reads the option values that were set by the user in the control panel and sends them to
		/// the ISpellCheckProvider. If the option was not set, this method will not be called and the provider should initialize itself
		/// internally with the default value for the option.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nf-spellcheckprovider-ispellcheckprovider-setoptionvalue
		// HRESULT SetOptionValue( [in] LPCWSTR optionId, [in] BYTE value );
		[PreserveSig]
		HRESULT SetOptionValue(string optionId, byte value);

		/// <summary>
		/// <para>Gets all of the declared option identifiers recognized by the spell checker.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="value"/>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nf-spellcheckprovider-ispellcheckprovider-get_optionids HRESULT
		// get_OptionIds( IEnumString **value );
		[PreserveSig]
		HRESULT get_OptionIds(out IEnumString? value);

		/// <summary>
		/// <para>Gets the identifier for this spell checker engine.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="value"/>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nf-spellcheckprovider-ispellcheckprovider-get_id HRESULT
		// get_Id( LPWSTR *value );
		[PreserveSig]
		HRESULT get_Id(out string? value);

		/// <summary>
		/// <para>Gets text, suitable to display to the user, that describes this spell checker.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="value"/>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nf-spellcheckprovider-ispellcheckprovider-get_localizedname
		// HRESULT get_LocalizedName( LPWSTR *value );
		[PreserveSig]
		HRESULT get_LocalizedName(out string? value);

		/// <summary>Retrieves the information (id, description, heading and labels) of a specific option.</summary>
		/// <param name="optionId">Identifier of the option to be retrieved.</param>
		/// <param name="value">IOptionDescription interface that contains the information about <c>optionId</c>.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>Successful.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ INVALIDARG</c></description>
		/// <description><c>optionId</c> is an empty string, or it is not one of the available options.</description>
		/// </item>
		/// <item>
		/// <description><c>E_POINTER</c></description>
		/// <description><c>optionId</c> is a null pointer.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nf-spellcheckprovider-ispellcheckprovider-getoptiondescription
		// HRESULT GetOptionDescription( [in] LPCWSTR optionId, [out, retval] IOptionDescription **value );
		[PreserveSig]
		HRESULT GetOptionDescription(string optionId, out IOptionDescription? value);

		/// <summary>Initialize the specified word list to contain only the specified words.</summary>
		/// <param name="wordlistType">The type of word list.</param>
		/// <param name="words">The set of words to be included in the word list, passed as an IEnumString object..</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>Successful.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ INVALIDARG</c></description>
		/// <description><c>wordlistType</c> is not a valid member of the WORDLIST_TYPE enumeration.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method is called by the system (for example, when the client calls ISpellChecker::Add), which passes the words from the
		/// respective word list to the provider so that it can consider the word list when spell checking.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nf-spellcheckprovider-ispellcheckprovider-initializewordlist
		// HRESULT InitializeWordlist( [in] WORDLIST_TYPE wordlistType, [in] IEnumString *words );
		[PreserveSig]
		HRESULT InitializeWordlist(WORDLIST_TYPE wordlistType, [In, Optional] IEnumString? words);
	}

	/// <summary>
	/// <para>
	/// A factory for instantiating a spell checker (ISpellCheckProvider) as well as providing functionality for determining which languages are supported.
	/// </para>
	/// <para>This is instantiated by providers and used by the Spell Checking API.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nn-spellcheckprovider-ispellcheckproviderfactory
	[PInvokeData("spellcheckprovider.h", MSDNShortId = "NN:spellcheckprovider.ISpellCheckProviderFactory")]
	[ComImport, Guid("9F671E11-77D6-4C92-AEFB-615215E3A4BE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpellCheckProviderFactory
	{
		/// <summary>
		/// <para>Gets the set of languages/dialects supported by the spell checker.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <param name="value"/>
		/// <returns>None</returns>
		/// <remarks>The supported languages are specific, not neutral. For Hebrew, for example, the supported language is "he-IL", not "he".</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nf-spellcheckprovider-ispellcheckproviderfactory-get_supportedlanguages
		// HRESULT get_SupportedLanguages( IEnumString **value );
		[PreserveSig]
		HRESULT get_SupportedLanguages(out IEnumString? value);

		/// <summary>Determines if the specified language is supported by this spell checker.</summary>
		/// <param name="languageTag">A BCP47 language tag that identifies the language for the requested spell checker.</param>
		/// <param name="value"><c>TRUE</c> if supported; <c>FALSE</c> if not supported.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>Successful.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ INVALIDARG</c></description>
		/// <description><c>languageTag</c> is an empty string.</description>
		/// </item>
		/// <item>
		/// <description><c>E_POINTER</c></description>
		/// <description><c>languageTag</c> is a null pointer.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nf-spellcheckprovider-ispellcheckproviderfactory-issupported
		// HRESULT IsSupported( [in] LPCWSTR languageTag, [out, retval] BOOL *value );
		[PreserveSig]
		HRESULT IsSupported(string languageTag, out bool value);

		/// <summary>
		/// Creates a spell checker (implemented by a spell check provider) that supports the specified language. This interface is not used
		/// directly by clients, but by the Spell Checking API.
		/// </summary>
		/// <param name="languageTag">A BCP47 language tag that identifies the language for the requested spell checker.</param>
		/// <param name="value">The created spell checker.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_OK</c></description>
		/// <description>Successful.</description>
		/// </item>
		/// <item>
		/// <description><c>E_ INVALIDARG</c></description>
		/// <description><c>languageTag</c> is an empty string, or there is no spell checker available for <c>languageTag</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>E_POINTER</c></description>
		/// <description><c>languageTag</c> is a null pointer.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>ISpellCheckProviderFactory::IsSupported can be called to determine if <c>languageTag</c> is supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheckprovider/nf-spellcheckprovider-ispellcheckproviderfactory-createspellcheckprovider
		// HRESULT CreateSpellCheckProvider( [in] LPCWSTR languageTag, [out, retval] ISpellCheckProvider **value );
		[PreserveSig]
		HRESULT CreateSpellCheckProvider(string languageTag, out ISpellCheckProvider? value);
	}
}