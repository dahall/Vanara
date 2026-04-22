using NUnit.Framework;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.OleAut32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class VariantTests
{
	[TestCase(123, VARTYPE.VT_I4)]
	[TestCase(1234L, VARTYPE.VT_I8)]
	[TestCase("Test", VARTYPE.VT_BSTR)]
	public void VariantStructTest(object o, VARTYPE vt)
	{
		VARIANT v = new(o);
		Assert.That(v.vt, Is.EqualTo(vt));
		Assert.That(v.ToObject(), Is.TypeOf(o.GetType()));
	}
}