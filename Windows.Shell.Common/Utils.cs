using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Vanara.Extensions;
using static Vanara.PInvoke.Ole32;

namespace Vanara.Windows.Shell
{
	/// <summary>Utility methods for shell functions.</summary>
	public static class Utils
	{
		private static int HdrLen = 0;

		/// <summary>Gets an HTML string from a pointer returned from the clipboard.</summary>
		/// <param name="ptr">The pointer to the clipboard formatted HTML.</param>
		/// <returns>The string representing the HTML.</returns>
		/// <exception cref="System.InvalidOperationException">HTML format header cannot be processed.</exception>
		public static string GetHtml(IntPtr ptr)
		{
			const string HdrRegEx = @"Version:\d\.\d\s+StartHTML:(\d+)\s+EndHTML:(\d+)\s+StartFragment:(\d+)\s+EndFragment:(\d+)\s+(?:StartSelection:(\d+)\s+EndSelection:(\d+)\s+)?";

			if (ptr == IntPtr.Zero)
			{
				return null;
			}

			// Find length of data by looking for a '\0' byte.
			int byteCount = 0;
			unsafe
			{
				for (byte* bp = (byte*)ptr.ToPointer(); byteCount < 4 * 1024 * 1024 && *bp != 0; byteCount++, bp++)
				{
					;
				}
			}
			byte[] bytes = ptr.ToArray<byte>(byteCount);
			// Get UTF8 encoded string
			string utf8String = Encoding.UTF8.GetString(bytes);
			// Find markers
			Match match = Regex.Match(utf8String, HdrRegEx);
			if (!match.Success)
			{
				throw new InvalidOperationException("HTML format header cannot be processed.");
			}

			int startHtml = int.Parse(match.Groups[1].Value.TrimStart('0'));
			int endHtml = int.Parse(match.Groups[2].Value.TrimStart('0'));
			int startFrag = int.Parse(match.Groups[3].Value.TrimStart('0'));
			int endFrag = int.Parse(match.Groups[4].Value.TrimStart('0'));
			int startSel = int.Parse(match.Groups[5].Value.TrimStart('0'));
			int endSel = int.Parse(match.Groups[6].Value.TrimStart('0'));

			return Encoding.UTF8.GetString(bytes, startFrag, endFrag - startFrag);
		}

		internal static T GetComData<T>(this IDataObject cdo, uint fmt, Func<IntPtr, T> convert, T defValue = default)
		{
			T ret = defValue;
			FORMATETC fc = new() { cfFormat = (short)fmt, dwAspect = DVASPECT.DVASPECT_CONTENT, lindex = -1, tymed = TYMED.TYMED_HGLOBAL };
			try
			{
				cdo.GetData(ref fc, out STGMEDIUM medium);
				if (medium.unionmember != default)
				{
					ret = convert(medium.unionmember);
				}

				ReleaseStgMedium(medium);
			}
			catch { }
			return ret;
		}

		internal static byte[] MakeClipHtml(string value)
		{
			const string Header = "Version:0.9\r\nStartHTML:{0:0000000000}\r\nEndHTML:{1:0000000000}\r\nStartFragment:{2:0000000000}\r\nEndFragment:{3:0000000000}\r\nStartSelection:{4:0000000000}\r\nEndSelection:{5:0000000000}\r\n";
			const string htmlDocType = "<!DOCTYPE html>";
			const string htmlBodyStart = "<HTML><HEAD><meta charset=\"UTF-8\"><TITLE>Snippet</TITLE></HEAD><BODY>";
			const string htmlBodyEnd = "</BODY></HTML>";
			const string fragmentStart = "<!--StartFragment-->";
			const string fragmentEnd = "<!--EndFragment-->";

			StringBuilder sb = new();
			if (value.IndexOf("<!DOCTYPE", StringComparison.OrdinalIgnoreCase) < 0)
			{
				sb.Append(htmlDocType);
			}

			if (value.IndexOf("<HTML>", StringComparison.OrdinalIgnoreCase) < 0)
			{
				sb.Append(htmlBodyStart);
			}

			int fragStartIdx = value.IndexOf(fragmentStart, StringComparison.OrdinalIgnoreCase);
			if (fragStartIdx < 0)
			{
				sb.Append(fragmentStart);
			}
			else
			{
				sb.Append(value.Substring(0, fragStartIdx + fragmentStart.Length));
				value = value.Remove(0, fragStartIdx + fragmentStart.Length);
			}
			fragStartIdx = Encoding.UTF8.GetByteCount(sb.ToString());

			int fragEndIdx = value.IndexOf(fragmentEnd, StringComparison.OrdinalIgnoreCase);
			if (fragEndIdx < 0)
			{
				sb.Append(value);
				fragEndIdx = Encoding.UTF8.GetByteCount(sb.ToString());
				sb.Append(fragmentEnd);
			}
			else
			{
				string preFrag = value.Substring(0, fragEndIdx);
				value = value.Remove(0, fragEndIdx);
				sb.Append(preFrag);
				fragEndIdx = Encoding.UTF8.GetByteCount(sb.ToString());
				sb.Append(value);
			}
			if (value.IndexOf("</HTML>", StringComparison.OrdinalIgnoreCase) < 0)
			{
				sb.Append(htmlBodyEnd);
			}

			if (HdrLen == 0)
			{
				HdrLen = string.Format(Header, 0, 0, 0, 0, 0, 0).Length;
			}

			int startHtml = HdrLen;
			int endHtml = HdrLen + Encoding.UTF8.GetByteCount(sb.ToString());
			int startFrag = HdrLen + fragStartIdx;
			int endFrag = HdrLen + fragEndIdx;
			int startSel = startFrag;
			int endSel = endFrag;
			sb.Insert(0, string.Format(Header, startHtml, endHtml, startFrag, endFrag, startSel, endSel));
			sb.Append('\0');

			return Encoding.UTF8.GetBytes(sb.ToString());
		}

		internal static void RunAsSTAThread(ThreadStart threadStart)
		{
			Thread thread = new(threadStart);
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			thread.Join();
		}

		internal static StringCollection ToSC(IEnumerable<string> e)
		{
			StringCollection sc = new();
			if (e != null)
			{
				sc.AddRange(e.ToArray());
			}

			return sc;
		}
	}
}