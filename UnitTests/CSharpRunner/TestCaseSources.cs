using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Vanara.PInvoke.Tests
{
	public static class TestCaseSources
	{
		public const string BmpFile = @"C:\Temp\Vanara.bmp";

		public const string EventFile = @"C:\Temp\TestLogFile.etl";

		public const string IcoFile = @"C:\Temp\Vanara.ico";

		public const string ImageFile = @"C:\Temp\Vanara.png";

		public const string Image2File = @"C:\Temp\X.png";

		public const string LargeFile = @"C:\Temp\Holes.mp4";

		public const string LogFile = @"C:\Temp\Test.log";

		public const string ResourceFile = @"C:\Temp\DummyResourceExe.exe";

		public const string SmallFile = Image2File;

		public const string TempChildDir = @"C:\Temp\Temp";

		public const string TempChildDirWhack = TempChildDir + "\\";

		public const string TempDir = @"C:\Temp";

		public const string TempDirWhack = TempDir + "\\";

		public const string VirtualDisk = @"D:\VirtualBox VMs\Windows Client\Windows XP Pro\Windows XP Pro.vhd";

		public const string WordDoc = @"C:\Temp\Test.docx";

		public const string WordDocLink = @"C:\Temp\Test.lnk";

		// Header: ValidUser ValidCred URN DN DC Domain Username Password Notes
		private const string authfn = @"C:\Temp\AuthTestCases.txt";

		private const string svrfn = @"C:\Temp\ServerConnectionTestCases.txt";

		// Header: Server IP User Domain Pwd ValidSvr ValidCred UserIsAdmin Local Internet Name
		private static readonly string[] svrhdr = { "Server", "IP", "User", "Domain", "Pwd", "ValidSvr", "ValidCred", "UserIsAdmin", "Local", "Internet", "Name" };

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
		public static object[] GetAuthCasesFromFile(bool validUser, bool validCred) => AuthCasesFromFile.Where(objs => ((object[])objs)[0].Equals(validUser) && ((object[])objs)[1].Equals(validCred)).ToArray();

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
				var bSvr = named.HasValue ? string.IsNullOrEmpty(svr) != named.Value : true;
				//var real = bool.Parse(d["ValidSvr"]?.ToLower());
				//var bReal = valid.HasValue ? real == valid.Value : true;
				//var vCred = bool.Parse(d["ValidCred"]?.ToLower());
				//var bCred = validCred.HasValue ? vCred == validCred.Value : true;
				//var vAdm = bool.Parse(d["UserIsAdmin"]?.ToLower());
				//var bAdm = admin.HasValue ? vAdm == admin.Value : true;
				return bSvr; // && bReal && bCred && bAdm;
			}
		}

		private static IEnumerable<string[]> GetFileItems(string fn, string[] cols = null, Func<IReadOnlyDictionary<string, string>, bool> filter = null)
		{
			var first = true;
			string[] hdr = null;
			int[] idxs = null;
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
					if (cols is null)
						cols = items;
					idxs = cols.Select(s => Array.IndexOf(items, s)).ToArray();
					first = false;
					continue;
				}
				// Get selected columns for each row
				var ret = new string[cols.Length];
				for (int i = 0; i < idxs.Length; i++)
				{
					var idx = idxs[i];
					ret[i] = idx >= 0 ? items[idx] : null;
				}
				// Filter if req
				if (filter is null)
					yield return ret;
				else if (filter(new StrArrDict(hdr, items)))
					yield return ret;
			}
		}

		private class StrArrDict : IReadOnlyDictionary<string, string>
		{
			private string[] keys;
			private string[] values;

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

			public bool TryGetValue(string key, out string value)
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
				private StrArrDict p;

				public DEnum(StrArrDict parent) => p = parent;

				public KeyValuePair<string, string> Current => new KeyValuePair<string, string>(p.keys[c], p.values[c]);

				object IEnumerator.Current => Current;

				public void Dispose() => p = null;

				public bool MoveNext() => ++c < p.keys.Length;

				public void Reset() => c = -1;
			}
		}
	}
}