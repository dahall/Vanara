using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.NtDll;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public partial class NtDllTests
{
	[Test]
	public void NtQuerySystemInformationTest()
	{
#pragma warning disable CS0618 // Type or member is obsolete
		var bi = NtQuerySystemInformation<SYSTEM_BASIC_INFORMATION>(SYSTEM_INFORMATION_CLASS.SystemBasicInformation);
#pragma warning restore CS0618 // Type or member is obsolete
		Assert.That(bi.NumberOfProcessors, Is.Not.Zero);
		var qi = NtQuerySystemInformation<SYSTEM_REGISTRY_QUOTA_INFORMATION>(SYSTEM_INFORMATION_CLASS.SystemRegistryQuotaInformation);
		Assert.That(qi.RegistryQuotaUsed, Is.Not.Zero);
		var ppi = NtQuerySystemInformation<SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION[]>(SYSTEM_INFORMATION_CLASS.SystemProcessorPerformanceInformation);
		Assert.That(ppi?.Length, Is.EqualTo(bi.NumberOfProcessors));

		var arr = NtQuerySystemInformation<SYSTEM_PROCESS_INFORMATION[]>(SYSTEM_INFORMATION_CLASS.SystemProcessInformation);
		var pti = NtQuerySystemInformation_Process();
		Assert.That(arr?.Length, Is.EqualTo(pti.Count));

		TestContext.WriteLine($"{bi.NumberOfProcessors} Cores; {pti.Count} Processes; {pti.Sum(t => t.Item2.Length)} Threads");
	}

	[Test]
	public void NtQueryInformationFileTest_Name()
	{
		using var hFile = CreateFile(TestCaseSources.WordDoc, FileAccess.GENERIC_READ, FILE_SHARE.FILE_SHARE_READ, null, CreationOption.OPEN_EXISTING, FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL);
		Assert.That(hFile, ResultIs.ValidHandle);
		var ret = NtQueryInformationFile(hFile, out var stat, FILE_INFORMATION_CLASS.FileNameInformation, out FILE_NAME_INFORMATION? fn);
		Assert.That(ret, ResultIs.Successful);
		Assert.That(fn, Is.Not.Null);
		Assert.That(fn!.Value.FileName, Is.EqualTo(TestCaseSources.WordDoc.Substring(2)));
	}

	[Test]
	public void NtQueryInformationFileTest_Basic()
	{
		using var hFile = CreateFile(TestCaseSources.WordDoc, FileAccess.GENERIC_READ, FILE_SHARE.FILE_SHARE_READ, null, CreationOption.OPEN_EXISTING, FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL);
		Assert.That(hFile, ResultIs.ValidHandle);
		var ret = NtQueryInformationFile(hFile, out var stat, FILE_INFORMATION_CLASS.FileBasicInformation, out FILE_BASIC_INFORMATION? fi);
		Assert.That(ret, ResultIs.Successful);
		Assert.That(fi, Is.Not.Null);
		var fsi = new System.IO.FileInfo(TestCaseSources.WordDoc);
		Assert.That(fi!.Value.CreationTime.ToDateTime(), Is.EqualTo(fsi.CreationTime));
		fi.Value.WriteValues();
	}

	[Test]
	public void DumpAllNtQueryFileInfoTest()
	{
		using var priv = new ElevPriv("SeBackupPrivilege");
		using var hFile = CreateFile(TestCaseSources.TempDir, FileAccess.GENERIC_READ, FILE_SHARE.FILE_SHARE_READ, null, CreationOption.OPEN_EXISTING, FileFlagsAndAttributes.FILE_FLAG_BACKUP_SEMANTICS);
		Assert.That(hFile, ResultIs.ValidHandle);
		using SafeCoTaskMemHandle mem = new(4096);
		foreach (var i in Enum.GetValues(typeof(FILE_INFORMATION_CLASS)).Cast<FILE_INFORMATION_CLASS>())
		{
			Type? t = CorrespondingTypeAttribute.GetCorrespondingTypes(i).FirstOrDefault();
			if (t is null)
				continue;
			var ret = NtQueryInformationFile(hFile, out var stat, mem, mem.Size, i);
			TestContext.WriteLine($"{i} ({t.Name}) = {ret}");
			if (ret.Succeeded)
				mem.DangerousGetHandle().Convert(mem.Size, t, CharSet.Unicode)!.WriteValues();
		}
	}

	[Test]
	public void SafeUNICODE_STRING_Test()
	{
		const string testStr = "Testing. 1. 2. 3.";
		SafeUNICODE_STRING? sstr = null;
		try
		{
			Assert.That(() => sstr = testStr, Throws.Nothing);
			Assert.That((string?)sstr!, Is.EqualTo(testStr));
		}
		finally
		{
			sstr?.Dispose();
		}
	}
}