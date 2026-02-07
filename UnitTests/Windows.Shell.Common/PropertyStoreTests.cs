using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.Windows.Shell.Tests;

[TestFixture]
public class PropertyStoreTests
{
	private string testFilePath = null!;

	[OneTimeSetUp]
	public void Setup()
	{
		// Create a test file
		testFilePath = Path.Combine(Path.GetTempPath(), $"PropertyStoreTest_{Guid.NewGuid()}.docx");
		File.Copy(Vanara.PInvoke.Tests.TestCaseSources.WordDoc, testFilePath);
	}

	[OneTimeTearDown]
	public void Cleanup()
	{
		if (File.Exists(testFilePath))
			File.Delete(testFilePath);
	}

	[Test]
	public void PropertyStore_Constructor_WithPath_Success()
	{
		using var ps = new PropertyStore(testFilePath);
		Assert.That(ps, Is.Not.Null);
		Assert.That(ps.Count, Is.GreaterThanOrEqualTo(0));
	}

	[Test]
	public void PropertyStore_Constructor_WithInvalidPath_ThrowsException() => Assert.That(() => new PropertyStore("Z:\\NonExistent\\Path\\File.txt"), Throws.Exception);

	[Test]
	public void PropertyStore_Constructor_WithFlags_Success()
	{
		using var ps = new PropertyStore(testFilePath, GETPROPERTYSTOREFLAGS.GPS_READWRITE);
		Assert.That(ps, Is.Not.Null);
		Assert.That(ps.ReadOnly, Is.False);
	}

	[Test]
	public void PropertyStore_Count_ReturnsValidCount()
	{
		using var ps = new PropertyStore(testFilePath);
		var count = ps.Count;
		Assert.That(count, Is.GreaterThanOrEqualTo(0));
	}

	[Test]
	public void PropertyStore_Keys_ReturnsValidKeys()
	{
		using var ps = new PropertyStore(testFilePath);
		var keys = ps.Keys;
		Assert.That(keys, Is.Not.Null);
		Assert.That(keys.Count, Is.EqualTo(ps.Count));
	}

	[Test]
	public void PropertyStore_Values_ReturnsValidValues()
	{
		using var ps = new PropertyStore(testFilePath);
		var values = ps.Values;
		Assert.That(values, Is.Not.Null);
		Assert.That(values.Count, Is.EqualTo(ps.Count));
	}

	[Test]
	public void PropertyStore_ReadOnly_DefaultIsTrue()
	{
		using var ps = new PropertyStore(testFilePath);
		Assert.That(ps.ReadOnly, Is.True);
	}

	[Test]
	public void PropertyStore_ReadOnly_CanSetToFalse()
	{
		using var ps = new PropertyStore(testFilePath);
		ps.ReadOnly = false;
		Assert.That(ps.ReadOnly, Is.False);
	}

	[Test]
	public void PropertyStore_IsDirty_DefaultIsFalse()
	{
		using var ps = new PropertyStore(testFilePath);
		Assert.That(ps.IsDirty, Is.False);
	}

	[Test]
	public void PropertyStore_IncludeSlow_DefaultIsFalse()
	{
		using var ps = new PropertyStore(testFilePath);
		Assert.That(ps.IncludeSlow, Is.False);
	}

	[Test]
	public void PropertyStore_IncludeSlow_CanSetToTrue()
	{
		using var ps = new PropertyStore(testFilePath);
		ps.IncludeSlow = true;
		Assert.That(ps.IncludeSlow, Is.True);
	}

	[Test]
	public void PropertyStore_NoInheritedProperties_DefaultIsFalse()
	{
		using var ps = new PropertyStore(testFilePath);
		Assert.That(ps.NoInheritedProperties, Is.False);
	}

	[Test]
	public void PropertyStore_NoInheritedProperties_CanSetToTrue()
	{
		using var ps = new PropertyStore(testFilePath);
		ps.NoInheritedProperties = true;
		Assert.That(ps.NoInheritedProperties, Is.True);
	}

	[Test]
	public void PropertyStore_Temporary_DefaultIsFalse()
	{
		using var ps = new PropertyStore(testFilePath);
		Assert.That(ps.Temporary, Is.False);
	}

	[Test]
	public void PropertyStore_Temporary_CanSetToTrue()
	{
		using var ps = new PropertyStore(testFilePath);
		ps.Temporary = true;
		Assert.That(ps.Temporary, Is.True);
		Assert.That(ps.ReadOnly, Is.True);
	}

	[Test]
	public void PropertyStore_GetPropertyKeyFromName_ValidName_ReturnsKey()
	{
		var key = PropertyStore.GetPropertyKeyFromName("System.Title");
		Assert.That(key, Is.Not.EqualTo(default(PROPERTYKEY)));
	}

	[Test]
	public void PropertyStore_GetPropertyKeyFromName_InvalidName_ThrowsException() => Assert.That(() => PropertyStore.GetPropertyKeyFromName("Invalid.Property.Name.That.Does.Not.Exist"),
			Throws.TypeOf<ArgumentOutOfRangeException>());

	[Test]
	public void PropertyStore_GetPropertyKeyFromName_NullName_ThrowsException() => Assert.That(() => PropertyStore.GetPropertyKeyFromName(null!),
			Throws.TypeOf<ArgumentNullException>());

	[Test]
	public void PropertyStore_GetPropertyDescription_ValidKey_ReturnsDescription()
	{
		var key = PropertyStore.GetPropertyKeyFromName("System.Title");
		var description = PropertyStore.GetPropertyDescription(key);
		Assert.That(description, Is.Not.Null);
	}

	[Test]
	public void PropertyStore_Indexer_ByString_CanGetValue()
	{
		using var ps = new PropertyStore(testFilePath);
		Assert.That(() => ps["System.Title"], Throws.Nothing);
	}

	[Test]
	public void PropertyStore_Indexer_ByKey_CanGetValue()
	{
		using var ps = new PropertyStore(testFilePath);
		var key = PropertyStore.GetPropertyKeyFromName("System.Title");
		Assert.That(() => ps[key], Throws.Nothing);
	}

	[Test]
	public void PropertyStore_Add_SetsReadOnlyToFalse()
	{
		using var ps = new PropertyStore(testFilePath);
		var key = PropertyStore.GetPropertyKeyFromName("System.Title");
		ps.Add(key, "Test Title");
		Assert.That(ps.ReadOnly, Is.False);
		Assert.That(ps.IsDirty, Is.True);
	}

	[Test]
	public void PropertyStore_Commit_ClearsDirtyFlag()
	{
		using var ps = new PropertyStore(testFilePath);
		var key = PropertyStore.GetPropertyKeyFromName("System.Title");
		ps.Add(key, "Test Title");
		Assert.That(ps.IsDirty, Is.True);
		ps.Commit();
		Assert.That(ps.IsDirty, Is.False);
	}

	[Test]
	public void PropertyStore_ContainsKey_ExistingKey_ReturnsTrue()
	{
		using var ps = new PropertyStore(testFilePath);
		if (ps.Keys.Count > 0)
		{
			var firstKey = ps.Keys.First();
			Assert.That(ps.ContainsKey(firstKey), Is.True);
		}
	}

	[Test]
	public void PropertyStore_TryGetValue_ExistingKey_ReturnsTrue()
	{
		using var ps = new PropertyStore(testFilePath);
		if (ps.Keys.Count > 0)
		{
			var firstKey = ps.Keys.First();
			var result = ps.TryGetValue(firstKey, out var value);
			Assert.That(result, Is.True);
		}
	}

	[Test]
	public void PropertyStore_TryGetValue_Generic_ReturnsCorrectType()
	{
		using var ps = new PropertyStore(testFilePath);
		var key = PropertyStore.GetPropertyKeyFromName("System.Size");
		if (ps.ContainsKey(key))
		{
			var result = ps.TryGetValue<ulong>(key, out var value);
			if (result)
				Assert.That(value, Is.TypeOf<ulong>());
		}
	}

	[Test]
	public void PropertyStore_GetProperty_ExistingKey_ReturnsValue()
	{
		using var ps = new PropertyStore(testFilePath);
		if (ps.Keys.Count > 0)
		{
			var firstKey = ps.Keys.First();
			Assert.That(() => ps.GetProperty<object>(firstKey), Throws.Nothing);
		}
	}

	[Test]
	public void PropertyStore_GetPropertyString_ValidKey_ReturnsString()
	{
		using var ps = new PropertyStore(testFilePath);
		if (ps.Keys.Count > 0)
		{
			var firstKey = ps.Keys.First();
			Assert.That(() => ps.GetPropertyString(firstKey), Throws.Nothing);
		}
	}

	[Test]
	public void PropertyStore_GetPropVariant_ValidKey_ReturnsPropVariant()
	{
		using var ps = new PropertyStore(testFilePath);
		if (ps.Keys.Count > 0)
		{
			var firstKey = ps.Keys.First();
			using var pv = ps.GetPropVariant(firstKey);
			Assert.That(pv, Is.Not.Null);
		}
	}

	[Test]
	public void PropertyStore_IsPropertyWritable_ReadOnlyStore_ReturnsFalse()
	{
		using var ps = new PropertyStore(testFilePath);
		ps.ReadOnly = true;
		var key = PropertyStore.GetPropertyKeyFromName("System.Title");
		Assert.That(ps.IsPropertyWritable(key), Is.False);
	}

	[Test]
	public void PropertyStore_CopyTo_ValidArray_CopiesElements()
	{
		using var ps = new PropertyStore(testFilePath);
		var array = new KeyValuePair<PROPERTYKEY, object?>[ps.Count];
		Assert.That(() => ps.CopyTo(array, 0), Throws.Nothing);
	}

	[Test]
	public void PropertyStore_CopyTo_ArrayTooSmall_ThrowsException()
	{
		using var ps = new PropertyStore(testFilePath);
		if (ps.Count > 0)
		{
			var array = new KeyValuePair<PROPERTYKEY, object?>[ps.Count - 1];
			Assert.That(() => ps.CopyTo(array, 0), Throws.TypeOf<ArgumentOutOfRangeException>());
		}
	}

	[Test]
	public void PropertyStore_CopyTo_NullArray_ThrowsException()
	{
		using var ps = new PropertyStore(testFilePath);
		Assert.That(() => ps.CopyTo(null!, 0), Throws.TypeOf<ArgumentNullException>());
	}

	[Test]
	public void PropertyStore_Descriptions_ReturnsValidDictionary()
	{
		using var ps = new PropertyStore(testFilePath);
		var descriptions = ps.Descriptions;
		Assert.That(descriptions, Is.Not.Null);
		Assert.That(descriptions.Count, Is.EqualTo(ps.Count));
	}

	[Test]
	public void PropertyStore_PropertyChanged_EventRaisedOnAdd()
	{
		using var ps = new PropertyStore(testFilePath);
		var eventRaised = false;
		ps.PropertyChanged += (sender, args) => eventRaised = true;
		var key = PropertyStore.GetPropertyKeyFromName("System.Title");
		ps.Add(key, "Test Title");
		Assert.That(eventRaised, Is.True);
	}

	[Test]
	public void PropertyStore_Enumeration_CanEnumerate()
	{
		using var ps = new PropertyStore(testFilePath);
		var count = 0;
		foreach (var kvp in ps)
		{
			count++;
		}
		Assert.That(count, Is.EqualTo(ps.Count));
	}

	[Test]
	public void PropertyStore_ICollectionIsReadOnly_ReturnsCorrectValue()
	{
		using var ps = new PropertyStore(testFilePath);
		var collection = ps as ICollection<KeyValuePair<PROPERTYKEY, object?>>;
		Assert.That(collection!.IsReadOnly, Is.EqualTo(ps.ReadOnly));
	}

	[Test]
	public void PropertyStore_ICollectionClear_ThrowsException()
	{
		using var ps = new PropertyStore(testFilePath);
		var collection = ps as ICollection<KeyValuePair<PROPERTYKEY, object?>>;
		Assert.That(() => collection!.Clear(), Throws.TypeOf<InvalidOperationException>());
	}

	[Test]
	public void PropertyStore_IDictionaryRemove_ThrowsException()
	{
		using var ps = new PropertyStore(testFilePath);
		var dictionary = ps as IDictionary<PROPERTYKEY, object?>;
		var key = PropertyStore.GetPropertyKeyFromName("System.Title");
		Assert.That(() => dictionary!.Remove(key), Throws.TypeOf<InvalidOperationException>());
	}

	[Test]
	public void PropertyStore_ICollectionRemove_ThrowsException()
	{
		using var ps = new PropertyStore(testFilePath);
		var collection = ps as ICollection<KeyValuePair<PROPERTYKEY, object?>>;
		var key = PropertyStore.GetPropertyKeyFromName("System.Title");
		var item = new KeyValuePair<PROPERTYKEY, object?>(key, "Test");
		Assert.That(() => collection!.Remove(item), Throws.TypeOf<InvalidOperationException>());
	}

	[Test]
	public void PropertyStore_Dispose_DisposesCleanly()
	{
		var ps = new PropertyStore(testFilePath);
		Assert.That(() => ps.Dispose(), Throws.Nothing);
	}

	[Test]
	public void PropertyStore_DoubleDispose_DoesNotThrow()
	{
		var ps = new PropertyStore(testFilePath);
		ps.Dispose();
		Assert.That(() => ps.Dispose(), Throws.Nothing);
	}

	[Test]
	public void PropertyStore_PropertyDescriptionDictionary_ContainsKey_WorksCorrectly()
	{
		using var ps = new PropertyStore(testFilePath);
		var descriptions = ps.Descriptions;
		if (ps.Keys.Count > 0)
		{
			var firstKey = ps.Keys.First();
			Assert.That(descriptions.ContainsKey(firstKey), Is.True);
		}
	}

	[Test]
	public void PropertyStore_PropertyDescriptionDictionary_TryGetValue_WorksCorrectly()
	{
		using var ps = new PropertyStore(testFilePath);
		var descriptions = ps.Descriptions;
		if (ps.Keys.Count > 0)
		{
			var firstKey = ps.Keys.First();
			var result = descriptions.TryGetValue(firstKey, out var description);
			Assert.That(result, Is.True);
			Assert.That(description, Is.Not.Null);
		}
	}

	[Test]
	public void PropertyStore_PropertyDescriptionDictionary_Indexer_WorksCorrectly()
	{
		using var ps = new PropertyStore(testFilePath);
		var descriptions = ps.Descriptions;
		if (ps.Keys.Count > 0)
		{
			var firstKey = ps.Keys.First();
			var description = descriptions[firstKey];
			Assert.That(description, Is.Not.Null);
		}
	}

	[Test]
	public void PropertyStore_PropertyDescriptionDictionary_Values_ReturnsAllDescriptions()
	{
		using var ps = new PropertyStore(testFilePath);
		var descriptions = ps.Descriptions;
		var values = descriptions.Values;
		Assert.That(values, Is.Not.Null);
		Assert.That(values.Count(), Is.EqualTo(ps.Count));
	}

	[Test]
	public void PropertyStore_PropertyDescriptionDictionary_CanEnumerate()
	{
		using var ps = new PropertyStore(testFilePath);
		var descriptions = ps.Descriptions;
		var count = 0;
		foreach (var kvp in descriptions)
		{
			count++;
		}
		Assert.That(count, Is.EqualTo(ps.Count));
	}
}