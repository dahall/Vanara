#pragma once

using namespace System;

template <class T>
ref class BaseWrapper : MarshalByRefObject
{
protected:
    T* pNative;
public:
    BaseWrapper(T* ptr) : pNative(ptr) {}
    ~BaseWrapper() { this->!BaseWrapper(); }
    !BaseWrapper() { if (pNative) { pNative->Release(); pNative = nullptr; } }
};

template <class T>
ref class BaseClassWrapper : MarshalByRefObject
{
protected:
    T* pNative;
public:
    BaseClassWrapper(T* ptr) : pNative(ptr) {}
    ~BaseClassWrapper() { this->!BaseClassWrapper(); }
    !BaseClassWrapper() { if (pNative) { delete pNative; pNative = nullptr; } }
};