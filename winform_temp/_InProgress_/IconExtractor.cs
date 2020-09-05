/*
 *  IconExtractor/IconUtil for .NET
 *  Copyright (C) 2014 Tsuda Kageyu. All rights reserved.
 *  
 *  Major modifications and extraction of native methods by David Hall
 *
 *  Redistribution and use in source and binary forms, with or without
 *  modification, are permitted provided that the following conditions
 *  are met:
 *
 *   1. Redistributions of source code must retain the above copyright
 *      notice, this list of conditions and the following disclaimer.
 *   2. Redistributions in binary form must reproduce the above copyright
 *      notice, this list of conditions and the following disclaimer in the
 *      documentation and/or other materials provided with the distribution.
 *
 *  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 *  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
 *  TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 *  PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER
 *  OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
 *  EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
 *  PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
 *  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
 *  LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 *  NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 *  SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Windows;

namespace Vanara.Helpers
{
	public class IconExtractor
	{
		private readonly IList<string> resInfo;
		private readonly SafeLibraryHandle hModule;
		private readonly Icon[] iconCache;

		/// <summary>
		/// Load the specified executable file or DLL, and get ready to extract the icons.
		/// </summary>
		/// <param name="filename">The name of a file from which icons will be extracted.</param>
		public IconExtractor(string filename)
		{
			if (filename == null)
				throw new ArgumentNullException(nameof(filename));

			using (var hm = new SafeLibraryHandle(filename))
				FileName = GetModuleFileName(hm);
			hModule = new SafeLibraryHandle(filename,
				LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE | LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE);
			resInfo = EnumResourceNames(hModule, ResourceTypes.GroupIcon);
			iconCache = new Icon[IconCount];
		}

		/// <summary>Gets the name of the file.</summary>
		/// <value>The name of the file.</value>
		public string FileName { get; }

		/// <summary>Gets the icon count.</summary>
		/// <value>The icon count.</value>
		public int IconCount => resInfo.Count;

		/// <summary>
		/// Extract an icon from the loaded executable file or DLL. 
		/// </summary>
		/// <param name="iconIndex">The zero-based index of the icon to be extracted.</param>
		/// <returns>A <see cref="Icon"/> object which may consists of multiple icons.</returns>
		/// <remarks>Always returns new copy of the <see cref="Icon"/>. It should be disposed by the user.</remarks>
		public Icon this[int iconIndex]
		{
			get
			{
				if (iconIndex < 0 || IconCount <= iconIndex)
					throw new ArgumentOutOfRangeException(nameof(iconIndex), $"Value should be between 0 and {IconCount - 1}.");

				if (iconCache[iconIndex] == null)
					iconCache[iconIndex] = CreateIcon(iconIndex);

				return (Icon)iconCache[iconIndex].Clone();
			}
		}

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString()
		{
			var text = $"IconExtractor (Filename: '{FileName}', IconCount: {IconCount})";
			return text;
		}

		private static byte[] GetResourceData(SafeLibraryHandle hMod, string lpName, string lpType)
		{
			// Get binary image of the specified resource.

			var hResInfo = FindResource(hMod, lpName, lpType);
			if (hResInfo == IntPtr.Zero)
				throw new Win32Exception();

			var hResData = LoadResource(hMod, hResInfo);
			if (hResData == IntPtr.Zero)
				throw new Win32Exception();

			var hGlobal = LockResource(hResData);
			if (hGlobal == IntPtr.Zero)
				throw new Win32Exception();

			var resSize = SizeofResource(hMod, hResInfo);
			if (resSize == 0)
				throw new Win32Exception();

			var buf = new byte[resSize];
			Marshal.Copy(hGlobal, buf, 0, buf.Length);
			return buf;
		}

		private Icon CreateIcon(int iconIndex)
		{
			const int szGrpIconDirEntry = 14; // sizeof(GRPICONDIRENTRY)
			const int sIconDir = 6; // sizeof(ICONDIR) 
			const int sIconDirEntry = 16; // sizeof(ICONDIRENTRY)

			// Get group icon resource.
			var srcBuf = GetResourceData(hModule, resInfo[iconIndex], ResourceTypes.GroupIcon);

			// Convert the resource into an .ico file image.
			using (var destStream = new MemoryStream())
			using (var writer = new BinaryWriter(destStream))
			{
				int count = BitConverter.ToUInt16(srcBuf, 4); // ICONDIR.idCount
				var imgOffset = sIconDir + sIconDirEntry*count;

				// Copy ICONDIR.
				writer.Write(srcBuf, 0, sIconDir);

				for (var i = 0; i < count; i++)
				{
					// Copy GRPICONDIRENTRY converting into ICONDIRENTRY.
					writer.BaseStream.Seek(sIconDir + sIconDirEntry*i, SeekOrigin.Begin);
					writer.Write(srcBuf, sIconDir + szGrpIconDirEntry*i, sIconDirEntry - 4); // Common fields of structures
					writer.Write(imgOffset); // ICONDIRENTRY.dwImageOffset

					// Get picture and mask data, then copy them.
					var nId = BitConverter.ToUInt16(srcBuf, sIconDir + szGrpIconDirEntry*i + 12); // GRPICONDIRENTRY.nID
					var imgBuf = GetResourceData(hModule, MAKEINTRESOURCE(nId), ResourceTypes.Icon);

					writer.BaseStream.Seek(imgOffset, SeekOrigin.Begin);
					writer.Write(imgBuf, 0, imgBuf.Length);

					imgOffset += imgBuf.Length;
				}

				destStream.Seek(0, SeekOrigin.Begin);
				return new Icon(destStream);
			}
		}
	}
}