namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>
	/// <para>Checks whether the user has opted in for SQM data collection as part of the Customer Experience Improvement Program (CEIP).</para>
	/// </summary>
	/// <returns>
	/// <para>True if SQM data collection is opted in and the machine can send data. Otherwise, false.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/windowsceip/nf-windowsceip-ceipisoptedin
	// BOOL CeipIsOptedIn( );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("windowsceip.h", MSDNShortId = "4CDB5B09-B172-4E99-AB46-A08E32346266")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CeipIsOptedIn();
}