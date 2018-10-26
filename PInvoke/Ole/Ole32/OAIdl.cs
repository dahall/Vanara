using System;
using System.Runtime.InteropServices;
using EXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>Communicates detailed error information between a client and an object.</summary>
		[ComImport, Guid("3127CA40-446E-11CE-8135-00AA004BB851"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("OAIdl.h")]
		public interface IErrorLog
		{
			/// <summary>Logs an error (using an EXCEPINFO structure) in the error log for a named property.</summary>
			/// <param name="pszPropName">
			/// A pointer to a string containing the name of the property involved with the error. This cannot be NULL.
			/// </param>
			/// <param name="pExcepInfo">
			/// A pointer to the caller-initialized EXCEPINFO structure that describes the error to log. This cannot be NULL.
			/// </param>
			void AddError([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropName, in EXCEPINFO pExcepInfo);
		}

		/// <summary>Provides an object with a property bag in which the object can save its properties persistently.</summary>
		/// <remarks>
		/// To read a property in IPersistPropertyBag::Load, the object calls IPropertyBag::Read. When the object saves properties in
		/// IPersistPropertyBag::Save, it calls IPropertyBag::Write. Each property is described with a name, whose value is stored in a
		/// VARIANT. This information allows a client to save the property values as text, for example; which is the primary reason why a
		/// client might choose to support IPersistPropertyBag.
		/// </remarks>
		[ComImport, Guid("55272A00-42CB-11CE-8135-00AA004BB851"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("OAIdl.h")]
		public interface IPropertyBag
		{
			/// <summary>Tells the property bag to read the named property into a caller-initialized VARIANT.</summary>
			/// <param name="pszPropName">The address of the name of the property to read. This cannot be NULL.</param>
			/// <param name="pVar">
			/// The address of the caller-initialized VARIANT that receives the property value on output. The function must set the type
			/// field and the value field in the VARIANT before it returns. If the caller initialized the pVar-&gt;vt field on entry, the
			/// property bag attempts to change its corresponding value to this type. If the caller sets pVar-&gt;vt to VT_EMPTY, the
			/// property bag can use whatever type is convenient.
			/// </param>
			/// <param name="pErrorLog">
			/// The address of the caller's error log in which the property bag stores any errors that occur during reads. This can be NULL;
			/// in which case, the caller does not receive errors.
			/// </param>
			/// <remarks>
			/// The Read method tells the property bag to read the property named in pszPropName to the caller-initialized VARIANT in pVar.
			/// Errors are logged in the error log that is pointed to by pErrorLog. When pVar-&gt;vt specifies another object pointer
			/// (VT_UNKNOWN), the property bag is responsible for creating and initializing the object described by pszPropName.
			/// </remarks>
			void Read([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropName, [In, Out] ref object pVar, [In] IErrorLog pErrorLog);

			/// <summary>Tells the property bag to save the named property in a caller-initialized VARIANT.</summary>
			/// <param name="pszPropName">The address of a string containing the name of the property to write. This cannot be NULL.</param>
			/// <param name="pVar">
			/// The address of the caller-initialized VARIANT that holds the property value to save. The caller owns this VARIANT, and is
			/// responsible for all of its allocations. That is, the property bag does not attempt to free data in the VARIANT.
			/// </param>
			/// <remarks>
			/// The Write method tells the property bag to save the property named with pszPropName by using the type and value in the
			/// caller-initialized VARIANT in pVar. In some cases, the caller might be telling the property bag to save another object, for
			/// example, when pVar-&gt;vt is VT_UNKNOWN. In such cases, the property bag queries this object pointer for a persistence
			/// interface, such as IPersistStream or IPersistPropertyBag, and has that object save its data as well. Usually this results in
			/// the property bag having some byte array for this object, which can be saved as encoded text, such as hexadecimal string,
			/// MIME, and so on. When the property bag is later used to reinitialize a control, the client that owns the property bag must
			/// re-create the object when the caller asks for it, initializing that object with the previously saved bits.
			/// <para>
			/// This allows efficient persistence operations for Binary Large Object (BLOB) properties, such as a picture, where the owner of
			/// the property bag tells the picture object (which is managed as a property in the control that is saved) to save to a specific
			/// location. This avoids potential extra copy operations that might be involved with other property-based persistence mechanisms.
			/// </para>
			/// </remarks>
			void Write([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropName, in object pVar);
		}
	}
}