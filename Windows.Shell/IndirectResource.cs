using System.ComponentModel;

namespace Vanara.Windows.Shell
{
	/// <summary>Wraps a resource reference used by some Shell classes.</summary>
	public abstract class IndirectResource
	{
		/// <summary>Initializes a new instance of the <see cref="IndirectResource"/> class.</summary>
		public IndirectResource() { }

		/// <summary>Initializes a new instance of the <see cref="IndirectResource"/> class.</summary>
		/// <param name="module">The module file name.</param>
		/// <param name="resourceIdOrIndex">
		/// If this number is positive, this is the index of the resource in the module file. If negative, the absolute value of the number
		/// is the resource ID of the resource in the module file.
		/// </param>
		public IndirectResource(string module, int resourceIdOrIndex)
		{
			ModuleFileName = module;
			ResourceId = resourceIdOrIndex;
		}

		/// <summary>Returns true if this location is valid.</summary>
		/// <value><c>true</c> if this location is valid; otherwise, <c>false</c>.</value>
		[Browsable(false)]
		public virtual bool IsValid => ResourceId != 0 && System.IO.File.Exists(ModuleFileName);

		/// <summary>Gets or sets the module file name.</summary>
		/// <value>The module file name.</value>
		public string ModuleFileName { get; set; }

		/// <summary>Gets or sets the resource index or resource ID.</summary>
		/// <value>
		/// If this number is positive, this is the index of the resource in the module file. If negative, the absolute value of the number
		/// is the resource ID of the icon in the module file.
		/// </value>
		public int ResourceId { get; set; }

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => IsValid ? $"@{ModuleFileName},{ResourceId}" : string.Empty;
	}
}