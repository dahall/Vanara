using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara
{
	internal static class UnitTestHelper
	{
		/// <summary>Creates a multi-line dump of a byte array using hexadecimal values.</summary>
		/// <param name="bytes">The byte array to dump. This value cannot be <see langword="null"/>.</param>
		/// <param name="bytesPerRow">The number of bytes to display on each line.</param>
		/// <param name="gapEvery">The number of bytes to display before inserting an extra space to create a visual gap.</param>
		/// <param name="rowIdLen">
		/// The number of hexadecimal digits to display on the left side of each line to indicate position. If this value is 0, then no
		/// position indicator will be shown. If this value is -1, then the size will be computed in increments of 4 based on the size of
		/// <paramref name="bytes"/>.
		/// </param>
		/// <returns>A multi-line string that contains a hexadecimal dump of <paramref name="bytes"/>.</returns>
		/// <exception cref="ArgumentNullException">bytes</exception>
		public static string ToHexDumpString(this byte[] bytes, int bytesPerRow = 16, int gapEvery = 4, int rowIdLen = -1)
		{
			if (bytes == null) throw new ArgumentNullException(nameof(bytes));
			var sb = new System.Text.StringBuilder();
			var hdrlen = rowIdLen == -1 ? (((bytes.Length.ToString("X").Length - 1) / 4) + 1) * 4 : rowIdLen;
			var hdrfmt = hdrlen == 0 ? "" : "{0:X" + hdrlen.ToString() + "}: ";
			for (var l = 0; l < bytes.Length; l += bytesPerRow)
			{
				sb.AppendFormat(hdrfmt, l);
				for (var i = l; i < bytes.Length && i < l + bytesPerRow; i++)
				{
					sb.Append($"{bytes[i]:X2} ");
					if ((i + 1) % gapEvery == 0) sb.Append(" ");
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}

		public static string Dump(object o)
		{
			using (var p = new PinnedObject(o))
				return (((IntPtr)p).ToArray<byte>(Marshal.SizeOf(o))).ToHexDumpString();
		}
	}
}
