using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.WinMm;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class midiTests
{
	public HMIDIOUT hOut;

	[OneTimeSetUp]
	public void _Setup()
	{
		midiOutOpen(out hOut, 0);
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
		midiOutClose(hOut);
	}

	[StructLayout(LayoutKind.Sequential)]
	struct midiMsg
	{
		public uint dwData;

		public midiMsg(params byte[] a) => dwData = BitConverter.ToUInt32(a, 0);

		public static implicit operator uint(midiMsg m) => m.dwData;
	}

	[Test]
	public void TestPlayNote()
	{
		Assert.That(midiOutOpen(out var device, 0), Is.EqualTo(MMRESULT.MMSYSERR_NOERROR));
		bool playing = false;
		const byte velocity = 100;
		try
		{
			for (int i = 0; i < 6; i++)
			{
				var msg = new midiMsg(0x90, 60, playing ? velocity : (byte)0, 0);
				playing = !playing;
				Assert.That(midiOutShortMsg(device, msg), Is.EqualTo(MMRESULT.MMSYSERR_NOERROR));
				Thread.Sleep(200);
			}
		}
		finally
		{
			// turn any MIDI notes currently playing:
			midiOutReset(device);

			// Remove any data in MIDI device and close the MIDI Output port
			Assert.That(midiOutClose(device), Is.EqualTo(MMRESULT.MMSYSERR_NOERROR));
		}
	}

	[Test]
	public void midiOutGetDevCapsTest()
	{
		Assert.That(midiOutGetDevCaps(0, out var mCap, MIDIOUTCAPS.NativeSize), Is.EqualTo(MMRESULT.MMSYSERR_NOERROR));
		mCap.WriteValues();
	}

	[Test]
	public void midiOutGetIDTest()
	{
		Assert.That(midiOutGetID(hOut, out var devId), Is.EqualTo(MMRESULT.MMSYSERR_NOERROR));
		TestContext.Write(devId);
	}

	[Test]
	public void midiOutGetNumDevsTest()
	{
		uint c = 0;
		Assert.That(c = midiOutGetNumDevs(), Is.GreaterThanOrEqualTo(0));
		TestContext.Write(c);
	}

	[Test]
	public void midiOutGetSetVolumeTest()
	{
		Assert.That(midiOutGetVolume(hOut, out var vol), Is.EqualTo(MMRESULT.MMSYSERR_NOERROR));
		TestContext.Write(vol);
		var nVol = vol + 100;
		Assert.That(midiOutSetVolume(hOut, nVol), Is.EqualTo(MMRESULT.MMSYSERR_NOERROR));
		Assert.That(midiOutSetVolume(hOut, vol), Is.EqualTo(MMRESULT.MMSYSERR_NOERROR));
	}

	[Test]
	public void midiOutHeaderTest()
	{
		const uint bufLen = 32 * 1024;
		MIDIHDR mhdr = new() { dwBufferLength = bufLen, lpData = Marshal.AllocHGlobal((int)bufLen) };

		try
		{
			Assert.That(midiOutLongMsg(hOut, mhdr, MIDIHDR.NativeSize), Is.EqualTo(MMRESULT.MIDIERR_UNPREPARED));

			Assert.That(midiOutPrepareHeader(hOut, ref mhdr, MIDIHDR.NativeSize), Is.EqualTo(MMRESULT.MMSYSERR_NOERROR));
			mhdr.WriteValues();
			Assert.That(midiOutLongMsg(hOut, mhdr, MIDIHDR.NativeSize), Is.EqualTo(MMRESULT.MMSYSERR_NOERROR));
			Assert.That(midiOutUnprepareHeader(hOut, ref mhdr, MIDIHDR.NativeSize), Is.EqualTo(MMRESULT.MMSYSERR_NOERROR));
		}
		finally
		{
			Marshal.FreeHGlobal(mhdr.lpData);
		}
	}
}