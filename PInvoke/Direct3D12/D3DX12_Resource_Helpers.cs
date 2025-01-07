using System.Diagnostics;
using static Vanara.PInvoke.FunctionHelper;

namespace Vanara.PInvoke;

public static partial class D3D12
{
	/// <summary>Outputs the mip slice, array slice, and plane slice that correspond to the specified subresource index.</summary>
	/// <param name="Subresource">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The index of the subresource.</para>
	/// </param>
	/// <param name="MipLevels">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The maximum number of mipmap levels in the subresource.</para>
	/// </param>
	/// <param name="ArraySize">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The number of elements in the array.</para>
	/// </param>
	/// <param name="MipSlice">
	/// <para>Type: <b>T</b></para>
	/// <para>Outputs the mip slice that corresponds to the given subresource index.</para>
	/// </param>
	/// <param name="ArraySlice">
	/// <para>Type: <b>U</b></para>
	/// <para>Outputs the array slice that corresponds to the given subresource index.</para>
	/// </param>
	/// <param name="PlaneSlice">
	/// <para>Type: <b>V</b></para>
	/// <para>Outputs the plane slice that corresponds to the given subresource index.</para>
	/// </param>
	/// <returns>This method does not return a value.</returns>
	/// <remarks>
	/// <para>
	/// This function determines which mip slice, array slice, and plane slice correspond to a given subresource index. This is a useful
	/// utility, though it is C++ specific.
	/// </para>
	/// <para>This function is declared as follows, with C++ templatized parameters for types <b>T</b>, <b>U</b>, and <b>V</b>:</para>
	/// <para>
	/// <c>template &lt;typename T, typename U, typename V&gt; inline void D3D12DecomposeSubresource( UINT Subresource, UINT MipLevels, UINT
	/// ArraySize, _Out_ T&amp; MipSlice, _Out_ U&amp; ArraySlice, _Out_ V&amp; PlaneSlice ) { MipSlice = static_cast&lt;T&gt;(Subresource %
	/// MipLevels); ArraySlice = static_cast&lt;U&gt;((Subresource / MipLevels) % ArraySize); PlaneSlice = static_cast&lt;V&gt;(Subresource
	/// / (MipLevels * ArraySize)); }</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/d3d12decomposesubresource void inline D3D12DecomposeSubresource( UINT
	// Subresource, UINT MipLevels, UINT ArraySize, _Out_ T &amp;MipSlice, _Out_ U &amp;ArraySlice, _Out_ V &amp;PlaneSlice );
	[PInvokeData("D3dx12.h")]
	public static void D3D12DecomposeSubresource<T, U, V>(uint Subresource, uint MipLevels, uint ArraySize, out T MipSlice, out U ArraySlice, out V PlaneSlice) where T : IConvertible where U : IConvertible where V : IConvertible
	{
		MipSlice = (T)Convert.ChangeType(Subresource % MipLevels, typeof(T));
		ArraySlice = (U)Convert.ChangeType(Subresource / MipLevels % ArraySize, typeof(U));
		PlaneSlice = (V)Convert.ChangeType(Subresource / (MipLevels * ArraySize), typeof(V));
	}

	/// <summary>Indicates whether the layout is opaque.</summary>
	/// <param name="Layout">
	/// <para>Type: <b><c><b>D3D12_TEXTURE_LAYOUT</b></c></b></para>
	/// <para>The layout to check, as a <c><b>D3D12_TEXTURE_LAYOUT</b></c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b>bool</b></para>
	/// <para>A <b>bool</b> that indicates whether the layout is opaque. A layout is opaque if it is D3D12_TEXTURE_LAYOUT_UNKNOWN or D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/d3d12islayoutopaque bool inline D3D12IsLayoutOpaque( D3D12_TEXTURE_LAYOUT
	// Layout );
	[PInvokeData("D3dx12.h")]
	public static bool D3D12IsLayoutOpaque(D3D12_TEXTURE_LAYOUT Layout) => Layout is D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_UNKNOWN or D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE;

	/// <summary/>
	public static T D3DX12Align<T>(T uValue, T uAlign) where T : unmanaged, IConvertible
	{
		// Assert power of 2 alignment
		ulong ulValue = uValue.ToUInt64(null);
		ulong ulAlign = uAlign.ToUInt64(null);
		Debug.Assert(0 == (ulAlign & (ulAlign - 1)));
		ulong uMask = ulAlign - 1;
		ulong uResult = (ulValue + uMask) & ~uMask;
		Debug.Assert(uResult >= ulValue);
		Debug.Assert(0 == uResult % ulAlign);
		return (T)Convert.ChangeType(uResult, typeof(T));
	}

	/// <summary/>
	public static T D3DX12AlignAtLeast<T>(T uValue, T uAlign) where T : unmanaged, IConvertible
	{
		T aligned = D3DX12Align(uValue, uAlign);
		return aligned.ToUInt64(null) > uAlign.ToUInt64(null) ? aligned : uAlign;
	}

	/// <summary>
	/// Gets a resource layout that can be copied. Helps your app fill in <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> and
	/// <c>D3D12_SUBRESOURCE_FOOTPRINT</c> when suballocating space in upload heaps.
	/// <para>
	/// The difference between D3DX12GetCopyableFootprints and ID3D12Device.GetCopyableFootprints is that this one loses a lot of error
	/// checking by assuming the arguments are correct.
	/// </para>
	/// </summary>
	/// <param name="pResourceDesc">
	/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
	/// <para>A description of the resource, as a pointer to a <b>D3D12_RESOURCE_DESC</b> structure.</para>
	/// </param>
	/// <param name="FirstSubresource">
	/// <para>Type: [in] <b>UINT</b></para>
	/// <para>Index of the first subresource in the resource. The range of valid values is 0 to D3D12_REQ_SUBRESOURCES.</para>
	/// </param>
	/// <param name="NumSubresources">
	/// <para>Type: [in] <b>UINT</b></para>
	/// <para>The number of subresources in the resource. The range of valid values is 0 to (D3D12_REQ_SUBRESOURCES - <i>FirstSubresource</i>).</para>
	/// </param>
	/// <param name="BaseOffset">
	/// <para>Type: <b>UINT64</b></para>
	/// <para>The offset, in bytes, to the resource.</para>
	/// </param>
	/// <param name="pLayouts">
	/// <para>Type: [out, optional] <b><c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c>*</b></para>
	/// <para>
	/// A pointer to an array (of length <i>NumSubresources</i>) of <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> structures, to be filled with
	/// the description and placement of each subresource.
	/// </para>
	/// </param>
	/// <param name="pNumRows">
	/// <para>Type: [out, optional] <b>UINT*</b></para>
	/// <para>
	/// A pointer to an array (of length <i>NumSubresources</i>) of integer variables, to be filled with the number of rows for each subresource.
	/// </para>
	/// </param>
	/// <param name="pRowSizeInBytes">
	/// <para>Type: [out, optional] <b>UINT64*</b></para>
	/// <para>
	/// A pointer to an array (of length <i>NumSubresources</i>) of integer variables, each entry to be filled with the unpadded size in
	/// bytes of a row, of each subresource.
	/// </para>
	/// <para>For example, if a Texture2D resource has a width of 32 and bytes per pixel of 4, then <i>pRowSizeInBytes</i> returns 128.</para>
	/// <para>
	/// <i>pRowSizeInBytes</i> should not be confused with <b>row pitch</b>, as examining <i>pLayouts</i> and getting the row pitch from
	/// that will give you 256 as it is aligned to D3D12_TEXTURE_DATA_PITCH_ALIGNMENT.
	/// </para>
	/// </param>
	/// <param name="pTotalBytes">
	/// <para>Type: [out, optional] <b>UINT64*</b></para>
	/// <para>A pointer to an integer variable, to be filled with the total size, in bytes.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>For remarks and examples, see <c>ID3D12Device.GetCopyableFootprints</c>.</remarks>
	[PInvokeData("d3d12.h", MSDNShortId = "NF:d3d12.ID3D12Device8.GetCopyableFootprints1")]
	public static bool D3DX12GetCopyableFootprints(in D3D12_RESOURCE_DESC pResourceDesc, uint FirstSubresource,
		uint NumSubresources, ulong BaseOffset, [Out] D3D12_PLACED_SUBRESOURCE_FOOTPRINT[] pLayouts,
		[Out] uint[] pNumRows, [Out] ulong[] pRowSizeInBytes, out ulong pTotalBytes)
	{
		// From D3D12_RESOURCE_DESC to D3D12_RESOURCE_DESC1
		D3D12_RESOURCE_DESC1 desc = new(pResourceDesc);
		return D3DX12GetCopyableFootprints(desc, // From D3D12_RESOURCE_DESC1 to CD3DX12_RESOURCE_DESC1
			FirstSubresource, NumSubresources, BaseOffset, pLayouts, pNumRows, pRowSizeInBytes, out pTotalBytes);
	}

	/// <summary>
	/// Gets a resource layout that can be copied. Helps your app fill in <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> and
	/// <c>D3D12_SUBRESOURCE_FOOTPRINT</c> when suballocating space in upload heaps.
	/// <para>
	/// The difference between D3DX12GetCopyableFootprints and ID3D12Device.GetCopyableFootprints is that this one loses a lot of error
	/// checking by assuming the arguments are correct.
	/// </para>
	/// </summary>
	/// <param name="ResourceDesc">
	/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC1</c>*</b></para>
	/// <para>A description of the resource, as a pointer to a <b>D3D12_RESOURCE_DESC1</b> structure.</para>
	/// </param>
	/// <param name="FirstSubresource">
	/// <para>Type: [in] <b>UINT</b></para>
	/// <para>Index of the first subresource in the resource. The range of valid values is 0 to D3D12_REQ_SUBRESOURCES.</para>
	/// </param>
	/// <param name="NumSubresources">
	/// <para>Type: [in] <b>UINT</b></para>
	/// <para>The number of subresources in the resource. The range of valid values is 0 to (D3D12_REQ_SUBRESOURCES - <i>FirstSubresource</i>).</para>
	/// </param>
	/// <param name="BaseOffset">
	/// <para>Type: <b>UINT64</b></para>
	/// <para>The offset, in bytes, to the resource.</para>
	/// </param>
	/// <param name="pLayouts">
	/// <para>Type: [out, optional] <b><c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c>*</b></para>
	/// <para>
	/// A pointer to an array (of length <i>NumSubresources</i>) of <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> structures, to be filled with
	/// the description and placement of each subresource.
	/// </para>
	/// </param>
	/// <param name="pNumRows">
	/// <para>Type: [out, optional] <b>UINT*</b></para>
	/// <para>
	/// A pointer to an array (of length <i>NumSubresources</i>) of integer variables, to be filled with the number of rows for each subresource.
	/// </para>
	/// </param>
	/// <param name="pRowSizeInBytes">
	/// <para>Type: [out, optional] <b>UINT64*</b></para>
	/// <para>
	/// A pointer to an array (of length <i>NumSubresources</i>) of integer variables, each entry to be filled with the unpadded size in
	/// bytes of a row, of each subresource.
	/// </para>
	/// <para>For example, if a Texture2D resource has a width of 32 and bytes per pixel of 4, then <i>pRowSizeInBytes</i> returns 128.</para>
	/// <para>
	/// <i>pRowSizeInBytes</i> should not be confused with <b>row pitch</b>, as examining <i>pLayouts</i> and getting the row pitch from
	/// that will give you 256 as it is aligned to D3D12_TEXTURE_DATA_PITCH_ALIGNMENT.
	/// </para>
	/// </param>
	/// <param name="pTotalBytes">
	/// <para>Type: [out, optional] <b>UINT64*</b></para>
	/// <para>A pointer to an integer variable, to be filled with the total size, in bytes.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>For remarks and examples, see <c>ID3D12Device.GetCopyableFootprints</c>.</remarks>
	[PInvokeData("d3d12.h", MSDNShortId = "NF:d3d12.ID3D12Device8.GetCopyableFootprints1")]
	public static bool D3DX12GetCopyableFootprints(in D3D12_RESOURCE_DESC1 ResourceDesc, uint FirstSubresource, uint NumSubresources,
		ulong BaseOffset, [Out] D3D12_PLACED_SUBRESOURCE_FOOTPRINT[] pLayouts, [Out] uint[] pNumRows, [Out] ulong[] pRowSizeInBytes,
		out ulong pTotalBytes)
	{
		if (pLayouts is not null && pLayouts.Length != NumSubresources || pNumRows is not null && pNumRows.Length != NumSubresources || pRowSizeInBytes is not null && pRowSizeInBytes.Length != NumSubresources)
			throw new ArgumentException("The length of the arrays must be equal to NumSubresources.");

		bool bResourceOverflow = false;
		ulong TotalBytes = 0;
		DXGI_FORMAT Format = ResourceDesc.Format;
		D3D12_RESOURCE_DESC1 LresourceDesc = default;
		ref readonly D3D12_RESOURCE_DESC1 resourceDesc = ref D3D12_RESOURCE_DESC1.D3DX12ConditionallyExpandAPIDesc(ref LresourceDesc, ResourceDesc);

		// Check if its a valid format
		Debug.Assert(D3D12_PROPERTY_LAYOUT_FORMAT_TABLE.FormatExists(Format));

		uint WidthAlignment = D3D12_PROPERTY_LAYOUT_FORMAT_TABLE.GetWidthAlignment(Format);
		uint HeightAlignment = D3D12_PROPERTY_LAYOUT_FORMAT_TABLE.GetHeightAlignment(Format);
		ushort DepthAlignment = (ushort)D3D12_PROPERTY_LAYOUT_FORMAT_TABLE.GetDepthAlignment(Format);

		uint uSubRes = 0;
		for (; uSubRes < NumSubresources; ++uSubRes)
		{
			bool bOverflow = false;
			uint Subresource = FirstSubresource + uSubRes;

			Debug.Assert(resourceDesc.MipLevels != 0);
			uint subresourceCount = (uint)resourceDesc.MipLevels * resourceDesc.ArraySize * D3D12_PROPERTY_LAYOUT_FORMAT_TABLE.GetPlaneCount(resourceDesc.Format);
			if (Subresource > subresourceCount)
			{
				break;
			}

			TotalBytes = D3DX12Align<ulong>(TotalBytes, D3D12_TEXTURE_DATA_PLACEMENT_ALIGNMENT);

			D3D12DecomposeSubresource(Subresource, resourceDesc.MipLevels, resourceDesc.ArraySize, out uint MipLevel, out uint ArraySlice, out uint PlaneSlice);

			ulong Width = D3DX12AlignAtLeast<ulong>(resourceDesc.Width >> (int)MipLevel, WidthAlignment);
			uint Height = D3DX12AlignAtLeast<uint>(resourceDesc.Height >> (int)MipLevel, HeightAlignment);
			ushort Depth = D3DX12AlignAtLeast<ushort>((ushort)(resourceDesc.Depth >> (int)MipLevel), DepthAlignment);

			// Adjust for the current PlaneSlice. Most formats have only one plane.
			D3D12_PROPERTY_LAYOUT_FORMAT_TABLE.GetPlaneSubsampledSizeAndFormatForCopyableLayout(PlaneSlice, Format, (uint)Width, Height,
				out var PlaneFormat, out var MinPlanePitchWidth, out var PlaneWidth, out var PlaneHeight);

			D3D12_SUBRESOURCE_FOOTPRINT Placement = pLayouts is not null ? pLayouts[uSubRes].Footprint : default;
			Placement.Format = PlaneFormat;
			Placement.Width = PlaneWidth;
			Placement.Height = PlaneHeight;
			Placement.Depth = Depth;

			// Calculate row pitch
			D3D12_PROPERTY_LAYOUT_FORMAT_TABLE.CalculateMinimumRowMajorRowPitch(PlaneFormat, MinPlanePitchWidth, out var MinPlaneRowPitch);

			// Formats with more than one plane choose a larger pitch alignment to ensure that each plane begins on the row immediately
			// following the previous plane while still adhering to subresource alignment restrictions.
			Debug.Assert(D3D12_TEXTURE_DATA_PLACEMENT_ALIGNMENT >= D3D12_TEXTURE_DATA_PITCH_ALIGNMENT
				&& D3D12_TEXTURE_DATA_PLACEMENT_ALIGNMENT % D3D12_TEXTURE_DATA_PITCH_ALIGNMENT == 0,
				"D3D12_TEXTURE_DATA_PLACEMENT_ALIGNMENT must be >= and evenly divisible by D3D12_TEXTURE_DATA_PITCH_ALIGNMENT.");

			Placement.RowPitch = D3D12_PROPERTY_LAYOUT_FORMAT_TABLE.Planar(Format)
				? D3DX12Align<uint>(MinPlaneRowPitch, D3D12_TEXTURE_DATA_PLACEMENT_ALIGNMENT)
				: D3DX12Align<uint>(MinPlaneRowPitch, D3D12_TEXTURE_DATA_PITCH_ALIGNMENT);

			if (pRowSizeInBytes is not null)
			{
				D3D12_PROPERTY_LAYOUT_FORMAT_TABLE.CalculateMinimumRowMajorRowPitch(PlaneFormat, PlaneWidth, out var PlaneRowSize);
				pRowSizeInBytes[uSubRes] = PlaneRowSize;
			}

			// Number of rows (accounting for block compression and additional planes)
			uint NumRows;
			if (D3D12_PROPERTY_LAYOUT_FORMAT_TABLE.Planar(Format))
			{
				NumRows = PlaneHeight;
			}
			else
			{
				Debug.Assert(Height % HeightAlignment == 0);
				NumRows = Height / HeightAlignment;
			}

			if (pNumRows is not null)
			{
				pNumRows[uSubRes] = NumRows;
			}

			// Offsetting
			if (pLayouts is not null)
			{
				pLayouts[uSubRes].Offset = bOverflow ? ulong.MaxValue : TotalBytes + BaseOffset;
			}

			ushort NumSlices = Depth;
			ulong SubresourceSize = (NumRows * NumSlices - 1) * Placement.RowPitch + MinPlaneRowPitch;

			// uint64 addition with overflow checking
			TotalBytes += SubresourceSize;
			if (TotalBytes < SubresourceSize)
			{
				TotalBytes = ulong.MaxValue;
			}
			bResourceOverflow = bResourceOverflow || bOverflow;
		}

		// Overflow error
		if (bResourceOverflow)
		{
			TotalBytes = ulong.MaxValue;
		}

		for (; uSubRes < NumSubresources; uSubRes++)
		{
			if (pLayouts is not null)
			{
				pLayouts[uSubRes] = default;
			}
			if (pNumRows is not null)
			{
				pNumRows[uSubRes] = uint.MaxValue;
			}
			if (pRowSizeInBytes is not null)
			{
				pRowSizeInBytes[uSubRes] = ushort.MaxValue;
			}
		}

		return (pTotalBytes = TotalBytes) != ulong.MaxValue;
	}

	/// <summary>Returns the required size of a buffer to be used for data upload.</summary>
	/// <param name="pDestinationResource">
	/// <para>Type: <b><c><b>ID3D12Resource</b></c>*</b></para>
	/// <para>A pointer to the <c><b>ID3D12Resource</b></c> interface that represents the destination resource.</para>
	/// </param>
	/// <param name="FirstSubresource">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The index of the first subresource in the resource. The range of valid values is 0 to D3D12_REQ_SUBRESOURCES.</para>
	/// </param>
	/// <param name="NumSubresources">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The number of subresources in the resource. The range of valid values is 0 to (D3D12_REQ_SUBRESOURCES - FirstSubresource).</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c><b>UINT64</b></c></b></para>
	/// <para>The size of the buffer, in bytes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/getrequiredintermediatesize UINT64 inline GetRequiredIntermediateSize(
	// _In_ ID3D12Resource *pDestinationResource, _In_ UINT FirstSubresource, _In_ UINT NumSubresources );
	[PInvokeData("D3dx12.h")]
	public static ulong GetRequiredIntermediateSize([In] ID3D12Resource pDestinationResource, uint FirstSubresource, int NumSubresources)
	{
		pDestinationResource.GetDesc(out var Desc);

		pDestinationResource.GetDevice(typeof(ID3D12Device).GUID, out var ppv).ThrowIfFailed();
		ID3D12Device pDevice = (ID3D12Device)ppv!;
		pDevice.GetCopyableFootprints(Desc, FirstSubresource, NumSubresources, 0, null, null, null, out var RequiredSize);
		Marshal.ReleaseComObject(pDevice);

		return RequiredSize;
	}

	/// <summary>Copies a subresource row by row.</summary>
	/// <param name="pDest">
	/// <para>Type: <b>const <c><b>D3D12_MEMCPY_DEST</b></c>*</b></para>
	/// <para>A pointer to a <c><b>D3D12_MEMCPY_DEST</b></c> structure that describes the destination of the memory copy operation.</para>
	/// </param>
	/// <param name="pSrc">
	/// <para>Type: <b>const <c><b>D3D12_SUBRESOURCE_DATA</b></c>*</b></para>
	/// <para>A pointer to a <c><b>D3D12_SUBRESOURCE_DATA</b></c> structure that describes the source of the memory copy operation.</para>
	/// </param>
	/// <param name="RowSizeInBytes">
	/// <para>Type: <b><c><b>SIZE_T</b></c></b></para>
	/// <para>The size, in bytes, of each row.</para>
	/// </param>
	/// <param name="NumRows">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The number of rows.</para>
	/// </param>
	/// <param name="NumSlices">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The number of slices.</para>
	/// </param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// <para>Also consider the following methods:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><c><b>ID3D12Resource.WriteToSubresource</b></c></description>
	/// </item>
	/// <item>
	/// <description><c><b>ID3D12Resource.ReadFromSubresource</b></c></description>
	/// </item>
	/// <item>
	/// <description><c><b>ID3D12GraphicsCommandList.CopyResource</b></c></description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/memcpysubresource void inline MemcpySubresource( _In_ const
	// D3D12_MEMCPY_DEST *pDest, _In_ const D3D12_SUBRESOURCE_DATA *pSrc, SIZE_T RowSizeInBytes, UINT NumRows, UINT NumSlices );
	[PInvokeData("D3dx12.h")]
	public static void MemcpySubresource(in D3D12_MEMCPY_DEST pDest, in D3D12_SUBRESOURCE_DATA pSrc, SizeT RowSizeInBytes, uint NumRows, uint NumSlices)
	{
		for (uint z = 0; z < NumSlices; ++z)
		{
			var pDestSlice = pDest.pData + pDest.SlicePitch * z;
			var pSrcSlice = pSrc.pData + pSrc.SlicePitch * z;
			for (uint y = 0; y < NumRows; ++y)
			{
				IntPtr src = pSrcSlice + pSrc.RowPitch * y;
				src.CopyTo(pDestSlice + pDest.RowPitch * y, RowSizeInBytes);
			}
		}
	}

	/// <summary>Copies a subresource row by row.</summary>
	/// <param name="pDest">
	/// <para>Type: <b>const <c><b>D3D12_MEMCPY_DEST</b></c>*</b></para>
	/// <para>A pointer to a <c><b>D3D12_MEMCPY_DEST</b></c> structure that describes the destination of the memory copy operation.</para>
	/// </param>
	/// <param name="pResourceData">The resource data.</param>
	/// <param name="pSrc">
	/// <para>Type: <b>const <c><b>D3D12_SUBRESOURCE_INFO</b></c>*</b></para>
	/// <para>A pointer to a <c><b>D3D12_SUBRESOURCE_INFO</b></c> structure that describes the source of the memory copy operation.</para>
	/// </param>
	/// <param name="RowSizeInBytes">
	/// <para>Type: <b><c><b>SIZE_T</b></c></b></para>
	/// <para>The size, in bytes, of each row.</para>
	/// </param>
	/// <param name="NumRows">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The number of rows.</para>
	/// </param>
	/// <param name="NumSlices">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The number of slices.</para>
	/// </param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// <para>Also consider the following methods:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><c><b>ID3D12Resource.WriteToSubresource</b></c></description>
	/// </item>
	/// <item>
	/// <description><c><b>ID3D12Resource.ReadFromSubresource</b></c></description>
	/// </item>
	/// <item>
	/// <description><c><b>ID3D12GraphicsCommandList.CopyResource</b></c></description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/memcpysubresource void inline MemcpySubresource( _In_ const
	// D3D12_MEMCPY_DEST *pDest, _In_ const D3D12_SUBRESOURCE_DATA *pSrc, SIZE_T RowSizeInBytes, UINT NumRows, UINT NumSlices );
	[PInvokeData("D3dx12.h")]
	public static void MemcpySubresource(in D3D12_MEMCPY_DEST pDest, [In] IntPtr pResourceData, in D3D12_SUBRESOURCE_INFO pSrc, SizeT RowSizeInBytes, uint NumRows, uint NumSlices)
	{
		for (uint z = 0; z < NumSlices; ++z)
		{
			var pDestSlice = pDest.pData + pDest.SlicePitch * z;
			var pSrcSlice = pResourceData.Offset((long)pSrc.Offset + pSrc.DepthPitch * (long)z);
			for (uint y = 0; y < NumRows; ++y)
			{
				IntPtr src = pSrcSlice.Offset(pSrc.RowPitch * (long)y);
				src.CopyTo(pDestSlice + pDest.RowPitch * y, RowSizeInBytes);
			}
		}
	}

	/// <summary>Updates subresources, all the subresource arrays should be populated, typically by calling <c><b>ID3D12Device.GetCopyableFootprints</b></c>.</summary>
	/// <param name="pCmdList">
	/// <para>Type: <b><c><b>ID3D12GraphicsCommandList</b></c>*</b></para>
	/// <para>The command list, as a pointer to an <c><b>ID3D12GraphicsCommandList</b></c>.</para>
	/// </param>
	/// <param name="pDestinationResource">
	/// <para>Type: <b><c><b>ID3D12Resource</b></c>*</b></para>
	/// <para>The destination resource, as a pointer to an <c><b>ID3D12Resource</b></c>.</para>
	/// </param>
	/// <param name="pIntermediate">
	/// <para>Type: <b><c><b>ID3D12Resource</b></c>*</b></para>
	/// <para>The intermediate resource, as a pointer to an <c><b>ID3D12Resource</b></c>.</para>
	/// </param>
	/// <param name="FirstSubresource">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The index of the first subresource in the resource. The range of valid values is 0 to D3D12_REQ_SUBRESOURCES.</para>
	/// </param>
	/// <param name="NumSubresources">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The number of subresources in the resource. The range of valid values is 0 to (D3D12_REQ_SUBRESOURCES - FirstSubresource).</para>
	/// </param>
	/// <param name="RequiredSize">
	/// <para>Type: <b><c><b>UINT64</b></c></b></para>
	/// <para>The required size, in bytes, for the update.</para>
	/// </param>
	/// <param name="pLayouts">
	/// <para>Type: <b>const <c><b>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</b></c>*</b></para>
	/// <para>
	/// Pointer to an array (of length NumSubresources) of pointers to the structures that contains the description and placement of the
	/// resource's subresources.
	/// </para>
	/// </param>
	/// <param name="pNumRows">
	/// <para>Type: <b>const <c><b>UINT</b></c>*</b></para>
	/// <para>Pointer to an array (of length NumSubresources) of UINTS containing the number of rows for each subresource.</para>
	/// </param>
	/// <param name="pRowSizesInBytes">
	/// <para>Type: <b>const <c><b>UINT64</b></c>*</b></para>
	/// <para>Pointer to an array (of length NumSubresources) of UINTS containing the size, in bytes, of each row.</para>
	/// </param>
	/// <param name="pSrcData">
	/// <para>Type: <b>const <c><b>D3D12_SUBRESOURCE_DATA</b></c>*</b></para>
	/// <para>
	/// Pointer to an array (of length NumSubresources) of pointers to <c><b>D3D12_SUBRESOURCE_DATA</b></c> structures containing
	/// descriptions of the subresource data used for the update.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c><b>UINT64</b></c></b></para>
	/// <para>The size, in bytes, of the buffer.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/updatesubresources1 UINT64 inline UpdateSubresources( _In_
	// ID3D12GraphicsCommandList *pCmdList, _In_ ID3D12Resource *pDestinationResource, _In_ ID3D12Resource *pIntermediate, _In_ UINT
	// FirstSubresource, _In_ UINT NumSubresources, UINT64 RequiredSize, _In_ const D3D12_PLACED_SUBRESOURCE_FOOTPRINT *pLayouts, _In_ const
	// UINT *pNumRows, _In_ const UINT64 *pRowSizesInBytes, _In_ const D3D12_SUBRESOURCE_DATA *pSrcData );
	[PInvokeData("D3dx12.h")]
	public static ulong UpdateSubresources([In] ID3D12GraphicsCommandList pCmdList, [In] ID3D12Resource pDestinationResource,
		[In] ID3D12Resource pIntermediate, uint FirstSubresource, int NumSubresources, ulong RequiredSize,
		[In] D3D12_PLACED_SUBRESOURCE_FOOTPRINT[] pLayouts, [In] uint[] pNumRows,
		[In] ulong[] pRowSizesInBytes, [In] D3D12_SUBRESOURCE_DATA[] pSrcData)
	{
		// Minor validation
		pIntermediate.GetDesc(out var IntermediateDesc);
		pDestinationResource.GetDesc(out var DestinationDesc);
		if (IntermediateDesc.Dimension != D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER ||
			IntermediateDesc.Width < RequiredSize + pLayouts[0].Offset ||
			RequiredSize > ulong.MaxValue ||
			DestinationDesc.Dimension == D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER &&
			(FirstSubresource != 0 || NumSubresources != 1))
		{
			return 0;
		}

		if (pIntermediate.Map(0, null, out var pData).Failed)
		{
			return 0;
		}

		for (uint i = 0; i < NumSubresources; ++i)
		{
			if (pRowSizesInBytes[i] > ulong.MaxValue) return 0;
			D3D12_MEMCPY_DEST DestData = new() { pData = pData.Offset((long)pLayouts[i].Offset), RowPitch = pLayouts[i].Footprint.RowPitch, SlicePitch = pLayouts[i].Footprint.RowPitch * pNumRows[i] };
			MemcpySubresource(DestData, pSrcData[i], pRowSizesInBytes[i], pNumRows[i], pLayouts[i].Footprint.Depth);
		}
		pIntermediate.Unmap(0);

		if (DestinationDesc.Dimension == D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER)
		{
			pCmdList.CopyBufferRegion(pDestinationResource, 0, pIntermediate, pLayouts[0].Offset, pLayouts[0].Footprint.Width);
		}
		else
		{
			for (uint i = 0; i < NumSubresources; ++i)
			{
				D3D12_TEXTURE_COPY_LOCATION Dst = new(pDestinationResource, i + FirstSubresource);
				D3D12_TEXTURE_COPY_LOCATION Src = new(pIntermediate, pLayouts[i]);
				pCmdList.CopyTextureRegion(Dst, 0, 0, 0, Src);
			}
		}
		return RequiredSize;
	}

	/// <summary>Updates subresources, all the subresource arrays should be populated, typically by calling <c><b>ID3D12Device.GetCopyableFootprints</b></c>.</summary>
	/// <param name="pCmdList">
	/// <para>Type: <b><c><b>ID3D12GraphicsCommandList</b></c>*</b></para>
	/// <para>The command list, as a pointer to an <c><b>ID3D12GraphicsCommandList</b></c>.</para>
	/// </param>
	/// <param name="pDestinationResource">
	/// <para>Type: <b><c><b>ID3D12Resource</b></c>*</b></para>
	/// <para>The destination resource, as a pointer to an <c><b>ID3D12Resource</b></c>.</para>
	/// </param>
	/// <param name="pIntermediate">
	/// <para>Type: <b><c><b>ID3D12Resource</b></c>*</b></para>
	/// <para>The intermediate resource, as a pointer to an <c><b>ID3D12Resource</b></c>.</para>
	/// </param>
	/// <param name="FirstSubresource">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The index of the first subresource in the resource. The range of valid values is 0 to D3D12_REQ_SUBRESOURCES.</para>
	/// </param>
	/// <param name="NumSubresources">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The number of subresources in the resource. The range of valid values is 0 to (D3D12_REQ_SUBRESOURCES - FirstSubresource).</para>
	/// </param>
	/// <param name="RequiredSize">
	/// <para>Type: <b><c><b>UINT64</b></c></b></para>
	/// <para>The required size, in bytes, for the update.</para>
	/// </param>
	/// <param name="pLayouts">
	/// <para>Type: <b>const <c><b>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</b></c>*</b></para>
	/// <para>
	/// Pointer to an array (of length NumSubresources) of pointers to the structures that contains the description and placement of the
	/// resource's subresources.
	/// </para>
	/// </param>
	/// <param name="pNumRows">
	/// <para>Type: <b>const <c><b>UINT</b></c>*</b></para>
	/// <para>Pointer to an array (of length NumSubresources) of UINTS containing the number of rows for each subresource.</para>
	/// </param>
	/// <param name="pRowSizesInBytes">
	/// <para>Type: <b>const <c><b>UINT64</b></c>*</b></para>
	/// <para>Pointer to an array (of length NumSubresources) of UINTS containing the size, in bytes, of each row.</para>
	/// </param>
	/// <param name="pResourceData">The resource data.</param>
	/// <param name="pSrcData">
	/// <para>Type: <b>const <c><b>D3D12_SUBRESOURCE_DATA</b></c>*</b></para>
	/// <para>
	/// Pointer to an array (of length NumSubresources) of pointers to <c><b>D3D12_SUBRESOURCE_DATA</b></c> structures containing
	/// descriptions of the subresource data used for the update.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c><b>UINT64</b></c></b></para>
	/// <para>The size, in bytes, of the buffer.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/updatesubresources1 UINT64 inline UpdateSubresources( _In_
	// ID3D12GraphicsCommandList *pCmdList, _In_ ID3D12Resource *pDestinationResource, _In_ ID3D12Resource *pIntermediate, _In_ UINT
	// FirstSubresource, _In_ UINT NumSubresources, UINT64 RequiredSize, _In_ const D3D12_PLACED_SUBRESOURCE_FOOTPRINT *pLayouts, _In_ const
	// UINT *pNumRows, _In_ const UINT64 *pRowSizesInBytes, _In_ const D3D12_SUBRESOURCE_DATA *pSrcData );
	[PInvokeData("D3dx12.h")]
	public static ulong UpdateSubresources([In] ID3D12GraphicsCommandList pCmdList, [In] ID3D12Resource pDestinationResource,
		[In] ID3D12Resource pIntermediate, uint FirstSubresource, int NumSubresources, ulong RequiredSize,
		[In] D3D12_PLACED_SUBRESOURCE_FOOTPRINT[] pLayouts, [In] uint[] pNumRows, [In] ulong[] pRowSizesInBytes,
		[In] IntPtr pResourceData, [In] D3D12_SUBRESOURCE_INFO[] pSrcData)
	{
		// Minor validation
		pIntermediate.GetDesc(out var IntermediateDesc);
		pDestinationResource.GetDesc(out var DestinationDesc);
		if (IntermediateDesc.Dimension != D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER ||
			IntermediateDesc.Width < RequiredSize + pLayouts[0].Offset ||
			RequiredSize > ulong.MaxValue ||
			DestinationDesc.Dimension == D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER &&
			(FirstSubresource != 0 || NumSubresources != 1))
		{
			return 0;
		}

		if (pIntermediate.Map(0, null, out var pData).Failed)
		{
			return 0;
		}

		for (uint i = 0; i < NumSubresources; ++i)
		{
			if (pRowSizesInBytes[i] > ulong.MaxValue) return 0;
			D3D12_MEMCPY_DEST DestData = new() { pData = pData.Offset((long)pLayouts[i].Offset), RowPitch = pLayouts[i].Footprint.RowPitch, SlicePitch = pLayouts[i].Footprint.RowPitch * pNumRows[i] };
			MemcpySubresource(DestData, pResourceData, pSrcData[i], pRowSizesInBytes[i], pNumRows[i], pLayouts[i].Footprint.Depth);
		}
		pIntermediate.Unmap(0);

		if (DestinationDesc.Dimension == D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER)
		{
			pCmdList.CopyBufferRegion(pDestinationResource, 0, pIntermediate, pLayouts[0].Offset, pLayouts[0].Footprint.Width);
		}
		else
		{
			for (uint i = 0; i < NumSubresources; ++i)
			{
				D3D12_TEXTURE_COPY_LOCATION Dst = new(pDestinationResource, i + FirstSubresource);
				D3D12_TEXTURE_COPY_LOCATION Src = new(pIntermediate, pLayouts[i]);
				pCmdList.CopyTextureRegion(Dst, 0, 0, 0, Src);
			}
		}
		return RequiredSize;
	}

	/// <summary>Updates subresources with a heap-allocating implementation.</summary>
	/// <param name="pCmdList">
	/// <para>Type: <b><c><b>ID3D12GraphicsCommandList</b></c>*</b></para>
	/// <para>A pointer to the <c><b>ID3D12GraphicsCommandList</b></c> interface for the command list.</para>
	/// </param>
	/// <param name="pDestinationResource">
	/// <para>Type: <b><c><b>ID3D12Resource</b></c>*</b></para>
	/// <para>A pointer to the <c><b>ID3D12Resource</b></c> interface that represents the destination resource.</para>
	/// </param>
	/// <param name="pIntermediate">
	/// <para>Type: <b><c><b>ID3D12Resource</b></c>*</b></para>
	/// <para>A pointer to the <c><b>ID3D12Resource</b></c> interface that represents the intermediate resource.</para>
	/// </param>
	/// <param name="IntermediateOffset">
	/// <para>Type: <b><c><b>UINT64</b></c></b></para>
	/// <para>The offset, in bytes, to the intermediate resource.</para>
	/// </param>
	/// <param name="FirstSubresource">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The index of the first subresource in the resource. The range of valid values is 0 to D3D12_REQ_SUBRESOURCES.</para>
	/// </param>
	/// <param name="NumSubresources">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The number of subresources in the resource. The range of valid values is 0 to (D3D12_REQ_SUBRESOURCES - FirstSubresource).</para>
	/// </param>
	/// <param name="pSrcData">
	/// <para>Type: <b><c><b>D3D12_SUBRESOURCE_DATA</b></c>*</b></para>
	/// <para>
	/// Pointer to an array (of length NumSubresources) of pointers to <c><b>D3D12_SUBRESOURCE_DATA</b></c> structures containing
	/// descriptions of the subresource data used for the update.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c><b>UINT64</b></c></b></para>
	/// <para>The size, in bytes, of the buffer.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/updatesubresources2 UINT64 inline UpdateSubresources( _In_
	// ID3D12GraphicsCommandList *pCmdList, _In_ ID3D12Resource *pDestinationResource, _In_ ID3D12Resource *pIntermediate, UINT64
	// IntermediateOffset, _In_ UINT FirstSubresource, _In_ UINT NumSubresources, _In_ D3D12_SUBRESOURCE_DATA *pSrcData );
	[PInvokeData("D3dx12.h")]
	public static ulong UpdateSubresources([In] ID3D12GraphicsCommandList pCmdList, [In] ID3D12Resource pDestinationResource,
		[In] ID3D12Resource pIntermediate, ulong IntermediateOffset, uint FirstSubresource, int NumSubresources,
		[In] D3D12_SUBRESOURCE_DATA[] pSrcData)
	{
		pDestinationResource.GetDesc(out var Desc);
		IidGetObj(pDestinationResource.GetDevice, out ID3D12Device pDevice).ThrowIfFailed();

		var pLayouts = new D3D12_PLACED_SUBRESOURCE_FOOTPRINT[NumSubresources];
		var pRowSizesInBytes = new ulong[NumSubresources];
		var pNumRows = new uint[NumSubresources];
		pDevice.GetCopyableFootprints(Desc, FirstSubresource, NumSubresources, IntermediateOffset, pLayouts,
			pNumRows, pRowSizesInBytes, out var RequiredSize);
		Marshal.ReleaseComObject(pDevice);

		return UpdateSubresources(pCmdList, pDestinationResource, pIntermediate, FirstSubresource, NumSubresources,
			RequiredSize, pLayouts, pNumRows, pRowSizesInBytes, pSrcData);
	}

	/// <summary>Updates subresources with a heap-allocating implementation.</summary>
	/// <param name="pCmdList">
	/// <para>Type: <b><c><b>ID3D12GraphicsCommandList</b></c>*</b></para>
	/// <para>A pointer to the <c><b>ID3D12GraphicsCommandList</b></c> interface for the command list.</para>
	/// </param>
	/// <param name="pDestinationResource">
	/// <para>Type: <b><c><b>ID3D12Resource</b></c>*</b></para>
	/// <para>A pointer to the <c><b>ID3D12Resource</b></c> interface that represents the destination resource.</para>
	/// </param>
	/// <param name="pIntermediate">
	/// <para>Type: <b><c><b>ID3D12Resource</b></c>*</b></para>
	/// <para>A pointer to the <c><b>ID3D12Resource</b></c> interface that represents the intermediate resource.</para>
	/// </param>
	/// <param name="IntermediateOffset">
	/// <para>Type: <b><c><b>UINT64</b></c></b></para>
	/// <para>The offset, in bytes, to the intermediate resource.</para>
	/// </param>
	/// <param name="FirstSubresource">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The index of the first subresource in the resource. The range of valid values is 0 to D3D12_REQ_SUBRESOURCES.</para>
	/// </param>
	/// <param name="NumSubresources">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The number of subresources in the resource. The range of valid values is 0 to (D3D12_REQ_SUBRESOURCES - FirstSubresource).</para>
	/// </param>
	/// <param name="pResourceData">The resource data.</param>
	/// <param name="pSrcData">
	/// <para>Type: <b><c><b>D3D12_SUBRESOURCE_DATA</b></c>*</b></para>
	/// <para>
	/// Pointer to an array (of length NumSubresources) of pointers to <c><b>D3D12_SUBRESOURCE_DATA</b></c> structures containing
	/// descriptions of the subresource data used for the update.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c><b>UINT64</b></c></b></para>
	/// <para>The size, in bytes, of the buffer.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/updatesubresources2 UINT64 inline UpdateSubresources( _In_
	// ID3D12GraphicsCommandList *pCmdList, _In_ ID3D12Resource *pDestinationResource, _In_ ID3D12Resource *pIntermediate, UINT64
	// IntermediateOffset, _In_ UINT FirstSubresource, _In_ UINT NumSubresources, _In_ D3D12_SUBRESOURCE_DATA *pSrcData );
	[PInvokeData("D3dx12.h")]
	public static ulong UpdateSubresources([In] ID3D12GraphicsCommandList pCmdList, [In] ID3D12Resource pDestinationResource,
		[In] ID3D12Resource pIntermediate, ulong IntermediateOffset, uint FirstSubresource, int NumSubresources,
		[In] IntPtr pResourceData, [In] D3D12_SUBRESOURCE_INFO[] pSrcData)
	{
		D3D12_PLACED_SUBRESOURCE_FOOTPRINT[] pLayouts = new D3D12_PLACED_SUBRESOURCE_FOOTPRINT[NumSubresources];
		ulong[] pRowSizesInBytes = new ulong[NumSubresources];
		uint[] pNumRows = new uint[NumSubresources];

		pDestinationResource.GetDesc(out var Desc);

		IidGetObj(pDestinationResource.GetDevice, out ID3D12Device pDevice).ThrowIfFailed();

		pDevice.GetCopyableFootprints(Desc, FirstSubresource, NumSubresources, IntermediateOffset, pLayouts, pNumRows,
			pRowSizesInBytes, out var RequiredSize);
		Marshal.ReleaseComObject(pDevice);

		return UpdateSubresources(pCmdList, pDestinationResource, pIntermediate, FirstSubresource, NumSubresources,
			RequiredSize, pLayouts, pNumRows, pRowSizesInBytes, pResourceData, pSrcData);
	}

	/// <summary>Updates subresources with a stack-allocating implementation.</summary>
	/// <param name="pCmdList">
	/// <para>Type: <b><c><b>ID3D12GraphicsCommandList</b></c>*</b></para>
	/// <para>The command list, as a pointer to an <c><b>ID3D12GraphicsCommandList</b></c>.</para>
	/// </param>
	/// <param name="pDestinationResource">
	/// <para>Type: <b><c><b>ID3D12Resource</b></c>*</b></para>
	/// <para>The destination resource, as a pointer to an <c><b>ID3D12Resource</b></c>.</para>
	/// </param>
	/// <param name="pIntermediate">
	/// <para>Type: <b><c><b>ID3D12Resource</b></c>*</b></para>
	/// <para>The intermediate resource, as a pointer to an <c><b>ID3D12Resource</b></c>.</para>
	/// </param>
	/// <param name="IntermediateOffset">
	/// <para>Type: <b><c><b>UINT64</b></c></b></para>
	/// <para>The offset, in bytes, to the intermediate resource.</para>
	/// </param>
	/// <param name="FirstSubresource">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The index of the first subresource in the resource. Valid values range from 0 to MaxSubresources.</para>
	/// </param>
	/// <param name="NumSubresources">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The number of subresources in the resource. Valid values range from 1 to (MaxSubresources - FirstSubresource).</para>
	/// </param>
	/// <param name="pSrcData">
	/// <para>Type: <b><c><b>D3D12_SUBRESOURCE_DATA</b></c>*</b></para>
	/// <para>
	/// Pointer to an array (of length NumSubresources) of pointers to <c><b>D3D12_SUBRESOURCE_DATA</b></c> structures containing
	/// descriptions of the subresource data used for the update.
	/// </para>
	/// </param>
	/// <param name="MaxSubresources">The maximum subresources.</param>
	/// <returns>
	/// <para>Type: <b><c><b>UINT64</b></c></b></para>
	/// <para>The size, in bytes, of the buffer.</para>
	/// </returns>
	/// <remarks>The declaration of this function begins with: <c>template &lt;UINT MaxSubresources&gt;</c></remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/updatesubresources3 UINT64 inline UpdateSubresources( _In_
	// ID3D12GraphicsCommandList *pCmdList, _In_ ID3D12Resource *pDestinationResource, _In_ ID3D12Resource *pIntermediate, UINT64
	// IntermediateOffset, _In_ UINT FirstSubresource, _In_ UINT NumSubresources, _In_ D3D12_SUBRESOURCE_DATA *pSrcData );
	[PInvokeData("D3dx12.h")]
	public static ulong UpdateSubresources([In] ID3D12GraphicsCommandList pCmdList, [In] ID3D12Resource pDestinationResource,
		[In] ID3D12Resource pIntermediate, ulong IntermediateOffset, uint FirstSubresource, int NumSubresources,
		[In] D3D12_SUBRESOURCE_DATA[] pSrcData, int MaxSubresources)
	{
		D3D12_PLACED_SUBRESOURCE_FOOTPRINT[] Layouts = new D3D12_PLACED_SUBRESOURCE_FOOTPRINT[MaxSubresources];
		uint[] NumRows = new uint[MaxSubresources];
		ulong[] RowSizesInBytes = new ulong[MaxSubresources];

		pDestinationResource.GetDesc(out var Desc);
		IidGetObj(pDestinationResource.GetDevice, out ID3D12Device pDevice).ThrowIfFailed();
		pDevice.GetCopyableFootprints(Desc, FirstSubresource, NumSubresources, IntermediateOffset, Layouts, NumRows,
			RowSizesInBytes, out var RequiredSize);
		Marshal.ReleaseComObject(pDevice);

		return UpdateSubresources(pCmdList, pDestinationResource, pIntermediate, FirstSubresource, NumSubresources, RequiredSize, Layouts, NumRows, RowSizesInBytes, pSrcData);
	}

	/// <summary>Updates subresources with a stack-allocating implementation.</summary>
	/// <param name="pCmdList">
	/// <para>Type: <b><c><b>ID3D12GraphicsCommandList</b></c>*</b></para>
	/// <para>The command list, as a pointer to an <c><b>ID3D12GraphicsCommandList</b></c>.</para>
	/// </param>
	/// <param name="pDestinationResource">
	/// <para>Type: <b><c><b>ID3D12Resource</b></c>*</b></para>
	/// <para>The destination resource, as a pointer to an <c><b>ID3D12Resource</b></c>.</para>
	/// </param>
	/// <param name="pIntermediate">
	/// <para>Type: <b><c><b>ID3D12Resource</b></c>*</b></para>
	/// <para>The intermediate resource, as a pointer to an <c><b>ID3D12Resource</b></c>.</para>
	/// </param>
	/// <param name="IntermediateOffset">
	/// <para>Type: <b><c><b>UINT64</b></c></b></para>
	/// <para>The offset, in bytes, to the intermediate resource.</para>
	/// </param>
	/// <param name="FirstSubresource">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The index of the first subresource in the resource. Valid values range from 0 to MaxSubresources.</para>
	/// </param>
	/// <param name="NumSubresources">
	/// <para>Type: <b><c><b>UINT</b></c></b></para>
	/// <para>The number of subresources in the resource. Valid values range from 1 to (MaxSubresources - FirstSubresource).</para>
	/// </param>
	/// <param name="pResourceData">The resource data.</param>
	/// <param name="pSrcData">
	/// <para>Type: <b><c><b>D3D12_SUBRESOURCE_DATA</b></c>*</b></para>
	/// <para>
	/// Pointer to an array (of length NumSubresources) of pointers to <c><b>D3D12_SUBRESOURCE_DATA</b></c> structures containing
	/// descriptions of the subresource data used for the update.
	/// </para>
	/// </param>
	/// <param name="MaxSubresources">The maximum subresources.</param>
	/// <returns>
	/// <para>Type: <b><c><b>UINT64</b></c></b></para>
	/// <para>The size, in bytes, of the buffer.</para>
	/// </returns>
	/// <remarks>The declaration of this function begins with: <c>template &lt;UINT MaxSubresources&gt;</c></remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/updatesubresources3 UINT64 inline UpdateSubresources( _In_
	// ID3D12GraphicsCommandList *pCmdList, _In_ ID3D12Resource *pDestinationResource, _In_ ID3D12Resource *pIntermediate, UINT64
	// IntermediateOffset, _In_ UINT FirstSubresource, _In_ UINT NumSubresources, _In_ D3D12_SUBRESOURCE_DATA *pSrcData );
	[PInvokeData("D3dx12.h")]
	public static ulong UpdateSubresources([In] ID3D12GraphicsCommandList pCmdList, [In] ID3D12Resource pDestinationResource,
		[In] ID3D12Resource pIntermediate, ulong IntermediateOffset, uint FirstSubresource, int NumSubresources,
		[In] IntPtr pResourceData, [In] D3D12_SUBRESOURCE_INFO[] pSrcData, uint MaxSubresources)
	{
		D3D12_PLACED_SUBRESOURCE_FOOTPRINT[] pLayouts = new D3D12_PLACED_SUBRESOURCE_FOOTPRINT[MaxSubresources];
		ulong[] pRowSizesInBytes = new ulong[MaxSubresources];
		uint[] pNumRows = new uint[MaxSubresources];

		pDestinationResource.GetDesc(out var Desc);

		IidGetObj(pDestinationResource.GetDevice, out ID3D12Device pDevice).ThrowIfFailed();
		pDevice.GetCopyableFootprints(Desc, FirstSubresource, NumSubresources, IntermediateOffset, pLayouts, pNumRows, pRowSizesInBytes,
			out var RequiredSize);
		Marshal.ReleaseComObject(pDevice);

		return UpdateSubresources(pCmdList, pDestinationResource, pIntermediate, FirstSubresource, NumSubresources, RequiredSize,
			pLayouts, pNumRows, pRowSizesInBytes, pResourceData, pSrcData);
	}
}