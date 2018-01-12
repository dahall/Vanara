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
	public static class ComponentDesignerExtension
	{
		/// <summary>Launches the design-time editor for the property of the component behind a designer.</summary>
		/// <param name="designer">The designer for a component.</param>
		/// <param name="propName">The name of the property to edit. If this value is null, the default property for the object is used.</param>
		/// <param name="objectToChange">The object on which to edit the property. If this value is null, the Component property of the designer is used.</param>
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
		/// <param name="designer">The designer for a component.</param>
		/// <param name="propName">The name of the property to set. If this value is null, the default property for the object is used. This method will not set the property if the property type does not match <typeparamref name="T"/>, if the property is read-only, or if the property is not browsable.</param>
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

	public static partial class ServiceProviderExtension
	{
		public static T GetService<T>(this IServiceProvider sp) where T : class => (T)sp.GetService(typeof(T));
	}

	public interface IActionGetItem
	{
		string Category { get; }

		DesignerActionItem GetItem(DesignerActionList actions, global::System.Reflection.MemberInfo mbr);
	}

	public abstract class AttributedComponentDesigner<TComponent> : ComponentDesigner where TComponent : Component
	{
		private IDictionary<string, List<Attribute>> redirectedProps;
		private DesignerVerbCollection verbs;

		public AttributedComponentDesigner()
		{
			redirectedProps = this.GetRedirectedProperties();
			verbs = this.GetAttributedVerbs();
		}

		public override DesignerActionListCollection ActionLists =>
			this.GetActionLists(Component, Actions, base.ActionLists, Verbs);

		public new TComponent Component => (TComponent)base.Component;

		public override DesignerVerbCollection Verbs => verbs;

		protected virtual AttributedDesignerActionList Actions => null;

		protected virtual IEnumerable<string> PropertiesToRemove => null;

		protected override void PreFilterProperties(IDictionary properties)
		{
			base.PreFilterProperties(properties);

			if (redirectedProps != null)
				this.RedirectRegisteredProperties(properties, redirectedProps);

			if (PropertiesToRemove != null)
				this.RemoveProperties(properties, PropertiesToRemove);
		}
	}

	public abstract class AttributedComponentDesignerEx<TComponent> : AttributedComponentDesigner<TComponent>
		where TComponent : Component
	{
		private Adorner adorner;

		public BehaviorService BehaviorService { get; private set; }

		public IComponentChangeService ComponentChangeService { get; private set; }

		public ISelectionService SelectionService { get; private set; }

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

		protected virtual TS GetService<TS>() where TS : class => (TS)GetService(typeof(TS));

		protected virtual void OnComponentChanged(object sender, ComponentChangedEventArgs e)
		{
		}

		protected virtual void OnSelectionChanged(object sender, EventArgs e)
		{
		}
	}

	public abstract class AttributedControlDesigner<TControl> : ControlDesigner where TControl : Control
	{
		private IDictionary<string, List<Attribute>> redirectedProps;
		private DesignerVerbCollection verbs;

		public AttributedControlDesigner()
		{
			redirectedProps = this.GetRedirectedProperties();
			verbs = this.GetAttributedVerbs();
		}

		public override DesignerActionListCollection ActionLists =>
			this.GetActionLists(Control, Actions, base.ActionLists, Verbs);

		public new TControl Control => (TControl)base.Control;

		public override DesignerVerbCollection Verbs => verbs;

		protected virtual AttributedDesignerActionList Actions => null;

		protected virtual IEnumerable<string> PropertiesToRemove => null;

		protected override void PreFilterProperties(IDictionary properties)
		{
			base.PreFilterProperties(properties);

			if (redirectedProps != null)
				this.RedirectRegisteredProperties(properties, redirectedProps);

			if (PropertiesToRemove != null)
				this.RemoveProperties(properties, PropertiesToRemove);
		}
	}

	public abstract class AttributedControlDesignerEx<TControl> : AttributedControlDesigner<TControl> where TControl : Control
	{
		private Adorner adorner;

		public IComponentChangeService ComponentChangeService { get; private set; }
		public ISelectionService SelectionService { get; private set; }
		public new BehaviorService BehaviorService => base.BehaviorService;

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

		protected virtual TS GetService<TS>() where TS : class => (TS)GetService(typeof(TS));

		protected virtual void OnComponentChanged(object sender, ComponentChangedEventArgs e)
		{
		}

		protected virtual void OnSelectionChanged(object sender, EventArgs e)
		{
		}
	}

	public abstract class AttributedDesignerActionList : DesignerActionList
	{
		private IEnumerable<DesignerActionItem> fullAIList;

		protected AttributedDesignerActionList(ComponentDesigner designer, IComponent component)
			: base(component)
		{
			ParentDesigner = designer;
			AutoShow = true;
		}

		public ComponentDesigner ParentDesigner { get; }

		public override DesignerActionItemCollection GetSortedActionItems()
		{
			// Retrieve all attributed methods and properties
			if (fullAIList == null)
				fullAIList = this.GetAllAttributedActionItems();

			// Filter for conditions and load
			return this.GetFilteredActionItems(fullAIList);
		}

		protected T GetComponentProperty<T>(string propName)
		{
			var p = ComponentProp(propName, typeof(T));
			if (p != null)
				return (T)p.GetValue(Component, null);
			return default(T);
		}

		protected void SetComponentProperty<T>(string propName, T value)
		{
			ComponentProp(propName, typeof(T))?.SetValue(Component, value, null);
		}

		private global::System.Reflection.PropertyInfo ComponentProp(string propName, Type retType) => Component.GetType().GetProperty(propName, InternalComponentDesignerExtension.allInstBind, null, retType, Type.EmptyTypes, null);
	}

	public abstract class AttributedParentControlDesigner<TControl> : ParentControlDesigner where TControl : Control
	{
		private IDictionary<string, List<Attribute>> redirectedProps;
		private DesignerVerbCollection verbs;

		public AttributedParentControlDesigner()
		{
			redirectedProps = this.GetRedirectedProperties();
			verbs = this.GetAttributedVerbs();
		}

		public override DesignerActionListCollection ActionLists =>
			this.GetActionLists(Control, Actions, base.ActionLists, Verbs);

		public new TControl Control => (TControl)base.Control;

		public override DesignerVerbCollection Verbs => verbs;

		protected virtual AttributedDesignerActionList Actions => null;

		protected virtual IEnumerable<string> PropertiesToRemove => null;

		protected override void PreFilterProperties(IDictionary properties)
		{
			base.PreFilterProperties(properties);

			if (redirectedProps != null)
				this.RedirectRegisteredProperties(properties, redirectedProps);

			if (PropertiesToRemove != null)
				this.RemoveProperties(properties, PropertiesToRemove);
		}
	}

	public abstract class AttributedParentControlDesignerEx<TControl> : AttributedParentControlDesigner<TControl> where TControl : Control
	{
		private Adorner adorner;

		public IComponentChangeService ComponentChangeService { get; private set; }
		public ISelectionService SelectionService { get; private set; }
		public new BehaviorService BehaviorService => base.BehaviorService;

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

		protected virtual TS GetService<TS>() where TS : class => (TS)GetService(typeof(TS));

		protected virtual void OnComponentChanged(object sender, ComponentChangedEventArgs e)
		{
		}

		protected virtual void OnSelectionChanged(object sender, EventArgs e)
		{
		}
	}

	[AttributeUsage(AttributeTargets.Method)]
	public sealed class DesignerActionMethodAttribute : Attribute, IActionGetItem
	{
		public DesignerActionMethodAttribute(string displayName, int displayOrder = 0)
		{
			DisplayName = displayName;
			DisplayOrder = displayOrder;
		}

		public bool AllowAssociate { get; set; }

		public string Category { get; set; }

		public string Condition { get; set; }

		public string Description { get; set; }

		public string DisplayName { get; }

		public int DisplayOrder { get; }

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

	[AttributeUsage(AttributeTargets.Property)]
	public sealed class DesignerActionPropertyAttribute : Attribute, IActionGetItem
	{
		public DesignerActionPropertyAttribute(string displayName, int displayOrder = 0)
		{
			DisplayName = displayName;
			DisplayOrder = displayOrder;
		}

		public bool AllowAssociate { get; set; }

		public string Category { get; set; }

		public string Condition { get; set; }

		public string Description { get; set; }

		public string DisplayName { get; }

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

	[AttributeUsage(AttributeTargets.Method)]
	public sealed class DesignerVerbAttribute : Attribute
	{
		private readonly CommandID cmdId;
		private readonly string menuText;

		public DesignerVerbAttribute(string menuText)
		{
			this.menuText = menuText;
		}

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

	[AttributeUsage(AttributeTargets.Property)]
	public sealed class RedirectedDesignerPropertyAttribute : Attribute
	{
		public RedirectedDesignerPropertyAttribute() { ApplyOtherAttributes = true; }

		public bool ApplyOtherAttributes { get; set; }
	}

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

	public abstract class TypedBehavior<TControlDesigner> : Behavior where TControlDesigner : ControlDesigner
	{
		protected TypedBehavior(TControlDesigner designer)
		{
			Designer = designer;
		}

		public TControlDesigner Designer { get; }
	}

	public abstract class TypedDesignerActionList<TComponentDesigner, TComponent> : AttributedDesignerActionList where TComponentDesigner : ComponentDesigner where TComponent : Component
	{
		protected TypedDesignerActionList(TComponentDesigner designer, TComponent component) : base(designer, component)
		{
			ParentDesigner = designer;
		}

		public new TComponentDesigner ParentDesigner { get; }
		public new TComponent Component => (TComponent)base.Component;
	}

	public abstract class TypedGlyph<TControlDesigner> : Glyph, IDisposable where TControlDesigner : ControlDesigner
	{
		protected TypedGlyph(TControlDesigner designer, Behavior behavior) : base(behavior)
		{
			Designer = designer;
		}

		public TControlDesigner Designer { get; }

		public virtual void Dispose() { }

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