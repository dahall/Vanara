using System;
using Vanara.Windows.Shell;
using static Vanara.PInvoke.Shell32;

namespace CoreConsoleApp
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			using var computer = new ShellFolder(KNOWNFOLDERID.FOLDERID_ComputerFolder);
			foreach (var si in computer)
			{
				Console.WriteLine(si.ParsingName);
				si.Dispose();
			}

			foreach (var si in computer.EnumerateChildren(FolderItemFilter.Folders | FolderItemFilter.IncludeHidden | FolderItemFilter.IncludeSuperHidden | FolderItemFilter.NonFolders | FolderItemFilter.Printers | FolderItemFilter.FlatList))
			{
				Console.WriteLine(si.ParsingName);
				si.Dispose();
			}
		}
	}
}
