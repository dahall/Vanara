using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.IO;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.CimFs;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class CimFsTests
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
	public void CreateTest()
	{
		const string tmpfn = "temp.cim";

		var cimpath = Path.Combine(Path.GetTempPath(), tmpfn);
		File.Delete(cimpath);

		Assert.That(CimCreateImage(Path.GetTempPath(), null, tmpfn, out var hImg), ResultIs.Successful);

		try
		{
			var fi = new FileInfo(TestCaseSources.SmallFile);
			using var sd = new SafeCoTaskMemHandle(fi.GetAccessControl().GetSecurityDescriptorBinaryForm());
			CIMFS_FILE_METADATA fmd = new()
			{
				Attributes = (FileFlagsAndAttributes)fi.Attributes,
				ChangeTime = fi.LastWriteTime.ToFileTimeStruct(),
				CreationTime = fi.CreationTime.ToFileTimeStruct(),
				FileSize = fi.Length,
				LastAccessTime = fi.LastAccessTime.ToFileTimeStruct(),
				LastWriteTime = fi.LastWriteTime.ToFileTimeStruct(),
				SecurityDescriptorBuffer = sd,
				SecurityDescriptorSize = sd.Size
			};
			Assert.That(CimCreateFile(hImg, "dir\\file.txt", fmd, out var hStrm), ResultIs.Successful);
			var fbuf = File.ReadAllBytes(TestCaseSources.SmallFile);
			Assert.That(CimWriteStream(hStrm, fbuf, (uint)fbuf.Length), ResultIs.Successful);
			Assert.That(() => hStrm.Dispose(), Throws.Nothing);

			Assert.That(CimCommitImage(hImg), ResultIs.Successful);

			Assert.IsTrue(File.Exists(cimpath));
			Assert.That(new FileInfo(cimpath).Length, Is.GreaterThan(0));

		}
		finally
		{
			Assert.That(() => hImg.Dispose(), Throws.Nothing);
			File.Delete(cimpath);
		}
	}
}