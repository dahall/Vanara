## Assembly report for Vanara.Core.dll
### Enumerations
Enum | Description | Values
---- | ---- | ----
[Vanara.InteropServices.CorrespondingAction](https://github.com/dahall/Vanara/search?l=C%23&q=CorrespondingAction) | Actions that can be taken with a corresponding type. | None, Get, Set, GetSet, Exception
[Vanara.InteropServices.StringListPackMethod](https://github.com/dahall/Vanara/search?l=C%23&q=StringListPackMethod) | Method used to pack a list of strings into memory. | Concatenated, Packed
### Structures
Struct | Description
---- | ----
[Vanara.BOOL](https://github.com/dahall/Vanara/search?l=C%23&q=BOOL) | Managed instance of the four-byte BOOL type.
[Vanara.BOOLEAN](https://github.com/dahall/Vanara/search?l=C%23&q=BOOLEAN) | Managed instance of the single-byte BOOLEAN type.
[Vanara.Extensions.EnumFlagIndexer<T>](https://github.com/dahall/Vanara/search?l=C%23&q=EnumFlagIndexer<T>) | 
[Vanara.InteropServices.GuidPtr](https://github.com/dahall/Vanara/search?l=C%23&q=GuidPtr) | The GuidPtr structure represents a LPGUID.
[Vanara.PInvoke.SizeT](https://github.com/dahall/Vanara/search?l=C%23&q=SizeT) | Managed instance of the SIZE_T type.
[Vanara.InteropServices.StrPtrAnsi](https://github.com/dahall/Vanara/search?l=C%23&q=StrPtrAnsi) | The StrPtr structure represents a LPWSTR.
[Vanara.InteropServices.StrPtrAuto](https://github.com/dahall/Vanara/search?l=C%23&q=StrPtrAuto) | The StrPtr structure represents a LPTSTR.
[Vanara.InteropServices.StrPtrUni](https://github.com/dahall/Vanara/search?l=C%23&q=StrPtrUni) | The StrPtr structure represents a LPWSTR.
### Interfaces
Interface | Description
---- | ----
[Vanara.InteropServices.IMarshalDirective](https://github.com/dahall/Vanara/search?l=C%23&q=IMarshalDirective) | Supports methods that allow for marshaling to and from native memory.
[Vanara.InteropServices.IMemoryMethods](https://github.com/dahall/Vanara/search?l=C%23&q=IMemoryMethods) | Interface to capture unmanaged memory methods.
[Vanara.InteropServices.ISafeMemoryHandle](https://github.com/dahall/Vanara/search?l=C%23&q=ISafeMemoryHandle) | Interface for classes that support safe memory pointers.
### Classes
Class | Description
---- | ----
[Vanara.InteropServices.AlignedMemory<T>](https://github.com/dahall/Vanara/search?l=C%23&q=AlignedMemory<T>) | A memory block aligned on a specific byte boundary.
[Vanara.Extensions.BitHelper](https://github.com/dahall/Vanara/search?l=C%23&q=BitHelper) | Static methods to help with bit manipulation.
[Vanara.ByteSizeFormatter](https://github.com/dahall/Vanara/search?l=C%23&q=ByteSizeFormatter) | A custom formatter for byte sizes (things like files, network bandwidth, etc.) that will automatically determine the best abbreviation.
[Vanara.InteropServices.ComConnectionPoint](https://github.com/dahall/Vanara/search?l=C%23&q=ComConnectionPoint) | Helper class to create an advised COM sink. When this class is constructed, the source is queried for an `System.Runtime.InteropServices.ComTypes.IConnectionPointContainer` reference.
[Vanara.InteropServices.ComReleaser<T>](https://github.com/dahall/Vanara/search?l=C%23&q=ComReleaser<T>) | A safe variable to hold an instance of a COM class that automatically calls `System.Runtime.InteropServices.Marshal.ReleaseComObject(System.Object)` on disposal.
[Vanara.InteropServices.ComReleaserFactory](https://github.com/dahall/Vanara/search?l=C%23&q=ComReleaserFactory) | Factory for creating `Vanara.InteropServices.ComReleaser`1` objects.
[Vanara.InteropServices.ComStream](https://github.com/dahall/Vanara/search?l=C%23&q=ComStream) | Implements a .NET stream over a COM IStream instance.
[Vanara.Extensions.ComTypeExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=ComTypeExtensions) | Extensions for types in System.Runtime.InteropServices.ComTypes.
[Vanara.InteropServices.CorrespondingTypeAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=CorrespondingTypeAttribute) | Attribute for enum values that provides information about corresponding types and related actions. Useful for Get/Set methods that use an enumeration value to determine the type to get or set.
[Vanara.InteropServices.CoTaskMemoryMethods](https://github.com/dahall/Vanara/search?l=C%23&q=CoTaskMemoryMethods) | Unmanaged memory methods for COM.
[Vanara.Collections.EnumerableEqualityComparer<T>](https://github.com/dahall/Vanara/search?l=C%23&q=EnumerableEqualityComparer<T>) | Checks the linear equality of two enumerated lists. For lists to be equal, they must have the same number of elements and each index must hold the same value in each list.
[Vanara.Extensions.EnumExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=EnumExtensions) | Extensions for enumerated types.
[Vanara.Collections.EventedList<T>](https://github.com/dahall/Vanara/search?l=C%23&q=EventedList<T>) | A generic list that provides event for changes to the list. This is an alternative to ObservableCollection that provides distinct events for each action (add, insert, remove, changed).
[Vanara.Extensions.FileTimeExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=FileTimeExtensions) | Extensions for `System.Runtime.InteropServices.ComTypes.FILETIME`.
[Vanara.Formatter](https://github.com/dahall/Vanara/search?l=C%23&q=Formatter) | Base class for expandable formatters.
[Vanara.FormatterComposer](https://github.com/dahall/Vanara/search?l=C%23&q=FormatterComposer) | Extension method to combine formatter instances.
[Vanara.InteropServices.GenericSafeHandle](https://github.com/dahall/Vanara/search?l=C%23&q=GenericSafeHandle) | A `System.Runtime.InteropServices.SafeHandle` that takes a delegate in the constructor that closes the supplied handle.
[Vanara.Collections.GenericVirtualReadOnlyDictionary<T>](https://github.com/dahall/Vanara/search?l=C%23&q=GenericVirtualReadOnlyDictionary<T>) | A generic class that creates a read-only dictionary from a list and getter function.
[Vanara.Extensions.HexDempHelpers](https://github.com/dahall/Vanara/search?l=C%23&q=HexDempHelpers) | Extension to dump a byte array.
[Vanara.InteropServices.HGlobalMemoryMethods](https://github.com/dahall/Vanara/search?l=C%23&q=HGlobalMemoryMethods) | Unmanaged memory methods for HGlobal.
[Vanara.Extensions.InteropExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=InteropExtensions) | Extension methods for System.Runtime.InteropServices.
[Vanara.InteropServices.IntPtrConverter](https://github.com/dahall/Vanara/search?l=C%23&q=IntPtrConverter) | Functions to safely convert a memory pointer to a type.
[Vanara.Extensions.IOExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=IOExtensions) | Extensions for classes in System.IO.
[Vanara.Collections.EventedList<T>.ListChangedEventArgs<T>](https://github.com/dahall/Vanara/search?l=C%23&q=ListChangedEventArgs<T>) | An `System.EventArgs` structure passed to events generated by an `Vanara.Collections.EventedList`1`.
[Vanara.InteropServices.MarshalDirectiveActivator](https://github.com/dahall/Vanara/search?l=C%23&q=MarshalDirectiveActivator) | Delegate that marshals native memory to an object. See `Vanara.InteropServices.IMarshalDirective.GetActivator`.
[Vanara.InteropServices.MarshalingStream](https://github.com/dahall/Vanara/search?l=C%23&q=MarshalingStream) | A `System.IO.Stream` derivative for working with unmanaged memory.
[Vanara.InteropServices.NativeMemoryStream](https://github.com/dahall/Vanara/search?l=C%23&q=NativeMemoryStream) | A `System.IO.Stream` derivative for working with unmanaged memory.
[Vanara.InteropServices.PinnedObject](https://github.com/dahall/Vanara/search?l=C%23&q=PinnedObject) | A safe class that represents an object that is pinned in memory.
[Vanara.Extensions.ReflectionExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=ReflectionExtensions) | Extensions related to <c>System.Reflection</c>
[Vanara.Extensions.Reflection.ReflectionExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=ReflectionExtensions) | Extensions for `System.Object` related to <c>System.Reflection</c>
[Vanara.InteropServices.SafeAllocatedMemoryHandle](https://github.com/dahall/Vanara/search?l=C%23&q=SafeAllocatedMemoryHandle) | Abstract base class for all SafeHandle derivatives that encapsulate handling unmanaged memory.
[Vanara.InteropServices.SafeByteArray](https://github.com/dahall/Vanara/search?l=C%23&q=SafeByteArray) | An safe unmanaged array of bytes allocated on the global heap.
[Vanara.InteropServices.SafeCoTaskMemHandle](https://github.com/dahall/Vanara/search?l=C%23&q=SafeCoTaskMemHandle) | A `System.Runtime.InteropServices.SafeHandle` for memory allocated via COM.
[Vanara.InteropServices.SafeCoTaskMemString](https://github.com/dahall/Vanara/search?l=C%23&q=SafeCoTaskMemString) | Safely handles an unmanaged memory allocated Unicode string.
[Vanara.InteropServices.SafeHGlobalHandle](https://github.com/dahall/Vanara/search?l=C%23&q=SafeHGlobalHandle) | A `System.Runtime.InteropServices.SafeHandle` for memory allocated via LocalAlloc.
[Vanara.InteropServices.SafeMemoryHandle<T>](https://github.com/dahall/Vanara/search?l=C%23&q=SafeMemoryHandle<T>) | Abstract base class for all SafeAllocatedMemoryHandle derivatives that apply a specific memory handling routine set.
[Vanara.InteropServices.SafeMemoryHandleExt<T>](https://github.com/dahall/Vanara/search?l=C%23&q=SafeMemoryHandleExt<T>) | A `System.Runtime.InteropServices.SafeHandle` for memory allocated via COM.
[Vanara.InteropServices.SafeMemString<T>](https://github.com/dahall/Vanara/search?l=C%23&q=SafeMemString<T>) | Base abstract class for a string handler based on `Vanara.InteropServices.SafeMemoryHandle`1`.
[Vanara.Collections.SparseArray<T>](https://github.com/dahall/Vanara/search?l=C%23&q=SparseArray<T>) | A sparse array based on a dictionary.
[Vanara.Extensions.StringHelper](https://github.com/dahall/Vanara/search?l=C%23&q=StringHelper) | A safe class that represents an object that is pinned in memory.
[Vanara.Collections.GenericVirtualReadOnlyDictionary<T>.TryGetValueDelegate](https://github.com/dahall/Vanara/search?l=C%23&q=TryGetValueDelegate) | Delegate for the implementation of the `Vanara.Collections.GenericVirtualReadOnlyDictionary`2.TryGetValue(`0,`1@)` method.
[Vanara.Collections.VirtualDictionary<T>](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualDictionary<T>) | A generic base class for providing a dictionary that gets and sets its values using virtual method calls. Useful for exposing lookups into existing list environments like the file system, registry, service controller, etc.
[Vanara.Collections.VirtualReadOnlyDictionary<T>](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualReadOnlyDictionary<T>) | A generic base class for providing a read-only dictionary that gets its values using virtual method calls. Useful for exposing lookups into existing list environments like the file system, registry, service controller, etc.
