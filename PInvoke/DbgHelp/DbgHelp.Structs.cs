using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from the DbgHelp.dll</summary>
	public static partial class DbgHelp
	{
		/// <summary>Flags for <see cref="IMAGEHLP_DEFERRED_SYMBOL_LOAD64"/>.</summary>
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_DEFERRED_SYMBOL_LOAD64")]
		[Flags]
		public enum DSLFLAG
		{
			/// <summary/>
			DSLFLAG_MISMATCHED_PDB = 0x1,

			/// <summary/>
			DSLFLAG_MISMATCHED_DBG = 0x2,

			/// <summary/>
			FLAG_ENGINE_PRESENT = 0x4,

			/// <summary/>
			FLAG_ENGOPT_DISALLOW_NETWORK_PATHS = 0x8,

			/// <summary/>
			FLAG_OVERRIDE_ARM_MACHINE_TYPE = 0x10,
		}

		/// <summary>Flags for <see cref="IMAGEHLP_GET_TYPE_INFO_PARAMS"/>.</summary>
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_GET_TYPE_INFO_PARAMS")]
		public enum IMAGEHLP_GTI_FLAGS
		{
			/// <summary>
			/// Do not cache the data for later retrievals. It is good to use this flag if you will not be requesting the information again.
			/// </summary>
			IMAGEHLP_GET_TYPE_INFO_UNCACHED = 0x00000001,

			/// <summary>Retrieve information about the children of the specified types, not the types themselves.</summary>
			IMAGEHLP_GET_TYPE_INFO_CHILDREN = 0x00000002
		}

		/// <summary>Specifies the type of the inline frame context.</summary>
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._tagSTACKFRAME_EX")]
		public enum INLINE_FRAME_CONTEXT : uint
		{
			/// <summary/>
			INLINE_FRAME_CONTEXT_INIT = 0,

			/// <summary/>
			INLINE_FRAME_CONTEXT_IGNORE = 0xFFFFFFFF
		}

		/// <summary>The type of symbols that are loaded.</summary>
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_MODULE")]
		public enum SYM_TYPE
		{
			/// <summary>No symbols are loaded.</summary>
			SymNone = 0,

			/// <summary>COFF symbols.</summary>
			SymCoff,

			/// <summary>CodeView symbols.</summary>
			SymCv,

			/// <summary>PDB symbols.</summary>
			SymPdb,

			/// <summary>Symbols generated from a DLL export table.</summary>
			SymExport,

			/// <summary>Symbol loading deferred.</summary>
			SymDeferred,

			/// <summary>.sym file.</summary>
			SymSym,       // .sym file

			/// <summary>DIA symbols.</summary>
			SymDia,

			/// <summary>The virtual module created by SymLoadModuleEx with SLMFLAG_VIRTUAL.</summary>
			SymVirtual,

			/// <summary>Unused.</summary>
			NumSymTypes
		}

		/// <summary>flags found in SYMBOL_INFO.Flags</summary>
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._SYMBOL_INFO")]
		public enum SYMFLAG : uint
		{
			/// <summary>The Value member is used.</summary>
			SYMFLAG_VALUEPRESENT = 0x00000001,

			/// <summary>The symbol is a register. The Register member is used.</summary>
			SYMFLAG_REGISTER = 0x00000008,

			/// <summary>Offsets are register relative.</summary>
			SYMFLAG_REGREL = 0x00000010,

			/// <summary>Offsets are frame relative.</summary>
			SYMFLAG_FRAMEREL = 0x00000020,

			/// <summary>The symbol is a parameter.</summary>
			SYMFLAG_PARAMETER = 0x00000040,

			/// <summary>The symbol is a local variable.</summary>
			SYMFLAG_LOCAL = 0x00000080,

			/// <summary>The symbol is a constant.</summary>
			SYMFLAG_CONSTANT = 0x00000100,

			/// <summary>The symbol is from the export table.</summary>
			SYMFLAG_EXPORT = 0x00000200,

			/// <summary>The symbol is a forwarder.</summary>
			SYMFLAG_FORWARDER = 0x00000400,

			/// <summary>The symbol is a known function.</summary>
			SYMFLAG_FUNCTION = 0x00000800,

			/// <summary>The symbol is a virtual symbol created by the SymAddSymbol function.</summary>
			SYMFLAG_VIRTUAL = 0x00001000,

			/// <summary>The symbol is a thunk.</summary>
			SYMFLAG_THUNK = 0x00002000,

			/// <summary>The symbol is an offset into the TLS data area.</summary>
			SYMFLAG_TLSREL = 0x00004000,

			/// <summary>The symbol is a managed code slot.</summary>
			SYMFLAG_SLOT = 0x00008000,

			/// <summary>
			/// The symbol address is an offset relative to the beginning of the intermediate language block. This applies to managed code only.
			/// </summary>
			SYMFLAG_ILREL = 0x00010000,

			/// <summary>The symbol is managed metadata.</summary>
			SYMFLAG_METADATA = 0x00020000,

			/// <summary>The symbol is a CLR token.</summary>
			SYMFLAG_CLR_TOKEN = 0x00040000,

			/// <summary/>
			SYMFLAG_NULL = 0x00080000,

			/// <summary/>
			SYMFLAG_FUNC_NO_RETURN = 0x00100000,

			/// <summary/>
			SYMFLAG_SYNTHETIC_ZEROBASE = 0x00200000,

			/// <summary/>
			SYMFLAG_PUBLIC_CODE = 0x00400000,

			/// <summary/>
			SYMFLAG_REGREL_ALIASINDIR = 0x00800000,

			/// <summary>this resets SymNext/Prev to the beginning of the module passed in the address field</summary>
			SYMFLAG_RESET = 0x80000000,
		}

		/// <summary>Converts a time stamp to a <see cref="DateTime"/>.</summary>
		/// <param name="timeStamp">
		/// The time stamp which is a value represented in the number of seconds elapsed since midnight (00:00:00), January 1, 1970,
		/// Universal Coordinated Time, according to the system clock.
		/// </param>
		/// <returns></returns>
		public static DateTime TimeStampToDateTime(uint timeStamp) => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc) + TimeSpan.FromSeconds(timeStamp);

		/// <summary>Represents an address. It is used in the STACKFRAME64 structure.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>ADDRESS</c> structure. For more information, see Updated Platform Support. <c>ADDRESS</c> is
		/// defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define ADDRESS ADDRESS64 #define LPADDRESS LPADDRESS64 #else typedef struct _tagADDRESS { DWORD Offset; WORD Segment; ADDRESS_MODE Mode; } ADDRESS, *LPADDRESS; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-address typedef struct _tagADDRESS { DWORD Offset; WORD
		// Segment; ADDRESS_MODE Mode; } ADDRESS, *LPADDRESS;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._tagADDRESS")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ADDRESS
		{
			/// <summary>
			/// The offset into the segment, or a 32-bit virtual address. The interpretation of this value depends on the value contained in
			/// the <c>Mode</c> member.
			/// </summary>
			public uint Offset;

			/// <summary>The segment number. This value is used only for 16-bit addressing.</summary>
			public ushort Segment;

			/// <summary>
			/// <para>The addressing mode. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>AddrMode1616 0</term>
			/// <term>16:16 addressing. To support this addressing mode, you must supply a TranslateAddressProc64 callback function.</term>
			/// </item>
			/// <item>
			/// <term>AddrMode1632 1</term>
			/// <term>16:32 addressing. To support this addressing mode, you must supply a TranslateAddressProc64 callback function.</term>
			/// </item>
			/// <item>
			/// <term>AddrModeReal 2</term>
			/// <term>Real-mode addressing. To support this addressing mode, you must supply a TranslateAddressProc64 callback function.</term>
			/// </item>
			/// <item>
			/// <term>AddrModeFlat 3</term>
			/// <term>Flat addressing. This is the only addressing mode supported by the library.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ADDRESS_MODE Mode;
		}

		/// <summary>Represents an address. It is used in the STACKFRAME64 structure.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>ADDRESS</c> structure. For more information, see Updated Platform Support. <c>ADDRESS</c> is
		/// defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define ADDRESS ADDRESS64 #define LPADDRESS LPADDRESS64 #else typedef struct _tagADDRESS { DWORD Offset; WORD Segment; ADDRESS_MODE Mode; } ADDRESS, *LPADDRESS; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-address64 typedef struct _tagADDRESS64 { DWORD64 Offset;
		// WORD Segment; ADDRESS_MODE Mode; } ADDRESS64, *LPADDRESS64;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._tagADDRESS64")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ADDRESS64
		{
			/// <summary>
			/// The offset into the segment, or a 32-bit virtual address. The interpretation of this value depends on the value contained in
			/// the <c>Mode</c> member.
			/// </summary>
			public ulong Offset;

			/// <summary>The segment number. This value is used only for 16-bit addressing.</summary>
			public ushort Segment;

			/// <summary>
			/// <para>The addressing mode. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>AddrMode1616 0</term>
			/// <term>16:16 addressing. To support this addressing mode, you must supply a TranslateAddressProc64 callback function.</term>
			/// </item>
			/// <item>
			/// <term>AddrMode1632 1</term>
			/// <term>16:32 addressing. To support this addressing mode, you must supply a TranslateAddressProc64 callback function.</term>
			/// </item>
			/// <item>
			/// <term>AddrModeReal 2</term>
			/// <term>Real-mode addressing. To support this addressing mode, you must supply a TranslateAddressProc64 callback function.</term>
			/// </item>
			/// <item>
			/// <term>AddrModeFlat 3</term>
			/// <term>Flat addressing. This is the only addressing mode supported by the library.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ADDRESS_MODE Mode;
		}

		/// <summary>Contains the library version.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-api_version typedef struct API_VERSION { USHORT
		// MajorVersion; USHORT MinorVersion; USHORT Revision; USHORT Reserved; } API_VERSION, *LPAPI_VERSION;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp.API_VERSION")]
		[StructLayout(LayoutKind.Sequential)]
		public struct API_VERSION
		{
			/// <summary>The major version number.</summary>
			public ushort MajorVersion;

			/// <summary>The minor version number.</summary>
			public ushort MinorVersion;

			/// <summary>The revision number.</summary>
			public ushort Revision;

			/// <summary>This member is reserved for use by the operating system.</summary>
			public ushort Reserved;

			/// <summary>Performs an explicit conversion from <see cref="Version"/> to <see cref="API_VERSION"/>.</summary>
			/// <param name="version">The version.</param>
			/// <returns>The resulting <see cref="API_VERSION"/> instance from the conversion.</returns>
			/// <exception cref="ArgumentException">version.Build must be 0</exception>
			public static implicit operator API_VERSION(Version version) => new API_VERSION { MajorVersion = (ushort)version.Major, MinorVersion = (ushort)version.Minor, Revision = (ushort)version.Revision, Reserved = version.Build == 0 ? (ushort)0 : throw new ArgumentException("version.Build must be 0") };

			/// <summary>Performs an explicit conversion from <see cref="API_VERSION"/> to <see cref="Version"/>.</summary>
			/// <param name="version">The version.</param>
			/// <returns>The resulting <see cref="Version"/> instance from the conversion.</returns>
			public static explicit operator Version(API_VERSION version) => new Version(version.MajorVersion, version.MinorVersion, 0, version.Revision);
		}

		/// <summary>
		/// <para>Contains debugging information.</para>
		/// <para>
		/// <c>Note</c> This structure is used by the MapDebugInformation and UnmapDebugInformation functions, which are provided only for
		/// backward compatibility.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>LIST_ENTRY</c> structure is defined as follows:</para>
		/// <para>
		/// <code>typedef struct _LIST_ENTRY { struct _LIST_ENTRY *Flink; struct _LIST_ENTRY *Blink; } LIST_ENTRY, *PLIST_ENTRY, *RESTRICTED_POINTER PRLIST_ENTRY;</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-image_debug_information typedef struct
		// _IMAGE_DEBUG_INFORMATION { LIST_ENTRY List; DWORD ReservedSize; PVOID ReservedMappedBase; USHORT ReservedMachine; USHORT
		// ReservedCharacteristics; DWORD ReservedCheckSum; DWORD ImageBase; DWORD SizeOfImage; DWORD ReservedNumberOfSections;
		// PIMAGE_SECTION_HEADER ReservedSections; DWORD ReservedExportedNamesSize; PSTR ReservedExportedNames; DWORD
		// ReservedNumberOfFunctionTableEntries; PIMAGE_FUNCTION_ENTRY ReservedFunctionTableEntries; DWORD
		// ReservedLowestFunctionStartingAddress; DWORD ReservedHighestFunctionEndingAddress; DWORD ReservedNumberOfFpoTableEntries;
		// PFPO_DATA ReservedFpoTableEntries; DWORD SizeOfCoffSymbols; PIMAGE_COFF_SYMBOLS_HEADER CoffSymbols; DWORD
		// ReservedSizeOfCodeViewSymbols; PVOID ReservedCodeViewSymbols; PSTR ImageFilePath; PSTR ImageFileName; PSTR ReservedDebugFilePath;
		// DWORD ReservedTimeDateStamp; BOOL ReservedRomImage; PIMAGE_DEBUG_DIRECTORY ReservedDebugDirectory; DWORD
		// ReservedNumberOfDebugDirectories; DWORD ReservedOriginalFunctionTableBaseAddress; DWORD Reserved[2]; } IMAGE_DEBUG_INFORMATION, *PIMAGE_DEBUG_INFORMATION;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGE_DEBUG_INFORMATION")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IMAGE_DEBUG_INFORMATION
		{
			/// <summary>A linked list of <c>LIST_ENTRY</c> structures.</summary>
			public LIST_ENTRY List;

			/// <summary>
			/// The size of the memory allocated for the <c>IMAGE_DEBUG_INFORMATION</c> structure and all debugging information, in bytes.
			/// </summary>
			public uint ReservedSize;

			/// <summary>The base address of the image.</summary>
			public IntPtr ReservedMappedBase;

			/// <summary>
			/// <para>The computer type. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IMAGE_FILE_MACHINE_I386 0x014c</term>
			/// <term>Intel (32-bit)</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_MACHINE_IA64 0x0200</term>
			/// <term>Intel Itanium</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_MACHINE_AMD64 0x8664</term>
			/// <term>x64 (AMD64 or EM64T)</term>
			/// </item>
			/// </list>
			/// </summary>
			public IMAGE_FILE_MACHINE ReservedMachine;

			/// <summary>
			/// <para>The characteristics of the image. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IMAGE_FILE_RELOCS_STRIPPED 0x0001</term>
			/// <term>Relocation information is stripped from the file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_EXECUTABLE_IMAGE 0x0002</term>
			/// <term>The file is executable (there are no unresolved external references).</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_LINE_NUMS_STRIPPED 0x0004</term>
			/// <term>Line numbers are stripped from the file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_LOCAL_SYMS_STRIPPED 0x0008</term>
			/// <term>Local symbols are stripped from file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_AGGRESIVE_WS_TRIM 0x0010</term>
			/// <term>Aggressively trim the working set.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_LARGE_ADDRESS_AWARE 0x0020</term>
			/// <term>The application can handle addresses larger than 2 GB.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_BYTES_REVERSED_LO 0x0080</term>
			/// <term>Bytes of the word are reversed.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_32BIT_MACHINE 0x0100</term>
			/// <term>Computer supports 32-bit words.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_DEBUG_STRIPPED 0x0200</term>
			/// <term>Debugging information is stored separately in a .dbg file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_REMOVABLE_RUN_FROM_SWAP 0x0400</term>
			/// <term>If the image is on removable media, copy and run from the swap file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_NET_RUN_FROM_SWAP 0x0800</term>
			/// <term>If the image is on the network, copy and run from the swap file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_SYSTEM 0x1000</term>
			/// <term>System file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_DLL 0x2000</term>
			/// <term>DLL file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_UP_SYSTEM_ONLY 0x4000</term>
			/// <term>File should be run only on a uniprocessor computer.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_BYTES_REVERSED_HI 0x8000</term>
			/// <term>Bytes of the word are reversed.</term>
			/// </item>
			/// </list>
			/// </summary>
			public IMAGE_FILE ReservedCharacteristics;

			/// <summary>The checksum of the image.</summary>
			public uint ReservedCheckSum;

			/// <summary>The requested base address of the image.</summary>
			public uint ImageBase;

			/// <summary>The size of the image, in bytes.</summary>
			public uint SizeOfImage;

			/// <summary>The number of COFF section headers.</summary>
			public uint ReservedNumberOfSections;

			/// <summary>A pointer to the first COFF section header. For more information, see IMAGE_SECTION_HEADER.</summary>
			public IntPtr ReservedSections;

			/// <summary>The size of the <c>ExportedNames</c> member, in bytes.</summary>
			public uint ReservedExportedNamesSize;

			/// <summary>A pointer to a series of null-terminated strings that name all the functions exported from the image.</summary>
			public IntPtr ReservedExportedNames;

			/// <summary>The number of entries contained in the <c>FunctionTableEntries</c> member.</summary>
			public uint ReservedNumberOfFunctionTableEntries;

			/// <summary>A pointer to the first function table entry. For more information, see IMAGE_FUNCTION_ENTRY.</summary>
			public IntPtr ReservedFunctionTableEntries;

			/// <summary>The lowest function table starting address.</summary>
			public uint ReservedLowestFunctionStartingAddress;

			/// <summary>The highest function table ending address.</summary>
			public uint ReservedHighestFunctionEndingAddress;

			/// <summary>The number of entries contained in the <c>FpoTableEntries</c> member.</summary>
			public uint ReservedNumberOfFpoTableEntries;

			/// <summary>A pointer to the first FPO entry. For more information, see FPO_DATA.</summary>
			public IntPtr ReservedFpoTableEntries;

			/// <summary>The size of the COFF symbol table, in bytes.</summary>
			public uint SizeOfCoffSymbols;

			/// <summary>A pointer to the COFF symbol table.</summary>
			public IntPtr CoffSymbols;

			/// <summary>The size of the CodeView symbol table, in bytes.</summary>
			public uint ReservedSizeOfCodeViewSymbols;

			/// <summary>A pointer to the beginning of the CodeView symbol table.</summary>
			public IntPtr ReservedCodeViewSymbols;

			/// <summary>The relative path to the image file name.</summary>
			[MarshalAs(UnmanagedType.LPStr)] public string ImageFilePath;

			/// <summary>The image file name.</summary>
			[MarshalAs(UnmanagedType.LPStr)] public string ImageFileName;

			/// <summary>The full path to the symbol file.</summary>
			[MarshalAs(UnmanagedType.LPStr)] public string ReservedDebugFilePath;

			/// <summary>The timestamp of the image. This represents the date and time the image was created by the linker.</summary>
			public uint ReservedTimeDateStamp;

			/// <summary>This value is <c>TRUE</c> if the image is a ROM image.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool ReservedRomImage;

			/// <summary>A pointer to the first debug directory. For more information, see IMAGE_DEBUG_DIRECTORY.</summary>
			public IntPtr ReservedDebugDirectory;

			/// <summary>The number of entries contained in the <c>DebugDirectory</c> member.</summary>
			public uint ReservedNumberOfDebugDirectories;

			/// <summary>The original function table base address.</summary>
			public uint ReservedOriginalFunctionTableBaseAddress;

			/// <summary>This member is reserved for use by the operating system.</summary>
			public ulong Reserved;
		}

		/// <summary>Contains information about a debugging event.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_cba_event typedef struct _IMAGEHLP_CBA_EVENT {
		// DWORD severity; DWORD code; PCHAR desc; PVOID object; } IMAGEHLP_CBA_EVENT, *PIMAGEHLP_CBA_EVENT;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_CBA_EVENT")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct IMAGEHLP_CBA_EVENT
		{
			/// <summary>
			/// <para>The event severity. This parameter can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>sevInfo 0</term>
			/// <term>Informational event.</term>
			/// </item>
			/// <item>
			/// <term>sevProblem 1</term>
			/// <term>Reserved for future use.</term>
			/// </item>
			/// <item>
			/// <term>sevAttn 2</term>
			/// <term>Reserved for future use.</term>
			/// </item>
			/// <item>
			/// <term>sevFatal 3</term>
			/// <term>Reserved for future use.</term>
			/// </item>
			/// </list>
			/// </summary>
			public EVENT_SEVERITY severity;

			/// <summary>This member is reserved for future use.</summary>
			public uint code;

			/// <summary>A text description of the error.</summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string desc;

			/// <summary>This member is reserved for future use.</summary>
			public IntPtr @object;
		}

		/// <summary>Contains information about a memory read operation.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_cba_read_memory typedef struct
		// _IMAGEHLP_CBA_READ_MEMORY { DWORD64 addr; PVOID buf; DWORD bytes; DWORD *bytesread; } IMAGEHLP_CBA_READ_MEMORY, *PIMAGEHLP_CBA_READ_MEMORY;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_CBA_READ_MEMORY")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IMAGEHLP_CBA_READ_MEMORY
		{
			/// <summary>The address to be read.</summary>
			public ulong addr;

			/// <summary>A pointer to a buffer that receives the memory read.</summary>
			public IntPtr buf;

			/// <summary>The number of bytes to read.</summary>
			public uint bytes;

			/// <summary>A pointer to a variable that receives the number of bytes read.</summary>
			public IntPtr bytesread;
		}

		/// <summary>Contains information about a deferred symbol load.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_DEFERRED_SYMBOL_LOAD</c> structure. For more information, see Updated Platform
		/// Support. <c>IMAGEHLP_DEFERRED_SYMBOL_LOAD</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_DEFERRED_SYMBOL_LOAD IMAGEHLP_DEFERRED_SYMBOL_LOAD64 #define PIMAGEHLP_DEFERRED_SYMBOL_LOAD PIMAGEHLP_DEFERRED_SYMBOL_LOAD64 #else typedef struct _IMAGEHLP_DEFERRED_SYMBOL_LOAD { DWORD SizeOfStruct; DWORD BaseOfImage; DWORD CheckSum; DWORD TimeDateStamp; CHAR FileName[MAX_PATH]; BOOLEAN Reparse; HANDLE hFile; } IMAGEHLP_DEFERRED_SYMBOL_LOAD, *PIMAGEHLP_DEFERRED_SYMBOL_LOAD; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_deferred_symbol_load typedef struct
		// _IMAGEHLP_DEFERRED_SYMBOL_LOAD { DWORD SizeOfStruct; DWORD BaseOfImage; DWORD CheckSum; DWORD TimeDateStamp; CHAR
		// FileName[MAX_PATH]; BOOLEAN Reparse; HANDLE hFile; } IMAGEHLP_DEFERRED_SYMBOL_LOAD, *PIMAGEHLP_DEFERRED_SYMBOL_LOAD;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_DEFERRED_SYMBOL_LOAD")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IMAGEHLP_DEFERRED_SYMBOL_LOAD
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_DEFERRED_SYMBOL_LOAD64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>The base virtual address where the image is loaded.</summary>
			public uint BaseOfImage;

			/// <summary>The computed checksum of the image. This value can be zero.</summary>
			public uint CheckSum;

			/// <summary>
			/// The date and timestamp value. The value is represented in the number of seconds elapsed since midnight (00:00:00), January
			/// 1, 1970, Universal Coordinated Time, according to the system clock. The timestamp can be printed using the C run-time (CRT)
			/// function <c>ctime</c>.
			/// </summary>
			public uint TimeDateStamp;

			/// <summary>The image name. The name may or may not contain a full path.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260 /*MAX_PATH*/)]
			public string FileName;

			/// <summary>If this member is <c>TRUE</c>, the operation should be performed again. Otherwise, it should not.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool Reparse;

			/// <summary>
			/// A handle to a file. This member is used with <c>CBA_DEFERRED_SYMBOL_LOAD_PARTIAL</c> and
			/// <c>IMAGEHLP_DEFERRED_SYMBOL_LOAD_FAILURE</c> callbacks.
			/// </summary>
			public HFILE hFile;
		}

		/// <summary>Contains information about a deferred symbol load.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_DEFERRED_SYMBOL_LOAD</c> structure. For more information, see Updated Platform
		/// Support. <c>IMAGEHLP_DEFERRED_SYMBOL_LOAD</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_DEFERRED_SYMBOL_LOAD IMAGEHLP_DEFERRED_SYMBOL_LOAD64 #define PIMAGEHLP_DEFERRED_SYMBOL_LOAD PIMAGEHLP_DEFERRED_SYMBOL_LOAD64 #else typedef struct _IMAGEHLP_DEFERRED_SYMBOL_LOAD { DWORD SizeOfStruct; DWORD BaseOfImage; DWORD CheckSum; DWORD TimeDateStamp; CHAR FileName[MAX_PATH]; BOOLEAN Reparse; HANDLE hFile; } IMAGEHLP_DEFERRED_SYMBOL_LOAD, *PIMAGEHLP_DEFERRED_SYMBOL_LOAD; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_deferred_symbol_load64 typedef struct
		// _IMAGEHLP_DEFERRED_SYMBOL_LOAD64 { DWORD SizeOfStruct; DWORD64 BaseOfImage; DWORD CheckSum; DWORD TimeDateStamp; CHAR
		// FileName[MAX_PATH]; BOOLEAN Reparse; HANDLE hFile; DWORD Flags; } IMAGEHLP_DEFERRED_SYMBOL_LOAD64, *PIMAGEHLP_DEFERRED_SYMBOL_LOAD64;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_DEFERRED_SYMBOL_LOAD64")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IMAGEHLP_DEFERRED_SYMBOL_LOAD64
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_DEFERRED_SYMBOL_LOAD64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>The base virtual address where the image is loaded.</summary>
			public ulong BaseOfImage;

			/// <summary>The computed checksum of the image. This value can be zero.</summary>
			public uint CheckSum;

			/// <summary>
			/// The date and timestamp value. The value is represented in the number of seconds elapsed since midnight (00:00:00), January
			/// 1, 1970, Universal Coordinated Time, according to the system clock. The timestamp can be printed using the C run-time (CRT)
			/// function <c>ctime</c>.
			/// </summary>
			public uint TimeDateStamp;

			/// <summary>The image name. The name may or may not contain a full path.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260 /*MAX_PATH*/)]
			public string FileName;

			/// <summary>If this member is <c>TRUE</c>, the operation should be performed again. Otherwise, it should not.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool Reparse;

			/// <summary>
			/// A handle to a file. This member is used with <c>CBA_DEFERRED_SYMBOL_LOAD_PARTIAL</c> and
			/// <c>IMAGEHLP_DEFERRED_SYMBOL_LOAD_FAILURE</c> callbacks.
			/// </summary>
			public HFILE hFile;

			/// <summary>
			/// <para>This member can be one of the following values.</para>
			/// <para>DSLFLAG_MISMATCHED_DBG (0x2)</para>
			/// <para>DSLFLAG_MISMATCHED_PDB (0x1)</para>
			/// </summary>
			public DSLFLAG Flags;
		}

		/// <summary>Contains information about a deferred symbol load.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_DEFERRED_SYMBOL_LOAD</c> structure. For more information, see Updated Platform
		/// Support. <c>IMAGEHLP_DEFERRED_SYMBOL_LOAD</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_DEFERRED_SYMBOL_LOAD IMAGEHLP_DEFERRED_SYMBOL_LOAD64 #define PIMAGEHLP_DEFERRED_SYMBOL_LOAD PIMAGEHLP_DEFERRED_SYMBOL_LOAD64 #else typedef struct _IMAGEHLP_DEFERRED_SYMBOL_LOAD { DWORD SizeOfStruct; DWORD BaseOfImage; DWORD CheckSum; DWORD TimeDateStamp; CHAR FileName[MAX_PATH]; BOOLEAN Reparse; HANDLE hFile; } IMAGEHLP_DEFERRED_SYMBOL_LOAD, *PIMAGEHLP_DEFERRED_SYMBOL_LOAD; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_deferred_symbol_load64 typedef struct
		// _IMAGEHLP_DEFERRED_SYMBOL_LOAD64 { DWORD SizeOfStruct; DWORD64 BaseOfImage; DWORD CheckSum; DWORD TimeDateStamp; CHAR
		// FileName[MAX_PATH]; BOOLEAN Reparse; HANDLE hFile; DWORD Flags; } IMAGEHLP_DEFERRED_SYMBOL_LOAD64, *PIMAGEHLP_DEFERRED_SYMBOL_LOAD64;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_DEFERRED_SYMBOL_LOAD64")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct IMAGEHLP_DEFERRED_SYMBOL_LOADW64
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_DEFERRED_SYMBOL_LOAD64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>The base virtual address where the image is loaded.</summary>
			public ulong BaseOfImage;

			/// <summary>The computed checksum of the image. This value can be zero.</summary>
			public uint CheckSum;

			/// <summary>
			/// The date and timestamp value. The value is represented in the number of seconds elapsed since midnight (00:00:00), January
			/// 1, 1970, Universal Coordinated Time, according to the system clock. The timestamp can be printed using the C run-time (CRT)
			/// function <c>ctime</c>.
			/// </summary>
			public uint TimeDateStamp;

			/// <summary>The image name. The name may or may not contain a full path.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 261 /*MAX_PATH + 1*/)]
			public string FileName;

			/// <summary>If this member is <c>TRUE</c>, the operation should be performed again. Otherwise, it should not.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool Reparse;

			/// <summary>
			/// A handle to a file. This member is used with <c>CBA_DEFERRED_SYMBOL_LOAD_PARTIAL</c> and
			/// <c>IMAGEHLP_DEFERRED_SYMBOL_LOAD_FAILURE</c> callbacks.
			/// </summary>
			public HFILE hFile;

			/// <summary>
			/// <para>This member can be one of the following values.</para>
			/// <para>DSLFLAG_MISMATCHED_DBG (0x2)</para>
			/// <para>DSLFLAG_MISMATCHED_PDB (0x1)</para>
			/// </summary>
			public DSLFLAG Flags;
		}

		/// <summary>Contains duplicate symbol information.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_DUPLICATE_SYMBOL</c> structure. For more information, see Updated Platform Support.
		/// <c>IMAGEHLP_DUPLICATE_SYMBOL</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_DUPLICATE_SYMBOL IMAGEHLP_DUPLICATE_SYMBOL64 #define PIMAGEHLP_DUPLICATE_SYMBOL PIMAGEHLP_DUPLICATE_SYMBOL64 #else typedef struct _IMAGEHLP_DUPLICATE_SYMBOL { DWORD SizeOfStruct; DWORD NumberOfDups; PIMAGEHLP_SYMBOL Symbol; DWORD SelectedSymbol; } IMAGEHLP_DUPLICATE_SYMBOL, *PIMAGEHLP_DUPLICATE_SYMBOL; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_duplicate_symbol64 typedef struct
		// _IMAGEHLP_DUPLICATE_SYMBOL64 { DWORD SizeOfStruct; DWORD NumberOfDups; PIMAGEHLP_SYMBOL64 Symbol; DWORD SelectedSymbol; }
		// IMAGEHLP_DUPLICATE_SYMBOL64, *PIMAGEHLP_DUPLICATE_SYMBOL64;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_DUPLICATE_SYMBOL64")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct IMAGEHLP_DUPLICATE_SYMBOL64
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_DUPLICATE_SYMBOL64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>The number of duplicate symbols.</summary>
			public uint NumberOfDups;

			/// <summary>
			/// A pointer to an array of symbols ( IMAGEHLP_SYMBOL64 structures). The number of entries in the array is specified by the
			/// <c>NumberOfDups</c> member.
			/// </summary>
			public IntPtr Symbol;

			/// <summary>The index into the symbol array for the selected symbol.</summary>
			public uint SelectedSymbol;
		}

		/// <summary>Contains type information for a module.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_get_type_info_params typedef struct
		// _IMAGEHLP_GET_TYPE_INFO_PARAMS { IN ULONG SizeOfStruct; IN ULONG Flags; IN ULONG NumIds; IN PULONG TypeIds; IN ULONG64 TagFilter;
		// IN ULONG NumReqs; IN IMAGEHLP_SYMBOL_TYPE_INFO *ReqKinds; IN PULONG_PTR ReqOffsets; IN PULONG ReqSizes; IN ULONG_PTR ReqStride;
		// IN ULONG_PTR BufferSize; OUT PVOID Buffer; OUT ULONG EntriesMatched; OUT ULONG EntriesFilled; OUT ULONG64 TagsFound; OUT ULONG64
		// AllReqsValid; IN ULONG NumReqsValid; OUT PULONG64 ReqsValid; } IMAGEHLP_GET_TYPE_INFO_PARAMS, *PIMAGEHLP_GET_TYPE_INFO_PARAMS;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_GET_TYPE_INFO_PARAMS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IMAGEHLP_GET_TYPE_INFO_PARAMS
		{
			/// <summary>The size of this structure, in bytes.</summary>
			public uint SizeOfStruct;

			/// <summary>
			/// <para>This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IMAGEHLP_GET_TYPE_INFO_CHILDREN 0x00000002</term>
			/// <term>Retrieve information about the children of the specified types, not the types themselves.</term>
			/// </item>
			/// <item>
			/// <term>IMAGEHLP_GET_TYPE_INFO_UNCACHED 0x00000001</term>
			/// <term>
			/// Do not cache the data for later retrievals. It is good to use this flag if you will not be requesting the information again.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public uint Flags;

			/// <summary>The number of elements specified in the <c>TypeIds</c> array.</summary>
			public uint NumIds;

			/// <summary>An array of type indexes.</summary>
			public IntPtr TypeIds;

			/// <summary>
			/// The filter for return values. For example, set this member to 1 &lt;&lt; <c>SymTagData</c> to return only results with a
			/// symbol tag of <c>SymTagData</c>. For a list of tags, see the <c>SymTagEnum</c> type defined in Dbghelp.h
			/// </summary>
			public ulong TagFilter;

			/// <summary>
			/// The number of elements specified in the arrays specified in the <c>ReqKinds</c>, <c>ReqOffsets</c>, and <c>ReqSizes</c>
			/// members. These arrays must be the same size.
			/// </summary>
			public uint NumReqs;

			/// <summary>
			/// An array of information types to be requested. Each element is one of the enumeration values in the
			/// IMAGEHLP_SYMBOL_TYPE_INFO enumeration type.
			/// </summary>
			public IntPtr ReqKinds;

			/// <summary>
			/// An array of offsets that specify where to store the data for each request within each element of <c>Buffer</c> array.
			/// </summary>
			public IntPtr ReqOffsets;

			/// <summary>The size of each data request, in bytes. The required sizes are described in IMAGEHLP_SYMBOL_TYPE_INFO.</summary>
			public IntPtr ReqSizes;

			/// <summary>The number of bytes for each element in the <c>Buffer</c> array.</summary>
			public IntPtr ReqStride;

			/// <summary>The size of the <c>Buffer</c> array, in bytes.</summary>
			public IntPtr BufferSize;

			/// <summary>
			/// An array of records used for storing query results. Each record is separated by <c>ReqStride</c> bytes. Each type for which
			/// data is to be retrieved requires one record in the array. Within each record, there are <c>NumReqs</c> pieces of data stored
			/// as the result of individual queries. The data is stored within the record according to the offsets specified in
			/// <c>ReqOffsets</c>. The format of the data depends on the value of the <c>ReqKinds</c> member in use.
			/// </summary>
			public IntPtr Buffer;

			/// <summary>The number of type entries that match the filter.</summary>
			public uint EntriesMatched;

			/// <summary>The number of elements in the <c>Buffer</c> array that received results.</summary>
			public uint EntriesFilled;

			/// <summary>A bitmask indicating all tag bits encountered during the search operation.</summary>
			public ulong TagsFound;

			/// <summary>A bitmask indicate the bit-wise AND of all <c>ReqsValid</c> fields.</summary>
			public ulong AllReqsValid;

			/// <summary>The size of <c>ReqsValid</c>, in elements.</summary>
			public uint NumReqsValid;

			/// <summary>
			/// A bitmask indexed by <c>Buffer</c> element index that indicates which request data is valid. This member can be <c>NULL</c>.
			/// </summary>
			public IntPtr ReqsValid;
		}

		/// <summary>Represents a source file line.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_LINE</c> structure. For more information, see Updated Platform Support.
		/// <c>IMAGEHLP_LINE</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_LINE IMAGEHLP_LINE64 #define PIMAGEHLP_LINE PIMAGEHLP_LINE64 #else typedef struct _IMAGEHLP_LINE { DWORD SizeOfStruct; PVOID Key; DWORD LineNumber; PCHAR FileName; DWORD Address; } IMAGEHLP_LINE, *PIMAGEHLP_LINE; typedef struct _IMAGEHLP_LINEW { DWORD SizeOfStruct; PVOID Key; DWORD LineNumber; PCHAR FileName; DWORD64 Address; } IMAGEHLP_LINEW, *PIMAGEHLP_LINEW; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_line typedef struct _IMAGEHLP_LINE { DWORD
		// SizeOfStruct; PVOID Key; DWORD LineNumber; PCHAR FileName; DWORD Address; } IMAGEHLP_LINE, *PIMAGEHLP_LINE;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_LINE")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IMAGEHLP_LINE
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_LINE64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>This member is reserved for use by the operating system.</summary>
			public IntPtr Key;

			/// <summary>The line number in the file.</summary>
			public uint LineNumber;

			/// <summary>The name of the file, including the full path.</summary>
			[MarshalAs(UnmanagedType.LPStr)] public string FileName;

			/// <summary>The address of the first instruction in the line.</summary>
			public uint Address;
		}

		/// <summary>Represents a source file line.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_LINE</c> structure. For more information, see Updated Platform Support.
		/// <c>IMAGEHLP_LINE</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_LINE IMAGEHLP_LINE64 #define PIMAGEHLP_LINE PIMAGEHLP_LINE64 #else typedef struct _IMAGEHLP_LINE { DWORD SizeOfStruct; PVOID Key; DWORD LineNumber; PCHAR FileName; DWORD Address; } IMAGEHLP_LINE, *PIMAGEHLP_LINE; typedef struct _IMAGEHLP_LINEW { DWORD SizeOfStruct; PVOID Key; DWORD LineNumber; PCHAR FileName; DWORD64 Address; } IMAGEHLP_LINEW, *PIMAGEHLP_LINEW; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_line64 typedef struct _IMAGEHLP_LINE64 { DWORD
		// SizeOfStruct; PVOID Key; DWORD LineNumber; PCHAR FileName; DWORD64 Address; } IMAGEHLP_LINE64, *PIMAGEHLP_LINE64;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_LINE64")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IMAGEHLP_LINE64
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_LINE64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>This member is reserved for use by the operating system.</summary>
			public IntPtr Key;

			/// <summary>The line number in the file.</summary>
			public uint LineNumber;

			/// <summary>The name of the file, including the full path.</summary>
			[MarshalAs(UnmanagedType.LPStr)] public string FileName;

			/// <summary>The address of the first instruction in the line.</summary>
			public ulong Address;
		}

		/// <summary>Represents a source file line.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_LINE</c> structure. For more information, see Updated Platform Support.
		/// <c>IMAGEHLP_LINE</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_LINE IMAGEHLP_LINE64 #define PIMAGEHLP_LINE PIMAGEHLP_LINE64 #else typedef struct _IMAGEHLP_LINE { DWORD SizeOfStruct; PVOID Key; DWORD LineNumber; PCHAR FileName; DWORD Address; } IMAGEHLP_LINE, *PIMAGEHLP_LINE; typedef struct _IMAGEHLP_LINEW { DWORD SizeOfStruct; PVOID Key; DWORD LineNumber; PCHAR FileName; DWORD64 Address; } IMAGEHLP_LINEW, *PIMAGEHLP_LINEW; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_line typedef struct _IMAGEHLP_LINE { DWORD
		// SizeOfStruct; PVOID Key; DWORD LineNumber; PCHAR FileName; DWORD Address; } IMAGEHLP_LINE, *PIMAGEHLP_LINE;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_LINE")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IMAGEHLP_LINEW
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_LINE64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>This member is reserved for use by the operating system.</summary>
			public IntPtr Key;

			/// <summary>The line number in the file.</summary>
			public uint LineNumber;

			/// <summary>The name of the file, including the full path.</summary>
			[MarshalAs(UnmanagedType.LPStr)] public string FileName;

			/// <summary>The address of the first instruction in the line.</summary>
			public ulong Address;
		}

		/// <summary>Represents a source file line.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_LINE</c> structure. For more information, see Updated Platform Support.
		/// <c>IMAGEHLP_LINE</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_LINE IMAGEHLP_LINE64 #define PIMAGEHLP_LINE PIMAGEHLP_LINE64 #else typedef struct _IMAGEHLP_LINE { DWORD SizeOfStruct; PVOID Key; DWORD LineNumber; PCHAR FileName; DWORD Address; } IMAGEHLP_LINE, *PIMAGEHLP_LINE; typedef struct _IMAGEHLP_LINEW { DWORD SizeOfStruct; PVOID Key; DWORD LineNumber; PCHAR FileName; DWORD64 Address; } IMAGEHLP_LINEW, *PIMAGEHLP_LINEW; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_linew64 typedef struct _IMAGEHLP_LINEW64 { DWORD
		// SizeOfStruct; PVOID Key; DWORD LineNumber; PWSTR FileName; DWORD64 Address; } IMAGEHLP_LINEW64, *PIMAGEHLP_LINEW64;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_LINEW64")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct IMAGEHLP_LINEW64
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_LINE64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>This member is reserved for use by the operating system.</summary>
			public IntPtr Key;

			/// <summary>The line number in the file.</summary>
			public uint LineNumber;

			/// <summary>The name of the file, including the full path.</summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string FileName;

			/// <summary>The address of the first instruction in the line.</summary>
			public ulong Address;
		}

		/// <summary>Contains module information.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_MODULE</c> structure. For more information, see Updated Platform Support.
		/// <c>IMAGEHLP_MODULE</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_MODULE IMAGEHLP_MODULE64 #define PIMAGEHLP_MODULE PIMAGEHLP_MODULE64 #define IMAGEHLP_MODULEW IMAGEHLP_MODULEW64 #define PIMAGEHLP_MODULEW PIMAGEHLP_MODULEW64 #else typedef struct _IMAGEHLP_MODULE { DWORD SizeOfStruct; DWORD BaseOfImage; DWORD ImageSize; DWORD TimeDateStamp; DWORD CheckSum; DWORD NumSyms; SYM_TYPE SymType; CHAR ModuleName[32]; CHAR ImageName[256]; CHAR LoadedImageName[256]; } IMAGEHLP_MODULE, *PIMAGEHLP_MODULE; typedef struct _IMAGEHLP_MODULEW { DWORD SizeOfStruct; DWORD BaseOfImage; DWORD ImageSize; DWORD TimeDateStamp; DWORD CheckSum; DWORD NumSyms; SYM_TYPE SymType; WCHAR ModuleName[32]; WCHAR ImageName[256]; WCHAR LoadedImageName[256]; } IMAGEHLP_MODULEW, *PIMAGEHLP_MODULEW; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_module typedef struct _IMAGEHLP_MODULE { DWORD
		// SizeOfStruct; DWORD BaseOfImage; DWORD ImageSize; DWORD TimeDateStamp; DWORD CheckSum; DWORD NumSyms; SYM_TYPE SymType; CHAR
		// ModuleName[32]; CHAR ImageName[256]; CHAR LoadedImageName[256]; } IMAGEHLP_MODULE, *PIMAGEHLP_MODULE;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_MODULE")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IMAGEHLP_MODULE
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_MODULE64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>The base virtual address where the image is loaded.</summary>
			public uint BaseOfImage;

			/// <summary>The size of the image, in bytes.</summary>
			public uint ImageSize;

			/// <summary>
			/// The date and timestamp value. The value is represented in the number of seconds elapsed since midnight (00:00:00), January
			/// 1, 1970, Universal Coordinated Time, according to the system clock. The timestamp can be printed using the C run-time (CRT)
			/// function <c>ctime</c>.
			/// </summary>
			public uint TimeDateStamp;

			/// <summary>The checksum of the image. This value can be zero.</summary>
			public uint CheckSum;

			/// <summary>
			/// The number of symbols in the symbol table. The value of this parameter is not meaningful when <c>SymPdb</c> is specified as
			/// the value of the SymType parameter.
			/// </summary>
			public uint NumSyms;

			/// <summary>
			/// <para>The type of symbols that are loaded. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SymCoff</term>
			/// <term>COFF symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymCv</term>
			/// <term>CodeView symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymDeferred</term>
			/// <term>Symbol loading deferred.</term>
			/// </item>
			/// <item>
			/// <term>SymDia</term>
			/// <term>DIA symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymExport</term>
			/// <term>Symbols generated from a DLL export table.</term>
			/// </item>
			/// <item>
			/// <term>SymNone</term>
			/// <term>No symbols are loaded.</term>
			/// </item>
			/// <item>
			/// <term>SymPdb</term>
			/// <term>PDB symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymSym</term>
			/// <term>.sym file.</term>
			/// </item>
			/// <item>
			/// <term>SymVirtual</term>
			/// <term>The virtual module created by SymLoadModuleEx with SLMFLAG_VIRTUAL.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SYM_TYPE SymType;

			/// <summary>The module name.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string ModuleName;

			/// <summary>The image name. The name may or may not contain a full path.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string ImageName;

			/// <summary>The full path and file name of the file from which symbols were loaded.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string LoadedImageName;
		}

		/// <summary>Contains module information.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_MODULE</c> structure. For more information, see Updated Platform Support.
		/// <c>IMAGEHLP_MODULE</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_MODULE IMAGEHLP_MODULE64 #define PIMAGEHLP_MODULE PIMAGEHLP_MODULE64 #define IMAGEHLP_MODULEW IMAGEHLP_MODULEW64 #define PIMAGEHLP_MODULEW PIMAGEHLP_MODULEW64 #else typedef struct _IMAGEHLP_MODULE { DWORD SizeOfStruct; DWORD BaseOfImage; DWORD ImageSize; DWORD TimeDateStamp; DWORD CheckSum; DWORD NumSyms; SYM_TYPE SymType; CHAR ModuleName[32]; CHAR ImageName[256]; CHAR LoadedImageName[256]; } IMAGEHLP_MODULE, *PIMAGEHLP_MODULE; typedef struct _IMAGEHLP_MODULEW { DWORD SizeOfStruct; DWORD BaseOfImage; DWORD ImageSize; DWORD TimeDateStamp; DWORD CheckSum; DWORD NumSyms; SYM_TYPE SymType; WCHAR ModuleName[32]; WCHAR ImageName[256]; WCHAR LoadedImageName[256]; } IMAGEHLP_MODULEW, *PIMAGEHLP_MODULEW; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_module64 typedef struct _IMAGEHLP_MODULE64 { DWORD
		// SizeOfStruct; DWORD64 BaseOfImage; DWORD ImageSize; DWORD TimeDateStamp; DWORD CheckSum; DWORD NumSyms; SYM_TYPE SymType; CHAR
		// ModuleName[32]; CHAR ImageName[256]; CHAR LoadedImageName[256]; CHAR LoadedPdbName[256]; DWORD CVSig; CHAR *CVData[MAX_PATH 3];
		// DWORD PdbSig; GUID PdbSig70; DWORD PdbAge; BOOL PdbUnmatched; BOOL DbgUnmatched; BOOL LineNumbers; BOOL GlobalSymbols; BOOL
		// TypeInfo; BOOL SourceIndexed; BOOL Publics; DWORD MachineType; DWORD Reserved; } IMAGEHLP_MODULE64, *PIMAGEHLP_MODULE64;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_MODULE64")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IMAGEHLP_MODULE64
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_MODULE64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>The base virtual address where the image is loaded.</summary>
			public ulong BaseOfImage;

			/// <summary>The size of the image, in bytes.</summary>
			public uint ImageSize;

			/// <summary>
			/// The date and timestamp value. The value is represented in the number of seconds elapsed since midnight (00:00:00), January
			/// 1, 1970, Universal Coordinated Time, according to the system clock. The timestamp can be printed using the C run-time (CRT)
			/// function <c>ctime</c>.
			/// </summary>
			public uint TimeDateStamp;

			/// <summary>The checksum of the image. This value can be zero.</summary>
			public uint CheckSum;

			/// <summary>
			/// The number of symbols in the symbol table. The value of this parameter is not meaningful when <c>SymPdb</c> is specified as
			/// the value of the SymType parameter.
			/// </summary>
			public uint NumSyms;

			/// <summary>
			/// <para>The type of symbols that are loaded. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SymCoff</term>
			/// <term>COFF symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymCv</term>
			/// <term>CodeView symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymDeferred</term>
			/// <term>Symbol loading deferred.</term>
			/// </item>
			/// <item>
			/// <term>SymDia</term>
			/// <term>DIA symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymExport</term>
			/// <term>Symbols generated from a DLL export table.</term>
			/// </item>
			/// <item>
			/// <term>SymNone</term>
			/// <term>No symbols are loaded.</term>
			/// </item>
			/// <item>
			/// <term>SymPdb</term>
			/// <term>PDB symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymSym</term>
			/// <term>.sym file.</term>
			/// </item>
			/// <item>
			/// <term>SymVirtual</term>
			/// <term>The virtual module created by SymLoadModuleEx with SLMFLAG_VIRTUAL.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SYM_TYPE SymType;

			/// <summary>The module name.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string ModuleName;

			/// <summary>The image name. The name may or may not contain a full path.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string ImageName;

			/// <summary>The full path and file name of the file from which symbols were loaded.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string LoadedImageName;

			/// <summary>The full path and file name of the .pdb file.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string LoadedPdbName;

			/// <summary>The signature of the CV record in the debug directories.</summary>
			public uint CVSig;

			/// <summary>The contents of the CV record.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260 * 3)]
			public string CVData;

			/// <summary>The PDB signature.</summary>
			public uint PdbSig;

			/// <summary>The PDB signature (Visual C/C++ 7.0 and later)</summary>
			public Guid PdbSig70;

			/// <summary>The DBI age of PDB.</summary>
			public uint PdbAge;

			/// <summary>A value that indicates whether the loaded PDB is unmatched.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool PdbUnmatched;

			/// <summary>A value that indicates whether the loaded DBG is unmatched.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool DbgUnmatched;

			/// <summary>A value that indicates whether line number information is available.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool LineNumbers;

			/// <summary>A value that indicates whether symbol information is available.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool GlobalSymbols;

			/// <summary>A value that indicates whether type information is available.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool TypeInfo;

			/// <summary>
			/// <para>A value that indicates whether the .pdb supports the source server.</para>
			/// <para><c>DbgHelp 6.1 and earlier:</c> This member is not supported.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool SourceIndexed;

			/// <summary>
			/// <para>A value that indicates whether the module contains public symbols.</para>
			/// <para><c>DbgHelp 6.1 and earlier:</c> This member is not supported.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool Publics;

			/// <summary/>
			public uint MachineType;

			/// <summary/>
			public uint Reserved;
		}

		/// <summary>Contains module information.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_MODULE</c> structure. For more information, see Updated Platform Support.
		/// <c>IMAGEHLP_MODULE</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_MODULE IMAGEHLP_MODULE64 #define PIMAGEHLP_MODULE PIMAGEHLP_MODULE64 #define IMAGEHLP_MODULEW IMAGEHLP_MODULEW64 #define PIMAGEHLP_MODULEW PIMAGEHLP_MODULEW64 #else typedef struct _IMAGEHLP_MODULE { DWORD SizeOfStruct; DWORD BaseOfImage; DWORD ImageSize; DWORD TimeDateStamp; DWORD CheckSum; DWORD NumSyms; SYM_TYPE SymType; CHAR ModuleName[32]; CHAR ImageName[256]; CHAR LoadedImageName[256]; } IMAGEHLP_MODULE, *PIMAGEHLP_MODULE; typedef struct _IMAGEHLP_MODULEW { DWORD SizeOfStruct; DWORD BaseOfImage; DWORD ImageSize; DWORD TimeDateStamp; DWORD CheckSum; DWORD NumSyms; SYM_TYPE SymType; WCHAR ModuleName[32]; WCHAR ImageName[256]; WCHAR LoadedImageName[256]; } IMAGEHLP_MODULEW, *PIMAGEHLP_MODULEW; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_module typedef struct _IMAGEHLP_MODULE { DWORD
		// SizeOfStruct; DWORD BaseOfImage; DWORD ImageSize; DWORD TimeDateStamp; DWORD CheckSum; DWORD NumSyms; SYM_TYPE SymType; CHAR
		// ModuleName[32]; CHAR ImageName[256]; CHAR LoadedImageName[256]; } IMAGEHLP_MODULE, *PIMAGEHLP_MODULE;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_MODULE")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct IMAGEHLP_MODULEW
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_MODULE64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>The base virtual address where the image is loaded.</summary>
			public uint BaseOfImage;

			/// <summary>The size of the image, in bytes.</summary>
			public uint ImageSize;

			/// <summary>
			/// The date and timestamp value. The value is represented in the number of seconds elapsed since midnight (00:00:00), January
			/// 1, 1970, Universal Coordinated Time, according to the system clock. The timestamp can be printed using the C run-time (CRT)
			/// function <c>ctime</c>.
			/// </summary>
			public uint TimeDateStamp;

			/// <summary>The checksum of the image. This value can be zero.</summary>
			public uint CheckSum;

			/// <summary>
			/// The number of symbols in the symbol table. The value of this parameter is not meaningful when <c>SymPdb</c> is specified as
			/// the value of the SymType parameter.
			/// </summary>
			public uint NumSyms;

			/// <summary>
			/// <para>The type of symbols that are loaded. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SymCoff</term>
			/// <term>COFF symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymCv</term>
			/// <term>CodeView symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymDeferred</term>
			/// <term>Symbol loading deferred.</term>
			/// </item>
			/// <item>
			/// <term>SymDia</term>
			/// <term>DIA symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymExport</term>
			/// <term>Symbols generated from a DLL export table.</term>
			/// </item>
			/// <item>
			/// <term>SymNone</term>
			/// <term>No symbols are loaded.</term>
			/// </item>
			/// <item>
			/// <term>SymPdb</term>
			/// <term>PDB symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymSym</term>
			/// <term>.sym file.</term>
			/// </item>
			/// <item>
			/// <term>SymVirtual</term>
			/// <term>The virtual module created by SymLoadModuleEx with SLMFLAG_VIRTUAL.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SYM_TYPE SymType;

			/// <summary>The module name.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string ModuleName;

			/// <summary>The image name. The name may or may not contain a full path.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string ImageName;

			/// <summary>The full path and file name of the file from which symbols were loaded.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string LoadedImageName;
		}

		/// <summary>Contains module information.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_MODULE</c> structure. For more information, see Updated Platform Support.
		/// <c>IMAGEHLP_MODULE</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_MODULE IMAGEHLP_MODULE64 #define PIMAGEHLP_MODULE PIMAGEHLP_MODULE64 #define IMAGEHLP_MODULEW IMAGEHLP_MODULEW64 #define PIMAGEHLP_MODULEW PIMAGEHLP_MODULEW64 #else typedef struct _IMAGEHLP_MODULE { DWORD SizeOfStruct; DWORD BaseOfImage; DWORD ImageSize; DWORD TimeDateStamp; DWORD CheckSum; DWORD NumSyms; SYM_TYPE SymType; CHAR ModuleName[32]; CHAR ImageName[256]; CHAR LoadedImageName[256]; } IMAGEHLP_MODULE, *PIMAGEHLP_MODULE; typedef struct _IMAGEHLP_MODULEW { DWORD SizeOfStruct; DWORD BaseOfImage; DWORD ImageSize; DWORD TimeDateStamp; DWORD CheckSum; DWORD NumSyms; SYM_TYPE SymType; WCHAR ModuleName[32]; WCHAR ImageName[256]; WCHAR LoadedImageName[256]; } IMAGEHLP_MODULEW, *PIMAGEHLP_MODULEW; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_modulew64 typedef struct _IMAGEHLP_MODULEW64 {
		// DWORD SizeOfStruct; DWORD64 BaseOfImage; DWORD ImageSize; DWORD TimeDateStamp; DWORD CheckSum; DWORD NumSyms; SYM_TYPE SymType;
		// WCHAR ModuleName[32]; WCHAR ImageName[256]; WCHAR LoadedImageName[256]; WCHAR LoadedPdbName[256]; DWORD CVSig; WCHAR
		// *CVData[MAX_PATH 3]; DWORD PdbSig; GUID PdbSig70; DWORD PdbAge; BOOL PdbUnmatched; BOOL DbgUnmatched; BOOL LineNumbers; BOOL
		// GlobalSymbols; BOOL TypeInfo; BOOL SourceIndexed; BOOL Publics; DWORD MachineType; DWORD Reserved; } IMAGEHLP_MODULEW64, *PIMAGEHLP_MODULEW64;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_MODULEW64")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct IMAGEHLP_MODULEW64
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_MODULE64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>The base virtual address where the image is loaded.</summary>
			public ulong BaseOfImage;

			/// <summary>The size of the image, in bytes.</summary>
			public uint ImageSize;

			/// <summary>
			/// The date and timestamp value. The value is represented in the number of seconds elapsed since midnight (00:00:00), January
			/// 1, 1970, Universal Coordinated Time, according to the system clock. The timestamp can be printed using the C run-time (CRT)
			/// function <c>ctime</c>.
			/// </summary>
			public uint TimeDateStamp;

			/// <summary>The checksum of the image. This value can be zero.</summary>
			public uint CheckSum;

			/// <summary>
			/// The number of symbols in the symbol table. The value of this parameter is not meaningful when <c>SymPdb</c> is specified as
			/// the value of the SymType parameter.
			/// </summary>
			public uint NumSyms;

			/// <summary>
			/// <para>The type of symbols that are loaded. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SymCoff</term>
			/// <term>COFF symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymCv</term>
			/// <term>CodeView symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymDeferred</term>
			/// <term>Symbol loading deferred.</term>
			/// </item>
			/// <item>
			/// <term>SymDia</term>
			/// <term>DIA symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymExport</term>
			/// <term>Symbols generated from a DLL export table.</term>
			/// </item>
			/// <item>
			/// <term>SymNone</term>
			/// <term>No symbols are loaded.</term>
			/// </item>
			/// <item>
			/// <term>SymPdb</term>
			/// <term>PDB symbols.</term>
			/// </item>
			/// <item>
			/// <term>SymSym</term>
			/// <term>.sym file.</term>
			/// </item>
			/// <item>
			/// <term>SymVirtual</term>
			/// <term>The virtual module created by SymLoadModuleEx with SLMFLAG_VIRTUAL.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SYM_TYPE SymType;

			/// <summary>The module name.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string ModuleName;

			/// <summary>The image name. The name may or may not contain a full path.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string ImageName;

			/// <summary>The full path and file name of the file from which symbols were loaded.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string LoadedImageName;

			/// <summary>The full path and file name of the .pdb file.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string LoadedPdbName;

			/// <summary>The signature of the CV record in the debug directories.</summary>
			public uint CVSig;

			/// <summary>The contents of the CV record.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260 * 3)]
			public string CVData;

			/// <summary>The PDB signature.</summary>
			public uint PdbSig;

			/// <summary>The PDB signature (Visual C/C++ 7.0 and later)</summary>
			public Guid PdbSig70;

			/// <summary>The DBI age of PDB.</summary>
			public uint PdbAge;

			/// <summary>A value that indicates whether the loaded PDB is unmatched.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool PdbUnmatched;

			/// <summary>A value that indicates whether the loaded DBG is unmatched.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool DbgUnmatched;

			/// <summary>A value that indicates whether line number information is available.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool LineNumbers;

			/// <summary>A value that indicates whether symbol information is available.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool GlobalSymbols;

			/// <summary>A value that indicates whether type information is available.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool TypeInfo;

			/// <summary>
			/// <para>A value that indicates whether the .pdb supports the source server.</para>
			/// <para><c>DbgHelp 6.1 and earlier:</c> This member is not supported.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool SourceIndexed;

			/// <summary>
			/// <para>A value that indicates whether the module contains public symbols.</para>
			/// <para><c>DbgHelp 6.1 and earlier:</c> This member is not supported.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool Publics;

			/// <summary/>
			public uint MachineType;

			/// <summary/>
			public uint Reserved;
		}

		/// <summary>Contains the stack frame information. This structure is used with the SymSetContext function.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_stack_frame typedef struct _IMAGEHLP_STACK_FRAME {
		// ULONG64 InstructionOffset; ULONG64 ReturnOffset; ULONG64 FrameOffset; ULONG64 StackOffset; ULONG64 BackingStoreOffset; ULONG64
		// FuncTableEntry; ULONG64 Params[4]; ULONG64 Reserved[5]; BOOL Virtual; ULONG Reserved2; } IMAGEHLP_STACK_FRAME, *PIMAGEHLP_STACK_FRAME;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_STACK_FRAME")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IMAGEHLP_STACK_FRAME
		{
			/// <summary>
			/// <para>The program counter.</para>
			/// <para><c>x86:</c> The program counter is EIP.</para>
			/// <para>
			/// <c>Intel Itanium:</c> The program counter is a combination of the bundle address and a slot indicator of 0, 4, or 8 for the
			/// slot within the bundle.
			/// </para>
			/// <para><c>x64:</c> The program counter is RIP.</para>
			/// </summary>
			public ulong InstructionOffset;

			/// <summary>The return address.</summary>
			public ulong ReturnOffset;

			/// <summary>
			/// <para>The frame pointer.</para>
			/// <para><c>x86:</c> The frame pointer is EBP.</para>
			/// <para><c>Intel Itanium:</c> There is no frame pointer, but <c>AddrBStore</c> is used.</para>
			/// <para><c>x64:</c> The frame pointer is RBP. AMD-64 does not always use this value.</para>
			/// </summary>
			public ulong FrameOffset;

			/// <summary>
			/// <para>The stack pointer.</para>
			/// <para><c>x86:</c> The stack pointer is ESP.</para>
			/// <para><c>Intel Itanium:</c> The stack pointer is SP.</para>
			/// <para><c>x64:</c> The stack pointer is RSP.</para>
			/// </summary>
			public ulong StackOffset;

			/// <summary><c>Intel Itanium:</c> The backing store address.</summary>
			public ulong BackingStoreOffset;

			/// <summary><c>x86:</c> An FPO_DATA structure. If there is no function table entry, this member is <c>NULL</c>.</summary>
			public ulong FuncTableEntry;

			/// <summary>The possible arguments to the function.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
			public ulong[] Params;

			/// <summary>This member is reserved for system use.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
			public ulong[] Reserved;

			/// <summary>If this is a virtual frame, this member is <c>TRUE</c>. Otherwise, this member is <c>FALSE</c>.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool Virtual;

			/// <summary>This member is reserved for system use.</summary>
			public uint Reserved2;
		}

		/// <summary>Contains symbol information.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_SYMBOL</c> structure. For more information, see Updated Platform Support.
		/// <c>IMAGEHLP_SYMBOL</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_SYMBOL IMAGEHLP_SYMBOL64 #define PIMAGEHLP_SYMBOL PIMAGEHLP_SYMBOL64 #else typedef struct _IMAGEHLP_SYMBOL { DWORD SizeOfStruct; DWORD Address; DWORD Size; DWORD Flags; DWORD MaxNameLength; CHAR Name[1]; } IMAGEHLP_SYMBOL, *PIMAGEHLP_SYMBOL; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_symbol typedef struct _IMAGEHLP_SYMBOL { DWORD
		// SizeOfStruct; DWORD Address; DWORD Size; DWORD Flags; DWORD MaxNameLength; CHAR Name[1]; } IMAGEHLP_SYMBOL, *PIMAGEHLP_SYMBOL;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_SYMBOL")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IMAGEHLP_SYMBOL
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_SYMBOL64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>The virtual address for the symbol.</summary>
			public uint Address;

			/// <summary>The size of the symbol, in bytes. This value is a best guess and can be zero.</summary>
			public uint Size;

			/// <summary>This member is reserved for use by the operating system.</summary>
			public uint Flags;

			/// <summary>
			/// The maximum length of the string that the <c>Name</c> member can contain, in characters, not including the null-terminating
			/// character. Because symbol names can vary in length, this data structure is allocated by the caller. This member is used so
			/// the library knows how much memory is available for use by the symbol name.
			/// </summary>
			public uint MaxNameLength;

			/// <summary>
			/// The decorated or undecorated symbol name. If the buffer is not large enough for the complete name, it is truncated to
			/// <c>MaxNameLength</c> characters, including the null-terminating character.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
			public string Name;
		}

		/// <summary>Contains symbol information.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_SYMBOL</c> structure. For more information, see Updated Platform Support.
		/// <c>IMAGEHLP_SYMBOL</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_SYMBOL IMAGEHLP_SYMBOL64 #define PIMAGEHLP_SYMBOL PIMAGEHLP_SYMBOL64 #else typedef struct _IMAGEHLP_SYMBOL { DWORD SizeOfStruct; DWORD Address; DWORD Size; DWORD Flags; DWORD MaxNameLength; CHAR Name[1]; } IMAGEHLP_SYMBOL, *PIMAGEHLP_SYMBOL; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_symbol64 typedef struct _IMAGEHLP_SYMBOL64 { DWORD
		// SizeOfStruct; DWORD64 Address; DWORD Size; DWORD Flags; DWORD MaxNameLength; CHAR Name[1]; } IMAGEHLP_SYMBOL64, *PIMAGEHLP_SYMBOL64;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_SYMBOL64")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct IMAGEHLP_SYMBOL64
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_SYMBOL64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>The virtual address for the symbol.</summary>
			public ulong Address;

			/// <summary>The size of the symbol, in bytes. This value is a best guess and can be zero.</summary>
			public uint Size;

			/// <summary>This member is reserved for use by the operating system.</summary>
			public uint Flags;

			/// <summary>
			/// The maximum length of the string that the <c>Name</c> member can contain, in characters, not including the null-terminating
			/// character. Because symbol names can vary in length, this data structure is allocated by the caller. This member is used so
			/// the library knows how much memory is available for use by the symbol name.
			/// </summary>
			public uint MaxNameLength;

			/// <summary>
			/// The decorated or undecorated symbol name. If the buffer is not large enough for the complete name, it is truncated to
			/// <c>MaxNameLength</c> characters, including the null-terminating character.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
			public string Name;
		}

		/// <summary>Contains symbol information.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_SYMBOL</c> structure. For more information, see Updated Platform Support.
		/// <c>IMAGEHLP_SYMBOL</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_SYMBOL IMAGEHLP_SYMBOL64 #define PIMAGEHLP_SYMBOL PIMAGEHLP_SYMBOL64 #else typedef struct _IMAGEHLP_SYMBOL { DWORD SizeOfStruct; DWORD Address; DWORD Size; DWORD Flags; DWORD MaxNameLength; CHAR Name[1]; } IMAGEHLP_SYMBOL, *PIMAGEHLP_SYMBOL; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_symbol typedef struct _IMAGEHLP_SYMBOL { DWORD
		// SizeOfStruct; DWORD Address; DWORD Size; DWORD Flags; DWORD MaxNameLength; CHAR Name[1]; } IMAGEHLP_SYMBOL, *PIMAGEHLP_SYMBOL;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_SYMBOL")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct IMAGEHLP_SYMBOLW
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_SYMBOL64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>The virtual address for the symbol.</summary>
			public uint Address;

			/// <summary>The size of the symbol, in bytes. This value is a best guess and can be zero.</summary>
			public uint Size;

			/// <summary>This member is reserved for use by the operating system.</summary>
			public uint Flags;

			/// <summary>
			/// The maximum length of the string that the <c>Name</c> member can contain, in characters, not including the null-terminating
			/// character. Because symbol names can vary in length, this data structure is allocated by the caller. This member is used so
			/// the library knows how much memory is available for use by the symbol name.
			/// </summary>
			public uint MaxNameLength;

			/// <summary>
			/// The decorated or undecorated symbol name. If the buffer is not large enough for the complete name, it is truncated to
			/// <c>MaxNameLength</c> characters, including the null-terminating character.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
			public string Name;
		}

		/// <summary>Contains symbol information.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>IMAGEHLP_SYMBOL</c> structure. For more information, see Updated Platform Support.
		/// <c>IMAGEHLP_SYMBOL</c> is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define IMAGEHLP_SYMBOL IMAGEHLP_SYMBOL64 #define PIMAGEHLP_SYMBOL PIMAGEHLP_SYMBOL64 #else typedef struct _IMAGEHLP_SYMBOL { DWORD SizeOfStruct; DWORD Address; DWORD Size; DWORD Flags; DWORD MaxNameLength; CHAR Name[1]; } IMAGEHLP_SYMBOL, *PIMAGEHLP_SYMBOL; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-imagehlp_symbolw64 typedef struct _IMAGEHLP_SYMBOLW64 {
		// DWORD SizeOfStruct; DWORD64 Address; DWORD Size; DWORD Flags; DWORD MaxNameLength; WCHAR Name[1]; } IMAGEHLP_SYMBOLW64, *PIMAGEHLP_SYMBOLW64;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_SYMBOLW64")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct IMAGEHLP_SYMBOLW64
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this member to
			/// <code>sizeof(IMAGEHLP_SYMBOL64)</code>
			/// .
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>The virtual address for the symbol.</summary>
			public ulong Address;

			/// <summary>The size of the symbol, in bytes. This value is a best guess and can be zero.</summary>
			public uint Size;

			/// <summary>This member is reserved for use by the operating system.</summary>
			public uint Flags;

			/// <summary>
			/// The maximum length of the string that the <c>Name</c> member can contain, in characters, not including the null-terminating
			/// character. Because symbol names can vary in length, this data structure is allocated by the caller. This member is used so
			/// the library knows how much memory is available for use by the symbol name.
			/// </summary>
			public uint MaxNameLength;

			/// <summary>
			/// The decorated or undecorated symbol name. If the buffer is not large enough for the complete name, it is truncated to
			/// <c>MaxNameLength</c> characters, including the null-terminating character.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
			public string Name;
		}

		/// <summary>Information that is used by kernel debuggers to trace through user-mode callbacks in a thread's kernel stack.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>KDHELP</c> structure. For more information, see Updated Platform Support. <c>KDHELP</c> is
		/// defined as follows in Dbghelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define KDHELP KDHELP64 #define PKDHELP PKDHELP64 #else typedef struct _KDHELP { DWORD Thread; DWORD ThCallbackStack; DWORD NextCallback; DWORD FramePointer; DWORD KiCallUserMode; DWORD KeUserCallbackDispatcher; DWORD SystemRangeStart; DWORD ThCallbackBStore; DWORD KiUserExceptionDispatcher; DWORD StackBase; DWORD StackLimit; DWORD Reserved[5]; } KDHELP, *PKDHELP; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-kdhelp typedef struct _KDHELP { DWORD Thread; DWORD
		// ThCallbackStack; DWORD NextCallback; DWORD FramePointer; DWORD KiCallUserMode; DWORD KeUserCallbackDispatcher; DWORD
		// SystemRangeStart; DWORD ThCallbackBStore; DWORD KiUserExceptionDispatcher; DWORD StackBase; DWORD StackLimit; DWORD Reserved[5];
		// } KDHELP, *PKDHELP;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._KDHELP")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct KDHELP
		{
			/// <summary>The address of the kernel thread object, as provided in the WAIT_STATE_CHANGE packet.</summary>
			public uint Thread;

			/// <summary>The offset in the thread object to the pointer to the current callback frame in the kernel stack.</summary>
			public uint ThCallbackStack;

			/// <summary>The address of the next callback frame.</summary>
			public uint NextCallback;

			/// <summary>The address of the saved frame pointer, if applicable.</summary>
			public uint FramePointer;

			/// <summary>The address of the kernel function that calls out to user mode.</summary>
			public uint KiCallUserMode;

			/// <summary>The address of the user-mode dispatcher function.</summary>
			public uint KeUserCallbackDispatcher;

			/// <summary>The lowest kernel-mode address.</summary>
			public uint SystemRangeStart;

			/// <summary>
			/// <c>Intel Itanium:</c> The offset in the thread object to a pointer to the current callback backing store frame in the kernel stack.
			/// </summary>
			public uint ThCallbackBStore;

			/// <summary>
			/// <para>The address of the user-mode exception dispatcher function.</para>
			/// <para><c>DbgHelp 6.1 and earlier:</c> This member is not supported.</para>
			/// </summary>
			public uint KiUserExceptionDispatcher;

			/// <summary>The address of the stack base.</summary>
			public uint StackBase;

			/// <summary>The stack limit.</summary>
			public uint StackLimit;

			/// <summary>This member is reserved for use by the operating system.</summary>
			private uint Reserved0;

			private uint Reserved1;
			private uint Reserved2;
			private uint Reserved3;
			private uint Reserved4;
		}

		/// <summary>Information that is used by kernel debuggers to trace through user-mode callbacks in a thread's kernel stack.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>KDHELP</c> structure. For more information, see Updated Platform Support. <c>KDHELP</c> is
		/// defined as follows in Dbghelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define KDHELP KDHELP64 #define PKDHELP PKDHELP64 #else typedef struct _KDHELP { DWORD Thread; DWORD ThCallbackStack; DWORD NextCallback; DWORD FramePointer; DWORD KiCallUserMode; DWORD KeUserCallbackDispatcher; DWORD SystemRangeStart; DWORD ThCallbackBStore; DWORD KiUserExceptionDispatcher; DWORD StackBase; DWORD StackLimit; DWORD Reserved[5]; } KDHELP, *PKDHELP; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-kdhelp typedef struct _KDHELP { DWORD Thread; DWORD
		// ThCallbackStack; DWORD NextCallback; DWORD FramePointer; DWORD KiCallUserMode; DWORD KeUserCallbackDispatcher; DWORD
		// SystemRangeStart; DWORD ThCallbackBStore; DWORD KiUserExceptionDispatcher; DWORD StackBase; DWORD StackLimit; DWORD Reserved[5];
		// } KDHELP, *PKDHELP;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._KDHELP")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct KDHELP64
		{
			/// <summary>The address of the kernel thread object, as provided in the WAIT_STATE_CHANGE packet.</summary>
			public ulong Thread;

			/// <summary>The offset in the thread object to the pointer to the current callback frame in the kernel stack.</summary>
			public uint ThCallbackStack;

			/// <summary>
			/// <c>Intel Itanium:</c> The offset in the thread object to a pointer to the current callback backing store frame in the kernel stack.
			/// </summary>
			public uint ThCallbackBStore;

			/// <summary>The address of the next callback frame.</summary>
			public uint NextCallback;

			/// <summary>The address of the saved frame pointer, if applicable.</summary>
			public uint FramePointer;

			/// <summary>The address of the kernel function that calls out to user mode.</summary>
			public ulong KiCallUserMode;

			/// <summary>The address of the user-mode dispatcher function.</summary>
			public ulong KeUserCallbackDispatcher;

			/// <summary>The lowest kernel-mode address.</summary>
			public ulong SystemRangeStart;

			/// <summary>
			/// <para>The address of the user-mode exception dispatcher function.</para>
			/// <para><c>DbgHelp 6.1 and earlier:</c> This member is not supported.</para>
			/// </summary>
			public ulong KiUserExceptionDispatcher;

			/// <summary>The address of the stack base.</summary>
			public ulong StackBase;

			/// <summary>The stack limit.</summary>
			public ulong StackLimit;

			/// <summary>Target OS build number.</summary>
			public uint BuildVersion;

			/// <summary/>
			public uint RetpolineStubFunctionTableSize;

			/// <summary/>
			public ulong RetpolineStubFunctionTable;

			/// <summary/>
			public uint RetpolineStubOffset;

			/// <summary/>
			public uint RetpolineStubSize;

			/// <summary>This member is reserved for use by the operating system.</summary>
			private ulong Reserved0;

			private ulong Reserved1;
		}

		/// <summary>Contains information about the loaded image.</summary>
		/// <remarks>
		/// <para>The <c>LIST_ENTRY</c> structure is defined as follows:</para>
		/// <para>
		/// <code>typedef struct _LIST_ENTRY { struct _LIST_ENTRY *Flink; struct _LIST_ENTRY *Blink; } LIST_ENTRY, *PLIST_ENTRY, *RESTRICTED_POINTER PRLIST_ENTRY;</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-loaded_image typedef struct _LOADED_IMAGE { PSTR
		// ModuleName; HANDLE hFile; PUCHAR MappedAddress; #if ... PIMAGE_NT_HEADERS64 FileHeader; #else PIMAGE_NT_HEADERS32 FileHeader;
		// #endif PIMAGE_SECTION_HEADER LastRvaSection; ULONG NumberOfSections; PIMAGE_SECTION_HEADER Sections; ULONG Characteristics;
		// BOOLEAN fSystemImage; BOOLEAN fDOSImage; BOOLEAN fReadOnly; UCHAR Version; LIST_ENTRY Links; ULONG SizeOfImage; } LOADED_IMAGE, *PLOADED_IMAGE;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._LOADED_IMAGE")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct LOADED_IMAGE
		{
			/// <summary>The file name of the mapped file.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string ModuleName;

			/// <summary>A handle to the mapped file.</summary>
			public HFILE hFile;

			/// <summary>The base address of the mapped file.</summary>
			public IntPtr MappedAddress;

			/// <summary>A pointer to an <see cref="IMAGE_NT_HEADERS"/> structure.</summary>
			public IntPtr FileHeader;

			/// <summary>A pointer to an <see cref="IMAGE_SECTION_HEADER"/> structure.</summary>
			public IntPtr LastRvaSection;

			/// <summary>The number of COFF section headers.</summary>
			public uint NumberOfSections;

			/// <summary>A pointer to an IMAGE_SECTION_HEADER structure.</summary>
			public IntPtr Sections;

			/// <summary>
			/// <para>The image characteristics value. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IMAGE_FILE_RELOCS_STRIPPED 0x0001</term>
			/// <term>Relocation information is stripped from the file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_EXECUTABLE_IMAGE 0x0002</term>
			/// <term>The file is executable (there are no unresolved external references).</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_LINE_NUMS_STRIPPED 0x0004</term>
			/// <term>Line numbers are stripped from the file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_LOCAL_SYMS_STRIPPED 0x0008</term>
			/// <term>Local symbols are stripped from file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_AGGRESIVE_WS_TRIM 0x0010</term>
			/// <term>Aggressively trim the working set.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_LARGE_ADDRESS_AWARE 0x0020</term>
			/// <term>The application can handle addresses larger than 2 GB.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_BYTES_REVERSED_LO 0x0080</term>
			/// <term>Bytes of word are reversed.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_32BIT_MACHINE 0x0100</term>
			/// <term>Computer supports 32-bit words.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_DEBUG_STRIPPED 0x0200</term>
			/// <term>Debugging information is stored separately in a .dbg file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_REMOVABLE_RUN_FROM_SWAP 0x0400</term>
			/// <term>If the image is on removable media, copy and run from the swap file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_NET_RUN_FROM_SWAP 0x0800</term>
			/// <term>If the image is on the network, copy and run from the swap file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_SYSTEM 0x1000</term>
			/// <term>System file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_DLL 0x2000</term>
			/// <term>DLL file.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_UP_SYSTEM_ONLY 0x4000</term>
			/// <term>File should be run only on a uniprocessor computer.</term>
			/// </item>
			/// <item>
			/// <term>IMAGE_FILE_BYTES_REVERSED_HI 0x8000</term>
			/// <term>Bytes of the word are reversed.</term>
			/// </item>
			/// </list>
			/// </summary>
			public IMAGE_FILE Characteristics;

			/// <summary>If the image is a kernel mode executable image, this value is <c>TRUE</c>.</summary>
			[MarshalAs(UnmanagedType.U1)]
			public bool fSystemImage;

			/// <summary>If the image is a 16-bit executable image, this value is <c>TRUE</c>.</summary>
			[MarshalAs(UnmanagedType.U1)]
			public bool fDOSImage;

			/// <summary>
			/// <para>If the image is read-only, this value is <c>TRUE</c>.</para>
			/// <para><c>Prior to Windows Vista:</c> This member is not included in the structure.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)]
			public bool fReadOnly;

			/// <summary>
			/// <para>The version string.</para>
			/// <para><c>Prior to Windows Vista:</c> This member is not included in the structure.</para>
			/// </summary>
			public byte Version;

			/// <summary>The list of loaded images.</summary>
			public LIST_ENTRY Links;

			/// <summary>The size of the image, in bytes.</summary>
			public uint SizeOfImage;
		}

		/// <summary>Contains CodeView and Misc records.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-modload_cvmisc typedef struct _MODLOAD_CVMISC { DWORD oCV;
		// size_t cCV; DWORD oMisc; size_t cMisc; DWORD dtImage; DWORD cImage; } MODLOAD_CVMISC, *PMODLOAD_CVMISC;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._MODLOAD_CVMISC")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MODLOAD_CVMISC
		{
			/// <summary>The offset of the CodeView record.</summary>
			public uint oCV;

			/// <summary>The size of the CodeView record.</summary>
			public SizeT cCV;

			/// <summary>The offset of the Misc record.</summary>
			public uint oMisc;

			/// <summary>The size of the Misc record.</summary>
			public SizeT cMisc;

			/// <summary>The date/time stamp of the image.</summary>
			public uint dtImage;

			/// <summary>The size of the image.</summary>
			public uint cImage;
		}

		/// <summary>Contains module data.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-modload_data typedef struct _MODLOAD_DATA { DWORD ssize;
		// DWORD ssig; PVOID data; DWORD size; DWORD flags; } MODLOAD_DATA, *PMODLOAD_DATA;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._MODLOAD_DATA")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MODLOAD_DATA
		{
			/// <summary>The size of this structure, in bytes.</summary>
			public uint ssize;

			/// <summary>
			/// <para>The type of data. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DBHHEADER_DEBUGDIRS 0x1</term>
			/// <term>The data member is a buffer that contains an array of IMAGE_DEBUG_DIRECTORY structures.</term>
			/// </item>
			/// <item>
			/// <term>DBHHEADER_CVMISC 0x2</term>
			/// <term>The data member is a buffer that contains an array of MODLOAD_CVMISC structures.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint ssig;

			/// <summary>The data. The format of this data depends on the value of the <c>ssig</c> member.</summary>
			public IntPtr data;

			/// <summary>The size of the <c>data</c> buffer, in bytes.</summary>
			public uint size;

			/// <summary>This member is unused.</summary>
			public uint flags;
		}

		/// <summary>Describes an entry in an address map.</summary>
		/// <remarks>
		/// <para>
		/// An address map provides a translation from one image layout (A) to another (B). An array of OMAP structures, sorted by
		/// <c>rva</c>, defines an address map.
		/// </para>
		/// <para>To translate an address, addrA, in image A to an address, addrB, in image B, perform the following steps:</para>
		/// <list type="number">
		/// <item>
		/// <term>Search the map for the entry, e, with the largest rva less than or equal to addrA.</term>
		/// </item>
		/// <item>
		/// <term>Set delta = addrA – e.rva.</term>
		/// </item>
		/// <item>
		/// <term>Set addrB = e.rvaTo + delta.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-omap typedef struct _OMAP { ULONG rva; ULONG rvaTo; } OMAP, *POMAP;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._OMAP")]
		[StructLayout(LayoutKind.Sequential)]
		public struct OMAP
		{
			/// <summary>A relative virtual address (RVA) in image A.</summary>
			public uint rva;

			/// <summary>The relative virtual address that <c>rva</c> is mapped to in image B.</summary>
			public uint rvaTo;
		}

		/// <summary>Contains source file information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-sourcefile typedef struct _SOURCEFILE { DWORD64 ModBase;
		// PCHAR FileName; } SOURCEFILE, *PSOURCEFILE;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._SOURCEFILE")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SOURCEFILE
		{
			/// <summary>The base address of the module.</summary>
			public ulong ModBase;

			/// <summary>The fully qualified source file name.</summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string FileName;
		}

		/// <summary>Contains line information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-srccodeinfo typedef struct _SRCCODEINFO { DWORD
		// SizeOfStruct; PVOID Key; DWORD64 ModBase; CHAR Obj[MAX_PATH + 1]; CHAR FileName[MAX_PATH + 1]; DWORD LineNumber; DWORD64 Address;
		// } SRCCODEINFO, *PSRCCODEINFO;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._SRCCODEINFO")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SRCCODEINFO
		{
			/// <summary>The size of the structure, in bytes.</summary>
			public uint SizeOfStruct;

			/// <summary>This member is not used.</summary>
			public IntPtr Key;

			/// <summary>The base address of the module that contains the line.</summary>
			public ulong ModBase;

			/// <summary>The name of the object file within the module that contains the line.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 261 /*MAX_PATH + 1*/)]
			public string Obj;

			/// <summary>The fully qualified source file name.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 261 /*MAX_PATH + 1*/)]
			public string FileName;

			/// <summary>The line number within the source file.</summary>
			public uint LineNumber;

			/// <summary>The virtual address of the first instruction of the line.</summary>
			public ulong Address;
		}

		/// <summary>Represents a stack frame.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>STACKFRAME</c> structure. For more information, see Updated Platform Support. <c>STACKFRAME</c>
		/// is defined as follows in Dbghelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define STACKFRAME STACKFRAME64 #define LPSTACKFRAME LPSTACKFRAME64 #else typedef struct _tagSTACKFRAME { ADDRESS AddrPC; ADDRESS AddrReturn; ADDRESS AddrFrame; ADDRESS AddrStack; PVOID FuncTableEntry; DWORD Params[4]; BOOL Far; BOOL Virtual; DWORD Reserved[3]; KDHELP KdHelp; ADDRESS AddrBStore; } STACKFRAME, *LPSTACKFRAME; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-stackframe64 typedef struct _tagSTACKFRAME64 { ADDRESS64
		// AddrPC; ADDRESS64 AddrReturn; ADDRESS64 AddrFrame; ADDRESS64 AddrStack; ADDRESS64 AddrBStore; PVOID FuncTableEntry; DWORD64
		// Params[4]; BOOL Far; BOOL Virtual; DWORD64 Reserved[3]; KDHELP64 KdHelp; } STACKFRAME64, *LPSTACKFRAME64;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._tagSTACKFRAME64")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct STACKFRAME
		{
			/// <summary>
			/// <para>An ADDRESS64 structure that specifies the program counter.</para>
			/// <para><c>x86:</c> The program counter is EIP.</para>
			/// <para><c>Intel Itanium:</c> The program counter is StIIP.</para>
			/// <para><c>x64:</c> The program counter is RIP.</para>
			/// </summary>
			public ADDRESS AddrPC;

			/// <summary>An ADDRESS64 structure that specifies the return address.</summary>
			public ADDRESS AddrReturn;

			/// <summary>
			/// <para>An ADDRESS64 structure that specifies the frame pointer.</para>
			/// <para><c>x86:</c> The frame pointer is EBP.</para>
			/// <para><c>Intel Itanium:</c> There is no frame pointer, but <c>AddrBStore</c> is used.</para>
			/// <para><c>x64:</c> The frame pointer is RBP or RDI. This value is not always used.</para>
			/// </summary>
			public ADDRESS AddrFrame;

			/// <summary>
			/// <para>An ADDRESS64 structure that specifies the stack pointer.</para>
			/// <para><c>x86:</c> The stack pointer is ESP.</para>
			/// <para><c>Intel Itanium:</c> The stack pointer is SP.</para>
			/// <para><c>x64:</c> The stack pointer is RSP.</para>
			/// </summary>
			public ADDRESS AddrStack;

			/// <summary>
			/// On x86 computers, this member is an FPO_DATA structure. If there is no function table entry, this member is <c>NULL</c>.
			/// </summary>
			public IntPtr FuncTableEntry;

			/// <summary>The possible arguments to the function.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
			public uint[] Params;

			/// <summary>This member is <c>TRUE</c> if this is a WOW far call.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool Far;

			/// <summary>This member is <c>TRUE</c> if this is a virtual frame.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool Virtual;

			/// <summary>This member is used internally by the StackWalk64 function.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
			public uint[] Reserved;

			/// <summary>A KDHELP64 structure that specifies helper data for walking kernel callback frames.</summary>
			public KDHELP KdHelp;

			/// <summary><c>Intel Itanium:</c> An ADDRESS64 structure that specifies the backing store (RsBSP).</summary>
			public ADDRESS AddrBStore;
		}

		/// <summary>Represents an extended stack frame.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-stackframe_ex typedef struct _tagSTACKFRAME_EX { ADDRESS64
		// AddrPC; ADDRESS64 AddrReturn; ADDRESS64 AddrFrame; ADDRESS64 AddrStack; ADDRESS64 AddrBStore; PVOID FuncTableEntry; DWORD64
		// Params[4]; BOOL Far; BOOL Virtual; DWORD64 Reserved[3]; KDHELP64 KdHelp; DWORD StackFrameSize; DWORD InlineFrameContext; }
		// STACKFRAME_EX, *LPSTACKFRAME_EX;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._tagSTACKFRAME_EX")]
		[StructLayout(LayoutKind.Sequential)]
		public struct STACKFRAME_EX
		{
			/// <summary>
			/// <para>An ADDRESS64 structure that specifies the program counter.</para>
			/// <para><c>x86:</c> The program counter is EIP.</para>
			/// <para><c>Intel Itanium:</c> The program counter is StIIP.</para>
			/// <para><c>x64:</c> The program counter is RIP.</para>
			/// </summary>
			public ADDRESS64 AddrPC;

			/// <summary>An ADDRESS64 structure that specifies the return address.</summary>
			public ADDRESS64 AddrReturn;

			/// <summary>
			/// <para>An ADDRESS64 structure that specifies the frame pointer.</para>
			/// <para><c>x86:</c> The frame pointer is EBP.</para>
			/// <para><c>Intel Itanium:</c> There is no frame pointer, but <c>AddrBStore</c> is used.</para>
			/// <para><c>x64:</c> The frame pointer is RBP or RDI. This value is not always used.</para>
			/// </summary>
			public ADDRESS64 AddrFrame;

			/// <summary>
			/// <para>An ADDRESS64 structure that specifies the stack pointer.</para>
			/// <para><c>x86:</c> The stack pointer is ESP.</para>
			/// <para><c>Intel Itanium:</c> The stack pointer is SP.</para>
			/// <para><c>x64:</c> The stack pointer is RSP.</para>
			/// </summary>
			public ADDRESS64 AddrStack;

			/// <summary><c>Intel Itanium:</c> An ADDRESS64 structure that specifies the backing store (RsBSP).</summary>
			public ADDRESS64 AddrBStore;

			/// <summary>
			/// On x86 computers, this member is an FPO_DATA structure. If there is no function table entry, this member is <c>NULL</c>.
			/// </summary>
			public IntPtr FuncTableEntry;

			/// <summary>The possible arguments to the function.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
			public ulong[] Params;

			/// <summary>This member is <c>TRUE</c> if this is a WOW far call.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool Far;

			/// <summary>This member is <c>TRUE</c> if this is a virtual frame.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool Virtual;

			/// <summary>This member is used internally by the StackWalkEx function.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
			public ulong[] Reserved;

			/// <summary>A KDHELP64 structure that specifies helper data for walking kernel callback frames.</summary>
			public KDHELP64 KdHelp;

			/// <summary>
			/// Set to
			/// <code>sizeof(STACKFRAME_EX)</code>
			/// .
			/// </summary>
			public uint StackFrameSize;

			/// <summary>
			/// <para>Specifies the type of the inline frame context.</para>
			/// <para>INLINE_FRAME_CONTEXT_INIT (0)</para>
			/// <para>INLINE_FRAME_CONTEXT_IGNORE (0xffffffff)</para>
			/// </summary>
			public INLINE_FRAME_CONTEXT InlineFrameContext;
		}

		/// <summary>Represents a stack frame.</summary>
		/// <remarks>
		/// <para>
		/// This structure supersedes the <c>STACKFRAME</c> structure. For more information, see Updated Platform Support. <c>STACKFRAME</c>
		/// is defined as follows in Dbghelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define STACKFRAME STACKFRAME64 #define LPSTACKFRAME LPSTACKFRAME64 #else typedef struct _tagSTACKFRAME { ADDRESS AddrPC; ADDRESS AddrReturn; ADDRESS AddrFrame; ADDRESS AddrStack; PVOID FuncTableEntry; DWORD Params[4]; BOOL Far; BOOL Virtual; DWORD Reserved[3]; KDHELP KdHelp; ADDRESS AddrBStore; } STACKFRAME, *LPSTACKFRAME; #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-stackframe64 typedef struct _tagSTACKFRAME64 { ADDRESS64
		// AddrPC; ADDRESS64 AddrReturn; ADDRESS64 AddrFrame; ADDRESS64 AddrStack; ADDRESS64 AddrBStore; PVOID FuncTableEntry; DWORD64
		// Params[4]; BOOL Far; BOOL Virtual; DWORD64 Reserved[3]; KDHELP64 KdHelp; } STACKFRAME64, *LPSTACKFRAME64;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._tagSTACKFRAME64")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct STACKFRAME64
		{
			/// <summary>
			/// <para>An ADDRESS64 structure that specifies the program counter.</para>
			/// <para><c>x86:</c> The program counter is EIP.</para>
			/// <para><c>Intel Itanium:</c> The program counter is StIIP.</para>
			/// <para><c>x64:</c> The program counter is RIP.</para>
			/// </summary>
			public ADDRESS64 AddrPC;

			/// <summary>An ADDRESS64 structure that specifies the return address.</summary>
			public ADDRESS64 AddrReturn;

			/// <summary>
			/// <para>An ADDRESS64 structure that specifies the frame pointer.</para>
			/// <para><c>x86:</c> The frame pointer is EBP.</para>
			/// <para><c>Intel Itanium:</c> There is no frame pointer, but <c>AddrBStore</c> is used.</para>
			/// <para><c>x64:</c> The frame pointer is RBP or RDI. This value is not always used.</para>
			/// </summary>
			public ADDRESS64 AddrFrame;

			/// <summary>
			/// <para>An ADDRESS64 structure that specifies the stack pointer.</para>
			/// <para><c>x86:</c> The stack pointer is ESP.</para>
			/// <para><c>Intel Itanium:</c> The stack pointer is SP.</para>
			/// <para><c>x64:</c> The stack pointer is RSP.</para>
			/// </summary>
			public ADDRESS64 AddrStack;

			/// <summary><c>Intel Itanium:</c> An ADDRESS64 structure that specifies the backing store (RsBSP).</summary>
			public ADDRESS64 AddrBStore;

			/// <summary>
			/// On x86 computers, this member is an FPO_DATA structure. If there is no function table entry, this member is <c>NULL</c>.
			/// </summary>
			public IntPtr FuncTableEntry;

			/// <summary>The possible arguments to the function.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
			public ulong[] Params;

			/// <summary>This member is <c>TRUE</c> if this is a WOW far call.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool Far;

			/// <summary>This member is <c>TRUE</c> if this is a virtual frame.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool Virtual;

			/// <summary>This member is used internally by the StackWalk64 function.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
			public ulong[] Reserved;

			/// <summary>A KDHELP64 structure that specifies helper data for walking kernel callback frames.</summary>
			public KDHELP64 KdHelp;
		}

		/// <summary>Contains symbol information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-symbol_info typedef struct _SYMBOL_INFO { ULONG
		// SizeOfStruct; ULONG TypeIndex; ULONG64 Reserved[2]; ULONG Index; ULONG Size; ULONG64 ModBase; ULONG Flags; ULONG64 Value; ULONG64
		// Address; ULONG Register; ULONG Scope; ULONG Tag; ULONG NameLen; ULONG MaxNameLen; CHAR Name[1]; } SYMBOL_INFO, *PSYMBOL_INFO;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._SYMBOL_INFO")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SYMBOL_INFO
		{
			/// <summary>
			/// The size of the structure, in bytes. This member must be set to
			/// <code>sizeof(SYMBOL_INFO)</code>
			/// . Note that the total size of the data is the
			/// <code>SizeOfStruct + (MaxNameLen - 1) * sizeof(TCHAR)</code>
			/// . The reason to subtract one is that the first character in the name is accounted for in the size of the structure.
			/// </summary>
			public uint SizeOfStruct;

			/// <summary>
			/// A unique value that identifies the type data that describes the symbol. This value does not persist between sessions.
			/// </summary>
			public uint TypeIndex;

			/// <summary>This member is reserved for system use.</summary>
			public ulong Reserved0;

			private ulong Reserved1;

			/// <summary>
			/// <para>
			/// The unique value for the symbol. The value associated with a symbol is not guaranteed to be the same each time you run the process.
			/// </para>
			/// <para>
			/// For PDB symbols, the index value for a symbol is not generated until the symbol is enumerated or retrieved through a search
			/// by name or address. The index values for all CodeView and COFF symbols are generated when the symbols are loaded.
			/// </para>
			/// </summary>
			public uint Index;

			/// <summary>
			/// The symbol size, in bytes. This value is meaningful only if the module symbols are from a pdb file; otherwise, this value is
			/// typically zero and should be ignored.
			/// </summary>
			public uint Size;

			/// <summary>The base address of the module that contains the symbol.</summary>
			public ulong ModBase;

			/// <summary>
			/// <para>This member can be one or more of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SYMFLAG_CLR_TOKEN 0x00040000</term>
			/// <term>The symbol is a CLR token.</term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_CONSTANT 0x00000100</term>
			/// <term>The symbol is a constant.</term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_EXPORT 0x00000200</term>
			/// <term>The symbol is from the export table.</term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_FORWARDER 0x00000400</term>
			/// <term>The symbol is a forwarder.</term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_FRAMEREL 0x00000020</term>
			/// <term>Offsets are frame relative.</term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_FUNCTION 0x00000800</term>
			/// <term>The symbol is a known function.</term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_ILREL 0x00010000</term>
			/// <term>
			/// The symbol address is an offset relative to the beginning of the intermediate language block. This applies to managed code only.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_LOCAL 0x00000080</term>
			/// <term>The symbol is a local variable.</term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_METADATA 0x00020000</term>
			/// <term>The symbol is managed metadata.</term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_PARAMETER 0x00000040</term>
			/// <term>The symbol is a parameter.</term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_REGISTER 0x00000008</term>
			/// <term>The symbol is a register. The Register member is used.</term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_REGREL 0x00000010</term>
			/// <term>Offsets are register relative.</term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_SLOT 0x00008000</term>
			/// <term>The symbol is a managed code slot.</term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_THUNK 0x00002000</term>
			/// <term>The symbol is a thunk.</term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_TLSREL 0x00004000</term>
			/// <term>The symbol is an offset into the TLS data area.</term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_VALUEPRESENT 0x00000001</term>
			/// <term>The Value member is used.</term>
			/// </item>
			/// <item>
			/// <term>SYMFLAG_VIRTUAL 0x00001000</term>
			/// <term>The symbol is a virtual symbol created by the SymAddSymbol function.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SYMFLAG Flags;

			/// <summary>The value of a constant.</summary>
			public ulong Value;

			/// <summary>The virtual address of the start of the symbol.</summary>
			public ulong Address;

			/// <summary>The register.</summary>
			public uint Register;

			/// <summary>
			/// <para>
			/// The DIA scope. For more information, see the Debug Interface Access SDK in the Visual Studio documentation. (This resource
			/// may not be available in some languages
			/// </para>
			/// <para>and countries.)</para>
			/// </summary>
			public uint Scope;

			/// <summary>The PDB classification. These values are defined in Dbghelp.h in the SymTagEnum enumeration type.</summary>
			public uint Tag;

			/// <summary>The length of the name, in characters, not including the null-terminating character.</summary>
			public uint NameLen;

			/// <summary>The size of the <c>Name</c> buffer, in characters. If this member is 0, the <c>Name</c> member is not used.</summary>
			public uint MaxNameLen;

			/// <summary>
			/// The name of the symbol. The name can be undecorated if the SYMOPT_UNDNAME option is used with the SymSetOptions function.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
			public string Name;
		}

		/// <summary>Contains symbol server index information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-symsrv_index_info typedef struct { DWORD sizeofstruct; char
		// file[MAX_PATH + 1]; BOOL stripped; DWORD timestamp; DWORD size; char dbgfile[MAX_PATH + 1]; char pdbfile[MAX_PATH + 1]; GUID
		// guid; DWORD sig; DWORD age; } SYMSRV_INDEX_INFO, *PSYMSRV_INDEX_INFO;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp.__unnamed_struct_0")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SYMSRV_INDEX_INFO
		{
			/// <summary>
			/// The size of the structure, in bytes. This member must be set to
			/// <code>sizeof(SYMSRV_INDEX_INFO)</code>
			/// or
			/// <code>sizeof(SYMSRV_INDEX_INFOW)</code>
			/// .
			/// </summary>
			public uint sizeofstruct;

			/// <summary>The name of the .pdb, .dbg, or image file.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 261 /*MAX_PATH + 1*/)]
			public string file;

			/// <summary>A value that indicates whether the image file is stripped.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool stripped;

			/// <summary>The timestamp from the PE header. This member is used only for image files.</summary>
			public uint timestamp;

			/// <summary>The file size from the PE header. This member is used only for image files.</summary>
			public uint size;

			/// <summary>
			/// If the image file is stripped and there is a .dbg file, this member is the path to the .dbg file from the CV record.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 261 /*MAX_PATH + 1*/)]
			public string dbgfile;

			/// <summary>The .pdb file from the CV record. This member is used only for image and .dbg files.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 261 /*MAX_PATH + 1*/)]
			public string pdbfile;

			/// <summary>
			/// The GUID of the .pdb file. If there is no GUID available, the signature of the .pdb file is copied into first <c>DWORD</c>
			/// of the GUID.
			/// </summary>
			public Guid guid;

			/// <summary>
			/// The signature of the .pdb file (for use with old-style .pdb files). This value can be 0 if it is a new-style .pdb file that
			/// uses a GUID-length signature.
			/// </summary>
			public uint sig;

			/// <summary>The age of the .pdb file.</summary>
			public uint age;
		}

		/// <summary>Contains type index information. It is used by the SymGetTypeInfo function.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ns-dbghelp-ti_findchildren_params typedef struct
		// _TI_FINDCHILDREN_PARAMS { ULONG Count; ULONG Start; ULONG ChildId[1]; } TI_FINDCHILDREN_PARAMS;
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._TI_FINDCHILDREN_PARAMS")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<TI_FINDCHILDREN_PARAMS>), nameof(Count))]
		[StructLayout(LayoutKind.Sequential)]
		public struct TI_FINDCHILDREN_PARAMS
		{
			/// <summary>The number of children.</summary>
			public uint Count;

			/// <summary>
			/// The zero-based index of the child from which the child indexes are to be retrieved. For example, in an array with five
			/// elements, if Start is two, this indicates the third array element. In most cases, this member is zero.
			/// </summary>
			public uint Start;

			/// <summary>An array of type indexes. There is one index per child.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public uint[] ChildId;
		}

		/// <summary>Pointer to a LOADED_IMAGE structure.</summary>
		/// <seealso cref="System.Runtime.InteropServices.SafeHandle"/>
		public class SafeLOADED_IMAGE : SafeHandle
		{
			private SafeLOADED_IMAGE() : base(IntPtr.Zero, true)
			{
			}

			/// <summary>When overridden in a derived class, gets a value indicating whether the handle value is invalid.</summary>
			public override bool IsInvalid => handle == IntPtr.Zero;

			/// <summary>Performs an implicit conversion from <see cref="SafeLOADED_IMAGE"/> to <see cref="LOADED_IMAGE"/>.</summary>
			/// <param name="i">The <see cref="SafeLOADED_IMAGE"/> instance.</param>
			/// <returns>The resulting <see cref="LOADED_IMAGE"/> instance from the conversion.</returns>
			public static implicit operator LOADED_IMAGE(SafeLOADED_IMAGE i) => i.handle.ToStructure<LOADED_IMAGE>();

			/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
			/// <returns>
			/// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it
			/// generates a releaseHandleFailed MDA Managed Debugging Assistant.
			/// </returns>
			protected override bool ReleaseHandle() => ImageHlp.ImageUnload(handle);
		}
	}
}