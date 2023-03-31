using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public class GenericComTester<TInt> where TInt : class
{
	protected Stack<object> objects = new Stack<object>();

	public virtual TInt Instance => (TInt)objects.Peek();

	[OneTimeSetUp]
	public virtual void Setup() => objects.Push(InitInstance());

	[OneTimeTearDown]
	public virtual void TearDown()
	{
		while (objects.Count > 0)
			Marshal.FinalReleaseComObject(objects.Pop());
	}

	protected virtual TInt InitInstance() => Activator.CreateInstance<TInt>();
}

public class GenericTester<T> where T : class, IDisposable
{
	public virtual T Instance { get; protected set; }

	[OneTimeSetUp]
	public virtual void Setup() => Instance = InitInstance();

	[OneTimeTearDown]
	public virtual void TearDown() => Instance?.Dispose();

	protected virtual T InitInstance() => Activator.CreateInstance<T>();
}