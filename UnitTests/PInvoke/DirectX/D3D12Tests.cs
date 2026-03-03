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

		D3D12_HEAP_PROPERTIES bufferHeapProps = new() { Type = D3D12_HEAP_TYPE.D3D12_HEAP_TYPE_DEFAULT };
		D3D12_RESOURCE_DESC bufferDesc = new(D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER, 0, 4096, 1, 1, 1,
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
	}

	[Test]
	public void TestResourceBarrier()
	{
		// Initialize D3D12 device and command list
		Assert.That(D3D12CreateDevice(D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_12_0, null, out ID3D12Device? device), ResultIs.Successful);
		Assert.That(device!.CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE.D3D12_COMMAND_LIST_TYPE_DIRECT, out ID3D12CommandAllocator? commandAllocator), ResultIs.Successful);
		Assert.That(device!.CreateCommandList(0, D3D12_COMMAND_LIST_TYPE.D3D12_COMMAND_LIST_TYPE_DIRECT, commandAllocator!, default, out ID3D12GraphicsCommandList? commandList), ResultIs.Successful);

		try
		{
			// Create dummy resources
			D3D12_HEAP_PROPERTIES heapProps = new(D3D12_HEAP_TYPE.D3D12_HEAP_TYPE_DEFAULT);
			D3D12_RESOURCE_DESC resourceDesc = new(D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER, 0, 1024, 1, 1, 1,
				DXGI_FORMAT.DXGI_FORMAT_UNKNOWN, 1, 0, D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_ROW_MAJOR, 0);
			Assert.That(device!.CreateCommittedResource(heapProps, D3D12_HEAP_FLAGS.D3D12_HEAP_FLAG_NONE, resourceDesc,
				D3D12_RESOURCE_STATES.D3D12_RESOURCE_STATE_COMMON, default, out ID3D12Resource? resource), ResultIs.Successful);

			// Define a resource barrier
			D3D12_RESOURCE_BARRIER barrier = D3D12_RESOURCE_BARRIER.CreateTransition(resource!, D3D12_RESOURCE_STATES.D3D12_RESOURCE_STATE_COMMON, D3D12_RESOURCE_STATES.D3D12_RESOURCE_STATE_COPY_DEST);

			// Apply the resource barrier
			commandList!.ResourceBarrier(1, [barrier]);
		}
		finally
		{
			// Close the command list
			Assert.That(commandList!.Close(), ResultIs.Successful);
		}
	}

	[Test]
	public void MarshaledStructTest()
	{
		D3D12_INFO_QUEUE_FILTER f = new()
		{
			AllowList = new()
			{
				pCategoryList = [D3D12_MESSAGE_CATEGORY.D3D12_MESSAGE_CATEGORY_EXECUTION],
				pSeverityList = [D3D12_MESSAGE_SEVERITY.D3D12_MESSAGE_SEVERITY_WARNING],
				pIDList = [D3D12_MESSAGE_ID.D3D12_MESSAGE_ID_COMMAND_LIST_CLOSED],
			},
			DenyList = new()
			{
				pCategoryList = [D3D12_MESSAGE_CATEGORY.D3D12_MESSAGE_CATEGORY_STATE_CREATION],
				pSeverityList = [D3D12_MESSAGE_SEVERITY.D3D12_MESSAGE_SEVERITY_ERROR],
				pIDList = [D3D12_MESSAGE_ID.D3D12_MESSAGE_ID_COMMAND_LIST_DESCRIPTOR_TABLE_NOT_SET],
			}
		};
		using var filter = SafeCoTaskMemHandle.CreateFromStructure(f);
		var values = filter.AsSpan<uint>(filter.Size / 4);
		TestContext.WriteLine(string.Join(", ", values.ToArray()));
		Assert.That((int)filter.Size, Is.EqualTo(16 * 3 * 2));
		Assert.That(values[0], Is.EqualTo(1)); // AllowList.pCategoryList count
		Assert.That(values[4], Is.EqualTo(1)); // AllowList.pSeverityList count
		Assert.That(values[8], Is.EqualTo(1)); // AllowList.pIDList count
		Assert.That((D3D12_MESSAGE_CATEGORY)Marshal.ReadInt32(Marshal.ReadIntPtr(filter.DangerousGetHandle().Offset(8))), Is.EqualTo(D3D12_MESSAGE_CATEGORY.D3D12_MESSAGE_CATEGORY_EXECUTION));
		Assert.That((D3D12_MESSAGE_ID)Marshal.ReadInt32(Marshal.ReadIntPtr(filter.DangerousGetHandle().Offset(88))), Is.EqualTo(D3D12_MESSAGE_ID.D3D12_MESSAGE_ID_COMMAND_LIST_DESCRIPTOR_TABLE_NOT_SET));
	}

	[Test]
	public void AddStorageFilterEntriesTest()
	{
		// Test to exercise ID3D12InfoQueue::AddStorageFilterEntries

		// Create a D3D12 device with debug layer enabled
		Assert.That(D3D12GetDebugInterface(out ID3D12Debug? debug), ResultIs.Successful);
		debug?.EnableDebugLayer();

		Assert.That(D3D12CreateDevice(D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_12_0, null, out ID3D12Device? device), ResultIs.Successful);

		// Query for the InfoQueue interface
		if (device is not ID3D12InfoQueue infoQueue)
		{
			Assert.Inconclusive("ID3D12InfoQueue interface not available. Debug layer may not be enabled.");
			return;
		}

		try
		{
			// Create a filter to allow only specific message categories and severities
			D3D12_INFO_QUEUE_FILTER filter = new()
			{
				AllowList = new()
				{
					pCategoryList = [D3D12_MESSAGE_CATEGORY.D3D12_MESSAGE_CATEGORY_EXECUTION, D3D12_MESSAGE_CATEGORY.D3D12_MESSAGE_CATEGORY_STATE_SETTING],
					pSeverityList = [D3D12_MESSAGE_SEVERITY.D3D12_MESSAGE_SEVERITY_WARNING, D3D12_MESSAGE_SEVERITY.D3D12_MESSAGE_SEVERITY_ERROR],
					pIDList = []
				},
				DenyList = new()
				{
					pCategoryList = [D3D12_MESSAGE_CATEGORY.D3D12_MESSAGE_CATEGORY_MISCELLANEOUS],
					pSeverityList = [D3D12_MESSAGE_SEVERITY.D3D12_MESSAGE_SEVERITY_INFO],
					pIDList = [D3D12_MESSAGE_ID.D3D12_MESSAGE_ID_COMMAND_LIST_DESCRIPTOR_TABLE_NOT_SET]
				}
			};

			// Add the storage filter entries
			Assert.That(infoQueue.AddStorageFilterEntries(filter), ResultIs.Successful);

			// Retrieve the filter
			Assert.That(infoQueue.GetStorageFilter(out var filter2), ResultIs.Successful);

			Assert.That(filter.AllowList.pSeverityList, Is.EquivalentTo(filter2!.Value.AllowList.pSeverityList));
			Assert.That(filter.DenyList.pIDList, Is.EquivalentTo(filter2!.Value.DenyList.pIDList));

			// Clear the storage filter
			infoQueue.ClearStorageFilter();

			// Verify filter was cleared
			SizeT clearedLength = 0;
			Assert.That(infoQueue.GetStorageFilter(default, ref clearedLength), ResultIs.Successful);
			Assert.That((int)clearedLength, Is.EqualTo(Marshaler.Marshaler.SizeOf<D3D12_INFO_QUEUE_FILTER>()));
		}
		finally
		{
			// Clean up
			infoQueue?.ClearStorageFilter();
		}
	}
	[StructLayout(LayoutKind.Sequential)]
	private struct Vertex
	{
		public D3DCOLORVALUE color;
		public D2D_VECTOR_3F position;
	}
}