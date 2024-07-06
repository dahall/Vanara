namespace Vanara.PInvoke;

public static partial class PowrProf
{
	/// <summary>
	/// Sent with a power setting event and contains data about the specific change. For more information, see Registering for Power Events and
	/// Power Setting GUIDs.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-powerbroadcast_setting typedef struct { GUID PowerSetting; DWORD
	// DataLength; UCHAR Data[1]; } POWERBROADCAST_SETTING, *PPOWERBROADCAST_SETTING;
	[PInvokeData("winuser.h", MSDNShortId = "NS:winuser.POWERBROADCAST_SETTING")]
	[StructLayout(LayoutKind.Sequential)]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<POWERBROADCAST_SETTING>), nameof(DataLength))]
	public struct POWERBROADCAST_SETTING
	{
		/// <summary>Indicates the power setting for which this notification is being delivered. For more info, see Power Setting GUIDs.</summary>
		public Guid PowerSetting;

		/// <summary>The size in bytes of the data in the <c>Data</c> member.</summary>
		public uint DataLength;

		/// <summary>The new value of the power setting. The type and possible values for this member depend on <c>PowerSettng.</c></summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] Data;

		/// <summary>Gets the data as an enumeration value.</summary>
		/// <typeparam name="TEnum">The type of the enum.</typeparam>
		/// <returns>The enum value in <see cref="Data"/>.</returns>
		public TEnum GetEnumData<TEnum>() where TEnum : unmanaged, Enum => EnumExtensions.ToEnum<TEnum>(Data);
	}
}