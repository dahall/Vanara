using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.TypeSystem;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Vanara.PInvoke.Tests;

public static class CSharpRunner
{
	private static IEnumerable<string> StdRefs => [typeof(object).Assembly.Location, typeof(Enumerable).Assembly.Location];
		//, Path.Combine(Path.GetDirectoryName(typeof(object).Assembly.Location)!, "System.Runtime.dll")];

	public static object? Run(string snippet, IEnumerable<string> references, string typeName, string methodName, params object[] args) =>
		Invoke(CompileLib(Parse(snippet), references), typeName, methodName, args);

	public static object? Run(MethodInfo methodInfo, params object[] args) => methodInfo.DeclaringType is not null ?
		Invoke(CompileLib(Decompile(methodInfo.DeclaringType), methodInfo.DeclaringType.GetReferencedAssemblyNames()), methodInfo.DeclaringType.FullName!, methodInfo.Name, args) :
		throw new ArgumentNullException(nameof(methodInfo), "The DeclaringType of methodInfo is null");

	public static Process RunProcess<T>(string? args = null, string entryPoint = "Main") where T : class => RunProcess(typeof(T), args, entryPoint);

	public static Process RunProcess(Type mainType, string? args = null, string entryPoint = "Main")
	{
		if (mainType.GetMethod(entryPoint, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) is null)
			throw new ArgumentException("Supplied type must include a static Main method.");
		var exe = Path.Combine(Path.GetDirectoryName(mainType.Assembly.Location)!, "tmp" + Guid.NewGuid().ToString("N") + ".exe");
		var syntaxTree = Decompile(mainType);
		if (entryPoint != "Main")
		{
			var root = syntaxTree.GetRoot();
			var mainMethod = root.DescendantNodes().OfType<Microsoft.CodeAnalysis.CSharp.Syntax.MethodDeclarationSyntax>().FirstOrDefault(m => m.Identifier.Text == entryPoint);
			if (mainMethod is null)
				throw new ArgumentException("Supplied type must include a static method with the specified entry point name.");
			var newMain = mainMethod.WithIdentifier(SyntaxFactory.Identifier("Main"));
			root = root.ReplaceNode(mainMethod, newMain);
			syntaxTree = syntaxTree.WithRootAndOptions(root.NormalizeWhitespace(), syntaxTree.Options);
		}
		CompileExe(exe, syntaxTree, mainType.GetReferencedAssemblyNames(), mainType.FullName);
		return CreateProcess(exe, args, Path.GetDirectoryName(mainType.Assembly.Location)!);
	}

	public static Process RunProcess(string snippet, string workingDir, IEnumerable<string> references, string? typeName = null, string? args = null)
	{
		var exe = Path.Combine(workingDir, "tmp" + Guid.NewGuid().ToString("N") + ".exe");
		CompileExe(exe, Parse(snippet), references, typeName);
		return CreateProcess(exe, args, workingDir);
	}

	private static void CompileExe(string outputExePath, SyntaxTree syntaxTree, IEnumerable<string> references, string? mainTypeName = null)
	{
		var mrefs = StdRefs.Union(references ?? []).Select(a => MetadataReference.CreateFromFile(a));
		var opts = new CSharpCompilationOptions(OutputKind.ConsoleApplication, allowUnsafe: true, mainTypeName: mainTypeName, optimizationLevel: OptimizationLevel.Debug);
		var compilation = CSharpCompilation.Create(Path.GetRandomFileName(), [syntaxTree], mrefs, opts);
		var result = compilation.Emit(outputExePath, Path.ChangeExtension(outputExePath, "pdb"));
		if (!result.Success)
			throw new InvalidOperationException(string.Join("\n", result.Diagnostics.Where(diagnostic => diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error).Select(d => $"{d.Id}: {d.GetMessage()}")));

		/*File.WriteAllText(Path.ChangeExtension(outputExePath, "runtimeconfig.json"), """
		{
		  "runtimeOptions": {
		    "tfm": "net8.0",
		    "framework": {
		      "name": "Microsoft.NETCore.App",
		      "version": "8.0.0"
		    },
		    "configProperties": {
		      "System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization": false,
		      "CSWINRT_USE_WINDOWS_UI_XAML_PROJECTIONS": false
		    }
		  }
		}
		""", Encoding.UTF8);*/
	}

	private static Assembly CompileLib(SyntaxTree syntaxTree, IEnumerable<string> references)
	{
		var mrefs = StdRefs.Union(references ?? []).Select(a => MetadataReference.CreateFromFile(a));
		var compilation = CSharpCompilation.Create(Path.GetRandomFileName(), [syntaxTree], mrefs, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

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

	private static Process CreateProcess(string exe, string? args, string workingDir)
	{
		var p = new Process { StartInfo = new(exe) { UseShellExecute = false, WorkingDirectory = workingDir, RedirectStandardInput = true, RedirectStandardError = true, RedirectStandardOutput = true } };
		if (args is not null) p.StartInfo.Arguments = args;
		p.Exited += (s, e) => Array.ForEach(Directory.GetFiles(Path.GetDirectoryName(exe)!, Path.GetFileNameWithoutExtension(exe) + ".*"), f => File.Delete(f));
		p.Start();
		return p;
	}

	private static SyntaxTree Decompile(Type type)
	{
		var decompiler = new CSharpDecompiler(type.Assembly.Location, new DecompilerSettings());
		var typeInfo = decompiler.TypeSystem.MainModule.Compilation.FindType(type).GetDefinition() ?? throw new ArgumentException("Type does not have a definition.", nameof(type));
		return Parse(decompiler.DecompileTypeAsString(typeInfo.FullTypeName));
	}

	private static IEnumerable<string> GetReferencedAssemblyNames(this Type type) => type.Assembly.GetReferencedAssemblies().Select(n => Assembly.Load(n).Location);

	private static object? Invoke(Assembly assembly, string typeName, string methodName, object[] args)
	{
		var type = assembly.GetType(typeName) ?? throw new ArgumentException("Type cannot be found.", nameof(typeName));
		var obj = Activator.CreateInstance(type);
		return type.InvokeMember(methodName, BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, args);
	}

	private static SyntaxTree Parse(string snippet) => CSharpSyntaxTree.ParseText(snippet);
}