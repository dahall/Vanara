using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

//using static Vanara.Shell32.PIDLUtil;
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Represents a managed pointer to an ITEMIDLIST.
		/// </summary>
		/// <seealso cref="SafeHandleZeroOrMinusOneIsInvalid" />
		/// <seealso cref="System.Collections.Generic.IEnumerable{PIDL}" />
		[PInvokeData("Shtypes.h", MSDNShortId = "bb773321")]
		public class PIDL : SafeHandleZeroOrMinusOneIsInvalid, IEnumerable<PIDL>, IEquatable<PIDL>, IEquatable<IntPtr>
		{
			/// <summary>Initializes a new instance of the <see cref="PIDL"/> class.</summary>
			/// <param name="pidl">The raw pointer to a native ITEMIDLIST.</param>
			/// <param name="clone">if set to <c>true</c> clone the list before storing it.</param>
			/// <param name="own">if set to <c>true</c><see cref="PIDL"/> will release the memory associated with the ITEMIDLIST when done.</param>
			public PIDL(IntPtr pidl, bool clone = false, bool own = true) : base(clone || own)
			{
				SetHandle(clone ? IntILClone(pidl) : pidl);
			}

			/// <summary>Initializes a new instance of the <see cref="PIDL"/> class.</summary>
			/// <param name="pidl">An existing <see cref="PIDL"/> that will be copied and managed.</param>
			public PIDL(PIDL pidl) : this(pidl.handle, true) { }

			/// <summary>Initializes a new instance of the <see cref="PIDL"/> class from a file path.</summary>
			/// <param name="path">A string that contains the path.</param>
			public PIDL(string path) : base(true)
			{
				SetHandle(IntILCreateFromPath(path));
			}

			/// <summary>Initializes a new instance of the <see cref="PIDL"/> class.</summary>
			internal PIDL() : base(true) { }

			/// <summary>Gets a value indicating whether this list is empty.</summary>
			/// <value><c>true</c> if this list is empty; otherwise, <c>false</c>.</value>
			public bool IsEmpty => ILIsEmpty(handle);

			/// <summary>Gets the last SHITEMID in this ITEMIDLIST.</summary>
			/// <value>The last SHITEMID.</value>
			public PIDL LastId => ILFindLastID(handle);

			/// <summary>Gets a value representing a NULL PIDL.</summary>
			/// <value>The null equivalent.</value>
			public static PIDL Null { get; } = new PIDL();

			/// <summary>Performs an explicit conversion from <see cref="PIDL"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="pidl">The current <see cref="PIDL"/>.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(PIDL pidl) => pidl.handle;

			/// <summary>Appends the specified <see cref="PIDL"/> to the existing list.</summary>
			/// <param name="appendPidl">The <see cref="PIDL"/> to append.</param>
			public void Append(PIDL appendPidl)
			{
				var newPidl = IntILCombine(handle, appendPidl.DangerousGetHandle());
				Marshal.FreeCoTaskMem(handle);
				SetHandle(newPidl);
			}

			/// <summary>Combines the specified <see cref="PIDL"/> instances to create a new one.</summary>
			/// <param name="firstPidl">The first <see cref="PIDL"/>.</param>
			/// <param name="secondPidl">The second <see cref="PIDL"/>.</param>
			/// <returns>A managed <see cref="PIDL"/> instance that contains both supplied lists in their respective order.</returns>
			public static PIDL Combine(PIDL firstPidl, PIDL secondPidl) => ILCombine(firstPidl.handle, secondPidl.handle);

			/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
			/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
			/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
			public override bool Equals(object obj)
			{
				switch (obj)
				{
					case null:
						return IsEmpty;
					case PIDL pidl:
						return Equals(pidl);
					case IntPtr ptr:
						return Equals(ptr);
					default:
						return base.Equals(obj);
				}
			}

			/// <summary>
			/// Indicates whether the current object is equal to another object of the same type.
			/// </summary>
			/// <param name="other">An object to compare with this object.</param>
			/// <returns>
			/// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
			/// </returns>
			public bool Equals(IntPtr other) => ILIsEqual(handle, other);

			/// <summary>
			/// Indicates whether the current object is equal to another object of the same type.
			/// </summary>
			/// <param name="other">An object to compare with this object.</param>
			/// <returns>
			/// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
			/// </returns>
			public bool Equals(PIDL other) => Equals(other?.handle ?? IntPtr.Zero);

			//public static bool operator ==(PIDL a, PIDL b) => (a == null && b == null) || (a?.Equals(b) ?? false);

			//public static bool operator !=(PIDL a, PIDL b) => !(a == b);

			/// <summary>Returns an enumerator that iterates through the collection.</summary>
			/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator{PIDL}"/> that can be used to iterate through the collection.</returns>
			public IEnumerator<PIDL> GetEnumerator() => new InternalEnumerator(handle);

			/// <summary>Returns an enumerator that iterates through a collection.</summary>
			/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

			// ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode() => base.GetHashCode();

			/// <summary>Inserts the specified <see cref="PIDL"/> before the existing list.</summary>
			/// <param name="insertPidl">The <see cref="PIDL"/> to insert.</param>
			public void Insert(PIDL insertPidl)
			{
				var newPidl = IntILCombine(insertPidl.handle, handle);
				Marshal.FreeCoTaskMem(handle);
				SetHandle(newPidl);
			}

			/// <summary>
			/// Removes the last identifier from the list.
			/// </summary>
			public bool RemoveLastId() => ILRemoveLastID(handle);

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString() => ToString(SIGDN.SIGDN_NORMALDISPLAY);

			/// <summary>Returns a <see cref="System.String"/> that represents this instance base according to the format provided by <paramref name="displayNameFormat"/>.</summary>
			/// <param name="displayNameFormat">The desired display name format.</param>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public string ToString(SIGDN displayNameFormat)
			{
				try
				{
					SHGetNameFromIDList(this, displayNameFormat, out SafeCoTaskMemHandle name);
					return name.ToString(-1);
				}
				catch (Exception ex) { Debug.WriteLine($"Error: PIDL:ToString = {ex}"); }
				return null;
			}

			/// <summary>Dumps this instance to a string a list of binary values.</summary>
			/// <returns>A binary string of the contents.</returns>
			public string Dump()
			{
				var sb = new StringBuilder();
				foreach (var pidl in this)
				{
					var sz = ILGetItemSize(pidl.handle);
					var bytes = pidl.handle.ToIEnum<byte>(sz);
					sb.AppendLine(string.Join(" ", bytes.Select(b => $"{b:X2}").ToArray()));
				}
				return sb.ToString();
			}

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PIDL"/>.</summary>
			/// <param name="p">The pointer to a raw ITEMIDLIST.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator PIDL(IntPtr p) => new PIDL(p);

			/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
			/// <returns>
			/// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it generates a
			/// releaseHandleFailed MDA Managed Debugging Assistant.
			/// </returns>
			protected override bool ReleaseHandle()
			{
				try { Marshal.FreeCoTaskMem(handle); } catch { }
				handle = IntPtr.Zero;
				return true;
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

				public PIDL Current => currentPidl == IntPtr.Zero ? null : ILCloneFirst(currentPidl);

				object IEnumerator.Current => Current;

				public void Dispose() { }

				public bool MoveNext()
				{
					if (start)
					{
						start = false;
						currentPidl = pidl;
						return true;
					}

					var newPidl = ILNext(currentPidl);
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
}