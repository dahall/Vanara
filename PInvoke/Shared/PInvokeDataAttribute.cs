using System;

namespace Vanara.PInvoke
{
	/// <summary>Flags that determine the minimum supported client(s) for a P/Invoke function.</summary>
	[Flags]
	public enum PInvokeClient
	{
		/// <summary>No minimum (default).</summary>
		None = 0,

		/// <summary>Windows 2000</summary>
		Windows2000 = 0x1,

		/// <summary>Windows XP</summary>
		WindowsXP = 0x3,

		/// <summary>Windows XP SP2</summary>
		WindowsXP_SP2 = 0x7,

		/// <summary>Windows Vista</summary>
		WindowsVista = 0xF,

		/// <summary>Windows Vista SP2</summary>
		WindowsVista_SP2 = 0x1F,

		/// <summary>Windows 7</summary>
		Windows7 = 0x3F,

		/// <summary>Windows 8</summary>
		Windows8 = 0x7F,

		/// <summary>Windows 8.1</summary>
		Windows81 = 0xFF,

		/// <summary>Windows 10</summary>
		Windows10 = 0x1FF,

		/// <summary>Windows 11</summary>
		Windows11 = 0x2FF
	}

	/// <summary>Captures information about P/Invoke calls.</summary>
	/// <seealso cref="Attribute"/>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Event |
					AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Method |
					AttributeTargets.Property | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
	public class PInvokeDataAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="PInvokeDataAttribute"/> class.</summary>
		/// <param name="header">The header.</param>
		public PInvokeDataAttribute(string header) => Header = header;

		/// <summary>Gets or sets the DLL in which this element is defined.</summary>
		/// <value>The DLL file name without the path (e.g. "advapi32.dll").</value>
		public string? Dll { get; set; }

		/// <summary>Gets or sets the header in which this element is defined.</summary>
		/// <value>The header file name without the path (e.g. "winuser.h").</value>
		public string Header { get; set; }

		/// <summary>Gets or sets the minimum supported client.</summary>
		/// <value>The minimum supported client.</value>
		public PInvokeClient MinClient { get; set; }

		/// <summary>Gets or sets the MSDN short identifier.</summary>
		/// <value>The MSDN short identifier. This is a unique 8-character alphanumeric string used for Microsoft documentation.</value>
		public string? MSDNShortId { get; set; }
	}
}

namespace Vanara.Extensions
{
	/// <summary>Extension methods for <see cref="PInvoke.PInvokeClient"/>.</summary>
	public static class PInvokeClientExtensions
	{
		/// <summary>Determines whether the running OS is minimally the one specified.</summary>
		/// <param name="client">The OS version to check.</param>
		/// <returns><see langword="true"/> if the running OS is minimally the specified client; otherwise, <see langword="false"/>.</returns>
		public static bool IsPlatformSupported(this PInvoke.PInvokeClient client)
		{
			var osVer = System.Environment.OSVersion.Version;

			switch (client)
			{
				case PInvoke.PInvokeClient.None:
					return true;
				case PInvoke.PInvokeClient.Windows2000:
					return osVer.Major >= 5;
				case PInvoke.PInvokeClient.WindowsXP:
					return osVer >= new Version(5, 1);
				case PInvoke.PInvokeClient.WindowsXP_SP2:
					return osVer >= new Version(5, 1, 2600, 2180);
				case PInvoke.PInvokeClient.WindowsVista:
					return osVer.Major >= 6;
				case PInvoke.PInvokeClient.WindowsVista_SP2:
					return osVer >= new Version(6, 0, 6002);
				case PInvoke.PInvokeClient.Windows7:
					return osVer >= new Version(6, 1);
				case PInvoke.PInvokeClient.Windows8:
					return osVer >= new Version(6, 2);
				case PInvoke.PInvokeClient.Windows81:
					return osVer >= new Version(6, 3);
				case PInvoke.PInvokeClient.Windows10:
					return osVer.Major >= 10;
				case PInvoke.PInvokeClient.Windows11:
					return osVer >= new Version(10, 0, 22000);
				default:
					return false;
			}
		}
	}
}