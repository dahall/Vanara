using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>
	/// Managed instance of the 16 bit LANGID type.
	/// <para>
	/// A language identifier is a standard international numeric abbreviation for the language in a country or geographical region. Each
	/// language has a unique language identifier (data type LANGID), a 16-bit value that consists of a primary language identifier and a
	/// sublanguage identifier.
	/// </para>
	/// </summary>
	[StructLayout(LayoutKind.Sequential), Serializable]
	[TypeConverter(typeof(LANGIDTypeConverter))]
	public struct LANGID : IEquatable<LANGID>, IEquatable<ushort>, IConvertible, IComparable
	{
		/// <summary>Primary language identifier.</summary>
		public enum LANG : ushort
		{
			LANG_NEUTRAL = 0x00,
			LANG_INVARIANT = 0x7f,
			LANG_AFRIKAANS = 0x36,
			LANG_ALBANIAN = 0x1c,
			LANG_ALSATIAN = 0x84,
			LANG_AMHARIC = 0x5e,
			LANG_ARABIC = 0x01,
			LANG_ARMENIAN = 0x2b,
			LANG_ASSAMESE = 0x4d,
			LANG_AZERI = 0x2c,   // for Azerbaijani, LANG_AZERBAIJANI is preferred
			LANG_AZERBAIJANI = 0x2c,
			LANG_BANGLA = 0x45,
			LANG_BASHKIR = 0x6d,
			LANG_BASQUE = 0x2d,
			LANG_BELARUSIAN = 0x23,
			LANG_BENGALI = 0x45,   // Some prefer to use LANG_BANGLA
			LANG_BRETON = 0x7e,
			LANG_BOSNIAN = 0x1a,   // Use with SUBLANG_BOSNIAN_* Sublanguage IDs
			LANG_BOSNIAN_NEUTRAL = 0x781a,   // Use with the ConvertDefaultLocale function
			LANG_BULGARIAN = 0x02,
			LANG_CATALAN = 0x03,
			LANG_CENTRAL_KURDISH = 0x92,
			LANG_CHEROKEE = 0x5c,
			LANG_CHINESE = 0x04,   // Use with SUBLANG_CHINESE_* Sublanguage IDs
			LANG_CHINESE_SIMPLIFIED = 0x04,   // Use with the ConvertDefaultLocale function
			LANG_CHINESE_TRADITIONAL = 0x7c04,   // Use with the ConvertDefaultLocale function
			LANG_CORSICAN = 0x83,
			LANG_CROATIAN = 0x1a,
			LANG_CZECH = 0x05,
			LANG_DANISH = 0x06,
			LANG_DARI = 0x8c,
			LANG_DIVEHI = 0x65,
			LANG_DUTCH = 0x13,
			LANG_ENGLISH = 0x09,
			LANG_ESTONIAN = 0x25,
			LANG_FAEROESE = 0x38,
			LANG_FARSI = 0x29,   // Deprecated: use LANG_PERSIAN instead
			LANG_FILIPINO = 0x64,
			LANG_FINNISH = 0x0b,
			LANG_FRENCH = 0x0c,
			LANG_FRISIAN = 0x62,
			LANG_FULAH = 0x67,
			LANG_GALICIAN = 0x56,
			LANG_GEORGIAN = 0x37,
			LANG_GERMAN = 0x07,
			LANG_GREEK = 0x08,
			LANG_GREENLANDIC = 0x6f,
			LANG_GUJARATI = 0x47,
			LANG_HAUSA = 0x68,
			LANG_HAWAIIAN = 0x75,
			LANG_HEBREW = 0x0d,
			LANG_HINDI = 0x39,
			LANG_HUNGARIAN = 0x0e,
			LANG_ICELANDIC = 0x0f,
			LANG_IGBO = 0x70,
			LANG_INDONESIAN = 0x21,
			LANG_INUKTITUT = 0x5d,
			LANG_IRISH = 0x3c,   // Use with the SUBLANG_IRISH_IRELAND Sublanguage ID
			LANG_ITALIAN = 0x10,
			LANG_JAPANESE = 0x11,
			LANG_KANNADA = 0x4b,
			LANG_KASHMIRI = 0x60,
			LANG_KAZAK = 0x3f,
			LANG_KHMER = 0x53,
			LANG_KICHE = 0x86,
			LANG_KINYARWANDA = 0x87,
			LANG_KONKANI = 0x57,
			LANG_KOREAN = 0x12,
			LANG_KYRGYZ = 0x40,
			LANG_LAO = 0x54,
			LANG_LATVIAN = 0x26,
			LANG_LITHUANIAN = 0x27,
			LANG_LOWER_SORBIAN = 0x2e,
			LANG_LUXEMBOURGISH = 0x6e,
			LANG_MACEDONIAN = 0x2f,   // the Former Yugoslav Republic of Macedonia
			LANG_MALAY = 0x3e,
			LANG_MALAYALAM = 0x4c,
			LANG_MALTESE = 0x3a,
			LANG_MANIPURI = 0x58,
			LANG_MAORI = 0x81,
			LANG_MAPUDUNGUN = 0x7a,
			LANG_MARATHI = 0x4e,
			LANG_MOHAWK = 0x7c,
			LANG_MONGOLIAN = 0x50,
			LANG_NEPALI = 0x61,
			LANG_NORWEGIAN = 0x14,
			LANG_OCCITAN = 0x82,
			LANG_ODIA = 0x48,
			LANG_ORIYA = 0x48,   // Deprecated: use LANG_ODIA, instead.
			LANG_PASHTO = 0x63,
			LANG_PERSIAN = 0x29,
			LANG_POLISH = 0x15,
			LANG_PORTUGUESE = 0x16,
			LANG_PULAR = 0x67,   // Deprecated: use LANG_FULAH instead
			LANG_PUNJABI = 0x46,
			LANG_QUECHUA = 0x6b,
			LANG_ROMANIAN = 0x18,
			LANG_ROMANSH = 0x17,
			LANG_RUSSIAN = 0x19,
			LANG_SAKHA = 0x85,
			LANG_SAMI = 0x3b,
			LANG_SANSKRIT = 0x4f,
			LANG_SCOTTISH_GAELIC = 0x91,
			LANG_SERBIAN = 0x1a,   // Use with the SUBLANG_SERBIAN_* Sublanguage IDs
			LANG_SERBIAN_NEUTRAL = 0x7c1a,   // Use with the ConvertDefaultLocale function
			LANG_SINDHI = 0x59,
			LANG_SINHALESE = 0x5b,
			LANG_SLOVAK = 0x1b,
			LANG_SLOVENIAN = 0x24,
			LANG_SOTHO = 0x6c,
			LANG_SPANISH = 0x0a,
			LANG_SWAHILI = 0x41,
			LANG_SWEDISH = 0x1d,
			LANG_SYRIAC = 0x5a,
			LANG_TAJIK = 0x28,
			LANG_TAMAZIGHT = 0x5f,
			LANG_TAMIL = 0x49,
			LANG_TATAR = 0x44,
			LANG_TELUGU = 0x4a,
			LANG_THAI = 0x1e,
			LANG_TIBETAN = 0x51,
			LANG_TIGRIGNA = 0x73,
			LANG_TIGRINYA = 0x73,   // Preferred spelling in locale
			LANG_TSWANA = 0x32,
			LANG_TURKISH = 0x1f,
			LANG_TURKMEN = 0x42,
			LANG_UIGHUR = 0x80,
			LANG_UKRAINIAN = 0x22,
			LANG_UPPER_SORBIAN = 0x2e,
			LANG_URDU = 0x20,
			LANG_UZBEK = 0x43,
			LANG_VALENCIAN = 0x03,
			LANG_VIETNAMESE = 0x2a,
			LANG_WELSH = 0x52,
			LANG_WOLOF = 0x88,
			LANG_XHOSA = 0x34,
			LANG_YAKUT = 0x85,   // Deprecated: use LANG_SAKHA,instead
			LANG_YI = 0x78,
			LANG_YORUBA = 0x6a,
			LANG_ZULU = 0x35,
		}

		/// <summary>Sublanguage identifier.</summary>
		public enum SUBLANG : byte
		{
			/// <summary>language neutral</summary>
			SUBLANG_NEUTRAL = 0x00,

			/// <summary>user default</summary>
			SUBLANG_DEFAULT = 0x01,

			/// <summary>system default</summary>
			SUBLANG_SYS_DEFAULT = 0x02,

			/// <summary>default custom language/locale</summary>
			SUBLANG_CUSTOM_DEFAULT = 0x03,

			/// <summary>custom language/locale</summary>
			SUBLANG_CUSTOM_UNSPECIFIED = 0x04,

			/// <summary>Default custom MUI language/locale</summary>
			SUBLANG_UI_CUSTOM_DEFAULT = 0x05,

			/// <summary>Afrikaans (South Africa) 0x0436 af-ZA</summary>
			SUBLANG_AFRIKAANS_SOUTH_AFRICA = 0x01,

			/// <summary>Albanian (Albania) 0x041c sq-AL</summary>
			SUBLANG_ALBANIAN_ALBANIA = 0x01,

			/// <summary>Alsatian (France) 0x0484</summary>
			SUBLANG_ALSATIAN_FRANCE = 0x01,

			/// <summary>Amharic (Ethiopia) 0x045e</summary>
			SUBLANG_AMHARIC_ETHIOPIA = 0x01,

			/// <summary>Arabic (Saudi Arabia)</summary>
			SUBLANG_ARABIC_SAUDI_ARABIA = 0x01,

			/// <summary>Arabic (Iraq)</summary>
			SUBLANG_ARABIC_IRAQ = 0x02,

			/// <summary>Arabic (Egypt)</summary>
			SUBLANG_ARABIC_EGYPT = 0x03,

			/// <summary>Arabic (Libya)</summary>
			SUBLANG_ARABIC_LIBYA = 0x04,

			/// <summary>Arabic (Algeria)</summary>
			SUBLANG_ARABIC_ALGERIA = 0x05,

			/// <summary>Arabic (Morocco)</summary>
			SUBLANG_ARABIC_MOROCCO = 0x06,

			/// <summary>Arabic (Tunisia)</summary>
			SUBLANG_ARABIC_TUNISIA = 0x07,

			/// <summary>Arabic (Oman)</summary>
			SUBLANG_ARABIC_OMAN = 0x08,

			/// <summary>Arabic (Yemen)</summary>
			SUBLANG_ARABIC_YEMEN = 0x09,

			/// <summary>Arabic (Syria)</summary>
			SUBLANG_ARABIC_SYRIA = 0x0a,

			/// <summary>Arabic (Jordan)</summary>
			SUBLANG_ARABIC_JORDAN = 0x0b,

			/// <summary>Arabic (Lebanon)</summary>
			SUBLANG_ARABIC_LEBANON = 0x0c,

			/// <summary>Arabic (Kuwait)</summary>
			SUBLANG_ARABIC_KUWAIT = 0x0d,

			/// <summary>Arabic (U.A.E)</summary>
			SUBLANG_ARABIC_UAE = 0x0e,

			/// <summary>Arabic (Bahrain)</summary>
			SUBLANG_ARABIC_BAHRAIN = 0x0f,

			/// <summary>Arabic (Qatar)</summary>
			SUBLANG_ARABIC_QATAR = 0x10,

			/// <summary>Armenian (Armenia) 0x042b hy-AM</summary>
			SUBLANG_ARMENIAN_ARMENIA = 0x01,

			/// <summary>Assamese (India) 0x044d</summary>
			SUBLANG_ASSAMESE_INDIA = 0x01,

			/// <summary>Azeri (Latin) - for Azerbaijani, SUBLANG_AZERBAIJANI_AZERBAIJAN_LATIN preferred</summary>
			SUBLANG_AZERI_LATIN = 0x01,

			/// <summary>Azeri (Cyrillic) - for Azerbaijani, SUBLANG_AZERBAIJANI_AZERBAIJAN_CYRILLIC preferred</summary>
			SUBLANG_AZERI_CYRILLIC = 0x02,

			/// <summary>Azerbaijani (Azerbaijan, Latin)</summary>
			SUBLANG_AZERBAIJANI_AZERBAIJAN_LATIN = 0x01,

			/// <summary>Azerbaijani (Azerbaijan, Cyrillic)</summary>
			SUBLANG_AZERBAIJANI_AZERBAIJAN_CYRILLIC = 0x02,

			/// <summary>Bangla (India)</summary>
			SUBLANG_BANGLA_INDIA = 0x01,

			/// <summary>Bangla (Bangladesh)</summary>
			SUBLANG_BANGLA_BANGLADESH = 0x02,

			/// <summary>Bashkir (Russia) 0x046d ba-RU</summary>
			SUBLANG_BASHKIR_RUSSIA = 0x01,

			/// <summary>Basque (Basque) 0x042d eu-ES</summary>
			SUBLANG_BASQUE_BASQUE = 0x01,

			/// <summary>Belarusian (Belarus) 0x0423 be-BY</summary>
			SUBLANG_BELARUSIAN_BELARUS = 0x01,

			/// <summary>Bengali (India) - Note some prefer SUBLANG_BANGLA_INDIA</summary>
			SUBLANG_BENGALI_INDIA = 0x01,

			/// <summary>Bengali (Bangladesh) - Note some prefer SUBLANG_BANGLA_BANGLADESH</summary>
			SUBLANG_BENGALI_BANGLADESH = 0x02,

			/// <summary>Bosnian (Bosnia and Herzegovina - Latin) 0x141a bs-BA-Latn</summary>
			SUBLANG_BOSNIAN_BOSNIA_HERZEGOVINA_LATIN = 0x05,

			/// <summary>Bosnian (Bosnia and Herzegovina - Cyrillic) 0x201a bs-BA-Cyrl</summary>
			SUBLANG_BOSNIAN_BOSNIA_HERZEGOVINA_CYRILLIC = 0x08,

			/// <summary>Breton (France) 0x047e</summary>
			SUBLANG_BRETON_FRANCE = 0x01,

			/// <summary>Bulgarian (Bulgaria) 0x0402</summary>
			SUBLANG_BULGARIAN_BULGARIA = 0x01,

			/// <summary>Catalan (Catalan) 0x0403</summary>
			SUBLANG_CATALAN_CATALAN = 0x01,

			/// <summary>Central Kurdish (Iraq) 0x0492 ku-Arab-IQ</summary>
			SUBLANG_CENTRAL_KURDISH_IRAQ = 0x01,

			/// <summary>Cherokee (Cherokee) 0x045c chr-Cher-US</summary>
			SUBLANG_CHEROKEE_CHEROKEE = 0x01,

			/// <summary>Chinese (Taiwan) 0x0404 zh-TW</summary>
			SUBLANG_CHINESE_TRADITIONAL = 0x01,

			/// <summary>Chinese (PR China) 0x0804 zh-CN</summary>
			SUBLANG_CHINESE_SIMPLIFIED = 0x02,

			/// <summary>Chinese (Hong Kong S.A.R., P.R.C.) 0x0c04 zh-HK</summary>
			SUBLANG_CHINESE_HONGKONG = 0x03,

			/// <summary>Chinese (Singapore) 0x1004 zh-SG</summary>
			SUBLANG_CHINESE_SINGAPORE = 0x04,

			/// <summary>Chinese (Macau S.A.R.) 0x1404 zh-MO</summary>
			SUBLANG_CHINESE_MACAU = 0x05,

			/// <summary>Corsican (France) 0x0483</summary>
			SUBLANG_CORSICAN_FRANCE = 0x01,

			/// <summary>Czech (Czech Republic) 0x0405</summary>
			SUBLANG_CZECH_CZECH_REPUBLIC = 0x01,

			/// <summary>Croatian (Croatia)</summary>
			SUBLANG_CROATIAN_CROATIA = 0x01,

			/// <summary>Croatian (Bosnia and Herzegovina - Latin) 0x101a hr-BA</summary>
			SUBLANG_CROATIAN_BOSNIA_HERZEGOVINA_LATIN = 0x04,

			/// <summary>Danish (Denmark) 0x0406</summary>
			SUBLANG_DANISH_DENMARK = 0x01,

			/// <summary>Dari (Afghanistan)</summary>
			SUBLANG_DARI_AFGHANISTAN = 0x01,

			/// <summary>Divehi (Maldives) 0x0465 div-MV</summary>
			SUBLANG_DIVEHI_MALDIVES = 0x01,

			/// <summary>Dutch</summary>
			SUBLANG_DUTCH = 0x01,

			/// <summary>Dutch (Belgian)</summary>
			SUBLANG_DUTCH_BELGIAN = 0x02,

			/// <summary>English (USA)</summary>
			SUBLANG_ENGLISH_US = 0x01,

			/// <summary>English (UK)</summary>
			SUBLANG_ENGLISH_UK = 0x02,

			/// <summary>English (Australian)</summary>
			SUBLANG_ENGLISH_AUS = 0x03,

			/// <summary>English (Canadian)</summary>
			SUBLANG_ENGLISH_CAN = 0x04,

			/// <summary>English (New Zealand)</summary>
			SUBLANG_ENGLISH_NZ = 0x05,

			/// <summary>English (Irish)</summary>
			SUBLANG_ENGLISH_EIRE = 0x06,

			/// <summary>English (South Africa)</summary>
			SUBLANG_ENGLISH_SOUTH_AFRICA = 0x07,

			/// <summary>English (Jamaica)</summary>
			SUBLANG_ENGLISH_JAMAICA = 0x08,

			/// <summary>English (Caribbean)</summary>
			SUBLANG_ENGLISH_CARIBBEAN = 0x09,

			/// <summary>English (Belize)</summary>
			SUBLANG_ENGLISH_BELIZE = 0x0a,

			/// <summary>English (Trinidad)</summary>
			SUBLANG_ENGLISH_TRINIDAD = 0x0b,

			/// <summary>English (Zimbabwe)</summary>
			SUBLANG_ENGLISH_ZIMBABWE = 0x0c,

			/// <summary>English (Philippines)</summary>
			SUBLANG_ENGLISH_PHILIPPINES = 0x0d,

			/// <summary>English (India)</summary>
			SUBLANG_ENGLISH_INDIA = 0x10,

			/// <summary>English (Malaysia)</summary>
			SUBLANG_ENGLISH_MALAYSIA = 0x11,

			/// <summary>English (Singapore)</summary>
			SUBLANG_ENGLISH_SINGAPORE = 0x12,

			/// <summary>Estonian (Estonia) 0x0425 et-EE</summary>
			SUBLANG_ESTONIAN_ESTONIA = 0x01,

			/// <summary>Faroese (Faroe Islands) 0x0438 fo-FO</summary>
			SUBLANG_FAEROESE_FAROE_ISLANDS = 0x01,

			/// <summary>Filipino (Philippines) 0x0464 fil-PH</summary>
			SUBLANG_FILIPINO_PHILIPPINES = 0x01,

			/// <summary>Finnish (Finland) 0x040b</summary>
			SUBLANG_FINNISH_FINLAND = 0x01,

			/// <summary>French</summary>
			SUBLANG_FRENCH = 0x01,

			/// <summary>French (Belgian)</summary>
			SUBLANG_FRENCH_BELGIAN = 0x02,

			/// <summary>French (Canadian)</summary>
			SUBLANG_FRENCH_CANADIAN = 0x03,

			/// <summary>French (Swiss)</summary>
			SUBLANG_FRENCH_SWISS = 0x04,

			/// <summary>French (Luxembourg)</summary>
			SUBLANG_FRENCH_LUXEMBOURG = 0x05,

			/// <summary>French (Monaco)</summary>
			SUBLANG_FRENCH_MONACO = 0x06,

			/// <summary>Frisian (Netherlands) 0x0462 fy-NL</summary>
			SUBLANG_FRISIAN_NETHERLANDS = 0x01,

			/// <summary>Fulah (Senegal) 0x0867 ff-Latn-SN</summary>
			SUBLANG_FULAH_SENEGAL = 0x02,

			/// <summary>Galician (Galician) 0x0456 gl-ES</summary>
			SUBLANG_GALICIAN_GALICIAN = 0x01,

			/// <summary>Georgian (Georgia) 0x0437 ka-GE</summary>
			SUBLANG_GEORGIAN_GEORGIA = 0x01,

			/// <summary>German</summary>
			SUBLANG_GERMAN = 0x01,

			/// <summary>German (Swiss)</summary>
			SUBLANG_GERMAN_SWISS = 0x02,

			/// <summary>German (Austrian)</summary>
			SUBLANG_GERMAN_AUSTRIAN = 0x03,

			/// <summary>German (Luxembourg)</summary>
			SUBLANG_GERMAN_LUXEMBOURG = 0x04,

			/// <summary>German (Liechtenstein)</summary>
			SUBLANG_GERMAN_LIECHTENSTEIN = 0x05,

			/// <summary>Greek (Greece)</summary>
			SUBLANG_GREEK_GREECE = 0x01,

			/// <summary>Greenlandic (Greenland) 0x046f kl-GL</summary>
			SUBLANG_GREENLANDIC_GREENLAND = 0x01,

			/// <summary>Gujarati (India (Gujarati Script)) 0x0447 gu-IN</summary>
			SUBLANG_GUJARATI_INDIA = 0x01,

			/// <summary>Hausa (Latin, Nigeria) 0x0468 ha-NG-Latn</summary>
			SUBLANG_HAUSA_NIGERIA_LATIN = 0x01,

			/// <summary>Hawiian (US) 0x0475 haw-US</summary>
			SUBLANG_HAWAIIAN_US = 0x01,

			/// <summary>Hebrew (Israel) 0x040d</summary>
			SUBLANG_HEBREW_ISRAEL = 0x01,

			/// <summary>Hindi (India) 0x0439 hi-IN</summary>
			SUBLANG_HINDI_INDIA = 0x01,

			/// <summary>Hungarian (Hungary) 0x040e</summary>
			SUBLANG_HUNGARIAN_HUNGARY = 0x01,

			/// <summary>Icelandic (Iceland) 0x040f</summary>
			SUBLANG_ICELANDIC_ICELAND = 0x01,

			/// <summary>Igbo (Nigeria) 0x0470 ig-NG</summary>
			SUBLANG_IGBO_NIGERIA = 0x01,

			/// <summary>Indonesian (Indonesia) 0x0421 id-ID</summary>
			SUBLANG_INDONESIAN_INDONESIA = 0x01,

			/// <summary>Inuktitut (Syllabics) (Canada) 0x045d iu-CA-Cans</summary>
			SUBLANG_INUKTITUT_CANADA = 0x01,

			/// <summary>Inuktitut (Canada - Latin)</summary>
			SUBLANG_INUKTITUT_CANADA_LATIN = 0x02,

			/// <summary>Irish (Ireland)</summary>
			SUBLANG_IRISH_IRELAND = 0x02,

			/// <summary>Italian</summary>
			SUBLANG_ITALIAN = 0x01,

			/// <summary>Italian (Swiss)</summary>
			SUBLANG_ITALIAN_SWISS = 0x02,

			/// <summary>Japanese (Japan) 0x0411</summary>
			SUBLANG_JAPANESE_JAPAN = 0x01,

			/// <summary>Kannada (India (Kannada Script)) 0x044b kn-IN</summary>
			SUBLANG_KANNADA_INDIA = 0x01,

			/// <summary>Kashmiri (South Asia)</summary>
			SUBLANG_KASHMIRI_SASIA = 0x02,

			/// <summary>For app compatibility only</summary>
			SUBLANG_KASHMIRI_INDIA = 0x02,

			/// <summary>Kazakh (Kazakhstan) 0x043f kk-KZ</summary>
			SUBLANG_KAZAK_KAZAKHSTAN = 0x01,

			/// <summary>Khmer (Cambodia) 0x0453 kh-KH</summary>
			SUBLANG_KHMER_CAMBODIA = 0x01,

			/// <summary>K'iche (Guatemala)</summary>
			SUBLANG_KICHE_GUATEMALA = 0x01,

			/// <summary>Kinyarwanda (Rwanda) 0x0487 rw-RW</summary>
			SUBLANG_KINYARWANDA_RWANDA = 0x01,

			/// <summary>Konkani (India) 0x0457 kok-IN</summary>
			SUBLANG_KONKANI_INDIA = 0x01,

			/// <summary>Korean (Extended Wansung)</summary>
			SUBLANG_KOREAN = 0x01,

			/// <summary>Kyrgyz (Kyrgyzstan) 0x0440 ky-KG</summary>
			SUBLANG_KYRGYZ_KYRGYZSTAN = 0x01,

			/// <summary>Lao (Lao PDR) 0x0454 lo-LA</summary>
			SUBLANG_LAO_LAO = 0x01,

			/// <summary>Latvian (Latvia) 0x0426 lv-LV</summary>
			SUBLANG_LATVIAN_LATVIA = 0x01,

			/// <summary>Lithuanian</summary>
			SUBLANG_LITHUANIAN = 0x01,

			/// <summary>Lower Sorbian (Germany) 0x082e wee-DE</summary>
			SUBLANG_LOWER_SORBIAN_GERMANY = 0x02,

			/// <summary>Luxembourgish (Luxembourg) 0x046e lb-LU</summary>
			SUBLANG_LUXEMBOURGISH_LUXEMBOURG = 0x01,

			/// <summary>Macedonian (Macedonia (FYROM)) 0x042f mk-MK</summary>
			SUBLANG_MACEDONIAN_MACEDONIA = 0x01,

			/// <summary>Malay (Malaysia)</summary>
			SUBLANG_MALAY_MALAYSIA = 0x01,

			/// <summary>Malay (Brunei Darussalam)</summary>
			SUBLANG_MALAY_BRUNEI_DARUSSALAM = 0x02,

			/// <summary>Malayalam (India (Malayalam Script) ) 0x044c ml-IN</summary>
			SUBLANG_MALAYALAM_INDIA = 0x01,

			/// <summary>Maltese (Malta) 0x043a mt-MT</summary>
			SUBLANG_MALTESE_MALTA = 0x01,

			/// <summary>Maori (New Zealand) 0x0481 mi-NZ</summary>
			SUBLANG_MAORI_NEW_ZEALAND = 0x01,

			/// <summary>Mapudungun (Chile) 0x047a arn-CL</summary>
			SUBLANG_MAPUDUNGUN_CHILE = 0x01,

			/// <summary>Marathi (India) 0x044e mr-IN</summary>
			SUBLANG_MARATHI_INDIA = 0x01,

			/// <summary>Mohawk (Mohawk) 0x047c moh-CA</summary>
			SUBLANG_MOHAWK_MOHAWK = 0x01,

			/// <summary>Mongolian (Cyrillic, Mongolia)</summary>
			SUBLANG_MONGOLIAN_CYRILLIC_MONGOLIA = 0x01,

			/// <summary>Mongolian (PRC)</summary>
			SUBLANG_MONGOLIAN_PRC = 0x02,

			/// <summary>Nepali (India)</summary>
			SUBLANG_NEPALI_INDIA = 0x02,

			/// <summary>Nepali (Nepal) 0x0461 ne-NP</summary>
			SUBLANG_NEPALI_NEPAL = 0x01,

			/// <summary>Norwegian (Bokmal)</summary>
			SUBLANG_NORWEGIAN_BOKMAL = 0x01,

			/// <summary>Norwegian (Nynorsk)</summary>
			SUBLANG_NORWEGIAN_NYNORSK = 0x02,

			/// <summary>Occitan (France) 0x0482 oc-FR</summary>
			SUBLANG_OCCITAN_FRANCE = 0x01,

			/// <summary>Odia (India (Odia Script)) 0x0448 or-IN</summary>
			SUBLANG_ODIA_INDIA = 0x01,

			/// <summary>Deprecated: use SUBLANG_ODIA_INDIA instead</summary>
			SUBLANG_ORIYA_INDIA = 0x01,

			/// <summary>Pashto (Afghanistan)</summary>
			SUBLANG_PASHTO_AFGHANISTAN = 0x01,

			/// <summary>Persian (Iran) 0x0429 fa-IR</summary>
			SUBLANG_PERSIAN_IRAN = 0x01,

			/// <summary>Polish (Poland) 0x0415</summary>
			SUBLANG_POLISH_POLAND = 0x01,

			/// <summary>Portuguese</summary>
			SUBLANG_PORTUGUESE = 0x02,

			/// <summary>Portuguese (Brazil)</summary>
			SUBLANG_PORTUGUESE_BRAZILIAN = 0x01,

			/// <summary>Deprecated: Use SUBLANG_FULAH_SENEGAL instead</summary>
			SUBLANG_PULAR_SENEGAL = 0x02,

			/// <summary>Punjabi (India (Gurmukhi Script)) 0x0446 pa-IN</summary>
			SUBLANG_PUNJABI_INDIA = 0x01,

			/// <summary>Punjabi (Pakistan (Arabic Script)) 0x0846 pa-Arab-PK</summary>
			SUBLANG_PUNJABI_PAKISTAN = 0x02,

			/// <summary>Quechua (Bolivia)</summary>
			SUBLANG_QUECHUA_BOLIVIA = 0x01,

			/// <summary>Quechua (Ecuador)</summary>
			SUBLANG_QUECHUA_ECUADOR = 0x02,

			/// <summary>Quechua (Peru)</summary>
			SUBLANG_QUECHUA_PERU = 0x03,

			/// <summary>Romanian (Romania) 0x0418</summary>
			SUBLANG_ROMANIAN_ROMANIA = 0x01,

			/// <summary>Romansh (Switzerland) 0x0417 rm-CH</summary>
			SUBLANG_ROMANSH_SWITZERLAND = 0x01,

			/// <summary>Russian (Russia) 0x0419</summary>
			SUBLANG_RUSSIAN_RUSSIA = 0x01,

			/// <summary>Sakha (Russia) 0x0485 sah-RU</summary>
			SUBLANG_SAKHA_RUSSIA = 0x01,

			/// <summary>Northern Sami (Norway)</summary>
			SUBLANG_SAMI_NORTHERN_NORWAY = 0x01,

			/// <summary>Northern Sami (Sweden)</summary>
			SUBLANG_SAMI_NORTHERN_SWEDEN = 0x02,

			/// <summary>Northern Sami (Finland)</summary>
			SUBLANG_SAMI_NORTHERN_FINLAND = 0x03,

			/// <summary>Lule Sami (Norway)</summary>
			SUBLANG_SAMI_LULE_NORWAY = 0x04,

			/// <summary>Lule Sami (Sweden)</summary>
			SUBLANG_SAMI_LULE_SWEDEN = 0x05,

			/// <summary>Southern Sami (Norway)</summary>
			SUBLANG_SAMI_SOUTHERN_NORWAY = 0x06,

			/// <summary>Southern Sami (Sweden)</summary>
			SUBLANG_SAMI_SOUTHERN_SWEDEN = 0x07,

			/// <summary>Skolt Sami (Finland)</summary>
			SUBLANG_SAMI_SKOLT_FINLAND = 0x08,

			/// <summary>Inari Sami (Finland)</summary>
			SUBLANG_SAMI_INARI_FINLAND = 0x09,

			/// <summary>Sanskrit (India) 0x044f sa-IN</summary>
			SUBLANG_SANSKRIT_INDIA = 0x01,

			/// <summary>Scottish Gaelic (United Kingdom) 0x0491 gd-GB</summary>
			SUBLANG_SCOTTISH_GAELIC = 0x01,

			/// <summary>Serbian (Bosnia and Herzegovina - Latin)</summary>
			SUBLANG_SERBIAN_BOSNIA_HERZEGOVINA_LATIN = 0x06,

			/// <summary>Serbian (Bosnia and Herzegovina - Cyrillic)</summary>
			SUBLANG_SERBIAN_BOSNIA_HERZEGOVINA_CYRILLIC = 0x07,

			/// <summary>Serbian (Montenegro - Latn)</summary>
			SUBLANG_SERBIAN_MONTENEGRO_LATIN = 0x0b,

			/// <summary>Serbian (Montenegro - Cyrillic)</summary>
			SUBLANG_SERBIAN_MONTENEGRO_CYRILLIC = 0x0c,

			/// <summary>Serbian (Serbia - Latin)</summary>
			SUBLANG_SERBIAN_SERBIA_LATIN = 0x09,

			/// <summary>Serbian (Serbia - Cyrillic)</summary>
			SUBLANG_SERBIAN_SERBIA_CYRILLIC = 0x0a,

			/// <summary>Croatian (Croatia) 0x041a hr-HR</summary>
			SUBLANG_SERBIAN_CROATIA = 0x01,

			/// <summary>Serbian (Latin)</summary>
			SUBLANG_SERBIAN_LATIN = 0x02,

			/// <summary>Serbian (Cyrillic)</summary>
			SUBLANG_SERBIAN_CYRILLIC = 0x03,

			/// <summary>Sindhi (India) reserved 0x0459</summary>
			SUBLANG_SINDHI_INDIA = 0x01,

			/// <summary>Sindhi (Pakistan) 0x0859 sd-Arab-PK</summary>
			SUBLANG_SINDHI_PAKISTAN = 0x02,

			/// <summary>For app compatibility only</summary>
			SUBLANG_SINDHI_AFGHANISTAN = 0x02,

			/// <summary>Sinhalese (Sri Lanka)</summary>
			SUBLANG_SINHALESE_SRI_LANKA = 0x01,

			/// <summary>Northern Sotho (South Africa)</summary>
			SUBLANG_SOTHO_NORTHERN_SOUTH_AFRICA = 0x01,

			/// <summary>Slovak (Slovakia) 0x041b sk-SK</summary>
			SUBLANG_SLOVAK_SLOVAKIA = 0x01,

			/// <summary>Slovenian (Slovenia) 0x0424 sl-SI</summary>
			SUBLANG_SLOVENIAN_SLOVENIA = 0x01,

			/// <summary>Spanish (Castilian)</summary>
			SUBLANG_SPANISH = 0x01,

			/// <summary>Spanish (Mexico)</summary>
			SUBLANG_SPANISH_MEXICAN = 0x02,

			/// <summary>Spanish (Modern)</summary>
			SUBLANG_SPANISH_MODERN = 0x03,

			/// <summary>Spanish (Guatemala)</summary>
			SUBLANG_SPANISH_GUATEMALA = 0x04,

			/// <summary>Spanish (Costa Rica)</summary>
			SUBLANG_SPANISH_COSTA_RICA = 0x05,

			/// <summary>Spanish (Panama)</summary>
			SUBLANG_SPANISH_PANAMA = 0x06,

			/// <summary>Spanish (Dominican Republic)</summary>
			SUBLANG_SPANISH_DOMINICAN_REPUBLIC = 0x07,

			/// <summary>Spanish (Venezuela)</summary>
			SUBLANG_SPANISH_VENEZUELA = 0x08,

			/// <summary>Spanish (Colombia)</summary>
			SUBLANG_SPANISH_COLOMBIA = 0x09,

			/// <summary>Spanish (Peru)</summary>
			SUBLANG_SPANISH_PERU = 0x0a,

			/// <summary>Spanish (Argentina)</summary>
			SUBLANG_SPANISH_ARGENTINA = 0x0b,

			/// <summary>Spanish (Ecuador)</summary>
			SUBLANG_SPANISH_ECUADOR = 0x0c,

			/// <summary>Spanish (Chile)</summary>
			SUBLANG_SPANISH_CHILE = 0x0d,

			/// <summary>Spanish (Uruguay)</summary>
			SUBLANG_SPANISH_URUGUAY = 0x0e,

			/// <summary>Spanish (Paraguay)</summary>
			SUBLANG_SPANISH_PARAGUAY = 0x0f,

			/// <summary>Spanish (Bolivia)</summary>
			SUBLANG_SPANISH_BOLIVIA = 0x10,

			/// <summary>Spanish (El Salvador)</summary>
			SUBLANG_SPANISH_EL_SALVADOR = 0x11,

			/// <summary>Spanish (Honduras)</summary>
			SUBLANG_SPANISH_HONDURAS = 0x12,

			/// <summary>Spanish (Nicaragua)</summary>
			SUBLANG_SPANISH_NICARAGUA = 0x13,

			/// <summary>Spanish (Puerto Rico)</summary>
			SUBLANG_SPANISH_PUERTO_RICO = 0x14,

			/// <summary>Spanish (United States)</summary>
			SUBLANG_SPANISH_US = 0x15,

			/// <summary>Swahili (Kenya) 0x0441 sw-KE</summary>
			SUBLANG_SWAHILI_KENYA = 0x01,

			/// <summary>Swedish</summary>
			SUBLANG_SWEDISH = 0x01,

			/// <summary>Swedish (Finland)</summary>
			SUBLANG_SWEDISH_FINLAND = 0x02,

			/// <summary>Syriac (Syria) 0x045a syr-SY</summary>
			SUBLANG_SYRIAC_SYRIA = 0x01,

			/// <summary>Tajik (Tajikistan) 0x0428 tg-TJ-Cyrl</summary>
			SUBLANG_TAJIK_TAJIKISTAN = 0x01,

			/// <summary>Tamazight (Latin, Algeria) 0x085f tzm-Latn-DZ</summary>
			SUBLANG_TAMAZIGHT_ALGERIA_LATIN = 0x02,

			/// <summary>Tamazight (Tifinagh) 0x105f tzm-Tfng-MA</summary>
			SUBLANG_TAMAZIGHT_MOROCCO_TIFINAGH = 0x04,

			/// <summary>Tamil (India)</summary>
			SUBLANG_TAMIL_INDIA = 0x01,

			/// <summary>Tamil (Sri Lanka) 0x0849 ta-LK</summary>
			SUBLANG_TAMIL_SRI_LANKA = 0x02,

			/// <summary>Tatar (Russia) 0x0444 tt-RU</summary>
			SUBLANG_TATAR_RUSSIA = 0x01,

			/// <summary>Telugu (India (Telugu Script)) 0x044a te-IN</summary>
			SUBLANG_TELUGU_INDIA = 0x01,

			/// <summary>Thai (Thailand) 0x041e th-TH</summary>
			SUBLANG_THAI_THAILAND = 0x01,

			/// <summary>Tibetan (PRC)</summary>
			SUBLANG_TIBETAN_PRC = 0x01,

			/// <summary>Tigrigna (Eritrea)</summary>
			SUBLANG_TIGRIGNA_ERITREA = 0x02,

			/// <summary>Tigrinya (Eritrea) 0x0873 ti-ER (preferred spelling)</summary>
			SUBLANG_TIGRINYA_ERITREA = 0x02,

			/// <summary>Tigrinya (Ethiopia) 0x0473 ti-ET</summary>
			SUBLANG_TIGRINYA_ETHIOPIA = 0x01,

			/// <summary>Setswana / Tswana (Botswana) 0x0832 tn-BW</summary>
			SUBLANG_TSWANA_BOTSWANA = 0x02,

			/// <summary>Setswana / Tswana (South Africa) 0x0432 tn-ZA</summary>
			SUBLANG_TSWANA_SOUTH_AFRICA = 0x01,

			/// <summary>Turkish (Turkey) 0x041f tr-TR</summary>
			SUBLANG_TURKISH_TURKEY = 0x01,

			/// <summary>Turkmen (Turkmenistan) 0x0442 tk-TM</summary>
			SUBLANG_TURKMEN_TURKMENISTAN = 0x01,

			/// <summary>Uighur (PRC) 0x0480 ug-CN</summary>
			SUBLANG_UIGHUR_PRC = 0x01,

			/// <summary>Ukrainian (Ukraine) 0x0422 uk-UA</summary>
			SUBLANG_UKRAINIAN_UKRAINE = 0x01,

			/// <summary>Upper Sorbian (Germany) 0x042e wen-DE</summary>
			SUBLANG_UPPER_SORBIAN_GERMANY = 0x01,

			/// <summary>Urdu (Pakistan)</summary>
			SUBLANG_URDU_PAKISTAN = 0x01,

			/// <summary>Urdu (India)</summary>
			SUBLANG_URDU_INDIA = 0x02,

			/// <summary>Uzbek (Latin)</summary>
			SUBLANG_UZBEK_LATIN = 0x01,

			/// <summary>Uzbek (Cyrillic)</summary>
			SUBLANG_UZBEK_CYRILLIC = 0x02,

			/// <summary>Valencian (Valencia) 0x0803 ca-ES-Valencia</summary>
			SUBLANG_VALENCIAN_VALENCIA = 0x02,

			/// <summary>Vietnamese (Vietnam) 0x042a vi-VN</summary>
			SUBLANG_VIETNAMESE_VIETNAM = 0x01,

			/// <summary>Welsh (United Kingdom) 0x0452 cy-GB</summary>
			SUBLANG_WELSH_UNITED_KINGDOM = 0x01,

			/// <summary>Wolof (Senegal)</summary>
			SUBLANG_WOLOF_SENEGAL = 0x01,

			/// <summary>isiXhosa / Xhosa (South Africa) 0x0434 xh-ZA</summary>
			SUBLANG_XHOSA_SOUTH_AFRICA = 0x01,

			/// <summary>Deprecated: use SUBLANG_SAKHA_RUSSIA instead</summary>
			SUBLANG_YAKUT_RUSSIA = 0x01,

			/// <summary>Yi (PRC)) 0x0478</summary>
			SUBLANG_YI_PRC = 0x01,

			/// <summary>Yoruba (Nigeria) 046a yo-NG</summary>
			SUBLANG_YORUBA_NIGERIA = 0x01,

			/// <summary>isiZulu / Zulu (South Africa) 0x0435 zu-ZA</summary>
			SUBLANG_ZULU_SOUTH_AFRICA = 0x01,
		}

		private ushort val;

		/// <summary>Initializes a new instance of the <see cref="LANGID"/> struct.</summary>
		/// <param name="value">The value.</param>
		public LANGID(ushort value) => val = value;

		/// <summary>Creates a language identifier from a primary language identifier and a sublanguage identifier. See <c>MAKELANGID</c>.</summary>
		/// <param name="p">
		/// Primary language identifier. This identifier can be a predefined value or a value for a user-defined primary language. For a
		/// user-defined language, the identifier is a value in the range 0x0200 to 0x03FF. All other values are reserved for operating
		/// system use. For more information, see Language Identifier Constants and Strings.
		/// </param>
		/// <param name="s">
		/// Sublanguage identifier. This parameter can be a predefined sublanguage identifier or a user-defined sublanguage. For a
		/// user-defined sublanguage, the identifier is a value in the range 0x20 to 0x3F. All other values are reserved for operating
		/// system use. For more information, see Language Identifier Constants and Strings.
		/// </param>
		public LANGID(ushort p, byte s) => val = (ushort)((s << 10) | p);

		/// <summary>Creates a language identifier from a primary language identifier and a sublanguage identifier. See <c>MAKELANGID</c>.</summary>
		/// <param name="p">
		/// Primary language identifier. This identifier can be a predefined value or a value for a user-defined primary language. For a
		/// user-defined language, the identifier is a value in the range 0x0200 to 0x03FF. All other values are reserved for operating
		/// system use. For more information, see Language Identifier Constants and Strings.
		/// </param>
		/// <param name="s">
		/// Sublanguage identifier. This parameter can be a predefined sublanguage identifier or a user-defined sublanguage. For a
		/// user-defined sublanguage, the identifier is a value in the range 0x20 to 0x3F. All other values are reserved for operating
		/// system use. For more information, see Language Identifier Constants and Strings.
		/// </param>
		public LANGID(LANG p, SUBLANG s) : this((ushort)p, (byte)s) { }

		/// <summary>Initializes a new instance of the <see cref="LANGID"/> struct from an <see cref="LCID"/> instance. See <c>LANGIDFROMLCID</c>.</summary>
		/// <param name="lcid">The LCID value.</param>
		public LANGID(LCID lcid) => val = (ushort)(uint)lcid;

		/// <summary>Extracts a primary language identifier from a language identifier.</summary>
		public LANG PRIMARYLANGID => (LANG)(val & 0x3ff);

		/// <summary>Extracts a Sublanguage identifier from a language identifier.</summary>
		public SUBLANG SUBLANGID => (SUBLANG)(val >> 10);

		/// <summary>Gets the value.</summary>
		/// <value>The value.</value>
		public ushort Value { get => val; private set => val = value; }

		/// <summary>Performs an implicit conversion from <see cref="ushort"/> to <see cref="LANGID"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator LANGID(ushort value) => new LANGID(value);

		/// <summary>Performs an implicit conversion from <see cref="LCID"/> to <see cref="LANGID"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator LANGID(LCID value) => new LANGID(value);

		/// <summary>Performs an explicit conversion from <see cref="System.Globalization.CultureInfo"/> to <see cref="LANGID"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator LANGID(System.Globalization.CultureInfo value) => new((ushort)value.LCID);

		/// <summary>The operating system default language.</summary>
		public static LANGID LANG_SYSTEM_DEFAULT => new(LANG.LANG_NEUTRAL, SUBLANG.SUBLANG_SYS_DEFAULT);

		/// <summary>The language of the current user.</summary>
		public static LANGID LANG_USER_DEFAULT => new(LANG.LANG_NEUTRAL, SUBLANG.SUBLANG_DEFAULT);

		/// <summary>Performs an implicit conversion from <see cref="LANGID"/> to <see cref="ushort"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ushort(LANGID value) => value.Value;

		/// <summary>Indicates whether two <see cref="LANGID"/> instances are not equal.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is not equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator !=(LANGID s1, LANGID s2) => !s1.Equals(s2);

		/// <summary>Indicates whether two <see cref="LANGID"/> instances are equal.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator ==(LANGID s1, LANGID s2) => s1.Equals(s2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is LANGID s ? Equals(s) : (obj is ushort b ? Value.Equals(b) : Value.Equals(obj));

		/// <inheritdoc/>
		public bool Equals(LANGID other) => Value.Equals(other.Value);

		/// <inheritdoc/>
		public bool Equals(ushort other) => Value.Equals(other);

		/// <inheritdoc/>
		public override int GetHashCode() => val;

		/// <inheritdoc/>
		public TypeCode GetTypeCode() => Value.GetTypeCode();

		/// <inheritdoc/>
		public override string ToString() => Value.ToString();

		/// <inheritdoc/>
		public string ToString(IFormatProvider provider) => Value.ToString(provider);

		/// <inheritdoc/>
		int IComparable.CompareTo(object obj) => Value.CompareTo(Convert.ChangeType(obj, typeof(ulong)));

		/// <inheritdoc/>
		bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvertible)Value).ToBoolean(provider);

		/// <inheritdoc/>
		byte IConvertible.ToByte(IFormatProvider provider) => ((IConvertible)Value).ToByte(provider);

		/// <inheritdoc/>
		char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)Value).ToChar(provider);

		/// <inheritdoc/>
		DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)Value).ToDateTime(provider);

		/// <inheritdoc/>
		decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvertible)Value).ToDecimal(provider);

		/// <inheritdoc/>
		double IConvertible.ToDouble(IFormatProvider provider) => ((IConvertible)Value).ToDouble(provider);

		/// <inheritdoc/>
		short IConvertible.ToInt16(IFormatProvider provider) => ((IConvertible)Value).ToInt16(provider);

		/// <inheritdoc/>
		int IConvertible.ToInt32(IFormatProvider provider) => ((IConvertible)Value).ToInt32(provider);

		/// <inheritdoc/>
		long IConvertible.ToInt64(IFormatProvider provider) => ((IConvertible)Value).ToInt64(provider);

		/// <inheritdoc/>
		sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertible)Value).ToSByte(provider);

		/// <inheritdoc/>
		float IConvertible.ToSingle(IFormatProvider provider) => ((IConvertible)Value).ToSingle(provider);

		/// <inheritdoc/>
		object IConvertible.ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)Value).ToBoolean(provider);

		/// <inheritdoc/>
		ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertible)Value).ToUInt16(provider);

		/// <inheritdoc/>
		uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertible)Value).ToUInt32(provider);

		/// <inheritdoc/>
		ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertible)Value).ToUInt64(provider);

		internal class LANGIDTypeConverter : UInt16Converter
		{
			public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) =>
				value is LANGID b ? base.ConvertTo(context, culture, b.Value, destinationType) : throw new ArgumentException(null, nameof(value));

			public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
				new LANGID((ushort)base.ConvertFrom(context, culture, value));
		}
	}
}