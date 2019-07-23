using NUnit.Framework;
using System.Threading;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public partial class WinBaseTests
	{
		private static readonly string pcCommPort = $"COM{GetCommPorts()[0]}";

		public static SafeHFILE ComPort => CreateFile(pcCommPort, FileAccess.GENERIC_READ | FileAccess.GENERIC_WRITE, 0, null, System.IO.FileMode.Open, 0);

		[Test]
		public void BuildCommDCBAndTimeoutsTest()
		{
			Assert.That(BuildCommDCBAndTimeouts("baud=57600 parity=N data=8 stop=1 to=on", out var dcb, out var tout), ResultIs.Successful);
			Assert.That(dcb.BaudRate, Is.EqualTo(57600));
			dcb.WriteValues();
			Assert.That(tout.WriteTotalTimeoutConstant, Is.EqualTo(60000));
			tout.WriteValues();
		}

		[Test]
		public void BuildCommDCBTest()
		{
			Assert.That(BuildCommDCB("baud=57600 parity=N data=8 stop=1", out var dcb), ResultIs.Successful);
			Assert.That(dcb.BaudRate, Is.EqualTo(57600));
			dcb.WriteValues();
		}

		[Test]
		public void ClearCommBreakTest()
		{
			using (var hCom = ComPort)
				Assert.That(ClearCommBreak(hCom), ResultIs.Successful);
		}

		[Test]
		public void ClearCommErrorTest()
		{
			using (var hCom = ComPort)
				Assert.That(ClearCommError(hCom, out var errs, out var stat), ResultIs.Successful);
		}

		[Test]
		public void CommConfigDialogTest()
		{
			var cc = COMMCONFIG.Default;
			cc.dwProviderSubType = PROV_SUB_TYPE.PST_UNSPECIFIED;
			Assert.That(CommConfigDialog(pcCommPort, HWND.NULL, ref cc), ResultIs.Successful);
		}

		[Test]
		public void EscapeCommFunctionTest()
		{
			using (var hCom = ComPort)
				Assert.That(EscapeCommFunction(hCom, COMM_ESC_FUNC.CLRBREAK), ResultIs.Successful);
		}

		[Test]
		public void GetCommModemStatusTest()
		{
			using (var hCom = ComPort)
			{
				Assert.That(GetCommModemStatus(hCom, out var st), ResultIs.Successful);
				st.WriteValues();
			}
		}

		[Test]
		public void GetCommPortsTest()
		{
			Assert.That(() =>
			{
				var p = GetCommPorts();
				p.WriteValues();
			}, Throws.Nothing);
		}

		[Test]
		public void GetCommPropertiesTest()
		{
			using (var hCom = ComPort)
			{
				Assert.That(GetCommProperties(hCom, out var prop), ResultIs.Successful);
				prop.WriteValues();
			}
		}

		[Test]
		public void GetSetCommConfigTest()
		{
			using (var hCom = ComPort)
			{
				using (var mem = new SafeHGlobalHandle(2048))
				{
					var sz = (uint)mem.Size;
					Assert.That(GetCommConfig(hCom, mem, ref sz), ResultIs.Successful);
					var cc = mem.ToStructure<COMMCONFIG>();
					cc.WriteValues();
					Assert.That(SetCommConfig(hCom, mem, (uint)mem.Size), ResultIs.Successful);
				}
			}
		}

		[Test]
		public void GetSetCommMaskTest()
		{
			using (var hCom = ComPort)
			{
				Assert.That(GetCommMask(hCom, out var mask), ResultIs.Successful);
				Assert.That(SetCommMask(hCom, mask), ResultIs.Successful);
			}
		}

		[Test]
		public void GetSetCommStateTest()
		{
			// Open a handle to the specified com port.
			using (var hCom = ComPort)
			{
				Assert.That(hCom, ResultIs.ValidHandle);

				// Build on the current configuration by first retrieving all current settings.
				Assert.That(GetCommState(hCom, out var dcb), ResultIs.Successful);

				PrintCommState(dcb);       //  Output to console

				// Fill in some DCB values and set the com state: 57,600 bps, 8 data bits, no parity, and 1 stop bit.
				dcb.BaudRate = CBR_57600;     //  baud rate
				dcb.ByteSize = 8;             //  data size, xmit and rcv
				dcb.Parity = Parity.NOPARITY;      //  parity bit
				dcb.StopBits = StopBits.ONESTOPBIT;    //  stop bit

				Assert.That(SetCommState(hCom, dcb), ResultIs.Successful);

				// Get the comm config again.
				Assert.That(GetCommState(hCom, out dcb), ResultIs.Successful);

				PrintCommState(dcb);       //  Output to console
			}

			void PrintCommState(in DCB dcb)
			{
				// Print some of the DCB structure values
				TestContext.WriteLine($"nBaudRate = {dcb.BaudRate}, ByteSize = {dcb.ByteSize}, Parity = {dcb.Parity}, StopBits = {dcb.StopBits}");
			}
		}

		[Test]
		public void GetSetCommTimeoutsTest()
		{
			using (var hCom = ComPort)
			{
				Assert.That(GetCommTimeouts(hCom, out var ct), ResultIs.Successful);
				ct.WriteValues();
				Assert.That(SetCommTimeouts(hCom, ct), ResultIs.Successful);
			}
		}

		[Test]
		public void GetSetDefaultCommConfigTest()
		{
			using (var mem = new SafeHGlobalHandle(2048))
			{
				var sz = (uint)mem.Size;
				Assert.That(GetDefaultCommConfig(pcCommPort, mem, ref sz), ResultIs.Successful);
				var cc = mem.ToStructure<COMMCONFIG>();
				cc.WriteValues();
				Assert.That(SetDefaultCommConfig(pcCommPort, mem, (uint)mem.Size), ResultIs.Successful);
			}
		}

		[Test]
		public void OpenCommPortTest()
		{
			Assert.That(OpenCommPort(3, FileAccess.GENERIC_READ | FileAccess.GENERIC_WRITE, 0), ResultIs.ValidHandle);
		}

		[Test]
		public void PurgeCommTest()
		{
			using (var hCom = ComPort)
				Assert.That(PurgeComm(hCom, COMM_PURGE.PURGE_RXCLEAR), ResultIs.Successful);
		}

		[Test]
		public void SetCommBreakTest()
		{
			using (var hCom = ComPort)
				Assert.That(SetCommBreak(hCom), ResultIs.Successful);
		}

		[Test]
		public void SetupCommTest()
		{
			using (var hCom = ComPort)
				Assert.That(SetupComm(hCom, 4096, 4096), ResultIs.Successful);
		}

		[Test]
		public void TransmitCommCharTest()
		{
			using (var hCom = ComPort)
				Assert.That(TransmitCommChar(hCom, 65), ResultIs.Successful);
		}

		[Test]
		public unsafe void WaitCommEventTest()
		{
			// Open a handle to the specified com port.
			using (var hCom = ComPort)
			using (var hEvent = CreateEvent(null, true, false, null))
			{
				Assert.That(hCom, ResultIs.ValidHandle);
				Assert.That(hEvent, ResultIs.ValidHandle);

				Assert.That(SetCommMask(hCom, COMM_EVT_MASK.EV_CTS | COMM_EVT_MASK.EV_DSR), ResultIs.Successful);

				// Create an event object for use by WaitCommEvent.
				var o = new NativeOverlapped { EventHandle = hEvent.DangerousGetHandle() };

				//if (WaitCommEvent(hCom, out var dwEvtMask, &o))
				//{
				//	TestContext.WriteLine(dwEvtMask);
				//}
				//else
				//{
				//	TestContext.WriteLine($"Err: {Win32Error.GetLastError()}");
				//}
			}
		}
	}
}