using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Authz
	{
		/// <summary>The <c>AUDIT_PARAM_TYPE</c> enumeration defines the type of audit parameters that are available.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/adtgen/ne-adtgen-_audit_param_type typedef enum _AUDIT_PARAM_TYPE {
		// APT_None, APT_String, APT_Ulong, APT_Pointer, APT_Sid, APT_LogonId, APT_ObjectTypeList, APT_Luid, APT_Guid, APT_Time, APT_Int64,
		// APT_IpAddress, APT_LogonIdWithSid } AUDIT_PARAM_TYPE;
		[PInvokeData("adtgen.h", MSDNShortId = "1ECC866A-2DD3-4EE4-B2CC-7F5ADF7FFC99")]
		public enum AUDIT_PARAM_TYPE
		{
			/// <summary>No audit options.</summary>
			APT_None = 1,

			/// <summary>A string that terminates with NULL.</summary>
			[CorrespondingType(typeof(string), EncodingType = typeof(System.Text.UnicodeEncoding))]
			APT_String,

			/// <summary>An unsigned long.</summary>
			[CorrespondingType(typeof(uint))]
			APT_Ulong,

			/// <summary>
			/// A pointer that is used to specify handles and pointers. These are 32-bit on 32-bit systems and 64-bit on 64-bit systems. Use
			/// this option when you are interested in the absolute value of the pointer. The memory to which the pointer points is not
			/// marshaled when using this type.
			/// </summary>
			[CorrespondingType(typeof(IntPtr))]
			APT_Pointer,

			/// <summary>The security identifier (SID).</summary>
			[CorrespondingType(typeof(PSID))]
			APT_Sid,

			/// <summary>
			/// The logon identifier (LUID) that results in three output parameters:
			/// <para>1. Account Name 2. Authority Name 3. LogonID</para>
			/// </summary>
			[CorrespondingType(typeof(uint))]
			APT_LogonId,

			/// <summary>Object type list.</summary>
			[CorrespondingType(typeof(AUDIT_OBJECT_TYPES))]
			APT_ObjectTypeList,

			/// <summary>LUID that is not translated to LogonId.</summary>
			[CorrespondingType(typeof(uint))]
			APT_Luid,

			/// <summary>GUID.</summary>
			[CorrespondingType(typeof(GuidPtr))]
			APT_Guid,

			/// <summary>Time as FILETIME.</summary>
			[CorrespondingType(typeof(System.Runtime.InteropServices.ComTypes.FILETIME))]
			APT_Time,

			/// <summary>LONGLONG.</summary>
			[CorrespondingType(typeof(long))]
			APT_Int64,

			/// <summary>
			/// IP Address (IPv4 and IPv6). This logs the address as the first parameter and the port as the second parameter. You must
			/// ensure that two entries are added in the event message file. You should ensure that the buffer size is 128 bytes.
			/// </summary>
			[CorrespondingType(typeof(byte[]))]
			APT_IpAddress,

			/// <summary>
			/// Logon ID with SID that results in four output parameters:
			/// <para>1. SID 2. Account Name 3. Authority Name 4. LogonID</para>
			/// </summary>
			APT_LogonIdWithSid,
		}

		/// <summary>
		/// IP Addess (IPv4 and IPv6). This logs the address as the first parameter and the port as the second. So ensure that 2 entries are
		/// added in the event message file, one for the address and the immediate next entry as the port
		/// </summary>
		[PInvokeData("adtgen.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct AUDIT_IP_ADDRESS
		{
			private const int _AUTHZ_SS_MAXSIZE = 128;

			/// <summary>The IP address bytes.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = _AUTHZ_SS_MAXSIZE)]
			public byte[] pIpAddress;
		}

		/// <summary>Element of an object-type-list</summary>
		[PInvokeData("adtgen.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct AUDIT_OBJECT_TYPE
		{
			/// <summary>guid of the (sub)object</summary>
			public Guid ObjectType;

			/// <summary>currently not defined</summary>
			public ushort Flags;

			/// <summary>level within the hierarchy. 0 is the root level</summary>
			public ushort Level;

			/// <summary>access-mask for this (sub)object</summary>
			public ACCESS_MASK AccessMask;
		}

		/// <summary>
		/// The AUDIT_OBJECT_TYPES structure identifies an object type element in a hierarchy of object types. The AccessCheckByType
		/// functions use an array of such structures to define a hierarchy of an object and its subobjects, such as property sets and properties.
		/// </summary>
		[PInvokeData("adtgen.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct AUDIT_OBJECT_TYPES
		{
			/// <summary>number of object-types in pObjectTypes</summary>
			public ushort Count;

			/// <summary>currently not defined</summary>
			public ushort Flags;

			/// <summary>array of object-types (i.e. AUDIT_OBJECT_TYPE[])</summary>
			public IntPtr pObjectTypes;
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
			/// <summary>Type</summary>
			[FieldOffset(0)]
			public AUDIT_PARAM_TYPE Type;

			/// <summary>currently unused</summary>
			[FieldOffset(4)]
			public uint Length;

			/// <summary>currently unused</summary>
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
			public GuidPtr pguid;

			/// <summary/>
			[FieldOffset(16)]
			public uint LogonId_LowPart;

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
			/// <summary>size in bytes</summary>
			public uint Length;

			/// <summary>currently unused</summary>
			public uint Flags;

			/// <summary>number of parameters</summary>
			public ushort Count;

			/// <summary>array of parameters (i.e. AUDIT_PARAM[])</summary>
			public IntPtr Parameters;
		}
	}
}