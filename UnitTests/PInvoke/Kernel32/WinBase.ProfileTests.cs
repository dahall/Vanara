using NUnit.Framework;
using System.Text;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public partial class WinBaseTests_Profile
	{
		[Test]
		public void PrivateProfileTest()
		{
			const string sec = "Section";

			using (var tmp = new TempFile(""))
			{
				Assert.That(WritePrivateProfileSection(sec, "Key0=10\0", tmp.FullName), ResultIs.Successful);
				Assert.That(WritePrivateProfileString(sec, "Key1", "Value1", tmp.FullName), ResultIs.Successful);
				Assert.That(WritePrivateProfileStruct(sec, "Key2", new RECT(1, 2, 3, 4), tmp.FullName), ResultIs.Successful);
				Assert.That(WritePrivateProfileStruct(sec, "Key3", 4, tmp.FullName), ResultIs.Successful);
				TestContext.WriteLine(System.IO.File.ReadAllText(tmp.FullName));

				Assert.That(GetPrivateProfileInt(sec, "Key0", 0, tmp.FullName), Is.EqualTo(10));
				Assert.That(GetPrivateProfileInt(sec, "Key3", 0, tmp.FullName), Is.Not.EqualTo(4));
				Assert.That(GetPrivateProfileInt(sec, "Key4", 0, tmp.FullName), Is.EqualTo(0));

				var sb = new StringBuilder(1024);
				Assert.That(GetPrivateProfileSection(sec, sb, (uint)sb.Capacity, tmp.FullName), Is.GreaterThan(0).And.Not.EqualTo(sb.Capacity - 2));
				TestContext.WriteLine(sb);

				sb.Clear();
				Assert.That(GetPrivateProfileSectionNames(sb, (uint)sb.Capacity, tmp.FullName), Is.GreaterThan(0).And.Not.EqualTo(sb.Capacity - 2));
				TestContext.WriteLine(sb);

				sb.Clear();
				Assert.That(GetPrivateProfileString(sec, "Key0", null, sb, (uint)sb.Capacity, tmp.FullName), Is.GreaterThan(0).And.Not.EqualTo(sb.Capacity - 2));
				Assert.That(sb.ToString(), Is.EqualTo("10"));
				sb.Clear();
				Assert.That(GetPrivateProfileString(sec, "Key1", null, sb, (uint)sb.Capacity, tmp.FullName), Is.GreaterThan(0).And.Not.EqualTo(sb.Capacity - 2));
				Assert.That(sb.ToString(), Is.EqualTo("Value1"));
				sb.Clear();
				Assert.That(GetPrivateProfileString(sec, "Key3", null, sb, (uint)sb.Capacity, tmp.FullName), Is.GreaterThan(0).And.Not.EqualTo(sb.Capacity - 2));
				Assert.That(sb.ToString(), Is.EqualTo("0400000004"));

				Assert.That(GetPrivateProfileStruct(sec, "Key2", out RECT r, tmp.FullName), Is.True);
				Assert.That(r.bottom, Is.EqualTo(4));
				Assert.That(GetPrivateProfileStruct(sec, "Key3", out int i, tmp.FullName), Is.True);
				Assert.That(i, Is.EqualTo(4));
				Assert.That(GetPrivateProfileStruct(sec, "Key0", out i, tmp.FullName), Is.False);
			}
		}

		[Test]
		public void ProfileTest()
		{
			const string sec = "Section";

			Assert.That(WriteProfileSection(sec, "Key0=10\0"), ResultIs.Successful);
			Assert.That(WriteProfileString(sec, "Key1", "Value1"), ResultIs.Successful);

			Assert.That(GetProfileInt(sec, "Key0", 0), Is.EqualTo(10));
			Assert.That(GetProfileInt(sec, "Key4", 0), Is.EqualTo(0));

			var sb = new StringBuilder(1024);
			Assert.That(GetProfileSection(sec, sb, (uint)sb.Capacity), Is.GreaterThan(0).And.Not.EqualTo(sb.Capacity - 2));
			TestContext.WriteLine(sb);

			sb.Clear();
			Assert.That(GetProfileString(sec, "Key0", null, sb, (uint)sb.Capacity), Is.GreaterThan(0).And.Not.EqualTo(sb.Capacity - 2));
			Assert.That(sb.ToString(), Is.EqualTo("10"));
			sb.Clear();
			Assert.That(GetProfileString(sec, "Key1", null, sb, (uint)sb.Capacity), Is.GreaterThan(0).And.Not.EqualTo(sb.Capacity - 2));
			Assert.That(sb.ToString(), Is.EqualTo("Value1"));
		}
	}
}