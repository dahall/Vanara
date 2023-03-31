using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public partial class WinBaseTests_TxF
{
	[Test]
	public void TxFTest()
	{
		// Unable to test actual functions, so just make sure signatures work
		Assert.That(() =>
		{
			bool b = false;
			CopyFileTransacted(default, default, default, default, ref b, default, default);
			CreateDirectoryTransacted(default, default, default, default);
			CreateFileTransacted(default, default, default, default, default, default, default, default, default, default);
			CreateHardLinkTransacted(default, default, default, default);
			DeleteFileTransacted(default, default);
			uint u = 0U;
			FindFirstFileNameTransactedW(default, default, ref u, default, default);
			FindFirstFileTransacted(default, default, out _, default, default, default, default);
			FindFirstStreamTransactedW(default, default, out _, default, default);
			WIN32_FILE_ATTRIBUTE_DATA fd = default(WIN32_FILE_ATTRIBUTE_DATA);
			GetFileAttributesTransacted(default, default, ref fd, default);
			GetFullPathNameTransacted(default, default, default, out _, default);
			GetLongPathNameTransacted(default, default, default, default);
			MoveFileTransacted(default, default, default, default, default, default);
			RemoveDirectoryTransacted(default, default);
			SetFileAttributesTransacted(default, default, default);
		}, Throws.Nothing);
	}
}