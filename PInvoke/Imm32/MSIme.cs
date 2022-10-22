#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from the Imm32.dll</summary>
	public static partial class Imm32
	{
		/// <summary>invalid dictionary format</summary>
		public static readonly HRESULT IFED_E_INVALID_FORMAT = HRESULT.Make(true, HRESULT.FacilityCode.FACILITY_ITF, 0x7301);

		/// <summary>no entry found in dictionary</summary>
		public static readonly HRESULT IFED_E_NO_ENTRY = HRESULT.Make(true, HRESULT.FacilityCode.FACILITY_ITF, 0x7304);

		/// <summary>dictionary is not found</summary>
		public static readonly HRESULT IFED_E_NOT_FOUND = HRESULT.Make(true, HRESULT.FacilityCode.FACILITY_ITF, 0x7300);

		/// <summary>not supported</summary>
		public static readonly HRESULT IFED_E_NOT_SUPPORTED = HRESULT.Make(true, HRESULT.FacilityCode.FACILITY_ITF, 0x7307);

		/// <summary>not a user dictionary</summary>
		public static readonly HRESULT IFED_E_NOT_USER_DIC = HRESULT.Make(true, HRESULT.FacilityCode.FACILITY_ITF, 0x7306);

		/// <summary>failed to open file</summary>
		public static readonly HRESULT IFED_E_OPEN_FAILED = HRESULT.Make(true, HRESULT.FacilityCode.FACILITY_ITF, 0x7302);

		/// <summary>dictionary is disconnected</summary>
		public static readonly HRESULT IFED_E_REGISTER_DISCONNECTED = HRESULT.Make(true, HRESULT.FacilityCode.FACILITY_ITF, 0x730b);

		/// <summary>this routines doesn't support the current dictionary</summary>
		public static readonly HRESULT IFED_E_REGISTER_FAILED = HRESULT.Make(true, HRESULT.FacilityCode.FACILITY_ITF, 0x7305);

		/// <summary>improper POS is to be registered</summary>
		public static readonly HRESULT IFED_E_REGISTER_ILLEGAL_POS = HRESULT.Make(true, HRESULT.FacilityCode.FACILITY_ITF, 0x7309);

		/// <summary>improper word is to be registered</summary>
		public static readonly HRESULT IFED_E_REGISTER_IMPROPER_WORD = HRESULT.Make(true, HRESULT.FacilityCode.FACILITY_ITF, 0x730a);

		/// <summary>failed to insert user comment</summary>
		public static readonly HRESULT IFED_E_USER_COMMENT = HRESULT.Make(true, HRESULT.FacilityCode.FACILITY_ITF, 0x7308);

		/// <summary>failed to write to file</summary>
		public static readonly HRESULT IFED_E_WRITE_FAILED = HRESULT.Make(true, HRESULT.FacilityCode.FACILITY_ITF, 0x7303);

		/// <summary>word already exists in dictionary but only comment data is updated</summary>
		public static readonly HRESULT IFED_S_COMMENT_CHANGED = HRESULT.Make(false, HRESULT.FacilityCode.FACILITY_ITF, 0x7203);

		/// <summary>dictionary is empty, no header information is returned</summary>
		public static readonly HRESULT IFED_S_EMPTY_DICTIONARY = HRESULT.Make(false, HRESULT.FacilityCode.FACILITY_ITF, 0x7201);

		/// <summary>no more entries in the dictionary</summary>
		public static readonly HRESULT IFED_S_MORE_ENTRIES = HRESULT.Make(false, HRESULT.FacilityCode.FACILITY_ITF, 0x7200);

		/// <summary>word already exists in dictionary</summary>
		public static readonly HRESULT IFED_S_WORD_EXISTS = HRESULT.Make(false, HRESULT.FacilityCode.FACILITY_ITF, 0x7202);

		/// <summary>Returns a pointer to an IFECommon interface.</summary>
		/// <param name="ppvObj">Address of the pointer variable that receives the IFECommon interface pointer of the object created.</param>
		/// <returns><c>S_OK</c> if successful, otherwise an OLE-defined error code.</returns>
		/// <remarks>
		/// There is no import library available that defines this function. It is necessary to manually obtain a pointer to this function
		/// using LoadLibrary and GetProcAddress.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-createifecommoninstance HRESULT CreateIFECommonInstance( [out]
		// VOID **ppvObj );
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("msime.h", MSDNShortId = "NF:msime.CreateIFECommonInstance")]
		public delegate HRESULT CreateIFECommonInstance(out IFECommon ppvObj);

		/// <summary>Returns a pointer to an IFEDictionary interface.</summary>
		/// <param name="ppvObj">Address of the pointer variable that receives the IFEDictionary interface pointer of the object created.</param>
		/// <returns><c>S_OK</c> if successful, otherwise an OLE-defined error code.</returns>
		/// <remarks>
		/// There is no import library available that defines this function. It is necessary to manually obtain a pointer to this function
		/// using LoadLibrary and GetProcAddress.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-createifedictionaryinstance HRESULT CreateIFEDictionaryInstance(
		// [out] VOID **ppvObj );
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("msime.h", MSDNShortId = "NF:msime.CreateIFEDictionaryInstance")]
		public delegate HRESULT CreateIFEDictionaryInstance(out IFEDictionary ppvObj);

		/// <summary>Returns a pointer to an IFELanguage interface.</summary>
		/// <param name="clsid">Reserved. Must be set to <c>NULL</c>.</param>
		/// <param name="ppvObj">Address of the pointer variable that receives the IFELanguage interface pointer of the object created.</param>
		/// <returns><c>S_OK</c> if successful, otherwise an OLE-defined error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-createifelanguageinstance HRESULT CreateIFELanguageInstance(
		// [in] REFCLSID clsid, [out] VOID **ppvObj );
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("msime.h", MSDNShortId = "NF:msime.CreateIFELanguageInstance")]
		public delegate HRESULT CreateIFELanguageInstance([In, Optional] IntPtr clsid, out IFELanguage ppvObj);

		[PInvokeData("msime.h")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate bool PFNLOG(ref IMEDP a, HRESULT hr);

		/// <summary>The information for each column</summary>
		[PInvokeData("msime.h")]
		[Flags]
		public enum FELANG_CLMN : uint
		{
			FELANG_CLMN_WBREAK = 0x01,
			FELANG_CLMN_NOWBREAK = 0x02,
			FELANG_CLMN_PBREAK = 0x04,
			FELANG_CLMN_NOPBREAK = 0x08,
			FELANG_CLMN_FIXR = 0x10,
			FELANG_CLMN_FIXD = 0x20,
		}

		/// <summary>Specifies the conversion output characters and conversion options.</summary>
		[PInvokeData("msime.h")]
		[Flags]
		public enum FELANG_CMODE : uint
		{
			/// <summary>Mono-ruby.</summary>
			FELANG_CMODE_MONORUBY = 0x00000002,

			/// <summary>No pruning.</summary>
			FELANG_CMODE_NOPRUNING = 0x00000004,

			/// <summary>Katakana output.</summary>
			FELANG_CMODE_KATAKANAOUT = 0x00000008,

			/// <summary>Default output.</summary>
			FELANG_CMODE_HIRAGANAOUT = 0x00000000,

			/// <summary>Half-width output.</summary>
			FELANG_CMODE_HALFWIDTHOUT = 0x00000010,

			/// <summary>Full-width output.</summary>
			FELANG_CMODE_FULLWIDTHOUT = 0x00000020,

			FELANG_CMODE_BOPOMOFO = 0x00000040,
			FELANG_CMODE_HANGUL = 0x00000080,
			FELANG_CMODE_PINYIN = 0x00000100,

			/// <summary>Do conversion as follows:</summary>
			FELANG_CMODE_PRECONV = 0x00000200,

			FELANG_CMODE_RADICAL = 0x00000400,
			FELANG_CMODE_UNKNOWNREADING = 0x00000800,

			/// <summary>Merge display with the same candidate.</summary>
			FELANG_CMODE_MERGECAND = 0x00001000,

			FELANG_CMODE_ROMAN = 0x00002000,

			/// <summary>Make only the first best.</summary>
			FELANG_CMODE_BESTFIRST = 0x00004000,

			/// <summary>Use invalid revword on REV/RECONV.</summary>
			FELANG_CMODE_USENOREVWORDS = 0x00008000,

			/// <summary>IME_SMODE_NONE</summary>
			FELANG_CMODE_NONE = 0x01000000,

			/// <summary>IME_SMODE_PLAURALCLAUSE</summary>
			FELANG_CMODE_PLAURALCLAUSE = 0x02000000,

			/// <summary>IME_SMODE_SINGLECONVERT</summary>
			FELANG_CMODE_SINGLECONVERT = 0x04000000,

			/// <summary>IME_SMODE_AUTOMATIC</summary>
			FELANG_CMODE_AUTOMATIC = 0x08000000,

			/// <summary>IME_SMODE_PHRASEPREDICT</summary>
			FELANG_CMODE_PHRASEPREDICT = 0x10000000,

			/// <summary>IME_SMODE_CONVERSATION</summary>
			FELANG_CMODE_CONVERSATION = 0x20000000,

			/// <summary>Name mode (MSKKIME).</summary>
			FELANG_CMODE_NAME = FELANG_CMODE_PHRASEPREDICT,

			/// <summary>Remove invisible chars (for example, the tone mark).</summary>
			FELANG_CMODE_NOINVISIBLECHAR = 0x40000000,
		}

		/// <summary>The conversion request.</summary>
		[PInvokeData("msime.h", MSDNShortId = "NN:msime.IFELanguage")]
		public enum FELANG_REQ
		{
			FELANG_REQ_CONV = 0x00010000,
			FELANG_REQ_RECONV = 0x00020000,
			FELANG_REQ_REV = 0x00030000,
		}

		/// <summary></summary>
		[PInvokeData("msime.h", MSDNShortId = "NN:msime.IFEDictionary")]
		[Flags]
		public enum IFED_POS : uint
		{
			IFED_POS_NONE = 0x00000000,
			IFED_POS_NOUN = 0x00000001,
			IFED_POS_VERB = 0x00000002,
			IFED_POS_ADJECTIVE = 0x00000004,
			IFED_POS_ADJECTIVE_VERB = 0x00000008,
			IFED_POS_ADVERB = 0x00000010,
			IFED_POS_ADNOUN = 0x00000020,
			IFED_POS_CONJUNCTION = 0x00000040,
			IFED_POS_INTERJECTION = 0x00000080,
			IFED_POS_INDEPENDENT = 0x000000ff,
			IFED_POS_INFLECTIONALSUFFIX = 0x00000100,
			IFED_POS_PREFIX = 0x00000200,
			IFED_POS_SUFFIX = 0x00000400,
			IFED_POS_AFFIX = 0x00000600,
			IFED_POS_TANKANJI = 0x00000800,
			IFED_POS_IDIOMS = 0x00001000,
			IFED_POS_SYMBOLS = 0x00002000,
			IFED_POS_PARTICLE = 0x00004000,
			IFED_POS_AUXILIARY_VERB = 0x00008000,
			IFED_POS_SUB_VERB = 0x00010000,
			IFED_POS_DEPENDENT = 0x0001c000,
			IFED_POS_ALL = 0x0001ffff,
		}

		/// <summary></summary>
		[PInvokeData("msime.h", MSDNShortId = "NN:msime.IFEDictionary")]
		[Flags]
		public enum IFED_REG : uint
		{
			IFED_REG_NONE = 0x00000000,
			IFED_REG_USER = 0x00000001,
			IFED_REG_AUTO = 0x00000002,
			IFED_REG_GRAMMAR = 0x00000004,
			IFED_REG_ALL = 0x00000007,
		}

		/// <summary></summary>
		[PInvokeData("msime.h", MSDNShortId = "NN:msime.IFEDictionary")]
		[Flags]
		public enum IFED_SELECT : uint
		{
			IFED_SELECT_NONE = 0x00000000,
			IFED_SELECT_READING = 0x00000001,
			IFED_SELECT_DISPLAY = 0x00000002,
			IFED_SELECT_POS = 0x00000004,
			IFED_SELECT_COMMENT = 0x00000008,
			IFED_SELECT_ALL = 0x0000000f,
		}

		/// <summary>The dictionary type.</summary>
		[PInvokeData("msime.h", MSDNShortId = "NN:msime.IFEDictionary")]
		[Flags]
		public enum IFED_TYPE : uint
		{
			/// <summary>Undefined.</summary>
			IFED_TYPE_NONE = 0x00000000,

			/// <summary>General dictionary.</summary>
			IFED_TYPE_GENERAL = 0x00000001,

			/// <summary>Name/place dictionary.</summary>
			IFED_TYPE_NAMEPLACE = 0x00000002,

			/// <summary>Speech dictionary.</summary>
			IFED_TYPE_SPEECH = 0x00000004,

			/// <summary>Reverse dictionary.</summary>
			IFED_TYPE_REVERSE = 0x00000008,

			/// <summary>English dictionary.</summary>
			IFED_TYPE_ENGLISH = 0x00000010,

			/// <summary>All of the above types.</summary>
			IFED_TYPE_ALL = 0x0000001f,
		}

		[PInvokeData("msime.h")]
		public enum IMEFMT
		{
			IFED_UNKNOWN,
			IFED_MSIME2_BIN_SYSTEM,
			IFED_MSIME2_BIN_USER,
			IFED_MSIME2_TEXT_USER,
			IFED_MSIME95_BIN_SYSTEM,
			IFED_MSIME95_BIN_USER,
			IFED_MSIME95_TEXT_USER,
			IFED_MSIME97_BIN_SYSTEM,
			IFED_MSIME97_BIN_USER,
			IFED_MSIME97_TEXT_USER,
			IFED_MSIME98_BIN_SYSTEM,
			IFED_MSIME98_BIN_USER,
			IFED_MSIME98_TEXT_USER,
			IFED_ACTIVE_DICT,
			IFED_ATOK9,
			IFED_ATOK10,
			IFED_NEC_AI_,
			IFED_WX_II,
			IFED_WX_III,
			IFED_VJE_20,
			IFED_MSIME98_SYSTEM_CE,
			IFED_MSIME_BIN_SYSTEM,
			IFED_MSIME_BIN_USER,
			IFED_MSIME_TEXT_USER,
			IFED_PIME2_BIN_USER,
			IFED_PIME2_BIN_SYSTEM,
			IFED_PIME2_BIN_STANDARD_SYSTEM,
		}

		[PInvokeData("msime.h")]
		public enum IMEREG
		{
			IFED_REG_HEAD,
			IFED_REG_TAIL,
			IFED_REG_DEL,
		}

		[PInvokeData("msime.h")]
		public enum IMEREL
		{
			IFED_REL_NONE,
			IFED_REL_NO,
			IFED_REL_GA,
			IFED_REL_WO,
			IFED_REL_NI,
			IFED_REL_DE,
			IFED_REL_YORI,
			IFED_REL_KARA,
			IFED_REL_MADE,
			IFED_REL_HE,
			IFED_REL_TO,
			IFED_REL_IDEOM,
			IFED_REL_FUKU_YOUGEN,       //p2_1
			IFED_REL_KEIYOU_YOUGEN,     //p2_2
			IFED_REL_KEIDOU1_YOUGEN,    //p2_3
			IFED_REL_KEIDOU2_YOUGEN,    //p2_4
			IFED_REL_TAIGEN,            //p2_5
			IFED_REL_YOUGEN,            //p2_6
			IFED_REL_RENTAI_MEI,        //p3_1
			IFED_REL_RENSOU,            //p3_2
			IFED_REL_KEIYOU_TO_YOUGEN,  //p3_3
			IFED_REL_KEIYOU_TARU_YOUGEN,//p3_4
			IFED_REL_UNKNOWN1,          //p3_5
			IFED_REL_UNKNOWN2,          //p3_6
			IFED_REL_ALL,               //any type
		}

		/// <summary>Type of user comment in a IMEWRD structure.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msime/ne-msime-imeuct typedef enum { IFED_UCT_NONE, IFED_UCT_STRING_SJIS,
		// IFED_UCT_STRING_UNICODE, IFED_UCT_USER_DEFINED, IFED_UCT_MAX } IMEUCT;
		[PInvokeData("msime.h", MSDNShortId = "NE:msime.__unnamed_enum_2")]
		public enum IMEUCT
		{
			IFED_UCT_NONE,
			IFED_UCT_STRING_SJIS,
			IFED_UCT_STRING_UNICODE,
			IFED_UCT_USER_DEFINED,
			IFED_UCT_MAX,
		}

		/// <summary>
		/// The IFECommon interface provides IME-related services that are common for different languages.
		/// <para>IFECommon allows the developer to control very basic functions of IMEs.</para>
		/// </summary>
		/// <remarks>Create an instance of this interface with the CreateIFECommonInstance function.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msime/nn-msime-ifecommon
		[PInvokeData("msime.h", MSDNShortId = "NN:msime.IFECommon")]
		[ComImport, Guid("019F7151-E6DB-11d0-83C3-00C04FDDB82E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IFECommon
		{
			/// <summary>
			/// Determines if the IME specified by the class ID is the default IME on a local computer.
			/// <para>The name of the IME is obtained from the Win32 keyboard layout API.</para>
			/// </summary>
			/// <param name="szName">The name of the IME for the specified class ID. Can be <c>NULL</c>.</param>
			/// <param name="cszName">The size of <c>szName</c> in bytes.</param>
			/// <returns>
			/// <list type="bullet">
			/// <item>
			/// <term><c>S_OK</c> if this Microsoft IME is already the default IME.</term>
			/// </item>
			/// <item>
			/// <term><c>S_FALSE</c> if this Microsoft IME is not the default IME.</term>
			/// </item>
			/// <item>
			/// <term>Otherwise <c>E_FAIL</c>.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifecommon-isdefaultime HRESULT IsDefaultIME( [out] const
			// CHAR *szName, [in] INT cszName );
			[PreserveSig]
			HRESULT IsDefaultIME([Out, Optional, MarshalAs(UnmanagedType.LPStr)] StringBuilder szName, [In] int cszName);

			/// <summary>
			/// Allows the Microsoft IME to become the default IME in the keyboard layout.
			/// <para>This method only applies when Microsoft IME uses the Input Method Manager(IMM) of the operating system.</para>
			/// </summary>
			/// <returns>
			/// <list type="bullet">
			/// <item>
			/// <term><c>S_OK</c> if successful.</term>
			/// </item>
			/// <item>
			/// <term><c>IFEC_S_ALREADY_DEFAULT</c> if this Microsoft IME is already the default IME.</term>
			/// </item>
			/// <item>
			/// <term>Otherwise <c>E_FAIL</c>.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifecommon-setdefaultime HRESULT SetDefaultIME();
			[PreserveSig]
			HRESULT SetDefaultIME();

			/// <summary>Invokes the Microsoft IME Word Register Dialog Window from the app.</summary>
			/// <param name="pimedlg">Pointer to an IMEDLG structure.</param>
			/// <returns><c>S_OK</c> if successful, otherwise <c>E_FAIL</c>.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifecommon-invokewordregdialog HRESULT InvokeWordRegDialog(
			// [in] IMEDLG *pimedlg );
			[PreserveSig]
			HRESULT InvokeWordRegDialog(in IMEDLG pimedlg);

			/// <summary>Invokes the Microsoft IME's Dictionary Tool from the app.</summary>
			/// <param name="pimedlg">Pointer to an IMEDLG structure.</param>
			/// <returns><c>S_OK</c> if successful, otherwise <c>E_FAIL</c>.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifecommon-invokedicttooldialog HRESULT InvokeDictToolDialog(
			// [in] IMEDLG *pimedlg );
			[PreserveSig]
			HRESULT InvokeDictToolDialog(in IMEDLG pimedlg);
		}

		/// <summary>
		/// <para>The IFEDictionary interface allows clients to access a Microsoft IME user dictionary.</para>
		/// <para>
		/// This API enables your apps to access and use the data contained in the Microsoft IME dictionaries(including personal name and
		/// geographical name dictionaries), or user dictionary.You can develop and sell such applications, provided that:
		/// </para>
		/// <list type="bullet">
		/// <item>You do not create an application that accesses a dictionary that is not a Microsoft IME dictionary through this API.</item>
		/// <item>
		/// You do not dump, copy, or distribute the dictionary data contained in the Microsoft IME. You must use this API only for the
		/// purpose of developing applications for users who already have the Microsoft IME.
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>Create an instance of this interface with the CreateIFEDictionaryInstance function.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msime/nn-msime-ifedictionary
		[PInvokeData("msime.h", MSDNShortId = "NN:msime.IFEDictionary")]
		[ComImport, Guid("019F7153-E6DB-11d0-83C3-00C04FDDB82E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IFEDictionary
		{
			/// <summary>
			/// This method opens an existing dictionary file and associates it with this IFEDictionary object. To implement a multiple
			/// dictionary facility, multiple open and release procedures must be carried out.
			/// </summary>
			/// <param name="pchDictPath">
			/// Points to a <c>NULL</c>-terminated file name string to be opened. If <c>pchDictPath</c> is <c>NULL</c> or an empty string,
			/// the user dictionary opened by the IME kernel will be used. If <c>pchDictPath</c> is an empty string, the name of user
			/// dictionary will be copied into <c>pchDictPath</c>, in which case the size of <c>pchDictPath</c> must be <c>MAX_PATH</c>.
			/// </param>
			/// <param name="pshf">The IMESHF header of the opened file. Can be <c>NULL</c>.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifedictionary-open HRESULT Open( [in, optional] CHAR
			// *pchDictPath, [out] IMESHF *pshf );
			void Open([Optional, MarshalAs(UnmanagedType.LPStr)] string pchDictPath, out IMESHF pshf);

			/// <summary>This method closes the file associated to this IFEDictionary object.</summary>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifedictionary-close HRESULT Close();
			void Close();

			/// <summary>Gets a dictionary header from a dictionary file without opening the dictionary.</summary>
			/// <param name="pchDictPath">A <c>NULL</c>-terminated string containing the path and name of the dictionary file.</param>
			/// <param name="pshf">The IMESHF header of the file. Can be <c>NULL</c>.</param>
			/// <param name="pjfmt">
			/// <para>The dictionary format. This can be one of the following values:</para>
			/// <list type="bullet">
			/// <item>IFED_UNKNOWN</item>
			/// <item>IFED_MSIME2_BIN_SYSTEM</item>
			/// <item>IFED_MSIME2_BIN_USER</item>
			/// <item>IFED_MSIME2_TEXT_USER</item>
			/// <item>IFED_MSIME95_BIN_SYSTEM</item>
			/// <item>IFED_MSIME95_BIN_USER</item>
			/// <item>IFED_MSIME95_TEXT_USER</item>
			/// <item>IFED_MSIME97_BIN_SYSTEM</item>
			/// <item>IFED_MSIME97_BIN_USER</item>
			/// <item>IFED_MSIME97_TEXT_USER</item>
			/// <item>IFED_MSIME98_BIN_SYSTEM</item>
			/// <item>IFED_MSIME98_BIN_USER</item>
			/// <item>IFED_MSIME98_TEST_USER</item>
			/// <item>IFED_ACTIVE_DICT</item>
			/// <item>IFED_ATOK9</item>
			/// <item>IFED_ATOK10</item>
			/// <item>IFED_NEC_AI_</item>
			/// <item>IFED_WX_II</item>
			/// <item>IFED_WX_III</item>
			/// <item>IFED_VJE_20</item>
			/// <item>IFED_MSIME98_SYSTEM_CE</item>
			/// <item>IFED_MSIME_BIN_SYSTEM</item>
			/// <item>IFED_MSIME_BIN_USER</item>
			/// <item>IFED_MSIME_TEXT_USER</item>
			/// <item>IFED_PIME2_BIN_USER</item>
			/// <item>IFED_PIME2_BIN_SYSTEM</item>
			/// <item>IFED_PIME2_BIN_STANDARD_SYSTEM</item>
			/// </list>
			/// </param>
			/// <param name="pulType">
			/// <para>The dictionary type. This is a combination of one or more of the following flags:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <description><c>IFED_TYPE_NONE</c></description>
			/// <description>Undefined.</description>
			/// </item>
			/// <item>
			/// <description><c>IFED_TYPE_GENERAL</c></description>
			/// <description>General dictionary.</description>
			/// </item>
			/// <item>
			/// <description><c>IFED_TYPE_NAMEPLACE</c></description>
			/// <description>Name/place dictionary.</description>
			/// </item>
			/// <item>
			/// <description><c>IFED_TYPE_SPEECH</c></description>
			/// <description>Speech dictionary.</description>
			/// </item>
			/// <item>
			/// <description><c>IFED_TYPE_REVERSE</c></description>
			/// <description>Reverse dictionary.</description>
			/// </item>
			/// <item>
			/// <description><c>IFED_TYPE_ENGLISH</c></description>
			/// <description>English dictionary.</description>
			/// </item>
			/// <item>
			/// <description><c>IFED_TYPE_ALL</c></description>
			/// <description>All of the above types.</description>
			/// </item>
			/// </list>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifedictionary-getheader HRESULT GetHeader( [in, out,
			// optional] CHAR *pchDictPath, [out] IMESHF *pshf, [out] IMEFMT *pjfmt, [out] ULONG *pulType );
			void GetHeader([MarshalAs(UnmanagedType.LPStr)] StringBuilder pchDictPath, out IMESHF pshf, out IMEFMT pjfmt, out IFED_TYPE pulType);

			/// <summary>This method is obsolete starting with Windows 8, and is no longer supported.</summary>
			/// <param name="hwnd">The parent window handle.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifedictionary-displayproperty HRESULT DisplayProperty( [in]
			// HWND hwnd );
			void DisplayProperty(HWND hwnd);

			/// <summary>Obtains the public POS (Part of Speech) table.</summary>
			/// <param name="prgPosTbl">Pointer to the array of POSTBL structures.</param>
			/// <param name="pcPosTbl">Pointer to the number of POSTBL structures in the returned array. Can be <c>NULL</c>.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifedictionary-getpostable HRESULT GetPosTable( [out] POSTBL
			// **prgPosTbl, [out] int *pcPosTbl );
			void GetPosTable([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] out POSTBL[] prgPosTbl, out int pcPosTbl);

			/// <summary>
			/// <para>The selection of a word entry can be performed by a combination of</para>
			/// <list type="bullet">
			/// <item>A string with Japanese phonetic characters, with or without a wildcard at the end of the string.</item>
			/// <item>A word, with or without a wildcard at its end.</item>
			/// <item>A Part of Speech</item>
			/// </list>
			/// <para>
			/// In addition, retrievals by a string with Japanese phonetic characters can be performed by specifying a range in the Hiragana
			/// 50-on ordering.
			/// </para>
			/// </summary>
			/// <param name="pwchFirst">
			/// <para>A text string against which IFEDictionary entries are matched; the value must be one of the following:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <description><c>NULL</c></description>
			/// <description>Low-value.</description>
			/// </item>
			/// <item>
			/// <description></description>
			/// <description>Hiragana string (full text to be retrieved).</description>
			/// </item>
			/// <item>
			/// <description></description>
			/// <description>
			/// Hiragana string ending in "*" (specifying only leading characters of text). This can be an initial text string when a range
			/// of words is to be retrieved, in which case a wildcard must not be used.
			/// </description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pwchLast">
			/// <para>
			/// A text string that is used to end a text string. This must contain the same value as <c>pwchReading</c> in the IMEWRD
			/// structure when a retrieval is performed by a single value; that is, not by a range value. The value must be one of the following:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <description><c>NULL</c></description>
			/// <description>High-value.</description>
			/// </item>
			/// <item>
			/// <description></description>
			/// <description>Hiragana string (full text to be retrieved).</description>
			/// </item>
			/// <item>
			/// <description></description>
			/// <description>Hiragana string ending in "*" (specifying only leading characters of text).</description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pwchDisplay">
			/// <para>A display string against which IFEDictionary entries are matched; the value must be one of the following:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <description><c>NULL</c></description>
			/// <description>Means "*".</description>
			/// </item>
			/// <item>
			/// <description></description>
			/// <description>Any Japanese string.</description>
			/// </item>
			/// <item>
			/// <description></description>
			/// <description>Japanese string ending in "*".</description>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="ulPos">
			/// <para>Filter(s) on the Microsoft IME public Parts of Speech. This is a combination of one or more of the following flags:</para>
			/// <list type="bullet">
			/// <item>IFED_POS_NONE</item>
			/// <item>IFED_POS_NOUN</item>
			/// <item>IFED_POS_VERB</item>
			/// <item>IFED_POS_ADJECTIVE</item>
			/// <item>IFED_POS_ADJECTIVE_VERB</item>
			/// <item>IFED_POS_ADVERB</item>
			/// <item>IFED_POS_ADNOUN</item>
			/// <item>IFED_POS_CONJUNCTION</item>
			/// <item>IFED_POS_INTERJECTION</item>
			/// <item>IFED_POS_INDEPENDENT</item>
			/// <item>IFED_POS_INFLECTIONALSUFFIX</item>
			/// <item>IFED_POS_PREFIX</item>
			/// <item>IFED_POS_SUFFIX</item>
			/// <item>IFED_POS_AFFIX</item>
			/// <item>IFED_POS_TANKANJI</item>
			/// <item>IFED_POS_IDIOMS</item>
			/// <item>IFED_POS_SYMBOLS</item>
			/// <item>IFED_POS_PARTICLE</item>
			/// <item>IFED_POS_AUXILIARY_VERB</item>
			/// <item>IFED_POS_SUB_VERB</item>
			/// <item>IFED_POS_DEPENDENT</item>
			/// <item>IFED_POS_ALL</item>
			/// </list>
			/// </param>
			/// <param name="ulSelect">
			/// <para>Specifies the query output of a word. This is a combination of one or more of the following flags:</para>
			/// <list type="bullet">
			/// <item>IFED_SELECT_NONE</item>
			/// <item>IFED_SELECT_READING</item>
			/// <item>IFED_SELECT_DISPLAY</item>
			/// <item>IFED_SELECT_POS</item>
			/// <item>IFED_SELECT_COMMENT</item>
			/// <item>IFED_SELECT_ALL</item>
			/// </list>
			/// </param>
			/// <param name="ulWordSrc">
			/// <para>
			/// Specifies the word source. When the IFEDictionary is a user dictionary, this is a combination of one or more of the following flags:
			/// </para>
			/// <list type="bullet">
			/// <item>IFED_REG_NONE</item>
			/// <item>IFED_REG_USER</item>
			/// <item>IFED_REG_AUTO</item>
			/// <item>IFED_REG_GRAMMAR</item>
			/// <item>IFED_REG_ALL</item>
			/// </list>
			/// </param>
			/// <param name="pchBuffer">Buffer provided by the caller to receive the data.</param>
			/// <param name="cbBuffer">The size of <c>pchBuffer</c>.</param>
			/// <param name="pcWrd">
			/// The number of IMEWRD structures returned in <c>pchBuffer</c>. If more entries are found than <c>pchBuffer</c> can store,
			/// <c>IFED_S_MORE_ENTRIES</c> will be returned.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <description><c>S_OK</c></description>
			/// <description></description>
			/// </item>
			/// <item>
			/// <description><c>IFED_S_MORE_ENTRIES</c></description>
			/// <description>The client must call NextWords to get additional IMEWRD structures.</description>
			/// </item>
			/// <item>
			/// <description><c>IFED_E_NO_ENTRY</c></description>
			/// <description></description>
			/// </item>
			/// <item>
			/// <description><c>E_OUTOFMEMORY</c></description>
			/// <description></description>
			/// </item>
			/// <item>
			/// <description><c>E_FAIL</c></description>
			/// <description></description>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifedictionary-getwords HRESULT GetWords( [in] const WCHAR
			// *pwchFirst, [in] const WCHAR *pwchLast, [in] const WCHAR *pwchDisplay, [in] ULONG ulPos, [in] ULONG ulSelect, [in] ULONG
			// ulWordSrc, [in, out] UCHAR *pchBuffer, [in] ULONG cbBuffer, [out] ULONG *pcWrd );
			[PreserveSig]
			HRESULT GetWords([MarshalAs(UnmanagedType.LPWStr)] string pwchFirst, [MarshalAs(UnmanagedType.LPWStr)] string pwchLast,
				[MarshalAs(UnmanagedType.LPWStr)] string pwchDisplay, IFED_POS ulPos, IFED_SELECT ulSelect, IFED_REG ulWordSrc,
				IntPtr pchBuffer, uint cbBuffer, out uint pcWrd);

			/// <summary>This method is used only after GetWords to get additional words.</summary>
			/// <param name="pchBuffer">Buffer provided by the caller to receive the data.</param>
			/// <param name="cbBuffer">The size of <c>pchBuffer</c>.</param>
			/// <param name="pcWrd">
			/// The number of IMEWRD structures returned in <c>pchBuffer</c>. If more entries are found than <c>pchBuffer</c> can store,
			/// <c>IFED_S_MORE_ENTRIES</c> will be returned.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>S_OK</c></term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term><c>IFED_S_MORE_ENTRIES</c></term>
			/// <term>The client must call NextWords to get additional IMEWRD structures.</term>
			/// </item>
			/// <item>
			/// <term><c>E_FAIL</c></term>
			/// <term/>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifedictionary-nextwords HRESULT NextWords( [in, out] UCHAR
			// *pchBuffer, [in] ULONG cbBuffer, [out] ULONG *pcWrd );
			[PreserveSig]
			HRESULT NextWords(IntPtr pchBuffer, uint cbBuffer, out uint pcWrd);

			/// <summary>Creates a new dictionary file.</summary>
			/// <param name="pchDictPath">
			/// A <c>NULL</c>-terminated string containing the path and name for the new dictionary file to be created.
			/// </param>
			/// <param name="pshf">The IMESHF header for the new dictionary.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifedictionary-create HRESULT Create( [in] const CHAR
			// *pchDictPath, [in] IMESHF *pshf );
			void Create([MarshalAs(UnmanagedType.LPStr)] string pchDictPath, in IMESHF pshf);

			/// <summary>This method sets or modifies the dictionary header of this IFEDictionary object.</summary>
			/// <param name="pshf">The IMESHF header to set.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifedictionary-setheader HRESULT SetHeader( [in] IMESHF *pshf );
			void SetHeader(in IMESHF pshf);

			/// <summary>Determines if the specified word exists in IFEDictionary.</summary>
			/// <param name="pwrd">An IMEWRD structure specifying the word to check.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>S_OK</c></term>
			/// <term>The word exists.</term>
			/// </item>
			/// <item>
			/// <term><c>S_FALSE</c></term>
			/// <term>The word does not exist.</term>
			/// </item>
			/// <item>
			/// <term><c>E_FAIL</c></term>
			/// <term>An unexpected error.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifedictionary-existword HRESULT ExistWord( [in] IMEWRD *pwrd );
			[PreserveSig]
			HRESULT ExistWord(in IMEWRD pwrd);

			/// <summary>See if dependency pair exist in dictionary</summary>
			/// <param name="pdp">The dependency pair.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>S_OK</c></term>
			/// <term>The pair exists.</term>
			/// </item>
			/// <item>
			/// <term><c>S_FALSE</c></term>
			/// <term>The pair does not exist.</term>
			/// </item>
			/// <item>
			/// <term><c>E_FAIL</c></term>
			/// <term>An unexpected error.</term>
			/// </item>
			/// </list>
			/// </returns>
			[PreserveSig]
			HRESULT ExistDependency(in IMEDP pdp);

			/// <summary>Registers a new word or deletes an existing word in the IFEDictionary.</summary>
			/// <param name="reg">
			/// <para>Type of operation to perform. This can be one of the following values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>IFED_REG_HEAD</c></term>
			/// <term>Register the word at the head of the dictionary.</term>
			/// </item>
			/// <item>
			/// <term><c>IFED_REG_TAIL</c></term>
			/// <term>Register the word at the tail of the dictionary.</term>
			/// </item>
			/// <item>
			/// <term><c>IFED_REG_DEL</c></term>
			/// <term>Delete the word from the dictionary.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pwrd">An IMEWRD structure specifying the word to register or delete.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>S_OK</c></term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term><c>IFED_E_NOT_USER_DIC</c></term>
			/// <term>This IFEDictionary object is not a user dictionary.</term>
			/// </item>
			/// <item>
			/// <term><c>IFED_S_WORD_EXISTS</c></term>
			/// <term>The word is already registered.</term>
			/// </item>
			/// <item>
			/// <term><c>IFED_E_USER_COMMENT</c></term>
			/// <term>Failed to insert the user comment.</term>
			/// </item>
			/// <item>
			/// <term><c>S_FALSE</c></term>
			/// <term>Failed to register or delete the word.</term>
			/// </item>
			/// <item>
			/// <term><c>E_FAIL</c></term>
			/// <term>An unexpected error.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifedictionary-registerword HRESULT RegisterWord( [in] IMEREG
			// reg, [in] IMEWRD *pwrd );
			[PreserveSig]
			HRESULT RegisterWord(IMEREG reg, in IMEWRD pwrd);

			/// <summary>Registers a new dependency or deletes an existing dependency in the IFEDictionary.</summary>
			/// <param name="reg">
			/// <para>Type of operation to perform. This can be one of the following values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>IFED_REG_HEAD</c></term>
			/// <term>Register the dependency at the head of the dictionary.</term>
			/// </item>
			/// <item>
			/// <term><c>IFED_REG_TAIL</c></term>
			/// <term>Register the dependency at the tail of the dictionary.</term>
			/// </item>
			/// <item>
			/// <term><c>IFED_REG_DEL</c></term>
			/// <term>Delete the dependency from the dictionary.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="pdp">An IMEDP structure specifying the dependency to register or delete.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>S_OK</c></term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term><c>IFED_E_NOT_USER_DIC</c></term>
			/// <term>This IFEDictionary object is not a user dictionary.</term>
			/// </item>
			/// <item>
			/// <term><c>IFED_S_WORD_EXISTS</c></term>
			/// <term>The dependency is already registered.</term>
			/// </item>
			/// <item>
			/// <term><c>IFED_E_USER_COMMENT</c></term>
			/// <term>Failed to insert the user comment.</term>
			/// </item>
			/// <item>
			/// <term><c>S_FALSE</c></term>
			/// <term>Failed to register or delete the dependency.</term>
			/// </item>
			/// <item>
			/// <term><c>E_FAIL</c></term>
			/// <term>An unexpected error.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifedictionary-registerword HRESULT RegisterWord( [in] IMEREG
			// reg, [in] IMEWRD *pwrd );
			[PreserveSig]
			HRESULT RegisterDependency(IMEREG reg, in IMEDP pdp);

			/// <summary>Undocumented</summary>
			/// <param name="pwchKakariReading">The kakarigo reading.</param>
			/// <param name="pwchKakariDisplay">The kakarigo display.</param>
			/// <param name="ulKakariPos">The part of speech for kakarigo.</param>
			/// <param name="pwchUkeReading">The ukego reading.</param>
			/// <param name="pwchUkeDisplay">The ukego display.</param>
			/// <param name="ulUkePos">The part of speech for uke.</param>
			/// <param name="jrel">The relation type.</param>
			/// <param name="ulWordSrc">
			/// <para>
			/// Specifies the word source. When the IFEDictionary is a user dictionary, this is a combination of one or more of the following flags:
			/// </para>
			/// <list type="bullet">
			/// <item>IFED_REG_NONE</item>
			/// <item>IFED_REG_USER</item>
			/// <item>IFED_REG_AUTO</item>
			/// <item>IFED_REG_GRAMMAR</item>
			/// <item>IFED_REG_ALL</item>
			/// </list>
			/// </param>
			/// <param name="pchBuffer">Buffer provided by the caller to receive the data.</param>
			/// <param name="cbBuffer">The size of <c>pchBuffer</c>.</param>
			/// <param name="pcdp">
			/// The number of IMEDP structures returned in <c>pchBuffer</c>. If more entries are found than <c>pchBuffer</c> can store,
			/// <c>IFED_S_MORE_ENTRIES</c> will be returned.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <description><c>S_OK</c></description>
			/// <description></description>
			/// </item>
			/// <item>
			/// <description><c>IFED_S_MORE_ENTRIES</c></description>
			/// <description>The client must call NextWords to get additional IMEDP structures.</description>
			/// </item>
			/// <item>
			/// <description><c>IFED_E_NO_ENTRY</c></description>
			/// <description></description>
			/// </item>
			/// <item>
			/// <description><c>E_OUTOFMEMORY</c></description>
			/// <description></description>
			/// </item>
			/// <item>
			/// <description><c>E_FAIL</c></description>
			/// <description></description>
			/// </item>
			/// </list>
			/// </returns>
			[PreserveSig]
			HRESULT GetDependencies([MarshalAs(UnmanagedType.LPWStr)] string pwchKakariReading, [MarshalAs(UnmanagedType.LPWStr)] string pwchKakariDisplay,
				uint ulKakariPos, [MarshalAs(UnmanagedType.LPWStr)] string pwchUkeReading, [MarshalAs(UnmanagedType.LPWStr)] string pwchUkeDisplay,
				uint ulUkePos, IMEREL jrel, IFED_REG ulWordSrc, IntPtr pchBuffer, uint cbBuffer, out uint pcdp);

			/// <summary>This method is used only after GetWords to get additional dependencies.</summary>
			/// <param name="pchBuffer">Buffer provided by the caller to receive the data.</param>
			/// <param name="cbBuffer">The size of <c>pchBuffer</c>.</param>
			/// <param name="pcdp">
			/// The number of IMEDP structures returned in <c>pchBuffer</c>. If more entries are found than <c>pchBuffer</c> can store,
			/// <c>IFED_S_MORE_ENTRIES</c> will be returned.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>S_OK</c></term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term><c>IFED_S_MORE_ENTRIES</c></term>
			/// <term>The client must call NextWords to get additional IMEDP structures.</term>
			/// </item>
			/// <item>
			/// <term><c>E_FAIL</c></term>
			/// <term/>
			/// </item>
			/// </list>
			/// </returns>
			[PreserveSig]
			HRESULT NextDependencies(IntPtr pchBuffer, uint cbBuffer, out uint pcdp);

			/// <summary>Undocumented</summary>
			/// <param name="pchDic">old ime user dictionary path</param>
			/// <param name="pfnLog">pointer to log function</param>
			/// <param name="reg">word registration info</param>
			/// <returns></returns>
			[PreserveSig]
			HRESULT ConvertFromOldMSIME([MarshalAs(UnmanagedType.LPStr)] string pchDic, PFNLOG pfnLog, IMEREG reg);

			/// <summary>Undocumented</summary>
			/// <returns></returns>
			[PreserveSig]
			HRESULT ConvertFromUserToSys();
		}

		/// <summary>The IFELanguage interface provides language processing services using the Microsoft IME.</summary>
		/// <remarks>Create an instance of this interface with the CreateIFELanguageInstance function.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msime/nn-msime-ifelanguage
		[PInvokeData("msime.h", MSDNShortId = "NN:msime.IFELanguage")]
		[ComImport, Guid("019F7152-E6DB-11d0-83C3-00C04FDDB82E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IFELanguage
		{
			/// <summary>This method must be called before any use of the IFELanguage object.</summary>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifelanguage-open HRESULT Open();
			void Open();

			/// <summary>This method must be called after your last use of the IFELanguage object.</summary>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifelanguage-close HRESULT Close();
			void Close();

			/// <summary>Gets morphological analysis results.</summary>
			/// <param name="dwRequest">
			/// <para>The conversion request. It can be one of the following values:</para>
			/// <para>FELANG_REQ_CONV</para>
			/// <para>FELANG_REQ_RECONV</para>
			/// <para>FELANG_REQ_REV</para>
			/// </param>
			/// <param name="dwCMode">
			/// <para>
			/// Specifies the conversion output characters and conversion options. This value is a combination of one or more of the
			/// following flags:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>FELANG_CMODE_MONORUBY</c></term>
			/// <term>Mono-ruby.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_NOPRUNING</c></term>
			/// <term>No pruning.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_KATAKANAOUT</c></term>
			/// <term>Katakana output.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_HIRAGANAOUT</c></term>
			/// <term>Default output.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_HALFWIDTHOUT</c></term>
			/// <term>Half-width output.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_FULLWIDTHOUT</c></term>
			/// <term>Full-width output.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_BOPOMOFO</c></term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_HANGUL</c></term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_PINYIN</c></term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_PRECONV</c></term>
			/// <term>Do conversion as follows:</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_RADICAL</c></term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_UNKNOWNREADING</c></term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_MERGECAND</c></term>
			/// <term>Merge display with the same candidate.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_ROMAN</c></term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_BESTFIRST</c></term>
			/// <term>Make only the first best.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_USENOREVWORDS</c></term>
			/// <term>Use invalid revword on REV/RECONV.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_NONE</c></term>
			/// <term>IME_SMODE_NONE</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_PLAURALCLAUSE</c></term>
			/// <term>IME_SMODE_PLAURALCLAUSE</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_SINGLECONVERT</c></term>
			/// <term>IME_SMODE_SINGLECONVERT</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_AUTOMATIC</c></term>
			/// <term>IME_SMODE_AUTOMATIC</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_PHRASEPREDICT</c></term>
			/// <term>IME_SMODE_PHRASEPREDICT</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_CONVERSATION</c></term>
			/// <term>IME_SMODE_CONVERSATION</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_NAME</c></term>
			/// <term>Name mode (MSKKIME).</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_NOINVISIBLECHAR</c></term>
			/// <term>Remove invisible chars (for example, the tone mark).</term>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="cwchInput">The number of characters in <c>pwchInput</c>.</param>
			/// <param name="pwchInput">
			/// <para>Input characters to be converted by the morphology engine. This must be a UNICODE string.</para>
			/// <para>
			/// Set this parameter to <c>NULL</c> to get the next entry for the previously input string, with the next rank. The order in
			/// which next entries are returned is defined by the implementation.
			/// </para>
			/// </param>
			/// <param name="pfCInfo">
			/// <para>
			/// The information for each column, where each <c>pfCInfo[x]</c> corresponds to <c>pwchInput[x]</c>. Each <c>DWORD</c> can be a
			/// combination of the flags below:
			/// </para>
			/// <para>FELANG_CLMN_WBREAK</para>
			/// <para>FELANG_CLMN_NOWBREAK</para>
			/// <para>FELANG_CLMN_PBREAK</para>
			/// <para>FELANG_CLMN_NOPBREAK</para>
			/// <para>FELANG_CLMN_FIXR</para>
			/// <para>FELANG_CLMN_FIXD</para>
			/// </param>
			/// <param name="ppResult">
			/// <para>The address of a MORRSLT structure that receives the morphology result data.</para>
			/// <para>
			/// <c>GetJMorphResult</c> allocates memory using the OLE task allocator for the returned data, and sets the <c>pResult</c> to
			/// point to the memory. The application must free the memory pointed to by <c>pResult</c>, by using the CoTaskMemFree.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>S_OK</c></term>
			/// <term>
			/// More candidates exist. If you call this function again with <c>pwchInput</c> equal to <c>NULL</c>, it will get the next best
			/// candidate for the previous <c>pwchInput</c>.
			/// </term>
			/// </item>
			/// <item>
			/// <term><c>S_FALSE</c></term>
			/// <term>No result.</term>
			/// </item>
			/// <item>
			/// <term><c>E_NOCAND</c></term>
			/// <term>No more candidates.</term>
			/// </item>
			/// <item>
			/// <term><c>E_LARGEINPUT</c></term>
			/// <term>input too large.</term>
			/// </item>
			/// <item>
			/// <term><c>ERROR_SEM_TIMEOUT</c></term>
			/// <term>Mutex timeout is occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifelanguage-getjmorphresult HRESULT GetJMorphResult( [in]
			// DWORD dwRequest, [in] DWORD dwCMode, [in] INT cwchInput, [in] const WCHAR *pwchInput, [in] DWORD *pfCInfo, [out] MORRSLT
			// **ppResult );
			[PreserveSig]
			HRESULT GetJMorphResult(FELANG_REQ dwRequest, FELANG_CMODE dwCMode, int cwchInput, [MarshalAs(UnmanagedType.LPWStr)] string pwchInput,
				[MarshalAs(UnmanagedType.LPArray)] FELANG_CLMN[] pfCInfo, out SafeCoTaskMemStruct<MORRSLT> ppResult);

			/// <summary>Gets the conversion mode capability of the IFELanguage object.</summary>
			/// <param name="pdwCaps">
			/// <para>The capabilities, represented as a combination of one or more of the following flags:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>FELANG_CMODE_MONORUBY</c></term>
			/// <term>Mono-ruby.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_NOPRUNING</c></term>
			/// <term>No pruning.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_KATAKANAOUT</c></term>
			/// <term>Katakana output.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_HIRAGANAOUT</c></term>
			/// <term>Default output.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_HALFWIDTHOUT</c></term>
			/// <term>Half-width output.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_FULLWIDTHOUT</c></term>
			/// <term>Full-width output.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_BOPOMOFO</c></term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_HANGUL</c></term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_PINYIN</c></term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_PRECONV</c></term>
			/// <term>Do conversion as follows:</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_RADICAL</c></term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_UNKNOWNREADING</c></term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_MERGECAND</c></term>
			/// <term>Merge display with the same candidate.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_ROMAN</c></term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_BESTFIRST</c></term>
			/// <term>Make only the first best.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_USENOREVWORDS</c></term>
			/// <term>Use invalid revword on REV/RECONV.</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_NONE</c></term>
			/// <term>IME_SMODE_NONE</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_PLAURALCLAUSE</c></term>
			/// <term>IME_SMODE_PLAURALCLAUSE</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_SINGLECONVERT</c></term>
			/// <term>IME_SMODE_SINGLECONVERT</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_AUTOMATIC</c></term>
			/// <term>IME_SMODE_AUTOMATIC</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_PHRASEPREDICT</c></term>
			/// <term>IME_SMODE_PHRASEPREDICT</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_CONVERSATION</c></term>
			/// <term>IME_SMODE_CONVERSATION</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_NAME</c></term>
			/// <term>Name mode (MSKKIME).</term>
			/// </item>
			/// <item>
			/// <term><c>FELANG_CMODE_NOINVISIBLECHAR</c></term>
			/// <term>Remove invisible chars (for example, the tone mark).</term>
			/// </item>
			/// </list>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifelanguage-getconversionmodecaps HRESULT
			// GetConversionModeCaps( [out] DWORD *pdwCaps );
			void GetConversionModeCaps(out FELANG_CMODE pdwCaps);

			void GetPhonetic([MarshalAs(UnmanagedType.BStr)] string @string, int start, int length, [MarshalAs(UnmanagedType.BStr)] out string phonetic);

			/// <summary>Converts the input string (which usually contains the Hiragana character) to converted strings.</summary>
			/// <param name="string">A string of phonetic characters to convert.</param>
			/// <param name="start">
			/// The starting character from which IFELanguage begins conversion. The first character of <c>string</c> is represented by 1
			/// (not 0).
			/// </param>
			/// <param name="length">
			/// The number of characters to convert. If this value is -1, all of the remaining characters from <c>start</c> are converted.
			/// </param>
			/// <param name="result">The converted string. This string is allocated by SysAllocStringLen and must be freed by the client.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/msime/nf-msime-ifelanguage-getconversion HRESULT GetConversion( [in] BSTR
			// string, [in] LONG start, [in] LONG length, [out, retval] BSTR *result );
			void GetConversion([MarshalAs(UnmanagedType.BStr)] string @string, int start, int length, [MarshalAs(UnmanagedType.BStr)] out string result);
		}

		/// <summary>Used when invoking the Microsoft IME's Dictionary Tool or Word Register Dialog Window from the app.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msime/ns-msime-imedlg typedef struct _IMEDLG { int cbIMEDLG; HWND hwnd; LPWSTR
		// lpwstrWord; int nTabId; } IMEDLG;
		[PInvokeData("msime.h", MSDNShortId = "NS:msime._IMEDLG")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IMEDLG
		{
			/// <summary>The size of this structure. You must set this value before using the structure.</summary>
			public int cbIMEDLG;

			/// <summary>The parent window handle of the Register Word Dialog.</summary>
			public HWND hwnd;

			/// <summary><see langword="null"/>, or the string to be registered. It shows in the Word Register Dialog's "Display" field.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpwstrWord;

			/// <summary>The initial tab ID, 0 or 1.</summary>
			public int nTabId;

			/// <summary>Initializes a new instance of the <see cref="IMEDLG"/> struct.</summary>
			/// <param name="hwnd">The parent window handle of the Register Word Dialog.</param>
			/// <param name="display">
			/// <see langword="null"/>, or the string to be registered. It shows in the Word Register Dialog's "Display" field.
			/// </param>
			/// <param name="tabId">The initial tab ID, 0 or 1.</param>
			public IMEDLG(HWND hwnd, string display = null, int tabId = 0)
			{
				cbIMEDLG = Marshal.SizeOf(typeof(IMEDLG));
				this.hwnd = hwnd;
				lpwstrWord = display;
				nTabId = tabId;
			}
		}

		[PInvokeData("msime.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IMEDP
		{
			public IMEWRD wrdModifier;    //kakari-go
			public IMEWRD wrdModifiee;    //uke-go
			public IMEREL relID;
		}

		/// <summary>
		/// The header of an opened user dictionary file. Used to get the user dictionary's properties, such as version, title, description,
		/// and copyright.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msime/ns-msime-imeshf typedef struct _IMESHF { WORD cbShf; WORD verDic; CHAR
		// szTitle[48]; CHAR szDescription[256]; CHAR szCopyright[128]; } IMESHF;
		[PInvokeData("msime.h", MSDNShortId = "NS:msime._IMESHF")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IMESHF
		{
			/// <summary>The size of this structure. You must set this value before using the structure.</summary>
			public ushort cbShf;

			/// <summary>Dictionary version.</summary>
			public ushort verDic;

			/// <summary>Dictionary title.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
			public string szTitle;

			/// <summary>Dictionary description.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string szDescription;

			/// <summary>Dictionary copyright information.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string szCopyright;
		}

		/// <summary>Contains data about a word in the Word data of the Microsoft IME dictionary.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msime/ns-msime-imewrd typedef struct _IMEWRD { WCHAR *pwchReading; WCHAR
		// *pwchDisplay; union { ULONG ulPos; struct { WORD nPos1; WORD nPos2; }; }; ULONG rgulAttrs[2]; INT cbComment; IMEUCT uct; VOID
		// *pvComment; } IMEWRD, *PIMEWRD;
		[PInvokeData("msime.h", MSDNShortId = "NS:msime._IMEWRD")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IMEWRD
		{
			/// <summary>The reading string.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pwchReading;

			/// <summary>The display string.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pwchDisplay;

			/// <summary>POS (Part of Speech), defined as JPOS_***.</summary>
			public uint ulPos;

			/// <summary>Reserved.</summary>
			public ulong rgulAttrs;

			/// <summary>Size of the comment, in bytes, of pvComment.</summary>
			public int cbComment;

			/// <summary>Type of comment. This must be one of the values of the IMEUCT enumeration.</summary>
			public IMEUCT uct;

			/// <summary>Comment string.</summary>
			public IntPtr pvComment;
		}

		/// <summary>Undocumented.</summary>
		[PInvokeData("msime.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MORRSLT
		{
			/// <summary>total size of this block.</summary>
			public uint dwSize;

			/// <summary>conversion result string.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pwchOutput;

			/// <summary>lengh of result string.</summary>
			public ushort cchOutput;

			/// <summary>reading string</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pwchRead;

			/// <summary>length of reading string.</summary>
			public ushort cchRead;

			/// <summary>index array of reading to input character.</summary>
			public IntPtr pchInputPos;

			/// <summary>index array of output character to WDD</summary>
			public IntPtr pchOutputIdxWDD;

			/// <summary>index array of reading character to WDD</summary>
			public IntPtr pchReadIdxWDD;

			/// <summary>array of position of monoruby</summary>
			public IntPtr paMonoRubyPos;

			/// <summary>pointer to array of WDD</summary>
			public IntPtr pWDD;

			/// <summary>number of WDD</summary>
			public int cWDD;

			/// <summary>pointer of private data area</summary>
			public IntPtr pPrivate;

			/// <summary>
			/// area for stored above members.
			/// <para>ushort wchOutput[cchOutput];</para>
			/// <para>ushort wchRead[cchRead];</para>
			/// <para>sbyte chInputIdx[cwchInput];</para>
			/// <para>sbyte chOutputIdx[cchOutput];</para>
			/// <para>sbyte chReadIndx[cchRead];</para>
			/// <para>???? Private</para>
			/// <para>WDD WDDBlk[cWDD];</para>
			/// </summary>
			public IntPtr BLKBuff;
		}

		/// <summary>An entry in the public POS (Part of Speech) table.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/msime/ns-msime-postbl typedef struct _POSTBL { WORD nPos; BYTE *szName; } POSTBL;
		[PInvokeData("msime.h", MSDNShortId = "NS:msime._POSTBL")]
		[StructLayout(LayoutKind.Sequential)]
		public struct POSTBL
		{
			/// <summary>The number of the part of speech.</summary>
			public ushort nPos;

			/// <summary>The name of the part of speech.</summary>
			public IntPtr szName;
		}

		/*
		// Word Descriptor
		public struct WDD
		{
			WORD        wDispPos;   // Offset of Output string
			union {
				WORD    wReadPos;   // Offset of Reading string
				WORD    wCompPos;
			};

			WORD        cchDisp;    //number of ptchDisp
			union {
				WORD    cchRead;    //number of ptchRead
				WORD    cchComp;
			};

			DWORD       WDD_nReserve1;   //reserved

			WORD        nPos;       //part of speech

									// implementation-defined
			WORD        fPhrase : 1;//start of phrase
			WORD        fAutoCorrect: 1;//auto-corrected
			WORD        fNumericPrefix: 1;//kansu-shi expansion(JPN)
			WORD        fUserRegistered: 1;//from user dictionary
			WORD        fUnknown: 1;//unknown word (duplicated information with nPos.)
			WORD        fRecentUsed: 1; //used recently flag
			WORD        :10;        //

			VOID        *pReserved; //points directly to WORDITEM
		}
		*/
	}
}