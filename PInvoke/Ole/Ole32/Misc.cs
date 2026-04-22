namespace Vanara.PInvoke;

public static partial class Ole32
{
	/// <summary>
	/// Instantiates the appropriate interceptor for the specified interface to be intercepted and returns the newly created interceptor.
	/// </summary>
	/// <param name="iidIntercepted">A reference to the identifier of the interface for which an interceptor is to be returned.</param>
	/// <param name="punkOuter">
	/// If this parameter is <c>NULL</c>, the object is not being created as part of an aggregate. Otherwise, this parameter is a pointer
	/// to the aggregate object's IUnknown interface (the controlling <c>IUnknown</c>).
	/// </param>
	/// <param name="iid">A reference to the identifier of the interface desired on the interceptor.</param>
	/// <param name="ppv">
	/// The address of a pointer variable that receives the interface pointer requested in iid. Upon successful return, **ppv contains
	/// the requested interceptor pointer.
	/// </param>
	/// <returns>
	/// <para>This function can return the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function returned successfully.</term>
	/// </item>
	/// <item>
	/// <term>E_UNEXPECTED</term>
	/// <term>An unexpected error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/callobj/nf-callobj-cogetinterceptor HRESULT CoGetInterceptor( REFIID
	// iidIntercepted, IUnknown *punkOuter, REFIID iid, void **ppv );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("callobj.h", MSDNShortId = "d1ffee1d-f907-4091-b993-cf13d8ce616c")]
	public static extern HRESULT CoGetInterceptor(in Guid iidIntercepted, [MarshalAs(UnmanagedType.IUnknown), Optional] object? punkOuter,
		in Guid iid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

	/// <summary>
	/// The <c>StgConvertVariantToProperty</c> function converts a <c>PROPVARIANT</c> data type to a <c>SERIALIZEDPROPERTYVALUE</c> data type.
	/// </summary>
	/// <param name="pvar">A pointer to <c>PROPVARIANT</c>.</param>
	/// <param name="CodePage">A property set codepage.</param>
	/// <returns>Returns a <c>SERIALIZEDPROPERTYVALUE</c>.</returns>
	/// <remarks>
	/// This function converts a <c>PROPVARIANT</c> to a property. If the function fails it throws an exception that represents
	/// <c>STATUS_INVALID_PARAMETER NT_STATUS</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/propidl/nf-propidl-stgconvertvarianttoproperty SERIALIZEDPROPERTYVALUE *
	// StgConvertVariantToProperty( const PROPVARIANT *pvar, USHORT CodePage, SERIALIZEDPROPERTYVALUE *pprop, ULONG *pcb, PROPID pid,
	// BOOLEAN fReserved, ULONG *pcIndirect );
	[PInvokeData("propidl.h", MSDNShortId = "3d35b808-4fa6-44ec-9c46-96ceee1dafd0")]
	public static SERIALIZEDPROPERTYVALUE StgConvertVariantToProperty(in PROPVARIANT_UNMGD pvar, ushort CodePage) =>
		StgConvertVariantToProperty(in pvar, CodePage, 0, out _);

	/// <summary>
	/// The <c>StgConvertVariantToProperty</c> function converts a <c>PROPVARIANT</c> data type to a <c>SERIALIZEDPROPERTYVALUE</c> data type.
	/// </summary>
	/// <param name="pvar">A pointer to <c>PROPVARIANT</c>.</param>
	/// <param name="CodePage">A property set codepage.</param>
	/// <param name="pid">The propid (used if indirect).</param>
	/// <param name="pcIndirect">Optional. A pointer to the indirect property count.</param>
	/// <returns>Returns a <c>SERIALIZEDPROPERTYVALUE</c>.</returns>
	/// <remarks>
	/// This function converts a <c>PROPVARIANT</c> to a property. If the function fails it throws an exception that represents
	/// <c>STATUS_INVALID_PARAMETER NT_STATUS</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/propidl/nf-propidl-stgconvertvarianttoproperty SERIALIZEDPROPERTYVALUE *
	// StgConvertVariantToProperty( const PROPVARIANT *pvar, USHORT CodePage, SERIALIZEDPROPERTYVALUE *pprop, ULONG *pcb, PROPID pid,
	// BOOLEAN fReserved, ULONG *pcIndirect );
	[PInvokeData("propidl.h", MSDNShortId = "3d35b808-4fa6-44ec-9c46-96ceee1dafd0")]
	public static SERIALIZEDPROPERTYVALUE StgConvertVariantToProperty(in PROPVARIANT_UNMGD pvar, ushort CodePage, uint pid, out uint pcIndirect)
	{
		uint pcb = 0, _pcIndirect = 0;
		if (StgConvertVariantToProperty(in pvar, CodePage, IntPtr.Zero, ref pcb, pid, false, ref _pcIndirect) == IntPtr.Zero && pcb == 0)
			throw ((NTStatus)NTStatus.STATUS_INVALID_PARAMETER).GetException()!;
		using SafeCoTaskMemHandle mem = new(pcb);
		var p = StgConvertVariantToProperty(in pvar, CodePage, mem, ref pcb, pid, false, ref _pcIndirect);
		pcIndirect = _pcIndirect;
		var ret = mem.ToStructure<SERIALIZEDPROPERTYVALUE>();
		ret.rgb = mem.ToArray<byte>(pcb - 4, 4);
		return ret;

		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		static extern IntPtr StgConvertVariantToProperty(in PROPVARIANT_UNMGD pvar, ushort CodePage, [Out, Optional] IntPtr pprop, ref uint pcb,
			uint pid, [MarshalAs(UnmanagedType.U1), Optional] bool fReserved, ref uint pcIndirect);
	}

	/// <summary>
	/// The <c>StgPropertyLengthAsVariant</c> function examines a <c>SERIALIZEDPROPERTYVALUE</c> and returns the amount of memory that
	/// this property would occupy as a <c>PROPVARIANT</c>.
	/// </summary>
	/// <param name="pProp">A pointer to a <c>SERIALIZEDPROPERTYVALUE</c>.</param>
	/// <param name="CodePage">A property set code page.</param>
	/// <returns>Returns the amount of memory the property would occupy as a <c>PROPVARIANT</c>.</returns>
	/// <remarks>
	/// Use this function to decide whether or not to deserialize a property value in a low-memory scenario. Most applications will have
	/// no need to call this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/propapi/nf-propapi-stgpropertylengthasvariant ULONG StgPropertyLengthAsVariant(
	// const SERIALIZEDPROPERTYVALUE *pProp, ULONG cbProp, USHORT CodePage, BYTE bReserved );
	[PInvokeData("propapi.h", MSDNShortId = "3e809ca9-3038-4d92-bb56-23bd45b6b644")]
	public static uint StgPropertyLengthAsVariant(in SERIALIZEDPROPERTYVALUE pProp, ushort CodePage)
	{
		using SafeCoTaskMemHandle mem = new(4 + pProp.rgb.Length);
		mem.Write(pProp);
		mem.Write(pProp.rgb, false, 4);
		return StgPropertyLengthAsVariant(mem, (uint)mem.Size, CodePage, 0);

		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		static extern uint StgPropertyLengthAsVariant([In] IntPtr pProp, uint cbProp, ushort CodePage, byte bReserved = 0);
	}
}