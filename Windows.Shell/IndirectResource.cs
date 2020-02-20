using System.ComponentModel;
using Vanara.PInvoke;

namespace Vanara.Windows.Shell
{
	/// <summary>Wraps a resource reference used by some Shell classes.</summary>
	public abstract class IndirectResource
	{
		private string fn;

		/// <summary>Initializes a new instance of the <see cref="IndirectResource"/> class.</summary>
		public IndirectResource() { }

		/// <summary>Initializes a new instance of the <see cref="IndirectResource"/> class.</summary>
		/// <param name="module">The module file name.</param>
		/// <param name="resourceIdOrIndex">
		/// If this number is positive, this is the index of the resource in the module file. If negative, the absolute value of the number
		/// is the resource ID of the resource in the module file.
		/// </param>
		/// <param name="versionModifier">The version modifier. This value can be, and usually is, <see langword="null"/>.</param>
		public IndirectResource(string module, int? resourceIdOrIndex = null, string versionModifier = null)
		{
			ModuleFileName = module;
			ResourceId = resourceIdOrIndex.HasValue ? (SafeResourceId)resourceIdOrIndex.Value : null;
			VersionModifier = versionModifier;
		}

		/// <summary>Returns true if this location is valid.</summary>
		/// <value><c>true</c> if this location is valid; otherwise, <c>false</c>.</value>
		[Browsable(false)]
		public virtual bool IsValid
		{
			get
			{
				return ResourceId != null &&
					((ModuleFileName != null && System.IO.File.Exists(ModuleFileName)) ||
					(PackageResourceIndexFile != null && System.IO.File.Exists(PackageResourceIndexFile)));
			}
		}

		/// <summary>Gets or sets the module file name.</summary>
		/// <value>The module file name.</value>
		[DefaultValue(null)]
		public string ModuleFileName
		{
			get
			{
				if (fn is null) return null;
				var ext = System.IO.Path.GetExtension(fn);
				return string.IsNullOrEmpty(ext) || ext.Equals(".pri", System.StringComparison.InvariantCultureIgnoreCase) ? null : fn;
			}
			set => fn = value;
		}

		/// <summary>
		/// Gets or sets the name of the package. The string is extracted from the Resources.pri file stored in the app's root directory of
		/// the package identified by PackageFullName, using the resource as a locator. The retrieved string is copied to the output buffer
		/// and the function returns S_OK. The string is extracted based on the app's environment or ResourceContext. Note: This string must
		/// refer to a package installed for the current user.If it does not, the call will fail.
		/// </summary>
		/// <value>The name of the package. Something like "Microsoft.Camera_6.2.8376.0_x64__8wekyb3d8bbwe".</value>
		[DefaultValue(null)]
		public string PackageName
		{
			get
			{
				if (fn is null) return null;
				var ext = System.IO.Path.GetExtension(fn);
				return string.IsNullOrEmpty(ext) ? fn : null;
			}
			set => fn = value;
		}

		/// <summary>
		/// Gets or sets the package resource index file name. The Package Resource Index (PRI) is a binary format introduced in Windows 8
		/// that contains indexed resources or references to resources. The .pri file is bundled as part of an app's package. For more
		/// information on .pri files, see Creating and retrieving resources in Windows Store apps. The string is extracted from the.pri file
		/// named, using the resource as a locator.The retrieved string is copied to the output buffer and the function returns S_OK. The
		/// string is extracted based on the current Shell environment or ResourceContext.
		/// </summary>
		/// <value>The package resource index file name. Something like "C:\Program Files\WindowsApps\Microsoft.Camera_6.2.8376.0_x64__8wekyb3d8bbwe\resources.pri".</value>
		[DefaultValue(null)]
		public string PackageResourceIndexFile
		{
			get
			{
				if (fn is null) return null;
				var ext = System.IO.Path.GetExtension(fn);
				return ext.Equals(".pri", System.StringComparison.InvariantCultureIgnoreCase) ? fn : null;
			}
			set => fn = value;
		}

		/// <summary>Gets or sets the resource index or resource ID.</summary>
		/// <value>
		/// If this number is positive, this is the index of the resource in the module file. If negative, the absolute value of the number
		/// is the resource ID of the icon in the module file.
		/// </value>
		[DefaultValue(null)]
		public SafeResourceId ResourceId { get; set; }

		/// <summary>Gets or sets the version modifier. This value is rarely used.</summary>
		/// <value>The version modifier (e.g. "v2").</value>
		[DefaultValue(null)]
		public string VersionModifier { get; set; }

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString()
		{
			if (string.IsNullOrEmpty(fn) || ResourceId is null)
				return string.Empty;
			var res = ResourceId.IsIntResource ? ResourceId.id.ToString() : ResourceId.ToString();
			if (ModuleFileName != null)
				return IsValid ? $"@{ModuleFileName},{res}" : string.Empty;
			return $"@{{{fn}?{res}}}";
		}
	}
}