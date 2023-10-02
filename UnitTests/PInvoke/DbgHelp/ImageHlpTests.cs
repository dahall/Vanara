using NUnit.Framework;
using NUnit.Framework.Internal;
using System.IO;
using static Vanara.PInvoke.DbgHelp;
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
	public unsafe void GetImageConfigInformationTest()
	{
		Kernel32.SetThreadAffinityMask(Kernel32.GetCurrentThread(), 1);

		using SafeLOADED_IMAGE pImg = ImageLoad(imgName, null);
		Assert.That(pImg, ResultIs.ValidHandle);
		Assert.That(GetImageConfigInformation(pImg, out IMAGE_LOAD_CONFIG_DIRECTORY64 cfg), ResultIs.Failure); // This shouldn't fail!!!
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
		using SafeCoTaskMemStruct<LOADED_IMAGE> mem = new();
		Assert.That(MapAndLoad(imgName, default, mem, true, true), ResultIs.Successful);
		mem.Value.WriteValues();
		Assert.That(UnMapAndLoad(mem), ResultIs.Successful);

		unsafe
		{
			LOADED_IMAGE_UNSAFE img = default;
			Assert.That(MapAndLoad(imgName, default, &img, true, true), ResultIs.Successful);
			Assert.That(UnMapAndLoad(&img), ResultIs.Successful);
		}
	}
}