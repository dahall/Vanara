using NUnit.Framework;
using Vanara.PInvoke;

namespace Vanara.InteropServices.Tests
{
	[TestFixture()]
	public class SafeNativeArrayTests
	{
		[Test()]
		public void Test()
		{
			var a1 = new SafeNativeArray<RECT>(20);
			Assert.That(a1.Count, Is.EqualTo(20));
			Assert.That(a1[5], Is.EqualTo(new RECT()));
			a1.Add(new RECT(1, 1, 1, 1));
			Assert.That(a1.Count, Is.EqualTo(21));
			Assert.That(a1[20], Is.EqualTo(new RECT(1,1,1,1)));
			a1[5] = new RECT(5, 5, 5, 5);
			Assert.That(a1[5], Is.EqualTo(new RECT(5, 5, 5, 5)));
			a1.RemoveAt(5);
			Assert.That(a1.Count, Is.EqualTo(20));
			Assert.That(a1[5], Is.EqualTo(new RECT()));
			Assert.That(a1[19], Is.EqualTo(new RECT(1, 1, 1, 1)));
			a1.Insert(5, new RECT(5, 5, 5, 5));
			Assert.That(a1[5], Is.EqualTo(new RECT(5, 5, 5, 5)));
			Assert.That(a1[20], Is.EqualTo(new RECT(1, 1, 1, 1)));
		}
	}
}