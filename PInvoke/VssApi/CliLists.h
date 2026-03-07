#pragma once

using namespace System;
using namespace System::Collections::Generic;

generic <typename T>
delegate T GetValue(int index);

generic <typename T>
delegate void AddValue(T value);

generic <typename T>
ref class ListImplBase : IReadOnlyList<T>
{
protected:
	int count;
	GetValue<T>^ getValue;
	List<T>^ cache;
	static initonly T defaultValue = T();

	virtual System::Collections::IEnumerator^ ObjGetEnum() = System::Collections::IEnumerable::GetEnumerator{ return GetEnumerator(); }
public:
	ListImplBase(int c, GetValue<T>^ gv) : count(c), getValue(gv), cache(gcnew List<T>()) { for (int i = 0; i < c; i++) cache->Add(defaultValue); }
	~ListImplBase() {}
	!ListImplBase() { getValue = nullptr; }

	virtual property int Count { int get() { return count; } }
	virtual property T default[Int32] { T get(Int32 index)
	{
		if (index < 0 || index >= cache->Count)
			throw gcnew ArgumentOutOfRangeException("index");
		// If the requested index value in 'cache' has never been set and is still its default value, fetch it and add to the cache.
		if (EqualityComparer<T>::Default->Equals(cache[index], defaultValue))
			cache[index] = getValue(index);
		return cache[index];
	} }
protected:
	ref class ListEnumerator : public IEnumerator<T>
	{
	protected:
		ListImplBase<T>^ list;
		int i;
	public:
		ListEnumerator(ListImplBase<T>^ l) : list(l), i(-1) {}
		~ListEnumerator() {}
		!ListEnumerator() { list = nullptr; }

		virtual property T Current { T get() { return i < 0 ? T() : list->default[i]; } }
		virtual bool MoveNext() { return ++i < list->Count; }
		virtual void Reset() { i = -1; }
	private:
		property Object^ ObjectCurrent { virtual Object^ get() sealed = System::Collections::IEnumerator::Current::get{ return Current; } };
	};
public:
	virtual System::Collections::Generic::IEnumerator<T>^ GetEnumerator() { return gcnew ListEnumerator(this); }
};

generic <typename T>
ref class AppendOnlyList : public ListImplBase<T>, public Vanara::PInvoke::VssApi::IAppendOnlyList<T>
{
protected:
	AddValue<T>^ addValue;

public:
	AppendOnlyList(int c, GetValue<T>^ gv, AddValue<T>^ add) : ListImplBase(c, gv), addValue(add) {}
	~AppendOnlyList() {}
	!AppendOnlyList() { addValue = nullptr; }

	virtual void Add(T item) { addValue(item); }
};