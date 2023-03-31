using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.TypeSystem;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Vanara.PInvoke.Tests;

public static class CSharpRunner
{
	private static IEnumerable<string> StdRefs => new[] { typeof(object).Assembly.Location, typeof(Enumerable).Assembly.Location };

	public static object Run(string snippet, IEnumerable<string> references, string typeName, string methodName, params object[] args) =>
		Invoke(CompileLib(Parse(snippet), references), typeName, methodName, args);

	public static object Run(MethodInfo methodInfo, params object[] args) =>
		Invoke(CompileLib(Decompile(methodInfo.DeclaringType), methodInfo.DeclaringType.GetReferencedAssemblyNames()), methodInfo.DeclaringType.FullName, methodInfo.Name, args);

	public static Process RunProcess<T>(string args = null) where T : class => RunProcess(typeof(T), args);

	public static Process RunProcess(Type mainType, string args = null)
	{
		if (mainType.GetMethod("Main", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) is null)
			throw new ArgumentException("Supplied type must include a static Main method.");
		var exe = Path.Combine(Path.GetDirectoryName(mainType.Assembly.Location), "tmp" + Guid.NewGuid().ToString("N") + ".exe");
		CompileExe(exe, Decompile(mainType), mainType.GetReferencedAssemblyNames(), mainType.FullName);
		return CreateProcess(exe, args, Path.GetDirectoryName(mainType.Assembly.Location));
	}

	public static Process RunProcess(string snippet, string workingDir, IEnumerable<string> references = null, string typeName = null, string args = null)
	{
		var exe = Path.Combine(workingDir, "tmp" + Guid.NewGuid().ToString("N") + ".exe");
		CompileExe(exe, Parse(snippet), references, typeName);
		return CreateProcess(exe, args, workingDir);
	}

	private static void CompileExe(string outputExePath, SyntaxTree syntaxTree, IEnumerable<string> references = null, string mainTypeName = null)
	{
		var mrefs = (references ?? StdRefs).Select(a => MetadataReference.CreateFromFile(a));
		var opts = new CSharpCompilationOptions(OutputKind.ConsoleApplication, allowUnsafe: true, mainTypeName: mainTypeName);
		var compilation = CSharpCompilation.Create(Path.GetRandomFileName(), new[] { syntaxTree }, mrefs, opts);
		var result = compilation.Emit(outputExePath);
		if (!result.Success)
		{
			throw new InvalidOperationException(string.Join("\n", result.Diagnostics.Where(diagnostic => diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error).Select(d => $"{d.Id}: {d.GetMessage()}")));
		}
	}

	private static Assembly CompileLib(SyntaxTree syntaxTree, IEnumerable<string> references = null)
	{
		var mrefs = (references ?? StdRefs).Select(a => MetadataReference.CreateFromFile(a));
		var compilation = CSharpCompilation.Create(Path.GetRandomFileName(), new[] { syntaxTree }, mrefs, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

		using var ms = new MemoryStream();
		var result = compilation.Emit(ms);
		if (result.Success)
		{
			ms.Seek(0, SeekOrigin.Begin);
			return Assembly.Load(ms.ToArray());
		}
		else
		{
			throw new InvalidOperationException(string.Join("\n", result.Diagnostics.Where(diagnostic => diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error).Select(d => $"{d.Id}: {d.GetMessage()}")));
		}
	}

	private static Process CreateProcess(string exe, string args, string workingDir)
	{
		var p = new Process { StartInfo = new ProcessStartInfo(exe, args) { WorkingDirectory = workingDir } };
		p.Exited += (s, e) => File.Delete(exe);
		p.Start();
		return p;
	}

	private static SyntaxTree Decompile(Type type)
	{
		var decompiler = new CSharpDecompiler(type.Assembly.Location, new DecompilerSettings());
		var typeInfo = decompiler.TypeSystem.MainModule.Compilation.FindType(type).GetDefinition();
		return Parse(decompiler.DecompileTypeAsString(typeInfo.FullTypeName));
	}

	private static IEnumerable<string> GetReferencedAssemblyNames(this Type type) => type.Assembly.GetReferencedAssemblies().Select(n => Assembly.Load(n).Location);

	private static object Invoke(Assembly assembly, string typeName, string methodName, object[] args)
	{
		var type = assembly.GetType(typeName);
		var obj = Activator.CreateInstance(type);
		return type.InvokeMember(methodName, BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, args);
	}

	private static SyntaxTree Parse(string snippet) => CSharpSyntaxTree.ParseText(snippet);
}