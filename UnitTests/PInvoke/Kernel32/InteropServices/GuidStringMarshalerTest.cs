using NUnit.Framework;

namespace Vanara.InteropServices.Tests;

[TestFixture]
public class GuidStringMarshalerTest
{
	private const string gstr = "00000000-0000-c000-0000-000000000000";

	[TestCase(null, "D", CharSet.Auto)]
	[TestCase("", "D", CharSet.Auto)]
	[TestCase("D,Unicode", "D", CharSet.Unicode)]
	[TestCase("N,Unicode", "N", CharSet.Unicode)]
	[TestCase("N,Ansi", "N", CharSet.Ansi)]
	[TestCase("N,Auto", "N", CharSet.Auto)]
	[TestCase("N", "N", CharSet.Auto)]
	[TestCase("Auto", "D", CharSet.Auto)]
	[TestCase("Q", null, 0)]
	[TestCase("Q,Auto", null, 0)]
	[TestCase("N,B,C", null, 0)]
	[TestCase("UTF", null, 0)]
	[TestCase("N,UTF", null, 0)]
	public void CreateTest(string cookie, string? fmt, CharSet cs)
	{
		GuidToStringMarshaler? m = null;
		if (fmt is not null)
		{
			Assert.That(() => m = (GuidToStringMarshaler)GuidToStringMarshaler.GetInstance(cookie), Throws.Nothing);
			Assert.That(m!.fmt, Is.EqualTo(fmt));
			Assert.That(m.charSet, Is.EqualTo(cs));
		}
		else
		{
			Assert.That(() => m = (GuidToStringMarshaler)GuidToStringMarshaler.GetInstance(cookie), Throws.TypeOf<FormatException>());
		}
	}

	[Test]
	public void ManagedToNativeTest()
	{
		Guid g = new(gstr);
		var m = GuidToStringMarshaler.GetInstance("D,Unicode");

		IntPtr p;
		Assert.That(Marshal.PtrToStringUni(p = m.MarshalManagedToNative(null!)), Is.Null);
		Assert.That(Marshal.PtrToStringUni(p = m.MarshalManagedToNative(g)), Is.EqualTo(gstr));
		m.CleanUpNativeData(p);
		Assert.That(Marshal.PtrToStringUni(p = m.MarshalManagedToNative(gstr)), Is.EqualTo(gstr));
		m.CleanUpNativeData(p);
		Assert.That(Marshal.PtrToStringUni(p = m.MarshalManagedToNative($"{{{gstr}}}")), Is.EqualTo(gstr));
		m.CleanUpNativeData(p);

		Assert.That(() => m.MarshalManagedToNative(123), Throws.TypeOf<ArgumentException>());
		Assert.That(() => m.MarshalManagedToNative("123"), Throws.TypeOf<ArgumentException>());
	}

	[Test]
	public void NativeToManagedTest()
	{
		Guid g = new(gstr);
		var m = GuidToStringMarshaler.GetInstance("D,Unicode");

		Assert.That(m.MarshalNativeToManaged(IntPtr.Zero), Is.Null);
		using SafeLPWSTR ps = new(gstr);
		Assert.That(m.MarshalNativeToManaged(ps), Is.EqualTo(g));
	}
}