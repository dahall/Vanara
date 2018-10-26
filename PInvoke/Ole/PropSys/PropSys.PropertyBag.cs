using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke
{
	public static partial class PropSys
	{
		/// <summary>
		/// <para>Deletes a property from a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_delete PSSTDAPI PSPropertyBag_Delete(
		// IPropertyBag *propBag, LPCWSTR propName );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "53ED1C87-5141-4925-B70E-C0304817A871")]
		public static extern HRESULT PSPropertyBag_Delete(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName);

		/// <summary>
		/// <para>Reads the <c>BOOL</c> data value of a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>When this function returns successfully, contains a pointer to the value read from the property.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between windows types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readbool PSSTDAPI PSPropertyBag_ReadBOOL(
		// IPropertyBag *propBag, LPCWSTR propName, BOOL *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "95F9CB5E-E690-4d83-A094-02981F0578CF")]
		public static extern HRESULT PSPropertyBag_ReadBOOL(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, [MarshalAs(UnmanagedType.Bool)] out bool value);

		/// <summary>
		/// <para>Reads a <c>BSTR</c> data value from a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>BSTR*</c></para>
		/// <para>When this function returns, contains a pointer to a <c>BSTR</c> property value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readbstr PSSTDAPI PSPropertyBag_ReadBSTR(
		// IPropertyBag *propBag, LPCWSTR propName, BSTR *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "14F21A4D-4867-4c4d-9BD8-C733B1C50266")]
		public static extern HRESULT PSPropertyBag_ReadBSTR(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, [MarshalAs(UnmanagedType.BStr)] out string value);

		/// <summary>
		/// <para>Reads a <c>DWORD</c> data value from property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>When this function returns, contains a pointer to a <c>DWORD</c> property value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readdword PSSTDAPI PSPropertyBag_ReadDWORD(
		// IPropertyBag *propBag, LPCWSTR propName, DWORD *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "31977E3F-FA2F-4c2d-8A95-6BF937EDC45C")]
		public static extern HRESULT PSPropertyBag_ReadDWORD(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, out uint value);

		/// <summary>
		/// <para>Reads the GUID data value from a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>GUID*</c></para>
		/// <para>When this function returns, contains a pointer to a GUID property value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readguid PSSTDAPI PSPropertyBag_ReadGUID(
		// IPropertyBag *propBag, LPCWSTR propName, GUID *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "BCC6E830-CF05-42c1-874F-CCC97E58A4BC")]
		public static extern HRESULT PSPropertyBag_ReadGUID(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, out Guid value);

		/// <summary>
		/// <para>Reads an <c>int</c> data value from a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>int*</c></para>
		/// <para>When this function returns, contains a pointer to an <c>int</c> property value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>If the property bag does not already contain the specified property, the call still succeeds.</para>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readint PSSTDAPI PSPropertyBag_ReadInt(
		// IPropertyBag *propBag, LPCWSTR propName, INT *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "9CEC97E6-C88F-4182-876C-D77EA14915DA")]
		public static extern HRESULT PSPropertyBag_ReadInt(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, out int value);

		/// <summary>
		/// <para>Reads a <c>LONG</c> data value from a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>When this function returns, contains a pointer to a <c>LONG</c> property value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>If the property bag does not already contain the specified property, the call still succeeds.</para>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readlong PSSTDAPI PSPropertyBag_ReadLONG(
		// IPropertyBag *propBag, LPCWSTR propName, LONG *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "A39E1F7C-A4FB-47da-A05E-39F6176F2878")]
		public static extern HRESULT PSPropertyBag_ReadLONG(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, out int value);

		/// <summary>
		/// <para>Retrieves the property coordinates stored in a POINTL structure of a specified property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>POINTL*</c></para>
		/// <para>When this function returns, contains a pointer to a POINTL structure that contains the property coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readpointl PSSTDAPI
		// PSPropertyBag_ReadPOINTL( IPropertyBag *propBag, LPCWSTR propName, POINTL *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "B8F66DF9-A366-41a7-8311-B9E1CDE14ADB")]
		public static extern HRESULT PSPropertyBag_ReadPOINTL(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, out Point value);

		/// <summary>
		/// <para>Retrieves the property coordinates stored in a POINTS structure of a specified property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>POINTS*</c></para>
		/// <para>When this function returns successfully, contains a pointer to a POINTS structure that contains the property coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readpoints PSSTDAPI
		// PSPropertyBag_ReadPOINTS( IPropertyBag *propBag, LPCWSTR propName, POINTS *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "60ED145A-7712-43b7-A2AD-C366DD32E19E")]
		public static extern HRESULT PSPropertyBag_ReadPOINTS(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, out POINTS value);

		/// <summary>
		/// <para>Reads the property key of a property in a specified property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>PROPERTYKEY*</c></para>
		/// <para>When this function returns, contains a pointer to a property key value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readpropertykey PSSTDAPI
		// PSPropertyBag_ReadPropertyKey( IPropertyBag *propBag, LPCWSTR propName, PROPERTYKEY *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "910D1356-DC61-470b-90BB-0DCF1B861E05")]
		public static extern HRESULT PSPropertyBag_ReadPropertyKey(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, out PROPERTYKEY value);

		/// <summary>
		/// <para>Retrieves the coordinates of a rectangle stored in a property contained in a specified property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>RECTL*</c></para>
		/// <para>When this function returns, contains a pointer to a RECTL structure that contains the property coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readrectl PSSTDAPI PSPropertyBag_ReadRECTL(
		// IPropertyBag *propBag, LPCWSTR propName, RECTL *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "4DAABF63-7CBA-4361-9E58-7072869CFDEC")]
		public static extern HRESULT PSPropertyBag_ReadRECTL(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, out RECT value);

		/// <summary>
		/// <para>Reads the SHORT data value of a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>SHORT*</c></para>
		/// <para>When this function returns, contains a pointer to a SHORT property value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readshort PSSTDAPI PSPropertyBag_ReadSHORT(
		// IPropertyBag *propBag, LPCWSTR propName, SHORT *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "F6E71602-86D0-41be-854F-83C5D5B64BF8")]
		public static extern HRESULT PSPropertyBag_ReadSHORT(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, out short value);

		/// <summary>
		/// <para>Reads the string data value of a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>When this function returns, contains a pointer to a string property value.</para>
		/// </param>
		/// <param name="characterCount">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// This function returns the integer that represents the size (maximum number of characters) of the value parameter being returned.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readstr PSSTDAPI PSPropertyBag_ReadStr(
		// IPropertyBag *propBag, LPCWSTR propName, LPWSTR value, int characterCount );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "2E3E86D6-B070-49fc-AAF0-D6DCF0EA16B7")]
		public static extern HRESULT PSPropertyBag_ReadStr(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder value, int characterCount);

		/// <summary>
		/// <para>Reads a string data value from a property in a property bag and allocates memory for the string that is read.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>
		/// When this function returns, contains a pointer to a string data value from a property in a property bag and allocates memory for
		/// the string that is read. The caller of the PSPropertyBag_ReadStrAlloc function needs to call a CoTaskMemFree function on this parameter.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readstralloc PSSTDAPI
		// PSPropertyBag_ReadStrAlloc( IPropertyBag *propBag, LPCWSTR propName, PWSTR *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "2F58A6DB-3563-42fa-9B6F-327D0A87AE81")]
		public static extern HRESULT PSPropertyBag_ReadStrAlloc(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string value);

		/// <summary>
		/// <para>Reads the data stream stored in a given property contained in a specified property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object, that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>IStream**</c></para>
		/// <para>The address of a pointer that, when this function returns successfully, receives the IStream object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The caller of the PSPropertyBag_ReadStream function needs to call a IUnknown::Release method on the IStream object returned by
		/// this function.
		/// </para>
		/// <para>
		/// IPropertyBag and IPersistPropertyBag optimize Save As Text functionality. <c>IPropertyBag</c> and IPropertyBag2 provide an object
		/// with a property bag in which the object can save its properties persistently. <c>IPropertyBag2</c> allows the object to obtain
		/// type information for each property: IPropertyBag2::Read causes one or more properties to be read from the property bag, and
		/// IPropertyBag2::Write causes one or more properties to be saved into the property bag.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readstream PSSTDAPI
		// PSPropertyBag_ReadStream( IPropertyBag *propBag, LPCWSTR propName, IStream **value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "3D1D8B3E-DD16-4b34-918C-C8478EBF0930")]
		public static extern HRESULT PSPropertyBag_ReadStream(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, out IStream value);

		/// <summary>
		/// <para>Reads the type of data value of a property that is stored in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object, that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated property name string.</para>
		/// </param>
		/// <param name="var">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>Returns on successful function completion a pointer to a <c>VARIANT</c> data type that contains the property value.</para>
		/// </param>
		/// <param name="type">
		/// <para>Type: <c>VARTYPE*</c></para>
		/// <para>
		/// If type is VT_EMPTY, this function reads the <c>VARIANT</c> of the property in the IPropertyBag propBag parameter. If type is not
		/// VT_EMPTY and not the same as the <c>VARIANT</c> read, then this function attempts to convert the <c>VARIANT</c> read to the
		/// <c>VARTYPE</c> defined by type parameter before returning.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// IPropertyBag and IPersistPropertyBag optimize Save As Text functionality. <c>IPropertyBag</c> and IPropertyBag2 provide an object
		/// with a property bag in which the object can save its properties persistently. <c>IPropertyBag2</c> allows the object to obtain
		/// type information for each property: IPropertyBag2::Read causes one or more properties to be read from the property bag, and
		/// IPropertyBag2::Write causes one or more properties to be saved into the property bag.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readtype PSSTDAPI PSPropertyBag_ReadType(
		// IPropertyBag *propBag, LPCWSTR propName, VARIANT *var, VARTYPE type );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "826038F7-FD93-474e-BCA7-910E214F3E01")]
		public static extern HRESULT PSPropertyBag_ReadType(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, out object var, VARTYPE type);

		/// <summary>
		/// <para>Reads a <c>ULONGLONG</c> data value from a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>ULONGLONG</c></para>
		/// <para>When this function returns, contains a pointer to a <c>ULONGLONG</c> property value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readulonglong PSSTDAPI
		// PSPropertyBag_ReadULONGLONG( IPropertyBag *propBag, LPCWSTR propName, ULONGLONG *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "6DB59A95-D571-452b-8974-76B4CC3FA36F")]
		public static extern HRESULT PSPropertyBag_ReadULONGLONG(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, out ulong value);

		/// <summary>
		/// <para>Reads a given property of an unknown data value in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object, that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated property name string.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// A reference to the IID of the interface to retrieve through ppv. This interface IID should be IPropertyBag or an interface
		/// derived from <c>IPropertyBag</c>.
		/// </para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this method returns successfully, contains the interface pointer requested in riid. This is typically riid.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// IPropertyBag and IPersistPropertyBag optimize Save As Text functionality. <c>IPropertyBag</c> and IPropertyBag2 provide an object
		/// with a property bag in which the object can save its properties persistently. <c>IPropertyBag2</c> allows the object to obtain
		/// type information for each property: IPropertyBag2::Read causes one or more properties to be read from the property bag, and
		/// IPropertyBag2::Write causes one or more properties to be saved into the property bag.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_readunknown PSSTDAPI
		// PSPropertyBag_ReadUnknown( IPropertyBag *propBag, LPCWSTR propName, REFIID riid, void **ppv );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "87921F52-308F-4ed7-8390-A3C0217ACEFD")]
		public static extern HRESULT PSPropertyBag_ReadUnknown(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		/// <summary>
		/// <para>Sets the <c>BOOL</c> value of a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>The <c>BOOL</c> value to which the named property should be set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_writebool PSSTDAPI PSPropertyBag_WriteBOOL(
		// IPropertyBag *propBag, LPCWSTR propName, BOOL value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "3703A7C4-CFDC-4453-AA8F-6A5D6B7D3E66")]
		public static extern HRESULT PSPropertyBag_WriteBOOL(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, [MarshalAs(UnmanagedType.Bool)] bool value);

		/// <summary>
		/// <para>Sets the <c>BSTR</c> value of a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>The <c>BSTR</c> value to which the named property should be set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_writebstr PSSTDAPI PSPropertyBag_WriteBSTR(
		// IPropertyBag *propBag, LPCWSTR propName, BSTR value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "9C2DBD1F-6760-4812-A33E-9A71C5A421A9")]
		public static extern HRESULT PSPropertyBag_WriteBSTR(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, [MarshalAs(UnmanagedType.BStr)] string value);

		/// <summary>
		/// <para>Sets the <c>DWORD</c> value of a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A <c>DWORD</c> value to which the named property should be set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_writedword PSSTDAPI
		// PSPropertyBag_WriteDWORD( IPropertyBag *propBag, LPCWSTR propName, DWORD value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "59142C21-032F-462c-B4A7-337483917ABC")]
		public static extern HRESULT PSPropertyBag_WriteDWORD(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, uint value);

		/// <summary>
		/// <para>Sets the GUID value of a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>A pointer to a GUID value to which the named property should be set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_writeguid PSSTDAPI PSPropertyBag_WriteGUID(
		// IPropertyBag *propBag, LPCWSTR propName, const GUID *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "F50CF010-3A4E-4723-BA9F-CE1B48CA4AA4")]
		public static extern HRESULT PSPropertyBag_WriteGUID(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, in Guid value);

		/// <summary>
		/// <para>Sets the <c>int</c> value of a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>int</c></para>
		/// <para>The <c>int</c> value to which the property should be set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_writeint PSSTDAPI PSPropertyBag_WriteInt(
		// IPropertyBag *propBag, LPCWSTR propName, INT value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "1FCC59B1-5084-4981-8F1D-A5860744F221")]
		public static extern HRESULT PSPropertyBag_WriteInt(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, int value);

		/// <summary>
		/// <para>Sets the <c>LONG</c> value of a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>LONG</c></para>
		/// <para>The <c>LONG</c> value to which the property should be set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_writelong PSSTDAPI PSPropertyBag_WriteLONG(
		// IPropertyBag *propBag, LPCWSTR propName, LONG value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "A623D097-FEF8-4864-A80A-C6EF824EC245")]
		public static extern HRESULT PSPropertyBag_WriteLONG(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, int value);

		/// <summary>
		/// <para>Stores the property coordinates in aPOINTL structure of a specified property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>const POINTL*</c></para>
		/// <para>A pointer to a POINTL structure that specifies the coordinates to store in the property.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_writepointl PSSTDAPI
		// PSPropertyBag_WritePOINTL( IPropertyBag *propBag, LPCWSTR propName, const POINTL *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "881A9D35-DF77-44d1-86DF-D6BC97AC0DD4")]
		public static extern HRESULT PSPropertyBag_WritePOINTL(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, in Point value);

		/// <summary>
		/// <para>Stores the property coordinates in aPOINTS structure of a specified property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>const POINTS*</c></para>
		/// <para>Pointer to a POINTS structure that specifies the coordinates to store in the property.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_writepoints PSSTDAPI
		// PSPropertyBag_WritePOINTS( IPropertyBag *propBag, LPCWSTR propName, const POINTS *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "B1E3E061-042A-4ba0-98F2-EA8A022882CC")]
		public static extern HRESULT PSPropertyBag_WritePOINTS(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, in POINTS value);

		/// <summary>
		/// <para>Sets the property key value of a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>REFPROPERTYKEY</c></para>
		/// <para>A PROPERTYKEY structure that specifies the property key value to store in the property.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Property keys uniquely identify a property. For example, corresponds to . This function succeeds only for properties registered
		/// as part of the property schema.
		/// </para>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_writepropertykey PSSTDAPI
		// PSPropertyBag_WritePropertyKey( IPropertyBag *propBag, LPCWSTR propName, REFPROPERTYKEY value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "52965079-ECC6-411a-BBB9-4EA2B7C01631")]
		public static extern HRESULT PSPropertyBag_WritePropertyKey(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, in PROPERTYKEY value);

		/// <summary>
		/// <para>Stores the coordinates of a rectangle in a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>const RECTL*</c></para>
		/// <para>A pointer to a RECTL structure that specifies the coordinates to store in the property.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_writerectl PSSTDAPI
		// PSPropertyBag_WriteRECTL( IPropertyBag *propBag, LPCWSTR propName, const RECTL *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "83C29519-CAB0-4989-85B5-70AD79E69D04")]
		public static extern HRESULT PSPropertyBag_WriteRECTL(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, in RECT value);

		/// <summary>
		/// <para>Sets the SHORT value of a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>SHORT</c></para>
		/// <para>The SHORT value to which the property should be set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_writeshort PSSTDAPI
		// PSPropertyBag_WriteSHORT( IPropertyBag *propBag, LPCWSTR propName, SHORT value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "9A8F0974-E7BE-4d66-8DBF-68744C0124A2")]
		public static extern HRESULT PSPropertyBag_WriteSHORT(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, short value);

		/// <summary>
		/// <para>Sets the string value of a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>The string value to which the property should be set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_writestr PSSTDAPI PSPropertyBag_WriteStr(
		// IPropertyBag *propBag, LPCWSTR propName, LPCWSTR value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "D3614CAE-D594-4050-B80E-20D8BBB93744")]
		public static extern HRESULT PSPropertyBag_WriteStr(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, [MarshalAs(UnmanagedType.LPWStr)] string value);

		/// <summary>
		/// <para>Writes a data stream to a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>A pointer to the IStream object to write to the property.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_writestream PSSTDAPI
		// PSPropertyBag_WriteStream( IPropertyBag *propBag, LPCWSTR propName, IStream *value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "48C3E7F7-ED7E-4797-A66A-A8529BF2A79C")]
		public static extern HRESULT PSPropertyBag_WriteStream(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, IStream value);

		/// <summary>
		/// <para>Sets the <c>ULONGLONG</c> value of a property in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A null-terminated property name string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <c>ULONGLONG</c></para>
		/// <para>An <c>ULONGLONG</c> value to which the property should be set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_writeulonglong PSSTDAPI
		// PSPropertyBag_WriteULONGLONG( IPropertyBag *propBag, LPCWSTR propName, ULONGLONG value );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "37854C80-00B9-465c-88D9-619695D418CD")]
		public static extern HRESULT PSPropertyBag_WriteULONGLONG(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, ulong value);

		/// <summary>
		/// <para>Writes a property of an unknown data value in a property bag.</para>
		/// </summary>
		/// <param name="propBag">
		/// <para>Type: <c>IPropertyBag*</c></para>
		/// <para>A pointer to an IPropertyBag object that represents the property bag in which the property is stored.</para>
		/// </param>
		/// <param name="propName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated property name string.</para>
		/// </param>
		/// <param name="punk">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>A pointer to an IUnknown derived interface that copies the specified property of an unknown data value in a property bag.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property bag property function API converts between window types and the <c>VARIANT</c> type that is used to express values
		/// in a property bag. Doing so eases property bag usage, simplifies applications, and avoids common coding errors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-pspropertybag_writeunknown PSSTDAPI
		// PSPropertyBag_WriteUnknown( IPropertyBag *propBag, LPCWSTR propName, IUnknown *punk );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "D96643E7-9A14-4410-BD2C-A264B74E0590")]
		public static extern HRESULT PSPropertyBag_WriteUnknown(IPropertyBag propBag, [MarshalAs(UnmanagedType.LPWStr)] string propName, [MarshalAs(UnmanagedType.IUnknown)] object punk);
	}
}