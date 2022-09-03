using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;
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

		IRdcFileReader reader = new RdcFileReader(File.OpenRead(TestCaseSources.WordDoc));
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

[ClassInterface(ClassInterfaceType.None)]
[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
[ComVisible(true)]
[Guid("01EED492-3E92-4DF1-AC94-A7CDD0F23699")]
public class RdcFileReader : IRdcFileReader
{
	private readonly Stream stream;

	private RdcFileReader() { }

	public RdcFileReader(Stream stream) => this.stream = stream;

	HRESULT IRdcFileReader.GetFileSize(out ulong fileSize)
	{
		fileSize = (ulong)stream.Length;
		return HRESULT.S_OK;
	}

	HRESULT IRdcFileReader.Read(ulong offsetFileStart, uint bytesToRead, out uint bytesActuallyRead, byte[] buffer, out bool eof)
	{
		if (stream.Position != (long)offsetFileStart)
		{
			stream.Seek((long)offsetFileStart, SeekOrigin.Begin);
		}

		var intBuff = new byte[bytesToRead];
		int read = 0, lastRead;
		do
		{
			lastRead = stream.Read(intBuff, read, ((int)bytesToRead - read));
			read += lastRead;
		} while (lastRead != 0 && read < bytesToRead);
		bytesActuallyRead = (uint)read;
		Array.Copy(intBuff, buffer, (int)bytesToRead);
		eof = read < bytesToRead;
		return HRESULT.S_OK;
	}

	HRESULT IRdcFileReader.GetFilePosition(out ulong offsetFromStart)
	{
		offsetFromStart = (uint)stream.Position;
		return HRESULT.S_OK;
	}
}