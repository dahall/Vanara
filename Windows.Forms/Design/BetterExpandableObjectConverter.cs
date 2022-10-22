using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Vanara.Windows.Forms
{
	internal class BetterExpandableObjectConverter : ExpandableObjectConverter
	{
		// Methods
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) =>
			destinationType == typeof(string) ? string.Empty : base.ConvertTo(context, culture, value, destinationType);

#if NET6_0_OR_GREATER
		[RequiresUnreferencedCode(null)]
#endif
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes) =>
			TypeDescriptor.GetProperties(value, attributes);
	}
}
