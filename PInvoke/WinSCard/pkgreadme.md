![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.WinSCard NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.WinSCard?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows WinSCard.dll. This assembly provides the definitions and symbols necessary for an Application or Smart Card Service Provider to access the Smartcard Subsystem.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.WinSCard**

Functions | Enumerations | Structures
--- | --- | ---
GetOpenCardNameA GetOpenCardNameW SCardAccessStartedEvent SCardAddReaderToGroup SCardAudit SCardBeginTransaction SCardCancel SCardConnect SCardControl SCardDisconnect SCardEndTransaction SCardEstablishContext SCardForgetCardType SCardForgetReader SCardForgetReaderGroup SCardFreeMemory SCardGetAttrib SCardGetCardTypeProviderName SCardGetDeviceTypeId SCardGetProviderId SCardGetReaderDeviceInstanceId SCardGetReaderIcon SCardGetStatusChange SCardGetTransmitCount SCardIntroduceCardType SCardIntroduceReader SCardIntroduceReaderGroup SCardIsValidContext SCardListCards SCardListInterfaces SCardListReaderGroups SCardListReaders SCardListReadersWithDeviceInstanceId SCardLocateCards SCardLocateCardsByATR SCardReadCache SCardReconnect SCardReleaseContext SCardReleaseStartedEvent SCardRemoveReaderFromGroup SCardSetAttrib SCardSetCardTypeProviderName SCardStatus SCardTransmit SCardUIDlgSelectCardA SCardUIDlgSelectCardW SCardWriteCache  | SC_DLG SCARD_ACTION SCARD_AUDIT_CHV SCARD_PROVIDER SCARD_SCOPE SCARD_SHARE SCARD_STATE SCARD_POWER SCARD_PROTOCOL SCARD_READER SCARD_READER_STATE SCARD_READER_TYPE                                     | SCARD_RET OPENCARD_SEARCH_CRITERIA OPENCARDNAME OPENCARDNAME_EX SCARD_ATRMASK SCARD_READERSTATE SCARDHANDLE SCARD_IO_REQUEST SCARD_T0_COMMAND SCARD_T0_REQUEST SCARD_T1_REQUEST                                     
