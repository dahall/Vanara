#pragma warning disable CS0649
using System.Collections;
using System.Collections.Generic;
using Vanara.Marshaler;

namespace Vanara.PInvoke;

public static partial class SpeechApi
{
	public const float DEFAULT_WEIGHT = 1f;
	public const uint SP_GETWHOLEPHRASE = unchecked((uint)-1);
	public const int SP_MAX_PRON_LENGTH = 384;
	public const int SP_MAX_WORD_LENGTH = 128;
	public const string SPALTERNATESCLSID = "AlternatesCLSID";
	public const string SPCAT_APPLEXICONS = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\AppLexicons";
	public const string SPCAT_AUDIOIN = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\AudioInput";
	public const string SPCAT_AUDIOOUT = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\AudioOutput";
	public const string SPCAT_PHONECONVERTERS = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\PhoneConverters";
	public const string SPCAT_RECOGNIZERS = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\Recognizers";
	public const string SPCAT_RECOPROFILES = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Speech\\RecoProfiles";
	public const string SPCAT_TEXTNORMALIZERS = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\TextNormalizers";
	public const string SPCAT_VOICES = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\Voices";
	public const string SPCURRENT_USER_LEXICON_TOKEN_ID = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Speech\\CurrentUserLexicon";
	public const string SPCURRENT_USER_SHORTCUT_TOKEN_ID = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Speech\\CurrentUserShortcut";
	public const string SPDICTATION = "*";
	public const float Speech_Default_Weight = DEFAULT_WEIGHT;
	public const int Speech_Max_Pron_Length = SP_MAX_PRON_LENGTH;
	public const int Speech_Max_Word_Length = SP_MAX_WORD_LENGTH;
	public const int Speech_StreamPos_Asap = 0;
	public const int Speech_StreamPos_RealTime = -1;
	public const string SpeechAddRemoveWord = "AddRemoveWord";
	public const int SpeechAllElements = -1;
	public const string SpeechAudioFormatGUIDText = "{7CEEF9F9-3D13-11d2-9EE7-00C04F797396}";
	public const string SpeechAudioFormatGUIDWave = "{C31ADBAE-527F-4ff5-A230-F62BB61FF70C}";
	public const string SpeechAudioProperties = "AudioProperties";
	public const string SpeechAudioVolume = "AudioVolume";
	public const string SpeechCategoryAppLexicons = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\AppLexicons";
	public const string SpeechCategoryAudioIn = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\AudioInput";
	public const string SpeechCategoryAudioOut = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\AudioOutput";
	public const string SpeechCategoryPhoneConverters = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\PhoneConverters";
	public const string SpeechCategoryRecognizers = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\Recognizers";
	public const string SpeechCategoryRecoProfiles = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Speech\\RecoProfiles";
	public const string SpeechCategoryVoices = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\Voices";
	public const string SpeechDictationTopicSpelling = "Spelling";
	public const string SpeechEngineProperties = "EngineProperties";
	public const string SpeechGrammarTagDictation = "*";
	public const string SpeechGrammarTagUnlimitedDictation = "*+";
	public const string SpeechGrammarTagWildcard = "...";
	public const string SpeechMicTraining = "MicTraining";
	public const string SpeechPropertyAdaptationOn = "AdaptationOn";
	public const string SpeechPropertyComplexResponseSpeed = "ComplexResponseSpeed";
	public const string SpeechPropertyHighConfidenceThreshold = "HighConfidenceThreshold";
	public const string SpeechPropertyLowConfidenceThreshold = "LowConfidenceThreshold";
	public const string SpeechPropertyNormalConfidenceThreshold = "NormalConfidenceThreshold";
	public const string SpeechPropertyResourceUsage = "ResourceUsage";
	public const string SpeechPropertyResponseSpeed = "ResponseSpeed";
	public const string SpeechRecoProfileProperties = "RecoProfileProperties";
	public const string SpeechRegistryLocalMachineRoot = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech";
	public const string SpeechRegistryUserRoot = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Speech";
	public const string SpeechTokenIdUserLexicon = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Speech\\CurrentUserLexicon";
	public const string SpeechTokenKeyAttributes = "Attributes";
	public const string SpeechTokenKeyFiles = "Files";
	public const string SpeechTokenKeyUI = "UI";
	public const string SpeechTokenValueCLSID = "CLSID";
	public const string SpeechUserTraining = "UserTraining";
	public const string SpeechVoiceCategoryTTSRate = "DefaultTTSRate";
	public const string SpeechVoiceSkipTypeSentence = "Sentence";
	public const ulong SPFEI_FLAGCHECK = (1UL << (int)SPEVENTENUM.SPEI_RESERVED1) | (1UL << (int)SPEVENTENUM.SPEI_RESERVED2);
	public const string SPINFDICTATION = "*+";
	public const string SPMMSYS_AUDIO_IN_TOKEN_ID = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\AudioInput\\TokenEnums\\MMAudioIn\\";
	public const string SPMMSYS_AUDIO_OUT_TOKEN_ID = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\AudioOutput\\TokenEnums\\MMAudioOut\\";
	public const string SPPROP_ADAPTATION_ON = "AdaptationOn";
	public const string SPPROP_COMPLEX_RESPONSE_SPEED = "ComplexResponseSpeed";
	public const string SPPROP_HIGH_CONFIDENCE_THRESHOLD = "HighConfidenceThreshold";
	public const string SPPROP_LOW_CONFIDENCE_THRESHOLD = "LowConfidenceThreshold";
	public const string SPPROP_NORMAL_CONFIDENCE_THRESHOLD = "NormalConfidenceThreshold";
	public const string SPPROP_PERSISTED_BACKGROUND_ADAPTATION = "PersistedBackgroundAdaptation";
	public const string SPPROP_PERSISTED_LANGUAGE_MODEL_ADAPTATION = "PersistedLanguageModelAdaptation";
	public const string SPPROP_RESOURCE_USAGE = "ResourceUsage";
	public const string SPPROP_RESPONSE_SPEED = "ResponseSpeed";
	public const string SPPROP_UX_IS_LISTENING = "UXIsListening";
	public const string SPRECOEXTENSION = "RecoExtension";
	public const string SPREG_LOCAL_MACHINE_ROOT = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech";
	public const string SPREG_SAFE_USER_TOKENS = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Speech\\UserTokens";
	public const string SPREG_USER_ROOT = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Speech";
	public const uint SPRR_ALL_ELEMENTS = unchecked((uint)-1);
	public const string SPTOKENKEY_ATTRIBUTES = "Attributes";
	public const string SPTOKENKEY_AUDIO_LATENCY_TRUNCATE = "LatencyTruncateThreshold";
	public const string SPTOKENKEY_AUDIO_LATENCY_UPDATE_INTERVAL = "LatencyUpdateInterval";
	public const string SPTOKENKEY_AUDIO_LATENCY_WARNING = "LatencyWarningThreshold";
	public const string SPTOKENKEY_FILES = "Files";
	public const string SPTOKENKEY_RETAINEDAUDIO = "SecondsPerRetainedAudioEvent";
	public const string SPTOKENKEY_UI = "UI";
	public const string SPTOKENVALUE_CLSID = "CLSID";
	public const string SPTOPIC_SPELLING = "Spelling";
	public const string SPVOICECATEGORY_TTSRATE = "DefaultTTSRate";
	public const string SPWILDCARD = "...";
	public const string SR_LOCALIZED_DESCRIPTION = "Description";

	public static readonly Guid SPDFID_Text = new(0x7ceef9f9, 0x3d13, 0x11d2, 0x9e, 0xe7, 0x00, 0xc0, 0x4f, 0x79, 0x73, 0x96);
	public static readonly Guid SPDFID_WaveFormatEx = new(0xc31adbae, 0x527f, 0x4ff5, 0xa2, 0x30, 0xf6, 0x2b, 0xb6, 0x1f, 0xf7, 0x0c);
	private const string EnumVariantMarshaler = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";

	public delegate void SPNOTIFYCALLBACK(IntPtr wParam, IntPtr lParam);

	public enum DISPID_SpeechAudio
	{
		DISPID_SAStatus = 200,
		DISPID_SABufferInfo,
		DISPID_SADefaultFormat,
		DISPID_SAVolume,
		DISPID_SABufferNotifySize,
		DISPID_SAEventHandle,
		DISPID_SASetState
	}

	public enum DISPID_SpeechAudioBufferInfo
	{
		DISPID_SABIMinNotification = 1,
		DISPID_SABIBufferSize,
		DISPID_SABIEventBias
	}

	public enum DISPID_SpeechAudioFormat
	{
		DISPID_SAFType = 1,
		DISPID_SAFGuid,
		DISPID_SAFGetWaveFormatEx,
		DISPID_SAFSetWaveFormatEx
	}

	public enum DISPID_SpeechAudioStatus
	{
		DISPID_SASFreeBufferSpace = 1,
		DISPID_SASNonBlockingIO,
		DISPID_SASState,
		DISPID_SASCurrentSeekPosition,
		DISPID_SASCurrentDevicePosition
	}

	public enum DISPID_SpeechBaseStream
	{
		DISPID_SBSFormat = 1,
		DISPID_SBSRead,
		DISPID_SBSWrite,
		DISPID_SBSSeek
	}

	public enum DISPID_SpeechCustomStream
	{
		DISPID_SCSBaseStream = 100
	}

	public enum DISPID_SpeechDataKey
	{
		DISPID_SDKSetBinaryValue = 1,
		DISPID_SDKGetBinaryValue,
		DISPID_SDKSetStringValue,
		DISPID_SDKGetStringValue,
		DISPID_SDKSetLongValue,
		DISPID_SDKGetlongValue,
		DISPID_SDKOpenKey,
		DISPID_SDKCreateKey,
		DISPID_SDKDeleteKey,
		DISPID_SDKDeleteValue,
		DISPID_SDKEnumKeys,
		DISPID_SDKEnumValues
	}

	public enum DISPID_SpeechFileStream
	{
		DISPID_SFSOpen = 100,
		DISPID_SFSClose
	}

	public enum DISPID_SpeechGrammarRule
	{
		DISPID_SGRAttributes = 1,
		DISPID_SGRInitialState,
		DISPID_SGRName,
		DISPID_SGRId,
		DISPID_SGRClear,
		DISPID_SGRAddResource,
		DISPID_SGRAddState
	}

	public enum DISPID_SpeechGrammarRules
	{
		DISPID_SGRsCount = 1,
		DISPID_SGRsDynamic = 2,
		DISPID_SGRsAdd = 3,
		DISPID_SGRsCommit = 4,
		DISPID_SGRsCommitAndSave = 5,
		DISPID_SGRsFindRule = 6,
		DISPID_SGRsItem = 0,
		DISPID_SGRs_NewEnum = -4
	}

	public enum DISPID_SpeechGrammarRuleState
	{
		DISPID_SGRSRule = 1,
		DISPID_SGRSTransitions,
		DISPID_SGRSAddWordTransition,
		DISPID_SGRSAddRuleTransition,
		DISPID_SGRSAddSpecialTransition
	}

	public enum DISPID_SpeechGrammarRuleStateTransition
	{
		DISPID_SGRSTType = 1,
		DISPID_SGRSTText,
		DISPID_SGRSTRule,
		DISPID_SGRSTWeight,
		DISPID_SGRSTPropertyName,
		DISPID_SGRSTPropertyId,
		DISPID_SGRSTPropertyValue,
		DISPID_SGRSTNextState
	}

	public enum DISPID_SpeechGrammarRuleStateTransitions
	{
		DISPID_SGRSTsCount = 1,
		DISPID_SGRSTsItem = 0,
		DISPID_SGRSTs_NewEnum = -4
	}

	public enum DISPID_SpeechLexicon
	{
		DISPID_SLGenerationId = 1,
		DISPID_SLGetWords,
		DISPID_SLAddPronunciation,
		DISPID_SLAddPronunciationByPhoneIds,
		DISPID_SLRemovePronunciation,
		DISPID_SLRemovePronunciationByPhoneIds,
		DISPID_SLGetPronunciations,
		DISPID_SLGetGenerationChange
	}

	public enum DISPID_SpeechLexiconProns
	{
		DISPID_SLPsCount = 1,
		DISPID_SLPsItem = 0,
		DISPID_SLPs_NewEnum = -4
	}

	public enum DISPID_SpeechLexiconPronunciation
	{
		DISPID_SLPType = 1,
		DISPID_SLPLangId,
		DISPID_SLPPartOfSpeech,
		DISPID_SLPPhoneIds,
		DISPID_SLPSymbolic
	}

	public enum DISPID_SpeechLexiconWord
	{
		DISPID_SLWLangId = 1,
		DISPID_SLWType,
		DISPID_SLWWord,
		DISPID_SLWPronunciations
	}

	public enum DISPID_SpeechLexiconWords
	{
		DISPID_SLWsCount = 1,
		DISPID_SLWsItem = 0,
		DISPID_SLWs_NewEnum = -4
	}

	public enum DISPID_SpeechMemoryStream
	{
		DISPID_SMSSetData = 100,
		DISPID_SMSGetData
	}

	public enum DISPID_SpeechMMSysAudio
	{
		DISPID_SMSADeviceId = 300,
		DISPID_SMSALineId,
		DISPID_SMSAMMHandle
	}

	public enum DISPID_SpeechObjectToken
	{
		DISPID_SOTId = 1,
		DISPID_SOTDataKey,
		DISPID_SOTCategory,
		DISPID_SOTGetDescription,
		DISPID_SOTSetId,
		DISPID_SOTGetAttribute,
		DISPID_SOTCreateInstance,
		DISPID_SOTRemove,
		DISPID_SOTGetStorageFileName,
		DISPID_SOTRemoveStorageFileName,
		DISPID_SOTIsUISupported,
		DISPID_SOTDisplayUI,
		DISPID_SOTMatchesAttributes
	}

	public enum DISPID_SpeechObjectTokenCategory
	{
		DISPID_SOTCId = 1,
		DISPID_SOTCDefault,
		DISPID_SOTCSetId,
		DISPID_SOTCGetDataKey,
		DISPID_SOTCEnumerateTokens
	}

	public enum DISPID_SpeechObjectTokens
	{
		DISPID_SOTsCount = 1,
		DISPID_SOTsItem = 0,
		DISPID_SOTs_NewEnum = -4
	}

	public enum DISPID_SpeechPhoneConverter
	{
		DISPID_SPCLangId = 1,
		DISPID_SPCPhoneToId,
		DISPID_SPCIdToPhone
	}

	public enum DISPID_SpeechPhraseAlternate
	{
		DISPID_SPARecoResult = 1,
		DISPID_SPAStartElementInResult,
		DISPID_SPANumberOfElementsInResult,
		DISPID_SPAPhraseInfo,
		DISPID_SPACommit
	}

	public enum DISPID_SpeechPhraseAlternates
	{
		DISPID_SPAsCount = 1,
		DISPID_SPAsItem = 0,
		DISPID_SPAs_NewEnum = -4
	}

	public enum DISPID_SpeechPhraseBuilder
	{
		DISPID_SPPBRestorePhraseFromMemory = 1
	}

	public enum DISPID_SpeechPhraseElement
	{
		DISPID_SPEAudioTimeOffset = 1,
		DISPID_SPEAudioSizeTime,
		DISPID_SPEAudioStreamOffset,
		DISPID_SPEAudioSizeBytes,
		DISPID_SPERetainedStreamOffset,
		DISPID_SPERetainedSizeBytes,
		DISPID_SPEDisplayText,
		DISPID_SPELexicalForm,
		DISPID_SPEPronunciation,
		DISPID_SPEDisplayAttributes,
		DISPID_SPERequiredConfidence,
		DISPID_SPEActualConfidence,
		DISPID_SPEEngineConfidence
	}

	public enum DISPID_SpeechPhraseElements
	{
		DISPID_SPEsCount = 1,
		DISPID_SPEsItem = 0,
		DISPID_SPEs_NewEnum = -4
	}

	public enum DISPID_SpeechPhraseInfo
	{
		DISPID_SPILanguageId = 1,
		DISPID_SPIGrammarId,
		DISPID_SPIStartTime,
		DISPID_SPIAudioStreamPosition,
		DISPID_SPIAudioSizeBytes,
		DISPID_SPIRetainedSizeBytes,
		DISPID_SPIAudioSizeTime,
		DISPID_SPIRule,
		DISPID_SPIProperties,
		DISPID_SPIElements,
		DISPID_SPIReplacements,
		DISPID_SPIEngineId,
		DISPID_SPIEnginePrivateData,
		DISPID_SPISaveToMemory,
		DISPID_SPIGetText,
		DISPID_SPIGetDisplayAttributes
	}

	public enum DISPID_SpeechPhraseProperties
	{
		DISPID_SPPsCount = 1,
		DISPID_SPPsItem = 0,
		DISPID_SPPs_NewEnum = -4
	}

	public enum DISPID_SpeechPhraseProperty
	{
		DISPID_SPPName = 1,
		DISPID_SPPId,
		DISPID_SPPValue,
		DISPID_SPPFirstElement,
		DISPID_SPPNumberOfElements,
		DISPID_SPPEngineConfidence,
		DISPID_SPPConfidence,
		DISPID_SPPParent,
		DISPID_SPPChildren
	}

	public enum DISPID_SpeechPhraseReplacement
	{
		DISPID_SPRDisplayAttributes = 1,
		DISPID_SPRText,
		DISPID_SPRFirstElement,
		DISPID_SPRNumberOfElements
	}

	public enum DISPID_SpeechPhraseReplacements
	{
		DISPID_SPRsCount = 1,
		DISPID_SPRsItem = 0,
		DISPID_SPRs_NewEnum = -4
	}

	public enum DISPID_SpeechPhraseRule
	{
		DISPID_SPRuleName = 1,
		DISPID_SPRuleId,
		DISPID_SPRuleFirstElement,
		DISPID_SPRuleNumberOfElements,
		DISPID_SPRuleParent,
		DISPID_SPRuleChildren,
		DISPID_SPRuleConfidence,
		DISPID_SPRuleEngineConfidence
	}

	public enum DISPID_SpeechPhraseRules
	{
		DISPID_SPRulesCount = 1,
		DISPID_SPRulesItem = 0,
		DISPID_SPRules_NewEnum = -4
	}

	public enum DISPID_SpeechRecoContext
	{
		DISPID_SRCRecognizer = 1,
		DISPID_SRCAudioInInterferenceStatus,
		DISPID_SRCRequestedUIType,
		DISPID_SRCVoice,
		DISPID_SRAllowVoiceFormatMatchingOnNextSet,
		DISPID_SRCVoicePurgeEvent,
		DISPID_SRCEventInterests,
		DISPID_SRCCmdMaxAlternates,
		DISPID_SRCState,
		DISPID_SRCRetainedAudio,
		DISPID_SRCRetainedAudioFormat,
		DISPID_SRCPause,
		DISPID_SRCResume,
		DISPID_SRCCreateGrammar,
		DISPID_SRCCreateResultFromMemory,
		DISPID_SRCBookmark,
		DISPID_SRCSetAdaptationData
	}

	public enum DISPID_SpeechRecoContextEvents
	{
		DISPID_SRCEStartStream = 1,
		DISPID_SRCEEndStream,
		DISPID_SRCEBookmark,
		DISPID_SRCESoundStart,
		DISPID_SRCESoundEnd,
		DISPID_SRCEPhraseStart,
		DISPID_SRCERecognition,
		DISPID_SRCEHypothesis,
		DISPID_SRCEPropertyNumberChange,
		DISPID_SRCEPropertyStringChange,
		DISPID_SRCEFalseRecognition,
		DISPID_SRCEInterference,
		DISPID_SRCERequestUI,
		DISPID_SRCERecognizerStateChange,
		DISPID_SRCEAdaptation,
		DISPID_SRCERecognitionForOtherContext,
		DISPID_SRCEAudioLevel,
		DISPID_SRCEEnginePrivate
	}

	public enum DISPID_SpeechRecognizer
	{
		DISPID_SRRecognizer = 1,
		DISPID_SRAllowAudioInputFormatChangesOnNextSet,
		DISPID_SRAudioInput,
		DISPID_SRAudioInputStream,
		DISPID_SRIsShared,
		DISPID_SRState,
		DISPID_SRStatus,
		DISPID_SRProfile,
		DISPID_SREmulateRecognition,
		DISPID_SRCreateRecoContext,
		DISPID_SRGetFormat,
		DISPID_SRSetPropertyNumber,
		DISPID_SRGetPropertyNumber,
		DISPID_SRSetPropertyString,
		DISPID_SRGetPropertyString,
		DISPID_SRIsUISupported,
		DISPID_SRDisplayUI,
		DISPID_SRGetRecognizers,
		DISPID_SVGetAudioInputs,
		DISPID_SVGetProfiles
	}

	public enum DISPID_SpeechRecognizerStatus
	{
		DISPID_SRSAudioStatus = 1,
		DISPID_SRSCurrentStreamPosition,
		DISPID_SRSCurrentStreamNumber,
		DISPID_SRSNumberOfActiveRules,
		DISPID_SRSClsidEngine,
		DISPID_SRSSupportedLanguages
	}

	public enum DISPID_SpeechRecoResult
	{
		DISPID_SRRRecoContext = 1,
		DISPID_SRRTimes,
		DISPID_SRRAudioFormat,
		DISPID_SRRPhraseInfo,
		DISPID_SRRAlternates,
		DISPID_SRRAudio,
		DISPID_SRRSpeakAudio,
		DISPID_SRRSaveToMemory,
		DISPID_SRRDiscardResultInfo
	}

	public enum DISPID_SpeechRecoResult2
	{
		DISPID_SRRSetTextFeedback = 12
	}

	public enum DISPID_SpeechRecoResultTimes
	{
		DISPID_SRRTStreamTime = 1,
		DISPID_SRRTLength,
		DISPID_SRRTTickCount,
		DISPID_SRRTOffsetFromStart
	}

	public enum DISPID_SpeechVoice
	{
		DISPID_SVStatus = 1,
		DISPID_SVVoice,
		DISPID_SVAudioOutput,
		DISPID_SVAudioOutputStream,
		DISPID_SVRate,
		DISPID_SVVolume,
		DISPID_SVAllowAudioOuputFormatChangesOnNextSet,
		DISPID_SVEventInterests,
		DISPID_SVPriority,
		DISPID_SVAlertBoundary,
		DISPID_SVSyncronousSpeakTimeout,
		DISPID_SVSpeak,
		DISPID_SVSpeakStream,
		DISPID_SVPause,
		DISPID_SVResume,
		DISPID_SVSkip,
		DISPID_SVGetVoices,
		DISPID_SVGetAudioOutputs,
		DISPID_SVWaitUntilDone,
		DISPID_SVSpeakCompleteEvent,
		DISPID_SVIsUISupported,
		DISPID_SVDisplayUI
	}

	public enum DISPID_SpeechVoiceEvent
	{
		DISPID_SVEStreamStart = 1,
		DISPID_SVEStreamEnd,
		DISPID_SVEVoiceChange,
		DISPID_SVEBookmark,
		DISPID_SVEWord,
		DISPID_SVEPhoneme,
		DISPID_SVESentenceBoundary,
		DISPID_SVEViseme,
		DISPID_SVEAudioLevel,
		DISPID_SVEEnginePrivate
	}

	public enum DISPID_SpeechVoiceStatus
	{
		DISPID_SVSCurrentStreamNumber = 1,
		DISPID_SVSLastStreamNumberQueued,
		DISPID_SVSLastResult,
		DISPID_SVSRunningState,
		DISPID_SVSInputWordPosition,
		DISPID_SVSInputWordLength,
		DISPID_SVSInputSentencePosition,
		DISPID_SVSInputSentenceLength,
		DISPID_SVSLastBookmark,
		DISPID_SVSLastBookmarkId,
		DISPID_SVSPhonemeId,
		DISPID_SVSVisemeId
	}

	public enum DISPID_SpeechWaveFormatEx
	{
		DISPID_SWFEFormatTag = 1,
		DISPID_SWFEChannels,
		DISPID_SWFESamplesPerSec,
		DISPID_SWFEAvgBytesPerSec,
		DISPID_SWFEBlockAlign,
		DISPID_SWFEBitsPerSample,
		DISPID_SWFEExtraData
	}

	public enum DISPID_SpeechXMLRecoResult
	{
		DISPID_SRRGetXMLResult = 10,
		DISPID_SRRGetXMLErrorInfo
	}

	public enum DISPIDSPRG
	{
		DISPID_SRGId = 1,
		DISPID_SRGRecoContext,
		DISPID_SRGState,
		DISPID_SRGRules,
		DISPID_SRGReset,
		DISPID_SRGCommit,
		DISPID_SRGCmdLoadFromFile,
		DISPID_SRGCmdLoadFromObject,
		DISPID_SRGCmdLoadFromResource,
		DISPID_SRGCmdLoadFromMemory,
		DISPID_SRGCmdLoadFromProprietaryGrammar,
		DISPID_SRGCmdSetRuleState,
		DISPID_SRGCmdSetRuleIdState,
		DISPID_SRGDictationLoad,
		DISPID_SRGDictationUnload,
		DISPID_SRGDictationSetState,
		DISPID_SRGSetWordSequenceData,
		DISPID_SRGSetTextSelection,
		DISPID_SRGIsPronounceable
	}

	public enum DISPIDSPTSI
	{
		DISPIDSPTSI_ActiveOffset = 1,
		DISPIDSPTSI_ActiveLength,
		DISPIDSPTSI_SelectionOffset,
		DISPIDSPTSI_SelectionLength
	}

	public enum SP_CONFIDENCE : sbyte
	{
		SP_LOW_CONFIDENCE = -1,
		SP_NORMAL_CONFIDENCE = 0,
		SP_HIGH_CONFIDENCE = 1,
	}

	public enum SPADAPTATIONRELEVANCE
	{
		SPAR_Unknown,
		SPAR_Low,
		SPAR_Medium,
		SPAR_High
	}

	public enum SPAUDIOOPTIONS
	{
		SPAO_NONE,
		SPAO_RETAIN_AUDIO
	}

	public enum SPAUDIOSTATE
	{
		SPAS_CLOSED,
		SPAS_STOP,
		SPAS_PAUSE,
		SPAS_RUN
	}

	[Flags]
	public enum SPBOOKMARKOPTIONS
	{
		SPBO_NONE = 0,
		SPBO_PAUSE = 1,
		SPBO_AHEAD = 2,
		SPBO_TIME_UNITS = 4
	}

	public enum SPCATEGORYTYPE
	{
		SPCT_COMMAND,
		SPCT_DICTATION,
		SPCT_SLEEP,
		SPCT_SUB_COMMAND,
		SPCT_SUB_DICTATION
	}

	[Flags]
	public enum SPCFGRULEATTRIBUTES
	{
		SPRAF_TopLevel = 1 << 0,
		SPRAF_Active = 1 << 1,
		SPRAF_Export = 1 << 2,
		SPRAF_Import = 1 << 3,
		SPRAF_Interpreter = 1 << 4,
		SPRAF_Dynamic = 1 << 5,
		SPRAF_Root = 1 << 6,
		SPRAF_AutoPause = 1 << 16,
		SPRAF_UserDelimited = 1 << 17
	}

	[Flags]
	public enum SPCOMMITFLAGS
	{
		SPCF_NONE = 0,
		SPCF_ADD_TO_USER_LEXICON = 1 << 0,
		SPCF_DEFINITE_CORRECTION = 1 << 1
	}

	public enum SPCONTEXTSTATE
	{
		SPCS_DISABLED,
		SPCS_ENABLED
	}

	public enum SPDATAKEYLOCATION
	{
		SPDKL_DefaultLocation = 0,
		SPDKL_CurrentUser = 1,
		SPDKL_LocalMachine = 2,
		SPDKL_CurrentConfig = 5
	}

	/// <summary>
	///   <b>SPDISPLAYATTRIBUTES</b> lists the display text of <c>phrase elements</c>. Recognition results contain the recognized text in a format that can be displayed on the screen. The SPDISPLAYATTRIBUTES type is used in the bDisplayAttributes member of SPPHRASEELEMENT to indicate additional display information that the application should honor when displaying a word, such as what to do with leading or trailing spaces.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms717251(v=vs.85)
	[PInvokeData("sapi.h")]
	[Flags]
	public enum SPDISPLAYATTRIBUTES : byte
	{
		/// <summary>Inserts one trailing space, used for most words.</summary>
		SPAF_ONE_TRAILING_SPACE = 0x2,
		/// <summary>Insert two trailing spaces, often used after a sentence final period.</summary>
		SPAF_TWO_TRAILING_SPACES = 0x4,
		/// <summary>Consume leading space, often used for periods. If this is absent, the word should have a leading space by default.</summary>
		SPAF_CONSUME_LEADING_SPACES = 0x8,
		/// <summary/>
		SPAF_BUFFER_POSITION = 0x10,
		/// <summary>A combination of all of the above flags.</summary>
		SPAF_ALL = 0x1f,
		/// <summary/>
		SPAF_USER_SPECIFIED = 0x80
	}

	[Flags]
	public enum SPEAKFLAGS : uint
	{
		SPF_DEFAULT = 0,
		SPF_ASYNC = 1 << 0,
		SPF_PURGEBEFORESPEAK = 1 << 1,
		SPF_IS_FILENAME = 1 << 2,
		SPF_IS_XML = 1 << 3,
		SPF_IS_NOT_XML = 1 << 4,
		SPF_PERSIST_XML = 1 << 5,
		SPF_NLP_SPEAK_PUNC = 1 << 6,
		SPF_PARSE_SAPI = 1 << 7,
		SPF_PARSE_SSML = 1 << 8,
		SPF_PARSE_AUTODETECT = 0,
		SPF_NLP_MASK = SPF_NLP_SPEAK_PUNC,
		SPF_PARSE_MASK = SPF_PARSE_SAPI | SPF_PARSE_SSML,
		SPF_VOICE_MASK = SPF_ASYNC | SPF_PURGEBEFORESPEAK | SPF_IS_FILENAME | SPF_IS_XML | SPF_IS_NOT_XML | SPF_NLP_MASK | SPF_PERSIST_XML | SPF_PARSE_MASK,
		SPF_UNUSED_FLAGS = ~SPF_VOICE_MASK
	}

	public enum SpeechAudioFormatType
	{
		SAFTDefault = -1,
		SAFTNoAssignedFormat,
		SAFTText,
		SAFTNonStandardFormat,
		SAFTExtendedAudioFormat,
		SAFT8kHz8BitMono,
		SAFT8kHz8BitStereo,
		SAFT8kHz16BitMono,
		SAFT8kHz16BitStereo,
		SAFT11kHz8BitMono,
		SAFT11kHz8BitStereo,
		SAFT11kHz16BitMono,
		SAFT11kHz16BitStereo,
		SAFT12kHz8BitMono,
		SAFT12kHz8BitStereo,
		SAFT12kHz16BitMono,
		SAFT12kHz16BitStereo,
		SAFT16kHz8BitMono,
		SAFT16kHz8BitStereo,
		SAFT16kHz16BitMono,
		SAFT16kHz16BitStereo,
		SAFT22kHz8BitMono,
		SAFT22kHz8BitStereo,
		SAFT22kHz16BitMono,
		SAFT22kHz16BitStereo,
		SAFT24kHz8BitMono,
		SAFT24kHz8BitStereo,
		SAFT24kHz16BitMono,
		SAFT24kHz16BitStereo,
		SAFT32kHz8BitMono,
		SAFT32kHz8BitStereo,
		SAFT32kHz16BitMono,
		SAFT32kHz16BitStereo,
		SAFT44kHz8BitMono,
		SAFT44kHz8BitStereo,
		SAFT44kHz16BitMono,
		SAFT44kHz16BitStereo,
		SAFT48kHz8BitMono,
		SAFT48kHz8BitStereo,
		SAFT48kHz16BitMono,
		SAFT48kHz16BitStereo,
		SAFTTrueSpeech_8kHz1BitMono,
		SAFTCCITT_ALaw_8kHzMono,
		SAFTCCITT_ALaw_8kHzStereo,
		SAFTCCITT_ALaw_11kHzMono,
		SAFTCCITT_ALaw_11kHzStereo,
		SAFTCCITT_ALaw_22kHzMono,
		SAFTCCITT_ALaw_22kHzStereo,
		SAFTCCITT_ALaw_44kHzMono,
		SAFTCCITT_ALaw_44kHzStereo,
		SAFTCCITT_uLaw_8kHzMono,
		SAFTCCITT_uLaw_8kHzStereo,
		SAFTCCITT_uLaw_11kHzMono,
		SAFTCCITT_uLaw_11kHzStereo,
		SAFTCCITT_uLaw_22kHzMono,
		SAFTCCITT_uLaw_22kHzStereo,
		SAFTCCITT_uLaw_44kHzMono,
		SAFTCCITT_uLaw_44kHzStereo,
		SAFTADPCM_8kHzMono,
		SAFTADPCM_8kHzStereo,
		SAFTADPCM_11kHzMono,
		SAFTADPCM_11kHzStereo,
		SAFTADPCM_22kHzMono,
		SAFTADPCM_22kHzStereo,
		SAFTADPCM_44kHzMono,
		SAFTADPCM_44kHzStereo,
		SAFTGSM610_8kHzMono,
		SAFTGSM610_11kHzMono,
		SAFTGSM610_22kHzMono,
		SAFTGSM610_44kHzMono
	}

	public enum SpeechAudioState
	{
		SASClosed,
		SASStop,
		SASPause,
		SASRun
	}

	public enum SpeechBookmarkOptions
	{
		SBONone,
		SBOPause
	}

	public enum SpeechDataKeyLocation
	{
		SDKLDefaultLocation = 0,
		SDKLCurrentUser = 1,
		SDKLLocalMachine = 2,
		SDKLCurrentConfig = 5
	}

	[Flags]
	public enum SpeechDiscardType
	{
		SDTProperty = 1,
		SDTReplacement = 2,
		SDTRule = 4,
		SDTDisplayText = 8,
		SDTLexicalForm = 16,
		SDTPronunciation = 32,
		SDTAudio = 64,
		SDTAlternates = 128,
		SDTAll = 255
	}

	[Flags]
	public enum SpeechDisplayAttributes
	{
		SDA_No_Trailing_Space = 0,
		SDA_One_Trailing_Space = 2,
		SDA_Two_Trailing_Spaces = 4,
		SDA_Consume_Leading_Spaces = 8
	}

	[Flags]
	public enum SpeechEmulationCompareFlags
	{
		SECFIgnoreCase = 1,
		SECFIgnoreKanaType = 65536,
		SECFIgnoreWidth = 131072,
		SECFNoSpecialChars = 536870912,
		SECFEmulateResult = 1073741824,
		SECFDefault = 196609
	}

	public enum SpeechEngineConfidence
	{
		SECLowConfidence = -1,
		SECNormalConfidence,
		SECHighConfidence
	}

	public enum SpeechFormatType
	{
		SFTInput,
		SFTSREngine
	}

	public enum SpeechGrammarRuleStateTransitionType
	{
		SGRSTTEpsilon,
		SGRSTTWord,
		SGRSTTRule,
		SGRSTTDictation,
		SGRSTTWildcard,
		SGRSTTTextBuffer
	}

	public enum SpeechGrammarState
	{
		SGSEnabled = 1,
		SGSDisabled = 0,
		SGSExclusive = 3
	}

	public enum SpeechGrammarWordType
	{
		SGDisplay,
		SGLexical,
		SGPronounciation,
		SGLexicalNoSpecialChars
	}

	public enum SpeechInterference
	{
		SINone,
		SINoise,
		SINoSignal,
		SITooLoud,
		SITooQuiet,
		SITooFast,
		SITooSlow
	}

	public enum SpeechLexiconType
	{
		SLTUser = 1,
		SLTApp
	}

	public enum SpeechLoadOption
	{
		SLOStatic,
		SLODynamic
	}

	public enum SpeechPartOfSpeech
	{
		SPSNotOverriden = -1,
		SPSUnknown = 0,
		SPSNoun = 4096,
		SPSVerb = 8192,
		SPSModifier = 12288,
		SPSFunction = 16384,
		SPSInterjection = 20480,
		SPSLMA = 28672,
		SPSSuppressWord = 61440
	}

	public enum SpeechRecoContextState
	{
		SRCS_Disabled,
		SRCS_Enabled
	}

	[Flags]
	public enum SpeechRecoEvents
	{
		SREStreamEnd = 1,
		SRESoundStart = 2,
		SRESoundEnd = 4,
		SREPhraseStart = 8,
		SRERecognition = 16,
		SREHypothesis = 32,
		SREBookmark = 64,
		SREPropertyNumChange = 128,
		SREPropertyStringChange = 256,
		SREFalseRecognition = 512,
		SREInterference = 1024,
		SRERequestUI = 2048,
		SREStateChange = 4096,
		SREAdaptation = 8192,
		SREStreamStart = 16384,
		SRERecoOtherContext = 32768,
		SREAudioLevel = 65536,
		SREPrivate = 262144,
		SREAllEvents = 393215
	}

	[Flags]
	public enum SpeechRecognitionType
	{
		SRTStandard = 0,
		SRTAutopause = 1,
		SRTEmulated = 2,
		SRTSMLTimeout = 4,
		SRTExtendableParse = 8,
		SRTReSent = 0x10
	}

	public enum SpeechRecognizerState
	{
		SRSInactive,
		SRSActive,
		SRSActiveAlways,
		SRSInactiveWithPurge
	}

	public enum SpeechRetainedAudioOptions
	{
		SRAONone,
		SRAORetainAudio
	}

	[Flags]
	public enum SpeechRuleAttributes
	{
		SRATopLevel = 1,
		SRADefaultToActive = 2,
		SRAExport = 4,
		SRAImport = 8,
		SRAInterpreter = 0x10,
		SRADynamic = 0x20,
		SRARoot = 0x40
	}

	public enum SpeechRuleState
	{
		SGDSInactive = 0,
		SGDSActive = 1,
		SGDSActiveWithAutoPause = 3,
		SGDSActiveUserDelimited = 4
	}

	public enum SpeechRunState
	{
		SRSEDone = 1,
		SRSEIsSpeaking
	}

	public enum SpeechSpecialTransitionType
	{
		SSTTWildcard = 1,
		SSTTDictation,
		SSTTTextBuffer
	}

	public enum SpeechStreamFileMode
	{
		SSFMOpenForRead,
		SSFMOpenReadWrite,
		SSFMCreate,
		SSFMCreateForWrite
	}

	public enum SpeechStreamSeekPositionType
	{
		SSSPTRelativeToStart,
		SSSPTRelativeToCurrentPosition,
		SSSPTRelativeToEnd
	}

	public enum SpeechTokenContext
	{
		STCInprocServer = 1,
		STCInprocHandler = 2,
		STCLocalServer = 4,
		STCRemoteServer = 16,
		STCAll = 23
	}

	public enum SpeechTokenShellFolder
	{
		STSF_AppData = 26,
		STSF_LocalAppData = 28,
		STSF_CommonAppData = 35,
		STSF_FlagCreate = 32768
	}

	public enum SpeechVisemeFeature
	{
		SVF_None,
		SVF_Stressed,
		SVF_Emphasis
	}

	public enum SpeechVisemeType
	{
		SVP_0,
		SVP_1,
		SVP_2,
		SVP_3,
		SVP_4,
		SVP_5,
		SVP_6,
		SVP_7,
		SVP_8,
		SVP_9,
		SVP_10,
		SVP_11,
		SVP_12,
		SVP_13,
		SVP_14,
		SVP_15,
		SVP_16,
		SVP_17,
		SVP_18,
		SVP_19,
		SVP_20,
		SVP_21
	}

	[Flags]
	public enum SpeechVoiceEvents
	{
		SVEStartInputStream = 2,
		SVEEndInputStream = 4,
		SVEVoiceChange = 8,
		SVEBookmark = 16,
		SVEWordBoundary = 32,
		SVEPhoneme = 64,
		SVESentenceBoundary = 128,
		SVEViseme = 256,
		SVEAudioLevel = 512,
		SVEPrivate = 32768,
		SVEAllEvents = 33790
	}

	public enum SpeechVoicePriority
	{
		SVPNormal,
		SVPAlert,
		SVPOver
	}

	[Flags]
	public enum SpeechVoiceSpeakFlags
	{
		SVSFDefault = 0,
		SVSFlagsAsync = 1,
		SVSFPurgeBeforeSpeak = 2,
		SVSFIsFilename = 4,
		SVSFIsXML = 8,
		SVSFIsNotXML = 16,
		SVSFPersistXML = 32,
		SVSFNLPSpeakPunc = 64,
		SVSFParseSapi = 128,
		SVSFParseSsml = 256,
		SVSFParseAutodetect = 0,
		SVSFNLPMask = 64,
		SVSFParseMask = 384,
		SVSFVoiceMask = 511,
		SVSFUnusedFlags = -512
	}

	public enum SpeechWordPronounceable
	{
		SWPUnknownWordUnpronounceable,
		SWPUnknownWordPronounceable,
		SWPKnownWordPronounceable
	}

	public enum SpeechWordType
	{
		SWTAdded = 1,
		SWTDeleted
	}

	/// <summary>
	/// SPENDSRSTREAMFLAGS is used to indicate the state of the input stream object when the end of a speech recognition (SR) input stream
	/// has been reached and, thus, enables an application to query for state changes. It is contained in the wParam of SPEVENT or SPEVENTEX
	/// when an SPEI_END_SR_STREAM event is raised.
	/// </summary>
	[Flags]
	public enum SPENDSRSTREAMFLAGS
	{
		/// <summary>No flags are associated with the end of stream event.</summary>
		SPESF_NONE = 0,

		/// <summary>
		/// The input stream object was released upon reaching the end of the current stream. For example, a wave file is a finite stream of
		/// data, and once the end of the stream, and file, is reached, the stream object is released. See also CSpEvent::InputStreamReleased.
		/// </summary>
		SPESF_STREAM_RELEASED = 1 << 0,

		/// <summary>Indicates that there was no actual audio input stream, but that the input stream was emulated.</summary>
		SPESF_EMULATED = 1 << 1
	}

	public enum SPEVENTENUM : ulong
	{
		SPEI_UNDEFINED = 0,
		SPEI_START_INPUT_STREAM = 1,
		SPEI_END_INPUT_STREAM = 2,
		SPEI_VOICE_CHANGE = 3,
		SPEI_TTS_BOOKMARK = 4,
		SPEI_WORD_BOUNDARY = 5,
		SPEI_PHONEME = 6,
		SPEI_SENTENCE_BOUNDARY = 7,
		SPEI_VISEME = 8,
		SPEI_TTS_AUDIO_LEVEL = 9,
		SPEI_TTS_PRIVATE = 15,
		SPEI_MIN_TTS = 1,
		SPEI_MAX_TTS = 15,
		SPEI_END_SR_STREAM = 34,
		SPEI_SOUND_START = 35,
		SPEI_SOUND_END = 36,
		SPEI_PHRASE_START = 37,
		SPEI_RECOGNITION = 38,
		SPEI_HYPOTHESIS = 39,
		SPEI_SR_BOOKMARK = 40,
		SPEI_PROPERTY_NUM_CHANGE = 41,
		SPEI_PROPERTY_STRING_CHANGE = 42,
		SPEI_FALSE_RECOGNITION = 43,
		SPEI_INTERFERENCE = 44,
		SPEI_REQUEST_UI = 45,
		SPEI_RECO_STATE_CHANGE = 46,
		SPEI_ADAPTATION = 47,
		SPEI_START_SR_STREAM = 48,
		SPEI_RECO_OTHER_CONTEXT = 49,
		SPEI_SR_AUDIO_LEVEL = 50,
		SPEI_SR_RETAINEDAUDIO = 51,
		SPEI_SR_PRIVATE = 52,
		SPEI_ACTIVE_CATEGORY_CHANGED = 53,
		SPEI_RESERVED5 = 54,
		SPEI_RESERVED6 = 55,
		SPEI_MIN_SR = 34,
		SPEI_MAX_SR = 55,
		SPEI_RESERVED1 = 30,
		SPEI_RESERVED2 = 33,
		SPEI_RESERVED3 = 63,
		SPFEI_ALL_EVENTS = 0xEFFFFFFFFFFFFFFFUL,
		SPFEI_ALL_SR_EVENTS = 0x003FFFFC00000000UL | SPFEI_FLAGCHECK,
		SPFEI_ALL_TTS_EVENTS = 0x000000000000FFFEUL | SPFEI_FLAGCHECK,
	}

	public enum SPEVENTLPARAMTYPE : ushort
	{
		SPET_LPARAM_IS_UNDEFINED = 0,
		SPET_LPARAM_IS_TOKEN = SPET_LPARAM_IS_UNDEFINED + 1,
		SPET_LPARAM_IS_OBJECT = SPET_LPARAM_IS_TOKEN + 1,
		SPET_LPARAM_IS_POINTER = SPET_LPARAM_IS_OBJECT + 1,
		SPET_LPARAM_IS_STRING = SPET_LPARAM_IS_POINTER + 1
	}

	public enum SPFILEMODE
	{
		SPFM_OPEN_READONLY,
		SPFM_OPEN_READWRITE,
		SPFM_CREATE,
		SPFM_CREATE_ALWAYS,
		SPFM_NUM_MODES
	}

	public enum SPGRAMMARSTATE
	{
		SPGS_DISABLED = 0,
		SPGS_ENABLED = 1,
		SPGS_EXCLUSIVE = 3
	}

	public enum SPGRAMMARWORDTYPE
	{
		SPWT_DISPLAY,
		SPWT_LEXICAL,
		SPWT_PRONUNCIATION,
		SPWT_LEXICAL_NO_SPECIAL_CHARS
	}

	public enum SPINTERFERENCE
	{
		SPINTERFERENCE_NONE,
		SPINTERFERENCE_NOISE,
		SPINTERFERENCE_NOSIGNAL,
		SPINTERFERENCE_TOOLOUD,
		SPINTERFERENCE_TOOQUIET,
		SPINTERFERENCE_TOOFAST,
		SPINTERFERENCE_TOOSLOW,
		SPINTERFERENCE_LATENCY_WARNING,
		SPINTERFERENCE_LATENCY_TRUNCATE_BEGIN,
		SPINTERFERENCE_LATENCY_TRUNCATE_END
	}

	[Flags]
	public enum SPLEXICONTYPE
	{
		eLEXTYPE_USER = 1,
		eLEXTYPE_APP = 2,
		eLEXTYPE_VENDORLEXICON = 4,
		eLEXTYPE_LETTERTOSOUND = 8,
		eLEXTYPE_MORPHOLOGY = 16,
		eLEXTYPE_RESERVED4 = 32,
		eLEXTYPE_USER_SHORTCUT = 64,
		eLEXTYPE_RESERVED6 = 128,
		eLEXTYPE_RESERVED7 = 256,
		eLEXTYPE_RESERVED8 = 512,
		eLEXTYPE_RESERVED9 = 1024,
		eLEXTYPE_RESERVED10 = 2048,
		eLEXTYPE_PRIVATE1 = 4096,
		eLEXTYPE_PRIVATE2 = 8192,
		eLEXTYPE_PRIVATE3 = 16384,
		eLEXTYPE_PRIVATE4 = 32768,
		eLEXTYPE_PRIVATE5 = 65536,
		eLEXTYPE_PRIVATE6 = 131072,
		eLEXTYPE_PRIVATE7 = 262144,
		eLEXTYPE_PRIVATE8 = 524288,
		eLEXTYPE_PRIVATE9 = 1048576,
		eLEXTYPE_PRIVATE10 = 2097152,
		eLEXTYPE_PRIVATE11 = 4194304,
		eLEXTYPE_PRIVATE12 = 8388608,
		eLEXTYPE_PRIVATE13 = 16777216,
		eLEXTYPE_PRIVATE14 = 33554432,
		eLEXTYPE_PRIVATE15 = 67108864,
		eLEXTYPE_PRIVATE16 = 134217728,
		eLEXTYPE_PRIVATE17 = 268435456,
		eLEXTYPE_PRIVATE18 = 536870912,
		eLEXTYPE_PRIVATE19 = 1073741824,
		eLEXTYPE_PRIVATE20 = int.MinValue
	}

	public enum SPLOADOPTIONS
	{
		SPLO_STATIC,
		SPLO_DYNAMIC
	}

	public enum SPPARTOFSPEECH
	{
		SPPS_NotOverriden = -1,
		SPPS_Unknown = 0,
		SPPS_Noun = 4096,
		SPPS_Verb = 8192,
		SPPS_Modifier = 12288,
		SPPS_Function = 16384,
		SPPS_Interjection = 20480,
		SPPS_Noncontent = 24576,
		SPPS_LMA = 28672,
		SPPS_SuppressWord = 61440
	}

	public enum SPPHRASEPROPERTYUNIONTYPE : byte
	{
		SPPPUT_UNUSED = 0,
		SPPPUT_ARRAY_INDEX = SPPPUT_UNUSED + 1
	}

	/// <summary>SPPRONUNCIATIONFLAGS is used with the ISpEnginePronunciation::GetPronounciations function.</summary>
	[Flags]
	public enum SPPRONUNCIATIONFLAGS : ushort
	{
		/// <summary>
		/// Set if the engine will use this pronunciation; otherwise, clear. For example, a speech recognition engine would listen for all
		/// pronunciations, and hence would always set this bit. However, a speech synthesis (TTS) engine will only synthesize one of the
		/// pronunciations, and will only set this bit in this case.
		/// </summary>
		ePRONFLAG_USED = 1 << 0
	}

	[Flags]
	public enum SPRECOEVENTFLAGS
	{
		SPREF_AutoPause = 1 << 0,
		SPREF_Emulated = 1 << 1,
		SPREF_SMLTimeout = 1 << 2,
		SPREF_ExtendableParse = 1 << 3,
		SPREF_ReSent = 1 << 4,
		SPREF_Hypothesis = 1 << 5,
		SPREF_FalseRecognition = 1 << 6
	}

	public enum SPRECOSTATE
	{
		SPRST_INACTIVE,
		SPRST_ACTIVE,
		SPRST_ACTIVE_ALWAYS,
		SPRST_INACTIVE_WITH_PURGE,
		SPRST_NUM_STATES
	}

	public enum SPRULESTATE
	{
		SPRS_INACTIVE = 0,
		SPRS_ACTIVE = 1,
		SPRS_ACTIVE_WITH_AUTO_PAUSE = 3,
		SPRS_ACTIVE_USER_DELIMITED = 4
	}

	[Flags]
	public enum SPRUNSTATE
	{
		SPRS_DONE = 1 << 0,
		SPRS_IS_SPEAKING = 1 << 1
	}

	[Flags]
	public enum SPSEMANTICFORMAT
	{
		SPSMF_SAPI_PROPERTIES = 0,
		SPSMF_SRGS_SEMANTICINTERPRETATION_MS = 1,
		SPSMF_SRGS_SAPIPROPERTIES = 2,
		SPSMF_UPS = 4,
		SPSMF_SRGS_SEMANTICINTERPRETATION_W3C = 8
	}

	public enum SPSHORTCUTTYPE
	{
		SPSHT_NotOverriden = -1,
		SPSHT_Unknown = 0,
		SPSHT_EMAIL = 4096,
		SPSHT_OTHER = 8192,
		SPPS_RESERVED1 = 12288,
		SPPS_RESERVED2 = 16384,
		SPPS_RESERVED3 = 20480,
		SPPS_RESERVED4 = 61440
	}

	public enum SPSTREAMFORMAT
	{
		SPSF_Default = -1,
		SPSF_NoAssignedFormat = 0,
		SPSF_Text = SPSF_NoAssignedFormat + 1,
		SPSF_NonStandardFormat = SPSF_Text + 1,
		SPSF_ExtendedAudioFormat = SPSF_NonStandardFormat + 1,
		SPSF_8kHz8BitMono = SPSF_ExtendedAudioFormat + 1,
		SPSF_8kHz8BitStereo = SPSF_8kHz8BitMono + 1,
		SPSF_8kHz16BitMono = SPSF_8kHz8BitStereo + 1,
		SPSF_8kHz16BitStereo = SPSF_8kHz16BitMono + 1,
		SPSF_11kHz8BitMono = SPSF_8kHz16BitStereo + 1,
		SPSF_11kHz8BitStereo = SPSF_11kHz8BitMono + 1,
		SPSF_11kHz16BitMono = SPSF_11kHz8BitStereo + 1,
		SPSF_11kHz16BitStereo = SPSF_11kHz16BitMono + 1,
		SPSF_12kHz8BitMono = SPSF_11kHz16BitStereo + 1,
		SPSF_12kHz8BitStereo = SPSF_12kHz8BitMono + 1,
		SPSF_12kHz16BitMono = SPSF_12kHz8BitStereo + 1,
		SPSF_12kHz16BitStereo = SPSF_12kHz16BitMono + 1,
		SPSF_16kHz8BitMono = SPSF_12kHz16BitStereo + 1,
		SPSF_16kHz8BitStereo = SPSF_16kHz8BitMono + 1,
		SPSF_16kHz16BitMono = SPSF_16kHz8BitStereo + 1,
		SPSF_16kHz16BitStereo = SPSF_16kHz16BitMono + 1,
		SPSF_22kHz8BitMono = SPSF_16kHz16BitStereo + 1,
		SPSF_22kHz8BitStereo = SPSF_22kHz8BitMono + 1,
		SPSF_22kHz16BitMono = SPSF_22kHz8BitStereo + 1,
		SPSF_22kHz16BitStereo = SPSF_22kHz16BitMono + 1,
		SPSF_24kHz8BitMono = SPSF_22kHz16BitStereo + 1,
		SPSF_24kHz8BitStereo = SPSF_24kHz8BitMono + 1,
		SPSF_24kHz16BitMono = SPSF_24kHz8BitStereo + 1,
		SPSF_24kHz16BitStereo = SPSF_24kHz16BitMono + 1,
		SPSF_32kHz8BitMono = SPSF_24kHz16BitStereo + 1,
		SPSF_32kHz8BitStereo = SPSF_32kHz8BitMono + 1,
		SPSF_32kHz16BitMono = SPSF_32kHz8BitStereo + 1,
		SPSF_32kHz16BitStereo = SPSF_32kHz16BitMono + 1,
		SPSF_44kHz8BitMono = SPSF_32kHz16BitStereo + 1,
		SPSF_44kHz8BitStereo = SPSF_44kHz8BitMono + 1,
		SPSF_44kHz16BitMono = SPSF_44kHz8BitStereo + 1,
		SPSF_44kHz16BitStereo = SPSF_44kHz16BitMono + 1,
		SPSF_48kHz8BitMono = SPSF_44kHz16BitStereo + 1,
		SPSF_48kHz8BitStereo = SPSF_48kHz8BitMono + 1,
		SPSF_48kHz16BitMono = SPSF_48kHz8BitStereo + 1,
		SPSF_48kHz16BitStereo = SPSF_48kHz16BitMono + 1,
		SPSF_TrueSpeech_8kHz1BitMono = SPSF_48kHz16BitStereo + 1,
		SPSF_CCITT_ALaw_8kHzMono = SPSF_TrueSpeech_8kHz1BitMono + 1,
		SPSF_CCITT_ALaw_8kHzStereo = SPSF_CCITT_ALaw_8kHzMono + 1,
		SPSF_CCITT_ALaw_11kHzMono = SPSF_CCITT_ALaw_8kHzStereo + 1,
		SPSF_CCITT_ALaw_11kHzStereo = SPSF_CCITT_ALaw_11kHzMono + 1,
		SPSF_CCITT_ALaw_22kHzMono = SPSF_CCITT_ALaw_11kHzStereo + 1,
		SPSF_CCITT_ALaw_22kHzStereo = SPSF_CCITT_ALaw_22kHzMono + 1,
		SPSF_CCITT_ALaw_44kHzMono = SPSF_CCITT_ALaw_22kHzStereo + 1,
		SPSF_CCITT_ALaw_44kHzStereo = SPSF_CCITT_ALaw_44kHzMono + 1,
		SPSF_CCITT_uLaw_8kHzMono = SPSF_CCITT_ALaw_44kHzStereo + 1,
		SPSF_CCITT_uLaw_8kHzStereo = SPSF_CCITT_uLaw_8kHzMono + 1,
		SPSF_CCITT_uLaw_11kHzMono = SPSF_CCITT_uLaw_8kHzStereo + 1,
		SPSF_CCITT_uLaw_11kHzStereo = SPSF_CCITT_uLaw_11kHzMono + 1,
		SPSF_CCITT_uLaw_22kHzMono = SPSF_CCITT_uLaw_11kHzStereo + 1,
		SPSF_CCITT_uLaw_22kHzStereo = SPSF_CCITT_uLaw_22kHzMono + 1,
		SPSF_CCITT_uLaw_44kHzMono = SPSF_CCITT_uLaw_22kHzStereo + 1,
		SPSF_CCITT_uLaw_44kHzStereo = SPSF_CCITT_uLaw_44kHzMono + 1,
		SPSF_ADPCM_8kHzMono = SPSF_CCITT_uLaw_44kHzStereo + 1,
		SPSF_ADPCM_8kHzStereo = SPSF_ADPCM_8kHzMono + 1,
		SPSF_ADPCM_11kHzMono = SPSF_ADPCM_8kHzStereo + 1,
		SPSF_ADPCM_11kHzStereo = SPSF_ADPCM_11kHzMono + 1,
		SPSF_ADPCM_22kHzMono = SPSF_ADPCM_11kHzStereo + 1,
		SPSF_ADPCM_22kHzStereo = SPSF_ADPCM_22kHzMono + 1,
		SPSF_ADPCM_44kHzMono = SPSF_ADPCM_22kHzStereo + 1,
		SPSF_ADPCM_44kHzStereo = SPSF_ADPCM_44kHzMono + 1,
		SPSF_GSM610_8kHzMono = SPSF_ADPCM_44kHzStereo + 1,
		SPSF_GSM610_11kHzMono = SPSF_GSM610_8kHzMono + 1,
		SPSF_GSM610_22kHzMono = SPSF_GSM610_11kHzMono + 1,
		SPSF_GSM610_44kHzMono = SPSF_GSM610_22kHzMono + 1,
		SPSF_NUM_FORMATS = SPSF_GSM610_44kHzMono + 1
	}

	public enum SPSTREAMFORMATTYPE
	{
		SPWF_INPUT,
		SPWF_SRENGINE
	}

	[Flags]
	public enum SPVALUETYPE
	{
		SPDF_PROPERTY = 0x1,
		SPDF_REPLACEMENT = 0x2,
		SPDF_RULE = 0x4,
		SPDF_DISPLAYTEXT = 0x8,
		SPDF_LEXICALFORM = 0x10,
		SPDF_PRONUNCIATION = 0x20,
		SPDF_AUDIO = 0x40,
		SPDF_ALTERNATES = 0x80,
		SPDF_ALL = 0xff
	}

	public enum SPVISEMES
	{
		SP_VISEME_0,
		SP_VISEME_1,
		SP_VISEME_2,
		SP_VISEME_3,
		SP_VISEME_4,
		SP_VISEME_5,
		SP_VISEME_6,
		SP_VISEME_7,
		SP_VISEME_8,
		SP_VISEME_9,
		SP_VISEME_10,
		SP_VISEME_11,
		SP_VISEME_12,
		SP_VISEME_13,
		SP_VISEME_14,
		SP_VISEME_15,
		SP_VISEME_16,
		SP_VISEME_17,
		SP_VISEME_18,
		SP_VISEME_19,
		SP_VISEME_20,
		SP_VISEME_21
	}

	public enum SPVLIMITS
	{
		SPMIN_VOLUME = 0,
		SPMAX_VOLUME = 100,
		SPMIN_RATE = -10,
		SPMAX_RATE = 10
	}

	public enum SPVPRIORITY
	{
		SPVPRI_NORMAL,
		SPVPRI_ALERT,
		SPVPRI_OVER
	}

	public enum SPWAVEFORMATTYPE
	{
		SPWF_INPUT,
		SPWF_SRENGINE
	}

	public enum SPWORDPRONOUNCEABLE
	{
		SPWP_UNKNOWN_WORD_UNPRONOUNCEABLE,
		SPWP_UNKNOWN_WORD_PRONOUNCEABLE,
		SPWP_KNOWN_WORD_PRONOUNCEABLE
	}

	public enum SPWORDTYPE
	{
		eWORDTYPE_ADDED = 1,
		eWORDTYPE_DELETED
	}

	public enum SPXMLRESULTOPTIONS
	{
		SPXRO_SML,
		SPXRO_Alternates_SML
	}

	public static SPEVENTENUM SPFEI(SPEVENTENUM SPEI_ord) => (SPEVENTENUM)((1UL << (int)SPEI_ord) | SPFEI_FLAGCHECK);

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct SPAUDIOBUFFERINFO
	{
		public uint ulMsMinNotification;

		public uint ulMsBufferSize;

		public uint ulMsEventBias;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SPAUDIOSTATUS
	{
		public int cbFreeBuffSpace;

		public uint cbNonBlockingIO;

		public SPAUDIOSTATE State;

		public ulong CurSeekPos;

		public ulong CurDevicePos;

		public uint dwAudioLevel;

		public uint dwReserved2;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct SPBINARYGRAMMAR
	{
		public uint ulTotalSerializedSize;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SPEVENT
	{
		private ushort _eEventId;

		public SPEVENTLPARAMTYPE elParamType;

		public uint ulStreamNum;

		public ulong ullAudioStreamOffset;

		public IntPtr wParam;

		public IntPtr lParam;

		public SPEVENTENUM eEventId { readonly get => (SPEVENTENUM)_eEventId; set => _eEventId = (ushort)value; }

		/// <summary>Gets and sets the underlying value for <see cref="lParam"/> based on object type and <see cref="elParamType"/> value.</summary>
		/// <exception cref="System.ArgumentException">Unsupported type for lParamValue - value</exception>
		public object? lParamValue
		{
			readonly get => elParamType switch
			{
				SPEVENTLPARAMTYPE.SPET_LPARAM_IS_UNDEFINED => null,
				SPEVENTLPARAMTYPE.SPET_LPARAM_IS_STRING => StringHelper.GetString(lParam, CharSet.Unicode),
				SPEVENTLPARAMTYPE.SPET_LPARAM_IS_POINTER => new SafeCoTaskMemHandle(lParam, wParam.ToInt64(), false),
				SPEVENTLPARAMTYPE.SPET_LPARAM_IS_TOKEN => Marshal.GetObjectForIUnknown(lParam) as ISpObjectToken,
				SPEVENTLPARAMTYPE.SPET_LPARAM_IS_OBJECT => Marshal.GetObjectForIUnknown(lParam),
				_ => throw new InvalidOperationException("Unknown lParam type"),
			};
			set
			{
				Dispose();
				if (value is null)
				{
					elParamType = SPEVENTLPARAMTYPE.SPET_LPARAM_IS_UNDEFINED;
					lParam = IntPtr.Zero;
				}
				else if (value is string str)
				{
					elParamType = SPEVENTLPARAMTYPE.SPET_LPARAM_IS_STRING;
					lParam = StringHelper.AllocString(str, CharSet.Unicode, Marshal.AllocCoTaskMem);
				}
				else if (value is ISafeMemoryHandle ptr)
				{
					elParamType = SPEVENTLPARAMTYPE.SPET_LPARAM_IS_POINTER;
					wParam = (IntPtr)(long)ptr.Size;
					lParam = ptr.DangerousGetHandle();
				}
				else if (value is ISpObjectToken token)
				{
					elParamType = SPEVENTLPARAMTYPE.SPET_LPARAM_IS_TOKEN;
					lParam = Marshal.GetIUnknownForObject(token);
				}
				else if (value.GetType().IsCOMObject)
				{
					elParamType = SPEVENTLPARAMTYPE.SPET_LPARAM_IS_OBJECT;
					lParam = Marshal.GetIUnknownForObject(value);
				}
				else
				{
					throw new ArgumentException("Unsupported type for lParamValue", nameof(value));
				}
			}
		}

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		public void Dispose()
		{
			if (elParamType != SPEVENTLPARAMTYPE.SPET_LPARAM_IS_UNDEFINED)
			{
				if (elParamType is SPEVENTLPARAMTYPE.SPET_LPARAM_IS_POINTER or SPEVENTLPARAMTYPE.SPET_LPARAM_IS_STRING)
				{
					Marshal.FreeCoTaskMem(lParam);
				}
				else if (elParamType is SPEVENTLPARAMTYPE.SPET_LPARAM_IS_TOKEN or SPEVENTLPARAMTYPE.SPET_LPARAM_IS_OBJECT)
				{
					Marshal.FinalReleaseComObject(Marshal.GetObjectForIUnknown(lParam));
				}
			}
			this = new();
		}

		/// <summary>Clones this instance, reallocating memory and object references.</summary>
		/// <exception cref="System.OutOfMemoryException"></exception>
		public readonly SPEVENT Clone()
		{
			var pDestEvent = this;
			if (elParamType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_POINTER && lParam != IntPtr.Zero)
			{
				pDestEvent.lParam = Marshal.AllocCoTaskMem(wParam.ToInt32());
				if (pDestEvent.lParam != IntPtr.Zero)
				{
					lParam.CopyTo(pDestEvent.lParam, wParam.ToInt32());
				}
				else
				{
					pDestEvent.eEventId = SPEVENTENUM.SPEI_UNDEFINED;
					throw new OutOfMemoryException();
				}
			}
			else if (elParamType == SPEVENTLPARAMTYPE.SPET_LPARAM_IS_STRING && lParam != IntPtr.Zero)
			{
				var str = StringHelper.GetString(lParam, CharSet.Unicode);
				pDestEvent.lParam = StringHelper.AllocString(str, CharSet.Unicode, Marshal.AllocCoTaskMem);
				if (pDestEvent.lParam == IntPtr.Zero)
				{
					pDestEvent.eEventId = SPEVENTENUM.SPEI_UNDEFINED;
					throw new OutOfMemoryException();
				}
			}
			else if (elParamType is SPEVENTLPARAMTYPE.SPET_LPARAM_IS_TOKEN or SPEVENTLPARAMTYPE.SPET_LPARAM_IS_OBJECT)
			{
				pDestEvent.lParam = Marshal.GetIUnknownForObject(Marshal.GetObjectForIUnknown(lParam));
			}
			return pDestEvent;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SPEVENTSOURCEINFO
	{
		public SPEVENTENUM ullEventInterest;

		public SPEVENTENUM ullQueuedInterest;

		public uint ulCount;
	}

	/// <summary>
	/// <para>
	/// You can create pronunciations for words that are not currently in the lexicon using the phonemes represented in the attached
	/// appendices. The proposed phoneme set is composed of a symbolic phonetic representation (SYM).
	/// </para>
	/// <para>
	/// You can enter the SYM representation to create the pronunciation by using the XML PRON tag, or by creating a new lexicon entry. Each
	/// phoneme should be space delimited.
	/// </para>
	/// <para>
	/// The engine is passed a USHORT structure called SPPHONEID (a number between 1 and n where n is the total number of phonemes for that
	/// language). The conversion from the SYM to SPPHONEID occurs in the SAPI PhoneConverter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Mark Up Tag</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description>PRON SYM</description>
	/// <description>Tag used to insert a pronunciation using symbolic representation</description>
	/// </item>
	/// </list>
	/// <para>Example: pronunciation for "hello"</para>
	/// <para><c>&lt;PRON SYM = "h eh l ow"/&gt;</c></para>
	/// <para>For improved accuracy, the primary (1), secondary (2) stress markers, and the syllabic markers (-) can be added to the pronunciation.</para>
	/// <para>Example: pronunciation for "hello" using the primary stress (1) and syllabic (-) markers:</para>
	/// <para><c>&lt;PRON SYM = "h eh - l ow 1"/&gt;</c></para>
	/// <para>
	/// SAPI-compliant engines are required to accept the PHONEID representation, and produce an articulation. The specific allophonic
	/// articulation is defined by the engine. There is no provision for support of phonemes outside the SAPI phoneme set.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <para><b>Main goals for defining the language dependent phoneme set:</b></para>
	/// </item>
	/// <list type="bullet">
	/// <item>
	/// <para>Provide an engine-independent architecture for application developers to create user and application lexicons.</para>
	/// </item>
	/// <item>
	/// <para>
	/// Make the English phonetic table simple enough to be used and understood by non-linguists who use the American English phoneme set.
	/// </para>
	/// </item>
	/// </list>
	/// </list>
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ee125161(v=vs.85)
	[PInvokeData("sapi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct SPPHONEID(ushort value) : IConvertible
	{
		private readonly ushort value = value;

		/// <summary>Performs an implicit conversion from <see cref="ushort"/> to <see cref="SPPHONEID"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SPPHONEID(ushort value) => new(value);

		/// <summary>Performs an implicit conversion from <see cref="SPPHONEID"/> to <see cref="ushort"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ushort(SPPHONEID value) => value.value;

		public static SPPHONEID[]? FromString(string? str)
		{
			if (str is null) return null;
			var arr = new SPPHONEID[str.Length + 1];
			for (int i = 0; i < str.Length; i++)
				arr[i] = (SPPHONEID)str[i];
			arr[^1] = 0;
			return arr;
		}

		public static string? ToString(SPPHONEID[]? pId)
		{
			if (pId is null) return null;
			var sb = new StringBuilder();
			for (int i = 0; i < pId.Length && pId[i] != 0; i++)
				sb.Append((char)pId[i]);
			return sb.ToString();
		}

		readonly TypeCode IConvertible.GetTypeCode() => value.GetTypeCode();
		readonly bool IConvertible.ToBoolean(IFormatProvider? provider) => ((IConvertible)value).ToBoolean(provider);
		readonly byte IConvertible.ToByte(IFormatProvider? provider) => ((IConvertible)value).ToByte(provider);
		readonly char IConvertible.ToChar(IFormatProvider? provider) => ((IConvertible)value).ToChar(provider);
		readonly DateTime IConvertible.ToDateTime(IFormatProvider? provider) => ((IConvertible)value).ToDateTime(provider);
		readonly decimal IConvertible.ToDecimal(IFormatProvider? provider) => ((IConvertible)value).ToDecimal(provider);
		readonly double IConvertible.ToDouble(IFormatProvider? provider) => ((IConvertible)value).ToDouble(provider);
		readonly short IConvertible.ToInt16(IFormatProvider? provider) => ((IConvertible)value).ToInt16(provider);
		readonly int IConvertible.ToInt32(IFormatProvider? provider) => ((IConvertible)value).ToInt32(provider);
		readonly long IConvertible.ToInt64(IFormatProvider? provider) => ((IConvertible)value).ToInt64(provider);
		readonly sbyte IConvertible.ToSByte(IFormatProvider? provider) => ((IConvertible)value).ToSByte(provider);
		readonly float IConvertible.ToSingle(IFormatProvider? provider) => ((IConvertible)value).ToSingle(provider);
		readonly string IConvertible.ToString(IFormatProvider? provider) => value.ToString(provider);
		readonly object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ((IConvertible)value).ToType(conversionType, provider);
		readonly ushort IConvertible.ToUInt16(IFormatProvider? provider) => ((IConvertible)value).ToUInt16(provider);
		readonly uint IConvertible.ToUInt32(IFormatProvider? provider) => ((IConvertible)value).ToUInt32(provider);
		readonly ulong IConvertible.ToUInt64(IFormatProvider? provider) => ((IConvertible)value).ToUInt64(provider);
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	[MarshaledAlternative(typeof(SPPHRASE_M))]
	public partial struct SPPHRASE
	{
		public uint cbSize;

		public LANGID LangID;

		public ushort wHomophoneGroupId;

		public ulong ullGrammarID;

		public FILETIME ftStartTime;

		public ulong ullAudioStreamPosition;

		public uint ulAudioSizeBytes;

		public uint ulRetainedSizeBytes;

		public uint ulAudioSizeTime;

		public SPPHRASERULE Rule;

		public StructPointer<SPPHRASEPROPERTY> pProperties;

		public ArrayPointer<SPPHRASEELEMENT> pElements;

		public uint cReplacements;

		public ArrayPointer<SPPHRASEREPLACEMENT> pReplacements;

		public Guid SREngineID;

		public uint ulSREnginePrivateDataSize;

		public IntPtr pSREnginePrivateData;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string pSML;

		public StructPointer<SPSEMANTICERRORINFO> pSemanticErrorInfo;

		public SPSEMANTICFORMAT SemanticTagFormat;
	}

	[Marshaled(Pack = 8)]
	public struct SPPHRASE_M
	{
		[MarshalFieldAs.SizeOf]
		internal uint cbSize;

		public LANGID LangID;

		public ushort wHomophoneGroupId;

		public ulong ullGrammarID;

		public FILETIME ftStartTime;

		public ulong ullAudioStreamPosition;

		public uint ulAudioSizeBytes;

		public uint ulRetainedSizeBytes;

		public uint ulAudioSizeTime;

		public SPPHRASERULE_M Rule;

		[MarshalFieldAs.StructPtr]
		public SPPHRASEPROPERTY_M? pProperties;

		[MarshalFieldAs.Array(ArrayLayout.LPArray, SizeFieldName = "Rule.ulCountOfElements")]
		public SPPHRASEELEMENT_M[]? pElements;

		internal uint cReplacements;

		[MarshalFieldAs.Array(ArrayLayout.LPArray, SizeFieldName = nameof(cReplacements))]
		public SPPHRASEREPLACEMENT_M[]? pReplacements;

		public Guid SREngineID;

		internal uint ulSREnginePrivateDataSize;

		[MarshalFieldAs.Array(ArrayLayout.LPArray, SizeFieldName = nameof(ulSREnginePrivateDataSize))]
		public byte[]? pSREnginePrivateData;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pSML;

		[MarshalFieldAs.StructPtr]
		public SPSEMANTICERRORINFO_M? pSemanticErrorInfo;

		public SPSEMANTICFORMAT SemanticTagFormat;

		public static explicit operator SPPHRASE_M(SafeCoTaskMemStruct<SPPHRASE> h) => Marshaler.Marshaler.PtrToValue<SPPHRASE_M>(h.DangerousGetHandle(), new(StringEncoding.Unicode));
	}

	/// <summary>SPPHRASEELEMENT contains the information for a spoken word.</summary>
	[PInvokeData("sapi.h", MSDNShortId = "https://learn.microsoft.com/en-us/previous-versions/office/developer/speech-technologies/jj127873(v=msdn.10)")]
	[MarshaledAlternative(typeof(SPPHRASEELEMENT_M))]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public partial struct SPPHRASEELEMENT
	{
		/// <summary>The starting offset of the element in 100-nanosecond units of time relative to the start of the phrase.</summary>
		public uint ulAudioTimeOffset;

		/// <summary>The length of the element in 100-nanosecond units of time.</summary>
		public uint ulAudioSizeTime;

		/// <summary>The starting offset of the element in bytes relative to the start of the phrase in the original input stream.</summary>
		public uint ulAudioStreamOffset;

		/// <summary>The size of the element in bytes in the original input stream.</summary>
		public uint ulAudioSizeBytes;

		/// <summary>The starting offset of the element in bytes relative to the start of the phrase in the retained audio stream</summary>
		public uint ulRetainedStreamOffset;

		/// <summary>The size of the element in bytes in the retained audio stream.</summary>
		public uint ulRetainedSizeBytes;

		/// <summary>The display text for this element (for example, ",").</summary>
		public PWSTR pszDisplayText;

		/// <summary>The lexical form of this element (for example, "comma" for ",").</summary>
		public PWSTR pszLexicalForm;

		/// <summary>The pronunciation for this element as a null-terminated array of SPPHONEID.</summary>
		public ArrayPointer<SPPHONEID> pszPronunciation;

		/// <summary>
		/// A bit field of SPDISPLAYATTRIBUTES defining extra display information which the application should honor when displaying this word.
		/// </summary>
		public SPDISPLAYATTRIBUTES bDisplayAttributes;

		/// <summary>
		/// The required confidence for this element (either SP_LOW_CONFIDENCE, SP_NORMAL_CONFIDENCE, or SP_HIGH_CONFIDENCE). If a word is
		/// prefixed with a '-' (minus), the RequiredConfidence is SP_LOW_CONFIDENCE, and '+' (plus) will set this field to
		/// SP_HIGH_CONFIDENCE (for example, "This -is -a +test").
		/// </summary>
		public SP_CONFIDENCE RequiredConfidence;

		/// <summary>
		/// The actual confidence for this element (either SP_LOW_CONFIDENCE, SP_NORMAL_CONFIDENCE, or SP_HIGH_CONFIDENCE). This is always at
		/// least the RequiredConfidence.
		/// </summary>
		public SP_CONFIDENCE ActualConfidence;

		/// <summary>Reserved for future use.</summary>
		public byte reserved;

		/// <summary>
		/// The confidence score computed by the SR engine. The value range is engine dependent. It can be used to optimize an application's
		/// performance with a specific engine. Using this value will improve the application with a particular speech engine but more than
		/// likely will make it worse with other engines and should be used with care. This value is more useful with speaker-independent
		/// engines because it allows a large corpus of recorded usage to correctly optimize the overall accuracy of the application.
		/// </summary>
		public float SREngineConfidence;
	}

	/// <summary>SPPHRASEELEMENT contains the information for a spoken word.</summary>
	[PInvokeData("sapi.h", MSDNShortId = "https://learn.microsoft.com/en-us/previous-versions/office/developer/speech-technologies/jj127873(v=msdn.10)")]
	[Marshaled(Pack = 8, StringEncoding = StringEncoding.Unicode)]
	public struct SPPHRASEELEMENT_M
	{
		/// <summary>The starting offset of the element in 100-nanosecond units of time relative to the start of the phrase.</summary>
		public uint ulAudioTimeOffset;

		/// <summary>The length of the element in 100-nanosecond units of time.</summary>
		public uint ulAudioSizeTime;

		/// <summary>The starting offset of the element in bytes relative to the start of the phrase in the original input stream.</summary>
		public uint ulAudioStreamOffset;

		/// <summary>The size of the element in bytes in the original input stream.</summary>
		public uint ulAudioSizeBytes;

		/// <summary>The starting offset of the element in bytes relative to the start of the phrase in the retained audio stream</summary>
		public uint ulRetainedStreamOffset;

		/// <summary>The size of the element in bytes in the retained audio stream.</summary>
		public uint ulRetainedSizeBytes;

		/// <summary>The display text for this element (for example, ",").</summary>
		public string? pszDisplayText;

		/// <summary>The lexical form of this element (for example, "comma" for ",").</summary>
		public string pszLexicalForm;

		/// <summary>The pronunciation for this element as a null-terminated array of SPPHONEID.</summary>
		[MarshalFieldAs.Array(ArrayLayout.LPArrayNullTerm)]
		public SPPHONEID[]? pszPronunciation;

		/// <summary>
		/// A bit field of SPDISPLAYATTRIBUTES defining extra display information which the application should honor when displaying this word.
		/// </summary>
		public SPDISPLAYATTRIBUTES bDisplayAttributes;

		/// <summary>
		/// The required confidence for this element (either SP_LOW_CONFIDENCE, SP_NORMAL_CONFIDENCE, or SP_HIGH_CONFIDENCE). If a word is
		/// prefixed with a '-' (minus), the RequiredConfidence is SP_LOW_CONFIDENCE, and '+' (plus) will set this field to
		/// SP_HIGH_CONFIDENCE (for example, "This -is -a +test").
		/// </summary>
		public SP_CONFIDENCE RequiredConfidence;

		/// <summary>
		/// The actual confidence for this element (either SP_LOW_CONFIDENCE, SP_NORMAL_CONFIDENCE, or SP_HIGH_CONFIDENCE). This is always at
		/// least the RequiredConfidence.
		/// </summary>
		public SP_CONFIDENCE ActualConfidence;

		/// <summary>Reserved for future use.</summary>
		public byte reserved;

		/// <summary>
		/// The confidence score computed by the SR engine. The value range is engine dependent. It can be used to optimize an application's
		/// performance with a specific engine. Using this value will improve the application with a particular speech engine but more than
		/// likely will make it worse with other engines and should be used with care. This value is more useful with speaker-independent
		/// engines because it allows a large corpus of recorded usage to correctly optimize the overall accuracy of the application.
		/// </summary>
		public float SREngineConfidence;
	}

	/// <summary>
	/// <para>SPPHRASEPROPERTY stores the information for one semantic property. It can be used to construct a semantic property tree.</para>
	/// <para>See also Designing Grammar Rules for more information about semantic properties.</para>
	/// </summary>
	[PInvokeData("sapi.h", MSDNShortId = "https://learn.microsoft.com/en-us/previous-versions/office/developer/speech-technologies/jj127874(v=msdn.10)")]
	[MarshaledAlternative(typeof(SPPHRASEPROPERTY_M))]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public partial struct SPPHRASEPROPERTY
	{
		/// <summary>Name of the null-terminated string of the semantic property.</summary>
		public PWSTR pszName;

		private UNION union;

		[StructLayout(LayoutKind.Explicit)]
		private struct UNION
		{
			[FieldOffset(0)]
			public ulong ulId;

			[FieldOffset(0)]
			public SPPHRASEPROPERTYUNIONTYPE bType;

			[FieldOffset(1)]
			public byte bReserved;

			[FieldOffset(2)]
			public ushort usArrayIndex;
		}

		/// <summary>The identifier of the semantic property.</summary>
		public ulong ulId { readonly get => union.ulId; set => union.ulId = value; }

		/// <summary>SPPHRASEPROPERTYUNIONTYPE indicating how to use the union.</summary>
		public SPPHRASEPROPERTYUNIONTYPE bType { readonly get => union.bType; set => union.bType = value; }

		/// <summary>For W3C grammars, indicates the array index, if this is an array element. Array elements have the name "item".</summary>
		public ushort usArrayIndex { readonly get => union.usArrayIndex; set => union.usArrayIndex = value; }

		/// <summary>Null-terminated string value of the semantic property.</summary>
		public PWSTR pszValue;

		/// <summary>
		/// VARIANT value of a semantic property. The type has to be on of the following: VT_BOOL, VT_I4, VT_R4, VT_R8, or VT_BYREF (only for
		/// dynamic grammars).
		/// </summary>
		public OleAut32.VARIANT vValue;

		/// <summary>The first spoken element spanned by this property.</summary>
		public uint ulFirstElement;

		/// <summary>The number of spoken elements spanned by this property.</summary>
		public uint ulCountOfElements;

		/// <summary>Pointer to next sibling in property tree.</summary>
		public unsafe SPPHRASEPROPERTY* pNextSibling;

		/// <summary>Pointer to the first child of this semantic property.</summary>
		public unsafe SPPHRASEPROPERTY* pFirstChild;

		/// <summary>
		/// Confidence value for this semantic property computed by the speech recognition (SR) engine. The value range is specific to each
		/// SR engine.
		/// </summary>
		public float SREngineConfidence;

		/// <summary>
		/// Confidence value for this semantic property computed by the Speech Platform. The value is either SP_LOW_CONFIDENCE,
		/// SP_NORMAL_CONFIDENCE, or SP_HIGH_CONFIDENCE.
		/// </summary>
		public SP_CONFIDENCE Confidence;
	}

	/// <summary>
	/// <para>SPPHRASEPROPERTY stores the information for one semantic property. It can be used to construct a semantic property tree.</para>
	/// <para>See also Designing Grammar Rules for more information about semantic properties.</para>
	/// </summary>
	[PInvokeData("sapi.h", MSDNShortId = "https://learn.microsoft.com/en-us/previous-versions/office/developer/speech-technologies/jj127874(v=msdn.10)")]
	[Marshaled(Pack = 8, StringEncoding = StringEncoding.Unicode)]
	public struct SPPHRASEPROPERTY_M
	{
		/// <summary>Name of the null-terminated string of the semantic property.</summary>
		public string pszName;

		/// <summary>The identifier of the semantic property.</summary>
		public ulong ulId;

		/// <summary>SPPHRASEPROPERTYUNIONTYPE indicating how to use the union.</summary>
		public SPPHRASEPROPERTYUNIONTYPE bType
		{
			readonly get => (SPPHRASEPROPERTYUNIONTYPE)UnionHelper.GetArrayItemAtOffset<byte, ulong>(ulId, 0);
			set => UnionHelper.SetArrayItemAtOffset(ref ulId, 0, (byte)value);
		}

		/// <summary>For W3C grammars, indicates the array index, if this is an array element. Array elements have the name "item".</summary>
		public ushort usArrayIndex
		{
			readonly get => UnionHelper.GetArrayItemAtOffset<ushort, ulong>(ulId, 1);
			set => UnionHelper.SetArrayItemAtOffset(ref ulId, 1, value);
		}

		/// <summary>Null-terminated string value of the semantic property.</summary>
		public string pszValue;

		/// <summary>
		/// VARIANT value of a semantic property. The type has to be on of the following: VT_BOOL, VT_I4, VT_R4, VT_R8, or VT_BYREF (only for
		/// dynamic grammars).
		/// </summary>
		[MarshalAs(UnmanagedType.Struct)]
		public object vValue;

		/// <summary>The first spoken element spanned by this property.</summary>
		public uint ulFirstElement;

		/// <summary>The number of spoken elements spanned by this property.</summary>
		public uint ulCountOfElements;

		/// <summary>Pointer to next sibling in property tree.</summary>
		public ManagedStructPointer<SPPHRASEPROPERTY_M> pNextSibling;

		/// <summary>Pointer to the first child of this semantic property.</summary>
		public ManagedStructPointer<SPPHRASEPROPERTY_M> pFirstChild;

		/// <summary>
		/// Confidence value for this semantic property computed by the speech recognition (SR) engine. The value range is specific to each
		/// SR engine.
		/// </summary>
		public float SREngineConfidence;

		/// <summary>
		/// Confidence value for this semantic property computed by the Speech Platform. The value is either SP_LOW_CONFIDENCE,
		/// SP_NORMAL_CONFIDENCE, or SP_HIGH_CONFIDENCE.
		/// </summary>
		public SP_CONFIDENCE Confidence;
	}

	/// <summary>
	/// SPPHRASEREPLACEMENT replaces the display text of one or more of the spoken words. This is used by speech recognition engines to
	/// perform Inverse Text Normalization (ITN). For example the spoken words "twenty" and "three" are replaced by the replacement text "23."
	/// </summary>
	[PInvokeData("sapi.h", MSDNShortId = "https://learn.microsoft.com/en-us/previous-versions/office/developer/speech-technologies/jj127875(v=msdn.10)")]
	[MarshaledAlternative(typeof(SPPHRASEREPLACEMENT_M))]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public partial struct SPPHRASEREPLACEMENT
	{
		/// <summary>One or more SPDISPLAYATTRIBUTES for the replacement text.</summary>
		public SPDISPLAYATTRIBUTES bDisplayAttributes;

		/// <summary>Text for the replacement.</summary>
		public PWSTR pszReplacementText;

		/// <summary>Offset of the first spoken element to be replaced.</summary>
		public uint ulFirstElement;

		/// <summary>Number of spoken elements to replace.</summary>
		public uint ulCountOfElements;
	}

	/// <summary>
	/// SPPHRASEREPLACEMENT replaces the display text of one or more of the spoken words. This is used by speech recognition engines to
	/// perform Inverse Text Normalization (ITN). For example the spoken words "twenty" and "three" are replaced by the replacement text "23."
	/// </summary>
	[PInvokeData("sapi.h", MSDNShortId = "https://learn.microsoft.com/en-us/previous-versions/office/developer/speech-technologies/jj127875(v=msdn.10)")]
	[Marshaled(Pack = 8, StringEncoding = StringEncoding.Unicode)]
	public struct SPPHRASEREPLACEMENT_M
	{
		/// <summary>One or more SPDISPLAYATTRIBUTES for the replacement text.</summary>
		public SPDISPLAYATTRIBUTES bDisplayAttributes;

		/// <summary>Text for the replacement.</summary>
		public string pszReplacementText;

		/// <summary>Offset of the first spoken element to be replaced.</summary>
		public uint ulFirstElement;

		/// <summary>Number of spoken elements to replace.</summary>
		public uint ulCountOfElements;
	}

	/// <summary>
	/// SPPHRASERULE contains the information for a rule in a grammar result. SAPI uses the pFirstChild and pNextSibling pointers to
	/// represent the parse tree. SPPHRASE.Rule is the root node of the parse tree.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	[MarshaledAlternative(typeof(SPPHRASERULE_M))]
	public partial struct SPPHRASERULE
	{
		/// <summary>Name of this rule (in Speech Text Grammar Format set using &lt;RULE NAME="MyName"&gt;).</summary>
		public PWSTR pszName;

		/// <summary>ID of this rule (set using &lt;RULE ID="123"&gt;).</summary>
		public uint ulId;

		/// <summary>The index of the first spoken element (word) of this rule.</summary>
		public uint ulFirstElement;

		/// <summary>Number of spoken elements (words) spanned by this rule.</summary>
		public uint ulCountOfElements;

		/// <summary>Pointer to the next sibling in the parse tree.</summary>
		public unsafe SPPHRASERULE* pNextSibling;

		/// <summary>Pointer to the first child node in the parse tree.</summary>
		public unsafe SPPHRASERULE* pFirstChild;

		/// <summary>
		/// Confidence for this rule computed by the SR engine. The value is engine dependent and not standardized across multiple SR
		/// engines. See Confidence Scoring and Rejection in SAPI Speech Recognition Engine Guide for additional details.
		/// </summary>
		public float SREngineConfidence;

		/// <summary>
		/// Confidence for this rule computed by SAPI. The value is either SP_LOW_CONFIDENCE, SP_NORMAL_CONFIDENCE, or SP_HIGH_CONFIDENCE.
		/// See Confidence Scoring and Rejection in SAPI Speech Recognition Engine Guide for additional details.
		/// </summary>
		public SP_CONFIDENCE Confidence;
	}

	/// <summary>
	/// SPPHRASERULE contains the information for a rule in a grammar result. SAPI uses the pFirstChild and pNextSibling pointers to
	/// represent the parse tree. SPPHRASE.Rule is the root node of the parse tree.
	/// </summary>
	[Marshaled(Pack = 8, StringEncoding = StringEncoding.Unicode)]
	public struct SPPHRASERULE_M
	{
		/// <summary>Name of this rule (in Speech Text Grammar Format set using &lt;RULE NAME="MyName"&gt;).</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszName;

		/// <summary>ID of this rule (set using &lt;RULE ID="123"&gt;).</summary>
		public uint ulId;

		/// <summary>The index of the first spoken element (word) of this rule.</summary>
		public uint ulFirstElement;

		/// <summary>Number of spoken elements (words) spanned by this rule.</summary>
		public uint ulCountOfElements;

		/// <summary>Pointer to the next sibling in the parse tree.</summary>
		public ManagedStructPointer<SPPHRASERULE_M> pNextSibling;

		/// <summary>Pointer to the first child node in the parse tree.</summary>
		public ManagedStructPointer<SPPHRASERULE_M> pFirstChild;

		/// <summary>
		/// Confidence for this rule computed by the SR engine. The value is engine dependent and not standardized across multiple SR
		/// engines. See Confidence Scoring and Rejection in SAPI Speech Recognition Engine Guide for additional details.
		/// </summary>
		public float SREngineConfidence;

		/// <summary>
		/// Confidence for this rule computed by SAPI. The value is either SP_LOW_CONFIDENCE, SP_NORMAL_CONFIDENCE, or SP_HIGH_CONFIDENCE.
		/// See Confidence Scoring and Rejection in SAPI Speech Recognition Engine Guide for additional details.
		/// </summary>
		public SP_CONFIDENCE Confidence;
	}

	/// <summary>
	/// SPPROPERTYINFO contains the information for a semantic property.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SPPROPERTYINFO
	{
		/// <summary>Pointer to the null-terminated string that contains the name information of the property. This is set using the PROPNAME attribute in the Speech Text Grammar Format.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszName;

		/// <summary>Identifier associated with the property. This is set using the PROPID attribute in the Speech Text Grammar Format.</summary>
		public uint ulId;

		/// <summary>Pointer to the null-terminated string that contains the value information of the property. This is set using the VALSTR attribute in the Speech Text Grammar Format.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszValue;

		/// <summary>Must be one of the following: VT_BOOL, VT_I4, VT_R4, VT_R8, or VT_BYREF (for dynamic grammars only.) This is set using the VAL attribute in the Speech Text Grammar Format.</summary>
		[MarshalAs(UnmanagedType.Struct)]
		public object vValue;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
	public struct SPRECOCONTEXTSTATUS
	{
		public SPINTERFERENCE eInterference;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
		public string szRequestTypeOfUI;

		public uint dwReserved1;

		public uint dwReserved2;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SPRECOGNIZERSTATUS
	{
		public SPAUDIOSTATUS AudioStatus;

		public ulong ullRecognitionStreamPos;

		public uint ulStreamNumber;

		public uint ulNumActive;

		public Guid ClsidEngine;

		public uint cLangIDs;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public LANGID[] aLangID;

		public ulong ullRecognitionStreamTime;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SPRECORESULTTIMES
	{
		public FILETIME ftStreamTime;

		public ulong ullLength;

		public uint dwTickCount;

		public ulong ullStart;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SPRULE
	{
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszRuleName;

		public uint ulRuleId;

		public SPCFGRULEATTRIBUTES dwAttributes;
	}

	/// <summary>
	/// Represents information about a recognition error.
	/// <para>
	/// SPSEMANTICERRORINFO is used with functions of the ISpXMLRecoResult and ISpPhrase2 interfaces to describe errors that occurred while
	/// generating semantic results(SML).
	/// </para>
	/// </summary>
	[MarshaledAlternative(typeof(SPSEMANTICERRORINFO_M))]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public partial struct SPSEMANTICERRORINFO
	{
		/// <summary>The line number where the error occurred.</summary>
		public uint ulLineNumber;

		/// <summary>The text of the line where the error occurred.</summary>
		public PWSTR pszScriptLine;

		/// <summary>The location of the file in which the error occurred.</summary>
		public PWSTR pszSource;

		/// <summary>A description of the error.</summary>
		public PWSTR pszDescription;

		/// <summary>The code number of the error.</summary>
		public HRESULT hrResultCode;
	}

	/// <summary>
	/// Represents information about a recognition error.
	/// <para>
	/// SPSEMANTICERRORINFO is used with functions of the ISpXMLRecoResult and ISpPhrase2 interfaces to describe errors that occurred while
	/// generating semantic results(SML).
	/// </para>
	/// </summary>
	[Marshaled(Pack = 8, StringEncoding = StringEncoding.Unicode)]
	public struct SPSEMANTICERRORINFO_M
	{
		/// <summary>The line number where the error occurred.</summary>
		public uint ulLineNumber;

		/// <summary>The text of the line where the error occurred.</summary>
		public string pszScriptLine;

		/// <summary>The location of the file in which the error occurred.</summary>
		public string pszSource;

		/// <summary>A description of the error.</summary>
		public string? pszDescription;

		/// <summary>The code number of the error.</summary>
		public HRESULT hrResultCode;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct SPSERIALIZEDPHRASE
	{
		public uint ulSerializedSize;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct SPSERIALIZEDRESULT
	{
		public uint ulSerializedSize;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SPSHORTCUTPAIR
	{
		public unsafe SPSHORTCUTPAIR* pNextSHORTCUTPAIR;

		public LANGID LangId;

		public SPSHORTCUTTYPE shType;

		public PWSTR pszDisplay;

		public PWSTR pszSpoken;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SPSHORTCUTPAIRLIST
	{
		public uint ulSize;

		public IntPtr pvBuffer;

		public unsafe SPSHORTCUTPAIR* pFirstShortcutPair;
	}

	[AutoHandle]
	public partial struct SPSTATEHANDLE { }

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct SPTEXTSELECTIONINFO
	{
		public uint ulStartActiveOffset;

		public uint cchActiveChars;

		public uint ulStartSelection;

		public uint cchSelection;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct SPVOICESTATUS
	{
		public uint ulCurrentStream;

		public uint ulLastStreamQueued;

		public HRESULT hrLastResult;

		public SPRUNSTATE dwRunningState;

		public uint ulInputWordPos;

		public uint ulInputWordLen;

		public uint ulInputSentPos;

		public uint ulInputSentLen;

		public int lBookmarkId;

		public ushort PhonemeId;

		public SPVISEMES VisemeId;

		public uint dwReserved1;

		public uint dwReserved2;
	}

	/// <summary>
	/// This structure contains information about changes to a word in a lexicon, and is used with <c>ISpLexicon</c> to define word changes.
	/// Words are formed into a word list represented by an <c>SPWORDLIST</c> structure. For use of words and word lists, see
	/// <c>ISpLexicon::GetWords</c> and <c>ISpLexicon::GetGenerationChange</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/previous-versions/windows/embedded/ms895959(v=msdn.10)
	[PInvokeData("sapi.h")]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SPWORD
	{
		/// <summary>Pointer to the next <b>SPWORD</b> structure in the list of words ( <b>SPWORDLIST</b>).</summary>
		public unsafe SPWORD* pNextWord;

		/// <summary>Language identifier of the word.</summary>
		public LANGID LangId;

		/// <summary>Reserved for future use.</summary>
		public ushort wReserved;

		/// <summary>
		/// Change state for the word and its pronunciation in the lexicon. Possible values are defined for the <c>SPWORDTYPE</c> enumeration.
		/// </summary>
		public SPWORDTYPE eWordType;

		/// <summary>Pointer to the offset of the word entry.</summary>
		public PWSTR pszWord;

		/// <summary>Pointer to an <c>SPWORDPRONUNCIATION</c> structure containing the first possible pronunciation of the word.</summary>
		public unsafe SPWORDPRONUNCIATION* pFirstWordPronunciation;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SPWORDLIST
	{
		public uint ulSize;

		public IntPtr pvBuffer;

		public unsafe SPWORD* pFirstWord;

		/// <summary>Releases the memory allocated for the structure.</summary>
		public void Dispose() => Marshal.FreeCoTaskMem(pvBuffer);
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Unicode)]
	public struct SPWORDPRONUNCIATION
	{
		public unsafe SPWORDPRONUNCIATION* pNextWordPronunciation;

		public SPLEXICONTYPE eLexiconType;

		public LANGID LangId;

		public SPPRONUNCIATIONFLAGS wPronunciationFlags;

		public SPPARTOFSPEECH ePartOfSpeech;

		public AnySizeStructFieldArray<SPPHONEID> szPronunciation;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SPWORDPRONUNCIATIONLIST
	{
		public uint ulSize;

		public IntPtr pvBuffer;

		public unsafe SPWORDPRONUNCIATION* pFirstWordPronunciation;

		/// <summary>Releases the memory allocated for the structure.</summary>
		public void Dispose() => Marshal.FreeCoTaskMem(pvBuffer);
	}
}