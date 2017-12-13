using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Vanara.Extensions
{
	internal static class SerializationInfoExtension
	{
		internal static T GetValue<T>(this SerializationInfo info, string name) => (T)info.GetValue(name, typeof(T));
	}
}

namespace Vanara.Windows.Forms
{
	/// <summary>
	/// 
	/// </summary>
	[TypeConverter(typeof(ColumnHeaderExConverter)), ToolboxItem(false), DesignTimeVisible(false), DefaultProperty("Text")]
	public partial class ColumnHeaderEx : ColumnHeader, ICloneable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ColumnHeaderEx" /> class.
		/// </summary>
		public ColumnHeaderEx()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ColumnHeaderEx" /> class with the image specified.
		/// </summary>
		/// <param name="imageIndex">Index of the image.</param>
		public ColumnHeaderEx(int imageIndex) : base(imageIndex)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ColumnHeaderEx" /> class with the image specified.
		/// </summary>
		/// <param name="imageKey">The image key.</param>
		public ColumnHeaderEx(string imageKey) : base(imageKey)
		{
		}

		/// <summary>
		/// Gets or sets the display order of the column relative to the currently displayed columns.
		/// </summary>
		/// <value>
		/// The display order of the column, relative to the currently displayed columns.
		/// </value>
		[Localizable(true)]
		public new int DisplayIndex
		{
			get { return base.DisplayIndex; }
			set { base.DisplayIndex = value; }
		}

		/// <summary>
		/// Gets or sets the drop down context menu associated with this header.
		/// </summary>
		/// <value>
		/// The drop down context menu.
		/// </value>
		[DefaultValue(null)]
		public ContextMenuStrip DropDownContextMenu
		{
			get { return Extras.DropDownContextMenu; }
			set { Extras.DropDownContextMenu = value; }
		}

		/// <summary>
		/// Gets or sets the format string applied to the textual content of values of items under this header.
		/// </summary>
		/// <value>
		/// A string that indicates the format item values. The default is <see cref="string.Empty"/>.
		/// </value>
		[DefaultValue("")]
		public string Format
		{
			get { return Extras.Format; }
			set { Extras.Format = value; }
		}

		/// <summary>
		/// Gets or sets the object used to provide culture-specific formatting of values in items under this header.
		/// </summary>
		/// <value>
		/// An <see cref="IFormatProvider"/> used for item formatting. The default is <see cref="CultureInfo.CurrentUICulture"/>.
		/// </value>
		[DefaultValue(null)]
		public IFormatProvider FormatProvider
		{
			get { return Extras.FormatProvider; }
			set { Extras.FormatProvider = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ColumnHeaderEx" /> can be hidden.
		/// </summary>
		/// <value>
		/// <c>true</c> if can be hidden; otherwise, <c>false</c>.
		/// </value>
		[DefaultValue(true)]
		public bool Hideable
		{
			get { return Extras.Hideable; }
			set { Extras.Hideable = value; }
		}

		/// <summary>
		/// Gets or sets the <see cref="ListViewEx"/> item display value corresponding to a value of <see cref="DBNull.Value"/> or <c>null</c>.
		/// </summary>
		/// <value>
		/// The object used to indicate a null value for an item. The default is <see cref="String.Empty"/>.
		/// </value>
		[DefaultValue("")]
		public string NullValue
		{
			get { return Extras.NullValue; }
			set { Extras.NullValue = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether to show drop down button.
		/// </summary>
		/// <value>
		/// <c>true</c> if showing drop down button; otherwise, <c>false</c>.
		/// </value>
		[DefaultValue(false)]
		public bool ShowDropDownButton
		{
			get { return Extras.ShowDropDownButton; }
			set
			{
				Extras.ShowDropDownButton = value;
				if (base.ListView != null)
					base.ListView.SetColumnDropDown(base.Index, value);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ColumnHeaderEx" /> is sortable.
		/// </summary>
		/// <value>
		/// <c>true</c> if sortable; otherwise, <c>false</c>.
		/// </value>
		[DefaultValue(true)]
		public bool Sortable
		{
			get { return Extras.Sortable; }
			set { Extras.Sortable = value; }
		}

		/// <summary>
		/// Gets a value indicating whether the items in the <see cref="ListViewEx"/> control are sorted in ascending or descending order, or are not sorted.
		/// </summary>
		/// <value>
		/// One of the <see cref="SortOrder"/> values.
		/// </value>
		[DefaultValue(0)]
		public SortOrder SortOrder
		{
			get { return Extras.SortOrder; }
			set { Extras.SortOrder = value; }
		}

		/// <summary>
		/// Gets or sets an object that contains data to associate with the <see cref="ColumnHeaderEx"/>.
		/// </summary>
		/// <value>
		/// An <see cref="Object"/> that contains data to associate with the <see cref="ColumnHeaderEx"/>.
		/// </value>
		[DefaultValue(null)]
		public new object Tag
		{
			get { return Extras.Tag; }
			set { Extras.Tag = value; }
		}

		internal InternalColInfo Extras
		{
			get
			{
				if (base.Tag == null)
					return (InternalColInfo)(base.Tag = new InternalColInfo());
				if (base.Tag is InternalColInfo)
					return (InternalColInfo)base.Tag;
				return (InternalColInfo)(base.Tag = new InternalColInfo() { Tag = base.Tag });
			}
			set
			{
				if (base.Tag != null && !(base.Tag is InternalColInfo))
					value.Tag = base.Tag;
				base.Tag = value;
			}
		}

		public new object Clone()
		{
			ColumnHeaderEx header = new ColumnHeaderEx() { Text = Text, TextAlign = TextAlign, Width = Width };
			header.DropDownContextMenu = DropDownContextMenu;
			header.Format = Format;
			header.FormatProvider = FormatProvider;
			header.Hideable = Hideable;
			header.NullValue = NullValue;
			header.ShowDropDownButton = ShowDropDownButton;
			header.Sortable = Sortable;
			header.SortOrder = SortOrder;
			header.Tag = (Tag is ICloneable) ? ((ICloneable)Tag).Clone() : Tag;
			header.Extras.GroupingInfo = (Extras.GroupingInfo is ICloneable) ? ((ICloneable)Extras.GroupingInfo).Clone() : Extras.GroupingInfo;
			return header;
		}

		public override string ToString() => ("ColumnHeaderEx: Text: " + Text);

		internal class InternalColInfo
		{
			public ContextMenuStrip DropDownContextMenu;
			public string Format = string.Empty;
			public IFormatProvider FormatProvider = System.Globalization.CultureInfo.CurrentUICulture;
			public bool Hideable = true;
			public string NullValue = string.Empty;
			public bool ShowDropDownButton = false;
			public bool Sortable = true;
			public SortOrder SortOrder = SortOrder.None;
			public object GroupingInfo;
			public object Tag;
		}
	}

	public class ColumnHeaderExConverter : ExpandableObjectConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) => sourceType == typeof(ColumnHeader) || base.CanConvertFrom(context, sourceType);

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => ((destinationType == typeof(InstanceDescriptor)) || base.CanConvertTo(context, destinationType));

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			ColumnHeader hdr = value as ColumnHeader;
			if (hdr == null)
				return base.ConvertFrom(context, culture, value);

			var header = new ColumnHeaderEx { Text = hdr.Text, TextAlign = hdr.TextAlign, Width = hdr.Width };
			// TODO: missing ImageList and index and owner ListView
			header.Tag = hdr.Tag;
			return header;
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
				throw new ArgumentNullException(nameof(destinationType));

			if (!(destinationType == typeof(InstanceDescriptor)) || !(value is ColumnHeaderEx))
				return base.ConvertTo(context, culture, value, destinationType);

			ColumnHeaderEx header = (ColumnHeaderEx)value;
			Type reflectionType = TypeDescriptor.GetReflectionType(value);
			ConstructorInfo constructor;
			InstanceDescriptor descriptor = null;

			if (header.ImageIndex != -1)
			{
				constructor = reflectionType.GetConstructor(new Type[] { typeof(int) });
				if (constructor != null)
					descriptor = new InstanceDescriptor(constructor, new object[] { header.ImageIndex }, false);
			}

			if ((descriptor == null) && !string.IsNullOrEmpty(header.ImageKey))
			{
				constructor = reflectionType.GetConstructor(new Type[] { typeof(string) });
				if (constructor != null)
					descriptor = new InstanceDescriptor(constructor, new object[] { header.ImageKey }, false);
			}

			if (descriptor != null)
				return descriptor;

			constructor = reflectionType.GetConstructor(Type.EmptyTypes);
			if (constructor == null)
				throw new ArgumentException("NoDefaultConstructor");

			return new InstanceDescriptor(constructor, new object[0], false);
		}
	}
}