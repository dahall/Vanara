// ReSharper disable InconsistentNaming
namespace Vanara.PInvoke
{
	/// <summary>Processor architecture</summary>
	public enum ProcessorArchitecture : ushort
	{
		/// <summary>x86</summary>
		PROCESSOR_ARCHITECTURE_INTEL = 0,

		/// <summary>Unspecified</summary>
		PROCESSOR_ARCHITECTURE_MIPS = 1,

		/// <summary>Unspecified</summary>
		PROCESSOR_ARCHITECTURE_ALPHA = 2,

		/// <summary>Unspecified</summary>
		PROCESSOR_ARCHITECTURE_PPC = 3,

		/// <summary>Unspecified</summary>
		PROCESSOR_ARCHITECTURE_SHX = 4,

		/// <summary>ARM</summary>
		PROCESSOR_ARCHITECTURE_ARM = 5,

		/// <summary>Intel Itanium-based</summary>
		PROCESSOR_ARCHITECTURE_IA64 = 6,

		/// <summary>Unspecified</summary>
		PROCESSOR_ARCHITECTURE_ALPHA64 = 7,

		/// <summary>Unspecified</summary>
		PROCESSOR_ARCHITECTURE_MSIL = 8,

		/// <summary>x64 (AMD or Intel)</summary>
		PROCESSOR_ARCHITECTURE_AMD64 = 9,

		/// <summary>Unspecified</summary>
		PROCESSOR_ARCHITECTURE_IA32_ON_WIN64 = 10,

		/// <summary>Unspecified</summary>
		PROCESSOR_ARCHITECTURE_NEUTRAL = 11,

		/// <summary>Unspecified</summary>
		PROCESSOR_ARCHITECTURE_ARM64 = 12,

		/// <summary>Unspecified</summary>
		PROCESSOR_ARCHITECTURE_ARM32_ON_WIN64 = 13,

		/// <summary>Unknown architecture.</summary>
		PROCESSOR_ARCHITECTURE_UNKNOWN = 0xFFFF
	}
}