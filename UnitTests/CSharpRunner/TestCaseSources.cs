using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Vanara.PInvoke.Tests;

public static class TestCaseSources
{
	// Header: ValidUser ValidCred URN DN DC Domain Username Password Notes
	private const string authfn = @"C:\Temp\AuthTestCases.txt";
	private const string sourceFile = @"C:\Temp\TestCaseSources.txt";
	private const string svrfn = @"C:\Temp\ServerConnectionTestCases.txt";

	// Header: Server IP User Domain Pwd ValidSvr ValidCred UserIsAdmin Local Internet Name
	private static readonly string[] svrhdr = ["Server", "IP", "User", "Domain", "Pwd", "ValidSvr", "ValidCred", "UserIsAdmin", "Local", "Internet", "Name"];
	private static readonly Dictionary<string, string?> lookup;

	static TestCaseSources()
	{
		// Read in test case sources from file
		lookup = [];
		if (File.Exists(sourceFile))
		{
			var lines = File.ReadAllLines(sourceFile);
			lookup = new Dictionary<string, string?>(lines.Length);
			foreach (var line in lines)
			{
				if (line.Trim().Length == 0 || line[0] == '\'')
					continue;
				var i = line.IndexOf('=');
				if (i == -1)
					lookup.Add(line, null);
				else
					lookup.Add(line.Substring(0, i), line.Length > i + 1 ? line.Substring(i + 1) : string.Empty);
			}
		}
		else
			lookup = [];
	}

	public static object[] AuthCasesFromFile
	{
		get
		{
			var lines = File.ReadAllLines(authfn).Skip(1).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
			var ret = new object[lines.Length];
			for (var i = 0; i < lines.Length; i++)
			{
				var items = lines[i].Split('\t').Select(s => s == string.Empty ? null : s).Cast<object>().ToArray();
				if (items.Length < 9) continue;
				bool.TryParse(items[0].ToString(), out var validUser);
				items[0] = validUser;
				bool.TryParse(items[1].ToString(), out var validCred);
				items[1] = validCred;
				ret[i] = items;
			}
			return ret;
		}
	}

	public static string BmpFile => GetLookupValue(@"test.bmp");
	public static string DummyFile => GetLookupValue(@"test.dmy");
	public static string EventFile => GetLookupValue(@"TestLogFile.etl");
	public static string IcoFile => GetLookupValue(@"Vanara.ico");
	public static string Image2File => GetLookupValue(@"X.png");
	public static string ImageFile => GetLookupValue(@"Vanara.png");
	public static string LargeFile => GetLookupValue(@"Holes.mp4");
	public static string LogFile => GetLookupValue(@"Test.log");
	public static IDictionary<string, string?> Lookup => lookup;
	public static string ResourceFile => GetLookupValue(@"DummyResourceExe.exe");
	public static string SmallFile => (lookup.TryGetValue(nameof(SmallFile), out var value) ? value : null) ?? Image2File;
	public static string TempChildDir => (lookup.TryGetValue(nameof(TempChildDir), out var value) ? value : null) ?? @"C:\Temp\Temp";
	public static string TempChildDirWhack => (lookup.TryGetValue(nameof(TempChildDirWhack), out var value) ? value : null) ?? TempChildDir + "\\";
	public static string TempDir => (lookup.TryGetValue(nameof(TempDir), out var value) ? value : null) ?? @"C:\Temp";
	public static string TempDirWhack => (lookup.TryGetValue(nameof(TempDirWhack), out var value) ? value : null) ?? TempDir + "\\";
	public static string VirtualDisk => GetLookupValue(@"Test.vhdx");
	public static string WordDoc => GetLookupValue(@"Test.docx");
	public static string WordDocLink => GetLookupValue("Test.lnk");

	public static object[] GetAuthCasesFromFile(bool validUser, bool validCred) => AuthCasesFromFile.Where(objs => ((object[])objs)[0].Equals(validUser) && ((object[])objs)[1].Equals(validCred)).ToArray();

	/// <summary>Gets the full file path of a file in the Temp directory.</summary>
	/// <param name="fn">The file name.</param>
	/// <returns>The full path to the file.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string GetFilePath(string fn) => Path.Combine(TempDir, fn);

	/// <summary>Gets the value from a key or retuns a default value.</summary>
	/// <param name="key">The key.</param>
	/// <param name="defaultValue">The default value.</param>
	/// <returns>The value corresponding to key or the default value if not found.</returns>
	public static string? GetValueOrDefault(string key, string? defaultValue = null) => lookup.TryGetValue(key, out var value) ? value : defaultValue;

	public static IEnumerable<TestCaseData> RemoteConnections(bool? named, int flags = 0)
	{
		foreach (var item in GetFileItems(svrfn, null, filter))
		{
			var tcd = new TestCaseData(item.Take(5).Cast<object>().ToArray()); //.SetName(item[10]);
			int flagVal = 0;
			for (int i = 5; i < 10; i++)
				if (item[i][0] == 'T') { tcd.SetCategory(svrhdr[i]); flagVal |= (1 << (i - 5)); }
			if (flags == 0 || flags == flagVal)
				yield return tcd;
		}

		bool filter(IReadOnlyDictionary<string, string> d)
		{
			var svr = d["Server"];
			var bSvr = !named.HasValue || string.IsNullOrEmpty(svr) != named.Value;
			//var real = bool.Parse(d["ValidSvr"]?.ToLower());
			//var bReal = valid.HasValue ? real == valid.Value : true;
			//var vCred = bool.Parse(d["ValidCred"]?.ToLower());
			//var bCred = validCred.HasValue ? vCred == validCred.Value : true;
			//var vAdm = bool.Parse(d["UserIsAdmin"]?.ToLower());
			//var bAdm = admin.HasValue ? vAdm == admin.Value : true;
			return bSvr; // && bReal && bCred && bAdm;
		}
	}

	private static IEnumerable<string[]> GetFileItems(string fn, string[]? cols = null, Func<IReadOnlyDictionary<string, string>, bool>? filter = null)
	{
		var first = true;
		string[] hdr = [];
		int[]? idxs = null;
		foreach (var ln in File.ReadLines(fn))
		{
			// Skip blank lines
			if (ln.Trim() == string.Empty)
				continue;

			var items = ln.Split('\t');
			// Get header indices for cols from first row
			if (first)
			{
				hdr = items;
				cols ??= items;
				idxs = cols.Select(s => Array.IndexOf(items, s)).ToArray();
				first = false;
				continue;
			}
			// Get selected columns for each row
			var ret = new string[cols?.Length ?? 0];
			for (int i = 0; i < (idxs?.Length ?? 0); i++)
			{
				var idx = idxs![i];
				ret[i] = idx >= 0 ? items[idx] : "";
			}
			// Filter if req
			if (filter is null)
				yield return ret;
			else if (filter(new StrArrDict(hdr, items)))
				yield return ret;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static string GetLookupValue(string fn, [CallerMemberName] string? key = null) => (lookup.TryGetValue(key!, out var value) ? value : null) ?? GetFilePath(fn);

	private class StrArrDict : IReadOnlyDictionary<string, string>
	{
		private readonly string[] keys;
		private readonly string[] values;

		public StrArrDict(string[] k, string[] v)
		{
			keys = k;
			values = v;
		}

		public int Count => keys.Length;
		public IEnumerable<string> Keys => keys;
		public IEnumerable<string> Values => values;
		public string this[string key] => TryGetValue(key, out var value) ? value : throw new IndexOutOfRangeException();

		public bool ContainsKey(string key) => keys.Contains(key);

		public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => new DEnum(this);

		public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
		{
			var idx = Array.IndexOf(keys, key);
			if (idx == -1)
			{
				value = null;
				return false;
			}
			value = values[idx];
			return true;
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		private class DEnum : IEnumerator<KeyValuePair<string, string>>
		{
			private int c = -1;
			private readonly StrArrDict p;

			public DEnum(StrArrDict parent) => p = parent;

			public KeyValuePair<string, string> Current => new(p.keys[c], p.values[c]);

			object IEnumerator.Current => Current;

			public void Dispose() => GC.SuppressFinalize(this);

			public bool MoveNext() => ++c < p.keys.Length;

			public void Reset() => c = -1;
		}
	}
}