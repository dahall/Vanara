using NUnit.Framework;
using System.Linq;
using System.Runtime.InteropServices;
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

	private static readonly int[] values = [1, 2];

	[Test]
	public void EnumFromComIntPtrFetchedCountTest()
	{
		var enumObj = new IntPtrEnum();
		var values = IEnumFromCom<int>.Create<IIntPtrEnum>(enumObj).ToArray();

		Assert.That(values, Is.EqualTo(values));
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

	[Test]
	public void Issue581Test()
	{
		Assert.That(SHCreateItemFromParsingName(TestCaseSources.TempDir, null, out IShellItem? pItem), ResultIs.Successful);
		Assert.That(pItem, Is.Not.Null);
		IShellFolder pFolder;
		Assert.That(pFolder = pItem!.BindToHandler<IShellFolder>(null, BHID.BHID_SFObject), Is.Not.Null);

		SFGAO? attr = SFGAO.SFGAO_FILESYSTEM;
		Assert.That(pFolder!.ParseDisplayName(default, default, System.IO.Path.GetFileName(TestCaseSources.WordDoc), out _, out var ppidl, ref attr), ResultIs.Successful);
		Assert.That(ppidl, ResultIs.ValidHandle);
	}

	private interface IIntPtrEnum : ICOMEnum<int>
	{
		HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] rgelt, IntPtr pceltFetched);

		void Reset();
	}

	private sealed class IntPtrEnum : IIntPtrEnum
	{
		private readonly int[] values = IShellFolderTests.values;
		private int index;

		public HRESULT Next(uint celt, int[] rgelt, IntPtr pceltFetched)
		{
			var fetched = 0;
			while (fetched < celt && index < values.Length)
				rgelt[fetched++] = values[index++];

			if (pceltFetched != IntPtr.Zero)
				Marshal.WriteInt32(pceltFetched, fetched);

			return fetched == celt ? HRESULT.S_OK : HRESULT.S_FALSE;
		}

		public void Reset() => index = 0;
	}
}