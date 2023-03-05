namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>The maximum character length for a path.</summary>
	[PInvokeData("minwindef.h")]
	public const int MAX_PATH = 260;
}