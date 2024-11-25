﻿![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.D3DCompiler NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.D3DCompiler?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows D3DCompiler.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.D3DCompiler**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
D3DCompile D3DCompile2 D3DCompileFromFile D3DCompressShaders D3DCreateBlob D3DCreateFunctionLinkingGraph D3DCreateLinker D3DDecompressShaders D3DDisassemble D3DDisassemble10Effect D3DDisassembleRegion D3DGetBlobPart D3DGetDebugInfo D3DGetInputAndOutputSignatureBlob D3DGetInputSignatureBlob D3DGetOutputSignatureBlob D3DGetTraceInstructionOffsets D3DLoadModule D3DPreprocess D3DReadFileToBlob D3DReflect D3DReflectLibrary D3DSetBlobPart D3DStripShader D3DWriteBlobToFile  | D3D_SHADER_REQUIRES_FLAGS D3D11_SHADER_VERSION_TYPE D3D_BLOB_PART D3D_COMPRESS_SHADER D3D_DISASM D3D_GET_INST_OFFSETS D3DCOMPILE D3DCOMPILE_EFFECT D3DCOMPILE_FLAGS2 D3DCOMPILE_SECDATA D3DCOMPILER_STRIP_FLAGS                | D3D11_FUNCTION_DESC D3D11_LIBRARY_DESC D3D11_PARAMETER_DESC D3D11_SHADER_BUFFER_DESC D3D11_SHADER_DESC D3D11_SHADER_INPUT_BIND_DESC D3D11_SHADER_TYPE_DESC D3D11_SHADER_VARIABLE_DESC D3D11_SIGNATURE_PARAMETER_DESC D3D_SHADER_DATA                 | ID3D11FunctionLinkingGraph ID3D11FunctionParameterReflection ID3D11FunctionReflection ID3D11LibraryReflection ID3D11Linker ID3D11LinkingNode ID3D11Module ID3D11ModuleInstance ID3D11ShaderReflection ID3D11ShaderReflectionConstantBuffer ID3D11ShaderReflectionType ID3D11ShaderReflectionVariable              
