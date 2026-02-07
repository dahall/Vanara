namespace Vanara.PInvoke;

/// <summary>Store the correlation vector that is used to reference events and the generated logs for diagnostic purposes.</summary>
// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/ntddk/ns-ntddk-correlation_vector typedef struct CORRELATION_VECTOR {
// CHAR Version; CHAR Vector[RTL_CORRELATION_VECTOR_STRING_LENGTH]; } CORRELATION_VECTOR;
[PInvokeData("ntddk.h", MSDNShortId = "35c1799f-2012-42b0-95e6-6902c818a094")]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CORRELATION_VECTOR
{
	/// <summary/>
	public const byte RTL_CORRELATION_VECTOR_VERSION_1 = 1;

	/// <summary/>
	public const byte RTL_CORRELATION_VECTOR_VERSION_2 = 2;

	/// <summary/>
	public const byte RTL_CORRELATION_VECTOR_VERSION_CURRENT = RTL_CORRELATION_VECTOR_VERSION_2;

	/// <summary>
	/// <para>The version of the correlation vector. Possible values are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>RTL_CORRELATION_VECTOR_VERSION_1</term>
	/// </item>
	/// <item>
	/// <term>RTL_CORRELATION_VECTOR_VERSION_2</term>
	/// </item>
	/// <item>
	/// <term>RTL_CORRELATION_VECTOR_VERSION_CURRENT</term>
	/// </item>
	/// </list>
	/// </summary>
	public byte Version;

	/// <summary>An array CHARs that represents the correlation vector.</summary>
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
	public byte[] Vector;
}