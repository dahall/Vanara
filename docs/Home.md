# Welcome to the Vanara API help

In a number of projects I have needed to use native API calls. Over the years I have collected quite a few of these interop code chunks and I decided to pull them all together into a set of reusable libraries. I have tried to carve up the libraries into small enough chunks that they are easy to identify and consume. The only problem with this is that you can literally end up with over 20 dependencies on some of the higher function libraries (oh well).



## Getting Started

Go out to MSDN and find the API functions or structures you'd like to use. Take note of the DLL in which it is implemented (usually at the very bottom of the page). This will be the name of the Vanara assembly (Vanara.PInvoke.[DLL_Name]). The only exceptions to this are for the security libraries (AdvApi32.dll, Authz.dll and Secur32.dll) which are all in the Vanara.PInvoke.Security assembly and the OLE/COM related libraries (Ole32.dll, OleAut32.dll and PropSys.dll) which are all in the Vanara.PInvoke.Ole assembly. To confirm these libraries have included that method you can search the <a href="https://dahall.github.io/Vanara">API Help</a> or search through the code.


For example, let's say you want to use the `FormatMessage` function. You go to is page in MSDN and see that it is in the Kernel32.dll and in the WinBase.h header. This would indicate that it should be in the Vanara.PInvoke.<u>Kernel32</u> assembly and NuGet package. In the code, it will indicate that you should find it in the PInvoke\Kernel32 project directory and in the WinBase.cs file.


If you find an API call that is not in the library, please <a href="https://github.com/dahall/Vanara/issues/new">log an issue</a> requesting it.



## See Also


#### Other Resources
<a href="b2b4b5a4-7eb7-47f0-aa84-e4d68ac1515f">Version History</a><br />