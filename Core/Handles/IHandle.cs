﻿namespace Vanara.PInvoke;

/// <summary>Signals that a structure or class holds a HANDLE.</summary>
public interface IHandle
{
	/// <summary>Returns the value of the handle field.</summary>
	/// <returns>An IntPtr representing the value of the handle field.</returns>
	IntPtr DangerousGetHandle();

	/// <summary>Gets a value indicating whether this handle is invalid.</summary>
	/// <value><see langword="true" /> if this handle is invalid; otherwise, <see langword="false" />.</value>
	bool IsInvalid { get; }
}