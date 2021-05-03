using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.CfgMgr32;
using static Vanara.PInvoke.SetupAPI;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class CfgMgr32Tests
	{
		private static readonly Guid devguid = GUID_DEVCLASS_DISKDRIVE;
		private static readonly Lazy<uint> leaf = new(() => GetFirstLeaf(root.Value));
		private static readonly Lazy<uint> node = new(() => LocateNode(@"USB\ROOT_HUB30\4&3490C39&0&0"));
		private static readonly Lazy<uint> root = new(() => LocateNode());

		private ElevPriv priv;

		public static uint LeafId => leaf.Value;

		public static uint NodeId => node.Value;

		public static uint RootId => root.Value;

		private static uint LocateNode(string devId = null)
		{
			CM_Locate_DevNode(out var di, devId, CM_LOCATE_DEVNODE.CM_LOCATE_DEVNODE_NORMAL).ThrowIfFailed();
			return di;
		}

		[OneTimeSetUp]
		public void _Setup()
		{
			priv = new ElevPriv("SeLoadDriverPrivilege");
		}

		[OneTimeTearDown]
		public void _TearDown()
		{
			priv?.Dispose();
		}

		[Test]
		public void StructSizeTest() => TestContext.Write(string.Join("\n", TestHelper.GetNestedStructSizes(typeof(CfgMgr32))));

		[Test]
		public void CM_Add_Empty_Log_ConfTest()
		{
			Assert.That(CM_Add_Empty_Log_Conf(out SafeLOG_CONF hConf, LeafId, PRIORITY.LCPRI_NORMAL, LOG_CONF_FLAG.BASIC_LOG_CONF), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			Assert.That(() => hConf.Dispose(), Throws.Nothing);
		}

		[Test]
		public void CM_Add_Res_DesTest()
		{
			Assert.That(CM_Add_Empty_Log_Conf(out var BootLC1, NodeId, PRIORITY.LCPRI_NORMAL, LOG_CONF_FLAG.BOOT_LOG_CONF), Is.EqualTo(CONFIGRET.CR_SUCCESS));

			var memRes = new MEM_RESOURCE
			{
				MEM_Header = new MEM_DES
				{
					MD_Count = 2,
					MD_Type = MType_Range,
					MD_Alloc_Base = 0xD8000,
					MD_Alloc_End = 0xD9000,
					MD_Flags = MEM_DES_FLAGS.fMD_ROM | MEM_DES_FLAGS.fMD_32 | MEM_DES_FLAGS.fMD_ReadAllowed,
					MD_Reserved = 0
				},
				MEM_Data = new MEM_RANGE[]
				{
					new MEM_RANGE
					{
						MR_Align = 8, //?
						MR_nBytes = 4096,
						MR_Min = 0xD8000,
						MR_Max = 0xDC000,
						MR_Flags = MEM_DES_FLAGS.fMD_ROM | MEM_DES_FLAGS.fMD_32 | MEM_DES_FLAGS.fMD_ReadAllowed,
						MR_Reserved = 0
					},

					new MEM_RANGE
					{
						MR_Align = 8, //?
						MR_nBytes = 4096,
						MR_Min = 0xE0000,
						MR_Max = 0xE4000,
						MR_Flags = MEM_DES_FLAGS.fMD_ROM | MEM_DES_FLAGS.fMD_32 | MEM_DES_FLAGS.fMD_ReadAllowed,
						MR_Reserved = 0
					}
				}
			};

			SafeRES_DES hRD = null;
			Assert.That(() => hRD = CM_Add_Res_Des(BootLC1, memRes), Throws.Nothing);
			hRD?.Dispose();
			BootLC1.Dispose();
		}

		[Test]
		public void CM_Connect_MachineTest()
		{
			Assert.That(CM_Connect_Machine(null, out SafeHMACHINE hMach), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			Assert.That(() => hMach.Dispose(), Throws.Nothing);
		}

		[Test]
		public void CM_Enable_DevNodeTest()
		{
			Assert.That(CM_Disable_DevNode(LeafId), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			Assert.That(CM_Enable_DevNode(LeafId), Is.EqualTo(CONFIGRET.CR_SUCCESS));
		}

		[Test]
		public void CM_Enumerate_ClassesTest()
		{
			IEnumerable<Guid> classes = null;
			Assert.That(() => classes = CM_Enumerate_Classes(CM_ENUMERATE_CLASSES.CM_ENUMERATE_CLASSES_INSTALLER), Throws.Nothing);
			Assert.That(classes, Is.Not.Empty);
			TestContext.Write(string.Join("\n", classes));
		}

		[Test]
		public void CM_Enumerate_EnumeratorsTest()
		{
			string[] enums = null;
			Assert.That(() => enums = CM_Enumerate_Enumerators().ToArray(), Throws.Nothing);
			Assert.That(enums, Is.Not.Empty);
			TestContext.Write(string.Join("\n", enums));
		}

		[Test]
		public void CM_Get_ChildrenTest()
		{
			Assert.That(() =>
			{
				foreach (var cid in CM_GetChildren(RootId))
					WriteChildId(cid);
			}, Throws.Nothing);

			static void WriteChildId(uint di)
			{
				if (CM_Get_Device_ID_Size(out var len, di) == CONFIGRET.CR_SUCCESS)
				{
					var sb = new StringBuilder((int)len + 1);
					if (CM_Get_Device_ID(di, sb, len + 1) == CONFIGRET.CR_SUCCESS)
					{
						TestContext.WriteLine(sb);
						return;
					}
				}
				TestContext.WriteLine($"Err: {di}");
			}
		}

		[Test]
		public void CM_Get_Class_PropertyTest()
		{
			var cls = devguid;
			var pkey = DEVPKEY_DeviceClass_IconPath;
			var sz = 0U;
			Assert.That(CM_Get_Class_Property(cls, pkey, out var dpType, default, ref sz, CM_CLASS_PROPERTY.CM_CLASS_PROPERTY_INSTALLER), Is.EqualTo(CONFIGRET.CR_BUFFER_SMALL));
			using var mem = new SafeCoTaskMemHandle(sz * StringHelper.GetCharSize());
			Assert.That(CM_Get_Class_Property(cls, pkey, out _, mem, ref sz, CM_CLASS_PROPERTY.CM_CLASS_PROPERTY_INSTALLER), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			TestContext.WriteLine($"{cls}: Type={dpType}, Size={sz}");
			mem.ToStringEnum().WriteValues();
		}

		[Test]
		public void CM_Get_Class_Property_KeysTest()
		{
			var keyLen = 0;
			Assert.That(CM_Get_Class_Property_Keys(devguid, null, ref keyLen, CM_CLASS_PROPERTY.CM_CLASS_PROPERTY_INSTALLER), Is.Not.EqualTo(CONFIGRET.CR_SUCCESS));
			var keys = new DEVPROPKEY[keyLen];
			Assert.That(CM_Get_Class_Property_Keys(devguid, keys, ref keyLen, CM_CLASS_PROPERTY.CM_CLASS_PROPERTY_INSTALLER), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			TestContext.Write(string.Join("\n", keys));
		}

		[Test]
		public void CM_Get_Class_Registry_PropertyTest()
		{
			var cls = devguid;
			var prop = CM_DRP.CM_DRP_CAPABILITIES;
			var sz = 0U;
			Assert.That(CM_Get_Class_Registry_Property(cls, prop, out var dpType, default, ref sz), Is.EqualTo(CONFIGRET.CR_BUFFER_SMALL));
			using var mem = new SafeCoTaskMemHandle(sz * StringHelper.GetCharSize());
			Assert.That(CM_Get_Class_Registry_Property(cls, prop, out _, mem, ref sz), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			TestContext.WriteLine($"{cls}: Type={dpType}, Size={sz}");
			TestContext.Write(mem.Dump);
		}

		[Test]
		public void CM_Get_Device_IDTest()
		{
			var di = RootId;
			Assert.That(CM_Get_Device_ID_Size(out var len, di), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			Assert.That(len, Is.Not.Zero);
			var sb = new StringBuilder((int)len+1);
			Assert.That(CM_Get_Device_ID(di, sb, len+1), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			Assert.That(sb.Length, Is.Not.Zero);
			TestContext.Write($"ID: {di} ({sb})");
		}

		[Test]
		public void CM_Get_Device_ID_ListTest()
		{
			Assert.That(CM_Get_Device_ID_List_Size(out var len), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			using var mem = new SafeCoTaskMemHandle(len * StringHelper.GetCharSize());
			Assert.That(CM_Get_Device_ID_List(null, mem, len), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			TestContext.Write(string.Join("\n", mem.ToStringEnum()));
		}

		[Test]
		public void CM_Get_Device_Interface_AliasTest()
		{
			//Assert.That(CM_Get_Device_Interface_Alias(), Is.EqualTo(CONFIGRET.CR_SUCCESS));
		}

		public void ClassesWithInterfacesTest()
		{
			foreach (var fi in typeof(SetupAPI).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).
				Where(fi => fi.FieldType == typeof(Guid) && fi.Name.StartsWith("GUID_DEVINTERFACE_")))
			{
				var ret = CM_Get_Device_Interface_List_Size(out var len, (Guid)fi.GetValue(null), default, CM_GET_DEVICE_INTERFACE_LIST.CM_GET_DEVICE_INTERFACE_LIST_PRESENT);
				if (ret == CONFIGRET.CR_SUCCESS && len > 2)
					TestContext.WriteLine($"{fi.Name}={len}");
			}
		}

		[Test]
		public void CM_Get_Device_Interface_PropertiesTest()
		{
			Assert.That(() =>
			{
				foreach (var devInt in CM_Get_Device_Interface_List(GUID_DEVINTERFACE_VOLUME, CM_GET_DEVICE_INTERFACE_LIST.CM_GET_DEVICE_INTERFACE_LIST_PRESENT))
				{
					TestContext.WriteLine(devInt);

					uint size = 0;
					var ret = CM_Get_Device_Interface_Property_Keys(devInt, default, ref size);
					if (ret == CONFIGRET.CR_NO_SUCH_VALUE) continue;
					Assert.That(ret, Is.EqualTo(CONFIGRET.CR_BUFFER_SMALL));
					Assert.That(size, Is.GreaterThan(0));
					var keys = new DEVPROPKEY[size];
					Assert.That(CM_Get_Device_Interface_Property_Keys(devInt, keys, ref size), Is.EqualTo(CONFIGRET.CR_SUCCESS));

					foreach (var key in keys)
					{
						TestContext.Write($"   {key}: ");
						size = 0;
						ret = CM_Get_Device_Interface_Property(devInt, key, out DEVPROPTYPE pType, default, ref size);
						if (ret == CONFIGRET.CR_NO_SUCH_VALUE) continue;
						Assert.That(ret, Is.EqualTo(CONFIGRET.CR_BUFFER_SMALL));
						Assert.That(size, Is.GreaterThan(0));
						using var mem = new SafeCoTaskMemHandle((int)size);
						Assert.That(CM_Get_Device_Interface_Property(devInt, key, out _, mem, ref size), Is.EqualTo(CONFIGRET.CR_SUCCESS));
						try
						{
							var o = pType.GetObject(mem);
							TestContext.WriteLine(o is null ? "(null)" : (o.GetType().IsArray ? string.Join(", ", ((Array)o).Cast<object>()) : (o is string s ? $"\"{s}\"" : o)));
						} catch { TestContext.WriteLine($"{pType} CONVERSION FAILED ({mem.Size})"); }
					}
				}
			}, Throws.Nothing);
		}

		[Test]
		public void CM_Get_DevNode_PropertiesTest()
		{
			Assert.That(() =>
			{
				foreach (var devId in CM_Get_Device_ID_List())
				{
					if (CM_Locate_DevNode(out var devInst, devId) != CONFIGRET.CR_SUCCESS)
						continue;
					TestContext.WriteLine($"{devId} ({devInst})");

					uint size = 0;
					var ret = CM_Get_DevNode_Property_Keys(devInst, default, ref size);
					if (ret == CONFIGRET.CR_NO_SUCH_VALUE) continue;
					Assert.That(ret, Is.EqualTo(CONFIGRET.CR_BUFFER_SMALL));
					Assert.That(size, Is.GreaterThan(0));
					var keys = new DEVPROPKEY[size];
					Assert.That(CM_Get_DevNode_Property_Keys(devInst, keys, ref size), Is.EqualTo(CONFIGRET.CR_SUCCESS));

					foreach (var key in keys)
					{
						TestContext.Write($"   {key}: ");
						size = 0;
						ret = CM_Get_DevNode_Property(devInst, key, out DEVPROPTYPE pType, default, ref size);
						if (ret == CONFIGRET.CR_NO_SUCH_VALUE) continue;
						Assert.That(ret, Is.EqualTo(CONFIGRET.CR_BUFFER_SMALL));
						Assert.That(size, Is.GreaterThan(0));
						using var mem = new SafeCoTaskMemHandle((int)size);
						Assert.That(CM_Get_DevNode_Property(devInst, key, out _, mem, ref size), Is.EqualTo(CONFIGRET.CR_SUCCESS));
						try
						{
							var o = pType.GetObject(mem);
							TestContext.WriteLine(o is null ? "(null)" : (o.GetType().IsArray ? string.Join(", ", ((Array)o).Cast<object>()) : (o is string s ? $"\"{s}\"" : o)));
						}
						catch { TestContext.WriteLine($"{pType} CONVERSION FAILED ({mem.Size})"); }
					}
				}
			}, Throws.Nothing);
		}

		[Test]
		public void CM_Get_DevNode_Registry_PropertyTest()
		{
			foreach (CM_DRP p in Enum.GetValues(typeof(CM_DRP)))
			{
				uint len = 0;
				CONFIGRET ret = CM_Get_DevNode_Registry_Property(RootId, p, out REG_VALUE_TYPE vType, default, ref len);
				if (ret == CONFIGRET.CR_BUFFER_SMALL)
				{
					using var mem = new SafeCoTaskMemHandle(len);
					Assert.That(CM_Get_DevNode_Registry_Property(RootId, p, out vType, mem, ref len), Is.EqualTo(CONFIGRET.CR_SUCCESS));
					TestContext.WriteLine($"{p} : {vType} : {vType.GetValue(mem, mem.Size)}");
				}
			}
		}

		[Test]
		public void CM_Get_DevNode_StatusTest()
		{
			Assert.That(CM_Get_DevNode_Status(out DN stat, out CM_PROB prob, RootId), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			TestContext.Write($"{stat} : {prob}");
		}

		[Test]
		public void CM_Locate_DevNodeTest()
		{
			Assert.That(CM_Locate_DevNode(out var di, null, CM_LOCATE_DEVNODE.CM_LOCATE_DEVNODE_NORMAL), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			Assert.That(di, Is.Not.Zero);
		}

		[Test]
		public void CM_Reenumerate_DevNodeTest() => Assert.That(CM_Reenumerate_DevNode(RootId, CM_REENUMERATE.CM_REENUMERATE_SYNCHRONOUS), Is.EqualTo(CONFIGRET.CR_SUCCESS));

		[Test]
		public void RegisterAllInterfacesTest()
		{
			CM_NOTIFY_CALLBACK callback = Notification;
			CM_NOTIFY_FILTER allDev = CM_NOTIFY_FILTER.AllDevices;
			Assert.That(CM_Register_Notification(allDev, default, callback, out SafeHCMNOTIFICATION context), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			context.Dispose();
			GC.KeepAlive(callback);
		}

		private static IEnumerable<uint> CM_GetChildren(uint dnDevInst)
		{
			CONFIGRET ret = CM_Get_Child(out var di, dnDevInst);
			if (ret == CONFIGRET.CR_NO_SUCH_DEVNODE)
				yield break;
			ret.ThrowIfFailed();
			yield return di;
			while ((ret = CM_Get_Sibling(out di, di)) == CONFIGRET.CR_SUCCESS)
				yield return di;
			if (ret != CONFIGRET.CR_NO_SUCH_DEVNODE)
				throw ret.GetException();
		}

		private static uint GetFirstLeaf(uint dnDevInst)
		{
			CONFIGRET ret;
			var di = dnDevInst;
			while ((ret = CM_Get_Child(out di, di)) == CONFIGRET.CR_SUCCESS) ;
			return ret == CONFIGRET.CR_NO_SUCH_DEVNODE ? di : throw ret.GetException();
		}

		private Win32Error Notification(HCMNOTIFICATION notify, IntPtr context, CM_NOTIFY_ACTION action, in CM_NOTIFY_EVENT_DATA eventData, uint eventDataSize)
		{
			switch (eventData.FilterType)
			{
				case CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE:
					if (action == CM_NOTIFY_ACTION.CM_NOTIFY_ACTION_DEVICECUSTOMEVENT)
						Debug.WriteLine($"Custom event {eventData.u.DeviceHandle.EventGuid}.");
					break;

				case CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE:
					unsafe
					{
						fixed (char* p = eventData.u.DeviceInstance.InstanceId)
						{
							var instanceId = new string(p);
							Debug.WriteLine($"Notification for {instanceId}: {action}");
						}
					}
					break;

				case CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE:
					unsafe
					{
						fixed (char* p = eventData.u.DeviceInterface.SymbolicLink)
						{
							var symbolicLink = new string(p);
							Debug.WriteLine($"Notification for {eventData.u.DeviceInterface.ClassGuid} linked {symbolicLink}: {action}");
						}
					}
					break;
			}

			return Win32Error.ERROR_SUCCESS;
		}
	}
}