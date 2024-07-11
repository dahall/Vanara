global using System.Collections.Generic;
global using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PortableDeviceApi;

namespace Vanara.PInvoke;

/// <summary>Items from the SensorsApi.dll.</summary>
public static partial class SensorsApi
{
	//private const string Lib_SensorsApi = "SensorsApi.dll";

	/// <summary>
	/// The <c>LOCATION_DESIRED_ACCURACY</c> enumeration type defines values for the SENSOR_PROPERTY_LOCATION_DESIRED_ACCURACY property.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/ne-sensorsapi-location_desired_accuracy typedef enum
	// LOCATION_DESIRED_ACCURACY { LOCATION_DESIRED_ACCURACY_DEFAULT = 0, LOCATION_DESIRED_ACCURACY_HIGH } ;
	[PInvokeData("sensorsapi.h", MSDNShortId = "NE:sensorsapi.LOCATION_DESIRED_ACCURACY")]
	public enum LOCATION_DESIRED_ACCURACY
	{
		/// <summary>Indicates that the sensor should use the accuracy for which it can optimize power and other such cost considerations.</summary>
		LOCATION_DESIRED_ACCURACY_DEFAULT,

		/// <summary>
		/// Indicates that the sensor should deliver the highest-accuracy report possible. This includes using services that might charge
		/// money, or consuming higher levels of battery power or connection bandwidth.
		/// </summary>
		LOCATION_DESIRED_ACCURACY_HIGH,
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("sensorsapi.h")]
	public enum LOCATION_POSITION_SOURCE
	{
		/// <summary/>
		LOCATION_POSITION_SOURCE_CELLULAR = 0,

		/// <summary/>
		LOCATION_POSITION_SOURCE_SATELLITE,

		/// <summary/>
		LOCATION_POSITION_SOURCE_WIFI,

		/// <summary/>
		LOCATION_POSITION_SOURCE_IPADDRESS,

		/// <summary/>
		LOCATION_POSITION_SOURCE_UNKNOWN
	}

	/// <summary>Specifies the accuracy of the magnetometer.</summary>
	/// <remarks>
	/// Apps that need calibration may periodically ask the user to calibrate the device. We suggest doing this no more than once every 10 minutes.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/ne-sensorsapi-magnetometeraccuracy typedef enum MagnetometerAccuracy {
	// MAGNETOMETER_ACCURACY_UNKNOWN = 0, MAGNETOMETER_ACCURACY_UNRELIABLE, MAGNETOMETER_ACCURACY_APPROXIMATE, MAGNETOMETER_ACCURACY_HIGH } ;
	[PInvokeData("sensorsapi.h", MSDNShortId = "NE:sensorsapi.MagnetometerAccuracy")]
	public enum MagnetometerAccuracy
	{
		/// <summary/>
		MAGNETOMETER_ACCURACY_UNKNOWN,

		/// <summary/>
		MAGNETOMETER_ACCURACY_UNRELIABLE,

		/// <summary/>
		MAGNETOMETER_ACCURACY_APPROXIMATE,

		/// <summary/>
		MAGNETOMETER_ACCURACY_HIGH,
	}

	/// <summary>Defines types of sensor device connections.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/ne-sensorsapi-sensorconnectiontype typedef enum
	// __MIDL___MIDL_itf_sensorsapi_0000_0000_0002 { SENSOR_CONNECTION_TYPE_PC_INTEGRATED = 0, SENSOR_CONNECTION_TYPE_PC_ATTACHED,
	// SENSOR_CONNECTION_TYPE_PC_EXTERNAL } SensorConnectionType;
	[PInvokeData("sensorsapi.h", MSDNShortId = "NE:sensorsapi.__MIDL___MIDL_itf_sensorsapi_0000_0000_0002")]
	public enum SensorConnectionType
	{
		/// <summary>The sensor device is built into the computer.</summary>
		SENSOR_CONNECTION_TYPE_PC_INTEGRATED,

		/// <summary>The sensor device is attached to the computer, such as through a peripheral device.</summary>
		SENSOR_CONNECTION_TYPE_PC_ATTACHED,

		/// <summary>The sensor device is connected by external means, such as through a network connection.</summary>
		SENSOR_CONNECTION_TYPE_PC_EXTERNAL,
	}

	/// <summary>Defines possible operational states for sensors.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/ne-sensorsapi-sensorstate typedef enum
	// __MIDL___MIDL_itf_sensorsapi_0000_0000_0001 { SENSOR_STATE_MIN = 0, SENSOR_STATE_READY, SENSOR_STATE_NOT_AVAILABLE,
	// SENSOR_STATE_NO_DATA, SENSOR_STATE_INITIALIZING, SENSOR_STATE_ACCESS_DENIED, SENSOR_STATE_ERROR, SENSOR_STATE_MAX } SensorState;
	[PInvokeData("sensorsapi.h", MSDNShortId = "NE:sensorsapi.__MIDL___MIDL_itf_sensorsapi_0000_0000_0001")]
	public enum SensorState
	{
		/// <summary>Minimum enumerated sensor state. Use SENSOR_STATE_READY instead.</summary>
		SENSOR_STATE_MIN = 0,

		/// <summary>Ready to send sensor data.</summary>
		SENSOR_STATE_READY = SENSOR_STATE_MIN,

		/// <summary>The sensor is not available for use.</summary>
		SENSOR_STATE_NOT_AVAILABLE,

		/// <summary>The sensor is available but does not have data.</summary>
		SENSOR_STATE_NO_DATA,

		/// <summary>The sensor is available, but performing initialization. Try again later.</summary>
		SENSOR_STATE_INITIALIZING,

		/// <summary>
		/// <para>
		/// The sensor is available, but the user account does not have permission to access the sensor data. For more information about
		/// permissions, see Managing User Permissions.
		/// </para>
		/// </summary>
		SENSOR_STATE_ACCESS_DENIED,

		/// <summary>The sensor has raised an error.</summary>
		SENSOR_STATE_ERROR,

		/// <summary>Maximum enumerated sensor state. Not a valid value.</summary>
		SENSOR_STATE_MAX = SENSOR_STATE_ERROR
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("sensorsapi.h")]
	public enum SimpleDeviceOrientation
	{
		/// <summary/>
		SIMPLE_DEVICE_ORIENTATION_NOT_ROTATED = 0,

		/// <summary/>
		SIMPLE_DEVICE_ORIENTATION_ROTATED_90,

		/// <summary/>
		SIMPLE_DEVICE_ORIENTATION_ROTATED_180,

		/// <summary/>
		SIMPLE_DEVICE_ORIENTATION_ROTATED_270,

		/// <summary/>
		SIMPLE_DEVICE_ORIENTATION_ROTATED_FACE_UP,

		/// <summary/>
		SIMPLE_DEVICE_ORIENTATION_ROTATED_FACE_DOWN
	}

	/// <summary>Provides the status of the system setting that allows users to change location settings.</summary>
	/// <remarks>
	/// <note><c>ILocationPermissions</c> is available in Windows 8.</note>
	/// <para>For more information on location settings in Windows 8 see Location settings.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nn-sensorsapi-ilocationpermissions
	[PInvokeData("sensorsapi.h", MSDNShortId = "NN:sensorsapi.ILocationPermissions")]
	[ComImport, Guid("D5FB0A7F-E74E-44f5-8E02-4806863A274F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ILocationPermissions
	{
		/// <summary>Gets the status of the system setting that allows users to change location settings.</summary>
		/// <returns><c>TRUE</c> if system settings allow users to enable or disable the location platform; otherwise, <c>FALSE</c>.</returns>
		/// <remarks>
		/// <para><c>Note</c><c>GetGlobalLocationPermission</c> is available in Windows 8.</para>
		/// <para>For more information on location settings in Windows 8 see Location settings.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-ilocationpermissions-getgloballocationpermission
		// HRESULT GetGlobalLocationPermission( [out] BOOL *pfEnabled );
		[return: MarshalAs(UnmanagedType.Bool)]
		public bool GetGlobalLocationPermission();

		/// <summary>Gets the location capability of the Windows Store app of the given thread</summary>
		/// <param name="dwClientThreadId">Thread Id of the app to check the location capability of</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded and the app is location enabled.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The app has not declared location capability or the user has declined or revoked location access.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ILLEGAL_METHOD_CALL</c></term>
		/// <term>An invalid client thread was provided.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <note><c>CheckLocationCapability</c> is available in Windows 8.</note>
		/// <para>For more information on location settings in Windows 8 see Location settings.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-ilocationpermissions-checklocationcapability HRESULT
		// CheckLocationCapability( DWORD dwClientThreadId );
		[PreserveSig]
		public HRESULT CheckLocationCapability(uint dwClientThreadId);
	}

	/// <summary>
	/// <para>Represents a sensor.</para>
	/// <para>
	/// You will generally retrieve a pointer to <c>ISensor</c> by calling ISensorCollection::GetAt or ISensorManager::GetSensorByID, but
	/// other methods can retrieve this pointer, too. Various other Sensor API methods use a pointer to <c>ISensor</c> to provide information
	/// about a particular sensor or to enable you to specify which sensor to use for a particular action.
	/// </para>
	/// <para>In addition to the methods inherited from <c>IUnknown</c>, the <c>ISensor</c> interface exposes the following methods.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nn-sensorsapi-isensor
	[PInvokeData("sensorsapi.h", MSDNShortId = "NN:sensorsapi.ISensor")]
	[ComImport, Guid("5FA08F80-2657-458E-AF75-46F73FA6AC5C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(Sensor))]
	public interface ISensor
	{
		/// <summary>Retrieves the unique identifier of the sensor.</summary>
		/// <returns>Address of a <c>SENSOR_ID</c> that receives the ID.</returns>
		/// <remarks>
		/// <para>
		/// A <c>SENSOR_ID</c> is a <c>GUID</c> that uniquely identifies the sensor on the current computer. This ID corresponds to the
		/// constant named SENSOR_PROPERTY_PERSISTENT_UNIQUE_ID.
		/// </para>
		/// <para>You can use an ID to retrieve a pointer to a particular sensor by calling ISensorManager::GetSensorByID.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-getid HRESULT GetID( [out] SENSOR_ID *pID );
		public Guid GetID();

		/// <summary>Retrieves the identifier of the sensor category.</summary>
		/// <returns>Address of a <c>SENSOR_CATEGORY_ID</c> that receives the sensor category ID.</returns>
		/// <remarks>A <c>SENSOR_CATEGORY_ID</c> is a <c>GUID</c> that uniquely identifies the sensor category.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-getcategory HRESULT GetCategory( [out]
		// SENSOR_CATEGORY_ID *pSensorCategory );
		public Guid GetCategory();

		/// <summary>Retrieves the sensor type ID.</summary>
		/// <returns>Address of a <c>SENSOR_TYPE_ID</c> that receives the sensor type ID.</returns>
		/// <remarks>
		/// Sensor types are more specific groupings than sensor categories. Sensor type IDs are <c>GUID</c> s that are defined in Sensors.h.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-gettype HRESULT GetType( [out] SENSOR_TYPE_ID
		// *pSensorType );
		public Guid GetType();

		/// <summary>Retrieves the sensor name that is intended to be seen by the user.</summary>
		/// <returns>Address of a <c>BSTR</c> that receives the friendly name.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-getfriendlyname HRESULT GetFriendlyName( [out]
		// BSTR *pFriendlyName );
		[return: MarshalAs(UnmanagedType.BStr)]
		public string? GetFriendlyName();

		/// <summary>Retrieves a property value.</summary>
		/// <param name="key"><c>REFPROPERTYKEY</c> specifying the property value to be retrieved.</param>
		/// <param name="pProperty"><c>PROPVARIANT</c> pointer that receives the property value.</param>
		/// <remarks>To retrieve multiple property values as a collection, call ISensor::GetProperties.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-getproperty
		// HRESULT GetProperty( [in] REFPROPERTYKEY key, [out] PROPVARIANT *pProperty );
		public void GetProperty(in PROPERTYKEY key, [Out] PROPVARIANT pProperty);

		/// <summary>Retrieves multiple sensor properties.</summary>
		/// <param name="pKeys">
		/// Pointer to an IPortableDeviceKeyCollection interface containing the <c>PROPERTYKEY</c> collection for the property values being
		/// requested. Set to <c>NULL</c> to retrieve all supported properties.
		/// </param>
		/// <returns>Address of an IPortableDeviceValues pointer that receives the pointer to the requested property values.</returns>
		/// <remarks>
		/// <para>
		/// This method enables you to retrieve the values of multiple properties, such as the sensor make, model, and serial number, by
		/// making a single call. To retrieve a single property, call ISensor::GetProperty.
		/// </para>
		/// <para>
		/// The <c>IPortableDeviceKeyCollection</c> and <c>IPortableDeviceValues</c> interfaces are defined by the Windows Portable Devices API.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example of how to retrieve properties from a sensor, see Setting and Retrieving Sensor Properties.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-getproperties HRESULT GetProperties( [in]
		// IPortableDeviceKeyCollection *pKeys, [out] IPortableDeviceValues **ppProperties );
		public IPortableDeviceValues GetProperties([In, Optional] IPortableDeviceKeyCollection? pKeys);

		/// <summary>Retrieves a set of <c>PROPERTYKEY</c> s that represent the data fields the sensor can provide.</summary>
		/// <returns>Address of the IPortableDeviceKeyCollection pointer that receives the list of supported data fields.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-getsupporteddatafields HRESULT
		// GetSupportedDataFields( [out] IPortableDeviceKeyCollection **ppDataFields );
		public IPortableDeviceKeyCollection GetSupportedDataFields();

		/// <summary>Specifies sensor properties.</summary>
		/// <param name="pProperties">Pointer to an IPortableDeviceValues interface containing the list of properties and values to set.</param>
		/// <param name="ppResults">
		/// Address of an <c>IPortableDeviceValues</c> interface that receives the list of properties that were successfully set. Each
		/// property has an associated <c>HRESULT</c> value, which indicates whether setting the property succeeded.
		/// </param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>S_FALSE</c></term>
		/// <term>
		/// The request to set one or more of the specified properties failed. Inspect <c>ppResults</c> to determine which properties, if
		/// any, succeeded.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>E_POINTER</c></term>
		/// <term>NULL was passed in for ppResults.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method enables you to specify the values of one or more properties, such as the sensor make, model, and serial number, by
		/// making a single call.
		/// </para>
		/// <para>Not all properties can be set.</para>
		/// <para><c>IPortableDeviceValues</c> is defined by the Windows Portable Devices API.</para>
		/// <para>Examples</para>
		/// <para>For an example of how to set properties, see Setting and Retrieving Sensor Properties.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-setproperties HRESULT SetProperties( [in]
		// IPortableDeviceValues *pProperties, [out] IPortableDeviceValues **ppResults );
		[PreserveSig]
		public HRESULT SetProperties(IPortableDeviceValues? pProperties, out IPortableDeviceValues? ppResults);

		/// <summary>Indicates whether the sensor supports the specified data field.</summary>
		/// <param name="key"><c>REFPROPERTYKEY</c> value specifying the data field to search for.</param>
		/// <returns>Address of a <c>VARIANT_BOOL</c> that receives a value indicating whether the sensor supports the data field.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-supportsdatafield HRESULT SupportsDataField(
		// [in] REFPROPERTYKEY key, [out] VARIANT_BOOL *pIsSupported );
		[return: MarshalAs(UnmanagedType.VariantBool)]
		public bool SupportsDataField(in PROPERTYKEY key);

		/// <summary>Retrieves the current operational state of the sensor.</summary>
		/// <returns>Address of a SensorState variable that receives the current state.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-getstate HRESULT GetState( [out] SensorState
		// *pState );
		public SensorState GetState();

		/// <summary>Retrieves the most recent sensor data report.</summary>
		/// <returns>Address of an ISensorDataReport pointer that receives the pointer to the most recent sensor data report.</returns>
		/// <remarks>
		/// <para>For location sensors, you can retrieve data only from sensors for which the user has granted permission.</para>
		/// <para>This method may return data before the driver has set the state to SENSOR_STATE_READY.</para>
		/// <para>Examples</para>
		/// <para>For an example of how to retrieve sensor data, see Retrieving Sensor Data Values.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-getdata HRESULT GetData( [out]
		// ISensorDataReport **ppDataReport );
		public ISensorDataReport GetData();

		/// <summary>Indicates whether the sensor supports the specified event.</summary>
		/// <param name="eventGuid"><c>REFGUID</c> value specifying the event to search for.</param>
		/// <returns>Address of a <c>VARIANT_BOOL</c> that receives a value indicating whether the sensor supports the event.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-supportsevent HRESULT SupportsEvent( [in]
		// REFGUID eventGuid, [out] VARIANT_BOOL *pIsSupported );
		[return: MarshalAs(UnmanagedType.VariantBool)]
		public bool SupportsEvent(in Guid eventGuid);

		/// <summary>Retrieves the current event interest settings.</summary>
		/// <param name="ppValues">Address of a <c>GUID</c> pointer that points to an array of sensor event identifiers.</param>
		/// <param name="pCount">The count of <c>GUID</c> s in the array pointed to by <c>ppValues</c>.</param>
		/// <remarks>
		/// Each sensor event is represented by a <c>GUID</c>. This method returns the list of requested events as an array of <c>GUID</c> s.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-geteventinterest HRESULT GetEventInterest(
		// [out] GUID **ppValues, [out] ULONG *pCount );
		public void GetEventInterest([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] out Guid[] ppValues, out uint pCount);

		/// <summary>Specifies the list of sensor events to receive.</summary>
		/// <param name="pValues">
		/// Pointer to an array of <c>GUID</c> s. Each <c>GUID</c> represents an event to receive. Set to <c>NULL</c> to receive all
		/// data-updated events and all custom events.
		/// </param>
		/// <param name="count">
		/// The count of <c>GUID</c> s in the array pointed to by <c>pValues</c>. Set to zero when <c>pValues</c> is <c>NULL</c>.
		/// </param>
		/// <remarks>
		/// <para>
		/// Each sensor event is represented by a <c>GUID</c>. This method takes, as an array of <c>GUID</c> s, the list of events that you
		/// want to receive.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example of how to set event interest, see Using Sensor API Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-seteventinterest HRESULT SetEventInterest(
		// [in] GUID *pValues, [in] ULONG count );
		public void SetEventInterest([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[]? pValues, uint count);

		/// <summary>Specifies the interface through which to receive sensor event notifications.</summary>
		/// <param name="pEvents">
		/// Pointer to the ISensorEvents callback interface that receives the event notifications. Set to <c>NULL</c> to cancel event notifications.
		/// </param>
		/// <remarks>
		/// <para>
		/// Specify the events to receive by calling SetEventInterest. You can retrieve the current event interest list by calling GetEventInterest.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example of how to set the event sink, see Using Sensor API Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-seteventsink HRESULT SetEventSink( [in]
		// ISensorEvents *pEvents );
		public void SetEventSink(ISensorEvents? pEvents);
	}

	/// <summary>
	/// <para>Represents a collection of sensors, such as all the sensors connected to a computer.</para>
	/// <para>
	/// Retrieve a pointer to <c>ISensorCollection</c> by calling methods of the ISensorManager interface. In addition to the methods
	/// inherited from <c>IUnknown</c>, the <c>ISensorCollection</c> interface exposes the following methods.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nn-sensorsapi-isensorcollection
	[PInvokeData("sensorsapi.h", MSDNShortId = "NN:sensorsapi.ISensorCollection")]
	[ComImport, Guid("23571E11-E545-4DD8-A337-B89BF44B10DF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SensorCollection))]
	public interface ISensorCollection
	{
		/// <summary>Retrieves the sensor at the specified index in the collection.</summary>
		/// <param name="ulIndex"><c>ULONG</c> containing the index of the sensor to retrieve.</param>
		/// <returns>Address of an ISensor pointer that receives the pointer to the specified sensor.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensorcollection-getat HRESULT GetAt( [in] ULONG
		// ulIndex, [out] ISensor **ppSensor );
		ISensor GetAt(uint ulIndex);

		/// <summary>Retrieves the count of sensors in the collection.</summary>
		/// <returns>Address of a <c>ULONG</c> that receives the count.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensorcollection-getcount HRESULT GetCount( [out]
		// ULONG *pCount );
		uint GetCount();

		/// <summary>Adds a sensor to the collection.</summary>
		/// <param name="pSensor">Pointer to the ISensor interface for the sensor to add to the collection.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensorcollection-add HRESULT Add( [in] ISensor
		// *pSensor );
		void Add(ISensor? pSensor);

		/// <summary>Removes a sensor from the collection. The sensor is specified by a pointer to the ISensor interface to be removed.</summary>
		/// <param name="pSensor">Pointer to the ISensor interface to remove from the collection.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensorcollection-remove HRESULT Remove( [in] ISensor
		// *pSensor );
		void Remove(ISensor? pSensor);

		/// <summary>Removes a sensor from the collection. The sensor to be removed is specified by its ID.</summary>
		/// <param name="sensorID">The <c>GUID</c> of the sensor to remove from the collection.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensorcollection-removebyid HRESULT RemoveByID( [in]
		// REFSENSOR_ID sensorID );
		void RemoveByID(in Guid sensorID);

		/// <summary>Empties the sensor collection.</summary>
		/// <remarks>
		/// This method calls <c>Release</c> on all sensor interface pointers in the collection and frees any memory used by the collection.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensorcollection-clear HRESULT Clear();
		void Clear();
	}

	/// <summary>
	/// <para>
	/// Represents a sensor data report. Sensor data reports contain data field values generated by a sensor and a time stamp that indicates
	/// when the data report was created.
	/// </para>
	/// <para>
	/// Retrieve a sensor data report asynchronously by subscribing to the ISensorEvents::OnDataUpdated event, or synchronously by calling
	/// ISensor::GetData. In addition to the methods inherited from <c>IUnknown</c>, the ISensorDataReport interface exposes the following methods.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nn-sensorsapi-isensordatareport
	[PInvokeData("sensorsapi.h", MSDNShortId = "NN:sensorsapi.ISensorDataReport")]
	[ComImport, Guid("0AB9DF9B-C4B5-4796-8898-0470706A2E1D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SensorDataReport))]
	public interface ISensorDataReport
	{
		/// <summary>Retrieves the time at which the data report was created.</summary>
		/// <returns>Address of a SYSTEMTIME variable that receives the time stamp.</returns>
		/// <remarks>Time stamps use Universal Coordinated Time (UTC).</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensordatareport-gettimestamp HRESULT GetTimestamp(
		// [out] SYSTEMTIME *pTimeStamp );
		public SYSTEMTIME GetTimestamp();

		/// <summary>Retrieves a single data field value from the data report.</summary>
		/// <param name="pKey"><c>REFPROPERTYKEY</c> indicating the data field to retrieve.</param>
		/// <param name="pValue">Address of a <c>PROPVARIANT</c> that receives the data field value.</param>
		/// <remarks>
		/// <para>Platform-defined data field <c>PROPERTYKEY</c>s are defined in Sensors.h.</para>
		/// <para>Examples</para>
		/// <para>For an example of how to retrieve a sensor data field value, see Retrieving Sensor Data Values.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensordatareport-getsensorvalue
		// HRESULT GetSensorValue( [in] REFPROPERTYKEY pKey, [out] PROPVARIANT *pValue );
		public void GetSensorValue(in PROPERTYKEY pKey, [Out] PROPVARIANT pValue);

		/// <summary>Retrieves a collection of data field values.</summary>
		/// <param name="pKeys">
		/// Pointer to the IPortableDeviceKeyCollection interface that contains the data fields for which to retrieve values. Set to
		/// <c>NULL</c> to retrieve values for all supported data fields.
		/// </param>
		/// <returns>Address of an IPortableDeviceValues interface pointer that receives the pointer to the retrieved values.</returns>
		/// <remarks>
		/// <para>
		/// The <c>IPortableDeviceKeyCollection</c> and <c>IPortableDeviceValues</c> interfaces are defined by the Windows Portable Devices API.
		/// </para>
		/// <para>
		/// When this method returns <c>HRESULT_FROM_WIN32(ERROR_NOT_FOUND)</c>, one or more of the results contained by the
		/// IPortableDeviceValues interface will be set to an <c>HRESULT</c> error value.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensordatareport-getsensorvalues HRESULT
		// GetSensorValues( [in] IPortableDeviceKeyCollection *pKeys, [out] IPortableDeviceValues **ppValues );
		public IPortableDeviceValues GetSensorValues(IPortableDeviceKeyCollection? pKeys);
	}

	/// <summary>
	/// <para>The callback interface you must implement if you want to receive sensor events.</para>
	/// <para>To subscribe to events for a particular sensor, call ISensor::SetEventSink.</para>
	/// <para>In addition to the methods inherited from <c>IUnknown</c>, the <c>ISensorEvents</c> interface exposes the following methods.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nn-sensorsapi-isensorevents
	[PInvokeData("sensorsapi.h", MSDNShortId = "NN:sensorsapi.ISensorEvents")]
	[ComImport, Guid("5D8DCC91-4641-47E7-B7C3-B74F48A6C391"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISensorEvents
	{
		/// <summary>Provides a notification that a sensor state has changed.</summary>
		/// <param name="pSensor">Pointer to the ISensor interface of the sensor that raised the event.</param>
		/// <param name="state">SensorState containing the new state.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensorevents-onstatechanged HRESULT OnStateChanged(
		// [in] ISensor *pSensor, [in] SensorState state );
		[PreserveSig]
		public HRESULT OnStateChanged(ISensor? pSensor, SensorState state);

		/// <summary>Provides sensor event data.</summary>
		/// <param name="pSensor">Pointer to the ISensor interface of the sensor that raised the event.</param>
		/// <param name="pNewData">Pointer to the ISensorDataReport interface that contains the event data.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensorevents-ondataupdated HRESULT OnDataUpdated(
		// [in] ISensor *pSensor, [in] ISensorDataReport *pNewData );
		[PreserveSig]
		public HRESULT OnDataUpdated(ISensor? pSensor, ISensorDataReport? pNewData);

		/// <summary>Provides custom event notifications.</summary>
		/// <param name="pSensor">Pointer to the ISensor interface that represents the sensor that raised the event.</param>
		/// <param name="eventID"><c>REFGUID</c> that identifies the event.</param>
		/// <param name="pEventData">Pointer to the IPortableDeviceValues interface that contains the event data.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// This callback method receives custom event notifications. Custom events are defined by sensor providers. Platform-defined event
		/// IDs are defined in Sensors.h.
		/// </para>
		/// <para>To receive new data from a sensor, use the OnDataUpdated Method.</para>
		/// <para>Examples</para>
		/// <para>For an example of how to receive sensor events, see Using Sensor API Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensorevents-onevent HRESULT OnEvent( [in] ISensor
		// *pSensor, [in] REFGUID eventID, [in] IPortableDeviceValues *pEventData );
		[PreserveSig]
		public HRESULT OnEvent(ISensor? pSensor, in Guid eventID, IPortableDeviceValues? pEventData);

		/// <summary>Provides notification that a sensor device is no longer connected.</summary>
		/// <param name="ID">The ID of the sensor.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>To know when a sensor enters, subscribe to the ISensorManagerEvents::OnSensorEnter event.</para>
		/// <para>Examples</para>
		/// <para>For an example of how to receive sensor events, see Using Sensor API Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensorevents-onleave HRESULT OnLeave( [in]
		// REFSENSOR_ID ID );
		[PreserveSig]
		public HRESULT OnLeave(in Guid ID);
	}

	/// <summary>Provides methods for discovering and retrieving available sensors and a method to request sensor manager events.</summary>
	/// <remarks>
	/// <para>
	/// You retrieve a pointer to this interface by calling the COM <c>CoCreateInstance</c> method. If group policy does not allow creation
	/// of this object, <c>CoCreateInstance</c> will return <c>HRESULT_FROM_WIN32 (ERROR_ACCESS_DISABLED_BY_POLICY)</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example code creates an instance of the sensor manager.</para>
	/// <para>
	/// <code>// Create the sensor manager. hr = CoCreateInstance(CLSID_SensorManager, NULL, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&amp;pSensorManager)); if(hr == HRESULT_FROM_WIN32(ERROR_ACCESS_DISABLED_BY_POLICY)) { // Unable to retrieve sensor manager due to // group policy settings. Alert the user. }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nn-sensorsapi-isensormanager
	[PInvokeData("sensorsapi.h", MSDNShortId = "NN:sensorsapi.ISensorManager")]
	[ComImport, Guid("BD77DB67-45A8-42DC-8D00-6DCF15F8377A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SensorManager))]
	public interface ISensorManager
	{
		/// <summary>Retrieves a collection containing all sensors associated with the specified category.</summary>
		/// <param name="sensorCategory">ID of the sensor category to retrieve.</param>
		/// <returns>Address of an ISensorCollection interface pointer that receives a pointer to the sensor collection requested.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensormanager-getsensorsbycategory HRESULT
		// GetSensorsByCategory( [in] REFSENSOR_CATEGORY_ID sensorCategory, [out] ISensorCollection **ppSensorsFound );
		public ISensorCollection GetSensorsByCategory(in Guid sensorCategory);

		/// <summary>Retrieves a collection containing all sensors associated with the specified type.</summary>
		/// <param name="sensorType">ID of the type of sensors to retrieve.</param>
		/// <returns>Address of an ISensorCollection interface pointer that receives the pointer to the sensor collection requested.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensormanager-getsensorsbytype HRESULT
		// GetSensorsByType( [in] REFSENSOR_TYPE_ID sensorType, [out] ISensorCollection **ppSensorsFound );
		public ISensorCollection GetSensorsByType(in Guid sensorType);

		/// <summary>Retrieves a pointer to the specified sensor.</summary>
		/// <param name="sensorID">The ID of the sensor to retrieve.</param>
		/// <returns>
		/// Address of an ISensor interface pointer that receives a pointer to the requested sensor. Will be <c>NULL</c> if the requested
		/// sensor cannot be found.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensormanager-getsensorbyid HRESULT GetSensorByID(
		// [in] REFSENSOR_ID sensorID, [out] ISensor **ppSensor );
		public ISensor GetSensorByID(in Guid sensorID);

		/// <summary>Specifies the interface through which to receive sensor manager event notifications.</summary>
		/// <param name="pEvents">
		/// Pointer to the ISensorManagerEvents callback interface that receives the event notifications. Set to <c>NULL</c> to stop
		/// receiving event notifications.
		/// </param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensormanager-seteventsink HRESULT SetEventSink( [in]
		// ISensorManagerEvents *pEvents );
		public void SetEventSink(ISensorManagerEvents? pEvents);

		/// <summary>Opens a system dialog box to request user permission to access sensor data.</summary>
		/// <param name="hParent">
		/// <para>
		/// For Windows 8, if <c>hParent</c> is provided a value, then the dialog will be modal to the parent window. If <c>hParent</c> is
		/// <c>NULL</c>, then the dialog will not be modal. The dialog is always synchronous.
		/// </para>
		/// <para>
		/// For Windows 7, <c>HWND</c> is handle to a window that can act as a parent to the permissions dialog box. Must be <c>NULL</c> if
		/// <c>fModal</c> is <c>TRUE</c>.
		/// </para>
		/// </param>
		/// <param name="pSensors">
		/// <para>For Windows 8, this value is not used.</para>
		/// <para>
		/// For Windows 7, <c>pSensors</c> is a pointer to the ISensorCollection interface that contains the list of sensors for which
		/// permission is being requested.
		/// </para>
		/// </param>
		/// <param name="fModal">
		/// <para>For Windows 8, this value is not used. Refer to <c>hParent</c> for control of modality.</para>
		/// <para>
		/// For Windows 7, <c>fModal</c> is a <c>BOOL</c> that specifies the dialog box mode. Must be <c>FALSE</c> if <c>hParent</c> is non-null.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>
		/// If <c>hParent</c> is <c>NULL</c>, the dialog box is modal and therefore has exclusive focus in Windows until the user responds.
		/// The call is synchronous. The return code indicates the user choice. See Return Value. If <c>hParent</c> is non-null, the call is
		/// asynchronous and the calling thread will not wait for the dialog box to be closed. The return code indicates whether the call
		/// succeeded. See Return Value.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>
		/// The dialog box is modeless. The call is asynchronous and the calling thread will not wait for the dialog box to be closed. The
		/// return code indicates whether the call succeeded. See Return Value. The <c>hParent</c> parameter is ignored.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>The following table describes return codes for synchronous results.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The user enabled the sensors.</term>
		/// </item>
		/// <item>
		/// <term><c>HRESULT_FROM_WIN32(ERROR_ACCESS_DENIED)</c></term>
		/// <term>The user chose to disable the sensors.</term>
		/// </item>
		/// <item>
		/// <term><c>HRESULT_FROM_WIN32(ERROR_CANCELLED)</c></term>
		/// <term>The user canceled the dialog box or refused elevation of permission to show the dialog box.</term>
		/// </item>
		/// </list>
		/// <para>The following table describes return codes for asynchronous results.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>All of the sensors in the sensor collection were displayed for the user to enable. The method succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>S_FALSE</c></term>
		/// <term>
		/// Some of the sensors in the sensor collection were displayed for the user to enable. Some sensors may have been removed from the
		/// collection; for example, because the user had previously chosen to keep them disabled. The method succeeded.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>An argument is not valid.</term>
		/// </item>
		/// <item>
		/// <term><c>E_POINTER</c></term>
		/// <term>A pointer is null.</term>
		/// </item>
		/// <item>
		/// <term><c>HRESULT_FROM_WIN32(ERROR_ACCESS_DENIED)</c></term>
		/// <term>All sensors in the sensor collection were previously disabled by the user. The dialog box was not shown.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Making a synchronous call from the user interface (UI) thread of a Windows application can block the UI thread and make the
		/// application less responsive. To prevent this, do not call this method from the UI thread with <c>fModal</c> set to <c>TRUE</c>.
		/// </para>
		/// <para><c>Note</c>
		/// <para></para>
		/// If an application or plugin that is running in protected mode, such as a Browser Helper Object (BHO) for Internet Explorer when
		/// Internet Explorer is running in protected mode, calls <c>RequestPermissions</c>, and the user chooses the <c>Don't enable this
		/// location sensor</c> option in the dialog box, Windows will display the dialog box again if <c>RequestPermissions</c> is called
		/// again by the same user. Applications that run in protected mode may choose to avoid calling <c>RequestPermissions</c> on startup
		/// so that the user will not be subjected to a possible unwanted dialog box each time the application starts.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example code requests permissions for all sensors retrieved from the sensor manager, by type, using an asynchronous
		/// method call. The platform will only prompt the user to enable sensors that are not already enabled. To determine whether the user
		/// enabled any sensors in this case, you must handle the ISensorEvents::OnStateChanged event. For additional examples that
		/// demonstrate how to request permissions, see Requesting User Permissions.
		/// </para>
		/// <para>
		/// <code>// Get the sensor collection. hr = pSensorManager-&gt;GetSensorsByType(SAMPLE_SENSOR_TYPE_TIME, &amp;pSensorColl); if(SUCCEEDED(hr)) { // Request permissions for all sensors // in the collection. hr = pSensorManager-&gt;RequestPermissions(0, pSensorColl, FALSE); }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensormanager-requestpermissions HRESULT
		// RequestPermissions( [in] HWND hParent, [in] ISensorCollection *pSensors, [in] BOOL fModal );
		[PreserveSig]
		public HRESULT RequestPermissions([In, Optional] HWND hParent, ISensorCollection? pSensors, [MarshalAs(UnmanagedType.Bool)] bool fModal);
	}

	/// <summary>
	/// <para>The callback interface for receiving sensor manager events.</para>
	/// <para>To receive event notifications, first call ISensorManager::SetEventSink.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nn-sensorsapi-isensormanagerevents
	[PInvokeData("sensorsapi.h", MSDNShortId = "NN:sensorsapi.ISensorManagerEvents")]
	[ComImport, Guid("9B3B0B86-266A-4AAD-B21F-FDE5501001B7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISensorManagerEvents
	{
		/// <summary>Provides notification when a sensor device is connected.</summary>
		/// <param name="pSensor">A pointer to the ISensor interface of the sensor that was connected.</param>
		/// <param name="state">SensorState indicating the current state of the sensor.</param>
		/// <returns>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The method succeeded.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>To know when a sensor is disconnected, subscribe to the ISensorEvents::OnLeave event.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensormanagerevents-onsensorenter HRESULT
		// OnSensorEnter( [in] ISensor *pSensor, [in] SensorState state );
		[PreserveSig]
		public HRESULT OnSensorEnter(ISensor? pSensor, SensorState state);
	}

	/// <summary>Enumerates each of the sensors in the collection.</summary>
	/// <param name="collection">The <see cref="ISensorCollection"/> instance.</param>
	/// <returns>A sequence of <see cref="ISensor"/> instances.</returns>
	public static IEnumerable<ISensor> Enumerate(this ISensorCollection collection)
	{
		for (uint i = 0; i < collection.GetCount(); i++)
			yield return collection.GetAt(i);
	}

	/// <summary>Retrieves a property value.</summary>
	/// <param name="s">The <see cref="ISensor"/> instance.</param>
	/// <param name="key"><c>REFPROPERTYKEY</c> specifying the property value to be retrieved.</param>
	/// <returns>The property value.</returns>
	/// <remarks>To retrieve multiple property values as a collection, call ISensor::GetProperties.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensor-getproperty
	// HRESULT GetProperty( [in] REFPROPERTYKEY key, [out] PROPVARIANT *pProperty );
	public static object? GetProperty(this ISensor s, in PROPERTYKEY key)
	{
		PROPVARIANT pv = new();
		s.GetProperty(key, pv);
		return pv.Value;
	}

	/// <summary>Retrieves a single data field value from the data report.</summary>
	/// <param name="r">The <see cref="ISensorDataReport"/> instance.</param>
	/// <param name="pKey"><c>REFPROPERTYKEY</c> indicating the data field to retrieve.</param>
	/// <returns>The data field value.</returns>
	/// <remarks>
	/// <para>Platform-defined data field <c>PROPERTYKEY</c>s are defined in Sensors.h.</para>
	/// <para>Examples</para>
	/// <para>For an example of how to retrieve a sensor data field value, see Retrieving Sensor Data Values.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/sensorsapi/nf-sensorsapi-isensordatareport-getsensorvalue
	// HRESULT GetSensorValue( [in] REFPROPERTYKEY pKey, [out] PROPVARIANT *pValue );
	public static object? GetSensorValue(this ISensorDataReport r, in PROPERTYKEY pKey)
	{
		PROPVARIANT pv = new();
		r.GetSensorValue(pKey, pv);
		return pv.Value;
	}

	/// <summary>CLSID_Sensor</summary>
	[ComImport, Guid("E97CED00-523A-4133-BF6F-D3A2DAE7F6BA"), ClassInterface(ClassInterfaceType.None)]
	public class Sensor { };

	/// <summary>CLSID_SensorCollection</summary>
	[ComImport, Guid("79C43ADB-A429-469F-AA39-2F2B74B75937"), ClassInterface(ClassInterfaceType.None)]
	public class SensorCollection { };

	/// <summary>CLSID_SensorDataReport</summary>
	[ComImport, Guid("4EA9D6EF-694B-4218-8816-CCDA8DA74BBA"), ClassInterface(ClassInterfaceType.None)]
	public class SensorDataReport { };

	/// <summary>CLSID_SensorManager</summary>
	[ComImport, Guid("77A1C827-FCD2-4689-8915-9D613CC5FA3E"), ClassInterface(ClassInterfaceType.None)]
	public class SensorManager { };
}