using NUnit.Framework;
using System.IO;
using static Vanara.PInvoke.OverlappedAsync;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class OverlappedAsyncTests
	{
		[Test()]
		public void SetupOverlappedFunctionTest()
		{
			var fn = Path.GetTempFileName();
			using (var hFile = Kernel32.CreateFile(fn, Kernel32.FileAccess.GENERIC_ALL, FileShare.ReadWrite, null, FileMode.OpenOrCreate, FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL | FileFlagsAndAttributes.FILE_FLAG_OVERLAPPED))
			{
				var oar = SetupOverlappedFunction(hFile, ar => { }, 10);
				Assert.That(oar.AsyncState, Is.EqualTo(10));
				Assert.That(oar.Handle, Is.EqualTo((HFILE)hFile));

				EvaluateOverlappedFunction(oar, true);
				Assert.That(oar.IsCompleted, Is.True);

				EndOverlappedFunction(oar);
			}
		}
	}
}