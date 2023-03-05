using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>
	/// Retrieves the session identifier of the console session. The console session is the session that is currently attached to the
	/// physical console. Note that it is not necessary that Remote Desktop Services be running for this function to succeed.
	/// </summary>
	/// <returns>
	/// The session identifier of the session that is attached to the physical console. If there is no session attached to the physical
	/// console, (for example, if the physical console session is in the process of being attached or detached), this function returns 0xFFFFFFFF.
	/// </returns>
	// DWORD WTSGetActiveConsoleSessionId(void); https://msdn.microsoft.com/en-us/library/aa383835(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa383835")]
	public static extern uint WTSGetActiveConsoleSessionId();
}