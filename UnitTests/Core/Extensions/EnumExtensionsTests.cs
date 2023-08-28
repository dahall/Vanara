using NUnit.Framework;
using System.ComponentModel;
using System.Linq;
using static Vanara.Extensions.EnumExtensions;

namespace Vanara.Extensions.Tests;

[TestFixture()]
public class EnumExtensionsTests
{
	[Flags]
	private enum TestEnum
	{
		[System.ComponentModel.Description("My first value.")]
		Value1 = 1,
		Value2 = 2,
		[System.ComponentModel.Description("My third value.")]
		Value3 = 4
	}

	private const TestEnum test = TestEnum.Value1 | TestEnum.Value2;

	[Test()]
	public void CheckHasValueTest()
	{
		Assert.DoesNotThrow(() => CheckHasValue(test));
		Assert.Throws<InvalidEnumArgumentException>(() => CheckHasValue((TestEnum)8));

		Assert.DoesNotThrow(() => CheckHasValue(ConsoleColor.Blue));
		Assert.Throws<InvalidEnumArgumentException>(() => CheckHasValue((ConsoleColor)30));
	}

	[Test()]
	public void ClearFlagsTest()
	{
		Assert.That(test.ClearFlags(TestEnum.Value1), Is.EqualTo(TestEnum.Value2));
		Assert.That(test.ClearFlags(TestEnum.Value3), Is.EqualTo(test));
	}

	[Test()]
	public void CombineFlagsTest()
	{
		var array = new[] {TestEnum.Value1, TestEnum.Value2};
		Assert.That(array.CombineFlags(), Is.EqualTo(test));
	}

	[Test()]
	public void GetDescriptionTest()
	{
		Assert.That(TestEnum.Value1.GetDescription(), Is.EqualTo("My first value."));
		Assert.That(TestEnum.Value2.GetDescription(), Is.EqualTo("Value2"));
		Assert.That(test.GetDescription(), Is.EqualTo("Value1, Value2"));
	}

	[Test()]
	public void GetFlagsTest()
	{
		var en = test.GetFlags();
		Assert.That(en.Count(), Is.EqualTo(2));
		Assert.That(en.Contains(TestEnum.Value1), Is.True);
	}

	[Test()]
	public void IsFlagSetTest()
	{
		Assert.That(test.IsFlagSet(TestEnum.Value1), Is.True);
		Assert.That(test.IsFlagSet(TestEnum.Value3), Is.False);

		Assert.Throws<ArgumentException>(() => ConsoleColor.Blue.IsFlagSet(ConsoleColor.Blue));
	}

	[Test()]
	public void IsValidTest()
	{
		Assert.That(test.IsValid(), Is.True);
		Assert.That((test | (TestEnum)8).IsValid(), Is.False);
		Assert.That(ConsoleColor.Blue.IsValid(), Is.True);
		Assert.That(((ConsoleColor)30).IsValid(), Is.False);
	}

	[Test()]
	public void SetFlagsTest()
	{
		Assert.That(test.SetFlags(TestEnum.Value1, false), Is.EqualTo(TestEnum.Value2));
		Assert.That(test.SetFlags(TestEnum.Value1, true), Is.EqualTo(test));
		Assert.That(test.SetFlags(TestEnum.Value3, false), Is.EqualTo(test));
		Assert.That(test.SetFlags(TestEnum.Value3, true), Is.EqualTo(TestEnum.Value1 | TestEnum.Value2 | TestEnum.Value3));
	}

	[Test()]
	public void SetFlagsTest1()
	{
		var t = test;
		SetFlags(ref t, TestEnum.Value3, false);
		Assert.That(t, Is.EqualTo(test));
		SetFlags(ref t, TestEnum.Value1, false);
		Assert.That(t, Is.EqualTo(TestEnum.Value2));
		SetFlags(ref t, TestEnum.Value2, true);
		Assert.That(t, Is.EqualTo(TestEnum.Value2));
		SetFlags(ref t, TestEnum.Value1, true);
		Assert.That(t, Is.EqualTo(test));
		SetFlags(ref t, TestEnum.Value1, true);
		Assert.That(t, Is.EqualTo(test));
	}
}