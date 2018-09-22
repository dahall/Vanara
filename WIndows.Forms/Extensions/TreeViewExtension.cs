using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Extensions
{
	/// <summary>Extension methods for <see cref="TreeView"/> controls.</summary>
	public static partial class TreeViewExtension
	{
		/// <summary>Sets the explorer theme on this <see cref="TreeView"/> instance.</summary>
		/// <param name="treeView">The tree view on which to set the theme.</param>
		/// <param name="on">If set to <c>true</c> use the Windows Explorer theme, otherwise set to default theme.</param>
		public static void SetExplorerTheme(this TreeView treeView, bool on = true)
		{
			if (Environment.OSVersion.Version.Major >= 6)
			{
				// Make sure the TVS_NOHSCROLL style is set
				treeView.SetStyle((int)TreeViewStyle.TVS_NOHSCROLL);

				// Set explorer theme, set critical properties, and set extended styles
				treeView.SetWindowTheme(on ? "explorer" : null);
				if (!on) return;
				treeView.HotTracking = true;
				treeView.ShowLines = false;
				SendMessage(treeView.Handle, (uint)TreeViewMessage.TVM_SETEXTENDEDSTYLE, (IntPtr)(TreeViewStyleEx.TVS_EX_FADEINOUTEXPANDOS | TreeViewStyleEx.TVS_EX_AUTOHSCROLL), (IntPtr)(TreeViewStyleEx.TVS_EX_FADEINOUTEXPANDOS | TreeViewStyleEx.TVS_EX_AUTOHSCROLL));
			}
		}

		/// <summary>Enumerates child nodes of a given <see cref="TreeNodeCollection"/>.</summary>
		/// <param name="nodes">The <see cref="TreeNodeCollection"/> instance from which to start the enumeration.</param>
		/// <param name="forAllChildren">if set to <c>true</c> also includes child nodes of all child nodes.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> of all <see cref="TreeNode"/> instances in the collection.</returns>
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

		/// <summary>Adds the file system item into a <see cref="TreeView"/> and adds the shell icon associated with it to the <see cref="ImageList"/> of the <c>TreeView</c>.</summary>
		/// <param name="tv">The tree view into which to add the item.</param>
		/// <param name="nodes">The <see cref="TreeNodeCollection"/> that receives the newly created <see cref="TreeNode"/>.</param>
		/// <param name="systemItemPath">The path of the item to add.</param>
		/// <returns>A <see cref="TreeNode"/> instance created </returns>
		public static TreeNode AddSystemItemAsNode(this TreeView tv, TreeNodeCollection nodes, string systemItemPath)
		{
			var ext = Path.GetExtension(systemItemPath);
			if (string.IsNullOrEmpty(ext))
				ext = "5EEB255733234c4dBECF9A128E896A1E";
			//ext = fullName.EndsWith("\\") ? "5EEB255733234c4dBECF9A128E896A1E" : "F9EB930C78D2477c80A51945D505E9C4";
			else if (ext.Equals(".exe", StringComparison.InvariantCultureIgnoreCase) || ext.Equals(".lnk", StringComparison.InvariantCultureIgnoreCase))
				ext = Path.GetFileName(systemItemPath);

			if (!tv.ImageList.Images.ContainsKey(ext))
			{
				try
				{
					tv.ImageList.Images.Add(ext, IconExtension.GetFileIcon(ext, GetIconSizeFromSize(tv.ImageList.ImageSize)));
				}
				catch (ArgumentException ex)
				{
					throw new ArgumentException($"File \"{systemItemPath}\" does" + " not exist!", ex);
				}
			}
			return nodes.Add(systemItemPath, Path.GetFileName(systemItemPath), ext, ext);
		}

		/// <summary>Enumerates all the nodes in the <see cref="TreeView"/>.</summary>
		/// <param name="treeView">The tree view.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> of all <see cref="TreeNode"/> instances in this <see cref="TreeView"/>.</returns>
		public static IEnumerable<TreeNode> EnumerateAllNodes(this TreeView treeView) => AsEnumerable(treeView.Nodes, true);

		private static IconSize GetIconSizeFromSize(Size sz)
		{
			switch (sz.Height)
			{
				case 16: return IconSize.Small;
				case 48: return IconSize.ExtraLarge;
				case 256: return IconSize.Jumbo;
				case 32:
				default:
					return IconSize.Large;
			}
		}
	}
}