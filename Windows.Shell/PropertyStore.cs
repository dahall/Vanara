using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.Windows.Shell
{
	public class PropertyStore : IDictionary<PROPERTYKEY, object>
	{
		private readonly IPropertyStore iprops;

		internal PropertyStore(ShellItem item, EventHandler propChangedHandler = null)
		{
			iprops = item.GetPropertyStore();
			if (propChangedHandler != null)
				PropertyChanged += propChangedHandler;
		}

		internal PropertyStore(ShellLink lnk, EventHandler propChangedHandler = null)
		{
			iprops = (IPropertyStore)lnk.link;
			if (propChangedHandler != null)
				PropertyChanged += propChangedHandler;
		}

		public event EventHandler PropertyChanged;

		public int Count => (int)(iprops?.GetCount() ?? 0);

		public bool IsReadOnly => false;

		public ICollection<PROPERTYKEY> Keys
		{
			get
			{
				var keys = new List<PROPERTYKEY>(Count);
				for (uint i = 0; i < Count; i++)
					keys.Add(iprops.GetAt(i));
				return keys;
			}
		}

		public ICollection<object> Values
		{
			get
			{
				var vals = new List<object>(Count);
				for (uint i = 0; i < Count; i++)
					vals.Add(this[iprops.GetAt(i)]);
				return vals;
			}
		}

		public object this[Guid key]
		{
			get => this[new PROPERTYKEY(key, 2)]; set { this[new PROPERTYKEY(key, 2)] = value; OnPropertyChanged(); }
		}

		public object this[PROPERTYKEY key]
		{
			get
			{
				object r;
				if (!TryGetValue(key, out r))
					throw new ArgumentOutOfRangeException(nameof(key));
				return r;
			}
			set
			{
				if (iprops == null)
					throw new InvalidOperationException("Property store does not exist.");
				iprops.SetValue(key, new PROPVARIANT(value));
				OnPropertyChanged();
			}
		}

		public void Add(PROPERTYKEY key, object value)
		{
			if (iprops == null)
				throw new InvalidOperationException("Property store does not exist.");
			iprops.SetValue(key, new PROPVARIANT(value));
			OnPropertyChanged();
		}

		public void Add(KeyValuePair<PROPERTYKEY, object> item) { Add(item.Key, item.Value); }

		public void Clear() { throw new InvalidOperationException(); }

		public void Commit() { iprops?.Commit(); }

		public bool Contains(KeyValuePair<PROPERTYKEY, object> item)
		{
			object o;
			return TryGetValue(item.Key, out o) && Equals(o, item.Value);
		}

		public bool ContainsKey(PROPERTYKEY key) => Keys.Contains(key);

		public void CopyTo(KeyValuePair<PROPERTYKEY, object>[] array, int arrayIndex)
		{
			if (array.Length < (arrayIndex + Count))
				throw new ArgumentOutOfRangeException(nameof(arrayIndex),
					"The number of items exceeds the length of the supplied array.");
			if (array == null)
				throw new ArgumentNullException(nameof(array));
			var i = arrayIndex;
			foreach (var kv in this)
				array[i++] = kv;
		}

		public IEnumerator<KeyValuePair<PROPERTYKEY, object>> GetEnumerator() => Keys.Select(k => new KeyValuePair<PROPERTYKEY, object>(k, this[k])).GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public void OnPropertyChanged() { PropertyChanged?.Invoke(this, EventArgs.Empty); }

		public bool Remove(PROPERTYKEY key) { throw new InvalidOperationException(); }

		public bool Remove(KeyValuePair<PROPERTYKEY, object> item) { throw new InvalidOperationException(); }

		public bool TryGetValue(PROPERTYKEY key, out object value)
		{
			if (iprops != null)
			{
				try
				{
					var pv = new PROPVARIANT();
					iprops.GetValue(ref key, pv);
					value = pv.Value;
					return true;
				}
				catch { }
			}
			value = null;
			return false;
		}
	}
}