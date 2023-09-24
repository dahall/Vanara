using NUnit.Framework;
using NUnit.Framework.Internal;
using static Vanara.PInvoke.EnhancedStorage;

namespace Vanara.PInvoke.Tests;

[TestFixture]
    public class EnhancedStorageTests
    {
        [Test]
        public void EnumStorage()
        {
            IEnumEnhancedStorageACT stores = new();
            foreach (var store in stores.GetACTs())
            {
                IEnhancedStorageACT2 store2 = (IEnhancedStorageACT2)store;
                IEnhancedStorageACT3 store3 = (IEnhancedStorageACT3)store;
                TestContext.WriteLine($"{store3.GetDeviceName()} = {store.GetAuthorizationState().ulState}");
                TestContext.WriteLine($"Rem: {store2.IsDeviceRemovable()}; Frz: {store3.IsQueueFrozen()}; Shl: {store3.GetShellExtSupport()}");
                foreach (var silo in store.GetSilos())
                {
                    // *** The commented lines consistenty fail on Win10 and Win11 Pro ***
                    //foreach (var action in silo.GetActions())
                    //    TestContext.WriteLine($"    {action.GetName()}; {action.GetDescription()}");
                    TestContext.WriteLine($"  {silo.GetDevicePath()}");
                    silo.GetInfo().WriteValues();
                    //var device = silo.GetPortableDevice();
                    //Assert.That(device.GetPnPDeviceID(), Is.EqualTo(silo.GetDevicePath()));
                }
                TestContext.WriteLine();
            }
        }

        [Test]
        public void Action()
        {
            IEnhancedStorageSiloAction a = new();
            TestContext.WriteLine(a.GetName());
            TestContext.WriteLine(a.GetDescription());
        }
    }