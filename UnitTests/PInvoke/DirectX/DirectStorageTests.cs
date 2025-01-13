using NUnit.Framework;
using static Vanara.PInvoke.DStorage;
using static Vanara.PInvoke.D3D12;
using static Vanara.PInvoke.DXGI;

namespace Vanara.PInvoke.Tests;

public class DirectStorageTests
{
	[Test]
	public void StructTest()
	{
		foreach (var ss in TestHelper.GetNestedStructSizes(typeof(DStorage)))
			TestContext.WriteLine(ss);
	}

	[Test]
	public void BasicTest()
	{
		string fileName = TestCaseSources.WordDoc;
		long fileSize = new System.IO.FileInfo(fileName).Length;

		ID3D12Device device = D3D12CreateDevice(D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_12_1) ?? throw new Exception();
		IDStorageFactory factory = DStorageGetFactory<IDStorageFactory>();
		IDStorageFile file = factory.OpenFile<IDStorageFile>(fileName);

		DSTORAGE_QUEUE_DESC queueDesc = new()
		{
			Capacity = DSTORAGE_MAX_QUEUE_CAPACITY,
			Priority = DSTORAGE_PRIORITY.DSTORAGE_PRIORITY_NORMAL,
			SourceType = DSTORAGE_REQUEST_SOURCE_TYPE.DSTORAGE_REQUEST_SOURCE_FILE,
			Device = device,
		};
		IDStorageQueue queue = factory.CreateQueue<IDStorageQueue>(queueDesc);

		D3D12_HEAP_PROPERTIES bufferHeapProps = new() { Type = D3D12_HEAP_TYPE.D3D12_HEAP_TYPE_DEFAULT };
		D3D12_RESOURCE_DESC bufferDesc = new()
		{
			Dimension = D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER,
			Width = 4096,
			Height = 1,
			DepthOrArraySize = 1,
			MipLevels = 1,
			Format = DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,
			Layout = D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_ROW_MAJOR,
			SampleDesc = new() { Count = 1 }
		};
		ID3D12Resource bufferResource = device!.CreateCommittedResource<ID3D12Resource>(bufferHeapProps, D3D12_HEAP_FLAGS.D3D12_HEAP_FLAG_NONE,
			bufferDesc, D3D12_RESOURCE_STATES.D3D12_RESOURCE_STATE_COMMON);

		DSTORAGE_REQUEST request = new()
		{
			Options = new()
			{
				SourceType = DSTORAGE_REQUEST_SOURCE_TYPE.DSTORAGE_REQUEST_SOURCE_FILE,
				DestinationType = DSTORAGE_REQUEST_DESTINATION_TYPE.DSTORAGE_REQUEST_DESTINATION_BUFFER,
			},
			Source = new()
			{
				File = new()
				{
					Source = new(file),
					Size = (uint)fileSize,
				},
			},
			UncompressedSize = (uint)fileSize,
			Destination = new()
			{
				Buffer = new()
				{
					Resource = new(bufferResource),
					Size = (uint)fileSize,
				},
			},
		};
		queue.EnqueueRequest(request);

		ID3D12Fence fence = device.CreateFence<ID3D12Fence>();

		using var fenceEvent = Kernel32.CreateEvent();
		if (fenceEvent.IsInvalid) throw Win32Error.GetLastError().GetException()!;
		fence.SetEventOnCompletion(1, fenceEvent).ThrowIfFailed();
		queue.EnqueueSignal(fence, 1);

		queue.Submit();

		fenceEvent.Wait();

		queue.RetrieveErrorRecord(out var errorRecord);
		Assert.That(errorRecord.FirstFailure.HResult, ResultIs.Successful);
	}
}