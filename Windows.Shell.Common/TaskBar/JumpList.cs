using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

/// <summary>Represents a Jump List item.</summary>
/// <seealso cref="INotifyPropertyChanged"/>
public interface IJumpListItem : INotifyPropertyChanged
{
	/// <summary>Gets the category to which the item belongs.</summary>
	/// <value>The category name.</value>
	string? Category { get; }

	/// <summary>Creates a shell object based on this item.</summary>
	/// <returns>An instance of either <see cref="IShellItem"/> or <see cref="IShellLinkW"/>.</returns>
	object GetShellObject();
}

/// <summary>Provides access to the jump list on the application's task bar icon.</summary>
[TypeConverter(typeof(GenericExpandableObjectConverter<JumpList>))]
[Editor("Vanara.Windows.Shell.JumpListItemCollectionEditor, Vanara.Windows.Shell", "System.Drawing.Design.UITypeEditor, System.Drawing")]
[Description("Provides access to the jump list on the application's task bar icon.")]
public class JumpList : ObservableCollection<IJumpListItem>
{
	/// <summary>Initializes a new instance of the <see cref="JumpList"/> class.</summary>
	public JumpList() => CollectionChanged += OnCollectionChanged;

	/// <summary>Gets the number of items in the collection.</summary>
	/// <value>The count.</value>
	[Browsable(false)]
	public new int Count => base.Count;

	/// <summary>Whether to show the special "Frequent" category.</summary>
	/// <remarks>
	/// This category is managed by the Shell and keeps track of items that are frequently accessed by this program. Applications can
	/// request that specific items are included here by calling JumpList.AddToRecentCategory. Because of duplication, applications
	/// generally should not have both ShowRecentCategory and ShowFrequentCategory set at the same time.
	/// </remarks>
	[Category("Appearance"), DefaultValue(false)]
	[Description("Gets or sets Whether to show the special \"Frequent\" category.")]
	public bool ShowFrequentCategory { get; set; }

	/// <summary>Whether to show the special "Recent" category.</summary>
	/// <remarks>
	/// This category is managed by the Shell and keeps track of items that have been recently accessed by this program. Applications
	/// can request that specific items are included here by calling JumpList.AddToRecentCategory Because of duplication, applications
	/// generally should not have both ShowRecentCategory and ShowFrequentCategory set at the same time.
	/// </remarks>
	[Category("Appearance"), DefaultValue(false)]
	[Description("Gets or sets Whether to show the special \"Recent\" category.")]
	public bool ShowRecentCategory { get; set; }

	/// <summary>
	/// Notifies the system that an item has been accessed, for the purposes of tracking those items used most recently and most frequently.
	/// </summary>
	/// <param name="docPath">The document path to add.</param>
	public static void AddToRecentDocs(string docPath)
	{
		if (docPath is null) throw new ArgumentNullException(nameof(docPath));
		SHAddToRecentDocs(SHARD.SHARD_PATHW, System.IO.Path.GetFullPath(docPath));
	}

	/// <summary>
	/// Notifies the system that an item has been accessed, for the purposes of tracking those items used most recently and most frequently.
	/// </summary>
	/// <param name="iShellItem">The <see cref="IShellItem"/> to add.</param>
	public static void AddToRecentDocs(IShellItem iShellItem)
	{
		if (iShellItem is null) throw new ArgumentNullException(nameof(iShellItem));
		SHAddToRecentDocs(SHARD.SHARD_SHELLITEM, iShellItem);
	}

	/// <summary>
	/// Notifies the system that an item has been accessed, for the purposes of tracking those items used most recently and most frequently.
	/// </summary>
	/// <param name="iShellLink">The <see cref="IShellLinkW"/> to add.</param>
	/// <exception cref="ArgumentNullException">iShellLink</exception>
	public static void AddToRecentDocs(IShellLinkW iShellLink)
	{
		if (iShellLink is null) throw new ArgumentNullException(nameof(iShellLink));
		SHAddToRecentDocs(SHARD.SHARD_LINK, iShellLink);
	}

	/// <summary>
	/// Notifies the system that an item has been accessed, for the purposes of tracking those items used most recently and most frequently.
	/// </summary>
	/// <param name="shellItem">The <see cref="ShellItem"/> to add.</param>
	/// <exception cref="ArgumentNullException">shellItem</exception>
	public static void AddToRecentDocs(ShellItem shellItem)
	{
		if (shellItem is null) throw new ArgumentNullException(nameof(shellItem));
		if (shellItem is ShellLink lnk)
			AddToRecentDocs(lnk.link);
		else
			AddToRecentDocs(shellItem.IShellItem);
	}

	/// <summary>Clears the system usage data for recent documents.</summary>
	public static void ClearRecentDocs() => SHAddToRecentDocs(0);

	/// <summary>Deletes a custom Jump List for a specified application.</summary>
	/// <param name="appId">The AppUserModelID of the process whose taskbar button representation displays the custom Jump List.</param>
	public static void DeleteList(string? appId = null)
	{
		using var icdl = ComReleaserFactory.Create(new ICustomDestinationList());
		icdl.Item.DeleteList(appId);
	}

	/// <summary>Applies the the current settings for the jumplist to the taskbar button.</summary>
	/// <param name="appId">The application identifier.</param>
	public void ApplySettings(string? appId = null)
	{
		using var icdl = ComReleaserFactory.Create(new ICustomDestinationList());
		if (!string.IsNullOrEmpty(appId))
			icdl.Item.SetAppID(appId);

		using var ioaRemoved = ComReleaserFactory.Create(icdl.Item.BeginList<IObjectArray>(out _));
		var removedObjs = ioaRemoved.Item.ToArray<object>();
		var exceptions = new System.Collections.Generic.List<Exception>();
		foreach (var cat in this.GroupBy(i => i.Category))
		{
			using var poc = ComReleaserFactory.Create(new IObjectCollection());
			foreach (var o in cat)
			{
				using var psho = ComReleaserFactory.Create(o.GetShellObject());
				if (!IsRemoved(psho.Item))
					poc.Item.AddObject(psho.Item);
			}
			if (cat.Key is null)
				icdl.Item.AddUserTasks(poc.Item);
			else
			{
				try { icdl.Item.AppendCategory(cat.Key, poc.Item); }
				catch (COMException cex) when (cex.ErrorCode == DESTS_E_NO_MATCHING_ASSOC_HANDLER)
				{ exceptions.Add(new InvalidOperationException($"At least one of the destinations in the '{cat.Key}' category has an extension that is not registered to this application.")); }
			}
		}

		if (ShowFrequentCategory)
			icdl.Item.AppendKnownCategory(KNOWNDESTCATEGORY.KDC_FREQUENT);

		if (ShowRecentCategory)
			icdl.Item.AppendKnownCategory(KNOWNDESTCATEGORY.KDC_RECENT);

		icdl.Item.CommitList();

		if (exceptions.Count > 0)
			throw new AggregateException(exceptions);

		bool IsRemoved(object shellObj)
		{
			if (shellObj is IShellItem shi)
			{
				return Array.Exists(removedObjs, o => o is IShellItem oi && ShellItem.Equals(shi, oi));
			}
			else if (shellObj is IShellLinkW shl)
			{
				var cstring = ShellLink.GetCompareString(shl);
				return Array.Exists(removedObjs, o => o is IShellLinkW l && cstring == ShellLink.GetCompareString(l));
			}
			return false;
		}
	}

	private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Add && (e.NewItems is null || e.NewItems.OfType<JumpListDestination>().Any(d => string.IsNullOrEmpty(d.Category))))
			throw new InvalidOperationException("A JumpListDestination cannot have a null category.");
	}
}

/// <summary>A file-based destination for a jumplist with an associated category.</summary>
public class JumpListDestination : JumpListItem, IJumpListItem
{
	private string path;

	/// <summary>Initializes a new instance of the <see cref="JumpListDestination"/> class.</summary>
	public JumpListDestination(string? category, string path)
	{
		if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
		Category = category;
		this.path = path;
	}

	/// <summary>The shell item to reference or execute.</summary>
	[Editor("System.Windows.Forms.Design.FileNameEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
	[DefaultValue(null)]
	public string Path
	{
		get => path;
		set
		{
			if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(Path));
			if (!string.Equals(path, value))
			{
				path = value;
				OnPropertyChanged();
			}
		}
	}

	/// <summary>Converts to string.</summary>
	/// <returns>A <see cref="string"/> that represents this instance.</returns>
	public override string ToString() => $"{Category}:{Path}";

	/// <summary>Creates a shell object based on this item.</summary>
	/// <returns>An interface.</returns>
	object IJumpListItem.GetShellObject() => ShellUtil.GetShellItemForPath(System.IO.Path.GetFullPath(Path))!;
}

/// <summary>An item in a Jump List.</summary>
[TypeConverter(typeof(GenericExpandableObjectConverter<JumpListItem>))]
public abstract class JumpListItem : INotifyPropertyChanged
{
	private string? category;

	/// <summary>Occurs when a property value changes.</summary>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>Gets or sets the category to which the item belongs.</summary>
	/// <value>The category name.</value>
	public string? Category
	{
		get => category;
		set
		{
			if (category != value)
			{
				category = value;
				OnPropertyChanged();
			}
		}
	}

	/// <summary>Called when a property has changed.</summary>
	/// <param name="propertyName">Name of the property.</param>
	protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "") =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

/// <summary>A separator which can be inserted into a custom list or task list.</summary>
public class JumpListSeparator : JumpListItem, IJumpListItem
{
	/// <summary>Initializes a new instance of the <see cref="JumpListSeparator"/> class and optionally assigns it to a category.</summary>
	/// <param name="category">The category name. If this value is <see langword="null"/>, this separator will be inserted into the task list.</param>
	public JumpListSeparator(string? category = null) => Category = category;

	/// <summary>Creates a shell object based on this item.</summary>
	/// <returns>An instance of either <see cref="IShellItem"/> or <see cref="IShellLinkW"/>.</returns>
	object IJumpListItem.GetShellObject()
	{
		var link = new IShellLinkW();
		var props = (IPropertyStore)link;
		props?.SetValue(PROPERTYKEY.System.AppUserModel.IsDestListSeparator, true);
		return link;
	}
}

/// <summary>A task for a jumplist.</summary>
/// <seealso cref="JumpListItem"/>
/// <remarks>Initializes a new instance of the <see cref="JumpListTask"/> class.</remarks>
public class JumpListTask(string? title, string applicationPath) : JumpListItem, IJumpListItem
{
	private int iconResIdx = -1;
	private string? description, args, dir, iconPath, appUserModelID;

	/// <summary>Gets or sets the application path.</summary>
	/// <value>The application path.</value>
	/// <exception cref="ArgumentNullException">ApplicationPath</exception>
	[DefaultValue(null)]
	[Editor("System.Windows.Forms.Design.FileNameEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
	public string ApplicationPath
	{
		get => applicationPath;
		set
		{
			if (value is null) throw new ArgumentNullException(nameof(ApplicationPath));
			if (applicationPath == value) return;
			applicationPath = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Gets or sets an explicit Application User Model ID used to associate processes, files, and windows with a particular application.
	/// </summary>
	/// <value>The application path.</value>
	/// <remarks>
	/// An application must provide its AppUserModelID in the following form. It can have no more than 128 characters and cannot contain
	/// spaces. Each section should be camel-cased.
	/// <para><c>CompanyName.ProductName.SubProduct.VersionInformation</c></para>
	/// <para>
	/// CompanyName and ProductName should always be used, while the SubProduct and VersionInformation portions are optional and depend
	/// on the application's requirements. SubProduct allows a main application that consists of several subapplications to provide a
	/// separate taskbar button for each subapplication and its associated windows. VersionInformation allows two versions of an
	/// application to coexist while being seen as discrete entities. If an application is not intended to be used in that way, the
	/// VersionInformation should be omitted so that an upgraded version can use the same AppUserModelID as the version that it replaced.
	/// </para>
	/// </remarks>
	[DefaultValue(null)]
	public string? AppUserModelID
	{
		get => appUserModelID;
		set
		{
			if (appUserModelID == value) return;
			if (value is not null && (value.Length > 128 || value.Contains(' ')))
				throw new ArgumentException("Invalid format.");
			appUserModelID = value;
			OnPropertyChanged();
		}
	}

	/// <summary>Gets or sets the arguments.</summary>
	/// <value>The arguments.</value>
	[DefaultValue(null)]
	public string? Arguments
	{
		get => args;
		set
		{
			if (args == value) return;
			args = value;
			OnPropertyChanged();
		}
	}

	/// <summary>Gets or sets the description.</summary>
	/// <value>The description.</value>
	[DefaultValue(null)]
	public string? Description
	{
		get => description;
		set
		{
			if (description == value) return;
			description = value;
			OnPropertyChanged();
		}
	}

	/// <summary>Gets or sets the index of the icon resource.</summary>
	/// <value>The index of the icon resource.</value>
	[DefaultValue(-1)]
	public int IconResourceIndex
	{
		get => iconResIdx;
		set
		{
			if (iconResIdx == value) return;
			iconResIdx = value;
			OnPropertyChanged();
		}
	}

	/// <summary>Gets or sets the icon resource path.</summary>
	/// <value>The icon resource path.</value>
	/// <exception cref="ArgumentException">Length of path may not exceed 260 characters. - IconResourcePath</exception>
	[DefaultValue(null)]
	[Editor("System.Windows.Forms.Design.FileNameEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
	public string? IconResourcePath
	{
		get => iconPath;
		set
		{
			if (iconPath == value) return;
			if (iconPath != null && iconPath.Length > Kernel32.MAX_PATH)
				throw new ArgumentException("Length of path may not exceed 260 characters.", nameof(IconResourcePath));
			iconPath = value;
			OnPropertyChanged();
		}
	}

	/// <summary>Gets or sets the title.</summary>
	/// <value>The title.</value>
	/// <exception cref="ArgumentNullException">Title</exception>
	[DefaultValue(null)]
	public string? Title
	{
		get => title;
		set
		{
			if (value is null) throw new ArgumentNullException(nameof(Title));
			if (title == value) return;
			title = value;
			OnPropertyChanged();
		}
	}

	/// <summary>Gets or sets the working directory.</summary>
	/// <value>The working directory.</value>
	[DefaultValue(null)]
	[Editor("System.Windows.Forms.Design.FolderNameEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
	public string? WorkingDirectory
	{
		get => dir;
		set
		{
			if (dir == value) return;
			dir = value;
			OnPropertyChanged();
		}
	}

	/// <summary>Converts to string.</summary>
	/// <returns>A <see cref="string"/> that represents this instance.</returns>
	public override string ToString() => $"{Category}:{ApplicationPath}";

	/// <summary>Creates a shell object based on this item.</summary>
	/// <returns>An interface.</returns>
	object IJumpListItem.GetShellObject()
	{
		var link = new IShellLinkW();

		link.SetPath(ApplicationPath);

		if (!string.IsNullOrEmpty(AppUserModelID))
			(link as IPropertyStore)?.SetValue(PROPERTYKEY.System.AppUserModel.ID, AppUserModelID);

		if (!string.IsNullOrEmpty(WorkingDirectory))
			link.SetWorkingDirectory(WorkingDirectory);

		if (!string.IsNullOrEmpty(Arguments))
			link.SetArguments(Arguments);

		// -1 is a sentinel value indicating not to use the icon.
		if (IconResourceIndex != -1)
			link.SetIconLocation(IconResourcePath ?? ApplicationPath, IconResourceIndex);

		if (!string.IsNullOrEmpty(Description))
			link.SetDescription(Description);

		if (!string.IsNullOrEmpty(Title))
			(link as IPropertyStore)?.SetValue(PROPERTYKEY.System.Title, Title);

		return link;
	}
}

internal class GenericExpandableObjectConverter<T> : ExpandableObjectConverter
{
	public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destType) =>
		destType == typeof(InstanceDescriptor) || destType == typeof(string) || base.CanConvertTo(context, destType);

	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? info, object? value, Type destType)
	{
		if (destType == typeof(InstanceDescriptor))
			return new InstanceDescriptor(typeof(T).GetConstructor([]), null, false);
		if (destType == typeof(string))
			return "";
		return base.ConvertTo(context, info, value, destType);
	}
}