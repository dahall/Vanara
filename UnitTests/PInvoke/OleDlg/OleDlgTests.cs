using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.InteropServices;
using static Vanara.PInvoke.OleDlg;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class OleDlgTests
	{
		[Test]
		public void OleUIBusyTest()
		{
			var bz = new OLEUIBUSY
			{
				cbStruct = (uint)Marshal.SizeOf(typeof(OLEUIBUSY)),
				hWndOwner = HWND.HWND_TOP,
				lpfnHook = hookfn,
			};
			Assert.That(OleUIBusy(ref bz), Is.EqualTo(1).Or.EqualTo(118));
		}

		static uint hookfn(HWND arg1, uint arg2, IntPtr arg3, IntPtr arg4) => 0;

		[Test]
		public void OleUIChangeIconTest()
		{
			const string iconExe = @"C:\Temp\dllexp.exe";
			var chi = new OLEUICHANGEICON
			{
				cbStruct = (uint)Marshal.SizeOf(typeof(OLEUICHANGEICON)),
				dwFlags = CIF.CIF_USEICONEXE,
				hWndOwner = HWND.HWND_TOP,
				lpfnHook = hookfn,
				szIconExe = iconExe,
				cchIconExe = iconExe.Length,
			};
			Assert.That(OleUIChangeIcon(ref chi), Is.EqualTo(1));
		}
	}
}