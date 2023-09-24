using System.Security.AccessControl;
using Vanara.PInvoke;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Extensions;

/// <summary>Extension methods for native and .NET access control objects.</summary>
public static class AccessExtension
{
	/// <summary>Converts a PSECURITY_DESCRIPTOR to a byte array.</summary>
	/// <param name="securityDescriptor">The security descriptor.</param>
	/// <returns>The byte array of the PSECURITY_DESCRIPTOR.</returns>
	public static byte[] ToByteArray(this PSECURITY_DESCRIPTOR securityDescriptor)
	{
		var sdLength = GetSecurityDescriptorLength(securityDescriptor);
		var buffer = new byte[sdLength];
		Marshal.Copy((IntPtr)securityDescriptor, buffer, 0, (int)sdLength);
		return buffer;
	}

	/// <summary>Converts a PSECURITY_DESCRIPTOR to a managed RawSecurityDescriptor.</summary>
	/// <param name="securityDescriptor">The security descriptor.</param>
	/// <returns>The RawSecurityDescriptor.</returns>
	public static RawSecurityDescriptor ToManaged(this PSECURITY_DESCRIPTOR securityDescriptor) => new(securityDescriptor.ToByteArray(), 0);

	/// <summary>Converts a RawSecurityDescriptor to a native safe handle.</summary>
	/// <param name="rawSD">The RawSecurityDescriptor.</param>
	/// <returns>A native safe handle for PSECURITY_DESCRIPTOR.</returns>
	public static SafePSECURITY_DESCRIPTOR ToNative(this RawSecurityDescriptor rawSD) => new(rawSD.ToByteArray());

	/// <summary>Converts a RawSecurityDescriptor to a byte array.</summary>
	/// <param name="rawSD">The RawSecurityDescriptor.</param>
	/// <returns>A byte array.</returns>
	public static byte[] ToByteArray(this RawSecurityDescriptor rawSD)
	{
		var buffer = new byte[rawSD.BinaryLength];
		rawSD.GetBinaryForm(buffer, 0);
		return buffer;
	}
}