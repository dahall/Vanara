using System;
using System.Runtime.InteropServices;
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

		/// <summary>
		/// Indicates flags that modify the property store object retrieved by methods that create a property store, such as IShellItem2::GetPropertyStore or IPropertyStoreFactory::GetPropertyStore.
		/// </summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762582")]
		[Flags]
		public enum GETPROPERTYSTOREFLAGS
		{
			/// <summary>
			/// Meaning to a calling process: Succeed at getting the store, even if some properties are not returned. Note: Some values may be different, or
			/// missing, compared to a store without this flag.
			/// <para>
			/// Meaning to a file folder: Succeed and return a store, even if the handler or innate store has an error during creation. Only fail if substores fail.
			/// </para>
			/// <para>Meaning to other folders: Succeed on getting the store, even if some properties are not returned.</para>
			/// <para>Combination with other flags: Cannot be combined with GPS_TEMPORARY, GPS_READWRITE, or GPS_HANDLERPROPERTIESONLY.</para>
			/// </summary>
			GPS_BESTEFFORT = 0x40,

			/// <summary>
			/// Meaning to a calling process: Return a read-only property store that contains all properties. Slow items (offline files) are not opened.
			/// <para>Combination with other flags: Can be overridden by other flags.</para>
			/// </summary>
			GPS_DEFAULT = 0,

			/// <summary>
			/// Meaning to a calling process: Delay memory-intensive operations, such as file access, until a property is requested that requires such access.
			/// <para>
			/// Meaning to a file folder: Do not create the handler until needed; for example, either GetCount/GetAt or GetValue, where the innate store does not
			/// satisfy the request. Note: GetValue might fail due to file access problems.
			/// </para>
			/// <para>
			/// Meaning to other folders: If the folder has memory-intensive properties, such as delegating to a file folder or network access, it can optimize
			/// performance by supporting IDelayedPropertyStoreFactory and splitting up its properties into a fast and a slow store. It can then use delayed MUX
			/// to recombine them.
			/// </para>
			/// <para>Combination with other flags: Cannot be combined with GPS_TEMPORARY or GPS_READWRITE.</para>
			/// </summary>
			GPS_DELAYCREATION = 0x20,

			/// <summary>
			/// Meaning to a calling process: Provides a store that does not involve reading from the disk or network. Note: Some values may be different, or
			/// missing, compared to a store without this flag.
			/// <para>Meaning to a file folder: Include the "innate" and "fallback" stores only. Do not load the handler.</para>
			/// <para>
			/// Meaning to other folders: Include only properties that are available in memory or can be computed very quickly (no properties from disk, network,
			/// or peripheral IO devices). This is normally only data sources from the IDLIST. When delegating to other folders, pass this flag on to them.
			/// </para>
			/// <para>Combination with other flags: Cannot be combined with GPS_TEMPORARY, GPS_READWRITE, GPS_HANDLERPROPERTIESONLY, or GPS_DELAYCREATION.</para>
			/// </summary>
			GPS_FASTPROPERTIESONLY = 8,

			/// <summary>
			/// Meaning to a calling process: Include only properties directly from the property handler, which opens the file on the disk, network, or device.
			/// <para>Meaning to a file folder: Only include properties directly from the handler.</para>
			/// <para>
			/// Meaning to other folders: When delegating to a file folder, pass this flag on to the file folder; do not do any multiplexing (MUX). When not
			/// delegating to a file folder, ignore this flag instead of returning a failure code.
			/// </para>
			/// <para>Combination with other flags: Cannot be combined with GPS_TEMPORARY, GPS_FASTPROPERTIESONLY, or GPS_BESTEFFORT.</para>
			/// </summary>
			GPS_HANDLERPROPERTIESONLY = 1,

			/// <summary>Mask for valid GETPROPERTYSTOREFLAGS values.</summary>
			GPS_MASK_VALID = 0xff,

			/// <summary>
			/// Windows 7 and later. Callers should use this flag only if they are already holding an opportunistic lock (oplock) on the file because without an
			/// oplock, the bind operation cannot continue. By default, the Shell requests an oplock on a file before binding to the property handler. This flag
			/// disables the default behavior.
			/// <para><c>Windows Server 2008 and Windows Vista:</c> This flag is not available.</para>
			/// </summary>
			GPS_NO_OPLOCK = 0x80,

			/// <summary>
			/// Meaning to a calling process: Open a slow item (offline file) if necessary.
			/// <para>
			/// Meaning to a file folder: Retrieve a file from offline storage, if necessary. Note: Without this flag, the handler is not created for offline files.
			/// </para>
			/// <para>Meaning to other folders: Do not return any properties that are very slow.</para>
			/// <para>Combination with other flags: Cannot be combined with GPS_TEMPORARY or GPS_FASTPROPERTIESONLY.</para>
			/// </summary>
			GPS_OPENSLOWITEM = 0x10,

			/// <summary>
			/// Meaning to a calling process: Can write properties to the item. Note: The store may contain fewer properties than a read-only store.
			/// <para>Meaning to a file folder: ReadWrite.</para>
			/// <para>
			/// Meaning to other folders: ReadWrite. Note: When using default MUX, return a single unmultiplexed store because the default MUX does not support ReadWrite.
			/// </para>
			/// <para>
			/// Combination with other flags: Cannot be combined with GPS_TEMPORARY, GPS_FASTPROPERTIESONLY, GPS_BESTEFFORT, or GPS_DELAYCREATION. Implies GPS_HANDLERPROPERTIESONLY.
			/// </para>
			/// </summary>
			GPS_READWRITE = 2,

			/// <summary>
			/// Meaning to a calling process: Provides a writable store, with no initial properties, that exists for the lifetime of the Shell item instance;
			/// basically, a property bag attached to the item instance.
			/// <para>Meaning to a file folder: Not applicable. Handled by the Shell item.</para>
			/// <para>Meaning to other folders: Not applicable. Handled by the Shell item.</para>
			/// <para>Combination with other flags: Cannot be combined with any other flag. Implies GPS_READWRITE.</para>
			/// </summary>
			GPS_TEMPORARY = 4,

			/// <summary>Windows 8 and later. Use this flag to retrieve only properties from the indexer for WDS results.</summary>
			GPS_PREFERQUERYPROPERTIES = 0x100,

			/// <summary>Include properties from the file's secondary stream.</summary>
			GPS_EXTRINSICPROPERTIES = 0x200,

			/// <summary>Include only properties from the file's secondary stream.</summary>
			GPS_EXTRINSICPROPERTIESONLY = 0x400,
		}

		/// <summary>Describes attributes of the typeInfo element in the property's .propdesc file.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762527")]
		[Flags]
		public enum PROPDESC_TYPE_FLAGS : uint
		{
			/// <summary>The property uses the default values for all attributes.</summary>
			PDTF_DEFAULT	= 0,
			/// <summary>The property can have multiple values. These values are stored as a VT_VECTOR in the PROPVARIANT structure. This value is set by the multipleValues attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_MULTIPLEVALUES	= 0x1,
			/// <summary>This flag indicates that a property is read-only, and cannot be written to. This value is set by the isInnate attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_ISINNATE	= 0x2,
			/// <summary>The property is a group heading. This value is set by the isGroup attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_ISGROUP	= 0x4,
			/// <summary>The user can group by this property. This value is set by the canGroupBy attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_CANGROUPBY	= 0x8,
			/// <summary>The user can stack by this property. This value is set by the canStackBy attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_CANSTACKBY	= 0x10,
			/// <summary>This property contains a hierarchy. This value is set by the isTreeProperty attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_ISTREEPROPERTY	= 0x20,
			/// <summary>Deprecated in Windows 7 and later. Include this property in any full text query that is performed. This value is set by the includeInFullTextQuery attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_INCLUDEINFULLTEXTQUERY	= 0x40,
			/// <summary>This property is meant to be viewed by the user. This influences whether the property shows up in the "Choose Columns" dialog box, for example. This value is set by the isViewable attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_ISVIEWABLE	= 0x80,
			/// <summary>Deprecated in Windows 7 and later. This property is included in the list of properties that can be queried. A queryable property must also be viewable. This influences whether the property shows up in the query builder UI. This value is set by the isQueryable attribute of the typeInfo element in the property's .propdesc file.</summary>
			PDTF_ISQUERYABLE	= 0x100,
			/// <summary>Windows Vista with Service Pack 1 (SP1) and later. Used with an innate property (that is, a value calculated from other property values) to indicate that it can be deleted. This value is used by the Remove Properties UI to determine whether to display a check box next to a property that enables that property to be selected for removal. Note that a property that is not innate can always be purged regardless of the presence or absence of this flag.</summary>
			PDTF_CANBEPURGED	= 0x200,
			/// <summary>Windows 7 and later. The unformatted (raw) property value should be used for searching.</summary>
			PDTF_SEARCHRAWVALUE	= 0x400,
			PDTF_DONTCOERCEEMPTYSTRINGS	= 0x800,
			PDTF_ALWAYSINSUPPLEMENTALSTORE	= 0x1000,
			/// <summary>This property is owned by the system.</summary>
			PDTF_ISSYSTEMPROPERTY	= 0x80000000,
			/// <summary>A mask used to retrieve all flags.</summary>
			PDTF_MASK_ALL	= 0x80001fff
		}

		/// <summary>These flags describe properties in property description list strings.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762528")]
		[Flags]
		public enum PROPDESC_VIEW_FLAGS
		{
			/// <summary>Show this property by default.</summary>
			PDVF_DEFAULT	= 0,
			/// <summary>This property should be centered.</summary>
			PDVF_CENTERALIGN	= 0x1,
			/// <summary>This property should be right aligned.</summary>
			PDVF_RIGHTALIGN	= 0x2,
			/// <summary>Show this property as the beginning of the next collection of properties in the view.</summary>
			PDVF_BEGINNEWGROUP	= 0x4,
			/// <summary>Fill the remainder of the view area with the content of this property.</summary>
			PDVF_FILLAREA	= 0x8,
			/// <summary>Sort this property in reverse (descending) order. Applies to a property in a list of sorted properties.</summary>
			PDVF_SORTDESCENDING	= 0x10,
			/// <summary>Show this property only if it is present.</summary>
			PDVF_SHOWONLYIFPRESENT	= 0x20,
			/// <summary>This property should be shown by default in a view (where applicable).</summary>
			PDVF_SHOWBYDEFAULT	= 0x40,
			/// <summary>This property should be shown by default in the primary column selection UI.</summary>
			PDVF_SHOWINPRIMARYLIST	= 0x80,
			/// <summary>This property should be shown by default in the secondary column selection UI.</summary>
			PDVF_SHOWINSECONDARYLIST	= 0x100,
			/// <summary>Hide the label of this property if the view normally shows the label.</summary>
			PDVF_HIDELABEL	= 0x200,
			/// <summary>This property should not be displayed as a column in the UI.</summary>
			PDVF_HIDDEN	= 0x800,
			/// <summary>This property can be wrapped to the next row.</summary>
			PDVF_CANWRAP	= 0x1000,
			/// <summary>A mask used to retrieve all flags.</summary>
			PDVF_MASK_ALL	= 0x1bff
		}

		/// <summary>A value that indicates the display type.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb761535")]
		public enum PROPDESC_DISPLAYTYPE
		{
			/// <summary>The value is displayed as a string.</summary>
			PDDT_STRING	= 0,
			/// <summary>The value is displayed as an integer.</summary>
			PDDT_NUMBER	= 1,
			/// <summary>The value is displayed as a Boolean value.</summary>
			PDDT_BOOLEAN	= 2,
			/// <summary>The value is displayed as date and time.</summary>
			PDDT_DATETIME	= 3,
			/// <summary>The value is displayed as an enumerated type-list. Use IPropertyDescription::GetEnumTypeList to handle this type.</summary>
			PDDT_ENUMERATED	= 4
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

		/// <summary>A flag value that indicates the grouping type.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb761542")]
		public enum PROPDESC_GROUPING_RANGE
		{
			/// <summary>Displays individual values.</summary>
			PDGR_DISCRETE	= 0,
			/// <summary>Displays static alphanumeric ranges.</summary>
			PDGR_ALPHANUMERIC	= 1,
			/// <summary>Displays static size ranges.</summary>
			PDGR_SIZE	= 2,
			/// <summary>Displays dynamically created ranges.</summary>
			PDGR_DYNAMIC	= 3,
			/// <summary>Displays month and year groups.</summary>
			PDGR_DATE	= 4,
			/// <summary>Displays percent groups.</summary>
			PDGR_PERCENT	= 5,
			/// <summary>Displays percent groups returned by IPropertyDescription::GetEnumTypeList.		</summary>
			PDGR_ENUMERATED	= 6
		}

		/// <summary>Used by property description helper functions, such as PSFormatForDisplay, to indicate the format of a property string.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762525")]
		[Flags]
		public enum PROPDESC_FORMAT_FLAGS
		{
			/// <summary>Use the format settings specified in the property's .propdesc file.</summary>
			PDFF_DEFAULT	= 0,
			/// <summary>Precede the value with the property's display name. If the hideLabelPrefix attribute of the labelInfo element in the property's .propinfo file is set to true, then this flag is ignored.</summary>
			PDFF_PREFIXNAME	= 0x1,
			/// <summary>Treat the string as a file name.</summary>
			PDFF_FILENAME	= 0x2,
			/// <summary>Byte sizes are always displayed in KB, regardless of size. This enables clean alignment of the values in the column. This flag applies only to properties that have been declared as type Integer in the displayType attribute of the displayInfo element in the property's .propinfo file. This flag overrides the numberFormat setting.</summary>
			PDFF_ALWAYSKB	= 0x4,
			/// <summary>Reserved.</summary>
			PDFF_RESERVED_RIGHTTOLEFT	= 0x8,
			/// <summary>Display time as "hh:mm am/pm".</summary>
			PDFF_SHORTTIME	= 0x10,
			/// <summary>Display time as "hh:mm:ss am/pm".</summary>
			PDFF_LONGTIME	= 0x20,
			/// <summary>Hide the time portion of datetime.</summary>
			PDFF_HIDETIME	= 0x40,
			/// <summary>Display date as "MM/DD/YY". For example, "03/21/04".</summary>
			PDFF_SHORTDATE	= 0x80,
			/// <summary>Display date as "DayOfWeek, Month day, year". For example, "Monday, March 21, 2009".</summary>
			PDFF_LONGDATE	= 0x100,
			/// <summary>Hide the date portion of datetime.</summary>
			PDFF_HIDEDATE	= 0x200,
			/// <summary>Use friendly date descriptions. For example, "Yesterday".</summary>
			PDFF_RELATIVEDATE	= 0x400,
			/// <summary>Return the invitation text if formatting failed or the value was empty. Invitation text is text displayed in a text box as a cue for the user, such as "Enter your name". Formatting can fail if the data entered is not of an expected type, such as when alpha characters have been entered in a phone-number field.</summary>
			PDFF_USEEDITINVITATION	= 0x800,
			/// <summary>If this flag is used, the PDFF_USEEDITINVITATION flag must also be specified. When the formatting flags are PDFF_READONLY | PDFF_USEEDITINVITATION and the algorithm would have shown invitation text, a string is returned that indicates the value is "Unknown" instead of returning the invitation text.</summary>
			PDFF_READONLY	= 0x1000,
			/// <summary>Do not detect reading order automatically. Useful when converting to ANSI to omit the Unicode reading order characters. However, reading order characters for some values are still returned.</summary>
			PDFF_NOAUTOREADINGORDER	= 0x2000
		}

		/// <summary>Indicate the sort types available to the user.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb761551")]
		public enum PROPDESC_SORTDESCRIPTION
		{
			/// <summary>Default. "Sort going up", "Sort going down"</summary>
			PDSD_GENERAL	= 0,
			/// <summary>"A on top", "Z on top"</summary>
			PDSD_A_Z	= 1,
			/// <summary>"Lowest on top", "Highest on top"</summary>
			PDSD_LOWEST_HIGHEST	= 2,
			/// <summary>"Smallest on top", "Largest on top"</summary>
			PDSD_SMALLEST_BIGGEST	= 3,
			/// <summary>"Oldest on top", "Newest on top"		</summary>
			PDSD_OLDEST_NEWEST	= 4
		}

		/// <summary>Describes the relative description type for a property description, as determined by the relativeDescriptionType attribute of the displayInfo element.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762526")]
		public enum PROPDESC_RELATIVEDESCRIPTION_TYPE
		{
			/// <summary>General type.</summary>
			PDRDT_GENERAL	= 0,
			/// <summary>Date type.</summary>
			PDRDT_DATE	= 1,
			/// <summary>Size type.</summary>
			PDRDT_SIZE	= 2,
			/// <summary>Count type.</summary>
			PDRDT_COUNT	= 3,
			/// <summary>Revision type.</summary>
			PDRDT_REVISION	= 4,
			/// <summary>Length type.</summary>
			PDRDT_LENGTH	= 5,
			/// <summary>Duration type.</summary>
			PDRDT_DURATION	= 6,
			/// <summary>Speed type.</summary>
			PDRDT_SPEED	= 7,
			/// <summary>Rate type.</summary>
			PDRDT_RATE	= 8,
			/// <summary>Rating type.</summary>
			PDRDT_RATING	= 9,
			/// <summary>Priority type.</summary>
			PDRDT_PRIORITY	= 10
		}

		/// <summary>Describes how property values are displayed when multiple items are selected. For a particular property, PROPDESC_AGGREGATION_TYPE describes how the property should be displayed when multiple items that have a value for the property are selected, such as whether the values should be summed, or averaged, or just displayed with the default "Multiple Values" string.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762522")]
		public enum PROPDESC_AGGREGATION_TYPE
		{
			/// <summary>Display the string "Multiple Values".</summary>
			PDAT_DEFAULT	= 0,
			/// <summary>Display the first value in the selection.</summary>
			PDAT_FIRST	= 1,
			/// <summary>Display the sum of the selected values. This flag is never returned for data types VT_LPWSTR, VT_BOOL, and VT_FILETIME.</summary>
			PDAT_SUM	= 2,
			/// <summary>Display the numerical average of the selected values. This flag is never returned for data types VT_LPWSTR, VT_BOOL, and VT_FILETIME.</summary>
			PDAT_AVERAGE	= 3,
			/// <summary>Display the date range of the selected values. This flag is returned only for values of the VT_FILETIME data type.</summary>
			PDAT_DATERANGE	= 4,
			/// <summary>Display a concatenated string of all the values. The order of individual values in the string is undefined. The concatenated string omits duplicate values; if a value occurs more than once, it appears only once in the concatenated string.</summary>
			PDAT_UNION	= 5,
			/// <summary>Display the highest of the selected values.</summary>
			PDAT_MAX	= 6,
			/// <summary>Display the lowest of the selected values.</summary>
			PDAT_MIN	= 7
		}

		/// <summary>Describes the condition type to use when displaying the property in the query builder UI in Windows Vista, but not in Windows 7 and later.</summary>
		[PInvokeData("Propsys.h", MSDNShortId = "bb762523")]
		public enum PROPDESC_CONDITION_TYPE
		{
			/// <summary>The default value; it means the condition type is unspecified.</summary>
			PDCOT_NONE	= 0,
			/// <summary>Use the string condition type.</summary>
			PDCOT_STRING	= 1,
			/// <summary>Use the size condition type.</summary>
			PDCOT_SIZE	= 2,
			/// <summary>Use the date/time condition type.</summary>
			PDCOT_DATETIME	= 3,
			/// <summary>Use the Boolean condition type.</summary>
			PDCOT_BOOLEAN	= 4,
			/// <summary>Use the number condition type.</summary>
			PDCOT_NUMBER	= 5
		}

		/// <summary>Gets an instance of a property description interface for a property specified by a PROPERTYKEY structure.</summary>
		/// <param name="propkey">Reference to a PROPERTYKEY.</param>
		/// <param name="riid">Reference to the interface ID of the requested interface.</param>
		/// <param name="ppv">
		/// When this function returns, contains the interface pointer requested in riid. This is typically IPropertyDescription, IPropertyDescriptionAliasInfo,
		/// or IPropertyDescriptionSearchInfo.
		/// </param>
		/// <returns>The result of the operation. S_OK indicates success.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propsys.h", MSDNShortId = "bb776503")]
		public static extern HRESULT PSGetPropertyDescription(ref PROPERTYKEY propkey, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppv);

		/// <summary>
		/// Retrieves the property's canonical name given its PROPERTYKEY.
		/// </summary>
		/// <param name="propkey">A pointer to a PROPERTYKEY structure containing the property's identifiers.</param>
		/// <param name="ppszCanonicalName">The address of a pointer to a buffer that receives the property name as a null-terminated Unicode string.</param>
		/// <returns>The result of the operation. S_OK indicates success.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propsys.h", MSDNShortId = "bb776502")]
		public static extern HRESULT PSGetNameFromPropertyKey(ref PROPERTYKEY propkey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszCanonicalName);

		/// <summary>Gets the property key for a canonical property name.</summary>
		/// <param name="pszName">Pointer to a property name as a null-terminated, Unicode string.</param>
		/// <param name="ppropkey">When this function returns, contains the requested property key.</param>
		/// <returns>The result of the operation. S_OK indicates success.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propsys.h", MSDNShortId = "bb762081")]
		public static extern HRESULT PSGetPropertyKeyFromName([MarshalAs(UnmanagedType.LPWStr)] string pszName, out PROPERTYKEY ppropkey);

		[ComImport, Guid("1F9FC1D0-C39B-4B26-817F-011967D3440E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h", MSDNShortId = "bb761511")]
		public interface IPropertyDescriptionList
		{
			uint GetCount();
			IPropertyDescription GetAt([In] uint iElem, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
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
			/// <returns>Contains the address of a pointer to the property's name as a null-terminated Unicode string.</returns>
			SafeCoTaskMemString GetDisplayName();
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
			/// <returns>When this method returns, contains the address of an IPropertyEnumTypeList interface pointer.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			object GetEnumTypeList();
			/// <summary>Coerces the value to the canonical value, according to the property description.</summary>
			/// <param name="propvar">On entry, contains a pointer to a PROPVARIANT structure that contains the original value. When this method returns, contains the canonical value.</param>
			[PreserveSig]
			HRESULT CoerceToCanonicalValue([In, Out] PROPVARIANT propvar);
			/// <summary>Gets a formatted, Unicode string representation of a property value.</summary>
			/// <param name="key">A reference to the requested property key, which identifies a property. See PROPERTYKEY.</param>
			/// <param name="propvar">A reference to a PROPVARIANT structure that contains the type and value of the property.</param>
			/// <param name="pdfFlags">One or more of the PROPDESC_FORMAT_FLAGS flags, which are either bitwise or multiple values, that indicate the property string format.</param>
			/// <param name="pszText">When this method returns, contains the formatted value as a null-terminated, Unicode string. The calling application must allocate memory for the buffer, and use CoTaskMemFree to release the string specified by pszText when it is no longer needed.</param>
			/// <param name="cchText">The length of the buffer at pszText in WCHARS, including the terminating NULL. The maximum size is 0x8000 (32K).</param>
			void FormatForDisplay([In] ref PROPERTYKEY key, [In] PROPVARIANT propvar, [In] PROPDESC_FORMAT_FLAGS pdfFlags, System.Text.StringBuilder pszText, uint cchText);
			/// <summary>Gets a value that indicates whether a property is canonical according to the definition of the property description.</summary>
			/// <param name="propvar">A reference to a PROPVARIANT structure that contains the type and value of the property.</param>
			/// <returns>Returns one of the following values: S_OK = The value is canonical; S_FALSE = The value is not canonical.</returns>
			[PreserveSig]
			HRESULT IsValueCanonical([In] PROPVARIANT propvar);
		}

		[ComImport, Guid("11E1FBF9-2D56-4A6B-8DB3-7CD193A471F2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h")]
		public interface IPropertyEnumType
		{
			PROPENUMTYPE GetEnumType();

			PROPVARIANT GetValue();

			PROPVARIANT GetRangeMinValue();

			PROPVARIANT GetRangeSetValue();

			SafeCoTaskMemString GetDisplayText();
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

		[ComImport, Guid("9B6E051C-5DDD-4321-9070-FE2ACB55E794"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h")]
		public interface IPropertyEnumType2 : IPropertyEnumType
		{
			new PROPENUMTYPE GetEnumType();

			new PROPVARIANT GetValue();

			new PROPVARIANT GetRangeMinValue();

			new PROPVARIANT GetRangeSetValue();

			new SafeCoTaskMemString GetDisplayText();

			SafeCoTaskMemString GetImageReference();
		}


		[ComImport, Guid("A99400F4-3D84-4557-94BA-1242FB2CC9A6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Propsys.h")]
		public interface IPropertyEnumTypeList
		{
			uint GetCount();

			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyEnumType GetAt([In] uint itype, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			[return: MarshalAs(UnmanagedType.Interface)]
			object GetConditionAt([In] uint index, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			uint FindMatchingIndex([In] PROPVARIANT propvarCmp);
		}

		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("886d8eeb-8cf2-4446-8d02-cdba1dbdcf99")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762502")]
		public interface IPropertyStore
		{
			uint GetCount();

			PROPERTYKEY GetAt(uint iProp);

			void GetValue([In] ref PROPERTYKEY pkey, [In, Out] PROPVARIANT pv);

			void SetValue([In] ref PROPERTYKEY pkey, [In] PROPVARIANT pv);

			void Commit();
		}

		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("ca724e8a-c3e6-442b-88a4-6fb0db8035a3")]
		[PInvokeData("PropSys.h")]
		public interface IPropertySystem
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyDescription GetPropertyDescription(ref PROPERTYKEY propkey, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyDescription GetPropertyDescriptionByName([In, MarshalAs(UnmanagedType.LPWStr)] string pszCanonicalName, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyDescriptionList GetPropertyDescriptionListFromString([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropList, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			[return: MarshalAs(UnmanagedType.Interface)]
			IPropertyDescriptionList EnumeratePropertyDescriptions(PROPDESC_ENUMFILTER filterOn, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

			void FormatForDisplay(ref PROPERTYKEY key, PROPVARIANT propvar, PROPDESC_FORMAT_FLAGS pdff, System.Text.StringBuilder pszText, uint cchText);

			SafeCoTaskMemString FormatForDisplayAlloc(ref PROPERTYKEY key, PROPVARIANT propvar, PROPDESC_FORMAT_FLAGS pdff);

			void RegisterPropertySchema([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath);

			void UnregisterPropertySchema([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath);

			void RefreshPropertySchema();
		}
	}
}