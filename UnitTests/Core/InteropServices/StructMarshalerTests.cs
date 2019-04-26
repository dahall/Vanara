using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vanara.Extensions;

namespace Vanara.InteropServices.Tests
{
	[TestFixture]
	public class StructMarshalerTests
	{
		[MarshaledStruct]
		public struct BlitStruct
		{
			public long l2;

			public Guid g1;

			public bool b1;

			public uint ui1;

			public float f1;

			[MarshalDirective(AlternateType = typeof(byte))]
			public bool b2;

			public ushort us1;

			public byte b3;
		}

		[MarshaledStruct(Bias = MarshalBias.Bidirectional, CharSet = CharSet.Unicode)]
		public struct Test
		{
			public long l2;

			public Guid g1;

			public string s1;

			public uint cba1;

			[MarshalDirective(MarshalDirective.AsArray, SizeField = "cba1")]
			public Guid[] a1;

			[MarshalDirective(MarshalDirective.AsRefArray, SizeField = "cbsa1")]
			public string[] sa1;

			public uint cbsa1;

			[MarshalDirective(AlternateType = typeof(ulong))]
			public uint ui2;

			[MarshalDirective(MarshalDirective.AsArray, SizeConst = 256)]
			public string s2;

			[MarshalDirective(SizeConst = 256, CharSet = CharSet.Ansi)]
			public string s3;

			[MarshalDirective(MarshalDirective.AsReference)]
			public Guid g2;

			[MarshalDirective(MarshalDirective.AsRefArray)]
			public Guid[] a2;

			public uint cba2;

			public uint cbsa2;

			[MarshalDirective(MarshalDirective.AsNullTermStringArray)]
			public string[] sa2;
		}

		[Test]
		public void SerializeBlitTest()
		{
			var s = new BlitStruct
			{
				l2 = 7L,
				g1 = Guid.NewGuid(),
				b1 = true,
				ui1 = 8,
				f1 = 4.2f,
				b2 = true,
				us1 = 3,
				b3 = 4
			};
			using (var ptr = MarshaledStructSerializer.Serialize(s))
			{
				Assert.That(ptr.IsInvalid, Is.False);
				Assert.That(ptr.Size, Is.EqualTo(40));
				TestContext.WriteLine(ptr.Dump);

				var obj = MarshaledStructSerializer.Deserialize<BlitStruct>(ptr);
				Assert.That(obj, Is.Not.Null);
				Assert.That(obj, Is.TypeOf<BlitStruct>());

				foreach (var fi in typeof(BlitStruct).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Instance))
				{
					if (fi.FieldType.FindElementType() is null)
						Assert.That(fi.GetValue(obj), Is.EqualTo(fi.GetValue(s)));
					else
						Assert.That(fi.GetValue(obj), Is.EquivalentTo(fi.GetValue(s) as IEnumerable));
				}
			}
		}
	}
}
