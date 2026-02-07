using NUnit.Framework;
using System.Linq;
using Vanara.Collections;
using static Vanara.PInvoke.PropSys;
using static Vanara.PInvoke.Shell32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class IShellFolderTests
{
	[Test]
	public void DetailsTest()
	{
		using var pFolder = ComReleaserFactory.Create((IShellFolder2)new MyDocuments());

		// Get folder details
		pFolder.Item.GetDefaultColumn(0, out var sortIdx, out var dispIdx);
		TestContext.WriteLine($"Sort={sortIdx}; Display={dispIdx}");

		// List all property keys
		for (uint i = 0; i < 50; i++)
		{
			try { TestContext.WriteLine($"{i}) Key={(pFolder.Item.MapColumnToSCID(i, out var pk).Succeeded ? pk : default)}; State={(pFolder.Item.GetDefaultColumnState(i, out var st).Succeeded ? st : default)}"); }
			catch { break; }
		}
	}

	[Test]
	public void EnumSearchesTest()
	{
		//foreach (KNOWNFOLDERID kf in Enum.GetValues(typeof(KNOWNFOLDERID)))
		{
			//using var pFolder = ComReleaserFactory.Create(KNOWNFOLDERID.FOLDERID_ConnectionsFolder.GetIShellFolder() as IShellFolder2);
			using var pFolder = ComReleaserFactory.Create((IShellFolder2)new Printers());
			try
			{
				pFolder.Item.GetDefaultSearchGUID(out var defGuid).ThrowIfFailed();
				pFolder.Item.EnumSearches(out var exSrc).ThrowIfFailed();
				using var pExSrc = ComReleaserFactory.Create(exSrc!);
				var cenum = new IEnumFromCom<EXTRASEARCH>(exSrc!.Next, exSrc!.Reset);
				//TestContext.WriteLine(kf);
				foreach (var item in cenum)
					TestContext.WriteLine($"{(item.guidSearch == defGuid ? "*" : "")}{item.wszFriendlyName}: {item.wszUrl}");
			}
			catch
			{
			}
		}

	}

	[Test]
	public void Issue530Test()
	{
		var pFolder = (IShellFolder2)new MyDocuments();
		var item = pFolder.EnumObjects().FirstOrDefault();
		Assert.That(item, Is.Not.Null);

		IPropertyStoreFactory? propertyStoreFactoryForChild = null;
		Assert.That(() => propertyStoreFactoryForChild = pFolder.BindToObject<IPropertyStoreFactory>(item!), Throws.Nothing);
		Assert.That(propertyStoreFactoryForChild, Is.Not.Null);

		IPropertyStore? propertyStoreForChild = null;
		Assert.That(() => propertyStoreFactoryForChild!.GetPropertyStore(GETPROPERTYSTOREFLAGS.GPS_DEFAULT, null, typeof(IPropertyStore).GUID, out propertyStoreForChild), Throws.Nothing);
		Assert.That(propertyStoreForChild, Is.Not.Null);
	}
}