using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Vanara.InteropServices.Tests
{
	[TestFixture()]
	public class SafeByteArrayTests
	{
		private static readonly byte[] bytes = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
		private static SafeByteArray TestArray => new SafeByteArray(bytes);

		[Test()]
		public void SafeByteArrayTest()
		{
			var a = TestArray;
			Assert.That(a.Count == bytes.Length);
			Assert.That(a[4] == 4);
			Assert.That(a.IsReadOnly, Is.False);

			byte[] nullBytes = null;
			a = new SafeByteArray(nullBytes);
			Assert.That(a.Count == 0);
		}

		[Test()]
		public void SafeByteArrayTest1()
		{
			var a = new SafeByteArray(73);
			Assert.That(a.Count == 73);
			var r = new Random();
			Assert.That(a[r.Next(0, 72)], Is.Zero);
			Assert.That(a[r.Next(0, 72)], Is.Zero);
			Assert.That(a[r.Next(0, 72)], Is.Zero);
		}

		[Test()]
		public void SafeByteArrayTest2()
		{
			var t = TestArray;
			var a = new SafeByteArray(t);
			t = null;
			Assert.That(a.Count == bytes.Length);
			Assert.That(a[4] == 4);

			Assert.That(() => new SafeByteArray(t), Throws.ArgumentNullException);
			a.Dispose();
			Assert.That(() => new SafeByteArray(a), Throws.ArgumentException);

			Assert.That(() => a[0], Throws.TypeOf<IndexOutOfRangeException>());
			Assert.That(() => a[0] = 1, Throws.TypeOf<IndexOutOfRangeException>());
		}

		[Test]
		public void IListPropTest()
		{
			var l = TestArray as IList;
			Assert.That(l.IsFixedSize, Is.True);
			Assert.That(l[0], Is.Zero);
			l[0] = (byte)1;
			Assert.That(l[0], Is.EqualTo(1));
			Assert.That(() => l.Add((byte)16), Throws.TypeOf<NotSupportedException>());
			Assert.That(l.Contains((byte)5), Is.True);
			Assert.That(l.IndexOf((byte)5), Is.EqualTo(5));
			Assert.That(() => l.Insert(0, (byte)100), Throws.TypeOf<NotSupportedException>());
			//Assert.That(l[0], Is.EqualTo(100));
			//Assert.That(l.Count, Is.EqualTo(18));
			Assert.That(() => l.Remove((byte)100), Throws.TypeOf<NotSupportedException>());
			//Assert.That(l[0], Is.EqualTo(1));
			//Assert.That(l.Count, Is.EqualTo(17));
			Assert.That(() => l.RemoveAt(0), Throws.TypeOf<NotSupportedException>());
			//Assert.That(l.Count, Is.EqualTo(16));

			var gl = l as IList<byte>;
			Assert.That(() => gl.Insert(0, 100), Throws.TypeOf<NotSupportedException>());
			Assert.That(() => gl.RemoveAt(0), Throws.TypeOf<NotSupportedException>());
		}

		[Test]
		public void ICollectionPropTest()
		{
			var c = TestArray as ICollection;
			Assert.That(c.Count, Is.EqualTo(bytes.Length));
			Assert.That(c.Count, Is.EqualTo(bytes.Length));
			Assert.That(c.IsSynchronized, Is.True);
			Assert.That(c.SyncRoot, Is.EqualTo(c));
			Assert.That(() => c.CopyTo(null, 0), Throws.ArgumentNullException);
			Assert.That(() => c.CopyTo(new int[3], 0), Throws.Exception);
			Assert.That(() => c.CopyTo(new byte[16,16], 0), Throws.Exception);
			var b1 = new byte[bytes.Length];
			Assert.That(() => c.CopyTo(b1, 0), Throws.Nothing);
			Assert.That(b1, Is.EquivalentTo(bytes));

			var gc = TestArray as ICollection<byte>;
			Assert.That(() => gc.Add(16), Throws.TypeOf<NotSupportedException>());
			//Assert.That(gc.Count, Is.EqualTo(17));
			Assert.That(() => gc.Remove(16), Throws.TypeOf<NotSupportedException>());

		}

		[Test]
		public void IStructuralComparablePropTest()
		{
			var c = TestArray as IStructuralComparable;
			Assert.That(() => c.CompareTo(null, null), Throws.ArgumentNullException);
			Assert.That(c.CompareTo(null, Comparer<byte>.Default), Is.EqualTo(1));
			Assert.That(() => c.CompareTo(1, Comparer<byte>.Default), Throws.TypeOf<ArgumentOutOfRangeException>());
			var sb2 = new SafeByteArray(3);
			Assert.That(() => c.CompareTo(sb2, Comparer<byte>.Default), Throws.TypeOf<ArgumentOutOfRangeException>());
			Assert.That(c.CompareTo(bytes, Comparer<byte>.Default), Is.EqualTo(0));
			var sb3 = bytes.Reverse().ToArray();
			Assert.That(c.CompareTo(sb3, Comparer<byte>.Default), Is.LessThan(0));
			Assert.That(c.CompareTo(new List<byte>(bytes), Comparer<byte>.Default), Is.EqualTo(0));
		}

		[Test]
		public void IStructuralEquatablePropTest()
		{
			var sb = TestArray;
			var e = sb as IStructuralEquatable;
			var iec = EqualityComparer<byte>.Default;
			Assert.That(e.Equals(sb, iec), Is.True);
			var h1 = e.GetHashCode(iec);
			Assert.That(() => e.GetHashCode(null), Throws.ArgumentNullException);
			Assert.That(() => e.Equals(null, null), Throws.ArgumentNullException);
			Assert.That(e.Equals(null, iec), Is.False);
			Assert.That(() => e.Equals(1, iec), Throws.TypeOf<ArgumentOutOfRangeException>());
			var sb2 = new SafeByteArray(3);
			var h2 = ((IStructuralEquatable) sb2).GetHashCode(iec);
			Assert.That(() => e.Equals(sb2, iec), Throws.TypeOf<ArgumentOutOfRangeException>());
			Assert.That(e.Equals(bytes, iec), Is.True);
			Assert.That(e.Equals(new List<byte>(bytes), iec), Is.True);
			var sb3 = new SafeByteArray(bytes.Reverse().ToArray());
			Assert.That(e.Equals(sb3, iec), Is.False);
			var h3 = ((IStructuralEquatable)sb3).GetHashCode(iec);

			var sb4 = new SafeByteArray(bytes);
			var h4 = ((IStructuralEquatable)sb4).GetHashCode(iec);

			Assert.That(h1 != h2);
			Assert.That(h1 != h3);
			Assert.That(h1 == h4);
		}

		[Test()]
		public void ClearTest()
		{
			var t = TestArray;
			t.Clear();
			Assert.That(t.Count == 0);
			Assert.That(() => t[4], Throws.TypeOf<IndexOutOfRangeException>());
		}

		[Test()]
		public void CloneTest()
		{
			var t = TestArray;
			var a = t.Clone() as SafeByteArray;
			t = null;
			Assert.That(a?.Count == bytes.Length);
			Assert.That(a[4] == 4);
		}

		[Test()]
		public void ContainsTest()
		{
			Assert.That(TestArray.Contains(4));
			Assert.That(TestArray.Contains(14));
			Assert.That(TestArray.Contains(0));
			Assert.That(!TestArray.Contains(24));
		}

		[Test()]
		public void CopyToTest()
		{
			var b1 = new byte[bytes.Length];
			var t = TestArray;
			Assert.That(() => t.CopyTo(b1, 0), Throws.Nothing);
			Assert.That(b1[4] == 4);
			var b2 = new byte[18];
			Assert.That(() => t.CopyTo(b2, 2), Throws.Nothing);
			Assert.That(b2[4] == 2);
			var b3 = new byte[8];
			Assert.That(() => t.CopyTo(b3, 0), Throws.TypeOf<ArgumentOutOfRangeException>());
			Assert.That(() => ((ICollection)t).CopyTo(new byte[4,4], 0), Throws.TypeOf<ArgumentOutOfRangeException>());
			Assert.That(() => t.CopyTo(null, 0), Throws.ArgumentNullException);
		}

		[Test()]
		public void GetEnumeratorTest()
		{
			var t = TestArray;
			byte i = 0;
			foreach (var b in t)
				Assert.That(b == i++);
			i = 0;
			foreach (var b in (IEnumerable)t)
				Assert.That((byte)b == i++);
			t.Dispose();
			foreach (var b in t)
				Assert.Fail();
		}

		[Test()]
		public void IndexerTest()
		{
			var t = TestArray;
			Assert.That(t[0] == 0);
			Assert.That(t[5] == 5);
			Assert.That(t[14] == 14);
			Assert.That(() => t[-1], Throws.TypeOf<IndexOutOfRangeException>());
			Assert.That(() => t[20], Throws.TypeOf<IndexOutOfRangeException>());

			t[0] = 255;
			t[5] = 250;
			Assert.That(t[0] == 255);
			Assert.That(t[5] == 250);
			Assert.That(() => t[-1] = 2, Throws.TypeOf<IndexOutOfRangeException>());
			Assert.That(() => t[20] = 2, Throws.TypeOf<IndexOutOfRangeException>());
		}

		[Test()]
		public void IndexOfTest()
		{
			var t = TestArray;
			Assert.That(t.IndexOf(0) == 0);
			Assert.That(t.IndexOf(5) == 5);
			Assert.That(t.IndexOf(14) == 14);
			Assert.That(t.IndexOf(20) == -1);
		}

		[Test()]
		public void ToArrayTest()
		{
			Assert.That(TestArray.ToArray(), Is.EquivalentTo(bytes));
			Assert.That(new SafeByteArray(new byte[] { 1, 2 }).ToArray(), Is.Not.EquivalentTo(bytes));
		}
	}
}