using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.Windows.Shell
{
	public class PropertyDescription : IDisposable
	{
		/// <summary>The IPropertyDescription object.</summary>
		protected IPropertyDescription iDesc;

		/// <summary>Initializes a new instance of the <see cref="PropertyDescription"/> class.</summary>
		/// <param name="propertyDescription">The property description.</param>
		internal PropertyDescription(IPropertyDescription propertyDescription)
		{
			iDesc = propertyDescription;
		}

		/// <summary>Gets a value that describes how the property values are displayed when multiple items are selected in the UI.</summary>
		public PROPDESC_AGGREGATION_TYPE AggregationType => iDesc.GetAggregationType();

		/// <summary>Gets the case-sensitive name by which a property is known to the system, regardless of its localized name.</summary>
		public string CanonicalName => iDesc.GetCanonicalName();

		/// <summary>Gets the column state flag, which describes how the property should be treated by interfaces or APIs that use this flag.</summary>
		public SHCOLSTATE ColumnState => iDesc.GetColumnState();

		/// <summary>Gets the condition type and default condition operation to use when displaying the property in the query builder UI. This influences the list of predicate conditions (for example, equals, less than, and contains) that are shown for this property.</summary>
		public Tuple<PROPDESC_CONDITION_TYPE, CONDITION_OPERATION> ConditionType
		{
			get { iDesc.GetConditionType(out var ct, out var co); return new Tuple<PROPDESC_CONDITION_TYPE, CONDITION_OPERATION>(ct, co); }
		}

		/// <summary>Gets the default column width of the property in a list view.</summary>
		/// <returns>A pointer to the column width value, in characters.</returns>
		public uint DefaultColumnWidth => iDesc.GetDefaultColumnWidth();

		/// <summary>Gets the display name of the property as it is shown in any UI.</summary>
		public string DisplayName => iDesc.GetDisplayName();

		/// <summary>Gets the current data type used to display the property.</summary>
		public PROPDESC_DISPLAYTYPE DisplayType => iDesc.GetDisplayType();

		/// <summary>Gets the text used in edit controls hosted in various dialog boxes.</summary>
		public string EditInvitation => iDesc.GetEditInvitation();

		/// <summary>Gets the grouping method to be used when a view is grouped by a property, and retrieves the grouping type.</summary>
		public PROPDESC_GROUPING_RANGE GroupingRange => iDesc.GetGroupingRange();

		/// <summary>Gets a structure that acts as a property's unique identifier.</summary>
		public PROPERTYKEY PropertyKey => iDesc.GetPropertyKey();

		/// <summary>Gets the variant type of the property.</summary>
		public Type PropertyType
		{
			get
			{
				throw new NotImplementedException();
				//TODO: return iDesc.GetPropertyType().GetType();
			}
		}
		/// <summary>Gets the relative description type for a property description.</summary>
		public PROPDESC_RELATIVEDESCRIPTION_TYPE RelativeDescriptionType => iDesc.GetRelativeDescriptionType();

		/// <summary>Gets the current sort description flags for the property, which indicate the particular wordings of sort offerings.</summary>
		public PROPDESC_SORTDESCRIPTION SortDescription => iDesc.GetSortDescription();

		/// <summary>Gets a set of flags that describe the uses and capabilities of the property.</summary>
		public PROPDESC_TYPE_FLAGS TypeFlags => iDesc.GetTypeFlags(PROPDESC_TYPE_FLAGS.PDTF_MASK_ALL);

		/// <summary>Gets the current set of flags governing the property's view.</summary>
		/// <returns>When this method returns, contains a pointer to a value that includes one or more of the following flags. See PROPDESC_VIEW_FLAGS for valid values.</returns>
		public PROPDESC_VIEW_FLAGS ViewFlags => iDesc.GetViewFlags();

		/// <summary>Coerces the value to the canonical value, according to the property description.</summary>
		/// <param name="propvar">On entry, contains a PROPVARIANT that contains the original value. When this method returns, contains the canonical value.</param>
		public bool CoerceToCanonicalValue(PROPVARIANT propvar) => iDesc.CoerceToCanonicalValue(propvar).Succeeded;

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public virtual void Dispose()
		{
			if (iDesc != null)
			{
				Marshal.ReleaseComObject(iDesc);
				iDesc = null;
			}
		}

		// /// <summary>Gets an instance of an IPropertyEnumTypeList, which can be used to enumerate the possible values for a property.</summary>
		// public IPropertyEnumTypeList EnumTypeList => iDesc.GetEnumTypeList() as IPropertyEnumTypeList;
		/// <summary>Gets a formatted string representation of a property value.</summary>
		/// <param name="key">A reference to the requested property key, which identifies a property. See PROPERTYKEY.</param>
		/// <param name="propvar">A PROPVARIANT that contains the type and value of the property.</param>
		/// <param name="pdfFlags">One or more of the PROPDESC_FORMAT_FLAGS flags, which are either bitwise or multiple values, that indicate the property string format.</param>
		/// <returns>The formatted value.</returns>
		public string FormatForDisplay(ref PROPERTYKEY key, PROPVARIANT propvar, PROPDESC_FORMAT_FLAGS pdfFlags)
		{
			var sb = new System.Text.StringBuilder(0x8000);
			iDesc.FormatForDisplay(ref key, propvar, pdfFlags, sb, (uint)sb.Capacity);
			return sb.ToString();
		}

		/// <summary>Compares two property values in the manner specified by the property description. Returns two display strings that describe how the two properties compare.</summary>
		/// <param name="propvar1">A reference to a PROPVARIANT structure that contains the type and value of the first property.</param>
		/// <param name="propvar2">A reference to a PROPVARIANT structure that contains the type and value of the second property.</param>
		public Tuple<string, string> GetRelativeDescription(PROPVARIANT propvar1, PROPVARIANT propvar2)
		{
			iDesc.GetRelativeDescription(propvar1, propvar2, out var d1, out var d2);
			return new Tuple<string, string>(d1, d2);
		}

		/// <summary>Gets the localized display string that describes the current sort order.</summary>
		/// <param name="descending">TRUE if ppszDescription should reference the string "Z on top"; FALSE to reference the string "A on top".</param>
		/// <returns>When this method returns, contains the address of a pointer to the sort description as a null-terminated Unicode string.</returns>
		public string GetSortDescriptionLabel(bool descending = false) => iDesc.GetSortDescriptionLabel(descending);

		/// <summary>Gets a value that indicates whether a property is canonical according to the definition of the property description.</summary>
		/// <param name="propvar">A PROPVARIANT that contains the type and value of the property.</param>
		public bool IsValueCanonical(PROPVARIANT propvar) => iDesc.IsValueCanonical(propvar).Succeeded;
	}

	public class PropertyDescriptionList : IReadOnlyList<PropertyDescription>, IDisposable
	{
		protected IPropertyDescriptionList iList;

		internal PropertyDescriptionList(IPropertyDescriptionList list)
		{
			iList = list;
		}

		public int Count => (int)iList.GetCount();

		public PropertyDescription this[int index] => new PropertyDescription(iList.GetAt((uint)index, typeof(IPropertyDescription).GUID));

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public virtual void Dispose()
		{
			if (iList != null)
			{
				Marshal.ReleaseComObject(iList);
				iList = null;
			}
		}

		public IEnumerator<PropertyDescription> GetEnumerator() => Enum().GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		private IEnumerable<PropertyDescription> Enum()
		{
			for (var i = 0; i < Count; i++)
				yield return this[i];
			yield break;
		}
	}

	public class PropertyType : IDisposable
	{
		protected IPropertyEnumType iType;
		protected IPropertyEnumType2 iType2;

		internal PropertyType(IPropertyEnumType type)
		{
			iType = type;
			iType2 = type as IPropertyEnumType2;
		}

		public string DisplayText => iType.GetDisplayText();

		public PROPENUMTYPE EnumType => iType.GetEnumType();

		public IconLocation ImageReference { get { if (IconLocation.TryParse(iType2?.GetImageReference(), out var loc)) return loc; return new IconLocation(); } }

		public PROPVARIANT RangeMinValue => iType.GetRangeMinValue();

		public PROPVARIANT RangeSetValue => iType.GetRangeSetValue();

		public PROPVARIANT Value => iType.GetValue();

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public virtual void Dispose()
		{
			if (iType != null)
			{
				Marshal.ReleaseComObject(iType);
				iType = null;
			}
			if (iType2 != null)
			{
				Marshal.ReleaseComObject(iType2);
				iType2 = null;
			}
		}
	}

	public class PropertyTypeList : IReadOnlyList<PropertyType>, IDisposable
	{
		protected IPropertyEnumTypeList iList;

		internal PropertyTypeList(IPropertyEnumTypeList list)
		{
			iList = list;
		}

		public int Count => (int)iList.GetCount();

		public PropertyType this[int index] => new PropertyType(iList.GetAt((uint)index, typeof(IPropertyDescription).GUID));

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public virtual void Dispose()
		{
			if (iList != null)
			{
				Marshal.ReleaseComObject(iList);
				iList = null;
			}
		}

		public int FindMatchingIndex(PROPVARIANT pv) => (int)iList.FindMatchingIndex(pv);

		public IEnumerator<PropertyType> GetEnumerator() => Enum().GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		private IEnumerable<PropertyType> Enum()
		{
			for (var i = 0; i < Count; i++)
				yield return this[i];
			yield break;
		}
	}
}