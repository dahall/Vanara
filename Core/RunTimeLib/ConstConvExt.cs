using System.IO;

namespace Vanara.RunTimeLib
{
	/// <summary>Extension methods for CRT enumerations to convert to .NET enumerations.</summary>
	public static class ConstantConversionExtensions
	{
		/// <summary>Converts a <see cref="FileAttributeConstant"/> value to <see cref="FileAccess"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result.</returns>
		public static FileAccess ToFileAccess(this FileAttributeConstant value)
		{
			// Note: This is not done in a switch because the order of tests matters.
			if ((FileAttributeConstant._A_RDONLY | FileAttributeConstant._A_NORMAL) == (value & (FileAttributeConstant._A_RDONLY | FileAttributeConstant._A_NORMAL)))
				return FileAccess.ReadWrite;
			else if (0 != (value & FileAttributeConstant._A_RDONLY))
				return FileAccess.Read;
			else if (0 != (value & FileAttributeConstant._A_NORMAL))
				return FileAccess.Write;
			else
				return FileAccess.Read;
		}

		/// <summary>Converts a <see cref="FilePermissionConstant"/> value to <see cref="FileAccess"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result.</returns>
		public static FileAccess ToFileAccess(this FilePermissionConstant value)
		{
			// Note: This is not done in a switch because the order of tests matters.
			if ((value & (FilePermissionConstant._S_IWRITE | FilePermissionConstant._S_IREAD)) != 0)
				return FileAccess.ReadWrite;
			else if ((value & FilePermissionConstant._S_IWRITE) != 0)
				return FileAccess.Write;
			else
				return FileAccess.Read;
		}

		/// <summary>Converts a <see cref="FileAttributeConstant"/> value to <see cref="FileAttributes"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result.</returns>
		public static FileAttributes ToFileAttributes(this FileAttributeConstant value)
		{
			FileAttributes ret = 0;
			if ((value & FileAttributeConstant._A_SUBDIR) != 0)
				ret |= FileAttributes.Directory;
			if ((value & FileAttributeConstant._A_RDONLY) != 0)
				ret |= FileAttributes.ReadOnly;
			if ((value & FileAttributeConstant._A_HIDDEN) != 0)
				ret |= FileAttributes.Hidden;
			if ((value & FileAttributeConstant._A_SYSTEM) != 0)
				ret |= FileAttributes.System;
			if ((value & FileAttributeConstant._A_ARCH) != 0)
				ret |= FileAttributes.Archive;
			return ret;
		}

		/// <summary>Converts a <see cref="FileOpConstant"/> value to <see cref="FileMode"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result.</returns>
		public static FileMode ToFileMode(this FileOpConstant value)
		{
			// Note: This is not done in a switch because the order of tests matters.
			if ((FileOpConstant._O_CREAT | FileOpConstant._O_EXCL) == (value & (FileOpConstant._O_CREAT | FileOpConstant._O_EXCL)))
				return FileMode.CreateNew;
			else if ((FileOpConstant._O_CREAT | FileOpConstant._O_TRUNC) == (value & (FileOpConstant._O_CREAT | FileOpConstant._O_TRUNC)))
				return FileMode.OpenOrCreate;
			else if (0 != (value & FileOpConstant._O_APPEND))
				return FileMode.Append;
			else if (0 != (value & FileOpConstant._O_CREAT))
				return FileMode.Create;
			else if (0 != (value & FileOpConstant._O_RDWR))
				return FileMode.Open;
			else if (0 != (value & FileOpConstant._O_TRUNC))
				return FileMode.Truncate;
			else
				return FileMode.OpenOrCreate; // This seemed the safest way to handled unrecognized types
		}

		/// <summary>Converts a <see cref="FileOpConstant"/> value to <see cref="FileOptions"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result.</returns>
		public static FileOptions ToFileOptions(this FileOpConstant value)
		{
			FileOptions ret = 0;
			if ((value & FileOpConstant._O_RANDOM) != 0)
				ret |= FileOptions.RandomAccess;
			if ((value & FileOpConstant._O_TEMPORARY) != 0)
				ret |= FileOptions.DeleteOnClose;
			if ((value & FileOpConstant._O_SEQUENTIAL) != 0)
				ret |= FileOptions.SequentialScan;
			return ret;
		}

		/// <summary>Converts a <see cref="FileAttributeConstant"/> value to <see cref="FileShare"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result.</returns>
		public static FileShare ToFileShare(this FileAttributeConstant value)
		{
			// Note: This is not done in a switch because the order of tests matters.
			if ((FileAttributeConstant._A_RDONLY | FileAttributeConstant._A_NORMAL) == (value & (FileAttributeConstant._A_RDONLY | FileAttributeConstant._A_NORMAL)))
				return FileShare.ReadWrite;
			else if (0 != (value & FileAttributeConstant._A_RDONLY))
				return FileShare.Read;
			else if (0 != (value & FileAttributeConstant._A_NORMAL))
				return FileShare.Write;
			else
				return FileShare.Read;
		}

		/// <summary>Converts a <see cref="FilePermissionConstant"/> value to <see cref="FileShare"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result.</returns>
		public static FileShare ToFileShare(this FilePermissionConstant value)
		{
			// Note: This is not done in a switch because the order of tests matters.
			if ((value & (FilePermissionConstant._S_IWRITE | FilePermissionConstant._S_IREAD)) != 0)
				return FileShare.ReadWrite;
			else if ((value & FilePermissionConstant._S_IWRITE) != 0)
				return FileShare.Write;
			else
				return FileShare.Read;
		}
	}
}