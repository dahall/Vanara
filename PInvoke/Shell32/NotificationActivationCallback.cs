namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// <para>
	/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
	/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
	/// </para>
	/// <para>Receives notification messages when an app is triggered through a toast from the action center.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/notificationactivationcallback/nn-notificationactivationcallback-inotificationactivationcallback
	[PInvokeData("notificationactivationcallback.h", MSDNShortId = "9DB90C47-6FFA-44CA-8D33-709DD8CDDA29")]
	[ComImport, Guid("53E31837-6600-4A81-9395-75CFFE746F94"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface INotificationActivationCallback
	{
		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>Called when a user interacts with a toast in the action center.</para>
		/// </summary>
		/// <param name="appUserModelId">The unique identifier representing your app to the notification platform.</param>
		/// <param name="invokedArgs">
		/// Arguments from the invoked button. <c>NULL</c> if the toast indicates the default activation and no launch arguments were
		/// specified in the XML payload.
		/// </param>
		/// <param name="data">The data from the input elements available on the notification toast.</param>
		/// <param name="count">The number of data elements.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// In order for your app to respond to toasts in the action center, you need to override this method in your app. You also will
		/// need to create a shortcut on the start menu. For more information about how to respond to activation notifications, see
		/// Respond to toast activations.
		/// </para>
		/// <para>If your application uses non-interactive toasts, you can respond to those without using invokedArgs or data.</para>
		/// <para>If you return a failure code, the activation will fail and the user can try again to activate your app.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/notificationactivationcallback/nf-notificationactivationcallback-inotificationactivationcallback-activate
		// HRESULT Activate( LPCWSTR appUserModelId, LPCWSTR invokedArgs, const NOTIFICATION_USER_INPUT_DATA *data, ULONG count );
		[PreserveSig]
		HRESULT Activate([MarshalAs(UnmanagedType.LPWStr)] string appUserModelId, [MarshalAs(UnmanagedType.LPWStr)] string? invokedArgs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] NOTIFICATION_USER_INPUT_DATA[] data, int count);
	}

	/// <summary>
	/// <para>
	/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
	/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
	/// </para>
	/// <para>
	/// Contains information about how a user interacted with a notification toast in the action center. This structure is used by Activate.
	/// </para>
	/// </summary>
	/// <remarks>
	/// Each key-value pair contains a piece of information based on an item in the notification toast when the Activate callback is triggered.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/notificationactivationcallback/ns-notificationactivationcallback-notification_user_input_data
	// typedef struct NOTIFICATION_USER_INPUT_DATA { LPCWSTR Key; LPCWSTR Value; } NOTIFICATION_USER_INPUT_DATA;
	[PInvokeData("notificationactivationcallback.h", MSDNShortId = "C39B906E-4EB2-4EFF-B0A3-76E6B17A3662")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode), Serializable]
	public struct NOTIFICATION_USER_INPUT_DATA
	{
		/// <summary>The ID of the user input field in the XML payload.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Key;

		/// <summary>The input value selected by the user for a given input field.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Value;
	}
}