using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.CustomMarshalers;
using static Vanara.PInvoke.OleAut32;

namespace Vanara.PInvoke;

/// <summary>Interfaces and constants for IMAPI v1 and v2.</summary>
public static partial class IMAPI
{
	/// <summary>Implement this interface to receive notifications of the current write operation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-ddiscformat2dataevents
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.DDiscFormat2DataEvents")]
	[ComImport, Guid("2735413C-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
#pragma warning disable IDE1006 // Naming Styles
	public interface DDiscFormat2DataEvents
	{
		/// <summary>Implement this method to receive progress notification of the current write operation.</summary>
		/// <param name="object">
		/// <para>The IDiscFormat2Data interface that initiated the write operation.</para>
		/// <para>This parameter is a <c>MsftDiscFormat2Data</c> object in script.</para>
		/// </param>
		/// <param name="progress">
		/// <para>An IDiscFormat2DataEventArgs interface that you use to determine the progress of the write operation.</para>
		/// <para>This parameter is a <c>MsftDiscFormat2Data</c> object in script.</para>
		/// </param>
		/// <returns>Return values are ignored.</returns>
		/// <remarks>
		/// <para>Notifications are sent in response to calling the IDiscFormat2Data::Write method.</para>
		/// <para>Notification is sent when the current action changes:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Once when initializing the hardware</term>
		/// </item>
		/// <item>
		/// <term>Once when calibrating the power</term>
		/// </item>
		/// <item>
		/// <term>Once when formatting the media, if required by the media type</term>
		/// </item>
		/// <item>
		/// <term>Every 0.5 seconds during the write operation</term>
		/// </item>
		/// <item>
		/// <term>Once after the operation completes</term>
		/// </item>
		/// </list>
		/// <para>To stop the write process, call the IDiscFormat2Data::CancelWrite method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-ddiscformat2dataevents-update HRESULT Update( IDispatch
		// *object, IDispatch *progress );
		[DispId(0x200)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Update([In, MarshalAs(UnmanagedType.IDispatch)] IDiscFormat2Data @object,
					[In, MarshalAs(UnmanagedType.IDispatch)] IDiscFormat2DataEventArgs progress);
	}

	/// <summary>Receive notifications of the current write operation.</summary>
	/// <seealso cref="Vanara.PInvoke.IMAPI.DDiscFormat2DataEvents"/>
	[ClassInterface(ClassInterfaceType.None)]
	public class DDiscFormat2DataEventsSink : DDiscFormat2DataEvents
	{
		/// <summary>Initializes a new instance of the <see cref="DDiscFormat2DataEventsSink"/> class.</summary>
		/// <param name="onUpdate">The update.</param>
		public DDiscFormat2DataEventsSink(Action<IDiscFormat2Data, IDiscFormat2DataEventArgs>? onUpdate)
		{
			if (onUpdate is not null) Update += onUpdate;
		}

		/// <summary>Occurs when the current write operation sends a progress notification.</summary>
		/// <remarks>
		/// <para>Notifications are sent in response to calling the IDiscFormat2Data::Write method.</para>
		/// <para>Notification is sent when the current action changes:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Once when initializing the hardware</term>
		/// </item>
		/// <item>
		/// <term>Once when calibrating the power</term>
		/// </item>
		/// <item>
		/// <term>Once when formatting the media, if required by the media type</term>
		/// </item>
		/// <item>
		/// <term>Every 0.5 seconds during the write operation</term>
		/// </item>
		/// <item>
		/// <term>Once after the operation completes</term>
		/// </item>
		/// </list>
		/// <para>To stop the write process, call the IDiscFormat2Data::CancelWrite method.</para>
		/// </remarks>
		public event Action<IDiscFormat2Data, IDiscFormat2DataEventArgs>? Update;

		void DDiscFormat2DataEvents.Update(IDiscFormat2Data @object, IDiscFormat2DataEventArgs progress) => Update?.Invoke(@object, progress);
	}

	/// <summary>Implement this interface to receive notifications of the current erase operation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-ddiscformat2eraseevents
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.DDiscFormat2EraseEvents")]
	[ComImport, Guid("2735413A-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface DDiscFormat2EraseEvents
	{
		/// <summary>Implement this method to receive progress notification of the current erase operation.</summary>
		/// <param name="object">
		/// <para>The IDiscFormat2Erase interface that initiated the erase operation.</para>
		/// <para>This parameter is a <c>MsftDiscFormat2Erase</c> object in script.</para>
		/// </param>
		/// <param name="elapsedSeconds">Elapsed time, in seconds, of the erase operation.</param>
		/// <param name="estimatedTotalSeconds">Estimated time, in seconds, to complete the erase operation.</param>
		/// <returns>Return values are ignored.</returns>
		/// <remarks>
		/// <para>Notifications are sent in response to calling the IDiscFormat2Erase::EraseMedia method.</para>
		/// <para>Notification is sent every 0.5 or 1.0 seconds depending on the method required to blank the media.</para>
		/// <para>
		/// Total time estimates for a single erasure can vary as the operation progresses. The drive provides updated information that
		/// can affect the projected duration of the erasure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-ddiscformat2eraseevents-update HRESULT Update( IDispatch
		// *object, LONG elapsedSeconds, LONG estimatedTotalSeconds );
		[DispId(0x200)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Update([In, MarshalAs(UnmanagedType.IDispatch)] IDiscFormat2Erase @object, int elapsedSeconds, int estimatedTotalSeconds);
	}

	/// <summary>Receive notifications of the current erase operation.</summary>
	[ClassInterface(ClassInterfaceType.None)]
	public class DDiscFormat2EraseEventsSink : DDiscFormat2EraseEvents
	{
		/// <summary>Initializes a new instance of the <see cref="DDiscFormat2EraseEventsSink"/> class.</summary>
		/// <param name="onUpdate">The on update.</param>
		public DDiscFormat2EraseEventsSink(Action<IDiscFormat2Erase, int, int>? onUpdate)
		{
			if (onUpdate is not null) Update += onUpdate;
		}

		/// <summary>Implement this method to receive progress notification of the current erase operation.</summary>
		/// <remarks>
		/// <para>Notifications are sent in response to calling the IDiscFormat2Erase::EraseMedia method.</para>
		/// <para>Notification is sent every 0.5 or 1.0 seconds depending on the method required to blank the media.</para>
		/// <para>
		/// Total time estimates for a single erasure can vary as the operation progresses. The drive provides updated information that
		/// can affect the projected duration of the erasure.
		/// </para>
		/// </remarks>
		public event Action<IDiscFormat2Erase, int, int>? Update;

		void DDiscFormat2EraseEvents.Update(IDiscFormat2Erase @object, int elapsedSeconds, int estimatedTotalSeconds) => Update?.Invoke(@object, elapsedSeconds, estimatedTotalSeconds);
	}

	/// <summary>Implement this interface to receive notifications of the current raw-image write operation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-ddiscformat2rawcdevents
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.DDiscFormat2RawCDEvents")]
	[ComImport, Guid("27354142-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface DDiscFormat2RawCDEvents
	{
		/// <summary>Implement this method to receive progress notification of the current raw-image write operation.</summary>
		/// <param name="object">
		/// <para>The IDiscFormat2RawCD interface that initiated the write operation.</para>
		/// <para>This parameter is a <c>MsftDiscFormat2RawCD</c> object in script.</para>
		/// </param>
		/// <param name="progress">
		/// <para>An IDiscFormat2RawCDEventArgs interface that you use to determine the progress of the write operation.</para>
		/// <para>This parameter is a <c>MsftDiscFormat2RawCD</c> object in script.</para>
		/// </param>
		/// <returns>Return values are ignored.</returns>
		/// <remarks>
		/// <para>
		/// Notifications are sent in response to calling the IDiscFormat2RawCD::WriteMedia or IDiscFormat2RawCD::WriteMedia2 method.
		/// </para>
		/// <para>To stop the write process, call the IDiscFormat2RawCD::CancelWrite method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-ddiscformat2rawcdevents-update HRESULT Update( IDispatch
		// *object, IDispatch *progress );
		[DispId(0x200)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Update([In, MarshalAs(UnmanagedType.IDispatch)] IDiscFormat2RawCD @object,
			[In, MarshalAs(UnmanagedType.IDispatch)] IDiscFormat2RawCDEventArgs progress);
	}

	/// <summary>Receive notifications of the current raw-image write operation.</summary>
	[ClassInterface(ClassInterfaceType.None)]
	public class DDiscFormat2RawCDEventsSink : DDiscFormat2RawCDEvents
	{
		/// <summary>Initializes a new instance of the <see cref="DDiscFormat2RawCDEventsSink"/> class.</summary>
		/// <param name="onUpdate">The on update.</param>
		public DDiscFormat2RawCDEventsSink(Action<IDiscFormat2RawCD, IDiscFormat2RawCDEventArgs>? onUpdate)
		{
			if (onUpdate is not null) Update += onUpdate;
		}

		/// <summary>Implement this method to receive progress notification of the current raw-image write operation.</summary>
		/// <remarks>
		/// <para>
		/// Notifications are sent in response to calling the IDiscFormat2RawCD::WriteMedia or IDiscFormat2RawCD::WriteMedia2 method.
		/// </para>
		/// <para>To stop the write process, call the IDiscFormat2RawCD::CancelWrite method.</para>
		/// </remarks>
		public event Action<IDiscFormat2RawCD, IDiscFormat2RawCDEventArgs>? Update;

		void DDiscFormat2RawCDEvents.Update(IDiscFormat2RawCD @object, IDiscFormat2RawCDEventArgs progress) => Update?.Invoke(@object, progress);
	}

	/// <summary>Implement this interface to receive notifications of the current track-writing operation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-ddiscformat2trackatonceevents
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.DDiscFormat2TrackAtOnceEvents")]
	[ComImport, Guid("2735413F-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface DDiscFormat2TrackAtOnceEvents
	{
		/// <summary>Implement this method to receive progress notification of the current track-writing operation.</summary>
		/// <param name="object">
		/// <para>The IDiscFormat2TrackAtOnce interface that initiated the write operation.</para>
		/// <para>This parameter is a <c>MsftDiscFormat2TrackAtOnce</c> object in script.</para>
		/// </param>
		/// <param name="progress">
		/// <para>An IDiscFormat2TrackAtOnceEventArgs interface that you use to determine the progress of the write operation.</para>
		/// <para>This parameter is a <c>MsftDiscFormat2TrackAtOnce</c> object in script.</para>
		/// </param>
		/// <returns>Return values are ignored.</returns>
		/// <remarks>
		/// <para>Notifications are sent in response to calling the IDiscFormat2TrackAtOnce::AddAudioTrack method.</para>
		/// <para>To stop the write process, call the IDiscFormat2TrackAtOnce::CancelAddTrack method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-ddiscformat2trackatonceevents-update HRESULT Update(
		// IDispatch *object, IDispatch *progress );
		[DispId(0x200)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Update([In, MarshalAs(UnmanagedType.IDispatch)] IDiscFormat2TrackAtOnce @object,
			[In, MarshalAs(UnmanagedType.IDispatch)] IDiscFormat2TrackAtOnceEventArgs progress);
	}

	/// <summary>Receive notifications of the current track-writing operation.</summary>
	[ClassInterface(ClassInterfaceType.None)]
	public class DDiscFormat2TrackAtOnceEventsSink : DDiscFormat2TrackAtOnceEvents
	{
		/// <summary>Initializes a new instance of the <see cref="DDiscFormat2TrackAtOnceEventsSink"/> class.</summary>
		/// <param name="onUpdate">The on update.</param>
		public DDiscFormat2TrackAtOnceEventsSink(Action<IDiscFormat2TrackAtOnce, IDiscFormat2TrackAtOnceEventArgs>? onUpdate)
		{
			if (onUpdate is not null) Update += onUpdate;
		}

		/// <summary>Implement this method to receive progress notification of the current track-writing operation.</summary>
		/// <remarks>
		/// <para>Notifications are sent in response to calling the IDiscFormat2TrackAtOnce::AddAudioTrack method.</para>
		/// <para>To stop the write process, call the IDiscFormat2TrackAtOnce::CancelAddTrack method.</para>
		/// </remarks>
		public event Action<IDiscFormat2TrackAtOnce, IDiscFormat2TrackAtOnceEventArgs>? Update;

		void DDiscFormat2TrackAtOnceEvents.Update(IDiscFormat2TrackAtOnce @object, IDiscFormat2TrackAtOnceEventArgs progress) => Update?.Invoke(@object, progress);
	}

	/// <summary>Implement this interface to receive notification when a CD or DVD device is added to or removed from the computer.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-ddiscmaster2events
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.DDiscMaster2Events")]
	[ComImport, Guid("27354131-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface DDiscMaster2Events
	{
		/// <summary>Receives notification when an optical media device is added to the computer.</summary>
		/// <param name="object">
		/// <para>An IDiscMaster2 interface that you can use to enumerate the devices on the computer.</para>
		/// <para>This parameter is a <c>MsftDiscMaster2</c> object in script.</para>
		/// </param>
		/// <param name="uniqueId">
		/// String that contains an identifier that uniquely identifies the optical media device that was added to the computer.
		/// </param>
		/// <returns>Return values are ignored.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-ddiscmaster2events-notifydeviceadded HRESULT
		// NotifyDeviceAdded( IDispatch *object, BSTR uniqueId );
		[DispId(0x100)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void NotifyDeviceAdded([In, MarshalAs(UnmanagedType.IDispatch)] IDiscMaster2 @object, [In, MarshalAs(UnmanagedType.BStr)] string uniqueId);

		/// <summary>Receives notification when an optical media device is removed from the computer.</summary>
		/// <param name="object">
		/// <para>An IDiscMaster2 interface that you can use to enumerate the devices on the computer.</para>
		/// <para>This parameter is a <c>MsftDiscMaster2</c> object in script.</para>
		/// </param>
		/// <param name="uniqueId">
		/// String that contains an identifier that uniquely identifies the optical media device that was added to the computer.
		/// </param>
		/// <returns>Return values are ignored.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-ddiscmaster2events-notifydeviceremoved HRESULT
		// NotifyDeviceRemoved( IDispatch *object, BSTR uniqueId );
		[DispId(0x101)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void NotifyDeviceRemoved([In, MarshalAs(UnmanagedType.IDispatch)] IDiscMaster2 @object, [In, MarshalAs(UnmanagedType.BStr)] string uniqueId);
	}

	/// <summary>Receive notifications of the current track-writing operation.</summary>
	[ClassInterface(ClassInterfaceType.None)]
	public class DDiscMaster2EventsSink : DDiscMaster2Events
	{
		/// <summary>Initializes a new instance of the <see cref="DDiscMaster2EventsSink"/> class.</summary>
		/// <param name="onAdded">The delegate to call when a device is added.</param>
		/// <param name="onRemoved">The delegate to call when a device is removed.</param>
		public DDiscMaster2EventsSink(Action<IDiscMaster2, string>? onAdded, Action<IDiscMaster2, string>? onRemoved)
		{
			if (onAdded is not null) NotifyDeviceAdded += onAdded;
			if (onRemoved is not null) NotifyDeviceRemoved += onRemoved;
		}

		/// <summary>Receives notification when an optical media device is added to the computer.</summary>
		public event Action<IDiscMaster2, string>? NotifyDeviceAdded;

		/// <summary>Receives notification when an optical media device is removed from the computer.</summary>
		public event Action<IDiscMaster2, string>? NotifyDeviceRemoved;

		void DDiscMaster2Events.NotifyDeviceAdded(IDiscMaster2 @object, string uniqueId) => NotifyDeviceAdded?.Invoke(@object, uniqueId);
		void DDiscMaster2Events.NotifyDeviceRemoved(IDiscMaster2 @object, string uniqueId) => NotifyDeviceRemoved?.Invoke(@object, uniqueId);
	}

	/// <summary>Implement this interface to receive notifications of the current write operation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-dwriteengine2events
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.DWriteEngine2Events")]
	[ComImport, Guid("27354137-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface DWriteEngine2Events
	{
		/// <summary>Implement this method to receive progress notification of the current write operation.</summary>
		/// <param name="object">
		/// <para>The IWriteEngine2 interface that initiated the write operation.</para>
		/// <para>This parameter is a <c>MsftWriteEngine2</c> object in script.</para>
		/// </param>
		/// <param name="progress">
		/// <para>An IWriteEngine2EventArgs interface that you use to determine the progress of the write operation.</para>
		/// <para>This parameter is a <c>MsftWriteEngine2</c> object in script.</para>
		/// </param>
		/// <returns>Return values are ignored.</returns>
		/// <remarks>
		/// <para>Notifications are sent in response to calling the IWriteEngine2::WriteSection method.</para>
		/// <para>Notification is sent:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Once before the operation begins</term>
		/// </item>
		/// <item>
		/// <term>Every 0.5 seconds during the write operation</term>
		/// </item>
		/// <item>
		/// <term>Once after the operation completes</term>
		/// </item>
		/// </list>
		/// <para>To stop the write process, call the IWriteEngine2::CancelWrite method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-dwriteengine2events-update HRESULT Update( IDispatch
		// *object, IDispatch *progress );
		[DispId(0x100)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Update([In, MarshalAs(UnmanagedType.IDispatch)] IWriteEngine2 @object, [In, MarshalAs(UnmanagedType.IDispatch)] IWriteEngine2EventArgs progress);
	}

	/// <summary>Receive notifications of the current write operation.</summary>
	/// <seealso cref="Vanara.PInvoke.IMAPI.DWriteEngine2Events"/>
	[ClassInterface(ClassInterfaceType.None)]
	public class DWriteEngine2EventsSink : DWriteEngine2Events
	{
		/// <summary>Initializes a new instance of the <see cref="DWriteEngine2EventsSink"/> class.</summary>
		/// <param name="onUpdate">The on update.</param>
		public DWriteEngine2EventsSink(Action<IWriteEngine2, IWriteEngine2EventArgs>? onUpdate)
		{
			if (onUpdate is not null) Update += onUpdate;
		}

		/// <summary>Implement this method to receive progress notification of the current write operation.</summary>
		/// <remarks>
		/// <para>Notifications are sent in response to calling the IWriteEngine2::WriteSection method.</para>
		/// <para>Notification is sent:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Once before the operation begins</term>
		/// </item>
		/// <item>
		/// <term>Every 0.5 seconds during the write operation</term>
		/// </item>
		/// <item>
		/// <term>Once after the operation completes</term>
		/// </item>
		/// </list>
		/// <para>To stop the write process, call the IWriteEngine2::CancelWrite method.</para>
		/// </remarks>
		public event Action<IWriteEngine2, IWriteEngine2EventArgs>? Update;

		void DWriteEngine2Events.Update(IWriteEngine2 @object, IWriteEngine2EventArgs progress) => Update?.Invoke(@object, progress);
	}

#pragma warning restore IDE1006 // Naming Styles

	/// <summary>
	/// Use this interface to retrieve information about a single continuous range of sectors on the media. This interface is typically
	/// used together with the IBlockRangeList interface to describe a collection of sector ranges.
	/// </summary>
	/// <remarks>
	/// The values returned by the IBlockRange::get_StartLba and IBlockRange::get_EndLba methods define an inclusive range, i.e. both
	/// the start and end sectors belong to the range.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-iblockrange
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IBlockRange")]
	[ComImport, Guid("B507CA25-2204-11DD-966A-001AA01BBC58"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(BlockRange))]
	public interface IBlockRange
	{
		/// <summary>Retrieves the start sector of the range described by IBlockRange.</summary>
		/// <value>The start sector of the range.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iblockrange-get_startlba
		// HRESULT get_StartLba( LONG *value );
		[DispId(0x100)]
		int StartLba { get; }

		/// <summary>Retrieves the end sector of the range specified by the IBlockRange interface.</summary>
		/// <value>The end sector of the range.</value>
		/// <remarks>The sector number returned by this method is included in the range.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iblockrange-get_endlba
		// HRESULT get_EndLba( LONG *value );
		[DispId(0x101)]
		int EndLba { get; }
	}

	/// <summary>
	/// Use this interface to retrieve a list of continuous sector ranges on the media. This interface is used to describe the sectors
	/// that need to be updated on a rewritable disc when a new logical session is recorded.
	/// </summary>
	/// <remarks>
	/// <para>
	/// <c>IBlockRangeList</c> is returned by the IFileSystemImageResult2::ModifiedBlocks method. Alternatively,
	/// IUnknown::QueryInterface can be called on the object returned by IFileSystemImageResult::get_ImageStream to get the list of
	/// modified sectors in the result image represented by that object.
	/// </para>
	/// <para>
	/// The order of sector ranges in <c>IBlockRangeList</c> is taken into account during burning. The sector ranges having lower
	/// indexes in the safe array returned by IBlockRangeList::get_BlockRanges are written before those with higher indexes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-iblockrangelist
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IBlockRangeList")]
	[ComImport, Guid("B507CA26-2204-11DD-966A-001AA01BBC58"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(BlockRangeList))]
	public interface IBlockRangeList
	{
		/// <summary>Returns the list of sector ranges in the form of a safe array of variants of type VT_Dispatch.</summary>
		/// <value>
		/// List of sector ranges. Each element of the list is a VARIANT of type VT_Dispatch. Query the pdispVal member of the variant
		/// for the IBlockRange interface.
		/// </value>
		/// <remarks>
		/// The order of sector ranges in IBlockRangeList is taken into account during burning. The sector ranges having lower indexes
		/// in the safe array returned by <c>IBlockRangeList::get_BlockRanges</c> are written before those with higher indexes.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iblockrangelist-get_blockranges
		// HRESULT get_BlockRanges( SAFEARRAY **value );
		[DispId(0x100)]
		IBlockRange[] BlockRanges { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IBlockRange>))] get; }
	}

	/// <summary>
	/// Use this interface with IDiscFormat2Data or IDiscFormat2TrackAtOnce to get or set the Burn Verification Level property which
	/// dictates how burned media is verified for integrity after the write operation.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The following example function demonstrates how the burn verification level defined by IMAPI_BURN_VERIFICATION_LEVEL, can be
	/// implemented. Burn verification level should be set prior to a burn operation.
	/// </para>
	/// <para>
	/// <code>#include &lt;imapi2.h&gt; HRESULT setBurnVerification( IDiscFormat2Data *DataWriter, IMAPI_BURN_VERIFICATION_LEVEL VerificationLevel ) { HRESULT hr = S_OK; IBurnVerification *burnVerifier = NULL; hr = DataWriter-&gt;QueryInterface(IID_PPV_ARGS(&amp;burnVerifier)); if (SUCCEEDED(hr)) { hr = burnVerifier-&gt;put_BurnVerificationLevel(VerificationLevel); } if (burnVerifier != NULL) { burnVerifier-&gt;Release(); burnVerifier = NULL; } return hr; }</code>
	/// </para>
	/// <para>
	/// This interface is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
	/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7 and
	/// Windows Server 2008 R2.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-iburnverification
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IBurnVerification")]
	[ComImport, Guid("D2FFD834-958B-426d-8470-2A13879C6A91"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IBurnVerification
	{
		/// <summary>Retrieves the current Burn Verification Level.</summary>
		/// <value>Pointer to an IMAPI_BURN_VERIFICATION_LEVEL enumeration that specifies the current the Burn Verification Level.</value>
		/// <remarks>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iburnverification-get_burnverificationlevel HRESULT
		// get_BurnVerificationLevel( IMAPI_BURN_VERIFICATION_LEVEL *value );
		[DispId(0x400)]
		IMAPI_BURN_VERIFICATION_LEVEL BurnVerificationLevel { set; get; }
	}

	/// <summary>
	/// <para>Use this interface to write a data stream to a disc.</para>
	/// <para>
	/// To create an instance of this interface, call the <c>CoCreateInstance</c> function. Use__uuidof(MsftDiscFormat2Data) for the
	/// class identifier and __uuidof(IDiscFormat2Data) for the interface identifier.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// To create the <c>MsftDiscFormat2Data</c> object in a script, use IMAPI2.MsftDiscFormat2Data as the program identifier when
	/// calling <c>CreateObject</c>.
	/// </para>
	/// <para>
	/// It is possible for a power state transition to take place during a burn operation (i.e. user log-off or system suspend) which
	/// leads to the interruption of the burn process and possible data loss. For programming considerations, see Preventing Logoff or
	/// Suspend During a Burn.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-idiscformat2data
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IDiscFormat2Data")]
	[ComImport, Guid("27354153-9F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftDiscFormat2Data))]
	public interface IDiscFormat2Data : IDiscFormat2
	{
		/// <summary>Determines if the recorder supports the given format.</summary>
		/// <param name="recorder">An IDiscRecorder2 interface of the recorder to test.</param>
		/// <returns>Is VARIANT_TRUE if the recorder supports the given format; otherwise, VARIANT_FALSE.</returns>
		/// <remarks>
		/// When implemented by the IDiscFormat2RawCD interface, this method will return E_IMAPI_DF2RAW_MEDIA_IS_NOT_SUPPORTED in the event
		/// the recorder does not support the given format. It is important to note that in this specific scenario the value does not
		/// indicate that an error has occurred, but rather the result of a successful operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-isrecordersupported HRESULT IsRecorderSupported(
		// IDiscRecorder2 *recorder, VARIANT_BOOL *value );
		[DispId(2048)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		new bool IsRecorderSupported(IDiscRecorder2 recorder);

		/// <summary>Determines if the current media in a supported recorder supports the given format.</summary>
		/// <param name="recorder">An IDiscRecorder2 interface of the recorder to test.</param>
		/// <returns>
		/// <para>Is VARIANT_TRUE if the media in the recorder supports the given format; otherwise, VARIANT_FALSE.</para>
		/// <para><c>Note</c> VARIANT_TRUE also implies that the result from IsDiscRecorderSupported is VARIANT_TRUE.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-iscurrentmediasupported HRESULT
		// IsCurrentMediaSupported( IDiscRecorder2 *recorder, VARIANT_BOOL *value );
		[DispId(2049)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		new bool IsCurrentMediaSupported(IDiscRecorder2 recorder);

		/// <summary>Determines if the current media is reported as physically blank by the drive.</summary>
		/// <value>Is VARIANT_TRUE if the disc is physically blank; otherwise, VARIANT_FALSE.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-get_mediaphysicallyblank HRESULT
		// get_MediaPhysicallyBlank( VARIANT_BOOL *value );
		[DispId(1792)]
		new bool MediaPhysicallyBlank { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Attempts to determine if the media is blank using heuristics (mainly for DVD+RW and DVD-RAM media).</summary>
		/// <value>Is VARIANT_TRUE if the disc is likely to be blank; otherwise; VARIANT_FALSE.</value>
		/// <remarks>
		/// <para>
		/// This method checks, for example, for a mounted file system on the device, verifying the first and last 2MB of the disc are
		/// filled with zeros, and other media-specific checks. These checks can help to determine if the media may have files on it for
		/// media that cannot be erased physically to a blank status.
		/// </para>
		/// <para>For a positive check that a disc is blank, call the IDiscFormat2::get_MediaPhysicallyBlank method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-get_mediaheuristicallyblank HRESULT
		// get_MediaHeuristicallyBlank( VARIANT_BOOL *value );
		[DispId(1793)]
		new bool MediaHeuristicallyBlank { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the media types that are supported by the current implementation of the IDiscFormat2 interface.</summary>
		/// <value>
		/// List of media types supported by the current implementation of the IDiscFormat2 interface. Each element of the array is a
		/// <c>VARIANT</c> of type <c>VT_I4</c>. The <c>lVal</c> member of <c>VARIANT</c> contains the media type. For a list of media
		/// types, see the IMAPI_MEDIA_PHYSICAL_TYPE enumeration type.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-get_supportedmediatypes HRESULT
		// get_SupportedMediaTypes( SAFEARRAY **value );
		[DispId(1794)]
		new IMAPI_MEDIA_PHYSICAL_TYPE[] SupportedMediaTypes { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IMAPI_MEDIA_PHYSICAL_TYPE>))] get; }

		/// <summary>Sets the recording device to use for the write operation.</summary>
		/// <value>An IDiscRecorder2 interface that identifies the recording device to use in the write operation.</value>
		/// <remarks>
		/// The recorder must be compatible with the format defined by this interface. To determine compatibility, call the
		/// IDiscFormat2::IsRecorderSupported method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-put_recorder HRESULT put_Recorder(
		// IDiscRecorder2 *value );
		[DispId(256)]
		IDiscRecorder2 Recorder { set; [return: MarshalAs(UnmanagedType.Interface)] get; }

		/// <summary>Determines if Buffer Underrun Free recording is enabled.</summary>
		/// <value>
		/// Set to VARIANT_TRUE to disable Buffer Underrun Free recording; otherwise, VARIANT_FALSE. The default is VARIANT_FALSE (enabled).
		/// </value>
		/// <remarks>
		/// Buffer underrun can be an issue if the data stream does not enter the buffer fast enough to keep the device continuously
		/// writing. In turn, the stop and start action of writing can cause data on the disc to be unusable. Buffer Underrun Free (BUF)
		/// recording allows the laser to start and stop without damaging data already written to the disc. Disabling of BUF recording is
		/// possible only on CD-R/RW media.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-put_bufferunderrunfreedisabled HRESULT
		// put_BufferUnderrunFreeDisabled( VARIANT_BOOL value );
		[DispId(257)]
		bool BufferUnderrunFreeDisabled { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Determines if the data stream contains post-writing gaps.</summary>
		/// <value>Set to VARIANT_TRUE if the data stream contains post-writing gaps; otherwise, VARIANT_FALSE. The default is VARIANT_FALSE.</value>
		/// <remarks>
		/// Note that writing to CD-R/RW media will automatically append a post-gap of 150 sectors, unless this property is explicitly disabled.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-put_postgapalreadyinimage HRESULT
		// put_PostgapAlreadyInImage( VARIANT_BOOL value );
		[DispId(260)]
		bool PostgapAlreadyInImage { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the current state of the media in the device.</summary>
		/// <value>
		/// State of the media in the disc device. For possible values, see the IMAPI_FORMAT2_DATA_MEDIA_STATE enumeration type. Note that
		/// more than one state can be set.
		/// </value>
		/// <remarks>For an example that uses this property, see Checking Media Support.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_currentmediastatus HRESULT
		// get_CurrentMediaStatus( IMAPI_FORMAT2_DATA_MEDIA_STATE *value );
		[DispId(262)]
		IMAPI_FORMAT2_DATA_MEDIA_STATE CurrentMediaStatus { get; }

		/// <summary>Retrieves the current write protect state of the media in the device.</summary>
		/// <value>
		/// <para>
		/// The current write protect state of the media in the device. For possible values, see the IMAPI_MEDIA_WRITE_PROTECT_STATE
		/// enumeration type.
		/// </para>
		/// <para>Note that more than one state can be set.</para>
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_writeprotectstatus HRESULT
		// get_WriteProtectStatus( IMAPI_MEDIA_WRITE_PROTECT_STATE *value );
		[DispId(263)]
		IMAPI_MEDIA_WRITE_PROTECT_STATE WriteProtectStatus { get; }

		/// <summary>Retrieves the number of sectors on the media in the device.</summary>
		/// <value>Number of sectors on the media in the device. The number includes free sectors, used sectors, and the boot sector.</value>
		/// <remarks>This value does not necessarily reflect the total usable sectors on the media, not even for a blank disc.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_totalsectorsonmedia HRESULT
		// get_TotalSectorsOnMedia( LONG *value );
		[DispId(264)]
		int TotalSectorsOnMedia { get; }

		/// <summary>Retrieves the number of free sectors on the disc for incremental recording (without overwriting existing data).</summary>
		/// <value>Number of free sectors on the media in the device.</value>
		/// <remarks>
		/// <para>
		/// The value of this property is effectively the number of sectors available on disc for the write operation. The value filters
		/// sectors consumed in managing the disc space and data quality, such as run-out blocks and postgaps.
		/// </para>
		/// <para>
		/// <c>Note</c> For overwritable discs, which have only one physical session, the number of free sectors indicated by value will
		/// always be the total number of sectors on the disc.
		/// </para>
		/// <para>
		/// If IDiscFormat2Data::put_ForceOverwrite is set to VARIANT_TRUE, use the IDiscFormat2Data::get_TotalSectorsOnMedia property instead.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_freesectorsonmedia HRESULT
		// get_FreeSectorsOnMedia( LONG *value );
		[DispId(265)]
		int FreeSectorsOnMedia { get; }

		/// <summary>Retrieves the location for the next write operation.</summary>
		/// <value>Address where the next write operation begins.</value>
		/// <remarks>
		/// <para>Blank media begin writing at location zero.</para>
		/// <para>In multi-session writing, the next writable address is useful for setting up a correct file system.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_nextwritableaddress HRESULT
		// get_NextWritableAddress( LONG *value );
		[DispId(266)]
		int NextWritableAddress { get; }

		/// <summary>Retrieves the first sector of the previous write session.</summary>
		/// <value>
		/// <para>Address where the previous write operation began.</para>
		/// <para>
		/// The value is -1 if the media is blank or does not support multi-session writing (indicates that no previous session could be detected).
		/// </para>
		/// </value>
		/// <remarks>
		/// <c>Note</c> This property should not be used. Instead, you should use an interface derived from IMultisession, such as
		/// IMultisessionSequential, for importing file data from the previous session.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_startaddressofprevioussession HRESULT
		// get_StartAddressOfPreviousSession( LONG *value );
		[DispId(267)]
		int StartAddressOfPreviousSession { get; }

		/// <summary>Retrieves the last sector of the previous write session.</summary>
		/// <value>
		/// <para>Address where the previous write operation ended.</para>
		/// <para>
		/// The value is -1 if the media is blank or does not support multi-session writing (indicates that no previous session could be detected).
		/// </para>
		/// </value>
		/// <remarks>
		/// <c>Note</c> This property should not be used. Instead, you should use an interface derived from IMultisession, such as
		/// IMultisessionSequential, for importing file data from the previous session.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_lastwrittenaddressofprevioussession
		// HRESULT get_LastWrittenAddressOfPreviousSession( LONG *value );
		[DispId(268)]
		int LastWrittenAddressOfPreviousSession { get; }

		/// <summary>Determines if further additions to the file system are prevented.</summary>
		/// <value>
		/// <para>Set to VARIANT_TRUE to mark the disc as closed to prohibit additional writes when the next write session ends.</para>
		/// <para>Set to VARIANT_FALSE to keep the disc open for subsequent write sessions. The default is VARIANT_FALSE.</para>
		/// </value>
		/// <remarks>
		/// <para>
		/// When the free space on a disc reaches 2% or less, the write process marks the disc closed, regardless of the value of this
		/// property. This action ensures that a disc has enough free space to record a file system in a write session.
		/// </para>
		/// <para>You can erase a rewritable disc that is marked closed.</para>
		/// <para>
		/// Note that the IDiscFormat2Data::put_DisableConsumerDvdCompatibilityMode property may supersede this property. Please refer to
		/// <c>put_DisableConsumerDvdCompatibilityMode</c> for details.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-put_forcemediatobeclosed HRESULT
		// put_ForceMediaToBeClosed( VARIANT_BOOL value );
		[DispId(269)]
		bool ForceMediaToBeClosed { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Determines if a DVD recording session includes tasks that can increase the chance that a device can play the DVD.</summary>
		/// <value>
		/// <para>
		/// Set to VARIANT_TRUE to skip the tasks that allow the disc to play on more consumer devices. Removing compatibility reduces the
		/// recording session time and the need for less free space on disc.
		/// </para>
		/// <para>Set to VARIANT_FALSE to increase the chance that a device can play the DVD. The default is VARIANT_FALSE.</para>
		/// </value>
		/// <remarks>
		/// <para>This property has no affect on CD media and DVD dash media.</para>
		/// <para>For DVD+R and DVD+DL media, this property will also affect the media closing operation.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value of DisableConsumerDvdCompatibilityMode</term>
		/// <term>Value of ForceMediaToBeClosed</term>
		/// <term>Closure operation</term>
		/// </listheader>
		/// <item>
		/// <term>False</term>
		/// <term>True</term>
		/// <term>Closes the disc in compatible mode</term>
		/// </item>
		/// <item>
		/// <term>Fale</term>
		/// <term>False</term>
		/// <term>Closes the disc in compatible mode</term>
		/// </item>
		/// <item>
		/// <term>True</term>
		/// <term>True</term>
		/// <term>Closes the disc normally</term>
		/// </item>
		/// <item>
		/// <term>True</term>
		/// <term>False</term>
		/// <term>Closes the session for DVD+RCloses disc normally for DVD+R DL</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-put_disableconsumerdvdcompatibilitymode
		// HRESULT put_DisableConsumerDvdCompatibilityMode( VARIANT_BOOL value );
		[DispId(270)]
		bool DisableConsumerDvdCompatibilityMode { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the type of media in the disc device.</summary>
		/// <value>Type of media in the disc device. For possible values, see the IMAPI_MEDIA_PHYSICAL_TYPEenumeration type.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_currentphysicalmediatype HRESULT
		// get_CurrentPhysicalMediaType( IMAPI_MEDIA_PHYSICAL_TYPE *value );
		[DispId(271)]
		IMAPI_MEDIA_PHYSICAL_TYPE CurrentPhysicalMediaType { get; }

		/// <summary>Sets the friendly name of the client.</summary>
		/// <value>Name of the client application. Cannot be <c>NULL</c> or an empty string.</value>
		/// <remarks>
		/// <para>
		/// The name is used when the write operation requests exclusive access to the device. The IDiscRecorder2::get_ExclusiveAccessOwner
		/// property contains the name of the client that has the lock.
		/// </para>
		/// <para>
		/// Because any application with read/write access to the CDROM device during the write operation can use the
		/// IOCTL_CDROM_EXCLUSIVE_ACCESS (query) control code (see the Microsoft Windows Driver Development Kit (DDK)) to access the name,
		/// it is important that the name identify the program that is using this interface to write to the media. The name is restricted to
		/// the same character set as required by the IOCTL_CDROM_EXCLUSIVE_ACCESS control code.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-put_clientname HRESULT put_ClientName( BSTR
		// value );
		[DispId(272)]
		string ClientName { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>Retrieves the requested write speed.</summary>
		/// <value>
		/// <para>Requested write speed measured in disc sectors per second.</para>
		/// <para>A value of 0xFFFFFFFF (-1) requests that the write occurs using the fastest supported speed for the media.</para>
		/// </value>
		/// <remarks>This is the value specified in the most recent call to the IDiscFormat2Data::SetWriteSpeed method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_requestedwritespeed HRESULT
		// get_RequestedWriteSpeed( LONG *value );
		[DispId(273)]
		int RequestedWriteSpeed { get; }

		/// <summary>Retrieves the requested rotational-speed control type.</summary>
		/// <value>
		/// Requested rotational-speed control type. Is VARIANT_TRUE for constant angular velocity (CAV) rotational-speed control type.
		/// Otherwise, is VARIANT_FALSE for any other rotational-speed control type that the recorder supports.
		/// </value>
		/// <remarks>This is the value specified in the most recent call to the IDiscFormat2Data::SetWriteSpeed method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_requestedrotationtypeispurecav HRESULT
		// get_RequestedRotationTypeIsPureCAV( VARIANT_BOOL *value );
		[DispId(274)]
		bool RequestedRotationTypeIsPureCAV { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the drive's current write speed.</summary>
		/// <value>The write speed of the current media, measured in sectors per second.</value>
		/// <remarks>
		/// <para>To retrieve the requested write speed, call the IDiscFormat2Data::get_RequestedWriteSpeed method.</para>
		/// <para>
		/// To retrieve a list of the write speeds that the recorder and current media supports, call the
		/// IDiscFormat2Data::get_SupportedWriteSpeeds method.
		/// </para>
		/// <para>
		/// Note that the write speed is based on the media write speeds. The value of this property can change when a media change occurs.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_currentwritespeed HRESULT
		// get_CurrentWriteSpeed( LONG *value );
		[DispId(275)]
		int CurrentWriteSpeed { get; }

		/// <summary>Retrieves the current rotational-speed control used by the recorder.</summary>
		/// <value>
		/// Is VARIANT_TRUE if constant angular velocity (CAV) rotational-speed control is in use. Otherwise, VARIANT_FALSE to indicate that
		/// another rotational-speed control that the recorder supports is in use.
		/// </value>
		/// <remarks>
		/// <para>To retrieve the requested rotational-speed control, call the IDiscFormat2Data::get_RequestedRotationTypeIsPureCAV method.</para>
		/// <para>Rotational-speed control types include the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>CLV (Constant Linear Velocity). The disc is written at a constant speed. Standard rotational control.</term>
		/// </item>
		/// <item>
		/// <term>CAV (Constant Angular Velocity). The disc is written at a constantly increasing speed.</term>
		/// </item>
		/// <item>
		/// <term>
		/// ZCAV (Zone Constant Linear Velocity). The disc is divided into zones. After each zone, the write speed increases. This is an
		/// impure form of CAV.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// PCAV (Partial Constant Angular Velocity). The disc speed increases up to a specified velocity. Once reached, the disc spins at
		/// the specified velocity for the duration of the disc writing.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_currentrotationtypeispurecav HRESULT
		// get_CurrentRotationTypeIsPureCAV( VARIANT_BOOL *value );
		[DispId(276)]
		bool CurrentRotationTypeIsPureCAV { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves a list of the write speeds supported by the disc recorder and current media.</summary>
		/// <value>
		/// List of the write speeds supported by the disc recorder and current media. Each element of the array is a <c>VARIANT</c> of type
		/// <c>VT_UI4</c>. The <c>ulVal</c> member of the variant contains the number of sectors written per second.
		/// </value>
		/// <remarks>
		/// <para>You can use a speed from the list to set the write speed when calling the IDiscFormat2Data::SetWriteSpeed method.</para>
		/// <para>
		/// To retrieve a list of the write configurations that the recorder and current media supports, call the
		/// IDiscFormat2Data::get_SupportedWriteSpeedDescriptors method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_supportedwritespeeds HRESULT
		// get_SupportedWriteSpeeds( SAFEARRAY **supportedSpeeds );
		[DispId(277)]
		uint[] SupportedWriteSpeeds { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<uint>))] get; }

		/// <summary>Retrieves a list of the detailed write configurations supported by the disc recorder and current media.</summary>
		/// <value>
		/// List of the detailed write configurations supported by the disc recorder and current media. Each element of the array is a
		/// <c>VARIANT</c> of type <c>VT_Dispatch</c>. Query the <c>pdispVal</c> member of the variant for the IWriteSpeedDescriptor
		/// interface, which contains the media type, write speed, rotational-speed control type.
		/// </value>
		/// <remarks>
		/// To retrieve a list of the write speeds that the recorder and current media supports, call the
		/// IDiscFormat2Data::get_SupportedWriteSpeeds method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_supportedwritespeeddescriptors HRESULT
		// get_SupportedWriteSpeedDescriptors( SAFEARRAY **supportedSpeedDescriptors );
		[DispId(278)]
		IWriteSpeedDescriptor[] SupportedWriteSpeedDescriptors { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IWriteSpeedDescriptor>))] get; }

		/// <summary>Determines if the data writer must overwrite the disc on overwritable media types.</summary>
		/// <value>
		/// Is VARIANT_TRUE if the data writer must overwrite the disc on overwritable media types; otherwise, VARIANT_FALSE. The default is VARIANT_FALSE.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-put_forceoverwrite HRESULT
		// put_ForceOverwrite( VARIANT_BOOL value );
		[DispId(279)]
		bool ForceOverwrite { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves a list of available multi-session interfaces.</summary>
		/// <value>
		/// List of available multi-session interfaces. Each element of the array is a <c>VARIANT</c> of type <c>VT_DISPATCH</c>. Query the
		/// <c>pdispVal</c> member of the variant for any interface that inherits from IMultisession interface, for example, IMultisessionSequential.
		/// </value>
		/// <remarks>The array will always contain at least one element.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_multisessioninterfaces HRESULT
		// get_MultisessionInterfaces( SAFEARRAY **value );
		[DispId(280)]
		object[] MultisessionInterfaces { get; }

		/// <summary>Writes the data stream to the device.</summary>
		/// <param name="data">An <c>IStream</c> interface of the data stream to write.</param>
		/// <remarks>
		/// <para>Before calling this method, you must call the following methods:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IDiscFormat2Data::put_Recorder</term>
		/// </item>
		/// <item>
		/// <term>IDiscFormat2Data::put_ClientName</term>
		/// </item>
		/// </list>
		/// <para>You should also consider calling the following methods if their default values are not appropriate for your application:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IDiscFormat2Data::put_BufferUnderrunFreeDisabled</term>
		/// </item>
		/// <item>
		/// <term>IDiscFormat2Data::put_DisableConsumerDvdCompatibilityMode</term>
		/// </item>
		/// <item>
		/// <term>IDiscFormat2Data::put_ForceMediaToBeClosed</term>
		/// </item>
		/// <item>
		/// <term>IDiscFormat2Data::put_ForceOverwrite</term>
		/// </item>
		/// <item>
		/// <term>IDiscFormat2Data::put_PostgapAlreadyInImage</term>
		/// </item>
		/// <item>
		/// <term>IDiscFormat2Data::SetWriteSpeed</term>
		/// </item>
		/// </list>
		/// <para>
		/// This method is synchronous, which means that control is not returned until the provided <c>IStream</c> is recorded to the media.
		/// To determine the progress of the write operation, you must implement the DDiscFormat2DataEvents interface. For examples that
		/// show how to implement an event handler in a script, see Monitoring Progress With Events.
		/// </para>
		/// <para>
		/// On sequentially recorded discs, the provided IStream is recorded as a new session. On rewritable discs, the provided
		/// <c>IStream</c> is always recorded starting from sector 0, but the object providing the <c>IStream</c> interface can also provide
		/// the IBlockRangeList interface listing the sectors that need to be recorded. The <c>IBlockRangeList</c> interface is used to
		/// avoid rewriting of sectors that have not changed in multisession scenarios. If the object providing <c>IStream</c> does not
		/// provide <c>IBlockRangeList</c>, it is assumed that the entire <c>IStream</c> needs to be recorded.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-write HRESULT Write( IStream *data );
		[DispId(512)]
		void Write([In, MarshalAs(UnmanagedType.Interface)] IStream data);

		/// <summary>Cancels the current write operation.</summary>
		/// <remarks>
		/// <para>
		/// To cancel the write operation, you must call this method from the DDiscFormat2DataEvents::Update event handler that you implemented.
		/// </para>
		/// <para>
		/// Note that calling this method does not immediately cancel the write operation on all media due to media-specific requirements.
		/// For example, when writing to a CD, the write operation can continue for up to three more minutes.
		/// </para>
		/// <para>
		/// This method leaves the media in an indeterminate state. For rewriteable media, you should call the IDiscFormat2Erase::EraseMedia
		/// method after calling this method to prepare the media for future use.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-cancelwrite HRESULT CancelWrite();
		[DispId(513)]
		void CancelWrite();

		/// <summary>Sets the write speed of the disc recorder.</summary>
		/// <param name="RequestedSectorsPerSecond">
		/// <para>Requested write speed measured in disc sectors per second.</para>
		/// <para>
		/// A value of 0xFFFFFFFF (-1) requests that the write occurs using the fastest supported speed for the media. This is the default.
		/// </para>
		/// </param>
		/// <param name="RotationTypeIsPureCAV">
		/// Requested rotational-speed control type. Set to VARIANT_TRUE to request constant angular velocity (CAV) rotational-speed control
		/// type. Set to VARIANT_FALSE to use another rotational-speed control type that the recorder supports. The default is VARIANT_FALSE.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method sets the write speed and type of rotational-speed control for a recorder. Requested values might differ from the
		/// values set in the recorder. To specify the recorder, call the IDiscFormat2Data::put_Recorder method.
		/// </para>
		/// <para>
		/// If the recorder supports the requested write speed, the disc device uses the requested value. If the recorder does not support
		/// the requested write speed, the recorder uses a write speed that it does support that is closest to the requested value. The
		/// IDiscFormat2Data::get_CurrentWriteSpeed property contains the value used by the recorder.
		/// </para>
		/// <para>
		/// To retrieve a list of the write speeds that the recorder and current media supports, call the
		/// IDiscFormat2Data::get_SupportedWriteSpeeds method.
		/// </para>
		/// <para>
		/// If you request constant angular velocity (CAV) for rotational-speed control type and the recorder does not support CAV, the disc
		/// device uses another type of rotational-speed control type that it supports. The
		/// IDiscFormat2Data::get_CurrentRotationTypeIsPureCAV property indicates the value used by the recorder.
		/// </para>
		/// <para>
		/// To retrieve the requested values, call the IDiscFormat2Data::get_RequestedWriteSpeed and
		/// IDiscFormat2Data::get_RequestedRotationTypeIsPureCAV methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-setwritespeed HRESULT SetWriteSpeed( LONG
		// RequestedSectorsPerSecond, VARIANT_BOOL RotationTypeIsPureCAV );
		[DispId(514)]
		void SetWriteSpeed(int RequestedSectorsPerSecond, [In, MarshalAs(UnmanagedType.VariantBool)] bool RotationTypeIsPureCAV);
	}

	/// <summary>
	/// <para>Use this interface to retrieve information about the current write operation.</para>
	/// <para>This interface is passed to the DDiscFormat2DataEvents::Update method that you implement.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-idiscformat2dataeventargs
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IDiscFormat2DataEventArgs")]
	[ComImport, Guid("2735413D-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IDiscFormat2DataEventArgs : IWriteEngine2EventArgs
	{
		/// <summary>Retrieves the starting logical block address (LBA) of the current write operation.</summary>
		/// <value>Starting logical block address of the write operation. Negative values for LBAs are supported.</value>
		/// <remarks>This is the same value passed to the IWriteEngine2::WriteSection method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_startlba HRESULT get_StartLba(
		// LONG *value );
		[DispId(0x100)]
		new int StartLba { get; }

		/// <summary>Retrieves the number of sectors to write to the device in the current write operation.</summary>
		/// <value>The number of sectors to write in the current write operation.</value>
		/// <remarks>This is the same value passed to the IWriteEngine2::WriteSection method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_sectorcount HRESULT
		// get_SectorCount( LONG *value );
		[DispId(0x101)]
		new int SectorCount { get; }

		/// <summary>Retrieves the address of the sector most recently read from the burn image.</summary>
		/// <value>Logical block address of the sector most recently read from the input data stream.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_lastreadlba HRESULT
		// get_LastReadLba( LONG *value );
		[DispId(0x102)]
		new int LastReadLba { get; }

		/// <summary>Retrieves the address of the sector most recently written to the device.</summary>
		/// <value>Logical block address of the sector most recently written to the device.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_lastwrittenlba HRESULT
		// get_LastWrittenLba( LONG *value );
		[DispId(0x103)]
		new int LastWrittenLba { get; }

		/// <summary>Retrieves the size of the internal data buffer that is used for writing to disc.</summary>
		/// <value>Size, in bytes, of the internal data buffer that is used for writing to disc.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_totalsystembuffer HRESULT
		// get_TotalSystemBuffer( LONG *value );
		[DispId(0x106)]
		new int TotalSystemBuffer { get; }

		/// <summary>Retrieves the number of used bytes in the internal data buffer that is used for writing to disc.</summary>
		/// <value>Size, in bytes, of the used portion of the internal data buffer that is used for writing to disc.</value>
		/// <remarks>This value increases as data is read into the buffer and decreases as data is written to disc.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_usedsystembuffer HRESULT
		// get_UsedSystemBuffer( LONG *value );
		[DispId(0x107)]
		new int UsedSystemBuffer { get; }

		/// <summary>Retrieves the number of unused bytes in the internal data buffer that is used for writing to disc.</summary>
		/// <value>Size, in bytes, of the unused portion of the internal data buffer that is used for writing to disc.</value>
		/// <remarks>This method returns the same value as if you subtracted IWriteEngine2EventArgs::get_UsedSystemBuffer from IWriteEngine2EventArgs::get_TotalSystemBuffer.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_freesystembuffer HRESULT
		// get_FreeSystemBuffer( LONG *value );
		[DispId(0x108)]
		new int FreeSystemBuffer { get; }

		/// <summary>Retrieves the total elapsed time of the write operation.</summary>
		/// <value>Elapsed time, in seconds, of the write operation.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2dataeventargs-get_elapsedtime HRESULT
		// get_ElapsedTime( LONG *value );
		[DispId(768)]
		int ElapsedTime { get; }

		/// <summary>Retrieves the estimated remaining time of the write operation.</summary>
		/// <value>Estimated time, in seconds, needed for the remainder of the write operation.</value>
		/// <remarks>
		/// The estimate for a single write operation can vary as the operation progresses. The drive provides updated information that can
		/// affect the projected duration of the write operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2dataeventargs-get_remainingtime HRESULT
		// get_RemainingTime( LONG *value );
		[DispId(769)]
		int RemainingTime { get; }

		/// <summary>Retrieves the estimated total time for write operation.</summary>
		/// <value>Estimated time, in seconds, for write operation.</value>
		/// <remarks>
		/// The estimate for a single write operation can vary as the operation progresses. The drive provides updated information that can
		/// affect the projected duration of the write operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2dataeventargs-get_totaltime HRESULT
		// get_TotalTime( LONG *value );
		[DispId(770)]
		int TotalTime { get; }

		/// <summary>Retrieves the current write action being performed.</summary>
		/// <value>
		/// Current write action being performed. For a list of possible actions, see the IMAPI_FORMAT2_DATA_WRITE_ACTION enumeration type.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2dataeventargs-get_currentaction HRESULT
		// get_CurrentAction( IMAPI_FORMAT2_DATA_WRITE_ACTION *value );
		[DispId(771)]
		IMAPI_FORMAT2_DATA_WRITE_ACTION CurrentAction { get; }
	}

	/// <summary>
	/// <para>Use this interface to erase data from a disc.</para>
	/// <para>
	/// To create an instance of this interface, call the <c>CoCreateInstance</c> function. Use__uuidof(MsftDiscFormat2Erase) for the class
	/// identifier and __uuidof(IDiscFormat2Erase) for the interface identifier.
	/// </para>
	/// </summary>
	/// <remarks>
	/// To create the <c>MsftDiscFormat2Erase</c> object in a script, use IMAPI2.MsftDiscFormat2Erase as the program identifier when calling <c>CreateObject</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-idiscformat2erase
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IDiscFormat2Erase")]
	[ComImport, Guid("27354156-8F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftDiscFormat2Erase))]
	public interface IDiscFormat2Erase : IDiscFormat2
	{
		/// <summary>Determines if the recorder supports the given format.</summary>
		/// <param name="recorder">An IDiscRecorder2 interface of the recorder to test.</param>
		/// <returns>Is VARIANT_TRUE if the recorder supports the given format; otherwise, VARIANT_FALSE.</returns>
		/// <remarks>
		/// When implemented by the IDiscFormat2RawCD interface, this method will return E_IMAPI_DF2RAW_MEDIA_IS_NOT_SUPPORTED in the event
		/// the recorder does not support the given format. It is important to note that in this specific scenario the value does not
		/// indicate that an error has occurred, but rather the result of a successful operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-isrecordersupported HRESULT IsRecorderSupported(
		// IDiscRecorder2 *recorder, VARIANT_BOOL *value );
		[DispId(2048)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		new bool IsRecorderSupported(IDiscRecorder2 recorder);

		/// <summary>Determines if the current media in a supported recorder supports the given format.</summary>
		/// <param name="recorder">An IDiscRecorder2 interface of the recorder to test.</param>
		/// <returns>
		/// <para>Is VARIANT_TRUE if the media in the recorder supports the given format; otherwise, VARIANT_FALSE.</para>
		/// <para><c>Note</c> VARIANT_TRUE also implies that the result from IsDiscRecorderSupported is VARIANT_TRUE.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-iscurrentmediasupported HRESULT
		// IsCurrentMediaSupported( IDiscRecorder2 *recorder, VARIANT_BOOL *value );
		[DispId(2049)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		new bool IsCurrentMediaSupported(IDiscRecorder2 recorder);

		/// <summary>Determines if the current media is reported as physically blank by the drive.</summary>
		/// <value>Is VARIANT_TRUE if the disc is physically blank; otherwise, VARIANT_FALSE.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-get_mediaphysicallyblank HRESULT
		// get_MediaPhysicallyBlank( VARIANT_BOOL *value );
		[DispId(1792)]
		new bool MediaPhysicallyBlank { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Attempts to determine if the media is blank using heuristics (mainly for DVD+RW and DVD-RAM media).</summary>
		/// <value>Is VARIANT_TRUE if the disc is likely to be blank; otherwise; VARIANT_FALSE.</value>
		/// <remarks>
		/// <para>
		/// This method checks, for example, for a mounted file system on the device, verifying the first and last 2MB of the disc are
		/// filled with zeros, and other media-specific checks. These checks can help to determine if the media may have files on it for
		/// media that cannot be erased physically to a blank status.
		/// </para>
		/// <para>For a positive check that a disc is blank, call the IDiscFormat2::get_MediaPhysicallyBlank method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-get_mediaheuristicallyblank HRESULT
		// get_MediaHeuristicallyBlank( VARIANT_BOOL *value );
		[DispId(1793)]
		new bool MediaHeuristicallyBlank { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the media types that are supported by the current implementation of the IDiscFormat2 interface.</summary>
		/// <value>
		/// List of media types supported by the current implementation of the IDiscFormat2 interface. Each element of the array is a
		/// <c>VARIANT</c> of type <c>VT_I4</c>. The <c>lVal</c> member of <c>VARIANT</c> contains the media type. For a list of media
		/// types, see the IMAPI_MEDIA_PHYSICAL_TYPE enumeration type.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-get_supportedmediatypes HRESULT
		// get_SupportedMediaTypes( SAFEARRAY **value );
		[DispId(1794)]
		new IMAPI_MEDIA_PHYSICAL_TYPE[] SupportedMediaTypes { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IMAPI_MEDIA_PHYSICAL_TYPE>))] get; }

		/// <summary>Sets the recording device to use in the erase operation.</summary>
		/// <value>An IDiscRecorder2 interface that identifies the recording device to use in the erase operation.</value>
		/// <remarks>
		/// The recorder must be compatible with the format defined by this interface. To determine compatibility, call the
		/// IDiscFormat2::IsRecorderSupported method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2erase-put_recorder HRESULT put_Recorder(
		// IDiscRecorder2 *value );
		[DispId(0x100)]
		IDiscRecorder2 Recorder { set; [return: MarshalAs(UnmanagedType.Interface)] get; }

		/// <summary>Determines the quality of the disc erasure.</summary>
		/// <value>
		/// <para>Set to VARIANT_TRUE to fully erase the disc by overwriting the entire medium at least once.</para>
		/// <para>
		/// Set to VARIANT_FALSE to overwrite the directory tracks, but not the entire disc. This option requires less time to perform than
		/// the full erase option.
		/// </para>
		/// <para>The default is VARIANT_FALSE.</para>
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2erase-put_fullerase HRESULT put_FullErase(
		// VARIANT_BOOL value );
		[DispId(0x101)]
		bool FullErase { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the type of media in the disc device.</summary>
		/// <value>Type of media in the disc device. For possible values, see the IMAPI_MEDIA_PHYSICAL_TYPEenumeration type.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2erase-get_currentphysicalmediatype HRESULT
		// get_CurrentPhysicalMediaType( IMAPI_MEDIA_PHYSICAL_TYPE *value );
		[DispId(0x102)]
		IMAPI_MEDIA_PHYSICAL_TYPE CurrentPhysicalMediaType { get; }

		/// <summary>Sets the friendly name of the client.</summary>
		/// <value>Name of the client application.</value>
		/// <remarks>
		/// <para>
		/// The name is used when the write operation requests exclusive access to the device. The IDiscRecorder2::get_ExclusiveAccessOwner
		/// property contains the name of the client that has the lock.
		/// </para>
		/// <para>
		/// Because any application with read/write access to the CDROM device during the erase operation can use the
		/// IOCTL_CDROM_EXCLUSIVE_ACCESS (query) control code (see the Microsoft Windows Driver Development Kit (DDK)) to access the name,
		/// it is important that the name identify the program that is using this interface to erase to the media. The name is restricted to
		/// the same character set as required by the IOCTL_CDROM_EXCLUSIVE_ACCESS control code.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2erase-put_clientname HRESULT put_ClientName( BSTR
		// value );
		[DispId(0x103)]
		string ClientName { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>Erases the media in the active disc recorder.</summary>
		/// <remarks>
		/// <para>Synchronously erases the media. Progress can be reported by calling into registered events of type DDiscFormat2EraseEvents.</para>
		/// <para>Before calling this method, you must call the following methods:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IDiscFormat2Erase::put_Recorder</term>
		/// </item>
		/// <item>
		/// <term>IDiscFormat2Erase::put_ClientName</term>
		/// </item>
		/// </list>
		/// <para>
		/// You should also consider calling the IDiscFormat2Erase::put_FullErase method if its default value is not appropriate for your application.
		/// </para>
		/// <para>
		/// This method is synchronous. To determine the progress of the erase operation, you must implement the DDiscFormat2EraseEvents
		/// interface. For examples that show how to implement an event handler in a script, see Monitoring Progress With Events.
		/// </para>
		/// <para>
		/// Currently, the E_IMAPI_ERASE_TOOK_LONGER_THAN_ONE_HOUR value is returned if an attempt to perform an erase on CD-RW or DVD-RW
		/// media via the IDiscFormat2Erase interface fails as a result of the media being bad or a drive failure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2erase-erasemedia HRESULT EraseMedia();
		[DispId(0x201)]
		void EraseMedia();
	}

	/// <summary>
	/// <para>
	/// Use this interface to write raw images to a disc device using Disc At Once (DAO) mode (also known as uninterrupted recording). For
	/// information on DAO mode, see the latest revision of the MMC specification at ftp://ftp.t10.org/t10/drafts/mmc5.
	/// </para>
	/// <para>
	/// To create an instance of this interface, call the <c>CoCreateInstance</c> function. Use__uuidof(MsftDiscFormat2RawCD) for the class
	/// identifier and __uuidof(IDiscFormat2RawCD) for the interface identifier.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// To create the <c>MsftDiscFormat2RawCD</c> object in a script, use IMAPI2.MsftDiscFormat2RawCD as the program identifier when calling <c>CreateObject</c>.
	/// </para>
	/// <para>
	/// It is possible for a power state transition to take place during a burn operation (i.e. user log-off or system suspend) which leads
	/// to the interruption of the burn process and possible data loss. For programming considerations, see Preventing Logoff or Suspend
	/// During a Burn.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-idiscformat2rawcd
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IDiscFormat2RawCD")]
	[ComImport, Guid("27354155-8F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftDiscFormat2RawCD))]
	public interface IDiscFormat2RawCD : IDiscFormat2
	{
		/// <summary>Determines if the recorder supports the given format.</summary>
		/// <param name="recorder">An IDiscRecorder2 interface of the recorder to test.</param>
		/// <returns>Is VARIANT_TRUE if the recorder supports the given format; otherwise, VARIANT_FALSE.</returns>
		/// <remarks>
		/// When implemented by the IDiscFormat2RawCD interface, this method will return E_IMAPI_DF2RAW_MEDIA_IS_NOT_SUPPORTED in the event
		/// the recorder does not support the given format. It is important to note that in this specific scenario the value does not
		/// indicate that an error has occurred, but rather the result of a successful operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-isrecordersupported HRESULT IsRecorderSupported(
		// IDiscRecorder2 *recorder, VARIANT_BOOL *value );
		[DispId(2048)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		new bool IsRecorderSupported(IDiscRecorder2 recorder);

		/// <summary>Determines if the current media in a supported recorder supports the given format.</summary>
		/// <param name="recorder">An IDiscRecorder2 interface of the recorder to test.</param>
		/// <returns>
		/// <para>Is VARIANT_TRUE if the media in the recorder supports the given format; otherwise, VARIANT_FALSE.</para>
		/// <para><c>Note</c> VARIANT_TRUE also implies that the result from IsDiscRecorderSupported is VARIANT_TRUE.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-iscurrentmediasupported HRESULT
		// IsCurrentMediaSupported( IDiscRecorder2 *recorder, VARIANT_BOOL *value );
		[DispId(2049)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		new bool IsCurrentMediaSupported(IDiscRecorder2 recorder);

		/// <summary>Determines if the current media is reported as physically blank by the drive.</summary>
		/// <value>Is VARIANT_TRUE if the disc is physically blank; otherwise, VARIANT_FALSE.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-get_mediaphysicallyblank HRESULT
		// get_MediaPhysicallyBlank( VARIANT_BOOL *value );
		[DispId(1792)]
		new bool MediaPhysicallyBlank { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Attempts to determine if the media is blank using heuristics (mainly for DVD+RW and DVD-RAM media).</summary>
		/// <value>Is VARIANT_TRUE if the disc is likely to be blank; otherwise; VARIANT_FALSE.</value>
		/// <remarks>
		/// <para>
		/// This method checks, for example, for a mounted file system on the device, verifying the first and last 2MB of the disc are
		/// filled with zeros, and other media-specific checks. These checks can help to determine if the media may have files on it for
		/// media that cannot be erased physically to a blank status.
		/// </para>
		/// <para>For a positive check that a disc is blank, call the IDiscFormat2::get_MediaPhysicallyBlank method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-get_mediaheuristicallyblank HRESULT
		// get_MediaHeuristicallyBlank( VARIANT_BOOL *value );
		[DispId(1793)]
		new bool MediaHeuristicallyBlank { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the media types that are supported by the current implementation of the IDiscFormat2 interface.</summary>
		/// <value>
		/// List of media types supported by the current implementation of the IDiscFormat2 interface. Each element of the array is a
		/// <c>VARIANT</c> of type <c>VT_I4</c>. The <c>lVal</c> member of <c>VARIANT</c> contains the media type. For a list of media
		/// types, see the IMAPI_MEDIA_PHYSICAL_TYPE enumeration type.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-get_supportedmediatypes HRESULT
		// get_SupportedMediaTypes( SAFEARRAY **value );
		[DispId(1794)]
		new IMAPI_MEDIA_PHYSICAL_TYPE[] SupportedMediaTypes { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IMAPI_MEDIA_PHYSICAL_TYPE>))] get; }

		/// <summary>Locks the current media for exclusive access.</summary>
		/// <remarks>
		/// <para>Before calling this method, you must call the IDiscFormat2RawCD::put_ClientName method.</para>
		/// <para>
		/// Also, you must call the <c>IDiscFormat2RawCD::PrepareMedia</c> method before calling either the IDiscFormat2RawCD::WriteMedia or
		/// IDiscFormat2RawCD::WriteMedia2 method.
		/// </para>
		/// <para>
		/// After the write is complete or you cancel the write operation, you must call the IDiscFormat2RawCD::ReleaseMedia method to
		/// release the lock.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-preparemedia HRESULT PrepareMedia();
		[DispId(0x200)]
		void PrepareMedia();

		/// <summary>Writes a DAO-96 raw image to the blank media using MSF 95:00:00 as the starting address.</summary>
		/// <param name="data">An <c>IStream</c> interface of the data stream to write.</param>
		/// <remarks>
		/// <para>Before calling this method, you must call the IDiscFormat2RawCD::put_Recorder and IDiscFormat2RawCD::PrepareMedia methods.</para>
		/// <para>You should also consider calling the following methods if their default values are not appropriate for your application:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IDiscFormat2RawCD::put_BufferUnderrunFreeDisabled</term>
		/// </item>
		/// <item>
		/// <term>IDiscFormat2RawCD::put_ClientName</term>
		/// </item>
		/// <item>
		/// <term>IDiscFormat2RawCD::put_RequestedSectorType</term>
		/// </item>
		/// <item>
		/// <term>IDiscFormat2RawCD::SetWriteSpeed</term>
		/// </item>
		/// </list>
		/// <para>
		/// This method is synchronous. To determine the progress of the write operation, you must implement the DDiscFormat2RawCDEvents
		/// interface. For examples that show how to implement an event handler in a script, see Monitoring Progress With Events.
		/// </para>
		/// <para>
		/// The first sector of the raw image is written at MSF 95:00:00. If your RAW image has a different first sector, please use the
		/// IDiscFormat2RawCD::WriteMedia2 method.
		/// </para>
		/// <para>
		/// This method uses the <c>IStream::Seek</c> method to reach the appropriate starting location in the image for the current media.
		/// If the <c>IStream::Seek</c> method fails, the method will call the <c>IStream::Read</c> method repeatedly until reaching the
		/// starting sector.
		/// </para>
		/// <para>
		/// The DAO-96 standard allows writing of any type of data to CD media. One common usage is to write audio CDs without a 2-second
		/// gap between tracks.
		/// </para>
		/// <para>DAO-96 also supports variations in the subcode content, such as CD+G and CD-Text.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-writemedia HRESULT WriteMedia( IStream
		// *data );
		[DispId(0x201)]
		void WriteMedia(IStream data);

		/// <summary>Writes a DAO-96 raw image to the blank media using a specified starting address.</summary>
		/// <param name="data">An <c>IStream</c> interface of the data stream to write.</param>
		/// <param name="streamLeadInSectors">Starting address at which to begin writing the data stream.</param>
		/// <remarks>
		/// This method is identical in function to the <c>IDiscFormat2RawCD::WriteMedia</c> method, except that it allows for a starting
		/// time other than 95:00:00. For details, please see the IDiscFormat2RawCD::WriteMedia method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-writemedia2 HRESULT WriteMedia2( IStream
		// *data, LONG streamLeadInSectors );
		[DispId(0x202)]
		void WriteMedia2(IStream data, int streamLeadInSectors);

		/// <summary>Cancels the current write operation.</summary>
		/// <remarks>
		/// <para>
		/// To cancel the write operation, you must call this method from the DDiscFormat2RawCDEvents::Update event handler that you implemented.
		/// </para>
		/// <para>You must also call the IDiscFormat2RawCD::ReleaseMedia method after calling this method.</para>
		/// <para>
		/// Note that calling this method does not immediately cancel the write operation on all media due to media-specific requirements.
		/// For example, when writing to a CD, the write operation can continue for up to three more minutes.
		/// </para>
		/// <para>
		/// This method leaves the media in an indeterminate state. For rewriteable media, you should call the IDiscFormat2Erase::EraseMedia
		/// method after calling this method to prepare the media for future use.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-cancelwrite HRESULT CancelWrite();
		[DispId(0x203)]
		void CancelWrite();

		/// <summary>Closes a Disc-At-Once (DAO) writing session of a raw image and releases the lock.</summary>
		/// <remarks>
		/// This method release the lock set when you called the IDiscFormat2RawCD::PrepareMedia method. You must call this method after the
		/// write operation completes or after calling IDiscFormat2RawCD::CancelWrite to cancel a writing operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-releasemedia HRESULT ReleaseMedia();
		[DispId(0x204)]
		void ReleaseMedia();

		/// <summary>Sets the write speed of the disc recorder.</summary>
		/// <param name="RequestedSectorsPerSecond">
		/// <para>Requested write speed measured in disc sectors per second.</para>
		/// <para>
		/// A value of 0xFFFFFFFF (-1) requests that the write occurs using the fastest supported speed for the media. This is the default.
		/// </para>
		/// </param>
		/// <param name="RotationTypeIsPureCAV">
		/// Requested rotational-speed control type. Set to VARIANT_TRUE to request constant angular velocity (CAV) rotational-speed control
		/// type. Set to VARIANT_FALSE to use another rotational-speed control type that the recorder supports. The default is VARIANT_FALSE.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method sets the write speed and type of rotational-speed control for a recorder. Requested values might differ from the
		/// values set in the recorder. To specify the recorder, call the IDiscFormat2RawCD::put_Recorder method.
		/// </para>
		/// <para>
		/// If the recorder supports the requested write speed, the disc device uses the requested value. If the recorder does not support
		/// the requested write speed, the recorder uses a write speed that it does support that is closest to the requested value. The
		/// IDiscFormat2RawCD::get_CurrentWriteSpeed property contains the value used by the recorder.
		/// </para>
		/// <para>
		/// To retrieve a list of the write speeds that the recorder and current media supports, call the
		/// IDiscFormat2RawCD::get_SupportedWriteSpeeds method.
		/// </para>
		/// <para>
		/// If you request constant angular velocity (CAV) for rotational-speed control type and the recorder does not support CAV, the disc
		/// device uses another type of rotational-speed control type that it supports. The
		/// IDiscFormat2RawCD::get_CurrentRotationTypeIsPureCAV property indicates the value used by the recorder.
		/// </para>
		/// <para>
		/// To retrieve the requested values, call the IDiscFormat2RawCD::get_RequestedWriteSpeed and
		/// IDiscFormat2RawCD::get_RequestedRotationTypeIsPureCAV methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-setwritespeed HRESULT SetWriteSpeed( LONG
		// RequestedSectorsPerSecond, VARIANT_BOOL RotationTypeIsPureCAV );
		[DispId(0x205)]
		void SetWriteSpeed(int RequestedSectorsPerSecond, [MarshalAs(UnmanagedType.VariantBool)] bool RotationTypeIsPureCAV);

		/// <summary>Retrieves the recording device to use for the write operation.</summary>
		/// <value>An IDiscRecorder2 interface that identifies the recording device to use in the write operation.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-get_recorder HRESULT get_Recorder(
		// IDiscRecorder2 **value );
		[DispId(0x100)]
		IDiscRecorder2 Recorder { set; [return: MarshalAs(UnmanagedType.Interface)] get; }

		/// <summary>Determines if Buffer Underrun Free recording is enabled.</summary>
		/// <value>
		/// Set to VARIANT_TRUE to disable Buffer Underrun Free recording; otherwise, VARIANT_FALSE. The default is VARIANT_FALSE (enabled).
		/// </value>
		/// <remarks>
		/// Buffer underrun can be an issue if the data stream does not enter the buffer fast enough to keep the device continuously
		/// writing. In turn, the stop and start action of writing can cause data on the disc to be unusable. Buffer Underrun Free (BUF)
		/// recording allows the laser to start and stop without damaging data already written to the disc. Disabling of BUF recording is
		/// possible only on CD-R/RW media.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-put_bufferunderrunfreedisabled HRESULT
		// put_BufferUnderrunFreeDisabled( VARIANT_BOOL value );
		[DispId(0x102)]
		bool BufferUnderrunFreeDisabled { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the first sector of the next session.</summary>
		/// <value>Sector number for the start of the next write operation. This value can be negative for blank media.</value>
		/// <remarks>
		/// The client application that creates an image must provide appropriately sized lead-in and lead-out data. The application
		/// developer using the IDiscFormat2RawCD interface must understand the formats of lead-in and lead-out for the first and subsequent
		/// sessions. Note that lead-in LBA for the first session is negative.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-get_startofnextsession HRESULT
		// get_StartOfNextSession( LONG *value );
		[DispId(0x103)]
		int StartOfNextSession { get; }

		/// <summary>Retrieves the last possible starting position for the leadout area.</summary>
		/// <value>Sector address of the starting position for the leadout area.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-get_lastpossiblestartofleadout HRESULT
		// get_LastPossibleStartOfLeadout( LONG *value );
		[DispId(0x104)]
		int LastPossibleStartOfLeadout { get; }

		/// <summary>Retrieves the type of media in the disc device.</summary>
		/// <value>Type of media in the disc device. For possible values, see the IMAPI_MEDIA_PHYSICAL_TYPEenumeration type.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-get_currentphysicalmediatype HRESULT
		// get_CurrentPhysicalMediaType( IMAPI_MEDIA_PHYSICAL_TYPE *value );
		[DispId(0x105)]
		IMAPI_MEDIA_PHYSICAL_TYPE CurrentPhysicalMediaType { get; }

		/// <summary>Retrieves the supported data sector types for the current recorder.</summary>
		/// <value>
		/// <para>
		/// List of data sector types for the current recorder. Each element of the list is a <c>VARIANT</c> of type <c>VT_UI4</c>. The
		/// <c>ulVal</c> member of the variant contains the data sector type.
		/// </para>
		/// <para>For a list of values of supported sector types, see IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE.</para>
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-get_supportedsectortypes HRESULT
		// get_SupportedSectorTypes( SAFEARRAY **value );
		[DispId(0x108)]
		IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE[] SupportedSectorTypes { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE>))] get; }

		/// <summary>Sets the requested data sector to use for writing the stream.</summary>
		/// <value>
		/// Data sector to use for writing the stream. For possible values, see the IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE enumeration type.
		/// The default is <c>IMAPI_FORMAT2_RAW_CD_SUBCODE_IS_COOKED</c>.
		/// </value>
		/// <remarks>For a list of supported data sector types, call the IDiscFormat2RawCD::get_SupportedSectorTypes method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-put_requestedsectortype HRESULT
		// put_RequestedSectorType( IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE value );
		[DispId(0x109)]
		IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE RequestedSectorType { set; get; }

		/// <summary>Sets the friendly name of the client.</summary>
		/// <value>Name of the client application. Cannot be <c>NULL</c> or an empty string.</value>
		/// <remarks>
		/// <para>
		/// The name is used when the write operation requests exclusive access to the device. The IDiscRecorder2::get_ExclusiveAccessOwner
		/// property contains the name of the client that has the lock.
		/// </para>
		/// <para>
		/// Because any application with read/write access to the CDROM device during the write operation can use the
		/// IOCTL_CDROM_EXCLUSIVE_ACCESS (query) control code (see the Microsoft Windows Driver Development Kit (DDK)) to access the name,
		/// it is important that the name identify the program that is using this interface to write to the media. The name is restricted to
		/// the same character set as required by the IOCTL_CDROM_EXCLUSIVE_ACCESS control code.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-put_clientname HRESULT put_ClientName( BSTR
		// value );
		[DispId(0x10A)]
		string ClientName { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>Retrieves the requested write speed.</summary>
		/// <value>
		/// <para>Requested write speed measured in disc sectors per second.</para>
		/// <para>A value of 0xFFFFFFFF (-1) requests that the write occurs using the fastest supported speed for the media.</para>
		/// </value>
		/// <remarks>This is the value specified in the most recent call to the IDiscFormat2RawCD::SetWriteSpeed method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-get_requestedwritespeed HRESULT
		// get_RequestedWriteSpeed( LONG *value );
		[DispId(0x10B)]
		int RequestedWriteSpeed { get; }

		/// <summary>Retrieves the requested rotational-speed control type.</summary>
		/// <value>
		/// Requested rotational-speed control type. Is VARIANT_TRUE for constant angular velocity (CAV) rotational-speed control type.
		/// Otherwise, is VARIANT_FALSE for any other rotational-speed control type that the recorder supports.
		/// </value>
		/// <remarks>This is the value specified in the most recent call to the IDiscFormat2RawCD::SetWriteSpeed method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-get_requestedrotationtypeispurecav HRESULT
		// get_RequestedRotationTypeIsPureCAV( VARIANT_BOOL *value );
		[DispId(0x10C)]
		bool RequestedRotationTypeIsPureCAV { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the drive's current write speed.</summary>
		/// <value>The write speed of the current media, measured in sectors per second.</value>
		/// <remarks>
		/// <para>To retrieve the requested write speed, call the IDiscFormat2RawCD::get_RequestedWriteSpeed method.</para>
		/// <para>
		/// To retrieve a list of the write speeds that the recorder and current media supports, call the
		/// IDiscFormat2RawCD::get_SupportedWriteSpeeds method.
		/// </para>
		/// <para>
		/// Note that the write speed is based on the media write speeds. The value of this property can change when a media change occurs.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-get_currentwritespeed HRESULT
		// get_CurrentWriteSpeed( LONG *value );
		[DispId(0x10D)]
		int CurrentWriteSpeed { get; }

		/// <summary>Retrieves the current rotational-speed control used by the recorder.</summary>
		/// <value>
		/// Is VARIANT_TRUE if constant angular velocity (CAV) rotational-speed control is in use. Otherwise, VARIANT_FALSE to indicate that
		/// another rotational-speed control that the recorder supports is in use.
		/// </value>
		/// <remarks>
		/// <para>To retrieve the requested rotational-speed control, call the IDiscFormat2RawCD::get_RequestedRotationTypeIsPureCAV method.</para>
		/// <para>Rotational-speed control types include the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>CLV (Constant Linear Velocity). The disc is written at a constant speed. Standard rotational control.</term>
		/// </item>
		/// <item>
		/// <term>CAV (Constant Angular Velocity). The disc is written at a constantly increasing speed.</term>
		/// </item>
		/// <item>
		/// <term>
		/// ZCAV (Zone Constant Linear Velocity). The disc is divided into zones. After each zone, the write speed increases. This is an
		/// impure form of CAV.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// PCAV (Partial Constant Angular Velocity). The disc speed increases up to a specified velocity. Once reached, the disc spins at
		/// the specified velocity for the duration of the disc writing.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-get_currentrotationtypeispurecav HRESULT
		// get_CurrentRotationTypeIsPureCAV( VARIANT_BOOL *value );
		[DispId(0x10E)]
		bool CurrentRotationTypeIsPureCAV { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves a list of the write speeds supported by the disc recorder and current media.</summary>
		/// <value>
		/// List of the write speeds supported by the disc recorder and current media. Each element of the list is a <c>VARIANT</c> of type
		/// <c>VT_UI4</c>. The <c>ulVal</c> member of the variant contains the number of sectors written per second.
		/// </value>
		/// <remarks>
		/// <para>You can use a speed from the list to set the write speed when calling the IDiscFormat2RawCD::SetWriteSpeed method.</para>
		/// <para>
		/// To retrieve a list of the write configurations that the recorder and current media supports, call the
		/// IDiscFormat2RawCD::get_SupportedWriteSpeedDescriptors method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-get_supportedwritespeeds HRESULT
		// get_SupportedWriteSpeeds( SAFEARRAY **supportedSpeeds );
		[DispId(0x10F)]
		uint[] SupportedWriteSpeeds { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<uint>))] get; }

		/// <summary>Retrieves a list of the detailed write configurations supported by the disc recorder and current media.</summary>
		/// <value>
		/// List of the detailed write configurations supported by the disc recorder and current media. Each element of the list is a
		/// <c>VARIANT</c> of type <c>VT_Dispatch</c>. Query the <c>pdispVal</c> member of the variant for the IWriteSpeedDescriptor
		/// interface, which contains the media type, write speed, rotational-speed control type.
		/// </value>
		/// <remarks>
		/// To retrieve a list of the write speeds that the recorder and current media supports, call the
		/// IDiscFormat2RawCD::get_SupportedWriteSpeeds method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcd-get_supportedwritespeeddescriptors HRESULT
		// get_SupportedWriteSpeedDescriptors( SAFEARRAY **supportedSpeedDescriptors );
		[DispId(0x110)]
		IWriteSpeedDescriptor[] SupportedWriteSpeedDescriptors { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IWriteSpeedDescriptor>))] get; }
	}

	/// <summary>
	/// <para>Use this interface to retrieve information about the current write operation.</para>
	/// <para>This interface is passed to the DDiscFormat2RawCDEvents::Update method that you implement.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-idiscformat2rawcdeventargs
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IDiscFormat2RawCDEventArgs")]
	[ComImport, Guid("27354143-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IDiscFormat2RawCDEventArgs : IWriteEngine2EventArgs
	{
		/// <summary>Retrieves the starting logical block address (LBA) of the current write operation.</summary>
		/// <value>Starting logical block address of the write operation. Negative values for LBAs are supported.</value>
		/// <remarks>This is the same value passed to the IWriteEngine2::WriteSection method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_startlba HRESULT get_StartLba(
		// LONG *value );
		[DispId(0x100)]
		new int StartLba { get; }

		/// <summary>Retrieves the number of sectors to write to the device in the current write operation.</summary>
		/// <value>The number of sectors to write in the current write operation.</value>
		/// <remarks>This is the same value passed to the IWriteEngine2::WriteSection method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_sectorcount HRESULT
		// get_SectorCount( LONG *value );
		[DispId(0x101)]
		new int SectorCount { get; }

		/// <summary>Retrieves the address of the sector most recently read from the burn image.</summary>
		/// <value>Logical block address of the sector most recently read from the input data stream.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_lastreadlba HRESULT
		// get_LastReadLba( LONG *value );
		[DispId(0x102)]
		new int LastReadLba { get; }

		/// <summary>Retrieves the address of the sector most recently written to the device.</summary>
		/// <value>Logical block address of the sector most recently written to the device.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_lastwrittenlba HRESULT
		// get_LastWrittenLba( LONG *value );
		[DispId(0x103)]
		new int LastWrittenLba { get; }

		/// <summary>Retrieves the size of the internal data buffer that is used for writing to disc.</summary>
		/// <value>Size, in bytes, of the internal data buffer that is used for writing to disc.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_totalsystembuffer HRESULT
		// get_TotalSystemBuffer( LONG *value );
		[DispId(0x106)]
		new int TotalSystemBuffer { get; }

		/// <summary>Retrieves the number of used bytes in the internal data buffer that is used for writing to disc.</summary>
		/// <value>Size, in bytes, of the used portion of the internal data buffer that is used for writing to disc.</value>
		/// <remarks>This value increases as data is read into the buffer and decreases as data is written to disc.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_usedsystembuffer HRESULT
		// get_UsedSystemBuffer( LONG *value );
		[DispId(0x107)]
		new int UsedSystemBuffer { get; }

		/// <summary>Retrieves the number of unused bytes in the internal data buffer that is used for writing to disc.</summary>
		/// <value>Size, in bytes, of the unused portion of the internal data buffer that is used for writing to disc.</value>
		/// <remarks>This method returns the same value as if you subtracted IWriteEngine2EventArgs::get_UsedSystemBuffer from IWriteEngine2EventArgs::get_TotalSystemBuffer.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_freesystembuffer HRESULT
		// get_FreeSystemBuffer( LONG *value );
		[DispId(0x108)]
		new int FreeSystemBuffer { get; }

		/// <summary>Retrieves the current write action being performed.</summary>
		/// <value>
		/// Current write action being performed. For a list of possible actions, see the IMAPI_FORMAT2_RAW_CD_WRITE_ACTION enumeration type.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcdeventargs-get_currentaction HRESULT
		// get_CurrentAction( IMAPI_FORMAT2_RAW_CD_WRITE_ACTION *value );
		[DispId(0x301)]
		IMAPI_FORMAT2_RAW_CD_WRITE_ACTION CurrentAction { get; }

		/// <summary>Retrieves the total elapsed time of the write operation.</summary>
		/// <value>Elapsed time, in seconds, of the write operation.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcdeventargs-get_elapsedtime HRESULT
		// get_ElapsedTime( LONG *value );
		[DispId(0x302)]
		int ElapsedTime { get; }

		/// <summary>Retrieves the estimated remaining time of the write operation.</summary>
		/// <value>Estimated time, in seconds, needed for the remainder of the write operation.</value>
		/// <remarks>
		/// The estimate for a single write operation can vary as the operation progresses. The drive provides updated information that can
		/// affect the projected duration of the write operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2rawcdeventargs-get_remainingtime HRESULT
		// get_RemainingTime( LONG *value );
		[DispId(0x303)]
		int RemainingTime { get; }
	}

	/// <summary>
	/// <para>Use this interface to write audio to blank CD-R or CD-RW media in Track-At-Once mode.</para>
	/// <para>
	/// To create an instance of this interface, call the <c>CoCreateInstance</c> function. Use__uuidof(MsftDiscFormat2TrackAtOnce) for the
	/// class identifier and __uuidof(IDiscFormat2TrackAtOnce) for the interface identifier.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// To create the <c>MsftDiscFormat2TrackAtOnce</c> object in a script, use IMAPI2.MsftDiscFormat2TrackAtOnce as the program identifier
	/// when calling <c>CreateObject</c>.
	/// </para>
	/// <para>
	/// It is possible for a power state transition to take place during a burn operation (i.e. user log-off or system suspend) which leads
	/// to the interruption of the burn process and possible data loss. For programming considerations, see Preventing Logoff or Suspend
	/// During a Burn.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-idiscformat2trackatonce
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IDiscFormat2TrackAtOnce")]
	[ComImport, Guid("27354154-8F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftDiscFormat2TrackAtOnce))]
	public interface IDiscFormat2TrackAtOnce : IDiscFormat2
	{
		/// <summary>Determines if the recorder supports the given format.</summary>
		/// <param name="recorder">An IDiscRecorder2 interface of the recorder to test.</param>
		/// <returns>Is VARIANT_TRUE if the recorder supports the given format; otherwise, VARIANT_FALSE.</returns>
		/// <remarks>
		/// When implemented by the IDiscFormat2RawCD interface, this method will return E_IMAPI_DF2RAW_MEDIA_IS_NOT_SUPPORTED in the event
		/// the recorder does not support the given format. It is important to note that in this specific scenario the value does not
		/// indicate that an error has occurred, but rather the result of a successful operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-isrecordersupported HRESULT IsRecorderSupported(
		// IDiscRecorder2 *recorder, VARIANT_BOOL *value );
		[DispId(2048)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		new bool IsRecorderSupported(IDiscRecorder2 recorder);

		/// <summary>Determines if the current media in a supported recorder supports the given format.</summary>
		/// <param name="recorder">An IDiscRecorder2 interface of the recorder to test.</param>
		/// <returns>
		/// <para>Is VARIANT_TRUE if the media in the recorder supports the given format; otherwise, VARIANT_FALSE.</para>
		/// <para><c>Note</c> VARIANT_TRUE also implies that the result from IsDiscRecorderSupported is VARIANT_TRUE.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-iscurrentmediasupported HRESULT
		// IsCurrentMediaSupported( IDiscRecorder2 *recorder, VARIANT_BOOL *value );
		[DispId(2049)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		new bool IsCurrentMediaSupported(IDiscRecorder2 recorder);

		/// <summary>Determines if the current media is reported as physically blank by the drive.</summary>
		/// <value>Is VARIANT_TRUE if the disc is physically blank; otherwise, VARIANT_FALSE.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-get_mediaphysicallyblank HRESULT
		// get_MediaPhysicallyBlank( VARIANT_BOOL *value );
		[DispId(1792)]
		new bool MediaPhysicallyBlank { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Attempts to determine if the media is blank using heuristics (mainly for DVD+RW and DVD-RAM media).</summary>
		/// <value>Is VARIANT_TRUE if the disc is likely to be blank; otherwise; VARIANT_FALSE.</value>
		/// <remarks>
		/// <para>
		/// This method checks, for example, for a mounted file system on the device, verifying the first and last 2MB of the disc are
		/// filled with zeros, and other media-specific checks. These checks can help to determine if the media may have files on it for
		/// media that cannot be erased physically to a blank status.
		/// </para>
		/// <para>For a positive check that a disc is blank, call the IDiscFormat2::get_MediaPhysicallyBlank method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-get_mediaheuristicallyblank HRESULT
		// get_MediaHeuristicallyBlank( VARIANT_BOOL *value );
		[DispId(1793)]
		new bool MediaHeuristicallyBlank { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the media types that are supported by the current implementation of the IDiscFormat2 interface.</summary>
		/// <value>
		/// List of media types supported by the current implementation of the IDiscFormat2 interface. Each element of the array is a
		/// <c>VARIANT</c> of type <c>VT_I4</c>. The <c>lVal</c> member of <c>VARIANT</c> contains the media type. For a list of media
		/// types, see the IMAPI_MEDIA_PHYSICAL_TYPE enumeration type.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-get_supportedmediatypes HRESULT
		// get_SupportedMediaTypes( SAFEARRAY **value );
		[DispId(1794)]
		new IMAPI_MEDIA_PHYSICAL_TYPE[] SupportedMediaTypes { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IMAPI_MEDIA_PHYSICAL_TYPE>))] get; }

		/// <summary>Locks the current media for exclusive access.</summary>
		/// <remarks>
		/// <para>Before calling this method, you must call the IDiscFormat2TrackAtOnce::put_ClientName method.</para>
		/// <para>
		/// Also, you must call the <c>IDiscFormat2TrackAtOnce::PrepareMedia</c> method before calling the
		/// IDiscFormat2TrackAtOnce::AddAudioTrack method.
		/// </para>
		/// <para>
		/// After the write is complete or you cancel the write operation, you must call the IDiscFormat2TrackAtOnce::ReleaseMedia method to
		/// release the lock.
		/// </para>
		/// <para>
		/// Note that Media Change Notification (MCN) and the IDiscFormat2TrackAtOnce::put_DoNotFinalizeMedia property become read-only
		/// until the session is closed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-preparemedia HRESULT PrepareMedia();
		[DispId(0x200)]
		void PrepareMedia();

		/// <summary>Writes the data stream to the current media as a new track.</summary>
		/// <param name="data">
		/// <para>An <c>IStream</c> interface of the audio data to write as the next track on the media.</para>
		/// <para>
		/// The data format contains 44.1KHz, 16-bit stereo, raw audio samples. This is the same format used by the audio samples in a
		/// Microsoft WAV audio file (without the header).
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Before calling this method, you must call the IDiscFormat2TrackAtOnce::put_Recorder and IDiscFormat2TrackAtOnce::PrepareMedia methods.
		/// </para>
		/// <para>You should also consider calling the following methods if their default values are not appropriate for your application:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IDiscFormat2TrackAtOnce::put_BufferUnderrunFreeDisabled</term>
		/// </item>
		/// <item>
		/// <term>IDiscFormat2TrackAtOnce::put_ClientName</term>
		/// </item>
		/// <item>
		/// <term>IDiscFormat2TrackAtOnce::put_DoNotFinalizeMedia</term>
		/// </item>
		/// </list>
		/// <para>
		/// To determine the progress of the write operation, you must implement the DDiscFormat2TrackAtOnceEvents interface. For examples
		/// that show how to implement an event handler in a script, see Monitoring Progress With Events.
		/// </para>
		/// <para>The media can accommodate 99 tracks of audio data. Track numbering starts at 1. The last track is 99.</para>
		/// <para>Silence, or data samples containing zeroes, will be added to the track-writing operation in the following ways:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The minimum track size is 4 seconds and if needed, the track data will be enlarged to meet this requirement.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Due to the nature of track-at-once recording, a two-second gap is added between successive audio tracks. This gap is normally
		/// hidden by PC-based players, but may be noticeable on some consumer electronics equipment.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-addaudiotrack HRESULT AddAudioTrack(
		// IStream *data );
		[DispId(0x201)]
		void AddAudioTrack(IStream data);

		/// <summary>Cancels the current write operation.</summary>
		/// <remarks>
		/// <para>
		/// To cancel the write operation, you must call this method from the DDiscFormat2TrackAtOnceEvents::Update event handler that you implemented.
		/// </para>
		/// <para>You must also call the IDiscFormat2TrackAtOnce::ReleaseMedia method after calling this method.</para>
		/// <para>
		/// Note that calling this method does not immediately cancel the write operation on all media due to media-specific requirements.
		/// For example, when writing to a CD, the write operation can continue for up to three more minutes.
		/// </para>
		/// <para>
		/// This method may result in a partial audio track having already been recorded. The method will attempt to keep the media in a
		/// usable state and will simply treat the canceled track as being shorter than originally described by the <c>IStream</c>. Callers
		/// should query the number of tracks and track sizes after canceling to determine the disc state.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-canceladdtrack HRESULT CancelAddTrack();
		[DispId(0x202)]
		void CancelAddTrack();

		/// <summary>Closes the track-writing session and releases the lock.</summary>
		/// <remarks>
		/// This method release the lock set when you called the IDiscFormat2TrackAtOnce::PrepareMedia method. You must call this method to
		/// close a writing session or after calling the IDiscFormat2TrackAtOnce::CancelAddTrack method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-releasemedia HRESULT ReleaseMedia();
		[DispId(0x203)]
		void ReleaseMedia();

		/// <summary>Sets the write speed of the disc recorder.</summary>
		/// <param name="RequestedSectorsPerSecond">
		/// <para>Requested write speed measured in disc sectors per second.</para>
		/// <para>
		/// A value of 0xFFFFFFFF (-1) requests that the write occurs using the fastest supported speed for the media. This is the default.
		/// </para>
		/// </param>
		/// <param name="RotationTypeIsPureCAV">
		/// Requested rotational-speed control type. Set to VARIANT_TRUE to request constant angular velocity (CAV) rotational-speed control
		/// type. Set to VARIANT_FALSE to use another rotational-speed control type that the recorder supports. The default is VARIANT_FALSE.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method sets the write speed and type of rotational-speed control for a recorder. Requested values might differ from the
		/// values set in the recorder. To specify the recorder, call the IDiscFormat2TrackAtOnce::put_Recorder method.
		/// </para>
		/// <para>
		/// If the recorder supports the requested write speed, the disc device uses the requested value. If the recorder does not support
		/// the requested write speed, the recorder uses a write speed that it does support that is closest to the requested value. The
		/// IDiscFormat2TrackAtOnce::get_CurrentWriteSpeed property contains the value used by the recorder.
		/// </para>
		/// <para>
		/// To retrieve a list of the write speeds that the recorder and current media supports, call the
		/// IDiscFormat2TrackAtOnce::get_SupportedWriteSpeeds method.
		/// </para>
		/// <para>
		/// If you request constant angular velocity (CAV) for rotational-speed control type and the recorder does not support CAV, the disc
		/// device uses another type of rotational-speed control type that it supports. The
		/// IDiscFormat2TrackAtOnce::get_CurrentRotationTypeIsPureCAV property indicates the value used by the recorder.
		/// </para>
		/// <para>
		/// To retrieve the requested values, call the IDiscFormat2TrackAtOnce::get_RequestedWriteSpeed and
		/// IDiscFormat2TrackAtOnce::get_RequestedRotationTypeIsPureCAV methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-setwritespeed HRESULT SetWriteSpeed(
		// LONG RequestedSectorsPerSecond, VARIANT_BOOL RotationTypeIsPureCAV );
		[DispId(0x204)]
		void SetWriteSpeed(int RequestedSectorsPerSecond, [MarshalAs(UnmanagedType.VariantBool)] bool RotationTypeIsPureCAV);

		/// <summary>Sets the recording device to use for the write operation.</summary>
		/// <value>An IDiscRecorder2 interface that identifies the recording device to use in the write operation.</value>
		/// <remarks>
		/// The recorder must be compatible with the format defined by this interface. To determine compatibility, call the
		/// IDiscFormat2::IsRecorderSupported method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-put_recorder HRESULT put_Recorder(
		// IDiscRecorder2 *value );
		[DispId(0x100)]
		IDiscRecorder2 Recorder { set; [return: MarshalAs(UnmanagedType.Interface)] get; }

		/// <summary>Determines if Buffer Underrun Free Recording is enabled.</summary>
		/// <value>
		/// Set to VARIANT_TRUE to disable Buffer Underrun Free Recording; otherwise, VARIANT_FALSE. The default is VARIANT_FALSE (enabled).
		/// </value>
		/// <remarks>
		/// Buffer underrun can be an issue if the data stream does not enter the buffer fast enough to keep the device continuously
		/// writing. In turn, the stop and start action of writing can cause data on the disc to be unusable. Buffer Underrun Free (BUF)
		/// recording allows the laser to start and stop without damaging data already written to the disc. Disabling of BUF recording is
		/// possible only on CD-R/RW media.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-put_bufferunderrunfreedisabled
		// HRESULT put_BufferUnderrunFreeDisabled( VARIANT_BOOL value );
		[DispId(0x102)]
		bool BufferUnderrunFreeDisabled { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the number of existing audio tracks on the media.</summary>
		/// <value>Number of completed tracks written to disc, not including the track currently being added.</value>
		/// <remarks>
		/// <para>The value is zero if:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The media is blank</term>
		/// </item>
		/// <item>
		/// <term>You call this method outside a writing session</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-get_numberofexistingtracks HRESULT
		// get_NumberOfExistingTracks( LONG *value );
		[DispId(0x103)]
		int NumberOfExistingTracks { get; }

		/// <summary>Retrieves the total sectors available on the media if writing one continuous audio track.</summary>
		/// <value>Number of all sectors on the media that can be used for audio if one continuous audio track was recorded.</value>
		/// <remarks>This property can be retrieved at any time; however, during writing, the value is cached.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-get_totalsectorsonmedia HRESULT
		// get_TotalSectorsOnMedia( LONG *value );
		[DispId(0x104)]
		int TotalSectorsOnMedia { get; }

		/// <summary>Retrieves the number of sectors available for adding a new track to the media.</summary>
		/// <value>Number of available sectors on the media that can be used for writing audio.</value>
		/// <remarks>
		/// If called during an AddAudioTrack operation, the available sectors do not reflect the sectors used in writing the current audio
		/// track. Instead, the reported value is the number of available sectors immediately preceding the call to AddAudioTrack.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-get_freesectorsonmedia HRESULT
		// get_FreeSectorsOnMedia( LONG *value );
		[DispId(0x105)]
		int FreeSectorsOnMedia { get; }

		/// <summary>Retrieves the total number of used sectors on the media.</summary>
		/// <value>Number of used sectors on the media, including audio tracks and overhead that exists between tracks.</value>
		/// <remarks>If you call this method from your event handler, the number reflects the sectors used before the write began.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-get_usedsectorsonmedia HRESULT
		// get_UsedSectorsOnMedia( LONG *value );
		[DispId(0x106)]
		int UsedSectorsOnMedia { get; }

		/// <summary>Determines if the media is left open for writing after writing the audio track.</summary>
		/// <value>
		/// Set to VARIANT_TRUE to leave the media open for writing after writing the audio track; otherwise, VARIANT_FALSE. The default is VARIANT_FALSE.
		/// </value>
		/// <remarks>
		/// <para>
		/// You can set this property before calling the IDiscFormat2TrackAtOnce::PrepareMedia method or after calling the
		/// IDiscFormat2TrackAtOnce::ReleaseMedia method; you cannot set it during a track-writing session.
		/// </para>
		/// <para>This property is useful to create a multi-session CD with audio in the first session and data in the second session.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-put_donotfinalizemedia HRESULT
		// put_DoNotFinalizeMedia( VARIANT_BOOL value );
		[DispId(0x107)]
		bool DoNotFinalizeMedia { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the table of content for the audio tracks that were laid on the media within the track-writing session.</summary>
		/// <value>
		/// Table of contents for the audio tracks that were laid on the media within the track-writing session. Each element of the list is
		/// a <c>VARIANT</c> of type <c>VT_BYREF|VT_UI1</c>. The <c>pbVal</c> member of the variant contains a binary blob. For details of
		/// the blob, see the READ TOC command at ftp://ftp.t10.org/t10/drafts/mmc5/mmc5r03.pdf.
		/// </value>
		/// <remarks>The property is not accessible outside a track-writing session. Nor is the property accessible if the disc is blank.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-get_expectedtableofcontents HRESULT
		// get_ExpectedTableOfContents( SAFEARRAY **value );
		[DispId(0x10A)]
		IntPtr[] ExpectedTableOfContents { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IntPtr>))] get; }

		/// <summary>Retrieves the type of media in the disc device.</summary>
		/// <value>Type of media in the disc device. For possible values, see the IMAPI_MEDIA_PHYSICAL_TYPEenumeration type.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-get_currentphysicalmediatype HRESULT
		// get_CurrentPhysicalMediaType( IMAPI_MEDIA_PHYSICAL_TYPE *value );
		[DispId(0x10B)]
		IMAPI_MEDIA_PHYSICAL_TYPE CurrentPhysicalMediaType { get; }

		/// <summary>Sets the friendly name of the client.</summary>
		/// <value>Name of the client application.</value>
		/// <remarks>
		/// <para>
		/// The name is used when the write operation requests exclusive access to the device. The IDiscRecorder2::get_ExclusiveAccessOwner
		/// property contains the name of the client that has the lock.
		/// </para>
		/// <para>
		/// Because any application with read/write access to the CDROM device during the write operation can use the
		/// IOCTL_CDROM_EXCLUSIVE_ACCESS (query) control code (see the Microsoft Windows Driver Development Kit (DDK)) to access the name,
		/// it is important that the name identify the program that is using this interface to write to the media. The name is restricted to
		/// the same character set as required by the IOCTL_CDROM_EXCLUSIVE_ACCESS control code.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-put_clientname HRESULT
		// put_ClientName( BSTR value );
		[DispId(0x10E)]
		string ClientName { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>Retrieves the requested write speed.</summary>
		/// <value>
		/// <para>Requested write speed measured in disc sectors per second.</para>
		/// <para>A value of 0xFFFFFFFF (-1) requests that the write occurs using the fastest supported speed for the media.</para>
		/// </value>
		/// <remarks>This is the value specified in the most recent call to the IDiscFormat2TrackAtOnce::SetWriteSpeed method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-get_requestedwritespeed HRESULT
		// get_RequestedWriteSpeed( LONG *value );
		[DispId(0x10F)]
		int RequestedWriteSpeed { get; }

		/// <summary>Retrieves the requested rotational-speed control type.</summary>
		/// <value>
		/// Requested rotational-speed control type. Is VARIANT_TRUE for constant angular velocity (CAV) rotational-speed control type.
		/// Otherwise, is VARIANT_FALSE for any other rotational-speed control type that the recorder supports.
		/// </value>
		/// <remarks>This is the value specified in the most recent call to the IDiscFormat2TrackAtOnce::SetWriteSpeed method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-get_requestedrotationtypeispurecav
		// HRESULT get_RequestedRotationTypeIsPureCAV( VARIANT_BOOL *value );
		[DispId(0x110)]
		bool RequestedRotationTypeIsPureCAV { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the drive's current write speed.</summary>
		/// <value>The write speed of the current media, measured in sectors per second.</value>
		/// <remarks>
		/// <para>To retrieve the requested write speed, call the IDiscFormat2TrackAtOnce::get_RequestedWriteSpeed method.</para>
		/// <para>
		/// To retrieve a list of the write speeds that the recorder and current media supports, call the
		/// IDiscFormat2TrackAtOnce::get_SupportedWriteSpeeds method.
		/// </para>
		/// <para>
		/// Note that the write speed is based on the media write speeds. The value of this property can change when a media change occurs.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-get_currentwritespeed HRESULT
		// get_CurrentWriteSpeed( LONG *value );
		[DispId(0x111)]
		int CurrentWriteSpeed { get; }

		/// <summary>Retrieves the current rotational-speed control used by the recorder.</summary>
		/// <value>
		/// Is VARIANT_TRUE if constant angular velocity (CAV) rotational-speed control is in use. Otherwise, VARIANT_FALSE to indicate that
		/// another rotational-speed control that the recorder supports is in use.
		/// </value>
		/// <remarks>
		/// <para>
		/// To retrieve the requested rotational-speed control, call the IDiscFormat2TrackAtOnce::get_RequestedRotationTypeIsPureCAV method.
		/// </para>
		/// <para>Rotational-speed control types include the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>CLV (Constant Linear Velocity). The disc is written at a constant speed. Standard rotational control.</term>
		/// </item>
		/// <item>
		/// <term>CAV (Constant Angular Velocity). The disc is written at a constantly increasing speed.</term>
		/// </item>
		/// <item>
		/// <term>
		/// ZCAV (Zone Constant Angular Velocity). The disc is divided into zones. After each zone, the write speed increases. This is an
		/// impure form of CAV.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// PCAV (Partial Constant Angular Velocity). The disc speed increases up to a specified velocity. Once reached, the disc spins at
		/// the specified velocity for the duration of the disc writing.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-get_currentrotationtypeispurecav
		// HRESULT get_CurrentRotationTypeIsPureCAV( VARIANT_BOOL *value );
		[DispId(0x112)]
		bool CurrentRotationTypeIsPureCAV { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves a list of the write speeds supported by the disc recorder and current media.</summary>
		/// <value>
		/// List of the write speeds supported by the disc recorder and current media. Each element of the list is a <c>VARIANT</c> of type
		/// <c>VT_UI4</c>. The <c>ulVal</c> member of the variant contains the number of sectors written per second.
		/// </value>
		/// <remarks>
		/// <para>You can use a speed from the list to set the write speed when calling the IDiscFormat2TrackAtOnce::SetWriteSpeed method.</para>
		/// <para>
		/// To retrieve a list of the write configurations that the recorder and current media supports, call the
		/// IDiscFormat2TrackAtOnce::get_SupportedWriteSpeedDescriptors method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-get_supportedwritespeeds HRESULT
		// get_SupportedWriteSpeeds( SAFEARRAY **supportedSpeeds );
		[DispId(0x113)]
		uint[] SupportedWriteSpeeds { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<uint>))] get; }

		/// <summary>Retrieves a list of the detailed write configurations supported by the disc recorder and current media.</summary>
		/// <value>List of the detailed write configurations supported by the disc recorder and current media. Each element of the list is a <c>VARIANT</c> of type <c>VT_Dispatch</c>. Query the <c>pdispVal</c> member of the variant for the IWriteSpeedDescriptor interface, which contains the media type, write speed, rotational-speed control type.</value>
		/// <remarks>To retrieve a list of the write speeds that the recorder and current media supports, call the IDiscFormat2TrackAtOnce::get_SupportedWriteSpeeds method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonce-get_supportedwritespeeddescriptors
		// HRESULT get_SupportedWriteSpeedDescriptors( SAFEARRAY **supportedSpeedDescriptors );
		[DispId(0x114)]
		IWriteSpeedDescriptor[] SupportedWriteSpeedDescriptors { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IWriteSpeedDescriptor>))] get; }
	}

	/// <summary>
	/// <para>Use this interface to retrieve information about the current write operation.</para>
	/// <para>This interface is passed to the DDiscFormat2TrackAtOnceEvents::Update method that you implement.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-idiscformat2trackatonceeventargs
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IDiscFormat2TrackAtOnceEventArgs")]
	[ComImport, Guid("27354140-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IDiscFormat2TrackAtOnceEventArgs : IWriteEngine2EventArgs
	{
		/// <summary>Retrieves the starting logical block address (LBA) of the current write operation.</summary>
		/// <value>Starting logical block address of the write operation. Negative values for LBAs are supported.</value>
		/// <remarks>This is the same value passed to the IWriteEngine2::WriteSection method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_startlba HRESULT get_StartLba(
		// LONG *value );
		[DispId(0x100)]
		new int StartLba { get; }

		/// <summary>Retrieves the number of sectors to write to the device in the current write operation.</summary>
		/// <value>The number of sectors to write in the current write operation.</value>
		/// <remarks>This is the same value passed to the IWriteEngine2::WriteSection method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_sectorcount HRESULT
		// get_SectorCount( LONG *value );
		[DispId(0x101)]
		new int SectorCount { get; }

		/// <summary>Retrieves the address of the sector most recently read from the burn image.</summary>
		/// <value>Logical block address of the sector most recently read from the input data stream.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_lastreadlba HRESULT
		// get_LastReadLba( LONG *value );
		[DispId(0x102)]
		new int LastReadLba { get; }

		/// <summary>Retrieves the address of the sector most recently written to the device.</summary>
		/// <value>Logical block address of the sector most recently written to the device.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_lastwrittenlba HRESULT
		// get_LastWrittenLba( LONG *value );
		[DispId(0x103)]
		new int LastWrittenLba { get; }

		/// <summary>Retrieves the size of the internal data buffer that is used for writing to disc.</summary>
		/// <value>Size, in bytes, of the internal data buffer that is used for writing to disc.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_totalsystembuffer HRESULT
		// get_TotalSystemBuffer( LONG *value );
		[DispId(0x106)]
		new int TotalSystemBuffer { get; }

		/// <summary>Retrieves the number of used bytes in the internal data buffer that is used for writing to disc.</summary>
		/// <value>Size, in bytes, of the used portion of the internal data buffer that is used for writing to disc.</value>
		/// <remarks>This value increases as data is read into the buffer and decreases as data is written to disc.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_usedsystembuffer HRESULT
		// get_UsedSystemBuffer( LONG *value );
		[DispId(0x107)]
		new int UsedSystemBuffer { get; }

		/// <summary>Retrieves the number of unused bytes in the internal data buffer that is used for writing to disc.</summary>
		/// <value>Size, in bytes, of the unused portion of the internal data buffer that is used for writing to disc.</value>
		/// <remarks>This method returns the same value as if you subtracted IWriteEngine2EventArgs::get_UsedSystemBuffer from IWriteEngine2EventArgs::get_TotalSystemBuffer.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_freesystembuffer HRESULT
		// get_FreeSystemBuffer( LONG *value );
		[DispId(0x108)]
		new int FreeSystemBuffer { get; }

		/// <summary>Retrieves the current track number being written to the media.</summary>
		/// <value>Track number, ranging from 1 through 99.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonceeventargs-get_currenttracknumber
		// HRESULT get_CurrentTrackNumber( LONG *value );
		[DispId(0x300)]
		int CurrentTrackNumber { get; }

		/// <summary>Retrieves the current write action being performed.</summary>
		/// <value>
		/// Current write action being performed. For a list of possible actions, see the IMAPI_FORMAT2_TAO_WRITE_ACTION enumeration type.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonceeventargs-get_currentaction HRESULT
		// get_CurrentAction( IMAPI_FORMAT2_TAO_WRITE_ACTION *value );
		[DispId(0x301)]
		IMAPI_FORMAT2_TAO_WRITE_ACTION CurrentAction { get; }

		/// <summary>Retrieves the total elapsed time of the write operation.</summary>
		/// <value>Elapsed time, in seconds, of the write operation.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonceeventargs-get_elapsedtime HRESULT
		// get_ElapsedTime( LONG *value );
		[DispId(0x302)]
		int ElapsedTime { get; }

		/// <summary>Retrieves the estimated remaining time of the write operation.</summary>
		/// <value>Estimated time, in seconds, needed for the remainder of the write operation.</value>
		/// <remarks>
		/// The estimate for a single write operation can vary as the operation progresses. The drive provides updated information that can
		/// affect the projected duration of the write operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2trackatonceeventargs-get_remainingtime HRESULT
		// get_RemainingTime( LONG *value );
		[DispId(0x303)]
		int RemainingTime { get; }
	}

	/// <summary>
	/// <para>Use this interface to enumerate the CD and DVD devices installed on the computer.</para>
	/// <para>
	/// To create an instance of this interface, call the <c>CoCreateInstance</c> function. Use__uuidof(MsftDiscMaster2) for the class
	/// identifier and __uuidof(IDiscMaster2) for the interface identifier.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// To create the <c>MsftDiscMaster2</c> object in a script, use IMAPI2.MsftDiscMaster2 as the program identifier when calling <c>CreateObject</c>.
	/// </para>
	/// <para>To receive notification when a device is added or removed from the computer, implement the <see cref="DDiscMaster2Events"/> interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-idiscmaster2
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IDiscMaster2")]
	[ComImport, Guid("27354130-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftDiscMaster2))]
	public interface IDiscMaster2 : IEnumerable
	{
		/// <summary>Retrieves a list of the CD and DVD devices installed on the computer.</summary>
		/// <returns>
		/// An <c>IEnumVariant</c> interface that you use to enumerate the CD and DVD devices installed on the computer. The items of
		/// the enumeration are variants whose type is <c>VT_BSTR</c>. Use the <c>bstrVal</c> member to retrieve the unique identifier
		/// of the device.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The enumeration is a snapshot of the devices on the computer at the time of the call and will not reflect devices that are
		/// added and removed. To receive notification when a device is added or removed from the computer, implement the
		/// DDiscMaster2Events interface.
		/// </para>
		/// <para>To retrieve a single identifier, see the IDiscMaster2::get_Item property.</para>
		/// <para>
		/// The device identifier is guaranteed to be unique and static for a given device as recognized by Windows Plug and Play. You
		/// can use the identifier as a key value for saving the user's default burner, and can also be used to cache other
		/// device-specific static information (for example, VendorID and ProductID) by an advanced application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscmaster2-get__newenum
		// HRESULT get__NewEnum( IEnumVARIANT **ppunk );
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(EnumeratorToEnumVariantMarshaler))]
		new IEnumerator GetEnumerator();

		/// <summary>Retrieves the unique identifier of the specified disc device.</summary>
		/// <param name="index">
		/// <para>Zero-based index of the device whose unique identifier you want to retrieve.</para>
		/// <para>The index value can change during PNP activity when devices are added or removed from the computer, or across boot sessions.</para>
		/// </param>
		/// <value>String that contains the unique identifier of the disc device associated with the specified index.</value>
		/// <remarks>
		/// <para>To enumerate all identifiers, call the IDiscMaster2::get__NewEnum method.</para>
		/// <para>
		/// The following sample demonstrates how to re-enumerate optical drives in order to accurately account for drives added or removed
		/// after the initial creation of the IDiscMaster2 object. This is accomplished via the <c>IDiscMaster2::get_Item</c> and
		/// IDiscMaster2::get_Count methods:
		/// </para>
		/// <para>
		/// <code>#include &lt;windows.h&gt; #include &lt;tchar.h&gt; #include &lt;imapi2.h&gt; #include &lt;objbase.h&gt; #include &lt;stdio.h&gt; #pragma comment(lib, "ole32.lib") #pragma comment(lib, "user32.lib") int __cdecl _tmain(int argc, TCHAR* argv[]) { BSTR bstrDeviceName; HRESULT hr = S_OK; BOOL bComInitialised; IDiscMaster2* discMaster; UINT iCounter = 0; LONG lValue = 0; bComInitialised = SUCCEEDED(CoInitializeEx(0, COINIT_MULTITHREADED)); // Create an object of IDiscMaster2 if (SUCCEEDED(hr)){ CoCreateInstance( CLSID_MsftDiscMaster2, NULL, CLSCTX_ALL, IID_PPV_ARGS(&amp;discMaster) ); if(FAILED(hr)){ _tprintf(TEXT("\nUnsuccessful in creating an instance of CLSID_MsftDiscMaster2.\n\nError returned: 0x%x\n"), hr); return 0; } } // // Loop twice and get the optical drives attached to the system, // first time just get the current configuration and second time // prompt the user to change the configuration and then get the // altered configuration. // do{ // Get the number of drives if (SUCCEEDED(hr)){ hr = discMaster-&gt;get_Count(&amp;lValue); if (SUCCEEDED(hr)){ _tprintf(TEXT("\nTotal number of drives = %d\n"), lValue); } } // Print all the optical drives attached to the system if (SUCCEEDED(hr)){ for(LONG iCount = 0; iCount &lt; lValue; iCount++) { hr = discMaster-&gt;get_Item(iCount, &amp;bstrDeviceName); _tprintf(TEXT("\nUnique identifier of the disc device associated with index %d is: %s\n"), iCount, bstrDeviceName); } } // Prompt the user to unhook or add drives if (iCounter &lt; 1){ MessageBox(NULL,TEXT("Please un-hook or add drives and hit OK"), TEXT("Manual Action"), MB_OK); _tprintf(TEXT("\nGetting the altered configuration ... \n")); } iCounter++; }while(iCounter &lt; 2); discMaster-&gt;Release(); CoUninitialize(); bComInitialised = FALSE; return 0;</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscmaster2-get_item HRESULT get_Item( LONG index, BSTR
		// *value );
		[DispId(0)]
		string this[int index] { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>Retrieves the number of the CD and DVD disc devices installed on the computer.</summary>
		/// <value>Number of CD and DVD disc devices installed on the computer.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscmaster2-get_count HRESULT get_Count( LONG *value );
		[DispId(1)]
		int Count { get; }

		/// <summary>
		/// Retrieves a value that determines if the environment contains one or more optical devices and the execution context has
		/// permission to access the devices.
		/// </summary>
		/// <value>
		/// Is VARIANT_TRUE if the environment contains one or more optical devices and the execution context has permission to access the
		/// devices; otherwise, VARIANT_FALSE.
		/// </value>
		/// <remarks>
		/// <para>
		/// This method loops through all the strings in IDiscMaster2 and attempts to use each string to initialize a DiscRecorder2 object.
		/// If any of the recorders on the system succeed the initialization, this method returns <c>TRUE</c>.
		/// </para>
		/// <para>The environment must contain at least one type-5 optical device.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscmaster2-get_issupportedenvironment HRESULT
		// get_IsSupportedEnvironment( VARIANT_BOOL *value );
		[DispId(2)]
		bool IsSupportedEnvironment { [return: MarshalAs(UnmanagedType.VariantBool)] get; }
	}

	/// <summary>
	/// <para>
	/// This interface represents a physical device. You use this interface to retrieve information about a CD and DVD device installed on
	/// the computer and to perform operations such as closing the tray or eject the media.
	/// </para>
	/// <para>
	/// To create an instance of this interface, call the <c>CoCreateInstance</c> function. Use__uuidof(MsftDiscRecorder2) for the class
	/// identifier and __uuidof(IDiscRecorder2) for the interface identifier.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// To create the <c>MsftDiscRecorder2</c> object in a script, use IMAPI2.MsftDiscRecorder2 as the program identifier when calling <c>CreateObject</c>.
	/// </para>
	/// <para>
	/// To write data to media, you need to attach a recorder to a format writer, for example, to attach the recorder to a data writer, call
	/// the IDiscFormat2Data::put_Recorder method.
	/// </para>
	/// <para>
	/// Several properties of this interface return packet data defined by Multimedia Command (MMC). For information on the format of the
	/// packet data, see the latest revision of the MMC specification at ftp://ftp.t10.org/t10/drafts/mmc5.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-idiscrecorder2
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IDiscRecorder2")]
	[ComImport, Guid("27354133-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftDiscRecorder2))]
	public interface IDiscRecorder2
	{
		/// <summary>Ejects media from the device.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-ejectmedia HRESULT EjectMedia();
		[DispId(256)]
		void EjectMedia();

		/// <summary>Closes the media tray.</summary>
		/// <remarks>
		/// <c>Note</c> Some drives, such as those with slot-loading mechanisms, do not support this method. To determine if the device
		/// supports this method, call the IDiscRecorder2::get_DeviceCanLoadMedia property.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-closetray HRESULT CloseTray();
		[DispId(257)]
		void CloseTray();

		/// <summary>Acquires exclusive access to the device.</summary>
		/// <param name="force">
		/// Set to VARIANT_TRUE to gain exclusive access to the volume whether the file system volume can or cannot be dismounted. If
		/// VARIANT_FALSE, this method gains exclusive access only when there is no file system mounted on the volume.
		/// </param>
		/// <param name="clientName">
		/// String that contains the friendly name of the client application requesting exclusive access. Cannot be <c>NULL</c> or a
		/// zero-length string. The string must conform to the restrictions for the IOCTL_CDROM_EXCLUSIVE_ACCESS control code found in the DDK.
		/// </param>
		/// <remarks>
		/// <para>
		/// You should not have to call this method to acquire the lock yourself because the write operations, such as
		/// IDiscFormat2Data::Write, acquires the lock for you.
		/// </para>
		/// <para>
		/// Each recorder has a lock count. The first call to a recorder locks the device for exclusive access. Applications can use the
		/// <c>AcquireExclusiveAccess</c> method multiple times to apply multiple locks on a device. Each call increments the lock count by one.
		/// </para>
		/// <para>
		/// When unlocking a recorder, the lock count must reach zero to free the device for other clients. Calling the
		/// IDiscRecorder2::ReleaseExclusiveAccess method decrements the lock count by one.
		/// </para>
		/// <para>
		/// An equal number of calls to the <c>AcquireExclusiveAccess</c> and ReleaseExclusiveAccess methods are needed to free a device.
		/// Should the application exit unexpectedly or crash while holding the exclusive access, the CDROM.SYS driver will automatically
		/// release these exclusive locks.
		/// </para>
		/// <para>
		/// If the device is already locked, you can call IDiscRecorder2::get_ExclusiveAccessOwner to retrieve the name of the client
		/// application that currently has exclusive access.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-acquireexclusiveaccess HRESULT
		// AcquireExclusiveAccess( VARIANT_BOOL force, BSTR __MIDL__IDiscRecorder20000 );
		[DispId(258)]
		void AcquireExclusiveAccess([MarshalAs(UnmanagedType.VariantBool)] bool force, [MarshalAs(UnmanagedType.BStr)] string clientName);

		/// <summary>Releases exclusive access to the device.</summary>
		/// <remarks>
		/// <para>
		/// Each recorder has a lock count. The first call to a recorder locks the device for exclusive access. Applications can use the
		/// IDiscRecorder2::AcquireExclusiveAccess method multiple times to apply multiple locks on a device. Each call increments the lock
		/// count by one.
		/// </para>
		/// <para>
		/// When unlocking a recorder, the lock count must reach zero to free the device for other clients. Calling the
		/// <c>ReleaseExclusiveAccess</c> method decrements the lock count by one.
		/// </para>
		/// <para>
		/// An equal number of calls to the AcquireExclusiveAccess and <c>ReleaseExclusiveAccess</c> methods are needed to free a device.
		/// When the lock count reaches zero, recording device is free; the last lock has been removed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-releaseexclusiveaccess HRESULT ReleaseExclusiveAccess();
		[DispId(259)]
		void ReleaseExclusiveAccess();

		/// <summary>Disables Media Change Notification (MCN) for the device.</summary>
		/// <remarks>
		/// <para>
		/// MCN is the CD-ROM device driver's method of detecting media change and state changes in the CD-ROM device. For example, when you
		/// change the media in a CD-ROM device, a MCN message is sent to trigger media features, such as Autoplay. To disable the features,
		/// call this method.
		/// </para>
		/// <para>
		/// To enable notifications, call the IDiscRecorder2::EnableMcn method. If the application crashes or closes unexpectedly, then MCN
		/// is automatically re-enabled by the driver.
		/// </para>
		/// <para>
		/// Note that DisableMcn increments a reference count each time it is called. The EnableMcn method decrements the count. The device
		/// is enabled when the reference count is zero.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-disablemcn HRESULT DisableMcn();
		[DispId(260)]
		void DisableMcn();

		/// <summary>Enables Media Change Notification (MCN) for the device.</summary>
		/// <remarks>
		/// <para>
		/// MCN is the CD-ROM device driver's method of detecting media change and state changes in the CD-ROM device. For example, when you
		/// change the media in a CD-ROM device, a MCN message is sent to trigger media features, such as Autoplay. MCN is enabled by
		/// default. Call this method to enable notifications when the notifications have been disabled using IDiscRecorder2::DisableMcn.
		/// </para>
		/// <para>
		/// Note that DisableMcn increments a reference count each time it is called. The EnableMcn method decrements the count. The device
		/// is enabled when the reference count is zero.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/ja-jp/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-enablemcn HRESULT EnableMcn();
		[DispId(261)]
		void EnableMcn();

		/// <summary>Associates the object with the specified disc device.</summary>
		/// <param name="recorderUniqueId">String that contains the unique identifier for the device.</param>
		/// <remarks>
		/// <para>You must initialize the recorder before calling any of the methods of this interface.</para>
		/// <para>To retrieve a list of devices on the computer and their unique identifiers, call the IDiscMaster2::get__NewEnum method.</para>
		/// <para>
		/// This method will not fail on a drive that is exclusively locked. However, if the drive is exclusively locked, several of the
		/// methods of this interface may return E_IMAPI_RECORDER_LOCKED. To determine who has exclusive access, call the
		/// IDiscRecorder2::get_ExclusiveAccessOwner method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-initializediscrecorder HRESULT
		// InitializeDiscRecorder( BSTR recorderUniqueId );
		[DispId(262)]
		void InitializeDiscRecorder([MarshalAs(UnmanagedType.BStr)] string recorderUniqueId);

		/// <summary>Retrieves the unique identifier used to initialize the disc device.</summary>
		/// <value>Unique identifier for the device. This is the identifier you specified when calling IDiscRecorder2::InitializeDiscRecorder.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-get_activediscrecorder HRESULT
		// get_ActiveDiscRecorder( BSTR *value );
		[DispId(0)]
		string ActiveDiscRecorder { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>Retrieves the vendor ID for the device.</summary>
		/// <value>String that contains the vendor ID for the device.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-get_vendorid HRESULT get_VendorId( BSTR *value );
		[DispId(513)]
		string VendorId { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>Retrieves the product ID of the device.</summary>
		/// <value>String that contains the product ID of the device.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-get_productid HRESULT get_ProductId( BSTR
		// *value );
		[DispId(514)]
		string ProductId { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>Retrieves the product revision code of the device.</summary>
		/// <value>String that contains the product revision code of the device.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-get_productrevision HRESULT
		// get_ProductRevision( BSTR *value );
		[DispId(515)]
		string ProductRevision { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>Retrieves the unique volume name associated with the device.</summary>
		/// <value>String that contains the unique volume name associated with the device.</value>
		/// <remarks>To retrieve the drive letter assignment, call the IDiscRecorder2::get_VolumePathNames method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-get_volumename HRESULT get_VolumeName( BSTR
		// *value );
		[DispId(516)]
		string VolumeName { [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>Retrieves a list of drive letters and NTFS mount points for the device.</summary>
		/// <value>
		/// List of drive letters and NTFS mount points for the device. Each element of the list is a <c>VARIANT</c> of type <c>VT_BSTR</c>.
		/// The <c>bstrVal</c> member of the variant contains the path.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-get_volumepathnames HRESULT
		// get_VolumePathNames( SAFEARRAY **value );
		[DispId(517)]
		string[] VolumePathNames { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<string>))] get; }

		/// <summary>Determines if the device can eject and subsequently reload media.</summary>
		/// <value>
		/// <para>Is VARIANT_TRUE if the device can eject and subsequently reload media. If VARIANT_FALSE, loading media must be done manually.</para>
		/// <para>
		/// <c>Note</c> For slim drives or laptop drives, which utilize a manual tray-loading mechanism, this parameter can indicate an
		/// incorrect value of VARIANT_TRUE.
		/// </para>
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-get_devicecanloadmedia HRESULT
		// get_DeviceCanLoadMedia( VARIANT_BOOL *value );
		[DispId(518)]
		bool DeviceCanLoadMedia { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the legacy device number for a CD or DVD device.</summary>
		/// <value>
		/// <para>Zero-based index number of the device, based on the order the device was installed on the computer.</para>
		/// <para>
		/// This value can change during PNP activity when devices are added or removed from the computer, or across boot sessions and
		/// should not be considered a unique identifier for the device.
		/// </para>
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-get_legacydevicenumber HRESULT
		// get_LegacyDeviceNumber( LONG *legacyDeviceNumber );
		[DispId(519)]
		int LegacyDeviceNumber { get; }

		/// <summary>Retrieves the list of features that the device supports.</summary>
		/// <value>
		/// List of features that the device supports. Each element of the list is a <c>VARIANT</c> of type <c>VT_I4</c>. The <c>lVal</c>
		/// member of the variant contains the feature page type value. For possible values, see the IMAPI_FEATURE_PAGE_TYPE enumeration type.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-get_supportedfeaturepages HRESULT
		// get_SupportedFeaturePages( SAFEARRAY **value );
		[DispId(520)]
		IMAPI_FEATURE_PAGE_TYPE[] SupportedFeaturePages { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IMAPI_FEATURE_PAGE_TYPE>))] get; }

		/// <summary>Retrieves the list of feature pages of the device that are marked as current.</summary>
		/// <value>
		/// List of supported feature pages that are marked as current for the device. Each element of the list is a <c>VARIANT</c> of type
		/// <c>VT_I4</c>. The <c>lVal</c> member of the variant contains the feature page type. For possible values, see the
		/// IMAPI_FEATURE_PAGE_TYPE enumeration.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-get_currentfeaturepages HRESULT
		// get_CurrentFeaturePages( SAFEARRAY **value );
		[DispId(521)]
		IMAPI_FEATURE_PAGE_TYPE[] CurrentFeaturePages { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IMAPI_FEATURE_PAGE_TYPE>))] get; }

		/// <summary>Retrieves the list of MMC profiles that the device supports.</summary>
		/// <value>
		/// List of MMC profiles that the device supports. Each element of the list is a <c>VARIANT</c> of type <c>VT_I4</c>. The
		/// <c>lVal</c> member of the variant contains the profile type value. For possible values, see the IMAPI_PROFILE_TYPE enumeration type.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-get_supportedprofiles HRESULT
		// get_SupportedProfiles( SAFEARRAY **value );
		[DispId(522)]
		IMAPI_PROFILE_TYPE[] SupportedProfiles { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IMAPI_PROFILE_TYPE>))] get; }

		/// <summary>Retrieves all MMC profiles of the device that are marked as current.</summary>
		/// <value>
		/// List of supported profiles that are marked as current for the device. Each element of the list is a <c>VARIANT</c> of type
		/// <c>VT_I4</c>. The <c>lVal</c> member of the variant contains the profile type. For possible values, see the IMAPI_PROFILE_TYPE enumeration.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-get_currentprofiles HRESULT
		// get_CurrentProfiles( SAFEARRAY **value );
		[DispId(523)]
		IMAPI_PROFILE_TYPE[] CurrentProfiles { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IMAPI_PROFILE_TYPE>))] get; }

		/// <summary>Retrieves the list of MMC mode pages that the device supports.</summary>
		/// <value>
		/// List of MMC mode pages that the device supports. Each element of the list is a <c>VARIANT</c> of type <c>VT_I4</c>. The
		/// <c>lVal</c> member of the variant contains the mode page type value. For possible values, see the IMAPI_MODE_PAGE_TYPE
		/// enumeration type.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-get_supportedmodepages HRESULT
		// get_SupportedModePages( SAFEARRAY **value );
		[DispId(524)]
		IMAPI_MODE_PAGE_TYPE[] SupportedModePages { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IMAPI_MODE_PAGE_TYPE>))] get; }

		/// <summary>Retrieves the name of the client application that has exclusive access to the device.</summary>
		/// <value>String that contains the name of the client application that has exclusive access to the device.</value>
		/// <remarks>
		/// This property returns the current exclusive access owner of the device. This value comes directly from CDROM.SYS and should be
		/// queried anytime an operation fails with error E_IMAPI_RECORDER_LOCKED.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2-get_exclusiveaccessowner HRESULT
		// get_ExclusiveAccessOwner( BSTR *value );
		[DispId(525)]
		string ExclusiveAccessOwner { [return: MarshalAs(UnmanagedType.BStr)] get; }
	}

	/// <summary>
	/// <para>
	/// This interface represents a physical device. You use this interface to retrieve information about a CD and DVD device installed on
	/// the computer and to perform operations such as closing the tray or ejecting the media. This interface retrieves information not
	/// available through IDiscRecorder2 interface, and provides easier access to some of the same property values in <c>IDiscRecorder2</c>.
	/// </para>
	/// <para>
	/// To get an instance of this interface, create an instance of the IDiscRecorder2 interface and then call the
	/// <c>IDiscRecorder2::QueryInterface</c> method to retrieve the <c>IDiscRecorder2Ex</c> interface.
	/// </para>
	/// <para>Note that you cannot access this functionality from script.</para>
	/// </summary>
	/// <remarks>
	/// To write data to media, you need to attach this recorder to the IWriteEngine2 data writer, using the IWriteEngine2::put_Recorder method.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-idiscrecorder2ex
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IDiscRecorder2Ex")]
	[ComImport, Guid("27354132-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(MsftDiscRecorder2))]
	public interface IDiscRecorder2Ex
	{
		/// <summary>
		/// Sends a MMC command to the recording device. Use this function when no data buffer is sent to nor received from the device.
		/// </summary>
		/// <param name="Cdb">Command packet to send to the device.</param>
		/// <param name="CdbSize">Size, in bytes, of the command packet to send. Must be between 6 and 16 bytes.</param>
		/// <param name="SenseBuffer">Sense data returned by the recording device.</param>
		/// <param name="Timeout">Time limit, in seconds, allowed for the send command to receive a result.</param>
		/// <remarks>
		/// <para>
		/// For details of the contents of the command packet and sense data, see the latest revision of the MMC specification at ftp://ftp.t10.org/t10/drafts/mmc5.
		/// </para>
		/// <para>
		/// Client-defined commands (CDBs) used with this method must be between 6 and 16 bytes in length. In addition, the size of each
		/// command must match the size defined by the operation code as defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>CDB operation code range</term>
		/// <term>CDB group</term>
		/// <term>Required CDB size</term>
		/// </listheader>
		/// <item>
		/// <term>0x00 — 0x1F</term>
		/// <term>0</term>
		/// <term>6 bytes</term>
		/// </item>
		/// <item>
		/// <term>0x20 — 0x3F</term>
		/// <term>1</term>
		/// <term>10 bytes</term>
		/// </item>
		/// <item>
		/// <term>0x40 — 0x5F</term>
		/// <term>2</term>
		/// <term>10 bytes</term>
		/// </item>
		/// <item>
		/// <term>0x60 — 0x7F</term>
		/// <term>3</term>
		/// <term>Will enforce standard-specified size requirements for this opcode range in the future.</term>
		/// </item>
		/// <item>
		/// <term>0x80 — 0x9F</term>
		/// <term>4</term>
		/// <term>16 bytes</term>
		/// </item>
		/// <item>
		/// <term>0xA0 — 0xBF</term>
		/// <term>5</term>
		/// <term>12 bytes</term>
		/// </item>
		/// <item>
		/// <term>0xC0 — 0xDF</term>
		/// <term>6</term>
		/// <term>Vendor Unique - Any size allowed</term>
		/// </item>
		/// <item>
		/// <term>0xE0 — 0xFF</term>
		/// <term>7</term>
		/// <term>Vendor Unique - Any size allowed</term>
		/// </item>
		/// </list>
		/// <para>
		/// Some very early devices used vendor-unique opcodes and therefore some opcodes cannot be validated in this manner. The following
		/// opcodes are still valid and only verify that the size is between 6 and 16 bytes:
		/// </para>
		/// <para>
		/// 0x02, 0x05, 0x06, 0x09, 0x0C, 0x0D, 0x0E, 0x0F, 0x10, 0x13, 0x14, 0x19, 0x20, 0x21, 0x22, 0x23, 0x24, 0x26, 0x27, 0x29, 0x2C, 0x2D
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-sendcommandnodata HRESULT SendCommandNoData(
		// BYTE *Cdb, ULONG CdbSize, BYTE [18] SenseBuffer, ULONG Timeout );
		void SendCommandNoData([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] Cdb, uint CdbSize,
			[MarshalAs(UnmanagedType.LPArray, SizeConst = 18)] byte[] SenseBuffer, uint Timeout);

		/// <summary>Sends a MMC command and its associated data buffer to the recording device.</summary>
		/// <param name="Cdb">Command packet to send to the device.</param>
		/// <param name="CdbSize">Size, in bytes, of the command packet to send. Must be between 6 and 16 bytes.</param>
		/// <param name="SenseBuffer">Sense data returned by the recording device.</param>
		/// <param name="Timeout">Time limit, in seconds, allowed for the send command to receive a result.</param>
		/// <param name="Buffer">Buffer containing data associated with the send command. Must not be <c>NULL</c>.</param>
		/// <param name="BufferSize">Size, in bytes, of the data buffer to send. Must not be zero.</param>
		/// <remarks>
		/// <para>
		/// For details of the contents of the command packet, sense data, and input data buffer, see the latest revision of the MMC
		/// specification at ftp://ftp.t10.org/t10/drafts/mmc5.
		/// </para>
		/// <para>
		/// Client-defined commands (CDBs) used with this method must be between 6 and 16 bytes in length. In addition, the size of each
		/// command must match the size defined by the operation code as defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>CDB operation code range</term>
		/// <term>CDB group</term>
		/// <term>Required CDB size</term>
		/// </listheader>
		/// <item>
		/// <term>0x00 — 0x1F</term>
		/// <term>0</term>
		/// <term>6 bytes</term>
		/// </item>
		/// <item>
		/// <term>0x20 — 0x3F</term>
		/// <term>1</term>
		/// <term>10 bytes</term>
		/// </item>
		/// <item>
		/// <term>0x40 — 0x5F</term>
		/// <term>2</term>
		/// <term>10 bytes</term>
		/// </item>
		/// <item>
		/// <term>0x60 — 0x7F</term>
		/// <term>3</term>
		/// <term>Will enforce standard-specified size requirements for this opcode range in the future.</term>
		/// </item>
		/// <item>
		/// <term>0x80 — 0x9F</term>
		/// <term>4</term>
		/// <term>16 bytes</term>
		/// </item>
		/// <item>
		/// <term>0xA0 — 0xBF</term>
		/// <term>5</term>
		/// <term>12 bytes</term>
		/// </item>
		/// <item>
		/// <term>0xC0 — 0xDF</term>
		/// <term>6</term>
		/// <term>Vendor Unique - Any size allowed</term>
		/// </item>
		/// <item>
		/// <term>0xE0 — 0xFF</term>
		/// <term>7</term>
		/// <term>Vendor Unique - Any size allowed</term>
		/// </item>
		/// </list>
		/// <para>
		/// Some very early devices used vendor-unique opcodes and therefore some opcodes cannot be validated in this manner. The following
		/// opcodes are still valid and only verify that the size is between 6 and 16 bytes:
		/// </para>
		/// <para>
		/// 0x02, 0x05, 0x06, 0x09, 0x0C, 0x0D, 0x0E, 0x0F, 0x10, 0x13, 0x14, 0x19, 0x20, 0x21, 0x22, 0x23, 0x24, 0x26, 0x27, 0x29, 0x2C, 0x2D
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-sendcommandsenddatatodevice HRESULT
		// SendCommandSendDataToDevice( BYTE *Cdb, ULONG CdbSize, BYTE [18] SenseBuffer, ULONG Timeout, BYTE *Buffer, ULONG_IMAPI2_NONZERO
		// BufferSize );
		void SendCommandSendDataToDevice([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] Cdb,
			uint CdbSize, [MarshalAs(UnmanagedType.LPArray, SizeConst = 18)] byte[] SenseBuffer, uint Timeout,
			[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)] byte[] Buffer,
			uint BufferSize);

		/// <summary>Sends a MMC command to the recording device requesting data from the device.</summary>
		/// <param name="Cdb">Command packet to send to the device.</param>
		/// <param name="CdbSize">Size, in bytes, of the command packet to send. Must be between 6 and 16 bytes.</param>
		/// <param name="SenseBuffer">Sense data returned by the recording device.</param>
		/// <param name="Timeout">Time limit, in seconds, allowed for the send command to receive a result.</param>
		/// <param name="Buffer">
		/// Application-allocated data buffer that will receive data associated with the send command. Must not be <c>NULL</c>.
		/// </param>
		/// <param name="BufferSize">Size, in bytes, of the Buffer data buffer. Must not be zero.</param>
		/// <param name="BufferFetched">Size, in bytes, of the data returned in the Buffer data buffer.</param>
		/// <remarks>
		/// <para>
		/// For details of the contents of the command packet, sense data, and output data buffer, see the latest revision of the MMC
		/// specification at ftp://ftp.t10.org/t10/drafts/mmc5.
		/// </para>
		/// <para>
		/// Client-defined commands (CDBs) used with this method must be between 6 and 16 bytes in length. In addition, the size of each
		/// command must match the size defined by the operation code as defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>CDB operation code range</term>
		/// <term>CDB group</term>
		/// <term>Required CDB size</term>
		/// </listheader>
		/// <item>
		/// <term>0x00 — 0x1F</term>
		/// <term>0</term>
		/// <term>6 bytes</term>
		/// </item>
		/// <item>
		/// <term>0x20 — 0x3F</term>
		/// <term>1</term>
		/// <term>10 bytes</term>
		/// </item>
		/// <item>
		/// <term>0x40 — 0x5F</term>
		/// <term>2</term>
		/// <term>10 bytes</term>
		/// </item>
		/// <item>
		/// <term>0x60 — 0x7F</term>
		/// <term>3</term>
		/// <term>Will enforce standard-specified size requirements for this opcode range in the future.</term>
		/// </item>
		/// <item>
		/// <term>0x80 — 0x9F</term>
		/// <term>4</term>
		/// <term>16 bytes</term>
		/// </item>
		/// <item>
		/// <term>0xA0 — 0xBF</term>
		/// <term>5</term>
		/// <term>12 bytes</term>
		/// </item>
		/// <item>
		/// <term>0xC0 — 0xDF</term>
		/// <term>6</term>
		/// <term>Vendor Unique - Any size allowed</term>
		/// </item>
		/// <item>
		/// <term>0xE0 — 0xFF</term>
		/// <term>7</term>
		/// <term>Vendor Unique - Any size allowed</term>
		/// </item>
		/// </list>
		/// <para>
		/// Some very early devices used vendor-unique opcodes and therefore some opcodes cannot be validated in this manner. The following
		/// opcodes are still valid and only verify that the size is between 6 and 16 bytes:
		/// </para>
		/// <para>
		/// 0x02, 0x05, 0x06, 0x09, 0x0C, 0x0D, 0x0E, 0x0F, 0x10, 0x13, 0x14, 0x19, 0x20, 0x21, 0x22, 0x23, 0x24, 0x26, 0x27, 0x29, 0x2C, 0x2D
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-sendcommandgetdatafromdevice HRESULT
		// SendCommandGetDataFromDevice( BYTE *Cdb, ULONG CdbSize, BYTE [18] SenseBuffer, ULONG Timeout, BYTE *Buffer, ULONG_IMAPI2_NONZERO
		// BufferSize, ULONG_IMAPI2_NOT_NEGATIVE *BufferFetched );
		void SendCommandGetDataFromDevice([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] Cdb,
			uint CdbSize, [MarshalAs(UnmanagedType.LPArray, SizeConst = 18)] byte[] SenseBuffer, uint Timeout,
			[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)] byte[] Buffer,
			uint BufferSize, out uint BufferFetched);

		/// <summary>Reads a DVD structure from the media.</summary>
		/// <param name="format">
		/// <para>Format field of the command packet. Acceptable values range from zero to 0xFF.</para>
		/// <para><c>Note</c> This value is truncated to <c>UCHAR</c>.</para>
		/// </param>
		/// <param name="address">Address field of the command packet.</param>
		/// <param name="layer">Layer field of the command packet.</param>
		/// <param name="agid">Authentication grant ID (AGID) field of the command packet.</param>
		/// <param name="data">
		/// <para>
		/// Data buffer that contains the DVD structure. For details of the contents of the data buffer, see the READ DISC STRUCTURE command
		/// in the latest revision of the MMC specification at ftp://ftp.t10.org/t10/drafts/mmc5.
		/// </para>
		/// <para>This method removes headers from the buffer.</para>
		/// <para>When done, call the <c>CoTaskMemFree</c> function to free the memory.</para>
		/// </param>
		/// <param name="count">Size, in bytes, of the data buffer.</param>
		/// <remarks>
		/// This method removes the complexity of working with the READ DISC STRUCTURE command. For details on the values to specify for the
		/// format, address, layer, and agid parameters, see their field descriptions for the READ DISC STRUCTURE command in the latest
		/// revision of the MMC specification at ftp://ftp.t10.org/t10/drafts/mmc5.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-readdvdstructure HRESULT ReadDvdStructure(
		// ULONG format, ULONG address, ULONG layer, ULONG agid, BYTE **data, ULONG_IMAPI2_DVD_STRUCTURE *count );
		void ReadDvdStructure(uint format, uint address, uint layer, uint agid, out SafeCoTaskMemHandle data, out uint count);

		/// <summary>Sends a DVD structure to the media.</summary>
		/// <param name="format">Format field of the command packet. Acceptable values range from zero to 0xFF.</param>
		/// <param name="data">
		/// Data buffer that contains the DVD structure to send to the media. Do not include a header; this method generates and prepends a
		/// header to the DVD structure.
		/// </param>
		/// <param name="count">Size, in bytes, of the data buffer.</param>
		/// <remarks>
		/// For details on specifying the fields of the structure, see the SEND DISC STRUCTURE command in the latest revision of the MMC
		/// specification at ftp://ftp.t10.org/t10/drafts/mmc5.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-senddvdstructure HRESULT SendDvdStructure(
		// ULONG format, BYTE *data, ULONG_IMAPI2_DVD_STRUCTURE count );
		void SendDvdStructure(uint format, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] data, int count);

		/// <summary>Retrieves the adapter descriptor for the device.</summary>
		/// <param name="data">
		/// <para>
		/// Data buffer that contains the descriptor of the storage adapter. For details of the contents of the data buffer, see the
		/// <c>STORAGE_ADAPTER_DESCRIPTOR</c> structure in the DDK
		/// </para>
		/// <para>When done, call the <c>CoTaskMemFree</c> function to free the memory.</para>
		/// </param>
		/// <param name="byteSize">Size, in bytes, of the data buffer.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-getadapterdescriptor HRESULT
		// GetAdapterDescriptor( BYTE **data, ULONG_IMAPI2_ADAPTER_DESCRIPTOR *byteSize );
		void GetAdapterDescriptor(out SafeCoTaskMemHandle data, out uint byteSize);

		/// <summary>Retrieves the device descriptor for the device.</summary>
		/// <param name="data">
		/// <para>
		/// Data buffer that contains the descriptor of the storage device. For details of the contents of the data buffer, see the
		/// <c>STORAGE_DEVICE_DESCRIPTOR</c> structure in the DDK
		/// </para>
		/// <para>When done, call the <c>CoTaskMemFree</c> function to free the memory.</para>
		/// </param>
		/// <param name="byteSize">Size, in bytes, of the data buffer.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-getdevicedescriptor HRESULT
		// GetDeviceDescriptor( BYTE **data, ULONG_IMAPI2_DEVICE_DESCRIPTOR *byteSize );
		void GetDeviceDescriptor(out SafeCoTaskMemHandle data, out uint byteSize);

		/// <summary>Retrieves the disc information from the media.</summary>
		/// <param name="discInformation">
		/// <para>
		/// Data buffer that contains disc information from the media. For details of the contents of the data buffer, see the READ DISC
		/// INFORMATION command in the latest revision of the MMC specification at ftp://ftp.t10.org/t10/drafts/mmc5.
		/// </para>
		/// <para>When done, call the <c>CoTaskMemFree</c> function to free the memory.</para>
		/// </param>
		/// <param name="byteSize">Size, in bytes, of the data buffer.</param>
		/// <remarks>See the MMC specification for details regarding how to interpret the returned data.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-getdiscinformation HRESULT
		// GetDiscInformation( BYTE **discInformation, ULONG_IMAPI2_DISC_INFORMATION *byteSize );
		void GetDiscInformation(out SafeCoTaskMemHandle discInformation, out uint byteSize);

		/// <summary>Retrieves the track information from the media.</summary>
		/// <param name="address">Address field. The addressType parameter provides additional context for this parameter.</param>
		/// <param name="addressType">
		/// Type of address specified in the address parameter, for example, if this is an LBA address or a track number. For possible
		/// values, see the IMAPI_READ_TRACK_ADDRESS_TYPE enumeration type.
		/// </param>
		/// <param name="trackInformation">
		/// <para>
		/// Data buffer that contains the track information. For details of the contents of the data buffer, see the READ TRACK INFORMATION
		/// command in the latest revision of the MMC specification at ftp://ftp.t10.org/t10/drafts/mmc5.
		/// </para>
		/// <para>When done, call the <c>CoTaskMemFree</c> function to free the memory.</para>
		/// </param>
		/// <param name="byteSize">Size, in bytes, of the trackInformation data buffer.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-gettrackinformation HRESULT
		// GetTrackInformation( ULONG address, IMAPI_READ_TRACK_ADDRESS_TYPE addressType, BYTE **trackInformation,
		// ULONG_IMAPI2_TRACK_INFORMATION *byteSize );
		void GetTrackInformation(uint address, IMAPI_READ_TRACK_ADDRESS_TYPE addressType, out SafeCoTaskMemHandle trackInformation, out uint byteSize);

		/// <summary>Retrieves the specified feature page from the device.</summary>
		/// <param name="requestedFeature">Feature page to retrieve. For possible values, see the IMAPI_FEATURE_PAGE_TYPE enumeration type.</param>
		/// <param name="currentFeatureOnly">
		/// Set to True to retrieve the feature page only when it is the current feature page. Otherwise, False to retrieve the feature page
		/// regardless of it being the current feature page.
		/// </param>
		/// <param name="featureData">
		/// <para>
		/// Data buffer that contains the feature page. For details of the contents of the data buffer, see the GET CONFIGURATION command in
		/// the latest revision of the MMC specification at ftp://ftp.t10.org/t10/drafts/mmc5.
		/// </para>
		/// <para>This method removes header information and other non-feature data before filling and sending this buffer.</para>
		/// <para>When done, call the <c>CoTaskMemFree</c> function to free the memory.</para>
		/// </param>
		/// <param name="byteSize">Size, in bytes, of the featureData data buffer.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-getfeaturepage HRESULT GetFeaturePage(
		// IMAPI_FEATURE_PAGE_TYPE requestedFeature, BOOLEAN currentFeatureOnly, BYTE **featureData, ULONG_IMAPI2_FEATURE_PAGE *byteSize );
		void GetFeaturePage(IMAPI_FEATURE_PAGE_TYPE requestedFeature, [MarshalAs(UnmanagedType.U1)] bool currentFeatureOnly,
			out SafeCoTaskMemHandle featureData, out uint byteSize);

		/// <summary>Retrieves the specified mode page from the device.</summary>
		/// <param name="requestedModePage">Mode page to retrieve. For possible values, see the IMAPI_MODE_PAGE_TYPE enumeration type.</param>
		/// <param name="requestType">
		/// Type of mode page data to retrieve, for example, the current settings or the settings that are write enabled. For possible
		/// values, see the IMAPI_MODE_PAGE_REQUEST_TYPE enumeration type.
		/// </param>
		/// <param name="modePageData">
		/// <para>
		/// Data buffer that contains the mode page. For details of the contents of the data buffer, see the MODE SENSE (10) command in the
		/// latest revision of the MMC specification at ftp://ftp.t10.org/t10/drafts/mmc5.
		/// </para>
		/// <para>This method removes header information and other non-page data before returning the buffer.</para>
		/// <para>When done, call the <c>CoTaskMemFree</c> function to free the memory.</para>
		/// </param>
		/// <param name="byteSize">Size, in bytes, of the modePageData data buffer.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-getmodepage HRESULT GetModePage(
		// IMAPI_MODE_PAGE_TYPE requestedModePage, IMAPI_MODE_PAGE_REQUEST_TYPE requestType, BYTE **modePageData, ULONG_IMAPI2_MODE_PAGE
		// *byteSize );
		void GetModePage(IMAPI_MODE_PAGE_TYPE requestedModePage, IMAPI_MODE_PAGE_REQUEST_TYPE requestType, out SafeCoTaskMemHandle modePageData,
			out uint byteSize);

		/// <summary>Sets the mode page data for the device.</summary>
		/// <param name="requestType">
		/// Type of mode page data to send. For possible values, see the IMAPI_MODE_PAGE_REQUEST_TYPE enumeration type.
		/// </param>
		/// <param name="data">
		/// <para>
		/// Data buffer that contains the mode page data to send to the media. Do not include a header; this method generates and prepends a
		/// header to the mode page data.
		/// </para>
		/// <para>
		/// For details on specifying the fields of the mode page data, see the MODE SELECT (10) command in the latest revision of the MMC
		/// specification at ftp://ftp.t10.org/t10/drafts/mmc5.
		/// </para>
		/// </param>
		/// <param name="byteSize">Size, in bytes, of the data buffer.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-setmodepage HRESULT SetModePage(
		// IMAPI_MODE_PAGE_REQUEST_TYPE requestType, BYTE *data, ULONG_IMAPI2_MODE_PAGE byteSize );
		void SetModePage(IMAPI_MODE_PAGE_REQUEST_TYPE requestType,
			[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] data, uint byteSize);

		/// <summary>Retrieves the list of supported feature pages or the current feature pages of the device.</summary>
		/// <param name="currentFeatureOnly">
		/// Set to True to retrieve only current feature pages. Otherwise, False to retrieve all feature pages that the device supports.
		/// </param>
		/// <param name="featureData">
		/// <para>
		/// Data buffer that contains one or more feature page types. For possible values, see the IMAPI_FEATURE_PAGE_TYPE enumeration type.
		/// </para>
		/// <para>To get the feature page data associated with the feature page type, call the IDiscRecorder2Ex::GetFeaturePage method.</para>
		/// <para>When done, call the <c>CoTaskMemFree</c> function to free the memory.</para>
		/// </param>
		/// <param name="byteSize">Number of supported feature pages in the featureData data buffer.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-getsupportedfeaturepages HRESULT
		// GetSupportedFeaturePages( BOOLEAN currentFeatureOnly, IMAPI_FEATURE_PAGE_TYPE **featureData, ULONG_IMAPI2_ALL_FEATURE_PAGES
		// *byteSize );
		void GetSupportedFeaturePages([MarshalAs(UnmanagedType.U1)] bool currentFeatureOnly, out SafeCoTaskMemHandle featureData, out uint byteSize);

		/// <summary>Retrieves the supported profiles or the current profiles of the device.</summary>
		/// <param name="currentOnly">
		/// Set to True to retrieve the current profiles. Otherwise, False to return all supported profiles of the device.
		/// </param>
		/// <param name="profileTypes">
		/// <para>Data buffer that contains one or more profile types. For possible values, see the IMAPI_PROFILE_TYPE enumeration type.</para>
		/// <para>When done, call the <c>CoTaskMemFree</c> function to free the memory.</para>
		/// </param>
		/// <param name="validProfiles">Number of supported profiles in the profileTypes data buffer.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-getsupportedprofiles HRESULT
		// GetSupportedProfiles( BOOLEAN currentOnly, IMAPI_PROFILE_TYPE **profileTypes, ULONG_IMAPI2_ALL_PROFILES *validProfiles );
		void GetSupportedProfiles([MarshalAs(UnmanagedType.U1)] bool currentOnly, out SafeCoTaskMemHandle profileTypes, out uint validProfiles);

		/// <summary>Retrieves the supported mode pages for the device.</summary>
		/// <param name="requestType">
		/// Type of mode page data to retrieve, for example, the current settings or the settings that are write enabled. For possible
		/// values, see the IMAPI_MODE_PAGE_REQUEST_TYPE enumeration type.
		/// </param>
		/// <param name="modePageTypes">
		/// <para>Data buffer that contains one or more mode page types. For possible values, see the IMAPI_MODE_PAGE_TYPE enumeration type.</para>
		/// <para>To get the mode page data associated with the mode page type, call the IDiscRecorder2Ex::GetModePage method.</para>
		/// <para>When done, call the <c>CoTaskMemFree</c> function to free the memory.</para>
		/// </param>
		/// <param name="validPages">Number of mode pages in the data buffer.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-getsupportedmodepages HRESULT
		// GetSupportedModePages( IMAPI_MODE_PAGE_REQUEST_TYPE requestType, IMAPI_MODE_PAGE_TYPE **modePageTypes,
		// ULONG_IMAPI2_ALL_MODE_PAGES *validPages );
		void GetSupportedModePages(IMAPI_MODE_PAGE_REQUEST_TYPE requestType, out SafeCoTaskMemHandle modePageTypes, out uint validPages);

		/// <summary>Retrieves the byte alignment mask for the device.</summary>
		/// <returns>
		/// Byte alignment mask that you use to determine if the buffer is aligned to the correct byte boundary for the device. The byte
		/// alignment value is always a number that is a power of 2.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The data buffer for IDiscRecorder2Ex::SendCommandSendDataToDevice and IDiscRecorder2Ex::SendCommandGetDataFromDevice must
		/// aligned to the correct byte boundary. To determine if the buffer is on the correct byte boundary, perform a bitwise logical AND
		/// of the bitmask with the address of the data buffer. For example, if the address of the buffer is 0x3840958, you can test for
		/// correct alignment using the following statement:
		/// </para>
		/// <para>
		/// <code>if (0x3840958 &amp; (value - 1) == 0) { // The alignment is correct }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-getbytealignmentmask HRESULT
		// GetByteAlignmentMask( ULONG *value );
		uint GetByteAlignmentMask();

		/// <summary>Retrieves the maximum non-page-aligned transfer size for the device.</summary>
		/// <returns>Maximum size, in bytes, of a non-page-aligned buffer.</returns>
		/// <remarks>
		/// This is the maximum buffer size that a device can accept for a single command. Buffers of this size provide the maximum exchange
		/// of data. The buffer does not need to begin on a physical memory page boundary.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-getmaximumnonpagealignedtransfersize HRESULT
		// GetMaximumNonPageAlignedTransferSize( ULONG *value );
		uint GetMaximumNonPageAlignedTransferSize();

		/// <summary>Retrieves the maximum page-aligned transfer size for the device.</summary>
		/// <returns>Maximum size, in bytes, of a page-aligned buffer.</returns>
		/// <remarks>
		/// Maximum page-aligned buffer size that a device can accept for a single command. The buffer for this transfer size must begin on
		/// a physical memory page boundary.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-getmaximumpagealignedtransfersize HRESULT
		// GetMaximumPageAlignedTransferSize( ULONG *value );
		uint GetMaximumPageAlignedTransferSize();
	}

	/// <summary>Reads a DVD structure from the media.</summary>
	/// <param name="obj">The <see cref="IDiscRecorder2Ex"/> instance.</param>
	/// <param name="format">
	/// <para>Format field of the command packet. Acceptable values range from zero to 0xFF.</para>
	/// <para><c>Note</c> This value is truncated to <c>UCHAR</c>.</para>
	/// </param>
	/// <param name="address">Address field of the command packet.</param>
	/// <param name="layer">Layer field of the command packet.</param>
	/// <param name="agid">Authentication grant ID (AGID) field of the command packet.</param>
	/// <returns>
	/// <para>
	/// Data buffer that contains the DVD structure. For details of the contents of the data buffer, see the READ DISC STRUCTURE command
	/// in the latest revision of the MMC specification at ftp://ftp.t10.org/t10/drafts/mmc5.
	/// </para>
	/// <para>This method removes headers from the buffer.</para>
	/// </returns>
	/// <remarks>
	/// This method removes the complexity of working with the READ DISC STRUCTURE command. For details on the values to specify for the
	/// format, address, layer, and agid parameters, see their field descriptions for the READ DISC STRUCTURE command in the latest
	/// revision of the MMC specification at ftp://ftp.t10.org/t10/drafts/mmc5.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscrecorder2ex-readdvdstructure HRESULT ReadDvdStructure(
	// ULONG format, ULONG address, ULONG layer, ULONG agid, BYTE **data, ULONG_IMAPI2_DVD_STRUCTURE *count );
	public static byte[] ReadDvdStructure(this IDiscRecorder2Ex obj, byte format, uint address, uint layer, uint agid)
	{
		obj.ReadDvdStructure(format, address, layer, agid, out var mem, out var sz);
		return mem.GetBytes(0, (int)sz);
	}

	/// <summary>
	/// <para>This is a base interface. Use the following interfaces which inherit this interface:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>IDiscFormat2Data</term>
	/// </item>
	/// <item>
	/// <term>IDiscFormat2Erase</term>
	/// </item>
	/// <item>
	/// <term>IDiscFormat2TrackAtOnce</term>
	/// </item>
	/// <item>
	/// <term>IDiscFormat2RawCD</term>
	/// </item>
	/// </list>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-idiscformat2
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IDiscFormat2")]
	[ComImport, Guid("27354152-8F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IDiscFormat2
	{
		/// <summary>Determines if the recorder supports the given format.</summary>
		/// <param name="recorder">An IDiscRecorder2 interface of the recorder to test.</param>
		/// <returns>Is VARIANT_TRUE if the recorder supports the given format; otherwise, VARIANT_FALSE.</returns>
		/// <remarks>
		/// When implemented by the IDiscFormat2RawCD interface, this method will return E_IMAPI_DF2RAW_MEDIA_IS_NOT_SUPPORTED in the event
		/// the recorder does not support the given format. It is important to note that in this specific scenario the value does not
		/// indicate that an error has occurred, but rather the result of a successful operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-isrecordersupported HRESULT IsRecorderSupported(
		// IDiscRecorder2 *recorder, VARIANT_BOOL *value );
		[DispId(2048)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool IsRecorderSupported(IDiscRecorder2 recorder);

		/// <summary>Determines if the current media in a supported recorder supports the given format.</summary>
		/// <param name="recorder">An IDiscRecorder2 interface of the recorder to test.</param>
		/// <returns>
		/// <para>Is VARIANT_TRUE if the media in the recorder supports the given format; otherwise, VARIANT_FALSE.</para>
		/// <para><c>Note</c> VARIANT_TRUE also implies that the result from IsDiscRecorderSupported is VARIANT_TRUE.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-iscurrentmediasupported HRESULT
		// IsCurrentMediaSupported( IDiscRecorder2 *recorder, VARIANT_BOOL *value );
		[DispId(2049)]
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool IsCurrentMediaSupported(IDiscRecorder2 recorder);

		/// <summary>Determines if the current media is reported as physically blank by the drive.</summary>
		/// <value>Is VARIANT_TRUE if the disc is physically blank; otherwise, VARIANT_FALSE.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-get_mediaphysicallyblank HRESULT
		// get_MediaPhysicallyBlank( VARIANT_BOOL *value );
		[DispId(1792)]
		bool MediaPhysicallyBlank { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Attempts to determine if the media is blank using heuristics (mainly for DVD+RW and DVD-RAM media).</summary>
		/// <value>Is VARIANT_TRUE if the disc is likely to be blank; otherwise; VARIANT_FALSE.</value>
		/// <remarks>
		/// <para>
		/// This method checks, for example, for a mounted file system on the device, verifying the first and last 2MB of the disc are
		/// filled with zeros, and other media-specific checks. These checks can help to determine if the media may have files on it for
		/// media that cannot be erased physically to a blank status.
		/// </para>
		/// <para>For a positive check that a disc is blank, call the IDiscFormat2::get_MediaPhysicallyBlank method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-get_mediaheuristicallyblank HRESULT
		// get_MediaHeuristicallyBlank( VARIANT_BOOL *value );
		[DispId(1793)]
		bool MediaHeuristicallyBlank { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the media types that are supported by the current implementation of the IDiscFormat2 interface.</summary>
		/// <value>
		/// List of media types supported by the current implementation of the IDiscFormat2 interface. Each element of the array is a
		/// <c>VARIANT</c> of type <c>VT_I4</c>. The <c>lVal</c> member of <c>VARIANT</c> contains the media type. For a list of media
		/// types, see the IMAPI_MEDIA_PHYSICAL_TYPE enumeration type.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-idiscformat2-get_supportedmediatypes HRESULT
		// get_SupportedMediaTypes( SAFEARRAY **value );
		[DispId(1794)]
		IMAPI_MEDIA_PHYSICAL_TYPE[] SupportedMediaTypes { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<IMAPI_MEDIA_PHYSICAL_TYPE>))] get; }
	}

	/// <summary>
	/// <para>Base interface containing properties common to derived multisession interfaces.</para>
	/// <para>
	/// You can derive from this interface to implement a new multi-session mechanism that is different from IMultisessionSequential and
	/// IMultisessionRandomWrite. For example, you could implement a mechanism for BD-R Pseudo-Overwrite.
	/// </para>
	/// <para>
	/// To access media-specific properties of a multisession interface, use the IMultisessionSequential and IMultisessionRandomWrite interface.
	/// </para>
	/// </summary>
	/// <remarks>
	/// If more than one multi-session interface exist, the application can let IFileSystemImage choose a compatible multi-session interface
	/// to use or the application can specify the multi-session interface to use by setting the put_InUse property to VARIANT_TRUE.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-imultisession
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IMultisession")]
	[ComImport, Guid("27354150-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IMultisession
	{
		/// <summary>Determines if the multi-session type can write to the current optical media.</summary>
		/// <value>
		/// Is VARIANT_TRUE if the multi-session interface can write to the current optical media in its current state. Otherwise, VARIANT_FALSE.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisession-get_issupportedoncurrentmediastate HRESULT
		// get_IsSupportedOnCurrentMediaState( VARIANT_BOOL *value );
		[DispId(0x100)]
		bool IsSupportedOnCurrentMediaState { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Determines if this multi-session interface is the one you should use on the current media.</summary>
		/// <value>
		/// Set to VARIANT_TRUE if this multi-session interface is the one you should use to write to the current media. Otherwise, VARIANT_FALSE.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisession-put_inuse HRESULT put_InUse( VARIANT_BOOL value );
		[DispId(0x101)]
		bool InUse { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the disc recorder to use to import one or more previous sessions.</summary>
		/// <value>An IDiscRecorder2 interface that identifies the device that contains one or more session images to import.</value>
		/// <remarks>The import recorder reads session content from the optical media and provides it to IFileSystemImage.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisession-get_importrecorder HRESULT get_ImportRecorder(
		// IDiscRecorder2 **value );
		[DispId(0x102)]
		IDiscRecorder2 ImportRecorder { [return: MarshalAs(UnmanagedType.Interface)] get; }
	}

	/// <summary>
	/// <para>
	/// Use this interface to retrieve information about the current state of media allowing random writes and not supporting the concept of
	/// physical sessions.
	/// </para>
	/// <para>The following methods return a collection of IMultisession interfaces representing all supported multisession types.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>IDiscFormat2Data::get_MultisessionInterfaces</term>
	/// </item>
	/// <item>
	/// <term>IFileSystemImage::get_MultisessionInterfaces</term>
	/// </item>
	/// </list>
	/// <para>
	/// You can then call the IUnknown::QueryInterface method on each element in the collection to query for the
	/// <c>IMultisessionRandomWrite</c> interface.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// If more than one multi-session interface exist, the application can let IFileSystemImage choose a compatible multi-session interface
	/// to use or the application can specify the multi-session interface to use by setting the put_InUse property to <c>VARIANT_TRUE</c>.
	/// </para>
	/// <para>
	/// A file system creator would use the address properties to import the content of the previous session on the disc and to compute the
	/// position of the next session it will create. These properties will return the same values as the properties of the same name of the
	/// IDiscFormat2Data interface. This is a <c>MsftMultisessionRandomWrite</c> object in script.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-imultisessionrandomwrite
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IMultisessionRandomWrite")]
	[ComImport, Guid("B507CA23-2204-11DD-966A-001AA01BBC58"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftMultisessionRandomWrite))]
	public interface IMultisessionRandomWrite : IMultisession
	{
		/// <summary>Determines if the multi-session type can write to the current optical media.</summary>
		/// <value>
		/// Is VARIANT_TRUE if the multi-session interface can write to the current optical media in its current state. Otherwise, VARIANT_FALSE.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisession-get_issupportedoncurrentmediastate HRESULT
		// get_IsSupportedOnCurrentMediaState( VARIANT_BOOL *value );
		[DispId(0x100)]
		new bool IsSupportedOnCurrentMediaState { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Determines if this multi-session interface is the one you should use on the current media.</summary>
		/// <value>
		/// Set to VARIANT_TRUE if this multi-session interface is the one you should use to write to the current media. Otherwise, VARIANT_FALSE.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisession-put_inuse HRESULT put_InUse( VARIANT_BOOL value );
		[DispId(0x101)]
		new bool InUse { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the disc recorder to use to import one or more previous sessions.</summary>
		/// <value>An IDiscRecorder2 interface that identifies the device that contains one or more session images to import.</value>
		/// <remarks>The import recorder reads session content from the optical media and provides it to IFileSystemImage.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisession-get_importrecorder HRESULT get_ImportRecorder(
		// IDiscRecorder2 **value );
		[DispId(0x102)]
		new IDiscRecorder2 ImportRecorder { [return: MarshalAs(UnmanagedType.Interface)] get; }

		/// <summary>Retrieves the size of a writeable unit on the media.</summary>
		/// <value>The size of a writeable unit on the media.</value>
		/// <remarks>
		/// Each write performed to the disc must start from an LBA that is a multiple of the writeable unit size. The number of recorded
		/// sectors must also be a multiple of the writeable unit size.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisessionrandomwrite-get_writeunitsize HRESULT
		// get_WriteUnitSize( LONG *value );
		[DispId(0x205)]
		int WriteUnitSize { get; }

		/// <summary>Retrieves the last written address on the media.</summary>
		/// <value>The last written address on the media.</value>
		/// <remarks>
		/// This property can be used for wear-out leveling on the media. The property is retrieved from the drive and may not be provided
		/// for some media types. If the drive does not provide the required information, this property access method returns <c>E_NOTIMPL</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisessionrandomwrite-get_lastwrittenaddress HRESULT
		// get_LastWrittenAddress( LONG *value );
		[DispId(0x206)]
		int LastWrittenAddress { get; }

		/// <summary>Retrieves the total number of sectors on the media.</summary>
		/// <value>The total number of sectors on the media.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisessionrandomwrite-get_totalsectorsonmedia HRESULT
		// get_TotalSectorsOnMedia( LONG *value );
		[DispId(0x207)]
		int TotalSectorsOnMedia { get; }
	}

	/// <summary>
	/// <para>
	/// Use this interface to retrieve information about the previous import session on a sequentially recorded media, if the media
	/// contains a previous session.
	/// </para>
	/// <para>The following methods return a collection of IMultisession interfaces representing all supported multisession types.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>IDiscFormat2Data::get_MultisessionInterfaces</term>
	/// </item>
	/// <item>
	/// <term>IFileSystemImage::get_MultisessionInterfaces</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>IMultisession::QueryInterface</c> method can be called on each element in the collection to query for the
	/// <c>IMultisessionSequential</c> interface.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// If more than one multi-session interface exist, the application can let IFileSystemImage choose a compatible multi-session
	/// interface to use or the application can specify the multi-session interface to use by setting the put_InUse property to VARIANT_TRUE.
	/// </para>
	/// <para>
	/// A file system creator would use the address properties to import the content of the previous session on the disc and to compute
	/// the position of the next session it will create. These properties will return the same values as the properties of the same name
	/// of the IDiscFormat2Data interface.
	/// </para>
	/// <para>This is a <c>MsftMultisessionSequential</c> object in script.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-imultisessionsequential
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IMultisessionSequential")]
	[ComImport, Guid("27354151-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftMultisessionSequential))]
	public interface IMultisessionSequential : IMultisession
	{
		/// <summary>Determines if the multi-session type can write to the current optical media.</summary>
		/// <value>
		/// Is VARIANT_TRUE if the multi-session interface can write to the current optical media in its current state. Otherwise, VARIANT_FALSE.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisession-get_issupportedoncurrentmediastate HRESULT
		// get_IsSupportedOnCurrentMediaState( VARIANT_BOOL *value );
		[DispId(0x100)]
		new bool IsSupportedOnCurrentMediaState { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Determines if this multi-session interface is the one you should use on the current media.</summary>
		/// <value>
		/// Set to VARIANT_TRUE if this multi-session interface is the one you should use to write to the current media. Otherwise, VARIANT_FALSE.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisession-put_inuse HRESULT put_InUse( VARIANT_BOOL value );
		[DispId(0x101)]
		new bool InUse { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the disc recorder to use to import one or more previous sessions.</summary>
		/// <value>An IDiscRecorder2 interface that identifies the device that contains one or more session images to import.</value>
		/// <remarks>The import recorder reads session content from the optical media and provides it to IFileSystemImage.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisession-get_importrecorder HRESULT get_ImportRecorder(
		// IDiscRecorder2 **value );
		[DispId(0x102)]
		new IDiscRecorder2 ImportRecorder { [return: MarshalAs(UnmanagedType.Interface)] get; }

		/// <summary>Determines if this session is the first data session on the media.</summary>
		/// <value>Is VARIANT_TRUE if the session is the first data session on the media. Otherwise, the value is VARIANT_FALSE.</value>
		/// <remarks>
		/// This property is relevant on CD media that combine audio and data tracks/sessions, such as CD Extra and Mixed-Mode CD.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisessionsequential-get_isfirstdatasession HRESULT
		// get_IsFirstDataSession( VARIANT_BOOL *value );
		[DispId(0x200)]
		bool IsFirstDataSession { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the first sector written in the previous session on the media.</summary>
		/// <value>Sector number that identifies the starting point of the previous write session.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisessionsequential-get_startaddressofprevioussession
		// HRESULT get_StartAddressOfPreviousSession( LONG *value );
		[DispId(0x201)]
		int StartAddressOfPreviousSession { get; }

		/// <summary>Retrieves the last sector of the previous write session.</summary>
		/// <value>
		/// <para>Address where the previous write operation ended.</para>
		/// <para>
		/// The value is -1 if the media is blank or does not support multi-session writing (indicates that no previous session could be detected).
		/// </para>
		/// </value>
		/// <remarks>
		/// <c>Note</c> This property should not be used. Instead, you should use an interface derived from IMultisession, such as
		/// IMultisessionSequential, for importing file data from the previous session.
		/// </remarks>
		// https://docs.microsoft.com/th-th/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_lastwrittenaddressofprevioussession
		// HRESULT get_LastWrittenAddressOfPreviousSession( LONG *value );
		[DispId(0x202)]
		int LastWrittenAddressOfPreviousSession { get; }

		/// <summary>Retrieves the next writable address on the media, including used sectors.</summary>
		/// <value>Sector number that identifies the next available sector that can record data or audio.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisessionsequential-get_nextwritableaddress HRESULT
		// get_NextWritableAddress( LONG *value );
		[DispId(0x203)]
		int NextWritableAddress { get; }

		/// <summary>Retrieves the number of free sectors available on the media.</summary>
		/// <value>Number of sectors on the disc that are available for use.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisessionsequential-get_freesectorsonmedia HRESULT
		// get_FreeSectorsOnMedia( LONG *value );
		[DispId(0x204)]
		int FreeSectorsOnMedia { get; }
	}

	/// <summary>Use this interface to retrieve information about the size of a writeable unit on sequentially recorded media.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-imultisessionsequential2
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IMultisessionSequential2")]
	[ComImport, Guid("27354151-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftMultisessionSequential))]
	public interface IMultisessionSequential2 : IMultisessionSequential
	{
		/// <summary>Determines if the multi-session type can write to the current optical media.</summary>
		/// <value>
		/// Is VARIANT_TRUE if the multi-session interface can write to the current optical media in its current state. Otherwise, VARIANT_FALSE.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisession-get_issupportedoncurrentmediastate HRESULT
		// get_IsSupportedOnCurrentMediaState( VARIANT_BOOL *value );
		[DispId(0x100)]
		new bool IsSupportedOnCurrentMediaState { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Determines if this multi-session interface is the one you should use on the current media.</summary>
		/// <value>
		/// Set to VARIANT_TRUE if this multi-session interface is the one you should use to write to the current media. Otherwise, VARIANT_FALSE.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisession-put_inuse HRESULT put_InUse( VARIANT_BOOL value );
		[DispId(0x101)]
		new bool InUse { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the disc recorder to use to import one or more previous sessions.</summary>
		/// <value>An IDiscRecorder2 interface that identifies the device that contains one or more session images to import.</value>
		/// <remarks>The import recorder reads session content from the optical media and provides it to IFileSystemImage.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisession-get_importrecorder HRESULT get_ImportRecorder(
		// IDiscRecorder2 **value );
		[DispId(0x102)]
		new IDiscRecorder2 ImportRecorder { [return: MarshalAs(UnmanagedType.Interface)] get; }

		/// <summary>Determines if this session is the first data session on the media.</summary>
		/// <value>Is VARIANT_TRUE if the session is the first data session on the media. Otherwise, the value is VARIANT_FALSE.</value>
		/// <remarks>
		/// This property is relevant on CD media that combine audio and data tracks/sessions, such as CD Extra and Mixed-Mode CD.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisessionsequential-get_isfirstdatasession HRESULT
		// get_IsFirstDataSession( VARIANT_BOOL *value );
		[DispId(0x200)]
		new bool IsFirstDataSession { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the first sector written in the previous session on the media.</summary>
		/// <value>Sector number that identifies the starting point of the previous write session.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisessionsequential-get_startaddressofprevioussession
		// HRESULT get_StartAddressOfPreviousSession( LONG *value );
		[DispId(0x201)]
		new int StartAddressOfPreviousSession { get; }

		/// <summary>Retrieves the last sector of the previous write session.</summary>
		/// <value>
		/// <para>Address where the previous write operation ended.</para>
		/// <para>
		/// The value is -1 if the media is blank or does not support multi-session writing (indicates that no previous session could be detected).
		/// </para>
		/// </value>
		/// <remarks>
		/// <c>Note</c> This property should not be used. Instead, you should use an interface derived from IMultisession, such as
		/// IMultisessionSequential, for importing file data from the previous session.
		/// </remarks>
		// https://docs.microsoft.com/th-th/windows/win32/api/imapi2/nf-imapi2-idiscformat2data-get_lastwrittenaddressofprevioussession
		// HRESULT get_LastWrittenAddressOfPreviousSession( LONG *value );
		[DispId(0x202)]
		new int LastWrittenAddressOfPreviousSession { get; }

		/// <summary>Retrieves the next writable address on the media, including used sectors.</summary>
		/// <value>Sector number that identifies the next available sector that can record data or audio.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisessionsequential-get_nextwritableaddress HRESULT
		// get_NextWritableAddress( LONG *value );
		[DispId(0x203)]
		new int NextWritableAddress { get; }

		/// <summary>Retrieves the number of free sectors available on the media.</summary>
		/// <value>Number of sectors on the disc that are available for use.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisessionsequential-get_freesectorsonmedia HRESULT
		// get_FreeSectorsOnMedia( LONG *value );
		[DispId(0x204)]
		new int FreeSectorsOnMedia { get; }

		/// <summary>Retrieves the size of a writeable unit on the media.</summary>
		/// <value>The size of a writeable unit on the media in sectors.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-imultisessionsequential2-get_writeunitsize
		// HRESULT get_WriteUnitSize( LONG *value );
		[DispId(0x205)]
		int WriteUnitSize { get; }
	}

	/// <summary>
	/// <para>
	/// Use this interface to create a RAW CD image for use in writing to CD media in Disc-at-Once (DAO) mode. Images created with this
	/// interface can be written to CD media using the IDiscFormat2RawCD interface.
	/// </para>
	/// <para>
	/// To create an instance of this interface, call the <c>CoCreateInstance</c> function. Use__uuidof(MsftRawCDImageCreator) for the class
	/// identifier and __uuidof(IRawCDImageCreator) for the interface identifier.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Images created with this interface can be written to persistent storage for later use, or can be provided directly to the
	/// IDiscFormat2RawCD interface for writing to CD media.
	/// </para>
	/// <para>DVD media does not support this type of writing.</para>
	/// <para>
	/// This interface is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
	/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7 and
	/// Windows Server 2008 R2.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-irawcdimagecreator
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IRawCDImageCreator")]
	[ComImport, Guid("25983550-9D65-49CE-B335-40630D901227"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftRawCDImageCreator))]
	public interface IRawCDImageCreator
	{
		/// <summary>Creates the final <c>IStream</c> object based on the current settings.</summary>
		/// <returns>Pointer to the finalized IStream object.</returns>
		/// <remarks>
		/// <para>
		/// <c>IRawCDImageCreator::CreateResultImage</c> can only be called once, and will result in the object becoming read-only. All
		/// properties associated with this object can be read but not modified. The resulting <c>IStream</c> object will be a disc image
		/// which starts at MSF 95:00:00, to allow writing of a single image to media with multiple starting addresses.
		/// </para>
		/// <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagecreator-createresultimage HRESULT
		// CreateResultImage( IStream **resultStream );
		[DispId(0x200)]
		IStream CreateResultImage();

		/// <summary>Accepts the provided <c>IStream</c> object and saves the interface pointer as the next track in the image.</summary>
		/// <param name="dataType">
		/// A value, defined by IMAPI_CD_SECTOR_TYPE, that indicates the type of data. <c>IMAPI_CD_SECTOR_AUDIO</c> is the only value
		/// supported by the <c>IRawCDImageCreator::AddTrack</c> method.
		/// </param>
		/// <param name="data">Pointer to the provided <c>IStream</c> object.</param>
		/// <returns>A <c>LONG</c> value within a 1 to 99 range that will be associated with the new track.</returns>
		/// <remarks>
		/// <para>
		/// Any additional tracks must be compatible with all existing tracks. See the IMAPI_CD_SECTOR_TYPE enumeration for information on limitations.
		/// </para>
		/// <para>
		/// The data stream must be at least 4 seconds (300 sectors) long. Data stream may not cause final sector to exceed LBA 398,099 (MSF
		/// 88:29:74), as leadout would then exceed the MSF 89:59:74 maximum.
		/// </para>
		/// <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagecreator-addtrack HRESULT AddTrack(
		// IMAPI_CD_SECTOR_TYPE dataType, IStream *data, LONG *trackIndex );
		[DispId(0x201)]
		int AddTrack(IMAPI_CD_SECTOR_TYPE dataType, IStream data);

		/// <summary>
		/// Accepts the provided <c>IStream</c> object and saves the associated pointer to be used as data for the pre-gap for track 1.
		/// </summary>
		/// <param name="data">Pointer to the provided <c>IStream</c> object.</param>
		/// <remarks>
		/// <para>
		/// This method can only be called prior to adding any tracks to the image. The data stream must be at least 2 seconds (or 150
		/// sectors) long.
		/// </para>
		/// <para>
		/// The data stream should not result final sector exceeding LBA 397,799 (MSF 88:25:74), as the minimal-sized track plus leadout
		/// would then exceed the MSF 89:59:74 maximum. Additionally, it is recommended that the IMAPI_CD_SECTOR_TYPE value for the first
		/// track is implicitly defined as "Audio". The resulting audio can then only be heard by playing the first track and "rewinding"
		/// back to the start of the audio disc.
		/// </para>
		/// <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagecreator-addspecialpregap HRESULT AddSpecialPregap(
		// IStream *data );
		[DispId(0x202)]
		void AddSpecialPregap(IStream data);

		/// <summary>
		/// Allows the addition of custom R-W subcode, provided by the <c>IStream</c>. The provided object must have a size equal to the
		/// number of sectors in the raw disc image * 96 bytes when the final image is created.
		/// </summary>
		/// <param name="subcode">
		/// The subcode data (with 96 bytes per sector), where the 2 most significant bits must always be zero (as they are the P/Q bits).
		/// </param>
		/// <remarks>
		/// <para>
		/// May be added anytime prior to calling IRawCDImageCreator::CreateResultImage. If IRawCDImageCreator::put_ResultingImageType is
		/// set to return PQ only, then this call will fail as no RW subcode will be used in the resulting image.
		/// </para>
		/// <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagecreator-addsubcoderwgenerator HRESULT
		// AddSubcodeRWGenerator( IStream *subcode );
		[DispId(0x203)]
		void AddSubcodeRWGenerator(IStream? subcode);

		/// <summary>Gets or sets the value that defines the type of image file that will be generated.</summary>
		/// <value>An IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE enumeration that defines the type of image file.</value>
		/// <remarks>
		/// <para>
		/// If the value set via IRawCDImageCreator::AddSubcodeRWGenerator is not <c>NULL</c>, then the <c>PQ_ONLY</c> type defined by
		/// IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE is not a valid choice, as subcode would not be generated by the resulting image.
		/// </para>
		/// <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagecreator-put_resultingimagetype HRESULT
		// put_ResultingImageType( IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE value );
		[DispId(0x100)]
		IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE ResultingImageType { set; get; }

		/// <summary>
		/// Retrieves the value that defines the LBA for the start of the Leadout. This method can be utilized to determine if the image can
		/// be written to a piece of media by comparing it against the <c>LastPossibleStartOfLeadout</c> for the media.
		/// </summary>
		/// <value>Pointer to a <c>LONG</c> value that represents the LBA for the start of the Leadout.</value>
		/// <remarks>
		/// <para>Use of this method requires that at least 1 track has been added to the image.</para>
		/// <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagecreator-get_startofleadout HRESULT
		// get_StartOfLeadout( LONG *value );
		[DispId(0x101)]
		int StartOfLeadout { get; }

		/// <summary>
		/// Gets or sets the StartOfLeadoutLimit property value. This value specifies if the resulting image is required to fit on a piece
		/// of media with a <c>StartOfLeadout</c> greater than or equal to the LBA specified.
		/// </summary>
		/// <value>Pointer to a <c>LONG</c> value that represents the current StartOfLeadoutLimit.</value>
		/// <remarks>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagecreator-put_startofleadoutlimit HRESULT
		// put_StartOfLeadoutLimit( LONG value );
		[DispId(0x102)]
		int StartOfLeadoutLimit { set; get; }

		/// <summary>
		/// Gets or sets the value that specifies if "Gapless Audio" recording is disabled. This property defaults to a value of
		/// <c>VARIANT_FALSE</c>, which disables the use of "gapless" recording between consecutive audio tracks.
		/// </summary>
		/// <value>
		/// A <c>VARIANT_BOOL</c> value that specifies if "Gapless Audio" is disabled. Setting a value of <c>VARIANT_FALSE</c> disables
		/// "Gapless Audio", while <c>VARIANT_TRUE</c> enables it.
		/// </value>
		/// <remarks>
		/// <para>
		/// When disabled, by default, the audio tracks will have the standard 2-second (150 sector) silent gap between tracks. When
		/// enabled, the last 2 seconds of audio data from the previous audio track are encoded in the pregap area of the next audio track,
		/// enabling seamless transitions between tracks.
		/// </para>
		/// <para>
		/// It is recommended that this property value is only set before the process of adding tracks to the image has begun as any changes
		/// afterwards could result in adverse effects to other image properties.
		/// </para>
		/// <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagecreator-put_disablegaplessaudio HRESULT
		// put_DisableGaplessAudio( VARIANT_BOOL value );
		[DispId(0x103)]
		bool DisableGaplessAudio { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Gets or sets the Media Catalog Number (MCN) for the entire audio disc.</summary>
		/// <value>A <c>BSTR</c> value that represents the MCN to associate with the audio disc.</value>
		/// <remarks>
		/// <para>
		/// The returned MCN is formatted as a 13-digit decimal number and must also be provided in the same form. Additionally, the
		/// provided MCN value must have a valid checksum digit (least significant digit), or it will be rejected. For improved
		/// compatibility with scripting, leading zeros may be excluded. For example, "0123456789012" can be expressed as "123456789012".
		/// </para>
		/// <para>Please refer to the MMC specification for details regarding the MCN value.</para>
		/// <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagecreator-put_mediacatalognumber HRESULT
		// put_MediaCatalogNumber( BSTR value );
		[DispId(0x104)]
		string MediaCatalogNumber { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>Gets or sets the starting track number.</summary>
		/// <value>A <c>LONG</c> value that represents the starting track number.</value>
		/// <remarks>
		/// <para>
		/// This property value can only be set before the addition of tracks. If this property is set to a value other than 1, all tracks
		/// added to the image must be audio tracks.
		/// </para>
		/// <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagecreator-put_startingtracknumber HRESULT
		// put_StartingTrackNumber( LONG value );
		[DispId(0x105)]
		int StartingTrackNumber { set; get; }

		/// <summary>
		/// Retrieves an indexed property, which takes a <c>LONG</c> value with a range of 1 to 99 as the index to determine which track the
		/// user is querying. The returned object is then queried/set for the particular per-track property of interest.
		/// </summary>
		/// <param name="trackIndex">A <c>LONG</c> value within a 1 to 99 range that is used to specify which track is queried.</param>
		/// <returns>
		/// A pointer to a pointer to an IRawCDImageTrackInfo object that contains information about the track associated with the specified
		/// trackInfo index value.
		/// </returns>
		/// <remarks>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagecreator-get_trackinfo HRESULT get_TrackInfo( LONG
		// trackIndex, IRawCDImageTrackInfo **value );
		[DispId(0x106)]
		IRawCDImageTrackInfo get_TrackInfo(int trackIndex);

		/// <summary>Retrieves the number of existing audio tracks on the media.</summary>
		/// <value>Pointer to a <c>LONG</c> value that indicates the number of audio tracks that currently exist on the media.</value>
		/// <remarks>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagecreator-get_numberofexistingtracks HRESULT
		// get_NumberOfExistingTracks( LONG *value );
		[DispId(0x107)]
		int NumberOfExistingTracks { get; }

		/// <summary>Retrieves the number of total used sectors on the current media, including any overhead between existing tracks.</summary>
		/// <value>Pointer to a <c>LONG</c> value that indicates the number of total used sectors on the media.</value>
		/// <remarks>
		/// <para>
		/// This value represents the LBA of the last sector with data that is considered part of a track, and does not include the overhead
		/// of the leadin, leadout, or the two-seconds between MSF 00:00:00 and MSF 00:02:00.
		/// </para>
		/// <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagecreator-get_lastusedusersectorinimage HRESULT
		// get_LastUsedUserSectorInImage( LONG *value );
		[DispId(0x108)]
		int LastUsedUserSectorInImage { get; }

		/// <summary>Gets the SCSI-form table of contents for the resulting disc.</summary>
		/// <value>
		/// The SCSI-form table of contents for the resulting disc. Accuracy of this value depends on
		/// <c>IRawCDImageCreator::get_ExpectedTableOfContents</c> being called after all image properties have been set.
		/// </value>
		/// <remarks>
		/// <para>This method can only be called after at least one track has been added to the image.</para>
		/// <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagecreator-get_expectedtableofcontents HRESULT
		// get_ExpectedTableOfContents( SAFEARRAY **value );
		[DispId(0x109)]
		object[] ExpectedTableOfContents { get; }
	}

	/// <summary>Use this interface to track per-track properties that are applied to CD media.</summary>
	/// <remarks>
	/// This interface is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
	/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7 and
	/// Windows Server 2008 R2.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-irawcdimagetrackinfo
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IRawCDImageTrackInfo")]
	[ComImport, Guid("25983551-9D65-49CE-B335-40630D901227"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IRawCDImageTrackInfo
	{
		/// <summary>Retrieves the LBA of the first user sectors in this track.</summary>
		/// <value>The LBA of the first user sectors in this track.</value>
		/// <remarks>
		///   <para>Most tracks also include a pregap and postgap, which are not included in this value.</para>
		///   <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagetrackinfo-get_startinglba HRESULT get_StartingLba(
		// LONG *value );
		[DispId(0x100)]
		int StartingLba { get; }

		/// <summary>Retrieves the number of user sectors in this track.</summary>
		/// <value>The number of user sectors in this track.</value>
		/// <remarks>
		///   <para>
		/// The end of the track is typically the <c>StartingLBA</c> plus the <c>SectorCount</c>. The start of the next track includes both
		/// of these properties plus any required pregap or postgap.
		/// </para>
		///   <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagetrackinfo-get_sectorcount HRESULT get_SectorCount(
		// LONG *value );
		[DispId(0x101)]
		int SectorCount { get; }

		/// <summary>Retrieves the track number for this track.</summary>
		/// <value>The track number for this track.</value>
		/// <remarks>
		///   <para>
		/// While this value is often identical to the <c>TrackIndex</c> property, it is possible for pure audio discs to start with a track
		/// other than track number 1. This means that the more general formula is that this value is ( TrackIndex + FirstTrackNumber - 1).
		/// </para>
		///   <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagetrackinfo-get_tracknumber HRESULT get_TrackNumber(
		// LONG *value );
		[DispId(0x102)]
		int TrackNumber { get; }

		/// <summary>
		/// Retrieves the type of data provided for the sectors in this track. For more detail on the possible sector types, see IMAPI_CD_SECTOR_TYPE.
		/// </summary>
		/// <value>
		/// A pointer to a IMAPI_CD_SECTOR_TYPE enumeration that specifies the type of data provided for the sectors on the track.
		/// </value>
		/// <remarks>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagetrackinfo-get_sectortype HRESULT get_SectorType(
		// IMAPI_CD_SECTOR_TYPE *value );
		[DispId(0x103)]
		IMAPI_CD_SECTOR_TYPE SectorType { get; }

		/// <summary>
		/// Gets or sets the International Standard Recording Code (ISRC) currently associated with the track. This property value defaults
		/// to <c>NULL</c> (or a zero-length string) and may only be set for tracks containing audio data.
		/// </summary>
		/// <value>The ISRC to associate with the track.</value>
		/// <remarks>
		/// <para>
		/// The format of the ISRC is provided to the caller formatted per ISRC standards (DIN-31-621) recommendations, such as
		/// "US-K7Y-98-12345". When set, the provided string may optionally exclude all the '-' characters.
		/// </para>
		/// <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagetrackinfo-put_isrc HRESULT put_ISRC( BSTR value );
		[DispId(0x104)]
		string? ISRC { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

		/// <summary>
		/// Sets the digital audio copy "Allowed" bit to one of three values on the resulting media. Please see the
		/// IMAPI_CD_TRACK_DIGITAL_COPY_SETTING enumeration for additional information on each possible value.
		/// </summary>
		/// <value>The digital audio copy setting value to assign.</value>
		/// <remarks>
		/// <para>This property may only be set for tracks containing audio data.</para>
		/// <para>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagetrackinfo-put_digitalaudiocopysetting HRESULT
		// put_DigitalAudioCopySetting( IMAPI_CD_TRACK_DIGITAL_COPY_SETTING value );
		[DispId(0x105)]
		IMAPI_CD_TRACK_DIGITAL_COPY_SETTING DigitalAudioCopySetting { set; get; }

		/// <summary>
		/// Sets the value that specifies if an audio track has an additional pre-emphasis added to the audio data prior to being written to CD.
		/// </summary>
		/// <value>Value that specifies if an audio track has an additional pre-emphasis added to the audio data.</value>
		/// <remarks>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagetrackinfo-put_audiohaspreemphasis HRESULT
		// put_AudioHasPreemphasis( VARIANT_BOOL value );
		[DispId(0x106)]
		bool AudioHasPreemphasis { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the one-based index of the tracks on the disc.</summary>
		/// <value>The one-based index associated with this track.</value>
		/// <remarks>
		/// This method is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
		/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7
		/// and Windows Server 2008 R2.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-irawcdimagetrackinfo-get_trackindexes HRESULT
		// get_TrackIndexes( SAFEARRAY **value );
		[DispId(0x107)]
		int[] TrackIndexes { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SafeArrayMarshaler<int>))] get; }

		/// <summary>Add the specified LBA (relative to the start of the track) as an index.</summary>
		/// <param name="lbaOffset">The LBA to add. This must be a value in the range of 0 and 0x7FFFFFFF.</param>
		[DispId(0x200)]
		void AddTrackIndex(int lbaOffset);

		/// <summary>Removes the specified LBA (relative to the start of the track) as an index.</summary>
		/// <param name="lbaOffset">The LBA to remove. This must be a value in the range of 0 and 0x7FFFFFFF.</param>
		[DispId(0x201)]
		void ClearTrackIndex(int lbaOffset);
	}

	/// <summary>
	/// <para>Use this interface to write a data stream to a device.</para>
	/// <para>
	/// This interface should be used by those developing support for new media types or formats. Writing to media typically includes the
	/// following steps:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>Preparing the hardware by setting mode pages for the media.</term>
	/// </item>
	/// <item>
	/// <term>Querying the hardware to verify that the media is large enough.</term>
	/// </item>
	/// <item>
	/// <term>Initializing the write, for example, by formatting the media or setting OPC.</term>
	/// </item>
	/// <item>
	/// <term>Performing the actual WRITE commands.</term>
	/// </item>
	/// <item>
	/// <term>Finishing the write by stopping the formatting or closing the session or track.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When developing support for new media types, you can implement steps 1, 2, 3, and 5, and use this interface to perform step 4. Note
	/// that all the IDiscFormat2* interfaces use this interface to perform the write operation.
	/// </para>
	/// <para>Most client applications should use the IDiscFormat2Data interface to write images to a device.</para>
	/// <para>
	/// To create an instance of this interface, call the <c>CoCreateInstance</c> function. Use__uuidof(MsftWriteEngine2) for the class
	/// identifier and __uuidof(IWriteEngine2) for the interface identifier.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// To create the <c>MsftWriteEngine2</c> object in a script, use IMAPI2.MsftWriteEngine2 as the program identifier when calling <c>CreateObject</c>.
	/// </para>
	/// <para>
	/// It is possible for a power state transition to take place during a burn operation (i.e. user log-off or system suspend) which leads
	/// to the interruption of the burn process and possible data loss. For programming considerations, see Preventing Logoff or Suspend
	/// During a Burn.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-iwriteengine2
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IWriteEngine2")]
	[ComImport, Guid("27354135-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftWriteEngine2))]
	public interface IWriteEngine2
	{
		/// <summary>Writes a data stream to the current recorder.</summary>
		/// <param name="data">An <c>IStream</c> interface of the data stream to write to the recorder.</param>
		/// <param name="startingBlockAddress">Starting logical block address (LBA) of the write operation. Negative values are supported.</param>
		/// <param name="numberOfBlocks">Number of blocks from the data stream to write.</param>
		/// <remarks>
		/// <para>
		/// Before calling this method, you must call the IWriteEngine2::put_Recorder method to specify the recording device and the
		/// IWriteEngine2::put_BytesPerSector method to specify the number of bytes to use for each sector during writing.
		/// </para>
		/// <para>You should also consider calling the following methods if their default values are not appropriate for your application:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IWriteEngine2::put_EndingSectorsPerSecond</term>
		/// </item>
		/// <item>
		/// <term>IWriteEngine2::put_StartingSectorsPerSecond</term>
		/// </item>
		/// <item>
		/// <term>IWriteEngine2::put_UseStreamingWrite12</term>
		/// </item>
		/// </list>
		/// <para>
		/// This method is synchronous. To determine the progress of the write operation, you must implement the DWriteEngine2Events
		/// interface. For examples that show how to implement an event handler in a script, see Monitoring Progress With Events.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2-writesection HRESULT WriteSection( IStream
		// *data, LONG startingBlockAddress, LONG numberOfBlocks );
		[DispId(0x200)]
		void WriteSection([In, MarshalAs(UnmanagedType.Interface)] IStream data, int startingBlockAddress, int numberOfBlocks);

		/// <summary>Cancels a write operation that is in progress.</summary>
		/// <remarks>
		/// To cancel the write operation, you must call this method from the DWriteEngine2Events::Update event handler that you implemented.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2-cancelwrite HRESULT CancelWrite();
		[DispId(0x201)]
		void CancelWrite();

		/// <summary>Retrieves the recording device to use in the write operation.</summary>
		/// <value>An IDiscRecorder2Ex interface that identifies the recording device to use in the write operation.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2-get_recorder HRESULT get_Recorder(
		// IDiscRecorder2Ex **value );
		[DispId(0x100)]
		IDiscRecorder2Ex Recorder { set; [return: MarshalAs(UnmanagedType.Interface)] get; }

		/// <summary>Sets a value that indicates if the write operations use the WRITE12 or WRITE10 command.</summary>
		/// <value>
		/// Set to VARIANT_TRUE to use the WRITE12 command with the streaming bit set to one when writing to disc. Otherwise, set
		/// VARIANT_FALSE to use the WRITE10 command. The default is VARIANT_FALSE.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2-put_usestreamingwrite12 HRESULT
		// put_UseStreamingWrite12( VARIANT_BOOL value );
		[DispId(0x101)]
		bool UseStreamingWrite12 { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>
		/// Sets the estimated number of sectors per second that the recording device can write to the media at the start of the writing process.
		/// </summary>
		/// <value>
		/// Approximate number of sectors per second that the recording device can write to the media at the start of the writing process.
		/// The default is -1 for maximum speed.
		/// </value>
		/// <remarks>This is used to optimize sleep time in the write engine.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2-put_startingsectorspersecond HRESULT
		// put_StartingSectorsPerSecond( LONG value );
		[DispId(0x102)]
		int StartingSectorsPerSecond { set; get; }

		/// <summary>
		/// Retrieves the estimated number of sectors per second that the recording device can write to the media at the end of the writing process.
		/// </summary>
		/// <value>
		/// <para>Approximate number of sectors per second that the recording device can write to the media at the end of the writing process.</para>
		/// <para>A value of -1 indicates maximum speed.</para>
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2-get_endingsectorspersecond HRESULT
		// get_EndingSectorsPerSecond( LONG *value );
		[DispId(0x103)]
		int EndingSectorsPerSecond { set; get; }

		/// <summary>Sets the number of bytes to use for each sector during writing.</summary>
		/// <value>
		/// Number of bytes to use for each sector during writing. The minimum size is 1 byte and the maximum is MAXLONG bytes. Typically,
		/// this value is 2,048 bytes for CD media, although any arbitrary size is supported (such as 2352 or 2448). This value is limited
		/// to the IDiscRecorder2Ex::GetMaximumPageAlignedTransferSize, which is typically 65,536 (64K) bytes.
		/// </value>
		/// <remarks>You must specify a logical block size.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2-put_bytespersector HRESULT put_BytesPerSector(
		// LONG value );
		[DispId(0x104)]
		int BytesPerSector { set; get; }

		/// <summary>Retrieves a value that indicates whether the recorder is currently writing data to the disc.</summary>
		/// <value>
		/// If VARIANT_TRUE, the recorder is currently writing data to the disc. Otherwise, if VARIANT_FALSE, the recorder is not currently
		/// writing to disc.
		/// </value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2-get_writeinprogress HRESULT
		// get_WriteInProgress( VARIANT_BOOL *value );
		[DispId(0x105)]
		bool WriteInProgress { [return: MarshalAs(UnmanagedType.VariantBool)] get; }
	}

	/// <summary>
	/// Use this interface to retrieve information about the current write operation. This interface is passed to the
	/// DWriteEngine2Events::Update method that you implement.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-iwriteengine2eventargs
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IWriteEngine2EventArgs")]
	[ComImport, Guid("27354136-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IWriteEngine2EventArgs
	{
		/// <summary>Retrieves the starting logical block address (LBA) of the current write operation.</summary>
		/// <value>Starting logical block address of the write operation. Negative values for LBAs are supported.</value>
		/// <remarks>This is the same value passed to the IWriteEngine2::WriteSection method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_startlba HRESULT get_StartLba(
		// LONG *value );
		[DispId(0x100)]
		int StartLba { get; }

		/// <summary>Retrieves the number of sectors to write to the device in the current write operation.</summary>
		/// <value>The number of sectors to write in the current write operation.</value>
		/// <remarks>This is the same value passed to the IWriteEngine2::WriteSection method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_sectorcount HRESULT
		// get_SectorCount( LONG *value );
		[DispId(0x101)]
		int SectorCount { get; }

		/// <summary>Retrieves the address of the sector most recently read from the burn image.</summary>
		/// <value>Logical block address of the sector most recently read from the input data stream.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_lastreadlba HRESULT
		// get_LastReadLba( LONG *value );
		[DispId(0x102)]
		int LastReadLba { get; }

		/// <summary>Retrieves the address of the sector most recently written to the device.</summary>
		/// <value>Logical block address of the sector most recently written to the device.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_lastwrittenlba HRESULT
		// get_LastWrittenLba( LONG *value );
		[DispId(0x103)]
		int LastWrittenLba { get; }

		/// <summary>Retrieves the size of the internal data buffer that is used for writing to disc.</summary>
		/// <value>Size, in bytes, of the internal data buffer that is used for writing to disc.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_totalsystembuffer HRESULT
		// get_TotalSystemBuffer( LONG *value );
		[DispId(0x106)]
		int TotalSystemBuffer { get; }

		/// <summary>Retrieves the number of used bytes in the internal data buffer that is used for writing to disc.</summary>
		/// <value>Size, in bytes, of the used portion of the internal data buffer that is used for writing to disc.</value>
		/// <remarks>This value increases as data is read into the buffer and decreases as data is written to disc.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_usedsystembuffer HRESULT
		// get_UsedSystemBuffer( LONG *value );
		[DispId(0x107)]
		int UsedSystemBuffer { get; }

		/// <summary>Retrieves the number of unused bytes in the internal data buffer that is used for writing to disc.</summary>
		/// <value>Size, in bytes, of the unused portion of the internal data buffer that is used for writing to disc.</value>
		/// <remarks>This method returns the same value as if you subtracted IWriteEngine2EventArgs::get_UsedSystemBuffer from IWriteEngine2EventArgs::get_TotalSystemBuffer.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwriteengine2eventargs-get_freesystembuffer HRESULT
		// get_FreeSystemBuffer( LONG *value );
		[DispId(0x108)]
		int FreeSystemBuffer { get; }
	}

	/// <summary>
	/// <para>
	/// Use this interface retrieve detailed write configurations supported by the disc recorder and current media, for example, the media
	/// type, write speed, rotational-speed control type.
	/// </para>
	/// <para>To get this interface, call one of the following methods:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>IDiscFormat2Data::get_SupportedWriteSpeedDescriptors</term>
	/// </item>
	/// <item>
	/// <term>IDiscFormat2RawCD::get_SupportedWriteSpeedDescriptors</term>
	/// </item>
	/// <item>
	/// <term>IDiscFormat2TrackAtOnce::get_SupportedWriteSpeedDescriptors</term>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>This is a <c>MsftWriteSpeedDescriptor</c> object in script.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nn-imapi2-iwritespeeddescriptor
	[PInvokeData("imapi2.h", MSDNShortId = "NN:imapi2.IWriteSpeedDescriptor")]
	[ComImport, Guid("27354144-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsDual), CoClass(typeof(MsftWriteSpeedDescriptor))]
	public interface IWriteSpeedDescriptor
	{
		/// <summary>Retrieves type of media in the current drive.</summary>
		/// <value>Type of media in the current drive. For possible values, see the IMAPI_MEDIA_PHYSICAL_TYPE enumeration type.</value>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwritespeeddescriptor-get_mediatype HRESULT get_MediaType(
		// IMAPI_MEDIA_PHYSICAL_TYPE *value );
		[DispId(0x101)]
		IMAPI_MEDIA_PHYSICAL_TYPE MediaType { get; }

		/// <summary>Retrieves the supported rotational-speed control used by the recorder for the current media.</summary>
		/// <value>
		/// Is VARIANT_TRUE if constant angular velocity (CAV) rotational-speed control is in use. Otherwise, VARIANT_FALSE to indicate that
		/// another rotational-speed control that the recorder supports is in use.
		/// </value>
		/// <remarks>
		/// <para>Rotational-speed control types include the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>CLV (Constant Linear Velocity). The disc is written at a constant speed. Standard rotational control.</term>
		/// </item>
		/// <item>
		/// <term>CAV (Constant Angular Velocity). The disc is written at a constantly increasing speed.</term>
		/// </item>
		/// <item>
		/// <term>
		/// ZCAV (Zone Constant Linear Velocity). The disc is divided into zones. After each zone, the write speed increases. This is an
		/// impure form of CAV.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// PCAV (Partial Constant Angular Velocity). The disc speed increases up to a specified velocity. Once reached, the disc spins at
		/// the specified velocity for the duration of the disc writing.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwritespeeddescriptor-get_rotationtypeispurecav HRESULT
		// get_RotationTypeIsPureCAV( VARIANT_BOOL *value );
		[DispId(0x102)]
		bool RotationTypeIsPureCAV { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

		/// <summary>Retrieves the supported write speed for writing to the media.</summary>
		/// <value>Write speed of the current media, measured in sectors per second.</value>
		/// <remarks>The write speed is based on the media write speeds. The value of this property can change when a media change occurs.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/nf-imapi2-iwritespeeddescriptor-get_writespeed HRESULT get_WriteSpeed(
		// LONG *value );
		[DispId(0x103)]
		int WriteSpeed { get; }
	}

	/// <summary>CLSID_MsftDiscFormat2Data</summary>
	[ComImport, Guid("2735412A-7F64-5B0F-8F00-5D77AFBE261E"), ClassInterface(ClassInterfaceType.None)]
	public class MsftDiscFormat2Data
	{
	}

	/// <summary>CLSID_MsftDiscFormat2Erase</summary>
	[ComImport, Guid("2735412B-7F64-5B0F-8F00-5D77AFBE261E"), ClassInterface(ClassInterfaceType.None)]
	public class MsftDiscFormat2Erase
	{
	}

	/// <summary>CLSID_MsftDiscFormat2RawCD</summary>
	[ComImport, Guid("27354128-7F64-5B0F-8F00-5D77AFBE261E"), ClassInterface(ClassInterfaceType.None)]
	public class MsftDiscFormat2RawCD
	{
	}

	/// <summary>CLSID_MsftDiscFormat2TrackAtOnce</summary>
	[ComImport, Guid("27354129-7F64-5B0F-8F00-5D77AFBE261E"), ClassInterface(ClassInterfaceType.None)]
	public class MsftDiscFormat2TrackAtOnce
	{
	}

	/// <summary>CLSID_MsftDiscMaster2</summary>
	[ComImport, Guid("2735412E-7F64-5B0F-8F00-5D77AFBE261E"), ClassInterface(ClassInterfaceType.None)]
	public class MsftDiscMaster2
	{
	}

	/// <summary>CLSID_MsftDiscRecorder2</summary>
	[ComImport, Guid("2735412D-7F64-5B0F-8F00-5D77AFBE261E"), ClassInterface(ClassInterfaceType.None)]
	public class MsftDiscRecorder2
	{
	}

	/// <summary>CLSID_MsftMultisessionRandomWrite</summary>
	[ComImport, Guid("B507CA24-2204-11DD-966A-001AA01BBC58"), ClassInterface(ClassInterfaceType.None)]
	public class MsftMultisessionRandomWrite
	{
	}

	/// <summary>CLSID_MsftMultisessionSequential</summary>
	[ComImport, Guid("27354122-7F64-5B0F-8F00-5D77AFBE261E"), ClassInterface(ClassInterfaceType.None)]
	public class MsftMultisessionSequential
	{
	}

	/// <summary>CLSID_MsftRawCDImageCreator</summary>
	[ComImport, Guid("25983561-9D65-49CE-B335-40630D901227"), ClassInterface(ClassInterfaceType.None)]
	public class MsftRawCDImageCreator
	{
	}

	/// <summary>CLSID_MsftWriteEngine2</summary>
	[ComImport, Guid("2735412C-7F64-5B0F-8F00-5D77AFBE261E"), ClassInterface(ClassInterfaceType.None)]
	public class MsftWriteEngine2
	{
	}

	/// <summary>CLSID_MsftWriteSpeedDescriptor</summary>
	[ComImport, Guid("27354123-7F64-5B0F-8F00-5D77AFBE261E"), ClassInterface(ClassInterfaceType.None)]
	public class MsftWriteSpeedDescriptor
	{
	}
}