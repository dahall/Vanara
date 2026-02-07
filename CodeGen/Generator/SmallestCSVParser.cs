// SmallestCSVParser version 1.2.0 - Copyright (C) 2024-2025 Karl Pickett
namespace SmallestCSV;

/// <summary>Provides functionality to parse CSV (Comma-Separated Values) data from a <see cref="TextReader"/>.</summary>
/// <remarks>
/// This class supports reading CSV data row by row, with optional handling of header rows. It can process both quoted and unquoted columns,
/// and provides options to remove or preserve enclosing quotes for quoted columns.
/// </remarks>
internal class SmallestCSVParser
{
	private readonly StringBuilder sb = new();
	private readonly TextReader reader;

	/// <summary>Initializes a new instance of the <see cref="SmallestCSVParser"/> class to parse CSV data from the specified <see cref="TextReader"/>.</summary>
	/// <param name="reader">The <see cref="TextReader"/> instance used to read the CSV data. Cannot be <see langword="null"/>.</param>
	/// <param name="hasHeader">
	/// A value indicating whether the CSV data includes a header row. If <see langword="true"/>, the header row will be read and stored in
	/// the <see cref="Header"/> property.
	/// </param>
	/// <remarks>This class does not Close/Dispose the <paramref name="reader"/>.</remarks>
	public SmallestCSVParser(TextReader reader, bool hasHeader = false)
	{
		this.reader = reader;
		if (hasHeader)
			Header = ReadNextRow();
	}

	/// <summary>Gets the collection of header values associated with the current request or response.</summary>
	public IReadOnlyList<string>? Header { get; }

	/// <summary>
	/// Read all columns for the next row/line. If we are at end of file, this returns null. By default, columns that were quoted (") have
	/// their enclosing quotes removed. Set `removeEnclosingQuotes` to false if you want to preserve the quotes, for example to distinguish
	/// between an empty quoted vs unquoted column.
	/// </summary>
	public IReadOnlyList<string>? ReadNextRow(bool removeEnclosingQuotes = true)
	{
		List<string> ret = [];
		while (true)
		{
			(string? column, bool hasMore) = ReadNextColumn(removeEnclosingQuotes);
			if (column != null)
			{
				ret.Add(column);
			}
			if (!hasMore)
			{
				return ret.Any() ? ret : null;
			}
		}
	}

	private (string? Column, bool RowHasMoreColumns) ReadNextColumn(bool removeEnclosingQuotes)
	{
		sb.Clear();
		switch (reader.Peek())
		{
			case -1:
				return (null, false);

			case '"':
				ReadQuotedColumn(removeEnclosingQuotes);
				return (sb.ToString(), !TryFinishLine());

			default:
				ReadNonQuotedColumn();
				return (sb.ToString(), !TryFinishLine());
		}
	}

	// A non-quoted column ends with a newline, comma, or EOF.
	private void ReadNonQuotedColumn()
	{
		while (true)
		{
			int ch = reader.Peek();
			if (ch is (-1) or '\r' or '\n' or ',')
			{
				// We aren't consuming the '\r' here. A later call to ReadWithNormalizedNewline will consume it.
				return;
			}
			reader.Read();
			sb.Append((char)ch);
		}
	}

	// A quoted column ends with a non-escaped quote (").
	private void ReadQuotedColumn(bool removeEnclosingQuotes)
	{
		reader.Read();  // Remove the quote from the reader
		if (!removeEnclosingQuotes)
		{
			sb.Append('"');  // Optionally keep the quote in the result
		}
		while (true)
		{
			int ch = reader.Read();
			switch (ch)
			{
				case -1:
					throw new Error("EOF reached inside quoted column");
				case '"':
					if (reader.Peek() == '"')
					{
						// A "" is an escaped ". Keep it and continue.
						reader.Read();
						sb.Append('"');
						break;
					}
					else
					{
						// A non-escaped ". We're done with this column.
						if (!removeEnclosingQuotes)
						{
							sb.Append('"');  // Optionally keep the quote in the result
						}
						return;
					}
				default:
					sb.Append((char)ch);
					break;
			}
		}
	}

	// Consume and return the next char from the reader, or return EOF. Maps ('\r', '\n', '\r\n') -> '\n'.
	private int ReadWithNormalizedNewline()
	{
		int ret = reader.Read();
		if (ret == '\r')
		{
			if (reader.Peek() == '\n')
			{
				reader.Read();
			}
			ret = '\n';
		}
		return ret;
	}

	private bool TryFinishLine()
	{
		int ch = ReadWithNormalizedNewline();
		return ch switch
		{
			-1 or '\n' => true,// All columns parsed for this row/line
			',' => false,// More columns remain for this row/line
			_ => throw new Error($"Unrecognized character '{(char)ch}' after a parsed column"),
		};
	}

	/// <summary>This is thrown if the CSV has invalid syntax.</summary>
	public class Error(string message) : Exception(message)
	{
	}
}