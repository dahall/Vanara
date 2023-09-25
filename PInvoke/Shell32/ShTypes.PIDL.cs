#pragma warning disable IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Represents a managed pointer to an ITEMIDLIST.</summary>
	[PInvokeData("Shtypes.h", MSDNShortId = "bb773321")]
	[DebuggerDisplay("[{ToString()}]")]
	public class PIDL : SafeHANDLE, IEnumerable<PIDL>, IEquatable<PIDL>, IEquatable<IntPtr>
	{
		/// <summary>Initializes a new instance of the <see cref="PIDL"/> class.</summary>
		/// <param name="pidl">The raw pointer to a native ITEMIDLIST.</param>
		/// <param name="clone">if set to <c>true</c> clone the list before storing it.</param>
		/// <param name="own">if set to <c>true</c><see cref="PIDL"/> will release the memory associated with the ITEMIDLIST when done.</param>
		public PIDL(IntPtr pidl, bool clone = false, bool own = true) : base(clone ? IntILClone(pidl) : pidl, clone || own) { }

		/// <summary>Initializes a new instance of the <see cref="PIDL"/> class.</summary>
		/// <param name="pidl">An existing <see cref="PIDL"/> that will be copied and managed.</param>
		public PIDL(PIDL pidl) : this(pidl.handle, true) { }

		/// <summary>Initializes a new instance of the <see cref="PIDL"/> class from a file path.</summary>
		/// <param name="path">A string that contains the path.</param>
		public PIDL(string path) : this(IntILCreateFromPath(path)) { }

		/// <summary>Initializes a new instance of the <see cref="PIDL"/> class from an array of bytes.</summary>
		/// <param name="bytes">The bytes.</param>
		public PIDL(byte[] bytes) { using var p = new PinnedObject(bytes); SetHandle(IntILClone(p)); }

		/// <summary>Initializes a new instance of the <see cref="PIDL"/> class from a stream holding an absolute ITEMIDLIST.</summary>
		/// <param name="stream">The stream interface instance from which the ITEMIDLIST loads.</param>
		public PIDL(System.Runtime.InteropServices.ComTypes.IStream stream)
		{
			ILLoadFromStreamEx(stream, out PIDL p).ThrowIfFailed();
			SetHandle(p.ReleaseOwnership());
		}

		/// <summary>Initializes a new instance of the <see cref="PIDL"/> class.</summary>
		internal PIDL() { }

		/// <summary>Gets a value representing a NULL PIDL.</summary>
		/// <value>The null equivalent.</value>
		public static PIDL Null { get; } = new PIDL();

		/// <summary>Gets a value indicating whether this list is empty.</summary>
		/// <value><c>true</c> if this list is empty; otherwise, <c>false</c>.</value>
		public bool IsEmpty => ILIsEmpty(handle);

		/// <summary>Gets the last SHITEMID in this ITEMIDLIST.</summary>
		/// <value>The last SHITEMID.</value>
		public PIDL LastId => new(ILFindLastID(handle), true);

		/// <summary>Gets an ITEMIDLIST with the last ID removed. If this is the topmost ID, a clone of the current is returned.</summary>
		public PIDL Parent
		{
			get
			{
				var p = new PIDL(this);
				p.RemoveLastId();
				return p;
			}
		}

		/// <summary>Gets the size, in bytes, of the ITEMIDLIST.</summary>
		public uint Size => ILGetSize(handle);

		/// <summary>Combines the specified <see cref="PIDL"/> instances to create a new one.</summary>
		/// <param name="firstPidl">The first <see cref="PIDL"/>.</param>
		/// <param name="secondPidl">The second <see cref="PIDL"/>.</param>
		/// <returns>A managed <see cref="PIDL"/> instance that contains both supplied lists in their respective order.</returns>
		public static PIDL Combine(PIDL firstPidl, PIDL secondPidl) => ILCombine(firstPidl.handle, secondPidl.handle);

		/// <summary>Performs an explicit conversion from <see cref="PIDL"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="pidl">The current <see cref="PIDL"/>.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(PIDL pidl) => pidl.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PIDL"/>.</summary>
		/// <param name="p">The pointer to a raw ITEMIDLIST.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PIDL(IntPtr p) => new(p);

		/// <summary>Combines the specified <see cref="PIDL"/> instances to create a new one.</summary>
		/// <param name="first">The first <see cref="PIDL"/>.</param>
		/// <param name="second">The second <see cref="PIDL"/>.</param>
		/// <returns>A managed <see cref="PIDL"/> instance that contains both supplied lists in their respective order.</returns>
		public static PIDL operator +(PIDL first, PIDL second) => Combine(first, second);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="first">The first <see cref="PIDL"/>.</param>
		/// <param name="second">The second <see cref="PIDL"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(PIDL first, PIDL second) => first?.Equals(second) ?? second is null;

		/// <summary>Implements the operator !=.</summary>
		/// <param name="first">The first <see cref="PIDL"/>.</param>
		/// <param name="second">The second <see cref="PIDL"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(PIDL first, PIDL second) => !(first == second);

		/// <summary>Appends the specified <see cref="PIDL"/> to the existing list.</summary>
		/// <param name="appendPidl">The <see cref="PIDL"/> to append.</param>
		public void Append(PIDL appendPidl) => UpdateHandle(IntILCombine(handle, appendPidl.DangerousGetHandle()));

		/// <summary>Dumps this instance to a string a list of binary values.</summary>
		/// <returns>A binary string of the contents.</returns>
		public string Dump() => string.Join(" ", handle.ToIEnum<byte>((int)Size).Select(b => $"{b:X2}").ToArray());

		/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object? obj) => obj switch
		{
			null => IsEmpty,
			PIDL pidl => Equals(pidl),
			IntPtr ptr => Equals(ptr),
			_ => base.Equals(obj),
		};

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(IntPtr other) => ILIsEqual(handle, other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(PIDL? other) => ReferenceEquals(this, other) || Equals(other?.handle ?? IntPtr.Zero);

		/// <summary>Gets the ID list as an array of bytes.</summary>
		/// <returns>An array of bytes representing the ID list.</returns>
		public byte[] GetBytes() => handle.ToByteArray((int)Size) ?? new byte[0];

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator{PIDL}"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<PIDL> GetEnumerator() => new InternalEnumerator(handle);

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => new Vanara.Collections.EnumerableEqualityComparer<byte>().GetHashCode(handle.ToIEnum<byte>((int)Size));

		/// <summary>Inserts the specified <see cref="PIDL"/> before the existing list.</summary>
		/// <param name="insertPidl">The <see cref="PIDL"/> to insert.</param>
		public void Insert(PIDL insertPidl) => UpdateHandle(IntILCombine(insertPidl.handle, handle));

		/// <summary>Determines if this instance is a parent or ancestor of a supplied PIDL.</summary>
		/// <param name="childPidl">Child instance to test.</param>
		/// <param name="immediate">If <c>true</c>, narrows test to immediate children only.</param>
		/// <returns><c>true</c> if this instance is a parent or ancestor of a supplied PIDL.</returns>
		public bool IsParentOf(PIDL childPidl, bool immediate = true) => ILIsParent((IntPtr)this, (IntPtr)childPidl, immediate);

		/// <summary>Removes the last identifier from the list.</summary>
		public bool RemoveLastId() => ILRemoveLastID(handle);

		/// <summary>Saves an ITEMIDLIST structure to a stream.</summary>
		/// <param name="stream">An IStream instance where the ITEMIDLIST is saved.</param>
		/// <remarks>The stream must be opened for writing, or <see cref="SaveToStream"/> returns an error.</remarks>
		public void SaveToStream(System.Runtime.InteropServices.ComTypes.IStream stream) => ILSaveToStream(stream, new(handle, false, false)).ThrowIfFailed();

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => ToString(SIGDN.SIGDN_NORMALDISPLAY);

		/// <summary>
		/// Returns a <see cref="string"/> that represents this instance base according to the format provided by <paramref name="displayNameFormat"/>.
		/// </summary>
		/// <param name="displayNameFormat">The desired display name format.</param>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public string ToString(SIGDN displayNameFormat)
		{
			try
			{
				SHGetNameFromIDList(this, displayNameFormat, out var name).ThrowIfFailed();
				return name!;
			}
			catch (Exception ex) { Debug.WriteLine($"Error: PIDL:ToString = {ex}"); }
			return string.Empty;
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>
		/// Internal method that actually releases the handle. This is called by <see cref="M:Vanara.PInvoke.SafeHANDLE.ReleaseHandle"/>
		/// for valid handles and afterwards zeros the handle.
		/// </summary>
		/// <returns><c>true</c> to indicate successful release of the handle; <c>false</c> otherwise.</returns>
		protected override bool InternalReleaseHandle()
		{
			ILFree(handle);
			return true;
		}

		/// <summary>Updates the handle after freeing the existing handle.</summary>
		/// <param name="newHandle">The new handle.</param>
		protected virtual void UpdateHandle(IntPtr newHandle)
		{
			ILFree(handle);
			SetHandle(newHandle);
		}

		private class InternalEnumerator : IEnumerator<PIDL>
		{
			private readonly IntPtr pidl;
			private IntPtr currentPidl;
			private bool start;

			public InternalEnumerator(IntPtr handle)
			{
				start = true;
				pidl = handle;
				currentPidl = IntPtr.Zero;
			}

			public PIDL Current => currentPidl == IntPtr.Zero ? PIDL.Null : ILCloneFirst(currentPidl);

			object IEnumerator.Current => Current;

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (start)
				{
					start = false;
					currentPidl = pidl;
					return true;
				}

				IntPtr newPidl = ILNext(currentPidl);
				if (ILIsEmpty(newPidl)) return false;
				currentPidl = newPidl;
				return true;
			}

			public void Reset()
			{
				start = true;
				currentPidl = IntPtr.Zero;
			}
		}
	}
}