global using System;
global using System.Runtime.InteropServices;
global using Vanara.Extensions;
global using Vanara.InteropServices;
global using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
global using FWP_AF = Vanara.PInvoke.FwpUClnt.FWP_NE_FAMILY;
global using static Vanara.PInvoke.AdvApi32;
global using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke;

/// <summary>Items from the FwpUClnt.dll.</summary>
public static partial class FwpUClnt
{
	private const string Lib_Fwpuclnt = "fwpuclnt.dll";

}