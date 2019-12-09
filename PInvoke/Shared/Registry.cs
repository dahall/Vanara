using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Vanara.InteropServices;
using Vanara.PInvoke;

namespace Vanara.PInvoke
{
	/// <summary>
	/// A registry value can store data in various formats. When you store data under a registry value, for instance by calling the
	/// RegSetValueEx function, you can specify one of the following values to indicate the type of data being stored. When you retrieve
	/// a registry value, functions such as RegQueryValueEx use these values to indicate the type of data retrieved.
	/// </summary>
	[PInvokeData("winnt.h")]
	public enum REG_VALUE_TYPE : uint
	{
		/// <summary>No defined value type.</summary>
		REG_NONE = 0,

		/// <summary>Binary data in any form.</summary>
		[CorrespondingType(typeof(byte[]))]
		REG_BINARY = 3,

		/// <summary>A 32-bit number.</summary>
		[CorrespondingType(typeof(uint))]
		REG_DWORD = 4,

		/// <summary>
		/// A 32-bit number in little-endian format.
		/// <para>Windows is designed to run on little-endian computer architectures.</para>
		/// <para>Therefore, this value is defined as REG_DWORD in the Windows header files.</para>
		/// </summary>
		[CorrespondingType(typeof(uint))]
		REG_DWORD_LITTLE_ENDIAN = 4,

		/// <summary>
		/// A 32-bit number in big-endian format.
		/// <para>Some UNIX systems support big-endian architectures.</para>
		/// </summary>
		REG_DWORD_BIG_ENDIAN = 5,

		/// <summary>
		/// A null-terminated string that contains unexpanded references to environment variables (for example, "%PATH%"). It will be a
		/// Unicode or ANSI string depending on whether you use the Unicode or ANSI functions. To expand the environment variable
		/// references, use the ExpandEnvironmentStrings function.
		/// </summary>
		[CorrespondingType(typeof(string))]
		REG_EXPAND_SZ = 2,

		/// <summary>
		/// A null-terminated Unicode string that contains the target path of a symbolic link that was created by calling the
		/// RegCreateKeyEx function with REG_OPTION_CREATE_LINK.
		/// </summary>
		REG_LINK = 6,

		/// <summary>
		/// A sequence of null-terminated strings, terminated by an empty string (\0).
		/// <para>The following is an example:</para>
		/// <para>String1\0String2\0String3\0LastString\0\0</para>
		/// <para>
		/// The first \0 terminates the first string, the second to the last \0 terminates the last string, and the final \0 terminates
		/// the sequence.Note that the final terminator must be factored into the length of the string.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(IEnumerable<string>))]
		REG_MULTI_SZ = 7,

		/// <summary>A 64-bit number.</summary>
		[CorrespondingType(typeof(ulong))]
		REG_QWORD = 11,

		/// <summary>
		/// A 64-bit number in little-endian format.
		/// <para>
		/// Windows is designed to run on little-endian computer architectures. Therefore, this value is defined as REG_QWORD in the
		/// Windows header files.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(ulong))]
		REG_QWORD_LITTLE_ENDIAN = 11,

		/// <summary>
		/// A null-terminated string. This will be either a Unicode or an ANSI string, depending on whether you use the Unicode or ANSI functions.
		/// </summary>
		[CorrespondingType(typeof(string))]
		REG_SZ = 1,

		/// <summary>Resource list in the resource map.</summary>
		REG_RESOURCE_LIST = 8,

		/// <summary>Resource list in the hardware description.</summary>
		REG_FULL_RESOURCE_DESCRIPTOR = 9,

		/// <summary>Resource requirement list.</summary>
		REG_RESOURCE_REQUIREMENTS_LIST = 10,
	}
}

namespace Vanara.Extensions
{
	/// <summary>Extension methods for registry types.</summary>
	public static class RegistryTypeExt
	{
		/// <summary>Extract the value of this registry type from a pointer.</summary>
		/// <param name="value">The registry type value.</param>
		/// <param name="ptr">The allocated memory pointer.</param>
		/// <param name="size">The size of the allocated memory.</param>
		/// <returns>The extracted value.</returns>
		public static object GetValue(this Vanara.PInvoke.REG_VALUE_TYPE value, IntPtr ptr, uint size)
		{
			switch (value)
			{
				case PInvoke.REG_VALUE_TYPE.REG_DWORD:
				case PInvoke.REG_VALUE_TYPE.REG_DWORD_BIG_ENDIAN:
					var data = IntPtrConverter.Convert<byte[]>(ptr, 4);
					if (BitConverter.IsLittleEndian && value == REG_VALUE_TYPE.REG_DWORD_BIG_ENDIAN || !BitConverter.IsLittleEndian && value == REG_VALUE_TYPE.REG_DWORD)
						Array.Reverse(data);
					return BitConverter.ToUInt32(data, 0);
				case PInvoke.REG_VALUE_TYPE.REG_EXPAND_SZ:
					return Environment.ExpandEnvironmentVariables(StringHelper.GetString(ptr, System.Runtime.InteropServices.CharSet.Auto, size));
				case PInvoke.REG_VALUE_TYPE.REG_MULTI_SZ:
					return ptr.ToStringEnum(System.Runtime.InteropServices.CharSet.Auto, 0, size).ToArray();
				case PInvoke.REG_VALUE_TYPE.REG_QWORD:
					return IntPtrConverter.Convert<ulong>(ptr, size);
				case PInvoke.REG_VALUE_TYPE.REG_SZ:
					return StringHelper.GetString(ptr, System.Runtime.InteropServices.CharSet.Auto, size);
				case PInvoke.REG_VALUE_TYPE.REG_RESOURCE_LIST:
				case PInvoke.REG_VALUE_TYPE.REG_FULL_RESOURCE_DESCRIPTOR:
				case PInvoke.REG_VALUE_TYPE.REG_RESOURCE_REQUIREMENTS_LIST:
				case PInvoke.REG_VALUE_TYPE.REG_BINARY:
					return IntPtrConverter.Convert<byte[]>(ptr, size);
				case PInvoke.REG_VALUE_TYPE.REG_LINK:
					throw new InvalidOperationException("Registry links cannot be retrived from a pointer. Please use RegOpenKeyEx.");
				default:
				case PInvoke.REG_VALUE_TYPE.REG_NONE:
					return ptr;
			}
		}

		/// <summary>Gets a <see cref="REG_VALUE_TYPE"/> given a system type.</summary>
		/// <param name="type">The type.</param>
		/// <returns>A compatible <see cref="REG_VALUE_TYPE"/>. If no good match is found, <see cref="REG_VALUE_TYPE.REG_SZ"/> is returned.</returns>
		public static REG_VALUE_TYPE GetFromType(Type type)
		{
			if (typeof(IEnumerable<string>).IsAssignableFrom(type))
				return REG_VALUE_TYPE.REG_MULTI_SZ;
			switch (Type.GetTypeCode(type))
			{
				case TypeCode.SByte:
				case TypeCode.Byte:
				case TypeCode.Int16:
				case TypeCode.UInt16:
				case TypeCode.Int32:
				case TypeCode.UInt32:
					return REG_VALUE_TYPE.REG_DWORD;
				case TypeCode.Int64:
				case TypeCode.UInt64:
					return REG_VALUE_TYPE.REG_QWORD;
				case TypeCode.Char:
				case TypeCode.String:
					return REG_VALUE_TYPE.REG_SZ;
				default:
					break;
			}
			if (typeof(IEnumerable<byte>).IsAssignableFrom(type) || type.IsMarshalable())
				return REG_VALUE_TYPE.REG_BINARY;
			return REG_VALUE_TYPE.REG_SZ;
		}

		/// <summary>Gets a <see cref="REG_VALUE_TYPE"/> given a system type.</summary>
		/// <typeparam name="T">The type.</typeparam>
		/// <returns>A compatible <see cref="REG_VALUE_TYPE"/>. If no good match is found, <see cref="REG_VALUE_TYPE.REG_SZ"/> is returned.</returns>
		public static REG_VALUE_TYPE GetFromType<T>() => GetFromType(typeof(T));
	}
}