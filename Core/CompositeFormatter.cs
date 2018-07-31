using System;
using System.Collections.Generic;
using System.Globalization;

namespace Vanara
{
	// Leveraged code from t3chb0t and Bogdan Yarema at https://codereview.stackexchange.com/questions/138747/custom-string-formatters

	/// <summary>Binds multiple formatters together.</summary>
	/// <seealso cref="Vanara.Formatter"/>
	internal sealed class CompositeFormatter : Formatter
	{
		private readonly List<Formatter> _formatters;

		/// <summary>Initializes a new instance of the <see cref="CompositeFormatter"/> class.</summary>
		/// <param name="culture">The culture.</param>
		/// <param name="formatters">The formatters.</param>
		public CompositeFormatter(CultureInfo culture = null, params Formatter[] formatters) : base(culture)
		{
			_formatters = new List<Formatter>(formatters);
		}

		/// <summary>Adds the specified formatter.</summary>
		/// <param name="formatter">The formatter.</param>
		public void Add(Formatter formatter) => _formatters.Add(formatter);

		/// <summary>
		/// Converts the value of a specified object to an equivalent string representation using specified format and culture-specific
		/// formatting information.
		/// </summary>
		/// <param name="format">A format string containing formatting specifications.</param>
		/// <param name="arg">An object to format.</param>
		/// <param name="formatProvider">An object that supplies format information about the current instance.</param>
		/// <returns>
		/// The string representation of the value of <paramref name="arg"/>, formatted as specified by <paramref name="format"/> and
		/// <paramref name="formatProvider"/>.
		/// </returns>
		public override string Format(string format, object arg, IFormatProvider formatProvider)
		{
			foreach (var formatter in _formatters)
			{
				var result = formatter.Format(format, arg, formatProvider);
				if (result != null)
					return result;
			}
			return null;
		}
	}

	/// <summary>Extension method to combine formatter instances.</summary>
	public static class FormatterComposer
	{
		/// <summary>Adds a chain of formatters with specific cultures to make a composite.</summary>
		/// <typeparam name="T">A <see cref="Formatter"/> derived type.</typeparam>
		/// <param name="formatter">The formatter instance to start the chain.</param>
		/// <param name="culture">The culture.</param>
		/// <returns>A composite formatter.</returns>
		/// <example>
		/// <code lang="cs">
		/// // Build composite formatter from custom formatters derived from Formatter
		/// var formatter = Formatter.Default().Add&lt;CustomFormatter1&gt;().Add&lt;CustomFormatter2&gt;();
		/// // Use custom format extensions defined in the custom formatters to format the string
		/// var output = string.Format(formatter, "{0:cf1} = {0:cf2}", 512);
		/// </code>
		/// </example>
		public static Formatter Add<T>(this Formatter formatter, CultureInfo culture = null) where T : Formatter, new()
		{
			var newFormatter = new T();
			if (!(formatter is CompositeFormatter compositeFormatter))
				return new CompositeFormatter(culture, formatter, newFormatter);
			compositeFormatter.Add(newFormatter);
			return compositeFormatter;
		}
	}

	/// <summary>Base class for expandable formatters.</summary>
	public abstract class Formatter : IFormatProvider, ICustomFormatter
	{
		/// <summary>Initializes a new instance of the <see cref="Formatter"/> class.</summary>
		/// <param name="culture">The culture.</param>
		protected Formatter(CultureInfo culture = null)
		{
			Culture = culture ?? CultureInfo.InvariantCulture;
		}

		/// <summary>Gets a default instance of a composite formatter.</summary>
		/// <param name="culture">The culture.</param>
		/// <returns>A composite formatter.</returns>
		public static Formatter Default(CultureInfo culture = null) => new CompositeFormatter(culture);

		/// <summary>Gets the culture.</summary>
		/// <value>The culture.</value>
		public CultureInfo Culture { get; }

		/// <summary>Returns an object that provides formatting services for the specified type.</summary>
		/// <param name="formatType">An object that specifies the type of format object to return.</param>
		/// <returns>
		/// An instance of the object specified by <paramref name="formatType"/>, if the IFormatProvider implementation can supply that type
		/// of object; otherwise, <see langword="null"/>.
		/// </returns>
		public virtual object GetFormat(Type formatType) => formatType == typeof(ICustomFormatter) ? this : null;

		/// <summary>
		/// Converts the value of a specified object to an equivalent string representation using specified format and culture-specific
		/// formatting information.
		/// </summary>
		/// <param name="format">A format string containing formatting specifications.</param>
		/// <param name="arg">An object to format.</param>
		/// <param name="formatProvider">An object that supplies format information about the current instance.</param>
		/// <returns>
		/// The string representation of the value of <paramref name="arg"/>, formatted as specified by <paramref name="format"/> and
		/// <paramref name="formatProvider"/>.
		/// </returns>
		public abstract string Format(string format, object arg, IFormatProvider formatProvider);

		/// <summary>Helper method that can be used inside the Format method to handle unrecognized formats.</summary>
		/// <param name="format">A format string containing formatting specifications.</param>
		/// <param name="arg">An object to format.</param>
		/// <returns>
		/// The string representation of the value of <paramref name="arg"/>, formatted as specified by <paramref name="format"/>.
		/// </returns>
		protected string HandleOtherFormats(string format, object arg) => (arg as IFormattable)?.ToString(format, Culture) ?? (arg?.ToString() ?? string.Empty);
	}
}