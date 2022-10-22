using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using HKL = System.IntPtr;

namespace Vanara.PInvoke
{
	public static partial class MSCTF
	{
		/// <summary>Indicates to a text service that the client is deactivated. See TfClientId.</summary>
		public const uint TF_CLIENTID_NULL = 0;

		/// <summary/>
		public const uint TF_DEFAULT_SELECTION = unchecked((uint)-1);

		/// <summary>Used to notify TSF, through atom functions, that a thread input process has been enabled.</summary>
		public const string TF_ENABLE_PROCESS_ATOM = "_CTF_ENABLE_PROCESS_ATOM_";

		/// <summary>Not used.</summary>
		public const uint TF_INVALID_COOKIE = unchecked((uint)-1);

		/// <summary>The TfGuidAtom value for the current process is invalid.</summary>
		public const uint TF_INVALID_GUIDATOM = 0;

		/// <summary/>
		public const uint TF_INVALID_UIELEMENTID = unchecked((uint)-1);

		/// <summary>Used to notify atom functions that a thread input process has initiated.</summary>
		public const string TF_PROCESS_ATOM = "_CTF_PROCESS_ATOM_";

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

		/// <summary>
		/// Obtains the function provider implemented by the current application. This object is not available if the application does not
		/// register itself as a function provider.
		/// </summary>
		public static readonly Guid GUID_APP_FUNCTIONPROVIDER = new Guid("4caef01e-12af-4b0e-9db1-a6ec5b881208");

		public static readonly Guid GUID_COMPARTMENT_EMPTYCONTEXT = new Guid("d7487dbf-804e-41c5-894d-ad96fd4eea13");

		public static readonly Guid GUID_COMPARTMENT_HANDWRITING_OPENCLOSE = new Guid("f9ae2c6b-1866-4361-af72-7aa30948890e");

		public static readonly Guid GUID_COMPARTMENT_KEYBOARD_DISABLED = new Guid("71a5b253-1951-466b-9fbc-9c8808fa84f2");

		public static readonly Guid GUID_COMPARTMENT_KEYBOARD_INPUTMODE_CONVERSION = new Guid("ccf05dd8-4a87-11d7-a6e2-00065b84435c");

		public static readonly Guid GUID_COMPARTMENT_KEYBOARD_INPUTMODE_SENTENCE = new Guid("ccf05dd9-4a87-11d7-a6e2-00065b84435c");

		public static readonly Guid GUID_COMPARTMENT_KEYBOARD_OPENCLOSE = new Guid("58273aad-01bb-4164-95c6-755ba0b5162d");

		public static readonly Guid GUID_COMPARTMENT_PERSISTMENUENABLED = new Guid("575f3783-70c8-47c8-ae5d-91a01a1f7592");

		public static readonly Guid GUID_COMPARTMENT_SPEECH_DISABLED = new Guid("56c5c607-0703-4e59-8e52-cbc84e8bbe35");

		public static readonly Guid GUID_COMPARTMENT_SPEECH_GLOBALSTATE = new Guid("2a54fe8e-0d08-460c-a75d-87035ff436c5");

		public static readonly Guid GUID_COMPARTMENT_SPEECH_OPENCLOSE = new Guid("544d6a63-e2e8-4752-bbd1-000960bca083");

		public static readonly Guid GUID_COMPARTMENT_TIPUISTATUS = new Guid("148ca3ec-0366-401c-8d75-ed978d85fbc9");

		public static readonly Guid GUID_COMPARTMENT_TRANSITORYEXTENSION = new Guid("8be347f5-c7a0-11d7-b408-00065b84435c");

		public static readonly Guid GUID_COMPARTMENT_TRANSITORYEXTENSION_DOCUMENTMANAGER = new Guid("8be347f7-c7a0-11d7-b408-00065b84435c");

		public static readonly Guid GUID_COMPARTMENT_TRANSITORYEXTENSION_PARENT = new Guid("8be347f8-c7a0-11d7-b408-00065b84435c");

		public static readonly Guid GUID_INTEGRATIONSTYLE_SEARCHBOX = new Guid("E6D1BD11-82F7-4903-AE21-1A6397CDE2EB");

		public static readonly Guid GUID_MODEBIAS_CHINESE = new Guid("7add26de-4328-489b-83ae-6493750cad5c");

		public static readonly Guid GUID_MODEBIAS_CONVERSATION = new Guid("0f4ec104-1790-443b-95f1-e10f939d6546");

		public static readonly Guid GUID_MODEBIAS_DATETIME = new Guid("f2bdb372-7f61-4039-92ef-1c35599f0222");

		public static readonly Guid GUID_MODEBIAS_FILENAME = new Guid("d7f707fe-44c6-4fca-8e76-86ab50c7931b");

		public static readonly Guid GUID_MODEBIAS_FULLWIDTHALPHANUMERIC = new Guid("81489fb8-b36a-473d-8146-e4a2258b24ae");

		public static readonly Guid GUID_MODEBIAS_FULLWIDTHHANGUL = new Guid("c01ae6c9-45b5-4fd0-9cb1-9f4cebc39fea");

		public static readonly Guid GUID_MODEBIAS_HALFWIDTHALPHANUMERIC = new Guid("c6f24fc0-4479-46ed-938a-6052b1653d3b");

		public static readonly Guid GUID_MODEBIAS_HALFWIDTHKATAKANA = new Guid("005f6b63-78d4-41cc-8859-485ca821a795");

		public static readonly Guid GUID_MODEBIAS_HANGUL = new Guid("76ef0541-23b3-4d77-a074-691801ccea17");

		public static readonly Guid GUID_MODEBIAS_HIRAGANA = new Guid("d73d316e-9b91-46f1-a280-31597f52c694");

		public static readonly Guid GUID_MODEBIAS_KATAKANA = new Guid("2e0eeddd-3a1a-499e-8543-3c7ee7949811");

		public static readonly Guid GUID_MODEBIAS_NAME = new Guid("fddc10f0-d239-49bf-b8fc-5410caaa427e");

		public static readonly Guid GUID_MODEBIAS_NONE = Guid.Empty;

		public static readonly Guid GUID_MODEBIAS_NUMERIC = new Guid("4021766c-e872-48fd-9cee-4ec5c75e16c3");

		public static readonly Guid GUID_MODEBIAS_READING = new Guid("e31643a3-6466-4cbf-8d8b-0bd4d8545461");

		public static readonly Guid GUID_MODEBIAS_URLHISTORY = new Guid("8b0e54d9-63f2-4c68-84d4-79aee7a59f09");

		/// <summary>
		/// Contains a TfGuidAtom value that represents the GUID of the display attribute. ITfCategoryMgr::GetGUID is used to convert this
		/// value into a GUID. For more information, see Using Display Attributes.
		/// </summary>
		[CorrespondingType(typeof(uint))]
		public static readonly Guid GUID_PROP_ATTRIBUTE = new Guid("34b45670-7526-11d2-a147-00105a2799b5");

		/// <summary>
		/// Contains a Boolean value that is nonzero if the text is part of a composition or zero otherwise. If this property is VT_EMPTY,
		/// it can be assumed that the text is not part of a composition.
		/// </summary>
		[CorrespondingType(typeof(bool))]
		public static readonly Guid GUID_PROP_COMPOSING = new Guid("e12ac060-af15-11d2-afc5-00105a2799b5");

		/// <summary>Contains a DWORD value that contains the language identifier ( LANGID ) of the text in the low word.</summary>
		[CorrespondingType(typeof(LANGID))]
		public static readonly Guid GUID_PROP_LANGID = new Guid("3280ce20-8032-11d2-b603-00105a2799b5");

		[CorrespondingType(typeof(LANGID))]
		public static readonly Guid GUID_PROP_LMLATTICE = new(0x8189b801, 0xd62f, 0x400a, 0x8c, 0x12, 0xe2, 0x93, 0x40, 0x96, 0x7b, 0xa8);

		/// <summary>Contains a pointer to an ITfLMLattice object.</summary>
		[CorrespondingType(typeof(ITfLMLattice))]
		public static readonly Guid GUID_PROP_MODEBIAS = new Guid("372e0716-974f-40ac-a088-08cdc92ebfbc");

		/// <summary>
		/// Contains the phonetic reading text for the text covered by the property. This can be different from the actual text. Windows
		/// Store apps don't support this property.
		/// </summary>
		[CorrespondingType(typeof(string))]
		public static readonly Guid GUID_PROP_READING = new Guid("5463f7c0-8e31-11d2-bf46-00105a2799b5");

		/// <summary>
		/// Contains a TfGuidAtom value that represents the class identifier ( CLSID ) of the text service that owns the text.
		/// ITfCategoryMgr::GetGUID is used to convert this value into a CLSID.
		/// </summary>
		[CorrespondingType(typeof(uint))]
		public static readonly Guid GUID_PROP_TEXTOWNER = new Guid("f1e2d520-0969-11d3-8df0-00105a2799b5");

		/// <summary>
		/// Starting with Windows 8: Contains a DWORD value set by the touch keyboard. This property can be used by TSF-aware edit controls
		/// and apps to identify the nature of the text in the text range covered by the property, for example, if the text in the range
		/// results from the insertion of a text suggestion or autocorrection.
		/// <para>
		/// The nature of the text in the text range covered by the property also extends to the type of alternates that would be returned
		/// by the ITfFnReconversion interface for that text range in the document.
		/// </para>
		/// <para>See the following Remarks for the possible values of this property.</para>
		/// </summary>
		[CorrespondingType(typeof(TKB_ALTERNATES))]
		public static readonly Guid GUID_PROP_TKB_ALTERNATES = new Guid("70B2A803-968D-462E-B93B-2164C91517F7");

		/// <summary>Obtains the TSF system function provider.</summary>
		public static readonly Guid GUID_SYSTEM_FUNCTIONPROVIDER = new Guid("9a698bb0-0f21-11d3-8df1-00105a2799b5");

		public static readonly Guid GUID_TFCAT_CATEGORY_OF_TIP = new Guid("534c48c1-0607-4098-a521-4fc899c73e90");

		public static readonly Guid GUID_TFCAT_DISPLAYATTRIBUTEPROPERTY = new Guid("b95f181b-ea4c-4af1-8056-7c321abbb091");

		public static readonly Guid GUID_TFCAT_DISPLAYATTRIBUTEPROVIDER = new Guid("046b8c80-1647-40f7-9b21-b93b81aabc1b");

		public static readonly Guid GUID_TFCAT_PROP_AUDIODATA = new Guid("9b7be3a9-e8ab-4d47-a8fe-254fa423436d");

		public static readonly Guid GUID_TFCAT_PROP_INKDATA = new Guid("7c6a82ae-b0d7-4f14-a745-14f28b009d61");

		public static readonly Guid GUID_TFCAT_PROPSTYLE_CUSTOM = new Guid("25504FB4-7BAB-4BC1-9C69-CF81890F0EF5");

		public static readonly Guid GUID_TFCAT_PROPSTYLE_STATIC = new Guid("565fb8d8-6bd4-4ca1-b223-0f2ccb8f4f96");

		public static readonly Guid GUID_TFCAT_PROPSTYLE_STATICCOMPACT = new Guid("85f9794b-4d19-40d8-8864-4e747371a66d");

		public static readonly Guid GUID_TFCAT_TIP_HANDWRITING = new Guid("246ecb87-c2f2-4abe-905b-c8b38add2c43");

		public static readonly Guid GUID_TFCAT_TIP_KEYBOARD = new Guid("34745c63-b2f0-4784-8b67-5e12c8701a31");

		public static readonly Guid GUID_TFCAT_TIP_SPEECH = new Guid("b5a73cd1-8355-426b-a161-259808f26b14");

		public static readonly Guid GUID_TFCAT_TIPCAP_COMLESS = new Guid("364215d9-75bc-11d7-a6ef-00065b84435c");

		public static readonly Guid GUID_TFCAT_TIPCAP_IMMERSIVESUPPORT = new Guid("13A016DF-560B-46CD-947A-4C3AF1E0E35D");

		public static readonly Guid GUID_TFCAT_TIPCAP_INPUTMODECOMPARTMENT = new Guid("ccf05dd7-4a87-11d7-a6e2-00065b84435c");

		public static readonly Guid GUID_TFCAT_TIPCAP_SECUREMODE = new Guid("49d2f9ce-1f5e-11d7-a6d3-00065b84435c");

		public static readonly Guid GUID_TFCAT_TIPCAP_SYSTRAYSUPPORT = new Guid("13A016DF-560B-46CD-947A-4C3AF1E0E35D");

		public static readonly Guid GUID_TFCAT_TIPCAP_UIELEMENTENABLED = new Guid("49d2f9cf-1f5e-11d7-a6d3-00065b84435c");

		public static readonly Guid GUID_TFCAT_TIPCAP_WOW16 = new Guid("364215da-75bc-11d7-a6ef-00065b84435c");
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

		/// <summary>
		/// <para>
		/// The Text Services Framework produces return values in the range from 0xHHHH0200 through 0xHHHH0507. The following table gives
		/// the manager return values in alphabetical order.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The descriptions supplied are non-specific; the meaning of a return value can vary depending on the method that returned the value.
		/// </para>
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/manager-return-values
		[PInvokeData("msctf.h")]
		public enum ManagerReturnValues : int
		{
			/// <summary>The preserved key is registered.</summary>
			TF_E_ALREADY_EXISTS = unchecked((int)0x80040506),

			/// <summary>The context owner rejected the composition.</summary>
			TF_E_COMPOSITION_REJECTED = unchecked((int)0x80040508),

			/// <summary>The context object is not on a document stack.</summary>
			TF_E_DISCONNECTED = unchecked((int)0x80040504),

			/// <summary>The context is empty.</summary>
			TF_E_EMPTYCONTEXT = unchecked((int)0x80040509),

			/// <summary>Context owner cannot handle objects of the type provided by the pDataObject parameter.</summary>
			TF_E_FORMAT = unchecked((int)0x8004020a),

			/// <summary>The screen coordinates are invalid.</summary>
			TF_E_INVALIDPOINT = unchecked((int)0x80040207),

			/// <summary>The character position is invalid.</summary>
			TF_E_INVALIDPOS = unchecked((int)0x80040200),

			/// <summary>The context view is invalid.</summary>
			TF_E_INVALIDVIEW = unchecked((int)0x80040505),

			/// <summary>The context is already locked.</summary>
			TF_E_LOCKED = unchecked((int)0x80040500),

			/// <summary>The object does not support the requested interface.</summary>
			TF_E_NOINTERFACE = unchecked((int)0x80040204),

			/// <summary>The text layout has not been calculated.</summary>
			TF_E_NOLAYOUT = unchecked((int)0x80040206),

			/// <summary>The caller does not have the necessary type of document.</summary>
			TF_E_NOLOCK = unchecked((int)0x80040201),

			/// <summary>No embedded object exists at the specified position.</summary>
			TF_E_NOOBJECT = unchecked((int)0x80040202),

			/// <summary>No function provider exists for the specified function.</summary>
			TF_E_NOPROVIDER = unchecked((int)0x80040503),

			/// <summary>No selection exists within the context.</summary>
			TF_E_NOSELECTION = unchecked((int)0x80040205),

			/// <summary>The specified service does not exists or cannot be created.</summary>
			TF_E_NOSERVICE = unchecked((int)0x80040203),

			/// <summary>The TSF manager does not own the range.</summary>
			TF_E_NOTOWNEDRANGE = unchecked((int)0x80040502),

			/// <summary>The range is not within an active composition.</summary>
			TF_E_RANGE_NOT_COVERED = unchecked((int)0x80040507),

			/// <summary>The edit context is read-only.</summary>
			TF_E_READONLY = unchecked((int)0x80040209),

			/// <summary>The context stack is full.</summary>
			TF_E_STACKFULL = unchecked((int)0x80040501),

			/// <summary>A synchronous read-only lock cannot be obtained.</summary>
			TF_E_SYNCHRONOUS = unchecked((int)0x80040208),

			/// <summary>The data will be obtained asynchronously.</summary>
			TF_S_ASYNC = unchecked(0x00040300),
		}

		/// <summary>Flags for GetUpdatedFlags.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_CLUIE
		{
			/// <summary>The target document manager was changed.</summary>
			TF_CLUIE_DOCUMENTMGR = 0x00000001,

			/// <summary>The count of the candidate string was changed.</summary>
			TF_CLUIE_COUNT = 0x00000002,

			/// <summary>The selection of the candidate was changed.</summary>
			TF_CLUIE_SELECTION = 0x00000004,

			/// <summary>Some strings in the list were changed.</summary>
			TF_CLUIE_STRING = 0x00000008,

			/// <summary>The current page index or some page index was changed.</summary>
			TF_CLUIE_PAGEINDEX = 0x00000010,

			/// <summary>The page was changed.</summary>
			TF_CLUIE_CURRENTPAGE = 0x00000020,
		}

		/// <summary>
		/// The following flags are used as a value of GUID_COMPARTMENT_KEYBOARD_INPUTMODE_CONVERSION. This is equivalent with IME_CMODE
		/// values for IMM32.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/flags-for-conversion-mode
		[PInvokeData("ctffunc.h")]
		[Flags]
		public enum TF_CONVERSIONMODE : uint
		{
			/// <summary>Set to 1 if ALPHANUMERIC mode.</summary>
			TF_CONVERSIONMODE_ALPHANUMERIC = 0x0000,

			/// <summary>Set to 1 if NATIVE mode; 0 if ALPHANUMERIC mode.</summary>
			TF_CONVERSIONMODE_NATIVE = 0x0001,

			/// <summary>Set to 1 if KATAKANA mode; 0 if HIRAGANA mode.</summary>
			TF_CONVERSIONMODE_KATAKANA = 0x0002,

			/// <summary>Set to 1 if full shape mode; 0 if half shape mode.</summary>
			TF_CONVERSIONMODE_FULLSHAPE = 0x0008,

			/// <summary>Set to 1 to prevent processing of conversions by IME; 0 if not.</summary>
			TF_CONVERSIONMODE_ROMAN = 0x0010,

			/// <summary>Set to 1 if character code input mode; 0 if not.</summary>
			TF_CONVERSIONMODE_CHARCODE = 0x0020,

			/// <summary>Set to 1 if Soft Keyboard mode; 0 if not.</summary>
			TF_CONVERSIONMODE_SOFTKEYBOARD = 0x0080,

			/// <summary>Set to 1 to prevent processing of conversions by IME; 0 if not.</summary>
			TF_CONVERSIONMODE_NOCONVERSION = 0x0100,

			/// <summary>Set to 1 if SYMBOL conversion mode; 0 if not.</summary>
			TF_CONVERSIONMODE_SYMBOL = 0x0400,

			/// <summary>Set to 1 if fixed conversion mode; 0 if not.</summary>
			TF_CONVERSIONMODE_FIXED = 0x0800,
		}

		/// <summary>
		/// Elements of the <c>TF_DA_ATTR_INFO</c> enumeration are used to specify text conversion data in the TF_DISPLAYATTRIBUTE structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ne-msctf-tf_da_attr_info
		[PInvokeData("msctf.h", MSDNShortId = "NE:msctf.__MIDL___MIDL_itf_msctf_0000_0070_0004")]
		[Guid("33D2FE4B-6C24-4F67-8D75-3BC1819E4126")]
		public enum TF_DA_ATTR_INFO
		{
			/// <summary>The text is entered by the user and has not been converted yet.</summary>
			TF_ATTR_INPUT,

			/// <summary>The user has made a character selection and the text has been converted yet.</summary>
			TF_ATTR_TARGET_CONVERTED,

			/// <summary>The text is converted.</summary>
			TF_ATTR_CONVERTED,

			/// <summary>The user made a character selection, but the text is not converted yet.</summary>
			TF_ATTR_TARGET_NOTCONVERTED,

			/// <summary>The text is an error character and cannot be converted. For example, some consonants cannot be put together.</summary>
			TF_ATTR_INPUT_ERROR,

			/// <summary>The text is not converted. Theses characters will no longer be converted.</summary>
			TF_ATTR_FIXEDCONVERTED,

			/// <summary>Reserved for the system.</summary>
			TF_ATTR_OTHER = -1,
		}

		/// <summary>
		/// Elements of the <c>TF_DA_COLORTYPE</c> enumeration specify the format of the color contained in the TF_DA_COLOR structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ne-msctf-tf_da_colortype
		[PInvokeData("msctf.h", MSDNShortId = "NE:msctf.__MIDL___MIDL_itf_msctf_0000_0070_0002")]
		[Guid("D9B92E21-084A-401B-9C64-1E6DAD91A1AB")]
		public enum TF_DA_COLORTYPE
		{
			/// <summary>The structure contains no color data.</summary>
			TF_CT_NONE,

			/// <summary>The color is specified as a system color index. For more information about the system color indexes, see GetSysColor.</summary>
			TF_CT_SYSCOLOR,

			/// <summary>The color is specified as an RGB value.</summary>
			TF_CT_COLORREF,
		}

		/// <summary>
		/// Elements of the <c>TF_DA_LINESTYLE</c> enumeration specify the underline style of a display attribute in the TF_DA_COLOR structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ne-msctf-tf_da_linestyle
		[PInvokeData("msctf.h", MSDNShortId = "NE:msctf.__MIDL___MIDL_itf_msctf_0000_0070_0001")]
		[Guid("C4CC07F1-80CC-4A7B-BC54-98512782CBE3")]
		public enum TF_DA_LINESTYLE
		{
			/// <summary>The text is not underlined.</summary>
			TF_LS_NONE,

			/// <summary>The text is underlined with a solid line.</summary>
			TF_LS_SOLID,

			/// <summary>The text is underlined with a dotted line.</summary>
			TF_LS_DOT,

			/// <summary>The text is underlined with a dashed line.</summary>
			TF_LS_DASH,

			/// <summary>The text is underlined with a solid wavy line.</summary>
			TF_LS_SQUIGGLE,
		}

		/// <summary>Speech recognition text service flags.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_DISABLE
		{
			/// <summary>
			/// If this bit is 1, speech input is disabled. Otherwise, speech input is enabled. Used with the
			/// GUID_COMPARTMENT_SPEECH_DISABLED compartment.
			/// </summary>
			TF_DISABLE_SPEECH = 0x00000001,

			/// <summary>
			/// If this bit is 1, speech dictation is disabled. Otherwise, speech dictation is enabled. Used with the
			/// GUID_COMPARTMENT_SPEECH_DISABLED compartment.
			/// </summary>
			TF_DISABLE_DICTATION = 0x00000002,

			/// <summary>
			/// If this bit is 1, speech command is disabled. Otherwise, speech command is enabled. Used with the
			/// GUID_COMPARTMENT_SPEECH_DISABLED compartment.
			/// </summary>
			TF_DISABLE_COMMANDING = 0x00000004,
		}

		/// <summary>The following are constants used by the ITfContext::RequestEditSession method.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/tf-es--constants
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_ES : uint
		{
			/// <summary>
			/// The edit session can occur synchronously or asynchronously, at the discretion of the manager. The manager will attempt to
			/// schedule a synchronous edit session for improved performance. This value cannot be combined with the TF_ES_ASYNC or
			/// TF_ES_SYNC values.
			/// </summary>
			TF_ES_ASYNCDONTCARE = 0x0,

			/// <summary>
			/// The edit session must be synchronous or the request will fail (with TF_E_SYNCHRONOUS). This flag should only be used in
			/// documented situations (such as keystroke handling) where it can be expected to succeed. Otherwise the call will likely fail.
			/// This value cannot be combined with the TF_ES_ASYNCDONTCARE or TF_ES_ASYNC values.
			/// </summary>
			TF_ES_SYNC = 0x1,

			/// <summary>Requests read-only access to the context.</summary>
			TF_ES_READ = 0x2,

			/// <summary>Requests write-only access to the context.</summary>
			TF_ES_WRITE = 0x4,

			/// <summary>Requests read/write access to the context.</summary>
			TF_ES_READWRITE = TF_ES_READ | TF_ES_WRITE,

			/// <summary>
			/// The edit session must be asynchronous or the request will fail. This value cannot be combined with the TF_ES_ASYNCDONTCARE
			/// or TF_ES_SYNC values.
			/// </summary>
			TF_ES_ASYNC = 0x8
		}

		/// <summary>Miscellaneous framework constants indicate settings for clients, processes, or text.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_GTP : uint
		{
			/// <summary>
			/// Specifies that the ITfEditRecord::GetTextAndPropertyUpdates method will obtain the collection of range objects that cover
			/// the text changed during the edit session.
			/// </summary>
			TF_GTP_INCL_TEXT = 1,
		}

		/// <summary>Miscellaneous framework constants indicate settings for clients, processes, or text.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_HF : uint
		{
			/// <summary>The range shift stops if an embedded object is encountered. Used in dwFlags member of TF_HALTCOND structure.</summary>
			TF_HF_OBJECT = 1,
		}

		/// <summary>
		/// Specifies whether the pacpStart and pacpEnd parameters and the TS_TEXTCHANGE structure contain the results of the text insertion.
		/// </summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_IAS : uint
		{
			/// <summary>
			/// Text insertion will occur, and the pacpStart and pacpEnd parameters will contain the results of the text insertion. The
			/// TS_TEXTCHANGE structure must be filled with this flag.
			/// </summary>
			TF_IAS_NONE = 0,

			/// <summary>
			/// Text is inserted, the values of the pacpStart and pacpEnd parameters can be NULL, and the TS_TEXTCHANGE structure must be
			/// filled. Use this flag to view the results of the text insertion.
			/// </summary>
			TF_IAS_NOQUERY = 0x1,

			/// <summary>
			/// Text is not inserted, and the values for the pacpStart and pacpEnd parameters contain the results of the text insertion. The
			/// values of these parameters depend on how the application implements text insertion into a document. For more information,
			/// see the Remarks section. Use this flag to view the results of the text insertion without actually inserting the text. It is
			/// not required that you fill the TS_TEXTCHANGE structure if you use this flag.
			/// </summary>
			TF_IAS_QUERYONLY = 0x2,

			/// <summary>Caller takes responsibility for starting a composition over the range</summary>
			TF_IAS_NO_DEFAULT_COMPOSITION = 0x80000000,
		}

		/// <summary>Miscellaneous framework constants indicate settings for clients, processes, or text.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_IE : uint
		{
			/// <summary>
			/// The text is a transform (correction) of existing content, so that other text services can preserve data associated with the
			/// original text. Used in dwFlags parameter of ITfRange::InsertEmbedded.
			/// </summary>
			TF_IE_CORRECTION = 1,
		}

		/// <summary>The flag to specify the capability of text service.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ns-msctf-tf_inputprocessorprofile
		[PInvokeData("msctf.h", MSDNShortId = "NS:msctf.TF_INPUTPROCESSORPROFILE")]
		[Flags]
		public enum TF_IPP_CAPS : uint
		{
			/// <summary>This text service profile is disabled on transitory context.</summary>
			TF_IPP_CAPS_DISABLEONTRANSITORY = 0x00000001,

			/// <summary>This text service supports the secure mode. This is categorized in GUID_TFCAT_TIPCAP_SECUREMODE.</summary>
			TF_IPP_CAPS_SECUREMODESUPPORT = 0x00000002,

			/// <summary>This text service supports the UIElement. This is categorized in GUID_TFCAT_TIPCAP_UIELEMENTENABLED.</summary>
			TF_IPP_CAPS_UIELEMENTENABLED = 0x00000004,

			/// <summary>This text service can be activated without COM. This is categorized in GUID_TFCAT_TIPCAP_COMLESS.</summary>
			TF_IPP_CAPS_COMLESSSUPPORT = 0x00000008,

			/// <summary>This text service can be activated on 16bit task. This is categorized in GUID_TFCAT_TIPCAP_WOW16.</summary>
			TF_IPP_CAPS_WOW16SUPPORT = 0x00000010,

			/// <summary>Starting with Windows 8: This text service has been tested to run properly in a Windows Store app.</summary>
			TF_IPP_CAPS_IMMERSIVESUPPORT = 0x00010000,

			/// <summary>
			/// Starting with Windows 8: This text service supports inclusion in the System Tray. This is used for text services that do not
			/// set the TF_IPP_CAPS_IMMERSIVESUPPORT flag but are still compatible with the System Tray.
			/// </summary>
			TF_IPP_CAPS_SYSTRAYSUPPORT = 0x00020000,
		}

		/// <summary>The flag for this profile.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_IPP_FLAG : uint
		{
			/// <summary>This profile is now active.</summary>
			TF_IPP_FLAG_ACTIVE = 0x00000001,

			/// <summary>This profile is enabled.</summary>
			TF_IPP_FLAG_ENABLED = 0x00000002,

			/// <summary>This profile is substituted by a text service.</summary>
			TF_IPP_FLAG_SUBSTITUTEDBYINPUTPROCESSOR = 0x00000004,
		}

		/// <summary/>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_IPPMF : uint
		{
			/// <summary>Activate this profile for all threads in the process.</summary>
			TF_IPPMF_FORPROCESS = 0x10000000,

			/// <summary>Activate this profile for all threads in the current desktop.</summary>
			TF_IPPMF_FORSESSION = 0x20000000,

			/// <summary/>
			TF_IPPMF_FORSYSTEMALL = 0x40000000,

			/// <summary>Update the registry to enable this profile for this user.</summary>
			TF_IPPMF_ENABLEPROFILE = 0x00000001,

			/// <summary/>
			TF_IPPMF_DISABLEPROFILE = 0x00000002,

			/// <summary>
			/// If the current input language does not match with the requested profile's language, TSF marks this profile to be activated
			/// when the requested input language is switched. If this flag is off and the current input language is not matched, this
			/// method fails.
			/// </summary>
			TF_IPPMF_DONTCARECURRENTINPUTLANGUAGE = 0x00000004,
		}

		/// <summary>Flags for ITfInputProcessorProfileActivationSink::OnActivated.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_IPSINK_FLAG : uint
		{
			/// <summary>This is on if this profile is activated.</summary>
			TF_IPSINK_FLAG_ACTIVE = 0x0001,
		}

		/// <summary>The TF_MOD_* constants specify key modifiers in the TF_PRESERVEDKEY structure.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/tf-mod--constants
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_MOD : uint
		{
			/// <summary>Either of the ALT keys is pressed</summary>
			TF_MOD_ALT = 0x0001,

			/// <summary>Either of the CTRL keys is pressed</summary>
			TF_MOD_CONTROL = 0x0002,

			/// <summary>Either of the SHIFT keys is pressed</summary>
			TF_MOD_SHIFT = 0x0004,

			/// <summary>The right ALT key is pressed</summary>
			TF_MOD_RALT = 0x0008,

			/// <summary>The right CTRL key is pressed</summary>
			TF_MOD_RCONTROL = 0x0010,

			/// <summary>The right SHIFT key is pressed</summary>
			TF_MOD_RSHIFT = 0x0020,

			/// <summary>The left ALT key is pressed</summary>
			TF_MOD_LALT = 0x0040,

			/// <summary>The left CTRL key is pressed</summary>
			TF_MOD_LCONTROL = 0x0080,

			/// <summary>The left SHIFT key is pressed</summary>
			TF_MOD_LSHIFT = 0x0100,

			/// <summary>The event will be fired when the key is released. Without this flag, the event is fired when the key is pressed.</summary>
			TF_MOD_ON_KEYUP = 0x0200,

			/// <summary>
			/// The state of the ALT, CTRL, and SHIFT keys is ignored. This means the event will be fired when the virtual key is pressed,
			/// regardless of which modifier keys are pressed.
			/// </summary>
			TF_MOD_IGNORE_ALL_MODIFIER = 0x0400,
		}

		/// <summary>Flags for <see cref="ITfDocumentMgr.Pop"/>.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/nf-msctf-itfdocumentmgr-pop
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_POPF : uint
		{
			/// <summary>All of the contexts are removed from the stack.</summary>
			TF_POPF_ALL = 0x1
		}

		/// <summary>Used by TF_INPUTPROCESSORPROFILE.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_PROFILETYPE : uint
		{
			/// <summary>This is a text service.</summary>
			TF_PROFILETYPE_INPUTPROCESSOR = 0x0001,

			/// <summary>This is a keyboard layout.</summary>
			TF_PROFILETYPE_KEYBOARDLAYOUT = 0x0002,
		}

		/// <summary>Used by ITfReverseConversionMgr::GetReverseConversion.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_RCM : uint
		{
			/// <summary>Activate the reverse conversion interface without COM.</summary>
			TF_RCM_COMLESS = 0x00000001,

			/// <summary>The output should be an array of virtual key codes (instead of chracter key codes).</summary>
			TF_RCM_VKEY = 0x00000002,

			/// <summary>
			/// The reverse conversion should prioritize the order of entries in the output list based on the length of input sequence, with
			/// the shortest sequences first. It is possible that an input sequence with a low collision count might be much higher than an
			/// input sequence with a similar (but slightly higher) collision count. The interpretation of this flag varies depending on the IME.
			/// </summary>
			TF_RCM_HINT_READING_LENGTH = 0x00000004,

			/// <summary>
			/// The reverse conversion should prioritize the order of entries in the output list based on the collision count, with the
			/// entries containing the lowest number of collisions first. If an input sequence corresponds to many more characters than a
			/// slightly longer input sequence, it might be preferable to use the longer input sequence instead. The IME determines whether
			/// this flag will affect the reverse conversion output.
			/// </summary>
			TF_RCM_HINT_COLLISION = 0x00000008,
		}

		/// <summary>Used by ITfInputProcessorProfileMgr::ReleaseInputProcessor.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_RIP_FLAG : uint
		{
			/// <summary>
			/// If this bit is on, this method calls CoFreeUnusedLibrariesEx() so the text services DLL might be freed if it does not have
			/// any more COM/DLL reference. Warning: This flag could cause some other unrelated COM/DLL free.
			/// </summary>
			TF_RIP_FLAG_FREEUNUSEDLIBRARIES = 0x00000001,
		}

		/// <summary>Used by ITfReadingInformationUIElement::GetUpdatedFlags</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_RIUIE : uint
		{
			/// <summary>The target ITfContext was changed.</summary>
			TF_RIUIE_CONTEXT = 0x00000001,

			/// <summary>The reading information string was changed.</summary>
			TF_RIUIE_STRING = 0x00000002,

			/// <summary>The max length of the reading information string was changed.</summary>
			TF_RIUIE_MAXREADINGSTRINGLENGTH = 0x00000004,

			/// <summary>The error index of the reading information string was changed.</summary>
			TF_RIUIE_ERRORINDEX = 0x00000008,

			/// <summary>The vertical order preference was changed.</summary>
			TF_RIUIE_VERTICALORDER = 0x00000010,
		}

		/// <summary>Used by ITfInputProcessorProfileMgr::RegisterProfile.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_RP : uint
		{
			/// <summary>This profile will not appear in the setting UI.</summary>
			TF_RP_HIDDENINSETTINGUI = 0x00000002,

			/// <summary>This profile is available only on the local process.</summary>
			TF_RP_LOCALPROCESS = 0x00000004,

			/// <summary>This profile is available only on the local thread.</summary>
			TF_RP_LOCALTHREAD = 0x00000008,

			/// <summary/>
			TF_RP_SUBITEMINSETTINGUI = 0x00000010,
		}

		/// <summary>
		/// The following values are used as a value of GUID_COMPARTMENT_KEYBOARD_INPUTMODE_SENTENCE. This is equivalent with IME_SMODE
		/// values for IMM32.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/flags-for-conversion-mode
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_SENTENCEMODE : uint
		{
			/// <summary>No information for sentence.</summary>
			TF_SENTENCEMODE_NONE = 0x0000,

			/// <summary>The IME uses plural clause information to carry out conversion processing.</summary>
			TF_SENTENCEMODE_PLAURALCLAUSE = 0x0001,

			/// <summary>The IME carries out conversion processing in single-character mode.</summary>
			TF_SENTENCEMODE_SINGLECONVERT = 0x0002,

			/// <summary>The IME carries out conversion processing in automatic mode.</summary>
			TF_SENTENCEMODE_AUTOMATIC = 0x0004,

			/// <summary>The IME uses phrase information to predict the next character.</summary>
			TF_SENTENCEMODE_PHRASEPREDICT = 0x0008,

			/// <summary>The IME uses conversation mode. This is useful for chat applications.</summary>
			TF_SENTENCEMODE_CONVERSATION = 0x0010,
		}

		/// <summary>Used in dwFlags parameter of ITfRange::SetText.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_ST : uint
		{
			/// <summary>
			/// The text is a transform (correction) of existing content, so that other text services can preserve data associated with the
			/// original text. Used in dwFlags parameter of ITfRange::SetText.
			/// </summary>
			TF_ST_CORRECTION = 1,
		}

		/// <summary>The <c>TF_TF_*</c> constants are used to specify options with the ITfRange::GetText method.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/tf-tf--constants
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_TF : uint
		{
			/// <summary>Update start anchor.</summary>
			TF_TF_MOVESTART = 1,

			/// <summary>Ignore end anchor.</summary>
			TF_TF_IGNOREEND = 2,
		}

		/// <summary>Flags for ITfThreadMgr2::ActivateEx and ITfTextInputProcessorEx::ActivateEx.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_TMAE : uint
		{
			/// <summary>
			/// Text services will not be activated while this method is called. They will be activated when the calling thread has focus asynchronously.
			/// </summary>
			TF_TMAE_NOACTIVATETIP = 0x00000001,

			/// <summary>TSF is activated in secure mode. Only text services that support the secure mode will be activated.</summary>
			TF_TMAE_SECUREMODE = 0x00000002,

			/// <summary>TSF activates only text services that are categorized in GUID_TFCAT_TIPCAP_UIELEMENTENABLED.</summary>
			TF_TMAE_UIELEMENTENABLEDONLY = 0x00000004,

			/// <summary>TSF does not use COM. TSF activate only text services that are categorized in GUID_TFCAT_TIPCAP_COMLESS.</summary>
			TF_TMAE_COMLESS = 0x00000008,

			/// <summary>The current thread is 16 bit task.</summary>
			TF_TMAE_WOW16 = 0x00000010,

			/// <summary>
			/// TSF does not sync the current keyboard layout while this method is called. The keyboard layout will be adjusted when the
			/// calling thread gets focus. This flag must be used with TF_TMAE_NOACTIVATETIP.
			/// </summary>
			TF_TMAE_NOACTIVATEKEYBOARDLAYOUT = 0x00000020,

			/// <summary>A text service is activated for console usage.</summary>
			TF_TMAE_CONSOLE = 0x00000040,
		}

		/// <summary>Flags for ITfThreadMgr2::GetActiveFlags.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_TMF : uint
		{
			/// <summary>TSF was activated with the TF_TMAE_NOACTIVATETIP flag.</summary>
			TF_TMF_NOACTIVATETIP = TF_TMAE.TF_TMAE_NOACTIVATETIP,

			/// <summary>TSF is running in secure mode.</summary>
			TF_TMF_SECUREMODE = TF_TMAE.TF_TMAE_SECUREMODE,

			/// <summary>TSF is running with text services that support only UIElement.</summary>
			TF_TMF_UIELEMENTENABLEDONLY = TF_TMAE.TF_TMAE_UIELEMENTENABLEDONLY,

			/// <summary>TSF is running without COM.</summary>
			TF_TMF_COMLESS = TF_TMAE.TF_TMAE_COMLESS,

			/// <summary>TSF is running in 16 bit task.</summary>
			TF_TMF_WOW16 = TF_TMAE.TF_TMAE_WOW16,

			/// <summary>TSF is running for console usage.</summary>
			TF_TMF_CONSOLE = TF_TMAE.TF_TMAE_CONSOLE,

			/// <summary>TSF is active in a Windows Store app.</summary>
			TF_TMF_IMMERSIVEMODE = 0x40000000,

			/// <summary>TSF is active.</summary>
			TF_TMF_ACTIVATED = 0x80000000,
		}

		/// <summary>
		/// The following values of the GUID_COMPARTMENT_TRANSITORYEXTENSION compartment are used to control the behavior of transitory extension.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/values-for-guid-compartment-transitoryextension
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_TRANSITORYEXTENSION : uint
		{
			/// <summary>This value stops the transitory extension.</summary>
			TF_TRANSITORYEXTENSION_NONE = 0x0000,

			/// <summary>This value starts the transitory extension with the floating UI.</summary>
			TF_TRANSITORYEXTENSION_FLOATING = 0x0001,

			/// <summary>
			/// This value starts the transitory extension with the popup UI at the IP or the selection of the parent document manager.
			/// </summary>
			TF_TRANSITORYEXTENSION_ATSELECTION = 0x0002,
		}

		/// <summary>Used in dwFlags parameter of ITfPropertyStore::OnTextUpdated.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_TU : uint
		{
			/// <summary>
			/// The text change is the result of a transform (correction) of existing content. This implies that the semantics of the text
			/// have not changed.
			/// </summary>
			TF_TU_CORRECTION = 0x1,
		}

		/// <summary>Flags used by ITfInputProcessorProfileMgr::UnregisterProfile.</summary>
		[PInvokeData("msctf.h")]
		[Flags]
		public enum TF_URP : uint
		{
			/// <summary>
			/// If this bit is on, UnregistrProfile unregisters all profiles of the rclsid parameter. The langid and guidProfile parameters
			/// are ignored.
			/// </summary>
			TF_URP_ALLPROFILES = 0x00000002,

			/// <summary>The profile was registered on the local process.</summary>
			TF_URP_LOCALPROCESS = 0x00000004,

			/// <summary>The profile was registered on the local thread.</summary>
			TF_URP_LOCALTHREAD = 0x00000008,
		}

		/// <summary>Elements of the <c>TfActiveSelEnd</c> enumeration specify which end of a selected range of text is active.</summary>
		/// <remarks>
		/// <para>
		/// The active end of a selected range is the end likely to respond to user actions. For example, in many applications, holding the
		/// SHIFT key down while using the arrow keys will change the selected range. The end of the selected range that moves is the active
		/// end of the selected range.
		/// </para>
		/// <para>This enumeration is used in the TF_SELECTIONSTYLE structure.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ne-msctf-tfactiveselend
		[PInvokeData("msctf.h", MSDNShortId = "NE:msctf.__MIDL_ITfContext_0001")]
		[Guid("1690BE9B-D3E9-49F6-8D8B-51B905AF4C43")]
		public enum TfActiveSelEnd : uint
		{
			/// <summary>The selected range has no active end. This is typical for selected ranges other than the default selected range.</summary>
			TF_AE_NONE,

			/// <summary>The active end is at the start of the selected range.</summary>
			TF_AE_START,

			/// <summary>The active end is at the end of the selected range.</summary>
			TF_AE_END,
		}

		/// <summary>Elements of the <c>TfAnchor</c> enumeration specify the start anchor or end anchor of an ITfRange object.</summary>
		/// <remarks>A range refers to a span of text in a document. Each range is delimited by a start anchor and an end anchor.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ne-msctf-tfanchor
		[PInvokeData("msctf.h", MSDNShortId = "NE:msctf.__MIDL___MIDL_itf_msctf_0000_0000_0001")]
		[Guid("5A886226-AE9A-489B-B991-2B1E25EE59A9")]
		public enum TfAnchor : uint
		{
			/// <summary>Specifies the start anchor of the ITfRange object.</summary>
			TF_ANCHOR_START,

			/// <summary>Specifies the end anchor of the ITfRange object.</summary>
			TF_ANCHOR_END,
		}

		/// <summary>
		/// Elements of the <c>TfGravity</c> enumeration specify the type of gravity associated with the anchor of an ITfRange object.
		/// </summary>
		/// <remarks>For more information about anchor gravity, see Anchor Gravity.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ne-msctf-tfgravity
		[PInvokeData("msctf.h", MSDNShortId = "NE:msctf.__MIDL_ITfRange_0001")]
		[Guid("CF610F06-2882-46F6-ABE5-298568B664C4")]
		public enum TfGravity : uint
		{
			/// <summary>The anchor has backward gravity.</summary>
			TF_GRAVITY_BACKWARD,

			/// <summary>The anchor has forward gravity.</summary>
			TF_GRAVITY_FORWARD,
		}

		/// <summary>
		/// Elements of the <c>TfLayoutCode</c> enumeration specify the type of layout change in an ITfTextLayoutSink::OnLayoutChange notification.
		/// </summary>
		/// <remarks>
		/// In TSF, a view is on-screen rendering of document content. These constants are assigned to parameters of methods of the
		/// <c>ITf*</c> interfaces, but not those of the <c>IText*</c> interfaces.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ne-msctf-tflayoutcode
		[PInvokeData("msctf.h", MSDNShortId = "NE:msctf.__MIDL_ITfTextLayoutSink_0001")]
		[Guid("603553CF-9EDD-4CC1-9ECC-069E4A427734")]
		public enum TfLayoutCode : uint
		{
			/// <summary>The view has just been created.</summary>
			TF_LC_CREATE,

			/// <summary>The view layout has changed.</summary>
			TF_LC_CHANGE,

			/// <summary>The view is about to be destroyed.</summary>
			TF_LC_DESTROY,
		}

		/// <summary>Elements of the <c>TfShiftDir</c> enumeration specify which direction a range anchor is moved.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ne-msctf-tfshiftdir
		[PInvokeData("msctf.h", MSDNShortId = "NE:msctf.__MIDL_ITfRange_0002")]
		[Guid("1E512533-BBDC-4530-9A8E-A1DC0AF67468")]
		public enum TfShiftDir : uint
		{
			/// <summary>Specifies that the anchor will be moved to the region immediately preceding the range.</summary>
			TF_SD_BACKWARD,

			/// <summary>Specifies that the anchor will be moved to the region immediately following the range.</summary>
			TF_SD_FORWARD,
		}

		/// <summary>The following values identify TSF-defined properties. The data format and contents of each property type are included.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/predefined-properties
		[PInvokeData("msctf.h")]
		public enum TKB_ALTERNATES : uint
		{
			/// <summary>
			/// Indicates that the touch keyboard has generated a list of possible alternate words for the text in the range covered by the
			/// property, and that neither the text range nor the alternates are an autocorrection or a text suggestion.
			/// </summary>
			TKB_ALTERNATES_STANDARD = 0x00000001,

			/// <summary>
			/// Indicates that the touch keyboard has generated an alternate word which should automatically replace the text in the text
			/// range covered by the property.
			/// <para>
			/// The touch keyboard will not apply the autocorrection without being instructed to do so by the edit control or app. The
			/// reconversion interface (ITfFnReconversion) should be used to apply the correction to the text in the document.
			/// </para>
			/// </summary>
			TKB_ALTERNATES_FOR_AUTOCORRECTION = 0x00000002,

			/// <summary>
			/// Indicates that the text range covered by the property is a text suggestion that has been generated by the touch keyboard and
			/// inserted into the document by the user.
			/// <para>Additional alternate predictions can also be stored as a property in the document.</para>
			/// </summary>
			TKB_ALTERNATES_FOR_PREDICTION = 0x00000003,

			/// <summary>
			/// Indicates that the text range covered by the property is an autocorrection provided by the touch keyboard and applied via
			/// the ITfFnReconversion interface.
			/// <para>
			/// This value can be used by edit controls or apps, with TKB_ALTERNATES_FOR_AUTOCORRECTION, to prevent the repeated application
			/// of an autocorrection.
			/// </para>
			/// </summary>
			TKB_ALTERNATES_AUTOCORRECTION_APPLIED = 0x00000004,
		}

		/// <summary>The <c>TF_DA_COLOR</c> structure contains color data used in the display attributes for a range of text.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ns-msctf-tf_da_color typedef struct TF_DA_COLOR { TF_DA_COLORTYPE type;
		// union { int nIndex; COLORREF cr; }; } TF_DA_COLOR;
		[PInvokeData("msctf.h", MSDNShortId = "NS:msctf.TF_DA_COLOR")]
		[StructLayout(LayoutKind.Explicit, Pack = 4), Guid("90D0CB5E-6520-4A0F-B47C-C39BD955F0D6")]
		public struct TF_DA_COLOR
		{
			/// <summary>Specifies the color type as defined in the TF_DA_COLORTYPE enumeration.</summary>
			[FieldOffset(0)]
			internal TF_DA_COLORTYPE type;

			/// <summary>
			/// Specifies the color as a system color index as defined in GetSysColor. This member is used only if <c>type</c> is equal to TF_CT_SYSCOLOR.
			/// </summary>
			[FieldOffset(4)]
			internal int nIndex;

			/// <summary>Specifies the color as an RGB value. This member is used only if <c>type</c> is equal to TF_CT_COLORREF.</summary>
			[FieldOffset(4)]
			internal COLORREF cr;
		}

		/// <summary>The <c>TF_DISPLAYATTRIBUTE</c> structure contains display attribute data for rendering text.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ns-msctf-tf_displayattribute typedef struct TF_DISPLAYATTRIBUTE {
		// TF_DA_COLOR crText; TF_DA_COLOR crBk; TF_DA_LINESTYLE lsStyle; BOOL fBoldLine; TF_DA_COLOR crLine; TF_DA_ATTR_INFO bAttr; } TF_DISPLAYATTRIBUTE;
		[PInvokeData("msctf.h", MSDNShortId = "NS:msctf.TF_DISPLAYATTRIBUTE")]
		[StructLayout(LayoutKind.Sequential, Pack = 4), Guid("1BF1C305-419B-4182-A4D2-9BFADC3F021F")]
		public struct TF_DISPLAYATTRIBUTE
		{
			/// <summary>Contains a TF_DA_COLOR structure that defines the text foreground color.</summary>
			public TF_DA_COLOR crText;

			/// <summary>Contains a <c>TF_DA_COLOR</c> structure that defines the text background color.</summary>
			public TF_DA_COLOR crBk;

			/// <summary>Contains a TF_DA_LINESTYLE enumeration value that defines the underline style.</summary>
			public TF_DA_LINESTYLE lsStyle;

			/// <summary>
			/// A BOOL value that specifies if the underline should be bold or normal weight. If this value is nonzero, the underline should
			/// be bold. If this value is zero, the underline should be normal.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fBoldLine;

			/// <summary>Contains a <c>TF_DA_COLOR</c> structure that defines the color of the underline.</summary>
			public TF_DA_COLOR crLine;

			/// <summary>Contains a TF_DA_ATTR_INFO value that defines text conversion display attribute data.</summary>
			public TF_DA_ATTR_INFO bAttr;
		}

		/// <summary>This structure contains data for the input processor profile.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ns-msctf-tf_inputprocessorprofile typedef struct
		// TF_INPUTPROCESSORPROFILE { DWORD dwProfileType; LANGID langid; CLSID clsid; GUID guidProfile; GUID catid; HKL hklSubstitute;
		// DWORD dwCaps; HKL hkl; DWORD dwFlags; } TF_INPUTPROCESSORPROFILE;
		[PInvokeData("msctf.h", MSDNShortId = "NS:msctf.TF_INPUTPROCESSORPROFILE")]
		[StructLayout(LayoutKind.Sequential, Pack = 4), Guid("44D2825A-10E5-43B2-877F-6CB2F43B7E7E")]
		public struct TF_INPUTPROCESSORPROFILE
		{
			/// <summary>
			/// <para>The type of this profile. This is one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TF_PROFILETYPE_INPUTPROCESSOR</term>
			/// <term>This is a text service.</term>
			/// </item>
			/// <item>
			/// <term>TF_PROFILETYPE_KEYBOARDLAYOUT</term>
			/// <term>This is a keyboard layout.</term>
			/// </item>
			/// </list>
			/// </summary>
			public TF_PROFILETYPE dwProfileType;

			/// <summary>The language id for this profile.</summary>
			public LANGID langid;

			/// <summary>The CLSID of the text service. This is CLSID_NULL if this profile is a keyboard layout.</summary>
			public Guid clsid;

			/// <summary>The guidProfile of the text services. This is GUID_NULL if this profile is a keyboard layout.</summary>
			public Guid guidProfile;

			/// <summary>
			/// The category of this text service. This category is GUID_TFCAT_TIP_KEYBOARD, GUID_TFCAT_TIP_SPEECH,
			/// GUID_TFCAT_TIP_HANDWRITING or something in GUID_TFCAT_CATEGORY_OF_TIP.
			/// </summary>
			public Guid catid;

			/// <summary>
			/// The keyboard layout handle of the substitute for this text service. This can be <c>NULL</c> if the text service does not
			/// have a substitute or this profile is a keyboard layout.
			/// </summary>
			public HKL hklSubstitute;

			/// <summary>
			/// <para>The flag to specify the capability of text service. This is the combination of the following flags:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TF_IPP_CAPS_DISABLEONTRANSITORY</term>
			/// <term>This text service profile is disabled on transitory context.</term>
			/// </item>
			/// <item>
			/// <term>TF_IPP_CAPS_SECUREMODESUPPORT</term>
			/// <term>This text service supports the secure mode. This is categorized in GUID_TFCAT_TIPCAP_SECUREMODE.</term>
			/// </item>
			/// <item>
			/// <term>TF_IPP_CAPS_UIELEMENTENABLED</term>
			/// <term>This text service supports the UIElement. This is categorized in GUID_TFCAT_TIPCAP_UIELEMENTENABLED.</term>
			/// </item>
			/// <item>
			/// <term>TF_IPP_CAPS_COMLESSSUPPORT</term>
			/// <term>This text service can be activated without COM. This is categorized in GUID_TFCAT_TIPCAP_COMLESS.</term>
			/// </item>
			/// <item>
			/// <term>TF_IPP_CAPS_WOW16SUPPORT</term>
			/// <term>This text service can be activated on 16bit task. This is categorized in GUID_TFCAT_TIPCAP_WOW16.</term>
			/// </item>
			/// <item>
			/// <term>TF_IPP_CAPS_IMMERSIVESUPPORT</term>
			/// <term>Starting with Windows 8: This text service has been tested to run properly in a Windows Store app.</term>
			/// </item>
			/// <item>
			/// <term>TF_IPP_CAPS_SYSTRAYSUPPORT</term>
			/// <term>
			/// Starting with Windows 8: This text service supports inclusion in the System Tray. This is used for text services that do not
			/// set the TF_IPP_CAPS_IMMERSIVESUPPORT flag but are still compatible with the System Tray.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public TF_IPP_CAPS dwCaps;

			/// <summary>The keyboard layout handle. This is <c>NULL</c> if this profile is a text service.</summary>
			public HKL hkl;

			/// <summary>
			/// <para>The flag for this profile. This is a combination of the following flags:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TF_IPP_FLAG_ACTIVE</term>
			/// <term>This profile is now active.</term>
			/// </item>
			/// <item>
			/// <term>TF_IPP_FLAG_ENABLED</term>
			/// <term>This profile is enabled.</term>
			/// </item>
			/// <item>
			/// <term>TF_IPP_FLAG_SUBSTITUTEDBYINPUTPROCESSOR</term>
			/// <term>This profile is substituted by a text service.</term>
			/// </item>
			/// </list>
			/// </summary>
			public TF_IPP_FLAG dwFlags;
		}

		/// <summary>The <c>TF_LANGUAGEPROFILE</c> structure contains information about a language profile.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ns-msctf-tf_languageprofile typedef struct TF_LANGUAGEPROFILE { CLSID
		// clsid; LANGID langid; GUID catid; BOOL fActive; GUID guidProfile; } TF_LANGUAGEPROFILE;
		[PInvokeData("msctf.h", MSDNShortId = "NS:msctf.TF_LANGUAGEPROFILE")]
		[StructLayout(LayoutKind.Sequential, Pack = 4), Guid("E1B5808D-1E46-4C19-84DC-68C5F5978CC8")]
		public struct TF_LANGUAGEPROFILE
		{
			/// <summary>Specifies the class identifier of the text service within the language profile.</summary>
			public Guid clsid;

			/// <summary>Specifies the language identifier of the profile.</summary>
			public LANGID langid;

			/// <summary>Specifies the identifier of the category that the text service belongs to.</summary>
			public Guid catid;

			/// <summary>A Boolean value, when <c>TRUE</c>, indicates that the language is activated.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fActive;

			/// <summary>Specifies the identifier of the language profile.</summary>
			public Guid guidProfile;
		}

		/// <summary>The <c>TF_PERSISTENT_PROPERTY_HEADER_ACP</c> structure is used to provide property header data.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ns-msctf-tf_persistent_property_header_acp typedef struct
		// TF_PERSISTENT_PROPERTY_HEADER_ACP { GUID guidType; LONG ichStart; LONG cch; ULONG cb; DWORD dwPrivate; CLSID clsidTIP; } TF_PERSISTENT_PROPERTY_HEADER_ACP;
		[PInvokeData("msctf.h", MSDNShortId = "NS:msctf.TF_PERSISTENT_PROPERTY_HEADER_ACP")]
		[StructLayout(LayoutKind.Sequential, Pack = 4), Guid("E26D9E1D-691E-4F29-90D7-338DCF1F8CEF")]
		public struct TF_PERSISTENT_PROPERTY_HEADER_ACP
		{
			/// <summary>Contains a GUID that identifies the property.</summary>
			public Guid guidType;

			/// <summary>Contains the starting character position of the property.</summary>
			public int ichStart;

			/// <summary>Contains the number of characters that the property spans.</summary>
			public int cch;

			/// <summary>Contains the size, in bytes, of the property value.</summary>
			public uint cb;

			/// <summary>Contains a <c>DWORD</c> value defined by the property owner.</summary>
			public uint dwPrivate;

			/// <summary>Contains the CLSID of the property owner.</summary>
			public Guid clsidTIP;
		}

		/// <summary>The <c>TF_PRESERVEDKEY</c> structure represents a preserved key.</summary>
		/// <remarks>
		/// Preserved keys are registered by TSF text services and provide keyboard shortcuts to common commands implemented by the TSF text service.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ns-msctf-tf_preservedkey typedef struct TF_PRESERVEDKEY { UINT uVKey;
		// UINT uModifiers; } TF_PRESERVEDKEY;
		[PInvokeData("msctf.h", MSDNShortId = "NS:msctf.TF_PRESERVEDKEY")]
		[StructLayout(LayoutKind.Sequential, Pack = 4), Guid("77C12F95-B783-450D-879F-1CD2362C6521")]
		public struct TF_PRESERVEDKEY
		{
			/// <summary>Virtual key code of the keyboard shortcut.</summary>
			public uint uVKey;

			/// <summary>Modifies the preserved key. This can be zero or a combination of one or more of the TF_MOD_* constants.</summary>
			public TF_MOD uModifiers;
		}

		/// <summary>
		/// The <c>TF_PROPERTYVAL</c> structure contains property value data. This structure is used with the IEnumTfPropertyValue::Next method.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ns-msctf-tf_propertyval typedef struct TF_PROPERTYVAL { GUID guidId;
		// VARIANT varValue; } TF_PROPERTYVAL;
		[PInvokeData("msctf.h", MSDNShortId = "NS:msctf.TF_PROPERTYVAL")]
		[StructLayout(LayoutKind.Sequential, Pack = 8), Guid("D678C645-EB6A-45C9-B4EE-0F3E3A991348")]
		public struct TF_PROPERTYVAL
		{
			/// <summary>
			/// A <c>GUID</c> that identifies the property type. This can be a custom identifier or one of the predefined property identifiers.
			/// </summary>
			public Guid guidId;

			/// <summary>
			/// A <c>VARIANT</c> that contains the value of the property specified by <c>guidId</c>. The user must know the type and format
			/// of this data.
			/// </summary>
			[MarshalAs(UnmanagedType.Struct)]
			public object varValue;
		}

		/// <summary>The <c>TF_SELECTION</c> structure contains text selection data.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ns-msctf-tf_selection typedef struct TF_SELECTION { ITfRange *range;
		// TF_SELECTIONSTYLE style; } TF_SELECTION;
		[PInvokeData("msctf.h", MSDNShortId = "NS:msctf.TF_SELECTION")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TF_SELECTION
		{
			/// <summary>Pointer to an ITfRange object that specifies the selected text.</summary>
			public ITfRange range;

			/// <summary>A TF_SELECTIONSTYLE structure that contains selection data.</summary>
			public TF_SELECTIONSTYLE style;
		}

		/// <summary>The <c>TF_SELECTIONSTYLE</c> structure represents the style of a selection.</summary>
		/// <remarks>
		/// An interim character selection spans exactly one character and is visually represented as a solid rectangle that is usually
		/// flashing. This is a standard UI element of Korean and some Chinese character compositions. <c>fInterimChar</c> is an indication
		/// that a specific character is composed. <c>fInterimChar</c> can only be nonzero for a single selection. In this case, there will
		/// be no caret because the highlight replaces it.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ns-msctf-tf_selectionstyle typedef struct TF_SELECTIONSTYLE {
		// TfActiveSelEnd ase; BOOL fInterimChar; } TF_SELECTIONSTYLE;
		[PInvokeData("msctf.h", MSDNShortId = "NS:msctf.TF_SELECTIONSTYLE")]
		[StructLayout(LayoutKind.Sequential, Pack = 4), Guid("36AE42A4-6989-4BDC-B48A-6137B7BF2E42")]
		public struct TF_SELECTIONSTYLE
		{
			/// <summary>Specifies the active end of the selection. For more information, see TfActiveSelEnd.</summary>
			public TfActiveSelEnd ase;

			/// <summary>
			/// Indicates if the selection is an interim character. If this value is nonzero, then the seleciton is an interim character and
			/// <c>ase</c> will be TF_AE_NONE. If this value is zero, the selection is not an interim character.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fInterimChar;
		}

		/// <summary>The <c>TF_HALTCOND</c> structure is used to contain conditions of a range shift.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msctf/ns-msctf-tf_haltcond typedef struct TF_HALTCOND { ITfRange *pHaltRange;
		// TfAnchor aHaltPos; DWORD dwFlags; } TF_HALTCOND;
		[PInvokeData("msctf.h", MSDNShortId = "NS:msctf.TF_HALTCOND")]
		[StructLayout(LayoutKind.Sequential, Pack = 4), Guid("49930D51-7D93-448C-A48C-FEA5DAC192B1")]
		public class TF_HALTCOND
		{
			/// <summary>
			/// Pointer to an ITfRange object that halts the shift. If the range shift encounters this range during the shift, the shift
			/// halts. This member can be <c>NULL</c>.
			/// </summary>
			public ITfRange pHaltRange;

			/// <summary>
			/// Contains one of the TfAnchor values that specifies which anchor of <c>pHaltRange</c> the anchor will get shifted to if
			/// <c>pHaltRange</c> is encountered during the range shift. This member is ignored if <c>pHaltRange</c> is <c>NULL</c>.
			/// </summary>
			public TfAnchor aHaltPos;

			/// <summary>
			/// <para>Contains a set of flags that modify the behavior of the range shift. This can be zero or the following value.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TF_HF_OBJECT</term>
			/// <term>The range shift halts if an embedded object is encountered.</term>
			/// </item>
			/// </list>
			/// </summary>
			public TF_HF dwFlags;
		}
	}
}