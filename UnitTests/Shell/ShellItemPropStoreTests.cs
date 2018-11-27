using System;
using NUnit.Framework;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Vanara.PInvoke;
using Vanara.Windows.Shell;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using System.Runtime.InteropServices;
using System.Collections;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture]
	public class ShellItemPropStoreTests
	{
		private const string testDoc = ShellItemTests.testDoc;

		[Test]
		public void ShellItemPropertyStoreTest1()
		{
			using (var i = new ShellItem(testDoc))
			{
				Assert.That(i.Properties, Is.Not.Null.And.Count.GreaterThan(0));
				Assert.That(i.Properties, Is.EqualTo(i.Properties));
				Assert.That(i.Properties.IncludeSlow, Is.False);
				Assert.That(i.Properties.IsDirty, Is.False);
				Assert.That(i.Properties.NoInheritedProperties, Is.False);
				Assert.That(i.Properties.ReadOnly, Is.True);
				Assert.That(i.Properties.Temporary, Is.False);
			}
		}

		[Test]
		public void EnumTest()
		{
			using (var i = new ShellItem(testDoc))
			{
				var c = 0;
				foreach (var key in i.Properties.Keys)
				{
					try
					{
						TestContext.Write($"({c}) {key} = ");
						var val = i.Properties[key];
						if (!(val is string) && val is IEnumerable ie)
							TestContext.WriteLine(string.Join(",", ie.Cast<object>().Select(o => o?.ToString())));
						else
							TestContext.WriteLine(val);
						using (var d = i.Properties.Descriptions[key])
						{
							if (d != null)
							{
								TestContext.WriteLine($"   {d.FormatForDisplay(val)}");
								TestContext.WriteLine($"   DispN:{d.DisplayName}; DispT:{d.DisplayType}");
							}
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
		}

		[Test]
		public void DescriptionTest()
		{
			using (var i = new ShellItem(testDoc))
			{
				var c = 0;
				foreach (var d in i.Properties.Descriptions)
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
						using (var pv = i.Properties.GetPropVariant(d.PropertyKey))
						{
							Assert.That(pv, Is.Not.Null);
							TestContext.WriteLine($"   IsCan:{d.IsValueCanonical(pv)}; ImgLoc:{d.GetImageLocationForValue(pv)}");
						}
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
				Assert.That(c, Is.EqualTo(i.Properties.Descriptions.Count));
			}
		}
	}
}