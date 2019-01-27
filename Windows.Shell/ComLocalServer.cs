using System;

namespace Vanara.Windows.Shell
{
	/// <summary>Implements a COM Local Server. Use similarly to Application with Windows.Forms in the Main method of your executable.</summary>
	public static partial class ComLocalServer
	{
		/// <summary>Runs the specified COM Local Server object.</summary>
		/// <param name="punk">The COM object to run as a local server.</param>
		public static void Run(ComObject punk)
		{
			using (var cf = new ComClassFactory(punk ?? throw new ArgumentNullException(nameof(punk))))
			{
				punk.RunMessageLoop();
			}
		}
	}
}