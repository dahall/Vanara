using System;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.IO;

/// <summary>
/// Suspends File System Redirection if found to be in effect. Effectively, this calls <c>IsWow64Process</c> to determine state and then disables
/// redirection using <c>Wow64DisableWow64FsRedirection</c>. It then reverts redirection at disposal using <c>Wow64RevertWow64FsRedirection</c>.
/// </summary>
/// <remarks>
/// This class is best used in a <c>using</c> clause as follows:
/// <code lang="cs">
/// using (new Wow64Redirect())
/// {
///    if (System.IO.File.Exists(@"C:\Windows\System32\qmgr.dll"))
///    {
///       // Do something
///    }
/// }
/// </code>
/// </remarks>
public class Wow64Redirect : IDisposable
{
	private readonly bool isWow64;
	private readonly IntPtr oldVal;

	/// <summary>Initializes a new instance of the <see cref="Wow64Redirect"/> class.</summary>
	public Wow64Redirect()
	{
		if (isWow64 = (IsWow64Process(GetCurrentProcess(), out var wow) && wow))
			Wow64DisableWow64FsRedirection(out oldVal);
	}

	/// <summary>
	/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
	/// </summary>
	void IDisposable.Dispose()
	{
		if (isWow64)
			Wow64RevertWow64FsRedirection(oldVal);
	}
}