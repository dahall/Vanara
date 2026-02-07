#if NETCOREAPP || NETSTANDARD2_0_OR_GREATER
using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using Vanara.PInvoke;

namespace System.Runtime.InteropServices.CustomMarshalers;

/// <summary>Marshals the COM <c>IEnumVARIANT</c> interface to the .NET Framework <see cref="IEnumerator"/> interface, and vice versa.</summary>
/// <remarks>
/// This custom marshaler marshals <c>IEnumVARIANT</c> to <see cref="IEnumerator"/> and marshals <see cref="IEnumerator"/> to
/// <c>IEnumVARIANT</c>. The CLR automatically uses this class to bridge COM enumerators and .NET enumerators. The <see cref="IEnumerator"/>
/// type returned by the GetEnumerator method in the imported COM class uses <c>EnumeratorToEnumVariantMarshaler</c> to map the calls to the
/// <c>IEnumVARIANT</c> interface pointer returned by the COM object's member with a DISPID of -4.
/// </remarks>
public class EnumeratorToEnumVariantMarshaler : ICustomMarshaler
{
	private static readonly EnumeratorToEnumVariantMarshaler s_enumeratorToEnumVariantMarshaler = new();

	/// <summary>Returns an instance of the custom marshaler.</summary>
	/// <param name="cookie">String "cookie" parameter that can be used by the custom marshaler.</param>
	/// <returns>An instance of the custom marshaler.</returns>
	public static ICustomMarshaler GetInstance(string cookie) => s_enumeratorToEnumVariantMarshaler;

	private EnumeratorToEnumVariantMarshaler()
	{
	}

	/// <summary>Performs necessary cleanup of the managed data when it is no longer needed.</summary>
	/// <param name="ManagedObj">The managed object to be destroyed.</param>
	public void CleanUpManagedData(object ManagedObj)
	{
	}

	/// <summary>Performs necessary cleanup of the unmanaged data when it is no longer needed.</summary>
	/// <param name="pNativeData">A pointer to the unmanaged data to be destroyed.</param>
	public void CleanUpNativeData(IntPtr pNativeData) => Marshal.Release(pNativeData);

	/// <summary>Returns the size in bytes of the unmanaged data to be marshaled.</summary>
	/// <returns>-1 to indicate the type this marshaler handles is not a value type.</returns>
	public int GetNativeDataSize() => -1;

	/// <summary>Marshals an object from managed code to unmanaged code.</summary>
	/// <param name="ManagedObj">The managed object to be converted.</param>
	/// <returns>A pointer to the unmanaged object.</returns>
	public IntPtr MarshalManagedToNative(object ManagedObj) => ManagedObj switch
	{
		null => throw new ArgumentNullException(nameof(ManagedObj)),
		EnumeratorViewOfEnumVariant view => Marshal.GetComInterfaceForObject<object, IEnumVARIANT>(view.GetUnderlyingObject()),
		_ => Marshal.GetComInterfaceForObject<EnumVariantViewOfEnumerator, IEnumVARIANT>(new EnumVariantViewOfEnumerator((IEnumerator)ManagedObj))
	};

	/// <summary>Marshals an object from unmanaged code to managed code.</summary>
	/// <param name="pNativeData">A pointer to the unmanaged object to be converted.</param>
	/// <returns>A managed object.</returns>
	public object MarshalNativeToManaged(IntPtr pNativeData)
	{
		if (pNativeData == IntPtr.Zero)
			throw new ArgumentNullException(nameof(pNativeData));

		object comObject = Marshal.GetObjectForIUnknown(pNativeData);
		if (!comObject.GetType().IsCOMObject)
			return comObject is EnumVariantViewOfEnumerator enumVariantView ? enumVariantView.Enumerator : (IEnumerator)comObject;
		return ComDataHelpers.GetOrCreateManagedViewFromComData<IEnumVARIANT, EnumeratorViewOfEnumVariant>(comObject, var => new EnumeratorViewOfEnumVariant(var));
	}
}

internal static class ComDataHelpers
{
	public static TView GetOrCreateManagedViewFromComData<T, TView>(object comObject, Func<T, TView> createCallback)
	{
#if NETSTANDARD2_0
		return createCallback((T)comObject);
#else
		object key = typeof(TView);

		if (Marshal.GetComObjectData(comObject, key) is TView managedView)
		{
			return managedView;
		}
		managedView = createCallback((T)comObject);
		if (!Marshal.SetComObjectData(comObject, key, managedView))
		{
			managedView = (TView)Marshal.GetComObjectData(comObject, key)!;
		}
		return managedView;
#endif
	}
}

internal class EnumVariantViewOfEnumerator(IEnumerator enumerator) : IEnumVARIANT, ICustomAdapter
{
	public IEnumerator Enumerator { get; } = enumerator ?? throw new ArgumentNullException(nameof(enumerator));

	IEnumVARIANT IEnumVARIANT.Clone() => Enumerator is ICloneable clonable
			? new EnumVariantViewOfEnumerator((IEnumerator)clonable.Clone())
			: throw new COMException("Enumerator is not clonable.", HRESULT.E_FAIL);

	int IEnumVARIANT.Next(int celt, object?[] rgVar, IntPtr pceltFetched)
	{
		int numElements = 0;

		try
		{
			if (celt > 0 && rgVar == null)
				return HRESULT.E_INVALIDARG;

			while (numElements < celt && Enumerator.MoveNext())
				rgVar[numElements++] = Enumerator.Current;

			if (pceltFetched != IntPtr.Zero)
				Marshal.WriteInt32(pceltFetched, numElements);
		}
		catch (Exception e)
		{
			return e.HResult;
		}

		return numElements == celt ? HRESULT.S_OK : HRESULT.S_FALSE;
	}

	int IEnumVARIANT.Reset()
	{
		try
		{
			Enumerator.Reset();
			return HRESULT.S_OK;
		}
		catch (Exception e)
		{
			return e.HResult;
		}
	}

	int IEnumVARIANT.Skip(int celt)
	{
		try
		{
			for (; celt > 0 && Enumerator.MoveNext(); celt--) { }
			return celt == 0 ? HRESULT.S_OK : HRESULT.S_FALSE;
		}
		catch (Exception e)
		{
			return e.HResult;
		}
	}

	object ICustomAdapter.GetUnderlyingObject() => Enumerator;
}

internal class EnumeratorViewOfEnumVariant(IEnumVARIANT enumVariantObject) : ICustomAdapter, IEnumerator
{
	private readonly IEnumVARIANT _enumVariantObject = enumVariantObject;
	private bool _fetchedLastObject = false;
	private readonly object[] _nextArray = new object[1];

	object IEnumerator.Current => _nextArray[0];

	unsafe bool IEnumerator.MoveNext()
	{
		if (_fetchedLastObject)
			return false;

		int numFetched = 0;
		HRESULT hr = _enumVariantObject.Next(1, _nextArray, (IntPtr)(&numFetched));
		hr.ThrowIfFailed();
		if (hr == HRESULT.S_FALSE)
		{
			_fetchedLastObject = true;
			if (numFetched == 0)
				return false;
		}
		return true;
	}

	void IEnumerator.Reset()
	{
		HRESULT.ThrowIfFailed(_enumVariantObject.Reset());
		_fetchedLastObject = false;
	}

	public object GetUnderlyingObject() => _enumVariantObject;
}
#endif