#include "pch.h"
#include "vsbackup.h"
#include "vswriter.h"

namespace Vanara { namespace PInvoke { namespace VssApi {

    Vanara::PInvoke::VssApi::VSS_COMPONENTINFO CVssWMComponent::GetComponentInfo() {
        RefreshInfo();
        return (Vanara::PInvoke::VssApi::VSS_COMPONENTINFO)Marshal::PtrToStructure(IntPtr((void*)pInfo), Vanara::PInvoke::VssApi::VSS_COMPONENTINFO::typeid);
    }

    void CVssExamineWriterMetadata::RefreshRestoreMethod()
    {
        ::VSS_RESTOREMETHOD_ENUM eMethod;
        SafeBSTR bstrService;
        SafeBSTR bstrUserProcedure;
        ::VSS_WRITERRESTORE_ENUM eWriterRestore;
        bool bRebootRequired;
        UINT iMappings;
        Utils::ThrowIfFailed(pNative->GetRestoreMethod(&eMethod, &bstrService, &bstrUserProcedure, &eWriterRestore, &bRebootRequired, &iMappings));
        restoreMethod = VSS_RESTORE_METHOD(eMethod, bstrService, bstrUserProcedure, eWriterRestore, bRebootRequired, iMappings);
    }

    void CVssExamineWriterMetadata::RefreshFileCounts()
    {
        pin_ptr<UINT> pci = &cIncludeFiles;
        pin_ptr<UINT> pce = &cExcludeFiles;
        pin_ptr<UINT> pcc = &cComponents;
        Utils::ThrowIfFailed(pNative->GetFileCounts(pci, pce, pcc));
    }

    Version^ CVssExamineWriterMetadata::Version::get()
    {
        SafeComPtr<::IVssExamineWriterMetadataEx2*> p2 = pNative;
        DWORD maj, min;
        Utils::ThrowIfFailed(((::IVssExamineWriterMetadataEx2*)p2)->GetVersion(&maj, &min));
        return gcnew System::Version(static_cast<int>(maj), static_cast<int>(min));
    }

    void CVssExamineWriterMetadata::GetIdentity(Guid% pidInstance, Guid% pidWriter, String^% pbstrWriterName, String^% pbstrInstanceName, Vanara::PInvoke::VssApi::VSS_USAGE_TYPE% pUsage,
        Vanara::PInvoke::VssApi::VSS_SOURCE_TYPE% pSource)
    {
        ::VSS_ID inst, writer;
        SafeBSTR name, wrName;
        ::VSS_USAGE_TYPE use;
        ::VSS_SOURCE_TYPE src;
        ::IVssExamineWriterMetadataEx* pNativeEx = nullptr;
        if (pNative->QueryInterface(::IID_IVssExamineWriterMetadataEx, (void**)&pNativeEx) >= 0)
        {
            Utils::ThrowIfFailed(pNativeEx->GetIdentityEx(&inst, &writer, &wrName, &name, &use, &src));
        }
        else
        {
            Utils::ThrowIfFailed(pNative->GetIdentity(&inst, &writer, &name, &use, &src));
        }
        pidInstance = Utils::FromGUID(inst);
        pidWriter = Utils::FromGUID(writer);
        pbstrWriterName = wrName;
        pbstrInstanceName = name;
        pUsage = static_cast<Vanara::PInvoke::VssApi::VSS_USAGE_TYPE>(use);
        pSource = static_cast<Vanara::PInvoke::VssApi::VSS_SOURCE_TYPE>(src);
    }

    void CVssExamineWriterMetadata::GetRestoreMethod(Vanara::PInvoke::VssApi::VSS_RESTOREMETHOD_ENUM% pMethod, System::String^% pbstrService, System::String^% pbstrUserProcedure,
        Vanara::PInvoke::VssApi::VSS_WRITERRESTORE_ENUM% pwriterRestore, bool% pbRebootRequired, UInt32% pcMappings)
    {
        RefreshRestoreMethod();
        pMethod = static_cast<Vanara::PInvoke::VssApi::VSS_RESTOREMETHOD_ENUM>(restoreMethod.eMethod);
        pbstrService = restoreMethod.bstrService;
        pbstrUserProcedure = restoreMethod.bstrUserProcedure;
        pwriterRestore = static_cast<Vanara::PInvoke::VssApi::VSS_WRITERRESTORE_ENUM>(restoreMethod.eWriterRestore);
        pbRebootRequired = restoreMethod.bRebootRequired;
        pcMappings = static_cast<UInt32>(restoreMethod.iMappings);
    }

    void CVssExamineWriterMetadata::LoadFromXML(String^ bstrXML)
    {
        SafeString xml = bstrXML;
        Utils::ThrowIfFailed(pNative->LoadFromXML(xml));
    }

    String^ CVssExamineWriterMetadata::SaveAsXML()
    {
        SafeBSTR bstr;
        Utils::ThrowIfFailed(pNative->SaveAsXML(&bstr));
        return bstr;
    }

    IVssWriterComponentsExt^ VssApi::CVssBackupComponents::GetWriterComponents(int i)
    {
        ::IVssWriterComponentsExt* p;
        Utils::ThrowIfFailed(pNative->GetWriterComponents(i, &p));
        return gcnew CVssWriterComponents(p);
    }

    IVssExamineWriterMetadata^ VssApi::CVssBackupComponents::GetWriterMetadata(int i)
    {
        ::IVssExamineWriterMetadata* p;
        VSS_ID id;
        Utils::ThrowIfFailed(pNative->GetWriterMetadata(i, &id, &p));
        return gcnew CVssExamineWriterMetadata(p);
    }

    VssWriterStatus VssApi::CVssBackupComponents::GetWriterStatus(int i)
    {
        VSS_ID id, wri;
        SafeBSTR swri, msg;
        ::VSS_WRITER_STATE stat;
        ::HRESULT hr, hrApp;
        SafeComPtr<::IVssBackupComponentsEx3*> p = pNative;
        Utils::ThrowIfFailed(p->GetWriterStatusEx(i, &id, &wri, &swri, &stat, &hr, &hrApp, &msg));
        VssWriterStatus ret { msg, swri, (HRESULT)hrApp, (HRESULT)hr, Utils::FromGUID(id), Utils::FromGUID(wri), static_cast<VSS_WRITER_STATE>(stat) };
        return ret;
    }

}}}