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
[Vanara.Marshaler.ArrayLayout](https://github.com/dahall/Vanara/search?l=C%23&q=ArrayLayout) | Indicates the data layout of the marshaled array. | ByValArray, ByValAnySizeArray, ByValAppendedArray, LPArray, StringPtrArray, StringPtrArrayNullTerm, ConcatenatedStringArray, LPArrayNullTerm
[Vanara.Marshaler.Bitness](https://github.com/dahall/Vanara/search?l=C%23&q=Bitness) | Specifies the number of bits in a pointer for a marshaled value. | Auto, X32bit, X64bit
[Vanara.InteropServices.CorrespondingAction](https://github.com/dahall/Vanara/search?l=C%23&q=CorrespondingAction) | Actions that can be taken with a corresponding type. | None, Get, Set, GetSet, Exception
[Vanara.RunTimeLib.FileAttributeConstant](https://github.com/dahall/Vanara/search?l=C%23&q=FileAttributeConstant) | These constants specify the current attributes of the file or directory specified by the function. | _A_NORMAL, _A_RDONLY, _A_HIDDEN, _A_SYSTEM, _A_SUBDIR, _A_ARCH
[Vanara.RunTimeLib.FileOpConstant](https://github.com/dahall/Vanara/search?l=C%23&q=FileOpConstant) | The integer expression formed from one or more of these constants determines the type of reading or writing operations permitted. It is formed by combining one or more constants with a translation-mode constant. | _O_RDONLY, _O_WRONLY, _O_RDWR, _O_APPEND, _O_RANDOM, _O_SEQUENTIAL, _O_TEMPORARY, _O_NOINHERIT, _O_CREAT, _O_TRUNC, _O_EXCL, _O_SHORT_LIVED, _O_OBTAIN_DIR, _O_TEXT, _O_BINARY, _O_RAW, _O_WTEXT, _O_U16TEXT, _O_U8TEXT
[Vanara.RunTimeLib.FilePermissionConstant](https://github.com/dahall/Vanara/search?l=C%23&q=FilePermissionConstant) | These constants are used to indicate file type in the st_mode field of the _stat structure. | _S_IEXEC, _S_IWRITE, _S_IREAD, _S_IFIFO, _S_IFCHR, _S_IFDIR, _S_IFREG, _S_IFMT
[Vanara.Marshaler.LayoutModel](https://github.com/dahall/Vanara/search?l=C%23&q=LayoutModel) | Determines the layout of the structure or class when marshaled. | Sequential, Union
[Vanara.PInvoke.SizingMethod](https://github.com/dahall/Vanara/search?l=C%23&q=SizingMethod) | Specifies the method used to determine the size of a field or array. | Count, Bytes, InclNullTerm, Query, QueryResultInReturn, CheckLastError
[Vanara.Marshaler.StringEncoding](https://github.com/dahall/Vanara/search?l=C%23&q=StringEncoding) | Identifies the type of encoding used to read and write binary representations of strings. | Default, Unicode, ASCII, UTF8, UTF32
[Vanara.InteropServices.StringListPackMethod](https://github.com/dahall/Vanara/search?l=C%23&q=StringListPackMethod) | Method used to pack a list of strings into memory. | Concatenated, Packed
### Structures
Struct | Description
---- | ----
[Vanara.InteropServices.AnySizeStructFieldArray&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=AnySizeStructFieldArray%26lt%3BT%26gt%3B) | For structures that end with an ANYSIZE array field, this structure can be used to represent the value rather than using `System.Runtime.InteropServices.UnmanagedType.ByValArray` but only when using an <c>unmanaged</c> type for <typeparamref name="T" />.
[Vanara.InteropServices.AnySizeStructUnmanagedFieldArray&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=AnySizeStructUnmanagedFieldArray%26lt%3BT%26gt%3B) | For structures that end with an ANYSIZE array field, this structure can be used to represent the value rather than using `System.Runtime.InteropServices.UnmanagedType.ByValArray` but only when using an <c>unmanaged</c> type for <typeparamref name="T" />.
[Vanara.PInvoke.ArrayPointer&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=ArrayPointer%26lt%3BT%26gt%3B) | A pointer to an array of entries in a structure.
[Vanara.BitField&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=BitField%26lt%3BT%26gt%3B) | A struct that allows for bit manipulation of a value type.
[Vanara.BOOL](https://github.com/dahall/Vanara/search?l=C%23&q=BOOL) | Managed instance of the four-byte BOOL type.
[Vanara.BOOLEAN](https://github.com/dahall/Vanara/search?l=C%23&q=BOOLEAN) | Managed instance of the single-byte BOOLEAN type.
[Vanara.Extensions.EnumFlagIndexer&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=EnumFlagIndexer%26lt%3BT%26gt%3B) | Structure to use in place of a enumerated type with the `System.FlagsAttribute` set. Allows for indexer access to flags and simplifies boolean logic.
[Vanara.InteropServices.GuidPtr](https://github.com/dahall/Vanara/search?l=C%23&q=GuidPtr) | The GuidPtr structure represents a LPGUID.
[Vanara.PInvoke.IUnknownPointer&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=IUnknownPointer%26lt%3BT%26gt%3B) | This structure is used to hold a reference to an IUnknown interface pointer.
[Vanara.PInvoke.LPCSTRArrayPointer](https://github.com/dahall/Vanara/search?l=C%23&q=LPCSTRArrayPointer) | A pointer to an array of ANSI string pointers as a field in a structure.
[Vanara.PInvoke.LPCTSTRArrayPointer](https://github.com/dahall/Vanara/search?l=C%23&q=LPCTSTRArrayPointer) | A pointer to an array of platform specific string pointers as a field in a structure.
[Vanara.PInvoke.LPCWSTRArrayPointer](https://github.com/dahall/Vanara/search?l=C%23&q=LPCWSTRArrayPointer) | A pointer to an array of Unicode (wide) string pointers as a field in a structure.
[Vanara.PInvoke.ManagedArrayPointer&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=ManagedArrayPointer%26lt%3BT%26gt%3B) | A pointer to an array of entries in a structure.
[Vanara.PInvoke.ManagedStructPointer&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=ManagedStructPointer%26lt%3BT%26gt%3B) | A pointer to a managed structure.
[Vanara.PInvoke.RefEnumerator&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=RefEnumerator%26lt%3BT%26gt%3B) | Enumerator with zero copy access using ref.
[Vanara.PInvoke.SizeT](https://github.com/dahall/Vanara/search?l=C%23&q=SizeT) | Managed instance of the SIZE_T type.
[Vanara.InteropServices.StrPtrAnsi](https://github.com/dahall/Vanara/search?l=C%23&q=StrPtrAnsi) | The StrPtr structure represents a LPWSTR.
[Vanara.InteropServices.StrPtrAuto](https://github.com/dahall/Vanara/search?l=C%23&q=StrPtrAuto) | The StrPtr structure represents a LPTSTR.
[Vanara.InteropServices.StrPtrUni](https://github.com/dahall/Vanara/search?l=C%23&q=StrPtrUni) | The StrPtr structure represents a LPWSTR.
[Vanara.PInvoke.StructPointer&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=StructPointer%26lt%3BT%26gt%3B) | A pointer to a structure.
[Vanara.PInvoke.time_t](https://github.com/dahall/Vanara/search?l=C%23&q=time_t) | Managed instance of the time_t type.
### Interfaces
Interface | Description
---- | ----
[Vanara.PInvoke.IArrayStruct&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=IArrayStruct%26lt%3BT%26gt%3B) | Interface that identifies a structure containing only a 4-byte size field followed by a pointer to an array of <typeparamref name="T" />.
[Vanara.PInvoke.IHandle](https://github.com/dahall/Vanara/search?l=C%23&q=IHandle) | Signals that a structure or class holds a HANDLE.
[Vanara.Collections.IHistory&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=IHistory%26lt%3BT%26gt%3B) | Provides an interface for a history of items.
[Vanara.InteropServices.IMemoryMethods](https://github.com/dahall/Vanara/search?l=C%23&q=IMemoryMethods) | Interface to capture unmanaged memory methods.
[Vanara.InteropServices.ISafeMemoryHandle](https://github.com/dahall/Vanara/search?l=C%23&q=ISafeMemoryHandle) | Interface for classes that support safe memory pointers.
[Vanara.InteropServices.ISafeMemoryHandleBase](https://github.com/dahall/Vanara/search?l=C%23&q=ISafeMemoryHandleBase) | Defines the base functionality for a safe memory handle, providing methods and properties for managing allocated memory.
[Vanara.InteropServices.ISafeMemoryHandleFactory](https://github.com/dahall/Vanara/search?l=C%23&q=ISafeMemoryHandleFactory) | Extension interface for `Vanara.InteropServices.SafeAllocatedMemoryHandleBase` that allows the creation of a new instance of the memory handle.
[Vanara.InteropServices.ISimpleMemoryMethods](https://github.com/dahall/Vanara/search?l=C%23&q=ISimpleMemoryMethods) | Interface to capture unmanaged simple (alloc/free) memory methods.
[Vanara.ISupportIndexer&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=ISupportIndexer%26lt%3BT%26gt%3B) | Interface representing a class that holds an indexer.
[Vanara.InteropServices.IVanaraMarshaler](https://github.com/dahall/Vanara/search?l=C%23&q=IVanaraMarshaler) | Smarter custom marshaler.
[Vanara.Collections.IVirtualListMethods&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=IVirtualListMethods%26lt%3BT%26gt%3B) | Interface that defines the methods for a virtual list. This interface is used by the `Vanara.Collections.VirtualList` class.
[Vanara.Collections.IVirtualReadOnlyListMethods&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=IVirtualReadOnlyListMethods%26lt%3BT%26gt%3B) | Interface that defines the methods for a virtual read-only list. This interface is used by the `Vanara.Collections.VirtualReadOnlyList` class.
### Classes
Class | Description
---- | ----
[Vanara.PInvoke.AddAsCtorAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=AddAsCtorAttribute) | <note type="implement">This attribute does not yet have an implemented generator.</note> An attribute to indicate that the method of the attributed parameter should be added as a constructor of the class or structure of the type being annotated. The type must be <c>partial</c> and either a structure or class.
[Vanara.PInvoke.AddAsMemberAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=AddAsMemberAttribute) | <note type="implement">This attribute does not yet have an implemented generator.</note> An attribute to indicate that the method of the attributed parameter should be added as a member of the class or structure of the type being annotated. The type must be <c>partial</c> and either a structure or class.
[Vanara.PInvoke.AdjustAutoMethodNamePatternAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=AdjustAutoMethodNamePatternAttribute) | <note type="implement">This attribute does not yet have an implemented generator.</note> <p> Applying this attribute to a class or structure will used the supplied regex pattern to replace portions of the auto-generated method names. </p>
[Vanara.InteropServices.AlignedMemory&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=AlignedMemory%26lt%3BT%26gt%3B) | A memory block aligned on a specific byte boundary.
[Vanara.Marshaler.MarshalFieldAs.AppendedStringAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=AppendedStringAttribute) | Attribute that is applied to a string as the final field in a structure to indicate that the string value is appended to the end of the structure. The string is null-terminated. The <paramref name="embeddedCharacters" /> value determines if any characters are counted in the native size of the structure.
[Vanara.Marshaler.MarshalFieldAs.ArrayAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=ArrayAttribute) | Attribute that can be applied to fields in a structure or class to indicate that the field is an array of values in a specified layout and size.
[Vanara.PInvoke.AutoHandleAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=AutoHandleAttribute) | Attribute to apply to simple struct definition that will generate the code for a full HANDLE.
[Vanara.PInvoke.AutoSafeHandleAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=AutoSafeHandleAttribute) | Attribute to apply to simple class definition that will generate the code for a full SafeHANDLE that will perform a close operation on disposal.
[Vanara.PInvoke.BeginEndEventContext](https://github.com/dahall/Vanara/search?l=C%23&q=BeginEndEventContext) | A disposable context for which a delegate is called at entry and exit.
[Vanara.Marshaler.MarshalFieldAs.BitFieldAttribute&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=BitFieldAttribute%26lt%3BT%26gt%3B) | Attribute that can be applied to fields in a structure or class to indicate that the field is a bitfield.
[Vanara.Extensions.BitHelper](https://github.com/dahall/Vanara/search?l=C%23&q=BitHelper) | Static methods to help with bit manipulation.
[Vanara.ByteSizeFormatter](https://github.com/dahall/Vanara/search?l=C%23&q=ByteSizeFormatter) | A custom formatter for byte sizes (things like files, network bandwidth, etc.) that will automatically determine the best abbreviation.
[Vanara.PInvoke.CloseHandleFunc](https://github.com/dahall/Vanara/search?l=C%23&q=CloseHandleFunc) | Delegate for a method that closes a handle and reports success. Used by SafeHandleBase.
[Vanara.InteropServices.ComConnectionPoint](https://github.com/dahall/Vanara/search?l=C%23&q=ComConnectionPoint) | Helper class to create an advised COM sink. When this class is constructed, the source is queried for an `System.Runtime.InteropServices.ComTypes.IConnectionPointContainer` reference.
[Vanara.PInvoke.InteropServices.ComEnumString](https://github.com/dahall/Vanara/search?l=C%23&q=ComEnumString) | A COM enumerator for `System.String` values. This is used to enumerate the values of a `System.Runtime.InteropServices.ComTypes.IEnumString` interface.
[Vanara.InteropServices.ComReleaser&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=ComReleaser%26lt%3BT%26gt%3B) | A safe variable to hold an instance of a COM class that automatically releases the instance on disposal.
[Vanara.InteropServices.ComReleaserFactory](https://github.com/dahall/Vanara/search?l=C%23&q=ComReleaserFactory) | Factory for creating `Vanara.InteropServices.ComReleaser` objects.
[Vanara.InteropServices.ComStream](https://github.com/dahall/Vanara/search?l=C%23&q=ComStream) | Implements a .NET stream derivation and a COM IStream instance.
[Vanara.Extensions.ComTypeExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=ComTypeExtensions) | Extensions for types in System.Runtime.InteropServices.ComTypes.
[Vanara.RunTimeLib.ConstantConversionExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=ConstantConversionExtensions) | Extension methods for CRT enumerations to convert to .NET enumerations.
[Vanara.InteropServices.CorrespondingTypeAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=CorrespondingTypeAttribute) | Attribute for enum values that provides information about corresponding types and related actions. Useful for Get/Set methods that use an enumeration value to determine the type to get or set.
[Vanara.InteropServices.CoTaskMemoryMethods](https://github.com/dahall/Vanara/search?l=C%23&q=CoTaskMemoryMethods) | Unmanaged memory methods for COM.
[Vanara.PInvoke.DeferAutoMethodFromAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=DeferAutoMethodFromAttribute) | <note type="implement">This attribute does not yet have an implemented generator.</note> <p>Applying this attribute to a class or structure will defer the auto-generated methods from that type to this type.</p>
[Vanara.Collections.EnumerableEqualityComparer&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=EnumerableEqualityComparer%26lt%3BT%26gt%3B) | Checks the linear equality of two enumerated lists. For lists to be equal, they must have the same number of elements and each index must hold the same value in each list.
[Vanara.Extensions.EnumExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=EnumExtensions) | Extensions for enumerated types.
[Vanara.Collections.EventedList&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=EventedList%26lt%3BT%26gt%3B) | A generic list that provides event for changes to the list. This is an alternative to ObservableCollection that provides distinct events for each action (add, insert, remove, changed).
[Vanara.Extensions.FileTimeExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=FileTimeExtensions) | Extensions for `System.Runtime.InteropServices.ComTypes.FILETIME`.
[Vanara.Marshaler.MarshalFieldAs.FixedStringAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=FixedStringAttribute) | Attribute that can be applied to fields in a structure or class to indicate that the field is a pointer to a string of a specified length.
[Vanara.Formatter](https://github.com/dahall/Vanara/search?l=C%23&q=Formatter) | Base class for expandable formatters.
[Vanara.FormatterComposer](https://github.com/dahall/Vanara/search?l=C%23&q=FormatterComposer) | Extension method to combine formatter instances.
[Vanara.InteropServices.GenericSafeHandle](https://github.com/dahall/Vanara/search?l=C%23&q=GenericSafeHandle) | A `System.Runtime.InteropServices.SafeHandle` that takes a delegate in the constructor that closes the supplied handle.
[Vanara.Collections.GenericVirtualReadOnlyDictionary&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=GenericVirtualReadOnlyDictionary%26lt%3BT%26gt%3B) | A generic class that creates a read-only dictionary from a list and getter function.
[Vanara.InteropServices.GuidToStringMarshaler](https://github.com/dahall/Vanara/search?l=C%23&q=GuidToStringMarshaler) | Provides a custom marshaler for converting `System.Guid` objects to and from native string representations.
[Vanara.Extensions.HexDumpHelpers](https://github.com/dahall/Vanara/search?l=C%23&q=HexDumpHelpers) | Extension to dump a byte array.
[Vanara.InteropServices.HGlobalMemoryMethods](https://github.com/dahall/Vanara/search?l=C%23&q=HGlobalMemoryMethods) | Unmanaged memory methods for HGlobal.
[Vanara.Collections.History&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=History%26lt%3BT%26gt%3B) | Provides a history of items that lives efficiently in memory and whose size can change easily.
[Vanara.PInvoke.IArrayStructExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=IArrayStructExtensions) | Extension methods for `Vanara.PInvoke.IArrayStruct`.
[Vanara.PInvoke.IArrayStructMarshaler&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=IArrayStructMarshaler%26lt%3BT%26gt%3B) | Allows marshaling of arrays in place of a structure supporting `Vanara.PInvoke.IArrayStruct`.
[Vanara.PInvoke.IgnoreAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=IgnoreAttribute) | Attribute to indicate that a field or parameter should be ignored when generating code.
[Vanara.Extensions.InteropExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=InteropExtensions) | Extension methods for System.Runtime.InteropServices.
[Vanara.InteropServices.IntPtrConverter](https://github.com/dahall/Vanara/search?l=C%23&q=IntPtrConverter) | Functions to safely convert a memory pointer to a type.
[Vanara.Extensions.IOExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=IOExtensions) | Extensions for classes in System.IO.
[Vanara.InteropServices.LibHelper](https://github.com/dahall/Vanara/search?l=C%23&q=LibHelper) | General functions to support library calls.
[Vanara.LinqHelpers](https://github.com/dahall/Vanara/search?l=C%23&q=LinqHelpers) | Helper methods for LINQ
[Vanara.Collections.EventedList&lt;T&gt;.ListChangedEventArgs&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=ListChangedEventArgs%26lt%3BT%26gt%3B) | An `System.EventArgs` structure passed to events generated by an `Vanara.Collections.EventedList`.
[Vanara.Marshaler.MarshaledAlternativeAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=MarshaledAlternativeAttribute) | Indicates that a struct has an alternative type that can be used for marshaling purposes.
[Vanara.Marshaler.MarshaledAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=MarshaledAttribute) | Attribute that can be applied to classes and structures to indicate that they support custom marshaling.
[Vanara.Marshaler.Marshaler](https://github.com/dahall/Vanara/search?l=C%23&q=Marshaler) | Contains static methods for marshaling objects.
[Vanara.Marshaler.MarshalerOptions](https://github.com/dahall/Vanara/search?l=C%23&q=MarshalerOptions) | General options for marshaling.
[Vanara.Marshaler.MarshalException](https://github.com/dahall/Vanara/search?l=C%23&q=MarshalException) | Base exception for marshaling errors.
[Vanara.Marshaler.MarshalFieldAs](https://github.com/dahall/Vanara/search?l=C%23&q=MarshalFieldAs) | A set of attributes to facilitate custom marshaling.
[Vanara.InteropServices.MarshalingStream](https://github.com/dahall/Vanara/search?l=C%23&q=MarshalingStream) | A `System.IO.Stream` derivative for working with unmanaged memory.
[Vanara.Matrix](https://github.com/dahall/Vanara/search?l=C%23&q=Matrix) | Represents a two-dimensional matrix of any size.
[Vanara.Matrix&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=Matrix%26lt%3BT%26gt%3B) | Represents a two-dimensional matrix of any size.
[Vanara.InteropServices.MemoryMethodsBase](https://github.com/dahall/Vanara/search?l=C%23&q=MemoryMethodsBase) | Implementation of `Vanara.InteropServices.IMemoryMethods` using just the methods from `Vanara.InteropServices.ISimpleMemoryMethods`.
[Vanara.PInvoke.Collections.NativeMemoryEnumerator&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=NativeMemoryEnumerator%26lt%3BT%26gt%3B) | Provides a generic enumerator over native memory.
[Vanara.InteropServices.NativeMemoryStream](https://github.com/dahall/Vanara/search?l=C%23&q=NativeMemoryStream) | A `System.IO.Stream` derivative for working with unmanaged memory.
[Vanara.InteropServices.PinnedObject](https://github.com/dahall/Vanara/search?l=C%23&q=PinnedObject) | A safe class that represents an object that is pinned in memory.
[Vanara.Extensions.ReflectionExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=ReflectionExtensions) | Extensions related to <c>System.Reflection</c>
[Vanara.Extensions.Reflection.ReflectionExtensions](https://github.com/dahall/Vanara/search?l=C%23&q=ReflectionExtensions) | Extensions for `System.Object` related to <c>System.Reflection</c>
[Vanara.InteropServices.SafeAllocatedMemoryHandle](https://github.com/dahall/Vanara/search?l=C%23&q=SafeAllocatedMemoryHandle) | Abstract base class for all SafeHandle derivatives that encapsulate handling unmanaged memory.
[Vanara.InteropServices.SafeAllocatedMemoryHandleBase](https://github.com/dahall/Vanara/search?l=C%23&q=SafeAllocatedMemoryHandleBase) | Abstract base class for all SafeHandle derivatives that encapsulate handling unmanaged memory. This class assumes read-only memory.
[Vanara.InteropServices.SafeByteArray](https://github.com/dahall/Vanara/search?l=C%23&q=SafeByteArray) | An safe unmanaged array of bytes allocated on the global heap.
[Vanara.InteropServices.SafeCoTaskMemHandle](https://github.com/dahall/Vanara/search?l=C%23&q=SafeCoTaskMemHandle) | A `System.Runtime.InteropServices.SafeHandle` for memory allocated via COM.
[Vanara.InteropServices.SafeCoTaskMemString](https://github.com/dahall/Vanara/search?l=C%23&q=SafeCoTaskMemString) | Safely handles an unmanaged memory allocated Unicode string.
[Vanara.InteropServices.SafeCoTaskMemStruct&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=SafeCoTaskMemStruct%26lt%3BT%26gt%3B) | A structure handler based on unmanaged memory allocated by AllocCoTaskMem.
[Vanara.InteropServices.SafeGuidPtr](https://github.com/dahall/Vanara/search?l=C%23&q=SafeGuidPtr) | <p>Represents a GUID point, or REFGUID, that will automatically dispose the memory to which it points at the end of scope.</p> <note>You must use the `Vanara.InteropServices.SafeGuidPtr.Null` value, or the parameter-less constructor to pass the equivalent of <see langword="null" />.</note>
[Vanara.PInvoke.SafeHANDLE](https://github.com/dahall/Vanara/search?l=C%23&q=SafeHANDLE) | Base class for all native handles.
[Vanara.InteropServices.SafeHGlobalHandle](https://github.com/dahall/Vanara/search?l=C%23&q=SafeHGlobalHandle) | A `System.Runtime.InteropServices.SafeHandle` for memory allocated via LocalAlloc.
[Vanara.InteropServices.SafeHGlobalStruct&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=SafeHGlobalStruct%26lt%3BT%26gt%3B) | A structure handler based on unmanaged memory allocated by AllocHGlobal.
[Vanara.InteropServices.SafeLPSTR](https://github.com/dahall/Vanara/search?l=C%23&q=SafeLPSTR) | Class that reprents a LPSTR with allocated memory behind it.
[Vanara.InteropServices.SafeLPTSTR](https://github.com/dahall/Vanara/search?l=C%23&q=SafeLPTSTR) | Class that reprents a LPTSTR with allocated memory behind it.
[Vanara.InteropServices.SafeLPWSTR](https://github.com/dahall/Vanara/search?l=C%23&q=SafeLPWSTR) | Class that reprents a LPWSTR with allocated memory behind it.
[Vanara.InteropServices.SafeMemoryHandle&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=SafeMemoryHandle%26lt%3BT%26gt%3B) | Abstract base class for all SafeAllocatedMemoryHandle derivatives that apply a specific memory handling routine set.
[Vanara.InteropServices.SafeMemoryHandleExt&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=SafeMemoryHandleExt%26lt%3BT%26gt%3B) | A `System.Runtime.InteropServices.SafeHandle` for memory allocated via COM.
[Vanara.InteropServices.SafeMemoryPool&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=SafeMemoryPool%26lt%3BT%26gt%3B) | A memory pool that will automatically release all memory pointers on disposal.
[Vanara.InteropServices.SafeMemString&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=SafeMemString%26lt%3BT%26gt%3B) | Base abstract class for a string handler based on `Vanara.InteropServices.SafeMemoryHandle`.
[Vanara.InteropServices.SafeMemStruct&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=SafeMemStruct%26lt%3BT%26gt%3B) | Base abstract class for a structure handler based on `Vanara.InteropServices.SafeMemoryHandle`.
[Vanara.PInvoke.SizeDefAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=SizeDefAttribute) | <note type="implement">This attribute does not yet have an implemented generator.</note>
[Vanara.PInvoke.SizeFieldNameAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=SizeFieldNameAttribute) | Should be used with `Vanara.PInvoke.ManagedArrayPointer` or `Vanara.PInvoke.ArrayPointer` to indicate which field within the same structure contains the size of the array.
[Vanara.PInvoke.SizeFieldNameAttributeExt](https://github.com/dahall/Vanara/search?l=C%23&q=SizeFieldNameAttributeExt) | Extension methods for `Vanara.PInvoke.SizeFieldNameAttribute` to get the size of an array pointer within a structure via attribute.
[Vanara.Marshaler.MarshalFieldAs.SizeOfAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=SizeOfAttribute) | Attribute that can be applied to fields in a structure or class to indicate that the field should be initialized with the native size of the parent structure or class or that indicates the size of the native structure or class on retrieval.
[Vanara.Matrix.SpanAction](https://github.com/dahall/Vanara/search?l=C%23&q=SpanAction) | A delegate that acts on a `System.Span` to set the values of the matrix.
[Vanara.Collections.SparseArray&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=SparseArray%26lt%3BT%26gt%3B) | A sparse array based on a dictionary.
[Vanara.Extensions.StringHelper](https://github.com/dahall/Vanara/search?l=C%23&q=StringHelper) | A safe class that represents an object that is pinned in memory.
[Vanara.Marshaler.MarshalFieldAs.StructPtrAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=StructPtrAttribute) | Attribute that can be applied to fields in a structure or class to indicate that the field is a pointer to a structure.
[Vanara.PInvoke.SuppressAutoGenAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=SuppressAutoGenAttribute) | An attribute that can be applied to a code element to suppress the automatic generation of P/Invoke methods for that element.
[Vanara.Collections.VirtualReadOnlyList&lt;T&gt;.TryGetDelegate](https://github.com/dahall/Vanara/search?l=C%23&q=TryGetDelegate) | Delegate for a method that tries to get the element at the specified index.
[Vanara.Collections.GenericVirtualReadOnlyDictionary&lt;T&gt;.TryGetValueDelegate](https://github.com/dahall/Vanara/search?l=C%23&q=TryGetValueDelegate) | Delegate for the implementation of the `Vanara.Collections.GenericVirtualReadOnlyDictionary.TryGetValue(,@)` method.
[Vanara.InteropServices.UnionHelper](https://github.com/dahall/Vanara/search?l=C%23&q=UnionHelper) | Methods for working with unions in unmanaged structures.
[Vanara.PInvoke.Collections.UntypedNativeMemoryEnumerator](https://github.com/dahall/Vanara/search?l=C%23&q=UntypedNativeMemoryEnumerator) | Provides an enumerator over native memory.
[Vanara.InteropServices.VanaraCustomMarshaler&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=VanaraCustomMarshaler%26lt%3BT%26gt%3B) | Provides an `System.Runtime.InteropServices.ICustomMarshaler` instance that utilizes an `Vanara.InteropServices.IVanaraMarshaler` implementation.
[Vanara.InteropServices.VanaraMarshaler](https://github.com/dahall/Vanara/search?l=C%23&q=VanaraMarshaler) | Provides methods to assist with custom marshaling.
[Vanara.InteropServices.VanaraMarshalerAttribute](https://github.com/dahall/Vanara/search?l=C%23&q=VanaraMarshalerAttribute) | Apply this attribute to a class or structure to have all Vanara interop function process via the marshaler.
[Vanara.Collections.VirtualDictionary&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualDictionary%26lt%3BT%26gt%3B) | A generic base class for providing a dictionary that gets and sets its values using virtual method calls. Useful for exposing lookups into existing list environments like the file system, registry, service controller, etc.
[Vanara.Collections.VirtualList&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualList%26lt%3BT%26gt%3B) | A virtual list that implements a lot of the scaffolding.
[Vanara.Collections.VirtualListMethodCarrier&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualListMethodCarrier%26lt%3BT%26gt%3B) | Wrapper for `Vanara.Collections.IVirtualListMethods` that allows for the use of delegates instead of implementing the interface.
[Vanara.Collections.VirtualReadOnlyDictionary&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualReadOnlyDictionary%26lt%3BT%26gt%3B) | A generic base class for providing a read-only dictionary that gets its values using virtual method calls. Useful for exposing lookups into existing list environments like the file system, registry, service controller, etc.
[Vanara.Collections.VirtualReadOnlyList&lt;T&gt;](https://github.com/dahall/Vanara/search?l=C%23&q=VirtualReadOnlyList%26lt%3BT%26gt%3B) | A virtual read-only list that implements a lot of the scaffolding.
