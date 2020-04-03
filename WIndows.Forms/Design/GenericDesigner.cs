using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;
using Vanara.Extensions;

namespace Vanara.Windows.Forms.Design
{
	/// <summary>Interface for an action that has items and a category.</summary>
	public interface IActionGetItem
	{
		/// <summary>Gets the category.</summary>
		/// <value>The category.</value>
		string Category { get; }

		/// <summary>Gets the item.</summary>
		/// <param name="actions">The actions.</param>
		/// <param name="mbr">The MBR.</param>
		/// <returns></returns>
		DesignerActionItem GetItem(DesignerActionList actions, global::System.Reflection.MemberInfo mbr);
	}

	/// <summary>Methods to assist when using designer code.</summary>
	public static class ComponentDesignerExtension
	{
		/// <summary>Launches the design-time editor for the property of the component behind a designer.</summary>
		/// <param name="designer">The designer for a component.</param>
		/// <param name="propName">The name of the property to edit. If this value is null, the default property for the object is used.</param>
		/// <param name="objectToChange">
		/// The object on which to edit the property. If this value is null, the Component property of the designer is used.
		/// </param>
		/// <returns>The new value returned by the editor.</returns>
		public static object EditValue(this ComponentDesigner designer, string propName, object objectToChange = null)
		{
			if (objectToChange == null) objectToChange = designer.Component;
			var prop = (propName == null) ? TypeDescriptor.GetDefaultProperty(objectToChange) : TypeDescriptor.GetProperties(objectToChange)[propName];
			if (prop == null) throw new ArgumentException("Unable to retrieve specified property.");
			var context = new EditorServiceContext(designer, prop);
			var editor = prop.GetEditor(typeof(UITypeEditor)) as UITypeEditor;
			var curVal = prop.GetValue(objectToChange);
			var newVal = editor?.EditValue(context, context, curVal);
			if (newVal != curVal)
				try { prop.SetValue(objectToChange, newVal); }
				catch (CheckoutException) { }
			return newVal;
		}

		/// <summary>Sets a property on the component behind a designer.</summary>
		/// <typeparam name="T">The type of the property value.</typeparam>
		/// <param name="d">The designer for a component.</param>
		/// <param name="propName">
		/// The name of the property to set. If this value is null, the default property for the object is used. This method will not set
		/// the property if the property type does not match <typeparamref name="T"/>, if the property is read-only, or if the property is
		/// not browsable.
		/// </param>
		/// <param name="value">The value to assign to the property.</param>
		public static void SetComponentProperty<T>(this ComponentDesigner d, string propName, T value)
		{
			var propDesc = (propName == null) ? TypeDescriptor.GetDefaultProperty(d.Component) : TypeDescriptor.GetProperties(d.Component)[propName];
			if (propDesc != null && propDesc.PropertyType == typeof(T) && !propDesc.IsReadOnly && propDesc.IsBrowsable)
				propDesc.SetValue(d.Component, value);
		}

		/// <summary>Shows a form tied to a designer.</summary>
		/// <param name="designer">The designer for a component.</param>
		/// <param name="dialog">A form instance.</param>
		/// <returns>The result of calling ShowDialog on the form.</returns>
		public static DialogResult ShowDialog(this ComponentDesigner designer, Form dialog)
		{
			var context = new EditorServiceContext(designer);
			return context.ShowDialog(dialog);
		}
	}

	/// <summary>Extension methods for IServiceProvider.</summary>
	public static partial class ServiceProviderExtension
	{
		/// <summary>Gets the service.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sp">The sp.</param>
		/// <returns></returns>
		public static T GetService<T>(this IServiceProvider sp) where T : class => (T)sp.GetService(typeof(T));
	}

	/// <summary>A designer for components that support attributes.</summary>
	/// <typeparam name="TComponent">The type of the component.</typeparam>
	/// <seealso cref="System.ComponentModel.Design.ComponentDesigner"/>
	public abstract class AttributedComponentDesigner<TComponent> : ComponentDesigner where TComponent : Component
	{
		private IDictionary<string, List<Attribute>> redirectedProps;
		private DesignerVerbCollection verbs;

		/// <summary>Initializes a new instance of the <see cref="AttributedComponentDesigner{TComponent}"/> class.</summary>
		public AttributedComponentDesigner()
		{
			redirectedProps = this.GetRedirectedProperties();
			verbs = this.GetAttributedVerbs();
		}

		/// <summary>Gets the design-time verbs supported by the component that is associated with the designer.</summary>
		public override DesignerVerbCollection Verbs => verbs;

		/// <summary>Gets the design-time action lists supported by the component associated with the designer.</summary>
		public override DesignerActionListCollection ActionLists =>
			this.GetActionLists(Component, Actions, base.ActionLists, Verbs);

		/// <summary>Gets the component this designer is designing.</summary>
		public new TComponent Component => (TComponent)base.Component;

		/// <summary>Gets the actions.</summary>
		/// <value>The actions.</value>
		protected virtual AttributedDesignerActionList Actions => null;

		/// <summary>Gets the properties to remove.</summary>
		/// <value>The properties to remove.</value>
		protected virtual IEnumerable<string> PropertiesToRemove => null;

		/// <summary>Allows a designer to add to the set of properties that it exposes through a <see cref="T:System.ComponentModel.TypeDescriptor"/>.</summary>
		/// <param name="properties">The properties for the class of the component.</param>
		protected override void PreFilterProperties(IDictionary properties)
		{
			base.PreFilterProperties(properties);

			if (redirectedProps != null)
				this.RedirectRegisteredProperties(properties, redirectedProps);

			if (PropertiesToRemove != null)
				this.RemoveProperties(properties, PropertiesToRemove);
		}
	}

	/// <summary>An extended designer for components that support attributes.</summary>
	/// <typeparam name="TComponent">The type of the component.</typeparam>
	/// <seealso cref="System.ComponentModel.Design.ComponentDesigner"/>
	public abstract class AttributedComponentDesignerEx<TComponent> : AttributedComponentDesigner<TComponent>
		where TComponent : Component
	{
		private Adorner adorner;

		/// <summary>Gets the behavior service.</summary>
		/// <value>The behavior service.</value>
		public BehaviorService BehaviorService { get; private set; }

		/// <summary>Gets the component change service.</summary>
		/// <value>The component change service.</value>
		public IComponentChangeService ComponentChangeService { get; private set; }

		/// <summary>Gets the selection service.</summary>
		/// <value>The selection service.</value>
		public ISelectionService SelectionService { get; private set; }

		/// <summary>Gets the glyphs.</summary>
		/// <value>The glyphs.</value>
		public virtual GlyphCollection Glyphs => Adorner.Glyphs;

		internal Adorner Adorner
		{
			get
			{
				if (adorner == null)
					BehaviorService.Adorners.Add(adorner = new Adorner());
				return adorner;
			}
		}

		/// <summary>Prepares the designer to view, edit, and design the specified component.</summary>
		/// <param name="component">The component for this designer.</param>
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			BehaviorService = GetService<BehaviorService>();
			SelectionService = GetService<ISelectionService>();
			if (SelectionService != null)
				SelectionService.SelectionChanged += OnSelectionChanged;
			ComponentChangeService = GetService<IComponentChangeService>();
			if (ComponentChangeService != null)
				ComponentChangeService.ComponentChanged += OnComponentChanged;
		}

		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Design.ComponentDesigner"/> and optionally
		/// releases the managed resources.
		/// </summary>
		/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (BehaviorService != null & adorner != null)
					BehaviorService.Adorners.Remove(adorner);
				var ss = SelectionService;
				if (ss != null)
					ss.SelectionChanged -= OnSelectionChanged;
				var cs = ComponentChangeService;
				if (cs != null)
					cs.ComponentChanged -= OnComponentChanged;
			}
			base.Dispose(disposing);
		}

		/// <summary>Gets the service.</summary>
		/// <typeparam name="TS">The type of the s.</typeparam>
		/// <returns></returns>
		protected virtual TS GetService<TS>() where TS : class => (TS)GetService(typeof(TS));

		/// <summary>Called when [component changed].</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="ComponentChangedEventArgs"/> instance containing the event data.</param>
		protected virtual void OnComponentChanged(object sender, ComponentChangedEventArgs e)
		{
		}

		/// <summary>Called when [selection changed].</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected virtual void OnSelectionChanged(object sender, EventArgs e)
		{
		}
	}

	/// <summary>A designer for controls that support attributes.</summary>
	/// <typeparam name="TControl">The type of the control.</typeparam>
	/// <seealso cref="System.Windows.Forms.Design.ControlDesigner"/>
	public abstract class AttributedControlDesigner<TControl> : ControlDesigner where TControl : Control
	{
		private IDictionary<string, List<Attribute>> redirectedProps;
		private DesignerVerbCollection verbs;

		/// <summary>Initializes a new instance of the <see cref="AttributedControlDesigner{TControl}"/> class.</summary>
		public AttributedControlDesigner()
		{
			redirectedProps = this.GetRedirectedProperties();
			verbs = this.GetAttributedVerbs();
		}

		/// <summary>Gets the design-time verbs supported by the component that is associated with the designer.</summary>
		public override DesignerVerbCollection Verbs => verbs;

		/// <summary>Gets the design-time action lists supported by the component associated with the designer.</summary>
		public override DesignerActionListCollection ActionLists =>
			this.GetActionLists(Control, Actions, base.ActionLists, Verbs);

		/// <summary>Gets the control that the designer is designing.</summary>
		public new TControl Control => (TControl)base.Control;

		/// <summary>Gets the actions.</summary>
		/// <value>The actions.</value>
		protected virtual AttributedDesignerActionList Actions => null;

		/// <summary>Gets the properties to remove.</summary>
		/// <value>The properties to remove.</value>
		protected virtual IEnumerable<string> PropertiesToRemove => null;

		/// <summary>Adjusts the set of properties the component exposes through a <see cref="T:System.ComponentModel.TypeDescriptor"/>.</summary>
		/// <param name="properties">An <see cref="T:System.Collections.IDictionary"/> containing the properties for the class of the component.</param>
		protected override void PreFilterProperties(IDictionary properties)
		{
			base.PreFilterProperties(properties);

			if (redirectedProps != null)
				this.RedirectRegisteredProperties(properties, redirectedProps);

			if (PropertiesToRemove != null)
				this.RemoveProperties(properties, PropertiesToRemove);
		}
	}

	/// <summary>An extended designer for controls that support attributes.</summary>
	/// <typeparam name="TControl">The type of the control.</typeparam>
	/// <seealso cref="Vanara.Windows.Forms.Design.AttributedControlDesigner{TControl}"/>
	public abstract class AttributedControlDesignerEx<TControl> : AttributedControlDesigner<TControl> where TControl : Control
	{
		private Adorner adorner;

		/// <summary>Gets the component change service.</summary>
		/// <value>The component change service.</value>
		public IComponentChangeService ComponentChangeService { get; private set; }

		/// <summary>Gets the selection service.</summary>
		/// <value>The selection service.</value>
		public ISelectionService SelectionService { get; private set; }

		/// <summary>Gets the <see cref="T:System.Windows.Forms.Design.Behavior.BehaviorService"/> from the design environment.</summary>
		public new BehaviorService BehaviorService => base.BehaviorService;

		/// <summary>Gets the glyphs.</summary>
		/// <value>The glyphs.</value>
		public virtual GlyphCollection Glyphs => Adorner.Glyphs;

		internal Adorner Adorner
		{
			get
			{
				if (adorner == null)
					BehaviorService.Adorners.Add(adorner = new Adorner());
				return adorner;
			}
		}

		/// <summary>Initializes the designer with the specified component.</summary>
		/// <param name="component">
		/// The <see cref="T:System.ComponentModel.IComponent"/> to associate the designer with. This component must always be an instance
		/// of, or derive from, <see cref="T:System.Windows.Forms.Control"/>.
		/// </param>
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			SelectionService = GetService<ISelectionService>();
			if (SelectionService != null)
				SelectionService.SelectionChanged += OnSelectionChanged;
			ComponentChangeService = GetService<IComponentChangeService>();
			if (ComponentChangeService != null)
				ComponentChangeService.ComponentChanged += OnComponentChanged;
		}

		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Design.ControlDesigner"/> and optionally releases
		/// the managed resources.
		/// </summary>
		/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				BehaviorService?.Adorners.Remove(adorner);
				var ss = SelectionService;
				if (ss != null)
					ss.SelectionChanged -= OnSelectionChanged;
				var cs = ComponentChangeService;
				if (cs != null)
					cs.ComponentChanged -= OnComponentChanged;
			}
			base.Dispose(disposing);
		}

		/// <summary>Gets the service.</summary>
		/// <typeparam name="TS">The type of the s.</typeparam>
		/// <returns></returns>
		protected virtual TS GetService<TS>() where TS : class => (TS)GetService(typeof(TS));

		/// <summary>Called when a component has changed.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="ComponentChangedEventArgs"/> instance containing the event data.</param>
		protected virtual void OnComponentChanged(object sender, ComponentChangedEventArgs e)
		{
		}

		/// <summary>Called when the selection on the designer has changed.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected virtual void OnSelectionChanged(object sender, EventArgs e)
		{
		}
	}

	/// <summary>A designer action list pulled from attributes.</summary>
	/// <seealso cref="System.ComponentModel.Design.DesignerActionList"/>
	public abstract class AttributedDesignerActionList : DesignerActionList
	{
		private IEnumerable<DesignerActionItem> fullAIList;

		/// <summary>Initializes a new instance of the <see cref="AttributedDesignerActionList"/> class.</summary>
		/// <param name="designer">The designer.</param>
		/// <param name="component">The component.</param>
		protected AttributedDesignerActionList(ComponentDesigner designer, IComponent component)
			: base(component)
		{
			ParentDesigner = designer;
			AutoShow = true;
		}

		/// <summary>Gets the parent designer.</summary>
		/// <value>The parent designer.</value>
		public ComponentDesigner ParentDesigner { get; }

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/> objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/> array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			// Retrieve all attributed methods and properties
			if (fullAIList == null)
				fullAIList = this.GetAllAttributedActionItems();

			// Filter for conditions and load
			return this.GetFilteredActionItems(fullAIList);
		}

		/// <summary>Gets the component property.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="propName">Name of the property.</param>
		/// <returns></returns>
		protected T GetComponentProperty<T>(string propName)
		{
			var p = ComponentProp(propName, typeof(T));
			if (p != null)
				return (T)p.GetValue(Component, null);
			return default;
		}

		/// <summary>Sets the component property.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="propName">Name of the property.</param>
		/// <param name="value">The value.</param>
		protected void SetComponentProperty<T>(string propName, T value)
		{
			ComponentProp(propName, typeof(T))?.SetValue(Component, value, null);
		}

		private global::System.Reflection.PropertyInfo ComponentProp(string propName, Type retType) => Component.GetType().GetProperty(propName, InternalComponentDesignerExtension.allInstBind, null, retType, Type.EmptyTypes, null);
	}

	/// <summary>A designer for parent controls supported by attributes.</summary>
	/// <typeparam name="TControl">The type of the control.</typeparam>
	/// <seealso cref="System.Windows.Forms.Design.ParentControlDesigner"/>
	public abstract class AttributedParentControlDesigner<TControl> : ParentControlDesigner where TControl : Control
	{
		private IDictionary<string, List<Attribute>> redirectedProps;
		private DesignerVerbCollection verbs;

		/// <summary>Initializes a new instance of the <see cref="AttributedParentControlDesigner{TControl}"/> class.</summary>
		public AttributedParentControlDesigner()
		{
			redirectedProps = this.GetRedirectedProperties();
			verbs = this.GetAttributedVerbs();
		}

		/// <summary>Gets the design-time verbs supported by the component that is associated with the designer.</summary>
		public override DesignerVerbCollection Verbs => verbs;

		/// <summary>Gets the design-time action lists supported by the component associated with the designer.</summary>
		public override DesignerActionListCollection ActionLists =>
			this.GetActionLists(Control, Actions, base.ActionLists, Verbs);

		/// <summary>Gets the control that the designer is designing.</summary>
		public new TControl Control => (TControl)base.Control;

		/// <summary>Gets the actions.</summary>
		/// <value>The actions.</value>
		protected virtual AttributedDesignerActionList Actions => null;

		/// <summary>Gets the properties to remove.</summary>
		/// <value>The properties to remove.</value>
		protected virtual IEnumerable<string> PropertiesToRemove => null;

		/// <summary>Adjusts the set of properties the component will expose through a <see cref="T:System.ComponentModel.TypeDescriptor"/>.</summary>
		/// <param name="properties">
		/// An <see cref="T:System.Collections.IDictionary"/> that contains the properties for the class of the component.
		/// </param>
		protected override void PreFilterProperties(IDictionary properties)
		{
			base.PreFilterProperties(properties);

			if (redirectedProps != null)
				this.RedirectRegisteredProperties(properties, redirectedProps);

			if (PropertiesToRemove != null)
				this.RemoveProperties(properties, PropertiesToRemove);
		}
	}

	/// <summary>An extended designer for parent controls supported by attributes.</summary>
	/// <typeparam name="TControl">The type of the control.</typeparam>
	/// <seealso cref="Vanara.Windows.Forms.Design.AttributedParentControlDesigner{TControl}"/>
	public abstract class AttributedParentControlDesignerEx<TControl> : AttributedParentControlDesigner<TControl> where TControl : Control
	{
		private Adorner adorner;

		/// <summary>Gets the component change service.</summary>
		/// <value>The component change service.</value>
		public IComponentChangeService ComponentChangeService { get; private set; }

		/// <summary>Gets the selection service.</summary>
		/// <value>The selection service.</value>
		public ISelectionService SelectionService { get; private set; }

		/// <summary>Gets the <see cref="T:System.Windows.Forms.Design.Behavior.BehaviorService"/> from the design environment.</summary>
		public new BehaviorService BehaviorService => base.BehaviorService;

		/// <summary>Gets the glyphs.</summary>
		/// <value>The glyphs.</value>
		public virtual GlyphCollection Glyphs => Adorner.Glyphs;

		internal Adorner Adorner
		{
			get
			{
				if (adorner == null)
					BehaviorService.Adorners.Add(adorner = new Adorner());
				return adorner;
			}
		}

		/// <summary>Initializes the designer with the specified component.</summary>
		/// <param name="component">The <see cref="T:System.ComponentModel.IComponent"/> to associate with the designer.</param>
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			SelectionService = GetService<ISelectionService>();
			if (SelectionService != null)
				SelectionService.SelectionChanged += OnSelectionChanged;
			ComponentChangeService = GetService<IComponentChangeService>();
			if (ComponentChangeService != null)
				ComponentChangeService.ComponentChanged += OnComponentChanged;
		}

		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Design.ParentControlDesigner"/>, and optionally
		/// releases the managed resources.
		/// </summary>
		/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (BehaviorService != null & adorner != null)
					BehaviorService.Adorners.Remove(adorner);
				var ss = SelectionService;
				if (ss != null)
					ss.SelectionChanged -= OnSelectionChanged;
				var cs = ComponentChangeService;
				if (cs != null)
					cs.ComponentChanged -= OnComponentChanged;
			}
			base.Dispose(disposing);
		}

		/// <summary>Gets the service.</summary>
		/// <typeparam name="TS">The type of the s.</typeparam>
		/// <returns></returns>
		protected virtual TS GetService<TS>() where TS : class => (TS)GetService(typeof(TS));

		/// <summary>Called when [component changed].</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="ComponentChangedEventArgs"/> instance containing the event data.</param>
		protected virtual void OnComponentChanged(object sender, ComponentChangedEventArgs e)
		{
		}

		/// <summary>Called when [selection changed].</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		protected virtual void OnSelectionChanged(object sender, EventArgs e)
		{
		}
	}

	/// <summary>Attribute placed on methods that indicate they support a designer action.</summary>
	/// <seealso cref="System.Attribute"/>
	/// <seealso cref="Vanara.Windows.Forms.Design.IActionGetItem"/>
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class DesignerActionMethodAttribute : Attribute, IActionGetItem
	{
		/// <summary>Initializes a new instance of the <see cref="DesignerActionMethodAttribute"/> class.</summary>
		/// <param name="displayName">The display name.</param>
		/// <param name="displayOrder">The display order.</param>
		public DesignerActionMethodAttribute(string displayName, int displayOrder = 0)
		{
			DisplayName = displayName;
			DisplayOrder = displayOrder;
		}

		/// <summary>Gets or sets a value indicating whether [allow associate].</summary>
		/// <value><see langword="true"/> if [allow associate]; otherwise, <see langword="false"/>.</value>
		public bool AllowAssociate { get; set; }

		/// <summary>Gets or sets the category.</summary>
		/// <value>The category.</value>
		public string Category { get; set; }

		/// <summary>Gets or sets the condition.</summary>
		/// <value>The condition.</value>
		public string Condition { get; set; }

		/// <summary>Gets or sets the description.</summary>
		/// <value>The description.</value>
		public string Description { get; set; }

		/// <summary>Gets the display name.</summary>
		/// <value>The display name.</value>
		public string DisplayName { get; }

		/// <summary>Gets the display order.</summary>
		/// <value>The display order.</value>
		public int DisplayOrder { get; }

		/// <summary>Gets or sets a value indicating whether [include as designer verb].</summary>
		/// <value><see langword="true"/> if [include as designer verb]; otherwise, <see langword="false"/>.</value>
		public bool IncludeAsDesignerVerb { get; set; }

		DesignerActionItem IActionGetItem.GetItem(DesignerActionList actions, global::System.Reflection.MemberInfo mbr)
		{
			var ret = new DesignerActionMethodItem(actions, mbr.Name, DisplayName, Category, Description, IncludeAsDesignerVerb)
			{ AllowAssociate = AllowAssociate };
			if (!string.IsNullOrEmpty(Condition))
				ret.Properties.Add("Condition", Condition);
			ret.Properties.Add("Order", DisplayOrder);
			return ret;
		}
	}

	/// <summary>Attribute placed on properties that indicate they support a designer action.</summary>
	/// <seealso cref="System.Attribute"/>
	/// <seealso cref="Vanara.Windows.Forms.Design.IActionGetItem"/>
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class DesignerActionPropertyAttribute : Attribute, IActionGetItem
	{
		/// <summary>Initializes a new instance of the <see cref="DesignerActionPropertyAttribute"/> class.</summary>
		/// <param name="displayName">The display name.</param>
		/// <param name="displayOrder">The display order.</param>
		public DesignerActionPropertyAttribute(string displayName, int displayOrder = 0)
		{
			DisplayName = displayName;
			DisplayOrder = displayOrder;
		}

		/// <summary>Gets or sets a value indicating whether [allow associate].</summary>
		/// <value><see langword="true"/> if [allow associate]; otherwise, <see langword="false"/>.</value>
		public bool AllowAssociate { get; set; }

		/// <summary>Gets or sets the category.</summary>
		/// <value>The category.</value>
		public string Category { get; set; }

		/// <summary>Gets or sets the condition.</summary>
		/// <value>The condition.</value>
		public string Condition { get; set; }

		/// <summary>Gets or sets the description.</summary>
		/// <value>The description.</value>
		public string Description { get; set; }

		/// <summary>Gets the display name.</summary>
		/// <value>The display name.</value>
		public string DisplayName { get; }

		/// <summary>Gets the display order.</summary>
		/// <value>The display order.</value>
		public int DisplayOrder { get; }

		DesignerActionItem IActionGetItem.GetItem(DesignerActionList actions, global::System.Reflection.MemberInfo mbr)
		{
			var ret = new DesignerActionPropertyItem(mbr.Name, DisplayName, Category, Description)
			{ AllowAssociate = AllowAssociate };
			if (!string.IsNullOrEmpty(Condition))
				ret.Properties.Add("Condition", Condition);
			ret.Properties.Add("Order", DisplayOrder);
			return ret;
		}
	}

	/// <summary>Attribute placed on methods that indicate they support a designer attribute.</summary>
	/// <seealso cref="System.Attribute"/>
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class DesignerVerbAttribute : Attribute
	{
		private readonly CommandID cmdId;
		private readonly string menuText;

		/// <summary>Initializes a new instance of the <see cref="DesignerVerbAttribute"/> class.</summary>
		/// <param name="menuText">The menu text.</param>
		public DesignerVerbAttribute(string menuText)
		{
			this.menuText = menuText;
		}

		/// <summary>Initializes a new instance of the <see cref="DesignerVerbAttribute"/> class.</summary>
		/// <param name="menuText">The menu text.</param>
		/// <param name="commandMenuGroup">The command menu group.</param>
		/// <param name="commandId">The command identifier.</param>
		public DesignerVerbAttribute(string menuText, Guid commandMenuGroup, int commandId)
		{
			this.menuText = menuText;
			cmdId = new CommandID(commandMenuGroup, commandId);
		}

		internal DesignerVerb GetDesignerVerb(object obj, global::System.Reflection.MethodInfo mi)
		{
			var handler = (EventHandler)Delegate.CreateDelegate(typeof(EventHandler), obj, mi);
			if (cmdId != null)
				return new DesignerVerb(menuText, handler, cmdId);
			return new DesignerVerb(menuText, handler);
		}
	}

	/// <summary>A service context implementation for an editor.</summary>
	/// <seealso cref="System.Windows.Forms.Design.IWindowsFormsEditorService"/>
	/// <seealso cref="System.ComponentModel.ITypeDescriptorContext"/>
	public class EditorServiceContext : IWindowsFormsEditorService, ITypeDescriptorContext
	{
		private readonly ComponentDesigner designer;
		private readonly PropertyDescriptor targetProperty;
		private IComponentChangeService componentChangeSvc;

		internal EditorServiceContext(ComponentDesigner designer)
		{
			this.designer = designer;
		}

		internal EditorServiceContext(ComponentDesigner designer, PropertyDescriptor prop)
		{
			this.designer = designer;
			targetProperty = prop;
			if (prop == null)
			{
				prop = TypeDescriptor.GetDefaultProperty(designer.Component);
				if ((prop != null) && typeof(ICollection).IsAssignableFrom(prop.PropertyType))
					targetProperty = prop;
			}
		}

		internal EditorServiceContext(ComponentDesigner designer, PropertyDescriptor prop, string newVerbText)
			: this(designer, prop)
		{
			this.designer.Verbs.Add(new DesignerVerb(newVerbText, OnEditItems));
		}

		IContainer ITypeDescriptorContext.Container => designer.Component.Site?.Container;

		object ITypeDescriptorContext.Instance => designer.Component;

		PropertyDescriptor ITypeDescriptorContext.PropertyDescriptor => targetProperty;

		private IComponentChangeService ChangeService => componentChangeSvc ?? (componentChangeSvc = GetService<IComponentChangeService>());

		/// <summary>Shows the specified <see cref="T:System.Windows.Forms.Form"/>.</summary>
		/// <param name="dialog">The <see cref="T:System.Windows.Forms.Form"/> to display.</param>
		/// <returns>A <see cref="T:System.Windows.Forms.DialogResult"/> indicating the result code returned by the <see cref="T:System.Windows.Forms.Form"/>.</returns>
		public DialogResult ShowDialog(Form dialog)
		{
			var service = GetService<IUIService>();
			if (service != null)
				return service.ShowDialog(dialog);
			return dialog.ShowDialog(designer.Component as IWin32Window);
		}

		void IWindowsFormsEditorService.CloseDropDown()
		{
		}

		void IWindowsFormsEditorService.DropDownControl(Control control)
		{
		}

		object IServiceProvider.GetService(Type serviceType)
		{
			if ((serviceType == typeof(ITypeDescriptorContext)) || (serviceType == typeof(IWindowsFormsEditorService)))
				return this;
			return designer.Component?.Site?.GetService(serviceType);
		}

		void ITypeDescriptorContext.OnComponentChanged()
		{
			ChangeService.OnComponentChanged(designer.Component, targetProperty, null, null);
		}

		bool ITypeDescriptorContext.OnComponentChanging()
		{
			try
			{
				ChangeService.OnComponentChanging(designer.Component, targetProperty);
			}
			catch (CheckoutException exception)
			{
				if (exception != CheckoutException.Canceled)
					throw;
				return false;
			}
			return true;
		}

		private T GetService<T>() where T : class => ((IServiceProvider)this).GetService<T>();

		private void OnEditItems(object sender, EventArgs e)
		{
			var component = targetProperty.GetValue(designer.Component);
			if (component != null)
			{
				var editor = TypeDescriptor.GetEditor(component, typeof(UITypeEditor)) as CollectionEditor;
				editor?.EditValue(this, this, component);
			}
		}
	}

	/// <summary>Attribute placed on properties that indicate they support a designer redirected property.</summary>
	/// <seealso cref="System.Attribute"/>
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class RedirectedDesignerPropertyAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="RedirectedDesignerPropertyAttribute"/> class.</summary>
		public RedirectedDesignerPropertyAttribute() { ApplyOtherAttributes = true; }

		/// <summary>Gets or sets a value indicating whether [apply other attributes].</summary>
		/// <value><see langword="true"/> if [apply other attributes]; otherwise, <see langword="false"/>.</value>
		public bool ApplyOtherAttributes { get; set; }
	}

	/// <summary>A behavior derivative for a supplied type.</summary>
	/// <typeparam name="TControlDesigner">The type of the control designer.</typeparam>
	/// <seealso cref="System.Windows.Forms.Design.Behavior.Behavior"/>
	public abstract class TypedBehavior<TControlDesigner> : Behavior where TControlDesigner : ControlDesigner
	{
		/// <summary>Initializes a new instance of the <see cref="TypedBehavior{TControlDesigner}"/> class.</summary>
		/// <param name="designer">The designer.</param>
		protected TypedBehavior(TControlDesigner designer)
		{
			Designer = designer;
		}

		/// <summary>Gets the designer.</summary>
		/// <value>The designer.</value>
		public TControlDesigner Designer { get; }
	}

	/// <summary>An action list for a generic designer.</summary>
	/// <typeparam name="TComponentDesigner">The type of the component designer.</typeparam>
	/// <typeparam name="TComponent">The type of the component.</typeparam>
	/// <seealso cref="Vanara.Windows.Forms.Design.AttributedDesignerActionList"/>
	public abstract class TypedDesignerActionList<TComponentDesigner, TComponent> : AttributedDesignerActionList where TComponentDesigner : ComponentDesigner where TComponent : Component
	{
		/// <summary>Initializes a new instance of the <see cref="TypedDesignerActionList{TComponentDesigner, TComponent}"/> class.</summary>
		/// <param name="designer">The designer.</param>
		/// <param name="component">The component.</param>
		protected TypedDesignerActionList(TComponentDesigner designer, TComponent component) : base(designer, component)
		{
			ParentDesigner = designer;
		}

		/// <summary>Gets the parent designer.</summary>
		/// <value>The parent designer.</value>
		public new TComponentDesigner ParentDesigner { get; }

		/// <summary>Gets the component related to <see cref="T:System.ComponentModel.Design.DesignerActionList"/>.</summary>
		public new TComponent Component => (TComponent)base.Component;
	}

	/// <summary>A glyph associated with a designer.</summary>
	/// <typeparam name="TControlDesigner">The type of the control designer.</typeparam>
	/// <seealso cref="System.Windows.Forms.Design.Behavior.Glyph"/>
	/// <seealso cref="System.IDisposable"/>
	public abstract class TypedGlyph<TControlDesigner> : Glyph, IDisposable where TControlDesigner : ControlDesigner
	{
		/// <summary>Initializes a new instance of the <see cref="TypedGlyph{TControlDesigner}"/> class.</summary>
		/// <param name="designer">The designer.</param>
		/// <param name="behavior">The behavior.</param>
		protected TypedGlyph(TControlDesigner designer, Behavior behavior) : base(behavior)
		{
			Designer = designer;
		}

		/// <summary>Gets the designer.</summary>
		/// <value>The designer.</value>
		public TControlDesigner Designer { get; }

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public virtual void Dispose() { }

		/// <summary>Sets the behavior.</summary>
		/// <param name="b">The b.</param>
		public void SetBehavior(TypedBehavior<TControlDesigner> b) { base.SetBehavior(b); }
	}

	internal static class InternalComponentDesignerExtension
	{
		public const BindingFlags allInstBind = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

		public static DesignerActionListCollection GetActionLists(this ComponentDesigner designer, Component component, AttributedDesignerActionList actions, DesignerActionListCollection baseActions, DesignerVerbCollection verbs)
		{
			var lists = new DesignerActionListCollection();
			if (baseActions != null && baseActions.Count > 0)
				lists.AddRange(baseActions);
			if (actions != null)
				lists.Add(actions);
			if (verbs != null && verbs.Count > 0)
				lists.Add(new DesignerActionVerbList(verbs));
			return lists;
		}

		public static IEnumerable<DesignerActionItem> GetAllAttributedActionItems(this DesignerActionList actionList)
		{
			var fullAIList = new List<DesignerActionItem>();
			foreach (var mbr in actionList.GetType().GetMethods(allInstBind))
			{
				foreach (IActionGetItem attr in mbr.GetCustomAttributes(typeof(DesignerActionMethodAttribute), true))
				{
					if (mbr.ReturnType == typeof(void) && mbr.GetParameters().Length == 0)
						fullAIList.Add(attr.GetItem(actionList, mbr));
					else
						throw new FormatException("DesignerActionMethodAttribute must be applied to a method returning void and having no parameters.");
				}
			}
			foreach (var mbr in actionList.GetType().GetProperties(allInstBind))
			{
				if (mbr.GetIndexParameters().Length > 0)
					throw new FormatException("DesignerActionPropertyAttribute must be applied to non-indexed properties.");
				foreach (IActionGetItem attr in mbr.GetCustomAttributes(typeof(DesignerActionPropertyAttribute), true))
					fullAIList.Add(attr.GetItem(actionList, mbr));
			}
			fullAIList.Sort(CompareItems);
			return fullAIList;

			int CompareItems(DesignerActionItem a, DesignerActionItem b)
			{
				var c = string.Compare(a?.Category ?? string.Empty, b?.Category ?? string.Empty, true);
				if (c != 0)
					return c;
				c = (int)(a?.Properties["Order"] ?? 0) - (int)(b?.Properties["Order"] ?? 0);
				if (c != 0)
					return c;
				return string.Compare(a?.DisplayName, b?.DisplayName, true);
			}
		}

		public static DesignerVerbCollection GetAttributedVerbs(this ComponentDesigner designer)
		{
			var verbs = new DesignerVerbCollection();
			foreach (var m in designer.GetType().GetMethods(allInstBind))
			{
				foreach (DesignerVerbAttribute attr in m.GetCustomAttributes(typeof(DesignerVerbAttribute), true))
				{
					verbs.Add(attr.GetDesignerVerb(designer, m));
				}
			}
			return verbs.Count > 0 ? verbs : null;
		}

		public static DesignerActionItemCollection GetFilteredActionItems(this DesignerActionList actionList, IEnumerable<DesignerActionItem> fullAIList)
		{
			var col = new DesignerActionItemCollection();
			foreach (var ai in fullAIList)
				if (CheckCondition(ai))
					col.Add(ai);

			// Add header items for displayed items
			string cat = null;
			for (var i = 0; i < col.Count; i++)
			{
				var curCat = col[i].Category;
				if (string.Compare(curCat, cat, true) != 0)
				{
					col.Insert(i++, new DesignerActionHeaderItem(curCat));
					cat = curCat;
				}
			}

			return col;

			bool CheckCondition(DesignerActionItem ai)
			{
				if (ai.Properties["Condition"] != null)
				{
					var p = actionList.GetType().GetProperty((string)ai.Properties["Condition"], allInstBind, null, typeof(bool), Type.EmptyTypes, null);
					if (p != null)
						return (bool)p.GetValue(actionList, null);
				}
				return true;
			}
		}

		public static IDictionary<string, List<Attribute>> GetRedirectedProperties(this ComponentDesigner d)
		{
			var ret = new Dictionary<string, List<Attribute>>();
			foreach (var prop in d.GetType().GetProperties(allInstBind))
			{
				foreach (RedirectedDesignerPropertyAttribute attr in prop.GetCustomAttributes(typeof(RedirectedDesignerPropertyAttribute), false))
				{
					List<Attribute> attributes;
					if (attr.ApplyOtherAttributes)
					{
						attributes = prop.GetCustomAttributes<Attribute>().ToList();
						attributes.RemoveAll(a => a is RedirectedDesignerPropertyAttribute);
					}
					else
						attributes = new List<Attribute>();
					ret.Add(prop.Name, attributes);
				}
			}
			return ret.Count > 0 ? ret : null;
		}

		public static void RedirectRegisteredProperties(this ComponentDesigner d, IDictionary properties, IDictionary<string, List<Attribute>> redirectedProps)
		{
			foreach (var propName in redirectedProps.Keys)
			{
				var oldPropertyDescriptor = (PropertyDescriptor)properties[propName];
				if (oldPropertyDescriptor != null)
				{
					var attributes = redirectedProps[propName];
					properties[propName] = TypeDescriptor.CreateProperty(d.GetType(), oldPropertyDescriptor, attributes.ToArray());
				}
			}
		}

		public static void RemoveProperties(this ComponentDesigner d, IDictionary properties, IEnumerable<string> propertiesToRemove)
		{
			foreach (var p in propertiesToRemove)
				if (properties.Contains(p))
					properties.Remove(p);
		}
	}

	internal class DesignerActionVerbList : DesignerActionList
	{
		private DesignerVerbCollection _verbs;

		public DesignerActionVerbList(DesignerVerbCollection verbs) : base(null)
		{
			_verbs = verbs;
		}

		public override bool AutoShow => false;

		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			foreach (DesignerVerb v in _verbs)
				if ((v.Visible && v.Enabled) && v.Supported)
					items.Add(new DesignerActionVerbItem(v));
			return items;
		}

		public class DesignerActionVerbItem : DesignerActionMethodItem
		{
			private DesignerVerb targetVerb;

			public DesignerActionVerbItem(DesignerVerb verb) : base(null, null, verb.Text, "Verbs", verb.Description, false)
			{
				targetVerb = verb;
			}

			public override void Invoke()
			{
				targetVerb.Invoke();
			}
		}
	}
}