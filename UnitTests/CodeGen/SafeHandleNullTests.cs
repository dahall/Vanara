using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using Vanara.CodeGen;
using Vanara.Marshaler;
using VerifyCS = Microsoft.CodeAnalysis.CSharp.Testing.CSharpCodeFixVerifier<SafeHANDLENullAnalyzer, Vanara.CodeGen.SafeHANDLENullCodeFixProvider, Microsoft.CodeAnalysis.Testing.DefaultVerifier>;

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

	static string? s = null;
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
	[TestCase("SafeTestHandle? h = default", "SafeTestHandle")]
	[TestCase("SafeTestHandle? h = null", "SafeTestHandle")]
	public async Task AnalyzeNoFix(string value, string? arg)
	{
		var source = test.Replace("[VALUE]", value);
		if (arg is null)
			await Analyze(source);
		else
			await Analyze(source, VerifyCS.Diagnostic(SafeHANDLENullAnalyzer.DiagnosticId).WithLocation(new LinePosition(pos.Line, pos.Character + value.IndexOf("= ") + 2)).WithArguments(arg!));
	}

	[TestCase("IntPtr h = default", "IntPtr h = default", null)]
	[TestCase("SafeTestHandle h = new(default, false)", "SafeTestHandle h = new(default, false)", null)]
	[TestCase("SafeTestHandle h = default", "SafeTestHandle h = SafeTestHandle.Null", "SafeTestHandle")]
	[TestCase("SafeTestHandle h = null", "SafeTestHandle h = SafeTestHandle.Null", "SafeTestHandle")]
	[TestCase("SafeTestHandle? h = default", "SafeTestHandle? h = SafeTestHandle.Null", "SafeTestHandle")]
	[TestCase("SafeTestHandle? h = null", "SafeTestHandle? h = SafeTestHandle.Null", "SafeTestHandle")]
	public async Task AnalyzeWithFix(string value, string fixedParams, string? arg)
	{
		var source = test.Replace("[VALUE]", value);
		var fixedSrc = test.Replace("[VALUE]", fixedParams);
		if (arg is null)
			await CodeFix(source, fixedSrc);
		else
			await CodeFix(source, fixedSrc, VerifyCS.Diagnostic(SafeHANDLENullAnalyzer.DiagnosticId).WithLocation(new LinePosition(pos.Line, pos.Character + value.IndexOf("= ") + 2)).WithArguments(arg!));
	}

	private static async Task Analyze(string source, params DiagnosticResult[] expected)
	{
		var test = new CSharpAnalyzerTest<SafeHANDLENullAnalyzer, DefaultVerifier>
		{
			ReferenceAssemblies = ReferenceAssemblies.Net.Net80Windows,
			TestCode = source,
			TestState =
			{
				AdditionalReferences = { typeof(MarshaledAttribute).Assembly.Location },
			}
		};
		test.ExpectedDiagnostics.AddRange(expected);
		await test.RunAsync();
	}

	private static async Task CodeFix(string source, string sourceFix, params DiagnosticResult[] expected)
	{
		var test = new CSharpCodeFixTest<SafeHANDLENullAnalyzer, SafeHANDLENullCodeFixProvider, DefaultVerifier>
		{
			ReferenceAssemblies = ReferenceAssemblies.Net.Net80Windows,
			TestCode = source,
			FixedCode = sourceFix,
			TestState =
			{
				AdditionalReferences = { typeof(MarshaledAttribute).Assembly.Location },
			}
		};
		test.ExpectedDiagnostics.AddRange(expected);
		await test.RunAsync();
	}
}