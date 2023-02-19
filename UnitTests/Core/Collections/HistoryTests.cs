using NUnit.Framework;
using System;
using System.ComponentModel;
using System.Linq;
using Vanara.Extensions.Reflection;

namespace Vanara.Collections.Tests;

[TestFixture()]
public class HistoryTests
{
	[Test]
	public void Test()
	{
		var history = new History<int>(Enumerable.Range(1, 300));
		history.CollectionChanged += (s, e) => TestContext.WriteLine($"{e.Action}: New={e.NewItems?.Count ?? 0} Old={e.OldItems?.Count ?? 0}");
		history.PropertyChanged += GetPropVal;
		Assert.That(history.Count, Is.EqualTo(300));

		history.Capacity = 20;
		Assert.That(history.Capacity, Is.EqualTo(20));
		Assert.That(history.Count, Is.EqualTo(20));
		Assert.That(history.Count(), Is.EqualTo(20));
		Assert.That(history.Current, Is.EqualTo(300));

		Assert.That(history, Is.EquivalentTo(Enumerable.Range(281, 20)));
		Assert.That(history.GetItems(10, System.IO.SeekOrigin.Begin), Is.EquivalentTo(Enumerable.Range(281, 10)));
		Assert.That(history.GetItems(-10, System.IO.SeekOrigin.End), Is.EquivalentTo(Enumerable.Range(291, 10)));

		Assert.That(history.CanSeekForward, Is.False);
		Assert.That(history.CanSeekBackward, Is.True);

		Assert.That(history.SeekBackward, Is.EqualTo(299));
		Assert.That(history.CanSeekForward, Is.True);
		Assert.That(history.CanSeekBackward, Is.True);

		Assert.That(history.Seek(0, System.IO.SeekOrigin.Begin), Is.EqualTo(281));
		Assert.That(history.CanSeekForward, Is.True);
		Assert.That(history.CanSeekBackward, Is.False);

		Assert.That(history.SeekForward, Is.EqualTo(282));
		Assert.That(history.CanSeekForward, Is.True);
		Assert.That(history.CanSeekBackward, Is.True);

		Assert.That(history.Seek(9, System.IO.SeekOrigin.Current), Is.EqualTo(291));
		Assert.That(history.CanSeekForward, Is.True);
		Assert.That(history.CanSeekBackward, Is.True);

		Assert.That(history.Seek(-5, System.IO.SeekOrigin.Current), Is.EqualTo(286));
		Assert.That(history.CanSeekForward, Is.True);
		Assert.That(history.CanSeekBackward, Is.True);

		Assert.That(history.Seek(0, System.IO.SeekOrigin.End), Is.EqualTo(300));
		Assert.That(history.CanSeekForward, Is.False);
		Assert.That(history.CanSeekBackward, Is.True);

		history.Add(301);
		Assert.That(history.Current, Is.EqualTo(301));
		Assert.That(history.CanSeekForward, Is.False);
		Assert.That(history.CanSeekBackward, Is.True);
		Assert.That(history.Seek(0, System.IO.SeekOrigin.Begin), Is.EqualTo(282));

		history.Clear();
		Assert.That(history.CanSeekForward, Is.False);
		Assert.That(history.CanSeekBackward, Is.False);
		Assert.That(() => history.Current, Throws.Exception);

		void GetPropVal(object sender, PropertyChangedEventArgs e)
		{
			var pi = history.GetType().GetProperty(e.PropertyName);
			object obj = null;
			try { obj = pi.GetValue(history); } catch (Exception ex) { obj = ex.GetType().Name; }
			TestContext.WriteLine($"{e.PropertyName}={obj}");
		}
	}
}