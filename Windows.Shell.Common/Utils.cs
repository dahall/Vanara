using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Vanara.Extensions;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	/// <summary>Utility methods for shell functions.</summary>
	public static class Utils
	{
		/// <summary>Gets an HTML string from a pointer returned from the clipboard.</summary>
		/// <param name="ptr">The pointer to the clipboard formatted HTML.</param>
		/// <returns>The string representing the HTML.</returns>
		/// <exception cref="System.InvalidOperationException">HTML format header cannot be processed.</exception>
		public static string GetHtml(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
			{
				return null;
			}

			int byteCount = GlobalSize(ptr);

			// If not an HGLOBAL pointer, find length of data by looking for a '\0' byte.
			if (byteCount == 0)
			{
				unsafe
				{
					for (byte* bp = (byte*)ptr.ToPointer(); byteCount < 4 * 1024 * 1024 && *bp != 0; byteCount++, bp++)
					{
						;
					}
				}
			}

			return GetHtmlFromClipboard(ptr.ToArray<byte>(byteCount));
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