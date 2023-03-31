using NUnit.Framework;
using System;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class EvntProvTests
{
	[Test]
	public void EventTest()
	{
		var activId = Guid.Empty;
		Assert.That(EventActivityIdControl(EVENT_ACTIVITY_CTRL.EVENT_ACTIVITY_CTRL_CREATE_ID, ref activId), ResultIs.Successful);

		var provGuid = Guid.NewGuid();
		Assert.That(EventRegister(provGuid, Callback, IntPtr.Zero, out var hReg), ResultIs.Successful);
		Assert.That(hReg.IsInvalid, Is.False);

		using (hReg)
		{
			var desc = new EVENT_DESCRIPTOR(0, 0, 0, 0, 0, 0, ulong.MaxValue);
			Assert.That(EventEnabled(hReg, desc), Is.False);

			Assert.That(EventProviderEnabled(hReg, 0, ulong.MaxValue), Is.False);

			using (var mem = SafeHGlobalHandle.CreateFromStructure((byte)1))
				Assert.That(EventSetInformation(hReg, EVENT_INFO_CLASS.EventProviderUseDescriptorType, mem, 1U), ResultIs.FailureCode(Win32Error.ERROR_NOT_SUPPORTED));

			Assert.That(EventWrite(hReg, desc, 0, null), ResultIs.FailureCode(Win32Error.ERROR_INVALID_PARAMETER));
			Assert.That(EventWriteEx(hReg, desc, 0, 0, IntPtr.Zero, IntPtr.Zero, 0, null), ResultIs.FailureCode(Win32Error.ERROR_INVALID_PARAMETER));
			Assert.That(EventWriteString(hReg, 0, ulong.MaxValue, "Dummy"), ResultIs.FailureCode(Win32Error.ERROR_INVALID_HANDLE));
			Assert.That(EventWriteTransfer(hReg, desc, IntPtr.Zero, IntPtr.Zero, 0, null), ResultIs.FailureCode(Win32Error.ERROR_INVALID_PARAMETER));
		}

		static void Callback(in Guid SourceId, bool IsEnabled, byte Level, ulong MatchAnyKeyword, ulong MatchAllKeyword, in EVENT_FILTER_DESCRIPTOR FilterData, IntPtr CallbackContext)
		{
		}
	}
}