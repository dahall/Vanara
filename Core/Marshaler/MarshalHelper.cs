namespace Vanara.InteropServices;

/// <summary>Provides helper methods for marshaling data between native memory and managed objects using custom marshallers.</summary>
public static class MarshalHelper
{
	/// <summary>
	/// Marshals a managed object of type specified by <typeparamref name="TOut"/> from a native byte buffer using the specified marshaller type.
	/// </summary>
	/// <remarks>
	/// The method uses the specified marshaller to convert native data in the provided byte span to a managed object. The caller is
	/// responsible for ensuring that the byte span contains valid data for the target managed type and marshaller.
	/// </remarks>
	/// <typeparam name="TMarshaller">
	/// The custom marshaller type to use for converting native data to managed objects. Must implement ICustomMarshaler, IVanaraMarshaler,
	/// or be attributed with CustomMarshaller.
	/// </typeparam>
	/// <typeparam name="TOut">The type of the managed object to be created from the native data.</typeparam>
	/// <param name="bytes">A span of bytes containing the native data to be marshaled into a managed object. Must not be empty.</param>
	/// <returns>
	/// An instance of <typeparamref name="TOut"/> representing the marshaled data, or the default value of <typeparamref name="TOut"/> if
	/// the input span is empty.
	/// </returns>
	/// <exception cref="InvalidOperationException">
	/// Thrown if the specified marshaller type does not implement the required interfaces or attribute, or if an error occurs during marshaling.
	/// </exception>
	public static TOut? MarshalFromNative<TMarshaller, TOut>(Span<byte> bytes)
	{
		if (bytes.IsEmpty)
			return default;
		if (VanaraMarshaler.CanMarshal<TOut>(out var vm))
		{
			try
			{
				unsafe
				{
					fixed (byte* pNativeData = &bytes[0])
						return (TOut?)vm.MarshalNativeToManaged((nint)pNativeData, (PInvoke.SizeT)bytes.Length);
				}
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException($"An error occurred while marshaling data from native to managed using the VanaraMarshaler for type {typeof(TOut).FullName}. See inner exception for details.", ex);
			}
		}
		else
			throw new InvalidOperationException($"The specified marshaller type {typeof(TMarshaller).FullName} does not implement ICustomMarshaler or IVanaraMarshaler or carry the CustomMarshaller attribute.");
	}
}