/*  Copyright (C) 2008-2018 Peter Palotas, Jeffrey Jangli, Alexandr Normuradov
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy 
 *  of this software and associated documentation files (the "Software"), to deal 
 *  in the Software without restriction, including without limitation the rights 
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
 *  copies of the Software, and to permit persons to whom the Software is 
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in 
 *  all copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
 *  THE SOFTWARE. 
 */

using NUnit.Framework;
using System;
using System.Globalization;
using System.Security.AccessControl;

namespace Vanara.IO.Tests
{
   /// <summary>Used to create a temporary directory that will be deleted once this instance is disposed.</summary>
   public sealed class TemporaryDirectory : IDisposable
   {
      #region Fields

      public const int OneMebibyte = 1048576;

      #endregion //Fields


      #region Constructors

      public TemporaryDirectory() : this(false) { }
      

      public TemporaryDirectory(bool isNetwork, string folderPrefix = null, string root = null)
      {
         if (string.IsNullOrWhiteSpace(folderPrefix))
            folderPrefix = "Vanara.TempRoot";

         if (string.IsNullOrWhiteSpace(root))
            root = TempPath;

         //if (isNetwork)
         //   root = Alphaleonis.Win32.Filesystem.Path.LocalToUnc(root);


         //UnitTestConstants.PrintUnitTestHeader(isNetwork);


         do
         {
            Directory = new System.IO.DirectoryInfo(System.IO.Path.Combine(root, folderPrefix + "." + RandomString));

         } while (Directory.Exists);

         Directory.Create();
      }

      #endregion // Constructors


      #region Properties

      public System.IO.DirectoryInfo Directory { get; private set; }


      /// <summary>Returns a random directory name, such as: "Directory_wqáánmvh".</summary>
      public string RandomDirectoryName
      {
         get { return string.Format(CultureInfo.InvariantCulture, "Directory.{0}", RandomString); }
      }


      /// <summary>Returns the full path to a non-existing file with a random name, such as: "File_wqáánmvh.txt".</summary>
      public string RandomTxtFileName
      {
         get { return string.Format(CultureInfo.InvariantCulture, "File_{0}.txt", RandomString); }
      }


      /// <summary>Returns the full path to a non-existing directory with a random name, such as: "C:\Users\UserName\AppData\Local\Temp\AlphaFS.TempRoot.lpqdzf\Directory_wqáánmvh.z03".</summary>
      public string RandomDirectoryFullPath
      {
         get { return System.IO.Path.Combine(Directory.FullName, RandomDirectoryName); }
      }


      /// <summary>Returns the full path to a non-existing file with a random name, such as: "C:\Users\UserName\AppData\Local\Temp\AlphaFS.TempRoot.lpqdzf\File_wqáánmvh.txt".</summary>
      public string RandomTxtFileFullPath
      {
         get { return System.IO.Path.Combine(Directory.FullName, RandomTxtFileName); }
      }


      /// <summary>Returns the full path to a non-existing file with a random name and without an extension, such as: "C:\Users\UserName\AppData\Local\Temp\AlphaFS.TempRoot.lpqdzf\File_wqáánmvh".</summary>
      public string RandomFileNoExtensionFullPath
      {
         get { return System.IO.Path.Combine(Directory.FullName, System.IO.Path.GetFileNameWithoutExtension(RandomTxtFileName)); }
      }
      
      
      /// <summary>Returns a random string of 8 characters in length, possibly with diacritic characters.</summary>
      public string RandomString
      {
         get
         {
            var randomFileName = System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetRandomFileName());
            return randomFileName;

            //switch (new Random(DateTime.UtcNow.Millisecond).Next(1, 3))
            //{
            //   case 1:
            //      return randomFileName.Replace("a", "ä").Replace("e", "ë").Replace("i", "ï").Replace("o", "ö").Replace("u", "ü");

            //   case 2:
            //      return randomFileName.Replace("a", "á").Replace("e", "é").Replace("i", "í").Replace("o", "ó").Replace("u", "ú");

            //   case 3:
            //      return randomFileName.Replace("a", "â").Replace("e", "ê").Replace("i", "î").Replace("o", "ô").Replace("u", "û");

            //   default:
            //      return randomFileName;
            //}
         }
      }

      #endregion // Properties


      #region Methods

      /// <summary>Returns a <see cref="System.IO.DirectoryInfo"/> instance to an existing directory.</summary>
      public System.IO.DirectoryInfo CreateDirectory()
      {
         return CreateDirectoryCore(null);
      }


      /// <summary>Returns a <see cref="System.IO.DirectoryInfo"/> instance to an existing directory.</summary>
      public System.IO.DirectoryInfo CreateDirectory(string directoryNameSuffix)
      {
         return CreateDirectoryCore(Directory.FullName + directoryNameSuffix);
      }


      /// <summary>Returns a <see cref="System.IO.DirectoryInfo"/> instance to an existing directory.</summary>
      public System.IO.DirectoryInfo CreateSubDirectory(string directoryName)
      {
         return CreateDirectoryCore(System.IO.Path.Combine(Directory.FullName, directoryName));
      }


      /// <summary>Returns a <see cref="System.IO.DirectoryInfo"/> instance to an existing directory, possibly with read-only and/or hidden attributes set.</summary>
      public System.IO.DirectoryInfo CreateDirectoryRandomizedAttributes()
      {
         return CreateDirectoryCore(null, false, true, true);
      }


      /// <summary>Returns a <see cref="System.IO.DirectoryInfo"/> instance to an existing directory, possibly with read-only and/or hidden attributes set.</summary>
      public System.IO.DirectoryInfo CreateDirectoryRandomizedAttributes(string directoryNameSuffix)
      {
         return CreateDirectoryCore(Directory.FullName + directoryNameSuffix, false, true, true);
      }
      

      /// <summary>Returns a <see cref="System.IO.FileInfo"/> instance to an existing file.</summary>
      public System.IO.FileInfo CreateFile()
      {
         return CreateFileCore(null);
      }


      /// <summary>Returns a <see cref="System.IO.FileInfo"/> instance to an existing file.</summary>
      public System.IO.FileInfo CreateSubDirectoryFile(System.IO.DirectoryInfo directoryInfo, string fileName = null, int fileSize = OneMebibyte)
      {
         return CreateFileCore(System.IO.Path.Combine(directoryInfo.FullName, fileName ?? RandomTxtFileName), fileSize: fileSize);
      }


      /// <summary>Returns a <see cref="System.IO.FileInfo"/> instance to an existing file of <paramref name="fileSize"/> bytes.</summary>
      public System.IO.FileInfo CreateFile(int fileSize)
      {
         return CreateFileCore(null, fileSize: fileSize);
      }


      /// <summary>Returns a <see cref="System.IO.FileInfo"/> instance to an existing file, possibly with read-only and/or hidden attributes set.</summary>
      public System.IO.FileInfo CreateFileRandomizedAttributes()
      {
         return CreateFileCore(null, false, true, true);
      }
      

      /// <summary>Creates a directory structure populated with subdirectories and files of random size.</summary>
      public System.IO.DirectoryInfo CreateTree(int level = 1)
      {
         return CreateTreeCore(null, level);
      }


      /// <summary>Creates a recursive directory structure populated with subdirectories and files of random size.</summary>      
      public System.IO.DirectoryInfo CreateRecursiveTree(int level = 1)
      {
         return CreateTreeCore(null, level, true);
      }


      /// <summary>Creates a recursive directory structure populated with subdirectories and files of random size.</summary>
      public System.IO.DirectoryInfo CreateRecursiveTree(int level, string rootFullPath)
      {
         return CreateTreeCore(rootFullPath, level, true);
      }


      /// <summary>Creates a directory structure populated with subdirectories and files of random size and possibly with read-only and/or hidden attributes set.</summary>
      public System.IO.DirectoryInfo CreateRandomizedAttributesTree(int level = 1)
      {
         return CreateTreeCore(null, level, false, false, true, true);
      }


      /// <summary>Creates a recursive directory structure populated with subdirectories and files of random size and possibly with read-only and/or hidden attributes set.</summary>
      public System.IO.DirectoryInfo CreateRecursiveRandomizedAttributesTree(int level = 1)
      {
         return CreateTreeCore(null, level, true, false, true, true);
      }


      /// <summary>Creates a recursive directory structure populated with subdirectories and files, possibly with randomized CreationTime, LastAccessTime and/or LastWriteTime.</summary>
      public System.IO.DirectoryInfo CreateRecursiveRandomizedDatesTree(int level = 1)
      {
         return CreateTreeCore(null, level, true, true);
      }

      /// <summary>Creates a recursive directory structure populated with subdirectories and files, possibly with randomized CreationTime, LastAccessTime and/or LastWriteTime.
      /// The file size, read-only and/or hidden attributes might also be randomized.
      /// </summary>
      public System.IO.DirectoryInfo CreateRecursiveRandomizedDatesAndAttributesTree(int level = 1)
      {
         return CreateTreeCore(null, level, true, true, true, true);
      }
      

      public DateTime GetRandomFileDate()
      {
         var rnd = new Random(DateTime.Now.Millisecond);
         return new DateTime(rnd.Next(1971, DateTime.Now.Year), rnd.Next(1, 12), rnd.Next(1, 28), rnd.Next(0, 23), rnd.Next(0, 59), rnd.Next(0, 59));
      }


      /// <summary>Enables or disables deny access for the current User.</summary>
      public void SetDirectoryDenyPermission(bool enable, string folderFullPath)
      {
         // ╔═════════════╦═════════════╦═══════════════════════════════╦════════════════════════╦══════════════════╦═══════════════════════╦═════════════╦═════════════╗
         // ║             ║ folder only ║ folder, sub-folders and files ║ folder and sub-folders ║ folder and files ║ sub-folders and files ║ sub-folders ║    files    ║
         // ╠═════════════╬═════════════╬═══════════════════════════════╬════════════════════════╬══════════════════╬═══════════════════════╬═════════════╬═════════════╣
         // ║ Propagation ║ none        ║ none                          ║ none                   ║ none             ║ InheritOnly           ║ InheritOnly ║ InheritOnly ║
         // ║ Inheritance ║ none        ║ Container|Object              ║ Container              ║ Object           ║ Container|Object      ║ Container   ║ Object      ║
         // ╚═════════════╩═════════════╩═══════════════════════════════╩════════════════════════╩══════════════════╩═══════════════════════╩═════════════╩═════════════╝

         var user = (Environment.UserDomainName + @"\" + Environment.UserName).TrimStart('\\');

         var rule = new FileSystemAccessRule(user, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny);

         DirectorySecurity dirSecurity;

         var dirInfo = CreateDirectoryCore(folderFullPath);


         // Set DENY for current User.
         if (enable)
         {
            dirSecurity = dirInfo.GetAccessControl();
            dirSecurity.AddAccessRule(rule);
            dirInfo.SetAccessControl(dirSecurity);
         }

         // Remove DENY for current User.
         else
         {
            dirSecurity = dirInfo.GetAccessControl();
            dirSecurity.RemoveAccessRule(rule);
            dirInfo.SetAccessControl(dirSecurity);
         }
      }


      public override string ToString()
      {
         return Directory.FullName;
      }

      #endregion // Methods


      #region Private Members

      /// <summary>The path to the temporary folder, ending with a backslash.</summary>
      private static readonly string TempPath = System.IO.Path.GetTempPath();


      /// <summary>Returns a <see cref="System.IO.DirectoryInfo"/> instance to an existing directory, possibly with read-only and/or hidden attributes set.</summary>
      private System.IO.DirectoryInfo CreateDirectoryCore(string folderFullPath, bool randomizedDates = false, bool readOnly = false, bool hidden = false)
      {
         var dirInfo = System.IO.Directory.CreateDirectory(!string.IsNullOrWhiteSpace(folderFullPath) ? folderFullPath : RandomDirectoryFullPath);

         SetRandomizedDates(dirInfo, randomizedDates);

         SetReadOnlyAndOrHiddenAttributes(dirInfo, readOnly, hidden);

         return dirInfo;
      }


      /// <summary>Returns a <see cref="System.IO.FileInfo"/> instance to an existing file, possibly with read-only and/or hidden attributes set.</summary>
      private System.IO.FileInfo CreateFileCore(string fileFullPath, bool randomizedDates = false, bool readOnly = false, bool hidden = false, int fileSize = 0)
      {
         var fileInfo = new System.IO.FileInfo(!string.IsNullOrWhiteSpace(fileFullPath) ? fileFullPath : RandomTxtFileFullPath);

         using (var fs = fileInfo.Create())
         {
            if (fileSize > OneMebibyte)
               fs.SetLength(fileSize);
            else
               fs.SetLength(new Random(DateTime.UtcNow.Millisecond).Next(0, OneMebibyte));
         }

         SetRandomizedDates(fileInfo, randomizedDates);

         SetReadOnlyAndOrHiddenAttributes(fileInfo, readOnly, hidden);
         
         return fileInfo;
      }


      /// <summary>Creates an, optional recursive, directory structure of <param name="level"/> levels deep, populated with subdirectories and files of random size and possibly with read-only and/or hidden attributes set.</summary>
      private System.IO.DirectoryInfo CreateTreeCore(string rootFullPath, int level = 1, bool recurse = false, bool randomizedDates = false, bool readOnly = false, bool hidden = false)
      {
         var dirInfo = CreateDirectoryCore(rootFullPath, randomizedDates, readOnly, hidden);

         var folderCount = 0;


         for (var fsoCount = 0; fsoCount < level; fsoCount++)
         {
            folderCount++;

            var fsoName = RandomString + "-" + fsoCount;

            // Always create folder.
            var di = CreateDirectoryCore(System.IO.Path.Combine(dirInfo.FullName, $"Directory_{fsoName}_directory"), randomizedDates, readOnly, hidden);

            // Create file, every other iteration.
            CreateFileCore(System.IO.Path.Combine(fsoCount % 2 == 0 ? di.FullName : dirInfo.FullName, $"File_{fsoName}_file.txt"), randomizedDates, readOnly, hidden);
         }


         if (recurse)
         {
            foreach (var folder in System.IO.Directory.EnumerateDirectories(dirInfo.FullName))
               CreateTreeCore(folder, level, false, randomizedDates, readOnly, hidden);
         }


         Assert.AreEqual(level, folderCount, "The number of folders does not equal level argument, but is expected to.");

         return dirInfo;
      }


      private void SetRandomizedDates(System.IO.FileSystemInfo fsi, bool randomizedDates = false)
      {
         if (randomizedDates && new Random(DateTime.UtcNow.Millisecond).Next(0, 1000) % 2 == 0)
         {
            fsi.CreationTime = GetRandomFileDate();
            fsi.LastAccessTime = GetRandomFileDate();
            fsi.LastWriteTime = GetRandomFileDate();
         }
      }


      private static void SetReadOnlyAndOrHiddenAttributes(System.IO.FileSystemInfo fsi, bool readOnly = false, bool hidden = false)
      {
         if (readOnly && new Random(DateTime.UtcNow.Millisecond).Next(0, 1000) % 2 == 0)
            fsi.Attributes |= System.IO.FileAttributes.ReadOnly;

         if (hidden && new Random(DateTime.UtcNow.Millisecond).Next(0, 1000) % 2 == 0)
            fsi.Attributes |= System.IO.FileAttributes.Hidden;
      }
      
      #endregion Private Members


      #region Disposable Members

      ~TemporaryDirectory()
      {
         Dispose(false);
      }


      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }


      private void Dispose(bool isDisposing)
      {
         try
         {
            if (isDisposing)
               System.IO.Directory.Delete(Directory.FullName, true);
         }
         catch (Exception ex)
         {
            Console.WriteLine($"{nameof(TemporaryDirectory)} delete failure. Error: {ex.Message.Replace(Environment.NewLine, string.Empty)}");
         }
      }

      #endregion // Disposable Members
   }
}
