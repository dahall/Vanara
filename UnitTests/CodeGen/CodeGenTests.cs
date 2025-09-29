using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Vanara.Generators;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class CodeGenTests
{
	[Test]
	public void AddAsMemberTest()
	{
		const string src = /* lang=c#-test */ """
			using System;
			using System.Runtime.InteropServices;
			namespace Vanara.PInvoke
			{
				public static partial class Test32
				{
					public partial struct HTEST { }

					public partial class SafeHTEST { }

					[DllImport("test32.dll", SetLastError = true)]
					public static extern bool IsExcluded([AddAsMember] HTEST2 hTest);
	
					/// <summary>Determines if a test is active.</summary>
					/// <param name="hTest">The test handle.</param>
					/// <param name="flag">The flag.</param>
					/// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
					[DllImport("test32.dll", SetLastError = true)]
					public static extern bool IsActive<T>([AddAsMember] HTEST hTest, T t, [Optional, Ignore] uint flag) where T : struct;

					/// <summary>Gets a test name.</summary>
					/// <param name="hTest">The test handle.</param>
					/// <param name="ptr">The pointer to the name buffer.</param>
					/// <param name="sz">The size of the name buffer.</param>
					/// <param name="name">The name.</param>
					/// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
					[DllImport("test32.dll", SetLastError = true)]
					public static extern bool GetName([AddAsMember] HTEST hTest, [In, Optional, SizeDef(nameof(sz))] IntPtr ptr, uint sz, out string? name);

					/// <summary>Sets a test name.</summary>
					/// <param name="hTest">The test handle.</param>
					/// <param name="name">The name.</param>
					/// <param name="code">The code.</param>
					/// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
					[DllImport("test32.dll", SetLastError = true)]
					public static extern bool SetName([AddAsMember] HTEST hTest, string? name, [Ignore] uint code = 0);

					/// <summary>Creates a test.</summary>
					/// <param name="name">The name.</param>
					/// <param name="code">The code.</param>
					/// <param name="test">The test handle.</param>
					/// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
					[DllImport("test32.dll", SetLastError = true)]
					public static extern bool CreateTest(string? name, [Optional][Ignore] uint code, [AddAsCtor] out SafeHTEST test);
				}
			}
			""";
		var compilation = GetCompilation(src);
		CreateGeneratorDriverAndRun(compilation, new VanaraAttributeGenerator(), null, out var output, out var diag);
		Assert.That(output.SyntaxTrees, Has.Exactly(2).Items);
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error), Has.Exactly(1).Items);
		WriteTrees(TestContext.Out, output.SyntaxTrees, false);
	}

	[Test]
	public void AutoHandleTest()
	{
		const string src = /* lang=c#-test */ """
			namespace Vanara.PInvoke
			{
				public static partial class Test32
				{
					/// <summary>Handle to a test.</summary>
					[Vanara.PInvoke.AutoHandleAttribute(typeof(Vanara.PInvoke.IGdiObjectHandle), typeof(HGDIOBJ))]
					public partial struct HPEN { }

					/// <summary>Handle to a sample.</summary>
					[Vanara.PInvoke.AutoHandleAttribute]
					public partial struct HSAMPLE
					{
						/// <summary>Get the integer value.</summary>
						public int Value => handle.ToInt32();
					}
				}
			}
			""";
		var compilation = GetCompilation(src);
		CreateGeneratorDriverAndRun(compilation, new AutoHandleGenerator(), null, out var output, out var diag);

		Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(3));
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error), Is.Empty);

		WriteTrees(TestContext.Out, output.SyntaxTrees, false);
	}

	[Test]
	public void AutoSafeHandleTest()
	{
		const string src = /* lang=c#-test */ """
			namespace Vanara.PInvoke
			{
				public static partial class Test32
				{
					/// <summary>Handle to a test.</summary>
					[Vanara.PInvoke.AutoSafeHandleAttribute("CloseTest(handle)", typeof(HTEST), typeof(Vanara.PInvoke.SafeHandleV), typeof(HANDLE))]
					public partial class SafeHTEST { }

					/// <summary>Handle to a sample.</summary>
					[Vanara.PInvoke.AutoSafeHandleAttribute(null, typeof(HSAMPLE))]
					public partial class SafeHSAMPLE
					{
						/// <summary>Get the integer value.</summary>
						public int Value => handle.ToInt32();
					}
				}
			}
			""";
		var compilation = GetCompilation(src);
		CreateGeneratorDriverAndRun(compilation, new AutoSafeHandleGenerator(), null, out var output, out var diag);

		Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(3));
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error), Is.Empty);

		WriteTrees(TestContext.Out, output.SyntaxTrees, false);
	}

	[Test]
	public void HandlesFromFileTest()
	{
		var compilation = GetCompilation(@"// comment");
		CreateGeneratorDriverAndRun(compilation, new HandlesFromFileGenerator(), "handles.csv", out var output, out var diag);

		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error), Is.Empty);

		WriteTrees(TestContext.Out, output.SyntaxTrees);
	}

	[TestCase("handlesbad1.csv", "VANGEN001")]
	[TestCase("handlesbad2.csv", "VANGEN002")]
	[TestCase("handlesbad3.csv", "VANGEN003")]
	[TestCase("handlesbad4.csv", "VANGEN003")]
	public void HandlesFromBadFileTest(string fn, string errId)
	{
		var compilation = GetCompilation(@"// comment");
		CreateGeneratorDriverAndRun(compilation, new HandlesFromFileGenerator(), fn, out var output, out var diag);
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error), Is.Not.Empty);
		Assert.That(diag[0].Id, Is.EqualTo(errId));
	}

	[Test]
	public void IUnkMethodGenTest()
	{
		const string src = /* lang=c#-test */ """
			using System;
			using System.Runtime.InteropServices;
			using static System.Runtime.InteropServices.RuntimeInformation;
			using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
			namespace Vanara.PInvoke
			{
				public interface IUnkHolderIgnore
				{
					[PreserveSig]
					HRESULT Ignore(object? p1, in System.Guid p2, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3);
				}

				/// <summary>A 32-bit test dll</summary>
				public static partial class Test32
				{
					[MarshalAs(UnmanagedType.Bool)]
					public static readonly bool field1;

					public interface IUnkHolder
					{
						/// <summary>Gets the object.</summary>
						/// <param name="p1">The p1.</param>
						/// <param name="p2">The p2.</param>
						/// <param name="p3">The p3.</param>
						/// <param name="p4">The p4.</param>
						/// <param name="p5">The p5.</param>
						/// <returns>The ret.</returns>
						[PreserveSig]
						HRESULT GetObj([Optional, Ignore] object? p1, in System.Guid p2, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3, ref NativeOverlapped p4, [Optional, Ignore] out long p5);
					}

					public interface IUnkHolder2 : IUnkHolder
					{
						/// <summary>Gets the object.</summary>
						/// <param name="p1">The p1.</param>
						/// <param name="p2">The p2.</param>
						/// <param name="p3">The p3.</param>
						/// <param name="p4">The p4.</param>
						/// <param name="p5">The p5.</param>
						/// <returns>The ret.</returns>
						[PreserveSig]
						new HRESULT GetObj([Optional, Ignore] object? p1, in System.Guid p2, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3, ref NativeOverlapped p4, [Optional, Ignore] out long p5);

						/// <summary>Gets the obj2.</summary>
						/// <param name="p1">The p1.</param>
						/// <param name="p2">The p2.</param>
						/// <param name="p3">The p3.</param>
						void GetObj2(float p1, [MarshalAs(UnmanagedType.Struct)] Guid p2, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3);

						HRESULT Ignore1(object? p1, in System.Guid p2, [MarshalAs(UnmanagedType.IUnknown)] object? p3);
						HRESULT Ignore2(object? p1, in System.Guid p2, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? p3);
						HRESULT Ignore3([MarshalAs(UnmanagedType.LPArray)] int[] p3);
						[SuppressAutoGen]
						void Ignore4(float p1, in System.Guid p2, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3);
					}
				}

				/// <summary>A 64-bit test dll</summary>
				public static partial class Test64
				{
					/// <summary>Gets the object.</summary>
					/// <param name="p1">The p1.</param>
					/// <param name="p2">The p2.</param>
					/// <param name="p3">The p3.</param>
					/// <returns>The ret.</returns>
					[DllImport("test32.dll")]
					public static extern HRESULT F1SetObj(object? p1, in System.Guid p2, [In, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] object p3);
				}
			}
			""";

		const string src2 = /* lang=c#-test */ """
			using System;
			using System.Runtime.InteropServices;
			namespace Vanara.PInvoke
			{
				public static partial class Test64
				{
					/// <summary>Gets the object.</summary>
					/// <param name="p1">The p1.</param>
					/// <param name="p2">The p2.</param>
					/// <param name="p3">The p3.</param>
					/// <returns>The ret.</returns>
					[DllImport("test32.dll")]
					public static extern HRESULT F2GetObj(object? p1, in System.Guid p2, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3);
				}
			}
			""";

		var compilation = GetCompilation(src, src2);
		CreateGeneratorDriverAndRun(compilation, new VanaraAttributeGenerator(), null, out var output, out var diag);
		WriteTrees(TestContext.Out, output.SyntaxTrees);
		Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(4));
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error).Count(), Is.EqualTo(1));
	}

	const string sizeDefCount = /* lang=c#-test */ """
		// sizeDefCount
		using System;
		using System.Runtime.InteropServices;
		using System.ComponentModel.DataAnnotations;
		namespace Vanara.PInvoke
		{
			/// <summary>A 64-bit test dll</summary>
			public static partial class Test64
			{
				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef01([SizeDef("p2")] StringBuilder? p1, [Range(0, 50)] int p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef02([SizeDef("p2", SizingMethod.Count)] StringBuilder? p1, int p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef03([SizeDef(50)] StringBuilder? p1);
			}
		}
		""";

	const string sizeDefBytes = /* lang=c#-test */ """
		// sizeDefBytes
		using System;
		using System.Runtime.InteropServices;
		using System.ComponentModel.DataAnnotations;
		namespace Vanara.PInvoke
		{
			/// <summary>A 64-bit test dll</summary>
			public static partial class Test64
			{
				private const int MAX_SIZE = 200;

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Ansi)]
				public static extern Win32Error GoodSizeDef01([SizeDef("p2", SizingMethod.Bytes)] StringBuilder? p1, [Range(0, 50)] int p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef02([SizeDef("p2", SizingMethod.Bytes)] StringBuilder? p1, [Range(0, MAX_SIZE)] uint p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Ansi)]
				public static extern int GoodSizeDef03([MarshalAs(UnmanagedType.LPWStr), SizeDef("p2", SizingMethod.Bytes)] StringBuilder? p1, SizeT p2);
			}
		}
		""";

	const string sizeDefNullTerm = /* lang=c#-test */ """
		// sizeDefNullTerm
		using System;
		using System.Runtime.InteropServices;
		using System.ComponentModel.DataAnnotations;
		namespace Vanara.PInvoke
		{
			/// <summary>A 64-bit test dll</summary>
			public static partial class Test64
			{
				private const int MAX_SIZE = 200;

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Ansi)]
				public static extern Win32Error GoodSizeDef01([SizeDef("p2", SizingMethod.InclNullTerm)] StringBuilder? p1, [Range(0, 50)] int p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef02([SizeDef("p2", SizingMethod.InclNullTerm)] StringBuilder? p1, [Range(0, MAX_SIZE)] uint p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Ansi)]
				public static extern int GoodSizeDef03([MarshalAs(UnmanagedType.LPWStr), SizeDef("p2", SizingMethod.InclNullTerm)] StringBuilder? p1, SizeT p2);
			}
		}
		""";

	const string sizeDefQuery = /* lang=c#-test */ """
		// sizeDefQuery
		using System;
		using System.Runtime.InteropServices;
		using System.ComponentModel.DataAnnotations;
		namespace Vanara.PInvoke
		{
			/// <summary>A 64-bit test dll</summary>
			public static partial class Test64
			{
				private const int MAX_SIZE = 200;

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true)]
				public static extern Win32Error GoodSizeDef01([SizeDef("p2", SizingMethod.Query)] StringBuilder? p1, [Range(0, 50)] ref int p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef02([SizeDef("p2", SizingMethod.Query)] StringBuilder? p1, [Range(0, MAX_SIZE)] ref uint p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Ansi)]
				public static extern int GoodSizeDef03([MarshalAs(UnmanagedType.LPWStr), SizeDef("p2", SizingMethod.Query)] StringBuilder? p1, ref SizeT p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Ansi)]
				public static extern int GoodSizeDef04([MarshalAs(UnmanagedType.LPWStr), SizeDef("p2", SizingMethod.QueryResultInReturn)] StringBuilder? p1, int p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Ansi)]
				public static extern Win32Error GoodSizeDef05([MarshalAs(UnmanagedType.LPWStr), SizeDef("p2", SizingMethod.CheckLastError)] StringBuilder? p1, ref int p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Ansi)]
				public static extern int GoodSizeDef06([MarshalAs(UnmanagedType.LPWStr), SizeDef("p2", SizingMethod.CheckLastError)] StringBuilder? p1, ref int p2);
			}
		}
		""";

	[TestCase(sizeDefCount, 2, 0)]
	[TestCase(sizeDefBytes, 2, 0)]
	[TestCase(sizeDefNullTerm, 2, 0)]
	[TestCase(sizeDefQuery, 2, 0)]
	public void SizeDefGenTest(string src, int treeCount, int errCount)
	{
		var compilation = GetCompilation(src);
		CreateGeneratorDriverAndRun(compilation, new VanaraAttributeGenerator(), null, out var output, out var diag);
		WriteTrees(TestContext.Out, output.SyntaxTrees);
		Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(treeCount));
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error).Count(), Is.EqualTo(errCount));
	}

	private static void CreateGeneratorDriverAndRun(CSharpCompilation compilation, IIncrementalGenerator sourceGenerator, string? additionalFile, out Compilation output, out System.Collections.Immutable.ImmutableArray<Diagnostic> diag) =>
		CSharpGeneratorDriver.Create(
			generators: [sourceGenerator.AsSourceGenerator()],
			additionalTexts: additionalFile is not null ? [new InMemoryAdditionalText("handles.csv", File.ReadAllText(additionalFile))] : [],
			driverOptions: new GeneratorDriverOptions(default, trackIncrementalGeneratorSteps: true)).
		RunGeneratorsAndUpdateCompilation(compilation, out output, out diag);

	private static readonly string VanaraCoreRef = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Documents\GitHubRepos\Vanara\Core\bin\Debug\netstandard2.0\Vanara.Core.dll";

	private static readonly List<MetadataReference> metaRefs =
		[.. AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic).Select(a => MetadataReference.CreateFromFile(a.Location)).Cast<MetadataReference>().Concat([MetadataReference.CreateFromFile(VanaraCoreRef)])];

	private static CSharpCompilation GetCompilation(params string[] sourceCode) => CSharpCompilation.Create(nameof(CodeGenTests),
		Array.ConvertAll(sourceCode, i => CSharpSyntaxTree.ParseText(i)), metaRefs, new(OutputKind.DynamicallyLinkedLibrary));

	private static void WriteTrees(TextWriter tw, IEnumerable<SyntaxTree> trees, bool skipFirst = true)
	{
		foreach (var tree in trees.Skip(skipFirst ? 1 : 0))
		{
			var fn = Path.GetFileName(tree.FilePath);
			tw.WriteLine($"== {fn} {new string('=', 78 - fn.Length)}");
			tw.WriteLine(tree);
		}
	}
}

internal class InMemoryAdditionalText(string path, string content) : AdditionalText
{
	private readonly SourceText _content = SourceText.From(content, Encoding.UTF8);
	public override string Path { get; } = path;
	public override SourceText GetText(CancellationToken cancellationToken = default) => _content;
}