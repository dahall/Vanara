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
		public static IEnumerable<NETRESOURCE> WNetEnumResources([Optional] NETRESOURCE root, NETRESOURCEScope dwScope = NETRESOURCEScope.RESOURCE_GLOBALNET, NETRESOURCEType dwType = NETRESOURCEType.RESOURCETYPE_ANY, NETRESOURCEUsage dwUsage = 0, bool recurseContainers = false)
		{
			var err = WNetOpenEnum(dwScope, dwType, dwUsage, root, out var h);
			if (err == Win32Error.ERROR_NOT_CONTAINER || err == Win32Error.ERROR_NO_NETWORK)
				yield break;
			else if (err.Failed)
				throw err.GetException();

			using (h)
			{
				var count = -1;
				var sz = 16 * 1024U;
				using (var mem = new SafeHGlobalHandle((int)sz))
				{
					do
					{
						err = WNetEnumResource(h, ref count, (IntPtr)mem, ref sz);
						if (err == Win32Error.ERROR_SUCCESS)
						{
							foreach (var e in mem.ToEnumerable<NETRESOURCE>((int)count))
							{
								yield return e;
								if (recurseContainers && e.dwUsage.IsFlagSet(NETRESOURCEUsage.RESOURCEUSAGE_CONTAINER))
									foreach (var ce in WNetEnumResources(e, dwScope, dwType, dwUsage, recurseContainers))
										yield return ce;
							}
						}
						else if (err == Win32Error.ERROR_NO_MORE_ITEMS)
							break;
						else
							throw err.GetException();
						mem.Zero();
					}
					while (true);
				}
			}
		}
	}
}