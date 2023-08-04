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
	/// <param name="pprop">Optional. A pointer to <c>SERIALIZEDPROPERTYVALUE</c>.</param>
	/// <param name="pcb">A pointer to the remaining stream length, updated to the actual property size on return.</param>
	/// <param name="pid">The propid (used if indirect).</param>
	/// <param name="fReserved">Reserver. The value must be <c>FALSE</c>.</param>
	/// <param name="pcIndirect">Optional. A pointer to the indirect property count.</param>
	/// <returns>Returns a pointer to <c>SERIALIZEDPROPERTYVALUE</c>.</returns>
	/// <remarks>
	/// This function converts a <c>PROPVARIANT</c> to a property. If the function fails it throws an exception that represents
	/// <c>STATUS_INVALID_PARAMETER NT_STATUS</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/propidl/nf-propidl-stgconvertvarianttoproperty SERIALIZEDPROPERTYVALUE *
	// StgConvertVariantToProperty( const PROPVARIANT *pvar, USHORT CodePage, SERIALIZEDPROPERTYVALUE *pprop, ULONG *pcb, PROPID pid,
	// BOOLEAN fReserved, ULONG *pcIndirect );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propidl.h", MSDNShortId = "3d35b808-4fa6-44ec-9c46-96ceee1dafd0")]
	public static extern IntPtr StgConvertVariantToProperty([In] PROPVARIANT pvar, ushort CodePage, [Optional] IntPtr pprop, ref uint pcb,
		uint pid, [MarshalAs(UnmanagedType.U1), Optional] bool fReserved, ref uint pcIndirect);

	/// <summary>
	/// The <c>StgPropertyLengthAsVariant</c> function examines a <c>SERIALIZEDPROPERTYVALUE</c> and returns the amount of memory that
	/// this property would occupy as a <c>PROPVARIANT</c>.
	/// </summary>
	/// <param name="pProp">A pointer to a <c>SERIALIZEDPROPERTYVALUE</c>.</param>
	/// <param name="cbProp">The size of the pProp buffer in bytes.</param>
	/// <param name="CodePage">A property set code page.</param>
	/// <param name="bReserved">Reserved. Must be 0.</param>
	/// <returns>Returns the amount of memory the property would occupy as a <c>PROPVARIANT</c>.</returns>
	/// <remarks>
	/// Use this function to decide whether or not to deserialize a property value in a low-memory scenario. Most applications will have
	/// no need to call this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/propapi/nf-propapi-stgpropertylengthasvariant ULONG StgPropertyLengthAsVariant(
	// const SERIALIZEDPROPERTYVALUE *pProp, ULONG cbProp, USHORT CodePage, BYTE bReserved );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("propapi.h", MSDNShortId = "3e809ca9-3038-4d92-bb56-23bd45b6b644")]
	public static extern uint StgPropertyLengthAsVariant(IntPtr pProp, uint cbProp, ushort CodePage, byte bReserved = 0);
}