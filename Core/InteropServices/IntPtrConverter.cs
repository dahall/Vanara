using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using Vanara.Extensions;

namespace Vanara.InteropServices
{
	/// <summary>Functions to safely convert a memory pointer to a type.</summary>
	public static class IntPtrConverter
	{
		/// <summary>Converts the specified pointer to <typeparamref name="T"/>.</summary>
		/// <typeparam name="T">The destination type.</typeparam>
		/// <param name="ptr">The pointer to a block of memory.</param>
		/// <param name="sz">The size of the allocated memory block.</param>
		/// <param name="charSet">The character set.</param>
		/// <returns>A value of the type specified.</returns>
		public static T Convert<T>(this IntPtr ptr, uint sz, CharSet charSet = CharSet.Auto) => (T)Convert(ptr, sz, typeof(T), charSet);

		/// <summary>Converts the specified pointer to type specified in <paramref name="destType"/>.</summary>
		/// <param name="ptr">The pointer to a block of memory.</param>
		/// <param name="sz">The size of the allocated memory block.</param>
		/// <param name="destType">The destination type.</param>
		/// <param name="charSet">The character set.</param>
		/// <returns>A value of the type specified.</returns>
		/// <exception cref="ArgumentException">Cannot convert a null pointer. - ptr or Cannot convert a pointer with no Size. - sz</exception>
		/// <exception cref="NotSupportedException">Thrown if type cannot be converted from memory.</exception>
		/// <exception cref="OutOfMemoryException"></exception>
		public static object Convert(this IntPtr ptr, uint sz, Type destType, CharSet charSet = CharSet.Auto)
		{
			if (ptr == IntPtr.Zero)
			{
				if (!destType.IsValueType) return null;
				throw new NullReferenceException();
			}
			if (sz == 0) throw new ArgumentException("Cannot convert a pointer with no Size.", nameof(sz));

			// Handle byte array and pointer as special cases
			if (destType.IsArray && destType.GetElementType() == typeof(byte))
				return ptr.ToArray<byte>((int)sz);
			if (destType == typeof(IntPtr))
				return Marshal.ReadIntPtr(ptr);

			var typeCode = Type.GetTypeCode(destType);
			switch (typeCode)
			{
				case TypeCode.Object:
					try
					{
						if (VanaraMarshaler.CanMarshal(destType, out var marshaler))
						{
							return marshaler.MarshalNativeToManaged(ptr, sz);
						}
						if (destType.IsBlittable())
						{
							return GetBlittable(destType);
						}
						if (destType.IsNullable())
						{
							return ptr != IntPtr.Zero ? InteropExtensions.GetValueType(ptr, Nullable.GetUnderlyingType(destType)) : Activator.CreateInstance(destType, true);
						}
						if (destType.IsSerializable)
						{
							using var mem = new MemoryStream(ptr.ToArray<byte>((int)sz));
							return new BinaryFormatter().Deserialize(mem);
						}
					}
					catch (ArgumentOutOfRangeException)
					{
						throw;
					}
					catch { }
					throw new NotSupportedException("Unsupported type parameter.");

				case TypeCode.Boolean:
					return System.Convert.ChangeType(GetBlittable(typeof(uint)), typeCode);

				case TypeCode.Char:
					return System.Convert.ChangeType(GetBlittable(typeof(ushort)), typeCode);

				case TypeCode.SByte:
				case TypeCode.Byte:
				case TypeCode.Int16:
				case TypeCode.UInt16:
				case TypeCode.Int32:
				case TypeCode.UInt32:
				case TypeCode.Int64:
				case TypeCode.UInt64:
				case TypeCode.Single:
				case TypeCode.Double:
				case TypeCode.Decimal:
					return GetBlittable(destType);

				case TypeCode.DateTime:
					return DateTime.FromBinary((long)GetBlittable(typeof(long)));

				case TypeCode.String:
					return StringHelper.GetString(ptr, charSet, sz);

				default:
					throw new NotSupportedException("Unsupported type parameter.");
			}

			object GetBlittable(Type retType) => InteropExtensions.GetValueType(ptr, retType);
		}

		/*public static IntPtr Convert(object value, Func<int, IntPtr> memAlloc, out int bytesAllocated, CharSet charSet = CharSet.Auto, int prefixBytes = 0)
		{
			bytesAllocated = 0;
			if (value is null)
				return IntPtr.Zero;

			var type = value.GetType();

			// Handle special cases
			if (type.IsArray || type.InheritsFrom(typeof(IEnumerable<>)))
			{
				var elemType = type.FindElementType();
				if (elemType == typeof(string))
				{
				}
				else
				{
					var enumType = typeof(IEnumerable<>).MakeGenericType(new[] { elemType });
					var mi = typeof(InteropExtensions).GetMethod("Write", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(IntPtr), enumType, typeof(int), typeof(SizeT) }, null);
					var gmi = mi.MakeGenericMethod(new[] { elemType });
					return gmi.Invoke(null, new object[] { x });
				}
			}
			if (value is IEnumerable)
			{
				if ()
				{

				}
			}

			throw new NotImplementedException();
		}*/

		/// <summary>Converts the specified pointer to <typeparamref name="T"/>.</summary>
		/// <typeparam name="T">The destination type.</typeparam>
		/// <param name="hMem">A block of allocated memory.</param>
		/// <param name="charSet">The character set.</param>
		/// <returns>A value of the type specified.</returns>
		public static T ToType<T>(this SafeAllocatedMemoryHandle hMem, CharSet charSet = CharSet.Auto)
		{
			if (hMem == null) throw new ArgumentNullException(nameof(hMem));
			return Convert<T>(hMem.DangerousGetHandle(), hMem.Size, charSet);
		}
	}
}
