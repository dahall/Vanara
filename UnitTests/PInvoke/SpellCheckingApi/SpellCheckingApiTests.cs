using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.SpellCheck;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class SpellCheckingApiTests
{
	private const string lang = "en-US";
	private ISpellChecker? checker;
	private ISpellCheckerFactory? factory;

	[OneTimeSetUp]
	public void _Setup()
	{
		Assert.That(factory = new(), Is.Not.Null);
		Assert.That(factory!.IsSupported(lang), Is.True);
		Assert.That(checker = factory.CreateSpellChecker(lang), Is.Not.Null);
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
		Marshal.ReleaseComObject(checker!);
		checker = null;
		Marshal.ReleaseComObject(factory!);
		factory = null;
	}

	[Test]
	public void CheckPropertiesTest()
	{
		Assert.That(checker!.LanguageTag, Is.EqualTo(lang));
		Assert.That(checker.Id, Is.EqualTo("MsSpell"));
		Assert.That(checker.LocalizedName, Is.EqualTo("Microsoft Windows Spellchecker"));
		foreach (var o in checker.OptionIds!.Enum().Select(s => new Option(checker, s)))
			o.WriteValues();
	}

	[Test]
	public void CheckTest()
	{
		var err = checker!.Check("This text has no spelling errors.");
		Assert.That(err, Is.Not.Null);
		Assert.That(err.Enum().Any(), Is.False);
		Marshal.ReleaseComObject(err!);

		err = checker.Check("This txt has some speling errorz.");
		Assert.That(err, Is.Not.Null);
		Assert.That(err.Enum().Any(), Is.True);
		Marshal.ReleaseComObject(err!);
	}

	[Test]
	public void ComprehensiveCheckTest()
	{
		const string txt = "This teckt has some speling errorz.";
		var err = checker!.ComprehensiveCheck(txt);
		Assert.That(err, Is.Not.Null);
		foreach (var errDetail in err.Enum())
		{
			Assert.That(errDetail, Is.Not.Null);
			var sub = txt.Substring((int)errDetail!.StartIndex, (int)errDetail.Length);
			TestContext.WriteLine($"Error:\n  Action: {errDetail.CorrectiveAction}, Sub: {sub} Repl: {errDetail.Replacement ?? "null"}");
			if (errDetail.CorrectiveAction == CORRECTIVE_ACTION.CORRECTIVE_ACTION_GET_SUGGESTIONS)
			{
				var ienum = checker.Suggest(sub);
				Assert.That(ienum, Is.Not.Null);
				TestContext.WriteLine("  Sugg: " + string.Join(',', ienum!.Enum()));
			}
			Marshal.ReleaseComObject(errDetail);
		}
		Marshal.ReleaseComObject(err!);
	}

	[Test]
	public void ErrorTest()
	{
		const string txt = "This teckt has some speling errorz.";
		var err = checker!.Check(txt);
		Assert.That(err, Is.Not.Null);
		foreach (var errDetail in err.Enum())
		{
			Assert.That(errDetail, Is.Not.Null);
			var sub = txt.Substring((int)errDetail!.StartIndex, (int)errDetail.Length);
			TestContext.WriteLine($"Error:\n  Action: {errDetail.CorrectiveAction}, Sub: {sub} Repl: {errDetail.Replacement ?? "null"}");
			if (errDetail.CorrectiveAction == CORRECTIVE_ACTION.CORRECTIVE_ACTION_GET_SUGGESTIONS)
			{
				var ienum = checker.Suggest(sub);
				Assert.That(ienum, Is.Not.Null);
				TestContext.WriteLine("  Sugg: " + string.Join(',', ienum!.Enum()));
			}
			Marshal.ReleaseComObject(errDetail);
		}
		Marshal.ReleaseComObject(err!);
	}

	[Test, Apartment(System.Threading.ApartmentState.MTA)]
	public void EventTest()
	{
		Event evt = new(TestContext.Out);
		uint cookie = 0;
		Assert.That(() => checker!.add_SpellCheckerChanged(evt, out cookie), Throws.Nothing);
		try
		{
			Assert.That(() => checker!.Ignore("Bodidly"), Throws.Nothing);
			System.Threading.Thread.Sleep(1000);
			Assert.That(evt.GotEvent, Is.True);
		}
		finally
		{
			Assert.That(() => checker!.remove_SpellCheckerChanged(cookie), Throws.Nothing);
		}
	}

	[Test]
	public void GetLangsTest()
	{
		var ienum = factory!.SupportedLanguages;
		Assert.That(ienum, Is.Not.Null);
		foreach (var s in ienum!.Enum())
			TestContext.WriteLine(s);
		Marshal.ReleaseComObject(ienum!);
	}

	[Test]
	public void IgnoreRemoveTest()
	{
		const string misp = "merkamuck";
		const string txt = $"I love {misp} in the morning.";

		var checker2 = (ISpellChecker2)checker!;
		Assert.That(() => checker2.Remove(misp), Throws.Nothing);
		Assert.That(() => checker2.Ignore(misp), Throws.Nothing);
		Assert.That(CheckGoodSpelling(txt), Is.True, "ignore");
		Assert.That(() => checker2.Remove(misp), Throws.Nothing);
		Assert.That(CheckGoodSpelling(txt), Is.False, "removeign");
	}

	private bool CheckGoodSpelling(string txt)
	{
		var err = checker!.Check(txt);
		var good = !err.Enum().Any();
		Marshal.ReleaseComObject(err!);
		return good;
	}
}

internal class Event(System.IO.TextWriter writer) : ISpellCheckerChangedEventHandler
{
	public bool GotEvent { get; private set; } = false;

	public HRESULT Invoke(ISpellChecker? sender)
	{
		writer.WriteLine($"Sender: {sender?.Id ?? "null"} changed.");
		GotEvent = true;
		return HRESULT.S_OK;
	}
}

internal class Option
{
	public string? Heading, Description;
	public string Id;
	public string[] Labels;
	public byte Value;

	public Option(ISpellChecker chk, string id)
	{
		Id = id;
		Value = chk.GetOptionValue(id);
		var od = chk.GetOptionDescription(id);
		Heading = od?.Heading;
		Description = od?.Description;
		Labels = od?.Labels?.Enum().ToArray() ?? [];
	}
}

internal static class Ex
{
	public static IEnumerable<ISpellingError> Enum(this IEnumSpellingError? err)
	{
		if (err is null)
			yield break;
		while (err.Next(out ISpellingError? errDetail) == HRESULT.S_OK)
			yield return errDetail!;
	}
}