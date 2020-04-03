using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using Vanara;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.WlanApi;

namespace WlanApi
{
	public class WFDTests
	{
		[Test]
		public void WFDOpenCloseHandleTest()
		{
			Assert.That(WFDOpenHandle(WFD_API_VERSION, out _, out var hSvc), ResultIs.Successful);
			Assert.That(() => hSvc.Dispose(), Throws.Nothing);
		}
	}
}