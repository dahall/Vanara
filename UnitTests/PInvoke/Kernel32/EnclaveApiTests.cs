using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class EnclaveApiTests
{
	[Test]
	public void EnclaveTest()
	{
		if (IsEnclaveTypeSupported(EnclaveType.ENCLAVE_TYPE_SGX))
		{
			ENCLAVE_CREATE_INFO_VBS vbs = new() { Flags = ENCLAVE_VBS_FLAG.ENCLAVE_VBS_FLAG_DEBUG, OwnerID = Encoding.Unicode.GetBytes("0123456789ABCDEF") };
			using SafeEnclaveHandle h = CreateEnclave(GetCurrentProcess(), IntPtr.Zero, 1024, 1024, EnclaveType.ENCLAVE_TYPE_VBS, vbs, (uint)Marshal.SizeOf(typeof(ENCLAVE_CREATE_INFO_VBS)), out _);
		}
		else
			throw new NotSupportedException();
	}
}