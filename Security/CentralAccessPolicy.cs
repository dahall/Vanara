using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Principal;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Security
{
	public static partial class AccountUtils
	{
		/// <summary>Represents a central access policy that contains a set of central access policy entries.</summary>
		public class CentralAccessPolicy
		{
			internal CentralAccessPolicy(in CENTRAL_ACCESS_POLICY cap)
			{
				Id = new SecurityIdentifier(cap.CAPID.DangerousGetHandle());
				Name = cap.Name;
				ChangeId = cap.ChangeId;
				Entries = Array.ConvertAll(cap.CAPEs.ToArray<CENTRAL_ACCESS_POLICY_ENTRY>((int)cap.CAPECount), e => new CentralAccessPolicyEntry(e));
			}

			/// <summary>An identifier that can be used to version the central access policy.</summary>
			public string ChangeId { get; }

			/// <summary>The description of the central access policy.</summary>
			/// <summary>Pointer to a buffer of CENTRAL_ACCESS_POLICY_ENTRY pointers.</summary>
			public CentralAccessPolicyEntry[] Entries { get; }

			/// <summary>The identifier of the central access policy.</summary>
			public SecurityIdentifier Id { get; }

			/// <summary>The name of the central access policy.</summary>
			public string Name { get; }

			/// <summary>
			/// Returns a seqence of central access policies (CAPs) identifiers (CAPIDs) of all the CAPs applied on a specific computer.
			/// </summary>
			/// <param name="systemName">
			/// The name of the specific computer. The name can have the form of "ComputerName" or "\ComputerName". If this parameter is
			/// <see langword="null"/>, then the function returns the CAPIDs of the local computer.
			/// </param>
			/// <returns>
			/// A sequence of <see cref="CentralAccessPolicy"/> instances that identify the CAPs available on the specified computer.
			/// </returns>
			/// <remarks>
			/// For specific details about the central access policies, you can query the attributes of the central access policy object in
			/// the Active Directory on the specified computer's domain controller. Look for the object whose
			/// <c>msAuthz-CentralAccessPolicyID</c> attribute matches one of the returned CAPIDs.
			/// </remarks>
			public static IEnumerable<CentralAccessPolicy> GetAppliedPolicies(string systemName = null)
			{
				LsaGetAppliedCAPIDs(systemName, out var h, out var c).ThrowIfFailed();
				using (h)
				{
					LsaQueryCAPs(h.DangerousGetHandle(), c, out var ch, out var cc).ThrowIfFailed();
					using (ch)
					{
						return Array.ConvertAll(ch.ToArray<CENTRAL_ACCESS_POLICY>((int)cc), e => new CentralAccessPolicy(e));
					}
				}
			}

			/// <summary>Returns the Central Access Policies (CAPs) for the specified IDs.</summary>
			/// <param name="capids">An array of pointers to CAPIDs that identify the CAPs being queried.</param>
			/// <returns>
			/// A sequence of <see cref="CentralAccessPolicy"/> instances that identify the CAPs available on the specified computer.
			/// </returns>
			public static IEnumerable<CentralAccessPolicy> GetPoliciesForIds(params PSID[] capids)
			{
				LsaQueryCAPs(capids, (uint)capids.Length, out var ch, out var cc).ThrowIfFailed();
				using (ch)
				{
					return Array.ConvertAll(ch.ToArray<CENTRAL_ACCESS_POLICY>((int)cc), e => new CentralAccessPolicy(e));
				}
			}
		}

		/// <summary>Represents a central access policy entry containing a list of security descriptors and staged security descriptors.</summary>
		public class CentralAccessPolicyEntry
		{
			internal CentralAccessPolicyEntry(in CENTRAL_ACCESS_POLICY_ENTRY cape)
			{
				Name = cape.Name;
				Description = cape.Description;
				ChangeId = cape.ChangeId;
				AppliesTo = cape.AppliesTo.ToByteArray((int)cape.LengthAppliesTo);
				SecurityDescriptor = cape.SD.ToManaged();
				StagedSecurityDescriptor = cape.StagedSD.ToManaged();
			}

			/// <summary>A resource condition in binary form.</summary>
			public byte[] AppliesTo { get; }

			/// <summary>An identifier that can be used to version the central access policy entry.</summary>
			public string ChangeId { get; }

			/// <summary>The description of the central access policy entry.</summary>
			public string Description { get; }

			/// <summary>The name of the central access policy entry.</summary>
			public string Name { get; }

			/// <summary>A buffer of security descriptors associated with the entry.</summary>
			public RawSecurityDescriptor SecurityDescriptor { get; }

			/// <summary>A buffer of staged security descriptors associated with the entry.</summary>
			public RawSecurityDescriptor StagedSecurityDescriptor { get; }
		}
	}
}