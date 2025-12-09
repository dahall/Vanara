using NUnit.Framework;
using System.Linq;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Tdh;

namespace Security.Tdh;

[TestFixture()]
public class TdhTests
{
	[Test]
	public void DisplayAllProviders()
	{
		var list = GetProviders().ToList();
		list.Sort((x, y) => string.Compare(x.ProviderName, y.ProviderName));

		foreach (var (id, source, name) in list.Select(p => (p.ProviderGuid, p.SchemaSource, p.ProviderName)))
		{
			TestContext.WriteLine($"{new string('=', 30)}\n{name} ({id})\n");

			StringBuilder tmp = new();
			foreach (EVENT_FIELD_TYPE fType in Enum.GetValues(typeof(EVENT_FIELD_TYPE)))
			{
				if (TdhEnumerateProviderFieldInformation(id, fType, out var pfia).Succeeded)
					foreach (var f in pfia.Value.FieldInfoArray)
						tmp.AppendLine($"    {fType}: {f.Value}, {PFI_FIELD_NAME(pfia, f)}, {PFI_FIELD_MESSAGE(pfia, f)}");
			}
			if (tmp.Length > 0) TestContext.WriteLine($"  Fields:\n{tmp}");

			tmp.Clear();
			if (TdhEnumerateManifestProviderEvents(id, out var pei).Succeeded)
				foreach (var e in pei.EventDescriptorsArray)
				{
					tmp.AppendLine($"    Id: {e.Id}, Ver: {e.Version}, Chnl: {e.Channel}, Lvl: {e.Level}, Opcode: {e.Opcode}, Task: {e.Task}, Key: 0x{e.Keyword:X}");
					Win32Error.ThrowIfFailed(TdhGetManifestEventInformation(id, e, out SafeCoTaskMemStruct<TRACE_EVENT_INFO> tei));
					if (tei.Value.EventNameOffset > 0) tmp.AppendLine($"      EventName: {TEI_EVENT_NAME(tei)}");
					if (tei.Value.KeywordsNameOffset > 0) tmp.AppendLine($"      Keywords: {TEI_KEYWORDS_NAME(tei)}");
					if (tei.Value.TaskNameOffset > 0) tmp.AppendLine($"      Task: {TEI_TASK_NAME(tei)}");
					if (tei.Value.ChannelNameOffset > 0) tmp.AppendLine($"      Channel: {TEI_CHANNEL_NAME(tei)}");
					if (tei.Value.LevelNameOffset > 0) tmp.AppendLine($"      Level: {TEI_LEVEL_NAME(tei)}");
					if (tei.Value.OpcodeNameOffset > 0) tmp.AppendLine($"      Opcode: {TEI_OPCODE_NAME(tei)}");
					if (tei.Value.ProviderMessageOffset > 0) tmp.AppendLine($"      ProvMsg: {TEI_PROVIDER_MESSAGE(tei)}");
					if (tei.Value.EventMessageOffset > 0) tmp.AppendLine($"      EventMsg: {TEI_EVENT_MESSAGE(tei)}");
					tmp.AppendLine($"      Properties ({tei.Value.PropertyCount}):");
					foreach (EVENT_PROPERTY_INFO p in tei.Value.EventPropertyInfoArray)
					{
						tmp.AppendLine($"        Name: {TEI_PROPERTY_NAME(tei, p)} ({p.Flags}):");
						if (!p.Flags.IsFlagSet(PROPERTY_FLAGS.PropertyStruct))
						{
							tmp.AppendLine($"          In: {p.nonStructType.InType.ToString().Replace("TDH_INTYPE_", "")}, Out: {p.nonStructType.OutType.ToString().Replace("TDH_OUTTYPE_", "")}, Map: {TEI_MAP_NAME(tei, p)}");
						}
					}
					tmp.AppendLine();
				}
			if (tmp.Length > 0) TestContext.WriteLine($"  Events:\n{tmp}");

			tmp.Clear();
			if (TdhEnumerateProviderFilters(id, null, out SafeNativeArray<PROVIDER_FILTER_INFO> pfi).Succeeded)
				for (int i = 0; i < pfi.Count; i++)
				{
					PROVIDER_FILTER_INFO l = pfi[i];
					tmp.AppendLine($"    Id: {l.Id}, Ver: {l.Version}, Msg: {PFI_FILTER_MESSAGE(pfi, i)}");
					for (int j = 0; j < l.PropertyCount; j++)
						tmp.AppendLine($"      PropName: {PFI_PROPERTY_NAME(pfi, l.EventPropertyInfoArray[j])} ({l.EventPropertyInfoArray[j].Flags})");
				}
			if (tmp.Length > 0) TestContext.WriteLine($"  Filters:\n{tmp}");
		}
	}

	[Test]
	public void TdhOpenDecodingHandleTest()
	{
		Assert.That(TdhOpenDecodingHandle(out var h), ResultIs.Successful);
		try
		{
			//Guid id = new("e5c16d49-2464-4382-bb20-97a4b5465db9");
			//uint eventid = 404; // Id: 404, Ver: 0, Chnl: 0, Lvl: 4, Opcode: 0, Task: 0, Key: 0x0
		}
		finally
		{
			TdhCloseDecodingHandle(h);
		}
	}

	[Test]
	public void TdhEnumerateManifestProviderEventsTest()
	{
		Assert.That(TdhEnumerateManifestProviderEvents(GetProviders().First(p => p.ProviderName == "Application Error").ProviderGuid, out PROVIDER_EVENT_INFO peInfo), ResultIs.Successful);
		Assert.That(peInfo, Is.Not.Null);
		uint cnt = peInfo.NumberOfEvents;
		Assert.That(cnt, Is.Not.Zero);
		EVENT_DESCRIPTOR[] a = peInfo.EventDescriptorsArray;
		a[0].WriteValues();
		a[cnt - 1].WriteValues();
	}

	[Test]
	public void TdhEnumerateProviderFieldInformationTest()
	{
		Assert.That(TdhEnumerateProviderFieldInformation(GetProviders().First().ProviderGuid, EVENT_FIELD_TYPE.EventLevelInformation, out SafeCoTaskMemStruct<PROVIDER_FIELD_INFOARRAY> peInfo), ResultIs.Successful);
		Assert.That(peInfo, Is.Not.Null);
		uint cnt = peInfo.Value.NumberOfElements;
		Assert.That(cnt, Is.Not.Zero);
		PROVIDER_FIELD_INFO f = peInfo.Value.FieldInfoArray[cnt - 1];
		Assert.That(PFI_FIELD_MESSAGE(peInfo, f), Is.Not.Null);
		TestContext.WriteLine($"{f.Value}, {PFI_FIELD_NAME(peInfo, f)}, {PFI_FIELD_MESSAGE(peInfo, f)}");
	}

	[Test]
	public void TdhEnumerateProviderFiltersTest()
	{
		Assert.That(TdhEnumerateProviderFilters(GetProviders().First(p => p.ProviderName == "Application Error").ProviderGuid, null, out var pfInfo), ResultIs.Successful);
		pfInfo.WriteValues();
	}

	[Test]
	public void TdhEnumerateProvidersForDecodingSourceTest()
	{
		Assert.That(TdhEnumerateProvidersForDecodingSource(DECODING_SOURCE.DecodingSourceXMLFile, out SafeCoTaskMemStruct<PROVIDER_ENUMERATION_INFO> peInfo), ResultIs.Successful);
		Assert.That(peInfo, Is.Not.Null);
		uint cnt = peInfo.Value.NumberOfProviders;
		Assert.That(cnt, Is.Not.Zero);
		TRACE_PROVIDER_INFO[] a = peInfo.Value.TraceProviderInfoArray;
		Assert.That(PEI_PROVIDER_NAME(peInfo, a[0]), Is.Not.Null);
		Assert.That(PEI_PROVIDER_NAME(peInfo, a[cnt - 1]), Is.Not.Null);
		Write(peInfo, a[cnt - 1]);
	}

	[Test]
	public void TdhEnumerateProvidersTest()
	{
		Assert.That(TdhEnumerateProviders(out SafeCoTaskMemStruct<PROVIDER_ENUMERATION_INFO> peInfo), ResultIs.Successful);
		Assert.That(peInfo, Is.Not.Null);
		uint cnt = peInfo.Value.NumberOfProviders;
		Assert.That(cnt, Is.Not.Zero);
		TRACE_PROVIDER_INFO[] a = peInfo.Value.TraceProviderInfoArray;
		Assert.That(PEI_PROVIDER_NAME(peInfo, a[0]), Is.Not.Null);
		Assert.That(PEI_PROVIDER_NAME(peInfo, a[cnt - 1]), Is.Not.Null);
		Write(peInfo, a[cnt - 1]);
	}

	private static void Write(SafeCoTaskMemStruct<PROVIDER_ENUMERATION_INFO> peInfo, in TRACE_PROVIDER_INFO i) =>
		TestContext.WriteLine($"{PEI_PROVIDER_NAME(peInfo, i)}, {i.ProviderGuid}, {i.SchemaSource}");

	private static TRACE_PROVIDER_INFO_EX[] GetProviders() { Win32Error.ThrowIfFailed(TdhEnumerateProviders(out SafeCoTaskMemStruct<PROVIDER_ENUMERATION_INFO> peInfo)); return Array.ConvertAll(peInfo.Value.TraceProviderInfoArray, i => new TRACE_PROVIDER_INFO_EX(i, PEI_PROVIDER_NAME(peInfo, i))); }

	private struct TRACE_PROVIDER_INFO_EX(TRACE_PROVIDER_INFO i, string? n)
	{
		public Guid ProviderGuid = i.ProviderGuid;
		public uint SchemaSource = i.SchemaSource;
		public string ProviderName = n ?? i.ProviderGuid.ToString("D");
	}
}