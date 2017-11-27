using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Vanara.Windows.Forms
{
	public partial class ListViewEx : ListView
	{
		private bool columnsFromData = true;
		private CurrencyManager dataManager = null;
		private string dataMember;
		private object dataSource;
		private PropertyDescriptorCollection dataSourceProperties;
		private bool inSetDataConnection, isDataSourceInitEventHooked, isDataSourceInitialized;
		private bool prevMultiSelect;
		private bool prevVirtualMode;

		public event EventHandler DataSourceChanged;

		[DefaultValue(true), Category("Data"), Description("Determines if columns are reset when a new DataSource is applied")]
		public bool ColumnsFromData
		{
			get { return columnsFromData; }
			set
			{
				columnsFromData = value;
				if (value)
					GetColumnsFromData();
			}
		}

		[DefaultValue((string)null), Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
		[Category("Data"), Description("Data member")]
		public string DataMember
		{
			get { return dataMember; }
			set
			{
				if ((dataMember == null) || !dataMember.Equals(value))
				{
					dataMember = value;
					SetDataConnection(DataSource, false);
				}
			}
		}

		[Bindable(true), DefaultValue(null), Category("Data"), Description("Data source")]
		[TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")]
		[AttributeProvider(typeof(IListSource)), RefreshProperties(RefreshProperties.Repaint)]
		public object DataSource
		{
			get
			{
				return dataSource;
			}
			set
			{
				if (((value != null) && !(value is IList)) && !(value is IListSource))
				{
					throw new ArgumentException("Bad DataSource for complex binding");
				}
				if ((dataSource == null) || !dataSource.Equals(value))
				{
					if (((value == null) || (value == Convert.DBNull)) && ((DataMember != null) && (DataMember.Length != 0)))
					{
						dataSource = null;
						DataMember = "";
					}
					else
					{
						if (value != null)
						{
							EnforceValidDataMember(value);
						}
						SetDataConnection(value, false);
					}
				}
			}
		}

		protected CurrencyManager DataManager => dataManager;

		public new void Sort()
		{
			if (VirtualMode && dataManager != null)
			{
				ListViewColumnSorter sorter = (ListViewColumnSorter)ListViewItemSorter;
				IBindingList bl = dataManager.List as IBindingList;
				if (bl != null && bl.SupportsSorting)
				{
					bl.RemoveSort();
					bl.ApplySort(dataSourceProperties[sorter.SortColumn], (ListSortDirection)(sorter.Order - 1));
				}
				else
					ArrayList.Adapter(dataManager.List).Sort(sorter);
			}
			else
				base.Sort();
		}

		protected virtual ListViewItem BuildItem(object obj)
		{
			var items = new string[Columns.Count];
			for (int i = 0; i < Columns.Count; i++)
			{
				ColumnHeaderEx hdr = Columns[i];
				var pd = dataSourceProperties.Find(hdr.Name, false);
				if (pd != null)
				{
					var val = pd.GetValue(obj);
					if (val == null || val is DBNull)
					{
						items[i] = hdr.NullValue;
					}
					else
					{
						var formattable = val as IFormattable;
						if (formattable == null)
						{
							var customFormatter = hdr.FormatProvider as ICustomFormatter;
							if (customFormatter == null)
								items[i] = Convert.ToString(pd.GetValue(obj), hdr.FormatProvider);
							else
								items[i] = customFormatter.Format(hdr.Format, pd.GetValue(obj), hdr.FormatProvider);
						}
						else
							items[i] = formattable.ToString(hdr.Format, hdr.FormatProvider);
					}
					continue;
				}
				if (dataSourceProperties.Count > i)
					items[i] = Convert.ToString(dataSourceProperties[i].GetValue(obj));
			}
			return new ListViewItem(items);
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.BindingContextChanged" /> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		protected override void OnBindingContextChanged(EventArgs e)
		{
			SetDataConnection(dataSource, true);
			base.OnBindingContextChanged(e);
		}

		/// <summary>
		/// Raises the <see cref="E:DataSourceChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected virtual void OnDataSourceChanged(EventArgs e)
		{
			EventHandler handler = DataSourceChanged;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.ListView.RetrieveVirtualItem" /> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.RetrieveVirtualItemEventArgs" /> that contains the event data.</param>
		protected override void OnRetrieveVirtualItem(RetrieveVirtualItemEventArgs e)
		{
			if (dataSourceProperties != null)
			{
				e.Item = BuildItem(dataManager.List[e.ItemIndex]);
			}
			base.OnRetrieveVirtualItem(e);
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.ListView.SearchForVirtualItem" /> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.SearchForVirtualItemEventArgs" /> that contains the event data.</param>
		protected override void OnSearchForVirtualItem(SearchForVirtualItemEventArgs e)
		{
			if (dataManager != null)
			{
				IBindingList bl = dataManager.List as IBindingList;
				if (bl != null && bl.SupportsSearching)
				{
					if (!e.IncludeSubItemsInSearch)
						e.Index = bl.Find(dataSourceProperties[0], e.Text);
					else
					{
						int idx;
						for (int i = 0; i < dataSourceProperties.Count; i++)
						{
							idx = bl.Find(dataSourceProperties[i], e.Text);
							if (idx != -1)
							{
								e.Index = idx;
								break;
							}
						}
					}
				}
			}
			base.OnSearchForVirtualItem(e);
		}

		private void DataManager_ItemChanged(object sender, ItemChangedEventArgs e)
		{
			DataManager_ItemChanged(sender, e.Index);
		}

		private void DataManager_ItemChanged(object sender, int index)
		{
			if (dataManager != null)
			{
				if (index == -1)
				{
					if (dataManager.Position >= 0)
						Items[dataManager.Position].Selected = true;
				}
				else
				{
					//this.SetItemCore(index, this.dataManager[index]);
				}
			}
		}

		private void DataManager_PositionChanged(object sender, EventArgs e)
		{
			if (dataManager != null)
			{
				Items[dataManager.Position].Selected = true;
			}
		}

		private void DataSourceDisposed(object sender, EventArgs e)
		{
			SetDataConnection(null, true);
		}

		private void DataSourceInitialized(object sender, EventArgs e)
		{
			SetDataConnection(dataSource, true);
		}

		private void EnforceValidDataMember(object value)
		{
			if (((DataMember != null) && (DataMember.Length != 0)) && (BindingContext != null))
			{
				try
				{
					BindingManagerBase base1 = BindingContext[value, dataMember];
				}
				catch
				{
					dataMember = "";
				}
			}
		}

		private void GetColumnsFromData()
		{
			if (dataSourceProperties != null && columnsFromData)
			{
				Columns.Clear();
				for (int i = 0; i < dataSourceProperties.Count; i++)
					Columns.Add(dataSourceProperties[i].Name, dataSourceProperties[i].DisplayName);
			}
		}

		private void SetDataConnection(object newDataSource, bool force)
		{
			bool newDS = dataSource != newDataSource;
			if (!inSetDataConnection)
			{
				try
				{
					if (force || newDS)
					{
						inSetDataConnection = true;
						IList list = (DataManager != null) ? DataManager.List : null;
						bool flag3 = DataManager == null;
						UnwireDataSource();
						dataSource = newDataSource;
						WireDataSource();
						if (isDataSourceInitialized)
						{
							CurrencyManager manager = null;
							if (((newDataSource != null) && (BindingContext != null)) && (newDataSource != Convert.DBNull))
							{
								manager = (CurrencyManager)BindingContext[newDataSource, DataMember];
							}
							if (dataManager != manager)
							{
								if (dataManager != null)
								{
									dataManager.ItemChanged -= new ItemChangedEventHandler(DataManager_ItemChanged);
									dataManager.PositionChanged -= new EventHandler(DataManager_PositionChanged);
								}
								dataManager = manager;
								if (dataManager != null)
								{
									dataManager.ItemChanged += new ItemChangedEventHandler(DataManager_ItemChanged);
									dataManager.PositionChanged += new EventHandler(DataManager_PositionChanged);
									prevMultiSelect = MultiSelect;
									MultiSelect = false;
									if (!VirtualMode)
										SelectedItems.Clear();
									Items.Clear();
									VirtualListSize = 0;
									prevVirtualMode = VirtualMode;
									VirtualMode = true;
									VirtualListSize = dataManager.List.Count;
									dataSourceProperties = dataManager.GetItemProperties();
									GetColumnsFromData();
								}
								else
								{
									MultiSelect = prevMultiSelect;
									VirtualMode = prevVirtualMode;
									dataSourceProperties = null;
								}
							}
							if (((dataManager != null) && (newDS || force)) && (force && ((list != dataManager.List) || flag3)))
							{
								DataManager_ItemChanged(dataManager, -1);
							}
						}
					}
					if (newDS)
					{
						OnDataSourceChanged(EventArgs.Empty);
					}
				}
				finally
				{
					inSetDataConnection = false;
				}
			}
		}

		private void UnwireDataSource()
		{
			if (this.dataSource is IComponent)
			{
				((IComponent)this.dataSource).Disposed -= new EventHandler(DataSourceDisposed);
			}
			ISupportInitializeNotification dataSource = this.dataSource as ISupportInitializeNotification;
			if ((dataSource != null) && isDataSourceInitEventHooked)
			{
				dataSource.Initialized -= new EventHandler(DataSourceInitialized);
				isDataSourceInitEventHooked = false;
			}
		}

		private void WireDataSource()
		{
			if (this.dataSource is IComponent)
			{
				((IComponent)this.dataSource).Disposed += new EventHandler(DataSourceDisposed);
			}
			ISupportInitializeNotification dataSource = this.dataSource as ISupportInitializeNotification;
			if ((dataSource != null) && !dataSource.IsInitialized)
			{
				dataSource.Initialized += new EventHandler(DataSourceInitialized);
				isDataSourceInitEventHooked = true;
				isDataSourceInitialized = false;
			}
			else
			{
				isDataSourceInitialized = true;
			}
		}
	}
}