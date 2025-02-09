namespace Vanara.PInvoke;

public static partial class D3D12
{
	/// <summary/>
	public class CD3DX12_PIPELINE_STATE_STREAM_AS : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_SHADER_BYTECODE>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_AS"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_AS(in D3D12_SHADER_BYTECODE value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_AS, value)
		{
		}
	}

	/// <summary>A helper structure used to describe a blend description as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_BLEND_DESC is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;CD3DX12_BLEND_DESC, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_BLEND, CD3DX12_DEFAULT&gt; CD3DX12_PIPELINE_STATE_STREAM_BLEND_DESC; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-blend-desc
	// struct CD3DX12_PIPELINE_STATE_STREAM_BLEND_DESC { CD3DX12_PIPELINE_STATE_STREAM_BLEND_DESC; CD3DX12_PIPELINE_STATE_STREAM_BLEND_DESC(CD3DX12_BLEND_DESC const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_BLEND_DESC operator=(CD3DX12_BLEND_DESC const&amp; i); operator CD3DX12_BLEND_DESC() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_BLEND_DESC : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_BLEND_DESC>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_BLEND_DESC"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_BLEND_DESC(in D3D12_BLEND_DESC? value = null) :
			base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_BLEND, value ?? new())
		{
		}
	}

	/// <summary>A helper structure used to describe a cached PSO as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_CACHED_PSO is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;D3D12_CACHED_PIPELINE_STATE, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_CACHED_PSO&gt; CD3DX12_PIPELINE_STATE_STREAM_CACHED_PSO; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-cached-pso
	// struct CD3DX12_PIPELINE_STATE_STREAM_CACHED_PSO { CD3DX12_PIPELINE_STATE_STREAM_CACHED_PSO; CD3DX12_PIPELINE_STATE_STREAM_CACHED_PSO(D3D12_CACHED_PIPELINE_STATE const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_CACHED_PSO operator=(D3D12_CACHED_PIPELINE_STATE const&amp; i); operator D3D12_CACHED_PIPELINE_STATE() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_CACHED_PSO : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_CACHED_PIPELINE_STATE>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_CACHED_PSO"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_CACHED_PSO(in D3D12_CACHED_PIPELINE_STATE value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_CACHED_PSO, value)
		{
		}
	}

	/// <summary>A helper structure used to describe a compute shader as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_CS is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;D3D12_SHADER_BYTECODE, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_CS&gt; CD3DX12_PIPELINE_STATE_STREAM_CS; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-cs
	// struct CD3DX12_PIPELINE_STATE_STREAM_CS { CD3DX12_PIPELINE_STATE_STREAM_CS; CD3DX12_PIPELINE_STATE_STREAM_CS(D3D12_SHADER_BYTECODE const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_CS operator=(D3D12_SHADER_BYTECODE const&amp; i); operator D3D12_SHADER_BYTECODE() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_CS : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_SHADER_BYTECODE>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_CS"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_CS(in D3D12_SHADER_BYTECODE value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_CS, value)
		{
		}
	}

	/// <summary>A helper structure used to describe a depth stencil description as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL1 is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;CD3DX12_DEPTH_STENCIL_DESC1, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL1, CD3DX12_DEFAULT&gt; CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL1; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-depth-stencil1
	// struct CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL1 { CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL1; CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL1(CD3DX12_DEPTH_STENCIL_DESC1 const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL1 operator=(CD3DX12_DEPTH_STENCIL_DESC1 const&amp; i); operator CD3DX12_DEPTH_STENCIL_DESC1() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_DEPTH_STENCIL_DESC>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL(in D3D12_DEPTH_STENCIL_DESC? value = null) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL, value ?? new())
		{
		}
	}

	/// <summary>A helper structure used to describe the depth stencil format as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL_FORMAT is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;DXGI_FORMAT, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL_FORMAT&gt; CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL_FORMAT; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-depth-stencil-format
	// struct CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL_FORMAT { CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL_FORMAT; CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL_FORMAT(DXGI_FORMAT const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL_FORMAT operator=(DXGI_FORMAT const&amp; i); operator DXGI_FORMAT() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL_FORMAT : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<DXGI_FORMAT>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL_FORMAT"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL_FORMAT(in DXGI_FORMAT value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL_FORMAT, value)
		{
		}
	}

	/// <summary>A helper structure used to describe a depth stencil description as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL1 is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;CD3DX12_DEPTH_STENCIL_DESC1, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL1, CD3DX12_DEFAULT&gt; CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL1; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-depth-stencil1
	// struct CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL1 { CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL1; CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL1(CD3DX12_DEPTH_STENCIL_DESC1 const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL1 operator=(CD3DX12_DEPTH_STENCIL_DESC1 const&amp; i); operator CD3DX12_DEPTH_STENCIL_DESC1() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL1 : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_DEPTH_STENCIL_DESC1>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL1"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_DEPTH_STENCIL1(in D3D12_DEPTH_STENCIL_DESC1? value = null) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DEPTH_STENCIL1, value ?? new())
		{
		}
	}

	/// <summary>A helper structure used to describe a domain shader as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_DS is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;D3D12_SHADER_BYTECODE, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DS&gt; CD3DX12_PIPELINE_STATE_STREAM_DS; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-ds
	// struct CD3DX12_PIPELINE_STATE_STREAM_DS { CD3DX12_PIPELINE_STATE_STREAM_DS; CD3DX12_PIPELINE_STATE_STREAM_DS(D3D12_SHADER_BYTECODE const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_DS operator=(D3D12_SHADER_BYTECODE const&amp; i); operator D3D12_SHADER_BYTECODE() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_DS : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_SHADER_BYTECODE>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_DS"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_DS(in D3D12_SHADER_BYTECODE value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_DS, value)
		{
		}
	}

	/// <summary>A helper structure used to describe pipeline state flags as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>
	/// CD3DX12_PIPELINE_STATE_STREAM_FLAGS is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c>
	/// template, and is defined as follows:
	/// </para>
	/// <para>
	/// <c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;D3D12_PIPELINE_STATE_FLAGS, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_FLAGS&gt; CD3DX12_PIPELINE_STATE_STREAM_FLAGS;</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-flags
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_FLAGS : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_PIPELINE_STATE_FLAGS>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_FLAGS"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_FLAGS(in D3D12_PIPELINE_STATE_FLAGS value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_FLAGS, value)
		{
		}
	}

	/// <summary>A helper structure used to describe a geometry shader as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_GS is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;D3D12_SHADER_BYTECODE, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_GS&gt; CD3DX12_PIPELINE_STATE_STREAM_GS; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-gs
	// struct CD3DX12_PIPELINE_STATE_STREAM_GS { CD3DX12_PIPELINE_STATE_STREAM_GS; CD3DX12_PIPELINE_STATE_STREAM_GS(D3D12_SHADER_BYTECODE const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_GS operator=(D3D12_SHADER_BYTECODE const&amp; i); operator D3D12_SHADER_BYTECODE() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_GS : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_SHADER_BYTECODE>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_GS"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_GS(in D3D12_SHADER_BYTECODE value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_GS, value)
		{
		}
	}

	/// <summary>A helper structure used to describe a hull shader as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_HS is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;D3D12_SHADER_BYTECODE, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_HS&gt; CD3DX12_PIPELINE_STATE_STREAM_HS; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-hs
	// struct CD3DX12_PIPELINE_STATE_STREAM_HS { CD3DX12_PIPELINE_STATE_STREAM_HS; CD3DX12_PIPELINE_STATE_STREAM_HS(D3D12_SHADER_BYTECODE const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_HS operator=(D3D12_SHADER_BYTECODE const&amp; i); operator D3D12_SHADER_BYTECODE() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_HS : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_SHADER_BYTECODE>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_HS"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_HS(in D3D12_SHADER_BYTECODE value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_HS, value)
		{
		}
	}

	/// <summary>A helper structure used to describe the index buffer strip cut value as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_IB_STRIP_CUT_VALUE is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;D3D12_INDEX_BUFFER_STRIP_CUT_VALUE, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_IB_STRIP_CUT_VALUE&gt; CD3DX12_PIPELINE_STATE_STREAM_IB_STRIP_CUT_VALUE; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-ib-strip-cut-value
	// struct CD3DX12_PIPELINE_STATE_STREAM_IB_STRIP_CUT_VALUE { CD3DX12_PIPELINE_STATE_STREAM_IB_STRIP_CUT_VALUE; CD3DX12_PIPELINE_STATE_STREAM_IB_STRIP_CUT_VALUE(D3D12_INDEX_BUFFER_STRIP_CUT_VALUE const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_IB_STRIP_CUT_VALUE operator=(D3D12_INDEX_BUFFER_STRIP_CUT_VALUE const&amp; i); operator D3D12_INDEX_BUFFER_STRIP_CUT_VALUE() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_IB_STRIP_CUT_VALUE : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_INDEX_BUFFER_STRIP_CUT_VALUE>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_IB_STRIP_CUT_VALUE"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_IB_STRIP_CUT_VALUE(in D3D12_INDEX_BUFFER_STRIP_CUT_VALUE value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_IB_STRIP_CUT_VALUE, value)
		{
		}
	}

	/// <summary>A helper structure used to describe an input layout as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_INPUT_LAYOUT is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;D3D12_INPUT_LAYOUT_DESC, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_INPUT_LAYOUT&gt; CD3DX12_PIPELINE_STATE_STREAM_INPUT_LAYOUT; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-input-layout
	// struct CD3DX12_PIPELINE_STATE_STREAM_INPUT_LAYOUT { CD3DX12_PIPELINE_STATE_STREAM_INPUT_LAYOUT; CD3DX12_PIPELINE_STATE_STREAM_INPUT_LAYOUT(D3D12_INPUT_LAYOUT_DESC const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_INPUT_LAYOUT operator=(D3D12_INPUT_LAYOUT_DESC const&amp; i); operator D3D12_INPUT_LAYOUT_DESC() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_INPUT_LAYOUT : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_INPUT_LAYOUT_DESC>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_INPUT_LAYOUT"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_INPUT_LAYOUT(in D3D12_INPUT_LAYOUT_DESC value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_INPUT_LAYOUT, value)
		{
		}
	}

	/// <summary/>
	public class CD3DX12_PIPELINE_STATE_STREAM_MS : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_SHADER_BYTECODE>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_MS"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_MS(in D3D12_SHADER_BYTECODE value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_MS, value)
		{
		}
	}

	/// <summary>A helper structure used to describe a node mask as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_NODE_MASK is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;UINT, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_NODE_MASK&gt; CD3DX12_PIPELINE_STATE_STREAM_NODE_MASK; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-node-mask
	// struct CD3DX12_PIPELINE_STATE_STREAM_NODE_MASK { CD3DX12_PIPELINE_STATE_STREAM_NODE_MASK; CD3DX12_PIPELINE_STATE_STREAM_NODE_MASK(UINT const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_NODE_MASK operator=(UINT const&amp; i); operator UINT() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_NODE_MASK : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<uint>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_NODE_MASK"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_NODE_MASK(uint value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_NODE_MASK, value)
		{
		}
	}

	/// <summary>A helper structure used to describe the primitive topology as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_PRIMITIVE_TOPOLOGY is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;D3D12_PRIMITIVE_TOPOLOGY_TYPE, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_PRIMITIVE_TOPOLOGY&gt; CD3DX12_PIPELINE_STATE_STREAM_PRIMITIVE_TOPOLOGY; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-primitive-topology
	// struct CD3DX12_PIPELINE_STATE_STREAM_PRIMITIVE_TOPOLOGY { CD3DX12_PIPELINE_STATE_STREAM_PRIMITIVE_TOPOLOGY; CD3DX12_PIPELINE_STATE_STREAM_PRIMITIVE_TOPOLOGY(D3D12_PRIMITIVE_TOPOLOGY_TYPE const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_PRIMITIVE_TOPOLOGY operator=(D3D12_PRIMITIVE_TOPOLOGY_TYPE const&amp; i); operator D3D12_PRIMITIVE_TOPOLOGY_TYPE() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_PRIMITIVE_TOPOLOGY : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_PRIMITIVE_TOPOLOGY_TYPE>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_PRIMITIVE_TOPOLOGY"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_PRIMITIVE_TOPOLOGY(in D3D12_PRIMITIVE_TOPOLOGY_TYPE value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_PRIMITIVE_TOPOLOGY, value)
		{
		}
	}

	/// <summary>A helper structure used to describe a pixel shader as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_PS is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;D3D12_SHADER_BYTECODE, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_PS&gt; CD3DX12_PIPELINE_STATE_STREAM_PS; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-ps
	// struct CD3DX12_PIPELINE_STATE_STREAM_PS { CD3DX12_PIPELINE_STATE_STREAM_PS; CD3DX12_PIPELINE_STATE_STREAM_PS(D3D12_SHADER_BYTECODE const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_PS operator=(D3D12_SHADER_BYTECODE const&amp; i); operator D3D12_SHADER_BYTECODE() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_PS : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_SHADER_BYTECODE>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_PS"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_PS(in D3D12_SHADER_BYTECODE value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_PS, value)
		{
		}
	}
	/// <summary>A helper structure used to describe a rasterizer description as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_RASTERIZER is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;CD3DX12_RASTERIZER_DESC, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_RASTERIZER, CD3DX12_DEFAULT&gt; CD3DX12_PIPELINE_STATE_STREAM_RASTERIZER; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-rasterizer
	// struct CD3DX12_PIPELINE_STATE_STREAM_RASTERIZER { CD3DX12_PIPELINE_STATE_STREAM_RASTERIZER; CD3DX12_PIPELINE_STATE_STREAM_RASTERIZER(CD3DX12_RASTERIZER_DESC const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_RASTERIZER operator=(CD3DX12_RASTERIZER_DESC const&amp; i); operator CD3DX12_RASTERIZER_DESC() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_RASTERIZER : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_RASTERIZER_DESC>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_RASTERIZER"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_RASTERIZER(in D3D12_RASTERIZER_DESC? value = null) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_RASTERIZER, value ?? new())
		{
		}
	}

	/// <summary>A helper structure used to describe the render target formats as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_RENDER_TARGET_FORMATS is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;D3D12_RT_FORMAT_ARRAY, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_RENDER_TARGET_FORMATS&gt; CD3DX12_PIPELINE_STATE_STREAM_RENDER_TARGET_FORMATS; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-render-target-formats
	// struct CD3DX12_PIPELINE_STATE_STREAM_RENDER_TARGET_FORMATS { CD3DX12_PIPELINE_STATE_STREAM_RENDER_TARGET_FORMATS; CD3DX12_PIPELINE_STATE_STREAM_RENDER_TARGET_FORMATS(D3D12_RT_FORMAT_ARRAY const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_RENDER_TARGET_FORMATS operator=(D3D12_RT_FORMAT_ARRAY const&amp; i); operator D3D12_RT_FORMAT_ARRAY() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_RENDER_TARGET_FORMATS : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_RT_FORMAT_ARRAY>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_RENDER_TARGET_FORMATS"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_RENDER_TARGET_FORMATS(in D3D12_RT_FORMAT_ARRAY value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_RENDER_TARGET_FORMATS, value)
		{
		}
	}

	/// <summary>A helper structure used to describe the root signature as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_ROOT_SIGNATURE is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;ID3D12RootSignature*, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_ROOT_SIGNATURE&gt; CD3DX12_PIPELINE_STATE_STREAM_ROOT_SIGNATURE; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-root-signature
	// struct CD3DX12_PIPELINE_STATE_STREAM_ROOT_SIGNATURE { CD3DX12_PIPELINE_STATE_STREAM_ROOT_SIGNATURE; CD3DX12_PIPELINE_STATE_STREAM_ROOT_SIGNATURE(ID3D12RootSignature* const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_ROOT_SIGNATURE operator=(ID3D12RootSignature* const&amp; i); operator ID3D12RootSignature*() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_ROOT_SIGNATURE : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<IUnknownPointer<ID3D12RootSignature>>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_ROOT_SIGNATURE"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_ROOT_SIGNATURE(ID3D12RootSignature value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_ROOT_SIGNATURE, new(value))
		{
		}
	}

	/// <summary>A helper structure used to describe a sample description as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_DESC is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;DXGI_SAMPLE_DESC, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_SAMPLE_DESC&gt; CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_DESC; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-sample-desc
	// struct CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_DESC { CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_DESC; CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_DESC(DXGI_SAMPLE_DESC const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_DESC operator=(DXGI_SAMPLE_DESC const&amp; i); operator DXGI_SAMPLE_DESC() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_DESC : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<DXGI_SAMPLE_DESC>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_DESC"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_DESC(in DXGI_SAMPLE_DESC? value = null) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_SAMPLE_DESC, value ?? new(1, 0))
		{
		}
	}

	/// <summary>A helper structure used to describe a sample mask as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_MASK is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;UINT, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_SAMPLE_MASK&gt; CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_MASK; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-sample-mask
	// struct CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_MASK { CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_MASK; CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_MASK(UINT const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_MASK operator=(UINT const&amp; i); operator UINT() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_MASK : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<uint>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_MASK"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_SAMPLE_MASK(uint value = uint.MaxValue) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_SAMPLE_MASK, value)
		{
		}
	}

	/// <summary>A helper structure used to describe the stream output description as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_STREAM_OUTPUT is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;D3D12_STREAM_OUTPUT_DESC, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_STREAM_OUTPUT&gt; CD3DX12_PIPELINE_STATE_STREAM_STREAM_OUTPUT; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-stream-output
	// struct CD3DX12_PIPELINE_STATE_STREAM_STREAM_OUTPUT { CD3DX12_PIPELINE_STATE_STREAM_STREAM_OUTPUT; CD3DX12_PIPELINE_STATE_STREAM_STREAM_OUTPUT(D3D12_STREAM_OUTPUT_DESC const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_STREAM_OUTPUT operator=(D3D12_STREAM_OUTPUT_DESC const&amp; i); operator D3D12_STREAM_OUTPUT_DESC() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_STREAM_OUTPUT : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_STREAM_OUTPUT_DESC>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_STREAM_OUTPUT"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_STREAM_OUTPUT(in D3D12_STREAM_OUTPUT_DESC value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_STREAM_OUTPUT, value)
		{
		}
	}

	/// <summary>
	/// A templated helper structure used to encapsulate subobject type and subobject data pairs as a single object suitable for a stream description.
	/// </summary>
	/// <typeparam name="InnerStructType">
	/// The template parameter <b>InnerStructType</b> specifies the subobject data type; that is, the subobject details to be encoded into a
	/// stream. The template parameter <b>Type</b> specifies the subobject type; that is, the type of the structure specified by the
	/// template parameter <b>InnerStructType</b>.
	/// </typeparam>
	[StructLayout(LayoutKind.Sequential)]
	public abstract class CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<InnerStructType> where InnerStructType : struct
	{
		private D3D12_PIPELINE_STATE_SUBOBJECT_TYPE _Type;
		private InnerStructType _Inner;

		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT{InnerStructType}"/> class.</summary>
		/// <param name="type">
		/// The template parameter <b>Type</b> specifies the subobject type; that is, the type of the structure specified by the template
		/// parameter <b>InnerStructType</b>.
		/// </param>
		/// <param name="inner">The value to assign the inner type specified by <typeparamref name="InnerStructType"/>.</param>
		internal CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE type, in InnerStructType inner)
		{
			_Type = type;
			_Inner = inner;
		}

		/// <summary>Performs an implicit conversion from <see cref="CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT{T}"/> to <typeparamref name="InnerStructType"/>.</summary>
		/// <param name="o">This type.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator InnerStructType(CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<InnerStructType> o) => o._Inner;
	}

	/// <summary>A helper structure used to wrap a <c>CD3DX12_VIEW_INSTANCING_DESC</c> structure. Allows shaders to render to multiple views with a single draw call; useful for stereo vision or cubemap generation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-view-instancing
	// typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;CD3DX12_VIEW_INSTANCING_DESC, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_VIEW_INSTANCING, CD3DX12_DEFAULT&gt; CD3DX12_PIPELINE_STATE_STREAM_VIEW_INSTANCING;
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_VIEW_INSTANCING : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_VIEW_INSTANCING_DESC>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_VIEW_INSTANCING"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_VIEW_INSTANCING(in D3D12_VIEW_INSTANCING_DESC? value = null) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_VIEW_INSTANCING, value ?? new())
		{
		}
	}

	/// <summary>A helper structure used to describe a vertex shader as a single object suitable for a stream description.</summary>
	/// <remarks>
	/// <para>CD3DX12_PIPELINE_STATE_STREAM_VS is a typedef specialization of the <c><b>CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT</b></c> template, and is defined as follows:</para>
	/// <para><c>typedef CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT&lt;D3D12_SHADER_BYTECODE, D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_VS&gt; CD3DX12_PIPELINE_STATE_STREAM_VS; </c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/direct3d12/cd3dx12-pipeline-state-stream-vs
	// struct CD3DX12_PIPELINE_STATE_STREAM_VS { CD3DX12_PIPELINE_STATE_STREAM_VS; CD3DX12_PIPELINE_STATE_STREAM_VS(D3D12_SHADER_BYTECODE const &amp;i); CD3DX12_PIPELINE_STATE_STREAM_VS operator=(D3D12_SHADER_BYTECODE const&amp; i); operator D3D12_SHADER_BYTECODE() const; };
	[PInvokeData("D3dx12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class CD3DX12_PIPELINE_STATE_STREAM_VS : CD3DX12_PIPELINE_STATE_STREAM_SUBOBJECT<D3D12_SHADER_BYTECODE>
	{
		/// <summary>Initializes a new instance of the <see cref="CD3DX12_PIPELINE_STATE_STREAM_VS"/> class.</summary>
		/// <param name="value">The value.</param>
		public CD3DX12_PIPELINE_STATE_STREAM_VS(in D3D12_SHADER_BYTECODE value) : base(D3D12_PIPELINE_STATE_SUBOBJECT_TYPE.D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_VS, value)
		{
		}
	}
}