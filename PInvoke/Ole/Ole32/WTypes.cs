using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.InteropServices;

// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	/// <summary>Platform invokable enumerated types, constants and functions from ole32.h</summary>
	public static partial class Ole32
	{
		/// <summary>
		/// Indicates whether the method should try to return a name in the pwcsName member of the STATSTG structure. The values are used in the
		/// ILockBytes::Stat, IStorage::Stat, and IStream::Stat methods to save memory when the pwcsName member is not required.
		/// </summary>
		[PInvokeData("WTypes.h", MSDNShortId = "aa380316")]
		public enum STATFLAG
		{
			/// <summary>Requests that the statistics include the pwcsName member of the STATSTG structure.</summary>
			STATFLAG_DEFAULT = 0,

			/// <summary>
			/// Requests that the statistics not include the pwcsName member of the STATSTG structure. If the name is omitted, there is no need for the
			/// ILockBytes::Stat, IStorage::Stat, and IStream::Stat methods to allocate and free memory for the string value of the name, therefore the
			/// method reduces time and resources used in an allocation and free operation.
			/// </summary>
			STATFLAG_NONAME = 1,

			/// <summary>Not implemented.</summary>
			STATFLAG_NOOPEN = 2
		}

		/// <summary>Specify the conditions for performing the commit operation in the IStorage::Commit and IStream::Commit methods.</summary>
		[PInvokeData("WTypes.h", MSDNShortId = "aa380320")]
		public enum STGC
		{
			/// <summary>
			/// You can specify this condition with STGC_CONSOLIDATE, or some combination of the other three flags in this list of elements. Use this value to
			/// increase the readability of code.
			/// </summary>
			STGC_DEFAULT = 0,

			/// <summary>
			/// The commit operation can overwrite existing data to reduce overall space requirements. This value is not recommended for typical usage because it
			/// is not as robust as the default value. In this case, it is possible for the commit operation to fail after the old data is overwritten, but
			/// before the new data is completely committed. Then, neither the old version nor the new version of the storage object will be intact.
			/// <para>You can use this value in the following cases:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>The user is willing to risk losing the data.</term>
			/// </item>
			/// <item>
			/// <term>The low-memory save sequence will be used to safely save the storage object to a smaller file.</term>
			/// </item>
			/// <item>
			/// <term>
			/// A previous commit returned STG_E_MEDIUMFULL, but overwriting the existing data would provide enough space to commit changes to the storage object.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// Be aware that the commit operation verifies that adequate space exists before any overwriting occurs. Thus, even with this value specified, if
			/// the commit operation fails due to space requirements, the old data is safe. It is possible, however, for data loss to occur with the
			/// STGC_OVERWRITE value specified if the commit operation fails for any reason other than lack of disk space.
			/// </para>
			/// </summary>
			STGC_OVERWRITE = 1,

			/// <summary>
			/// Prevents multiple users of a storage object from overwriting each other's changes. The commit operation occurs only if there have been no changes
			/// to the saved storage object because the user most recently opened it. Thus, the saved version of the storage object is the same version that the
			/// user has been editing. If other users have changed the storage object, the commit operation fails and returns the STG_E_NOTCURRENT value. To
			/// override this behavior, call the IStorage::Commit or IStream::Commit method again using the STGC_DEFAULT value.
			/// </summary>
			STGC_ONLYIFCURRENT = 2,

			/// <summary>
			/// Commits the changes to a write-behind disk cache, but does not save the cache to the disk. In a write-behind disk cache, the operation that
			/// writes to disk actually writes to a disk cache, thus increasing performance. The cache is eventually written to the disk, but usually not until
			/// after the write operation has already returned. The performance increase comes at the expense of an increased risk of losing data if a problem
			/// occurs before the cache is saved and the data in the cache is lost.
			/// <para>
			/// If you do not specify this value, then committing changes to root-level storage objects is robust even if a disk cache is used. The two-phase
			/// commit process ensures that data is stored on the disk and not just to the disk cache.
			/// </para>
			/// </summary>
			STGC_DANGEROUSLYCOMMITMERELYTODISKCACHE = 4,

			/// <summary>
			/// Windows 2000 and Windows XP: Indicates that a storage should be consolidated after it is committed, resulting in a smaller file on disk. This
			/// flag is valid only on the outermost storage object that has been opened in transacted mode. It is not valid for streams. The STGC_CONSOLIDATE
			/// flag can be combined with any other STGC flags.
			/// </summary>
			STGC_CONSOLIDATE = 8
		}

		/// <summary>Indicate whether a storage element is to be moved or copied. They are used in the IStorage::MoveElementTo method.</summary>
		[PInvokeData("WTypes.h", MSDNShortId = "aa380336")]
		public enum STGMOVE
		{
			/// <summary>Indicates that the method should move the data from the source to the destination.</summary>
			STGMOVE_MOVE = 0,

			/// <summary>
			/// Indicates that the method should copy the data from the source to the destination. A copy is the same as a move except that the source element is
			/// not removed after copying the element to the destination. Copying an element on top of itself is undefined.
			/// </summary>
			STGMOVE_COPY = 1,

			/// <summary>Not implemented.</summary>
			STGMOVE_SHALLOWCOPY = 2
		}

		/// <summary>Equivalent to <see cref="VarEnum" />, but cast to <see cref="ushort" />.</summary>
		[Flags]
		[PInvokeData("Wtypes.h", MSDNShortId = "ms221127")]
		public enum VARTYPE : ushort
		{
			/// <summary>Not specified.</summary>
			[CorrespondingType(typeof(object))]
			VT_EMPTY = 0,
			/// <summary>Null.</summary>
			[CorrespondingType(typeof(DBNull))]
			VT_NULL = 1,
			/// <summary>A 2-byte integer.</summary>
			[CorrespondingType(typeof(short))]
			VT_I2 = 2,
			/// <summary>A 4-byte integer.</summary>
			[CorrespondingType(typeof(int))]
			VT_I4 = 3,
			/// <summary>A 4-byte real.</summary>
			[CorrespondingType(typeof(float))]
			VT_R4 = 4,
			/// <summary>A 8-byte real.</summary>
			[CorrespondingType(typeof(double))]
			VT_R8 = 5,
			/// <summary>Currency</summary>
			[CorrespondingType(typeof(decimal))]
			VT_CY = 6,
			/// <summary>A date.</summary>
			[CorrespondingType(typeof(DateTime))]
			VT_DATE = 7,
			/// <summary>A string.</summary>
			[CorrespondingType(typeof(string))]
			VT_BSTR = 8,
			/// <summary>An IDispatch pointer.</summary>
			[CorrespondingType(typeof(object))]
			VT_DISPATCH = 9,
			/// <summary>An SCODE value.</summary>
			[CorrespondingType(typeof(Win32Error))]
			VT_ERROR = 10,
			/// <summary>A Boolean value. True is -1 and false is 0.</summary>
			[CorrespondingType(typeof(bool))]
			VT_BOOL = 11,
			/// <summary>A variant pointer.</summary>
			[CorrespondingType(typeof(object))]
			VT_VARIANT = 12,
			/// <summary>An IUnknown pointer.</summary>
			[CorrespondingType(typeof(object))]
			VT_UNKNOWN = 13,
			/// <summary>A 16-byte fixed-point value.</summary>
			[CorrespondingType(typeof(decimal))]
			VT_DECIMAL = 14,
			/// <summary>A character.</summary>
			[CorrespondingType(typeof(sbyte))]
			VT_I1 = 16,
			/// <summary>An unsigned character.</summary>
			[CorrespondingType(typeof(byte))]
			VT_UI1 = 17,
			/// <summary>An unsigned short.</summary>
			[CorrespondingType(typeof(ushort))]
			VT_UI2 = 18,
			/// <summary>An unsigned long.</summary>
			[CorrespondingType(typeof(uint))]
			VT_UI4 = 19,
			/// <summary>A 64-bit integer.</summary>
			[CorrespondingType(typeof(long))]
			VT_I8 = 20,
			/// <summary>A 64-bit unsigned integer.</summary>
			[CorrespondingType(typeof(ulong))]
			VT_UI8 = 21,
			/// <summary>An integer.</summary>
			[CorrespondingType(typeof(int))]
			VT_INT = 22,
			/// <summary>An unsigned integer.</summary>
			[CorrespondingType(typeof(uint))]
			VT_UINT = 23,
			/// <summary>The vt void</summary>
			[CorrespondingType(typeof(IntPtr))]
			VT_VOID = 24,
			/// <summary>A C-style void.</summary>
			[CorrespondingType(typeof(double))]
			VT_HRESULT = 25,
			/// <summary>A pointer type.</summary>
			[CorrespondingType(typeof(IntPtr))]
			VT_PTR = 26,
			/// <summary>A safe array. Use VT_ARRAY in VARIANT.</summary>
			VT_SAFEARRAY = 27,
			/// <summary>A C-style array.</summary>
			VT_CARRAY = 28,
			/// <summary>A user-defined type.</summary>
			[CorrespondingType(typeof(IntPtr))]
			VT_USERDEFINED = 29,
			/// <summary>A null-terminated string.</summary>
			[CorrespondingType(typeof(string))]
			VT_LPSTR = 30,
			/// <summary>A wide null-terminated string.</summary>
			[CorrespondingType(typeof(string))]
			VT_LPWSTR = 31,
			/// <summary>A user-defined type.</summary>
			[CorrespondingType(typeof(IntPtr))]
			VT_RECORD = 36,
			/// <summary>A FILETIME value.</summary>
			[CorrespondingType(typeof(System.Runtime.InteropServices.ComTypes.FILETIME))]
			VT_FILETIME = 64,
			/// <summary>Length-prefixed bytes.</summary>
			[CorrespondingType(typeof(BLOB))]
			VT_BLOB = 65,
			/// <summary>The name of the stream follows.</summary>
			[CorrespondingType(typeof(IStream))]
			VT_STREAM = 66,
			/// <summary>The name of the storage follows.</summary>
			[CorrespondingType(typeof(IStorage))]
			VT_STORAGE = 67,
			/// <summary>The stream contains an object.</summary>
			[CorrespondingType(typeof(IStream))]
			VT_STREAMED_OBJECT = 68,
			/// <summary>The storage contains an object.</summary>
			[CorrespondingType(typeof(IStorage))]
			VT_STORED_OBJECT = 69,
			/// <summary>The blob contains an object.</summary>
			VT_BLOB_OBJECT = 70,
			/// <summary>A clipboard format.</summary>
			[CorrespondingType(typeof(CLIPDATA))]
			VT_CF = 71,
			/// <summary>A class ID.</summary>
			[CorrespondingType(typeof(Guid))]
			VT_CLSID = 72,
			/// <summary>A stream with a GUID version.</summary>
			VT_VERSIONED_STREAM = 73,
			/// <summary>A simple counted array.</summary>
			VT_VECTOR = 0x1000,
			/// <summary>A SAFEARRAY pointer.</summary>
			VT_ARRAY = 0x2000,
			/// <summary>A void pointer for local use.</summary>
			VT_BYREF = 0x4000,
		}
	}
}