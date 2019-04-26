using NUnit.Framework;
using System;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class OBJECT_TYPE_LISTTests
	{
		[Test()]
		public void OBJECT_TYPE_LISTTest()
		{
			var guid = Guid.NewGuid();
			var otl = new OBJECT_TYPE_LIST(ObjectTypeListLevel.ACCESS_PROPERTY_SET_GUID, guid);
			Assert.That(otl.ObjectType == guid);
			Assert.That(otl.Level == ObjectTypeListLevel.ACCESS_PROPERTY_SET_GUID);
		}
	}
}