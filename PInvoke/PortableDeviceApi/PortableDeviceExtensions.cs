using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PortableDeviceApi;

namespace Vanara.Extensions;

    /// <summary>Extension methods for classes in Vanara.PInvoke.PortableDeviceApi.</summary>
    public static class PortableDeviceExtensions
    {
        private const BindingFlags BindStPub = BindingFlags.Static | BindingFlags.Public;

        private static Dictionary<Type, Dictionary<PROPERTYKEY, PropertyInfo>> gReversePKLookup = new();

        /// <summary>Extracts command results from an <see cref="IPortableDeviceValues"/> for a documented <see cref="PROPERTYKEY"/>.</summary>
        /// <param name="results">The results from a call to <c>IPortableDevice.SendCommand</c>.</param>
        /// <param name="cmd">The command's PROPERTYKEY.</param>
        /// <param name="parentType">The type in which <paramref name="cmd"/> is defined, if not other than <see cref="Vanara.PInvoke.PortableDeviceApi"/>.</param>
        /// <returns>A dictionary containing the result values.</returns>
        /// <exception cref="System.InvalidOperationException">Supplied PROPERTYKEY is not a recognized WPD command.</exception>
        public static IReadOnlyDictionary<PROPERTYKEY, object> ExtractResults(this IPortableDeviceValues results, in PROPERTYKEY cmd, Type parentType = null)
        {
            if (!cmd.TryGetCommandInfo(out _, out _, out var rAttrs, parentType))
                throw new InvalidOperationException("Supplied PROPERTYKEY is not a recognized WPD command.");
            var ret = new Dictionary<PROPERTYKEY, object>();
            foreach (var a in rAttrs)
            {
                PROPVARIANT pv = new();
                try { pv = results.GetValue(a.Property); } catch { }
                ret.Add(a.Property, pv.Value);
            }
            return (IReadOnlyDictionary<PROPERTYKEY, object>)ret;
        }

        /// <summary>Sends a command to the device and retrieves the results synchronously.</summary>
        /// <param name="device">The portable device.</param>
        /// <param name="cmd">The command's PROPERTYKEY.</param>
        /// <param name="pkResult">The PROPERTYKEY of the result value to return.</param>
        /// <returns>The value returned in <paramref name="pkResult"/>.</returns>
        public static object SendCommand(this IPortableDevice device, in PROPERTYKEY cmd, in PROPERTYKEY pkResult) =>
            device.SendCommand(cmd).GetValue(pkResult).Value;

        /// <summary>Sends a command to the device and retrieves the results synchronously.</summary>
        /// <param name="device">The portable device.</param>
        /// <param name="cmd">The command's PROPERTYKEY.</param>
        /// <param name="addParams">
        /// An action that can optionally be called to manipulate the <see cref="IPortableDeviceValues"/> instance passed to <see
        /// cref="IPortableDevice.SendCommand(uint, IPortableDeviceValues)"/>.
        /// </param>
        /// <returns>The <see cref="IPortableDeviceValues"/> instance returned by <see cref="IPortableDevice.SendCommand(uint, IPortableDeviceValues)"/>.</returns>
        public static IPortableDeviceValues SendCommand(this IPortableDevice device, in PROPERTYKEY cmd, Action<IPortableDeviceValues> addParams = null)
        {
            IPortableDeviceValues cmdParams = new();
            cmdParams.SetCommandPKey(cmd);
            addParams?.Invoke(cmdParams);
            var cmdResults = device.SendCommand(0, cmdParams);
            cmdResults.GetErrorValue(WPD_PROPERTY_COMMON_HRESULT).ThrowIfFailed();
            return cmdResults;
        }

        /// <summary>Sends a command to the device and retrieves the results synchronously.</summary>
        /// <param name="device">The portable device.</param>
        /// <param name="cmd">The command's PROPERTYKEY.</param>
        /// <param name="addParams">
        /// A list of <see cref="PROPERTYKEY"/>/ <see cref="object"/> tuples representing the property keys and their related values to add
        /// to <see cref="IPortableDeviceValues"/>.
        /// </param>
        /// <returns>The <see cref="IPortableDeviceValues"/> instance returned by <see cref="IPortableDevice.SendCommand(uint, IPortableDeviceValues)"/>.</returns>
        public static IPortableDeviceValues SendCommand(this IPortableDevice device, in PROPERTYKEY cmd, params (PROPERTYKEY key, object value)[] addParams) =>
            SendCommand(device, cmd, v =>
            {
                if (addParams is not null)
                    foreach ((PROPERTYKEY key, object value) in addParams)
                        v.SetValue(key, new PROPVARIANT(value));
            });

        /// <summary>Adds a new enumeration value or overwrites an existing one.</summary>
        /// <typeparam name="T">The type of the enumeration value.</typeparam>
        /// <param name="vals">The <see cref="IPortableDeviceValues"/> instance.</param>
        /// <param name="key">A <c>PROPERTYKEY</c> that specifies the item to create or overwrite.</param>
        /// <param name="enumVal">The enum value.</param>
        /// <remarks>
        /// If an existing value has the same key that is specified by the key parameter, it overwrites the existing value without any
        /// warning. The existing key memory is released appropriately.
        /// </remarks>
        public static void SetEnumValue<T>(this IPortableDeviceValues vals, in PROPERTYKEY key, T enumVal) where T : Enum, IConvertible =>
            vals.SetValue(key, new PROPVARIANT(Convert.ChangeType(enumVal, Enum.GetUnderlyingType(typeof(T)))));

        /// <summary>Tries to get the command information associated with a provided Command <c>PROPERTYKEY</c>.</summary>
        /// <param name="key">The <see cref="PROPERTYKEY"/> of the WPD command.</param>
        /// <param name="cmd">The <see cref="WPDCommandAttribute"/> instance with detail about the command.</param>
        /// <param name="param">
        /// An array of <see cref="WPDCommandParamAttribute"/> instances representing valid parameters for <paramref name="key"/>.
        /// </param>
        /// <param name="result">
        /// An array of <see cref="WPDCommandResultAttribute"/> instances representing valid results for <paramref name="key"/>.
        /// </param>
        /// <param name="parentType">The type in which <paramref name="key"/> is defined, if not other than <see cref="Vanara.PInvoke.PortableDeviceApi"/>.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="key"/> is a valid command in <paramref name="parentType"/>; <see langword="false"/> otherwise.
        /// </returns>
        /// <remarks>
        /// The reflection based lookup is cached so that subsequent lookups are accelerated. As such, expect a slower response the first
        /// time this method is called with each unique <paramref name="parentType"/>.
        /// </remarks>
        public static bool TryGetCommandInfo(this PROPERTYKEY key, out WPDCommandAttribute cmd, out WPDCommandParamAttribute[] param, out WPDCommandResultAttribute[] result, Type parentType = null)
        {
            var pi = GetPI(key, parentType);
            parentType ??= typeof(Vanara.PInvoke.PortableDeviceApi);
            if (pi is not null)
            {
                cmd = pi.GetCustomAttribute<WPDCommandAttribute>();
                if (cmd is not null)
                {
                    param = pi.GetCustomAttributes<WPDCommandParamAttribute>()?.ToArray() ?? new WPDCommandParamAttribute[0];
                    result = pi.GetCustomAttributes<WPDCommandResultAttribute>()?.ToArray() ?? new WPDCommandResultAttribute[0];
                    return true;
                }
            }
            cmd = null;
            param = null;
            result = null;
            return false;
        }

        internal static PROPERTYKEY? GetKeyFromName(string keyName, Type parentType = null)
        {
            parentType ??= typeof(Vanara.PInvoke.PortableDeviceApi);
            var kv = GetDict(parentType).FirstOrDefault(kv => kv.Value.Name == keyName);
            return kv.Value is null ? null : kv.Key;
        }

        private static Dictionary<PROPERTYKEY, PropertyInfo> GetDict(Type type)
        {
            if (!gReversePKLookup.TryGetValue(type, out var dict))
            {
                dict = type.GetProperties(BindStPub).ToDictionary(m => (PROPERTYKEY)m.GetValue(null, null));
                gReversePKLookup.Add(type, dict);
            }
            return dict;
        }

        private static PropertyInfo GetPI(in PROPERTYKEY key, Type parentType = null)
        {
            parentType ??= typeof(Vanara.PInvoke.PortableDeviceApi);
            return GetDict(parentType).TryGetValue(key, out var pi) ? pi : null;
        }
    }