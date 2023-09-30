using NUnit.Framework;
using NUnit.Framework.Internal;
using System.IO;
using static Vanara.PInvoke.ImageHlp;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class ImageHlpTests
{
	const string imgName = "imagehlp.dll";
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	string imgPath;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	[OneTimeSetUp]
	public void _Setup()
	{
		imgPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void GetImageConfigInformationTest()
	{
		using var pImg = ImageLoad(imgName, imgPath);
		Assert.That(pImg, ResultIs.ValidHandle);
		Assert.That(GetImageConfigInformation(pImg, out var cfg), ResultIs.Successful);
		cfg.WriteValues();
	}

	[Test]
	public void GetImageUnusedHeaderBytesTest()
	{
		using var pImg = ImageLoad(imgName, imgPath);
		Assert.That(pImg, ResultIs.ValidHandle);
		Assert.That(GetImageUnusedHeaderBytes(pImg, out var b), ResultIs.Not.Value(0U));
		TestContext.WriteLine(b);
	}

	[Test]
	public void MapFileAndCheckSumTest()
	{
		Assert.That(MapFileAndCheckSum(Path.Combine(imgPath, imgName), out var hSum, out var chkSum), Is.EqualTo(CHECKSUM.CHECKSUM_SUCCESS));
		TestContext.WriteLine($"HeaderSum={hSum}, CheckSum={chkSum}");
	}

	[Test]
	public void MapAndLoadTest()
	{
		Assert.That(MapAndLoad(imgName, default, out var li, true, true), ResultIs.Successful);
		li.WriteValues();
		Assert.That(UnMapAndLoad(ref li), ResultIs.Successful);
	}
}