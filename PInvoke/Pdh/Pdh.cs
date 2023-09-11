using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

/// <summary>Pdh Performance Counter functions and structures.</summary>
public static partial class Pdh
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public const uint PDH_CVERSION_WIN40 = 0x0400;
	public const uint PDH_CVERSION_WIN50 = 0x0500;
	public const int PDH_MAX_COUNTER_PATH = 2048;

	// v1.1 revision of PDH -- basic log functions v1.2 of the PDH -- adds variable instance counters v1.3 of the PDH -- adds log service
	// control & stubs for NT5/PDH v2 fn's v2.0 of the PDH -- is the NT v 5.0 B2 version
	public const uint PDH_VERSION = PDH_CVERSION_WIN50 + 0x0003;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

	/// <summary>
	/// Applications implement the <c>CounterPathCallBack</c> function to process the counter path strings returned by the <c>Browse</c>
	/// dialog box.
	/// </summary>
	/// <param name="Arg1"/>
	/// <returns>
	/// <para>Return ERROR_SUCCESS if the function succeeds.</para>
	/// <para>If the function fails due to a transient error, you can return PDH_RETRY and PDH will call your callback immediately.</para>
	/// <para>Otherwise, return an appropriate error code. The error code is passed back to the caller of PdhBrowseCounters.</para>
	/// </returns>
	/// <remarks>The following members of the PDH_BROWSE_DLG_CONFIG structure are used to communicate with the callback function:</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nc-pdh-counterpathcallback CounterPathCallBack Counterpathcallback;
	// PDH_STATUS Counterpathcallback( DWORD_PTR Arg1 ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("pdh.h", MSDNShortId = "b7a2112e-9f50-4a36-b022-f9609b2827bc")]
	public delegate Win32Error CounterPathCallBack(IntPtr Arg1);

	/// <summary>Flags used by PDH_BROWSE_DLG_CONFIG.</summary>
	[PInvokeData("pdh.h", MSDNShortId = "8e045e0b-c157-4527-902c-6096c7922642")]
	[Flags]
	public enum BrowseFlag
	{
		/// <summary>
		/// If this flag is <c>TRUE</c>, the dialog box includes an index number for duplicate instance names. For example, if there are
		/// two cmd instances, the instance list will contain cmd and cmd#1. If this flag is <c>FALSE</c>, duplicate instance names will
		/// not contain an index number.
		/// </summary>
		bIncludeInstanceIndex = 1 << 0,

		/// <summary>
		/// If this flag is <c>TRUE</c>, the dialog returns only one counter. If this flag is <c>FALSE</c>, the dialog can return
		/// multiple selections, and wildcard selections are permitted. Selected counters are returned as a MULTI_SZ string.
		/// </summary>
		bSingleCounterPerAdd = 1 << 1,

		/// <summary>
		/// If this flag is <c>TRUE</c>, the dialog box uses an OK and Cancel button. The dialog returns when the user clicks either
		/// button. If this flag is <c>FALSE</c>, the dialog box uses an Add and Close button. The dialog box closes when the user clicks
		/// the Close button. The Add button can be clicked multiple times. The Add button overwrites the previously selected items with
		/// the currently selected items.
		/// </summary>
		bSingleCounterPerDialog = 1 << 2,

		/// <summary>
		/// If this flag is <c>TRUE</c>, the dialog box lets the user select counters only from the local computer (the path will not
		/// contain a computer name). If this flag is <c>FALSE</c>, the user can specify a computer from which to select counters. The
		/// computer name will prefix the counter path unless the user selects <c>Use local computer counters</c>.
		/// </summary>
		bLocalCountersOnly = 1 << 3,

		/// <summary>
		/// <para>
		/// If this flag is <c>TRUE</c> and the user selects <c>All instances</c>, the counter path will include the wildcard character
		/// for the instance field.
		/// </para>
		/// <para>
		/// If this flag is <c>FALSE</c>, and the user selects <c>All instances</c>, all the instances currently found for that object
		/// will be returned in a MULTI_SZ string.
		/// </para>
		/// </summary>
		bWildCardInstances = 1 << 4,

		/// <summary>
		/// <para>
		/// If this flag is <c>TRUE</c>, this removes <c>Detail level</c> from the dialog box so the user cannot change the detail level
		/// of the counters displayed in the dialog box. The detail level will be fixed to the value of the <c>dwDefaultDetailLevel</c> member.
		/// </para>
		/// <para>
		/// If this flag is <c>FALSE</c>, this displays <c>Detail level</c> in the dialog box, allowing the user to change the detail
		/// level of the counters displayed.
		/// </para>
		/// <para>
		/// Note that the counters displayed will be those whose detail level is less than or equal to the current detail level
		/// selection. Selecting a detail level of Wizard will display all counters and objects.
		/// </para>
		/// </summary>
		bHideDetailBox = 1 << 5,

		/// <summary>
		/// <para>
		/// If this flag is <c>TRUE</c>, the dialog highlights the counter and object specified in <c>szReturnPathBuffer</c> when the
		/// dialog box is first displayed, instead of using the default counter and object specified by the computer.
		/// </para>
		/// <para>
		/// If this flag is <c>FALSE</c>, this selects the initial counter and object using the default counter and object information
		/// returned by the computer.
		/// </para>
		/// </summary>
		bInitializePath = 1 << 6,

		/// <summary>
		/// <para>If this flag is <c>TRUE</c>, the user cannot select a computer from <c>Select counters from computer</c>.</para>
		/// <para>
		/// If this flag is <c>FALSE</c>, the user can select a computer from <c>Select counters from computer</c>. This is the default
		/// value. The list contains the local computer only unless you call the PdhConnectMachine to connect to other computers first.
		/// </para>
		/// </summary>
		bDisableMachineSelection = 1 << 7,

		/// <summary>
		/// <para>
		/// If this flag is <c>TRUE</c>, the counters list will also contain costly data—that is, data that requires a relatively large
		/// amount of processor time or memory overhead to collect.
		/// </para>
		/// <para>If this flag is <c>FALSE</c>, the list will not contain costly counters. This is the default value.</para>
		/// </summary>
		bIncludeCostlyObjects = 1 << 8,

		/// <summary>
		/// If this flag is <c>TRUE</c>, the dialog lists only performance objects. When the user selects an object, the dialog returns a
		/// counter path that includes the object and wildcard characters for the instance name and counter if the object is a multiple
		/// instance object. For example, if the "Process" object is selected, the dialog returns the string "\Process(*)*". If the
		/// object is a single instance object, the path contains a wildcard character for counter only. For example, "\System*". You can
		/// then pass the path to PdhExpandWildCardPath to retrieve a list of actual paths for the object.
		/// </summary>
		bShowObjectBrowser = 1 << 9,
	}

	/// <summary>Performance counter type.</summary>
	[Flags]
	public enum CounterType : uint
	{
		/// <summary>A number (not a counter)</summary>
		PERF_TYPE_NUMBER = 0x00000000,

		/// <summary>32 bit field</summary>
		PERF_SIZE_DWORD = 0x00000000,

		/// <summary>64 bit field</summary>
		PERF_SIZE_LARGE = 0x00000100,

		/// <summary>for Zero Length fields</summary>
		PERF_SIZE_ZERO = 0x00000200,

		/// <summary>length is in CounterLength field</summary>
		PERF_SIZE_VARIABLE_LEN = 0x00000300,

		/// <summary>An increasing numeric value</summary>
		PERF_TYPE_COUNTER = 0x00000400,

		/// <summary>A text field</summary>
		PERF_TYPE_TEXT = 0x00000800,

		/// <summary>Displays a zero</summary>
		PERF_TYPE_ZERO = 0x00000C00,

		/// <summary>Display as HEX value</summary>
		PERF_NUMBER_HEX = 0x00000000,

		/// <summary>Display as a decimal integer</summary>
		PERF_NUMBER_DECIMAL = 0x00010000,

		/// <summary>Display as a decimal/1000</summary>
		PERF_NUMBER_DEC_1000 = 0x00020000,

		/// <summary>Display counter value</summary>
		PERF_COUNTER_VALUE = 0x00000000,

		/// <summary>Divide ctr / delta time</summary>
		PERF_COUNTER_RATE = 0x00010000,

		/// <summary>Divide ctr / base</summary>
		PERF_COUNTER_FRACTION = 0x00020000,

		/// <summary>Base value used in fractions</summary>
		PERF_COUNTER_BASE = 0x00030000,

		/// <summary>Subtract counter from current time</summary>
		PERF_COUNTER_ELAPSED = 0x00040000,

		/// <summary>Use Queuelen processing func.</summary>
		PERF_COUNTER_QUEUELEN = 0x00050000,

		/// <summary>Counter begins or ends a histogram</summary>
		PERF_COUNTER_HISTOGRAM = 0x00060000,

		/// <summary>Divide ctr / private clock</summary>
		PERF_COUNTER_PRECISION = 0x00070000,

		/// <summary>Type of text in text field</summary>
		PERF_TEXT_UNICODE = 0x00000000,

		/// <summary>ASCII using the CodePage field</summary>
		PERF_TEXT_ASCII = 0x00010000,

		/// <summary>Use system perf. freq for base</summary>
		PERF_TIMER_TICK = 0x00000000,

		/// <summary>Use 100 NS timer time base units</summary>
		PERF_TIMER_100NS = 0x00100000,

		/// <summary>Use the object timer freq</summary>
		PERF_OBJECT_TIMER = 0x00200000,

		/// <summary>Compute difference first</summary>
		PERF_DELTA_COUNTER = 0x00400000,

		/// <summary>Compute base diff as well</summary>
		PERF_DELTA_BASE = 0x00800000,

		/// <summary>Show as 1.00-value (assumes:</summary>
		PERF_INVERSE_COUNTER = 0x01000000,

		/// <summary>Sum of multiple instances</summary>
		PERF_MULTI_COUNTER = 0x02000000,

		/// <summary>No suffix</summary>
		PERF_DISPLAY_NO_SUFFIX = 0x00000000,

		/// <summary>"/sec"</summary>
		PERF_DISPLAY_PER_SEC = 0x10000000,

		/// <summary>"%"</summary>
		PERF_DISPLAY_PERCENT = 0x20000000,

		/// <summary>"secs"</summary>
		PERF_DISPLAY_SECONDS = 0x30000000,

		/// <summary>Value is not displayed</summary>
		PERF_DISPLAY_NOSHOW = 0x40000000,

		/// <summary>32-bit Counter. Divide delta by delta time. Display suffix: "/sec"</summary>
		PERF_COUNTER_COUNTER = PERF_SIZE_DWORD | PERF_TYPE_COUNTER | PERF_COUNTER_RATE | PERF_TIMER_TICK | PERF_DELTA_COUNTER | PERF_DISPLAY_PER_SEC,

		/// <summary>64-bit Timer. Divide delta by delta time. Display suffix: "%"</summary>
		PERF_COUNTER_TIMER = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_RATE | PERF_TIMER_TICK | PERF_DELTA_COUNTER | PERF_DISPLAY_PERCENT,

		/// <summary>Queue Length Space-Time Product. Divide delta by delta time. No Display Suffix.</summary>
		PERF_COUNTER_QUEUELEN_TYPE = PERF_SIZE_DWORD | PERF_TYPE_COUNTER | PERF_COUNTER_QUEUELEN | PERF_TIMER_TICK | PERF_DELTA_COUNTER | PERF_DISPLAY_NO_SUFFIX,

		/// <summary>Queue Length Space-Time Product. Divide delta by delta time. No Display Suffix.</summary>
		PERF_COUNTER_LARGE_QUEUELEN_TYPE = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_QUEUELEN | PERF_TIMER_TICK | PERF_DELTA_COUNTER | PERF_DISPLAY_NO_SUFFIX,

		/// <summary>Queue Length Space-Time Product using 100 Ns timebase. Divide delta by delta time. No Display Suffix.</summary>
		PERF_COUNTER_100NS_QUEUELEN_TYPE = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_QUEUELEN | PERF_TIMER_100NS | PERF_DELTA_COUNTER | PERF_DISPLAY_NO_SUFFIX,

		/// <summary>Queue Length Space-Time Product using Object specific timebase. Divide delta by delta time. No Display Suffix.</summary>
		PERF_COUNTER_OBJ_TIME_QUEUELEN_TYPE = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_QUEUELEN | PERF_OBJECT_TIMER | PERF_DELTA_COUNTER | PERF_DISPLAY_NO_SUFFIX,

		/// <summary>64-bit Counter. Divide delta by delta time. Display Suffix: "/sec"</summary>
		PERF_COUNTER_BULK_COUNT = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_RATE | PERF_TIMER_TICK | PERF_DELTA_COUNTER | PERF_DISPLAY_PER_SEC,

		/// <summary>Indicates the counter is not a counter but rather Unicode text Display as text.</summary>
		PERF_COUNTER_TEXT = PERF_SIZE_VARIABLE_LEN | PERF_TYPE_TEXT | PERF_TEXT_UNICODE | PERF_DISPLAY_NO_SUFFIX,

		/// <summary>
		/// Indicates the data is a counter which should not be time averaged on display (such as an error counter on a serial line)
		/// Display as is. No Display Suffix.
		/// </summary>
		PERF_COUNTER_RAWCOUNT = PERF_SIZE_DWORD | PERF_TYPE_NUMBER | PERF_NUMBER_DECIMAL | PERF_DISPLAY_NO_SUFFIX,

		/// <summary>Same as PERF_COUNTER_RAWCOUNT except its size is a large integer</summary>
		PERF_COUNTER_LARGE_RAWCOUNT = PERF_SIZE_LARGE | PERF_TYPE_NUMBER | PERF_NUMBER_DECIMAL | PERF_DISPLAY_NO_SUFFIX,

		/// <summary>
		/// Special case for RAWCOUNT that want to be displayed in hex Indicates the data is a counter which should not be time averaged
		/// on display (such as an error counter on a serial line) Display as is. No Display Suffix.
		/// </summary>
		PERF_COUNTER_RAWCOUNT_HEX = PERF_SIZE_DWORD | PERF_TYPE_NUMBER | PERF_NUMBER_HEX | PERF_DISPLAY_NO_SUFFIX,

		/// <summary>Same as PERF_COUNTER_RAWCOUNT_HEX except its size is a large integer</summary>
		PERF_COUNTER_LARGE_RAWCOUNT_HEX = PERF_SIZE_LARGE | PERF_TYPE_NUMBER | PERF_NUMBER_HEX | PERF_DISPLAY_NO_SUFFIX,

		/// <summary>
		/// A count which is either 1 or 0 on each sampling interrupt (% busy) Divide delta by delta base. Display Suffix: "%"
		/// </summary>
		PERF_SAMPLE_FRACTION = PERF_SIZE_DWORD | PERF_TYPE_COUNTER | PERF_COUNTER_FRACTION | PERF_DELTA_COUNTER | PERF_DELTA_BASE | PERF_DISPLAY_PERCENT,

		/// <summary>A count which is sampled on each sampling interrupt (queue length) Divide delta by delta time. No Display Suffix.</summary>
		PERF_SAMPLE_COUNTER = PERF_SIZE_DWORD | PERF_TYPE_COUNTER | PERF_COUNTER_RATE | PERF_TIMER_TICK | PERF_DELTA_COUNTER | PERF_DISPLAY_NO_SUFFIX,

		/// <summary>A label: no data is associated with this counter (it has 0 length) Do not display.</summary>
		PERF_COUNTER_NODATA = PERF_SIZE_ZERO | PERF_DISPLAY_NOSHOW,

		/// <summary>
		/// 64-bit Timer inverse (e.g., idle is measured, but display busy %) Display 100 - delta divided by delta time. Display suffix: "%"
		/// </summary>
		PERF_COUNTER_TIMER_INV = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_RATE | PERF_TIMER_TICK | PERF_DELTA_COUNTER | PERF_INVERSE_COUNTER | PERF_DISPLAY_PERCENT,

		/// <summary>
		/// The divisor for a sample, used with the previous counter to form a sampled %. You must check for &gt;0 before dividing by
		/// this! This counter will directly follow the numerator counter. It should not be displayed to the user.
		/// </summary>
		PERF_SAMPLE_BASE = PERF_SIZE_DWORD | PERF_TYPE_COUNTER | PERF_COUNTER_BASE | PERF_DISPLAY_NOSHOW | 0x00000001,

		/// <summary>
		/// A timer which, when divided by an average base, produces a time in seconds which is the average time of some operation. This
		/// timer times total operations, and the base is the number of operations. Display Suffix: "sec"
		/// </summary>
		PERF_AVERAGE_TIMER = PERF_SIZE_DWORD | PERF_TYPE_COUNTER | PERF_COUNTER_FRACTION | PERF_DISPLAY_SECONDS,

		/// <summary>
		/// Used as the denominator in the computation of time or count averages. Must directly follow the numerator counter. Not
		/// displayed to the user.
		/// </summary>
		PERF_AVERAGE_BASE = PERF_SIZE_DWORD | PERF_TYPE_COUNTER | PERF_COUNTER_BASE | PERF_DISPLAY_NOSHOW | 0x00000002,

		/// <summary>
		/// A bulk count which, when divided (typically) by the number of operations, gives (typically) the number of bytes per
		/// operation. No Display Suffix.
		/// </summary>
		PERF_AVERAGE_BULK = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_FRACTION | PERF_DISPLAY_NOSHOW,

		/// <summary>
		/// 64-bit Timer in object specific units. Display delta divided by delta time as returned in the object type header structure.
		/// Display suffix: "%"
		/// </summary>
		PERF_OBJ_TIME_TIMER = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_RATE | PERF_OBJECT_TIMER | PERF_DELTA_COUNTER | PERF_DISPLAY_PERCENT,

		/// <summary>64-bit Timer in 100 nsec units. Display delta divided by delta time. Display suffix: "%"</summary>
		PERF_100NSEC_TIMER = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_RATE | PERF_TIMER_100NS | PERF_DELTA_COUNTER | PERF_DISPLAY_PERCENT,

		/// <summary>
		/// 64-bit Timer inverse (e.g., idle is measured, but display busy %) Display 100 - delta divided by delta time. Display suffix: "%"
		/// </summary>
		PERF_100NSEC_TIMER_INV = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_RATE | PERF_TIMER_100NS | PERF_DELTA_COUNTER | PERF_INVERSE_COUNTER | PERF_DISPLAY_PERCENT,

		/// <summary>
		/// 64-bit Timer. Divide delta by delta time. Display suffix: "%" Timer for multiple instances, so result can exceed 100%.
		/// </summary>
		PERF_COUNTER_MULTI_TIMER = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_RATE | PERF_DELTA_COUNTER | PERF_TIMER_TICK | PERF_MULTI_COUNTER | PERF_DISPLAY_PERCENT,

		/// <summary>
		/// 64-bit Timer inverse (e.g., idle is measured, but display busy %) Display 100 * _MULTI_BASE - delta divided by delta time.
		/// Display suffix: "%" Timer for multiple instances, so result can exceed 100%. Followed by a counter of type _MULTI_BASE.
		/// </summary>
		PERF_COUNTER_MULTI_TIMER_INV = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_RATE | PERF_DELTA_COUNTER | PERF_MULTI_COUNTER | PERF_TIMER_TICK | PERF_INVERSE_COUNTER | PERF_DISPLAY_PERCENT,

		/// <summary>Number of instances to which the preceding _MULTI_..._INV counter applies. Used as a factor to get the percentage.</summary>
		PERF_COUNTER_MULTI_BASE = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_BASE | PERF_MULTI_COUNTER | PERF_DISPLAY_NOSHOW,

		/// <summary>
		/// 64-bit Timer in 100 nsec units. Display delta divided by delta time. Display suffix: "%" Timer for multiple instances, so
		/// result can exceed 100%.
		/// </summary>
		PERF_100NSEC_MULTI_TIMER = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_DELTA_COUNTER | PERF_COUNTER_RATE | PERF_TIMER_100NS | PERF_MULTI_COUNTER | PERF_DISPLAY_PERCENT,

		/// <summary>
		/// 64-bit Timer inverse (e.g., idle is measured, but display busy %) Display 100 * _MULTI_BASE - delta divided by delta time.
		/// Display suffix: "%" Timer for multiple instances, so result can exceed 100%. Followed by a counter of type _MULTI_BASE.
		/// </summary>
		PERF_100NSEC_MULTI_TIMER_INV = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_DELTA_COUNTER | PERF_COUNTER_RATE | PERF_TIMER_100NS | PERF_MULTI_COUNTER | PERF_INVERSE_COUNTER | PERF_DISPLAY_PERCENT,

		/// <summary>
		/// Indicates the data is a fraction of the following counter which should not be time averaged on display (such as free space
		/// over total space.) Display as is. Display the quotient as "%".
		/// </summary>
		PERF_RAW_FRACTION = PERF_SIZE_DWORD | PERF_TYPE_COUNTER | PERF_COUNTER_FRACTION | PERF_DISPLAY_PERCENT,

		/// <summary>
		/// Indicates the data is a fraction of the following counter which should not be time averaged on display (such as free space
		/// over total space.) Display as is. Display the quotient as "%".
		/// </summary>
		PERF_LARGE_RAW_FRACTION = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_FRACTION | PERF_DISPLAY_PERCENT,

		/// <summary>
		/// Indicates the data is a base for the preceding counter which should not be time averaged on display (such as free space over
		/// total space.)
		/// </summary>
		PERF_RAW_BASE = PERF_SIZE_DWORD | PERF_TYPE_COUNTER | PERF_COUNTER_BASE | PERF_DISPLAY_NOSHOW | 0x00000003,  // for compatibility with pre-beta version,

		/// <summary>
		/// Indicates the data is a base for the preceding counter which should not be time averaged on display (such as free space over
		/// total space.)
		/// </summary>
		PERF_LARGE_RAW_BASE = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_BASE | PERF_DISPLAY_NOSHOW,

		/// <summary>
		/// The data collected in this counter is actually the start time of the item being measured. For display, this data is
		/// subtracted from the sample time to yield the elapsed time as the difference between the two. In the definition below, the
		/// PerfTime field of the Object contains the sample time as indicated by the PERF_OBJECT_TIMER bit and the difference is scaled
		/// by the PerfFreq of the Object to convert the time units into seconds.
		/// </summary>
		PERF_ELAPSED_TIME = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_ELAPSED | PERF_OBJECT_TIMER | PERF_DISPLAY_SECONDS,

		/// <summary>
		/// The following counter type can be used with the preceding types to define a range of values to be displayed in a histogram.
		/// </summary>
		PERF_COUNTER_HISTOGRAM_TYPE = 0x8000000,

		/// <summary>
		/// This counter is used to display the difference from one sample to the next. The counter value is a constantly increasing
		/// number and the value displayed is the difference between the current value and the previous value. Negative numbers are not
		/// allowed which shouldn't be a problem as long as the counter value is increasing or unchanged.
		/// </summary>
		PERF_COUNTER_DELTA = PERF_SIZE_DWORD | PERF_TYPE_COUNTER | PERF_COUNTER_VALUE | PERF_DELTA_COUNTER | PERF_DISPLAY_NO_SUFFIX,

		/// <summary>
		/// This counter is used to display the difference from one sample to the next. The counter value is a constantly increasing
		/// number and the value displayed is the difference between the current value and the previous value. Negative numbers are not
		/// allowed which shouldn't be a problem as long as the counter value is increasing or unchanged.
		/// </summary>
		PERF_COUNTER_LARGE_DELTA = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_VALUE | PERF_DELTA_COUNTER | PERF_DISPLAY_NO_SUFFIX,

		/// <summary>The timer used has the same frequency as the System Performance Timer</summary>
		PERF_PRECISION_SYSTEM_TIMER = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_PRECISION | PERF_TIMER_TICK | PERF_DELTA_COUNTER | PERF_DISPLAY_PERCENT,

		/// <summary>The timer used has the same frequency as the 100 NanoSecond Timer</summary>
		PERF_PRECISION_100NS_TIMER = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_PRECISION | PERF_TIMER_100NS | PERF_DELTA_COUNTER | PERF_DISPLAY_PERCENT,

		/// <summary>The timer used is of the frequency specified in the Object header's PerfFreq field (PerfTime is ignored)</summary>
		PERF_PRECISION_OBJECT_TIMER = PERF_SIZE_LARGE | PERF_TYPE_COUNTER | PERF_COUNTER_PRECISION | PERF_OBJECT_TIMER | PERF_DELTA_COUNTER | PERF_DISPLAY_PERCENT,
	}

	/// <summary>Determines the data type of the calculated value.</summary>
	[PInvokeData("pdh.h", MSDNShortId = "fd50b1fd-29b7-49a8-bbcc-4d7f0cbd7079")]
	public enum PDH_FMT
	{
		/// <summary/>
		PDH_FMT_RAW = 0x00000010,

		/// <summary>Return the calculated value as an ANSI string.</summary>
		PDH_FMT_ANSI = 0x00000020,

		/// <summary>Return the calculated value as a Unicode string.</summary>
		PDH_FMT_UNICODE = 0x00000040,

		/// <summary>Return the calculated value as a long integer.</summary>
		PDH_FMT_LONG = 0x00000100,

		/// <summary>Return the calculated value as a double-precision floating point real.</summary>
		PDH_FMT_DOUBLE = 0x00000200,

		/// <summary>Return the calculated value as a 64-bit integer.</summary>
		PDH_FMT_LARGE = 0x00000400,

		/// <summary>Do not apply the counter's scaling factor in the calculation.</summary>
		PDH_FMT_NOSCALE = 0x00001000,

		/// <summary>Multiply the final value by 1,000.</summary>
		PDH_FMT_1000 = 0x00002000,

		/// <summary/>
		PDH_FMT_NODATA = 0x00004000,

		/// <summary>
		/// Counter values greater than 100 (for example, counter values measuring the processor load on multiprocessor computers) will
		/// not be reset to 100. The default behavior is that counter values are capped at a value of 100.
		/// </summary>
		PDH_FMT_NOCAP100 = 0x00008000,
	}

	/// <summary>Type of record for <c>PDH_RAW_LOG_RECORD</c>.</summary>
	[PInvokeData("pdh.h", MSDNShortId = "ae96515f-ea3f-4578-a249-fb8f41cdfa69")]
	public enum PDH_LOG_TYPE
	{
		/// <summary>Undefined record format.</summary>
		PDH_LOG_TYPE_UNDEFINED = 0,

		/// <summary>A comma-separated-value format record</summary>
		PDH_LOG_TYPE_CSV = 1,

		/// <summary>A tab-separated-value format record</summary>
		PDH_LOG_TYPE_TSV = 2,

		/// <summary/>
		PDH_LOG_TYPE_TRACE_KERNEL = 4,

		/// <summary/>
		PDH_LOG_TYPE_TRACE_GENERIC = 5,

		/// <summary>A Perfmon format record</summary>
		PDH_LOG_TYPE_PERFMON = 6,

		/// <summary>A SQL format record</summary>
		PDH_LOG_TYPE_SQL = 7,

		/// <summary>A binary trace format record</summary>
		PDH_LOG_TYPE_BINARY = 8,
	}

	/// <summary>Format of the input and output counter values.</summary>
	[PInvokeData("pdh.h", MSDNShortId = "f2dc5f77-9f9e-4290-95fa-ce2f1e81fc69")]
	public enum PDH_PATH
	{
		/// <summary>Returns the path in the PDH format, for example, \\computer\object(parent/instance#index)\counter.</summary>
		PDH_PATH_DEFAULT = 0x00000000,

		/// <summary>Converts a PDH path to the WMI class and property name format.</summary>
		PDH_PATH_WBEM_RESULT = 0x00000001,

		/// <summary>Converts the WMI class and property name to a PDH path.</summary>
		PDH_PATH_WBEM_INPUT = 0x00000002
	}

	/// <summary>Flags that indicate which wildcard characters not to expand.</summary>
	[PInvokeData("pdh.h", MSDNShortId = "415da310-de56-4d58-8959-231426867526")]
	[Flags]
	public enum PdhExpandFlags
	{
		/// <summary>Do not expand the counter name if the path contains a wildcard character for counter name.</summary>
		PDH_NOEXPANDCOUNTERS = 1,

		/// <summary>
		/// Do not expand the instance name if the path contains a wildcard character for parent instance, instance name, or instance index.
		/// </summary>
		PDH_NOEXPANDINSTANCES = 2,

		/// <summary/>
		PDH_REFRESHCOUNTERS = 4
	}

	/// <summary>Type of access to use to open the log file.</summary>
	[PInvokeData("pdh.h", MSDNShortId = "a8457959-af3a-497f-91ca-0876cbb552cc")]
	[Flags]
	public enum PdhLogAccess : uint
	{
		/// <summary>Open the log file for reading.</summary>
		PDH_LOG_READ_ACCESS = 0x00010000,

		/// <summary>Open a new log file for writing.</summary>
		PDH_LOG_WRITE_ACCESS = 0x00020000,

		/// <summary>Open an existing log file for writing.</summary>
		PDH_LOG_UPDATE_ACCESS = 0x00040000,

		/// <summary>Creates a new log file with the specified name.</summary>
		PDH_LOG_CREATE_NEW = 0x00000001,

		/// <summary>
		/// Creates a new log file with the specified name. If the log file already exists, the function removes the existing log file
		/// before creating the new file.
		/// </summary>
		PDH_LOG_CREATE_ALWAYS = 0x00000002,

		/// <summary>
		/// Opens an existing log file with the specified name or creates a new log file with the specified name.Opens an existing log
		/// file with the specified name or creates a new log file with the specified name.
		/// </summary>
		PDH_LOG_OPEN_ALWAYS = 0x00000003,

		/// <summary>
		/// Opens an existing log file with the specified name. If a log file with the specified name does not exist, this is equal to PDH_LOG_CREATE_NEW.
		/// </summary>
		PDH_LOG_OPEN_EXISTING = 0x00000004,

		/// <summary>
		/// Used with PDH_LOG_TYPE_TSV to write the user caption or log file description indicated by the szUserString parameter of
		/// PdhUpdateLog or PdhOpenLog. The user caption or log file description is written as the last column in the first line of the
		/// text log.
		/// </summary>
		PDH_LOG_OPT_USER_STRING = 0x01000000,

		/// <summary>
		/// Creates a circular log file with the specified name. When the file reaches the value of the dwMaxSize parameter, data wraps
		/// to the beginning of the log file. You can specify this flag only if the lpdwLogType parameter is PDH_LOG_TYPE_BINARY.
		/// </summary>
		PDH_LOG_OPT_CIRCULAR = 0x02000000,

		/// <summary/>
		PDH_LOG_OPT_MAX_IS_BYTES = 0x04000000,

		/// <summary/>
		PDH_LOG_OPT_APPEND = 0x08000000,
	}

	/// <summary>Dialog boxes that will be displayed to prompt for the data source.</summary>
	[PInvokeData("pdh.h", MSDNShortId = "211d4504-e1f9-48a0-8ddd-613f2f183c59")]
	public enum PdhSelectDataSourceFlags
	{
		/// <summary>
		/// Display the data source selection dialog box. The dialog box lets the user select performance data from either a log file or
		/// a real-time source. If the user specified that data is to be collected from a log file, a file browser is displayed for the
		/// user to specify the name and location of the log file.
		/// </summary>
		Default,

		/// <summary>
		/// Display the file browser only. Set this flag when you want to prompt for the name and location of a log file only.
		/// </summary>
		PDH_FLAGS_FILE_BROWSER_ONLY
	}

	/// <summary>
	/// Default detail level to show in the Detail level list if bHideDetailBox is FALSE. If bHideDetailBox is TRUE, the dialog uses this
	/// value to filter the displayed performance counters and objects.
	/// </summary>
	[PInvokeData("winperf.h")]
	public enum PERF_DETAIL
	{
		/// <summary>A novice user can understand the counter data.</summary>
		PERF_DETAIL_NOVICE = 100,

		/// <summary>The counter data is provided for advanced users.</summary>
		PERF_DETAIL_ADVANCED = 200,

		/// <summary>The counter data is provided for expert users.</summary>
		PERF_DETAIL_EXPERT = 300,

		/// <summary>The counter data is provided for system designers.</summary>
		PERF_DETAIL_WIZARD = 400
	}

	/// <summary>Adds the specified counter to the query.</summary>
	/// <param name="hQuery">
	/// Handle to the query to which you want to add the counter. This handle is returned by the PdhOpenQuery function.
	/// </param>
	/// <param name="szFullCounterPath">
	/// Null-terminated string that contains the counter path. For details on the format of a counter path, see Specifying a Counter
	/// Path. The maximum length of a counter path is PDH_MAX_COUNTER_PATH.
	/// </param>
	/// <param name="dwUserData">
	/// User-defined value. This value becomes part of the counter information. To retrieve this value later, call the PdhGetCounterInfo
	/// function and access the <c>dwUserData</c> member of the PDH_COUNTER_INFO structure.
	/// </param>
	/// <param name="phCounter">
	/// Handle to the counter that was added to the query. You may need to reference this handle in subsequent calls.
	/// </param>
	/// <returns>
	/// <para>Return ERROR_SUCCESS if the function succeeds.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_CSTATUS_BAD_COUNTERNAME</term>
	/// <term>The counter path could not be parsed or interpreted.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_COUNTER</term>
	/// <term>Unable to find the specified counter on the computer or in the log file.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_COUNTERNAME</term>
	/// <term>The counter path is empty.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_MACHINE</term>
	/// <term>The path did not contain a computer name, and the function was unable to retrieve the local computer name.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_OBJECT</term>
	/// <term>Unable to find the specified object on the computer or in the log file.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FUNCTION_NOT_FOUND</term>
	/// <term>Unable to determine the calculation function to use for this counter.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>One or more arguments are not valid.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The query handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>Unable to allocate memory required to complete the function.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the counter path contains a wildcard character, all counter names matching the wildcard character are added to the query.
	/// </para>
	/// <para>
	/// If a counter instance is specified that does not yet exist, <c>PdhAddCounter</c> does not report an error condition. Instead, it
	/// returns ERROR_SUCCESS. The reason for this behavior is that it is not known whether a nonexistent counter instance has been
	/// specified or whether one will exist but has not yet been created.
	/// </para>
	/// <para>To remove the counter from the query, use the PdhRemoveCounter function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Browsing Performance Counters or Reading Performance Data from a Log File.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhaddcountera PDH_FUNCTION PdhAddCounterA( PDH_HQUERY hQuery,
	// LPCSTR szFullCounterPath, DWORD_PTR dwUserData, PDH_HCOUNTER *phCounter );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "b8b9a332-ce28-46d4-92e2-91f9f6c24da5")]
	public static extern Win32Error PdhAddCounter(PDH_HQUERY hQuery, string szFullCounterPath, IntPtr dwUserData, out SafePDH_HCOUNTER phCounter);

	/// <summary>Adds the specified language-neutral counter to the query.</summary>
	/// <param name="hQuery">
	/// Handle to the query to which you want to add the counter. This handle is returned by the PdhOpenQuery function.
	/// </param>
	/// <param name="szFullCounterPath">
	/// Null-terminated string that contains the counter path. For details on the format of a counter path, see Specifying a Counter
	/// Path. The maximum length of a counter path is PDH_MAX_COUNTER_PATH.
	/// </param>
	/// <param name="dwUserData">
	/// User-defined value. This value becomes part of the counter information. To retrieve this value later, call the PdhGetCounterInfo
	/// function and access the <c>dwQueryUserData</c> member of the PDH_COUNTER_INFO structure.
	/// </param>
	/// <param name="phCounter">
	/// Handle to the counter that was added to the query. You may need to reference this handle in subsequent calls.
	/// </param>
	/// <returns>
	/// <para>Return ERROR_SUCCESS if the function succeeds.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_CSTATUS_BAD_COUNTERNAME</term>
	/// <term>The counter path could not be parsed or interpreted.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_COUNTER</term>
	/// <term>Unable to find the specified counter on the computer or in the log file.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_COUNTERNAME</term>
	/// <term>The counter path is empty.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_MACHINE</term>
	/// <term>The path did not contain a computer name and the function was unable to retrieve the local computer name.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_OBJECT</term>
	/// <term>Unable to find the specified object on the computer or in the log file.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FUNCTION_NOT_FOUND</term>
	/// <term>Unable to determine the calculation function to use for this counter.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>One or more arguments are not valid.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The query handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>Unable to allocate memory required to complete the function.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function provides a language-neutral way to add performance counters to the query. In contrast, the counter path that you
	/// specify in the PdhAddCounter function must be localized.
	/// </para>
	/// <para>
	/// If a counter instance is specified that does not yet exist, <c>PdhAddEnglishCounter</c> does not report an error condition.
	/// Instead, it returns ERROR_SUCCESS. The reason for this behavior is that it is not known whether a nonexistent counter instance
	/// has been specified or whether one will exist but has not yet been created.
	/// </para>
	/// <para>To remove the counter from the query, use the PdhRemoveCounter function.</para>
	/// <para>
	/// <c>Note</c> If the counter path contains a wildcard character, the non-wildcard portions of the path will be localized, but
	/// wildcards will not be expanded before adding the localized counter path to the query. In this case, you will need use the
	/// following procedure to add all matching counter names to the query.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhaddenglishcountera PDH_FUNCTION PdhAddEnglishCounterA( PDH_HQUERY
	// hQuery, LPCSTR szFullCounterPath, DWORD_PTR dwUserData, PDH_HCOUNTER *phCounter );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "6a94b40d-0105-4358-93e1-dae603a35cc4")]
	public static extern Win32Error PdhAddEnglishCounter(PDH_HQUERY hQuery, string szFullCounterPath, IntPtr dwUserData, out SafePDH_HCOUNTER phCounter);

	/// <summary>Binds one or more binary log files together for reading log data.</summary>
	/// <param name="phDataSource">Handle to the bound data sources.</param>
	/// <param name="LogFileNameList">
	/// <para>
	/// One or more binary log files to bind together. The log file names can contain absolute or relative paths. You cannot specify more
	/// than 32 log files.
	/// </para>
	/// <para>If <c>NULL</c>, the source is a real-time data source.</para>
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if the function succeeds.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is used with the PDH functions that require a handle to a data source. For a list of these functions, see See Also.
	/// </para>
	/// <para>
	/// You cannot specify more than one comma-delimited (CSV) or tab-delimited (TSV) file. The list can contain only one type of
	/// file—you cannot combine multiple file types.
	/// </para>
	/// <para>To close the bound log files, call the PdhCloseLog function using the log handle.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhbindinputdatasourcea PDH_FUNCTION PdhBindInputDataSourceA(
	// PDH_HLOG *phDataSource, LPCSTR LogFileNameList );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "eaed9b28-eb09-4123-9317-5d3d50e2d77a")]
	public static extern Win32Error PdhBindInputDataSource(out SafePDH_HLOG phDataSource, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")] string[] LogFileNameList);

	/// <summary>Binds one or more binary log files together for reading log data.</summary>
	/// <param name="LogFileNameList">
	/// <para>
	/// One or more binary log files to bind together. The log file names can contain absolute or relative paths. You cannot specify more
	/// than 32 log files.
	/// </para>
	/// <para>If <c>NULL</c>, the source is a real-time data source.</para>
	/// </param>
	/// <returns>Handle to the bound data sources.</returns>
	/// <remarks>
	/// <para>
	/// This function is used with the PDH functions that require a handle to a data source. For a list of these functions, see See Also.
	/// </para>
	/// <para>
	/// You cannot specify more than one comma-delimited (CSV) or tab-delimited (TSV) file. The list can contain only one type of
	/// file—you cannot combine multiple file types.
	/// </para>
	/// </remarks>
	[PInvokeData("pdh.h", MSDNShortId = "eaed9b28-eb09-4123-9317-5d3d50e2d77a")]
	public static SafePDH_HLOG PdhBindInputDataSource(params string[] LogFileNameList)
	{
		var err = PdhBindInputDataSource(out var hLog, LogFileNameList is null || LogFileNameList.Length == 0 ? null : LogFileNameList);
		return err.Succeeded ? hLog : throw err.GetException();
	}

	/// <summary>
	/// <para>
	/// Displays a <c>Browse Counters</c> dialog box that the user can use to select one or more counters that they want to add to the query.
	/// </para>
	/// <para>To use handles to data sources, use the PdhBrowseCountersH function.</para>
	/// </summary>
	/// <param name="pBrowseDlgData">A PDH_BROWSE_DLG_CONFIG structure that specifies the behavior of the dialog box.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Note that the dialog box can return PDH_DIALOG_CANCELLED if <c>bSingleCounterPerDialog</c> is <c>FALSE</c> and the user clicks
	/// the <c>Close</c> button, so your error handling would have to account for this.
	/// </para>
	/// <para>For information on using this function, see Browsing Counters.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Browsing Performance Counters.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhbrowsecountersa PDH_FUNCTION PdhBrowseCountersA(
	// PPDH_BROWSE_DLG_CONFIG_A pBrowseDlgData );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "4e9e4b20-a573-4f6d-97e8-63bcc675032b")]
	public static extern Win32Error PdhBrowseCounters(ref PDH_BROWSE_DLG_CONFIG pBrowseDlgData);

	/// <summary>
	/// <para>
	/// Displays a <c>Browse Counters</c> dialog box that the user can use to select one or more counters that they want to add to the query.
	/// </para>
	/// <para>This function is identical to the PdhBrowseCounters function, except that it supports the use of handles to data sources.</para>
	/// </summary>
	/// <param name="pBrowseDlgData">A PDH_BROWSE_DLG_CONFIG_H structure that specifies the behavior of the dialog box.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code.</para>
	/// </returns>
	/// <remarks>
	/// Note that the dialog box can return PDH_DIALOG_CANCELLED if <c>bSingleCounterPerDialog</c> is <c>FALSE</c> and the user clicks
	/// the <c>Close</c> button, so your error handling would have to account for this.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhbrowsecountersha PDH_FUNCTION PdhBrowseCountersHA(
	// PPDH_BROWSE_DLG_CONFIG_HA pBrowseDlgData );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "ab835bf8-1adc-463f-99c3-654a328af98a")]
	public static extern Win32Error PdhBrowseCountersH(in PDH_BROWSE_DLG_CONFIG_H pBrowseDlgData);

	/// <summary>Calculates the displayable value of two raw counter values.</summary>
	/// <param name="hCounter">
	/// Handle to the counter to calculate. The function uses information from the counter to determine how to calculate the value. This
	/// handle is returned by the PdhAddCounter function.
	/// </param>
	/// <param name="dwFormat">
	/// <para>Determines the data type of the calculated value. Specify one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_FMT_DOUBLE</term>
	/// <term>Return the calculated value as a double-precision floating point real.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_LARGE</term>
	/// <term>Return the calculated value as a 64-bit integer.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_LONG</term>
	/// <term>Return the calculated value as a long integer.</term>
	/// </item>
	/// </list>
	/// <para>You can use the bitwise inclusive OR operator (|) to combine the data type with one of the following scaling factors.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_FMT_NOSCALE</term>
	/// <term>Do not apply the counter's scaling factor in the calculation.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_NOCAP100</term>
	/// <term>
	/// Counter values greater than 100 (for example, counter values measuring the processor load on multiprocessor computers) will not
	/// be reset to 100. The default behavior is that counter values are capped at a value of 100.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_1000</term>
	/// <term>Multiply the final value by 1,000.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="rawValue1">
	/// Raw counter value used to compute the displayable counter value. For details, see the PDH_RAW_COUNTER structure.
	/// </param>
	/// <param name="rawValue2">
	/// Raw counter value used to compute the displayable counter value. For details, see PDH_RAW_COUNTER. Some counters (for example,
	/// rate counters) require two raw values to calculate a displayable value. If the counter type does not require a second value, set
	/// this parameter to <c>NULL</c>. This value must be the older of the two raw values.
	/// </param>
	/// <param name="fmtValue">A PDH_FMT_COUNTERVALUE structure that receives the calculated counter value.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>An argument is not correct or is incorrectly formatted.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The counter handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>To retrieve the current raw counter value from the query, call the PdhGetRawCounterValue function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhcalculatecounterfromrawvalue PDH_FUNCTION
	// PdhCalculateCounterFromRawValue( PDH_HCOUNTER hCounter, DWORD dwFormat, PPDH_RAW_COUNTER rawValue1, PPDH_RAW_COUNTER rawValue2,
	// PPDH_FMT_COUNTERVALUE fmtValue );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "fd50b1fd-29b7-49a8-bbcc-4d7f0cbd7079")]
	public static extern Win32Error PdhCalculateCounterFromRawValue(PDH_HCOUNTER hCounter, PDH_FMT dwFormat, in PDH_RAW_COUNTER rawValue1, in PDH_RAW_COUNTER rawValue2, out PDH_FMT_COUNTERVALUE fmtValue);

	/// <summary>Calculates the displayable value of two raw counter values.</summary>
	/// <param name="hCounter">
	/// Handle to the counter to calculate. The function uses information from the counter to determine how to calculate the value. This
	/// handle is returned by the PdhAddCounter function.
	/// </param>
	/// <param name="dwFormat">
	/// <para>Determines the data type of the calculated value. Specify one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_FMT_DOUBLE</term>
	/// <term>Return the calculated value as a double-precision floating point real.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_LARGE</term>
	/// <term>Return the calculated value as a 64-bit integer.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_LONG</term>
	/// <term>Return the calculated value as a long integer.</term>
	/// </item>
	/// </list>
	/// <para>You can use the bitwise inclusive OR operator (|) to combine the data type with one of the following scaling factors.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_FMT_NOSCALE</term>
	/// <term>Do not apply the counter's scaling factor in the calculation.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_NOCAP100</term>
	/// <term>
	/// Counter values greater than 100 (for example, counter values measuring the processor load on multiprocessor computers) will not
	/// be reset to 100. The default behavior is that counter values are capped at a value of 100.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_1000</term>
	/// <term>Multiply the final value by 1,000.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="rawValue1">
	/// Raw counter value used to compute the displayable counter value. For details, see the PDH_RAW_COUNTER structure.
	/// </param>
	/// <param name="rawValue2">
	/// Raw counter value used to compute the displayable counter value. For details, see PDH_RAW_COUNTER. Some counters (for example,
	/// rate counters) require two raw values to calculate a displayable value. If the counter type does not require a second value, set
	/// this parameter to <c>NULL</c>. This value must be the older of the two raw values.
	/// </param>
	/// <param name="fmtValue">A PDH_FMT_COUNTERVALUE structure that receives the calculated counter value.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>An argument is not correct or is incorrectly formatted.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The counter handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>To retrieve the current raw counter value from the query, call the PdhGetRawCounterValue function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhcalculatecounterfromrawvalue PDH_FUNCTION
	// PdhCalculateCounterFromRawValue( PDH_HCOUNTER hCounter, DWORD dwFormat, PPDH_RAW_COUNTER rawValue1, PPDH_RAW_COUNTER rawValue2,
	// PPDH_FMT_COUNTERVALUE fmtValue );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "fd50b1fd-29b7-49a8-bbcc-4d7f0cbd7079")]
	public static extern Win32Error PdhCalculateCounterFromRawValue(PDH_HCOUNTER hCounter, PDH_FMT dwFormat, in PDH_RAW_COUNTER rawValue1, [Optional] IntPtr rawValue2, out PDH_FMT_COUNTERVALUE fmtValue);

	/// <summary>Closes the specified log file.</summary>
	/// <param name="hLog">Handle to the log file to be closed. This handle is returned by the PdhOpenLog function.</param>
	/// <param name="dwFlags">
	/// <para>You can specify the following flag.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_FLAGS_CLOSE_QUERY</term>
	/// <term>Closes the query associated with the specified log file handle. See the hQuery parameter of PdhOpenLog.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS and closes and deletes the query.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following is a possible value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The log file handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhcloselog PDH_FUNCTION PdhCloseLog( PDH_HLOG hLog, DWORD dwFlags );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "74039bdf-d1b5-41ba-aa4e-4779ce0dd02a")]
	public static extern Win32Error PdhCloseLog(PDH_HLOG hLog, uint dwFlags);

	/// <summary>
	/// Closes all counters contained in the specified query, closes all handles related to the query, and frees all memory associated
	/// with the query.
	/// </summary>
	/// <param name="hQuery">Handle to the query to close. This handle is returned by the PdhOpenQuery function.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns ERROR_SUCCESS. Otherwise, the function returns a system error code or a PDH error code.
	/// </para>
	/// <para>The following is a possible value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The query handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Do not use the counter handles associated with this query after calling this function.</para>
	/// <para>The following shows the syntax if calling this function from Visual Basic.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Browsing Performance Counters or Reading Performance Data from a Log File.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhclosequery PDH_FUNCTION PdhCloseQuery( PDH_HQUERY hQuery );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "af0fb9f4-3999-48fa-88d7-aa59b5caed75")]
	public static extern Win32Error PdhCloseQuery(PDH_HQUERY hQuery);

	/// <summary>
	/// Collects the current raw data value for all counters in the specified query and updates the status code of each counter.
	/// </summary>
	/// <param name="hQuery">Handle of the query for which you want to collect data. The PdhOpenQuery function returns this handle.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns ERROR_SUCCESS. Otherwise, the function returns a system error code or a PDH error code.
	/// </para>
	/// <para>The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The query handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>PDH_NO_DATA</term>
	/// <term>
	/// The query does not currently contain any counters. The query may not contain data because the user is not running with an
	/// elevated token (see Limited User Access Support).
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Call this function when you want to collect counter data for the counters in the query. PDH stores the raw counter values for the
	/// current and previous collection.
	/// </para>
	/// <para>
	/// If you want to retrieve the current raw counter value, call the PdhGetRawCounterValue function. If you want to compute a
	/// displayable value for the counter value, call the PdhGetFormattedCounterValue function. If the counter path contains a wildcard
	/// for the instance name, instead call the PdhGetRawCounterArray and PdhGetFormattedCounterArray functions, respectively.
	/// </para>
	/// <para>
	/// When <c>PdhCollectQueryData</c> is called for data from one counter instance only and the counter instance does not exist, the
	/// function returns PDH_NO_DATA. However, if data from more than one counter is queried, <c>PdhCollectQueryData</c> may return
	/// ERROR_SUCCESS even if one of the counter instances does not yet exist. This is because it is not known if the specified counter
	/// instance does not exist, or if it will exist but has not yet been created. In this case, call PdhGetRawCounterValue or
	/// PdhGetFormattedCounterValue for each of the counter instances of interest to determine whether they exist.
	/// </para>
	/// <para>The following shows the syntax if calling this function from Visual Basic.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Browsing Performance Counters or Reading Performance Data from a Log File.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhcollectquerydata PDH_FUNCTION PdhCollectQueryData( PDH_HQUERY
	// hQuery );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "1d83325b-8deb-4731-9df4-6201da292cdc")]
	public static extern Win32Error PdhCollectQueryData(PDH_HQUERY hQuery);

	/// <summary>
	/// Uses a separate thread to collect the current raw data value for all counters in the specified query. The function then signals
	/// the application-defined event and waits the specified time interval before returning.
	/// </summary>
	/// <param name="hQuery">
	/// Handle of the query. The query identifies the counters that you want to collect. The PdhOpenQuery function returns this handle.
	/// </param>
	/// <param name="dwIntervalTime">Time interval to wait, in seconds.</param>
	/// <param name="hNewDataEvent">
	/// Handle to the event that you want PDH to signal after the time interval expires. To create an event object, call the CreateEvent function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The query handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>PDH_NO_DATA</term>
	/// <term>The query does not currently have any counters.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// PDH terminates the thread when you call the PdhCloseQuery function. If you call <c>PdhCollectQueryDataEx</c> more than once, each
	/// subsequent call terminates the thread from the previous call and then starts a new thread.
	/// </para>
	/// <para>
	/// When <c>PdhCollectQueryDataEx</c> is called for data from one counter instance only and the counter instance does not exist, the
	/// function returns PDH_NO_DATA. However, if data from more than one counter is queried, <c>PdhCollectQueryDataEx</c> may return
	/// ERROR_SUCCESS even if one of the counter instances does not yet exist. This is because it is not known if the specified counter
	/// instance does not exist, or if it will exist but has not yet been created. In this case, call PdhGetRawCounterValue or
	/// PdhGetFormattedCounterValue for each of the counter instances of interest to determine whether they exist.
	/// </para>
	/// <para>
	/// PDH stores the raw counter values for the current and previous collection. If you want to retrieve the current raw counter value,
	/// call the PdhGetRawCounterValue function. If you want to compute a displayable value for the counter value, call the
	/// PdhGetFormattedCounterValue. If the counter path contains a wildcard for the instance name, instead call the
	/// PdhGetRawCounterArray and PdhGetFormattedCounterArray functions, respectively.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows how to use this function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhcollectquerydataex PDH_FUNCTION PdhCollectQueryDataEx( PDH_HQUERY
	// hQuery, DWORD dwIntervalTime, HANDLE hNewDataEvent );
	[DllImport(Lib.Pdh, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "3fa1d193-03d0-44d8-a32b-b7754594d0ca")]
	public static extern Win32Error PdhCollectQueryDataEx(PDH_HQUERY hQuery, uint dwIntervalTime, SafeEventHandle hNewDataEvent);

	/// <summary>
	/// Collects the current raw data value for all counters in the specified query and updates the status code of each counter.
	/// </summary>
	/// <param name="hQuery">Handle of the query for which you want to collect data. The PdhOpenQuery function returns this handle.</param>
	/// <param name="pllTimeStamp">Time stamp when the first counter value in the query was retrieved. The time is specified as FILETIME.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns ERROR_SUCCESS. Otherwise, the function returns a system error code or a PDH error code.
	/// </para>
	/// <para>The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The query handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>PDH_NO_DATA</term>
	/// <term>The query does not currently have any counters.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Call this function when you want to collect counter data for the counters in the query. PDH stores the raw counter values for the
	/// current and previous collection.
	/// </para>
	/// <para>
	/// If you want to retrieve the current raw counter value, call the PdhGetRawCounterValue function. If you want to compute a
	/// displayable value for the counter value, call the PdhGetFormattedCounterValue. If the counter path contains a wildcard for the
	/// instance name, instead call the PdhGetRawCounterArray and PdhGetFormattedCounterArray functions, respectively.
	/// </para>
	/// <para>
	/// When PdhCollectQueryDataEx is called for data from one counter instance only, and the counter instance does not exist, the
	/// function returns PDH_NO_DATA. However, if data from more than one counter is queried, <c>PdhCollectQueryDataEx</c> may return
	/// ERROR_SUCCESS even if one of the counter instances does not yet exist. This is because it is not known if the specified counter
	/// instance does not exist, or if it will exist but has not yet been created. In this case, call the PdhGetRawCounterValue or
	/// PdhGetFormattedCounterValue function for each of the counter instances of interest to determine whether they exist.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhcollectquerydatawithtime PDH_FUNCTION
	// PdhCollectQueryDataWithTime( PDH_HQUERY hQuery, LONGLONG *pllTimeStamp );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "2c47c690-0748-4ed4-a138-894d45c72581")]
	public static extern Win32Error PdhCollectQueryDataWithTime(PDH_HQUERY hQuery, out FILETIME pllTimeStamp);

	/// <summary>Computes statistics for a counter from an array of raw values.</summary>
	/// <param name="hCounter">
	/// Handle of the counter for which you want to compute statistics. The PdhAddCounter function returns this handle.
	/// </param>
	/// <param name="dwFormat">
	/// <para>Determines the data type of the formatted value. Specify one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_FMT_DOUBLE</term>
	/// <term>Return the calculated value as a double-precision floating point real.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_LARGE</term>
	/// <term>Return the calculated value as a 64-bit integer.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_LONG</term>
	/// <term>Return the calculated value as a long integer.</term>
	/// </item>
	/// </list>
	/// <para>You can use the bitwise inclusive OR operator (|) to combine the data type with one of the following scaling factors.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_FMT_NOSCALE</term>
	/// <term>Do not apply the counter's scaling factors in the calculation.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_NOCAP100</term>
	/// <term>
	/// Counter values greater than 100 (for example, counter values measuring the processor load on multiprocessor computers) will not
	/// be reset to 100. The default behavior is that counter values are capped at a value of 100.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_1000</term>
	/// <term>Multiply the final value by 1,000.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFirstEntry">
	/// Zero-based index of the first raw counter value to use to begin the calculations. The index value must point to the oldest entry
	/// in the buffer. The function starts at this entry and scans through the buffer, wrapping at the last entry back to the beginning
	/// of the buffer and up to the dwFirstEntry-1 entry, which is assumed to be the newest or most recent data.
	/// </param>
	/// <param name="dwNumEntries">Number of raw counter values in the lpRawValueArray buffer.</param>
	/// <param name="lpRawValueArray">Array of PDH_RAW_COUNTER structures that contain dwNumEntries entries.</param>
	/// <param name="data">A PDH_STATISTICS structure that receives the counter statistics.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>An argument is not correct or is incorrectly formatted.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The counter handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhcomputecounterstatistics PDH_FUNCTION
	// PdhComputeCounterStatistics( PDH_HCOUNTER hCounter, DWORD dwFormat, DWORD dwFirstEntry, DWORD dwNumEntries, PPDH_RAW_COUNTER
	// lpRawValueArray, PPDH_STATISTICS data );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "a986ae6c-88ee-4a03-9077-3d286157b9d1")]
	public static extern Win32Error PdhComputeCounterStatistics(PDH_HCOUNTER hCounter, PDH_FMT dwFormat, uint dwFirstEntry, uint dwNumEntries, [In] PDH_RAW_COUNTER[] lpRawValueArray, out PDH_STATISTICS data);

	/// <summary>Connects to the specified computer.</summary>
	/// <param name="szMachineName">
	/// <c>Null</c>-terminated string that specifies the name of the computer to connect to. If <c>NULL</c>, PDH connects to the local computer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_CSTATUS_NO_MACHINE</term>
	/// <term>
	/// Unable to connect to the specified computer. Could be caused by the computer not being on, not supporting PDH, not being
	/// connected to the network, or having the permissions set on the registry that prevent remote connections or remote performance
	/// monitoring by the user.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>
	/// Unable to allocate a dynamic memory block. Occurs when there is a serious memory shortage in the system due to too many
	/// applications running on the system or an insufficient memory paging file.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Typically, applications do not call this function and instead the connection is made when the application adds the counter to the query.
	/// </para>
	/// <para>
	/// However, you can use this function if you want to include more than the local computer in the <c>Select counters from
	/// computer</c> list on the <c>Browse Counters</c> dialog box. For details, see the PDH_BROWSE_DLG_CONFIG structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhconnectmachinea PDH_FUNCTION PdhConnectMachineA( LPCSTR
	// szMachineName );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "8f8b4651-b550-4b34-bb2f-d2497c56b572")]
	public static extern Win32Error PdhConnectMachine([Optional] string? szMachineName);

	/// <summary>Enumerates the names of the log sets within the DSN.</summary>
	/// <param name="szDataSource"><c>Null</c>-terminated string that specifies the DSN.</param>
	/// <param name="mszDataSetNameList">
	/// Caller-allocated buffer that receives the list of <c>null</c>-terminated log set names. The list is terminated with a
	/// <c>null</c>-terminator character. Set to <c>NULL</c> if the pcchBufferLength parameter is zero.
	/// </param>
	/// <param name="pcchBufferLength">
	/// Size of the mszLogSetNameList buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this
	/// parameter to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the
	/// actual size of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you
	/// should not rely on the returned size to reallocate the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The size of the mszLogSetNameList buffer is too small to contain all the data. This return value is expected if pcchBufferLength
	/// is zero on input. If the specified size on input is greater than zero but less than the required size, you should not rely on the
	/// returned size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid. For example, on some releases you could receive this error if the specified size on input is greater
	/// than zero but less than the required size.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You should call this function twice, the first time to get the required buffer size (set mszLogSetNameList to <c>NULL</c> and
	/// pcchBufferLength to 0), and the second time to get the data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhenumlogsetnamesa PDH_FUNCTION PdhEnumLogSetNamesA( LPCSTR
	// szDataSource, PZZSTR mszDataSetNameList, LPDWORD pcchBufferLength );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "c74cc8a6-915b-40ed-a88b-bc2147215d52")]
	public static extern Win32Error PdhEnumLogSetNames(string szDataSource, IntPtr mszDataSetNameList, ref uint pcchBufferLength);

	/// <summary>
	/// <para>
	/// Returns a list of the computer names associated with counters in a log file. The computer names were either specified when adding
	/// counters to the query or when calling the PdhConnectMachine function. The computers listed include those that are currently
	/// connected and online, in addition to those that are offline or not returning performance data.
	/// </para>
	/// <para>To use handles to data sources, use the PdhEnumMachinesH function.</para>
	/// </summary>
	/// <param name="szDataSource">
	/// <c>Null</c>-terminated string that specifies the name of a log file. The function enumerates the names of the computers whose
	/// counter data is in the log file. If <c>NULL</c>, the function enumerates the list of computers that were specified when adding
	/// counters to a real time query or when calling the PdhConnectMachine function.
	/// </param>
	/// <param name="mszMachineList">
	/// Caller-allocated buffer to receive the list of <c>null</c>-terminated strings that contain the computer names. The list is
	/// terminated with two <c>null</c>-terminator characters. Set to <c>NULL</c> if pcchBufferLength is zero.
	/// </param>
	/// <param name="pcchBufferSize">
	/// Size of the mszMachineNameList buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this
	/// parameter to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the
	/// actual size of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you
	/// should not rely on the returned size to reallocate the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The mszMachineNameList buffer is too small to contain all the data. This return value is expected if pcchBufferLength is zero on
	/// input. If the specified size on input is greater than zero but less than the required size, you should not rely on the returned
	/// size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid. For example, on some releases you could receive this error if the specified size on input is greater
	/// than zero but less than the required size.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You should call this function twice, the first time to get the required buffer size (set mszMachineNameList to <c>NULL</c> and
	/// pcchBufferLength to 0), and the second time to get the data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhenummachinesa PDH_FUNCTION PdhEnumMachinesA( LPCSTR szDataSource,
	// PZZSTR mszMachineList, LPDWORD pcchBufferSize );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "77584d3b-3ba5-4288-b730-be2458f4fc1c")]
	public static extern Win32Error PdhEnumMachines([Optional] string? szDataSource, IntPtr mszMachineList, ref uint pcchBufferSize);

	/// <summary>
	/// <para>
	/// Returns a list of the computer names associated with counters in a log file. The computer names were either specified when adding
	/// counters to the query or when calling the PdhConnectMachine function. The computers listed include those that are currently
	/// connected and online, in addition to those that are offline or not returning performance data.
	/// </para>
	/// <para>This function is identical to the PdhEnumMachines function, except that it supports the use of handles to data sources.</para>
	/// </summary>
	/// <param name="hDataSource">Handle to a data source returned by the PdhBindInputDataSource function.</param>
	/// <param name="mszMachineList">
	/// Caller-allocated buffer to receive the list of <c>null</c>-terminated strings that contain the computer names. The list is
	/// terminated with two <c>null</c>-terminator characters. Set to <c>NULL</c> if pcchBufferLength is zero.
	/// </param>
	/// <param name="pcchBufferSize">
	/// Size of the mszMachineNameList buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this
	/// parameter to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the
	/// actual size of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you
	/// should not rely on the returned size to reallocate the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The mszMachineNameList buffer is too small to contain all the data. This return value is expected if pcchBufferLength is zero on
	/// input. If the specified size on input is greater than zero but less than the required size, you should not rely on the returned
	/// size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid. For example, on some releases you could receive this error if the specified size on input is greater
	/// than zero but less than the required size.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You should call this function twice, the first time to get the required buffer size (set mszMachineNameList to <c>NULL</c> and
	/// pcchBufferLength to 0), and the second time to get the data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhenummachinesha PDH_FUNCTION PdhEnumMachinesHA( PDH_HLOG
	// hDataSource, PZZSTR mszMachineList, LPDWORD pcchBufferSize );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "7e8dc113-76a7-4a7a-bbad-1a4387831501")]
	public static extern Win32Error PdhEnumMachinesH([Optional] PDH_HLOG hDataSource, IntPtr mszMachineList, ref uint pcchBufferSize);

	/// <summary>
	/// <para>
	/// Returns the specified object's counter and instance names that exist on the specified computer or in the specified log file.
	/// </para>
	/// <para>To use handles to data sources, use the PdhEnumObjectItemsH function.</para>
	/// </summary>
	/// <param name="szDataSource">
	/// <para>
	/// <c>Null</c>-terminated string that specifies the name of the log file used to enumerate the counter and instance names. If
	/// <c>NULL</c>, the function uses the computer specified in
	/// </para>
	/// <para>the szMachineName parameter to enumerate the names.</para>
	/// </param>
	/// <param name="szMachineName">
	/// <para>
	/// <c>Null</c>-terminated string that specifies the name of the computer that contains the counter and instance names that you want
	/// to enumerate.
	/// </para>
	/// <para>Include the leading slashes in the computer name, for example, \computername.</para>
	/// <para>If the szDataSource parameter is <c>NULL</c>, you can set szMachineName to <c>NULL</c> to specify the local computer.</para>
	/// </param>
	/// <param name="szObjectName">
	/// <c>Null</c>-terminated string that specifies the name of the object whose counter and instance names you want to enumerate.
	/// </param>
	/// <param name="mszCounterList">
	/// Caller-allocated buffer that receives a list of <c>null</c>-terminated counter names provided by the specified object. The list
	/// contains unique counter names. The list is terminated by two <c>NULL</c> characters. Set to <c>NULL</c> if the
	/// pcchCounterListLengthparameter is zero.
	/// </param>
	/// <param name="pcchCounterListLength">
	/// Size of the mszCounterList buffer, in <c>TCHARs</c>. If zero on input and the object exists, the function returns PDH_MORE_DATA
	/// and sets this parameter to the required buffer size. If the buffer is larger than the required size, the function sets this
	/// parameter to the actual size of the buffer that was used. If the specified size on input is greater than zero but less than the
	/// required size, you should not rely on the returned size to reallocate the buffer.
	/// </param>
	/// <param name="mszInstanceList">
	/// Caller-allocated buffer that receives a list of <c>null</c>-terminated instance names provided by the specified object. The list
	/// contains unique instance names. The list is terminated by two <c>NULL</c> characters. Set to <c>NULL</c> if
	/// pcchInstanceListLength is zero.
	/// </param>
	/// <param name="pcchInstanceListLength">
	/// <para>
	/// Size of the mszInstanceList buffer, in <c>TCHARs</c>. If zero on input and the object exists, the function returns PDH_MORE_DATA
	/// and sets this parameter to the required buffer size. If the buffer is larger than the required size, the function sets this
	/// parameter to the actual size of the buffer that was used. If the specified size on input is greater than zero but less than the
	/// required size, you should not rely on the returned size to reallocate the buffer.
	/// </para>
	/// <para>
	/// If the specified object does not support variable instances, then the returned value will be zero. If the specified object does
	/// support variable instances, but does not currently have any instances, then the value returned is 2, which is the size of an
	/// empty MULTI_SZ list string.
	/// </para>
	/// </param>
	/// <param name="dwDetailLevel">
	/// <para>
	/// Detail level of the performance items to return. All items that are of the specified detail level or less will be returned (the
	/// levels are listed in increasing order). This parameter can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PERF_DETAIL_NOVICE</term>
	/// <term>Novice user level of detail.</term>
	/// </item>
	/// <item>
	/// <term>PERF_DETAIL_ADVANCED</term>
	/// <term>Advanced user level of detail.</term>
	/// </item>
	/// <item>
	/// <term>PERF_DETAIL_EXPERT</term>
	/// <term>Expert user level of detail.</term>
	/// </item>
	/// <item>
	/// <term>PERF_DETAIL_WIZARD</term>
	/// <term>System designer level of detail.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">This parameter must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// One of the buffers is too small to contain the list of names. This return value is expected if pcchCounterListLength or
	/// pcchInstanceListLength is zero on input. If the specified size on input is greater than zero but less than the required size, you
	/// should not rely on the returned size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid. For example, on some releases you could receive this error if the specified size on input is greater
	/// than zero but less than the required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>Unable to allocate memory to support this function.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_MACHINE</term>
	/// <term>The specified computer is offline or unavailable.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_OBJECT</term>
	/// <term>The specified object could not be found on the specified computer or in the specified log file.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You should call this function twice, the first time to get the required buffer size (set the buffers to <c>NULL</c> and the sizes
	/// to 0), and the second time to get the data.
	/// </para>
	/// <para>
	/// Consecutive calls to this function will return identical lists of counters and instances, because <c>PdhEnumObjectItems</c> will
	/// always query the list of performance objects defined by the last call to PdhEnumObjects or <c>PdhEnumObjectItems</c>. To refresh
	/// the list of performance objects, call <c>PdhEnumObjects</c> with a bRefresh flag value of <c>TRUE</c> before calling
	/// <c>PdhEnumObjectItems</c> again.
	/// </para>
	/// <para>The order of the instance and counter names is undetermined.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Enumerating Process Objects.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhenumobjectitemsa PDH_FUNCTION PdhEnumObjectItemsA( LPCSTR
	// szDataSource, LPCSTR szMachineName, LPCSTR szObjectName, PZZSTR mszCounterList, LPDWORD pcchCounterListLength, PZZSTR
	// mszInstanceList, LPDWORD pcchInstanceListLength, DWORD dwDetailLevel, DWORD dwFlags );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "b3efdd31-44e6-47ff-bd0e-d31451c32818")]
	public static extern Win32Error PdhEnumObjectItems([Optional] string? szDataSource, [Optional] string? szMachineName, string szObjectName, [Optional] IntPtr mszCounterList, ref uint pcchCounterListLength, [Optional] IntPtr mszInstanceList, ref uint pcchInstanceListLength, PERF_DETAIL dwDetailLevel, uint dwFlags = 0);

	/// <summary>
	/// <para>
	/// Returns the specified object's counter and instance names that exist on the specified computer or in the specified log file.
	/// </para>
	/// <para>This function is identical to the PdhEnumObjectItems function, except that it supports the use of handles to data sources.</para>
	/// </summary>
	/// <param name="hDataSource">Handle to a data source returned by the PdhBindInputDataSource function.</param>
	/// <param name="szMachineName">
	/// <para>
	/// <c>Null</c>-terminated string that specifies the name of the computer that contains the counter and instance names that you want
	/// to enumerate.
	/// </para>
	/// <para>Include the leading slashes in the computer name, for example, \computername.</para>
	/// <para>If the szDataSource parameter is <c>NULL</c>, you can set szMachineName to <c>NULL</c> to specify the local computer.</para>
	/// </param>
	/// <param name="szObjectName">
	/// <c>Null</c>-terminated string that specifies the name of the object whose counter and instance names you want to enumerate.
	/// </param>
	/// <param name="mszCounterList">
	/// Caller-allocated buffer that receives a list of <c>null</c>-terminated counter names provided by the specified object. The list
	/// contains unique counter names. The list is terminated by two <c>NULL</c> characters. Set to <c>NULL</c> if the
	/// pcchCounterListLength parameter is zero.
	/// </param>
	/// <param name="pcchCounterListLength">
	/// Size of the mszCounterList buffer, in <c>TCHARs</c>. If zero on input and the object exists, the function returns PDH_MORE_DATA
	/// and sets this parameter to the required buffer size. If the buffer is larger than the required size, the function sets this
	/// parameter to the actual size of the buffer that was used. If the specified size on input is greater than zero but less than the
	/// required size, you should not rely on the returned size to reallocate the buffer.
	/// </param>
	/// <param name="mszInstanceList">
	/// Caller-allocated buffer that receives a list of <c>null</c>-terminated instance names provided by the specified object. The list
	/// contains unique instance names. The list is terminated by two <c>NULL</c> characters. Set to <c>NULL</c> if the
	/// pcchInstanceListLength parameter is zero.
	/// </param>
	/// <param name="pcchInstanceListLength">
	/// <para>
	/// Size of the mszInstanceList buffer, in <c>TCHARs</c>. If zero on input and the object exists, the function returns PDH_MORE_DATA
	/// and sets this parameter to the required buffer size. If the buffer is larger than the required size, the function sets this
	/// parameter to the actual size of the buffer that was used. If the specified size on input is greater than zero but less than the
	/// required size, you should not rely on the returned size to reallocate the buffer.
	/// </para>
	/// <para>
	/// If the specified object does not support variable instances, then the returned value will be zero. If the specified object does
	/// support variable instances, but does not currently have any instances, then the value returned is 2, which is the size of an
	/// empty MULTI_SZ list string.
	/// </para>
	/// </param>
	/// <param name="dwDetailLevel">
	/// <para>
	/// Detail level of the performance items to return. All items that are of the specified detail level or less will be returned (the
	/// levels are listed in increasing order). This parameter can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PERF_DETAIL_NOVICE</term>
	/// <term>Novice user level of detail.</term>
	/// </item>
	/// <item>
	/// <term>PERF_DETAIL_ADVANCED</term>
	/// <term>Advanced user level of detail.</term>
	/// </item>
	/// <item>
	/// <term>PERF_DETAIL_EXPERT</term>
	/// <term>Expert user level of detail.</term>
	/// </item>
	/// <item>
	/// <term>PERF_DETAIL_WIZARD</term>
	/// <term>System designer level of detail.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">This parameter must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// One of the buffers is too small to contain the list of names. This return value is expected if pcchCounterListLength or
	/// pcchInstanceListLength is zero on input. If the specified size on input is greater than zero but less than the required size, you
	/// should not rely on the returned size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid. For example, on some releases you could receive this error if the specified size on input is greater
	/// than zero but less than the required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>Unable to allocate memory to support this function.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_MACHINE</term>
	/// <term>The specified computer is offline or unavailable.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_OBJECT</term>
	/// <term>The specified object could not be found on the specified computer or in the specified log file.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You should call this function twice, the first time to get the required buffer size (set the buffers to <c>NULL</c> and the sizes
	/// to 0), and the second time to get the data.
	/// </para>
	/// <para>
	/// Consecutive calls to this function will return identical lists of counters and instances, because <c>PdhEnumObjectItemsH</c> will
	/// always query the list of performance objects defined by the last call to PdhEnumObjectsH or <c>PdhEnumObjectItemsH</c>. To
	/// refresh the list of performance objects, call <c>PdhEnumObjectsH</c> with a bRefresh flag value of <c>TRUE</c> before calling
	/// <c>PdhEnumObjectItemsH</c> again.
	/// </para>
	/// <para>The order of the instance and counter names is undetermined.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhenumobjectitemsha PDH_FUNCTION PdhEnumObjectItemsHA( PDH_HLOG
	// hDataSource, LPCSTR szMachineName, LPCSTR szObjectName, PZZSTR mszCounterList, LPDWORD pcchCounterListLength, PZZSTR
	// mszInstanceList, LPDWORD pcchInstanceListLength, DWORD dwDetailLevel, DWORD dwFlags );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "2cea7d0a-cea2-4fee-a087-37663de254e9")]
	public static extern Win32Error PdhEnumObjectItemsH([Optional] PDH_HLOG hDataSource, [Optional] string? szMachineName, string szObjectName, [Optional] IntPtr mszCounterList, ref uint pcchCounterListLength, [Optional] IntPtr mszInstanceList, ref uint pcchInstanceListLength, PERF_DETAIL dwDetailLevel, uint dwFlags = 0);

	/// <summary>
	/// <para>Returns a list of objects available on the specified computer or in the specified log file.</para>
	/// <para>To use handles to data sources, use the PdhEnumObjectsH function.</para>
	/// </summary>
	/// <param name="szDataSource">
	/// <para>
	/// <c>Null</c>-terminated string that specifies the name of the log file used to enumerate the performance objects. If <c>NULL</c>,
	/// the function uses the computer specified in
	/// </para>
	/// <para>the szMachineName parameter to enumerate the names.</para>
	/// </param>
	/// <param name="szMachineName">
	/// <para><c>Null</c>-terminated string that specifies the name of the computer used to enumerate the performance objects.</para>
	/// <para>Include the leading slashes in the computer name, for example, \computername.</para>
	/// <para>If the szDataSource parameter is <c>NULL</c>, you can set szMachineName to <c>NULL</c> to specify the local computer.</para>
	/// </param>
	/// <param name="mszObjectList">
	/// Caller-allocated buffer that receives the list of object names. Each object name in this list is terminated by a <c>null</c>
	/// character. The list is terminated with two <c>null</c>-terminator characters. Set to <c>NULL</c> if the pcchBufferLength
	/// parameter is zero.
	/// </param>
	/// <param name="pcchBufferSize">
	/// <para>
	/// Size of the mszObjectList buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this parameter
	/// to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the actual size
	/// of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you should not
	/// rely on the returned size to reallocate the buffer.
	/// </para>
	/// <para><c>Windows XP:</c> Add one to the required buffer size.</para>
	/// </param>
	/// <param name="dwDetailLevel">
	/// <para>
	/// Detail level of the performance items to return. All items that are of the specified detail level or less will be returned (the
	/// levels are listed in increasing order). This parameter can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PERF_DETAIL_NOVICE</term>
	/// <term>Novice user level of detail.</term>
	/// </item>
	/// <item>
	/// <term>PERF_DETAIL_ADVANCED</term>
	/// <term>Advanced user level of detail.</term>
	/// </item>
	/// <item>
	/// <term>PERF_DETAIL_EXPERT</term>
	/// <term>Expert user level of detail.</term>
	/// </item>
	/// <item>
	/// <term>PERF_DETAIL_WIZARD</term>
	/// <term>System designer level of detail.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bRefresh">
	/// <para>Indicates if the cached object list should be automatically refreshed. Specify one of the following values.</para>
	/// <para>
	/// If you call this function twice, once to get the size of the list and a second time to get the actual list, set this parameter to
	/// <c>TRUE</c> on the first call and <c>FALSE</c> on the second call. If both calls are <c>TRUE</c>, the second call may also return
	/// PDH_MORE_DATA because the object data may have changed between calls.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>The object cache is automatically refreshed before the objects are returned.</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>Do not automatically refresh the cache.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The mszObjectList buffer is too small to hold the list of objects. This return value is expected if pcchBufferLength is zero on
	/// input. If the specified size on input is greater than zero but less than the required size, you should not rely on the returned
	/// size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_MACHINE</term>
	/// <term>The specified computer is offline or unavailable.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_OBJECT</term>
	/// <term>The specified object could not be found.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid. For example, on some releases you could receive this error if the specified size on input is greater
	/// than zero but less than the required size.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You should call this function twice, the first time to get the required buffer size (set mszObjectList to <c>NULL</c> and
	/// pcchBufferLength to 0), and the second time to get the data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhenumobjectsa PDH_FUNCTION PdhEnumObjectsA( LPCSTR szDataSource,
	// LPCSTR szMachineName, PZZSTR mszObjectList, LPDWORD pcchBufferSize, DWORD dwDetailLevel, BOOL bRefresh );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "dfa4b10f-5134-4620-a6b0-0fa2c13a33ec")]
	public static extern Win32Error PdhEnumObjects([Optional] string? szDataSource, [Optional] string? szMachineName, [Optional] IntPtr mszObjectList, ref uint pcchBufferSize, PERF_DETAIL dwDetailLevel, [MarshalAs(UnmanagedType.Bool)] bool bRefresh);

	/// <summary>
	/// <para>Returns a list of objects available on the specified computer or in the specified log file.</para>
	/// <para>This function is identical to PdhEnumObjects, except that it supports the use of handles to data sources.</para>
	/// </summary>
	/// <param name="hDataSource">Handle to a data source returned by the PdhBindInputDataSource function.</param>
	/// <param name="szMachineName">
	/// <para><c>Null</c>-terminated string that specifies the name of the computer used to enumerate the performance objects.</para>
	/// <para>Include the leading slashes in the computer name, for example, \computername.</para>
	/// <para>If szDataSource is <c>NULL</c>, you can set szMachineName to <c>NULL</c> to specify the local computer.</para>
	/// </param>
	/// <param name="mszObjectList">
	/// Caller-allocated buffer that receives the list of object names. Each object name in this list is terminated by a <c>null</c>
	/// character. The list is terminated with two <c>null</c>-terminator characters. Set to <c>NULL</c> if pcchBufferLength is zero.
	/// </param>
	/// <param name="pcchBufferSize">
	/// <para>
	/// Size of the mszObjectList buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this parameter
	/// to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the actual size
	/// of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you should not
	/// rely on the returned size to reallocate the buffer.
	/// </para>
	/// <para><c>Windows XP:</c> Add one to the required buffer size.</para>
	/// </param>
	/// <param name="dwDetailLevel">
	/// <para>
	/// Detail level of the performance items to return. All items that are of the specified detail level or less will be returned (the
	/// levels are listed in increasing order). This parameter can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PERF_DETAIL_NOVICE</term>
	/// <term>Novice user level of detail.</term>
	/// </item>
	/// <item>
	/// <term>PERF_DETAIL_ADVANCED</term>
	/// <term>Advanced user level of detail.</term>
	/// </item>
	/// <item>
	/// <term>PERF_DETAIL_EXPERT</term>
	/// <term>Expert user level of detail.</term>
	/// </item>
	/// <item>
	/// <term>PERF_DETAIL_WIZARD</term>
	/// <term>System designer level of detail.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bRefresh">
	/// <para>Indicates if the cached object list should be automatically refreshed. Specify one of the following values.</para>
	/// <para>
	/// If you call this function twice, once to get the size of the list and a second time to get the actual list, set this parameter to
	/// <c>TRUE</c> on the first call and <c>FALSE</c> on the second call. If both calls are <c>TRUE</c>, the second call may also return
	/// PDH_MORE_DATA because the object data may have changed between calls.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TRUE</term>
	/// <term>The object cache is automatically refreshed before the objects are returned.</term>
	/// </item>
	/// <item>
	/// <term>FALSE</term>
	/// <term>Do not automatically refresh the cache.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The mszObjectList buffer is too small to hold the list of objects. This return value is expected if pcchBufferLength is zero on
	/// input. If the specified size on input is greater than zero but less than the required size, you should not rely on the returned
	/// size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_MACHINE</term>
	/// <term>The specified computer is offline or unavailable.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_OBJECT</term>
	/// <term>The specified object could not be found.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid. For example, on some releases you could receive this error if the specified size on input is greater
	/// than zero but less than the required size.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You should call this function twice, the first time to get the required buffer size (set mszObjectList to <c>NULL</c> and
	/// pcchBufferLength to 0), and the second time to get the data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhenumobjectsha PDH_FUNCTION PdhEnumObjectsHA( PDH_HLOG
	// hDataSource, LPCSTR szMachineName, PZZSTR mszObjectList, LPDWORD pcchBufferSize, DWORD dwDetailLevel, BOOL bRefresh );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "8f68a7a8-cc56-4f7f-a86f-4b439738808d")]
	public static extern Win32Error PdhEnumObjectsH([Optional] PDH_HLOG hDataSource, [Optional] string? szMachineName, [Optional] IntPtr mszObjectList, ref uint pcchBufferSize, PERF_DETAIL dwDetailLevel, [MarshalAs(UnmanagedType.Bool)] bool bRefresh);

	/// <summary>
	/// <para>
	/// Examines the specified computer (or local computer if none is specified) for counters and instances of counters that match the
	/// wildcard strings in the counter path.
	/// </para>
	/// <para><c>Note</c> This function is superseded by the PdhExpandWildCardPath function.</para>
	/// </summary>
	/// <param name="szWildCardPath">
	/// <c>Null</c>-terminated string that contains the counter path to expand. The function searches the computer specified in the path
	/// for matches. If the path does not specify a computer, the function searches the local computer. The maximum length of a counter
	/// path is PDH_MAX_COUNTER_PATH.
	/// </param>
	/// <param name="mszExpandedPathList">
	/// Caller-allocated buffer that receives the list of expanded counter paths that match the wildcard specification in szWildCardPath.
	/// Each counter path in this list is terminated by a <c>null</c> character. The list is terminated with two <c>NULL</c> characters.
	/// Set to <c>NULL</c> if pcchPathListLength is zero.
	/// </param>
	/// <param name="pcchPathListLength">
	/// <para>
	/// Size of the mszExpandedPathList buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this
	/// parameter to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the
	/// actual size of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you
	/// should not rely on the returned size to reallocate the buffer.
	/// </para>
	/// <para><c>Note</c> You must add one to the required size on Windows XP.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The mszExpandedPathList buffer is too small to contain the list of paths. This return value is expected if pcchPathListLength is
	/// zero on input. If the specified size on input is greater than zero but less than the required size, you should not rely on the
	/// returned size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid. For example, on some releases you could receive this error if the specified size on input is greater
	/// than zero but less than the required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>Unable to allocate memory to support this function.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You should call this function twice, the first time to get the required buffer size (set mszExpandedPathList to <c>NULL</c> and
	/// pcchPathListLength to 0), and the second time to get the data.
	/// </para>
	/// <para>The general counter path format is as follows:</para>
	/// <para>\computer\object(parent/instance#index)\counter</para>
	/// <para>
	/// The parent, instance, index, and counter components of the counter path may contain either a valid name or a wildcard character.
	/// The computer, parent, instance, and index components are not necessary for all counters.
	/// </para>
	/// <para>
	/// The counter paths that you must use is determined by the counter itself. For example, the LogicalDisk object has an instance
	/// index, so you must provide the #index, or a wildcard. Therefore, you could use the following format:
	/// </para>
	/// <para>\LogicalDisk(/#*)*</para>
	/// <para>In comparison, the Process object does not require an instance index. Therefore, you could use the following format:</para>
	/// <para>\Process(*)\ID Process</para>
	/// <para>The following is a list of the possible formats:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>\\computer\object(parent/instance#index)\counter</term>
	/// </item>
	/// <item>
	/// <term>\\computer\object(parent/instance)\counter</term>
	/// </item>
	/// <item>
	/// <term>\\computer\object(instance#index)\counter</term>
	/// </item>
	/// <item>
	/// <term>\\computer\object(instance)\counter</term>
	/// </item>
	/// <item>
	/// <term>\\computer\object\counter</term>
	/// </item>
	/// <item>
	/// <term>\object(parent/instance#index)\counter</term>
	/// </item>
	/// <item>
	/// <term>\object(parent/instance)\counter</term>
	/// </item>
	/// <item>
	/// <term>\object(instance#index)\counter</term>
	/// </item>
	/// <item>
	/// <term>\object(instance)\counter</term>
	/// </item>
	/// <item>
	/// <term>\object\counter</term>
	/// </item>
	/// </list>
	/// <para>
	/// If a wildcard character is specified in the parent name, all instances of the specified object that match the specified instance
	/// and counter fields will be returned.
	/// </para>
	/// <para>
	/// If a wildcard character is specified in the instance name, all instances of the specified object and parent object will be
	/// returned if all instance names corresponding to the specified index match the wildcard character.
	/// </para>
	/// <para>If a wildcard character is specified in the counter name, all counters of the specified object are returned.</para>
	/// <para>Partial counter path string matches (for example, "pro*") are not supported.</para>
	/// <para>Examples</para>
	/// <para>The following example demonstrates how to this function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhexpandcounterpatha PDH_FUNCTION PdhExpandCounterPathA( LPCSTR
	// szWildCardPath, PZZSTR mszExpandedPathList, LPDWORD pcchPathListLength );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "d90954ab-ec2f-42fd-90b7-66f59f3d1115")]
	public static extern Win32Error PdhExpandCounterPath(string szWildCardPath, [Optional] IntPtr mszExpandedPathList, ref uint pcchPathListLength);

	/// <summary>
	/// <para>
	/// Examines the specified computer or log file and returns those counter paths that match the given counter path which contains
	/// wildcard characters.
	/// </para>
	/// <para>To use handles to data sources, use the PdhExpandWildCardPathH function.</para>
	/// </summary>
	/// <param name="szDataSource">
	/// <para>
	/// <c>Null</c>-terminated string that contains the name of a log file. The function uses the performance objects and counters
	/// defined in the log file to expand the path specified in the szWildCardPath parameter.
	/// </para>
	/// <para>If <c>NULL</c>, the function searches the computer specified in szWildCardPath.</para>
	/// </param>
	/// <param name="szWildCardPath">
	/// <para><c>Null</c>-terminated string that specifies the counter path to expand. The maximum length of a counter path is PDH_MAX_COUNTER_PATH.</para>
	/// <para>
	/// If the szDataSource parameter is <c>NULL</c>, the function searches the computer specified in the path for matches. If the path
	/// does not specify a computer, the function searches the local computer.
	/// </para>
	/// </param>
	/// <param name="mszExpandedPathList">
	/// Caller-allocated buffer that receives a list of <c>null</c>-terminated counter paths that match the wildcard specification in the
	/// szWildCardPath. The list is terminated by two <c>NULL</c> characters. Set to <c>NULL</c> if pcchPathListLength is zero.
	/// </param>
	/// <param name="pcchPathListLength">
	/// <para>
	/// Size of the mszExpandedPathList buffer, in <c>TCHARs</c>. If zero on input and the object exists, the function returns
	/// PDH_MORE_DATA and sets this parameter to the required buffer size. If the buffer is larger than the required size, the function
	/// sets this parameter to the actual size of the buffer that was used. If the specified size on input is greater than zero but less
	/// than the required size, you should not rely on the returned size to reallocate the buffer.
	/// </para>
	/// <para><c>Note</c> You must add one to the required size on Windows XP.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flags that indicate which wildcard characters not to expand. You can specify one or more flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_NOEXPANDCOUNTERS</term>
	/// <term>Do not expand the counter name if the path contains a wildcard character for counter name.</term>
	/// </item>
	/// <item>
	/// <term>PDH_NOEXPANDINSTANCES</term>
	/// <term>
	/// Do not expand the instance name if the path contains a wildcard character for parent instance, instance name, or instance index.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The mszExpandedPathList buffer is not large enough to contain the list of paths. This return value is expected if
	/// pcchPathListLength is zero on input. If the specified size on input is greater than zero but less than the required size, you
	/// should not rely on the returned size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid. For example, on some releases you could receive this error if the specified size on input is greater
	/// than zero but less than the required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_PATH</term>
	/// <term>The specified object does not contain an instance.</term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>Unable to allocate memory to support this function.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_OBJECT</term>
	/// <term>Unable to find the specified object on the computer or in the log file.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You should call this function twice, the first time to get the required buffer size (set mszExpandedPathList to <c>NULL</c> and
	/// pcchPathListLength to 0), and the second time to get the data.
	/// </para>
	/// <para><c>PdhExpandWildCardPath</c> differs from PdhExpandCounterPath in the following ways:</para>
	/// <list type="number">
	/// <item>
	/// <term>Lets you control which wildcard characters are expanded.</term>
	/// </item>
	/// <item>
	/// <term>The contents of a log file can be used as the source of counter names.</term>
	/// </item>
	/// </list>
	/// <para>The general counter path format is as follows:</para>
	/// <para>\computer\object(parent/instance#index)\counter</para>
	/// <para>
	/// The parent, instance, index, and counter components of the counter path may contain either a valid name or a wildcard character.
	/// The computer, parent, instance, and index components are not necessary for all counters.
	/// </para>
	/// <para>The following is a list of the possible formats:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>\\computer\object(parent/instance#index)\counter</term>
	/// </item>
	/// <item>
	/// <term>\\computer\object(parent/instance)\counter</term>
	/// </item>
	/// <item>
	/// <term>\\computer\object(instance#index)\counter</term>
	/// </item>
	/// <item>
	/// <term>\\computer\object(instance)\counter</term>
	/// </item>
	/// <item>
	/// <term>\\computer\object\counter</term>
	/// </item>
	/// <item>
	/// <term>\object(parent/instance#index)\counter</term>
	/// </item>
	/// <item>
	/// <term>\object(parent/instance)\counter</term>
	/// </item>
	/// <item>
	/// <term>\object(instance#index)\counter</term>
	/// </item>
	/// <item>
	/// <term>\object(instance)\counter</term>
	/// </item>
	/// <item>
	/// <term>\object\counter</term>
	/// </item>
	/// </list>
	/// <para>Use an asterisk (*) as the wildcard character, for example, \object(*)\counter.</para>
	/// <para>
	/// If a wildcard character is specified in the parent name, all instances of the specified object that match the specified instance
	/// and counter fields will be returned. For example, \object(*/instance)\counter.
	/// </para>
	/// <para>
	/// If a wildcard character is specified in the instance name, all instances of the specified object and parent object will be
	/// returned if all instance names corresponding to the specified index match the wildcard character. For example,
	/// \object(parent/*)\counter. If the object does not contain an instance, an error occurs.
	/// </para>
	/// <para>If a wildcard character is specified in the counter name, all counters of the specified object are returned.</para>
	/// <para>Partial counter path string matches (for example, "pro*") are supported.</para>
	/// <para><c>Prior to Windows Vista:</c> Partial wildcard matches are not supprted.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhexpandwildcardpatha PDH_FUNCTION PdhExpandWildCardPathA( LPCSTR
	// szDataSource, LPCSTR szWildCardPath, PZZSTR mszExpandedPathList, LPDWORD pcchPathListLength, DWORD dwFlags );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "415da310-de56-4d58-8959-231426867526")]
	public static extern Win32Error PdhExpandWildCardPath([Optional] string? szDataSource, string szWildCardPath, [Optional] IntPtr mszExpandedPathList, ref uint pcchPathListLength, PdhExpandFlags dwFlags);

	/// <summary>
	/// <para>
	/// Examines the specified computer or log file and returns those counter paths that match the given counter path which contains
	/// wildcard characters.
	/// </para>
	/// <para>This function is identical to the PdhExpandWildCardPath function, except that it supports the use of handles to data sources.</para>
	/// </summary>
	/// <param name="hDataSource">Handle to a data source returned by the PdhBindInputDataSource function.</param>
	/// <param name="szWildCardPath">
	/// <para><c>Null</c>-terminated string that specifies the counter path to expand. The maximum length of a counter path is PDH_MAX_COUNTER_PATH.</para>
	/// <para>
	/// If hDataSource is a real time data source, the function searches the computer specified in the path for matches. If the path does
	/// not specify a computer, the function searches the local computer.
	/// </para>
	/// </param>
	/// <param name="mszExpandedPathList">
	/// Caller-allocated buffer that receives a list of <c>null</c>-terminated counter paths that match the wildcard specification in the
	/// szWildCardPath. The list is terminated by two <c>NULL</c> characters. Set to <c>NULL</c> if pcchPathListLength is zero.
	/// </param>
	/// <param name="pcchPathListLength">
	/// <para>
	/// Size of the mszExpandedPathList buffer, in <c>TCHARs</c>. If zero on input and the object exists, the function returns
	/// PDH_MORE_DATA and sets this parameter to the required buffer size. If the buffer is larger than the required size, the function
	/// sets this parameter to the actual size of the buffer that was used. If the specified size on input is greater than zero but less
	/// than the required size, you should not rely on the returned size to reallocate the buffer.
	/// </para>
	/// <para><c>Note</c> You must add one to the required size on Windows XP.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flags that indicate which wildcard characters not to expand. You can specify one or more flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_NOEXPANDCOUNTERS</term>
	/// <term>Do not expand the counter name if the path contains a wildcard character for counter name.</term>
	/// </item>
	/// <item>
	/// <term>PDH_NOEXPANDINSTANCES</term>
	/// <term>
	/// Do not expand the instance name if the path contains a wildcard character for parent instance, instance name, or instance index.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The mszExpandedPathList buffer is not large enough to contain the list of paths. This return value is expected if
	/// pcchPathListLength is zero on input. If the specified size on input is greater than zero but less than the required size, you
	/// should not rely on the returned size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid. For example, on some releases you could receive this error if the specified size on input is greater
	/// than zero but less than the required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>Unable to allocate memory to support this function.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_OBJECT</term>
	/// <term>Unable to find the specified object on the computer or in the log file.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You should call this function twice, the first time to get the required buffer size (set mszExpandedPathList to <c>NULL</c> and
	/// pcchPathListLength to 0), and the second time to get the data.
	/// </para>
	/// <para><c>PdhExpandWildCardPathH</c> differs from PdhExpandCounterPath in the following ways:</para>
	/// <list type="number">
	/// <item>
	/// <term>Lets you control which wildcard characters are expanded.</term>
	/// </item>
	/// <item>
	/// <term>The contents of a log file can be used as the source of counter names.</term>
	/// </item>
	/// </list>
	/// <para>The general counter path format is as follows:</para>
	/// <para>\computer\object(parent/instance#index)\counter</para>
	/// <para>
	/// The parent, instance, index, and counter components of the counter path may contain either a valid name or a wildcard character.
	/// The computer, parent, instance, and index components are not necessary for all counters.
	/// </para>
	/// <para>The following is a list of the possible formats:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>\\computer\object(parent/instance#index)\counter</term>
	/// </item>
	/// <item>
	/// <term>\\computer\object(parent/instance)\counter</term>
	/// </item>
	/// <item>
	/// <term>\\computer\object(instance#index)\counter</term>
	/// </item>
	/// <item>
	/// <term>\\computer\object(instance)\counter</term>
	/// </item>
	/// <item>
	/// <term>\\computer\object\counter</term>
	/// </item>
	/// <item>
	/// <term>\object(parent/instance#index)\counter</term>
	/// </item>
	/// <item>
	/// <term>\object(parent/instance)\counter</term>
	/// </item>
	/// <item>
	/// <term>\object(instance#index)\counter</term>
	/// </item>
	/// <item>
	/// <term>\object(instance)\counter</term>
	/// </item>
	/// <item>
	/// <term>\object\counter</term>
	/// </item>
	/// </list>
	/// <para>Use an asterisk (*) as the wildcard character, for example, \object(*)\counter.</para>
	/// <para>
	/// If a wildcard character is specified in the parent name, all instances of the specified object that match the specified instance
	/// and counter fields will be returned. For example, \object(*/instance)\counter.
	/// </para>
	/// <para>
	/// If a wildcard character is specified in the instance name, all instances of the specified object and parent object will be
	/// returned if all instance names corresponding to the specified index match the wildcard character. For example, \object(parent/*)\counter.
	/// </para>
	/// <para>If a wildcard character is specified in the counter name, all counters of the specified object are returned.</para>
	/// <para>Partial counter path string matches (for example, "pro*") are supported.</para>
	/// <para><c>Prior to Windows Vista:</c> Partial wildcard matches are not supprted.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhexpandwildcardpathha PDH_FUNCTION PdhExpandWildCardPathHA(
	// PDH_HLOG hDataSource, LPCSTR szWildCardPath, PZZSTR mszExpandedPathList, LPDWORD pcchPathListLength, DWORD dwFlags );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "d7d13beb-02ab-4204-808e-d395197f09e1")]
	public static extern Win32Error PdhExpandWildCardPathH([Optional] PDH_HLOG hDataSource, string szWildCardPath, [Optional] IntPtr mszExpandedPathList, ref uint pcchPathListLength, PdhExpandFlags dwFlags);

	/// <summary>Computes a displayable value for the given raw counter values.</summary>
	/// <param name="dwCounterType">
	/// <para>
	/// Type of counter. Typically, you call PdhGetCounterInfo to retrieve the counter type at the time you call PdhGetRawCounterValue to
	/// retrieve the raw counter value.
	/// </para>
	/// <para>
	/// For a list of counter types, see the Counter Types section of the Windows Server 2003 Deployment Kit. (The constant values are
	/// defined in Winperf.h.)
	/// </para>
	/// <para>Note that you cannot specify base types, for example, PERF_LARGE_RAW_BASE.</para>
	/// </param>
	/// <param name="dwFormat">
	/// <para>Determines the data type of the calculated value. Specify one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_FMT_DOUBLE</term>
	/// <term>Return the calculated value as a double-precision floating point real.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_LARGE</term>
	/// <term>Return the calculated value as a 64-bit integer.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_LONG</term>
	/// <term>Return the calculated value as a long integer.</term>
	/// </item>
	/// </list>
	/// <para>You can use the bitwise inclusive OR operator (|) to combine the data type with one of the following scaling factors.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_FMT_NOSCALE</term>
	/// <term>Do not apply the counter's scaling factor in the calculation.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_NOCAP100</term>
	/// <term>
	/// Counter values greater than 100 (for example, counter values measuring the processor load on multiprocessor computers) will not
	/// be reset to 100. The default behavior is that counter values are capped at a value of 100.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_1000</term>
	/// <term>Multiply the final value by 1,000.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pTimeBase">
	/// Pointer to the time base, if necessary for the format conversion. If time base information is not necessary for the format
	/// conversion, the value of this parameter is ignored. To retrieve the time base of the counter, call PdhGetCounterTimeBase.
	/// </param>
	/// <param name="pRawValue1">Raw counter value used to compute the displayable counter value. For details, see PDH_RAW_COUNTER.</param>
	/// <param name="pRawValue2">
	/// Raw counter value used to compute the displayable counter value. For details, see PDH_RAW_COUNTER. Some counters, for example,
	/// rate counters, require two raw values to calculate a displayable value. If the counter type does not require a second value, set
	/// this parameter to <c>NULL</c>. This value must be the older of the two raw values.
	/// </param>
	/// <param name="pFmtValue">A PDH_FMT_COUNTERVALUE structure that receives the calculated counter value.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhformatfromrawvalue PDH_FUNCTION PdhFormatFromRawValue( DWORD
	// dwCounterType, DWORD dwFormat, LONGLONG *pTimeBase, PPDH_RAW_COUNTER pRawValue1, PPDH_RAW_COUNTER pRawValue2,
	// PPDH_FMT_COUNTERVALUE pFmtValue );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "13027af4-2e76-4c2f-88e8-a2554a16fae3")]
	public static extern Win32Error PdhFormatFromRawValue(CounterType dwCounterType, PDH_FMT dwFormat, in FILETIME pTimeBase, in PDH_RAW_COUNTER pRawValue1, in PDH_RAW_COUNTER pRawValue2, out PDH_FMT_COUNTERVALUE pFmtValue);

	/// <summary>Retrieves information about a counter, such as data size, counter type, path, and user-supplied data values.</summary>
	/// <param name="hCounter">
	/// Handle of the counter from which you want to retrieve information. The PdhAddCounter function returns this handle.
	/// </param>
	/// <param name="bRetrieveExplainText">
	/// Determines whether explain text is retrieved. If you set this parameter to <c>TRUE</c>, the explain text for the counter is
	/// retrieved. If you set this parameter to <c>FALSE</c>, the field in the returned buffer is <c>NULL</c>.
	/// </param>
	/// <param name="pdwBufferSize">
	/// Size of the lpBuffer buffer, in bytes. If zero on input, the function returns PDH_MORE_DATA and sets this parameter to the
	/// required buffer size. If the buffer is larger than the required size, the function sets this parameter to the actual size of the
	/// buffer that was used. If the specified size on input is greater than zero but less than the required size, you should not rely on
	/// the returned size to reallocate the buffer.
	/// </param>
	/// <param name="lpBuffer">
	/// Caller-allocated buffer that receives a <see cref="PDH_COUNTER_INFO"/> structure. The structure is variable-length, because the
	/// string data is appended to the end of the fixed-format portion of the structure. This is done so that all data is returned in a
	/// single buffer allocated by the caller. Set to <c>NULL</c> if pdwBufferSize is zero.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid or is incorrectly formatted. For example, on some releases you could receive this error if the specified
	/// size on input is greater than zero but less than the required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The counter handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The lpBuffer buffer is too small to hold the counter information. This return value is expected if pdwBufferSize is zero on
	/// input. If the specified size on input is greater than zero but less than the required size, you should not rely on the returned
	/// size to reallocate the buffer.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You should call this function twice, the first time to get the required buffer size (set lpBuffer to <c>NULL</c> and
	/// pdwBufferSize to 0), and the second time to get the data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetcounterinfoa PDH_FUNCTION PdhGetCounterInfoA( PDH_HCOUNTER
	// hCounter, BOOLEAN bRetrieveExplainText, LPDWORD pdwBufferSize, PPDH_COUNTER_INFO_A lpBuffer );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "12e1a194-5418-4c2a-9853-ef2d2c666893")]
	public static extern Win32Error PdhGetCounterInfo(PDH_HCOUNTER hCounter, [MarshalAs(UnmanagedType.U1)] bool bRetrieveExplainText, ref uint pdwBufferSize, IntPtr lpBuffer);

	/// <summary>Returns the time base of the specified counter.</summary>
	/// <param name="hCounter">Handle to the counter. The PdhAddCounter function returns this handle.</param>
	/// <param name="pTimeBase">Time base that specifies the number of performance values a counter samples per second.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>The specified counter does not use a time base.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The counter handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If you use the PdhFormatFromRawValue function to calculate a displayable value instead of calling the
	/// PdhCalculateCounterFromRawValue function, you must call the <c>PdhGetCounterTimeBase</c> function to retrieve the time base.
	/// </para>
	/// <para>
	/// Each counter that returns time-based performance data has a time base defined for it. The time base of a counter is the number of
	/// times a counter samples data per second.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetcountertimebase PDH_FUNCTION PdhGetCounterTimeBase(
	// PDH_HCOUNTER hCounter, LONGLONG *pTimeBase );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "b034c00e-50f1-46af-aebc-0cb968c0b737")]
	public static extern Win32Error PdhGetCounterTimeBase(PDH_HCOUNTER hCounter, out FILETIME pTimeBase);

	/// <summary>
	/// <para>
	/// Determines the time range, number of entries and, if applicable, the size of the buffer containing the performance data from the
	/// specified input source.
	/// </para>
	/// <para>To use handles to data sources, use the PdhGetDataSourceTimeRangeH function.</para>
	/// </summary>
	/// <param name="szDataSource">
	/// Null-terminated string that specifies the name of a log file from which the time range information is retrieved.
	/// </param>
	/// <param name="pdwNumEntries">
	/// Number of structures in the pInfo buffer. This function collects information for only one time range, so the value is typically
	/// 1, or zero if an error occurred.
	/// </param>
	/// <param name="pInfo">A PDH_TIME_INFO structure that receives the time range.</param>
	/// <param name="pdwBufferSize">Size of the PDH_TIME_INFO structure, in bytes.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>A parameter is not valid or is incorrectly formatted.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The counter handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>PDH_DATA_SOURCE_IS_REAL_TIME</term>
	/// <term>The current data source is a real-time data source.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetdatasourcetimerangea PDH_FUNCTION PdhGetDataSourceTimeRangeA(
	// LPCSTR szDataSource, LPDWORD pdwNumEntries, PPDH_TIME_INFO pInfo, LPDWORD pdwBufferSize );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "142ee829-7f1c-4b97-859c-670f7058dfa1")]
	public static extern Win32Error PdhGetDataSourceTimeRange(string szDataSource, out uint pdwNumEntries, out PDH_TIME_INFO pInfo, ref uint pdwBufferSize);

	/// <summary>
	/// <para>
	/// Determines the time range, number of entries and, if applicable, the size of the buffer containing the performance data from the
	/// specified input source.
	/// </para>
	/// <para>
	/// This function is identical to the PdhGetDataSourceTimeRange function, except that it supports the use of handles to data sources.
	/// </para>
	/// </summary>
	/// <param name="hDataSource">Handle to a data source returned by the PdhBindInputDataSource function.</param>
	/// <param name="pdwNumEntries">
	/// Number of structures in the pInfo buffer. This function collects information for only one time range, so the value is typically
	/// 1, or zero if an error occurred.
	/// </param>
	/// <param name="pInfo">A PDH_TIME_INFO structure that receives the time range. The information spans all bound log files.</param>
	/// <param name="pdwBufferSize">Size of the PDH_TIME_INFO structure, in bytes.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>A parameter is not valid or is incorrectly formatted.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The counter handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>PDH_DATA_SOURCE_IS_REAL_TIME</term>
	/// <term>The current data source is a real-time data source.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetdatasourcetimerangeh PDH_FUNCTION PdhGetDataSourceTimeRangeH(
	// PDH_HLOG hDataSource, LPDWORD pdwNumEntries, PPDH_TIME_INFO pInfo, LPDWORD pdwBufferSize );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "55cfef46-999d-43fa-9b09-9d8916fbf755")]
	public static extern Win32Error PdhGetDataSourceTimeRangeH(PDH_HLOG hDataSource, out uint pdwNumEntries, out PDH_TIME_INFO pInfo, ref uint pdwBufferSize);

	/// <summary>
	/// <para>
	/// Retrieves the name of the default counter for the specified object. This name can be used to set the initial counter selection in
	/// the Browse Counter dialog box.
	/// </para>
	/// <para>To use handles to data sources, use the PdhGetDefaultPerfCounterH function.</para>
	/// </summary>
	/// <param name="szDataSource">Should be <c>NULL</c>.</param>
	/// <param name="szMachineName">
	/// <c>Null</c>-terminated string that specifies the name of the computer used to verify the object name. If <c>NULL</c>, the local
	/// computer is used to verify the object name.
	/// </param>
	/// <param name="szObjectName">
	/// <c>Null</c>-terminated string that specifies the name of the object whose default counter name you want to retrieve.
	/// </param>
	/// <param name="szDefaultCounterName">
	/// Caller-allocated buffer that receives the <c>null</c>-terminated default counter name. Set to <c>NULL</c> if pcchBufferSize is zero.
	/// </param>
	/// <param name="pcchBufferSize">
	/// Size of the szDefaultCounterName buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this
	/// parameter to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the
	/// actual size of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you
	/// should not rely on the returned size to reallocate the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The szDefaultCounterName buffer is too small to contain the counter name. This return value is expected if pcchBufferSize is zero
	/// on input. If the specified size on input is greater than zero but less than the required size, you should not rely on the
	/// returned size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A required parameter is not valid. For example, on some releases you could receive this error if the specified size on input is
	/// greater than zero but less than the required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>Unable to allocate memory in order to complete the function.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_MACHINE</term>
	/// <term>The specified computer is offline or unavailable.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_COUNTERNAME</term>
	/// <term>The default counter name cannot be read or found.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_OBJECT</term>
	/// <term>The specified object could not be found.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_COUNTER</term>
	/// <term>The object did not specify a default counter.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You should call this function twice, the first time to get the required buffer size (set szDefaultCounterName to <c>NULL</c> and
	/// pcchBufferSize to 0), and the second time to get the data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetdefaultperfcountera PDH_FUNCTION PdhGetDefaultPerfCounterA(
	// LPCSTR szDataSource, LPCSTR szMachineName, LPCSTR szObjectName, LPSTR szDefaultCounterName, LPDWORD pcchBufferSize );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "0eb78071-3496-40e9-91b0-3c06547c88d5")]
	public static extern Win32Error PdhGetDefaultPerfCounter([Optional] string? szDataSource, [Optional] string? szMachineName, string szObjectName, [Optional] StringBuilder szDefaultCounterName, ref uint pcchBufferSize);

	/// <summary>
	/// <para>
	/// Retrieves the name of the default counter for the specified object. This name can be used to set the initial counter selection in
	/// the Browse Counter dialog box.
	/// </para>
	/// <para>This function is identical to PdhGetDefaultPerfCounter, except that it supports the use of handles to data sources.</para>
	/// </summary>
	/// <param name="hDataSource">Should be <c>NULL</c>.</param>
	/// <param name="szMachineName">
	/// <c>Null</c>-terminated string that specifies the name of the computer used to verify the object name. If <c>NULL</c>, the local
	/// computer is used to verify the name.
	/// </param>
	/// <param name="szObjectName">
	/// <c>Null</c>-terminated string that specifies the name of the object whose default counter name you want to retrieve.
	/// </param>
	/// <param name="szDefaultCounterName">
	/// Caller-allocated buffer that receives the <c>null</c>-terminated default counter name. Set to <c>NULL</c> if pcchBufferSize is zero.
	/// </param>
	/// <param name="pcchBufferSize">
	/// Size of the szDefaultCounterName buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this
	/// parameter to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the
	/// actual size of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you
	/// should not rely on the returned size to reallocate the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The szDefaultCounterName buffer is too small to contain the counter name. This return value is expected if pcchBufferSize is zero
	/// on input. If the specified size on input is greater than zero but less than the required size, you should not rely on the
	/// returned size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A required parameter is not valid. For example, on some releases you could receive this error if the specified size on input is
	/// greater than zero but less than the required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>Unable to allocate memory in order to complete the function.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_MACHINE</term>
	/// <term>The specified computer is offline or unavailable.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_COUNTERNAME</term>
	/// <term>The default counter name cannot be read or found.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_OBJECT</term>
	/// <term>The specified object could not be found.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_COUNTER</term>
	/// <term>The object did not specify a default counter.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You should call this function twice, the first time to get the required buffer size (set szDefaultCounterName to <c>NULL</c> and
	/// pcchBufferSize to 0), and the second time to get the data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetdefaultperfcounterha PDH_FUNCTION PdhGetDefaultPerfCounterHA(
	// PDH_HLOG hDataSource, LPCSTR szMachineName, LPCSTR szObjectName, LPSTR szDefaultCounterName, LPDWORD pcchBufferSize );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "d1b3de9a-99ab-4339-8e9f-906f5a5d291d")]
	public static extern Win32Error PdhGetDefaultPerfCounterH([Optional] PDH_HLOG hDataSource, [Optional] string? szMachineName, string szObjectName, [Optional] StringBuilder szDefaultCounterName, ref uint pcchBufferSize);

	/// <summary>
	/// <para>
	/// Retrieves the name of the default object. This name can be used to set the initial object selection in the Browse Counter dialog box.
	/// </para>
	/// <para>To use handles to data sources, use the PdhGetDefaultPerfObjectH function.</para>
	/// </summary>
	/// <param name="szDataSource">Should be <c>NULL</c>.</param>
	/// <param name="szMachineName">
	/// <c>Null</c>-terminated string that specifies the name of the computer used to verify the object name. If <c>NULL</c>, the local
	/// computer is used to verify the name.
	/// </param>
	/// <param name="szDefaultObjectName">
	/// <para>
	/// Caller-allocated buffer that receives the <c>null</c>-terminated default object name. Set to <c>NULL</c> if the pcchBufferSize
	/// parameter is zero.
	/// </para>
	/// <para>Note that PDH always returns Processor for the default object name.</para>
	/// </param>
	/// <param name="pcchBufferSize">
	/// Size of the szDefaultObjectName buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this
	/// parameter to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the
	/// actual size of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you
	/// should not rely on the returned size to reallocate the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The szDefaultObjectName buffer is too small to contain the object name. This return value is expected if pcchBufferSize is zero
	/// on input. If the specified size on input is greater than zero but less than the required size, you should not rely on the
	/// returned size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A required parameter is not valid. For example, on some releases you could receive this error if the specified size on input is
	/// greater than zero but less than the required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>Unable to allocate memory in order to complete the function.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_MACHINE</term>
	/// <term>The specified computer is offline or unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You should call this function twice, the first time to get the required buffer size (set szDefaultObjectName to <c>NULL</c> and
	/// pcchBufferSize to 0), and the second time to get the data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetdefaultperfobjecta PDH_FUNCTION PdhGetDefaultPerfObjectA(
	// LPCSTR szDataSource, LPCSTR szMachineName, LPSTR szDefaultObjectName, LPDWORD pcchBufferSize );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "7c6d4d82-8b60-4422-8108-8ac10f254278")]
	public static extern Win32Error PdhGetDefaultPerfObject([Optional] string? szDataSource, [Optional] string? szMachineName, [Optional] StringBuilder szDefaultObjectName, ref uint pcchBufferSize);

	/// <summary>
	/// <para>
	/// Retrieves the name of the default object. This name can be used to set the initial object selection in the Browse Counter dialog box.
	/// </para>
	/// <para>
	/// This function is identical to the PdhGetDefaultPerfObject function, except that it supports the use of handles to data sources.
	/// </para>
	/// </summary>
	/// <param name="hDataSource">Should be <c>NULL</c>.</param>
	/// <param name="szMachineName">
	/// <c>Null</c>-terminated string that specifies the name of the computer used to verify the object name. If <c>NULL</c>, the local
	/// computer is used to verify the name.
	/// </param>
	/// <param name="szDefaultObjectName">
	/// <para>
	/// Caller-allocated buffer that receives the <c>null</c>-terminated default object name. Set to <c>NULL</c> if pcchBufferSize is zero.
	/// </para>
	/// <para>Note that PDH always returns Processor for the default object name.</para>
	/// </param>
	/// <param name="pcchBufferSize">
	/// Size of the szDefaultObjectName buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this
	/// parameter to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the
	/// actual size of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you
	/// should not rely on the returned size to reallocate the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The szDefaultObjectName buffer is too small to contain the object name. This return value is expected if pcchBufferSize is zero
	/// on input. If the specified size on input is greater than zero but less than the required size, you should not rely on the
	/// returned size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A required parameter is not valid. For example, on some releases you could receive this error if the specified size on input is
	/// greater than zero but less than the required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>Unable to allocate memory in order to complete the function.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_MACHINE</term>
	/// <term>The specified computer is offline or unavailable.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_COUNTERNAME</term>
	/// <term>The default object name cannot be read or found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You should call this function twice, the first time to get the required buffer size (set szDefaultObjectName to <c>NULL</c> and
	/// pcchBufferSize to 0), and the second time to get the data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetdefaultperfobjectha PDH_FUNCTION PdhGetDefaultPerfObjectHA(
	// PDH_HLOG hDataSource, LPCSTR szMachineName, LPSTR szDefaultObjectName, LPDWORD pcchBufferSize );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "4950d5b7-3a6f-410d-830f-7868aa84f6d5")]
	public static extern Win32Error PdhGetDefaultPerfObjectH([Optional] PDH_HLOG hDataSource, [Optional] string? szMachineName, [Optional] StringBuilder szDefaultObjectName, ref uint pcchBufferSize);

	/// <summary>
	/// <para>Returns the version of the currently installed Pdh.dll file.</para>
	/// <para><c>Note</c> This function is obsolete and no longer supported.</para>
	/// </summary>
	/// <param name="lpdwVersion">
	/// <para>Pointer to a variable that receives the version of Pdh.dll. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_CVERSION_WIN50</term>
	/// <term>The file version is a legacy operating system.</term>
	/// </item>
	/// <item>
	/// <term>PDH_VERSION</term>
	/// <term>The file version is Windows XP.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// </returns>
	/// <remarks>This function is used to help in determining the functionality that the currently installed version of Pdh.dll supports.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetdllversion PDH_FUNCTION PdhGetDllVersion( LPDWORD lpdwVersion );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "09c9ecf6-43e0-480c-b607-537632b56576")]
	public static extern Win32Error PdhGetDllVersion(out uint lpdwVersion);

	/// <summary>
	/// Returns an array of formatted counter values. Use this function when you want to format the counter values of a counter that
	/// contains a wildcard character for the instance name.
	/// </summary>
	/// <param name="hCounter">
	/// Handle to the counter whose current value you want to format. The PdhAddCounter function returns this handle.
	/// </param>
	/// <param name="dwFormat">
	/// <para>Determines the data type of the formatted value. Specify one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_FMT_DOUBLE</term>
	/// <term>Return data as a double-precision floating point real.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_LARGE</term>
	/// <term>Return data as a 64-bit integer.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_LONG</term>
	/// <term>Return data as a long integer.</term>
	/// </item>
	/// </list>
	/// <para>You can use the bitwise inclusive OR operator (|) to combine the data type with one of the following scaling factors.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_FMT_NOSCALE</term>
	/// <term>Do not apply the counter's default scaling factor.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_NOCAP100</term>
	/// <term>
	/// Counter values greater than 100 (for example, counter values measuring the processor load on multiprocessor computers) will not
	/// be reset to 100. The default behavior is that counter values are capped at a value of 100.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_1000</term>
	/// <term>Multiply the actual value by 1,000.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpdwBufferSize">
	/// Size of the ItemBuffer buffer, in bytes. If zero on input, the function returns PDH_MORE_DATA and sets this parameter to the
	/// required buffer size. If the buffer is larger than the required size, the function sets this parameter to the actual size of the
	/// buffer that was used. If the specified size on input is greater than zero but less than the required size, you should not rely on
	/// the returned size to reallocate the buffer.
	/// </param>
	/// <param name="lpdwItemCount">Number of counter values in the ItemBuffer buffer.</param>
	/// <param name="ItemBuffer">
	/// Caller-allocated buffer that receives an array of PDH_FMT_COUNTERVALUE_ITEM structures; the structures contain the counter
	/// values. Set to <c>NULL</c> if lpdwBufferSize is zero.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The ItemBuffer buffer is not large enough to contain the object name. This return value is expected if lpdwBufferSize is zero on
	/// input. If the specified size on input is greater than zero but less than the required size, you should not rely on the returned
	/// size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid or is incorrectly formatted. For example, on some releases you could receive this error if the specified
	/// size on input is greater than zero but less than the required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The counter handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You should call this function twice, the first time to get the required buffer size (set ItemBuffer to <c>NULL</c> and
	/// lpdwBufferSize to 0), and the second time to get the data.
	/// </para>
	/// <para>
	/// The data for the counter is locked for the duration of the call to <c>PdhGetFormattedCounterArray</c> to prevent any changes
	/// during the processing of the call.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows how to use this function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetformattedcounterarraya PDH_FUNCTION
	// PdhGetFormattedCounterArrayA( PDH_HCOUNTER hCounter, DWORD dwFormat, LPDWORD lpdwBufferSize, LPDWORD lpdwItemCount,
	// PPDH_FMT_COUNTERVALUE_ITEM_A ItemBuffer );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "0f388c7e-d0c8-461d-908c-48af92166996")]
	public static extern Win32Error PdhGetFormattedCounterArray(PDH_HCOUNTER hCounter, PDH_FMT dwFormat, ref uint lpdwBufferSize, out uint lpdwItemCount, [Optional] IntPtr ItemBuffer);

	/// <summary>Computes a displayable value for the specified counter.</summary>
	/// <param name="hCounter">
	/// Handle of the counter for which you want to compute a displayable value. The PdhAddCounter function returns this handle.
	/// </param>
	/// <param name="dwFormat">
	/// <para>Determines the data type of the formatted value. Specify one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_FMT_DOUBLE</term>
	/// <term>Return data as a double-precision floating point real.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_LARGE</term>
	/// <term>Return data as a 64-bit integer.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_LONG</term>
	/// <term>Return data as a long integer.</term>
	/// </item>
	/// </list>
	/// <para>You can use the bitwise inclusive OR operator (|) to combine the data type with one of the following scaling factors.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_FMT_NOSCALE</term>
	/// <term>Do not apply the counter's default scaling factor.</term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_NOCAP100</term>
	/// <term>
	/// Counter values greater than 100 (for example, counter values measuring the processor load on multiprocessor computers) will not
	/// be reset to 100. The default behavior is that counter values are capped at a value of 100.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_FMT_1000</term>
	/// <term>Multiply the actual value by 1,000.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpdwType">
	/// Receives the counter type. For a list of counter types, see the Counter Types section of the Windows Server 2003 Deployment Kit.
	/// This parameter is optional.
	/// </param>
	/// <param name="pValue">A PDH_FMT_COUNTERVALUE structure that receives the counter value.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>A parameter is not valid or is incorrectly formatted.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_DATA</term>
	/// <term>The specified counter does not contain valid data or a successful status code.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The counter handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The data for the counter is locked (protected) for the duration of the call to <c>PdhGetFormattedCounterValue</c> to prevent any
	/// changes during the processing of the call. Reading the data (calling this function successfully) clears the data-changed flag for
	/// the counter.
	/// </para>
	/// <para>
	/// Some counters, such as rate counters, require two counter values in order to compute a displayable value. In this case you must
	/// call PdhCollectQueryData twice before calling <c>PdhGetFormattedCounterValue</c>. For more information, see Collecting
	/// Performance Data.
	/// </para>
	/// <para>
	/// If the specified counter instance does not exist, the method will return PDH_INVALID_DATA and set the <c>CStatus</c> member of
	/// the PDH_FMT_COUNTERVALUE structure to PDH_CSTATUS_NO_INSTANCE.
	/// </para>
	/// <para>
	/// <c>Prior to Windows Server 2003:</c> The format call may fail for counters that require only a single value when the instance is
	/// not found. Try calling the query and format calls again. If the format call fails the second time, the instance is not found. As
	/// an alternative, you can call the PdhEnumObjects function with the refresh option set to <c>TRUE</c> to refresh the counter
	/// instances before querying and formatting the counter data.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Browsing Performance Counters or Reading Performance Data from a Log File.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetformattedcountervalue PDH_FUNCTION
	// PdhGetFormattedCounterValue( PDH_HCOUNTER hCounter, DWORD dwFormat, LPDWORD lpdwType, PPDH_FMT_COUNTERVALUE pValue );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "cd104b26-1498-4f95-a411-97d868b43836")]
	public static extern Win32Error PdhGetFormattedCounterValue(PDH_HCOUNTER hCounter, PDH_FMT dwFormat, out CounterType lpdwType, out PDH_FMT_COUNTERVALUE pValue);

	/// <summary>Returns the size of the specified log file.</summary>
	/// <param name="hLog">Handle to the log file. The PdhOpenLog or PdhBindInputDataSource function returns this handle.</param>
	/// <param name="llSize">Size of the log file, in bytes.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_LOG_FILE_OPEN_ERROR</term>
	/// <term>An error occurred when trying to open the log file.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// If the log file handle points to multiple bound log files, the size is the sum of all the log files. If the log file is a SQL log
	/// file, the llSize parameter is the number of records in the log file.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetlogfilesize PDH_FUNCTION PdhGetLogFileSize( PDH_HLOG hLog,
	// LONGLONG *llSize );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "2bb94019-c664-4144-98b6-a0a545f7e4c1")]
	public static extern Win32Error PdhGetLogFileSize(PDH_HLOG hLog, out long llSize);

	/// <summary>
	/// Returns an array of raw values from the specified counter. Use this function when you want to retrieve the raw counter values of
	/// a counter that contains a wildcard character for the instance name.
	/// </summary>
	/// <param name="hCounter">
	/// Handle of the counter for whose current raw instance values you want to retrieve. The PdhAddCounter function returns this handle.
	/// </param>
	/// <param name="lpdwBufferSize">
	/// Size of the ItemBuffer buffer, in bytes. If zero on input, the function returns PDH_MORE_DATA and sets this parameter to the
	/// required buffer size. If the buffer is larger than the required size, the function sets this parameter to the actual size of the
	/// buffer that was used. If the specified size on input is greater than zero but less than the required size, you should not rely on
	/// the returned size to reallocate the buffer.
	/// </param>
	/// <param name="lpdwItemCount">Number of raw counter values in the ItemBuffer buffer.</param>
	/// <param name="ItemBuffer">
	/// Caller-allocated buffer that receives the array of <see cref="PDH_RAW_COUNTER_ITEM"/> structures; the structures contain the raw
	/// instance counter values. Set to <c>NULL</c> if lpdwBufferSize is zero.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The ItemBuffer buffer is not large enough to contain the object name. This return value is expected if lpdwBufferSize is zero on
	/// input. If the specified size on input is greater than zero but less than the required size, you should not rely on the returned
	/// size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid or is incorrectly formatted. For example, on some releases you could receive this error if the specified
	/// size on input is greater than zero but less than the required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The counter handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You should call this function twice, the first time to get the required buffer size (set ItemBuffer to <c>NULL</c> and
	/// lpdwBufferSize to 0), and the second time to get the data.
	/// </para>
	/// <para>
	/// The data for the counter is locked for the duration of the call to <c>PdhGetRawCounterArray</c> to prevent any changes during
	/// processing of the call.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetrawcounterarraya PDH_FUNCTION PdhGetRawCounterArrayA(
	// PDH_HCOUNTER hCounter, LPDWORD lpdwBufferSize, LPDWORD lpdwItemCount, PPDH_RAW_COUNTER_ITEM_A ItemBuffer );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "03b30d08-6901-45cd-bd6d-d2672eb0f914")]
	public static extern Win32Error PdhGetRawCounterArray(PDH_HCOUNTER hCounter, ref uint lpdwBufferSize, out uint lpdwItemCount, IntPtr ItemBuffer);

	/// <summary>Returns the current raw value of the counter.</summary>
	/// <param name="hCounter">
	/// Handle of the counter from which to retrieve the current raw value. The PdhAddCounter function returns this handle.
	/// </param>
	/// <param name="lpdwType">
	/// Receives the counter type. For a list of counter types, see the Counter Types section of the Windows Server 2003 Deployment Kit.
	/// This parameter is optional.
	/// </param>
	/// <param name="pValue">A PDH_RAW_COUNTER structure that receives the counter value.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>A parameter is not valid or is incorrectly formatted.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The counter handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The data for the counter is locked (protected) for the duration of the call to <c>PdhGetRawCounterValue</c> to prevent any
	/// changes during processing of the call.
	/// </para>
	/// <para>
	/// If the specified counter instance does not exist, this function will return ERROR_SUCCESS and the <c>CStatus</c> member of the
	/// PDH_RAW_COUNTER structure will contain PDH_CSTATUS_NO_INSTANCE.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetrawcountervalue PDH_FUNCTION PdhGetRawCounterValue(
	// PDH_HCOUNTER hCounter, LPDWORD lpdwType, PPDH_RAW_COUNTER pValue );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "bb246c82-8748-4e2f-9f44-a206199aff90")]
	public static extern Win32Error PdhGetRawCounterValue(PDH_HCOUNTER hCounter, out CounterType lpdwType, out PDH_RAW_COUNTER pValue);

	/// <summary>Determines if the specified query is a real-time query.</summary>
	/// <param name="hQuery">Handle to the query. The PdhOpenQuery function returns this handle.</param>
	/// <returns>
	/// <para>If the query is a real-time query, the return value is <c>TRUE</c>.</para>
	/// <para>If the query is not a real-time query, the return value is <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// The term real-time as used in the description of this function does not imply the standard meaning of the term real-time.
	/// Instead, it describes the collection of performance data from a source providing current information (for example, the registry
	/// or a WMI provider) rather than from a log file.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhisrealtimequery BOOL PdhIsRealTimeQuery( PDH_HQUERY hQuery );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "4f6b2d8d-3a0f-4346-8b8e-a7aea11fbc40")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PdhIsRealTimeQuery(PDH_HQUERY hQuery);

	/// <summary>Returns the counter index corresponding to the specified counter name.</summary>
	/// <param name="szMachineName">
	/// <c>Null</c>-terminated string that specifies the name of the computer where the specified counter is located. The computer name
	/// can be specified by the DNS name or the IP address. If <c>NULL</c>, the function uses the local computer.
	/// </param>
	/// <param name="szNameBuffer"><c>Null</c>-terminated string that contains the counter name.</param>
	/// <param name="pdwIndex">Index of the counter.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following is a possible value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>A parameter is not valid or is incorrectly formatted.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhlookupperfindexbynamea PDH_FUNCTION PdhLookupPerfIndexByNameA(
	// LPCSTR szMachineName, LPCSTR szNameBuffer, LPDWORD pdwIndex );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "b8530bf3-0a9b-49c2-9494-4dca14cd57ef")]
	public static extern Win32Error PdhLookupPerfIndexByName([Optional] string? szMachineName, string szNameBuffer, out uint pdwIndex);

	/// <summary>Returns the performance object name or counter name corresponding to the specified index.</summary>
	/// <param name="szMachineName">
	/// <c>Null</c>-terminated string that specifies the name of the computer where the specified performance object or counter is
	/// located. The computer name can be specified by the DNS name or the IP address. If <c>NULL</c>, the function uses the local computer.
	/// </param>
	/// <param name="dwNameIndex">Index of the performance object or counter.</param>
	/// <param name="szNameBuffer">
	/// Caller-allocated buffer that receives the <c>null</c>-terminated name of the performance object or counter. Set to <c>NULL</c> if
	/// pcchNameBufferSize is zero.
	/// </param>
	/// <param name="pcchNameBufferSize">
	/// Size of the szNameBuffer buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this parameter
	/// to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the actual size
	/// of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you should not
	/// rely on the returned size to reallocate the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The szNameBuffer buffer is not large enough to contain the counter name. This return value is expected if pcchNameBufferSize is
	/// zero on input. If the specified size on input is greater than zero but less than the required size, you should not rely on the
	/// returned size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid or is incorrectly formatted. For example, on some releases you could receive this error if the specified
	/// size on input is greater than zero but less than the required size.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You should call this function twice, the first time to get the required buffer size (set szNameBuffer to <c>NULL</c> and
	/// pcchNameBufferSize to 0), and the second time to get the data.
	/// </para>
	/// <para>
	/// <c>Windows XP:</c> You must specify a buffer and buffer size. The function sets pcchNameBufferSize to either the required size or
	/// the size of the buffer that was used. If the buffer is too small, the function returns PDH_INSUFFICIENT_BUFFER instead of
	/// PDH_MORE_DATA. The maximum string size in bytes is PDH_MAX_COUNTER_NAME * sizeof(TCHAR).
	/// </para>
	/// <para>
	/// The index value that you specify must match one of the index values associated with the objects or counters that were loaded on
	/// the computer. The index/name value pairs are stored in the <c>Counters</c> registry value in the following registry location.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhlookupperfnamebyindexa PDH_FUNCTION PdhLookupPerfNameByIndexA(
	// LPCSTR szMachineName, DWORD dwNameIndex, LPSTR szNameBuffer, LPDWORD pcchNameBufferSize );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "6d5e1465-296b-4d8c-b0cb-aefdffb8539e")]
	public static extern Win32Error PdhLookupPerfNameByIndex([Optional] string? szMachineName, uint dwNameIndex, [Optional] StringBuilder szNameBuffer, ref uint pcchNameBufferSize);

	/// <summary>Creates a full counter path using the members specified in the PDH_COUNTER_PATH_ELEMENTS structure.</summary>
	/// <param name="pCounterPathElements">
	/// <para>
	/// A PDH_COUNTER_PATH_ELEMENTS structure that contains the members used to make up the path. Only the <c>szObjectName</c> and
	/// <c>szCounterName</c> members are required, the others are optional.
	/// </para>
	/// <para>
	/// If the instance name member is <c>NULL</c>, the path will not contain an instance reference and the <c>szParentInstance</c> and
	/// <c>dwInstanceIndex</c> members will be ignored.
	/// </para>
	/// </param>
	/// <param name="szFullPathBuffer">
	/// Caller-allocated buffer that receives a <c>null</c>-terminated counter path. The maximum length of a counter path is
	/// PDH_MAX_COUNTER_PATH. Set to <c>NULL</c> if pcchBufferSize is zero.
	/// </param>
	/// <param name="pcchBufferSize">
	/// Size of the szFullPathBuffer buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this
	/// parameter to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the
	/// actual size of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you
	/// should not rely on the returned size to reallocate the buffer.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Format of the input and output counter values. You can specify one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_PATH_WBEM_RESULT</term>
	/// <term>Converts a PDH path to the WMI class and property name format.</term>
	/// </item>
	/// <item>
	/// <term>PDH_PATH_WBEM_INPUT</term>
	/// <term>Converts the WMI class and property name to a PDH path.</term>
	/// </item>
	/// <item>
	/// <term>0</term>
	/// <term>Returns the path in the PDH format, for example, \\computer\object(parent/instance#index)\counter.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The szFullPathBuffer buffer is too small to contain the counter name. This return value is expected if pcchBufferSize is zero on
	/// input. If the specified size on input is greater than zero but less than the required size, you should not rely on the returned
	/// size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid or is incorrectly formatted. For example, on some releases you could receive this error if the specified
	/// size on input is greater than zero but less than the required size.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You should call this function twice, the first time to get the required buffer size (set szFullPathBuffer to <c>NULL</c> and
	/// pcchBufferSize to 0), and the second time to get the data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhmakecounterpatha PDH_FUNCTION PdhMakeCounterPathA(
	// PPDH_COUNTER_PATH_ELEMENTS_A pCounterPathElements, LPSTR szFullPathBuffer, LPDWORD pcchBufferSize, DWORD dwFlags );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "f2dc5f77-9f9e-4290-95fa-ce2f1e81fc69")]
	public static extern Win32Error PdhMakeCounterPath(in PDH_COUNTER_PATH_ELEMENTS pCounterPathElements, [Optional] StringBuilder szFullPathBuffer, ref uint pcchBufferSize, [Optional] PDH_PATH dwFlags);

	/// <summary>Creates a full counter path using the members specified in the PDH_COUNTER_PATH_ELEMENTS structure.</summary>
	/// <param name="pCounterPathElements">
	/// <para>
	/// A PDH_COUNTER_PATH_ELEMENTS structure that contains the members used to make up the path. Only the <c>szObjectName</c> and
	/// <c>szCounterName</c> members are required, the others are optional.
	/// </para>
	/// <para>
	/// If the instance name member is <c>NULL</c>, the path will not contain an instance reference and the <c>szParentInstance</c> and
	/// <c>dwInstanceIndex</c> members will be ignored.
	/// </para>
	/// </param>
	/// <param name="szFullPathBuffer">
	/// Caller-allocated buffer that receives a <c>null</c>-terminated counter path. The maximum length of a counter path is
	/// PDH_MAX_COUNTER_PATH. Set to <c>NULL</c> if pcchBufferSize is zero.
	/// </param>
	/// <param name="pcchBufferSize">
	/// Size of the szFullPathBuffer buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this
	/// parameter to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the
	/// actual size of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you
	/// should not rely on the returned size to reallocate the buffer.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Format of the input and output counter values. You can specify one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_PATH_WBEM_RESULT</term>
	/// <term>Converts a PDH path to the WMI class and property name format.</term>
	/// </item>
	/// <item>
	/// <term>PDH_PATH_WBEM_INPUT</term>
	/// <term>Converts the WMI class and property name to a PDH path.</term>
	/// </item>
	/// <item>
	/// <term>0</term>
	/// <term>Returns the path in the PDH format, for example, \\computer\object(parent/instance#index)\counter.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="langId">The language identifier to be used in creating the path.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The szFullPathBuffer buffer is too small to contain the counter name. This return value is expected if pcchBufferSize is zero on
	/// input. If the specified size on input is greater than zero but less than the required size, you should not rely on the returned
	/// size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid or is incorrectly formatted. For example, on some releases you could receive this error if the specified
	/// size on input is greater than zero but less than the required size.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You should call this function twice, the first time to get the required buffer size (set szFullPathBuffer to <c>NULL</c> and
	/// pcchBufferSize to 0), and the second time to get the data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhmakecounterpatha PDH_FUNCTION PdhMakeCounterPathA(
	// PPDH_COUNTER_PATH_ELEMENTS_A pCounterPathElements, LPSTR szFullPathBuffer, LPDWORD pcchBufferSize, DWORD dwFlags );
	[PInvokeData("pdh.h", MSDNShortId = "f2dc5f77-9f9e-4290-95fa-ce2f1e81fc69")]
	public static Win32Error PdhMakeCounterPath(in PDH_COUNTER_PATH_ELEMENTS pCounterPathElements, [Optional] StringBuilder szFullPathBuffer, ref uint pcchBufferSize, PDH_PATH dwFlags, ushort langId) =>
		PdhMakeCounterPath(pCounterPathElements, szFullPathBuffer, ref pcchBufferSize, PDH_PATH_LANG_FLAGS(langId, dwFlags));

	/// <summary>Opens the specified log file for reading or writing.</summary>
	/// <param name="szLogFileName">
	/// <para>
	/// <c>Null</c>-terminated string that specifies the name of the log file to open. The name can contain an absolute or relative path.
	/// </para>
	/// <para>
	/// If the lpdwLogType parameter is <c>PDH_LOG_TYPE_SQL</c>, specify the name of the log file in the form, <c>SQL:</c> DataSourceName
	/// <c>!</c> LogFileName.
	/// </para>
	/// </param>
	/// <param name="dwAccessFlags">
	/// <para>Type of access to use to open the log file. Specify one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_LOG_READ_ACCESS</term>
	/// <term>Open the log file for reading.</term>
	/// </item>
	/// <item>
	/// <term>PDH_LOG_WRITE_ACCESS</term>
	/// <term>Open a new log file for writing.</term>
	/// </item>
	/// <item>
	/// <term>PDH_LOG_UPDATE_ACCESS</term>
	/// <term>Open an existing log file for writing.</term>
	/// </item>
	/// </list>
	/// <para>
	/// You can use the bitwise inclusive <c>OR</c> operator (|) to combine the access type with one or more of the following creation flags.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_LOG_CREATE_NEW</term>
	/// <term>Creates a new log file with the specified name.</term>
	/// </item>
	/// <item>
	/// <term>PDH_LOG_CREATE_ALWAYS</term>
	/// <term>
	/// Creates a new log file with the specified name. If the log file already exists, the function removes the existing log file before
	/// creating the new file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_LOG_OPEN_EXISTING</term>
	/// <term>
	/// Opens an existing log file with the specified name. If a log file with the specified name does not exist, this is equal to PDH_LOG_CREATE_NEW.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_LOG_OPEN_ALWAYS</term>
	/// <term>Opens an existing log file with the specified name or creates a new log file with the specified name.</term>
	/// </item>
	/// <item>
	/// <term>PDH_LOG_OPT_CIRCULAR</term>
	/// <term>
	/// Creates a circular log file with the specified name. When the file reaches the value of the dwMaxSize parameter, data wraps to
	/// the beginning of the log file. You can specify this flag only if the lpdwLogType parameter is PDH_LOG_TYPE_BINARY.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_LOG_USER_STRING</term>
	/// <term>
	/// Used with PDH_LOG_TYPE_TSV to write the user caption or log file description indicated by the szUserString parameter of
	/// PdhUpdateLog or PdhOpenLog. The user caption or log file description is written as the last column in the first line of the text log.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpdwLogType">
	/// <para>Type of log file to open. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_LOG_TYPE_UNDEFINED</term>
	/// <term>
	/// Undefined log file format. If specified, PDH determines the log file type. You cannot specify this value if the dwAccessFlags
	/// parameter is PDH_LOG_WRITE_ACCESS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_LOG_TYPE_CSV</term>
	/// <term>
	/// Text file containing column headers in the first line, and individual data records in each subsequent line. The fields of each
	/// data record are comma-delimited. The first line also contains information about the format of the file, the PDH version used to
	/// create the log file, and the names and paths of each of the counters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_LOG_TYPE_SQL</term>
	/// <term>The data source of the log file is an SQL database.</term>
	/// </item>
	/// <item>
	/// <term>PDH_LOG_TYPE_TSV</term>
	/// <term>
	/// Text file containing column headers in the first line, and individual data records in each subsequent line. The fields of each
	/// data record are tab-delimited. The first line also contains information about the format of the file, the PDH version used to
	/// create the log file, and the names and paths of each of the counters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_LOG_TYPE_BINARY</term>
	/// <term>Binary log file format.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hQuery">
	/// <para>Specify a query handle if you are writing query data to a log file. The PdhOpenQuery function returns this handle.</para>
	/// <para>This parameter is ignored and should be <c>NULL</c> if you are reading from the log file.</para>
	/// </param>
	/// <param name="dwMaxSize">
	/// <para>
	/// Maximum size of the log file, in bytes. Specify the maximum size if you want to limit the file size or if dwAccessFlags specifies
	/// <c>PDH_LOG_OPT_CIRCULAR</c>; otherwise, set to 0.
	/// </para>
	/// <para>
	/// For circular log files, you must specify a value large enough to hold at least one sample. Sample size depends on data being
	/// collected. However, specifying a value of at least one megabyte will cover most samples.
	/// </para>
	/// </param>
	/// <param name="szUserCaption">
	/// <c>Null</c>-terminated string that specifies the user-defined caption of the log file. A log file caption generally describes the
	/// contents of the log file. When an existing log file is opened, the value of this parameter is ignored.
	/// </param>
	/// <param name="phLog">Handle to the opened log file.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To use this function to write performance data to a log file, you must open a query using PdhOpenQuery and add the desired
	/// counters to it, before calling this function.
	/// </para>
	/// <para>
	/// Newer operating systems can read log files that were generated on older operating systems; however, log files that were created
	/// on Windows Vista and later operating systems cannot be read on earlier operating systems.
	/// </para>
	/// <para>The following rules apply to log files</para>
	/// <list type="bullet">
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example, see Writing Performance Data to a Log File.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhopenloga PDH_FUNCTION PdhOpenLogA( LPCSTR szLogFileName, DWORD
	// dwAccessFlags, LPDWORD lpdwLogType, PDH_HQUERY hQuery, DWORD dwMaxSize, LPCSTR szUserCaption, PDH_HLOG *phLog );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "a8457959-af3a-497f-91ca-0876cbb552cc")]
	public static extern Win32Error PdhOpenLog(string szLogFileName, PdhLogAccess dwAccessFlags, ref PDH_LOG_TYPE lpdwLogType, [Optional] PDH_HQUERY hQuery, [Optional] uint dwMaxSize, [Optional] string? szUserCaption, out SafePDH_HLOG phLog);

	/// <summary>
	/// <para>Creates a new query that is used to manage the collection of performance data.</para>
	/// <para>To use handles to data sources, use the PdhOpenQueryH function.</para>
	/// </summary>
	/// <param name="szDataSource">
	/// <c>Null</c>-terminated string that specifies the name of the log file from which to retrieve performance data. If <c>NULL</c>,
	/// performance data is collected from a real-time data source.
	/// </param>
	/// <param name="dwUserData">
	/// User-defined value to associate with this query. To retrieve the user data later, call PdhGetCounterInfo and access the
	/// <c>dwQueryUserData</c> member of PDH_COUNTER_INFO.
	/// </param>
	/// <param name="phQuery">Handle to the query. You use this handle in subsequent calls.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhopenquerya PDH_FUNCTION PdhOpenQueryA( LPCSTR szDataSource,
	// DWORD_PTR dwUserData, PDH_HQUERY *phQuery );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "ec4e5353-c7f5-4957-b7f4-39df508846a0")]
	public static extern Win32Error PdhOpenQuery([Optional] string? szDataSource, [Optional] IntPtr dwUserData, out SafePDH_HQUERY phQuery);

	/// <summary>
	/// <para>Creates a new query that is used to manage the collection of performance data.</para>
	/// <para>This function is identical to the PdhOpenQuery function, except that it supports the use of handles to data sources.</para>
	/// </summary>
	/// <param name="hDataSource">Handle to a data source returned by the PdhBindInputDataSource function.</param>
	/// <param name="dwUserData">
	/// User-defined value to associate with this query. To retrieve the user data later, call the PdhGetCounterInfo function and access
	/// the <c>dwQueryUserData</c> member of PDH_COUNTER_INFO.
	/// </param>
	/// <param name="phQuery">Handle to the query. You use this handle in subsequent calls.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhopenqueryh PDH_FUNCTION PdhOpenQueryH( PDH_HLOG hDataSource,
	// DWORD_PTR dwUserData, PDH_HQUERY *phQuery );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "068c55da-d7e0-4111-91c8-a2bbd676f99d")]
	public static extern Win32Error PdhOpenQueryH([Optional] PDH_HLOG hDataSource, [Optional] IntPtr dwUserData, out SafePDH_HQUERY phQuery);

	/// <summary>Parses the elements of the counter path and stores the results in the PDH_COUNTER_PATH_ELEMENTS structure.</summary>
	/// <param name="szFullPathBuffer">
	/// <c>Null</c>-terminated string that contains the counter path to parse. The maximum length of a counter path is PDH_MAX_COUNTER_PATH.
	/// </param>
	/// <param name="pCounterPathElements">
	/// Caller-allocated buffer that receives a PDH_COUNTER_PATH_ELEMENTS structure. The structure contains pointers to the individual
	/// string elements of the path referenced by the szFullPathBuffer parameter. The function appends the strings to the end of the
	/// <c>PDH_COUNTER_PATH_ELEMENTS</c> structure. The allocated buffer should be large enough for the structure and the strings. Set to
	/// <c>NULL</c> if pdwBufferSize is zero.
	/// </param>
	/// <param name="pdwBufferSize">
	/// Size of the pCounterPathElements buffer, in bytes. If zero on input, the function returns PDH_MORE_DATA and sets this parameter
	/// to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the actual size
	/// of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you should not
	/// rely on the returned size to reallocate the buffer.
	/// </param>
	/// <param name="dwFlags">Reserved. Must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>A parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The pCounterPathElements buffer is too small to contain the path elements. This return value is expected if pdwBufferSize is zero
	/// on input. If the specified size on input is greater than zero but less than the required size, you should not rely on the
	/// returned size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_PATH</term>
	/// <term>
	/// The path is not formatted correctly and cannot be parsed. For example, on some releases you could receive this error if the
	/// specified size on input is greater than zero but less than the required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>Unable to allocate memory in order to complete the function.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You should call this function twice, the first time to get the required buffer size (set pCounterPathElements to <c>NULL</c> and
	/// pdwBufferSize to 0), and the second time to get the data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhparsecounterpatha PDH_FUNCTION PdhParseCounterPathA( LPCSTR
	// szFullPathBuffer, PPDH_COUNTER_PATH_ELEMENTS_A pCounterPathElements, LPDWORD pdwBufferSize, DWORD dwFlags );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "760b94e9-88df-4f7d-92e9-333d682779f6")]
	public static extern Win32Error PdhParseCounterPath(string szFullPathBuffer, [Optional] IntPtr pCounterPathElements, ref uint pdwBufferSize, uint dwFlags = 0);

	/// <summary>Parses the elements of an instance string.</summary>
	/// <param name="szInstanceString">
	/// <para>
	/// <c>Null</c>-terminated string that specifies the instance string to parse into individual components. This string can contain the
	/// following formats, and is less than MAX_PATH characters in length:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>instance</term>
	/// </item>
	/// <item>
	/// <term>instance#index</term>
	/// </item>
	/// <item>
	/// <term>parent/instance</term>
	/// </item>
	/// <item>
	/// <term>parent/instance#index</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szInstanceName">
	/// Caller-allocated buffer that receives the <c>null</c>-terminated instance name. Set to <c>NULL</c> if pcchInstanceNameLength is zero.
	/// </param>
	/// <param name="pcchInstanceNameLength">
	/// Size of the szInstanceName buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this parameter
	/// to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the actual size
	/// of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you should not
	/// rely on the returned size to reallocate the buffer.
	/// </param>
	/// <param name="szParentName">
	/// Caller-allocated buffer that receives the <c>null</c>-terminated name of the parent instance, if one is specified. Set to
	/// <c>NULL</c> if pcchParentNameLength is zero.
	/// </param>
	/// <param name="pcchParentNameLength">
	/// Size of the szParentName buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this parameter
	/// to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the actual size
	/// of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you should not
	/// rely on the returned size to reallocate the buffer.
	/// </param>
	/// <param name="lpIndex">
	/// Index value of the instance. If an index entry is not present in the string, then this value is zero. This parameter can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid. For example, on some releases you could receive this error if the specified size on input is greater
	/// than zero but less than the required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// One or both of the string buffers are too small to contain the data. This return value is expected if the corresponding size
	/// buffer is zero on input. If the specified size on input is greater than zero but less than the required size, you should not rely
	/// on the returned size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_INSTANCE</term>
	/// <term>The instance string is incorrectly formatted, exceeds MAX_PATH characters in length, or cannot be parsed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You should call this function twice, the first time to get the required buffer size (set the buffers to <c>NULL</c> and buffer
	/// sizes to 0), and the second time to get the data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhparseinstancenamea PDH_FUNCTION PdhParseInstanceNameA( LPCSTR
	// szInstanceString, LPSTR szInstanceName, LPDWORD pcchInstanceNameLength, LPSTR szParentName, LPDWORD pcchParentNameLength, LPDWORD
	// lpIndex );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "8304ecee-5141-450a-be11-838b9f52413b")]
	public static extern Win32Error PdhParseInstanceName(string szInstanceString, [Optional] StringBuilder szInstanceName, ref uint pcchInstanceNameLength, [Optional] StringBuilder szParentName, ref uint pcchParentNameLength, out uint lpIndex);

	/// <summary>Reads the information in the specified binary trace log file.</summary>
	/// <param name="hLog">Handle to the log file. The PdhOpenLog or PdhBindInputDataSource function returns this handle.</param>
	/// <param name="ftRecord">
	/// Time stamp of the record to be read. If the time stamp does not match a record in the log file, the function returns the record
	/// that has a time stamp closest to (but not greater than) the given time stamp.
	/// </param>
	/// <param name="pRawLogRecord">
	/// Caller-allocated buffer that receives a <see cref="PDH_RAW_LOG_RECORD"/> structure; the structure contains the log file record
	/// information. Set to <c>NULL</c> if pdwBufferLength is zero.
	/// </param>
	/// <param name="pdwBufferLength">
	/// Size of the pRawLogRecord buffer, in <c>TCHARs</c>. If zero on input, the function returns PDH_MORE_DATA and sets this parameter
	/// to the required buffer size. If the buffer is larger than the required size, the function sets this parameter to the actual size
	/// of the buffer that was used. If the specified size on input is greater than zero but less than the required size, you should not
	/// rely on the returned size to reallocate the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>
	/// A parameter is not valid. For example, on some releases you could receive this error if the specified size on input is greater
	/// than zero but less than the required size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_MORE_DATA</term>
	/// <term>
	/// The pRawLogRecord buffer is too small to contain the path elements. This return value is expected if pdwBufferLength is zero on
	/// input. If the specified size on input is greater than zero but less than the required size, you should not rely on the returned
	/// size to reallocate the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>Unable to allocate memory in order to complete the function.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You should call this function twice, the first time to get the required buffer size (set pRawLogRecord to <c>NULL</c> and
	/// pdwBufferLength to 0), and the second time to get the data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhreadrawlogrecord PDH_FUNCTION PdhReadRawLogRecord( PDH_HLOG hLog,
	// FILETIME ftRecord, PPDH_RAW_LOG_RECORD pRawLogRecord, LPDWORD pdwBufferLength );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "fb93b6ea-ca31-4ff1-a553-b02388be8b72")]
	public static extern Win32Error PdhReadRawLogRecord(PDH_HLOG hLog, FILETIME ftRecord, [Optional] IntPtr pRawLogRecord, ref uint pdwBufferLength);

	/// <summary>Removes a counter from a query.</summary>
	/// <param name="hCounter">Handle of the counter to remove from its query. The PdhAddCounter function returns this handle.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code.</para>
	/// <para>The following is a possible value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The counter handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Do not use the counter handle after removing the counter from the query.</para>
	/// <para>The following shows the syntax if calling this function from Visual Basic.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhremovecounter PDH_FUNCTION PdhRemoveCounter( PDH_HCOUNTER
	// hCounter );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "adf9c7bd-47d6-489a-88fc-954fdf127ce8")]
	public static extern Win32Error PdhRemoveCounter(PDH_HCOUNTER hCounter);

	/// <summary>Displays a dialog window that prompts the user to specify the source of the performance data.</summary>
	/// <param name="hWndOwner">Owner of the dialog window. This can be <c>NULL</c> if there is no owner (the desktop becomes the owner).</param>
	/// <param name="dwFlags">
	/// <para>Dialog boxes that will be displayed to prompt for the data source. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_FLAGS_FILE_BROWSER_ONLY</term>
	/// <term>Display the file browser only. Set this flag when you want to prompt for the name and location of a log file only.</term>
	/// </item>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// Display the data source selection dialog box. The dialog box lets the user select performance data from either a log file or a
	/// real-time source. If the user specified that data is to be collected from a log file, a file browser is displayed for the user to
	/// specify the name and location of the log file.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szDataSource">
	/// <para>
	/// Caller-allocated buffer that receives a <c>null</c>-terminated string that contains the name of a log file that the user
	/// selected. The log file name is truncated to the size of the buffer if the buffer is too small.
	/// </para>
	/// <para>If the user selected a real time source, the buffer is empty.</para>
	/// </param>
	/// <param name="pcchBufferLength">Maximum size of the szDataSource buffer, in <c>TCHARs</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>The length of the buffer passed in the pcchBufferLength is not equal to the actual length of the szDataSource buffer.</term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>A zero-length buffer was passed in the szDataSource parameter.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhselectdatasourcea PDH_FUNCTION PdhSelectDataSourceA( HWND
	// hWndOwner, DWORD dwFlags, LPSTR szDataSource, LPDWORD pcchBufferLength );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "211d4504-e1f9-48a0-8ddd-613f2f183c59")]
	public static extern Win32Error PdhSelectDataSource([Optional] HWND hWndOwner, PdhSelectDataSourceFlags dwFlags, StringBuilder szDataSource, ref uint pcchBufferLength);

	/// <summary>
	/// Sets the scale factor that is applied to the calculated value of the specified counter when you request the formatted counter
	/// value. If the PDH_FMT_NOSCALE flag is set, then this scale factor is ignored.
	/// </summary>
	/// <param name="hCounter">Handle of the counter to apply the scale factor to. The PdhAddCounter function returns this handle.</param>
	/// <param name="lFactor">
	/// Power of ten by which to multiply the calculated value before returning it. The minimum value of this parameter is PDH_MIN_SCALE
	/// (–7), where the returned value is the actual value multiplied by 10⁷. The maximum value of this parameter is PDH_MAX_SCALE (+7),
	/// where the returned value is the actual value multiplied by 10⁺⁷. A value of zero will set the scale to one, so that the actual
	/// value is returned.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>The scale value is out of range.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The counter handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhsetcounterscalefactor PDH_FUNCTION PdhSetCounterScaleFactor(
	// PDH_HCOUNTER hCounter, LONG lFactor );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "6db99e03-0b03-4c1c-b82a-2982b52746db")]
	public static extern Win32Error PdhSetCounterScaleFactor(PDH_HCOUNTER hCounter, int lFactor);

	/// <summary>Specifies the source of the real-time data.</summary>
	/// <param name="dwDataSourceId">
	/// <para>Source of the performance data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DATA_SOURCE_REGISTRY</term>
	/// <term>The data source is the registry interface. This is the default.</term>
	/// </item>
	/// <item>
	/// <term>DATA_SOURCE_WBEM</term>
	/// <term>The data source is a WMI provider.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following is a possible value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>The parameter is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The term real-time as used in the description of this function does not imply the standard meaning of the term real-time.
	/// Instead, it describes the collection of performance data from a source providing current information (for example, the registry
	/// or a WMI provider) rather than from a log file.
	/// </para>
	/// <para>
	/// If you want to query real-time data from WMI, you must call <c>PdhSetDefaultRealTimeDataSource</c> to set the default real-time
	/// data source. You must call this function before calling any other PDH API function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhsetdefaultrealtimedatasource PDH_FUNCTION
	// PdhSetDefaultRealTimeDataSource( DWORD dwDataSourceId );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "5a46ac26-c1a1-40c1-a328-688e0b394e18")]
	public static extern Win32Error PdhSetDefaultRealTimeDataSource(uint dwDataSourceId);

	/// <summary>Limits the samples that you can read from a log file to those within the specified time range, inclusively.</summary>
	/// <param name="hQuery">Handle to the query. The PdhOpenQuery function returns this handle.</param>
	/// <param name="pInfo">
	/// A PDH_TIME_INFO structure that specifies the time range. Specify the time as local file time. The end time must be greater than
	/// the start time. You can specify 0 for the start time and the maximum 64-bit value for the end time if you want to read all records.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The query handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>The ending time range value must be greater than the starting time range value.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// When the end of the specified time range or the end of the log file is reached, the PdhCollectQueryData function will return PDH_NO_MORE_DATA.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhsetquerytimerange PDH_FUNCTION PdhSetQueryTimeRange( PDH_HQUERY
	// hQuery, PPDH_TIME_INFO pInfo );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "ed0e100e-9f82-48c0-b4bb-72820c5eeaa8")]
	public static extern Win32Error PdhSetQueryTimeRange(PDH_HQUERY hQuery, in PDH_TIME_INFO pInfo);

	/// <summary>Collects counter data for the current query and writes the data to the log file.</summary>
	/// <param name="hLog">Handle of a single log file to update. The PdhOpenLog function returns this handle.</param>
	/// <param name="szUserString">
	/// Null-terminated string that contains a user-defined comment to add to the data record. The string can not be empty.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The log file handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_ARGUMENT</term>
	/// <term>An empty string was passed in the szUserString parameter.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If you are updating a log file from another log file, the comments from the other log file do not migrate.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Writing Performance Data to a Log File.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhupdateloga PDH_FUNCTION PdhUpdateLogA( PDH_HLOG hLog, LPCSTR
	// szUserString );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "b2052275-6944-41f4-92ac-38967ed270f3")]
	public static extern Win32Error PdhUpdateLog(PDH_HLOG hLog, string szUserString);

	/// <summary>
	/// <para>Synchronizes the information in the log file catalog with the performance data in the log file.</para>
	/// <para><c>Note</c> This function is obsolete.</para>
	/// </summary>
	/// <param name="hLog">Handle to the log file containing the file catalog to update. The PdhOpenLog function.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_NOT_IMPLEMENTED</term>
	/// <term>A handle to a CSV or TSV log file was specified. These log file types do not have catalogs.</term>
	/// </item>
	/// <item>
	/// <term>PDH_UNKNOWN_LOG_FORMAT</term>
	/// <term>A handle to a log file with an unknown format was specified.</term>
	/// </item>
	/// <item>
	/// <term>PDH_INVALID_HANDLE</term>
	/// <term>The handle is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The log file catalog serves as an index to the performance data records in the log file, providing for faster searches for
	/// individual records in the file.
	/// </para>
	/// <para>
	/// Catalogs should be updated when the data collection process is complete and the log file has been closed. The catalog can be
	/// updated during data collection, but doing this may disrupt the process of logging the performance data because updating the
	/// catalogs can be time consuming.
	/// </para>
	/// <para>
	/// Perfmon, CSV, and TSV log files do not have catalogs. Specifying a handle to these log file types will result in a return value
	/// of PDH_NOT_IMPLEMENTED.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhupdatelogfilecatalog PDH_FUNCTION PdhUpdateLogFileCatalog(
	// PDH_HLOG hLog );
	[DllImport(Lib.Pdh, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("pdh.h", MSDNShortId = "e8aa8462-48f1-4ccd-8c41-a7358975e056")]
	public static extern Win32Error PdhUpdateLogFileCatalog(PDH_HLOG hLog);

	/// <summary>Validates that the counter is present on the computer specified in the counter path.</summary>
	/// <param name="szFullPathBuffer">
	/// Null-terminated string that contains the counter path to validate. The maximum length of a counter path is PDH_MAX_COUNTER_PATH.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_CSTATUS_NO_INSTANCE</term>
	/// <term>The specified instance of the performance object was not found.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_COUNTER</term>
	/// <term>The specified counter was not found in the performance object.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_OBJECT</term>
	/// <term>The specified performance object was not found on the computer.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_MACHINE</term>
	/// <term>The specified computer could not be found or connected to.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_BAD_COUNTERNAME</term>
	/// <term>The counter path string could not be parsed.</term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>The function is unable to allocate a required temporary buffer.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhvalidatepatha PDH_FUNCTION PdhValidatePathA( LPCSTR
	// szFullPathBuffer );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "9248e63c-2672-466f-85f5-46f26e31dc75")]
	public static extern Win32Error PdhValidatePath(string szFullPathBuffer);

	/// <summary>Validates that the specified counter is present on the computer or in the log file.</summary>
	/// <param name="hDataSource">
	/// <para>Handle to the data source. The PdhOpenLog and PdhBindInputDataSource functions return this handle.</para>
	/// <para>To validate that the counter is present on the local computer, specify <c>NULL</c> (this is the same as calling PdhValidatePath).</para>
	/// </param>
	/// <param name="szFullPathBuffer">
	/// <c>Null</c>-terminated string that specifies the counter path to validate. The maximum length of a counter path is PDH_MAX_COUNTER_PATH.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code or a PDH error code. The following are possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>PDH_CSTATUS_NO_INSTANCE</term>
	/// <term>The specified instance of the performance object was not found.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_COUNTER</term>
	/// <term>The specified counter was not found in the performance object.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_OBJECT</term>
	/// <term>The specified performance object was not found on the computer or in the log file.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_NO_MACHINE</term>
	/// <term>The specified computer could not be found or connected to.</term>
	/// </item>
	/// <item>
	/// <term>PDH_CSTATUS_BAD_COUNTERNAME</term>
	/// <term>The counter path string could not be parsed.</term>
	/// </item>
	/// <item>
	/// <term>PDH_MEMORY_ALLOCATION_FAILURE</term>
	/// <term>The function is unable to allocate a required temporary buffer.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhvalidatepathexw PDH_FUNCTION PdhValidatePathExW( PDH_HLOG
	// hDataSource, LPCWSTR szFullPathBuffer );
	[DllImport(Lib.Pdh, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("pdh.h", MSDNShortId = "e6b52af7-7276-4565-aa61-73899796a13c")]
	public static extern Win32Error PdhValidatePathExW(PDH_HLOG hDataSource, string szFullPathBuffer);

	private static PDH_PATH PDH_PATH_LANG_FLAGS(ushort LangId, PDH_PATH Flags) => (PDH_PATH)(((LangId & 0x0000FFFF) << 16) | ((int)Flags & 0x0000FFFF));

	/// <summary>
	/// The <c>PDH_BROWSE_DLG_CONFIG</c> structure is used by the PdhBrowseCounters function to configure the <c>Browse Performance
	/// Counters</c> dialog box.
	/// </summary>
	/// <remarks>
	/// Each time the Add button is clicked, the <c>szReturnPathBuffer</c> buffer contains the selected counter and the <c>pCallBack</c>
	/// callback function is called. The callback function should call the PdhAddCounter function for each counter in the buffer.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/ns-pdh-pdh_browse_dlg_config_a typedef struct _BrowseDlgConfig_A { DWORD
	// bIncludeInstanceIndex : 1; DWORD bSingleCounterPerAdd : 1; DWORD bSingleCounterPerDialog : 1; DWORD bLocalCountersOnly : 1; DWORD
	// bWildCardInstances : 1; DWORD bHideDetailBox : 1; DWORD bInitializePath : 1; DWORD bDisableMachineSelection : 1; DWORD
	// bIncludeCostlyObjects : 1; DWORD bShowObjectBrowser : 1; DWORD bReserved : 22; HWND hWndOwner; LPSTR szDataSource; LPSTR
	// szReturnPathBuffer; DWORD cchReturnPathLength; CounterPathCallBack pCallBack; DWORD_PTR dwCallBackArg; PDH_STATUS CallBackStatus;
	// DWORD dwDefaultDetailLevel; LPSTR szDialogBoxCaption; } PDH_BROWSE_DLG_CONFIG_A, *PPDH_BROWSE_DLG_CONFIG_A;
	[PInvokeData("pdh.h", MSDNShortId = "8e045e0b-c157-4527-902c-6096c7922642")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PDH_BROWSE_DLG_CONFIG
	{
		/// <summary/>
		public BrowseFlag Flags;

		/// <summary>Handle of the window to own the dialog. If <c>NULL</c>, the owner is the desktop.</summary>
		public HWND hWndOwner;

		/// <summary>
		/// Pointer to a <c>null</c>-terminated string that specifies the name of the log file from which the list of counters is
		/// retrieved. If <c>NULL</c>, the list of counters is retrieved from the local computer (or remote computer if specified).
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string szDataSource;

		/// <summary>
		/// <para>Pointer to a MULTI_SZ that contains the selected counter paths.</para>
		/// <para>
		/// If <c>bInitializePath</c> is <c>TRUE</c>, you can use this member to specify a counter path whose components are used to
		/// highlight entries in computer, object, counter, and instance lists when the dialog is first displayed.
		/// </para>
		/// </summary>
		public IntPtr szReturnPathBuffer;

		/// <summary>
		/// Size of the <c>szReturnPathBuffer</c> buffer, in <c>TCHARs</c>. If the callback function reallocates a new buffer, it must
		/// also update this value.
		/// </summary>
		public uint cchReturnPathLength;

		/// <summary>Pointer to the callback function that processes the user's selection. For more information, see CounterPathCallBack.</summary>
		public CounterPathCallBack pCallBack;

		/// <summary>Caller-defined value that is passed to the callback function.</summary>
		public IntPtr dwCallBackArg;

		/// <summary>
		/// <para>
		/// On entry to the callback function, this member contains the status of the path buffer. On exit, the callback function sets
		/// the status value resulting from processing.
		/// </para>
		/// <para>
		/// If the buffer is too small to load the current selection, the dialog sets this value to PDH_MORE_DATA. If this value is
		/// ERROR_SUCCESS, then the <c>szReturnPathBuffer</c> member contains a valid counter path or counter path list.
		/// </para>
		/// <para>
		/// If the callback function reallocates a new buffer, it should set this member to PDH_RETRY so that the dialog will try to load
		/// the buffer with the selected paths and call the callback function again.
		/// </para>
		/// <para>If some other error occurred, then the callback function should return the appropriate PDH error status value.</para>
		/// </summary>
		public Win32Error CallBackStatus;

		/// <summary>
		/// <para>
		/// Default detail level to show in the <c>Detail level</c> list if <c>bHideDetailBox</c> is <c>FALSE</c>. If
		/// <c>bHideDetailBox</c> is <c>TRUE</c>, the dialog uses this value to filter the displayed performance counters and objects.
		/// You can specify one of the following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Detail level</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PERF_DETAIL_NOVICE</term>
		/// <term>A novice user can understand the counter data.</term>
		/// </item>
		/// <item>
		/// <term>PERF_DETAIL_ADVANCED</term>
		/// <term>The counter data is provided for advanced users.</term>
		/// </item>
		/// <item>
		/// <term>PERF_DETAIL_EXPERT</term>
		/// <term>The counter data is provided for expert users.</term>
		/// </item>
		/// <item>
		/// <term>PERF_DETAIL_WIZARD</term>
		/// <term>The counter data is provided for system designers.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PERF_DETAIL dwDefaultDetailLevel;

		/// <summary>
		/// Pointer to a <c>null</c>-terminated string that specifies the optional caption to display in the caption bar of the dialog
		/// box. If this member is <c>NULL</c>, the caption will be <c>Browse Performance Counters</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string szDialogBoxCaption;

		/// <summary>On return, gets the selected counter paths.</summary>
		public string[] CounterPaths => szReturnPathBuffer.ToStringEnum(CharSet.Auto, 0, cchReturnPathLength).ToArray();
	}

	/// <summary>
	/// The <c>PDH_BROWSE_DLG_CONFIG_H</c> structure is used by the PdhBrowseCountersH function to configure the <c>Browse Performance
	/// Counters</c> dialog box.
	/// </summary>
	/// <remarks>
	/// Each time the Add button is clicked, the <c>szReturnPathBuffer</c> buffer contains the selected counter and the <c>pCallBack</c>
	/// callback function is called. The callback function should call the PdhAddCounter function for each counter in the buffer.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/ns-pdh-pdh_browse_dlg_config_ha typedef struct _BrowseDlgConfig_HA { DWORD
	// bIncludeInstanceIndex : 1; DWORD bSingleCounterPerAdd : 1; DWORD bSingleCounterPerDialog : 1; DWORD bLocalCountersOnly : 1; DWORD
	// bWildCardInstances : 1; DWORD bHideDetailBox : 1; DWORD bInitializePath : 1; DWORD bDisableMachineSelection : 1; DWORD
	// bIncludeCostlyObjects : 1; DWORD bShowObjectBrowser : 1; DWORD bReserved : 22; HWND hWndOwner; PDH_HLOG hDataSource; LPSTR
	// szReturnPathBuffer; DWORD cchReturnPathLength; CounterPathCallBack pCallBack; DWORD_PTR dwCallBackArg; PDH_STATUS CallBackStatus;
	// DWORD dwDefaultDetailLevel; LPSTR szDialogBoxCaption; } PDH_BROWSE_DLG_CONFIG_HA, *PPDH_BROWSE_DLG_CONFIG_HA;
	[PInvokeData("pdh.h", MSDNShortId = "db30ff94-3238-45a0-a78e-8b3cd00ec79c")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PDH_BROWSE_DLG_CONFIG_H
	{
		/// <summary/>
		public BrowseFlag Flags;

		/// <summary>Handle of the window to own the dialog. If <c>NULL</c>, the owner is the desktop.</summary>
		public HWND hWndOwner;

		/// <summary>Handle to a data source returned by the PdhBindInputDataSource function.</summary>
		public PDH_HLOG hDataSource;

		/// <summary>
		/// <para>Pointer to a MULTI_SZ that contains the selected counter paths.</para>
		/// <para>
		/// If <c>bInitializePath</c> is <c>TRUE</c>, you can use this member to specify a counter path whose components are used to
		/// highlight entries in computer, object, counter, and instance lists when the dialog is first displayed.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string szReturnPathBuffer;

		/// <summary>
		/// Size of the <c>szReturnPathBuffer</c> buffer, in <c>TCHARs</c>. If the callback function reallocates a new buffer, it must
		/// also update this value.
		/// </summary>
		public uint cchReturnPathLength;

		/// <summary>Pointer to the callback function that processes the user's selection. For more information, see CounterPathCallBack.</summary>
		public CounterPathCallBack pCallBack;

		/// <summary>Caller-defined value that is passed to the callback function.</summary>
		public IntPtr dwCallBackArg;

		/// <summary>
		/// <para>
		/// On entry to the callback function, this member contains the status of the path buffer. On exit, the callback function sets
		/// the status value resulting from processing.
		/// </para>
		/// <para>
		/// If the buffer is too small to load the current selection, the dialog sets this value to PDH_MORE_DATA. If this value is
		/// ERROR_SUCCESS, then the <c>szReturnPathBuffer</c> member contains a valid counter path or counter path list.
		/// </para>
		/// <para>
		/// If the callback function reallocates a new buffer, it should set this member to PDH_RETRY so that the dialog will try to load
		/// the buffer with the selected paths and call the callback function again.
		/// </para>
		/// <para>If some other error occurred, then the callback function should return the appropriate PDH error status value.</para>
		/// </summary>
		public Win32Error CallBackStatus;

		/// <summary>
		/// <para>
		/// Default detail level to show in the <c>Detail level</c> list if <c>bHideDetailBox</c> is <c>FALSE</c>. If
		/// <c>bHideDetailBox</c> is <c>TRUE</c>, the dialog uses this value to filter the displayed performance counters and objects.
		/// You can specify one of the following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Detail level</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PERF_DETAIL_NOVICE</term>
		/// <term>A novice user can understand the counter data.</term>
		/// </item>
		/// <item>
		/// <term>PERF_DETAIL_ADVANCED</term>
		/// <term>The counter data is provided for advanced users.</term>
		/// </item>
		/// <item>
		/// <term>PERF_DETAIL_EXPERT</term>
		/// <term>The counter data is provided for expert users.</term>
		/// </item>
		/// <item>
		/// <term>PERF_DETAIL_WIZARD</term>
		/// <term>The counter data is provided for system designers.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PERF_DETAIL dwDefaultDetailLevel;

		/// <summary>
		/// Pointer to a <c>null</c>-terminated string that specifies the optional caption to display in the caption bar of the dialog
		/// box. If this member is <c>NULL</c>, the caption will be <c>Browse Performance Counters</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string szDialogBoxCaption;
	}

	/// <summary>
	/// The <c>PDH_COUNTER_INFO</c> structure contains information describing the properties of a counter. This information also includes
	/// the counter path.
	/// </summary>
	/// <remarks>
	/// When you allocate memory for this structure, allocate enough memory for the member strings, such as <c>szCounterName</c>, that
	/// are appended to the end of this structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/ns-pdh-pdh_counter_info_a typedef struct _PDH_COUNTER_INFO_A { DWORD
	// dwLength; DWORD dwType; DWORD CVersion; DWORD CStatus; LONG lScale; LONG lDefaultScale; DWORD_PTR dwUserData; DWORD_PTR
	// dwQueryUserData; LPSTR szFullPath; union { PDH_DATA_ITEM_PATH_ELEMENTS_A DataItemPath; PDH_COUNTER_PATH_ELEMENTS_A CounterPath;
	// struct { LPSTR szMachineName; LPSTR szObjectName; LPSTR szInstanceName; LPSTR szParentInstance; DWORD dwInstanceIndex; LPSTR
	// szCounterName; }; }; LPSTR szExplainText; DWORD DataBuffer[1]; } PDH_COUNTER_INFO_A, *PPDH_COUNTER_INFO_A;
	[PInvokeData("pdh.h", MSDNShortId = "c9ede50e-85de-4a68-b539-54285c2599cb")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PDH_COUNTER_INFO
	{
		/// <summary>Size of the structure, including the appended strings, in bytes.</summary>
		public uint dwLength;

		/// <summary>
		/// Counter type. For a list of counter types, see the Counter Types section of the Windows Server 2003 Deployment Kit. The
		/// counter type constants are defined in Winperf.h.
		/// </summary>
		public CounterType dwType;

		/// <summary>Counter version information. Not used.</summary>
		public uint CVersion;

		/// <summary>
		/// Counter status that indicates if the counter value is valid. For a list of possible values, see Checking PDH Interface Return Values.
		/// </summary>
		public uint CStatus;

		/// <summary>
		/// Scale factor to use when computing the displayable value of the counter. The scale factor is a power of ten. The valid range
		/// of this parameter is PDH_MIN_SCALE (–7) (the returned value is the actual value times 10⁷) to PDH_MAX_SCALE (+7) (the
		/// returned value is the actual value times 10⁺⁷). A value of zero will set the scale to one, so that the actual value is returned
		/// </summary>
		public long lScale;

		/// <summary>Default scale factor as suggested by the counter's provider.</summary>
		public long lDefaultScale;

		/// <summary>The value passed in the dwUserData parameter when calling PdhAddCounter.</summary>
		public IntPtr dwUserData;

		/// <summary>The value passed in the dwUserData parameter when calling PdhOpenQuery.</summary>
		public IntPtr dwQueryUserData;

		/// <summary><c>Null</c>-terminated string that specifies the full counter path. The string follows this structure in memory.</summary>
		public StrPtrAuto szFullPath;

		/// <summary>
		/// <c>Null</c>-terminated string that contains the name of the computer specified in the counter path. Is <c>NULL</c>, if the
		/// path does not specify a computer. The string follows this structure in memory.
		/// </summary>
		public StrPtrAuto szMachineName;

		/// <summary>
		/// <c>Null</c>-terminated string that contains the name of the performance object specified in the counter path. The string
		/// follows this structure in memory.
		/// </summary>
		public StrPtrAuto szObjectName;

		/// <summary>
		/// <c>Null</c>-terminated string that contains the name of the object instance specified in the counter path. Is <c>NULL</c>, if
		/// the path does not specify an instance. The string follows this structure in memory.
		/// </summary>
		public StrPtrAuto szInstanceName;

		/// <summary>
		/// <c>Null</c>-terminated string that contains the name of the parent instance specified in the counter path. Is <c>NULL</c>, if
		/// the path does not specify a parent instance. The string follows this structure in memory.
		/// </summary>
		public StrPtrAuto szParentInstance;

		/// <summary>Instance index specified in the counter path. Is 0, if the path does not specify an instance index.</summary>
		public uint dwInstanceIndex;

		/// <summary><c>Null</c>-terminated string that contains the counter name. The string follows this structure in memory.</summary>
		public StrPtrAuto szCounterName;

		/// <summary>Help text that describes the counter. Is <c>NULL</c> if the source is a log file.</summary>
		public StrPtrAuto szExplainText;

		/// <summary>Start of the string data that is appended to the structure.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public uint[] DataBuffer;
	}

	/// <summary>The <c>PDH_COUNTER_PATH_ELEMENTS</c> structure contains the components of a counter path.</summary>
	/// <remarks>
	/// <para>This structure is used by PdhMakeCounterPath to create a counter path and by PdhParseCounterPath to parse a counter path.</para>
	/// <para>
	/// When you allocate memory for this structure, allocate enough memory for the member strings, such as <c>szCounterName</c>, that
	/// are appended to the end of this structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/ns-pdh-pdh_counter_path_elements_a typedef struct
	// _PDH_COUNTER_PATH_ELEMENTS_A { LPSTR szMachineName; LPSTR szObjectName; LPSTR szInstanceName; LPSTR szParentInstance; DWORD
	// dwInstanceIndex; LPSTR szCounterName; } PDH_COUNTER_PATH_ELEMENTS_A, *PPDH_COUNTER_PATH_ELEMENTS_A;
	[PInvokeData("pdh.h", MSDNShortId = "ffa2a076-7267-406b-8eed-4a49504a7ad6")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PDH_COUNTER_PATH_ELEMENTS
	{
		/// <summary>Pointer to a null-terminated string that specifies the computer name.</summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string szMachineName;

		/// <summary>Pointer to a null-terminated string that specifies the object name.</summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string szObjectName;

		/// <summary>Pointer to a null-terminated string that specifies the instance name. Can contain a wildcard character.</summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string szInstanceName;

		/// <summary>Pointer to a null-terminated string that specifies the parent instance name. Can contain a wildcard character.</summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string szParentInstance;

		/// <summary>Index used to uniquely identify duplicate instance names.</summary>
		public uint dwInstanceIndex;

		/// <summary>Pointer to a null-terminated string that specifies the counter name.</summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string szCounterName;
	}

	/// <summary>The <c>PDH_DATA_ITEM_PATH_ELEMENTS</c> structure contains the path elements of a specific data item.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/ns-pdh-pdh_data_item_path_elements_a typedef struct
	// _PDH_DATA_ITEM_PATH_ELEMENTS_A { LPSTR szMachineName; GUID ObjectGUID; DWORD dwItemId; LPSTR szInstanceName; }
	// PDH_DATA_ITEM_PATH_ELEMENTS_A, *PPDH_DATA_ITEM_PATH_ELEMENTS_A;
	[PInvokeData("pdh.h", MSDNShortId = "7d80d9ac-0123-4743-93a2-fa9d609d81b2")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PDH_DATA_ITEM_PATH_ELEMENTS
	{
		/// <summary>Pointer to a null-terminated string that specifies the name of the computer where the data item resides.</summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string szMachineName;

		/// <summary>GUID of the object where the data item resides.</summary>
		public Guid ObjectGUID;

		/// <summary>Identifier of the data item.</summary>
		public uint dwItemId;

		/// <summary>Pointer to a null-terminated string that specifies the name of the data item instance.</summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string szInstanceName;
	}

	/// <summary>The <c>PDH_FMT_COUNTERVALUE</c> structure contains the computed value of the counter and its status.</summary>
	/// <remarks>
	/// You specify the data type of the computed counter value when you call PdhGetFormattedCounterValue or
	/// PdhCalculateCounterFromRawValue to compute the counter's value.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/ns-pdh-pdh_fmt_countervalue typedef struct _PDH_FMT_COUNTERVALUE { DWORD
	// CStatus; union { LONG longValue; double doubleValue; LONGLONG largeValue; LPCSTR AnsiStringValue; LPCWSTR WideStringValue; }; }
	// PDH_FMT_COUNTERVALUE, *PPDH_FMT_COUNTERVALUE;
	[PInvokeData("pdh.h", MSDNShortId = "68ccd722-94d2-4610-ba64-f51318f5436e")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct PDH_FMT_COUNTERVALUE
	{
		/// <summary>
		/// Counter status that indicates if the counter value is valid. Check this member before using the data in a calculation or
		/// displaying its value. For a list of possible values, see Checking PDH Interface Return Values.
		/// </summary>
		[FieldOffset(0)]
		public Win32Error CStatus;

		/// <summary>The computed counter value as a <c>LONG</c>.</summary>
		[FieldOffset(8)]
		public int longValue;

		/// <summary>The computed counter value as a <c>DOUBLE</c>.</summary>
		[FieldOffset(8)]
		public double doubleValue;

		/// <summary>The computed counter value as a <c>LONGLONG</c>.</summary>
		[FieldOffset(8)]
		public long largeValue;

		/// <summary>The computed counter value as a <c>LPCSTR</c>. Not supported.</summary>
		[FieldOffset(8)]
		public StrPtrAnsi AnsiStringValue;

		/// <summary>The computed counter value as a <c>LPCWSTR</c>. Not supported.</summary>
		[FieldOffset(8)]
		public StrPtrUni WideStringValue;
	}

	/// <summary>The <c>PDH_FMT_COUNTERVALUE_ITEM</c> structure contains the instance name and formatted value of a counter.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/ns-pdh-pdh_fmt_countervalue_item_a typedef struct
	// _PDH_FMT_COUNTERVALUE_ITEM_A { LPSTR szName; PDH_FMT_COUNTERVALUE FmtValue; } PDH_FMT_COUNTERVALUE_ITEM_A, *PPDH_FMT_COUNTERVALUE_ITEM_A;
	[PInvokeData("pdh.h", MSDNShortId = "d3bc6ad3-0cab-4843-ae1d-5f384948a1ea")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PDH_FMT_COUNTERVALUE_ITEM
	{
		/// <summary>
		/// Pointer to a null-terminated string that specifies the instance name of the counter. The string is appended to the end of
		/// this structure.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string szName;

		/// <summary>A PDH_FMT_COUNTERVALUE structure that contains the counter value of the instance.</summary>
		public PDH_FMT_COUNTERVALUE FmtValue;
	}

	/// <summary>Provides a handle to a PDH counter.</summary>
	[PInvokeData("pdh.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PDH_HCOUNTER : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="PDH_HCOUNTER"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public PDH_HCOUNTER(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="PDH_HCOUNTER"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static PDH_HCOUNTER NULL => new PDH_HCOUNTER(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="PDH_HCOUNTER"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(PDH_HCOUNTER h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PDH_HCOUNTER"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PDH_HCOUNTER(IntPtr h) => new PDH_HCOUNTER(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(PDH_HCOUNTER h1, PDH_HCOUNTER h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(PDH_HCOUNTER h1, PDH_HCOUNTER h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is PDH_HCOUNTER h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a PDH log.</summary>
	[PInvokeData("pdh.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PDH_HLOG : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="PDH_HLOG"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public PDH_HLOG(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="PDH_HLOG"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static PDH_HLOG NULL => new PDH_HLOG(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="PDH_HLOG"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(PDH_HLOG h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PDH_HLOG"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PDH_HLOG(IntPtr h) => new PDH_HLOG(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(PDH_HLOG h1, PDH_HLOG h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(PDH_HLOG h1, PDH_HLOG h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is PDH_HLOG h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a PDH query.</summary>
	[PInvokeData("pdh.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PDH_HQUERY : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="PDH_HQUERY"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public PDH_HQUERY(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="PDH_HQUERY"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static PDH_HQUERY NULL => new PDH_HQUERY(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="PDH_HQUERY"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(PDH_HQUERY h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PDH_HQUERY"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PDH_HQUERY(IntPtr h) => new PDH_HQUERY(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(PDH_HQUERY h1, PDH_HQUERY h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(PDH_HQUERY h1, PDH_HQUERY h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is PDH_HQUERY h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>
	/// The <c>PDH_RAW_COUNTER</c> structure returns the data as it was collected from the counter provider. No translation, formatting,
	/// or other interpretation is performed on the data.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/ns-pdh-pdh_raw_counter typedef struct _PDH_RAW_COUNTER { DWORD CStatus;
	// FILETIME TimeStamp; LONGLONG FirstValue; LONGLONG SecondValue; DWORD MultiCount; } PDH_RAW_COUNTER, *PPDH_RAW_COUNTER;
	[PInvokeData("pdh.h", MSDNShortId = "237a3c82-0ab4-45cb-bd93-2f308178c573")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PDH_RAW_COUNTER
	{
		/// <summary>
		/// Counter status that indicates if the counter value is valid. Check this member before using the data in a calculation or
		/// displaying its value. For a list of possible values, see Checking PDH Interface Return Values.
		/// </summary>
		public Win32Error CStatus;

		/// <summary>Local time for when the data was collected, in FILETIME format.</summary>
		public FILETIME TimeStamp;

		/// <summary>First raw counter value.</summary>
		public long FirstValue;

		/// <summary>Second raw counter value. Rate counters require two values in order to compute a displayable value.</summary>
		public long SecondValue;

		/// <summary>
		/// If the counter type contains the PERF_MULTI_COUNTER flag, this member contains the additional counter data used in the
		/// calculation. For example, the PERF_100NSEC_MULTI_TIMER counter type contains the PERF_MULTI_COUNTER flag.
		/// </summary>
		public uint MultiCount;
	}

	/// <summary>The <c>PDH_RAW_COUNTER_ITEM</c> structure contains the instance name and raw value of a counter.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/ns-pdh-pdh_raw_counter_item_a typedef struct _PDH_RAW_COUNTER_ITEM_A {
	// LPSTR szName; PDH_RAW_COUNTER RawValue; } PDH_RAW_COUNTER_ITEM_A, *PPDH_RAW_COUNTER_ITEM_A;
	[PInvokeData("pdh.h", MSDNShortId = "602e0d44-3551-4a26-a5b7-8f7015131f9a")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PDH_RAW_COUNTER_ITEM
	{
		/// <summary>
		/// Pointer to a null-terminated string that specifies the instance name of the counter. The string is appended to the end of
		/// this structure.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string szName;

		/// <summary>A PDH_RAW_COUNTER structure that contains the raw counter value of the instance.</summary>
		public PDH_RAW_COUNTER RawValue;
	}

	/// <summary>The <c>PDH_RAW_LOG_RECORD</c> structure contains information about a binary trace log file record.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/ns-pdh-pdh_raw_log_record typedef struct _PDH_RAW_LOG_RECORD { DWORD
	// dwStructureSize; DWORD dwRecordType; DWORD dwItems; UCHAR RawBytes[1]; } PDH_RAW_LOG_RECORD, *PPDH_RAW_LOG_RECORD;
	[PInvokeData("pdh.h", MSDNShortId = "ae96515f-ea3f-4578-a249-fb8f41cdfa69")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<PDH_RAW_LOG_RECORD>), nameof(dwItems))]
	[StructLayout(LayoutKind.Sequential)]
	public struct PDH_RAW_LOG_RECORD
	{
		/// <summary>
		/// Size of this structure, in bytes. The size includes this structure and the <c>RawBytes</c> appended to the end of this structure.
		/// </summary>
		public uint dwStructureSize;

		/// <summary>
		/// <para>Type of record. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PDH_LOG_TYPE_BINARY</term>
		/// <term>A binary trace format record</term>
		/// </item>
		/// <item>
		/// <term>PDH_LOG_TYPE_CSV</term>
		/// <term>A comma-separated-value format record</term>
		/// </item>
		/// <item>
		/// <term>PDH_LOG_TYPE_PERFMON</term>
		/// <term>A Perfmon format record</term>
		/// </item>
		/// <item>
		/// <term>PDH_LOG_TYPE_SQL</term>
		/// <term>A SQL format record</term>
		/// </item>
		/// <item>
		/// <term>PDH_LOG_TYPE_TSV</term>
		/// <term>A tab-separated-value format record</term>
		/// </item>
		/// </list>
		/// </summary>
		public PDH_LOG_TYPE dwRecordType;

		/// <summary>Size of the <c>RawBytes</c> data.</summary>
		public uint dwItems;

		/// <summary>Binary record.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] RawBytes;
	}

	/// <summary>
	/// The <c>PDH_STATISTICS</c> structure contains the minimum, maximum, and mean values for an array of raw counters values.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/ns-pdh-pdh_statistics typedef struct _PDH_STATISTICS { DWORD dwFormat;
	// DWORD count; PDH_FMT_COUNTERVALUE min; PDH_FMT_COUNTERVALUE max; PDH_FMT_COUNTERVALUE mean; } PDH_STATISTICS, *PPDH_STATISTICS;
	[PInvokeData("pdh.h", MSDNShortId = "a1daedfd-55f6-418e-b71f-8334cb628d98")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PDH_STATISTICS
	{
		/// <summary>Format of the data. The format is specified in the dwFormat when calling PdhComputeCounterStatistics.</summary>
		public PDH_FMT dwFormat;

		/// <summary>Number of values in the array.</summary>
		public uint count;

		/// <summary>Minimum of the values.</summary>
		public PDH_FMT_COUNTERVALUE min;

		/// <summary>Maximum of the values.</summary>
		public PDH_FMT_COUNTERVALUE max;

		/// <summary>Mean of the values.</summary>
		public PDH_FMT_COUNTERVALUE mean;
	}

	/// <summary>
	/// The <c>PDH_TIME_INFO</c> structure contains information on time intervals as applied to the sampling of performance data.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/pdh/ns-pdh-pdh_time_info typedef struct _PDH_TIME_INFO { LONGLONG StartTime;
	// LONGLONG EndTime; DWORD SampleCount; } PDH_TIME_INFO, *PPDH_TIME_INFO;
	[PInvokeData("pdh.h", MSDNShortId = "a747f288-8d6c-401c-a927-a61ffea3d423")]
	[StructLayout(LayoutKind.Sequential, Size = 24)]
	public struct PDH_TIME_INFO
	{
		/// <summary>Starting time of the sample interval, in local FILETIME format.</summary>
		public FILETIME StartTime;

		/// <summary>Ending time of the sample interval, in local FILETIME format.</summary>
		public FILETIME EndTime;

		/// <summary>Number of samples collected during the interval.</summary>
		public uint SampleCount;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="PDH_HCOUNTER"/> that is disposed using <see cref="PdhRemoveCounter"/>.</summary>
	public class SafePDH_HCOUNTER : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafePDH_HCOUNTER"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafePDH_HCOUNTER(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafePDH_HCOUNTER"/> class.</summary>
		private SafePDH_HCOUNTER() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafePDH_HCOUNTER"/> to <see cref="PDH_HCOUNTER"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PDH_HCOUNTER(SafePDH_HCOUNTER h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => PdhRemoveCounter(handle).Succeeded;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="PDH_HLOG"/> that is disposed using <see cref="PdhCloseLog"/>.</summary>
	public class SafePDH_HLOG : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafePDH_HLOG"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafePDH_HLOG(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafePDH_HLOG"/> class.</summary>
		private SafePDH_HLOG() : base() { }

		/// <summary>
		/// Gets or sets a value indicating whether to close the query associated with the specified log file handle on disposal. See the
		/// hQuery parameter of PdhOpenLog.
		/// </summary>
		public bool CloseAssocQueries { get; set; }

		/// <summary>Performs an implicit conversion from <see cref="SafePDH_HLOG"/> to <see cref="PDH_HLOG"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PDH_HLOG(SafePDH_HLOG h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => PdhCloseLog(handle, CloseAssocQueries ? 1U : 0).Succeeded;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="PDH_HQUERY"/> that is disposed using <see cref="PdhCloseQuery"/>.</summary>
	public class SafePDH_HQUERY : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafePDH_HQUERY"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafePDH_HQUERY(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafePDH_HQUERY"/> class.</summary>
		private SafePDH_HQUERY() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafePDH_HQUERY"/> to <see cref="PDH_HQUERY"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PDH_HQUERY(SafePDH_HQUERY h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => PdhCloseQuery(handle).Succeeded;
	}
}