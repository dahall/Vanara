﻿namespace Vanara.PInvoke;

/// <summary>Signals that a structure or class holds a handle to a device context.</summary>
public interface IDeviceContextHandle : IHandle { }

/// <summary>Signals that a structure or class holds a handle to a graphics object.</summary>
public interface IGraphicsObjectHandle : IUserHandle { }

/// <summary>Signals that a structure or class holds a handle to a kernel object.</summary>
public interface IKernelHandle : IHandle { }

/// <summary>Signals that a structure or class holds a pointer to a security object.</summary>
public interface ISecurityObject : IHandle { }

/// <summary>Signals that a structure or class holds a handle to a shell object.</summary>
public interface IShellHandle : IHandle { }

/// <summary>Signals that a structure or class holds a handle to a synchronization object.</summary>
public interface ISyncHandle : IKernelHandle { }

/// <summary>Signals that a structure or class holds a handle to a user object.</summary>
public interface IUserHandle : IHandle { }