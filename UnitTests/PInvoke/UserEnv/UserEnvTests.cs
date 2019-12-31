using NUnit.Framework;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.UserEnv;

namespace Vanara.PInvoke.Tests
{
	public class UserEnvTests
	{
		[Test]
		public void CreateDestroyEnvironmentBlockTest()
		{
			using var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_READ).Duplicate(SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation);
			Assert.That(CreateEnvironmentBlock(out var env, hTok, false), ResultIs.Successful);
			Assert.That(env, Has.Exactly(1).StartsWith("Path="));
			TestContext.Write(string.Join("\r\n", env));
		}
	}
}