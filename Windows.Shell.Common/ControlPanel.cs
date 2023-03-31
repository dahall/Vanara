using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

/// <summary>Provides a means to open Control Panel items and get their paths.</summary>
public static class ControlPanel
{
	private static SafeCP cp;

	/// <summary>Gets a value indicating whether the most recent Control Panel view was Classic view.</summary>
	/// <value>
	/// <see langword="true"/> if the most recent Control Panel view was Classic view; otherwise, <see langword="false"/> for Category view.
	/// </value>
	public static bool IsClassicView => CP.GetCurrentView() == CPVIEW.CPVIEW_CLASSIC;

	private static SafeCP CP => cp ?? (cp = new SafeCP());

	/// <summary>Gets the path of a Control Panel item.</summary>
	/// <param name="item">The Control Panel item.</param>
	/// <returns>The path.</returns>
	public static string GetPath(ControlPanelItem item) => CP.GetPath(item.CanonicalName());

	/// <summary>Gets the path of a Control Panel GUID.</summary>
	/// <param name="item">The Control Panel GUID.</param>
	/// <returns>The path.</returns>
	public static string GetPath(Guid item) => CP.GetPath(item.ToString());

	/// <summary>Gets the path of a Control Panel item.</summary>
	/// <param name="item">The Control Panel item's canonical name.</param>
	/// <returns>The path.</returns>
	public static string GetPath(string item) => CP.GetPath(item);

	/// <summary>Opens the Control Panel.</summary>
	/// <returns><see langword="true"/> if the Control Panel has been opened. <see langword="false"/> if an error prevented opening.</returns>
	public static bool Open() => CP.Open();

	/// <summary>Opens the specified Control Panel item.</summary>
	/// <param name="item">The Control Panel item.</param>
	/// <param name="page">Optional. The Control Panel page.</param>
	/// <returns>
	/// <see langword="true"/> if this item is supported and has been opened. <see langword="false"/> if an error prevented opening or
	/// the item or page was unsupported on this OS.
	/// </returns>
	/// <exception cref="ArgumentOutOfRangeException">page</exception>
	public static bool Open(ControlPanelItem item, string page = null)
	{
		if (page != null && Array.IndexOf(item.ValidPages(), page) == -1) throw new ArgumentOutOfRangeException(nameof(page));
		return CP.Open(item.CanonicalName(), page);
	}

	/// <summary>Opens the specified Control Panel item.</summary>
	/// <param name="item">The Control Panel item's canonical name.</param>
	/// <param name="page">Optional. The Control Panel page.</param>
	/// <returns>
	/// <see langword="true"/> if this item is supported and has been opened. <see langword="false"/> if an error prevented opening or
	/// the item or page was unsupported on this OS.
	/// </returns>
	/// <exception cref="ArgumentOutOfRangeException">page</exception>
	public static bool Open(string item, string page = null) => CP.Open(item, page);

	private class SafeCP : IDisposable
	{
		internal IOpenControlPanel icp;
		private bool disposedValue = false;

		public SafeCP() => icp = new IOpenControlPanel();

		~SafeCP()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public CPVIEW GetCurrentView() => icp.GetCurrentView();

		public string GetPath(string pszName)
		{
			const int cchPath = 128;
			var pszPath = new StringBuilder(cchPath, cchPath);
			return icp.GetPath(pszName, pszPath, cchPath).Succeeded ? pszPath.ToString() : string.Empty;
		}

		public bool Open(string pszName = null, string page = null, object punkSite = null) => icp.Open(pszName, page, punkSite).Succeeded;

		protected virtual void Dispose(bool disposing)
		{
			if (disposedValue) return;
			icp = null;
			disposedValue = true;
		}
	}
}