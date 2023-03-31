using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public partial class WinBaseTests_Resource
{
	private static readonly string ResExe = TestCaseSources.ResourceFile;
	private const int ResId1 = 103;
	private const int ResId2 = 129;
	private const int ResType = (int)ResourceType.RT_DIALOG;

	[Test]
	public void UpdateResourceTest()
	{
		using TempFile tmp = new();
		Assert.That(CopyFile(ResExe, tmp.FullName, false), ResultIs.Successful);

		// Load the .EXE file that contains the dialog box you want to copy.
		using SafeHINSTANCE hExe = LoadLibraryEx(ResExe, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE | LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE);
		Assert.That(hExe, ResultIs.ValidHandle);

		// Locate the resource in the .EXE file.
		HRSRC hRes = FindResource(hExe, ResId1, ResType);
		Assert.That(hRes, ResultIs.ValidHandle);

		// Load the resource into global memory.
		HRSRCDATA hResLoad = LoadResource(hExe, hRes);
		Assert.That(hResLoad, ResultIs.ValidHandle);

		// Lock the resource into global memory.
		System.IntPtr lpResLock = LockResource(hResLoad);
		Assert.That(lpResLock, ResultIs.ValidHandle);

		// Open the file to which you want to add the resource resource.
		using SafeHUPDRES hUpdateRes = BeginUpdateResource(tmp.FullName, false);
		Assert.That(hUpdateRes, ResultIs.ValidHandle);

		// Add the resource resource to the update list.
		Assert.That(UpdateResource(hUpdateRes, ResType, ResId2, MAKELANGID(LANG_NEUTRAL, SUBLANG_NEUTRAL),
			lpResLock, SizeofResource(hExe, hRes)), ResultIs.Successful);
	}
}