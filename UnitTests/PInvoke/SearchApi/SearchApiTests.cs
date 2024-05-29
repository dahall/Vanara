using NUnit.Framework;
using NUnit.Framework.Internal;
using System.IO;
using static Vanara.PInvoke.SearchApi;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class SearchApiTests
{
	ISearchCatalogManager? catalogManager;

	[OneTimeSetUp]
	public void _Setup()
	{
		ISearchManager searchManager = new();
		catalogManager = searchManager.GetCatalog("SystemIndex");
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	//[Test]
	public void GetItemsChangedSinkTest()
	{
		TestInlineSite testInlineSite = new(TestContext.Out);
		ISearchItemsChangedSink itemsChangedSink = catalogManager!.GetItemsChangedSink(testInlineSite, out _, out _, out _);

		using TemporaryDirectory tempDir = new();
		string f1 = tempDir.RandomTxtFileFullPath;
		File.Copy(TestCaseSources.SmallFile, f1);
		Assert.That(File.Exists(f1), Is.True);
		string f2 = tempDir.RandomTxtFileFullPath;

		SEARCH_ITEM_CHANGE itemChange = new()
		{
			Change = SEARCH_KIND_OF_CHANGE.SEARCH_CHANGE_MOVE_RENAME,
			Priority = SEARCH_NOTIFICATION_PRIORITY.SEARCH_NORMAL_PRIORITY,
			pUserData = default, //This is supposed to be a "Pointer to user information", but I have no idea what this means or what it wants
			lpwszURL = new Uri(f2).AbsoluteUri,
			lpwszOldURL = new Uri(f1).AbsoluteUri
		};
		File.Move(f1, f2);
		Assert.That(File.Exists(f2), Is.True);

		// I can't get this to work. I get an exception (DTS_E_OLEDBERROR) when trying to call OnItemsChanged.
		SEARCH_ITEM_CHANGE[] itemsChangedArray = [itemChange];
		uint[] retInts = [0];
		HRESULT[] hresults = [0];
		itemsChangedSink.OnItemsChanged(1, itemsChangedArray, retInts, hresults);
		Assert.That((int)hresults[0], Is.EqualTo(HRESULT.S_OK));
	}

	[ComVisible(true), Guid("4da1a242-8634-433a-906d-9bdba3e60b11")]
	internal class TestInlineSite(TextWriter tw) : ISearchNotifyInlineSite
	{
		public void OnItemIndexedStatusChange([In] SEARCH_INDEXING_PHASE sipStatus, [In] uint dwNumEntries,
			SEARCH_ITEM_INDEXING_STATUS[] rgItemStatusEntries) => tw.WriteLine("OnItemIndexedStatusChange");
		public void OnCatalogStatusChange(in Guid guidCatalogResetSignature, in Guid guidCheckPointSignature, uint dwLastCheckPointNumber) =>
			tw.WriteLine("OnCatalogStatusChange");
	}
}