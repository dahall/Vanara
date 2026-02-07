using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke;

/// <summary>Functions, constants, and interfaces for the Spell Checking API.</summary>
public static partial class SpellCheck
{
	/// <summary>Identifies the type of corrective action to be taken for a spelling error.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/ne-spellcheck-corrective_action typedef enum CORRECTIVE_ACTION {
	// CORRECTIVE_ACTION_NONE = 0, CORRECTIVE_ACTION_GET_SUGGESTIONS = 1, CORRECTIVE_ACTION_REPLACE = 2, CORRECTIVE_ACTION_DELETE = 3 } ;
	[PInvokeData("spellcheck.h", MSDNShortId = "NE:spellcheck.CORRECTIVE_ACTION")]
	public enum CORRECTIVE_ACTION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>There are no errors.</para>
		/// </summary>
		CORRECTIVE_ACTION_NONE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The user should be prompted with a list of suggestions as returned by</para>
		/// <para>ISpellChecker::Suggest</para>
		/// <para>.</para>
		/// </summary>
		CORRECTIVE_ACTION_GET_SUGGESTIONS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Replace the indicated erroneous text with the text provided in the suggestion. The user does not need to be prompted.</para>
		/// </summary>
		CORRECTIVE_ACTION_REPLACE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The user should be prompted to delete the indicated erroneous text.</para>
		/// </summary>
		CORRECTIVE_ACTION_DELETE,
	}

	/// <summary>Identifies one of the types of word lists used by spell checkers.</summary>
	/// <remarks>
	/// Providers should consider the following priority order when doing spell checking: Ignored Words &gt; AutoCorrected Words &gt;
	/// Excluded Words &gt; Added Words &gt; Spell checking algorithm.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/ne-spellcheck-wordlist_type typedef enum WORDLIST_TYPE {
	// WORDLIST_TYPE_IGNORE = 0, WORDLIST_TYPE_ADD = 1, WORDLIST_TYPE_EXCLUDE = 2, WORDLIST_TYPE_AUTOCORRECT = 3 } ;
	[PInvokeData("spellcheck.h", MSDNShortId = "NE:spellcheck.WORDLIST_TYPE")]
	public enum WORDLIST_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// Words considered to be correctly spelled, but which are not offered as suggestions. This word list isn't saved and is specific to
		/// a spelling session. (The others types of word lists are saved in the default custom dictionary files, and are global.)
		/// </para>
		/// </summary>
		WORDLIST_TYPE_IGNORE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Words considered to be correctly spelled and which can be offered as suggestions.</para>
		/// </summary>
		WORDLIST_TYPE_ADD,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Words considered to be incorrectly spelled.</para>
		/// </summary>
		WORDLIST_TYPE_EXCLUDE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Word pairs of a misspelled word and the word that should replace it.</para>
		/// </summary>
		WORDLIST_TYPE_AUTOCORRECT,
	}

	/// <summary>An enumeration of the spelling errors.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nn-spellcheck-ienumspellingerror
	[PInvokeData("spellcheck.h", MSDNShortId = "NN:spellcheck.IEnumSpellingError")]
	[ComImport, Guid("803E3BD4-2828-4410-8290-418D1D73C762"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumSpellingError
	{
		/// <summary>Gets the next spelling error.</summary>
		/// <param name="value">The spelling error (ISpellingError) returned.</param>
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
		/// <description>There is no spelling error left to return. <c>value</c> does not point at a valid ISpellingError.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If there are no spelling errors, this will return <c>S_FALSE</c>. This provides a way for a provider to implement spell checking
		/// lazily if desired—instead of doing the spell checking work on ISpellCheckProvider::Check and getting all the errors at once, you
		/// can do it only as needed when this method is called, getting one error per call.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ienumspellingerror-next HRESULT Next( [out, retval]
		// ISpellingError **value );
		[PreserveSig]
		HRESULT Next([MarshalAs(UnmanagedType.Interface)] out ISpellingError? value);
	}

	/// <summary>Represents the description of a spell checker option.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nn-spellcheck-ioptiondescription
	[PInvokeData("spellcheck.h", MSDNShortId = "NN:spellcheck.IOptionDescription")]
	[ComImport, Guid("432E5F85-35CF-4606-A801-6F70277E1D7A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOptionDescription
	{
		/// <summary>
		/// <para>Gets the identifier of the spell checker option.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Option identifiers all exist in the same area. Spell checker providers should use the engine identifier and the language tag (if
		/// the option is language-specific) to disambiguate potential collisions.
		/// </para>
		/// <para>Specifically, the structure for naming the option identifiers should be:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>For the Microsoft spell checker engine:</c> &lt;language tag&gt;:&lt;option name&gt;. For example, "pt-BR:2009Reform."</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>For spell check provider engines:</c> &lt;engine id&gt;:&lt;language tag&gt;:&lt;option name&gt; (the language tag may be
		/// omitted if the option is not language specific). For example, "samplespell:fr-FR:AccentedUppercase".
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c>  Spell check providers are allowed to support existing Microsoft option identifiers, but they must not create new
		/// option identifiers in the Microsoft namespace. That is, spell check providers must use the engine identifier as a prefix.
		/// </para>
		/// <para></para>
		/// <para>
		/// An option identifier is linked to the set of labels and the semantics associated with them. If any change needs to be made
		/// between versions to the option (adding a label to the set of labels), a new option with a new identifier must be used. The only
		/// valid change that does not require a new identifier is to change from a single label to two labels and vice-versa when the
		/// semantics for values 0 and 1 do not change.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ioptiondescription-get_id HRESULT get_Id( StrPtrUni
		// *value );
		string Id { [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		/// <summary>
		/// <para>Gets the heading for the spell checker option.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The heading can be used to group sets of options by placing the header on the first item of that group. This should be in the
		/// language of the spell checker or localized to the user's UI language.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ioptiondescription-get_heading HRESULT get_Heading(
		// StrPtrUni *value );
		string Heading { [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		/// <summary>
		/// <para>Get the description of the spell checker option.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The description explains the implications of making the various choices associated with the option. This should be in the
		/// language of the spell checker or localized to the user's UI language.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ioptiondescription-get_description HRESULT
		// get_Description( StrPtrUni *value );
		string Description { [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		/// <summary>
		/// <para>Gets the label enumerator for the spell checker option.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// When there is a single label, the valid values for this option are 0 (not chosen) and 1 (chosen). When there is more than one
		/// label, the first label is associated with the value 0, the second with 1, and so on, effectively forming an enumeration. The
		/// labels should be in the language of the spell checker or localized to the user's UI language.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ioptiondescription-get_labels HRESULT get_Labels(
		// IEnumString **value );
		IEnumString Labels { [return: MarshalAs(UnmanagedType.Interface)] get; }
	}

	/// <summary>
	/// <para>Represents a particular spell checker for a particular language.</para>
	/// <para>The <c>ISpellChecker</c> can be used to check text, get suggestions, update user dictionaries, and maintain options.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nn-spellcheck-ispellchecker
	[PInvokeData("spellcheck.h", MSDNShortId = "NN:spellcheck.ISpellChecker")]
	[ComImport, Guid("B6FD0B71-E2BC-4653-8D05-F197E412770B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpellChecker
	{
		/// <summary>
		/// <para>Gets the BCP47 language tag this instance of the spell checker supports.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-get_languagetag HRESULT
		// get_LanguageTag( StrPtrUni *value );
		string LanguageTag { [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		/// <summary>Checks the spelling of the supplied text and returns a collection of spelling errors.</summary>
		/// <param name="text">The text to check.</param>
		/// <returns>The result of checking this text, returned as an IEnumSpellingError object.</returns>
		/// <remarks>
		/// The returned IEnumSpellingError contains the results of spell checking. A correct <c>text</c> returns an empty (not a null) enumeration.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-check HRESULT Check( [in] LPCWSTR text,
		// [out, retval] IEnumSpellingError **value );
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumSpellingError Check([MarshalAs(UnmanagedType.LPWStr)] string text);

		/// <summary>Retrieves spelling suggestions for the supplied text.</summary>
		/// <param name="word">The word or phrase to get suggestions for.</param>
		/// <returns>The list of suggestions, returned as an IEnumString object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-suggest HRESULT Suggest( [in] LPCWSTR
		// word, [out, retval] IEnumString **value );
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumString Suggest([MarshalAs(UnmanagedType.LPWStr)] string word);

		/// <summary>
		/// <para>Treats the provided word as though it were part of the original dictionary.</para>
		/// <para>The word will no longer be considered misspelled, and will also be considered as a candidate for suggestions.</para>
		/// </summary>
		/// <param name="word">The word to be added to the list of added words.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-add HRESULT Add( [in] LPCWSTR word );
		void Add([MarshalAs(UnmanagedType.LPWStr)] string word);

		/// <summary>
		/// <para>Ignores the provided word for the rest of this session.</para>
		/// <para>
		/// Until this ISpellChecker interface is released, the word will no longer be considered misspelled, but it will not be considered
		/// as a candidate for suggestions.
		/// </para>
		/// </summary>
		/// <param name="word">The word to ignore.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-ignore HRESULT Ignore( [in] LPCWSTR
		// word );
		void Ignore([MarshalAs(UnmanagedType.LPWStr)] string word);

		/// <summary>Causes occurrences of one word to be replaced by another.</summary>
		/// <param name="from">The incorrectly spelled word to be autocorrected.</param>
		/// <param name="to">The correctly spelled word that should replace <c>from</c>.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-autocorrect HRESULT AutoCorrect( [in]
		// LPCWSTR from, [in] LPCWSTR to );
		void AutoCorrect([MarshalAs(UnmanagedType.LPWStr)] string from, [MarshalAs(UnmanagedType.LPWStr)] string to);

		/// <summary>Retrieves the value associated with the given option.</summary>
		/// <param name="optionId">The option identifier.</param>
		/// <returns>The value associated with <c>optionId</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-getoptionvalue HRESULT GetOptionValue(
		// [in] LPCWSTR optionId, [out, retval] BYTE *value );
		byte GetOptionValue([MarshalAs(UnmanagedType.LPWStr)] string optionId);

		/// <summary>
		/// <para>Gets all of the declared option identifiers.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-get_optionids HRESULT get_OptionIds(
		// IEnumString **value );
		IEnumString OptionIds { [return: MarshalAs(UnmanagedType.Interface)] get; }

		/// <summary>
		/// <para>Gets the identifier for this spell checker.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-get_id HRESULT get_Id( StrPtrUni *value );
		string Id { [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		/// <summary>
		/// <para>Gets text, suitable to display to the user, that describes this spell checker.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-get_localizedname HRESULT
		// get_LocalizedName( StrPtrUni *value );
		string LocalizedName { [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		/// <summary>Adds an event handler (ISpellCheckerChangedEventHandler) for the SpellCheckerChanged event.</summary>
		/// <param name="handler">The handler to invoke when the spell checker changes.</param>
		/// <param name="eventCookie">
		/// An event cookie that uniquely identifies the added handler. This cookie must be passed to remove_SpellCheckerChanged to stop this
		/// handler from being invoked by spell checker changes.
		/// </param>
		/// <remarks>
		/// The SpellCheckerChanged event fires whenever the state of the spell checker changes in a way such that any text that has been
		/// checked should be rechecked. This should happen when the contents of a word list changes, when an option changes, or when the
		/// default spell checker changes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-add_spellcheckerchanged HRESULT
		// add_SpellCheckerChanged( [in] ISpellCheckerChangedEventHandler *handler, [out, retval] DWORD *eventCookie );
		void add_SpellCheckerChanged([In, Optional, MarshalAs(UnmanagedType.Interface)] ISpellCheckerChangedEventHandler handler, out uint eventCookie);

		/// <summary>Removes an event handler (ISpellCheckerChangedEventHandler) that has been added for the SpellCheckerChanged event.</summary>
		/// <param name="eventCookie">
		/// The event cookie that uniquely identifies the added handler. This is the <c>eventCookie</c> that was obtained from the call to add_SpellCheckerChanged.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-remove_spellcheckerchanged HRESULT
		// remove_SpellCheckerChanged( [in] DWORD eventCookie );
		void remove_SpellCheckerChanged(uint eventCookie);

		/// <summary>Retrieves the information (id, description, heading and labels) of a specific option.</summary>
		/// <param name="optionId">Identifier of the option to be retrieved.</param>
		/// <returns>IOptionDescription interface that contains the information about <c>optionId</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-getoptiondescription HRESULT
		// GetOptionDescription( [in] LPCWSTR optionId, [out, retval] IOptionDescription **value );
		[return: MarshalAs(UnmanagedType.Interface)]
		IOptionDescription GetOptionDescription([MarshalAs(UnmanagedType.LPWStr)] string optionId);

		/// <summary>
		/// Checks the spelling of the supplied text in a more thorough manner than ISpellChecker::Check, and returns a collection of
		/// spelling errors.
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <returns>The result of checking this text, returned as an IEnumSpellingError object.</returns>
		/// <remarks>
		/// <para>
		/// The returned IEnumSpellingError contains the results of spell checking. A correct <c>text</c> returns an empty (not a null) enumeration.
		/// </para>
		/// <para>
		/// If the provider supports two "modes" of spell checking (a faster one and a slower but more thorough one), it implements
		/// IComprehensiveSpellCheckProvider to support the more thorough checking mode. When a client calls
		/// <c>ISpellChecker::ComprehensiveCheck</c>, the spell checking functionality will QueryInterface the provider for
		/// <c>IComprehensiveSpellCheckProvider</c>, and call IComprehensiveSpellCheckProvider.ComprehensiveCheck if the interface is
		/// supported. If the interface isn't supported, it will silently fall back to ISpellCheckProvider::Check.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-comprehensivecheck HRESULT
		// ComprehensiveCheck( [in] LPCWSTR text, [out, retval] IEnumSpellingError **value );
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumSpellingError ComprehensiveCheck([MarshalAs(UnmanagedType.LPWStr)] string text);
	}

	/// <summary>
	/// <para>
	/// Represents a particular spell checker for a particular language, with the added ability to remove words from the added words
	/// dictionary, or from the ignore list.
	/// </para>
	/// <para>
	/// The <c>ISpellChecker2</c> can also be used to check text, get suggestions, update user dictionaries, and maintain options, as can
	/// ISpellChecker from which it is derived.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nn-spellcheck-ispellchecker2
	[PInvokeData("spellcheck.h", MSDNShortId = "NN:spellcheck.ISpellChecker2")]
	[ComImport, Guid("E7ED1C71-87F7-4378-A840-C9200DACEE47"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpellChecker2 : ISpellChecker
	{
		/// <summary>
		/// <para>Gets the BCP47 language tag this instance of the spell checker supports.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-get_languagetag HRESULT
		// get_LanguageTag( StrPtrUni *value );
		new string LanguageTag { [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		/// <summary>Checks the spelling of the supplied text and returns a collection of spelling errors.</summary>
		/// <param name="text">The text to check.</param>
		/// <returns>The result of checking this text, returned as an IEnumSpellingError object.</returns>
		/// <remarks>
		/// The returned IEnumSpellingError contains the results of spell checking. A correct <c>text</c> returns an empty (not a null) enumeration.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-check HRESULT Check( [in] LPCWSTR text,
		// [out, retval] IEnumSpellingError **value );
		[return: MarshalAs(UnmanagedType.Interface)]
		new IEnumSpellingError Check([MarshalAs(UnmanagedType.LPWStr)] string text);

		/// <summary>Retrieves spelling suggestions for the supplied text.</summary>
		/// <param name="word">The word or phrase to get suggestions for.</param>
		/// <returns>The list of suggestions, returned as an IEnumString object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-suggest HRESULT Suggest( [in] LPCWSTR
		// word, [out, retval] IEnumString **value );
		[return: MarshalAs(UnmanagedType.Interface)]
		new IEnumString Suggest([MarshalAs(UnmanagedType.LPWStr)] string word);

		/// <summary>
		/// <para>Treats the provided word as though it were part of the original dictionary.</para>
		/// <para>The word will no longer be considered misspelled, and will also be considered as a candidate for suggestions.</para>
		/// </summary>
		/// <param name="word">The word to be added to the list of added words.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-add HRESULT Add( [in] LPCWSTR word );
		new void Add([MarshalAs(UnmanagedType.LPWStr)] string word);

		/// <summary>
		/// <para>Ignores the provided word for the rest of this session.</para>
		/// <para>
		/// Until this ISpellChecker interface is released, the word will no longer be considered misspelled, but it will not be considered
		/// as a candidate for suggestions.
		/// </para>
		/// </summary>
		/// <param name="word">The word to ignore.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-ignore HRESULT Ignore( [in] LPCWSTR
		// word );
		new void Ignore([MarshalAs(UnmanagedType.LPWStr)] string word);

		/// <summary>Causes occurrences of one word to be replaced by another.</summary>
		/// <param name="from">The incorrectly spelled word to be autocorrected.</param>
		/// <param name="to">The correctly spelled word that should replace <c>from</c>.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-autocorrect HRESULT AutoCorrect( [in]
		// LPCWSTR from, [in] LPCWSTR to );
		new void AutoCorrect([MarshalAs(UnmanagedType.LPWStr)] string from, [MarshalAs(UnmanagedType.LPWStr)] string to);

		/// <summary>Retrieves the value associated with the given option.</summary>
		/// <param name="optionId">The option identifier.</param>
		/// <returns>The value associated with <c>optionId</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-getoptionvalue HRESULT GetOptionValue(
		// [in] LPCWSTR optionId, [out, retval] BYTE *value );
		new byte GetOptionValue([MarshalAs(UnmanagedType.LPWStr)] string optionId);

		/// <summary>
		/// <para>Gets all of the declared option identifiers.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-get_optionids HRESULT get_OptionIds(
		// IEnumString **value );
		new IEnumString OptionIds { [return: MarshalAs(UnmanagedType.Interface)] get; }

		/// <summary>
		/// <para>Gets the identifier for this spell checker.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-get_id HRESULT get_Id( StrPtrUni *value );
		new string Id { [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		/// <summary>
		/// <para>Gets text, suitable to display to the user, that describes this spell checker.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-get_localizedname HRESULT
		// get_LocalizedName( StrPtrUni *value );
		new string LocalizedName { [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		/// <summary>Adds an event handler (ISpellCheckerChangedEventHandler) for the SpellCheckerChanged event.</summary>
		/// <param name="handler">The handler to invoke when the spell checker changes.</param>
		/// <param name="eventCookie">
		/// An event cookie that uniquely identifies the added handler. This cookie must be passed to remove_SpellCheckerChanged to stop this
		/// handler from being invoked by spell checker changes.
		/// </param>
		/// <remarks>
		/// The SpellCheckerChanged event fires whenever the state of the spell checker changes in a way such that any text that has been
		/// checked should be rechecked. This should happen when the contents of a word list changes, when an option changes, or when the
		/// default spell checker changes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-add_spellcheckerchanged HRESULT
		// add_SpellCheckerChanged( [in] ISpellCheckerChangedEventHandler *handler, [out, retval] DWORD *eventCookie );
		new void add_SpellCheckerChanged([In, Optional, MarshalAs(UnmanagedType.Interface)] ISpellCheckerChangedEventHandler? handler, out uint eventCookie);

		/// <summary>Removes an event handler (ISpellCheckerChangedEventHandler) that has been added for the SpellCheckerChanged event.</summary>
		/// <param name="eventCookie">
		/// The event cookie that uniquely identifies the added handler. This is the <c>eventCookie</c> that was obtained from the call to add_SpellCheckerChanged.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-remove_spellcheckerchanged HRESULT
		// remove_SpellCheckerChanged( [in] DWORD eventCookie );
		new void remove_SpellCheckerChanged(uint eventCookie);

		/// <summary>Retrieves the information (id, description, heading and labels) of a specific option.</summary>
		/// <param name="optionId">Identifier of the option to be retrieved.</param>
		/// <returns>IOptionDescription interface that contains the information about <c>optionId</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-getoptiondescription HRESULT
		// GetOptionDescription( [in] LPCWSTR optionId, [out, retval] IOptionDescription **value );
		[return: MarshalAs(UnmanagedType.Interface)]
		new IOptionDescription GetOptionDescription([MarshalAs(UnmanagedType.LPWStr)] string optionId);

		/// <summary>
		/// Checks the spelling of the supplied text in a more thorough manner than ISpellChecker::Check, and returns a collection of
		/// spelling errors.
		/// </summary>
		/// <param name="text">The text to check.</param>
		/// <returns>The result of checking this text, returned as an IEnumSpellingError object.</returns>
		/// <remarks>
		/// <para>
		/// The returned IEnumSpellingError contains the results of spell checking. A correct <c>text</c> returns an empty (not a null) enumeration.
		/// </para>
		/// <para>
		/// If the provider supports two "modes" of spell checking (a faster one and a slower but more thorough one), it implements
		/// IComprehensiveSpellCheckProvider to support the more thorough checking mode. When a client calls
		/// <c>ISpellChecker::ComprehensiveCheck</c>, the spell checking functionality will QueryInterface the provider for
		/// <c>IComprehensiveSpellCheckProvider</c>, and call IComprehensiveSpellCheckProvider.ComprehensiveCheck if the interface is
		/// supported. If the interface isn't supported, it will silently fall back to ISpellCheckProvider::Check.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker-comprehensivecheck HRESULT
		// ComprehensiveCheck( [in] LPCWSTR text, [out, retval] IEnumSpellingError **value );
		[return: MarshalAs(UnmanagedType.Interface)]
		new IEnumSpellingError ComprehensiveCheck([MarshalAs(UnmanagedType.LPWStr)] string text);

		/// <summary>Removes a word that was previously added by ISpellChecker.Add, or set by ISpellChecker.Ignore to be ignored.</summary>
		/// <param name="word">
		/// The word to be removed from the list of added words, or from the list of ignored words. If the word is not present, nothing will
		/// be removed.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellchecker2-remove HRESULT Remove( [in] LPCWSTR
		// word );
		void Remove([MarshalAs(UnmanagedType.LPWStr)] string word);
	}

	/// <summary>Allows the caller to create a handler for notifications that the state of the speller has changed.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nn-spellcheck-ispellcheckerchangedeventhandler
	[PInvokeData("spellcheck.h", MSDNShortId = "NN:spellcheck.ISpellCheckerChangedEventHandler")]
	[ComImport, Guid("0B83A5B0-792F-4EAB-9799-ACF52C5ED08A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpellCheckerChangedEventHandler
	{
		/// <summary>Receives the SpellCheckerChanged event.</summary>
		/// <param name="sender">The ISpellChecker that fired the event.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// This method is called when there is a change to the state of the spell checker that could cause text to be treated differently. A
		/// client should recheck the text when this event is received.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellcheckerchangedeventhandler-invoke HRESULT
		// Invoke( [in] ISpellChecker *sender );
		[PreserveSig]
		HRESULT Invoke([In, Optional, MarshalAs(UnmanagedType.Interface)] ISpellChecker? sender);
	}

	/// <summary>
	/// <para>
	/// A factory for instantiating a spell checker (ISpellChecker) as well as providing functionality for determining which languages are supported.
	/// </para>
	/// <para>
	/// <c>ISpellCheckerFactory</c> is the starting point for clients of the Spell Checking API, which should be created as an in-proc COM
	/// Server as shown in the example below.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nn-spellcheck-ispellcheckerfactory
	[PInvokeData("spellcheck.h", MSDNShortId = "NN:spellcheck.ISpellCheckerFactory")]
	[ComImport, Guid("8E018A9D-2415-4677-BF08-794EA61F94BB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SpellCheckerFactory))]
	public interface ISpellCheckerFactory
	{
		/// <summary>
		/// <para>Gets the set of languages/dialects supported by any of the registered spell checkers.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// The supported languages are specific, not neutral. For Hebrew, for example, the supported language is "he-IL", not "he".
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellcheckerfactory-get_supportedlanguages HRESULT
		// get_SupportedLanguages( IEnumString **value );
		IEnumString SupportedLanguages { [return: MarshalAs(UnmanagedType.Interface)] get; }

		/// <summary>Determines if the specified language is supported by a registered spell checker.</summary>
		/// <param name="languageTag">A BCP47 language tag that identifies the language for the requested spell checker.</param>
		/// <returns><c>TRUE</c> if supported; <c>FALSE</c> if not supported.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellcheckerfactory-issupported HRESULT IsSupported(
		// [in] LPCWSTR languageTag, [out, retval] BOOL *value );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsSupported([MarshalAs(UnmanagedType.LPWStr)] string languageTag);

		/// <summary>Creates a spell checker that supports the specified language.</summary>
		/// <param name="languageTag">A BCP47 language tag that identifies the language for the requested spell checker.</param>
		/// <returns>The created spell checker.</returns>
		/// <remarks>
		/// ISpellCheckerFactory::IsSupported can be called to determine if <c>languageTag</c> is supported. This will create the preferred
		/// spell checker (according to user ranking) for the given language.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellcheckerfactory-createspellchecker HRESULT
		// CreateSpellChecker( [in] LPCWSTR languageTag, [out, retval] ISpellChecker **value );
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpellChecker CreateSpellChecker([MarshalAs(UnmanagedType.LPWStr)] string languageTag);
	}

	/// <summary>Provides information about a spelling error.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nn-spellcheck-ispellingerror
	[PInvokeData("spellcheck.h", MSDNShortId = "NN:spellcheck.ISpellingError")]
	[ComImport, Guid("B7C82D61-FBE8-4B47-9B27-6C0D2E0DE0A3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpellingError
	{
		/// <summary>
		/// <para>Gets the position in the checked text where the error begins.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellingerror-get_startindex HRESULT get_StartIndex(
		// ULONG *value );
		uint StartIndex { get; }

		/// <summary>
		/// <para>Gets the length of the erroneous text.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellingerror-get_length HRESULT get_Length( ULONG
		// *value );
		uint Length { get; }

		/// <summary>
		/// <para>Indicates which corrective action should be taken for the spelling error.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellingerror-get_correctiveaction HRESULT
		// get_CorrectiveAction( CORRECTIVE_ACTION *value );
		CORRECTIVE_ACTION CorrectiveAction { get; }

		/// <summary>
		/// <para>Gets the text to use as replacement text when the corrective action is replace.</para>
		/// <para>This property is read-only.</para>
		/// </summary>
		/// <remarks>
		/// If the CORRECTIVE_ACTION returned by CorrectiveAction is not <c>CORRECTIVE_ACTION_REPLACE</c>, <c>value</c> is the empty string.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-ispellingerror-get_replacement HRESULT
		// get_Replacement( StrPtrUni *value );
		string Replacement { [return: MarshalAs(UnmanagedType.LPWStr)] get; }
	}

	/// <summary>Manages the registration of user dictionaries.</summary>
	/// <remarks>
	/// <para>
	/// <c>IUserDictionariesRegistrar</c> allows clients to persistently register and unregister user dictionary files that exist in
	/// locations other than the usual dictionary path (). The dictionaries must have the same file formats as the ones located in the normal
	/// path and also should have the appropriate file extensions. However, it is strongly recommended for clients to place their
	/// dictionaries under whenever possible—the spell checking functionality does not pick up changes in dictionaries outside that directory tree.
	/// </para>
	/// <para>This interface is obtained through a QueryInterface in ISpellCheckerFactory.</para>
	/// <para>
	/// The combined size of all registered dictionary files must be less than 1 MB by default. This can be increased to 2 MB by setting the
	/// registry key HKEY_CURRENT_USER\Software\Microsoft\Spelling\Dictionaries\AllowBiggerUD to the value 1. For more information about the
	/// Windows registry, see Registry.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nn-spellcheck-iuserdictionariesregistrar
	[PInvokeData("spellcheck.h", MSDNShortId = "NN:spellcheck.IUserDictionariesRegistrar")]
	[ComImport, Guid("AA176B85-0E12-4844-8E1A-EEF1DA77F586"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SpellCheckerFactory))]
	public interface IUserDictionariesRegistrar
	{
		/// <summary>Registers a file to be used as a user dictionary for the current user, until unregistered.</summary>
		/// <param name="dictionaryPath">The path of the dictionary file to be registered.</param>
		/// <param name="languageTag">The language for which this dictionary should be used. If left empty, it will be used for any language.</param>
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
		/// <description>S_FALSE</description>
		/// <description>The file is already registered for the language.</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>The file doesn’t exist or isn't valid, or it doesn't have a valid extension (.dic, .exc, or .acl)</description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// <description><c>dictionaryPath</c> or <c>languageTag</c> is a null pointer.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The filename must have the extension .dic (added words), .exc (excluded words), or .acl (autocorrect word pairs). The files are
		/// UTF-16 LE plaintext that must start with the appropriate Byte Order Mark (BOM). Each line contains a word (in the Added and
		/// Excluded word lists), or an autocorrect pair with the words separated by a vertical bar ("|") (in the AutoCorrect word list). The
		/// wordlist in which the dictionary is included is inferred through the file extension.
		/// </para>
		/// <para>
		/// A file registered for a language subtag will be picked up for all languages that contain it. For example, a dictionary registered
		/// for "en" will also be used by an "en-US" spell checker.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-iuserdictionariesregistrar-registeruserdictionary
		// HRESULT RegisterUserDictionary( [in] LPCWSTR dictionaryPath, [in] LPCWSTR languageTag );
		[PreserveSig]
		HRESULT RegisterUserDictionary([MarshalAs(UnmanagedType.LPWStr)] string dictionaryPath, [MarshalAs(UnmanagedType.LPWStr)] string languageTag);

		/// <summary>
		/// Unregisters a previously registered user dictionary. The dictionary will no longer be used by the spell checking functionality.
		/// </summary>
		/// <param name="dictionaryPath">The path of the dictionary file to be unregistered.</param>
		/// <param name="languageTag">The language for which this dictionary was used. It must match the language passed to RegisterUserDictionary.</param>
		/// <remarks>
		/// <para>
		/// <c>Note</c>  To unregister a given file, this method must be passed the same arguments that were previously used to register it.
		/// </para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/spellcheck/nf-spellcheck-iuserdictionariesregistrar-unregisteruserdictionary
		// HRESULT UnregisterUserDictionary( [in] LPCWSTR dictionaryPath, [in] LPCWSTR languageTag );
		void UnregisterUserDictionary([MarshalAs(UnmanagedType.LPWStr)] string dictionaryPath, [MarshalAs(UnmanagedType.LPWStr)] string languageTag);
	}

	/// <summary>Enumerates the specified <see cref="IEnumSpellingError"/>.</summary>
	/// <param name="err">The spelling error enumeration interface.</param>
	/// <returns>A sequence of <see cref="ISpellingError"/> instances.</returns>
	public static IEnumerable<ISpellingError> Enum(this IEnumSpellingError? err)
	{
		if (err is null)
			yield break;
		while (err.Next(out ISpellingError? errDetail) == HRESULT.S_OK)
			yield return errDetail!;
	}

	/// <summary>Gets information about all the options associated with the specified <see cref="ISpellChecker"/> instance.</summary>
	/// <param name="checker">The <see cref="ISpellChecker"/> instance.</param>
	/// <returns>A sequence of <see cref="SpellCheckerOption"/> values.</returns>
	public static IEnumerable<SpellCheckerOption> GetOptions(this ISpellChecker checker)
	{
		if (checker is not null)
		{
			var opts = checker.OptionIds;
			if (opts is not null)
			{
				try
				{
					return opts.Enum().Select(o => new SpellCheckerOption(checker, o)).ToArray();
				}
				finally
				{
					Marshal.ReleaseComObject(opts);
				}
			}
		}
		return [];
	}

	/// <summary>CLSID_SpellCheckerFactory</summary>
	[ComImport, Guid("7AB36653-1796-484B-BDFA-E74F1DB7C1DC"), ClassInterface(ClassInterfaceType.None)]
	public class SpellCheckerFactory { }

	/// <summary>Consolidated class holding information about options for the spell checker.</summary>
	public class SpellCheckerOption
	{
		/// <summary>Initializes a new instance of the <see cref="SpellCheckerOption"/> class.</summary>
		/// <param name="chk">A <see cref="ISpellChecker"/> instance.</param>
		/// <param name="id">A declared option identifier.</param>
		public SpellCheckerOption(ISpellChecker chk, string id)
		{
			Id = id;
			Value = chk.GetOptionValue(id);
			var od = chk.GetOptionDescription(id);
			try
			{
				Heading = od.Heading;
				Description = od.Description;
				var lbl = od.Labels;
				try
				{
					Labels = lbl.Enum().ToArray();
				}
				finally
				{
					Marshal.ReleaseComObject(lbl);
				}
			}
			finally
			{
				Marshal.ReleaseComObject(od);
			}
		}

		/// <summary>Get the description of the spell checker option.</summary>
		/// <remarks>
		/// The description explains the implications of making the various choices associated with the option. This should be in the
		/// language of the spell checker or localized to the user's UI language.
		/// </remarks>
		public string Description { get; }

		/// <summary>Gets the heading for the spell checker option.</summary>
		/// <remarks>
		/// The heading can be used to group sets of options by placing the header on the first item of that group. This should be in the
		/// language of the spell checker or localized to the user's UI language.
		/// </remarks>
		public string Heading { get; }

		/// <summary>Gets the identifier of the spell checker option.</summary>
		/// <remarks>
		/// <para>
		/// Option identifiers all exist in the same area. Spell checker providers should use the engine identifier and the language tag (if
		/// the option is language-specific) to disambiguate potential collisions.
		/// </para>
		/// <para>Specifically, the structure for naming the option identifiers should be:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>For the Microsoft spell checker engine:</c> &lt;language tag&gt;:&lt;option name&gt;. For example, "pt-BR:2009Reform."</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>For spell check provider engines:</c> &lt;engine id&gt;:&lt;language tag&gt;:&lt;option name&gt; (the language tag may be
		/// omitted if the option is not language specific). For example, "samplespell:fr-FR:AccentedUppercase".
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c>  Spell check providers are allowed to support existing Microsoft option identifiers, but they must not create new
		/// option identifiers in the Microsoft namespace. That is, spell check providers must use the engine identifier as a prefix.
		/// </para>
		/// <para></para>
		/// <para>
		/// An option identifier is linked to the set of labels and the semantics associated with them. If any change needs to be made
		/// between versions to the option (adding a label to the set of labels), a new option with a new identifier must be used. The only
		/// valid change that does not require a new identifier is to change from a single label to two labels and vice-versa when the
		/// semantics for values 0 and 1 do not change.
		/// </para>
		/// </remarks>
		public string Id { get; }

		/// <summary>
		/// <para>Gets the labels for the spell checker option.</para>
		/// </summary>
		/// <remarks>
		/// When there is a single label, the valid values for this option are 0 (not chosen) and 1 (chosen). When there is more than one
		/// label, the first label is associated with the value 0, the second with 1, and so on, effectively forming an enumeration. The
		/// labels should be in the language of the spell checker or localized to the user's UI language.
		/// </remarks>
		public string[] Labels { get; }

		/// <summary>Gets the value associated with the given option.</summary>
		public byte Value { get; }
	}
}