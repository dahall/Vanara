using Microsoft.Win32;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.CoreAudio;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;
using static Vanara.PInvoke.WinMm;

namespace Vanara.PInvoke.Tests
{
	public partial class CoreAudioTopoTests : GenericComTester<IPart>
	{
		private List<IMMDevice> Devices { get; set; }
		private HashSet<IPart> Parts { get; set; }

		protected override IPart InitInstance()
		{
			var enumerator = Push(new IMMDeviceEnumerator());
			var coll = Push(enumerator.EnumAudioEndpoints(EDataFlow.eRender, DEVICE_STATE.DEVICE_STATE_ACTIVE));
			Devices = new List<IMMDevice>();
			for (var i = 0U; i < coll.GetCount(); i++)
				if (coll.Item(i, out var d).Succeeded)
					Devices.Add(Push(d));
			Parts = new HashSet<IPart>(new PartComparer());
			foreach (var dev in Devices)
			{
				using var topo = ComReleaserFactory.Create(dev.Activate<IDeviceTopology>());
				for (var i = 0U; i < topo.Item.GetConnectorCount(); i++)
					Parts.Add((IPart)Push(topo.Item.GetConnector(i)));
			}
			return Parts.FirstOrDefault();

			T Push<T>(T val) where T : class { objects.Push(val); return val; }
		}

		IEnumerable<T> GetPartActivations<T>() where T: class
		{
			foreach (var part in Parts)
			{
				T ret;
				try { ret = part.Activate<T>(); }
				catch { continue; }
				yield return ret;
			}
		}

		class PartComparer : EqualityComparer<IPart>
		{
			public override bool Equals(IPart a, IPart b) => a is null || b is null ? false : string.Equals(a.GetGlobalId(), b.GetGlobalId());
			public override int GetHashCode(IPart obj) => ((string)obj?.GetGlobalId())?.GetHashCode() ?? 0;
		}

		[Test]
		public void IAudioAutoGainControlTest()
		{
			bool enabled = false;
			using var gain = ComReleaserFactory.Create(GetPartActivations<IAudioAutoGainControl>().First());
			Assert.That(() => enabled = gain.Item.GetEnabled(), Throws.Nothing);
			Assert.That(() => gain.Item.SetEnabled(!enabled), Throws.Nothing);
			Assert.That(gain.Item.GetEnabled(), Is.EqualTo(!enabled));
			Assert.That(() => gain.Item.SetEnabled(enabled), Throws.Nothing);
		}

		[Test]
		public void IAudioBassTest()
		{
			using var bass = ComReleaserFactory.Create(GetPartActivations<IAudioBass>().First());
			Assert.That(bass.Item.GetChannelCount(), Is.Not.Zero);
		}
	}
}