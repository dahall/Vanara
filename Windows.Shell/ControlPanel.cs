using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	/// <summary>Provides a means to open Control Panel items and get their paths.</summary>
	public static class ControlPanel
	{
		private static SafeCP cp;

		private static IOpenControlPanel CP => cp != null ? cp.icp : (cp = new SafeCP()).icp;

		/// <summary>Gets the path of a Control Panel item.</summary>
		/// <param name="item">The Control Panel item.</param>
		/// <returns>The path.</returns>
		public static string GetPath(ControlPanelItem item) => GetPath(item.CanonicalName());

		/// <summary>Gets the path of a Control Panel GUID.</summary>
		/// <param name="item">The Control Panel GUID.</param>
		/// <returns>The path.</returns>
		public static string GetPath(Guid item) => GetPath(item.ToString());

		/// <summary>Opens the specified Control Panel item.</summary>
		/// <param name="item">The Control Panel item.</param>
		/// <param name="page">Optional. The Control Panel page.</param>
		/// <exception cref="ArgumentOutOfRangeException">page</exception>
		public static void Open(ControlPanelItem item, string page = null)
		{
			if (page != null && Array.IndexOf(item.ValidPages(), page) == -1) throw new ArgumentOutOfRangeException(nameof(page));
			// TODO: handle minOsVer gracefully
			CP.Open(item.CanonicalName(), page, null);
		}

		private static string GetPath(string item)
		{
			var sb = new System.Text.StringBuilder(1024);
			CP.GetPath(item, sb, (uint)sb.Capacity);
			return sb.ToString();
		}

		private class SafeCP : IDisposable
		{
			internal readonly IOpenControlPanel icp;
			private bool disposedValue = false;

			public SafeCP() { icp = new IOpenControlPanel(); }

			~SafeCP() { Dispose(false); }

			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}

			protected virtual void Dispose(bool disposing)
			{
				if (disposedValue) return;
				Marshal.ReleaseComObject(icp);
				disposedValue = true;
			}
		}
	}
}