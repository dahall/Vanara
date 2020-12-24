using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.ComDlg32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class ComDlg32Tests
	{
		[OneTimeSetUp]
		public void _Setup()
		{
		}

		[OneTimeTearDown]
		public void _TearDown()
		{
		}

		[Test]
		public void GetOpenFileNameTest()
		{
			var fnch = new char[261];
			var fn = new string(fnch);
			var ofn = new OPENFILENAME
			{
				lStructSize = (uint)Marshal.SizeOf(typeof(OPENFILENAME)),
				lpstrFile = fn,
				nMaxFile = (uint)fnch.Length,
				lpstrFilter = "All\0*.*\0Text\0*.txt\0",
				nFilterIndex = 1,
				Flags = OFN.OFN_PATHMUSTEXIST | OFN.OFN_FILEMUSTEXIST
			};
			Assert.That(GetOpenFileName(ref ofn), ResultIs.Successful);
			Assert.That(ofn.lpstrFilter.Length, Is.GreaterThan(0));
		}
	}
}