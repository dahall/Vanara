using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Vanara.InteropServices;

namespace Vanara.Extensions
{
	/// <summary>Extensions for types in System.Runtime.InteropServices.ComTypes.</summary>
	public static class ComTypeExtensions
	{
		/// <summary>Enumerates the strings from an <see cref="IEnumString"/> instance.</summary>
		/// <param name="iEnumString">The <see cref="IEnumString"/> instance.</param>
		/// <returns>A list of strings.</returns>
		/// <exception cref="ArgumentNullException">iEnumString</exception>
		public static IEnumerable<string> Enum(this IEnumString iEnumString)
		{
			if (iEnumString is null) throw new ArgumentNullException(nameof(iEnumString));
			var ret = 0;
			var items = new string[1];
			using (var pret = new PinnedObject(ret))
				while (iEnumString.Next(1, items, pret) == 0 && ret == 1)
					yield return items[0];
		}
	}
}