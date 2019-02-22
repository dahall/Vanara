using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Vanara
{
	/// <summary>Represents a single connected (authenticated) computer.</summary>
	/// <seealso cref="System.ComponentModel.Component"/>
	/// <seealso cref="System.ComponentModel.ISupportInitialize"/>
	/// <seealso cref="System.Runtime.Serialization.ISerializable"/>
	[Serializable, DefaultProperty(nameof(Target))]
	public class Computer : Component, ISupportInitialize, ISerializable
	{
		/// <summary>The local computer connected by the current account.</summary>
		public static readonly Computer Local = new Computer();

		private bool initializing;
		private string targetServer;
		private bool targetServerSet;
		private string userName;
		private bool userNameSet;
		private string userPassword;
		private bool userPasswordSet;
		private SharedDevices devices;

		/// <summary>Creates a new instance of a TaskService connecting to the local machine as the current user.</summary>
		public Computer() => Connect();

		/// <summary>Initializes a new instance of the <see cref="Computer"/> class.</summary>
		/// <param name="target">
		/// The name of the computer that you want to connect to. If the this parameter is <see langword="null"/>, then this will connect to
		/// the local computer.
		/// </param>
		/// <param name="userName">
		/// The user name that is used during the connection to the computer. If the user is not specified, then the current user is used.
		/// </param>
		/// <param name="password">
		/// The password that is used to connect to the computer. If the user name and password are not specified, then the current token is used.
		/// </param>
		public Computer(string target, string userName = null, string accountDomain = null, string password = null)
		{
			BeginInit();
			Target = target;
			UserName = userName;
			UserPassword = password;
			EndInit();
		}

		private Computer(SerializationInfo info, StreamingContext context)
		{
			BeginInit();
			Target = (string)info.GetValue(nameof(Target), typeof(string));
			UserName = (string)info.GetValue(nameof(UserName), typeof(string));
			UserPassword = (string)info.GetValue(nameof(UserPassword), typeof(string));
			EndInit();
		}

		/// <summary>Gets or sets the name of the computer that the user is connected to.</summary>
		[Category("Data"), DefaultValue(null), Description("The name of the computer to connect to.")]
		public string Target
		{
			get => ShouldSerializeTargetServer() ? targetServer : null;
			set
			{
				if (value == null || value.Trim() == string.Empty) value = null;
				if (string.Compare(value, targetServer, StringComparison.OrdinalIgnoreCase) != 0)
				{
					targetServerSet = true;
					targetServer = value;
					Connect();
				}
			}
		}

		/// <summary>Gets the shared devices defined for this computer.</summary>
		/// <value>Returns a <see cref="SharedDevices"/> value.</value>
		[Browsable(false)]
		public SharedDevices SharedDevices => devices ?? (devices = new SharedDevices(this));

		//public IEnumerable<LocalUser> LocalUsers => LocalUser.GetEnum(Target, UserName, UserPassword);

		//public IEnumerable<LocalGroup> LocalGroups => LocalGroup.GetEnum(Target, UserName, UserPassword);

		/// <summary>Gets or sets the user name to be used when connecting to the <see cref="Target"/>.</summary>
		/// <value>The user name.</value>
		[Category("Data"), DefaultValue(null), Description("The user name to be used when connecting.")]
		public string UserName
		{
			get => ShouldSerializeUserName() ? userName : null;
			set
			{
				if (value == null || value.Trim() == string.Empty) value = null;
				if (string.Compare(value, userName, StringComparison.OrdinalIgnoreCase) != 0)
				{
					userNameSet = true;
					userName = value;
					Connect();
				}
			}
		}

		/// <summary>Gets or sets the user password to be used when connecting to the <see cref="Target"/>.</summary>
		/// <value>The user password.</value>
		[Category("Data"), DefaultValue(null), Description("The user password to be used when connecting.")]
		public string UserPassword
		{
			get => userPassword;
			set
			{
				if (value == null || value.Trim() == string.Empty) value = null;
				if (string.CompareOrdinal(value, userPassword) != 0)
				{
					userPasswordSet = true;
					userPassword = value;
					Connect();
				}
			}
		}

		/// <summary>Signals the object that initialization is starting.</summary>
		public void BeginInit() => initializing = true;

		/// <summary>Signals the object that initialization is complete.</summary>
		public void EndInit()
		{
			initializing = false;
			Connect();
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue(nameof(Target), Target, typeof(string));
			info.AddValue(nameof(UserName), UserName, typeof(string));
			info.AddValue(nameof(UserPassword), UserPassword, typeof(string));
		}

		private void Connect()
		{
			ResetUnsetProperties();

			if (!initializing && !DesignMode)
			{
				// Clear stuff if already connected
				Dispose(true);

				if (!string.IsNullOrEmpty(targetServer))
				{
					// Check to ensure character only server name. (Suggested by bigsan)
					if (targetServer.StartsWith(@"\"))
						targetServer = targetServer.TrimStart('\\');
					// Make sure null is provided for local machine to compensate for a native library oddity (Found by ctrollen)
					if (targetServer.Equals(Environment.MachineName, StringComparison.CurrentCultureIgnoreCase))
						targetServer = null;
				}
				else
					targetServer = null;
			}
		}

		private void ResetUnsetProperties()
		{
			if (!targetServerSet) targetServer = null;
			if (!userNameSet) userName = null;
			if (!userPasswordSet) userPassword = null;
		}

		private bool ShouldSerializeTargetServer() => targetServer != null && !targetServer.Trim('\\').Equals(Environment.MachineName.Trim('\\'), StringComparison.InvariantCultureIgnoreCase);

		private bool ShouldSerializeUserName() => userName != null && !userName.Equals(Environment.UserName, StringComparison.InvariantCultureIgnoreCase);
	}
}