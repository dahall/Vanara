using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Vanara.PInvoke.Shell32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class ExplorerTests
{
	[Test]
	public void WalkNamespaceTest1()
	{
		using var pFolder = ComReleaserFactory.Create((IShellFolder2)new MyDocuments());
		INamespaceWalk walk = new();
		WalkerCallback callback = new("Progress Title", "Cancel");
		List<string> mycnt = new();
		callback.ItemFound += (f, p) => mycnt.Add(pFolder.Item.GetDisplayNameOf(SHGDNF.SHGDN_FORPARSING, p) ?? "");
		Assert.That(walk.Walk(pFolder.Item, NAMESPACEWALKFLAG.NSWF_NONE_IMPLIES_ALL | NAMESPACEWALKFLAG.NSWF_DONT_ACCUMULATE_RESULT | NAMESPACEWALKFLAG.NSWF_SHOW_PROGRESS, 0, callback), ResultIs.Successful);
		Assert.That(mycnt.Count, Is.GreaterThan(0));
		mycnt.WriteValues();
	}

	[Test]
	public void WalkNamespaceTest2()
	{
		using var pFolder = ComReleaserFactory.Create((IShellFolder2)new MyDocuments());
		INamespaceWalk walk = new();
		Assert.That(walk.Walk(pFolder.Item, NAMESPACEWALKFLAG.NSWF_NONE_IMPLIES_ALL, 0), ResultIs.Successful);
		Assert.That(walk.GetIDArrayResult(out var cnt, out var ppidls), ResultIs.Successful);
		foreach (var pidl in ppidls.ToEnumerable<IntPtr>((int)cnt).Select(p => new PIDL(p)))
			TestContext.WriteLine(pFolder.Item.GetDisplayNameOf(SHGDNF.SHGDN_NORMAL, pidl));
	}

	[Test]
	public void WalkNamespaceTest3()
	{
		using var pFolder = ComReleaserFactory.Create((IShellFolder2)new MyDocuments());
		ShellNamespaceWalker walker = new(pFolder.Item, 0, NAMESPACEWALKFLAG.NSWF_NONE_IMPLIES_ALL | NAMESPACEWALKFLAG.NSWF_DONT_ACCUMULATE_RESULT);
		var items = walker.ToArray();
		Assert.That(items, Has.Length.GreaterThanOrEqualTo(30));
		items.WriteValues();
	}


	public class ShellNamespaceWalker : IEnumerable<IShellItem>, IAsyncEnumerable<IShellItem>
	{
		private readonly object objToWalk;
		private readonly int depth;
		private readonly NAMESPACEWALKFLAG flags;

		public ShellNamespaceWalker(object objToWalk, int depth, NAMESPACEWALKFLAG flags)
		{
			this.objToWalk = objToWalk;
			this.depth = depth;
			this.flags = flags;
		}

		IAsyncEnumerator<IShellItem> IAsyncEnumerable<IShellItem>.GetAsyncEnumerator(CancellationToken cancellationToken) => throw new NotImplementedException();

		IEnumerator<IShellItem> IEnumerable<IShellItem>.GetEnumerator()
		{
			INamespaceWalk walk = new();
			var callback = new WalkerCallback();
			Queue<IShellItem> q = new();
			bool done = false;
			AutoResetEvent evt = new(false);
			callback.ItemFound += (f, p) => { lock (q) { q.Enqueue(SHCreateItemFromIDList<IShellItem>(p)!); } evt.Set(); };
			callback.Completed += hr => { done = true; evt.Set(); };
			walk.Walk(objToWalk, flags | NAMESPACEWALKFLAG.NSWF_ASYNC, depth, callback).ThrowIfFailed();
			while (!done && evt.WaitOne())
			{
				lock (q)
				{
					while (q.Count > 0)
						yield return q.Dequeue();
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<IShellItem>)this).GetEnumerator();
	}

	class WalkerCallback : INamespaceWalkCB2, IActionProgress
	{
		private readonly string cancel;
		private readonly string title;

		public WalkerCallback(string progressDlgTitle = "", string progressDlgCancelText = "Cancel")
		{
			cancel = progressDlgCancelText;
			title = progressDlgTitle;
		}

		public event Action<IShellFolder, PIDL>? ItemFound;
		public event Action<IShellFolder, PIDL>? FolderEntered;
		public event Action<IShellFolder, PIDL>? FolderLeft;
		public event Action<HRESULT>? Completed;

		public HRESULT FoundItem([In] IShellFolder psf, [In] IntPtr pidl) { ItemFound?.Invoke(psf, new PIDL(pidl, true)); return HRESULT.S_OK; }
		public HRESULT EnterFolder([In] IShellFolder psf, [In] IntPtr pidl) { FolderEntered?.Invoke(psf, new PIDL(pidl, true)); return HRESULT.S_OK; }
		public HRESULT LeaveFolder([In] IShellFolder psf, [In] IntPtr pidl) { FolderLeft?.Invoke(psf, new PIDL(pidl, true)); return HRESULT.S_OK; }
		public HRESULT InitializeProgressDialog([MarshalAs(UnmanagedType.LPWStr), Out] out string ppszTitle, [MarshalAs(UnmanagedType.LPWStr), Out] out string ppszCancel)
		{ ppszTitle = title; ppszCancel = cancel; return HRESULT.S_OK; }
		public HRESULT WalkComplete(HRESULT hr) { Completed?.Invoke(hr); return HRESULT.S_OK; }

		public void Begin(SPACTION action, SPBEGINF flags) { }
		public void UpdateProgress(ulong ulCompleted, ulong ulTotal) { }
		public void UpdateText(SPTEXT sptext, [In, MarshalAs(UnmanagedType.LPWStr)] string pszText, [MarshalAs(UnmanagedType.Bool)] bool fMayCompact) { }
		public bool QueryCancel() => false;
		public void ResetCancel() { }
		public void End() { }
	}
}