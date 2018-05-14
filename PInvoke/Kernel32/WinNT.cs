using System;
using System.Runtime.InteropServices;
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>The flags that control the enforcement of the minimum and maximum working set sizes.</summary>
		[PInvokeData("winnt.h")]
		[Flags]
		public enum QUOTA_LIMITS_HARDWS
		{
			/// <summary>The working set will not fall below the minimum working set limit.</summary>
			QUOTA_LIMITS_HARDWS_MIN_ENABLE = 0x00000001,
			/// <summary>The working set may fall below the minimum working set limit if memory demands are high.</summary>
			QUOTA_LIMITS_HARDWS_MIN_DISABLE = 0x00000002,
			/// <summary>The working set will not exceed the maximum working set limit.</summary>
			QUOTA_LIMITS_HARDWS_MAX_ENABLE = 0x00000004,
			/// <summary>The working set may exceed the maximum working set limit if there is abundant memory.</summary>
			QUOTA_LIMITS_HARDWS_MAX_DISABLE = 0x00000008,
			/// <summary>The quota limits use default limits</summary>
			QUOTA_LIMITS_USE_DEFAULT_LIMITS = 0x00000010,
		}

		[PInvokeData("winnt.h")]
		[Flags]
		public enum SECTION_MAP : uint
		{
			SECTION_QUERY                = 0x0001,
			SECTION_MAP_WRITE            = 0x0002,
			SECTION_MAP_READ             = 0x0004,
			SECTION_MAP_EXECUTE          = 0x0008,
			SECTION_EXTEND_SIZE          = 0x0010,
			SECTION_MAP_EXECUTE_EXPLICIT = 0x0020,
			SECTION_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED | SECTION_QUERY | SECTION_MAP_WRITE | SECTION_MAP_READ | SECTION_MAP_EXECUTE | SECTION_EXTEND_SIZE,
		}

		/// <summary>
		/// A mask that indicates the member of the OSVERSIONINFOEX structure whose comparison operator is being set. This value corresponds to one of the bits
		/// specified in the dwTypeMask parameter for the VerifyVersionInfo function.
		/// </summary>
		[Flags]
		public enum VERSION_MASK : uint
		{
			/// <summary>dwMinorVersion</summary>
			VER_MINORVERSION = 0x0000001,
			/// <summary>dwMajorVersion</summary>
			VER_MAJORVERSION = 0x0000002,
			/// <summary>dwBuildNumber</summary>
			VER_BUILDNUMBER = 0x0000004,
			/// <summary>dwPlatformId</summary>
			VER_PLATFORMID = 0x0000008,
			/// <summary>wServicePackMinor</summary>
			VER_SERVICEPACKMINOR = 0x0000010,
			/// <summary>wServicePackMajor</summary>
			VER_SERVICEPACKMAJOR = 0x0000020,
			/// <summary>wSuiteMask</summary>
			VER_SUITENAME = 0x0000040,
			/// <summary>wProductType</summary>
			VER_PRODUCT_TYPE = 0x0000080,
		}

		/// <summary>
		/// The operator to be used for the comparison. The VerifyVersionInfo function uses this operator to compare a specified attribute value to the
		/// corresponding value for the currently running system.
		/// </summary>
		public enum VERSION_CONDITION : byte
		{
			/// <summary>The current value must be equal to the specified value.</summary>
			VER_EQUAL = 1,
			/// <summary>The current value must be greater than the specified value.</summary>
			VER_GREATER,
			/// <summary>The current value must be greater than or equal to the specified value.</summary>
			VER_GREATER_EQUAL,
			/// <summary>The current value must be less than the specified value.</summary>
			VER_LESS,
			/// <summary>The current value must be less than or equal to the specified value.</summary>
			VER_LESS_EQUAL,
			/// <summary>All product suites specified in the wSuiteMask member must be present in the current system.</summary>
			VER_AND,
			/// <summary>At least one of the specified product suites must be present in the current system.</summary>
			VER_OR,
		}
	}
}