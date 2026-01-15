using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using Vanara.CodeGen;
using Vanara.Marshaler;
using VerifyCS = Microsoft.CodeAnalysis.CSharp.Testing.CSharpCodeFixVerifier<MarshalerStructNoAttrAnalyzer, Vanara.CodeGen.MarshalerStructAttrFixProvider, Microsoft.CodeAnalysis.Testing.DefaultVerifier>;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class MarshalStructNoAttrTests
{
	const string test = /* lang=c#-test */ """
		using System;
		using System.Runtime.InteropServices;
		using Vanara.Marshaler;
			
		namespace Test;

		[StructLayout(LayoutKind.Sequential)]
		public struct UnmarshaledStruct
		{
			public IntPtr s;
		}

		[Marshaled]
		public struct MarshaledStruct
		{
			[MarshalAs(UnmanagedType.LPWStr)]
			public string s;

			internal int c;

			[MarshalFieldAs.Array(ArrayLayout.LPArray, SizeFieldName = "c")]
			public int[] a;
		}
			
		internal static class TestClass
		{   
			public static void TestMethod([PARAMS]) { }
		}
		""";

	static readonly LinePosition pos = new(26, 31);

	[Test]
	public async Task AnalyzeNoDiag()
	{
		await VerifyCS.VerifyAnalyzerAsync(string.Empty);
	}

	[TestCase(0, "in UnmarshaledStruct s", "UnmarshaledStruct")]
	[TestCase(1, "MarshaledStruct s", "MarshaledStruct")]
	[TestCase(1, "in MarshaledStruct s", "MarshaledStruct")]
	[TestCase(1, "ref MarshaledStruct s", "MarshaledStruct")]
	[TestCase(1, "[In] MarshaledStruct s", "MarshaledStruct")]
	[TestCase(1, "[In, MarshalAs(UnmanagedType.Struct)] MarshaledStruct s", "MarshaledStruct")]
	[TestCase(0, "[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Vanara.InteropServices.VanaraCustomMarshaler<MarshaledStruct>))] in MarshaledStruct s", "MarshaledStruct")]
	public async Task AnalyzeNoFix(int cerr, string value, string arg)
	{
		var source = test.Replace("[PARAMS]", value);
		if (cerr == 0)
			await Analyze(source);
		else
			await Analyze(source, VerifyCS.Diagnostic(MarshalerStructNoAttrAnalyzer.DiagnosticId).WithLocation(pos).WithArguments(arg));
	}

	[TestCase(1, "MarshaledStruct s", "[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Vanara.InteropServices.VanaraCustomMarshaler<MarshaledStruct>))] MarshaledStruct s", "MarshaledStruct")]
	[TestCase(1, "in MarshaledStruct s", "[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Vanara.InteropServices.VanaraCustomMarshaler<MarshaledStruct>))] in MarshaledStruct s", "MarshaledStruct")]
	[TestCase(1, "ref MarshaledStruct s", "[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Vanara.InteropServices.VanaraCustomMarshaler<MarshaledStruct>))] ref MarshaledStruct s", "MarshaledStruct")]
	[TestCase(1, "[In] MarshaledStruct s", "[In][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Vanara.InteropServices.VanaraCustomMarshaler<MarshaledStruct>))] MarshaledStruct s", "MarshaledStruct")]
	[TestCase(1, "[In, MarshalAs(UnmanagedType.Struct)] MarshaledStruct s", "[In][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Vanara.InteropServices.VanaraCustomMarshaler<MarshaledStruct>))] MarshaledStruct s", "MarshaledStruct")]
	[TestCase(1, "[In][MarshalAs(UnmanagedType.Struct)] MarshaledStruct s", "[In][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Vanara.InteropServices.VanaraCustomMarshaler<MarshaledStruct>))] MarshaledStruct s", "MarshaledStruct")]
	[TestCase(0, "[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Vanara.InteropServices.VanaraCustomMarshaler<MarshaledStruct>))] in MarshaledStruct s", "[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Vanara.InteropServices.VanaraCustomMarshaler<MarshaledStruct>))] in MarshaledStruct s", "MarshaledStruct")]
	public async Task AnalyzeWithFix(int cerr, string value, string fixedParams, string arg)
	{
		var source = test.Replace("[PARAMS]", value);
		var fixedSrc = test.Replace("[PARAMS]", fixedParams);
		if (cerr == 0)
			await CodeFix(source, fixedSrc);
		else
			await CodeFix(source, fixedSrc, VerifyCS.Diagnostic(MarshalerStructNoAttrAnalyzer.DiagnosticId).WithLocation(pos).WithArguments(arg));
	}

	private static async Task Analyze(string source, params DiagnosticResult[] expected)
	{
		var test = new CSharpAnalyzerTest<MarshalerStructNoAttrAnalyzer, DefaultVerifier>
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
		var test = new CSharpCodeFixTest<MarshalerStructNoAttrAnalyzer, MarshalerStructAttrFixProvider, DefaultVerifier>
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
/*
[Marshaled]
public struct MarshaledStruct
{
	[MarshalAs(UnmanagedType.LPWStr)]
	public string s;

	internal int c;

	[MarshalFieldAs.Array(ArrayLayout.LPArray, SizeFieldName = "c")]
	public int[] a;
}

[StructLayout(LayoutKind.Sequential)]
public struct UnmarshaledStruct
{
	public LPWSTR s;
	public int c;
	public ArrayPointer<int> a;
}
*/