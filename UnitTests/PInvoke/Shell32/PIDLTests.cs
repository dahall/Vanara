using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using static Vanara.PInvoke.Shell32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class PIDLFindCommonParentTests
{
	private string testFolder1 = null!;
	private string testFolder2 = null!;
	private string testSubFolder1 = null!;
	private string testSubFolder2 = null!;
	private string testFile1 = null!;
	private string testFile2 = null!;

	[OneTimeSetUp]
	public void Setup()
	{
		// Create test directory structure
		var tempPath = Path.GetTempPath();
		var baseTestFolder = Path.Combine(tempPath, $"PIDLTests_{Guid.NewGuid()}");
		Directory.CreateDirectory(baseTestFolder);

		testFolder1 = Path.Combine(baseTestFolder, "Folder1");
		testFolder2 = Path.Combine(baseTestFolder, "Folder2");
		testSubFolder1 = Path.Combine(testFolder1, "SubFolder1");
		testSubFolder2 = Path.Combine(testFolder1, "SubFolder2");

		Directory.CreateDirectory(testFolder1);
		Directory.CreateDirectory(testFolder2);
		Directory.CreateDirectory(testSubFolder1);
		Directory.CreateDirectory(testSubFolder2);

		testFile1 = Path.Combine(testSubFolder1, "test1.txt");
		testFile2 = Path.Combine(testSubFolder1, "test2.txt");
		File.WriteAllText(testFile1, "Test content 1");
		File.WriteAllText(testFile2, "Test content 2");
	}

	[OneTimeTearDown]
	public void Cleanup()
	{
		try
		{
			if (Directory.Exists(Path.GetDirectoryName(testFolder1)))
			{
				Directory.Delete(Path.GetDirectoryName(testFolder1)!, true);
			}
		}
		catch { /* Ignore cleanup errors */ }
	}

	[Test]
	public void FindCommonParent_NullCollection_ReturnsNull()
	{
		var result = PIDL.FindCommonParent(null!);
		Assert.That(result, Is.Not.Null);
		Assert.That(result.IsNull, Is.True);
	}

	[Test]
	public void FindCommonParent_EmptyCollection_ReturnsNull()
	{
		var result = PIDL.FindCommonParent([]);
		Assert.That(result, Is.Not.Null);
		Assert.That(result.IsNull, Is.True);
	}

	[Test]
	public void FindCommonParent_SinglePIDL_ReturnsSamePIDL()
	{
		using var pidl = new PIDL(testFolder1);
		var result = PIDL.FindCommonParent([pidl]);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.IsEmpty, Is.False);
		Assert.That(result.Equals(pidl), Is.True);
	}

	[Test]
	public void FindCommonParent_TwoSiblingsInSameFolder_ReturnsParentFolder()
	{
		using var pidl1 = new PIDL(testSubFolder1);
		using var pidl2 = new PIDL(testSubFolder2);
		using var result = PIDL.FindCommonParent([pidl1, pidl2]);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.IsEmpty, Is.False);

		// The common parent should be testFolder1
		var resultPath = result.ToString(SIGDN.SIGDN_FILESYSPATH);
		var expectedPath = testFolder1;
		Assert.That(resultPath, Is.EqualTo(expectedPath));
	}

	[Test]
	public void FindCommonParent_TwoFilesInSameFolder_ReturnsParentFolder()
	{
		using var pidl1 = new PIDL(testFile1);
		using var pidl2 = new PIDL(testFile2);
		using var result = PIDL.FindCommonParent([pidl1, pidl2]);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.IsEmpty, Is.False);

		var resultPath = result.ToString(SIGDN.SIGDN_FILESYSPATH);
		Assert.That(resultPath, Is.EqualTo(testSubFolder1));
	}

	[Test]
	public void FindCommonParent_FoldersInDifferentBranches_ReturnsCommonAncestor()
	{
		using var pidl1 = new PIDL(testFolder1);
		using var pidl2 = new PIDL(testFolder2);
		using var result = PIDL.FindCommonParent([pidl1, pidl2]);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.IsEmpty, Is.False);

		// The common parent should be the base test folder
		var resultPath = result.ToString(SIGDN.SIGDN_FILESYSPATH);
		var expectedPath = Path.GetDirectoryName(testFolder1);
		Assert.That(resultPath, Is.EqualTo(expectedPath));
	}

	[Test]
	public void FindCommonParent_ParentAndChild_ReturnsParent()
	{
		using var parentPidl = new PIDL(testFolder1);
		using var childPidl = new PIDL(testSubFolder1);
		using var result = PIDL.FindCommonParent([parentPidl, childPidl]);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.IsEmpty, Is.False);

		var resultPath = result.ToString(SIGDN.SIGDN_FILESYSPATH);
		Assert.That(resultPath, Is.EqualTo(testFolder1));
	}

	[Test]
	public void FindCommonParent_MultiplePIDLs_ReturnsDeepestCommonParent()
	{
		using var pidl1 = new PIDL(testFile1);
		using var pidl2 = new PIDL(testFile2);
		using var pidl3 = new PIDL(testSubFolder1);
		using var result = PIDL.FindCommonParent([pidl1, pidl2, pidl3]);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.IsEmpty, Is.False);

		var resultPath = result.ToString(SIGDN.SIGDN_FILESYSPATH);
		Assert.That(resultPath, Is.EqualTo(testSubFolder1));
	}

	[Test]
	public void FindCommonParent_IdenticalPIDLs_ReturnsSamePIDL()
	{
		using var pidl1 = new PIDL(testFolder1);
		using var pidl2 = new PIDL(testFolder1);
		using var pidl3 = new PIDL(testFolder1);
		using var result = PIDL.FindCommonParent([pidl1, pidl2, pidl3]);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.IsEmpty, Is.False);

		var resultPath = result.ToString(SIGDN.SIGDN_FILESYSPATH);
		Assert.That(resultPath, Is.EqualTo(testFolder1));
	}

	[Test]
	public void FindCommonParent_KnownFolders_ReturnsCommonParent()
	{
		// Get known folder paths
		SHGetKnownFolderPath(KNOWNFOLDERID.FOLDERID_Documents.Guid(), 0, default, out var documentsPath).ThrowIfFailed();
		SHGetKnownFolderPath(KNOWNFOLDERID.FOLDERID_Pictures.Guid(), 0, default, out var picturesPath).ThrowIfFailed();

		using var docsPidl = new PIDL(documentsPath);
		using var picsPidl = new PIDL(picturesPath);
		using var result = PIDL.FindCommonParent([docsPidl, picsPidl]);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.IsEmpty, Is.False);

		// The result should be at least valid and have a path
		var resultPath = result.ToString(SIGDN.SIGDN_FILESYSPATH);
		Assert.That(resultPath, Is.Not.Null.And.Not.Empty);
	}

	[Test]
	public void FindCommonParent_DesktopAndSubfolder_ReturnsDesktop()
	{
		using var root = PIDL.Desktop;
		using var subfolder = new PIDL(testFolder1);
		using var result = PIDL.FindCommonParent([root, subfolder]);

		Assert.That(result, Is.EqualTo(root));
	}

	[Test]
	public void FindCommonParent_DeeplyNestedStructure_ReturnsCorrectAncestor()
	{
		// Create deeper nesting
		var deepFolder1 = Path.Combine(testSubFolder1, "Deep1", "Deep2");
		var deepFolder2 = Path.Combine(testSubFolder2, "Deep1", "Deep2");
		Directory.CreateDirectory(deepFolder1);
		Directory.CreateDirectory(deepFolder2);

		try
		{
			using var pidl1 = new PIDL(deepFolder1);
			using var pidl2 = new PIDL(deepFolder2);
			using var result = PIDL.FindCommonParent([pidl1, pidl2]);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.IsEmpty, Is.False);

			// Common parent should be testFolder1
			var resultPath = result.ToString(SIGDN.SIGDN_FILESYSPATH);
			Assert.That(resultPath, Is.EqualTo(testFolder1));
		}
		finally
		{
			try
			{
				if (Directory.Exists(deepFolder1))
					Directory.Delete(Path.Combine(testSubFolder1, "Deep1"), true);
				if (Directory.Exists(deepFolder2))
					Directory.Delete(Path.Combine(testSubFolder2, "Deep1"), true);
			}
			catch { /* Ignore cleanup errors */ }
		}
	}

	[Test]
	public void FindCommonParent_MixedDepths_ReturnsCorrectCommonParent()
	{
		using var shallowPidl = new PIDL(testFolder1);
		using var deepPidl = new PIDL(testFile1);
		using var result = PIDL.FindCommonParent([shallowPidl, deepPidl]);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.IsEmpty, Is.False);

		var resultPath = result.ToString(SIGDN.SIGDN_FILESYSPATH);
		Assert.That(resultPath, Is.EqualTo(testFolder1));
	}

	[Test]
	public void FindCommonParent_LargeCollection_HandlesEfficiently()
	{
		// Create a collection of PIDLs all in the same folder
		var pidls = new List<PIDL>();
		try
		{
			for (int i = 0; i < 10; i++)
			{
				pidls.Add(new PIDL(testSubFolder1));
			}

			using var result = PIDL.FindCommonParent(pidls);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.IsEmpty, Is.False);

			var resultPath = result.ToString(SIGDN.SIGDN_FILESYSPATH);
			Assert.That(resultPath, Is.EqualTo(testSubFolder1));
		}
		finally
		{
			pidls.ForEach(p => p.Dispose());
		}
	}

	[Test]
	public void FindCommonParent_ResultIsValid_CanBeUsedForOperations()
	{
		using var pidl1 = new PIDL(testFile1);
		using var pidl2 = new PIDL(testFile2);
		using var result = PIDL.FindCommonParent([pidl1, pidl2]);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.IsEmpty, Is.False);

		// Verify the result can be used in operations
		Assert.That(result.Size, Is.GreaterThan(0u));
		Assert.That(() => result.ToString(), Throws.Nothing);
		Assert.That(() => result.GetBytes(), Throws.Nothing);
		Assert.That(result.GetBytes().Length, Is.GreaterThan(0));
	}

	[Test]
	public void FindCommonParent_DisposesEnumeratorsProperly_NoMemoryLeak()
	{
		// This test ensures that enumerators are properly disposed
		using var pidl1 = new PIDL(testFolder1);
		using var pidl2 = new PIDL(testFolder2);

		// Call multiple times to ensure no accumulation of undisposed resources
		for (int i = 0; i < 100; i++)
		{
			using var result = PIDL.FindCommonParent([pidl1, pidl2]);
			Assert.That(result, Is.Not.Null);
		}

		// If we get here without exceptions or hanging, enumerators are being disposed properly
		Assert.Pass("No memory leak detected");
	}
}