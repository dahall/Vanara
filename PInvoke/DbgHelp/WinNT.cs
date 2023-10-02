namespace Vanara.PInvoke;

public static partial class DbgHelp
{

	/// <summary>A <c>LIST_ENTRY</c> structure describes an entry in a doubly linked list or serves as the header for such a list.</summary>
	/// <remarks>
	/// <para>A <c>LIST_ENTRY</c> structure that describes the list head must have been initialized by calling InitializeListHead.</para>
	/// <para>
	/// A driver can access the <c>Flink</c> or <c>Blink</c> members of a <c>LIST_ENTRY</c>, but the members must only be updated by the
	/// system routines supplied for this purpose.
	/// </para>
	/// <para>
	/// For more information about how to use <c>LIST_ENTRY</c> structures to implement a doubly linked list, see Singly and Doubly
	/// Linked Lists.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ntdef/ns-ntdef-list_entry typedef struct _LIST_ENTRY { struct _LIST_ENTRY
	// *Flink; struct _LIST_ENTRY *Blink; } LIST_ENTRY, *PLIST_ENTRY, PRLIST_ENTRY;
	[PInvokeData("ntdef.h", MSDNShortId = "NS:ntdef._LIST_ENTRY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LIST_ENTRY
	{
		/// <summary>
		/// <para>
		/// For a <c>LIST_ENTRY</c> structure that serves as a list entry, the <c>Flink</c> member points to the next entry in the list
		/// or to the list header if there is no next entry in the list.
		/// </para>
		/// <para>
		/// For a <c>LIST_ENTRY</c> structure that serves as the list header, the <c>Flink</c> member points to the first entry in the
		/// list or to the LIST_ENTRY structure itself if the list is empty.
		/// </para>
		/// </summary>
		public IntPtr Flink;

		/// <summary>
		/// <para>
		/// For a <c>LIST_ENTRY</c> structure that serves as a list entry, the <c>Blink</c> member points to the previous entry in the
		/// list or to the list header if there is no previous entry in the list.
		/// </para>
		/// <para>
		/// For a <c>LIST_ENTRY</c> structure that serves as the list header, the <c>Blink</c> member points to the last entry in the
		/// list or to the <c>LIST_ENTRY</c> structure itself if the list is empty.
		/// </para>
		/// </summary>
		public IntPtr Blink;
	}

	/// <summary>The format of the debugging information. This member can be one of the following values.</summary>
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_DEBUG_DIRECTORY")]
	public enum IMAGE_DEBUG_TYPE
	{
		/// <summary>Unknown value, ignored by all tools.</summary>
		IMAGE_DEBUG_TYPE_UNKNOWN = 0,

		/// <summary>
		/// COFF debugging information (line numbers, symbol table, and string table). This type of debugging information is also
		/// pointed to by fields in the file headers.
		/// </summary>
		IMAGE_DEBUG_TYPE_COFF = 1,

		/// <summary>CodeView debugging information. The format of the data block is described by the CodeView 4.0 specification.</summary>
		IMAGE_DEBUG_TYPE_CODEVIEW = 2,

		/// <summary>
		/// Frame pointer omission (FPO) information. This information tells the debugger how to interpret nonstandard stack frames,
		/// which use the EBP register for a purpose other than as a frame pointer.
		/// </summary>
		IMAGE_DEBUG_TYPE_FPO = 3,

		/// <summary>Miscellaneous information.</summary>
		IMAGE_DEBUG_TYPE_MISC = 4,

		/// <summary>Exception information.</summary>
		IMAGE_DEBUG_TYPE_EXCEPTION = 5,

		/// <summary>Fixup information.</summary>
		IMAGE_DEBUG_TYPE_FIXUP = 6,

		/// <summary>Borland debugging information.</summary>
		IMAGE_DEBUG_TYPE_BORLAND = 9,

		/// <summary/>
		IMAGE_DEBUG_TYPE_OMAP_TO_SRC = 7,

		/// <summary/>
		IMAGE_DEBUG_TYPE_OMAP_FROM_SRC = 8,

		/// <summary/>
		IMAGE_DEBUG_TYPE_RESERVED10 = 10,

		/// <summary/>
		IMAGE_DEBUG_TYPE_CLSID = 11,

		/// <summary/>
		IMAGE_DEBUG_TYPE_VC_FEATURE = 12,

		/// <summary/>
		IMAGE_DEBUG_TYPE_POGO = 13,

		/// <summary/>
		IMAGE_DEBUG_TYPE_ILTCG = 14,

		/// <summary/>
		IMAGE_DEBUG_TYPE_MPX = 15,

		/// <summary/>
		IMAGE_DEBUG_TYPE_REPRO = 16,

		/// <summary/>
		IMAGE_DEBUG_TYPE_EX_DLLCHARACTERISTICS = 20,
	}

	/// <summary>The index number of the desired directory entry.</summary>
	[PInvokeData("winnt.h")]
	public enum IMAGE_DIRECTORY_ENTRY : ushort
	{
		/// <summary>Architecture-specific data</summary>
		MAGE_DIRECTORY_ENTRY_ARCHITECTURE = 7,

		/// <summary>Base relocation table</summary>
		IMAGE_DIRECTORY_ENTRY_BASERELOC = 5,

		/// <summary>Bound import directory</summary>
		IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT = 11,

		/// <summary>COM descriptor table</summary>
		IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR = 14,

		/// <summary>Debug directory</summary>
		IMAGE_DIRECTORY_ENTRY_DEBUG = 6,

		/// <summary>Delay import table</summary>
		IMAGE_DIRECTORY_ENTRY_DELAY_IMPORT = 13,

		/// <summary>Exception directory</summary>
		IMAGE_DIRECTORY_ENTRY_EXCEPTION = 3,

		/// <summary>Export directory</summary>
		[CorrespondingType(typeof(IMAGE_EXPORT_DIRECTORY), CorrespondingAction.Get)]
		IMAGE_DIRECTORY_ENTRY_EXPORT = 0,

		/// <summary>The relative virtual address of global pointer</summary>
		IMAGE_DIRECTORY_ENTRY_GLOBALPTR = 8,

		/// <summary>Import address table</summary>
		IMAGE_DIRECTORY_ENTRY_IAT = 12,

		/// <summary>Import directory</summary>
		IMAGE_DIRECTORY_ENTRY_IMPORT = 1,

		/// <summary>Load configuration directory</summary>
		IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG = 10,

		/// <summary>Resource directory</summary>
		IMAGE_DIRECTORY_ENTRY_RESOURCE = 2,

		/// <summary>Security directory</summary>
		IMAGE_DIRECTORY_ENTRY_SECURITY = 4,

		/// <summary>Thread local storage directory</summary>
		IMAGE_DIRECTORY_ENTRY_TLS = 9,
	}

	/// <summary>The DLL characteristics of the image.</summary>
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_OPTIONAL_HEADER")]
	public enum IMAGE_DLLCHARACTERISTICS : ushort
	{
		/// <summary>The DLL can be relocated at load time.</summary>
		IMAGE_DLLCHARACTERISTICS_DYNAMIC_BASE = 0x0040,

		/// <summary>
		/// Code integrity checks are forced. If you set this flag and a section contains only uninitialized data, set the
		/// PointerToRawData member of IMAGE_SECTION_HEADER for that section to zero; otherwise, the image will fail to load because the
		/// digital signature cannot be verified.
		/// </summary>
		IMAGE_DLLCHARACTERISTICS_FORCE_INTEGRITY = 0x0080,

		/// <summary>The image is compatible with data execution prevention (DEP).</summary>
		IMAGE_DLLCHARACTERISTICS_NX_COMPAT = 0x0100,

		/// <summary>The image is isolation aware, but should not be isolated.</summary>
		IMAGE_DLLCHARACTERISTICS_NO_ISOLATION = 0x0200,

		/// <summary>The image does not use structured exception handling (SEH). No handlers can be called in this image.</summary>
		IMAGE_DLLCHARACTERISTICS_NO_SEH = 0x0400,

		/// <summary>Do not bind the image.</summary>
		IMAGE_DLLCHARACTERISTICS_NO_BIND = 0x0800,

		/// <summary>A WDM driver.</summary>
		IMAGE_DLLCHARACTERISTICS_WDM_DRIVER = 0x2000,

		/// <summary>The image is terminal server aware.</summary>
		IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE = 0x8000,
	}

	/// <summary>The characteristics of the image.</summary>
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_FILE_HEADER")]
	[Flags]
	public enum IMAGE_FILE : ushort
	{
		/// <summary>
		/// Relocation information was stripped from the file. The file must be loaded at its preferred base address. If the base
		/// address is not available, the loader reports an error.
		/// </summary>
		IMAGE_FILE_RELOCS_STRIPPED = 0x0001,

		/// <summary>The file is executable (there are no unresolved external references).</summary>
		IMAGE_FILE_EXECUTABLE_IMAGE = 0x0002,

		/// <summary>COFF line numbers were stripped from the file.</summary>
		IMAGE_FILE_LINE_NUMS_STRIPPED = 0x0004,

		/// <summary>COFF symbol table entries were stripped from file.</summary>
		IMAGE_FILE_LOCAL_SYMS_STRIPPED = 0x0008,

		/// <summary>Aggressively trim the working set. This value is obsolete.</summary>
		IMAGE_FILE_AGGRESIVE_WS_TRIM = 0x0010,

		/// <summary>The application can handle addresses larger than 2 GB.</summary>
		IMAGE_FILE_LARGE_ADDRESS_AWARE = 0x0020,

		/// <summary>The bytes of the word are reversed. This flag is obsolete.</summary>
		IMAGE_FILE_BYTES_REVERSED_LO = 0x0080,

		/// <summary>The computer supports 32-bit words.</summary>
		IMAGE_FILE_32BIT_MACHINE = 0x0100,

		/// <summary>Debugging information was removed and stored separately in another file.</summary>
		IMAGE_FILE_DEBUG_STRIPPED = 0x0200,

		/// <summary>If the image is on removable media, copy it to and run it from the swap file.</summary>
		IMAGE_FILE_REMOVABLE_RUN_FROM_SWAP = 0x0400,

		/// <summary>If the image is on the network, copy it to and run it from the swap file.</summary>
		IMAGE_FILE_NET_RUN_FROM_SWAP = 0x0800,

		/// <summary>The image is a system file.</summary>
		IMAGE_FILE_SYSTEM = 0x1000,

		/// <summary>The image is a DLL file. While it is an executable file, it cannot be run directly.</summary>
		IMAGE_FILE_DLL = 0x2000,

		/// <summary>The file should be run only on a uniprocessor computer.</summary>
		IMAGE_FILE_UP_SYSTEM_ONLY = 0x4000,

		/// <summary>The bytes of the word are reversed. This flag is obsolete.</summary>
		IMAGE_FILE_BYTES_REVERSED_HI = 0x8000,
	}

	/// <summary>Represents the stack frame layout for a function on an x86 computer when frame pointer omission (FPO) optimization is used. The structure is used to locate the base of the call frame.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-fpo_data
	// typedef struct _FPO_DATA { DWORD ulOffStart; DWORD cbProcSize; DWORD cdwLocals; WORD cdwParams; WORD cbProlog : 8; WORD cbRegs : 3; WORD fHasSEH : 1; WORD fUseBP : 1; WORD reserved : 1; WORD cbFrame : 2; } FPO_DATA, *PFPO_DATA;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._FPO_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct FPO_DATA
	{
		/// <summary>The offset of the first byte of the function code.</summary>
		public uint ulOffStart;
		/// <summary>The number of bytes in the function.</summary>
		public uint cbProcSize;
		/// <summary>The number of local variables.</summary>
		public uint cdwLocals;
		/// <summary>The size of the parameters, in <c>DWORD</c>s.</summary>
		public ushort cdwParams;
		private ushort flags;

#pragma warning disable IDE1006 // Naming Styles
		/// <summary>The number of bytes in the function prolog code.</summary>
		public ushort cbProlog
		{
			get => BitHelper.GetBits(flags, 0, 8);
			set => BitHelper.SetBits(ref flags, 0, 8, value);
		}

		/// <summary>The number of registers saved.</summary>
		public ushort cbRegs
		{
			get => BitHelper.GetBits(flags, 8, 3);
			set => BitHelper.SetBits(ref flags, 8, 3, value);
		}

		/// <summary>A variable that indicates whether the function uses structured exception handling.</summary>
		public bool fHasSEH
		{
			get => BitHelper.GetBit(flags, 11);
			set => BitHelper.SetBit(ref flags, 11, value);
		}
		/// <summary>A variable that indicates whether the EBP register has been allocated.</summary>
		public bool fUseBP
		{
			get => BitHelper.GetBit(flags, 12);
			set => BitHelper.SetBit(ref flags, 12, value);
		}

		/// <summary>Reserved for future use.</summary>
		public bool reserved
		{
			get => BitHelper.GetBit(flags, 13);
			set => BitHelper.SetBit(ref flags, 13, value);
		}

		/// <summary>
		///   <para>A variable that indicates the frame type.</para>
		///   <list type="table">
		///     <listheader>
		///       <term>Type</term>
		///       <term>Meaning</term>
		///     </listheader>
		///     <item>
		///       <term>FRAME_FPO 0</term>
		///       <term>FPO frame</term>
		///     </item>
		///     <item>
		///       <term>FRAME_NONFPO 3</term>
		///       <term>Non-FPO frame</term>
		///     </item>
		///     <item>
		///       <term>FRAME_TRAP 1</term>
		///       <term>Trap frame</term>
		///     </item>
		///     <item>
		///       <term>FRAME_TSS 2</term>
		///       <term>TSS frame</term>
		///     </item>
		///   </list>
		/// </summary>
		public FRAME cbFrame
		{
			get => (FRAME)BitHelper.GetBits(flags, 14, 2);
			set => BitHelper.SetBits(ref flags, 14, 2, (ushort)value);
		}
#pragma warning restore IDE1006 // Naming Styles
	}

	/// <summary>Represents an entry in the function table on 64-bit Windows.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-runtime_function
	// typedef struct _IMAGE_RUNTIME_FUNCTION_ENTRY { DWORD BeginAddress; DWORD EndAddress; union { DWORD UnwindInfoAddress; DWORD UnwindData; } DUMMYUNIONNAME; } RUNTIME_FUNCTION, *PRUNTIME_FUNCTION, _IMAGE_RUNTIME_FUNCTION_ENTRY, *_PIMAGE_RUNTIME_FUNCTION_ENTRY;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_RUNTIME_FUNCTION_ENTRY")]
	[StructLayout(LayoutKind.Explicit)]
	public struct IMAGE_RUNTIME_FUNCTION_ENTRY
	{
		/// <summary>The address of the start of the function.</summary>
		[FieldOffset(0)]
		public uint BeginAddress;
		/// <summary>The address of the end of the function.</summary>
		[FieldOffset(4)]
		public uint EndAddress;
		/// <summary>The address of the unwind information for the function.</summary>
		[FieldOffset(8)]
		public uint UnwindInfoAddress;
		/// <summary />
		[FieldOffset(8)]
		public uint UnwindData;
	}

	/// <summary>
	/// The architecture type of the computer. An image file can only be run on the specified computer or a system that emulates the
	/// specified computer.
	/// </summary>
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_FILE_HEADER")]
	public enum IMAGE_FILE_MACHINE : ushort
	{
		/// <summary/>
		IMAGE_FILE_MACHINE_AXP64 = IMAGE_FILE_MACHINE_ALPHA64,

		/// <summary>Unknown</summary>
		IMAGE_FILE_MACHINE_UNKNOWN = 0,

		/// <summary>Useful for indicating we want to interact with the host and not a WoW guest.</summary>
		IMAGE_FILE_MACHINE_TARGET_HOST = 0x0001,

		/// <summary>Intel 386.</summary>
		IMAGE_FILE_MACHINE_I386 = 0x014c,

		/// <summary>MIPS little-endian, 0x160 big-endian</summary>
		IMAGE_FILE_MACHINE_R3000 = 0x0162,

		/// <summary>MIPS little-endian</summary>
		IMAGE_FILE_MACHINE_R4000 = 0x0166,

		/// <summary>MIPS little-endian</summary>
		IMAGE_FILE_MACHINE_R10000 = 0x0168,

		/// <summary>MIPS little-endian WCE v2</summary>
		IMAGE_FILE_MACHINE_WCEMIPSV2 = 0x0169,

		/// <summary>Alpha_AXP</summary>
		IMAGE_FILE_MACHINE_ALPHA = 0x0184,

		/// <summary>SH3 little-endian</summary>
		IMAGE_FILE_MACHINE_SH3 = 0x01a2,

		/// <summary/>
		IMAGE_FILE_MACHINE_SH3DSP = 0x01a3,

		/// <summary>SH3E little-endian</summary>
		IMAGE_FILE_MACHINE_SH3E = 0x01a4,

		/// <summary>SH4 little-endian</summary>
		IMAGE_FILE_MACHINE_SH4 = 0x01a6,

		/// <summary>SH5</summary>
		IMAGE_FILE_MACHINE_SH5 = 0x01a8,

		/// <summary>ARM Little-Endian</summary>
		IMAGE_FILE_MACHINE_ARM = 0x01c0,

		/// <summary>ARM Thumb/Thumb-2 Little-Endian</summary>
		IMAGE_FILE_MACHINE_THUMB = 0x01c2,

		/// <summary>ARM Thumb-2 Little-Endian</summary>
		IMAGE_FILE_MACHINE_ARMNT = 0x01c4,

		/// <summary/>
		IMAGE_FILE_MACHINE_AM33 = 0x01d3,

		/// <summary>IBM PowerPC Little-Endian</summary>
		IMAGE_FILE_MACHINE_POWERPC = 0x01F0,

		/// <summary/>
		IMAGE_FILE_MACHINE_POWERPCFP = 0x01f1,

		/// <summary>Intel 64</summary>
		IMAGE_FILE_MACHINE_IA64 = 0x0200,

		/// <summary>MIPS</summary>
		IMAGE_FILE_MACHINE_MIPS16 = 0x0266,

		/// <summary>ALPHA64</summary>
		IMAGE_FILE_MACHINE_ALPHA64 = 0x0284,

		/// <summary>MIPS</summary>
		IMAGE_FILE_MACHINE_MIPSFPU = 0x0366,

		/// <summary>MIPS</summary>
		IMAGE_FILE_MACHINE_MIPSFPU16 = 0x0466,

		/// <summary>Infineon</summary>
		IMAGE_FILE_MACHINE_TRICORE = 0x0520,

		/// <summary/>
		IMAGE_FILE_MACHINE_CEF = 0x0CEF,

		/// <summary>EFI Byte Code</summary>
		IMAGE_FILE_MACHINE_EBC = 0x0EBC,

		/// <summary>AMD64 (K8)</summary>
		IMAGE_FILE_MACHINE_AMD64 = 0x8664,

		/// <summary>M32R little-endian</summary>
		IMAGE_FILE_MACHINE_M32R = 0x9041,

		/// <summary>ARM64 Little-Endian</summary>
		IMAGE_FILE_MACHINE_ARM64 = 0xAA64,

		/// <summary/>
		IMAGE_FILE_MACHINE_CEE = 0xC0EE,
	}

	/// <summary>The state of the image file.</summary>
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_OPTIONAL_HEADER")]
	public enum IMAGE_OPTIONAL_MAGIC : ushort
	{
		/// <summary>The file is an executable image.</summary>
		IMAGE_NT_OPTIONAL_HDR32_MAGIC = 0x10b,

		/// <summary>The file is an executable image.</summary>
		IMAGE_NT_OPTIONAL_HDR64_MAGIC = 0x20b,

		/// <summary>The file is a ROM image.</summary>
		IMAGE_ROM_OPTIONAL_HDR_MAGIC = 0x107,
	}

	/// <summary>The characteristics of the image.</summary>
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_SECTION_HEADER")]
	[Flags]
	public enum IMAGE_SCN : uint
	{
		/// <summary>The section should not be padded to the next boundary. This flag is obsolete and is replaced by IMAGE_SCN_ALIGN_1BYTES.</summary>
		IMAGE_SCN_TYPE_NO_PAD = 0x00000008,

		/// <summary>The section contains executable code.</summary>
		IMAGE_SCN_CNT_CODE = 0x00000020,

		/// <summary>The section contains initialized data.</summary>
		IMAGE_SCN_CNT_INITIALIZED_DATA = 0x00000040,

		/// <summary>The section contains uninitialized data.</summary>
		IMAGE_SCN_CNT_UNINITIALIZED_DATA = 0x00000080,

		/// <summary>Reserved.</summary>
		IMAGE_SCN_LNK_OTHER = 0x00000100,

		/// <summary>The section contains comments or other information. This is valid only for object files.</summary>
		IMAGE_SCN_LNK_INFO = 0x00000200,

		/// <summary>The section will not become part of the image. This is valid only for object files.</summary>
		IMAGE_SCN_LNK_REMOVE = 0x00000800,

		/// <summary>The section contains COMDAT data. This is valid only for object files.</summary>
		IMAGE_SCN_LNK_COMDAT = 0x00001000,

		/// <summary>Reset speculative exceptions handling bits in the TLB entries for this section.</summary>
		IMAGE_SCN_NO_DEFER_SPEC_EXC = 0x00004000,

		/// <summary>The section contains data referenced through the global pointer.</summary>
		IMAGE_SCN_GPREL = 0x00008000,

		/// <summary>Reserved.</summary>
		IMAGE_SCN_MEM_PURGEABLE = 0x00020000,

		/// <summary>Reserved.</summary>
		IMAGE_SCN_MEM_LOCKED = 0x00040000,

		/// <summary>Reserved.</summary>
		IMAGE_SCN_MEM_PRELOAD = 0x00080000,

		/// <summary>Align data on a 1-byte boundary. This is valid only for object files.</summary>
		IMAGE_SCN_ALIGN_1BYTES = 0x00100000,

		/// <summary>Align data on a 2-byte boundary. This is valid only for object files.</summary>
		IMAGE_SCN_ALIGN_2BYTES = 0x00200000,

		/// <summary>Align data on a 4-byte boundary. This is valid only for object files.</summary>
		IMAGE_SCN_ALIGN_4BYTES = 0x00300000,

		/// <summary>Align data on a 8-byte boundary. This is valid only for object files.</summary>
		IMAGE_SCN_ALIGN_8BYTES = 0x00400000,

		/// <summary>Align data on a 16-byte boundary. This is valid only for object files.</summary>
		IMAGE_SCN_ALIGN_16BYTES = 0x00500000,

		/// <summary>Align data on a 32-byte boundary. This is valid only for object files.</summary>
		IMAGE_SCN_ALIGN_32BYTES = 0x00600000,

		/// <summary>Align data on a 64-byte boundary. This is valid only for object files.</summary>
		IMAGE_SCN_ALIGN_64BYTES = 0x00700000,

		/// <summary>Align data on a 128-byte boundary. This is valid only for object files.</summary>
		IMAGE_SCN_ALIGN_128BYTES = 0x00800000,

		/// <summary>Align data on a 256-byte boundary. This is valid only for object files.</summary>
		IMAGE_SCN_ALIGN_256BYTES = 0x00900000,

		/// <summary>Align data on a 512-byte boundary. This is valid only for object files.</summary>
		IMAGE_SCN_ALIGN_512BYTES = 0x00A00000,

		/// <summary>Align data on a 1024-byte boundary. This is valid only for object files.</summary>
		IMAGE_SCN_ALIGN_1024BYTES = 0x00B00000,

		/// <summary>Align data on a 2048-byte boundary. This is valid only for object files.</summary>
		IMAGE_SCN_ALIGN_2048BYTES = 0x00C00000,

		/// <summary>Align data on a 4096-byte boundary. This is valid only for object files.</summary>
		IMAGE_SCN_ALIGN_4096BYTES = 0x00D00000,

		/// <summary>Align data on a 8192-byte boundary. This is valid only for object files.</summary>
		IMAGE_SCN_ALIGN_8192BYTES = 0x00E00000,

		/// <summary>
		/// The section contains extended relocations. The count of relocations for the section exceeds the 16 bits that is reserved for
		/// it in the section header. If the NumberOfRelocations field in the section header is 0xffff, the actual relocation count is
		/// stored in the VirtualAddress field of the first relocation. It is an error if IMAGE_SCN_LNK_NRELOC_OVFL is set and there are
		/// fewer than 0xffff relocations in the section.
		/// </summary>
		IMAGE_SCN_LNK_NRELOC_OVFL = 0x01000000,

		/// <summary>The section can be discarded as needed.</summary>
		IMAGE_SCN_MEM_DISCARDABLE = 0x02000000,

		/// <summary>The section cannot be cached.</summary>
		IMAGE_SCN_MEM_NOT_CACHED = 0x04000000,

		/// <summary>The section cannot be paged.</summary>
		IMAGE_SCN_MEM_NOT_PAGED = 0x08000000,

		/// <summary>The section can be shared in memory.</summary>
		IMAGE_SCN_MEM_SHARED = 0x10000000,

		/// <summary>The section can be executed as code.</summary>
		IMAGE_SCN_MEM_EXECUTE = 0x20000000,

		/// <summary>The section can be read.</summary>
		IMAGE_SCN_MEM_READ = 0x40000000,

		/// <summary>The section can be written to.</summary>
		IMAGE_SCN_MEM_WRITE = 0x80000000,
	}

	/// <summary>The subsystem required to run this image.</summary>
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_OPTIONAL_HEADER")]
	public enum IMAGE_SUBSYSTEM : ushort
	{
		/// <summary>Unknown subsystem.</summary>
		IMAGE_SUBSYSTEM_UNKNOWN = 0,

		/// <summary>No subsystem required (device drivers and native system processes).</summary>
		IMAGE_SUBSYSTEM_NATIVE = 1,

		/// <summary>Windows graphical user interface (GUI) subsystem.</summary>
		IMAGE_SUBSYSTEM_WINDOWS_GUI = 2,

		/// <summary>Windows character-mode user interface (CUI) subsystem.</summary>
		IMAGE_SUBSYSTEM_WINDOWS_CUI = 3,

		/// <summary>OS/2 CUI subsystem.</summary>
		IMAGE_SUBSYSTEM_OS2_CUI = 5,

		/// <summary>POSIX CUI subsystem.</summary>
		IMAGE_SUBSYSTEM_POSIX_CUI = 7,

		/// <summary>Windows CE system.</summary>
		IMAGE_SUBSYSTEM_WINDOWS_CE_GUI = 9,

		/// <summary>Extensible Firmware Interface (EFI) application.</summary>
		IMAGE_SUBSYSTEM_EFI_APPLICATION = 10,

		/// <summary>EFI driver with boot services.</summary>
		IMAGE_SUBSYSTEM_EFI_BOOT_SERVICE_DRIVER = 11,

		/// <summary>EFI driver with run-time services.</summary>
		IMAGE_SUBSYSTEM_EFI_RUNTIME_DRIVER = 12,

		/// <summary>EFI ROM image.</summary>
		IMAGE_SUBSYSTEM_EFI_ROM = 13,

		/// <summary>Xbox system.</summary>
		IMAGE_SUBSYSTEM_XBOX = 14,

		/// <summary>Boot application.</summary>
		IMAGE_SUBSYSTEM_WINDOWS_BOOT_APPLICATION = 16,
	}

	/// <summary>Represents the COFF symbols header.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_coff_symbols_header typedef struct
	// _IMAGE_COFF_SYMBOLS_HEADER { DWORD NumberOfSymbols; DWORD LvaToFirstSymbol; DWORD NumberOfLinenumbers; DWORD
	// LvaToFirstLinenumber; DWORD RvaToFirstByteOfCode; DWORD RvaToLastByteOfCode; DWORD RvaToFirstByteOfData; DWORD
	// RvaToLastByteOfData; } IMAGE_COFF_SYMBOLS_HEADER, *PIMAGE_COFF_SYMBOLS_HEADER;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_COFF_SYMBOLS_HEADER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMAGE_COFF_SYMBOLS_HEADER
	{
		/// <summary>The number of symbols.</summary>
		public uint NumberOfSymbols;

		/// <summary>The virtual address of the first symbol.</summary>
		public uint LvaToFirstSymbol;

		/// <summary>The number of line-number entries.</summary>
		public uint NumberOfLinenumbers;

		/// <summary>The virtual address of the first line-number entry.</summary>
		public uint LvaToFirstLinenumber;

		/// <summary>The relative virtual address of the first byte of code.</summary>
		public uint RvaToFirstByteOfCode;

		/// <summary>The relative virtual address of the last byte of code.</summary>
		public uint RvaToLastByteOfCode;

		/// <summary>The relative virtual address of the first byte of data.</summary>
		public uint RvaToFirstByteOfData;

		/// <summary>The relative virtual address of the last byte of data.</summary>
		public uint RvaToLastByteOfData;
	}

	/// <summary>Represents the data directory.</summary>
	/// <remarks>
	/// <para>The following is a list of the data directories. Offsets are relative to the beginning of the optional header.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Offset (PE/PE32+)</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>96/112</term>
	/// <term>Export table address and size</term>
	/// </item>
	/// <item>
	/// <term>104/120</term>
	/// <term>Import table address and size</term>
	/// </item>
	/// <item>
	/// <term>112/128</term>
	/// <term>Resource table address and size</term>
	/// </item>
	/// <item>
	/// <term>120/136</term>
	/// <term>Exception table address and size</term>
	/// </item>
	/// <item>
	/// <term>128/144</term>
	/// <term>Certificate table address and size</term>
	/// </item>
	/// <item>
	/// <term>136/152</term>
	/// <term>Base relocation table address and size</term>
	/// </item>
	/// <item>
	/// <term>144/160</term>
	/// <term>Debugging information starting address and size</term>
	/// </item>
	/// <item>
	/// <term>152/168</term>
	/// <term>Architecture-specific data address and size</term>
	/// </item>
	/// <item>
	/// <term>160/176</term>
	/// <term>Global pointer register relative virtual address</term>
	/// </item>
	/// <item>
	/// <term>168/184</term>
	/// <term>Thread local storage (TLS) table address and size</term>
	/// </item>
	/// <item>
	/// <term>176/192</term>
	/// <term>Load configuration table address and size</term>
	/// </item>
	/// <item>
	/// <term>184/200</term>
	/// <term>Bound import table address and size</term>
	/// </item>
	/// <item>
	/// <term>192/208</term>
	/// <term>Import address table address and size</term>
	/// </item>
	/// <item>
	/// <term>200/216</term>
	/// <term>Delay import descriptor address and size</term>
	/// </item>
	/// <item>
	/// <term>208/224</term>
	/// <term>The CLR header address and size</term>
	/// </item>
	/// <item>
	/// <term>216/232</term>
	/// <term>Reserved</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_data_directory typedef struct _IMAGE_DATA_DIRECTORY {
	// DWORD VirtualAddress; DWORD Size; } IMAGE_DATA_DIRECTORY, *PIMAGE_DATA_DIRECTORY;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_DATA_DIRECTORY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMAGE_DATA_DIRECTORY
	{
		/// <summary>The relative virtual address of the table.</summary>
		public uint VirtualAddress;

		/// <summary>The size of the table, in bytes.</summary>
		public uint Size;
	}

	/// <summary>Represents the debug directory format.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_debug_directory typedef struct _IMAGE_DEBUG_DIRECTORY {
	// DWORD Characteristics; DWORD TimeDateStamp; WORD MajorVersion; WORD MinorVersion; DWORD Type; DWORD SizeOfData; DWORD
	// AddressOfRawData; DWORD PointerToRawData; } IMAGE_DEBUG_DIRECTORY, *PIMAGE_DEBUG_DIRECTORY;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_DEBUG_DIRECTORY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMAGE_DEBUG_DIRECTORY
	{
		/// <summary>Reserved.</summary>
		public uint Characteristics;

		/// <summary>The ime and date the debugging information was created.</summary>
		public uint TimeDateStamp;

		/// <summary>The major version number of the debugging information format.</summary>
		public ushort MajorVersion;

		/// <summary>The minor version number of the debugging information format.</summary>
		public ushort MinorVersion;

		/// <summary>
		/// <para>The format of the debugging information. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Constant</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IMAGE_DEBUG_TYPE_UNKNOWN 0</term>
		/// <term>Unknown value, ignored by all tools.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DEBUG_TYPE_COFF 1</term>
		/// <term>
		/// COFF debugging information (line numbers, symbol table, and string table). This type of debugging information is also
		/// pointed to by fields in the file headers.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DEBUG_TYPE_CODEVIEW 2</term>
		/// <term>CodeView debugging information. The format of the data block is described by the CodeView 4.0 specification.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DEBUG_TYPE_FPO 3</term>
		/// <term>
		/// Frame pointer omission (FPO) information. This information tells the debugger how to interpret nonstandard stack frames,
		/// which use the EBP register for a purpose other than as a frame pointer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DEBUG_TYPE_MISC 4</term>
		/// <term>Miscellaneous information.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DEBUG_TYPE_EXCEPTION 5</term>
		/// <term>Exception information.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DEBUG_TYPE_FIXUP 6</term>
		/// <term>Fixup information.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DEBUG_TYPE_BORLAND 9</term>
		/// <term>Borland debugging information.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IMAGE_DEBUG_TYPE Type;

		/// <summary>The size of the debugging information, in bytes. This value does not include the debug directory itself.</summary>
		public uint SizeOfData;

		/// <summary>The address of the debugging information when the image is loaded, relative to the image base.</summary>
		public uint AddressOfRawData;

		/// <summary>A file pointer to the debugging information.</summary>
		public uint PointerToRawData;
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("winnt.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMAGE_EXPORT_DIRECTORY
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public uint Characteristics;
		public uint TimeDateStamp;
		public ushort MajorVersion;
		public ushort MinorVersion;
		public uint Name;
		public uint Base;
		public uint NumberOfFunctions;
		public uint NumberOfNames;
		public uint AddressOfFunctions; // RVA from base of image
		public uint AddressOfNames; // RVA from base of image
		public uint AddressOfNameOrdinals; // RVA from base of image
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}

	/// <summary>Represents the COFF header format.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_file_header typedef struct _IMAGE_FILE_HEADER { WORD
	// Machine; WORD NumberOfSections; DWORD TimeDateStamp; DWORD PointerToSymbolTable; DWORD NumberOfSymbols; WORD
	// SizeOfOptionalHeader; WORD Characteristics; } IMAGE_FILE_HEADER, *PIMAGE_FILE_HEADER;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_FILE_HEADER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMAGE_FILE_HEADER
	{
		/// <summary>
		/// <para>
		/// The architecture type of the computer. An image file can only be run on the specified computer or a system that emulates the
		/// specified computer. This member can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IMAGE_FILE_MACHINE_I386 0x014c</term>
		/// <term>x86</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_MACHINE_IA64 0x0200</term>
		/// <term>Intel Itanium</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_MACHINE_AMD64 0x8664</term>
		/// <term>x64</term>
		/// </item>
		/// </list>
		/// </summary>
		public IMAGE_FILE_MACHINE Machine;

		/// <summary>
		/// The number of sections. This indicates the size of the section table, which immediately follows the headers. Note that the
		/// Windows loader limits the number of sections to 96.
		/// </summary>
		public ushort NumberOfSections;

		/// <summary>
		/// The low 32 bits of the time stamp of the image. This represents the date and time the image was created by the linker. The
		/// value is represented in the number of seconds elapsed since midnight (00:00:00), January 1, 1970, Universal Coordinated
		/// Time, according to the system clock.
		/// </summary>
		public uint TimeDateStamp;

		/// <summary>The offset of the symbol table, in bytes, or zero if no COFF symbol table exists.</summary>
		public uint PointerToSymbolTable;

		/// <summary>The number of symbols in the symbol table.</summary>
		public uint NumberOfSymbols;

		/// <summary>The size of the optional header, in bytes. This value should be 0 for object files.</summary>
		public ushort SizeOfOptionalHeader;

		/// <summary>
		/// <para>The characteristics of the image. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IMAGE_FILE_RELOCS_STRIPPED 0x0001</term>
		/// <term>
		/// Relocation information was stripped from the file. The file must be loaded at its preferred base address. If the base
		/// address is not available, the loader reports an error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_EXECUTABLE_IMAGE 0x0002</term>
		/// <term>The file is executable (there are no unresolved external references).</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_LINE_NUMS_STRIPPED 0x0004</term>
		/// <term>COFF line numbers were stripped from the file.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_LOCAL_SYMS_STRIPPED 0x0008</term>
		/// <term>COFF symbol table entries were stripped from file.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_AGGRESIVE_WS_TRIM 0x0010</term>
		/// <term>Aggressively trim the working set. This value is obsolete.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_LARGE_ADDRESS_AWARE 0x0020</term>
		/// <term>The application can handle addresses larger than 2 GB.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_BYTES_REVERSED_LO 0x0080</term>
		/// <term>The bytes of the word are reversed. This flag is obsolete.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_32BIT_MACHINE 0x0100</term>
		/// <term>The computer supports 32-bit words.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_DEBUG_STRIPPED 0x0200</term>
		/// <term>Debugging information was removed and stored separately in another file.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_REMOVABLE_RUN_FROM_SWAP 0x0400</term>
		/// <term>If the image is on removable media, copy it to and run it from the swap file.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_NET_RUN_FROM_SWAP 0x0800</term>
		/// <term>If the image is on the network, copy it to and run it from the swap file.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_SYSTEM 0x1000</term>
		/// <term>The image is a system file.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_DLL 0x2000</term>
		/// <term>The image is a DLL file. While it is an executable file, it cannot be run directly.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_UP_SYSTEM_ONLY 0x4000</term>
		/// <term>The file should be run only on a uniprocessor computer.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_BYTES_REVERSED_HI 0x8000</term>
		/// <term>The bytes of the word are reversed. This flag is obsolete.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IMAGE_FILE Characteristics;
	}

	/// <summary>Represents an entry in the function table.</summary>
	/// <remarks>
	/// <para>The following definition exists for 64-bit support.</para>
	/// <para>
	/// <code>typedef struct _IMAGE_FUNCTION_ENTRY64 { ULONGLONG StartingAddress; ULONGLONG EndingAddress; union { ULONGLONG EndOfPrologue; ULONGLONG UnwindInfoAddress; }; } IMAGE_FUNCTION_ENTRY64, *PIMAGE_FUNCTION_ENTRY64;</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_function_entry typedef struct _IMAGE_FUNCTION_ENTRY {
	// DWORD StartingAddress; DWORD EndingAddress; DWORD EndOfPrologue; } IMAGE_FUNCTION_ENTRY, *PIMAGE_FUNCTION_ENTRY;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_FUNCTION_ENTRY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMAGE_FUNCTION_ENTRY
	{
		/// <summary>The image address of the start of the function.</summary>
		public uint StartingAddress;

		/// <summary>The image address of the end of the function.</summary>
		public uint EndingAddress;

		/// <summary>The image address of the end of the prologue code.</summary>
		public uint EndOfPrologue;
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("winnt.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMAGE_LOAD_CONFIG_CODE_INTEGRITY
	{
		/// <summary>Flags to indicate if CI information is available, etc.</summary>
		public ushort Flags;

		/// <summary>0xFFFF means not available</summary>
		public ushort Catalog;

		/// <summary/>
		public uint CatalogOffset;

		/// <summary>Additional bitmask to be defined later</summary>
		public uint Reserved;
	}

	/// <summary>Contains the load configuration data of an image.</summary>
	/// <remarks>
	/// <para>
	/// If <c>_WIN64</c> is defined, then <c>IMAGE_LOAD_CONFIG_DIRECTORY</c> is defined as <c>IMAGE_LOAD_CONFIG_DIRECTORY64</c>.
	/// However, if <c>_WIN64</c> is not defined, then <c>IMAGE_LOAD_CONFIG_DIRECTORY</c> is defined as <c>IMAGE_LOAD_CONFIG_DIRECTORY32</c>.
	/// </para>
	/// <para>
	/// <code>typedef struct { DWORD Size; DWORD TimeDateStamp; WORD MajorVersion; WORD MinorVersion; DWORD GlobalFlagsClear; DWORD GlobalFlagsSet; DWORD CriticalSectionDefaultTimeout; DWORD DeCommitFreeBlockThreshold; DWORD DeCommitTotalFreeThreshold; DWORD LockPrefixTable; // VA DWORD MaximumAllocationSize; DWORD VirtualMemoryThreshold; DWORD ProcessHeapFlags; DWORD ProcessAffinityMask; WORD CSDVersion; WORD Reserved1; DWORD EditList; // VA DWORD SecurityCookie; // VA DWORD SEHandlerTable; // VA DWORD SEHandlerCount; } IMAGE_LOAD_CONFIG_DIRECTORY32, *PIMAGE_LOAD_CONFIG_DIRECTORY32;</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_load_config_directory32 typedef struct
	// _IMAGE_LOAD_CONFIG_DIRECTORY32 { DWORD Size; DWORD TimeDateStamp; WORD MajorVersion; WORD MinorVersion; DWORD GlobalFlagsClear;
	// DWORD GlobalFlagsSet; DWORD CriticalSectionDefaultTimeout; DWORD DeCommitFreeBlockThreshold; DWORD DeCommitTotalFreeThreshold;
	// DWORD LockPrefixTable; DWORD MaximumAllocationSize; DWORD VirtualMemoryThreshold; DWORD ProcessHeapFlags; DWORD
	// ProcessAffinityMask; WORD CSDVersion; WORD DependentLoadFlags; DWORD EditList; DWORD SecurityCookie; DWORD SEHandlerTable; DWORD
	// SEHandlerCount; DWORD GuardCFCheckFunctionPointer; DWORD GuardCFDispatchFunctionPointer; DWORD GuardCFFunctionTable; DWORD
	// GuardCFFunctionCount; DWORD GuardFlags; IMAGE_LOAD_CONFIG_CODE_INTEGRITY CodeIntegrity; DWORD GuardAddressTakenIatEntryTable;
	// DWORD GuardAddressTakenIatEntryCount; DWORD GuardLongJumpTargetTable; DWORD GuardLongJumpTargetCount; DWORD
	// DynamicValueRelocTable; DWORD CHPEMetadataPointer; DWORD GuardRFFailureRoutine; DWORD GuardRFFailureRoutineFunctionPointer; DWORD
	// DynamicValueRelocTableOffset; WORD DynamicValueRelocTableSection; WORD Reserved2; DWORD GuardRFVerifyStackPointerFunctionPointer;
	// DWORD HotPatchTableOffset; DWORD Reserved3; DWORD EnclaveConfigurationPointer; DWORD VolatileMetadataPointer; DWORD
	// GuardEHContinuationTable; DWORD GuardEHContinuationCount; } IMAGE_LOAD_CONFIG_DIRECTORY32, *PIMAGE_LOAD_CONFIG_DIRECTORY32;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_LOAD_CONFIG_DIRECTORY32")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct IMAGE_LOAD_CONFIG_DIRECTORY32
	{
		/// <summary>The size of the structure. For Windows XP, the size must be specified as 64 for x86 images.</summary>
		public uint Size;

		/// <summary>
		/// The date and time stamp value. The value is represented in the number of seconds elapsed since midnight (00:00:00), January
		/// 1, 1970, Universal Coordinated Time, according to the system clock. The time stamp can be printed using the C run-time (CRT)
		/// function <c>ctime</c>.
		/// </summary>
		public uint TimeDateStamp;

		/// <summary>The major version number.</summary>
		public ushort MajorVersion;

		/// <summary>The minor version number.</summary>
		public ushort MinorVersion;

		/// <summary>The global flags that control system behavior. For more information, see Gflags.exe.</summary>
		public uint GlobalFlagsClear;

		/// <summary>The global flags that control system behavior. For more information, see Gflags.exe.</summary>
		public uint GlobalFlagsSet;

		/// <summary>The critical section default time-out value.</summary>
		public uint CriticalSectionDefaultTimeout;

		/// <summary>
		/// The size of the minimum block that must be freed before it is freed (de-committed), in bytes. This value is advisory.
		/// </summary>
		public uint DeCommitFreeBlockThreshold;

		/// <summary>
		/// The size of the minimum total memory that must be freed in the process heap before it is freed (de-committed), in bytes.
		/// This value is advisory.
		/// </summary>
		public uint DeCommitTotalFreeThreshold;

		/// <summary>
		/// The VA of a list of addresses where the LOCK prefix is used. These will be replaced by NOP on single-processor systems. This
		/// member is available only for x86.
		/// </summary>
		public uint LockPrefixTable;

		/// <summary>The maximum allocation size, in bytes. This member is obsolete and is used only for debugging purposes.</summary>
		public uint MaximumAllocationSize;

		/// <summary>The maximum block size that can be allocated from heap segments, in bytes.</summary>
		public uint VirtualMemoryThreshold;

		/// <summary>The process heap flags. For more information, see HeapCreate.</summary>
		public uint ProcessHeapFlags;

		/// <summary>
		/// The process affinity mask. For more information, see GetProcessAffinityMask. This member is available only for .exe files.
		/// </summary>
		public uint ProcessAffinityMask;

		/// <summary>The service pack version.</summary>
		public ushort CSDVersion;

		/// <summary/>
		public ushort DependentLoadFlags;

		/// <summary>Reserved for use by the system.</summary>
		public uint EditList;

		/// <summary>A pointer to a cookie that is used by Visual C++ or GS implementation.</summary>
		public uint SecurityCookie;

		/// <summary>
		/// The VA of the sorted table of RVAs of each valid, unique handler in the image. This member is available only for x86.
		/// </summary>
		public uint SEHandlerTable;

		/// <summary>The count of unique handlers in the table. This member is available only for x86.</summary>
		public uint SEHandlerCount;

		/// <summary/>
		public uint GuardCFCheckFunctionPointer;

		/// <summary/>
		public uint GuardCFDispatchFunctionPointer;

		/// <summary/>
		public uint GuardCFFunctionTable;

		/// <summary/>
		public uint GuardCFFunctionCount;

		/// <summary/>
		public uint GuardFlags;

		/// <summary/>
		public IMAGE_LOAD_CONFIG_CODE_INTEGRITY CodeIntegrity;

		/// <summary/>
		public uint GuardAddressTakenIatEntryTable;

		/// <summary/>
		public uint GuardAddressTakenIatEntryCount;

		/// <summary/>
		public uint GuardLongJumpTargetTable;

		/// <summary/>
		public uint GuardLongJumpTargetCount;

		/// <summary/>
		public uint DynamicValueRelocTable;

		/// <summary/>
		public uint CHPEMetadataPointer;

		/// <summary/>
		public uint GuardRFFailureRoutine;

		/// <summary/>
		public uint GuardRFFailureRoutineFunctionPointer;

		/// <summary/>
		public uint DynamicValueRelocTableOffset;

		/// <summary/>
		public ushort DynamicValueRelocTableSection;

		/// <summary/>
		public ushort Reserved2;

		/// <summary/>
		public uint GuardRFVerifyStackPointerFunctionPointer;

		/// <summary/>
		public uint HotPatchTableOffset;

		/// <summary/>
		public uint Reserved3;

		/// <summary/>
		public uint EnclaveConfigurationPointer;

		/// <summary/>
		public uint VolatileMetadataPointer;

		/// <summary/>
		public uint GuardEHContinuationTable;

		/// <summary/>
		public uint GuardEHContinuationCount;
		
		/// <summary/>
		public uint GuardXFGCheckFunctionPointer;   // VA
		
		/// <summary/>
		public uint GuardXFGDispatchFunctionPointer; // VA
		
		/// <summary/>
		public uint GuardXFGTableDispatchFunctionPointer; // VA
		
		/// <summary/>
		public uint CastGuardOsDeterminedFailureMode; // VA

		/// <summary/>
		public uint GuardMemcpyFunctionPointer;     // VA
	}

	/// <summary>Contains the load configuration data of an image.</summary>
	/// <remarks>
	/// <para>
	/// If <c>_WIN64</c> is defined, then <c>IMAGE_LOAD_CONFIG_DIRECTORY</c> is defined as <c>IMAGE_LOAD_CONFIG_DIRECTORY64</c>.
	/// However, if <c>_WIN64</c> is not defined, then <c>IMAGE_LOAD_CONFIG_DIRECTORY</c> is defined as <c>IMAGE_LOAD_CONFIG_DIRECTORY32</c>.
	/// </para>
	/// <para>
	/// <code>typedef struct { DWORD Size; DWORD TimeDateStamp; WORD MajorVersion; WORD MinorVersion; DWORD GlobalFlagsClear; DWORD GlobalFlagsSet; DWORD CriticalSectionDefaultTimeout; DWORD DeCommitFreeBlockThreshold; DWORD DeCommitTotalFreeThreshold; DWORD LockPrefixTable; // VA DWORD MaximumAllocationSize; DWORD VirtualMemoryThreshold; DWORD ProcessHeapFlags; DWORD ProcessAffinityMask; WORD CSDVersion; WORD Reserved1; DWORD EditList; // VA DWORD SecurityCookie; // VA DWORD SEHandlerTable; // VA DWORD SEHandlerCount; } IMAGE_LOAD_CONFIG_DIRECTORY32, *PIMAGE_LOAD_CONFIG_DIRECTORY32;</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_load_config_directory64 typedef struct
	// _IMAGE_LOAD_CONFIG_DIRECTORY64 { DWORD Size; DWORD TimeDateStamp; WORD MajorVersion; WORD MinorVersion; DWORD GlobalFlagsClear;
	// DWORD GlobalFlagsSet; DWORD CriticalSectionDefaultTimeout; ULONGLONG DeCommitFreeBlockThreshold; ULONGLONG
	// DeCommitTotalFreeThreshold; ULONGLONG LockPrefixTable; ULONGLONG MaximumAllocationSize; ULONGLONG VirtualMemoryThreshold;
	// ULONGLONG ProcessAffinityMask; DWORD ProcessHeapFlags; WORD CSDVersion; WORD DependentLoadFlags; ULONGLONG EditList; ULONGLONG
	// SecurityCookie; ULONGLONG SEHandlerTable; ULONGLONG SEHandlerCount; ULONGLONG GuardCFCheckFunctionPointer; ULONGLONG
	// GuardCFDispatchFunctionPointer; ULONGLONG GuardCFFunctionTable; ULONGLONG GuardCFFunctionCount; DWORD GuardFlags;
	// IMAGE_LOAD_CONFIG_CODE_INTEGRITY CodeIntegrity; ULONGLONG GuardAddressTakenIatEntryTable; ULONGLONG
	// GuardAddressTakenIatEntryCount; ULONGLONG GuardLongJumpTargetTable; ULONGLONG GuardLongJumpTargetCount; ULONGLONG
	// DynamicValueRelocTable; ULONGLONG CHPEMetadataPointer; ULONGLONG GuardRFFailureRoutine; ULONGLONG
	// GuardRFFailureRoutineFunctionPointer; DWORD DynamicValueRelocTableOffset; WORD DynamicValueRelocTableSection; WORD Reserved2;
	// ULONGLONG GuardRFVerifyStackPointerFunctionPointer; DWORD HotPatchTableOffset; DWORD Reserved3; ULONGLONG
	// EnclaveConfigurationPointer; ULONGLONG VolatileMetadataPointer; ULONGLONG GuardEHContinuationTable; ULONGLONG
	// GuardEHContinuationCount; } IMAGE_LOAD_CONFIG_DIRECTORY64, *PIMAGE_LOAD_CONFIG_DIRECTORY64;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_LOAD_CONFIG_DIRECTORY64")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct IMAGE_LOAD_CONFIG_DIRECTORY64
	{
		/// <summary>The size of the structure. For Windows XP, the size must be specified as 64 for x86 images.</summary>
		public uint Size;

		/// <summary>
		/// The date and time stamp value. The value is represented in the number of seconds elapsed since midnight (00:00:00), January
		/// 1, 1970, Universal Coordinated Time, according to the system clock. The time stamp can be printed using the C run-time (CRT)
		/// function <c>ctime</c>.
		/// </summary>
		public uint TimeDateStamp;

		/// <summary>The major version number.</summary>
		public ushort MajorVersion;

		/// <summary>The minor version number.</summary>
		public ushort MinorVersion;

		/// <summary>The global flags that control system behavior. For more information, see Gflags.exe.</summary>
		public uint GlobalFlagsClear;

		/// <summary>The global flags that control system behavior. For more information, see Gflags.exe.</summary>
		public uint GlobalFlagsSet;

		/// <summary>The critical section default time-out value.</summary>
		public uint CriticalSectionDefaultTimeout;

		/// <summary>
		/// The size of the minimum block that must be freed before it is freed (de-committed), in bytes. This value is advisory.
		/// </summary>
		public ulong DeCommitFreeBlockThreshold;

		/// <summary>
		/// The size of the minimum total memory that must be freed in the process heap before it is freed (de-committed), in bytes.
		/// This value is advisory.
		/// </summary>
		public ulong DeCommitTotalFreeThreshold;

		/// <summary>
		/// The VA of a list of addresses where the LOCK prefix is used. These will be replaced by NOP on single-processor systems. This
		/// member is available only for x86.
		/// </summary>
		public ulong LockPrefixTable;

		/// <summary>The maximum allocation size, in bytes. This member is obsolete and is used only for debugging purposes.</summary>
		public ulong MaximumAllocationSize;

		/// <summary>The maximum block size that can be allocated from heap segments, in bytes.</summary>
		public ulong VirtualMemoryThreshold;

		/// <summary>
		/// The process affinity mask. For more information, see GetProcessAffinityMask. This member is available only for .exe files.
		/// </summary>
		public ulong ProcessAffinityMask;

		/// <summary>The process heap flags. For more information, see HeapCreate.</summary>
		public uint ProcessHeapFlags;

		/// <summary>The service pack version.</summary>
		public ushort CSDVersion;

		/// <summary/>
		public ushort DependentLoadFlags;

		/// <summary>Reserved for use by the system.</summary>
		public ulong EditList;

		/// <summary>A pointer to a cookie that is used by Visual C++ or GS implementation.</summary>
		public ulong SecurityCookie;

		/// <summary>
		/// The VA of the sorted table of RVAs of each valid, unique handler in the image. This member is available only for x86.
		/// </summary>
		public ulong SEHandlerTable;

		/// <summary>The count of unique handlers in the table. This member is available only for x86.</summary>
		public ulong SEHandlerCount;

		/// <summary/>
		public ulong GuardCFCheckFunctionPointer;

		/// <summary/>
		public ulong GuardCFDispatchFunctionPointer;

		/// <summary/>
		public ulong GuardCFFunctionTable;

		/// <summary/>
		public ulong GuardCFFunctionCount;

		/// <summary/>
		public uint GuardFlags;

		/// <summary/>
		public IMAGE_LOAD_CONFIG_CODE_INTEGRITY CodeIntegrity;

		/// <summary/>
		public ulong GuardAddressTakenIatEntryTable;

		/// <summary/>
		public ulong GuardAddressTakenIatEntryCount;

		/// <summary/>
		public ulong GuardLongJumpTargetTable;

		/// <summary/>
		public ulong GuardLongJumpTargetCount;

		/// <summary/>
		public ulong DynamicValueRelocTable;

		/// <summary/>
		public ulong CHPEMetadataPointer;

		/// <summary/>
		public ulong GuardRFFailureRoutine;

		/// <summary/>
		public ulong GuardRFFailureRoutineFunctionPointer;

		/// <summary/>
		public uint DynamicValueRelocTableOffset;

		/// <summary/>
		public ushort DynamicValueRelocTableSection;

		/// <summary/>
		public ushort Reserved2;

		/// <summary/>
		public ulong GuardRFVerifyStackPointerFunctionPointer;

		/// <summary/>
		public uint HotPatchTableOffset;

		/// <summary/>
		public uint Reserved3;

		/// <summary/>
		public ulong EnclaveConfigurationPointer;

		/// <summary/>
		public ulong VolatileMetadataPointer;

		/// <summary/>
		public ulong GuardEHContinuationTable;

		/// <summary/>
		public ulong GuardEHContinuationCount;

		/// <summary/>
		public ulong GuardXFGCheckFunctionPointer;   //VA

		/// <summary/>
		public ulong GuardXFGDispatchFunctionPointer; //VA

		/// <summary/>
		public ulong GuardXFGTableDispatchFunctionPointer; //VA

		/// <summary/>
		public ulong CastGuardOsDeterminedFailureMode; //VA

		/// <summary/>
		public ulong GuardMemcpyFunctionPointer;     //VA
	}

	/// <summary>Represents the PE header format.</summary>
	/// <remarks>
	/// <para>
	/// The actual structure in WinNT.h is named <c>IMAGE_NT_HEADERS32</c> and <c>IMAGE_NT_HEADERS</c> is defined as
	/// <c>IMAGE_NT_HEADERS32</c>. However, if _WIN64 is defined, then <c>IMAGE_NT_HEADERS</c> is defined as <c>IMAGE_NT_HEADERS64</c>.
	/// </para>
	/// <para>
	/// <code>typedef struct _IMAGE_NT_HEADERS64 { DWORD Signature; IMAGE_FILE_HEADER FileHeader; IMAGE_OPTIONAL_HEADER64 OptionalHeader; } IMAGE_NT_HEADERS64, *PIMAGE_NT_HEADERS64;</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_nt_headers32 typedef struct _IMAGE_NT_HEADERS { DWORD
	// Signature; IMAGE_FILE_HEADER FileHeader; IMAGE_OPTIONAL_HEADER32 OptionalHeader; } IMAGE_NT_HEADERS32, *PIMAGE_NT_HEADERS32;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_NT_HEADERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMAGE_NT_HEADERS
	{
		/// <summary>A 4-byte signature identifying the file as a PE image. The bytes are "PE\0\0".</summary>
		public uint Signature;

		/// <summary>An IMAGE_FILE_HEADER structure that specifies the file header.</summary>
		public IMAGE_FILE_HEADER FileHeader;

		/// <summary>An IMAGE_OPTIONAL_HEADER structure that specifies the optional file header.</summary>
		public IMAGE_OPTIONAL_HEADER OptionalHeader;
	}

	/// <summary>Represents the optional header format.</summary>
	/// <remarks>
	/// <para>The number of directories is not fixed. Check the <c>NumberOfRvaAndSizes</c> member before looking for a specific directory.</para>
	/// <para>
	/// The actual structure in WinNT.h is named <c>IMAGE_OPTIONAL_HEADER32</c> and <c>IMAGE_OPTIONAL_HEADER</c> is defined as
	/// <c>IMAGE_OPTIONAL_HEADER32</c>. However, if <c>_WIN64</c> is defined, then <c>IMAGE_OPTIONAL_HEADER</c> is defined as <c>IMAGE_OPTIONAL_HEADER64</c>.
	/// </para>
	/// <para>
	/// <code>typedef struct _IMAGE_OPTIONAL_HEADER64 { WORD Magic; BYTE MajorLinkerVersion; BYTE MinorLinkerVersion; DWORD SizeOfCode; DWORD SizeOfInitializedData; DWORD SizeOfUninitializedData; DWORD AddressOfEntryPoint; DWORD BaseOfCode; ULONGLONG ImageBase; DWORD SectionAlignment; DWORD FileAlignment; WORD MajorOperatingSystemVersion; WORD MinorOperatingSystemVersion; WORD MajorImageVersion; WORD MinorImageVersion; WORD MajorSubsystemVersion; WORD MinorSubsystemVersion; DWORD Win32VersionValue; DWORD SizeOfImage; DWORD SizeOfHeaders; DWORD CheckSum; WORD Subsystem; WORD DllCharacteristics; ULONGLONG SizeOfStackReserve; ULONGLONG SizeOfStackCommit; ULONGLONG SizeOfHeapReserve; ULONGLONG SizeOfHeapCommit; DWORD LoaderFlags; DWORD NumberOfRvaAndSizes; IMAGE_DATA_DIRECTORY DataDirectory[IMAGE_NUMBEROF_DIRECTORY_ENTRIES]; } IMAGE_OPTIONAL_HEADER64, *PIMAGE_OPTIONAL_HEADER64;</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_optional_header32 typedef struct _IMAGE_OPTIONAL_HEADER {
	// WORD Magic; BYTE MajorLinkerVersion; BYTE MinorLinkerVersion; DWORD SizeOfCode; DWORD SizeOfInitializedData; DWORD
	// SizeOfUninitializedData; DWORD AddressOfEntryPoint; DWORD BaseOfCode; DWORD BaseOfData; DWORD ImageBase; DWORD SectionAlignment;
	// DWORD FileAlignment; WORD MajorOperatingSystemVersion; WORD MinorOperatingSystemVersion; WORD MajorImageVersion; WORD
	// MinorImageVersion; WORD MajorSubsystemVersion; WORD MinorSubsystemVersion; DWORD Win32VersionValue; DWORD SizeOfImage; DWORD
	// SizeOfHeaders; DWORD CheckSum; WORD Subsystem; WORD DllCharacteristics; DWORD SizeOfStackReserve; DWORD SizeOfStackCommit; DWORD
	// SizeOfHeapReserve; DWORD SizeOfHeapCommit; DWORD LoaderFlags; DWORD NumberOfRvaAndSizes; IMAGE_DATA_DIRECTORY
	// DataDirectory[IMAGE_NUMBEROF_DIRECTORY_ENTRIES]; } IMAGE_OPTIONAL_HEADER32, *PIMAGE_OPTIONAL_HEADER32;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_OPTIONAL_HEADER")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public unsafe struct IMAGE_OPTIONAL_HEADER
	{
		/// <summary>
		/// <para>The state of the image file. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IMAGE_NT_OPTIONAL_HDR_MAGIC</term>
		/// <term>
		/// The file is an executable image. This value is defined as IMAGE_NT_OPTIONAL_HDR32_MAGIC in a 32-bit application and as
		/// IMAGE_NT_OPTIONAL_HDR64_MAGIC in a 64-bit application.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IMAGE_NT_OPTIONAL_HDR32_MAGIC 0x10b</term>
		/// <term>The file is an executable image.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_NT_OPTIONAL_HDR64_MAGIC 0x20b</term>
		/// <term>The file is an executable image.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_ROM_OPTIONAL_HDR_MAGIC 0x107</term>
		/// <term>The file is a ROM image.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IMAGE_OPTIONAL_MAGIC Magic;

		/// <summary>The major version number of the linker.</summary>
		public byte MajorLinkerVersion;

		/// <summary>The minor version number of the linker.</summary>
		public byte MinorLinkerVersion;

		/// <summary>The size of the code section, in bytes, or the sum of all such sections if there are multiple code sections.</summary>
		public uint SizeOfCode;

		/// <summary>
		/// The size of the initialized data section, in bytes, or the sum of all such sections if there are multiple initialized data sections.
		/// </summary>
		public uint SizeOfInitializedData;

		/// <summary>
		/// The size of the uninitialized data section, in bytes, or the sum of all such sections if there are multiple uninitialized
		/// data sections.
		/// </summary>
		public uint SizeOfUninitializedData;

		/// <summary>
		/// A pointer to the entry point function, relative to the image base address. For executable files, this is the starting
		/// address. For device drivers, this is the address of the initialization function. The entry point function is optional for
		/// DLLs. When no entry point is present, this member is zero.
		/// </summary>
		public uint AddressOfEntryPoint;

		/// <summary>A pointer to the beginning of the code section, relative to the image base.</summary>
		public uint BaseOfCode;

		/// <summary>A pointer to the beginning of the data section, relative to the image base.</summary>
		public uint BaseOfData;

		/// <summary>
		/// The preferred address of the first byte of the image when it is loaded in memory. This value is a multiple of 64K bytes. The
		/// default value for DLLs is 0x10000000. The default value for applications is 0x00400000, except on Windows CE where it is 0x00010000.
		/// </summary>
		public uint ImageBase;

		/// <summary>
		/// The alignment of sections loaded in memory, in bytes. This value must be greater than or equal to the <c>FileAlignment</c>
		/// member. The default value is the page size for the system.
		/// </summary>
		public uint SectionAlignment;

		/// <summary>
		/// The alignment of the raw data of sections in the image file, in bytes. The value should be a power of 2 between 512 and 64K
		/// (inclusive). The default is 512. If the <c>SectionAlignment</c> member is less than the system page size, this member must
		/// be the same as <c>SectionAlignment</c>.
		/// </summary>
		public uint FileAlignment;

		/// <summary>The major version number of the required operating system.</summary>
		public ushort MajorOperatingSystemVersion;

		/// <summary>The minor version number of the required operating system.</summary>
		public ushort MinorOperatingSystemVersion;

		/// <summary>The major version number of the image.</summary>
		public ushort MajorImageVersion;

		/// <summary>The minor version number of the image.</summary>
		public ushort MinorImageVersion;

		/// <summary>The major version number of the subsystem.</summary>
		public ushort MajorSubsystemVersion;

		/// <summary>The minor version number of the subsystem.</summary>
		public ushort MinorSubsystemVersion;

		/// <summary>This member is reserved and must be 0.</summary>
		public uint Win32VersionValue;

		/// <summary>The size of the image, in bytes, including all headers. Must be a multiple of <c>SectionAlignment</c>.</summary>
		public uint SizeOfImage;

		/// <summary>
		/// <para>
		/// The combined size of the following items, rounded to a multiple of the value specified in the <c>FileAlignment</c> member.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>e_lfanew</c> member of <c>IMAGE_DOS_HEADER</c></term>
		/// </item>
		/// <item>
		/// <term>4 byte signature</term>
		/// </item>
		/// <item>
		/// <term>size of IMAGE_FILE_HEADER</term>
		/// </item>
		/// <item>
		/// <term>size of optional header</term>
		/// </item>
		/// <item>
		/// <term>size of all section headers</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint SizeOfHeaders;

		/// <summary>
		/// The image file checksum. The following files are validated at load time: all drivers, any DLL loaded at boot time, and any
		/// DLL loaded into a critical system process.
		/// </summary>
		public uint CheckSum;

		/// <summary>
		/// <para>The subsystem required to run this image. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IMAGE_SUBSYSTEM_UNKNOWN 0</term>
		/// <term>Unknown subsystem.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SUBSYSTEM_NATIVE 1</term>
		/// <term>No subsystem required (device drivers and native system processes).</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SUBSYSTEM_WINDOWS_GUI 2</term>
		/// <term>Windows graphical user interface (GUI) subsystem.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SUBSYSTEM_WINDOWS_CUI 3</term>
		/// <term>Windows character-mode user interface (CUI) subsystem.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SUBSYSTEM_OS2_CUI 5</term>
		/// <term>OS/2 CUI subsystem.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SUBSYSTEM_POSIX_CUI 7</term>
		/// <term>POSIX CUI subsystem.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SUBSYSTEM_WINDOWS_CE_GUI 9</term>
		/// <term>Windows CE system.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SUBSYSTEM_EFI_APPLICATION 10</term>
		/// <term>Extensible Firmware Interface (EFI) application.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SUBSYSTEM_EFI_BOOT_SERVICE_DRIVER 11</term>
		/// <term>EFI driver with boot services.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SUBSYSTEM_EFI_RUNTIME_DRIVER 12</term>
		/// <term>EFI driver with run-time services.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SUBSYSTEM_EFI_ROM 13</term>
		/// <term>EFI ROM image.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SUBSYSTEM_XBOX 14</term>
		/// <term>Xbox system.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SUBSYSTEM_WINDOWS_BOOT_APPLICATION 16</term>
		/// <term>Boot application.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IMAGE_SUBSYSTEM Subsystem;

		/// <summary>
		/// <para>The DLL characteristics of the image. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0x0001</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>0x0002</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>0x0004</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>0x0008</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DLLCHARACTERISTICS_DYNAMIC_BASE 0x0040</term>
		/// <term>The DLL can be relocated at load time.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DLLCHARACTERISTICS_FORCE_INTEGRITY 0x0080</term>
		/// <term>
		/// Code integrity checks are forced. If you set this flag and a section contains only uninitialized data, set the
		/// PointerToRawData member of IMAGE_SECTION_HEADER for that section to zero; otherwise, the image will fail to load because the
		/// digital signature cannot be verified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DLLCHARACTERISTICS_NX_COMPAT 0x0100</term>
		/// <term>The image is compatible with data execution prevention (DEP).</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DLLCHARACTERISTICS_NO_ISOLATION 0x0200</term>
		/// <term>The image is isolation aware, but should not be isolated.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DLLCHARACTERISTICS_NO_SEH 0x0400</term>
		/// <term>The image does not use structured exception handling (SEH). No handlers can be called in this image.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DLLCHARACTERISTICS_NO_BIND 0x0800</term>
		/// <term>Do not bind the image.</term>
		/// </item>
		/// <item>
		/// <term>0x1000</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DLLCHARACTERISTICS_WDM_DRIVER 0x2000</term>
		/// <term>A WDM driver.</term>
		/// </item>
		/// <item>
		/// <term>0x4000</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE 0x8000</term>
		/// <term>The image is terminal server aware.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IMAGE_DLLCHARACTERISTICS DllCharacteristics;

		/// <summary>
		/// The number of bytes to reserve for the stack. Only the memory specified by the <c>SizeOfStackCommit</c> member is committed
		/// at load time; the rest is made available one page at a time until this reserve size is reached.
		/// </summary>
		public uint SizeOfStackReserve;

		/// <summary>The number of bytes to commit for the stack.</summary>
		public uint SizeOfStackCommit;

		/// <summary>
		/// The number of bytes to reserve for the local heap. Only the memory specified by the <c>SizeOfHeapCommit</c> member is
		/// committed at load time; the rest is made available one page at a time until this reserve size is reached.
		/// </summary>
		public uint SizeOfHeapReserve;

		/// <summary>The number of bytes to commit for the local heap.</summary>
		public uint SizeOfHeapCommit;

		/// <summary>This member is obsolete.</summary>
		public uint LoaderFlags;

		/// <summary>
		/// The number of directory entries in the remainder of the optional header. Each entry describes a location and size.
		/// </summary>
		public uint NumberOfRvaAndSizes;

		//[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 /*IMAGE_NUMBEROF_DIRECTORY_ENTRIES*/)]
		private fixed ulong _DataDirectory[16];

		/// <summary>
		/// <para>A pointer to the first IMAGE_DATA_DIRECTORY structure in the data directory.</para>
		/// <para>The index number of the desired directory entry. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_ARCHITECTURE 7</term>
		/// <term>Architecture-specific data</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_BASERELOC 5</term>
		/// <term>Base relocation table</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT 11</term>
		/// <term>Bound import directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR 14</term>
		/// <term>COM descriptor table</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_DEBUG 6</term>
		/// <term>Debug directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_DELAY_IMPORT 13</term>
		/// <term>Delay import table</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_EXCEPTION 3</term>
		/// <term>Exception directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_EXPORT 0</term>
		/// <term>Export directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_GLOBALPTR 8</term>
		/// <term>The relative virtual address of global pointer</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_IAT 12</term>
		/// <term>Import address table</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_IMPORT 1</term>
		/// <term>Import directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG 10</term>
		/// <term>Load configuration directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_RESOURCE 2</term>
		/// <term>Resource directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_SECURITY 4</term>
		/// <term>Security directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_TLS 9</term>
		/// <term>Thread local storage directory</term>
		/// </item>
		/// </list>
		/// </summary>
		public IMAGE_DATA_DIRECTORY[] DataDirectory
		{
			get
			{
				unsafe
				{
					fixed (void* dd = _DataDirectory)
					{
						return ((IntPtr)dd).ToArray<IMAGE_DATA_DIRECTORY>(16)!;
					}
				}
			}
			set
			{
				if (value is null || value.Length != 16)
					throw new ArgumentOutOfRangeException(nameof(DataDirectory), "Must be an array with 16 elements.");
				unsafe
				{
					fixed (IMAGE_DATA_DIRECTORY* v = value)
					fixed (void* dd = _DataDirectory)
					{
						((IntPtr)v).CopyTo((IntPtr)dd, sizeof(ulong) * 16);
					}
				}
			}
		}
	}

	/// <summary>Represents the image section header format.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_section_header typedef struct _IMAGE_SECTION_HEADER {
	// BYTE Name[IMAGE_SIZEOF_SHORT_NAME]; union { DWORD PhysicalAddress; DWORD VirtualSize; } Misc; DWORD VirtualAddress; DWORD
	// SizeOfRawData; DWORD PointerToRawData; DWORD PointerToRelocations; DWORD PointerToLinenumbers; WORD NumberOfRelocations; WORD
	// NumberOfLinenumbers; DWORD Characteristics; } IMAGE_SECTION_HEADER, *PIMAGE_SECTION_HEADER;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._IMAGE_SECTION_HEADER")]
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct IMAGE_SECTION_HEADER
	{
		/// <summary>
		/// An 8-byte, null-padded UTF-8 string. There is no terminating null character if the string is exactly eight characters long.
		/// For longer names, this member contains a forward slash (/) followed by an ASCII representation of a decimal number that is
		/// an offset into the string table. Executable images do not use a string table and do not support section names longer than
		/// eight characters.
		/// </summary>
		public fixed byte Name[8];

		/// <summary/>
		public MISC Misc;

		/// <summary>
		/// The address of the first byte of the section when loaded into memory, relative to the image base. For object files, this is
		/// the address of the first byte before relocation is applied.
		/// </summary>
		public uint VirtualAddress;

		/// <summary>
		/// The size of the initialized data on disk, in bytes. This value must be a multiple of the <c>FileAlignment</c> member of the
		/// IMAGE_OPTIONAL_HEADER structure. If this value is less than the <c>VirtualSize</c> member, the remainder of the section is
		/// filled with zeroes. If the section contains only uninitialized data, the member is zero.
		/// </summary>
		public uint SizeOfRawData;

		/// <summary>
		/// A file pointer to the first page within the COFF file. This value must be a multiple of the <c>FileAlignment</c> member of
		/// the IMAGE_OPTIONAL_HEADER structure. If a section contains only uninitialized data, set this member is zero.
		/// </summary>
		public uint PointerToRawData;

		/// <summary>
		/// A file pointer to the beginning of the relocation entries for the section. If there are no relocations, this value is zero.
		/// </summary>
		public uint PointerToRelocations;

		/// <summary>
		/// A file pointer to the beginning of the line-number entries for the section. If there are no COFF line numbers, this value is zero.
		/// </summary>
		public uint PointerToLinenumbers;

		/// <summary>The number of relocation entries for the section. This value is zero for executable images.</summary>
		public ushort NumberOfRelocations;

		/// <summary>The number of line-number entries for the section.</summary>
		public ushort NumberOfLinenumbers;

		/// <summary>
		/// <para>The characteristics of the image. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0x00000000</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>0x00000001</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>0x00000002</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>0x00000004</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_TYPE_NO_PAD 0x00000008</term>
		/// <term>The section should not be padded to the next boundary. This flag is obsolete and is replaced by IMAGE_SCN_ALIGN_1BYTES.</term>
		/// </item>
		/// <item>
		/// <term>0x00000010</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_CNT_CODE 0x00000020</term>
		/// <term>The section contains executable code.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_CNT_INITIALIZED_DATA 0x00000040</term>
		/// <term>The section contains initialized data.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_CNT_UNINITIALIZED_DATA 0x00000080</term>
		/// <term>The section contains uninitialized data.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_LNK_OTHER 0x00000100</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_LNK_INFO 0x00000200</term>
		/// <term>The section contains comments or other information. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>0x00000400</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_LNK_REMOVE 0x00000800</term>
		/// <term>The section will not become part of the image. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_LNK_COMDAT 0x00001000</term>
		/// <term>The section contains COMDAT data. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>0x00002000</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_NO_DEFER_SPEC_EXC 0x00004000</term>
		/// <term>Reset speculative exceptions handling bits in the TLB entries for this section.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_GPREL 0x00008000</term>
		/// <term>The section contains data referenced through the global pointer.</term>
		/// </item>
		/// <item>
		/// <term>0x00010000</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_MEM_PURGEABLE 0x00020000</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_MEM_LOCKED 0x00040000</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_MEM_PRELOAD 0x00080000</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_ALIGN_1BYTES 0x00100000</term>
		/// <term>Align data on a 1-byte boundary. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_ALIGN_2BYTES 0x00200000</term>
		/// <term>Align data on a 2-byte boundary. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_ALIGN_4BYTES 0x00300000</term>
		/// <term>Align data on a 4-byte boundary. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_ALIGN_8BYTES 0x00400000</term>
		/// <term>Align data on a 8-byte boundary. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_ALIGN_16BYTES 0x00500000</term>
		/// <term>Align data on a 16-byte boundary. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_ALIGN_32BYTES 0x00600000</term>
		/// <term>Align data on a 32-byte boundary. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_ALIGN_64BYTES 0x00700000</term>
		/// <term>Align data on a 64-byte boundary. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_ALIGN_128BYTES 0x00800000</term>
		/// <term>Align data on a 128-byte boundary. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_ALIGN_256BYTES 0x00900000</term>
		/// <term>Align data on a 256-byte boundary. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_ALIGN_512BYTES 0x00A00000</term>
		/// <term>Align data on a 512-byte boundary. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_ALIGN_1024BYTES 0x00B00000</term>
		/// <term>Align data on a 1024-byte boundary. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_ALIGN_2048BYTES 0x00C00000</term>
		/// <term>Align data on a 2048-byte boundary. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_ALIGN_4096BYTES 0x00D00000</term>
		/// <term>Align data on a 4096-byte boundary. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_ALIGN_8192BYTES 0x00E00000</term>
		/// <term>Align data on a 8192-byte boundary. This is valid only for object files.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_LNK_NRELOC_OVFL 0x01000000</term>
		/// <term>
		/// The section contains extended relocations. The count of relocations for the section exceeds the 16 bits that is reserved for
		/// it in the section header. If the NumberOfRelocations field in the section header is 0xffff, the actual relocation count is
		/// stored in the VirtualAddress field of the first relocation. It is an error if IMAGE_SCN_LNK_NRELOC_OVFL is set and there are
		/// fewer than 0xffff relocations in the section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_MEM_DISCARDABLE 0x02000000</term>
		/// <term>The section can be discarded as needed.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_MEM_NOT_CACHED 0x04000000</term>
		/// <term>The section cannot be cached.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_MEM_NOT_PAGED 0x08000000</term>
		/// <term>The section cannot be paged.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_MEM_SHARED 0x10000000</term>
		/// <term>The section can be shared in memory.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_MEM_EXECUTE 0x20000000</term>
		/// <term>The section can be executed as code.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_MEM_READ 0x40000000</term>
		/// <term>The section can be read.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_SCN_MEM_WRITE 0x80000000</term>
		/// <term>The section can be written to.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IMAGE_SCN Characteristics;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct MISC
		{
			/// <summary>The file address.</summary>
			[FieldOffset(0)]
			public uint PhysicalAddress;

			/// <summary>
			/// The total size of the section when loaded into memory, in bytes. If this value is greater than the <c>SizeOfRawData</c>
			/// member, the section is filled with zeroes. This field is valid only for executable images and should be set to 0 for
			/// object files.
			/// </summary>
			[FieldOffset(0)]
			public uint VirtualSize;
		}
	}
}