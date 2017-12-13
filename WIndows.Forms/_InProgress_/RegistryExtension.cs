using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Threading;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.Extensions
{
	public static partial class ControlExtension
	{
		[DefaultEvent(nameof(SubkeyChanged))]
		public class RegistryWatcher : Component, ISupportInitialize
		{
			private int currentSession;
			private bool enableEvents;
			private bool includeSubKeys;
			private bool initializing;
			private RegistryKey key;
			private Thread thread;
			private readonly object threadLock = new object();
			private ISynchronizeInvoke synchObj;
			private readonly ManualResetEvent breakEvent = new ManualResetEvent(false);

			private const RegNotifyChangeFilter stdEvents = RegNotifyChangeFilter.REG_NOTIFY_CHANGE_ATTRIBUTES |
			                                                RegNotifyChangeFilter.REG_NOTIFY_CHANGE_LAST_SET |
			                                                RegNotifyChangeFilter.REG_NOTIFY_CHANGE_NAME |
			                                                RegNotifyChangeFilter.REG_NOTIFY_CHANGE_SECURITY;

			public RegistryWatcher()
			{
			}

			public RegistryWatcher(RegistryKey registryKey, bool includeSubKeys) : this()
			{
				key = registryKey;
				IncludeSubKeys = includeSubKeys;
			}

			public event EventHandler<RegistryEventArgs> SubkeyChanged;

			public event EventHandler<RegistryEventArgs> ValueChanged;

			public bool EnableRaisingEvents
			{
				get { return enableEvents; }
				set { enableEvents = value; }
			}

			public bool IncludeSubKeys
			{
				get { return includeSubKeys; }
				set
				{
					if (includeSubKeys == value) return;
					includeSubKeys = value;
					Restart();
				}
			}

			public RegistryKey RegistryKey
			{
				get { return key; }
				set
				{
					if (!RegistryKey.Equals(key, value))
					{
						key = value;
						Restart();
					}
				}
			}

			public override ISite Site
			{
				get { return base.Site; }
				set
				{
					base.Site = value;
					if (value != null && value.DesignMode) EnableRaisingEvents = true;
				}
			}

			public ISynchronizeInvoke SynchronizingObject
			{
				get
				{
					if (synchObj == null && DesignMode)
					{
						var service = (IDesignerHost)GetService(typeof(IDesignerHost));
						var root = service?.RootComponent as ISynchronizeInvoke;
						if (root != null)
							synchObj = root;
					}
					return synchObj;
				}
				set { synchObj = value; }
			}

			private bool IsSuspended => initializing || DesignMode;

			public void BeginInit()
			{
				var enabled = enableEvents;
				StopRaisingEvents();
				enableEvents = enabled;
				initializing = true;
			}

			public void EndInit()
			{
				initializing = false;
				if (key != null && enableEvents)
					StartRaisingEvents();
			}

			protected override void Dispose(bool disposing)
			{
				try
				{
					if (disposing)
					{
						StopRaisingEvents();
					}
					else
					{
						key = null;
					}
				}
				finally
				{
					base.Dispose(disposing);
				}
			}

			protected void OnSubkeyChanged(RegistryEventArgs e)
			{
				SubkeyChanged?.Invoke(this, e);
			}

			protected void OnValueChanged(RegistryEventArgs e)
			{
				ValueChanged?.Invoke(this, e);
			}

			private void Monitor()
			{
				if (enableEvents && key != null)
				{
					//hEvent = CreateEvent(null, true, false, null);
					//if (0 != RegNotifyChangeKeyValue(key.Handle, includeSubKeys, stdEvents, hEvent, true))
					//	throw new Win32Exception();
					lock (threadLock)
					{
						if (thread == null)
						{
							breakEvent.Reset();
							thread = new Thread(new ThreadStart(ThreadTarget)) { IsBackground = true };
							thread.Start();
						}
					}
				}
			}

			private void ThreadTarget()
			{
				try
				{
					var autoEvent = new AutoResetEvent(false);
					var waitHandles = new WaitHandle[] { autoEvent, breakEvent };
					while (!breakEvent.WaitOne(0, true))
					{
#pragma warning disable 618
						var result = RegNotifyChangeKeyValue(key.Handle, includeSubKeys, stdEvents, autoEvent.Handle, true);
#pragma warning restore 618
						if (result != 0)
							throw new Win32Exception(result);
				
						if (WaitHandle.WaitAny(waitHandles) == 0)
						{
							OnRegChanged();
						}
					}
				}
				finally
				{
				}
			}

			private void Restart()
			{
				if (IsSuspended || !enableEvents) return;
				StopRaisingEvents();
				StartRaisingEvents();
			}

			private void StartRaisingEvents()
			{
				if (Environment.OSVersion.Platform != PlatformID.Win32NT)
					throw new PlatformNotSupportedException();
				if (IsSuspended)
				{
					enableEvents = true;
				}
				else
				{
					Monitor();
				}
			}

			private void StopRaisingEvents()
			{
				if (IsSuspended)
					enableEvents = false;
				else if (key != null)
				{
					stopListening = true;
					key = null;
					Interlocked.Increment(ref currentSession);
					enableEvents = false;
				}
			}

			public class RegistryEventArgs : EventArgs { }
		}
	}
}