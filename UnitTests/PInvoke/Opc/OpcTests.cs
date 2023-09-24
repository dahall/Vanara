using NUnit.Framework;
using static Vanara.PInvoke.Opc;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class OpcTests
{
	public IOpcFactory factory;

	[OneTimeSetUp]
	public void _Setup() => factory = new IOpcFactory();

	[OneTimeTearDown]
	public void _TearDown() => Marshal.ReleaseComObject(factory);

	[Test]
	public void LoadTest()
	{
		Assert.That(factory.CreateStreamOnFile(TestCaseSources.WordDoc, OPC_STREAM_IO_MODE.OPC_STREAM_IO_READ, null, 0, out var sourceFileStream), ResultIs.Successful);
		using var psourceFileString = ComReleaserFactory.Create(sourceFileStream);

		Assert.That(factory.ReadPackageFromStream(sourceFileStream, OPC_READ_FLAGS.OPC_CACHE_ON_ACCESS, out var outPackage), ResultIs.Successful);
		using var poutPackage = ComReleaserFactory.Create(outPackage);

		IOpcPartSet pset = null;
		Assert.That(() => pset = outPackage.GetPartSet(), Throws.Nothing);
		using var ppset = ComReleaserFactory.Create(pset);

		IOpcPartEnumerator penum = null;
		Assert.That(() => penum = pset.GetEnumerator(), Throws.Nothing);
		using var ppenum = new OpcEnumerator<IOpcPartEnumerator, IOpcPart>(penum);

		while (ppenum.MoveNext())
			TestContext.WriteLine($"{ppenum.Current.GetContentType()}, {ppenum.Current.GetCompressionOptions()}");
		TestContext.WriteLine();

		IOpcRelationshipSet rset = null;
		Assert.That(() => rset = outPackage.GetRelationshipSet(), Throws.Nothing);
		using var prset = ComReleaserFactory.Create(rset);

		IOpcRelationshipEnumerator renum = null;
		Assert.That(() => renum = rset.GetEnumerator(), Throws.Nothing);
		using var prenum = new OpcEnumerator<IOpcRelationshipEnumerator, IOpcRelationship>(renum);

		while (prenum.MoveNext())
			TestContext.WriteLine($"{prenum.Current.GetId()}, {prenum.Current.GetRelationshipType()}, {prenum.Current.GetTargetMode()}");
		TestContext.WriteLine();
	}

	[Test]
	public void RootTest()
	{
		IOpcUri rootUri = null;
		Assert.That(() => rootUri = factory.CreatePackageRootUri(), Throws.Nothing);
		Assert.That(rootUri, Is.Not.Null);
		Marshal.ReleaseComObject(rootUri);
	}
}