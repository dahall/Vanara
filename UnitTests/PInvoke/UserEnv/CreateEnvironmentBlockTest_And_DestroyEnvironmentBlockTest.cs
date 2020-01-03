using NUnit.Framework;
using System;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.UserEnv;

namespace Vanara.PInvoke.Tests
{
	public partial class UserEnvTests
	{
		[Test]
		public void CreateEnvironmentBlockTest_And_DestroyEnvironmentBlockTest()
		{
			SafeHTOKEN hToken;

			using (hToken = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_READ).Duplicate(SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation))
			{
				Assert.IsFalse(hToken.IsClosed);

				Assert.That(CreateEnvironmentBlock(out var environmentBlock, hToken, false), ResultIs.Successful);


				// Test all environment variables.

				var allEnvironmentVariables = Environment.GetEnvironmentVariables();

				foreach (var envVar in environmentBlock)
				{
					var envVarName = envVar.Split('=')[0];

					if (allEnvironmentVariables.Contains(envVarName))
					{
						var envVarValue = Environment.GetEnvironmentVariable(envVarName);

						Assert.AreEqual(allEnvironmentVariables[envVarName], envVarValue);

						TestContext.WriteLine(envVar);
					}

					else
					{
						TestContext.WriteLine();
						TestContext.WriteLine($"*** UNAVAILABLE: {envVar}");
						TestContext.WriteLine();
					}
				}
			}


			Assert.IsTrue(hToken.IsClosed);
		}
	}
}
