using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class SetupAPI
	{
		/// <summary>Indicates the property store.</summary>
		[PInvokeData("Devpropdef.h")]
		public enum DEVPROPSTORE
		{
			/// <summary/>
			DEVPROP_STORE_SYSTEM,

			/// <summary/>
			DEVPROP_STORE_USER
		}

		/// <summary>
		/// <para>
		/// In Windows Vista and later versions of Windows, the DEVPROPTYPE data type represents the property-data-type identifier that
		/// specifies the data type of a device property value in the unified device property model.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A property-data-type identifier represents a combination of a <c>base data type</c> and a <c>property-data-type modifier</c>. A
		/// property-data-type identifier is property-specific, and generally can represent a single fixed-length base-data-type value, a
		/// single variable-length base-data-type value, an array of fixed-length base-data-type values, or a list of variable-length
		/// base-data-type values.
		/// </para>
		/// <para>
		/// The device property functions that retrieve or set a device property take a PropertyType parameter that retrieves or supplies
		/// the property-data-type identifier for a device property. For example, <c>SetupDiGetDeviceProperty</c> and
		/// <c>SetupDiSetDeviceProperty</c> retrieve and set a device property for a device instance.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/ff543546(v=vs.85)
		[PInvokeData("Devpropdef.h")]
		[Flags]
		public enum DEVPROPTYPE : uint
		{
			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPEMOD_ARRAY identifier represents a property-data-type
			/// modifier that can be combined with the <c>base-data-type identifiers</c> to create a property-data-type identifier that
			/// represents an array of base-data-type values.
			/// </summary>
			/// <remarks>
			/// <para>
			/// The DEVPROP_TYPEMOD_ARRAY identifier can be combined only with the fixed-length base-data-type identifiers (
			/// <c>DEVPROPTYPE</c> values) that are associated with data. The DEVPROP_TYPEMOD_ARRAY identifier cannot be combined with
			/// <c>DEVPROP_TYPE_EMPTY</c>, <c>DEVPROP_TYPE_NULL</c>, or any of the variable-length base-data-type identifiers.
			/// </para>
			/// <para>
			/// To create a property-data-type identifier that represents an array of base-data-type values, perform a bitwise OR between
			/// DEVPROP_TYPEMOD_ARRAY and the corresponding DEVPROP_TYPE_Xxx identifier. For example, to specify an array of unsigned bytes,
			/// perform the following bitwise OR: (DEVPROP_TYPEMOD_ARRAY | <c>DEVPROP_TYPE_BYTE</c>).
			/// </para>
			/// <para>The size, in bytes, of an array of base-data-type values is the size, in bytes, of the array.</para>
			/// <para>
			/// For information about how to create a property-data-type identifier that represents a REG_MULTI_SZ list of NULL-terminated
			/// Unicode strings, see <c>DEVPROP_TYPEMOD_LIST</c>.
			/// </para>
			/// </remarks>
			DEVPROP_TYPEMOD_ARRAY = 0x00001000,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPEMOD_LIST identifier represents a property-data-type modifier
			/// that can be combined only with the <c>base-data-type identifiers</c><c>DEVPROP_TYPE_STRING</c> and
			/// <c>DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING</c> to create a property-data-type identifier that represents a REG_MULTI_SZ list
			/// of NULL-terminated Unicode strings.
			/// </summary>
			/// <remarks>
			/// <para>
			/// DEVPROP_TYPEMOD_LIST cannot be combined with <c>DEVPROP_TYPE_EMPTY</c>, <c>DEVPROP_TYPE_NULL</c>,
			/// <c>DEVPROP_TYPE_SECURITY_DESCRIPTOR</c>, or any of the fixed length base-data-type identifiers.
			/// </para>
			/// <para>
			/// To create a property-data-type identifier that represents a string list, perform a bitwise OR between the
			/// DEVPROP_TYPEMOD_LIST property-data-type modifier and the corresponding DEVPROP_TYPE_Xxx identifier. For example, to specify
			/// a REG_MULTI_SZ list of Unicode strings, perform the following bitwise OR: (DEVPROP_TYPEMOD_LIST | DEVPROP_TYPE_STRING).
			/// </para>
			/// <para>
			/// The size of a REG_MULTI_SZ list of NULL-terminated Unicode strings is size of the list including the final <c>NULL</c> that
			/// terminated the list.
			/// </para>
			/// <para>
			/// For information about how to create a property-data-type identifier that represents an array of fixed length data values,
			/// see <c>DEVPROP_TYPEMOD_ARRAY</c>.
			/// </para>
			/// </remarks>
			DEVPROP_TYPEMOD_LIST = 0x00002000,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_EMPTY identifier represents a special base-data-type
			/// identifier that indicates that a property does not exist.
			/// </summary>
			/// <remarks>
			/// <para>Use this base-data-type identifier with the device property functions to delete a property.</para>
			/// <para>If a device property function returns this base-data-type identifier, the property does not exist.</para>
			/// <para>
			/// <c>DEVPROP_TYPE_EMPTY</c> cannot be combined with the property-data-type modifiers <c>DEVPROP_TYPEMOD_ARRAY</c> or <c>DEVPROP_TYPEMOD_LIST</c>.
			/// </para>
			/// <para>Deleting a Property</para>
			/// <para>To delete a property, call the corresponding SetupDiSetXxx property function and set the function parameters as follows:</para>
			/// <para>
			/// If DEVPROP_TYPE_EMPTY is used in an attempt to delete a property that does not exist, the delete operation will fail, and a
			/// call to GetLastError will return ERROR_NOT_FOUND.
			/// </para>
			/// <para>Retrieving a Property that Does Not Exist</para>
			/// <para>
			/// A call to a SetupDiGetXxx property function that attempts to retrieve a device property that does not exist will fail, and a
			/// subsequent call to GetLastError will return ERROR_NOT_FOUND. The called SetupAPI property function will set the
			/// *PropertyType parameter to DEVPROP_TYPE_EMPTY.
			/// </para>
			/// </remarks>
			DEVPROP_TYPE_EMPTY = 0x00000000,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_NULL identifier represents a special base-data-type
			/// identifier that indicates that a device property exists. However, that the property has no value that is associated with the property.
			/// </summary>
			/// <remarks>
			/// <para>
			/// Use this base-property-type identifier with the device property functions to delete the value that is associated with a
			/// device property.
			/// </para>
			/// <para>
			/// If a device property function returns this base data type, the property exists, but the property has no value that is
			/// associated with it.
			/// </para>
			/// <para>
			/// The DEVPROP_TYPE_NULL identifier cannot be combined with the property-data-type modifiers <c>DEVPROP_TYPEMOD_ARRAY</c> or <c>DEVPROP_TYPEMOD_LIST</c>.
			/// </para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose data type is DEVPROP_TYPE_NULL, call the corresponding <c>SetupDiSetXxx</c> property function and
			/// set the function parameters as follows:
			/// </para>
			/// <para><c>Retrieving a Property of this Type</c></para>
			/// <para>
			/// A call to a <c>SetupDiGetXxx</c> property function that attempts to retrieve a device property that has no value will
			/// succeed and set the *PropertyType parameter to DEVPROP_TYPE_NULL.
			/// </para>
			/// </remarks>
			DEVPROP_TYPE_NULL = 0x00000001,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_BYTE identifier represents the base-data-type identifier
			/// that indicates the data type is a SBYTE-typed signed integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_SBYTE can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose data type is DEVPROP_TYPE_BYTE, call the corresponding <c>SetupDiSetXxx</c> property function, and
			/// set the function parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(sbyte))]
			DEVPROP_TYPE_SBYTE = 0x00000002,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_BYTE identifier represents the base-data-type identifier
			/// that indicates the data type is a BYTE-typed unsigned integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_BYTE can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose data type is DEVPROP_TYPE_BYTE, call the corresponding SetupDiSetXxx property function, setting the
			/// function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(byte))]
			DEVPROP_TYPE_BYTE = 0x00000003,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_INT16 identifier represents the base-data-type identifier
			/// that indicates the data type is a SHORT-typed signed integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_SHORT can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_INT16, call the corresponding <c>SetupDiSetXxx</c> property function
			/// and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(short))]
			DEVPROP_TYPE_INT16 = 0x00000004,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_UINT16 identifier represents the base-data-type identifier
			/// that indicates that the data type is a USHORT-typed unsigned integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_UINT16 can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_UINT16, call the corresponding <c>SetupDiSetXxx</c> property function
			/// and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(ushort))]
			DEVPROP_TYPE_UINT16 = 0x00000005,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_INT32 identifier represents the base-data-type identifier
			/// that indicates that the data type is a LONG-typed signed integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_INT32 can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_INT32, call the corresponding <c>SetupDiSetXxx</c> property function,
			/// setting the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(int))]
			DEVPROP_TYPE_INT32 = 0x00000006,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_UINT32 identifier represents the base-data-type identifier
			/// that indicates that the data type is a ULONG-typed unsigned integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_UINT32 can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_UINT32, call the corresponding <c>SetupDiSetXxx</c> property function
			/// and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(uint))]
			DEVPROP_TYPE_UINT32 = 0x00000007,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_INT64 identifier represents the base-data-type identifier
			/// that indicates that the data type is a LONG64-typed signed integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_INT64 can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_INT64, call the corresponding <c>SetupDiSetXxx</c> property function
			/// and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(long))]
			DEVPROP_TYPE_INT64 = 0x00000008,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_INT64 identifier represents the base-data-type identifier
			/// that indicates that the data type is a ULONG64-typed unsigned integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_UINT64 can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_UINT64, call the corresponding <c>SetupDiSetXxx</c> property function
			/// and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(ulong))]
			DEVPROP_TYPE_UINT64 = 0x00000009,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_INT64 identifier represents the base-data-type identifier
			/// that indicates that the data type is a FLOAT-typed IEEE floating-point number.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_FLOAT can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_FLOAT, call the corresponding SetupDiSetXxx property function,
			/// setting the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(float))]
			DEVPROP_TYPE_FLOAT = 0x0000000A,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_DOUBLE identifier represents the base-data-type identifier
			/// that indicates that the data type is a DOUBLE-typed IEEE floating-point number.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_DOUBLE can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_DOUBLE, call the corresponding SetupDiSetXxx property function and
			/// set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(double))]
			DEVPROP_TYPE_DOUBLE = 0x0000000B,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_INT64 identifier represents the base-data-type identifier
			/// that indicates that the data type is a DECIMAL-typed value.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_DECIMAL can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose data type is DEVPROP_TYPE_DECIMAL, call the corresponding SetupDiSetXxx property function and set
			/// the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(DECIMAL))]
			DEVPROP_TYPE_DECIMAL = 0x0000000C,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_GUID identifier represents the base-data-type identifier
			/// that indicates that the data type is a GUID-typed globally unique identifier (GUID).
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_GUID can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_GUID, call the corresponding SetupDiSetXxx property function and set
			/// the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(Guid))]
			DEVPROP_TYPE_GUID = 0x0000000D,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_CURRENCY identifier represents the base-data-type
			/// identifier that indicates that the data type is a CURRENCY-typed value.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_CURRENCY can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of This Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_CURRENCY, call the corresponding SetupDiSetXxx property function and
			/// set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(CY))]
			DEVPROP_TYPE_CURRENCY = 0x0000000E,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_DATE property type represents the base-data-type identifier
			/// that indicates that the data type is a DOUBLE-typed value that specifies the number of days since December 31, 1899. For
			/// example, January 1, 1900, is 1.0; January 2, 1900, is 2.0; and so on.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_DATE can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_DATE, call the corresponding SetupDiSetXxx property function and set
			/// the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(DATE))]
			DEVPROP_TYPE_DATE = 0x0000000F,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_FILETIME property type represents the base-data-type
			/// identifier that indicates that the data type is a FILETIME-typed value.
			/// </summary>
			/// <remarks>
			/// <para>We recommend that all time values be represented in Coordinated Universal Time (UTC) units.</para>
			/// <para>DEVPROP_TYPE_FILETIME can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_FILETIME, call the corresponding SetupDiSetXxx property function and
			/// set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(FILETIME))]
			DEVPROP_TYPE_FILETIME = 0x00000010,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_BOOLEAN property type represents the base-data-type
			/// identifier that indicates that the data type is a DEVPROP_BOOLEAN-typed Boolean value.
			/// </summary>
			/// <remarks>
			/// <para>The DEVPROP_BOOLEAN data type and valid Boolean values are defined as follows:</para>
			/// <para>
			/// <code>typedef CHAR DEVPROP_BOOLEAN, *PDEVPROP_BOOLEAN; #define DEVPROP_TRUE ((DEVPROP_BOOLEAN)-1) #define DEVPROP_FALSE ((DEVPROP_BOOLEAN) 0)</code>
			/// </para>
			/// <para>DEVPROP_TYPE_BOOLEAN can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_BOOLEAN, call the corresponding SetupDiSetXxx property function and
			/// set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(BOOLEAN))]
			DEVPROP_TYPE_BOOLEAN = 0x00000011,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_STRING property type represents the base-data-type
			/// identifier that indicates that the data type is a NULL-terminated Unicode string.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_STRING can be combined only with the <c>DEVPROP_TYPEMOD_LIST</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_STRING, call the corresponding <c>SetupDiSetXxx</c> property
			/// function, setting the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(string))]
			DEVPROP_TYPE_STRING = 0x00000012,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_STRING_LIST property type represents the base-data-type
			/// identifier that indicates that the data type is a REG_MULTI_SZ-typed list of Unicode strings.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_STRING_LIST cannot be combined with the property-data-type modifiers.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_STRING_LIST, call the corresponding <c>SetupDiSetXxx</c> property
			/// function and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(System.Collections.Generic.IEnumerable<string>))]
			DEVPROP_TYPE_STRING_LIST = DEVPROP_TYPE_STRING | DEVPROP_TYPEMOD_LIST,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_SECURITY_DESCRIPTOR identifier represents the
			/// base-data-type identifier that indicates the data type is a variable-length, self-relative, SECURITY_DESCRIPTOR-typed,
			/// security descriptor.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_SECURITY_DESCRIPTOR cannot be combined with the property-data-type modifiers.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_SECURITY_DESCRIPTOR, call the corresponding <c>SetupDiSetXxx</c>
			/// property function and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			DEVPROP_TYPE_SECURITY_DESCRIPTOR = 0x00000013,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING identifier represents the
			/// base-data-type identifier that indicates the data type is a NULL-terminated Unicode string that contains a security
			/// descriptor in the Security Descriptor Definition Language (SDDL) format.
			/// </summary>
			/// <remarks>
			/// <para>
			/// DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING can be combined only with the <c>DEVPROP_TYPEMOD_LIST</c> property-data-type modifier.
			/// </para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING, call the corresponding
			/// <c>SetupDiSetXxx</c> property function and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(string))]
			DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING = 0x00000014,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_DEVPROPKEY identifier represents the base-data-type
			/// identifier that indicates the data type is a DEVPROPKEY-typed device property key.
			/// </summary>
			/// <remarks>
			/// <para>
			/// The DEVPROP_TYPE_DEVPROPKEY property type can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.
			/// </para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_DEVPROPKEY, call the corresponding SetupDiSetXxx property function
			/// and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(DEVPROPKEY))]
			DEVPROP_TYPE_DEVPROPKEY = 0x00000015,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_DEVPROPTYPE identifier represents the base-data-type
			/// identifier that indicates the data type is a DEVPROPTYPE-typed value.
			/// </summary>
			/// <remarks>
			/// <para>
			/// The DEVPROP_TYPE_DEVPROPTYPE property type can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.
			/// </para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_DEVPROPTYPE, call the corresponding SetupDiSetXxx property function,
			/// setting the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(DEVPROPTYPE))]
			DEVPROP_TYPE_DEVPROPTYPE = 0x00000016,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_BINARY identifier represents the base-data-type identifier
			/// that indicates that the data type is an array of BYTE-typed unsigned values.
			/// </summary>
			/// <remarks>
			/// <para>The DEVPROP_TYPE_BINARY property type cannot be combined with the property-data-type modifiers.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_BINARY, call the corresponding SetupDiSetXxx property function and
			/// set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(byte[]))]
			DEVPROP_TYPE_BINARY = DEVPROP_TYPE_BYTE | DEVPROP_TYPEMOD_ARRAY,

			/// <summary>
			/// The DEVPROP_TYPE_ERROR identifier represents the base-data-type identifier for the Microsoft Win32 error code values that
			/// are defined in WINERROR.H.
			/// </summary>
			/// <remarks>
			/// <para>
			/// In Windows Vista and later versions of Windows, the unified device property model also defines a
			/// <c>DEVPROP_TYPE_NTSTATUS</c> base-data-type identifier for NTSTATUS error code values.
			/// </para>
			/// <para>You can combine DEVPROP_TYPE_ERROR only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of This Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_ERROR, call the corresponding SetupDiSetXxx property function and set
			/// the function input parameters as follows:
			/// </para>
			/// <para>Retrieving the Descriptive Text for a Win32 Error Code Value</para>
			/// <para>
			/// To retrieve the descriptive text that is associated with a Win32 error code, call the <c>FormatMessage</c> function
			/// (documented in the Windows SDK) as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(Win32Error))]
			DEVPROP_TYPE_ERROR = 0x00000017,

			/// <summary>
			/// The DEVPROP_TYPE_NTSTATUS identifier represents the base-data-type identifier for the NTSTATUS status code values that are
			/// defined in Ntstatus.h.
			/// </summary>
			/// <remarks>
			/// <para>
			/// In Windows Vista and later versions of Windows, the unified device property model also defines a <c>DEVPROP_TYPE_ERROR</c>
			/// base-data-type identifier for Microsoft Win32 error code values.
			/// </para>
			/// <para>You can combine DEVPROP_TYPE_NTSTATUS only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of This Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_NTSTATUS, call the corresponding <c>SetupDiSet</c> Xxx property
			/// function and set the function input parameters as follows:
			/// </para>
			/// <para>Retrieving the Descriptive Text for a NTSTATUS Error Code Value</para>
			/// <para>
			/// To retrieve the descriptive text that is associated with an NTSTATUS error code value, call the <c>FormatMessage</c>
			/// function (documented in the Windows SDK) as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(NTStatus))]
			DEVPROP_TYPE_NTSTATUS = 0x00000018,

			/// <summary>
			/// The DEVPROP_TYPE_STRING_INDIRECT identifier represents the base-data-type identifier for a NULL-terminated Unicode string
			/// that contains an indirect string reference.
			/// </summary>
			/// <remarks>
			/// <para>
			/// An indirect string reference describes a string resource that contains the actual string. The indirect string reference can
			/// appear in one of the following formats:
			/// </para>
			/// <para>
			/// <c>@</c>[path <c>\</c>]FileName <c>,-</c> ResourceID Windows extracts the string from the module that is specified by the
			/// path and FileName entries, and the resource identifier of the string is supplied by the ResourceID entry (excluding the
			/// required minus sign). The string resource is loaded from the module resource section that best matches one of the caller's
			/// preferred UI languages. The path entry is optional. If you specify the path entry, the module must be located in a directory
			/// that is in the system-defined search path.
			/// </para>
			/// <para>
			/// <c>@</c> InfName <c>,%</c> strkey <c>%</c> Windows extracts the string from the INF <c>Strings</c> section of the INF file
			/// in the %SystemRoot%\inf directory whose name is supplied by the InfName entry. The strkey token identifier should match the
			/// key of a line in the <c>Strings</c> section that best matches one of the caller's preferred UI languages. If no
			/// language-specific <c>Strings</c> sections exist, Windows uses the default <c>Strings</c> section.
			/// </para>
			/// <para>You cannot combine DEVPROP_TYPE_STRING_INDIRECT with any of the property-data-type modifiers.</para>
			/// <para>Setting a Property of This Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_STRING_INDIRECT, call the corresponding <c>SetupDiSet</c> Xxx
			/// property function and set the function input parameters as follows:
			/// </para>
			/// <para>Retrieving the Value of This Property Type</para>
			/// <para>
			/// When an application calls a <c>SetupDiGet</c> Xxx property function to retrieve the value of a property of this base data
			/// type, Windows tries to locate the actual string that the property references. If Windows can retrieve the actual string, it
			/// returns the actual string to the caller and identifies the base data type of the retrieved property as
			/// <c>DEVPROP_TYPE_STRING</c>. Otherwise, Windows returns the indirect string reference and identifies the base data type of
			/// the retrieved property as DEVPROP_TYPE_STRING_INDIRECT.
			/// </para>
			/// <para>Localizing Static Text</para>
			/// <para>
			/// Starting with Windows Vista you can localize custom and standard string-type PnP static-text properties using resources from
			/// a PE image's string or resource tables by setting static-text property types to DEVPROP_TYPE_STRING_INDIRECT. You can also
			/// add non-localized replacement-string data that can be formatted into the static text.
			/// </para>
			/// <para>
			/// Strings located in a PE image's STRINGTABLE resource (as typically performed by LoadString) should use the following format:
			/// </para>
			/// <para>"@"System32\mydll.dll,-21[;Fallback" String]"</para>
			/// <para>"@System32\mydll.dll,-21[;Fallback String with %1, %2, … to %n[;(Arg1,Arg2,…,ArgN)]]"</para>
			/// <para>
			/// Strings located in a PE images's message-table resource (as typically performed by RtlFindMessage, more commonly used in
			/// drivers) should use the following format:
			/// </para>
			/// <para>"@System32\drivers\mydriver.sys,#21[;Fallback String]"</para>
			/// <para>"@System32\drivers\mydriver.sys,#21[;Fallback String with %1, %2, … to %n[;(Arg1,Arg2,…,ArgN)]]"</para>
			/// <para>
			/// A "Fallback String" is optional but useful because it can be returned if the resource can’t be found or loaded. The fallback
			/// string is also returned to non-interactive system processes that are not impersonating a user, and as such cannot show
			/// localized text to users anyways.
			/// </para>
			/// <para>
			/// This technique enables you to localize static-text pulled from the string or message table resource that best matches the
			/// caller’s locale.
			/// </para>
			/// <para>
			/// Windows will format the trailing arguments into the string (or the fallback string) when they are retrieved from the
			/// respective resource table, much as in the same manner as RtlFormatMessage does.
			/// </para>
			/// <para>
			/// Custom and standard string-type PnP static-text is localized when you set the property by loading the resource from the
			/// component performing the set operation, which typically happens under the system default locale for system-level components.
			/// </para>
			/// <para>Note: PE images can use either resource table type (STRINGTABLE resources, or message-table resources).</para>
			/// </remarks>
			[CorrespondingType(typeof(string))]
			DEVPROP_TYPE_STRING_INDIRECT = 0x00000019,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_MASK_TYPE mask can be combined in a bitwise AND with a
			/// property-data-type identifier to extract the <c>base-data-type identifier</c> from a property-data-type identifier.
			/// </summary>
			/// <remarks>
			/// <para>This mask cannot be used as a base-data-type identifier, a property-data-type modifier, or a property-data-type identifier.</para>
			/// <para>
			/// For information about how to extract the DEVPROP_TYPEMOD_Xxx <c>property-data-type modifier</c> from a property-data-type
			/// identifier, see <c>DEVPROP_MASK_TYPEMOD</c>.
			/// </para>
			/// </remarks>
			DEVPROP_MASK_TYPE = 0x00000FFF,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_MASK_TYPEMOD mask can be combined in a bitwise AND with a
			/// property-data-type identifier to extract the DEVPROP_TYPEMOD_Xxx <c>property-data-type modifier</c> from a
			/// property-data-type identifier.
			/// </summary>
			/// <remarks>
			/// <para>This mask cannot be used as a base-data-type identifier, a property-data-type modifier, or property-data-type identifier.</para>
			/// <para>
			/// For information about how to extract the <c>base-data-type identifier</c> from a property-data-type identifier, see <c>DEVPROP_MASK_TYPE</c>.
			/// </para>
			/// </remarks>
			DEVPROP_MASK_TYPEMOD = 0x0000F000,
		}

		/// <summary>Extracts a value from memory of the type specified.</summary>
		/// <param name="pType">Type of the value to extract.</param>
		/// <param name="mem">The memory handle holding the value.</param>
		/// <returns>An object of the specified type.</returns>
		public static object GetObject(this DEVPROPTYPE pType, ISafeMemoryHandle mem) => GetObject(pType, mem.DangerousGetHandle(), mem.Size);

		/// <summary>Extracts a value from memory of the type specified.</summary>
		/// <param name="pType">Type of the value to extract.</param>
		/// <param name="mem">The pointer to the memory holding the value.</param>
		/// <param name="memSize">Size of the allocated memory.</param>
		/// <returns>An object of the specified type.</returns>
		public static object GetObject(this DEVPROPTYPE pType, IntPtr mem, SizeT memSize)
		{
			switch (pType)
			{
				case DEVPROPTYPE.DEVPROP_TYPE_EMPTY:
				case DEVPROPTYPE.DEVPROP_TYPE_NULL:
					return null;

				case DEVPROPTYPE.DEVPROP_TYPE_SBYTE:
				case DEVPROPTYPE.DEVPROP_TYPE_BYTE:
				case DEVPROPTYPE.DEVPROP_TYPE_INT16:
				case DEVPROPTYPE.DEVPROP_TYPE_UINT16:
				case DEVPROPTYPE.DEVPROP_TYPE_INT32:
				case DEVPROPTYPE.DEVPROP_TYPE_UINT32:
				case DEVPROPTYPE.DEVPROP_TYPE_INT64:
				case DEVPROPTYPE.DEVPROP_TYPE_UINT64:
				case DEVPROPTYPE.DEVPROP_TYPE_FLOAT:
				case DEVPROPTYPE.DEVPROP_TYPE_DOUBLE:
				case DEVPROPTYPE.DEVPROP_TYPE_DECIMAL:
				case DEVPROPTYPE.DEVPROP_TYPE_GUID:
				case DEVPROPTYPE.DEVPROP_TYPE_FILETIME:
				case DEVPROPTYPE.DEVPROP_TYPE_CURRENCY:
				case DEVPROPTYPE.DEVPROP_TYPE_DATE:
				case DEVPROPTYPE.DEVPROP_TYPE_STRING:
				case DEVPROPTYPE.DEVPROP_TYPE_DEVPROPKEY:
				case DEVPROPTYPE.DEVPROP_TYPE_DEVPROPTYPE:
				case DEVPROPTYPE.DEVPROP_TYPE_ERROR:
				case DEVPROPTYPE.DEVPROP_TYPE_NTSTATUS:
				case DEVPROPTYPE.DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING:
				case DEVPROPTYPE.DEVPROP_TYPE_BINARY:
					return mem.Convert(memSize, CorrespondingTypeAttribute.GetCorrespondingTypes(pType).First());

				case DEVPROPTYPE.DEVPROP_TYPE_STRING_LIST:
				case DEVPROPTYPE.DEVPROP_TYPEMOD_LIST | DEVPROPTYPE.DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING:
					return mem.ToStringEnum(CharSet.Auto, 0, memSize).ToArray();

				case DEVPROPTYPE.DEVPROP_TYPE_BOOLEAN:
					return mem.ToStructure<BOOLEAN>(memSize).Value;

				case DEVPROPTYPE.DEVPROP_TYPE_SECURITY_DESCRIPTOR:
					return new System.Security.AccessControl.RawSecurityDescriptor(mem.ToArray<byte>(memSize, 0, memSize), 0);

				case DEVPROPTYPE.DEVPROP_TYPE_STRING_INDIRECT:
					return Environment.ExpandEnvironmentVariables(StringHelper.GetString(mem, CharSet.Auto, memSize));

				default:
					if (pType.IsFlagSet(DEVPROPTYPE.DEVPROP_TYPEMOD_ARRAY))
					{
						var elemtype = CorrespondingTypeAttribute.GetCorrespondingTypes(pType.ClearFlags(DEVPROPTYPE.DEVPROP_TYPEMOD_ARRAY)).First();
						var elemsz = Marshal.SizeOf(elemtype);
						return mem.ToArray(elemtype, memSize / elemsz, 0, memSize);
					}
					break;
			}
			throw new ArgumentException($"Unable to convert to {pType}.");
		}

		/// <summary>Splits the provided <see cref="DEVPROPTYPE"/> value into its parts.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The type and modifier.</returns>
		public static (DEVPROPTYPE type, DEVPROPTYPE mod) Split(this DEVPROPTYPE value) => (value & DEVPROPTYPE.DEVPROP_MASK_TYPE, value & DEVPROPTYPE.DEVPROP_MASK_TYPEMOD);

		/// <summary>Describes a compound key for a device property.</summary>
		// https://docs.microsoft.com/en-us/previous-versions/windows/hardware/drivers/dn315029(v=vs.85) typedef struct _DEVPROPCOMPKEY {
		// DEVPROPKEY Key; DEVPROPSTORE Store; PCWSTR LocaleName; } DEVPROPCOMPKEY, *PDEVPROPCOMPKEY;
		[PInvokeData("Devpropdef.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DEVPROPCOMPKEY
		{
			/// <summary>A <c>DEVPROPKEY</c> structure that represents a key for a property.</summary>
			public DEVPROPKEY Key;

			/// <summary>A <c>DEVPROPSTORE</c>-typed value that indicates the property store. Here are possible values:</summary>
			public DEVPROPSTORE Store;

			/// <summary>A string for the property's locale name.</summary>
			public string LocaleName;
		}

		/// <summary>Describes a property for a software device.</summary>
		// https://docs.microsoft.com/en-us/previous-versions/windows/hardware/drivers/dn315030(v=vs.85) typedef struct _DEVPROPERTY {
		// DEVPROPCOMPKEY CompKey; DEVPROPTYPE Type; ULONG BufferSize; PVOID Buffer; } DEVPROPERTY, *PDEVPROPERTY;
		[PInvokeData("Devpropdef.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DEVPROPERTY
		{
			/// <summary>A DEVPROPCOMPKEY structure that represents a compound key for a property.</summary>
			public DEVPROPCOMPKEY CompKey;

			/// <summary>
			/// A DEVPROPTYPE value that indicates the property type. Valid DEVPROPTYPE values are constructed from base DEVPROP_TYPE_
			/// values, which may be modified by a logical OR with DEVPROP_TYPEMOD_ values, as appropriate.
			/// </summary>
			public DEVPROPTYPE Type;

			/// <summary>The size in bytes of the property in Buffer.</summary>
			public uint BufferSize;

			/// <summary>The buffer that contains the property info.</summary>
			public IntPtr Buffer;
		}

		/// <summary>
		/// In Windows Vista and later versions of Windows, the DEVPROPKEY structure represents a device property key for a device property
		/// in the unified device property model.
		/// </summary>
		/// <remarks>
		/// <para>The DEVPROPKEY structure is part of the unified device property model.</para>
		/// <para>The basic set of system-supplied device property keys are defined in Devpkey.h.</para>
		/// <para>The <c>DEFINE_DEVPROPKEY</c> macro creates an instance of a DEVPROPKEY structure that represents a device property key.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpropkey struct DEVPROPKEY { DEVPROPGUID fmtid; DEVPROPID
		// pid; };
		[PInvokeData("Devpropdef.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DEVPROPKEY : IEquatable<DEVPROPKEY>
		{
			/// <summary>
			/// <para>A DEVPROPGUID-typed value that specifies a property category.</para>
			/// <para>The DEVPROPGUID data type is defined as:</para>
			/// </summary>
			public Guid fmtid;

			/// <summary>
			/// <para>
			/// <c>pid</c> A DEVPROPID-typed value that uniquely identifies the property within the property category. For internal system
			/// reasons, a property identifier must be greater than or equal to two.
			/// </para>
			/// <para>The DEVPROPID data type is defined as:</para>
			/// </summary>
			public uint pid;

			/// <summary>Initializes a new instance of the <see cref="DEVPROPKEY"/> struct.</summary>
			/// <param name="a">Guid value.</param>
			/// <param name="b">Guid value.</param>
			/// <param name="c">Guid value.</param>
			/// <param name="d">Guid value.</param>
			/// <param name="e">Guid value.</param>
			/// <param name="f">Guid value.</param>
			/// <param name="g">Guid value.</param>
			/// <param name="h">Guid value.</param>
			/// <param name="i">Guid value.</param>
			/// <param name="j">Guid value.</param>
			/// <param name="k">Guid value.</param>
			/// <param name="pid">The pid.</param>
			public DEVPROPKEY(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k, uint pid)
			{
				fmtid = new Guid(a, b, c, d, e, f, g, h, i, j, k);
				this.pid = pid;
			}

			/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
			/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
			/// <returns>
			/// <see langword="true"/> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <see langword="false"/>.
			/// </returns>
			public override bool Equals(object obj) => obj is DEVPROPKEY pk && Equals(pk);

			/// <summary>Determines whether the specified <see cref="DEVPROPKEY"/>, is equal to this instance.</summary>
			/// <param name="pk">The property key.</param>
			/// <returns>
			/// <see langword="true"/> if the specified <see cref="DEVPROPKEY"/> is equal to this instance; otherwise, <see langword="false"/>.
			/// </returns>
			public bool Equals(DEVPROPKEY pk) => pk.pid == pid && pk.fmtid == fmtid;

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode() => (pid, fmtid).GetHashCode();

			/// <summary>Performs a lookup of this <see cref="DEVPROPKEY"/> against defined values in this assembly to find a name.</summary>
			/// <returns>The name, if found, otherwise <see langword="null"/>.</returns>
			public string LookupName() => Lookup()?.Name;

			/// <inheritdoc/>
			public override string ToString() => LookupName() ?? $"{fmtid}:{pid}";

			/// <summary>
			/// Tries to determine if the property is read-only by performing a reverse lookup on known keys and, if found, reading its attributes.
			/// </summary>
			/// <param name="readOnly">if set to <see langword="true"/>, the property is known to be read-only.</param>
			/// <returns>If <see langword="true"/>, the known key was found and the <paramref name="readOnly"/> output is valid.</returns>
			public bool TryGetReadOnly(out bool readOnly)
			{
				readOnly = false;
				var fi = Lookup();
				if (fi is null) return false;
				readOnly = !fi.GetCustomAttributes(typeof(CorrespondingTypeAttribute), false).Cast<CorrespondingTypeAttribute>().Any(a => a.Action.IsFlagSet(CorrespondingAction.Set));
				return true;
			}

			private System.Reflection.FieldInfo Lookup()
			{
				var dpkType = GetType();
				var lthis = this;
				return dpkType.DeclaringType.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).
					Where(fi => fi.FieldType == dpkType && lthis.Equals(fi.GetValue(null))).FirstOrDefault();
			}
		}
	}
}