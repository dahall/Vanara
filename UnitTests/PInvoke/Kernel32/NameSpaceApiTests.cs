using NUnit.Framework;
using System.IO;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class NameSpaceApiTests
{
	private const string bndName = "BND1";
	private const string nsName = "NS1";

	[Test]
	public void CreatePrivateNamespaceTest()
	{
		BoundaryDescriptorHandle bdh = CreateBoundaryDescriptor(bndName);
		using SafeNamespaceHandle pns = CreatePrivateNamespace(null, bdh, nsName);
		if (pns.IsNull) TestContext.WriteLine($"ERR: CreateNS={Win32Error.GetLastError()}");
		Assert.That(pns.IsInvalid, Is.False);

		//var p = CSharpRunner.RunProcess(typeof(NSRunner));
		//p.WaitForExit();
		//Assert.That(p.ExitCode, Is.Zero);
	}

	[Test]
	public void AddToBoundaryTest()
	{
		BoundaryDescriptorHandle h = CreateBoundaryDescriptor(Path.GetRandomFileName());
		Assert.That(h.IsInvalid, Is.False);
		try
		{
			bool b = AddSIDToBoundaryDescriptor(ref h, SafePSID.Current);
			if (!b) TestContext.WriteLine($"ERR: AddSid={Win32Error.GetLastError()}");
			Assert.That(b, Is.True);

			var plsid = SafePSID.Init(KnownSIDAuthority.SECURITY_MANDATORY_LABEL_AUTHORITY, KnownSIDRelativeID.SECURITY_MANDATORY_MEDIUM_RID);
			b = AddIntegrityLabelToBoundaryDescriptor(ref h, plsid);
			if (!b) TestContext.WriteLine($"ERR: AddSid={Win32Error.GetLastError()}");
			Assert.That(b, Is.True);
		}
		finally
		{
			DeleteBoundaryDescriptor(h);
		}
	 }

	[Test]
	public void AddToBoundaryTest2()
	{
		BoundaryDescriptorHandle bdh = CreateBoundaryDescriptor(Path.GetRandomFileName());
		using SafePSID pCurSid = SafePSID.Current;
		Assert.That(bdh.IsInvalid, Is.False);
		Assert.That(BoundaryDescriptorHandle.AddSid(ref bdh, pCurSid), Is.True);
	}
}