using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Exposes methods to enumerate unknown objects.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ienumobjects
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IEnumObjects")]
	[ComImport, Guid("2c1c7e2e-2d0e-4059-831e-1e6f82335c2e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumObjects : Vanara.Collections.ICOMEnum<object>
	{
		/// <summary>Gets the next specified number and type of objects.</summary>
		/// <param name="celt">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of objects to retrieve.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>Reference to the desired interface ID.</para>
		/// </param>
		/// <param name="rgelt">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this method returns, contains the interface pointer requested in riid.</para>
		/// </param>
		/// <param name="pceltFetched">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>
		/// Pointer to a <c>ULONG</c> value that, when this method returns, states the actual number of objects retrieved. This value
		/// can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK if the method successfully retrieved the requested objects. This method only returns S_OK if the full count of
		/// requested items are successfully retrieved.
		/// </para>
		/// <para>S_FALSE indicates that more items were requested than remained in the enumeration.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ienumobjects-next HRESULT Next( ULONG celt,
		// REFIID riid, void **rgelt, ULONG *pceltFetched );
		[PreserveSig]
		HRESULT Next(uint celt, in Guid riid, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] object[] rgelt, out uint pceltFetched);

		/// <summary>Skips a specified number of objects.</summary>
		/// <param name="celt">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of objects to skip.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>Enumeration index is advanced by the number of items skipped.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ienumobjects-skip HRESULT Skip( ULONG celt );
		[PreserveSig]
		HRESULT Skip(uint celt);

		/// <summary>Resets the enumeration index to 0.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ienumobjects-reset HRESULT Reset();
		void Reset();

		/// <summary>
		/// <para>Not implemented.</para>
		/// <para>Not implemented.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>IEnumObjects**</c></para>
		/// <para>Not used.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ienumobjects-clone HRESULT Clone(
		// IEnumObjects **ppenum );
		IEnumObjects Clone();
	}
}