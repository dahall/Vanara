#if (NET20 || NET35 || NET40 || NET45)
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Extensions
{
	/// <summary>Extension methods for <see cref="ServiceController"/>.</summary>
	public static partial class ServiceControllerExtension
	{
		public static void SetStartType(this ServiceController svc, ServiceStartMode mode)
		{
			using (var serviceHandle = svc.ServiceHandle)
			{
				if (!ChangeServiceConfig(serviceHandle.DangerousGetHandle(), ServiceTypes.SERVICE_NO_CHANGE, (ServiceStartType)mode, ServiceErrorControlType.SERVICE_NO_CHANGE))
					throw new ExternalException("Could not change service start type.", new Win32Exception());
			}
		}
	}
}
#endif