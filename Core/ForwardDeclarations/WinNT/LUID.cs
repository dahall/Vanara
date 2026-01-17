namespace Vanara.PInvoke;

/// <summary>
/// An LUID is a 64-bit value guaranteed to be unique only on the system on which it was generated. The uniqueness of a locally unique
/// identifier (LUID) is guaranteed only until the system is restarted.
/// <para>Applications must use functions and structures to manipulate LUID values.</para>
/// </summary>
[TypeDef(typeof(long), Excludes = ExcludeOptions.ToString | ExcludeOptions.Convertible | ExcludeOptions.Parsable | ExcludeOptions.Numerics)]
public partial struct LUID
{
	/// <summary>High order bits.</summary>
	public int HighPart { readonly get => value.HighPart(); set => this.value = Macros.MAKELONG64(LowPart, value); }

	/// <summary>Low order bits.</summary>
	public uint LowPart { readonly get => value.LowPart(); set => this.value = Macros.MAKELONG64(value, HighPart); }

	/// <summary>Creates a new LUID instance from a privilege name.</summary>
	/// <param name="name">The privilege name.</param>
	/// <param name="systemName">Name of the system on which to perform the lookup. Specifying <c>null</c> will query the local system.</param>
	/// <returns>The LUID instance corresponding to the <paramref name="name"/>.</returns>
	public static LUID FromName(string name, string? systemName = null) =>
		LookupPrivilegeValue(systemName, name, out LUID val) ? val : throw Win32Error.GetLastError().GetException()!;

	/// <summary>
	/// Creates a new LUID that is unique to the local system only, and uniqueness is guaranteed only until the system is next restarted.
	/// </summary>
	/// <returns>A new LUID.</returns>
	public static LUID NewLUID()
	{
		if (!AllocateLocallyUniqueId(out LUID ret))
			Win32Error.ThrowLastError();
		return ret;
	}

	/// <summary>Gets the privilege name for this LUID.</summary>
	/// <param name="systemName">Name of the system on which to perform the lookup. Specifying <c>null</c> will query the local system.</param>
	/// <returns>The name retrieved for the LUID.</returns>
	public readonly string GetName(string? systemName = null)
	{
		var sb = new StringBuilder(1024);
		var sz = (uint)sb.Capacity;
		if (!LookupPrivilegeName(systemName, in this, sb, ref sz))
			Win32Error.ThrowLastError();
		return sb.ToString();
	}

	/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
	/// <returns>A <see cref="string"/> that represents this instance.</returns>
	public override readonly string ToString()
	{
		try { return GetName(); } catch { return $"0x{value:X}"; }
	}

	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool AllocateLocallyUniqueId(out LUID Luid);

	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool LookupPrivilegeName([MarshalAs(UnmanagedType.LPTStr)] string? lpSystemName,
		in LUID lpLuid, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpName, ref uint cchName);

	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool LookupPrivilegeValue([MarshalAs(UnmanagedType.LPTStr)] string? lpSystemName,
		[MarshalAs(UnmanagedType.LPTStr)] string lpName, out LUID lpLuid);
}