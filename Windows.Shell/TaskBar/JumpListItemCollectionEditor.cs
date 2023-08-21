using System.Linq;

namespace Vanara.Windows.Shell;

internal class JumpListItemCollectionEditor : System.ComponentModel.Design.CollectionEditor
{
	/// <summary>Initializes a new instance of the <see cref="JumpListItemCollectionEditor"/> class.</summary>
	public JumpListItemCollectionEditor() : base(typeof(JumpList))
	{
	}

	/// <summary>Creates the collection form.</summary>
	/// <returns></returns>
	protected override CollectionForm CreateCollectionForm()
	{
		var f = base.CreateCollectionForm();
		f.Text = "JumpList Item Collection Editor";
		return f;
	}

	/// <summary>Creates the new item types.</summary>
	/// <returns></returns>
	protected override Type[] CreateNewItemTypes() => new[] { typeof(JumpListDestination), typeof(JumpListTask), typeof(JumpListSeparator) };

	/// <summary>Sets the items.</summary>
	/// <param name="editValue">The edit value.</param>
	/// <param name="value">The value.</param>
	/// <returns></returns>
	protected override object SetItems(object editValue, object[] value)
	{
		if (editValue is JumpList c)
		{
			c.Clear();
			foreach (var i in value.Cast<IJumpListItem>())
				c.Add(i);
		}
		return editValue;
	}

	protected override object CreateInstance(Type itemType)
	{
		if (itemType == typeof(JumpListDestination))
			return new JumpListDestination("[Category name]", "[File path]");
		if (itemType == typeof(JumpListSeparator))
			return new JumpListSeparator();
		if (itemType == typeof(JumpListTask))
			return new JumpListTask("[Title]", "[Application path]");
		return base.CreateInstance(itemType);
	}

	protected override string GetDisplayText(object value) => value is JumpListSeparator ? "-----------" : value.ToString() ?? "";

	/*protected override string HelpTopic => base.HelpTopic;

	public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
	{
		return base.EditValue(context, provider, value);
	}

	protected override CollectionForm CreateCollectionForm() => new JumpListItemCollectionEditorForm(this);

	protected class JumpListItemCollectionEditorForm : CollectionForm
	{
		public JumpListItemCollectionEditorForm(CollectionEditor editor) : base(editor)
		{
		}

		protected override void OnEditValueChanged();
	}*/
}