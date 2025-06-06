﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary>Class representation of the native SID structure.</summary>
	/// <seealso cref="SafeHGlobalHandle"/>
	[DebuggerDisplay("{DebugString}")]
	public class SafePSID : SafeMemoryHandle<LocalMemoryMethods>, IEquatable<SafePSID>, IEquatable<PSID>, IEquatable<IntPtr>, ICloneable, ISecurityObject
	{
		/// <summary>Equivalent to a NULL pointer to a SID.</summary>
		public static readonly SafePSID Null = new(SizeT.Zero);

		/// <summary>Initializes a new instance of the <see cref="SafePSID"/> class.</summary>
		/// <param name="psid">The existing <see cref="SafePSID"/> instance to duplicate.</param>
		public SafePSID(PSID psid) : base(psid.IsNull ? 0 : GetLengthSid(psid)) { if (!psid.IsNull) CopySid(Size, handle, psid); }

		/// <summary>Initializes a new instance of the <see cref="SafePSID"/> class.</summary>
		/// <param name="size">The size of memory to allocate, in bytes.</param>
		public SafePSID(SizeT size) : base(size)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="SafePSID"/> class.</summary>
		/// <param name="sidBytes">An array of bytes that contain a valid Sid.</param>
		public SafePSID(byte[]? sidBytes) : base(sidBytes?.Length ?? 0) { if (Size > 0) Marshal.Copy(sidBytes!, 0, handle, Size); }

		/// <summary>Initializes a new instance of the <see cref="SafePSID"/> class.</summary>
		/// <param name="sidValue">The string SID value.</param>
		public SafePSID(string sidValue) : this(ConvertStringSidToSid(sidValue))
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SafePSID"/> class from a
		/// <see cref="SecurityIdentifier"/> instance.
		/// </summary>
		/// <param name="si">The <see cref="SecurityIdentifier"/> instance.</param>
		public SafePSID(SecurityIdentifier? si) : this(si is null ? null : GetBytes(si))
		{
		}

		/// <summary>Initializes a new instance of the <see cref="SafePSID"/> class.</summary>
		private SafePSID() : base() { }

		/// <summary>Gets a pointer to the SID_IDENTIFIER_AUTHORITY structure in this security identifier (SID).</summary>
		/// <returns>A pointer to the SID_IDENTIFIER_AUTHORITY structure for this SID structure.</returns>
		public PSID_IDENTIFIER_AUTHORITY Authority => GetSidIdentifierAuthority(this);

		/// <summary>Gets the SID for the current user</summary>
		/// <value>The current user's SID.</value>
		public static SafePSID Current
		{
			get
			{
				using WindowsIdentity identity = WindowsIdentity.GetCurrent();
				return new(identity.User);
			}
		}

		/// <summary>A SID representing the Everyone Group (S-1-1-0).</summary>
		public static SafePSID Everyone => CreateWellKnown(WELL_KNOWN_SID_TYPE.WinWorldSid);

		/// <summary>
		/// Verifies that the revision number is within a known range, and that the number of subauthorities is less than the maximum.
		/// </summary>
		/// <value><c>true</c> if this instance is a valid SID; otherwise, <c>false</c>.</value>
		public bool IsValidSid => IsValidSid(this);

		/// <summary>Gets the length, in bytes, of the SID.</summary>
		/// <value>The SID length, in bytes.</value>
		public int Length => IsValidSid ? GetLengthSid(this) : 0;

		/// <summary>Enumerates the subauthorities in a security identifier (SID). The subauthority values are relative identifiers (RID).</summary>
		/// <returns>A sequence of subauthorities.</returns>
		public IEnumerable<uint> SubAuthorities => ((PSID)this).GetSubAuthorities();

		/// <summary>Gets the string used to display in the debugger.</summary>
		internal string DebugString
		{
			get
			{
				if (IsInvalid || IsClosed) return "NULL";
				if (!IsValidSid) return "Invalid";
				var d = ToString("D");
				var n = ToString("P");
				return d == n ? $"({d})" : $"{n} ({d})";
			}
		}

		/// <summary>Creates a SID for predefined capability.</summary>
		/// <param name="capability">
		/// Member of the KnownSIDCapability enumeration that specifies which capability the SID will identify.
		/// </param>
		/// <returns>A <see cref="SafePSID"/> instance.</returns>
		public static SafePSID CreateCapability(KnownSIDCapability capability) =>
			Init(KnownSIDAuthority.SECURITY_APP_PACKAGE_AUTHORITY, KnownSIDRelativeID.SECURITY_CAPABILITY_BASE_RID, (int)capability);

		/// <summary>Copies the specified SID from a memory pointer to a <see cref="SafePSID"/> instance.</summary>
		/// <param name="psid">The SID pointer. This value remains the responsibility of the caller to release.</param>
		/// <returns>A <see cref="SafePSID"/> instance.</returns>
		public static SafePSID CreateFromPtr(IntPtr psid) => new((PSID)psid);

		/// <summary>Creates a SID for predefined aliases.</summary>
		/// <param name="WellKnownSidType">Member of the WELL_KNOWN_SID_TYPE enumeration that specifies what the SID will identify.</param>
		/// <param name="DomainSid">
		/// A pointer to a SID that identifies the domain to use when creating the SID. Pass <c>PSID.NULL</c> to use the local computer.
		/// </param>
		/// <returns>A <see cref="SafePSID"/> instance.</returns>
		public static SafePSID CreateWellKnown(WELL_KNOWN_SID_TYPE WellKnownSidType, PSID DomainSid = default)
		{
			var sz = 0U;
			CreateWellKnownSid(WellKnownSidType, DomainSid, Null, ref sz);
			if (sz == 0) Win32Error.ThrowLastError();
			SafePSID newSid = new((SizeT)sz);
			if (!CreateWellKnownSid(WellKnownSidType, DomainSid, newSid, ref sz))
				Win32Error.ThrowLastError();
			return newSid;
		}

		/// <summary>Extracts the user account SID associated with a security token.</summary>
		/// <param name="hToken">The security token handle.</param>
		/// <returns>A <see cref="SafePSID"/> instance of the user account SID associated with a security token.</returns>
		public static SafePSID FromToken(HTOKEN hToken)
		{
			using var hTok = new SafeHTOKEN((IntPtr)hToken, false);
			return hTok.GetInfo<TOKEN_USER>(TOKEN_INFORMATION_CLASS.TokenUser).User.Sid;
		}

		/// <summary>Performs an explicit conversion from <see cref="SafePSID"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="psid">The SafePSID instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(SafePSID psid) => psid.DangerousGetHandle();

		/// <summary>Performs an explicit conversion from <see cref="SafePSID"/> to <see cref="PSID"/>.</summary>
		/// <param name="psid">The SafePSID instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PSID(SafePSID psid) => psid.DangerousGetHandle();

		/// <summary>Performs an implicit conversion from <see cref="PSID"/> to <see cref="SafePSID"/>.</summary>
		/// <param name="psid">The psid.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafePSID(PSID psid) => new(psid);

		/// <summary>Initializes a new <see cref="SafePSID"/> instance from a SID authority and subauthorities.</summary>
		/// <param name="sidAuthority">The SID authority.</param>
		/// <param name="subAuth0">The first subauthority.</param>
		/// <param name="subAuthorities1to7">Up to seven other subauthorities.</param>
		/// <returns>A new <see cref="SafePSID"/> instance.</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		/// <paramref name="sidAuthority"/> is null or an invalid length or more than 8 total subauthorities were submitted.
		/// </exception>
		public static SafePSID Init(PSID_IDENTIFIER_AUTHORITY sidAuthority, int subAuth0, params int[] subAuthorities1to7)
		{
			if (sidAuthority is null)
				throw new ArgumentOutOfRangeException(nameof(sidAuthority));
			if (subAuthorities1to7.Length > 7)
				throw new ArgumentOutOfRangeException(nameof(subAuthorities1to7));
			AllocateAndInitializeSid(sidAuthority, (byte)(subAuthorities1to7.Length + 1),
				subAuth0,
				subAuthorities1to7.Length > 0 ? subAuthorities1to7[0] : 0,
				subAuthorities1to7.Length > 1 ? subAuthorities1to7[1] : 0,
				subAuthorities1to7.Length > 2 ? subAuthorities1to7[2] : 0,
				subAuthorities1to7.Length > 3 ? subAuthorities1to7[3] : 0,
				subAuthorities1to7.Length > 4 ? subAuthorities1to7[4] : 0,
				subAuthorities1to7.Length > 5 ? subAuthorities1to7[5] : 0,
				subAuthorities1to7.Length > 6 ? subAuthorities1to7[6] : 0,
				out var res);
			return new(res);
		}

		/// <summary>Implements the operator !=.</summary>
		/// <param name="psid1">The psid1.</param>
		/// <param name="psid2">The psid2.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(SafePSID psid1, SafePSID psid2) => !(psid1 == psid2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="psid1">The psid1.</param>
		/// <param name="psid2">The psid2.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(SafePSID psid1, SafePSID psid2)
		{
			if (ReferenceEquals(psid1, psid2)) return true;
			if (Equals(null, psid1) || Equals(null, psid2)) return false;
			return psid1.Equals(psid2);
		}

		/// <summary>Clones this instance.</summary>
		/// <returns>A copy of the current <see cref="SafePSID"/>.</returns>
		public SafePSID Clone() => CreateFromPtr(handle);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(SafePSID? other) => other is not null && (ReferenceEquals(this, other) || EqualSid(this, other));

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(PSID other) => Equals(other.DangerousGetHandle());

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(IntPtr other) => EqualSid(handle, other);

		/// <summary>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns>true if the specified <see cref="object"/> is equal to the current <see cref="object"/>; otherwise, false.</returns>
		public override bool Equals(object? obj) => obj switch
		{
			SafePSID psid2 => Equals(psid2),
			PSID psidh => Equals(psidh),
			IntPtr ptr => Equals(ptr),
			_ => false
		};

		/// <summary>Gets the binary form of this SafePSID.</summary>
		/// <returns>An array of bytes containing the Sid.</returns>
		public byte[] GetBinaryForm() => GetBytes(0, Size);

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => base.GetHashCode();

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => ToString(null);

		/// <summary>Converts the value of this security identifier (SID) to its equivalent string representation according to the provided format specifier.</summary>
		/// <param name="format">
		/// A single format specifier that indicates how to format the value of this security identifier (SID). The format parameter can be
		/// "B" (binary), "D" (sddl), "N" (name), or "P" (upn). If format is null or an empty string (""), "D" is used.
		/// </param>
		/// <returns>The value of this security identifier (SID), in the specified format.</returns>
		/// <exception cref="ArgumentException">SID value is not a valid SID. - pSid</exception>
		/// <exception cref="FormatException">The value of format is not null, an empty string (""), "B" (binary), "D" (sddl), "N" (name), or "P" (upn).</exception>
		/// <remarks>
		///   <para>The following table shows the accepted format specifiers for the format parameter.</para>
		///   <list type="table">
		///     <item>
		///       <description>Specifier</description>
		///       <description>Format of return value</description>
		///     </item>
		///     <item>
		///       <description>"B"</description>
		///       <description>
		///         <para>Binary hex dump representation of the SID.</para>
		///       </description>
		///     </item>
		///     <item>
		///       <description>"D"</description>
		///       <description>SDDL representation of the SID.</description>
		///     </item>
		///     <item>
		///       <description>"N"</description>
		///       <description>The NT4 style name (domain\username) corresponding to the SID.</description>
		///     </item>
		///     <item>
		///       <description>"P"</description>
		///       <description>The internet style name (UPN) corresponding to the SID.</description>
		///     </item>
		///   </list>
		/// </remarks>
		public string ToString(string? format)
		{
			try { return ((PSID)handle).ToString(format); }
			catch { return !IsInvalid && !IsClosed ? "Invalid" : "0"; }
		}

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		object ICloneable.Clone() => Clone();

		private static byte[] GetBytes(SecurityIdentifier si)
		{
			var b = new byte[si.BinaryLength];
			si.GetBinaryForm(b, 0);
			return b;
		}
	}

	/// <summary>Provides an array of SID pointers whose memory is disposed after use.</summary>
	/// <seealso cref="SafeHANDLE"/>
	/// <seealso cref="IReadOnlyList{T}"/>
	public class SafePSIDArray : SafeHANDLE, IReadOnlyList<PSID>
	{
		private List<SafePSID>? items;

		/// <summary>Initializes a new instance of the <see cref="SafePSIDArray"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="count">The count of PSID array values pointed to by <paramref name="preexistingHandle"/>.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not
		/// recommended). If <see langword="true"/>, the individually allocated values for each PSID will also be released.
		/// </param>
		public SafePSIDArray(IntPtr preexistingHandle, int count, bool ownsHandle = true) : base(preexistingHandle, ownsHandle)
		{
			if (ownsHandle)
				Count = count;
			else
				items = [.. handle.ToIEnum<IntPtr>(count).Select(p => new SafePSID((PSID)p))];
		}

		/// <summary>Initializes a new instance of the <see cref="SafePSIDArray"/> class.</summary>
		/// <param name="pSIDs">A list of <see cref="SafePSID"/> instances.</param>
		public SafePSIDArray(IEnumerable<SafePSID>? pSIDs) : this(pSIDs?.Select(p => (PSID)p) ?? [])
		{
		}

		/// <summary>Initializes a new instance of the <see cref="SafePSIDArray"/> class.</summary>
		/// <param name="pSIDs">A list of <see cref="SafePSID"/> instances.</param>
		public SafePSIDArray(IEnumerable<PSID> pSIDs) : base()
		{
			if (pSIDs is null) throw new ArgumentNullException(nameof(pSIDs));
			items = [.. pSIDs.Select(p => new SafePSID(p))];
			SetHandle(items.Select(p => (IntPtr)p).MarshalToPtr(i => LocalAlloc(LMEM.LPTR, i).DangerousGetHandle(), out _));
		}

		/// <summary>Initializes a new instance of the <see cref="SafePSIDArray"/> class.</summary>
		private SafePSIDArray() : base() { }

		/// <summary>Gets or sets the length of the array. This value must be set in order to interact with the elements.</summary>
		/// <value>The length.</value>
		public int Count
		{
			get => items?.Count ?? throw new InvalidOperationException("The length must be set before using this function.");
			set
			{
				if (items != null) throw new InvalidOperationException("The length can only be set for partially initialized arrays.");
				items = [];
				foreach (PSID psid in handle.ToIEnum<IntPtr>(value))
				{
					items.Add(new(psid));
					LocalFree((IntPtr)psid);
				}
			}
		}

		/// <summary>Gets the <see cref="PSID"/> at the specified index.</summary>
		/// <value>The <see cref="PSID"/>.</value>
		/// <param name="index">The index.</param>
		/// <returns>The PSID at the specified index.</returns>
		/// <exception cref="InvalidOperationException">The length must be set before using this function.</exception>
		public PSID this[int index] => items?[index] ?? throw new InvalidOperationException("The length must be set before using this function.");

		/// <summary>Performs an implicit conversion from <see cref="SafePSIDArray"/> to <see cref="PSID"/>[].</summary>
		/// <param name="a">The <see cref="SafePSIDArray"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PSID[](SafePSIDArray a) => [.. a.Enum()];

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="IEnumerator{PSID}"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<PSID> GetEnumerator() => Enum().GetEnumerator();

		/// <inheritdoc/>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle()
		{
			if (items != null)
				foreach (var p in items)
					p.Dispose();
			return LocalFree(handle) == HLOCAL.NULL;
		}

		private IEnumerable<PSID> Enum() => items?.Select(p => (PSID)p) ?? [];
	}
}

/// <summary>Extension methods for PSID instances.</summary>
public static class PSIDExtensions
{
	/// <summary>Determines equality of two PSID instances.</summary>
	/// <param name="psid1">The first PSID.</param>
	/// <param name="psid2">The second PSID.</param>
	/// <returns><see langword="true"/> if the SID structures are equal; <see langword="false"/> otherwise.</returns>
	public static bool Equals(this PSID psid1, PSID psid2) => AdvApi32.EqualSid(psid1, psid2);

	/// <summary>
	/// The <c>GetAuthority</c> function returns a pointer to the SID_IDENTIFIER_AUTHORITY structure in a specified security identifier (SID).
	/// </summary>
	/// <param name="pSid">
	/// <para>A pointer to the SID structure for which a pointer to the SID_IDENTIFIER_AUTHORITY structure is returned.</para>
	/// <para>
	/// This function does not handle SID structures that are not valid. Call the IsValidSid function to verify that the <c>SID</c>
	/// structure is valid before you call this function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a pointer to the SID_IDENTIFIER_AUTHORITY structure for the specified SID structure.
	/// </para>
	/// <para>
	/// If the function fails, the return value is undefined. The function fails if the SID structure pointed to by the pSid parameter
	/// is not valid. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// This function uses a 32-bit RID value. For applications that require a larger RID value, use CreateWellKnownSid and related functions.
	/// </remarks>
	public static AdvApi32.PSID_IDENTIFIER_AUTHORITY GetAuthority(this PSID pSid) => AdvApi32.GetSidIdentifierAuthority(pSid);

	/// <summary>Gets the binary form of the SID structure.</summary>
	/// <param name="pSid">The SID structure pointer.</param>
	/// <returns>The binary form (byte array) of the SID structure.</returns>
	public static byte[] GetBinaryForm(this PSID pSid) => (pSid.IsValidSid() ? ((IntPtr)pSid).ToByteArray(pSid.Length()) : null) ?? [];

	/// <summary>
	/// The <c>GetDomainSid</c> function receives a security identifier (SID) and returns a SID representing the domain of that SID.
	/// </summary>
	/// <param name="pSid">A pointer to the SID to examine.</param>
	/// <returns>An allocated safe pointer to a SID representing the domain.</returns>
	public static AdvApi32.SafePSID GetDomainSid(this PSID pSid)
	{
		Win32Error.ThrowLastErrorIfFalse(AdvApi32.GetWindowsAccountDomainSid(pSid, out var pDomSid));
		return pDomSid;
	}

	/// <summary>Enumerates the subauthorities in a security identifier (SID). The subauthority values are relative identifiers (RID).</summary>
	/// <param name="pSid">A pointer to the SID structure from which a pointer to a subauthority is to be returned.</param>
	/// <returns>A sequence of subauthorities.</returns>
	public static IEnumerable<uint> GetSubAuthorities(this PSID pSid)
	{
		for (uint i = 0; i < AdvApi32.GetSidSubAuthorityCount(pSid); i++)
			yield return AdvApi32.GetSidSubAuthority(pSid, i);
	}

	/// <summary>
	/// Validates a security identifier (SID) by verifying that the revision number is within a known range, and that the number of
	/// subauthorities is less than the maximum.
	/// </summary>
	/// <param name="pSid">A pointer to the SID structure to validate. This parameter cannot be NULL.</param>
	/// <returns>
	/// If the SID structure is valid, the return value is <see langword="true"/>. If the SID structure is not valid, the return value is <see langword="false"/>.
	/// </returns>
	public static bool IsValidSid(this PSID pSid) => AdvApi32.IsValidSid(pSid);

	/// <summary>Returns the length, in bytes, of a valid security identifier (SID).</summary>
	/// <param name="pSid">A pointer to the SID structure whose length is returned. The structure is assumed to be valid.</param>
	/// <returns>
	/// If the SID structure is valid, the return value is the length, in bytes, of the SID structure. If the SID structure is not valid,
	/// the return value is 0.
	/// </returns>
	public static int Length(this PSID pSid) => AdvApi32.IsValidSid(pSid) ? AdvApi32.GetLengthSid(pSid) : 0;

	/// <summary>Converts the value of a security identifier (SID) to its equivalent string representation according to the provided format specifier.</summary>
	/// <param name="pSid">A pointer to a valid SID structure.</param>
	/// <param name="format">
	/// A single format specifier that indicates how to format the value of this security identifier (SID). The format parameter can be
	/// "B" (binary), "D" (sddl), "N" (name), or "P" (upn). If format is null or an empty string (""), "D" is used.
	/// </param>
	/// <returns>The value of this security identifier (SID), in the specified format.</returns>
	/// <exception cref="ArgumentException">SID value is not a valid SID. - pSid</exception>
	/// <exception cref="FormatException">The value of format is not null, an empty string (""), "B", "D", "N", or "P".</exception>
	/// <remarks>
	///   <para>The following table shows the accepted format specifiers for the format parameter.</para>
	///   <list type="table">
	///     <item>
	///       <description>Specifier</description>
	///       <description>Format of return value</description>
	///     </item>
	///     <item>
	///       <description>"B"</description>
	///       <description>
	///         <para>Binary hex dump representation of the SID.</para>
	///       </description>
	///     </item>
	///     <item>
	///       <description>"D"</description>
	///       <description>SDDL representation of the SID.</description>
	///     </item>
	///     <item>
	///       <description>"N"</description>
	///       <description>The NT4 style name (domain\username) corresponding to the SID.</description>
	///     </item>
	///     <item>
	///       <description>"P"</description>
	///       <description>The internet style name (UPN) corresponding to the SID.</description>
	///     </item>
	///   </list>
	/// </remarks>
	public static string ToString(this PSID pSid, string? format)
	{
		if (!pSid.IsValidSid())
			throw new ArgumentException("SID value is not a valid SID.", nameof(pSid));
		switch (format)
		{
			case "B":
				var len = pSid.Length();
				return pSid.GetBinaryForm().ToHexDumpString(len, len, 0).Trim(' ', '\r', '\n');

			case "D":
			case null:
			case "":
				try { return AdvApi32.ConvertSidToStringSid(pSid); }
				catch { goto case "B"; }

			case "N":
			case "P":
				using (var hPol = AdvApi32.LsaOpenPolicy(AdvApi32.LsaPolicyRights.POLICY_LOOKUP_NAMES))
				{
					var flag = format == "P" ? AdvApi32.LsaLookupSidsFlags.LSA_LOOKUP_PREFER_INTERNET_NAMES : 0;
					try
					{
						AdvApi32.LsaLookupSids2(hPol, flag, 1, [pSid], out var memDoms, out var memNames).ThrowIfFailed();
						memDoms.Dispose();
						using (memNames)
						{
							return memNames.ToStructure<AdvApi32.LSA_TRANSLATED_NAME>().Name;
						}
					}
					catch (Exception)
					{
						goto case "D";
					}
				}

			default:
				throw new FormatException();
		}
	}
}