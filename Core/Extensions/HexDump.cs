namespace Vanara.Extensions;

/// <summary>Extension to dump a byte array.</summary>
public static class HexDempHelpers
{
	/// <summary>Creates a multi-line dump of a byte array using hexadecimal values.</summary>
	/// <param name="bytes">The byte array to dump. This value cannot be <see langword="null"/>.</param>
	/// <param name="bytesPerRow">The number of bytes to display on each line.</param>
	/// <param name="gapEvery">The number of bytes to display before inserting an extra space to create a visual gap.</param>
	/// <param name="rowIdLen">
	/// The number of hexadecimal digits to display on the left side of each line to indicate position. If this value is 0, then no
	/// position indicator will be shown. If this value is -1, then the size will be computed in increments of 4 based on the size of <paramref name="bytes"/>.
	/// </param>
	/// <param name="location">
	/// A pointer location to show to the left of the row identifier. If set to <c>IntPtr.Zero</c>, no location value is shown.
	/// </param>
	/// <returns>A multi-line string that contains a hexadecimal dump of <paramref name="bytes"/>.</returns>
	/// <exception cref="ArgumentNullException">bytes</exception>
	/// <exception cref="ArgumentNullException">bytes</exception>
	public static string ToHexDumpString(this byte[] bytes, int bytesPerRow = 16, int gapEvery = 4, int rowIdLen = -1, IntPtr location = default)
	{
		if (bytes == null) throw new ArgumentNullException(nameof(bytes));
		var sb = new StringBuilder();
		var hdrlen = rowIdLen == -1 ? (((bytes.Length.ToString("X").Length - 1) / 4) + 1) * 4 : rowIdLen;
		var hdrfmt = hdrlen == 0 ? "" : $"{{0:X{hdrlen}}}: ";
		if (location != IntPtr.Zero) hdrfmt = $"0x{{1:X{IntPtr.Size * 2}}} " + hdrfmt;
		for (var l = 0; l < bytes.Length; l += bytesPerRow)
		{
			sb.AppendFormat(hdrfmt, l, location.Offset(l).ToInt64());
			for (var i = l; i < bytes.Length && i < l + bytesPerRow; i++)
			{
				sb.Append($"{bytes[i]:X2} ");
				if ((i + 1) % gapEvery == 0) sb.Append(" ");
			}
			sb.AppendLine();
		}
		return sb.ToString();
	}

	/// <summary>
	/// Creates a multi-line dump of a byte array using hexadecimal values.
	/// </summary>
	/// <param name="ptr">A pointer to the memory to dump.</param>
	/// <param name="byteCount">The number of bytes to display starting at the location pointed to by <paramref name="ptr" />.</param>
	/// <param name="bytesPerRow">The number of bytes to display on each line.</param>
	/// <param name="gapEvery">The number of bytes to display before inserting an extra space to create a visual gap.</param>
	/// <param name="rowIdLen">The number of hexadecimal digits to display on the left side of each line to indicate position. If this value is 0, then no
	/// position indicator will be shown. If this value is -1, then the size will be computed in increments of 4 based on the size of <paramref name="byteCount" />.</param>
	/// <param name="showLocation">If set to <c>true</c>, the pointer location value is shown to the left of the row identifier.</param>
	/// <returns>
	/// A multi-line string that contains a hexadecimal dump of <paramref name="ptr" />.
	/// </returns>
	/// <exception cref="ArgumentNullException">bytes</exception>
	public static string? ToHexDumpString(this IntPtr ptr, int byteCount, int bytesPerRow = 16, int gapEvery = 4, int rowIdLen = -1, bool showLocation = true) =>
		ptr.ToByteArray(byteCount)?.ToHexDumpString(bytesPerRow, gapEvery, rowIdLen, showLocation ? ptr : IntPtr.Zero);
}