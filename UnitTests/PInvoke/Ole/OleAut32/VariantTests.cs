using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.OleAut32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class VariantTests
{
	[Test]
	public void VariantStructTest()
	{
		object o = 123;
		VARIANT v = new(o);
		Assert.That(v.vt, Is.EqualTo(VARTYPE.VT_I4));
		Assert.That(v.ToObject(), Is.TypeOf<int>());

		o = 1234L;
		v = new VARIANT(o);
		Assert.That(v.vt, Is.EqualTo(VARTYPE.VT_I8));
		Assert.That(v.ToObject(), Is.TypeOf<long>());

		o = "Test";
		v = new VARIANT(o);
		Assert.That(v.vt, Is.EqualTo(VARTYPE.VT_BSTR));
		Assert.That(v.ToObject(), Is.TypeOf<string>());
	}
}