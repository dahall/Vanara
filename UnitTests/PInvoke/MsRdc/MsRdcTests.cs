using NUnit.Framework;
using NUnit.Framework.Internal;
using System.IO;
using static Vanara.PInvoke.MsRdc;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class MsRdcTests
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
	public void Test()
	{
		IRdcLibrary lib = new();
		lib.GetRDCVersion(out var curVer, out var minAppVer);
		TestContext.WriteLine($"CurVer={curVer}, MinAppVer={minAppVer}");
		var maxdepth = lib.ComputeDefaultRecursionDepth(12 * 1024);
		TestContext.WriteLine($"MaxDepth={maxdepth}");
		var gParams = lib.CreateGeneratorParameters(GeneratorParametersType.RDCGENTYPE_FilterMax, MSRDC_MINIMUM_DEPTH);
		var gen = lib.CreateGenerator(MSRDC_MINIMUM_DEPTH, new[] { gParams });
		var gParamsCopy = gen.GetGeneratorParameters(MSRDC_MINIMUM_DEPTH);
		Assert.That(gParams.GetSerializeSize(), Is.EqualTo(gParamsCopy.GetSerializeSize()));

		IRdcFileReader reader = new RdcStreamReader(File.OpenRead(TestCaseSources.WordDoc));
		//var comp = lib.CreateComparator(reader, maxdepth);
		var sigRead = lib.CreateSignatureReader(reader);
		//TestContext.WriteLine($"SigHdrRes={sigRead.ReadHeader()}");

		SafeHGlobalHandle buf = new(8 * 1024 + 16);
		RdcBufferPointer inputBuf = new() { m_Data = buf, m_Size = 2048 };
		SafeNativeArray<RdcBufferPointer> outputBufs = new((int)MSRDC_MINIMUM_DEPTH);
		gen.Process(false, out var eoo, ref inputBuf, MSRDC_MINIMUM_DEPTH, outputBufs.GetPointers(), out var errCode);
		TestContext.WriteLine($"EndOfOut={eoo}, Err={errCode}");
	}

	[Test]
	public void SigGenTest()
	{
	}
}