using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.Windows.Shell;

/// <summary>Enumerate and retrieve individual property description details. Wraps the <see cref="IPropertyDescription"/> shell interface</summary>
/// <seealso cref="IDisposable"/>
public class PropertyDescription : IDisposable
{
	/// <summary>The IPropertyDescription object.</summary>
	protected IPropertyDescription iDesc;
	/// <summary>The IPropertyDescription2 object.</summary>
	protected IPropertyDescription2? iDesc2;
	/// <summary>The property key for this property.</summary>
	protected PROPERTYKEY key;
	/// <summary>Gets the type list.</summary>
	protected PropertyTypeList? typeList;

	/// <summary>Initializes a new instance of the <see cref="PropertyDescription"/> class.</summary>
	/// <param name="propertyDescription">The property description.</param>
	/// <param name="pkey">The associated property key.</param>
	protected internal PropertyDescription(IPropertyDescription propertyDescription, PROPERTYKEY? pkey = null)
	{
		iDesc = propertyDescription;
		key = pkey ?? iDesc.GetPropertyKey();
	}

	/// <summary>Initializes a new instance of the <see cref="PropertyDescription"/> class from a specified property key.</summary>
	/// <param name="propkey">The property key.</param>
	public PropertyDescription(PROPERTYKEY propkey)
	{
		PSGetPropertyDescription(propkey, typeof(IPropertyDescription).GUID, out var ppv).ThrowIfFailed();
		iDesc = (IPropertyDescription)ppv;
		key = propkey;
	}

	/// <summary>Initializes a new instance of the <see cref="PropertyDescription"/> class from a property name.</summary>
	/// <param name="name">A string that identifies the property.</param>
	public PropertyDescription(string name)
	{
		PSGetPropertyDescriptionByName(name, typeof(IPropertyDescription).GUID, out var ppv).ThrowIfFailed();
		iDesc = (IPropertyDescription)ppv;
		key = iDesc.GetPropertyKey();
	}

	/// <summary>Creates a <see cref="PropertyDescription"/> instance from a specified property key.</summary>
	/// <param name="propkey">The property key.</param>
	/// <returns>An associated instance of <see cref="PropertyDescription"/> or <see langword="null"/> if the PROPERTYKEY does not exist in the schema subsystem cache.</returns>
	public static PropertyDescription? Create(PROPERTYKEY propkey) => PSGetPropertyDescription(propkey, typeof(IPropertyDescription).GUID, out var ppv).Succeeded ? new PropertyDescription((IPropertyDescription)ppv, propkey) : null;

	/// <summary>Creates a <see cref="PropertyDescription"/> instance from a property key name.</summary>
	/// <param name="name">A string that identifies the property.</param>
	/// <returns>An associated instance of <see cref="PropertyDescription"/> or <see langword="null"/> if the PROPERTYKEY does not exist in the schema subsystem cache.</returns>
	public static PropertyDescription? Create(string name) => PSGetPropertyDescriptionByName(name, typeof(IPropertyDescription).GUID, out var ppv).Succeeded ? new PropertyDescription((IPropertyDescription)ppv) : null;

	/// <summary>Tries to create a <see cref="PropertyDescription"/> instance from a specified property key.</summary>
	/// <param name="propkey">The property key.</param>
	/// <param name="desc">
	/// An associated instance of <see cref="PropertyDescription"/> or <see langword="null"/> if the PROPERTYKEY does not exist in the
	/// schema subsystem cache.
	/// </param>
	/// <returns><see langword="true"/> if the supplied property key exists; otherwise <see langword="false"/>.</returns>
	public static bool TryCreate(PROPERTYKEY propkey, [NotNullWhen(true)] out PropertyDescription? desc)
	{
		if (PSGetPropertyDescription(propkey, typeof(IPropertyDescription).GUID, out var ppv).Succeeded)
		{
			desc = new PropertyDescription((IPropertyDescription)ppv, propkey);
			return true;
		}

		desc = null;
		return false;
	}

	/// <summary>Gets a value that describes how the property values are displayed when multiple items are selected in the UI.</summary>
	public PROPDESC_AGGREGATION_TYPE AggregationType => iDesc?.GetAggregationType() ?? 0;

	/// <summary>Gets a value indicating whether the user can group by this property.</summary>
	/// <value><see langword="true"/> if the user can group by this property; otherwise, <see langword="false"/>.</value>
	public bool CanGroupBy => (iDesc?.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_CANGROUPBY) ?? 0) == PROPDESC_TYPE_FLAGS.PDTF_CANGROUPBY;

	/// <summary>Gets the case-sensitive name by which a property is known to the system, regardless of its localized name.</summary>
	public string? CanonicalName => iDesc?.GetCanonicalName();

	/// <summary>Gets the column state flag, which describes how the property should be treated by interfaces or APIs that use this flag.</summary>
	public SHCOLSTATE ColumnState => iDesc?.GetColumnState() ?? 0;

	/// <summary>Gets the condition type and default condition operation to use when displaying the property in the query builder UI. This influences the list of predicate conditions (for example, equals, less than, and contains) that are shown for this property.</summary>
	public Tuple<PROPDESC_CONDITION_TYPE, CONDITION_OPERATION> ConditionType
	{
		get
		{
			PROPDESC_CONDITION_TYPE ct = 0;
			CONDITION_OPERATION co = 0;
			iDesc?.GetConditionType(out ct, out co);
			return new Tuple<PROPDESC_CONDITION_TYPE, CONDITION_OPERATION>(ct, co);
		}
	}

	/// <summary>Gets the default column width of the property in a list view.</summary>
	/// <returns>A pointer to the column width value, in characters.</returns>
	public uint DefaultColumnWidth => iDesc?.GetDefaultColumnWidth() ?? 0;

	/// <summary>Gets the display name of the property as it is shown in any UI.</summary>
	public string? DisplayName => iDesc != null && iDesc.GetDisplayName(out var s).Succeeded ? s : null;

	/// <summary>Gets the current data type used to display the property.</summary>
	public PROPDESC_DISPLAYTYPE DisplayType { get { try { return iDesc?.GetDisplayType() ?? 0; } catch { return 0; } } }

	/// <summary>Gets the text used in edit controls hosted in various dialog boxes.</summary>
	public string? EditInvitation => iDesc?.GetEditInvitation();

	/// <summary>Gets the grouping method to be used when a view is grouped by a property, and retrieves the grouping type.</summary>
	public PROPDESC_GROUPING_RANGE GroupingRange => iDesc?.GetGroupingRange() ?? 0;

	/// <summary>
	/// Gets a value indicating whether this property is meant to be viewed by the user. This influences whether the property shows up
	/// in the "Choose Columns" dialog box, for example.
	/// </summary>
	/// <value><see langword="true"/> if the user can view this property; otherwise, <see langword="false"/>.</value>
	public bool IsViewable => (iDesc?.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_ISVIEWABLE) ?? 0) == PROPDESC_TYPE_FLAGS.PDTF_ISVIEWABLE;

	/// <summary>Gets a structure that acts as a property's unique identifier.</summary>
	public PROPERTYKEY PropertyKey => key;

	/// <summary>Gets the variant type of the property. If the type cannot be determined, this property returns <c>null</c>.</summary>
	public Type PropertyType => PROPVARIANT.GetType(iDesc?.GetPropertyType() ?? VARTYPE.VT_EMPTY)!;

	/// <summary>Gets the relative description type for a property description.</summary>
	public PROPDESC_RELATIVEDESCRIPTION_TYPE RelativeDescriptionType => iDesc?.GetRelativeDescriptionType() ?? 0;

	/// <summary>Gets the current sort description flags for the property, which indicate the particular wordings of sort offerings.</summary>
	public PROPDESC_SORTDESCRIPTION SortDescription => iDesc?.GetSortDescription() ?? 0;

	/// <summary>Gets a set of flags that describe the uses and capabilities of the property.</summary>
	public PROPDESC_TYPE_FLAGS TypeFlags => iDesc?.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_MASK_ALL) ?? 0;

	/// <summary>Gets an instance of an PropertyTypeList, which can be used to enumerate the possible values for a property.</summary>
	public PropertyTypeList TypeList => typeList ??= new PropertyTypeList(iDesc?.GetEnumTypeList(typeof(IPropertyEnumTypeList).GUID));

	/// <summary>Gets the current set of flags governing the property's view.</summary>
	/// <returns>When this method returns, contains a pointer to a value that includes one or more of the following flags. See PROPDESC_VIEW_FLAGS for valid values.</returns>
	public PROPDESC_VIEW_FLAGS ViewFlags => iDesc?.GetViewFlags() ?? 0;

	/// <summary>Coerces the value to the canonical value, according to the property description.</summary>
	/// <param name="propvar">On entry, contains a PROPVARIANT that contains the original value. When this method returns, contains the canonical value.</param>
	public bool CoerceToCanonicalValue(PROPVARIANT propvar) => iDesc?.CoerceToCanonicalValue(propvar).Succeeded ?? false;

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public virtual void Dispose()
	{
		iDesc2 = null;
		Marshal.FinalReleaseComObject(iDesc);
		GC.SuppressFinalize(this);
	}

	/// <summary>Gets a formatted string representation of a property value.</summary>
	/// <param name="obj">A object that contains the type and value of the property.</param>
	/// <param name="pdfFlags">One or more of the PROPDESC_FORMAT_FLAGS flags, which are either bitwise or multiple values, that indicate the property string format.</param>
	/// <returns>The formatted value.</returns>
	public string FormatForDisplay(object obj, PROPDESC_FORMAT_FLAGS pdfFlags = PROPDESC_FORMAT_FLAGS.PDFF_DEFAULT) => iDesc.FormatForDisplay(new PROPVARIANT(obj), pdfFlags);

	/// <summary>Gets a formatted string representation of a property value.</summary>
	/// <param name="pv">A object that contains the type and value of the property.</param>
	/// <param name="pdfFlags">One or more of the PROPDESC_FORMAT_FLAGS flags, which are either bitwise or multiple values, that indicate the property string format.</param>
	/// <returns>The formatted value.</returns>
	internal string FormatForDisplay(PROPVARIANT pv, PROPDESC_FORMAT_FLAGS pdfFlags = PROPDESC_FORMAT_FLAGS.PDFF_DEFAULT) => iDesc.FormatForDisplay(pv, pdfFlags);

	/// <summary>Gets the image location for a value.</summary>
	/// <param name="obj">The value.</param>
	/// <returns>An IconLocation for the image associated with the property value.</returns>
	public IconLocation GetImageLocationForValue(object obj)
	{
		iDesc2 ??= iDesc as IPropertyDescription2;
		return iDesc2 != null && IconLocation.TryParse(iDesc2.GetImageReferenceForValue(new PROPVARIANT(obj), out var img).Succeeded ? img : null, out var loc) ? loc : new IconLocation();
	}

	/// <summary>Compares two property values in the manner specified by the property description. Returns two display strings that describe how the two properties compare.</summary>
	/// <param name="obj1">An object for the first property.</param>
	/// <param name="obj2">An object for the second property.</param>
	public Tuple<string?, string?> GetRelativeDescription(object obj1, object obj2)
	{
		string? d1 = null, d2 = null;
		iDesc?.GetRelativeDescription(new PROPVARIANT(obj1), new PROPVARIANT(obj2), out d1, out d2);
		return new Tuple<string?, string?>(d1, d2);
	}

	/// <summary>Gets the localized display string that describes the current sort order.</summary>
	/// <param name="descending">TRUE if ppszDescription should reference the string "Z on top"; FALSE to reference the string "A on top".</param>
	/// <returns>When this method returns, contains the address of a pointer to the sort description as a null-terminated Unicode string.</returns>
	public string? GetSortDescriptionLabel(bool descending = false) => iDesc?.GetSortDescriptionLabel(descending);

	/// <summary>Gets a value that indicates whether a property is canonical according to the definition of the property description.</summary>
	/// <param name="propvar">A PROPVARIANT that contains the type and value of the property.</param>
	public bool IsValueCanonical(PROPVARIANT propvar) => iDesc?.IsValueCanonical(propvar).Succeeded ?? false;

	/// <summary>Returns a <see cref="string" /> that represents this instance.</summary>
	/// <returns>A <see cref="string" /> that represents this instance.</returns>
	public override string ToString() => CanonicalName ?? string.Empty;

	/// <summary>Gets the raw interface object wrapped by this object.</summary>
	public IPropertyDescription Raw => iDesc;
}

/// <summary>Exposes methods that extract information from a collection of property descriptions presented as a list.</summary>
/// <seealso cref="IReadOnlyList{T}"/>
/// <seealso cref="IDisposable"/>
public class PropertyDescriptionList : IReadOnlyList<PropertyDescription>, IDisposable
{
	/// <summary>The IPropertyDescriptionList instance.</summary>
	protected IPropertyDescriptionList? iList;

	/// <summary>
	/// Initializes a new instance of the <see cref="PropertyDescriptionList"/> class from a string.
	/// </summary>
	/// <param name="propList">The property list. See <see cref="IPropertySystem.GetPropertyDescriptionListFromString"/> for the required format.</param>
	public PropertyDescriptionList(string propList) => PSGetPropertyDescriptionListFromString(propList, typeof(IPropertyDescriptionList).GUID, out iList).ThrowIfFailed();

	/// <summary>Initializes a new instance of the <see cref="PropertyDescriptionList"/> class.</summary>
	/// <param name="list">The COM interface pointer.</param>
	protected internal PropertyDescriptionList(IPropertyDescriptionList? list) => iList = list;

	/// <inheritdoc />
	public virtual int Count => (int)(iList?.GetCount() ?? 0);

	/// <inheritdoc />
	public virtual PropertyDescription this[int index] =>
		new((iList ?? throw new IndexOutOfRangeException()).GetAt((uint)index, typeof(IPropertyDescription).GUID));

	/// <summary>Gets the <see cref="PropertyDescription" /> for the specified key.</summary>
	/// <value>The <see cref="PropertyDescription" />.</value>
	/// <param name="propkey">The PROPERTYKEY.</param>
	/// <returns>The <see cref="PropertyDescription" /> for the specified key.</returns>
	public virtual PropertyDescription? this[PROPERTYKEY propkey] => PropertyDescription.Create(propkey);

	/// <inheritdoc />
	public virtual void Dispose() => GC.SuppressFinalize(this);

	/// <inheritdoc />
	public IEnumerator<PropertyDescription> GetEnumerator() => Enum().GetEnumerator();

	/// <summary>Gets the values for each property defined by this list for a specified shell item.</summary>
	/// <param name="shellItem">The shell item used to retrieve property values.</param>
	/// <returns>A list of property values.</returns>
	public object?[] GetValuesForShellItem(ShellItem shellItem) => Enum().Select(pd => shellItem.Properties[pd.PropertyKey]).ToArray();

	/// <inheritdoc />
	public override string ToString() => "prop:" + string.Join(";", this.Select(d => $"{GetPrefixForViewFlags(d.ViewFlags)}{d.CanonicalName}").ToArray());

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	/// <summary>Enumerates through the items in this instance.</summary>
	/// <returns>An <see cref="IEnumerable{PropertyDescription}"/> for this list.</returns>
	protected virtual IEnumerable<PropertyDescription> Enum()
	{
		for (var i = 0; i < Count; i++)
			yield return this[i];
	}

	// TODO: Incomplete. Needs to also include ?, < and & flags, but they are not documented.
	private static string GetPrefixForViewFlags(PROPDESC_VIEW_FLAGS flags)
	{
		var sb = new StringBuilder();
		foreach (var e in flags.GetFlags())
		{
			switch (e)
			{
				case PROPDESC_VIEW_FLAGS.PDVF_CENTERALIGN:
					sb.Append('|');
					break;
				case PROPDESC_VIEW_FLAGS.PDVF_RIGHTALIGN:
					sb.Append('/');
					break;
				case PROPDESC_VIEW_FLAGS.PDVF_BEGINNEWGROUP:
					sb.Append('^');
					break;
				case PROPDESC_VIEW_FLAGS.PDVF_FILLAREA:
					sb.Append('#');
					break;
				case PROPDESC_VIEW_FLAGS.PDVF_SORTDESCENDING:
					sb.Append('-');
					break;
				case PROPDESC_VIEW_FLAGS.PDVF_SHOWONLYIFPRESENT:
					sb.Append('*');
					break;
				case PROPDESC_VIEW_FLAGS.PDVF_HIDELABEL:
					sb.Append('~');
					break;
			}
		}
		if (flags.IsFlagSet(PROPDESC_VIEW_FLAGS.PDVF_SHOWBYDEFAULT | PROPDESC_VIEW_FLAGS.PDVF_SHOWINPRIMARYLIST | PROPDESC_VIEW_FLAGS.PDVF_SHOWINSECONDARYLIST))
			sb.Append('0');
		else if (flags.IsFlagSet(PROPDESC_VIEW_FLAGS.PDVF_SHOWINPRIMARYLIST | PROPDESC_VIEW_FLAGS.PDVF_SHOWINSECONDARYLIST))
			sb.Append('1');
		if (flags.IsFlagSet(PROPDESC_VIEW_FLAGS.PDVF_SHOWINSECONDARYLIST))
			sb.Append('2');
		return sb.ToString();
	}
}

/// <summary>Exposes methods that extract data from enumeration information.</summary>
/// <seealso cref="IDisposable"/>
public class PropertyType : IDisposable
{
	/// <summary>The IPropertyEnumType instance.</summary>
	protected IPropertyEnumType iType;
	/// <summary>The IPropertyEnumType2 instance.</summary>
	protected IPropertyEnumType2? iType2;

	/// <summary>Initializes a new instance of the <see cref="PropertyType"/> class.</summary>
	/// <param name="type">The IPropertyEnumType object.</param>
	protected internal PropertyType(IPropertyEnumType type) => iType = type;

	/// <summary>Gets the display text.</summary>
	/// <value>The display text.</value>
	public string? DisplayText { get { try { iType.GetDisplayText(out var s); return s; } catch { return null; } } }

	/// <summary>Gets an enumeration type.</summary>
	/// <value>The enumeration type.</value>
	public PROPENUMTYPE EnumType => iType?.GetEnumType() ?? 0;

	/// <summary>Gets the image reference.</summary>
	/// <value>The image reference.</value>
	public IconLocation ImageReference
	{
		get
		{
			iType2 ??= iType as IPropertyEnumType2;
			return IconLocation.TryParse(iType2?.GetImageReference(out string? img).Succeeded ?? false ? img : null, out var loc) ? loc : new IconLocation();
		}
	}

	/// <summary>Gets a minimum value.</summary>
	/// <value>The minimum value.</value>
	public object? RangeMinValue { get { try { var t = new PROPVARIANT(); iType.GetRangeMinValue(t); return t.Value; } catch { return null; } } }

	/// <summary>Gets a set value.</summary>
	/// <value>The set value.</value>
	public object? RangeSetValue { get { try { var t = new PROPVARIANT(); iType.GetRangeSetValue(t); return t.Value; } catch { return null; } } }

	/// <summary>Gets a value.</summary>
	/// <value>The value.</value>EnumType != PROPENUMTYPE.PET_DEFAULTVALUE ? 
	public object? Value { get { try { var t = new PROPVARIANT(); iType.GetValue(t); return t.Value; } catch { return null; } } }

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public virtual void Dispose()
	{
		iType2 = null;
		GC.SuppressFinalize(this);
	}

	/// <summary>Returns a <see cref="string" /> that represents this instance.</summary>
	/// <returns>A <see cref="string" /> that represents this instance.</returns>
	public override string ToString() => DisplayText ?? "";
}

/// <summary>Exposes methods that enumerate the possible values for a property.</summary>
/// <seealso cref="IReadOnlyList{T}"/>
/// <seealso cref="IDisposable"/>
public class PropertyTypeList : IReadOnlyList<PropertyType>, IDisposable
{
	/// <summary>The IPropertyEnumTypeList object.</summary>
	protected IPropertyEnumTypeList? iList;

	/// <summary>Initializes a new instance of the <see cref="PropertyTypeList"/> class.</summary>
	/// <param name="list">The IPropertyEnumTypeList object.</param>
	protected internal PropertyTypeList(IPropertyEnumTypeList? list) => iList = list;

	/// <summary>Gets the number of elements in the collection.</summary>
	/// <value>The number of elements in the collection.</value>
	public virtual int Count => (int)(iList?.GetCount() ?? 0);

	/// <summary>Gets the <see cref="PropertyType"/> at the specified index.</summary>
	/// <value>The <see cref="PropertyType"/>.</value>
	/// <param name="index">The index.</param>
	/// <returns>The <see cref="PropertyType"/> at the specified index.</returns>
	public virtual PropertyType this[int index] =>
		new(iList?.GetAt((uint)index, typeof(IPropertyEnumType).GUID) ?? throw new IndexOutOfRangeException());

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public virtual void Dispose()
	{
		iList = null;
		GC.SuppressFinalize(this);
	}

	/// <summary>Determines the index of a specific item in the list.</summary>
	/// <param name="obj">The object to locate in the list.</param>
	/// <returns>The index of item if found in the list; otherwise, -1.</returns>
	public virtual int IndexOf(object obj) => iList == null ? -1 : (iList.FindMatchingIndex(new PROPVARIANT(obj), out var idx).Succeeded ? (int)idx : -1);

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>
	/// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
	/// </returns>
	public IEnumerator<PropertyType> GetEnumerator() => Enum().GetEnumerator();

	/// <summary>Returns an enumerator that iterates through a collection.</summary>
	/// <returns>
	/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
	/// </returns>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	/// <summary>Enumerates through the items in this instance.</summary>
	/// <returns>An <see cref="IEnumerable{PropertyType}"/> for this list.</returns>
	protected virtual IEnumerable<PropertyType> Enum()
	{
		for (var i = 0; i < Count; i++)
			yield return this[i];
	}
}