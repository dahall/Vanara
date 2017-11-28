using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using static Vanara.PInvoke.MSTask;
using static Vanara.PInvoke.NetListMgr;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;
using static Vanara.PInvoke.Shell32;
using Vanara.Extensions;
using Vanara.PInvoke;
using System.Runtime.InteropServices;
using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;
using System.Linq;
using Vanara.InteropServices;

namespace Vanara.Collections.Tests
{
	[TestFixture]
	public class ComEnumeratorUnitTest
	{
		/*[Test]
		public void ComEnumeratorTest0()
		{
			var v1TS = new ITaskScheduler();
			var e = new IEnumNextPattern<IEnumWorkItems, IntPtr, string>(v1TS.Enum(),
				p => {
					try { return new SafeCoTaskMemHandle(Marshal.ReadIntPtr(p), -1).ToString(-1); }
					finally { Marshal.FreeCoTaskMem(p); }
				});
			while (e.MoveNext())
			{
				Assert.IsInstanceOf<string>(e.Current);
				Debug.WriteLine(e.Current);
			}
			Assert.That(e.MoveNext(), Is.False);
			e.Reset();
			Assert.That(e.MoveNext(), Is.True);
			e.Reset();
			e.Dispose();
			Assert.That(e.MoveNext(), Is.False);
		}

		public class WorkItemEnum : IEnumNextPattern<IEnumWorkItems, IntPtr, string>
		{
			//public WorkItemEnum(IEnumWorkItems coll) : base(coll, WINext, WIConvert, c => c.Reset()) { }

			private static string WIConvert(IntPtr p)
			{
				try { return new SafeCoTaskMemHandle(Marshal.ReadIntPtr(p), -1).ToString(-1); }
				finally { Marshal.FreeCoTaskMem(p); }
			}

			private static HRESULT WINext(IEnumWorkItems collection, uint celt, out IntPtr pvalues, out uint pceltfetched)
			{
				return collection.Next(celt, out pvalues, out pceltfetched);
			}
		}*/

		[Test]
		public void ComEnumeratorTest1()
		{
			// Test IntPtr -> string conversion
			var v1TS = new ITaskScheduler();
			var ewi = v1TS.Enum();

			// Test IEnumerable
			var e = new IEnumFromNext<IntPtr>((out IntPtr p) => ewi.Next(1, out p, out var f).Succeeded && f == 1, ewi.Reset);
			foreach (var p in e)
			{
				Assert.That(p, Is.Not.EqualTo(IntPtr.Zero));
				var sa = IEnumWorkItemsNames.Convert(p, 1);
				Assert.That(sa.Length, Is.EqualTo(1));
				TestContext.WriteLine(sa[0]);
			}

			// Test IEnumerator
			var g = e.GetEnumerator();
			g.Reset();
			Assert.That(g.MoveNext(), Is.True);
			g.Dispose();
			Assert.That(g.MoveNext(), Is.False);
			Assert.That(() => g.Reset(), Throws.Nothing);
		}

		[Test]
		public void ComEnumeratorTest2()
		{
			// Test IEnumerable collection
			var nlm = new INetworkListManager();
			var en = nlm.GetNetworks(NLM_ENUM_NETWORK.NLM_ENUM_NETWORK_ALL);

			// Test IEnumerable
			var e = new IEnumFromNext<INetwork>((out INetwork p) => en.Next(1, out p, out var f).Succeeded && f == 1,
				() => en.Reset());
			foreach (var p in e)
			{
				Assert.IsInstanceOf<INetwork>(p);
				TestContext.WriteLine(p.GetName());
			}

			// Test IEnumerator
			var g = e.GetEnumerator();
			g.Reset();
			Assert.That(g.MoveNext(), Is.True);
			g.Dispose();
			Assert.That(g.MoveNext(), Is.False);
		}

		[Test]
		public void ComEnumeratorTest3()
		{
			// Test class values
			var pidl = KNOWNFOLDERID.FOLDERID_Documents.PIDL();
			SHGetDesktopFolder(out IShellFolder dt);
			var docs = (IShellFolder) dt.BindToObject(pidl, null, typeof(IShellFolder).GUID);
			var eo = docs.EnumObjects(IntPtr.Zero, SHCONTF.SHCONTF_FOLDERS);

			// Test IEnumerable
			var e = new IEnumFromNext<IntPtr>((out IntPtr p) => eo.Next(1, out p, out var f).Succeeded && f == 1,
				() => eo.Reset());
			foreach (var p in e)
			{
				Assert.That(p, Is.Not.EqualTo(IntPtr.Zero));
				var sp = new PIDL(p);
				TestContext.WriteLine(sp);
			}

			// Test IEnumerator
			var g = e.GetEnumerator();
			g.Reset();
			Assert.That(g.MoveNext(), Is.True);
			g.Dispose();
			Assert.That(g.MoveNext(), Is.False);
		}

		[Test]
		public void ComEnumeratorTest4()
		{
			// Test Get based interfaces with PIDLs
			SHCreateItemFromParsingName(PInvoke.Tests.AdvApi32Tests.fn, null, typeof(IShellItem2).GUID, out object ppv);
			Assert.That(ppv, Is.Not.Null);
			var si2 = (IShellItem2) ppv;
			var pk = KnownShellItemPropertyKeys.PropList.FullDetails;
			var pdl = si2.GetPropertyDescriptionList(ref pk, typeof(IPropertyDescriptionList).GUID);
			var pdRiid = typeof(IPropertyDescription).GUID;

			// Test IEnumerable
			var e = new IEnumFromIndexer<IPropertyDescription>(pdl.GetCount, i => pdl.GetAt(i, pdRiid), 0);
			var c = 0;
			var l = new List<string>();
			foreach (var pd in e)
			{
				Assert.IsInstanceOf<IPropertyDescription>(pd);
				var s = pd.GetDisplayName();
				l.Add(s);
				TestContext.WriteLine(s);
				c++;
			}
			Assert.That(c, Is.EqualTo(e.Count));
			Assert.That(l[0], Is.EqualTo(e[0]));
			Assert.That(l[c-1], Is.EqualTo(e[c-1]));

			// Test IEnumerator
			var g = e.GetEnumerator();
			g.Reset();
			Assert.That(g.MoveNext(), Is.True);
			g.Dispose();
			Assert.That(g.MoveNext(), Is.False);
		}

		[Test]
		public void ComEnumeratorTest5()
		{
			// Test IntPtr -> string conversion
			var fn = System.IO.Path.GetTempFileName();
			var hr = StgCreateStorageEx(fn,
				STGM.STGM_DELETEONRELEASE | STGM.STGM_CREATE | STGM.STGM_DIRECT | STGM.STGM_READWRITE | STGM.STGM_SHARE_EXCLUSIVE,
				STGFMT.STGFMT_DOCFILE, 0, IntPtr.Zero, IntPtr.Zero, typeof(IStorage).GUID, out object iptr);
			Assert.That(hr, Is.EqualTo((HRESULT) HRESULT.S_OK));
			var istg = (IStorage) iptr;
			Assert.That(istg, Is.InstanceOf<IStorage>());
			var istgc = istg.CreateStorage("temp",
				STGM.STGM_CREATE | STGM.STGM_DIRECT | STGM.STGM_WRITE | STGM.STGM_SHARE_EXCLUSIVE, 0, 0);
			istgc.Commit(STGC.STGC_DEFAULT);
			var istr = istg.CreateStream("stream1",
				STGM.STGM_CREATE | STGM.STGM_DIRECT | STGM.STGM_WRITE | STGM.STGM_SHARE_EXCLUSIVE, 0, 0);
			var strb = "Some string text".GetBytes();
			istr.Write(strb, strb.Length, IntPtr.Zero);
			istr.Commit((int) STGC.STGC_DEFAULT);
			istg.Commit(STGC.STGC_DEFAULT);
			var ee = istg.EnumElements(0, IntPtr.Zero, 0);

			// Test IEnumerable
			bool Next(out STATSTG p)
			{
				var a = new STATSTG[1];
				var b = ee.Next(1, a, out var f).Succeeded && f == 1;
				p = b ? a[0] : default(STATSTG);
				return b;
			}

			var e = new IEnumFromNext<STATSTG>(Next, ee.Reset);
			foreach (var p in e)
			{
				//Assert.That(p.cbSize, Is.Not.Zero);
				TestContext.WriteLine(p.pwcsName);
			}

			// Test IEnumerator
			var g = e.GetEnumerator();
			g.Reset();
			Assert.That(g.MoveNext(), Is.True);
			g.Dispose();
			Assert.That(g.MoveNext(), Is.False);
		}

		[Test]
		public void ComEnumeratorTest6()
		{
			var pidls = new[]
			{
				KNOWNFOLDERID.FOLDERID_Documents.PIDL(), KNOWNFOLDERID.FOLDERID_Pictures.PIDL(),
				KNOWNFOLDERID.FOLDERID_Videos.PIDL()
			}.Select(p => (IntPtr) p).ToArray();
			var hr = SHCreateShellItemArrayFromIDLists((uint) pidls.Length, pidls, out IShellItemArray iarr);
			Assert.That(hr, Is.EqualTo((HRESULT) HRESULT.S_OK));
			var ei = iarr.EnumItems();

			// Test IEnumerable
			bool Next(out IShellItem p)
			{
				var a = new IShellItem[1];
				var b = ei.Next(1, a, out var f).Succeeded && f == 1;
				p = b ? a[0] : null;
				return b;
			}

			var e = new IEnumFromNext<IShellItem>(Next, ei.Reset);
			foreach (var p in e)
			{
				Assert.That(p, Is.Not.Null);
				TestContext.WriteLine(p.GetDisplayName(SIGDN.SIGDN_PARENTRELATIVE));
				Marshal.ReleaseComObject(p);
			}

			// Test IEnumerator
			var g = e.GetEnumerator();
			g.Reset();
			Assert.That(g.MoveNext(), Is.True);
			g.Dispose();
			Assert.That(g.MoveNext(), Is.False);
		}

		[Test]
		public void ComEnumeratorTest7()
		{
			var pidls = new[]
			{
				KNOWNFOLDERID.FOLDERID_Documents.PIDL(), KNOWNFOLDERID.FOLDERID_Pictures.PIDL(),
				KNOWNFOLDERID.FOLDERID_Videos.PIDL()
			}.Select(p => (IntPtr) p).ToArray();
			var hr = SHCreateShellItemArrayFromIDLists((uint) pidls.Length, pidls, out IShellItemArray iarr);
			Assert.That(hr, Is.EqualTo((HRESULT) HRESULT.S_OK));

			// Test IEnumerable
			var e = new IEnumFromIndexer<IShellItem>(iarr.GetCount, i => iarr.GetItemAt(i), 0);
			var c = 0;
			foreach (var pd in e)
			{
				Assert.IsInstanceOf<IShellItem>(pd);
				TestContext.WriteLine(pd.GetDisplayName(SIGDN.SIGDN_PARENTRELATIVE));
				c++;
			}
			Assert.That(c, Is.EqualTo(iarr.GetCount()));

			// Test IEnumerator
			var g = e.GetEnumerator();
			g.Reset();
			Assert.That(g.MoveNext(), Is.True);
			g.Dispose();
			Assert.That(g.MoveNext(), Is.False);
		}

		[Test]
		public void ComEnumeratorTest8()
		{
			var oc = new IObjectCollection();
			SHCreateItemFromParsingName(PInvoke.Tests.AdvApi32Tests.fn, null, typeof(IShellItem).GUID, out object ppv);
			Assert.That(ppv, Is.Not.Null);
			Assert.That(oc.GetCount(), Is.Zero);
			oc.AddObject(ppv);
			var oa = (IObjectArray) oc;

			// Test IEnumerable
			var e = new IEnumFromIndexer<IShellItem>(oa.GetCount, i => (IShellItem) oa.GetAt(i, typeof(IShellItem).GUID), 0);
			var c = 0;
			foreach (var pd in e)
			{
				Assert.IsInstanceOf<IShellItem>(pd);
				TestContext.WriteLine(pd.GetDisplayName(SIGDN.SIGDN_PARENTRELATIVE));
				c++;
			}
			Assert.That(c, Is.EqualTo(oa.GetCount()));

			// Test IEnumerator
			var g = e.GetEnumerator();
			g.Reset();
			Assert.That(g.MoveNext(), Is.True);
			g.Dispose();
			Assert.That(g.MoveNext(), Is.False);
		}

		[Test]
		public void ComEnumeratorTest9()
		{
			SHGetPropertyStoreFromParsingName(PInvoke.Tests.AdvApi32Tests.fn, null, GETPROPERTYSTOREFLAGS.GPS_DEFAULT,
				typeof(IPropertyStore).GUID, out IPropertyStore ps);
			Assert.That(ps, Is.Not.Null);

			// Test IEnumerable
			var e = new IEnumFromIndexer<PROPERTYKEY>(ps.GetCount, i => ps.GetAt(i), 0);
			var c = 0;
			foreach (var pd in e)
			{
				Assert.IsInstanceOf<PROPERTYKEY>(pd);
				TestContext.WriteLine(pd);
				c++;
			}
			Assert.That(c, Is.EqualTo(ps.GetCount()));

			// Test IEnumerator
			var g = e.GetEnumerator();
			g.Reset();
			Assert.That(g.MoveNext(), Is.True);
			g.Dispose();
			Assert.That(g.MoveNext(), Is.False);
		}

		[Test]
		public void ComEnumeratorTest10()
		{
			Assert.That(() => new IEnumFromIndexer<uint>(null, i => i, 0), Throws.ArgumentNullException);
			Assert.That(() => new IEnumFromIndexer<uint>(() => 1, null, 0), Throws.ArgumentNullException);
			Assert.That(() => new IEnumFromNext<uint>(null, () => { }), Throws.ArgumentNullException);
			Assert.That(() => new IEnumFromNext<uint>((out uint value) => { value = 1; return true; }, null), Throws.ArgumentNullException);
		}
	}
}