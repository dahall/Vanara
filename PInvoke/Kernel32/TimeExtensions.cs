using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Convert a <see cref="SYSTEMTIME"/> value to a <see cref="FILETIME"/> value.</summary>
		/// <param name="st">The <see cref="SYSTEMTIME"/> value.</param>
		/// <returns>The converted <see cref="FILETIME"/> value.</returns>
		public static FILETIME ToFILETIME(this SYSTEMTIME st)
		{
			var ft = new FILETIME();
			SystemTimeToFileTime(ref st, ref ft);
			return ft;
		}

		/// <summary>Convert a <see cref="FILETIME"/> value to a <see cref="SYSTEMTIME"/> value.</summary>
		/// <param name="st">The <see cref="FILETIME"/> value.</param>
		/// <returns>The converted <see cref="SYSTEMTIME"/> value.</returns>
		public static SYSTEMTIME ToSYSTEMTIME(this FILETIME ft)
		{
			var st = new SYSTEMTIME();
			FileTimeToSystemTime(ref ft, ref st);
			return st;
		}
	}
}