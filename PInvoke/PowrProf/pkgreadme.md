![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.PowrProf NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.PowrProf?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows PowrProf.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.PowrProf**

Functions | Enumerations | Structures
--- | --- | ---
CallNtPowerInformation CanUserWritePwrScheme DeletePwrScheme DevicePowerClose DevicePowerEnumDevices DevicePowerOpen DevicePowerSetDeviceState EnumPwrSchemes GetActivePwrScheme GetCurrentPowerPolicies GetPwrCapabilities GetPwrDiskSpindownRange IsPwrHibernateAllowed IsPwrShutdownAllowed IsPwrSuspendAllowed PowerCanRestoreIndividualDefaultPowerScheme PowerCreatePossibleSetting PowerCreateSetting PowerDeleteScheme PowerDeterminePlatformRole PowerDeterminePlatformRoleEx PowerDuplicateScheme PowerEnumerate PowerGetActiveScheme PowerImportPowerScheme PowerIsSettingRangeDefined PowerReadACDefaultIndex PowerReadACValue PowerReadACValueIndex PowerReadDCDefaultIndex PowerReadDCValue PowerReadDCValueIndex PowerReadDescription PowerReadFriendlyName PowerReadIconResourceSpecifier PowerReadPossibleDescription PowerReadPossibleFriendlyName PowerReadPossibleValue PowerReadSettingAttributes PowerReadValueIncrement PowerReadValueMax PowerReadValueMin PowerReadValueUnitsSpecifier PowerRegisterForEffectivePowerModeNotifications PowerRegisterSuspendResumeNotification PowerRemovePowerSetting PowerReplaceDefaultPowerSchemes PowerReportThermalEvent PowerRestoreDefaultPowerSchemes PowerRestoreIndividualDefaultPowerScheme PowerSetActiveScheme PowerSettingAccessCheck PowerSettingAccessCheckEx PowerSettingRegisterNotification PowerSettingUnregisterNotification PowerUnregisterFromEffectivePowerModeNotifications PowerUnregisterSuspendResumeNotification PowerWriteACDefaultIndex PowerWriteACValueIndex PowerWriteDCDefaultIndex PowerWriteDCValueIndex PowerWriteDescription PowerWriteFriendlyName PowerWriteIconResourceSpecifier PowerWritePossibleDescription PowerWritePossibleFriendlyName PowerWritePossibleValue PowerWriteSettingAttributes PowerWriteValueIncrement PowerWriteValueMax PowerWriteValueMin PowerWriteValueUnitsSpecifier ReadGlobalPwrPolicy ReadProcessorPwrScheme ReadPwrScheme SetActivePwrScheme SetSuspendState WriteGlobalPwrPolicy WriteProcessorPwrScheme WritePwrScheme  | POWER_INFORMATION_LEVEL PowerPlatformRoleVersion RegisterSuspendResumeNotificationFlags DEVICE_PWR_NOTIFY EFFECTIVE_POWER_MODE GlobalFlags PDQUERY PDSET POWER_ATTR POWER_DATA_ACCESSOR ENERGY_SAVER_STATUS EventCode POWER_ACTION POWER_PLATFORM_ROLE PROCESSOR_POWER_POLICY_INFO_Options SYSTEM_POWER_CONDITION PowerActionFlags                                                                 | DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS GLOBAL_MACHINE_POWER_POLICY GLOBAL_POWER_POLICY GLOBAL_USER_POWER_POLICY MACHINE_POWER_POLICY MACHINE_PROCESSOR_POWER_POLICY POWER_POLICY THERMAL_EVENT USER_POWER_POLICY BATTERY_REPORTING_SCALE POWER_ACTION_POLICY PROCESSOR_POWER_POLICY PROCESSOR_POWER_POLICY_INFO SYSTEM_POWER_CAPABILITIES SYSTEM_POWER_LEVEL                                                                  
