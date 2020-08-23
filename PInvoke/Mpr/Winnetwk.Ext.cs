using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from the mpr.dll</summary>
	public static partial class Mpr
	{
		/// <summary>The <c>WNetEnumResources</c> function enumerates network resources.</summary>
		/// <param name="root">
		/// <para>
		/// Pointer to a <c>NETRESOURCE</c> structure that specifies the container to enumerate. If the dwScope parameter is not
		/// RESOURCE_GLOBALNET, this parameter must be <c>NULL</c>.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the root of the network is assumed. (The system organizes a network as a hierarchy; the root is
		/// the topmost container in the network.)
		/// </para>
		/// <para>
		/// If this parameter is not <c>NULL</c>, it must point to a <c>NETRESOURCE</c> structure. This structure can be filled in by the
		/// application or it can be returned by a call to the <c>WNetEnumResource</c> function. The <c>NETRESOURCE</c> structure must
		/// specify a container resource; that is, the RESOURCEUSAGE_CONTAINER value must be specified in the dwUsage parameter.
		/// </para>
		/// <para>
		/// To enumerate all network resources, an application can begin the enumeration by calling <c>WNetOpenEnum</c> with the
		/// lpNetResource parameter set to <c>NULL</c>, and then use the returned handle to call <c>WNetEnumResource</c> to enumerate
		/// resources. If one of the resources in the <c>NETRESOURCE</c> array returned by the <c>WNetEnumResource</c> function is a
		/// container resource, you can call <c>WNetOpenEnum</c> to open the resource for further enumeration.
		/// </para>
		/// </param>
		/// <param name="dwScope">
		/// <para>Scope of the enumeration. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RESOURCE_CONNECTED</term>
		/// <term>
		/// Enumerate all currently connected resources. The function ignores the dwUsage parameter. For more information, see the following
		/// Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RESOURCE_CONTEXT</term>
		/// <term>
		/// Enumerate only resources in the network context of the caller. Specify this value for a Network Neighborhood view. The function
		/// ignores the dwUsage parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RESOURCE_GLOBALNET</term>
		/// <term>Enumerate all resources on the network.</term>
		/// </item>
		/// <item>
		/// <term>RESOURCE_REMEMBERED</term>
		/// <term>Enumerate all remembered (persistent) connections. The function ignores the dwUsage parameter.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="dwType">
		/// <para>Resource types to be enumerated. This parameter can be a combination of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RESOURCETYPE_ANY</term>
		/// <term>All resources. This value cannot be combined with RESOURCETYPE_DISK or RESOURCETYPE_PRINT.</term>
		/// </item>
		/// <item>
		/// <term>RESOURCETYPE_DISK</term>
		/// <term>All disk resources.</term>
		/// </item>
		/// <item>
		/// <term>RESOURCETYPE_PRINT</term>
		/// <term>All print resources.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>If a network provider cannot distinguish between print and disk resources, it can enumerate all resources.</para>
		/// </param>
		/// <param name="dwUsage">
		/// <para>Resource usage type to be enumerated. This parameter can be a combination of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>All resources.</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEUSAGE_CONNECTABLE</term>
		/// <term>All connectable resources.</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEUSAGE_CONTAINER</term>
		/// <term>All container resources.</term>
		/// </item>
		/// <item>
		/// <term>RESOURCEUSAGE_ATTACHED</term>
		/// <term>
		/// Setting this value forces WNetOpenEnum to fail if the user is not authenticated. The function fails even if the network allows
		/// enumeration without authentication.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RESOURCEUSAGE_ALL</term>
		/// <term>Setting this value is equivalent to setting RESOURCEUSAGE_CONNECTABLE, RESOURCEUSAGE_CONTAINER, and RESOURCEUSAGE_ATTACHED.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// This parameter is ignored unless the dwScope parameter is equal to RESOURCE_GLOBALNET. For more information, see the following
		/// Remarks section.
		/// </para>
		/// </param>
		/// <param name="recurseContainers">if set to <see langword="true"/> [recurse containers].</param>
		/// <returns>The enumeration results. The results are returned as a list of <c>NETRESOURCE</c> structures.</returns>
		public static IEnumerable<NETRESOURCE> WNetEnumResources([Optional] NETRESOURCE root, NETRESOURCEScope dwScope = NETRESOURCEScope.RESOURCE_GLOBALNET, NETRESOURCEType dwType = NETRESOURCEType.RESOURCETYPE_ANY, NETRESOURCEUsage dwUsage = 0, bool recurseContainers = false)
		{
			var err = WNetOpenEnum(dwScope, dwType, dwUsage, root, out var h);
			if (err == Win32Error.ERROR_NOT_CONTAINER || err == Win32Error.ERROR_NO_NETWORK)
				yield break;
			else
				err.WNetThrowIfFailed();

			using (h)
			{
				var count = -1;
				var sz = 4096U;
				using var mem = new SafeHGlobalHandle((int)sz);
				do
				{
					mem.Zero();
					sz = mem.Size;
					err = WNetEnumResource(h, ref count, mem, ref sz);
					if (err.Succeeded)
					{
						foreach (var e in mem.ToEnumerable<NETRESOURCE>(count))
						{
							yield return e;
							if (recurseContainers && e.dwUsage.IsFlagSet(NETRESOURCEUsage.RESOURCEUSAGE_CONTAINER))
								foreach (var ce in WNetEnumResources(e, dwScope, dwType, dwUsage, recurseContainers))
									yield return ce;
						}
					}
					else if (err != Win32Error.ERROR_NO_MORE_ITEMS)
						err.WNetThrowIfFailed("Last resource = " + (root is null ? "" : $"Type:{root.dwDisplayType}=Prov:{root.lpProvider}; Rem:{root.lpRemoteName}"));
				}
				while (err != Win32Error.ERROR_NO_MORE_ITEMS);
			}
		}
	}
}