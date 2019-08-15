using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Valid values for the <see cref="OBJECT_TYPE_LIST.level"/> field.</summary>
	public enum ObjectTypeListLevel : ushort
	{
		/// <summary>Indicates the object itself at level zero.</summary>
		ACCESS_OBJECT_GUID = 0,

		/// <summary>Indicates a property set at level one.</summary>
		ACCESS_PROPERTY_SET_GUID = 1,

		/// <summary>Indicates a property at level two.</summary>
		ACCESS_PROPERTY_GUID = 2,

		/// <summary>Indicates a property set at the max level.</summary>
		ACCESS_MAX_LEVEL = 4,
	}

	/// <summary>
	/// The <c>OBJECT_TYPE_LIST</c> structure identifies an object type element in a hierarchy of object types. The AccessCheckByType
	/// functions use an array of <c>OBJECT_TYPE_LIST</c> structures to define a hierarchy of an object and its subobjects, such as property
	/// sets and properties.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_object_type_list
	// typedef struct _OBJECT_TYPE_LIST { WORD Level; WORD Sbz; GUID *ObjectType; } OBJECT_TYPE_LIST, *POBJECT_TYPE_LIST;
	[PInvokeData("winnt.h", MSDNShortId = "c729ff1a-65f3-4f6f-84dd-5700aead75ce")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 2)]
	public unsafe struct OBJECT_TYPE_LIST
	{
		/// <summary>
		/// Specifies the level of the object type in the hierarchy of an object and its subobjects. Level zero indicates the object itself.
		/// Level one indicates a subobject of the object, such as a property set. Level two indicates a subobject of the level one
		/// subobject, such as a property. There can be a maximum of five levels numbered zero through four.
		/// </summary>
		public ObjectTypeListLevel level;

		/// <summary>Should be zero. Reserved for future use.</summary>
		public ushort Sbz;

		/// <summary>A pointer to the GUID for the object or subobject.</summary>
		public Guid* guidObjectType;

		/// <summary>Initializes a new instance of the <see cref="OBJECT_TYPE_LIST"/> struct.</summary>
		/// <param name="level">The level of the object type in the hierarchy of an object and its subobjects.</param>
		/// <param name="objType">The object or subobject identifier.</param>
		public OBJECT_TYPE_LIST(ObjectTypeListLevel level, in Guid objType = default)
		{
			Sbz = 0;
			this.level = level;
			unsafe
			{
				if (objType == default)
					fixed (Guid* pGuid = &Guid.Empty)
					{
						guidObjectType = pGuid;
					}
				else
					fixed (Guid* pGuid = &objType)
					{
						guidObjectType = pGuid;
					}
			}
		}

		/// <summary>Represents an object that is itself.</summary>
		public static readonly OBJECT_TYPE_LIST Self = new OBJECT_TYPE_LIST();
	}
}