using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Vanara.PInvoke;
using static Vanara.PInvoke.Authz;

// ReSharper disable InconsistentNaming

namespace Microsoft.Samples.DynamicAccessControl
{
	/// <summary>Enumeration used to identify if a ClaimValueDictionary comprised of user or device claims.</summary>
	internal enum ClaimDefinitionType
	{
		User,
		Device
	}

	/// <summary>Exception raised when value(s) of a claim value type is invalid.</summary>
	[Serializable]
	public class BadValueException : Exception
	{
		public BadValueException() { }

		public BadValueException(string message) : base(message) { }

		public BadValueException(string message, Exception innerException) : base(message, innerException) { }

		protected BadValueException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}

	/// <summary>
	/// Class to represent the type of claims values held, the value(s) and obtain native (unmanaged) pointers to the value as they are stored in the union
	/// members of AUTHZ_SECURITY_ATTRIBUTE_V1 structure's 'Values' field.
	/// </summary>
	public class ClaimValue
	{
		internal AUTHZ_SECURITY_ATTRIBUTE_V1 attr;

		public ClaimValue(string value)
		{
			attr = new AUTHZ_SECURITY_ATTRIBUTE_V1(null, value);
		}

		public ClaimValue(ulong version, string fullyQualifiedBinaryName)
		{
			attr = new AUTHZ_SECURITY_ATTRIBUTE_V1(null, new AUTHZ_SECURITY_ATTRIBUTE_FQBN_VALUE { pName = fullyQualifiedBinaryName, Version = version });
		}

		public ClaimValue(string[] value)
		{
			attr = new AUTHZ_SECURITY_ATTRIBUTE_V1(null, value);
		}

		public ClaimValue(byte[] value)
		{
			attr = new AUTHZ_SECURITY_ATTRIBUTE_V1(null, new AUTHZ_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE { pValue = value, ValueLength = (uint)value.Length });
		}

		public ClaimValue(ulong value)
		{
			attr = new AUTHZ_SECURITY_ATTRIBUTE_V1(null, value);
		}

		public ClaimValue(long value)
		{
			attr = new AUTHZ_SECURITY_ATTRIBUTE_V1(null, value);
		}

		public ClaimValue(bool value)
		{
			attr = new AUTHZ_SECURITY_ATTRIBUTE_V1(null, value);
		}

		/// <summary>Get the number of values contained in the Microsoft.Samples.Cbac.ClaimValue</summary>
		public uint ValueCount => attr.ValueCount;
	}

	/// <summary>Class to represent a set of claim values(s) and to facilitate applying these to an Authz client context</summary>
	[Serializable]
	internal class ClaimValueDictionary : Dictionary<string, ClaimValue>
	{
		private readonly ClaimDefinitionType claimDefnType;

		/// <summary>Identifies if this instance represents user's claims or device's claims</summary>
		/// <param name="type">ClaimDefinitionType.User to indicate user's claims and ClaimDefinitionType.Device to indicate device's claims.</param>
		/// <remarks>
		/// When ClaimDefinitionType.User, AithzModifyClaims in invoked with SidClass AuthzContextInfoUserClaims and when ClaimDefinitionType.Device with
		/// SidClass AuthzContextInfoDeviceClaims.
		/// </remarks>
		public ClaimValueDictionary(ClaimDefinitionType type)
		{
			claimDefnType = type;
		}

		protected ClaimValueDictionary(SerializationInfo info, StreamingContext context)
					: base(info, context)
		{
		}

		/// <summary>Adds or replaces claims in the specified Authz Client Context.</summary>
		/// <remarks>
		/// This method invokes AuthzModifyClaims, modifying the claims using AUTHZ_SECURITY_ATTRIBUTE_OPERATION_REPLACE. This ensures that the values of a
		/// claims that already exists are replaces and the ones not present are added.
		/// </remarks>
		/// <param name="handleClientContext">Handle to the Authz Client Context to be modified</param>
		/// <returns>Win32Error.ERROR_SUCCESS on success and Win32 error code otherwise.</returns>
		public int ApplyClaims(SafeAUTHZ_CLIENT_CONTEXT_HANDLE handleClientContext)
		{
			var claimInfo = new AUTHZ_SECURITY_ATTRIBUTES_INFORMATION(new AUTHZ_SECURITY_ATTRIBUTE_V1[Count]);
			var i = 0;
			foreach (var claim in this)
			{
				claimInfo.pAttributeV1[i] = claim.Value.attr;
				claimInfo.pAttributeV1[i].pName = claim.Key;
				i++;
			}

			AUTHZ_SECURITY_ATTRIBUTE_OPERATION[] claimOps = null;
			if (claimInfo.AttributeCount != 0)
			{
				claimOps = new AUTHZ_SECURITY_ATTRIBUTE_OPERATION[claimInfo.AttributeCount];
				for (var Idx = 0; Idx < claimInfo.AttributeCount; ++Idx)
					claimOps[Idx] = AUTHZ_SECURITY_ATTRIBUTE_OPERATION.AUTHZ_SECURITY_ATTRIBUTE_OPERATION_REPLACE;
			}

			if (!AuthzModifyClaims(handleClientContext,
				claimDefnType == ClaimDefinitionType.User ? AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoUserClaims : AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoDeviceClaims,
				claimOps, claimInfo))
			{
				return Marshal.GetLastWin32Error();
			}

			return Win32Error.ERROR_SUCCESS;
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			if (info != null)
			{
				info.AddValue("claimDefnType", claimDefnType);
			}
		}

		/*static class 
		{
			[StructLayout(LayoutKind.Sequential)]
			public struct AUTHZ_SECURITY_ATTRIBUTES_INFORMATION
			{
				public USHORT Version;
				public USHORT Reserved;
				public uint AttributeCount;
				public PAUTHZ_SECURITY_ATTRIBUTE_V1 pAttributeV1;
			}

			public enum AuthzSecurityAttributeValueType : ushort
			{
				Invalid = 0x0,
				Int = 0x1,
				String = 0x3,
				Boolean = 0x6,
			}

			[Flags]
			public enum AuthzSecurityAttributeFlags : uint // uint
			{
				None = 0x0,
				NonInheritable = 0x1,
				ValueCaseSensitive = 0x2,
			}

			[StructLayout(LayoutKind.Sequential)]
			public struct AUTHZ_SECURITY_ATTRIBUTE_V1
			{
				[MarshalAs(UnmanagedType.LPWStr)] public string Name;
				public AuthzSecurityAttributeValueType Type;
				public USHORT Reserved;
				public AuthzSecurityAttributeFlags Flags;
				public uint ValueCount;
				public IntPtr Values;
			}

			public enum AuthzContextInformationClass : uint
			{
				AuthzContextInfoUserClaims = 13,
				AuthzContextInfoDeviceClaims,
			};

			public enum AuthzSecurityAttributeOperation : uint
			{
				None = 0,
				ReplaceAll,
				Add,
				Delete,
				Replace
			}

			[DllImport(Win32.AUTHZ_DLL, CharSet = CharSet.Unicode, SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool AuthzModifyClaims(
				AUTHZ_CLIENT_CONTEXT_HANDLE handleClientContext,
				AuthzContextInformationClass infoClass,
				AuthzSecurityAttributeOperation[] claimOperation,
				ref AUTHZ_SECURITY_ATTRIBUTES_INFORMATION claims);
		}*/
	}
}