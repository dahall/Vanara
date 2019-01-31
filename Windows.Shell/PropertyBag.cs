using static Vanara.PInvoke.Ole32;

namespace Vanara.Windows.Shell
{
	/// <summary>Encapsulates an <see cref="IPropertyBag"/> instance.</summary>
	public class PropertyBag
	{
		/// <summary>The IPropertyBag instance.</summary>
		protected readonly IPropertyBag ibag;

		/// <summary>Initializes a new instance of the <see cref="PropertyBag"/> class.</summary>
		/// <param name="ps">The ps.</param>
		public PropertyBag(IPropertyBag ppb) => ibag = ppb;

		/// <summary>Gets or sets the <see cref="System.Object"/> with the specified property name.</summary>
		/// <value>The <see cref="System.Object"/>.</value>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns>The property value.</returns>
		public object this[string propertyName]
		{
			get
			{
				object o = null;
				ibag.Read(propertyName, ref o, null);
				return o;
			}
			set => ibag.Write(propertyName, value);
		}
	}
}