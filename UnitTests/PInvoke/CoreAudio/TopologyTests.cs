using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.CoreAudio;

namespace Vanara.PInvoke.Tests;

public partial class CoreAudioTopoTests : GenericComTester<IPart>
{
	private List<IMMDevice> Devices { get; set; } = new();
	private HashSet<IPart> Parts { get; set; } = new(new PartComparer());

	protected override IPart InitInstance()
	{
		var enumerator = Push(new IMMDeviceEnumerator());
		var coll = Push(enumerator.EnumAudioEndpoints(EDataFlow.eRender, DEVICE_STATE.DEVICE_STATE_ACTIVE) ?? throw new Exception());
		for (var i = 0U; i < coll.GetCount(); i++)
			if (coll.Item(i, out var d).Succeeded)
				Devices.Add(Push(d!));
		foreach (var dev in Devices)
		{
			using var topo = ComReleaserFactory.Create(dev.Activate<IDeviceTopology>() ?? throw new Exception());
			for (var i = 0U; i < topo.Item.GetConnectorCount(); i++)
				Parts.Add((IPart)Push(topo.Item.GetConnector(i)!));
		}
		return Parts.FirstOrDefault() ?? throw new Exception();

		T Push<T>(T val) where T : class { objects.Push(val); return val; }
	}

	IEnumerable<T> GetPartActivations<T>() where T: class
	{
		foreach (var part in Parts!)
		{
			T? ret;
			try { ret = part.Activate<T>(); }
			catch { continue; }
			yield return ret!;
		}
	}

	class PartComparer : EqualityComparer<IPart>
	{
		public override bool Equals(IPart? a, IPart? b) => a is not null && b is not null && string.Equals(a.GetGlobalId(), b.GetGlobalId());
		public override int GetHashCode(IPart obj) => ((string?)obj.GetGlobalId())?.GetHashCode() ?? 0;
	}

	[Test]
	public void IAudioAutoGainControlTest()
	{
		bool enabled = false;
		var gain = GetPartActivations<IAudioAutoGainControl>().FirstOrDefault();
		if (gain is null) return;
		Assert.That(() => enabled = gain.GetEnabled(), Throws.Nothing);
		Assert.That(() => gain.SetEnabled(!enabled), Throws.Nothing);
		Assert.That(gain.GetEnabled(), Is.EqualTo(!enabled));
		Assert.That(() => gain.SetEnabled(enabled), Throws.Nothing);
	}

	[Test]
	public void IAudioBassTest()
	{
		var bass = GetPartActivations<IAudioBass>().FirstOrDefault();
		if (bass is null) return;
		Assert.That(bass.GetChannelCount(), Is.Not.Zero);
	}
}