using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Collections.Immutable;
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
					[AutoSafeHandleAttribute("CloseHandle(handle)", typeof(HANDLE))]
					public partial class SafeHACCEL { }
			
					[AutoSafeHandleAttribute("CloseHandle(handle)")]
					public partial class SafeHTEST3 { }
			
					[DllImport("test32.dll", SetLastError = true)]
					public static extern bool CheckInst([AddAsMember] HANDLE hInst);
			
					[DllImport("test32.dll", SetLastError = true)]
					public static extern bool IsTestExcluded(int code, [AddAsMember] HTEST hTest);
	
					[DllImport("test32.dll", SetLastError = true)]
					public static extern bool FreeTest(HTEST hTest);
	
					/// <summary>Determines if a test is active.</summary>
					/// <param name="hTest">The test handle.</param>
					/// <param name="flag">The flag.</param>
					/// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
					[DllImport("test32.dll", SetLastError = true)]
					public static extern bool IsTestActive<T>([AddAsMember] HTEST hTest, T t, [Optional, Ignore] uint flag) where T : struct;

					/// <summary>Gets a test name.</summary>
					/// <param name="hTest">The test handle.</param>
					/// <param name="ptr">The pointer to the name buffer.</param>
					/// <param name="sz">The size of the name buffer.</param>
					/// <param name="name">The name.</param>
					/// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
					[DllImport("test32.dll", SetLastError = true)]
					public static extern bool GetTestName([AddAsMember] HTEST hTest, [In, Optional, SizeDef(nameof(sz))] IntPtr ptr, uint sz, out string? name);

					/// <summary>Sets a test name.</summary>
					/// <param name="hTest">The test handle.</param>
					/// <param name="name">The name.</param>
					/// <param name="code">The code.</param>
					/// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
					[DllImport("test32.dll", SetLastError = true)]
					public static extern bool SetTestName([AddAsMember] HTEST hTest, string? name, [Ignore] uint code = 0);

					/// <summary>Sets a test name.</summary>
					/// <param name="hTest">The test handle.</param>
					/// <param name="name">The name.</param>
					/// <param name="code">The code.</param>
					/// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
					[DllImport("test32.dll", SetLastError = true)]
					public static extern bool SetTest3Name([AddAsMember] SafeHTEST3 hTest, string? name, [Ignore] uint code = 0);

					/// <summary>Creates a test.</summary>
					/// <param name="name">The name.</param>
					/// <param name="code">The code.</param>
					/// <param name="test">The test handle.</param>
					/// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
					[DllImport("test32.dll", SetLastError = true)]
					public static extern bool CreateTest(string? name, [Optional][Ignore] uint code, [AddAsCtor] out SafeHTEST test);

					/// <summary>Creates a test.</summary>
					/// <param name="id">The id.</param>
					/// <returns>The handle</returns>
					[DllImport("test32.dll", SetLastError = true)]
					[return: AddAsCtor]
					public static extern SafeHTEST CreateTestEx(int id);
				}
			}
			""";

		const string expoutput = /* lang=c#-test */ """
			public partial struct HTEST
			{
				public bool IsTestExcluded(int code)
				{
					var ret = IsTestExcluded(code, handle);
					return ret;
				}
	
				/// <summary>Determines if a test is active.</summary>
				/// <param name="t">The value.</param>
				/// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
				public bool IsTestActive<T>(T t) where T : struct
				{
					var ret = IsTestActive<T>(handle, t, default);
					return ret;
				}

				/// <summary>Gets a test name.</summary>
				/// <param name="ptr">The pointer to the name buffer.</param>
				/// <param name="name">The name.</param>
				/// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
				public bool GetTestName(SafeAllocatedMemoryHandle? ptr, out string? name)
				{
					var ret = GetTestName(ptr ?? IntPtr.Zero, ptr?.Size ?? 0, out name);
					return ret;
				}

				/// <summary>Sets a test name.</summary>
				/// <param name="name">The name.</param>
				/// <returns><see langword="true"/> on success, <see langword="false"/> on failure.</returns>
				public bool SetTestName(string? name)
				{
					var ret = SetTestName(handle, name, default);
					return ret;
				}
			}

			public partial struct SafeHTEST
			{
				/// <summary>Creates a test.</summary>
				/// <param name="name">The name.</param>
				/// <returns>The test handle.</returns>
				// bool CreateTest(string? name, [Optional][Ignore] uint code, [AddAsCtor] out SafeHTEST test);			
				public static SafeHTEST Create(string? name)
				{
					var ret = CreateTest(name, default, out var test);
					THROW_IF_FAILED(test, false)
					return test;
				}

				/// <summary>Creates a test.</summary>
				/// <param name="id">The id.</param>
				/// <returns>The test handle.</returns>
				// [return: AddAsCtor] SafeHTEST CreateTestEx(int id);
				public static SafeHTEST Create(int id)
				{
					var ret = CreateTestEx(id);
					THROW_IF_FAILED(ret, false);
					return ret;
				}d
			}
			""";
		var compilation = GetCompilation(src);
		CreateGeneratorDriverAndRun(compilation, new VanaraAttributeGenerator(), "handles.csv", out var output, out var diag);
		WriteTrees(TestContext.Out, output.SyntaxTrees);
		WriteDiags(diag);
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error).Count(), Is.EqualTo(0));
		Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(4));
	}

	private static void WriteDiags(ImmutableArray<Diagnostic> diag, DiagnosticSeverity sev = DiagnosticSeverity.Error)
	{
		foreach (var d in diag.Where(d => d.Severity == sev))
			TestContext.Out.WriteLine($"{d.Severity} {d.Id}: {d.GetMessage()} @ {d.Location.SourceSpan}");
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
		Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(7));
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
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error).Count(), Is.EqualTo(0));
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

/*public partial class SafeHINSTANCE
{
	/// <summary>
	/// Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.
	/// </summary>
	/// <param name="lpFileName">
	/// <para>
	/// A string that specifies the file name of the module to load. This name is not related to the name stored in a library module
	/// itself, as specified by the <c>LIBRARY</c> keyword in the module-definition (.def) file.
	/// </para>
	/// <para>
	/// The module can be a library module (a .dll file) or an executable module (an .exe file). If the specified module is an executable
	/// module, static imports are not loaded; instead, the module is loaded as if <c>DONT_RESOLVE_DLL_REFERENCES</c> was specified. See
	/// the dwFlags parameter for more information.
	/// </para>
	/// <para>
	/// If the string specifies a module name without a path and the file name extension is omitted, the function appends the default
	/// library extension .dll to the module name. To prevent the function from appending .dll to the module name, include a trailing
	/// point character (.) in the module name string.
	/// </para>
	/// <para>
	/// If the string specifies a fully qualified path, the function searches only that path for the module. When specifying a path, be
	/// sure to use backslashes (\), not forward slashes (/). For more information about paths, see Naming Files, Paths, and Namespaces.
	/// </para>
	/// <para>
	/// If the string specifies a module name without a path and more than one loaded module has the same base name and extension, the
	/// function returns a handle to the module that was loaded first.
	/// </para>
	/// <para>
	/// If the string specifies a module name without a path and a module of the same name is not already loaded, or if the string
	/// specifies a module name with a relative path, the function searches for the specified module. The function also searches for
	/// modules if loading the specified module causes the system to load other associated modules (that is, if the module has
	/// dependencies). The directories that are searched and the order in which they are searched depend on the specified path and the
	/// dwFlags parameter. For more information, see Remarks.
	/// </para>
	/// <para>If the function cannot find the module or one of its dependencies, the function fails.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// The action to be taken when loading the module. If no flags are specified, the behavior of this function is identical to that of
	/// the <c>LoadLibrary</c> function. This parameter can be one of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DONT_RESOLVE_DLL_REFERENCES0x00000001</term>
	/// <term>
	/// If this value is used, and the executable module is a DLL, the system does not call DllMain for process and thread initialization
	/// and termination. Also, the system does not load additional executable modules that are referenced by the specified module.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_IGNORE_CODE_AUTHZ_LEVEL0x00000010</term>
	/// <term>
	/// If this value is used, the system does not check AppLocker rules or apply Software Restriction Policies for the DLL. This action
	/// applies only to the DLL being loaded and not to its dependencies. This value is recommended for use in setup programs that must
	/// run extracted DLLs during installation.Windows Server 2008 R2 and Windows 7: On systems with KB2532445 installed, the caller must
	/// be running as &amp;quot;LocalSystem&amp;quot; or &amp;quot;TrustedInstaller&amp;quot;; otherwise the system ignores this flag.
	/// For more information, see &amp;quot;You can circumvent AppLocker rules by using an Office macro on a computer that is running
	/// Windows 7 or Windows Server 2008 R2&amp;quot; in the Help and Support Knowledge Base at
	/// http://support.microsoft.com/kb/2532445.Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: AppLocker was
	/// introduced in Windows 7 and Windows Server 2008 R2.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_AS_DATAFILE0x00000002</term>
	/// <term>
	/// If this value is used, the system maps the file into the calling process's virtual address space as if it were a data file.
	/// Nothing is done to execute or prepare to execute the mapped file. Therefore, you cannot call functions like GetModuleFileName,
	/// GetModuleHandle or GetProcAddress with this DLL. Using this value causes writes to read-only memory to raise an access violation.
	/// Use this flag when you want to load a DLL only to extract messages or resources from it.This value can be used with
	/// LOAD_LIBRARY_AS_IMAGE_RESOURCE. For more information, see Remarks.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE0x00000040</term>
	/// <term>
	/// Similar to LOAD_LIBRARY_AS_DATAFILE, except that the DLL file is opened with exclusive write access for the calling process.
	/// Other processes cannot open the DLL file for write access while it is in use. However, the DLL can still be opened by other
	/// processes.This value can be used with LOAD_LIBRARY_AS_IMAGE_RESOURCE. For more information, see Remarks.Windows Server 2003 and
	/// Windows XP: This value is not supported until Windows Vista.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_AS_IMAGE_RESOURCE0x00000020</term>
	/// <term>
	/// If this value is used, the system maps the file into the process's virtual address space as an image file. However, the loader
	/// does not load the static imports or perform the other usual initialization steps. Use this flag when you want to load a DLL only
	/// to extract messages or resources from it.Unless the application depends on the file having the in-memory layout of an image, this
	/// value should be used with either LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE or LOAD_LIBRARY_AS_DATAFILE. For more information, see the
	/// Remarks section.Windows Server 2003 and Windows XP: This value is not supported until Windows Vista.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_APPLICATION_DIR0x00000200</term>
	/// <term>
	/// If this value is used, the application's installation directory is searched for the DLL and its dependencies. Directories in the
	/// standard search path are not searched. This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.Windows 7, Windows Server
	/// 2008 R2, Windows Vista and Windows Server 2008: This value requires KB2533623 to be installed.Windows Server 2003 and Windows XP:
	/// This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_DEFAULT_DIRS0x00001000</term>
	/// <term>
	/// This value is a combination of LOAD_LIBRARY_SEARCH_APPLICATION_DIR, LOAD_LIBRARY_SEARCH_SYSTEM32, and
	/// LOAD_LIBRARY_SEARCH_USER_DIRS. Directories in the standard search path are not searched. This value cannot be combined with
	/// LOAD_WITH_ALTERED_SEARCH_PATH.This value represents the recommended maximum number of directories an application should include
	/// in its DLL search path.Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server 2008: This value requires KB2533623 to
	/// be installed.Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR0x00000100</term>
	/// <term>
	/// If this value is used, the directory that contains the DLL is temporarily added to the beginning of the list of directories that
	/// are searched for the DLL's dependencies. Directories in the standard search path are not searched.The lpFileName parameter must
	/// specify a fully qualified path. This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.For example, if Lib2.dll is a
	/// dependency of C:\Dir1\Lib1.dll, loading Lib1.dll with this value causes the system to search for Lib2.dll only in C:\Dir1. To
	/// search for Lib2.dll in C:\Dir1 and all of the directories in the DLL search path, combine this value with
	/// LOAD_LIBRARY_DEFAULT_DIRS.Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server 2008: This value requires KB2533623
	/// to be installed.Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_SYSTEM320x00000800</term>
	/// <term>
	/// If this value is used, %windows%\system32 is searched for the DLL and its dependencies. Directories in the standard search path
	/// are not searched. This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.Windows 7, Windows Server 2008 R2, Windows
	/// Vista and Windows Server 2008: This value requires KB2533623 to be installed.Windows Server 2003 and Windows XP: This value is
	/// not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_LIBRARY_SEARCH_USER_DIRS0x00000400</term>
	/// <term>
	/// If this value is used, directories added using the AddDllDirectory or the SetDllDirectory function are searched for the DLL and
	/// its dependencies. If more than one directory has been added, the order in which the directories are searched is unspecified.
	/// Directories in the standard search path are not searched. This value cannot be combined with
	/// LOAD_WITH_ALTERED_SEARCH_PATH.Windows 7, Windows Server 2008 R2, Windows Vista and Windows Server
	/// 2008: This value requires KB2533623 to be installed.Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LOAD_WITH_ALTERED_SEARCH_PATH0x00000008</term>
	/// <term>
	/// If this value is used and lpFileName specifies an absolute path, the system uses the alternate file search strategy discussed in
	/// the Remarks section to find associated executable modules that the specified module causes to be loaded. If this value is used
	/// and lpFileName specifies a relative path, the behavior is undefined.If this value is not used, or if lpFileName does not specify
	/// a path, the system uses the standard search strategy discussed in the Remarks section to find associated executable modules that
	/// the specified module causes to be loaded.This value cannot be combined with any LOAD_LIBRARY_SEARCH flag.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	public SafeHINSTANCE(string lpFileName, LoadLibraryExFlags dwFlags = 0) => LoadLibraryEx(lpFileName, default, dwFlags);

	/// <summary>
	/// Retrieves a module handle for the specified module and increments the module's reference count unless
	/// GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT is specified. The module must have been loaded by the calling process.
	/// </summary>
	/// <param name="dwFlags">
	/// This parameter can be zero or one or more of the following values. If the module's reference count is incremented, the caller
	/// must use the <c>FreeLibrary</c> function to decrement the reference count when the module handle is no longer needed.
	/// </param>
	/// <param name="lpModuleName">
	/// <para>The name of the loaded module (either a .dll or .exe file), or an address in the module (if dwFlags is GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS).</para>
	/// <para>
	/// For a module name, if the file name extension is omitted, the default library extension .dll is appended. The file name string
	/// can include a trailing point character (.) to indicate that the module name has no extension. The string does not have to specify
	/// a path. When specifying a path, be sure to use backslashes (\), not forward slashes (/). The name is compared (case
	/// independently) to the names of modules currently mapped into the address space of the calling process.
	/// </para>
	/// <para>If this parameter is NULL, the function returns a handle to the file used to create the calling process (.exe file).</para>
	/// </param>
	public SafeHINSTANCE(GET_MODULE_HANDLE_EX_FLAG dwFlags, [Optional] string? lpModuleName) : base(IntPtr.Zero, true)
	{
		var ret = GetModuleHandleEx(dwFlags, lpModuleName, out SafeHINSTANCE phModule);
		if (FailedHelper.FAILED(ret))
			throw Win32Error.GetExceptionForLastError()!;
		SetHandle(phModule.ReleaseOwnership());
	}

	/// <summary>
	/// Disables the DLL_THREAD_ATTACH and DLL_THREAD_DETACH notifications for the specified dynamic-link library (DLL). This can reduce
	/// the size of the working set for some applications.
	/// </summary>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. The <c>DisableThreadLibraryCalls</c> function fails if the DLL specified by
	/// hModule has active static thread local storage, or if hModule is an invalid module handle. To get extended error information,
	/// call <c>GetLastError</c>.
	/// </para>
	/// </returns>
	public bool DisableThreadCalls() => DisableThreadLibraryCalls(handle);
}*/