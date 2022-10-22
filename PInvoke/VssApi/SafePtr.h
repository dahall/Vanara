#pragma once
#include <wtypes.h>

using namespace System;

template <typename T>
class SafePointer
{
protected:
    T m_ptr;
public:
    SafePointer() : m_ptr(0) { }
    SafePointer(T ptr) : m_ptr(ptr) { }
    virtual ~SafePointer() { if (m_ptr != 0) { Release(m_ptr); } }
    operator T() { return m_ptr; }
    T* operator&() { return &m_ptr; }
    virtual void Release(T ptr) {};
};

class SafeBSTR : public SafePointer<BSTR>
{
public:
    SafeBSTR() : SafePointer() {}
    SafeBSTR(LPWSTR pString) : SafePointer(::SysAllocString(pString)) {}
    void Release(BSTR ptr) override { ::SysFreeString(ptr); }
    operator String^() { return (m_ptr == 0) ? nullptr : Runtime::InteropServices::Marshal::PtrToStringBSTR((IntPtr)m_ptr); }
};

class SafeString : public SafePointer<BSTR>
{
public:
    SafeString(String^ value) : SafePointer((BSTR)Runtime::InteropServices::Marshal::StringToBSTR(value).ToPointer()) {}
    void Release(BSTR ptr) override { System::Runtime::InteropServices::Marshal::FreeBSTR((IntPtr)ptr); }
    operator String^() { return (m_ptr == 0) ? nullptr : Runtime::InteropServices::Marshal::PtrToStringBSTR((IntPtr)m_ptr); }
};

class SafeWString : public SafePointer<LPWSTR>
{
public:
    SafeWString(String^ value) : SafePointer((LPWSTR)Runtime::InteropServices::Marshal::StringToCoTaskMemUni(value).ToPointer()) {}
    void Release(LPWSTR ptr) override { System::Runtime::InteropServices::Marshal::FreeCoTaskMem((IntPtr)ptr); }
    operator String^() { return (m_ptr == 0) ? nullptr : Runtime::InteropServices::Marshal::PtrToStringUni((IntPtr)m_ptr); }
};

template <class T>
class SafeComPtr : public SafePointer<T>
{
public:
    SafeComPtr() : SafePointer() {}
    SafeComPtr(IUnknown* pUnk) { Utils::ThrowIfFailed(pUnk->QueryInterface(IID_PPV_ARGS(&m_ptr))); }
    void Release(T ptr) override { ((IUnknown*)m_ptr)->Release(); }
    T operator->() const { return m_ptr; }
};
