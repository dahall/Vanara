using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

/// <summary>Specifies taskbar button thumbnail tab properties.</summary>
public enum TaskbarItemTabThumbnailOption
{
	/// <summary>The tab window provides a thumbnail and peek image, either live or static as appropriate.</summary>
	TabWindow = 0,

	/// <summary>
	/// Always use the thumbnail or peek image provided by the main application frame window rather than a thumbnail or peek image
	/// provided by the individual tab window.
	/// </summary>
	MainWindow = 1,

	/// <summary>
	/// When the application tab is active and a live representation of its window is available, use the main application's frame window
	/// as the thumbnail or peek feature. At other times, use the tab window thumbnail or peek feature.
	/// </summary>
	MainWindowWhenActive = 2,
}

//[TypeConverter(typeof(TaskbarItemTabConverter))]
//[Serializable]
/// <summary></summary>
/// <seealso cref="INotifyPropertyChanged"/>
public class TaskbarButtonThumbnail : INotifyPropertyChanged //, ISerializable
{
	internal STPFLAG flag = 0;
	[MaybeNull]
	private Control tabWin;

	/// <summary>Initializes a new instance of the <see cref="TaskbarButtonThumbnail"/> class.</summary>
	public TaskbarButtonThumbnail()
	{
	}

	/// <summary>Initializes a new instance of the <see cref="TaskbarButtonThumbnail"/> class.</summary>
	/// <param name="tabWindow">The tab window.</param>
	public TaskbarButtonThumbnail(Control tabWindow) => ChildWindow = tabWindow;

	/*private TaskbarItemTab(SerializationInfo info, StreamingContext context)
	{
		flag = (STPFLAG)info.GetValue(nameof(flag), flag.GetType());
		TabWindow = (Control)info.GetValue(nameof(ChildWindow), typeof(Control));
	}

	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(nameof(ChildWindow), tabWin, typeof(Control));
		info.AddValue(nameof(flag), flag, flag.GetType());
	}*/

	/// <summary>Occurs when a property has changed.</summary>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>Gets or sets the child window whose image will be displayed in this thumbnail.</summary>
	/// <value>The child window.</value>
	[DefaultValue(null), Category("Appearance")]
	[MemberNotNull(nameof(tabWin))]
	public Control ChildWindow
	{
		get => tabWin ?? throw new ArgumentNullException(nameof(ChildWindow), "Child window not specified for tab.");
		set
		{
			if (ReferenceEquals(tabWin, value ?? throw new ArgumentNullException(nameof(ChildWindow), "Child window must be specified for tab.")))
				return;
			tabWin = value;
			//if (Parent != null)
			//{
			//	var idx = Parent.Thumbnails.IndexOf(this);
			//	var nextTab = (idx < (Parent.Thumbnails.Count - 1)) ? Parent.Thumbnails[idx + 1] : null;
			//	Register(nextTab);
			//}
			OnPropertyChanged();
		}
	}

	/// <summary>Gets or sets the peek image provider.</summary>
	/// <value>The peek image provider.</value>
	[DefaultValue(typeof(TaskbarItemTabThumbnailOption), "TabWindow"), Category("Appearance")]
	public TaskbarItemTabThumbnailOption PeekImageProvider
	{
		get => (TaskbarItemTabThumbnailOption)(((int)flag & 0xC) >> 2);
		set { flag = (STPFLAG)(((int)flag & 0x3) | ((int)value << 2)); OnPropertyChanged(); }
	}

	/// <summary>Gets or sets the thumbnail provider.</summary>
	/// <value>The thumbnail provider.</value>
	[DefaultValue(typeof(TaskbarItemTabThumbnailOption), "TabWindow"), Category("Appearance")]
	public TaskbarItemTabThumbnailOption ThumbnailProvider
	{
		get => (TaskbarItemTabThumbnailOption)((int)flag & 0x3);
		set { flag = (STPFLAG)(((int)flag & 0xC) | (int)value); OnPropertyChanged(); }
	}

	/// <summary>Called when [property changed].</summary>
	/// <param name="propertyName">Name of the property.</param>
	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

/*internal class TaskbarItemTabConverter : TypeConverter
{
	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == null)
			throw new ArgumentNullException(nameof(destinationType));
		if (destinationType == typeof(InstanceDescriptor))
		{
			TaskbarItemTab tab = (TaskbarItemTab)value;
			var ci = typeof(TaskbarItemTab).GetConstructor((tab.ChildWindow == null) ? Type.EmptyTypes : new Type[] { typeof(Control) });
			if (ci != null)
				return new InstanceDescriptor(ci, (tab.ChildWindow == null) ? null : new object[] { tab.ChildWindow }, false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}*/