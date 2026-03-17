using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Immutable;
using Vanara.Generators;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public partial class CodeGenTests
{
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

		var compilation = GetCompilation(src);
		CreateGeneratorDriverAndRun(compilation, new VanaraAttributeGenerator(), "handles.csv", out var output, out var diag);
		CodeAnalysisHelpers.WriteTrees(TestContext.Out, output.SyntaxTrees);
		CodeAnalysisHelpers.WriteDiags(diag);
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error).Count(), Is.EqualTo(0));
		Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(4));
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
		CodeAnalysisHelpers.
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
		CodeAnalysisHelpers.
				WriteTrees(TestContext.Out, output.SyntaxTrees, false);
	}

	[Test]
	public void HandlesFromFileTest()
	{
		var compilation = GetCompilation(@"// comment");
		CreateGeneratorDriverAndRun(compilation, new HandlesFromFileGenerator(), "handles.csv", out var output, out var diag);
		Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(7));
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error), Is.Empty);
		CodeAnalysisHelpers.WriteTrees(TestContext.Out, output.SyntaxTrees);
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

					[DllImport("test32.dll")]
					private static extern HRESULT IgnoreAsPrivate(object? p1, in System.Guid p2, [In, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] object p3);

					[DllImport("test32.dll")]
					public static unsafe extern HRESULT IgnoreAsUnsafe(object? p1, System.Guid* p2, [In, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] object p3);
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
		CodeAnalysisHelpers.WriteTrees(TestContext.Out, output.SyntaxTrees);
		CodeAnalysisHelpers.WriteDiags(diag);
		Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(4));
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error).Count(), Is.EqualTo(0));
	}

	const string marshalArrBad = /* lang=c#-test */ """
		// marshalArrBad
		using System;
		using System.Runtime.InteropServices;
		using Vanara.InteropServices;
		namespace Vanara.PInvoke
		{
			public static partial class Test64
			{
				public static extern bool Method(uint cToBeHashed, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] rgpbToBeHashed);
			}
		}
		""";

	const string marshalArrMult = /* lang=c#-test */ """
		// marshalArrMult
		using System;
		using System.Runtime.InteropServices;
		using Vanara.InteropServices;
		namespace Vanara.PInvoke
		{
			public static partial class Test64
			{
				public static extern bool CryptHashMessage(bool fDetachedHash, uint cToBeHashed, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] rgpbToBeHashed,
					[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] rgcbToBeHashed);
				public static extern bool AccessCheckByTypeResultList([In, Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] OBJECT_TYPE_LIST[]? ObjectTypeList, uint ObjectTypeListLength,
					[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ACCESS_MASK[] GrantedAccessList, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] AccessStatusList);
				public static extern bool GetResourceAllocationInfo1([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] RECT[]? ObjectTypeList, int ObjectTypeListLength,
					[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? GrantedAccessList, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] AccessStatusList);
				public static extern bool Method([SizeDef(nameof(cbLen))] string psz, uint cbLen, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] outList);
			}
		}
		""";

	[TestCase(marshalArrMult, 2, 0)]
	[TestCase(marshalArrBad, 1, 1)]
	public void MarshalAsLPArrayTest(string src, int treeCount, int errCount)
	{
		var compilation = GetCompilation(src);
		CreateGeneratorDriverAndRun(compilation, new VanaraAttributeGenerator(), null, out var output, out var diag);
		CodeAnalysisHelpers.WriteTrees(TestContext.Out, output.SyntaxTrees);
		CodeAnalysisHelpers.WriteDiags(diag);
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error).Count(), Is.EqualTo(errCount));
		Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(treeCount));
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
				public static extern bool GoodSizeDef02([SizeDef("p2", SizingMethod.Count)] StringBuilder? p1, uint p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef03([SizeDef(50)] StringBuilder? p1);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef04([In, SizeDef("p2")] string? p1, [Range(0, 50)] byte p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef05([SizeDef("p2")] int[]? p1, [Range(0, 50)] int p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef06([SizeDef("p2", SizingMethod.Count)] int[]? p1, int p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef07([SizeDef(50)] int[]? p1);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef08([In, SizeDef("p2")] int[]? p1, [Range(0, 50)] int p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef09([SizeDef("p2")] IntPtr p1, [Range(0, 50)] int p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef10([SizeDef("p2", SizingMethod.Count)] IntPtr, int p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef11([SizeDef(50)] IntPtr p1);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef12([In, SizeDef(50)] IntPtr p1);
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

	const string sizeDefQueryFull = /* lang=c#-test */ """
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

				public static extern Win32Error GetCurrentPackageInfo([Out, SizeDef(nameof(count), SizingMethod.Query | SizingMethod.Bytes, BufferVarName = nameof(bufferLength))] uint[] buffer,
					ref uint bufferLength, out uint count);
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
				public static extern Win32Error GetCurrentPackageInfo([Out, SizeDef(nameof(szParam), SizingMethod.Query | SizingMethod.Bytes, OutVarName = nameof(byteSzParam))] uint[] buffer,
					ref uint byteSzParam, out uint szParam);
			}
		}
		""";

	const string sizeDefQueryPtr = /* lang=c#-test */ """
		// sizeDefQueryPtr
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
				public static extern Win32Error GoodSizeDef01([SizeDef("p2", SizingMethod.Query)] IntPtr p1, [Range(0, 50)] ref int p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <param name="p2">The p2.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true)]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool GoodSizeDef02([SizeDef("p2", SizingMethod.Query)] IntPtr p1, [Range(0, MAX_SIZE)] ref uint p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Ansi)]
				public static extern int GoodSizeDef03([MarshalAs(UnmanagedType.LPWStr), SizeDef("p2", SizingMethod.Query)] IntPtr p1, ref SizeT p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Ansi)]
				public static extern int GoodSizeDef04([MarshalAs(UnmanagedType.LPWStr), SizeDef("p2", SizingMethod.QueryResultInReturn)] IntPtr p1, int p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Ansi)]
				public static extern Win32Error GoodSizeDef05([MarshalAs(UnmanagedType.LPWStr), SizeDef("p2", SizingMethod.CheckLastError)] IntPtr p1, ref int p2);

				/// <summary>Gets the object.</summary>
				/// <param name="p1">The p1.</param>
				/// <returns>The ret.</returns>
				[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Ansi)]
				public static extern int GoodSizeDef06([MarshalAs(UnmanagedType.LPWStr), SizeDef("p2", SizingMethod.CheckLastError)] IntPtr p1, ref int p2);
			}
		}
		""";

	const string sizeDefQueryPtr2 = /* lang=c#-test */ """
		// sizeDefQueryPtr2
		using System;
		using System.Runtime.InteropServices;
		using System.ComponentModel.DataAnnotations;
		namespace Vanara.PInvoke
		{
			/// <summary>A 64-bit test dll</summary>
			public static partial class Test64
			{
				public static extern HRESULT EnclaveGetAttestationReport([In, Optional] byte[]? EnclaveData,
					[Optional, SizeDef(nameof(BufferSize), SizingMethod.Query, OutVarName = nameof(OutputSize))] IntPtr Report,
					[Optional] uint BufferSize, out uint OutputSize);

				public static extern HRESULT EnclaveSealData([In, SizeDef(nameof(DataToEncryptSize))] IntPtr DataToEncrypt, uint DataToEncryptSize, uint RuntimePolicy,
					[Optional, SizeDef(nameof(BufferSize), SizingMethod.Query, OutVarName = nameof(ProtectedBlobSize))] IntPtr ProtectedBlob, [Optional] uint BufferSize, out uint ProtectedBlobSize);
			}
		}
		""";

	const string sizeDefMult = /* lang=c#-test */ """
		// sizeDefMult
		using System;
		using System.Runtime.InteropServices;
		using System.ComponentModel.DataAnnotations;
		namespace Vanara.PInvoke
		{
			/// <summary>A 64-bit test dll</summary>
			public static partial class Test64
			{
				public static extern NTStatus TwoDiffSizeDefParams([In, AddAsMember] HTEST hAlgorithm, out SafeHTEST phHash, [Out, Optional, SizeDef(nameof(cbHashObject), SizingMethod.Bytes)] IntPtr pbHashObject,
					[Optional] uint cbHashObject, [In, Optional, SizeDef(nameof(cbSecret), SizingMethod.Bytes)] IntPtr pbSecret, [Optional] uint cbSecret, uint dwFlags = 0);

				public static extern uint TwoSizeDefParamsWithSameSizer(string szFileName, int nIconIndex, int cxIcon, int cyIcon,
					[Optional, Out, MarshalAs(UnmanagedType.LPArray), SizeDef(nameof(nIcons), SizingMethod.QueryResultInReturn)] SafeHICON[]? phicon,
					[Optional, Out, MarshalAs(UnmanagedType.LPArray), SizeDef(nameof(nIcons), SizingMethod.QueryResultInReturn)] uint[]? piconid,
					[Optional] uint nIcons, [Optional] LoadImageOptions flags);

			}
		}
		""";

	[TestCase(sizeDefCount, 2, 0)]
	[TestCase(sizeDefBytes, 2, 0)]
	[TestCase(sizeDefNullTerm, 2, 0)]
	[TestCase(sizeDefQuery, 2, 0)]
	[TestCase(sizeDefQueryPtr, 2, 0)]
	[TestCase(sizeDefQueryPtr2, 2, 0)]
	[TestCase(sizeDefMult, 2, 0)]
	public void SizeDefGenTest(string src, int treeCount, int errCount)
	{
		var compilation = GetCompilation(src);
		CreateGeneratorDriverAndRun(compilation, new VanaraAttributeGenerator(), null, out var output, out var diag);
		CodeAnalysisHelpers.WriteTrees(TestContext.Out, output.SyntaxTrees);
		Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(treeCount));
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error).Count(), Is.EqualTo(errCount));
	}

	const string structPtrIn = /* lang=c#-test */ """
		// structPtrIn
		using System;
		using System.Runtime.InteropServices;
		namespace Vanara.PInvoke
		{
			public struct UNMGD { public string s; }
			public static partial class Test64
			{
				public static extern Win32Error SampleMethod([In, Optional, StructPointer(typeof(RECT))] IntPtr buffer);
				public static extern void RaiseFailFastException([In, Optional, StructPointer(typeof(RECT))] IntPtr pExceptionRecord, [In, Optional, StructPointer(typeof(RECT))] IntPtr pContextRecord, [In, Optional] FAIL_FAST_FLAGS dwFlags);
				public static extern bool ObjectPrivilegeAuditAlarm(string SubsystemName, [In, StructPointer(typeof(UNMGD))] IntPtr Privileges);
			}
		}
		""";

	const string structPtrInSize = /* lang=c#-test */ """
		// structPtrInSize
		using System;
		using System.Runtime.InteropServices;
		namespace Vanara.PInvoke
		{
			public static partial class Test64
			{
				public static extern Win32Error SampleMethod([In, SizeDef(nameof(bufferLength)), StructPointer(typeof(RECT))] IntPtr buffer, uint bufferLength);
				public static extern Win32Error SampleMethod([In, Optional, SizeDef(nameof(bufferLength)), StructPointer(typeof(RECT))] IntPtr buffer, uint bufferLength);
			}
		}
		""";

	const string structPtrOutSize = /* lang=c#-test */ """
		// structPtrOutSize
		using System;
		using System.Runtime.InteropServices;
		namespace Vanara.PInvoke
		{
			public static partial class Test64
			{
				public static extern Win32Error SampleMethod([Out, SizeDef(nameof(bufferLength), SizingMethod.Query), StructPointer(typeof(RECT), false)] IntPtr buffer, ref uint bufferLength);
				public static extern Win32Error SampleMethod([Out, SizeDef(nameof(bufferLength), SizingMethod.Query), StructPointer(typeof(RECT))] IntPtr buffer, ref uint bufferLength);
			}
		}
		""";

	const string structPtrOutOpt = /* lang=c#-test */ """
		// structPtrOutOpt
		using System;
		using System.Runtime.InteropServices;
		namespace Vanara.PInvoke
		{
			public static partial class Test64
			{
				public static extern Win32Error SampleMethodOptOut([Out, Optional, StructPointer(typeof(uint))] IntPtr buffer);
			}
		}
		""";

	const string structPtrHMEM = /* lang=c#-test */ """
		// structPtrHMEM
		using System;
		using System.Runtime.InteropServices;
		using Vanara.InteropServices;
		namespace Vanara.PInvoke
		{
			public struct TOKENBINDING_KEY_TYPES : IArrayStruct<uint>
			{
				public uint keyCount;
				public ArrayPointer<uint> keyType;
			}
			public static partial class Test64
			{
				public static extern Win32Error SampleMethodOptOut([Out, StructPointer(typeof(SYSTEMTIME)] out SafeHGlobalHandle buffer);
				public static extern Win32Error SampleMethodOptOut2([Out, Optional, StructPointer(typeof(SYSTEMTIME)] out SafeHGlobalHandle buffer);
				public static extern Win32Error SampleMethodOptOut3([StructPointer(typeof(TOKENBINDING_KEY_TYPES))] out SafeHGlobalHandle keyTypes);
			}
		}
		""";

	const string structPtrMemMgr = /* lang=c#-test */ """
		// structPtrMemMgr
		using System;
		using System.Runtime.InteropServices;
		using Vanara.InteropServices;
		namespace Vanara.PInvoke
		{
			public static partial class Test64
			{
				public static extern Win32Error SampleMethodOptOut([Out, Optional, StructPointer(typeof(SYSTEMTIME), MemoryManager = typeof(HGlobalMemoryMethods))] out IntPtr buffer);
				public static extern Win32Error SampleMethodOptOut2([Out, StructPointer(typeof(SYSTEMTIME), MemoryManager = typeof(HGlobalMemoryMethods))] out IntPtr buffer);
			}
		}
		""";

	const string structPtrBad = /* lang=c#-test */ """
		// structPtrBad
		using System;
		using System.Runtime.InteropServices;
		using Vanara.InteropServices;
		namespace Vanara.PInvoke
		{
			public static partial class Test64
			{
				// Bad param type
				public static extern Win32Error SampleMethodOptOut([Out, Optional, StructPointer(typeof(uint))] uint buffer);
				// Type not ISafeMemoryHandleBase
				public static extern Win32Error SampleMethodOptOut([Out, Optional, StructPointer(typeof(SYSTEMTIME))] out DateTime buffer);
				// Mising MemoryManager
				public static extern Win32Error SampleMethodOptOut([Out, Optional, StructPointer(typeof(SYSTEMTIME))] out IntPtr buffer);
				// MemoryManager, bad param type
				public static extern Win32Error SampleMethodOptOut([Out, StructPointer(typeof(SYSTEMTIME), MemoryManager = typeof(HGlobalMemoryMethods))] out uint buffer);
			}
		}
		""";

	[TestCase(structPtrIn, 2, 0)]
	[TestCase(structPtrInSize, 2, 0)]
	[TestCase(structPtrOutSize, 2, 0)]
	[TestCase(structPtrOutOpt, 2, 0)]
	[TestCase(structPtrHMEM, 2, 0)]
	[TestCase(structPtrMemMgr, 2, 0)]
	[TestCase(structPtrBad, 1, 4)]
	public void StructPtrGenTest(string src, int treeCount, int errCount)
	{
		var compilation = GetCompilation(src);
		CreateGeneratorDriverAndRun(compilation, new VanaraAttributeGenerator(), null, out var output, out var diag);
		CodeAnalysisHelpers.WriteTrees(TestContext.Out, output.SyntaxTrees);
		CodeAnalysisHelpers.WriteDiags(diag);
		Assert.That(diag.Where(d => d.Severity == DiagnosticSeverity.Error).Count(), Is.EqualTo(errCount));
		Assert.That(output.SyntaxTrees.Count(), Is.EqualTo(treeCount));
	}

	private static void CreateGeneratorDriverAndRun(CSharpCompilation compilation, IIncrementalGenerator sourceGenerator, string? additionalFile, out Compilation output, out ImmutableArray<Diagnostic> diag) =>
		CSharpGeneratorDriver.Create(
			generators: [sourceGenerator.AsSourceGenerator()],
			additionalTexts: additionalFile is not null ? [new InMemoryAdditionalText("handles.csv", File.ReadAllText(additionalFile))] : [],
			driverOptions: new GeneratorDriverOptions(default, trackIncrementalGeneratorSteps: true)).
		RunGeneratorsAndUpdateCompilation(compilation, out output, out diag);

	private static CSharpCompilation GetCompilation(params string[] sourceCode) => CSharpCompilation.Create(nameof(CodeGenTests),
		Array.ConvertAll(sourceCode, i => CSharpSyntaxTree.ParseText(i)), CodeAnalysisHelpers.MetaReferences, new(OutputKind.DynamicallyLinkedLibrary));
}

internal class InMemoryAdditionalText(string path, string content) : AdditionalText
{
	private readonly SourceText _content = SourceText.From(content, Encoding.UTF8);
	public override string Path { get; } = path;
	public override SourceText GetText(CancellationToken cancellationToken = default) => _content;
}