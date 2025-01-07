using NUnit.Framework;
using static Vanara.PInvoke.D3D12;
using static Vanara.PInvoke.DXGI;

namespace Vanara.PInvoke.Tests;

public class D3D12Tests
{
	[Test]
	public void StructTest()
	{
		foreach (var ss in TestHelper.GetNestedStructSizes(typeof(D3D12)))
			TestContext.WriteLine(ss);
	}

	[Test]
	public void BasicTest()
	{
		Assert.That(D3D12CreateDevice(D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_12_1, null, out ID3D12Device? device), ResultIs.Successful);

		//Assert.That(() => device!.GetNodeCount(), Throws.Nothing);
		//Assert.That(() => device!.CreateCommandAllocator<ID3D12CommandAllocator>(D3D12_COMMAND_LIST_TYPE.D3D12_COMMAND_LIST_TYPE_DIRECT), Throws.Nothing);
		//Assert.That(device!.CheckFeatureSupport(D3D12_FEATURE.D3D12_FEATURE_FORMAT_SUPPORT, new D3D12_FEATURE_DATA_FORMAT_SUPPORT() { Format = DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT }), ResultIs.Successful);

		D3D12_HEAP_PROPERTIES bufferHeapProps = new() { Type = D3D12_HEAP_TYPE.D3D12_HEAP_TYPE_DEFAULT };
		D3D12_RESOURCE_DESC bufferDesc = new(D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER, 4096, 1, 1, 0, 1,
			DXGI_FORMAT.DXGI_FORMAT_UNKNOWN, 1, 0, D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_ROW_MAJOR, D3D12_RESOURCE_FLAGS.D3D12_RESOURCE_FLAG_NONE);
		Assert.That(() => device!.CreateCommittedResource<ID3D12Resource>(bufferHeapProps, D3D12_HEAP_FLAGS.D3D12_HEAP_FLAG_NONE,
			bufferDesc, D3D12_RESOURCE_STATES.D3D12_RESOURCE_STATE_COMMON), Throws.Nothing);

		Assert.That(() => device!.SetStablePowerState(true), Throws.Nothing);
	}

	[Test]
	public void From11on12Sample()
	{
		float m_aspectRatio = 1.0f;
		Assert.That(D3D12CreateDevice(D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_12_1, null, out ID3D12Device? m_d3d12Device), ResultIs.Successful);

		Assert.That(m_d3d12Device!.CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE.D3D12_COMMAND_LIST_TYPE_DIRECT, out ID3D12CommandAllocator? m_commandAllocator), ResultIs.Successful);

		var m_commandList = m_d3d12Device!.CreateCommandList<ID3D12GraphicsCommandList>(0, D3D12_COMMAND_LIST_TYPE.D3D12_COMMAND_LIST_TYPE_DIRECT, m_commandAllocator!);
		m_commandList.SetName(nameof(m_commandList));

		// Define the geometry for a triangle.
		using SafeNativeArray<Vertex> triangleVertices = [
			new() { position = new(0.0f, 0.25f * m_aspectRatio, 0.0f), color = new(1.0f, 0.0f, 0.0f, 1.0f) },
			new() { position = new(0.25f, -0.25f * m_aspectRatio, 0.0f), color = new(0.0f, 1.0f, 0.0f, 1.0f) },
			new() { position = new(-0.25f, -0.25f * m_aspectRatio, 0.0f), color = new(0.0f, 0.0f, 1.0f, 1.0f) }
		];

		ID3D12Resource m_vertexBuffer = m_d3d12Device!.CreateCommittedResource<ID3D12Resource>(new(D3D12_HEAP_TYPE.D3D12_HEAP_TYPE_DEFAULT),
			D3D12_HEAP_FLAGS.D3D12_HEAP_FLAG_NONE, D3D12_RESOURCE_DESC.Buffer(triangleVertices.Size), D3D12_RESOURCE_STATES.D3D12_RESOURCE_STATE_COPY_DEST);
		m_vertexBuffer.SetName(nameof(m_vertexBuffer));

		ID3D12Resource vertexBufferUpload = m_d3d12Device!.CreateCommittedResource<ID3D12Resource>(new(D3D12_HEAP_TYPE.D3D12_HEAP_TYPE_UPLOAD), D3D12_HEAP_FLAGS.D3D12_HEAP_FLAG_NONE,
			D3D12_RESOURCE_DESC.Buffer(triangleVertices.Size), D3D12_RESOURCE_STATES.D3D12_RESOURCE_STATE_GENERIC_READ);

		// Copy data to the intermediate upload heap and then schedule a copy from the upload heap to the vertex buffer.
		D3D12_SUBRESOURCE_DATA[] vertexData = [new(triangleVertices, triangleVertices.Size, triangleVertices.Size)];
		UpdateSubresources(m_commandList, m_vertexBuffer, vertexBufferUpload, 0, 0, vertexData.Length, vertexData);
		m_commandList.ResourceBarrier(1, [D3D12_RESOURCE_BARRIER.CreateTransition(m_vertexBuffer,
			D3D12_RESOURCE_STATES.D3D12_RESOURCE_STATE_COPY_DEST,
			D3D12_RESOURCE_STATES.D3D12_RESOURCE_STATE_VERTEX_AND_CONSTANT_BUFFER)]);

		// Initialize the vertex buffer view.
		//m_vertexBufferView.BufferLocation = m_vertexBuffer.GetGPUVirtualAddress();
		//m_vertexBufferView.StrideInBytes = (uint)Marshal.SizeOf(typeof(Vertex));
		//m_vertexBufferView.SizeInBytes = vertexBufferSize;
	}

	[StructLayout(LayoutKind.Sequential)]
	private struct Vertex
	{
		public D3DCOLORVALUE color;
		public D2D_VECTOR_3F position;
	}
}