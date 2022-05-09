![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.IScsiDsc NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.IScsiDsc?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows ISCSI Discovery Library (IScsiDsc.dll).

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.IScsiDsc

Functions | Enumerations | Structures
--- | --- | ---
AddIScsiConnection<br>AddIScsiSendTargetPortal<br>AddIScsiStaticTarget<br>AddISNSServer<br>AddPersistentIScsiDevice<br>AddRadiusServer<br>ClearPersistentIScsiDevices<br>GetDevicesForIScsiSession<br>GetIScsiIKEInfo<br>GetIScsiInitiatorNodeName<br>GetIScsiSessionList<br>GetIScsiTargetInformation<br>GetIScsiVersionInformation<br>LoginIScsiTarget<br>LogoutIScsiTarget<br>RefreshIScsiSendTargetPortal<br>RefreshISNSServer<br>RemoveIScsiConnection<br>RemoveIScsiPersistentTarget<br>RemoveIScsiSendTargetPortal<br>RemoveIScsiStaticTarget<br>RemoveISNSServer<br>RemovePersistentIScsiDevice<br>RemoveRadiusServer<br>ReportActiveIScsiTargetMappings<br>ReportIScsiInitiatorList<br>ReportIScsiPersistentLogins<br>ReportIScsiSendTargetPortals<br>ReportIScsiSendTargetPortalsEx<br>ReportIScsiTargetPortals<br>ReportIScsiTargets<br>ReportISNSServerList<br>ReportPersistentIScsiDevices<br>ReportRadiusServerList<br>SendScsiInquiry<br>SendScsiReadCapacity<br>SendScsiReportLuns<br>SetIScsiGroupPresharedKey<br>SetIScsiIKEInfo<br>SetIScsiInitiatorCHAPSharedSecret<br>SetIScsiInitiatorNodeName<br>SetIScsiInitiatorRADIUSSharedSecret<br>SetIScsiTunnelModeOuterAddress<br>SetupPersistentIScsiDevices<br>SetupPersistentIScsiVolumes<br> | IKE_AUTHENTICATION_METHOD<br>IKE_IDENTIFICATION_PAYLOAD_TYPE<br>ISCSI_AUTH_TYPES<br>ISCSI_DIGEST_TYPES<br>ISCSI_LOGIN_FLAGS<br>ISCSI_LOGIN_OPTIONS_INFO_SPECIFIED<br>ISCSI_SECURITY_FLAGS<br>ISCSI_TARGET_FLAGS<br>TARGET_INFORMATION_CLASS<br>TARGETPROTOCOLTYPE<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | IKE_AUTHENTICATION_INFORMATION<br>IKE_AUTHENTICATION_PRESHARED_KEY<br>ISCSI_CONNECTION_INFO<br>ISCSI_DEVICE_ON_SESSION<br>ISCSI_LOGIN_OPTIONS<br>ISCSI_SESSION_INFO<br>ISCSI_TARGET_MAPPING<br>ISCSI_TARGET_PORTAL<br>ISCSI_TARGET_PORTAL_GROUP<br>ISCSI_TARGET_PORTAL_INFO<br>ISCSI_TARGET_PORTAL_INFO_EX<br>ISCSI_UNIQUE_SESSION_ID<br>ISCSI_VERSION_INFO<br>PERSISTENT_ISCSI_LOGIN_INFO<br>SCSI_ADDRESS<br>SCSI_LUN_LIST<br>STORAGE_DEVICE_NUMBER<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
