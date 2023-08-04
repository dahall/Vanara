using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using static Vanara.PInvoke.PortableDeviceApi;

namespace Vanara.PInvoke.Tests;

    [TestFixture]
    public class PortableDeviceApiTests
    {
        IPortableDevice device = null;
        IPortableDeviceManager manager;
        static readonly Ole32.PROPERTYKEY eventNameProp = new(Guid.NewGuid(), 1);

        [OneTimeSetUp]
        public void _Setup()
        {
            manager = new();
            var deviceId = manager.GetDevices().FirstOrDefault() ?? throw new ArgumentNullException("Device");
		device = new();
            device.Open(deviceId, GetClientInfo());
        }

        [OneTimeTearDown]
        public void _TearDown()
        {
            device?.Close();
            device = null;
            manager = null;
        }

        [Test]
        public void DeviceEventing()
        {
            string evtName = nameof(DeviceEventing);
            EventWaitHandle evt = new(false, EventResetMode.ManualReset, evtName);
            EventCallback callback = new();
            IPortableDeviceValues vals = new();
            vals.SetStringValue(eventNameProp, evtName);
            device.Advise(0, callback, vals, out var cookie);
            TestContext.WriteLine($"Fired = {evt.WaitOne(200)}");
            device.Unadvise(cookie);
        }

        class EventCallback : IPortableDeviceEventCallback
        {
            void IPortableDeviceEventCallback.OnEvent(IPortableDeviceValues pEventParameters)
            {
                var evtName = pEventParameters.GetStringValue(eventNameProp);
                if (EventWaitHandle.TryOpenExisting(evtName, out var evt))
                    evt.Set();
            }
        }

        [Test]
        public void EnumDevices()
        {
            try
            {
                var devices = manager.GetDevices();
                TestContext.WriteLine("{0} Windows Portable Device(s) found in the system", devices.Length);

                foreach (var device in devices)
                {
                    TestContext.WriteLine(device +
                        "\n\tManufacturer:  " + manager.GetDeviceManufacturer(device) +
                        "\n\tDescription:   " + manager.GetDeviceDescription(device) +
                        "\n\tFriendly Name: " + manager.GetDeviceFriendlyName(device));
                }
            }
            catch (COMException exception)
            {
                Console.WriteLine("COM exception: code {1}, {0}", exception.Message, exception.ErrorCode);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        [Test]
        public void EnumDeviceProps()
        {
            var content = device.Content();

            foreach (var s in RecursiveEnumerate(WPD_DEVICE_OBJECT_ID, content).Take(20))
                TestContext.WriteLine(s);

            static IEnumerable<string> RecursiveEnumerate(string objId, IPortableDeviceContent content)
            {
                var enumObjs = content.EnumObjects(0, objId);
                foreach (var sobj in enumObjs.Enumerate())
                {
                    yield return sobj;
                    foreach (var s in RecursiveEnumerate(sobj, content))
                        yield return s;
                }
            }
        }

        [Test]
        public void EnumDeviceFuncCats()
        {
            var caps = device.Capabilities();

            foreach (var catid in caps.GetFunctionalCategories().Enumerate().Where(pv => pv.VarType == VarEnum.VT_CLSID).Select(pv => pv.puuid.Value))
            {
                TestContext.WriteLine(GetPI(catid, "WPD_FUNCTIONAL_CATEGORY_")?.Name ?? catid.ToString());
                foreach (var type in caps.GetSupportedContentTypes(catid).Enumerate().Where(pv => pv.VarType == VarEnum.VT_CLSID).Select(pv => pv.puuid.Value))
                {
                    TestContext.WriteLine("  t: " + (GetPI(type, "WPD_CONTENT_TYPE_")?.Name ?? type.ToString()));
                    foreach (var fmt in caps.GetSupportedFormats(type).Enumerate().Where(pv => pv.VarType == VarEnum.VT_CLSID).Select(pv => pv.puuid.Value))
                        TestContext.WriteLine("    f: " + (GetPI(fmt, "WPD_OBJECT_FORMAT_")?.Name ?? type.ToString()));
                }
                foreach (var obj in caps.GetFunctionalObjects(catid).Enumerate().Where(pv => pv.VarType == VarEnum.VT_LPWSTR).Select(pv => pv.pwszVal))
                    TestContext.WriteLine("  o: " + obj);
            }
        }

        [Test]
        public void EnumDeviceCmds()
        {
            var caps = device.Capabilities();

            foreach (var cmd in caps.GetSupportedCommands().Enumerate())
            {
                TestContext.WriteLine(GetPI(cmd, "WPD_COMMAND_")?.Name ?? cmd.ToString());
                Write(caps.GetCommandOptions(cmd), "WPD_OPTION_", "  ");
            }
        }

        [Test]
        public void EnumDeviceResources()
        {
            var content = device.Content();
            var res = content.Transfer();
            foreach (var cmd in res.GetSupportedResources(WPD_DEVICE_OBJECT_ID).Enumerate())
            {
                Write(res.GetResourceAttributes(WPD_DEVICE_OBJECT_ID, cmd), "WPD_");
            }
        }

        private void Write(IPortableDeviceValues vals, string lookupFilter, string prefix = "")
        {
            foreach (var val in vals.Enumerate())
            {
                var name = GetPI(val.Item1, lookupFilter)?.Name ?? val.Item1.ToString();
                TestContext.WriteLine($"{prefix}{name} = {val.Item2.Value}");
            }
        }

        [Test]
        public void CallDeviceCmd()
        {
            var pkey = WPD_COMMAND_OBJECT_PROPERTIES_GET_SUPPORTED;
            Assert.IsTrue(device.Capabilities().GetSupportedCommands().Enumerate().Contains(pkey));
            var objId = device.Content().EnumObjects(0, WPD_DEVICE_OBJECT_ID).Enumerate().First();
            IPortableDeviceValues vals = new();
            vals.SetCommandPKey(pkey);
            vals.SetStringValue(WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID, objId);
            IPortableDeviceKeyCollection result = new();
            vals.SetIPortableDeviceKeyCollectionValue(WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS, result);
            device.SendCommand(0, vals);
            foreach (var key in result.Enumerate())
                TestContext.WriteLine(key);
        }

        [Test]
        public void EnumDeviceEvents()
        {
            var caps = device.Capabilities();

            foreach (var evt in caps.GetSupportedEvents().Enumerate().Where(pv => pv.VarType == VarEnum.VT_CLSID).Select(pv => pv.puuid.Value))
            {
                TestContext.WriteLine(GetPI(evt, "WPD_EVENT_")?.Name ?? evt.ToString());
                foreach (var opt in caps.GetEventOptions(evt).Enumerate())
                    TestContext.WriteLine($"  {(GetPI(opt.Item1, "WPD_EVENT_OPTION_")?.Name ?? opt.Item1.ToString())} = {opt.Item2.Value}");
            }
        }

        private static PropertyInfo GetPI<T>(T t, string prefix) =>
            typeof(PortableDeviceApi).GetProperties(BindingFlags.Public | BindingFlags.Static).
            FirstOrDefault(pi => pi.Name.StartsWith(prefix) && pi.PropertyType.Equals(typeof(T)) && t.Equals(pi.GetValue(null)));

        private IPortableDeviceValues GetClientInfo(bool readOnly = true)
        {
            // Client information is optional.  The client can choose to identify itself, or
            // to remain unknown to the driver.  It is beneficial to identify yourself because
            // drivers may be able to optimize their behavior for known clients. (e.g. An
            // IHV may want their bundled driver to perform differently when connected to their
            // bundled software.)

            // CoCreate an IPortableDeviceValues interface to hold the client information.
            IPortableDeviceValues clientInformation = new();

            // Attempt to set all bits of client information
            clientInformation.SetStringValue(WPD_CLIENT_NAME, "Test");
            clientInformation.SetUnsignedIntegerValue(WPD_CLIENT_MAJOR_VERSION, 1);
            clientInformation.SetUnsignedIntegerValue(WPD_CLIENT_MINOR_VERSION, 0);
            clientInformation.SetUnsignedIntegerValue(WPD_CLIENT_REVISION, 2);
            if (readOnly)
                clientInformation.SetUnsignedIntegerValue(WPD_CLIENT_DESIRED_ACCESS, ACCESS_MASK.GENERIC_READ);

            //  Some device drivers need to impersonate the caller in order to function correctly.  Since our application does not
            //  need to restrict its identity, specify SECURITY_IMPERSONATION so that we work with all devices.
            clientInformation.SetUnsignedIntegerValue(WPD_CLIENT_SECURITY_QUALITY_OF_SERVICE, (uint)FileFlagsAndAttributes.SECURITY_IMPERSONATION);

            return clientInformation;
        }
    }