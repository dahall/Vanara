using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using NUnit.Framework;
using Vanara.CodeGen;
using VerifyCS = Microsoft.CodeAnalysis.CSharp.Testing.CSharpCodeFixVerifier<SafeHANDLENullAnalyzer, Vanara.CodeGen.SafeHANDLENullCodeFixProvider, Microsoft.CodeAnalysis.Testing.DefaultVerifier>;
using static Vanara.PInvoke.Tests.CodeAnalysisHelpers;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class SafeHandleNullTests
{
	const string test = /* lang=c#-test */ """
		using System;
		using System.Runtime.InteropServices;
		using Vanara.PInvoke;
			
		namespace Test;

		public class SafeTestHandle(IntPtr handle, bool own) : SafeHANDLE(handle, own)
		{
			public static readonly SafeTestHandle Null = new(default, false);
			protected override bool InternalReleaseHandle() => true;
		}

		internal static class TestClass
		{   
			public static [VALUE];
		}
		""";

	static readonly LinePosition pos = new(14, 15);

	[Test]
	public async Task AnalyzeNoDiag()
	{
		await VerifyCS.VerifyAnalyzerAsync(string.Empty);
	}

	[TestCase("IntPtr h = default", null)]
	[TestCase("SafeTestHandle h = new(default, false)", null)]
	[TestCase("SafeTestHandle h = default", "SafeTestHandle")]
	[TestCase("SafeTestHandle h = null", "SafeTestHandle")]
	[TestCase("SafeTestHandle? h = default", null)]
	[TestCase("SafeTestHandle? h = null", null)]
	public async Task AnalyzeNoFix(string value, string? arg)
	{
		var source = test.Replace("[VALUE]", value);
		if (arg is null)
			await Analyze(source);
		else
			await Analyze(source, MakeDiag(pos.Line, pos.Character + value.IndexOf("= ") + 2, arg!));
	}

	[TestCase("IntPtr h = default", "IntPtr h = default", null)]
	[TestCase("SafeTestHandle h = new(default, false)", "SafeTestHandle h = new(default, false)", null)]
	[TestCase("SafeTestHandle h = default", "SafeTestHandle h = SafeTestHandle.Null", "SafeTestHandle")]
	[TestCase("SafeTestHandle h = null", "SafeTestHandle h = SafeTestHandle.Null", "SafeTestHandle")]
	[TestCase("SafeTestHandle? h = default", "SafeTestHandle? h = default", null)]
	[TestCase("SafeTestHandle? h = null", "SafeTestHandle? h = null", null)]
	public async Task AnalyzeWithFix(string value, string fixedParams, string? arg)
	{
		var source = test.Replace("[VALUE]", value);
		var fixedSrc = test.Replace("[VALUE]", fixedParams);
		if (arg is null)
			await CodeFix(source, fixedSrc);
		else
			await CodeFix(source, fixedSrc, MakeDiag(pos.Line, pos.Character + value.IndexOf("= ") + 2, arg!));
	}

	private static async Task Analyze(string source, params DiagnosticResult[] expected) => await Analyze<SafeHANDLENullAnalyzer>(source, expected);

	private static async Task CodeFix(string source, string sourceFix, params DiagnosticResult[] expected) =>
		await CodeFix<SafeHANDLENullAnalyzer, SafeHANDLENullCodeFixProvider>(source, sourceFix, expected);

	private static DiagnosticResult MakeDiag(int line, int character, string arg) =>
		VerifyCS.Diagnostic(SafeHANDLENullAnalyzer.DiagnosticId).WithLocation(new LinePosition(line, character)).WithArguments(arg);
}