using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Vanara.Collections;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Shell32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class IShellFolderTests
	{
		[Test]
		public void DetailsTest()
		{
			using var pFolder = ComReleaserFactory.Create(new MyDocuments() as IShellFolder2);

			// Get folder details
			pFolder.Item.GetDefaultColumn(0, out var sortIdx, out var dispIdx);
			TestContext.WriteLine($"Sort={sortIdx}; Display={dispIdx}");

			// List all property keys
			for (uint i = 0; i < uint.MaxValue; i++)
			{
				try { TestContext.WriteLine($"{i}) Key={pFolder.Item.MapColumnToSCID(i)}; State={pFolder.Item.GetDefaultColumnState(i)}"); }
				catch { break; }
			}
		}

		[Test]
		public void EnumSearchesTest()
		{
			//foreach (KNOWNFOLDERID kf in Enum.GetValues(typeof(KNOWNFOLDERID)))
			{
				//using var pFolder = ComReleaserFactory.Create(KNOWNFOLDERID.FOLDERID_ConnectionsFolder.GetIShellFolder() as IShellFolder2);
				using var pFolder = ComReleaserFactory.Create(new Printers() as IShellFolder2);
				try
				{
					var defGuid = pFolder.Item.GetDefaultSearchGUID();
					var exSrc = pFolder.Item.EnumSearches();
					using var pExSrc = ComReleaserFactory.Create(exSrc);
					var cenum = new IEnumFromCom<EXTRASEARCH>(exSrc.Next, exSrc.Reset);
					//TestContext.WriteLine(kf);
					foreach (var item in cenum)
						TestContext.WriteLine($"{(item.guidSearch == defGuid ? "*" : "")}{item.wszFriendlyName}: {item.wszUrl}");
				}
				catch
				{
				}
			}

		}
	}
}