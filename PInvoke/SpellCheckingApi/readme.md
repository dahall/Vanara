## Assembly report for Vanara.PInvoke.SpellCheckingApi.dll
PInvoke API (methods, structures and constants) imported from Windows Spell Checking API.
### Enumerations
Enum | Description | Values
---- | ---- | ----
[Vanara.PInvoke.SpellCheck.CORRECTIVE_ACTION](https://github.com/dahall/Vanara/search?l=C%23&q=CORRECTIVE_ACTION) | Identifies the type of corrective action to be taken for a spelling error. | CORRECTIVE_ACTION_NONE, CORRECTIVE_ACTION_GET_SUGGESTIONS, CORRECTIVE_ACTION_REPLACE, CORRECTIVE_ACTION_DELETE
[Vanara.PInvoke.SpellCheck.WORDLIST_TYPE](https://github.com/dahall/Vanara/search?l=C%23&q=WORDLIST_TYPE) | Identifies one of the types of word lists used by spell checkers. | WORDLIST_TYPE_IGNORE, WORDLIST_TYPE_ADD, WORDLIST_TYPE_EXCLUDE, WORDLIST_TYPE_AUTOCORRECT
### Interfaces
Interface | Description
---- | ----
[Vanara.PInvoke.SpellCheckProvider.IComprehensiveSpellCheckProvider](https://github.com/dahall/Vanara/search?l=C%23&q=IComprehensiveSpellCheckProvider) | Allows the provider to optionally support a more comprehensive spell checking functionality.
[Vanara.PInvoke.SpellCheck.IEnumSpellingError](https://github.com/dahall/Vanara/search?l=C%23&q=IEnumSpellingError) | An enumeration of the spelling errors.
[Vanara.PInvoke.SpellCheck.IOptionDescription](https://github.com/dahall/Vanara/search?l=C%23&q=IOptionDescription) | Represents the description of a spell checker option.
[Vanara.PInvoke.SpellCheck.ISpellChecker](https://github.com/dahall/Vanara/search?l=C%23&q=ISpellChecker) | <p>Represents a particular spell checker for a particular language.</p> <p>The <c>ISpellChecker</c> can be used to check text, get suggestions, update user dictionaries, and maintain options.</p>
[Vanara.PInvoke.SpellCheck.ISpellChecker2](https://github.com/dahall/Vanara/search?l=C%23&q=ISpellChecker2) | <p> Represents a particular spell checker for a particular language, with the added ability to remove words from the added words dictionary, or from the ignore list. </p> <p> The <c>ISpellChecker2</c> can also be used to check text, get suggestions, update user dictionaries, and maintain options, as can ISpellChecker from which it is derived. </p>
[Vanara.PInvoke.SpellCheck.ISpellCheckerChangedEventHandler](https://github.com/dahall/Vanara/search?l=C%23&q=ISpellCheckerChangedEventHandler) | Allows the caller to create a handler for notifications that the state of the speller has changed.
[Vanara.PInvoke.SpellCheck.ISpellCheckerFactory](https://github.com/dahall/Vanara/search?l=C%23&q=ISpellCheckerFactory) | <p> A factory for instantiating a spell checker (ISpellChecker) as well as providing functionality for determining which languages are supported. </p> <p> <c>ISpellCheckerFactory</c> is the starting point for clients of the Spell Checking API, which should be created as an in-proc COM Server as shown in the example below. </p>
[Vanara.PInvoke.SpellCheckProvider.ISpellCheckProvider](https://github.com/dahall/Vanara/search?l=C%23&q=ISpellCheckProvider) | Represents a particular spell checker provider for a particular language, to be used by the spell checking infrastructure.
[Vanara.PInvoke.SpellCheckProvider.ISpellCheckProviderFactory](https://github.com/dahall/Vanara/search?l=C%23&q=ISpellCheckProviderFactory) | <p> A factory for instantiating a spell checker (ISpellCheckProvider) as well as providing functionality for determining which languages are supported. </p> <p>This is instantiated by providers and used by the Spell Checking API.</p>
[Vanara.PInvoke.SpellCheck.ISpellingError](https://github.com/dahall/Vanara/search?l=C%23&q=ISpellingError) | Provides information about a spelling error.
[Vanara.PInvoke.SpellCheck.IUserDictionariesRegistrar](https://github.com/dahall/Vanara/search?l=C%23&q=IUserDictionariesRegistrar) | Manages the registration of user dictionaries.
### Classes
Class | Description
---- | ----
[Vanara.PInvoke.SpellCheck](https://github.com/dahall/Vanara/search?l=C%23&q=SpellCheck) | Functions, constants, and interfaces for the Spell Checking API.
[Vanara.PInvoke.SpellCheck.SpellCheckerFactory](https://github.com/dahall/Vanara/search?l=C%23&q=SpellCheckerFactory) | CLSID_SpellCheckerFactory
[Vanara.PInvoke.SpellCheck.SpellCheckerOption](https://github.com/dahall/Vanara/search?l=C%23&q=SpellCheckerOption) | Consolidated class holding information about options for the spell checker.
[Vanara.PInvoke.SpellCheckProvider](https://github.com/dahall/Vanara/search?l=C%23&q=SpellCheckProvider) | Functions, constants, and interfaces for the Spell Checking API provider.
