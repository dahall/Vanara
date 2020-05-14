using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.CoreAudio;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke.Tests
{
    /// <summary>Functions, structures and constants from Windows Core Audio Api.</summary>
    public static partial class CoreAudio
    {
        public enum DeviceShareMode
        {
            Shared,
            Exclusive
        }

        /// <summary>Undocumented COM-interface IPolicyConfig. Use for set default audio render endpoint.</summary>
        [ComImport, Guid("f8679f50-850a-41cf-9c72-430f290290c8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(PolicyConfig))]
        public interface IPolicyConfig
        {
            [PreserveSig]
            HRESULT GetMixFormat([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceName, [Out] out IntPtr ppFormat);

            [PreserveSig]
            HRESULT GetDeviceFormat([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceName, [MarshalAs(UnmanagedType.Bool)] bool bDefault, [Out] out IntPtr ppFormat);

            [PreserveSig]
            HRESULT ResetDeviceFormat([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceName);

            [PreserveSig]
            HRESULT SetDeviceFormat([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceName, [In] IntPtr pEndpointFormat, [In] IntPtr mixFormat);

            [PreserveSig]
            HRESULT GetProcessingPeriod([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceName, [MarshalAs(UnmanagedType.Bool)] bool bDefault, out long pmftDefaultPeriod, out long pmftMinimumPeriod);

            [PreserveSig]
            HRESULT SetProcessingPeriod([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceName, long pmftPeriod);

            [PreserveSig]
            HRESULT GetShareMode([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceName, [Out] out DeviceShareMode pMode);

            [PreserveSig]
            HRESULT SetShareMode([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceName, in DeviceShareMode mode);

            [PreserveSig]
            HRESULT GetPropertyValue([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceName, [MarshalAs(UnmanagedType.Bool)] bool bFxStore, in PROPERTYKEY key, [Out] PROPVARIANT pv);

            [PreserveSig]
            HRESULT SetPropertyValue([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceName, [MarshalAs(UnmanagedType.Bool)] bool bFxStore, in PROPERTYKEY key, [Out] PROPVARIANT pv);

            [PreserveSig]
            HRESULT SetDefaultEndpoint([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceName, [MarshalAs(UnmanagedType.U4)] ERole role);

            [PreserveSig]
            HRESULT SetEndpointVisibility([MarshalAs(UnmanagedType.LPWStr)] string pszDeviceName, [MarshalAs(UnmanagedType.Bool)] bool bVisible);
        }

        [ComImport, Guid("870af99c-171d-4f9e-af0d-e63df40c2bc9"), ClassInterface(ClassInterfaceType.None)]
        public class PolicyConfig { }
    }
}