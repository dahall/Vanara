﻿using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke
{
	public static partial class NtDll
	{
		/// <summary>Initializes a counted Unicode string.</summary>
		/// <param name="DestinationString">
		/// The buffer for a counted Unicode string to be initialized. The length is initialized to zero if the SourceString is not specified.
		/// </param>
		/// <param name="SourceString">Optional pointer to a null-terminated Unicode string with which to initialize the counted string.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winternl/nf-winternl-rtlinitunicodestring void RtlInitUnicodeString(
		// PUNICODE_STRING DestinationString, PCWSTR SourceString );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winternl.h", MSDNShortId = "NF:winternl.RtlInitUnicodeString")]
		public static extern void RtlInitUnicodeString(ref UNICODE_STRING DestinationString, [MarshalAs(UnmanagedType.LPWStr), Optional] string SourceString);

		/// <summary>Initializes a counted Unicode string.</summary>
		/// <param name="DestinationString">
		/// The buffer for a counted Unicode string to be initialized. The length is initialized to zero if the SourceString is not specified.
		/// </param>
		/// <param name="SourceString">Optional pointer to a null-terminated Unicode string with which to initialize the counted string.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winternl/nf-winternl-rtlinitunicodestring void RtlInitUnicodeString(
		// PUNICODE_STRING DestinationString, PCWSTR SourceString );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winternl.h", MSDNShortId = "NF:winternl.RtlInitUnicodeString")]
		public static extern void RtlInitUnicodeString(ref UNICODE_STRING_WOW64 DestinationString, [MarshalAs(UnmanagedType.LPWStr), Optional] string SourceString);

		/// <summary>Initializes a counted Unicode string.</summary>
		/// <param name="DestinationString">
		/// The buffer for a counted Unicode string to be initialized. The length is initialized to zero if the SourceString is not specified.
		/// </param>
		/// <param name="SourceString">Optional pointer to a null-terminated Unicode string with which to initialize the counted string.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winternl/nf-winternl-rtlinitunicodestring void RtlInitUnicodeString(
		// PUNICODE_STRING DestinationString, PCWSTR SourceString );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winternl.h", MSDNShortId = "NF:winternl.RtlInitUnicodeString")]
		public static extern void RtlInitUnicodeString([In, Out] IntPtr DestinationString, [MarshalAs(UnmanagedType.LPWStr), Optional] string SourceString);

		/// <summary>Initializes a counted Unicode string.</summary>
		/// <param name="DestinationString">
		/// The buffer for a counted Unicode string to be initialized. The length is initialized to zero if the SourceString is not specified.
		/// </param>
		/// <param name="SourceString">Optional pointer to a null-terminated Unicode string with which to initialize the counted string.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winternl/nf-winternl-rtlinitunicodestring void RtlInitUnicodeString(
		// PUNICODE_STRING DestinationString, PCWSTR SourceString );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winternl.h", MSDNShortId = "NF:winternl.RtlInitUnicodeString")]
		public static extern void RtlInitUnicodeString([In, Out] IntPtr DestinationString, [In, Optional] IntPtr SourceString);

		/// <summary>The <c>UNICODE_STRING</c> structure is used to define Unicode strings.</summary>
		/// <remarks>
		/// <para>
		/// The <c>UNICODE_STRING</c> structure is used to pass Unicode strings. Use RtlUnicodeStringInit or RtlUnicodeStringInitEx to
		/// initialize a <c>UNICODE_STRING</c> structure.
		/// </para>
		/// <para>If the string is null-terminated, <c>Length</c> does not include the trailing null character.</para>
		/// <para>
		/// The <c>MaximumLength</c> is used to indicate the length of <c>Buffer</c> so that if the string is passed to a conversion routine
		/// such as RtlAnsiStringToUnicodeString the returned string does not exceed the buffer size.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wudfwdm/ns-wudfwdm-_unicode_string typedef struct
		// _UNICODE_STRING { USHORT Length; USHORT MaximumLength; PWCH Buffer; } UNICODE_STRING;
		[PInvokeData("wudfwdm.h", MSDNShortId = "b02f29a9-1049-4e29-aac3-72bf0c70a21e")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct UNICODE_STRING
		{
			/// <summary>The length, in bytes, of the string stored in <c>Buffer</c>.</summary>
			public ushort Length;

			/// <summary>The length, in bytes, of <c>Buffer</c>.</summary>
			public ushort MaximumLength;

			/// <summary>Pointer to a wide-character string.</summary>
			public IntPtr Buffer;

			/// <inheritdoc/>
			public override string ToString() => StringHelper.GetString(Buffer, CharSet.Unicode, MaximumLength) ?? string.Empty;

			/// <summary>Extracts the string value from this structure by reading process specific memory.</summary>
			/// <param name="hProc">The process handle of the process from which to read the memory.</param>
			/// <returns>A <see cref="string"/> that has the value.</returns>
			public string ToString(HPROCESS hProc)
			{
				using var mem = new SafeCoTaskMemString(MaximumLength);
				return ReadProcessMemory(hProc, Buffer, mem, mem.Size, out _) ? mem : string.Empty;
			}
		}

		/// <summary>The <c>UNICODE_STRING</c> structure is used to define Unicode strings.</summary>
		/// <remarks>
		/// <para>
		/// The <c>UNICODE_STRING</c> structure is used to pass Unicode strings. Use RtlUnicodeStringInit or RtlUnicodeStringInitEx to
		/// initialize a <c>UNICODE_STRING</c> structure.
		/// </para>
		/// <para>If the string is null-terminated, <c>Length</c> does not include the trailing null character.</para>
		/// <para>
		/// The <c>MaximumLength</c> is used to indicate the length of <c>Buffer</c> so that if the string is passed to a conversion routine
		/// such as RtlAnsiStringToUnicodeString the returned string does not exceed the buffer size.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wudfwdm/ns-wudfwdm-_unicode_string typedef struct
		// _UNICODE_STRING { USHORT Length; USHORT MaximumLength; PWCH Buffer; } UNICODE_STRING;
		[PInvokeData("wudfwdm.h", MSDNShortId = "b02f29a9-1049-4e29-aac3-72bf0c70a21e")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct UNICODE_STRING_WOW64
		{
			/// <summary>The length, in bytes, of the string stored in <c>Buffer</c>.</summary>
			public ushort Length;

			/// <summary>The length, in bytes, of <c>Buffer</c>.</summary>
			public ushort MaximumLength;

			/// <summary>Pointer to a wide-character string.</summary>
			public long Buffer;

			/// <summary>Extracts the string value from this structure by reading process specific memory.</summary>
			/// <param name="hProc">The process handle of the process from which to read the memory.</param>
			/// <returns>A <see cref="string"/> that has the value.</returns>
			public string ToString(HPROCESS hProc)
			{
				using var mem = new SafeCoTaskMemString(MaximumLength);
				return NtWow64ReadVirtualMemory64(hProc, Buffer, ((IntPtr)mem).ToInt32(), mem.Size, out _).Succeeded ? mem : string.Empty;
			}
		}

		/// <summary>
		/// Provides an abstraction for both <see cref="UNICODE_STRING"/> and <see cref="UNICODE_STRING_WOW64"/> that converts easily with
		/// <see cref="string"/>.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.SafeHANDLE"/>
		public class SafeUNICODE_STRING : SafeHANDLE
		{
			private readonly int size;

			/// <summary>Initializes a new instance of the <see cref="SafeUNICODE_STRING"/> class with a string value.</summary>
			/// <param name="value">The string value.</param>
			public SafeUNICODE_STRING(string value) : base(IntPtr.Zero, true)
			{
				var structLen = GetStructSize(GetCurrentProcess());
				if (string.IsNullOrEmpty(value))
					SetHandle(Marshal.AllocCoTaskMem(size = structLen));
				else
					SetHandle(InitMemForString(value, structLen, out size));
			}

			internal SafeUNICODE_STRING(IntPtr ptr, bool own) : base(ptr, own)
			{
			}

			private SafeUNICODE_STRING() : base()
			{
			}

			/// <summary>The length, in bytes, of the string stored in <c>Buffer</c>.</summary>
			public ushort Length => IsInvalid ? (ushort)0 : unchecked((ushort)Marshal.ReadInt16(handle, 0));

			/// <summary>The length, in bytes, of <c>Buffer</c>.</summary>
			public ushort MaximumLength => IsInvalid ? (ushort)0 : unchecked((ushort)Marshal.ReadInt16(handle, 2));

			/// <summary>The size of the allocated memory holding the structure and the string.</summary>
			public int Size => size;

			/// <summary>Performs an implicit conversion from <see cref="string"/> to <see cref="SafeUNICODE_STRING"/>.</summary>
			/// <param name="value">The string value.</param>
			/// <returns>The resulting <see cref="SafeUNICODE_STRING"/> instance from the conversion.</returns>
			public static implicit operator SafeUNICODE_STRING(string value) => new(value);

			/// <summary>Performs an implicit conversion from <see cref="SafeUNICODE_STRING"/> to <see cref="string"/>.</summary>
			/// <param name="value">The value.</param>
			/// <returns>The resulting <see cref="string"/> instance from the conversion.</returns>
			public static implicit operator string(SafeUNICODE_STRING value) => value?.ToString(default);

			/// <summary>Extracts the string value from this structure by reading process specific memory.</summary>
			/// <param name="hProc">The process handle of the process from which to read the memory.</param>
			/// <returns>A <see cref="string"/> that has the value.</returns>
			public string ToString(HPROCESS hProc)
			{
				if (IsInvalid) return null;
				var maxlen = unchecked((ushort)Marshal.ReadInt16(handle, 2));
				hProc = hProc == default ? GetCurrentProcess() : hProc;
				var bufOffset = GetBufferOffset(hProc);
				var bufPtr = Marshal.ReadIntPtr(handle, bufOffset);
				if (hProc == GetCurrentProcess())
					return StringHelper.GetString(bufPtr, CharSet.Unicode, MaximumLength) ?? string.Empty;
				using var mem = new SafeCoTaskMemString(maxlen);
				if (hProc.IsWow64())
					return NtWow64ReadVirtualMemory64(hProc, bufPtr.ToInt64(), ((IntPtr)mem).ToInt32(), mem.Size, out _).Succeeded ? mem : string.Empty;
				return ReadProcessMemory(hProc, bufPtr, mem, mem.Size, out _) ? mem : string.Empty;
			}

			/// <summary>Extracts the string value from this structure by reading process specific memory.</summary>
			/// <returns>A <see cref="string"/> that has the value.</returns>
			public override string ToString() => ToString(default);

			internal static int GetStructSize(HPROCESS hProc) => Marshal.SizeOf(hProc.IsWow64() ? typeof(UNICODE_STRING_WOW64) : typeof(UNICODE_STRING));

			internal static int GetBufferOffset(HPROCESS hProc) => Marshal.OffsetOf(hProc.IsWow64() ? typeof(UNICODE_STRING_WOW64) : typeof(UNICODE_STRING), "Buffer").ToInt32();

			internal static IntPtr InitMemForString(string value, int structLen, out int allocatedSize)
			{
				// Collect lengths
				var strLen = StringHelper.GetByteCount(value, true, CharSet.Unicode);

				// Create mem and append string after struct
				IntPtr mem = Marshal.AllocCoTaskMem(allocatedSize = structLen + strLen);
				IntPtr strOffset = mem.Offset(structLen);
				Marshal.WriteInt16(mem, 0, (short)(strLen - 2));
				Marshal.WriteInt16(mem, 2, (short)strLen);
				StringHelper.Write(value, strOffset, out _, true, CharSet.Unicode, strLen);
				Marshal.WriteIntPtr(mem, GetBufferOffset(GetCurrentProcess()), strOffset);
				return mem;
			}

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { Marshal.FreeCoTaskMem(handle); return true; }
		}

		/// <summary>A custom marshaler for functions using UNICODE_STRING so that managed strings can be used.</summary>
		/// <seealso cref="ICustomMarshaler"/>
		internal class UnicodeStringMarshaler : ICustomMarshaler
		{
			public static ICustomMarshaler GetInstance(string _) => new UnicodeStringMarshaler();

			void ICustomMarshaler.CleanUpManagedData(object ManagedObj)
			{
			}

			void ICustomMarshaler.CleanUpNativeData(IntPtr pNativeData) => Marshal.FreeCoTaskMem(pNativeData);

			int ICustomMarshaler.GetNativeDataSize() => SafeUNICODE_STRING.GetStructSize(GetCurrentProcess());

			IntPtr ICustomMarshaler.MarshalManagedToNative(object ManagedObj) => ManagedObj is string s ? SafeUNICODE_STRING.InitMemForString(s, SafeUNICODE_STRING.GetStructSize(GetCurrentProcess()), out _) : IntPtr.Zero;

			object ICustomMarshaler.MarshalNativeToManaged(IntPtr pNativeData) => new SafeUNICODE_STRING(pNativeData, false).ToString();
		}

		/*
		RtlAppendUnicodeStringToString
		RtlCompareUnicodeString
		RtlConvertSidToUnicodeString
		RtlCopyUnicodeString
		RtlCreateUnicodeString
		RtlDowncaseUnicodeString
		RtlEqualUnicodeString
		RtlFreeUnicodeString
		RtlHashUnicodeString
		RtlInt64ToUnicodeString
		RtlIntegerToUnicodeString
		RtlOemStringToUnicodeString
		RtlPrefixUnicodeString
		RtlUnicodeStringToAnsiString
		RtlUnicodeStringToCountedOemString
		RtlUnicodeStringToInteger
		RtlUnicodeStringToOemString
		RtlUpcaseUnicodeString
		RtlUpcaseUnicodeStringToCountedOemString
		RtlUpcaseUnicodeStringToOemString
		*/
	}
}