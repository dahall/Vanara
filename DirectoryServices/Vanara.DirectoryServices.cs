using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.ActiveDS;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.DirectoryServices;

/// <summary>Interface that identifies an object as a container with access to its children.</summary>
/// <seealso cref="Vanara.DirectoryServices.IADsObject"/>
public interface IADsContainerObject : IADsObject
{
	/// <summary>
	/// <para>
	/// The <see cref="ADsContainer"/> object enables an ADSI object to create, delete, and manage contained ADSI objects. Container objects
	/// represent hierarchical directory trees, such as in a file system, and to organize the directory hierarchy.
	/// </para>
	/// <para>
	/// You can use the <see cref="ADsContainer"/> object to either enumerate contained objects or manage their lifecycle. An example would
	/// be to recursively navigate a directory tree. By querying the <see cref="ADsContainer"/> object on an ADSI object, you can determine
	/// if the object has any children. You can continue this process for the newly found container objects. To create, copy, or delete an
	/// object, send the request to the container object to perform the task.
	/// </para>
	/// </summary>
	ADsContainer Children { get; }
}

/// <summary>Interface that represents an ADs object.</summary>
/// <seealso cref="System.IDisposable"/>
public interface IADsObject : IDisposable
{
	/// <summary>The name of the object Schema class.</summary>
	string Class { get; }

	/// <summary>Gets the native interface.</summary>
	IADs NativeInterface { get; }

	/// <summary>
	/// The globally unique identifier of the directory object.
	/// </summary>
	/// <remarks>
	/// <para>
	/// In Active Directory, the GUID returned from GUID is a string of hexadecimals. Use the resultant GUID to bind to the object directly.
	/// </para>
	/// <code language="vb">
	///<![CDATA[Dim x As IADs
	///Set x = GetObject("LDAP://servername/<GUID=xxx>")]]>
	/// </code>
	/// <para>
	/// where xxx is the value returned from the GUID property. For more information, see Using objectGUID to Bind to an Object. Be aware
	/// that if you use a GUID to bind to an object, the ADsPath property method returns values that are different from the normal values
	/// that would be returned if you used a distinguished name (DN) to bind to the same object. For example, the following table lists
	/// the values returned when using the two different binding methods to bind to the same user object.
	/// </para>
	/// </remarks>
	Guid Guid { get; }

	/// <summary>
	/// The relative name of the object as named within the underlying directory service. This name distinguishes this object from its siblings.
	/// </summary>
	string Name { get; }

	/// <summary>
	/// The parent container object. Active Directory does not permit the formation of the ADsPath of a given object by concatenating the
	/// Parent and Name properties. While this operation might work in some providers, it is not guaranteed to work for all implementations.
	/// </summary>
	IADsObject? Parent { get; }

	/// <summary>
	/// The path string of this object. The string uniquely identifies this object in a network environment. The object can always be
	/// retrieved using this path.
	/// </summary>
	string Path { get; }

	/// <summary>
	/// <para>
	/// Used to modify, read, and update a list of property entries in the property cache of an object. It serves to enumerate, modify, and
	/// purge the contained property entries. Use the enumeration method of this object to identify initialized properties. This is different
	/// from using the schema to determine all possible attributes that an ADSI object can have and which properties have been set.
	/// </para>
	/// <para>
	/// Call the methods of the <see cref="ADsPropertyCache"/> object to examine and manipulate the property list on the client. After
	/// calling the methods of this interface, you must call <see cref="ADsPropertyCache.Save"/> to save the changes in the persistent store
	/// of the underlying directory.
	/// </para>
	/// </summary>
	ADsPropertyCache PropertyCache { get; }

	/// <summary>The Schema class object of this object.</summary>
	ADsSchemaClass Schema { get; }
}

/// <summary>A template for accessing details associated with <see cref="IADs"/> derived interfaces.</summary>
/// <typeparam name="TInterface">The type of the interface.</typeparam>
/// <seealso cref="System.IDisposable"/>
/// <seealso cref="Vanara.DirectoryServices.IADsObject"/>
public abstract class ADsBaseObject<TInterface> : IDisposable, IADsObject where TInterface : class, IADs
{
	private bool disposedValue;
	private ADsPropertyCache? props = null;
	private ADsSchemaClass? schema = null;

	/// <summary>Initializes a new instance of the <see cref="ADsBaseObject{TInterface}"/> class.</summary>
	/// <param name="pathName">
	/// The string that specifies the path used to bind to the object in the underlying directory service. For more information and code
	/// examples for binding strings for this parameter, see <a
	/// href="https://learn.microsoft.com/en-us/windows/desktop/ADSI/ldap-adspath">LDAP ADsPath</a> and <a
	/// href="https://learn.microsoft.com/en-us/windows/desktop/ADSI/winnt-adspath">WinNT ADsPath</a>.
	/// </param>
	protected ADsBaseObject(string pathName)
	{
		ADsGetObject<TInterface>(pathName, out var o).ThrowIfFailed();
		Interface = o!;
	}

	/// <summary>Initializes a new instance of the <see cref="ADsBaseObject{TInterface}"/> class.</summary>
	/// <param name="pathName">
	/// The string that specifies the path used to bind to the object in the underlying directory service. For more information and code
	/// examples for binding strings for this parameter, see <a
	/// href="https://learn.microsoft.com/en-us/windows/desktop/ADSI/ldap-adspath">LDAP ADsPath</a> and <a
	/// href="https://learn.microsoft.com/en-us/windows/desktop/ADSI/winnt-adspath">WinNT ADsPath</a>.
	/// </param>
	/// <param name="auth">Provider-specific authentication flags used to define the binding options..</param>
	/// <param name="userName">
	/// The string that specifies the user name to supply to the directory service to use for credentials. This string should always be in
	/// the format "&lt;domain\&gt;&lt;user name&gt;" to avoid ambiguity. For example, if DomainA and DomainB have a trust relationship and
	/// both domains have a user with the name "user1", it is not possible to predict which domain ADsOpenObject will use to validate "user1".
	/// </param>
	/// <param name="password">The string that specifies the password to supply to the directory service to use for credentials.</param>
	protected ADsBaseObject(string pathName, ADS_AUTHENTICATION auth, [Optional] string? userName, [Optional] string? password)
	{
		ADsOpenObject<TInterface>(pathName, out var o, auth, userName, password).ThrowIfFailed();
		Interface = o!;
	}

	/// <summary>Initializes a new instance of the <see cref="ADsBaseObject{TInterface}"/> class.</summary>
	/// <param name="intf">The interface instance.</param>
	protected ADsBaseObject(TInterface intf) => Interface = intf;

	/// <inheritdoc/>
	public string Class => Interface.Class;

	/// <inheritdoc/>
	public Guid Guid => new(Interface.GUID);

	/// <summary>Gets the underlying COM interface for this object.</summary>
	public TInterface Interface { get; private set; }

	/// <inheritdoc/>
	public string Name => Interface.Name;

	/// <inheritdoc/>
	public IADsObject? Parent => TryGetProp(() => Interface.Parent, out string? o) && !string.IsNullOrEmpty(o) ? ADsObject.GetObject(o!) : null;

	/// <inheritdoc/>
	public string Path => Interface.ADsPath;

	/// <inheritdoc/>
	public ADsPropertyCache PropertyCache => props ??= new(Interface);

	/// <inheritdoc/>
	public ADsSchemaClass Schema => schema ??= new(Interface.Schema);

	/// <inheritdoc/>
	IADs IADsObject.NativeInterface => Interface;

	/// <inheritdoc/>
	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	/// <summary>
	/// Gets a value and compensates for exceptions, returning the default value for <typeparamref name="T"/> when an exception is thrown.
	/// </summary>
	/// <typeparam name="T">The type of the value to return.</typeparam>
	/// <param name="f">A lambda function or delegate that attempts to return a value.</param>
	/// <returns>The value from <paramref name="f"/>, or the default value of <typeparamref name="T"/> on failure.</returns>
	protected static T? GetProp<T>(Func<T> f) => Util.GetProp(f);

	/// <summary>
	/// Tries to get a value and compensates for exceptions, returning the default value for <typeparamref name="T"/> when an exception is thrown.
	/// </summary>
	/// <typeparam name="T">The type of the value to return.</typeparam>
	/// <param name="f">A lambda function or delegate that attempts to return a value.</param>
	/// <param name="ret">The value from <paramref name="f"/>, or the default value of <typeparamref name="T"/> on failure.</param>
	/// <returns><see langword="true"/> if the value was successfully retrieved; otherwise <see langword="false"/>.</returns>
	protected static bool TryGetProp<T>(Func<T> f, out T? ret) => Util.TryGetProp(f, out ret);

	/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
	/// <param name="disposing">
	/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
	/// </param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			props = null;
			if (disposing)
			{
				Marshal.ReleaseComObject(Interface);
			}
			disposedValue = true;
		}
	}

	/// <inheritdoc/>
	protected ADsContainer GetContainer()
	{
		try
		{
			if (Schema.Container)
				return new((IADsContainer)Interface);
		}
		catch { }
		return new(new ContainerStub());
	}

	/// <summary>Empty wrapper around <see cref="IADsContainer"/>.</summary>
	internal class ContainerStub : IADsContainer
	{
		int IADsContainer.Count => 0;
		object? IADsContainer.Filter { get => null; set => throw new NotImplementedException(); }
		object? IADsContainer.Hints { get => null; set => throw new NotImplementedException(); }

		object IADsContainer.CopyHere(string SourceName, string? NewName) => throw new NotImplementedException();

		object IADsContainer.Create(string ClassName, string RelativeName) => throw new NotImplementedException();

		void IADsContainer.Delete(string? bstrClassName, string bstrRelativeName) => throw new NotImplementedException();

		IEnumerator IADsContainer.GetEnumerator()
		{
			yield break;
		}

		IEnumerator IEnumerable.GetEnumerator() => ((IADsContainer)this).GetEnumerator();

		object IADsContainer.GetObject(string? ClassName, string RelativeName) => throw new NotImplementedException();

		object IADsContainer.MoveHere(string SourceName, string? NewName) => throw new NotImplementedException();
	}
}

/// <summary>
/// <para>
/// Enables its hosting ADSI object to define and manage an arbitrary set of named data elements for a directory service. Collections differ
/// from arrays of elements in that individual items can be added or deleted without reordering the entire array.
/// </para>
/// <para>
/// Collection objects can represent one or more items that correspond to volatile data, such as processes or active communication sessions,
/// as well as persistent data, such as physical entities for a directory service. For example, a collection object can represent a list of
/// print jobs in a queue or a list of active sessions connected to a server. Although a collection object can represent arbitrary data sets,
/// all elements in a collection must be of the same type. The data are of <c>Variant</c> types.
/// </para>
/// </summary>
/// <typeparam name="T">The type of object exposed by the collection.</typeparam>
/// <remarks>
/// Of the ADSI system providers, only the WinNT provider supports this interface to handle active file service sessions, resources and print jobs.
/// </remarks>
public class ADsCollection<T> : IDictionary<string, T> where T : class, IADsObject
{
	private readonly IADsCollection c;

	internal ADsCollection(IADsCollection c) => this.c = c;

	/// <inheritdoc/>
	public T this[string key]
	{
		get => (T)ADsObject.GetTypedObj((IADs)c.GetObject(key));
		set => Add(key, value);
	}

	/// <inheritdoc/>
	public int Count => Enum().Count();

	/// <inheritdoc/>
	public bool IsReadOnly => false;

	/// <inheritdoc/>
	public ICollection<string> Keys => GetKeys().ToList();

	/// <inheritdoc/>
	public ICollection<T> Values => GetValues().ToList();

	/// <inheritdoc/>
	public void Add(string key, T value) => c.Add(key, value.NativeInterface);

	/// <inheritdoc/>
	public void Add(KeyValuePair<string, T> item) => Add(item.Key, item.Value);

	/// <inheritdoc/>
	public void Clear() => GetKeys().ToList().ForEach(s => Remove(s));

	/// <inheritdoc/>
	public bool Contains(KeyValuePair<string, T> item) => TryGetValue(item.Key, out var t) && Equals(item.Value, t);

	/// <inheritdoc/>
	public bool ContainsKey(string key)
	{ try { _ = c.GetObject(key); return true; } catch { return false; } }

	/// <inheritdoc/>
	public void CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
	{
		var l = GetDict().ToArray();
		Array.ConstrainedCopy(l, 0, array, arrayIndex, l.Length);
	}

	/// <inheritdoc/>
	public IEnumerator<KeyValuePair<string, T>> GetEnumerator() => GetDict().GetEnumerator();

	/// <inheritdoc/>
	public bool Remove(string key)
	{ try { c.Remove(key); return true; } catch { return false; } }

	/// <inheritdoc/>
	public bool Remove(KeyValuePair<string, T> item) => Contains(item) && Remove(item.Key);

	/// <inheritdoc/>
#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).

	public bool TryGetValue(string key, [NotNullWhen(true)] out T? value)
	{ try { value = this[key]; return true; } catch { value = default; return false; } }

#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).

	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	private IEnumerable<IADs> Enum() => c.Cast<IADs>();

	private Dictionary<string, T> GetDict() => GetValues().ToDictionary(o => o.Name);

	private IEnumerable<string> GetKeys() => Enum().Select(i => i.Name);

	private IEnumerable<T> GetValues() => Enum().Select(ADsObject.GetTypedObj).WhereNotNull().OfType<T>();
}

/// <summary>
/// <para>
/// The <see cref="ADsComputer"/> object is designed to represent and manage a computer, such as a server, client, workstation, and so on, on
/// a network. You can manipulate the properties of this object to access data about a computer. The data includes the operating system, the
/// make and model, processor, computer identifier, its network addresses, and so on.
/// </para>
/// <note>The <see cref="ADsComputer"/> object is not implemented by the LDAP ADSI provider. For more information, see ADSI Objects of LDAP.</note>
/// </summary>
public class ADsComputer : ADsBaseObject<IADsComputer>, IADsContainerObject
{
	private ADsContainer? children;
	private ADsComputerOperations? ops;

	internal ADsComputer(IADs intf) : base((IADsComputer)intf)
	{
	}

	/// <inheritdoc/>
	public ADsContainer Children => children ??= GetContainer();

	/// <summary>Gets the globally unique identifier assigned to each computer.</summary>
	public Guid? ComputerID => TryGetProp(() => Interface.ComputerID, out var r) ? new(r!) : null;

	/// <summary>Gets or sets the organizational unit (OU), such as department, that this computer belongs to.</summary>
	public string? Department { get => GetProp(() => Interface.Department); set => Interface.Department = value ?? string.Empty; }

	/// <summary>Gets or sets the description of this computer.</summary>
	public string? Description { get => GetProp(() => Interface.Description); set => Interface.Description = value ?? string.Empty; }

	/// <summary>Gets or sets the division, within an organization, that this computer belongs to.</summary>
	public string? Division { get => GetProp(() => Interface.Division); set => Interface.Division = value ?? string.Empty; }

	/// <summary>Gets or sets the assigned physical location of this computer.</summary>
	public string? Location { get => GetProp(() => Interface.Location); set => Interface.Location = value ?? string.Empty; }

	/// <summary>Gets or sets the size, in megabytes, of random access memory for this computer..</summary>
	public string? MemorySize { get => GetProp(() => Interface.MemorySize); set => Interface.MemorySize = value ?? string.Empty; }

	/// <summary>Gets or sets the make and model of this computer.</summary>
	public string? Model { get => GetProp(() => Interface.Model); set => Interface.Model = value ?? string.Empty; }

	/// <summary>
	/// Gets or sets an array of NetAddress fields that represent the addresses by which this computer can be reached. NetAddress is a
	/// provider-specific string composed of two substrings separated by a colon (:). The left substring indicates the address type, and the
	/// right substring is a string representation of an address of that type. For example, TCP/IP addresses are of the form:
	/// IP:100.201.301.45. IPX type addresses are of the form: IPX:10.123456.80.
	/// </summary>
	public string[] NetAddresses
	{
		get => Util.ToStringArray(() => Interface.NetAddresses);
		set => Interface.NetAddresses = Array.ConvertAll<string, object>(value ?? [], s => s);
	}

	/// <summary>Gets or sets the operating system used on this computer.</summary>
	public string? OperatingSystem { get => GetProp(() => Interface.OperatingSystem); set => Interface.OperatingSystem = value ?? string.Empty; }

	/// <summary>Gets or sets the version of the operating system used on this computer.</summary>
	public string? OperatingSystemVersion { get => GetProp(() => Interface.OperatingSystemVersion); set => Interface.OperatingSystemVersion = value ?? string.Empty; }

	/// <summary>Gets the <see cref="ADsComputerOperations"/> object associated with this instance.</summary>
	public ADsComputerOperations Operations => ops ??= new(Interface);

	/// <summary>
	/// Gets or sets the person to whom this computer is assigned. This person should also have a license to run the installed software.
	/// </summary>
	public string? Owner { get => GetProp(() => Interface.Owner); set => Interface.Owner = value ?? string.Empty; }

	/// <summary>Gets or sets the name of the contact person, such as an administrator, for this computer.</summary>
	public string? PrimaryUser { get => GetProp(() => Interface.PrimaryUser); set => Interface.PrimaryUser = value ?? string.Empty; }

	/// <summary>Gets or sets the processor type.</summary>
	public string? Processor { get => GetProp(() => Interface.Processor); set => Interface.Processor = value ?? string.Empty; }

	/// <summary>Gets or sets the number of installed processors.</summary>
	public string? ProcessorCount { get => GetProp(() => Interface.ProcessorCount); set => Interface.ProcessorCount = value ?? string.Empty; }

	/// <summary>Gets or sets the role of this computer, for example, workstation, server, or domain controller.</summary>
	public string? Role { get => GetProp(() => Interface.Role); set => Interface.Role = value ?? string.Empty; }

	/// <summary>
	/// Gets the globally unique identifier that identifies the site that this computer was installed in. A site is a physical region of good
	/// connectivity in a network.
	/// </summary>
	public Guid? Site => TryGetProp(() => Interface.Site, out var r) ? new(r!) : null;

	/// <summary>Gets or sets the size, in megabytes, of the disk.</summary>
	public string? StorageCapacity { get => GetProp(() => Interface.StorageCapacity); set => Interface.StorageCapacity = value ?? string.Empty; }
}

/// <summary>
/// The <see cref="ADsComputerOperations"/> class exposes methods for retrieving the status of a computer over a network and to enable remote
/// shutdown. Directory service providers may choose to implement this class to support basic system administration over a network through ADSI.
/// </summary>
public class ADsComputerOperations : ADsBaseObject<IADsComputerOperations>
{
	internal ADsComputerOperations(IADsComputer comp) : base((IADsComputerOperations)comp)
	{
	}

	/// <summary>Retrieves the status of a computer.</summary>
	/// <returns>Pointer to an IDispatch interface that reports the status code of computer operations. The status code is provider-specific.</returns>
	public object? Status => GetProp(Interface.Status);

	/// <summary>Causes a computer under ADSI control to execute the shutdown operation with an optional reboot.</summary>
	/// <param name="reboot">If <see langword="true"/>, then reboot the computer after the shutdown is complete.</param>
	public void Shutdown(bool reboot) => Interface.Shutdown(reboot);
}

/// <summary>
/// <para>
/// The <see cref="ADsContainer"/> class enables an ADSI container object to create, delete, and manage contained ADSI objects. Container
/// objects represent hierarchical directory trees, such as in a file system, and to organize the directory hierarchy.
/// </para>
/// <para>
/// You can use the <see cref="ADsContainer"/> class to either enumerate contained objects or manage their lifecycle. An example would be to
/// recursively navigate a directory tree. By querying the <see cref="ADsContainer"/> class on an ADSI object, you can determine if the
/// object has any children. If the interface is not supported, the object is a leaf. Otherwise, it is a container. You can continue this
/// process for the newly found container objects. To create, copy, or delete an object, send the request to the container object to perform
/// the task.
/// </para>
/// </summary>
/// <remarks>
/// <para>
/// When you bind to a container object using its GUID (or SID), you can only perform specific operations on the container object. These
/// operations include examination of the object attributes and enumeration of the object's immediate children. These operations are shown in
/// the following code example.
/// </para>
/// <para>
/// All other operations, that is, <c>GetObject</c>, <c>Create</c>, <c>Delete</c>, <c>CopyHere</c>, and <c>MoveHere</c> are not supported in
/// the container's GUID representation. For example, the last line of the following code example will result in an error.
/// </para>
/// <para>Binding, using GUID (or SID), is intended for low overhead and, thus, fast binds, which are often used for object introspection.</para>
/// <para>To call these methods of the container bound with its GUID (or SID), rebind to the object using its distinguished name.</para>
/// <para>For more information about object GUID representation, see IADs.GUID.</para>
/// <para>Examples</para>
/// <para>The following code example determines if an ADSI object is a container.</para>
/// <para>The following code example determines if an ADSI object is a container.</para>
/// </remarks>
public class ADsContainer : ICollection<IADsObject>
{
	internal string? classFilter = null;

	internal ADsContainer(IADsContainer intf) => Interface = intf;

	/// <inheritdoc/>
	public int Count => Interface.Count;

	/// <summary>
	/// Retrieves or sets the filter used to select object classes in a given enumeration. This is an array, each element of which is the
	/// name of a schema class. If Filter is not set or set to empty, all objects of all classes are retrieved by the enumerator.
	/// </summary>
	/// <value>The filter.</value>
	public string[] Filter
	{
		get => Util.ToStringArray(() => Interface.Filter);
		set => Interface.Filter = Array.ConvertAll<string, object>(value ?? [], s => s);
	}

	/// <summary>
	/// An array of strings. Each element identifies the name of a property found in the schema definition. The vHints parameter enables the
	/// client to indicate which attributes to load for each enumerated object. Such data may be used to optimize network access. The exact
	/// implementation, however, is provider-specific, and is currently not used by the WinNT provider.
	/// </summary>
	/// <value>The hints.</value>
	public string[] Hints
	{
		get => Util.ToStringArray(() => Interface.Hints);
		set => Interface.Hints = Array.ConvertAll<string, object>(value ?? [], s => s);
	}

	/// <summary>Gets the underlying COM interface for this object.</summary>
	public IADsContainer Interface { get; private set; }

	/// <inheritdoc/>
	bool ICollection<IADsObject>.IsReadOnly => false;

	/// <summary>Gets the <see cref="IADsObject"/> value with the specified relative name.</summary>
	/// <value>The <see cref="IADsObject"/> value instance.</value>
	/// <param name="relativeName">A string that specifies the relative distinguished name of the object to retrieve.</param>
	/// <returns>The <see cref="IADsObject"/> value.</returns>
	public IADsObject this[string relativeName] => I2T((IADs)Interface.GetObject(null, relativeName));

	/// <summary>Gets the <see cref="IADsObject"/> value with the specified relative name and class.</summary>
	/// <value>The <see cref="IADsObject"/> value instance.</value>
	/// <param name="relativeName">A string that specifies the relative distinguished name of the object to retrieve.</param>
	/// <param name="className">A string that specifies the name of the object class as of the object to retrieve.</param>
	/// <returns>The <see cref="IADsObject"/> value.</returns>
	public IADsObject this[string className, string relativeName] => I2T((IADs)Interface.GetObject(className, relativeName));

	/// <summary>
	/// Sets up a request to create a directory object of the specified schema class and a given name in the container. The object is not
	/// made persistent until <see cref="ADsPropertyCache.Save"/> is called on the new object. This allows for setting mandatory properties
	/// on the new object.
	/// </summary>
	/// <param name="className">Name of the schema class object to be created.</param>
	/// <param name="relativeName">Relative name of the object as it is known in the underlying directory.</param>
	/// <returns>Indirect pointer to the IDispatch interface on the newly created object.</returns>
	public IADsObject Add(string className, string relativeName) =>
		I2T((IADs)Interface.Create(className, relativeName));

	/// <inheritdoc/>
	public void Clear()
	{
		foreach (var o in EnumInt())
			Interface.Delete(o.Class, MakeRelative(o.ADsPath));
	}

	/// <inheritdoc/>
	public bool Contains(IADsObject item) => EnumInt().Any(i => i.ADsPath == item.Path);

	/// <summary>The <c>IADsContainer::CopyHere</c> method creates a copy of the specified directory object in this container.</summary>
	/// <param name="sourcePath">The ADsPath of the object to copy.</param>
	/// <param name="newName">
	/// Optional name of the new object within the container. If a new name is not specified for the object, set to <c>NULL</c>; the new
	/// object will have the same name as the source object.
	/// </param>
	/// <returns>Indirect pointer to the IADs interface on the copied object.</returns>
	/// <remarks>
	/// <para>
	/// The destination container must be in the same directory service as the source container. An object cannot be copied across a
	/// directory service implementation.
	/// </para>
	/// <para>The providers supplied with ADSI return the <c>E_NOTIMPL</c> error message.</para>
	/// </remarks>
	public IADsObject CopyHere(string sourcePath, string? newName = null) => I2T((IADs)Interface.CopyHere(sourcePath, newName));

	/// <summary>The <c>IADsContainer::CopyHere</c> method creates a copy of the specified directory object in this container.</summary>
	/// <param name="item">The ADsPath of the object to copy.</param>
	/// <param name="newName">
	/// Optional name of the new object within the container. If a new name is not specified for the object, set to <c>NULL</c>; the new
	/// object will have the same name as the source object.
	/// </param>
	/// <returns>Indirect pointer to the IADs interface on the copied object.</returns>
	/// <remarks>
	/// <para>
	/// The destination container must be in the same directory service as the source container. An object cannot be copied across a
	/// directory service implementation.
	/// </para>
	/// <para>The providers supplied with ADSI return the <c>E_NOTIMPL</c> error message.</para>
	/// </remarks>
	public IADsObject CopyHere(IADsObject item, string? newName = null) => I2T((IADs)Interface.CopyHere(item.Path, newName));

	/// <inheritdoc/>
	public void CopyTo(IADsObject[] array, int arrayIndex)
	{
		var a = Enum().ToArray();
		Array.Copy(a, 0, array, arrayIndex, a.Length);
	}

	/// <inheritdoc/>
	public IEnumerator<IADsObject> GetEnumerator() => Enum().GetEnumerator();

	/// <summary>
	/// The <c>IADsContainer::MoveHere</c> method moves a specified object to the container that implements this interface.The method can be
	/// used to rename an object.
	/// </summary>
	/// <param name="sourcePath">The string that specifies the <c>ADsPath</c> of the object to be moved.</param>
	/// <param name="newName">
	/// The string that specifies the relative name of the new object within the container. This can be <c>NULL</c>, in which case the object
	/// is moved. If it is not <c>NULL</c>, the object is renamed accordingly in the process.
	/// </param>
	/// <returns>Pointer to a pointer to the IDispatch interface on the moved object.</returns>
	/// <remarks>
	/// <para>
	/// In Active Directory, you can move an object within the same domain or from different domains in the same directory forest. For the
	/// cross domain move, the following restrictions apply:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>The destination domain must be in the native mode.</description>
	/// </item>
	/// <item>
	/// <description>Objects to be moved must be a leaf object or an empty container.</description>
	/// </item>
	/// <item>
	/// <description>
	/// NT LAN Manager (NTLM) cannot perform authentication; use Kerberos authentication or delegation. Be aware that if Kerberos
	/// authentication is not used, the password transmits in plaintext over the network. To avoid this, use delegation with secure authentication.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// You cannot move security principals (for example, user, group, computer, and so on) belonging to a global group. When a security
	/// principal is moved, a new SID is created for the object at the destination. However, its old SID from the source, stored in the
	/// <c>sIDHistory</c> attribute, is preserved, as well as the password of the object.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c>  Use the Movetree.exe utility to move a subtree among different domains. To move objects from a source domain to a
	/// destination domain using the Movetree command-line tool, you must connect to the domain controller holding the source domain's RID
	/// master role. If the RID master is unavailable then objects cannot be moved to other domains. If you attempt to move an object from
	/// one domain to another using the Movetree.exe tool and you specify a source domain controller that is not the RID master, a
	/// nonspecific "Movetree failed" error message results.
	/// </para>
	/// <para></para>
	/// <para>
	/// <c>Note</c>  When using the ADsOpenObject function to bind to an ADSI object, you must use the <c>ADS_USE_DELEGATION</c> flag of the
	/// ADS_AUTHENTICATION_ENUM in the <c>dwReserved</c> parameter of this function in order to create cross-domain moves with
	/// <c>IADsContainer::MoveHere</c>. The <c>ADsOpenObject</c> function is equivalent to the IADsOpenDSObject::OpenDsObject method.
	/// Likewise, using the <c>OpenDsObject</c> method to bind to an ADSI object, the <c>InReserved</c> parameter of this method must contain
	/// the <c>ADS_USE_DELEGATION</c> flag of the <c>ADS_AUTHENTICATION_ENUM</c> in order to make cross-domain moves with <c>IADsContainer::MoveHere</c>.
	/// </para>
	/// <para></para>
	/// <para>
	/// The following code example moves the user, "jeffsmith" from the "South.Fabrikam.Com" domain to the "North.Fabrikam.Com" domain.
	/// First, it gets an IADsContainer pointer to the destination container, then the <c>MoveHere</c> call specifies the path of the object
	/// to move.
	/// </para>
	/// <para>A serverless ADsPath can be used for either the source or the destination or both.</para>
	/// <para>
	/// The <c>IADsContainer::MoveHere</c> method can be used either to rename an object within the same container or to move an object among
	/// different containers. Moving an object retains the object RDN, whereas renaming an object alters the RDN.
	/// </para>
	/// <para>For example, the following code example performs the rename action.</para>
	/// <para>The following code example performs the move.</para>
	/// <para>
	/// In Visual Basic applications, you can pass <c>vbNullString</c> as the second parameter when moving an object from one container to another.
	/// </para>
	/// <para>
	/// However, you cannot do the same with VBScript. This is because VBScript maps <c>vbNullString</c> to an empty string instead of to a
	/// null string, as does Visual Basic. You must use the RDN explicitly, as shown in the previous example.
	/// </para>
	/// <para>
	/// <c>Note</c>  The WinNT provider supports <c>IADsContainer::MoveHere</c>, but only for renaming users &amp; groups within a domain.
	/// </para>
	/// <para></para>
	/// <para>Examples</para>
	/// <para>The following code example shows how to use this method to rename an object.</para>
	/// <para>The following code example moves a user object using the <c>IADsContainer::MoveHere</c> method.</para>
	/// </remarks>
	public IADsObject MoveHere(string sourcePath, string? newName = null) => I2T((IADs)Interface.MoveHere(sourcePath, newName));

	/// <summary>
	/// The <c>IADsContainer::MoveHere</c> method moves a specified object to the container that implements this interface.The method can be
	/// used to rename an object.
	/// </summary>
	/// <param name="item">The string that specifies the <c>ADsPath</c> of the object to be moved.</param>
	/// <param name="newName">
	/// The string that specifies the relative name of the new object within the container. This can be <c>NULL</c>, in which case the object
	/// is moved. If it is not <c>NULL</c>, the object is renamed accordingly in the process.
	/// </param>
	/// <returns>Pointer to a pointer to the IDispatch interface on the moved object.</returns>
	/// <remarks>
	/// <para>
	/// In Active Directory, you can move an object within the same domain or from different domains in the same directory forest. For the
	/// cross domain move, the following restrictions apply:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>The destination domain must be in the native mode.</description>
	/// </item>
	/// <item>
	/// <description>Objects to be moved must be a leaf object or an empty container.</description>
	/// </item>
	/// <item>
	/// <description>
	/// NT LAN Manager (NTLM) cannot perform authentication; use Kerberos authentication or delegation. Be aware that if Kerberos
	/// authentication is not used, the password transmits in plaintext over the network. To avoid this, use delegation with secure authentication.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// You cannot move security principals (for example, user, group, computer, and so on) belonging to a global group. When a security
	/// principal is moved, a new SID is created for the object at the destination. However, its old SID from the source, stored in the
	/// <c>sIDHistory</c> attribute, is preserved, as well as the password of the object.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c>  Use the Movetree.exe utility to move a subtree among different domains. To move objects from a source domain to a
	/// destination domain using the Movetree command-line tool, you must connect to the domain controller holding the source domain's RID
	/// master role. If the RID master is unavailable then objects cannot be moved to other domains. If you attempt to move an object from
	/// one domain to another using the Movetree.exe tool and you specify a source domain controller that is not the RID master, a
	/// nonspecific "Movetree failed" error message results.
	/// </para>
	/// <para></para>
	/// <para>
	/// <c>Note</c>  When using the ADsOpenObject function to bind to an ADSI object, you must use the <c>ADS_USE_DELEGATION</c> flag of the
	/// ADS_AUTHENTICATION_ENUM in the <c>dwReserved</c> parameter of this function in order to create cross-domain moves with
	/// <c>IADsContainer::MoveHere</c>. The <c>ADsOpenObject</c> function is equivalent to the IADsOpenDSObject::OpenDsObject method.
	/// Likewise, using the <c>OpenDsObject</c> method to bind to an ADSI object, the <c>InReserved</c> parameter of this method must contain
	/// the <c>ADS_USE_DELEGATION</c> flag of the <c>ADS_AUTHENTICATION_ENUM</c> in order to make cross-domain moves with <c>IADsContainer::MoveHere</c>.
	/// </para>
	/// <para></para>
	/// <para>
	/// The following code example moves the user, "jeffsmith" from the "South.Fabrikam.Com" domain to the "North.Fabrikam.Com" domain.
	/// First, it gets an IADsContainer pointer to the destination container, then the <c>MoveHere</c> call specifies the path of the object
	/// to move.
	/// </para>
	/// <para>A serverless ADsPath can be used for either the source or the destination or both.</para>
	/// <para>
	/// The <c>IADsContainer::MoveHere</c> method can be used either to rename an object within the same container or to move an object among
	/// different containers. Moving an object retains the object RDN, whereas renaming an object alters the RDN.
	/// </para>
	/// <para>For example, the following code example performs the rename action.</para>
	/// <para>The following code example performs the move.</para>
	/// <para>
	/// In Visual Basic applications, you can pass <c>vbNullString</c> as the second parameter when moving an object from one container to another.
	/// </para>
	/// <para>
	/// However, you cannot do the same with VBScript. This is because VBScript maps <c>vbNullString</c> to an empty string instead of to a
	/// null string, as does Visual Basic. You must use the RDN explicitly, as shown in the previous example.
	/// </para>
	/// <para>
	/// <c>Note</c>  The WinNT provider supports <c>IADsContainer::MoveHere</c>, but only for renaming users &amp; groups within a domain.
	/// </para>
	/// <para></para>
	/// <para>Examples</para>
	/// <para>The following code example shows how to use this method to rename an object.</para>
	/// <para>The following code example moves a user object using the <c>IADsContainer::MoveHere</c> method.</para>
	/// </remarks>
	public IADsObject MoveHere(IADsObject item, string? newName = null) => I2T((IADs)Interface.MoveHere(item.Path, newName));

	/// <inheritdoc/>
	public bool Remove(IADsObject item) => Remove(MakeRelative(item.Path), item.Class);

	/// <summary>Removes a specified directory object from this container.</summary>
	/// <param name="relativeName">Name of the object as it is known in the underlying directory.</param>
	/// <param name="className">
	/// The schema class object to delete. Providing <see langword="null"/> for this parameter is the only way to deal with defunct schema
	/// classes. If an instance was created before the class became defunct, the only way to delete the instance of the defunct class is to
	/// call <c>Remove</c> and provide <see langword="null"/> for this parameter.
	/// </param>
	/// <param name="deleteAnyChildren">if set to <see langword="true"/>, deletes containers with children and all their children.</param>
	/// <returns><see langword="true"/> if the item was successfully removed from the container; otherwise <see langword="false"/>.</returns>
	/// <remarks>
	/// The specified object is immediately removed after calling <c>Remove</c> and calling <see cref="ADsPropertyCache.Save"/> on the
	/// container object is unnecessary.
	/// </remarks>
	public bool Remove(string relativeName, string? className = null, bool deleteAnyChildren = false)
	{
		try
		{
			Interface.Delete(className, relativeName);
			return true;
		}
		catch
		{
			if (deleteAnyChildren)
			{
				var o = (IADs)Interface.GetObject(className, relativeName);
				try
				{
					if (o is IADsDeleteOps del)
						try { del.DeleteObject(); return true; } catch { return false; }
				}
				finally { Marshal.ReleaseComObject(o); }
			}
			return false;
		}
	}

	/// <inheritdoc/>
	void ICollection<IADsObject>.Add(IADsObject item) => throw new NotImplementedException();

	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	private static string MakeRelative(string path) => path.Split('/').Last();

	private IEnumerable<IADsObject> Enum() => EnumInt().Select(I2T);

	private IEnumerable<IADs> EnumInt() => Interface.Cast<IADs>().Where(i => classFilter is null || string.Equals(i.Class, classFilter, StringComparison.InvariantCultureIgnoreCase));

	private IADsObject I2T(IADs i) => ADsObject.GetTypedObj(i);
}

/// <summary>
/// Designed to represent a network domain and manage domain accounts. Use this interface to determine whether the domain is actually a
/// Workgroup, to specify how frequently a user must change a password, and to specify the maximum number of invalid password logins allowed
/// before a lockout on the account is set. To change a password, call the <c>ChangePassword</c> method on an ADSI object that supports
/// password controls. For example, to change the password of a user account, call IADsUser::ChangePassword on the user object.
/// </summary>
/// <remarks>For the WinNT provider supplied by Microsoft, this interface is implemented on the <c>WinNTDomain</c> object.</remarks>
public class ADsDomain : ADsBaseObject<IADsDomain>, IADsContainerObject
{
	private ADsContainer? children;

	internal ADsDomain(IADs intf) : base((IADsDomain)intf)
	{
	}

	/// <inheritdoc/>
	public ADsContainer Children => children ??= GetContainer();
}

/// <summary>
/// <para>
/// Designed for representing file services supported in the directory service. Through this interface you can discover and modify the
/// maximum number of users simultaneously running a file service.
/// </para>
/// <para>
/// To access active sessions or open resources used by the file service, you must go through the Operations property to retrieve sessions or resources.
/// </para>
/// <para>To examine the status of the file service or to perform service management operations, you use the Operations property.</para>
/// </summary>
/// <remarks>Under the WinNT provider, this interface is implemented on the <c>WinNTService</c> object.</remarks>
// TODO: Inherit from ADsService??
public class ADsFileService : ADsBaseObject<IADsFileService>, IADsContainerObject
{
	private ADsContainer? children;
	private ADsFileServiceOperations? ops;

	internal ADsFileService(IADs intf) : base((IADsFileService)intf)
	{
	}

	/// <summary>Gets the <see cref="ADsFileServiceOperations"/> object associated with this instance.</summary>
	public ADsFileServiceOperations Operations => ops ??= new(Interface);

	/// <inheritdoc/>
	public ADsContainer Children => children ??= GetContainer();
}

/// <summary>
/// Extends the functionality, as exposed in the <c>ADsServiceOperations</c> interface, for managing the file service across a network.
/// Specifically, it serves to maintain and manage open resources and active sessions of the file service.
/// </summary>
// TODO: Inherit from ADsServiceOperations??
public class ADsFileServiceOperations : ADsBaseObject<IADsFileServiceOperations>
{
	internal ADsFileServiceOperations(IADsService o) : base((IADsFileServiceOperations)o)
	{
	}

	/// <summary>
	/// Gets an <see cref="ADsCollection{ADsResource}"/> instance of a collection of the resource objects representing the current open
	/// resources on this file service.
	/// </summary>
	/// <remarks>
	/// Traditional directory services supply data only about directory service elements represented in the underlying data store. Data about
	/// resources for file services may not be available from the underlying directory store.
	/// </remarks>
	public ADsCollection<ADsResource>? Resources => TryGetProp(Interface.Resources, out var c) && c is not null ? new(c) : null;

	/// <summary>
	/// Gets an <see cref="ADsCollection{ADsSession}"/> instance of a collection of the session objects that represent the current open
	/// sessions for this file service.
	/// </summary>
	/// <remarks>
	/// Traditional directory services supply data only about directory service elements represented in the underlying data store. Data about
	/// sessions for file services may not be available from the underlying store.
	/// </remarks>
	public ADsCollection<ADsSession>? Sessions => TryGetProp(Interface.Sessions, out var c) && c is not null ? new(c) : null;
}

/// <summary>
/// Designed for representing a published file share across the network. Call the methods on <c>ADsFileShare</c> to access or publish data
/// about a file share point.
/// </summary>
/// <remarks>
/// <para>
/// <c>ADsFileShare</c> is supported by WinNT system provider only. Using the WinNT provider, you can also bind to a FPNW share by
/// substituting "FPNW" for "LanmanServer" in the code examples below.
/// </para>
/// <para>
/// To bind to a file share, using the WinNT system provider, you can explicitly bind to the file service "LanmanServer" on the host machine,
/// and then enumerate the container to reach the file share of interest, or bind directly to the file share.
/// </para>
/// </remarks>
public class ADsFileShare : ADsBaseObject<IADsFileShare>
{
	internal ADsFileShare(IADs intf) : base((IADsFileShare)intf)
	{
	}
}

/// <summary>
/// Manages group membership data in a directory service. It enables you to get member objects, test if a given object belongs to the group,
/// and to add, or remove, an object to, or from, the group.
/// </summary>
public class ADsGroup : ADsBaseObject<IADsGroup>
{
	private ADsMembership? members;

	internal ADsGroup(IADs intf) : base((IADsGroup)intf)
	{
	}

	/// <summary>
	/// <para>
	/// Retrieves a collection of the immediate members of the group represented by their full ADS path name. The collection does not include
	/// the members of other groups that are nested within the group.
	/// </para>
	/// <para>
	/// The default implementation of this method uses LsaLookupSids to query name information for the group members. LsaLookupSids has a
	/// maximum limitation of 20480 SIDs it can convert, therefore that limitation also applies to this method.
	/// </para>
	/// </summary>
	public ADsMembership Members => members ??= new(Interface.Members(), Interface);
}

/// <summary>
/// Designed for managing a list of ADSI object references. It is implemented to support group membership for individual accounts. It can be
/// used to manage a collection of ADSI objects belonging to a group. To access the collection of group members, use the <see
/// cref="ADsGroup.Members"/> property method implemented by the ADSI group object.
/// </summary>
public class ADsMembership : IReadOnlyCollection<IADsObject>
{
	private readonly IADsMembers Interface;
	private readonly IADs parent;

	internal ADsMembership(IADsMembers imbr, IADs parent)
	{
		Interface = imbr;
		this.parent = parent;
	}

	/// <inheritdoc/>
	public int Count => Interface.Count;

	/// <summary>Adds an item to the members.</summary>
	/// <param name="item">The object to add.</param>
	public void Add(IADsObject item) => Add(item.Path);

	/// <summary>Adds the specified ads path.</summary>
	/// <param name="adsPath">
	/// Contains a string that specifies the ADsPath of the object to add to the group. For more information, see Remarks.
	/// </param>
	/// <exception cref="System.ArgumentException">Supplied path does not represent a valid ADs Group - adsPath</exception>
	/// <exception cref="System.InvalidOperationException">Unable to locate valid parent object.</exception>
	/// <remarks>
	/// <para>
	/// If the LDAP provider is used to bind to the IADsGroup object, the same form of ADsPath must be specified in the <paramref
	/// name="adsPath"/> parameter. For example, if the ADsPath used to bind to the <c>IADsGroup</c> object includes a server, the ADsPath in
	/// the <paramref name="adsPath"/> parameter must contain the same server prefix. Likewise, if a serverless path is used to bind to the
	/// <c>IADsGroup</c> object, the <paramref name="adsPath"/> parameter must also contain a serverless path. When using server prefix,
	/// delays may occur if the group and the new member are from different domains, as requests may be sent to the wrong domain controller
	/// and referred to a domain controller of the correct domain and retried there. An exception occurs when adding or removing a member
	/// using a GUID or security identifier (SID) ADsPath. In this case, a serverless path should always be used in <paramref name="adsPath"/>.
	/// </para>
	/// <para>
	/// The LDAP provider for Active Directory enables a member to be added to a group using the string form of the member SID. The <paramref
	/// name="adsPath"/> parameter can contain a SID string in the following form.
	/// </para>
	/// <para>For more information about SID strings in Active Directory, see Binding to an Object Using a SID.</para>
	/// <para>
	/// The WinNT provider for Active Directory also enables a member to be added to a group using the string form of the member's SID. The
	/// <paramref name="adsPath"/> parameter can contain a SID string in the following form.
	/// </para>
	/// </remarks>
	public void Add(string adsPath)
	{
		IADsGroup? iGrp = null;
		if (parent is IADsUser)
		{
			if (ADsGetObject(adsPath, out iGrp).Failed)
				throw new ArgumentException("Supplied path does not represent a valid ADs Group", nameof(adsPath));
		}
		else if (parent is IADsGroup g)
		{
			iGrp = g;
		}

		if (iGrp is null)
			throw new InvalidOperationException("Unable to locate valid parent object.");

		iGrp.Add(adsPath);
	}

	/// <summary>Removes all items from the membership.</summary>
	public void Clear() => Interface.Cast<IADs>().Select(i => i.ADsPath).ToList().ForEach(t => Remove(t));

	/// <summary>Determines whether this instance contains the object.</summary>
	/// <param name="item">The item.</param>
	/// <returns><see langword="true"/> if the members includes the item; otherwise, <see langword="false"/>.</returns>
	public bool Contains(IADsObject item) => Enum().Contains(item);

	/// <summary>Determines whether this instance contains the object.</summary>
	/// <param name="adsPath">Contains a string that specifies the ADsPath of the object.</param>
	/// <returns><see langword="true"/> if the members includes the item; otherwise, <see langword="false"/>.</returns>
	public bool Contains(string adsPath) => Interface.Cast<IADs>().Any(i => string.Equals(i.ADsPath, adsPath, StringComparison.InvariantCultureIgnoreCase));

	/// <inheritdoc/>
	public IEnumerator<IADsObject> GetEnumerator() => Enum().GetEnumerator();

	/// <summary>
	/// Removes the specified user object from this group. The operation does not remove the group object itself even when there is no member
	/// remaining in the group.
	/// </summary>
	/// <param name="item">The object to remove.</param>
	/// <returns>
	/// <see langword="true"/> if item was successfully removed from the membership; otherwise, <see langword="false"/>. This method also
	/// returns false if item is not found in the original membership.
	/// </returns>
	public bool Remove(IADsObject item) => Remove(item.Path);

	/// <summary>
	/// Removes the specified user object from this group. The operation does not remove the group object itself even when there is no member
	/// remaining in the group.
	/// </summary>
	/// <param name="adsPath">
	/// Contains a string that specifies the ADsPath of the object to remove from the group. For more information about this parameter, see
	/// the Remarks section.
	/// </param>
	/// <returns>
	/// <see langword="true"/> if item was successfully removed from the membership; otherwise, <see langword="false"/>. This method also
	/// returns false if item is not found in the original membership.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the LDAP provider is used to bind to the IADsGroup object, the same form of ADsPath must be specified in the <paramref
	/// name="adsPath"/> parameter. For example, if the ADsPath used to bind to the <c>IADsGroup</c> object includes a server, the ADsPath in
	/// the <paramref name="adsPath"/> parameter must contain the same server prefix. Likewise, if a serverless path is used to bind to the
	/// <c>IADsGroup</c> object, the <paramref name="adsPath"/> parameter must also contain a serverless path. The exception is when adding
	/// or removing a member using a GUID or SID ADsPath. In this case, a serverless path should always be used in <paramref name="adsPath"/>.
	/// </para>
	/// <para>
	/// You can use a SID in the ADsPath to remove a security principal from the group through the WinNT provider. For example, suppose the
	/// SID of a user, "Fabrikam\jeffsmith", is S-1-5-21-35135249072896, the following statement:
	/// </para>
	/// <code language="vb">
	///<![CDATA[Dim group As IADsGroup
	///group.Remove("WinNT://S-1-5-21-35135249072896")]]>
	/// </code>
	/// <para>is equivalent to</para>
	/// <code language="vb">
	///<![CDATA[Dim group As IADsGroup
	///group.Remove("WinNT://Fabrikam/jeffsmith")]]>
	/// </code>
	/// <para>Removing a member using its SID through the WinNT provider is a new feature in Windows 2000 and the DSCLIENT package.</para>
	/// </remarks>
	public bool Remove(string adsPath)
	{
		IADsGroup? iGrp = null;
		if (parent is IADsUser)
		{
			if (ADsGetObject(adsPath, out iGrp).Failed)
				throw new ArgumentException("Supplied path does not represent a valid ADs Group", nameof(adsPath));
		}
		else if (parent is IADsGroup g)
		{
			iGrp = g;
		}

		if (iGrp is null)
			return false;

		try { iGrp.Remove(adsPath); return true; } catch { return false; }
	}

	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	private IEnumerable<IADsObject> Enum() => Interface.Cast<IADs>().Select(ADsObject.GetTypedObj);
}

/// <summary>
/// <para>
/// The <see cref="ADsObject"/> class defines the basic object features, that is, properties and methods, of any ADSI object. Examples of
/// ADSI objects include users, computers, services, organization of user accounts and computers, file systems, and file service operations.
/// Every ADSI object must support this interface, which serves to do the following:
/// </para>
/// <list type="bullet">
/// <item>
/// <description>Provides object identification by name, class, or ADsPath</description>
/// </item>
/// <item>
/// <description>Identifies the object's container that manages the object's creation and deletion</description>
/// </item>
/// <item>
/// <description>Retrieves the object's schema definition</description>
/// </item>
/// <item>
/// <description>Loads object's attributes to the property cache and commits changes to the persistent directory store</description>
/// </item>
/// <item>
/// <description>Accesses and modifies the object's attribute values in the property cache</description>
/// </item>
/// </list>
/// <para>
/// The <see cref="ADsObject"/> class is designed to ensure that ADSI objects provide network administrators and directory service providers
/// with a simple and consistent representation of various underlying directory services.
/// </para>
/// </summary>
public class ADsObject : ADsBaseObject<IADs>
{
	internal ADsObject(IADs intf) : base(intf)
	{
	}

	/// <summary>The <c>GetObject</c> function binds to an object given its path and a specified interface identifier.</summary>
	/// <param name="path">
	/// The string that specifies the path used to bind to the object in the underlying directory service. For more information and code
	/// examples for binding strings for this parameter, see <a
	/// href="https://learn.microsoft.com/en-us/windows/desktop/ADSI/ldap-adspath">LDAP ADsPath</a> and <a
	/// href="https://learn.microsoft.com/en-us/windows/desktop/ADSI/winnt-adspath">WinNT ADsPath</a>.
	/// </param>
	/// <returns>The requested object.</returns>
	/// <remarks>
	/// It is possible to bind to an ADSI object with a user credential different from that of the currently logged-on user. To perform this
	/// operation, use the <see cref="OpenObject"/> method.
	/// </remarks>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IADsObject GetObject(string path)
	{
		ADsGetObject(path, out IADs? o).ThrowIfFailed();
		return GetTypedObj(o!);
	}

	/// <summary>The <c>OpenObject</c> function binds to an ADSI object using explicit user name and password credentials.</summary>
	/// <param name="path">
	/// The string that specifies the path used to bind to the object in the underlying directory service. For more information and code
	/// examples for binding strings for this parameter, see <a
	/// href="https://learn.microsoft.com/en-us/windows/desktop/ADSI/ldap-adspath">LDAP ADsPath</a> and <a
	/// href="https://learn.microsoft.com/en-us/windows/desktop/ADSI/winnt-adspath">WinNT ADsPath</a>.
	/// </param>
	/// <param name="userName">
	/// The string that specifies the user name to supply to the directory service to use for credentials. This string should always be in
	/// the format "&lt;domain\&gt;&lt;user name&gt;" to avoid ambiguity. For example, if DomainA and DomainB have a trust relationship and
	/// both domains have a user with the name "user1", it is not possible to predict which domain <c>OpenObject</c> will use to validate "user1".
	/// </param>
	/// <param name="password">The string that specifies the password to supply to the directory service to use for credentials.</param>
	/// <param name="auth">Provider-specific authentication flags used to define the binding options. For more information, see ADS_AUTHENTICATION_ENUM.</param>
	/// <returns>The requested object.</returns>
	/// <remarks>
	/// <para>This function should not be used just to validate user credentials.</para>
	/// <para>
	/// The credentials passed to the <c>OpenObject</c> function are used only with the particular object bound to and do not affect the
	/// security context of the calling thread. This means that, in the example below, the call to <c>OpenObject</c> will use different
	/// credentials than the call to ADsGetObject.
	/// </para>
	/// <para>To work with the WinNT: provider, you can pass in <paramref name="userName"/> as one of the following strings:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>The name of a user account, that is, "jeffsmith".</description>
	/// </item>
	/// <item>
	/// <description>The Windows style user name, that is, "Fabrikam\jeffsmith".</description>
	/// </item>
	/// </list>
	/// <para>With the LDAP provider for Active Directory, you may pass in <paramref name="userName"/> as one of the following strings:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// The name of a user account, such as "jeffsmith". To use a user name by itself, you must set only the <c>ADS_SECURE_AUTHENTICATION</c>
	/// flag in the <paramref name="auth"/> parameter.
	/// </description>
	/// </item>
	/// <item>
	/// <description>The user path from a previous version of Windows, such as "Fabrikam\jeffsmith".</description>
	/// </item>
	/// <item>
	/// <description>
	/// Distinguished Name, such as "CN=Jeff Smith,OU=Sales,DC=Fabrikam,DC=Com". To use a DN, the <paramref name="auth"/> parameter must be
	/// zero or it must include the <c>ADS_USE_SSL</c> flag.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// User Principal Name (UPN), such as "jeffsmith@Fabrikam.com". To use a UPN, assign the appropriate UPN value for the
	/// <c>userPrincipalName</c> attribute of the target user object.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// If Kerberos authentication is required for the successful completion of a specific directory request using the LDAP provider, the
	/// <c>lpszPathName</c> binding string must use either a serverless ADsPath, such as "LDAP://CN=Jeff Smith,CN=admin,DC=Fabrikam,DC=com",
	/// or it must use an ADsPath with a fully qualified DNS server name, such as "LDAP://central3.corp.Fabrikam.com/CN=Jeff
	/// Smith,CN=admin,DC=Fabrikam,DC=com". Binding to the server using a flat NETBIOS name or a short DNS name, for example, using the short
	/// name "central3" instead of "central3.corp.Fabrikam.com", may or may not yield Kerberos authentication.
	/// </para>
	/// </remarks>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IADsObject OpenObject(string path, [Optional] ADS_AUTHENTICATION auth, [Optional] string? userName,
		[Optional] string? password)
	{
		ADsOpenObject(path, out IADs? o, auth, userName, password).ThrowIfFailed();
		return GetTypedObj(o!);
	}

	internal static IADsObject GetTypedObj(IADs obj) => obj.Class switch
	{
		"Class" => new ADsSchemaClass(obj),
		"Computer" => new ADsComputer(obj),
		"Domain" => new ADsDomain(obj),
		"FileService" => new ADsFileService(obj),
		"FileShare" => new ADsFileShare(obj),
		"Group" => new ADsGroup(obj),
		"PrintJob" => new ADsPrintJob(obj),
		"PrintQueue" => new ADsPrintQueue(obj),
		"Property" => new ADsSchemaProperty(obj),
		"Resource" => new ADsResource(obj),
		"Service" => new ADsService(obj),
		"Session" => new ADsSession(obj),
		"Syntax" => new ADsSchemaPropertySyntax(obj),
		"User" => new ADsUser(obj),
		_ => new ADsObject(obj)
	};
}

/// <summary>
/// Designed for representing a print job. When a user submits a request to a printer to print a document, a print job is created in the
/// print queue. The property methods allow you to access the information about a print job. Such information includes which printer performs
/// the printing, who submitted the document, when the document was submitted, and how many pages will be printed.
/// </summary>
/// <remarks>
/// <para>
/// To manage a print job across a network, use the Operations property, which supports the functionality to examine the status of a print
/// job and to pause or resume the operation of printing the document, and so on.
/// </para>
/// <para>
/// To access any print jobs in a print queue, call the PrintJobs propertyto obtain the collection object holding all the print jobs in the
/// print queue.
/// </para>
/// </remarks>
public class ADsPrintJob : ADsBaseObject<IADsPrintJob>
{
	private ADsPrintJobOperations? ops;

	internal ADsPrintJob(IADs i) : base((IADsPrintJob)i)
	{
	}

	/// <summary>Gets the <see cref="ADsPrintJobOperations"/> object associated with this instance.</summary>
	public ADsPrintJobOperations Operations => ops ??= new(Interface);
}

/// <summary>
/// <para>
/// Used to control a print job across a network. A print job object that implements the IADsPrintJob interface will also support the
/// following features for this interface:
/// </para>
/// <list type="bullet">
/// <item>
/// <description>To examine the operational status and other information.</description>
/// </item>
/// <item>
/// <description>To interrupt a running print job.</description>
/// </item>
/// <item>
/// <description>To resume a paused print job.</description>
/// </item>
/// </list>
/// </summary>
public class ADsPrintJobOperations : ADsBaseObject<IADsPrintJobOperations>
{
	internal ADsPrintJobOperations(IADsPrintJob o) : base((IADsPrintJobOperations)o)
	{
	}

	/// <summary>Gets the number of pages printed.</summary>
	public int PagesPrinted => Interface.PagesPrinted;

	/// <summary>Gets or sets the position of this print job in the print queue.</summary>
	public int Position { get => Interface.Position; set => Interface.Position = value; }

	/// <summary>Gets the current status of the print job as indicated by one of the ADSI Print Job Status Constants values.</summary>
	public ADS_JOB_STATUS Status => Interface.Status;

	/// <summary>Gets the number of milliseconds elapsed since the print job started.</summary>
	public TimeSpan TimeElapsed => TimeSpan.FromMilliseconds(Interface.TimeElapsed);

	/// <summary>Halts the processing of the current print job. Call the Resume method to continue the processing.</summary>
	public void Pause() => Interface.Pause();

	/// <summary>Continues the print job halted by the Pause method.</summary>
	public void Resume() => Interface.Resume();
}

/// <summary>
/// The <c>ADsPrintQueue</c> class represents a printer on a network. The property methods of this interface enables you to access data about
/// a printer, for example printer model, physical location, and network address.
/// </summary>
/// <remarks>
/// <para>
/// Use this class to browse a collection of print jobs in the print queue. To control a printer across a network, use the Operations
/// property. To obtain a collection of the print jobs, call the PrintJobs method.
/// </para>
/// <para>
/// In Windows, a printer, or a print queue, is managed by a host computer. If the path to a print queue is known, bind to it as to any other
/// ADSI objects.
/// </para>
/// <para><c>To enumerate all print queues on a given computer</c></para>
/// <list type="number">
/// <item>
/// <description>Bind to the computer object.</description>
/// </item>
/// <item>
/// <description>Determine if the computer contains any "PrintQueue" objects.</description>
/// </item>
/// <item>
/// <description>Enumerate all the found printer objects.</description>
/// </item>
/// </list>
/// </remarks>
public class ADsPrintQueue : ADsBaseObject<IADsPrintQueue>
{
	private ADsPrintQueueOperations? ops;

	internal ADsPrintQueue(IADs intf) : base((IADsPrintQueue)intf)
	{
	}

	/// <summary>Gets the <see cref="ADsPrintQueueOperations"/> object associated with this instance.</summary>
	public ADsPrintQueueOperations Operations => ops ??= new(Interface);
}

/// <summary>
/// <para>Used to control a printer from across a network.</para>
/// <para>The <c>ADsPrintQueueOperations</c> class supports the following operations:</para>
/// <list type="bullet">
/// <item>
/// <description>Retrieve all print jobs submitted to the print queue.</description>
/// </item>
/// <item>
/// <description>Suspend the print queue operation.</description>
/// </item>
/// <item>
/// <description>Resume the print queue operation.</description>
/// </item>
/// <item>
/// <description>Remove all print jobs from the print queue.</description>
/// </item>
/// </list>
/// </summary>
public class ADsPrintQueueOperations : ADsBaseObject<IADsPrintQueueOperations>
{
	internal ADsPrintQueueOperations(IADsPrintQueue o) : base((IADsPrintQueueOperations)o)
	{
	}

	/// <summary>
	/// Gets the collection of the print jobs processed in this print queue. To delete a print job, use the Remove method on the retrieved
	/// interface pointer.
	/// </summary>
	public ADsCollection<ADsPrintJob>? PrintJobs => TryGetProp(Interface.PrintJobs, out var c) && c is not null ? new(c) : null;

	/// <summary>Gets the current status of the print queue operations..</summary>
	public ADS_PRINT_QUEUE_STATUS Status => Interface.Status;

	/// <summary>Suspends the processing of print jobs within a print queue service.</summary>
	public void Pause() => Interface.Pause();

	/// <summary>Clears the print queue of all print jobs without processing them.</summary>
	public void Purge() => Interface.Purge();

	/// <summary>Resumes processing of suspended print jobs in the print queue.</summary>
	public void Resume() => Interface.Resume();
}

/// <summary>
/// <para>
/// The <c>ADsPropertyCache</c> class is used to modify, read, and update a list of property entries in the property cache of an object. It
/// serves to enumerate, modify, and purge the contained property entries. Use the enumeration method of this class to identify initialized
/// properties. This is different from using the schema to determine all possible attributes that an ADSI object can have and which
/// properties have been set.
/// </para>
/// <para>
/// Call the methods of the <c>ADsPropertyCache</c> class to examine and manipulate the property list on the client. After calling the
/// methods of this class, you must call <see cref="Save"/> to save the changes in the persistent store of the underlying directory.
/// </para>
/// </summary>
public class ADsPropertyCache : /*DynamicObject,*/ IDictionary<string, object?>
{
	private readonly IADs Interface;

	private readonly IADsPropertyList? props;

	internal ADsPropertyCache(IADs intf)
	{
		Interface = intf;
		props = Interface as IADsPropertyList;
		Refresh();
	}

	/// <inheritdoc/>
	public int Count => props?.PropertyCount ?? 0;

	/// <inheritdoc/>
	public bool IsReadOnly => false;

	/// <inheritdoc/>
	public ICollection<string> Keys => EnumProps().Select(pe => pe.Name).ToList();

	/// <inheritdoc/>
	public ICollection<object?> Values => EnumProps().Select(GetValue).ToList();

	/// <inheritdoc/>
	public object? this[string key]
	{
		get => Interface.Get(key);
		set => Add(key, value);
	}

	/// <inheritdoc/>
	public void Add(string key, object? value) => Interface.PutEx(ADS_PROPERTY_OPERATION.ADS_PROPERTY_UPDATE, key, value);

	/// <inheritdoc/>
	public void Add(KeyValuePair<string, object?> item) => Add(item.Key, item.Value);

	/// <inheritdoc/>
	public void Clear()
	{
		foreach (var k in Keys)
			Remove(k);
	}

	/// <inheritdoc/>
	public bool Contains(KeyValuePair<string, object?> item) => TryGetValue(item.Key, out var t) && Equals(item.Value, t);

	/// <inheritdoc/>
	public bool ContainsKey(string key) => EnumProps().Any(pe => string.Equals(pe.Name, key, StringComparison.InvariantCultureIgnoreCase));

	/// <inheritdoc/>
	public void CopyTo(KeyValuePair<string, object?>[] array, int arrayIndex) => throw new NotImplementedException();

	/// <inheritdoc/>
	public IEnumerator<KeyValuePair<string, object?>> GetEnumerator() =>
		EnumProps().Select(pe => new KeyValuePair<string, object?>(pe.Name, GetValue(pe))).GetEnumerator();

	/// <summary>
	/// Reloads into the property cache values of the supported properties of this ADSI object from the
	/// underlying directory store.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>Refresh</c> function is called to initialize or refresh the property cache. This is similar to obtaining those
	/// property values of supported properties from the underlying directory store.
	/// </para>
	/// <para>
	/// An uninitialized property cache is not necessarily empty. Call IADs::Put or IADs::PutEx to place a value into the property cache
	/// for any supported property and the cache remains uninitialized.
	/// </para>
	/// <para>
	/// An explicit call to <c>Refresh</c> loads or reloads the entire property cache, overwriting all the cached property values.
	/// But an implicit call loads only those properties not set in the cache. Always call <c>Refresh</c> explicitly to retrieve
	/// the most current property values of the ADSI object.
	/// </para>
	/// <para>
	/// Because an explicit call to <c>Refresh</c> overwrites all the values in the property cache, any change made to the cache
	/// will be lost if an IADs::SetInfo was not invoked before <c>Refresh</c>.
	/// </para>
	/// <para>
	/// For an ADSI container object, <c>Refresh</c> caches only the property values of the container, but not those of the child objects.
	/// </para>
	/// <para>
	/// It is important to emphasize the differences between the IADs::Get and <c>Refresh</c> methods. The former returns values of
	/// a given property from the property cache whereas the latter loads all the supported property values into the property cache from
	/// the underlying directory store.
	/// </para>
	/// <para>The following code example illustrates the differences between the IADs::Get and <c>Refresh</c> methods.</para>
	/// <para>
	/// For increased performance, explicitly call IADs::GetInfoEx to refresh specific properties. Also, <c>IADs::GetInfoEx</c> must be
	/// called instead of <c>Refresh</c> if the object's operational property values have to be accessed. This function overwrites
	/// any previously cached values of the specified properties.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example uses a computer object served by the WinNT provider. The supported properties include <c>Owner</c>
	/// ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"), <c>Division</c> ("Fabrikam"),
	/// <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping 1"). The default values are shown
	/// in parentheses.
	/// </para>
	/// <para>
	/// The following code example is a client-side script that illustrates the effect of <c>Refresh</c> method. The supported
	/// properties include <c>Owner</c> ("Owner"), <c>OperatingSystem</c> ("Windows NT"), <c>OperatingSystemVersion</c> ("4.0"),
	/// <c>Division</c> ("Fabrikam"), <c>ProcessorCount</c> ("Uniprococessor Free"), <c>Processor</c> ("x86 Family 6 Model 5 Stepping
	/// 1"). The default values are shown in parentheses.
	/// </para>
	/// <para>The following code example highlights the effect of Get and GetInfo. For brevity, error checking is omitted.</para>
	/// </remarks>
	public void Refresh() => Interface.GetInfo();

	/// <inheritdoc/>
	public bool Remove(string key)
	{
		try { Interface.PutEx(ADS_PROPERTY_OPERATION.ADS_PROPERTY_CLEAR, key); return true; }
		catch { return false; }
	}

	/// <inheritdoc/>
	public bool Remove(KeyValuePair<string, object?> item) => Contains(item) && Remove(item.Key);

	/// <summary>Saves the cached property values of the ADSI object to the underlying directory store.</summary>
	/// <remarks>
	/// Because <c>Save</c> sends data across networks, minimize the usage of this method. This reduces the number of trips a
	/// client makes to the server. For example, you should commit all, or most, of the changes to the properties from the cache to the
	/// persistent store in one batch.
	/// </remarks>
	public void Save() => Interface.SetInfo();

	/// <inheritdoc/>
	public bool TryGetValue(string key, out object? value)
	{
		try { value = this[key]; return true; }
		catch { value = default; return false; }
	}

	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	private static object? GetValue(IADsPropertyEntry pe)
	{
		var val = (IADsPropertyValue?)((object[]?)pe.Values)?.FirstOrDefault();
		return val == null
			? null
			: val.ADsType switch
			{
				ADSTYPE.ADSTYPE_INVALID => null,
				ADSTYPE.ADSTYPE_DN_STRING => val.DNString,
				ADSTYPE.ADSTYPE_CASE_EXACT_STRING => val.CaseExactString,
				ADSTYPE.ADSTYPE_CASE_IGNORE_STRING => val.CaseIgnoreString,
				ADSTYPE.ADSTYPE_PRINTABLE_STRING => val.PrintableString,
				ADSTYPE.ADSTYPE_NUMERIC_STRING => val.NumericString,
				ADSTYPE.ADSTYPE_BOOLEAN => val.Boolean,
				ADSTYPE.ADSTYPE_INTEGER => val.Integer,
				ADSTYPE.ADSTYPE_OCTET_STRING => (byte[])val.OctetString,
				ADSTYPE.ADSTYPE_UTC_TIME => val.UTCTime,
				ADSTYPE.ADSTYPE_LARGE_INTEGER => ((IADsLargeInteger)val.LargeInteger).ToInt64(),
				ADSTYPE.ADSTYPE_NT_SECURITY_DESCRIPTOR => ISD2SD(val.SecurityDescriptor),
				_ => throw new InvalidOperationException("Unable to extract property value."),
			};
	}

	private static SafePSECURITY_DESCRIPTOR ISD2SD(object isd)
	{
		SecurityDescriptorToBinarySD((IADsSecurityDescriptor)isd, out var sd, out _).ThrowIfFailed();
		return new SafePSECURITY_DESCRIPTOR(sd, true);
	}

	private IEnumerable<IADsPropertyEntry> EnumProps()
	{
		for (int i = 0; i < Count; i++)
			yield return (IADsPropertyEntry)props!.Item(i);
	}
}

/// <summary>Designed to manage an open resource for a file service across a network.</summary>
/// <remarks>
/// When a remote user opens a folder or a subfolder on a public share point on the target computer, ADSI considers this folder to be an open
/// resource and represents it with a resource object that implements this interface.
/// </remarks>
public class ADsResource : ADsBaseObject<IADsResource>
{
	internal ADsResource(IADs i) : base((IADsResource)i)
	{
	}
}

/// <summary>
/// The <c>ADsSchemaClass</c> class is designed for managing schema class objects that provide class definitions for any ADSI object. Other
/// schema management classes include ADsProperty for attribute definitions and ADsSyntax for attribute syntax.
/// </summary>
/// <remarks>
/// Schema objects are organized in the schema container of a given directory. To access an object's schema class, use the object's
/// <c>Schema</c> property to obtain the ADsPath string and use that string to bind to its schema class object.
/// </remarks>
public class ADsSchemaClass : ADsBaseObject<IADsClass>, IADsContainerObject
{
	private ADsContainer? cont;

	internal ADsSchemaClass(string pathName) : base(pathName) => Interface.GetInfo();

	internal ADsSchemaClass(IADs intf) : base((IADsClass)intf) => Interface.GetInfo();

	/// <summary>
	/// Gets or sets a boolean value that indicates if this class is Abstract or non-abstract. When TRUE, this class is an Abstract class and
	/// cannot be directly instantiated in the directory service. Abstract classes can only be used as super classes.
	/// </summary>
	/// <value><see langword="true"/> if abstract; otherwise, <see langword="false"/>.</value>
	public bool Abstract { get => Interface.Abstract; set => Interface.Abstract = value; }

	/// <summary>Gets or sets the array of ADsPath strings that indicate the super Auxiliary classes this class derives from.</summary>
	public IReadOnlyCollection<string> AuxDerivedFrom
	{
		get => Util.ToStringArray(() => Interface.AuxDerivedFrom);
		set => Interface.AuxDerivedFrom = value?.ToArray() ?? [];
	}

	/// <summary>
	/// Gets or sets a Boolean value that indicates whether or not this class is Auxiliary. When TRUE, this class is an Auxiliary class and
	/// cannot be directly instantiated in the directory service. Auxiliary classes can only be used as super classes of other Auxiliary
	/// classes or as a source of additional properties on structural classes.
	/// </summary>
	/// <value><see langword="true"/> if auxiliary; otherwise, <see langword="false"/>.</value>
	public bool Auxiliary { get => Interface.Auxiliary; set => Interface.Auxiliary = value; }

	/// <summary>Gets the collection of properties associated with this schema object.</summary>
	/// <value>The schema properties.</value>
	public ADsContainer Children
	{
		get
		{
			if (cont is null)
			{
				string pPath = Interface.Parent;
				if (!string.IsNullOrEmpty(pPath) && ADsGetObject(pPath, out IADsContainer? iCont).Succeeded)
				{
					//foreach (IADs i in iCont!)
					//	Debug.WriteLine($"{i.ADsPath}, {i.Class}"); ;
					cont = new(iCont!) { classFilter = "Property" };
				}
				else
					cont = new(new ContainerStub());
			}
			return cont;
		}
	}

	/// <summary>Gets or sets the optional provider-specific CLSID identifying the COM object that implements this class..</summary>
	public Guid? CLSID
	{
		get => TryGetProp(() => Interface.CLSID, out var r) ? new(r!) : null;
		set => Interface.CLSID = value.GetValueOrDefault().ToString("B");
	}

	/// <summary>
	/// Gets or sets a Boolean value that indicates if this class can be a container of other object classes. If this value is TRUE, you can
	/// call the get_Container method to get an array of the object classes that this class can contain.
	/// </summary>
	/// <value><see langword="true"/> if container; otherwise, <see langword="false"/>.</value>
	public bool Container { get => Interface.Container; set => Interface.Container = value; }

	/// <summary>Gets an array in which each element is the class that this class can contain.</summary>
	public IReadOnlyCollection<ADsSchemaClass> Containment => ToADsListFromName<ADsSchemaClass>(ContainmentClassNames, ClassPathFromName);

	/// <summary>Gets or sets a string array in which each element is the name of an object class that this class can contain.</summary>
	public IReadOnlyCollection<string> ContainmentClassNames
	{
		get => Util.ToStringArray(() => Interface.Containment);
		set => Interface.Containment = value?.ToArray() ?? [];
	}

	/// <summary>Gets the array of classes this class was derived from.</summary>
	public IReadOnlyCollection<ADsSchemaClass> DerivedFrom => ToADsList<ADsSchemaClass>(DerivedFromPaths);

	/// <summary>Gets or sets the array of ADsPath strings that indicate which classes this class was derived from.</summary>
	public IReadOnlyCollection<string> DerivedFromPaths
	{
		get => Util.ToStringArray(() => Interface.DerivedFrom);
		set => Interface.DerivedFrom = value?.ToArray() ?? [];
	}

	/// <summary>Gets or sets the Context ID inside HelpFileName where specific information for this class can be found.</summary>
	public int HelpFileContext
	{
		get => Interface.HelpFileContext;
		set => Interface.HelpFileContext = value;
	}

	/// <summary>Gets or sets the name of a help file that contains more information about objects of this class.</summary>
	public string HelpFileName
	{
		get => Interface.HelpFileName;
		set => Interface.HelpFileName = value;
	}

	/// <summary>Gets or sets the array of strings that lists the properties that must be set for this class to be written to storage.</summary>
	public IReadOnlyCollection<string> MandatoryProperties
	{
		get => Util.ToStringArray(() => Interface.MandatoryProperties);
		set => Interface.MandatoryProperties = value?.ToArray() ?? [];
	}

	/// <summary>Gets or sets a array of strings that lists the properties used to name attributes of this schema class.</summary>
	public IReadOnlyCollection<string> NamingProperties
	{
		get => Util.ToStringArray(() => Interface.NamingProperties);
		set => Interface.NamingProperties = value?.ToArray() ?? [];
	}

	/// <summary>
	/// Gets or sets the Provider-specific Object Identifier that defines this class. This is provided to allow schema extension, using
	/// Active Directory, in directory services that require provider-specific OIDs for classes.
	/// </summary>
	public string OID { get => Interface.OID; set => Interface.OID = value; }

	/// <summary>Gets or sets array of strings that lists the optional properties for this schema class.</summary>
	public IReadOnlyCollection<string> OptionalProperties
	{
		get => Util.ToStringArray(() => Interface.OptionalProperties);
		set => Interface.OptionalProperties = value?.ToArray() ?? [];
	}

	/// <summary>Gets or sets an array of ADsPath strings that indicate the schema classes that can contain instances of this class.</summary>
	public IReadOnlyCollection<string> PossibleSuperiorPaths
	{
		get => Util.ToStringArray(() => Interface.PossibleSuperiors);
		set => Interface.PossibleSuperiors = value?.ToArray() ?? [];
	}

	/// <summary>Gets an array of schema classes that can contain instances of this class.</summary>
	public IReadOnlyCollection<ADsSchemaClass> PossibleSuperiors => ToADsListFromName<ADsSchemaClass>(PossibleSuperiorPaths, ClassPathFromName);

	/// <summary>
	/// Gets the optional provider-specific identifier GUID that associates an interface to objects of this schema class. For example, the
	/// "User" class that supports IADsUser and PrimaryInterface is identified by IID_IADsUser. This must be in the standard string format of
	/// a GUID, as defined by COM. This GUID is the value that appears in the IADs::get_GUID property in instances of this class for
	/// providers that implement this property. Identifying a schema class by IID of the class code's primary interface enables the use of
	/// QueryInterface at run time to determine whether an object is of the desired class.
	/// </summary>
	public Guid? PrimaryInterface => TryGetProp(() => Interface.PrimaryInterface, out var r) ? new(r!) : null;

	/// <summary>Returns a collection of ADSI objects that describe additional qualifiers for this schema class.</summary>
	/// <remarks>
	/// <para>The qualifier objects are provider-specific. When supported, this method can be used to obtain extended schema data.</para>
	/// <para>This method is not currently supported by any of Microsoft providers.</para>
	/// </remarks>
	public ADsCollection<IADsObject>? Qualifiers => TryGetProp(Interface.Qualifiers, out var c) && c is not null ? new(c) : null;

	private static List<T> ToADsList<T>(IEnumerable<string> paths) where T : IADsObject =>
		paths.Select(ADsObject.GetObject).OfType<T>().ToList();

	private static List<T> ToADsListFromName<T>(IReadOnlyCollection<string> vals, Func<string, string> f) where T : IADsObject =>
		ToADsList<T>(vals.Select(f));

	private string ClassPathFromName(string name) => Parent!.Path + '/' + name;
}

/// <summary>
/// <para>
/// The <see cref="ADsSchemaProperty"/> class is designed to manage a single attribute definition for a schema class object. An attribute
/// definition specifies the minimum and maximum values of a property, its syntax, and whether the property supports multiple values. Other
/// interfaces involved in schema management include IADsClass and IADsSyntax.
/// </para>
/// <para>
/// The <see cref="ADsSchemaProperty"/> class exposes methods to describe a property by name, syntax, value ranges, and any other defined
/// attributes. A property can have multiple names associated with it, but providers must ensure that each name is unique.
/// </para>
/// <para>
/// Use the <see cref="ADsSchemaProperty"/> class to determine at run time the attribute definition of a property supported by a directory
/// service object.
/// </para>
/// <para><c>To determine the attribute definition at run time</c></para>
/// <list type="number">
/// <item>
/// <description>Get the schema class object of the ADSI object.</description>
/// </item>
/// <item>
/// <description>
/// Enumerate mandatory or optional attributes accessible from the schema class object. Skip this step if you know that the object supports
/// the attribute of your interest.
/// </description>
/// </item>
/// <item>
/// <description>Bind to the schema container of the schema class object you obtained in first step.</description>
/// </item>
/// <item>
/// <description>Retrieve the attribute definition object of the property of interest from the schema container.</description>
/// </item>
/// <item>
/// <description>Examine the attribute definition of the property. You may have to also inspect the syntax object.</description>
/// </item>
/// </list>
/// </summary>
/// <remarks>
/// <para>The <see cref="ADsSchemaProperty"/> class methods can add new attributes and property objects to a provider-specific implementation.</para>
/// </remarks>
public class ADsSchemaProperty : ADsBaseObject<IADsProperty>
{
	private ADsSchemaPropertySyntax? syntax = null;

	internal ADsSchemaProperty(IADs intf) : base((IADsProperty)intf)
	{
	}

	/// <summary>Gets or sets the upper limit of values.</summary>
	public int MaxRange { get => Interface.MaxRange; set => Interface.MaxRange = value; }

	/// <summary>Gets or sets the lower limit of values.</summary>
	public int MinRange { get => Interface.MinRange; set => Interface.MinRange = value; }

	/// <summary>Gets or sets a value indicating whether property supports single or multiple values.</summary>
	public bool MultiValued { get => Interface.MultiValued; set => Interface.MultiValued = value; }

	/// <summary>Gets or sets the Directory-specific object identifier.</summary>
	public string OID { get => Interface.OID; set => Interface.OID = value; }

	/// <summary>Returns a collection of ADSI objects that describe additional qualifiers of this property.</summary>
	/// <remarks>
	/// <para>The qualifier objects are provider-specific. When supported, this method can be used to obtain extended schema data.</para>
	/// <para>This method is not currently supported by any of the providers supplied by Microsoft.</para>
	/// </remarks>
	public ADsCollection<IADsObject>? Qualifiers => TryGetProp(Interface.Qualifiers, out var c) && c is not null ? new(c) : null;

	/// <summary>Gets or sets the relative path of syntax object.</summary>
	public ADsSchemaPropertySyntax Syntax => syntax ??= new(GetSyntaxObj());

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private IADs GetSyntaxObj()
	{
		ADsGetObject($"{Parent!.Path}/{Interface.Syntax}", out IADs? pSynBad).ThrowIfFailed();
		return pSynBad!;
	}
}

/// <summary>
/// <para>
/// The <see cref="ADsSchemaPropertySyntax"/> class specifies methods to identify and modify the available Automation data types used to
/// represent its data. ADSI defines a standard set of syntax objects that can be used uniformly across multiple directory service implementations.
/// </para>
/// <para>Use the <see cref="ADsSchemaPropertySyntax"/> class to process the property values of any instance of ADSI schema class object.</para>
/// </summary>
public class ADsSchemaPropertySyntax : ADsBaseObject<IADs>
{
	private readonly IADsSyntax isyntax;

	internal ADsSchemaPropertySyntax(IADs intf) : base(intf) => isyntax = (IADsSyntax)intf;

	/// <summary>Retrieves and sets a value of the VT_xxx constant for the Automation data type that represents this syntax.</summary>
	public Ole32.VARTYPE OleAutoDataType
	{
		get => isyntax is not null && TryGetProp(() => isyntax.OleAutoDataType, out int? r) ? (Ole32.VARTYPE)r! : Ole32.VARTYPE.VT_EMPTY;
		set => isyntax.OleAutoDataType = isyntax is not null ? (int)value : throw new NotImplementedException();
	}
}

/// <summary>
/// Designed to maintain data about system services running on a host computer. Examples of such services include "FAX" for Microsoft Fax
/// Service, "RemoteAccess" for Routing and RemoteAccess Service, and "seclogon" for Secondary Logon Service. Examples of the data about any
/// system service include the path to the executable file on the host computer, the type of the service, other services or load group
/// required to run a particular service, and others. <c>ADsService</c> exposes several properties to represent such data.
/// </summary>
/// <remarks>
/// <para>
/// The system services are published in the underlying directory. Some may be running, others may not. To verify the status or to operate on
/// any of the services, use the properties and methods of the Operations property.
/// </para>
/// <para>
/// File service is a special case of the system service. The ADsFileService and ADsFileServiceOperations classes support additional features
/// unique to file services.
/// </para>
/// </remarks>
public class ADsService : ADsBaseObject<IADsService>
{
	private ADsServiceOperations? ops;

	internal ADsService(IADs intf) : base((IADsService)intf)
	{
	}

	/// <summary>Gets the <see cref="ADsServiceOperations"/> object associated with this instance.</summary>
	public ADsServiceOperations Operations => ops ??= new(Interface);
}

/// <summary>
/// <para>
/// Designed to manage system services installed on a computer. You can use this interface to start, pause, and stop a system service, change
/// the password, and examine the status of a given service across a network.
/// </para>
/// <para>
/// Of the system services and their operations, file service and file service operations are a special case. They are represented and
/// managed by ADsFileService and ADsFileServiceOperations.
/// </para>
/// </summary>
public class ADsServiceOperations : ADsBaseObject<IADsServiceOperations>
{
	internal ADsServiceOperations(IADsService o) : base((IADsServiceOperations)o)
	{
	}

	/// <summary>Gets the status of service.</summary>
	public ADS_SERVICE_STATUS Status => Interface.Status;

	/// <summary>Resumes a service operation paused by the Pause method.</summary>
	public void Continue() => Interface.Continue();

	/// <summary>Pauses a service started with the Start method.</summary>
	public void Pause() => Interface.Pause();

	/// <summary>
	/// Sets the password for the account used by the service manager. This method is called when the security context for this service is created.
	/// </summary>
	/// <param name="newPassword">The string to be stored as the new password.</param>
	/// <remarks>
	/// <para>The property <c>ServiceAccountName</c> identifies the account for which this password is to be set.</para>
	/// </remarks>
	public void SetPassword(string newPassword) => Interface.SetPassword(newPassword);

	/// <summary>Starts a network service.</summary>
	public void Start() => Interface.Start();

	/// <summary>Stops a currently active network service.</summary>
	public void Stop() => Interface.Stop();
}

/// <summary>Designed to represent an active session for file service across a network.</summary>
/// <remarks>
/// <para>
/// When a remote user opens resources on a target computer, an active session is established between the remote user and that computer. Many
/// resources can be opened in a single active session. ADSI represents this process with a session object that implements this interface.
/// </para>
/// <para>
/// Call the methods of this interface to examine session-specific data, for example, who is using the session, which computer is used, and
/// the time elapsed for the current session.
/// </para>
/// <para>Sessions are managed by the file service. To obtain session objects, first bind to this service ("LanmanServer" or "FPNW").</para>
/// </remarks>
public class ADsSession : ADsBaseObject<IADsSession>
{
	internal ADsSession(IADs i) : base((IADsSession)i)
	{
	}
}

/// <summary>
/// <para>
/// Designed to represent and manage an end-user account on a network. Call the methods of this interface to access and manipulate end-user
/// account data. Such data includes names of the user, telephone numbers, job title, and so on. This interface supports features for
/// determining the group association of the user, and for setting or changing the password.
/// </para>
/// <para>To bind to a domain user through a WinNT provider, use the domain name as part of the ADsPath.</para>
/// <para>Similarly, use the computer name as part of the ADsPath to bind to a local user.</para>
/// <para>In Active Directory, domain users reside in the directory.</para>
/// <para>
/// However, local accounts reside in the local SAM database and the LDAP provider does not communicate with the local database. Thus, to
/// bind to a local user, you must go through a WinNT provider.
/// </para>
/// </summary>
/// <remarks>
/// <para>As with any other ADSI object, the container object creates a Windows user account object. First, bind to a container object.</para>
/// <para>With WinNT, you do not have to specify any additional attributes when creating a user.</para>
/// <para>In this case, a domain user is created with the following default values.</para>
/// <list type="table">
/// <listheader>
/// <description>Property</description>
/// <description>Value</description>
/// </listheader>
/// <item>
/// <description><c>Full Name</c></description>
/// <description>SAM Account Name (such as jeffsmith)</description>
/// </item>
/// <item>
/// <description><c>Password</c></description>
/// <description>Empty</description>
/// </item>
/// <item>
/// <description><c>User Must Change Password</c></description>
/// <description><c>TRUE</c></description>
/// </item>
/// <item>
/// <description><c>User Cannot Change Password</c></description>
/// <description><c>FALSE</c></description>
/// </item>
/// <item>
/// <description><c>Password Never Expires</c></description>
/// <description><c>FALSE</c></description>
/// </item>
/// <item>
/// <description><c>Account Disabled</c></description>
/// <description><c>FALSE</c></description>
/// </item>
/// <item>
/// <description><c>Group</c></description>
/// <description>Domain User</description>
/// </item>
/// <item>
/// <description><c>Profile</c></description>
/// <description>Empty</description>
/// </item>
/// <item>
/// <description><c>Account Never Expires</c></description>
/// <description><c>TRUE</c></description>
/// </item>
/// </list>
/// <para></para>
/// <para>To create a local user, bind to a target computer.</para>
/// <para>
/// Newly created local users will have the same default properties as the domain user. The group membership, however, will be "users",
/// instead of "domain user".
/// </para>
/// </remarks>
public class ADsUser : ADsBaseObject<IADsUser>
{
	private ADsMembership? groups;

	internal ADsUser(IADs intf) : base((IADsUser)intf)
	{
	}

	/// <summary>Obtains a collection of the ADSI group objects to which this user belongs.</summary>
	public ADsMembership Groups => groups ??= new(Interface.Groups(), Interface);

	/// <summary>Changes the user password from the specified old value to a new value.</summary>
	/// <param name="oldPassword">A string that contains the current password.</param>
	/// <param name="newPassword">A string that contains the new password.</param>
	/// <remarks>
	/// <para>
	/// <c>ChangePassword</c> functions similarly to SetPassword in that it will use one of three methods to try to change the password.
	/// Initially, the LDAP provider will attempt an LDAP change password operation, if a secure SSL connection to the server is established.
	/// If this attempt fails, the LDAP provider will next try to use Kerberos (see <c>SetPassword</c> for some problems that may result on
	/// Windows with cross-forest authentication), and if this also fails, it will finally call the Active Directory specific network
	/// management API, NetUserChangePassword.
	/// </para>
	/// <para>
	/// In Active Directory, the caller must have the Change Password extended control access right to change the password with this method.
	/// </para>
	/// </remarks>
	public void ChangePassword(string oldPassword, string newPassword) => Interface.ChangePassword(oldPassword, newPassword);

	/// <summary>
	/// <para>
	/// Sets the user password to a specified value. For the LDAP provider, the user account must have been created and stored in the
	/// underlying directory using <see cref="ADsPropertyCache.Save"/> before <c>SetPassword</c> is called.
	/// </para>
	/// <para>
	/// The WinNT provider, however, enables you to set the password on a newly created user object prior to calling SetInfo. This ensures
	/// that you create passwords that comply with the system password policy before you create the user account.
	/// </para>
	/// </summary>
	/// <param name="newPassword">A string that contains the new password.</param>
	/// <remarks>
	/// <para>
	/// The LDAP provider for Active Directory uses one of three processes to set the password; third-party LDAP directories such as iPlanet
	/// do not use this password authentication process. The method may vary according to the network configuration. Attempts to set the
	/// password occur in the following order:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// First, the LDAP provider attempts to use LDAP over a 128-bit SSL connection. For LDAP SSL to operate successfully, the LDAP server
	/// must have the appropriate server authentication certificate installed and the clients running the ADSI code must trust the authority
	/// that issued those certificates. Both the server and the client must support 128-bit encryption.
	/// </description>
	/// </item>
	/// <item>
	/// <description>Second, if the SSL connection is unsuccessful, the LDAP provider attempts to use Kerberos.</description>
	/// </item>
	/// <item>
	/// <description>
	/// Third, if Kerberos is unsuccessful, the LDAP provider attempts a NetUserSetInfo API call. In previous releases, ADSI called
	/// <c>NetUserSetInfo</c> in the security context in which the thread was running, and not the security context specified in the call to
	/// IADsOpenDSObject::OpenDSObject or ADsOpenObject. In later releases, this was changed so that the ADSI LDAP provider would impersonate
	/// the user specified in the <c>OpenDSObject</c> call when it calls NetUserSetInfo.
	/// </description>
	/// </item>
	/// </list>
	/// <para>In Active Directory, the caller must have the Reset Password extended control access right to set the password with this method.</para>
	/// </remarks>
	public void SetPassword(string newPassword) => Interface.SetPassword(newPassword);
}

/// <summary>
/// <para>
/// Provides clients with direct access to directory service objects. The class enables access by means of a direct over-the-wire protocol,
/// rather than through the ADSI attribute cache. Using the over-the-wire protocol optimizes performance. With <c>DirectoryObject</c>, a
/// client can get, or set, any number of object attributes with one method call. Unlike the corresponding Automation methods, which are
/// invoked in batch, those of <c>DirectoryObject</c> are executed when they are called. <c>DirectoryObject</c> performs no attribute caching.
/// </para>
/// <para>Of the ADSI system-supplied providers, only the LDAP provider supports this interface.</para>
/// </summary>
public class DirectoryObject
{
	private readonly IDirectoryObject? dirObj;

	/// <summary>Initializes a new instance of the <see cref="DirectoryObject"/> class.</summary>
	/// <param name="ldapPath">The LDAP path.</param>
	public DirectoryObject(string ldapPath) => ADsGetObject(ldapPath, out dirObj).ThrowIfFailed();

	/// <summary>
	/// Gets an ADS_OBJECT_INFO structure that contains data regarding the identity and location of a directory service object.
	/// </summary>
	/// <returns>An ADS_OBJECT_INFO structure that contains data regarding the requested directory service object.</returns>
	public ADS_OBJECT_INFO ObjectInfo => dirObj!.GetObjectInformation() ?? throw new InvalidOperationException();

	/// <summary>
	/// Retrieves one or more specified attributes of the directory service object.
	/// </summary>
	/// <param name="attributeNames">
	/// <para>Specifies an array of names of the requested attributes.</para>
	/// <para>To request all of the object's attributes, set the first value to "*" or <see langword="null"/>.</para>
	/// </param>
	/// <returns>
	/// An array of ADS_ATTR_INFO structures that contain the requested attribute values. If no attributes could be obtained from the
	/// directory service object, the returned array is empty.
	/// </returns>
	/// <remarks>
	/// <para>The order of attributes returned in <c>ppAttributeEntries</c> is not necessarily the same as requested in <c>pAttributeNames</c>.</para>
	/// <para>
	/// This method attempts to read the schema definition of the requested attributes so it can return the attribute values in the
	/// appropriate format in the ADSVALUE structures contained in the ADS_ATTR_INFO structures. However, <c>GetObjectAttributes</c> can
	/// succeed even when the schema definition is not available, in which case the <c>dwADsType</c> member of the <c>ADS_ATTR_INFO</c>
	/// structure returns ADSTYPE_PROV_SPECIFIC and the value is returned as a <see cref="byte"/> array. When you process the results of a
	/// <c>GetObjectAttributes</c> call, verify <c>dwADsType</c> to ensure that the data was returned in the expected format.
	/// </para>
	/// </remarks>
	public ADS_ATTR_INFO[] GetAttributes(params string[] attributeNames) => dirObj!.GetObjectAttributes(attributeNames);

	/// <summary>
	/// Modifies data in one or more specified object attributes defined in the ADS_ATTR_INFO structure.
	/// </summary>
	/// <param name="pAttributeEntries">
	/// Provides an sequence of attributes to be modified. Each attribute contains the name of the attribute, the operation to perform, and
	/// the attribute value, if applicable. For more information, see the ADS_ATTR_INFO structure.
	/// </param>
	/// <returns>The number of attributes modified by the <c>SetObjectAttributes</c> method.</returns>
	/// <remarks>
	/// <para>
	/// In Active Directory (LDAP provider), this method is a transacted call. The attributes are either all committed or discarded. Other
	/// directory providers may not transact the call.
	/// </para>
	/// <para>
	/// Active Directory does not allow duplicate values on a multi-valued attribute. However, if you call <c>SetObjectAttributes</c> to
	/// append a duplicate value to a multi-valued attribute of an Active Directory object, the <c>SetObjectAttributes</c> call succeeds but
	/// the duplicate value is ignored.
	/// </para>
	/// <para>
	/// Similarly, if you use <c>SetObjectAttributes</c> to delete one or more values from a multi-valued property of an Active Directory
	/// object, the operation succeeds even if any or all of the specified values are not set for the property.
	/// </para>
	/// </remarks>
	public uint SetObjectAttributes(params ADS_ATTR_INFO[] pAttributeEntries) => dirObj!.SetObjectAttributes(pAttributeEntries);
}

/// <summary>
/// <para>Provides a low overhead method that clients can use to perform queries in the underlying directory.</para>
/// <para>Of the ADSI system-supplied providers, only the LDAP provider supports this interface.</para>
/// </summary>
public class DirectorySearch
{
	private readonly IDirectorySearch? iSearch;

	/// <summary>Initializes a new instance of the <see cref="DirectorySearch"/> class.</summary>
	/// <param name="ldapPath">The LDAP path.</param>
	public DirectorySearch(string ldapPath) => ADsGetObject(ldapPath, out iSearch).ThrowIfFailed();

	/// <summary>
	/// Specifies the search preferences for obtaining data in a search.
	/// </summary>
	public IDictionary<ADS_SEARCHPREF, object> Preferences { get; } = new Dictionary<ADS_SEARCHPREF, object>();

	/// <summary>
	/// Executes a search and passes the results to the caller.
	/// </summary>
	/// <param name="filter">A search filter string in LDAP format, such as "(objectClass=user)".</param>
	/// <param name="attributes">An array of attribute names for which data is requested.</param>
	/// <returns>The search results.</returns>
	/// <remarks>
	/// When the search filter ( <paramref name="filter"/>) contains an attribute of <c>ADS_UTC_TIME</c> type, it value must be of the
	/// "yymmddhhmmssZ" format where "y", "m", "d", "h", "m" and "s" stand for year, month, day, hour, minute, and second, respectively. In
	/// this format, for example, "10:20:00 May 13, 1999" becomes "990513102000Z". The final letter "Z" is the required syntax and indicated
	/// Zulu Time or Universal Coordinated Time.
	/// </remarks>
	public SearchResult Search(string filter, string[] attributes)
	{
		// Set search preferences
		if (Preferences.Count > 0)
			iSearch!.SetSearchPreference(Preferences.Select(kv => new ADS_SEARCHPREF_INFO(kv.Key, kv.Value)).ToArray());

		// Execute the search
		var h = iSearch!.ExecuteSearch(filter, attributes);

		return new SearchResult(iSearch!, h);
	}

	/// <summary>
	/// A navigatable set of results from the search initiated by the <see cref="Search"/> method.
	/// </summary>
	public class SearchResult : IEnumerator<SearchRow>
	{
		internal readonly IDirectorySearch iSearch;
		internal readonly SafeADS_SEARCH_HANDLE handle;
		private List<string>? columns;

		internal SearchResult(IDirectorySearch iSearch, SafeADS_SEARCH_HANDLE handle)
		{
			this.iSearch = iSearch;
			this.handle = handle;
		}

		/// <summary>
		/// Abandons a search initiated by an earlier call to the <see cref="Search"/> method.
		/// </summary>
		/// <remarks>
		/// This method may be used if the Page_Size or Asynchronous options can be specified through <see cref="Preferences"/> before the
		/// search is executed.
		/// </remarks>
		public void Abandon() => iSearch.AbandonSearch(handle);

		/// <summary>Gets the ordered list of column names returned by the executed search.</summary>
		/// <value>The column names.</value>
		public IReadOnlyList<string> ColumnNames => columns ??= iSearch.GetColumnNames(handle);

		/// <inheritdoc/>
		public SearchRow Current => new(this);

		object IEnumerator.Current => Current;

		void IDisposable.Dispose()
		{
			handle.Dispose();
			GC.SuppressFinalize(this);
		}

		/// <inheritdoc/>
		public bool MoveNext() => iSearch.GetNextRow(handle) == HRESULT.S_OK;

		/// <summary>
		/// Gets the previous row of the search result. If the provider does not provide cursor support, it should return <see langword="false"/>.
		/// </summary>
		/// <returns>
		/// <see langword="true"/> if the enumerator was moved to the previous position, <see langword="false"/> if the enumerator has moved
		/// before the beginning of the enumeration.
		/// </returns>
		/// <remarks>
		/// When the <c>ADS_SEARCHPREF_CACHE_RESULTS</c> flag is not set, only forward scrolling is permitted, because the client might not
		/// cache all the query results.
		/// </remarks>
		public bool MovePrevious() => iSearch.GetPreviousRow(handle) == HRESULT.S_OK;

		/// <inheritdoc/>
		public void Reset() => iSearch.GetFirstRow(handle);
	}

	/// <summary>A row of the search result.</summary>
	/// <returns>A search result row that provides access to all column values</returns>
	public class SearchRow : IEnumerable<object?[]>
	{
		private readonly SearchResult result;

		internal SearchRow(SearchResult result) => this.result = result;

		/// <summary>
		/// Gets data from a named column of the search result.
		/// </summary>
		/// <param name="columnName">Provides the name of the column for which data is requested.</param>
		/// <value>The <see cref="object"/>[].</value>
		/// <returns>The column value from the current row of the search result.</returns>
		/// <remarks>
		/// This property tries to read the schema definition of the requested attribute so it can return the attribute values in the
		/// appropriate format. However, this property can succeed even when the schema definition is not available, in which case the
		/// value is returned as a byte array.
		/// </remarks>
		public object?[] this[string columnName] => result.iSearch.GetColumn(result.handle, columnName)?.pADsValues ?? [];

		/// <inheritdoc/>
		public IEnumerator<object?[]> GetEnumerator()
		{
			foreach (var col in result.ColumnNames)
				yield return this[col];
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}

internal static class Util
{
	/// <summary>
	/// Gets a value and compensates for exceptions, returning the default value for <typeparamref name="T"/> when an exception is thrown.
	/// </summary>
	/// <typeparam name="T">The type of the value to return.</typeparam>
	/// <param name="f">A lambda function or delegate that attempts to return a value.</param>
	/// <returns>The value from <paramref name="f"/>, or the default value of <typeparamref name="T"/> on failure.</returns>
	public static T? GetProp<T>(Func<T> f)
	{
		try { return f(); }
		catch { return default; }
	}

	public static string[] ToStringArray(Func<object?> f)
	{
		if (!TryGetProp(f, out var o))
			o = null;
		return o switch
		{
			string s => [s],
			string[] sa => sa,
			object[] oa => Array.ConvertAll(oa, i => i?.ToString() ?? ""),
			_ => []
		};
	}

	/// <summary>
	/// Tries to get a value and compensates for exceptions, returning the default value for <typeparamref name="T"/> when an exception is thrown.
	/// </summary>
	/// <typeparam name="T">The type of the value to return.</typeparam>
	/// <param name="f">A lambda function or delegate that attempts to return a value.</param>
	/// <param name="ret">The value from <paramref name="f"/>, or the default value of <typeparamref name="T"/> on failure.</param>
	/// <returns><see langword="true"/> if the value was successfully retrieved; otherwise <see langword="false"/>.</returns>
	public static bool TryGetProp<T>(Func<T> f, out T? ret)
	{
		try { ret = f(); return true; }
		catch { ret = default; return false; }
	}
}