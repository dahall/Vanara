using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Collections;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

/// <summary>Exposes a list of categorizers registered on an IShellFolder.</summary>
public class ShellFolderCategorizer : IEnumerable<ShellFolderCategory>
{
	internal ShellFolderCategorizer(IShellFolder folder) => ICategoryProvider = folder.CreateViewObject<ICategoryProvider>(default);

	/// <summary>Gets the default category.</summary>
	public ShellFolderCategory DefaultCategory
	{
		get
		{
			var hr = ICategoryProvider.GetDefaultCategory(out var guid, out _);
			if (hr == HRESULT.S_OK)
				return GetCat(guid);
			if (hr == HRESULT.S_FALSE)
				return null;
			throw hr.GetException();
		}
	}

	/// <summary>Gets the underlying <see cref="ICategoryProvider"/> instance.</summary>
	public ICategoryProvider ICategoryProvider { get; private set; }

	/// <summary>Gets the <see cref="ShellFolderCategory"/> with the specified shell column.</summary>
	/// <param name="scid">The shell column identifier.</param>
	/// <returns>The <see cref="ShellFolderCategory"/> value.</returns>
	public ShellFolderCategory this[in PROPERTYKEY scid] => ICategoryProvider.GetCategoryForSCID(scid, out var guid) == HRESULT.S_OK
		? GetCat(guid) : throw new IndexOutOfRangeException();

	/// <summary>Determines whether a column can be used as a category.</summary>
	/// <param name="scid">The shell column identifier.</param>
	/// <returns><see langword="true"/> if the specified shell column identifier can be used as a category; otherwise, <see langword="false"/>.</returns>
	public bool CanCategorizeOnSCID(in PROPERTYKEY scid) => ICategoryProvider.CanCategorizeOnSCID(scid) == HRESULT.S_OK;

	/// <inheritdoc/>
	public IEnumerator<ShellFolderCategory> GetEnumerator()
	{
		if (ICategoryProvider.EnumCategories(out IEnumGUID penum) == HRESULT.S_OK)
			return new IEnumFromCom<Guid>(penum.Next, penum.Reset).Select(g => GetCat(g)).GetEnumerator();
		return Enumerable.Empty<ShellFolderCategory>().GetEnumerator();
	}

	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	private ShellFolderCategory GetCat(Guid catid)
	{
		StringBuilder sb = new(1024);
		ICategoryProvider.GetCategoryName(catid, sb, (uint)sb.Capacity);
		return new ShellFolderCategory(ICategoryProvider.CreateCategory(catid), catid, sb.ToString());
	}
}

/// <summary>A shell folder category object.</summary>
public class ShellFolderCategory : IEquatable<ShellFolderCategory>
{
	private readonly ICategorizer icat;
	private readonly Guid id;

	internal ShellFolderCategory(ICategorizer cat, Guid id, string name)
	{
		icat = cat;
		this.id = id;
		Name = name;
	}

	/// <summary>Gets the name of the category.</summary>
	/// <value>The category name.</value>
	public string Name { get; }

	/* NOTE: I think this always is the same as Name.
	private string desc;
	private string Description
	{
		get
		{
			if (desc == null)
			{
				StringBuilder sb = new(1024);
				icat.GetDescription(sb, (uint)sb.Capacity);
				desc = sb.ToString();
			}
			return desc;
		}
	}*/

	/// <summary>Compares the category.</summary>
	/// <param name="flags">The flags.</param>
	/// <param name="categoryId1">The category id1.</param>
	/// <param name="categoryId2">The category id2.</param>
	/// <returns></returns>
	public int CompareCategory(CATSORT_FLAGS flags, uint categoryId1, uint categoryId2) => icat.CompareCategory(flags, categoryId1, categoryId2).Code;

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns><see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.</returns>
	public bool Equals(ShellFolderCategory other) => id == other.id;

	/// <summary>Gets a list of categories associated with a list of identifiers.</summary>
	/// <param name="items">An array of item identifiers.</param>
	/// <returns>An array of category identifiers.</returns>
	public uint[] GetCategoryIdForItems([In] PIDL[] items)
	{
		uint[] ret = new uint[items.Length];
		icat.GetCategory((uint)items.Length, Array.ConvertAll(items, i => i.DangerousGetHandle()), ret).ThrowIfFailed();
		return ret;
	}

	/// <summary>Gets information about a category, such as the default display and the text to display in the UI.</summary>
	/// <param name="categoryId">Specifies a category identifier.</param>
	/// <returns>A flag from CATEGORYINFO_FLAGS that specifies the type of information to retrieve and the name of the category.</returns>
	public (CATEGORYINFO_FLAGS flags, string name) GetCategoryInfo(uint categoryId)
	{
		icat.GetCategoryInfo(categoryId, out var info).ThrowIfFailed();
		return (info.cif, info.wszName);
	}
}