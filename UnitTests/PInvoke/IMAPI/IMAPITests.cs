using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Linq;
using static Vanara.PInvoke.IMAPI;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class IMAPITests
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
	public void RecorderTest()
	{
		IDiscMaster2 discMaster = new();
		Assert.That(discMaster.IsSupportedEnvironment, "There are no media sources on which to test.");

		IDiscRecorder2 discRecorder = new();
		discRecorder.InitializeDiscRecorder(discMaster[0]);
		discRecorder.SupportedProfiles.WriteValues();

		// Get the media type in the recorder
		IDiscFormat2Data iDiscFormat2Data = new();
		Assert.That(iDiscFormat2Data.IsCurrentMediaSupported(discRecorder));
		iDiscFormat2Data.Recorder = discRecorder;
		IMAPI_MEDIA_PHYSICAL_TYPE mediaType = iDiscFormat2Data.CurrentPhysicalMediaType;
		TestContext.WriteLine($"Media Type : {mediaType.GetDescription()}");
		iDiscFormat2Data.SupportedWriteSpeedDescriptors.WriteValues();

		// Create a file system and select media type
		IFileSystemImage iFileSystemImage = new();
		iFileSystemImage.ChooseImageDefaultsForMediaType(mediaType);

		// If there are other recored sessions on the disc, import them into the file system image
		if (!iDiscFormat2Data.MediaHeuristicallyBlank)
		{
			iFileSystemImage.MultisessionInterfaces = iDiscFormat2Data.MultisessionInterfaces;
			iFileSystemImage.ImportFileSystem();
		}

		// Get the total size of the file system image
		int fileMediaBlocks = iFileSystemImage.FreeMediaBlocks;
		int totalDiskSize = 2048 * fileMediaBlocks;
		TestContext.WriteLine($"Total Disk Size: {totalDiskSize}");
	}
}