![Vanara](/docs/icons/VanaraHeading.png)

This project contains various .NET assemblies that contain P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries. For example, Shlwapi.dll has all the exported functions from shlwapi.lib; Kernel32.dll has all for both kernel32.lib and kernelbase.lib.

All assemblies are available via NuGet and provide builds against .NET 2.0, 3.5, 4.0 and 4.5. In all cases where a dependency doesn't disallow it, a .NET Standard 2.0 build is also included for use with UWP and other .NET Core and Standard projects.

## Use
1. Look for the function you need in Microsoft documentation. Note which library or DLL the function is in.
2. Confirm the Vanara library exists and has your function by looking at the table below. Clicking on the Assembly link will take you to a drill down of that assembly's coverage. Find your function and if there is a matching implementation it will appear to the right.
3. Add the assembly to your project via NuGet.
4. To use the function, you can:
   1. Call it directly `var bret = Vanara.PInvoke.Kernel32.GetComputerName(sb, ref sbSz);`
   2. Under C# 6.0 and later, use a static using directive and call it:
   ```
   using static Vanara.PInvoke.Kernel32;
   
   var bret = GetComputerName(sb, ref sbSz);
   ```

## Design Concepts

I have tried to follow the concepts below in laying out the libraries.
* All functions that are imported from a single DLL should be placed into a single assembly that is named after the DLL
  * (e.g. The assembly `Vanara.PInvoke.Gdi32.dll` hosts all functions and supporting enumerations, constants and structures that are exported from `gdi32.dll` in the system directory.)
* Any structure or macro or enumeration (no function) that is used by many libraries is put into either `Vanara.Core` or `Vanara.PInvoke.Shared`
  * (e.g. The macro `HIWORD` and the structure `SIZE` are both in `Vanara.PInvoke.Shared` and classes to simplfy interop calls and native memory management are in `Vanara.Core`.)
* Inside a project, all constructs are contained in a file named after the header file (*.h) in which they are defined in the Windows API
  * (e.g. In the Vanara.PInvoke.Kernel32 project directory, you'll find a FileApi.cs, a WinBase.cs and a WinNT.cs file representing fileapi.h, winbase.h and winnt.h respectively.)
* Where the direct interpretation of a structure leads to memory leaks or misuse, I have tried to simplify their use
* Where structures are always passed by reference and where that structure needs to clean up memory allocations, I have changed the structure to a class implementing `IDisposable`.
* Wherever possible, all handles have been turned into `SafeHandle` derivatives.
* Wherever possible, all functions that allocate memory that is to be freed by the caller use a safe memory handle.
* All PInvoke calls are in assemblies prefixed by `Vanara.PInvoke`
* If there are classes or extensions that make use of the PInvoke calls, they are in wrapper assemblies prefixed by `Vanara` and then followed by a logical name for the functionality. Today, those are Core, Security, SystemServices, Windows.Forms and Windows.Shell.

## Supported Libraries

Library/DLL | Assembly | NuGet&nbsp;Link
--- | --- | --- | --- 
AclUI.dll | [Vanara.PInvoke.AclUI](https://github.com/dahall/Vanara/blob/master/PInvoke/AclUI/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-100%25-green.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.AclUI.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.AclUI)
qmgr.dll (BITS) | [Vanara.PInvoke.BITS](https://github.com/dahall/Vanara/blob/master/PInvoke/BITS/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-100%25-green.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.BITS.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.BITS)
ComCtl32.dll | [Vanara.PInvoke.ComCtl32](https://github.com/dahall/Vanara/blob/master/PInvoke/ComCtl32/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-100%25-green.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.ComCtl32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.ComCtl32)
CredUI.dll | [Vanara.PInvoke.CredUI](https://github.com/dahall/Vanara/blob/master/PInvoke/CredUI/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-100%25-green.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.CredUI.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.CredUI)
Crypt32.dll | [Vanara.PInvoke.Crypt32](https://github.com/dahall/Vanara/blob/master/PInvoke/Crypt32/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-0%25-red.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.Crypt32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Crypt32)
DwmApi.dll | [Vanara.PInvoke.DwmApi](https://github.com/dahall/Vanara/blob/master/PInvoke/DwmApi/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-100%25-green.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.DwmApi.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.DwmApi)
Gdi32.dll | [Vanara.PInvoke.Gdi32](https://github.com/dahall/Vanara/blob/master/PInvoke/Gdi32/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-1%25-red.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.Gdi32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Gdi32)
IpHlpApi.dll | [Vanara.PInvoke.IpHlpApi](https://github.com/dahall/Vanara/blob/master/PInvoke/IpHlpApi/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-26%25-yellow.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.IpHlpApi.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.IpHlpApi)
Kernel32.dll | [Vanara.PInvoke.Kernel32](https://github.com/dahall/Vanara/blob/master/PInvoke/Kernel32/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-100%25-green.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.Kernel32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Kernel32)
Mpr.dll | [Vanara.PInvoke.Mpr](https://github.com/dahall/Vanara/blob/master/PInvoke/Mpr/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-100%25-green.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.Mpr.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Mpr)
NetApi32.dll | [Vanara.PInvoke.NetApi32](https://github.com/dahall/Vanara/blob/master/PInvoke/NetApi32/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-1%25-red.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.NetApi32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.NetApi32)
NetListMgr.dll | [Vanara.PInvoke.NetListMgr](https://github.com/dahall/Vanara/blob/master/PInvoke/NetListMgr/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-100%25-green.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.NetListMgr.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.NetListMgr)
NTDSApi.dll | [Vanara.PInvoke.NTDSApi](https://github.com/dahall/Vanara/blob/master/PInvoke/NTDSApi/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-8%25-red.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.NTDSApi.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.NTDSApi)
Ole32.dll, OleAut32 and PropSys.dll | [Vanara.PInvoke.Ole](https://github.com/dahall/Vanara/blob/master/PInvoke/Ole/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-7%25-red.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.Ole.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Ole)
AdvApi32.dll, Authz.dll and Secur32.dll | [Vanara.PInvoke.Security](https://github.com/dahall/Vanara/blob/master/PInvoke/Security/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-11%25-red.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.Security.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Security)
Shell32.dll | [Vanara.PInvoke.Shell32](https://github.com/dahall/Vanara/blob/master/PInvoke/Shell32/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-100%25-green.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.Shell32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Shell32)
ShlwApi.dll | [Vanara.PInvoke.ShlwApi](https://github.com/dahall/Vanara/blob/master/PInvoke/ShlwApi/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-100%25-green.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.ShlwApi.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.ShlwApi)
TaskSchd.dll | [Vanara.PInvoke.TaskSchd](https://github.com/dahall/Vanara/blob/master/PInvoke/TaskSchd/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-100%25-green.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.TaskSchd.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.TaskSchd)
User32.dll | [Vanara.PInvoke.User32](https://github.com/dahall/Vanara/blob/master/PInvoke/User32/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-4%25-red.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.User32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.User32)
User32.dll that have GDI references | [Vanara.PInvoke.User32.Gdi](https://github.com/dahall/Vanara/blob/master/PInvoke/User32.Gdi/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-2%25-red.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.User32.Gdi.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.User32.Gdi)
UxTheme.dll | [Vanara.PInvoke.UxTheme](https://github.com/dahall/Vanara/blob/master/PInvoke/UxTheme/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-100%25-green.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.UxTheme.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.UxTheme)
VirtDisk.dll | [Vanara.PInvoke.VirtDisk](https://github.com/dahall/Vanara/blob/master/PInvoke/VirtDisk/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-100%25-green.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.VirtDisk.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.VirtDisk)
WinINet.dll | [Vanara.PInvoke.WinINet](https://github.com/dahall/Vanara/blob/master/PInvoke/WinINet/CorrelationReport.md)<br>![Coverage](https://img.shields.io/badge/coverage-3%25-red.svg) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.WinINet.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.WinINet)

## Supporting Assemblies

Assembly | NuGet&nbsp;Link | Description
--- | --- | --- 
[Vanara.Core](https://github.com/dahall/Vanara/blob/master/Core/AssemblyReport.md) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.Core.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.Core) | Shared methods, structures and constants for use throughout the Vanara assemblies. Think of it as windows.h with some useful extensions.
[Vanara.PInvoke.Shared](https://github.com/dahall/Vanara/blob/master/PInvoke/Shared/AssemblyReport.md) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.PInvoke.Shared.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Shared) | Shared methods, structures and constants for use throughout the Vanara.PInvoke assemblies
[Vanara.Security](https://github.com/dahall/Vanara/blob/master/Security/AssemblyReport.md) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.Security.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.Security) | Wrapper classes for security related items in the PInvoke libraries 
[Vanara.SystemServices](https://github.com/dahall/Vanara/blob/master/System/AssemblyReport.md) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.SystemServices.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.SystemServices) | Wrapper classes for system related items in the PInvoke libraries 
[Vanara.Windows.Forms](https://github.com/dahall/Vanara/blob/master/WIndows.Forms/AssemblyReport.md) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.Windows.Forms.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.Windows.Forms) | Classes for user interface related items derived from the Vanara PInvoke libraries. Includes extensions for almost all common controls to give post Vista capabilities, WinForms controls (panel, commandlink, enhanced combo boxes, IPAddress, split button, trackbar and themed controls), shutdown/restart/lock control, buffered painting, resource files, access control editor, simplified designer framework for Windows.Forms.
[Vanara.Windows.Shell](https://github.com/dahall/Vanara/blob/master/Windows.Shell/AssemblyReport.md) | [![NuGet Package](https://img.shields.io/nuget/v/Vanara.Windows.Shell.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.Windows.Shell) | Classes for Windows Shell items derived from the Vanara PInvoke libraries. Includes shell items, files, icons, links, and taskbar lists.

## Quick Links
* [Documentation](https://github.com/dahall/Vanara/wiki)
* [Issues](https://github.com/dahall/Vanara/issues)

## Sample Code
There are numerous examples in the [UnitTest](https://github.com/dahall/Vanara/tree/master/UnitTests) folder.
