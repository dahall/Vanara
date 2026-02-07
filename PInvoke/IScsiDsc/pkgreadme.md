![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.IScsiDsc NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.IScsiDsc?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows ISCSI Discovery Library (IScsiDsc.dll).

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.IScsiDsc**

Functions | Enumerations | Structures
--- | --- | ---
AddIScsiConnection AddIScsiSendTargetPortal AddIScsiStaticTarget AddISNSServer AddPersistentIScsiDevice AddRadiusServer ClearPersistentIScsiDevices GetDevicesForIScsiSession GetIScsiIKEInfo GetIScsiInitiatorNodeName GetIScsiSessionList GetIScsiTargetInformation GetIScsiVersionInformation LoginIScsiTarget LogoutIScsiTarget RefreshIScsiSendTargetPortal RefreshISNSServer RemoveIScsiConnection RemoveIScsiPersistentTarget RemoveIScsiSendTargetPortal RemoveIScsiStaticTarget RemoveISNSServer RemovePersistentIScsiDevice RemoveRadiusServer ReportActiveIScsiTargetMappings ReportIScsiInitiatorList ReportIScsiPersistentLogins ReportIScsiSendTargetPortals ReportIScsiSendTargetPortalsEx ReportIScsiTargetPortals ReportIScsiTargets ReportISNSServerList ReportPersistentIScsiDevices ReportRadiusServerList SendScsiInquiry SendScsiReadCapacity SendScsiReportLuns SetIScsiGroupPresharedKey SetIScsiIKEInfo SetIScsiInitiatorCHAPSharedSecret SetIScsiInitiatorNodeName SetIScsiInitiatorRADIUSSharedSecret SetIScsiTunnelModeOuterAddress SetupPersistentIScsiDevices SetupPersistentIScsiVolumes  | IKE_AUTHENTICATION_METHOD IKE_IDENTIFICATION_PAYLOAD_TYPE ISCSI_AUTH_TYPES ISCSI_DIGEST_TYPES ISCSI_LOGIN_FLAGS ISCSI_LOGIN_OPTIONS_INFO_SPECIFIED ISCSI_SECURITY_FLAGS ISCSI_TARGET_FLAGS TARGET_INFORMATION_CLASS TARGETPROTOCOLTYPE                                     | IKE_AUTHENTICATION_INFORMATION IKE_AUTHENTICATION_PRESHARED_KEY ISCSI_CONNECTION_INFO ISCSI_DEVICE_ON_SESSION ISCSI_LOGIN_OPTIONS ISCSI_SESSION_INFO ISCSI_SESSION_INFO_MGD ISCSI_TARGET_MAPPING ISCSI_TARGET_PORTAL ISCSI_TARGET_PORTAL_GROUP ISCSI_TARGET_PORTAL_INFO ISCSI_TARGET_PORTAL_INFO_EX ISCSI_UNIQUE_SESSION_ID ISCSI_VERSION_INFO PERSISTENT_ISCSI_LOGIN_INFO SCSI_ADDRESS SCSI_LUN_LIST STORAGE_DEVICE_NUMBER                            
