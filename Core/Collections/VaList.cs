using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;

namespace Vanara.Collections
{
	public class VaList : IDisposable
	{
		//protected byte[] buffer;
		protected readonly List<GCHandle> handles = new List<GCHandle>();

		public VaList(params object[] args) : this(CharSet.Auto, args)
		{
		}

		public VaList(CharSet charSet, params object[] args)
		{
			if (args == null) throw new ArgumentNullException(nameof(args));

			var ptrs = new IntPtr[args.Length];
			handles.Add(GCHandle.Alloc(ptrs, GCHandleType.Pinned));

			var enc = StringHelper.GetCharSize(charSet) == 1 ? Encoding.ASCII : Encoding.Unicode;
			for (var i = 0; i < args.Length; i++)
			{
				var arg = args[i];
				switch (arg)
				{
					case null:
					case DBNull n:
						break;
					case char c:
						ptrs[i] = (IntPtr) BitConverter.ToUInt16(enc.GetBytes(new[] {c}), 0);
						break;
					case string s:
						var bytes = s.GetBytesNullTerm(true, charSet);
						var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
						handles.Add(handle);
						ptrs[i] = handle.AddrOfPinnedObject();
						break;
					case IntPtr p:
						ptrs[i] = p;
						break;
					case UIntPtr p:
						ptrs[i] = IntPtr.Size == 4 ? (IntPtr) Convert.ToInt32(p.ToUInt32()) : (IntPtr) Convert.ToInt64(p.ToUInt64());
						break;
					default:
						if (Marshal.SizeOf(arg) <= IntPtr.Size && arg.GetType().IsPrimitive)
						{
							ptrs[i] = IntPtr.Size == 4 ? (IntPtr) Convert.ToInt32(arg) : (IntPtr) Convert.ToInt64(arg);
						}
						else if (!arg.GetType().IsValueType)
						{
							var ohandle = GCHandle.Alloc(arg, GCHandleType.Pinned);
							handles.Add(ohandle);
							ptrs[i] = ohandle.AddrOfPinnedObject();
						}
						else
							throw new NotSupportedException();
						break;
				}
			}
		}

		/*private void Test(CharSet charSet, params object[] args)
		{
			if (args == null) throw new ArgumentNullException(nameof(args));

			// The first handle is for the bytes array
			handles.Add(default(GCHandle));

			var bf = new BinaryFormatter();
			var enc = StringHelper.GetCharSize(charSet) == 1 ? Encoding.ASCII : Encoding.Unicode;
			using (var ms = new MemoryStream())
			using (var bw = new BinaryWriter(ms, enc, true))
			{
				foreach (var arg in args)
				{
					if (arg == null || arg == DBNull.Value)
					{
						WritePad(bw, 0);
						continue;
					}

					var type = arg.GetType();
					var typeHandle = Type.GetTypeCode(type);
					switch (typeHandle)
					{
						case TypeCode.Boolean:
							bw.Write((bool)arg ? 1U : 0U);
							WritePad(bw, sizeof(int));
							break;

						case TypeCode.SByte:
							bw.Write((sbyte)arg);
							WritePad(bw, Marshal.SizeOf(arg));
							break;

						case TypeCode.Byte:
							bw.Write((byte)arg);
							WritePad(bw, Marshal.SizeOf(arg));
							break;

						case TypeCode.Int16:
							bw.Write((short)arg);
							WritePad(bw, Marshal.SizeOf(arg));
							break;

						case TypeCode.UInt16:
							bw.Write((ushort)arg);
							WritePad(bw, Marshal.SizeOf(arg));
							break;

						case TypeCode.Int32:
							bw.Write((int)arg);
							WritePad(bw, Marshal.SizeOf(arg));
							break;

						case TypeCode.UInt32:
							bw.Write((uint)arg);
							WritePad(bw, Marshal.SizeOf(arg));
							break;

						case TypeCode.Int64:
							bw.Write((long)arg);
							WritePad(bw, Marshal.SizeOf(arg));
							break;

						case TypeCode.UInt64:
							bw.Write((ulong)arg);
							WritePad(bw, Marshal.SizeOf(arg));
							break;

						case TypeCode.Single:
							bw.Write((float)arg);
							WritePad(bw, Marshal.SizeOf(arg));
							break;

						case TypeCode.Double:
							bw.Write((double)arg);
							WritePad(bw, Marshal.SizeOf(arg));
							break;

						case TypeCode.Char:
							bw.Write((char)arg);
							WritePad(bw, enc.GetMaxCharCount(1));
							break;

						case TypeCode.String:
							var str = (string)arg;
							var bytes = str.GetBytesNullTerm(true, charSet);
							var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
							handles.Add(handle);
							WritePtr(bw, handle.AddrOfPinnedObject());
							break;

						case TypeCode.Object:
							if (type == typeof(IntPtr))
								WritePtr(bw, (IntPtr)arg);
							else if (type == typeof(UIntPtr))
							{
								if (IntPtr.Size == 4)
									bw.Write(((UIntPtr)arg).ToUInt32());
								else
									bw.Write(((UIntPtr)arg).ToUInt64());
							}
							else if (!type.IsValueType)
							{
								var ohandle = GCHandle.Alloc(arg, GCHandleType.Pinned);
								handles.Add(ohandle);
								WritePtr(bw, ohandle.AddrOfPinnedObject());
							}
							else
								throw new NotSupportedException();

							break;

						default:
							throw new NotSupportedException();
					}
				}
				buffer = ms.ToArray();
			}

			handles[0] = GCHandle.Alloc(buffer, GCHandleType.Pinned);

			void WritePad(BinaryWriter bw, int size)
			{
				var pad = IntPtr.Size - size;
				if (pad > 0)
					bw.Write(new byte[pad], 0, pad);
			}

			void WritePtr(BinaryWriter bw, IntPtr p)
			{
				if (IntPtr.Size == 4)
					bw.Write(p.ToInt32());
				else
					bw.Write(p.ToInt64());
			}
		}*/

		~VaList()
		{
			Dispose(false);
		}

		public static implicit operator IntPtr(VaList vaList) => vaList.AddrOfPinnedObject();

		public static implicit operator VaList(object[] args) => new VaList(args);

		public IntPtr AddrOfPinnedObject()
		{
			if (handles.Count == 0)
				throw new ObjectDisposedException(GetType().Name);

			return handles[0].AddrOfPinnedObject();
		}

		void IDisposable.Dispose()
		{
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			for (var i = 0; i < handles.Count; i++)
				if (handles[i].IsAllocated)
					handles[i].Free();

			handles.Clear();
		}
	}
}