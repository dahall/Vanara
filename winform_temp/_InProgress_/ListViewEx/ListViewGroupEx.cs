using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Forms;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Forms
{
	[Serializable, ToolboxItem(false), DesignTimeVisible(false), DefaultProperty("Header"), TypeConverter(typeof(ListViewGroupExConverter))]
	public partial class ListViewGroupEx : ISerializable
	{
		private bool? collapsed, hidden, noheader, focused, selected, collapsible, subseted, subsetlinkfocused;
		private string footer, task, subtitle, descTop, descBottom, subsetTitle;
		private HorizontalAlignment footerAlign = HorizontalAlignment.Left;
		private GroupHeaderImageListIndexer titleImageIndexer, extendedImageIndexer;

		/// <summary>
		/// Initializes a new instance of the <see cref="ListViewGroupEx"/> class using the default header text of "ListViewGroupEx" and the default left header alignment.
		/// </summary>
		public ListViewGroupEx() : this(typeof(ListViewGroupEx).Name)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ListViewGroupEx" /> class using the specified value to initialize the <see cref="ListViewGroupEx.Header"/> property and using the default left header alignment.
		/// </summary>
		/// <param name="header">The text to display for the group header.</param>
		public ListViewGroupEx(string header)
		{
			BaseGroup = new ListViewGroup(header);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ListViewGroupEx"/> class using the specified header text and the specified header alignment.
		/// </summary>
		/// <param name="key">The initial value of the Name property.</param>
		/// <param name="headerText">The text to display for the group header.</param>
		public ListViewGroupEx(string key, string headerText) : this(headerText)
		{
			Name = key;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ListViewGroupEx"/> class using the specified values to initialize the <see cref="ListViewGroupEx.Name"/> and Header<see cref="ListViewGroupEx.Header"/> properties.
		/// </summary>
		/// <param name="header">The text to display for the group header.</param>
		/// <param name="headerAlignment">One of the HorizontalAlignment values that specifies the alignment of the header text.</param>
		public ListViewGroupEx(string header, HorizontalAlignment headerAlignment) : this(header)
		{
			HeaderAlignment = headerAlignment;
		}

		private ListViewGroupEx(SerializationInfo info, StreamingContext context)
		{
			Deserialize(info, context);
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ListViewGroupEx"/> is collapsed.
		/// </summary>
		/// <value>
		///   <c>true</c> if collapsed; otherwise, <c>false</c>.
		/// </value>
		[DefaultValue(false), Category("Appearance")]
		public bool Collapsed
		{
			get { return GetState(ListViewGroupState.Collapsed | ListViewGroupState.Normal, ref collapsed); }
			set { SetState(ListViewGroupState.Collapsed | ListViewGroupState.Normal, value, ref collapsed); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ListViewGroupEx"/> is collapsible.
		/// </summary>
		/// <value>
		///   <c>true</c> if collapsible; otherwise, <c>false</c>.
		/// </value>
		[DefaultValue(false), Category("Behavior")]
		public bool Collapsible
		{
			get { return GetState(ListViewGroupState.Collapsible, ref collapsible); }
			set { SetState(ListViewGroupState.Collapsible, value, ref collapsible); }
		}

		/// <summary>
		/// Gets or sets the text that is drawn under the top description text when there is a title image, no extended image, and <see cref="HeaderAlignment"/> equals <see cref="HorizontalAlignment.Center"/>.
		/// </summary>
		/// <value>
		/// The bottom description text.
		/// </value>
		[DefaultValue(""), Category("Appearance"), Description("The bottom description text.")]
		public string DescriptionBottom
		{
			get { return descBottom ?? string.Empty; }
			set
			{
				if (descBottom != value)
				{
					descBottom = value;
					UpdateListView();
				}
			}
		}

		/// <summary>
		/// Gets or sets the text that is drawn opposite the title image when there is a title image, no extended image, and <see cref="HeaderAlignment"/> equals <see cref="HorizontalAlignment.Center"/>.
		/// </summary>
		/// <value>
		/// The top description text.
		/// </value>
		[DefaultValue(""), Category("Appearance"), Description("The top description text.")]
		public string DescriptionTop
		{
			get { return descTop ?? string.Empty; }
			set
			{
				if (descTop != value)
				{
					descTop = value;
					UpdateListView();
				}
			}
		}

		/// <summary>
		/// Gets or sets the index of the extended image in the parent <see cref="ListView.SmallImageList"/>.
		/// </summary>
		/// <value>
		/// The index of the extended image.
		/// </value>
		/// <exception cref="System.ArgumentOutOfRangeException"></exception>
		[RefreshProperties(RefreshProperties.Repaint), RelatedImageList("ListView.SmallImageList"), Localizable(true)]
		[DefaultValue(-1), Description("Index of extended image to display with group"), Category("Behavior")]
		[TypeConverter(typeof(ImageIndexConverter))]
		[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int ExtendedImageIndex
		{
			get { return ExtendedImageIndexer.Index; }
			set
			{
				if (value < -1)
					throw new ArgumentOutOfRangeException(nameof(ExtendedImageIndex));
				ExtendedImageIndexer.Index = value;
				UpdateListView();
			}
		}

		/// <summary>
		/// Gets or sets the key of the extended image in the parent <see cref="ListView.SmallImageList"/>.
		/// </summary>
		/// <value>
		/// The key of extended image.
		/// </value>
		[RefreshProperties(RefreshProperties.Repaint), RelatedImageList("ListView.SmallImageList"), Localizable(true)]
		[DefaultValue(null), Description("Key of extended image to display with group"), Category("Behavior")]
		[TypeConverter(typeof(ImageKeyConverter))]
		[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string ExtendedImageKey
		{
			get { return ExtendedImageIndexer.Key; }
			set
			{
				ExtendedImageIndexer.Key = value;
				UpdateListView();
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ListViewGroupEx"/> is focused.
		/// </summary>
		/// <value>
		///   <c>true</c> if focused; otherwise, <c>false</c>.
		/// </value>
		[DefaultValue(false), Category("Appearance")]
		public bool Focused
		{
			get { return GetState(ListViewGroupState.Focused, ref focused); }
			set { SetState(ListViewGroupState.Focused, value, ref focused); }
		}

		/// <summary>
		/// Gets or sets the footer.
		/// </summary>
		/// <value>
		/// The footer.
		/// </value>
		[DefaultValue(""), Category("Appearance")]
		public string Footer
		{
			get { return footer ?? string.Empty; }
			set
			{
				if (footer != value)
				{
					footer = value;
					UpdateListView();
				}
			}
		}

		[DefaultValue(0), Category("Appearance")]
		public HorizontalAlignment FooterAlignment
		{
			get { return footerAlign; }
			set
			{
				if (footerAlign != value)
				{
					footerAlign = value;
					UpdateListView();
				}
			}
		}

		/// <summary>
		/// Gets or sets the header text for the group.
		/// </summary>
		/// <value>
		/// The text to display for the group header. The default is "ListViewGroupEx".
		/// </value>
		[DefaultValue(""), Category("Appearance")]
		public string Header
		{
			get { return BaseGroup.Header; }
			set { BaseGroup.Header = value; }
		}

		/// <summary>
		/// Gets or sets the alignment of the group header text.
		/// </summary>
		/// <value>
		/// The header alignment.
		/// </value>
		[DefaultValue(0), Category("Appearance")]
		public HorizontalAlignment HeaderAlignment
		{
			get { return BaseGroup.HeaderAlignment; }
			set { BaseGroup.HeaderAlignment = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ListViewGroupEx"/> is hidden.
		/// </summary>
		/// <value>
		///   <c>true</c> if hidden; otherwise, <c>false</c>.
		/// </value>
		[DefaultValue(false), Category("Appearance")]
		public bool Hidden
		{
			get { return GetState(ListViewGroupState.Hidden, ref hidden); }
			set { SetState(ListViewGroupState.Hidden, value, ref hidden); }
		}

		[Browsable(false)]
		public ImageList ImageList => ListView?.SmallImageList;

		/// <summary>
		/// Gets a collection containing all items associated with this group.
		/// </summary>
		/// <value>
		/// The group items.
		/// </value>
		[Browsable(false)]
		public ListView.ListViewItemCollection Items => BaseGroup.Items;

		/// <summary>
		/// Gets the <see cref="ListViewEx"/> control that contains this group.
		/// </summary>
		/// <value>
		/// The ListViewEx parent control.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public ListViewEx ListView { get; internal set; }

		/// <summary>
		/// Gets or sets the name of the group.
		/// </summary>
		/// <value>
		/// The group name.
		/// </value>
		[DefaultValue(""), Category("Behavior"), Browsable(true)]
		public string Name
		{
			get { return BaseGroup.Name; }
			set { BaseGroup.Name = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the group displays a header.
		/// </summary>
		/// <value>
		/// <c>true</c> if no header should be displayed; otherwise, <c>false</c>.
		/// </value>
		[DefaultValue(false), Category("Appearance")]
		public bool NoHeader
		{
			get { return GetState(ListViewGroupState.NoHeader, ref noheader); }
			set { SetState(ListViewGroupState.NoHeader, value, ref noheader); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ListViewGroupEx" /> is selected.
		/// </summary>
		/// <value>
		/// <c>true</c> if selected; otherwise, <c>false</c>.
		/// </value>
		[DefaultValue(false), Category("Appearance")]
		public bool Selected
		{
			get { return GetState(ListViewGroupState.Selected, ref selected); }
			set { SetState(ListViewGroupState.Selected, value, ref selected); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ListViewGroupEx" /> only shows a portion of its items.
		/// </summary>
		/// <value>
		/// <c>true</c> if only a portion of items are shown; otherwise, <c>false</c>.
		/// </value>
		[DefaultValue(false), Category("Appearance")]
		public bool Subseted
		{
			get { return GetState(ListViewGroupState.Subseted, ref subseted); }
			set { SetState(ListViewGroupState.Subseted, value, ref subseted); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the subset link of the group has keyboard focus.
		/// </summary>
		/// <value>
		/// <c>true</c> if subset link focused; otherwise, <c>false</c>.
		/// </value>
		[DefaultValue(false), Category("Appearance")]
		public bool SubsetLinkFocused
		{
			get { return GetState(ListViewGroupState.SubsetLinkFocused, ref subsetlinkfocused); }
			set { SetState(ListViewGroupState.SubsetLinkFocused, value, ref subsetlinkfocused); }
		}

		/// <summary>
		/// Gets or sets the subset title text for the group.
		/// </summary>
		/// <value>
		/// The subset title.
		/// </value>
		[DefaultValue(""), Category("Appearance")]
		public string SubsetTitle
		{
			get { return subsetTitle ?? string.Empty; }
			private set
			{
				if (subsetTitle != value)
				{
					subsetTitle = value;
					UpdateListView();
				}
			}
		}

		/// <summary>
		/// Gets or sets the subtitle text that is drawn under the header text.
		/// </summary>
		/// <value>
		/// The subtitle text.
		/// </value>
		[DefaultValue(""), Category("Appearance")]
		public string Subtitle
		{
			get { return subtitle ?? string.Empty; }
			set
			{
				if (subtitle != value)
				{
					subtitle = value;
					UpdateListView();
				}
			}
		}

		/// <summary>
		/// Gets or sets the object that contains data about the group.
		/// </summary>
		/// <value>
		/// An <see cref="Object"/> for storing additional data.
		/// </value>
		[Localizable(false), Bindable(true), TypeConverter(typeof(StringConverter)), Category("Data"), DefaultValue((string)null)]
		public object Tag
		{
			get { return BaseGroup.Tag; }
			set { BaseGroup.Tag = value; }
		}

		/// <summary>
		/// Gets or sets the task.
		/// </summary>
		/// <value>
		/// The task.
		/// </value>
		[DefaultValue(""), Category("Appearance")]
		public string Task
		{
			get { return task ?? string.Empty; }
			set
			{
				if (task != value)
				{
					task = value;
					UpdateListView();
				}
			}
		}

		/// <summary>
		/// Gets or sets the index of the title image.
		/// </summary>
		/// <value>
		/// The index of the title image.
		/// </value>
		[RefreshProperties(RefreshProperties.Repaint), RelatedImageList("ListView.SmallImageList"), Localizable(true)]
		[DefaultValue(-1), Description("Index of image to display with group"), Category("Behavior")]
		[TypeConverter(typeof(ImageIndexConverter))]
		[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int TitleImageIndex
		{
			get { return TitleImageIndexer.Index; }
			set
			{
				if (value < -1)
					throw new ArgumentOutOfRangeException(nameof(TitleImageIndex));
				TitleImageIndexer.Index = value;
				UpdateListView();
			}
		}

		/// <summary>
		/// Gets or sets the title image key.
		/// </summary>
		/// <value>
		/// The title image key.
		/// </value>
		[RefreshProperties(RefreshProperties.Repaint), RelatedImageList("ListView.SmallImageList"), Localizable(true)]
		[DefaultValue(null), Description("Index of image to display with group"), Category("Behavior")]
		[TypeConverter(typeof(ImageKeyConverter))]
		[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string TitleImageKey
		{
			get { return TitleImageIndexer.Key; }
			set
			{
				TitleImageIndexer.Key = value;
				UpdateListView();
			}
		}

		internal ListViewGroup BaseGroup { get; set; }

		internal GroupHeaderImageListIndexer ExtendedImageIndexer
		{
			get { if (extendedImageIndexer == null) extendedImageIndexer = new GroupHeaderImageListIndexer(this); return extendedImageIndexer; }
		}

		internal int ID
		{
			get
			{
				var pi = BaseGroup.GetType().GetProperty("ID", BindingFlags.Instance | BindingFlags.NonPublic, null, typeof(int), Type.EmptyTypes, null);
				if (pi != null)
					return (int)pi.GetValue(BaseGroup, null);
				return 0;
			}
		}

		internal GroupHeaderImageListIndexer TitleImageIndexer
		{
			get { if (titleImageIndexer == null) titleImageIndexer = new GroupHeaderImageListIndexer(this); return titleImageIndexer; }
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="ListViewGroupEx" /> to <see cref="System.Windows.Forms.ListViewGroup" />.
		/// </summary>
		/// <param name="grpEx">The <see cref="ListViewGroupEx" /> instance to convert.</param>
		/// <returns>
		/// The resulting <see cref="System.Windows.Forms.ListViewGroupE" /> from the conversion.
		/// </returns>
		public static implicit operator ListViewGroup(ListViewGroupEx grpEx) => grpEx.BaseGroup;

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("BaseGroup", BaseGroup, BaseGroup.GetType());
			if (descBottom != null)
				info.AddValue("DescriptionBottom", descBottom);
			if (descTop != null)
				info.AddValue("DescriptionTop", descTop);
			if (footer != null)
				info.AddValue("Footer", footer);
			if (footerAlign != 0)
				info.AddValue("FooterAlignment", footerAlign);
			if (subtitle != null)
				info.AddValue("Subtitle", subtitle);
			if (task != null)
				info.AddValue("Task", task);
			if (TitleImageIndexer.ActualIndex > -1)
				info.AddValue("TitleImageIndex", TitleImageIndexer.ActualIndex);
			if (ExtendedImageIndexer.ActualIndex > -1)
				info.AddValue("ExtendedImageIndex", ExtendedImageIndexer.ActualIndex);
			info.AddValue("GroupState", ListView.GetGroupState(this));
		}

		internal LVGROUP AsLVGROUP()
		{
			LVGROUP lvGrp = new LVGROUP(ListViewGroupMask.None, Header);
			if (ID != 0) lvGrp.ID = ID;
			if (HeaderAlignment != HorizontalAlignment.Left) lvGrp.HeaderAlignment = HeaderAlignment;
			if (FooterAlignment != HorizontalAlignment.Left) lvGrp.FooterAlignment = FooterAlignment;
			if (Footer != null) lvGrp.Footer = Footer;
			if (DescriptionBottom != null) lvGrp.DescriptionBottom = DescriptionBottom;
			if (DescriptionTop != null) lvGrp.DescriptionTop = DescriptionTop;
			if (Subtitle != null) lvGrp.Subtitle = Subtitle;
			if (Task != null) lvGrp.Task = Task;
			if (TitleImageIndexer.ActualIndex > -1) lvGrp.TitleImageIndex = TitleImageIndexer.ActualIndex;
			if (ExtendedImageIndexer.ActualIndex > -1) lvGrp.ExtendedImageIndex = ExtendedImageIndexer.ActualIndex;
			ListViewGroupState s, m;
			GetSetState(out m, out s);
			if (s != ListViewGroupState.Normal) lvGrp.SetState(s);
			return lvGrp;
		}

		internal void GetSetState(out ListViewGroupState m, out ListViewGroupState s)
		{
			m = s = ListViewGroupState.Normal;
			if (collapsed.HasValue) { m |= ListViewGroupState.Collapsed; if (collapsed.Value) s |= ListViewGroupState.Collapsed; }
			if (collapsible.HasValue) { m |= ListViewGroupState.Collapsible; if (collapsible.Value) s |= ListViewGroupState.Collapsible; }
			if (focused.HasValue) { m |= ListViewGroupState.Focused; if (focused.Value) s |= ListViewGroupState.Focused; }
			if (hidden.HasValue) { m |= ListViewGroupState.Hidden; if (hidden.Value) s |= ListViewGroupState.Hidden; }
			if (noheader.HasValue) { m |= ListViewGroupState.NoHeader; if (noheader.Value) s |= ListViewGroupState.NoHeader; }
			if (selected.HasValue) { m |= ListViewGroupState.Selected; if (selected.Value) s |= ListViewGroupState.Selected; }
			if (subseted.HasValue) { m |= ListViewGroupState.Subseted; if (subseted.Value) s |= ListViewGroupState.Subseted; }
			if (subsetlinkfocused.HasValue) { m |= ListViewGroupState.SubsetLinkFocused; if (subsetlinkfocused.Value) s |= ListViewGroupState.SubsetLinkFocused; }
		}

		private void Deserialize(SerializationInfo info, StreamingContext context)
		{
			SerializationInfoEnumerator enumerator = info.GetEnumerator();
			while (enumerator.MoveNext())
			{
				SerializationEntry current = enumerator.Current;
				var pi = GetType().GetProperty(current.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, current.ObjectType, Type.EmptyTypes, null);
				if (pi != null)
					pi.SetValue(this, current.Value, null);
				else
					switch (current.Name)
					{
						case "GroupState":
							var state = (ListViewGroupState)current.Value;
							if ((state & ListViewGroupState.Collapsed) != 0) collapsed = true;
							if ((state & ListViewGroupState.Collapsible) != 0) collapsible = true;
							if ((state & ListViewGroupState.Focused) != 0) focused = true;
							if ((state & ListViewGroupState.Hidden) != 0) hidden = true;
							if ((state & ListViewGroupState.NoHeader) != 0) noheader = true;
							if ((state & ListViewGroupState.Selected) != 0) selected = true;
							if ((state & ListViewGroupState.Subseted) != 0) subseted = true;
							if ((state & ListViewGroupState.SubsetLinkFocused) != 0) subsetlinkfocused = true;
							ListView.SetGroupState(this, state, true);
							break;

						default:
							break;
					}
			}
		}

		private bool GetState(ListViewGroupState item, ref bool? localVar)
		{
			if (ListView != null)
			{
				ListViewGroupState s = ListView.GetGroupState(this, item);
				localVar = ((s & item) != 0);
			}
			return localVar.GetValueOrDefault(false);
		}

		private void SetState(ListViewGroupState item, bool on, ref bool? localVar)
		{
			if (ListView != null)
				ListView.SetGroupState(this, item, on);
			localVar = on;
		}

		private void UpdateListView()
		{
			ListView?.UpdateGroupNative(this);
		}

		internal class GroupHeaderImageListIndexer
		{
			private object index = -1;
			private ListViewGroupEx owner;

			public GroupHeaderImageListIndexer(ListViewGroupEx owner)
			{
				this.owner = owner;
			}

			public int ActualIndex => (index is string && ImageList != null) ? ImageList.Images.IndexOfKey((string)index) : Index;

			public ImageList ImageList
			{
				get { return owner?.ListView?.SmallImageList; }
				set { }
			}

			public int Index
			{
				get
				{
					if (index is int)
					{
						if ((int)index != -1 && ImageList != null && (int)index >= ImageList.Images.Count)
							return ImageList.Images.Count - 1;
						return (int)index;
					}
					return -1;
				}
				set { index = value; }
			}

			public string Key
			{
				get { return (index is string) ? (string)index : null; }
				set { index = value; }
			}
		}
	}

	internal class ListViewGroupExConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) => ((((sourceType == typeof(string)) && (context != null)) && (context.Instance is ListViewItem)) || base.CanConvertFrom(context, sourceType));

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => ((destinationType == typeof(InstanceDescriptor)) || ((((destinationType == typeof(string)) && (context != null)) && (context.Instance is ListViewItem)) || base.CanConvertTo(context, destinationType)));

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				string str = ((string)value).Trim();
				if ((context != null) && (context.Instance != null))
				{
					ListViewItem instance = context.Instance as ListViewItem;
					if ((instance != null) && (instance.ListView != null))
					{
						foreach (ListViewGroupEx group in ((ListViewEx)instance.ListView).Groups)
						{
							if (group.Header == str)
							{
								return group;
							}
						}
					}
				}
			}
			if ((value != null) && !value.Equals("None"))
			{
				return base.ConvertFrom(context, culture, value);
			}
			return null;
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
			{
				throw new ArgumentNullException(nameof(destinationType));
			}
			if ((destinationType == typeof(InstanceDescriptor)) && (value is ListViewGroupEx))
			{
				ListViewGroupEx group = (ListViewGroupEx)value;
				ConstructorInfo constructor = typeof(ListViewGroupEx).GetConstructor(System.Type.EmptyTypes);
				if (constructor != null)
				{
					return new InstanceDescriptor(constructor, null, false);
				}
			}
			if ((destinationType == typeof(string)) && (value == null))
			{
				return "None";
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			if ((context != null) && (context.Instance != null))
			{
				ListViewItem instance = context.Instance as ListViewItem;
				if ((instance != null) && (instance.ListView != null))
				{
					ArrayList values = new ArrayList();
					foreach (ListViewGroup group in instance.ListView.Groups)
					{
						values.Add(group);
					}
					values.Add(null);
					return new TypeConverter.StandardValuesCollection(values);
				}
			}
			return null;
		}

		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) => true;

		public override bool GetStandardValuesSupported(ITypeDescriptorContext context) => true;
	}
}