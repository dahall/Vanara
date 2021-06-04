## Assembly report for Vanara.Core.dll
This library includes shared methods, structures and constants for use throughout the Vanara assemblies. Think of it as windows.h with some useful extensions. It includes:
* Extension methods for working with enumerated types (enum), FILETIME, and method and property extractions via reflection
* Extension and helper methods to marshaling structures arrays and strings
* SafeHandle based classes for working with memory allocated via CoTaskMem, HGlobal, or Local calls that handles packing and extracting arrays, structures and raw memory
* Safe pinning of objects in memory
* Memory stream based on marshaled memory
### Enumerations
Enum | Description | Values
---- | ---- | ----
[Vanara.InteropServices.CorrespondingAction](https://github.com/dahall/Vanara/search?l=C%23&q=CorrespondingAction) | Actions that can be taken with a corresponding type. | None, Get, Set, GetSet, Exception
[Vanara.RunTimeLib.FileAttributeConstant](https://github.com/dahall/Vanara/search?l=C%23&q=FileAttributeConstant) | These constants specify the current attributes of the file or directory specified by the function. | _A_NORMAL, _A_RDONLY, _A_HIDDEN, _A_SYSTEM, _A_SUBDIR, _A_ARCH
[Vanara.RunTimeLib.FileOpConstant](https://github.com/dahall/Vanara/search?l=C%23&q=FileOpConstant) | The integer expression formed from one or more of these constants determines the type of reading or writing operations permitted. It is formed by combining one or more constants with a translation-mode constant. | _O_RDONLY, _O_WRONLY, _O_RDWR, _O_APPEND, _O_RANDOM, _O_SEQUENTIAL, _O_TEMPORARY, _O_NOINHERIT, _O_CREAT, _O_TRUNC, _O_EXCL, _O_SHORT_LIVED, _O_OBTAIN_DIR, _O_TEXT, _O_RAW, _O_BINARY, _O_WTEXT, _O_U16TEXT, _O_U8TEXT
[Vanara.RunTimeLib.FilePermissionConstant](https://github.com/dahall/Vanara/search?l=C%23&q=FilePermissionConstant) | These constants are used to indicate file type in the st_mode field of the _stat structure. | _S_IEXEC, _S_IWRITE, _S_IREAD, _S_IFIFO, _S_IFCHR, _S_IFDIR, _S_IFREG, _S_IFMT
[Vanara.InteropServices.StringListPackMethod](https://github.com/dahall/Vanara/search?l=C%23&q=StringListPackMethod) | Method used to pack a list of strings into memory. | Concatenated, Packed
### Structures
Struct | Description
---- | ----
[Vanara.BOOL](https://github.com/dahall/Vanara/search?l=C%23&q=BOOL) | Managed instance of the four-byte BOOL type.
[Vanara.BOOLEAN](https://github.com/dahall/Vanara/search?l=C%23&q=BOOLEAN) | Managed instance of the single-byte BOOLEAN type.
[Vanara.Extensions.EnumFlagIndexer<T>](https://github.com/dahall/Vanara/search?l=C%23&q=EnumFlagIndexer<T>) | Structure to use in place of a enumerated type with the `System.FlagsAttribute` set. Allows for indexer access to flags and simplifies boolean logic.
[Vanara.InteropServices.GuidPtr](https://github.com/dahall/Vanara/search?l=C%23&q=GuidPtr) | The GuidPtr structure represents a LPGUID.
[Vanara.PInvoke.RefEnumerator<T>](https://github.com/dahall/Vanara/search?l=C%23&q=RefEnumerator<T>) | Enumerator with zero copy access using ref.
[Vanara.PInvoke.SizeT](https://github.com/dahall/Vanara/search?l=C%23&q=SizeT) | Managed instance of the SIZE_T type.
[Vanara.InteropServices.StrPtrAnsi](https://github.com/dahall/Vanara/search?l=C%23&q=StrPtrAnsi) | The StrPtr structure represents a LPWSTR.
[Vanara.InteropServices.StrPtrAuto](https://github.com/dahall/Vanara/search?l=C%23&q=StrPtrAuto) | The StrPtr structure represents a LPTSTR.
[Vanara.InteropServices.StrPtrUni](https://github.com/dahall/Vanara/search?l=C%23&q=StrPtrUni) | The StrPtr structure represents a LPWSTR.
[Vanara.PInvoke.time_t](https://github.com/dahall/Vanara/search?l=C%23&q=time_t) | Managed instance of the time_t type.
### Interfaces
Interface | Description
---- | ----
[Vanara.PInvoke.IArrayStruct<T>](https://github.com/dahall/Vanara/search?l=C%23&q=IArrayStruct<T>) | Interface that identifies a structure containing only a 4-byte size field followed by a pointer to an array of <typeparamref name="T" />.
[Vanara.Collections.IHistory<T>](https://github.com/dahall/Vanara/search?l=C%23&q=IHistory<T>) | Provides an interface for a history of items.
[Vanara.InteropServices.IMemoryMethods](https://github.com/dahall/Vanara/search?l=C%23&q=IMemoryMethods) | Interface to capture unmanaged memory methods.
[Vanara.InteropServices.ISafeMemoryHandle](https://github.com/dahall/Vanara/search?l=C%23&q=ISafeMemoryHandle) | Interface for classes that support safe memory pointers.
[Vanara.InteropServices.ISimpleMemoryMethods](https://github.com/dahall/Vanara/search?l=C%23&q=ISimpleMemoryMethods) | Interface to capture unmanaged simple (alloc/free) memory methods.
[Vanara.InteropServices.IVanaraMarshaler](https://github.com/dahall/Vanara/search?l=C%23&q=IVanaraMarshaler) | Smarter custom marshaler.
### Classes
Class | Description
---- | ----
[Vanara.InteropServices.AlignedMemory<T>](https://github.com/dahall/Vanara/search?l=C%23&q=AlignedMemory<T>) | A memory block aligned on a specific byte boundary.
[Vanara.Extensions.BitHelper](https://github.com/dahall/Vanara/search?l=C%23&q=BitHelper) | Static methods to help with bit manipulation.
[Vanara.ByteSizeFormatter](https://github.com/dahall/Vanara/search?l=C%23&q=ByteSizeFormatter) | A custom formatter for byte sizes (things like files, network bandwidth, etc.) that will automatically determine the best abbreviation.
[Vanara.InteropServices.ComConnectionPoint](https://github.com/dahall/Vanara/search?l=C%23&q=ComConnectionPoint) | Helper class to create an advised COM sink. When this class is constructed, the source is queried for an `System.Runtime.InteropServices.ComTypes.IConnectionPointContainer` reference.
[Vanara.InteropServices.ComReleaser<T>](https://github.com/dahall/Vanara/search?l=C%23&q=ComReleaser<T>) | A safe variable to hold an instance of a COM class that automatically releases the instance on disposal.
[Vanara.InteropServices.ComReleaserFactory](https://github.com/dahall/Vanara/search?l=C%23&q=ComReleaserFactory) | Factory for creating `Vanara.InteropServices.ComReleaser`1` objects.
[Vanara.InteropServices.ComStream](https://github.com/dahall/Vanara/search?l=C%23&q=ComStream) | Implements a .NET stream derivation and a COM IStream instance.
[Vanara.Extensions.ComTypeExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=ComTypeExtensions) | Extensions for types in System.Runtime.InteropServices.ComTypes.
[Vanara.RunTimeLib.ConstantConversionExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=ConstantConversionExtensions) | Extension methods for CRT enumerations to convert to .NET enumerations.
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
[Vanara.Collections.History<T>](https://github.com/dahall/Vanara/search?l=C%23&q=History<T>) | Provides a history of items that lives efficiently in memory and whose size can change easily.
[Vanara.PInvoke.IArrayStructExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=IArrayStructExtensions) | Extension methods for `Vanara.PInvoke.IArrayStruct`1`.
[Vanara.PInvoke.IArrayStructMarshaler<T>](https://github.com/dahall/Vanara/search?l=C%23&q=IArrayStructMarshaler<T>) | Allows marshaling of arrays in place of a structure supporting `Vanara.PInvoke.IArrayStruct`1`.
[Vanara.Extensions.InteropExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=InteropExtensions) | Extension methods for System.Runtime.InteropServices.
[Vanara.InteropServices.IntPtrConverter](https://github.com/dahall/Vanara/search?l=C%23&q=IntPtrConverter) | Functions to safely convert a memory pointer to a type.
[Vanara.Extensions.IOExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=IOExtensions) | Extensions for classes in System.IO.
[Vanara.InteropServices.LibHelper](https://github.com/dahall/Vanara/search?l=C%23&q=LibHelper) | General functions to support library calls.
[Vanara.Collections.EventedList<T>.ListChangedEventArgs<T>](https://github.com/dahall/Vanara/search?l=C%23&q=ListChangedEventArgs<T>) | An `System.EventArgs` structure passed to events generated by an `Vanara.Collections.EventedList`1`.
[Vanara.InteropServices.MarshalingStream](https://github.com/dahall/Vanara/search?l=C%23&q=MarshalingStream) | A `System.IO.Stream` derivative for working with unmanaged memory.
[Vanara.InteropServices.MemoryMethodsBase](https://github.com/dahall/Vanara/search?l=C%23&q=MemoryMethodsBase) | Implementation of `Vanara.InteropServices.IMemoryMethods` using just the methods from `Vanara.InteropServices.ISimpleMemoryMethods`.
[Vanara.PInvoke.Collections.NativeMemoryEnumerator<T>](https://github.com/dahall/Vanara/search?l=C%23&q=NativeMemoryEnumerator<T>) | Provides a generic enumerator over native memory.
[Vanara.InteropServices.NativeMemoryStream](https://github.com/dahall/Vanara/search?l=C%23&q=NativeMemoryStream) | A `System.IO.Stream` derivative for working with unmanaged memory.
[Vanara.InteropServices.PinnedObject](https://github.com/dahall/Vanara/search?l=C%23&q=PinnedObject) | A safe class that represents an object that is pinned in memory.
[Vanara.Extensions.ReflectionExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=ReflectionExtensions) | Extensions related to <c>System.Reflection</c>
[Vanara.Extensions.Reflection.ReflectionExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=ReflectionExtensions) | Extensions for `System.Object` related to <c>System.Reflection</c>
[Vanara.InteropServices.SafeAllocatedMemoryHandle](https://github.com/dahall/Vanara/search?l=C%23&q=SafeAllocatedMemoryHandle) | Abstract base class for all SafeHandle derivatives that encapsulate handling unmanaged memory.
[Vanara.InteropServices.SafeAllocatedMemoryHandleBase](https://github.com/dahall/Vanara/search?l=C%23&q=SafeAllocatedMemoryHandleBase) | Abstract base class for all SafeHandle derivatives that encapsulate handling unmanaged memory. This class assumes read-only memory.
[Vanara.InteropServices.SafeByteArray](https://github.com/dahall/Vanara/search?l=C%23&q=SafeByteArray) | An safe unmanaged array of bytes allocated on the global heap.
[Vanara.InteropServices.SafeCoTaskMemHandle](https://github.com/dahall/Vanara/search?l=C%23&q=SafeCoTaskMemHandle) | A `System.Runtime.InteropServices.SafeHandle` for memory allocated via COM.
[Vanara.InteropServices.SafeCoTaskMemString](https://github.com/dahall/Vanara/search?l=C%23&q=SafeCoTaskMemString) | Safely handles an unmanaged memory allocated Unicode string.
[Vanara.InteropServices.SafeCoTaskMemStruct<T>](https://github.com/dahall/Vanara/search?l=C%23&q=SafeCoTaskMemStruct<T>) | A structure handler based on unmanaged memory allocated by AllocCoTaskMem.
[Vanara.InteropServices.SafeGuidPtr](https://github.com/dahall/Vanara/search?l=C%23&q=SafeGuidPtr) | <para>Represents a GUID point, or REFGUID, that will automatically dispose the memory to which it points at the end of scope.</para> <note>You must use the `Vanara.InteropServices.SafeGuidPtr.Null` value, or the parameter-less constructor to pass the equivalent of <see langword="null" />.</note>
[Vanara.InteropServices.SafeHGlobalHandle](https://github.com/dahall/Vanara/search?l=C%23&q=SafeHGlobalHandle) | A `System.Runtime.InteropServices.SafeHandle` for memory allocated via LocalAlloc.
[Vanara.InteropServices.SafeHGlobalStruct<T>](https://github.com/dahall/Vanara/search?l=C%23&q=SafeHGlobalStruct<T>) | A structure handler based on unmanaged memory allocated by AllocHGlobal.
[Vanara.InteropServices.SafeMemoryHandle<T>](https://github.com/dahall/Vanara/search?l=C%23&q=SafeMemoryHandle<T>) | Abstract base class for all SafeAllocatedMemoryHandle derivatives that apply a specific memory handling routine set.
[Vanara.InteropServices.SafeMemoryHandleExt<T>](https://github.com/dahall/Vanara/search?l=C%23&q=SafeMemoryHandleExt<T>) | A `System.Runtime.InteropServices.SafeHandle` for memory allocated via COM.
[Vanara.InteropServices.SafeMemString<T>](https://github.com/dahall/Vanara/search?l=C%23&q=SafeMemString<T>) | Base abstract class for a string handler based on `Vanara.InteropServices.SafeMemoryHandle`1`.
[Vanara.InteropServices.SafeMemStruct<T>](https://github.com/dahall/Vanara/search?l=C%23&q=SafeMemStruct<T>) | Base abstract class for a structure handler based on `Vanara.InteropServices.SafeMemoryHandle`1`.
[Vanara.Collections.SparseArray<T>](https://github.com/dahall/Vanara/search?l=C%23&q=SparseArray<T>) | A sparse array based on a dictionary.
[Vanara.Extensions.StringHelper](https://github.com/dahall/Vanara/search?l=C%23&q=StringHelper) | A safe class that represents an object that is pinned in memory.
[Vanara.Collections.GenericVirtualReadOnlyDictionary<T>.TryGetValueDelegate](https://github.com/dahall/Vanara/search?l=C%23&q=TryGetValueDelegate) | Delegate for the implementation of the `Vanara.Collections.GenericVirtualReadOnlyDictionary`2.TryGetValue(`0,`1@)` method.
[Vanara.PInvoke.Collections.UntypedNativeMemoryEnumerator](https://github.com/dahall/Vanara/search?l=C%23&q=UntypedNativeMemoryEnumerator) | Provides an enumerator over native memory.
[Vanara.InteropServices.VanaraCustomMarshaler<T>](https://github.com/dahall/Vanara/search?l=C%23&q=VanaraCustomMarshaler<T>) | Provides an `System.Runtime.InteropServices.ICustomMarshaler` instance that utilizes an `Vanara.InteropServices.IVanaraMarshaler` implementation.
[Vanara.InteropServices.VanaraMarshaler](https://github.com/dahall/Vanara/search?l=C%23&q=VanaraMarshaler) | Provides methods to assist with custom marshaling.
[Vanara.InteropServices.VanaraMarshalerAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=VanaraMarshalerAttribute) | Apply this attribute to a class or structure to have all Vanara interop function process via the marshaler.
[Vanara.Collections.VirtualDictionary<T>](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualDictionary<T>) | A generic base class for providing a dictionary that gets and sets its values using virtual method calls. Useful for exposing lookups into existing list environments like the file system, registry, service controller, etc.
[Vanara.Collections.VirtualReadOnlyDictionary<T>](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualReadOnlyDictionary<T>) | A generic base class for providing a read-only dictionary that gets its values using virtual method calls. Useful for exposing lookups into existing list environments like the file system, registry, service controller, etc.
