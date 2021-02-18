using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class IoApiSetTests
	{
		[Test]
		public void DeviceIoControlNoInOutTest()
		{
			using var hFile = CreateFile(@"\\.\C:", FileAccess.GENERIC_READ, System.IO.FileShare.Read,
				default, System.IO.FileMode.Open, 0);
			Assert.That(hFile, ResultIs.ValidHandle);
			Assert.True(DeviceIoControl(hFile, IOControlCode.FSCTL_IS_VOLUME_MOUNTED));
		}

		[Test]
		public void DeviceIoControlOutAndInTest()
		{
			using var hFile = CreateFile(TestCaseSources.WordDoc, FileAccess.GENERIC_READ | FileAccess.GENERIC_WRITE,
				System.IO.FileShare.None, default, System.IO.FileMode.Open, 0);
			Assert.That(hFile, ResultIs.ValidHandle);

			Assert.That(DeviceIoControl(hFile, IOControlCode.FSCTL_GET_COMPRESSION, out COMPRESSION_FORMAT compr), ResultIs.Successful);
			Assert.That(DeviceIoControl(hFile, IOControlCode.FSCTL_SET_COMPRESSION, compr == COMPRESSION_FORMAT.COMPRESSION_FORMAT_NONE ? COMPRESSION_FORMAT.COMPRESSION_FORMAT_DEFAULT : COMPRESSION_FORMAT.COMPRESSION_FORMAT_NONE), ResultIs.Successful);
			Assert.That(DeviceIoControl(hFile, IOControlCode.FSCTL_GET_COMPRESSION, out COMPRESSION_FORMAT newcompr), ResultIs.Successful);
			Assert.That(compr, Is.Not.EqualTo(newcompr));
			Assert.That(DeviceIoControl(hFile, IOControlCode.FSCTL_SET_COMPRESSION, compr), ResultIs.Successful);
		}

		[Test]
		public void StructSizeTest()
		{
			TestHelper.GetNestedStructSizes(typeof(Kernel32)).WriteValues();
		}
	}
}