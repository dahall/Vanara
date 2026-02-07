using Microsoft.CodeAnalysis;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Linq;
using Vanara.Generators;

namespace Vanara.PInvoke.Tests;

public partial class CodeGenTests
{
	[Test]
	public void TypeDefTest()
	{
		const string src = /* lang=c#-test */ """
			namespace Vanara.PInvoke
			{
				[TypeDef(typeof(uint), Excludes = ExcludeOptions.Numerics)]
				public partial struct LUID { }
			}
			""";
		var compilation = GetCompilation(src);
		CreateGeneratorDriverAndRun(compilation, new TypeDefGenerator(), null, out var output, out var diag);
		WriteTrees(TestContext.Out, output.SyntaxTrees);
		WriteDiags(diag);
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error), Is.Empty);
		Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(3));

		//Assert.That(FindMethod("GetHashCode", output.SyntaxTrees.ElementAt(1)), Is.Not.Null, "Hash method should be available.");
		//Assert.That(FindMethod("GetObjectData", output.SyntaxTrees.ElementAt(1)), Is.Null, "Serialize method should be removed.");
		//Assert.That(FindMethod("Parse", output.SyntaxTrees.ElementAt(1)), Is.Null, "Parse method should be removed.");
		//Assert.That(FindMethod("GetTypeCode", output.SyntaxTrees.ElementAt(1)), Is.Null, "Convertible method should be removed.");
		//Assert.That(FindMethod("op_Addition", output.SyntaxTrees.ElementAt(1)), Is.Null, "Numerics method should be removed.");
	}

	[Test]
	public void TypeDefPtrTest()
	{
		const string src = /* lang=c#-test */ """
			namespace Vanara.PInvoke
			{
				[TypeDef(typeof(nuint), ConvertTo = typeof(ulong), GetConvValue="value", SetConvValue="new UIntPtr(value)")]
				public partial struct SizeT { }
			}
			""";
		var compilation = GetCompilation(src);
		CreateGeneratorDriverAndRun(compilation, new TypeDefGenerator(), null, out var output, out var diag);
		WriteTrees(TestContext.Out, output.SyntaxTrees);
		WriteDiags(diag);
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error), Is.Empty);
		Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(3));

		//Assert.That(FindMethod("GetHashCode", output.SyntaxTrees.ElementAt(1)), Is.Not.Null, "Hash method should be available.");
		//Assert.That(FindMethod("GetObjectData", output.SyntaxTrees.ElementAt(1)), Is.Null, "Serialize method should be removed.");
		//Assert.That(FindMethod("Parse", output.SyntaxTrees.ElementAt(1)), Is.Null, "Parse method should be removed.");
		//Assert.That(FindMethod("GetTypeCode", output.SyntaxTrees.ElementAt(1)), Is.Null, "Convertible method should be removed.");
		//Assert.That(FindMethod("op_Addition", output.SyntaxTrees.ElementAt(1)), Is.Null, "Numerics method should be removed.");
	}

	[Test]
	public void TypeDefConversionTest()
	{
		const string src = /* lang=c#-test */ """
			namespace Vanara.PInvoke
			{
				[TypeDef(typeof(uint), ConvertTo = typeof(bool), Excludes = ExcludeOptions.Numerics)]
				public partial struct BOOL { }
			}
			""";
		var compilation = GetCompilation(src);
		CreateGeneratorDriverAndRun(compilation, new TypeDefGenerator(), null, out var output, out var diag);
		WriteTrees(TestContext.Out, output.SyntaxTrees);
		WriteDiags(diag);
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error), Is.Empty);
		Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(3));

		//Assert.That(FindMethod("GetHashCode", output.SyntaxTrees.ElementAt(1)), Is.Not.Null, "Hash method should be available.");
		//Assert.That(FindMethod("GetObjectData", output.SyntaxTrees.ElementAt(1)), Is.Null, "Serialize method should be removed.");
		//Assert.That(FindMethod("Parse", output.SyntaxTrees.ElementAt(1)), Is.Null, "Parse method should be removed.");
		//Assert.That(FindMethod("GetTypeCode", output.SyntaxTrees.ElementAt(1)), Is.Null, "Convertible method should be removed.");
		//Assert.That(FindMethod("op_Addition", output.SyntaxTrees.ElementAt(1)), Is.Null, "Numerics method should be removed.");
	}
}