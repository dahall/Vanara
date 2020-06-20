using System;
using System.IO;
using System.Threading;
using Vanara.Windows.Shell;
using static Vanara.PInvoke.Shell32;

namespace CoreConsoleApp
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			const string bitBucket = @"C:\$Recycle.Bin";
			const string dir = @"C:\Users\dahal\Downloads";
			const string fn = "Clash.for.Windows.Setup.0.10.1.exe";
			Move(Path.Combine(dir, fn), bitBucket);
			Thread.Sleep(500);
			Move(Path.Combine(bitBucket, fn), dir);
		}

		public static bool Move(string SourcePath, string DestinationPath, string NewName = null)
		{
			try
			{
				using (ShellItem SourceItem = new ShellItem(SourcePath))
				using (ShellFolder DestItem = new ShellFolder(DestinationPath))
				{
					ShellFileOperations.Move(SourceItem, DestItem, NewName, ShellFileOperations.OperationFlags.AllowUndo | ShellFileOperations.OperationFlags.NoConfirmMkDir | ShellFileOperations.OperationFlags.Silent);
				}

				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
