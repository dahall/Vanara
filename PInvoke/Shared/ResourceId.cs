using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Macros;

// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	/// <summary>Predefined resource types.</summary>
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
		/// Allows a resource editing tool to associate a string with an .rc file. Typically, the string is the name of the header file that provides
		/// symbolic names. The resource compiler parses the string but otherwise ignores the value.
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
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
	public struct ResourceId : IEquatable<string>, IEquatable<IntPtr>, IEquatable<int>, IEquatable<ResourceId>
	{
		/// <summary>The name</summary>
		[FieldOffset(0)]
		public string name;

		/// <summary>The PTR</summary>
		[FieldOffset(0)]
		public IntPtr ptr;

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
		public static readonly ResourceId Null = new ResourceId();

		/// <summary>Performs an implicit conversion from <see cref="ResourceId"/> to <see cref="int"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator int(ResourceId r) => r.id;

		/// <summary>Performs an implicit conversion from <see cref="ResourceId"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator IntPtr(ResourceId r) => r.ptr;

		/// <summary>Performs an implicit conversion from <see cref="string"/> to <see cref="ResourceId"/>.</summary>
		/// <param name="resName">Name of the resource.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ResourceId(string resName) => new ResourceId { name = resName };

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
		public static implicit operator string(ResourceId r) => r.ToString();

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
		bool IEquatable<int>.Equals(int other) => ptr.ToInt32().Equals(other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		/// <exception cref="NotImplementedException"></exception>
		bool IEquatable<string>.Equals(string other) => string.Equals(ToString(), other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		bool IEquatable<IntPtr>.Equals(IntPtr other) => ptr.Equals(other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		/// <exception cref="NotImplementedException"></exception>
		bool IEquatable<ResourceId>.Equals(ResourceId other) => string.Equals(other.ToString(), ToString());
	}

	/// <summary>Helper structure to use for a pointer that can morph into a string, pointer or integer.</summary>
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct ResourceIdUni : IEquatable<string>, IEquatable<IntPtr>, IEquatable<int>, IEquatable<ResourceIdUni>
	{
		/// <summary>The name</summary>
		[FieldOffset(0)]
		public string name;

		/// <summary>The PTR</summary>
		[FieldOffset(0)]
		public IntPtr ptr;

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
		public static readonly ResourceIdUni Null = new ResourceIdUni();

		/// <summary>Performs an implicit conversion from <see cref="ResourceIdUni"/> to <see cref="int"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator int(ResourceIdUni r) => r.id;

		/// <summary>Performs an implicit conversion from <see cref="ResourceIdUni"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator IntPtr(ResourceIdUni r) => r.ptr;

		/// <summary>Performs an implicit conversion from <see cref="string"/> to <see cref="ResourceIdUni"/>.</summary>
		/// <param name="resName">Name of the resource.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ResourceIdUni(string resName) => new ResourceIdUni { name = resName };

		/// <summary>Performs an implicit conversion from <see cref="int"/> to <see cref="ResourceIdUni"/>.</summary>
		/// <param name="resId">The resource identifier.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ResourceIdUni(int resId) => new ResourceIdUni { id = resId };

		/// <summary>Performs an implicit conversion from <see cref="ResourceType"/> to <see cref="ResourceIdUni"/>.</summary>
		/// <param name="resType">Type of the resource.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ResourceIdUni(ResourceType resType) => new ResourceIdUni { id = (int)resType };

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="ResourceIdUni"/>.</summary>
		/// <param name="p">The PTR.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ResourceIdUni(IntPtr p) => new ResourceIdUni { ptr = p };

		/// <summary>Performs an implicit conversion from <see cref="ResourceIdUni"/> to <see cref="string"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator string(ResourceIdUni r) => r.ToString();

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

				case ResourceIdUni r:
					return Equals(r);

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
		public override string ToString() => IS_INTRESOURCE(ptr) ? $"#{ptr.ToInt32()}" : Marshal.PtrToStringUni(ptr);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		bool IEquatable<int>.Equals(int other) => ptr.ToInt32().Equals(other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		/// <exception cref="NotImplementedException"></exception>
		bool IEquatable<string>.Equals(string other) => string.Equals(ToString(), other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		bool IEquatable<IntPtr>.Equals(IntPtr other) => ptr.Equals(other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		/// <exception cref="NotImplementedException"></exception>
		bool IEquatable<ResourceIdUni>.Equals(ResourceIdUni other) => string.Equals(other.ToString(), ToString());
	}

	/// <summary>Represents a system resource name that can identify as a string, integer, or pointer.</summary>
	/// <seealso cref="SafeHandle"/>
	public sealed class SafeResourceId : GenericSafeHandle, IEquatable<string>, IEquatable<int>, IEquatable<SafeResourceId>, IEquatable<IntPtr>
	{
		/// <summary>Initializes a new instance of the <see cref="SafeResourceId"/> class.</summary>
		/// <param name="resName">Name of the resource.</param>
		public SafeResourceId(string resName) : base(CloseHandle)
		{
			if (string.IsNullOrEmpty(resName)) throw new ArgumentNullException(nameof(resName));
			SetHandle(Marshal.StringToCoTaskMemUni(resName));
		}

		/// <summary>Initializes a new instance of the <see cref="SafeResourceId"/> class.</summary>
		/// <param name="resId">The resource identifier.</param>
		public SafeResourceId(int resId) : base(CloseHandle)
		{
			if (resId > ushort.MaxValue || resId <= 0) throw new ArgumentOutOfRangeException(nameof(resId));
			SetHandle((IntPtr)(ushort)resId);
		}

		/// <summary>Initializes a new instance of the <see cref="SafeResourceId"/> class.</summary>
		/// <param name="resType">Type of the resource.</param>
		public SafeResourceId(ResourceType resType) : this((int)resType)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="SafeResourceId"/> class.</summary>
		/// <param name="ptr">The PTR.</param>
		public SafeResourceId(IntPtr ptr) : base(CloseHandle)
		{
			if (IS_INTRESOURCE(ptr))
				SetHandle(ptr);
			else
			{
				var s = (string)Marshal.PtrToStringUni(ptr)?.Clone();
				if (s != null)
					SetHandle(Marshal.StringToCoTaskMemUni(s));
			}
		}

		/// <summary>When overridden in a derived class, gets a value indicating whether the handle value is invalid.</summary>
		public override bool IsInvalid => handle == IntPtr.Zero;

		/// <summary>Performs an implicit conversion from <see cref="SafeResourceId"/> to <see cref="System.Int32"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator int(SafeResourceId r)
			=> IS_INTRESOURCE(r.handle) ? (ushort)r.handle.ToInt32() : 0;

		/// <summary>Performs an implicit conversion from <see cref="SafeResourceId"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator IntPtr(SafeResourceId r) => r.handle;

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
		public bool Equals(SafeResourceId other)
			=> IS_INTRESOURCE(handle) && other != null ? handle == other.handle : Equals(other?.ToString());

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(IntPtr other) => new SafeResourceId(other).Equals(this);

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => handle.GetHashCode();

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString()
			=> IS_INTRESOURCE(handle) ? $"#{handle.ToInt32()}" : Marshal.PtrToStringUni(handle);

		private static bool CloseHandle(IntPtr handle)
		{
			if (handle != IntPtr.Zero && !IS_INTRESOURCE(handle)) Marshal.FreeCoTaskMem(handle);
			return true;
		}
	}
}