using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Macros;

namespace Vanara.PInvoke
{
	/// <summary>Predefined resource types.</summary>
	[PInvokeData("winuser.h")]
	public enum ResourceType : ushort
	{
		/// <summary>Accelerator table.</summary>
		RT_ACCELERATOR = 9,

		/// <summary>Animated cursor.</summary>
		RT_ANICURSOR = 21,

		/// <summary>Animated icon.</summary>
		RT_ANIICON = 22,

		/// <summary>Bitmap resource.</summary>
		RT_BITMAP = 2,

		/// <summary>Hardware-dependent cursor resource.</summary>
		RT_CURSOR = 1,

		/// <summary>Dialog box.</summary>
		RT_DIALOG = 5,

		/// <summary>
		/// Allows a resource editing tool to associate a string with an .rc file. Typically, the string is the name of the header file that
		/// provides symbolic names. The resource compiler parses the string but otherwise ignores the value.
		/// </summary>
		RT_DLGINCLUDE = 17,

		/// <summary>Font resource.</summary>
		RT_FONT = 8,

		/// <summary>Font directory resource.</summary>
		RT_FONTDIR = 7,

		/// <summary>Hardware-independent cursor resource.</summary>
		RT_GROUP_CURSOR = 12,

		/// <summary>Hardware-independent icon resource.</summary>
		RT_GROUP_ICON = 14,

		/// <summary>HTML resource.</summary>
		RT_HTML = 23,

		/// <summary>Hardware-dependent icon resource.</summary>
		RT_ICON = 3,

		/// <summary>Side-by-Side Assembly Manifest.</summary>
		RT_MANIFEST = 24,

		/// <summary>Menu resource.</summary>
		RT_MENU = 4,

		/// <summary>Message-table entry.</summary>
		RT_MESSAGETABLE = 11,

		/// <summary>Plug and Play resource.</summary>
		RT_PLUGPLAY = 19,

		/// <summary>Application-defined resource (raw data).</summary>
		RT_RCDATA = 10,

		/// <summary>String-table entry.</summary>
		RT_STRING = 6,

		/// <summary>Version resource.</summary>
		RT_VERSION = 16,

		/// <summary>VXD.</summary>
		RT_VXD = 20,
	}

	/// <summary>Helper structure to use for a pointer that can morph into a string, pointer or integer.</summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h")]
	public struct ResourceId : IEquatable<string>, IEquatable<IntPtr>, IEquatable<int>, IEquatable<ResourceId>, IHandle
	{
		private IntPtr ptr;

		/// <summary>Gets or sets an integer identifier.</summary>
		/// <value>The identifier.</value>
		public int id
		{
			get => IS_INTRESOURCE(ptr) ? (ushort)ptr.ToInt32() : 0;
			set
			{
				if (value > ushort.MaxValue || value <= 0) throw new ArgumentOutOfRangeException(nameof(id));
				ptr = (IntPtr)(ushort)value;
			}
		}

		/// <summary>Represent a NULL value.</summary>
		public static readonly ResourceId NULL = new ResourceId();

		/// <summary>Performs an implicit conversion from <see cref="SafeResourceId"/> to <see cref="System.Int32"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator int(ResourceId r) => r.id;

		/// <summary>Performs an implicit conversion from <see cref="ResourceId"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator IntPtr(ResourceId r) => r.ptr;

		/// <summary>Performs an implicit conversion from <see cref="int"/> to <see cref="ResourceId"/>.</summary>
		/// <param name="resId">The resource identifier.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ResourceId(int resId) => new ResourceId { id = resId };

		/// <summary>Performs an implicit conversion from <see cref="ResourceType"/> to <see cref="ResourceId"/>.</summary>
		/// <param name="resType">Type of the resource.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ResourceId(ResourceType resType) => new ResourceId { id = (int)resType };

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="ResourceId"/>.</summary>
		/// <param name="p">The PTR.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ResourceId(IntPtr p) => new ResourceId { ptr = p };

		/// <summary>Performs an implicit conversion from <see cref="ResourceId"/> to <see cref="string"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator string(ResourceId r) => r.ToString();

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			switch (obj)
			{
				case null:
					return false;

				case string s:
					return Equals(s);

				case int i:
					return Equals(i);

				case IntPtr p:
					return Equals(p);

				case ResourceId r:
					return Equals(r);

				case IHandle h:
					return Equals(h.DangerousGetHandle());

				default:
					if (!obj.GetType().IsPrimitive) return false;
					try { return Equals(Convert.ToInt32(obj)); } catch { return false; }
			}
		}

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => ptr.GetHashCode();

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => IS_INTRESOURCE(ptr) ? $"#{ptr.ToInt32()}" : Marshal.PtrToStringAuto(ptr);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(int other) => ptr.ToInt32().Equals(other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public bool Equals(string other) => string.Equals(ToString(), other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(IntPtr other) => ptr.Equals(other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public bool Equals(ResourceId other) => string.Equals(other.ToString(), ToString());

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => ptr;
	}

	/// <summary>Helper structure to use for a pointer that can morph into a string, handle or integer.</summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h")]
	public struct ResourceIdOrHandle<THandle> : IEquatable<string>, IEquatable<int>, IEquatable<ResourceIdOrHandle<THandle>>, IHandle where THandle : IHandle
	{
		private IntPtr ptr;

		/// <summary>Gets or sets an integer identifier.</summary>
		/// <value>The identifier.</value>
		public int id
		{
			get => IS_INTRESOURCE(ptr) ? (ushort)ptr.ToInt32() : 0;
			set
			{
				if (value > ushort.MaxValue || value <= 0) throw new ArgumentOutOfRangeException(nameof(id));
				ptr = (IntPtr)(ushort)value;
			}
		}

		/// <summary>Represent a NULL value.</summary>
		public static readonly ResourceIdOrHandle<THandle> NULL = new ResourceIdOrHandle<THandle>();

		/// <summary>Performs an implicit conversion from <see cref="SafeResourceId"/> to <see cref="System.Int32"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator int(ResourceIdOrHandle<THandle> r) => r.id;

		/// <summary>Performs an implicit conversion from <see cref="ResourceIdOrHandle{THandle}"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator IntPtr(ResourceIdOrHandle<THandle> r) => r.ptr;

		/// <summary>Performs an implicit conversion from <see cref="int"/> to <see cref="ResourceIdOrHandle{THandle}"/>.</summary>
		/// <param name="resId">The resource identifier.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ResourceIdOrHandle<THandle>(int resId) => new ResourceIdOrHandle<THandle> { id = resId };

		/// <summary>Performs an implicit conversion from <see cref="ResourceType"/> to <see cref="ResourceIdOrHandle{THandle}"/>.</summary>
		/// <param name="resType">Type of the resource.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ResourceIdOrHandle<THandle>(ResourceType resType) => new ResourceIdOrHandle<THandle> { id = (int)resType };

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="ResourceIdOrHandle{THandle}"/>.</summary>
		/// <param name="p">The PTR.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ResourceIdOrHandle<THandle>(THandle p) => new ResourceIdOrHandle<THandle> { ptr = p.DangerousGetHandle() };

		/// <summary>Performs an implicit conversion from <see cref="ResourceIdOrHandle{THandle}"/> to <see cref="string"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator string(ResourceIdOrHandle<THandle> r) => r.ToString();

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			switch (obj)
			{
				case null:
					return false;

				case string s:
					return Equals(s);

				case int i:
					return Equals(i);

				case IntPtr p:
					return Equals(p);

				case ResourceIdOrHandle<THandle> r:
					return Equals(r);

				case IHandle h:
					return Equals(h.DangerousGetHandle());

				default:
					if (!obj.GetType().IsPrimitive) return false;
					try { return Equals(Convert.ToInt32(obj)); } catch { return false; }
			}
		}

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => ptr.GetHashCode();

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => IS_INTRESOURCE(ptr) ? $"#{ptr.ToInt32()}" : Marshal.PtrToStringAuto(ptr);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(int other) => ptr.ToInt32().Equals(other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public bool Equals(string other) => string.Equals(ToString(), other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(IntPtr other) => ptr.Equals(other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public bool Equals(ResourceIdOrHandle<THandle> other) => string.Equals(other.ToString(), ToString());

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => ptr;
	}

	/// <summary>Represents a system resource name that can identify as a string, integer, or pointer.</summary>
	/// <seealso cref="SafeHandle"/>
	public class SafeResourceId : GenericSafeHandle, IEquatable<string>, IEquatable<int>, IEquatable<SafeResourceId>, IEquatable<ResourceId>, IEquatable<IntPtr>, IHandle
	{
		/// <summary>Represent a NULL value.</summary>
		public static readonly SafeResourceId Null = new SafeResourceId();

		/// <summary>Initializes a new instance of the <see cref="SafeResourceId"/> class.</summary>
		/// <param name="resName">Name of the resource.</param>
		/// <param name="charSet">The character set.</param>
		/// <exception cref="System.ArgumentNullException">resName</exception>
		public SafeResourceId(string resName, CharSet charSet = CharSet.Auto)
		{
			if (string.IsNullOrEmpty(resName)) throw new ArgumentNullException(nameof(resName));
			CharSet = charSet;
			SetHandle(StringHelper.AllocString(resName, charSet));
		}

		/// <summary>Initializes a new instance of the <see cref="SafeResourceId"/> class.</summary>
		/// <param name="resId">The resource identifier.</param>
		public SafeResourceId(int resId) => id = resId;

		/// <summary>Initializes a new instance of the <see cref="SafeResourceId"/> class.</summary>
		/// <param name="resType">Type of the resource.</param>
		public SafeResourceId(ResourceType resType) : this((int)resType)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="SafeResourceId"/> class.</summary>
		/// <param name="ptr">The PTR.</param>
		public SafeResourceId(IntPtr ptr)
		{
			if (IS_INTRESOURCE(ptr))
				SetHandle(ptr);
			else
			{
				var s = StringHelper.GetString(ptr, CharSet);
				if (s != null)
					SetHandle(StringHelper.AllocString(s, CharSet));
			}
		}

		/// <summary>Initializes a new instance of the <see cref="SafeResourceId"/> class.</summary>
		protected SafeResourceId() { }

		/// <summary>Gets or sets the character set to use on resource strings.</summary>
		/// <value>The character set.</value>
		public virtual CharSet CharSet { get; set; } = CharSet.Auto;

		/// <summary>Gets or sets an integer identifier.</summary>
		/// <value>The identifier.</value>
		public int id
		{
			get => IsIntResource ? (ushort)handle.ToInt32() : 0;
			set
			{
				if (value > short.MaxValue || value < short.MinValue) throw new ArgumentOutOfRangeException(nameof(id));
				InternalCloseMethod(handle);
				SetHandle((IntPtr)unchecked((ushort)value));
			}
		}

		/// <summary>Gets a value indicating whether this instance is an integer-based resource.</summary>
		/// <value><c>true</c> if this instance is an integer-based resource; otherwise, <c>false</c>.</value>
		public bool IsIntResource => IS_INTRESOURCE(handle);

		/// <inheritdoc/>
		public override bool IsInvalid => handle == IntPtr.Zero;

		/// <inheritdoc/>
		protected override Func<IntPtr, bool> CloseMethod => InternalCloseMethod;

		/// <summary>Gets the string representation of a resource identifier.</summary>
		/// <param name="ptr">The resource identifier.</param>
		/// <param name="charSet">The character set.</param>
		/// <returns>The string representation.</returns>
		public static string GetString(IntPtr ptr, CharSet charSet = CharSet.Auto) => IS_INTRESOURCE(ptr) ? $"#{ptr.ToInt32()}" : StringHelper.GetString(ptr, charSet);

		/// <summary>Performs an implicit conversion from <see cref="SafeResourceId"/> to <see cref="System.Int32"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator int(SafeResourceId r) => r.IsIntResource ? (ushort)r.handle.ToInt32() : 0;

		/// <summary>Performs an implicit conversion from <see cref="SafeResourceId"/> to <see cref="ResourceId"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ResourceId(SafeResourceId h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="string"/> to <see cref="SafeResourceId"/>.</summary>
		/// <param name="resName">Name of the resource.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeResourceId(string resName) => new SafeResourceId(resName);

		/// <summary>Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="SafeResourceId"/>.</summary>
		/// <param name="resId">The resource identifier.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeResourceId(int resId) => new SafeResourceId(resId);

		/// <summary>Performs an implicit conversion from <see cref="ResourceType"/> to <see cref="SafeResourceId"/>.</summary>
		/// <param name="resType">Type of the resource.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeResourceId(ResourceType resType) => new SafeResourceId(resType);

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="SafeResourceId"/>.</summary>
		/// <param name="ptr">The PTR.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeResourceId(IntPtr ptr) => new SafeResourceId(ptr);

		/// <summary>Performs an implicit conversion from <see cref="SafeResourceId"/> to <see cref="string"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator string(SafeResourceId r) => r.ToString();

		/// <summary>
		/// Gets a cloned handle that also, if a string resource, copies the string to a new handle which must be released using StringHelper.FreeString.
		/// </summary>
		/// <returns>A safe copy of this resource id.</returns>
		public SafeResourceId Clone() => new SafeResourceId(handle);

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			switch (obj)
			{
				case null:
					return false;

				case ResourceId resId:
					return Equals(resId);

				case string s:
					return Equals(s);

				case int i:
					return Equals(i);

				case IntPtr p:
					return Equals(p);

				case SafeResourceId r:
					return Equals(r);

				default:
					if (!obj.GetType().IsPrimitive) return false;
					try { return Equals(Convert.ToInt32(obj)); } catch { return false; }
			}
		}

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(string other) => string.Equals(ToString(), other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(int other) => other == handle.ToInt32();

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(SafeResourceId other) => string.Equals(other.ToString(), ToString());

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(ResourceId other) => other.Equals((ResourceId)this);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(IntPtr other) => new SafeResourceId(other).Equals(this);

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public override string ToString() => GetString(handle, CharSet);

		private bool InternalCloseMethod(IntPtr h)
		{
			if (h != IntPtr.Zero && !IS_INTRESOURCE(h))
				StringHelper.FreeString(h);
			return true;
		}
	}
}