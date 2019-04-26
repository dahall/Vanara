using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.InteropServices
{
	[Flags]
	public enum MarshalBias
	{
		ToNative = 0x01,
		ToManaged = 0x02,
		Bidirectional = 0x03,
	}

	public enum MarshalDirective
	{
		Normal,
		Ignore,
		AsReference,
		AsArray,
		AsRefArray,
		AsAlternateType,
		AsNullTermStringArray,
	}

	/// <summary>
	/// Contains methods to serialize and deserialize structures from memory. This handles standard structures and those attributed with <see cref="MarshaledStructAttribute"/>.
	/// </summary>
	public static class MarshaledStructSerializer
	{
		private const System.Reflection.BindingFlags stdBind = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Instance;

		public static T Deserialize<T>(SafeCoTaskMemHandle hmem) => 
			(T)Deserialize(hmem.DangerousGetHandle(), hmem.Size, typeof(T));

		public static T Deserialize<T>(IntPtr ptr, int allocatedSize) => 
			(T)Deserialize(ptr, allocatedSize, typeof(T));

		public static object Deserialize(SafeCoTaskMemHandle hmem, Type outputType) =>
			Deserialize(hmem.DangerousGetHandle(), hmem.Size, outputType);

		public static object Deserialize(IntPtr ptr, int allocatedSize, Type outputType)
		{
			if (outputType is null) throw new ArgumentNullException(nameof(outputType));
			if (ptr == IntPtr.Zero) return default;

			// If this doesn't have our attribute, use standard marshaling.
			var attr = outputType.GetCustomAttributes<MarshaledStructAttribute>().FirstOrDefault();
			if (attr is null)
				return ptr.Convert((uint)allocatedSize, outputType);

			if (!attr.Bias.IsFlagSet(MarshalBias.ToManaged))
				throw new ArgumentException("The supplied object is not configured to be marshaled to managed memory. See the MarshaledStructAttribute.Bias value.");

			// Process each field and read it from the pointer
			var processed = new Dictionary<string, object>();
			var waiting = new Dictionary<string, (System.Reflection.FieldInfo, long)>();
			var val = Activator.CreateInstance(outputType);
			using (var stream = new NativeMemoryStream(ptr, allocatedSize))
			{
				foreach (var fi in outputType.GetFields(stdBind))
				{
					var ft = fi.FieldType;
					var elemType = ft.FindElementType();
					var fattr = fi.GetCustomAttributes<MarshalDirectiveAttribute>().FirstOrDefault();

					// Get size info
					var fsize = int.MaxValue;
					if (fattr?.SizeConst > 0)
						fsize = fattr.SizeConst;
					else if (fattr?.SizeField != null)
					{
						var szField = outputType.GetField(fattr.SizeField, stdBind);
						if (szField is null)
							throw new InvalidOperationException($"The SizeField value '{fattr.SizeField}' does not specify a valid field in this structure.");
						if (processed.TryGetValue(szField.Name, out var szFieldVal))
						{
							var iszFieldVal = Convert.ToInt32(szFieldVal);
							if (iszFieldVal > 0)
								fsize = iszFieldVal;
						}
						else
						{
							if (true) // TODO: See if there are directives that are just pointers which can be processed later.
								throw new InvalidOperationException($"The dependency of {fi.Name} on {szField.Name} for sizing cannot be processed. The sizing field must appear before in-line arrays in the structure.");
							waiting.Add(szField.Name, (fi, stream.Position));
							stream.Read<IntPtr>();
							break;
						}
					}

					// Handle cases where directive is omitted or MarshalDirectiveAttibute not set.
					var dir = fattr?.Value ?? MarshalDirective.Normal;
					if (dir == MarshalDirective.Normal)
					{
						if (ft == typeof(string))
							dir = fattr?.SizeConst > 0 ? MarshalDirective.AsArray : MarshalDirective.AsReference;
						else if (fattr?.AlternateType != null)
							dir = MarshalDirective.AsAlternateType;
						else if (!(elemType is null))
							dir = elemType == typeof(string) ? MarshalDirective.AsRefArray : MarshalDirective.AsArray;
					}

					switch (dir)
					{
						case MarshalDirective.Normal:
							SetValue(stream.Read(ft));
							break;
						case MarshalDirective.Ignore:
							break;
						case MarshalDirective.AsReference:
							SetValue(ReadRefType(ft));
							break;
						case MarshalDirective.AsArray:
							if (ft == typeof(string))
							{
								SetValue(stream.Read(ft));
							}
							else if (!(elemType is null))
							{
								SetValue(stream.ReadArray(elemType, fsize, false));
							}
							break;
						case MarshalDirective.AsRefArray:
							break;
						case MarshalDirective.AsAlternateType:
							if (fattr is null || fattr.AlternateType is null)
								throw new InvalidOperationException("If the directive is set to MarshalDirective.AsAlternateType, the MarshalDirectiveAttribute.AlternateType parameter must contain a valid type.");
							SetValue(Convert.ChangeType(stream.Read(fattr.AlternateType), ft));
							break;
						case MarshalDirective.AsNullTermStringArray:
							break;
						default:
							break;
					}

					void SetValue(object v)
					{
						fi.SetValue(val, v);
						processed.Add(fi.Name, v);
					}
				}

				object ReadRefType(Type t)
				{
					var p = stream.Read<IntPtr>();
					var diff = p.ToInt64() - ptr.ToInt64();
					var pos = stream.Position;
					stream.Seek(diff, System.IO.SeekOrigin.Begin);
					var ret = stream.Read(t);
					stream.Seek(pos, System.IO.SeekOrigin.Begin);
					return ret;
				}
			}
			return val;
		}


		public static IntPtr Serialize(object structure, out int allocationSize)
		{
			var mem = Serialize(structure);
			allocationSize = mem.Size;
			mem.SetHandleAsInvalid();
			return mem.DangerousGetHandle();
		}

		public static SafeCoTaskMemHandle Serialize(object structure)
		{
			if (structure is null) return SafeCoTaskMemHandle.Null;

			// If this doesn't have our attribute, use standard marshaling.
			var attr = structure.GetType().GetCustomAttributes<MarshaledStructAttribute>().FirstOrDefault();
			if (attr is null)
				return SafeCoTaskMemHandle.CreateFromStructure(structure);

			if (!attr.Bias.IsFlagSet(MarshalBias.ToNative))
				throw new ArgumentException("The supplied object is not configured to be marshaled to native memory. See the MarshaledStructAttribute.Bias value.");

			// Process each field and write it into memory
			var allocator = new SafeCoTaskMemHandle(attr.Size > 0 ? attr.Size : 256);
			using (var stream = new NativeMemoryStream(allocator) { CharSet = attr.CharSet })
			{
				foreach (var fi in structure.GetType().GetFields(stdBind))
				{
					var val = fi.GetValue(structure);
					var fattr = fi.GetCustomAttributes<MarshalDirectiveAttribute>().FirstOrDefault();

					// Get size info
					var fsize = int.MaxValue;
					if (fattr?.SizeConst > 0)
						fsize = fattr.SizeConst;
					else if (fattr?.SizeField != null)
					{
						var szFieldVal = structure.GetType().GetField(fattr.SizeField, stdBind)?.GetValue(structure);
						if (szFieldVal != null && szFieldVal is IConvertible c && c.ToInt32(null) > 0)
							fsize = c.ToInt32(null);
					}

					// Handle cases where directive is omitted or MarshalDirectiveAttibute not set.
					var dir = fattr?.Value ?? MarshalDirective.Normal;
					if (dir == MarshalDirective.Normal)
					{
						if (val is string)
							dir = fattr?.SizeConst > 0 ? MarshalDirective.AsArray : MarshalDirective.AsReference;
						else if (fattr?.AlternateType != null)
							dir = MarshalDirective.AsAlternateType;
						else if (val is IEnumerable)
							dir = val.GetType().FindElementType() == typeof(string) ? MarshalDirective.AsRefArray : MarshalDirective.AsArray;
					}

					switch (dir)
					{
						case MarshalDirective.Normal:
							stream.WriteObject(val);
							break;
						case MarshalDirective.AsReference:
							stream.WriteReferenceObject(val);
							break;
						case MarshalDirective.AsArray:
							if (val is string s)
							{
								if (s.Length >= fsize)
									s = s.Substring(0, fsize - 1);
								stream.Write(s, fattr.CharSet != CharSet.None && fattr.CharSet != attr.CharSet ? fattr.CharSet : attr.CharSet);
							}
							else if (val is IEnumerable ie)
							{
								var max = fsize;
								foreach (var oval in ie)
								{
									if (max-- > 0)
										stream.WriteObject(oval);
								}
							}
							else
								throw new InvalidOperationException("The only types supported by MarshalDirective.AsArray are string and IEnumerable.");
							break;
						case MarshalDirective.AsRefArray:
							if (val is IEnumerable ire)
							{
								var max = fsize;
								foreach (var oval in ire)
								{
									if (max-- > 0)
										stream.WriteReferenceObject(oval);
								}
							}
							else
								throw new InvalidOperationException("The only type supported by MarshalDirective.AsRefArray is IEnumerable.");
							break;
						case MarshalDirective.AsAlternateType:
							stream.WriteObject(Convert.ChangeType(val, fattr?.AlternateType ?? throw new InvalidOperationException("The MarshalDirectiveAttribute.AlternateType value must be set when using MarshalDirective.AsAlternateType.")));
							break;
						case MarshalDirective.AsNullTermStringArray:
							if (!(val is IEnumerable<string> ies)) throw new InvalidOperationException("The only type supported by MarshalDirective.AsNullTermStringArray is IEnumerable<string>.");
							stream.Write(ies);
							break;
						default:
							break;
					}
				}
				stream.Flush();
				allocator.Size = (int)stream.Length;
			}
			return allocator;
		}
	}

	[System.AttributeUsage(System.AttributeTargets.Field, Inherited = false)]
	public class MarshalDirectiveAttribute : Attribute
	{
		public Type AlternateType;

		public CharSet CharSet = CharSet.None;

		public int DeclaredSize;

		public int SizeConst;

		public string SizeField;

		//public string Union;

		public MarshalDirectiveAttribute() : this(MarshalDirective.Normal)
		{
		}

		public MarshalDirectiveAttribute(MarshalDirective directive)
		{
			Value = directive;
		}

		public MarshalDirective Value { get; set; }
	}

	[System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct, Inherited = false)]
	public class MarshaledStructAttribute : Attribute
	{
		public MarshalBias Bias = MarshalBias.Bidirectional;

		public CharSet CharSet = CharSet.Auto;

		public int Pack = 4;

		public int Size;

		public Type Type { get; set; }

		public MarshaledStructAttribute()
		{
		}

		public MarshaledStructAttribute(Type outputType)
		{
			Type = outputType;
		}
	}

	/// <summary>
	/// Advanced marshaler for structures, using CoTaskMem as underlying default memory allocator, that handles attribute decorated structures.
	/// </summary>
	public class StructMarshaler : ICustomMarshaler
	{
		private readonly IMemoryMethods mem;

		private StructMarshaler(string cookie)
		{
			var t = typeof(CoTaskMemoryMethods);
			if (!string.IsNullOrEmpty(cookie))
			{
				var st = Type.GetType(cookie, false, true);
				if (st is null || !typeof(IMemoryMethods).IsAssignableFrom(st))
					throw new InvalidOperationException("Invalid string in cookie. It must be a string identifier of a type that derives from Vanara.InteropServices.IMemoryMethods.");
				t = st;
			}
			mem = (IMemoryMethods)Activator.CreateInstance(t);
		}

		/// <summary>Gets the instance.</summary>
		/// <param name="cookie">The cookie.</param>
		/// <returns>A new instance of this class.</returns>
		public static ICustomMarshaler GetInstance(string cookie) => new StructMarshaler(cookie);

		/// <summary>Performs necessary cleanup of the managed data when it is no longer needed.</summary>
		/// <param name="ManagedObj">The managed object to be destroyed.</param>
		public void CleanUpManagedData(object ManagedObj)
		{
		}

		/// <summary>Performs necessary cleanup of the unmanaged data when it is no longer needed.</summary>
		/// <param name="pNativeData">A pointer to the unmanaged data to be destroyed.</param>
		public void CleanUpNativeData(IntPtr pNativeData) => mem.FreeMem(pNativeData);

		/// <summary>Returns the size of the native data to be marshaled.</summary>
		/// <returns>The size in bytes of the native data.</returns>
		public int GetNativeDataSize() => IntPtr.Size;

		/// <summary>Converts the managed data to unmanaged data.</summary>
		/// <param name="ManagedObj">The managed object to be converted.</param>
		/// <returns>Returns the COM view of the managed object.</returns>
		public IntPtr MarshalManagedToNative(object ManagedObj) => MarshaledStructSerializer.Serialize(ManagedObj, out _);

		/// <summary>Converts the unmanaged data to managed data.</summary>
		/// <param name="pNativeData">A pointer to the unmanaged data to be wrapped.</param>
		/// <returns>Returns the managed view of the COM data.</returns>
		public object MarshalNativeToManaged(IntPtr pNativeData) => MarshaledStructSerializer.Deserialize(pNativeData, -1, this.GetType());
	}
}