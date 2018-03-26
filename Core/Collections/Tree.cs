#if !(NET20)

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Vanara.Collections
{
	public static partial class TreeExtension
	{
		private const char defaultSeparator = '\\';

		/// <summary>Parses and adds the entry to the hierarchy, creating any parent entries as required.</summary>
		/// <param name="tree">The tree.</param>
		/// <param name="entry">The delimiter separated list of child node values.</param>
		/// <param name="startIndex">The index of the character in <paramref name="entry"/> at which to start reading node values.</param>
		/// <param name="separator">The separator character used as the delimiter.</param>
		public static void AddEntry(this Tree<string> tree, string entry, int startIndex = 0, char separator = defaultSeparator)
		{
			AddEntry((TreeNode<string>)tree, entry, startIndex, separator);
		}

		/// <summary>
		/// Gets the child, potentially many levels down, by supplying a backslash ('\') separated list of children's string representations of their <see cref="TreeNode{T}.Value"/>.
		/// </summary>
		/// <param name="tree">The tree.</param>
		/// <param name="childPath">The backslash ('\') separated list of children's string representations.</param>
		/// <returns>The requested <see cref="TreeNode{T}"/>, or <c>null</c> if not found.</returns>
		public static TreeNode<string> NodeFromPath(this Tree<string> tree, string childPath)
		{
			childPath = childPath?.TrimStart(defaultSeparator);
			if (string.IsNullOrEmpty(childPath)) return tree;
			try
			{
				return childPath.Split(defaultSeparator).Aggregate((TreeNode<string>)tree, (current, key) => current.Children.First(p => string.Equals(key, p.Value, StringComparison.InvariantCulture)));
			}
			catch
			{
				return null;
			}
		}

		private static void AddEntry(this TreeNode<string> tree, string entry, int startIndex, char separator)
		{
			if (string.IsNullOrEmpty(entry)) throw new ArgumentNullException(nameof(entry));
			if (startIndex >= entry.Length)
				return;

			var endIndex = entry.IndexOf(separator, startIndex);
			if (endIndex == -1)
				endIndex = entry.Length;
			var key = entry.Substring(startIndex, endIndex - startIndex);
			if (string.IsNullOrEmpty(key))
				return;

			// Now add the rest to the new item's children
			var item = tree.Children.Contains(key) ? tree.Children.GetNode(key) : tree.Children.Add(key);
			AddEntry(item, entry, endIndex + 1);

			/*while (startIndex < entry.Length)
			{
				var endIndex = entry.IndexOf(pathDesignator, startIndex);
				if (endIndex == -1) endIndex = entry.Length;
				var key = entry.Substring(startIndex, endIndex - startIndex);
				if (string.IsNullOrEmpty(key)) return;

				node = enumChildren(node).FirstOrDefault(n => getPath(n) == key) ?? addChild(node, key);
				startIndex = endIndex + 1;
			}*/
		}
	}

	public static partial class TupleExtension
	{
		public static void Add<T1, T2>(this IList<Tuple<T1, T2>> list, T1 item1, T2 item2)
		{
			list.Add(new Tuple<T1, T2>(item1, item2));
		}
	}

	/// <summary>A hierarchical tree containing nodes of type <typeparamref name="T"/>.</summary>
	/// <typeparam name="T">The type of the node.</typeparam>
	public class Tree<T> : TreeNode<T> where T : IComparable<T>
	{
		/// <summary>Gets the zero-based depth of the tree node in the <see cref="T:Vanara.PInvoke.Tree`1"/>.</summary>
		/// <value>The zero-based depth of the tree node in the <see cref="T:Vanara.PInvoke.Tree`1"/>.</value>
		public override int Level => 0;

		/// <summary>Gets the parent tree node of the current tree node.</summary>
		/// <value>A <see cref="T:Vanara.PInvoke.TreeNode`1"/> that represents the parent of the current tree node.</value>
		public override TreeNode<T> Parent => null;

		/// <summary>Gets the root node of the tree. If this node has no parent, then it will be returned.</summary>
		/// <value>The root node.</value>
		public override TreeNode<T> RootNode => this;

		/// <summary>Creates a tree from a list of paired values.</summary>
		/// <param name="input">A list of paired values.</param>
		/// <returns>A tree of leafs constructed from the list.</returns>
		public static Tree<T> FromParentChildPairs(ICollection<Tuple<T, T>> input)
		{
			if (input == null) throw new ArgumentNullException(nameof(input));
			var ret = new Tree<T>();
			var uniq1 = input.Select(i => i.Item1).Distinct();
			var uniq2 = input.Select(i => i.Item2).Distinct();
			var roots = uniq1.Except(uniq2).ToArray();
			if (roots.Length == 1)
			{
				ret.Value = roots[0];
				roots = input.Where(i => Equals(i.Item1, ret.Value)).Select(i => i.Item2).ToArray();
			}
			ret.Children.AddRange(roots);
			var groups = input.GroupBy(i => i.Item1).ToArray();
			foreach (var n in ret.Children)
				n.AddChildren(groups);
			return ret;
		}

		/// <summary>Gets the child specified by the list of nodes.</summary>
		/// <param name="childKeys">The child values starting with the top-most child key.</param>
		/// <returns>The requested <see cref="TreeNode{T}"/>, or <c>null</c> if not found.</returns>
		public TreeNode<T> GetChild(params T[] childKeys)
		{
			try
			{
				return childKeys.Aggregate((TreeNode<T>)this, (current, key) => current.Children.First(n => Equals(n.Value, key)));
			}
			catch
			{
				return null;
			}
		}
	}

	/// <summary></summary>
	/// <typeparam name="T"></typeparam>
	/// <seealso cref="System.IDisposable"/>
	public class TreeNode<T> : IDisposable where T : IComparable<T>
	{
		/// <summary>Initializes a new instance of the <see cref="TreeNode{T}"/> class.</summary>
		public TreeNode() { Children = new TreeNodeList(this); }

		/// <summary>Initializes a new instance of the <see cref="TreeNode{T}"/> class.</summary>
		/// <param name="value">The value to assign to the <see cref="Value"/> property.</param>
		/// <param name="parent">Optionally nest this node to an existing parent <see cref="TreeNode{T}"/>.</param>
		public TreeNode(T value, TreeNode<T> parent = null) : this()
		{
			Value = value;
			Parent = parent;
		}

		/// <summary>Gets the children (leafs) of the current node.</summary>
		/// <value>The children nodes.</value>
		public TreeNodeList Children { get; internal set; }

		/// <summary>Gets the parent tree node of the current tree node.</summary>
		/// <value>A <see cref="TreeNode{T}"/> that represents the parent of the current tree node.</value>
		public virtual TreeNode<T> Parent { get; internal set; }

		/// <summary>Gets the root node of the tree. If this node has no parent, then it will be returned.</summary>
		/// <value>The root node.</value>
		public virtual TreeNode<T> RootNode
		{
			get
			{
				var r = this;
				while (r.Parent != null) r = r.Parent;
				return r;
			}
		}

		/// <summary>Gets or sets the value tied to this <see cref="TreeNode{T}"/>.</summary>
		/// <value>The value.</value>
		public virtual T Value { get; set; }

		/// <summary>Gets the zero-based depth of the tree node in the <see cref="Tree{T}"/>.</summary>
		/// <value>The zero-based depth of the tree node in the <see cref="Tree{T}"/>.</value>
		public virtual int Level => Parent?.Level + 1 ?? 0;

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public virtual void Dispose()
		{
			Children.Dispose();
			(Value as IDisposable)?.Dispose();
		}

		/// <summary>Returns a <see cref="System.String" /> that represents this instance.</summary>
		/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
		public override string ToString() => $"{Value}";

		internal void AddChildren(IGrouping<T, Tuple<T, T>>[] groups)
		{
			foreach (var child in groups.Where(g => Equals(g.Key, Value)))
				foreach (var pair in child)
					Children.Add(pair.Item2).AddChildren(groups);
		}

		/// <summary>A list of leaf nodes for a <see cref="TreeNode{T}"/>. Exposed through the <see cref="TreeNode{T}.Children"/> property.</summary>
		/// <typeparam name="T">The type held by a node.</typeparam>
		/// <seealso cref="System.Collections.Generic.IList{Vanara.Collections.TreeNode{T}}"/>
		/// <seealso cref="System.IDisposable"/>
		public class TreeNodeList : IList<TreeNode<T>>, IDisposable
		{
			private readonly TreeNode<T> host;
			private readonly IList<TreeNode<T>> list;

			// Prevent construction
			private TreeNodeList() { }

			/// <summary>Initializes a new instance of the <see cref="TreeNodeList{T}"/> class.</summary>
			/// <param name="hostNode">The host node.</param>
			internal TreeNodeList(TreeNode<T> hostNode)
			{
				host = hostNode;
				list = new List<TreeNode<T>>();
			}

			/// <summary>Gets the values for all nodes in this list.</summary>
			/// <value>The node values.</value>
			public IEnumerable<T> Values => list.Select(n => n.Value);

			/// <summary>
			/// Gets the number of elements contained in the <see cref="ICollection{T}" />.
			/// </summary>
			public int Count => list.Count;

			/// <summary>
			/// Gets a value indicating whether the <see cref="ICollection{T}" /> is read-only.
			/// </summary>
			bool ICollection<TreeNode<T>>.IsReadOnly => false;

			/// <summary>Gets or sets the <see cref="TreeNode{T}"/> at the specified index. This will remove the tree node at this position</summary>
			/// <value>The <see cref="TreeNode{T}"/>.</value>
			/// <param name="index">The index.</param>
			/// <returns></returns>
			public TreeNode<T> this[int index]
			{
				get => list[index];
				set
				{
					value.Parent = host;
					list[index] = value;
				}
			}

			/// <summary>Adds the specified item.</summary>
			/// <param name="item">The item.</param>
			/// <returns></returns>
			public virtual TreeNode<T> Add(T item)
			{
				var ret = MakeNode(item);
				list.Add(ret);
				return ret;
			}

			/// <summary>Adds an item to the <see cref="ICollection{T}" />.</summary>
			/// <param name="item">The object to add to the <see cref="ICollection{T}" />.</param>
			public void Add(TreeNode<T> item)
			{
				item.Parent = host;
			}

			/// <summary>Adds the range.</summary>
			/// <param name="items">The items.</param>
			public void AddRange(IEnumerable<T> items)
			{
				foreach (var item in items)
					Add(item);
			}

			/// <summary>Adds the range.</summary>
			/// <param name="items">The items.</param>
			public void AddRange(params T[] items)
			{
				AddRange(items.AsEnumerable());
			}

			/// <summary>Removes all items from the <see cref="ICollection{T}" />.</summary>
			public virtual void Clear()
			{
				foreach (var n in list)
					n.Dispose();
				list.Clear();
			}

			/// <summary>
			/// Determines whether the <see cref="ICollection{T}" /> contains a specific value.
			/// </summary>
			/// <param name="item">The object to locate in the <see cref="ICollection{T}" />.</param>
			/// <returns>
			/// true if <paramref name="item" /> is found in the <see cref="ICollection{T}" />; otherwise, false.
			/// </returns>
			public bool Contains(TreeNode<T> item) => list.Contains(item);

			/// <summary>Determines whether [contains] [the specified item].</summary>
			/// <param name="item">The item.</param>
			/// <returns><c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.</returns>
			public bool Contains(T item) => IndexOf(item) != -1;

			/// <summary>
			/// Copies the elements of the <see cref="ICollection{T}" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
			/// </summary>
			/// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="ICollection{T}" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
			/// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
			public void CopyTo(TreeNode<T>[] array, int arrayIndex)
			{
				list.CopyTo(array, arrayIndex);
			}

			/// <summary>Copies to.</summary>
			/// <param name="array">The array.</param>
			/// <param name="arrayIndex">Index of the array.</param>
			public void CopyTo(T[] array, int arrayIndex)
			{
				list.Select(n => n.Value).ToArray().CopyTo(array, arrayIndex);
			}

			/// <summary>
			/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
			/// </summary>
			public virtual void Dispose()
			{
				Clear();
			}

			/// <summary>Returns an enumerator that iterates through the collection.</summary>
			/// <returns>
			/// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
			/// </returns>
			public IEnumerator<TreeNode<T>> GetEnumerator() => list.GetEnumerator();

			/// <summary>Gets the node.</summary>
			/// <param name="item">The item.</param>
			/// <returns></returns>
			public TreeNode<T> GetNode(T item) => list.First(n => Equals(n.Value, item));

			/// <summary>Indexes the of.</summary>
			/// <param name="item">The item.</param>
			/// <returns></returns>
			public virtual int IndexOf(T item) => ((List<TreeNode<T>>)list).FindIndex(n => Equals(n.Value, item));

			/// <summary>Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1" />.</summary>
			/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1" />.</param>
			/// <returns>The index of <paramref name="item" /> if found in the list; otherwise, -1.</returns>
			public int IndexOf(TreeNode<T> item) => list.IndexOf(item);

			/// <summary>Inserts the specified index.</summary>
			/// <param name="index">The index.</param>
			/// <param name="item">The item.</param>
			/// <returns></returns>
			public virtual TreeNode<T> Insert(int index, T item)
			{
				var n = MakeNode(item);
				Insert(index, n);
				return n;
			}

			/// <summary>Inserts an item to the <see cref="T:System.Collections.Generic.IList`1" /> at the specified index.</summary>
			/// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
			/// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1" />.</param>
			public void Insert(int index, TreeNode<T> item)
			{
				list.Insert(index, item);
			}

			/// <summary>
			/// Removes the first occurrence of a specific object from the <see cref="ICollection{T}" />.
			/// </summary>
			/// <param name="item">The object to remove from the <see cref="ICollection{T}" />.</param>
			/// <returns>
			/// true if <paramref name="item" /> was successfully removed from the <see cref="ICollection{T}" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="ICollection{T}" />.
			/// </returns>
			public bool Remove(TreeNode<T> item) => list.Remove(item);

			/// <summary>Removes the specified item.</summary>
			/// <param name="item">The item.</param>
			/// <returns></returns>
			public bool Remove(T item)
			{
				var i = IndexOf(item);
				if (i == -1) return false;
				list.RemoveAt(i);
				return true;
			}

			/// <summary>Removes the <see cref="T:System.Collections.Generic.IList`1" /> item at the specified index.</summary>
			/// <param name="index">The zero-based index of the item to remove.</param>
			public void RemoveAt(int index)
			{
				list.RemoveAt(index);
			}

			/// <summary>Returns a <see cref="System.String" /> that represents this instance.</summary>
			/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
			public override string ToString() => $"Count:{list.Count}";

			/// <summary>Returns an enumerator that iterates through a collection.</summary>
			/// <returns>
			/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
			/// </returns>
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

			internal void InternalAdd(TreeNode<T> item)
			{
				list.Add(item);
			}

			protected virtual TreeNode<T> MakeNode(T item) => new TreeNode<T>(item, host);
		}
	}
}

#endif