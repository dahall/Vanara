#pragma once
#include <winerror.h>
#include <guiddef.h>

using namespace System;

ref class Utils sealed
{
public:
    static void ThrowIfFailed(::HRESULT hr)
    {
        if (hr < 0)
            throw gcnew Runtime::InteropServices::COMException(nullptr, hr);
    }

    static Guid FromGUID(_GUID& guid) {
        return Guid(guid.Data1, guid.Data2, guid.Data3, guid.Data4[0], guid.Data4[1], guid.Data4[2],
            guid.Data4[3], guid.Data4[4], guid.Data4[5], guid.Data4[6], guid.Data4[7]);
    }

    static _GUID ToGUID(Guid& guid) {
        array<Byte>^ guidData = guid.ToByteArray();
        pin_ptr<Byte> data = &(guidData[0]);

        return *(_GUID*)data;
    }

    static _GUID* ToGUIDArray([System::Runtime::InteropServices::In] array<Guid>^ input)
    {
        if (input == nullptr)
            return nullptr;
        pin_ptr<Guid> pg = &input[0];
        VSS_ID* buf = new VSS_ID[input->Length];
        for (int i = 0; i < input->Length; i++)
            buf[i] = Utils::ToGUID(pg[i]);
        return buf;
    }

    generic <class TIN, class TOUT>
    delegate TOUT Conv(TIN input);

    template <class TIN, class TOUT>
    static TOUT* ToNative(array<TIN>^ input, Conv<TIN, TOUT>^ func)
    {
        if (input == nullptr)
            return nullptr;
        if (input->Length == 0)
            return new TOUT[0];
        pin_ptr<TIN> pin = &input[0];
        TIN* p = pin;
        TOUT* buf = new TOUT[input->Length];
        for (int i = 0; i < input->Len; i++)
        {
            input[i] = func(pin[i]);
        }
        return buf;
    }
};

class SmartGuid
{
private:
    _GUID mGuid;
public:
    SmartGuid(_GUID& guid) : mGuid(guid) {}
    SmartGuid(Guid& guid) : mGuid(Utils::ToGUID(guid)) {}
    operator Guid() { return Utils::FromGUID(mGuid); }
    operator _GUID() { return mGuid; }
};
