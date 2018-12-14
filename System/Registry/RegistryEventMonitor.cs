using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Threading;
using Vanara.PInvoke;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Registry
{
	/// <summary>Watches the Windows Registry for any changes.</summary>
	[DefaultEvent(nameof(SubkeyChanged))]
	public class RegistryEventMonitor : Component, ISupportInitialize
	{
		private const int eventCount = 4;
		private static readonly RegNotifyChangeFilter[] events = { RegNotifyChangeFilter.REG_NOTIFY_CHANGE_LAST_SET, RegNotifyChangeFilter.REG_NOTIFY_CHANGE_NAME, RegNotifyChangeFilter.REG_NOTIFY_CHANGE_ATTRIBUTES, RegNotifyChangeFilter.REG_NOTIFY_CHANGE_SECURITY };
		private readonly Action<RegistryEventArgs>[] actions;
		private readonly ManualResetEvent breakEvent = new ManualResetEvent(false);
		private readonly object threadLock = new object();
		private readonly Thread[] threads = new Thread[eventCount];
		private readonly AutoResetEvent[] threadsEnded = new AutoResetEvent[eventCount];
		private readonly AutoResetEvent[] threadsStarted = new AutoResetEvent[eventCount];
		private bool enabled;
		private SafeRegistryHandle hkey;
		private bool includeSubKeys;
		private bool initializing;
		private string keyName;
		private string remoteMachine;
		private ISynchronizeInvoke synchObj;

		/// <summary>Initializes a new instance of the <see cref="RegistryEventMonitor"/> class.</summary>
		public RegistryEventMonitor()
		{
			actions = new Action<RegistryEventArgs>[eventCount] { OnValueChanged, OnSubkeyChanged, OnAttributesChanged, OnSecurityChanged };
			for (var i = 0; i < eventCount; i++)
			{
				threadsStarted[i] = new AutoResetEvent(false);
				threadsEnded[i] = new AutoResetEvent(false);
			}
		}

		/// <summary>Initializes a new instance of the <see cref="RegistryEventMonitor"/> class.</summary>
		/// <param name="registryKey">
		/// The root registry key. Events will be watched in this key and optionally below (set <paramref name="includeSubKeys"/> to <see langword="true"/>).
		/// </param>
		/// <param name="includeSubKeys">if set to <c>true</c>, include sub keys.</param>
		public RegistryEventMonitor(RegistryKey registryKey, bool includeSubKeys) : this()
		{
			RegistryKey = registryKey;
			IncludeSubKeys = includeSubKeys;
		}

		/// <summary>Occurs when attributes have changed.</summary>
		[Category("Behavior"), Description("An attribute has changed.")]
		public event EventHandler<RegistryEventArgs> AttributesChanged;

		/// <summary>Occurs when key security has changed.</summary>
		[Category("Behavior"), Description("Key security has changed.")]
		public event EventHandler<RegistryEventArgs> SecurityChanged;

		/// <summary>Occurs when a subkey has changed.</summary>
		[Category("Behavior"), Description("A subkey has changed.")]
		public event EventHandler<RegistryEventArgs> SubkeyChanged;

		/// <summary>Occurs when a value has changed.</summary>
		[Category("Behavior"), Description("A value has changed.")]
		public event EventHandler<RegistryEventArgs> ValueChanged;

		/// <summary>Gets or sets a value indicating whether to enable raising events.</summary>
		/// <value><c>true</c> if raising events is enabled; otherwise, <c>false</c>.</value>
		[DefaultValue(false), Category("Behavior"), Description("Whether to enable raising events.")]
		public bool EnableRaisingEvents
		{
			get => enabled;
			set
			{
				if (enabled == value) return;
				enabled = value;
				if (IsSuspended) return;
				if (value)
					StartRaisingEvents();
				else
					StopRaisingEvents();
			}
		}

		/// <summary>Gets or sets a value indicating whether to monitor all subkeys.</summary>
		/// <value><c>true</c> if [include sub keys]; otherwise, <c>false</c>.</value>
		[DefaultValue(false), Category("Behavior"), Description("Whether to monitor all subkeys.")]
		public bool IncludeSubKeys
		{
			get => includeSubKeys;
			set
			{
				if (includeSubKeys == value) return;
				includeSubKeys = value;
				Restart();
			}
		}

		/// <summary>Gets or sets the machine name.</summary>
		/// <value>The machine name. Use <see langword="null"/> or <see cref="string.Empty"/> to represent the local machine.</value>
		[DefaultValue(null), Category("Behavior"), Description("The machine name.")]
		public string MachineName
		{
			get => remoteMachine;
			set
			{
				if (value == string.Empty) value = null;
				if (value != null)
				{
					if (!value.StartsWith("\\")) value = "\\" + value;
					if (value.LastIndexOf('\\') > 0) throw new ArgumentException("Machine name cannot have any path delimiters.");
				}
				if (string.Equals(remoteMachine, value, StringComparison.InvariantCultureIgnoreCase)) return;
				remoteMachine = value;
			}
		}

		/// <summary>
		/// Gets or sets the root registry key. Events will be watched in this key and optionally below (set <see cref="IncludeSubKeys"/> to
		/// <see langword="true"/>).
		/// </summary>
		[Browsable(false)]
		public RegistryKey RegistryKey
		{
			get => RegistryKeyFromName(RegistryKeyName, remoteMachine);
			set => RegistryKeyName = value?.Name;
		}

		/// <summary>Gets or sets the name of the root registry key to monitor.</summary>
		[DefaultValue(null), Category("Behavior"), Description("The name of the root registry key to monitor.")]
		public string RegistryKeyName
		{
			get => keyName;
			set
			{
				if (string.Equals(keyName, value, StringComparison.InvariantCultureIgnoreCase)) return;
				keyName = value;
				Restart();
			}
		}

		/// <summary>Gets or sets the object used to marshal the event handler calls issued as a result of a registry change.</summary>
		/// <value>
		/// The <see cref="ISynchronizeInvoke"/> that represents the object used to marshal the event handler calls issued as a result of a
		/// registry change. The default is <see langword="null"/>.
		/// </value>
		/// <remarks>
		/// When SynchronizingObject is <see langword="null"/>, methods handling the <see cref="AttributesChanged"/>,
		/// <see cref="SecurityChanged"/>, <see cref="SubkeyChanged"/>, and <see cref="ValueChanged"/> events are called on a thread from the
		/// system thread pool. For more information on system thread pools, see ThreadPool.
		/// <para>
		/// When the <see cref="AttributesChanged"/>, <see cref="SecurityChanged"/>, <see cref="SubkeyChanged"/>, and <see cref="ValueChanged"/>
		/// events are handled by a visual Windows Forms component, such as a Button, accessing the component through
		/// the system thread pool might not work, or may result in an exception. Avoid this by setting SynchronizingObject to a Windows
		/// Forms component, which causes the methods that handle the <see cref="AttributesChanged"/>, <see cref="SecurityChanged"/>,
		/// <see cref="SubkeyChanged"/>, and <see cref="ValueChanged"/> events to be called on the same thread on which the component was created.
		/// </para>
		/// <para>
		/// If the <see cref="RegistryEventMonitor"/> is used inside Visual Studio in a Windows Forms designer, SynchronizingObject
		/// automatically sets to the control that contains the <see cref="RegistryEventMonitor"/>. For example, if you place a
		/// <see cref="RegistryEventMonitor"/> on a designer for Form1 (which inherits from Form) the SynchronizingObject property of 
		/// <see cref="RegistryEventMonitor"/> is set to the instance of Form1.
		/// </para>
		/// </remarks>
		[Browsable(false), DefaultValue(null)]
		public ISynchronizeInvoke SynchronizingObject
		{
			get
			{
				if (synchObj == null && DesignMode)
				{
					var service = (IDesignerHost)GetService(typeof(IDesignerHost));
					if (service?.RootComponent is ISynchronizeInvoke root)
						synchObj = root;
				}
				return synchObj;
			}
			set => synchObj = value;
		}

		private bool IsSuspended => initializing || DesignMode;

		/// <summary>Signals the object that initialization is starting.</summary>
		public void BeginInit()
		{
			var enabled = EnableRaisingEvents;
			StopRaisingEvents();
			EnableRaisingEvents = enabled;
			initializing = true;
		}

		/// <summary>Signals the object that initialization is complete.</summary>
		public void EndInit()
		{
			initializing = false;
			if (keyName != null && EnableRaisingEvents)
				StartRaisingEvents();
		}

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		/// <param name="disposing">
		/// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
		/// </param>
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing)
				{
					StopRaisingEvents();
					hkey?.Dispose();
					hkey = null;
				}
				else
					keyName = null;
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		/// <summary>Raises the <see cref="E:AttributesChanged"/> event.</summary>
		/// <param name="e">The <see cref="RegistryEventArgs"/> instance containing the event data.</param>
		protected virtual void OnAttributesChanged(RegistryEventArgs e)
		{
			SynchedInvoke(AttributesChanged, e);
		}

		/// <summary>Raises the <see cref="E:SecurityChanged"/> event.</summary>
		/// <param name="e">The <see cref="RegistryEventArgs"/> instance containing the event data.</param>
		protected virtual void OnSecurityChanged(RegistryEventArgs e)
		{
			SynchedInvoke(SecurityChanged, e);
		}

		/// <summary>Raises the <see cref="E:SubkeyChanged"/> event.</summary>
		/// <param name="e">The <see cref="RegistryEventArgs"/> instance containing the event data.</param>
		protected virtual void OnSubkeyChanged(RegistryEventArgs e)
		{
			SynchedInvoke(SubkeyChanged, e);
		}

		/// <summary>Raises the <see cref="E:ValueChanged"/> event.</summary>
		/// <param name="e">The <see cref="RegistryEventArgs"/> instance containing the event data.</param>
		protected virtual void OnValueChanged(RegistryEventArgs e)
		{
			SynchedInvoke(ValueChanged, e);
		}

		private static SafeRegistryHandle RegistryHandleFromName(string keyName, string serverName = null)
		{
			if (keyName == null)
				return null;

			var index = keyName.IndexOf('\\');
			var str = index != -1 ? keyName.Substring(0, index).ToUpper(System.Globalization.CultureInfo.InvariantCulture) : keyName.ToUpper(System.Globalization.CultureInfo.InvariantCulture);

			if (!(typeof(Vanara.PInvoke.AdvApi32).GetField(str)?.GetValue(null) is HKEY hive))
				return null;

			try
			{
				RegConnectRegistry(serverName, hive, out var mhive).ThrowIfFailed();
				if ((index == -1) || (index == keyName.Length))
					return mhive;
				var subKeyName = keyName.Substring(index + 1, (keyName.Length - index) - 1);
				RegOpenKeyEx(mhive, subKeyName, 0, RegAccessTypes.KEY_NOTIFY, out var hkey).ThrowIfFailed();
				return hkey;
			}
			catch
			{
				return null;
			}
		}

		private static RegistryKey RegistryKeyFromName(string keyName, string serverName = null)
		{
			if (keyName == null)
				return null;

			var index = keyName.IndexOf('\\');
			var str = index != -1 ? keyName.Substring(0, index).ToUpper(System.Globalization.CultureInfo.InvariantCulture) : keyName.ToUpper(System.Globalization.CultureInfo.InvariantCulture);
			RegistryHive hive;
			switch (str)
			{
				case "HKEY_CLASSES_ROOT":
					hive = RegistryHive.ClassesRoot;
					break;

				case "HKEY_CURRENT_USER":
					hive = RegistryHive.CurrentUser;
					break;

				case "HKEY_LOCAL_MACHINE":
					hive = RegistryHive.LocalMachine;
					break;

				case "HKEY_USERS":
					hive = RegistryHive.Users;
					break;

				case "HKEY_PERFORMANCE_DATA":
					hive = RegistryHive.PerformanceData;
					break;

				case "HKEY_CURRENT_CONFIG":
					hive = RegistryHive.CurrentConfig;
					break;
#if (NET20 || NET35 || NET40 || NET45)
				case "HKEY_DYN_DATA":
					hive = RegistryHive.DynData;
					break;
#endif
				default:
					return null;
			}

			try
			{
				var mhive = RegistryKey.OpenRemoteBaseKey(hive, serverName ?? string.Empty);
				if ((index == -1) || (index == keyName.Length))
					return mhive;
				var subKeyName = keyName.Substring(index + 1, (keyName.Length - index) - 1);
				return mhive.OpenSubKey(subKeyName, RegistryKeyPermissionCheck.Default, System.Security.AccessControl.RegistryRights.Notify);
			}
			catch
			{
				return null;
			}
		}

		private void MonitorRegThreadProc(object i)
		{
			var idx = (int)i;
			var filter = events[idx];
			using (var autoEvent = new AutoResetEvent(false))
			using (var hEvent = autoEvent.SafeWaitHandle)
			{
				var waitHandles = new WaitHandle[] { autoEvent, breakEvent };
				while (!breakEvent.WaitOne(0, true))
				{
					Debug.WriteLine($"Calling RegNotify for {filter}");
					RegNotifyChangeKeyValue(hkey, includeSubKeys, filter, hEvent, true).ThrowIfFailed();
					threadsStarted[idx].Set();
					Debug.WriteLine($"Waiting for {filter}");
					if (WaitHandle.WaitAny(waitHandles) == 0)
					{
						Debug.WriteLine($"Event called for {filter}");
						actions[idx]?.Invoke(new RegistryEventArgs(RegistryKeyName, IncludeSubKeys));
					}
					else
					{
						Debug.WriteLine($"Canceled {filter}");
					}
				}
			}
			threadsEnded[idx].Set();
			Debug.WriteLine($"Exiting {filter}");
		}

		private void Restart()
		{
			if (IsSuspended || !EnableRaisingEvents) return;
			StopRaisingEvents();
			StartRaisingEvents();
		}

		private void StartRaisingEvents()
		{
			if (Environment.OSVersion.Platform != PlatformID.Win32NT)
				throw new PlatformNotSupportedException();
			if (keyName == null) throw new ArgumentNullException(nameof(RegistryKeyName));
			if (!IsSuspended && EnableRaisingEvents)
			{
				lock (threadLock)
				{
					breakEvent.Reset();
					hkey = RegistryHandleFromName(keyName, remoteMachine);
					if (hkey == null || hkey.IsClosed || hkey.IsInvalid) throw new InvalidOperationException($"Unable to connect to registry key specified in {nameof(RegistryKeyName)}");
					for (var i = 0; i < eventCount; i++)
					{
						threads[i]?.Abort();
						threads[i] = new Thread(MonitorRegThreadProc) { IsBackground = false };
						threads[i].Start(i);
					}
					if (!WaitHandle.WaitAll(threadsStarted, 5000))
					{
						StopRaisingEvents();
						throw new InvalidOperationException("Threads waiting for changes failed to start within reasonable time.");
					}
				}
			}
		}

		private void StopRaisingEvents()
		{
			if (IsSuspended) return;
			breakEvent.Set();
			WaitHandle.WaitAll(threadsEnded);
			enabled = false;
		}

		private void SynchedInvoke(EventHandler<RegistryEventArgs> h, RegistryEventArgs e)
		{
			if (h == null) return;
			if (SynchronizingObject != null && SynchronizingObject.InvokeRequired)
				SynchronizingObject.BeginInvoke(h, new object[] { this, e });
			else
				h.Invoke(this, e);
		}

		/// <summary>Argument used in <see cref="RegistryEventMonitor"/> events.</summary>
		/// <seealso cref="System.EventArgs"/>
		public class RegistryEventArgs : EventArgs
		{
			internal RegistryEventArgs(string keyName, bool inclSubKeys)
			{
				RegistryKeyName = keyName;
				IncludeSubKeys = inclSubKeys;
			}

			/// <summary>Gets a value indicating whether subkeys were monitored.</summary>
			/// <value><c>true</c> if subkeys were monitored; otherwise, <c>false</c>.</value>
			public bool IncludeSubKeys { get; }

			/// <summary>Gets the name of the root registry key being monitored.</summary>
			public string RegistryKeyName { get; }
		}
	}
}