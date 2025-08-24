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
		using SafeBoundaryDescriptorHandle bdh = CreateBoundaryDescriptor(bndName);
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
		SafeBoundaryDescriptorHandle bdh = CreateBoundaryDescriptor(Path.GetRandomFileName());
		Assert.That(bdh.IsInvalid, Is.False);
		BoundaryDescriptorHandle h = bdh;
		try
		{
			bool b = AddSIDToBoundaryDescriptor(ref h, SafePSID.Current);
			if (!b) TestContext.WriteLine($"ERR: AddSid={Win32Error.GetLastError()}");
			Assert.That(b, Is.True);

			//var plsid = SafePSID.Init(KnownSIDAuthority.SECURITY_MANDATORY_LABEL_AUTHORITY, MandatoryIntegrityLevelSIDRelativeID.SECURITY_MANDATORY_MEDIUM_RID);
			//b = AddIntegrityLabelToBoundaryDescriptor(ref h, plsid);
			//if (!b) TestContext.WriteLine($"ERR: AddSid={Win32Error.GetLastError()}");
			//Assert.That(b, Is.True);
		}
		finally
		{
			//DeleteBoundaryDescriptor(h);
			bdh.Close();
		}
	 }

	[Test]
	public void AddToBoundaryTest2()
	{
		using SafeBoundaryDescriptorHandle bdh = CreateBoundaryDescriptor(Path.GetRandomFileName());
		using SafePSID pCurSid = SafePSID.Current;
		Assert.That(bdh.IsInvalid, Is.False);
		Assert.That(bdh.AddSid(pCurSid), Is.True);
		//var plsid = SafePSID.Init(KnownSIDAuthority.SECURITY_MANDATORY_LABEL_AUTHORITY, MandatoryIntegrityLevelSIDRelativeID.SECURITY_MANDATORY_MEDIUM_RID);
		//Assert.That(bdh.AddSid(plsid), Is.True);
	}
}

//public static class NSRunner
//{
//	public static int MyMain()
//	{
//		using (var bdh = CreateBoundaryDescriptor("BND1"))
//		using (var pns = OpenPrivateNamespace(bdh, "NS1"))
//		{
//			Console.WriteLine($"BndDec: {!bdh.IsNull}");
//			Console.WriteLine($"PNS: {!pns.IsNull}");
//			Console.ReadKey();
//			return pns.IsNull ? (int)Win32Error.GetLastError() : 0;
//		}
//	}
//}