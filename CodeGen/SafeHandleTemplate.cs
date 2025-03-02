namespace Namespace;

#1#public static partial class ParentClassName
{
#1#	SummaryText
	public partial class ClassName : BaseClassName
	{
		/// <summary>Initializes a new instance of the <see cref="ClassName"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
		public ClassName(IntPtr preexistingHandle = default, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }
	
#2#		/// <summary>Performs an implicit conversion from <see cref="ClassName"/> to <see cref="HandleName"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HandleName(ClassName h) => h.handle;

#2##3#		/// <summary>Performs an implicit conversion from <see cref="ClassName"/> to <see cref="InheritedHandleName"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator InheritedHandleName(ClassName h) => h.handle;

#3#		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() CloseCode
	}#1#
}#1#