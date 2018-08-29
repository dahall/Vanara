using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Vanara.Collections.Generic.Tests
{
	[TestFixture()]
	public class HashSetTests
	{
		[Test]
		public void CtorTest()
		{
			var s1 = new HashSet<string>(NumGen(0, 2, 20));
			Assert.That(s1.Count, Is.EqualTo(20));
			Assert.That(s1.Comparer.Equals("S", "s"), Is.False);
			var s3 = new HashSet<string>(NumGen(0, 2, 20), StringComparer.CurrentCultureIgnoreCase);
			Assert.That(s3.Count, Is.EqualTo(20));
			Assert.That(s3.Comparer.Equals("S", "s"), Is.True);
			var s5 = new HashSet<string>();
			Assert.That(s5.Count, Is.EqualTo(0));
			Assert.That(s5.Comparer.Equals("S", "s"), Is.False);
			var s6 = new HashSet<string>(StringComparer.CurrentCultureIgnoreCase);
			Assert.That(s6.Count, Is.EqualTo(0));
			Assert.That(s6.Comparer.Equals("S", "s"), Is.True);

			// Test dup values
			var s7 = new HashSet<string>(NumGen(3, 0, 10));
			Assert.That(s7.Count, Is.EqualTo(1));
			Assert.That(s7.First(), Is.EqualTo("3"));
		}

		[Test]
		public void ClearTest()
		{
			var s1 = new HashSet<string>(NumGen(0, 2, 20));
			Assert.That(s1.Count, Is.EqualTo(20));
			s1.Clear();
			Assert.That(s1.Count, Is.EqualTo(0));
		}

		[Test]
		public void ContainsTest()
		{
			var s1 = new HashSet<string>(NumGen(0, 2, 20));
			Assert.That(s1.Contains("2"), Is.True);
			Assert.That(s1.Contains("21"), Is.False);
		}

		[Test]
		public void CopyToTest()
		{
			var s1 = new HashSet<string>(NumGen(0, 2, 20));
			var sa = new string[20];
			s1.CopyTo(sa, 0);
			Assert.That(sa.All(s => s != null), Is.True);
			Assert.That(sa[1], Is.EqualTo("2"));

			Assert.That(() => s1.CopyTo(sa, 10), Throws.Exception);
			sa = new string[10];
			Assert.That(() => s1.CopyTo(sa, 0), Throws.Exception);
		}

		[Test]
		public void ExceptWithTest()
		{
			var s1 = new HashSet<string>(NumGen(0, 2, 20));

			Assert.That(() => s1.ExceptWith(null), Throws.Exception);

			s1.ExceptWith(NumGen(4, 2, 18));
			Assert.That(s1.Count, Is.EqualTo(2));
			Assert.That(s1.Contains("2"), Is.True);

			s1.ExceptWith(s1);
			Assert.That(s1.Count, Is.EqualTo(0));

			s1.ExceptWith(NumGen(0, 2, 4));
			Assert.That(s1.Count, Is.EqualTo(0));
		}

		[Test]
		public void IntersectWithTest()
		{
			var s1 = new HashSet<string>(NumGen(0, 2, 20));

			Assert.That(() => s1.IntersectWith(null), Throws.Exception);

			var other = new List<string>();
			s1.IntersectWith(other);
			Assert.That(s1.Count, Is.EqualTo(0));

			s1 = new HashSet<string>(NumGen(0, 2, 20));
			var e = NumGen(4, 2, 4);
			s1.IntersectWith(e);
			Assert.That(s1.Count, Is.EqualTo(4));
			Assert.That(s1, Is.EquivalentTo(e));

			s1.IntersectWith(new[] {"3"});
			Assert.That(s1.Count, Is.EqualTo(0));
		}

		[Test]
		public void IsProperSubsetOfTest()
		{
			var s1 = new HashSet<string>(NumGen(4, 2, 10));

			Assert.That(() => s1.IsProperSubsetOf(null), Throws.Exception);

			var s2 = new HashSet<string>(NumGen(0, 2, 20));
			Assert.That(s1.IsProperSubsetOf(s2), Is.True);

			var s3 = new HashSet<string>(NumGen(4, 2, 10));
			Assert.That(s1.IsProperSubsetOf(s3), Is.False);

			var s4 = new HashSet<string>(NumGen(1, 2, 10));
			Assert.That(s1.IsProperSubsetOf(s4), Is.False);

			s1.Clear();
			Assert.That(s1.IsProperSubsetOf(s2), Is.True);
			s2.Clear();
			Assert.That(s1.IsProperSubsetOf(s2), Is.False);
		}

		[Test]
		public void IsProperSupersetOfTest()
		{
			var s1 = new HashSet<string>(NumGen(0, 2, 20));

			Assert.That(() => s1.IsProperSupersetOf(null), Throws.Exception);

			var s2 = new HashSet<string>(NumGen(4, 2, 10));
			Assert.That(s1.IsProperSupersetOf(s2), Is.True);

			var s3 = new HashSet<string>(NumGen(0, 2, 20));
			Assert.That(s1.IsProperSupersetOf(s3), Is.False);

			var s4 = new HashSet<string>(NumGen(1, 2, 10));
			Assert.That(s1.IsProperSupersetOf(s4), Is.False);

			s1.Clear();
			Assert.That(s1.IsProperSupersetOf(s2), Is.False);
			Assert.That(s3.IsProperSupersetOf(s1), Is.True);
		}

		[Test]
		public void IsSubsetOfTest()
		{
			var s1 = new HashSet<string>(NumGen(4, 2, 10));

			Assert.That(() => s1.IsSubsetOf(null), Throws.Exception);

			var s2 = new HashSet<string>(NumGen(0, 2, 20));
			Assert.That(s1.IsSubsetOf(s2), Is.True);

			var s3 = new HashSet<string>(NumGen(4, 2, 10));
			Assert.That(s1.IsSubsetOf(s3), Is.True);

			var s4 = new HashSet<string>(NumGen(1, 2, 10));
			Assert.That(s1.IsSubsetOf(s4), Is.False);

			s1.Clear();
			Assert.That(s1.IsSubsetOf(s2), Is.True);
			s2.Clear();
			Assert.That(s1.IsSubsetOf(s2), Is.True);
		}

		[Test]
		public void IsSupersetOfTest()
		{
			var s1 = new HashSet<string>(NumGen(0, 2, 20));

			Assert.That(() => s1.IsSupersetOf(null), Throws.Exception);

			var s2 = new HashSet<string>(NumGen(4, 2, 10));
			Assert.That(s1.IsSupersetOf(s2), Is.True);

			var s3 = new HashSet<string>(NumGen(0, 2, 20));
			Assert.That(s1.IsSupersetOf(s3), Is.True);

			var s4 = new HashSet<string>(NumGen(1, 2, 10));
			Assert.That(s1.IsSupersetOf(s4), Is.False);

			s1.Clear();
			Assert.That(s1.IsSupersetOf(s2), Is.False);
			Assert.That(s3.IsSupersetOf(s1), Is.True);
		}

		[Test]
		public void OverlapsTest()
		{
			var s1 = new HashSet<string>(NumGen(0, 2, 20));

			Assert.That(() => s1.Overlaps(null), Throws.Exception);

			var s2 = new HashSet<string>(NumGen(4, 2, 10));
			Assert.That(s1.Overlaps(s2), Is.True);

			Assert.That(s1.Overlaps(new[] {"0"}), Is.True);
			Assert.That(s1.Overlaps(new[] {"38"}), Is.True);
			Assert.That(s1.Overlaps(new[] {"40"}), Is.False);
			Assert.That(s1.Overlaps(new[] {"0", "X", "."}), Is.True);

			s1.Clear();
			Assert.That(s1.Overlaps(s2), Is.False);
		}

		[Test]
		public void RemoveTest()
		{
			var s1 = new HashSet<string>(NumGen(0, 2, 5));
			Assert.That(s1.Remove("0"), Is.True);
			Assert.That(s1.Remove("1"), Is.False);
			Assert.That(s1.Remove(null), Is.False);
		}

		[Test]
		public void SetEqualsTest()
		{
			var s1 = new HashSet<string>(NumGen(0, 2, 10));

			Assert.That(() => s1.SetEquals(null), Throws.Exception);

			Assert.That(s1.SetEquals(NumGen(0, 2, 10)), Is.True);
			Assert.That(s1.SetEquals(NumGen(0, 2, 5)), Is.False);
			Assert.That(s1.SetEquals(NumGen(1, 2, 2)), Is.False);

			var s2 = new HashSet<string>(NumGen(0, 2, 10));
			Assert.That(s1.SetEquals(s2), Is.True);

			s2.Remove("0");
			Assert.That(s1.SetEquals(s2), Is.False);
		}

		[Test]
		public void SymmetricExceptTest()
		{
			var s1 = new HashSet<string>();

			Assert.That(() => s1.SymmetricExceptWith(null), Throws.Exception);

			var e1 = NumGen(0, 2, 5).ToArray();
			s1.SymmetricExceptWith(e1);
			Assert.That(s1, Is.EquivalentTo(e1));

			s1.SymmetricExceptWith(s1);
			Assert.That(s1.Count, Is.EqualTo(0));

			s1 = new HashSet<string>(e1);
			var s2 = new HashSet<string>(NumGen(10, 2, 5));
			s1.SymmetricExceptWith(s2);
			Assert.That(s1.Count, Is.EqualTo(10));

			s1.SymmetricExceptWith(s2);
			Assert.That(s1.Count, Is.EqualTo(5));
			Assert.That(s1, Is.EquivalentTo(e1));

			var s3 = new HashSet<string>(NumGen(6, 2, 5));
			s1.SymmetricExceptWith(s3);
			Assert.That(s1.Count, Is.EqualTo(6));
			Assert.That(s1.Contains("4"), Is.True);
			Assert.That(s1.Contains("6"), Is.False);
			Assert.That(s1.Contains("10"), Is.True);
		}

		/*[Test]
		public void TryGetValueTest()
		{
			var s1 = new HashSet<Tester>(new Tester.Comparer());
			s1.Add("Test1");
			s1.Add("Test2");
			s1.Add("Test3");

			var t2 = new Tester {Name = "test2", Value = 12};
			Assert.That(s1.TryGetValue(t2, out var o2), Is.True);
			Assert.That(o2.Value, Is.Zero);
		}

		public class Tester
		{
			public string Name { get; set; }
			public int Value { get; set; }

			public static implicit operator Tester(string value) => new Tester {Name = value};

			public class Comparer : EqualityComparer<Tester>
			{
				public override bool Equals(Tester x, Tester y) => StringComparer.InvariantCultureIgnoreCase.Compare(x?.Name, y?.Name) == 0;
				public override int GetHashCode(Tester obj) => obj?.Name.ToLowerInvariant().GetHashCode() ?? 0;
			}
		}*/

		[Test]
		public void UnionWithTest()
		{
			var s1 = new HashSet<string>();

			Assert.That(() => s1.UnionWith(null), Throws.Exception);

			var e1 = NumGen(0, 2, 5).ToArray();
			s1.UnionWith(e1);
			Assert.That(s1, Is.EquivalentTo(e1));

			s1.UnionWith(s1);
			Assert.That(s1, Is.EquivalentTo(e1));

			s1.UnionWith(e1);
			Assert.That(s1, Is.EquivalentTo(e1));

			var s2 = new HashSet<string>(NumGen(10, 2, 5));
			s1.UnionWith(s2);
			Assert.That(s1.Count, Is.EqualTo(10));

			s1.UnionWith(s2);
			Assert.That(s1.Count, Is.EqualTo(10));

			var s3 = new HashSet<string>(NumGen(16, 2, 5));
			s1.UnionWith(s3);
			Assert.That(s1.Count, Is.EqualTo(13));
		}

		private static IEnumerable<string> NumGen(int start, int incr, int count, string prefix = "")
		{
			var n = start;
			for (var i = 0; i < count; i++, n += incr)
				yield return $"{prefix}{n}";
		}
	}
}