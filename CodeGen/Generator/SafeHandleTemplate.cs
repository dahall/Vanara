namespace Namespace;

#1#public static partial class ParentClassName
{
#1#	SummaryText
#2#	[global::Vanara.PInvoke.DeferAutoMethodFrom(typeof(HandleName))]
#2##7#	[global::Vanara.PInvoke.AdjustAutoMethodNamePattern(AdjNameRegex)]
#7#	public partial class ClassName : BaseClassName
	{
		/// <summary>Initializes a new instance of the <see cref="ClassName"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
		public ClassName(IntPtr preexistingHandle = default, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		// /// <summary>Initializes a new instance of the <see cref="ClassName"/> class.</summary>
		// private ClassName() : this(default, true) { }

		/// <summary>Gets a <see cref="ClassName"/> object that represents a null handle.</summary>
#pragma warning disable CS0109 // Member does not hide an inherited member
		public static new ClassName Null => new(IntPtr.Zero, false);
#pragma warning restore CS0109 // Member does not hide an inherited member

#5#		/// <summary>Performs an implicit conversion from <see cref="ClassName"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator IntPtr(ClassName h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="ClassName"/>.</summary>
		/// <param name="h">The handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ClassName(IntPtr h) => new(h, false);

#5##2#		/// <summary>Initializes a new instance of the <see cref="ClassName"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="HandleName"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
		public ClassName(HandleName preexistingHandle = default, bool ownsHandle = true) : base((IntPtr)preexistingHandle, ownsHandle) { }
	
		/// <summary>Performs an implicit conversion from <see cref="ClassName"/> to <see cref="HandleName"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HandleName(ClassName h) => h.handle;

#2##3#		/// <summary>Performs an implicit conversion from <see cref="ClassName"/> to <see cref="InheritedHandleName"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator InheritedHandleName(ClassName h) => h.handle;

#3##4#		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() CloseCode
#4#	}#1#
}#1#