using ICSharpCode.Decompiler.TypeSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using Windows.Storage.Streams;
using static Vanara.PInvoke.CldApi;

namespace Vanara.PInvoke.Tests
{
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
				using var csp = new CloudSyncProvider(destDirPath, "TestSync");
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
			var destDirPath = SetupTempDir(dest);
			try
			{
				using var csp = new CloudSyncProvider(destDirPath, "TestSync");

				csp.CancelFetchData += (s, e) => { TestContext.WriteLine($"CancelFetchData: {e.NormalizedPath}, {e.FileSize}"); e.ParamData.WriteValues(); };
				csp.CancelFetchPlaceholders += (s, e) => { TestContext.WriteLine($"CancelFetchPlaceholders: {e.NormalizedPath}, {e.FileSize}"); e.ParamData.WriteValues(); };
				csp.FetchData += (s, e) => { TestContext.WriteLine($"FetchData: {e.NormalizedPath}, {e.FileSize}"); e.ParamData.WriteValues(); };
				csp.FetchPlaceholders += (s, e) => { TestContext.WriteLine($"FetchPlaceholders: {e.NormalizedPath}, {e.FileSize}"); e.ParamData.WriteValues(); };
				csp.NotifyDehydrate += (s, e) => { TestContext.WriteLine($"NotifyDehydrate: {e.NormalizedPath}, {e.FileSize}"); e.ParamData.WriteValues(); };
				csp.NotifyDehydrateCompletion += (s, e) => { TestContext.WriteLine($"NotifyDehydrateCompletion: {e.NormalizedPath}, {e.FileSize}"); e.ParamData.WriteValues(); };
				csp.NotifyDelete += (s, e) => { TestContext.WriteLine($"NotifyDelete: {e.NormalizedPath}, {e.FileSize}"); e.ParamData.WriteValues(); };
				csp.NotifyDeleteCompletion += (s, e) => { TestContext.WriteLine($"NotifyDeleteCompletion: {e.NormalizedPath}, {e.FileSize}"); e.ParamData.WriteValues(); };
				csp.NotifyFileCloseCompletion += (s, e) => { TestContext.WriteLine($"NotifyFileCloseCompletion: {e.NormalizedPath}, {e.FileSize}"); e.ParamData.WriteValues(); };
				csp.NotifyFileOpenCompletion += (s, e) => { TestContext.WriteLine($"NotifyFileOpenCompletion: {e.NormalizedPath}, {e.FileSize}"); e.ParamData.WriteValues(); };
				csp.NotifyRename += (s, e) => { TestContext.WriteLine($"NotifyRename: {e.NormalizedPath}, {e.FileSize}"); e.ParamData.WriteValues(); };
				csp.NotifyRenameCompletion += (s, e) => { TestContext.WriteLine($"NotifyRenameCompletion: {e.NormalizedPath}, {e.FileSize}"); e.ParamData.WriteValues(); };
				csp.ValidateData += (s, e) => { TestContext.WriteLine($"ValidateData: {e.NormalizedPath}, {e.FileSize}"); e.ParamData.WriteValues(); };

				csp.CreatePlaceholderFromFile("test.bmp", new FileInfo(TestCaseSources.BmpFile), true);
				Assert.That(File.Exists(Path.Combine(destDirPath, "test.bmp")), Is.True);
				Assert.That(new FileInfo(Path.Combine(destDirPath, "test.bmp")).Length, Is.EqualTo(new FileInfo(TestCaseSources.BmpFile).Length));

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
			using (var mem = SafeHGlobalHandle.CreateFromStructure<CF_SYNC_ROOT_BASIC_INFO>())
			{
				Assert.That(CfGetSyncRootInfoByPath(syncRootPath, CF_SYNC_ROOT_INFO_CLASS.CF_SYNC_ROOT_INFO_BASIC, mem, mem.Size, out var len), ResultIs.Successful);
				mem.ToStructure<CF_SYNC_ROOT_BASIC_INFO>().WriteValues();
			}
			Assert.That(() => CfGetSyncRootInfoByPath<CF_SYNC_ROOT_PROVIDER_INFO>(syncRootPath).WriteValues(), Throws.Nothing);
			Assert.That(() => CfGetSyncRootInfoByPath<CF_SYNC_ROOT_STANDARD_INFO>(syncRootPath).WriteValues(), Throws.Nothing);
		}

		[Test]
		public void CfOpenFileWithOplockTest()
		{
			Assert.That(CfOpenFileWithOplock(TestCaseSources.SmallFile, CF_OPEN_FILE_FLAGS.CF_OPEN_FILE_FLAG_EXCLUSIVE, out var handle), ResultIs.Successful);
			Assert.That(handle, ResultIs.ValidHandle);
			Assert.That(() => handle.Dispose(), Throws.Nothing);
		}
	}
}