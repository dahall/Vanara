using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

public static partial class PropSys
{
	/// <summary>Describes property change array behavior.</summary>
	[PInvokeData("Propsys.h")]
	public enum PKA_FLAGS
	{
		/// <summary>Replace current value.</summary>
		PKA_SET = 0,

		/// <summary>Append to current value - multi-value properties only.</summary>
		PKA_APPEND = 1,

		/// <summary>Delete from current value - multi-value properties only.</summary>
		PKA_DELETE = 2
	}

	/// <summary>Exposes methods for getting and setting the property key.</summary>
	[PInvokeData("Propsys.h", MSDNShortId = "bb775404")]
	[ComImport, Guid("fc0ca0a7-c316-4fd2-9031-3e628e6d4f23"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IObjectWithPropertyKey
	{
		/// <summary>Sets the property key.</summary>
		/// <param name="key">The property key.</param>
		void SetPropertyKey(in PROPERTYKEY key);

		/// <summary>Gets the property key.</summary>
		/// <returns>When this returns, contains the property key.</returns>
		PROPERTYKEY GetPropertyKey();
	}

	/// <summary>Exposes a method that encapsulates a change to a single property.</summary>
	/// <seealso cref="Vanara.PInvoke.PropSys.IObjectWithPropertyKey"/>
	[PInvokeData("Propsys.h", MSDNShortId = "bb775244")]
	[ComImport, Guid("f917bc8a-1bba-4478-a245-1bde03eb9431"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPropertyChange : IObjectWithPropertyKey
	{
		/// <summary>Sets the property key.</summary>
		/// <param name="key">The property key.</param>
		new void SetPropertyKey(in PROPERTYKEY key);

		/// <summary>Gets the property key.</summary>
		/// <returns>When this returns, contains the property key.</returns>
		new PROPERTYKEY GetPropertyKey();

		/// <summary>Applies a change to a property value.</summary>
		/// <param name="propvarIn">A reference to a source PROPVARIANT structure.</param>
		/// <param name="ppropvarOut">A pointer to a changed PROPVARIANT structure.</param>
		void ApplyToPropVariant([In] PROPVARIANT propvarIn, out PROPVARIANT ppropvarOut);
	}

	/// <summary>Exposes methods for several multiple change operations that may be passed to IFileOperation.</summary>
	[PInvokeData("Propsys.h", MSDNShortId = "bb775223")]
	[ComImport, Guid("380f5cad-1b5e-42f2-805d-637fd392d31e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPropertyChangeArray
	{
		/// <summary>Gets the number of change operations in the array.</summary>
		/// <returns>The number of change operations.</returns>
		uint GetCount();

		/// <summary>Gets the change operation at a specified array index.</summary>
		/// <param name="iIndex">The index of the change to retrieve.</param>
		/// <param name="riid">A reference to the desired IID.</param>
		/// <returns>The address of a pointer to the interface specified by riid, usually IPropertyChange.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		object GetAt([In] uint iIndex, in Guid riid);

		/// <summary>Inserts a change operation into an array at the specified position.</summary>
		/// <param name="iIndex">The index at which the change is inserted.</param>
		/// <param name="ppropChange">A pointer to the interface that contains the change.</param>
		void InsertAt([In] uint iIndex, [In] IPropertyChange ppropChange);

		/// <summary>Inserts a change operation at the end of an array.</summary>
		/// <param name="ppropChange">A pointer to the interface that contains the change.</param>
		void Append([In] IPropertyChange ppropChange);

		/// <summary>
		/// Replaces the first occurrence of a change that affects the same property key as the provided change. If the property key is
		/// not already in the array, this method appends the change to the end of the array.
		/// </summary>
		/// <param name="ppropChange">A pointer to the interface that contains the change.</param>
		void AppendOrReplace([In] IPropertyChange ppropChange);

		/// <summary>Removes a specified change.</summary>
		/// <param name="iIndex">The index of the change to remove.</param>
		void RemoveAt([In] uint iIndex);

		/// <summary>Specifies whether a particular property key exists in the change array.</summary>
		/// <param name="key">A reference to the PROPERTYKEY structure of interest.</param>
		[PreserveSig] HRESULT IsKeyInArray(in PROPERTYKEY key);
	}

	/// <summary>Gets the change operation at a specified array index.</summary>
	/// <typeparam name="T">The type of the interface to retrieve.</typeparam>
	/// <param name="pca">The <see cref="IPropertyChangeArray"/> instance.</param>
	/// <param name="iIndex">The index of the change to retrieve.</param>
	/// <returns>The address of a pointer to the interface specified by <typeparamref name="T"/>, usually IPropertyChange.</returns>
	public static T GetAt<T>(this IPropertyChangeArray pca, [In] uint iIndex) where T : class => (T)pca.GetAt(iIndex, typeof(T).GUID);

	/// <summary>
	/// Creates a container for a set of IPropertyChange objects. This container can be used with IFileOperation to apply a set of
	/// property changes to a set of files.
	/// </summary>
	/// <param name="rgpropkey">
	/// Pointer to an array of PROPERTYKEY structures that name the specific properties whose changes are being stored. If this value is
	/// NULL, cChanges must be 0.
	/// </param>
	/// <param name="rgflags">Pointer to an array of PKA_FLAGS values. If this value is NULL, cChanges must be 0.</param>
	/// <param name="rgpropvar">Pointer to an array of PROPVARIANT structures. If this value is NULL, cChanges must be 0.</param>
	/// <param name="cChanges">
	/// Count of changes to be applied. This is the number of elements in each of the arrays rgpropkey, rgflags, and rgpropvar.
	/// </param>
	/// <param name="riid">Reference to the ID of the requested interface.</param>
	/// <param name="ppv">When this function returns, contains the interface pointer requested in riid. This is typically IPropertyChangeArray.</param>
	/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
	[DllImport(Lib.PropSys, ExactSpelling = true)]
	[PInvokeData("Propsys.h", MSDNShortId = "bb776491")]
	public static extern HRESULT PSCreatePropertyChangeArray(
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] PROPERTYKEY[] rgpropkey,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] PKA_FLAGS[] rgflags,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] PROPVARIANT[] rgpropvar,
		uint cChanges, in Guid riid, out IPropertyChangeArray ppv);

	/// <summary>Creates a simple property change.</summary>
	/// <param name="flags">PKA_FLAGS flags.</param>
	/// <param name="key">Reference to a PROPERTYKEY structure.</param>
	/// <param name="propvar">Reference to a PROPVARIANT structure.</param>
	/// <param name="riid">Reference to a specified IID.</param>
	/// <param name="ppv">The address of an IPropertyChange interface pointer.</param>
	/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
	[DllImport(Lib.PropSys, ExactSpelling = true)]
	[PInvokeData("Propsys.h", MSDNShortId = "bb776494")]
	public static extern HRESULT PSCreateSimplePropertyChange([In] PKA_FLAGS flags, in PROPERTYKEY key,
		[In] PROPVARIANT propvar, in Guid riid, out IPropertyChange ppv);
}