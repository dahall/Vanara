using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public partial class WinBaseTests_Resource
	{
		private const string ResExe = @"C:\Temp\DummyResourceExe.exe";
		private const int ResId1 = 103;
		private const int ResId2 = 129;
		private const int ResType = (int)ResourceType.RT_DIALOG;

		[Test]
		public void UpdateResourceTest()
		{
			using (var tmp = new TempFile())
			{
				Assert.That(CopyFile(ResExe, tmp.FullName, false), ResultIs.Successful);

				// Load the .EXE file that contains the dialog box you want to copy.
				using (var hExe = LoadLibraryEx(ResExe, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE | LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE))
				{
					Assert.That(hExe, ResultIs.ValidHandle);

					// Locate the resource in the .EXE file.
					var hRes = FindResource(hExe, ResId1, ResType);
					Assert.That(hRes, ResultIs.ValidHandle);

					// Load the resource into global memory.
					var hResLoad = LoadResource(hExe, hRes);
					Assert.That(hResLoad, ResultIs.ValidHandle);

					// Lock the resource into global memory.
					var lpResLock = LockResource(hResLoad);
					Assert.That(lpResLock, ResultIs.ValidHandle);

					// Open the file to which you want to add the resource resource.
					using (var hUpdateRes = BeginUpdateResource(tmp.FullName, false))
					{
						Assert.That(hUpdateRes, ResultIs.ValidHandle);

						// Add the resource resource to the update list.
						Assert.That(UpdateResource(hUpdateRes, ResType, ResId2, MAKELANGID(LANG_NEUTRAL, SUBLANG_NEUTRAL),
							lpResLock, SizeofResource(hExe, hRes)), ResultIs.Successful);
					}
				}
			}
		}
	}
}