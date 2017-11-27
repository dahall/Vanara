#if (NET20)
namespace System.Collections.Specialized
{
	/// <summary>
	/// Stub
	/// </summary>
	public interface INotifyCollectionChanged
	{
		/// <summary>
		/// Stub
		/// </summary>
		event NotifyCollectionChangedEventHandler CollectionChanged;
	}

	/// <summary>
	/// Stub
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
	public delegate void NotifyCollectionChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e);

	/// <summary>
	/// Stub
	/// </summary>
	public class NotifyCollectionChangedEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NotifyCollectionChangedEventArgs"/> class.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <param name="newItems">The new items.</param>
		/// <param name="oldItems">The old items.</param>
		/// <param name="newIndex">The new index.</param>
		/// <param name="oldIndex">The old index.</param>
		internal NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems, int newIndex, int oldIndex)
		{
			Action = action;
			NewItems = newItems;
			NewStartingIndex = newIndex;
			OldItems = oldItems;
			OldStartingIndex = oldIndex;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NotifyCollectionChangedEventArgs"/> class.
		/// </summary>
		/// <param name="action">The action.</param>
		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action) :
			this(action, null, null, -1, -1) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="NotifyCollectionChangedEventArgs"/> class.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <param name="item">The item.</param>
		/// <param name="idx">The index.</param>
		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object item, int idx = -1) :
			this(action, new object[] { item }, null, idx, -1) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="NotifyCollectionChangedEventArgs"/> class.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <param name="item">The item.</param>
		/// <param name="item2">The item2.</param>
		/// <param name="idx">The index.</param>
		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object item, object item2, int idx) :
			this(action, new object[] { item }, new object[] { item2 }, idx, -1) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="NotifyCollectionChangedEventArgs"/> class.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <param name="newItems">The new items.</param>
		public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList newItems) :
			this(action, newItems, null, -1, -1) { }

		/// <summary>
		/// Gets the action.
		/// </summary>
		/// <value>
		/// The action.
		/// </value>
		public NotifyCollectionChangedAction Action { get; }
		/// <summary>
		/// Gets the new items.
		/// </summary>
		/// <value>
		/// The new items.
		/// </value>
		public IList NewItems { get; }
		/// <summary>
		/// Gets the new index of the starting.
		/// </summary>
		/// <value>
		/// The new index of the starting.
		/// </value>
		public int NewStartingIndex { get; }
		/// <summary>
		/// Gets the old items.
		/// </summary>
		/// <value>
		/// The old items.
		/// </value>
		public IList OldItems { get; }
		/// <summary>
		/// Gets the old index of the starting.
		/// </summary>
		/// <value>
		/// The old index of the starting.
		/// </value>
		public int OldStartingIndex { get; }
	}

	/// <summary>
	/// Stub
	/// </summary>
	public enum NotifyCollectionChangedAction
	{
		/// <summary>
		/// The add
		/// </summary>
		Add = 0,
		/// <summary>
		/// The move
		/// </summary>
		Move = 3,
		/// <summary>
		/// The remove
		/// </summary>
		Remove = 1,
		/// <summary>
		/// The replace
		/// </summary>
		Replace = 2,
		/// <summary>
		/// The reset
		/// </summary>
		Reset = 4
	}
}
#endif