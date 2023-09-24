using NUnit.Framework;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Ole32;

namespace Vanara.Windows.Shell.Tests;

[TestFixture]
public class ShellItemPropStoreTests
{
	private static readonly string testDoc = ShellItemTests.testDoc;

	[Test]
	public void DescriptionTest()
	{
		using var i = new ShellItem(TestCaseSources.LogFile);
		var c = 0;
		foreach (var d in i.PropertyDescriptions)
		{
			c++;
			Assert.That(d, Is.Not.Null);
			Assert.That(() =>
			{
				TestContext.WriteLine($"Agg:{d.AggregationType}; Can:{d.CanonicalName}; ColSt:{d.ColumnState}");
				TestContext.WriteLine($"Cond:{d.ConditionType}; ColW:{d.DefaultColumnWidth}; DispN:{d.DisplayName}");
				TestContext.WriteLine($"DispT:{d.DisplayType}; EditInv:{d.EditInvitation}; SortDesc:{d.GetSortDescriptionLabel()}");
				TestContext.WriteLine($"GrpRng:{d.GroupingRange}; PropType:{d.PropertyType}; RelDescType:{d.RelativeDescriptionType}");
				TestContext.WriteLine($"SortDesc:{d.SortDescription}; TypeFlags:{d.TypeFlags}; ViewFlags:{d.ViewFlags}");
				using var pv = i.Properties.GetPropVariant(d.PropertyKey);
				Assert.That(pv, Is.Not.Null);
				TestContext.WriteLine($"   IsCan:{d.IsValueCanonical(pv)}; ImgLoc:{d.GetImageLocationForValue(pv)}");
			}, Throws.Nothing);
			if (d.TypeList.Count > 0) Debug.WriteLine("   Prop Types:");
			foreach (var t in d.TypeList)
			{
				Debug.WriteLine($"     DispTx:{t.DisplayText}; EnumT:{t.EnumType}");
				Debug.WriteLine($"     ImgLoc:{t.ImageReference}; RngMin:{t.RangeMinValue}");
				Debug.WriteLine($"     RngSet:{t.RangeSetValue}; Val:{t.Value}");
			}
		}
		TestContext.WriteLine("");
		Assert.That(c, Is.LessThanOrEqualTo(i.Properties.Descriptions.Count));
	}

	[Test]
	public void EnumTest()
	{
		using var i = new ShellItem(testDoc);
		var c = 0;
		foreach (var key in i.Properties.Keys)
		{
			try
			{
				TestContext.Write($"({c}) {key} = ");
				var val = i.Properties[key];
				if (val is not string && val is IEnumerable ie)
					TestContext.WriteLine(string.Join(",", ie.Cast<object>().Select(o => o?.ToString())));
				else
					TestContext.WriteLine(val);
				using var d = i.Properties.Descriptions[key];
				if (d != null)
				{
					TestContext.WriteLine($"   {d.FormatForDisplay(val ?? "")}");
					TestContext.WriteLine($"   DispN:{d.DisplayName}; DispT:{d.DisplayType}");
				}
			}
			catch (Exception ex)
			{
				TestContext.WriteLine(ex.ToString());
			}
			c++;
			TestContext.WriteLine("");
		}
		Assert.That(c, Is.EqualTo(i.Properties.Count));
	}

	[Test]
	public void WritableTest()
	{
		// Try accessing a text file's writable properties and assert a failure.
		using (var i = new ShellItem(TestCaseSources.LogFile))
		{
			i.Properties.ReadOnly = false;
			Assert.That(() => i.Properties.TryGetValue(PROPERTYKEY.System.Size, out var val), Throws.TypeOf<InvalidOperationException>());
		}

		// Try accessing a Word file's writable properties and assert successs.
		using var w = new ShellItem(testDoc);
		w.Properties.ReadOnly = false;
		Assert.That(w.Properties.TryGetValue(PROPERTYKEY.System.Author, out _), Is.True);
	}

	[Test]
	public void ShellItemPropertyStoreTest1()
	{
		using var i = new ShellItem(testDoc);
		Assert.That(i.Properties, Is.Not.Null.And.Count.GreaterThan(0));
		Assert.That(i.Properties, Is.EqualTo(i.Properties));
		Assert.That(i.Properties.IncludeSlow, Is.False);
		Assert.That(i.Properties.IsDirty, Is.False);
		Assert.That(i.Properties.NoInheritedProperties, Is.False);
		Assert.That(i.Properties.ReadOnly, Is.True);
		Assert.That(i.Properties.Temporary, Is.False);
	}

	[Test]
	public void PropXlsGetTest()
	{
		using ShellItem Item = new(TestCaseSources.TempDirWhack + "Test.xlsx");
		if (Item.Properties.TryGetValue(PROPERTYKEY.System.Document.PageCount, out int PageCount))
			TestContext.Write($"PageCount={PageCount}");
	}
}