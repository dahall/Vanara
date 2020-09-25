using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;

namespace Vanara.Collections
{
	/// <summary>Provides an interface for a history of items.</summary>
	public interface IHistory<T> : IEnumerable<T>, INotifyCollectionChanged, INotifyPropertyChanged
	{
		/// <summary>Indicates the presence of items in the history that can be reached by calling <see cref="SeekBackward"/>.</summary>
		/// <value><see langword="true"/> if this instance can seek backward; otherwise, <see langword="false"/>.</value>
		bool CanSeekBackward { get; }

		/// <summary>Indicates the presence of items in the history that can be reached by calling <see cref="SeekForward"/>.</summary>
		/// <value><see langword="true"/> if this instance can seek forward; otherwise, <see langword="false"/>.</value>
		bool CanSeekForward { get; }

		/// <summary>Gets the items in the history.</summary>
		/// <value>The number of items.</value>
		int Count { get; }

		/// <summary>Gets the value at a pointer within the history that represents the current item.</summary>
		/// <value>The current item.</value>
		/// <exception cref="System.InvalidOperationException">There are no items in the history.</exception>
		T Current { get; }

		/// <summary>Adds the specified item as the last history entry and sets the <see cref="Current"/> property to it's value.</summary>
		/// <param name="item">The item to add to the history.</param>
		/// <param name="removeForwardItems"><see langword="true" /> indicates to remove all items forward of the current pointer; <see langword="false"/> leaves the history intact.</param>
		void Add(T item, bool removeForwardItems);

		/// <summary>Clears the history of all items.</summary>
		void Clear();

		/// <summary>Gets a specified number of items starting at a location within the history.</summary>
		/// <param name="count">The maximum number of items to retrieve. The actual number of items returned may be less if not avaialable.</param>
		/// <param name="origin">The reference point within the history at which to start fetching items.</param>
		/// <returns>A read-only list of items.</returns>
		IReadOnlyList<T> GetItems(int count, SeekOrigin origin);

		/// <summary>
		/// Seeks through the history a given number of items starting at a known location within the history. This updates the <see
		/// cref="Current"/> property.
		/// </summary>
		/// <param name="count">The number of items to move. This value can be negative to search backwards or positive to search forwards.</param>
		/// <param name="origin">The reference point within the history at which to start seeking.</param>
		/// <returns>The value at the new current pointer position.</returns>
		/// <exception cref="System.InvalidOperationException">Cannot seek on an empty history.</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">
		/// The number of items to move cannot be accomplished given the number of items in the history and the seek origin.
		/// </exception>
		T Seek(int count, SeekOrigin origin);

		/// <summary>Seeks one position backwards.</summary>
		/// <returns>The value at the new current pointer position.</returns>
		T SeekBackward();

		/// <summary>Seeks one position forwards.</summary>
		/// <returns>The value at the new current pointer position.</returns>
		T SeekForward();
	}

	/// <summary>Provides a history of items that lives efficiently in memory and whose size can change easily.</summary>
	/// <typeparam name="T">The type of item to hold.</typeparam>
	/// <seealso cref="System.Collections.Generic.IEnumerable{T}"/>
	/// <seealso cref="System.Collections.Specialized.INotifyCollectionChanged"/>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged"/>
	public class History<T> : IHistory<T>
	{
		private readonly LinkedList<T> activeHistory = new LinkedList<T>();
		private int capacity;
		private LinkedListNode<T> current;

		/// <summary>Initializes a new instance of the <see cref="History{T}"/> class with a capacity of 256 items.</summary>
		public History() : this(256)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="History{T}"/> class with a variable capacity.</summary>
		/// <param name="capacity">The capacity.</param>
		public History(int capacity) => Capacity = capacity;

		/// <summary>Initializes a new instance of the <see cref="History{T}"/> class with a initial list of items.</summary>
		/// <param name="items">The items with which to initialize the history.</param>
		public History(IEnumerable<T> items)
		{
			foreach (var i in items)
				activeHistory.AddLast(i);
			capacity = activeHistory.Count;
			GetCurrent();
		}

		/// <summary>Occurs when an item is added, removed, changed, moved, or the entire list is refreshed.</summary>
		public event NotifyCollectionChangedEventHandler CollectionChanged;

		/// <summary>Occurs when a property value changes.</summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>Indicates the presence of items in the history that can be reached by calling <see cref="SeekBackward"/>.</summary>
		/// <value><see langword="true"/> if this instance can seek backward; otherwise, <see langword="false"/>.</value>
		public virtual bool CanSeekBackward => GetCurrent()?.Previous != null;

		/// <summary>Indicates the presence of items in the history that can be reached by calling <see cref="SeekForward"/>.</summary>
		/// <value><see langword="true"/> if this instance can seek forward; otherwise, <see langword="false"/>.</value>
		public virtual bool CanSeekForward => GetCurrent()?.Next != null;

		/// <summary>Gets or sets the capacity of the history, or the maximum number of items that it will hold.</summary>
		/// <value>The history's capacity.</value>
		public virtual int Capacity
		{
			get => capacity;
			set
			{
				if (capacity == value) return;
				if (value < activeHistory.Count)
				{
					var list = new List<T>();
					while (activeHistory.Count > value)
					{
						list.Add(activeHistory.First.Value);
						activeHistory.RemoveFirst();
					}
					OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, list));
				}
				capacity = value;
				OnPropertyChanged();
			}
		}

		/// <summary>Gets the value at a pointer within the history that represents the current item.</summary>
		/// <value>The current item.</value>
		/// <exception cref="System.InvalidOperationException">There are no items in the history.</exception>
		public virtual T Current => !(GetCurrent() is null) ? current.Value : throw new InvalidOperationException("There are no items in the history.");

		/// <summary>Gets the items in the history.</summary>
		/// <value>The number of items.</value>
		public virtual int Count => activeHistory.Count;

		/// <summary>
		/// Adds the specified item as the last history entry and sets the <see cref="Current" /> property to it's value.
		/// </summary>
		/// <param name="item">The item to add to the history.</param>
		/// <param name="removeForwardItems"><see langword="true" /> indicates to remove all items forward of the current pointer; <see langword="false"/> leaves the history intact.</param>
		public virtual void Add(T item, bool removeForwardItems = false)
		{
			if (removeForwardItems && CanSeekForward)
			{
				var ptr = activeHistory.Last;
				var items = new List<T>();
				while (ptr != current)
				{
					items.Add(ptr.Value);
					activeHistory.RemoveLast();
					ptr = activeHistory.Last;
				}
				OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, items));
			}
			var added = activeHistory.AddLast(item);
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
			if (activeHistory.Count > Capacity)
			{
				var first = activeHistory.First;
				activeHistory.RemoveFirst();
				OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, first.Value));
			}
			OnPropertyChanged(nameof(Count));
			current = added;
			OnPropertyChanged(nameof(Current));
		}

		/// <summary>Clears the history of all items.</summary>
		public virtual void Clear()
		{
			if (Count == 0) return;
			activeHistory.Clear();
			current = null;
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			OnPropertyChanged(nameof(Count));
			OnPropertyChanged(nameof(Current));
		}

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="IEnumerator{T}"/> that can be used to iterate through the collection.</returns>
		public virtual IEnumerator<T> GetEnumerator() => activeHistory.GetEnumerator();

		/// <summary>Gets a specified number of items starting at a location within the history.</summary>
		/// <param name="count">The maximum number of items to retrieve. The actual number of items returned may be less if not avaialable.</param>
		/// <param name="origin">The reference point within the history at which to start fetching items.</param>
		/// <returns>A read-only list of items.</returns>
		public virtual IReadOnlyList<T> GetItems(int count, SeekOrigin origin)
		{
			if (count == 0 || Count == 0) return (IReadOnlyList<T>)new List<T>(0);
			var ptr = origin switch
			{
				SeekOrigin.Begin => activeHistory.First,
				SeekOrigin.Current => GetCurrent(),
				SeekOrigin.End => activeHistory.Last,
				_ => throw new ArgumentOutOfRangeException(nameof(origin)),
			};
			var items = new List<T>();
			for (int i = 0; i < Math.Abs(count) && ptr != null; i++)
			{
				items.Add(ptr.Value);
				ptr = count > 0 ? ptr.Next : ptr.Previous;
			}
			return (IReadOnlyList<T>)items;
		}

		/// <summary>
		/// Seeks through the history a given number of items starting at a known location within the history. This updates the <see
		/// cref="Current"/> property.
		/// </summary>
		/// <param name="count">The number of items to move. This value can be negative to search backwards or positive to search forwards.</param>
		/// <param name="origin">The reference point within the history at which to start seeking.</param>
		/// <returns>The value at the new current pointer position.</returns>
		/// <exception cref="System.InvalidOperationException">Cannot seek on an empty history.</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">
		/// The number of items to move cannot be accomplished given the number of items in the history and the seek origin.
		/// </exception>
		public virtual T Seek(int count, SeekOrigin origin)
		{
			if (activeHistory.Count == 0) throw new InvalidOperationException("Cannot seek on an empty history.");
			var ptr = origin switch
			{
				SeekOrigin.Begin => activeHistory.First,
				SeekOrigin.Current => GetCurrent(),
				SeekOrigin.End => activeHistory.Last,
				_ => throw new ArgumentOutOfRangeException(nameof(origin)),
			};
			for (int i = 0; i < Math.Abs(count); i++)
			{
				if (ptr is null) throw new ArgumentOutOfRangeException(nameof(count));
				ptr = count > 0 ? ptr.Next : ptr.Previous;
			}
			current = ptr;
			OnPropertyChanged(nameof(Current));
			return Current;
		}

		/// <summary>Seeks one position backwards.</summary>
		/// <returns>The value at the new current pointer position.</returns>
		public virtual T SeekBackward() => CanSeekBackward ? Seek(-1, SeekOrigin.Current) : default;

		/// <summary>Seeks one position forwards.</summary>
		/// <returns>The value at the new current pointer position.</returns>
		public virtual T SeekForward() => CanSeekForward ? Seek(1, SeekOrigin.Current) : default;

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>Raises the <see cref="CollectionChanged"/> event.</summary>
		/// <param name="e">The <see cref="NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
		protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e) => CollectionChanged?.Invoke(this, e);

		/// <summary>Raises the <see cref="PropertyChanged"/> event.</summary>
		/// <param name="propertyName">Name of the property that has changed.</param>
		protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		private LinkedListNode<T> GetCurrent()
		{
			if (current is null)
			{
				current = activeHistory.Last;
				if (current != null)
					OnPropertyChanged(nameof(Current));
			}
			return current;
		}
	}
}