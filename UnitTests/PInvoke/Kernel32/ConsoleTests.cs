using NUnit.Framework;
using System.Diagnostics;
using System.Reflection;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class ConsoleTests
{
	[Test]
	public void ConsoleTest()
	{
		Process p = CSharpRunner.RunProcess(typeof(ConsoleTestProcess), null, "MyMain");
		p.WaitForExit();
		Assert.That(p.ExitCode, Is.Zero);
	}
}

public static class ConsoleTestProcess
{
	public static HFILE hStdin, hStdout;

	public static int MyMain()
	{
		// Get handles to STDIN and STDOUT.
		hStdin = GetStdHandle(StdHandleType.STD_INPUT_HANDLE);
		hStdout = GetStdHandle(StdHandleType.STD_OUTPUT_HANDLE);
		if (hStdin == HFILE.INVALID_HANDLE_VALUE || hStdout == HFILE.INVALID_HANDLE_VALUE)
			return ShowErr("GetStdHandle");

		Aliases();
		Attach();
		ClearScreen();
		GetSetWindowInfo();
		IO();
		Others();
		ReadInputEvents();
		RegCtrlHandler();
		RWBlocks();
		ScrollContent();
		ScrollWindow();
		return 0;
	}

	private static int Aliases()
	{
		if (!AddConsoleAlias("test", "expansion string", Assembly.GetEntryAssembly().Location))
			return ShowErr("AddConsoleAlias");
		StringBuilder sb = new(256);
		if (!GetConsoleAlias("test", sb, (uint)sb.Capacity, Assembly.GetEntryAssembly().Location))
			return ShowErr("GetConsoleAlias");
		foreach (string exe in GetConsoleAliasExes())
		{
			foreach (string alias in GetConsoleAliases(exe))
			{
				Console.WriteLine($"{exe} => {alias}");
			}
		}
		return 0;
	}

	private static int Attach()
	{
		uint[] pids = GetConsoleProcessList();
		AttachConsole(pids[0]);

		FreeConsole();
		if (!AllocConsole())
			return ShowErr("AllocConsole");
		else
			FreeConsole();
		if (!AttachConsole(25412))
			return ShowErr("AttachConsole");
		else
			FreeConsole();
		AttachConsole(uint.MaxValue);

		return 0;
	}

	// Adapted from https://docs.microsoft.com/en-us/windows/console/clearing-the-screen
	private static int ClearScreen()
	{
		// Write some lines to the screen
		byte[] lines = Encoding.ASCII.GetBytes("Blah Blah Blah Blah Blah Blah Blah Blah Blah Blah Blah Blah\nBlah Blah Blah Blah Blah Blah Blah Blah Blah Blah\nBlah Blah Blah Blah");
		if (!WriteFile(hStdout, lines, (uint)lines.Length, out _, default))
			return ShowErr("WriteFile");
		Sleep(1000);

		// Get the number of character cells in the current buffer.
		if (!GetConsoleScreenBufferInfo(hStdout, out CONSOLE_SCREEN_BUFFER_INFO csbi))
			return ShowErr("GetConsoleScreenBufferInfo");

		// Fill the entire screen with blanks.
		uint dwConSize = (uint)(csbi.dwSize.X * csbi.dwSize.Y);
		if (!FillConsoleOutputCharacter(hStdout, ' ', dwConSize, default, out _))
			return ShowErr("FillConsoleOutputCharacter");

		// Get the current text attribute.
		if (!GetConsoleScreenBufferInfo(hStdout, out csbi))
			return ShowErr("GetConsoleScreenBufferInfo");

		// Set the buffer's attributes accordingly.
		if (!FillConsoleOutputAttribute(hStdout, csbi.wAttributes, dwConSize, default, out _))
			return ShowErr("FillConsoleOutputAttribute");

		// Put the cursor at its home coordinates.
		SetConsoleCursorPosition(hStdout, default);

		Sleep(1000);
		return 0;
	}

	private static int GetSetWindowInfo()
	{
		StringBuilder sb = new(256);
		if (GetConsoleTitle(sb, (uint)sb.Capacity) == 0)
			return ShowErr("GetConsoleTitle");
		if (!SetConsoleTitle("Test"))
			return ShowErr("SetConsoleTitle");
		if (GetConsoleOriginalTitle(sb, (uint)sb.Capacity) == 0)
			return ShowErr("GetConsoleOriginalTitle");

		if (!GetConsoleDisplayMode(out GET_CONSOLE_DISPLAY_MODE mode))
			return ShowErr("GetConsoleDisplayMode");
		Console.WriteLine($"Display mode = {mode}");

		uint cp = GetConsoleCP();
		if (!SetConsoleCP(cp))
			return ShowErr("SetConsoleCP");

		cp = GetConsoleOutputCP();
		if (!SetConsoleOutputCP(cp))
			return ShowErr("SetConsoleOutputCP");

		if (!GetConsoleCursorInfo(hStdout, out CONSOLE_CURSOR_INFO cursor))
			return ShowErr("GetConsoleCursorInfo");
		if (!SetConsoleCursorInfo(hStdout, cursor))
			return ShowErr("SetConsoleCursorInfo");

		if (!GetCurrentConsoleFont(hStdout, false, out CONSOLE_FONT_INFO curFont))
			return ShowErr("GetCurrentConsoleFont");
		CONSOLE_FONT_INFOEX curFontEx = CONSOLE_FONT_INFOEX.Default;
		if (!GetCurrentConsoleFontEx(hStdout, false, ref curFontEx))
			return ShowErr("GetCurrentConsoleFontEx");
		COORD fsz = GetConsoleFontSize(hStdout, curFont.nFont);
		if (fsz.X == 0 && fsz.Y == 0)
			return ShowErr("GetConsoleFontSize");

		if (!SetCurrentConsoleFontEx(hStdout, false, curFontEx))
			return ShowErr("SetCurrentConsoleFontEx");

		CONSOLE_HISTORY_INFO hist = CONSOLE_HISTORY_INFO.Default;
		if (!GetConsoleHistoryInfo(ref hist) || hist.NumberOfHistoryBuffers <= 0)
			return ShowErr("GetConsoleHistoryInfo");
		//hist.NumberOfHistoryBuffers++;
		//if (!SetConsoleHistoryInfo(hist))
		//	return ShowErr("SetConsoleHistoryInfo");

		COORD winSz = GetLargestConsoleWindowSize(hStdout);
		if (winSz.X == 0 && winSz.Y == 0)
			return ShowErr("GetConsoleHistoryInfo");

		HWND hwnd = GetConsoleWindow();
		if (hwnd.IsNull)
			return ShowErr("GetConsoleWindow");

		return 0;
	}

	// From https://docs.microsoft.com/en-us/windows/console/using-the-high-level-input-and-output-functions
	private static int IO()
	{
		byte[] lpszPrompt1 = Encoding.ASCII.GetBytes("Type a line and press Enter, or q to quit: ");
		byte[] lpszPrompt2 = Encoding.ASCII.GetBytes("Type any key, or q to quit: ");
		byte[] chBuffer = new byte[256];

		// Save the current text colors.
		if (!GetConsoleScreenBufferInfo(hStdout, out CONSOLE_SCREEN_BUFFER_INFO csbiInfo))
			return ShowErr("GetConsoleScreenBufferInfo");

		// Get current info
		CONSOLE_SCREEN_BUFFER_INFOEX csbiInfoEx = CONSOLE_SCREEN_BUFFER_INFOEX.Default;
		if (!GetConsoleScreenBufferInfoEx(hStdout, ref csbiInfoEx))
			return ShowErr("GetConsoleScreenBufferInfo");

		// Set the text attributes to draw red text on black background.
		if (!SetConsoleTextAttribute(hStdout, CHARACTER_ATTRIBUTE.FOREGROUND_RED | CHARACTER_ATTRIBUTE.FOREGROUND_INTENSITY))
			return ShowErr("SetConsoleTextAttribute");

		// Increase the screen buffer size
		if (!SetConsoleScreenBufferSize(hStdout, new COORD(csbiInfo.dwSize.X, (short)(csbiInfo.dwSize.Y + 10))))
			return ShowErr("SetConsoleScreenBufferSize");

		// Write to STDOUT and read from STDIN by using the default modes. Input is echoed automatically, and ReadFile does not return
		// until a carriage return is typed.
		//
		// The default input modes are line, processed, and echo. The default output modes are processed and wrap at EOL.
		while (true)
		{
			if (!WriteFile(hStdout, lpszPrompt1, (uint)lpszPrompt1.Length, out _, default))
				return ShowErr("WriteFile");

			if (!ReadFile(hStdin, chBuffer, (uint)chBuffer.Length, out _, default))
				break;
			if (chBuffer[0] == 'q')
				break;
		}

		// Turn off the line input and echo input modes
		if (!GetConsoleMode(hStdin, out CONSOLE_INPUT_MODE fdwOldMode))
			return ShowErr("GetConsoleMode");

		CONSOLE_INPUT_MODE fdwMode = fdwOldMode & ~(CONSOLE_INPUT_MODE.ENABLE_LINE_INPUT | CONSOLE_INPUT_MODE.ENABLE_ECHO_INPUT);
		if (!SetConsoleMode(hStdin, fdwMode))
			return ShowErr("SetConsoleMode");

		// ReadFile returns when any input is available. WriteFile is used to echo input.
		NewLine();

		while (true)
		{
			if (!WriteFile(hStdout, lpszPrompt2, (uint)lpszPrompt2.Length, out _, default))
				return ShowErr("WriteFile");

			if (!ReadFile(hStdin, chBuffer, (uint)chBuffer.Length, out uint cRead, default))
				break;
			if (chBuffer[0] == '\r')
				NewLine();
			else if (!WriteFile(hStdout, chBuffer, cRead, out _, default))
				break;
			else
				NewLine();
			if (chBuffer[0] == 'q') break;
		}

		// Restore the original settings.
		SetConsoleScreenBufferInfoEx(hStdin, csbiInfoEx);

		return 0;

		// The NewLine function handles carriage returns when the processed input mode is disabled. It gets the current cursor position
		// and resets it to the first cell of the next row.
		void NewLine()
		{
			if (!GetConsoleScreenBufferInfo(hStdout, out csbiInfo))
			{
				ShowErr("GetConsoleScreenBufferInfo");
				return;
			}

			// If it is the last line in the screen buffer, scroll the buffer up.
			csbiInfo.dwCursorPosition.X = 0;
			if (csbiInfo.dwSize.Y - 1 == csbiInfo.dwCursorPosition.Y)
				ScrollScreenBuffer(hStdout, 1);
			// Otherwise, advance the cursor to the next line.
			else
				csbiInfo.dwCursorPosition.Y += 1;

			if (!SetConsoleCursorPosition(hStdout, csbiInfo.dwCursorPosition))
				ShowErr("SetConsoleCursorPosition");
		}

		void ScrollScreenBuffer(HFILE h, short x)
		{
			SMALL_RECT srctScrollRect = new(0, 1, (short)(csbiInfo.dwSize.X - x), (short)(csbiInfo.dwSize.Y - x));

			// The destination for the scroll rectangle is one row up.
			COORD coordDest = default;

			// The clipping rectangle is the same as the scrolling rectangle. The destination row is left unchanged.
			SMALL_RECT srctClipRect = srctScrollRect;

			// Set the fill character and attributes.
			CHAR_INFO chiFill = new(' ', CHARACTER_ATTRIBUTE.FOREGROUND_RED | CHARACTER_ATTRIBUTE.FOREGROUND_INTENSITY);

			// Scroll up one line.
			ScrollConsoleScreenBuffer(h, srctScrollRect, srctClipRect, coordDest, chiFill);
		}
	}

	private static int Others()
	{
		FlushConsoleInputBuffer(hStdin);
		StringBuilder sb = new(256);
		ReadConsole(hStdin, sb, 1, out uint nRead); //, CONSOLE_READCONSOLE_CONTROL.Default);
		CHARACTER_ATTRIBUTE[] atts = new CHARACTER_ATTRIBUTE[256];
		ReadConsoleOutputAttribute(hStdout, atts, (uint)atts.Length, default, out uint ar);
		ReadConsoleOutputCharacter(hStdout, sb, (uint)sb.Capacity, default, out uint r);
		WriteConsole(hStdout, "Fred", 4, out uint wr);
		WriteConsoleInput(hStdin, new[] { INPUT_RECORD.CreateKeyEventRecord(true, 9, 9, '\t') }, 1, out wr);
		WriteConsoleOutputAttribute(hStdout, atts, ar, default, out wr);
		WriteConsoleOutputCharacter(hStdout, "\b", 1, default, out wr);
		return 0;
	}

	// Adapted from https://docs.microsoft.com/en-us/windows/console/reading-input-buffer-events
	private static int ReadInputEvents()
	{
		if (!GetConsoleMode(hStdin, out CONSOLE_INPUT_MODE fdwSaveOldMode))
			return ShowErr("GetConsoleMode");

		try
		{
			if (!SetConsoleMode(hStdin, CONSOLE_INPUT_MODE.ENABLE_WINDOW_INPUT | CONSOLE_INPUT_MODE.ENABLE_MOUSE_INPUT | CONSOLE_INPUT_MODE.ENABLE_EXTENDED_FLAGS))
				return ShowErr("SetConsoleMode");

			if (!GetNumberOfConsoleMouseButtons(out uint mouseBtn))
				return ShowErr("GetNumberOfConsoleMouseButtons");

			if (!GetConsoleSelectionInfo(out CONSOLE_SELECTION_INFO selInfo))
				return ShowErr("GetConsoleSelectionInfo");

			const uint recCnt = 128;
			INPUT_RECORD[] irInBuf = new INPUT_RECORD[recCnt];
			while (true)
			{
				if (!GetNumberOfConsoleInputEvents(hStdin, out uint evtNum))
					return ShowErr("GetNumberOfConsoleInputEvents");
				if (evtNum > 0)
				{
					PeekConsoleInput(hStdin, irInBuf, recCnt, out uint pkread);
				}

				if (!ReadConsoleInput(hStdin, irInBuf, recCnt, out uint cNumRead))
					return ShowErr("ReadConsoleInput");

				for (int i = 0; i < cNumRead; i++)
				{
					Debug.WriteLine($"Seeing event {irInBuf[i].EventType}");
					switch (irInBuf[i].EventType)
					{
						case EVENT_TYPE.KEY_EVENT:
							Debug.WriteLine($"Key event: {(irInBuf[i].Event.KeyEvent.bKeyDown ? "Pressed" : "Released")} Key: {irInBuf[i].Event.KeyEvent.uChar} ({irInBuf[i].Event.KeyEvent.wVirtualKeyCode})");
							if (irInBuf[i].Event.KeyEvent.uChar == 'q')
								return 0;
							break;

						case EVENT_TYPE.MOUSE_EVENT:
							MouseEventProc(irInBuf[i].Event.MouseEvent);
							break;

						case EVENT_TYPE.WINDOW_BUFFER_SIZE_EVENT:
							Debug.WriteLine($"Screen buffer is {irInBuf[i].Event.WindowBufferSizeEvent.dwSize}");
							break;

						case EVENT_TYPE.MENU_EVENT:
						case EVENT_TYPE.FOCUS_EVENT:
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

		void MouseEventProc(in MOUSE_EVENT_RECORD mouseEvent)
		{
			Debug.Write($"Mouse event: {mouseEvent.dwMousePosition} ");
			switch (mouseEvent.dwEventFlags)
			{
				case MOUSE_EVENT_FLAG.NONE:
					if (mouseEvent.dwButtonState == MOUSE_BUTTON_STATE.FROM_LEFT_1ST_BUTTON_PRESSED)
						Debug.WriteLine("Left btn press");
					else if (mouseEvent.dwButtonState == MOUSE_BUTTON_STATE.RIGHTMOST_BUTTON_PRESSED)
						Debug.WriteLine("Right btn press");
					else
						Debug.WriteLine("Btn press");
					break;

				case MOUSE_EVENT_FLAG.DOUBLE_CLICK:
					Debug.WriteLine("Double click");
					break;

				case MOUSE_EVENT_FLAG.MOUSE_HWHEELED:
					Debug.WriteLine("Horz mouse wheeled");
					break;

				case MOUSE_EVENT_FLAG.MOUSE_MOVED:
					Debug.WriteLine("Mouse moved");
					break;

				case MOUSE_EVENT_FLAG.MOUSE_WHEELED:
					Debug.WriteLine("Vert mouse wheeled");
					break;

				default:
					Debug.WriteLine("Unknown");
					break;
			}
		}
	}

	// From https://docs.microsoft.com/en-us/windows/console/registering-a-control-handler-function
	private static int RegCtrlHandler()
	{
		if (SetConsoleCtrlHandler(CtrlHandler, true))
		{
			Console.Write("\nThe Control Handler is installed.\n");
			Console.Write("\n -- Now try pressing Ctrl+C or Ctrl+Break, or");
			Console.Write("\n    try logging off or closing the console...\n");
			Console.Write("\n(...waiting in a loop for events...)\n\n");

			if (!GenerateConsoleCtrlEvent(CTRL_EVENT.CTRL_BREAK_EVENT, 0))
				return ShowErr("GenerateConsoleCtrlEvent failed");
			while (true) Sleep(100);
		}
		else
		{
			Console.Write("\nERROR: Could not set control handler");
			return 1;
		}

		bool CtrlHandler(CTRL_EVENT CtrlType)
		{
			switch (CtrlType)
			{
				// Handle the CTRL-C signal.
				case CTRL_EVENT.CTRL_C_EVENT:
					Console.Write("Ctrl-C event\n\n");
					Beep(750, 300);
					return true;

				// CTRL-CLOSE: confirm that the user wants to exit.
				case CTRL_EVENT.CTRL_CLOSE_EVENT:
					Beep(600, 200);
					Console.Write("Ctrl-Close event\n\n");
					return true;

				// Pass other signals to the next handler.
				case CTRL_EVENT.CTRL_BREAK_EVENT:
					Beep(900, 200);
					Console.Write("Ctrl-Break event\n\n");
					return false;

				case CTRL_EVENT.CTRL_LOGOFF_EVENT:
					Beep(1000, 200);
					Console.Write("Ctrl-Logoff event\n\n");
					return false;

				case CTRL_EVENT.CTRL_SHUTDOWN_EVENT:
					Beep(750, 500);
					Console.Write("Ctrl-Shutdown event\n\n");
					return false;

				default:
					return false;
			}
		}
	}

	// From https://docs.microsoft.com/en-us/windows/console/reading-and-writing-blocks-of-characters-and-attributes
	private static int RWBlocks()
	{
		// Get a handle to the STDOUT screen buffer to copy from and create a new screen buffer to copy to.
		SafeHFILE hNewScreenBuffer = CreateConsoleScreenBuffer(ACCESS_MASK.GENERIC_READ | ACCESS_MASK.GENERIC_WRITE, System.IO.FileShare.ReadWrite);
		if (hNewScreenBuffer == HFILE.INVALID_HANDLE_VALUE)
			return ShowErr("CreateConsoleScreenBuffer failed");

		// Make the new screen buffer the active screen buffer.
		if (!SetConsoleActiveScreenBuffer(hNewScreenBuffer))
			return ShowErr("SetConsoleActiveScreenBuffer failed");

		// Set the source rectangle.
		SMALL_RECT srctReadRect = new(0, 0, 79, 1);

		// The temporary buffer size is 2 rows x 80 columns.
		COORD coordBufSize = new(2, 80);

		// The top left destination cell of the temporary buffer is row 0, col 0.
		COORD coordBufCoord = new();

		// Copy the block from the screen buffer to the temp. buffer.
		CHAR_INFO[] chiBuffer = new CHAR_INFO[coordBufSize.X * coordBufSize.Y];
		if (!ReadConsoleOutput(hStdout, chiBuffer, coordBufSize, coordBufCoord, ref srctReadRect))
			return ShowErr("ReadConsoleOutput failed");

		// Set the destination rectangle.
		SMALL_RECT srctWriteRect = new(0, 10, 79, 11);

		// Copy from the temporary buffer to the new screen buffer.
		if (!WriteConsoleOutput(hNewScreenBuffer, chiBuffer, coordBufSize, coordBufCoord, ref srctWriteRect))
			return ShowErr("WriteConsoleOutput failed");
		Sleep(5000);

		// Restore the original active screen buffer.
		if (!SetConsoleActiveScreenBuffer(hStdout))
			return ShowErr("SetConsoleActiveScreenBuffer failed");

		return 0;
	}

	// From https://docs.microsoft.com/en-us/windows/console/scrolling-a-screen-buffer-s-contents
	private static int ScrollContent()
	{
		Console.Write("\nPrinting 20 lines for reference. Notice that line 6 is discarded during scrolling.\n");
		for (int i = 0; i <= 20; i++)
			Console.Write($"{i}\n");
		Sleep(1000);

		// Get the screen buffer size.
		if (!GetConsoleScreenBufferInfo(hStdout, out CONSOLE_SCREEN_BUFFER_INFO csbiInfo))
			return ShowErr("GetConsoleScreenBufferInfo");

		// The scrolling rectangle is the bottom 15 rows of the screen buffer.
		SMALL_RECT srctScrollRect = new(0, (short)(csbiInfo.dwSize.Y - 16), (short)(csbiInfo.dwSize.X - 1), (short)(csbiInfo.dwSize.Y - 1));

		// The destination for the scroll rectangle is one row up.
		COORD coordDest = new(0, (short)(csbiInfo.dwSize.Y - 17));

		// The clipping rectangle is the same as the scrolling rectangle. The destination row is left unchanged.
		SMALL_RECT srctClipRect = srctScrollRect;

		// Fill the bottom row with green blanks.
		CHAR_INFO chiFill = new(' ', CHARACTER_ATTRIBUTE.BACKGROUND_GREEN | CHARACTER_ATTRIBUTE.FOREGROUND_RED);

		// Scroll up one line.
		if (!ScrollConsoleScreenBuffer(hStdout, srctScrollRect, srctClipRect, coordDest, chiFill))
			return ShowErr("ScrollConsoleScreenBuffer");

		Sleep(1000);
		return 0;
	}

	// From https://docs.microsoft.com/en-us/windows/console/scrolling-a-screen-buffer-s-window
	private static int ScrollWindow()
	{
		Console.Write("\nPrinting twenty lines, then scrolling up five lines.\n");
		Console.Write("Press any key to scroll up ten lines; then press another key to stop the demo.\n");
		for (int i = 0; i <= 20; i++)
			Console.Write($"{i}\n");

		if (ScrollByAbsoluteCoord(5) > 0)
			Console.ReadKey();
		else
			return ShowErr("ScrollByAbsoluteCoord");

		if (ScrollByRelativeCoord(10) > 0)
			Console.ReadKey();
		else
			return ShowErr("ScrollByRelativeCoord");

		return 0;

		int ScrollByAbsoluteCoord(short iRows)
		{
			// Get the current screen buffer size and window position.
			if (!GetConsoleScreenBufferInfo(hStdout, out CONSOLE_SCREEN_BUFFER_INFO csbiInfo))
			{
				ShowErr("GetConsoleScreenBufferInfo");
				return 0;
			}

			// Set srctWindow to the current window size and location.
			SMALL_RECT srctWindow = csbiInfo.srWindow;

			// Check whether the window is too close to the screen buffer top
			if (srctWindow.Top >= iRows)
			{
				srctWindow.Top -= iRows;     // move top up
				srctWindow.Bottom -= iRows;  // move bottom up

				if (!SetConsoleWindowInfo(hStdout, true, srctWindow))
				{
					ShowErr("SetConsoleWindowInfo");
					return 0;
				}
				return iRows;
			}
			else
			{
				ShowMsg("\nCannot scroll; the window is too close to the top.\n");
				return 0;
			}
		}

		int ScrollByRelativeCoord(short iRows)
		{
			// Get the current screen buffer window position.
			if (!GetConsoleScreenBufferInfo(hStdout, out CONSOLE_SCREEN_BUFFER_INFO csbiInfo))
			{
				ShowErr("GetConsoleScreenBufferInfo");
				return 0;
			}

			// Check whether the window is too close to the screen buffer top
			if (csbiInfo.srWindow.Top >= iRows)
			{
				SMALL_RECT srctWindow = new(0, (short)-iRows, 0, (short)-iRows);

				if (!SetConsoleWindowInfo(hStdout, false, srctWindow))
				{
					ShowErr("SetConsoleWindowInfo");
					return 0;
				}
				return iRows;
			}
			else
			{
				ShowMsg("\nCannot scroll; the window is too close to the top.\n");
				return 0;
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
		byte[] bmsg = Encoding.ASCII.GetBytes(msg);
		WriteFile(hStdout, bmsg, (uint)bmsg.Length, out _, default);

		byte[] inBuf = new byte[2];
		ReadFile(hStdin, inBuf, (uint)inBuf.Length, out _, default);
	}
}