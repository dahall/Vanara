using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	/// <summary>A collection of thumbnail toolbar buttons.</summary>
	public class ThumbnailToolbarButtonCollection : ObservableCollection<ThumbnailToolbarButton>
	{
		private const int maxBtns = 7;
		private readonly ThumbnailToolbar Parent;

		internal ThumbnailToolbarButtonCollection()
		{
			CollectionChanged += OnCollectionChanged;
		}

		/// <summary>Adds a sequence of <see cref="ThumbnailToolbarButton"/> instances to the collection.</summary>
		/// <param name="items">The items to add.</param>
		public void AddRange(IEnumerable<ThumbnailToolbarButton> items)
		{
			foreach (var item in items)
				Add(item);
		}

		internal THUMBBUTTON[] ToArray()
		{
			var ret = new THUMBBUTTON[maxBtns];
			for (var i = 0; i < maxBtns; i++)
			{
				if (i < Count)
					ret[i] = this[i].btn;
				else
					ret[i] = THUMBBUTTON.Default;
				ret[i].iId = (uint)i;
			}
			return ret;
		}

		/// <summary>Inserts the item into the collection.</summary>
		/// <param name="index">The index at which to insert.</param>
		/// <param name="item">The item to insert.</param>
		protected override void InsertItem(int index, ThumbnailToolbarButton item)
		{
			if (Count >= maxBtns)
				throw new InvalidOperationException($"A maximum of {maxBtns} buttons may be added to a {nameof(ThumbnailToolbarButtonCollection)}.");
			item.indexer.ImageList = Parent.ImageList;
			base.InsertItem(index, item);
		}

		/// <summary>Called when the collection has changed.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
		protected virtual void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e?.NewItems != null)
				foreach (ThumbnailToolbarButton tbi in e.NewItems)
					tbi.Parent = Parent;
		}
	}
}