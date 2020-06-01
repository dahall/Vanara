using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke
{
	public static partial class PropSys
	{
		/// <summary>
		/// Provides a set of flags to be used with following methods to indicate the operation in ICondition::GetComparisonInfo,
		/// ICondition2::GetLeafConditionInfo, IConditionFactory::MakeLeaf, IConditionFactory2::CreateBooleanLeaf,
		/// IConditionFactory2::CreateIntegerLeaf, IConditionFactory2::MakeLeaf, IConditionFactory2::CreateStringLeaf, and IConditionGenerator::GenerateForLeaf.
		/// </summary>
		[PInvokeData("Propsys.h", MSDNShortId = "aa965691")]
		public enum CONDITION_OPERATION
		{
			/// <summary>
			/// An implicit comparison between the value of the property and the value of the constant. For an unresolved condition,
			/// COP_IMPLICIT means that a user did not type an operation. In contrast, a resolved condition will always have a condition
			/// other than the COP_IMPLICIT operation.
			/// </summary>
			COP_IMPLICIT = 0,

			/// <summary>The value of the property and the value of the constant must be equal.</summary>
			COP_EQUAL = 1,

			/// <summary>The value of the property and the value of the constant must not be equal.</summary>
			COP_NOTEQUAL = 2,

			/// <summary>The value of the property must be less than the value of the constant.</summary>
			COP_LESSTHAN = 3,

			/// <summary>The value of the property must be greater than the value of the constant.</summary>
			COP_GREATERTHAN = 4,

			/// <summary>The value of the property must be less than or equal to the value of the constant.</summary>
			COP_LESSTHANOREQUAL = 5,

			/// <summary>The value of the property must be greater than or equal to the value of the constant.</summary>
			COP_GREATERTHANOREQUAL = 6,

			/// <summary>The value of the property must begin with the value of the constant.</summary>
			COP_VALUE_STARTSWITH = 7,

			/// <summary>The value of the property must end with the value of the constant.</summary>
			COP_VALUE_ENDSWITH = 8,

			/// <summary>The value of the property must contain the value of the constant.</summary>
			COP_VALUE_CONTAINS = 9,

			/// <summary>The value of the property must not contain the value of the constant.</summary>
			COP_VALUE_NOTCONTAINS = 10,

			/// <summary>
			/// The value of the property must match the value of the constant, where '?' matches any single character and '*' matches any
			/// sequence of characters.
			/// </summary>
			COP_DOSWILDCARDS = 11,

			/// <summary>The value of the property must contain a word that is the value of the constant.</summary>
			COP_WORD_EQUAL = 12,

			/// <summary>The value of the property must contain a word that begins with the value of the constant.</summary>
			COP_WORD_STARTSWITH = 13,

			/// <summary>The application is free to interpret this in any suitable way.</summary>
			COP_APPLICATION_SPECIFIC = 14
		}

		/// <summary>
		/// Describes how property values are displayed when multiple items are selected. For a particular property,
		/// PROPDESC_AGGREGATION_TYPE describes how the property should be displayed when multiple items that have a value for the property
		/// are selected, such as whether the values should be summed, or averaged, or just displayed with the default "Multiple Values" string.
		/// </summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762522")]
		public enum PROPDESC_AGGREGATION_TYPE
		{
			/// <summary>Display the string "Multiple Values".</summary>
			PDAT_DEFAULT = 0,

			/// <summary>Display the first value in the selection.</summary>
			PDAT_FIRST = 1,

			/// <summary>Display the sum of the selected values. This flag is never returned for data types VT_LPWSTR, VT_BOOL, and VT_FILETIME.</summary>
			PDAT_SUM = 2,

			/// <summary>
			/// Display the numerical average of the selected values. This flag is never returned for data types VT_LPWSTR, VT_BOOL, and VT_FILETIME.
			/// </summary>
			PDAT_AVERAGE = 3,

			/// <summary>
			/// Display the date range of the selected values. This flag is returned only for values of the VT_FILETIME data type.
			/// </summary>
			PDAT_DATERANGE = 4,

			/// <summary>
			/// Display a concatenated string of all the values. The order of individual values in the string is undefined. The concatenated
			/// string omits duplicate values; if a value occurs more than once, it appears only once in the concatenated string.
			/// </summary>
			PDAT_UNION = 5,

			/// <summary>Display the highest of the selected values.</summary>
			PDAT_MAX = 6,

			/// <summary>Display the lowest of the selected values.</summary>
			PDAT_MIN = 7
		}

		/// <summary>
		/// Describes the condition type to use when displaying the property in the query builder UI in Windows Vista, but not in Windows 7
		/// and later.
		/// </summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762523")]
		public enum PROPDESC_CONDITION_TYPE
		{
			/// <summary>The default value; it means the condition type is unspecified.</summary>
			PDCOT_NONE = 0,

			/// <summary>Use the string condition type.</summary>
			PDCOT_STRING = 1,

			/// <summary>Use the size condition type.</summary>
			PDCOT_SIZE = 2,

			/// <summary>Use the date/time condition type.</summary>
			PDCOT_DATETIME = 3,

			/// <summary>Use the Boolean condition type.</summary>
			PDCOT_BOOLEAN = 4,

			/// <summary>Use the number condition type.</summary>
			PDCOT_NUMBER = 5
		}

		/// <summary>A value that indicates the display type.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb761535")]
		public enum PROPDESC_DISPLAYTYPE
		{
			/// <summary>The value is displayed as a string.</summary>
			PDDT_STRING = 0,

			/// <summary>The value is displayed as an integer.</summary>
			PDDT_NUMBER = 1,

			/// <summary>The value is displayed as a Boolean value.</summary>
			PDDT_BOOLEAN = 2,

			/// <summary>The value is displayed as date and time.</summary>
			PDDT_DATETIME = 3,

			/// <summary>
			/// The value is displayed as an enumerated type-list. Use IPropertyDescription::GetEnumTypeList to handle this type.
			/// </summary>
			PDDT_ENUMERATED = 4
		}

		/// <summary>Describes the filtered list of property descriptions that is returned.</summary>
		public enum PROPDESC_ENUMFILTER
		{
			/// <summary>The list contains all property descriptions in the system.</summary>
			PDEF_ALL = 0,        // All properties in system

			/// <summary>
			/// The list contains system property descriptions only. It excludes third-party property descriptions that are registered on
			/// the computer.
			/// </summary>
			PDEF_SYSTEM = 1,        // Only system properties

			/// <summary>The list contains only third-party property descriptions that are registered on the computer.</summary>
			PDEF_NONSYSTEM = 2,        // Only non-system properties

			/// <summary>The list contains only viewable properties, where &lt;typeInfo isViewable="true"&gt;.</summary>
			PDEF_VIEWABLE = 3,        // Only viewable properties

			/// <summary>
			/// Deprecated in Windows 7 and later. The list contains only queryable properties, where &lt;typeInfo isViewable="true" isQueryable="true"&gt;.
			/// </summary>
			PDEF_QUERYABLE = 4,        // Deprecated

			/// <summary>Deprecated in Windows 7 and later. The list contains only properties to be included in full-text queries.</summary>
			PDEF_INFULLTEXTQUERY = 5,        // Deprecated

			/// <summary>The list contains only properties that are columns.</summary>
			PDEF_COLUMN = 6,        // Only properties that are columns
		}

		/// <summary>
		/// Used by property description helper functions, such as PSFormatForDisplay, to indicate the format of a property string.
		/// </summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762525")]
		[Flags]
		public enum PROPDESC_FORMAT_FLAGS
		{
			/// <summary>Use the format settings specified in the property's .propdesc file.</summary>
			PDFF_DEFAULT = 0,

			/// <summary>
			/// Precede the value with the property's display name. If the hideLabelPrefix attribute of the labelInfo element in the
			/// property's .propinfo file is set to true, then this flag is ignored.
			/// </summary>
			PDFF_PREFIXNAME = 0x1,

			/// <summary>Treat the string as a file name.</summary>
			PDFF_FILENAME = 0x2,

			/// <summary>
			/// Byte sizes are always displayed in KB, regardless of size. This enables clean alignment of the values in the column. This
			/// flag applies only to properties that have been declared as type Integer in the displayType attribute of the displayInfo
			/// element in the property's .propinfo file. This flag overrides the numberFormat setting.
			/// </summary>
			PDFF_ALWAYSKB = 0x4,

			/// <summary>Reserved.</summary>
			PDFF_RESERVED_RIGHTTOLEFT = 0x8,

			/// <summary>Display time as "hh:mm am/pm".</summary>
			PDFF_SHORTTIME = 0x10,

			/// <summary>Display time as "hh:mm:ss am/pm".</summary>
			PDFF_LONGTIME = 0x20,

			/// <summary>Hide the time portion of datetime.</summary>
			PDFF_HIDETIME = 0x40,

			/// <summary>Display date as "MM/DD/YY". For example, "03/21/04".</summary>
			PDFF_SHORTDATE = 0x80,

			/// <summary>Display date as "DayOfWeek, Month day, year". For example, "Monday, March 21, 2009".</summary>
			PDFF_LONGDATE = 0x100,

			/// <summary>Hide the date portion of datetime.</summary>
			PDFF_HIDEDATE = 0x200,

			/// <summary>Use friendly date descriptions. For example, "Yesterday".</summary>
			PDFF_RELATIVEDATE = 0x400,

			/// <summary>
			/// Return the invitation text if formatting failed or the value was empty. Invitation text is text displayed in a text box as a
			/// cue for the user, such as "Enter your name". Formatting can fail if the data entered is not of an expected type, such as
			/// when alpha characters have been entered in a phone-number field.
			/// </summary>
			PDFF_USEEDITINVITATION = 0x800,

			/// <summary>
			/// If this flag is used, the PDFF_USEEDITINVITATION flag must also be specified. When the formatting flags are PDFF_READONLY |
			/// PDFF_USEEDITINVITATION and the algorithm would have shown invitation text, a string is returned that indicates the value is
			/// "Unknown" instead of returning the invitation text.
			/// </summary>
			PDFF_READONLY = 0x1000,

			/// <summary>
			/// Do not detect reading order automatically. Useful when converting to ANSI to omit the Unicode reading order characters.
			/// However, reading order characters for some values are still returned.
			/// </summary>
			PDFF_NOAUTOREADINGORDER = 0x2000
		}

		/// <summary>A flag value that indicates the grouping type.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb761542")]
		public enum PROPDESC_GROUPING_RANGE
		{
			/// <summary>Displays individual values.</summary>
			PDGR_DISCRETE = 0,

			/// <summary>Displays static alphanumeric ranges.</summary>
			PDGR_ALPHANUMERIC = 1,

			/// <summary>Displays static size ranges.</summary>
			PDGR_SIZE = 2,

			/// <summary>Displays dynamically created ranges.</summary>
			PDGR_DYNAMIC = 3,

			/// <summary>Displays month and year groups.</summary>
			PDGR_DATE = 4,

			/// <summary>Displays percent groups.</summary>
			PDGR_PERCENT = 5,

			/// <summary>Displays percent groups returned by IPropertyDescription::GetEnumTypeList.</summary>
			PDGR_ENUMERATED = 6
		}

		/// <summary>
		/// Describes the relative description type for a property description, as determined by the relativeDescriptionType attribute of
		/// the displayInfo element.
		/// </summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762526")]
		public enum PROPDESC_RELATIVEDESCRIPTION_TYPE
		{
			/// <summary>General type.</summary>
			PDRDT_GENERAL = 0,

			/// <summary>Date type.</summary>
			PDRDT_DATE = 1,

			/// <summary>Size type.</summary>
			PDRDT_SIZE = 2,

			/// <summary>Count type.</summary>
			PDRDT_COUNT = 3,

			/// <summary>Revision type.</summary>
			PDRDT_REVISION = 4,

			/// <summary>Length type.</summary>
			PDRDT_LENGTH = 5,

			/// <summary>Duration type.</summary>
			PDRDT_DURATION = 6,

			/// <summary>Speed type.</summary>
			PDRDT_SPEED = 7,

			/// <summary>Rate type.</summary>
			PDRDT_RATE = 8,

			/// <summary>Rating type.</summary>
			PDRDT_RATING = 9,

			/// <summary>Priority type.</summary>
			PDRDT_PRIORITY = 10
		}

		/// <summary>Indicate the sort types available to the user.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb761551")]
		public enum PROPDESC_SORTDESCRIPTION
		{
			/// <summary>Default. "Sort going up", "Sort going down"</summary>
			PDSD_GENERAL = 0,

			/// <summary>"A on top", "Z on top"</summary>
			PDSD_A_Z = 1,

			/// <summary>"Lowest on top", "Highest on top"</summary>
			PDSD_LOWEST_HIGHEST = 2,

			/// <summary>"Smallest on top", "Largest on top"</summary>
			PDSD_SMALLEST_BIGGEST = 3,

			/// <summary>"Oldest on top", "Newest on top"</summary>
			PDSD_OLDEST_NEWEST = 4
		}

		/// <summary>Describes attributes of the typeInfo element in the property's .propdesc file.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762527")]
		[Flags]
		public enum PROPDESC_TYPE_FLAGS : uint
		{
			/// <summary>The property uses the default values for all attributes.</summary>
			PDTF_DEFAULT = 0,

			/// <summary>
			/// The property can have multiple values. These values are stored as a VT_VECTOR in the PROPVARIANT structure. This value is
			/// set by the multipleValues attribute of the typeInfo element in the property's .propdesc file.
			/// </summary>
			PDTF_MULTIPLEVALUES = 0x1,

			/// <summary>
			/// This flag indicates that a property is read-only, and cannot be written to. This value is set by the isInnate attribute of
			/// the typeInfo element in the property's .propdesc file.
			/// </summary>
			PDTF_ISINNATE = 0x2,

			/// <summary>
			/// The property is a group heading. This value is set by the isGroup attribute of the typeInfo element in the property's
			/// .propdesc file.
			/// </summary>
			PDTF_ISGROUP = 0x4,

			/// <summary>
			/// The user can group by this property. This value is set by the canGroupBy attribute of the typeInfo element in the property's
			/// .propdesc file.
			/// </summary>
			PDTF_CANGROUPBY = 0x8,

			/// <summary>
			/// The user can stack by this property. This value is set by the canStackBy attribute of the typeInfo element in the property's
			/// .propdesc file.
			/// </summary>
			PDTF_CANSTACKBY = 0x10,

			/// <summary>
			/// This property contains a hierarchy. This value is set by the isTreeProperty attribute of the typeInfo element in the
			/// property's .propdesc file.
			/// </summary>
			PDTF_ISTREEPROPERTY = 0x20,

			/// <summary>
			/// Deprecated in Windows 7 and later. Include this property in any full text query that is performed. This value is set by the
			/// includeInFullTextQuery attribute of the typeInfo element in the property's .propdesc file.
			/// </summary>
			PDTF_INCLUDEINFULLTEXTQUERY = 0x40,

			/// <summary>
			/// This property is meant to be viewed by the user. This influences whether the property shows up in the "Choose Columns"
			/// dialog box, for example. This value is set by the isViewable attribute of the typeInfo element in the property's .propdesc file.
			/// </summary>
			PDTF_ISVIEWABLE = 0x80,

			/// <summary>
			/// Deprecated in Windows 7 and later. This property is included in the list of properties that can be queried. A queryable
			/// property must also be viewable. This influences whether the property shows up in the query builder UI. This value is set by
			/// the isQueryable attribute of the typeInfo element in the property's .propdesc file.
			/// </summary>
			PDTF_ISQUERYABLE = 0x100,

			/// <summary>
			/// Windows Vista with Service Pack 1 (SP1) and later. Used with an innate property (that is, a value calculated from other
			/// property values) to indicate that it can be deleted. This value is used by the Remove Properties UI to determine whether to
			/// display a check box next to a property that enables that property to be selected for removal. Note that a property that is
			/// not innate can always be purged regardless of the presence or absence of this flag.
			/// </summary>
			PDTF_CANBEPURGED = 0x200,

			/// <summary>Windows 7 and later. The unformatted (raw) property value should be used for searching.</summary>
			PDTF_SEARCHRAWVALUE = 0x400,

			/// <summary/>
			PDTF_DONTCOERCEEMPTYSTRINGS = 0x800,

			/// <summary/>
			PDTF_ALWAYSINSUPPLEMENTALSTORE = 0x1000,

			/// <summary>This property is owned by the system.</summary>
			PDTF_ISSYSTEMPROPERTY = 0x80000000,

			/// <summary>A mask used to retrieve all flags.</summary>
			PDTF_MASK_ALL = 0x80001fff
		}

		/// <summary>These flags describe properties in property description list strings.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762528")]
		[Flags]
		public enum PROPDESC_VIEW_FLAGS
		{
			/// <summary>Show this property by default.</summary>
			PDVF_DEFAULT = 0,

			/// <summary>This property should be centered.</summary>
			PDVF_CENTERALIGN = 0x1,

			/// <summary>This property should be right aligned.</summary>
			PDVF_RIGHTALIGN = 0x2,

			/// <summary>Show this property as the beginning of the next collection of properties in the view.</summary>
			PDVF_BEGINNEWGROUP = 0x4,

			/// <summary>Fill the remainder of the view area with the content of this property.</summary>
			PDVF_FILLAREA = 0x8,

			/// <summary>Sort this property in reverse (descending) order. Applies to a property in a list of sorted properties.</summary>
			PDVF_SORTDESCENDING = 0x10,

			/// <summary>Show this property only if it is present.</summary>
			PDVF_SHOWONLYIFPRESENT = 0x20,

			/// <summary>This property should be shown by default in a view (where applicable).</summary>
			PDVF_SHOWBYDEFAULT = 0x40,

			/// <summary>This property should be shown by default in the primary column selection UI.</summary>
			PDVF_SHOWINPRIMARYLIST = 0x80,

			/// <summary>This property should be shown by default in the secondary column selection UI.</summary>
			PDVF_SHOWINSECONDARYLIST = 0x100,

			/// <summary>Hide the label of this property if the view normally shows the label.</summary>
			PDVF_HIDELABEL = 0x200,

			/// <summary>This property should not be displayed as a column in the UI.</summary>
			PDVF_HIDDEN = 0x800,

			/// <summary>This property can be wrapped to the next row.</summary>
			PDVF_CANWRAP = 0x1000,

			/// <summary>A mask used to retrieve all flags.</summary>
			PDVF_MASK_ALL = 0x1bff
		}

		/// <summary>Property Enumeration Types</summary>
		public enum PROPENUMTYPE
		{
			/// <summary>Use DisplayText and either RangeMinValue or RangeSetValue.</summary>
			PET_DISCRETEVALUE = 0,

			/// <summary>Use DisplayText and either RangeMinValue or RangeSetValue</summary>
			PET_RANGEDVALUE = 1,

			/// <summary>Use DisplayText</summary>
			PET_DEFAULTVALUE = 2,

			/// <summary>Use Value or RangeMinValue</summary>
			PET_ENDRANGE = 3
		}

		/// <summary>Values used by <see cref="IDelayedPropertyStoreFactory.GetDelayedPropertyStore"/>.</summary>
		[PInvokeData("propsys.h", MSDNShortId = "855c9f10-9f40-4c60-a669-551fa51133f5")]
		public enum STOREID
		{
			/// <summary>Undocumented.</summary>
			STOREID_INNATE = 0,

			/// <summary>Undocumented.</summary>
			STOREID_FILE = 1,

			/// <summary>Undocumented.</summary>
			STOREID_FALLBACK = 2
		}

		/// <summary>Exposes a method that creates an object of a specified class.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nn-propsys-icreateobject
		[PInvokeData("propsys.h", MSDNShortId = "90502b4a-dc0a-4077-83d7-e9f5445ba69b")]
		[ComImport, Guid("75121952-e0d0-43e5-9380-1d80483acf72"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ICreateObject
		{
			/// <summary>
			/// <para>Creates a local object of a specified class and returns a pointer to a specified interface on the object.</para>
			/// </summary>
			/// <param name="clsid">
			/// <para>Type: <c>REFCLSID</c></para>
			/// <para>A reference to a CLSID.</para>
			/// </param>
			/// <param name="pUnkOuter">
			/// <para>Type: <c>IUnknown*</c></para>
			/// <para>
			/// A pointer to the IUnknown interface that aggregates the object created by this function, or <c>NULL</c> if no aggregation is desired.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to the IID of the interface the created object should return.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>When this method returns, contains the address of the pointer to the interface requested in riid.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>This method can be used with GetPropertyStoreWithCreateObject.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-icreateobject-createobject HRESULT CreateObject(
			// REFCLSID clsid, IUnknown *pUnkOuter, REFIID riid, void **ppv );
			[PInvokeData("propsys.h", MSDNShortId = "72c56de7-4c04-4bcf-b6bb-6e41d12b68a3")]
			void CreateObject(in Guid clsid, [MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter, in Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppv);
		}

		/// <summary>
		/// Exposes a method to create a specified IPropertyStore object in circumstances where property access is potentially slow.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.PropSys.IPropertyStoreFactory"/>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nn-propsys-idelayedpropertystorefactory
		[PInvokeData("propsys.h", MSDNShortId = "855c9f10-9f40-4c60-a669-551fa51133f5")]
		[ComImport, Guid("40d4577f-e237-4bdb-bd69-58f089431b6a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IDelayedPropertyStoreFactory : IPropertyStoreFactory
		{
			/// <summary>
			/// <para>Gets an IPropertyStore object that corresponds to the supplied flags.</para>
			/// </summary>
			/// <param name="flags">
			/// <para>Type: <c>GETPROPERTYSTOREFLAGS</c></para>
			/// <para>GETPROPERTYSTOREFLAGS values that modify the store that is returned.</para>
			/// </param>
			/// <param name="pUnkFactory">
			/// <para>Type: <c>IUnknown*</c></para>
			/// <para>
			/// Optional. A pointer to the IUnknown of an object that implements ICreateObject. If pUnkFactory is provided, this method can
			/// create the handler instance using <c>ICreateObject</c> rather than CoCreateInstance, if implemented. The reason to provide
			/// pUnkFactory is usually to create the handler in a different process. However, for most users, passing <c>NULL</c> in this
			/// parameter is sufficient.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to IID of the object to create.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>When this method returns, contains the address of an IPropertyStore interface pointer.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// It is recommended that you use the IID_PPV_ARGS macro, defined in Objbase.h, to package the riid and ppv parameters. This
			/// macro provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a
			/// coding error.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-ipropertystorefactory-getpropertystore HRESULT
			// GetPropertyStore( GETPROPERTYSTOREFLAGS flags, IUnknown *pUnkFactory, REFIID riid, void **ppv );
			new void GetPropertyStore(GETPROPERTYSTOREFLAGS flags, [Optional, MarshalAs(UnmanagedType.IUnknown)] ICreateObject pUnkFactory, in Guid riid, out IPropertyStore ppv);

			/// <summary>
			/// <para>
			/// Gets an IPropertyStore object, given a set of property keys. This provides an alternative, possibly faster, method of
			/// getting an <c>IPropertyStore</c> object compared to calling IPropertyStoreFactory::GetPropertyStore.
			/// </para>
			/// </summary>
			/// <param name="rgKeys">
			/// <para>Type: <c>const PROPERTYKEY*</c></para>
			/// <para>A pointer to an array of PROPERTYKEY structures.</para>
			/// </param>
			/// <param name="cKeys">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of PROPERTYKEY structures in the array pointed to by rgKeys.</para>
			/// </param>
			/// <param name="flags">
			/// <para>Type: <c>GETPROPERTYSTOREFLAGS</c></para>
			/// <para>GETPROPERTYSTOREFLAGS values that modify the store that is returned.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to IID of the object to create.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>When this method returns, contains the address of an IPropertyStore interface pointer.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// It is recommended that you use the IID_PPV_ARGS macro, defined in Objbase.h, to package the riid and ppv parameters. This
			/// macro provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a
			/// coding error.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-ipropertystorefactory-getpropertystoreforkeys HRESULT
			// GetPropertyStoreForKeys( const PROPERTYKEY *rgKeys, UINT cKeys, GETPROPERTYSTOREFLAGS flags, REFIID riid, void **ppv );
			new void GetPropertyStoreForKeys([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] PROPERTYKEY[] rgKeys, uint cKeys, GETPROPERTYSTOREFLAGS flags,
				in Guid riid, out IPropertyStore ppv);

			/// <summary>
			/// <para>Gets an IPropertyStore interface object, as specified.</para>
			/// </summary>
			/// <param name="flags">
			/// <para>Type: <c>GETPROPERTYSTOREFLAGS</c></para>
			/// <para>The GPS_XXX flags that modify the store that is returned. See GETPROPERTYSTOREFLAGS.</para>
			/// </param>
			/// <param name="dwStoreId">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The property store ID. Valid values are.</para>
			/// <para>STOREID_INNATE</para>
			/// <para>Value is 0.</para>
			/// <para>STOREID_FILE</para>
			/// <para>Value is 1.</para>
			/// <para>STOREID_FALLBACK</para>
			/// <para>Value is 2.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to the desired IID.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>The address of an IPropertyStore interface pointer.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-idelayedpropertystorefactory-getdelayedpropertystore
			// HRESULT GetDelayedPropertyStore( GETPROPERTYSTOREFLAGS flags, DWORD dwStoreId, REFIID riid, void **ppv );
			void GetDelayedPropertyStore(GETPROPERTYSTOREFLAGS flags, STOREID dwStoreId, in Guid riid, out IPropertyStore ppv);
		}

		/// <summary>
		/// Exposes a method that initializes a handler, such as a property handler, thumbnail handler, or preview handler, with a stream.
		/// </summary>
		[ComImport, Guid("b824b49d-22ac-4161-ac8a-9916e8fa3f7f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h", MSDNShortId = "bb761810")]
		public interface IInitializeWithStream
		{
			/// <summary>Initializes a handler with a stream.</summary>
			/// <param name="pstream">A pointer to an IStream interface that represents the stream source.</param>
			/// <param name="grfMode">One of the following STGM values that indicates the access mode for pstream. STGM_READ or STGM_READWRITE.</param>
			void Initialize(IStream pstream, STGM grfMode);
		}

		/// <summary>
		/// Exposes methods to persist serialized property storage data for later use and to restore persisted data to a new property store instance.
		/// </summary>
		/// <remarks>
		/// <para>Use the IPropertyStore interface to read and write values from and to the property store.</para>
		/// <para>When to Use</para>
		/// <para>
		/// The in-memory property store, created by calling PSCreateMemoryPropertyStore, provides an implementation of this interface. Use
		/// this implementation when you want to persist or restore serialized property storage data.
		/// </para>
		/// <para>When to Implement</para>
		/// <para>
		/// <c>IPersistSerializedPropStorage</c> is not intended for custom implementation. Use the system-provided implementation
		/// associated with the in-memory property store.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nn-propsys-ipersistserializedpropstorage
		[ComImport, Guid("e318ad57-0aa0-450f-aca5-6fab7103d917"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IPersistSerializedPropStorage
		{
			/// <summary>Toggles the property store object between the read-only and read/write state.</summary>
			/// <param name="flags">
			/// <para>Type: <c>PERSIST_SPROPSTORE_FLAGS</c></para>
			/// <para>The flags parameter takes one of the following values to set options for the behavior of the property storage:</para>
			/// <para>FPSPS_DEFAULT (0x00000000)</para>
			/// <para><c>Windows 7 and later</c>. The property store object is read/write.</para>
			/// <para>FPSPS_READONLY (0x00000001)</para>
			/// <para>The property store object is read-only.</para>
			/// <para>FPSPS_TREAT_NEW_VALUES_AS_DIRTY (0x00000002)</para>
			/// <para>
			/// <c>Introduced in Windows 8</c>. New property values that are added to the property store through the
			/// IPropertyStore::SetValue method will cause the IPersistStream::IsDirty method to return S_OK. If this flag is not set, the
			/// addition of new property values to the property store does not affect the value returned by <c>IPersistStream::IsDirty</c>.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para>
			/// Read/write is the default setting. <c>IPersistSerializedPropStorage::SetFlags</c> can be called at any time to toggle the
			/// read-only and read/write state of the property store.
			/// </para>
			/// <para>
			/// In versions of Windows before Windows 7, callers can assign a literal zero value directly into the flags parameter to set
			/// the read/write state. As of Windows 7, the FPSPS_DEFAULT flag value should be used instead.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipersistserializedpropstorage-setflags HRESULT
			// SetFlags( PERSIST_SPROPSTORE_FLAGS flags );
			void SetFlags(PERSIST_SPROPSTORE_FLAGS flags);

			/// <summary>Initializes the property store instance from the specified serialized property storage data.</summary>
			/// <param name="psps">
			/// <para>Type: <c>PCUSERIALIZEDPROPSTORAGE</c></para>
			/// <para>A pointer to the serialized property store data that will be used to initialize the property store.</para>
			/// </param>
			/// <param name="cb">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The count of bytes contained in the serialized property storage data pointed to by psps.</para>
			/// </param>
			/// <remarks>
			/// The <c>SERIALIZEDPROPSTORAGE</c> type is defined in Propsys.h as an incomplete type. It should be treated as an array of
			/// <c>BYTE</c> values; the format of the data returned is not specified. The data stored as a <c>SERIALIZEDPROPSTORAGE</c>
			/// structure must have been obtained through a call to IPersistSerializedPropStorage::GetPropertyStorage, either directly or
			/// through persisted data that was generated by a call to that method.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipersistserializedpropstorage-setpropertystorage
			// HRESULT SetPropertyStorage( PCUSERIALIZEDPROPSTORAGE psps, DWORD cb );
			void SetPropertyStorage([In] IntPtr psps, uint cb);

			/// <summary>Gets the serialized property storage data from the property store instance.</summary>
			/// <param name="ppsps">
			/// <para>Type: <c>SERIALIZEDPROPSTORAGE**</c></para>
			/// <para>When this method returns, contains the address of a pointer to the serialized property storage data.</para>
			/// </param>
			/// <param name="pcb">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>
			/// When this method returns, contains the count of bytes contained in the serialized property storage data pointed to by ppsps.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para>
			/// The <c>SERIALIZEDPROPSTORAGE</c> type is defined in Propsys.h as an incomplete type. It should be treated as an array of
			/// <c>BYTE</c> values; the format of the returned data is not specified. The contents of the <c>SERIALIZEDPROPSTORAGE</c>
			/// structure are suitable for persisting to disk or other storage and can be used to initialize another property store through IPersistSerializedPropStorage::SetPropertyStorage.
			/// </para>
			/// <para>
			/// <c>Note</c> It is the responsibility of the application that calls <c>IPersistSerializedPropStorage::GetPropertyStorage</c>
			/// to later call CoTaskMemFree to release the memory referred to by ppsps when it is no longer needed.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipersistserializedpropstorage-getpropertystorage
			// HRESULT GetPropertyStorage( SERIALIZEDPROPSTORAGE **ppsps, DWORD *pcb );
			void GetPropertyStorage(out IntPtr ppsps, out uint pcb);
		}

		/// <summary>Exposes methods that enumerate and retrieve individual property description details.</summary>
		[ComImport, Guid("6F79D558-3E96-4549-A1D1-7D75D2288814"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h", MSDNShortId = "bb761561")]
		public interface IPropertyDescription
		{
			/// <summary>Gets a structure that acts as a property's unique identifier.</summary>
			/// <returns>When this method returns, contains a pointer to a PROPERTYKEY structure.</returns>
			PROPERTYKEY GetPropertyKey();

			/// <summary>Gets the case-sensitive name by which a property is known to the system, regardless of its localized name.</summary>
			/// <returns>
			/// When this method returns, contains the address of a pointer to the property's canonical name as a null-terminated Unicode string.
			/// </returns>
			SafeCoTaskMemString GetCanonicalName();

			/// <summary>Gets the variant type of the property.</summary>
			/// <returns>
			/// When this method returns, contains a pointer to a VARTYPE that indicates the property type. If the property is multi-valued,
			/// the value pointed to is a VT_VECTOR mask (VT_VECTOR ORed to the VARTYPE.
			/// </returns>
			VARTYPE GetPropertyType();

			/// <summary>Gets the display name of the property as it is shown in any UI.</summary>
			/// <param name="pszName">Contains the address of a pointer to the property's name as a null-terminated Unicode string.</param>
			[PreserveSig]
			HRESULT GetDisplayName(out SafeCoTaskMemString pszName);

			/// <summary>Gets the text used in edit controls hosted in various dialog boxes.</summary>
			/// <returns>
			/// When this method returns, contains the address of a pointer to a null-terminated Unicode buffer that holds the invitation text.
			/// </returns>
			SafeCoTaskMemString GetEditInvitation();

			/// <summary>Gets a set of flags that describe the uses and capabilities of the property.</summary>
			/// <param name="mask">
			/// A mask that specifies which type flags to retrieve. A combination of values found in the PROPDESC_TYPE_FLAGS constants. To
			/// retrieve all type flags, pass PDTF_MASK_ALL
			/// </param>
			/// <returns>When this method returns, contains a pointer to a value that consists of bitwise PROPDESC_TYPE_FLAGS values.</returns>
			PROPDESC_TYPE_FLAGS GetTypeFlags([In] PROPDESC_TYPE_FLAGS mask);

			/// <summary>Gets the current set of flags governing the property's view.</summary>
			/// <returns>
			/// When this method returns, contains a pointer to a value that includes one or more of the following flags. See
			/// PROPDESC_VIEW_FLAGS for valid values.
			/// </returns>
			PROPDESC_VIEW_FLAGS GetViewFlags();

			/// <summary>Gets the default column width of the property in a list view.</summary>
			/// <returns>A pointer to the column width value, in characters.</returns>
			uint GetDefaultColumnWidth();

			/// <summary>Gets the current data type used to display the property.</summary>
			/// <returns>Contains a pointer to a value that indicates the display type.</returns>
			PROPDESC_DISPLAYTYPE GetDisplayType();

			/// <summary>
			/// Gets the column state flag, which describes how the property should be treated by interfaces or APIs that use this flag.
			/// </summary>
			/// <returns>When this method returns, contains a pointer to the column state flag.</returns>
			SHCOLSTATE GetColumnState();

			/// <summary>Gets the grouping method to be used when a view is grouped by a property, and retrieves the grouping type.</summary>
			/// <returns>Receives a pointer to a flag value that indicates the grouping type.</returns>
			PROPDESC_GROUPING_RANGE GetGroupingRange();

			/// <summary>Gets the relative description type for a property description.</summary>
			/// <returns>
			/// When this method returns, contains a pointer to the relative description type value. See PROPDESC_RELATIVEDESCRIPTION_TYPE
			/// for valid values.
			/// </returns>
			PROPDESC_RELATIVEDESCRIPTION_TYPE GetRelativeDescriptionType();

			/// <summary>
			/// Compares two property values in the manner specified by the property description. Returns two display strings that describe
			/// how the two properties compare.
			/// </summary>
			/// <param name="propvar1">A reference to a PROPVARIANT structure that contains the type and value of the first property.</param>
			/// <param name="propvar2">A reference to a PROPVARIANT structure that contains the type and value of the second property.</param>
			/// <param name="ppszDesc1">
			/// When this method returns, contains the address of a pointer to the description string that compares the first property with
			/// the second property. The string is null-terminated.
			/// </param>
			/// <param name="ppszDesc2">
			/// When this method returns, contains the address of a pointer to the description string that compares the second property with
			/// the first property. The string is null-terminated.
			/// </param>
			void GetRelativeDescription([In] PROPVARIANT propvar1, [In] PROPVARIANT propvar2, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszDesc1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszDesc2);

			/// <summary>Gets the current sort description flags for the property, which indicate the particular wordings of sort offerings.</summary>
			/// <returns>
			/// When this method returns, contains a pointer to the value of one or more of the following flags that indicate the sort types
			/// available to the user. Note that the strings shown are English versions only. Localized strings are used for other locales.
			/// </returns>
			PROPDESC_SORTDESCRIPTION GetSortDescription();

			/// <summary>Gets the localized display string that describes the current sort order.</summary>
			/// <param name="fDescending">
			/// TRUE if ppszDescription should reference the string "Z on top"; FALSE to reference the string "A on top".
			/// </param>
			/// <returns>
			/// When this method returns, contains the address of a pointer to the sort description as a null-terminated Unicode string.
			/// </returns>
			SafeCoTaskMemString GetSortDescriptionLabel([In, MarshalAs(UnmanagedType.Bool)] bool fDescending);

			/// <summary>Gets a value that describes how the property values are displayed when multiple items are selected in the UI.</summary>
			/// <returns>When this method returns, contains a pointer to a value that indicates the aggregation type.</returns>
			PROPDESC_AGGREGATION_TYPE GetAggregationType();

			/// <summary>
			/// Gets the condition type and default condition operation to use when displaying the property in the query builder UI. This
			/// influences the list of predicate conditions (for example, equals, less than, and contains) that are shown for this property.
			/// </summary>
			/// <param name="pcontype">A pointer to a value that indicates the condition type.</param>
			/// <param name="popDefault">When this method returns, contains a pointer to a value that indicates the default condition operation.</param>
			void GetConditionType(out PROPDESC_CONDITION_TYPE pcontype, out CONDITION_OPERATION popDefault);

			/// <summary>Gets an instance of an IPropertyEnumTypeList, which can be used to enumerate the possible values for a property.</summary>
			/// <param name="riid">Reference to the interface ID of the requested interface.</param>
			/// <returns>When this method returns, contains the address of an IPropertyEnumTypeList interface pointer.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyEnumTypeList GetEnumTypeList(in Guid riid);

			/// <summary>Coerces the value to the canonical value, according to the property description.</summary>
			/// <param name="propvar">
			/// On entry, contains a pointer to a PROPVARIANT structure that contains the original value. When this method returns, contains
			/// the canonical value.
			/// </param>
			[PreserveSig]
			HRESULT CoerceToCanonicalValue([In, Out] PROPVARIANT propvar);

			/// <summary>Gets a formatted, Unicode string representation of a property value.</summary>
			/// <param name="propvar">A reference to a PROPVARIANT structure that contains the type and value of the property.</param>
			/// <param name="pdfFlags">
			/// One or more of the PROPDESC_FORMAT_FLAGS flags, which are either bitwise or multiple values, that indicate the property
			/// string format.
			/// </param>
			/// <returns>
			/// When this method returns, contains the formatted value as a null-terminated, Unicode string. The calling application must
			/// allocate memory for the buffer, and use CoTaskMemFree to release the string specified by pszText when it is no longer needed.
			/// </returns>
			SafeCoTaskMemString FormatForDisplay([In] PROPVARIANT propvar, [In] PROPDESC_FORMAT_FLAGS pdfFlags);

			/// <summary>Gets a value that indicates whether a property is canonical according to the definition of the property description.</summary>
			/// <param name="propvar">A reference to a PROPVARIANT structure that contains the type and value of the property.</param>
			/// <returns>Returns one of the following values: S_OK = The value is canonical; S_FALSE = The value is not canonical.</returns>
			[PreserveSig]
			HRESULT IsValueCanonical([In] PROPVARIANT propvar);
		}

		/// <summary>Exposes methods that enumerate and retrieve individual property description details.</summary>
		[ComImport, Guid("57d2eded-5062-400e-b107-5dae79fe57a6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h", MSDNShortId = "bb761561")]
		public interface IPropertyDescription2 : IPropertyDescription
		{
			/// <summary>Gets a structure that acts as a property's unique identifier.</summary>
			/// <returns>When this method returns, contains a pointer to a PROPERTYKEY structure.</returns>
			new PROPERTYKEY GetPropertyKey();

			/// <summary>Gets the case-sensitive name by which a property is known to the system, regardless of its localized name.</summary>
			/// <returns>
			/// When this method returns, contains the address of a pointer to the property's canonical name as a null-terminated Unicode string.
			/// </returns>
			new SafeCoTaskMemString GetCanonicalName();

			/// <summary>Gets the variant type of the property.</summary>
			/// <returns>
			/// When this method returns, contains a pointer to a VARTYPE that indicates the property type. If the property is multi-valued,
			/// the value pointed to is a VT_VECTOR mask (VT_VECTOR ORed to the VARTYPE.
			/// </returns>
			new VARTYPE GetPropertyType();

			/// <summary>Gets the display name of the property as it is shown in any UI.</summary>
			/// <param name="pszName">Contains the address of a pointer to the property's name as a null-terminated Unicode string.</param>
			[PreserveSig]
			new HRESULT GetDisplayName(out SafeCoTaskMemString pszName);

			/// <summary>Gets the text used in edit controls hosted in various dialog boxes.</summary>
			/// <returns>
			/// When this method returns, contains the address of a pointer to a null-terminated Unicode buffer that holds the invitation text.
			/// </returns>
			new SafeCoTaskMemString GetEditInvitation();

			/// <summary>Gets a set of flags that describe the uses and capabilities of the property.</summary>
			/// <param name="mask">
			/// A mask that specifies which type flags to retrieve. A combination of values found in the PROPDESC_TYPE_FLAGS constants. To
			/// retrieve all type flags, pass PDTF_MASK_ALL
			/// </param>
			/// <returns>When this method returns, contains a pointer to a value that consists of bitwise PROPDESC_TYPE_FLAGS values.</returns>
			new PROPDESC_TYPE_FLAGS GetTypeFlags([In] PROPDESC_TYPE_FLAGS mask);

			/// <summary>Gets the current set of flags governing the property's view.</summary>
			/// <returns>
			/// When this method returns, contains a pointer to a value that includes one or more of the following flags. See
			/// PROPDESC_VIEW_FLAGS for valid values.
			/// </returns>
			new PROPDESC_VIEW_FLAGS GetViewFlags();

			/// <summary>Gets the default column width of the property in a list view.</summary>
			/// <returns>A pointer to the column width value, in characters.</returns>
			new uint GetDefaultColumnWidth();

			/// <summary>Gets the current data type used to display the property.</summary>
			/// <returns>Contains a pointer to a value that indicates the display type.</returns>
			new PROPDESC_DISPLAYTYPE GetDisplayType();

			/// <summary>
			/// Gets the column state flag, which describes how the property should be treated by interfaces or APIs that use this flag.
			/// </summary>
			/// <returns>When this method returns, contains a pointer to the column state flag.</returns>
			new SHCOLSTATE GetColumnState();

			/// <summary>Gets the grouping method to be used when a view is grouped by a property, and retrieves the grouping type.</summary>
			/// <returns>Receives a pointer to a flag value that indicates the grouping type.</returns>
			new PROPDESC_GROUPING_RANGE GetGroupingRange();

			/// <summary>Gets the relative description type for a property description.</summary>
			/// <returns>
			/// When this method returns, contains a pointer to the relative description type value. See PROPDESC_RELATIVEDESCRIPTION_TYPE
			/// for valid values.
			/// </returns>
			new PROPDESC_RELATIVEDESCRIPTION_TYPE GetRelativeDescriptionType();

			/// <summary>
			/// Compares two property values in the manner specified by the property description. Returns two display strings that describe
			/// how the two properties compare.
			/// </summary>
			/// <param name="propvar1">A reference to a PROPVARIANT structure that contains the type and value of the first property.</param>
			/// <param name="propvar2">A reference to a PROPVARIANT structure that contains the type and value of the second property.</param>
			/// <param name="ppszDesc1">
			/// When this method returns, contains the address of a pointer to the description string that compares the first property with
			/// the second property. The string is null-terminated.
			/// </param>
			/// <param name="ppszDesc2">
			/// When this method returns, contains the address of a pointer to the description string that compares the second property with
			/// the first property. The string is null-terminated.
			/// </param>
			new void GetRelativeDescription([In] PROPVARIANT propvar1, [In] PROPVARIANT propvar2, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszDesc1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszDesc2);

			/// <summary>Gets the current sort description flags for the property, which indicate the particular wordings of sort offerings.</summary>
			/// <returns>
			/// When this method returns, contains a pointer to the value of one or more of the following flags that indicate the sort types
			/// available to the user. Note that the strings shown are English versions only. Localized strings are used for other locales.
			/// </returns>
			new PROPDESC_SORTDESCRIPTION GetSortDescription();

			/// <summary>Gets the localized display string that describes the current sort order.</summary>
			/// <param name="fDescending">
			/// TRUE if ppszDescription should reference the string "Z on top"; FALSE to reference the string "A on top".
			/// </param>
			/// <returns>
			/// When this method returns, contains the address of a pointer to the sort description as a null-terminated Unicode string.
			/// </returns>
			new SafeCoTaskMemString GetSortDescriptionLabel([In, MarshalAs(UnmanagedType.Bool)] bool fDescending);

			/// <summary>Gets a value that describes how the property values are displayed when multiple items are selected in the UI.</summary>
			/// <returns>When this method returns, contains a pointer to a value that indicates the aggregation type.</returns>
			new PROPDESC_AGGREGATION_TYPE GetAggregationType();

			/// <summary>
			/// Gets the condition type and default condition operation to use when displaying the property in the query builder UI. This
			/// influences the list of predicate conditions (for example, equals, less than, and contains) that are shown for this property.
			/// </summary>
			/// <param name="pcontype">A pointer to a value that indicates the condition type.</param>
			/// <param name="popDefault">When this method returns, contains a pointer to a value that indicates the default condition operation.</param>
			new void GetConditionType(out PROPDESC_CONDITION_TYPE pcontype, out CONDITION_OPERATION popDefault);

			/// <summary>Gets an instance of an IPropertyEnumTypeList, which can be used to enumerate the possible values for a property.</summary>
			/// <param name="riid">Reference to the interface ID of the requested interface.</param>
			/// <returns>When this method returns, contains the address of an IPropertyEnumTypeList interface pointer.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new IPropertyEnumTypeList GetEnumTypeList(in Guid riid);

			/// <summary>Coerces the value to the canonical value, according to the property description.</summary>
			/// <param name="propvar">
			/// On entry, contains a pointer to a PROPVARIANT structure that contains the original value. When this method returns, contains
			/// the canonical value.
			/// </param>
			[PreserveSig]
			new HRESULT CoerceToCanonicalValue([In, Out] PROPVARIANT propvar);

			/// <summary>Gets a formatted, Unicode string representation of a property value.</summary>
			/// <param name="propvar">A reference to a PROPVARIANT structure that contains the type and value of the property.</param>
			/// <param name="pdfFlags">
			/// One or more of the PROPDESC_FORMAT_FLAGS flags, which are either bitwise or multiple values, that indicate the property
			/// string format.
			/// </param>
			/// <returns>
			/// When this method returns, contains the formatted value as a null-terminated, Unicode string. The calling application must
			/// allocate memory for the buffer, and use CoTaskMemFree to release the string specified by pszText when it is no longer needed.
			/// </returns>
			new SafeCoTaskMemString FormatForDisplay([In] PROPVARIANT propvar, [In] PROPDESC_FORMAT_FLAGS pdfFlags);

			/// <summary>Gets a value that indicates whether a property is canonical according to the definition of the property description.</summary>
			/// <param name="propvar">A reference to a PROPVARIANT structure that contains the type and value of the property.</param>
			/// <returns>Returns one of the following values: S_OK = The value is canonical; S_FALSE = The value is not canonical.</returns>
			[PreserveSig]
			new HRESULT IsValueCanonical([In] PROPVARIANT propvar);

			/// <summary>Gets the image reference associated with a property value.</summary>
			/// <param name="propvar">The PROPVARIANT for which to get an image.</param>
			/// <param name="ppszImageRes">
			/// A string that receives, when this method returns successfully, a string of the form &lt;dll name&gt;,-&lt;resid&gt; that is
			/// suitable to be passed to PathParseIconLocation.
			/// </param>
			/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			[PreserveSig]
			HRESULT GetImageReferenceForValue([In] PROPVARIANT propvar, out SafeCoTaskMemString ppszImageRes);
		}

		/// <summary>Exposes methods that enumerate and retrieve property description list details.</summary>
		[ComImport, Guid("1F9FC1D0-C39B-4B26-817F-011967D3440E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h", MSDNShortId = "bb761511")]
		public interface IPropertyDescriptionList
		{
			/// <summary>Gets the number of properties included in the property list.</summary>
			/// <returns>
			/// <para>Type: <c>UINT*</c></para>
			/// <para>When this method returns, contains a pointer to the count of properties.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertydescriptionlist-getcount
			// HRESULT GetCount( UINT *pcElem );
			uint GetCount();

			/// <summary>Gets the property description at the specified index in a property description list.</summary>
			/// <param name="iElem">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of the property in the list string.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to the IID of the requested property description interface, typically IID_IPropertyDescription.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>When this method returns, contains the interface pointer requested in riid. Typically, this is IPropertyDescription.</para>
			/// </returns>
			/// <remarks>It is recommended that you use the IID_PPV_ARGS macro, defined in objbase.h, to package the riid and ppv parameters. This macro provides the correct IID based on the interface pointed to by the value in ppv, eliminating the possibility of a coding error.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertydescriptionlist-getat
			// HRESULT GetAt( UINT iElem, REFIID riid, void **ppv );
			IPropertyDescription GetAt([In] uint iElem, in Guid riid);
		}

		/// <summary>
		/// Exposes methods that extract data from enumeration information. IPropertyEnumType gives access to the enum and enumRange
		/// elements in the property schema in a programmatic way at run time.
		/// </summary>
		[ComImport, Guid("11e1fbf9-2d56-4a6b-8db3-7cd193a471f2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h")]
		public interface IPropertyEnumType
		{
			/// <summary>Gets an enumeration type from an enumeration information structure.</summary>
			/// <returns>When this method returns, contains a value that indicate the enumeration type.</returns>
			PROPENUMTYPE GetEnumType();

			/// <summary>Gets a value from an enumeration information structure.</summary>
			/// <param name="ppropvar">When this method returns, contains a pointer to the property value.</param>
			void GetValue([Out] PROPVARIANT ppropvar);

			/// <summary>Gets a minimum value from an enumeration information structure.</summary>
			/// <param name="ppropvarMin">When this method returns, contains a pointer to the minimum value.</param>
			void GetRangeMinValue([Out] PROPVARIANT ppropvarMin);

			/// <summary>Gets a set value from an enumeration information structure.</summary>
			/// <param name="ppropvarSet">When this method returns, contains a pointer to the set value.</param>
			void GetRangeSetValue([Out] PROPVARIANT ppropvarSet);

			/// <summary>Gets display text from an enumeration information structure.</summary>
			/// <param name="ppszDisplay">
			/// When this method returns, contains the address of a pointer to a null-terminated Unicode string that contains the display text.
			/// </param>
			void GetDisplayText([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszDisplay);
		}

		/// <summary>Exposes methods that extract data from enumeration information. IPropertyEnumType2 extends IPropertyEnumType.</summary>
		/// <seealso cref="Vanara.PInvoke.PropSys.IPropertyEnumType"/>
		[ComImport, Guid("9b6e051c-5ddd-4321-9070-fe2acb55e794"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h")]
		public interface IPropertyEnumType2 : IPropertyEnumType
		{
			/// <summary>Gets an enumeration type from an enumeration information structure.</summary>
			/// <returns>When this method returns, contains a value that indicate the enumeration type.</returns>
			new PROPENUMTYPE GetEnumType();

			/// <summary>Gets a value from an enumeration information structure.</summary>
			/// <param name="ppropvar">When this method returns, contains a pointer to the property value.</param>
			new void GetValue([Out] PROPVARIANT ppropvar);

			/// <summary>Gets a minimum value from an enumeration information structure.</summary>
			/// <param name="ppropvarMin">When this method returns, contains a pointer to the minimum value.</param>
			new void GetRangeMinValue([Out] PROPVARIANT ppropvarMin);

			/// <summary>Gets a set value from an enumeration information structure.</summary>
			/// <param name="ppropvarSet">When this method returns, contains a pointer to the set value.</param>
			new void GetRangeSetValue([Out] PROPVARIANT ppropvarSet);

			/// <summary>Gets display text from an enumeration information structure.</summary>
			/// <param name="ppszDisplay">
			/// When this method returns, contains the address of a pointer to a null-terminated Unicode string that contains the display text.
			/// </param>
			new void GetDisplayText([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszDisplay);

			/// <summary>Retrieves the image reference associated with a property enumeration.</summary>
			/// <param name="ppszImageRes">
			/// A pointer to a buffer that, when this method returns successfully, receives a string of the form &lt;dll
			/// name&gt;,-&lt;resid&gt; that is suitable to be passed to PathParseIconLocation.
			/// </param>
			[PreserveSig] HRESULT GetImageReference([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszImageRes);
		}

		/// <summary>Exposes methods that enumerate the possible values for a property.</summary>
		[ComImport, Guid("A99400F4-3D84-4557-94BA-1242FB2CC9A6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h")]
		public interface IPropertyEnumTypeList
		{
			/// <summary>Gets the number of elements in the list.</summary>
			/// <returns>The number of list elements.</returns>
			uint GetCount();

			/// <summary>Gets the IPropertyEnumType object at the specified index in the list.</summary>
			/// <param name="itype">The index of the object in the list.</param>
			/// <param name="riid">The IID of IPropertyEnumType</param>
			/// <returns>An IPropertyEnumType instance.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyEnumType GetAt([In] uint itype, in Guid riid);

			/// <summary>Gets the condition at the specified index.</summary>
			/// <param name="index">Index of the desired condition.</param>
			/// <param name="riid">A reference to the IID of the interface to retrieve.</param>
			/// <returns>An ICondition interface pointer.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetConditionAt([In] uint index, in Guid riid);

			/// <summary>Compares the specified property value against the enumerated values in a list and returns the matching index.</summary>
			/// <param name="propvarCmp">A reference to a PROPVARIANT structure that represents the property value.</param>
			/// <param name="pnIndex">
			/// When this method returns, contains a pointer to the index in the enumerated type list that matches the property value, if any.
			/// </param>
			/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			[PreserveSig]
			HRESULT FindMatchingIndex([In] PROPVARIANT propvarCmp, out uint pnIndex);
		}

		/// <summary>This interface exposes methods used to enumerate and manipulate property values.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nn-propsys-ipropertystore
		[PInvokeData("propsys.h", MSDNShortId = "63afd5b1-87cc-4e0a-8964-2138c5fbff46")]
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("886d8eeb-8cf2-4446-8d02-cdba1dbdcf99")]
		public interface IPropertyStore
		{
			/// <summary>This method returns a count of the number of properties that are attached to the file.</summary>
			/// <returns>A value that indicates the property count.</returns>
			/// <remarks>
			/// <para>
			/// <c>IPropertyStore</c> provides an abstraction over an array of property keys via the and IPropertyStore::GetAt methods. The
			/// property keys in this array represent the properties that are currently stored by the <c>IPropertyStore</c>.
			/// </para>
			/// <para>
			/// When succeeds, the value pointed to by cProps is a count of property keys in the array. The caller can expect calls to
			/// <c>IPropertyStore::GetAt</c> to succeed for values of iProp less than cProps.
			/// </para>
			/// <para>
			/// In the case of failures such as E_OUTOFMEMORY, you should set cProps to zero. It is preferable that errors are discovered
			/// during creation or initialization of the property store.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertystore-getcount HRESULT GetCount( DWORD *cProps );
			uint GetCount();

			/// <summary>Gets a property key from an item's array of properties.</summary>
			/// <param name="iProp">
			/// <para>[in] Type: <c>DWORD</c></para>
			/// <para>The index of the property key in the array of <c>PROPERTYKEY</c> structures. This is a zero-based index.</para>
			/// </param>
			/// <returns>
			/// <para>[out] Type: <c>PROPERTYKEY*</c></para>
			/// <para>When this method returns, contains a <c>PROPERTYKEY</c> structure that receives the unique identifier for a property.</para>
			/// </returns>
			/// <remarks>
			/// <para>The <c>PROPERTYKEY</c> returned in pkey can be used in subsequent calls to <c>IPropertyStore::GetValue</c> and <c>IPropertyStore::SetValue</c>.</para>
			/// <para>
			/// There is no specific order to an item's set of enumerated properties. To find a specific property, you must walk the array
			/// until you find the property that matches your criteria.
			/// </para>
			/// <para>
			/// iProp cannot be greater than or equal to the cProps parameter retrieved by <c>IPropertyStore::GetCount</c>. If it is greater
			/// than or equal to that value, <c>IPropertyStore::GetAt</c> returns E_INVALIDARG and pkey is set to <c>NULL</c> by the
			/// property handler.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb761471(v=vs.85) HRESULT GetAt( [in] DWORD iProp,
			// [out] PROPERTYKEY *pkey );
			PROPERTYKEY GetAt(uint iProp);

			/// <summary>Gets data for a specific property.</summary>
			/// <param name="pkey">The pkey.</param>
			/// <param name="pv">
			/// <para>[out] Type: <c>PROPVARIANT*</c></para>
			/// <para>When this method returns, contains a <c>PROPVARIANT</c> structure that contains the property data.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// If the <c>PROPERTYKEY</c> referenced in key is not present in the property store, this method returns <c>S_OK</c> and the
			/// <c>vt</c> member of the structure pointed to by pv is set to VT_EMPTY.
			/// </para>
			/// <para>
			/// File property handler implementers can use <c>IPropertyStore::GetValue</c> to retrieve the property value by using the
			/// filestream with which <c>Initialize</c> initialized the property handler. The value can also be computed from an in-memory
			/// cache, or other means. However, most consumers of the property system obtain <c>IPropertyStore</c> through
			/// <c>GetPropertyStore</c> and are not—and have no need to be—aware of the method of initialization.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb761473(v=vs.85) HRESULT GetValue( [in]
			// REFPROPERTYKEY key, [out] PROPVARIANT *pv );
			void GetValue(in PROPERTYKEY pkey, [In, Out] PROPVARIANT pv);

			/// <summary>Sets a new property value, or replaces or removes an existing value.</summary>
			/// <param name="pkey">The pkey.</param>
			/// <param name="pv">The pv.</param>
			/// <remarks>
			/// <para>
			/// <c>Note</c> When this method is implemented under <c>IPropertyStoreCache</c>, be aware that the interface is used only by
			/// the in-memory store. Many of the following remarks may not apply in that case.
			/// </para>
			/// <para>
			/// <c>SetValue</c> affects the current property store instance only. A property handler implements <c>SetValue</c> by
			/// accumulating property changes in an in-memory data structure. Property changes are written to the stream only when
			/// <c>IPropertyStore::Commit</c> is called.
			/// </para>
			/// <para>If <c>Commit</c> is called on a read-only property store, the property handler determines this and returns STG_E_ACCESSDENIED.</para>
			/// <para>
			/// In general, errors should be detected and reported by <c>SetValue</c>. However, when processing is deferred until
			/// <c>Commit</c> is called, the same error semantics apply.
			/// </para>
			/// <para>
			/// If a value was added or removed as a result of <c>SetValue</c>, subsequent enumerations by <c>IPropertyStore::GetCount</c>
			/// and <c>IPropertyStore::GetAt</c> reflect that change and subsequent calls to <c>SetValue</c> reflect the changed value.
			/// </para>
			/// <para>Adding a New Property</para>
			/// <para>If the property value pointed to by key does not exist in the store, <c>SetValue</c> adds the value to the store.</para>
			/// <para>Replacing an Existing Property Value</para>
			/// <para>If the property value pointed to by the key parameter already exists in the store, the stored value is replaced.</para>
			/// <para>Removing an Existing Property</para>
			/// <para>Removing a property values from a property store is not supported and could lead to unexpected results.</para>
			/// <para>Support for Different Properties</para>
			/// <para>
			/// A property handler must handle three types of properties in <c>SetValue</c>: new properties introduced by the handler
			/// author, pre-existing properties that are germane to the property handler, and other properties that do not fall in either of
			/// those categories.
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>
			/// New properties introduced by the property handler author must be described in a property description XML file. Clients
			/// consume a file property handler through a wrapping layer called the Windows Property Provider. This layer delegates calls to
			/// <c>SetValue</c> to the property handler after it enforces restrictions on the new property according to the property
			/// description XML. Therefore, a handler should not attempt to enforce restrictions itself and must store any values that
			/// satisfy the property description XML. If the property description does not provide the necessary information to restrict
			/// values for the new property, the handler must alter the value as necessary to store those values successfully. For example,
			/// in the property description XML there is no way to specify that an integer-valued property can never be an odd number. If an
			/// odd integer were provided to <c>SetValue</c>, the handler is still required to store a value successfully. It could
			/// accomplish this by perhaps adding one to the value. If data is lost, <c>SetValue</c> must succeed with the return value INPLACE_S_TRUNCATED.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// Pre-existing properties that are germane to the handler are those that have a representation in the handler's property
			/// storage format. For example, Adobe Acrobat .pdf files have representations for PKEY_Author and PKEY_Comments. These
			/// properties are described in a property description XML file provided by Windows. It is likely that the restrictions provided
			/// by Windows do not exactly match how the equivalent property must be stored in the author's file format. For example, the
			/// author value may be restricted to fewer characters in Acrobat files than in the property description for PKEY_Author. In
			/// this case, the handler author must make a best-effort attempt to coerce the property value. If data is lost, <c>SetValue</c>
			/// must succeed with the return value INPLACE_S_TRUNCATED. In the unusual case that the value cannot be coerced,
			/// <c>SetValue</c> can return E_FAIL. If the author's file format is less restrictive than a property description provided by
			/// Windows, the Windows Property Provider layer described earlier will already have returned an error and therefore the
			/// property handler's <c>SetValue</c> will never be called to store the value.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// Properties that are neither new nor pre-existing properties germane to the handler must still be stored by the property
			/// handler. The utility class CLSID_InMemoryPropertyStore, provided by Windows, can be used by handler authors to temporarily
			/// store such properties in memory and save those properties to a stream for storage in the file.
			/// </term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb761475(v=vs.85) HRESULT SetValue( [in]
			// REFPROPERTYKEY key, [in] REFPROPVARIANT propvar );
			void SetValue(in PROPERTYKEY pkey, [In] PROPVARIANT pv);

			/// <summary>After a change has been made, this method saves the changes.</summary>
			/// <remarks>
			/// <para>
			/// Before the method returns, it releases the file stream or path that was initialized to be used by the method. Therefore, no
			/// <c>IPropertyStore</c> methods succeed after returns. At that point, they return E_FAIL.
			/// </para>
			/// <para>
			/// Property handlers must ensure that property changes result in a valid destination file, even if the process terminates
			/// abnormally, or encounters any errors.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertystore-commit HRESULT Commit();
			void Commit();
		}

		/// <summary>Exposes a method that determines whether a property can be edited in the UI by the user.</summary>
		/// <remarks>
		/// <para>When to Implement</para>
		/// <para>
		/// Property handlers implement this interface to disable a user's ability to edit specific properties. These properties are
		/// typically editable in the UI, but are not supported for writing by the property handler. For example, the property System.Author
		/// is typically editable. If a property handler author created a file type that exposed System.Author for reading, but could not
		/// support writing this property back, the handler author could return S_FALSE from IPropertyStoreCapabilities::IsPropertyWritable
		/// for System.Author.
		/// </para>
		/// <para>
		/// The Shell user interfaces that allow property editing, such as the <c>Details Pane</c> and <c>Details Tab</c> of the Properties
		/// dialog, call this method as part of determining whether to allow editing of a specific property. This allows the Shell property
		/// editing UI to disable controls rather than showing errors when the property handler fails to set or commit the property value.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nn-propsys-ipropertystorecapabilities
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("c8e2d566-186e-4d49-bf41-6909ead56acc")]
		public interface IPropertyStoreCapabilities
		{
			/// <summary>Queries whether the property handler allows a specific property to be edited in the UI by the user.</summary>
			/// <param name="key">
			/// <para>Type: <c>REFPROPERTYKEY</c></para>
			/// <para>A reference to PROPERTYKEY structure that represents the property being queried.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The property can be edited and stored by the handler.</term>
			/// </item>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>The property cannot be edited.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// The Shell disables the editing of controls by the user as appropriate through this method. A handler that does not support
			/// IPropertyStoreCapabilities is assumed to support writing of any property.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertystorecapabilities-ispropertywritable
			// HRESULT IsPropertyWritable( REFPROPERTYKEY key );
			[PreserveSig]
			HRESULT IsPropertyWritable(in PROPERTYKEY key);
		}

		/// <summary>
		/// <para>Exposes methods to get an IPropertyStore object.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This interface is typically obtained through IShellFolder::BindToObject or IShellItem::BindToHandler. It is useful for data
		/// source implementers who want to avoid the additional overhead of creating a property store through
		/// IShellItem2::GetPropertyStore. However, <c>IShellItem2::GetPropertyStore</c> is the recommended method to obtain a property
		/// store unless you are implementing a data source through a Shell folder extension.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nn-propsys-ipropertystorefactory
		[PInvokeData("propsys.h", MSDNShortId = "78ea822d-da8e-4883-b0eb-4277e7eb87a2")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("bc110b6d-57e8-4148-a9c6-91015ab2f3a5")]
		public interface IPropertyStoreFactory
		{
			/// <summary>
			/// <para>Gets an IPropertyStore object that corresponds to the supplied flags.</para>
			/// </summary>
			/// <param name="flags">
			/// <para>Type: <c>GETPROPERTYSTOREFLAGS</c></para>
			/// <para>GETPROPERTYSTOREFLAGS values that modify the store that is returned.</para>
			/// </param>
			/// <param name="pUnkFactory">
			/// <para>Type: <c>IUnknown*</c></para>
			/// <para>
			/// Optional. A pointer to the IUnknown of an object that implements ICreateObject. If pUnkFactory is provided, this method can
			/// create the handler instance using <c>ICreateObject</c> rather than CoCreateInstance, if implemented. The reason to provide
			/// pUnkFactory is usually to create the handler in a different process. However, for most users, passing <c>NULL</c> in this
			/// parameter is sufficient.
			/// </para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to IID of the object to create.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>When this method returns, contains the address of an IPropertyStore interface pointer.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// It is recommended that you use the IID_PPV_ARGS macro, defined in Objbase.h, to package the riid and ppv parameters. This
			/// macro provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a
			/// coding error.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-ipropertystorefactory-getpropertystore HRESULT
			// GetPropertyStore( GETPROPERTYSTOREFLAGS flags, IUnknown *pUnkFactory, REFIID riid, void **ppv );
			void GetPropertyStore(GETPROPERTYSTOREFLAGS flags, [Optional, MarshalAs(UnmanagedType.IUnknown)] ICreateObject pUnkFactory, in Guid riid, out IPropertyStore ppv);

			/// <summary>
			/// <para>
			/// Gets an IPropertyStore object, given a set of property keys. This provides an alternative, possibly faster, method of
			/// getting an <c>IPropertyStore</c> object compared to calling IPropertyStoreFactory::GetPropertyStore.
			/// </para>
			/// </summary>
			/// <param name="rgKeys">
			/// <para>Type: <c>const PROPERTYKEY*</c></para>
			/// <para>A pointer to an array of PROPERTYKEY structures.</para>
			/// </param>
			/// <param name="cKeys">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of PROPERTYKEY structures in the array pointed to by rgKeys.</para>
			/// </param>
			/// <param name="flags">
			/// <para>Type: <c>GETPROPERTYSTOREFLAGS</c></para>
			/// <para>GETPROPERTYSTOREFLAGS values that modify the store that is returned.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to IID of the object to create.</para>
			/// </param>
			/// <param name="ppv">
			/// <para>Type: <c>void**</c></para>
			/// <para>When this method returns, contains the address of an IPropertyStore interface pointer.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// It is recommended that you use the IID_PPV_ARGS macro, defined in Objbase.h, to package the riid and ppv parameters. This
			/// macro provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a
			/// coding error.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-ipropertystorefactory-getpropertystoreforkeys HRESULT
			// GetPropertyStoreForKeys( const PROPERTYKEY *rgKeys, UINT cKeys, GETPROPERTYSTOREFLAGS flags, REFIID riid, void **ppv );
			void GetPropertyStoreForKeys([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] PROPERTYKEY[] rgKeys, uint cKeys, GETPROPERTYSTOREFLAGS flags,
				in Guid riid, out IPropertyStore ppv);
		}

		/// <summary>
		/// Exposes methods that get property descriptions, register and unregister property schemas, enumerate property descriptions, and
		/// format property values in a type-strict way.
		/// </summary>
		/// <remarks>
		/// Many of the exported APIs (such as PSGetPropertyDescription) are simply wrappers around the IPropertySystem methods. If your
		/// code calls a lot of these helper APIs in sequence, it may be worthwhile to instantiate a single <c>IPropertySystem</c> object,
		/// and call the methods directly, rather than calling the helper APIs. (To improve the performance, the helper APIs do obtain a
		/// cached instance of the <c>IPropertySystem</c> object.)
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nn-propsys-ipropertysystem
		[PInvokeData("propsys.h", MSDNShortId = "9ead94d9-4d4e-44c6-8c53-11c4c4ee2fb2")]
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("ca724e8a-c3e6-442b-88a4-6fb0db8035a3")]
		public interface IPropertySystem
		{
			/// <summary>
			/// Gets an instance of the subsystem object that implements IPropertyDescription, to obtain the property description for a
			/// given PROPERTYKEY.
			/// </summary>
			/// <param name="propkey">
			/// <para>Type: <c>REFPROPERTYKEY</c></para>
			/// <para>A reference to the desired property key. See PROPERTYKEY.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to the desired IID.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>The address of an IPropertyDescription interface pointer.</para>
			/// </returns>
			/// <remarks>
			/// It is recommended that you use the IID_PPV_ARGS macro, defined in objbase.h, to package the riid and ppv parameters. This
			/// macro provides the correct IID based on the interface pointed to by the value in ppv, eliminating the possibility of a
			/// coding error.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertysystem-getpropertydescription HRESULT
			// GetPropertyDescription( REFPROPERTYKEY propkey, REFIID riid, void **ppv );
			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyDescription GetPropertyDescription(ref PROPERTYKEY propkey, in Guid riid);

			/// <summary>
			/// Gets an instance of the subsystem object that implements IPropertyDescription, to obtain the property description for a
			/// given canonical name.
			/// </summary>
			/// <param name="pszCanonicalName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a string that identifies the property.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to the desired IID.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>The address of an IPropertyDescription interface pointer.</para>
			/// </returns>
			/// <remarks>
			/// It is recommended that you use the IID_PPV_ARGS macro, defined in objbase.h, to package the riid and ppv parameters. This
			/// macro provides the correct IID based on the interface pointed to by the value in ppv, eliminating the possibility of a
			/// coding error.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertysystem-getpropertydescriptionbyname HRESULT
			// GetPropertyDescriptionByName( LPCWSTR pszCanonicalName, REFIID riid, void **ppv );
			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyDescription GetPropertyDescriptionByName([In, MarshalAs(UnmanagedType.LPWStr)] string pszCanonicalName, in Guid riid);

			/// <summary>
			/// <para>
			/// Gets an instance of the subsystem object that implements IPropertyDescriptionList, to obtain an ordered collection of
			/// property descriptions, based on the provided string.
			/// </para>
			/// </summary>
			/// <param name="pszPropList">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a string that identifies the property list.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to the desired IID.</para>
			/// </param>
			/// <returns>
			/// <para>The address of an IPropertyDescriptionList interface pointer.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The property description list string ("proplist") syntax consists of a sequence of canonical property names, with flags
			/// associated with each property name. The string starts with "prop:". The syntax looks like this:
			/// </para>
			/// <para>The flags are optional and can be any of those below. Note: These flags translate to the PROPDESC_VIEW_FLAGS enum.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Flag</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>-</term>
			/// <term>Sort in reverse order (PDVF_REVERSESORT).</term>
			/// </item>
			/// <item>
			/// <term>0</term>
			/// <term>Show by default in both the primary and secondary lists (PDVF_SHOWBYDEFAULT | PDVF_SHOWINPRIMARYLIST | PDVF_SHOWINSECONDARYLIST).</term>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <term>Show in the primary and secondary lists (PDVF_SHOWINPRIMARYLIST | PDVF_SHOWINSECONDARYLIST).</term>
			/// </item>
			/// <item>
			/// <term>2</term>
			/// <term>Show in secondary list (PDVF_SHOWINSECONDARYLIST).</term>
			/// </item>
			/// <item>
			/// <term>^</term>
			/// <term>Begin a new group (PDVF_BEGINNEWGROUP).</term>
			/// </item>
			/// <item>
			/// <term>/</term>
			/// <term>Right align (PDVF_RIGHTALIGN).</term>
			/// </item>
			/// <item>
			/// <term>*</term>
			/// <term>Hide if the value is not present.</term>
			/// </item>
			/// <item>
			/// <term>|</term>
			/// <term>Center align. (PDVF_CENTERALIGN).</term>
			/// </item>
			/// <item>
			/// <term>~</term>
			/// <term>Hide the label. (PDVF_HIDELABEL).</term>
			/// </item>
			/// <item>
			/// <term>#</term>
			/// <term>Fill area. (PDVF_FILLAREA).</term>
			/// </item>
			/// <item>
			/// <term>?</term>
			/// <term>Hide if unsupported by property handler (PDVF_HIDEIFUNSUPPORTED).</term>
			/// </item>
			/// <item>
			/// <term>&lt;</term>
			/// <term>Parse as link (PDVF_PARSEASLINK).</term>
			/// </item>
			/// <item>
			/// <term>&amp;</term>
			/// <term>Show as whole link (PDVF_SHOWASWHOLELINK).</term>
			/// </item>
			/// </list>
			/// <para>From the dbfolder and file folder perspective:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>0</term>
			/// <term>Show as a column in defview, column chooser menu, and column chooser dialog.</term>
			/// </listheader>
			/// <item>
			/// <term>1</term>
			/// <term>Show in the column chooser menu and dialog.</term>
			/// </item>
			/// <item>
			/// <term>2</term>
			/// <term>Show in the column chooser dialog.</term>
			/// </item>
			/// <item>
			/// <term>NULL</term>
			/// <term>Include in the search results, but hide in the UI.</term>
			/// </item>
			/// </list>
			/// <para>The endflags are also optional and can be the following:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>EndFlag</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>]</term>
			/// <term>End column (used for extended tiles view).</term>
			/// </item>
			/// </list>
			/// <para>
			/// It is recommended that you use the IID_PPV_ARGS macro, defined in objbase.h, to package the riid and ppv parameters. This
			/// macro provides the correct IID based on the interface pointed to by the value in ppv, eliminating the possibility of a
			/// coding error.
			/// </para>
			/// <para>For more information about property schemas, see Property Schemas.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-ipropertysystem-getpropertydescriptionlistfromstring
			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyDescriptionList GetPropertyDescriptionListFromString([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropList, in Guid riid);

			/// <summary>
			/// Gets an instance of the subsystem object that implements IPropertyDescriptionList, to obtain either the entire or a partial
			/// list of property descriptions in the system.
			/// </summary>
			/// <param name="filterOn">
			/// <para>Type: <c>PROPDESC_ENUMFILTER</c></para>
			/// <para>The list to return. See PROPDESC_ENUMFILTER. Valid values for this method are 0 through 4.</para>
			/// </param>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>A reference to the desired IID.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>void**</c></para>
			/// <para>The address of an IPropertyDescriptionList interface pointer.</para>
			/// </returns>
			/// <remarks>
			/// <para>This method is not implemented where BUILDING_DOWNLEVEL_LIB is defined.</para>
			/// <para>
			/// It is recommended that you use the IID_PPV_ARGS macro, defined in objbase.h, to package the riid and ppv parameters. This
			/// macro provides the correct IID based on the interface pointed to by the value in ppv, eliminating the possibility of a
			/// coding error.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertysystem-enumeratepropertydescriptions HRESULT
			// EnumeratePropertyDescriptions( PROPDESC_ENUMFILTER filterOn, REFIID riid, void **ppv );
			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyDescriptionList EnumeratePropertyDescriptions(PROPDESC_ENUMFILTER filterOn, in Guid riid);

			/// <summary>Gets a formatted, Unicode string representation of a property value.</summary>
			/// <param name="key">
			/// <para>Type: <c>REFPROPERTYKEY</c></para>
			/// <para>A reference to the requested property key.</para>
			/// </param>
			/// <param name="propvar">
			/// <para>Type: <c>REFPROPVARIANT</c></para>
			/// <para>A reference to a PROPVARIANT structure containing the type and value of the property.</para>
			/// </param>
			/// <param name="pdff">
			/// <para>Type: <c>PROPDESC_FORMAT_FLAGS</c></para>
			/// <para>The format of the property string. See PROPDESC_FORMAT_FLAGS for possible values.</para>
			/// </param>
			/// <param name="pszText">
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// Receives the formatted value as a null-terminated, Unicode string. The calling application must allocate memory for the buffer.
			/// </para>
			/// </param>
			/// <param name="cchText">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The length of the buffer at pszText in <c>WCHAR</c><c>s</c>, including the terminating <c>NULL</c>. The maximum size is
			/// 0x8000 (32K).
			/// </para>
			/// </param>
			/// <remarks>
			/// <para>You must initialize Component Object Model (COM) with CoInitialize or OleInitialize before calling IPropertySystem::FormatForDisplay.</para>
			/// <para>
			/// When it succeeds, this method gets a formatted Unicode string representation of a property value for a specified
			/// PROPERTYKEY, and one or more PROPDESC_FORMAT_FLAGS. If the <c>PROPERTYKEY</c> is not recognized by the schema subsystem,
			/// IPropertySystem::FormatForDisplay attempts to format the value according to its VARTYPE.
			/// </para>
			/// <para>
			/// The purpose of this method is to convert data into a string suitable for display to the user. The value is formatted
			/// according to the current locale, the language of the user, the PROPDESC_FORMAT_FLAGS, and the property description specified
			/// by the property key. For information about how the property description schema influences the formatting of the value, see
			/// displayInfo, stringFormat, booleanFormat, numberFormat, NMDATETIMEFORMAT, and enumeratedList. Typically, the
			/// <c>PROPDESC_FORMAT_FLAGS</c> are used to modify the format prescribed by the property description.
			/// </para>
			/// <para>
			/// The output string may contain Unicode directional characters. These nonspacing characters influence the Unicode
			/// bidirectional algorithm so that the values appear correctly when a left-to-right (LTR) language is drawn on a right-to-left
			/// (RTL) window, and vice versa. These characters include the following:
			/// </para>
			/// <para>
			/// The properties in the following table use special formats and are unaffected by the PROPDESC_FORMAT_FLAGS (examples cited
			/// are for strings with a current locale set to English; typically, output is localized except where noted).
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Property</term>
			/// <term>Format</term>
			/// </listheader>
			/// <item>
			/// <term>System.FileAttributes</term>
			/// <term>
			/// The following file attributes are converted to letters and appended to create a string (for example, a value of 0x1801
			/// (FILE_ATTRIBUTE_READONLY | FILE_ATTRIBUTE_COMPRESSED | FILE_ATTRIBUTE_OFFLINE) is converted to "RCO"):
			/// </term>
			/// </item>
			/// <item>
			/// <term>System.Photo.ISOSpeed</term>
			/// <term>For example, "ISO-400".</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.ShutterSpeed</term>
			/// <term>The APEX value is converted to an exposure time using this formula: For example, "2 sec."or "1/125 sec.".</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.ExposureTime</term>
			/// <term>For example, "2 sec."or "1/125 sec."</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.Aperture</term>
			/// <term>The APEX value is converted to an F number using this formula: For example, "f/5.6".</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.FNumber</term>
			/// <term>For example, "f/5.6".</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.SubjectDistance</term>
			/// <term>For example, "15 m"or "250 mm".</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.FocalLength</term>
			/// <term>For example, "50 mm".</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.FlashEnergy</term>
			/// <term>For example, "500 bpcs".</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.ExposureBias</term>
			/// <term>For example, "-2 step", " 0 step", or "+3 step".</term>
			/// </item>
			/// <item>
			/// <term>System.Computer.DecoratedFreeSpace</term>
			/// <term>For example, "105 MB free of 13.2 GB".</term>
			/// </item>
			/// <item>
			/// <term>System.ItemType</term>
			/// <term>For example, "Application" or "JPEG Image".</term>
			/// </item>
			/// <item>
			/// <term>System.ControlPanel.Category</term>
			/// <term>For example, "Appearance and Personalization".</term>
			/// </item>
			/// <item>
			/// <term>System.ComputerName</term>
			/// <term>For example, "LITWARE05 (this computer)" or "testbox07".</term>
			/// </item>
			/// </list>
			/// <para>
			/// If the property key does not correspond to a property description in any of the registered property schemas, this method
			/// chooses a format based on the type of the value, as described in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Type of the value</term>
			/// <term>Format</term>
			/// </listheader>
			/// <item>
			/// <term>VT_BOOLEAN</term>
			/// <term>Not supported.</term>
			/// </item>
			/// <item>
			/// <term>VT_FILETIME</term>
			/// <term>
			/// Date/time string as specified by PROPDESC_FORMAT_FLAGS and the current locale. PDFF_SHORTTIME and PDFF_SHORTDATE are the
			/// default. For example, "11/13/2006 3:22 PM".
			/// </term>
			/// </item>
			/// <item>
			/// <term>Numeric VARTYPE</term>
			/// <term>Decimal string in the current locale. For example, "42".</term>
			/// </item>
			/// <item>
			/// <term>VT_LPWSTR or other</term>
			/// <term>String. Sequences of "\r", "\t", or "\n" are replaced with a single space.</term>
			/// </item>
			/// <item>
			/// <term>VT_VECTOR | anything</term>
			/// <term>Semicolon separated values—a semicolon is used regardless of locale.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertysystem-formatfordisplay HRESULT
			// FormatForDisplay( REFPROPERTYKEY key, REFPROPVARIANT propvar, PROPDESC_FORMAT_FLAGS pdff, LPWSTR pszText, DWORD cchText );
			void FormatForDisplay(ref PROPERTYKEY key, PROPVARIANT propvar, PROPDESC_FORMAT_FLAGS pdff, System.Text.StringBuilder pszText, uint cchText);

			/// <summary>Gets a string representation of a property value to an allocated memory buffer.</summary>
			/// <param name="key">
			/// <para>Type: <c>REFPROPERTYKEY</c></para>
			/// <para>A reference to the desired PROPERTYKEY.</para>
			/// </param>
			/// <param name="propvar">
			/// <para>Type: <c>REFPROPVARIANT</c></para>
			/// <para>A reference to a PROPVARIANT structure that contains the type and value of the property.</para>
			/// </param>
			/// <param name="pdff">
			/// <para>Type: <c>PROPDESC_FORMAT_FLAGS</c></para>
			/// <para>The format of the property string. See PROPDESC_FORMAT_FLAGS.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>When this method returns, contains a pointer to the formatted value as a null-terminated, Unicode string.</para>
			/// </returns>
			/// <remarks>
			/// <para>You must initialize Component Object Model (COM) with CoInitialize or OleInitialize before calling IPropertySystem::FormatForDisplayAlloc.</para>
			/// <para>
			/// On success, this method gets a formatted Unicode string representation of a property value for a specified PROPERTYKEY, and
			/// one or more PROPDESC_FORMAT_FLAGS. If the <c>PROPERTYKEY</c> is not recognized by the schema subsystem,
			/// IPropertySystem::FormatForDisplayAlloc attempts to format the value according to its VARTYPE.
			/// </para>
			/// <para>
			/// This method allocates memory for the buffer and returns a pointer to it at ppszDisplay. The calling application must use
			/// CoTaskMemFree to release the string specified by ppszDisplay when it is no longer needed.
			/// </para>
			/// <para>
			/// The purpose of this method is to convert data into a string suitable for display to the user. The value is formatted
			/// according to the current locale, the language of the user, the PROPDESC_FORMAT_FLAGS, and the property description specified
			/// by the property key. For information about how the property description schema influences the formatting of the value, see
			/// displayInfo, stringFormat, booleanFormat, numberFormat, NMDATETIMEFORMAT, and enumeratedList. Typically, the
			/// <c>PROPDESC_FORMAT_FLAGS</c> are used to modify the format prescribed by the property description.
			/// </para>
			/// <para>
			/// The output string may contain Unicode directional characters. These nonspacing characters influence the Unicode
			/// bidirectional algorithm so that the values appear correctly when a left to right (LTR) language is drawn on a right to left
			/// (RTL) window, and vice versa. These characters include the following:
			/// </para>
			/// <para>
			/// The following properties use special formats and are unaffected by the PROPDESC_FORMAT_FLAGS (examples cited are for strings
			/// with a current locale set to English; typically, output is localized except where noted).
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Property</term>
			/// <term>Format</term>
			/// </listheader>
			/// <item>
			/// <term>System.FileAttributes</term>
			/// <term>
			/// The following file attributes are converted to letters and appended to create a string (for example, a value of 0x1801
			/// (FILE_ATTRIBUTE_READONLY | FILE_ATTRIBUTE_COMPRESSED | FILE_ATTRIBUTE_OFFLINE) is converted to "RCO"):
			/// </term>
			/// </item>
			/// <item>
			/// <term>System.Photo.ISOSpeed</term>
			/// <term>For example, "ISO-400".</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.ShutterSpeed</term>
			/// <term>The APEX value is converted to an exposure time using this formula: For example, "2 sec."or "1/125 sec.".</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.ExposureTime</term>
			/// <term>For example, "2 sec."or "1/125 sec."</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.Aperture</term>
			/// <term>The APEX value is converted to an F number using this formula: For example, "f/5.6".</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.FNumber</term>
			/// <term>For example, "f/5.6".</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.SubjectDistance</term>
			/// <term>For example, "15 m"or "250 mm".</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.FocalLength</term>
			/// <term>For example, "50 mm".</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.FlashEnergy</term>
			/// <term>For example, "500 bpcs".</term>
			/// </item>
			/// <item>
			/// <term>System.Photo.ExposureBias</term>
			/// <term>For example, "-2 step", " 0 step", or "+3 step".</term>
			/// </item>
			/// <item>
			/// <term>System.Computer.DecoratedFreeSpace</term>
			/// <term>For example, "105 MB free of 13.2 GB".</term>
			/// </item>
			/// <item>
			/// <term>System.ItemType</term>
			/// <term>For example, "Application" or "JPEG Image".</term>
			/// </item>
			/// <item>
			/// <term>System.ControlPanel.Category</term>
			/// <term>For example, "Appearance and Personalization".</term>
			/// </item>
			/// <item>
			/// <term>System.ComputerName</term>
			/// <term>For example, "LITWARE05 (this computer)" or "testbox07".</term>
			/// </item>
			/// </list>
			/// <para>
			/// If the property key does not correspond to a property description in any of the registered property schemas, then this
			/// method chooses a format based on the type of the value.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Type of the value</term>
			/// <term>Format</term>
			/// </listheader>
			/// <item>
			/// <term>VT_BOOLEAN</term>
			/// <term>Not supported.</term>
			/// </item>
			/// <item>
			/// <term>VT_FILETIME</term>
			/// <term>
			/// Date/time string as specified by PROPDESC_FORMAT_FLAGS and the current locale. PDFF_SHORTTIME and PDFF_SHORTDATE are the
			/// default. For example, "11/13/2006 3:22 PM".
			/// </term>
			/// </item>
			/// <item>
			/// <term>Numeric VARTYPE</term>
			/// <term>Decimal string in the current locale. For example, "42".</term>
			/// </item>
			/// <item>
			/// <term>VT_LPWSTR or other</term>
			/// <term>Converted to a string. Sequences of "\r", "\t", or "\n" are replaced with a single space.</term>
			/// </item>
			/// <item>
			/// <term>VT_VECTOR | anything</term>
			/// <term>Semicolon separated values—a semicolon is used regardless of locale.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertysystem-formatfordisplayalloc HRESULT
			// FormatForDisplayAlloc( REFPROPERTYKEY key, REFPROPVARIANT propvar, PROPDESC_FORMAT_FLAGS pdff, LPWSTR *ppszDisplay );
			SafeCoTaskMemString FormatForDisplayAlloc(ref PROPERTYKEY key, PROPVARIANT propvar, PROPDESC_FORMAT_FLAGS pdff);

			/// <summary>Informs the schema subsystem of the addition of a property description schema file.</summary>
			/// <param name="pszPath">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to the file path for the .propdesc file on the local machine.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// This method informs the schema subsystem of the addition of a property description schema (.propdesc) file, using a file
			/// path to the .propdesc file on the local computer. Call this method only when the file has first been installed on the
			/// computer. Typically, a setup application calls this method after installing the .propdesc file, which should be stored in
			/// the install directory of the application under "Program Files". Multiple calls may be made to
			/// IPropertySystem::RegisterPropertySchema in order to batch-register multiple schema files.
			/// </para>
			/// <para>
			/// If a failure is encountered that prevents a property description from getting loaded, the cause will be recorded in the
			/// application event log. This method fails with E_ACCESSDENIED if the calling context does not have proper privileges, which
			/// include write access to HKLM (HKEY_LOCAL_MACHINE). It is the responsibility of the calling application to obtain privileges
			/// via limited user account (LUA) mechanisms.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertysystem-registerpropertyschema HRESULT
			// RegisterPropertySchema( LPCWSTR pszPath );
			void RegisterPropertySchema([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath);

			/// <summary>
			/// Informs the schema subsystem of the removal of a property description schema (.propdesc) file, using a file path to the
			/// .propdesc file on the local machine.
			/// </summary>
			/// <param name="pszPath">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>Pointer to the file path for the .propdesc file on the local machine.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// Call this method when the file is being uninstalled from the machine. Typically, a setup application calls this method
			/// before or after uninstalling the .propdesc file. This method can be called after the file no longer exists.
			/// </para>
			/// <para>
			/// Call IPropertySystem::RefreshPropertySchema in order for the newly-unregistered schema files to be unincorporated from the
			/// search index and the schema subsystem cache.
			/// </para>
			/// <para>
			/// This method fails with E_ACCESSDENIED if the calling context does not have proper privileges, which include write access to
			/// the local machine. It is the caller's responsibility to obtain privileges via least-privileged user account (LUA) mechanisms.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertysystem-unregisterpropertyschema HRESULT
			// UnregisterPropertySchema( LPCWSTR pszPath );
			void UnregisterPropertySchema([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath);

			/// <summary>Not supported.</summary>
			// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertysystem-refreshpropertyschema HRESULT RefreshPropertySchema();
			void RefreshPropertySchema();
		}

		/// <summary>Creates a local object of a specified class and returns a pointer to a specified interface on the object.</summary>
		/// <typeparam name="T">The type of the interface the created object should return.</typeparam>
		/// <param name="co">The <see cref="ICreateObject"/> instance.</param>
		/// <param name="clsid">
		/// <para>Type: <c>REFCLSID</c></para>
		/// <para>A reference to a CLSID.</para>
		/// </param>
		/// <param name="pUnkOuter">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// A pointer to the IUnknown interface that aggregates the object created by this function, or <c>NULL</c> if no aggregation is desired.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>void**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the interface requested in riid.</para>
		/// </returns>
		/// <remarks>This method can be used with GetPropertyStoreWithCreateObject.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-icreateobject-createobject HRESULT CreateObject( REFCLSID
		// clsid, IUnknown *pUnkOuter, REFIID riid, void **ppv );
		public static T CreateObject<T>(this ICreateObject co, in Guid clsid, [In, MarshalAs(UnmanagedType.IUnknown), Optional] object pUnkOuter) where T : class
		{
			co.CreateObject(clsid, pUnkOuter, typeof(T).GUID, out var ppv);
			return (T)ppv;
		}
	}

	/// <summary>Extension methods for <see cref="PropSys.IPropertyStore"/>.</summary>
	public static class PSExtensions
	{
		/// <summary>Enumerates the keys of a property store.</summary>
		/// <param name="ps">The <see cref="PropSys.IPropertyStore"/> instance used to retrieve the keys.</param>
		/// <returns>A sequence of keys found in the property store.</returns>
		public static System.Collections.Generic.IEnumerable<PROPERTYKEY> EnumKeys(this PropSys.IPropertyStore ps)
		{
			for (var i = 0U; i < ps.GetCount(); i++)
				yield return ps.GetAt(i);
		}

		/// <summary>Gets data for a specific property from a property store.</summary>
		/// <param name="ps">The <see cref="PropSys.IPropertyStore"/> instance from which to request the value.</param>
		/// <param name="pkey">The key whose value to retrieve.</param>
		/// <returns>An object with the property data or <see langword="null"/> if <paramref name="pkey"/> was not found.</returns>
		public static object GetValue(this PropSys.IPropertyStore ps, in PROPERTYKEY pkey)
		{
			using var pv = new PROPVARIANT();
			ps.GetValue(pkey, pv);
			return pv.Value;
		}

		/// <summary>Sets a new property value, or replaces or removes an existing value in a property store.</summary>
		/// <param name="ps">The <see cref="PropSys.IPropertyStore"/> instance used to set the value.</param>
		/// <param name="pkey">The key whose value to set.</param>
		/// <param name="value">The value to set or <see langword="null"/> to remove an existing value.</param>
		/// <param name="commit">
		/// If <see langword="true"/>, the <see cref="PropSys.IPropertyStore.Commit"/> method is called after setting the value.
		/// </param>
		public static void SetValue(this PropSys.IPropertyStore ps, in PROPERTYKEY pkey, object value, bool commit = true)
		{
			using var pv = new PROPVARIANT(value);
			ps.SetValue(pkey, pv);
			if (commit) ps.Commit();
		}
	}
}