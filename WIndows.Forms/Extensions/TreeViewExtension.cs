using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Extensions
{
	public static partial class TreeViewExtension
	{
		private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
		private const int TVS_EX_FADEINOUTEXPANDOS = 0x0040;
		private const int TVS_EX_AUTOHSCROLL = 0x0020;
		private const int TVS_NOHSCROLL = 0x8000;

		public static void SetExplorerTheme(this TreeView treeView, bool on = true)
		{
			if (System.Environment.OSVersion.Version.Major >= 6)
			{
				// Make sure the TVS_NOHSCROLL style is set
				treeView.SetStyle(TVS_NOHSCROLL);

				// Set explorer theme, set critical properties, and set extended styles
				treeView.SetWindowTheme(on ? "explorer" : null);
				if (!on) return;
				treeView.HotTracking = true;
				treeView.ShowLines = false;
				SendMessage(new HandleRef(treeView, treeView.Handle), TVM_SETEXTENDEDSTYLE, TVS_EX_FADEINOUTEXPANDOS | TVS_EX_AUTOHSCROLL, TVS_EX_FADEINOUTEXPANDOS | TVS_EX_AUTOHSCROLL);
			}
		}

		public static void ForEach(this TreeNodeCollection nodes, Action<TreeNode> action, bool forAllChildren = false)
		{
			Action<TreeNode> traverse = null;
			traverse = n => { action(n); if (forAllChildren) foreach (TreeNode n1 in n.Nodes) traverse(n1); };
			foreach (TreeNode n in nodes) traverse(n);
		}

		public static IEnumerable<TreeNode> AsEnumerable(this TreeNodeCollection nodes, bool forAllChildren = false)
		{
			foreach (TreeNode item in nodes)
			{
				yield return item;
				if (forAllChildren)
					foreach (var child in item.Nodes.AsEnumerable(true))
						yield return child;
			}
		}
	}
}