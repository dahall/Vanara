<<<<<<< HEAD
![Vanara](/docs/icons/VanaraHeading.png)
In a number of projects I have needed to use native API calls. Over the years I have collected quite a few of these interop code chunks and I decided to pull them all together into a set of reusable libraries. I have tried to carve up the libraries into small enough chunks that they are easy to identify and consume. The only problem with this is that you can literally end up with over 20 dependencies on some of the higher function libraries (oh well).

I have tried to follow the concepts below in laying out the libraries.
* All functions that are imported from a single DLL should be placed into a single assembly that is named after the DLL
  * (e.g. The assembly `Vanara.PInvoke.Gdi32.dll` hosts all functions and supporting enumerations, constants and structures that are exported from `gdi32.dll` in the system directory.)
* Any structure or macro or enumeration (no function) that is used by many libraries is put into either `Vanara.Core` or `Vanara.PInvoke.Shared`
  * (e.g. The macro `HIWORD` and the structure `SIZE` are both in `Vanara.PInvoke.Shared` and classes to simplfy interop calls and native memory management are in `Vanara.Core`.)
* Inside a project, all constructs are contained in a file named after the header file (*.h) in which they are defined in the Windows API
  * (e.g. In the Vanara.PInvoke.Kernel32 project directory, you'll find a FileApi.cs, a WinBase.cs and a WinNT.cs file representing fileapi.h, winbase.h and winnt.h respectively.)
* Where the direct interpretation of a structure leads to memory leaks or misuse, I have tried to simplify their use
* Where structures are always passed by reference and where that structure needs to clean up memory allocations, I have changed the structure to class implementing `IDisposable`.
* Wherever possible, all handles have been turned into `SafeHandle` derivatives.
* Wherever possible, all functions that allocate memory that is to be freed by the caller use a safe memory handle.
* All PInvoke calls are in assemblies prefixed by `Vanara.PInvoke`
* If there are classes or extensions that make use of the PInvoke calls, they are in wrapper assemblies prefixed by `Vanara` and then followed by a logical name for the functionality. Today, those are Core, Security, SystemServices and UI.

## Quick Links
* [Issues](https://github.com/dahall/Vanara/issues)

## Installation
This project's assemblies are available via NuGet.

Link | Assembly | Description | Dependencies
---- | -------- | ----------- | ------------
[![NuGet](https://img.shields.io/nuget/v/Vanara.Core.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.Core)| Vanara.Core | Shared methods, structures and constants for use throughout the Vanara assemblies. Think of it as windows.h with some useful extensions. | None
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.Shared.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Shared)| Vanara.PInvoke.Shared | Shared methods, structures and constants for use throughout the Vanara.PInvoke assemblies | Vanara.Core
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.AclUI.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.AclUI)| Vanara.PInvoke.AclUI | Methods, structures and constants imported from AclUI.dll | Vanara.PInvoke.Security
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.ComCtl32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.ComCtl32)| Vanara.PInvoke.ComCtl32 | Methods, structures and constants imported from ComCtl32.dll | Vanara.PInvoke.User32
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.ComCtl32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.CredUI)| Vanara.PInvoke.CredUI | Methods, structures and constants imported from CredUI.dll | Vanara.PInvoke.Security
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.DwmApi.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.DwmApi)| Vanara.PInvoke.DwmApi | Methods, structures and constants imported from DwmApi.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.Gdi32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Gdi32)| Vanara.PInvoke.Gdi32 | Methods, structures and constants imported from Gdi32.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.Kernel32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Kernel32)| Vanara.PInvoke.Kernel32 | Methods, structures and constants imported from Kernel32.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.NetApi32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.NetApi32)| Vanara.PInvoke.NetApi32 | Methods, structures and constants imported from NetApi32.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.NetListMgr.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.NetListMgr)| Vanara.PInvoke.NetListMgr | Methods, structures and constants imported from NetListMgr.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.NTDSApi.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.NTDSApi)| Vanara.PInvoke.NTDSApi | Methods, structures and constants imported from NTDSApi.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.Ole.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Ole)| Vanara.PInvoke.Ole | Methods, structures and constants imported from Ole32.dll, OleAut32 and PropSys.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.Security.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Security)| Vanara.PInvoke.Security | Methods, structures and constants imported from AdvApi32.dll, Authz.dll and Secur32.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.ShlwApi.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.ShlwApi)| Vanara.PInvoke.ShlwApi | Methods, structures and constants imported from ShlwApi.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.Shell32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Shell32)| Vanara.PInvoke.Shell32 | Methods, structures and constants imported from Shell32.dll | Vanara.PInvoke.ComCtl32, Vanara.PInvoke.Ole, Vanara.PInvoke.Security
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.TaskSchd.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.TaskSchd)| Vanara.PInvoke.TaskSchd | Methods, structures and constants imported from TaskSchd.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.User32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.User32)| Vanara.PInvoke.User32 | Methods, structures and constants imported from User32.dll | Vanara.PInvoke.Gdi32, Vanara.PInvoke.Kernel32
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.UxTheme.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.UxTheme)| Vanara.PInvoke.UxTheme | Methods, structures and constants imported from UxTheme.dll | Vanara.PInvoke.Gdi32
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.VirtDisk.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.VirtDisk)| Vanara.PInvoke.VirtDisk | Methods, structures and constants imported from VirtDisk.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.WinINet.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.WinINet)| Vanara.PInvoke.WinINet | Methods, structures and constants imported from WinINet.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.Security.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.Security)| Vanara.Security | Wrapper classes for security related items in the PInvoke libraries | Vanara.PInvoke.NTDSApi, Vanara.PInvoke.Security
[![NuGet](https://img.shields.io/nuget/v/Vanara.SystemServices.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.SystemServices)| Vanara.SystemServices | Wrapper classes for system related items in the PInvoke libraries | Vanara.PInvoke.Kernel32, Vanara.PInvoke.VirtDisk
[![NuGet](https://img.shields.io/nuget/v/Vanara.UI.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.UI)| Vanara.UI | Wrapper classes for user interface related items in the PInvoke libraries | Vanara.PInvoke.AclUI, Vanara.PInvoke.CredUI, Vanara.PInvoke.ComCtl32, Vanara.PInvoke.DwmApi, Vanara.PInvoke.NetListMgr, Vanara.PInvoke.Shell32, Vanara.PInvoke.UxTheme

## Sample Code
There are numerous examples in the [UnitTest](https://github.com/dahall/Vanara/tree/master/UnitTests) folder.
=======
![Vanara](/docs/icons/VanaraHeading.png)

In a number of projects I have needed to use native API calls. Over the years I have collected quite a few of these interop code chunks and I decided to pull them all together into a set of reusable libraries. I have tried to carve up the libraries into small enough chunks that they are easy to identify and consume. The only problem with this is that you can literally end up with over 20 dependencies on some of the higher function libraries (oh well).

I have tried to follow the concepts below in laying out the libraries.
* All functions that are imported from a single DLL should be placed into a single assembly that is named after the DLL
  * (e.g. The assembly `Vanara.PInvoke.Gdi32.dll` hosts all functions and supporting enumerations, constants and structures that are exported from `gdi32.dll` in the system directory.)
* Any structure or macro or enumeration (no function) that is used by many libraries is put into either `Vanara.Core` or `Vanara.PInvoke.Shared`
  * (e.g. The macro `HIWORD` and the structure `SIZE` are both in `Vanara.PInvoke.Shared` and classes to simplfy interop calls and native memory management are in `Vanara.Core`.)
* Inside a project, all constructs are contained in a file named after the header file (*.h) in which they are defined in the Windows API
  * (e.g. In the Vanara.PInvoke.Kernel32 project directory, you'll find a FileApi.cs, a WinBase.cs and a WinNT.cs file representing fileapi.h, winbase.h and winnt.h respectively.)
* Where the direct interpretation of a structure leads to memory leaks or misuse, I have tried to simplify their use
* Where structures are always passed by reference and where that structure needs to clean up memory allocations, I have changed the structure to class implementing `IDisposable`.
* Wherever possible, all handles have been turned into `SafeHandle` derivatives.
* Wherever possible, all functions that allocate memory that is to be freed by the caller use a safe memory handle.
* All PInvoke calls are in assemblies prefixed by `Vanara.PInvoke`
* If there are classes or extensions that make use of the PInvoke calls, they are in wrapper assemblies prefixed by `Vanara` and then followed by a logical name for the functionality. Today, those are Core, Security, SystemServices and UI.

## Quick Links
* [Issues](https://github.com/dahall/Vanara/issues)

## Installation
This project's assemblies are available via NuGet.

Link | Assembly | Description | Dependencies
---- | -------- | ----------- | ------------
[![NuGet](https://img.shields.io/nuget/v/Vanara.Core.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.Core)| Vanara.Core | Shared methods, structures and constants for use throughout the Vanara assemblies. Think of it as windows.h with some useful extensions. | None
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.Shared.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Shared)| Vanara.PInvoke.Shared | Shared methods, structures and constants for use throughout the Vanara.PInvoke assemblies | Vanara.Core
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.AclUI.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.AclUI)| Vanara.PInvoke.AclUI | Methods, structures and constants imported from AclUI.dll | Vanara.PInvoke.Security
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.ComCtl32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.ComCtl32)| Vanara.PInvoke.ComCtl32 | Methods, structures and constants imported from ComCtl32.dll | Vanara.PInvoke.User32
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.ComCtl32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.CredUI)| Vanara.PInvoke.CredUI | Methods, structures and constants imported from CredUI.dll | Vanara.PInvoke.Security
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.DwmApi.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.DwmApi)| Vanara.PInvoke.DwmApi | Methods, structures and constants imported from DwmApi.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.Gdi32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Gdi32)| Vanara.PInvoke.Gdi32 | Methods, structures and constants imported from Gdi32.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.Kernel32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Kernel32)| Vanara.PInvoke.Kernel32 | Methods, structures and constants imported from Kernel32.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.NetApi32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.NetApi32)| Vanara.PInvoke.NetApi32 | Methods, structures and constants imported from NetApi32.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.NetListMgr.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.NetListMgr)| Vanara.PInvoke.NetListMgr | Methods, structures and constants imported from NetListMgr.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.NTDSApi.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.NTDSApi)| Vanara.PInvoke.NTDSApi | Methods, structures and constants imported from NTDSApi.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.Ole.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Ole)| Vanara.PInvoke.Ole | Methods, structures and constants imported from Ole32.dll, OleAut32 and PropSys.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.Security.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Security)| Vanara.PInvoke.Security | Methods, structures and constants imported from AdvApi32.dll, Authz.dll and Secur32.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.ShlwApi.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.ShlwApi)| Vanara.PInvoke.ShlwApi | Methods, structures and constants imported from ShlwApi.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.Shell32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.Shell32)| Vanara.PInvoke.Shell32 | Methods, structures and constants imported from Shell32.dll | Vanara.PInvoke.ComCtl32, Vanara.PInvoke.Ole, Vanara.PInvoke.Security
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.TaskSchd.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.TaskSchd)| Vanara.PInvoke.TaskSchd | Methods, structures and constants imported from TaskSchd.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.User32.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.User32)| Vanara.PInvoke.User32 | Methods, structures and constants imported from User32.dll | Vanara.PInvoke.Gdi32, Vanara.PInvoke.Kernel32
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.UxTheme.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.UxTheme)| Vanara.PInvoke.UxTheme | Methods, structures and constants imported from UxTheme.dll | Vanara.PInvoke.Gdi32
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.VirtDisk.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.VirtDisk)| Vanara.PInvoke.VirtDisk | Methods, structures and constants imported from VirtDisk.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.PInvoke.WinINet.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.PInvoke.WinINet)| Vanara.PInvoke.WinINet | Methods, structures and constants imported from WinINet.dll | Vanara.PInvoke.Shared
[![NuGet](https://img.shields.io/nuget/v/Vanara.Security.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.Security)| Vanara.Security | Wrapper classes for security related items in the PInvoke libraries | Vanara.PInvoke.NTDSApi, Vanara.PInvoke.Security
[![NuGet](https://img.shields.io/nuget/v/Vanara.SystemServices.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.SystemServices)| Vanara.SystemServices | Wrapper classes for system related items in the PInvoke libraries | Vanara.PInvoke.Kernel32, Vanara.PInvoke.VirtDisk
[![NuGet](https://img.shields.io/nuget/v/Vanara.UI.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.UI)| Vanara.UI | Wrapper classes for user interface related items in the PInvoke libraries | Vanara.PInvoke.AclUI, Vanara.PInvoke.CredUI, Vanara.PInvoke.ComCtl32, Vanara.PInvoke.DwmApi, Vanara.PInvoke.NetListMgr, Vanara.PInvoke.Shell32, Vanara.PInvoke.UxTheme

## Sample Code
There are numerous examples in the [UnitTest](https://github.com/dahall/Vanara/tree/master/UnitTests) folder.
>>>>>>> 96fdde0e524112a3238f949429ec2213c7349648
