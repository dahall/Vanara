#include "pch.h"
#include "vswriter.h"
#include "CliLists.h"

using namespace Vanara::PInvoke::VssApi;
using namespace System::Collections::Generic;

#define DEFINE_COMP_ROLIST(prop, cFunc, iElem, gFunc, cElem) \
    IReadOnlyList<Vanara::PInvoke::VssApi::IVssWMFiledesc^>^ CVssComponent::prop::get() {\
        UINT c;\
        Utils::ThrowIfFailed(pNative->cFunc(&c));\
        auto ret = gcnew List<iElem^>();\
        ::iElem* v;\
        for (UINT i = 0; i < c; i++) {\
            pNative->gFunc(i, &v);\
            ret->Add(gcnew cElem(v));\
        }\
        return ret;\
    }

DEFINE_COMP_ROLIST(AlternateLocationMappings, GetAlternateLocationMappingCount, IVssWMFiledesc, GetAlternateLocationMapping, CVssWMFiledesc)

DEFINE_COMP_ROLIST(NewTargets, GetNewTargetCount, IVssWMFiledesc, GetNewTarget, CVssWMFiledesc)

void CVssComponent::AddDifferencedFile(VssDifferencedFile item)
{
    auto llft = item.LastModifyTime.ToFileTime();
    ::FILETIME ft = *(::FILETIME*)&llft;
    Utils::ThrowIfFailed(pNative->AddDifferencedFilesByLastModifyTime(SafeWString(item.Path), SafeWString(item.FileSpec), item.Recursive, ft));
}

VssDifferencedFile CVssComponent::GetDifferencedFilesItem(int i)
{
    SafeBSTR path, filespec, lsn;
    ::BOOL recur;
    ::FILETIME ft;
    Utils::ThrowIfFailed(pNative->GetDifferencedFile(i, &path, &filespec, &recur, &lsn, &ft));
    VssDifferencedFile e {};
    e.Path = path;
    e.FileSpec = filespec;
    e.Recursive = recur;
    ::Int64 nFT = static_cast<::Int64>(*(long long*)&ft);
    e.LastModifyTime = DateTime::FromFileTime(nFT);
    return e;
}

IAppendOnlyList<VssDifferencedFile>^ CVssComponent::DifferencedFiles::get()
{
    return gcnew AppendOnlyList<Vanara::PInvoke::VssApi::VssDifferencedFile>(
        gcnew GetCount(this, &CVssComponent::GetDifferencedFilesCount),
        gcnew GetValue<VssDifferencedFile>(this, &CVssComponent::GetDifferencedFilesItem),
        gcnew AddValue<VssDifferencedFile>(this, &CVssComponent::AddDifferencedFile));
}

VssDirectedTarget CVssComponent::GetDirectedTargetItem(int i)
{
    SafeBSTR spath, sfn, srng, dpath, dfn, drng;
    Utils::ThrowIfFailed(pNative->GetDirectedTarget(i, &spath, &sfn, &srng, &dpath, &dfn, &drng));
    VssDirectedTarget e = { dfn, dpath, drng, sfn, spath, srng, };
    return e;
}

void CVssComponent::AddDirectedTarget(VssDirectedTarget v)
{
    Utils::ThrowIfFailed(pNative->AddDirectedTarget(SafeWString(v.SourcePath),
        SafeWString(v.SourceFilename), SafeWString(v.SourceRangeList), SafeWString(v.DestinationPath),
        SafeWString(v.DestinationFilename), SafeWString(v.DestinationRangeList)));
}

IAppendOnlyList<VssDirectedTarget>^ CVssComponent::DirectedTargets::get()
{
    return gcnew AppendOnlyList<Vanara::PInvoke::VssApi::VssDirectedTarget>(
        gcnew GetCount(this, &CVssComponent::GetDirectedTargetCount),
        gcnew GetValue<VssDirectedTarget>(this, &CVssComponent::GetDirectedTargetItem),
        gcnew AddValue<VssDirectedTarget>(this, &CVssComponent::AddDirectedTarget));
}

VssPartialFile CVssComponent::GetPartialFileItem(int i)
{
    SafeBSTR path, fn, rng, meta;
    Utils::ThrowIfFailed(pNative->GetPartialFile(i, &path, &fn, &rng, &meta));
    VssPartialFile e = { fn, meta, path, rng };
    return e;
}

void CVssComponent::AddPartialFile(VssPartialFile v)
{
    Utils::ThrowIfFailed(pNative->AddPartialFile(SafeWString(v.Path), SafeWString(v.Filename),
        SafeWString(v.Ranges), SafeWString(v.Metadata)));
}

IAppendOnlyList<VssPartialFile>^ CVssComponent::PartialFiles::get()
{
    return gcnew AppendOnlyList<Vanara::PInvoke::VssApi::VssPartialFile>(
        gcnew GetCount(this, &CVssComponent::GetPartialFileCount),
        gcnew GetValue<VssPartialFile>(this, &CVssComponent::GetPartialFileItem),
        gcnew AddValue<VssPartialFile>(this, &CVssComponent::AddPartialFile));
}

VssRestoreSubcomponent CVssComponent::GetRestoreSubcomponentsItem(int i)
{
    SafeBSTR path, n;
    bool repair;
    Utils::ThrowIfFailed(pNative->GetRestoreSubcomponent(i, &path, &n, &repair));
    VssRestoreSubcomponent e = { n, path, repair };
    return e;
}

IReadOnlyList<VssRestoreSubcomponent>^ CVssComponent::RestoreSubcomponents::get()
{
    return gcnew ListImplBase<Vanara::PInvoke::VssApi::VssRestoreSubcomponent>(
        gcnew GetCount(this, &CVssComponent::GetRestoreSubcomponentsCount),
        gcnew GetValue<VssRestoreSubcomponent>(this, &CVssComponent::GetRestoreSubcomponentsItem));
}

void CVssComponent::GetFailure(Vanara::PInvoke::HRESULT% phr, Vanara::PInvoke::HRESULT% phrApplication, System::String^% pbstrApplicationMessage)
{
    SafeComPtr<::IVssComponentEx2*> p = pNative;
    ::HRESULT hr, hrApp;
    SafeBSTR msg;
    DWORD d;
    Utils::ThrowIfFailed(p->GetFailure(&hr, &hrApp, &msg, &d));
    phr = static_cast<HRESULT>(hr);
    phrApplication = static_cast<HRESULT>(hrApp);
    pbstrApplicationMessage = msg;
}

void CVssComponent::GetRollForward(VSS_ROLLFORWARD_TYPE% pRollType, System::String^% pbstrPoint)
{
    SafeComPtr<::IVssComponentEx*> p = pNative;
    ::VSS_ROLLFORWARD_TYPE type{};
    SafeBSTR pt;
    Utils::ThrowIfFailed(p->GetRollForward(&type, &pt));
    pRollType = static_cast<VSS_ROLLFORWARD_TYPE>(type);
    pbstrPoint = pt;
}

void CVssComponent::SetFailure(Vanara::PInvoke::HRESULT hr, Vanara::PInvoke::HRESULT hrApplication, System::String^ wszApplicationMessage)
{
    SafeComPtr<::IVssComponentEx2*> p = pNative;
    SafeString msg = wszApplicationMessage;
    Utils::ThrowIfFailed(p->SetFailure(static_cast<::HRESULT>((Int32)hr), static_cast<::HRESULT>((Int32)hrApplication), msg, 0));
}

Vanara::PInvoke::VssApi::IVssComponent^ CVssWriterComponents::GetComponent(int i)
{
    SafeComPtr<::IVssComponent*> c;
    Utils::ThrowIfFailed(pNative->GetComponent(i, &c));
    return (IVssComponent^)Marshal::GetObjectForIUnknown(IntPtr((::IVssComponent*)c));
}