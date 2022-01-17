using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.PInvoke;

namespace Vanara.InteropServices.Tests
{
	[TestFixture()]
	public class SafeHGlobalHandleTests
	{
		[Test(Description = "Allocate an enumeration")]
		public void CreateFromListTest()
		{
			var r = new[] { 5, 5, 5, 5 };
			var h = SafeHGlobalHandle.CreateFromList(r, r.Length);
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That((int)h.Size, Is.EqualTo(Marshal.SizeOf(typeof(int)) * r.Length));
			Assert.That(h.ToStructure<int>(), Is.EqualTo(5));
			Assert.That(h.ToEnumerable<int>(4), Has.Exactly(4).EqualTo(5).And.Exactly(4).Items);

			var d = new[] { new RECT(1, 1, 1, 1), new RECT(2, 2, 2, 2) };
			h = SafeHGlobalHandle.CreateFromList(d, d.Length);
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That((int)h.Size, Is.EqualTo(Marshal.SizeOf(typeof(RECT)) * d.Length));
			Assert.That(h.ToStructure<RECT>().X, Is.EqualTo(1));
			Assert.That(h.ToArray<RECT>(2), Has.Exactly(2).Items);

			var p = new[] { new PRECT(1, 1, 1, 1), new PRECT(2, 2, 2, 2) };
			h = SafeHGlobalHandle.CreateFromList(p);
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That((int)h.Size, Is.EqualTo(Marshal.SizeOf(typeof(PRECT)) * p.Length));
			Assert.That(h.ToArray<RECT>(2), Has.Exactly(2).Items);

			Assert.That(() => SafeHGlobalHandle.CreateFromList(new[] { "X" }), Throws.ArgumentException);
		}

		[Test(Description = "Allocate an enumeration of strings.")]
		public void CreateFromStringListTest()
		{
			var r = new[] { "5", "5", "5", "5" };

			var h = SafeHGlobalHandle.CreateFromStringList(r, StringListPackMethod.Concatenated, CharSet.Ansi, 7);
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That((int)h.Size, Is.EqualTo(16));
			Assert.That(h.ToStringEnum(CharSet.Ansi, 7), Has.Exactly(4).EqualTo("5").And.Exactly(4).Items);
			h = SafeHGlobalHandle.CreateFromStringList(r, StringListPackMethod.Concatenated, CharSet.Unicode, 7);
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That((int)h.Size, Is.EqualTo(25));
			Assert.That(h.ToStringEnum(CharSet.Unicode, 7), Has.Exactly(4).EqualTo("5").And.Exactly(4).Items);
			h = SafeHGlobalHandle.CreateFromStringList(r);
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That((int)h.Size, Is.EqualTo(18));
			Assert.That(h.ToString(-1), Is.EqualTo("5"));
			Assert.That(h.ToStringEnum(), Has.Exactly(4).EqualTo("5").And.Exactly(4).Items);

			h = SafeHGlobalHandle.CreateFromStringList(r, StringListPackMethod.Packed, CharSet.Ansi, 7);
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That((int)h.Size, Is.EqualTo(7 + IntPtr.Size + r.Length * (2 + IntPtr.Size)));
			Assert.That(h.ToStringEnum(4, CharSet.Ansi, 7), Has.Exactly(4).EqualTo("5").And.Exactly(4).Items);
			h = SafeHGlobalHandle.CreateFromStringList(r, StringListPackMethod.Packed, CharSet.Unicode, 7);
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That((int)h.Size, Is.EqualTo(7 + IntPtr.Size + r.Length * (4 + IntPtr.Size)));
			Assert.That(h.ToStringEnum(4, CharSet.Unicode, 7), Has.Exactly(4).EqualTo("5").And.Exactly(4).Items);
			h = SafeHGlobalHandle.CreateFromStringList(r, StringListPackMethod.Packed);
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That((int)h.Size, Is.EqualTo(IntPtr.Size + r.Length * (4 + IntPtr.Size)));
			Assert.That(h.ToStringEnum(4, CharSet.Unicode), Has.Exactly(4).EqualTo("5").And.Exactly(4).Items);

			h = SafeHGlobalHandle.CreateFromStringList(null);
			Assert.That((int)h.Size, Is.EqualTo(Extensions.StringHelper.GetCharSize()));
		}

		[Test(Description = "Allocate a structure")]
		public void CreateFromStructureTest()
		{
			var r = new RECT(5, 5, 5, 5);
			var h = SafeHGlobalHandle.CreateFromStructure(r);
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That((int)h.Size, Is.EqualTo(Marshal.SizeOf(typeof(RECT))));
			Assert.That(h.ToStructure<RECT>().X, Is.EqualTo(5));
		}

		[Test()]
		public void ResizeTest()
		{
			var h = new SafeHGlobalHandle(5);
			Assert.That(!h.IsClosed && !h.IsInvalid && h.Size == 5);
			var ptr = (IntPtr)h;
			h.Size = 50;
			Assert.That(!h.IsClosed && !h.IsInvalid && h.Size == 50 && (IntPtr)h != ptr);
		}

		[Test()]
		public void SafeHGlobalHandleTest()
		{
			var ptr = Marshal.AllocHGlobal(5);
			var h = new SafeHGlobalHandle(ptr, 5);
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That((int)h.Size, Is.EqualTo(5));
			h.Dispose();
			Assert.That(h.IsClosed && h.IsInvalid);

			h = Marshal.AllocHGlobal(5);
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That(h, Is.Not.EqualTo(SafeHGlobalHandle.Null));
			h.Dispose();
			Assert.That(h.IsClosed && h.IsInvalid);
		}

		[Test]
		public void SafeHGlobalHandleExceptionTest()
		{
			Assert.That(SafeHGlobalHandle.Null.IsInvalid, Is.True);

			Assert.That(SafeHGlobalHandle.Null.ToArray<RECT>(0), Is.Null);
			Assert.That(SafeHGlobalHandle.Null.ToArray<Exception>(0), Is.Null);
			Assert.That(() => new SafeHGlobalHandle(5).ToArray<Exception>(0), Throws.ArgumentException);

			Assert.That(SafeHGlobalHandle.Null.ToEnumerable<RECT>(0), Is.Empty);
			Assert.That(SafeHGlobalHandle.Null.ToEnumerable<Exception>(0), Is.Empty.And.EquivalentTo(new Exception[0]));
			Assert.That(() => new SafeHGlobalHandle(5).ToEnumerable<Exception>(0).ToArray(), Throws.Exception);

			Assert.That(SafeHGlobalHandle.Null.ToStructure<RECT>(), Is.EqualTo(default(RECT)));

			Assert.That(() => new SafeHGlobalHandle(-1), Throws.TypeOf<ArgumentOutOfRangeException>());

			Assert.That(() => new SafeHGlobalHandle(5).AddSubReference(new[] { new SafeHGlobalHandle(5), new SafeHGlobalHandle(5) }), Throws.Nothing);
		}

		[Test()]
		public void SafeHGlobalHandleTest1()
		{
			var h = new SafeHGlobalHandle(Marshal.AllocHGlobal(5), 5);
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That((int)h.Size, Is.EqualTo(5));
			h.Dispose();
			Assert.That(h.IsClosed && h.IsInvalid);
		}

		[Test()]
		public void SafeHGlobalHandleTest2()
		{
			var h = new SafeHGlobalHandle(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That((int)h.Size, Is.EqualTo(10));
			h.Dispose();
			Assert.That(h.IsClosed && h.IsInvalid);
		}

		[Test()]
		public void SafeHGlobalHandleTest3()
		{
			var h = new SafeHGlobalHandle(new[] { (IntPtr)1, (IntPtr)2, (IntPtr)3, (IntPtr)4, (IntPtr)5 });
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That((int)h.Size, Is.EqualTo(5 * IntPtr.Size));
			h.Dispose();
			Assert.That(h.IsClosed && h.IsInvalid);
		}

		[Test()]
		public void SafeHGlobalHandleTest4()
		{
			var h = new SafeHGlobalHandle("0123456789");
			Assert.That(!h.IsClosed && !h.IsInvalid);
			Assert.That((int)h.Size, Is.EqualTo(11 * Marshal.SystemDefaultCharSize));
			h.Dispose();
			Assert.That(h.IsClosed && h.IsInvalid);
		}

		[Test()]
		public void HGlobalMemoryMethodsTest()
		{
			var mm = new HGlobalMemoryMethods();
			var h = mm.AllocStringAnsi("Test");
			Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
			Assert.That(() => mm.FreeMem(h), Throws.Nothing);
			var ss = new SecureString();
			h = mm.AllocSecureStringUni(ss);
			Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
			Assert.That(() => mm.FreeSecureStringUni(h), Throws.Nothing);
			h = mm.AllocSecureStringAnsi(ss);
			Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
			Assert.That(() => mm.FreeSecureStringAnsi(h), Throws.Nothing);
		}
	}
}