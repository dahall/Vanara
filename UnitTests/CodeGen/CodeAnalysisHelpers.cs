using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;
using System.Collections.Immutable;
using Vanara.CodeGen;

namespace Vanara.PInvoke.Tests;

internal static class CodeAnalysisHelpers
{
	private const string pkg = "Vanara.PInvoke.Cryptography";
	private const string pkgVer = "5.0.1";
	private static readonly string VanaraCoreRef = $@"Vanara.Core.dll";

	internal static async Task Analyze<TAnalyzer>(string source, params DiagnosticResult[] expected)
		where TAnalyzer : DiagnosticAnalyzer, new()
	{
		CSharpAnalyzerTest<TAnalyzer, DefaultVerifier> test = new()
		{
			ReferenceAssemblies = ReferenceAssemblies.Net.Net80Windows.AddPackages([new(pkg, pkgVer)]),
			TestCode = source,
		};
		//test.TestState.AdditionalReferences.AddRange(MetaReferences);
		test.ExpectedDiagnostics.AddRange(expected);
		await test.RunAsync();
	}

	internal static async Task CodeFix<TAnalyzer, TCodeFix>(string source, string sourceFix, params DiagnosticResult[] expected)
		where TAnalyzer : DiagnosticAnalyzer, new()
		where TCodeFix : CodeFixProvider, new()
	{
		CSharpCodeFixTest<TAnalyzer, TCodeFix, DefaultVerifier> test = new()
		{
			ReferenceAssemblies = ReferenceAssemblies.Net.Net80Windows.AddPackages([new(pkg, pkgVer)]),
			TestCode = source,
			FixedCode = sourceFix,
		};
		//test.TestState.AdditionalReferences.AddRange(MetaReferences);
		test.ExpectedDiagnostics.AddRange(expected);
		await test.RunAsync();
	}

	internal static List<MetadataReference> MetaReferences { get; } =
		[.. AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic).Select(a => MetadataReference.CreateFromFile(a.Location)).Cast<MetadataReference>().Concat([MetadataReference.CreateFromFile(VanaraCoreRef)])];

	internal static MethodDeclarationSyntax? FindMethod(string name, SyntaxTree tree) =>
		tree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>().FirstOrDefault(m => m.Identifier.Text == name);

	internal static void WriteDiags(ImmutableArray<Diagnostic> diag, DiagnosticSeverity sev = DiagnosticSeverity.Error)
	{
		foreach (Diagnostic? d in diag.Where(d => d.Severity == sev))
			TestContext.Out.WriteLine($"{d.Severity} {d.Id}: {d.GetMessage()} @ {d.Location.SourceSpan}");
	}

	internal static void WriteTrees(TextWriter tw, IEnumerable<SyntaxTree> trees, bool skipFirst = true)
	{
		foreach (SyntaxTree? tree in trees.Skip(skipFirst ? 1 : 0))
		{
			var fn = Path.GetFileName(tree.FilePath);
			tw.WriteLine($"== {fn} {new string('=', 78 - fn.Length)}");
			tw.WriteLine(tree);
		}
	}
}