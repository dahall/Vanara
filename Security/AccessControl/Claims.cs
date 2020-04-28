using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Vanara.PInvoke;
using static Vanara.PInvoke.Authz;

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
		/// <summary>Initializes a new instance of the <see cref="BadValueException"/> class.</summary>
		public BadValueException()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="BadValueException"/> class.</summary>
		/// <param name="message">The message that describes the error.</param>
		public BadValueException(string message) : base(message)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="BadValueException"/> class.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">
		/// The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.
		/// </param>
		public BadValueException(string message, Exception innerException) : base(message, innerException)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="BadValueException"/> class.</summary>
		/// <param name="info">
		/// The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception
		/// being thrown.
		/// </param>
		/// <param name="context">
		/// The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.
		/// </param>
		protected BadValueException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}

	/// <summary>
	/// Class to represent the type of claims values held, the value(s) and obtain native (unmanaged) pointers to the value as they are
	/// stored in the union members of AUTHZ_SECURITY_ATTRIBUTE_V1 structure's 'Values' field.
	/// </summary>
	public class ClaimValue
	{
		internal AUTHZ_SECURITY_ATTRIBUTE_V1 attr;

		/// <summary>Initializes a new instance of the <see cref="ClaimValue"/> class based on a string.</summary>
		/// <param name="value">The string value.</param>
		public ClaimValue(string value) => attr = new AUTHZ_SECURITY_ATTRIBUTE_V1(null, value);

		/// <summary>Initializes a new instance of the <see cref="ClaimValue"/> class based on a fully qualified binary name and version.</summary>
		/// <param name="version">The version.</param>
		/// <param name="fullyQualifiedBinaryName">Name of the fully qualified binary.</param>
		public ClaimValue(ulong version, string fullyQualifiedBinaryName) => attr = new AUTHZ_SECURITY_ATTRIBUTE_V1(null, new AUTHZ_SECURITY_ATTRIBUTE_FQBN_VALUE { pName = fullyQualifiedBinaryName, Version = version });

		/// <summary>Initializes a new instance of the <see cref="ClaimValue"/> class based on multiple string values.</summary>
		/// <param name="value">The string values.</param>
		public ClaimValue(string[] value) => attr = new AUTHZ_SECURITY_ATTRIBUTE_V1(null, value);

		/// <summary>Initializes a new instance of the <see cref="ClaimValue"/> class based on a binary blob.</summary>
		/// <param name="value">The value.</param>
		public ClaimValue(byte[] value) => attr = new AUTHZ_SECURITY_ATTRIBUTE_V1(null, new AUTHZ_SECURITY_ATTRIBUTE_OCTET_STRING_VALUE { pValue = value, ValueLength = (uint)value.Length });

		/// <summary>Initializes a new instance of the <see cref="ClaimValue"/> class based on an unsigned long value.</summary>
		/// <param name="value">The value.</param>
		public ClaimValue(ulong value) => attr = new AUTHZ_SECURITY_ATTRIBUTE_V1(null, value);

		/// <summary>Initializes a new instance of the <see cref="ClaimValue"/> class based on a long value.</summary>
		/// <param name="value">The value.</param>
		public ClaimValue(long value) => attr = new AUTHZ_SECURITY_ATTRIBUTE_V1(null, value);

		/// <summary>Initializes a new instance of the <see cref="ClaimValue"/> class based on a boolean value.</summary>
		/// <param name="value">if set to <see langword="true"/> [value].</param>
		public ClaimValue(bool value) => attr = new AUTHZ_SECURITY_ATTRIBUTE_V1(null, value);

		/// <summary>Get the number of values contained in the object.</summary>
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
		/// When ClaimDefinitionType.User, AithzModifyClaims in invoked with SidClass AuthzContextInfoUserClaims and when
		/// ClaimDefinitionType.Device with SidClass AuthzContextInfoDeviceClaims.
		/// </remarks>
		public ClaimValueDictionary(ClaimDefinitionType type) => claimDefnType = type;

		/// <summary>Initializes a new instance of the <see cref="ClaimValueDictionary"/> class.</summary>
		/// <param name="info">
		/// A <see cref="T:System.Runtime.Serialization.SerializationInfo"/> object containing the information required to serialize the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </param>
		/// <param name="context">
		/// A <see cref="T:System.Runtime.Serialization.StreamingContext"/> structure containing the source and destination of the
		/// serialized stream associated with the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </param>
		protected ClaimValueDictionary(SerializationInfo info, StreamingContext context)
					: base(info, context)
		{
		}

		/// <summary>Adds or replaces claims in the specified Authz Client Context.</summary>
		/// <remarks>
		/// This method invokes AuthzModifyClaims, modifying the claims using AUTHZ_SECURITY_ATTRIBUTE_OPERATION_REPLACE. This ensures that
		/// the values of a claims that already exists are replaces and the ones not present are added.
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

			return 0;
		}

		/// <summary>
		/// Implements the <see cref="T:System.Runtime.Serialization.ISerializable"/> interface and returns the data needed to serialize the
		/// <see cref="T:System.Collections.Generic.Dictionary`2"/> instance.
		/// </summary>
		/// <param name="info">
		/// A <see cref="T:System.Runtime.Serialization.SerializationInfo"/> object that contains the information required to serialize the
		/// <see cref="T:System.Collections.Generic.Dictionary`2"/> instance.
		/// </param>
		/// <param name="context">
		/// A <see cref="T:System.Runtime.Serialization.StreamingContext"/> structure that contains the source and destination of the
		/// serialized stream associated with the <see cref="T:System.Collections.Generic.Dictionary`2"/> instance.
		/// </param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			if (info != null)
			{
				info.AddValue("claimDefnType", claimDefnType);
			}
		}
	}
}