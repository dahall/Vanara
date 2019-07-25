using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.InteropServices
{
	/// <summary>A memory block aligned on a specific byte boundary.</summary>
	/// <typeparam name="TMem">The type of the memory.</typeparam>
	/// <seealso cref="Vanara.InteropServices.SafeAllocatedMemoryHandle"/>
	public class AlignedMemory<TMem> : SafeAllocatedMemoryHandle where TMem : IMemoryMethods, new()
	{
		/// <summary>The <see cref="IMemoryMethods"/> implementation instance.</summary>
		protected TMem mm = new TMem();

		/// <summary>The number of bytes currently allocated.</summary>
		protected int sz;

		private int alignment;
		private IntPtr rawMemPtr;

		/// <summary>Initializes a new instance of the <see cref="AlignedMemory{TMem}"/> class.</summary>
		/// <param name="sizeInBytes">The number of aligned bytes to allocate.</param>
		/// <param name="alignmentBoundary">The memory offset to which the memory is aligned.</param>
		/// <exception cref="ArgumentOutOfRangeException">
		/// sizeInBytes - The value of this argument must be non-negative or alignmentBoundary - Alignment must be at least 2.
		/// </exception>
		public AlignedMemory(int sizeInBytes, int alignmentBoundary) : base(IntPtr.Zero, true)
		{
			if (sizeInBytes < 0)
				throw new ArgumentOutOfRangeException(nameof(sizeInBytes), "The value of this argument must be non-negative");
			if (alignmentBoundary < 2)
				throw new ArgumentOutOfRangeException(nameof(alignmentBoundary), "Alignment must be at least 2.");
			if (sizeInBytes == 0) return;
			RuntimeHelpers.PrepareConstrainedRegions();
			alignment = alignmentBoundary;
			rawMemPtr = mm.AllocMem(sz = GetBufSz(sizeInBytes));
			SetHandle(rawMemPtr.Offset(GetOffset()));
			Zero();
		}

		/// <summary>Initializes a new instance of the <see cref="AlignedMemory{TMem}"/> class.</summary>
		/// <param name="sizeInBytes">The number of aligned bytes to allocate.</param>
		/// <param name="alignemntType">The type to which to align the memory. Memory will be aligned to the byte size of this type.</param>
		public AlignedMemory(int sizeInBytes, Type alignemntType) : this(sizeInBytes, Marshal.SizeOf(alignemntType))
		{
		}

		/// <summary>Gets a value indicating whether the handle value is invalid.</summary>
		public override bool IsInvalid => handle == IntPtr.Zero;

		/// <summary>Gets or sets the size in bytes of the allocated memory block.</summary>
		/// <value>The size in bytes of the allocated memory block.</value>
		public override int Size
		{
			get => IsInvalid ? 0 : sz + 1 - alignment;
			set
			{
				if (value == 0)
				{
					ReleaseHandle();
				}
				else
				{
					if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
					var newsz = GetBufSz(value);
					rawMemPtr = IsInvalid ? mm.AllocMem(newsz) : mm.ReAllocMem(rawMemPtr, newsz);
					SetHandle(rawMemPtr.Offset(GetOffset()));
					if (value > Size)
						handle.Offset(Size).FillMemory(0, value - Size);
					sz = newsz;
				}
			}
		}

		/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
		/// <returns>
		/// <see langword="true"/> if the handle is released successfully; otherwise, in the event of a catastrophic failure,
		/// <see langword="false"/>. In this case, it generates a releaseHandleFailed MDA Managed Debugging Assistant.
		/// </returns>
		protected override bool ReleaseHandle()
		{
			mm.FreeMem(rawMemPtr);
			sz = 0;
			handle = IntPtr.Zero;
			return true;
		}

		private int GetBufSz(int value) => value + alignment - 1;

		private long GetOffset() => alignment - rawMemPtr.ToInt64() % alignment;
	}
}