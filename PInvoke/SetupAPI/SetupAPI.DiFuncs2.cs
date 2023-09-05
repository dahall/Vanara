using Microsoft.Win32.SafeHandles;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.AccessControl;

namespace Vanara.PInvoke;

/// <summary>Items from the SetupAPI.dll</summary>
public static partial class SetupAPI
{
	/// <summary>
	/// The <c>SetupDiGetClassProperty</c> function retrieves a device property that is set for a device setup class or a device
	/// interface class.
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to a GUID that identifies the device setup class or device interface class for which to retrieve a device property
	/// that is set for the device class. For information about specifying the class type, see the Flags parameter.
	/// </param>
	/// <param name="PropertyKey">
	/// A pointer to a DEVPROPKEY structure that represents the device property key of the requested device class property.
	/// </param>
	/// <param name="PropertyType">
	/// A pointer to a DEVPROPTYPE-typed variable that receives the property-data-type identifier of the requested device class
	/// property, where the property-data-type identifier is the bitwise OR between a base-data-type identifier and, if the base data
	/// type is modified, a property-data-type modifier.
	/// </param>
	/// <param name="PropertyBuffer">
	/// A pointer to a buffer that receives the requested device class property. <c>SetupDiGetClassProperty</c> retrieves the requested
	/// property value only if the buffer is large enough to hold all the property value data. The pointer can be <c>NULL</c>. If the
	/// pointer is set to <c>NULL</c> and RequiredSize is supplied, <c>SetupDiGetClassProperty</c> returns the size of the device class
	/// property, in bytes, in *RequiredSize.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to <c>NULL</c>, PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to a DWORD-typed variable that receives either the size, in bytes, of the device class property if the device class
	/// property is retrieved or the required buffer size if the buffer is not large enough. This pointer can be set to <c>NULL</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>One of the following values, which specifies whether the class is a device setup class or a device interface class.</para>
	/// <para>DICLASSPROP_INSTALLER</para>
	/// <para>ClassGuid specifies a device setup class. This flag cannot be used with DICLASSPROP_INTERFACE.</para>
	/// <para>DICLASSPROP_INTERFACE</para>
	/// <para>ClassGuid specifies a device interface class. This flag cannot be used with DICLASSPROP_INSTALLER.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// <c>SetupDiGetClassProperty</c> returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c>, and the logged error
	/// can be retrieved by calling GetLastError.
	/// </para>
	/// <para>The following table includes some of the more common error codes that this function might log.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value of Flags is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_CLASS</term>
	/// <term>
	/// The device setup class that is specified by ClassGuid is not valid. This error can occur only if the DICLASSPROP_INSTALLER flag
	/// is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An unspecified parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_REG_PROPERTY</term>
	/// <term>The property key that is supplied by PropertyKey is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_REFERENCE_STRING</term>
	/// <term>The device interface reference string is not valid. This error can be returned if the DICLASSPROP_INTERFACE flag is specified.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>An unspecified internal data value was not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_USER_BUFFER</term>
	/// <term>A user buffer is not valid. One possibility is that PropertyBuffer is NULL, and PropertyBufferSize is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_INTERFACE_CLASS</term>
	/// <term>
	/// The device interface class that is specified by ClassGuid does not exist. This error can occur only if the DICLASSPROP_INTERFACE
	/// flag is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>An internal data buffer that was passed to a system call was too small.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There was not enough system memory available to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>The requested device property does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have Administrator privileges.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>SetupDiGetClassProperty</c> is part of the unified device property model.</para>
	/// <para>SetupAPI supports only a Unicode version of <c>SetupDiGetClassProperty</c>.</para>
	/// <para>A caller of <c>SetupDiGetClassProperty</c> must be a member of the Administrators group to set a device interface property.</para>
	/// <para>
	/// To obtain the device property keys that represent the device properties that are set for a device class on a local computer,
	/// call SetupDiGetClassPropertyKeys.
	/// </para>
	/// <para>To retrieve a device class property on a remote computer, call SetupDiGetClassPropertyEx.</para>
	/// <para>
	/// To set a device class property on a local computer, call SetupDiSetClassProperty <c>,</c> and to set a device class property on
	/// a remote computer, call SetupDiSetClassPropertyEx.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclasspropertyw WINSETUPAPI BOOL
	// SetupDiGetClassPropertyW( const GUID *ClassGuid, const DEVPROPKEY *PropertyKey, DEVPROPTYPE *PropertyType, PBYTE PropertyBuffer,
	// DWORD PropertyBufferSize, PDWORD RequiredSize, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Unicode)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassPropertyW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassProperty(in Guid ClassGuid, in DEVPROPKEY PropertyKey, out DEVPROPTYPE PropertyType,
		[Out, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize, out uint RequiredSize, DICLASSPROP Flags);

	/// <summary>
	/// The <c>SetupDiGetClassPropertyEx</c> function retrieves a class property for a device setup class or a device interface class on
	/// a local or remote computer.
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to a GUID that identifies the device setup class or device interface class for which to retrieve a device property for
	/// the device class. For information about specifying the class type, see the Flags parameter.
	/// </param>
	/// <param name="PropertyKey">
	/// A pointer to a DEVPROPKEY structure that represents the device property key of the requested device class property.
	/// </param>
	/// <param name="PropertyType">
	/// A pointer to a DEVPROPTYPE-typed variable that receives the property-data-type identifier of the requested device class
	/// property, where the property-data-type identifier is the bitwise OR between a base-data-type identifier and, if the base data
	/// type is modified, a property-data-type modifier.
	/// </param>
	/// <param name="PropertyBuffer">
	/// A pointer to a buffer that receives the requested device class property. <c>SetupDiGetClassPropertyEx</c> retrieves the
	/// requested property value only if the buffer is large enough to hold all the property value data. The pointer can be <c>NULL</c>.
	/// If the pointer is set to <c>NULL</c> and RequiredSize is supplied, <c>SetupDiGetClassPropertyEx</c> returns the size of the
	/// device class property, in bytes, in *RequiredSize.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to <c>NULL</c>, PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to a DWORD-typed variable that receives either the size, in bytes, of the device class property if the property is
	/// retrieved or the required buffer size if the buffer is not large enough. This pointer can be set to <c>NULL</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>One of the following values, which specifies whether the class is a device setup class or a device interface class:</para>
	/// <para>DICLASSPROP_INSTALLER</para>
	/// <para>ClassGuid specifies a device setup class. This flag cannot be used with DICLASSPROP_INTERFACE.</para>
	/// <para>DICLASSPROP_INTERFACE</para>
	/// <para>ClassGuid specifies a device interface class. This flag cannot be used with DICLASSPROP_INSTALLER.</para>
	/// </param>
	/// <param name="MachineName">
	/// A pointer to a NULL-terminated string that contains the UNC name, including the "\" prefix, of a computer. The pointer can be
	/// set to <c>NULL</c>. If MachineName is <c>NULL</c>, <c>SetupDiGetClassPropertyEx</c> retrieves the requested device class
	/// property from the local computer.
	/// </param>
	/// <param name="Reserved">This parameter must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>
	/// <c>SetupDiGetClassPropertyEx</c> returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c>, and the logged
	/// error can be retrieved by calling GetLastError.
	/// </para>
	/// <para>The following table includes some of the more common error codes that this function might log.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value of Flags is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_CLASS</term>
	/// <term>
	/// The device setup class that is specified by ClassGuid is not valid. This error can occur only if the DICLASSPROP_INSTALLER flag
	/// is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An unspecified parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_REG_PROPERTY</term>
	/// <term>The property key that is supplied by PropertyKey is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_REFERENCE_STRING</term>
	/// <term>The device interface reference string is not valid. This error can be returned if the DICLASSPROP_INTERFACE flag is specified.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>An unspecified internal data value was not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_USER_BUFFER</term>
	/// <term>A user buffer is not valid. One possibility is that PropertyBuffer is NULL, and PropertyBufferSize is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_MACHINENAME</term>
	/// <term>The computer name that is specified by MachineName is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_INTERFACE_CLASS</term>
	/// <term>
	/// The device interface class that is specified by ClassGuid does not exist. This error can occur only if the DICLASSPROP_INTERFACE
	/// flag is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>An internal data buffer that was passed to a system call was too small.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There was not enough system memory available to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>The requested device property does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have Administrator privileges.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>SetupDiGetClassPropertyEx</c> is part of the unified device property model.</para>
	/// <para>SetupAPI supports only a Unicode version of <c>SetupDiGetClassPropertyEx</c>.</para>
	/// <para>A caller of <c>SetupDiGetClassPropertyEx</c> must be a member of the Administrators group to set a device interface property.</para>
	/// <para>
	/// To obtain the device property keys that represent the device properties that are set for a device class on a remote computer,
	/// call SetupDiGetClassPropertyKeysEx.
	/// </para>
	/// <para>To retrieve a device class property on a local computer, call SetupDiGetClassProperty.</para>
	/// <para>
	/// To set a device class property on a local computer, call SetupDiSetClassProperty <c>,</c> and to set a device class property on
	/// a remote computer, call SetupDiSetClassPropertyEx.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclasspropertyexw WINSETUPAPI BOOL
	// SetupDiGetClassPropertyExW( const GUID *ClassGuid, const DEVPROPKEY *PropertyKey, DEVPROPTYPE *PropertyType, PBYTE
	// PropertyBuffer, DWORD PropertyBufferSize, PDWORD RequiredSize, DWORD Flags, PCWSTR MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Unicode)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassPropertyExW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassPropertyEx(in Guid ClassGuid, in DEVPROPKEY PropertyKey, out DEVPROPTYPE PropertyType,
		[Out, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize, out uint RequiredSize, DICLASSPROP Flags,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? MachineName, [In, Optional] IntPtr Reserved);

	/// <summary>
	/// The <c>SetupDiGetClassPropertyKeys</c> function retrieves an array of the device property keys that represent the device
	/// properties that are set for a device setup class or a device interface class.
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to a GUID that represents a device setup class or a device interface class. <c>SetupDiGetClassPropertyKeys</c>
	/// retrieves an array of the device property keys that represent device properties that are set for the specified class. For
	/// information about specifying the class type, see the Flags parameter.
	/// </param>
	/// <param name="PropertyKeyArray">
	/// A pointer to a buffer that receives an array of DEVPROPKEY-typed values, where each value is a device property key that
	/// represents a device property that is set for the device class. The pointer is optional and can be <c>NULL</c>. For more
	/// information, see the <c>Remarks</c> section later in this topic.
	/// </param>
	/// <param name="PropertyKeyCount">
	/// The size, in DEVPROPKEY-typed values, of the PropertyKeyArray buffer. If PropertyKeyArray is set to <c>NULL</c>,
	/// PropertyKeyCount must be set to zero.
	/// </param>
	/// <param name="RequiredPropertyKeyCount">
	/// A pointer to a DWORD-typed variable that receives the number of requested property keys. The parameter is optional and can be
	/// set to <c>NULL</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// One of the following values, which specifies whether to retrieve property keys for a device setup class or for a device
	/// interface class:
	/// </para>
	/// <para>DICLASSPROP_INSTALLER</para>
	/// <para>ClassGuid specifies a device setup class. This flag cannot be used with DICLASSPROP_INTERFACE.</para>
	/// <para>DICLASSPROP_INTERFACE</para>
	/// <para>ClassGuid specifies a device interface class. This flag cannot be used with DICLASSPROP_INSTALLER.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// <c>SetupDiGetClassPropertyKeys</c> returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c>, and the logged
	/// error can be retrieved by calling GetLastError.
	/// </para>
	/// <para>The following table includes some of the more common error codes that this function might log.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value of Flags is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_CLASS</term>
	/// <term>
	/// If the DICLASSPROP_INSTALLER flag is specified, this error code indicates that the device setup class that is specified by
	/// ClassGuid does not exist.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_REFERENCE_STRING</term>
	/// <term>
	/// The reference string for the device interface that is specified by ClassGuild is not valid. This error can be returned if the
	/// DICLASSPROP_INTERFACE flag is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>An unspecified data value is not valid. One possibility is that the ClassGuid value is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An unspecified parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_USER_BUFFER</term>
	/// <term>A user buffer is not valid. One possibility is that PropertyKeyArray is NULL, and PropertKeyCount is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_INTERFACE_CLASS</term>
	/// <term>
	/// If the DICLASSPROP_INTERFACE flag is specified, this error code indicates that the device interface class that is specified by
	/// ClassGuid does not exist.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICENT_BUFFER</term>
	/// <term>
	/// The PropertyKeyArray buffer is not large enough to hold all the property keys, or an internal data buffer that was passed to a
	/// system call was too small.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There was not enough system memory available to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have Administrator privileges.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>SetupDiGetClassPropertyKeys</c> is part of the unified device property model.</para>
	/// <para>
	/// A caller of <c>SetupDiGetClassPropertyKeys</c> must be a member of the Administrators group to retrieve device property keys for
	/// a device class.
	/// </para>
	/// <para>
	/// If the PropertyKeyArray buffer is not large enough to hold all the requested property keys, <c>SetupDiGetClassPropertyKeys</c>
	/// does not retrieve any property keys and returns ERROR_INSUFFICIENT_BUFFER. If the caller supplied a RequiredPropertyKeyCount
	/// pointer, <c>SetupDiGetClassPropertyKeys</c> sets the value of *RequiredPropertyKeyCount to the required size, in
	/// DEVPROPKEY-typed values, of the PropertyKeyArray buffer.
	/// </para>
	/// <para>
	/// To retrieve a device class property on a local computer, call SetupDiGetClassProperty. To set a device class property on a local
	/// computer, call SetupDiSetClassProperty.
	/// </para>
	/// <para>To retrieve the property keys for a device setup class or device interface class on a remote computer, call SetupDiGetClassPropertyKeysEx.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclasspropertykeys WINSETUPAPI BOOL
	// SetupDiGetClassPropertyKeys( const GUID *ClassGuid, DEVPROPKEY *PropertyKeyArray, DWORD PropertyKeyCount, PDWORD
	// RequiredPropertyKeyCount, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassPropertyKeys")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassPropertyKeys(in Guid ClassGuid,
		[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEVPROPKEY[]? PropertyKeyArray, uint PropertyKeyCount,
		out uint RequiredPropertyKeyCount, DICLASSPROP Flags);

	/// <summary>
	/// The <c>SetupDiGetClassPropertyKeysEx</c> function retrieves an array of the device property keys that represent the device
	/// properties that are set for a device setup class or a device interface class on a local or a remote computer.
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to a GUID that represents a device setup class or a device interface class. <c>SetupDiGetClassPropertyKeysEx</c>
	/// retrieves an array of the device property keys that represent device properties that are set for the specified class. For
	/// information about specifying the class type, see the Flags parameter.
	/// </param>
	/// <param name="PropertyKeyArray">
	/// A pointer to a buffer that receives an array of DEVPROPKEY-typed values, where each value is a device property key that
	/// represents a device property that is set for the device setup class. The pointer is optional and can be <c>NULL</c>. For more
	/// information, see the <c>Remarks</c> section later in this topic.
	/// </param>
	/// <param name="PropertyKeyCount">
	/// The size, in DEVPROPKEY-type values, of the PropertyKeyArray buffer. If PropertyKeyArray is set to <c>NULL</c>, PropertyKeyCount
	/// must be set to zero.
	/// </param>
	/// <param name="RequiredPropertyKeyCount">
	/// A pointer to a DWORD-typed variable that receives the number of requested property keys. The pointer is optional and can be set
	/// to <c>NULL</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// One of the following values, which specifies whether to retrieve class property keys for a device setup class or for a device
	/// interface class.
	/// </para>
	/// <para>DICLASSPROP_INSTALLER</para>
	/// <para>ClassGuid specifies a device setup class. This flag cannot be used with DICLASSPROP_INTERFACE.</para>
	/// <para>DICLASSPROP_INTERFACE</para>
	/// <para>ClassGuid specifies a device interface class. This flag cannot be used with DICLASSPROP_INSTALLER.</para>
	/// </param>
	/// <param name="MachineName">
	/// A pointer to a NULL-terminated string that contains the UNC name, including the "\" prefix, of a computer. The pointer can be
	/// <c>NULL</c>. If the pointer is <c>NULL</c>, <c>SetupDiGetClassPropertyKeysEx</c> retrieves the requested information from the
	/// local computer.
	/// </param>
	/// <param name="Reserved">This parameter must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>
	/// <c>SetupDiGetClassPropertyKeysEx</c> returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c>, and the logged
	/// error can be retrieved by calling GetLastError.
	/// </para>
	/// <para>The following table includes some of the more common error codes that this function might log.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value of Flags is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_CLASS</term>
	/// <term>
	/// If the DICLASSPROP_INSTALLER flag is specified, this error code indicates that the device setup class that is specified by
	/// ClassGuid does not exist.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_REFERENCE_STRING</term>
	/// <term>
	/// The reference string for the device interface that is specified by ClassGuild is not valid. This error might be returned when
	/// the DICLASSPROP_INTERFACE flag is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>An unspecified data value is not valid. One possibility is that the ClassGuid value is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An unspecified parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_USER_BUFFER</term>
	/// <term>A user buffer is not valid. One possibility is that PropertyKeyArray is NULL, and PropertKeyCount is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_MACHINENAME</term>
	/// <term>The computer name that is specified by MachineName is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_INTERFACE_CLASS</term>
	/// <term>
	/// If the DICLASSPROP_INTERFACE flag is specified, this error code indicates that the device interface class that is specified by
	/// ClassGuid does not exist.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICENT_BUFFER</term>
	/// <term>
	/// The PropertyKeyArray buffer is not large enough to hold all the property keys, or an internal data buffer that was passed to a
	/// system call was too small.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There was not enough system memory available to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have Administrator privileges.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>SetupDiGetClassPropertyKeysEx</c> is part of the unified device property model.</para>
	/// <para>
	/// A caller of <c>SetupDiGetClassPropertyKeysEx</c> must be a member of the Administrators group to retrieve device property keys
	/// for a device class.
	/// </para>
	/// <para>
	/// If the PropertyKeyArray buffer is not large enough to hold all the requested property keys, <c>SetupDiGetClassPropertyKeysEx</c>
	/// does not retrieve any property keys and returns ERROR_INSUFFICIENT_BUFFER. If the caller supplied a RequiredPropertyKeyCount
	/// pointer, <c>SetupDiGetClassPropertyKeysEx</c> sets the value of *RequiredPropertyKeyCount to the required size, in
	/// DEVPROPKEY-typed values, of the PropertyKeyArray buffer.
	/// </para>
	/// <para>
	/// To retrieve a device class property on a remote computer, call SetupDiGetClassPropertyEx, and to set a device class property on
	/// a remote computer, call SetupDiSetClassPropertyEx.
	/// </para>
	/// <para>To retrieve the property keys for a device setup class or device interface class on a local computer, call SetupDiGetClassPropertyKeys.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclasspropertykeysexw WINSETUPAPI BOOL
	// SetupDiGetClassPropertyKeysExW( const GUID *ClassGuid, DEVPROPKEY *PropertyKeyArray, DWORD PropertyKeyCount, PDWORD
	// RequiredPropertyKeyCount, DWORD Flags, PCWSTR MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Unicode)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassPropertyKeysExW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassPropertyKeysEx(in Guid ClassGuid,
		[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DEVPROPKEY[]? PropertyKeyArray, uint PropertyKeyCount,
		out uint RequiredPropertyKeyCount, DICLASSPROP Flags, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? MachineName,
		[In, Optional] IntPtr Reserved);

	/// <summary>
	/// The <c>SetupDiGetClassRegistryProperty</c> function retrieves a property for a specified device setup class from the registry.
	/// </summary>
	/// <param name="ClassGuid">A pointer to a GUID representing the device setup class for which a property is to be retrieved.</param>
	/// <param name="Property">
	/// <para>A value that identifies the property to be retrieved. This must be one of the following values:</para>
	/// <para>SPCRP_CHARACTERISTICS</para>
	/// <para>
	/// The function returns flags indicating device characteristics for the class. For a list of characteristics flags, see the
	/// DeviceCharacteristics parameter to IoCreateDevice.
	/// </para>
	/// <para>SPCRP_DEVTYPE</para>
	/// <para>
	/// The function returns a DWORD value that represents the device type for the class. For more information, see Specifying Device Types.
	/// </para>
	/// <para>SPCRP_EXCLUSIVE</para>
	/// <para>
	/// The function returns a DWORD value indicating whether users can obtain exclusive access to devices for this class. The returned
	/// value is one if exclusive access is allowed, or zero otherwise.
	/// </para>
	/// <para>SPCRP_LOWERFILTERS</para>
	/// <para>
	/// (Windows Vista and later) The function returns a REG_MULTI_SZ list of the service names of the lower filter drivers that are
	/// installed for the device setup class.
	/// </para>
	/// <para>SPCRP_SECURITY</para>
	/// <para>
	/// The function returns the device's security descriptor as a SECURITY_DESCRIPTOR structure in self-relative format (described in
	/// the Microsoft Windows SDK documentation).
	/// </para>
	/// <para>SPCRP_SECURITY_SDS</para>
	/// <para>
	/// The function returns the device's security descriptor as a text string. For information about security descriptor strings, see
	/// Security Descriptor Definition Language (Windows). For information about the format of security descriptor strings, see Security
	/// Descriptor Definition Language (Windows).
	/// </para>
	/// <para>SPCRP_UPPERFILTERS</para>
	/// <para>
	/// (Windows Vista and later) The function returns a REG_MULTI_SZ list of the service names of the upper filter drivers that are
	/// installed for the device setup class.
	/// </para>
	/// </param>
	/// <param name="PropertyRegDataType">
	/// A pointer to a variable of type DWORD that receives the property data type as one of the REG_-prefixed registry data types. This
	/// parameter is optional and can be <c>NULL</c>. If this parameter is <c>NULL</c>, S <c>etupDiGetClassRegistryProperty</c> does not
	/// return the data type.
	/// </param>
	/// <param name="PropertyBuffer">A pointer to a buffer that receives the requested property.</param>
	/// <param name="PropertyBufferSize">The size, in bytes, of the PropertyBuffer buffer.</param>
	/// <param name="RequiredSize">
	/// A pointer to a variable of type DWORD that receives the required size, in bytes, of the PropertyBuffer buffer. If the
	/// PropertyBuffer buffer is too small, and RequiredSize is not <c>NULL</c>, the function sets RequiredSize to the minimum buffer
	/// size that is required to receive the requested property.
	/// </param>
	/// <param name="MachineName">
	/// A pointer to a NULL-terminated string that contains the name of a remote system from which to retrieve the specified device
	/// class property. This parameter is optional and can be <c>NULL</c>. If this parameter is <c>NULL</c>, the property is retrieved
	/// from the local system.
	/// </param>
	/// <param name="Reserved">Reserved, must be <c>NULL</c>.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassregistrypropertya WINSETUPAPI BOOL
	// SetupDiGetClassRegistryPropertyA( const GUID *ClassGuid, DWORD Property, PDWORD PropertyRegDataType, PBYTE PropertyBuffer, DWORD
	// PropertyBufferSize, PDWORD RequiredSize, PCSTR MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassRegistryPropertyA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassRegistryProperty(in Guid ClassGuid, SPCRP Property, out REG_VALUE_TYPE PropertyRegDataType,
		[Out, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize, out uint RequiredSize,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? MachineName, [In, Optional] IntPtr Reserved);

	/// <summary>The <c>SetupDiGetCustomDeviceProperty</c> function retrieves a specified custom device property from the registry.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set that contains a device information element that represents the device for which to
	/// retrieve a custom device property.
	/// </param>
	/// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
	/// <param name="CustomPropertyName">A registry value name representing a custom property.</param>
	/// <param name="Flags">
	/// <para>A flag value that indicates how the requested information should be returned. The flag can be zero or one of the following:</para>
	/// <para>DICUSTOMDEVPROP_MERGE_MULTISZ</para>
	/// <para>
	/// If set, the function retrieves both device instance-specific property values and hardware ID-specific property values,
	/// concatenated as a REG_MULTI_SZ-typed string. (For more information, see the <c>Remarks</c> section on this reference page.)
	/// </para>
	/// </param>
	/// <param name="PropertyRegDataType">
	/// A pointer to a variable of type DWORD that receives the data type of the retrieved property. The data type is specified as one
	/// of the REG_-prefixed constants that represents registry data types. This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="PropertyBuffer">A pointer to a buffer that receives requested property information.</param>
	/// <param name="PropertyBufferSize">The size, in bytes, of the PropertyBuffer buffer.</param>
	/// <param name="RequiredSize">
	/// A pointer to a variable of type DWORD that receives the buffer size, in bytes, that is required to receive the requested
	/// information. This parameter is optional and can be <c>NULL</c>. If this parameter is specified,
	/// <c>SetupDiGetCustomDeviceProperty</c> returns the required size, regardless of whether the PropertyBuffer buffer is large enough
	/// to receive the requested information.
	/// </param>
	/// <returns>
	/// If the operation succeeds, <c>SetupDiGetCustomDeviceProperty</c> returns <c>TRUE</c>. Otherwise, the function returns
	/// <c>FALSE</c> and the logged error can be retrieved with a call to GetLastError. If the PropertyBuffer buffer is not large enough
	/// to receive the requested information, <c>SetupDiGetCustomDeviceProperty</c> returns <c>FALSE</c> and a subsequent call to
	/// GetLastError will return ERROR_INSUFFICIENT_BUFFER.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiGetCustomDeviceProperty</c> retrieves device properties that are associated with a single device instance or with all
	/// devices matching a certain hardware ID. (For information about hardware IDs, see Device Identification Strings).
	/// </para>
	/// <para>
	/// Vendors can set properties for a device instance by using INF AddReg directives in INF DDInstall.HW sections and specifying the
	/// <c>HKR</c> registry root.
	/// </para>
	/// <para>Only the system can set properties for hardware IDs. The system supplies an "Icon" property for some hardware IDs.</para>
	/// <para>
	/// The function first checks to see if the specified property exists for the specified device instance. If so, the property's value
	/// is returned. If not, the function checks to see if the property exists for all devices matching the hardware ID of the specified
	/// device instance. If so, the property's value is returned. If DICUSTOMDEVPROP_MERGE_MULTISZ is set in Flags, the function returns
	/// the property values associated with both the device instance and the hardware ID, if they both exist.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetcustomdevicepropertya WINSETUPAPI BOOL
	// SetupDiGetCustomDevicePropertyA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PCSTR CustomPropertyName, DWORD Flags,
	// PDWORD PropertyRegDataType, PBYTE PropertyBuffer, DWORD PropertyBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetCustomDevicePropertyA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetCustomDeviceProperty(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
		[MarshalAs(UnmanagedType.LPTStr)] string CustomPropertyName, DICUSTOMDEVPROP Flags, out REG_VALUE_TYPE PropertyRegDataType,
		[Out, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize, out uint RequiredSize);

	/// <summary>
	/// The <c>SetupDiGetDeviceInfoListClass</c> function retrieves the GUID for the device setup class associated with a device
	/// information set if the set has an associated class.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to the device information set to query.</param>
	/// <param name="ClassGuid">A pointer to variable of type GUID that receives the GUID for the associated class.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the specified device information set does not have an associated class because a class GUID was not specified when the set
	/// was created with SetupDiCreateDeviceInfoList, the function fails. In this case, a call to GetLastError returns ERROR_NO_ASSOCIATED_CLASS.
	/// </para>
	/// <para>
	/// If a device information set is for a remote computer, use SetupDiGetDeviceInfoListDetail to get the associated remote computer
	/// handle and computer name.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinfolistclass WINSETUPAPI BOOL
	// SetupDiGetDeviceInfoListClass( HDEVINFO DeviceInfoSet, LPGUID ClassGuid );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceInfoListClass")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDeviceInfoListClass(HDEVINFO DeviceInfoSet, out Guid ClassGuid);

	/// <summary>
	/// The <c>SetupDiGetDeviceInfoListDetail</c> function retrieves information associated with a device information set including the
	/// class GUID, remote computer handle, and remote computer name.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to the device information set for which to retrieve information.</param>
	/// <param name="DeviceInfoSetDetailData">
	/// A pointer to a caller-initialized SP_DEVINFO_LIST_DETAIL_DATA structure that receives the device information set information.
	/// For more information about this structure, see the following <c>Remarks</c> section.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the parameters are valid, <c>SetupDiGetDeviceInfoListDetail</c> sets values in the DeviceInfoSetDetailData structure (except
	/// for the <c>cbSize</c> field) and returns status NO_ERROR.
	/// </para>
	/// <para>
	/// A caller of <c>SetupDiGetDeviceInfoListDetail</c> must set DeviceInfoSetDetailData. <c>cbSize</c> to
	/// <c>sizeof</c>(SP_DEVINFO_LIST_DETAIL_DATA) or the function will fail and the call to GetLastError will return ERROR_INVALID_USER_BUFFER.
	/// </para>
	/// <para>
	/// If <c>SetupDiGetDeviceInfoListDetail</c> completes successfully, DeviceInfoSetDetailData. <c>ClassGuid</c> contains the class
	/// GUID associated with the device information set or a GUID_NULL structure.
	/// </para>
	/// <para>
	/// If <c>SetupDiGetDeviceInfoListDetail</c> completes successfully and the device information set is for a remote system,
	/// DeviceInfoSetDetailData. <c>RemoteMachineHandle</c> contains the ConfigMgr32 system handle for accessing the remote system and
	/// DeviceInfoSetDetailData. <c>RemoteMachineName</c> contains the name of the remote system. If there is a remote handle for the
	/// device information set, it must be used when calling <c>CM_</c> Xxx <c>_Ex</c> functions because the DevInst handles are
	/// relative to the remote handle.
	/// </para>
	/// <para>
	/// If the device information set is for the local computer, DeviceInfoSetDetailData. <c>RemoteMachineHandle</c> is <c>NULL</c> and
	/// DeviceInfoSetDetailData. <c>RemoteMachineName</c> is an empty string.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinfolistdetaila WINSETUPAPI BOOL
	// SetupDiGetDeviceInfoListDetailA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_LIST_DETAIL_DATA_A DeviceInfoSetDetailData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceInfoListDetailA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDeviceInfoListDetail(HDEVINFO DeviceInfoSet, ref SP_DEVINFO_LIST_DETAIL_DATA DeviceInfoSetDetailData);

	/// <summary>
	/// The <c>SetupDiGetDeviceInstallParams</c> function retrieves device installation parameters for a device information set or a
	/// particular device information element.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to the device information set that contains the device installation parameters to retrieve.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This parameter is
	/// optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiGetDeviceInstallParams</c> retrieves the installation
	/// parameters for the specified device. If this parameter is <c>NULL</c>, the function retrieves the global device installation
	/// parameters that are associated with DeviceInfoSet.
	/// </param>
	/// <param name="DeviceInstallParams">
	/// A pointer to an SP_DEVINSTALL_PARAMS structure that receives the device install parameters. DeviceInstallParams. <c>cbSize</c>
	/// must be set to the size, in bytes, of the structure before calling this function.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinstallparamsa WINSETUPAPI BOOL
	// SetupDiGetDeviceInstallParamsA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DEVINSTALL_PARAMS_A
	// DeviceInstallParams );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceInstallParamsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDeviceInstallParams(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, ref SP_DEVINSTALL_PARAMS DeviceInstallParams);

	/// <summary>
	/// The <c>SetupDiGetDeviceInstallParams</c> function retrieves device installation parameters for a device information set or a
	/// particular device information element.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to the device information set that contains the device installation parameters to retrieve.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This parameter is
	/// optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiGetDeviceInstallParams</c> retrieves the installation
	/// parameters for the specified device. If this parameter is <c>NULL</c>, the function retrieves the global device installation
	/// parameters that are associated with DeviceInfoSet.
	/// </param>
	/// <param name="DeviceInstallParams">
	/// A pointer to an SP_DEVINSTALL_PARAMS structure that receives the device install parameters. DeviceInstallParams. <c>cbSize</c>
	/// must be set to the size, in bytes, of the structure before calling this function.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinstallparamsa WINSETUPAPI BOOL
	// SetupDiGetDeviceInstallParamsA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DEVINSTALL_PARAMS_A
	// DeviceInstallParams );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceInstallParamsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDeviceInstallParams(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData, ref SP_DEVINSTALL_PARAMS DeviceInstallParams);

	/// <summary>
	/// The <c>SetupDiGetDeviceInstanceId</c> function retrieves the device instance ID that is associated with a device information element.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set that contains the device information element that represents the device for which to
	/// retrieve a device instance ID.
	/// </param>
	/// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
	/// <param name="DeviceInstanceId">
	/// A pointer to the character buffer that will receive the NULL-terminated device instance ID for the specified device information
	/// element. For information about device instance IDs, see Device Identification Strings.
	/// </param>
	/// <param name="DeviceInstanceIdSize">The size, in characters, of the DeviceInstanceId buffer.</param>
	/// <param name="RequiredSize">
	/// A pointer to the variable that receives the number of characters required to store the device instance ID.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinstanceida WINSETUPAPI BOOL
	// SetupDiGetDeviceInstanceIdA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSTR DeviceInstanceId, DWORD
	// DeviceInstanceIdSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceInstanceIdA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDeviceInstanceId(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder DeviceInstanceId, uint DeviceInstanceIdSize, out uint RequiredSize);

	/// <summary>The <c>SetupDiGetDeviceInterfaceAlias</c> function returns an alias of a specified device interface.</summary>
	/// <param name="DeviceInfoSet">
	/// A pointer to the device information set that contains the device interface for which to retrieve an alias. This handle is
	/// typically returned by SetupDiGetClassDevs.
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to an SP_DEVICE_INTERFACE_DATA structure that specifies the device interface in DeviceInfoSet for which to retrieve an
	/// alias. This pointer is typically returned by SetupDiEnumDeviceInterfaces.
	/// </param>
	/// <param name="AliasInterfaceClassGuid">A pointer to a GUID that specifies the interface class of the alias to retrieve.</param>
	/// <param name="AliasDeviceInterfaceData">
	/// A pointer to a caller-allocated buffer that contains, on successful return, a completed SP_DEVICE_INTERFACE_DATA structure that
	/// identifies the requested alias. The caller must set AliasDeviceInterfaceData <c>.cbSize</c> to
	/// <c>sizeof</c>(SP_DEVICE_INTERFACE_DATA) before calling this function.
	/// </param>
	/// <returns>
	/// <para>
	/// <c>SetupDiGetDeviceInterfaceAlias</c> returns <c>TRUE</c> if the function completed without error. If the function completed
	/// with an error, <c>FALSE</c> is returned and the error code for the failure can be retrieved by calling GetLastError.
	/// </para>
	/// <para>Possible errors returned by GetLastError are listed in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Invalid DeviceInfoSet or invalid DeviceInterfaceData parameter.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_INTERFACE_DEVICE</term>
	/// <term>There is no alias of class AliasInterfaceClassGuid for the specified device interface.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_USER_BUFFER</term>
	/// <term>Invalid AliasDeviceInterfaceData buffer.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Device interfaces are considered aliases if they are of different interface classes but are supported by the same device and
	/// have identical reference strings.
	/// </para>
	/// <para>
	/// <c>SetupDiGetDeviceInterfaceAlias</c> can be used to locate a device that exposes more than one interface. For example, consider
	/// a disk that can be part of a fault-tolerant volume and can contain encrypted data. The function driver for the disk device could
	/// register a fault-tolerant-volume interface and an encrypted-volume interface. These interfaces are device interface aliases if
	/// the function driver registers them with identical reference strings and they refer to the same device. (The reference strings
	/// will likely be <c>NULL</c> and therefore are equal.)
	/// </para>
	/// <para>
	/// To locate such a multi-interface device, first locate all available devices that expose one of the interfaces, such as the
	/// fault-tolerant-volume interface, using SetupDiGetClassDevs and SetupDiEnumDeviceInterfaces. Then, pass a device with the first
	/// interface (fault-tolerant-volume) to <c>SetupDiGetDeviceInterfaceAlias</c> and request an alias of the other interface class (encrypted-volume).
	/// </para>
	/// <para>
	/// If the requested alias exists but the caller-supplied AliasDeviceInterfaceData buffer is invalid, this function successfully
	/// adds the device interface element to DevInfoSet but returns <c>FALSE</c> for the return value. In this case, GetLastError
	/// returns ERROR_INVALID_USER_BUFFER.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinterfacealias WINSETUPAPI BOOL
	// SetupDiGetDeviceInterfaceAlias( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData, const GUID
	// *AliasInterfaceClassGuid, PSP_DEVICE_INTERFACE_DATA AliasDeviceInterfaceData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceInterfaceAlias")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDeviceInterfaceAlias(HDEVINFO DeviceInfoSet, in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
		in Guid AliasInterfaceClassGuid, ref SP_DEVICE_INTERFACE_DATA AliasDeviceInterfaceData);

	/// <summary>The <c>SetupDiGetDeviceInterfaceDetail</c> function returns details about a device interface.</summary>
	/// <param name="DeviceInfoSet">
	/// A pointer to the device information set that contains the interface for which to retrieve details. This handle is typically
	/// returned by SetupDiGetClassDevs.
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to an SP_DEVICE_INTERFACE_DATA structure that specifies the interface in DeviceInfoSet for which to retrieve details.
	/// A pointer of this type is typically returned by SetupDiEnumDeviceInterfaces.
	/// </param>
	/// <param name="DeviceInterfaceDetailData">
	/// A pointer to an SP_DEVICE_INTERFACE_DETAIL_DATA structure to receive information about the specified interface. This parameter
	/// is optional and can be <c>NULL</c>. This parameter must be <c>NULL</c> if DeviceInterfaceDetailSize is zero. If this parameter
	/// is specified, the caller must set DeviceInterfaceDetailData <c>.cbSize</c> to <c>sizeof</c>(SP_DEVICE_INTERFACE_DETAIL_DATA)
	/// before calling this function. The <c>cbSize</c> member always contains the size of the fixed part of the data structure, not a
	/// size reflecting the variable-length string at the end.
	/// </param>
	/// <param name="DeviceInterfaceDetailDataSize">
	/// <para>
	/// The size of the DeviceInterfaceDetailData buffer. The buffer must be at least ( <c>offsetof</c>(SP_DEVICE_INTERFACE_DETAIL_DATA,
	/// <c>DevicePath</c>) + <c>sizeof</c>(TCHAR)) bytes, to contain the fixed part of the structure and a single <c>NULL</c> to
	/// terminate an empty MULTI_SZ string.
	/// </para>
	/// <para>This parameter must be zero if DeviceInterfaceDetailData is <c>NULL</c>.</para>
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to a variable of type DWORD that receives the required size of the DeviceInterfaceDetailData buffer. This size
	/// includes the size of the fixed part of the structure plus the number of bytes required for the variable-length device path
	/// string. This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to a buffer that receives information about the device that supports the requested interface. The caller must set
	/// DeviceInfoData <c>.cbSize</c> to <c>sizeof</c>(SP_DEVINFO_DATA). This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <c>SetupDiGetDeviceInterfaceDetail</c> returns <c>TRUE</c> if the function completed without error. If the function completed
	/// with an error, <c>FALSE</c> is returned and the error code for the failure can be retrieved by calling GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>Using this function to get details about an interface is typically a two-step process:</para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Get the required buffer size. Call <c>SetupDiGetDeviceInterfaceDetail</c> with a <c>NULL</c> DeviceInterfaceDetailData pointer,
	/// a DeviceInterfaceDetailDataSize of zero, and a valid RequiredSize variable. In response to such a call, this function returns
	/// the required buffer size at RequiredSize and fails with GetLastError returning ERROR_INSUFFICIENT_BUFFER.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Allocate an appropriately sized buffer and call the function again to get the interface details.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The interface detail returned by this function consists of a device path that can be passed to Win32 functions such as
	/// CreateFile. Do not attempt to parse the device path symbolic name. The device path can be reused across system starts.
	/// </para>
	/// <para>
	/// <c>SetupDiGetDeviceInterfaceDetail</c> can be used to get just the DeviceInfoData. If the interface exists but
	/// DeviceInterfaceDetailData is <c>NULL</c>, this function fails, GetLastError returns ERROR_INSUFFICIENT_BUFFER, and the
	/// DeviceInfoData structure is filled with information about the device that exposes the interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinterfacedetaila WINSETUPAPI BOOL
	// SetupDiGetDeviceInterfaceDetailA( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
	// PSP_DEVICE_INTERFACE_DETAIL_DATA_A DeviceInterfaceDetailData, DWORD DeviceInterfaceDetailDataSize, PDWORD RequiredSize,
	// PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceInterfaceDetailA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDeviceInterfaceDetail(HDEVINFO DeviceInfoSet, in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
		[Out, Optional] IntPtr DeviceInterfaceDetailData, uint DeviceInterfaceDetailDataSize, out uint RequiredSize, ref SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>The <c>SetupDiGetDeviceInterfaceDetail</c> function returns details about a device interface.</summary>
	/// <param name="DeviceInfoSet">
	/// A pointer to the device information set that contains the interface for which to retrieve details. This handle is typically
	/// returned by SetupDiGetClassDevs.
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to an SP_DEVICE_INTERFACE_DATA structure that specifies the interface in DeviceInfoSet for which to retrieve details.
	/// A pointer of this type is typically returned by SetupDiEnumDeviceInterfaces.
	/// </param>
	/// <param name="DeviceInterfaceDetailData">
	/// A pointer to an SP_DEVICE_INTERFACE_DETAIL_DATA structure to receive information about the specified interface. This parameter
	/// is optional and can be <c>NULL</c>. This parameter must be <c>NULL</c> if DeviceInterfaceDetailSize is zero. If this parameter
	/// is specified, the caller must set DeviceInterfaceDetailData <c>.cbSize</c> to <c>sizeof</c>(SP_DEVICE_INTERFACE_DETAIL_DATA)
	/// before calling this function. The <c>cbSize</c> member always contains the size of the fixed part of the data structure, not a
	/// size reflecting the variable-length string at the end.
	/// </param>
	/// <param name="DeviceInterfaceDetailDataSize">
	/// <para>
	/// The size of the DeviceInterfaceDetailData buffer. The buffer must be at least ( <c>offsetof</c>(SP_DEVICE_INTERFACE_DETAIL_DATA,
	/// <c>DevicePath</c>) + <c>sizeof</c>(TCHAR)) bytes, to contain the fixed part of the structure and a single <c>NULL</c> to
	/// terminate an empty MULTI_SZ string.
	/// </para>
	/// <para>This parameter must be zero if DeviceInterfaceDetailData is <c>NULL</c>.</para>
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to a variable of type DWORD that receives the required size of the DeviceInterfaceDetailData buffer. This size
	/// includes the size of the fixed part of the structure plus the number of bytes required for the variable-length device path
	/// string. This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to a buffer that receives information about the device that supports the requested interface. The caller must set
	/// DeviceInfoData <c>.cbSize</c> to <c>sizeof</c>(SP_DEVINFO_DATA). This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <c>SetupDiGetDeviceInterfaceDetail</c> returns <c>TRUE</c> if the function completed without error. If the function completed
	/// with an error, <c>FALSE</c> is returned and the error code for the failure can be retrieved by calling GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>Using this function to get details about an interface is typically a two-step process:</para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Get the required buffer size. Call <c>SetupDiGetDeviceInterfaceDetail</c> with a <c>NULL</c> DeviceInterfaceDetailData pointer,
	/// a DeviceInterfaceDetailDataSize of zero, and a valid RequiredSize variable. In response to such a call, this function returns
	/// the required buffer size at RequiredSize and fails with GetLastError returning ERROR_INSUFFICIENT_BUFFER.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Allocate an appropriately sized buffer and call the function again to get the interface details.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The interface detail returned by this function consists of a device path that can be passed to Win32 functions such as
	/// CreateFile. Do not attempt to parse the device path symbolic name. The device path can be reused across system starts.
	/// </para>
	/// <para>
	/// <c>SetupDiGetDeviceInterfaceDetail</c> can be used to get just the DeviceInfoData. If the interface exists but
	/// DeviceInterfaceDetailData is <c>NULL</c>, this function fails, GetLastError returns ERROR_INSUFFICIENT_BUFFER, and the
	/// DeviceInfoData structure is filled with information about the device that exposes the interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinterfacedetaila WINSETUPAPI BOOL
	// SetupDiGetDeviceInterfaceDetailA( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
	// PSP_DEVICE_INTERFACE_DETAIL_DATA_A DeviceInterfaceDetailData, DWORD DeviceInterfaceDetailDataSize, PDWORD RequiredSize,
	// PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceInterfaceDetailA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDeviceInterfaceDetail(HDEVINFO DeviceInfoSet, in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
		[Out, Optional] IntPtr DeviceInterfaceDetailData, uint DeviceInterfaceDetailDataSize, out uint RequiredSize, IntPtr DeviceInfoData = default);

	/// <summary>The <c>SetupDiGetDeviceInterfaceDetail</c> function returns details about a device interface.</summary>
	/// <param name="DeviceInfoSet">
	/// A pointer to the device information set that contains the interface for which to retrieve details. This handle is typically
	/// returned by SetupDiGetClassDevs.
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// An SP_DEVICE_INTERFACE_DATA structure that specifies the interface in DeviceInfoSet for which to retrieve details. This value is
	/// typically returned by SetupDiEnumDeviceInterfaces.
	/// </param>
	/// <param name="DeviceInterfacePath">
	/// A string that contains the device interface path. This path can be passed to Win32 functions such as CreateFile.
	/// </param>
	/// <param name="DeviceInfoData">Receives information about the device that supports the requested interface.</param>
	/// <returns>
	/// <c>SetupDiGetDeviceInterfaceDetail</c> returns <c>TRUE</c> if the function completed without error. If the function completed
	/// with an error, <c>FALSE</c> is returned and the error code for the failure can be retrieved by calling GetLastError.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinterfacedetaila WINSETUPAPI BOOL
	// SetupDiGetDeviceInterfaceDetailA( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
	// PSP_DEVICE_INTERFACE_DETAIL_DATA_A DeviceInterfaceDetailData, DWORD DeviceInterfaceDetailDataSize, PDWORD RequiredSize,
	// PSP_DEVINFO_DATA DeviceInfoData );
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceInterfaceDetailA")]
	public static bool SetupDiGetDeviceInterfaceDetail(HDEVINFO DeviceInfoSet, in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData, out string? DeviceInterfacePath, out SP_DEVINFO_DATA DeviceInfoData)
	{
		SetupDiGetDeviceInterfaceDetail(DeviceInfoSet, DeviceInterfaceData, default, 0, out var sz);
		Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		using var mem = new SafeSP_DEVICE_INTERFACE_DETAIL_DATA(sz);
		DeviceInfoData = new SP_DEVINFO_DATA { cbSize = (uint)Marshal.SizeOf(typeof(SP_DEVINFO_DATA)) };
		var ret = SetupDiGetDeviceInterfaceDetail(DeviceInfoSet, DeviceInterfaceData, mem, sz, out sz, ref DeviceInfoData);
		DeviceInterfacePath = ret ? mem.DevicePath : null;
		return ret;
	}

	/// <summary>The <c>SetupDiGetDeviceInterfaceProperty</c> function retrieves a device property that is set for a device interface.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a device interface for which to retrieve a device interface property.
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to an SP_DEVICE_INTERFACE_DATA structure that represents the device interface for which to retrieve a device interface property.
	/// </param>
	/// <param name="PropertyKey">
	/// A pointer to a DEVPROPKEY structure that represents the device interface property key of the device interface property to retrieve.
	/// </param>
	/// <param name="PropertyType">
	/// A pointer to a DEVPROPTYPE-typed variable that receives the property-data-type identifier of the requested device interface
	/// property. The property-data-type identifier is a bitwise OR between a base-data-type identifier and, if the base-data type is
	/// modified, a property-data-type modifier.
	/// </param>
	/// <param name="PropertyBuffer">
	/// A pointer to a buffer that receives the requested device interface property. <c>SetupDiGetDeviceInterfaceProperty</c> retrieves
	/// the requested property only if the buffer is large enough to hold all the property value data. The pointer can be <c>NULL</c>.
	/// If the pointer is set to <c>NULL</c> and RequiredSize is supplied, <c>SetupDiGetDeviceInterfaceProperty</c> returns the size of
	/// the property, in bytes, in *RequiredSize.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to <c>NULL</c>, PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to a DWORD-typed variable that receives the size, in bytes, of either the device interface property if the property is
	/// retrieved or the required buffer size, if the buffer is not large enough. This pointer can be set to <c>NULL</c>.
	/// </param>
	/// <param name="Flags">This parameter must be set to zero.</param>
	/// <returns>
	/// <para>
	/// <c>SetupDiGetDeviceInterfaceProperty</c> returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c>, and the
	/// logged error can be retrieved by calling GetLastError.
	/// </para>
	/// <para>
	/// The following table includes some of the more common error codes that this function might log. Other error codes can be set by
	/// the device installer functions that are called by this API.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value of Flags is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The device information set that is specified by DevInfoSet is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// A supplied parameter is not valid. One possibility is that the device interface that is specified by DeviceInterfaceData is not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_REG_PROPERTY</term>
	/// <term>The property key that is supplied by PropertyKey is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>An unspecified internal data value was not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_USER_BUFFER</term>
	/// <term>A user buffer is not valid. One possibility is that PropertyBuffer is NULL, and PropertyBufferSize is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_DEVICE_INTERFACE</term>
	/// <term>The device interface that is specified by DeviceInterfaceData does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// The PropertyBuffer buffer is not large enough to hold the property value, or an internal data buffer that was passed to a system
	/// call was too small.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There was not enough system memory available to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>The requested device property does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have Administrator privileges.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>SetupDiGetDeviceInterfaceProperty</c> is part of the unified device property model.</para>
	/// <para>SetupAPI supports only a Unicode version of <c>SetupDiGetDeviceInterfaceProperty</c>.</para>
	/// <para>
	/// A caller of <c>SetupDiGetDeviceInterfaceProperty</c> must be a member of the Administrators group to set a device interface property.
	/// </para>
	/// <para>To obtain the device property keys that represent the device properties that are set for a device interface, call SetupDiGetDeviceInterfacePropertyKeys.</para>
	/// <para>To set a device interface property, call SetupDiSetDeviceInterfaceProperty.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinterfacepropertyw WINSETUPAPI BOOL
	// SetupDiGetDeviceInterfacePropertyW( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData, const DEVPROPKEY
	// *PropertyKey, DEVPROPTYPE *PropertyType, PBYTE PropertyBuffer, DWORD PropertyBufferSize, PDWORD RequiredSize, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Unicode)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceInterfacePropertyW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDeviceInterfaceProperty(HDEVINFO DeviceInfoSet, in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
		in DEVPROPKEY PropertyKey, out DEVPROPTYPE PropertyType, [Out, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize,
		out uint RequiredSize, [In, Optional] uint Flags);

	/// <summary>The <c>SetupDiGetDeviceInterfaceProperty</c> function retrieves a device property that is set for a device interface.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a device interface for which to retrieve a device interface property.
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to an SP_DEVICE_INTERFACE_DATA structure that represents the device interface for which to retrieve a device interface property.
	/// </param>
	/// <param name="PropertyKey">
	/// A pointer to a DEVPROPKEY structure that represents the device interface property key of the device interface property to retrieve.
	/// </param>
	/// <returns>The requested device interface property.</returns>
	/// <remarks>
	/// <para><c>SetupDiGetDeviceInterfaceProperty</c> is part of the unified device property model.</para>
	/// <para>
	/// A caller of <c>SetupDiGetDeviceInterfaceProperty</c> must be a member of the Administrators group to set a device interface property.
	/// </para>
	/// <para>To obtain the device property keys that represent the device properties that are set for a device interface, call SetupDiGetDeviceInterfacePropertyKeys.</para>
	/// <para>To set a device interface property, call SetupDiSetDeviceInterfaceProperty.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinterfacepropertyw WINSETUPAPI BOOL
	// SetupDiGetDeviceInterfacePropertyW( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData, const DEVPROPKEY
	// *PropertyKey, DEVPROPTYPE *PropertyType, PBYTE PropertyBuffer, DWORD PropertyBufferSize, PDWORD RequiredSize, DWORD Flags );
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceInterfacePropertyW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static object? SetupDiGetDeviceInterfaceProperty(HDEVINFO DeviceInfoSet, in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
		in DEVPROPKEY PropertyKey)
	{
		if (!SetupDiGetDeviceInterfaceProperty(DeviceInfoSet, DeviceInterfaceData, PropertyKey, out _, default, 0, out var sz))
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		using var mem = new SafeHGlobalHandle(sz);
		if (!SetupDiGetDeviceInterfaceProperty(DeviceInfoSet, DeviceInterfaceData, PropertyKey, out var propType, mem, mem.Size, out _))
			Win32Error.ThrowLastError();
		return SetupDiPropertyToManagedObject(mem, propType);
	}

	/// <summary>
	/// The <c>SetupDiGetDeviceInterfacePropertyKeys</c> function retrieves an array of device property keys that represent the device
	/// properties that are set for a device interface.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set. This device information set contains a device interface for which to retrieve an array of
	/// the device property keys that represent the device properties that are set for a device interface.
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to an SP_DEVICE_INTERFACE_DATA structure that represents the device interface for which to retrieve the requested
	/// array of device property keys.
	/// </param>
	/// <param name="PropertyKeyArray">
	/// A pointer to a buffer that receives an array of DEVPROPKEY-typed values, where each value is a device property key for a device
	/// property that is set for the device interface. The pointer is optional and can be <c>NULL</c>. For more information, see the
	/// <c>Remarks</c> section later in this topic.
	/// </param>
	/// <param name="PropertyKeyCount">
	/// The size, in DEVPROPKEY-typed elements, of the PropertyKeyArray buffer. If PropertyKeyArray is <c>NULL</c>, PropertyKeyCount
	/// must be set to zero.
	/// </param>
	/// <param name="RequiredPropertyKeyCount">
	/// A pointer to a DWORD-typed variable that receives the number of requested device property keys. The pointer is optional and can
	/// be set to <c>NULL</c>.
	/// </param>
	/// <param name="Flags">This parameter must be set to zero.</param>
	/// <returns>
	/// <para>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c>, and the logged error can be retrieved
	/// by calling GetLastError.
	/// </para>
	/// <para>The following table includes some of the more common error codes that this function might log.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value of Flags is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The device information set that is specified by DevInfoSet is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>An internal data value is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is not valid. One possibility is that the device interface that is specified by DevInterfaceData is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_USER_BUFFER</term>
	/// <term>A user buffer is not valid. One possibility is that PropertyKeyArray is NULL, and PropertKeyCount is not zero. .</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_DEVICE_INTERFACE</term>
	/// <term>The device interface that is specified by DeviceInterfaceData does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The PropertyKeyArray buffer is not large enough to hold all the requested property keys.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There was not enough system memory available to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>SetupDiGetDeviceInterfacePropertyKeys</c> is part of the unified device property model.</para>
	/// <para>
	/// If the PropertyKeyArray buffer is not large enough to hold all the requested property keys,
	/// <c>SetupDiGetDeviceInterfacePropertyKeys</c> does not retrieve any property keys and returns ERROR_INSUFFICIENT_BUFFER. If the
	/// caller supplied a RequiredPropertyKeyCount pointer, <c>SetupDiGetDeviceInterfacePropertyKeys</c> sets the value of
	/// *RequiredPropertyKeyCount to the required size, in DEVPROPKEY-typed values, of the PropertyKeyArray buffer.
	/// </para>
	/// <para>
	/// To retrieve a device interface property, call SetupDiGetDeviceInterfaceProperty <c>,</c> and to set a device interface property,
	/// call SetupDiSetDeviceInterfaceProperty.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinterfacepropertykeys WINSETUPAPI BOOL
	// SetupDiGetDeviceInterfacePropertyKeys( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData, DEVPROPKEY
	// *PropertyKeyArray, DWORD PropertyKeyCount, PDWORD RequiredPropertyKeyCount, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceInterfacePropertyKeys")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDeviceInterfacePropertyKeys(HDEVINFO DeviceInfoSet, in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEVPROPKEY[] PropertyKeyArray, uint PropertyKeyCount,
		out uint RequiredPropertyKeyCount, [In, Optional] uint Flags);

	/// <summary>The <c>SetupDiGetDeviceProperty</c> function retrieves a device instance property.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a device instance for which to retrieve a device instance property.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to the SP_DEVINFO_DATA structure that represents the device instance for which to retrieve a device instance property.
	/// </param>
	/// <param name="PropertyKey">
	/// A pointer to a DEVPROPKEY structure that represents the device property key of the requested device instance property.
	/// </param>
	/// <param name="PropertyType">
	/// A pointer to a DEVPROPTYPE-typed variable that receives the property-data-type identifier of the requested device instance
	/// property, where the property-data-type identifier is the bitwise OR between a base-data-type identifier and, if the base-data
	/// type is modified, a property-data-type modifier.
	/// </param>
	/// <param name="PropertyBuffer">
	/// A pointer to a buffer that receives the requested device instance property. <c>SetupDiGetDeviceProperty</c> retrieves the
	/// requested property only if the buffer is large enough to hold all the property value data. The pointer can be <c>NULL</c>. If
	/// the pointer is set to <c>NULL</c> and RequiredSize is supplied, <c>SetupDiGetDeviceProperty</c> returns the size of the
	/// property, in bytes, in *RequiredSize.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to <c>NULL</c>, PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to a DWORD-typed variable that receives the size, in bytes, of either the device instance property if the property is
	/// retrieved or the required buffer size if the buffer is not large enough. This pointer can be set to <c>NULL</c>.
	/// </param>
	/// <param name="Flags">This parameter must be set to zero.</param>
	/// <returns>
	/// <para>
	/// <c>SetupDiGetDeviceProperty</c> returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c>, and the logged
	/// error can be retrieved by calling GetLastError.
	/// </para>
	/// <para>The following table includes some of the more common error codes that this function might log.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value of Flags is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The device information set that is specified by DevInfoSet is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A supplied parameter is not valid. One possibility is that the device information element is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_REG_PROPERTY</term>
	/// <term>The property key that is supplied by PropertyKey is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>An unspecified internal data value was not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_USER_BUFFER</term>
	/// <term>A user buffer is not valid. One possibility is that PropertyBuffer is NULL and PropertBufferSize is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_DEVINST</term>
	/// <term>The device instance that is specified by DevInfoData does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// The PropertyBuffer buffer is too small to hold the requested property value, or an internal data buffer that was passed to a
	/// system call was too small.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There was not enough system memory available to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>The requested device property does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have Administrator privileges.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>SetupDiGetDeviceProperty</c> is part of the unified device property model.</para>
	/// <para>SetupAPI supports only a Unicode version of <c>SetupDiGetDeviceProperty</c>.</para>
	/// <para>To obtain the device property keys that represent the device properties that are set for a device instance, call SetupDiGetDevicePropertyKeys.</para>
	/// <para>To set a device instance property, call SetupDiSetDeviceProperty.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdevicepropertyw WINSETUPAPI BOOL
	// SetupDiGetDevicePropertyW( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, const DEVPROPKEY *PropertyKey, DEVPROPTYPE
	// *PropertyType, PBYTE PropertyBuffer, DWORD PropertyBufferSize, PDWORD RequiredSize, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Unicode)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDevicePropertyW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDeviceProperty(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, in DEVPROPKEY PropertyKey,
		out DEVPROPTYPE PropertyType, [Out, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize, out uint RequiredSize, uint Flags = 0);

	/// <summary>The <c>SetupDiGetDeviceProperty</c> function retrieves a device instance property.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a device instance for which to retrieve a device instance property.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to the SP_DEVINFO_DATA structure that represents the device instance for which to retrieve a device instance property.
	/// </param>
	/// <param name="PropertyKey">
	/// A pointer to a DEVPROPKEY structure that represents the device property key of the requested device instance property.
	/// </param>
	/// <param name="Value">
	/// A pointer to a buffer that receives the requested device instance property. <c>SetupDiGetDeviceProperty</c> retrieves the
	/// requested property only if the buffer is large enough to hold all the property value data. The pointer can be <c>NULL</c>. If
	/// the pointer is set to <c>NULL</c> and RequiredSize is supplied, <c>SetupDiGetDeviceProperty</c> returns the size of the
	/// property, in bytes, in *RequiredSize.
	/// </param>
	/// <returns>
	/// <para>
	/// <c>SetupDiGetDeviceProperty</c> returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c>, and the logged
	/// error can be retrieved by calling GetLastError.
	/// </para>
	/// <para>The following table includes some of the more common error codes that this function might log.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value of Flags is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The device information set that is specified by DevInfoSet is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A supplied parameter is not valid. One possibility is that the device information element is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_REG_PROPERTY</term>
	/// <term>The property key that is supplied by PropertyKey is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>An unspecified internal data value was not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_USER_BUFFER</term>
	/// <term>A user buffer is not valid. One possibility is that PropertyBuffer is NULL and PropertBufferSize is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_DEVINST</term>
	/// <term>The device instance that is specified by DevInfoData does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// The PropertyBuffer buffer is too small to hold the requested property value, or an internal data buffer that was passed to a
	/// system call was too small.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There was not enough system memory available to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>The requested device property does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have Administrator privileges.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>SetupDiGetDeviceProperty</c> is part of the unified device property model.</para>
	/// <para>SetupAPI supports only a Unicode version of <c>SetupDiGetDeviceProperty</c>.</para>
	/// <para>To obtain the device property keys that represent the device properties that are set for a device instance, call SetupDiGetDevicePropertyKeys.</para>
	/// <para>To set a device instance property, call SetupDiSetDeviceProperty.</para>
	/// </remarks>
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDevicePropertyW")]
	public static bool SetupDiGetDeviceProperty(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, in DEVPROPKEY PropertyKey, [NotNullWhen(true)] out object? Value)
	{
		Value = null;
		if (!SetupDiGetDeviceProperty(DeviceInfoSet, DeviceInfoData, PropertyKey, out _, default, 0, out var sz) && Win32Error.GetLastError() != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			return false;
		using var mem = new SafeCoTaskMemHandle(sz);
		if (SetupDiGetDeviceProperty(DeviceInfoSet, DeviceInfoData, PropertyKey, out var propType, mem, mem.Size, out _))
		{
			Value = SetupDiPropertyToManagedObject(mem, propType)!;
			return true;
		}
		return false;
	}

	/// <summary>
	/// The <c>SetupDiGetDevicePropertyKeys</c> function retrieves an array of the device property keys that represent the device
	/// properties that are set for a device instance.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set. This device information set contains the device instance for which this function retrieves
	/// an array of device property keys. The property keys represent the device properties that are set for the device instance.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that represents the device instance for which to retrieve the requested array of
	/// device property keys.
	/// </param>
	/// <param name="PropertyKeyArray">
	/// A pointer to a buffer that receives an array of DEVPROPKEY-typed values, where each value is a device property key that
	/// represents a device property that is set for the device instance. The pointer is optional and can be <c>NULL</c>. For more
	/// information, see the <c>Remarks</c> section later in this topic.
	/// </param>
	/// <param name="PropertyKeyCount">
	/// The size, in DEVPROPKEY-typed values, of the PropertyKeyArray buffer. If PropertyKeyArray is set to <c>NULL</c>,
	/// PropertyKeyCount must be set to zero.
	/// </param>
	/// <param name="RequiredPropertyKeyCount">
	/// A pointer to a DWORD-typed variable that receives the number of requested device property keys. The pointer is optional and can
	/// be set to <c>NULL</c>.
	/// </param>
	/// <param name="Flags">This parameter must be set to zero.</param>
	/// <returns>
	/// <para>
	/// <c>SetupDiGetDevicePropertyKeys</c> returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c>, and the logged
	/// error can be retrieved by calling GetLastError.
	/// </para>
	/// <para>The following table includes some of the more common error codes that this function might log.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value of Flags is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The device information set that is specified by DevInfoSet is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A supplied parameter is not valid. One possibility is that the device information element is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>An internal data value is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_USER_BUFFER</term>
	/// <term>A user buffer is not valid. One possibility is that PropertyKeyArray is NULL and PropertKeyCount is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_DEVINST</term>
	/// <term>The device instance that is specified by DevInfoData does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The PropertyKeyArray buffer is too small to hold all the requested property keys.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There was not enough system memory available to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>SetupDiGetDevicePropertyKeys</c> is part of the unified device property model.</para>
	/// <para>
	/// If the ProperKeyArray buffer is not large enough to hold all the requested property keys, <c>SetupDiGetDevicePropertyKeys</c>
	/// does not retrieve any property keys and returns ERROR_INSUFFICIENT_BUFFER. If the caller supplied a RequiredPropertyKeyCount
	/// pointer, <c>SetupDiGetDevicePropertyKeys</c> sets the value of *RequiredPropertyKeyCount to the required size, in
	/// DEVPROPKEY-typed values, of the PropertyKeyArray buffer.
	/// </para>
	/// <para>To retrieve a device instance property, call SetupDiGetDeviceProperty, and to set a device instance property, call SetupDiSetDeviceProperty.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdevicepropertykeys WINSETUPAPI BOOL
	// SetupDiGetDevicePropertyKeys( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DEVPROPKEY *PropertyKeyArray, DWORD
	// PropertyKeyCount, PDWORD RequiredPropertyKeyCount, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDevicePropertyKeys")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDevicePropertyKeys(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
		[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEVPROPKEY[]? PropertyKeyArray, uint PropertyKeyCount,
		out uint RequiredPropertyKeyCount, uint Flags = 0);

	/// <summary>The <c>SetupDiGetDeviceRegistryProperty</c> function retrieves a specified Plug and Play device property.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a device information element that represents the device for which to retrieve
	/// a Plug and Play property.
	/// </param>
	/// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
	/// <param name="Property">
	/// <para>One of the following values that specifies the property to be retrieved:</para>
	/// <para>SPDRP_ADDRESS</para>
	/// <para>The function retrieves the device's address.</para>
	/// <para>SPDRP_BUSNUMBER</para>
	/// <para>The function retrieves the device's bus number.</para>
	/// <para>SPDRP_BUSTYPEGUID</para>
	/// <para>The function retrieves the GUID for the device's bus type.</para>
	/// <para>SPDRP_CAPABILITIES</para>
	/// <para>
	/// The function retrieves a bitwise OR of the following CM_DEVCAP_Xxx flags in a DWORD. The device capabilities that are
	/// represented by these flags correspond to the device capabilities that are represented by the members of the DEVICE_CAPABILITIES
	/// structure. The CM_DEVCAP_Xxx constants are defined in Cfgmgr32.h.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>CM_DEVCAP_Xxx flag</term>
	/// <term>Corresponding DEVICE_CAPABILITIES structure member</term>
	/// </listheader>
	/// <item>
	/// <term>CM_DEVCAP_LOCKSUPPORTED</term>
	/// <term>LockSupported</term>
	/// </item>
	/// <item>
	/// <term>CM_DEVCAP_EJECTSUPPORTED</term>
	/// <term>EjectSupported</term>
	/// </item>
	/// <item>
	/// <term>CM_DEVCAP_REMOVABLE</term>
	/// <term>Removable</term>
	/// </item>
	/// <item>
	/// <term>CM_DEVCAP_DOCKDEVICE</term>
	/// <term>DockDevice</term>
	/// </item>
	/// <item>
	/// <term>CM_DEVCAP_UNIQUEID</term>
	/// <term>UniqueID</term>
	/// </item>
	/// <item>
	/// <term>CM_DEVCAP_SILENTINSTALL</term>
	/// <term>SilentInstall</term>
	/// </item>
	/// <item>
	/// <term>CM_DEVCAP_RAWDEVICEOK</term>
	/// <term>RawDeviceOK</term>
	/// </item>
	/// <item>
	/// <term>CM_DEVCAP_SURPRISEREMOVALOK</term>
	/// <term>SurpriseRemovalOK</term>
	/// </item>
	/// <item>
	/// <term>CM_DEVCAP_HARDWAREDISABLED</term>
	/// <term>HardwareDisabled</term>
	/// </item>
	/// <item>
	/// <term>CM_DEVCAP_NONDYNAMIC</term>
	/// <term>NonDynamic</term>
	/// </item>
	/// </list>
	/// <para>SPDRP_CHARACTERISTICS</para>
	/// <para>
	/// The function retrieves a bitwise OR of a device's characteristics flags in a DWORD. For a description of these flags, which are
	/// defined in Wdm.h and Ntddk.h, see the DeviceCharacteristics parameter of the IoCreateDevice function.
	/// </para>
	/// <para>SPDRP_CLASS</para>
	/// <para>The function retrieves a REG_SZ string that contains the device setup class of a device.</para>
	/// <para>SPDRP_CLASSGUID</para>
	/// <para>The function retrieves a REG_SZ string that contains the GUID that represents the device setup class of a device.</para>
	/// <para>SPDRP_COMPATIBLEIDS</para>
	/// <para>
	/// The function retrieves a REG_MULTI_SZ string that contains the list of compatible IDs for a device. For information about
	/// compatible IDs, see Device Identification Strings.
	/// </para>
	/// <para>SPDRP_CONFIGFLAGS</para>
	/// <para>
	/// The function retrieves a bitwise OR of a device's configuration flags in a DWORD value. The configuration flags are represented
	/// by the CONFIGFLAG_Xxx bitmasks that are defined in Regstr.h.
	/// </para>
	/// <para>SPDRP_DEVICE_POWER_DATA</para>
	/// <para>(Windows XP and later) The function retrieves a CM_POWER_DATA structure that contains the device's power management information.</para>
	/// <para>SPDRP_DEVICEDESC</para>
	/// <para>The function retrieves a REG_SZ string that contains the description of a device.</para>
	/// <para>SPDRP_DEVTYPE</para>
	/// <para>The function retrieves a DWORD value that represents the device's type. For more information, see Specifying Device Types.</para>
	/// <para>SPDRP_DRIVER</para>
	/// <para>
	/// The function retrieves a string that identifies the device's software key (sometimes called the driver key). For more
	/// information about driver keys, see Registry Trees and Keys for Devices and Drivers.
	/// </para>
	/// <para>SPDRP_ENUMERATOR_NAME</para>
	/// <para>The function retrieves a REG_SZ string that contains the name of the device's enumerator.</para>
	/// <para>SPDRP_EXCLUSIVE</para>
	/// <para>
	/// The function retrieves a DWORD value that indicates whether a user can obtain exclusive use of the device. The returned value is
	/// one if exclusive use is allowed, or zero otherwise. For more information, see IoCreateDevice.
	/// </para>
	/// <para>SPDRP_FRIENDLYNAME</para>
	/// <para>The function retrieves a REG_SZ string that contains the friendly name of a device.</para>
	/// <para>SPDRP_HARDWAREID</para>
	/// <para>
	/// The function retrieves a REG_MULTI_SZ string that contains the list of hardware IDs for a device. For information about hardware
	/// IDs, see Device Identification Strings.
	/// </para>
	/// <para>SPDRP_INSTALL_STATE</para>
	/// <para>
	/// (Windows XP and later) The function retrieves a DWORD value that indicates the installation state of a device. The installation
	/// state is represented by one of the CM_INSTALL_STATE_Xxx values that are defined in Cfgmgr32.h. The CM_INSTALL_STATE_Xxx values
	/// correspond to the DEVICE_INSTALL_STATE enumeration values.
	/// </para>
	/// <para>SPDRP_LEGACYBUSTYPE</para>
	/// <para>The function retrieves the device's legacy bus type as an INTERFACE_TYPE value (defined in Wdm.h and Ntddk.h).</para>
	/// <para>SPDRP_LOCATION_INFORMATION</para>
	/// <para>The function retrieves a REG_SZ string that contains the hardware location of a device.</para>
	/// <para>SPDRP_LOCATION_PATHS</para>
	/// <para>
	/// (Windows Server 2003 and later) The function retrieves a REG_MULTI_SZ string that represents the location of the device in the
	/// device tree.
	/// </para>
	/// <para>SPDRP_LOWERFILTERS</para>
	/// <para>The function retrieves a REG_MULTI_SZ string that contains the names of a device's lower-filter drivers.</para>
	/// <para>SPDRP_MFG</para>
	/// <para>The function retrieves a REG_SZ string that contains the name of the device manufacturer.</para>
	/// <para>SPDRP_PHYSICAL_DEVICE_OBJECT_NAME</para>
	/// <para>
	/// The function retrieves a REG_SZ string that contains the name that is associated with the device's PDO. For more information,
	/// see IoCreateDevice.
	/// </para>
	/// <para>SPDRP_REMOVAL_POLICY</para>
	/// <para>
	/// (Windows XP and later) The function retrieves the device's current removal policy as a DWORD that contains one of the
	/// CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
	/// </para>
	/// <para>SPDRP_REMOVAL_POLICY_HW_DEFAULT</para>
	/// <para>
	/// (Windows XP and later) The function retrieves the device's hardware-specified default removal policy as a DWORD that contains
	/// one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
	/// </para>
	/// <para>SPDRP_REMOVAL_POLICY_OVERRIDE</para>
	/// <para>
	/// (Windows XP and later) The function retrieves the device's override removal policy (if it exists) from the registry, as a DWORD
	/// that contains one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
	/// </para>
	/// <para>SPDRP_SECURITY</para>
	/// <para>The function retrieves a SECURITY_DESCRIPTOR structure for a device.</para>
	/// <para>SPDRP_SECURITY_SDS</para>
	/// <para>
	/// The function retrieves a REG_SZ string that contains the device's security descriptor. For information about security descriptor
	/// strings, see Security Descriptor Definition Language (Windows). For information about the format of security descriptor strings,
	/// see Security Descriptor Definition Language (Windows).
	/// </para>
	/// <para>SPDRP_SERVICE</para>
	/// <para>The function retrieves a REG_SZ string that contains the service name for a device.</para>
	/// <para>SPDRP_UI_NUMBER</para>
	/// <para>
	/// The function retrieves a DWORD value set to the value of the <c>UINumber</c> member of the device's DEVICE_CAPABILITIES structure.
	/// </para>
	/// <para>SPDRP_UI_NUMBER_DESC_FORMAT</para>
	/// <para>The function retrieves a format string (REG_SZ) used to display the <c>UINumber</c> value.</para>
	/// <para>SPDRP_UPPERFILTERS</para>
	/// <para>The function retrieves a REG_MULTI_SZ string that contains the names of a device's upper filter drivers.</para>
	/// </param>
	/// <param name="PropertyRegDataType">
	/// A pointer to a variable that receives the data type of the property that is being retrieved. This is one of the standard
	/// registry data types. This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="PropertyBuffer">
	/// A pointer to a buffer that receives the property that is being retrieved. If this parameter is set to <c>NULL</c>, and
	/// PropertyBufferSize is also set to zero, the function returns the required size for the buffer in RequiredSize.
	/// </param>
	/// <param name="PropertyBufferSize">The size, in bytes, of the PropertyBuffer buffer.</param>
	/// <param name="RequiredSize">
	/// A pointer to a variable of type DWORD that receives the required size, in bytes, of the PropertyBuffer buffer that is required
	/// to hold the data for the requested property. This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <c>SetupDiGetDeviceRegistryProperty</c> returns <c>TRUE</c> if the call was successful. Otherwise, it returns <c>FALSE</c> and
	/// the logged error can be retrieved by making a call to GetLastError. <c>SetupDiGetDeviceRegistryProperty</c> returns the
	/// ERROR_INVALID_DATA error code if the requested property does not exist for a device or if the property data is not valid.
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceregistrypropertya WINSETUPAPI BOOL
	// SetupDiGetDeviceRegistryPropertyA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DWORD Property, PDWORD
	// PropertyRegDataType, PBYTE PropertyBuffer, DWORD PropertyBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceRegistryPropertyA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDeviceRegistryProperty(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, SPDRP Property,
		out REG_VALUE_TYPE PropertyRegDataType, [Out, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize, out uint RequiredSize);

	/// <summary>
	/// The <c>SetupDiGetDriverInfoDetail</c> function retrieves driver information detail for a device information set or a particular
	/// device information element in the device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a driver information element for which to retrieve driver information.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element that represents the device for which to
	/// retrieve driver information. This parameter is optional and can be <c>NULL</c>. If this parameter is specified,
	/// <c>SetupDiGetDriverInfoDetail</c> retrieves information about a driver in a driver list for the specified device. If this
	/// parameter is <c>NULL</c>, <c>SetupDiGetDriverInfoDetail</c> retrieves information about a driver that is a member of the global
	/// class driver list for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInfoData">
	/// A pointer to an SP_DRVINFO_DATA structure that specifies the driver information element that represents the driver for which to
	/// retrieve details. If DeviceInfoData is specified, the driver must be a member of the driver list for the device that is
	/// specified by DeviceInfoData. Otherwise, the driver must be a member of the global class driver list for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInfoDetailData">
	/// <para>
	/// A pointer to an SP_DRVINFO_DETAIL_DATA structure that receives detailed information about the specified driver. If this
	/// parameter is not specified, DriverInfoDetailDataSize must be zero. If this parameter is specified, DriverInfoDetailData.
	/// <c>cbSize</c> must be set to the value of <c>sizeof(</c> SP_DRVINFO_DETAIL_DATA <c>)</c> before it calls <c>SetupDiGetDriverInfoDetail</c>.
	/// </para>
	/// <para><c>Note</c> DriverInfoDetailData. <c>cbSize</c> must not be set to the value of the DriverInfoDetailDataSize parameter.</para>
	/// </param>
	/// <param name="DriverInfoDetailDataSize">The size, in bytes, of the DriverInfoDetailData buffer.</param>
	/// <param name="RequiredSize">
	/// A pointer to a variable that receives the number of bytes required to store the detailed driver information. This value includes
	/// both the size of the structure and the additional bytes required for the variable-length character buffer at the end that holds
	/// the hardware ID list and the compatible ID list. The lists are in REG_MULTI_SZ format. For information about hardware and
	/// compatible IDs, see Device Identification Strings.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// If the specified driver information member and the caller-supplied buffer are both valid, this function is guaranteed to fill in
	/// all static fields in the SP_DRVINFO_DETAIL_DATA structure and as many IDs as possible in the variable-length buffer at the end
	/// while still maintaining REG_MULTI_SZ format. In this case, the function returns <c>FALSE</c> and a call to GetLastError returns
	/// ERROR_INSUFFICIENT_BUFFER. If specified, RequiredSize contains the total number of bytes required for the structure with all IDs.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdriverinfodetaila WINSETUPAPI BOOL
	// SetupDiGetDriverInfoDetailA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DRVINFO_DATA_A DriverInfoData,
	// PSP_DRVINFO_DETAIL_DATA_A DriverInfoDetailData, DWORD DriverInfoDetailDataSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDriverInfoDetailA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDriverInfoDetail(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, in SP_DRVINFO_DATA_V2 DriverInfoData,
		IntPtr DriverInfoDetailData, uint DriverInfoDetailDataSize, out uint RequiredSize);

	/// <summary>
	/// The <c>SetupDiGetDriverInfoDetail</c> function retrieves driver information detail for a device information set or a particular
	/// device information element in the device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a driver information element for which to retrieve driver information.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element that represents the device for which to
	/// retrieve driver information. This parameter is optional and can be <c>NULL</c>. If this parameter is specified,
	/// <c>SetupDiGetDriverInfoDetail</c> retrieves information about a driver in a driver list for the specified device. If this
	/// parameter is <c>NULL</c>, <c>SetupDiGetDriverInfoDetail</c> retrieves information about a driver that is a member of the global
	/// class driver list for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInfoData">
	/// A pointer to an SP_DRVINFO_DATA structure that specifies the driver information element that represents the driver for which to
	/// retrieve details. If DeviceInfoData is specified, the driver must be a member of the driver list for the device that is
	/// specified by DeviceInfoData. Otherwise, the driver must be a member of the global class driver list for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInfoDetailData">
	/// <para>
	/// A pointer to an SP_DRVINFO_DETAIL_DATA structure that receives detailed information about the specified driver. If this
	/// parameter is not specified, DriverInfoDetailDataSize must be zero. If this parameter is specified, DriverInfoDetailData.
	/// <c>cbSize</c> must be set to the value of <c>sizeof(</c> SP_DRVINFO_DETAIL_DATA <c>)</c> before it calls <c>SetupDiGetDriverInfoDetail</c>.
	/// </para>
	/// <para><c>Note</c> DriverInfoDetailData. <c>cbSize</c> must not be set to the value of the DriverInfoDetailDataSize parameter.</para>
	/// </param>
	/// <param name="DriverInfoDetailDataSize">The size, in bytes, of the DriverInfoDetailData buffer.</param>
	/// <param name="RequiredSize">
	/// A pointer to a variable that receives the number of bytes required to store the detailed driver information. This value includes
	/// both the size of the structure and the additional bytes required for the variable-length character buffer at the end that holds
	/// the hardware ID list and the compatible ID list. The lists are in REG_MULTI_SZ format. For information about hardware and
	/// compatible IDs, see Device Identification Strings.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// If the specified driver information member and the caller-supplied buffer are both valid, this function is guaranteed to fill in
	/// all static fields in the SP_DRVINFO_DETAIL_DATA structure and as many IDs as possible in the variable-length buffer at the end
	/// while still maintaining REG_MULTI_SZ format. In this case, the function returns <c>FALSE</c> and a call to GetLastError returns
	/// ERROR_INSUFFICIENT_BUFFER. If specified, RequiredSize contains the total number of bytes required for the structure with all IDs.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdriverinfodetaila WINSETUPAPI BOOL
	// SetupDiGetDriverInfoDetailA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DRVINFO_DATA_A DriverInfoData,
	// PSP_DRVINFO_DETAIL_DATA_A DriverInfoDetailData, DWORD DriverInfoDetailDataSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDriverInfoDetailA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDriverInfoDetail(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData, in SP_DRVINFO_DATA_V2 DriverInfoData,
		IntPtr DriverInfoDetailData, uint DriverInfoDetailDataSize, out uint RequiredSize);

	/// <summary>
	/// The <c>SetupDiGetDriverInfoDetail</c> function retrieves driver information detail for a device information set or a particular
	/// device information element in the device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a driver information element for which to retrieve driver information.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element that represents the device for which to
	/// retrieve driver information. This parameter is optional and can be <c>NULL</c>. If this parameter is specified,
	/// <c>SetupDiGetDriverInfoDetail</c> retrieves information about a driver in a driver list for the specified device. If this parameter
	/// is <c>NULL</c>, <c>SetupDiGetDriverInfoDetail</c> retrieves information about a driver that is a member of the global class driver
	/// list for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInfoData">
	/// A pointer to an SP_DRVINFO_DATA structure that specifies the driver information element that represents the driver for which to
	/// retrieve details. If DeviceInfoData is specified, the driver must be a member of the driver list for the device that is specified by
	/// DeviceInfoData. Otherwise, the driver must be a member of the global class driver list for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInfoDetailData">An SP_DRVINFO_DETAIL_DATA structure that receives detailed information about the specified driver.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved by
	/// making a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// If the specified driver information member and the caller-supplied buffer are both valid, this function is guaranteed to fill in all
	/// static fields in the SP_DRVINFO_DETAIL_DATA structure and as many IDs as possible in the variable-length buffer at the end while
	/// still maintaining REG_MULTI_SZ format. In this case, the function returns <c>FALSE</c> and a call to GetLastError returns
	/// ERROR_INSUFFICIENT_BUFFER. If specified, RequiredSize contains the total number of bytes required for the structure with all IDs.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdriverinfodetaila WINSETUPAPI BOOL
	// SetupDiGetDriverInfoDetailA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DRVINFO_DATA_A DriverInfoData,
	// PSP_DRVINFO_DETAIL_DATA_A DriverInfoDetailData, DWORD DriverInfoDetailDataSize, PDWORD RequiredSize );
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDriverInfoDetailA")]
	public static bool SetupDiGetDriverInfoDetail(HDEVINFO DeviceInfoSet, [In, Optional] SP_DEVINFO_DATA? DeviceInfoData, in SP_DRVINFO_DATA_V2 DriverInfoData,
		[NotNullWhen(true)] out SP_DRVINFO_DETAIL_DATA? DriverInfoDetailData)
	{
		DriverInfoDetailData = null;
		using SafeCoTaskMemStruct<SP_DEVINFO_DATA> mem = DeviceInfoData;
		if (!SetupDiGetDriverInfoDetail(DeviceInfoSet, mem, DriverInfoData, IntPtr.Zero, 0, out var sz) && Win32Error.GetLastError() != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			return false;
		using var mem2 = new SafeCoTaskMemStruct<SP_DRVINFO_DETAIL_DATA>((int)sz);
		if (SetupDiGetDriverInfoDetail(DeviceInfoSet, mem, DriverInfoData, mem2, sz, out _))
		{
			DriverInfoDetailData = mem2.Value;
			return true;
		}
		return false;
	}

	/// <summary>
	/// The <c>SetupDiGetDriverInstallParams</c> function retrieves driver installation parameters for a device information set or a
	/// particular device information element.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a driver information element that represents the driver for which to retrieve
	/// installation parameters.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that contains a device information element that represents the device for which to
	/// retrieve installation parameters. This parameter is optional and can be <c>NULL</c>. If this parameter is specified,
	/// <c>SetupDiGetDriverInstallParams</c> retrieves information about a driver that is a member of a driver list for the specified
	/// device. If this parameter is <c>NULL</c>, <c>SetupDiGetDriverInstallParams</c> retrieves information about a driver that is a
	/// member of the global class driver list for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInfoData">
	/// A pointer to an SP_DRVINFO_DATA structure that specifies the driver information element that represents the driver for which to
	/// retrieve installation parameters. If DeviceInfoData is supplied, the driver must be a member of the driver list for the device
	/// that is specified by DeviceInfoData. Otherwise, the driver must be a member of the global class driver list for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInstallParams">
	/// A pointer to an SP_DRVINSTALL_PARAMS structure to receive the installation parameters for this driver.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to GetLastError.
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdriverinstallparamsa WINSETUPAPI BOOL
	// SetupDiGetDriverInstallParamsA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DRVINFO_DATA_A DriverInfoData,
	// PSP_DRVINSTALL_PARAMS DriverInstallParams );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDriverInstallParamsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDriverInstallParams(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
		in SP_DRVINFO_DATA_V2 DriverInfoData, ref SP_DRVINSTALL_PARAMS DriverInstallParams);

	/// <summary>
	/// The <c>SetupDiGetDriverInstallParams</c> function retrieves driver installation parameters for a device information set or a
	/// particular device information element.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a driver information element that represents the driver for which to retrieve
	/// installation parameters.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that contains a device information element that represents the device for which to
	/// retrieve installation parameters. This parameter is optional and can be <c>NULL</c>. If this parameter is specified,
	/// <c>SetupDiGetDriverInstallParams</c> retrieves information about a driver that is a member of a driver list for the specified
	/// device. If this parameter is <c>NULL</c>, <c>SetupDiGetDriverInstallParams</c> retrieves information about a driver that is a
	/// member of the global class driver list for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInfoData">
	/// A pointer to an SP_DRVINFO_DATA structure that specifies the driver information element that represents the driver for which to
	/// retrieve installation parameters. If DeviceInfoData is supplied, the driver must be a member of the driver list for the device
	/// that is specified by DeviceInfoData. Otherwise, the driver must be a member of the global class driver list for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInstallParams">
	/// A pointer to an SP_DRVINSTALL_PARAMS structure to receive the installation parameters for this driver.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to GetLastError.
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdriverinstallparamsa WINSETUPAPI BOOL
	// SetupDiGetDriverInstallParamsA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DRVINFO_DATA_A DriverInfoData,
	// PSP_DRVINSTALL_PARAMS DriverInstallParams );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDriverInstallParamsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetDriverInstallParams(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData,
		in SP_DRVINFO_DATA_V2 DriverInfoData, ref SP_DRVINSTALL_PARAMS DriverInstallParams);

	/// <summary>
	/// The <c>SetupDiGetHwProfileFriendlyName</c> function retrieves the friendly name associated with a hardware profile ID.
	/// </summary>
	/// <param name="HwProfile">
	/// The hardware profile ID associated with the friendly name to retrieve. If this parameter is 0, the friendly name for the current
	/// hardware profile is retrieved.
	/// </param>
	/// <param name="FriendlyName">A pointer to a string buffer to receive the friendly name.</param>
	/// <param name="FriendlyNameSize">The size, in characters, of the FriendlyName buffer.</param>
	/// <param name="RequiredSize">
	/// A pointer to a variable of type DWORD that receives the number of characters required to retrieve the friendly name (including a
	/// NULL terminator).
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks>Call SetupDiGetHwProfileFriendlyNameEx to get the friendly name of a hardware profile ID on a remote computer.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigethwprofilefriendlynamea WINSETUPAPI BOOL
	// SetupDiGetHwProfileFriendlyNameA( DWORD HwProfile, PSTR FriendlyName, DWORD FriendlyNameSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetHwProfileFriendlyNameA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetHwProfileFriendlyName(uint HwProfile, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder FriendlyName,
		uint FriendlyNameSize, out uint RequiredSize);

	/// <summary>
	/// The <c>SetupDiGetHwProfileFriendlyNameEx</c> function retrieves the friendly name associated with a hardware profile ID on a
	/// local or remote computer.
	/// </summary>
	/// <param name="HwProfile">
	/// Supplies the hardware profile ID associated with the friendly name to retrieve. If this parameter is 0, the friendly name for
	/// the current hardware profile is retrieved.
	/// </param>
	/// <param name="FriendlyName">A pointer to a character buffer to receive the friendly name.</param>
	/// <param name="FriendlyNameSize">The size, in characters, of the FriendlyName buffer.</param>
	/// <param name="RequiredSize">
	/// A pointer to a variable to receive the number of characters required to store the friendly name (including a NULL terminator).
	/// This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="MachineName">
	/// A pointer to NULL-terminated string that contains the name of a remote computer on which the hardware profile ID resides. This
	/// parameter is optional and can be <c>NULL</c>. If MachineName is <c>NULL</c>, the hardware profile ID is on the local computer.
	/// </param>
	/// <param name="Reserved">Must be <c>NULL</c>.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigethwprofilefriendlynameexa WINSETUPAPI BOOL
	// SetupDiGetHwProfileFriendlyNameExA( DWORD HwProfile, PSTR FriendlyName, DWORD FriendlyNameSize, PDWORD RequiredSize, PCSTR
	// MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetHwProfileFriendlyNameExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetHwProfileFriendlyNameEx(uint HwProfile, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder FriendlyName,
		uint FriendlyNameSize, out uint RequiredSize, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? MachineName, [In, Optional] IntPtr Reserved);

	/// <summary>The <c>SetupDiGetHwProfileList</c> function retrieves a list of all currently defined hardware profile IDs.</summary>
	/// <param name="HwProfileList">A pointer to an array to receive the list of currently defined hardware profile IDs.</param>
	/// <param name="HwProfileListSize">The number of DWORDs in the HwProfileList buffer.</param>
	/// <param name="RequiredSize">
	/// A pointer to a variable of type DWORD that receives the number of hardware profiles currently defined. If the number is larger
	/// than HwProfileListSize, the list is truncated to fit the array size. The value returned in RequiredSize indicates the array size
	/// required to store the entire list of hardware profiles. In this case, the function fails and a call to GetLastError returns ERROR_INSUFFICIENT_BUFFER.
	/// </param>
	/// <param name="CurrentlyActiveIndex">
	/// A pointer to a variable of type DWORD that receives the index of the currently active hardware profile in the retrieved hardware
	/// profile list. This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks>Call SetupDiGetHwProfileListEx to retrieve the hardware profile IDs for a remote computer.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigethwprofilelist WINSETUPAPI BOOL
	// SetupDiGetHwProfileList( PDWORD HwProfileList, DWORD HwProfileListSize, PDWORD RequiredSize, PDWORD CurrentlyActiveIndex );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetHwProfileList")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetHwProfileList([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] HwProfileList,
		uint HwProfileListSize, out uint RequiredSize, out uint CurrentlyActiveIndex);

	/// <summary>
	/// The <c>SetupDiGetHwProfileListEx</c> function retrieves a list of all currently defined hardware profile IDs on a local or
	/// remote computer.
	/// </summary>
	/// <param name="HwProfileList">A pointer to an array to receive the list of currently defined hardware profile IDs.</param>
	/// <param name="HwProfileListSize">The number of DWORDs in the HwProfileList buffer.</param>
	/// <param name="RequiredSize">
	/// A pointer to a variable of type DWORD that receives the number of hardware profiles that are currently defined. If the number is
	/// larger than HwProfileListSize, the list is truncated to fit the array size. The value returned in RequiredSize indicates the
	/// array size required to store the entire list of hardware profiles.
	/// </param>
	/// <param name="CurrentlyActiveIndex">
	/// A pointer to a variable that receives the index of the currently active hardware profile in the retrieved hardware profile list.
	/// This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="MachineName">
	/// A pointer to a NULL-terminated string that contains the name of a remote system for which to retrieve the list of hardware
	/// profile IDs. This parameter is optional and can be <c>NULL</c>. If this parameter is <c>NULL</c>, the list is retrieved for the
	/// local system.
	/// </param>
	/// <param name="Reserved">Must be <c>NULL</c>.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError. If the required size is larger than HwProfileListSize, <c>SetupDiGetHwProfileListEx</c>
	/// returns <c>FALSE</c> and a call to GetLastError returns ERROR_INSUFFICIENT_BUFFER.
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigethwprofilelistexa WINSETUPAPI BOOL
	// SetupDiGetHwProfileListExA( PDWORD HwProfileList, DWORD HwProfileListSize, PDWORD RequiredSize, PDWORD CurrentlyActiveIndex,
	// PCSTR MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetHwProfileListExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetHwProfileListEx([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] HwProfileList,
		uint HwProfileListSize, out uint RequiredSize, out uint CurrentlyActiveIndex,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? MachineName, [In, Optional] IntPtr Reserved);

	/// <summary>The <c>SetupDiGetINFClass</c> function returns the class of a specified device INF file.</summary>
	/// <param name="InfName">
	/// A pointer to a NULL-terminated string that supplies the name of a device INF file. This name can include a path. However, if
	/// just the file name is specified, the file is searched for in each directory that is listed in the <c>DevicePath</c> entry under
	/// the <c>HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion</c> subkey of the registry. The maximum length in characters, including a
	/// NULL terminator, of a NULL-terminated INF file name is MAX_PATH.
	/// </param>
	/// <param name="ClassGuid">
	/// A pointer to a variable of type GUID that receives the class GUID for the specified INF file. If the INF file does not specify a
	/// class name, the function returns a GUID_NULL structure. Call SetupDiClassGuidsFromName to determine whether one or more classes
	/// with this name are already installed.
	/// </param>
	/// <param name="ClassName">
	/// A pointer to a buffer that receives a NULL-terminated string that contains the name of the class for the specified INF file. If
	/// the INF file does not specify a class name but does specify a GUID, this buffer receives the name that is retrieved by calling
	/// SetupDiClassNameFromGuid. However, if <c>SetupDiClassNameFromGuid</c> cannot retrieve a class name (for example, the class is
	/// not installed), it returns an empty string.
	/// </param>
	/// <param name="ClassNameSize">
	/// The size, in characters, of the buffer that is pointed to by the ClassName parameter. The maximum length of a NULL-terminated
	/// class name, in characters, is MAX_CLASS_NAME_LEN.
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to a DWORD-typed variable that receives the number of characters that are required to store the class name, including
	/// a terminating <c>NULL</c>. This pointer is optional and can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>Do not use this function with INF files for Windows 9x or Millennium Edition.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetinfclassw WINSETUPAPI BOOL SetupDiGetINFClassW(
	// PCWSTR InfName, LPGUID ClassGuid, PWSTR ClassName, DWORD ClassNameSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetINFClassW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetINFClass([MarshalAs(UnmanagedType.LPTStr)] string InfName, out Guid ClassGuid,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder ClassName, uint ClassNameSize, out uint RequiredSize);

	/// <summary>
	/// The <c>SetupDiGetSelectedDevice</c> function retrieves the selected device information element in a device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to the device information set for which to retrieve the selected device information element.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that receives information about the selected device information element for
	/// DeviceInfoSet. The caller must set DeviceInfoData. <c>cbSize</c> to <c>sizeof</c>(SP_DEVINFO_DATA). If a device is currently not
	/// selected, the function fails and a call to GetLastError returns ERROR_NO_DEVICE_SELECTED.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks><c>SetupDiGetSelectedDevice</c> is usually used by an installation wizard.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetselecteddevice WINSETUPAPI BOOL
	// SetupDiGetSelectedDevice( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetSelectedDevice")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetSelectedDevice(HDEVINFO DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiGetSelectedDriver</c> function retrieves the selected driver for a device information set or a particular device
	/// information element.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to the device information set for which to retrieve a selected driver.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element that represents the device in
	/// DeviceInfoSet for which to retrieve the selected driver. This parameter is optional and can be <c>NULL</c>. If this parameter is
	/// specified, <c>SetupDiGetSelectedDriver</c> retrieves the selected driver for the specified device. If this parameter is
	/// <c>NULL</c>, <c>SetupDiGetSelectedDriver</c> retrieves the selected class driver in the global class driver list that is
	/// associated with DeviceInfoSet.
	/// </param>
	/// <param name="DriverInfoData">A pointer to an SP_DRVINFO_DATA structure that receives information about the selected driver.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError. If a driver has not been selected for the specified device instance, the logged error is ERROR_NO_DRIVER_SELECTED.
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetselecteddriverw WINSETUPAPI BOOL
	// SetupDiGetSelectedDriverW( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DRVINFO_DATA_W DriverInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetSelectedDriverW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetSelectedDriver(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, ref SP_DRVINFO_DATA_V2 DriverInfoData);

	/// <summary>
	/// The <c>SetupDiGetSelectedDriver</c> function retrieves the selected driver for a device information set or a particular device
	/// information element.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to the device information set for which to retrieve a selected driver.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element that represents the device in
	/// DeviceInfoSet for which to retrieve the selected driver. This parameter is optional and can be <c>NULL</c>. If this parameter is
	/// specified, <c>SetupDiGetSelectedDriver</c> retrieves the selected driver for the specified device. If this parameter is
	/// <c>NULL</c>, <c>SetupDiGetSelectedDriver</c> retrieves the selected class driver in the global class driver list that is
	/// associated with DeviceInfoSet.
	/// </param>
	/// <param name="DriverInfoData">A pointer to an SP_DRVINFO_DATA structure that receives information about the selected driver.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError. If a driver has not been selected for the specified device instance, the logged error is ERROR_NO_DRIVER_SELECTED.
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetselecteddriverw WINSETUPAPI BOOL
	// SetupDiGetSelectedDriverW( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DRVINFO_DATA_W DriverInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetSelectedDriverW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetSelectedDriver(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData, ref SP_DRVINFO_DATA_V2 DriverInfoData);

	/// <summary>The <c>SetupDiInstallClass</c> function installs the <c>ClassInstall32</c> section of the specified INF file.</summary>
	/// <param name="hwndParent">
	/// The handle to the parent window for any user interface that is used to install this class. This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="InfFileName">
	/// A pointer to a NULL-terminated string that contains the name of the INF file that contains an INF ClassInstall32 section.
	/// </param>
	/// <param name="Flags">
	/// <para>These flags control the installation process. Can be a combination of the following:</para>
	/// <para>DI_NOVCP</para>
	/// <para>
	/// Set this flag if FileQueue is supplied. DI_NOVCP instructs the <c>SetupInstallFromInfSection</c> function (described in
	/// Microsoft Windows SDK documentation) not to create a queue of its own and to use the caller-supplied queue instead. If this flag
	/// is set, files are not copied just queued.
	/// </para>
	/// <para>DI_NOBROWSE</para>
	/// <para>
	/// Set this flag to disable browsing if a copy operation cannot find a specified file. If the caller supplies a file queue, this
	/// flag is ignored.
	/// </para>
	/// <para>DI_FORCECOPY</para>
	/// <para>
	/// Set this flag to always copy files, even if they are already present on the user's computer. If the caller supplies a file
	/// queue, this flag is ignored.
	/// </para>
	/// <para>DI_QUIETINSTALL</para>
	/// <para>
	/// Set this flag to suppress the user interface unless absolutely necessary. For example, do not display the progress dialog. If
	/// the caller supplies a file queue, this flag is ignored.
	/// </para>
	/// </param>
	/// <param name="FileQueue">
	/// If the DI_NOVCP flag is set, this parameter supplies a handle to a file queue where file operations should be queued but not committed.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must be a member of the Administrators group.</para>
	/// <para>This function is called by a class installer when it installs a device of a new device class.</para>
	/// <para>To install an interface class or a device class, use SetupDiInstallClassEx.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiinstallclassa WINSETUPAPI BOOL
	// SetupDiInstallClassA( HWND hwndParent, PCSTR InfFileName, DWORD Flags, HSPFILEQ FileQueue );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiInstallClassA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiInstallClass([In, Optional] HWND hwndParent, [MarshalAs(UnmanagedType.LPTStr)] string InfFileName,
		DI_FLAGS Flags, [In, Optional] HSPFILEQ FileQueue);

	/// <summary>The <c>SetupDiInstallClassEx</c> function installs a class installer or an interface class.</summary>
	/// <param name="hwndParent">
	/// The handle to the parent window for any user interface that is used to install this class. This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="InfFileName">
	/// <para>
	/// A pointer to a NULL-terminated string that contains the name of an INF file. This parameter is optional and can be <c>NULL</c>.
	/// If this function is being used to install a class installer, the INF file contains an INF ClassInstall32 section and this
	/// parameter must not be <c>NULL</c>.
	/// </para>
	/// <para>If this function is being used to install an interface class, the INF file contains an INF InterfaceInstall32 section.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>A value of type DWORD that controls the installation process. Flags can be zero or a bitwise OR of the following values:</para>
	/// <para>DI_NOVCP</para>
	/// <para>Set this flag if FileQueue is supplied.</para>
	/// <para>
	/// DI_NOVCP instructs the <c>SetupInstallFromInfSection</c> function not to create a queue of its own and to use the
	/// caller-supplied queue instead.
	/// </para>
	/// <para>If this flag is set, files are not copied just queued.</para>
	/// <para>For more information about the <c>SetupInstallFromInfSection</c> function, see the Microsoft Windows SDK documentation.</para>
	/// <para>DI_NOBROWSE</para>
	/// <para>
	/// Set this flag to disable browsing if a copy operation cannot find a specified file. If the caller supplies a file queue, this
	/// flag is ignored.
	/// </para>
	/// <para>DI_FORCECOPY</para>
	/// <para>
	/// Set this flag to always copy files, even if they are already present on the user's computer. If the caller supplies a file
	/// queue, this flag is ignored.
	/// </para>
	/// <para>DI_QUIETINSTALL</para>
	/// <para>
	/// Set this flag to suppress the user interface unless absolutely necessary. For example, do not display the progress dialog. If
	/// the caller supplies a file queue, this flag is ignored.
	/// </para>
	/// </param>
	/// <param name="FileQueue">
	/// If the DI_NOVCP flag is set, this parameter supplies a handle to a file queue where file operations should be queued but not committed.
	/// </param>
	/// <param name="InterfaceClassGuid">
	/// A pointer to a GUID that identifies the interface class to be installed. This parameter is optional and can be <c>NULL</c>. If
	/// this parameter is specified, this function is being used to install the interface class represented by the GUID. If this
	/// parameter is <c>NULL</c>, this function is being used to install a class installer.
	/// </param>
	/// <param name="Reserved1">Reserved. Must be zero.</param>
	/// <param name="Reserved2">Reserved. Must be zero.</param>
	/// <returns>
	/// <c>SetupDiInstallClassEx</c> returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error
	/// can be retrieved with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must be a member of the Administrators group.</para>
	/// <para>
	/// <c>SetupDiInstallClassEx</c> is typically called by a class installer to install a new device setup class or a new device
	/// interface class.
	/// </para>
	/// <para>
	/// <c>Note</c> An interface class can also be installed automatically by calling SetupDiInstallDeviceInterfaces to install the
	/// device interfaces for a device.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiinstallclassexw WINSETUPAPI BOOL
	// SetupDiInstallClassExW( HWND hwndParent, PCWSTR InfFileName, DWORD Flags, HSPFILEQ FileQueue, const GUID *InterfaceClassGuid,
	// PVOID Reserved1, PVOID Reserved2 );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiInstallClassExW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiInstallClassEx([In, Optional] HWND hwndParent, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? InfFileName,
		DI_FLAGS Flags, [In, Optional] HSPFILEQ FileQueue, in Guid InterfaceClassGuid, [In, Optional] IntPtr Reserved1, [In, Optional] IntPtr Reserved2);

	/// <summary>The <c>SetupDiInstallClassEx</c> function installs a class installer or an interface class.</summary>
	/// <param name="hwndParent">
	/// The handle to the parent window for any user interface that is used to install this class. This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="InfFileName">
	/// <para>
	/// A pointer to a NULL-terminated string that contains the name of an INF file. This parameter is optional and can be <c>NULL</c>.
	/// If this function is being used to install a class installer, the INF file contains an INF ClassInstall32 section and this
	/// parameter must not be <c>NULL</c>.
	/// </para>
	/// <para>If this function is being used to install an interface class, the INF file contains an INF InterfaceInstall32 section.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>A value of type DWORD that controls the installation process. Flags can be zero or a bitwise OR of the following values:</para>
	/// <para>DI_NOVCP</para>
	/// <para>Set this flag if FileQueue is supplied.</para>
	/// <para>
	/// DI_NOVCP instructs the <c>SetupInstallFromInfSection</c> function not to create a queue of its own and to use the
	/// caller-supplied queue instead.
	/// </para>
	/// <para>If this flag is set, files are not copied just queued.</para>
	/// <para>For more information about the <c>SetupInstallFromInfSection</c> function, see the Microsoft Windows SDK documentation.</para>
	/// <para>DI_NOBROWSE</para>
	/// <para>
	/// Set this flag to disable browsing if a copy operation cannot find a specified file. If the caller supplies a file queue, this
	/// flag is ignored.
	/// </para>
	/// <para>DI_FORCECOPY</para>
	/// <para>
	/// Set this flag to always copy files, even if they are already present on the user's computer. If the caller supplies a file
	/// queue, this flag is ignored.
	/// </para>
	/// <para>DI_QUIETINSTALL</para>
	/// <para>
	/// Set this flag to suppress the user interface unless absolutely necessary. For example, do not display the progress dialog. If
	/// the caller supplies a file queue, this flag is ignored.
	/// </para>
	/// </param>
	/// <param name="FileQueue">
	/// If the DI_NOVCP flag is set, this parameter supplies a handle to a file queue where file operations should be queued but not committed.
	/// </param>
	/// <param name="InterfaceClassGuid">
	/// A pointer to a GUID that identifies the interface class to be installed. This parameter is optional and can be <c>NULL</c>. If
	/// this parameter is specified, this function is being used to install the interface class represented by the GUID. If this
	/// parameter is <c>NULL</c>, this function is being used to install a class installer.
	/// </param>
	/// <param name="Reserved1">Reserved. Must be zero.</param>
	/// <param name="Reserved2">Reserved. Must be zero.</param>
	/// <returns>
	/// <c>SetupDiInstallClassEx</c> returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error
	/// can be retrieved with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must be a member of the Administrators group.</para>
	/// <para>
	/// <c>SetupDiInstallClassEx</c> is typically called by a class installer to install a new device setup class or a new device
	/// interface class.
	/// </para>
	/// <para>
	/// <c>Note</c> An interface class can also be installed automatically by calling SetupDiInstallDeviceInterfaces to install the
	/// device interfaces for a device.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiinstallclassexw WINSETUPAPI BOOL
	// SetupDiInstallClassExW( HWND hwndParent, PCWSTR InfFileName, DWORD Flags, HSPFILEQ FileQueue, const GUID *InterfaceClassGuid,
	// PVOID Reserved1, PVOID Reserved2 );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiInstallClassExW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiInstallClassEx([In, Optional] HWND hwndParent, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? InfFileName,
		DI_FLAGS Flags, [In, Optional] HSPFILEQ FileQueue, [In, Optional] IntPtr InterfaceClassGuid, [In, Optional] IntPtr Reserved1,
		[In, Optional] IntPtr Reserved2);

	/// <summary>The <c>SetupDiInstallDevice</c> function is the default handler for the DIF_INSTALLDEVICE installation request.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set for the local system that contains a device information element that represents the
	/// device to install.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element in DeviceInfoSet. This is an IN-OUT
	/// parameter because DeviceInfoData. <c>DevInst</c> might be updated with a new handle value upon return.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiInstallDevice</c> installs a driver from the INF file. SetupAPI's definition of the "driver" is really a "driver
	/// node." Therefore, when this function installs a driver, it also installs the items in the following list:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The service(s) for the device.</term>
	/// </item>
	/// <item>
	/// <term>The driver files.</term>
	/// </item>
	/// <item>
	/// <term>Device-specific co-installers (if any).</term>
	/// </item>
	/// <item>
	/// <term>Property-page providers (if any).</term>
	/// </item>
	/// <item>
	/// <term>Control-panel applets (if any).</term>
	/// </item>
	/// </list>
	/// <para>This function also registers any required device interfaces.</para>
	/// <para>A successful installation includes, but is not limited to, the following steps:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Create a driver key in the registry and write appropriate entries (such as <c>InfPath</c> and <c>ProviderName</c>).</term>
	/// </item>
	/// <item>
	/// <term>
	/// Locate and process the INF DDInstall section for the device. The section might be OS/architecture-specific. The DDInstall
	/// section's <c>AddReg</c> and <c>DelReg</c> entries are directed at the device's software key. Locate and process the DDInstall
	/// <c>.HW</c> section whose <c>AddReg</c> and <c>DelReg</c> entries are directed at the device's hardware key. Locate and process
	/// the INF DDInstall.LogConfigOverride section, if present, to supply an override configuration for the device. Locate and process
	/// the INF DDInstall.Services section to add services for the device (and potentially remove any old services that are no longer necessary).
	/// </term>
	/// </item>
	/// <item>
	/// <term>Copy the INF file to the system INF directory.</term>
	/// </item>
	/// <item>
	/// <term>Possibly perform the other file operations, based on flag settings in the device installation parameters.</term>
	/// </item>
	/// <item>
	/// <term>Load the drivers for the device. This includes the function driver and any upper or lower-filter drivers.</term>
	/// </item>
	/// <item>
	/// <term>Call the drivers' AddDevice routines.</term>
	/// </item>
	/// <item>
	/// <term>Start the device by sending an IRP_MN_START_DEVICE I/O request packet (IRP).</term>
	/// </item>
	/// </list>
	/// <para>
	/// Windows does not start the device if the DI_NEEDRESTART, DI_NEEDREBOOT, or DI_DONOTCALLCONFIGMG flag is set in the
	/// SP_DEVINSTALL_PARAMS structure.
	/// </para>
	/// <para>
	/// A class installer should return ERROR_DI_DO_DEFAULT or call this function when handling a DIF_INSTALLDEVICE request. This
	/// function performs many tasks for device installation and that list of tasks might be expanded in future releases. If a class
	/// installer performs device installation without calling this function, the class installer might not work correctly on future
	/// versions of the operating system.
	/// </para>
	/// <para>
	/// If Windows cannot locate an INF file for the device, it will send DIF_INSTALLDEVICE in an attempt to install a null driver.
	/// <c>SetupDiInstallDevice</c> installs a null driver only if the device supports raw mode or is a non-PnP device (reported by
	/// IoReportDetectedDevice). For more information, see DIF_INSTALLDEVICE.
	/// </para>
	/// <para>
	/// If the DI_FLAGSEX_SETFAILEDINSTALL flag is set in the SP_DEVINSTALL_PARAMS structure, <c>SetupDiInstallDevice</c> just sets the
	/// FAILEDINSTALL flag in the device's <c>ConfigFlags</c> registry value.
	/// </para>
	/// <para>
	/// <c>Note</c> Only a class installer should call <c>SetupDiInstallDevice</c> and only in those situations where the class
	/// installer must perform device installation operations after <c>SetupDiInstallDevice</c> completes the default device
	/// installation operation. In such situations, the class installer must directly call <c>SetupDiInstallDevice</c> when the
	/// installer processes a DIF_INSTALLDEVICE request. For more information about calling the default handler, see Calling Default DIF
	/// Code Handlers.
	/// </para>
	/// <para>The caller of <c>SetupDiInstallDevice</c> must be a member of the Administrators group.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiinstalldevice WINSETUPAPI BOOL
	// SetupDiInstallDevice( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiInstallDevice")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiInstallDevice(HDEVINFO DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiInstallDeviceInterfaces</c> function is the default handler for the DIF_INSTALLINTERFACES installation request.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A pointer to the device information set that contains a device information element that represents the device for which to
	/// install interfaces. The device information set must contain only elements for the local system.
	/// </param>
	/// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
	/// <returns>
	/// <c>SetupDiInstallDeviceInterfaces</c> returns <c>TRUE</c> if the function completed without error. If the function completed
	/// with an error, <c>FALSE</c> is returned and the error code for the failure can be retrieved by calling GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiInstallDeviceInterfaces</c> processes each <c>AddInterface</c> entry in the DDInstall. <c>Interfaces</c> section of a
	/// device INF file and creates each interface by calling SetupDiCreateDeviceInterface.
	/// </para>
	/// <para>The caller of <c>SetupDiInstallDeviceInterfaces</c> must be a member of the Administrators group.</para>
	/// <para>
	/// <c>Note</c> Only a class installer should call <c>SetupDiInstallDeviceInterfaces</c> and only in those situations where the
	/// class installer must perform device interface installation operations after <c>SetupDiInstallDeviceInterfaces</c> completes the
	/// default device interface installation operation. In such situations, the class installer must directly call
	/// <c>SetupDiInstallDeviceInterfaces</c> when the installer processes a DIF_INSTALLINTERFACES request. For more information about
	/// calling the default handler, see Calling Default DIF Code Handlers.
	/// </para>
	/// <para>For information about INF file format, see INF File Sections and Directives.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiinstalldeviceinterfaces WINSETUPAPI BOOL
	// SetupDiInstallDeviceInterfaces( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiInstallDeviceInterfaces")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiInstallDeviceInterfaces(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiInstallDriverFiles</c> function is the default handler for the DIF_INSTALLDEVICEFILES installation request.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set that contains the device information element that represents the device for which to
	/// install files. The device information set must not contain remote elements.
	/// </param>
	/// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller of <c>SetupDiInstallDriverFiles</c> must be a member of the Administrators group if this function is being used to
	/// install files. However, if this function is being used to build up a file queue, membership in the Administrators group is not required.
	/// </para>
	/// <para>
	/// <c>Note</c> Only a class installer should call <c>SetupDiInstallDriverFiles</c> and only in those situations where the class
	/// installer must perform driver file installation operations after <c>SetupDiInstallDriverFiles</c> completes the default driver
	/// file installation operation. In such situations, the class installer must directly call <c>SetupDiInstallDriverFiles</c> when
	/// the installer processes a DIF_INSTALLDEVICEFILES request. For more information about calling the default handler, see Calling
	/// Default DIF Code Handlers.
	/// </para>
	/// <para>
	/// The operation of <c>SetupDiInstallDriverFiles</c> is similar to the SetupDiInstallDevice function. However, this function
	/// performs only the file copy operations that are performed by <c>SetupDiInstallDevice</c>.
	/// </para>
	/// <para>A driver must be selected for the specified device information set or element before this function is called.</para>
	/// <para>This function processes the <c>CopyFiles</c>, <c>Delfiles</c>, and <c>Renfiles</c> entries in the selected INF file.</para>
	/// <para>The DeviceInfoSet must only contain elements on the local computer.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiinstalldriverfiles WINSETUPAPI BOOL
	// SetupDiInstallDriverFiles( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiInstallDriverFiles")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiInstallDriverFiles(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>The <c>SetupDiLoadClassIcon</c> function loads both the large and mini-icon for the specified class.</summary>
	/// <param name="ClassGuid">A pointer to the GUID of the class for which the icon(s) should be loaded.</param>
	/// <param name="LargeIcon">
	/// A pointer to an icon handle that receives the handle value for the loaded large icon for the specified class. This pointer is
	/// optional and can be <c>NULL</c>. If the pointer is <c>NULL</c>, the large icon is not loaded.
	/// </param>
	/// <param name="MiniIconIndex">
	/// A pointer to an INT-typed variable that receives the index of the mini-icon for the specified class. The mini-icon is stored in
	/// the device installer's mini-icon cache. The pointer is optional and can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The icons of the class are either predefined and loaded from the device installer's internal cache, or they are loaded directly
	/// from the class installer's executable. This function queries the registry value <c>ICON</c> in the specified class's section. If
	/// the <c>ICON</c> value is specified, it indicates which mini-icon to load.
	/// </para>
	/// <para>
	/// If the <c>ICON</c> value is negative, the absolute value represents a predefined icon in the class's registry. See
	/// SetupDiDrawMiniIcon for a list of the predefined mini-icons.
	/// </para>
	/// <para>
	/// If the <c>ICON</c> value is positive, it represents an icon in the class installer's executable image that will be extracted.
	/// The value 1 is reserved. This function also uses the <c>INSTALLER32</c> registry value and then the <c>ENUMPROPPAGES32</c>
	/// registry value to determine which executable image to extract the icons from. For more information about these registry values,
	/// see INF ClassInstall32 Section.
	/// </para>
	/// <para>
	/// When a caller is finished using the icon, the caller must call <c>DestroyIcon</c> (which is described in the Microsoft Windows
	/// SDK documentation).
	/// </para>
	/// <para>
	/// If the LargeIcon parameter is specified, but the ClassGuid parameter does not supply a valid class GUID or the <c>Icon</c>
	/// registry value of the class is not valid, <c>SetupDiLoadClassIcon</c> loads the default large icon, returns the handle for the
	/// large icon, and, if the MiniIconIndex parameter is specified, returns the index of the default mini-icon.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiloadclassicon WINSETUPAPI BOOL
	// SetupDiLoadClassIcon( const GUID *ClassGuid, HICON *LargeIcon, PINT MiniIconIndex );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiLoadClassIcon")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiLoadClassIcon(in Guid ClassGuid, out HICON LargeIcon, out int MiniIconIndex);

	/// <summary>The <c>SetupDiLoadClassIcon</c> function loads both the large and mini-icon for the specified class.</summary>
	/// <param name="ClassGuid">A pointer to the GUID of the class for which the icon(s) should be loaded.</param>
	/// <param name="LargeIcon">
	/// A pointer to an icon handle that receives the handle value for the loaded large icon for the specified class. This pointer is
	/// optional and can be <c>NULL</c>. If the pointer is <c>NULL</c>, the large icon is not loaded.
	/// </param>
	/// <param name="MiniIconIndex">
	/// A pointer to an INT-typed variable that receives the index of the mini-icon for the specified class. The mini-icon is stored in
	/// the device installer's mini-icon cache. The pointer is optional and can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The icons of the class are either predefined and loaded from the device installer's internal cache, or they are loaded directly
	/// from the class installer's executable. This function queries the registry value <c>ICON</c> in the specified class's section. If
	/// the <c>ICON</c> value is specified, it indicates which mini-icon to load.
	/// </para>
	/// <para>
	/// If the <c>ICON</c> value is negative, the absolute value represents a predefined icon in the class's registry. See
	/// SetupDiDrawMiniIcon for a list of the predefined mini-icons.
	/// </para>
	/// <para>
	/// If the <c>ICON</c> value is positive, it represents an icon in the class installer's executable image that will be extracted.
	/// The value 1 is reserved. This function also uses the <c>INSTALLER32</c> registry value and then the <c>ENUMPROPPAGES32</c>
	/// registry value to determine which executable image to extract the icons from. For more information about these registry values,
	/// see INF ClassInstall32 Section.
	/// </para>
	/// <para>
	/// When a caller is finished using the icon, the caller must call <c>DestroyIcon</c> (which is described in the Microsoft Windows
	/// SDK documentation).
	/// </para>
	/// <para>
	/// If the LargeIcon parameter is specified, but the ClassGuid parameter does not supply a valid class GUID or the <c>Icon</c>
	/// registry value of the class is not valid, <c>SetupDiLoadClassIcon</c> loads the default large icon, returns the handle for the
	/// large icon, and, if the MiniIconIndex parameter is specified, returns the index of the default mini-icon.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiloadclassicon WINSETUPAPI BOOL
	// SetupDiLoadClassIcon( const GUID *ClassGuid, HICON *LargeIcon, PINT MiniIconIndex );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiLoadClassIcon")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiLoadClassIcon(in Guid ClassGuid, [In, Optional] IntPtr LargeIcon, [In, Optional] IntPtr MiniIconIndex);

	/// <summary>The <c>SetupDiLoadDeviceIcon</c> function retrieves an icon for a specified device.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set that contains the device information element that represents the device for which to
	/// retrieve an icon.
	/// </param>
	/// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
	/// <param name="cxIcon">
	/// The width, in pixels, of the icon to be retrieved. Use the system metric index SM_CXICON to specify a default-sized icon or use
	/// the system metric index SM_CXSMICON to specify a small icon. The system metric indexes are defined in Winuser.h, and their
	/// associated values can be retrieved by a call to the GetSystemMetrics function. (The <c>GetSystemMetrics</c> function is
	/// documented in the Microsoft Windows SDK.)
	/// </param>
	/// <param name="cyIcon">
	/// The height, in pixels, of the icon to be retrieved. Use SM_CXICON to specify a default-sized icon or use SM_CXSMICON to specify
	/// a small icon.
	/// </param>
	/// <param name="Flags">Not used. Must set to zero.</param>
	/// <param name="hIcon">
	/// A pointer to a handle to an icon that receives a handle to the icon that this function retrieves. After the application that
	/// calls this function is finished using the icon, the application must call DestroyIcon to delete the icon. ( <c>DestroyIcon</c>
	/// is documented in the Microsoft Windows SDK.)
	/// </param>
	/// <returns>
	/// <c>SetupDiLoadDeviceIcon</c> returns <c>TRUE</c> if the function succeeds in retrieving the icon for the specified device.
	/// Otherwise, the function returns <c>FALSE</c> and the logged error can be retrieved by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para><c>SetupDiLoadDeviceIcon</c> attempts to retrieve an icon for the device as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the DEVPKEY_DrvPkg_Icon device property of the device includes a list of resource-identifier strings, the function attempts
	/// to retrieve the icon that is specified by the first resource-identifier string in the list.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the function cannot retrieve a device-specific icon, it will then attempt to retrieve the class icon for the device. For
	/// information about class icons, see SetupDiLoadClassIcon.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the function cannot retrieve the class icon for the device, it will then attempt to retrieve the icon for the Unknown device
	/// setup class, where the icon for the Unknown device setup class includes the image of a question mark (?).
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiloaddeviceicon WINSETUPAPI BOOL
	// SetupDiLoadDeviceIcon( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, UINT cxIcon, UINT cyIcon, DWORD Flags, HICON
	// *hIcon );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiLoadDeviceIcon")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiLoadDeviceIcon(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, uint cxIcon, uint cyIcon,
		[In, Optional] uint Flags, out HICON hIcon);

	/// <summary>The <c>SetupDiOpenClassRegKey</c> function opens the setup class registry key or a specific class's subkey.</summary>
	/// <param name="ClassGuid">
	/// A pointer to the GUID of the setup class whose key is to be opened. This parameter is optional and can be <c>NULL</c>. If this
	/// parameter is <c>NULL</c>, the root of the setup class tree ( <c>HKLM\SYSTEM\CurrentControlSet\Control\Class</c>) is opened.
	/// </param>
	/// <param name="samDesired">
	/// The registry security access for the key to be opened. For information about registry security access values of type REGSAM, see
	/// the Microsoft Windows SDK documentation.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function is successful, it returns a handle to an opened registry key where information about this setup class can be stored/retrieved.
	/// </para>
	/// <para>If the function fails, it returns INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on the value that is passed in the samDesired parameter, it might be necessary for the caller of this function to be a
	/// member of the Administrators group.
	/// </para>
	/// <para>This function does not create a registry key if it does not already exist.</para>
	/// <para>The handle returned from this function must be closed by calling RegCloseKey.</para>
	/// <para>To open the interface class registry key or a specific interface class subkey, call SetupDiOpenClassRegKeyEx.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiopenclassregkey WINSETUPAPI HKEY
	// SetupDiOpenClassRegKey( const GUID *ClassGuid, REGSAM samDesired );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiOpenClassRegKey")]
	public static extern SafeRegistryHandle SetupDiOpenClassRegKey(in Guid ClassGuid, RegistryRights samDesired);

	/// <summary>The <c>SetupDiOpenClassRegKey</c> function opens the setup class registry key or a specific class's subkey.</summary>
	/// <param name="ClassGuid">
	/// A pointer to the GUID of the setup class whose key is to be opened. This parameter is optional and can be <c>NULL</c>. If this
	/// parameter is <c>NULL</c>, the root of the setup class tree ( <c>HKLM\SYSTEM\CurrentControlSet\Control\Class</c>) is opened.
	/// </param>
	/// <param name="samDesired">
	/// The registry security access for the key to be opened. For information about registry security access values of type REGSAM, see
	/// the Microsoft Windows SDK documentation.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function is successful, it returns a handle to an opened registry key where information about this setup class can be stored/retrieved.
	/// </para>
	/// <para>If the function fails, it returns INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on the value that is passed in the samDesired parameter, it might be necessary for the caller of this function to be a
	/// member of the Administrators group.
	/// </para>
	/// <para>This function does not create a registry key if it does not already exist.</para>
	/// <para>The handle returned from this function must be closed by calling RegCloseKey.</para>
	/// <para>To open the interface class registry key or a specific interface class subkey, call SetupDiOpenClassRegKeyEx.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiopenclassregkey WINSETUPAPI HKEY
	// SetupDiOpenClassRegKey( const GUID *ClassGuid, REGSAM samDesired );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiOpenClassRegKey")]
	public static extern SafeRegistryHandle SetupDiOpenClassRegKey([In, Optional] IntPtr ClassGuid, RegistryRights samDesired);

	/// <summary>
	/// The <c>SetupDiOpenClassRegKeyEx</c> function opens the device setup class registry key, the device interface class registry key,
	/// or a specific class's subkey. This function opens the specified key on the local computer or on a remote computer.
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to the GUID of the class whose registry key is to be opened. This parameter is optional and can be <c>NULL</c>. If
	/// this parameter is <c>NULL</c>, the root of the class tree ( <c>HKLM\SYSTEM\CurrentControlSet\Control\Class</c>) is opened.
	/// </param>
	/// <param name="samDesired">
	/// The registry security access for the key to be opened. For information about registry security access values of type REGSAM, see
	/// the Microsoft Windows SDK documentation.
	/// </param>
	/// <param name="Flags">
	/// <para>The type of registry key to be opened, which is specified by one of the following:</para>
	/// <para>DIOCR_INSTALLER</para>
	/// <para>Open a setup class key. If ClassGuid is <c>NULL</c>, open the root key of the class installer branch.</para>
	/// <para>DIOCR_INTERFACE</para>
	/// <para>Open an interface class key. If ClassGuid is <c>NULL</c>, open the root key of the interface class branch.</para>
	/// </param>
	/// <param name="MachineName">
	/// Optionally points to a string that contains the name of a remote computer on which to open the specified key.
	/// </param>
	/// <param name="Reserved">Reserved. Must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>
	/// <c>SetupDiOpenClassRegKeyEx</c> returns a handle to an opened registry key where information about this setup class can be stored/retrieved.
	/// </para>
	/// <para>If the function fails, it returns INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on the value that is passed in the samDesired parameter, it might be necessary for the caller of this function to be a
	/// member of the Administrators group.
	/// </para>
	/// <para><c>SetupDiOpenClassRegKeyEx</c> does not create a registry key if it does not already exist.</para>
	/// <para>Callers of this function must close the handle returned from this function by calling RegCloseKey.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiopenclassregkeyexa WINSETUPAPI HKEY
	// SetupDiOpenClassRegKeyExA( const GUID *ClassGuid, REGSAM samDesired, DWORD Flags, PCSTR MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiOpenClassRegKeyExA")]
	public static extern SafeRegistryHandle SetupDiOpenClassRegKeyEx(in Guid ClassGuid, RegistryRights samDesired, DIOCR Flags,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? MachineName, [In, Optional] IntPtr Reserved);

	/// <summary>
	/// The <c>SetupDiOpenClassRegKeyEx</c> function opens the device setup class registry key, the device interface class registry key,
	/// or a specific class's subkey. This function opens the specified key on the local computer or on a remote computer.
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to the GUID of the class whose registry key is to be opened. This parameter is optional and can be <c>NULL</c>. If
	/// this parameter is <c>NULL</c>, the root of the class tree ( <c>HKLM\SYSTEM\CurrentControlSet\Control\Class</c>) is opened.
	/// </param>
	/// <param name="samDesired">
	/// The registry security access for the key to be opened. For information about registry security access values of type REGSAM, see
	/// the Microsoft Windows SDK documentation.
	/// </param>
	/// <param name="Flags">
	/// <para>The type of registry key to be opened, which is specified by one of the following:</para>
	/// <para>DIOCR_INSTALLER</para>
	/// <para>Open a setup class key. If ClassGuid is <c>NULL</c>, open the root key of the class installer branch.</para>
	/// <para>DIOCR_INTERFACE</para>
	/// <para>Open an interface class key. If ClassGuid is <c>NULL</c>, open the root key of the interface class branch.</para>
	/// </param>
	/// <param name="MachineName">
	/// Optionally points to a string that contains the name of a remote computer on which to open the specified key.
	/// </param>
	/// <param name="Reserved">Reserved. Must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>
	/// <c>SetupDiOpenClassRegKeyEx</c> returns a handle to an opened registry key where information about this setup class can be stored/retrieved.
	/// </para>
	/// <para>If the function fails, it returns INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on the value that is passed in the samDesired parameter, it might be necessary for the caller of this function to be a
	/// member of the Administrators group.
	/// </para>
	/// <para><c>SetupDiOpenClassRegKeyEx</c> does not create a registry key if it does not already exist.</para>
	/// <para>Callers of this function must close the handle returned from this function by calling RegCloseKey.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiopenclassregkeyexa WINSETUPAPI HKEY
	// SetupDiOpenClassRegKeyExA( const GUID *ClassGuid, REGSAM samDesired, DWORD Flags, PCSTR MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiOpenClassRegKeyExA")]
	public static extern SafeRegistryHandle SetupDiOpenClassRegKeyEx([In, Optional] IntPtr ClassGuid, RegistryRights samDesired, DIOCR Flags,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? MachineName, [In, Optional] IntPtr Reserved);

	/// <summary>
	/// The <c>SetupDiOpenDeviceInfo</c> function adds a device information element for a device instance to a device information set,
	/// if one does not already exist in the device information set, and retrieves information that identifies the device information
	/// element for the device instance in the device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set to which <c>SetupDiOpenDeviceInfo</c> adds a device information element, if one does not
	/// already exist, for the device instance that is specified by DeviceInstanceId.
	/// </param>
	/// <param name="DeviceInstanceId">
	/// A pointer to a NULL-terminated string that supplies the device instance identifier of a device (for example,
	/// "Root*PNP0500\0000"). If DeviceInstanceId is <c>NULL</c> or references a zero-length string, <c>SetupDiOpenDeviceInfo</c> adds a
	/// device information element to the supplied device information set, if one does not already exist, for the root device in the
	/// device tree.
	/// </param>
	/// <param name="hwndParent">The handle to the top-level window to use for any user interface related to installing the device.</param>
	/// <param name="OpenFlags">
	/// <para>
	/// A variable of DWORD type that controls how the device information element is opened. The value of this parameter can be one or
	/// more of the following:
	/// </para>
	/// <para>DIOD_CANCEL_REMOVE</para>
	/// <para>
	/// If this flag is specified and the device had been marked for pending removal, the operating system cancels the pending removal.
	/// </para>
	/// <para>DIOD_INHERIT_CLASSDRVS</para>
	/// <para>
	/// If this flag is specified, the resulting device information element inherits the class driver list, if any, associated with the
	/// device information set. In addition, if there is a selected driver for the device information set, that same driver is selected
	/// for the new device information element.
	/// </para>
	/// <para>If the device information element was already present, its class driver list, if any, is replaced with the inherited list.</para>
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to a caller-supplied SP_DEVINFO_DATA structure that receives information about the device information element for the
	/// device instance that is specified by DeviceInstanceId. The caller must set <c>cbSize</c> to <c>sizeof(</c> SP_DEVINFO_DATA
	/// <c>)</c>. This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <c>SetupDiOpenDeviceInfo</c> returns <c>TRUE</c> if it is successful. Otherwise, the function returns <c>FALSE</c> and the
	/// logged error can be retrieved with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If this device instance is being added to a set that has an associated class, the device class must be the same or the call will
	/// fail. In this case, a call to GetLastError returns ERROR_CLASS_MISMATCH.
	/// </para>
	/// <para>
	/// If the new device information element is successfully opened but the caller-supplied DeviceInfoData buffer is invalid, this
	/// function returns <c>FALSE</c>. In this case, a call to GetLastError returns ERROR_INVALID_USER_BUFFER. However, the device
	/// information element is added as a new member of the set anyway.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiopendeviceinfoa WINSETUPAPI BOOL
	// SetupDiOpenDeviceInfoA( HDEVINFO DeviceInfoSet, PCSTR DeviceInstanceId, HWND hwndParent, DWORD OpenFlags, PSP_DEVINFO_DATA
	// DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiOpenDeviceInfoA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiOpenDeviceInfo(HDEVINFO DeviceInfoSet, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? DeviceInstanceId,
		[In, Optional] HWND hwndParent, DIOD OpenFlags, ref SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiOpenDeviceInterface</c> function retrieves information about a device interface and adds the interface to the
	/// specified device information set for a local system or a remote system.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A pointer to a device information set that contains, or will contain, a device information element that represents the device
	/// that supports the interface to open.
	/// </param>
	/// <param name="DevicePath">
	/// A pointer to a NULL-terminated string that supplies the name of the device interface to be opened. This name is a Win32 device
	/// path that is typically received in a PnP notification structure or obtained by a previous call to SetupDiEnumDeviceInterfaces
	/// and its related functions.
	/// </param>
	/// <param name="OpenFlags">
	/// <para>Flags that determine how the device interface element is to be opened. The only valid flag is as follows:</para>
	/// <para>DIODI_NO_ADD</para>
	/// <para>
	/// Specifies that the device information element for the underlying device will not be created if that element is not already
	/// present in the specified device information set. For more information, see the following <c>Remarks</c> section.
	/// </para>
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to a caller-initialized SP_DEVICE_INTERFACE_DATA structure that receives the requested interface data. This pointer is
	/// optional and can be <c>NULL</c>. If a buffer is supplied, the caller must set the <c>cbSize</c> member of the structure to
	/// <c>sizeof(</c> SP_DEVICE_INTERFACE_DATA <c>)</c> before calling <c>SetupDiOpenDeviceInterface</c>. For more information, see the
	/// following <c>Remarks</c> section.
	/// </param>
	/// <returns>
	/// <c>SetupDiOpenDeviceInterface</c> returns <c>TRUE</c> if the function completed without error. If the function completed with an
	/// error, it returns <c>FALSE</c> and the error code for the failure can be retrieved by calling GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a device interface element for the interface already exists in DeviceInfoSet, <c>SetupDiOpenDeviceInterface</c> updates the
	/// flags. Therefore, this function can be used to update the flags for a device interface. For example, an interface might have
	/// been inactive when it was first opened, but has subsequently become active. If the device information element for the underlying
	/// device is not already present in DeviceInfoSet, this function creates one and adds it to DeviceInfoSet.
	/// </para>
	/// <para>
	/// If the function successfully opens the new device interface but the caller did not supply a valid structure in the
	/// DeviceInterfaceData parameter, the function will return <c>FALSE</c> and a subsequent call to GetLastError will return
	/// ERROR_INVALID_USER_BUFFER. However, in this situation, <c>SetupDiOpenDeviceInterface</c> does add the requested interface to the
	/// device information set.
	/// </para>
	/// <para>
	/// If the new device interface is successfully opened, but the caller-supplied DeviceInterfaceData buffer is invalid, this function
	/// returns <c>FALSE</c> and GetLastError returns ERROR_INVALID_USER_BUFFER. The caller's buffer error does not prevent the
	/// interface from being opened.
	/// </para>
	/// <para>
	/// If the DIODI_NO_ADD flag is specified for the OpenFlags parameter, and a device information element for the underlying device is
	/// not already present in the specified device information set, this function returns <c>FALSE</c> and GetLastError returns ERROR_NO_SUCH_DEVICE_INTERFACE.
	/// </para>
	/// <para>
	/// When the application has finished using the information that <c>SetupDiOpenDeviceInterface</c> retrieved <c>,</c> the
	/// application must call SetupDiDeleteDeviceInterfaceData.
	/// </para>
	/// <para>
	/// MF_DEVSOURCE_ATTRIBUTE_SOURCE_TYPE_VIDCAP_SYMBOLIC_LINKattribute can be passed in as the value of the DevicePath argument of the
	/// <c>SetupDiOpenDeviceInterface</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiopendeviceinterfacew WINSETUPAPI BOOL
	// SetupDiOpenDeviceInterfaceW( HDEVINFO DeviceInfoSet, PCWSTR DevicePath, DWORD OpenFlags, PSP_DEVICE_INTERFACE_DATA
	// DeviceInterfaceData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiOpenDeviceInterfaceW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiOpenDeviceInterface(HDEVINFO DeviceInfoSet, [MarshalAs(UnmanagedType.LPTStr)] string DevicePath,
		DIODI OpenFlags, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);

	/// <summary>
	/// The <c>SetupDiOpenDeviceInterfaceRegKey</c> function opens the registry subkey that is used by applications and drivers to store
	/// information that is specific to a device interface.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A pointer to a device information set that contains the device interface for which to open a registry subkey.
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to an SP_DEVICE_INTERFACE_DATA structure that specifies the device interface. This pointer can be returned by
	/// SetupDiCreateDeviceInterface or SetupDiEnumDeviceInterfaces.
	/// </param>
	/// <param name="Reserved">Reserved. Must be zero.</param>
	/// <param name="samDesired">
	/// The requested registry security access to the registry subkey. For information about registry security access values of type
	/// REGSAM, see the Microsoft Windows SDK documentation.
	/// </param>
	/// <returns>
	/// <c>SetupDiOpenDeviceInterfaceRegKey</c> returns a handle to the opened registry key. If the function fails, it returns
	/// INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on the value that is passed in the samDesired parameter, it might be necessary for the caller of this function to be a
	/// member of the Administrators group.
	/// </para>
	/// <para>Close the handle returned from by function by calling RegCloseKey.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiopendeviceinterfaceregkey WINSETUPAPI HKEY
	// SetupDiOpenDeviceInterfaceRegKey( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData, DWORD Reserved, REGSAM
	// samDesired );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiOpenDeviceInterfaceRegKey")]
	public static extern SafeRegistryHandle SetupDiOpenDeviceInterfaceRegKey(HDEVINFO DeviceInfoSet, in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
		[In, Optional] uint Reserved, RegistryRights samDesired);

	/// <summary>The <c>SetupDiOpenDevRegKey</c> function opens a registry key for device-specific configuration information.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set that contains a device information element that represents the device for which to open a
	/// registry key.
	/// </param>
	/// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
	/// <param name="Scope">
	/// <para>
	/// The scope of the registry key to open. The scope determines where the information is stored. The scope can be global or specific
	/// to a hardware profile. The scope is specified by one of the following values:
	/// </para>
	/// <para>DICS_FLAG_GLOBAL</para>
	/// <para>
	/// Open a key to store global configuration information. This information is not specific to a particular hardware profile. This
	/// opens a key that is rooted at <c>HKEY_LOCAL_MACHINE.</c> The exact key opened depends on the value of the KeyType parameter.
	/// </para>
	/// <para>DICS_FLAG_CONFIGSPECIFIC</para>
	/// <para>
	/// Open a key to store hardware profile-specific configuration information. This key is rooted at one of the hardware-profile
	/// specific branches, instead of <c>HKEY_LOCAL_MACHINE</c>. The exact key opened depends on the value of the KeyType parameter.
	/// </para>
	/// </param>
	/// <param name="HwProfile">
	/// <para>A hardware profile value, which is set as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If Scope is set to DICS_FLAG_CONFIGSPECIFIC, HwProfile specifies the hardware profile of the key that is to be opened.</term>
	/// </item>
	/// <item>
	/// <term>If HwProfile is 0, the key for the current hardware profile is opened.</term>
	/// </item>
	/// <item>
	/// <term>If Scope is DICS_FLAG_GLOBAL, HwProfile is ignored.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="KeyType">
	/// <para>The type of registry storage key to open, which can be one of the following values:</para>
	/// <para>DIREG_DEV</para>
	/// <para>Open a hardware key for the device.</para>
	/// <para>DIREG_DRV</para>
	/// <para>Open a software key for the device.</para>
	/// <para>For more information about a device's hardware and software keys, see Registry Trees and Keys for Devices and Drivers.</para>
	/// </param>
	/// <param name="samDesired">
	/// The registry security access that is required for the requested key. For information about registry security access values of
	/// type REGSAM, see the Microsoft Windows SDK documentation.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function is successful, it returns a handle to an opened registry key where private configuration data about this device
	/// instance can be stored/retrieved.
	/// </para>
	/// <para>If the function fails, it returns INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on the value that is passed in the samDesired parameter, it might be necessary for the caller of this function to be a
	/// member of the Administrators group.
	/// </para>
	/// <para>Close the handle returned from this function by calling RegCloseKey.</para>
	/// <para>
	/// The specified device instance must be registered before this function is called. However, be aware that the operating system
	/// automatically registers PnP device instances. For information about how to register non-PnP device instances, see SetupDiRegisterDeviceInfo.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiopendevregkey WINSETUPAPI HKEY
	// SetupDiOpenDevRegKey( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DWORD Scope, DWORD HwProfile, DWORD KeyType,
	// REGSAM samDesired );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiOpenDevRegKey")]
	public static extern SafeRegistryHandle SetupDiOpenDevRegKey(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
		DICS_FLAG Scope, uint HwProfile, DIREG KeyType, RegistryRights samDesired);

	/// <summary>Converts memory retrieved from a property call to a managed object of the correct type.</summary>
	/// <param name="mem">The allocated memory.</param>
	/// <param name="propType">The type of the property.</param>
	/// <param name="convType">The type to which to convert the result if ambiguous.</param>
	/// <returns>A managed object with the value from the memory.</returns>
	public static object? SetupDiPropertyToManagedObject(ISafeMemoryHandle mem, DEVPROPTYPE propType, Type? convType = null)
	{
		object? Value = null;
		switch (propType)
		{
			case DEVPROPTYPE.DEVPROP_TYPE_EMPTY:
			case DEVPROPTYPE.DEVPROP_TYPE_NULL:
				break;

			case DEVPROPTYPE.DEVPROP_TYPE_SECURITY_DESCRIPTOR:
				Value = new RawSecurityDescriptor(mem.GetBytes(0, mem.Size), 0);
				break;

			case DEVPROPTYPE.DEVPROP_TYPE_STRING_INDIRECT:
				Value = mem.ToString(-1, CharSet.Unicode);
				break;

			case DEVPROPTYPE.DEVPROP_TYPE_STRING_LIST:
				Value = mem.ToStringEnum(CharSet.Unicode).ToArray();
				break;

			default:
				(DEVPROPTYPE type, DEVPROPTYPE mod) spt = propType.Split();
				var type = convType ?? CorrespondingTypeAttribute.GetCorrespondingTypes(spt.type).FirstOrDefault();
				if (type is not null)
				{
					Value = spt.mod switch
					{
						0 => mem.DangerousGetHandle().Convert(mem.Size, type, CharSet.Unicode),
						DEVPROPTYPE.DEVPROP_TYPEMOD_ARRAY => mem.DangerousGetHandle().ToArray(type, mem.Size / Marshal.SizeOf(type), 0, mem.Size),
						_ => null
					};
				}
				Value ??= mem.GetBytes(0, mem.Size);
				break;
		}
		return Value;
	}

	/// <summary>The <c>SetupDiRegisterCoDeviceInstallers</c> function is the default handler for DIF_REGISTER_COINSTALLERS.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set that contains a device information element that represents the device for which to
	/// register co-installers. The device information set must not contain any remote elements.
	/// </param>
	/// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
	/// <returns>
	/// <c>SetupDiRegisterCoDeviceInstallers</c> returns <c>TRUE</c> if the function succeeds. If the function returns <c>FALSE</c>,
	/// call GetLastError for extended error information.
	/// </returns>
	/// <remarks>
	/// <para>The caller of <c>SetupDiRegisterCoDeviceInstallers</c> must be a member of the Administrators group.</para>
	/// <para>
	/// <c>Note</c> Only a class installer should call <c>SetupDiRegisterCoDeviceInstallers</c> and only in those situations where the
	/// class installer must perform co-installer registration operations after <c>SetupDiRegisterCoDeviceInstallers</c> completes the
	/// default co-installer registration operation. In such situations, the class installer must directly call
	/// <c>SetupDiRegisterCoDeviceInstallers</c> when the installer processes a DIF_REGISTER_COINSTALLERS request. For more information
	/// about calling the default handler, see Calling Default DIF Code Handlers.
	/// </para>
	/// <para>
	/// <c>SetupDiRegisterCoDeviceInstallers</c> reads the INF file for the device specified by DeviceInfoData and creates registry
	/// entries to register any device-specific co-installers listed in the INF file. Co-installers are listed in an INF
	/// DDInstall.CoInstallers section. This function also copies the files for the co-installers, unless the DI_NOFILECOPY flag is set.
	/// </para>
	/// <para>
	/// If there is no driver selected, or the device has an INF file for Windows 9x or Millennium Edition, this function does not
	/// register any co-installers.
	/// </para>
	/// <para>
	/// Registering a new device-specific co-installer invalidates the Device Installer's current list of co-installers. After a
	/// successful registration, the Device Installer updates its list of co-installers.
	/// </para>
	/// <para>This function only registers device-specific co-installers, not class co-installers.</para>
	/// <para>For more information about how to write and register device-specific co-installers, see Writing a Co-installer.</para>
	/// <para>The device information set specified by DeviceInfoSet must only contain elements on the local computer.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiregistercodeviceinstallers WINSETUPAPI BOOL
	// SetupDiRegisterCoDeviceInstallers( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiRegisterCoDeviceInstallers")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiRegisterCoDeviceInstallers(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>The <c>SetupDiRegisterDeviceInfo</c> function is the default handler for the DIF_REGISTERDEVICE request.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a device information element that represents the device to register. The
	/// device information set must not contain any remote elements.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This is an IN-OUT
	/// parameter because DeviceInfoData. <c>DevInst</c> might be updated with a new handle value upon return.
	/// </param>
	/// <param name="Flags">
	/// <para>A flag value that controls how the device is registered, which can be zero or the following value:</para>
	/// <para>SPRDI_FIND_DUPS</para>
	/// <para>
	/// Search for a previously-existing device instance that corresponds to the device that is represented by DeviceInfoData. If this
	/// flag is not specified, the device instance is registered regardless of whether a device instance already exists for it.
	/// </para>
	/// <para>If the caller supplies CompareProc, the caller must also set this flag.</para>
	/// </param>
	/// <param name="CompareProc">
	/// A pointer to a comparison callback function to use in duplicate detection. This parameter is optional and can be <c>NULL</c>. If
	/// this parameter is specified, the callback function is called for each device instance that is of the same class as the device
	/// instance that is being registered.
	/// <para>
	/// The compare function must return ERROR_DUPLICATE_FOUND if it finds that the two devices are duplicates. Otherwise, it should
	/// return NO_ERROR. If some other error is encountered, the callback function should return the appropriate ERROR_* code to
	/// indicate the failure.
	/// </para>
	/// <para>
	/// If CompareProc is not specified and duplication detection is requested, a default comparison behavior is used. The default is to
	/// compare the new device's detect signature with the detect signature of all other devices in the class. The detect signature is
	/// contained in the class-specific resource descriptor of the device's boot log configuration.
	/// </para>
	/// </param>
	/// <param name="CompareContext">
	/// A pointer to a caller-supplied context buffer that is passed into the callback function. This parameter is ignored if
	/// CompareProc is not specified.
	/// </param>
	/// <param name="DupDeviceInfoData">
	/// <para>
	/// A pointer to an SP_DEVINFO_DATA structure to receive information about a duplicate device instance, if any, discovered as a
	/// result of attempting to register this device. This parameter is optional and can be <c>NULL</c>. If this parameter is specified,
	/// the caller must set DupDeviceInfoData. <c>cbSize</c> to <c>sizeof</c>(SP_DEVINFO_DATA). This will be filled in if the function
	/// returns <c>FALSE</c>, and GetLastError returns ERROR_DUPLICATE_FOUND. This device information element is added as a member of
	/// the specified DeviceInfoSet, if not already a member. If DupDeviceInfoData is not specified, the duplicate is not added to the
	/// device information set.
	/// </para>
	/// <para>If you call this function when handling a DIF_REGISTERDEVICE request, the DupDeviceInfoData parameter must be <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiRegisterDeviceInfo</c> is primarily designed to register a non-PnP device with the Plug and Play (PnP) manager on a
	/// local computer. Although <c>SetupDiRegisterDeviceInfo</c> will not fail if the device information set is for a remote computer,
	/// the result is of limited use because the device information set cannot subsequently be used with DIF_Xxx installation requests
	/// or <c>SetupDi</c> Xxx functions that do not support operations on a remote computer. For example, calling
	/// <c>SetupDiCreateDevRegKey</c> to execute an INF section for a newly registered device on a remote computer will fail.
	/// </para>
	/// <para>
	/// <c>Note</c> Only a class installer should call <c>SetupDiRegisterDeviceInfo</c> and only in those situations where the class
	/// installer must perform device registration operations after <c>SetupDiRegisterDeviceInfo</c> completes the default device
	/// registration operation. In such situations, the class installer must directly call <c>SetupDiRegisterDeviceInfo</c> when the
	/// installer processes a DIF_REGISTERDEVICE request. For more information about calling the default handler, see Calling Default
	/// DIF Code Handlers.
	/// </para>
	/// <para>
	/// After registering a device information element, the caller should update any stored copies of the <c>DevInst</c> handle
	/// associated with this device. This is necessary because the handle value might have changed during registration. The caller does
	/// not have to retrieve the SP_DEVINFO_DATA structure again because the <c>DevInst</c> field of the structure is updated to reflect
	/// the current value of the handle.
	/// </para>
	/// <para>
	/// Do not directly call this function for PnP device instances. PnP device instances are automatically registered by the operating
	/// system. However, you must register non-PnP device instances in one of the following ways:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// If your installation application uses a DIF_DETECT request to successfully detect a device, it should also use a
	/// DIF_REGISTERDEVICE request to register the device instance. The request should be handled in the default manner. (By default,
	/// SetupDiCallClassInstaller first calls the class installer and class co-installers to do duplicate detection and register the
	/// device instance. If these installers do not register the device instance, <c>SetupDiCallClassInstaller</c> calls
	/// <c>SetupDiRegisterDeviceInfo</c> to do duplicate detection and register the device instance.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If your installation application creates a device instance (for example, by calling SetupDiCreateDeviceInfo) but does not do
	/// duplicate detection, your installation application should use a DIF_REGISTERDEVICE request to register the device instance. The
	/// request should be handled in the default manner as described earlier.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If your installation application creates a new device and does duplicate detection, your installation application should use a
	/// DIF_REGISTERDEVICE request but should prevent <c>SetupDiCallClassInstaller</c> from calling <c>SetupDiRegisterDeviceInfo</c>. To
	/// prevent <c>SetupDiCallClassInstaller</c> from calling <c>SetupDiRegisterDeviceInfo</c>, set the DI_NODI_DEFAULTACTION flag in
	/// the <c>Flags</c> member of the SP_DEVINSTALL_PARAMS structure for the device instance. The caller of
	/// <c>SetupDiRegisterDeviceInfo</c> must be a member of the Administrators group.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiregisterdeviceinfo WINSETUPAPI BOOL
	// SetupDiRegisterDeviceInfo( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DWORD Flags, PSP_DETSIG_CMPPROC CompareProc,
	// PVOID CompareContext, PSP_DEVINFO_DATA DupDeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiRegisterDeviceInfo")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiRegisterDeviceInfo(HDEVINFO DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData, SPRDI Flags,
		[In, Optional] PSP_DETSIG_CMPPROC? CompareProc, [In, Optional] IntPtr CompareContext, ref SP_DEVINFO_DATA DupDeviceInfoData);

	/// <summary>The <c>SetupDiRegisterDeviceInfo</c> function is the default handler for the DIF_REGISTERDEVICE request.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a device information element that represents the device to register. The
	/// device information set must not contain any remote elements.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This is an IN-OUT
	/// parameter because DeviceInfoData. <c>DevInst</c> might be updated with a new handle value upon return.
	/// </param>
	/// <param name="Flags">
	/// <para>A flag value that controls how the device is registered, which can be zero or the following value:</para>
	/// <para>SPRDI_FIND_DUPS</para>
	/// <para>
	/// Search for a previously-existing device instance that corresponds to the device that is represented by DeviceInfoData. If this
	/// flag is not specified, the device instance is registered regardless of whether a device instance already exists for it.
	/// </para>
	/// <para>If the caller supplies CompareProc, the caller must also set this flag.</para>
	/// </param>
	/// <param name="CompareProc">
	/// A pointer to a comparison callback function to use in duplicate detection. This parameter is optional and can be <c>NULL</c>. If
	/// this parameter is specified, the callback function is called for each device instance that is of the same class as the device
	/// instance that is being registered.
	/// <para>
	/// The compare function must return ERROR_DUPLICATE_FOUND if it finds that the two devices are duplicates. Otherwise, it should
	/// return NO_ERROR. If some other error is encountered, the callback function should return the appropriate ERROR_* code to
	/// indicate the failure.
	/// </para>
	/// <para>
	/// If CompareProc is not specified and duplication detection is requested, a default comparison behavior is used. The default is to
	/// compare the new device's detect signature with the detect signature of all other devices in the class. The detect signature is
	/// contained in the class-specific resource descriptor of the device's boot log configuration.
	/// </para>
	/// </param>
	/// <param name="CompareContext">
	/// A pointer to a caller-supplied context buffer that is passed into the callback function. This parameter is ignored if
	/// CompareProc is not specified.
	/// </param>
	/// <param name="DupDeviceInfoData">
	/// <para>
	/// A pointer to an SP_DEVINFO_DATA structure to receive information about a duplicate device instance, if any, discovered as a
	/// result of attempting to register this device. This parameter is optional and can be <c>NULL</c>. If this parameter is specified,
	/// the caller must set DupDeviceInfoData. <c>cbSize</c> to <c>sizeof</c>(SP_DEVINFO_DATA). This will be filled in if the function
	/// returns <c>FALSE</c>, and GetLastError returns ERROR_DUPLICATE_FOUND. This device information element is added as a member of
	/// the specified DeviceInfoSet, if not already a member. If DupDeviceInfoData is not specified, the duplicate is not added to the
	/// device information set.
	/// </para>
	/// <para>If you call this function when handling a DIF_REGISTERDEVICE request, the DupDeviceInfoData parameter must be <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiRegisterDeviceInfo</c> is primarily designed to register a non-PnP device with the Plug and Play (PnP) manager on a
	/// local computer. Although <c>SetupDiRegisterDeviceInfo</c> will not fail if the device information set is for a remote computer,
	/// the result is of limited use because the device information set cannot subsequently be used with DIF_Xxx installation requests
	/// or <c>SetupDi</c> Xxx functions that do not support operations on a remote computer. For example, calling
	/// <c>SetupDiCreateDevRegKey</c> to execute an INF section for a newly registered device on a remote computer will fail.
	/// </para>
	/// <para>
	/// <c>Note</c> Only a class installer should call <c>SetupDiRegisterDeviceInfo</c> and only in those situations where the class
	/// installer must perform device registration operations after <c>SetupDiRegisterDeviceInfo</c> completes the default device
	/// registration operation. In such situations, the class installer must directly call <c>SetupDiRegisterDeviceInfo</c> when the
	/// installer processes a DIF_REGISTERDEVICE request. For more information about calling the default handler, see Calling Default
	/// DIF Code Handlers.
	/// </para>
	/// <para>
	/// After registering a device information element, the caller should update any stored copies of the <c>DevInst</c> handle
	/// associated with this device. This is necessary because the handle value might have changed during registration. The caller does
	/// not have to retrieve the SP_DEVINFO_DATA structure again because the <c>DevInst</c> field of the structure is updated to reflect
	/// the current value of the handle.
	/// </para>
	/// <para>
	/// Do not directly call this function for PnP device instances. PnP device instances are automatically registered by the operating
	/// system. However, you must register non-PnP device instances in one of the following ways:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// If your installation application uses a DIF_DETECT request to successfully detect a device, it should also use a
	/// DIF_REGISTERDEVICE request to register the device instance. The request should be handled in the default manner. (By default,
	/// SetupDiCallClassInstaller first calls the class installer and class co-installers to do duplicate detection and register the
	/// device instance. If these installers do not register the device instance, <c>SetupDiCallClassInstaller</c> calls
	/// <c>SetupDiRegisterDeviceInfo</c> to do duplicate detection and register the device instance.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If your installation application creates a device instance (for example, by calling SetupDiCreateDeviceInfo) but does not do
	/// duplicate detection, your installation application should use a DIF_REGISTERDEVICE request to register the device instance. The
	/// request should be handled in the default manner as described earlier.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If your installation application creates a new device and does duplicate detection, your installation application should use a
	/// DIF_REGISTERDEVICE request but should prevent <c>SetupDiCallClassInstaller</c> from calling <c>SetupDiRegisterDeviceInfo</c>. To
	/// prevent <c>SetupDiCallClassInstaller</c> from calling <c>SetupDiRegisterDeviceInfo</c>, set the DI_NODI_DEFAULTACTION flag in
	/// the <c>Flags</c> member of the SP_DEVINSTALL_PARAMS structure for the device instance. The caller of
	/// <c>SetupDiRegisterDeviceInfo</c> must be a member of the Administrators group.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiregisterdeviceinfo WINSETUPAPI BOOL
	// SetupDiRegisterDeviceInfo( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DWORD Flags, PSP_DETSIG_CMPPROC CompareProc,
	// PVOID CompareContext, PSP_DEVINFO_DATA DupDeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiRegisterDeviceInfo")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiRegisterDeviceInfo(HDEVINFO DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData, SPRDI Flags,
		[In, Optional] PSP_DETSIG_CMPPROC? CompareProc, [In, Optional] IntPtr CompareContext, [In, Optional] IntPtr DupDeviceInfoData);

	/// <summary>The <c>SetupDiRemoveDevice</c> function is the default handler for the DIF_REMOVE installation request.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set for the local system that contains a device information element that represents the device
	/// to remove.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This is an IN-OUT
	/// parameter because DeviceInfoSet. <c>DevInst</c> might be updated with a new handle value upon return. If this is a global
	/// removal or the last hardware profile-specific removal, all traces of the device instance are deleted from the registry and the
	/// handle will be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to <c>GetLastError</c>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiRemoveDevice</c> removes the device from the system. It deletes the device's hardware and software registry keys and
	/// any hardware-profile-specific registry keys (configuration-specific registry keys). This function dynamically stops the device
	/// if its <c>DevInst</c> is active and this is a global removal or the last configuration-specific removal. If the device cannot be
	/// dynamically stopped, flags are set in the Install Parameter block of the device information set that eventually cause the user
	/// to be prompted to restart the computer.
	/// </para>
	/// <para>
	/// Device removal is either global to all hardware profiles or specific to one hardware profile as specified by the <c>Scope</c>
	/// member of the SP_REMOVEDEVICE_PARAMS structure that supplies the class installation parameters for the DIF_REMOVE request.
	/// Configuration-specific removal is only appropriate for root-enumerated devices and should only be requested by system code.
	/// </para>
	/// <para>The caller of <c>SetupDiRemoveDevice</c> must be a member of the Administrators group.</para>
	/// <para>
	/// <c>Note</c> Only a class installer should call <c>SetupDiRemoveDevice</c> and only in those situations where the class installer
	/// must perform device removal operations after <c>SetupDiRemoveDevice</c> completes the default device removal operation. In such
	/// situations, the class installer must directly call <c>SetupDiRemoveDevice</c> when the installer processes a DIF_REMOVE request.
	/// For more information about calling the default handler, see Calling Default DIF Code Handlers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiremovedevice WINSETUPAPI BOOL SetupDiRemoveDevice(
	// HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiRemoveDevice")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiRemoveDevice(HDEVINFO DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>The <c>SetupDiRemoveDeviceInterface</c> function removes a registered device interface from the system.</summary>
	/// <param name="DeviceInfoSet">
	/// A pointer to the device information set that contains the device interface to remove. This handle is typically returned by <c>SetupDiGetClassDevs</c>.
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// <para>
	/// A pointer to an SP_DEVICE_INTERFACE_DATA structure that specifies the device interface in DeviceInfoSet to remove. This pointer
	/// is typically returned by SetupDiEnumDeviceInterfaces.
	/// </para>
	/// <para>
	/// After the interface is removed, this function sets the SPINT_REMOVED flag in DeviceInterfaceData <c>.Flags</c>. It also clears
	/// the SPINT_ACTIVE flag, but be aware that this flag should have already been cleared before this function was called.
	/// </para>
	/// </param>
	/// <returns>
	/// <c>SetupDiRemoveDeviceInterface</c> returns <c>TRUE</c> if the function completed without error. If the function completed with
	/// an error, it returns <c>FALSE</c> and the error code for the failure can be retrieved by calling GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must be a member of the Administrators group.</para>
	/// <para>
	/// <c>SetupDiRemoveDeviceInterface</c> removes the specified device interface from the system. This includes deleting the
	/// associated registry key.
	/// </para>
	/// <para>Call SetupDiDeleteDeviceInterfaceData to delete the interface from a device information list.</para>
	/// <para>
	/// A device interface must be disabled to be removed. If the interface is enabled, this function fails and GetLastError returns
	/// ERROR_DEVICE_INTERFACE_ACTIVE. Disable an interface by using whatever interface-specific mechanism is provided (for example, an
	/// IOCTL). If the caller has no way to disable an interface and the interface must be removed, the caller must stop the underlying
	/// device by using SetupDiChangeState. Stopping the device disables all the interfaces exposed by the device.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiremovedeviceinterface WINSETUPAPI BOOL
	// SetupDiRemoveDeviceInterface( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiRemoveDeviceInterface")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiRemoveDeviceInterface(HDEVINFO DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);

	/// <summary>
	/// The <c>SetupDiRestartDevices</c> function restarts a specified device or, if necessary, restarts all devices that are operated
	/// by the same function and filter drivers that operate the specified device.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains the device information element that represents the device to restart.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure for the device information member that represents the device to restart. This
	/// parameter is also an output parameter because <c>SetupDiRestartDevices</c> updates the device installation parameters for this
	/// device information member and the status and problem code of the corresponding device instance. For more information about these
	/// updates, see the following <c>Remarks</c> section.
	/// </param>
	/// <returns>
	/// If the operation succeeds, <c>SetupDiRestartDevices</c> returns <c>TRUE</c>; otherwise, the function returns <c>FALSE</c> and
	/// the logged error can be retrieved by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiRestartDevices</c> should be called only by a class installer when a class installer is handling a DIF_INSTALLDEVICE
	/// request and only in rare situations where the class installer must perform operations after all default installation operations,
	/// except for starting a device, have completed . For more information about calling <c>SetupDiRestartDevices</c> in these
	/// situations, see DIF_INSTALLDEVICE.
	/// </para>
	/// <para>
	/// <c>SetupDiRestartDevices</c> restarts only the specified device if the restart can be performed without affecting the
	/// installation of other devices that are operated by the same function driver or filter drivers that operate the device.
	/// Specifically, if the restart of the specified device does not copy new files or modify any files that were previously installed
	/// for the device, <c>SetupDiRestartDevices</c> restarts only the specified device. Otherwise, the function restarts all devices
	/// that are operated by the same function and filter drivers that operate the specified device.
	/// </para>
	/// <para>
	/// <c>SetupDiRestartDevices</c> updates the device installation parameters and device status to reflect the result of the attempted
	/// restart operation. For example:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>If the device is started, <c>SetupDiRestartDevices</c> sets the device status to DN_STARTED.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If a system restart is necessary to start a device, <c>SetupDiRestartDevices</c> sets the DI_NEEDREBOOT flag in the <c>Flags</c>
	/// member of the SP_DEVINSTALL_PARAMETER structure that is associated with the device information element and sets the problem code
	/// for the device to CM_PROB_NEED_RESTART.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The CM_Get_DevNode_Status function retrieves the status and problem code for a device instance and the
	/// SetupDiGetDeviceInstallParams function retrieves the device installation parameters for the device information element that
	/// represents the device instance.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdirestartdevices WINSETUPAPI BOOL
	// SetupDiRestartDevices( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiRestartDevices")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiRestartDevices(HDEVINFO DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiSelectBestCompatDrv</c> function is the default handler for the DIF_SELECTBESTCOMPATDRV installation request.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a device information element that represents the device for which to select
	/// the best compatible driver.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.
	/// <c>SetupDiSelectBestCompatDrv</c> selects the best driver for a device information element from the compatible driver list for
	/// the specified device.
	/// </param>
	/// <returns>
	/// If the operation succeeds, <c>SetupDiSelectBestCompatDrv</c> returns <c>TRUE</c>. Otherwise, the function returns <c>FALSE</c>
	/// and the logged error can be retrieved by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the caller of <c>SetupDiSelectBestCompatDrv</c> is a member of the Administrators group and the class of the device is
	/// different that the class of the selected driver, <c>SetupDiSelectBestCompatDrv</c> sets the class of the device to the class of
	/// the driver. If this behavior is not desired, call this function at a lower privilege level.
	/// </para>
	/// <para>
	/// <c>Note</c> Only a class installer should call <c>SetupDiSelectBestCompatDrv</c> and only in those situations where the class
	/// installer must perform driver selection operations after <c>SetupDiSelectBestCompatDrv</c> completes the default driver
	/// selection operation. In such situations, the class installer must directly call <c>SetupDiSelectBestCompatDrv</c> when the
	/// installer processes a DIF_SELECTBESTCOMPATDRV request. For more information about calling the default handler, see Calling
	/// Default DIF Code Handlers.
	/// </para>
	/// <para>
	/// <c>SetupDiSelectBestCompatDrv</c> is primarily designed to select the best compatible driver for a device information element on
	/// a local computer. Although <c>SetupDiSelectBestCompatDrv</c> will not fail if the device information set is for a remote
	/// computer, the result is of limited use because the device information set cannot subsequently be used as input with DIF_Xxx
	/// installation requests or <c>SetupDi</c> Xxx functions that do not support operations for a remote computer. In particular, the
	/// device information set cannot subsequently be used as input with a DIF_INSTALLDEVICE installation request to install a device on
	/// a remote computer.
	/// </para>
	/// <para>For information about how the best driver is selected, see How Windows Selects Drivers.</para>
	/// <para>To get the selected driver for a device, call SetupDiGetSelectedDriver.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiselectbestcompatdrv WINSETUPAPI BOOL
	// SetupDiSelectBestCompatDrv( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSelectBestCompatDrv")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSelectBestCompatDrv(HDEVINFO DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiSelectBestCompatDrv</c> function is the default handler for the DIF_SELECTBESTCOMPATDRV installation request.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a device information element that represents the device for which to select
	/// the best compatible driver.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.
	/// <c>SetupDiSelectBestCompatDrv</c> selects the best driver for a device information element from the compatible driver list for
	/// the specified device.
	/// </param>
	/// <returns>
	/// If the operation succeeds, <c>SetupDiSelectBestCompatDrv</c> returns <c>TRUE</c>. Otherwise, the function returns <c>FALSE</c>
	/// and the logged error can be retrieved by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the caller of <c>SetupDiSelectBestCompatDrv</c> is a member of the Administrators group and the class of the device is
	/// different that the class of the selected driver, <c>SetupDiSelectBestCompatDrv</c> sets the class of the device to the class of
	/// the driver. If this behavior is not desired, call this function at a lower privilege level.
	/// </para>
	/// <para>
	/// <c>Note</c> Only a class installer should call <c>SetupDiSelectBestCompatDrv</c> and only in those situations where the class
	/// installer must perform driver selection operations after <c>SetupDiSelectBestCompatDrv</c> completes the default driver
	/// selection operation. In such situations, the class installer must directly call <c>SetupDiSelectBestCompatDrv</c> when the
	/// installer processes a DIF_SELECTBESTCOMPATDRV request. For more information about calling the default handler, see Calling
	/// Default DIF Code Handlers.
	/// </para>
	/// <para>
	/// <c>SetupDiSelectBestCompatDrv</c> is primarily designed to select the best compatible driver for a device information element on
	/// a local computer. Although <c>SetupDiSelectBestCompatDrv</c> will not fail if the device information set is for a remote
	/// computer, the result is of limited use because the device information set cannot subsequently be used as input with DIF_Xxx
	/// installation requests or <c>SetupDi</c> Xxx functions that do not support operations for a remote computer. In particular, the
	/// device information set cannot subsequently be used as input with a DIF_INSTALLDEVICE installation request to install a device on
	/// a remote computer.
	/// </para>
	/// <para>For information about how the best driver is selected, see How Windows Selects Drivers.</para>
	/// <para>To get the selected driver for a device, call SetupDiGetSelectedDriver.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiselectbestcompatdrv WINSETUPAPI BOOL
	// SetupDiSelectBestCompatDrv( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSelectBestCompatDrv")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSelectBestCompatDrv(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData);

	/// <summary>The <c>SetupDiSelectDevice</c> function is the default handler for the DIF_SELECTDEVICE request.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a device information element that represents the device for which to select a driver.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element. This parameter is optional and can be
	/// <c>NULL</c>. If this parameter is specified, <c>SetupDiSelectDevice</c> selects the driver for the specified device and sets
	/// DeviceInfoData. <c>ClassGuid</c> to the GUID of the device setup class for the selected driver. If this parameter is
	/// <c>NULL</c>, <c>SetupDiSelectDevice</c> sets the selected driver in the global class driver list for DeviceInfoSet.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiSelectDevice</c> handles the user interface that allows the user to select a driver for the specified device, or a
	/// device information set if a device is not specified. By setting the <c>Flags</c> field of the SP_DEVINSTALL_PARAMS structure for
	/// the device, or the device information set if a device is not specified, the caller can specify special handling of the user
	/// interface, for example, to allow users to select a driver from an OEM installation disk.
	/// </para>
	/// <para>
	/// <c>Note</c> Only a class installer should call <c>SetupDiSelectDevice</c> and only in those situations where the class installer
	/// must perform driver selection operations after <c>SetupDiSelectDevice</c> completes the default driver selection operation. In
	/// such situations, the class installer must directly call <c>SetupDiSelectDevice</c> when the installer processes a
	/// DIF_SELECTDEVICE request. For more information about calling the default handler, see Calling Default DIF Code Handlers.
	/// </para>
	/// <para>
	/// <c>SetupDiSelectDevice</c> is primarily designed to select a driver for a device on a local computer before installing the
	/// device. Although <c>SetupDiSelectDevice</c> will not fail if the device information set is for a remote computer, the result is
	/// of limited use because the device information set cannot subsequently be used with DIF_Xxx installation requests or
	/// <c>SetupDi</c> Xxx functions that do not support operations on a remote computer. In particular, the device information set
	/// cannot be used as input with a DIF_INSTALLDEVICE installation request to install a device on a remote computer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiselectdevice WINSETUPAPI BOOL SetupDiSelectDevice(
	// HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSelectDevice")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSelectDevice(HDEVINFO DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>The <c>SetupDiSelectDevice</c> function is the default handler for the DIF_SELECTDEVICE request.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a device information element that represents the device for which to select a driver.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element. This parameter is optional and can be
	/// <c>NULL</c>. If this parameter is specified, <c>SetupDiSelectDevice</c> selects the driver for the specified device and sets
	/// DeviceInfoData. <c>ClassGuid</c> to the GUID of the device setup class for the selected driver. If this parameter is
	/// <c>NULL</c>, <c>SetupDiSelectDevice</c> sets the selected driver in the global class driver list for DeviceInfoSet.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiSelectDevice</c> handles the user interface that allows the user to select a driver for the specified device, or a
	/// device information set if a device is not specified. By setting the <c>Flags</c> field of the SP_DEVINSTALL_PARAMS structure for
	/// the device, or the device information set if a device is not specified, the caller can specify special handling of the user
	/// interface, for example, to allow users to select a driver from an OEM installation disk.
	/// </para>
	/// <para>
	/// <c>Note</c> Only a class installer should call <c>SetupDiSelectDevice</c> and only in those situations where the class installer
	/// must perform driver selection operations after <c>SetupDiSelectDevice</c> completes the default driver selection operation. In
	/// such situations, the class installer must directly call <c>SetupDiSelectDevice</c> when the installer processes a
	/// DIF_SELECTDEVICE request. For more information about calling the default handler, see Calling Default DIF Code Handlers.
	/// </para>
	/// <para>
	/// <c>SetupDiSelectDevice</c> is primarily designed to select a driver for a device on a local computer before installing the
	/// device. Although <c>SetupDiSelectDevice</c> will not fail if the device information set is for a remote computer, the result is
	/// of limited use because the device information set cannot subsequently be used with DIF_Xxx installation requests or
	/// <c>SetupDi</c> Xxx functions that do not support operations on a remote computer. In particular, the device information set
	/// cannot be used as input with a DIF_INSTALLDEVICE installation request to install a device on a remote computer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiselectdevice WINSETUPAPI BOOL SetupDiSelectDevice(
	// HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSelectDevice")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSelectDevice(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiSelectOEMDrv</c> function selects a driver for a device information set or a particular device information element
	/// that uses an OEM path supplied by the user.
	/// </summary>
	/// <param name="hwndParent">
	/// A window handle that will be the parent of any dialogs created during the processing of this function. This parameter can be
	/// used to override the <c>hwndParent</c> field in the installation parameters block of the specified device information set or element.
	/// </param>
	/// <param name="DeviceInfoSet">A handle to the device information set for which to select a driver.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element in DeviceInfoSet. This parameter is
	/// optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiSelectOEMDrv</c> associates the selected driver with
	/// the specified device. If this parameter is <c>NULL</c>, <c>SetupDiSelectOEMDrv</c> associates the selected driver with the
	/// global class driver list for DeviceInfoSet.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiSelectOEMDrv</c> is primarily designed to select an OEM driver for a device on a local computer before installing the
	/// device on that computer. Although <c>SetupDiSelectOEMDrv</c> will not fail if the device information set is for a remote
	/// computer, the result is of limited use because the device information set cannot subsequently be used with DIF_Xxx installation
	/// requests or <c>SetupDi</c> Xxx functions that do not support operations on a remote computer. In particular, the device
	/// information set cannot be used as input with a DIF_INSTALLDEVICE installation request to install a device on a remote computer.
	/// </para>
	/// <para>
	/// <c>SetupDiSelectOEMDrv</c> prompts the user for the OEM path and then calls the class installer to select a driver from the OEM path.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiselectoemdrv WINSETUPAPI BOOL SetupDiSelectOEMDrv(
	// HWND hwndParent, HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSelectOEMDrv")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSelectOEMDrv([In, Optional] HWND hwndParent, HDEVINFO DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiSelectOEMDrv</c> function selects a driver for a device information set or a particular device information element
	/// that uses an OEM path supplied by the user.
	/// </summary>
	/// <param name="hwndParent">
	/// A window handle that will be the parent of any dialogs created during the processing of this function. This parameter can be
	/// used to override the <c>hwndParent</c> field in the installation parameters block of the specified device information set or element.
	/// </param>
	/// <param name="DeviceInfoSet">A handle to the device information set for which to select a driver.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element in DeviceInfoSet. This parameter is
	/// optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiSelectOEMDrv</c> associates the selected driver with
	/// the specified device. If this parameter is <c>NULL</c>, <c>SetupDiSelectOEMDrv</c> associates the selected driver with the
	/// global class driver list for DeviceInfoSet.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiSelectOEMDrv</c> is primarily designed to select an OEM driver for a device on a local computer before installing the
	/// device on that computer. Although <c>SetupDiSelectOEMDrv</c> will not fail if the device information set is for a remote
	/// computer, the result is of limited use because the device information set cannot subsequently be used with DIF_Xxx installation
	/// requests or <c>SetupDi</c> Xxx functions that do not support operations on a remote computer. In particular, the device
	/// information set cannot be used as input with a DIF_INSTALLDEVICE installation request to install a device on a remote computer.
	/// </para>
	/// <para>
	/// <c>SetupDiSelectOEMDrv</c> prompts the user for the OEM path and then calls the class installer to select a driver from the OEM path.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiselectoemdrv WINSETUPAPI BOOL SetupDiSelectOEMDrv(
	// HWND hwndParent, HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSelectOEMDrv")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSelectOEMDrv([In, Optional] HWND hwndParent, HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiSetClassInstallParams</c> function sets or clears class install parameters for a device information set or a
	/// particular device information element.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to the device information set for which to set class install parameters.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that represents the device for which to set class install parameters. This parameter
	/// is optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiSetClassInstallParams</c> sets the class
	/// installation parameters for the specified device. If this parameter is <c>NULL</c>, <c>SetupDiSetClassInstallParams</c> sets the
	/// class install parameters that are associated with DeviceInfoSet.
	/// </param>
	/// <param name="ClassInstallParams">
	/// <para>
	/// A pointer to a buffer that contains the new class install parameters to use. The SP_CLASSINSTALL_HEADER structure at the
	/// beginning of this buffer must have its <c>cbSize</c> field set to <c>sizeof(</c> SP_CLASSINSTALL_HEADER <c>)</c> and the
	/// <c>InstallFunction</c> field must be set to the DI_FUNCTION code that reflects the type of parameters contained in the rest of
	/// the buffer.
	/// </para>
	/// <para>
	/// If ClassInstallParams is not specified, the current class install parameters, if any, are cleared for the specified device
	/// information set or element.
	/// </para>
	/// </param>
	/// <param name="ClassInstallParamsSize">
	/// The size, in bytes, of the ClassInstallParams buffer. If the buffer is not supplied (that is, the class install parameters are
	/// being cleared), ClassInstallParamsSize must be 0.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// All parameters are validated before any changes are made. Therefore, a return value of <c>FALSE</c> indicates that no parameters
	/// were modified.
	/// </para>
	/// <para>
	/// A side effect of setting class install parameters is that the DI_CLASSINSTALLPARAMS flag is set. If the caller wants to set the
	/// parameters, but disable their use, this flag must be cleared by a call to <c>SetupDiSetDeviceInstallParams</c>.
	/// </para>
	/// <para>If the class install parameters are cleared, the DI_CLASSINSTALLPARAMS flag is reset.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetclassinstallparamsa WINSETUPAPI BOOL
	// SetupDiSetClassInstallParamsA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_CLASSINSTALL_HEADER
	// ClassInstallParams, DWORD ClassInstallParamsSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetClassInstallParamsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetClassInstallParams(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
		[In, Optional] IntPtr ClassInstallParams, uint ClassInstallParamsSize);

	/// <summary>
	/// The <c>SetupDiSetClassInstallParams</c> function sets or clears class install parameters for a device information set or a
	/// particular device information element.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to the device information set for which to set class install parameters.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that represents the device for which to set class install parameters. This parameter
	/// is optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiSetClassInstallParams</c> sets the class
	/// installation parameters for the specified device. If this parameter is <c>NULL</c>, <c>SetupDiSetClassInstallParams</c> sets the
	/// class install parameters that are associated with DeviceInfoSet.
	/// </param>
	/// <param name="ClassInstallParams">
	/// <para>
	/// A pointer to a buffer that contains the new class install parameters to use. The SP_CLASSINSTALL_HEADER structure at the
	/// beginning of this buffer must have its <c>cbSize</c> field set to <c>sizeof(</c> SP_CLASSINSTALL_HEADER <c>)</c> and the
	/// <c>InstallFunction</c> field must be set to the DI_FUNCTION code that reflects the type of parameters contained in the rest of
	/// the buffer.
	/// </para>
	/// <para>
	/// If ClassInstallParams is not specified, the current class install parameters, if any, are cleared for the specified device
	/// information set or element.
	/// </para>
	/// </param>
	/// <param name="ClassInstallParamsSize">
	/// The size, in bytes, of the ClassInstallParams buffer. If the buffer is not supplied (that is, the class install parameters are
	/// being cleared), ClassInstallParamsSize must be 0.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// All parameters are validated before any changes are made. Therefore, a return value of <c>FALSE</c> indicates that no parameters
	/// were modified.
	/// </para>
	/// <para>
	/// A side effect of setting class install parameters is that the DI_CLASSINSTALLPARAMS flag is set. If the caller wants to set the
	/// parameters, but disable their use, this flag must be cleared by a call to <c>SetupDiSetDeviceInstallParams</c>.
	/// </para>
	/// <para>If the class install parameters are cleared, the DI_CLASSINSTALLPARAMS flag is reset.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetclassinstallparamsa WINSETUPAPI BOOL
	// SetupDiSetClassInstallParamsA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_CLASSINSTALL_HEADER
	// ClassInstallParams, DWORD ClassInstallParamsSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetClassInstallParamsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetClassInstallParams(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData,
		[In, Optional] IntPtr ClassInstallParams, uint ClassInstallParamsSize);

	/// <summary>
	/// The <c>SetupDiSetClassProperty</c> function sets a class property for a device setup class or a device interface class.
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to a GUID that identifies the device setup class or device interface class for which to set a device property. For
	/// information about how to specify the class type, see the Flags parameter.
	/// </param>
	/// <param name="PropertyKey">
	/// A pointer to a DEVPROPKEY structure that represents the device property key of the device class property to set.
	/// </param>
	/// <param name="PropertyType">
	/// A DEVPROPTYPE-typed value that represents the property-data-type identifier for the device class property. For more information
	/// about the property-data-type identifier, see the <c>Remarks</c> section later in this topic.
	/// </param>
	/// <param name="PropertyBuffer">
	/// A pointer to a buffer that contains the property value of the device class. If either the property or the data is being deleted,
	/// this pointer must be set to <c>NULL</c>, and PropertyBufferSize must be set to zero. For more information about property data,
	/// see the <c>Remarks</c> section later in this topic.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to <c>NULL</c>, PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="Flags">
	/// <para>One of the following values, which specifies whether the class is a device setup class or a device interface class:</para>
	/// <para>DICLASSPROP_INSTALLER</para>
	/// <para>ClassGuid specifies a device setup class. This flag cannot be used with DICLASSPROP_INTERFACE.</para>
	/// <para>DICLASSPROP_INTERFACE</para>
	/// <para>ClassGuid specifies a device interface class. This flag cannot be used with DICLASSPROP_INSTALLER.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// <c>SetupDiSetClassProperty</c> returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c>, and the logged error
	/// can be retrieved by calling GetLastError.
	/// </para>
	/// <para>The following table includes some of the more common error codes that this function might log.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value of Flags is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_CLASS</term>
	/// <term>
	/// The device setup class that is specified by ClassGuid is not valid. This error can occur only if the DICLASSPROP_INSTALLER flag
	/// is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_REFERENCE_STRING</term>
	/// <term>The device interface reference string is not valid. This error can occur only if the DICLASSPROP_INTERFACE flag is specified.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_REG_PROPERTY</term>
	/// <term>The property key that is supplied by PropertyKey is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>
	/// An unspecified internal data value was not valid. This error could be logged if the ClassGuid value is not a valid GUID or the
	/// property value is not consistent with the property type specified by PropertyType.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_USER_BUFFER</term>
	/// <term>A user buffer is not valid. One possibility is that PropertyBuffer is NULL, and PropertyBufferSize is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_INTERFACE_CLASS</term>
	/// <term>
	/// The device interface class that is specified by ClassGuid does not exist. This error can occur only if the DICLASSPROP_INTERFACE
	/// flag is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>An internal data buffer that was passed to a system call was too small.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There was not enough system memory available to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>An unspecified item was not found. One possibility is that the property to be deleted does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have Administrator privileges.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>SetupDiSetClassProperty</c> is part of the unified device property model.</para>
	/// <para>SetupAPI supports only a Unicode version of <c>SetupDiSetClassProperty</c>.</para>
	/// <para>A caller of <c>SetupDiSetClassProperty</c> must be a member of the Administrators group to set a device interface property.</para>
	/// <para><c>SetupDiSetClassProperty</c> enforces requirements on the property-data-type identifier and the property value.</para>
	/// <para>
	/// To obtain the device property keys that represent the device properties that are set for a device class on a local computer,
	/// call SetupDiGetClassPropertyKeys.
	/// </para>
	/// <para>
	/// To retrieve a device class property on a local computer, call SetupDiGetClassProperty, and to retrieve a device class property
	/// on a remote computer, call SetupDiGetClassPropertyEx.
	/// </para>
	/// <para>To set a device class property on a remote computer, call SetupDiSetClassPropertyEx.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetclasspropertyw WINSETUPAPI BOOL
	// SetupDiSetClassPropertyW( const GUID *ClassGuid, const DEVPROPKEY *PropertyKey, DEVPROPTYPE PropertyType, const PBYTE
	// PropertyBuffer, DWORD PropertyBufferSize, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Unicode)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetClassPropertyW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetClassProperty(in Guid ClassGuid, in DEVPROPKEY PropertyKey, DEVPROPTYPE PropertyType,
		[In, Optional] IntPtr PropertyBuffer, [In, Optional] uint PropertyBufferSize, DICLASSPROP Flags);

	/// <summary>
	/// The <c>SetupDiSetClassPropertyEx</c> function sets a device property for a device setup class or a device interface class on a
	/// local or remote computer.
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to a GUID that identifies the device setup class or device interface class for which to set a device property. For
	/// information about how to specify the class type, see the Flags parameter.
	/// </param>
	/// <param name="PropertyKey">
	/// A pointer to a DEVPROPKEY structure that represents the device property key of the device class property to set.
	/// </param>
	/// <param name="PropertyType">
	/// A DEVPROPTYPE-typed value that represents the property-data-type identifier for the class property. For more information about
	/// the property-data-type identifier, see the <c>Remarks</c> section later in this topic.
	/// </param>
	/// <param name="PropertyBuffer">
	/// A pointer to a buffer that contains the class property value. If either the property or the property value is being deleted,
	/// this pointer must be set to <c>NULL</c>, and PropertyBufferSize must be set to zero. For more information about property value
	/// requirements, see the <c>Remarks</c> section later in this topic.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. The property buffer size must be consistent with the property-data-type
	/// identifier that is supplied by PropertyType. If PropertyBuffer is set to <c>NULL</c>, PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="Flags">
	/// <para>One of the following values, which specifies whether the class is a device setup class or a device interface class:</para>
	/// <para>DICLASSPROP_INSTALLER</para>
	/// <para>ClassGuid specifies a device setup class. This flag cannot be used with DICLASSPROP_INTERFACE.</para>
	/// <para>DICLASSPROP_INTERFACE</para>
	/// <para>ClassGuid specifies a device interface class. This flag cannot be used with DICLASSPROP_INSTALLER.</para>
	/// </param>
	/// <param name="MachineName">
	/// A pointer to a NULL-terminated Unicode string that contains the UNC name, including the "\" prefix, of a computer. This pointer
	/// can be set to <c>NULL</c>. If the pointer is <c>NULL</c>, <c>SetupDiSetClassPropertyEx</c> sets the class property for a class
	/// that is installed on the local computer.
	/// </param>
	/// <param name="Reserved">This parameter must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>
	/// <c>SetupDiSetClassPropertyEx</c> returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c>, and the logged
	/// error can be retrieved by calling GetLastError.
	/// </para>
	/// <para>The following table includes some of the more common error codes that this function might log.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value of Flags is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_CLASS</term>
	/// <term>
	/// The device setup class that is specified by ClassGuid is not valid. This error can occur only if the DICLASSPROP_INSTALLER flag
	/// is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_REFERENCE_STRING</term>
	/// <term>The device interface reference string is not valid. This error can occur only if the DICLASSPROP_INTERFACE flag is specified.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_REG_PROPERTY</term>
	/// <term>The property key that is supplied by PropertyKey is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>
	/// An unspecified internal data value was not valid. This error could be logged if either the ClassGuid value is not a valid GUID
	/// or the property value does not match the property type specified by PropertyType.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_USER_BUFFER</term>
	/// <term>A user buffer is not valid. One possibility is that PropertyBuffer is NULL, and PropertyBufferSize is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_MACHINENAME</term>
	/// <term>The computer name that is specified by MachineName is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_INTERFACE_CLASS</term>
	/// <term>
	/// The device interface class that is specified by ClassGuid does not exist. This error can occur only if the DICLASSPROP_INTERFACE
	/// flag is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>An internal data buffer that was passed to a system call was too small.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There was not enough system memory available to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>An unspecified item was not found. One possibility is that the property to be deleted does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have Administrator privileges.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>SetupDiSetClassPropertyEx</c> is part of the unified device property model.</para>
	/// <para>SetupAPI supports only a Unicode version of <c>SetupDiSetClassPropertyEx</c>.</para>
	/// <para>A caller of <c>SetupDiSetClassPropertyEx</c> must be a member of the Administrators group to set a device interface property.</para>
	/// <para><c>SetupDiSetClassPropertyEx</c> enforces requirements on the property-data-type identifier and the property value.</para>
	/// <para>
	/// To obtain the device property keys that represent the device properties that are set for a device class on a remote computer,
	/// call SetupDiGetClassPropertyKeysEx.
	/// </para>
	/// <para>
	/// To retrieve a device class property on a local computer, call SetupDiGetClassProperty <c>,</c> and to retrieve a device class
	/// property on a remote computer, call SetupDiGetClassPropertyEx.
	/// </para>
	/// <para>To set a device class property on a local computer, call SetupDiSetClassProperty.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetclasspropertyexw WINSETUPAPI BOOL
	// SetupDiSetClassPropertyExW( const GUID *ClassGuid, const DEVPROPKEY *PropertyKey, DEVPROPTYPE PropertyType, const PBYTE
	// PropertyBuffer, DWORD PropertyBufferSize, DWORD Flags, PCWSTR MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Unicode)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetClassPropertyExW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetClassPropertyEx(in Guid ClassGuid, in DEVPROPKEY PropertyKey, DEVPROPTYPE PropertyType,
		[In, Optional] IntPtr PropertyBuffer, [In, Optional] uint PropertyBufferSize, DICLASSPROP Flags,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? MachineName, [In, Optional] IntPtr Reserved);

	/// <summary>The <c>SetupDiSetClassRegistryProperty</c> function sets a specified device class property in the registry.</summary>
	/// <param name="ClassGuid">A pointer to the GUID that identifies the device class for which a property is to be set.</param>
	/// <param name="Property">
	/// <para>A value that identifies the property to be set, which must be one of the following:</para>
	/// <para>SPCRP_CHARACTERISTICS</para>
	/// <para>
	/// The caller supplies flags that specify the device characteristics for the class. For a list of characteristics flags, see the
	/// DeviceCharacteristics parameter of IoCreateDevice. Device characteristics should be set when the device class is installed and
	/// should not be changed after the device class is installed.
	/// </para>
	/// <para>SPCRP_DEVTYPE</para>
	/// <para>
	/// The caller supplies the device type for the class. For more information, see Specifying Device Types. Device type should be set
	/// when a device class is installed and should not be changed after the device class is installed.
	/// </para>
	/// <para>SPCRP_EXCLUSIVE</para>
	/// <para>
	/// The caller supplies a DWORD value that specifies whether users can obtain exclusive access to devices for this class. The
	/// supplied value is 1 if exclusive access is allowed, or zero otherwise. The exclusive setting for a device should be set when a
	/// device class is installed and should not be changed after the device class is installed.
	/// </para>
	/// <para>SPCRP_LOWERFILTERS</para>
	/// <para>
	/// (Windows Vista and later) The caller supplies a REG_MULTI_SZ list of the service names of the lower filter drivers that are
	/// installed for the device setup class. For more information about how to install a class filter driver, see Installing a Filter
	/// Driver and INF ClassInstall32 Section.
	/// </para>
	/// <para>SPCRP_SECURITY</para>
	/// <para>
	/// The caller supplies the device's security descriptor as a SECURITY_DESCRIPTOR structure in self-relative format (described in
	/// the Microsoft Windows SDK documentation).
	/// </para>
	/// <para>SPCRP_SECURITY_SDS</para>
	/// <para>
	/// The caller supplies the device's security descriptor as a text string. For information about security descriptor strings, see
	/// Security Descriptor Definition Language (Windows). For information about the format of security descriptor strings, see Security
	/// Descriptor Definition Language (Windows).
	/// </para>
	/// <para>SPCRP_UPPERFILTERS</para>
	/// <para>
	/// (Windows Vista and later) The caller supplies a REG_MULTI_SZ list of the service names of the upper filter drivers that are
	/// installed for the device setup class. For more information about how to install a class filter driver, see Installing a Filter
	/// Driver and INF ClassInstall32 Section.
	/// </para>
	/// </param>
	/// <param name="PropertyBuffer">
	/// A pointer to a buffer that supplies the specified property. This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="PropertyBufferSize">The size, in bytes, of the PropertyBuffer buffer.</param>
	/// <param name="MachineName">
	/// A pointer to a NULL-terminated string that contains the name of a remote system on which to set the specified device class
	/// property. This parameter is optional and can be <c>NULL</c>. If this parameter is <c>NULL</c>, the property is set on the name
	/// of the local system.
	/// </param>
	/// <param name="Reserved">Reserved, must be <c>NULL</c>.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must be a member of the Administrators group.</para>
	/// <para>To determine the data type for a device class property, call SetupDiGetClassRegistryProperty.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetclassregistrypropertyw WINSETUPAPI BOOL
	// SetupDiSetClassRegistryPropertyW( const GUID *ClassGuid, DWORD Property, const BYTE *PropertyBuffer, DWORD PropertyBufferSize,
	// PCWSTR MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetClassRegistryPropertyW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetClassRegistryProperty(in Guid ClassGuid, SPCRP Property, [In, Optional] IntPtr PropertyBuffer,
		uint PropertyBufferSize, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? MachineName, [In, Optional] IntPtr Reserved);

	/// <summary>
	/// The <c>SetupDiSetDeviceInstallParams</c> function sets device installation parameters for a device information set or a
	/// particular device information element.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to the device information set for which to set device installation parameters.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element in DeviceInfoSet. This parameter is
	/// optional and can be set to <c>NULL</c>. If this parameter is specified, <c>SetupDiSetDeviceInstallParams</c> sets the
	/// installation parameters for the specified device. If this parameter is <c>NULL</c>, <c>SetupDiSetDeviceInstallParams</c> sets
	/// the installation parameters that are associated with the global class driver list for DeviceInfoSet.
	/// </param>
	/// <param name="DeviceInstallParams">
	/// A pointer to an SP_DEVINSTALL_PARAMS structure that contains the new values of the parameters. The DeviceInstallParams.
	/// <c>cbSize</c> must be set to the size, in bytes, of the structure before this function is called.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// All parameters are validated before any changes are made. Therefore, a return value of <c>FALSE</c> indicates that no parameters
	/// were modified.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetdeviceinstallparamsa WINSETUPAPI BOOL
	// SetupDiSetDeviceInstallParamsA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DEVINSTALL_PARAMS_A
	// DeviceInstallParams );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetDeviceInstallParamsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetDeviceInstallParams(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
		in SP_DEVINSTALL_PARAMS DeviceInstallParams);

	/// <summary>
	/// The <c>SetupDiSetDeviceInstallParams</c> function sets device installation parameters for a device information set or a
	/// particular device information element.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to the device information set for which to set device installation parameters.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element in DeviceInfoSet. This parameter is
	/// optional and can be set to <c>NULL</c>. If this parameter is specified, <c>SetupDiSetDeviceInstallParams</c> sets the
	/// installation parameters for the specified device. If this parameter is <c>NULL</c>, <c>SetupDiSetDeviceInstallParams</c> sets
	/// the installation parameters that are associated with the global class driver list for DeviceInfoSet.
	/// </param>
	/// <param name="DeviceInstallParams">
	/// A pointer to an SP_DEVINSTALL_PARAMS structure that contains the new values of the parameters. The DeviceInstallParams.
	/// <c>cbSize</c> must be set to the size, in bytes, of the structure before this function is called.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// All parameters are validated before any changes are made. Therefore, a return value of <c>FALSE</c> indicates that no parameters
	/// were modified.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetdeviceinstallparamsa WINSETUPAPI BOOL
	// SetupDiSetDeviceInstallParamsA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DEVINSTALL_PARAMS_A
	// DeviceInstallParams );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetDeviceInstallParamsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetDeviceInstallParams(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData,
		in SP_DEVINSTALL_PARAMS DeviceInstallParams);

	/// <summary>
	/// The <c>SetupDiSetDeviceInterfaceDefault</c> function sets a device interface as the default interface for a device interface class.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set that contains the device interface to set as the default for a device interface class.
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to an SP_DEVICE_INTERFACE_DATA structure that specifies the device interface in DeviceInfoSet.
	/// </param>
	/// <param name="Flags">Not used, must be zero.</param>
	/// <param name="Reserved">Reserved for future use, must be <c>NULL</c>.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// A caller must have Administrator privileges to set the default interface for a device interface class. However, if the requested
	/// default interface is the same as the currently set default interface, the function returns <c>TRUE</c> regardless of whether the
	/// caller has Administrator privileges.
	/// </para>
	/// <para>
	/// If the function successfully sets the specified device interface as the default for the device class, it updates the Flags
	/// member of the supplied SP_DEVICE_INTERFACE_DATA structure.
	/// </para>
	/// <para>
	/// Call SetupDiGetClassDevs to obtain a DevInfoSet handle to a device information set that contains the device interface to set as
	/// the default for a device interface class. To obtain the DeviceInterfaceData pointer to the device interface element, call
	/// SetupDiEnumDeviceInterfaces to enumerate the interfaces in the device information set. To retrieve information about an
	/// enumerated interface, call SetupDiGetDeviceInterfaceDetail.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetdeviceinterfacedefault WINSETUPAPI BOOL
	// SetupDiSetDeviceInterfaceDefault( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData, DWORD Flags, PVOID
	// Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetDeviceInterfaceDefault")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetDeviceInterfaceDefault(HDEVINFO DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
		[In, Optional] uint Flags, [In, Optional] IntPtr Reserved);

	/// <summary>The <c>SetupDiSetDeviceInterfaceProperty</c> function sets a device property of a device interface.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains the device interface for which to set a device interface property.
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to an SP_DEVICE_INTERFACE_DATA structure that represents the device interface for which to set a device interface property.
	/// </param>
	/// <param name="PropertyKey">
	/// A pointer to a DEVPROPKEY structure that represents the device property key of the device interface property to set.
	/// </param>
	/// <param name="PropertyType">
	/// A DEVPROPTYPE-typed value that represents the property-data-type identifier of the device interface property to set. For more
	/// information about the property-data-type identifier, see the <c>Remarks</c> section later in this topic.
	/// </param>
	/// <param name="PropertyBuffer">
	/// A pointer to a buffer that contains the device interface property value. If either the property or the interface value is being
	/// deleted, this pointer must be set to <c>NULL</c>, and PropertyBufferSize must be set to zero. For more information about
	/// property value data, see the <c>Remarks</c> section later in this topic.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. The property buffer size must be consistent with the property-data-type
	/// identifier that is supplied by PropertyType. If PropertyBuffer is set to <c>NULL</c>, PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="Flags">Must be set to zero.</param>
	/// <returns>
	/// <para>
	/// <c>SetupDiSetDeviceInterfaceProperty</c> returns <c>TRUE</c> if it is successful. Otherwise, this function returns <c>FALSE</c>,
	/// and the logged error can be retrieved by calling GetLastError.
	/// </para>
	/// <para>The following table includes some of the more common error codes that this function might log.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value of Flags is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The device information set that is specified by DevInfoSet is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// A supplied parameter is not valid. One possibility is that the device interface specified by DeviceInterfaceData is not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_REG_PROPERTY</term>
	/// <term>The property key that is supplied by PropertyKey is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>
	/// An unspecified data value was not valid. This error could be logged if either the symbolic link name of the device interface is
	/// not valid or the property-data-type identifier is not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_USER_BUFFER</term>
	/// <term>A user buffer is not valid. One possibility is that PropertyBuffer is NULL, and PropertBufferSize is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_DEVICE_INTERFACE</term>
	/// <term>The device interface that is specified by DeviceInterfaceData does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>An internal data buffer that was passed to a system call was too small.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There was not enough system memory available to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>An unspecified internal element was not found. One possibility is that a property to be deleted does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have Administrator privileges.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>SetupDiSetDeviceInterfaceProperty</c> is part of the unified device property model.</para>
	/// <para>SetupAPI supports only a Unicode version of <c>SetupDiSetDeviceInterfaceProperty</c>.</para>
	/// <para>
	/// A caller of <c>SetupDiSetDeviceInterfaceProperty</c> must be a member of the Administrators group to set a device interface property.
	/// </para>
	/// <para><c>SetupDiSetDeviceInterfaceProperty</c> enforces requirements on the property-data-type identifier and the property value.</para>
	/// <para>To obtain the device property keys that represent the device properties that are set for a device interface, call SetupDiGetDeviceInterfacePropertyKeys.</para>
	/// <para>To retrieve a device interface property, call SetupDiGetDeviceInterfaceProperty.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetdeviceinterfacepropertyw WINSETUPAPI BOOL
	// SetupDiSetDeviceInterfacePropertyW( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData, const DEVPROPKEY
	// *PropertyKey, DEVPROPTYPE PropertyType, const PBYTE PropertyBuffer, DWORD PropertyBufferSize, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Unicode)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetDeviceInterfacePropertyW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetDeviceInterfaceProperty(HDEVINFO DeviceInfoSet, in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
		in DEVPROPKEY PropertyKey, DEVPROPTYPE PropertyType, [In, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize, [In, Optional] uint Flags);

	/// <summary>The <c>SetupDiSetDeviceProperty</c> function sets a device instance property.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set. This device information set contains a device information element that represents the
	/// device instance for which to set a device instance property.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to the SP_DEVINFO_DATA structure that identifies the device instance for which to set a device instance property.
	/// </param>
	/// <param name="PropertyKey">
	/// A pointer to a DEVPROPKEY structure that represents the device property key of the device instance property to set.
	/// </param>
	/// <param name="PropertyType">
	/// A DEVPROPTYPE-typed value that represents the property-data-type identifier for the device instance property. For more
	/// information, see the <c>Remarks</c> section later in this topic.
	/// </param>
	/// <param name="PropertyBuffer">
	/// A pointer to a buffer that contains the device instance property value. If the property is being deleted or set to a <c>NULL</c>
	/// value, this pointer must be <c>NULL</c>, and PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is <c>NULL</c>, PropertyBufferSize must be set to zero.
	/// </param>
	/// <param name="Flags">This parameter must be set to zero.</param>
	/// <returns>
	/// <para>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c>, and the logged error can be retrieved
	/// by calling GetLastError.
	/// </para>
	/// <para>The following table includes some of the more common error codes that this function might log.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value of Flags is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The device information set that is specified by DevInfoSet is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A supplied parameter is not valid. One possibility is that the device information element is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_REG_PROPERTY</term>
	/// <term>The property key that is supplied by PropertyKey is not valid or the property is not writable.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>
	/// The property-data-type identifier that is supplied by PropertyType, or the property value that is supplied by PropertyBuffer, is
	/// not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_USER_BUFFER</term>
	/// <term>A user buffer is not valid. One possibility is that PropertyBuffer is NULL, and PropertyBufferSize is not zero.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_DEVINST</term>
	/// <term>The device instance that is specified by DevInfoData does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>An internal data buffer that was passed to a system call was too small.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There was not enough system memory available to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>An unspecified internal element was not found. One possibility is that the property to be deleted does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have Administrator privileges.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>SetupDiSetDeviceProperty</c> is part of the unified device property model.</para>
	/// <para>SetupAPI supports only a Unicode version of <c>SetupDiSetDeviceProperty</c>.</para>
	/// <para>A caller of <c>SetupDiSetDeviceProperty</c> must be a member of the Administrators group to set a device instance property.</para>
	/// <para><c>SetupDiSetDeviceProperty</c> enforces requirements on the property-data-type identifier and the property value.</para>
	/// <para>To obtain the device property keys for the instance device properties that are set for a device, call SetupDiGetDevicePropertyKeys.</para>
	/// <para>To retrieve a device instance property, call SetupDiGetDeviceProperty.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetdevicepropertyw WINSETUPAPI BOOL
	// SetupDiSetDevicePropertyW( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, const DEVPROPKEY *PropertyKey, DEVPROPTYPE
	// PropertyType, const PBYTE PropertyBuffer, DWORD PropertyBufferSize, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Unicode)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetDevicePropertyW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetDeviceProperty(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
		in DEVPROPKEY PropertyKey, DEVPROPTYPE PropertyType, [In, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize, [In, Optional] uint Flags);

	/// <summary>The <c>SetupDiSetDeviceRegistryProperty</c> function sets a Plug and Play device property for a device.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set that contains a device information element that represents the device for which to set a
	/// Plug and Play device property.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. If the
	/// <c>ClassGuid</c> property is set, DeviceInfoData. <c>ClassGuid</c> is set upon return to the new class for the device.
	/// </param>
	/// <param name="Property">
	/// <para>One of the following values, which identifies the property to be set. For descriptions of these values, see SetupDiGetDeviceRegistryProperty.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>SPDRP_CONFIGFLAGS</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_EXCLUSIVE</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_FRIENDLYNAME</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_LOCATION_INFORMATION</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_LOWERFILTERS</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_REMOVAL_POLICY_OVERRIDE</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_SECURITY</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_SECURITY_SDS</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_UI_NUMBER_DESC_FORMAT</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_UPPERFILTERS</term>
	/// </item>
	/// </list>
	/// <para>The following values are reserved for use by the operating system and cannot be used in the Property parameter:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>SPDRP_ADDRESS</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_BUSNUMBER</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_BUSTYPEGUID</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_CHARACTERISTICS</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_CAPABILITIES</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_CLASS</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_CLASSGUID</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_DEVICE_POWER_DATA</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_DEVICEDESC</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_DEVTYPE</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_DRIVER</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_ENUMERATOR_NAME</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_INSTALL_STATE</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_LEGACYBUSTYPE</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_LOCATION_PATHS</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_MFG</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_PHYSICAL_DEVICE_OBJECT_NAME</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_REMOVAL_POLICY</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_REMOVAL_POLICY_HW_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_SERVICE</term>
	/// </item>
	/// <item>
	/// <term>SPDRP_UI_NUMBER</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PropertyBuffer">
	/// A pointer to a buffer that contains the new data for the property. If the property is being cleared, then this pointer should be
	/// <c>NULL</c> and PropertyBufferSize must be zero.
	/// </param>
	/// <param name="PropertyBufferSize">
	/// The size, in bytes, of PropertyBuffer. If PropertyBuffer is <c>NULL</c>, then this field must be zero.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must be a member of the Administrators group.</para>
	/// <para>
	/// The class name property cannot be set because it is based on the corresponding class GUID and is automatically updated when that
	/// property is changed. When the ClassGUID property changes, <c>SetupDiSetDeviceRegistryProperty</c> automatically cleans up any
	/// software keys associated with the device.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetdeviceregistrypropertya WINSETUPAPI BOOL
	// SetupDiSetDeviceRegistryPropertyA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DWORD Property, const BYTE
	// *PropertyBuffer, DWORD PropertyBufferSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetDeviceRegistryPropertyA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetDeviceRegistryProperty(HDEVINFO DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData,
		SPDRP Property, [In, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize);

	/// <summary>The <c>SetupDiSetDriverInstallParams</c> function sets driver installation parameters for a driver information element.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a driver information element that represents the driver for which to set
	/// installation parameters.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element in DeviceInfoSet. This parameter is
	/// optional and can be set to <c>NULL</c>. If this parameter is specified, <c>SetupDiSetDriverInstallParams</c> sets the driver
	/// installation parameters for the specified device. If this parameter is <c>NULL</c>, <c>SetupDiSetDriverInstallParams</c> sets
	/// driver installation parameters for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInfoData">
	/// A pointer to an SP_DRVINFO_DATA structure that specifies the driver for which installation parameters are set. If DeviceInfoData
	/// is specified, this driver must be a member of a driver list that is associated with DeviceInfoData. If DeviceInfoData is
	/// <c>NULL</c>, this driver must be a member of the global class driver list for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInstallParams">A pointer to an SP_DRVINSTALL_PARAMS structure that specifies the new driver install parameters.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to GetLastError.
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetdriverinstallparamsa WINSETUPAPI BOOL
	// SetupDiSetDriverInstallParamsA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DRVINFO_DATA_A DriverInfoData,
	// PSP_DRVINSTALL_PARAMS DriverInstallParams );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetDriverInstallParamsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetDriverInstallParams(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
		in SP_DRVINFO_DATA_V2 DriverInfoData, in SP_DRVINSTALL_PARAMS DriverInstallParams);

	/// <summary>The <c>SetupDiSetDriverInstallParams</c> function sets driver installation parameters for a driver information element.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a driver information element that represents the driver for which to set
	/// installation parameters.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element in DeviceInfoSet. This parameter is
	/// optional and can be set to <c>NULL</c>. If this parameter is specified, <c>SetupDiSetDriverInstallParams</c> sets the driver
	/// installation parameters for the specified device. If this parameter is <c>NULL</c>, <c>SetupDiSetDriverInstallParams</c> sets
	/// driver installation parameters for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInfoData">
	/// A pointer to an SP_DRVINFO_DATA structure that specifies the driver for which installation parameters are set. If DeviceInfoData
	/// is specified, this driver must be a member of a driver list that is associated with DeviceInfoData. If DeviceInfoData is
	/// <c>NULL</c>, this driver must be a member of the global class driver list for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInstallParams">A pointer to an SP_DRVINSTALL_PARAMS structure that specifies the new driver install parameters.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to GetLastError.
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetdriverinstallparamsa WINSETUPAPI BOOL
	// SetupDiSetDriverInstallParamsA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DRVINFO_DATA_A DriverInfoData,
	// PSP_DRVINSTALL_PARAMS DriverInstallParams );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetDriverInstallParamsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetDriverInstallParams(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData,
		in SP_DRVINFO_DATA_V2 DriverInfoData, in SP_DRVINSTALL_PARAMS DriverInstallParams);

	/// <summary>
	/// The <c>SetupDiSetSelectedDevice</c> function sets a device information element as the selected member of a device information
	/// set. This function is typically used by an installation wizard.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set that contains the device information element to set as the selected member of the device
	/// information set.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet to set as the selected
	/// member of DeviceInfoSet.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetselecteddevice WINSETUPAPI BOOL
	// SetupDiSetSelectedDevice( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetSelectedDevice")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetSelectedDevice(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiSetSelectedDriver</c> function sets, or resets, the selected driver for a device information element or the
	/// selected class driver for a device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set that contains the driver list from which to select a driver for a device information
	/// element or for the device information set.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This parameter is
	/// optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiSetSelectedDriver</c> sets, or resets, the selected
	/// driver for the specified device. If this parameter is <c>NULL</c>, <c>SetupDiSetSelectedDriver</c> sets, or resets, the selected
	/// class driver for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInfoData">
	/// <para>
	/// A pointer to an SP_DRVINFO_DATA structure that specifies the driver to be selected. This parameter is optional and can be
	/// <c>NULL</c>. If this parameter and DeviceInfoData are supplied, the specified driver must be a member of a driver list that is
	/// associated with DeviceInfoData. If this parameter is specified and DeviceInfoData is <c>NULL</c>, the driver must be a member of
	/// the global class driver list for DeviceInfoSet. If this parameter is <c>NULL</c>, the selected driver is reset for the device
	/// information element, if DeviceInfoData is specified, or the device information set, if DeviceInfoData is <c>NULL</c>.
	/// </para>
	/// <para>
	/// If the DriverInfoData. <c>Reserved</c> is <c>NULL</c>, the caller is requesting a search for a driver node with the specified
	/// parameters ( <c>DriverType</c>, <c>Description</c>, and <c>ProviderName</c>). If a match is found, that driver node is selected.
	/// The <c>Reserved</c> field is updated on output to reflect the actual driver node where the match was found. If a match is not
	/// found, the function fails and a call to GetLastError returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the caller of <c>SetupDiSetSelectedDriver</c> is a member of the Administrators group, the class of the device is set to the
	/// class of the selected driver, provided that the two classes are different.
	/// </para>
	/// <para>
	/// If DriverInfoData is <c>NULL</c>, <c>SetupDiSetSelectedDriver</c> resets the selected driver. As a result, there is no selected driver.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetselecteddrivera WINSETUPAPI BOOL
	// SetupDiSetSelectedDriverA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DRVINFO_DATA_A DriverInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetSelectedDriverA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetSelectedDriver(HDEVINFO DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData, ref SP_DRVINFO_DATA_V2 DriverInfoData);

	/// <summary>
	/// The <c>SetupDiSetSelectedDriver</c> function sets, or resets, the selected driver for a device information element or the
	/// selected class driver for a device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set that contains the driver list from which to select a driver for a device information
	/// element or for the device information set.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This parameter is
	/// optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiSetSelectedDriver</c> sets, or resets, the selected
	/// driver for the specified device. If this parameter is <c>NULL</c>, <c>SetupDiSetSelectedDriver</c> sets, or resets, the selected
	/// class driver for DeviceInfoSet.
	/// </param>
	/// <param name="DriverInfoData">
	/// <para>
	/// A pointer to an SP_DRVINFO_DATA structure that specifies the driver to be selected. This parameter is optional and can be
	/// <c>NULL</c>. If this parameter and DeviceInfoData are supplied, the specified driver must be a member of a driver list that is
	/// associated with DeviceInfoData. If this parameter is specified and DeviceInfoData is <c>NULL</c>, the driver must be a member of
	/// the global class driver list for DeviceInfoSet. If this parameter is <c>NULL</c>, the selected driver is reset for the device
	/// information element, if DeviceInfoData is specified, or the device information set, if DeviceInfoData is <c>NULL</c>.
	/// </para>
	/// <para>
	/// If the DriverInfoData. <c>Reserved</c> is <c>NULL</c>, the caller is requesting a search for a driver node with the specified
	/// parameters ( <c>DriverType</c>, <c>Description</c>, and <c>ProviderName</c>). If a match is found, that driver node is selected.
	/// The <c>Reserved</c> field is updated on output to reflect the actual driver node where the match was found. If a match is not
	/// found, the function fails and a call to GetLastError returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the caller of <c>SetupDiSetSelectedDriver</c> is a member of the Administrators group, the class of the device is set to the
	/// class of the selected driver, provided that the two classes are different.
	/// </para>
	/// <para>
	/// If DriverInfoData is <c>NULL</c>, <c>SetupDiSetSelectedDriver</c> resets the selected driver. As a result, there is no selected driver.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdisetselecteddrivera WINSETUPAPI BOOL
	// SetupDiSetSelectedDriverA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DRVINFO_DATA_A DriverInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiSetSelectedDriverA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiSetSelectedDriver(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData, [In, Optional] IntPtr DriverInfoData);

	/// <summary>The <c>SetupDiUnremoveDevice</c> function is the default handler for the DIF_UNREMOVE installation request.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set for the local system that contains a device information element that represents a device to
	/// restore and to restart.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This is an IN-OUT
	/// parameter because DeviceInfoData. <c>DevInst</c> might be updated with a new handle value on return.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiUnremoveDevice</c> restores a device to a hardware profile. This function starts the device, if possible, or it sets a
	/// flag in the device install parameters that eventually causes the user to be prompted to shut down the system.
	/// </para>
	/// <para>
	/// <c>Note</c> Only a class installer should call <c>SetupDiUnremoveDevice</c> and only in those situations where the class
	/// installer must perform device unremove operations after <c>SetupDiUnremoveDevice</c> completes the default device unremove
	/// operation. In such situations, the class installer must directly call <c>SetupDiUnremoveDevice</c> when the installer processes
	/// a DIF_UNREMOVE request. For more information about calling the default handler, see Calling Default DIF Code Handlers.
	/// </para>
	/// <para>
	/// The device being restored must have class install parameters for DIF_UNREMOVE or the function fails and GetLastError returns ERROR_NO_CLASSINSTALL_PARAMS.
	/// </para>
	/// <para>The DeviceInfoSet must only contain elements on the local computer.</para>
	/// <para>The caller of <c>SetupDiUnremoveDevice</c> must be a member of the Administrators group.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiunremovedevice WINSETUPAPI BOOL
	// SetupDiUnremoveDevice( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiUnremoveDevice")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiUnremoveDevice(HDEVINFO DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData);
}