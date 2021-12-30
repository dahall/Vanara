using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Vanara.Windows
{
	/// <summary>A generic base to implement <see cref="IExtenderProvider"/> for a single extender type.</summary>
	/// <typeparam name="TExtend">The type of the type that can be extended.</typeparam>
	public abstract class ExtenderProviderBase<TExtend> : Component, IExtenderProvider, ISupportInitialize where TExtend : Component
	{
		/// <summary>A dictionary that holds a property bag for each extended type.</summary>
		protected readonly Dictionary<TExtend, Dictionary<string, object>> propHash = new();

		/// <summary>Initializes a new instance of the <see cref="ExtenderProviderBase{TExtend}"/> class.</summary>
		protected ExtenderProviderBase() { }

		/// <summary>Initializes a new instance of the <see cref="ExtenderProviderBase{TExtend}"/> class.</summary>
		/// <param name="parent">The parent.</param>
		protected ExtenderProviderBase(TExtend parent) => OnAddingExtender(parent);

		/// <summary>Initializes a new instance of the <see cref="ExtenderProviderBase{TExtend}"/> class.</summary>
		/// <param name="container">The container.</param>
		/// <exception cref="ArgumentNullException">container</exception>
		protected ExtenderProviderBase(IContainer container) : this()
		{
			if (container is null)
				throw new ArgumentNullException(nameof(container));
			container.Add(this);
		}

		/// <summary>Occurs when a new extender is being added.</summary>
		protected event EventHandler<AddExtenderEventArgs> AddingExtender;

		/// <summary>Sets the site.</summary>
		/// <value>The site.</value>
		public override ISite Site
		{
			set
			{
				base.Site = value;
				var parent = (value?.GetService(typeof(IDesignerHost)) as IDesignerHost)?.RootComponent as TExtend;
				if (parent != null)
					OnAddingExtender(parent);
			}
		}

		/// <summary>Gets all extended components that have properties assigned.</summary>
		/// <value>Returns a <see cref="IEnumerable{TExt}"/> value.</value>
		protected IEnumerable<TExtend> ExtendedComponents => propHash.Keys;

		/// <summary>Gets the known properties stored against all components.</summary>
		/// <value>Returns a <see cref="IEnumerable{T}"/> value.</value>
		protected IEnumerable<string> KnownProperties => propHash.Values.SelectMany(d => d.Keys).Distinct();

		/// <summary>Signals the object that initialization is starting.</summary>
		public virtual void BeginInit() { }

		/// <summary>Determines whether this instance can extend the specified extendee.</summary>
		/// <param name="extendee">The extendee.</param>
		/// <returns><see langword="true"/> if this instance can extend the specified extendee; otherwise, <see langword="false"/>.</returns>
		public virtual bool CanExtend(object extendee) => extendee is TExtend;

		/// <summary>Signals the object that initialization is complete.</summary>
		public virtual void EndInit() { }

		/// <summary>Gets the property value.</summary>
		/// <typeparam name="T">The type of the property to get.</typeparam>
		/// <param name="form">The form.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <param name="propName">Name of the field.</param>
		/// <returns></returns>
		protected virtual T GetPropertyValue<T>(TExtend form, T defaultValue = default, [CallerMemberName] string propName = "")
		{
			if (propName.StartsWith("Get"))
				propName = propName.Remove(0, 3);
			return propHash.TryGetValue(form, out var props) && props.TryGetValue(propName, out var prop) ? (T)prop : defaultValue;
		}

		/// <summary>Calls the <see cref="AddingExtender"/> event.</summary>
		/// <param name="extender">The extender being added.</param>
		protected virtual void OnAddingExtender(TExtend extender)
		{
			var args = new AddExtenderEventArgs(extender);
			AddingExtender?.Invoke(this, args);
			propHash[extender] = args.ExtenderProperties;
		}

		/// <summary>Sets the property value.</summary>
		/// <typeparam name="T">The type of the property to set.</typeparam>
		/// <param name="form">The form.</param>
		/// <param name="value">The value.</param>
		/// <param name="propName">Name of the field.</param>
		protected virtual bool SetPropertyValue<T>(TExtend form, T value, [CallerMemberName] string propName = "")
		{
			if (!propHash.ContainsKey(form))
				OnAddingExtender(form);
			if (propName.StartsWith("Set"))
				propName = propName.Remove(0, 3);
			if (propHash[form].TryGetValue(propName, out var prop) && Equals(prop, value))
				return false;
			propHash[form][propName] = value;
			return true;
		}

		/// <summary>Arguments for the <see cref="AddingExtender"/> event.</summary>
		public class AddExtenderEventArgs : EventArgs
		{
			internal AddExtenderEventArgs(TExtend parent)
			{
				Extender = parent;
				ExtenderProperties = new Dictionary<string, object>();
			}

			/// <summary>Gets the extender being added.</summary>
			/// <value>The extender.</value>
			public TExtend Extender { get; }

			/// <summary>Gets or sets the property bag to be associated with this extender.</summary>
			/// <value>The extender property bag.</value>
			public Dictionary<string, object> ExtenderProperties { get; set; }
		}
	}
}