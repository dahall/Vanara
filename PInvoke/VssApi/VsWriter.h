#pragma once
#include "pch.h"
#include <vcclr.h>
#include "CliLists.h"

using namespace System;
using namespace Collections::Generic;
using namespace Runtime::InteropServices;

namespace Vanara { namespace PInvoke { namespace VssApi {

    ///// <summary>Denotes that no maximum space is specified in AddDiffArea or ChangeDiffAreaMaximumSize</summary>
    //public const long VSS_ASSOC_NO_MAX_SPACE = -1;

    ///// <summary>If this constant is specified in ChangeDiffAreaMaximumSize then the association is removed</summary>
    //public const long VSS_ASSOC_REMOVE = 0;

    ref class CVssWMFiledesc : IVssWMFiledesc, BaseWrapper<::IVssWMFiledesc>
    {
    public:
        CVssWMFiledesc(::IVssWMFiledesc* ptr) : BaseWrapper(ptr) {}

        DEFINE_WRAPPER_STRING_PROP(AlternateLocation, GetAlternateLocation)
        DEFINE_WRAPPER_PROP(BackupTypeMask, VSS_FILE_SPEC_BACKUP_TYPE, ::DWORD, GetBackupTypeMask)
        DEFINE_WRAPPER_STRING_PROP(FileSpec, GetFilespec)
        DEFINE_WRAPPER_STRING_PROP(Path, GetPath)
        DEFINE_WRAPPER_PROP(Recursive, bool, bool, GetRecursive)
    };

    ref class CVssWMDependency : IVssWMDependency, BaseWrapper<::IVssWMDependency>
    {
    public:
        CVssWMDependency(::IVssWMDependency* ptr) : BaseWrapper(ptr) {}

        DEFINE_WRAPPER_STRING_PROP(ComponentName, GetComponentName)
        DEFINE_WRAPPER_STRING_PROP(LogicalPath, GetLogicalPath)
        DEFINE_WRAPPER_PROPC(WriterId, Guid, _GUID, GetWriterId, Utils::FromGUID)
    };

    ref class CVssComponent : IVssComponent, BaseWrapper<::IVssComponent>
    {
    public:
        CVssComponent(::IVssComponent* ptr) : BaseWrapper(ptr) {}

        DEFINE_WRAPPER_GS_PROP(RestoreTarget, VSS_RESTORE_TARGET, ::VSS_RESTORE_TARGET)
        DEFINE_WRAPPER_PROP(AdditionalRestores, bool, bool, GetAdditionalRestores)
        DEFINE_WRAPPER_PROP(BackupSucceeded, bool, bool, GetBackupSucceeded)
        DEFINE_WRAPPER_PROP(ComponentType, VSS_COMPONENT_TYPE, ::VSS_COMPONENT_TYPE, GetComponentType)
        DEFINE_WRAPPER_PROP(FileRestoreStatus, VSS_FILE_RESTORE_STATUS, ::VSS_FILE_RESTORE_STATUS, GetFileRestoreStatus)
        DEFINE_WRAPPER_PROP(IsSelectedForRestore, bool, bool, IsSelectedForRestore)
        DEFINE_WRAPPER_QI_PROP(AuthoritativeRestore, bool, bool, GetAuthoritativeRestore, ::IVssComponentEx)
        DEFINE_WRAPPER_STRING_GS_PROP(BackupMetadata)
        DEFINE_WRAPPER_STRING_GS_PROP(BackupStamp)
        DEFINE_WRAPPER_STRING_GS_PROP(PostRestoreFailureMsg)
        DEFINE_WRAPPER_STRING_GS_PROP(PreRestoreFailureMsg)
        DEFINE_WRAPPER_STRING_GS_PROP(RestoreMetadata)
        DEFINE_WRAPPER_STRING_PROP(BackupOptions, GetBackupOptions)
        DEFINE_WRAPPER_STRING_PROP(ComponentName, GetComponentName)
        DEFINE_WRAPPER_STRING_PROP(LogicalPath, GetLogicalPath)
        DEFINE_WRAPPER_STRING_PROP(PreviousBackupStamp, GetPreviousBackupStamp)
        DEFINE_WRAPPER_STRING_PROP(RestoreOptions, GetRestoreOptions)
        DEFINE_WRAPPER_STRING_QI_GS_PROP(PostSnapshotFailureMsg, ::IVssComponentEx)
        DEFINE_WRAPPER_STRING_QI_GS_PROP(PrepareForBackupFailureMsg, ::IVssComponentEx)
        DEFINE_WRAPPER_STRING_QI_PROP(RestoreName, GetRestoreName, ::IVssComponentEx)

        property IReadOnlyList<IVssWMFiledesc^>^ AlternateLocationMappings { virtual IReadOnlyList<IVssWMFiledesc^>^ get(); }
        property IAppendOnlyList<VssDifferencedFile>^ DifferencedFiles { virtual IAppendOnlyList<VssDifferencedFile>^ get(); }
        property IAppendOnlyList<VssDirectedTarget>^ DirectedTargets { virtual IAppendOnlyList<VssDirectedTarget>^ get(); }
        property IReadOnlyList<IVssWMFiledesc^>^ NewTargets { virtual IReadOnlyList<IVssWMFiledesc^>^ get(); }
        property IAppendOnlyList<VssPartialFile>^ PartialFiles { virtual IAppendOnlyList<VssPartialFile>^ get(); }
        property IReadOnlyList<VssRestoreSubcomponent>^ RestoreSubcomponents { virtual IReadOnlyList<VssRestoreSubcomponent>^ get(); }

        virtual void GetFailure(Vanara::PInvoke::HRESULT% phr, Vanara::PInvoke::HRESULT% phrApplication, System::String^% pbstrApplicationMessage);
        virtual void GetRollForward(VSS_ROLLFORWARD_TYPE% pRollType, System::String^% pbstrPoint);
        virtual void SetFailure(Vanara::PInvoke::HRESULT hr, Vanara::PInvoke::HRESULT hrApplication, System::String^ wszApplicationMessage);
    private:
        int GetDifferencedFilesCount() { UINT c; pNative->GetDifferencedFilesCount(&c); return c; }
        int GetDirectedTargetCount() { UINT c; pNative->GetDirectedTargetCount(&c); return c; }
        int GetPartialFileCount() { UINT c; pNative->GetPartialFileCount(&c); return c; }
        int GetRestoreSubcomponentsCount() { UINT c; pNative->GetRestoreSubcomponentCount(&c); return c; }
        VssDifferencedFile GetDifferencedFilesItem(int i);
        VssDirectedTarget GetDirectedTargetItem(int i);
        VssPartialFile GetPartialFileItem(int i);
        VssRestoreSubcomponent GetRestoreSubcomponentsItem(int i);
        void AddDifferencedFile(VssDifferencedFile);
        void AddDirectedTarget(VssDirectedTarget);
        void AddPartialFile(VssPartialFile);
    };

    ref class CVssCreateWriterMetadata : IVssCreateWriterMetadata, IVssCreateWriterMetadataEx, BaseClassWrapper<::IVssCreateWriterMetadata>
    {
    public:
        CVssCreateWriterMetadata(::IVssCreateWriterMetadata* ptr) : BaseClassWrapper(ptr) {}

        virtual void AddAlternateLocationMapping(System::String^ wszSourcePath, System::String^ wszSourceFilespec, bool bRecursive, System::String^ wszDestination)
        {
            Utils::ThrowIfFailed(pNative->AddAlternateLocationMapping(SafeWString(wszSourcePath), SafeWString(wszSourceFilespec), bRecursive, SafeWString(wszDestination)));
        }

        virtual void AddComponent(VSS_COMPONENT_TYPE ct, System::String^ wszLogicalPath, System::String^ wszComponentName,
            System::String^ wszCaption, array<unsigned char, 1>^ pbIcon, bool bRestoreMetadata, bool bNotifyOnBackupComplete, bool bSelectable,
            bool bSelectableForRestore, VSS_COMPONENT_FLAGS dwComponentFlags)
        {
            pin_ptr<unsigned char> pIco = &pbIcon[0];
            Utils::ThrowIfFailed(pNative->AddComponent(static_cast<::VSS_COMPONENT_TYPE>(ct), SafeWString(wszLogicalPath), SafeWString(wszComponentName),
                SafeWString(wszCaption), pIco, pbIcon->Length, bRestoreMetadata, bNotifyOnBackupComplete, bSelectable, bSelectableForRestore, (DWORD)dwComponentFlags));
        }

        virtual void AddComponentDependency(System::String^ wszForLogicalPath, System::String^ wszForComponentName, System::Guid onWriterId,
            System::String^ wszOnLogicalPath, System::String^ wszOnComponentName)
        {
            Utils::ThrowIfFailed(pNative->AddComponentDependency(SafeWString(wszForLogicalPath), SafeWString(wszForComponentName), Utils::ToGUID(onWriterId),
                SafeWString(wszOnLogicalPath), SafeWString(wszOnComponentName)));
        }

        virtual void AddDatabaseFiles(System::String^ wszLogicalPath, System::String^ wszDatabaseName, System::String^ wszPath, System::String^ wszFilespec,
            VSS_FILE_SPEC_BACKUP_TYPE dwBackupTypeMask)
        {
            Utils::ThrowIfFailed(pNative->AddDatabaseFiles(SafeWString(wszLogicalPath), SafeWString(wszDatabaseName), SafeWString(wszPath), SafeWString(wszFilespec), (DWORD)dwBackupTypeMask));
        }

        virtual void AddDatabaseLogFiles(System::String^ wszLogicalPath, System::String^ wszDatabaseName, System::String^ wszPath, System::String^ wszFilespec,
            VSS_FILE_SPEC_BACKUP_TYPE dwBackupTypeMask)
        {
            Utils::ThrowIfFailed(pNative->AddDatabaseLogFiles(SafeWString(wszLogicalPath), SafeWString(wszDatabaseName), SafeWString(wszPath), SafeWString(wszFilespec),
                static_cast<DWORD>(dwBackupTypeMask)));
        }

        virtual void AddExcludeFiles(System::String^ wszPath, System::String^ wszFilespec, bool bRecursive)
        {
            Utils::ThrowIfFailed(pNative->AddExcludeFiles(SafeWString(wszPath), SafeWString(wszFilespec), bRecursive));
        }

        virtual void AddExcludeFilesFromSnapshot(System::String^ wszPath, System::String^ wszFilespec, bool bRecursive)
        {
            ::IVssCreateWriterMetadataEx* p = dynamic_cast<::IVssCreateWriterMetadataEx*>(pNative);
            if (p)
                Utils::ThrowIfFailed(p->AddExcludeFilesFromSnapshot(SafeWString(wszPath), SafeWString(wszFilespec), bRecursive));
        }

        virtual void AddFilesToFileGroup(System::String^ wszLogicalPath, System::String^ wszGroupName, System::String^ wszPath, System::String^ wszFilespec,
            bool bRecursive, System::String^ wszAlternateLocation, VSS_FILE_SPEC_BACKUP_TYPE dwBackupTypeMask)
        {
            Utils::ThrowIfFailed(pNative->AddFilesToFileGroup(SafeWString(wszLogicalPath), SafeWString(wszGroupName), SafeWString(wszPath),
                SafeWString(wszFilespec), bRecursive, SafeWString(wszAlternateLocation), (DWORD)dwBackupTypeMask));
        }

        virtual System::String^ SaveAsXML()
        {
            SafeBSTR xml;
            Utils::ThrowIfFailed(pNative->SaveAsXML(&xml));
            return xml;
        }

        virtual void SetBackupSchema(VSS_BACKUP_SCHEMA dwSchemaMask)
        {
            Utils::ThrowIfFailed(pNative->SetBackupSchema((DWORD)dwSchemaMask));
        }

        virtual void SetRestoreMethod(VSS_RESTOREMETHOD_ENUM method, System::String^ wszService, System::String^ wszUserProcedure,
            VSS_WRITERRESTORE_ENUM writerRestore, bool bRebootRequired)
        {
            Utils::ThrowIfFailed(pNative->SetRestoreMethod(static_cast<::VSS_RESTOREMETHOD_ENUM>(method), SafeWString(wszService), SafeWString(wszUserProcedure),
                static_cast<::VSS_WRITERRESTORE_ENUM>(writerRestore), bRebootRequired));
        }

    };

    ref class CVssExpressWriter : IVssExpressWriter, BaseWrapper<::IVssExpressWriter>
    {
    public:
        CVssExpressWriter(::IVssExpressWriter* ptr) : BaseWrapper(ptr) {}

        virtual IVssCreateExpressWriterMetadata^ CreateMetadata(Guid writerId, String^ writerName, VSS_USAGE_TYPE usageType, unsigned int versionMajor, unsigned int versionMinor)
        {
            SafeComPtr<::IVssCreateExpressWriterMetadata*> meta;
            Utils::ThrowIfFailed(pNative->CreateMetadata(Utils::ToGUID(writerId), SafeWString(writerName), static_cast<::VSS_USAGE_TYPE>(usageType), (DWORD)versionMajor, (DWORD)versionMinor, 0, &meta));
            return (IVssCreateExpressWriterMetadata^)Marshal::GetObjectForIUnknown(IntPtr((::IVssCreateExpressWriterMetadata*)meta));
        }

        virtual void LoadMetadata(System::String^ metadata) { Utils::ThrowIfFailed(pNative->LoadMetadata(SafeWString(metadata), 0)); }

        virtual void Register() { Utils::ThrowIfFailed(pNative->Register()); }

        virtual void Unregister(System::Guid writerId) { Utils::ThrowIfFailed(pNative->Unregister(Utils::ToGUID(writerId))); }
    };

    ref class CVssWriterComponents : IVssWriterComponents, IVssWriterComponentsExt, BaseClassWrapper<::IVssWriterComponents>
    {
    public:
        CVssWriterComponents(::IVssWriterComponents* ptr) : BaseClassWrapper(ptr) {}
        CVssWriterComponents(::IVssWriterComponentsExt* ptr) : BaseClassWrapper(ptr) {}

        virtual property IReadOnlyList<IVssComponent^>^ Components
        {
            IReadOnlyList<IVssComponent^>^ get()
            {
                return gcnew ListImplBase<IVssComponent^>(gcnew GetCount(this, &CVssWriterComponents::GetComponentsCount),
                    gcnew GetValue<IVssComponent^>(this, &CVssWriterComponents::GetComponent));
            }
        }

        virtual void GetWriterInfo(System::Guid% pidInstance, System::Guid% pidWriter)
        {
            VSS_ID inst, wri;
            Utils::ThrowIfFailed(pNative->GetWriterInfo(&inst, &wri));
            pidInstance = Utils::FromGUID(inst);
            pidWriter = Utils::FromGUID(wri);
        }
    private:
        int GetComponentsCount() { UINT c; Utils::ThrowIfFailed(pNative->GetComponentCount(&c)); return c; }
        IVssComponent^ GetComponent(int i);
    };

    interface class IVssWriter
    {
    public:
        virtual Boolean OnIdentify(IN IVssCreateWriterMetadata^ pMetadata) = 0;

        virtual Boolean OnPrepareBackup(_In_ IVssWriterComponents^ pComponent) = 0;

        // callback for prepare snapsot event
        virtual Boolean OnPrepareSnapshot() = 0;

        // callback for freeze event
        virtual Boolean OnFreeze() = 0;

        // callback for thaw event
        virtual Boolean OnThaw() = 0;

        // callback if current sequence is aborted
        virtual Boolean OnAbort() = 0;

        // callback on backup complete event
        virtual Boolean OnBackupComplete(_In_ IVssWriterComponents^ pComponent) = 0;

        // callback indicating that the backup process has either completed or has shut down
        virtual Boolean OnBackupShutdown(_In_ Guid SnapshotSetId) = 0;

        // callback on pre-restore event
        virtual Boolean OnPreRestore(_In_ IVssWriterComponents^ pComponent) = 0;

        // callback on post-restore event
        virtual Boolean OnPostRestore(_In_ IVssWriterComponents^ pComponent) = 0;

        // callback on post snapshot event
        virtual Boolean OnPostSnapshot(_In_ IVssWriterComponents^ pComponent) = 0;

        // callback on back off I/O volume event
        virtual Boolean OnBackOffIOOnVolume(_In_ String^ wszVolumeName, _In_ Guid snapshotId, _In_ Guid providerId) = 0;

        // callback on Continue I/O on volume event
        virtual Boolean OnContinueIOOnVolume(_In_ String^ wszVolumeName, _In_ Guid snapshotId, _In_ Guid providerId) = 0;

        virtual Boolean OnVSSShutdown() = 0;

        virtual Boolean OnVSSApplicationStartup() = 0;

        virtual Boolean OnIdentifyEx(_In_ IVssCreateWriterMetadataEx^ pMetadata) = 0;
    };

    class CVssWriterImpl : public ::CVssWriterEx2
    {
    private:
        gcroot<IVssWriter^> host;
    public:
        CVssWriterImpl(IVssWriter^ h) : host(h) {}

        bool STDMETHODCALLTYPE OnIdentify(IN ::IVssCreateWriterMetadata* pMetadata)
        {
            return host->OnIdentify(gcnew CVssCreateWriterMetadata(pMetadata));
        }

        bool STDMETHODCALLTYPE OnPrepareBackup(_In_ ::IVssWriterComponents* pComponent)
        {
            return host->OnPrepareBackup((IVssWriterComponents^)Marshal::GetObjectForIUnknown(IntPtr((void*)pComponent)));
        }

        bool STDMETHODCALLTYPE OnPrepareSnapshot()
        {
            return host->OnPrepareSnapshot();
        }

        bool STDMETHODCALLTYPE OnFreeze()
        {
            return host->OnFreeze();
        }

        bool STDMETHODCALLTYPE OnThaw()
        {
            return host->OnThaw();
        }

        bool STDMETHODCALLTYPE OnAbort()
        {
            return host->OnAbort();
        }

        bool STDMETHODCALLTYPE OnBackupComplete(_In_ ::IVssWriterComponents* pComponent)
        {
            return host->OnBackupComplete((IVssWriterComponents^)Marshal::GetObjectForIUnknown(IntPtr((void*)pComponent)));
        }

        bool STDMETHODCALLTYPE OnBackupShutdown(_In_ VSS_ID SnapshotSetId)
        {
            return host->OnBackupShutdown(Utils::FromGUID(SnapshotSetId));
        }

        bool STDMETHODCALLTYPE OnPreRestore(_In_ ::IVssWriterComponents* pComponent)
        {
            return host->OnPreRestore((IVssWriterComponents^)Marshal::GetObjectForIUnknown(IntPtr((void*)pComponent)));
        }

        bool STDMETHODCALLTYPE OnPostRestore(_In_ ::IVssWriterComponents* pComponent)
        {
            return host->OnPostRestore((IVssWriterComponents^)Marshal::GetObjectForIUnknown(IntPtr((void*)pComponent)));
        }

        bool STDMETHODCALLTYPE OnPostSnapshot(_In_ ::IVssWriterComponents* pComponent)
        {
            return host->OnPostSnapshot((IVssWriterComponents^)Marshal::GetObjectForIUnknown(IntPtr((void*)pComponent)));
        }

        bool STDMETHODCALLTYPE OnBackOffIOOnVolume(_In_ VSS_PWSZ wszVolumeName, _In_ VSS_ID snapshotId, _In_ VSS_ID providerId)
        {
            return host->OnBackOffIOOnVolume(SafeBSTR(wszVolumeName), Utils::FromGUID(snapshotId), Utils::FromGUID(providerId));
        }

        bool STDMETHODCALLTYPE OnContinueIOOnVolume(_In_ VSS_PWSZ wszVolumeName, _In_ VSS_ID snapshotId, _In_ VSS_ID providerId)
        {
            return host->OnContinueIOOnVolume(SafeBSTR(wszVolumeName), Utils::FromGUID(snapshotId), Utils::FromGUID(providerId));
        }

        bool STDMETHODCALLTYPE OnVSSShutdown()
        {
            return host->OnVSSShutdown();
        }

        bool STDMETHODCALLTYPE OnVSSApplicationStartup()
        {
            return host->OnVSSApplicationStartup();
        }

        bool STDMETHODCALLTYPE OnIdentifyEx(_In_::IVssCreateWriterMetadataEx* pMetadata)
        {
            return host->OnIdentifyEx(gcnew CVssCreateWriterMetadata(pMetadata));
        }
    };

    public ref class CVssWriter : public IVssWriter
    {
    private:
        CVssWriterImpl* pNative;

    protected:
        // Constructors & Destructors
        STDMETHODCALLTYPE CVssWriter() : pNative(new CVssWriterImpl(this)) {}

        virtual STDMETHODCALLTYPE ~CVssWriter()
        {
            if (pNative != NULL)
            {
                delete pNative;
                pNative = NULL;
            }
        }

    public:

        /// <summary>Returns the writer's session identifier.</summary>
        /// <param name="idSession">A pointer to a variable that receives the session identifier.</param>
        /// <remarks>
        /// <para>
        /// The session identifier is an opaque value that uniquely identifies a backup or restore session. It is used to distinguish the
        /// current session among multiple parallel backup or restore sessions.
        /// </para>
        /// <para>
        /// As a best practice, writers and requesters should include the session ID in all diagnostics messages used for event logging and tracing.
        /// </para>
        /// <para>
        /// If a writer's event handler (such as CVssWriter::OnFreeze) calls this method, it must do so in the same thread that called the
        /// event handler. For more information, see Writer Event Handling.
        /// </para>
        /// </remarks>
        void GetSessionId([Out] Guid% idSession)
        {
            VSS_ID id;
            Utils::ThrowIfFailed(pNative->GetSessionId(&id));
            idSession = Utils::FromGUID(id);
        }

        /// <summary>
        /// <para>Initializes a CVssWriter object and allows a writer application to interact with VSS.</para>
        /// <para><c>Initialize</c> is a public method implemented by the CVssWriter base class.</para>
        /// </summary>
        /// <param name="WriterId">The globally unique identifier (GUID) of the writer class.</param>
        /// <param name="wszWriterName">
        /// A <c>null</c>-terminated wide character string that contains the name of the writer. This string is not localized.
        /// </param>
        /// <param name="ut">A VSS_USAGE_TYPE enumeration value that indicates how the data managed by the writer is used on the host system.</param>
        /// <param name="st">A VSS_SOURCE_TYPE enumeration value that indicates the type of data managed by the writer.</param>
        /// <param name="nLevel">
        /// <para>
        /// A VSS_APPLICATION_LEVEL enumeration value that indicates the application level at which the writer receives a Freeze event notification.
        /// </para>
        /// <para>The default value for this parameter is VSS_APP_FRONT_END.</para>
        /// </param>
        /// <param name="dwTimeoutFreeze">
        /// <para>
        /// The maximum permitted time, in milliseconds, between a writer's receipt of a Freeze event notification and the receipt of a
        /// matching Thaw event notification from VSS. After the time-out expires, the writer's CVssWriter::OnAbort method is called automatically.
        /// </para>
        /// <para>The default value for this parameter is 60000.</para>
        /// </param>
        /// <param name="aws">
        /// <para>A VSS_ALTERNATE_WRITER_STATE enumeration value that indicates whether the writer has an associated alternate writer.</para>
        /// <para>
        /// The default value for this parameter is VSS_AWS_NO_ALTERNATE_WRITER. The caller should not override this default value. This
        /// parameter is reserved for future use.
        /// </para>
        /// </param>
        /// <param name="bIOThrottlingOnly">
        /// <para>Set this parameter to <c>true</c> if I/O throttling methods are enabled, or <c>false</c> otherwise.</para>
        /// <para>
        /// The default value for this parameter is <c>false</c>. The caller should not override this default value. This parameter is
        /// reserved for future use.
        /// </para>
        /// </param>
        /// <param name="wszWriterInstanceName">
        /// <para>A <c>null</c>-terminated wide character string that contains the writer instance name.</para>
        /// <para>
        /// The default value for this parameter is <c>NULL</c>. If the writer has multiple instances and requires restore events, this
        /// parameter is required and cannot be <c>NULL</c>. For details, see the following Remarks section.
        /// </para>
        /// <para>
        /// <c>Windows Server 2003 and Windows XP:</c> Before Windows Server 2003 with SP1, this parameter is reserved for system use, and
        /// the caller should not override the default value.
        /// </para>
        /// </param>
        /// <remarks>
        /// <para>
        /// VSS assigns a unique writer instance ID to each instance of a writer application. If more than one instance is present on the
        /// system at the same time (for example, if multiple SQL servers are running on a system), each writer is uniquely identified by
        /// the combination of its writer class ID and its writer instance ID.
        /// </para>
        /// <para>
        /// The <c>wszWriterInstanceName</c> parameter allows a multi-instance writer to specify a persistent name for each writer instance
        /// as a human-readable string. This name must be unique across all instances of the writer on the system. If a writer has multiple
        /// instances and requires restore events, it must specify a non- <c>NULL</c> string for this parameter. VSS uses the instance name
        /// to correctly restore multi-instance writers.
        /// </para>
        /// </remarks>
        void Initialize(Guid WriterId, String^ wszWriterName, VSS_USAGE_TYPE ut, VSS_SOURCE_TYPE st, VSS_APPLICATION_LEVEL nLevel,
            UInt32 dwTimeoutFreeze, VSS_ALTERNATE_WRITER_STATE aws, [Optional] bool bIOThrottlingOnly, [Optional] String^ wszWriterInstanceName)
        {
            if (pNative != NULL)
                throw gcnew InvalidOperationException("Initialize has already been called.");
            Utils::ThrowIfFailed(pNative->Initialize(SmartGuid(WriterId), SafeWString(wszWriterName), (::VSS_USAGE_TYPE)ut, (::VSS_SOURCE_TYPE)st,
                (::VSS_APPLICATION_LEVEL)nLevel, dwTimeoutFreeze, (::VSS_ALTERNATE_WRITER_STATE)aws, bIOThrottlingOnly, SafeWString(wszWriterInstanceName)));
        }

        /// <summary>
        /// <para>
        /// Initializes a CVssWriterEx object and allows a writer application to interact with VSS. Unlike the Initialize method, the
        /// <c>InitializeEx</c> method allows the caller to specify writer version information.
        /// </para>
        /// <para><c>InitializeEx</c> is a public method implemented by the CVssWriterEx base class.</para>
        /// <para>Writers must call Initialize or <c>InitializeEx</c>, but not both.</para>
        /// </summary>
        /// <param name="WriterId">The globally unique identifier (GUID) of the writer class.</param>
        /// <param name="wszWriterName">
        /// A <c>null</c>-terminated wide character string that contains the name of the writer. This string is not localized.
        /// </param>
        /// <param name="dwMajorVersion">The major version of the writer application. For more information, see the Remarks section.</param>
        /// <param name="dwMinorVersion">The minor version of the writer application. For more information, see the Remarks section.</param>
        /// <param name="ut">
        /// A VSS_USAGE_TYPE enumeration value that indicates how the data that is managed by the writer is used on the host system.
        /// </param>
        /// <param name="st">A VSS_SOURCE_TYPE enumeration value that indicates the type of data that is managed by the writer.</param>
        /// <param name="nLevel">
        /// <para>
        /// A VSS_APPLICATION_LEVEL enumeration value that indicates the application level at which the writer receives a Freeze event notification.
        /// </para>
        /// <para>The default value for this parameter is VSS_APP_FRONT_END.</para>
        /// </param>
        /// <param name="dwTimeoutFreeze">
        /// <para>
        /// The maximum permitted time, in milliseconds, between the writer's receipt of a Freeze event notification and its receipt of a
        /// matching Thaw event notification from VSS. After the time-out expires, the writer's OnAbort method is called automatically.
        /// </para>
        /// <para>The default value for this parameter is 60000.</para>
        /// </param>
        /// <param name="aws">
        /// <para>A VSS_ALTERNATE_WRITER_STATE enumeration value that indicates whether the writer has an associated alternate writer.</para>
        /// <para>
        /// The default value for this parameter is VSS_AWS_NO_ALTERNATE_WRITER. The caller should not override this default value. This
        /// parameter is reserved for future use.
        /// </para>
        /// </param>
        /// <param name="bIOThrottlingOnly">
        /// <para>Set this parameter to <c>true</c> if I/O throttling methods are enabled, or <c>false</c> otherwise.</para>
        /// <para>
        /// The default value for this parameter is <c>false</c>. The caller should not override this default value. This parameter is
        /// reserved for future use.
        /// </para>
        /// </param>
        /// <param name="wszWriterInstanceName">
        /// <para>A <c>null</c>-terminated wide character string that contains the writer instance name.</para>
        /// <para>
        /// The default value for this parameter is <c>NULL</c>. If the writer has multiple instances and requires restore events, this
        /// parameter is required and cannot be <c>NULL</c>. For more information, see the following Remarks section.
        /// </para>
        /// </param>
        /// <remarks>
        /// <para>
        /// The <c>InitializeEx</c> method is identical to the Initialize method except for the <c>dwMajorVersion</c> and
        /// <c>dwMinorVersion</c> parameters. If the writer uses <c>Initialize</c> instead of <c>InitializeEx</c>, the writer version will
        /// be reported as 0.0 (major version = 0, minor version = 0) by the IVssExamineWriterMetadataEx2::GetVersion method.
        /// </para>
        /// <para>
        /// The <c>dwMajorVersion</c> and <c>dwMinorVersion</c> parameters are used to specify the writer major and minor version numbers
        /// according to the following VSS conventions:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <term>
        /// If the writer has changed since Windows XP or is new for Windows Vista, it should specify 1.0 or higher for its version number.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// A writer's minor version number should be incremented by one whenever a released version of the writer contains minor changes
        /// that affect the writer's interaction with requesters. For example, a correction to a file specification in a writer QFE or
        /// service pack would justify incrementing the minor version number. However, a change between beta or release candidate versions
        /// of a writer would not justify the changing of the minor version number.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// A writer's major version number should be incremented by one whenever a released version of the writer contains a significant
        /// change. For example, if data that is backed up with a new version of a writer cannot be restored using the previous version of
        /// the writer, the new writer's major version number should be incremented.
        /// </term>
        /// </item>
        /// <item>
        /// <term>Whenever the major version number is incremented, the minor version number should be reset to zero.</term>
        /// </item>
        /// </list>
        /// <para>If a writer does not specify a version number, VSS will assign a default version number of 0.0.</para>
        /// <para>
        /// VSS assigns a unique writer instance ID to each instance of a writer application. If more than one instance is present on the
        /// system at the same time (for example, if multiple SQL servers are running on a system), each writer is uniquely identified by
        /// the combination of its writer class ID and its writer instance ID.
        /// </para>
        /// <para>
        /// The <c>wszWriterInstanceName</c> parameter allows a multi-instance writer to specify a persistent name for each writer instance
        /// as a human-readable string. This name must be unique across all instances of the writer on the system. If a writer has multiple
        /// instances and requires restore events, it must specify a non- <c>NULL</c> string for this parameter. VSS uses the instance name
        /// to correctly restore multi-instance writers.
        /// </para>
        /// </remarks>
        void InitializeEx(Guid WriterId, String^ wszWriterName, UInt32 dwMajorVersion, UInt32 dwMinorVersion, VSS_USAGE_TYPE ut,
            VSS_SOURCE_TYPE st, VSS_APPLICATION_LEVEL nLevel, UInt32 dwTimeoutFreeze, VSS_ALTERNATE_WRITER_STATE aws,
            [Optional] bool bIOThrottlingOnly, [Optional] String^ wszWriterInstanceName)
        {
            if (pNative != NULL)
                throw gcnew InvalidOperationException("Initialize has already been called.");
            Utils::ThrowIfFailed(pNative->InitializeEx(SmartGuid(WriterId), SafeWString(wszWriterName), dwMajorVersion, dwMinorVersion, (::VSS_USAGE_TYPE)ut, (::VSS_SOURCE_TYPE)st,
                (::VSS_APPLICATION_LEVEL)nLevel, dwTimeoutFreeze, (::VSS_ALTERNATE_WRITER_STATE)aws, bIOThrottlingOnly, SafeWString(wszWriterInstanceName)));
        }

        ///// <summary>
        ///// <para>Not supported.</para>
        ///// <para>This method is reserved for future use.</para>
        ///// </summary>
        ///// <param name="writerId">This parameter is reserved for future use.</param>
        ///// <param name="persistentWriterClassId">This parameter is reserved for future use.</param>
        //// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-cvsswriter-installalternatewriter
        //// HRESULT InstallAlternateWriter( VSS_ID writerId, CLSID persistentWriterClassId );
        //void InstallAlternateWriter(Guid writerId, Guid persistentWriterClassId)
        //{
        //    Utils::ThrowIfFailed(pNative->InstallAlternateWriter(SmartGuid(writerId), SmartGuid(persistentWriterClassId)));
        //}

        /// <summary>Determines whether the writer is shutting down.</summary>
        /// <returns>Returns <c>true</c> if the writer is shutting down, or <c>false</c> otherwise.</returns>
        /// <remarks>
        /// <para>
        /// The writer implementation should call this method periodically during long-running events where the writer is performing a large
        /// amount of processing or looping. If this method returns <c>true</c> during the event, the writer should do the following:
        /// </para>
        /// <list type="number">
        /// <item>
        /// <term>Log an error to the Application Event Log event. This is optional, but recommended.</term>
        /// </item>
        /// <item>
        /// <term>Call SetWriterFailure or SetWriterFailureEx, passing a non-retryable error code for the <c>hr</c> or <c>hrWriter</c> parameter.</term>
        /// </item>
        /// </list>
        /// </remarks>
        Boolean IsWriterShuttingDown()
        {
            return pNative->IsWriterShuttingDown();
        }

        /// <summary>
        /// <para>The <c>OnIdentify</c> method is called by a writer following receipt of an Identify event.</para>
        /// <para>
        /// <c>OnIdentify</c> is a virtual method. It is implemented by the CVssWriter base class, but can be overridden by derived classes.
        /// </para>
        /// </summary>
        /// <param name="pMetadata">A pointer to an IVssCreateWriterMetadata object used to construct the writer's metadata.</param>
        /// <returns>
        /// <para>As implemented by the base class, <c>OnIdentify</c> always returns <c>true</c>.</para>
        /// <para>
        /// Any other implementation of this method must return <c>true</c> except in the case of a fatal error. If a fatal error occurs,
        /// the method should return <c>false</c>.
        /// </para>
        /// <para>
        /// In all cases when a failure occurs, including nonfatal errors, the method should write a detailed entry to the event log to
        /// report the exact reason for the failure.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The default implementation of this method by the CVssWriter base class returns <c>true</c> without performing any other operation.
        /// </para>
        /// <para>Writers should never throw an exception from this method or any other <c>CVssWriter(Ex)::On <c>Xxx</c></c> callback method.</para>
        /// <para>
        /// Writers should never call the CVssWriter::SetWriterFailure method from the <c>OnIdentify</c> or CVssWriterEx::OnIdentifyEx method.
        /// </para>
        /// <para>
        /// If this method calls the CVssWriterEx2::GetSessionId method, it must do so in the same thread that called this method. For more
        /// information, see Writer Event Handling.
        /// </para>
        /// <para>
        /// In response to an Identify event generated by another application, a writer uses the <c>OnIdentify</c> handler to create a
        /// Writer Metadata Document containing information about the components it manages using the IVssCreateWriterMetadata interface.
        /// </para>
        /// <para>
        /// The application that generated the Identify event then retrieves the Writer Metadata Document and examines the writer's
        /// component information using the IVssExamineWriterMetadata interface.
        /// </para>
        /// <para>
        /// An Identify event is required before the events that make up a backup or restore sequence. Therefore, <c>OnIdentify</c> is
        /// perhaps most typically invoked to handle an Identify event in response to a requester's call to
        /// IVssBackupComponents::GatherWriterMetadata as part of a backup or restore operation.
        /// </para>
        /// <para>
        /// However, an Identify event is not itself part of the sequence of events that makes up a backup or restore and the VSS service
        /// does not prevent its generation, even while a backup or restore sequence is in progress. For instance, VSS management
        /// applications use the Identify event to determine and display the state of the writers on the system.
        /// </para>
        /// <para>This being the case, writers should never use their implementation of <c>OnIdentify</c> in the following ways:</para>
        /// <list type="bullet">
        /// <item>
        /// <term>As the beginning of their handling of a backup or restore</term>
        /// </item>
        /// <item>
        /// <term>To set or maintain information about the writer's state</term>
        /// </item>
        /// </list>
        /// <para>See Writer Event Handling for more information on writer interactions with events.</para>
        /// <para>The life cycle of the IVssCreateWriterMetadata object passed into <c>OnIdentify</c> is managed by the VSS infrastructure.</para>
        /// </remarks>
        virtual Boolean OnIdentify(IN IVssCreateWriterMetadata^ pMetadata)
        {
            UNREFERENCED_PARAMETER(pMetadata);
            return true;
        }

        /// <summary>
        /// <para>Returns a pointer to an IVssCreateWriterMetadataEx object.</para>
        /// <para><c>OnIdentifyEx</c> is a virtual method. It is implemented by the CVssWriterEx base class, but can be overridden by derived classes.</para>
        /// </summary>
        /// <param name="pMetadata">A pointer to an IVssCreateWriterMetadataEx object.</param>
        /// <returns>
        /// <para>As implemented by the base class, <c>OnIdentifyEx</c> always returns <c>true</c>.</para>
        /// <para>Any other implementation of this method must return <c>true</c> except in the case of a fatal error. If a fatal error occurs, the method should return <c>false</c>.</para>
        /// <para>In all cases when a failure occurs, including nonfatal errors, the method should write a detailed entry to the event log to report the exact reason for the failure.</para>
        /// </returns>
        /// <remarks>
        /// <para>The <c>OnIdentifyEx</c> method is identical to the OnIdentify method, except that it returns an IVssCreateWriterMetadataEx interface pointer instead of an IVssCreateWriterMetadata interface pointer in the <c>pMetadata</c> parameter. A writer can override <c>OnIdentify</c> or <c>OnIdentifyEx</c>, but not both.</para>
        /// <para>Writers should never throw an exception from this method or any other <c>CVssWriter(Ex)::On<c>Xxx</c></c> callback method.</para>
        /// <para>Writers should never call the CVssWriter::SetWriterFailure method from the OnIdentify or <c>OnIdentifyEx</c> method.</para>
        /// <para>If this method calls the CVssWriterEx2::GetSessionId method, it must do so in the same thread that called this method. For more information, see Writer Event Handling.</para>
        /// <para>In response to an Identify event that is generated by another application, a writer calls <c>OnIdentifyEx</c> to create a Writer Metadata Document that contains information about the components it manages using the IVssCreateWriterMetadataEx interface.</para>
        /// <para>The application that generated the Identify event then retrieves the Writer Metadata Document and examines the writer's component information using the IVssExamineWriterMetadata interface.</para>
        /// <para>An Identify event is required before the events that make up a backup or restore sequence. Therefore, <c>OnIdentifyEx</c> is typically called to handle an <c>Identify</c> event in response to a requester's call to IVssBackupComponents::GatherWriterMetadata as part of a backup or restore operation.</para>
        /// <para>However, an Identify event by itself is not part of the sequence of events that make up a backup or restore sequence, and the VSS service does not prevent <c>Identify</c> events from being generated, even while a backup or restore sequence is in progress. For example, VSS management applications use the <c>Identify</c> event to determine and display the state of the writers on the system.</para>
        /// <para>For this reason, writers should never use their implementation of <c>OnIdentifyEx</c> in any of the following ways:</para>
        /// <list type="bullet">
        /// <item>
        /// <term>As the beginning of their handling of a backup or restore sequence</term>
        /// </item>
        /// <item>
        /// <term>To set or maintain information about the writer's state</term>
        /// </item>
        /// </list>
        /// <para>For more information about writer interactions with events, see Writer Event Handling.</para>
        /// <para>During the PrepareForBackup, PrepareForSnapshot, and PostSnapshot events, a writer can use the GetIdentifyInformation method to get the metadata that the writer's <c>OnIdentifyEx</c> method previously reported.</para>
        /// <para>The life cycle of the IVssCreateWriterMetadataEx object that the <c>pMetadata</c> parameter points to is managed by the VSS infrastructure.</para>
        /// </remarks>
        virtual Boolean OnIdentifyEx(_In_ IVssCreateWriterMetadataEx^ pMetadata)
        {
            UNREFERENCED_PARAMETER(pMetadata);
            return false;
        }

        /// <summary>
        /// <para>The <c>OnPrepareBackup</c> method is called by a writer following a PrepareForBackup event. This method is used to configure a writer's state and its components in preparation for a backup operation.</para>
        /// <para><c>OnPrepareBackup</c> is a virtual method. It is implemented by the CVssWriter base class, but can be overridden by derived classes.</para>
        /// </summary>
        /// <param name="pComponent">Pointer to an instantiation of an IVssWriterComponents object containing the contents of the Writer Metadata Document. The value of this parameter may be <c>NULL</c> if the requester does not support components (if CVssWriter::AreComponentsSelected returns <c>false</c>).</param>
        /// <returns>
        /// <para>As implemented by the base class, <c>OnPrepareBackup</c> always returns <c>true</c>.</para>
        /// <para>Any other implementation of this method must return <c>true</c> except in the case of a fatal error. If a fatal error occurs, the method must call the CVssWriter::SetWriterFailure method to provide a description of the failure before returning <c>false</c>. If a nonfatal error occurs, the method should still call <c>SetWriterFailure</c> but return <c>true</c>. If the error is caused by a transient problem, the method should specify VSS_E_WRITERERROR_RETRYABLE in the call to <c>SetWriterFailure</c>.</para>
        /// <para>In all cases when a failure occurs, the method should write an event to the event log to report the exact reason for the failure.</para>
        /// </returns>
        /// <remarks>
        /// <para>The default implementation of this method by the CVssWriter base class returns <c>true</c> without performing any other operation.</para>
        /// <para><c>OnPrepareBackup</c> provides a writer an opportunity to more finely select what will be backed up.</para>
        /// <para>Handling the PrepareForBackup event is the last opportunity for a writer to get access to metadata contained in the Backup Components Document prior to the shadow copy's creation.</para>
        /// <para>Therefore, <c>OnPrepareBackup</c> provides an opportunity for the writer to make any final additions or updates to stored component information (using the IVssComponent interface). In particular, writer-specific metadata can be updated by IVssComponent::SetBackupMetadata or IVssComponent::SetRestoreMetadata.</para>
        /// <para>In addition, while handling the PrepareForSnapshot event provides another opportunity in the life cycle of a VSS backup operation to perform time-consuming operations (such as synchronizing data across multiple sites), <c>OnPrepareBackup</c> provides a chance for the writer to start such an operation asynchronously. Tasks like these must be completed prior to the return of CVssWriter::OnPrepareSnapshot.</para>
        /// <para>Writers should never throw an exception from this method or any other <c>CVssWriter(Ex)::On<c>Xxx</c></c> callback method.</para>
        /// <para>A requester generates a PrepareForBackup event, triggering a call to <c>OnPrepareBackup</c>, by calling <c>IVssBackupComponents::PrepareForBackup</c>.</para>
        /// <para>If this method calls the CVssWriterEx2::GetSessionId, CVssWriter::SetWriterFailure, or CVssWriterEx2::SetWriterFailureEx method, it must do so in the same thread that called this method. For more information, see Writer Event Handling.</para>
        /// </remarks>
        virtual Boolean OnPrepareBackup(_In_ IVssWriterComponents^ pComponent)
        {
            UNREFERENCED_PARAMETER(pComponent);
            return true;
        }

        /// <summary>
        /// <para>The <c>OnPrepareSnapshot</c> method is called by a writer to handle a PrepareForSnapshot event. It is used to perform operations needed to prepare a writer to participate in the shadow copy or to veto a shadow copy.</para>
        /// <para><c>OnPrepareSnapshot</c> is a pure virtual method. It is not implemented by the CVssWriter base class, and must be implemented by derived classes.</para>
        /// </summary>
        /// <returns>
        /// <para>The implementation of this method must return <c>true</c> except in the case of a fatal error. If a fatal error occurs, the method must call the CVssWriter::SetWriterFailure method to provide a description of the failure before returning <c>false</c>. If a nonfatal error occurs, the method should still call <c>SetWriterFailure</c> but return <c>true</c>. If the error is caused by a transient problem, the method should specify VSS_E_WRITERERROR_RETRYABLE in the call to <c>SetWriterFailure</c>.</para>
        /// <para>In all cases when a failure occurs, the method should write an event to the event log to report the exact reason for the failure.</para>
        /// </returns>
        /// <remarks>
        /// <para>The <c>OnPrepareSnapshot</c> method performs operations that are required prior to any shadow copy freeze.</para>
        /// <para>The time-out window for handling a PrepareForSnapshot event is typically longer than that for handling a Freeze event. Therefore, developers can use <c>OnPrepareSnapshot</c> to handle more time-consuming operations. A typical use might be for the writer to explicitly checkpoint its data.</para>
        /// <para>Writers should never throw an exception from this method or any other <c>CVssWriter(Ex)::On<c>Xxx</c></c> callback method.</para>
        /// <para>If this method calls the CVssWriterEx2::GetSessionId, CVssWriter::SetWriterFailure, or CVssWriterEx2::SetWriterFailureEx method, it must do so in the same thread that called this method. For more information, see Writer Event Handling.</para>
        /// </remarks>
        // https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-cvsswriter-onpreparesnapshot
        // Platform::Boolean OnPrepareSnapshot();
        virtual Boolean OnPrepareSnapshot() = 0;

        /// <summary>
        /// <para>The <c>OnFreeze</c> method is called by a writer on receipt of a Freeze event at the start of a shadow copy freeze. A writer uses this method to perform operations needed to participate in the freeze or to veto the freeze.</para>
        /// <para><c>OnFreeze</c> is a pure virtual method. It is not implemented by the CVssWriter base class, and must be implemented by derived classes.</para>
        /// </summary>
        /// <returns>
        /// <para>The implementation of this method must return <c>true</c> except in the case of a fatal error. If a fatal error occurs, the method must call the CVssWriter::SetWriterFailure method to provide a description of the failure before returning <c>false</c>. If a nonfatal error occurs, the method should still call <c>SetWriterFailure</c> but return <c>true</c>. If the error is caused by a transient problem, the method should specify VSS_E_WRITERERROR_RETRYABLE in the call to <c>SetWriterFailure</c>.</para>
        /// <para>In all cases when a failure occurs, the method should write an event to the event log to report the exact reason for the failure.</para>
        /// </returns>
        /// <remarks>
        /// <para>In this method, the writer application should put itself into a well-defined state that is compatible with the VSS operation.</para>
        /// <para>In this method, the writer should complete final preparations to support the creation of a shadow copy. Once the shadow copy is created, the writer will receive the Thaw event and can continue normal operations.</para>
        /// <para>By default, the time-out window between Freeze and Thaw events is 60 seconds. That is, if a Thaw event is not received with the time-out window, an Abort event will be generated. Writers can change the time-out window at initialization time by setting the <c>dwTimeoutFreeze</c> argument to CVssWriter::Initialize.</para>
        /// <para>How a writer prepares for a shadow copy is highly dependent on the application that hosts it. Some applications can afford to hold all writes and keep the data in an absolute consistent state for this period. Other applications, like many databases, cannot stop work during this period but can take actions, such as checkpointing their state, which may reduce the recovery time for a shadow copy created during this window.</para>
        /// <para>If the writer cannot put itself into a well-defined state for the Freeze, the following happens:</para>
        /// <list type="number">
        /// <item>
        /// <term><c>OnFreeze</c> should return <c>false</c>, vetoing the shadow copy.</term>
        /// </item>
        /// <item>
        /// <term>The writer calls CVssWriter::SetWriterFailure to provide a description of the failure.</term>
        /// </item>
        /// <item>
        /// <term>An Abort event will be generated upon <c>OnFreeze</c> return of <c>false</c></term>
        /// </item>
        /// </list>
        /// <para>Writers should never throw an exception from this method or any other <c>CVssWriter(Ex)::On<c>Xxx</c></c> callback method.</para>
        /// <para>The time-out window for handling the Freeze event is typically relatively short as compared to that for handling the PrepareForSnapshot event. Therefore, developers should avoid lengthy operations in this method. A typical use might be to suspend logging by the writer.</para>
        /// <para>It is recommended that all time-consuming operations be handled by CVssWriter::OnPrepareSnapshot.</para>
        /// <para>Either CVssWriter::OnThaw or CVssWriter::OnAbort will be called after this method.</para>
        /// <para>If this method calls the CVssWriterEx2::GetSessionId, CVssWriter::SetWriterFailure, or CVssWriterEx2::SetWriterFailureEx method, it must do so in the same thread that called this method. For more information, see Writer Event Handling.</para>
        /// </remarks>
        virtual Boolean OnFreeze() = 0;

        /// <summary>
        /// <para>The <c>OnThaw</c> method is called by a writer following a Thaw event.</para>
        /// <para><c>OnThaw</c> is a pure virtual method. It is not implemented by the CVssWriter base class, and must be implemented by derived classes.</para>
        /// </summary>
        /// <returns>
        /// <para>The implementation of this method must return <c>true</c> except in the case of a fatal error. If a fatal error occurs, the method must call the CVssWriter::SetWriterFailure method to provide a description of the failure before returning <c>false</c>. If a nonfatal error occurs, the method should still call <c>SetWriterFailure</c> but return <c>true</c>. If the error is caused by a transient problem, the method should specify VSS_E_WRITERERROR_RETRYABLE in the call to <c>SetWriterFailure</c>.</para>
        /// <para>In all cases when a failure occurs, the method should write an event to the event log to report the exact reason for the failure.</para>
        /// </returns>
        /// <remarks>
        /// <para>This method is called at the end of a shadow copy freeze when writers can begin to modify data on disk again.</para>
        /// <para><c>OnThaw</c> is used to return the writer to normal operation, typically reversing actions taken during CVssWriter::OnPrepareSnapshot and CVssWriter::OnFreeze.</para>
        /// <para>Final updates by the writer to the backup components metadata and cleanup (such as removing temporary files) are typically reserved for CVssWriter::OnPostSnapshot.</para>
        /// <para>Writers should never throw an exception from this method or any other <c>CVssWriter(Ex)::On<c>Xxx</c></c> callback method.</para>
        /// <para>If this method calls the CVssWriterEx2::GetSessionId, CVssWriter::SetWriterFailure, or CVssWriterEx2::SetWriterFailureEx method, it must do so in the same thread that called this method. For more information, see Writer Event Handling.</para>
        /// </remarks>
        virtual Boolean OnThaw() = 0;

        /// <summary>
        /// <para>The <c>OnAbort</c> method is called by a writer following an Abort event issued by VSS indicating that a shadow copy operation has terminated prematurely. The writer uses this method to clean up from its attempt to participate in that operation.</para>
        /// <para><c>OnAbort</c> is a pure virtual method. It is not implemented by the CVssWriter base class, and must be implemented by derived classes.</para>
        /// </summary>
        /// <returns>
        /// <para>The implementation of this method should return <c>true</c> except in the case of a fatal error. If a fatal error occurs, the method must call the CVssWriter::SetWriterFailure method to provide a description of the failure before returning <c>false</c>. If a nonfatal error occurs, the method should still call <c>SetWriterFailure</c> but return <c>true</c>. If the error is caused by a transient problem, the method should specify VSS_E_WRITERERROR_RETRYABLE in the call to <c>SetWriterFailure</c>.</para>
        /// <para>In all cases when a failure occurs, the method should write an event to the event log to report the exact reason for the failure.</para>
        /// </returns>
        /// <remarks>
        /// <para>In this method, the writer should free all temporary system resources it created when preparing to participate with a VSS operation.</para>
        /// <para>The writer will not receive further event notifications related to the VSS operation it was participating in after <c>CVssWriter::OnAbort</c> has been executed.</para>
        /// <para>This method will not be called if the writer has called CVssWriter::OnPostSnapshot (that is, received notification of the end of a shadow copy).</para>
        /// <para>An Abort event is generated when:</para>
        /// <list type="bullet">
        /// <item>
        /// <term>A writer's Freeze and Thaw event handlers (CVssWriter::OnFreeze and CVssWriter::OnThaw) return <c>false</c>, or cannot complete in the time window specified in CVssWriter::Initialize.</term>
        /// </item>
        /// <item>
        /// <term>A requester explicitly generates an Abort event by calling IVssBackupComponents::AbortBackup.</term>
        /// </item>
        /// <item>
        /// <term>There is any failure of the provider or VSS during the creation of a shadow copy following the PrepareForSnapshot event.</term>
        /// </item>
        /// </list>
        /// <para>Writers should never throw an exception from this method or any other <c>CVssWriter(Ex)::On<c>Xxx</c></c> callback method.</para>
        /// <para>If this method calls the CVssWriterEx2::GetSessionId, CVssWriter::SetWriterFailure, or CVssWriterEx2::SetWriterFailureEx method, it must do so in the same thread that called this method. For more information, see Writer Event Handling.</para>
        /// </remarks>
        virtual Boolean OnAbort() = 0;

        /// <summary>
        /// <para>The <c>OnBackupComplete</c> method is called by a writer following a BackupComplete event. It is used to perform operations considered necessary following a backup. These operations cannot, however, modify the Backup Components Document.</para>
        /// <para><c>OnBackupComplete</c> is a virtual method. It is implemented by the CVssWriter base class, but can be overridden by derived classes.</para>
        /// </summary>
        /// <param name="pComponent">A pointer to an IVssWriterComponents object passed in by VSS to provide the method with access to the writer's component information. The value of this parameter may be <c>NULL</c> if the requester does not support components (if CVssWriter::AreComponentsSelected returns <c>false</c>).</param>
        /// <returns>
        /// <para>As implemented by the base class, <c>OnBackupComplete</c> always returns <c>true</c>.</para>
        /// <para>Any other implementation of this method should return <c>true</c> except in the case of a fatal error. If a fatal error occurs, the method must call the CVssWriter::SetWriterFailure method to provide a description of the failure before returning <c>false</c>. If a nonfatal error occurs, the method should still call <c>SetWriterFailure</c> but return <c>true</c>. If the error is caused by a transient problem, the method should specify VSS_E_WRITERERROR_RETRYABLE in the call to <c>SetWriterFailure</c>.</para>
        /// <para>In all cases when a failure occurs, the method should write an event to the event log to report the exact reason for the failure.</para>
        /// </returns>
        /// <remarks>
        /// <para>The default implementation of this method by CVssWriter base class returns <c>true</c> without performing any other operation.</para>
        /// <para>If special operations are to be performed by the writer at the end of a backup, the default implementation can be overridden.</para>
        /// <para>With the generation of a BackupComplete event, a requester's Backup Components Document becomes a read-only document. Therefore, attempts to modify the document through the interface (for instance, calling IVssComponent::SetBackupMetadata) will fail in user implementations of <c>OnBackupComplete</c>.</para>
        /// <para>A successful backup application will generate a BackupComplete event when all data has been saved to backup media.</para>
        /// <para>However, there is no guarantee of the writer receiving a BackupComplete event notification, because these require the backup application to either successfully complete the backup or fail gracefully.</para>
        /// <para>A BackupComplete event could fail to be generated should the backup application be terminated by the system or manually prior to the completion of the backup (for instance, if the backup operation hung and had to be shut down).</para>
        /// <para>A writer should maintain state information so that it can track whether a BackupComplete event was sent for a given shadow copy set.</para>
        /// <para>This information can be used by a writer's BackupShutdown event handler (CVssWriter::OnBackupShutdown), which will be called when a backup application actually terminates and its IVssBackupComponents is released, to perform cleanup operations should there be no call to <c>OnBackupComplete</c>.</para>
        /// <para>Writers should never throw an exception from this method or any other <c>CVssWriter(Ex)::On<c>Xxx</c></c> callback method.</para>
        /// <para>If this method calls the CVssWriterEx2::GetSessionId, CVssWriter::SetWriterFailure, or CVssWriterEx2::SetWriterFailureEx method, it must do so in the same thread that called this method. For more information, see Writer Event Handling.</para>
        /// </remarks>
        virtual Boolean OnBackupComplete(_In_ IVssWriterComponents^ pComponent)
        {
            UNREFERENCED_PARAMETER(pComponent);
            return true;
        }

        /// <summary>
        /// <para>The <c>OnBackupShutdown</c> method is called by a writer following a BackupShutdown event. It is used to perform operations considered necessary when a backup application shuts down, particularly in the case of a crash of the backup application.</para>
        /// <para><c>OnBackupShutdown</c> is a virtual method. It is implemented by the CVssWriter base class, but can be overridden by derived classes.</para>
        /// </summary>
        /// <param name="SnapshotSetId">Identifier for the shadow copy set involved in the backup operation.</param>
        /// <returns>
        /// <para>As implemented by the base class, <c>OnBackupShutdown</c> always returns <c>true</c></para>
        /// <para>Any other implementation of this method should return <c>true</c> except in the case of a fatal error. If a fatal error occurs, the method must call the CVssWriter::SetWriterFailure method to provide a description of the failure before returning <c>false</c>. If a nonfatal error occurs, the method should still call <c>SetWriterFailure</c> but return <c>true</c>. If the error is caused by a transient problem, the method should specify VSS_E_WRITERERROR_RETRYABLE in the call to <c>SetWriterFailure</c>.</para>
        /// <para>In all cases when a failure occurs, the method should write an event to the event log to report the exact reason for the failure.</para>
        /// </returns>
        /// <remarks>
        /// <para>The default implementation of this method by the CVssWriter base class returns <c>true</c> without performing any other operation.</para>
        /// <para>If special operations are to be performed by the writer when a backup application shuts down, the default implementation can be overridden.</para>
        /// <para>If no shadow copy has been successfully performed, the value of the shadow copy set identifier (<c>SnapshotSetId</c>) will be <c>NULL</c>.</para>
        /// <para>A BackupShutdown event will be generated whenever a backup application actually terminates and its IVssBackupComponents is released.</para>
        /// <para>The BackupComplete event requires the backup application to either successfully complete the backup or fail gracefully; this may not be the case if the backup application is terminated by the system or terminated manually prior to the completion of the backup (for instance, if the backup operation hung and had to be shut down).</para>
        /// <para>Because of this, a BackupShutdown event is a more robust signal of the end of a backup application than the BackupComplete event.</para>
        /// <para>A writer should maintain state information so that it can track whether a BackupComplete event was sent for a given shadow copy set.</para>
        /// <para>Any writer-specific implementation of <c>OnBackupShutdown</c> should check whether a BackupComplete event was handled. It should ensure that all necessary writer cleanup operations following a backup (successful or otherwise) are preformed.</para>
        /// <para>Writers should never throw an exception from this method or any other <c>CVssWriter(Ex)::On<c>Xxx</c></c> callback method.</para>
        /// <para>If this method calls the CVssWriterEx2::GetSessionId, CVssWriter::SetWriterFailure, or CVssWriterEx2::SetWriterFailureEx method, it must do so in the same thread that called this method. For more information, see Writer Event Handling.</para>
        /// </remarks>
        virtual Boolean OnBackupShutdown(_In_ Guid SnapshotSetId)
        {
            UNREFERENCED_PARAMETER(SnapshotSetId);
            return true;
        }

        /// <summary>
        /// <para>The <c>OnPreRestore</c> method is called by a writer following a PreRestore event. This method is used to put the writer in a state to support the restore—for instance, taking database services offline—and to make modifications in the Backup Components Document of the requester that is restoring files (such as setting the restore target to override the original restore method).</para>
        /// <para><c>OnPreRestore</c> is a virtual method. It is implemented by the CVssWriter base class, but can be overridden by derived classes.</para>
        /// </summary>
        /// <param name="pComponent">Pointer to an instantiation of an IVssWriterComponents object containing those components associated with the current writer in the requester's Backup Components Document.</param>
        /// <returns>
        /// <para>As implemented by the base class, <c>OnPreRestore</c> always returns <c>true</c>.</para>
        /// <para>Any other implementation of this method must return <c>true</c> except in the case of a fatal error. If a fatal error occurs, the method must call the CVssWriter::SetWriterFailure method to provide a description of the failure before returning <c>false</c>. If a nonfatal error occurs, the method should still call <c>SetWriterFailure</c> but return <c>true</c>. If the error is caused by a transient problem, the method should specify VSS_E_WRITERERROR_RETRYABLE in the call to <c>SetWriterFailure</c>.</para>
        /// <para>In all cases when a failure occurs, the method should write an event to the event log to report the exact reason for the failure.</para>
        /// </returns>
        /// <remarks>
        /// <para>The PreRestore event occurs before backed-up data is actually being restored. This is an opportunity for the writer to determine what is being restored.</para>
        /// <para>The default implementation of this method by the CVssWriter base class returns <c>true</c> without performing any other operation.</para>
        /// <para>This method enables the writer to determine what is being restored, to retrieve stored private metadata in the stored Backup Components Document, and to update that data.</para>
        /// <para>Writers should never throw an exception from this method or any other <c>CVssWriter(Ex)::On<c>Xxx</c></c> callback method.</para>
        /// <para>If this method calls the CVssWriterEx2::GetSessionId, CVssWriter::SetWriterFailure, or CVssWriterEx2::SetWriterFailureEx method, it must do so in the same thread that called this method. For more information, see Writer Event Handling.</para>
        /// </remarks>
        virtual Boolean OnPreRestore(_In_ IVssWriterComponents^ pComponent)
        {
            UNREFERENCED_PARAMETER(pComponent);
            return true;
        }

        /// <summary>
        /// <para>The <c>OnPostRestore</c> method is called by a writer following a PostRestore event. It is used to perform operations considered necessary after files are restored to disk by a requester. These operations cannot, however, modify the Backup Components Document.</para>
        /// <para><c>OnPostRestore</c> is a virtual method. It is implemented by the CVssWriter base class, but can be overridden by derived classes.</para>
        /// </summary>
        /// <param name="pComponent">A pointer to an IVssWriterComponents object passed in by VSS to provide the method with access to the writer's component information. The value of this parameter may be <c>NULL</c> if the requester does not support components (if CVssWriter::AreComponentsSelected returns <c>false</c>).</param>
        /// <returns>
        /// <para>As implemented by the base class, <c>OnPostRestore</c> always returns <c>true</c>.</para>
        /// <para>Any other implementation of this method must return <c>true</c> except in the case of a fatal error. If a fatal error occurs, the method must call the CVssWriter::SetWriterFailure method to provide a description of the failure before returning <c>false</c>. If a nonfatal error occurs, the method should still call <c>SetWriterFailure</c> but return <c>true</c>. If the error is caused by a transient problem, the method should specify VSS_E_WRITERERROR_RETRYABLE in the call to <c>SetWriterFailure</c>.</para>
        /// <para>In all cases when a failure occurs, the method should write an event to the event log to report the exact reason for the failure.</para>
        /// </returns>
        /// <remarks>
        /// <para>The default implementation of this method by the CVssWriter base class returns <c>true</c> without performing any other operation.</para>
        /// <para>If necessary, a writer should remove any temporary files and release any system resources that it needed for its participation in the restore.</para>
        /// <para>Writers should never throw an exception from this method or any other <c>CVssWriter(Ex)::On<c>Xxx</c></c> callback method.</para>
        /// <para>With the generation of a PostRestore event, a requester's Backup Components Document becomes a read-only document. Therefore, attempts to modify the document through the interface (for instance, calling IVssComponent::SetRestoreMetadata) will fail in user implementations of <c>OnPostRestore</c>.</para>
        /// <para>If this method calls the CVssWriterEx2::GetSessionId, CVssWriter::SetWriterFailure, or CVssWriterEx2::SetWriterFailureEx method, it must do so in the same thread that called this method. For more information, see Writer Event Handling.</para>
        /// </remarks>
        virtual Boolean OnPostRestore(_In_ IVssWriterComponents^ pComponent)
        {
            UNREFERENCED_PARAMETER(pComponent);
            return true;
        }

        /// <summary>
        /// <para>The <c>OnPostSnapshot</c> method is called by a writer following a PostSnapshot event.</para>
        /// <para><c>OnPostSnapshot</c> is a virtual method. It is implemented by the CVssWriter base class but can be overridden by derived classes.</para>
        /// </summary>
        /// <param name="pComponent">A pointer to an IVssWriterComponents object passed in by VSS to provide the method with access to the writer's component information. The value of this parameter may be NULL if the requester does not support components (if CVssWriter::AreComponentsSelected returns <c>false</c>).</param>
        /// <returns>
        /// <para>As implemented by the base class, <c>OnPostSnapshot</c> always returns <c>true</c>.</para>
        /// <para>Any other implementation of this method must return <c>true</c> except in the case of a fatal error. If a fatal error occurs, the method must call the CVssWriter::SetWriterFailure method to provide a description of the failure before returning <c>false</c>. If a nonfatal error occurs, the method should still call <c>SetWriterFailure</c> but return <c>true</c>. If the error is caused by a transient problem, the method should specify VSS_E_WRITERERROR_RETRYABLE in the call to <c>SetWriterFailure</c>.</para>
        /// <para>In all cases when a failure occurs, the method should write an event to the event log to report the exact reason for the failure.</para>
        /// </returns>
        /// <remarks>
        /// <para>The default implementation of this method by the CVssWriter base class returns <c>true</c> without performing any other operation.</para>
        /// <para><c>CVssWriter::OnPostSnapshot</c> is typically used to process any final updates by the writer to the backup components metadata and clean up (such as removing temporary files).</para>
        /// <para>If an incremental or differential backup is being performed, the writer may call IVssComponent::GetPreviousBackupStamp and IVssComponent::SetBackupStamp. For more information, see Writer Role in Backing Up Complex Stores. Another method that can be called at this time is IVssComponent::AddDifferencedFilesByLastModifyTime.</para>
        /// <para>Most of the work needed to return the writer to normal operation (reversing the actions of CVssWriter::OnPrepareSnapshot and CVssWriter::OnFreeze) is typically performed in CVssWriter::OnThaw, not in <c>OnPostSnapshot</c>.</para>
        /// <para>Writers should never throw an exception from this method or any other <c>CVssWriter(Ex)::On<c>Xxx</c></c> callback method.</para>
        /// <para>If the shadow copy has the <c>VSS_VOLSNAP_ATTR_AUTORECOVER</c> flag set in the context, the writer should perform any recovery required (for example, rolling back any incomplete transactions) so that the component will be usable on a read-only copy for data mining (without adding load to the live server) or restore purposes (for example, to restore selected items from a database).</para>
        /// <para>To retrieve the volume name of the shadow copy of a volume, perform the following steps:</para>
        /// <list type="number">
        /// <item>
        /// <term>Call the CVssWriter::GetCurrentVolumeCount method to query the number of volumes in the shadow copy set.</term>
        /// </item>
        /// <item>
        /// <term>Call the CVssWriter::GetCurrentVolumeArray method to enumerate the original names of the volumes in the shadow copy set.</term>
        /// </item>
        /// <item>
        /// <term>Call the CVssWriter::GetSnapshotDeviceName to retrieve the name of the shadow copy volume.</term>
        /// </item>
        /// </list>
        /// <para>If this method calls the CVssWriterEx2::GetSessionId, CVssWriter::SetWriterFailure, or CVssWriterEx2::SetWriterFailureEx method, it must do so in the same thread that called this method. For more information, see Writer Event Handling.</para>
        /// </remarks>
        virtual Boolean OnPostSnapshot(_In_ IVssWriterComponents^ pComponent)
        {
            UNREFERENCED_PARAMETER(pComponent);
            return true;
        }

        /// <summary>
        /// <para>Not supported.</para>
        /// <para>This method is reserved for future use.</para>
        /// </summary>
        /// <param name="wszVolumeName">This parameter is reserved for future use.</param>
        /// <param name="snapshotId">This parameter is reserved for future use.</param>
        /// <param name="providerId">This parameter is reserved for future use.</param>
        /// <returns>This method does not return a value.</returns>
        virtual Boolean OnBackOffIOOnVolume(_In_ String^ wszVolumeName, _In_ Guid snapshotId, _In_ Guid providerId)
        {
            UNREFERENCED_PARAMETER(wszVolumeName);
            UNREFERENCED_PARAMETER(snapshotId);
            UNREFERENCED_PARAMETER(providerId);

            return true;
        }

        /// <summary>
        /// <para>Not supported.</para>
        /// <para>This method is reserved for future use.</para>
        /// </summary>
        /// <param name="wszVolumeName">This parameter is reserved for future use.</param>
        /// <param name="snapshotId">This parameter is reserved for future use.</param>
        /// <param name="providerId">This parameter is reserved for future use.</param>
        /// <returns>This method does not return a value.</returns>
        virtual Boolean OnContinueIOOnVolume(_In_ String^ wszVolumeName, _In_ Guid snapshotId, _In_ Guid providerId)
        {
            UNREFERENCED_PARAMETER(wszVolumeName);
            UNREFERENCED_PARAMETER(snapshotId);
            UNREFERENCED_PARAMETER(providerId);

            return true;
        }

        /// <summary>
        /// <para>Not supported.</para>
        /// <para>This method is reserved for future use.</para>
        /// </summary>
        /// <returns>This method does not return a value.</returns>
        virtual Boolean OnVSSShutdown()
        {
            return true;
        }

        /// <summary>
        /// <para>Not supported.</para>
        /// <para>This method is reserved for future use.</para>
        /// </summary>
        /// <returns>This method does not return a value.</returns>
        virtual Boolean OnVSSApplicationStartup()
        {
            return true;
        }

        /// <summary>Sets extended error information to indicate that the writer has encountered a problem with participating in a VSS operation.</summary>
        /// <param name="hrWriter">
        /// <para>The error code to be returned to the requester.</para>
        /// <para>The following are the error codes that this method can set.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <term>Meaning</term>
        /// </listheader>
        /// <item>
        /// <term><c>S_OK</c></term>
        /// <term>The writer was successful.</term>
        /// </item>
        /// <item>
        /// <term><c>VSS_E_WRITERERROR_INCONSISTENTSNAPSHOT</c></term>
        /// <term>The shadow copy contains only a subset of the volumes needed by the writer to correctly back up the application component.</term>
        /// </item>
        /// <item>
        /// <term><c>VSS_E_WRITERERROR_OUTOFRESOURCES</c></term>
        /// <term>The writer ran out of memory or other system resources. The recommended way to handle this error code is to wait ten minutes and then repeat the operation, up to three times.</term>
        /// </item>
        /// <item>
        /// <term><c>VSS_E_WRITERERROR_TIMEOUT</c></term>
        /// <term>The writer operation failed because of a time-out between the Freeze and Thaw events. The recommended way to handle this error code is to wait ten minutes and then repeat the operation, up to three times.</term>
        /// </item>
        /// <item>
        /// <term><c>VSS_E_WRITERERROR_RETRYABLE</c></term>
        /// <term>The writer failed due to an error that would likely not occur if the entire backup, restore, or shadow copy creation process was restarted. The recommended way to handle this error code is to wait ten minutes and then repeat the operation, up to three times.</term>
        /// </item>
        /// <item>
        /// <term><c>VSS_E_WRITERERROR_NONRETRYABLE</c></term>
        /// <term>The writer operation failed because of an error that might recur if another shadow copy is created. For more information, see Event and Error Handling Under VSS.</term>
        /// </item>
        /// <item>
        /// <term><c>VSS_E_WRITERERROR_PARTIAL_FAILURE</c></term>
        /// <term>The writer is reporting one or more component-level errors. To report the errors, the writer must use the IVssComponentEx2::SetFailure method.</term>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="hrApplication">An additional error code to be returned to the requester. This parameter is optional.</param>
        /// <param name="wszApplicationMessage">A string containing an error message for the requester to display to the end user. The writer is responsible for localizing this string if necessary before using it in this method. This parameter is optional and can be <c>NULL</c> or an empty string.</param>
        /// <remarks>
        /// <para>This method cannot be called from CVssWriter::OnIdentify or CVssWriterEx::OnIdentifyEx.</para>
        /// <para>To report component-level errors, writers should use the IVssComponentEx2::SetFailure method.</para>
        /// <para>If a writer's event handler (such as CVssWriter::OnFreeze) calls this method, it must do so in the same thread that called the event handler. For more information, see Writer Event Handling.</para>
        /// </remarks>
        void SetWriterFailureEx(_In_ HRESULT hrWriter, _In_ HRESULT hrApplication, [Optional] _In_ String^ wszApplicationMessage)
        {
            Utils::ThrowIfFailed(pNative->SetWriterFailureEx((UInt32)hrWriter, (UInt32)hrApplication, SafeWString(wszApplicationMessage)));
        }

        /// <summary>
        /// <para>The <c>Subscribe</c> method subscribes the writer with VSS.</para>
        /// <para><c>Subscribe</c> is a public method implemented by the base class.</para>
        /// </summary>
        /// <param name="dwEventFlags">
        /// <para>A bit mask (or bitwise OR) of VSS_SUBSCRIBE_MASK values indicating the events that VSS should notify the writer about.</para>
        /// <para>
        /// The default value for this argument is (VSS_SM_BACKUP_EVENTS_FLAG | VSS_SM_RESTORE_EVENTS_FLAG). Currently, the caller should
        /// not override the default value.
        /// </para>
        /// <para>This parameter is reserved for future use.</para>
        /// </param>
        void Subscribe(VSS_SUBSCRIBE_MASK dwEventFlags)
        {
            Utils::ThrowIfFailed(pNative->Subscribe((DWORD)dwEventFlags));
        }

        /// <summary>
        /// <para>The <c>Unsubscribe</c> method unsubscribes the writer with VSS.</para>
        /// <para><c>Unsubscribe</c> is a public method implemented by the CVssWriter base class.</para>
        /// </summary>
        void Unsubscribe()
        {
            Utils::ThrowIfFailed(pNative->Unsubscribe());
        }

    };

}}}
