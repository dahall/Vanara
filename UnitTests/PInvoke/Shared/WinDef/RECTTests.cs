using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class RECTTests
{
	[Test()]
	public void RECTTest()
	{
		using (var h = SafeHGlobalHandle.CreateFromStructure(new RECT(1, 2, 3, 4)))
		{
			var r = h.ToStructure<RECT>();
			Assert.That(r.left == 1);
			Assert.That(r.top == 2);
			Assert.That(r.right == 3);
			Assert.That(r.bottom == 4);
		}
	}

	[Test()]
	public void RECTTest1()
	{
		var dr = new Rectangle(1, 2, 2, 2);
		var r = new RECT(dr);
		Assert.That(r.left == 1);
		Assert.That(r.top == 2);
		Assert.That(r.right == 3);
		Assert.That(r.bottom == 4);
		RECT r2 = dr;
		Assert.That(r, Is.EqualTo(r2));
		Assert.That(new RECT(0,0,0,0).IsEmpty);
		Assert.That(new RECT(1, 0, 1, 0).IsEmpty, Is.False);
		Assert.That(new RECT().GetHashCode(), Is.Zero);
		Assert.That(r.GetHashCode(), Is.Not.Zero);
	}

	[Test()]
	public void PropsTest()
	{
		var r = new RECT();
		r.X = 10;
		Assert.That(r.X == 10 && r.left == 10);
		r.Y = 5;
		Assert.That(r.Y == 5 && r.top == 5);
		Assert.That(r.Height == 0);
		r.Height = 7;
		Assert.That(r.Height == 7 && r.bottom == 12);
		r.Width = 11;
		Assert.That(r.Width == 11 && r.right == 21);
		Assert.That(r.Location == new POINT(10, 5));
		Assert.That(r.Size == new SIZE(11, 7));
		r.Size = new Size(5,5);
		Assert.That(r.Width, Is.EqualTo(5));
		Assert.That(r.Height, Is.EqualTo(5));
		r.Location = new POINT(5, 5);
		Assert.That(r.X, Is.EqualTo(5));
		Assert.That(r.Y, Is.EqualTo(5));
	}

	[Test()]
	public void EqualsTest()
	{
		var r1 = new RECT(1, 2, 3, 4);
		var r2 = new RECT(1, 2, 3, 4);
		var r3 = new RECT(1, 2, 1, 4);
		Assert.That(r1 == r2);
		Assert.That(r1 == r3, Is.False);
		Assert.That(r1 != r3);
		Assert.That(r1 != r2, Is.False);
	}

	[Test()]
	public void EqualsTest1()
	{
		var r1 = new RECT(1, 1, 4, 4);
		Assert.That(!r1.Equals((object)null));
		Assert.That(r1.Equals(r1));
		Assert.That(r1.Equals(new RECT(1, 1, 4, 4)));
		Assert.That(r1.Equals((object)new RECT(1, 1, 4, 4)));
		Assert.That(!r1.Equals(new RECT(1, 2, 4, 4)));
		Assert.That(r1.Equals(new PRECT(1, 1, 4, 4)));
		Assert.That(r1.Equals((object)new PRECT(1, 1, 4, 4)));
		Assert.That(!r1.Equals(new PRECT(1, 2, 1, 4)));
		Assert.That(r1.Equals(new Rectangle(1, 1, 3, 3)));
		Assert.That(r1.Equals((object)new Rectangle(1, 1, 3, 3)));
		Assert.That(!r1.Equals(new Rectangle(1, 2, 2, 2)));
		Assert.That(!r1.Equals(new Size(1, 2)));
	}

	[TestCase(0,0,0,0, ExpectedResult = "{left=0,top=0,right=0,bottom=0}")]
	[TestCase(10,11,12,13, ExpectedResult = "{left=10,top=11,right=12,bottom=13}")]
	public string ToStringTest(int l, int t, int r, int b) => new RECT(l,t,r,b).ToString();

	[Test]
	public void TypeConverterTest()
	{
		var conv = TypeDescriptor.GetConverter(typeof(RECT));
		var pr = new RECT(1, 1, 1, 1);
		Assert.That(conv.CanConvertFrom(typeof(string)));
		Assert.That(conv.ConvertFrom("1, 1, 1, 1"), Is.EqualTo(pr));
		Assert.That(conv.ConvertFrom("1,1,1,1"), Is.EqualTo(pr));
		Assert.That(conv.ConvertFrom(""), Is.Null);
		Assert.That(() => conv.ConvertFrom("1,1,1,1,1,1"), Throws.TypeOf<NotSupportedException>());
		Assert.That(!conv.CanConvertFrom(typeof(int)));
		Assert.That(() => conv.ConvertFrom(1), Throws.TypeOf<NotSupportedException>());
		Assert.That(() => conv.ConvertFrom("S"), Throws.TypeOf<Exception>());

		Assert.That(() => conv.ConvertTo(pr, null), Throws.ArgumentNullException);
		Assert.That(conv.CanConvertTo(typeof(string)));
		Assert.That(conv.ConvertTo(pr, typeof(string)), Is.TypeOf<string>().And.EqualTo("1, 1, 1, 1"));
		Assert.That(!conv.CanConvertTo(typeof(char)));
		Assert.That(() => conv.ConvertTo(pr, typeof(char)), Throws.TypeOf<NotSupportedException>());
		Assert.That(() => conv.ConvertTo(pr, typeof(DateTime)), Throws.TypeOf<NotSupportedException>());
		Assert.That(conv.ConvertTo(pr, typeof(InstanceDescriptor)), Is.TypeOf<InstanceDescriptor>());

		Assert.That(conv.GetCreateInstanceSupported(null));
		var r = (RECT)conv.CreateInstance(null, new Dictionary<string, int> {{"left", 4}, {"bottom", 4}});
		Assert.That(r, Is.EqualTo(new RECT(4, 0, 0, 4)));
		Assert.That(() => conv.CreateInstance(null, null), Throws.Exception);
		Assert.That(() => conv.CreateInstance(null, new Dictionary<string, object> { { "left", 4.2 }, { "bottom", 4 } }), Throws.Exception);

		Assert.That(conv.GetPropertiesSupported(null));
		var p = conv.GetProperties(null, pr);
		Assert.That(p, Has.Count.GreaterThanOrEqualTo(4));
	}
}