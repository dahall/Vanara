global using System;
global using System.Runtime.InteropServices;
global using Vanara.Extensions;
global using Vanara.InteropServices;
global using static Vanara.PInvoke.Ws2_32;
global using IN_ADDR_IPV4 = Vanara.PInvoke.Ws2_32.IN_ADDR;
global using IN_ADDR_IPV6 = Vanara.PInvoke.Ws2_32.IN6_ADDR;

namespace Vanara.PInvoke;

/// <summary>Items from Qwave.dll.</summary>
public static partial class Qwave
{
	/// <summary>
	/// This flag can be used to prevent any rsvp signaling messages from being sent. Local traffic control will be invoked, but no RSVP Path
	/// messages will be sent. This flag can also be used in conjunction with a receiving flowspec to suppress the automatic generation of a
	/// Reserve message. The application would receive notification that a Path message had arrived and would then need to alter the QOS by
	/// issuing WSAIoctl( SIO_SET_QOS ), to unset this flag and thereby causing Reserve messages to go out.
	/// </summary>
	public const uint SERVICE_NO_QOS_SIGNALING = 0x40000000;

	private const uint QOS_GENERAL_ID_BASE = 2000;
	private const uint RSVP_OBJECT_ID_BASE = 1000;
	private const uint QOS_TRAFFIC_GENERAL_ID_BASE = 4000;

	/// <summary>Specifies the type of object to which QOS_OBJECT_HDR is attached.</summary>
	[PInvokeData("qos.h", MSDNShortId = "NS:qos.__unnamed_struct_0")]
	public enum QOS_OBJ_TYPE : uint
	{
		/// <summary>QOS_End_of_list structure passed</summary>
		[CorrespondingType(typeof(QOS_OBJECT_HDR))]
		QOS_OBJECT_END_OF_LIST = 0x00000001 + QOS_GENERAL_ID_BASE,

		/// <summary>QOS_ShapeDiscard structure passed</summary>
		[CorrespondingType(typeof(QOS_SD_MODE))]
		QOS_OBJECT_SD_MODE = 0x00000002 + QOS_GENERAL_ID_BASE,

		/// <summary>QOS_ShapingRate structure</summary>
		[CorrespondingType(typeof(QOS_SHAPING_RATE))]
		QOS_OBJECT_SHAPING_RATE = 0x00000003 + QOS_GENERAL_ID_BASE,

		/// <summary>QOS_DestAddr structure (defined in qossp.h)</summary>
		[CorrespondingType(typeof(QOS_DESTADDR))]
		QOS_OBJECT_DESTADDR = 0x00000004 + QOS_GENERAL_ID_BASE,

		/// <summary>QOS_DS_CLASS structure</summary>
		[CorrespondingType(typeof(QOS_DS_CLASS))]
		QOS_OBJECT_DS_CLASS = 0x00000001 + QOS_TRAFFIC_GENERAL_ID_BASE,

		/// <summary>QOS_TRAFFIC_CLASS structure</summary>
		[CorrespondingType(typeof(QOS_TRAFFIC_CLASS))]
		QOS_OBJECT_TRAFFIC_CLASS = 0x00000002 + QOS_TRAFFIC_GENERAL_ID_BASE,

		/// <summary>QOS_DIFFSERV structure</summary>
		[CorrespondingType(typeof(QOS_DIFFSERV))]
		QOS_OBJECT_DIFFSERV = 0x00000003 + QOS_TRAFFIC_GENERAL_ID_BASE,

		/// <summary>QOS_TCP_TRAFFIC structure</summary>
		[CorrespondingType(typeof(QOS_TCP_TRAFFIC))]
		QOS_OBJECT_TCP_TRAFFIC = 0x00000004 + QOS_TRAFFIC_GENERAL_ID_BASE,

		/// <summary>QOS_FRIENDLY_NAME structure</summary>
		[CorrespondingType(typeof(QOS_FRIENDLY_NAME))]
		QOS_OBJECT_FRIENDLY_NAME = 0x00000005 + QOS_TRAFFIC_GENERAL_ID_BASE,

		/// <summary>RSVP_STATUS_INFO structure</summary>
		[CorrespondingType(typeof(RSVP_STATUS_INFO))]
		RSVP_OBJECT_STATUS_INFO     = 0x00000000 + RSVP_OBJECT_ID_BASE,

		/// <summary>RSVP_RESERVE_INFO structure</summary>
		[CorrespondingType(typeof(RSVP_RESERVE_INFO))]
		RSVP_OBJECT_RESERVE_INFO    = 0x00000001 + RSVP_OBJECT_ID_BASE,

		/// <summary>RSVP_ADSPEC structure</summary>
		[CorrespondingType(typeof(RSVP_ADSPEC))]
		RSVP_OBJECT_ADSPEC          = 0x00000002 + RSVP_OBJECT_ID_BASE,

		/// <summary>RSVP_POLICY_INFO structure</summary>
		[CorrespondingType(typeof(RSVP_POLICY_INFO))]
		RSVP_OBJECT_POLICY_INFO     = 0x00000003 + RSVP_OBJECT_ID_BASE,

		/// <summary>RSVP_FILTERSPEC structure</summary>
		[CorrespondingType(typeof(RSVP_FILTERSPEC))]
		RSVP_OBJECT_FILTERSPEC_LIST = 0x00000004 + RSVP_OBJECT_ID_BASE,
	}

	/// <summary>Specifies the requested behavior of the packet shaper.</summary>
	[PInvokeData("qos.h", MSDNShortId = "NS:qos._QOS_SD_MODE")]
	public enum TC_NONCONF
	{
		/// <summary>
		/// This mode is currently only available to the TC API. It is not available to users of the QOS API. Instructs the packet shaper to
		/// borrow remaining available resources after all higher priority flows have been serviced. If the <c>TokenRate</c> member of
		/// FLOWSPEC is specified for this flow, packets that exceed the value of <c>TokenRate</c> will have their priority demoted to less
		/// than SERVICETYPE_BESTEFFORT, as defined in the <c>ServiceType</c> member of the <c>FLOWSPEC</c> structure.
		/// </summary>
		TC_NONCONF_BORROW = 0,

		/// <summary>
		/// Instructs the packet shaper to retain packets until network resources are available to the flow in sufficient quantity to make
		/// such packets conforming. (For example, a 100K packet will be retained in the packet shaper until 100K worth of credit is accrued
		/// for the flow, allowing the packet to be transmitted as conforming). Note that TokenRate must be specified if using TC_NONCONF_SHAPE.
		/// </summary>
		TC_NONCONF_SHAPE = 1,

		/// <summary>Instructs the packet shaper to discard all nonconforming packets. TC_NONCONF_DISCARD should be used with care.</summary>
		TC_NONCONF_DISCARD = 2,

		/// <summary>Not currently supported.</summary>
		TC_NONCONF_BORROW_PLUS = 3,
	}

	/// <summary>Represents a structure that starts with <see cref="QOS_OBJECT_HDR"/>.</summary>
	public interface IQoSObjectHdr { }

	/// <summary>The QOS object <c>QOS_OBJECT_HDR</c> is attached to each QOS object. It specifies the object type and its length.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos/ns-qos-qos_object_hdr typedef struct { ULONG ObjectType; ULONG ObjectLength; }
	// QOS_OBJECT_HDR, *LPQOS_OBJECT_HDR;
	[PInvokeData("qos.h", MSDNShortId = "NS:qos.__unnamed_struct_0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct QOS_OBJECT_HDR
	{
		/// <summary>
		/// <para>Specifies the type of object to which <c>QOS_OBJECT_HDR</c> is attached. The following values are valid for <c>QOS_OBJECT_HDR</c>:</para>
		/// <para>QOS_OBJECT_DESTADDR</para>
		/// <para>QOS_OBJECT_END_OF_LIST</para>
		/// <para>QOS_OBJECT_SD_MODE</para>
		/// <para>QOS_OBJECT_SHAPING_RATE</para>
		/// <para>RSVP_OBJECT_ADSPEC</para>
		/// <para>RSVP_OBJECT_FILTERSPEC_LIST</para>
		/// <para>RSVP_OBJECT_POLICY_INFO</para>
		/// <para>RSVP_OBJECT_RESERVE_INFO</para>
		/// </summary>
		public QOS_OBJ_TYPE ObjectType;

		/// <summary>Specifies the length of the attached object, inclusive of QOS_OBJECT_HDR.</summary>
		public uint ObjectLength;

		/// <summary>Initializes this instance from a type.</summary>
		/// <typeparam name="T">The structure to use.</typeparam>
		/// <returns>Initialized header.</returns>
		/// <exception cref="System.ArgumentException"></exception>
		public static QOS_OBJECT_HDR Init<T>() where T : IQoSObjectHdr
		{
			var ot = CorrespondingTypeAttribute.CanGet<QOS_OBJ_TYPE>(typeof(T), out var e) ? e : throw new ArgumentException();
			return new() { ObjectType = ot, ObjectLength = (uint)Marshal.SizeOf(typeof(T)) };
		}
	}

	/// <summary>The QOS object <c>QOS_SD_MODE</c> defines the behavior of the traffic control-packet shaper component.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos/ns-qos-qos_sd_mode typedef struct _QOS_SD_MODE { QOS_OBJECT_HDR ObjectHdr;
	// ULONG ShapeDiscardMode; } QOS_SD_MODE, *LPQOS_SD_MODE;
	[PInvokeData("qos.h", MSDNShortId = "NS:qos._QOS_SD_MODE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct QOS_SD_MODE : IQoSObjectHdr
	{
		/// <summary>The QOS object QOS_OBJECT_HDR. The object type for this QOS object should be <c>QOS_SD_MODE</c>.</summary>
		public QOS_OBJECT_HDR ObjectHdr;

		/// <summary>
		/// <para>
		/// Specifies the requested behavior of the packet shaper. Note that there are elements of packet handling within these predefined
		/// behaviors that depend on the flow settings specified within FLOWSPEC.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TC_NONCONF_BORROW</c></term>
		/// <term>
		/// This mode is currently only available to the TC API. It is not available to users of the QOS API. Instructs the packet shaper to
		/// borrow remaining available resources after all higher priority flows have been serviced. If the <c>TokenRate</c> member of
		/// FLOWSPEC is specified for this flow, packets that exceed the value of <c>TokenRate</c> will have their priority demoted to less
		/// than SERVICETYPE_BESTEFFORT, as defined in the <c>ServiceType</c> member of the <c>FLOWSPEC</c> structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>TC_NONCONF_SHAPE</c></term>
		/// <term>
		/// Instructs the packet shaper to retain packets until network resources are available to the flow in sufficient quantity to make
		/// such packets conforming. (For example, a 100K packet will be retained in the packet shaper until 100K worth of credit is accrued
		/// for the flow, allowing the packet to be transmitted as conforming). Note that TokenRate must be specified if using TC_NONCONF_SHAPE.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>TC_NONCONF_DISCARD</c></term>
		/// <term>Instructs the packet shaper to discard all nonconforming packets. TC_NONCONF_DISCARD should be used with care.</term>
		/// </item>
		/// </list>
		/// </summary>
		public TC_NONCONF ShapeDiscardMode;
	}

	/// <summary>The QOS object <c>QOS_SHAPING_RATE</c> specifies the uniform traffic shaping rate be applied to a given flow.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qos/ns-qos-qos_shaping_rate typedef struct _QOS_SHAPING_RATE { QOS_OBJECT_HDR
	// ObjectHdr; ULONG ShapingRate; } QOS_SHAPING_RATE, *LPQOS_SHAPING_RATE;
	[PInvokeData("qos.h", MSDNShortId = "NS:qos._QOS_SHAPING_RATE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct QOS_SHAPING_RATE : IQoSObjectHdr
	{
		/// <summary>The QOS object QOS_OBJECT_HDR. The object type for this QOS object should be <c>QOS_SHAPING_RATE</c>.</summary>
		public QOS_OBJECT_HDR ObjectHdr;

		/// <summary>Unsigned 32-bit integer that specifies the uniform traffic shaping rate in bytes per second.</summary>
		public uint ShapingRate;
	}
}