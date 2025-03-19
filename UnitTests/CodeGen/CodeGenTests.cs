using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.IO;
using System.Linq;
using System.Threading;
using Vanara.Generators;

//namespace Vanara.PInvoke
//{
//	public static partial class Test32
//	{
//		/// <summary>Handle to a test.</summary>
//		[Vanara.PInvoke.AutoHandleAttribute(typeof(Vanara.PInvoke.IHandle))]
//		public partial struct HTEST { }

//		/// <summary>Handle to a sample.</summary>
//		[Vanara.PInvoke.AutoHandleAttribute]
//		public partial struct HSAMPLE
//		{
//			/// <summary>Get the integer value.</summary>
//			public int Value => handle.ToInt32();
//		}
//	}
//}

//namespace Vanara.PInvoke
//{
//	public static partial class Test32
//	{
//		/// <summary>Handle to a test.</summary>
//		[Vanara.PInvoke.AutoSafeHandleAttribute("CloseTest(handle)", typeof(HTEST), typeof(Vanara.PInvoke.SafeHANDLE), typeof(HANDLE))]
//		public partial class SafeHTEST { }

//		/// <summary>Handle to a sample.</summary>
//		[Vanara.PInvoke.AutoSafeHandleAttribute(null, typeof(HSAMPLE))]
//		public partial class SafeHSAMPLE
//		{
//			/// <summary>Get the integer value.</summary>
//			public int Value => handle.ToInt32();
//		}
//	}
//}

//namespace Vanara.PInvoke
//{
//	public interface IUnkHolderIgnore
//	{
//		HRESULT GetObj(object? p1, in System.Guid p2, [System.Runtime.InteropServices.MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] object? p3);
//	}
//	public static partial class Test32
//	{
//		[System.Runtime.InteropServices.MarshalAs(UnmanagedType.Bool)]
//		public static bool field1;

//		public interface IUnkHolder
//		{
//			HRESULT GetObj(object? p1, in System.Guid p2, [System.Runtime.InteropServices.MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] object? p3);
//			HRESULT Ignore1(object? p1, in System.Guid p2, [System.Runtime.InteropServices.MarshalAs(UnmanagedType.IUnknown)] object? p3);
//			HRESULT Ignore2([System.Runtime.InteropServices.MarshalAs(UnmanagedType.LPArray)] int[] p3);
//		}

//		[System.Runtime.InteropServices.DllImport("test32.dll")]
//		public static extern HRESULT GetObj(object? p1, in System.Guid p2, [System.Runtime.InteropServices.MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] object? p3);
//	}
//}

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class CodeGenTests
	{
		[Test]
		public void AutoHandleTest()
		{
			const string src = """
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

			TestContext.WriteLine(string.Join($"\n{new string('=', 80)}\n", output.SyntaxTrees));
		}

		[Test]
		public void AutoSafeHandleTest()
		{
			const string src = """
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

			TestContext.WriteLine(string.Join($"\n{new string('=', 80)}\n", output.SyntaxTrees));
		}

		[Test]
		public void HandlesFromFileTest()
		{
			var compilation = GetCompilation(@"// comment");
			CreateGeneratorDriverAndRun(compilation, new HandlesFromFileGenerator(), "handles.csv", out var output, out var diag);

			Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error), Is.Empty);

			TestContext.WriteLine(string.Join($"\n{new string('=', 80)}\n", output.SyntaxTrees.Skip(1)));
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
			const string src = @"
				namespace Vanara.PInvoke
				{
					public interface IUnkHolderIgnore
					{
						//HRESULT GetObj(object? p1, in System.Guid p2, [System.Runtime.InteropServices.MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] object? p3);
					}
					public static partial class Test32
					{
						//[System.Runtime.InteropServices.MarshalAs(UnmanagedType.Bool)]
						//public static bool field1;

						public interface IUnkHolder
						{
							HRESULT GetObj(object? p1, in System.Guid p2, [System.Runtime.InteropServices.MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] object? p3);
							//HRESULT Ignore1(object? p1, in System.Guid p2, [System.Runtime.InteropServices.MarshalAs(UnmanagedType.IUnknown)] object? p3);
							//HRESULT Ignore2([System.Runtime.InteropServices.MarshalAs(UnmanagedType.LPArray)] int[] p3);
						}

						[System.Runtime.InteropServices.DllImport(""test32.dll"")]
						public static extern HRESULT GetObj(object? p1, in System.Guid p2, [System.Runtime.InteropServices.MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] object? p3);
					}
				}
			";
			var compilation = GetCompilation(src);
			//CreateGeneratorDriverAndRun(compilation, new IUnkMethodGenerator(), null, out var output, out var diag);
			//Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(2));
			//Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error), Is.Empty);
			//TestContext.WriteLine(string.Join($"\n{new string('=', 80)}\n", output.SyntaxTrees.Skip(1)));
		}

		private static void CreateGeneratorDriverAndRun(CSharpCompilation compilation, IIncrementalGenerator sourceGenerator, string? additionalFile, out Compilation output, out System.Collections.Immutable.ImmutableArray<Diagnostic> diag) =>
			CSharpGeneratorDriver.Create(
				generators: [sourceGenerator.AsSourceGenerator()],
				additionalTexts: additionalFile is not null ? [new InMemoryAdditionalText("handles.csv", File.ReadAllText(additionalFile))] : [],
				driverOptions: new GeneratorDriverOptions(default, trackIncrementalGeneratorSteps: true)).
			RunGeneratorsAndUpdateCompilation(compilation, out output, out diag);

		private static CSharpCompilation GetCompilation(string sourceCode) => CSharpCompilation.Create(nameof(CodeGenTests),
			[CSharpSyntaxTree.ParseText(sourceCode)],
			AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic).Select(a => MetadataReference.CreateFromFile(a.Location)).Cast<MetadataReference>(),
			new(OutputKind.DynamicallyLinkedLibrary));
	}

	internal class InMemoryAdditionalText(string path, string content) : AdditionalText
	{
		private readonly SourceText _content = SourceText.From(content, Encoding.UTF8);
		public override string Path { get; } = path;
		public override SourceText GetText(CancellationToken cancellationToken = default) => _content;
	}
}