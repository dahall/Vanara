using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Vanara.Windows.Shell;

/// <summary></summary>
/// <seealso cref="System.IComparable{T}"/>
/// <seealso cref="System.IDisposable"/>
/// <seealso cref="System.IEquatable{T}"/>
/// <seealso cref="System.IEquatable{T}"/>
/// <seealso cref="System.ComponentModel.INotifyPropertyChanged"/>
public abstract class ComObjWrapper<TObj, TComType> : IDisposable, IEquatable<TComType>, INotifyPropertyChanged where TObj : ComObjWrapper<TObj, TComType> where TComType : class
{
	/// <summary>The internal reference to the COM object.</summary>
	protected TComType iObj;

	/// <summary>Initializes a new instance of the <see cref="ComObjWrapper{TObj, TComType}"/> class.</summary>
	/// <param name="baseInterface">The base interface.</param>
	protected ComObjWrapper(TComType baseInterface) => iObj = baseInterface ?? throw new ArgumentNullException(nameof(baseInterface));

	/// <summary>Occurs when a property value changes.</summary>
	public virtual event PropertyChangedEventHandler PropertyChanged;

	/// <summary>Gets the COM interface supporting this type.</summary>
	/// <value>The COM interface.</value>
	public virtual TComType ComInterface => iObj;

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public virtual void Dispose()
	{
		iObj = null;
	}

	/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
	/// <returns><see langword="true"/> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <see langword="false"/>.</returns>
	public override bool Equals(object obj) => ReferenceEquals(this, obj) || (obj is TObj view ? Equals(view) : obj is TComType com && Equals(com));

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public abstract bool Equals(TComType other);

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public virtual bool Equals(TObj other) => Equals(other.iObj);

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public abstract override int GetHashCode();

	/// <summary>Called when a property's value has changed.</summary>
	/// <param name="propName">Name of the property.</param>
	protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
}