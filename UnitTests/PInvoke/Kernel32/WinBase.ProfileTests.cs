using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Vanara.Configuration;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public partial class WinBaseTests_Profile
{
	private const int cnt = 20;

	[Test]
	public void PrivateProfileTest()
	{
		const string sec = "Section";

		using TempFile tmp = new("");
		Assert.That(WritePrivateProfileSection(sec, MakeSectionKeys(), tmp.FullName), ResultIs.Successful);
		Assert.That(WritePrivateProfileString(sec, "Key21", "Value1", tmp.FullName), ResultIs.Successful);
		Assert.That(WritePrivateProfileStruct(sec, "Key22", new RECT(1, 2, 3, 4), tmp.FullName), ResultIs.Successful);
		Assert.That(WritePrivateProfileStruct(sec, "Key23", 4, tmp.FullName), ResultIs.Successful);
		TestContext.WriteLine(File.ReadAllText(tmp.FullName));

		Assert.That(GetPrivateProfileInt(sec, "Key1", 0, tmp.FullName), Is.EqualTo(1));
		Assert.That(GetPrivateProfileInt(sec, "Key23", 0, tmp.FullName), Is.Not.EqualTo(4));
		Assert.That(GetPrivateProfileInt(sec, "Key24", 0, tmp.FullName), Is.EqualTo(0));

		string[] secVals = GetPrivateProfileSection(sec, tmp.FullName);
		Assert.That(secVals.Length, Is.EqualTo(cnt + 3));
		TestContext.WriteLine(string.Join("; ", secVals));

		string[] secNames = GetPrivateProfileSectionNames(tmp.FullName);
		Assert.That(secNames.Length, Is.EqualTo(1));
		TestContext.WriteLine(string.Join("; ", secNames));

		StringBuilder sb = new(256);
		Assert.That(GetPrivateProfileString(sec, "Key1", null, sb, (uint)sb.Capacity, tmp.FullName), Is.GreaterThan(0).And.Not.EqualTo(sb.Capacity - 2));
		Assert.That(sb.ToString(), Is.EqualTo("1"));
		sb.Clear();
		Assert.That(GetPrivateProfileString(sec, "Key21", null, sb, (uint)sb.Capacity, tmp.FullName), Is.GreaterThan(0).And.Not.EqualTo(sb.Capacity - 2));
		Assert.That(sb.ToString(), Is.EqualTo("Value1"));
		sb.Clear();
		Assert.That(GetPrivateProfileString(sec, "Key23", null, sb, (uint)sb.Capacity, tmp.FullName), Is.GreaterThan(0).And.Not.EqualTo(sb.Capacity - 2));
		Assert.That(sb.ToString(), Is.EqualTo("0400000004"));

		Assert.That(GetPrivateProfileStruct(sec, "Key22", out RECT r, tmp.FullName), Is.True);
		Assert.That(r.bottom, Is.EqualTo(4));
		Assert.That(GetPrivateProfileStruct(sec, "Key23", out int i, tmp.FullName), Is.True);
		Assert.That(i, Is.EqualTo(4));
		Assert.That(GetPrivateProfileStruct(sec, "Key0", out i, tmp.FullName), Is.False);
	}

	[Test]
	public void PrivateProfileWrapperTest()
	{
		using TempFile tmp = new("");
		InitializationFile ppf = new(tmp.FullName);
		Assert.That(ppf.FullName, Is.EqualTo(tmp.FullName));

		const string secName = "Section";
		InitializationFile.InitializationFileSection sec = ppf.Sections.Add(secName);
		Assert.That(sec.Name, Is.EqualTo(secName));
		sec.AddRange(Enumerable.Range(0, cnt).Select(i => new KeyValuePair<string, string>($"Key{i}", i.ToString())));
		sec.Add("Key20", string.Empty);
		sec.SetValue("Key21", "Value");
		Assert.That(sec["Key21"], Is.EqualTo("Value"));
		sec["Key21"] = "Value1";
		sec.SetValue("Key22", new RECT(1, 2, 3, 4));
		sec.SetValue("Key23", 4L);
		DumpFile();
		Assert.That(ppf.Sections.Count, Is.EqualTo(1));
		Assert.That(ppf.Sections.Contains(secName.ToLower()));
		Assert.That(ppf.Sections[secName], Is.Not.Null.And.Property("Name").EqualTo(secName));

		Assert.That(sec.TryGetValue("Key1", out int iVal));
		Assert.That(iVal, Is.EqualTo(1));
		Assert.That(sec.TryGetValue("Key1", out uint uVal));
		Assert.That(uVal, Is.EqualTo(1));
		Assert.That(sec.TryGetValue("Key23", out long lVal));
		Assert.That(lVal, Is.EqualTo(4));
		Assert.That(!sec.TryGetValue("Key20", out iVal));
		Assert.That(!sec.TryGetValue("Key24", out iVal));

		KeyValuePair<string, string>[] secVals = sec.ToArray();
		Assert.That(secVals.Length, Is.EqualTo(cnt + 4));
		TestContext.WriteLine(string.Join("; ", secVals.Select(kv => $"{kv.Key}={kv.Value}")));

		string[] secNames = sec.Keys.ToArray();
		Assert.That(secNames.Length, Is.EqualTo(cnt + 4));
		TestContext.WriteLine(string.Join("; ", secNames));

		Assert.That(sec["Key1"], Is.EqualTo("1"));
		Assert.That(sec["Key21"], Is.EqualTo("Value1"));
		Assert.That(sec["Key23"], Is.EqualTo("040000000000000004"));
		Assert.That(sec.TryGetValue("Key20", out string sVal));
		Assert.That(sVal, Is.EqualTo(""));
		Assert.That(!sec.TryGetValue("Key24", out sVal));

		Assert.That(sec.TryGetValue("Key22", out RECT r), Is.True);
		Assert.That(r.bottom, Is.EqualTo(4));

		sec.Add("Key100", "100");
		Assert.That(sec.Count, Is.EqualTo(cnt + 5));
		Assert.That(!sec.Remove(new KeyValuePair<string, string>("Key100", "200")));
		Assert.That(sec.Remove(new KeyValuePair<string, string>("Key100", "100")));
		Assert.That(sec.Count, Is.EqualTo(cnt + 4));

		Assert.That(() => sec.Clear(), Throws.Nothing);
		Assert.That(sec.Count, Is.Zero);
		Assert.That(new FileInfo(tmp.FullName).Length, Is.GreaterThan(0));
		DumpFile();

		Assert.That(() => ppf.Sections.Add("Other"), Throws.Nothing);
		Assert.That(ppf.Sections.Count, Is.EqualTo(2));
		Assert.That(() => ppf.Sections.Remove(sec), Throws.Nothing);
		Assert.That(ppf.Sections.Count, Is.EqualTo(1));
		Assert.That(ppf.Sections.Contains("OTHER"));
		Assert.That(() => ppf.Sections.Clear(), Throws.Nothing);
		Assert.That(ppf.Sections.Count, Is.Zero);
		Assert.That(new FileInfo(tmp.FullName).Length, Is.LessThan(8));
		DumpFile();

		void DumpFile() => TestContext.WriteLine("=============\r\n" + File.ReadAllText(tmp.FullName));
	}

	[Test]
	public void ProfileTest()
	{
		const string sec = "ImpossibleSection029340985634987";

		try
		{
			Assert.That(WriteProfileSection(sec, MakeSectionKeys()), ResultIs.Successful);
			Assert.That(WriteProfileString(sec, "Key21", "Value1"), ResultIs.Successful);

			Assert.That(GetProfileInt(sec, "Key1", 0), Is.EqualTo(1));
			Assert.That(GetProfileInt(sec, "Key24", 0), Is.EqualTo(0));

			string[] secVals = GetProfileSection(sec);
			Assert.That(secVals.Length, Is.EqualTo(cnt + 1));
			TestContext.WriteLine(string.Join("; ", secVals));

			StringBuilder sb = new(256);
			Assert.That(GetProfileString(sec, "Key1", null, sb, (uint)sb.Capacity), Is.GreaterThan(0).And.Not.EqualTo(sb.Capacity - 2));
			Assert.That(sb.ToString(), Is.EqualTo("1"));
			sb.Clear();
			Assert.That(GetProfileString(sec, "Key21", null, sb, (uint)sb.Capacity), Is.GreaterThan(0).And.Not.EqualTo(sb.Capacity - 2));
			Assert.That(sb.ToString(), Is.EqualTo("Value1"));
		}
		finally
		{
			// Cleanup changes to win.ini
			WriteProfileString(sec, null, null);
		}
	}

	private string[] MakeSectionKeys() => Enumerable.Range(0, cnt).Select(i => $"Key{i}={i}").ToArray();
}