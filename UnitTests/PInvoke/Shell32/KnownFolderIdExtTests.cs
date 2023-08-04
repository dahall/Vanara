using NUnit.Framework;
using static Vanara.PInvoke.Shell32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class KnownFolderIdExtTests
{
	[Test()]
	public void FullPathTest()
	{
		Assert.That(KNOWNFOLDERID.FOLDERID_Documents.FullPath(), Is.EqualTo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)));
	}

	[Test()]
	public void GetRegistryPropertyTest()
	{
		Assert.That(KNOWNFOLDERID.FOLDERID_Documents.GetRegistryProperty<string>("RelativePath"), Is.EqualTo("Documents"));
	}

	[Test()]
	public void GuidTest()
	{
		Assert.That(KNOWNFOLDERID.FOLDERID_Documents.Guid(), Is.EqualTo(new Guid("{FDD39AD0-238F-46AF-ADB4-6C85480369C7}")));
	}

	[Test()]
	public void NameTest()
	{
		Assert.That(KNOWNFOLDERID.FOLDERID_Documents.Name(), Is.EqualTo("Personal"));
	}

	[Test()]
	public void PIDLTest()
	{
		Assert.That((IntPtr)KNOWNFOLDERID.FOLDERID_Documents.PIDL(), Is.Not.EqualTo(IntPtr.Zero));
	}

	[Test()]
	public void SpecialFolderTest()
	{
		Assert.That(KNOWNFOLDERID.FOLDERID_Documents.SpecialFolder(), Is.EqualTo(Environment.SpecialFolder.MyDocuments));
	}
}