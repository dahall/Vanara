![Vanara](/docs/icons/VanaraHeading.png)

[![Version](https://img.shields.io/github/release/dahall/Vanara.svg?style=flat-square)](https://github.com/dahall/Vanara/releases) [![Downloads](https://img.shields.io/nuget/dt/Vanara.Core.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.Core/) [![Build status](https://ci.appveyor.com/api/projects/status/p6jj1j3sbt95opdr?svg=true)](https://ci.appveyor.com/project/dahall/vanara)

This project contains various .NET assemblies that contain P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries. For example, Shlwapi.dll has all the exported functions from shlwapi.lib; Kernel32.dll has all for both kernel32.lib and kernelbase.lib.

All assemblies are available via NuGet and provide builds against .NET 2.0, 3.5, 4.0, 4.5, Core 3.0 and **Core 3.1** (new in v3.1.7) and support [SourceLink](https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/sourcelink). In all cases where a dependency doesn't disallow it, .NET Standard 2.0, .NET Core 2.0, and 2.1 builds are also included for use with UWP and other .NET Core and Standard projects.

## Use
1. Look for the function you need in Microsoft documentation. Note which library or DLL the function is in.
2. Confirm the Vanara library exists and has your function by looking at the Supported Libraries table below. Clicking on the Assembly link will take you to a drill down of that assembly's coverage. Find your function and if there is a matching implementation it will appear to the right.
3. Add the assembly to your project via NuGet.
4. To use the function, you can:
   1. Call it directly `var bret = Vanara.PInvoke.Kernel32.GetComputerName(sb, ref sbSz);`
   2. Under C# 6.0 and later, use a static using directive and call it:
   ```
   using static Vanara.PInvoke.Kernel32;
   
   var bret = GetComputerName(sb, ref sbSz);
   ```
5. In some cases there is a corresponding helper/wrapper class in one of the [Supporting Assemblies](#Supporting-Assemblies), especially for Security, System Services, Forms and Shell. Go to their library page (click on link in section) and look through the classes included in each library.

## Design Concepts

I have tried to follow the concepts below in laying out the libraries.
* All functions that are imported from a single DLL should be placed into a single assembly that is named after the DLL.
  * (e.g. The assembly `Vanara.PInvoke.Gdi32.dll` hosts all functions and supporting enumerations, constants and structures that are exported from `gdi32.dll` in the system directory.)
* Any structure or macro or enumeration (no function) that is used by many libraries is put into either `Vanara.Core` or `Vanara.PInvoke.Shared`.
  * (e.g. The macro `HIWORD` and the structure `SIZE` are both in `Vanara.PInvoke.Shared` and classes to simplify interop calls and native memory management are in `Vanara.Core`.)
* Inside a project, all constructs are contained in a file named after the header file (*.h) in which they are defined in the Windows API.
  * (e.g. In the `Vanara.PInvoke.Kernel32` project directory, you'll find a FileApi.cs, a WinBase.cs and a WinNT.cs file representing fileapi.h, winbase.h and winnt.h respectively.)
* Where the direct interpretation of a structure or function leads to memory leaks or misuse, I have tried to simplify its use.
* Where a structure is always passed by reference and where that structure needs to clean up memory allocations, I have changed the structure to a class implementing `IDisposable`.
* Wherever possible, all handles have been turned into `SafeHandle` derivatives named after the Windows API handle. If those handles require a call to a function to release/close/destroy, a derived `SafeHANDLE` exists that performs that function on disposal.
  * e.g. `HTOKEN` is defined. `SafeHTOKEN` builds upon that handle with an automated release calling `CloseHandle`.
* Wherever possible, all functions that allocate memory that is to be freed by the caller use a safe memory handle.
* All PInvoke calls are in assemblies prefixed by `Vanara.PInvoke`.
* If a structure is to passed into a function as a constant, that structure is marshaled using the `in` statement which will pass the structure by reference without requiring the `ref` keyword.
  * Windows API: `BOOL MapDialogRect(HWND hDlg, LPRECT lpRect)`
  * Vanara: `bool MapDialogRect(HWND hDlg, in RECT lpRect);`
* If there are classes or extensions that make use of the PInvoke calls, they are in wrapper assemblies prefixed by `Vanara` and then followed by a logical name for the functionality. Today, those are Core, Security, SystemServices, Windows.Forms and Windows.Shell.

## Supported Libraries

Library/DLL | Assembly | Coverage | NuGet&nbsp;Link
--- | --- | --- | ---
*Core* (see Supporting Assemblies) | [Vanara.Core](https://github.com/dahall/Vanara/blob/master/Core/AssemblyReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.Core)](https://www.nuget.org/packages/Vanara.Core)
*Shared* (see Supporting Assemblies) | [Vanara.PInvoke.Shared](https://github.com/dahall/Vanara/blob/master/PInvoke/Shared/AssemblyReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Shared)](https://www.nuget.org/packages/Vanara.PInvoke.Shared)
AclUI.dll | [Vanara.PInvoke.AclUI](https://github.com/dahall/Vanara/blob/master/PInvoke/AclUI/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.AclUI)](https://www.nuget.org/packages/Vanara.PInvoke.AclUI)
qmgr.dll (BITS) | [Vanara.PInvoke.BITS](https://github.com/dahall/Vanara/blob/master/PInvoke/BITS/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.BITS)](https://www.nuget.org/packages/Vanara.PInvoke.BITS)
Cabinet.dll | [Vanara.PInvoke.Cabinet](https://github.com/dahall/Vanara/blob/master/PInvoke/Cabinet/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Cabinet)](https://www.nuget.org/packages/Vanara.PInvoke.Cabinet)
ComCtl32.dll | [Vanara.PInvoke.ComCtl32](https://github.com/dahall/Vanara/blob/master/PInvoke/ComCtl32/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.ComCtl32)](https://www.nuget.org/packages/Vanara.PInvoke.ComCtl32)
CredUI.dll | [Vanara.PInvoke.CredUI](https://github.com/dahall/Vanara/blob/master/PInvoke/CredUI/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.CredUI)](https://www.nuget.org/packages/Vanara.PInvoke.CredUI)
BCrypt.dll, Crypt32.dll and NCrypt.dll | [Vanara.PInvoke.Cryptography](https://github.com/dahall/Vanara/blob/master/PInvoke/Cryptography/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Cryptography)](https://www.nuget.org/packages/Vanara.PInvoke.Cryptography)
DwmApi.dll | [Vanara.PInvoke.DwmApi](https://github.com/dahall/Vanara/blob/master/PInvoke/DwmApi/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.DwmApi)](https://www.nuget.org/packages/Vanara.PInvoke.DwmApi)
Gdi32.dll | [Vanara.PInvoke.Gdi32](https://github.com/dahall/Vanara/blob/master/PInvoke/Gdi32/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/98%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Gdi32)](https://www.nuget.org/packages/Vanara.PInvoke.Gdi32)
IpHlpApi.dll | [Vanara.PInvoke.IpHlpApi](https://github.com/dahall/Vanara/blob/master/PInvoke/IpHlpApi/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.IpHlpApi)](https://www.nuget.org/packages/Vanara.PInvoke.IpHlpApi)
Kernel32.dll, KernelBase.dll, Normaliz.dll and Vertdll.dll | [Vanara.PInvoke.Kernel32](https://github.com/dahall/Vanara/blob/master/PInvoke/Kernel32/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Kernel32)](https://www.nuget.org/packages/Vanara.PInvoke.Kernel32)
KtmW32.dll | [Vanara.PInvoke.KtmW32](https://github.com/dahall/Vanara/blob/master/PInvoke/KtmW32/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.KtmW32)](https://www.nuget.org/packages/Vanara.PInvoke.KtmW32)
Mpr.dll | [Vanara.PInvoke.Mpr](https://github.com/dahall/Vanara/blob/master/PInvoke/Mpr/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Mpr)](https://www.nuget.org/packages/Vanara.PInvoke.Mpr)
NetApi32.dll | [Vanara.PInvoke.NetApi32](https://github.com/dahall/Vanara/blob/master/PInvoke/NetApi32/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.NetApi32)](https://www.nuget.org/packages/Vanara.PInvoke.NetApi32)
NetListMgr.dll | [Vanara.PInvoke.NetListMgr](https://github.com/dahall/Vanara/blob/master/PInvoke/NetListMgr/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.NetListMgr)](https://www.nuget.org/packages/Vanara.PInvoke.NetListMgr)
NTDll.dll | [Vanara.PInvoke.NTDll](https://github.com/dahall/Vanara/blob/master/PInvoke/NTDll/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/4%25-red.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.NTDll)](https://www.nuget.org/packages/Vanara.PInvoke.NTDll)
NTDSApi.dll | [Vanara.PInvoke.NTDSApi](https://github.com/dahall/Vanara/blob/master/PInvoke/NTDSApi/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.NTDSApi)](https://www.nuget.org/packages/Vanara.PInvoke.NTDSApi)
Ole32.dll, OleAut32 and PropSys.dll | [Vanara.PInvoke.Ole](https://github.com/dahall/Vanara/blob/master/PInvoke/Ole/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/82%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Ole)](https://www.nuget.org/packages/Vanara.PInvoke.Ole)
Oleacc.dll | [Vanara.PInvoke.Accessibility](https://github.com/dahall/Vanara/blob/master/PInvoke/Accessibility/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Accessibility)](https://www.nuget.org/packages/Vanara.PInvoke.Accessibility)
OpcServices.dll | [Vanara.PInvoke.Opc](https://github.com/dahall/Vanara/blob/master/PInvoke/Opc/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Opc)](https://www.nuget.org/packages/Vanara.PInvoke.Opc)
Pdh.dll | [Vanara.PInvoke.Pdh](https://github.com/dahall/Vanara/blob/master/PInvoke/Pdh/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Pdh)](https://www.nuget.org/packages/Vanara.PInvoke.Pdh)
PowrProf.dll | [Vanara.PInvoke.PowrProf](https://github.com/dahall/Vanara/blob/master/PInvoke/PowrProf/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.PowrProf)](https://www.nuget.org/packages/Vanara.PInvoke.PowrProf)
WinSpool.drv, PrntvPt.dll | [Vanara.PInvoke.Printing](https://github.com/dahall/Vanara/blob/master/PInvoke/Printing/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Printing)](https://www.nuget.org/packages/Vanara.PInvoke.Printing)
SearchApi | [Vanara.PInvoke.SearchApi](https://github.com/dahall/Vanara/blob/master/PInvoke/SearchApi/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.SearchApi)](https://www.nuget.org/packages/Vanara.PInvoke.SearchApi)
AdvApi32.dll, Authz.dll, Schannel.dll, Secur32.dll and SspiCli.dll | [Vanara.PInvoke.Security](https://github.com/dahall/Vanara/blob/master/PInvoke/Security/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Security)](https://www.nuget.org/packages/Vanara.PInvoke.Security)
Shell32.dll, Url.dll | [Vanara.PInvoke.Shell32](https://github.com/dahall/Vanara/blob/master/PInvoke/Shell32/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Shell32)](https://www.nuget.org/packages/Vanara.PInvoke.Shell32)
ShlwApi.dll | [Vanara.PInvoke.ShlwApi](https://github.com/dahall/Vanara/blob/master/PInvoke/ShlwApi/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.ShlwApi)](https://www.nuget.org/packages/Vanara.PInvoke.ShlwApi)
TaskSchd.dll and MSTask.dll | [Vanara.PInvoke.TaskSchd](https://github.com/dahall/Vanara/blob/master/PInvoke/TaskSchd/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.TaskSchd)](https://www.nuget.org/packages/Vanara.PInvoke.TaskSchd)
UrlMon.dll | [Vanara.PInvoke.UrlMon](https://github.com/dahall/Vanara/blob/master/PInvoke/UrlMon/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.UrlMon)](https://www.nuget.org/packages/Vanara.PInvoke.UrlMon)
User32.dll | [Vanara.PInvoke.User32](https://github.com/dahall/Vanara/blob/master/PInvoke/User32/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.User32)](https://www.nuget.org/packages/Vanara.PInvoke.User32)
UserEnv.dll | [Vanara.PInvoke.UserEnv](https://github.com/dahall/Vanara/blob/master/PInvoke/UserEnv/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.UserEnv)](https://www.nuget.org/packages/Vanara.PInvoke.UserEnv)
UxTheme.dll | [Vanara.PInvoke.UxTheme](https://github.com/dahall/Vanara/blob/master/PInvoke/UxTheme/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.UxTheme)](https://www.nuget.org/packages/Vanara.PInvoke.UxTheme)
VirtDisk.dll | [Vanara.PInvoke.VirtDisk](https://github.com/dahall/Vanara/blob/master/PInvoke/VirtDisk/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.VirtDisk)](https://www.nuget.org/packages/Vanara.PInvoke.VirtDisk)
WcmApi.dll | [Vanara.PInvoke.WcmApi](https://github.com/dahall/Vanara/blob/master/PInvoke/WcmApi/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.WcmApi)](https://www.nuget.org/packages/Vanara.PInvoke.WcmApi)
Wer.dll | [Vanara.PInvoke.Wer](https://github.com/dahall/Vanara/blob/master/PInvoke/Wer/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Wer)](https://www.nuget.org/packages/Vanara.PInvoke.Wer)
WinINet.dll | [Vanara.PInvoke.WinINet](https://github.com/dahall/Vanara/blob/master/PInvoke/WinINet/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.WinINet)](https://www.nuget.org/packages/Vanara.PInvoke.WinINet)
WinTrust.dll | [Vanara.PInvoke.WinTrust](https://github.com/dahall/Vanara/blob/master/PInvoke/WinTrust/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.WinTrust)](https://www.nuget.org/packages/Vanara.PInvoke.WinTrust)
WlanApi.dll | [Vanara.PInvoke.WlanApi](https://github.com/dahall/Vanara/blob/master/PInvoke/WlanApi/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.WlanApi)](https://www.nuget.org/packages/Vanara.PInvoke.WlanApi)
Ws2_32.dll | [Vanara.PInvoke.Ws2_32](https://github.com/dahall/Vanara/blob/master/PInvoke/Ws2_32/CorrelationReport.md) | ![Coverage](https://img.shields.io/badge/100%25-green.svg) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Ws2_32)](https://www.nuget.org/packages/Vanara.PInvoke.Ws2_32)

## Supporting Assemblies

Assembly | &nbsp;&nbsp;&nbsp;NuGet&nbsp;Link&nbsp;&nbsp;&nbsp; | Description
--- | --- | --- 
[Vanara.Core](https://github.com/dahall/Vanara/blob/master/Core/AssemblyReport.md) | [![NuGet](https://buildstats.info/nuget/Vanara.Core)](https://www.nuget.org/packages/Vanara.Core) | Shared methods, structures and constants for use throughout the Vanara assemblies. Think of it as windows.h with some useful extensions.
[Vanara.PInvoke.Shared](https://github.com/dahall/Vanara/blob/master/PInvoke/Shared/AssemblyReport.md) | [![NuGet](https://buildstats.info/nuget/Vanara.PInvoke.Shared)](https://www.nuget.org/packages/Vanara.PInvoke.Shared) | Shared methods, structures and constants for use throughout the Vanara.PInvoke assemblies.
[Vanara.BITS](https://github.com/dahall/Vanara/blob/master/BITS/AssemblyReport.md) | [![NuGet](https://buildstats.info/nuget/Vanara.BITS)](https://www.nuget.org/packages/Vanara.BITS) | Classes for Background Transfer (BITS).
[Vanara.Security](https://github.com/dahall/Vanara/blob/master/Security/AssemblyReport.md) | [![NuGet](https://buildstats.info/nuget/Vanara.Security)](https://www.nuget.org/packages/Vanara.Security) | Classes for Windows Security that are missing or incomplete in .NET. Includes claims, privileges, impersonation, Active Directory, and UAC. 
[Vanara.SystemServices](https://github.com/dahall/Vanara/blob/master/System/AssemblyReport.md) | [![NuGet](https://buildstats.info/nuget/Vanara.SystemServices)](https://www.nuget.org/packages/Vanara.SystemServices) | Classes for Windows system functions. Includes WOW64 interaction, and file, process, path, networking and service controller extensions.
[Vanara.VirtualDisk](https://github.com/dahall/Vanara/blob/master/VirtualDisk/AssemblyReport.md) | [![NuGet](https://buildstats.info/nuget/Vanara.VirtualDisk)](https://www.nuget.org/packages/Vanara.VirtualDisk) | Classes for Virtual Disk management.
[Vanara.Windows.Forms](https://github.com/dahall/Vanara/blob/master/WIndows.Forms/AssemblyReport.md) | [![NuGet](https://buildstats.info/nuget/Vanara.Windows.Forms)](https://www.nuget.org/packages/Vanara.Windows.Forms) | Classes for user interface related items derived from the Vanara PInvoke libraries. Includes extensions for almost all common controls to give post Vista capabilities, WinForms controls (panel, commandlink, enhanced combo boxes, IPAddress, split button, trackbar and themed controls), shutdown/restart/lock control, buffered painting, resource files, access control editor, simplified designer framework for Windows.Forms.
[Vanara.Windows.Shell](https://github.com/dahall/Vanara/blob/master/Windows.Shell/AssemblyReport.md) | [![NuGet](https://buildstats.info/nuget/Vanara.Windows.Shell)](https://www.nuget.org/packages/Vanara.Windows.Shell) | Classes for Windows Shell items derived from the Vanara PInvoke libraries. Includes shell items, files, icons, links, shell properties, shell registration and taskbar lists.

## Quick Links
* [Documentation](https://github.com/dahall/Vanara/wiki)
* [Issues](https://github.com/dahall/Vanara/issues)

## Sample Code
There are numerous examples in the [UnitTest](https://github.com/dahall/Vanara/tree/master/UnitTests) folder and in the [WinClassicSamplesCS](https://github.com/dahall/WinClassicSamplesCS) project that recreates the Windows Samples in C# using Vanara.
