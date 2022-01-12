using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Vanara.Windows.Shell
{
	/// <summary>The list of thumbnails to be displayed on the taskbar button.</summary>
	/// <seealso cref="System.Collections.ObjectModel.ObservableCollection{T}"/>
	[Serializable]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class TaskbarButtonThumbnails : ObservableCollection<TaskbarButtonThumbnail>
	{
		internal IWin32Window parent;
		private bool hasAddedButtons = false;

		internal TaskbarButtonThumbnails(IWin32Window parent)
		{
			this.parent = parent;
			Toolbar = new ThumbnailToolbar();
			Toolbar.PropertyChanged += (s, e) => ResetToolbar();
			base.CollectionChanged += LocalCollectionChanged;
		}

		/// <summary>Gets or sets the toolbar associated with the taskbar button.</summary>
		/// <value>The toolbar.</value>
		[Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ThumbnailToolbar Toolbar { get; }

		/// <summary>Gets the count.</summary>
		/// <value>The count.</value>
		[Browsable(false)]
		public new int Count => base.Count;

		internal void ResetToolbar()
		{
			if (Toolbar?.ImageList != null)
				TaskbarList.ThumbBarSetImageList(parent.Handle, Toolbar.ImageList.Handle);
			if (Toolbar?.Buttons?.Count > 0)
			{
				if (!hasAddedButtons)
				{
					TaskbarList.ThumbBarAddButtons(parent.Handle, Toolbar.Buttons.ToArray());
					hasAddedButtons = true;
				}
				else
					TaskbarList.ThumbBarUpdateButtons(parent.Handle, Toolbar.Buttons.ToArray());
			}
		}

		private void ActivateThumbnail(TaskbarButtonThumbnail thumbnail)
		{
			if (parent != null)
				TaskbarList.SetTabActive(parent.Handle, thumbnail?.ChildWindow.Handle ?? throw new ArgumentNullException(nameof(thumbnail), "The TaskbarItemTab.ChildWindow property must be set in order to be activated."));
		}

		private void LocalCollectionChanged(object _, NotifyCollectionChangedEventArgs e)
		{
			// If new thumbnails are added, they have to be registered
			if (e.NewItems != null)
			{
				foreach (var item in e.NewItems.Cast<TaskbarButtonThumbnail>())
				{
					item.PropertyChanged += ThmbChanged;
					RegisterThumbnail(item);
				}
			}

			// If new thumbnails are removed, they have to be unregistered
			if (e.OldItems != null)
			{
				foreach (var item in e.OldItems.Cast<TaskbarButtonThumbnail>())
				{
					item.PropertyChanged -= ThmbChanged;
					UnregisterThumbnail(item);
				}
			}

			void ThmbChanged(object s, PropertyChangedEventArgs e) => RefreshThumbnail(s as TaskbarButtonThumbnail);
		}

		private void RefreshThumbnail(TaskbarButtonThumbnail thumbnail)
		{
			if (parent != null && thumbnail.ChildWindow != null)
				TaskbarList.SetTabProperties(thumbnail.ChildWindow.Handle, thumbnail.flag);
		}

		private void RegisterThumbnail(TaskbarButtonThumbnail thumbnail)
		{
			var idx = IndexOf(thumbnail);
			var nxt = idx < Count - 1 ? this[idx + 1] : null;

			if (parent != null && thumbnail.ChildWindow != null)
			{
				TaskbarList.RegisterTab(parent.Handle, thumbnail.ChildWindow.Handle);
				TaskbarList.SetTabOrder(thumbnail.ChildWindow.Handle, nxt?.ChildWindow.Handle ?? default);
				TaskbarList.SetTabProperties(thumbnail.ChildWindow.Handle, thumbnail.flag);
			}
		}

		private void UnregisterThumbnail(TaskbarButtonThumbnail thumbnail)
		{
			if (thumbnail.ChildWindow != null)
				TaskbarList.UnregisterTab(thumbnail.ChildWindow.Handle);
		}
	}
}