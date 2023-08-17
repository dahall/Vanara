using NUnit.Framework;

namespace Vanara.Windows.Shell.Tests;

[TestFixture]
public class ShellSearchTests
{
	[Test]
	public void SearchTests()
	{
		using var c = SearchCondition.CreateFromStructuredQuery("customer *.pptx");
		GetResults(c);
		using var shf = ShellSearch.GetSearchResults(c, "Test", new[] { ShellFolder.Desktop }) as ShellFolder;
		var i = 50;
		foreach (var item in shf)
			if (--i > 0)
				TestContext.WriteLine(item.FileSystemPath);
			else
				break;
	}

	[Test]
	public void ConditionTest()
	{
		using var c = SearchCondition.CreateFromStructuredQuery("LONG kind:text");
		GetResults(c);
	}

	private static void GetResults(SearchCondition c)
	{
		foreach (var r in c.GetLeveledResults())
			TestContext.WriteLine(r);
	}
}