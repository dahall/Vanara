#pragma once

using namespace System;
using namespace System::Collections::Generic;

delegate int GetCount();

generic <typename T>
delegate T GetValue(int index);

generic <typename T>
delegate void AddValue(T value);

template <class T>
ref class IEnumeratorImpl;

template <class T>
ref class ListImplBase : IReadOnlyList<T>
{
protected:
    GetCount^ getCount;
    GetValue<T>^ getValue;

    virtual System::Collections::IEnumerator^ ObjGetEnum() = System::Collections::IEnumerable::GetEnumerator{ return GetEnumerator(); }
public:
    ListImplBase(GetCount^ gc, GetValue<T>^ gv) : getCount(gc), getValue(gv) { }
    ~ListImplBase() {}
    !ListImplBase() { getCount = nullptr; getValue = nullptr; }

    virtual property int Count { int get() { return getCount(); } }
    virtual property T default[Int32] { T get(Int32 index) { return getValue(index); } }
        virtual System::Collections::Generic::IEnumerator<T>^ GetEnumerator()
    {
        return gcnew ListEnumerator<T>(this);
    }
};

template <class T>
ref class AppendOnlyList : public ListImplBase<T>, public Vanara::PInvoke::VssApi::IAppendOnlyList<T>
{
protected:
    AddValue<T>^ addValue;

public:
    AppendOnlyList(GetCount^ gc, GetValue<T>^ gv, AddValue<T>^ add) :
        ListImplBase(gc, gv), addValue(add) {}
    ~AppendOnlyList() {}
    !AppendOnlyList() { addValue = nullptr; }

    virtual void Add(T item) { addValue(item); }
};

template <class T>
ref class ListEnumerator : public IEnumerator<T>
{
protected:
    ListImplBase<T>^ list;

    int i;
public:
    ListEnumerator(ListImplBase<T>^ l) : list(l), i(-1) { }
    ~ListEnumerator() {}
    !ListEnumerator() { list = nullptr; }

    virtual property T Current { T get() { return i < 0 ? T() : list->default[i]; } }
    virtual bool MoveNext() { return ++i < list->Count; }
    virtual void Reset() { i = -1; }
private:
    property Object^ ObjectCurrent { virtual Object^ get() sealed = System::Collections::IEnumerator::Current::get{ return Current; } };
};
