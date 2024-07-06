namespace Vanara.PInvoke;

public static partial class PowrProf
{
	#region Well-known power schemes

	/// <summary>
	/// Maximum Power Savings - indicates that very aggressive power savings measures will be used to help stretch battery life.
	/// </summary>
	public readonly static Guid GUID_MAX_POWER_SAVINGS = new("{A1841308-3541-4FAB-BC81-F71556F20B4A}");

	/// <summary>No Power Savings - indicates that almost no power savings measures will be used.</summary>
	public readonly static Guid GUID_MIN_POWER_SAVINGS = new("{8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c}");

	/// <summary>Typical Power Savings - indicates that fairly aggressive power savings measures will be used.</summary>
	public static readonly Guid GUID_TYPICAL_POWER_SAVINGS = new("{381B4222-F694-41F0-9685-FF5BB260DF2E}");

	/// <summary>
	/// This is a special GUID that represents "every power scheme". That is, it indicates that any write to this power scheme should be
	/// reflected to every scheme present. This allows users to write a single setting once and have it apply to all schemes. They can
	/// then apply custom settings to specific power schemes that they care about.
	/// </summary>
	public static readonly Guid ALL_POWERSCHEMES_GUID = new("{68A1E95E-13EA-41E1-8011-0C496CA490B0}");

	/// <summary>
	/// Define a special GUID which will be used to define the active power scheme. User will register for this power setting GUID, and
	/// when the active power scheme changes, they'll get a callback where the payload is the GUID representing the active power-scheme.
	/// </summary>
	public static readonly Guid GUID_ACTIVE_POWERSCHEME = new("{31F9F286-5084-42FE-B720-2B0264993763}");

	#endregion

	#region Adaptive power behavior settings

	/// <summary>{8619B916-E004-4dd8-9B66-DAE86F806698}</summary>
	public static readonly Guid GUID_ADAPTIVE_POWER_BEHAVIOR_SUBGROUP = new("{8619b916-e004-4dd8-9b66-dae86f806698}");

	/// <summary>Defines a guid to control Standby Reserve Time.</summary>
	public static readonly Guid GUID_STANDBY_RESERVE_TIME = new("{468FE7E5-1158-46EC-88bc-5b96c9e44fd0}");

	/// <summary>Defines a guid to control Standby Reset Percentage.</summary>
	public static readonly Guid GUID_STANDBY_RESET_PERCENT = new("{49cb11a5-56e2-4afb-9d38-3df47872e21b}");

	/// <summary>Specifies the input timeout (in seconds) to be used to indicate UserUnkown. Value 0 effectively disables this feature.</summary>
	public static readonly Guid GUID_NON_ADAPTIVE_INPUT_TIMEOUT = new("{5ADBBFBC-074E-4da1-BA38-DB8B36B2C8F3}");

	/// <summary>Specifies a change in the input controller(s) global system's state: e.g. enabled, suppressed, filtered.</summary>
	public static readonly Guid GUID_ADAPTIVE_INPUT_CONTROLLER_STATE = new("{0E98FAE9-F45A-4DE1-A757-6031F197F6EA}");

	/// <summary>Defines a guid to control Standby Budget Grace Period.</summary>
	public static readonly Guid GUID_STANDBY_BUDGET_GRACE_PERIOD = new("{60C07FE1-0556-45CF-9903-D56E32210242}");

	/// <summary>Defines a guid to control Standby Budget Percent.</summary>
	public static readonly Guid GUID_STANDBY_BUDGET_PERCENT = new("{9fe527be-1b70-48da-930d-7bcf17b44990}");

	/// <summary>Defines a guid to control Standby Reserve Grace Period.</summary>
	public static readonly Guid GUID_STANDBY_RESERVE_GRACE_PERIOD = new("{c763ee92-71e8-4127-84eb-f6ed043a3e3d}");

	/// <summary>Defines a guid to control User Presence Prediction mode.</summary>
	public static readonly Guid GUID_USER_PRESENCE_PREDICTION = new("{82011705-FB95-4D46-8D35-4042B1D20DEF}");

	#endregion

	#region Battery Discharge Settings

	/// <summary>Specifies the subgroup which will contain all of the battery discharge settings for a single policy.</summary>
	public static readonly Guid GUID_BATTERY_SUBGROUP = new("{E73A048D-BF27-4F12-9731-8B2076E8891F}");

	/// <summary></summary>
	public static readonly Guid GUID_BATTERY_DISCHARGE_ACTION_0 = new("{637EA02F-BBCB-4015-8E2C-A1C7B9C0B546}");

	/// <summary></summary>
	public static readonly Guid GUID_BATTERY_DISCHARGE_ACTION_1 = new("{D8742DCB-3E6A-4B3C-B3FE-374623CDCF06}");

	/// <summary></summary>
	public static readonly Guid GUID_BATTERY_DISCHARGE_ACTION_2 = new("{421CBA38-1A8E-4881-AC89-E33A8B04ECE4}");

	/// <summary></summary>
	public static readonly Guid GUID_BATTERY_DISCHARGE_ACTION_3 = new("{80472613-9780-455E-B308-72D3003CF2F8}");

	/// <summary></summary>
	public static readonly Guid GUID_BATTERY_DISCHARGE_FLAGS_0 = new("{5dbb7c9f-38e9-40d2-9749-4f8a0e9f640f}");

	/// <summary></summary>
	public static readonly Guid GUID_BATTERY_DISCHARGE_FLAGS_1 = new("{bcded951-187b-4d05-bccc-f7e51960c258}");

	/// <summary></summary>
	public static readonly Guid GUID_BATTERY_DISCHARGE_FLAGS_2 = new("{7fd2f0c4-feb7-4da3-8117-e3fbedc46582}");

	/// <summary></summary>
	public static readonly Guid GUID_BATTERY_DISCHARGE_FLAGS_3 = new("{73613ccf-dbfa-4279-8356-4935f6bf62f3}");

	/// <summary></summary>
	public static readonly Guid GUID_BATTERY_DISCHARGE_LEVEL_0 = new("{9A66D8D7-4FF7-4EF9-B5A2-5A326CA2A469}");

	/// <summary></summary>
	public static readonly Guid GUID_BATTERY_DISCHARGE_LEVEL_1 = new("{8183BA9A-E910-48DA-8769-14AE6DC1170A}");

	/// <summary></summary>
	public static readonly Guid GUID_BATTERY_DISCHARGE_LEVEL_2 = new("{07A07CA2-ADAF-40D7-B077-533AADED1BFA}");

	/// <summary></summary>
	public static readonly Guid GUID_BATTERY_DISCHARGE_LEVEL_3 = new("{58AFD5A6-C2DD-47D2-9FBF-EF70CC5C5965}");

	#endregion

	#region Harddisk settings

	/// <summary>Specifies the subgroup which will contain all of the hard disk settings for a single policy.</summary>
	public static readonly Guid GUID_DISK_SUBGROUP = new("{0012EE47-9041-4B5D-9B77-535FBA8B1442}");

	/// <summary>Specifies a maximum power consumption level.</summary>
	public static readonly Guid GUID_DISK_MAX_POWER = new("{51dea550-bb38-4bc4-991b-eacf37be5ec8}");

	/// <summary>Specifies (in seconds) how long we wait after the last disk access before we power off the disk.</summary>
	public static readonly Guid GUID_DISK_POWERDOWN_TIMEOUT = new("{6738E2C4-E8A5-4A42-B16A-E040E769756E}");

	/// <summary>
	/// Specifies (in milliseconds) how long we wait after the last disk access before we power off the disk taking into account if IO
	/// coalescing is active.
	/// </summary>
	public static readonly Guid GUID_DISK_IDLE_TIMEOUT = new("{58E39BA8-B8E6-4EF6-90D0-89AE32B258D6}");

	/// <summary>Specifies the amount of contiguous disk activity time to ignore when calculating disk idleness.</summary>
	public static readonly Guid GUID_DISK_BURST_IGNORE_THRESHOLD = new("{80e3c60e-bb94-4ad8-bbe0-0d3195efc663}");

	/// <summary>Specifies if the operating system should use adaptive timers (based on previous behavior) to power down the disk,</summary>
	public static readonly Guid GUID_DISK_ADAPTIVE_POWERDOWN = new("{396A32E1-499A-40B2-9124-A96AFE707667}");

	/// <summary/>
	public static readonly Guid GUID_ENABLE_SWITCH_FORCED_SHUTDOWN = new("{833a6b62-dfa4-46d1-82f8-e09e34d029d6}");

	#endregion

	#region Energy Saver settings

	/// <summary>Specifies the subgroup which will contain all of the Energy Saver settings for a single policy.</summary>
	public static readonly Guid GUID_ENERGY_SAVER_SUBGROUP = new("{DE830923-A562-41AF-A086-E3A2C6BAD2DA}");

	/// <summary>Indicates if Energy Saver is ON or OFF.</summary>
	[CorrespondingType(typeof(uint))]
	public static readonly Guid GUID_POWER_SAVING_STATUS = new("{e00958c0-c213-4ace-ac77-fecced2eeea5}");

	/// <summary>Defines a guid to engage Energy Saver at specific battery charge level</summary>
	public static readonly Guid GUID_ENERGY_SAVER_BATTERY_THRESHOLD = new("{E69653CA-CF7F-4F05-AA73-CB833FA90AD4}");

	/// <summary>Defines a guid to specify display brightness weight when Energy Saver is engaged</summary>
	public static readonly Guid GUID_ENERGY_SAVER_BRIGHTNESS = new("{13D09884-F74E-474A-A852-B6BDE8AD03A8}");

	/// <summary>Defines a guid to specify the Energy Saver policy</summary>
	public static readonly Guid GUID_ENERGY_SAVER_POLICY = new("{5C5BB349-AD29-4ee2-9D0B-2B25270F7A81}");

	/// <summary>Defines a guid that notifies when the Energy saver status has changed.</summary>
	public static readonly Guid GUID_ENERGY_SAVER_STATUS = new("550E8400-E29B-41D4-A716-446655440000");

	#endregion

	#region Graphics configuration

	/// <summary>Specified the subgroup which contains all in-box graphics settings.</summary>
	public static readonly Guid GUID_GRAPHICS_SUBGROUP = new("{5fb4938d-1ee8-4b0f-9a3c-5036b0ab995c}");

	/// <summary>Specifies the GPU preference policy.</summary>
	public static readonly Guid GUID_GPU_PREFERENCE_POLICY = new("{dd848b2a-8a5d-4451-9ae2-39cd41658f6c}");

	#endregion

	#region Idle resiliency settings

	/// <summary>Specifies the subgroup which will contain all of the idle resiliency settings for a single policy.</summary>
	public static readonly Guid GUID_IDLE_RESILIENCY_SUBGROUP = new("{2E601130-5351-4d9d-8E04-252966BAD054}");

	/// <summary>
	/// Specifies (in milliseconds) how long we wait after the last disk access before we power off the disk in case when IO coalescing
	/// is active.
	/// </summary>
	public static readonly Guid GUID_DISK_COALESCING_POWERDOWN_TIMEOUT = new("{C36F0EB4-2988-4a70-8EEE-0884FC2C2433}");

	/// <summary>Specifies the deep sleep policy setting. This is intended to override the GUID_IDLE_RESILIENCY_PERIOD</summary>
	public static readonly Guid GUID_DEEP_SLEEP_ENABLED = new("{d502f7ee-1dc7-4efd-a55d-f04b6f5c0545}");

	/// <summary>
	/// Specifies the platform idle state index associated with idle resiliency period.
	///
	/// N.B. This power setting is DEPRECATED.
	/// </summary>
	public static readonly Guid GUID_DEEP_SLEEP_PLATFORM_STATE = new("{d23f2fb8-9536-4038-9c94-1ce02e5c2152}");

	/// <summary>
	/// Specifies the maximum clock interrupt period (in ms)
	///
	/// N.B. This power setting is DEPRECATED.
	/// </summary>
	public static readonly Guid GUID_IDLE_RESILIENCY_PERIOD = new("{C42B79AA-AA3A-484b-A98F-2CF32AA90A28}");

	/// <summary>
	/// Specifies (in seconds) how long we wait after the CS Enter before we deactivate execution required request.
	/// -1 : implies execution power requests are never deactivated
	///
	/// Note: Execution required power requests are mapped into system required power requests on non-AoAc machines and this value has no effect.
	/// </summary>
	public static readonly Guid GUID_EXECUTION_REQUIRED_REQUEST_TIMEOUT = new("{3166BC41-7E98-4e03-B34E-EC0F5F2B218E}");

	#endregion

	#region Interrupt steering settings

	/// <summary>Specifies if forced shutdown should be used for all button and lid initiated shutdown actions.</summary>
	public static readonly Guid GUID_INTSTEER_SUBGROUP = new("{48672f38-7a9a-4bb2-8bf8-3d85be19de4e}");

	/// <summary/>
	public static readonly Guid GUID_INTSTEER_LOAD_PER_PROC_TRIGGER = new("{73cde64d-d720-4bb2-a860-c755afe77ef2}");

	/// <summary/>
	public static readonly Guid GUID_INTSTEER_MODE = new("{2bfc24f9-5ea2-4801-8213-3dbae01aa39d}");

	/// <summary/>
	public static readonly Guid GUID_INTSTEER_TIME_UNPARK_TRIGGER = new("{d6ba4903-386f-4c2c-8adb-5c21b3328d25}");

	#endregion

	#region No Subgroup

	/// <summary>
	/// This is a special GUID that represents "no subgroup" of settings. That is, it indicates that settings that are in the root of the
	/// power policy hierarchy as opposed to settings that are buried under a subgroup of settings. This should be used when querying for
	/// power settings that may not fall into a subgroup.
	/// </summary>
	public static readonly Guid NO_SUBGROUP_GUID = new("{FEA3413E-7E05-4911-9A71-700331F1C294}");

	/// <summary>
	/// <para>
	/// This is a special GUID that represents a 'personality' that each power scheme will have. In other words, each power scheme will have
	/// this key indicating "I'm most like *this* base power scheme." This individual setting will have one of three settings:
	/// </para>
	/// <list type="bullet">
	/// <item>GUID_MAX_POWER_SAVINGS</item>
	/// <item>GUID_MIN_POWER_SAVINGS</item>
	/// <item>GUID_TYPICAL_POWER_SAVINGS</item>
	/// </list>
	/// <para>This allows several features:</para>
	/// <list type="number">
	/// <item>
	/// Drivers and applications can register for notification of this GUID. So when this power scheme is activated, this GUID's setting will
	/// be sent across the system and drivers/applications can see "GUID_MAX_POWER_SAVINGS" which will tell them in a generic fashion "get
	/// real aggressive about conserving power".
	/// </item>
	/// <item>
	/// <para>
	/// UserB may install a driver or application which creates power settings, and UserB may modify those power settings. Now UserA logs in.
	/// How does he see those settings? They simply don't exist in his private power key. Well they do exist over in the system power key.
	/// When we enumerate all the power settings in this system power key and don't find a corresponding entry in the user's private power
	/// key, then we can go look at this "personality" key in the users power scheme. We can then go get a default value for the power
	/// setting, depending on which "personality" power scheme is being operated on.
	/// </para>
	/// <para>Here's an example:</para>
	/// <list type="number">
	/// <item>UserB installs an application that creates a power setting Seetting1</item>
	/// <item>UserB changes Setting1 to have a value of 50 because that's one of the possible settings available for setting1.</item>
	/// <item>UserB logs out</item>
	/// <item>
	/// UserA logs in and his active power scheme is some custom scheme that was derived from the GUID_TYPICAL_POWER_SAVINGS. But remember
	/// that UserA has no setting1 in his private power key.
	/// </item>
	/// <item>When activating UserA's selected power scheme, all power settings in the system power key will be enumerated (including Setting1).</item>
	/// <item>The power manager will see that UserA has no Setting1 power setting in his private power scheme.</item>
	/// <item>The power manager will query UserA's power scheme for its personality and retrieve GUID_TYPICAL_POWER_SAVINGS.</item>
	/// <item>
	/// The power manager then looks in Setting1 in the system power key and looks in its set of default values for the corresponding value
	/// for GUID_TYPICAL_POWER_SAVINGS power schemes.
	/// </item>
	/// <item>This derived power setting is applied.</item>
	/// </list>
	/// </item>
	/// </list>
	/// </summary>
	[CorrespondingType(typeof(Guid))]
	public static readonly Guid GUID_POWERSCHEME_PERSONALITY = new("{245D8541-3943-4422-B025-13A784F679B7}");

	/// <summary>
	/// Specifies the behavior of the system when we wake from standby or hibernate. If this is set, then we will cause the console to
	/// lock after we resume.
	/// </summary>
	public static readonly Guid GUID_LOCK_CONSOLE_ON_WAKE = new("{0E796BDB-100D-47D6-A2D5-F7D2DAA51F51}");

	/// <summary>Specifies standby connectivity preference.</summary>
	public static readonly Guid GUID_CONNECTIVITY_IN_STANDBY = new("{F15576E8-98B7-4186-B944-EAFA664402D9}");

	/// <summary>Specifies the mode for disconnected standby.</summary>
	public static readonly Guid GUID_DISCONNECTED_STANDBY_MODE = new("{68AFB2D9-EE95-47A8-8F50-4115088073B1}");

	/// <summary>Specifies whether to use the "performance" or "conservative" timeouts for device idle management.</summary>
	public static readonly Guid GUID_DEVICE_IDLE_POLICY = new("{4faab71a-92e5-4726-b531-224559672d19}");

	#endregion

	#region PCI Express Power Management

	/// <summary>Specifies the subgroup which will contain all of the PCI Express settings for a single policy.</summary>
	public static readonly Guid GUID_PCIEXPRESS_SETTINGS_SUBGROUP = new("{501a4d13-42af-4429-9fd1-a8218c268e20}");

	/// <summary>Specifies the PCI Express ASPM power policy.</summary>
	public static readonly Guid GUID_PCIEXPRESS_ASPM_POLICY = new("{ee12f906-d277-404b-b6da-e5fa1a576df5}");

	#endregion

	#region Processor power settings

	/// <summary>Specifies the subgroup which will contain all of the processor settings for a single policy.</summary>
	public static readonly Guid GUID_PROCESSOR_SETTINGS_SUBGROUP = new("{54533251-82BE-4824-96C1-47B60B740D00}");

	/// <summary>
	/// Specifies a percentage (between 0 and 100) that the processor frequency should never go above. For example, if this value is set
	/// to 80, then the processor frequency will never be throttled above 80 percent of its maximum frequency by the system.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_THROTTLE_MAXIMUM = new("{BC5038F7-23E0-4960-96DA-33ABAF5935EC}");

	/// <summary>
	/// Specifies a percentage (between 0 and 100) that the processor frequency should never go above for Processor Power Efficiency
	/// Class 1. For example, if this value is set to 80, then the processor frequency will never be throttled above 80 percent of its
	/// maximum frequency by the system.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_THROTTLE_MAXIMUM_1 = new("{BC5038F7-23E0-4960-96DA-33ABAF5935ED}");

	/// <summary>
	/// Specifies a percentage (between 0 and 100) that the processor frequency should not drop below. For example, if this value is set
	/// to 50, then the processor frequency will never be throttled below 50 percent of its maximum frequency by the system.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_THROTTLE_MINIMUM = new("{893DEE8E-2BEF-41E0-89C6-B55D0929964C}");

	/// <summary>
	/// Specifies a percentage (between 0 and 100) that the processor frequency should not drop below for Processor Power Efficiency
	/// Class 1. For example, if this value is set to 50, then the processor frequency will never be throttled below 50 percent of its
	/// maximum frequency by the system.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_THROTTLE_MINIMUM_1 = new("{893DEE8E-2BEF-41E0-89C6-B55D0929964D}");

	/// <summary>Specifies the maximum processor frequency (expressed in MHz).</summary>
	public static readonly Guid GUID_PROCESSOR_FREQUENCY_LIMIT = new("{75b0ae3f-bce0-45a7-8c89-c9611c25e100}");

	/// <summary>{75B0AE3F-BCE0-45a7-8C89-C9611C25E101}</summary>
	public static readonly Guid GUID_PROCESSOR_FREQUENCY_LIMIT_1 = new("{75b0ae3f-bce0-45a7-8c89-c9611c25e101}");

	/// <summary>Specifies whether throttle states are allowed to be used even when performance states are available.</summary>
	public static readonly Guid GUID_PROCESSOR_ALLOW_THROTTLING = new("{3b04d4fd-1cc7-4f23-ab1c-d1337819c4bb}");

	/// <summary>Specifies processor power settings for CState policy data {68F262A7-F621-4069-B9A5-4874169BE23C}</summary>
	public static readonly Guid GUID_PROCESSOR_IDLESTATE_POLICY = new("{68f262a7-f621-4069-b9a5-4874169be23c}");

	/// <summary>Specifies processor power settings for PerfState policy data {BBDC3814-18E9-4463-8A55-D197327C45C0}</summary>
	public static readonly Guid GUID_PROCESSOR_PERFSTATE_POLICY = new("{BBDC3814-18E9-4463-8A55-D197327C45C0}");

	/// <summary>
	/// Specifies the performance target floor of a Processor Power Efficiency Class 0 processor when the system unparks Processor Power
	/// Efficiency Class 1 processor(s).
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_CLASS0_FLOOR_PERF = new("{fddc842b-8364-4edc-94cf-c17f60de1c80}");

	/// <summary>
	/// Specifies the initial performance target of a Processor Power Efficiency Class 1 processor when the system makes a transition up
	/// from zero Processor Power Efficiency Class 1 processors.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_CLASS1_INITIAL_PERF = new("{1facfc65-a930-4bc5-9f38-504ec097bbc0}");

	/// <summary>Specifies the factor by which to decrease affinity history on each core after each check.</summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_AFFINITY_HISTORY_DECREASE_FACTOR = new("{8f7b45e3-c393-480a-878c-f67ac3d07082}");

	/// <summary>
	/// Specifies the threshold above which a core is considered to have had significant affinitized work scheduled to it while parked.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_AFFINITY_HISTORY_THRESHOLD = new("{5b33697b-e89d-4d38-aa46-9e7dfb7cd2f9}");

	/// <summary>Specifies the weighting given to each occurrence where affinitized work was scheduled to a parked core.</summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_AFFINITY_WEIGHTING = new("{e70867f1-fa2f-4f4e-aea1-4d8a0ba23b20}");

	/// <summary>Specifies, either as ideal, single or rocket, how aggressive core parking is when cores must be parked.</summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_DECREASE_POLICY = new("{71021b41-c749-4d21-be74-a00f335d582b}");

	/// <summary>
	/// Specifies the utilization threshold in percent that must be crossed in order to park cores.
	///
	/// N.B. This power setting is DEPRECATED.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_DECREASE_THRESHOLD = new("{68dd2f27-a4ce-4e11-8487-3794e4135dfa}");

	/// <summary>Specifies, in milliseconds, the minimum amount of time a core must be unparked before it can be parked.</summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_DECREASE_TIME = new("{dfd10d17-d5eb-45dd-877a-9a34ddd15c82}");

	/// <summary>Specifies, either as ideal, single or rocket, how aggressive core parking is when cores must be unparked.</summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_INCREASE_POLICY = new("{c7be0679-2817-4d69-9d02-519a537ed0c6}");

	/// <summary>
	/// Specifies the utilization threshold in percent that must be crossed in order to un-park cores.
	///
	/// N.B. This power setting is DEPRECATED.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_INCREASE_THRESHOLD = new("{df142941-20f3-4edf-9a4a-9c83d3d717d1}");

	/// <summary>Specifies, in milliseconds, the minimum amount of time a core must be parked before it can be unparked.</summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_INCREASE_TIME = new("{2ddd5a84-5a71-437e-912a-db0b8c788732}");

	/// <summary>Specifies, on a per processor group basis, the maximum number of cores that can be kept unparked.</summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_MAX_CORES = new("{ea062031-0e34-4ff1-9b6d-eb1059334028}");

	/// <summary>
	/// Specifies, on a per processor group basis, the maximum number of cores that can be kept unparked for Processor Power Efficiency
	/// Class 1.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_MAX_CORES_1 = new("{ea062031-0e34-4ff1-9b6d-eb1059334029}");

	/// <summary>Specifies, on a per processor group basis, the minimum number of cores that must be kept unparked.</summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_MIN_CORES = new("{0cc5b647-c1df-4637-891a-dec35c318583}");

	/// <summary>
	/// Specifies, on a per processor group basis, the minimum number of cores that must be kept unparked in Processor Power Efficiency
	/// Class 1.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_MIN_CORES_1 = new("{0cc5b647-c1df-4637-891a-dec35c318584}");

	/// <summary>
	/// Specifies the factor by which to decrease the over utilization history on each core after the current performance check.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_OVER_UTILIZATION_HISTORY_DECREASE_FACTOR = new("{1299023c-bc28-4f0a-81ec-d3295a8d815d}");

	/// <summary>Specifies the threshold above which a core is considered to have been recently over utilized while parked.</summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_OVER_UTILIZATION_HISTORY_THRESHOLD = new("{9ac18e92-aa3c-4e27-b307-01ae37307129}");

	/// <summary>Specifies, in percentage, the busy threshold that must be met before a parked core is considered over utilized.</summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_OVER_UTILIZATION_THRESHOLD = new("{943c8cb6-6f93-4227-ad87-e9a3feec08d1}");

	/// <summary>Specifies the weighting given to each occurrence where a parked core is found to be over utilized.</summary>
	public static readonly Guid GUID_PROCESSOR_CORE_PARKING_OVER_UTILIZATION_WEIGHTING = new("{8809c2d8-b155-42d4-bcda-0d345651b1db}");

	/// <summary>Specifies whether the core parking engine should distribute processor utility.</summary>
	public static readonly Guid GUID_PROCESSOR_DISTRIBUTE_UTILITY = new("{e0007330-f589-42ed-a401-5ddb10e785d3}");

	/// <summary>Specifies whether the processor should perform duty cycling.</summary>
	public static readonly Guid GUID_PROCESSOR_DUTY_CYCLING = new("{4e4450b3-6179-4e91-b8f1-5bb9938f81a1}");

	/// <summary>
	/// Specifies the performance level (in units of Processor Power Efficiency Class 0 processor performance) at which the number of
	/// Processor Power Efficiency Class 1 processors is decreased.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_HETERO_DECREASE_THRESHOLD = new("{f8861c27-95e7-475c-865b-13c0cb3f9d6b}");

	/// <summary>
	/// Specifies the number of perf check cycles required to decrease the number of Processor Power Efficiency Class 1 processors.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_HETERO_DECREASE_TIME = new("{7f2492b6-60b1-45e5-ae55-773f8cd5caec}");

	/// <summary>
	/// Specifies the performance level (in units of Processor Power Efficiency Class 0 processor performance) at which the number of
	/// Processor Power Efficiency Class 1 processors is increased.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_HETERO_INCREASE_THRESHOLD = new("{b000397d-9b0b-483d-98c9-692a6060cfbf}");

	/// <summary>
	/// Specifies the number of perf check cycles required to increase the number of Processor Power Efficiency Class 1 processors.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_HETERO_INCREASE_TIME = new("{4009efa7-e72d-4cba-9edf-91084ea8cbc3}");

	/// <summary>Specifies the current active heterogeneous policy.</summary>
	public static readonly Guid GUID_PROCESSOR_HETEROGENEOUS_POLICY = new("{7f2f5cfa-f10c-4823-b5e1-e93ae85f46b5}");

	/// <summary>Specifies if idle state promotion and demotion values should be scaled based on the current performance state.</summary>
	public static readonly Guid GUID_PROCESSOR_IDLE_ALLOW_SCALING = new("{6C2993B0-8F48-481f-BCC6-00DD2742AA06}");

	/// <summary>Specifies the upper busy threshold that must be met before demoting the processor to a lighter idle state (in percentage).</summary>
	public static readonly Guid GUID_PROCESSOR_IDLE_DEMOTE_THRESHOLD = new("{4b92d758-5a24-4851-a470-815d78aee119}");

	/// <summary>Specifies if idle states should be disabled.</summary>
	public static readonly Guid GUID_PROCESSOR_IDLE_DISABLE = new("{5d76a2ca-e8c0-402f-a133-2158492d58ad}");

	/// <summary>Specifies the lower busy threshold that must be met before promoting the processor to a deeper idle state (in percentage).</summary>
	public static readonly Guid GUID_PROCESSOR_IDLE_PROMOTE_THRESHOLD = new("{7b224883-b3cc-4d79-819f-8374152cbe7c}");

	/// <summary>
	/// Specifies the deepest idle state type that should be used. If this value is set to zero, this setting is ignored. Values higher
	/// than supported by the processor then this setting has no effect.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_IDLE_STATE_MAXIMUM = new("{9943e905-9a30-4ec1-9b99-44dd3b76f7a2}");

	/// <summary>
	/// Specifies the time that elapsed since the last idle state promotion or demotion before idle states may be promoted or demoted
	/// again (in microseconds).
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_IDLE_TIME_CHECK = new("{C4581C31-89AB-4597-8E2B-9C9CAB440E6B}");

	/// <summary>Specifies the minimum unparked processors when a latency hint is active (in a percentage).</summary>
	public static readonly Guid GUID_PROCESSOR_LATENCY_HINT_MIN_UNPARK = new("{616cdaa5-695e-4545-97ad-97dc2d1bdd88}");

	/// <summary>
	/// Specifies the minimum unparked processors when a latency hint is active for Processor Power Efficiency Class 1 (in a percentage).
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_LATENCY_HINT_MIN_UNPARK_1 = new("{616cdaa5-695e-4545-97ad-97dc2d1bdd89}");

	/// <summary>Specify the busy threshold that must be met when calculating the concurrency of a node's workload.</summary>
	public static readonly Guid GUID_PROCESSOR_PARKING_CONCURRENCY_THRESHOLD = new("{2430ab6f-a520-44a2-9601-f7f23b5134b1}");

	/// <summary>Specifies if at least one processor per core should always remain unparked.</summary>
	public static readonly Guid GUID_PROCESSOR_PARKING_CORE_OVERRIDE = new("{a55612aa-f624-42c6-a443-7397d064c04f}");

	/// <summary>Specify the percentage utilization used to calculate the distribution concurrency.</summary>
	public static readonly Guid GUID_PROCESSOR_PARKING_DISTRIBUTION_THRESHOLD = new("{4bdaf4e9-d103-46d7-a5f0-6280121616ef}");

	/// <summary>Specify the busy threshold that must be met by all cores in a concurrency set to unpark an extra core.</summary>
	public static readonly Guid GUID_PROCESSOR_PARKING_HEADROOM_THRESHOLD = new("{f735a673-2066-4f80-a0c5-ddee0cf1bf5d}");

	/// <summary>Specifies what performance state a processor should enter when first parked.</summary>
	public static readonly Guid GUID_PROCESSOR_PARKING_PERF_STATE = new("{447235c7-6a8d-4cc0-8e24-9eaf70b96e2b}");

	/// <summary>
	/// Specifies what performance state a processor should enter when first parked for Processor Power Efficiency Class 1.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PARKING_PERF_STATE_1 = new("{447235c7-6a8d-4cc0-8e24-9eaf70b96e2c}");

	/// <summary>Specifies the window over which the processor should observe utilization when operating in autonomous mode, in microseconds.</summary>
	public static readonly Guid GUID_PROCESSOR_PERF_AUTONOMOUS_ACTIVITY_WINDOW = new("{CFEDA3D0-7697-4566-A922-A9086CD49DFA}");

	/// <summary>Specifies whether or not a processor should autonomously select its operating performance state.</summary>
	public static readonly Guid GUID_PROCESSOR_PERF_AUTONOMOUS_MODE = new("{8baa4a8a-14c6-4451-8e8b-14bdbd197537}");

	/// <summary>
	/// Specifies how a processor opportunistically increases frequency above the maximum when operating conditions allow it to do so safely.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_BOOST_MODE = new("{BE337238-0D82-4146-A960-4F3749D470C7}");

	/// <summary>
	/// Specifies how the processor should manage performance and efficiency trade-offs when boosting frequency above the maximum.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_BOOST_POLICY = new("{45BCC044-D885-43e2-8605-EE0EC6E96B59}");

	/// <summary>
	/// Specifies the number of perf time check intervals to average utility over for core parking.
	///
	/// N.B. This power setting is DEPRECATED.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_CORE_PARKING_HISTORY = new("{77D7F282-8F1A-42cd-8537-45450A839BE8}");

	/// <summary>
	/// Specifies the number of perf time check intervals to average utility over to determine performance decrease.
	///
	/// N.B. This power setting is DEPRECATED.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_DECREASE_HISTORY = new("{0300F6F8-ABD6-45a9-B74F-4908691A40B5}");

	/// <summary>
	/// Specifies, either as ideal, single or rocket, how aggressive performance states should be selected when decreasing the processor
	/// performance state.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_DECREASE_POLICY = new("{40FBEFC7-2E9D-4d25-A185-0CFD8574BAC6}");

	/// <summary>
	/// Specifies, either as ideal, single or rocket, how aggressive performance states should be selected when decreasing the processor
	/// performance state for Processor Power Efficiency Class 1.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_DECREASE_POLICY_1 = new("{40FBEFC7-2E9D-4d25-A185-0CFD8574BAC7}");

	/// <summary>Specifies the decrease busy percentage threshold that must be met before decreasing the processor performance state.</summary>
	public static readonly Guid GUID_PROCESSOR_PERF_DECREASE_THRESHOLD = new("{12a0ab44-fe28-4fa9-b3bd-4b64f44960a6}");

	/// <summary>
	/// Specifies the decrease busy percentage threshold that must be met before decreasing the processor performance state for Processor
	/// Power Efficiency Class 1.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_DECREASE_THRESHOLD_1 = new("{12a0ab44-fe28-4fa9-b3bd-4b64f44960a7}");

	/// <summary>
	/// Specifies, in milliseconds, the minimum amount of time that must elapse after the last processor performance state change before
	/// increasing the processor performance state.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_DECREASE_TIME = new("{d8edeb9b-95cf-4f95-a73c-b061973693c8}");

	/// <summary>
	/// Specifies, in milliseconds, the minimum amount of time that must elapse after the last processor performance state change before
	/// increasing the processor performance state for Processor Power Efficiency Class 1.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_DECREASE_TIME_1 = new("{d8edeb9b-95cf-4f95-a73c-b061973693c9}");

	/// <summary>Specifies the trade-off between performance and energy the processor should make when operating in autonomous mode.</summary>
	public static readonly Guid GUID_PROCESSOR_PERF_ENERGY_PERFORMANCE_PREFERENCE = new("{36687f9e-e3a5-4dbf-b1dc-15eb381c6863}");

	/// <summary>
	/// Specifies the trade-off between performance and energy the processor should make when operating in autonomous mode for class 1 processors.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_ENERGY_PERFORMANCE_PREFERENCE_1 = new("{36687f9e-e3a5-4dbf-b1dc-15eb381c6864}");

	/// <summary>Specifies the number of perf time check intervals to average utility over.</summary>
	public static readonly Guid GUID_PROCESSOR_PERF_HISTORY = new("{7d24baa7-0b84-480f-840c-1b0743c00f5f}");

	/// <summary>Specifies the number of perf time check intervals to average utility over in Processor Power Efficiency Class 1.</summary>
	public static readonly Guid GUID_PROCESSOR_PERF_HISTORY_1 = new("{7d24baa7-0b84-480f-840c-1b0743c00f60}");

	/// <summary>
	/// Specifies the number of perf time check intervals to average utility over to determine performance increase.
	///
	/// N.B. This power setting is DEPRECATED.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_INCREASE_HISTORY = new("{99B3EF01-752F-46a1-80FB-7730011F2354}");

	/// <summary>
	/// Specifies, either as ideal, single or rocket, how aggressive performance states should be selected when increasing the processor
	/// performance state.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_INCREASE_POLICY = new("{465E1F50-B610-473a-AB58-00D1077DC418}");

	/// <summary>
	/// Specifies, either as ideal, single or rocket, how aggressive performance states should be selected when increasing the processor
	/// performance state for Processor Power Efficiency Class 1.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_INCREASE_POLICY_1 = new("{465E1F50-B610-473a-AB58-00D1077DC419}");

	/// <summary>Specifies the increase busy percentage threshold that must be met before increasing the processor performance state.</summary>
	public static readonly Guid GUID_PROCESSOR_PERF_INCREASE_THRESHOLD = new("{06cadf0e-64ed-448a-8927-ce7bf90eb35d}");

	/// <summary>
	/// Specifies the increase busy percentage threshold that must be met before increasing the processor performance state for Processor
	/// Power Efficiency Class 1.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_INCREASE_THRESHOLD_1 = new("{06cadf0e-64ed-448a-8927-ce7bf90eb35e}");

	/// <summary>
	/// Specifies, in milliseconds, the minimum amount of time that must elapse after the last processor performance state change before
	/// increasing the processor performance state.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_INCREASE_TIME = new("{984cf492-3bed-4488-a8f9-4286c97bf5aa}");

	/// <summary>
	/// Specifies, in milliseconds, the minimum amount of time that must elapse after the last processor performance state change before
	/// increasing the processor performance state for Processor Power Efficiency Class 1.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_INCREASE_TIME_1 = new("{984cf492-3bed-4488-a8f9-4286c97bf5ab}");

	/// <summary>
	/// Specifies whether latency sensitivity hints should be taken into account by the perf state engine.
	///
	/// N.B. This power setting is DEPRECATED.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_LATENCY_HINT = new("{0822df31-9c83-441c-a079-0de4cf009c7b}");

	/// <summary>Specifies the processor performance state in response to latency sensitivity hints.</summary>
	public static readonly Guid GUID_PROCESSOR_PERF_LATENCY_HINT_PERF = new("{619b7505-003b-4e82-b7a6-4dd29c300971}");

	/// <summary>
	/// Specifies the processor performance state in response to latency sensitivity hints for Processor Power Efficiency Class 1.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_LATENCY_HINT_PERF_1 = new("{619b7505-003b-4e82-b7a6-4dd29c300972}");

	/// <summary>
	/// Specifies the time, in milliseconds, that must expire before considering a change in the processor performance states or parked
	/// core set.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_PERF_TIME_CHECK = new("{4d2b0152-7d5c-498b-88e2-34345392a2c5}");

	/// <summary>
	/// Processor responsiveness settings
	///
	/// Specifies the number of responsiveness events required to disable responsiveness policy overrides.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_RESPONSIVENESS_DISABLE_THRESHOLD = new("{38b8383d-cce0-4c79-9e3e-56a4f17cc480}");

	/// <summary>
	/// Specifies the number of responsiveness events required to disable responsiveness policy overrides for efficiency class 1 processors.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_RESPONSIVENESS_DISABLE_THRESHOLD_1 = new("{38b8383d-cce0-4c79-9e3e-56a4f17cc481}");

	/// <summary>Specifies the number of consecutive perf checks with a disable hint before responsiveness overrides will be disabled.</summary>
	public static readonly Guid GUID_PROCESSOR_RESPONSIVENESS_DISABLE_TIME = new("{F565999F-3FB0-411a-A226-3F0198DEC130}");

	/// <summary>
	/// Specifies the number of consecutive perf checks with a disable hint before responsiveness overrides will be disabled for
	/// efficiency class 1 processors.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_RESPONSIVENESS_DISABLE_TIME_1 = new("{F565999F-3FB0-411a-A226-3F0198DEC131}");

	/// <summary>Specifies the number of responsiveness events required to enable responsiveness policy overrides.</summary>
	public static readonly Guid GUID_PROCESSOR_RESPONSIVENESS_ENABLE_THRESHOLD = new("{3d44e256-7222-4415-a9ed-9c45fa3dd830}");

	/// <summary>
	/// Specifies the number of responsiveness events required to enable responsiveness policy overrides for efficiency class 1 processors.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_RESPONSIVENESS_ENABLE_THRESHOLD_1 = new("{3d44e256-7222-4415-a9ed-9c45fa3dd831}");

	/// <summary>Specifies the number of consecutive perf checks with a enable hint before responsiveness overrides will be enabled.</summary>
	public static readonly Guid GUID_PROCESSOR_RESPONSIVENESS_ENABLE_TIME = new("{3D915188-7830-49ae-A79A-0FB0A1E5A200}");

	/// <summary>
	/// Specifies the number of consecutive perf checks with a enable hint before responsiveness overrides will be enabled for efficiency
	/// class 1 processors.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_RESPONSIVENESS_ENABLE_TIME_1 = new("{3D915188-7830-49ae-A79A-0FB0A1E5A201}");

	/// <summary>Specifies the ceiling placed on EPP when responsiveness hints are enabled.</summary>
	public static readonly Guid GUID_PROCESSOR_RESPONSIVENESS_EPP_CEILING = new("{4427c73b-9756-4a5c-b84b-c7bda79c7320}");

	/// <summary>Specifies the ceiling placed on EPP when responsiveness hints are enabled for efficiency class 1 processors.</summary>
	public static readonly Guid GUID_PROCESSOR_RESPONSIVENESS_EPP_CEILING_1 = new("{4427c73b-9756-4a5c-b84b-c7bda79c7321}");

	/// <summary>Specifies the floor placed on processor performance when responsiveness hints are enabled.</summary>
	public static readonly Guid GUID_PROCESSOR_RESPONSIVENESS_PERF_FLOOR = new("{CE8E92EE-6A86-4572-BFE0-20C21D03CD40}");

	/// <summary>
	/// Specifies the floor placed on processor performance when responsiveness hints are enabled for efficiency class 1 processors.
	/// </summary>
	public static readonly Guid GUID_PROCESSOR_RESPONSIVENESS_PERF_FLOOR_1 = new("{ce8e92ee-6a86-4572-bfe0-20c21d03cd41}");

	/// <summary>Specifies the scheduling policy for short running threads in a given QoS class.</summary>
	public static readonly Guid GUID_PROCESSOR_SHORT_THREAD_SCHEDULING_POLICY = new("{bae08b81-2d5e-4688-ad6a-13243356654b}");

	/// <summary>Specifies the scheduling policy for threads in a given QoS class.</summary>
	public static readonly Guid GUID_PROCESSOR_THREAD_SCHEDULING_POLICY = new("{93B8B6DC-0698-4d1c-9EE4-0644E900C85D}");

	/// <summary>Specifies various attributes that control processor performance/throttle states.</summary>
	public static readonly Guid GUID_PROCESSOR_THROTTLE_POLICY = new("{57027304-4AF6-4104-9260-E3D95248FC36}");

	/// <summary>
	/// Specifies active vs passive cooling. Although not directly related to processor settings, it is the processor that gets throttled
	/// if we're doing passive cooling, so it is fairly strongly related. {94D3A615-A899-4AC5-AE2B-E4D8F634367F}
	/// </summary>
	public static readonly Guid GUID_SYSTEM_COOLING_POLICY = new("{94D3A615-A899-4AC5-AE2B-E4D8F634367F}");

	#endregion

	#region System sleep settings

	/// <summary>
	/// Specifies the subgroup which will contain all of the sleep settings for a single policy. { 238C9FA8-0AAD-41ED-83F4-97BE242C8F20 }
	/// </summary>
	public static readonly Guid GUID_SLEEP_SUBGROUP = new("{238C9FA8-0AAD-41ED-83F4-97BE242C8F20}");

	/// <summary>
	/// Specifies an idle threshold percentage (0-100). The system must be this idle over a period of time in order to idle to sleep.
	///
	/// N.B. DEPRECATED IN WINDOWS 6.1
	/// </summary>
	public static readonly Guid GUID_SLEEP_IDLE_THRESHOLD = new("{81cd32e0-7833-44f3-8737-7081f38d1f70}");

	/// <summary>Specifies (in seconds) how long we wait after the system is deemed "idle" before moving to standby (S1, S2 or S3).</summary>
	public static readonly Guid GUID_STANDBY_TIMEOUT = new("{29F6C1DB-86DA-48C5-9FDB-F2B67B1F44DA}");

	/// <summary>
	/// Specifies (in seconds) how long the system should go back to sleep after waking unattended. 0 indicates that the standard
	/// standby/hibernate idle policy should be used instead.
	/// </summary>
	public static readonly Guid GUID_UNATTEND_SLEEP_TIMEOUT = new("{7bc4a2f9-d8fc-4469-b07b-33eb785aaca0}");

	/// <summary>Specifies (in seconds) how long we wait after the system is deemed "idle" before moving to hibernate (S4).</summary>
	public static readonly Guid GUID_HIBERNATE_TIMEOUT = new("{9D7815A6-7EE4-497E-8888-515A05F02364}");

	/// <summary>Specifies whether or not Fast S4 should be enabled if the system supports it 94AC6D29-73CE-41A6-809F-6363BA21B47E</summary>
	public static readonly Guid GUID_HIBERNATE_FASTS4_POLICY = new("{94AC6D29-73CE-41A6-809F-6363BA21B47E}");

	/// <summary>
	/// Define a GUID for controlling the criticality of sleep state transitions. Critical sleep transitions do not query applications,
	/// services or drivers before transitioning the platform to a sleep state.
	/// </summary>
	public static readonly Guid GUID_CRITICAL_POWER_TRANSITION = new("{B7A27025-E569-46c2-A504-2B96CAD225A1}");

	/// <summary>The system is entering or exiting away mode. The Data member is a DWORD that indicates the current away mode state.
	/// <para>0x0 - The computer is exiting away mode.</para>
	/// <para>0x1 - The computer is entering away mode.</para></summary>
	[CorrespondingType(typeof(uint))]
	public static readonly Guid GUID_SYSTEM_AWAYMODE = new("{98A7F580-01F7-48AA-9C0F-44352C29E5C0}");

	/// <summary>Defines a guid for enabling/disabling standby (S1-S3) states. This does not affect hibernation (S4).</summary>
	public static readonly Guid GUID_ALLOW_STANDBY_STATES = new("{abfc2519-3608-4c2a-94ea-171b0ed546ab}");

	/// <summary>Defines a guid for enabling/disabling the ability to wake via RTC.</summary>
	public static readonly Guid GUID_ALLOW_RTC_WAKE = new("{BD3B718A-0680-4D9D-8AB2-E1D2B4AC806D}");

	/// <summary>Defines a guid for enabling/disabling legacy RTC mitigations.</summary>
	public static readonly Guid GUID_LEGACY_RTC_MITIGATION = new("{1A34BDC3-7E6B-442E-A9D0-64B6EF378E84}");

	/// <summary>Defines a guid for enabling/disabling the ability to create system required power requests.</summary>
	public static readonly Guid GUID_ALLOW_SYSTEM_REQUIRED = new("{A4B195F5-8225-47D8-8012-9D41369786E2}");

	/// <summary>Specify whether away mode is allowed</summary>
	[CorrespondingType(typeof(bool))]
	public static readonly Guid GUID_ALLOW_AWAYMODE = new("{25dfa149-5dd1-4736-b5ab-e8a37b5b8187}");

	#endregion

	#region System button actions

	/// <summary>Specifies the subgroup which will contain all of the system button settings for a single policy.</summary>
	public static readonly Guid GUID_SYSTEM_BUTTON_SUBGROUP = new("{4F971E89-EEBD-4455-A8DE-9E59040E7347}");

	/// <summary>Specifies (in a POWER_ACTION_POLICY structure) the appropriate action to take when the system power button is pressed.</summary>
	public static readonly Guid GUID_POWERBUTTON_ACTION = new("{7648EFA3-DD9C-4E3E-B566-50F929386280}");

	/// <summary>Specifies (in a POWER_ACTION_POLICY structure) the appropriate action to take when the system sleep button is pressed.</summary>
	public static readonly Guid GUID_SLEEPBUTTON_ACTION = new("{96996BC0-AD50-47EC-923B-6F41874DD9EB}");

	/// <summary>
	/// Specifies (in a POWER_ACTION_POLICY structure) the appropriate action to take when the system sleep button is pressed.
	/// </summary>
	public static readonly Guid GUID_USERINTERFACEBUTTON_ACTION = new("{A7066653-8D6C-40A8-910E-A1F54B84C7E5}");

	/// <summary>Specifies (in a POWER_ACTION_POLICY structure) the appropriate action to take when the system lid is closed.</summary>
	public static readonly Guid GUID_LIDCLOSE_ACTION = new("{5CA83367-6E45-459F-A27B-476B1D01C936}");

	/// <summary></summary>
	public static readonly Guid GUID_LIDOPEN_POWERSTATE = new("{99FF10E7-23B1-4C07-A9D1-5C3206D741B4}");

	#endregion

	#region Video settings

	/// <summary>Specifies the subgroup which will contain all of the video settings for a single policy.</summary>
	public static readonly Guid GUID_VIDEO_SUBGROUP = new("{7516B95F-F776-4464-8C53-06167F40CC99}");

	/// <summary>Specifies if the operating system should use ambient light sensor to change adaptively the display's brightness.</summary>
	public static readonly Guid GUID_VIDEO_POWERDOWN_TIMEOUT = new("{3C0BC021-C8A8-4E07-A973-6B14CBCB2B7E}");

	/// <summary>
	/// Specifies whether adaptive display dimming is turned on or off.
	///
	/// N.B. This setting is DEPRECATED in Windows 8.1
	/// </summary>
	public static readonly Guid GUID_VIDEO_ANNOYANCE_TIMEOUT = new("{82DBCF2D-CD67-40C5-BFDC-9F1A5CCD4663}");

	/// <summary>
	/// Specifies how much adaptive dim time out will be increased by.
	///
	/// N.B. This setting is DEPRECATED in Windows 8.1
	/// </summary>
	public static readonly Guid GUID_VIDEO_ADAPTIVE_PERCENT_INCREASE = new("{EED904DF-B142-4183-B10B-5A1197A37864}");

	/// <summary>Specifies (in seconds) how long we wait after the last user input has been received before we dim the video.</summary>
	public static readonly Guid GUID_VIDEO_DIM_TIMEOUT = new("{17aaa29b-8b43-4b94-aafe-35f64daaf1ee}");

	/// <summary>Specifies if the operating system should use adaptive timers (based on previous behavior) to power down the video.</summary>
	public static readonly Guid GUID_VIDEO_ADAPTIVE_POWERDOWN = new("{90959D22-D6A1-49B9-AF93-BCE885AD335B}");

	/// <summary>Specifies if the monitor is currently being powered or not.</summary>
	[CorrespondingType(typeof(uint))]
	public static readonly Guid GUID_MONITOR_POWER_ON = new("{02731015-4510-4526-99E6-E5A17EBD1AEA}");

	/// <summary>Monitor brightness policy when in normal state.</summary>
	public static readonly Guid GUID_DEVICE_POWER_POLICY_VIDEO_BRIGHTNESS = new("{aded5e82-b909-4619-9949-f5d71dac0bcb}");

	/// <summary>Monitor brightness policy when in dim state.</summary>
	public static readonly Guid GUID_DEVICE_POWER_POLICY_VIDEO_DIM_BRIGHTNESS = new("{f1fbfde2-a960-4165-9f88-50667911ce96}");

	/// <summary>Current monitor brightness.</summary>
	public static readonly Guid GUID_VIDEO_CURRENT_MONITOR_BRIGHTNESS = new("{8ffee2c6-2d01-46be-adb9-398addc5b4ff}");

	/// <summary>Specifies if the operating system should use ambient light sensor to change adaptively the display's brightness.</summary>
	public static readonly Guid GUID_VIDEO_ADAPTIVE_DISPLAY_BRIGHTNESS = new("{FBD9AA66-9553-4097-BA44-ED6E9D65EAB8}");

	/// <summary>Specifies a change in the current monitor's display state.</summary>
	[CorrespondingType(typeof(uint))]
	public static readonly Guid GUID_CONSOLE_DISPLAY_STATE = new("{6fe69556-704a-47a0-8f24-c28d936fda47}");

	/// <summary>Defines a guid for enabling/disabling the ability to create display required power requests.</summary>
	public static readonly Guid GUID_ALLOW_DISPLAY_REQUIRED = new("{A9CEB8DA-CD46-44FB-A98B-02AF69DE4623}");

	/// <summary>
	/// Specifies the video power down timeout (in seconds) after the interactive console is locked (and sensors indicate
	/// UserNotPresent). Value 0 effectively disables this feature.
	/// </summary>
	public static readonly Guid GUID_VIDEO_CONSOLE_LOCK_TIMEOUT = new("{8ec4b3a5-6868-48c2-be75-4f3044be88a7}");

	/// <summary>
	/// Specifies power settings which will decide whether to prefer visual quality or battery life for an Advanced Color capable display
	/// </summary>
	public static readonly Guid GUID_ADVANCED_COLOR_QUALITY_BIAS = new("{684c3e69-a4f7-4014-8754-d45179a56167}");

	#endregion

	#region Notifications

	/// <summary>
	///   <para>
	/// The system power source has changed. The Data member is a DWORD with values from the SYSTEM_POWER_CONDITION enumeration that indicates the current power source.</para>
	///   <list type="bullet">
	///     <item>0 - Indicates the system is being powered by an AC power source.</item>
	///     <item>1 - Indicates the system is being powered by a DC power source.</item>
	///     <item>2 - Indicates the system is being powered by a short-term DC power source. For example, this would be the case if the system is being powered by a short-term battery supply in a backing UPS system. When this value is received, the consumer should make preparations for either a system hibernate or system shutdown.
	/// </item>
	///   </list>
	/// </summary>
	[CorrespondingType(typeof(uint))]
	public static readonly Guid GUID_ACDC_POWER_SOURCE = new("{5D3E9A59-E9D5-4B00-A6BD-FF34FF516548}");

	/// <summary>
	/// Define a GUID that will represent the action of a direct experience button on the platform. Users will register for this DPPE
	/// setting and receive notification when the h/w button is pressed.
	/// </summary>
	public static readonly Guid GUID_APPLAUNCH_BUTTON = new("{1A689231-7399-4E9A-8F99-B71F999DB3FA}");

	/// <summary>
	/// Notification to listeners that the system is fairly busy and won't be moving into an idle state any time soon. This can be used
	/// as a hint to listeners that now might be a good time to do background tasks.
	/// </summary>
	public static readonly Guid GUID_BACKGROUND_TASK_NOTIFICATION = new("{CF23F240-2A54-48D8-B114-DE1518FF052E}");

	/// <summary>
	/// Specifies change in number of batteries present on the system. The consumer may register for notification in order to track
	/// change in number of batteries available on a system.
	///
	/// Once registered, the consumer can expect to be notified whenever the batteries are added or removed from the system.
	///
	/// The consumer will receive a value indicating number of batteries currently present on the system.
	/// </summary>
	public static readonly Guid GUID_BATTERY_COUNT = new("{7d263f15-fca4-49e5-854b-a9f2bfbd5c24}");

	/// <summary>
	/// Specifies the percentage of battery life remaining. The consumer may register for notification in order to track battery life in
	/// a fine-grained manner.
	///
	/// Once registered, the consumer can expect to be notified as the battery life percentage changes.
	///
	/// The consumer will receive a value between 0 and 100 (inclusive) which indicates percent battery life remaining.
	/// </summary>
	[CorrespondingType(typeof(uint))]
	public static readonly Guid GUID_BATTERY_PERCENTAGE_REMAINING = new("{A7AD8041-B45A-4CAE-87A3-EECBB468A9E1}");

	/// <summary>
	/// Global notification indicating to listeners user activity/presence across all sessions in the system (Present, NotPresent, Inactive)
	/// </summary>
	[CorrespondingType(typeof(uint))]
	public static readonly Guid GUID_GLOBAL_USER_PRESENCE = new("{786E8A1D-B427-4344-9207-09E70BDCBEA9}");

	/// <summary>
	/// Notification to listeners that the system is fairly busy and won't be moving into an idle state any time soon. This can be used
	/// as a hint to listeners that now might be a good time to do background tasks.
	/// </summary>
	public static readonly Guid GUID_IDLE_BACKGROUND_TASK = new("{515C31D8-F734-163D-A0FD-11A08C91E8F1}");

	/// <summary>
	/// Specifies the current state of the lid (open or closed). The callback won't be called at all until a lid device is found and its
	/// current state is known.
	///
	/// Values:
	/// </summary>
	public static readonly Guid GUID_LIDSWITCH_STATE_CHANGE = new("{BA3E0F4D-B817-4094-A2D1-D56379E6A0F3}");

	/// <summary>
	/// Session specific notification indicating to listeners whether or not the display related to the given session is on/off/dim
	///
	/// N.B. This is a session-specific notification, sent only to interactive session registrants. Session 0 and kernel mode consumers
	/// do not receive this notification.
	/// </summary>
	[CorrespondingType(typeof(uint))]
	public static readonly Guid GUID_SESSION_DISPLAY_STATUS = new("{2B84C20E-AD23-4ddf-93DB-05FFBD7EFCA5}");

	/// <summary>
	/// Session specific notification indicating to listeners user activity/presence
	///(Present, NotPresent, Inactive)
	///
	/// N.B. This is a session-specific notification, sent only to interactive
	///      session registrants. Session 0 and kernel mode consumers do not receive
	///      this notification.
	/// </summary>
	[CorrespondingType(typeof(uint))]
	public static readonly Guid GUID_SESSION_USER_PRESENCE = new("{3c0f4548-c03f-4c4d-b9f2-237ede686376}");

	/// <summary>Specifies a change (start/end) in System Power Report's Active Session.</summary>
	public static readonly Guid GUID_SPR_ACTIVE_SESSION_CHANGE = new("{0E24CE38-C393-4742-BDB1-744F4B9EE08E}");

	/// <summary>Specifies whether mixed reality mode is engaged.</summary>
	public static readonly Guid GUID_MIXED_REALITY_MODE = new("{1E626B4E-CF04-4f8d-9CC7-C97C5B0F2391}");

	#endregion

	/// <summary>Indicate the current energy saver status.</summary>
	[PInvokeData("winnt.h")]
	public enum ENERGY_SAVER_STATUS
	{
		/// <summary>Energy saver is off.</summary>
		ENERGY_SAVER_OFF = 0,

		/// <summary>Energy saver is in standard mode. Save energy if the user experience impact is minimal.</summary>
		ENERGY_SAVER_STANDARD,

		/// <summary>Energy saver is in high savings mode. Save energy where possible.</summary>
		ENERGY_SAVER_HIGH_SAVINGS
	}

	/// <summary>The level of user notification.</summary>
	[PInvokeData("winnt.h", MSDNShortId = "70739f46-54be-4748-8993-ffee3b2a8b6c")]
	[Flags]
	public enum EventCode : uint
	{
		/// <summary>Clears a user power button press.</summary>
		POWER_FORCE_TRIGGER_RESET = 0x80000000,

		/// <summary>Specifies a program to be executed.</summary>
		POWER_LEVEL_USER_NOTIFY_EXEC = 0x00000004,

		/// <summary>User notified using sound.</summary>
		POWER_LEVEL_USER_NOTIFY_SOUND = 0x00000002,

		/// <summary>User notified using the UI.</summary>
		POWER_LEVEL_USER_NOTIFY_TEXT = 0x00000001,

		/// <summary>Indicates that the power action is in response to a user power button press.</summary>
		POWER_USER_NOTIFY_BUTTON = 0x00000008,

		/// <summary>Indicates a power action of shutdown/off.</summary>
		POWER_USER_NOTIFY_SHUTDOWN = 0x00000010,
	}

	/// <summary>
	/// <para>Defines values that are used to specify system power action types.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/WinNT/ne-winnt-power_action typedef enum { PowerActionNone,
	// PowerActionReserved, PowerActionSleep, PowerActionHibernate, PowerActionShutdown, PowerActionShutdownReset,
	// PowerActionShutdownOff, PowerActionWarmEject, PowerActionDisplayOff } *PPOWER_ACTION;
	[PInvokeData("winnt.h", MSDNShortId = "815e1f2d-0fc9-446c-ae83-5d5cfea57ab7")]
	public enum POWER_ACTION
	{
		/// <summary>No system power action.</summary>
		PowerActionNone,

		/// <summary>Reserved; do not use.</summary>
		PowerActionReserved,

		/// <summary>Sleep.</summary>
		PowerActionSleep,

		/// <summary>Hibernate.</summary>
		PowerActionHibernate,

		/// <summary>Shutdown.</summary>
		PowerActionShutdown,

		/// <summary>Shutdown and reset.</summary>
		PowerActionShutdownReset,

		/// <summary>Shutdown and power off.</summary>
		PowerActionShutdownOff,

		/// <summary>Warm eject.</summary>
		PowerActionWarmEject,

		/// <summary/>
		PowerActionDisplayOff,
	}

	/// <summary>
	/// Indicates the OEM's preferred power management profile. These values are read from the Preferred_PM_Profile field of the Fixed
	/// ACPI Description Table (FADT). These values are returned by the PowerDeterminePlatformRole or PowerDeterminePlatformRoleEx function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ne-winnt-_power_platform_role typedef enum _POWER_PLATFORM_ROLE {
	// PlatformRoleUnspecified, PlatformRoleDesktop, PlatformRoleMobile, PlatformRoleWorkstation, PlatformRoleEnterpriseServer,
	// PlatformRoleSOHOServer, PlatformRoleAppliancePC, PlatformRolePerformanceServer, PlatformRoleSlate, PlatformRoleMaximum }
	// POWER_PLATFORM_ROLE, *PPOWER_PLATFORM_ROLE;
	[PInvokeData("winnt.h", MSDNShortId = "ec94a0c4-8451-47a5-be48-9d5ed76c3585")]
	public enum POWER_PLATFORM_ROLE
	{
		/// <summary>The OEM did not specify a specific role.</summary>
		PlatformRoleUnspecified,

		/// <summary>The OEM specified a desktop role.</summary>
		PlatformRoleDesktop,

		/// <summary>The OEM specified a mobile role (for example, a laptop).</summary>
		PlatformRoleMobile,

		/// <summary>The OEM specified a workstation role.</summary>
		PlatformRoleWorkstation,

		/// <summary>The OEM specified an enterprise server role.</summary>
		PlatformRoleEnterpriseServer,

		/// <summary>The OEM specified a single office/home office (SOHO) server role.</summary>
		PlatformRoleSOHOServer,

		/// <summary>The OEM specified an appliance PC role.</summary>
		PlatformRoleAppliancePC,

		/// <summary>The OEM specified a performance server role.</summary>
		PlatformRolePerformanceServer,

		/// <summary>
		/// The OEM specified a tablet form factor role. Windows 7, Windows Server 2008 R2, Windows Vista or Windows Server 2008: In
		/// version 1 of this enumeration, this value is equivalent to PlatformRoleMaximum. This value is supported in version 2 of this
		/// enumeration starting with Windows 8 and Windows Server 2012.
		/// </summary>
		PlatformRoleSlate,

		/// <summary>Values equal to or greater than this value indicate an out of range value.</summary>
		PlatformRoleMaximum,
	}

	/// <summary>Option flags for <see cref="PROCESSOR_POWER_POLICY_INFO"/>.</summary>
	[PInvokeData("winnt.h", MSDNShortId = "9d29aec0-ba22-46be-b429-d6dfd2191b98")]
	[Flags]
	public enum PROCESSOR_POWER_POLICY_INFO_Options
	{
		/// <summary>When set, allows the kernel power policy manager to demote from the current state.</summary>
		AllowDemotion = 1,

		/// <summary>When set, allows the kernel power policy manager to promote from the current state.</summary>
		AllowPromotion = 2
	}

	/// <summary>Used by the <c>GUID_ACDC_POWER_SOURCE</c> power event to indicate the current power source.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-system_power_condition
	// typedef enum { PoAc, PoDc, PoHot, PoConditionMaximum } SYSTEM_POWER_CONDITION;
	[PInvokeData("winnt.h", MSDNShortId = "NE:winnt.__unnamed_enum_7")]
	public enum SYSTEM_POWER_CONDITION : uint
	{
		/// <summary>The computer is powered by an AC power source (or similar, such as a laptop powered by a 12V automotive adapter).</summary>
		PoAc = 0,

		/// <summary>The system is receiving power from built-in batteries.</summary>
		PoDc,

		/// <summary>The computer is powered by a short-term power source such as a UPS device.</summary>
		PoHot,

		/// <summary>Values equal to or greater than this value indicate an out of range value.</summary>
		PoConditionMaximum,
	}

	/// <summary>
	/// Contains the granularity of the battery capacity that is reported by IOCTL_BATTERY_QUERY_STATUS. A variable-length array of
	/// <c>BATTERY_REPORTING_SCALE</c> structures is returned from IOCTL_BATTERY_QUERY_INFORMATION when the <c>InformationLevel</c> is
	/// set to <c>BatteryGranularityInformation</c>. Multiple entries are returned when the granularity depends on the present capacity
	/// of the battery.
	/// </summary>
	/// <remarks>
	/// The total number of <c>BATTERY_REPORTING_SCALE</c> entries returned from IOCTL_BATTERY_QUERY_INFORMATION is indicated by the
	/// value of the lpBytesReturned parameter of DeviceIoControl. To determine the number of elements in the array, divide the value of
	/// lpBytesReturned by the size of the <c>BATTERY_REPORTING_SCALE</c> structure. The maximum number of array entries that can be
	/// returned is four.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-battery_reporting_scale typedef struct { DWORD Granularity;
	// DWORD Capacity; } BATTERY_REPORTING_SCALE, *PBATTERY_REPORTING_SCALE;
	[PInvokeData("winnt.h", MSDNShortId = "91834159-e837-407b-8c9e-fbbcf9f208ef")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct BATTERY_REPORTING_SCALE
	{
		/// <summary>
		/// The granularity of the capacity reading returned by IOCTL_BATTERY_QUERY_STATUS in milliwatt-hours (mWh). Granularity may
		/// change over time as battery discharge and recharge lowers the range of readings.
		/// </summary>
		public uint Granularity;

		/// <summary>
		/// The upper capacity limit for Granularity. The value of Granularity is valid for capacities reported by
		/// IOCTL_BATTERY_QUERY_STATUS that are less than or equal to this capacity (mWh), but greater than or equal to the capacity
		/// given in the previous array element, or zero if this is the first array element.
		/// </summary>
		public uint Capacity;
	}

	/// <summary>Contains information used to set the system power state.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-power_action_policy typedef struct { POWER_ACTION Action;
	// DWORD Flags; DWORD EventCode; } POWER_ACTION_POLICY, *PPOWER_ACTION_POLICY;
	[PInvokeData("winnt.h", MSDNShortId = "70739f46-54be-4748-8993-ffee3b2a8b6c")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct POWER_ACTION_POLICY
	{
		/// <summary>The requested system power state. This member must be one of the POWER_ACTION enumeration type values.</summary>
		public POWER_ACTION Action;

		/// <summary>
		/// <para>A flag that controls how to switch the power state. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>POWER_ACTION_CRITICAL 0x80000000</term>
		/// <term>Forces a critical suspension.</term>
		/// </item>
		/// <item>
		/// <term>POWER_ACTION_DISABLE_WAKES 0x40000000</term>
		/// <term>Disables all wake events.</term>
		/// </item>
		/// <item>
		/// <term>POWER_ACTION_LIGHTEST_FIRST 0x10000000</term>
		/// <term>Uses the first lightest available sleep state.</term>
		/// </item>
		/// <item>
		/// <term>POWER_ACTION_LOCK_CONSOLE 0x20000000</term>
		/// <term>Requires entry of the system password upon resume from one of the system standby states.</term>
		/// </item>
		/// <item>
		/// <term>POWER_ACTION_OVERRIDE_APPS 0x00000004</term>
		/// <term>Has no effect.</term>
		/// </item>
		/// <item>
		/// <term>POWER_ACTION_QUERY_ALLOWED 0x00000001</term>
		/// <term>Has no effect.</term>
		/// </item>
		/// <item>
		/// <term>POWER_ACTION_UI_ALLOWED 0x00000002</term>
		/// <term>
		/// Applications can prompt the user for directions on how to prepare for suspension. Sets bit 0 in the Flags parameter passed in
		/// the lParam parameter of WM_POWERBROADCAST.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public PowerActionFlags Flags;

		/// <summary>
		/// <para>The level of user notification. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>POWER_FORCE_TRIGGER_RESET 0x80000000</term>
		/// <term>Clears a user power button press.</term>
		/// </item>
		/// <item>
		/// <term>POWER_LEVEL_USER_NOTIFY_EXEC 0x00000004</term>
		/// <term>Specifies a program to be executed.</term>
		/// </item>
		/// <item>
		/// <term>POWER_LEVEL_USER_NOTIFY_SOUND 0x00000002</term>
		/// <term>User notified using sound.</term>
		/// </item>
		/// <item>
		/// <term>POWER_LEVEL_USER_NOTIFY_TEXT 0x00000001</term>
		/// <term>User notified using the UI.</term>
		/// </item>
		/// <item>
		/// <term>POWER_USER_NOTIFY_BUTTON 0x00000008</term>
		/// <term>Indicates that the power action is in response to a user power button press.</term>
		/// </item>
		/// <item>
		/// <term>POWER_USER_NOTIFY_SHUTDOWN 0x00000010</term>
		/// <term>Indicates a power action of shutdown/off.</term>
		/// </item>
		/// </list>
		/// </summary>
		public EventCode EventCode;
	}

	/// <summary>Action to perform on a power event.</summary>
	[PInvokeData("winnt.h", MSDNShortId = "70739f46-54be-4748-8993-ffee3b2a8b6c")]
	[Flags]
	public enum PowerActionFlags : uint
	{
		/// <summary>Has no effect.</summary>
		POWER_ACTION_QUERY_ALLOWED = 0x00000001,
		/// <summary>Applications can prompt the user for directions on how to prepare for suspension. Sets bit 0 in the Flags parameter passed in
		/// the lParam parameter of WM_POWERBROADCAST.</summary>
		POWER_ACTION_UI_ALLOWED = 0x00000002,
		/// <summary>Has no effect.</summary>
		POWER_ACTION_OVERRIDE_APPS = 0x00000004,
		/// <summary/>
		POWER_ACTION_HIBERBOOT = 0x00000008,
		/// <summary/>
		POWER_ACTION_USER_NOTIFY = 0x00000010,
		/// <summary/>
		POWER_ACTION_DOZE_TO_HIBERNATE = 0x00000020,
		/// <summary/>
		POWER_ACTION_ACPI_CRITICAL = 0x01000000,
		/// <summary/>
		POWER_ACTION_ACPI_USER_NOTIFY = 0x02000000,
		/// <summary/>
		POWER_ACTION_DIRECTED_DRIPS = 0x04000000,
		/// <summary/>
		POWER_ACTION_PSEUDO_TRANSITION = 0x08000000,
		/// <summary>Uses the first lightest available sleep state.</summary>
		POWER_ACTION_LIGHTEST_FIRST = 0x10000000,
		/// <summary>Requires entry of the system password upon resume from one of the system standby states.</summary>
		POWER_ACTION_LOCK_CONSOLE = 0x20000000,
		/// <summary>Disables all wake events.</summary>
		POWER_ACTION_DISABLE_WAKES = 0x40000000,
		/// <summary>Forces a critical suspension.</summary>
		POWER_ACTION_CRITICAL = 0x80000000,
	}

	/// <summary>Contains information about processor performance control and C-states.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_processor_power_policy typedef struct _PROCESSOR_POWER_POLICY
	// { DWORD Revision; BYTE DynamicThrottle; BYTE Spare[3]; DWORD DisableCStates : 1; DWORD Reserved : 31; DWORD PolicyCount;
	// PROCESSOR_POWER_POLICY_INFO Policy[3]; } PROCESSOR_POWER_POLICY, *PPROCESSOR_POWER_POLICY;
	[PInvokeData("winnt.h", MSDNShortId = "ea1eae62-26b4-4f5d-a9ca-0a7bb463b90a")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PROCESSOR_POWER_POLICY
	{
		/// <summary>
		/// The current structure revision level. Set this value by calling ReadProcessorPwrScheme before using a
		/// <c>PROCESSOR_POWER_POLICY</c> structure to set power policy.
		/// </summary>
		public uint Revision;

		/// <summary>
		/// The current processor performance state policy. This member must be one of the values described in Processor Performance
		/// Control Policy Constants.
		/// </summary>
		public byte DynamicThrottle;

		/// <summary>Reserved; set to zero.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		private readonly byte[] Spare;

		/// <summary>Reserved; set to zero.</summary>
		public uint Reserved;

		/// <summary>The number of elements in the <c>Policy</c> array.</summary>
		public uint PolicyCount;

		/// <summary>
		/// An array of PROCESSOR_POWER_POLICY_INFO structures that defines values used to apply processor C-state policy settings.
		/// Policy[0] corresponds to ACPI C-state C1, Policy[1] corresponds to C2, and Policy[2] corresponds to C3. The
		/// <c>AllowPromotion</c> member determines whether the processor can be promoted to the state. For example, if
		/// Policy[0].AllowPromotion is 0, the computer cannot transition from C0 to C1.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public PROCESSOR_POWER_POLICY_INFO[] Policy;
	}

	/// <summary>
	/// Contains information about processor C-state policy settings. This structure is part of the PROCESSOR_POWER_POLICY structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_processor_power_policy_info typedef struct
	// _PROCESSOR_POWER_POLICY_INFO { DWORD TimeCheck; DWORD DemoteLimit; DWORD PromoteLimit; BYTE DemotePercent; BYTE PromotePercent;
	// BYTE Spare[2]; DWORD AllowDemotion : 1; DWORD AllowPromotion : 1; DWORD Reserved : 30; } PROCESSOR_POWER_POLICY_INFO, *PPROCESSOR_POWER_POLICY_INFO;
	[PInvokeData("winnt.h", MSDNShortId = "9d29aec0-ba22-46be-b429-d6dfd2191b98")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PROCESSOR_POWER_POLICY_INFO
	{
		/// <summary>The time that must expire before promotion or demotion is considered, in microseconds.</summary>
		public uint TimeCheck;

		/// <summary>The minimum amount of time that must be spent in the idle loop to avoid demotion, in microseconds.</summary>
		public uint DemoteLimit;

		/// <summary>The time that must be exceeded to cause promotion to a deeper idle state, in microseconds.</summary>
		public uint PromoteLimit;

		/// <summary>
		/// The value that scales the threshold at which the power policy manager decreases the performance of the processor, expressed
		/// as a percentage.
		/// </summary>
		public byte DemotePercent;

		/// <summary>
		/// The value that scales the threshold at which the power policy manager increases the performance of the processor, expressed
		/// as a percentage.
		/// </summary>
		public byte PromotePercent;

		/// <summary>Reserved.</summary>
		/// <value>The <see cref="System.Byte"/>.</value>
		/// <returns></returns>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		private readonly byte[] Spare;

		/// <summary>Options</summary>
		public PROCESSOR_POWER_POLICY_INFO_Options Options;
	}

	/// <summary>Contains information about the power capabilities of the system.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-system_power_capabilities typedef struct { BOOLEAN
	// PowerButtonPresent; BOOLEAN SleepButtonPresent; BOOLEAN LidPresent; BOOLEAN SystemS1; BOOLEAN SystemS2; BOOLEAN SystemS3; BOOLEAN
	// SystemS4; BOOLEAN SystemS5; BOOLEAN HiberFilePresent; BOOLEAN FullWake; BOOLEAN VideoDimPresent; BOOLEAN ApmPresent; BOOLEAN
	// UpsPresent; BOOLEAN ThermalControl; BOOLEAN ProcessorThrottle; BYTE ProcessorMinThrottle; BYTE ProcessorThrottleScale; BYTE
	// spare2[4]; BYTE ProcessorMaxThrottle; BOOLEAN FastSystemS4; BOOLEAN Hiberboot; BOOLEAN WakeAlarmPresent; BOOLEAN AoAc; BOOLEAN
	// DiskSpinDown; #if ... BYTE spare3[8]; BYTE HiberFileType; BOOLEAN AoAcConnectivitySupported; #else BYTE spare3[6]; #endif BOOLEAN
	// SystemBatteriesPresent; BOOLEAN BatteriesAreShortTerm; BATTERY_REPORTING_SCALE BatteryScale[3]; SYSTEM_POWER_STATE AcOnLineWake;
	// SYSTEM_POWER_STATE SoftLidWake; SYSTEM_POWER_STATE RtcWake; SYSTEM_POWER_STATE MinDeviceWakeState; SYSTEM_POWER_STATE
	// DefaultLowLatencyWake; } SYSTEM_POWER_CAPABILITIES, *PSYSTEM_POWER_CAPABILITIES;
	[PInvokeData("winnt.h", MSDNShortId = "aa0af56e-59b3-4d0d-b356-a4046d8754ef")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct SYSTEM_POWER_CAPABILITIES
	{
		/// <summary>If this member is <c>TRUE</c>, there is a system power button.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool PowerButtonPresent;

		/// <summary>If this member is <c>TRUE</c>, there is a system sleep button.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool SleepButtonPresent;

		/// <summary>If this member is <c>TRUE</c>, there is a lid switch.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool LidPresent;

		/// <summary>If this member is <c>TRUE</c>, the operating system supports sleep state S1.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool SystemS1;

		/// <summary>If this member is <c>TRUE</c>, the operating system supports sleep state S2.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool SystemS2;

		/// <summary>If this member is <c>TRUE</c>, the operating system supports sleep state S3.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool SystemS3;

		/// <summary>If this member is <c>TRUE</c>, the operating system supports sleep state S4 (hibernation).</summary>
		[MarshalAs(UnmanagedType.U1)] public bool SystemS4;

		/// <summary>If this member is <c>TRUE</c>, the operating system supports power off state S5 (soft off).</summary>
		[MarshalAs(UnmanagedType.U1)] public bool SystemS5;

		/// <summary>If this member is <c>TRUE</c>, the system hibernation file is present.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool HiberFilePresent;

		/// <summary>If this member is <c>TRUE</c>, the system supports wake capabilities.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool FullWake;

		/// <summary>If this member is <c>TRUE</c>, the system supports video display dimming capabilities.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool VideoDimPresent;

		/// <summary>If this member is <c>TRUE</c>, the system supports APM BIOS power management features.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool ApmPresent;

		/// <summary>If this member is <c>TRUE</c>, there is an uninterruptible power supply (UPS).</summary>
		[MarshalAs(UnmanagedType.U1)] public bool UpsPresent;

		/// <summary>If this member is <c>TRUE</c>, the system supports thermal zones.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool ThermalControl;

		/// <summary>If this member is <c>TRUE</c>, the system supports processor throttling.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool ProcessorThrottle;

		/// <summary>The minimum level of system processor throttling supported, expressed as a percentage.</summary>
		public byte ProcessorMinThrottle;

		/// <summary>The processor throttle scale</summary>
		public byte ProcessorThrottleScale;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		private byte[] spare2;

		/// <summary>The maximum level of system processor throttling supported, expressed as a percentage.</summary>
		public byte ProcessorMaxThrottle;

		/// <summary>If this member is <c>TRUE</c>, the system supports the hybrid sleep state.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool FastSystemS4;

		/// <summary>The hiberboot</summary>
		[MarshalAs(UnmanagedType.U1)] public bool Hiberboot;

		/// <summary>
		/// If this member is <c>TRUE</c>, the platform has support for ACPI wake alarm devices. For more details on wake alarm devices,
		/// please see the ACPI specification section 9.18.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)] public bool WakeAlarmPresent;

		/// <summary>If this member is <c>TRUE</c>, the system supports the S0 low power idle model.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool AoAc;

		/// <summary>If this member is <c>TRUE</c>, the system supports allowing the removal of power to fixed disk devices.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool DiskSpinDown;

		/// <summary>The hiber file type</summary>
		public byte HiberFileType;

		/// <summary>The ao ac connectivity supported</summary>
		[MarshalAs(UnmanagedType.U1)] public bool AoAcConnectivitySupported;

		/// <summary>The spare3</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		private readonly byte[] spare3;

		/// <summary>If this member is <c>TRUE</c>, there are one or more batteries in the system.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool SystemBatteriesPresent;

		/// <summary>
		/// If this member is <c>TRUE</c>, the system batteries are short-term. Short-term batteries are used in uninterruptible power
		/// supplies (UPS).
		/// </summary>
		[MarshalAs(UnmanagedType.U1)] public bool BatteriesAreShortTerm;

		/// <summary>A BATTERY_REPORTING_SCALE structure that contains information about how system battery metrics are reported.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public BATTERY_REPORTING_SCALE[] BatteryScale;

		/// <summary>
		/// The lowest system sleep state (Sx) that will generate a wake event when the system is on AC power. This member must be one of
		/// the SYSTEM_POWER_STATE enumeration type values.
		/// </summary>
		public SYSTEM_POWER_STATE AcOnLineWake;

		/// <summary>
		/// The lowest system sleep state (Sx) that will generate a wake event via the lid switch. This member must be one of the
		/// SYSTEM_POWER_STATE enumeration type values.
		/// </summary>
		public SYSTEM_POWER_STATE SoftLidWake;

		/// <summary>
		/// <para>
		/// The lowest system sleep state (Sx) supported by hardware that will generate a wake event via the Real Time Clock (RTC). This
		/// member must be one of the SYSTEM_POWER_STATE enumeration type values.
		/// </para>
		/// <para>
		/// To wake the computer using the RTC, the operating system must also support waking from the sleep state the computer is in
		/// when the RTC generates the wake event. Therefore, the effective lowest sleep state from which an RTC wake event can wake the
		/// computer is the lowest sleep state supported by the operating system that is equal to or higher than the value of
		/// <c>RtcWake</c>. To determine the sleep states that the operating system supports, check the <c>SystemS1</c>, <c>SystemS2</c>,
		/// <c>SystemS3</c>, and <c>SystemS4</c> members.
		/// </para>
		/// </summary>
		public SYSTEM_POWER_STATE RtcWake;

		/// <summary>
		/// The minimum allowable system power state supporting wake events. This member must be one of the SYSTEM_POWER_STATE
		/// enumeration type values. Note that this state may change as different device drivers are installed on the system.
		/// </summary>
		public SYSTEM_POWER_STATE MinDeviceWakeState;

		/// <summary>
		/// The default system power state used if an application calls RequestWakeupLatency with <c>LT_LOWEST_LATENCY</c>. This member
		/// must be one of the SYSTEM_POWER_STATE enumeration type values.
		/// </summary>
		public SYSTEM_POWER_STATE DefaultLowLatencyWake;
	}

	/// <summary>
	/// <para>
	/// Contains information about system battery drain policy settings. This structure is part of the GLOBAL_USER_POWER_POLICY structure.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/WinNT/ns-winnt-system_power_level typedef struct { BOOLEAN Enable; BYTE
	// Spare[3]; DWORD BatteryLevel; POWER_ACTION_POLICY PowerPolicy; SYSTEM_POWER_STATE MinSystemState; } SYSTEM_POWER_LEVEL, *PSYSTEM_POWER_LEVEL;
	[PInvokeData("winnt.h", MSDNShortId = "4efa847d-92da-4cf7-95c2-c329de1691f4")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct SYSTEM_POWER_LEVEL
	{
		/// <summary>
		/// <para>If this member is <c>TRUE</c>, the alarm should be activated when the battery discharges below the value set in <c>BatteryLevel</c>.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.U1)] public bool Enable;

		/// <summary>
		/// <para>Reserved.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		private readonly byte[] Spare;

		/// <summary>
		/// <para>The battery capacity for this battery discharge policy, expressed as a percentage.</para>
		/// </summary>
		public uint BatteryLevel;

		/// <summary>
		/// <para>A POWER_ACTION_POLICY structure that defines the action to take for this battery discharge policy.</para>
		/// </summary>
		public POWER_ACTION_POLICY PowerPolicy;

		/// <summary>
		/// <para>
		/// The minimum system sleep state to enter when the battery discharges below the value set in <c>BatteryLevel</c>. This member
		/// must be one of the SYSTEM_POWER_STATE enumeration type values.
		/// </para>
		/// </summary>
		public SYSTEM_POWER_STATE MinSystemState;
	}

	/*
#define POWERBUTTON_ACTION_INDEX_NOTHING                0
#define POWERBUTTON_ACTION_INDEX_SLEEP                  1
#define POWERBUTTON_ACTION_INDEX_HIBERNATE              2
#define POWERBUTTON_ACTION_INDEX_SHUTDOWN               3
#define POWERBUTTON_ACTION_INDEX_TURN_OFF_THE_DISPLAY   4

#define POWERBUTTON_ACTION_VALUE_NOTHING                0
#define POWERBUTTON_ACTION_VALUE_SLEEP                  2
#define POWERBUTTON_ACTION_VALUE_HIBERNATE              3
#define POWERBUTTON_ACTION_VALUE_SHUTDOWN               6
#define POWERBUTTON_ACTION_VALUE_TURN_OFF_THE_DISPLAY   8
#define PERFSTATE_POLICY_CHANGE_IDEAL  0
#define PERFSTATE_POLICY_CHANGE_SINGLE 1
#define PERFSTATE_POLICY_CHANGE_ROCKET 2
#define PERFSTATE_POLICY_CHANGE_IDEAL_AGGRESSIVE 3

#define PERFSTATE_POLICY_CHANGE_DECREASE_MAX PERFSTATE_POLICY_CHANGE_ROCKET
#define PERFSTATE_POLICY_CHANGE_INCREASE_MAX PERFSTATE_POLICY_CHANGE_IDEAL_AGGRESSIVE
#define PROCESSOR_THROTTLE_DISABLED  0
#define PROCESSOR_THROTTLE_ENABLED   1
#define PROCESSOR_THROTTLE_AUTOMATIC 2
#define PROCESSOR_PERF_BOOST_POLICY_DISABLED 0
#define PROCESSOR_PERF_BOOST_POLICY_MAX 100
#define PROCESSOR_PERF_BOOST_MODE_DISABLED 0
#define PROCESSOR_PERF_BOOST_MODE_ENABLED 1
#define PROCESSOR_PERF_BOOST_MODE_AGGRESSIVE 2
#define PROCESSOR_PERF_BOOST_MODE_EFFICIENT_ENABLED 3
#define PROCESSOR_PERF_BOOST_MODE_EFFICIENT_AGGRESSIVE 4
#define PROCESSOR_PERF_BOOST_MODE_AGGRESSIVE_AT_GUARANTEED 5
#define PROCESSOR_PERF_BOOST_MODE_EFFICIENT_AGGRESSIVE_AT_GUARANTEED 6
#define PROCESSOR_PERF_BOOST_MODE_MAX PROCESSOR_PERF_BOOST_MODE_EFFICIENT_AGGRESSIVE_AT_GUARANTEED
#define PROCESSOR_PERF_AUTONOMOUS_MODE_DISABLED 0
#define PROCESSOR_PERF_AUTONOMOUS_MODE_ENABLED 1
#define PROCESSOR_PERF_PERFORMANCE_PREFERENCE 0xff
#define PROCESSOR_PERF_ENERGY_PREFERENCE         0
#define PROCESSOR_PERF_MINIMUM_ACTIVITY_WINDOW 0
#define PROCESSOR_PERF_MAXIMUM_ACTIVITY_WINDOW 1270000000
#define PROCESSOR_DUTY_CYCLING_DISABLED 0
#define PROCESSOR_DUTY_CYCLING_ENABLED 1
#define CORE_PARKING_POLICY_CHANGE_IDEAL  0
#define CORE_PARKING_POLICY_CHANGE_SINGLE 1
#define CORE_PARKING_POLICY_CHANGE_ROCKET 2
#define CORE_PARKING_POLICY_CHANGE_MULTISTEP 3
#define CORE_PARKING_POLICY_CHANGE_MAX CORE_PARKING_POLICY_CHANGE_MULTISTEP
#define POWER_DEVICE_IDLE_POLICY_PERFORMANCE  0
#define POWER_DEVICE_IDLE_POLICY_CONSERVATIVE 1
#define POWER_CONNECTIVITY_IN_STANDBY_DISABLED 0
#define POWER_CONNECTIVITY_IN_STANDBY_ENABLED 1
#define POWER_CONNECTIVITY_IN_STANDBY_SYSTEM_MANAGED 2
#define POWER_DISCONNECTED_STANDBY_MODE_NORMAL 0
#define POWER_DISCONNECTED_STANDBY_MODE_AGGRESSIVE 1
	*/
}