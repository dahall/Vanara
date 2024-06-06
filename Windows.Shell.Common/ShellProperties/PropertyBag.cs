using static Vanara.PInvoke.OleAut32;

namespace Vanara.Windows.Shell;

/// <summary>Encapsulates an <see cref="IPropertyBag"/> instance.</summary>
/// <remarks>Initializes a new instance of the <see cref="PropertyBag"/> class.</remarks>
/// <param name="ppb">The property bag.</param>
public class PropertyBag(PInvoke.OleAut32.IPropertyBag ppb)
{
	/// <summary>The IPropertyBag instance.</summary>
	protected readonly IPropertyBag ibag = ppb;

	/// <summary>Gets or sets the <see cref="object"/> with the specified property name.</summary>
	/// <value>The <see cref="object"/>.</value>
	/// <param name="propertyName">Name of the property.</param>
	/// <returns>The property value.</returns>
	public object this[string propertyName]
	{
		get
		{
			object o = new();
			ibag.Read(propertyName, ref o, null);
			return o;
		}
		set => ibag.Write(propertyName, value);
	}
}