using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class EnclaveApiTests
{
	[Test]
	public void EnclaveTest()
	{
		Assert.That(IsEnclaveTypeSupported(EnclaveType.ENCLAVE_TYPE_VBS));
		ENCLAVE_CREATE_INFO_VBS vbs = new(ENCLAVE_VBS_FLAG.ENCLAVE_VBS_FLAG_DEBUG, [0x10, 0x20, 0x30, 0x40, 0x41, 0x31, 0x21, 0x11]);
		using var h = CreateEnclave(GetCurrentProcess(), IntPtr.Zero, 0x10000000, 0, EnclaveType.ENCLAVE_TYPE_VBS, vbs, (uint)Marshal.SizeOf(typeof(ENCLAVE_CREATE_INFO_VBS)), out _);
		Assert.That(h, ResultIs.ValidHandle);
	}
}