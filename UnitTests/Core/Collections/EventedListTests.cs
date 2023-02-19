using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Vanara.Collections.Tests;

[TestFixture()]
public class EventedListTests
{
	[Test()]
	public void AddRangeTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>();
		l.AddRange(a);
		Assert.That(l.Count, Is.EqualTo(2));
	}

	[Test()]
	public void AddRangeTest1()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>();
		l.AddRange(a.AsEnumerable());
		Assert.That(l.Count, Is.EqualTo(2));
	}

	[Test()]
	public void AsReadOnlyTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		Assert.That(l.AsReadOnly(), Is.InstanceOf<IReadOnlyCollection<EClass>>());
	}

	[Test()]
	public void BinarySearchTest()
	{
		var l = new EventedList<EClass>(100);
		var r = new Random();
		for (var i = 0; i < 100; i++)
			l.Add(new EClass(r.Next()));
		l.Sort();
		var x = l[27];
		Assert.That(l.BinarySearch(x), Is.EqualTo(27));
		Assert.That(l.BinarySearch(x, new CEClass()), Is.EqualTo(27));
		Assert.That(l.BinarySearch(10, 40, x, new CEClass()), Is.EqualTo(27));
		Assert.That(l.BinarySearch(50, 40, x, new CEClass()), Is.Negative);
	}

	[Test()]
	public void ClearTest()
	{
		var l = new EventedList<EClass>();
		l.Add(new EClass());
		Assert.That(l.Count, Is.EqualTo(1));
		l.Clear();
		Assert.That(l.Count, Is.EqualTo(0));
	}

	[Test()]
	public void ContainsTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		Assert.That(l.Contains(a[0]));
		Assert.That(!l.Contains(new EClass()));
	}

	[Test()]
	public void ConvertAllTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		Assert.That(l.ConvertAll(e => new EClass(e.Prop - 1)).Count, Is.EqualTo(2));
	}

	[Test()]
	public void CopyToTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		var a2 = new EClass[2];
		l.CopyTo(a2, 0);
		Assert.That(a, Is.EquivalentTo(a));
	}

	[Test()]
	public void CopyToTest1()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		var a2 = new EClass[1];
		l.CopyTo(1, a2, 0, 1);
		Assert.That(a2[0], Is.EqualTo(a[1]));
	}

	[Test()]
	public void EventedListTest()
	{
		var l = new EventedList<EClass>();
		Assert.That(l.Count, Is.EqualTo(0));
	}

	[Test()]
	public void EventedListTest1()
	{
		var l = new EventedList<EClass>(new[] { new EClass(1), new EClass(2) });
		Assert.That(l.Count, Is.EqualTo(2));
	}

	[Test()]
	public void EventedListTest2()
	{
		var l = new EventedList<EClass>(3);
		Assert.That(l.Count, Is.EqualTo(0));
		Assert.That(l.Capacity, Is.EqualTo(3));
	}

	[Test()]
	public void ExistsTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		Assert.That(l.Exists(e => e.Prop == 1));
		Assert.That(!l.Exists(e => e.Prop == 7));
	}

	[Test()]
	public void FindAllTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		Assert.That(l.FindAll(e => e.Prop >= 1), Is.EquivalentTo(l));
		Assert.That(l.FindAll(e => e.Prop < 1), Is.Empty);
	}

	[Test()]
	public void FindIndexTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		Assert.That(l.FindIndex(e => e.Prop == 2), Is.EqualTo(1));
		Assert.That(l.FindIndex(e => e.Prop == 7), Is.EqualTo(-1));
		Assert.That(l.FindIndex(1, 1, e => e.Prop == 2), Is.EqualTo(1));
	}

	[Test()]
	public void FindLastIndexTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		Assert.That(l.FindLastIndex(e => e.Prop == 1), Is.EqualTo(0));
		Assert.That(l.FindLastIndex(e => e.Prop == 7), Is.EqualTo(-1));
		Assert.That(l.FindLastIndex(1, 1, e => e.Prop == 2), Is.EqualTo(1));
	}

	[Test()]
	public void FindLastTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		Assert.That(l.FindLast(e => e.Prop == 1), Is.EqualTo(a[0]));
		Assert.That(l.FindLast(e => e.Prop == 7), Is.Null);
	}

	[Test()]
	public void FindTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		Assert.That(l.Find(e => e.Prop == 1), Is.EqualTo(a[0]));
		Assert.That(l.Find(e => e.Prop == 7), Is.Null);
	}

	[Test()]
	public void ForEachTest()
	{
		var i = 0;
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		l.ForEach(e => i += e.Prop);
		Assert.That(i, Is.EqualTo(3));
	}

	[Test()]
	public void GetEnumeratorTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		Assert.That(l.GetEnumerator(), Is.InstanceOf<IEnumerator<EClass>>());
	}

	[Test()]
	public void GetRangeTest()
	{
		var a = new[] { new EClass(1), new EClass(2), new EClass(3) };
		var l = new EventedList<EClass>(a);
		var r = l.GetRange(1, 2);
		Assert.That(r.Count, Is.EqualTo(2));
		Assert.That(r[0].Prop, Is.EqualTo(2));
	}

	[Test()]
	public void IndexOfTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		Assert.That(l.IndexOf(a[1]), Is.EqualTo(1));
		Assert.That(l.IndexOf(a[1], 1, 1), Is.EqualTo(1));
	}

	[Test()]
	public void InsertRangeTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		l.InsertRange(1, a);
		Assert.That(l.Count, Is.EqualTo(4));
		Assert.That(l[1].Prop, Is.EqualTo(1));
		Assert.That(l[2].Prop, Is.EqualTo(2));
	}

	[Test()]
	public void InsertTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		l.Insert(1, new EClass(3));
		Assert.That(l[1].Prop, Is.EqualTo(3));
	}

	[Test()]
	public void LastIndexOfTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		l.Add(a[0]);
		Assert.That(l.LastIndexOf(a[0]), Is.EqualTo(2));
		Assert.That(l.LastIndexOf(a[0], 1, 2), Is.EqualTo(0));
	}

	[Test()]
	public void RemoveAllTest()
	{
		var a = new[] { new EClass(1), new EClass(2), new EClass(3) };
		var l = new EventedList<EClass>(a);
		l.RemoveAll(e => e.Prop < 3);
		Assert.That(l.Count, Is.EqualTo(1));
		Assert.That(l[0].Prop, Is.EqualTo(3));
	}

	[Test()]
	public void RemoveAtTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		l.RemoveAt(0);
		Assert.That(l.Count, Is.EqualTo(1));
	}

	[Test()]
	public void RemoveRangeTest()
	{
		var a = new[] { new EClass(1), new EClass(2), new EClass(3) };
		var l = new EventedList<EClass>(a);
		l.RemoveRange(0, 2);
		Assert.That(l.Count, Is.EqualTo(1));
		Assert.That(l[0].Prop, Is.EqualTo(3));
	}

	[Test()]
	public void RemoveTest()
	{
		var a = new[] { new EClass(1), new EClass(2) };
		var l = new EventedList<EClass>(a);
		l.Remove(a[0]);
		Assert.That(l.Count, Is.EqualTo(1));
	}

	[Test()]
	public void ReverseTest()
	{
		var a = new[] { new EClass(1), new EClass(2), new EClass(3) };
		var l = new EventedList<EClass>(a);
		l.Reverse();
		Assert.That(l[0].Prop, Is.EqualTo(3));
		Assert.That(l[2].Prop, Is.EqualTo(1));
	}

	[Test()]
	public void ReverseTest1()
	{
		var a = new[] { new EClass(1), new EClass(2), new EClass(3) };
		var l = new EventedList<EClass>(a);
		l.Reverse(1, 2);
		Assert.That(l[0].Prop, Is.EqualTo(1));
		Assert.That(l[2].Prop, Is.EqualTo(2));
	}

	[Test()]
	public void SortTest()
	{
		var a = new[] { new EClass(3), new EClass(1), new EClass(0) };
		var l = new EventedList<EClass>(a);
		l.Sort();
		Assert.That(l[0].Prop, Is.EqualTo(0));
		Assert.That(l[2].Prop, Is.EqualTo(3));
	}

	[Test()]
	public void SortTest1()
	{
		var a = new[] { new EClass(3), new EClass(1), new EClass(0) };
		var l = new EventedList<EClass>(a);
		l.Sort(1, 2, new CEClass());
		Assert.That(l[0].Prop, Is.EqualTo(3));
		Assert.That(l[2].Prop, Is.EqualTo(1));
	}

	[Test()]
	public void ToArrayTest()
	{
		var a = new[] { new EClass(1), new EClass(2), new EClass(3) };
		var l = new EventedList<EClass>(a);
		Assert.That(l.ToArray(), Is.EquivalentTo(a));
	}

	[Test()]
	public void TrimExcessTest()
	{
		var l = new EventedList<EClass>(10);
		l.AddRange(new[] { new EClass(1), new EClass(2), new EClass(3) });
		Assert.That(l.Capacity, Is.EqualTo(10));
		Assert.That(l.Count, Is.EqualTo(3));
		l.TrimExcess();
		Assert.That(l.Count, Is.EqualTo(l.Capacity));
	}

	[Test()]
	public void TrueForAllTest()
	{
		var a = new[] { new EClass(1), new EClass(2), new EClass(3) };
		var l = new EventedList<EClass>(a);
		Assert.That(l.TrueForAll(e => e.Prop > 1), Is.False);
		Assert.That(l.TrueForAll(e => e.Prop > 0), Is.True);
	}

	private class CEClass : Comparer<EClass>
	{
		public override int Compare(EClass x, EClass y) => x.CompareTo(y);
	}

	private class EClass : INotifyPropertyChanged, IComparable<EClass>
	{
		private int p;

		public EClass(int prop = 0)
		{
			p = prop;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public int Prop
		{
			get => p;
			set
			{
				p = value;
				OnPropertyChanged();
			}
		}

		public int CompareTo(EClass other)
		{
			if (ReferenceEquals(this, other)) return 0;
			if (ReferenceEquals(null, other)) return 1;
			return p.CompareTo(other.p);
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}