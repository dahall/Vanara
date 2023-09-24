using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.User32;

namespace Vanara.Extensions;

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

	/// <summary>Sets the <see cref="TVITEM"/> values.</summary>
	/// <param name="node">The <see cref="TreeNode"/> instance for which to set details.</param>
	/// <param name="tvItem">The <see cref="TVITEMEX"/> instance.</param>
	public static bool SetItem(this TreeNode node, ref TVITEMEX tvItem) => SendMessage(node.TreeView.Handle, TreeViewMessage.TVM_SETITEM, default, ref tvItem).ToInt32() != 0;

	/// <summary>Gets the node values.</summary>
	/// <param name="node">The <see cref="TreeNode"/> instance for which to get details.</param>
	/// <param name="mask">The mask of items to get.</param>
	/// <param name="stateMask">The mask of states to get.</param>
	/// <returns>A <see cref="TVITEMEX"/> structure with the information.</returns>
	public static TVITEMEX GetItem(this TreeNode node, TreeViewItemMask mask = (TreeViewItemMask)0x13FF, TreeViewItemStates stateMask = (TreeViewItemStates)0xFFFF)
	{
		var tvItem = new TVITEMEX
		{
			hItem = node.Handle,
			mask = mask.SetFlags(TreeViewItemMask.TVIF_HANDLE).SetFlags(TreeViewItemMask.TVIF_TEXT, false),
			stateMask = stateMask
		};
		SendMessage(node.TreeView.Handle, TreeViewMessage.TVM_GETITEM, default, ref tvItem);
		return tvItem;
	}

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