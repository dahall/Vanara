#nullable enable
using System;
using System.ComponentModel;

namespace Vanara.Windows.Shell
{
	/// <summary>Wraps a resource reference used by some Shell classes.</summary>
	public abstract class IndirectResource
	{
		/// <summary>Initializes a new instance of the <see cref="IndirectResource"/> class.</summary>
		/// <param name="value">The value of the string.</param>
		public IndirectResource(string? value = null) => RawValue = value;

		/// <summary>Initializes a new instance of the <see cref="IndirectResource"/> class.</summary>
		/// <param name="module">The module file name.</param>
		/// <param name="resourceIdOrIndex">
		/// If this number is positive, this is the index of the resource in the module file. If negative, the absolute value of the number
		/// is the resource ID of the resource in the module file.
		/// </param>
		/// <param name="versionModifier">The version modifier. This value can be, and usually is, <see langword="null"/>.</param>
		public IndirectResource(string module, int resourceIdOrIndex, string? versionModifier = null)
		{
			if (module is null) throw new ArgumentNullException(nameof(module));
			RawValue = $"@{module},{resourceIdOrIndex}" + (versionModifier is null ? "" : ';' + versionModifier);
		}

		/// <summary>Initializes a new instance of the <see cref="IndirectResource"/> class.</summary>
		/// <param name="packageNameOrPriFile">The package name or package resource index file name.</param>
		/// <param name="packageLocator">The package locator.</param>
		/// <exception cref="System.ArgumentNullException">packageNameOrPriFile or packageLocator</exception>
		/// <exception cref="System.ArgumentException">Package locator must start with 'ms-resource://' - packageLocator</exception>
		public IndirectResource(string packageNameOrPriFile, string packageLocator)
		{
			if (packageNameOrPriFile is null) throw new ArgumentNullException(nameof(packageNameOrPriFile));
			if (packageLocator is null) throw new ArgumentNullException(nameof(packageLocator));
			if (!packageLocator.StartsWith("ms-resource://")) throw new ArgumentException("Package locator must start with 'ms-resource://'", nameof(packageLocator));
			RawValue = $"@{{{packageNameOrPriFile}? {packageLocator}}}";
		}

		/// <summary>Returns true if this location is valid.</summary>
		/// <value><c>true</c> if this location is valid; otherwise, <c>false</c>.</value>
		[Browsable(false)]
		public virtual bool IsValid => ModuleFileName != null && ResourceId != 0 || (PackageName != null || PackageResourceIndexFile != null) && PackageLocator != null;

		/// <summary>Gets the module file name.</summary>
		/// <value>The module file name.</value>
		[Browsable(false)]
		public string? ModuleFileName
		{
			get
			{
				if (RawValue is null || RawValue.Length == 0 || RawValue[0] != '@' || RawValue.Length > 1 && RawValue[1] == '{') return null;
				return RawValue.TrimStart('@').Split(',')[0];
			}
		}

		/// <summary>Gets the resource name used to lookup the resource within a package.</summary>
		/// <value>The resource lookup name.</value>
		public string? PackageLocator
		{
			get
			{
				if (RawValue is null || RawValue.Length == 0 || RawValue[0] != '@' || RawValue.Length > 1 && !(RawValue[1] == '{' && RawValue[RawValue.Length - 1] == '}')) return null;
				var parts = RawValue.Substring(2).TrimEnd('}').Split('?');
				return parts.Length > 1 && parts[1].Trim().StartsWith("ms-resource://") ? parts[1].Trim() : null;
			}
		}

		/// <summary>
		/// Gets the name of the package. The string is extracted from the Resources.pri file stored in the app's root directory of the
		/// package identified by PackageFullName, using the resource as a locator. The retrieved string is copied to the output buffer and
		/// the function returns S_OK. The string is extracted based on the app's environment or ResourceContext. Note: This string must
		/// refer to a package installed for the current user.If it does not, the call will fail.
		/// </summary>
		/// <value>The name of the package. Something like "Microsoft.Camera_6.2.8376.0_x64__8wekyb3d8bbwe".</value>
		[Browsable(false)]
		public string? PackageName
		{
			get
			{
				if (RawValue is null || RawValue.Length == 0 || RawValue[0] != '@' || RawValue.Length > 1 && !(RawValue[1] == '{' && RawValue[RawValue.Length - 1] == '}')) return null;
				var parts = RawValue.Substring(2).TrimEnd('}').Split('?');
				return parts[0].IndexOf('\\') >= 0 ? null : parts[0];
			}
		}

		/// <summary>
		/// Gets the package resource index file name. The Package Resource Index (PRI) is a binary format introduced in Windows 8 that
		/// contains indexed resources or references to resources. The .pri file is bundled as part of an app's package. For more
		/// information on .pri files, see Creating and retrieving resources in Windows Store apps. The string is extracted from the.pri
		/// file named, using the resource as a locator.The retrieved string is copied to the output buffer and the function returns S_OK.
		/// The string is extracted based on the current Shell environment or ResourceContext.
		/// </summary>
		/// <value>The package resource index file name. Something like "C:\Program Files\WindowsApps\Microsoft.Camera_6.2.8376.0_x64__8wekyb3d8bbwe\resources.pri".</value>
		[Browsable(false)]
		public string? PackageResourceIndexFile
		{
			get
			{
				if (RawValue is null || RawValue.Length == 0 || RawValue[0] != '@' || RawValue.Length > 1 && !(RawValue[1] == '{' && RawValue[RawValue.Length - 1] == '}')) return null;
				var parts = RawValue.Substring(2).TrimEnd('}').Split('?');
				return parts[0].IndexOf('\\') >= 0 && System.IO.Path.GetExtension(parts[0]) != null && System.IO.Path.GetExtension(RawValue).Equals(".pri", StringComparison.InvariantCultureIgnoreCase) ? parts[0] : null;
			}
		}

		/// <summary>Gets the raw value of the string.</summary>
		/// <value>Returns a <see cref="string"/> value.</value>
		public string? RawValue { get; private set; }

		/// <summary>Gets or sets the resource index or resource ID.</summary>
		/// <value>
		/// If this number is positive, this is the index of the resource in the module file. If negative, the absolute value of the number
		/// is the resource ID of the icon in the module file.
		/// </value>
		[Browsable(false)]
		public int ResourceId
		{
			get
			{
				if (RawValue is null || RawValue.Length == 0 || RawValue[0] != '@' || RawValue.Length > 1 && RawValue[1] == '{') return 0;
				var parts = RawValue.Split(',', ';');
				return parts.Length > 1 && int.TryParse(parts[1], out var i) ? i : 0;
			}
		}

		/// <summary>Gets the version modifier. This value is rarely used.</summary>
		/// <value>The version modifier (e.g. "v2").</value>
		[Browsable(false)]
		public string? VersionModifier
		{
			get
			{
				if (RawValue is null || RawValue.Length == 0 || RawValue[0] != '@' || RawValue.Length > 1 && RawValue[1] == '{') return null;
				var parts = RawValue.Split(',', ';');
				return parts.Length > 2 ? parts[2] : null;
			}
		}

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => RawValue ?? "";
	}
}