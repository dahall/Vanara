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
			
			using (var hFile = System.IO.File.Create(fn, 128, FileOptions.DeleteOnClose | FileOptions.Asynchronous))
			{
				var oar = SetupOverlappedFunction(hFile.Handle, ar => { }, 10);
				Assert.That(oar.AsyncState, Is.EqualTo(10));
				Assert.That(oar.Handle, Is.EqualTo((HFILE)hFile.Handle));

				EvaluateOverlappedFunction(oar, true);
				Assert.That(oar.IsCompleted, Is.True);

				EndOverlappedFunction(oar);
			}
		}
	}
}