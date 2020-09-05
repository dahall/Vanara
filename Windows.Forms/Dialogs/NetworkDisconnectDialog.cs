using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.Extensions;
using static Vanara.PInvoke.Mpr;

namespace Vanara.Windows.Forms
{
	/// <summary>
	/// A dialog box that allows the user to browse and connect to network resources.
	/// </summary>
	/// <seealso cref="System.Windows.Forms.CommonDialog" />
	public class NetworkDisconnectDialog : CommonDialog
	{
		private DISCDLGSTRUCT opts;

		/// <summary>Initializes a new instance of the <see cref="NetworkDisconnectDialog"/> class.</summary>
		public NetworkDisconnectDialog()
		{
			opts.cbStructure = (uint)Marshal.SizeOf(typeof(DISCDLGSTRUCT));
		}

		/// <summary>Gets or sets a value indicating whether to force when attempting to disconnect from the network resource.</summary>
		/// <value><c>true</c> if forcing a disconnect; otherwise, <c>false</c>.</value>
		[DefaultValue(true), Category("Behavior"), Description("Force when attempting to disconnect from the network resource.")]
		public bool ForceDisconnect
		{
			get => !opts.dwFlags.IsFlagSet(DISC.DISC_NO_FORCE);
			set => opts.dwFlags = opts.dwFlags.SetFlags(DISC.DISC_NO_FORCE, !value);
		}

		/// <summary>Gets or sets the name of the local device, such as "F:" or "LPT1".</summary>
		/// <value>The name of the local device.</value>
		[DefaultValue(null), Category("Behavior"), Description("The local device name.")]
		public string LocalDeviceName { get => opts.lpLocalName; set => opts.lpLocalName = value; }

		/// <summary>Gets or sets the name of the remote network.</summary>
		/// <value>The name of the remote network.</value>
		[DefaultValue(null), Category("Behavior"), Description("The value displayed in the path field.")]
		public string RemoteNetworkName { get => opts.lpRemoteName; set => opts.lpRemoteName = value; }

		/// <summary>Gets or sets a value indicating whether to enter the most recently used paths into the combination box.</summary>
		/// <value><c>true</c> to use MRU path; otherwise, <c>false</c>.</value>
		/// <exception cref="InvalidOperationException">UseMostRecentPath</exception>
		[DefaultValue(false), Category("Behavior"), Description("Enter the most recently used paths into the combination box.")]
		public bool UpdateProfile
		{
			get => opts.dwFlags.IsFlagSet(DISC.DISC_UPDATE_PROFILE);
			set
			{
				if (value && string.IsNullOrEmpty(opts.lpLocalName))
					throw new InvalidOperationException($"{nameof(UpdateProfile)} cannot be set to true if {nameof(LocalDeviceName)} is null or empty.");
				opts.dwFlags = opts.dwFlags.SetFlags(DISC.DISC_UPDATE_PROFILE, value);
			}
		}

		/// <inheritdoc/>
		public override void Reset()
		{
			opts.dwFlags = 0;
			opts.lpLocalName = opts.lpRemoteName = null;
		}

		/// <inheritdoc/>
		protected override bool RunDialog(IntPtr hwndOwner)
		{
			opts.hwndOwner = hwndOwner;
			var ret = WNetDisconnectDialog1(opts);
			if (ret == unchecked((uint)-1)) return false;
			ret.ThrowIfFailed();
			return true;
		}
	}
}