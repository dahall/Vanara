using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.SearchApi;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

/// <summary>Represents functionality of the Windows Search Service.</summary>
public static class ShellSearch
{
	private const string systemCatalog = "SystemIndex";
	private static readonly ISearchCatalogManager catMgr;
	private static readonly ISearchManager mgr = new();
	private static readonly IQueryParserManager queryMgr = new();

	static ShellSearch() => catMgr = mgr.GetCatalog(systemCatalog);

	/// <summary>Gets search results for a supplied condition against a list of folders.</summary>
	/// <param name="condition">The search condition.</param>
	/// <param name="displayName">The display name for the search folder.</param>
	/// <param name="searchFolders">The folders in which to perform the search.</param>
	/// <param name="settings">Optional settings for the output view.</param>
	/// <returns>A <see cref="ShellItem"/> which contains the search results.</returns>
	public static ShellItem GetSearchResults(SearchCondition condition, string displayName, IEnumerable<ShellFolder> searchFolders, ShellSearchViewSettings settings = null)
	{
		using var cfactory = ComReleaserFactory.Create(new ISearchFolderItemFactory());
		cfactory.Item.SetPaths(searchFolders);
		return GetSearchResults(cfactory.Item, condition, displayName, settings);
	}

	/// <summary>Gets search results for a supplied condition against a list of folders.</summary>
	/// <param name="condition">The search condition.</param>
	/// <param name="displayName">The display name for the search folder.</param>
	/// <param name="searchFolders">The folder paths in which to perform the search.</param>
	/// <param name="settings">Optional settings for the output view.</param>
	/// <returns>A <see cref="ShellItem"/> which contains the search results.</returns>
	public static ShellItem GetSearchResults(SearchCondition condition, string displayName, IEnumerable<string> searchFolders, ShellSearchViewSettings settings = null)
	{
		using var cfactory = ComReleaserFactory.Create(new ISearchFolderItemFactory());
		cfactory.Item.SetPaths(searchFolders);
		return GetSearchResults(cfactory.Item, condition, displayName, settings);
	}

	private static ShellItem GetSearchResults(ISearchFolderItemFactory factory, SearchCondition condition, string displayName, ShellSearchViewSettings settings)
	{
		factory.SetDisplayName(displayName ?? "");
		factory.SetCondition(condition?.condition ?? throw new ArgumentNullException(nameof(condition)));
		if (settings != null)
		{
			factory.SetFolderTypeID(settings.FolderTypeID.Guid());
			if (settings.FolderLogicalViewMode.HasValue) factory.SetFolderLogicalViewMode(settings.FolderLogicalViewMode.Value);
			if (settings.IconSize.HasValue) factory.SetIconSize(settings.IconSize.Value);
			if (settings.VisibleColumns != null) factory.SetVisibleColumns((uint)settings.VisibleColumns.Length, settings.VisibleColumns);
			if (settings.SortColumns != null) factory.SetSortColumns((uint)settings.SortColumns.Length, settings.SortColumns);
			if (settings.GroupColumn.HasValue) factory.SetGroupColumn(settings.GroupColumn.Value);
			if (settings.StackKeys != null) factory.SetStacks((uint)settings.StackKeys.Length, settings.StackKeys);
		}
		return factory.GetShellItem();
	}

	private static ShellItem GetShellItem(this ISearchFolderItemFactory f) => ShellItem.Open(f.GetShellItem<IShellItem>());

	private static void SetPaths(this ISearchFolderItemFactory f, IEnumerable<string> paths) =>
		SetPaths(f, paths.Select(p => new ShellFolder(p)));

	private static void SetPaths(this ISearchFolderItemFactory f, IEnumerable<ShellFolder> paths)
	{
		var pa = paths?.ToArray();
		if (pa != null && pa.Length > 0)
		{
			SHCreateShellItemArrayFromIDLists((uint)pa.Length, Array.ConvertAll(pa, i => (IntPtr)i.PIDL), out var ia).ThrowIfFailed();
			f.SetScope(ia);
		}
		else
			f.SetScope(null);
	}
}

/// <summary>Settings that change the folder view of a search.</summary>
public class ShellSearchViewSettings
{
	/// <summary>The folder logical view mode. The default settings are based on the which is set by the FolderTypeID property.</summary>
	public FOLDERLOGICALVIEWMODE? FolderLogicalViewMode { get; set; }

	/// <summary>The search folder type ID.</summary>
	public FOLDERTYPEID FolderTypeID { get; set; } = FOLDERTYPEID.FOLDERTYPEID_GenericLibrary;

	/// <summary>The group column. If no group column is specified, no grouping occurs.</summary>
	public PROPERTYKEY? GroupColumn { get; set; }

	/// <summary>The search folder icon size. The default settings are based on the which is set by the FolderTypeID property.</summary>
	public int? IconSize { get; set; }

	/// <summary>A list of sort column directions.</summary>
	public SORTCOLUMN[] SortColumns { get; set; }

	/// <summary>A list of stack keys, as specified. If <see langword="null"/>, the folder will not be stacked.</summary>
	public PROPERTYKEY[] StackKeys { get; set; }

	/// <summary>A list of which columns are all visible. The default is based on <c>FolderTypeID</c>.</summary>
	public PROPERTYKEY[] VisibleColumns { get; set; }
}