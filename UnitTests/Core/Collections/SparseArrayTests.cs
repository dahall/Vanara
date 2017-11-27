using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Vanara.Collections.Tests
{
	[TestFixture()]
	public class SparseArrayTests
	{
		[Test()]
		public void AddTest()
		{
			var a = new SparseArray<bool>();
			Assert.That(() => ((ICollection<bool>)a).Add(true), Throws.TypeOf<NotSupportedException>());
			Assert.That(((ICollection<bool>)a).IsReadOnly, Is.False);
		}

		[Test()]
		public void ClearTest()
		{
			var a = new SparseArray<bool> { [5] = true, [90] = false };
			Assert.That(a.Count, Is.EqualTo(2));
			a.Clear();
			Assert.That(a.Count, Is.EqualTo(0));
		}

		[Test()]
		public void ContainsTest()
		{
			var a = new SparseArray<bool> { [5] = true, [90] = true };
			Assert.That(a.Contains(true), Is.True);
			Assert.That(a.Contains(false), Is.False);
		}

		[Test()]
		public void CopyToTest()
		{
			var a = new SparseArray<bool> { [5] = true, [90] = false };
			var arr = new bool[2];
			a.CopyTo(arr, 0);
			Assert.That(arr, Is.EquivalentTo(new[] {true, false}));
			arr = new bool[3];
			a.CopyTo(arr, 1);
			Assert.That(arr, Is.EquivalentTo(new[] {false, true, false}));
		}

		[Test()]
		public void GetEnumeratorTest()
		{
			var a = new SparseArray<bool> { [5] = true, [90] = false };
			using (var e = a.GetEnumerator())
			{
				Assert.That(e.MoveNext());
				Assert.That(e.Current, Is.True);
				Assert.That(e.MoveNext());
				Assert.That(e.Current, Is.False);
				Assert.That(e.MoveNext(), Is.False);
			}
		}

		[Test()]
		public void IndexOfTest()
		{
			var a = new SparseArray<int> { [5] = -5, [90] = -90 };
			Assert.That(a.IndexOf(-5), Is.EqualTo(5));
			Assert.That(a.IndexOf(-90), Is.EqualTo(90));
			Assert.That(a.IndexOf(0), Is.EqualTo(-1));
		}

		[Test()]
		public void InsertTest()
		{
			var a = new SparseArray<bool> { [5] = true, [90] = false };
			a.Insert(5, false);
			Assert.That(a[1], Is.False);
			Assert.That(a[5], Is.False);
			Assert.That(a.Count, Is.EqualTo(2));
			a.Insert(10, false);
			Assert.That(a[10], Is.False);
			Assert.That(a.Count, Is.EqualTo(3));
		}

		[Test()]
		public void RemoveAtTest()
		{
			var a = new SparseArray<bool> { [5] = true, [90] = false };
			a.RemoveAt(5);
			Assert.That(a.Count, Is.EqualTo(1));
			a.RemoveAt(10);
			Assert.That(a.Count, Is.EqualTo(1));
		}

		[Test()]
		public void RemoveTest()
		{
			var a = new SparseArray<bool> { [5] = true, [90] = false };
			a.Remove(true);
			Assert.That(a.Count, Is.EqualTo(1));
			a.Remove(true);
			Assert.That(a.Count, Is.EqualTo(1));
		}

		[Test()]
		public void ToArrayTest()
		{
			var a = new SparseArray<bool> { [5] = true, [90] = false };
			Assert.That(a.ToArray(), Is.EquivalentTo(new[] {true, false}));
		}
	}
}