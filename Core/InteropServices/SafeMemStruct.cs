using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.PInvoke;

#if ALLOWSPAN
using System.Buffers;
#endif

namespace Vanara.InteropServices
{
	/// <summary>Base abstract class for a structure handler based on <see cref="SafeMemoryHandle{TMem}"/>.</summary>
	/// <typeparam name="TStruct">The type of the structure.</typeparam>
	/// <typeparam name="TMem">The type of the memory.</typeparam>
	/// <seealso cref="Vanara.InteropServices.SafeMemoryHandle{TMem}"/>
	public abstract class SafeMemStruct<TStruct, TMem> : SafeMemoryHandle<TMem>, IEquatable<TStruct> where TMem : IMemoryMethods, new() where TStruct : struct
	{
		/// <summary>Initializes a new instance of the <see cref="SafeMemStruct{TStruct, TMem}"/> class.</summary>
		/// <param name="s">The TStruct value.</param>
		/// <param name="capacity">The capacity of the buffer, in bytes.</param>
		protected SafeMemStruct(in TStruct s, SizeT capacity = default) : base(Math.Max((ulong)SizeOf<TStruct>(), (ulong)capacity)) => handle.Write(s);

		/// <summary>Initializes a new instance of the <see cref="SafeMemStruct{TStruct, TMem}"/> class.</summary>
		/// <param name="capacity">The capacity of the buffer, in bytes.</param>
		protected SafeMemStruct(SizeT capacity = default) : base(Math.Max((ulong)SizeOf<TStruct>(), (ulong)capacity)) { }

		/// <summary>Initializes a new instance of the <see cref="SafeMemStruct{TStruct, TMem}"/> class.</summary>
		/// <param name="ptr">The PTR.</param>
		/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
		/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
		[ExcludeFromCodeCoverage]
		protected SafeMemStruct(IntPtr ptr, bool ownsHandle = true, SizeT allocatedBytes = default) : base(ptr, allocatedBytes, ownsHandle) { }

		/// <summary>Gets a value indicating whether the current memory has a valid value of its underlying type.</summary>
		/// <value><see langword="true"/> if this instance has a value; otherwise, <see langword="false"/>.</value>
		public bool HasValue => !IsClosed && !IsInvalid;

		/// <summary>
		/// Gets or sets the value of the current <see cref="SafeMemStruct{TStruct, TMem}"/> object if it has been assigned a valid
		/// underlying value.
		/// </summary>
		/// <value>
		/// The value of the current <see cref="SafeMemStruct{TStruct, TMem}"/> object if the HasValue property is true. An exception is
		/// thrown if the HasValue property is false.
		/// </value>
		/// <exception cref="System.InvalidOperationException">The HasValue property is false.</exception>
		public TStruct Value
		{
			get => HasValue ? handle.ToStructure<TStruct>(Size) : throw new InvalidOperationException("The HasValue property is false.");
			set => _ = HasValue ? handle.Write(value, 0, Size) : throw new InvalidOperationException("The HasValue property is false.");
		}

		/// <summary>Returns the TStruct value held by a <see cref="SafeMemStruct{TStruct, TMem}"/>.</summary>
		/// <param name="s">The <see cref="SafeMemStruct{TStruct, TMem}"/> instance.</param>
		/// <returns>
		/// A nullable value held by the <see cref="SafeMemStruct{TStruct, TMem}"/> or <c>null</c> if the handle or value is invalid.
		/// </returns>
		public static explicit operator TStruct?(SafeMemStruct<TStruct, TMem> s) => s is null || !s.HasValue ? (TStruct?)null : s.Value;

		/// <summary>Performs an explicit conversion from <see cref="SafeMemStruct{TStruct, TMem}"/> to <see cref="System.Char"/>.</summary>
		/// <param name="s">The <see cref="SafeMemStruct{TStruct, TMem}"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		/// <exception cref="InvalidCastException">Cannot convert an ANSI string to a Char pointer.</exception>
		public static unsafe explicit operator void*(SafeMemStruct<TStruct, TMem> s) => (void*)s.handle;

		/// <summary>Returns the value of the <see cref="SafeHandle.handle"/> field.</summary>
		/// <param name="s">The <see cref="SafeMemStruct{TStruct, TMem}"/> instance.</param>
		/// <returns>
		/// An <see cref="IntPtr"/> representing the value of the handle field. If the handle has been marked invalid with <see
		/// cref="SafeHandle.SetHandleAsInvalid"/>, this method still returns the original handle value, which can be a stale value.
		/// </returns>
		public static implicit operator IntPtr(SafeMemStruct<TStruct, TMem> s) => s.DangerousGetHandle();

		/// <summary>Returns the TStruct value held by a <see cref="SafeMemStruct{TStruct, TMem}"/>.</summary>
		/// <param name="s">The <see cref="SafeMemStruct{TStruct, TMem}"/> instance.</param>
		/// <returns>
		/// The structure value held by the <see cref="SafeMemStruct{TStruct, TMem}"/> or an <see cref="InvalidOperationException"/>
		/// exception if the handle or value is invalid.
		/// </returns>
		public static implicit operator TStruct(SafeMemStruct<TStruct, TMem> s) => !(s is null) ? s.Value : throw new ArgumentNullException(nameof(s));

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) => ReferenceEquals(this, obj)
				? true
				: (obj switch
				{
					null => false,
					SafeMemStruct<TStruct, TMem> ms => Equals((TStruct?)this, (TStruct?)ms),
					TStruct s => Equals(s),
					SafeAllocatedMemoryHandle m => m.DangerousGetHandle() == handle,
					_ => false,
				});

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(TStruct other) => !HasValue ? false : EqualityComparer<TStruct>.Default.Equals(handle.ToStructure<TStruct>(Size), other);

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => handle.ToInt32();

		/// <summary>Retrieves the value of the current <see cref="SafeMemStruct{TStruct, TMem}"/> object, or the specified default value.</summary>
		/// <param name="defaultValue">A value to return if the <see cref="HasValue"/> property is <see langword="false"/>.</param>
		/// <returns>
		/// The value of the <see cref="Value"/> property if the <see cref="HasValue"/> property is <see langword="true"/>; otherwise, the
		/// <paramref name="defaultValue"/> parameter.
		/// </returns>
		public virtual TStruct GetValueOrDefault(in TStruct defaultValue = default) => HasValue ? Value : defaultValue;

		/// <summary>Returns the string value held by this instance.</summary>
		/// <returns>A <see cref="System.String"/> value held by this instance or <c>null</c> if the handle is invalid.</returns>
		public override string ToString() => ((TStruct?)this).ToString();

		private static SizeT SizeOf<T>() => InteropExtensions.SizeOf<T>();

#if ALLOWSPAN
		/// <summary>Gets a reference to a structure based on this allocated memory.</summary>
		/// <returns>A referenced structure.</returns>
		public ref TStruct AsRef() => ref MemoryMarshal.GetReference(AsSpan());

		/// <summary>Creates a new span over this allocated memory.</summary>
		/// <returns>The span representation of the structure.</returns>
		public Span<TStruct> AsSpan() => base.AsSpan<TStruct>(1);
#endif
	}

	/// <summary>
	/// A structure handler based on unmanaged memory allocated by AllocCoTaskMem.
	/// </summary>
	/// <typeparam name="TStruct">The type of the structure.</typeparam>
	/// <seealso cref="Vanara.InteropServices.SafeMemStruct{TStruct, TMem}" />
	public class SafeCoTaskMemStruct<TStruct> : SafeMemStruct<TStruct, CoTaskMemoryMethods> where TStruct : struct
	{
		/// <summary>Initializes a new instance of the <see cref="SafeCoTaskMemStruct{TStruct}"/> class.</summary>
		/// <param name="s">The TStruct value.</param>
		/// <param name="capacity">The capacity of the buffer, in bytes.</param>
		public SafeCoTaskMemStruct(in TStruct s, SizeT capacity = default) : base(s, capacity) { }

		/// <summary>Initializes a new instance of the <see cref="SafeCoTaskMemStruct{TStruct}"/> class.</summary>
		/// <param name="capacity">The capacity of the buffer, in bytes.</param>
		public SafeCoTaskMemStruct(SizeT capacity = default) : base(capacity) { }

		/// <summary>Initializes a new instance of the <see cref="SafeCoTaskMemStruct{TStruct}"/> class.</summary>
		/// <param name="ptr">The PTR.</param>
		/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
		/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
		[ExcludeFromCodeCoverage]
		public SafeCoTaskMemStruct(IntPtr ptr, bool ownsHandle = true, SizeT allocatedBytes = default) : base(ptr, ownsHandle, allocatedBytes) { }
	}

	/// <summary>
	/// A structure handler based on unmanaged memory allocated by AllocHGlobal.
	/// </summary>
	/// <typeparam name="TStruct">The type of the structure.</typeparam>
	/// <seealso cref="Vanara.InteropServices.SafeMemStruct{TStruct, TMem}" />
	public class SafeHGlobalStruct<TStruct> : SafeMemStruct<TStruct, HGlobalMemoryMethods> where TStruct : struct
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHGlobalStruct{TStruct}"/> class.</summary>
		/// <param name="s">The TStruct value.</param>
		/// <param name="capacity">The capacity of the buffer, in bytes.</param>
		public SafeHGlobalStruct(in TStruct s, SizeT capacity = default) : base(s, capacity) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHGlobalStruct{TStruct}"/> class.</summary>
		/// <param name="capacity">The capacity of the buffer, in bytes.</param>
		public SafeHGlobalStruct(SizeT capacity = default) : base(capacity) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHGlobalStruct{TStruct}"/> class.</summary>
		/// <param name="ptr">The PTR.</param>
		/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
		/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
		[ExcludeFromCodeCoverage]
		public SafeHGlobalStruct(IntPtr ptr, bool ownsHandle = true, SizeT allocatedBytes = default) : base(ptr, ownsHandle, allocatedBytes) { }
	}
}