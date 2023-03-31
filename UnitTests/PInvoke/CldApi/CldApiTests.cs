using ICSharpCode.Decompiler.TypeSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Vanara.Extensions;
using Vanara.InteropServices;
using Windows.Storage.Streams;
using static Vanara.PInvoke.CldApi;

namespace Vanara.PInvoke.Tests;

public class CldApiTests
{
	private static readonly string syncRootPath = Environment.GetEnvironmentVariable("OneDrive");
	//private const string tempSubDir = "CfSource";

	private static string SetupTempDir(string subDir) => Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), subDir)).FullName;

	private static void DeleteTempDir(string subDir)
	{
		var dirInfo = new DirectoryInfo(Path.Combine(Path.GetTempPath(), subDir));
		if (dirInfo.Exists) dirInfo.Delete(true);
	}

	[Test]
	public void CfConnectSyncRootTest()
	{
		const string dest = "CfDest";
		var destDirPath = SetupTempDir(dest);
		try
		{
			using var csp = new CloudSyncProvider(destDirPath, "TestSync") { Status = CF_SYNC_PROVIDER_STATUS.CF_PROVIDER_STATUS_IDLE };
			csp.Status.WriteValues();

			const string desc = "SyncStatus is good.";
			Assert.That(() => csp.ReportSyncStatus(desc, 1), Throws.Nothing);
		}
		finally
		{
			DeleteTempDir(dest);
		}
	}

	[Test]
	public void CfCreatePlaceholdersTest()
	{
		const string dest = "CfDest";
		const string fname = "test.bmp";
		var destDirPath = SetupTempDir(dest);
		var fpath = Path.Combine(destDirPath, fname);
		try
		{
			var tokSrc = new CancellationTokenSource();
			var token = tokSrc.Token;
			var evt = new ManualResetEventSlim();
			var task = Task.Run(() =>
			{
				using var csp = new CloudSyncProvider(destDirPath, "TestSync");

				csp.CancelFetchData += ShowInfo;
				csp.CancelFetchPlaceholders += ShowInfo;
				csp.FetchData += ShowInfo;
				csp.FetchPlaceholders += ShowInfo;
				csp.NotifyDehydrate += ShowInfo;
				csp.NotifyDehydrateCompletion += ShowInfo;
				csp.NotifyDelete += ShowInfo;
				csp.NotifyDeleteCompletion += ShowInfo;
				csp.NotifyFileCloseCompletion += ShowInfo;
				csp.NotifyFileOpenCompletion += ShowInfo;
				csp.NotifyRename += ShowInfo;
				csp.NotifyRenameCompletion += ShowInfo;
				csp.ValidateData += ShowInfo;

				var origFileInfo = new FileInfo(TestCaseSources.BmpFile);
				csp.CreatePlaceholderFromFile(fname, origFileInfo, true);
				Assert.That(File.Exists(fpath), Is.True);
				Assert.That(new FileInfo(fpath).Length, Is.EqualTo(origFileInfo.Length));

				Debug.WriteLine("CSP is running...................................\n");
				evt.Set();
				while (!token.IsCancellationRequested) { Task.Delay(100); }

				static void ShowInfo<T>(object s, CloudSyncCallbackArgs<T> e) where T : struct
				{
					Debug.WriteLine($"\n{typeof(T).Name}: {e.NormalizedPath ?? "(null)"}, {e.FileSize}\n" +
						Newtonsoft.Json.JsonConvert.SerializeObject(e.ParamData, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.Converters.StringEnumConverter()));

					if (typeof(T) == typeof(CF_CALLBACK_PARAMETERS.RENAME))
					{
						e.OperationType = CF_OPERATION_TYPE.CF_OPERATION_TYPE_ACK_RENAME;
						e.OpParam = CF_OPERATION_PARAMETERS.Create(new CF_OPERATION_PARAMETERS.ACKRENAME());
					}
					else if (typeof(T) == typeof(CF_CALLBACK_PARAMETERS.DEHYDRATE))
					{
						e.OperationType = CF_OPERATION_TYPE.CF_OPERATION_TYPE_ACK_DEHYDRATE;
						e.OpParam = CF_OPERATION_PARAMETERS.Create(new CF_OPERATION_PARAMETERS.ACKDEHYDRATE());
					}
					else if (typeof(T) == typeof(CF_CALLBACK_PARAMETERS.DELETE))
					{
						e.OperationType = CF_OPERATION_TYPE.CF_OPERATION_TYPE_ACK_DELETE;
						e.OpParam = CF_OPERATION_PARAMETERS.Create(new CF_OPERATION_PARAMETERS.ACKDELETE());
					}
					else if (typeof(T) == typeof(CF_CALLBACK_PARAMETERS.FETCHDATA))
					{
						var opInfo = e.MakeOpInfo(CF_OPERATION_TYPE.CF_OPERATION_TYPE_TRANSFER_DATA);
						using var buf = new PinnedObject(File.ReadAllBytes(TestCaseSources.BmpFile));
						var opParam = CF_OPERATION_PARAMETERS.Create(new CF_OPERATION_PARAMETERS.TRANSFERDATA { Buffer = buf, Length = new FileInfo(TestCaseSources.BmpFile).Length });
						var hr = CfExecute(opInfo, ref opParam);
						if (hr.Failed) Debug.WriteLine("CfExecute for transfer failed: " + hr.FormatMessage());
						hr = CfReportProviderProgress(e.ConnectionKey, e.TransferKey, 100, 100);
						if (hr.Failed) Debug.WriteLine("CfReportProviderProgress for transfer failed: " + hr.FormatMessage());
					}
				}
			}, tokSrc.Token);

			evt.Wait(); // Let CSP get loaded
			using var hFile = GetHFILE(fpath);
			Assert.That(hFile, ResultIs.ValidHandle);
			Assert.That(CfHydratePlaceholder(hFile), ResultIs.Successful);
			Assert.That(CfGetCorrelationVector(hFile, out var cv), ResultIs.Successful);
			using var buf = new SafeHGlobalHandle(128);
			Assert.That(CfGetPlaceholderRangeInfo(hFile, CF_PLACEHOLDER_RANGE_INFO_CLASS.CF_PLACEHOLDER_RANGE_INFO_ONDISK, 0, buf.Size, buf, buf.Size, out var rngLen), ResultIs.Successful);
			Assert.That(CfGetTransferKey(hFile, out var txKey), ResultIs.Successful);
			Assert.That(() => CfReleaseTransferKey(hFile, txKey), Throws.Nothing);
			Assert.That(CfDehydratePlaceholder(hFile, 0, -1, 0), ResultIs.Successful);
			//Thread.Sleep(2000); // Wait for user interaction

			tokSrc.Cancel();
			task.Wait();

			//CfGetPlaceholderRangeInfo(hFile, CF_PLACEHOLDER_RANGE_INFO_CLASS.CF_PLACEHOLDER_RANGE_INFO_ONDISK, 0, )
			//Assert.That(CfHydratePlaceholder(hFile, 0, -1, CF_HYDRATE_FLAGS.CF_HYDRATE_FLAG_NONE), ResultIs.Successful);
		}
		finally
		{
			DeleteTempDir(dest);
		}
	}

	private string CopyFile(string src, string destDir)
	{
		var destFile = Path.Combine(destDir, Path.GetFileName(src));
		File.Copy(src, destFile);
		Assert.That(File.Exists(destFile), Is.True);
		return destFile;
	}

	private Kernel32.SafeHFILE GetHFILE(string path) => Kernel32.CreateFile(path, Kernel32.FileAccess.FILE_READ_ATTRIBUTES, FileShare.Read, null, FileMode.Open, 0);

	[Test]
	public void CfGetPlaceholderInfoTest()
	{
		const string dest = "CfDest";
		var destDirPath = SetupTempDir(dest);
		try
		{
			using var csp = new CloudSyncProvider(destDirPath, "TestSync");

			// Copy in file and convert to placeholder
			var destFile = CopyFile(TestCaseSources.WordDoc, destDirPath);
			Assert.That(() => csp.ConvertToPlaceholder(destFile), Throws.Nothing);

			using var hFile = GetHFILE(destFile);
			Assert.That(() => CfGetPlaceholderInfo<CF_PLACEHOLDER_BASIC_INFO>(hFile).WriteValues(), Throws.Nothing);
			Assert.That(() => CfGetPlaceholderInfo<CF_PLACEHOLDER_STANDARD_INFO>(hFile).WriteValues(), Throws.Nothing);
		}
		finally
		{
			DeleteTempDir(dest);
		}
	}

	[Test]
	public void CfGetPlaceholderStateFromFindDataTest()
	{
		const string dest = "CfDest";
		var destDirPath = SetupTempDir(dest);
		try
		{
			using var csp = new CloudSyncProvider(destDirPath, "TestSync");
			csp.CreatePlaceholderFromFile("test.bmp", new FileInfo(TestCaseSources.BmpFile), true);
			Assert.That(File.Exists(Path.Combine(destDirPath, "test.bmp")), Is.True);

			Kernel32.FindFirstFile(Path.Combine(destDirPath, "test.bmp"), out var findData).Dispose();
			CfGetPlaceholderStateFromFindData(findData).WriteValues();
		}
		finally
		{
			DeleteTempDir(dest);
		}
	}

	[Test]
	public void CfSetInSyncStateTest()
	{
		const string dest = "CfDest";
		var destDirPath = SetupTempDir(dest);
		try
		{
			using var csp = new CloudSyncProvider(destDirPath, "TestSync");
			csp.CreatePlaceholderFromFile("test.bmp", new FileInfo(TestCaseSources.BmpFile), true);
			var destFile = Path.Combine(destDirPath, "test.bmp");
			Assert.That(File.Exists(destFile), Is.True);

			using var hFile = GetHFILE(destFile);
			Assert.That(CfSetInSyncState(hFile, CF_IN_SYNC_STATE.CF_IN_SYNC_STATE_IN_SYNC, CF_SET_IN_SYNC_FLAGS.CF_SET_IN_SYNC_FLAG_NONE), ResultIs.Successful);
			Assert.That(CfSetPinState(hFile, CF_PIN_STATE.CF_PIN_STATE_PINNED, CF_SET_PIN_FLAGS.CF_SET_PIN_FLAG_NONE), ResultIs.Successful);
		}
		finally
		{
			DeleteTempDir(dest);
		}
	}

	[Test]
	public void CfGetPlaceholderStateFromAttributeTagTest()
	{
		const string dest = "CfDest";
		var destDirPath = SetupTempDir(dest);
		try
		{
			using var csp = new CloudSyncProvider(destDirPath, "TestSync");
			var destFile = CopyFile(TestCaseSources.WordDoc, destDirPath);
			Assert.That(() => csp.ConvertToPlaceholder(destFile), Throws.Nothing);

			using var hFile = GetHFILE(destFile);
			Kernel32.FILE_ATTRIBUTE_TAG_INFO info = default;
			Assert.That(() => info = Kernel32.GetFileInformationByHandleEx<Kernel32.FILE_ATTRIBUTE_TAG_INFO>(hFile, Kernel32.FILE_INFO_BY_HANDLE_CLASS.FileAttributeTagInfo), Throws.Nothing);
			info.WriteValues();
			CfGetPlaceholderStateFromAttributeTag(info.FileAttributes, info.ReparseTag).WriteValues();

			using var mem = SafeHGlobalHandle.CreateFromStructure(info);
			CfGetPlaceholderStateFromFileInfo(mem, Kernel32.FILE_INFO_BY_HANDLE_CLASS.FileAttributeTagInfo).WriteValues();
		}
		finally
		{
			DeleteTempDir(dest);
		}
	}

	[Test]
	public void CfGetPlatformInfoTest()
	{
		Assert.That(CfGetPlatformInfo(out var info), ResultIs.Successful);
		info.WriteValues();
	}

	[Test]
	public void CfGetSyncRootInfoByHandleTest()
	{
		using var hFile = GetHFILE(new DirectoryInfo(syncRootPath).EnumerateFiles("*.*").First().FullName);
		Assert.That(hFile, ResultIs.ValidHandle);
		using (var mem = SafeHGlobalHandle.CreateFromStructure<CF_SYNC_ROOT_BASIC_INFO>())
		{
			Assert.That(CfGetSyncRootInfoByHandle(hFile, CF_SYNC_ROOT_INFO_CLASS.CF_SYNC_ROOT_INFO_BASIC, mem, mem.Size, out var len), ResultIs.Successful);
			mem.ToStructure<CF_SYNC_ROOT_BASIC_INFO>().WriteValues();
		}
		Assert.That(() => CfGetSyncRootInfoByHandle<CF_SYNC_ROOT_PROVIDER_INFO>(hFile).WriteValues(), Throws.Nothing);
		Assert.That(() => CfGetSyncRootInfoByHandle<CF_SYNC_ROOT_STANDARD_INFO>(hFile).WriteValues(), Throws.Nothing);
	}

	[Test]
	public void CfGetSyncRootInfoByPathTest()
	{
		using var mem = new SafeCoTaskMemStruct<CF_SYNC_ROOT_BASIC_INFO>();
		Assert.That(CfGetSyncRootInfoByPath(syncRootPath, CF_SYNC_ROOT_INFO_CLASS.CF_SYNC_ROOT_INFO_BASIC, mem, mem.Size, out var len), ResultIs.Successful);
		mem.Value.WriteValues();
		Assert.That(() => CfGetSyncRootInfoByPath<CF_SYNC_ROOT_PROVIDER_INFO>(syncRootPath).WriteValues(), Throws.Nothing);
		Assert.That(() => CfGetSyncRootInfoByPath<CF_SYNC_ROOT_STANDARD_INFO>(syncRootPath).WriteValues(), Throws.Nothing);
	}

	[Test]
	public void CfOpenFileWithOplockTest()
	{
		Assert.That(CfOpenFileWithOplock(TestCaseSources.SmallFile, CF_OPEN_FILE_FLAGS.CF_OPEN_FILE_FLAG_EXCLUSIVE, out var handle), ResultIs.Successful);
		Assert.That(handle, ResultIs.ValidHandle);
		Assert.That(CfReferenceProtectedHandle(handle), ResultIs.Successful);
		Assert.That(CfGetWin32HandleFromProtectedHandle(handle), ResultIs.ValidHandle);
		Assert.That(() => CfReleaseProtectedHandle(handle), Throws.Nothing);
		Assert.That(() => handle.Dispose(), Throws.Nothing);
	}
}