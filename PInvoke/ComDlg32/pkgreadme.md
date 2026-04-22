![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.ComDlg32 NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.ComDlg32?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows ComDlg32.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.ComDlg32**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
ChooseColor<br>ChooseFont<br>CommDlgExtendedError<br>FindText<br>GetFileTitle<br>GetOpenFileName<br>GetSaveFileName<br>PageSetupDlg<br>PrintDlg<br>PrintDlgEx<br>ReplaceText<br> | CC<br>ERR<br>CF<br>DN<br>OFN<br>OFN_EX<br>PD<br>PD_EXCL<br>PD_RESULT<br>PSD<br><br> | CHOOSECOLOR<br>CHOOSEFONT<br>DEVNAMES<br>FINDREPLACE<br>OFNOTIFY<br>OFNOTIFYEX<br>OPENFILENAME<br>PAGESETUPDLG<br>PRINTDLG<br>PRINTDLGEX<br>PRINTPAGERANGE<br> | IPrintDialogCallback<br>IPrintDialogServices<br><br><br><br><br><br><br><br><br><br>
