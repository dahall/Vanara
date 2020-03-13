using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Authz
	{
		/// <summary>The <c>AUDIT_PARAM_TYPE</c> enumeration defines the type of audit parameters that are available.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/adtgen/ne-adtgen-_audit_param_type typedef enum _AUDIT_PARAM_TYPE { APT_None,
		// APT_String, APT_Ulong, APT_Pointer, APT_Sid, APT_LogonId, APT_ObjectTypeList, APT_Luid, APT_Guid, APT_Time, APT_Int64,
		// APT_IpAddress, APT_LogonIdWithSid } AUDIT_PARAM_TYPE;
		[PInvokeData("adtgen.h", MSDNShortId = "1ECC866A-2DD3-4EE4-B2CC-7F5ADF7FFC99")]
		public enum AUDIT_PARAM_TYPE
		{
			/// <summary>No audit options.</summary>
			APT_None = 1,

			/// <summary>A string that terminates with NULL.</summary>
			APT_String,

			/// <summary>An unsigned long.</summary>
			APT_Ulong,

			/// <summary>
			/// A pointer that is used to specify handles and pointers. These are 32-bit on 32-bit systems and 64-bit on 64-bit systems. Use
			/// this option when you are interested in the absolute value of the pointer. The memory to which the pointer points is not
			/// marshaled when using this type.
			/// </summary>
			APT_Pointer,

			/// <summary>The security identifier (SID).</summary>
			APT_Sid,

			/// <summary>The logon identifier (LUID) that results in three output parameters:</summary>
			APT_LogonId,

			/// <summary>Object type list.</summary>
			APT_ObjectTypeList,

			/// <summary>LUID that is not translated to LogonId.</summary>
			APT_Luid,

			/// <summary>GUID.</summary>
			APT_Guid,

			/// <summary>Time as FILETIME.</summary>
			APT_Time,

			/// <summary>ULONGLONG.</summary>
			APT_Int64,

			/// <summary>
			/// IP Address (IPv4 and IPv6). This logs the address as the first parameter and the port as the second parameter. You must
			/// ensure that two entries are added in the event message file. You should ensure that the buffer size is 128 bytes.
			/// </summary>
			APT_IpAddress,

			/// <summary>Logon ID with SID that results in four output parameters:</summary>
			APT_LogonIdWithSid,
		}

		/// <summary>
		/// Structure that defines a single audit parameter. LsaGenAuditEvent accepts an array of such elements to represent the parameters
		/// of the audit to be generated. It is best to initialize this structure using AdtInitParams function. This will ensure
		/// compatibility with any future changes to this structure.
		/// </summary>
		[PInvokeData("adtgen.h")]
		[StructLayout(LayoutKind.Explicit, Size = 32, CharSet = CharSet.Unicode)]
		public struct AUDIT_PARAM
		{
			/// <summary/>
			[FieldOffset(0)]
			public AUDIT_PARAM_TYPE Type;

			/// <summary/>
			[FieldOffset(4)]
			public uint Length;

			/// <summary/>
			[FieldOffset(8)]
			public uint Flags;

			/// <summary/>
			[FieldOffset(16)]
			public IntPtr Data0;

			/// <summary/>
			[FieldOffset(16)]
			public StrPtrUni String;

			/// <summary/>
			[FieldOffset(16)]
			public IntPtr u;

			/// <summary/>
			[FieldOffset(16)]
			public PSID psid;

			/// <summary/>
			[FieldOffset(16)]
			public IntPtr pguid;

			/// <summary/>
			[FieldOffset(16)]
			public int LogonId_LowPart;

			/// <summary/>
			[FieldOffset(16)]
			public IntPtr pObjectTypes;

			/// <summary/>
			[FieldOffset(16)]
			public IntPtr pIpAddress;

			/// <summary/>
			[FieldOffset(24)]
			public IntPtr Data1;

			/// <summary/>
			[FieldOffset(24)]
			public int LogonId_HighPart;
		}

		/// <summary>Audit parameters passed to LsaGenAuditEvent.</summary>
		[PInvokeData("adtgen.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct AUDIT_PARAMS
		{
			/// <summary/>
			public uint Length;

			/// <summary/>
			public uint Flags;

			/// <summary/>
			public ushort Count;

			/// <summary/>
			public IntPtr Parameters;
		}
	}
}
