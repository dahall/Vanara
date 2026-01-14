namespace Vanara.PInvoke;

/// <summary>Contains all the predefined zones used by Windows Internet Explorer.</summary>
[PInvokeData("urlmon.h")]
public enum URLZONE
{
	/// <summary>Internet Explorer 7. Invalid zone. Used only if no appropriate zone is available.</summary>
	URLZONE_INVALID = -1,

	/// <summary>Minimum value for a predefined zone.</summary>
	URLZONE_PREDEFINED_MIN = 0,

	/// <summary>Zone used for content already on the user's local computer. This zone is not exposed by the user interface.</summary>
	URLZONE_LOCAL_MACHINE = 0,

	/// <summary>Zone used for content found on an intranet.</summary>
	URLZONE_INTRANET = (URLZONE_LOCAL_MACHINE + 1),

	/// <summary>Zone used for trusted Web sites on the Internet.</summary>
	URLZONE_TRUSTED = (URLZONE_INTRANET + 1),

	/// <summary>Zone used for most of the content on the Internet.</summary>
	URLZONE_INTERNET = (URLZONE_TRUSTED + 1),

	/// <summary>Zone used for Web sites that are not trusted.</summary>
	URLZONE_UNTRUSTED = (URLZONE_INTERNET + 1),

	/// <summary>Maximum value for a predefined zone.</summary>
	URLZONE_PREDEFINED_MAX = 999,

	/// <summary>Minimum value allowed for a user-defined zone.</summary>
	URLZONE_USER_MIN = 1000,

	/// <summary>Maximum value allowed for a user-defined zone.</summary>
	URLZONE_USER_MAX = 10000
}