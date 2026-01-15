using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Odbc32;

namespace Vanara.PInvoke.Tests;
[TestFixture]
public class Odbc32Tests
{
	private const int DISPLAY_MAX = 50;
	private const short NULL_SIZE = 6;
	private const short DISPLAY_FORMAT_EXTRA = 3;
	private const short gHeight = 80;

	[OneTimeSetUp]
	public void _Setup()
	{
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void Test()
	{
		using var hEnv = SQLAllocHandle<SafeSQLHENV>();
		SQLSetEnvAttr(hEnv, SQL_ATTR.SQL_ATTR_ODBC_VERSION, (IntPtr)SQL_OV.SQL_OV_ODBC3, 0).ThrowIfFailed(hEnv);
		using var hDbc = SQLAllocHandle<SafeSQLHDBC>(hEnv);
		SQLDriverConnect(hDbc, GetDesktopWindow(), "", SQL_NTS, default, 0, out _, SQL_DRIVER.SQL_DRIVER_COMPLETE).ThrowIfFailed(hDbc);
		try
		{
			using var hStmt = SQLAllocHandle<SafeSQLHSTMT>(hDbc);
			SQLExec(hStmt, "SELECT * FROM Filters");
		}
		finally
		{
			SQLDisconnect(hDbc);
		}
	}

	static private void SQLExec(SQLHSTMT hStmt, string cmd)
	{
		SQLExecDirect(hStmt, cmd).ThrowIfFailed(hStmt);
		try
		{
			SQLNumResultCols(hStmt, out var sNumResults).ThrowIfFailed(hStmt);
			if (sNumResults > 0)
			{
				DisplayResults(hStmt, sNumResults);
			}
			else
			{
				SQLRowCount(hStmt, out var rows).ThrowIfFailed(hStmt);
				TestContext.WriteLine($"{rows} row{(rows == 1 ? "" : "s")} affected");
			}
		}
		finally
		{
			SQLFreeStmt(hStmt, SQL_STMT.SQL_CLOSE).ThrowIfFailed(hStmt);
		}
	}

	/************************************************************************
	/* DisplayResults: display results of a select query
	/*
	/* Parameters:
	/* hStmt ODBC statement handle
	/* cCols Count of columns
	/************************************************************************/
	static void DisplayResults(SQLHSTMT hStmt, short cCols)
	{
		// Allocate memory for each column 
		AllocateBindings(hStmt, cCols, out var pBindings, out var cDisplaySize);

		// Set the display mode and write the titles
		DisplayTitles(hStmt, (short)(cDisplaySize + 1), pBindings);

		// Fetch and display the data

		bool fNoData = false;
		int iCount = 0;
		do
		{
			// Fetch a row

			if (iCount++ >= gHeight - 2)
			{
				iCount = 1;
				DisplayTitles(hStmt, (short)(cDisplaySize + 1), pBindings);
			}

			SQLRETURN RetCode = SQLFetch(hStmt);
			if (RetCode == SQLRETURN.SQL_NO_DATA)
			{
				fNoData = true;
			}
			else
			{
				// Display the data. Ignore truncations

				foreach (var pThisBinding in pBindings)
				{
					TestContext.Write($"| {(pThisBinding.indPtr == SQL_NULL_DATA ? "<null>" : pThisBinding.wszBuffer!.ToString()!).PadRight(pThisBinding.cDisplaySize)}");
				}
				TestContext.WriteLine("|");
			}
		} while (!fNoData);
	}

	/************************************************************************
	/* AllocateBindings: Get column information and allocate bindings
	/* for each column. 
	/*
	/* Parameters:
	/* hStmt Statement handle
	/* cCols Number of columns in the result set
	/* *lppBinding Binding pointer (returned)
	/* lpDisplay Display size of one line
	/************************************************************************/
	static void AllocateBindings(SQLHSTMT hStmt, short cCols, out IList<BINDING> ppBinding, out short pDisplay)
	{
		ppBinding = [];
		pDisplay = 0;

		for (ushort iCol = 1; iCol <= cCols; iCol++)
		{
			BINDING pThisBinding = new();
			ppBinding.Add(pThisBinding);

			// Figure out the display length of the column (we will
			// bind to byte since we are only displaying data, in general
			// you should bind to the appropriate C type if you are going
			// to manipulate data since it is much faster...)

			//SQLColAttribute(hStmt, iCol, SQL_DESC.SQL_DESC_DISPLAY_SIZE, default, 0, out _, out var cchDisplay).ThrowIfFailed(hStmt);
			var cchDisplay = SQLColAttribute<int>(hStmt, iCol, SQL_DESC.SQL_DESC_DISPLAY_SIZE);

			// Figure out if this is a character or numeric column; this is
			// used to determine if we want to display the data left- or right-
			// aligned.

			// SQL_DESC_CONCISE_TYPE maps to the 1.x SQL_COLUMN_TYPE. 
			// This is what you must use if you want to work
			// against a 2.x driver.

			//SQLColAttribute(hStmt, iCol, SQL_DESC.SQL_DESC_CONCISE_TYPE, default, 0, out _, out var ssType).ThrowIfFailed(hStmt);
			var ssType = SQLColAttribute<SQL_TYPE>(hStmt, iCol, SQL_DESC.SQL_DESC_CONCISE_TYPE);

			pThisBinding.fChar = ssType is SQL_TYPE.SQL_CHAR or SQL_TYPE.SQL_VARCHAR or SQL_TYPE.SQL_LONGVARCHAR;

			// Arbitrary limit on display size
			if (cchDisplay > DISPLAY_MAX)
				cchDisplay = DISPLAY_MAX;

			// Allocate a buffer big enough to hold the text representation
			// of the data. Add one character for the null terminator

			pThisBinding.wszBuffer = new(cchDisplay + 1);

			// Map this buffer to the driver's buffer. At Fetch time,
			// the driver will fill in this data. Note that the size is 
			// count of bytes (for Unicode). All ODBC functions that take
			// SQLPOINTER use count of bytes; all functions that take only
			// strings use count of characters.

			SQLBindCol(hStmt, iCol, SQL_C_TCHAR(), pThisBinding.wszBuffer, pThisBinding.wszBuffer.Size, ref pThisBinding.indPtr).ThrowIfFailed(hStmt);

			// Now set the display size that we will use to display
			// the data. Figure out the length of the column name

			pThisBinding.colName = SQLColAttribute<string>(hStmt, iCol, SQL_DESC.SQL_DESC_NAME);

			pThisBinding.cDisplaySize = (short)Math.Max(cchDisplay, pThisBinding.colName.Length);
			if (pThisBinding.cDisplaySize < NULL_SIZE)
				pThisBinding.cDisplaySize = NULL_SIZE;

			pDisplay += (short)(pThisBinding.cDisplaySize + DISPLAY_FORMAT_EXTRA);
		}
	}

	/************************************************************************
	/* DisplayTitles: print the titles of all the columns and set the 
	/* shell window's width
	/*
	/* Parameters:
	/* hStmt Statement handle
	/* cDisplaySize Total display size
	/* pBinding list of binding information
	/************************************************************************/
	static void DisplayTitles(SQLHSTMT hStmt, short cDisplaySize, IList<BINDING> pBindings)
	{
		foreach (var pBinding in pBindings)
		{
			TestContext.Write($"| {(pBinding.colName ?? "").PadRight(pBinding.cDisplaySize)}");
		}
		TestContext.WriteLine("|");
	}

	public class BINDING
	{
		public short cDisplaySize;           /* size to display  */
		public string? colName;              /* name of column   */
		public SafePTSTR? wszBuffer;        /* display buffer   */
		public nint indPtr;                  /* size or null     */
		public bool fChar;                   /* character col?   */
	}

	[DllImport("user32.dll", SetLastError = true)]
	private static extern HWND GetDesktopWindow();
}