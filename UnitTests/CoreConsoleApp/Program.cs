using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;
//using System.IO;
//using System.Threading;
//using Vanara.Windows.Shell;
//using static Vanara.PInvoke.Shell32;

namespace CoreConsoleApp
{
	class Program
	{
		static HFILE hStdin, hStdout;

		[STAThread]
		static void Main(string[] args)
		{
			//const string bitBucket = @"C:\$Recycle.Bin";
			//const string dir = @"C:\Users\dahal\Downloads";
			//const string fn = "Clash.for.Windows.Setup.0.10.1.exe";
			//Move(Path.Combine(dir, fn), bitBucket);
			//Thread.Sleep(500);
			//Move(Path.Combine(bitBucket, fn), dir);
			hStdin = GetStdHandle(StdHandleType.STD_INPUT_HANDLE);
			hStdout = GetStdHandle(StdHandleType.STD_OUTPUT_HANDLE);
			if (hStdin == HFILE.INVALID_HANDLE_VALUE || hStdout == HFILE.INVALID_HANDLE_VALUE)
				ShowErr("GetStdHandle");
			else
				ReadInputEvents();
		}

		[StructLayout(LayoutKind.Sequential)]
		struct Test
		{
			public EVENT_TYPE et;
			private readonly ushort pad;
			public COORD xy;
			public uint a, b, c, d;
		}

		// Adapted from https://docs.microsoft.com/en-us/windows/console/reading-input-buffer-events
		private static int ReadInputEvents()
		{
			if (!GetConsoleMode(hStdin, out CONSOLE_INPUT_MODE fdwSaveOldMode))
				return ShowErr("GetConsoleMode");
			Console.WriteLine($"Orig input mode: {fdwSaveOldMode}");

			try
			{
				if (!SetConsoleMode(hStdin, CONSOLE_INPUT_MODE.ENABLE_MOUSE_INPUT | CONSOLE_INPUT_MODE.ENABLE_EXTENDED_FLAGS))
					return ShowErr("SetConsoleMode");

				if (!GetNumberOfConsoleMouseButtons(out var mouseBtn))
					return ShowErr("GetNumberOfConsoleMouseButtons");

				if (!GetConsoleSelectionInfo(out var selInfo))
					return ShowErr("GetConsoleSelectionInfo");

				SetConsoleCursorInfo(hStdin, new CONSOLE_CURSOR_INFO { dwSize = 25 });

				while (true /*WaitForSingleObject(hStdin, 10000) == WAIT_STATUS.WAIT_OBJECT_0*/)
				{
					if (!GetNumberOfConsoleInputEvents(hStdin, out var evtNum))
						return ShowErr("GetNumberOfConsoleInputEvents");
					if (evtNum == 0)
						continue;

					var irInBuf = new INPUT_RECORD[evtNum];
					//PeekConsoleInput(hStdin, irInBuf, evtNum, out _);

					if (!ReadConsoleInput(hStdin, irInBuf, evtNum, out var cNumRead))
						return ShowErr("ReadConsoleInput");

					for (var i = 0; i < cNumRead; i++)
					{
						var ir = irInBuf[i];
						//Console.WriteLine($"Seeing event {ir.EventType}");
						switch (ir.EventType)
						{
							case EVENT_TYPE.KEY_EVENT:
								Console.WriteLine($"Key event: {(ir.Event.KeyEvent.bKeyDown ? "Pressed" : "Released")} Key: {ir.Event.KeyEvent.uChar} (0x{ir.Event.KeyEvent.wVirtualKeyCode:X})");
								if (ir.Event.KeyEvent.uChar == 'q')
									return 0;
								break;

							case EVENT_TYPE.MOUSE_EVENT:
								MouseEventProc(ir.Event.MouseEvent);
								break;

							case EVENT_TYPE.WINDOW_BUFFER_SIZE_EVENT:
								//Console.WriteLine($"Screen buffer is {ir.Event.WindowBufferSizeEvent.dwSize}");
								break;

							case EVENT_TYPE.MENU_EVENT:
								break;

							case EVENT_TYPE.FOCUS_EVENT:
								//Console.WriteLine($"Focus event: {(ir.Event.FocusEvent.bSetFocus ? "Got" : "Lost")}");
								break;

							default:
								return ShowErr("Unknown event type.");
						}
					}
				}
			}
			finally
			{
				SetConsoleMode(hStdin, fdwSaveOldMode);
			}

			static void MouseEventProc(in MOUSE_EVENT_RECORD mouseEvent)
			{
				Console.Write($"Mouse event: {mouseEvent.dwMousePosition} ");
				switch (mouseEvent.dwEventFlags)
				{
					case MOUSE_EVENT_FLAG.NONE:
						Console.WriteLine($"Btn press = {mouseEvent.dwButtonState}");
						break;

					case MOUSE_EVENT_FLAG.DOUBLE_CLICK:
						Console.WriteLine("Double click");
						break;

					case MOUSE_EVENT_FLAG.MOUSE_HWHEELED:
						Console.WriteLine("Horz mouse wheeled");
						break;

					case MOUSE_EVENT_FLAG.MOUSE_MOVED:
						Console.WriteLine("Mouse moved");
						break;

					case MOUSE_EVENT_FLAG.MOUSE_WHEELED:
						Console.WriteLine("Vert mouse wheeled");
						break;

					default:
						Console.WriteLine("Unknown");
						break;
				}
			}
		}

		private static int ShowErr(string msg, Win32Error? err = null)
		{
			if (!err.HasValue) err = Win32Error.GetLastError();
			ShowMsg(msg + "\r\n" + err.ToString());
			return unchecked((int)(uint)err);
		}

		private static void ShowMsg(string msg)
		{
			msg = "======================================================\r\n" + msg + "\r\n======================================================\r\n";
			var bmsg = Encoding.ASCII.GetBytes(msg);
			WriteFile(hStdout, bmsg, (uint)bmsg.Length, out _, default);

			var inBuf = new byte[2];
			ReadFile(hStdin, inBuf, (uint)inBuf.Length, out _, default);
		}

		//public static bool Move(string SourcePath, string DestinationPath, string NewName = null)
		//{
		//	try
		//	{
		//		using (ShellItem SourceItem = new ShellItem(SourcePath))
		//		using (ShellFolder DestItem = new ShellFolder(DestinationPath))
		//		{
		//			ShellFileOperations.Move(SourceItem, DestItem, NewName, ShellFileOperations.OperationFlags.AllowUndo | ShellFileOperations.OperationFlags.NoConfirmMkDir | ShellFileOperations.OperationFlags.Silent);
		//		}

		//		return true;
		//	}
		//	catch
		//	{
		//		return false;
		//	}
		//}
	}
}
