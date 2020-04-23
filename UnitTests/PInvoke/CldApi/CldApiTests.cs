using Microsoft.Win32.SafeHandles;
using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.CldApi;

namespace Vanara.PInvoke.Tests
{
	public class CldApiTests
	{
		[Test]
		public void CfOpenFileWithOplockTest()
		{
			Assert.That(CfOpenFileWithOplock(TestCaseSources.SmallFile, CF_OPEN_FILE_FLAGS.CF_OPEN_FILE_FLAG_EXCLUSIVE, out var handle), ResultIs.Successful);
			Assert.That(handle, ResultIs.ValidHandle);
			Assert.That(() => handle.Dispose(), Throws.Nothing);
		}
	}
}