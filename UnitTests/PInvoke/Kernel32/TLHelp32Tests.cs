using NUnit.Framework;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class TLHelp32Tests
	{
		[Test]
		public void TestMethod()
		{
			using (var hsnap = CreateToolhelp32Snapshot(TH32CS.TH32CS_SNAPPROCESS, 0))
			{
				if (hsnap.IsInvalid) Assert.Fail(Win32Error.GetLastError().ToString());
				var pe = new PROCESSENTRY32 { dwSize = (uint)Marshal.SizeOf(typeof(PROCESSENTRY32)) };
				if (!Process32First(hsnap, ref pe)) Assert.Fail(Win32Error.GetLastError().ToString());
				do
				{
					TestContext.WriteLine("=======================================");
					TestContext.WriteLine($"PROCESS NAME: {pe.szExeFile}");
					TestContext.WriteLine("---------------------------------------");

					CREATE_PROCESS pClass = 0;
					using (var hproc = OpenProcess((uint)ProcessAccess.PROCESS_ALL_ACCESS, false, pe.th32ProcessID))
					{
						if (!hproc.IsInvalid)
							pClass = GetPriorityClass(hproc);
					}

					TestContext.WriteLine($"Process ID:        {pe.th32ProcessID}");
					TestContext.WriteLine($"Thread count:      {pe.cntThreads}");
					TestContext.WriteLine($"Parent process ID: {pe.th32ParentProcessID}");
					TestContext.WriteLine($"Priority base:     {pe.pcPriClassBase}");
					TestContext.WriteLine($"Priority class:    {pClass}");
					TestContext.WriteLine();

				} while (Process32Next(hsnap, ref pe));
			}
		}
	}
}