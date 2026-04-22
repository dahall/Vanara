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
GetOpenCardNameA<br>GetOpenCardNameW<br>SCardAccessStartedEvent<br>SCardAddReaderToGroup<br>SCardAudit<br>SCardBeginTransaction<br>SCardCancel<br>SCardConnect<br>SCardControl<br>SCardDisconnect<br>SCardEndTransaction<br>SCardEstablishContext<br>SCardForgetCardType<br>SCardForgetReader<br>SCardForgetReaderGroup<br>SCardFreeMemory<br>SCardGetAttrib<br>SCardGetCardTypeProviderName<br>SCardGetDeviceTypeId<br>SCardGetProviderId<br>SCardGetReaderDeviceInstanceId<br>SCardGetReaderIcon<br>SCardGetStatusChange<br>SCardGetTransmitCount<br>SCardIntroduceCardType<br>SCardIntroduceReader<br>SCardIntroduceReaderGroup<br>SCardIsValidContext<br>SCardListCards<br>SCardListInterfaces<br>SCardListReaderGroups<br>SCardListReaders<br>SCardListReadersWithDeviceInstanceId<br>SCardLocateCards<br>SCardLocateCardsByATR<br>SCardReadCache<br>SCardReconnect<br>SCardReleaseContext<br>SCardReleaseStartedEvent<br>SCardRemoveReaderFromGroup<br>SCardSetAttrib<br>SCardSetCardTypeProviderName<br>SCardStatus<br>SCardTransmit<br>SCardUIDlgSelectCardA<br>SCardUIDlgSelectCardW<br>SCardWriteCache<br> | SC_DLG<br>SCARD_ACTION<br>SCARD_AUDIT_CHV<br>SCARD_PROVIDER<br>SCARD_SCOPE<br>SCARD_SHARE<br>SCARD_STATE<br>SCARD_POWER<br>SCARD_PROTOCOL<br>SCARD_READER<br>SCARD_READER_STATE<br>SCARD_READER_TYPE<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | SCARD_RET<br>OPENCARD_SEARCH_CRITERIA<br>OPENCARDNAME<br>OPENCARDNAME_EX<br>SCARD_ATRMASK<br>SCARD_READERSTATE<br>SCARDHANDLE<br>SCARD_IO_REQUEST<br>SCARD_T0_COMMAND<br>SCARD_T0_REQUEST<br>SCARD_T1_REQUEST<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
