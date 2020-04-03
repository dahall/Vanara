using System.ComponentModel;
using System.Windows.Forms;

namespace Vanara.Windows.Shell
{
	/// <summary>The toolbar associated with thumbnails shown when hovering over an application's taskbar button.</summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged"/>
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class ThumbnailToolbar : INotifyPropertyChanged
	{
		private ImageList _imageList;

		/// <summary>Initializes a new instance of the <see cref="ThumbnailToolbar"/> class.</summary>
		public ThumbnailToolbar()
		{
			Buttons = new ThumbnailToolbarButtonCollection(this);
			Buttons.CollectionChanged += (s, e) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Buttons)));
		}

		/// <summary>Occurs when a property has changed.</summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>Gets the buttons.</summary>
		/// <value>The buttons.</value>
		[Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ThumbnailToolbarButtonCollection Buttons { get; }

		/// <summary>Gets or sets the image list for use by the toolbar buttons.</summary>
		/// <value>The image list.</value>
		public ImageList ImageList
		{
			get => _imageList;
			set
			{
				if (ReferenceEquals(_imageList, value)) return;
				_imageList = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageList)));
			}
		}
	}
}