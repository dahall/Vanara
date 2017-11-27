![Vanara](/docs/Vanara64x64.png)
# Vanara
> A set of .NET assemblies containing PInvoke (Interop) references and related extensions.

## Quick Links
* [Discussion Forum (users helping users, enhancement requests, Q&A)](https://groups.google.com/forum/#!forum/vanara)
* [Documentation Wiki (samples, library how-to, etc.)](https://github.com/dahall/Vanara/wiki)
* [API documentation (class/method/property help)](https://dahall.github.io/Vanara)
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
[![NuGet](https://img.shields.io/nuget/v/Vanara.Security.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.Security)| Vanara.Security | Wrapper classes for security related items in the PInvoke libraries | Vanara.PInvoke.AclUI, Vanara.PInvoke.CredUI
[![NuGet](https://img.shields.io/nuget/v/Vanara.SystemServices.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.SystemServices)| Vanara.SystemServices | Wrapper classes for system related items in the PInvoke libraries | Vanara.PInvoke.Kernel32, Vanara.PInvoke.VirtDisk
[![NuGet](https://img.shields.io/nuget/v/Vanara.UI.svg?style=flat-square)](https://www.nuget.org/packages/Vanara.UI)| Vanara.UI | Wrapper classes for user interface related items in the PInvoke libraries | Vanara.PInvoke.ComCtl32, Vanara.PInvoke.NetListMgr, Vanara.PInvoke.Shell32, Vanara.PInvoke.UxTheme

## Sample Code
There are numerous examples in the [UnitTest](https://github.com/dahall/Vanara/tree/master/UnitTests) folder.