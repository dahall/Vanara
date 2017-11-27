using NUnit.Framework;
using System;

namespace Vanara.Extensions.Tests
{
	[TestFixture()]
	public class EnumFlagIndexerTests
	{
		[Test()]
		public void EnumFlagIndexerTest()
		{
			Assert.That(() => { EnumFlagIndexer<ConsoleColor> e = ConsoleColor.Black; }, Throws.ArgumentException);
			Assert.That(() => { EnumFlagIndexer<int> e1 = 0; }, Throws.ArgumentException);
			var efi = new EnumFlagIndexer<GenericUriParserOptions>();
			Assert.That((GenericUriParserOptions)efi, Is.EqualTo(GenericUriParserOptions.Default));
			efi = new EnumFlagIndexer<GenericUriParserOptions>(GenericUriParserOptions.Idn);
			Assert.That((GenericUriParserOptions)efi, Is.EqualTo(GenericUriParserOptions.Idn));
		}

		[Test()]
		public void AndOrTest()
		{
			var efi = new EnumFlagIndexer<GenericUriParserOptions>(GenericUriParserOptions.Idn);
			Assert.That(efi | GenericUriParserOptions.NoPort, Is.EqualTo(GenericUriParserOptions.Idn | GenericUriParserOptions.NoPort));
			efi |= GenericUriParserOptions.NoPort;
			Assert.That(efi & GenericUriParserOptions.NoPort, Is.EqualTo(GenericUriParserOptions.NoPort));
		}

		[Test()]
		public void ClearTest()
		{
			var efi = new EnumFlagIndexer<GenericUriParserOptions>(GenericUriParserOptions.Idn);
			Assert.That((GenericUriParserOptions)efi, Is.EqualTo(GenericUriParserOptions.Idn));
			efi.Clear();
			Assert.That((GenericUriParserOptions)efi, Is.EqualTo(GenericUriParserOptions.Default));
		}

		[Test()]
		public void EqualsTest()
		{
			var efi = new EnumFlagIndexer<GenericUriParserOptions>(GenericUriParserOptions.Idn);
			Assert.That(efi.Equals(new EnumFlagIndexer<GenericUriParserOptions>(GenericUriParserOptions.Idn)), Is.True);
			Assert.That(efi == new EnumFlagIndexer<GenericUriParserOptions>(GenericUriParserOptions.Idn), Is.True);
			Assert.That(efi.Equals(GenericUriParserOptions.Idn), Is.True);
			Assert.That(efi == GenericUriParserOptions.Idn, Is.True);
			Assert.That(efi != GenericUriParserOptions.IriParsing, Is.True);
			Assert.That(efi.Equals(new EnumFlagIndexer<GenericUriParserOptions>(GenericUriParserOptions.IriParsing)), Is.False);
			Assert.That(efi.Equals(new EnumFlagIndexer<GenericUriParserOptions>(GenericUriParserOptions.IriParsing)), Is.False);
			Assert.That(efi.Equals(GenericUriParserOptions.IriParsing), Is.False);
			Assert.That(efi.Equals(512), Is.False);
			Assert.That(efi.Equals("512"), Is.False);
		}

		[Test()]
		public void GetHashCodeTest()
		{
			var efi = new EnumFlagIndexer<GenericUriParserOptions>(GenericUriParserOptions.Idn);
			Assert.That(efi.GetHashCode(), Is.EqualTo(GenericUriParserOptions.Idn.GetHashCode()));
		}

		[Test()]
		public void GetEnumeratorTest()
		{
			var efi = new EnumFlagIndexer<GenericUriParserOptions>(GenericUriParserOptions.Idn | GenericUriParserOptions.NoPort);
			Assert.That(efi, Is.EquivalentTo(new[] { GenericUriParserOptions.Idn, GenericUriParserOptions.NoPort }));
			efi |= (GenericUriParserOptions)4096;
			Assert.That(efi, Is.EquivalentTo(new[] { GenericUriParserOptions.Idn, GenericUriParserOptions.NoPort, (GenericUriParserOptions)4096 }));
		}

		[Test()]
		public void IndexerTest()
		{
			var efi = new EnumFlagIndexer<GenericUriParserOptions>(GenericUriParserOptions.Idn | GenericUriParserOptions.NoPort);
			Assert.That(efi[GenericUriParserOptions.Idn], Is.True);
			Assert.That(efi[GenericUriParserOptions.NoPort], Is.True);
			Assert.That(efi[GenericUriParserOptions.NoFragment], Is.False);
			efi[GenericUriParserOptions.NoFragment] = true;
			Assert.That(efi[GenericUriParserOptions.NoFragment], Is.True);
			Assert.That(efi, Is.EqualTo(GenericUriParserOptions.NoPort | GenericUriParserOptions.Idn | GenericUriParserOptions.NoFragment));
			efi[GenericUriParserOptions.Idn] = false;
			Assert.That(efi, Is.EqualTo(GenericUriParserOptions.NoPort | GenericUriParserOptions.NoFragment));
			efi[GenericUriParserOptions.GenericAuthority] = false;
			Assert.That(efi, Is.EqualTo(GenericUriParserOptions.NoPort | GenericUriParserOptions.NoFragment));
		}

		[Test()]
		public void ToStringTest()
		{
			var efi = new EnumFlagIndexer<GenericUriParserOptions>(GenericUriParserOptions.Idn);
			Assert.That(efi.ToString(), Is.EqualTo("Idn"));
			efi |= GenericUriParserOptions.NoPort;
			Assert.That(efi.ToString(), Is.EqualTo("NoPort, Idn"));
		}

		[Test()]
		public void UnionTest()
		{
			var efi = new EnumFlagIndexer<GenericUriParserOptions>(GenericUriParserOptions.Idn);
			efi.Union(GenericUriParserOptions.NoPort);
			Assert.That(efi.Equals(GenericUriParserOptions.Idn | GenericUriParserOptions.NoPort), Is.True);
			efi.Union(GenericUriParserOptions.NoPort);
			Assert.That(efi.Equals(GenericUriParserOptions.Idn | GenericUriParserOptions.NoPort), Is.True);
		}

		[Test()]
		public void UnionTest1()
		{
			var efi = new EnumFlagIndexer<GenericUriParserOptions>(GenericUriParserOptions.Idn);
			efi.Union(new[] { GenericUriParserOptions.IriParsing, GenericUriParserOptions.NoPort });
			Assert.That(efi.Equals(GenericUriParserOptions.Idn | GenericUriParserOptions.NoPort | GenericUriParserOptions.IriParsing), Is.True);
			efi.Union(new[] { GenericUriParserOptions.Idn, GenericUriParserOptions.NoPort });
			Assert.That(efi.Equals(GenericUriParserOptions.Idn | GenericUriParserOptions.NoPort | GenericUriParserOptions.IriParsing), Is.True);
		}
	}
}