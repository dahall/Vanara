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
		/// <summary>Provides a set of flags to be used with following methods to indicate the operation in ICondition::GetComparisonInfo, ICondition2::GetLeafConditionInfo, IConditionFactory::MakeLeaf, IConditionFactory2::CreateBooleanLeaf, IConditionFactory2::CreateIntegerLeaf, IConditionFactory2::MakeLeaf, IConditionFactory2::CreateStringLeaf, and IConditionGenerator::GenerateForLeaf.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "aa965691")]
		public enum CONDITION_OPERATION
		{ 
			/// <summary>An implicit comparison between the value of the property and the value of the constant. For an unresolved condition, COP_IMPLICIT means that a user did not type an operation. In contrast, a resolved condition will always have a condition other than the COP_IMPLICIT operation.</summary>
			COP_IMPLICIT              = 0,
			/// <summary>The value of the property and the value of the constant must be equal.</summary>
			COP_EQUAL                 = 1,
			/// <summary>The value of the property and the value of the constant must not be equal.</summary>
			COP_NOTEQUAL              = 2,
			/// <summary>The value of the property must be less than the value of the constant.</summary>
			COP_LESSTHAN              = 3,
			/// <summary>The value of the property must be greater than the value of the constant.</summary>
			COP_GREATERTHAN           = 4,
			/// <summary>The value of the property must be less than or equal to the value of the constant.</summary>
			COP_LESSTHANOREQUAL       = 5,
			/// <summary>The value of the property must be greater than or equal to the value of the constant.</summary>
			COP_GREATERTHANOREQUAL    = 6,
			/// <summary>The value of the property must begin with the value of the constant.</summary>
			COP_VALUE_STARTSWITH      = 7,
			/// <summary>The value of the property must end with the value of the constant.</summary>
			COP_VALUE_ENDSWITH        = 8,
			/// <summary>The value of the property must contain the value of the constant.</summary>
			COP_VALUE_CONTAINS        = 9,
			/// <summary>The value of the property must not contain the value of the constant.</summary>
			COP_VALUE_NOTCONTAINS     = 10,
			/// <summary>The value of the property must match the value of the constant, where '?' matches any single character and '*' matches any sequence of characters.</summary>
			COP_DOSWILDCARDS          = 11,
			/// <summary>The value of the property must contain a word that is the value of the constant.</summary>
			COP_WORD_EQUAL            = 12,
			/// <summary>The value of the property must contain a word that begins with the value of the constant.</summary>
			COP_WORD_STARTSWITH       = 13,
			/// <summary>The application is free to interpret this in any suitable way.</summary>
			COP_APPLICATION_SPECIFIC  = 14
		}

		/// <summary>Describes how property values are displayed when multiple items are selected. For a particular property, PROPDESC_AGGREGATION_TYPE describes how the property should be displayed when multiple items that have a value for the property are selected, such as whether the values should be summed, or averaged, or just displayed with the default "Multiple Values" string.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762522")]
		public enum PROPDESC_AGGREGATION_TYPE
		{
			/// <summary>Display the string "Multiple Values".</summary>
			PDAT_DEFAULT = 0,
			/// <summary>Display the first value in the selection.</summary>
			PDAT_FIRST = 1,
			/// <summary>Display the sum of the selected values. This flag is never returned for data types VT_LPWSTR, VT_BOOL, and VT_FILETIME.</summary>
			PDAT_SUM = 2,
			/// <summary>Display the numerical average of the selected values. This flag is never returned for data types VT_LPWSTR, VT_BOOL, and VT_FILETIME.</summary>
			PDAT_AVERAGE = 3,
			/// <summary>Display the date range of the selected values. This flag is returned only for values of the VT_FILETIME data type.</summary>
			PDAT_DATERANGE = 4,
			/// <summary>Display a concatenated string of all the values. The order of individual values in the string is undefined. The concatenated string omits duplicate values; if a value occurs more than once, it appears only once in the concatenated string.</summary>
			PDAT_UNION = 5,
			/// <summary>Display the highest of the selected values.</summary>
			PDAT_MAX = 6,
			/// <summary>Display the lowest of the selected values.</summary>
			PDAT_MIN = 7
		}

		/// <summary>Describes the condition type to use when displaying the property in the query builder UI in Windows Vista, but not in Windows 7 and later.</summary>
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
			/// <summary>The value is displayed as an enumerated type-list. Use IPropertyDescription::GetEnumTypeList to handle this type.</summary>
			PDDT_ENUMERATED = 4
		}

		/// <summary>Describes the filtered list of property descriptions that is returned.</summary>
		public enum PROPDESC_ENUMFILTER
		{
			/// <summary>The list contains all property descriptions in the system.</summary>
			PDEF_ALL = 0,        // All properties in system
								 /// <summary>The list contains system property descriptions only. It excludes third-party property descriptions that are registered on the computer.</summary>
			PDEF_SYSTEM = 1,        // Only system properties
									/// <summary>The list contains only third-party property descriptions that are registered on the computer.</summary>
			PDEF_NONSYSTEM = 2,        // Only non-system properties
									   /// <summary>The list contains only viewable properties, where &lt;typeInfo isViewable="true"&gt;.</summary>
			PDEF_VIEWABLE = 3,        // Only viewable properties
									  /// <summary>Deprecated in Windows 7 and later. The list contains only queryable properties, where &lt;typeInfo isViewable="true" isQueryable="true"&gt;.</summary>
			PDEF_QUERYABLE = 4,        // Deprecated
									   /// <summary>Deprecated in Windows 7 and later. The list contains only properties to be included in full-text queries.</summary>
			PDEF_INFULLTEXTQUERY = 5,        // Deprecated
											 /// <summary>The list contains only properties that are columns.</summary>
			PDEF_COLUMN = 6,        // Only properties that are columns
		}

		/// <summary>Used by property description helper functions, such as PSFormatForDisplay, to indicate the format of a property string.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762525")]
		[Flags]
		public enum PROPDESC_FORMAT_FLAGS
		{
			/// <summary>Use the format settings specified in the property's .propdesc file.</summary>
			PDFF_DEFAULT = 0,
			/// <summary>Precede the value with the property's display name. If the hideLabelPrefix attribute of the labelInfo element in the property's .propinfo file is set to true, then this flag is ignored.</summary>
			PDFF_PREFIXNAME = 0x1,
			/// <summary>Treat the string as a file name.</summary>
			PDFF_FILENAME = 0x2,
			/// <summary>Byte sizes are always displayed in KB, regardless of size. This enables clean alignment of the values in the column. This flag applies only to properties that have been declared as type Integer in the displayType attribute of the displayInfo element in the property's .propinfo file. This flag overrides the numberFormat setting.</summary>
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
			/// <summary>Return the invitation text if formatting failed or the value was empty. Invitation text is text displayed in a text box as a cue for the user, such as "Enter your name". Formatting can fail if the data entered is not of an expected type, such as when alpha characters have been entered in a phone-number field.</summary>
			PDFF_USEEDITINVITATION = 0x800,
			/// <summary>If this flag is used, the PDFF_USEEDITINVITATION flag must also be specified. When the formatting flags are PDFF_READONLY | PDFF_USEEDITINVITATION and the algorithm would have shown invitation text, a string is returned that indicates the value is "Unknown" instead of returning the invitation text.</summary>
			PDFF_READONLY = 0x1000,
			/// <summary>Do not detect reading order automatically. Useful when converting to ANSI to omit the Unicode reading order characters. However, reading order characters for some values are still returned.</summary>
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
			/// <summary>Displays percent groups returned by IPropertyDescription::GetEnumTypeList.		</summary>
			PDGR_ENUMERATED = 6
		}

		/// <summary>Describes the relative description type for a property description, as determined by the relativeDescriptionType attribute of the displayInfo element.</summary>
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
			/// <summary>"Oldest on top", "Newest on top"		</summary>
			PDSD_OLDEST_NEWEST = 4
		}

		/// <summary>Describes attributes of the typeInfo element in the property's .propdesc file.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762527")]
		[Flags]
		public enum PROPDESC_TYPE_FLAGS : uint
		{
			/// <summary>The property uses the default values for all attributes.</summary>
			PDTF_DEFAULT = 0,
			/// <summary>The property can have multiple values. These values are stored as a VT_VECTOR in the PROPVARIANT structure. This value is set by the multipleValues attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_MULTIPLEVALUES = 0x1,
			/// <summary>This flag indicates that a property is read-only, and cannot be written to. This value is set by the isInnate attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_ISINNATE = 0x2,
			/// <summary>The property is a group heading. This value is set by the isGroup attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_ISGROUP = 0x4,
			/// <summary>The user can group by this property. This value is set by the canGroupBy attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_CANGROUPBY = 0x8,
			/// <summary>The user can stack by this property. This value is set by the canStackBy attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_CANSTACKBY = 0x10,
			/// <summary>This property contains a hierarchy. This value is set by the isTreeProperty attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_ISTREEPROPERTY = 0x20,
			/// <summary>Deprecated in Windows 7 and later. Include this property in any full text query that is performed. This value is set by the includeInFullTextQuery attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_INCLUDEINFULLTEXTQUERY = 0x40,
			/// <summary>This property is meant to be viewed by the user. This influences whether the property shows up in the "Choose Columns" dialog box, for example. This value is set by the isViewable attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_ISVIEWABLE = 0x80,
			/// <summary>Deprecated in Windows 7 and later. This property is included in the list of properties that can be queried. A queryable property must also be viewable. This influences whether the property shows up in the query builder UI. This value is set by the isQueryable attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_ISQUERYABLE = 0x100,
			/// <summary>Windows Vista with Service Pack 1 (SP1) and later. Used with an innate property (that is, a value calculated from other property values) to indicate that it can be deleted. This value is used by the Remove Properties UI to determine whether to display a check box next to a property that enables that property to be selected for removal. Note that a property that is not innate can always be purged regardless of the presence or absence of this flag.</summary>
			PDTF_CANBEPURGED = 0x200,
			/// <summary>Windows 7 and later. The unformatted (raw) property value should be used for searching.</summary>
			PDTF_SEARCHRAWVALUE = 0x400,
			PDTF_DONTCOERCEEMPTYSTRINGS = 0x800,
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

		/// <summary><para>Exposes a method to create a specified IPropertyStore object in circumstances where property access is potentially slow.</para></summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nn-propsys-idelayedpropertystorefactory
		[PInvokeData("propsys.h", MSDNShortId = "855c9f10-9f40-4c60-a669-551fa51133f5")]
		[ComImport, Guid("40d4577f-e237-4bdb-bd69-58f089431b6a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IDelayedPropertyStoreFactory : IPropertyStoreFactory
		{
			/// <summary><para>Gets an IPropertyStore interface object, as specified.</para></summary><param name="flags"><para>Type: <c>GETPROPERTYSTOREFLAGS</c></para><para>The GPS_XXX flags that modify the store that is returned. See GETPROPERTYSTOREFLAGS.</para></param><param name="dwStoreId"><para>Type: <c>DWORD</c></para><para>The property store ID. Valid values are.</para><para>STOREID_INNATE</para><para>Value is 0.</para><para>STOREID_FILE</para><para>Value is 1.</para><para>STOREID_FALLBACK</para><para>Value is 2.</para></param><param name="riid"><para>Type: <c>REFIID</c></para><para>A reference to the desired IID.</para></param><param name="ppv"><para>Type: <c>void**</c></para><para>The address of an IPropertyStore interface pointer.</para></param><returns><para>Type: <c>HRESULT</c></para><para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para></returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-idelayedpropertystorefactory-getdelayedpropertystore
			// HRESULT GetDelayedPropertyStore( GETPROPERTYSTOREFLAGS flags, DWORD dwStoreId, REFIID riid, void **ppv );
			void GetDelayedPropertyStore(GETPROPERTYSTOREFLAGS flags, STOREID dwStoreId, in Guid riid, out IPropertyStore ppv);
		}

		/// <summary>Exposes a method that initializes a handler, such as a property handler, thumbnail handler, or preview handler, with a stream.</summary>
		[ComImport, Guid("b824b49d-22ac-4161-ac8a-9916e8fa3f7f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h", MSDNShortId = "bb761810")]
		public interface IInitializeWithStream
		{
			/// <summary>Initializes a handler with a stream.</summary>
			/// <param name="pstream">A pointer to an IStream interface that represents the stream source.</param>
			/// <param name="grfMode">One of the following STGM values that indicates the access mode for pstream. STGM_READ or STGM_READWRITE.</param>
			void Initialize(IStream pstream, STGM grfMode);
		}

		// <summary>Exposes methods that enumerate and retrieve individual property description details.</summary>
		[ComImport, Guid("6F79D558-3E96-4549-A1D1-7D75D2288814"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h", MSDNShortId = "bb761561")]
		public interface IPropertyDescription
		{
			/// <summary>Gets a structure that acts as a property's unique identifier.</summary>
			/// <returns>When this method returns, contains a pointer to a PROPERTYKEY structure.</returns>
			PROPERTYKEY GetPropertyKey();
			/// <summary>Gets the case-sensitive name by which a property is known to the system, regardless of its localized name.</summary>
			/// <returns>When this method returns, contains the address of a pointer to the property's canonical name as a null-terminated Unicode string.</returns>
			SafeCoTaskMemString GetCanonicalName();
			/// <summary>Gets the variant type of the property.</summary>
			/// <returns>When this method returns, contains a pointer to a VARTYPE that indicates the property type. If the property is multi-valued, the value pointed to is a VT_VECTOR mask (VT_VECTOR ORed to the VARTYPE.</returns>
			VARTYPE GetPropertyType();
			/// <summary>Gets the display name of the property as it is shown in any UI.</summary>
			/// <param name="pszName">Contains the address of a pointer to the property's name as a null-terminated Unicode string.</param>
			[PreserveSig]
			HRESULT GetDisplayName(out SafeCoTaskMemString pszName);
			/// <summary>Gets the text used in edit controls hosted in various dialog boxes.</summary>
			/// <returns>When this method returns, contains the address of a pointer to a null-terminated Unicode buffer that holds the invitation text.</returns>
			SafeCoTaskMemString GetEditInvitation();
			/// <summary>Gets a set of flags that describe the uses and capabilities of the property.</summary>
			/// <param name="mask">A mask that specifies which type flags to retrieve. A combination of values found in the PROPDESC_TYPE_FLAGS constants. To retrieve all type flags, pass PDTF_MASK_ALL</param>
			/// <returns>When this method returns, contains a pointer to a value that consists of bitwise PROPDESC_TYPE_FLAGS values.</returns>
			PROPDESC_TYPE_FLAGS GetTypeFlags([In] PROPDESC_TYPE_FLAGS mask);
			/// <summary>Gets the current set of flags governing the property's view.</summary>
			/// <returns>When this method returns, contains a pointer to a value that includes one or more of the following flags. See PROPDESC_VIEW_FLAGS for valid values.</returns>
			PROPDESC_VIEW_FLAGS GetViewFlags();
			/// <summary>Gets the default column width of the property in a list view.</summary>
			/// <returns>A pointer to the column width value, in characters.</returns>
			uint GetDefaultColumnWidth();
			/// <summary>Gets the current data type used to display the property.</summary>
			/// <returns>Contains a pointer to a value that indicates the display type.</returns>
			PROPDESC_DISPLAYTYPE GetDisplayType();
			/// <summary>Gets the column state flag, which describes how the property should be treated by interfaces or APIs that use this flag.</summary>
			/// <returns>When this method returns, contains a pointer to the column state flag.</returns>
			SHCOLSTATE GetColumnState();
			/// <summary>Gets the grouping method to be used when a view is grouped by a property, and retrieves the grouping type.</summary>
			/// <returns>Receives a pointer to a flag value that indicates the grouping type.</returns>
			PROPDESC_GROUPING_RANGE GetGroupingRange();
			/// <summary>Gets the relative description type for a property description.</summary>
			/// <returns>When this method returns, contains a pointer to the relative description type value. See PROPDESC_RELATIVEDESCRIPTION_TYPE for valid values.</returns>
			PROPDESC_RELATIVEDESCRIPTION_TYPE GetRelativeDescriptionType();
			/// <summary>Compares two property values in the manner specified by the property description. Returns two display strings that describe how the two properties compare.</summary>
			/// <param name="propvar1">A reference to a PROPVARIANT structure that contains the type and value of the first property.</param>
			/// <param name="propvar2">A reference to a PROPVARIANT structure that contains the type and value of the second property.</param>
			/// <param name="ppszDesc1">When this method returns, contains the address of a pointer to the description string that compares the first property with the second property. The string is null-terminated.</param>
			/// <param name="ppszDesc2">When this method returns, contains the address of a pointer to the description string that compares the second property with the first property. The string is null-terminated.</param>
			void GetRelativeDescription([In] PROPVARIANT propvar1, [In] PROPVARIANT propvar2, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszDesc1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszDesc2);
			/// <summary>Gets the current sort description flags for the property, which indicate the particular wordings of sort offerings.</summary>
			/// <returns>When this method returns, contains a pointer to the value of one or more of the following flags that indicate the sort types available to the user. Note that the strings shown are English versions only. Localized strings are used for other locales.</returns>
			PROPDESC_SORTDESCRIPTION GetSortDescription();
			/// <summary>Gets the localized display string that describes the current sort order.</summary>
			/// <param name="fDescending">TRUE if ppszDescription should reference the string "Z on top"; FALSE to reference the string "A on top".</param>
			/// <returns>When this method returns, contains the address of a pointer to the sort description as a null-terminated Unicode string.</returns>
			SafeCoTaskMemString GetSortDescriptionLabel([In, MarshalAs(UnmanagedType.Bool)] bool fDescending);
			/// <summary>Gets a value that describes how the property values are displayed when multiple items are selected in the UI.</summary>
			/// <returns>When this method returns, contains a pointer to a value that indicates the aggregation type.</returns>
			PROPDESC_AGGREGATION_TYPE GetAggregationType();
			/// <summary>Gets the condition type and default condition operation to use when displaying the property in the query builder UI. This influences the list of predicate conditions (for example, equals, less than, and contains) that are shown for this property.</summary>
			/// <param name="pcontype">A pointer to a value that indicates the condition type.</param>
			/// <param name="popDefault">When this method returns, contains a pointer to a value that indicates the default condition operation.</param>
			void GetConditionType(out PROPDESC_CONDITION_TYPE pcontype, out CONDITION_OPERATION popDefault);
			/// <summary>Gets an instance of an IPropertyEnumTypeList, which can be used to enumerate the possible values for a property.</summary>
			/// <param name="riid">Reference to the interface ID of the requested interface.</param>
			/// <returns>When this method returns, contains the address of an IPropertyEnumTypeList interface pointer.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyEnumTypeList GetEnumTypeList(in Guid riid);
			/// <summary>Coerces the value to the canonical value, according to the property description.</summary>
			/// <param name="propvar">On entry, contains a pointer to a PROPVARIANT structure that contains the original value. When this method returns, contains the canonical value.</param>
			[PreserveSig]
			HRESULT CoerceToCanonicalValue([In, Out] PROPVARIANT propvar);
			/// <summary>Gets a formatted, Unicode string representation of a property value.</summary>
			/// <param name="propvar">A reference to a PROPVARIANT structure that contains the type and value of the property.</param>
			/// <param name="pdfFlags">One or more of the PROPDESC_FORMAT_FLAGS flags, which are either bitwise or multiple values, that indicate the property string format.</param>
			/// <returns>When this method returns, contains the formatted value as a null-terminated, Unicode string. The calling application must allocate memory for the buffer, and use CoTaskMemFree to release the string specified by pszText when it is no longer needed.</returns>
			SafeCoTaskMemString FormatForDisplay([In] PROPVARIANT propvar, [In] PROPDESC_FORMAT_FLAGS pdfFlags);
			/// <summary>Gets a value that indicates whether a property is canonical according to the definition of the property description.</summary>
			/// <param name="propvar">A reference to a PROPVARIANT structure that contains the type and value of the property.</param>
			/// <returns>Returns one of the following values: S_OK = The value is canonical; S_FALSE = The value is not canonical.</returns>
			[PreserveSig]
			HRESULT IsValueCanonical([In] PROPVARIANT propvar);
		}

		[ComImport, Guid("57d2eded-5062-400e-b107-5dae79fe57a6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h", MSDNShortId = "bb761561")]
		public interface IPropertyDescription2 : IPropertyDescription
		{
			/// <summary>Gets a structure that acts as a property's unique identifier.</summary>
			/// <returns>When this method returns, contains a pointer to a PROPERTYKEY structure.</returns>
			new PROPERTYKEY GetPropertyKey();
			/// <summary>Gets the case-sensitive name by which a property is known to the system, regardless of its localized name.</summary>
			/// <returns>When this method returns, contains the address of a pointer to the property's canonical name as a null-terminated Unicode string.</returns>
			new SafeCoTaskMemString GetCanonicalName();
			/// <summary>Gets the variant type of the property.</summary>
			/// <returns>When this method returns, contains a pointer to a VARTYPE that indicates the property type. If the property is multi-valued, the value pointed to is a VT_VECTOR mask (VT_VECTOR ORed to the VARTYPE.</returns>
			new VARTYPE GetPropertyType();
			/// <summary>Gets the display name of the property as it is shown in any UI.</summary>
			/// <param name="pszName">Contains the address of a pointer to the property's name as a null-terminated Unicode string.</param>
			[PreserveSig]
			new HRESULT GetDisplayName(out SafeCoTaskMemString pszName);
			/// <summary>Gets the text used in edit controls hosted in various dialog boxes.</summary>
			/// <returns>When this method returns, contains the address of a pointer to a null-terminated Unicode buffer that holds the invitation text.</returns>
			new SafeCoTaskMemString GetEditInvitation();
			/// <summary>Gets a set of flags that describe the uses and capabilities of the property.</summary>
			/// <param name="mask">A mask that specifies which type flags to retrieve. A combination of values found in the PROPDESC_TYPE_FLAGS constants. To retrieve all type flags, pass PDTF_MASK_ALL</param>
			/// <returns>When this method returns, contains a pointer to a value that consists of bitwise PROPDESC_TYPE_FLAGS values.</returns>
			new PROPDESC_TYPE_FLAGS GetTypeFlags([In] PROPDESC_TYPE_FLAGS mask);
			/// <summary>Gets the current set of flags governing the property's view.</summary>
			/// <returns>When this method returns, contains a pointer to a value that includes one or more of the following flags. See PROPDESC_VIEW_FLAGS for valid values.</returns>
			new PROPDESC_VIEW_FLAGS GetViewFlags();
			/// <summary>Gets the default column width of the property in a list view.</summary>
			/// <returns>A pointer to the column width value, in characters.</returns>
			new uint GetDefaultColumnWidth();
			/// <summary>Gets the current data type used to display the property.</summary>
			/// <returns>Contains a pointer to a value that indicates the display type.</returns>
			new PROPDESC_DISPLAYTYPE GetDisplayType();
			/// <summary>Gets the column state flag, which describes how the property should be treated by interfaces or APIs that use this flag.</summary>
			/// <returns>When this method returns, contains a pointer to the column state flag.</returns>
			new SHCOLSTATE GetColumnState();
			/// <summary>Gets the grouping method to be used when a view is grouped by a property, and retrieves the grouping type.</summary>
			/// <returns>Receives a pointer to a flag value that indicates the grouping type.</returns>
			new PROPDESC_GROUPING_RANGE GetGroupingRange();
			/// <summary>Gets the relative description type for a property description.</summary>
			/// <returns>When this method returns, contains a pointer to the relative description type value. See PROPDESC_RELATIVEDESCRIPTION_TYPE for valid values.</returns>
			new PROPDESC_RELATIVEDESCRIPTION_TYPE GetRelativeDescriptionType();
			/// <summary>Compares two property values in the manner specified by the property description. Returns two display strings that describe how the two properties compare.</summary>
			/// <param name="propvar1">A reference to a PROPVARIANT structure that contains the type and value of the first property.</param>
			/// <param name="propvar2">A reference to a PROPVARIANT structure that contains the type and value of the second property.</param>
			/// <param name="ppszDesc1">When this method returns, contains the address of a pointer to the description string that compares the first property with the second property. The string is null-terminated.</param>
			/// <param name="ppszDesc2">When this method returns, contains the address of a pointer to the description string that compares the second property with the first property. The string is null-terminated.</param>
			new void GetRelativeDescription([In] PROPVARIANT propvar1, [In] PROPVARIANT propvar2, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszDesc1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszDesc2);
			/// <summary>Gets the current sort description flags for the property, which indicate the particular wordings of sort offerings.</summary>
			/// <returns>When this method returns, contains a pointer to the value of one or more of the following flags that indicate the sort types available to the user. Note that the strings shown are English versions only. Localized strings are used for other locales.</returns>
			new PROPDESC_SORTDESCRIPTION GetSortDescription();
			/// <summary>Gets the localized display string that describes the current sort order.</summary>
			/// <param name="fDescending">TRUE if ppszDescription should reference the string "Z on top"; FALSE to reference the string "A on top".</param>
			/// <returns>When this method returns, contains the address of a pointer to the sort description as a null-terminated Unicode string.</returns>
			new SafeCoTaskMemString GetSortDescriptionLabel([In, MarshalAs(UnmanagedType.Bool)] bool fDescending);
			/// <summary>Gets a value that describes how the property values are displayed when multiple items are selected in the UI.</summary>
			/// <returns>When this method returns, contains a pointer to a value that indicates the aggregation type.</returns>
			new PROPDESC_AGGREGATION_TYPE GetAggregationType();
			/// <summary>Gets the condition type and default condition operation to use when displaying the property in the query builder UI. This influences the list of predicate conditions (for example, equals, less than, and contains) that are shown for this property.</summary>
			/// <param name="pcontype">A pointer to a value that indicates the condition type.</param>
			/// <param name="popDefault">When this method returns, contains a pointer to a value that indicates the default condition operation.</param>
			new void GetConditionType(out PROPDESC_CONDITION_TYPE pcontype, out CONDITION_OPERATION popDefault);
			/// <summary>Gets an instance of an IPropertyEnumTypeList, which can be used to enumerate the possible values for a property.</summary>
			/// <param name="riid">Reference to the interface ID of the requested interface.</param>
			/// <returns>When this method returns, contains the address of an IPropertyEnumTypeList interface pointer.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new IPropertyEnumTypeList GetEnumTypeList(in Guid riid);
			/// <summary>Coerces the value to the canonical value, according to the property description.</summary>
			/// <param name="propvar">On entry, contains a pointer to a PROPVARIANT structure that contains the original value. When this method returns, contains the canonical value.</param>
			[PreserveSig]
			new HRESULT CoerceToCanonicalValue([In, Out] PROPVARIANT propvar);
			/// <summary>Gets a formatted, Unicode string representation of a property value.</summary>
			/// <param name="propvar">A reference to a PROPVARIANT structure that contains the type and value of the property.</param>
			/// <param name="pdfFlags">One or more of the PROPDESC_FORMAT_FLAGS flags, which are either bitwise or multiple values, that indicate the property string format.</param>
			/// <returns>When this method returns, contains the formatted value as a null-terminated, Unicode string. The calling application must allocate memory for the buffer, and use CoTaskMemFree to release the string specified by pszText when it is no longer needed.</returns>
			new SafeCoTaskMemString FormatForDisplay([In] PROPVARIANT propvar, [In] PROPDESC_FORMAT_FLAGS pdfFlags);
			/// <summary>Gets a value that indicates whether a property is canonical according to the definition of the property description.</summary>
			/// <param name="propvar">A reference to a PROPVARIANT structure that contains the type and value of the property.</param>
			/// <returns>Returns one of the following values: S_OK = The value is canonical; S_FALSE = The value is not canonical.</returns>
			[PreserveSig]
			new HRESULT IsValueCanonical([In] PROPVARIANT propvar);
			/// <summary>Gets the image reference associated with a property value.</summary>
			/// <param name="propvar">The PROPVARIANT for which to get an image.</param>
			/// <param name="ppszImageRes">A string that receives, when this method returns successfully, a string of the form &lt;dll name&gt;,-&lt;resid&gt; that is suitable to be passed to PathParseIconLocation.</param>
			/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			[PreserveSig]
			HRESULT GetImageReferenceForValue([In] PROPVARIANT propvar, out SafeCoTaskMemString ppszImageRes);
		}

		[ComImport, Guid("1F9FC1D0-C39B-4B26-817F-011967D3440E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h", MSDNShortId = "bb761511")]
		public interface IPropertyDescriptionList
		{
			uint GetCount();
			IPropertyDescription GetAt([In] uint iElem, in Guid riid);
		}

		/// <summary>
		/// Exposes methods that extract data from enumeration information. IPropertyEnumType gives access to the enum and enumRange elements in the property
		/// schema in a programmatic way at run time.
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
			/// <param name="ppszDisplay">When this method returns, contains the address of a pointer to a null-terminated Unicode string that contains the display text.</param>
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
			/// <param name="ppszDisplay">When this method returns, contains the address of a pointer to a null-terminated Unicode string that contains the display text.</param>
			new void GetDisplayText([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszDisplay);
			/// <summary>Retrieves the image reference associated with a property enumeration.</summary>
			/// <param name="ppszImageRes">A pointer to a buffer that, when this method returns successfully, receives a string of the form &lt;dll name&gt;,-&lt;resid&gt; that is suitable to be passed to PathParseIconLocation.</param>
			[PreserveSig] HRESULT GetImageReference([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszImageRes);
		}

		[ComImport, Guid("A99400F4-3D84-4557-94BA-1242FB2CC9A6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h")]
		public interface IPropertyEnumTypeList
		{
			uint GetCount();

			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyEnumType GetAt([In] uint itype, in Guid riid);

			[return: MarshalAs(UnmanagedType.Interface)]
			object GetConditionAt([In] uint index, in Guid riid);

			/// <summary>Compares the specified property value against the enumerated values in a list and returns the matching index.</summary>
			/// <param name="propvarCmp">A reference to a PROPVARIANT structure that represents the property value.</param>
			/// <param name="pnIndex">When this method returns, contains a pointer to the index in the enumerated type list that matches the property value, if any.</param>
			/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			[PreserveSig]
			HRESULT FindMatchingIndex([In] PROPVARIANT propvarCmp, out uint pnIndex);
		}

		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("886d8eeb-8cf2-4446-8d02-cdba1dbdcf99")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762502")]
		public interface IPropertyStore
		{
			uint GetCount();

			PROPERTYKEY GetAt(uint iProp);

			void GetValue(in PROPERTYKEY pkey, [In, Out] PROPVARIANT pv);

			void SetValue(in PROPERTYKEY pkey, [In] PROPVARIANT pv);

			void Commit();
		}

		/// <summary><para>Exposes methods to get an IPropertyStore object.</para></summary><remarks><para>This interface is typically obtained through IShellFolder::BindToObject or IShellItem::BindToHandler. It is useful for data source implementers who want to avoid the additional overhead of creating a property store through IShellItem2::GetPropertyStore. However, <c>IShellItem2::GetPropertyStore</c> is the recommended method to obtain a property store unless you are implementing a data source through a Shell folder extension.</para></remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nn-propsys-ipropertystorefactory
		[PInvokeData("propsys.h", MSDNShortId = "78ea822d-da8e-4883-b0eb-4277e7eb87a2")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("bc110b6d-57e8-4148-a9c6-91015ab2f3a5")]
		public interface IPropertyStoreFactory
		{
			/// <summary><para>Gets an IPropertyStore object that corresponds to the supplied flags.</para></summary><param name="flags"><para>Type: <c>GETPROPERTYSTOREFLAGS</c></para><para>GETPROPERTYSTOREFLAGS values that modify the store that is returned.</para></param><param name="pUnkFactory"><para>Type: <c>IUnknown*</c></para><para>Optional. A pointer to the IUnknown of an object that implements ICreateObject. If pUnkFactory is provided, this method can create the handler instance using <c>ICreateObject</c> rather than CoCreateInstance, if implemented. The reason to provide pUnkFactory is usually to create the handler in a different process. However, for most users, passing <c>NULL</c> in this parameter is sufficient.</para></param><param name="riid"><para>Type: <c>REFIID</c></para><para>A reference to IID of the object to create.</para></param><param name="ppv"><para>Type: <c>void**</c></para><para>When this method returns, contains the address of an IPropertyStore interface pointer.</para></param><returns><para>Type: <c>HRESULT</c></para><para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para></returns><remarks><para>It is recommended that you use the IID_PPV_ARGS macro, defined in Objbase.h, to package the riid and ppv parameters. This macro provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a coding error.</para></remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-ipropertystorefactory-getpropertystore
			// HRESULT GetPropertyStore( GETPROPERTYSTOREFLAGS flags, IUnknown *pUnkFactory, REFIID riid, void **ppv );
			void GetPropertyStore(GETPROPERTYSTOREFLAGS flags, [MarshalAs(UnmanagedType.IUnknown)] object pUnkFactory, in Guid riid, out IPropertyStore ppv);

			/// <summary><para>Gets an IPropertyStore object, given a set of property keys. This provides an alternative, possibly faster, method of getting an <c>IPropertyStore</c> object compared to calling IPropertyStoreFactory::GetPropertyStore.</para></summary><param name="rgKeys"><para>Type: <c>const PROPERTYKEY*</c></para><para>A pointer to an array of PROPERTYKEY structures.</para></param><param name="cKeys"><para>Type: <c>UINT</c></para><para>The number of PROPERTYKEY structures in the array pointed to by rgKeys.</para></param><param name="flags"><para>Type: <c>GETPROPERTYSTOREFLAGS</c></para><para>GETPROPERTYSTOREFLAGS values that modify the store that is returned.</para></param><param name="riid"><para>Type: <c>REFIID</c></para><para>A reference to IID of the object to create.</para></param><param name="ppv"><para>Type: <c>void**</c></para><para>When this method returns, contains the address of an IPropertyStore interface pointer.</para></param><returns><para>Type: <c>HRESULT</c></para><para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para></returns><remarks><para>It is recommended that you use the IID_PPV_ARGS macro, defined in Objbase.h, to package the riid and ppv parameters. This macro provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a coding error.</para></remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-ipropertystorefactory-getpropertystoreforkeys
			// HRESULT GetPropertyStoreForKeys( const PROPERTYKEY *rgKeys, UINT cKeys, GETPROPERTYSTOREFLAGS flags, REFIID riid, void **ppv );
			void GetPropertyStoreForKeys([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] PROPERTYKEY[] rgKeys, uint cKeys, GETPROPERTYSTOREFLAGS flags,
				in Guid riid, out IPropertyStore ppv);
		}

		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("ca724e8a-c3e6-442b-88a4-6fb0db8035a3")]
		[PInvokeData("PropSys.h")]
		public interface IPropertySystem
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyDescription GetPropertyDescription(ref PROPERTYKEY propkey, in Guid riid);

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
			/// macro provides the correct IID based on the interface pointed to by the value in ppv, eliminating the possibility of a coding error.
			/// </para>
			/// <para>For more information about property schemas, see Property Schemas.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-ipropertysystem-getpropertydescriptionlistfromstring
			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyDescriptionList GetPropertyDescriptionListFromString([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropList, in Guid riid);

			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyDescriptionList EnumeratePropertyDescriptions(PROPDESC_ENUMFILTER filterOn, in Guid riid);

			void FormatForDisplay(ref PROPERTYKEY key, PROPVARIANT propvar, PROPDESC_FORMAT_FLAGS pdff, System.Text.StringBuilder pszText, uint cchText);

			SafeCoTaskMemString FormatForDisplayAlloc(ref PROPERTYKEY key, PROPVARIANT propvar, PROPDESC_FORMAT_FLAGS pdff);

			void RegisterPropertySchema([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath);

			void UnregisterPropertySchema([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath);

			void RefreshPropertySchema();
		}
	}
}
