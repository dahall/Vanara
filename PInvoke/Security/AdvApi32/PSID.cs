using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>Class representation of the native SID structure.</summary>
		/// <seealso cref="SafeHGlobalHandle"/>
		public class SafePSID : SafeMemoryHandle<LocalMemoryMethods>, IEquatable<SafePSID>, IEquatable<PSID>, IEquatable<IntPtr>, ICloneable, ISecurityObject
		{
			/// <summary>Equivalent to a NULL pointer to a SID.</summary>
			public static readonly SafePSID Null = new SafePSID(0);

			/// <summary>Initializes a new instance of the <see cref="SafePSID"/> class.</summary>
			/// <param name="psid">The existing <see cref="SafePSID"/> instance to duplicate.</param>
			public SafePSID(PSID psid) : base(psid.IsNull ? 0 : GetLengthSid(psid)) { if (!psid.IsNull) CopySid(Size, handle, psid); }

			/// <summary>Initializes a new instance of the <see cref="SafePSID"/> class.</summary>
			/// <param name="size">The size of memory to allocate, in bytes.</param>
			public SafePSID(int size) : base(size)
			{
			}

			/// <summary>Initializes a new instance of the <see cref="SafePSID"/> class.</summary>
			/// <param name="sidBytes">An array of bytes that contain a valid Sid.</param>
			public SafePSID(byte[] sidBytes) : base(sidBytes?.Length ?? 0) => Marshal.Copy(sidBytes, 0, handle, Size);

			/// <summary>Initializes a new instance of the <see cref="SafePSID"/> class.</summary>
			/// <param name="sidValue">The string SID value.</param>
			public SafePSID(string sidValue) : this(ConvertStringSidToSid(sidValue))
			{
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="SafePSID"/> class from a
			/// <see cref="System.Security.Principal.SecurityIdentifier"/> instance.
			/// </summary>
			/// <param name="si">The <see cref="System.Security.Principal.SecurityIdentifier"/> instance.</param>
			public SafePSID(System.Security.Principal.SecurityIdentifier si) : this(si is null ? null : GetBytes(si))
			{
			}

			/// <summary>Initializes a new instance of the <see cref="SafePSID"/> class.</summary>
			private SafePSID() : base() { }

			/// <summary>Gets the SID for the current user</summary>
			/// <value>The current user's SID.</value>
			public static SafePSID Current => new SafePSID(System.Security.Principal.WindowsIdentity.GetCurrent().User);

			/// <summary>A SID representing the Everyone Group (S-1-1-0).</summary>
			public static SafePSID Everyone => CreateWellKnown(WELL_KNOWN_SID_TYPE.WinWorldSid);

			/// <summary>
			/// Verifies that the revision number is within a known range, and that the number of subauthorities is less than the maximum.
			/// </summary>
			/// <value><c>true</c> if this instance is a valid SID; otherwise, <c>false</c>.</value>
			public bool IsValidSid => IsValidSid(this);

			/// <summary>Copies the specified SID from a memory pointer to a <see cref="SafePSID"/> instance.</summary>
			/// <param name="psid">The SID pointer. This value remains the responsibility of the caller to release.</param>
			/// <returns>A <see cref="SafePSID"/> instance.</returns>
			public static SafePSID CreateFromPtr(IntPtr psid) => new SafePSID(psid);

			/// <summary>Creates a SID for predefined aliases.</summary>
			/// <param name="WellKnownSidType">Member of the WELL_KNOWN_SID_TYPE enumeration that specifies what the SID will identify.</param>
			/// <param name="DomainSid">
			/// A pointer to a SID that identifies the domain to use when creating the SID. Pass <c>PSID.NULL</c> to use the local computer.
			/// </param>
			/// <returns>A <see cref="SafePSID"/> instance.</returns>
			public static SafePSID CreateWellKnown(WELL_KNOWN_SID_TYPE sidType, PSID domainSid = default)
			{
				var sz = 0U;
				CreateWellKnownSid(sidType, domainSid, Null, ref sz);
				if (sz == 0) Win32Error.ThrowLastError();
				var newSid = new SafePSID((int)sz);
				if (!CreateWellKnownSid(sidType, domainSid, newSid, ref sz))
					Win32Error.ThrowLastError();
				return newSid;
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
			public static implicit operator SafePSID(PSID psid) => new SafePSID(psid);

			/// <summary>Initializes a new <see cref="SafePSID"/> instance from a SID authority and subauthorities.</summary>
			/// <param name="sidAuthority">The SID authority.</param>
			/// <param name="subAuth0">The first subauthority.</param>
			/// <param name="subAuthorities1to7">Up to seven other subauthorities.</param>
			/// <returns>A new <see cref="SafePSID"/> instance.</returns>
			/// <exception cref="System.ArgumentOutOfRangeException">
			/// <paramref name="sidAuthority"/> is null or an invalid length or more than 8 total subauthorities were submitted.
			/// </exception>
			public static SafePSID Init(PSID_IDENTIFIER_AUTHORITY sidAuthority, int subAuth0, params int[] subAuthorities1to7)
			{
				if (sidAuthority == null)
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
				return new SafePSID(res);
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
			public bool Equals(SafePSID other) => EqualSid(this, other);

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
			public override bool Equals(object obj)
			{
				if (obj is SafePSID psid2)
					return Equals(psid2);
				if (obj is PSID psidh)
					return Equals(psidh);
				if (obj is IntPtr ptr)
					return Equals(ptr);
				return false;
			}

			/// <summary>Gets the binary form of this SafePSID.</summary>
			/// <returns>An array of bytes containing the Sid.</returns>
			public byte[] GetBinaryForm() => GetBytes(0, Size);

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode() => base.GetHashCode();

			/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
			/// <returns>A <see cref="string"/> that represents this instance.</returns>
			public override string ToString()
			{
				try { return ConvertSidToStringSid(this); }
				catch { return !IsInvalid && !IsClosed ? "Invalid" : "0"; }
			}

			/// <summary>Creates a new object that is a copy of the current instance.</summary>
			/// <returns>A new object that is a copy of this instance.</returns>
			object ICloneable.Clone() => Clone();

			private static byte[] GetBytes(System.Security.Principal.SecurityIdentifier si)
			{
				var b = new byte[si.BinaryLength];
				si.GetBinaryForm(b, 0);
				return b;
			}
		}

		/// <summary>Provides an array of SID pointers whose memory is disposed after use.</summary>
		/// <seealso cref="Vanara.PInvoke.SafeHANDLE"/>
		/// <seealso cref="System.Collections.Generic.IReadOnlyList{Vanara.PInvoke.PSID}"/>
		public class SafePSIDArray : SafeHANDLE, IReadOnlyList<PSID>
		{
			private List<SafePSID> items;

			/// <summary>Initializes a new instance of the <see cref="SafePSIDArray"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafePSIDArray(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafePSIDArray"/> class.</summary>
			/// <param name="pSIDs">A list of <see cref="SafePSID"/> instances.</param>
			public SafePSIDArray(IEnumerable<SafePSID> pSIDs) : this(pSIDs.Select(p => (PSID)p))
			{
			}

			/// <summary>Initializes a new instance of the <see cref="SafePSIDArray"/> class.</summary>
			/// <param name="pSIDs">A list of <see cref="SafePSID"/> instances.</param>
			public SafePSIDArray(IEnumerable<PSID> pSIDs) : base()
			{
				items = pSIDs.Select(p => new SafePSID(p)).ToList();
				SetHandle(items.Cast<IntPtr>().MarshalToPtr(i => LocalAlloc(LMEM.LPTR, i).DangerousGetHandle(), out _));
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
					if (items != null) throw new InvalidOperationException("The length can only be set once.");
					items = new List<SafePSID>(handle.ToIEnum<IntPtr>(value).Select(p => new SafePSID(p)));
				}
			}

			/// <summary>Gets the <see cref="PSID"/> at the specified index.</summary>
			/// <value>The <see cref="PSID"/>.</value>
			/// <param name="index">The index.</param>
			/// <returns>The PSID at the specified index.</returns>
			/// <exception cref="InvalidOperationException">The length must be set before using this function.</exception>
			public PSID this[int index] => items?[index] ?? throw new InvalidOperationException("The length must be set before using this function.");

			/// <summary>Performs an implicit conversion from <see cref="SafePSIDArray"/> to <see cref="PSID[]"/>.</summary>
			/// <param name="a">The <see cref="SafePSIDArray"/> instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator PSID[](SafePSIDArray a) => a.items.ConvertAll(p => (PSID)p).ToArray();

			/// <summary>Returns an enumerator that iterates through the collection.</summary>
			/// <returns>A <see cref="IEnumerator{PSID}"/> that can be used to iterate through the collection.</returns>
			public IEnumerator<PSID> GetEnumerator() => items.ConvertAll(p => (PSID)p).GetEnumerator();

			/// <inheritdoc/>
			IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<SafePSID>)items).GetEnumerator();

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle()
			{
				if (items != null)
					foreach (var p in items)
						p.Dispose();
				return LocalFree(handle) == HLOCAL.NULL;
			}
		}
	}
}