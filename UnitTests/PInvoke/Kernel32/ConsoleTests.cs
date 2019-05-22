using NUnit.Framework;
using System;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class ConsoleTests
	{
		[Test]
		public void TestMethod()
		{
			// Taken from https://docs.microsoft.com/en-us/windows/console/reading-input-buffer-events
			var hStdin = GetStdHandle(StdHandleType.STD_INPUT_HANDLE);
			if (hStdin.IsInvalid) Win32Error.ThrowLastError();

			if (!GetConsoleMode(hStdin, out CONSOLE_INPUT_MODE fewSaveOldMode))
				Win32Error.ThrowLastError();

			try
			{
				if (!SetConsoleMode(hStdin, CONSOLE_INPUT_MODE.ENABLE_WINDOW_INPUT | CONSOLE_INPUT_MODE.ENABLE_MOUSE_INPUT))
					Win32Error.ThrowLastError();

				var counter = 0;
				const int recCnt = 128;
				while (counter++ <= 100)
				{
					var irInBuf = new INPUT_RECORD[recCnt];
					if (!ReadConsoleInput(hStdin, irInBuf, recCnt, out var cNumRead))
						Win32Error.ThrowLastError();

					for (var i = 0; i < cNumRead; i++)
					{
						switch (irInBuf[i].EventType)
						{
							case EVENT_TYPE.KEY_EVENT:
								TestContext.WriteLine($"Key event: {(irInBuf[i].Event.KeyEvent.bKeyDown ? "Pressed" : "Released")}");
								break;
							case EVENT_TYPE.MOUSE_EVENT:
								MouseEventProc(irInBuf[i].Event.MouseEvent);
								break;
							case EVENT_TYPE.WINDOW_BUFFER_SIZE_EVENT:
								TestContext.WriteLine($"Screen buffer is {irInBuf[i].Event.WindowBufferSizeEvent.dwSize.X} x {irInBuf[i].Event.WindowBufferSizeEvent.dwSize.Y}");
								break;
							case EVENT_TYPE.MENU_EVENT:
							case EVENT_TYPE.FOCUS_EVENT:
								break;
							default:
								throw new InvalidOperationException("Unknown event type.");
						}
					}
				}
			}
			finally
			{
				SetConsoleMode(hStdin, fewSaveOldMode);
			}

			void MouseEventProc(MOUSE_EVENT_RECORD mouseEvent)
			{
				TestContext.Write("Mouse event: ");
				switch (mouseEvent.dwEventFlags)
				{
					case MOUSE_EVENT_FLAG.NONE:
						if (mouseEvent.dwButtonState == MOUSE_BUTTON_STATE.FROM_LEFT_1ST_BUTTON_PRESSED)
							TestContext.WriteLine("Left btn press");
						else if (mouseEvent.dwButtonState == MOUSE_BUTTON_STATE.RIGHTMOST_BUTTON_PRESSED)
							TestContext.WriteLine("Right btn press");
						else
							TestContext.WriteLine("Btn press");
						break;
					case MOUSE_EVENT_FLAG.DOUBLE_CLICK:
						TestContext.WriteLine("Double click");
						break;
					case MOUSE_EVENT_FLAG.MOUSE_HWHEELED:
						TestContext.WriteLine("Horz mouse wheeled");
						break;
					case MOUSE_EVENT_FLAG.MOUSE_MOVED:
						TestContext.WriteLine("Mouse moved");
						break;
					case MOUSE_EVENT_FLAG.MOUSE_WHEELED:
						TestContext.WriteLine("Vert mouse wheeled");
						break;
					default:
						TestContext.WriteLine("Unknown");
						break;
				}
			}
		}
	}
}