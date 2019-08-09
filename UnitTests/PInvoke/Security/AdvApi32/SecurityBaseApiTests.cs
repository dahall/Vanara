using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class SecurityBaseApiTests
	{
		[Test]
		public void AddResourceAttributeAceTest()
		{
			using (var pNewSacl = new SafePACL(256))
			{
				using (var capId = new SafePSID("S-1-17-22"))
					Assert.That(AddScopedPolicyIDAce(pNewSacl, ACL_REVISION, 0, 0, capId), ResultIs.Successful);

				var attrValues = new[] { 12L, 32L };
				using (var pattrValues = SafeHGlobalHandle.CreateFromList(attrValues))
				{
					var csattr = new CLAIM_SECURITY_ATTRIBUTE_V1
					{
						Name = "Int",
						ValueType = CLAIM_SECURITY_ATTRIBUTE_TYPE.CLAIM_SECURITY_ATTRIBUTE_TYPE_INT64,
						ValueCount = (uint)attrValues.Length,
						Values = new CLAIM_SECURITY_ATTRIBUTE_V1.VALUESUNION { pInt64 = (IntPtr)pattrValues }
					};
					var attr = new[] { csattr };
					using (var pattr = SafeHGlobalHandle.CreateFromList(attr))
					{
						var csi = CLAIM_SECURITY_ATTRIBUTES_INFORMATION.Default;
						csi.AttributeCount = (uint)attr.Length;
						csi.Attribute.pAttributeV1 = (IntPtr)pattr;
						var len = 0U;
						Assert.That(AddResourceAttributeAce(pNewSacl, ACL_REVISION, 0, 0, SafePSID.Everyone, csi, ref len), ResultIs.Successful);
					}
				}
			}
		}

		[Test]
		public void CheckTokenCapabilityTest()
		{
			using (var hTok = SafeHTOKEN.CurrentProcessToken)
				Assert.That(CheckTokenCapability(hTok, SafePSID.Current, out var has), ResultIs.Successful);
		}

		[Test]
		public void DeriveCapabilitySidsFromNameTest()
		{
			Assert.That(DeriveCapabilitySidsFromName("microsoft.hsaTestCustomCapability_q536wpkpf5cy2", out var grpsids, out var grpcnt, out var sids, out var cnt), ResultIs.Successful);
			grpsids.Count = grpcnt; sids.Count = cnt;
			Assert.That(grpsids.Count, Is.EqualTo(grpcnt));
			Assert.That(grpsids, Is.Not.Empty);
			Assert.That(sids, Is.Not.Empty);
		}
	}
}