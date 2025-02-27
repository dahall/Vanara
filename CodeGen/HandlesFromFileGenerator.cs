using LumenWorks.Framework.IO.Csv;
using System.Collections.Immutable;

namespace Vanara.Generators;

/// <summary>Code generator that looks for a handles.txt or handles.csv file and builds indicated handle objects.</summary>
// [Namespace, HandleName, SummaryText?, Interface? = IHandle, CloseMethod?, SafeSummaryText?, SafeBase? = SafeHANDLE]
// ClassName,"A handle to a test",IHandle,"CloseTest(handle)","A safe handle to test that is closed by <c>CloseTest</c> when disposed.",SafeHANDLE
// HNOSAFE,"A handle that cannot be automatically closed.",IHandle,,
// HSNAPSHOT,"Provides a handle to a snapshot.",IKernelHandle,[inherit],"Provides a safe handle to a snapshot.",SafeKernelHandle
// HEVENT,,,[inherit],"Provides a safe handle to a sync event.",SafeSyncHandle
[Generator(LanguageNames.CSharp)]
public class HandlesFromFileGenerator : IIncrementalGenerator
{
	/// <summary>Called to initialize the generator and register generation steps via callbacks on the <paramref name="context"/></summary>
	/// <param name="context">
	/// The <see cref="T:Microsoft.CodeAnalysis.IncrementalGeneratorInitializationContext"/> to register callbacks on
	/// </param>
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		var pipeline = context.AdditionalTextsProvider.Where(at => Path.GetFileName(at.Path).ToLower() is "handles.txt" or "handles.csv").
			Select((text, token) => text.GetText(token)?.ToString()).Where(text => text is not null)!.Collect();

		context.RegisterSourceOutput(pipeline, GenerateCode);
	}

	private static void GenerateCode(SourceProductionContext context, ImmutableArray<string?> files)
	{
		foreach (string file in files.Where(f => f?.Length > 5)!)
		{
			bool hasHeader = file[0] == '#' || file.StartsWith("Namespace,");
			using StringReader ms = new(file);
			using CachedCsvReader parser = new(ms, hasHeader);
			if (parser.FieldCount != 7)
			{
				ReportError(context, "VANGEN001", "Invalid number of fields in file.", []);
				continue;
			}
			while (parser.ReadNextRecord())
			{
				HandleModel model = new(parser[0], parser[1], parser[2], parser[3], parser[4], parser[5], parser[6]);
				if (model.Namespace != string.Empty && model.HandleName != string.Empty)
				{
					bool found = false;
					if (model.HandleName != string.Empty && model.InterfaceName != string.Empty)
					{
						var src = model.GetHandleCode();
						context.AddSource($"{model.HandleName}.g.cs", SourceText.From(src, Encoding.UTF8));
						found = true;
					}
					if (model.ClassName != string.Empty && model.BaseClassName != string.Empty && model.CloseCode != string.Empty)
					{
						var classSrc = model.GetSafeHandleCode();
						context.AddSource($"{model.ClassName}.g.cs", SourceText.From(classSrc, Encoding.UTF8));
						found = true;
					}
					if (!found)
						ReportError(context, "VANGEN003", "Invalid record. No valid handle or safe handle found.", parser.Records[(int)parser.CurrentRecordIndex]);
				}
				else
				{
					ReportError(context, "VANGEN002", "Invalid record. Namespace and HandleName are required.", parser.Records[(int)parser.CurrentRecordIndex]);
					continue;
				}
			}
		}
	}

	private static void ReportError(SourceProductionContext context, string id, string message, string[] fields) => 
		context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor(id, "Error", message, "Vanara.Generator", DiagnosticSeverity.Error, true), Location.None, string.Join(",", fields)));
}