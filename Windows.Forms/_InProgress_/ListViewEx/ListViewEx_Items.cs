using System.ComponentModel;
using System.Windows.Forms;

namespace Vanara.Windows.Forms
{
	public partial class ListViewEx : ListView
	{
		private ListViewItemExCollection newItems;

		[Description("Items"), Localizable(true), MergableProperty(false), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Editor(typeof(ListViewItemExCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public new ListViewItemExCollection Items
		{
			get { if (newItems == null) newItems = new ListViewItemExCollection(this); return newItems; }
		}

		internal ListViewItemCollection BaseItems => base.Items;
	}
}