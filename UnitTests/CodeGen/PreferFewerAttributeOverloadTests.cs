using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using NUnit.Framework;
using Vanara.CodeGen;
using VerifyCS = Microsoft.CodeAnalysis.CSharp.Testing.CSharpAnalyzerVerifier<PreferFewerAttributeOverloadAnalyzer, Microsoft.CodeAnalysis.Testing.DefaultVerifier>;
using static Vanara.PInvoke.Tests.CodeAnalysisHelpers;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class PreferFewerAttributeOverloadTests
{
	const string test = /* lang=c#-test */ """
		using System;
		using System.Runtime.InteropServices;
		using Vanara.InteropServices;
		using Vanara.PInvoke;
		using static Vanara.PInvoke.Crypt32;
			
		namespace Test;

		internal static class TestClass
		{   
			public static void CallMethod() { [VALUE] }
		}
		""";

	static readonly LinePosition pos = new(11, 36);

	[Test]
	public async Task AnalyzeNoDiag() => await VerifyCS.VerifyAnalyzerAsync(string.Empty);

	[TestCase("uint i = 50; var h = new byte[(uint)i]; CertSerializeCTLStoreElement(default, default, h, ref i);", "Crypt32.CertSerializeCTLStoreElement(Crypt32.PCCTL_CONTEXT, out byte[]?)", 40, 56)]
	[TestCase("CertSerializeCTLStoreElement(default, out var elements);", null, 0, 0)]
	[TestCase("var h = new byte[128]; CryptGetMessageSignerCount(default, h, h.Length);", "Crypt32.CryptGetMessageSignerCount(Crypt32.CertEncodingType, byte[])", 23, 48)]
	[TestCase("CryptGetMessageSignerCount(default, new byte[4]);", null, 0, 0)]
	public async Task AnalyzeNoFix(string value, string? arg, int p, int l)
	{
		var source = test.Replace("[VALUE]", value);
		if (arg is null && p == 0)
			await Analyze(source);
		else
			await Analyze(source, MakeDiag(p, l, arg));
	}

	[TestCase("uint i = 50; var h = new byte[(uint)i]; CertSerializeCTLStoreElement(default, default, h, ref i);", "CertSerializeCTLStoreElement(default, out byte[]? h);")]
	[TestCase("CertSerializeCTLStoreElement(default, out var elements);", null)]
	[TestCase("var h = new byte[128]; CryptGetMessageSignerCount(default, h, h.Length);", "CryptGetMessageSignerCount(default, h);")]
	[TestCase("CryptGetMessageSignerCount(default, new byte[4]);", null)]
	public async Task AnalyzeWithFix(string value, string fixedParams, string? arg)
	{
		var source = test.Replace("[VALUE]", value);
		var fixedSrc = test.Replace("[VALUE]", fixedParams);
		if (arg is null)
			await CodeFix(source, fixedSrc);
		else
			await CodeFix(source, fixedSrc, MakeDiag(0, 0, arg!));
	}

	private static async Task Analyze(string source, params DiagnosticResult[] expected) => await Analyze<PreferFewerAttributeOverloadAnalyzer>(source, expected);

	private static async Task CodeFix(string source, string sourceFix, params DiagnosticResult[] expected) =>
		await CodeFix<PreferFewerAttributeOverloadAnalyzer, PreferFewerAttributeOverloadCodeFixProvider>(source, sourceFix, expected);

	private static DiagnosticResult MakeDiag(int p, int l, string? arg = null) =>
		VerifyCS.Diagnostic(PreferFewerAttributeOverloadAnalyzer.DiagnosticId).WithSpan(pos.Line, pos.Character + p, pos.Line, pos.Character + p + l).WithArguments(arg ?? "");
}