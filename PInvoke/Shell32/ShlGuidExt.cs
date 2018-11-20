using System;
using static Vanara.PInvoke.Shell32;

namespace Vanara.PInvoke
{
	/// <summary>Extension methods for enums with associated Guids.</summary>
	public static class ShlGuidExt
	{
		/// <summary>Retrieves the Guid associated with a <see cref="BHID"/>.</summary>
		/// <param name="id">The known folder.</param>
		/// <returns>The GUID.</returns>
		public static Guid Guid(this BHID id) => AssociateAttribute.GetGuidFromEnum(id);

		/// <summary>Retrieves the Guid associated with a <see cref="FOLDERTYPEID"/>.</summary>
		/// <param name="id">The known folder.</param>
		/// <returns>The GUID.</returns>
		public static Guid Guid(this FOLDERTYPEID id) => AssociateAttribute.GetGuidFromEnum(id);

		/// <summary>Lookups the specified unique identifier.</summary>
		/// <param name="guid">The unique identifier.</param>
		/// <returns>Corresponding BHID.</returns>
		public static TEnum Lookup<TEnum>(Guid guid) where TEnum : System.Enum => AssociateAttribute.TryEnumLookup(guid, out TEnum val) ? val : (TEnum)Convert.ChangeType(-1, typeof(TEnum));
	}
}