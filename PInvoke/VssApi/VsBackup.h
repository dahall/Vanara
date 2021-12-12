#pragma once
#include "pch.h"
#include "vswriter.h"
#include "CliLists.h"

using namespace System;
using namespace Collections::Generic;
using namespace Runtime::InteropServices;

namespace Vanara {
	namespace PInvoke {
		namespace VssApi {
			ref class CVssExamineWriterMetadata;

			ref class CVssWMComponent : IVssWMComponent, BaseWrapper<::IVssWMComponent>
			{
			public:
				CVssWMComponent(::IVssWMComponent* ptr) : BaseWrapper(ptr) {}
				~CVssWMComponent() { if (pInfo && pNative) { pin_ptr<::VSS_COMPONENTINFO> p = pInfo; pNative->FreeComponentInfo(p); } }

				virtual VSS_COMPONENTINFO GetComponentInfo();

#define DEFINE_WM_COMP_ROLIST(prop, itf, cfield, gfunc, cwrap) \
			private:\
				ListImplBase<itf^>^ f##prop;\
				int Get##prop##Count() { RefreshInfo(); return pInfo->cfield; }\
				itf^ Get##prop(int i) { ::itf* p; Utils::ThrowIfFailed(pNative->gfunc(i, &p)); return gcnew cwrap(p); }\
			public:\
				property IReadOnlyList<itf^>^ prop { virtual IReadOnlyList<itf^>^ get() {\
					if (!f##prop) f##prop = gcnew ListImplBase<itf^>(gcnew GetCount(this, &CVssWMComponent::Get##prop##Count), gcnew GetValue<itf^>(this, &CVssWMComponent::Get##prop));\
					return f##prop; } }

				DEFINE_WM_COMP_ROLIST(DatabaseFiles, IVssWMFiledesc, cDatabases, GetDatabaseFile, CVssWMFiledesc)
					DEFINE_WM_COMP_ROLIST(Files, IVssWMFiledesc, cFileCount, GetFile, CVssWMFiledesc)
					DEFINE_WM_COMP_ROLIST(DatabaseLogFiles, IVssWMFiledesc, cLogFiles, GetDatabaseLogFile, CVssWMFiledesc)
					DEFINE_WM_COMP_ROLIST(Dependencies, IVssWMDependency, cDependencies, GetDependency, CVssWMDependency)

			private:
				::VSS_COMPONENTINFO* pInfo;
				void RefreshInfo()
				{
					pin_ptr<::VSS_COMPONENTINFO> p = pInfo;
					if (pInfo != nullptr)
						pNative->FreeComponentInfo(p);
					Utils::ThrowIfFailed(pNative->GetComponentInfo((::PVSSCOMPONENTINFO*)&p));
				}
			};

			ref class CVssBackupComponents : IVssBackupComponents, BaseWrapper<::IVssBackupComponents>
			{
			public:
				CVssBackupComponents(::IVssBackupComponents* ptr) : BaseWrapper(ptr) {}

				virtual void AbortBackup() { Utils::ThrowIfFailed(pNative->AbortBackup()); }
				virtual void AddAlternativeLocationMapping(Guid writerId, VSS_COMPONENT_TYPE componentType, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath,
					String^ wszComponentName, String^ wszPath, String^ wszFilespec, Boolean bRecursive, String^ wszDestination)
				{
					Utils::ThrowIfFailed(pNative->AddAlternativeLocationMapping(SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(componentType),
						SafeWString(wszLogicalPath), SafeWString(wszComponentName), SafeWString(wszPath), SafeWString(wszFilespec), bRecursive, SafeWString(wszDestination)));
				}
				virtual void AddComponent(Guid instanceId, Guid writerId, VSS_COMPONENT_TYPE ct, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath, String^ wszComponentName)
				{
					Utils::ThrowIfFailed(pNative->AddComponent(SmartGuid(instanceId), SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(ct),
						SafeWString(wszLogicalPath), SafeWString(wszComponentName)));
				}
				virtual void AddNewTarget(Guid writerId, VSS_COMPONENT_TYPE ct, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath, String^ wszComponentName, String^ wszPath,
					String^ wszFileName, Boolean bRecursive, String^ wszAlternatePath)
				{
					Utils::ThrowIfFailed(pNative->AddNewTarget(SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(ct), SafeWString(wszLogicalPath), SafeWString(wszComponentName),
						SafeWString(wszPath), SafeWString(wszFileName), bRecursive, SafeWString(wszAlternatePath)));
				}
				virtual void AddRestoreSubcomponent(Guid writerId, VSS_COMPONENT_TYPE componentType, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath,
					String^ wszComponentName, String^ wszSubComponentLogicalPath, String^ wszSubComponentName, Boolean bRepair)
				{
					Utils::ThrowIfFailed(pNative->AddRestoreSubcomponent(SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(componentType), SafeWString(wszLogicalPath), SafeWString(wszComponentName),
						SafeWString(wszSubComponentLogicalPath), SafeWString(wszSubComponentName), bRepair));
				}
				virtual void AddSnapshotToRecoverySet(Guid snapshotId, [System::Runtime::InteropServices::Optional] UInt32 dwFlags, [System::Runtime::InteropServices::Optional] String^ pwszDestinationVolume)
				{
					SafeComPtr<::IVssBackupComponentsEx3*> p = pNative;
					Utils::ThrowIfFailed(p->AddSnapshotToRecoverySet(SmartGuid(snapshotId), dwFlags, SafeWString(pwszDestinationVolume)));
				}
				virtual Guid AddToSnapshotSet(String^ pwszVolumeName, Guid ProviderId)
				{
					VSS_ID id;
					Utils::ThrowIfFailed(pNative->AddToSnapshotSet(SafeWString(pwszVolumeName), SmartGuid(ProviderId), &id));
					return Utils::FromGUID(id);
				}
				virtual IVssAsync^ BackupComplete()
				{
					SafeComPtr<::IVssAsync*> pa;
					Utils::ThrowIfFailed(pNative->BackupComplete(&pa));
					return mgd_cast(IVssAsync, pa);
				}
				virtual void BreakSnapshotSet(Guid SnapshotSetId) { Utils::ThrowIfFailed(pNative->BreakSnapshotSet(SmartGuid(SnapshotSetId))); }
				virtual IVssAsync^ BreakSnapshotSetEx(Guid SnapshotSetID, VSS_HARDWARE_OPTIONS dwBreakFlags)
				{
					SafeComPtr<::IVssBackupComponentsEx2*> p = pNative;
					SafeComPtr<::IVssAsync*> pa;
					Utils::ThrowIfFailed(p->BreakSnapshotSetEx(SmartGuid(SnapshotSetID), static_cast<::VSS_HARDWARE_OPTIONS>(dwBreakFlags), &pa));
					return mgd_cast(IVssAsync, pa);
				}
				virtual void DeleteSnapshots(Guid SourceObjectId, VSS_OBJECT_TYPE eSourceObjectType, Boolean bForceDelete, [System::Runtime::InteropServices::Out] Int32% plDeletedSnapshots, [System::Runtime::InteropServices::Out] Guid% pNondeletedSnapshotID)
				{
					LONG dSnap;
					GUID sId;
					Utils::ThrowIfFailed(pNative->DeleteSnapshots(SmartGuid(SourceObjectId), static_cast<::VSS_OBJECT_TYPE>(eSourceObjectType), bForceDelete, &dSnap, &sId));
					plDeletedSnapshots = dSnap;
					pNondeletedSnapshotID = Utils::FromGUID(sId);
				}
				virtual void DisableWriterClasses([In] array<Guid>^ rgWriterClassId)
				{
					if (rgWriterClassId == nullptr || rgWriterClassId->Length == 0)
						return;
					VSS_ID* buf = Utils::ToGUIDArray(rgWriterClassId);
					Utils::ThrowIfFailed(pNative->DisableWriterClasses(buf, rgWriterClassId->Length));
					delete buf;
				}
				virtual void DisableWriterInstances([In] array<Guid>^ rgWriterInstanceId)
				{
					if (rgWriterInstanceId == nullptr || rgWriterInstanceId->Length == 0)
						return;
					VSS_ID* buf = Utils::ToGUIDArray(rgWriterInstanceId);
					Utils::ThrowIfFailed(pNative->DisableWriterInstances(buf, rgWriterInstanceId->Length));
					delete buf;
				}
				virtual IVssAsync^ DoSnapshotSet()
				{
					SafeComPtr<::IVssAsync*> pa;
					Utils::ThrowIfFailed(pNative->DoSnapshotSet(&pa));
					return mgd_cast(IVssAsync, pa);
				}
				virtual void EnableWriterClasses([In] array<Guid>^ rgWriterClassId)
				{
					if (rgWriterClassId == nullptr || rgWriterClassId->Length == 0)
						return;
					VSS_ID* buf = Utils::ToGUIDArray(rgWriterClassId);
					Utils::ThrowIfFailed(pNative->EnableWriterClasses(buf, rgWriterClassId->Length));
					delete buf;
				}
				virtual String^ ExposeSnapshot(Guid SnapshotId, [System::Runtime::InteropServices::Optional] String^ wszPathFromRoot, VSS_VOLUME_SNAPSHOT_ATTRIBUTES lAttributes, [System::Runtime::InteropServices::Optional] String^ wszExpose)
				{
					VSS_PWSZ exp;
					Utils::ThrowIfFailed(pNative->ExposeSnapshot(SmartGuid(SnapshotId), SafeWString(wszPathFromRoot), static_cast<::VSS_VOLUME_SNAPSHOT_ATTRIBUTES>(lAttributes), SafeWString(wszExpose), &exp));
					String^ ret = Marshal::PtrToStringUni(IntPtr(exp));
					CoTaskMemFree(exp);
					return ret;
				}
				virtual IVssAsync^ FastRecovery(Guid SnapshotSetID, [System::Runtime::InteropServices::Optional] UInt32 dwFastRecoveryFlags)
				{
					SafeComPtr<::IVssBackupComponentsEx2*> p = pNative;
					SafeComPtr<::IVssAsync*> pa;
					Utils::ThrowIfFailed(p->FastRecovery(SmartGuid(SnapshotSetID), dwFastRecoveryFlags, &pa));
					return mgd_cast(IVssAsync, pa);
				}
				virtual void FreeWriterMetadata()
				{
					Utils::ThrowIfFailed(pNative->FreeWriterMetadata());
				}
				virtual void FreeWriterStatus()
				{
					Utils::ThrowIfFailed(pNative->FreeWriterStatus());
				}
				virtual IVssAsync^ GatherWriterMetadata()
				{
					SafeComPtr<::IVssAsync*> pa;
					Utils::ThrowIfFailed(pNative->GatherWriterMetadata(&pa));
					return mgd_cast(IVssAsync, pa);
				}
				virtual IVssAsync^ GatherWriterStatus()
				{
					SafeComPtr<::IVssAsync*> pa;
					Utils::ThrowIfFailed(pNative->GatherWriterStatus(&pa));
					return mgd_cast(IVssAsync, pa);
				}
				virtual void GetRootAndLogicalPrefixPaths(String^ pwszFilePath, [System::Runtime::InteropServices::Out] String^% ppwszRootPath, [System::Runtime::InteropServices::Out] String^% ppwszLogicalPrefix, [System::Runtime::InteropServices::Optional] Boolean bNormalizeFQDNforRootPath)
				{
					SafeComPtr<::IVssBackupComponentsEx4*> p = pNative;
					VSS_PWSZ rPath, lPref;
					Utils::ThrowIfFailed(p->GetRootAndLogicalPrefixPaths(SafeWString(pwszFilePath), &rPath, &lPref, bNormalizeFQDNforRootPath));
				}
				virtual Guid GetSessionId()
				{
					SafeComPtr<::IVssBackupComponentsEx3*> p = pNative;
					VSS_ID id;
					Utils::ThrowIfFailed(p->GetSessionId(&id));
					return Utils::FromGUID(id);
				}
				virtual VSS_SNAPSHOT_PROP GetSnapshotProperties(Guid SnapshotId)
				{
					::VSS_SNAPSHOT_PROP prop;
					Utils::ThrowIfFailed(pNative->GetSnapshotProperties(SmartGuid(SnapshotId), &prop));
					return Marshal::PtrToStructure<VSS_SNAPSHOT_PROP>(IntPtr(&prop));
				}
				virtual IVssAsync^ ImportSnapshots()
				{
					SafeComPtr<::IVssAsync*> pa;
					Utils::ThrowIfFailed(pNative->ImportSnapshots(&pa));
					return mgd_cast(IVssAsync, pa);
				}
				virtual void InitializeForBackup([System::Runtime::InteropServices::Optional] String^ bstrXML)
				{
					Utils::ThrowIfFailed(pNative->InitializeForBackup(SafeWString(bstrXML)));
				}
				virtual void InitializeForRestore([System::Runtime::InteropServices::Optional] String^ bstrXML)
				{
					Utils::ThrowIfFailed(pNative->InitializeForRestore(SafeWString(bstrXML)));
				}
				virtual Boolean IsVolumeSupported(Guid ProviderId, String^ pwszVolumeName)
				{
					::BOOL b;
					Utils::ThrowIfFailed(pNative->IsVolumeSupported(SmartGuid(ProviderId), SafeWString(pwszVolumeName), &b));
					return b;
				}
				virtual IVssAsync^ PostRestore()
				{
					SafeComPtr<::IVssAsync*> pa;
					Utils::ThrowIfFailed(pNative->PostRestore(&pa));
					return mgd_cast(IVssAsync, pa);
				}
				virtual IVssAsync^ PreFastRecovery(Guid SnapshotSetID, [System::Runtime::InteropServices::Optional] UInt32 dwPreFastRecoveryFlags)
				{
					SafeComPtr<::IVssBackupComponentsEx2*> p = pNative;
					SafeComPtr<::IVssAsync*> pa;
					Utils::ThrowIfFailed(p->PreFastRecovery(SmartGuid(SnapshotSetID), dwPreFastRecoveryFlags, &pa));
					return mgd_cast(IVssAsync, pa);
				}
				virtual IVssAsync^ PrepareForBackup()
				{
					SafeComPtr<::IVssAsync*> pa;
					Utils::ThrowIfFailed(pNative->PrepareForBackup(&pa));
					return mgd_cast(IVssAsync, pa);
				}
				virtual IVssAsync^ PreRestore()
				{
					SafeComPtr<::IVssAsync*> pa;
					Utils::ThrowIfFailed(pNative->PreRestore(&pa));
					return mgd_cast(IVssAsync, pa);
				}
				virtual IVssEnumObject^ Query(Guid QueriedObjectId, VSS_OBJECT_TYPE eQueriedObjectType, VSS_OBJECT_TYPE eReturnedObjectsType)
				{
					SafeComPtr<::IVssEnumObject*> pa;
					Utils::ThrowIfFailed(pNative->Query(SmartGuid(QueriedObjectId), static_cast<::VSS_OBJECT_TYPE>(eQueriedObjectType), static_cast<::VSS_OBJECT_TYPE>(eReturnedObjectsType), &pa));
					return mgd_cast(IVssEnumObject, pa);
				}
				virtual IVssAsync^ QueryRevertStatus(String^ pwszVolume)
				{
					SafeComPtr<::IVssAsync*> pa;
					Utils::ThrowIfFailed(pNative->QueryRevertStatus(SafeWString(pwszVolume), &pa));
					return mgd_cast(IVssAsync, pa);
				}
				virtual IVssAsync^ RecoverSet(VSS_RECOVERY_OPTIONS dwFlags)
				{
					SafeComPtr<::IVssBackupComponentsEx3*> p = pNative;
					SafeComPtr<::IVssAsync*> pa;
					Utils::ThrowIfFailed(p->RecoverSet(static_cast<::VSS_RECOVERY_OPTIONS>(dwFlags), &pa));
					return mgd_cast(IVssAsync, pa);
				}
				virtual void RevertToSnapshot(Guid SnapshotId, Boolean bForceDismount)
				{
					Utils::ThrowIfFailed(pNative->RevertToSnapshot(SmartGuid(SnapshotId), bForceDismount));
				}
				virtual String^ SaveAsXML()
				{
					SafeBSTR s;
					Utils::ThrowIfFailed(pNative->SaveAsXML(&s));
					return s;
				}
				virtual void SetAdditionalRestores(Guid writerId, VSS_COMPONENT_TYPE ct, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath, String^ wszComponentName, Boolean bAdditionalRestores)
				{
					Utils::ThrowIfFailed(pNative->SetAdditionalRestores(SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(ct), SafeWString(wszLogicalPath), SafeWString(wszComponentName), bAdditionalRestores));
				}
				virtual void SetAuthoritativeRestore(Guid writerId, VSS_COMPONENT_TYPE ct, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath, String^ wszComponentName, Boolean bAuth)
				{
					SafeComPtr<::IVssBackupComponentsEx2*> p = pNative;
					Utils::ThrowIfFailed(p->SetAuthoritativeRestore(SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(ct), SafeWString(wszLogicalPath), SafeWString(wszComponentName), bAuth));
				}
				virtual void SetBackupOptions(Guid writerId, VSS_COMPONENT_TYPE ct, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath, String^ wszComponentName, String^ wszBackupOptions)
				{
					Utils::ThrowIfFailed(pNative->SetBackupOptions(SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(ct), SafeWString(wszLogicalPath), SafeWString(wszComponentName), SafeWString(wszBackupOptions)));
				}
				virtual void SetBackupState(Boolean bSelectComponents, Boolean bBackupBootableSystemState, VSS_BACKUP_TYPE backupType, [System::Runtime::InteropServices::Optional] Boolean bPartialFileSupport)
				{
					Utils::ThrowIfFailed(pNative->SetBackupState(bSelectComponents, bBackupBootableSystemState, static_cast<::VSS_BACKUP_TYPE>(backupType), bPartialFileSupport));
				}
				virtual void SetBackupSucceeded(Guid instanceId, Guid writerId, VSS_COMPONENT_TYPE ct, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath, String^ wszComponentName, Boolean bSucceded)
				{
					Utils::ThrowIfFailed(pNative->SetBackupSucceeded(SmartGuid(instanceId), SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(ct), SafeWString(wszLogicalPath), SafeWString(wszComponentName), bSucceded));
				}
				virtual void SetContext(VSS_SNAPSHOT_CONTEXT lContext)
				{
					Utils::ThrowIfFailed(pNative->SetContext(static_cast<::VSS_SNAPSHOT_CONTEXT>(lContext)));
				}
				virtual void SetFileRestoreStatus(Guid writerId, VSS_COMPONENT_TYPE ct, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath, String^ wszComponentName, VSS_FILE_RESTORE_STATUS status)
				{
					Utils::ThrowIfFailed(pNative->SetFileRestoreStatus(SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(ct), SafeWString(wszLogicalPath), SafeWString(wszComponentName), static_cast<::VSS_FILE_RESTORE_STATUS>(status)));
				}
				virtual void SetPreviousBackupStamp(Guid writerId, VSS_COMPONENT_TYPE ct, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath, String^ wszComponentName, String^ wszPreviousBackupStamp)
				{
					Utils::ThrowIfFailed(pNative->SetPreviousBackupStamp(SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(ct), SafeWString(wszLogicalPath), SafeWString(wszComponentName), SafeWString(wszPreviousBackupStamp)));
				}
				virtual void SetRangesFilePath(Guid writerId, VSS_COMPONENT_TYPE ct, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath, String^ wszComponentName, UInt32 iPartialFile, String^ wszRangesFile)
				{
					Utils::ThrowIfFailed(pNative->SetRangesFilePath(SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(ct), SafeWString(wszLogicalPath), SafeWString(wszComponentName), iPartialFile, SafeWString(wszRangesFile)));
				}
				virtual void SetRestoreName(Guid writerId, VSS_COMPONENT_TYPE ct, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath, String^ wszComponentName, String^ wszRestoreName)
				{
					SafeComPtr<::IVssBackupComponentsEx2*> p = pNative;
					Utils::ThrowIfFailed(p->SetRestoreName(SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(ct), SafeWString(wszLogicalPath), SafeWString(wszComponentName), SafeWString(wszRestoreName)));
				}
				virtual void SetRestoreOptions(Guid writerId, VSS_COMPONENT_TYPE ct, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath, String^ wszComponentName, String^ wszRestoreOptions)
				{
					Utils::ThrowIfFailed(pNative->SetRestoreOptions(SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(ct), SafeWString(wszLogicalPath), SafeWString(wszComponentName), SafeWString(wszRestoreOptions)));
				}
				virtual void SetRestoreState(VSS_RESTORE_TYPE restoreType)
				{
					Utils::ThrowIfFailed(pNative->SetRestoreState(static_cast<::VSS_RESTORE_TYPE>(restoreType)));
				}
				virtual void SetRollForward(Guid writerId, VSS_COMPONENT_TYPE ct, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath, String^ wszComponentName, VSS_ROLLFORWARD_TYPE rollType, String^ wszRollForwardPoint)
				{
					SafeComPtr<::IVssBackupComponentsEx2*> p = pNative;
					Utils::ThrowIfFailed(p->SetRollForward(SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(ct), SafeWString(wszLogicalPath), SafeWString(wszComponentName), static_cast<::VSS_ROLLFORWARD_TYPE>(rollType), SafeWString(wszRollForwardPoint)));
				}
				virtual void SetSelectedForRestore(Guid writerId, VSS_COMPONENT_TYPE ct, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath, String^ wszComponentName, Boolean bSelectedForRestore)
				{
					Utils::ThrowIfFailed(pNative->SetSelectedForRestore(SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(ct), SafeWString(wszLogicalPath), SafeWString(wszComponentName), bSelectedForRestore));
				}
				virtual void SetSelectedForRestoreEx(Guid writerId, VSS_COMPONENT_TYPE ct, [System::Runtime::InteropServices::Optional] String^ wszLogicalPath, String^ wszComponentName, Boolean bSelectedForRestore, [System::Runtime::InteropServices::Optional] Guid instanceId)
				{
					SafeComPtr<::IVssBackupComponentsEx*> p = pNative;
					Utils::ThrowIfFailed(p->SetSelectedForRestoreEx(SmartGuid(writerId), static_cast<::VSS_COMPONENT_TYPE>(ct), SafeWString(wszLogicalPath), SafeWString(wszComponentName), bSelectedForRestore, SmartGuid(instanceId)));
				}
				virtual Guid StartSnapshotSet()
				{
					VSS_ID id;
					Utils::ThrowIfFailed(pNative->StartSnapshotSet(&id));
					return Utils::FromGUID(id);
				}
				virtual void UnexposeSnapshot(Guid snapshotId)
				{
					SafeComPtr<::IVssBackupComponentsEx2*> p = pNative;
					Utils::ThrowIfFailed(p->UnexposeSnapshot(SmartGuid(snapshotId)));
				}

			private:
				IVssWriterComponentsExt^ GetWriterComponents(int i);
				IVssExamineWriterMetadata^ GetWriterMetadata(int i);
				VssWriterStatus GetWriterStatus(int i);

#define DEFINE_BC_ROLIST(prop, itf, ref) \
			private:\
				ListImplBase<itf>^ f##prop;\
				int Get##prop##Count() { UINT c; Utils::ThrowIfFailed(pNative->ref(&c)); return c; }\
			public:\
				property IReadOnlyList<itf>^ prop { virtual IReadOnlyList<itf>^ get() {\
					if (!f##prop) f##prop = gcnew ListImplBase<itf>(gcnew GetCount(this, &CVssBackupComponents::Get##prop##Count), gcnew GetValue<itf>(this, &CVssBackupComponents::Get##prop));\
					return f##prop; } }

				DEFINE_BC_ROLIST(WriterComponents, IVssWriterComponentsExt^, GetWriterComponentsCount)
					DEFINE_BC_ROLIST(WriterMetadata, IVssExamineWriterMetadata^, GetWriterMetadataCount)
					DEFINE_BC_ROLIST(WriterStatus, VssWriterStatus, GetWriterStatusCount)
			};

			value struct VSS_RESTORE_METHOD
			{
			public:
				::VSS_RESTOREMETHOD_ENUM eMethod;
				String^ bstrService;
				String^ bstrUserProcedure;
				::VSS_WRITERRESTORE_ENUM eWriterRestore;
				bool bRebootRequired;
				UINT iMappings;

				VSS_RESTORE_METHOD(::VSS_RESTOREMETHOD_ENUM method, String^ strService, String^ strUserProcedure, ::VSS_WRITERRESTORE_ENUM writerRestore, bool rebootRequired, UINT mappings) :
					eMethod(method), bstrService(strService), bstrUserProcedure(strUserProcedure), eWriterRestore(writerRestore), bRebootRequired(rebootRequired), iMappings(mappings) {}
			};

			ref class CVssExamineWriterMetadata : IVssExamineWriterMetadata, BaseWrapper<::IVssExamineWriterMetadata>
			{
			private:
				VSS_RESTORE_METHOD restoreMethod;
				UINT cIncludeFiles, cExcludeFiles, cComponents;
				ListImplBase<IVssWMFiledesc^>^ fExcludeFromSnapshotFiles;

				int GetExcludeFromSnapshotFilesCount() { SafeComPtr<::IVssExamineWriterMetadataEx2*> p2 = pNative; UINT c; Utils::ThrowIfFailed(p2->GetExcludeFromSnapshotCount(&c)); return c; }
				IVssWMFiledesc^ GetExcludeFromSnapshotFiles(int i) { SafeComPtr<::IVssExamineWriterMetadataEx2*> p2 = pNative; ::IVssWMFiledesc* p; Utils::ThrowIfFailed(p2->GetExcludeFromSnapshotFile(i, &p)); return gcnew CVssWMFiledesc(p); }
				void RefreshRestoreMethod();
				void RefreshFileCounts();

			public:
				CVssExamineWriterMetadata(::IVssExamineWriterMetadata* ptr) : BaseWrapper(ptr) {}

#define DEFINE_EWM_ROLIST(prop, itf, gfunc, cwrap, ref, cexp) \
			private:\
				ListImplBase<itf^>^ f##prop;\
				int Get##prop##Count() { ref(); return cexp; }\
				itf^ Get##prop(int i) { ::itf* p; Utils::ThrowIfFailed(pNative->gfunc(i, &p)); return gcnew cwrap(p); }\
			public:\
				property IReadOnlyList<itf^>^ prop { virtual IReadOnlyList<itf^>^ get() {\
					if (!f##prop) f##prop = gcnew ListImplBase<itf^>(gcnew GetCount(this, &CVssExamineWriterMetadata::Get##prop##Count), gcnew GetValue<itf^>(this, &CVssExamineWriterMetadata::Get##prop));\
					return f##prop; } }

				DEFINE_EWM_ROLIST(AlternateLocationMappings, IVssWMFiledesc, GetAlternateLocationMapping, CVssWMFiledesc, RefreshRestoreMethod, restoreMethod.iMappings)
					DEFINE_EWM_ROLIST(Components, IVssWMComponent, GetComponent, CVssWMComponent, RefreshFileCounts, cComponents)
					DEFINE_EWM_ROLIST(ExcludeFiles, IVssWMFiledesc, GetExcludeFile, CVssWMFiledesc, RefreshFileCounts, cExcludeFiles)
					// DEFINE_EWM_ROLIST(IncludeFiles, IVssWMFiledesc, GetIncludeFile, CVssWMFiledesc, RefreshFileCounts, cIncludeFiles);

			private:

			public:
				DEFINE_WRAPPER_PROP(BackupSchema, VSS_BACKUP_SCHEMA, DWORD, GetBackupSchema);

				property IReadOnlyList<IVssWMFiledesc^>^ ExcludeFromSnapshotFiles { virtual IReadOnlyList<IVssWMFiledesc^>^ get() {
					if (!fExcludeFromSnapshotFiles)
						fExcludeFromSnapshotFiles = gcnew ListImplBase<IVssWMFiledesc^>(gcnew GetCount(this, &CVssExamineWriterMetadata::GetExcludeFromSnapshotFilesCount),
							gcnew GetValue<IVssWMFiledesc^>(this, &CVssExamineWriterMetadata::GetExcludeFromSnapshotFiles));
					return fExcludeFromSnapshotFiles;
				} }

				property Version^ Version { virtual System::Version^ get(); }

				virtual void GetIdentity(Guid% pidInstance, Guid% pidWriter, String^% pbstrWriterName, String^% pbstrInstanceName, VSS_USAGE_TYPE% pUsage,
					VSS_SOURCE_TYPE% pSource);

				virtual void GetRestoreMethod(VSS_RESTOREMETHOD_ENUM% pMethod, System::String^% pbstrService, System::String^% pbstrUserProcedure,
					VSS_WRITERRESTORE_ENUM% pwriterRestore, bool% pbRebootRequired, UInt32% pcMappings);

				virtual void LoadFromXML(String^ bstrXML);

				virtual String^ SaveAsXML();
			};
		}
	}
}