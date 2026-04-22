using NUnit.Framework;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class BOOLTests
{
	private static readonly ConcurrentDictionary<Type, bool> cachedTypes = [];
	private static bool IsUnmanagedType(Type t)
	{
		var result = false;
		if (cachedTypes.TryGetValue(t, out bool value))
			return value;
		else if (t.IsPrimitive || t.IsPointer || t.IsEnum)
			result = true;
		else if (t.IsGenericType || !t.IsValueType)
			result = false;
		else
			result = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).All(x => IsUnmanagedType(x.FieldType));
		cachedTypes[t] = result;
		return result;
	}

	[Test]
	public void IsUnmanagedTypeTest()
	{
		byte[] buffer = new byte[4];
		Assert.That(IsUnmanagedType(typeof(BOOL)));
		Assert.That(() => Marshal.StructureToPtr((object)new BOOL(true), Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0), false), Throws.Nothing);
		Assert.That(buffer[0], Is.EqualTo(1));

		Assert.That(IsUnmanagedType(typeof(BOOLEAN)));
		Assert.That(IsUnmanagedType(typeof(VARIANT_BOOL)));
	}

	[Test]
	public void BOOLTest()
	{
		Assert.That(Marshal.SizeOf<BOOL>(), Is.EqualTo(sizeof(uint)));

		BOOL b = true;
		Assert.That(b.Value, Is.True);
		Assert.That(b == true);
		Assert.That(b == new BOOL(true));
		Assert.That((bool)b, Is.EqualTo(true));
		Assert.That(b != false);
		Assert.That(b != new BOOL(false));
		Assert.That(!b == false);
		Assert.That((bool)!b, Is.EqualTo(false));
		Assert.That((int)b, Is.Not.EqualTo(0));
		Assert.That((IntPtr)b, Is.Not.EqualTo(IntPtr.Zero));

		Assert.That(() => b ? 1 : 0, Is.EqualTo(1));

		b = 5;
		Assert.That(b.Value, Is.True);
		Assert.That(b == true);
		Assert.That(b == new BOOL(true));
		Assert.That((bool)b, Is.EqualTo(true));
		Assert.That(b != false);
		Assert.That(b != new BOOL(false));
		Assert.That(!b == false);
		Assert.That((bool)!b, Is.EqualTo(false));
		Assert.That((int)b, Is.Not.EqualTo(0));
		Assert.That((IntPtr)b, Is.Not.EqualTo(IntPtr.Zero));

		b = false;
		Assert.That(b.Value, Is.False);
		Assert.That(b == false);
		Assert.That(b == new BOOL(false));
		Assert.That((bool)b, Is.EqualTo(false));
		Assert.That(b != true);
		Assert.That(b != new BOOL(true));
		Assert.That(!b == true);
		Assert.That((bool)!b, Is.EqualTo(true));
		Assert.That((int)b, Is.EqualTo(0));
		Assert.That((IntPtr)b, Is.EqualTo(IntPtr.Zero));

		b = 0;
		Assert.That(b.Value, Is.False);
		Assert.That(b == false);
		Assert.That(b == new BOOL(false));
		Assert.That((bool)b, Is.EqualTo(false));
		Assert.That(b != true);
		Assert.That(b != new BOOL(true));
		Assert.That(!b == true);
		Assert.That((bool)!b, Is.EqualTo(true));
		Assert.That((int)b, Is.EqualTo(0));
		Assert.That((IntPtr)b, Is.EqualTo(IntPtr.Zero));
	}

	[Test]
	public void BOOLIConvertibleTest()
	{
		BOOL b = true;
		var conv = (IConvertible)b;
		Assert.That(conv.ToBoolean(null), Is.True);
		Assert.That(conv.ToInt32(null), Is.Not.EqualTo(0));
		Assert.That(conv.ToInt64(null), Is.Not.EqualTo(0));
		Assert.That(conv.ToUInt32(null), Is.Not.EqualTo(0));
		Assert.That(conv.ToUInt64(null), Is.Not.EqualTo(0));
		Assert.That(Convert.ChangeType(b, typeof(bool)), Is.EqualTo(true));
	}

	[Test]
	public void BOOLMemTest()
	{
		using SafeCoTaskMemStruct<BOOL> mem = (BOOL)true;
	}

	[Test]
	public void BOOLEANMemTest()
	{
		using SafeCoTaskMemStruct<BOOLEAN> mem = (BOOLEAN)true;
	}

	[Test]
	public void VARIANT_BOOLMemTest()
	{
		using SafeCoTaskMemStruct<VARIANT_BOOL> mem = (VARIANT_BOOL)true;
	}

	[Test]
	public void BOOLEANTest()
	{
		Assert.That(Marshal.SizeOf<BOOLEAN>(), Is.EqualTo(sizeof(byte)));

		BOOLEAN b = true;
		Assert.That(b.Value, Is.True);
		Assert.That(b == true);
		Assert.That(b == new BOOLEAN(true));
		Assert.That((bool)b, Is.EqualTo(true));
		Assert.That(b != false);
		Assert.That(b != new BOOLEAN(false));
		Assert.That(!b == false);
		Assert.That((bool)!b, Is.EqualTo(false));
		Assert.That((int)b, Is.Not.EqualTo(0));
		Assert.That((IntPtr)b, Is.Not.EqualTo(IntPtr.Zero));

		Assert.That(() => b ? 1 : 0, Is.EqualTo(1));

		b = 5;
		Assert.That(b.Value, Is.True);
		Assert.That(b == true);
		Assert.That(b == new BOOLEAN(true));
		Assert.That((bool)b, Is.EqualTo(true));
		Assert.That(b != false);
		Assert.That(b != new BOOLEAN(false));
		Assert.That(!b == false);
		Assert.That((bool)!b, Is.EqualTo(false));
		Assert.That((int)b, Is.Not.EqualTo(0));
		Assert.That((IntPtr)b, Is.Not.EqualTo(IntPtr.Zero));

		b = false;
		Assert.That(b.Value, Is.False);
		Assert.That(b == false);
		Assert.That(b == new BOOLEAN(false));
		Assert.That((bool)b, Is.EqualTo(false));
		Assert.That(b != true);
		Assert.That(b != new BOOLEAN(true));
		Assert.That(!b == true);
		Assert.That((bool)!b, Is.EqualTo(true));
		Assert.That((int)b, Is.EqualTo(0));
		Assert.That((IntPtr)b, Is.EqualTo(IntPtr.Zero));

		b = 0;
		Assert.That(b.Value, Is.False);
		Assert.That(b == false);
		Assert.That(b == new BOOLEAN(false));
		Assert.That((bool)b, Is.EqualTo(false));
		Assert.That(b != true);
		Assert.That(b != new BOOLEAN(true));
		Assert.That(!b == true);
		Assert.That((bool)!b, Is.EqualTo(true));
		Assert.That((int)b, Is.EqualTo(0));
		Assert.That((IntPtr)b, Is.EqualTo(IntPtr.Zero));
	}

	[Test]
	public void BOOLEANIConvertibleTest()
	{
		BOOLEAN b = true;
		var conv = (IConvertible)b;
		Assert.That(conv.ToBoolean(null), Is.True);
		Assert.That(conv.ToInt32(null), Is.Not.EqualTo(0));
		Assert.That(conv.ToInt64(null), Is.Not.EqualTo(0));
		Assert.That(conv.ToUInt32(null), Is.Not.EqualTo(0));
		Assert.That(conv.ToUInt64(null), Is.Not.EqualTo(0));
		Assert.That(Convert.ChangeType(b, typeof(bool)), Is.EqualTo(true));
	}

	[Test]
	public void VARIANT_BOOLTest()
	{
		Assert.That(Marshal.SizeOf<VARIANT_BOOL>(), Is.EqualTo(sizeof(short)));

		VARIANT_BOOL b = true;
		Assert.That(b.Value, Is.True);
		Assert.That(b == true);
		Assert.That(b == new VARIANT_BOOL(true));
		Assert.That((bool)b, Is.EqualTo(true));
		Assert.That(b != false);
		Assert.That(b != new VARIANT_BOOL(false));
		Assert.That(!b == false);
		Assert.That((bool)!b, Is.EqualTo(false));
		Assert.That((int)b, Is.Not.EqualTo(0));
		Assert.That((IntPtr)b, Is.Not.EqualTo(IntPtr.Zero));

		Assert.That(() => b ? 1 : 0, Is.EqualTo(1));

		b = 5;
		Assert.That(b.Value, Is.True);
		Assert.That(b == true);
		Assert.That(b == new VARIANT_BOOL(true));
		Assert.That((bool)b, Is.EqualTo(true));
		Assert.That(b != false);
		Assert.That(b != new VARIANT_BOOL(false));
		Assert.That(!b == false);
		Assert.That((bool)!b, Is.EqualTo(false));
		Assert.That((int)b, Is.Not.EqualTo(0));
		Assert.That((IntPtr)b, Is.Not.EqualTo(IntPtr.Zero));

		b = false;
		Assert.That(b.Value, Is.False);
		Assert.That(b == false);
		Assert.That(b == new VARIANT_BOOL(false));
		Assert.That((bool)b, Is.EqualTo(false));
		Assert.That(b != true);
		Assert.That(b != new VARIANT_BOOL(true));
		Assert.That(!b == true);
		Assert.That((bool)!b, Is.EqualTo(true));
		Assert.That((int)b, Is.EqualTo(0));
		Assert.That((IntPtr)b, Is.EqualTo(IntPtr.Zero));

		b = 0;
		Assert.That(b.Value, Is.False);
		Assert.That(b == false);
		Assert.That(b == new VARIANT_BOOL(false));
		Assert.That((bool)b, Is.EqualTo(false));
		Assert.That(b != true);
		Assert.That(b != new VARIANT_BOOL(true));
		Assert.That(!b == true);
		Assert.That((bool)!b, Is.EqualTo(true));
		Assert.That((int)b, Is.EqualTo(0));
		Assert.That((IntPtr)b, Is.EqualTo(IntPtr.Zero));
	}

	[Test]
	public void VARIANT_BOOLIConvertibleTest()
	{
		VARIANT_BOOL b = true;
		var conv = (IConvertible)b;
		Assert.That(conv.ToBoolean(null), Is.True);
		Assert.That(conv.ToInt32(null), Is.Not.EqualTo(0));
		Assert.That(conv.ToInt64(null), Is.Not.EqualTo(0));
		Assert.That(conv.ToUInt32(null), Is.Not.EqualTo(0));
		Assert.That(conv.ToUInt64(null), Is.Not.EqualTo(0));
		Assert.That(Convert.ChangeType(b, typeof(bool)), Is.EqualTo(true));
	}
}