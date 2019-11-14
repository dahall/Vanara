using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.PInvoke;

namespace Vanara.InteropServices
{
	/// <summary>Smarter custom marshaler.</summary>
	public interface IVanaraMarshaler
	{
		/// <summary>Gets the size of the native data.</summary>
		/// <returns>
		/// The size, in bytes, of the base object in memory. This should return the equivalent of the sizeof(X) function in C/C++.
		/// </returns>
		SizeT GetNativeSize();

		/// <summary>Marshals the managed object to its native, in-memory, value.</summary>
		/// <param name="managedObject">The managed object to marshal.</param>
		/// <returns>The self-destroying handle to the binary representation.</returns>
		SafeAllocatedMemoryHandle MarshalManagedToNative(object managedObject);

		/// <summary>Marshals the native memory to a managed object.</summary>
		/// <param name="pNativeData">The pointer to the native data.</param>
		/// <param name="allocatedBytes">The number of allocated bytes.</param>
		/// <returns>The type instance.</returns>
		object MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes);
	}

	[VanaraMarshaler(typeof(TestMarshal))]
	internal struct TestMarshal : IVanaraMarshaler
	{
		public bool bVal;
		public uint[] uArray;

		SizeT IVanaraMarshaler.GetNativeSize() => 12;

		SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object managedObject)
		{
			if (managedObject is null) return SafeHGlobalHandle.Null;
			if (!(managedObject is TestMarshal t))
				throw new ArgumentException($"Object must be a {nameof(TestMarshal)} instance.", nameof(managedObject));
			var mem = new SafeHGlobalHandle(12);
			mem.Write(t.bVal ? 1U : 0U);
			mem.Write(t.uArray?.Length ?? 0);
			mem.Write(t.uArray, true, 8);
			return mem;
		}

		object IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
		{
			var ret = default(TestMarshal);
			if (pNativeData != IntPtr.Zero)
			{
				using var str = new NativeMemoryStream(pNativeData, allocatedBytes);
				ret.bVal = str.Read<uint>() != 0;
				var len = str.Read<int>();
				ret.uArray = str.ReadArray<uint>(len, false).ToArray();
			}
			return ret;
		}
	}

	/// <summary>Provides methods to assist with custom marshaling.</summary>
	public static class VanaraMarshaler
	{
		/// <summary>Determines whether a type can be marshaled.</summary>
		/// <param name="t">The type to check.</param>
		/// <param name="marshaler">On success, the marshaler instance.</param>
		/// <returns><see langword="true"/> if this type can marshaled; otherwise, <see langword="false"/>.</returns>
		public static bool CanMarshal(Type t, out IVanaraMarshaler marshaler)
		{
			var vattr = t.GetCustomAttributes<VanaraMarshalerAttribute>(true).FirstOrDefault();
			if (vattr != null)
			{
				marshaler = Activator.CreateInstance(vattr.MarshalType) as IVanaraMarshaler;
				return marshaler != null;
			}
			if (typeof(IVanaraMarshaler).IsAssignableFrom(t))
			{
				marshaler = Activator.CreateInstance(t) as IVanaraMarshaler;
				return marshaler != null;
			}
			marshaler = null;
			return false;
		}

		/// <summary>Determines whether a type can be marshaled.</summary>
		/// <typeparam name="T">The type to check.</typeparam>
		/// <param name="marshaler">On success, the marshaler instance.</param>
		/// <returns><see langword="true"/> if this type can marshaled; otherwise, <see langword="false"/>.</returns>
		public static bool CanMarshal<T>(out IVanaraMarshaler marshaler) => CanMarshal(typeof(T), out marshaler);
	}

	/// <summary>Provides an <see cref="ICustomMarshaler"/> instance that utilizes an <see cref="IVanaraMarshaler"/> implementation.</summary>
	/// <typeparam name="T">
	/// The type that either implements <see cref="IVanaraMarshaler"/> or uses <see cref="VanaraMarshalerAttribute"/> to specify a type.
	/// </typeparam>
	/// <seealso cref="System.Runtime.InteropServices.ICustomMarshaler"/>
	public class VanaraCustomMarshaler<T> : ICustomMarshaler
	{
		private SafeAllocatedMemoryHandle mem;

		private VanaraCustomMarshaler(string _)
		{
		}

		/// <summary>Gets the instance.</summary>
		/// <param name="cookie">The cookie.</param>
		/// <returns></returns>
		public static ICustomMarshaler GetInstance(string cookie) => new VanaraCustomMarshaler<T>(cookie);

		void ICustomMarshaler.CleanUpManagedData(object ManagedObj)
		{
		}

		void ICustomMarshaler.CleanUpNativeData(IntPtr pNativeData) => mem?.Dispose();

		int ICustomMarshaler.GetNativeDataSize() => VanaraMarshaler.CanMarshal<T>(out var m) ? (int)m.GetNativeSize() : -1;

		IntPtr ICustomMarshaler.MarshalManagedToNative(object ManagedObj) => VanaraMarshaler.CanMarshal<T>(out var m) ? (mem = m.MarshalManagedToNative(ManagedObj)) : throw new InvalidOperationException("Cannot marshal this type.");

		object ICustomMarshaler.MarshalNativeToManaged(IntPtr pNativeData) => VanaraMarshaler.CanMarshal<T>(out var m) ? m.MarshalNativeToManaged(pNativeData, SizeT.MaxValue) : throw new InvalidOperationException("Cannot marshal this type.");
	}

	/// <summary>Apply this attribute to a class or structure to have all Vanara interop function process via the marshaler.</summary>
	/// <seealso cref="System.Attribute"/>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
	public class VanaraMarshalerAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="VanaraMarshalerAttribute"/> class.</summary>
		/// <param name="marshalType">A type that derives from <see cref="IVanaraMarshaler"/> that will marshal this class or structure.</param>
		public VanaraMarshalerAttribute(Type marshalType)
		{
			if (marshalType is null)
				throw new ArgumentNullException(nameof(marshalType));
			if (!typeof(IVanaraMarshaler).IsAssignableFrom(marshalType))
				throw new ArgumentException($"The supplied type must inherit from {nameof(IVanaraMarshaler)}.", nameof(marshalType));
			MarshalType = marshalType;
		}

		/// <summary>Gets the type that will marshal this class or structure.</summary>
		public Type MarshalType { get; }
	}
}