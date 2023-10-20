using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
		private static readonly Lazy<uint> node = new(() => LocateNode(@"SWD\PRINTENUM\WSD-F442E38C-F139-42D3-BCCC-A3653929E4B7")); //@"USB\ROOT_HUB30\4&3490C39&0&0"));
		private static readonly Lazy<uint> root = new(() => LocateNode());

		private ElevPriv priv;

		public static uint LeafId => leaf.Value;
		public static uint NodeId => node.Value;
		public static uint RootId => root.Value;

		[OneTimeSetUp]
		public void _Setup() => priv = new ElevPriv("SeLoadDriverPrivilege");

		[OneTimeTearDown]
		public void _TearDown() => priv?.Dispose();

		public void ClassesWithInterfacesTest()
		{
			foreach (System.Reflection.FieldInfo fi in typeof(SetupAPI).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).
				Where(fi => fi.FieldType == typeof(Guid) && fi.Name.StartsWith("GUID_DEVINTERFACE_")))
			{
				CONFIGRET ret = CM_Get_Device_Interface_List_Size(out var len, (Guid)fi.GetValue(null), default, CM_GET_DEVICE_INTERFACE_LIST.CM_GET_DEVICE_INTERFACE_LIST_PRESENT);
				if (ret == CONFIGRET.CR_SUCCESS && len > 2)
					TestContext.WriteLine($"{fi.Name}={len}");
			}
		}

		[Test]
		public void CM_Add_Empty_Log_ConfTest()
		{
			Assert.That(CM_Add_Empty_Log_Conf(out SafeLOG_CONF hConf, NodeId, PRIORITY.LCPRI_NORMAL, LOG_CONF_FLAG.BASIC_LOG_CONF), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			try
			{
				Assert.That(CM_Get_Log_Conf_Priority(hConf, out PRIORITY p), Is.EqualTo(CONFIGRET.CR_SUCCESS));
				Assert.That(PRIORITY.LCPRI_NORMAL, Is.EqualTo(p));
			}
			finally
			{
				Assert.That(CM_Free_Log_Conf(hConf), Is.EqualTo(CONFIGRET.CR_SUCCESS));
				Assert.That(() => hConf.Dispose(), Throws.Nothing);
			}
		}

		[Test]
		public void CM_Add_Res_DesTest()
		{
			Assert.That(CM_Add_Empty_Log_Conf(out SafeLOG_CONF BootLC1, NodeId, PRIORITY.LCPRI_BOOTCONFIG, LOG_CONF_FLAG.BOOT_LOG_CONF | LOG_CONF_FLAG.PRIORITY_EQUAL_FIRST), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			try
			{
				MEM_RESOURCE memRes = MakeResource();

				SafeRES_DES hRD = null;
				Assert.That(() => hRD = CM_Add_Res_Des(BootLC1, memRes), Throws.Nothing);
				try
				{
					var list = new (SafeRES_DES prdResDes, RESOURCEID pResourceID)[0];
					Assert.That(() => list = CM_Get_Res_Des_List(BootLC1).ToArray(), Throws.Nothing);
					Assert.That(list, Is.Not.Empty);

					Assert.That(list[0].pResourceID, Is.EqualTo(RESOURCEID.ResType_Mem));
					MEM_RESOURCE retMemRes = default;
					Assert.That(() => retMemRes = CM_Get_Res_Des_Data<MEM_RESOURCE>(list[0].prdResDes), Throws.Nothing);
					Assert.That(retMemRes.MEM_Data.Length, Is.EqualTo(memRes.MEM_Data.Length));

					memRes.MEM_Data[0].MR_Min = 0xDA00;
					memRes.MEM_Data[0].MR_Max = 0xDE00;
					Assert.That(() => hRD = CM_Modify_Res_Des(list[0].prdResDes, memRes), Throws.Nothing);
				}
				finally
				{
					CM_Free_Res_Des(IntPtr.Zero, hRD);
					hRD?.Dispose();
				}
			}
			finally
			{
				CM_Free_Log_Conf(BootLC1);
				BootLC1.Dispose();
			}
		}

		[Test]
		public void CM_Clear_Log_Conf_List()
		{
			var lc = new SafeLOG_CONF[0];
			Assert.That(() => lc = CM_Get_Log_Conf_List(NodeId, LOG_CONF_FLAG.BOOT_LOG_CONF).ToArray(), Throws.Nothing);
			foreach (SafeLOG_CONF l in lc)
				CM_Free_Log_Conf(l);
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
			Assert.That(CM_Disable_DevNode(NodeId), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			Assert.That(CM_Enable_DevNode(NodeId), Is.EqualTo(CONFIGRET.CR_SUCCESS));
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
		public void CM_Get_Class_Property_KeysTest()
		{
			var keyLen = 0;
			Assert.That(CM_Get_Class_Property_Keys(devguid, null, ref keyLen, CM_CLASS_PROPERTY.CM_CLASS_PROPERTY_INSTALLER), Is.Not.EqualTo(CONFIGRET.CR_SUCCESS));
			var keys = new DEVPROPKEY[keyLen];
			Assert.That(CM_Get_Class_Property_Keys(devguid, keys, ref keyLen, CM_CLASS_PROPERTY.CM_CLASS_PROPERTY_INSTALLER), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			TestContext.Write(string.Join("\n", keys));
		}

		[Test]
		public void CM_GetSet_Class_PropertyTest()
		{
			Guid cls = devguid;
			DEVPROPKEY pkey = DEVPKEY_DeviceClass_IconPath;

			// Get value
			var sz = 0U;
			Assert.That(CM_Get_Class_Property(cls, pkey, out DEVPROPTYPE dpType, default, ref sz, CM_CLASS_PROPERTY.CM_CLASS_PROPERTY_INSTALLER), Is.EqualTo(CONFIGRET.CR_BUFFER_SMALL));
			var strings = new string[0];
			using (var mem = new SafeCoTaskMemHandle(sz * StringHelper.GetCharSize()))
			{
				Assert.That(CM_Get_Class_Property(cls, pkey, out _, mem, ref sz, CM_CLASS_PROPERTY.CM_CLASS_PROPERTY_INSTALLER), Is.EqualTo(CONFIGRET.CR_SUCCESS));
				TestContext.WriteLine($"{cls}: Type={dpType}, Size={sz}");
				strings = mem.ToStringEnum().ToArray();
				strings.WriteValues();
			}

			// Set bogus value
			using (var mem = SafeCoTaskMemHandle.CreateFromStringList(new[] { "A", "B" }))
			{
				Assert.That(CM_Set_Class_Property(devguid, pkey, DEVPROPTYPE.DEVPROP_TYPE_STRING_LIST, mem, mem.Size), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			}

			// Reset correct value
			using (var mem = SafeCoTaskMemHandle.CreateFromStringList(strings))
			{
				Assert.That(CM_Set_Class_Property(devguid, pkey, DEVPROPTYPE.DEVPROP_TYPE_STRING_LIST, mem, mem.Size), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			}
		}

		[Test]
		public void CM_GetSet_Class_Registry_PropertyTest()
		{
			Guid cls = devguid;
			CM_CRP prop = CM_CRP.CM_CRP_CHARACTERISTICS;

			var sz = 0U;
			Assert.That(CM_Get_Class_Registry_Property(cls, prop, out _, default, ref sz), Is.EqualTo(CONFIGRET.CR_BUFFER_SMALL));
			uint val = 0;
			using (var mem = new SafeCoTaskMemHandle(sz * StringHelper.GetCharSize()))
			{
				Assert.That(CM_Get_Class_Registry_Property(cls, prop, out REG_VALUE_TYPE dpType, mem, ref sz), Is.EqualTo(CONFIGRET.CR_SUCCESS));
				TestContext.WriteLine($"{cls}: Type={dpType}, Size={sz}");
				TestContext.Write(val = (uint)dpType.GetValue(mem, mem.Size));
			}

			using (var mem = SafeCoTaskMemHandle.CreateFromStructure(val > 0 ? 0U : 256))
				Assert.That(CM_Set_Class_Registry_Property(cls, prop, mem, mem.Size), Is.EqualTo(CONFIGRET.CR_SUCCESS));

			using (var mem = SafeCoTaskMemHandle.CreateFromStructure(val))
				Assert.That(CM_Set_Class_Registry_Property(cls, prop, mem, mem.Size), Is.EqualTo(CONFIGRET.CR_SUCCESS));
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
		public void CM_Get_Device_IDTest()
		{
			var di = RootId;
			Assert.That(CM_Get_Device_ID_Size(out var len, di), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			Assert.That(len, Is.Not.Zero);
			var sb = new StringBuilder((int)len + 1);
			Assert.That(CM_Get_Device_ID(di, sb, len + 1), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			Assert.That(sb.Length, Is.Not.Zero);
			TestContext.Write($"ID: {di} ({sb})");
		}

		[Test]
		public void CM_Get_Device_Interface_AliasTest()
		{
			//Assert.That(CM_Get_Device_Interface_Alias(), Is.EqualTo(CONFIGRET.CR_SUCCESS));
		}

		[Test]
		public void CM_Get_Device_Interface_PropertiesTest() => Assert.That(() =>
		{
			foreach (var devInt in CM_Get_Device_Interface_List(GUID_DEVINTERFACE_NET, CM_GET_DEVICE_INTERFACE_LIST.CM_GET_DEVICE_INTERFACE_LIST_PRESENT))
			{
				TestContext.WriteLine(devInt);

				uint size = 0;
				CONFIGRET ret = CM_Get_Device_Interface_Property_Keys(devInt, default, ref size);
				if (ret == CONFIGRET.CR_NO_SUCH_VALUE) continue;
				Assert.That(ret, Is.EqualTo(CONFIGRET.CR_BUFFER_SMALL));
				Assert.That(size, Is.GreaterThan(0));
				var keys = new DEVPROPKEY[size];
				Assert.That(CM_Get_Device_Interface_Property_Keys(devInt, keys, ref size), Is.EqualTo(CONFIGRET.CR_SUCCESS));

				foreach (DEVPROPKEY key in keys)
				{
					TestContext.Write($"   {key} ({(key.TryGetReadOnly(out var ro) ? (ro ? "R" : "RW") : "?")}): ");
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
					}
					catch { TestContext.WriteLine($"{pType} CONVERSION FAILED ({mem.Size})"); }
				}
			}
		}, Throws.Nothing);

		[Test]
		public void CM_Set_Device_Interface_PropertyTest()
		{
			var devInt = CM_Get_Device_Interface_List(GUID_DEVINTERFACE_VOLUME, CM_GET_DEVICE_INTERFACE_LIST.CM_GET_DEVICE_INTERFACE_LIST_PRESENT).First();
			DEVPROPKEY pkey = DEVPKEY_DeviceInterface_FriendlyName;
			using var mem = new SafeCoTaskMemString(256, System.Runtime.InteropServices.CharSet.Auto);
			uint sz = mem.Size;
			Assert.That(CM_Get_Device_Interface_Property(devInt, pkey, out var dpt, mem, ref sz), Is.EqualTo(CONFIGRET.CR_SUCCESS).Or.EqualTo(CONFIGRET.CR_NO_SUCH_VALUE));
			var orig = mem.ToString();
			mem.Set("DUMMY_VALUE$$");
			Assert.That(CM_Set_Device_Interface_Property(devInt, pkey, DEVPROPTYPE.DEVPROP_TYPE_STRING, mem, (uint)((mem.Length + 1) * StringHelper.GetCharSize())), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			if (string.IsNullOrEmpty(orig))
				Assert.That(CM_Set_Device_Interface_Property(devInt, pkey, DEVPROPTYPE.DEVPROP_TYPE_STRING, IntPtr.Zero, 0), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			else
			{
				mem.Set(orig);
				Assert.That(CM_Set_Device_Interface_Property(devInt, pkey, DEVPROPTYPE.DEVPROP_TYPE_STRING, mem, (uint)((mem.Length + 1) * StringHelper.GetCharSize())), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			}
		}

		[Test]
		public void CM_Set_DevNode_PropertyTest()
		{
			var devInt = NodeId;
			var pkey = DEVPKEY_DeviceInterface_Enabled;
			unsafe
			{
				byte boolVal = 0;
				uint sz = 1;
				Assert.That(CM_Get_DevNode_Property(devInt, pkey, out var dpt, (IntPtr)(&boolVal), ref sz), Is.EqualTo(CONFIGRET.CR_SUCCESS));
				byte newBoolVal = boolVal == 0 ? (byte)1 : (byte)0;
				Assert.That(CM_Set_DevNode_Property(devInt, pkey, dpt, (IntPtr)(&newBoolVal), 1), Is.EqualTo(CONFIGRET.CR_SUCCESS));
				Assert.That(CM_Set_DevNode_Property(devInt, pkey, dpt, (IntPtr)(&boolVal), 1), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			}
		}

		[Test]
		public void CM_Get_DevNode_PropertiesTest() => Assert.That(() =>
		{
			foreach (var devId in CM_Get_Device_ID_List())
			{
				if (CM_Locate_DevNode(out var devInst, devId) != CONFIGRET.CR_SUCCESS)
					continue;
				TestContext.WriteLine($"{devId} ({devInst})");

				uint size = 0;
				CONFIGRET ret = CM_Get_DevNode_Property_Keys(devInst, default, ref size);
				if (ret == CONFIGRET.CR_NO_SUCH_VALUE) continue;
				Assert.That(ret, Is.EqualTo(CONFIGRET.CR_BUFFER_SMALL));
				Assert.That(size, Is.GreaterThan(0));
				var keys = new DEVPROPKEY[size];
				Assert.That(CM_Get_DevNode_Property_Keys(devInst, keys, ref size), Is.EqualTo(CONFIGRET.CR_SUCCESS));

				foreach (DEVPROPKEY key in keys)
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
		public void CM_Get_HW_Prof_FlagsTest()
		{
			Assert.That(CM_Get_HW_Prof_Flags(@"USB\ROOT_HUB30\4&3490C39&0&0", 0, out CSCONFIGFLAG cf), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			Assert.That(cf & (CSCONFIGFLAG.CSCONFIGFLAG_DISABLED | CSCONFIGFLAG.CSCONFIGFLAG_DO_NOT_CREATE | CSCONFIGFLAG.CSCONFIGFLAG_DO_NOT_START), Is.Not.Zero);
		}

		//[Test]
		//public void CM_Get_Log_Conf_ListTest()
		//{
		//	//Assert.That(CM_Add_Empty_Log_Conf(out SafeLOG_CONF hConf, NodeId, PRIORITY.LCPRI_NORMAL, LOG_CONF_FLAG.BASIC_LOG_CONF), Is.EqualTo(CONFIGRET.CR_SUCCESS));
		//	//using (hConf)
		//	{
		//		var lc = new SafeLOG_CONF[0];
		//		Assert.That(() => lc = CM_Get_Log_Conf_List(NodeId, LOG_CONF_FLAG.BOOT_LOG_CONF).ToArray(), Throws.Nothing);
		//		Assert.That(lc.Length, Is.GreaterThanOrEqualTo(1));
		//		Assert.That(() => { foreach (var l in lc) l.Dispose(); }, Throws.Nothing);
		//	}
		//}
		//[Test]
		//public void CM_Get_Log_Conf_PriorityTest()
		//{
		//	Assert.That(CM_Add_Empty_Log_Conf(out SafeLOG_CONF hConf, NodeId, PRIORITY.LCPRI_NORMAL, LOG_CONF_FLAG.BASIC_LOG_CONF), Is.EqualTo(CONFIGRET.CR_SUCCESS));
		//	using (hConf)
		//	{
		//		using var lc = CM_Get_Log_Conf_List(NodeId, LOG_CONF_FLAG.BASIC_LOG_CONF).First();
		//		Assert.That(CM_Get_Log_Conf_Priority(lc, out var p), Is.EqualTo(CONFIGRET.CR_SUCCESS));
		//		Assert.IsTrue(Enum.IsDefined(typeof(PRIORITY), p));
		//	}
		//}

		[Test]
		public void CM_Get_Resource_Conflict_DetailsTest()
		{
			SafeCONFLICT_LIST hcl = null;
			MEM_RESOURCE memRes = MakeResource();
			Assert.That(() => hcl = CM_Query_Resource_Conflict_List(NodeId, memRes), Throws.Nothing);
			try
			{
				Assert.That(CM_Get_Resource_Conflict_Count(hcl, out var count), Is.EqualTo(CONFIGRET.CR_SUCCESS));
				Assert.That(count, Is.GreaterThan(0));
				CONFLICT_DETAILS det = new(CM_CDMASK.CM_CDMASK_DESCRIPTION | CM_CDMASK.CM_CDMASK_DEVINST | CM_CDMASK.CM_CDMASK_FLAGS | CM_CDMASK.CM_CDMASK_RESDES);
				Assert.That(CM_Get_Resource_Conflict_Details(hcl, 0, ref det), ResultIs.Successful);
				Assert.That(det.CD_dnDevInst, Is.Not.Zero);
				Assert.That(det.CD_szDescription, Is.Not.Null);
				det.WriteValues();
			}
			finally
			{
				hcl?.Dispose();
			}
		}

		[Test]
		public void CM_Is_Dock_Station_PresentTest()
		{
			Assert.That(CM_Is_Dock_Station_Present(out var present), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			TestContext.Write($"Dock present={present}");
		}

		[Test]
		public void CM_Is_Version_AvailableTest() => Assert.That(CM_Is_Version_Available(0x0501), Is.True);

		[Test]
		public void CM_Locate_DevNodeTest()
		{
			Assert.That(CM_Locate_DevNode(out var di, null, CM_LOCATE_DEVNODE.CM_LOCATE_DEVNODE_NORMAL), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			Assert.That(di, Is.Not.Zero);
		}

		[Test]
		public void CM_Open_Class_KeyTest()
		{
			Assert.That(CM_Open_Class_Key(GUID_DEVCLASS_USB, null, AdvApi32.REGSAM.KEY_READ, REGDISPOSITION.RegDisposition_OpenExisting,
				out var hReg, CM_OPEN_CLASS_KEY.CM_OPEN_CLASS_KEY_INSTALLER), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			Assert.That(hReg, ResultIs.ValidHandle);
			hReg.Dispose();
		}

		[Test]
		public void CM_Open_Device_Interface_KeyTest()
		{
			var devInf = CM_Get_Device_Interface_List(GUID_DEVINTERFACE_USB_DEVICE, CM_GET_DEVICE_INTERFACE_LIST.CM_GET_DEVICE_INTERFACE_LIST_PRESENT).First();
			Assert.That(CM_Open_Device_Interface_Key(devInf, AdvApi32.REGSAM.KEY_READ, REGDISPOSITION.RegDisposition_OpenExisting,
				out var hReg), Is.EqualTo(CONFIGRET.CR_SUCCESS).Or.EqualTo(CONFIGRET.CR_NO_SUCH_REGISTRY_KEY));
			//Assert.That(hReg, ResultIs.ValidHandle);
			hReg?.Dispose();
		}

		[Test]
		public void CM_Open_DevNode_KeyTest()
		{
			Assert.That(CM_Open_DevNode_Key(NodeId, AdvApi32.REGSAM.KEY_READ, 0, REGDISPOSITION.RegDisposition_OpenExisting, out var hReg, CM_REGISTRY.CM_REGISTRY_USER), 
				Is.EqualTo(CONFIGRET.CR_SUCCESS).Or.EqualTo(CONFIGRET.CR_NO_SUCH_REGISTRY_KEY));
			hReg?.Dispose();
		}

		[Test]
		public void CM_Query_And_Remove_SubTreeTest()
		{
			//Assert.That(CM_Query_And_Remove_SubTree(LeafId, out var veto, null, 0, CM_REMOVE.), ResultIs.Successful);
		}

		[Test]
		public void CM_Reenumerate_DevNodeTest() => Assert.That(CM_Reenumerate_DevNode(RootId, CM_REENUMERATE.CM_REENUMERATE_SYNCHRONOUS), Is.EqualTo(CONFIGRET.CR_SUCCESS));

		[Test]
		public void CM_Request_Device_EjectTest()
		{
			var sb = new StringBuilder(260);
			Assert.That(CM_Request_Device_Eject(NodeId, out var veto, sb, (uint)sb.Capacity), Is.EqualTo(CONFIGRET.CR_SUCCESS));
		}

		[Test]
		public void CM_Request_Eject_PCTest()
		{
			Assert.That(CM_Request_Eject_PC(), Is.EqualTo(CONFIGRET.CR_SUCCESS));
		}

		[Test]
		public void RegisterAllInterfacesTest()
		{
			CM_NOTIFY_CALLBACK callback = Notification;
			GC.KeepAlive(callback);
			Assert.That(CM_Register_Notification(CM_NOTIFY_FILTER.AllDevices, default, callback, out SafeHCMNOTIFICATION context), Is.EqualTo(CONFIGRET.CR_SUCCESS));
			for (int i = 0; i < 200; i++)
				System.Threading.Thread.Sleep(100);
			context.Dispose();
		}

		[Test]
		public void StructSizeTest() => TestContext.Write(string.Join("\n", TestHelper.GetNestedStructSizes(typeof(CfgMgr32))));

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

		private static uint LocateNode(string devId = null)
		{
			CM_Locate_DevNode(out var di, devId, CM_LOCATE_DEVNODE.CM_LOCATE_DEVNODE_NORMAL).ThrowIfFailed();
			return di;
		}

		private static MEM_RESOURCE MakeResource() => new()
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

		private Win32Error Notification(HCMNOTIFICATION notify, IntPtr context, CM_NOTIFY_ACTION action, IntPtr ed, uint eventDataSize)
		{
			unsafe
			{
				CM_NOTIFY_EVENT_DATA* eventData = (CM_NOTIFY_EVENT_DATA*)ed;
				switch (eventData->FilterType)
				{
					case CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE:
						if (action == CM_NOTIFY_ACTION.CM_NOTIFY_ACTION_DEVICECUSTOMEVENT)
							Debug.WriteLine($"Custom event {eventData->u.DeviceHandle.EventGuid}.");
						break;

					case CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE:
						var instanceId = new string(eventData->u.DeviceInstance.InstanceId);
						Debug.WriteLine($"Notification for {instanceId}: {action}");
						break;

					case CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE:
						var symbolicLink = new string(eventData->u.DeviceInterface.SymbolicLink);
						Debug.WriteLine($"Notification for {eventData->u.DeviceInterface.ClassGuid} linked {symbolicLink}: {action}");
						break;
				}
			}
			return Win32Error.ERROR_SUCCESS;
		}
	}
}