using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using NUnit.Framework;
using Vanara.CodeGen;
using VerifyCS = Microsoft.CodeAnalysis.CSharp.Testing.CSharpCodeFixVerifier<MarshalerStructNoAttrAnalyzer, Vanara.CodeGen.MarshalerStructAttrFixProvider, Microsoft.CodeAnalysis.Testing.DefaultVerifier>;
using static Vanara.PInvoke.Tests.CodeAnalysisHelpers;

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
			await Analyze(source, MakeDiag(pos, arg));
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
			await CodeFix(source, fixedSrc, MakeDiag(pos, arg));
	}

	private static async Task Analyze(string source, params DiagnosticResult[] expected) => await Analyze<MarshalerStructNoAttrAnalyzer>(source, expected);

	private static async Task CodeFix(string source, string sourceFix, params DiagnosticResult[] expected) =>
		await CodeFix<MarshalerStructNoAttrAnalyzer, MarshalerStructAttrFixProvider>(source, sourceFix, expected);

	private static DiagnosticResult MakeDiag(LinePosition lp, string arg) =>
		VerifyCS.Diagnostic(MarshalerStructNoAttrAnalyzer.DiagnosticId).WithLocation(lp).WithArguments(arg);
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
	public StrPtrUni s;
	public int c;
	public ArrayPointer<int> a;
}
*/