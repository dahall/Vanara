using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.PInvoke
{
    public static partial class PortableDeviceApi
    {
        /// <summary>
        /// The <c>WPD_STREAM_UNITS</c> enumeration specifies the unit types to be used for <c>IPortableDeviceUnitsStream</c> operations.
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-stream-units typedef enum _WPD_STREAM_UNITS { WPD_STREAM_UNITS_BYTES =
        // 0, WPD_STREAM_UNITS_FRAMES = 1, WPD_STREAM_UNITS_ROWS = 2, WPD_STREAM_UNITS_MILLISECONDS = 3, WPD_STREAM_UNITS_MICROSECONDS = 4 } WPD_STREAM_UNITS;
        [PInvokeData("portabldevicetypes.h")]
        public enum WPD_STREAM_UNITS
        {
            /// <summary>The stream units are specified in bytes.</summary>
            WPD_STREAM_UNITS_BYTES = 0,

            /// <summary>The stream units are specified in frames.</summary>
            WPD_STREAM_UNITS_FRAMES = 1,

            /// <summary>The stream units are specified in rows.</summary>
            WPD_STREAM_UNITS_ROWS = 2,

            /// <summary>The stream units are specified in milliseconds.</summary>
            WPD_STREAM_UNITS_MILLISECONDS = 4,

            /// <summary>The stream units are specified in microseconds.</summary>
            WPD_STREAM_UNITS_MICROSECONDS = 8,
        }

        /// <summary>
        /// The <c>IPortableDeviceKeyCollection</c> interface holds a collection of <c>PROPERTYKEY</c> values. This interface can be
        /// retrieved from a method or, if a new object is required, call <c>CoCreate</c> with <c>CLSID_PortableDeviceKeyCollection</c>.
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicekeycollection
        [PInvokeData("portabldevicetypes.h")]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("DADA2357-E0AD-492E-98DB-DD61C53BA353"), CoClass(typeof(PortableDeviceKeyCollection))]
        public interface IPortableDeviceKeyCollection
        {
            /// <summary>The <c>GetCount</c> method retrieves the number of keys in this collection.</summary>
            /// <returns>A <c>DWORD</c> that contains the number of keys in the collection.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicekeycollection-getcount HRESULT GetCount( [in] DWORD
            // *pcElems );
            uint GetCount();

            /// <summary>The <c>GetAt</c> method retrieves a <c>PROPERTYKEY</c> from the collection by index.</summary>
            /// <param name="dwIndex"><c>DWORD</c> that contains the index of the key to be retrieved.</param>
            /// <returns>A <c>PROPERTYKEY</c> object.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicekeycollection-getat HRESULT GetAt( [in] const DWORD
            // dwIndex, [out] PROPERTYKEY *pKey );
            PROPERTYKEY GetAt([In] uint dwIndex);

            /// <summary>The <c>Add</c> method adds a property key to the collection.</summary>
            /// <param name="Key">
            /// A <c>REFPROPERTYKEY</c> to add to the collection. This method copies the key to the collection, so you can release the local
            /// variable after calling this method.
            /// </param>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicekeycollection-add HRESULT Add( [in] REFPROPERTYKEY Key );
            void Add(in PROPERTYKEY Key);

            /// <summary>Deletes all items from the collection.</summary>
            /// <remarks>None.</remarks>
            // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/portabledevicetypes/nf-portabledevicetypes-iportabledevicekeycollection-clear
            // HRESULT Clear();
            void Clear();

            /// <summary>The <c>RemoveAt</c> method removes the element stored at the location specified by the given index.</summary>
            /// <param name="dwIndex">Specifies the index of the element to be removed.</param>
            /// <remarks>You must specify a zero-based index.</remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicekeycollection-removeat HRESULT RemoveAt( [in] const
            // DWORD dwIndex );
            void RemoveAt([In] uint dwIndex);
        }

        /// <summary>
        /// <para>
        /// The <c>IPortableDevicePropVariantCollection</c> interface holds a collection of indexed <c>PROPVARIANT</c> values of the same
        /// VARTYPE. The VARTYPE of the first item that is added to the collection determines the VARTYPE of the collection. An attempt to
        /// add an item of a different VARTYPE may fail if the <c>PROPVARIANT</c> value cannot be changed to the collection's current
        /// VARTYPE. To change the VARTYPE of the collection, call <c>ChangeType</c>.
        /// </para>
        /// <para>This interface can be retrieved from a method or, if a new object is required, call <c>CoCreate</c> with <c>CLSID_PortableDevicePropVariantCollection</c>.</para>
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicepropvariantcollection
        [PInvokeData("portabldevicetypes.h")]
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("89B2E422-4F1B-4316-BCEF-A44AFEA83EB3"), CoClass(typeof(PortableDevicePropVariantCollection))]
        public interface IPortableDevicePropVariantCollection
        {
            /// <summary>The <c>GetCount</c> method retrieves the number of items in this collection.</summary>
            /// <returns>The number of items in the collection.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicepropvariantcollection-getcount HRESULT GetCount( [in]
            // DWORD *pcElems );
            uint GetCount();

            /// <summary>The <c>GetAt</c> method retrieves an item from the collection by a zero-based index.</summary>
            /// <param name="dwIndex"><c>DWORD</c> that contains the zero-based index of the item to retrieve.</param>
            /// <param name="pValue">A <c>PROPVARIANT</c> structure. The caller is responsible for freeing this memory by calling <c>PropVariantClear</c>.</param>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicepropvariantcollection-getat HRESULT GetAt( [in] const
            // DWORD dwIndex, [out] PROPVARIANT *pValue );
            void GetAt([In] uint dwIndex, [Out] PROPVARIANT pValue);

            /// <summary>The <c>Add</c> method adds an item to the collection.</summary>
            /// <param name="pValue">
            /// A new <c>PROPVARIANT</c> object to add to the collection. This method copies the <c>PROPVARIANT</c> to the collection, so
            /// you should release your local copy of the variable by calling <c>PropVariantClear</c> after calling this method.
            /// </param>
            /// <remarks>
            /// <para>
            /// When the VARTYPE for pValue is VT_VECTOR or VT_UI1, setting and retrieving a <c>NULL</c> or zero-sized buffer is not
            /// supported. For example, neither pValue.caub.pElems = <c>NULL</c> nor pValue.caub.cElems = 0 are allowed.
            /// </para>
            /// <para>
            /// If a caller tries to add an item of a different VARTYPE contained in the collection and the PROPVARIANT value cannot be
            /// changed by this interface automatically, this method will fail. To change the collection type manually, call <c>IPortableDevicePropVariantCollection::ChangeType</c>.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicepropvariantcollection-add HRESULT Add( [in] const
            // PROPVARIANT *pValue );
            void Add([In] PROPVARIANT pValue);

            /// <summary>The <c>GetType</c> method retrieves the data type of the items in the collection.</summary>
            /// <returns>A Platform SDK <c>VARTYPE</c> enumeration value that indicates the data type of all the items in the collection.</returns>
            /// <remarks>All items that are stored in an <c>IPortableDevicePropVariantCollection</c> are the same type.</remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicepropvariantcollection-gettype HRESULT GetType( [out]
            // VARTYPE *pvt );
            VARTYPE GetType();

            /// <summary>The <c>ChangeType</c> method converts all items in the collection to the specified VARTYPE.</summary>
            /// <param name="vt">
            /// Specifies the <c>VARTYPE</c> to which you want to convert all items in the collection. Example types include VT_UI4 and VT_UI8.
            /// </param>
            /// <remarks>
            /// If this method fails, the collection may be left in an intermediate state, with some members converted and some not converted.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicepropvariantcollection-changetype HRESULT ChangeType(
            // [in] const VARTYPE vt );
            void ChangeType([In] VARTYPE vt);

            /// <summary>
            /// The <c>Clear</c> method frees, and then removes, all items from the collection. The collection is considered empty after
            /// calling this method.
            /// </summary>
            /// <remarks>
            /// After calling <c>Clear</c>, the collection is considered type-less, meaning that the VARTYPE it was previously set to is no
            /// longer restricting <c>Add</c> operations. A call to <c>Add</c> after calling <c>Clear</c> is considered the "first"
            /// <c>Add</c> for this collection.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicepropvariantcollection-clear HRESULT Clear();
            void Clear();

            /// <summary>The <c>RemoveAt</c> method removes the element stored at the location specified by the given index.</summary>
            /// <param name="dwIndex">Specifies the index of the element to be removed.</param>
            /// <remarks>You must specify a zero-based index.</remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicepropvariantcollection-removeat HRESULT RemoveAt( [in]
            // const DWORD dwIndex );
            void RemoveAt([In] uint dwIndex);
        }

        /// <summary>
        /// <para>
        /// The <c>IPortableDeviceValues</c> interface holds a collection of <c>PROPERTYKEY</c>/ <c>PROPVARIANT</c> pairs. Values in the
        /// collection do not need to be the same VARTYPE.
        /// </para>
        /// <para>
        /// Values are stored as key-value pairs; each key must be unique in the collection. Clients can search for items by
        /// <c>PROPERTYKEY</c> or zero-based index. Data values are stored as <c>PROPVARIANT</c> structures. You can add or retrieve values
        /// of any type by using the generic methods <c>SetValue</c> and <c>GetValue</c>, or you add items by using the method specific to
        /// the type of data added.
        /// </para>
        /// <para>
        /// The <c>Get...</c> methods require the caller to release any retrieved values appropriately. The <c>Set...</c> methods copy the
        /// value into the collection.
        /// </para>
        /// <para>
        /// When an <c>IPortableDeviceValues</c> interface is released, it calls <c>Clear</c>, which frees the memory that was allocated for
        /// all its members appropriately.
        /// </para>
        /// <para>This interface can be retrieved from a method or, if a new object is required, call <c>CoCreate</c> with <c>CLSID_PortableDeviceValues</c>.</para>
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues
        [PInvokeData("portabldevicetypes.h")]
        [ComImport, Guid("6848f6f2-3155-4f86-b6f5-263eeeab3143"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(PortableDeviceValues))]
        public interface IPortableDeviceValues
        {
            /// <summary>The <c>GetCount</c> method retrieves the number of items in the collection.</summary>
            /// <returns>A <c>DWORD</c> that contains the number of items in the collection.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getcount HRESULT GetCount( [in] DWORD *pcelt );
            uint GetCount();

            /// <summary>The <c>GetAt</c> method retrieves a value from the collection using the supplied zero-based index.</summary>
            /// <param name="index">A <c>DWORD</c> that specifies a zero-based index in the collection.</param>
            /// <param name="pKey">An optional <c>PROPERTYKEY</c> pointer that retrieves the key of the specified item.</param>
            /// <param name="pValue">
            /// An optional <c>PROPVARIANT</c> that retrieves the value of the specified item. The caller must free the memory by calling
            /// <c>PropVariantClear</c> when done with it.
            /// </param>
            /// <remarks>
            /// If a property indicates a value of type VT_UNKNOWN, the property will be one of the Windows Portable Devices (
            /// <c>IPortableDeviceKeyCollection</c>, <c>IPortableDeviceValuesCollection</c>, <c>IPortableDeviceValues</c> or
            /// <c>IPortableDevicePropVariantCollection</c>). No other interfaces can be returned by Windows Portable Devices.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getat HRESULT GetAt( [in] const DWORD index,
            // [in, out] PROPERTYKEY *pKey, [in, out] PROPVARIANT *pValue );
            void GetAt(uint index, out PROPERTYKEY pKey, [Out] PROPVARIANT pValue);

            /// <summary>The <c>SetValue</c> method adds a new <c>PROPVARIANT</c> value or overwrites an existing one.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="pValue">
            /// A <c>PROPVARIANT</c> that specifies the new value. The SDK copies the value, so the caller can release the local variable by
            /// calling <c>PropVariantClear</c> after calling this method.
            /// </param>
            /// <remarks>
            /// <para>
            /// When the VARTYPE for pValue is VT_VECTOR or VT_UI1, setting a <c>NULL</c> or zero-sized buffer is not supported. For
            /// example, neither pValue.caub.pElems = <c>NULL</c> nor pValue.caub.cElems = 0 are allowed.
            /// </para>
            /// <para>
            /// This method can be used to retrieve a value of any type from the collection. However, if you know the value type in advance,
            /// use one of the specialized <c>Set...</c> methods of this interface to avoid the overhead of working with PROPVARIANT values directly.
            /// </para>
            /// <para>
            /// If an existing value has the same key that is specified by the key parameter, it overwrites the existing value without any
            /// warning. The existing key memory is released appropriately.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-setvalue HRESULT SetValue( [in] REFPROPERTYKEY
            // key, [in] const PROPVARIANT *pValue );
            void SetValue(in PROPERTYKEY key, [In] PROPVARIANT pValue);

            /// <summary>The <c>GetValue</c> method retrieves a <c>PROPVARIANT</c> value specified by a key.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>
            /// Pointer to the retrieved <c>PROPVARIANT</c> value. The caller must release the memory by calling <c>PropVariantClear</c>
            /// when done with it.
            /// </returns>
            /// <remarks>
            /// <para>
            /// When the VARTYPE for pValue is VT_VECTOR or VT_UI1, retrieving a <c>NULL</c> or zero-sized buffer is not supported. For
            /// example, neither pValue.caub.pElems = <c>NULL</c> nor pValue.caub.cElems = 0 are allowed.
            /// </para>
            /// <para>
            /// This method can be used to retrieve a value of any type from the collection. However, if you know the value type in advance,
            /// use one of the specialized retrieval methods of this interface to avoid the overhead of working with PROPVARIANT values directly.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getvalue HRESULT GetValue( [in] REFPROPERTYKEY
            // key, [out] PROPVARIANT *pValue );
            PROPVARIANT GetValue(in PROPERTYKEY key);

            /// <summary>The <c>SetStringValue</c> method adds a new string value (type VT_LPWSTR) or overwrites an existing one.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="Value">
            /// A <c>LPCWSTR</c> that specifies the new value. The string is copied, so the caller can release the memory allocated for this
            /// value after calling this method.
            /// </param>
            /// <remarks>Any existing key memory will be released appropriately.</remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-setstringvalue HRESULT SetStringValue( [in]
            // REFPROPERTYKEY key, [in] LPCWSTR Value );
            void SetStringValue(in PROPERTYKEY key, [In, MarshalAs(UnmanagedType.LPWStr)] string Value);

            /// <summary>The <c>GetStringValue</c> method retrieves a string value (type VT_LPWSTR) specified by a key.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>
            /// Pointer to the retrieved <c>LPWSTR</c> value. The caller is responsible for calling <c>CoTaskMemFree</c> to release the memory.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getstringvalue HRESULT GetStringValue( [in]
            // REFPROPERTYKEY key, [out] LPWSTR *pValue );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetStringValue(in PROPERTYKEY key);

            /// <summary>
            /// The <c>SetUnsignedIntegerValue</c> method adds a new <c>ULONG</c> value (type VT_UI4) or overwrites an existing one.
            /// </summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="Value">A <c>ULONG</c> that specifies the new value.</param>
            /// <remarks>
            /// If an existing value has the same key that is specified by the key parameter, it overwrites the existing value without any warning.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-setunsignedintegervalue HRESULT
            // SetUnsignedIntegerValue( [in] REFPROPERTYKEY key, [in] const ULONG Value );
            void SetUnsignedIntegerValue(in PROPERTYKEY key, [In] uint Value);

            /// <summary>The <c>GetUnsignedIntegerValue</c> method retrieves a <c>ULONG</c> value (type VT_UI4) specified by a key.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>Pointer to the retrieved <c>ULONG</c> value.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getunsignedintegervalue HRESULT
            // GetUnsignedIntegerValue( [in] REFPROPERTYKEY key, [out] ULONG *pValue );
            uint GetUnsignedIntegerValue(in PROPERTYKEY key);

            /// <summary>
            /// The <c>SetSignedIntegerValue</c> method adds a new <c>LONG</c> value (type VT_I4) or overwrites an existing one.
            /// </summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="Value">A <c>LONG</c> that specifies the new value.</param>
            /// <remarks>
            /// If an existing value has the same key that is specified by the key parameter, it overwrites the existing value without any warning.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-setsignedintegervalue HRESULT
            // SetSignedIntegerValue( [in] REFPROPERTYKEY key, [in] const LONG Value );
            void SetSignedIntegerValue(in PROPERTYKEY key, [In] int Value);

            /// <summary>The <c>GetSignedIntegerValue</c> method retrieves a <c>LONG</c> value (type VT_I4) specified by a key.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>Pointer to the retrieved <c>LONG</c> value.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getsignedintegervalue HRESULT
            // GetSignedIntegerValue( [in] REFPROPERTYKEY key, [out] LONG *pValue );
            int GetSignedIntegerValue(in PROPERTYKEY key);

            /// <summary>
            /// The <c>SetUnsignedLargeIntegerValue</c> method adds a new <c>ULONGLONG</c> value (type VT_UI8) or overwrites an existing one.
            /// </summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="Value">A <c>ULONGLONG</c> that specifies the new value.</param>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-setunsignedlargeintegervalue HRESULT
            // SetUnsignedLargeIntegerValue( [in] REFPROPERTYKEY key, [in] const ULONGLONG Value );
            void SetUnsignedLargeIntegerValue(in PROPERTYKEY key, [In] ulong Value);

            /// <summary>
            /// The <c>GetUnsignedLargeIntegerValue</c> method retrieves a <c>ULONGLONG</c> value (type VT_UI8) specified by a key.
            /// </summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>Pointer to the retrieved <c>ULONGLONG</c> value.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getunsignedlargeintegervalue HRESULT
            // GetUnsignedLargeIntegerValue( [in] REFPROPERTYKEY key, [out] ULONGLONG *pValue );
            ulong GetUnsignedLargeIntegerValue(in PROPERTYKEY key);

            /// <summary>
            /// The <c>SetSignedLargeIntegerValue</c> method adds a new <c>LONGLONG</c> value (type VT_I8) or overwrites an existing one.
            /// </summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="Value">A <c>LONGLONG</c> that specifies the new value.</param>
            /// <remarks>
            /// If an existing value has the same key that is specified by the key parameter, it overwrites the existing value without any warning.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-setsignedlargeintegervalue HRESULT
            // SetSignedLargeIntegerValue( [in] REFPROPERTYKEY key, [in] const LONGLONG Value );
            void SetSignedLargeIntegerValue(in PROPERTYKEY key, [In] long Value);

            /// <summary>The <c>GetSignedLargeIntegerValue</c> method retrieves a <c>LONGLONG</c> value (type VT_I8) specified by a key.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>Pointer to the retrieved <c>ULONG</c> value.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getsignedlargeintegervalue HRESULT
            // GetSignedLargeIntegerValue( [in] REFPROPERTYKEY key, [out] LONGLONG *pValue );
            long GetSignedLargeIntegerValue(in PROPERTYKEY key);

            /// <summary>The <c>SetFloatValue</c> method adds a new <c>FLOAT</c> value (type VT_R4) or overwrites an existing one.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="Value">A <c>FLOAT</c> that contains the new value.</param>
            /// <remarks>
            /// If an existing value has the same key that is specified by the key parameter, it overwrites the existing value without any warning.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-setfloatvalue HRESULT SetFloatValue( [in]
            // REFPROPERTYKEY key, [in] const FLOAT Value );
            void SetFloatValue(in PROPERTYKEY key, [In] float Value);

            /// <summary>The <c>GetFloatValue</c> method retrieves a <c>FLOAT</c> value (type VT_R4) specified by a key.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>Pointer to the retrieved <c>FLOAT</c> value.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getfloatvalue HRESULT GetFloatValue( [in]
            // REFPROPERTYKEY key, [out] FLOAT *pValue );
            float GetFloatValue(in PROPERTYKEY key);

            /// <summary>The <c>SetErrorValue</c> method adds a new <c>HRESULT</c> value (type VT_ERROR) or overwrites an existing one.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="Value">An <c>HRESULT</c> that contains the new value.</param>
            /// <remarks>
            /// If an existing value has the same key specified by the key parameter, it overwrites the existing value without any warning.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-seterrorvalue HRESULT SetErrorValue( [in]
            // REFPROPERTYKEY key, [in] const HRESULT Value );
            void SetErrorValue(in PROPERTYKEY key, HRESULT Value);

            /// <summary>The <c>GetErrorValue</c> method retrieves an <c>HRESULT</c> value (type VT_ERROR) specified by a key.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>Pointer to the retrieved <c>HRESULT</c> value.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-geterrorvalue HRESULT GetErrorValue( [in]
            // REFPROPERTYKEY key, [out] HRESULT *pValue );
            HRESULT GetErrorValue(in PROPERTYKEY key);

            /// <summary>
            /// The <c>SetKeyValue</c> method adds a new <c>REFPROPERTYKEY</c> value (type VT_UNKNOWN) or overwrites an existing one.
            /// </summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="Value">A <c>REFPROPERTYKEY</c> that specifies the new value.</param>
            /// <remarks>
            /// If an existing value has the same key that is specified by the key parameter, it overwrites the existing value without any
            /// warning. The existing key memory is released appropriately.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-setkeyvalue HRESULT SetKeyValue( [in]
            // REFPROPERTYKEY key, [in] REFPROPERTYKEY Value );
            void SetKeyValue(in PROPERTYKEY key, in PROPERTYKEY Value);

            /// <summary>The <c>GetKeyValue</c> method retrieves a <c>PROPERTYKEY</c> value specified by a key.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>Pointer to the retrieved <c>PROPERTYKEY</c> value.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getkeyvalue HRESULT GetKeyValue( [in]
            // REFPROPERTYKEY key, [out] PROPERTYKEY *pValue );
            PROPERTYKEY GetKeyValue(in PROPERTYKEY key);

            /// <summary>The <c>SetBoolValue</c> method adds a new <c>Boolean</c> value (type VT_BOOL) or overwrites an existing one.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="Value">A <c>BOOL</c> that specifies the new value.</param>
            /// <remarks>
            /// If an existing value has the same key specified by the key parameter, it overwrites the existing value without any warning.
            /// The existing key memory is released appropriately.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-setboolvalue HRESULT SetBoolValue( [in]
            // REFPROPERTYKEY key, [in] const BOOL Value );
            void SetBoolValue(in PROPERTYKEY key, [In, MarshalAs(UnmanagedType.Bool)] bool Value);

            /// <summary>The <c>GetBoolValue</c> method retrieves a <c>Boolean</c> value (type VT_BOOL) specified by a key.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>Pointer to the retrieved <c>BOOL</c> value.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getboolvalue HRESULT GetBoolValue( [in]
            // REFPROPERTYKEY key, [out] BOOL *pValue );
            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetBoolValue(in PROPERTYKEY key);

            /// <summary>
            /// The <c>SetIUnknownValue</c> method adds a new <c>IUnknown</c> value (type VT_UNKNOWN) or overwrites an existing one.
            /// </summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="pValue">
            /// A pointer to an <c>IUnknown</c> interface that specifies the new value. The SDK copies a reference to the submitted
            /// interface and calls <c>AddRef</c> on it.
            /// </param>
            /// <remarks>
            /// If an existing value has the same key that is specified by the key parameter, it overwrites the existing value without any
            /// warning. The existing key memory is released appropriately.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-setiunknownvalue HRESULT SetIUnknownValue( [in]
            // REFPROPERTYKEY key, [in] IUnknown *pValue );
            void SetIUnknownValue(in PROPERTYKEY key, [In, MarshalAs(UnmanagedType.IUnknown)] object pValue);

            /// <summary>
            /// The <c>GetIUnknownValue</c> method retrieves an <c>IUnknown</c> interface value (type VT_UNKNOWN) specified by a key.
            /// </summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>
            /// Address of a variable that receives a pointer to the retrieved <c>IUnknown</c> interface. The caller is responsible for
            /// calling <c>Release</c> on the retrieved interface.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getiunknownvalue HRESULT GetIUnknownValue( [in]
            // REFPROPERTYKEY key, [out] IUnknown **ppValue );
            [return: MarshalAs(UnmanagedType.IUnknown)]
            object GetIUnknownValue(in PROPERTYKEY key);

            /// <summary>The <c>SetGuidValue</c> method adds a new <c>GUID</c> value (type VT_CLSID) or overwrites an existing one.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="Value">A <c>REFGUID</c> that contains the new value.</param>
            /// <remarks>
            /// If an existing value has the same key that is specified by the key parameter, it overwrites the existing value without any warning.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-setguidvalue HRESULT SetGuidValue( [in]
            // REFPROPERTYKEY key, [in] REFGUID Value );
            void SetGuidValue(in PROPERTYKEY key, in Guid Value);

            /// <summary>The <c>GetGuidValue</c> method retrieves a <c>GUID</c> value (type VT_CLSID) specified by a key.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>Pointer to the retrieved <c>GUID</c> value.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getguidvalue HRESULT GetGuidValue( [in]
            // REFPROPERTYKEY key, [out] GUID *pValue );
            Guid GetGuidValue(in PROPERTYKEY key);

            /// <summary>
            /// The <c>SetBufferValue</c> method adds a new <c>BYTE</c>* value (type VT_VECTOR | VT_UI1) or overwrites an existing one.
            /// </summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="pValue">
            /// A <c>BYTE*</c> that contains the data to write to the item. The submitted buffer data is copied to the interface, so the
            /// caller can free this buffer after making this call.
            /// </param>
            /// <param name="cbValue">The size of the value pointed to by pValue, in bytes.</param>
            /// <remarks>
            /// <para>
            /// If an existing value has the same key that is specified by the key parameter, it overwrites the existing value without any
            /// warning. The existing key memory is released appropriately.
            /// </para>
            /// <para>Setting a <c>NULL</c> or a zero-sized buffer is not supported.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-setbuffervalue HRESULT SetBufferValue( [in]
            // REFPROPERTYKEY key, [in] BYTE *pValue, [in] DWORD cbValue );
            void SetBufferValue(in PROPERTYKEY key, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pValue, [In] int cbValue);

            /// <summary>
            /// The <c>GetBufferValue</c> method retrieves a <c>byte array</c> value (type VT_VECTOR | VT_UI1) specified by a key.
            /// </summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <param name="ppValue">
            /// Pointer to the retrieved <c>BYTE*</c> value. The caller is responsible for freeing the memory by calling <c>CoTaskMemFree</c>.
            /// </param>
            /// <param name="pcbValue">Pointer to the size of ppValue, in bytes.</param>
            /// <remarks>Retrieving a <c>NULL</c> buffer or a zero-sized buffer is not supported.</remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getbuffervalue HRESULT GetBufferValue( [in]
            // REFPROPERTYKEY key, [out] BYTE **ppValue, [out] DWORD *pcbValue );
            void GetBufferValue(in PROPERTYKEY key, [Out] out SafeCoTaskMemHandle ppValue, [Out] out int pcbValue);

            /// <summary>
            /// The <c>SetIPortableDeviceValuesValue</c> method adds a new <c>IPortableDeviceValues</c> value (type VT_UNKNOWN) or
            /// overwrites an existing one.
            /// </summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="pValue">
            /// An <c>IPortableDeviceValues</c> interface that specifies the new value. The SDK copies a reference to the submitted
            /// interface and calls <c>AddRef</c> on it.
            /// </param>
            /// <remarks>
            /// If an existing value has the same key that is specified by the key parameter, it overwrites the existing value without any
            /// warning. The existing key memory is released appropriately.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-setiportabledevicevaluesvalue HRESULT
            // SetIPortableDeviceValuesValue( [in] REFPROPERTYKEY key, [in] IPortableDeviceValues *pValue );
            void SetIPortableDeviceValuesValue(in PROPERTYKEY key, [In] IPortableDeviceValues pValue);

            /// <summary>
            /// The <c>GetIPortableDeviceValuesValue</c> method retrieves an <c>IPortableDeviceValues</c> value (type VT_UNKNOWN) specified
            /// by a key.
            /// </summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>
            /// Address of a variable that receives a pointer to the retrieved <c>IPortableDeviceValues</c> interface. The caller is
            /// responsible for calling <c>Release</c> on the retrieved interface.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getiportabledevicevaluesvalue HRESULT
            // GetIPortableDeviceValuesValue( [in] REFPROPERTYKEY key, [out] IPortableDeviceValues **ppValue );
            IPortableDeviceValues GetIPortableDeviceValuesValue(in PROPERTYKEY key);

            /// <summary>
            /// The <c>SetIPortableDevicePropVariantCollectionValue</c> method adds a new <c>IPortableDevicePropVariantCollection</c> value
            /// (type VT_UNKNOWN) or overwrites an existing one.
            /// </summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="pValue">
            /// An <c>IPortableDevicePropVariantCollection</c> interface that specifies the new value. The SDK copies a reference to the
            /// submitted interface and calls <c>AddRef</c> on it.
            /// </param>
            /// <remarks>
            /// If an existing value has the same key that is specified by the key parameter, it overwrites the existing value without any
            /// warning. The existing key memory is released appropriately.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-setiportabledevicepropvariantcollectionvalue
            // HRESULT SetIPortableDevicePropVariantCollectionValue( [in] REFPROPERTYKEY key, [in] IPortableDevicePropVariantCollection
            // *pValue );
            void SetIPortableDevicePropVariantCollectionValue(in PROPERTYKEY key, IPortableDevicePropVariantCollection pValue);

            /// <summary>
            /// The <c>GetIPortableDevicePropVariantCollectionValue</c> method retrieves an <c>IPortableDevicePropVariantCollection</c>
            /// value (type VT_UNKNOWN) specified by a key.
            /// </summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>
            /// Address of a variable that receives a pointer to the retrieved <c>IPortableDevicePropVariantCollection</c> interface. The
            /// caller is responsible for calling <c>Release</c> on the retrieved interface.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-getiportabledevicepropvariantcollectionvalue
            // HRESULT GetIPortableDevicePropVariantCollectionValue( [in] REFPROPERTYKEY key, [out] IPortableDevicePropVariantCollection
            // **ppValue );
            IPortableDevicePropVariantCollection GetIPortableDevicePropVariantCollectionValue(in PROPERTYKEY key);

            /// <summary>Adds a new <c>SetIPortableDeviceKeyCollectionValue</c> value (type VT_UNKNOWN) or overwrites an existing one.</summary>
            /// <param name="key">[in] A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="pValue">
            /// [in] An <c>IPortableDeviceKeyCollection</c> interface that specifies the new value. The SDK copies a reference to the
            /// submitted interface and calls <c>AddRef</c> on it.
            /// </param>
            /// <remarks>
            /// If an existing value has the same key that is specified by the key parameter, it overwrites the existing value without any
            /// warning. The existing key memory is released appropriately.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/portabledevicetypes/nf-portabledevicetypes-iportabledevicevalues-setiportabledevicekeycollectionvalue
            // HRESULT SetIPortableDeviceKeyCollectionValue( REFPROPERTYKEY key, IPortableDeviceKeyCollection *pValue );
            void SetIPortableDeviceKeyCollectionValue(in PROPERTYKEY key, IPortableDeviceKeyCollection pValue);

            /// <summary>Retrieves an <c>IPortableDeviceKeyCollection</c> value (type VT_UNKNOWN) that is specified by a key.</summary>
            /// <param name="key">[in] A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>
            /// [out] Pointer to the retrieved IPortableDeviceKeyCollection interface pointer. The caller is responsible for calling
            /// <c>Release</c> on the retrieved interface.
            /// </returns>
            /// <remarks>None.</remarks>
            // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/portabledevicetypes/nf-portabledevicetypes-iportabledevicevalues-getiportabledevicekeycollectionvalue
            // HRESULT GetIPortableDeviceKeyCollectionValue( REFPROPERTYKEY key, IPortableDeviceKeyCollection **ppValue );
            IPortableDeviceKeyCollection GetIPortableDeviceKeyCollectionValue(in PROPERTYKEY key);

            /// <summary>Adds a new <c>IPortableDeviceValuesCollection</c> value (type VT_UNKNOWN) or overwrites an existing one.</summary>
            /// <param name="key">[in] A <c>REFPROPERTYKEY</c> that specifies the item to create or overwrite.</param>
            /// <param name="pValue">
            /// [in] An <c>IPortableDeviceValuesCollection</c> interface that specifies the new value. The SDK copies a reference to the
            /// submitted interface and calls <c>AddRef</c> on it.
            /// </param>
            /// <remarks>
            /// If an existing value has the same key that is specified by the key parameter, it overwrites the existing value without any
            /// warning. The existing key memory is released appropriately.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/portabledevicetypes/nf-portabledevicetypes-iportabledevicevalues-setiportabledevicevaluescollectionvalue
            // HRESULT SetIPortableDeviceValuesCollectionValue( REFPROPERTYKEY key, IPortableDeviceValuesCollection *pValue );
            void SetIPortableDeviceValuesCollectionValue(in PROPERTYKEY key, IPortableDeviceValuesCollection pValue);

            /// <summary>Retrieves an <c>IPortableDeviceValuesCollection</c> (type VT_UNKNOWN) value specified by a key.</summary>
            /// <param name="key">[in] A <c>REFPROPERTYKEY</c> key that specifies the item to retrieve.</param>
            /// <returns>
            /// [out] Address of a variable that receives a pointer to the retrieved IPortableDeviceValuesCollection interface. The caller
            /// is responsible for calling <c>Release</c> on the retrieved interface.
            /// </returns>
            /// <remarks>None.</remarks>
            // https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/portabledevicetypes/nf-portabledevicetypes-iportabledevicevalues-getiportabledevicevaluescollectionvalue
            // HRESULT GetIPortableDeviceValuesCollectionValue( REFPROPERTYKEY key, IPortableDeviceValuesCollection **ppValue );
            IPortableDeviceValuesCollection GetIPortableDeviceValuesCollectionValue(in PROPERTYKEY key);

            /// <summary>The <c>RemoveValue</c> method removes an item from the collection.</summary>
            /// <param name="key">A <c>REFPROPERTYKEY</c> that specifies the item to remove.</param>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-removevalue HRESULT RemoveValue( [in]
            // REFPROPERTYKEY key );
            void RemoveValue(in PROPERTYKEY key);

            /// <summary>The <c>CopyValuesFromPropertyStore</c> method copies the contents of an <c>IPropertyStore</c> into the collection.</summary>
            /// <param name="pStore">An <c>IPropertyStore</c> to copy into the collection.</param>
            /// <remarks>
            /// <para>This method automatically converts all <c>VT_BSTR</c> values to <c>VT_LPWSTR</c> values.</para>
            /// <para>
            /// Many external applications or components that communicate with your application, such as some shell applications, use the
            /// <c>IPropertyStore</c> interface. This method provides a quick and easy way to exchange data with these programs.
            /// </para>
            /// <para>This method is supported in Windows Vista and later versions of Windows.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-copyvaluesfrompropertystore HRESULT
            // CopyValuesFromPropertyStore( [in] IPropertyStore *pStore );
            void CopyValuesFromPropertyStore(IPropertyStore pStore);

            /// <summary>
            /// The <c>CopyValuesToPropertyStore</c> method copies all the values from a collection into an <c>IPropertyStore</c> interface.
            /// </summary>
            /// <param name="pStore">A store object.</param>
            /// <remarks>
            /// <para>
            /// This method does not convert values of VT_LPWSTR into VT_BSTR. Many external applications or components that communicate
            /// with your application, such as some shell applications, use the <c>IPropertyStore</c> interface. This method provides a
            /// quick and easy way to exchange data with these programs.
            /// </para>
            /// <para>This method is supported in Windows Vista and later versions of Windows.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-copyvaluestopropertystore HRESULT
            // CopyValuesToPropertyStore( [in] IPropertyStore *pStore );
            void CopyValuesToPropertyStore(IPropertyStore pStore);

            /// <summary>The <c>Clear</c> method deletes all items from the collection.</summary>
            /// <remarks>
            /// This method frees the memory for all dynamically allocated items in the collection. For interfaces, it calls <c>Release</c>.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevalues-clear HRESULT Clear();
            void Clear();
        }

        /// <summary>
        /// The <c>IPortableDeviceValuesCollection</c> interface holds a collection of zero-based indexed <c>IPortableDeviceValues</c>
        /// interfaces. This interface can be retrieved from a method, or if a new object is required, call <c>CoCreate</c> with <c>CLSID_PortableDeviceValuesCollection</c>.
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevaluescollection
        [PInvokeData("portabldevicetypes.h")]
        [ComImport, Guid("6E3F2D79-4E07-48C4-8208-D8C2E5AF4A99"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(PortableDeviceValuesCollection))]
        public interface IPortableDeviceValuesCollection
        {
            /// <summary>The <c>GetCount</c> method retrieves the number of items in the collection.</summary>
            /// <returns>The number of <c>IPortableDeviceValues</c> interfaces in the collection.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevaluescollection-getcount HRESULT GetCount( [in] DWORD
            // *pcElems );
            uint GetCount();

            /// <summary>The <c>GetAt</c> method retrieves an item from the collection by a zero-based index.</summary>
            /// <param name="dwIndex"><c>DWORD</c> that specifies a zero-based index in the collection.</param>
            /// <returns>
            /// An <c>IPortableDeviceValues</c> interface from the collection. The caller is responsible for calling <c>Release</c> on this
            /// interface when done with it.
            /// </returns>
            /// <remarks>Any changes that are made to values in the retrieved interface will be made to the version stored in the collection.</remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevaluescollection-getat HRESULT GetAt( [in] const DWORD
            // dwIndex, [out] IPortableDeviceValues **ppValues );
            IPortableDeviceValues GetAt(uint dwIndex);

            /// <summary>The <c>Add</c> method adds an item to the collection.</summary>
            /// <param name="pValues">
            /// An <c>IPortableDeviceValues</c> interface to add to the collection. The interface is not actually copied, but <c>AddRef</c>
            /// is called on it.
            /// </param>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevaluescollection-add HRESULT Add( [in]
            // IPortableDeviceValues *pValues );
            void Add(IPortableDeviceValues pValues);

            /// <summary>The <c>Clear</c> method releases all items from the collection.</summary>
            /// <remarks>The method releases all memory that is allocated for the items in the collection.</remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevaluescollection-clear HRESULT Clear();
            void Clear();

            /// <summary>The <c>RemoveAt</c> method removes the element stored at the location specified by the given index.</summary>
            /// <param name="dwIndex">Specifies the index of the element to be removed.</param>
            /// <remarks>You must specify a zero-based index.</remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iportabledevicevaluescollection-removeat HRESULT RemoveAt( [in] const
            // DWORD dwIndex );
            void RemoveAt(uint dwIndex);
        }

        /// <summary>
        /// <para>
        /// The <c>IWpdSerializer</c> interface is used by the device driver to serialize <c>IPortableDeviceValues</c> interfaces to and
        /// from the raw data buffers used to communicate with the application.
        /// </para>
        /// <para>
        /// Applications do not need to use this interface, because the data is serialized and deserialized automatically when calling <c>IPortableDevice::SendCommand</c>.
        /// </para>
        /// <para>To get this interface, call <c>CoCreateInstance</c> and pass in <c>IID_IWpdSerializer</c>.</para>
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iwpdserializer
        [PInvokeData("portabldevicetypes.h")]
        [ComImport, Guid("b32f4002-bb27-45ff-af4f-06631c1e8dad"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(WpdSerializer))]
        public interface IWpdSerializer
        {
            /// <summary>
            /// The <c>GetIPortableDeviceValuesFromBuffer</c> method deserializes a byte array to an <c>IPortableDeviceValues</c> interface.
            /// </summary>
            /// <param name="pBuffer">Pointer to the buffer to deserialize.</param>
            /// <param name="dwInputBufferLength"><c>DWORD</c> that specifies the size of the buffer, in bytes.</param>
            /// <returns>
            /// An <c>IPortableDeviceValues</c> interface created from the buffer. The application is responsible for calling <c>Release</c>
            /// on the interface.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iwpdserializer-getiportabledevicevaluesfrombuffer HRESULT
            // GetIPortableDeviceValuesFromBuffer( [in] BYTE *pBuffer, [in] DWORD dwInputBufferLength, [out] IPortableDeviceValues
            // **ppParams );
            IPortableDeviceValues GetIPortableDeviceValuesFromBuffer(byte[] pBuffer, uint dwInputBufferLength);

            /// <summary>
            /// The <c>WriteIPortableDeviceValuesToBuffer</c> method serializes an <c>IPortableDeviceValues</c> interface to a
            /// caller-allocated byte array.
            /// </summary>
            /// <param name="dwOutputBufferLength"><c>DWORD</c> that specifies the size of pBuffer, in bytes.</param>
            /// <param name="pResults">An <c>IPortableDeviceValues</c> interface to serialize.</param>
            /// <param name="pBuffer">A caller-allocated buffer. To learn the size of the required buffer, call <c>GetSerializedSize</c>.</param>
            /// <param name="pdwBytesWritten">
            /// A <c>DWORD</c> that indicates the number of bytes that was actually written to the caller-allocated buffer.
            /// </param>
            /// <remarks>
            /// This method copies an <c>IPortableDeviceValues</c> interface into an existing buffer. If you want to allocate a new buffer,
            /// use <c>GetBufferFromIPortableDeviceValues</c>.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iwpdserializer-writeiportabledevicevaluestobuffer HRESULT
            // WriteIPortableDeviceValuesToBuffer( [in] DWORD dwOutputBufferLength, [in] IPortableDeviceValues *pResults, [out] BYTE
            // *pBuffer, [out] DWORD *pdwBytesWritten );
            void WriteIPortableDeviceValuesToBuffer(uint dwOutputBufferLength, IPortableDeviceValues pResults, byte[] pBuffer, out uint pdwBytesWritten);

            /// <summary>
            /// The <c>GetBufferFromIPortableDeviceValues</c> method serializes a submitted <c>IPortableDeviceValues</c> interface to an
            /// allocated byte array. The byte array returned is allocated for the caller and should be freed by the caller using <c>CoTaskMemFree</c>.
            /// </summary>
            /// <param name="pSource">An <c>IPortableDeviceValues</c> interface to serialize.</param>
            /// <param name="ppBuffer">
            /// A <c>BYTE*</c> that contains the serialized data. Windows Portable Devices allocates this memory; the caller must free it by
            /// calling <c>CoTaskMemFree</c>.
            /// </param>
            /// <param name="pdwBufferSize">A <c>DWORD</c> that specifies the size of allocated buffer, in bytes.</param>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iwpdserializer-getbufferfromiportabledevicevalues HRESULT
            // GetBufferFromIPortableDeviceValues( [in] IPortableDeviceValues *pSource, [out] BYTE **ppBuffer, [out] DWORD *pdwBufferSize );
            void GetBufferFromIPortableDeviceValues(IPortableDeviceValues pSource, out SafeCoTaskMemHandle ppBuffer, out uint pdwBufferSize);

            /// <summary>
            /// The <c>GetSerializedSize</c> method calculates the buffer size that is required to hold a serialized
            /// <c>IPortableDeviceValues</c> interface.
            /// </summary>
            /// <param name="pSource">An <c>IPortableDeviceValues</c> interface whose size you want to request.</param>
            /// <returns>A <c>DWORD</c> that indicates the buffer size that is required to serialize pSource, in bytes.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iwpdserializer-getserializedsize HRESULT GetSerializedSize( [in]
            // IPortableDeviceValues *pSource, [out] DWORD *pdwSize );
            uint GetSerializedSize(IPortableDeviceValues pSource);
        }

        /// <summary>Enumerates the items in the collection.</summary>
        /// <param name="intf">The <see cref="IPortableDeviceKeyCollection"/> instance.</param>
        /// <returns>A sequence of <see cref="PROPERTYKEY"/> values from the collection.</returns>
        public static IEnumerable<PROPERTYKEY> Enumerate(this IPortableDeviceKeyCollection intf) =>
            new Vanara.Collections.IEnumFromIndexer<PROPERTYKEY>(intf.GetCount, intf.GetAt);

        /// <summary>Enumerates the items in the collection.</summary>
        /// <param name="intf">The <see cref="IPortableDevicePropVariantCollection"/> instance.</param>
        /// <returns>A sequence of <see cref="PROPVARIANT"/> values from the collection.</returns>
        public static IEnumerable<PROPVARIANT> Enumerate(this IPortableDevicePropVariantCollection intf) =>
            new Vanara.Collections.IEnumFromIndexer<PROPVARIANT>(intf.GetCount, i => { PROPVARIANT pv = new(); intf.GetAt(i, pv); return pv; });

        /// <summary>Enumerates the items in the collection.</summary>
        /// <param name="intf">The <see cref="IPortableDeviceValues"/> instance.</param>
        /// <returns>A sequence of <see cref="Tuple{PROPERTYKEY, PROPVARIANT}"/> values from the collection.</returns>
        public static IEnumerable<(PROPERTYKEY, PROPVARIANT)> Enumerate(this IPortableDeviceValues intf) =>
            new Vanara.Collections.IEnumFromIndexer<(PROPERTYKEY, PROPVARIANT)>(intf.GetCount, i => { PROPVARIANT pv = new(); intf.GetAt(i, out PROPERTYKEY pk, pv); return (pk, pv); });

        /// <summary>Enumerates the items in the collection.</summary>
        /// <param name="intf">The <see cref="IPortableDeviceValuesCollection"/> instance.</param>
        /// <returns>A sequence of <see cref="IPortableDeviceValues"/> values from the collection.</returns>
        public static IEnumerable<IPortableDeviceValues> Enumerate(this IPortableDeviceValuesCollection intf) =>
            new Vanara.Collections.IEnumFromIndexer<IPortableDeviceValues>(intf.GetCount, intf.GetAt);

        /// <summary>Gets the property key value from WPD_PROPERTY_COMMON_COMMAND_CATEGORY and WPD_PROPERTY_COMMON_COMMAND_ID.</summary>
        /// <param name="iValues">The IPortableDeviceValues instance.</param>
        /// <returns>The PROPERTYKEY.</returns>
        public static PROPERTYKEY GetCommandPKey(this IPortableDeviceValues iValues) =>
            new PROPERTYKEY(iValues.GetGuidValue(WPD_PROPERTY_COMMON_COMMAND_CATEGORY), iValues.GetUnsignedIntegerValue(WPD_PROPERTY_COMMON_COMMAND_ID));

        /// <summary>Sets the values corresponding to a command property key using WPD_PROPERTY_COMMON_COMMAND_CATEGORY and WPD_PROPERTY_COMMON_COMMAND_ID.</summary>
        /// <param name="iValues">The IPortableDeviceValues instance.</param>
        /// <param name="commandPropKey">The command property key.</param>
        public static void SetCommandPKey(this IPortableDeviceValues iValues, in PROPERTYKEY commandPropKey)
        {
            iValues.SetGuidValue(WPD_PROPERTY_COMMON_COMMAND_CATEGORY, commandPropKey.Key);
            iValues.SetUnsignedIntegerValue(WPD_PROPERTY_COMMON_COMMAND_ID, commandPropKey.Id);
        }

        /// <summary>PortableDeviceKeyCollection Class</summary>
        [PInvokeData("portabldevicetypes.h")]
        [ComImport, Guid("de2d022d-2480-43be-97f0-d1fa2cf98f4f"), ClassInterface(ClassInterfaceType.None)]
        public class PortableDeviceKeyCollection
        {
        }

        /// <summary>PortableDevicePropVariantCollection Class</summary>
        [PInvokeData("portabldevicetypes.h")]
        [ComImport, Guid("08a99e2f-6d6d-4b80-af5a-baf2bcbe4cb9"), ClassInterface(ClassInterfaceType.None)]
        public class PortableDevicePropVariantCollection
        {
        }

        /// <summary>PortableDeviceValues Class</summary>
        [PInvokeData("portabldevicetypes.h")]
        [ComImport, Guid("0c15d503-d017-47ce-9016-7b3f978721cc"), ClassInterface(ClassInterfaceType.None)]
        public class PortableDeviceValues
        {
        }

        /// <summary>PortableDeviceValuesCollection Class</summary>
        [PInvokeData("portabldevicetypes.h")]
        [ComImport, Guid("3882134d-14cf-4220-9cb4-435f86d83f60"), ClassInterface(ClassInterfaceType.None)]
        public class PortableDeviceValuesCollection
        {
        }

        /// <summary>WpdSerializer Class</summary>
        [PInvokeData("portabldevicetypes.h")]
        [ComImport, Guid("0b91a74b-ad7c-4a9d-b563-29eef9167172"), ClassInterface(ClassInterfaceType.None)]
        public class WpdSerializer
        {
        }
    }
}