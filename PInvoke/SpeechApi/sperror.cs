namespace Vanara.PInvoke;

public static partial class SpeechApi
{
	static SpeechApi() => StaticFieldValueHash.AddFields<HRESULT, int, SPERR>();

	public enum SPERR
	{
		/// <summary>
		/// S_LIMIT_REACHED 0x0004507F 282751
		/// <para>The word being normalized has generated more than the maximum number of allowed normalized results</para>
		/// <para>Indicates that returned list is not exhaustive, but contains as many alternatives as the engine is willing to provide.</para>
		/// </summary>
		S_LIMIT_REACHED = unchecked((int)(0x00045000 | 0x07F)),

		/// <summary>
		/// S_NOTSUPPORTED 0x00045080 282752
		/// <para>We currently don't support this combination of function call + input</para>
		/// </summary>
		S_NOTSUPPORTED = unchecked((int)(0x00045000 | 0x080)),

		/// <summary>
		/// SP_ALREADY_IN_LEX 0x00045018 282648
		/// <para>The word, pronunciation, or POS pair being added is already in lexicon.</para>
		/// </summary>
		SP_ALREADY_IN_LEX = unchecked((int)(0x00045000 | 0x018)),

		/// <summary>
		/// SP_AUDIO_CONVERSION_ENABLED 0x00045015 282645
		/// <para>The operation was successful, but only with automatic stream format conversion.</para>
		/// </summary>
		SP_AUDIO_CONVERSION_ENABLED = unchecked((int)(0x00045000 | 0x015)),

		/// <summary>
		/// SP_AUDIO_PAUSED 0x00045010 282640
		/// <para>This will be returned only on input (read) streams when the stream is paused. Reads on</para>
		/// <para>paused streams will not block, and this return code indicates that all of the data has been</para>
		/// <para>removed from the stream.</para>
		/// </summary>
		SP_AUDIO_PAUSED = unchecked((int)(0x00045000 | 0x010)),

		/// <summary>
		/// SP_AUDIO_STOPPED 0x00045065 282725
		/// <para>This can be returned from Read or Write calls audio streams when the stream is stopped.</para>
		/// </summary>
		SP_AUDIO_STOPPED = unchecked((int)(0x00045000 | 0x065)),

		/// <summary>
		/// SP_COMPLETE_BUT_EXTENDABLE 0x00045074 282740
		/// <para>Parse is valid but could be extendable (internal use only)</para>
		/// </summary>
		SP_COMPLETE_BUT_EXTENDABLE = unchecked((int)(0x00045000 | 0x074)),

		/// <summary>
		/// SP_END_OF_STREAM 0x00045005 282629
		/// <para>The operation has reached the end of stream.</para>
		/// </summary>
		SP_END_OF_STREAM = unchecked((int)(0x00045000 | 0x005)),

		/// <summary>SP_INSUFFICIENTDATA 0x0004500b 282635</summary>
		SP_INSUFFICIENT_DATA = unchecked((int)(0x00045000 | 0x00b)),

		/// <summary>
		/// SP_LEX_NOTHING_TO_SYNC 0x0004501a 282650
		/// <para>The client is currently synced with the lexicon.</para>
		/// </summary>
		SP_LEX_NOTHING_TO_SYNC = unchecked((int)(0x00045000 | 0x01a)),

		/// <summary>
		/// SP_NO_HYPOTHESIS_AVAILABLE 0x00045016 282646
		/// <para>There is currently no hypothesis recognition available.</para>
		/// </summary>
		SP_NO_HYPOTHESIS_AVAILABLE = unchecked((int)(0x00045000 | 0x016)),

		/// <summary>
		/// SP_NO_PARSE_FOUND 0x0004502c 282668
		/// <para>Parse path cannot be parsed given the currently active rules.</para>
		/// </summary>
		SP_NO_PARSE_FOUND = unchecked((int)(0x00045000 | 0x02c)),

		/// <summary>
		/// SP_NO_RULE_ACTIVE 0x00045055 282709
		/// <para>An attempt to parse when no rule was active.</para>
		/// </summary>
		SP_NO_RULE_ACTIVE = unchecked((int)(0x00045000 | 0x055)),

		/// <summary>
		/// SP_NO_RULES_TO_ACTIVATE 0x0004507B 282747
		/// <para>The grammar does not have any root or top-level active rules to activate.</para>
		/// </summary>
		SP_NO_RULES_TO_ACTIVATE = unchecked((int)(0x00045000 | 0x07B)),

		/// <summary>
		/// SP_NO_WORDENTRY_NOTIFICATION 0x0004507C 282748
		/// <para>The engine does not need SAPI word entry handles for this grammar</para>
		/// </summary>
		SP_NO_WORDENTRY_NOTIFICATION = unchecked((int)(0x00045000 | 0x07C)),

		/// <summary>
		/// SP_PARTIAL_PARSE_FOUND 0x00045053 282707
		/// <para>A grammar-ending parse has been found that does not use all available words.</para>
		/// </summary>
		SP_PARTIAL_PARSE_FOUND = unchecked((int)(0x00045000 | 0x053)),

		/// <summary>
		/// SP_RECOGNIZER_INACTIVE 0x0004504e 282702
		/// <para>Operation could not be completed because the recognizer is inactive. It is inactive either</para>
		/// <para>because the recognition state is currently inactive or because no rules are active .</para>
		/// </summary>
		SP_RECOGNIZER_INACTIVE = unchecked((int)(0x00045000 | 0x04e)),

		/// <summary>
		/// SP_REQUEST_PENDING 0x00045026 282662
		/// <para>This success code indicates that an SR method called with the SPRIF_ASYNC flag is</para>
		/// <para>being processed. When it has finished processing, an SPFEI_ASYNC_COMPLETED event will be generated.</para>
		/// </summary>
		SP_REQUEST_PENDING = unchecked((int)(0x00045000 | 0x026)),

		/// <summary>
		/// SP_STREAM_UNINITIALIZED 0x00045057 282711
		/// <para>An attempt to activate a rule/dictation/etc without calling SetInput</para>
		/// <para>first in the inproc case.</para>
		/// </summary>
		SP_STREAM_UNINITIALIZED = unchecked((int)(0x00045000 | 0x057)),

		/// <summary>
		/// SP_UNSUPPORTED_ON_STREAM_INPUT 0x00045034 282676
		/// <para>The operation is not supported for stream input.</para>
		/// </summary>
		SP_UNSUPPORTED_ON_STREAM_INPUT = unchecked((int)(0x00045000 | 0x034)),

		/// <summary>
		/// SP_WORD_EXISTS_WITHOUT_PRONUNCIATION 0x00045037 282679
		/// <para>The word exists but without pronunciation.</para>
		/// </summary>
		SP_WORD_EXISTS_WITHOUT_PRONUNCIATION = unchecked((int)(0x00045000 | 0x037)),

		/// <summary>
		/// SPERR_ALL_WORDS_OPTIONAL 0x80045027 -2147200985
		/// <para>A grammar rule was defined with a null path through the rule. That is, it is possible</para>
		/// <para>to satisfy the rule conditions with no words.</para>
		/// </summary>
		SPERR_ALL_WORDS_OPTIONAL = unchecked((int)(0x80045000 | 0x027)),

		/// <summary>
		/// SPERR_ALREADY_DELETED 0x80045064 -2147200924
		/// <para>The object is a stale reference and is invalid to use.</para>
		/// <para>For example having a ISpeechGrammarRule object reference and then calling</para>
		/// <para>ISpeechRecoGrammar::Reset() will cause the rule object to be invalidated.</para>
		/// <para>Calling any methods after this will result in this error.</para>
		/// </summary>
		SPERR_ALREADY_DELETED = unchecked((int)(0x80045000 | 0x064)),

		/// <summary>
		/// SPERR_ALREADY_INITIALIZED 0x80045002 -2147201022
		/// <para>The object has already been initialized.</para>
		/// </summary>
		SPERR_ALREADY_INITIALIZED = unchecked((int)(0x80045000 | 0x002)),

		/// <summary>
		/// SPERR_ALTERNATES_WOULD_BE_INCONSISTENT 0x8004505e -2147200930
		/// <para>An attempt to call ScaleAudio on a recognition result having previously</para>
		/// <para>called GetAlternates. Allowing the call to succeed would result in</para>
		/// <para>the previously created alternates located in incorrect audio stream positions.</para>
		/// </summary>
		SPERR_ALTERNATES_WOULD_BE_INCONSISTENT = unchecked((int)(0x80045000 | 0x05e)),

		/// <summary>
		/// SPERR_AMBIGUOUS_PROPERTY 0x8004503f -2147200961
		/// <para>Cannot add ambiguous property.</para>
		/// </summary>
		SPERR_AMBIGUOUS_PROPERTY = unchecked((int)(0x80045000 | 0x03f)),

		/// <summary>
		/// SPERR_APPLEX_READ_ONLY 0x80045035 -2147200971
		/// <para>The operation is invalid for all but newly created application lexicons.</para>
		/// </summary>
		SPERR_APPLEX_READ_ONLY = unchecked((int)(0x80045000 | 0x035)),

		/// <summary>
		/// SPERR_AUDIO_BUFFER_OVERFLOW 0x8004502f -2147200977
		/// <para>This will only be returned on input (read) streams when the stream is paused because</para>
		/// <para>the SR driver has not retrieved data recently.</para>
		/// </summary>
		SPERR_AUDIO_BUFFER_OVERFLOW = unchecked((int)(0x80045000 | 0x02f)),

		/// <summary>
		/// SPERR_AUDIO_BUFFER_UNDERFLOW 0x8004505b -2147200933
		/// <para>This will only be returned on input (read) streams when the real time audio device</para>
		/// <para>stops returning data for a long period of time.</para>
		/// </summary>
		SPERR_AUDIO_BUFFER_UNDERFLOW = unchecked((int)(0x80045000 | 0x05b)),

		/// <summary>
		/// SPERR_AUDIO_NOT_FOUND 0x80045078 -2147200904
		/// <para>No audio device is installed.</para>
		/// </summary>
		SPERR_AUDIO_NOT_FOUND = unchecked((int)(0x80045000 | 0x078)),

		/// <summary>
		/// SPERR_AUDIO_STOPPED 0x8004500f -2147201009
		/// <para>This method is deprecated. Use SP_AUDIO_STOPPED instead.</para>
		/// </summary>
		SPERR_AUDIO_STOPPED = unchecked((int)(0x80045000 | 0x00f)),

		/// <summary>
		/// SPERR_AUDIO_STOPPED_UNEXPECTEDLY 0x8004505c -2147200932
		/// <para>An audio device stopped returning data from the Read() method even though it was in</para>
		/// <para>the run state. This error is only returned in the END_SR_STREAM event.</para>
		/// </summary>
		SPERR_AUDIO_STOPPED_UNEXPECTEDLY = unchecked((int)(0x80045000 | 0x05c)),

		/// <summary>
		/// SPERR_BUFFER_TOO_SMALL 0x8004500d -2147201011
		/// <para>The caller provided a buffer too small to return a result.</para>
		/// </summary>
		SPERR_BUFFER_TOO_SMALL = unchecked((int)(0x80045000 | 0x00d)),

		/// <summary>
		/// SPERR_CANNOT_NORMALIZE 0x8004507E -2147200898
		/// <para>The word passed to the normalize interface cannot be normalized</para>
		/// </summary>
		SPERR_CANNOT_NORMALIZE = unchecked((int)(0x80045000 | 0x07E)),

		/// <summary>
		/// SPERR_CANT_CREATE 0x80045017 -2147201001
		/// <para>Can not create a new object instance for the specified object category.</para>
		/// </summary>
		SPERR_CANT_CREATE = unchecked((int)(0x80045000 | 0x017)),

		/// <summary>
		/// SPERR_CFG_INVALID_DATA 0x80045086 -2147200890
		/// <para>The data in the CFG grammar is invalid or corrupted</para>
		/// </summary>
		SPERR_CFG_INVALID_DATA = unchecked((int)(0x80045000 | 0x086)),

		/// <summary>
		/// SPERR_CIRCULAR_REFERENCE 0x80045023 -2147200989
		/// <para>Circular reference in import rules of grammars.</para>
		/// </summary>
		SPERR_CIRCULAR_REFERENCE = unchecked((int)(0x80045000 | 0x023)),

		/// <summary>
		/// SPERR_CIRCULAR_RULE_REF 0x8004502b -2147200981
		/// <para>Rule 'A' refers to a second rule 'B' which, in turn, refers to rule 'A'.</para>
		/// </summary>
		SPERR_CIRCULAR_RULE_REF = unchecked((int)(0x80045000 | 0x02b)),

		/// <summary>
		/// SPERR_DEAD_ALTERNATE 0x80045031 -2147200975
		/// <para>This alternate is no longer a valid alternate to the result it was obtained from.</para>
		/// <para>Returned from ISpPhraseAlt methods.</para>
		/// </summary>
		SPERR_DEAD_ALTERNATE = unchecked((int)(0x80045000 | 0x031)),

		/// <summary>
		/// SPERR_DEVICE_BUSY 0x80045006 -2147201018
		/// <para>The wave device is busy.</para>
		/// </summary>
		SPERR_DEVICE_BUSY = unchecked((int)(0x80045000 | 0x006)),

		/// <summary>
		/// SPERR_DEVICE_NOT_ENABLED 0x80045008 -2147201016
		/// <para>The wave device is not enabled.</para>
		/// </summary>
		SPERR_DEVICE_NOT_ENABLED = unchecked((int)(0x80045000 | 0x008)),

		/// <summary>
		/// SPERR_DEVICE_NOT_SUPPORTED 0x80045007 -2147201017
		/// <para>The wave device is not supported.</para>
		/// </summary>
		SPERR_DEVICE_NOT_SUPPORTED = unchecked((int)(0x80045000 | 0x007)),

		/// <summary>
		/// SPERR_DUPLICATE_RESOURCE_NAME 0x80045021 -2147200991
		/// <para>A resource name was duplicated for a given rule.</para>
		/// </summary>
		SPERR_DUPLICATE_RESOURCE_NAME = unchecked((int)(0x80045000 | 0x021)),

		/// <summary>
		/// SPERR_DUPLICATE_RULE_NAME 0x80045020 -2147200992
		/// <para>A rule name was duplicated.</para>
		/// </summary>
		SPERR_DUPLICATE_RULE_NAME = unchecked((int)(0x80045000 | 0x020)),

		/// <summary>
		/// SPERR_EMPTY_RULE 0x8004501d -2147200995
		/// <para>A non-dynamic grammar rule that has no body.</para>
		/// </summary>
		SPERR_EMPTY_RULE = unchecked((int)(0x80045000 | 0x01d)),

		/// <summary>
		/// SPERR_ENGINE_BUSY 0x80045014 -2147201004
		/// <para>In speech recognition, the current method can not be performed while</para>
		/// <para>a grammar rule is active.</para>
		/// </summary>
		SPERR_ENGINE_BUSY = unchecked((int)(0x80045000 | 0x014)),

		/// <summary>
		/// SPERR_ENGINE_RESPONSE_INVALID 0x8004504b -2147200949
		/// <para>Arguments or data supplied by the engine are in an invalid format or are inconsistent.</para>
		/// </summary>
		SPERR_ENGINE_RESPONSE_INVALID = unchecked((int)(0x80045000 | 0x04b)),

		/// <summary>
		/// SPERR_EXPORT_DYNAMIC_RULE 0x80045047 -2147200953
		/// <para>Exported rules cannot refer directly or indirectly to a dynamic rule.</para>
		/// </summary>
		SPERR_EXPORT_DYNAMIC_RULE = unchecked((int)(0x80045000 | 0x047)),

		/// <summary>
		/// SPERR_FAILED_TO_DELETE_FILE 0x80045075 -2147200907
		/// <para>Tried and failed to delete an existing file.</para>
		/// </summary>
		SPERR_FAILED_TO_DELETE_FILE = unchecked((int)(0x80045000 | 0x075)),

		/// <summary>
		/// SPERR_FILEMUSTBEUNICODE 0x8004500a -2147201014
		/// <para>The file must be Unicode.</para>
		/// </summary>
		SPERR_FILE_MUST_BE_UNICODE = unchecked((int)(0x80045000 | 0x00a)),

		/// <summary>
		/// SPERR_FORMAT_NOT_SPECIFIED 0x8004500e -2147201010
		/// <para>Caller did not specify a format prior to opening a stream.</para>
		/// </summary>
		SPERR_FORMAT_NOT_SPECIFIED = unchecked((int)(0x80045000 | 0x00e)),

		/// <summary>
		/// SPERR_GENERIC_MMSYS_ERROR 0x8004503c -2147200964
		/// <para>A generic MMSYS error not caught by _MMRESULT_TO_HRESULT.</para>
		/// </summary>
		SPERR_GENERIC_MMSYS_ERROR = unchecked((int)(0x80045000 | 0x03c)),

		/// <summary>
		/// SPERR_GRAMMAR_COMPILER_INTERNAL_ERROR 0x8004501e -2147200994
		/// <para>The grammar compiler failed due to an internal state error.</para>
		/// </summary>
		SPERR_GRAMMAR_COMPILER_INTERNAL_ERROR = unchecked((int)(0x80045000 | 0x01e)),

		/// <summary>
		/// SPERR_HIGH_LOW_CONFIDENCE 0x80045032 -2147200974
		/// <para>The result does not contain any audio, nor does the portion of the element chain of the result</para>
		/// <para>contain any audio. Returned from ISpResult::GetAudio and ISpResult::SpeakAudio.</para>
		/// </summary>
		SPERR_HIGH_LOW_CONFIDENCE = unchecked((int)(0x80045000 | 0x032)),

		/// <summary>
		/// SPERR_INSTANCE_CHANGE_INVALID 0x80045028 -2147200984
		/// <para>It is not possible to change the current engine or input. This occurs in the</para>
		/// <para>following cases:</para>
		/// <para>1) SelectEngine called while a recognition context exists, or</para>
		/// <para>2) SetInput called in the shared instance case.</para>
		/// </summary>
		SPERR_INSTANCE_CHANGE_INVALID = unchecked((int)(0x80045000 | 0x028)),

		/// <summary>
		/// SPERR_INVALID_AUDIO_STATE 0x8004503b -2147200965
		/// <para>Audio state passed to SetState() is invalid.</para>
		/// </summary>
		SPERR_INVALID_AUDIO_STATE = unchecked((int)(0x80045000 | 0x03b)),

		/// <summary>
		/// SPERR_INVALID_FLAGS 0x80045004 -2147201020
		/// <para>The caller has specified invalid flags for this operation.</para>
		/// </summary>
		SPERR_INVALID_FLAGS = unchecked((int)(0x80045000 | 0x004)),

		/// <summary>
		/// SPERR_INVALID_FORMAT_STRING 0x80045033 -2147200973
		/// <para>The XML format string for this RULEREF is invalid, e.g. not a GUID or REFCLSID.</para>
		/// </summary>
		SPERR_INVALID_FORMAT_STRING = unchecked((int)(0x80045000 | 0x033)),

		/// <summary>
		/// SPERR_NO_PARSE_FOUND 0x8004502d -2147200979
		/// <para>Parse path cannot be parsed given the currently active rules.</para>
		/// </summary>
		SPERR_INVALID_HANDLE = unchecked((int)(0x80045000 | 0x02d)),

		/// <summary>
		/// SPERR_INVALID_IMPORT 0x80045024 -2147200988
		/// <para>A rule reference to an imported grammar that could not be resolved.</para>
		/// </summary>
		SPERR_INVALID_IMPORT = unchecked((int)(0x80045000 | 0x024)),

		/// <summary>
		/// SPERR_INVALID_PHRASE_ID 0x8004500c -2147201012
		/// <para>The phrase ID specified does not exist or is out of range.</para>
		/// </summary>
		SPERR_INVALID_PHRASE_ID = unchecked((int)(0x80045000 | 0x00c)),

		/// <summary>
		/// SPERR_INVALID_REGISTRY_KEY 0x80045040 -2147200960
		/// <para>The key specified is invalid.</para>
		/// </summary>
		SPERR_INVALID_REGISTRY_KEY = unchecked((int)(0x80045000 | 0x040)),

		/// <summary>
		/// SPERR_INVALID_TOKEN_ID 0x80045041 -2147200959
		/// <para>The token specified is invalid.</para>
		/// </summary>
		SPERR_INVALID_TOKEN_ID = unchecked((int)(0x80045000 | 0x041)),

		/// <summary>
		/// SPERR_INVALID_WAV_FILE 0x80045025 -2147200987
		/// <para>The format of the WAV file is not supported.</para>
		/// </summary>
		SPERR_INVALID_WAV_FILE = unchecked((int)(0x80045000 | 0x025)),

		/// <summary>
		/// SPERR_LANGID_MISMATCH 0x80045052 -2147200942
		/// <para>An attempt to load a CFG grammar with a LANGID different than other loaded grammars.</para>
		/// </summary>
		SPERR_LANGID_MISMATCH = unchecked((int)(0x80045000 | 0x052)),

		/// <summary>
		/// SPERR_LEX_INVALID_DATA 0x80045085 -2147200891
		/// <para>The lexicon data is invalid or corrupted.</para>
		/// </summary>
		SPERR_LEX_INVALID_DATA = unchecked((int)(0x80045000 | 0x085)),

		/// <summary>
		/// SPERR_LEX_REQUIRES_COOKIE 0x80045056 -2147200938
		/// <para>An attempt to ask a container lexicon for all words at once.</para>
		/// </summary>
		SPERR_LEX_REQUIRES_COOKIE = unchecked((int)(0x80045000 | 0x056)),

		/// <summary>
		/// SPERR_LEX_UNEXPECTED_FORMAT 0x80045087 -2147200889
		/// <para>The lexicon is not in the expected format.</para>
		/// </summary>
		SPERR_LEX_UNEXPECTED_FORMAT = unchecked((int)(0x80045000 | 0x087)),

		/// <summary>
		/// SPERR_LEX_VERY_OUT_OF_SYNC 0x8004501b -2147200997
		/// <para>The client is excessively out of sync with the lexicon. Mismatches may not be incrementally sync'd.</para>
		/// </summary>
		SPERR_LEX_VERY_OUT_OF_SYNC = unchecked((int)(0x80045000 | 0x01b)),

		/// <summary>
		/// SPERR_MARSHALER_EXCEPTION 0x8004503d -2147200963
		/// <para>An exception was raised during a call to the marshaling code.</para>
		/// </summary>
		SPERR_MARSHALER_EXCEPTION = unchecked((int)(0x80045000 | 0x03d)),

		/// <summary>
		/// SPERR_MULTI_LINGUAL_NOT_SUPPORTED 0x80045046 -2147200954
		/// <para>The selected voice was registered as multi-lingual. SAPI does not support multi-lingual registration.</para>
		/// </summary>
		SPERR_MULTI_LINGUAL_NOT_SUPPORTED = unchecked((int)(0x80045000 | 0x046)),

		/// <summary>
		/// SPERR_NO_AUDIO_DATA 0x80045030 -2147200976
		/// <para>The result does not contain any audio, nor does the portion of the element chain of the result</para>
		/// <para>contain any audio.</para>
		/// </summary>
		SPERR_NO_AUDIO_DATA = unchecked((int)(0x80045000 | 0x030)),

		/// <summary>
		/// SPERR_NO_DRIVER 0x80045009 -2147201015
		/// <para>There is no wave driver installed.</para>
		/// </summary>
		SPERR_NO_DRIVER = unchecked((int)(0x80045000 | 0x009)),

		/// <summary>
		/// SPERR_NO_MORE_ITEMS 0x80045039 -2147200967
		/// <para>When enumerating items, the requested index is greater than the count of items.</para>
		/// </summary>
		SPERR_NO_MORE_ITEMS = unchecked((int)(0x80045000 | 0x039)),

		/// <summary>
		/// SPERR_NO_RULES 0x8004502a -2147200982
		/// <para>A grammar contains no top-level, dynamic, or exported rules. There is no possible</para>
		/// <para>way to activate or otherwise use any rule in this grammar.</para>
		/// </summary>
		SPERR_NO_RULES = unchecked((int)(0x80045000 | 0x02a)),

		/// <summary>SPERR_NO_TERMINATING_RULE_PATH 0x80045036 -2147200970</summary>
		SPERR_NO_TERMINATING_RULE_PATH = unchecked((int)(0x80045000 | 0x036)),

		/// <summary>
		/// SPERR_NO_VOWEL 0x80045079 -2147200903
		/// <para>No Vowel in a word</para>
		/// </summary>
		SPERR_NO_VOWEL = unchecked((int)(0x80045000 | 0x079)),

		/// <summary>
		/// SPERR_NO_WORD_PRONUNCIATION 0x8004505d -2147200931
		/// <para>The SR engine is unable to add this word to a grammar. The application may need to supply</para>
		/// <para>an explicit pronunciation for this word.</para>
		/// </summary>
		SPERR_NO_WORD_PRONUNCIATION = unchecked((int)(0x80045000 | 0x05d)),

		/// <summary>
		/// SPERR_NON_WORD_TRANSITION 0x80045090 -2147200880
		/// <para>One of the parse transitions is not a word transition.</para>
		/// </summary>
		SPERR_NON_WORD_TRANSITION = unchecked((int)(0x80045000 | 0x090)),

		/// <summary>
		/// SPERR_NOT_ACTIVE_SESSION 0x80045063 -2147200925
		/// <para>Neither audio output and input is supported for non-active console sessions.</para>
		/// </summary>
		SPERR_NOT_ACTIVE_SESSION = unchecked((int)(0x80045000 | 0x063)),

		/// <summary>
		/// SPERR_NOT_DYNAMIC_GRAMMAR 0x8004503e -2147200962
		/// <para>Attempt was made to manipulate a non-dynamic grammar.</para>
		/// </summary>
		SPERR_NOT_DYNAMIC_GRAMMAR = unchecked((int)(0x80045000 | 0x03e)),

		// --- The following error codes are taken directly from WIN32 ---
		/// <summary>
		/// SPERR_NOT_FOUND 0x8004503a -2147200966
		/// <para>The requested data item (data key, value, etc.) was not found.</para>
		/// </summary>
		SPERR_NOT_FOUND = unchecked((int)(0x80045000 | 0x03a)),

		/// <summary>
		/// SPERR_NOT_IN_LEX 0x80045019 -2147200999
		/// <para>The word does not exist in the lexicon.</para>
		/// </summary>
		SPERR_NOT_IN_LEX = unchecked((int)(0x80045000 | 0x019)),

		/// <summary>
		/// SPERR_NOT_PROMPT_VOICE 0x80045068 -2147200920
		/// <para>The current voice is not a prompt voice, so the ISpPromptVoice</para>
		/// <para>functions don't work.</para>
		/// </summary>
		SPERR_NOT_PROMPT_VOICE = unchecked((int)(0x80045000 | 0x068)),

		/// <summary>
		/// SPERR_NOT_SUPPORTED_FOR_INPROC_RECOGNIZER 0x80045083 -2147200893
		/// <para>The method called is not supported for the in-process recognizer.</para>
		/// <para>For example: SetTextFeedback</para>
		/// </summary>
		SPERR_NOT_SUPPORTED_FOR_INPROC_RECOGNIZER = unchecked((int)(0x80045000 | 0x083)),

		/// <summary>
		/// SPERR_NOT_SUPPORTED_FOR_SHARED_RECOGNIZER 0x8004505f -2147200929
		/// <para>The method called is not supported for the shared recognizer.</para>
		/// <para>For example, ISpRecognizer::GetInputStream().</para>
		/// </summary>
		SPERR_NOT_SUPPORTED_FOR_SHARED_RECOGNIZER = unchecked((int)(0x80045000 | 0x05f)),

		/// <summary>
		/// SPERR_NOT_TOPLEVEL_RULE 0x80045054 -2147200940
		/// <para>An attempt to deactivate or activate a non-toplevel rule.</para>
		/// </summary>
		SPERR_NOT_TOPLEVEL_RULE = unchecked((int)(0x80045000 | 0x054)),

		/// <summary>
		/// SPERR_OVERLOAD 0x80045084 -2147200892
		/// <para>The operation cannot be carried out due to overload and should be attempted again.</para>
		/// </summary>
		SPERR_OVERLOAD = unchecked((int)(0x80045000 | 0x084)),

		/// <summary>
		/// SPERR_PHONEME_CONVERSION 0x80045082 -2147200894
		/// <para>Cannot convert the phonemes to the specified phonetic alphabet.</para>
		/// </summary>
		SPERR_PHONEME_CONVERSION = unchecked((int)(0x80045000 | 0x082)),

		/// <summary>
		/// SPERR_RECOGNIZER_NOT_FOUND 0x80045077 -2147200905
		/// <para>No recognizer is installed.</para>
		/// </summary>
		SPERR_RECOGNIZER_NOT_FOUND = unchecked((int)(0x80045000 | 0x077)),

		/// <summary>
		/// SPERR_RECOXML_GENERATION_FAIL 0x80045066 -2147200922
		/// <para>The Recognition Parse Tree couldn't be genrated.</para>
		/// <para>For example, that the rule name begins with a digit.</para>
		/// <para>XML parser doesn't allow element name beginning with a digit.</para>
		/// </summary>
		SPERR_RECOXML_GENERATION_FAIL = unchecked((int)(0x80045000 | 0x066)),

		/// <summary>
		/// SPERR_REENTER_SYNCHRONIZE 0x80045061 -2147200927
		/// <para>A SR engine called synchronize while inside of a synchronize call.</para>
		/// </summary>
		SPERR_REENTER_SYNCHRONIZE = unchecked((int)(0x80045000 | 0x061)),

		/// <summary>
		/// SPERR_REMOTE_CALL_ON_WRONG_THREAD 0x8004504f -2147200945
		/// <para>When making a remote call to the server, the call was made on the wrong thread.</para>
		/// </summary>
		SPERR_REMOTE_CALL_ON_WRONG_THREAD = unchecked((int)(0x80045000 | 0x04f)),

		/// <summary>
		/// SPERR_REMOTE_CALL_TIMED_OUT 0x8004502e -2147200978
		/// <para>A marshaled remote call failed to respond.</para>
		/// </summary>
		SPERR_REMOTE_CALL_TIMED_OUT = unchecked((int)(0x80045000 | 0x02e)),

		/// <summary>
		/// SPERR_REMOTE_CALL_TIMED_OUT_CONNECT 0x80045072 -2147200910
		/// <para>A timeout occurred obtaining the lock for starting or connecting to sapi server</para>
		/// </summary>
		SPERR_REMOTE_CALL_TIMED_OUT_CONNECT = unchecked((int)(0x80045000 | 0x072)),

		/// <summary>
		/// SPERR_REMOTE_CALL_TIMED_OUT_START 0x80045071 -2147200911
		/// <para>A time out occurred starting the sapi server</para>
		/// </summary>
		SPERR_REMOTE_CALL_TIMED_OUT_START = unchecked((int)(0x80045000 | 0x071)),

		/// <summary>
		/// SPERR_REMOTE_PROCESS_ALREADY_RUNNING 0x80045051 -2147200943
		/// <para>The remote process is already running; it cannot be started a second time.</para>
		/// </summary>
		SPERR_REMOTE_PROCESS_ALREADY_RUNNING = unchecked((int)(0x80045000 | 0x051)),

		/// <summary>
		/// SPERR_REMOTE_PROCESS_TERMINATED 0x80045050 -2147200944
		/// <para>The remote process terminated unexpectedly.</para>
		/// </summary>
		SPERR_REMOTE_PROCESS_TERMINATED = unchecked((int)(0x80045000 | 0x050)),

		/// <summary>
		/// SPERR_ROOTRULE_ALREADY_DEFINED 0x80045069 -2147200919
		/// <para>There is already a root rule for this grammar</para>
		/// <para>Defining another root rule will fail.</para>
		/// </summary>
		SPERR_ROOTRULE_ALREADY_DEFINED = unchecked((int)(0x80045000 | 0x069)),

		/// <summary>
		/// SPERR_RULE_NAME_ID_CONFLICT 0x80045029 -2147200983
		/// <para>A rule exists with matching IDs (names) but different names (IDs).</para>
		/// </summary>
		SPERR_RULE_NAME_ID_CONFLICT = unchecked((int)(0x80045000 | 0x029)),

		/// <summary>
		/// SPERR_RULE_NOT_DYNAMIC 0x8004501f -2147200993
		/// <para>An attempt was made to modify a non-dynamic rule.</para>
		/// </summary>
		SPERR_RULE_NOT_DYNAMIC = unchecked((int)(0x80045000 | 0x01f)),

		/// <summary>
		/// SPERR_RULE_NOT_FOUND 0x80045011 -2147201007
		/// <para>Invalid rule name passed to ActivateGrammar.</para>
		/// </summary>
		SPERR_RULE_NOT_FOUND = unchecked((int)(0x80045000 | 0x011)),

		/// <summary>
		/// SPERR_SCRIPT_DISALLOWED 0x80045070 -2147200912
		/// <para>Support for embedded script not supported because browser security settings have disabled it</para>
		/// </summary>
		SPERR_SCRIPT_DISALLOWED = unchecked((int)(0x80045000 | 0x070)),

		/// <summary>
		/// SPERR_SECMGR_CHANGE_NOT_ALLOWED 0x80045073 -2147200909
		/// <para>When there is a cfg grammar loaded, we don't allow changing the security manager</para>
		/// </summary>
		SPERR_SECMGR_CHANGE_NOT_ALLOWED = unchecked((int)(0x80045000 | 0x073)),

		/// <summary>
		/// SPERR_SHARED_ENGINE_DISABLED 0x80045076 -2147200906
		/// <para>The user has chosen to disable speech from running on the machine, or the</para>
		/// <para>system is not set up to run speech {e.g. initial setup and tutorial has not been run}.</para>
		/// </summary>
		SPERR_SHARED_ENGINE_DISABLED = unchecked((int)(0x80045000 | 0x076)),

		/// <summary>
		/// SPERR_SISR_ATTRIBUTES_NOT_ALLOWED 0x80045091 -2147200879
		/// <para>Attributes are not allowed at the top level.</para>
		/// </summary>
		SPERR_SISR_ATTRIBUTES_NOT_ALLOWED = unchecked((int)(0x80045000 | 0x091)),

		/// <summary>
		/// SPERR_SISR_MIXED_NOT_ALLOWED 0x80045092 -2147200878
		/// <para>Mixed content is not allowed at the top level.</para>
		/// </summary>
		SPERR_SISR_MIXED_NOT_ALLOWED = unchecked((int)(0x80045000 | 0x092)),

		/// <summary>
		/// SPERR_SML_GENERATION_FAIL 0x80045067 -2147200921
		/// <para>The SML couldn't be genrated.</para>
		/// <para>For example, the transformation xslt template is not well formed.</para>
		/// </summary>
		SPERR_SML_GENERATION_FAIL = unchecked((int)(0x80045000 | 0x067)),

		/// <summary>
		/// SPERR_SR_ENGINE_EXCEPTION 0x8004504c -2147200948
		/// <para>An exception was raised during a call to the current SR engine.</para>
		/// </summary>
		SPERR_SR_ENGINE_EXCEPTION = unchecked((int)(0x80045000 | 0x04c)),

		/// <summary>
		/// SPERR_STATE_WITH_NO_ARCS 0x80045062 -2147200926
		/// <para>The grammar contains a node no arcs.</para>
		/// </summary>
		SPERR_STATE_WITH_NO_ARCS = unchecked((int)(0x80045000 | 0x062)),

		/// <summary>
		/// SPERR_STGF_ERROR 0x80045048 -2147200952
		/// <para>Error parsing the SAPI Text Grammar Format (XML grammar).</para>
		/// </summary>
		SPERR_STGF_ERROR = unchecked((int)(0x80045000 | 0x048)),

		/// <summary>
		/// SPERR_STREAM_CLOSED 0x80045038 -2147200968
		/// <para>An operation was attempted on a stream object that has been closed.</para>
		/// </summary>
		SPERR_STREAM_CLOSED = unchecked((int)(0x80045000 | 0x038)),

		/// <summary>
		/// SPERR_STREAM_NOT_ACTIVE 0x8004504a -2147200950
		/// <para>Methods associated with active audio stream cannot be called unless stream is active.</para>
		/// </summary>
		SPERR_STREAM_NOT_ACTIVE = unchecked((int)(0x80045000 | 0x04a)),

		/// <summary>
		/// SPERR_STREAM_POS_INVALID 0x8004504d -2147200947
		/// <para>Stream position information supplied from engine is inconsistent.</para>
		/// </summary>
		SPERR_STREAM_POS_INVALID = unchecked((int)(0x80045000 | 0x04d)),

		/// <summary>
		/// SPERR_STRING_EMPTY 0x80045089 -2147200887
		/// <para>The string cannot be empty.</para>
		/// </summary>
		SPERR_STRING_EMPTY = unchecked((int)(0x80045000 | 0x089)),

		/// <summary>
		/// SPERR_STRING_TOO_LONG 0x80045088 -2147200888
		/// <para>The string is too long.</para>
		/// </summary>
		SPERR_STRING_TOO_LONG = unchecked((int)(0x80045000 | 0x088)),

		/// <summary>
		/// SPERR_TIMEOUT 0x80045060 -2147200928
		/// <para>A task could not complete because the SR engine had timed out.</para>
		/// </summary>
		SPERR_TIMEOUT = unchecked((int)(0x80045000 | 0x060)),

		/// <summary>
		/// SPERR_TOKEN_DELETED 0x80045045 -2147200955
		/// <para>Attempted to perform an action on an object token that has had associated registry key deleted.</para>
		/// </summary>
		SPERR_TOKEN_DELETED = unchecked((int)(0x80045000 | 0x045)),

		/// <summary>
		/// SPERR_TOKEN_IN_USE 0x80045044 -2147200956
		/// <para>Attempted to remove registry data from a token that is already in use elsewhere.</para>
		/// </summary>
		SPERR_TOKEN_IN_USE = unchecked((int)(0x80045000 | 0x044)),

		/// <summary>
		/// SPERR_TOO_MANY_GRAMMARS 0x80045022 -2147200990
		/// <para>Too many grammars have been loaded.</para>
		/// </summary>
		SPERR_TOO_MANY_GRAMMARS = unchecked((int)(0x80045000 | 0x022)),

		/// <summary>
		/// SPERR_TOPIC_NOT_ADAPTABLE 0x80045081 -2147200895
		/// <para>This topic is not adaptable</para>
		/// </summary>
		SPERR_TOPIC_NOT_ADAPTABLE = unchecked((int)(0x80045000 | 0x081)),

		/// <summary>
		/// SPERR_TTS_ENGINE_EXCEPTION 0x80045012 -2147201006
		/// <para>An exception was raised during a call to the current TTS driver.</para>
		/// </summary>
		SPERR_TTS_ENGINE_EXCEPTION = unchecked((int)(0x80045000 | 0x012)),

		/// <summary>
		/// SPERR_TTS_NLP_EXCEPTION 0x80045013 -2147201005
		/// <para>An exception was raised during a call to an application sentence filter.</para>
		/// </summary>
		SPERR_TTS_NLP_EXCEPTION = unchecked((int)(0x80045000 | 0x013)),

		/// <summary>
		/// SPERR_UNDEFINED_FORWARD_RULE_REF 0x8004501c -2147200996
		/// <para>A rule reference in a grammar was made to a named rule that was never defined.</para>
		/// </summary>
		SPERR_UNDEFINED_FORWARD_RULE_REF = unchecked((int)(0x80045000 | 0x01c)),

		/// <summary>
		/// SPERR_UNINITIALIZED 0x80045001 -2147201023
		/// <para>The object has not been properly initialized.</para>
		/// </summary>
		SPERR_UNINITIALIZED = unchecked((int)(0x80045000 | 0x001)),

		/// <summary>
		/// SPERR_UNSUPPORTED_FORMAT 0x80045003 -2147201021
		/// <para>The caller has specified an unsupported format.</para>
		/// </summary>
		SPERR_UNSUPPORTED_FORMAT = unchecked((int)(0x80045000 | 0x003)),

		/// <summary>
		/// SPERR_UNSUPPORTED_LANG 0x80045059 -2147200935
		/// <para>The requested language is not supported.</para>
		/// </summary>
		SPERR_UNSUPPORTED_LANG = unchecked((int)(0x80045000 | 0x059)),

		/// <summary>
		/// SPERR_UNSUPPORTED_PHONEME 0x8004507A -2147200902
		/// <para>Unknown phoneme</para>
		/// </summary>
		SPERR_UNSUPPORTED_PHONEME = unchecked((int)(0x80045000 | 0x07A)),

		/// <summary>
		/// SPERR_VOICE_NOT_FOUND 0x80045093 -2147200877
		/// <para>NO given voice is found</para>
		/// </summary>
		SPERR_VOICE_NOT_FOUND = unchecked((int)(0x80045000 | 0x093)),

		// Error x058 is not used in SAPI 5.0
		/// <summary>
		/// SPERR_VOICE_PAUSED 0x8004505a -2147200934
		/// <para>The operation cannot be performed because the voice is currently paused.</para>
		/// </summary>
		SPERR_VOICE_PAUSED = unchecked((int)(0x80045000 | 0x05a)),

		/// <summary>
		/// SPERR_WORD_NEEDS_NORMALIZATION 0x8004507D -2147200899
		/// <para>The word passed to the GetPronunciations interface needs normalizing first</para>
		/// </summary>
		SPERR_WORD_NEEDS_NORMALIZATION = unchecked((int)(0x80045000 | 0x07D)),

		/// <summary>
		/// SPERR_WORDFORMAT_ERROR 0x80045049 -2147200951
		/// <para>Incorrect word format, probably due to incorrect pronunciation string.</para>
		/// </summary>
		SPERR_WORDFORMAT_ERROR = unchecked((int)(0x80045000 | 0x049)),

		/// <summary>
		/// SPERR_XML_BAD_SYNTAX 0x80045042 -2147200958
		/// <para>The xml parser failed due to bad syntax.</para>
		/// </summary>
		SPERR_XML_BAD_SYNTAX = unchecked((int)(0x80045000 | 0x042)),

		/// <summary>
		/// SPERR_XML_RESOURCE_NOT_FOUND 0x80045043 -2147200957
		/// <para>The xml parser failed to load a required resource (e.g., voice, phoneconverter, etc.).</para>
		/// </summary>
		SPERR_XML_RESOURCE_NOT_FOUND = unchecked((int)(0x80045000 | 0x043)),
	}
}
