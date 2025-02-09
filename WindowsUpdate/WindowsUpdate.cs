using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Vanara.Collections;
using Vanara.PInvoke;
using static Vanara.PInvoke.WUApi;

namespace Vanara.WindowsUpdate;

/// <summary>
/// Represents a session in which the caller can perform operations that involve updates. For example, this object represents sessions in
/// which the caller performs a search, download, installation, or uninstallation operation.
/// </summary>
public static class UpdateSession
{
	[ThreadStatic]
	private static readonly IUpdateSession sess = new();

	/// <summary>Gets and sets the current client application.</summary>
	/// <remarks>Returns <see langword="null"/> if the client application has not set the property.</remarks>
	public static string? ClientApplicationID { get => sess.ClientApplicationID; set => sess.ClientApplicationID = value; }

	/// <summary>Gets a <see cref="bool"/> that indicates whether the session object is read-only.</summary>
	public static bool ReadOnly => sess.ReadOnly;

	/// <summary>
	/// <para>Gets and sets the preferred locale for which update information is retrieved..</para>
	/// <para>
	/// If you do not specify the locale, the default is the user locale that GetUserDefaultUILanguage returns. If the information is not
	/// available in a specified locale or in the user locale, Windows Update Agent (WUA) tries to retrieve the information from the default
	/// update locale.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// A search from an <see cref="UpdateSearcher"/> object that was created from the <see cref="UpdateSession"/> object fails if the
	/// following conditions are true:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>A user or a power user set the <c>UserLocale</c> property for the UpdateSession instance to a locale.</description>
	/// </item>
	/// <item>
	/// <description>The locale corresponds to a language that is not installed on the computer.</description>
	/// </item>
	/// </list>
	/// </remarks>
	public static LCID UserLocale
	{
		get => (sess as IUpdateSession2)?.UserLocale ?? LCID.LOCALE_SYSTEM_DEFAULT;
		set { if (sess is IUpdateSession2 s2) s2.UserLocale = value; else throw new NotImplementedException(); }
	}

	/// <summary>Gets and sets the proxy settings that are used to access the server.</summary>
	public static WebProxy WebProxy { get => new(sess.WebProxy); set => sess.WebProxy = value.Interface; }

	/// <summary>Returns a UpdateDownloader instance for this session.</summary>
	/// <returns>A UpdateDownloader instance for this session.</returns>
	/// <remarks>A UpdateDownloader instance can also be created by using the UpdateDownloader class.</remarks>
	public static UpdateDownloader CreateUpdateDownloader() => new();

	/// <summary>Returns a UpdateInstaller instance for this session.</summary>
	/// <returns>A UpdateInstaller instance for this session.</returns>
	/// <remarks>A UpdateInstaller instance can also be created by using the UpdateInstaller class.</remarks>
	public static UpdateInstaller CreateUpdateInstaller() => new();

	/// <summary>Returns a UpdateSearcher instance for this session.</summary>
	/// <returns>A UpdateSearcher instance for this session.</returns>
	/// <remarks>A UpdateSearcher instance can also be created by using the UpdateSearcher class.</remarks>
	public static UpdateSearcher CreateUpdateSearcher() => new();

	/// <summary>Returns a pointer to a UpdateServiceManager instance for the session.</summary>
	/// <returns>A pointer to a UpdateServiceManager instance for the session.</returns>
	public static UpdateServiceManager CreateUpdateServiceManager() => new();
}

/// <summary>Contains the functionality of Automatic Updates.</summary>
public class AutomaticUpdates
{
	private readonly IAutomaticUpdates au = new();

	/// <summary>Returns an <see cref="AutomaticUpdatesResults"/> instance.</summary>
	/// <returns>An <see cref="AutomaticUpdatesResults"/> instance.</returns>
	public AutomaticUpdatesResults? Results => au is IAutomaticUpdates2 u2 ? new AutomaticUpdatesResults(u2.Results) : null;

	/// <summary>Gets a <see cref="bool"/> that indicates whether all the components that Automatic Updates requires are available.</summary>
	/// <value><see langword="true"/> if all the components that Automatic Updates requires are available; otherwise, <see langword="false"/>.</value>
	public bool ServiceEnabled => au.ServiceEnabled;

	/// <summary>Gets the configuration settings for Automatic Updates.</summary>
	/// <remarks>The returned object can be used to change the current settings and to read the current settings.</remarks>
	public AutomaticUpdatesSettings Settings => new(au.Settings);

	/// <summary>
	/// Begins the Automatic Updates detection task if Automatic Updates is enabled. If any updates are detected, the installation behavior
	/// is determined by the NotificationLevel property of the AutomaticUpdatesSettings instance.
	/// </summary>
	public void DetectNow() => au.DetectNow();

	/// <summary>Enables all the components that Automatic Updates requires.</summary>
	/// <remarks>
	/// <para>This method requires administrator permissions.</para>
	/// </remarks>
	public void EnableService() => au.EnableService();

	/// <summary>Restricts access to the methods and properties of the object that implements this method.</summary>
	/// <param name="flags">
	/// <para>The option to restrict access to various Windows Update Agent (WUA) objects from the Windows Update website.</para>
	/// <para>
	/// Setting this parameter to <see cref="UpdateLockdownOption.uloForWebsiteAccess"/> or to 1 (one) restricts access to the WUA classes that implement the
	/// UpdateLockdown instance.
	/// </para>
	/// </param>
	public void LockDown([In] UpdateLockdownOption flags) => UpdateLockdown.LockDown(au, flags);

	/// <summary>Pauses automatic updates.</summary>
	/// <remarks>
	/// <para>This method requires administrator permissions.</para>
	/// <para>
	/// Automatic Updates can be paused for only eight hours. This limit varies in different binary versions. Callers should call the Resume
	/// method after calling <see cref="Pause"/> as soon as they no longer need to pause automatic updating.
	/// </para>
	/// </remarks>
	public void Pause() => au.Pause();

	/// <summary>Restarts automatic updating if automatic updating is paused.</summary>
	/// <remarks>
	/// <para>This method requires administrator permissions.</para>
	/// <para>Callers should call <see cref="Resume"/> after calling the Pause method as soon as they no longer need to pause automatic updating.</para>
	/// </remarks>
	public void Resume() => au.Resume();

	/// <summary>Displays a dialog box that contains settings for Automatic Updates.</summary>
	/// <remarks>
	/// <para>
	/// A call to <see cref="ShowSettingsDialog"/> fails if the calling user is not logged on or does not have a desktop. A caller can also
	/// programmatically modify Automatic Updates settings by using the Settings property.
	/// </para>
	/// <para>
	/// The settings in the dialog box are read-only if the caller has insufficient security permissions or if the settings are enforced by a
	/// domain administrator who is using Group Policy settings.
	/// </para>
	/// </remarks>
	public void ShowSettingsDialog() => au.ShowSettingsDialog();
}

/// <summary>Contains the read-only properties that describe Automatic Updates.</summary>
public class AutomaticUpdatesResults
{
	private readonly IAutomaticUpdatesResults res;

	internal AutomaticUpdatesResults(IAutomaticUpdatesResults res) => this.res = res;

	/// <summary>
	/// Gets the last time and Coordinated Universal Time (UTC) date when Automatic Updates successfully installed any updates, even if some
	/// failures occurred.
	/// </summary>
	/// <remarks>
	/// Calls to LastInstallationSuccessDate by public users do not update this property. Only the AutomaticUpdates object will update this property.
	/// </remarks>
	public DateTime? LastInstallationSuccessDate => (DateTime?)res.LastInstallationSuccessDate;

	/// <summary>Gets the last time and Coordinated Universal Time (UTC) date when AutomaticUpdates successfully searched for updates.</summary>
	/// <value>
	/// If the date-time for the last successful update search is not known, returns <see langword="null"/>. Otherwise, returns the <see
	/// cref="DateTime"/> of the last successful update search.
	/// </value>
	public DateTime? LastSearchSuccessDate => (DateTime?)res.LastSearchSuccessDate;
}

/// <summary>Contains the settings that are available in Automatic Updates.</summary>
public class AutomaticUpdatesSettings
{
	private readonly IAutomaticUpdatesSettings settings;

	internal AutomaticUpdatesSettings(IAutomaticUpdatesSettings settings) => this.settings = settings;

	/// <summary>
	/// <para>
	/// Gets and sets a <see cref="bool"/> that indicates whether to include optional or recommended updates when a search for updates and
	/// installation of updates is performed.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>Only administrators can set this property.</para>
	/// <para>
	/// The caller can modify the settings in AutomaticUpdatesSettings only if the ReadOnly property is <see langword="true"/>. The <see
	/// cref="ReadOnly"/> property may change after the Refresh method is called.
	/// </para>
	/// </remarks>
	public bool? IncludeRecommendedUpdates
	{
		get => settings is IAutomaticUpdatesSettings2 s2 ? s2.IncludeRecommendedUpdates : null;
		set { if (settings is IAutomaticUpdatesSettings2 s2) s2.IncludeRecommendedUpdates = value ?? throw new NotImplementedException(); }
	}

	/// <summary>
	/// Gets and sets a <see cref="bool"/> that indicates whether non-administrators can perform some update-related actions without
	/// administrator approval.
	/// </summary>
	/// <remarks>
	/// The NonAdministratorsElevated property controls whether non-administrative users are allowed to perform some additional actions
	/// without elevation. It is equivalent to the “Allow all users to install updates on this computer” check box in the Windows Update
	/// settings dialog.
	/// </remarks>
	public bool? NonAdministratorsElevated
	{
		get => settings is IAutomaticUpdatesSettings3 s3 ? s3.NonAdministratorsElevated : null;
		set { if (settings is IAutomaticUpdatesSettings3 s3) s3.NonAdministratorsElevated = value ?? throw new NotImplementedException(); }
	}

	/// <summary>Gets and sets how users are notified about Automatic Update events.</summary>
	public AutomaticUpdatesNotificationLevel NotificationLevel { get => settings.NotificationLevel; set => settings.NotificationLevel = value; }

	/// <summary>Gets a <see cref="bool"/> that indicates whether the Automatic Update settings are read-only.</summary>
	/// <remarks>
	/// <para><see cref="ReadOnly"/> is <see langword="true"/> if either of the following conditions is true:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>The caller has insufficient security permissions to modify the Automatic Updates settings.</description>
	/// </item>
	/// <item>
	/// <description>The current settings are enforced by Group Policy.</description>
	/// </item>
	/// </list>
	/// <para>
	/// The caller can modify the settings in AutomaticUpdatesSettings only if <see cref="ReadOnly"/> is <see langword="false"/> The value of
	/// <see cref="ReadOnly"/> may change after calling Refresh.
	/// </para>
	/// </remarks>
	public bool ReadOnly => settings.ReadOnly;

	/// <summary>Gets a <see cref="bool"/> that indicates whether Group Policy requires the Automatic Updates service.</summary>
	public bool Required => settings.Required;

	/// <summary>Gets and sets the days of the week on which Automatic Updates installs or uninstalls updates.</summary>
	/// <remarks>
	/// <para>The value of this property is ignored if the value of the NotificationLevel property is not <see cref="AutomaticUpdatesNotificationLevel.aunlScheduledInstallation"/>.</para>
	/// <para>
	/// <c>Note</c>  Starting with Windows 8 and Windows Server 2012, <see cref="ScheduledInstallationDay"/> is not supported and will return
	/// unreliable values. If you try to modify <see cref="ScheduledInstallationDay"/>, the operation will appear to succeed but will have no effect.
	/// </para>
	/// </remarks>
	public AutomaticUpdatesScheduledInstallationDay ScheduledInstallationDay { get => settings.ScheduledInstallationDay; set => settings.ScheduledInstallationDay = value; }

	/// <summary>Gets and sets the time at which Automatic Updates installs or uninstalls updates.</summary>
	/// <remarks>
	/// <para>The time is set by using the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Time</description>
	/// </listheader>
	/// <item>
	/// <description>0</description>
	/// <description>00:00</description>
	/// </item>
	/// <item>
	/// <description>1</description>
	/// <description>01:00</description>
	/// </item>
	/// <item>
	/// <description>2</description>
	/// <description>02:00</description>
	/// </item>
	/// <item>
	/// <description>3</description>
	/// <description>03:00</description>
	/// </item>
	/// <item>
	/// <description>4</description>
	/// <description>04:00</description>
	/// </item>
	/// <item>
	/// <description>5</description>
	/// <description>05:00</description>
	/// </item>
	/// <item>
	/// <description>6</description>
	/// <description>06:00</description>
	/// </item>
	/// <item>
	/// <description>7</description>
	/// <description>07:00</description>
	/// </item>
	/// <item>
	/// <description>8</description>
	/// <description>08:00</description>
	/// </item>
	/// <item>
	/// <description>9</description>
	/// <description>09:00</description>
	/// </item>
	/// <item>
	/// <description>10</description>
	/// <description>10:00</description>
	/// </item>
	/// <item>
	/// <description>11</description>
	/// <description>11:00</description>
	/// </item>
	/// <item>
	/// <description>12</description>
	/// <description>12:00</description>
	/// </item>
	/// <item>
	/// <description>13</description>
	/// <description>13:00</description>
	/// </item>
	/// <item>
	/// <description>14</description>
	/// <description>14:00</description>
	/// </item>
	/// <item>
	/// <description>15</description>
	/// <description>15:00</description>
	/// </item>
	/// <item>
	/// <description>16</description>
	/// <description>16:00</description>
	/// </item>
	/// <item>
	/// <description>17</description>
	/// <description>17:00</description>
	/// </item>
	/// <item>
	/// <description>18</description>
	/// <description>18:00</description>
	/// </item>
	/// <item>
	/// <description>19</description>
	/// <description>19:00</description>
	/// </item>
	/// <item>
	/// <description>20</description>
	/// <description>20:00</description>
	/// </item>
	/// <item>
	/// <description>21</description>
	/// <description>21:00</description>
	/// </item>
	/// <item>
	/// <description>22</description>
	/// <description>22:00</description>
	/// </item>
	/// <item>
	/// <description>23</description>
	/// <description>23:00</description>
	/// </item>
	/// </list>
	/// <para>The value of this property is ignored if the value of the NotificationLevel property is not <see cref="AutomaticUpdatesNotificationLevel.aunlScheduledInstallation"/>.</para>
	/// <para>
	/// <c>Note</c>  Starting with Windows 8 and Windows Server 2012, <see cref="ScheduledInstallationTime"/> is not supported and will
	/// return unreliable values. If you try to modify <see cref="ScheduledInstallationTime"/>, the operation will appear to succeed but will
	/// have no effect.
	/// </para>
	/// </remarks>
	public int ScheduledInstallationTime { get => settings.ScheduledInstallationTime; set => settings.ScheduledInstallationTime = value; }

	/// <summary>Determines whether a specific user or type of user has permission to perform a selected action.</summary>
	/// <param name="userType">An enumeration that indicates the type of user to verify permissions.</param>
	/// <param name="permissionType">An enumeration that indicates the user's permission level.</param>
	/// <returns><see langword="true"/> if the user has the specified permission type; otherwise, <see langword="false"/>.</returns>
	/// <remarks>
	/// This method can be used to determine whether User Access Control (UAC) must be used to perform an action in the agent, which may
	/// obviate the need for prompting if the user type does not have permission to perform the action. For example, unless the agent has
	/// elevated permission, the ReadOnly property of the AutomaticUpdatesSettings object will always be <see langword="true"/>. However,
	/// even after a user has been elevated, the NotificationLevel (for example) may still be read-only due to Group Policy settings. The
	/// <see cref="CheckPermission"/> method can determine this before elevation is done to prevent prompting in cases where the setting
	/// cannot be changed.
	/// </remarks>
	public bool CheckPermission([In] AutomaticUpdatesUserType userType, [In] AutomaticUpdatesPermissionType permissionType) =>
		(settings as IAutomaticUpdatesSettings2)?.CheckPermission(userType, permissionType) ?? throw new NotImplementedException();

	/// <summary>Restricts access to the methods and properties of the object that implements this method.</summary>
	/// <param name="flags">
	/// <para>The option to restrict access to various Windows Update Agent (WUA) objects from the Windows Update website.</para>
	/// <para>
	/// Setting this parameter to <see cref="UpdateLockdownOption.uloForWebsiteAccess"/> or to 1 (one) restricts access to the WUA classes
	/// that implement the UpdateLockdown instance.
	/// </para>
	/// </param>
	public void LockDown([In] UpdateLockdownOption flags) => UpdateLockdown.LockDown(settings, flags);

	/// <summary>Retrieves the latest Automatic Updates settings.</summary>
	/// <remarks>
	/// <para>Calling <see cref="Refresh"/> resets any setting changes that have not been saved by using the Save method.</para>
	/// <para>
	/// <c>Note</c>  On Windows RT, you can no longer use the AutomaticUpdatesSettings.Save method to configure Windows Update settings
	/// programmatically. The configuration operation fails if you use <see cref="Save"/> to set any value other than 4 (aunlScheduledInstallation).
	/// </para>
	/// </remarks>
	public void Refresh() => settings.Refresh();

	/// <summary>Applies the current Automatic Updates settings.</summary>
	/// <remarks>
	/// <para>Saving settings with a NotificationLevel value other than Disabled starts the Automatic Updates service.</para>
	/// <para>
	/// <c>Note</c>  On Windows RT, you can no longer use the <see cref="Save"/> method to configure Windows Update settings
	/// programmatically. The configuration operation fails if you use <see cref="Save"/> to set any value other than 4 (aunlScheduledInstallation).
	/// </para>
	/// </remarks>
	public void Save() => settings.Save();
}

/// <summary>
/// Fluent query item for Windows Update searches. This class is used to build a query for the <see cref="UpdateSearcher.Search"/> method.
/// </summary>
/// <seealso cref="FluentQueryBase"/>
public class BoolCriteria : FluentQueryBase
{
	internal BoolCriteria(FluentQueryBase prior, bool allowed) : base(prior) => Allowed = allowed ? 1 : 0;

	/// <summary>Handles the 'IsAssigned' query value.</summary>
	public QueryOperator Assigned => new(this, $"IsAssigned={Allowed}");

	/// <summary>Handles the 'AutoSelectOnWebSites' query value.</summary>
	public QueryOperator AutoSelectOnWebSites => new(this, $"AutoSelectOnWebSites={Allowed}");

	/// <summary>Handles the 'BrowseOnly' query value.</summary>
	public QueryOperator BrowseOnly => new(this, $"BrowseOnly={Allowed}");

	/// <summary>Handles the 'IsHidden' query value.</summary>
	public QueryOperator Hidden => new(this, $"IsHidden={Allowed}");

	/// <summary>Handles the 'IsInstalled' query value.</summary>
	public QueryOperator Installed => new(this, $"IsInstalled={Allowed}");

	/// <summary>Handles the 'IsPresent' query value.</summary>
	public QueryOperator Present => new(this, $"IsPresent={Allowed}");

	/// <summary>Handles the 'RebootRequired' query value.</summary>
	public QueryOperator RebootRequired => new(this, $"RebootRequired={Allowed}");

	internal int Allowed { get; set; }
}

/// <summary>Represents the category to which an update belongs.</summary>
public class Category
{
	private readonly ICategory cat;

	internal Category(ICategory cat) => this.cat = cat;

	/// <summary>Gets the identifier of the category.</summary>
	[DefaultValue(null)]
	public string? CategoryID => cat.CategoryID;

	/// <summary>Gets a collection that contains the child categories of this category.</summary>
	public IReadOnlyCollection<Category> Children => new CategoryCollection(cat.Children);

	/// <summary>Gets the description of the category.</summary>
	/// <remarks>
	/// <para>
	/// A Categories property exists for the Update object. And, a Categories property exists for the UpdateHistoryEntry object. Therefore,
	/// the information that is used by the localized properties of the Category object depends on the Windows Update Agent (WUA) object that
	/// owns the <see cref="Category"/> object.
	/// </para>
	/// <para>
	/// If the Category object is returned from the Categories property of Update, the <see cref="Category"/> object follows the localization
	/// rules of the <see cref="Update"/> object. In this case, if the UpdateSearcher object is created by using the
	/// UpdateSession.CreateUpdateSearcher method, the information that this property returns is for the language that is specified by the
	/// UserLocale property of the UpdateSession object of the session that is used to create <see cref="UpdateSearcher"/>.
	/// </para>
	/// <para>
	/// If a language preference is not specified by the UserLocale property of the UpdateSession object, or if the UpdateSearcher object is
	/// not created by using the UpdateSession.CreateUpdateSearcher method, the information that this property returns is for the default
	/// user interface (UI) language of the user. If the default UI language of the user is unavailable, WUA uses the default UI language of
	/// the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
	/// </para>
	/// <para>
	/// If the Category object is returned from the Categories property of the UpdateHistoryEntry object, the <see cref="Category"/> object
	/// follows the localization rules of the <see cref="UpdateHistoryEntry"/> object. The information that this property returns is for the
	/// default UI language of the user. If the default UI language of the user is unavailable, WUA uses the default UI language of the
	/// computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
	/// </para>
	/// </remarks>
	[DefaultValue(null)]
	public string? Description => cat.Description;

	/// <summary>Gets an object that contains information about the image that is associated with the category.</summary>
	/// <remarks>
	/// <para>
	/// A Categories property exists for the Update object. And, a Categories property exists for the UpdateHistoryEntry object. Therefore,
	/// the information that is used by the localized properties of the Category object depends on the Windows Update Agent (WUA) object that
	/// owns <see cref="Category"/>.
	/// </para>
	/// <para>
	/// If the Category instance is returned from the Categories property of Update, the <see cref="Category"/> class follows the
	/// localization rules of the <see cref="Update"/> object. In this case, if the UpdateSearcher instance is created by using the
	/// UpdateSession.CreateUpdateSearcher method, the information that this property returns is for the language that is specified by the
	/// UserLocale property of the UpdateSession instance of the session that is used to create <see cref="UpdateSearcher"/>.
	/// </para>
	/// <para>
	/// If a language preference is not specified by the UserLocale property of the UpdateSession instance, or if the IUpdateSearcher object
	/// is not created by using the UpdateSession.CreateUpdateSearcher method, the information that this property returns is for the default
	/// user interface (UI) language of the user. If the default UI language of the user is unavailable, WUA uses the default UI language of
	/// the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
	/// </para>
	/// <para>
	/// If the Category instance is returned from the Categories property of the UpdateHistoryEntry instance, the <see cref="Category"/>
	/// object follows the localization rules of the <see cref="UpdateHistoryEntry"/> class. The information that this property returns is
	/// for the default UI language of the user. If the default UI language of the user is unavailable, WUA uses the default UI language of
	/// the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
	/// </para>
	/// </remarks>
	[DefaultValue(null)]
	public ImageInformation? Image => cat.Image is null ? null : new(cat.Image);

	/// <summary>Gets the localized name of the category.</summary>
	/// <remarks>
	/// <para>
	/// A Categories property exists for the Update instance. And, a Categories property exists for the UpdateHistoryEntry instance.
	/// Therefore, the information that is used by the localized properties of the Category instance depends on the Windows Update Agent
	/// (WUA) object that owns the <see cref="Category"/> class.
	/// </para>
	/// <para>
	/// If the Category instance is returned from the Categories property of IUpdate, the <see cref="Category"/> class follows the
	/// localization rules of the <see cref="Update"/> class. In this case, if the UpdateSearcher instance is created by using the
	/// UpdateSession.CreateUpdateSearcher method, the information that this property returns is for the language that is specified by the
	/// UserLocale property of the UpdateSession instance of the session that is used to create <see cref="UpdateSearcher"/>.
	/// </para>
	/// <para>
	/// If a language preference is not specified by the UserLocale property of the UpdateSession instance, or if the IUpdateSearcher object
	/// is not created by using the UpdateSession.CreateUpdateSearcher method, the information that this property returns is for the default
	/// user interface (UI) language of the user. If the default UI language of the user is unavailable, WUA uses the default UI language of
	/// the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
	/// </para>
	/// <para>
	/// If the Category instance is returned from the Categories property of the UpdateHistoryEntry instance, the <see cref="Category"/>
	/// object follows the localization rules of the <see cref="UpdateHistoryEntry"/> class. The information that this property returns is
	/// for the default UI language of the user. If the default UI language of the user is unavailable, WUA uses the default UI language of
	/// the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
	/// </para>
	/// </remarks>
	public string Name => cat.Name;

	/// <summary>Gets the recommended display order of this category among its sibling categories.</summary>
	[DefaultValue(0)]
	public int Order => cat.Order;

	/// <summary>Gets the type of the category.</summary>
	/// <remarks>The following list identifies the possible category types:</remarks>
	public string Type => cat.Type;

	/// <summary>Gets an object that describes the parent category of this category.</summary>
	public Category? GetParent() => cat.Parent is null ? null : new(cat.Parent);

	/// <summary>Gets a collection of updates that immediately belong to the category.</summary>
	/// <remarks>The returned updates are applicable to the computer. They may or may not be installed on that computer.</remarks>
	public IReadOnlyCollection<Update> GetUpdates() => new UpdateCollection(cat.Updates);
}

/// <summary>The <see cref="CategoryCollection"/> class represents an ordered read-only list of Category instances.</summary>
public class CategoryCollection : VirtualReadOnlyList<Category>
{
	internal CategoryCollection(ICategoryCollection? coll) : base(new CollectionMethods(coll))
	{
	}

	private class CollectionMethods(ICategoryCollection? c) : IVirtualReadOnlyListMethods<Category>
	{
		public readonly ICategoryCollection? src = c;

		public int GetItemCount() => src?.Count ?? 0;

		public bool TryGet(int index, [NotNullWhen(true)] out Category? value)
		{
			ICategory? cat = index >= 0 && index < GetItemCount() ? src![index] : null;
			value = cat is not null ? new Category(cat) : null;
			return value is not null;
		}
	}
}

/// <summary>
/// Fluent query item for Windows Update searches. This class is used to build a query for the <see cref="UpdateSearcher.Search"/> method.
/// </summary>
/// <seealso cref="FluentQueryBase"/>
public class ContainsCriteria : FluentQueryBase
{
	internal ContainsCriteria(FluentQueryBase prior) : base(prior)
	{
	}

	/// <summary>Handles the 'CategoryIDs' query value.</summary>
	public QueryOperator Category(Guid catId) => new(this, $"CategoryIDs contains '{catId:D}'");
}

/// <summary>Represents the progress of an asynchronous download operation.</summary>
public class DownloadProgress
{
	private readonly IDownloadProgress prog;

	internal DownloadProgress(IDownloadProgress prog) => this.prog = prog;

	/// <summary>
	/// Gets a string that specifies how much data has been transferred for the content file or files of the update that is being downloaded,
	/// in bytes.
	/// </summary>
	public decimal CurrentUpdateBytesDownloaded => prog.CurrentUpdateBytesDownloaded;

	/// <summary>
	/// Gets a string that estimates how much data should be transferred for the content file or files of the update that is being
	/// downloaded, in bytes.
	/// </summary>
	public decimal CurrentUpdateBytesToDownload => prog.CurrentUpdateBytesToDownload;

	/// <summary>Gets a DownloadPhase enumeration value that specifies the phase of the download that is currently in progress.</summary>
	public DownloadPhase CurrentUpdateDownloadPhase => prog.CurrentUpdateDownloadPhase;

	/// <summary>
	/// Gets a zero-based index value that specifies the update that is currently being downloaded when multiple updates have been selected.
	/// </summary>
	public int CurrentUpdateIndex => prog.CurrentUpdateIndex;

	/// <summary>Gets an estimate of the percentage of the current update that has been downloaded.</summary>
	public int CurrentUpdatePercentComplete => prog.CurrentUpdatePercentComplete;

	/// <summary>Gets an estimate of the percentage of all the updates that have been downloaded.</summary>
	public int PercentComplete => prog.PercentComplete;

	/// <summary>Gets a string that specifies the total amount of data that has been downloaded, in bytes.</summary>
	public decimal TotalBytesDownloaded => prog.TotalBytesDownloaded;

	/// <summary>Gets a string that represents the estimate of the total amount of data that will be downloaded, in bytes.</summary>
	public decimal TotalBytesToDownload => prog.TotalBytesToDownload;

	/// <summary>Returns the result of the download of a specified update.</summary>
	/// <param name="updateIndex">A zero-based index value that specifies an update.</param>
	/// <returns>A UpdateDownloadResult instance that contains information about the specified update.</returns>
	public UpdateDownloadResult GetUpdateResult([In] int updateIndex) => new(prog.GetUpdateResult(updateIndex));
}

/// <summary>The <see cref="DownloadResult"/> class represents the result of a download operation.</summary>
public class DownloadResult
{
	private readonly IDownloadResult res;

	internal DownloadResult(IDownloadResult res) => this.res = res;

	/// <summary>Gets the exception code number if an exception code number is raised during the download.</summary>
	[DefaultValue(0)]
	public HRESULT HResult => res.HResult;

	/// <summary>Gets an OperationResultCode enumeration that specifies the result of the download.</summary>
	public OperationResultCode ResultCode => res.ResultCode;

	/// <summary>Returns a UpdateDownloadResult instance that contains the download information for a specified update.</summary>
	/// <param name="updateIndex">The index of the update.</param>
	/// <returns>A UpdateDownloadResult instance that contains the results for the specified update.</returns>
	public UpdateDownloadResult GetUpdateResult([In] int updateIndex) => new(res.GetUpdateResult(updateIndex));
}

/// <summary>Fluent helper class. Not intended for use.</summary>
public abstract class FluentQueryBase
{
	/// <summary>The searcher</summary>
	protected readonly UpdateSearcher searcher;
	/// <summary>The query</summary>
	protected StringBuilder query;

	internal FluentQueryBase(UpdateSearcher searcher)
	{ this.searcher = searcher; query = new StringBuilder(1024); }

	internal FluentQueryBase(FluentQueryBase prior, string? stmt = null)
	{ searcher = prior.searcher; query = prior.query; if (stmt is not null) query.Append(stmt + ' '); }

	//public override string ToString() => query.ToString().Trim();
}

/// <summary>Contains information about a localized image that is associated with an update or a category.</summary>
public class ImageInformation
{
	private readonly IImageInformation img;

	internal ImageInformation(IImageInformation img) => this.img = img;

	/// <summary>Gets the alternate text for the image.</summary>
	public string AltText => img.AltText;

	/// <summary>Gets the size of the image, in pixels.</summary>
	public SIZE Size => new(img.Width, img.Height);

	/// <summary>Gets the source location of the image.</summary>
	public string Source => img.Source;
}

/// <summary>
/// Fluent query item for Windows Update searches. This class is used to build a query for the <see cref="UpdateSearcher.Search"/> method.
/// </summary>
/// <seealso cref="FluentQueryBase"/>
public class InclCriteria : FluentQueryBase
{
	internal InclCriteria(FluentQueryBase prior, bool eq) : base(prior) => Eq = eq ? "=" : "!=";

	internal string Eq { get; set; }

	/// <summary>Handles the 'Type' query value.</summary>
	public QueryOperator Type(string type) => new(this, $"Type{Eq}'{type}'");

	/// <summary>Handles the 'UpdateID' query value.</summary>
	public QueryOperator UpdateID(Guid id) => new(this, $"UpdateID{Eq}'{id:D}'");
}

/// <summary>Represents the installation and uninstallation options of an update.</summary>
public class InstallationBehavior
{
	private readonly IInstallationBehavior beh;

	internal InstallationBehavior(IInstallationBehavior beh) => this.beh = beh;

	/// <summary>
	/// Gets a <see cref="bool"/> thast indicates whether the installation or uninstallation of an update can prompt for user input.
	/// </summary>
	public bool CanRequestUserInput => beh.CanRequestUserInput;

	/// <summary>
	/// Gets an InstallationImpact enumeration that indicates how the installation or uninstallation of the update affects the computer.
	/// </summary>
	public InstallationImpact Impact => beh.Impact;

	/// <summary>
	/// Gets an InstallationRebootBehavior enumeration that specifies the restart behavior that occurs when you install or uninstall the update.
	/// </summary>
	public InstallationRebootBehavior RebootBehavior => beh.RebootBehavior;

	/// <summary>Gets a <see cref="bool"/> that indicates whether the installation or uninstallation of an update requires network connectivity.</summary>
	public bool RequiresNetworkConnectivity => beh.RequiresNetworkConnectivity;
}

/// <summary>Represents the progress of an asynchronous installation or uninstallation.</summary>
public class InstallationProgress
{
	private readonly IInstallationProgress prog;

	internal InstallationProgress(IInstallationProgress prog) => this.prog = prog;

	/// <summary>
	/// Gets a zero-based index value. This value specifies the update that is currently being installed or uninstalled when multiple updates
	/// have been selected.
	/// </summary>
	public int CurrentUpdateIndex => prog.CurrentUpdateIndex;

	/// <summary>Gets how far the installation or uninstallation process for the current update has progressed, as a percentage.</summary>
	public int CurrentUpdatePercentComplete => prog.CurrentUpdatePercentComplete;

	/// <summary>Gets how far the overall installation or uninstallation process has progressed, as a percentage.</summary>
	public int PercentComplete => prog.PercentComplete;

	/// <summary>Returns the result of the installation or uninstallation of a specified update.</summary>
	/// <param name="updateIndex">A zero-based index value that specifies an update.</param>
	/// <returns>A UpdateInstallationResult instance that contains information about a specified update.</returns>
	/// <remarks>
	/// You must make repeated calls to the <see cref="GetUpdateResult"/> method to track the progress of a download. You must do this
	/// because the UpdateInstallationResult instance is not automatically updated during a download.
	/// </remarks>
	public UpdateInstallationResult GetUpdateResult([In] int updateIndex) => new(prog.GetUpdateResult(updateIndex));
}

/// <summary>Represents the result of an installation or uninstallation.</summary>
public class InstallationResult
{
	private readonly IInstallationResult res;

	internal InstallationResult(IInstallationResult res) => this.res = res;

	/// <summary>Gets the <see cref="HRESULT"/> of the exception, if any, that is raised during the installation.</summary>
	public HRESULT HResult => res.HResult;

	/// <summary>
	/// Gets a <see cref="bool"/> that indicates whether you must restart the computer to complete the installation or uninstallation of an update.
	/// </summary>
	public bool RebootRequired => res.RebootRequired;

	/// <summary>Gets an OperationResultCode value that specifies the result of an operation on an update.</summary>
	public OperationResultCode ResultCode => res.ResultCode;

	/// <summary>Returns a UpdateInstallationResult instance that contains the installation results for a specified update.</summary>
	/// <param name="updateIndex">The index of an update.</param>
	/// <returns>An object that contains results for a specified update.</returns>
	public UpdateInstallationResult GetUpdateResult(int updateIndex) => new(res.GetUpdateResult(updateIndex));
}

/// <summary>
/// Fluent query item for Windows Update searches. This class is used to build a query for the <see cref="UpdateSearcher.Search"/> method.
/// </summary>
/// <seealso cref="FluentQueryBase"/>
public class QueryCondition : FluentQueryBase
{
	internal QueryCondition(UpdateSearcher updateSearcher) : base(updateSearcher)
	{
	}

	internal QueryCondition(FluentQueryBase prior, string? stmt = null) : base(prior, stmt)
	{
	}

	/// <summary>Handles query values using 'contains'.</summary>
	public ContainsCriteria Contains => new(this);

	/// <summary>Handles query values using '!='.</summary>
	public InclCriteria Excludes => new(this, false);

	/// <summary>Handles query values using parameters.</summary>
	public SetCriteria Has => new(this);

	/// <summary>Handles query values using '='.</summary>
	public BoolCriteria Is => new(this, true);

	/// <summary>Handles query values using '!='.</summary>
	public BoolCriteria Not => new(this, false);
}

/// <summary>
/// Fluent query item for Windows Update searches. This class is used to build a query for the <see cref="UpdateSearcher.Search"/> method.
/// </summary>
/// <seealso cref="FluentQueryBase"/>
public class QueryOperator : FluentQueryBase
{
	internal QueryOperator(FluentQueryBase prior, string criteria) : base(prior, criteria)
	{
	}

	/// <summary>Handles join operations for queries using a logical <c>AND</c>.</summary>
	public QueryCondition And => new(this, "and");

	/// <summary>Handles join operations for queries using a logical <c>OR</c>.</summary>
	public QueryCondition Or => new(this, "or");

	/// <summary>Performs a synchronous search for updates. The search uses the search options that are currently configured.</summary>
	/// <returns>
	/// <para>A SearchResult instance that contains the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>The result of an operation</description>
	/// </item>
	/// <item>
	/// <description>A collection of updates that match the search criteria</description>
	/// </item>
	/// </list>
	/// </returns>
	public SearchResult Search()
	{
		System.Diagnostics.Debug.WriteLine(query);
		return searcher.Search(query.ToString());
	}
}

/// <summary>Represents the result of a search.</summary>
public class SearchResult
{
	private readonly ISearchResult res;

	internal SearchResult(ISearchResult r) => res = r;

	/// <summary>Gets an OperationResultCode enumeration that specifies the result of a search.</summary>
	public OperationResultCode ResultCode => res.ResultCode;

	/// <summary>Gets a collection of the root categories that are currently available on the computer.</summary>
	public IReadOnlyCollection<Category> RootCategories => new CategoryCollection(res.RootCategories);

	/// <summary>Gets a collection of the updates that result from a search.</summary>
	public IReadOnlyList<Update> Updates => new UpdateCollection(res.Updates);

	/// <summary>Gets a collection of the warnings that result from a search.</summary>
	public IReadOnlyCollection<UpdateException> Warnings => res.Warnings?.Cast<IUpdateException>().Select(e => new UpdateException(e)).ToList() ?? [];
}

/// <summary>
/// Fluent query item for Windows Update searches. This class is used to build a query for the <see cref="UpdateSearcher.Search"/> method.
/// </summary>
/// <seealso cref="FluentQueryBase"/>
public class SetCriteria : FluentQueryBase
{
	internal SetCriteria(FluentQueryBase prior, bool eq = true) : base(prior) => Eq = eq ? "=" : "!=";

	internal string Eq { get; set; }

	/// <summary>Handles the 'DeploymentAction' query value.</summary>
	public QueryOperator DeploymentAction(string action) => new(this, $"DeploymentAction='{action}'");

	/// <summary>Handles the 'RevisionNumber' query value.</summary>
	public QueryOperator RevisionNumber(int rev) => new(this, $"RevisionNumber={rev}");

	/// <summary>Handles the 'Type' query value.</summary>
	public QueryOperator Type(string type) => new(this, $"Type{Eq}'{type}'");

	/// <summary>Handles the 'UpdateID' query value.</summary>
	public QueryOperator UpdateID(Guid id) => new(this, $"UpdateID{Eq}'{id:D}'");
}

/// <summary>Represents an ordered list of strings.</summary>
public class StringCollection : VirtualList<string>, IStringCollection
{
	/// <summary>Initializes a new instance of the <see cref="StringCollection"/> class.</summary>
	/// <param name="values">The values with which to initiate the list.</param>
	public StringCollection(IEnumerable<string> values) : this((IStringCollection?)null)
	{
		foreach (var s in values)
			Add(s);
	}

	/// <summary>Initializes a new instance of the <see cref="StringCollection"/> class.</summary>
	public StringCollection() : this((IStringCollection?)null)
	{
	}

	internal StringCollection(IStringCollection? coll = null) : base(new StringCollectionMethods(coll))
	{
	}

	internal IStringCollection Interface => ((StringCollectionMethods)impl).coll;

	private class StringCollectionMethods(IStringCollection? c) : IVirtualListMethods<String>
	{
		public readonly IStringCollection coll = c ?? new IStringCollection();

		public void AddItem(string item) => coll.Add(item);

		public int GetItemCount() => coll.Count;

		public void InsertItemAt(int index, string item) => coll.Insert(index, item);

		public void RemoveItemAt(int index) => coll.RemoveAt(index);

		public void SetItemAt(int index, string value) => coll[index] = value;

		public bool TryGet(int index, [NotNullWhen(true)] out string? value)
		{
			value = index >= 0 && index < coll.Count ? coll[index] : null;
			return value is not null;
		}
	}

	IEnumerator IStringCollection.GetEnumerator() => Interface.GetEnumerator();
	bool IStringCollection.ReadOnly => Interface.ReadOnly;
	int IStringCollection.Add(string value) => Interface.Add(value);
	IStringCollection IStringCollection.Copy() => Interface.Copy();
}

/// <summary>Contains information about the specified computer. This information is relevant to the Windows Update Agent (WUA).</summary>
public class SystemInformation
{
	private readonly ISystemInformation info = new();

	/// <summary>Gets a hyperlink to technical support information for OEM hardware.</summary>
	[DefaultValue("")]
	public string OemHardwareSupportLink => info.OemHardwareSupportLink;

	/// <summary>
	/// Gets a <see cref="bool"/> that indicates whether a system restart is required to complete the installation or uninstallation of one
	/// or more updates.
	/// </summary>
	[DefaultValue(false)]
	public bool RebootRequired => info.RebootRequired;
}

/// <summary>Contains the properties and methods that are available to an update.</summary>
/// <remarks>
/// If the BundledUpdates property contains an UpdateCollection, some properties and methods of the update may only be available on the
/// bundled updates, for example, DownloadContents or CopyFromCache.
/// </remarks>
public class Update
{
	/// <summary>The update object.</summary>
	protected internal readonly IUpdate upd;

	internal Update(IUpdate upd) => this.upd = upd;

	/// <summary>Gets a value indicating the automatic download mode of update.</summary>
	/// <remarks>The AutoDownload property indicates whether the update will be automatically downloaded by Automatic Updates.</remarks>
	public AutoDownloadMode AutoDownload => (upd as IUpdate5)?.AutoDownload ?? AutoDownloadMode.adLetWindowsUpdateDecide;

	/// <summary>Gets a value indicating the automatic selection mode of update in the Control Panel of Windows Update.</summary>
	/// <remarks>
	/// The AutoSelection property indicates whether the update will be automatically selected when the user views the available updates in
	/// the Windows Update user interface.
	/// </remarks>
	public AutoSelectionMode AutoSelection => (upd as IUpdate5)?.AutoSelection ?? AutoSelectionMode.asLetWindowsUpdateDecide;

	/// <summary>Gets a <see cref="bool"/> that indicates whether the update is flagged to be automatically selected by Windows Update.</summary>
	public bool AutoSelectOnWebSites => upd.AutoSelectOnWebSites;

	/// <summary>Gets a <see cref="bool"/> that indicates whether an update can be discovered only by browsing through the available updates.</summary>
	public bool? BrowseOnly => (upd as IUpdate3)?.BrowseOnly;

	/// <summary>Gets an object that contains information about the ordered list of the bundled updates for the update.</summary>
	public IReadOnlyList<Update> BundledUpdates => new UpdateCollection(upd.BundledUpdates);

	/// <summary>Gets a <see cref="bool"/> that indicates whether the source media of the update is required for installation or uninstallation.</summary>
	public bool CanRequireSource => upd.CanRequireSource;

	/// <summary>Gets a collection of categories to which the update belongs.</summary>
	/// <remarks>
	/// <para>
	/// If the UpdateSearcher instance is created by using the UpdateSession.CreateUpdateSearcher method, the information that this property
	/// returns is for the language that is specified by the UserLocale property of the UpdateSession instance of the session that was used
	/// to create <see cref="UpdateSearcher"/>.
	/// </para>
	/// <para>
	/// If a language preference is not specified by the UserLocale property of UpdateSession, or if the UpdateSearcher instance is not
	/// created by using UpdateSession.CreateUpdateSearcher, the information that this property returns is for the default user interface
	/// (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI
	/// language of the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the
	/// update recommends.
	/// </para>
	/// <para>
	/// Because there is a <see cref="Categories"/> property of IUpdate and a Categories property of UpdateHistoryEntry, the information that
	/// is used by the localized properties of the Category instance depend on the WUA object that owns the <see cref="Category"/> class. If
	/// the <see cref="Category"/> class is returned from the <see cref="Categories"/> property of <see cref="Update"/>, it follows the
	/// localization rules of <see cref="Update"/>. If the <see cref="Category"/> class is returned from the <see cref="Categories"/>
	/// property of <see cref="UpdateHistoryEntry"/>, it follows the localization rules of <see cref="UpdateHistoryEntry"/>.
	/// </para>
	/// </remarks>
	public IReadOnlyCollection<Category> Categories => new CategoryCollection(upd.Categories);

	/// <summary>Gets a collection of common vulnerabilities and exposures (CVE) IDs that are associated with the update.</summary>
	public IReadOnlyList<string> CveIDs => new StringCollection((upd as IUpdate3)?.CveIDs);

	/// <summary>Gets the date by which the update must be installed.</summary>
	/// <remarks>
	/// <para>
	/// In COM, if the update has a deadline, the return value is of type VT_DATE and contains a DATE value that specifies the deadline.
	/// Otherwise, the return value is of type VT_EMPTY.
	/// </para>
	/// <para>In the Microsoft .NET Framework, the return value is <c><see langword="null"/></c> if the update has no deadline.</para>
	/// </remarks>
	public DateTime? Deadline => upd.Deadline is null ? null : (DateTime)upd.Deadline;

	/// <summary>Gets a <see cref="bool"/> that indicates whether delta-compressed content is available on a server for the update.</summary>
	public bool DeltaCompressedContentAvailable => upd.DeltaCompressedContentAvailable;

	/// <summary>
	/// Gets a <see cref="bool"/> that indicates whether to prefer delta-compressed content during the download and install or uninstall of
	/// the update if delta-compressed content is available.
	/// </summary>
	public bool DeltaCompressedContentPreferred => upd.DeltaCompressedContentPreferred;

	/// <summary>Gets the action for which the update is deployed.</summary>
	public DeploymentAction DeploymentAction => upd.DeploymentAction;

	/// <summary>Gets the localized description of the update.</summary>
	/// <remarks>
	/// <para>
	/// If the UpdateSearcher instance is created by using the UpdateSession.CreateUpdateSearcher method, the information that this property
	/// returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
	/// UpdateSession instance of the session that is used to create <see cref="UpdateSearcher"/>.
	/// </para>
	/// <para>
	/// If a language preference is not specified by the UserLocale property of UpdateSession, or if the UpdateSearcher instance is not
	/// created by using UpdateSession.CreateUpdateSearcher, the information that is returned by this property is for the default user object
	/// (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI
	/// language of the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the
	/// update recommends.
	/// </para>
	/// </remarks>
	public string? Description => upd.Description;

	/// <summary>Gets file information about the download contents of the update.</summary>
	public IReadOnlyList<UpdateDownloadContent> DownloadContents => upd.DownloadContents?.Cast<IUpdateDownloadContent>().Select(c => new UpdateDownloadContent(c)).ToList() ?? [];

	/// <summary>Gets the suggested download priority of the update.</summary>
	[DefaultValue(DownloadPriority.dpNormal)]
	public DownloadPriority DownloadPriority => upd.DownloadPriority;

	/// <summary>
	/// <para>
	/// Gets a <see cref="bool"/> that indicates whether the Microsoft Software License Terms that are associated with the update are
	/// accepted for the computer.
	/// </para>
	/// </summary>
	public bool EulaAccepted => upd.EulaAccepted;

	/// <summary>Gets the full localized text of the Microsoft Software License Terms that are associated with the update.</summary>
	/// <remarks>
	/// <para>
	/// If the UpdateSearcher instance is created by using the UpdateSession.CreateUpdateSearcher method, the information that this property
	/// returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
	/// UpdateSession instance of the session that is used to create <see cref="UpdateSearcher"/>.
	/// </para>
	/// <para>
	/// If a language preference is not specified by the UserLocale property of UpdateSession, or if the UpdateSearcher instance is not
	/// created by using UpdateSession.CreateUpdateSearcher, the information that is returned by this property is for the default user object
	/// (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI
	/// language of the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the
	/// update recommends.
	/// </para>
	/// </remarks>
	public string? EulaText => upd.EulaText;

	/// <summary>Gets the install handler of the update.</summary>
	/// <remarks>
	/// <para>The valid values for the <see cref="HandlerID"/> property include the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>The Command Line Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/CommandLineInstallation</description>
	/// </item>
	/// <item>
	/// <description>The Inf Based Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/InfBasedInstallation</description>
	/// </item>
	/// <item>
	/// <description>The Windows Installer Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/WindowsInstaller</description>
	/// </item>
	/// <item>
	/// <description>
	/// The Package Installer for Microsoft Windows Operating Systems and Windows Components (update.exe) Installation Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/WindowsPatch
	/// </description>
	/// </item>
	/// <item>
	/// <description>The Component Based Servicing (CBS) Handlerhttp://schemas.microsoft.com/msus/2002/12/UpdateHandlers/Cbs</description>
	/// </item>
	/// </list>
	/// </remarks>
	public string? HandlerID => upd.HandlerID;

	/// <summary>Gets an object that contains the unique identifier of the update.</summary>
	public UpdateIdentity Identity => new(upd.Identity);

	/// <summary>Gets an object that contains information about an image that is associated with the update.</summary>
	/// <remarks>
	/// <para>
	/// If the UpdateSearcher instance is created by using the UpdateSession.CreateUpdateSearcher method, the information that this property
	/// returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
	/// UpdateSession instance of the session that is used to create <see cref="UpdateSearcher"/>.
	/// </para>
	/// <para>
	/// If a language preference is not specified by the UserLocale property of UpdateSession, or if the UpdateSearcher instance is not
	/// created by using UpdateSession.CreateUpdateSearcher, the information that is returned by this property is for the default user object
	/// (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI
	/// language of the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the
	/// update recommends.
	/// </para>
	/// <para>This API can return a null pointer as the output, even when the return value is S_OK.</para>
	/// </remarks>
	public ImageInformation? Image => upd.Image is null ? null : new(upd.Image);

	/// <summary>Gets an object that contains the installation options of the update.</summary>
	/// <remarks>
	/// If the current update represents a bundle, the <see cref="InstallationBehavior"/> property of the bundle will be determined by the
	/// <see cref="InstallationBehavior"/> property of the child updates of the bundle. This API can return a null pointer as the output,
	/// even when the return value is S_OK.
	/// </remarks>
	public InstallationBehavior InstallationBehavior => new(upd.InstallationBehavior);

	/// <summary>Gets a <see cref="bool"/> that indicates whether the update is a beta release.</summary>
	public bool IsBeta => upd.IsBeta;

	/// <summary>Gets a <see cref="bool"/> that indicates whether all the update content is cached on the computer.</summary>
	public bool IsDownloaded => upd.IsDownloaded;

	/// <summary>
	/// <para>
	/// Gets a <see cref="bool"/> that indicates whether an update is hidden by a user. Administrators, users, and power users can retrieve
	/// the value of this property. However, only administrators and members of the Power Users administrative group can set the value of
	/// this property.
	/// </para>
	/// </summary>
	/// <remarks>An attempt to mark a mandatory update as hidden causes an error.</remarks>
	public bool IsHidden { get => upd.IsHidden; set => upd.IsHidden = value; }

	/// <summary>Gets a <see cref="bool"/> that indicates whether the update is installed on a computer when the search is performed.</summary>
	public bool IsInstalled => upd.IsInstalled;

	/// <summary>Gets a <see cref="bool"/> that indicates whether the installation of the update is mandatory.</summary>
	/// <remarks>
	/// <para>If you try to mark a mandatory update as hidden, an error occurs.</para>
	/// <para>
	/// Mandatory updates are updates to the Windows Update Agent (WUA) infrastructure. WUA may not require all mandatory updates to continue
	/// operating. However, these updates frequently improve performance or increase the number of products that WUA can offer. We recommend
	/// that you install all mandatory updates.
	/// </para>
	/// </remarks>
	public bool IsMandatory => upd.IsMandatory;

	/// <summary>Gets a <see cref="bool"/> that indicates whether an update is present on a computer.</summary>
	/// <remarks>
	/// <para>
	/// An update is considered present if it is installed for one or more products. For example, if an update applies to both Microsoft
	/// Office Word and to Microsoft Office Excel, the <see cref="IsPresent"/> property returns <see langword="true"/> if the update is
	/// installed for one or both of the products.
	/// </para>
	/// <para>
	/// If an update applies to only one product, the <see cref="IsPresent"/> and IsInstalled properties are equivalent. An update is
	/// considered installed if the update is installed for all the products to which it applies.
	/// </para>
	/// <para>
	/// If <see cref="IsPresent"/> returns <see langword="true"/> and IsInstalled returns <see langword="false"/>, the update can be
	/// uninstalled for the product that installed it.
	/// </para>
	/// </remarks>
	public bool? IsPresent => (upd as IUpdate2)?.IsPresent;

	/// <summary>Gets a <see cref="bool"/> that indicates whether a user can uninstall the update from a computer.</summary>
	public bool IsUninstallable => upd.IsUninstallable;

	/// <summary>Gets a collection of Microsoft Knowledge Base article IDs that are associated with the update.</summary>
	public IReadOnlyList<string> KBArticleIDs => new StringCollection(upd.KBArticleIDs);

	/// <summary>Gets an object that contains the languages that are supported by the update.</summary>
	/// <remarks>
	/// This property refers to the language of the update itself. The language that is used for the title and description of the update is
	/// not necessarily the language of the update itself.
	/// </remarks>
	public IReadOnlyList<string> Languages => new StringCollection(upd.Languages);

	/// <summary>
	/// Gets the last published date of the update, in Coordinated Universal Time (UTC) date and time, on the server that deploys the update.
	/// </summary>
	/// <remarks>
	/// On computers that are running Windows XP, the <see cref="LastDeploymentChangeTime"/> property retrieves the same date and time that
	/// are retrieved by the CreationDate property of the <c>UpdateApproval</c> class. The CreationDate property is used on computers
	/// that are running Windows Server 2003.
	/// </remarks>
	public DateTime LastDeploymentChangeTime => upd.LastDeploymentChangeTime;

	/// <summary>Gets the maximum download size of the update.</summary>
	/// <remarks>
	/// The MinDownloadSize property of an update is always downloaded. However, the <see cref="MaxDownloadSize"/> property is not always
	/// downloaded. The <see cref="MaxDownloadSize"/> property is downloaded based on the configuration of the computer that receives the update.
	/// </remarks>
	public decimal MaxDownloadSize => upd.MaxDownloadSize;

	/// <summary>Gets the minimum download size of the update.</summary>
	/// <remarks>
	/// The <see cref="MinDownloadSize"/> property of an update is always downloaded. However, the MaxDownloadSize property is not always
	/// downloaded. The <see cref="MaxDownloadSize"/> property is downloaded based on the configuration of the computer that receives the update.
	/// </remarks>
	public decimal MinDownloadSize => upd.MinDownloadSize;

	/// <summary>Gets a collection of language-specific strings that specify the hyperlinks to more information about the update.</summary>
	public IReadOnlyList<string> MoreInfoUrls => new StringCollection(upd.MoreInfoUrls);

	/// <summary>Gets the Microsoft Security Response Center severity rating of the update.</summary>
	/// <remarks>
	/// <para>
	/// The following ratings are the possible severity ratings of a security issue that is fixed by an update. These ratings were revised by
	/// the Microsoft Security Response Center in November 2002.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Term</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>Critical</description>
	/// <description>A security issue whose exploitation could allow the propagation of an Internet worm without user action.</description>
	/// </item>
	/// <item>
	/// <description>Important</description>
	/// <description>
	/// A security issue whose exploitation could result in compromise of the confidentiality, integrity, or availability of users' data, or
	/// of the integrity or availability of processing resources.
	/// </description>
	/// </item>
	/// <item>
	/// <description>Moderate</description>
	/// <description>
	/// Exploitation is mitigated to a significant degree by factors such as default configuration, auditing, or difficulty of exploitation.
	/// </description>
	/// </item>
	/// <item>
	/// <description>Low</description>
	/// <description>A security issue whose exploitation is extremely difficult, or whose impact is minimal.</description>
	/// </item>
	/// </list>
	/// </remarks>
	public string? MsrcSeverity => upd.MsrcSeverity;

	/// <summary>Gets a <see cref="bool"/> that indicates whether this is a per-user update.</summary>
	/// <remarks>
	/// Per-user updates are designed to alter the current user’s environment only; not the environment of the machine as a whole. For
	/// example, an update which only alters files in the current user’s user directory could be a per-user update; an update which alters
	/// files in the Program Files directory or the Windows directory would not be a per-user update. Per-user updates are currently not
	/// processed by Automatic Updates or displayed in the Windows Update user interface. Instead, they are only available to callers who
	/// specifically request them in searches by using the UpdateSearcher instance. On computers running versions of Windows Update Agent
	/// that do not implement the Update instance, only per-machine updates will be available; per-user updates will never be detected.
	/// </remarks>
	public bool PerUser => (upd as IUpdate4)?.PerUser ?? false;

	/// <summary>
	/// <para>
	/// Gets a <see cref="bool"/> that indicates whether a system restart is required on a computer to complete the installation or the
	/// uninstallation of an update.
	/// </para>
	/// </summary>
	public bool? RebootRequired => (upd as IUpdate2)?.RebootRequired;

	/// <summary>Gets the recommended CPU speed used to install the update, in megahertz (MHz).</summary>
	/// <remarks>
	/// <para>The following properties of the Update instance return 0 (zero) when the information is not available:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><see cref="RecommendedCpuSpeed"/></description>
	/// </item>
	/// <item>
	/// <description>RecommendedHardDiskSpace</description>
	/// </item>
	/// <item>
	/// <description>RecommendedMemory</description>
	/// </item>
	/// </list>
	/// </remarks>
	public int RecommendedCpuSpeed => upd.RecommendedCpuSpeed;

	/// <summary>
	/// <para>
	/// Gets the recommended free space that should be available on the hard disk before you install the update. The free space is specified
	/// in megabytes (MB).
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>The following properties of the Update instance return 0 (zero) when the information is not available:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>RecommendedCpuSpeed</description>
	/// </item>
	/// <item>
	/// <description><see cref="RecommendedHardDiskSpace"/></description>
	/// </item>
	/// <item>
	/// <description>RecommendedMemory</description>
	/// </item>
	/// </list>
	/// </remarks>
	public int RecommendedHardDiskSpace => upd.RecommendedHardDiskSpace;

	/// <summary>
	/// <para>
	/// Gets the recommended physical memory size that should be available in your computer before you install the update. The physical
	/// memory size is specified in megabytes (MB).
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>The following properties of the Update instance return 0 (zero) when the information is not available:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>RecommendedCpuSpeed</description>
	/// </item>
	/// <item>
	/// <description>RecommendedHardDiskSpace</description>
	/// </item>
	/// <item>
	/// <description><see cref="RecommendedMemory"/></description>
	/// </item>
	/// </list>
	/// </remarks>
	public int RecommendedMemory => upd.RecommendedMemory;

	/// <summary>Gets the localized release notes for the update.</summary>
	/// <remarks>
	/// <para>
	/// If the UpdateSearcher instance is created by using the UpdateSession.CreateUpdateSearcher method, the information that this property
	/// returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
	/// UpdateSession instance of the session that is used to create <see cref="UpdateSearcher"/>.
	/// </para>
	/// <para>
	/// If a language preference is not specified by the UserLocale property of UpdateSession, or if the UpdateSearcher instance is not
	/// created by using UpdateSession.CreateUpdateSearcher, the information that is returned by this property is for the default user object
	/// (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI
	/// language of the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the
	/// update recommends.
	/// </para>
	/// </remarks>
	public string? ReleaseNotes => upd.ReleaseNotes;

	/// <summary>Gets a collection of string values that contain the security bulletin IDs that are associated with the update.</summary>
	public IReadOnlyList<string> SecurityBulletinIDs => new StringCollection(upd.SecurityBulletinIDs);

	/// <summary>
	/// Gets a collection of update identifiers. This collection of identifiers specifies the updates that are superseded by the update.
	/// </summary>
	public IReadOnlyList<string> SupersededUpdateIDs => new StringCollection(upd.SupersededUpdateIDs);

	/// <summary>Gets a hyperlink to the language-specific support information for the update.</summary>
	/// <remarks>
	/// <para>
	/// If the UpdateSearcher instance is created by using the UpdateSession.CreateUpdateSearcher method, the information that this property
	/// returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
	/// UpdateSession instance of the session that is used to create <see cref="UpdateSearcher"/>.
	/// </para>
	/// <para>
	/// If a language preference is not specified by the UserLocale property of UpdateSession, or if the UpdateSearcher instance is not
	/// created by using UpdateSession.CreateUpdateSearcher, the information that is returned by this property is for the default user object
	/// (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI
	/// language of the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the
	/// update recommends.
	/// </para>
	/// </remarks>
	public string? SupportUrl => upd.SupportUrl;

	/// <summary>Gets the localized title of the update.</summary>
	/// <remarks>
	/// <para>
	/// If the UpdateSearcher instance is created by using the UpdateSession.CreateUpdateSearcher method, the information that this property
	/// returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
	/// UpdateSession instance of the session that is used to create <see cref="UpdateSearcher"/>.
	/// </para>
	/// <para>
	/// If a language preference is not specified by the UserLocale property of UpdateSession, or if the UpdateSearcher instance is not
	/// created by using UpdateSession.CreateUpdateSearcher, the information that is returned by this property is for the default user object
	/// (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI
	/// language of the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the
	/// update recommends.
	/// </para>
	/// </remarks>
	public string Title => upd.Title;

	/// <summary>Gets the type of the update.</summary>
	public UpdateType Type => upd.Type;

	/// <summary>Gets an object that contains the uninstallation options for the update.</summary>
	/// <remarks>This API can return a null pointer as the output, even when the return value is S_OK.</remarks>
	public InstallationBehavior? UninstallationBehavior => upd.UninstallationBehavior is null ? null : new(upd.UninstallationBehavior);

	/// <summary>Gets the uninstallation notes for the update.</summary>
	/// <remarks>
	/// <para>
	/// If the UpdateSearcher instance is created by using the UpdateSession.CreateUpdateSearcher method, the information that this property
	/// returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
	/// UpdateSession instance of the session that is used to create <see cref="UpdateSearcher"/>.
	/// </para>
	/// <para>
	/// If a language preference is not specified by the UserLocale property of UpdateSession, or if the UpdateSearcher instance is not
	/// created by using UpdateSession.CreateUpdateSearcher, the information that is returned by this property is for the default user object
	/// (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI
	/// language of the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the
	/// update recommends.
	/// </para>
	/// </remarks>
	public string? UninstallationNotes => upd.UninstallationNotes;

	/// <summary>Gets an object that contains the uninstallation steps for the update.</summary>
	/// <remarks>
	/// <para>
	/// If the UpdateSearcher instance is created by using the UpdateSession.CreateUpdateSearcher method, the information that this property
	/// returns is for the language that is specified by the UserLocale property. This is the <c>UserLocale</c> property of the
	/// UpdateSession instance of the session that is used to create <see cref="UpdateSearcher"/>.
	/// </para>
	/// <para>
	/// If a language preference is not specified by the UserLocale property of UpdateSession, or if the UpdateSearcher instance is not
	/// created by using UpdateSession.CreateUpdateSearcher, the information that is returned by this property is for the default user object
	/// (UI) language of the user. If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI
	/// language of the computer. If the default language of the computer is unavailable, WUA uses the language that the provider of the
	/// update recommends.
	/// </para>
	/// </remarks>
	public IReadOnlyList<string> UninstallationSteps => new StringCollection(upd.UninstallationSteps);

	/// <summary>
	/// Accepts the Microsoft Software License Terms that are associated with Windows Update. Administrators and power users can call this method.
	/// </summary>
	public void AcceptEula() => upd.AcceptEula();

	/// <summary>Copies the contents of an update to a specified path.</summary>
	/// <param name="path">The path of the location where the update contents are to be copied.</param>
	/// <param name="toExtractCabFiles">
	/// <para>Reserved for future use.</para>
	/// <para>You must set <paramref name="toExtractCabFiles"/> to <see langword="true"/> or <see langword="false"/>.</para>
	/// </param>
	/// <remarks>
	/// <para>To copy bundled updates, call this method on the individual updates that are bundled in this update.</para>
	/// <note>
	/// We don't recommend or support the use of the <c>Update.CopyFromCache</c> and Update.CopyToCache methods to move
	/// downloaded updates from one computer to another computer. When the Windows Update Agent (WUA) downloads an update, it might only
	/// download the portions of the update’s payload that are necessary for a particular client computer. The necessary portions of the
	/// update’s payload can often vary from one computer to another computer, even if the computers have similar hardware and software
	/// configurations. <c>Update.CopyToCache</c> only works if the provided files are an exact match for the files that Windows Update
	/// would have normally downloaded on that computer; if you called <c>Update.CopyFromCache</c> to obtain the files on a different
	/// computer, the files are likely not to match the files that Windows Update would have normally downloaded so
	/// <c>Update.CopyToCache</c> might fail.
	/// </note>
	/// </remarks>
	public void CopyFromCache(string path, bool toExtractCabFiles) => upd.CopyFromCache(path, toExtractCabFiles);

	/// <summary>Copies files for an update from a specified source location to the internal Windows Update Agent (WUA) download cache.</summary>
	/// <param name="pFiles">
	/// <para>A StringCollection instance that represents a collection of strings that contain the full paths of the files for an update.</para>
	/// <para>
	/// The strings must give the full paths of the files that are being copied. The strings cannot give only the directory that contains the files.
	/// </para>
	/// </param>
	/// <remarks>
	/// <para>This method returns <see cref="WUError.WU_E_INVALID_OPERATION"/> if the object that is implementing the object has been locked down.</para>
	/// <note>
	/// We don't recommend or support the use of the Update.CopyFromCache and <c>Update.CopyToCache</c> methods to move
	/// downloaded updates from one computer to another computer. When the Windows Update Agent (WUA) downloads an update, it might only
	/// download the portions of the update’s payload that are necessary for a particular client computer. The necessary portions of the
	/// update’s payload can often vary from one computer to another computer, even if the computers have similar hardware and software
	/// configurations. <c>Update.CopyToCache</c> only works if the provided files are an exact match for the files that Windows Update
	/// would have normally downloaded on that computer; if you called <c>Update.CopyFromCache</c> to obtain the files on a different
	/// computer, the files are likely not to match the files that Windows Update would have normally downloaded so
	/// <c>Update.CopyToCache</c> might fail.
	/// </note>
	/// </remarks>
	public void CopyToCache(IList<string> pFiles)
	{
		if (upd is IUpdate2 u)
		{
			StringCollection sc = new(pFiles);
			u.CopyToCache(sc.Interface);
		}
		else
			throw new NotImplementedException();
	}
}

/// <summary>Represents an ordered list of updates.</summary>
/// <remarks>
/// You can create an instance of this object by using the UpdateCollection class. Use the Microsoft.Update.UpdateColl program identifier to
/// create the object.
/// </remarks>
public class UpdateCollection : VirtualList<Update>, ICloneable
{
	/// <summary>Initializes a new instance of the <see cref="UpdateCollection"/> class.</summary>
	public UpdateCollection() : this((IUpdateCollection?)null)
	{
	}

	/// <summary>Initializes a new instance of the <see cref="UpdateCollection"/> class.</summary>
	public UpdateCollection(IEnumerable<Update> items) : this((IUpdateCollection?)null)
	{
		foreach (var i in items)
			Add(i);
	}

	internal UpdateCollection(IUpdateCollection? coll = null) : base(new UpdateCollectionMethods(coll ?? (IUpdateCollection)new UpdateCollectionClass()))
	{
	}

	/// <summary>Gets the underlying <see cref="IUpdateCollection"/> interface.</summary>
	/// <value>The <see cref="IUpdateCollection"/> interface.</value>
	public IUpdateCollection Interface => ((UpdateCollectionMethods)impl).coll;

	/// <inheritdoc/>
	public override IEnumerator<Update> GetEnumerator() => Interface.Cast<IUpdate>().Select(Conv).GetEnumerator();

	private static Update Conv(IUpdate iupd) => iupd.Type == UpdateType.utDriver && iupd is IWindowsDriverUpdate wdu ? new WindowsDriverUpdate(wdu) : new Update(iupd);

	/// <summary>Creates a shallow read/write copy of the collection.</summary>
	/// <returns>A shallow read/write copy of the collection.</returns>
	public UpdateCollection Clone() => new(Interface.Copy());

	/// <inheritdoc/>
	object ICloneable.Clone() => Clone();

	private class UpdateCollectionMethods(IUpdateCollection? c) : IVirtualListMethods<Update>
	{
		public readonly IUpdateCollection coll = c ?? (IUpdateCollection)new UpdateCollectionClass();

		public void AddItem(Update item) => coll.Add(item.upd);

		public int GetItemCount() => coll.Count;

		public void InsertItemAt(int index, Update item) => coll.Insert(index, item.upd);

		public void RemoveItemAt(int index) => coll.RemoveAt(index);

		public void SetItemAt(int index, Update value) => coll[index] = value.upd;

		public bool TryGet(int index, [NotNullWhen(true)] out Update? value)
		{
			var iupd = index >= 0 && index < coll.Count ? coll[index] : null;
			value = iupd is not null ? Conv(iupd) : null;
			return value is not null;
		}
	}

	/*IUpdate IUpdateCollection.this[int index] { get => Interface[index]; set => Interface[index] = value; }
	IEnumerator IUpdateCollection.GetEnumerator() => Interface.GetEnumerator();
	bool IUpdateCollection.ReadOnly => Interface.ReadOnly;
	int IUpdateCollection.Add(IUpdate value) => Interface.Add(value);
	IUpdateCollection IUpdateCollection.Copy() => Interface.Copy();
	void IUpdateCollection.Insert(int index, IUpdate value) => Interface.Insert(index, value);*/
}

/// <summary>Represents the download content of an update.</summary>
public class UpdateDownloadContent
{
	internal UpdateDownloadContent(IUpdateDownloadContent content)
	{
		DownloadUrl = content.DownloadUrl;
		IsDeltaCompressedContent = (content as IUpdateDownloadContent2)?.IsDeltaCompressedContent ?? false;
	}

	/// <summary>Gets the location of the download content on the server that hosts the update.</summary>
	public string DownloadUrl { get; }

	/// <summary>Gets a <see cref="bool"/> that indicates whether an update is a binary update or a full-file update.</summary>
	/// <remarks>
	/// The UpdateDownloadContent object may require you to update the Windows Update Agent (WUA). For more information, see Updating Windows
	/// Update Agent.
	/// </remarks>
	public bool IsDeltaCompressedContent { get; }
}

/// <summary>Downloads updates from the server.</summary>
/// <remarks>
/// You can create an instance of this object by using the UpdateDownloader class. Use the Microsoft.Update.Downloader program identifier to
/// create the object.
/// </remarks>
public class UpdateDownloader
{
	private readonly IUpdateDownloader downloader = new();

	/// <summary>Initializes a new instance of the <see cref="UpdateDownloader"/> class.</summary>
	/// <param name="updates">The updates to download.</param>
	public UpdateDownloader(IEnumerable<Update>? updates = null)
	{
		if (updates is not null && updates.Any())
			downloader.Updates = updates.ToCollection().Interface;
	}

	/// <summary>Gets and sets the current client application.</summary>
	/// <remarks>Returns the value Unknown if the client application has not set the property.</remarks>
	public string? ClientApplicationID { get => downloader.ClientApplicationID; set => downloader.ClientApplicationID = value; }

	/// <summary>
	/// Gets and sets a <see cref="bool"/> that indicates whether the Windows Update Agent (WUA) forces the download of updates that are
	/// already installed or that cannot be installed.
	/// </summary>
	/// <remarks>This method returns <see cref="WUError.WU_E_INVALID_OPERATION"/> if the object that is implementing the object is locked down.</remarks>
	public bool IsForced { get => downloader.IsForced; set => downloader.IsForced = value; }

	/// <summary>Gets and sets the priority level of the download.</summary>
	public DownloadPriority Priority { get => downloader.Priority; set => downloader.Priority = value; }

	/// <summary>Gets and sets an object that contains a read-only collection of the updates that are specified for download.</summary>
	public IEnumerable<Update> Updates { get => new UpdateCollection(downloader.Updates); set => downloader.Updates = value.ToCollection().Interface; }

	/// <summary>Starts a synchronous download of the content files that are associated with the updates.</summary>
	/// <returns>A DownloadResult instance that contains result codes for the download.</returns>
	/// <remarks>
	/// <para>This method returns <see cref="WUError.WU_E_INVALID_OPERATION"/> if the object that is implementing the object is locked down.</para>
	/// <para>
	/// This method returns <see cref="WUError.WU_E_NO_UPDATE"/> if the Updates property of the UpdateDownloader instance is not set. This method
	/// also returns <see cref="WUError.WU_E_NO_UPDATE"/> if the <see cref="Updates"/> property is set to an empty collection.
	/// </para>
	/// <para>This method returns <c>SUS_E_NOT_INITIALIZED</c> if the download job does not contain updates.</para>
	/// </remarks>
	public DownloadResult Download() => new(downloader.Download());

	/// <summary>Restricts access to the methods and properties of the object that implements this method.</summary>
	/// <param name="flags">
	/// <para>The option to restrict access to various Windows Update Agent (WUA) objects from the Windows Update website.</para>
	/// <para>
	/// Setting this parameter to <see cref="UpdateLockdownOption.uloForWebsiteAccess"/> or to 1 (one) restricts access to the WUA classes that implement the
	/// UpdateLockdown instance.
	/// </para>
	/// </param>
	public void LockDown([In] UpdateLockdownOption flags) => UpdateLockdown.LockDown(downloader, flags);

#if NET6_0_OR_GREATER
	/// <summary>Performs an asynchronous download of the content files that are associated with the updates.</summary>
	/// <param name="onProgressChanged">A callback method that is called periodically for download progress changes before download is complete.</param>
	/// <param name="timeout">
	/// The timeout after which the <see cref="Task"/> should be faulted with a <see cref="TimeoutException"/> if it hasn't otherwise completed.
	/// </param>
	/// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for a cancellation request.</param>
	/// <returns>A DownloadResult instance that contains result codes for a download.</returns>
	/// <remarks>
	/// <para>
	/// This method throws a <see cref="COMException"/> with <see cref="Exception.HResult"/> equal to <see cref="WUError.WU_E_INVALID_OPERATION"/> if the
	/// object that is implementing the object is locked down.
	/// </para>
	/// <para>
	/// This method throws a <see cref="COMException"/> with <see cref="Exception.HResult"/> equal to <see cref="WUError.WU_E_NO_UPDATE"/> if the Updates
	/// property of the UpdateDownloader instance is not set. This method also throws a <see cref="COMException"/> with <see cref="Exception.HResult"/>
	/// equal to WU_E_NO_UPDATE if the <see cref="Updates"/> property is set to an empty collection.
	/// </para>
	/// <para>
	/// This method throws a <see cref="COMException"/> with <see cref="Exception.HResult"/> equal to <c>SUS_E_NOT_INITIALIZED</c> if the
	/// download job contains no updates.
	/// </para>
	/// </remarks>
	public async Task<DownloadResult> DownloadAsync(Action<DownloadProgress>? onProgressChanged, TimeSpan? timeout = null, CancellationToken cancellationToken = default) =>
		await new DownloadCompletedCallback(downloader).DownloadAsync(onProgressChanged, timeout, cancellationToken);

	private class DownloadCompletedCallback(IUpdateDownloader dl) : IDownloadCompletedCallback, IDownloadProgressChangedCallback
	{
		private readonly TaskCompletionSource<DownloadResult> tcs = new();
		private Action<DownloadProgress>? onProgress;

		public async Task<DownloadResult> DownloadAsync(Action<DownloadProgress>? onProgressChanged, TimeSpan? timeout = null, CancellationToken cancellationToken = default)
		{
			onProgress = onProgressChanged;
			dl.BeginDownload(this, this, null);
			return await (timeout.HasValue ? tcs.Task.WaitAsync(timeout.Value, cancellationToken) : tcs.Task.WaitAsync(cancellationToken));
		}

		public HRESULT Invoke(IDownloadJob downloadJob, IDownloadProgressChangedCallbackArgs callbackArgs)
		{
			var prog = callbackArgs.Progress;
			onProgress?.Invoke(new(prog));
			if (tcs.Task.IsCanceled)
				downloadJob.RequestAbort();
			return HRESULT.S_OK;
		}

		public HRESULT Invoke(IDownloadJob downloadJob, IDownloadCompletedCallbackArgs callbackArgs)
		{
			if (downloadJob.IsCompleted)
			{
				var res = dl.EndDownload(downloadJob);
				tcs.SetResult(new DownloadResult(res));
			}
			return HRESULT.S_OK;
		}
	}
#endif
}

/// <summary>Contains the properties that indicate the status of a download operation for an update.</summary>
public class UpdateDownloadResult
{
	private readonly IUpdateDownloadResult res;

	internal UpdateDownloadResult(IUpdateDownloadResult res) => this.res = res;

	/// <summary>Gets the exception <see cref="HRESULT"/> value, if any, that is raised during the operation on the update.</summary>
	public HRESULT HResult => res.HResult;

	/// <summary>Gets an OperationResultCode enumeration value that specifies the result of an operation on the update.</summary>
	public OperationResultCode ResultCode => res.ResultCode;
}

/// <summary>
/// Represents info about the aspects of search results returned in the ISearchResult object that were incomplete. For more info, see Remarks.
/// </summary>
/// <remarks>
/// The <see cref="UpdateException"/> object is returned as part of the SearchResult.Warnings property when a search succeeds but can't
/// return complete results. For example, Windows Update might not have been able to retrieve all of the update metadata for a given update
/// from the server. In this situation, the search results returned in the ISearchResult object are usable, but they aren't necessarily
/// complete. The properties of the <see cref="UpdateException"/> objects that are returned by the <c>SearchResult.Warnings</c> property
/// contain info about the aspects of the search that were incomplete. This info is unlikely to be useful programmatically, but can sometimes
/// be useful for debugging.
/// </remarks>
public class UpdateException : Exception
{
	internal UpdateException(IUpdateException e) : base(e.Message)
	{
		HResult = (int)e.HResult;
		Context = e.Context;
	}

	/// <summary>Gets the context of search results.</summary>
	public UpdateExceptionContext Context { get; }
}

/// <summary>Represents an ordered read-only list of UpdateHistoryEntry instances.</summary>
public class UpdateHistory : VirtualReadOnlyList<UpdateHistoryEntry>
{
	/// <summary>Initializes a new instance of the <see cref="UpdateHistory"/> class.</summary>
	public UpdateHistory() : this(null) { }

	internal UpdateHistory(IUpdateSearcher? searcher = null) : base(new HistoryMethods(searcher))
	{
	}

	private class HistoryMethods(IUpdateSearcher? c) : IVirtualReadOnlyListMethods<UpdateHistoryEntry>
	{
		public readonly IUpdateSearcher src = c ?? new IUpdateSearcher();

		public int GetItemCount() => src.GetTotalHistoryCount();

		public bool TryGet(int index, [NotNullWhen(true)] out UpdateHistoryEntry? value)
		{
			IUpdateHistoryEntry? iupd = index >= 0 && index < GetItemCount() ? src.QueryHistory(index, 1)[0] : null;
			value = iupd is not null ? new UpdateHistoryEntry(iupd) : null;
			return value is not null;
		}
	}
}

/// <summary>Represents the recorded history of an update.</summary>
public class UpdateHistoryEntry
{
	internal readonly IUpdateHistoryEntry e;

	internal UpdateHistoryEntry(IUpdateHistoryEntry e) => this.e = e;

	/// <summary>Gets a collection of the update categories to which an update belongs.</summary>
	/// <remarks>
	/// <para>
	/// The UpdateHistoryEntry instance may require you to update Windows Update Agent (WUA). For more information, see Updating Windows
	/// Update Agent.
	/// </para>
	/// <para>
	/// The information that this property returns is for the default user interface (UI) language of the user. If the default UI language of
	/// the user is unavailable, WUA uses the default UI language of the computer. If the default language of the computer is unavailable,
	/// WUA uses the language that the provider of the update recommends.
	/// </para>
	/// <para>
	/// Because there is a Categories property of the Update instance and a <see cref="Categories"/> property of the UpdateHistoryEntry
	/// object, the information that is used by the localized properties of the Category instance depends on the WUA object that owns the
	/// <see cref="Category"/> class. If the <see cref="Category"/> class is returned from the <see cref="Categories"/> property of <see
	/// cref="Update"/>, it follows the localization rules of <see cref="Update"/>. If the <see cref="Category"/> class is returned from the
	/// <see cref="Categories"/> property of <see cref="UpdateHistoryEntry"/>, it follows the localization rules of <see cref="UpdateHistoryEntry"/>.
	/// </para>
	/// </remarks>
	public IReadOnlyCollection<Category> Categories => new CategoryCollection((e as IUpdateHistoryEntry2)?.Categories);

	/// <summary>Gets the identifier of the client application that processed an update.</summary>
	/// <remarks>Returns <see langword="null"/> if the client application has not set the property.</remarks>
	public string ClientApplicationID => e.ClientApplicationID;

	/// <summary>Gets the date and the time an update was applied.</summary>
	public DateTime Date => e.Date;

	/// <summary>Gets the description of an update.</summary>
	/// <remarks>
	/// <para>The information that this property returns is for the default user interface (UI) language of the user. However, note the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI language of the computer.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	public string? Description => e.Description;

	/// <summary>Gets the <see cref="HRESULT"/> value that is returned from the operation on an update.</summary>
	/// <remarks>The returned value is a mapped exception code. To retrieve the actual exception code, use the UnmappedResultCode property.</remarks>
	public HRESULT HResult => e.HResult;

	/// <summary>Gets an UpdateOperation value that specifies the operation on an update.</summary>
	public UpdateOperation Operation => e.Operation;

	/// <summary>Gets an OperationResultCode value that specifies the result of an operation on an update.</summary>
	public OperationResultCode ResultCode => e.ResultCode;

	/// <summary>Gets the ServerSelection value that indicates which server provided an update.</summary>
	public ServerSelection ServerSelection => e.ServerSelection;

	/// <summary>
	/// <para>
	/// Gets the service identifier of an update service that is not a Windows update. This property is meaningful only if the
	/// ServerSelection property returns <c>ssOthers</c>.
	/// </para>
	/// </summary>
	public string? ServiceID => e.ServiceID;

	/// <summary>Gets a hyperlink to the language-specific support information for an update.</summary>
	/// <remarks>
	/// <para>The information that this property returns is for the default user interface (UI) language of the user. However, note the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI language of the computer.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	public string SupportUrl => e.SupportUrl;

	/// <summary>Gets the title of an update.</summary>
	/// <remarks>
	/// <para>The information that this property returns is for the default user interface (UI) language of the user. However, note the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI language of the computer.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	public string Title => e.Title;

	/// <summary>Gets the uninstallation notes of an update.</summary>
	/// <remarks>
	/// <para>The information that this property returns is for the default user interface (UI) language of the user. However, note the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI language of the computer.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	public string? UninstallationNotes => e.UninstallationNotes;

	/// <summary>Gets the StringCollection instance that contains the uninstallation steps for an update.</summary>
	/// <remarks>
	/// <para>The information that this property returns is for the default user interface (UI) language of the user. However, note the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// If the default UI language of the user is unavailable, Windows Update Agent (WUA) uses the default UI language of the computer.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If the default language of the computer is unavailable, WUA uses the language that the provider of the update recommends.
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	public IReadOnlyList<string> UninstallationSteps => new StringCollection(e.UninstallationSteps);

	/// <summary>Gets the unmapped result code that is returned from an operation on an update.</summary>
	/// <remarks>The returned value is an unmapped result code. To retrieve a mapped exception code, use the HResult property.</remarks>
	public int UnmappedResultCode => e.UnmappedResultCode;

	/// <summary>Gets the UpdateIdentity instance that contains the identity of the update.</summary>
	public UpdateIdentity UpdateIdentity => new(e.UpdateIdentity);
}

/// <summary>Represents the unique identifier of an update.</summary>
/// <remarks>You can create an instance of this object by using the UpdateIdentity class.</remarks>
public class UpdateIdentity
{
	private readonly IUpdateIdentity id;

	internal UpdateIdentity(IUpdateIdentity id) => this.id = id;

	/// <summary>Gets the revision number of the update.</summary>
	public int RevisionNumber => id.RevisionNumber;

	/// <summary>Gets the revision-independent identifier of an update.</summary>
	public string UpdateID => id.UpdateID;
}

/// <summary>Contains the properties and the methods that are available to the status of an installation or uninstallation of an update.</summary>
public class UpdateInstallationResult
{
	private readonly IUpdateInstallationResult res;

	internal UpdateInstallationResult(IUpdateInstallationResult res) => this.res = res;

	/// <summary>Gets the <see cref="HRESULT"/> exception value that is raised during the operation on an update.</summary>
	public HRESULT HResult => res.HResult;

	/// <summary>
	/// Gets a <see cref="bool"/> that indicates whether a system restart is required on a computer to complete the installation of an update.
	/// </summary>
	public bool RebootRequired => res.RebootRequired;

	/// <summary>Gets an OperationResultCode value that specifies the result of an operation on an update.</summary>
	public OperationResultCode ResultCode => res.ResultCode;
}

/// <summary>Installs or uninstalls updates from or onto a computer.</summary>
/// <remarks>
/// This object can be instantiated by using the UpdateInstaller class. Use the Microsoft.Update.Installer program identifier to create the object.
/// </remarks>
public class UpdateInstaller
{
	private readonly IUpdateInstaller inst = new();

	/// <summary>Initializes a new instance of the <see cref="UpdateInstaller"/> class.</summary>
	/// <param name="updates">The updates to install.</param>
	public UpdateInstaller(IEnumerable<Update>? updates = null)
	{
		if (updates is not null && updates.Any())
			inst.Updates = updates.ToCollection().Interface;
	}

	/// <summary>Gets and sets a <see cref="bool"/> that indicates whether to show source prompts to the user when installing the updates.</summary>
	[DefaultValue(false)]
	public bool AllowSourcePrompts { get => inst.AllowSourcePrompts; set => inst.AllowSourcePrompts = value; }

	/// <summary>
	/// Gets and sets a value indicating whether the update installer will attempt to close applications, blocking immediate installation of updates.
	/// </summary>
	/// <returns>True if the installer will attempt to close applications.</returns>
	[DefaultValue(false)]
	public bool AttemptCloseAppsIfNecessary
	{
		get => (inst as IUpdateInstaller3)?.AttemptCloseAppsIfNecessary ?? throw new NotImplementedException();
		set { if (inst is IUpdateInstaller3 i3) i3.AttemptCloseAppsIfNecessary = value; else throw new NotImplementedException(); }
	}

	/// <summary>Gets and sets the current client application.</summary>
	/// <remarks>Returns <see langword="null"/> if the client application has not set the property.</remarks>
	[DefaultValue(null)]
	public string? ClientApplicationID { get => inst.ClientApplicationID; set => inst.ClientApplicationID = value; }

	/// <summary>
	/// Gets and sets a <see cref="bool"/> that indicates whether Windows Installer is forced to install the updates without user interaction.
	/// </summary>
	/// <remarks>
	/// You cannot forcibly silence some updates. If an update does not support this action, and you try to install the update, the update
	/// returns the following: WU_E_UH_DOESNOTSUPPORTACTION.
	/// </remarks>
	[DefaultValue(false)]
	public bool ForceQuiet
	{
		get => (inst as IUpdateInstaller2)?.ForceQuiet ?? false;
		set { if (inst is IUpdateInstaller2 i) i.ForceQuiet = value; else throw new NotImplementedException(); }
	}

	/// <summary>
	/// Gets a <see cref="bool"/> that indicates whether an installation or uninstallation is in progress on a computer at a specific time.
	/// </summary>
	/// <remarks>
	/// A new installation or uninstallation is processed only when no other installation or uninstallation is in progress. While an
	/// installation or uninstallation is in progress, a new installation or uninstallation immediately fails with the <see
	/// cref="WUError.WU_E_OPERATIONINPROGRESS"/> error. The <see cref="IsBusy"/> property does not secure an opportunity for the caller to begin a
	/// new installation or uninstallation. If the <see cref="IsBusy"/> property or a recent installation or uninstallation failure indicates
	/// that another installation or uninstallation is already in progress, the caller should attempt the installation or uninstallation later.
	/// </remarks>
	public bool IsBusy => inst.IsBusy;

	/// <summary>Gets or sets a <see cref="bool"/> that indicates whether to forcibly install or uninstall an update.</summary>
	/// <remarks>
	/// <para>
	/// A forced installation is an installation in which an update is installed even if the metadata indicates that the update is already
	/// installed. A forced uninstallation is an uninstallation in which an update is removed even if the metadata indicates that the update
	/// is not installed.
	/// </para>
	/// <para>
	/// Before you use <see cref="IsForced"/> to force an installation, determine whether the update is installed and available. If an update
	/// is not installed, a forced installation fails. For example, an update can be downloaded, and then its corresponding files removed
	/// from the cache after the expiration limit. In this case, if the files are not installed, a forced installation of the update fails.
	/// </para>
	/// </remarks>
	[DefaultValue(false)]
	public bool IsForced { get => inst.IsForced; set => inst.IsForced = value; }

	/// <summary>Gets and sets a handle to the parent window that can contain a dialog box.</summary>
	/// <remarks>
	/// This property can be changed only by a user on the computer.
	/// </remarks>
	[DefaultValue(typeof(HWND), "NULL")]
	public HWND ParentHwnd { get => inst.ParentHwnd; set => inst.ParentHwnd = value; }

	/// <summary>Gets a <see cref="bool"/> that indicates whether a system restart is required before installing or uninstalling updates.</summary>
	public bool RebootRequiredBeforeInstallation => inst.RebootRequiredBeforeInstallation;

	/// <summary>Gets and sets an object that contains a read-only collection of the updates that are specified for installation or uninstallation.</summary>
	public IEnumerable<Update> Updates { get => new UpdateCollection(inst.Updates); set => inst.Updates = value.ToCollection().Interface; }
/*
	/// <summary>Finalizes updates that were previously staged or installed.</summary>
	/// <remarks>
	/// <para>
	/// The <see cref="Commit"/> API was made public in the 1809 SDK. Any app compiled with the wuapi.h header can use the <see
	/// cref="Commit"/> method on previous versions of Windows 10 as well.
	/// </para>
	/// <para>
	/// <see cref="Commit"/> should only be called once. This call should happen just prior to commencing a reboot. Calling it multiple times
	/// prior to a reboot is not supported and may cause the update to fail.
	/// </para>
	/// <para>
	/// Calling <see cref="Commit"/> is required prior to rebooting when a feature update is pending reboot. If <see cref="Commit"/> is not
	/// called in this circumstance the update won’t be finalized and installed during the reboot.
	/// </para>
	/// <para><see cref="Commit"/> is safe to call prior to reboot for any other types of updates as well.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wuapi/nf-wuapi-iupdateinstaller4-commit HRESULT Commit( DWORD dwFlags );
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1610874882)]
	public void Commit() { if (inst is IUpdateInstaller4 i4) i4.Commit(0); else throw new NotImplementedException(); }
*/
	/// <summary>Starts a synchronous installation of the updates.</summary>
	/// <returns>
	/// A InstallationResult instance that represents the results of an installation operation for each update that is specified in a request.
	/// </returns>
	/// <remarks>
	/// This method throws a <see cref="COMException"/> with <see cref="Exception.HResult"/> equal to WU_E_NO_UPDATE if the Updates property of
	/// IUpdateInstaller is not set. This method also throws a <see cref="COMException"/> with <see cref="Exception.HResult"/> equal to WU_E_NO_UPDATE
	/// if the <see cref="Updates"/> property is set to an empty collection.
	/// </remarks>
	public InstallationResult Install() => new(inst.Install());

	/// <summary>Restricts access to the methods and properties of the object that implements this method.</summary>
	/// <param name="flags">
	/// <para>The option to restrict access to various Windows Update Agent (WUA) objects from the Windows Update website.</para>
	/// <para>
	/// Setting this parameter to <see cref="UpdateLockdownOption.uloForWebsiteAccess"/> or to 1 (one) restricts access to the WUA classes that implement the
	/// UpdateLockdown instance.
	/// </para>
	/// </param>
	public void LockDown([In] UpdateLockdownOption flags) => UpdateLockdown.LockDown(inst, flags);

	/// <summary>Starts a wizard that guides the local user through the steps to install the updates.</summary>
	/// <param name="dialogTitle">
	/// <para>An optional string value to be displayed in the title bar of the wizard.</para>
	/// <para>If an empty string value is used, the following text is displayed: Download and Install Updates.</para>
	/// </param>
	/// <returns>
	/// A InstallationResult instance that represents the results of an installation operation for each update that is specified in the request.
	/// </returns>
	/// <remarks>
	/// This method throws a <see cref="COMException"/> with <see cref="Exception.HResult"/> equal to WU_E_NO_UPDATE if the Updates property of
	/// IUpdateInstaller is not set. This method also throws a <see cref="COMException"/> with <see cref="Exception.HResult"/> equal to WU_E_NO_UPDATE
	/// if the <see cref="Updates"/> property is set to an empty collection.
	/// </remarks>
	public InstallationResult RunWizard(string dialogTitle = "") => new(inst.RunWizard(dialogTitle));

	/// <summary>Starts a synchronous uninstallation of the updates.</summary>
	/// <returns>
	/// A InstallationResult instance that represents the results of an uninstallation operation for each update that is specified in a request.
	/// </returns>
	/// <remarks>
	/// This method throws a <see cref="COMException"/> with <see cref="Exception.HResult"/> equal to WU_E_NO_UPDATE if the Updates property of
	/// IUpdateInstaller is not set. This method also throws a <see cref="COMException"/> with <see cref="Exception.HResult"/> equal to WU_E_NO_UPDATE
	/// if the <see cref="Updates"/> property is set to an empty collection.
	/// </remarks>
	public InstallationResult Uninstall() => new(inst.Uninstall());

#if NET6_0_OR_GREATER
	/// <summary>Starts an asynchronous installation of the updates.</summary>
	/// <param name="onProgressChanged">
	/// A callback method that is called periodically for installation progress changes before the installation is complete.
	/// </param>
	/// <param name="timeout">
	/// The timeout after which the <see cref="Task"/> should be faulted with a <see cref="TimeoutException"/> if it hasn't otherwise completed.
	/// </param>
	/// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for a cancellation request.</param>
	/// <returns>A InstallationResult instance that represents the overall result of the installation operation.</returns>
	/// <remarks>
	/// <para>
	/// This method throws a <see cref="COMException"/> with <see cref="Exception.HResult"/> equal to WU_E_NO_UPDATE if the Updates property of
	/// IUpdateInstaller is not set. This method also throws a <see cref="COMException"/> with <see cref="Exception.HResult"/> equal to WU_E_NO_UPDATE
	/// if the <see cref="Updates"/> property is set to an empty collection.
	/// </para>
	/// </remarks>
	public Task<InstallationResult> InstallAsync(Action<InstallationProgress>? onProgressChanged, TimeSpan? timeout = null, CancellationToken cancellationToken = default)
	{
		//var cb = new InstallCallback(inst);
		//return await cb.InstallAsync(onProgressChanged, timeout, cancellationToken);
		var task = new TaskCompletionSource<InstallationResult>();
		if (cancellationToken.IsCancellationRequested)
		{
			task.TrySetCanceled(cancellationToken);
			return task.Task;
		}
		IInstallationJob? job = null;
		CancellationTokenRegistration? reg = null;
		job = inst.BeginInstall(new InstallationProgressChangeCallback(onProgressChanged), new InstallationCompletedCallback(OnComplete), null);
		reg = cancellationToken.Register(() =>
		{
			task.TrySetCanceled(cancellationToken);
			job?.RequestAbort();
		});
		return task.Task;

		void OnComplete(IInstallationJob _job2)
		{
			try
			{
				try { task.TrySetResult(new(inst.EndInstall(_job2))); }
				catch (Exception e) { task.TrySetException(e); }
			}
			finally
			{
				job = null;
				reg?.Dispose();
			}
		}
	}

	/// <summary>Starts an asynchronous uninstallation of the updates.</summary>
	/// <param name="onProgressChanged">
	/// A callback method that is called periodically for uninstallation progress changes before the uninstallation is complete.
	/// </param>
	/// <param name="timeout">
	/// The timeout after which the <see cref="Task"/> should be faulted with a <see cref="TimeoutException"/> if it hasn't otherwise completed.
	/// </param>
	/// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for a cancellation request.</param>
	/// <returns>A InstallationResult instance that represents the overall result of an uninstallation operation.</returns>
	/// <remarks>
	/// <para>
	/// This method throws a <see cref="COMException"/> with <see cref="Exception.HResult"/> equal to WU_E_NO_UPDATE if the Updates property of
	/// IUpdateInstaller is not set. This method also throws a <see cref="COMException"/> with <see cref="Exception.HResult"/> equal to WU_E_NO_UPDATE
	/// if the <see cref="Updates"/> property is set to an empty collection.
	/// </para>
	/// </remarks>
	public async Task<InstallationResult> UninstallAsync(Action<InstallationProgress>? onProgressChanged, TimeSpan? timeout = null, CancellationToken cancellationToken = default) =>
		await new InstallCallback(inst).UninstallAsync(onProgressChanged, timeout, cancellationToken);

	internal class InstallationProgressChangeCallback(Action<InstallationProgress>? Action) : IInstallationProgressChangedCallback
	{
		HRESULT IInstallationProgressChangedCallback.Invoke([In, MarshalAs(UnmanagedType.Interface)] IInstallationJob installationJob,
			[In, MarshalAs(UnmanagedType.Interface)] IInstallationProgressChangedCallbackArgs callbackArgs)
		{ try { Action?.Invoke(new(callbackArgs.Progress)); } catch (Exception ex) { return ex.HResult; } return HRESULT.S_OK; }
	}
	internal class InstallationCompletedCallback(Action<IInstallationJob> Action) : IInstallationCompletedCallback
	{
		HRESULT IInstallationCompletedCallback.Invoke([In, MarshalAs(UnmanagedType.Interface)] IInstallationJob installationJob,
			[In, MarshalAs(UnmanagedType.Interface)] IInstallationCompletedCallbackArgs? callbackArgs)
		{ try { Action?.Invoke(installationJob); } catch (Exception ex) { return ex.HResult; } return HRESULT.S_OK; }
	}

	[ComVisible(true)]
	private class InstallCallback(IUpdateInstaller installer) : IInstallationCompletedCallback, IInstallationProgressChangedCallback
	{
		private readonly TaskCompletionSource<InstallationResult> tcs = new();
		private Action<InstallationProgress>? onProgress;

		public Task<InstallationResult> InstallAsync(Action<InstallationProgress>? onProgressChanged, TimeSpan? timeout = null, CancellationToken cancellationToken = default)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				tcs.TrySetCanceled(cancellationToken);
				return tcs.Task;
			}
			onProgress = onProgressChanged;
			var job = installer.BeginInstall(this, this, null);
			cancellationToken.Register(() => { tcs.TrySetCanceled(cancellationToken); job!.RequestAbort(); });
			return (timeout.HasValue ? tcs.Task.WaitAsync(timeout.Value, cancellationToken) : tcs.Task.WaitAsync(cancellationToken));
		}

		public async Task<InstallationResult> UninstallAsync(Action<InstallationProgress>? onProgressChanged, TimeSpan? timeout = null, CancellationToken cancellationToken = default)
		{
			onProgress = onProgressChanged;
			installer.BeginUninstall(this, this, 0);
			return await (timeout.HasValue ? tcs.Task.WaitAsync(timeout.Value, cancellationToken) : tcs.Task.WaitAsync(cancellationToken));
		}

		HRESULT IInstallationCompletedCallback.Invoke(IInstallationJob installationJob, IInstallationCompletedCallbackArgs? callbackArgs)
		{
			if (installationJob.IsCompleted)
			{
				var res = installationJob.AsyncState is int i && i == 0 ? installer.EndUninstall(installationJob) : installer.EndInstall(installationJob);
				try { tcs.TrySetResult(new InstallationResult(res)); }
				catch (Exception e) { tcs.TrySetException(e); }
			}
			return HRESULT.S_OK;
		}

		HRESULT IInstallationProgressChangedCallback.Invoke(IInstallationJob installationJob, IInstallationProgressChangedCallbackArgs callbackArgs)
		{
			IInstallationProgress prog = callbackArgs.Progress;
			onProgress?.Invoke(new(prog));
			if (tcs.Task.IsCanceled)
				installationJob.RequestAbort();
			return HRESULT.S_OK;
		}
	}
#endif
}

/// <summary>Searches for updates on a server.</summary>
/// <remarks>
/// You can create an instance of this object by using the UpdateSearcher class. Use the Microsoft.Update.Searcher program identifier to
/// create the object.
/// </remarks>
public partial class UpdateSearcher
{
	private readonly IUpdateSearcher searcher = new IUpdateSession().CreateUpdateSearcher();

	/// <summary>
	/// <para>
	/// Gets and sets a <see cref="bool"/> that indicates whether future calls to the BeginSearch and Search methods result in an automatic
	/// upgrade to Windows Update Agent (WUA). Currently, this property's valid value corresponds to the option that does not automatically
	/// upgrade WUA.
	/// </para>
	/// </summary>
	public bool CanAutomaticallyUpgradeService { get => searcher.CanAutomaticallyUpgradeService; set => searcher.CanAutomaticallyUpgradeService = value; }

	/// <summary>Identifies the current client application.</summary>
	/// <remarks>Returns <see langword="null"/> if the client application has not set the property.</remarks>
	public string ClientApplicationID { get => searcher.ClientApplicationID; set => searcher.ClientApplicationID = value; }

	/// <summary>
	/// <para>
	/// Gets and sets a <see cref="bool"/> that indicates whether to ignore the download priority. The download priority determines whether
	/// one update should replace another update.
	/// </para>
	/// </summary>
	/// <remarks>
	/// The UpdateSearcher instance may require you to update Windows Update Agent (WUA). For more information, see Updating Windows Update Agent.
	/// </remarks>
	public bool IgnoreDownloadPriority
	{
		get => (searcher as IUpdateSearcher2)?.IgnoreDownloadPriority ?? throw new NotImplementedException();
		set { if (searcher is IUpdateSearcher2 s2) s2.IgnoreDownloadPriority = value; else throw new NotImplementedException(); }
	}

	/// <summary>
	/// <para>
	/// Gets and sets a <see cref="bool"/> that indicates whether the search results include updates that are superseded by other updates in
	/// the search results.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>This property is no longer supported in Windows 10, version 1709 (build 16299), and later OS releases.</para>
	/// </para>
	/// </summary>
	public bool IncludePotentiallySupersededUpdates { get => searcher.IncludePotentiallySupersededUpdates; set => searcher.IncludePotentiallySupersededUpdates = value; }

	/// <summary>Gets and sets a <see cref="bool"/> that indicates whether the UpdateSearcher goes online to search for updates.</summary>
	public bool Online { get => searcher.Online; set => searcher.Online = value; }

	/// <summary>Synchronously queries the computer for the history of the update events.</summary>
	/// <returns>
	/// A pointer to a UpdateHistoryEntryCollection instance that contains matching event records on the computer in descending chronological order.
	/// </returns>
	public UpdateHistory QueryHistory => new(searcher);

	/// <summary>Gets or sets the search scope.</summary>
	/// <value>The search scope.</value>
	public SearchScope SearchScope
	{
		get => (searcher as IUpdateSearcher3)?.SearchScope ?? throw new NotImplementedException();
		set { if (searcher is IUpdateSearcher3 s3) s3.SearchScope = value; else throw new NotImplementedException(); }
	}

	/// <summary>Gets and sets a ServerSelection value that indicates the server to search for updates.</summary>
	/// <remarks>
	/// The site that is not a Windows Update site that is specified by the value of the ServiceID property is searched only if the value of
	/// the <see cref="ServerSelection"/> property is ssOthers.
	/// </remarks>
	public ServerSelection ServerSelection { get => searcher.ServerSelection; set => searcher.ServerSelection = value; }

	/// <summary>Gets and sets a site to search when the site to search is not a Windows Update site.</summary>
	/// <remarks>
	/// The site that is not a Windows Update site that is specified by the value of the <see cref="ServiceID"/> property is searched only if
	/// the value of the ServerSelection property is ssOthers.
	/// </remarks>
	public string? ServiceID { get => searcher.ServiceID; set => searcher.ServiceID = value; }

	/// <summary>Initiates a fluent query for filtering updates based on their properties.</summary>
	public QueryCondition Where => new(this);

	/// <summary>Converts a string into a string that can be used as a literal value in a search criteria string.</summary>
	/// <param name="unescaped">A string to be escaped.</param>
	/// <returns>The resulting escaped string.</returns>
	public string? GetEscapedString(string? unescaped) => searcher.EscapeString(unescaped);

	/// <summary>Performs a synchronous search for updates. The search uses the search options that are currently configured.</summary>
	/// <param name="criteria">A string that specifies the search criteria.</param>
	/// <returns>
	/// <para>A SearchResult instance that contains the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>The result of an operation</description>
	/// </item>
	/// <item>
	/// <description>A collection of updates that match the search criteria</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The string that is used for the <paramref name="criteria"/> parameter must match the custom search language for the <see cref="Search"/>
	/// method. The string consists of criteria that are evaluated to determine the updates to return.
	/// </para>
	/// <para>
	/// Each criterion specifies an update property name and value. With some restrictions, multiple criteria can be connected with the
	/// <c>and</c> and <c>or</c> operators. The <c>=</c> (equal) and <c>!=</c> (not-equal) operators are both supported. When you use Windows
	/// Update Agent (WUA), the <c>!=</c> (not-equal) operator can be used only with the type criterion.
	/// </para>
	/// <para>
	/// The search criteria syntax is based on the WHERE clause of an SQL query expression. Most of the supported criteria map directly to
	/// update properties. These update properties resemble the elements in a virtual XML document that contains the entire server catalog.
	/// For example, if you specify a search criteria string of "AutoSelectOnWebSites = 1", the search returns all the updates that have a
	/// AutoSelectOnWebSites property with a value of <see langword="true"/>.
	/// </para>
	/// <para>
	/// A single criterion consists of " <c>Name</c> = <c>Value</c>" or " <c>Name</c> != <c>Value</c>", where " <c>Name</c>" is one of the
	/// supported criterion names, and " <c>Value</c>" is a string or an integer. The <c>and</c> and <c>or</c> operators can be used to
	/// connect multiple criteria. However, <c>or</c> can be used only at the top level of the search criteria. Therefore, "(x=1 and y=1) or
	/// (z=1)" is valid, but "(x=1) and (y=1 or z=1)" is not valid.
	/// </para>
	/// <para>
	/// The supported value types are integers and strings. An integer must be specified in base 10, and negative numbers are prefixed with a
	/// minus sign ( <c>-</c>). A string must be escaped and enclosed in single quotation marks ('). All string comparisons are
	/// case-insensitive unless specified.
	/// </para>
	/// <para>
	/// The following table identifies all the public support criteria in the order of evaluation precedence. More criteria may be added to
	/// this list in the future.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Criterion</description>
	/// <description>Type</description>
	/// <description>Allowed operators</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>Type</description>
	/// <description><see cref="string"/></description>
	/// <description><c>=</c>, <c>!=</c></description>
	/// <description>Finds updates of a specific type, such as "'Driver'" and "'Software'".</description>
	/// </item>
	/// <item>
	/// <description>DeploymentAction</description>
	/// <description><see cref="string"/></description>
	/// <description><c>=</c></description>
	/// <description>
	/// Finds updates that are deployed for a specific action, such as an installation or uninstallation that the administrator of a server
	/// specifies. "DeploymentAction='Installation'" finds updates that are deployed for installation on a destination computer.
	/// "DeploymentAction='Uninstallation'" depends on the other query criteria. "DeploymentAction='Uninstallation'" finds updates that are
	/// deployed for uninstallation on a destination computer. "DeploymentAction='Uninstallation'" depends on the other query criteria. If
	/// this criterion is not explicitly specified, each group of criteria that is joined to an <c>and</c> operator implies "DeploymentAction='Installation'".
	/// </description>
	/// </item>
	/// <item>
	/// <description>IsAssigned</description>
	/// <description><c>int(bool)</c></description>
	/// <description><c>=</c></description>
	/// <description>
	/// Finds updates that are intended for deployment by Automatic Updates. "IsAssigned=1" finds updates that are intended for deployment by
	/// Automatic Updates, which depends on the other query criteria. At most, one assigned Windows-based driver update is returned for each
	/// local device on a destination computer. "IsAssigned=0" finds updates that are not intended to be deployed by Automatic Updates.
	/// </description>
	/// </item>
	/// <item>
	/// <description>BrowseOnly</description>
	/// <description><c>int(bool)</c></description>
	/// <description><c>=</c></description>
	/// <description>
	/// "BrowseOnly=1" finds updates that are considered optional. "BrowseOnly=0" finds updates that are not considered optional.
	/// </description>
	/// </item>
	/// <item>
	/// <description>AutoSelectOnWebSites</description>
	/// <description><c>int(bool)</c></description>
	/// <description><c>=</c></description>
	/// <description>
	/// Finds updates where the AutoSelectOnWebSites property has the specified value. "AutoSelectOnWebSites=1" finds updates that are
	/// flagged to be automatically selected by Windows Update. "AutoSelectOnWebSites=0" finds updates that are not flagged for Automatic Updates.
	/// </description>
	/// </item>
	/// <item>
	/// <description>UpdateID</description>
	/// <description><c>string(UUID)</c></description>
	/// <description><c>=</c>, <c>!=</c></description>
	/// <description>
	/// Finds updates for which the value of the UpdateIdentity.UpdateID property matches the specified value. Can be used with the <c>!=</c>
	/// operator to find all the updates that do not have an <c>UpdateIdentity.UpdateID</c> of the specified value. For example,
	/// "UpdateID='12345678-9abc-def0-1234-56789abcdef0'" finds updates for UpdateIdentity.UpdateID that equal
	/// 12345678-9abc-def0-1234-56789abcdef0. For example, "UpdateID!='12345678-9abc-def0-1234-56789abcdef0'" finds updates for
	/// UpdateIdentity.UpdateID that are not equal to 12345678-9abc-def0-1234-56789abcdef0. For example,
	/// "UpdateID='12345678-9abc-def0-1234-56789abcdef0' and RevisionNumber=100" can be used to find the update for UpdateIdentity.UpdateID
	/// that equals 12345678-9abc-def0-1234-56789abcdef0 and whose UpdateIdentity.RevisionNumber equals 100.
	/// </description>
	/// </item>
	/// <item>
	/// <description>RevisionNumber</description>
	/// <description><see cref="int"/></description>
	/// <description><c>=</c></description>
	/// <description>
	/// Finds updates for which the value of the UpdateIdentity.RevisionNumber property matches the specified value. For example,
	/// "RevisionNumber=2" finds updates where UpdateIdentity.RevisionNumber equals 2. This criterion must be combined with the UpdateID property.
	/// </description>
	/// </item>
	/// <item>
	/// <description>CategoryIDs</description>
	/// <description><c>string(uuid)</c></description>
	/// <description><c>contains</c></description>
	/// <description>Finds updates that belong to a specified category.</description>
	/// </item>
	/// <item>
	/// <description>IsInstalled</description>
	/// <description><c>int(bool)</c></description>
	/// <description><c>=</c></description>
	/// <description>
	/// Finds updates that are installed on the destination computer. "IsInstalled=1" finds updates that are installed on the destination
	/// computer. "IsInstalled=0" finds updates that are not installed on the destination computer.
	/// </description>
	/// </item>
	/// <item>
	/// <description>IsHidden</description>
	/// <description><c>int(bool)</c></description>
	/// <description><c>=</c></description>
	/// <description>
	/// Finds updates that are marked as hidden on the destination computer. "IsHidden=1" finds updates that are marked as hidden on a
	/// destination computer. When you use this clause, you can set the UpdateSearcher.IncludePotentiallySupersededUpdates property to <see
	/// langword="true"/> so that a search returns the hidden updates. The hidden updates might be superseded by other updates in the same
	/// results. "IsHidden=0" finds updates that are not marked as hidden. If the UpdateSearcher.IncludePotentiallySupersededUpdates property
	/// is set to <see langword="false"/>, it is better to include that clause in the search filter string so that the updates that are
	/// superseded by hidden updates are included in the search results. <see langword="false"/> is the default value.
	/// </description>
	/// </item>
	/// <item>
	/// <description>IsPresent</description>
	/// <description><c>int(bool)</c></description>
	/// <description><c>=</c></description>
	/// <description>
	/// When set to 1, finds updates that are present on a computer. "IsPresent=1" finds updates that are present on a destination computer.
	/// If the update is valid for one or more products, the update is considered present if it is installed for one or more of the products.
	/// "IsPresent=0" finds updates that are not installed for any product on a destination computer.
	/// </description>
	/// </item>
	/// <item>
	/// <description>RebootRequired</description>
	/// <description><c>int(bool)</c></description>
	/// <description><c>=</c></description>
	/// <description>
	/// Finds updates that require a computer to be restarted to complete an installation or uninstallation. "RebootRequired=1" finds updates
	/// that require a computer to be restarted to complete an installation or uninstallation. "RebootRequired=0" finds updates that do not
	/// require a computer to be restarted to complete an installation or uninstallation.
	/// </description>
	/// </item>
	/// </list>
	/// <para>The default search criteria for a search are as follows:</para>
	/// <para>
	/// To find all the hidden updates (by using the UpdateSearcher.IncludePotentiallySupersededUpdates property set to <see
	/// langword="true"/>), use the following criterion:
	/// </para>
	/// </remarks>
	public SearchResult Search(string criteria = "") => new(searcher.Search(criteria));

#if NET6_0_OR_GREATER
	/// <summary>Begins execution of an asynchronous search for updates. The search uses the search options that are currently configured.</summary>
	/// <param name="criteria">A string that specifies the search criteria.</param>
	/// <param name="timeout">
	/// The timeout after which the <see cref="Task"/> should be faulted with a <see cref="TimeoutException"/> if it hasn't otherwise completed.
	/// </param>
	/// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for a cancellation request.</param>
	/// <returns>
	/// <para>A SearchResult instance that contains the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>The result of an operation</description>
	/// </item>
	/// <item>
	/// <description>A collection of updates that match the search criteria</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For a complete description of search criteria syntax, see Search.</para>
	/// </remarks>
	public async Task<SearchResult> SearchAsync(string criteria = "", TimeSpan? timeout = null, CancellationToken cancellationToken = default)
	{
		var cb = new SearchCompletedCallback(searcher);
		return await cb.SearchAsync(criteria, timeout, cancellationToken);
	}

	private class SearchCompletedCallback(IUpdateSearcher searcher) : ISearchCompletedCallback
	{
		private readonly TaskCompletionSource<SearchResult> tcs = new();

		public async Task<SearchResult> SearchAsync(string criteria, TimeSpan? timeout = null, CancellationToken cancellationToken = default)
		{
			searcher.BeginSearch(criteria, this, 0);
			return await (timeout.HasValue ? tcs.Task.WaitAsync(timeout.Value, cancellationToken) : tcs.Task.WaitAsync(cancellationToken));
		}

		HRESULT ISearchCompletedCallback.Invoke(ISearchJob searchJob, ISearchCompletedCallbackArgs callbackArgs)
		{
			if (searchJob.IsCompleted)
			{
				var res = searcher.EndSearch(searchJob);
				tcs.SetResult(new SearchResult(res));
			}
			return HRESULT.S_OK;
		}
	}
#endif
}

/// <summary>Contains information about a service that is registered with Windows Update Agent (WUA) or with Automatic Updates.</summary>
public class UpdateService
{
	internal readonly IUpdateService svc;
	internal IUpdateServiceRegistration? reg = null;

	internal UpdateService(IUpdateService svc) => this.svc = svc ?? throw new ArgumentNullException(nameof(svc));

	/// <summary>Gets a <see cref="bool"/> that indicates whether the service can register with Automatic Updates.</summary>
	public bool CanRegisterWithAU => svc.CanRegisterWithAU;

	/// <summary>Gets an SHA-1 hash of the certificate that is used to sign the contents of the service.</summary>
	public byte[]? ContentValidationCert => (byte[]?)svc.ContentValidationCert;

	/// <summary>
	/// Gets a <see cref="bool"/> that indicates whether the service is registered with Automatic Updates and whether the service is
	/// currently used by Automatic Updates as the default service.
	/// </summary>
	public bool? IsDefaultAUService => (svc as IUpdateService2)?.IsDefaultAUService;

	/// <summary>Gets a <see cref="bool"/> that indicates whether a service is a managed service.</summary>
	public bool IsManaged => svc.IsManaged;

	/// <summary>
	/// Gets a <see cref="bool"/> that indicates whether the service will also be registered with Automatic Updates, when added. The
	/// authorization cabinet file (.cab) of the service determines whether the service can be added.
	/// </summary>
	/// <remarks>
	/// If the RegistrationState property is <see cref="UpdateServiceRegistrationState.usrsRegistrationPending"/>, registration with Automatic Updates is subject to the
	/// allowed settings that are specified in the authorization cabinet file (.cab) for the service. If the authorization cabinet file does
	/// not allow registration with Automatic Updates, the service will be registered with Windows Update Agent (WUA). However, the service
	/// will not be registered with Automatic Updates.
	/// </remarks>
	public bool IsPendingRegistrationWithAU => Reg.IsPendingRegistrationWithAU;

	/// <summary>Gets a <see cref="bool"/> that indicates whether a service is registered with Automatic Updates.</summary>
	public bool IsRegisteredWithAU => svc.IsRegisteredWithAU;

	/// <summary>Gets a <see cref="bool"/> that indicates whether a service is based on a scan package.</summary>
	public bool IsScanPackageService => svc.IsScanPackageService;

	/// <summary>Gets the date on which the authorization cabinet file was issued.</summary>
	public DateTime IssueDate => svc.IssueDate;

	/// <summary>Gets the name of the service.</summary>
	/// <remarks>
	/// The localized properties of an update are returned in the language that corresponds to the user default user interface (UI) language
	/// of the caller. If a property of an update is unavailable in such language, it will be returned in the system default UI language on
	/// the specified computer. If the property is unavailable in either languages mentioned, then it will be returned in the language
	/// recommended, if any, by the provider of the Update. Otherwise the Update Service will choose a language as it sees fit for the property.
	/// </remarks>
	public string? Name => svc.Name;

	/// <summary>Gets a <see cref="bool"/> indicates whether the current service offers updates from Windows Updates.</summary>
	public bool OffersWindowsUpdates => svc.OffersWindowsUpdates;

	/// <summary>The <see cref="RedirectUrls"/> property contains the URLs for the redirector cabinet file.</summary>
	public IReadOnlyList<string> RedirectUrls => new StringCollection(svc.RedirectUrls);

	/// <summary>Gets an UpdateServiceRegistrationState value that indicates the current state of the service registration.</summary>
	public UpdateServiceRegistrationState RegistrationState => Reg.RegistrationState;

	/// <summary>The <see cref="ServiceID"/> property retrieves or sets the identifier for a service.</summary>
	public string ServiceID => svc.ServiceID;

	/// <summary>The <see cref="ServiceUrl"/> property retrieves the URL for the service.</summary>
	public string? ServiceUrl => svc.ServiceUrl;

	/// <summary>The <see cref="SetupPrefix"/> property identifies the prefix for the setup files.</summary>
	public string? SetupPrefix => svc.SetupPrefix;

	private IUpdateServiceRegistration Reg => reg ??= new IUpdateServiceManager2().QueryServiceRegistration(ServiceID);
}

/// <summary>Adds or removes the registration of the update service with Windows Update Agent or Automatic Updates.</summary>
/// <remarks>
/// You can create an instance of this object by using the UpdateServiceManager class. Use the Microsoft.Update.ServiceManager program
/// identifier to create the object.
/// </remarks>
public class UpdateServiceManager : IReadOnlyList<UpdateService>
{
	private readonly IUpdateServiceManager mgr = new();

	/// <summary>Gets and sets the identifier of the current client application.</summary>
	/// <remarks>Returns <see langword="null"/> if the client application has not set the property.</remarks>
	public string? ClientApplicationID
	{
		get => (mgr as IUpdateServiceManager2)?.ClientApplicationID;
		set { if (mgr is IUpdateServiceManager2 m2) m2.ClientApplicationID = value; else throw new NotImplementedException(nameof(ClientApplicationID)); }
	}

	/// <inheritdoc/>
	public int Count => mgr.Services.Count;

	/// <inheritdoc/>
	public UpdateService this[int index] => index < 0 || index >= Count ? throw new ArgumentOutOfRangeException(nameof(index)) : new(mgr.Services[index]);

	/// <summary>Gets the <see cref="UpdateService"/> with the specified service identifier.</summary>
	/// <param name="id">The service identifier of a registered service.</param>
	/// <returns>The resulting <see cref="UpdateService"/> instance.</returns>
	/// <exception cref="System.ArgumentOutOfRangeException">id</exception>
	public UpdateService this[string id]
	{
		get
		{
			var res = mgr.Services.Cast<IUpdateService>().FirstOrDefault(s => s.ServiceID == id);
			return res is not null ? new(res) : throw new ArgumentOutOfRangeException(nameof(id));
		}
	}

	/// <summary>Registers a scan package as a service with Windows Update Agent (WUA) and then returns a UpdateService instance.</summary>
	/// <param name="serviceName">A descriptive name for the scan package service.</param>
	/// <param name="scanFileLocation">The path of the Microsoft signed scan file that has to be registered as a service.</param>
	/// <returns>A pointer to a UpdateService instance that contains service registration information.</returns>
	/// <remarks>
	/// <para>You can use the ID of the service in searches by passing the ID as the ServiceID property of the UpdateSearcher instance.</para>
	/// <para>To free resources, remove the service after it is no longer needed. Use the RemoveService method to remove the service.</para>
	/// <para>Do not call the RegisterServiceWithAU method for the service that the <see cref="AddScanPackageService"/> method registers.</para>
	/// <para>
	/// The service that is returned by <see cref="AddScanPackageService"/> is in the collection of services that the Services property of
	/// the UpdateServiceManager instance returns. This service has the special IsScanPackageService property.
	/// </para>
	/// <para>An error is returned by WinVerifyTrust if the Authorization Cab is not signed.</para>
	/// <para>This method returns <see cref="WUError.WU_E_INVALID_OPERATION"/> if the object that implements the object has been locked down.</para>
	/// </remarks>
	public UpdateService AddScanPackageService(string serviceName, string scanFileLocation) =>
		mgr is IUpdateServiceManager2 mgr2
			? (UpdateService)new(mgr2.AddScanPackageService(serviceName, scanFileLocation))
			: throw new NotImplementedException();

	/// <summary>
	/// Registers a service with Windows Update Agent (WUA) without requiring an authorization cabinet file (.cab). This method also returns
	/// a pointer to a UpdateServiceRegistration instance.
	/// </summary>
	/// <param name="serviceID">An identifier for the service to be registered.</param>
	/// <param name="flags">
	/// A combination of AddServiceFlag values that are combined by using a bitwise OR operation. The resulting value specifies options for
	/// service registration. For more info, see Remarks.
	/// </param>
	/// <param name="authorizationCabPath">
	/// The path of the Microsoft signed local cabinet file (.cab) that has the information that is required for a service registration. If
	/// empty, the update agent searches for the authorization cabinet file (.cab) during service registration when a network connection is available.
	/// </param>
	/// <returns>A pointer to a UpdateServiceRegistration instance that represents an added service.</returns>
	/// <remarks>
	/// <para>This method may return networking error codes when the <see cref="AddServiceFlag.asfAllowOnlineRegistration"/> flag is specified.</para>
	/// <para>
	/// The <paramref name="authorizationCabPath"/> parameter is optional for this method. If the <paramref name="authorizationCabPath"/> parameter is
	/// not specified, it will be retrieved from the Windows Update server.
	/// </para>
	/// <para>
	/// This method returns <see cref="HRESULT.E_INVALIDARG"/> if the <see cref="AddServiceFlag.asfAllowOnlineRegistration"/> or <see
	/// cref="AddServiceFlag.asfAllowPendingRegistration"/> flags are specified and if the value of the <paramref name="authorizationCabPath"/> parameter is not
	/// an empty string.
	/// </para>
	/// <para>
	/// This method returns <see cref="WUError.WU_E_DS_INVALIDOPERATION"/> if the requested change in the state of Automatic Updates is contrary to
	/// the specifications in the authorization cabinet file (.cab) when the <see cref="AddServiceFlag.asfRegisterServiceWithAU"/> flag is specified. An
	/// error is returned by the WinVerifyTrust function if the authorization cabinet file has not been signed.
	/// </para>
	/// <para>
	/// The update agent and <see cref="AddService"/> behave in the following ways depending on the AddServiceFlag values that you specify
	/// in the <paramref name="flags"/> parameter:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// If you specify <see cref="AddServiceFlag.asfAllowOnlineRegistration"/> without <see cref="AddServiceFlag.asfAllowPendingRegistration"/>, the update agent
	/// immediately attempts to go online to register the service. <see cref="AddService"/> returns an HRESULT value that reflects the
	/// success or failure of the registration. If the registration fails, the update agent makes no future attempts to register the service.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If you specify <see cref="AddServiceFlag.asfAllowPendingRegistration"/> without <see cref="AddServiceFlag.asfAllowOnlineRegistration"/>, the update agent doesn't
	/// register the service immediately. <see cref="AddService"/> returns S_OK to indicate that the update agent will attempt to register
	/// the service at a later time, which doesn't guarantee that the registration will eventually succeed.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If you specify <see cref="AddServiceFlag.asfAllowPendingRegistration"/> and <see cref="AddServiceFlag.asfAllowOnlineRegistration"/> together, the update agent
	/// immediately attempts to go online to register the service. <see cref="AddService"/> returns S_OK if the registration succeeds. <see
	/// cref="AddService"/> returns a failure HRESULT value if the registration fails, but the update agent still attempts to register the
	/// service at a later time.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If you specify <see cref="AddServiceFlag.asfAllowPendingRegistration"/>, <see cref="AddServiceFlag.asfAllowOnlineRegistration"/>, or both, also specify <c><see
	/// langword="null"/></c> for the <paramref name="authorizationCabPath"/> parameter.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If you specify neither <see cref="AddServiceFlag.asfAllowPendingRegistration"/> nor <see cref="AddServiceFlag.asfAllowOnlineRegistration"/> (in other words, if
	/// <paramref name="flags"/> is either zero or <see cref="AddServiceFlag.asfRegisterServiceWithAU"/>), you must specify a non- <c><see langword="null"/></c>
	/// path in the <paramref name="authorizationCabPath"/> parameter. In this mode, <see cref="AddService"/> processes the cabinet file (.cab)
	/// and registers the service in the same way as UpdateServiceManager.AddService.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// If you specify <see cref="AddServiceFlag.asfRegisterServiceWithAU"/>, the change to the default Automatic Updates service doesn't occur (and isn't
	/// reflected in the Windows Update user interface) until the service registration succeeds. This means that if the registration succeeds
	/// immediately (because you specified <see cref="AddServiceFlag.asfAllowPendingRegistration"/> or supplied a cabinet file (.cab)), the Automatic
	/// Updates service change also occurs immediately. If the registration doesn't succeed until later (because you specified <see
	/// cref="AddServiceFlag.asfAllowPendingRegistration"/>), the Automatic Updates service change doesn't occur unless the pending service registration
	/// eventually succeeds.
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	public UpdateService? AddService(string serviceID, AddServiceFlag flags = AddServiceFlag.asfAllowOnlineRegistration, string authorizationCabPath = "")
	{
		if (mgr is IUpdateServiceManager2 mgr2)
		{
			var ret = mgr2.AddService2(serviceID, flags, authorizationCabPath);
			return ret.Service is null ? null : new(ret.Service);
		}
		var ius = mgr.AddService(serviceID, authorizationCabPath);
		if (flags.IsFlagSet(AddServiceFlag.asfRegisterServiceWithAU))
			RegisterServiceWithAU(serviceID);
		return new UpdateService(ius);
	}

	/// <inheritdoc/>
	public IEnumerator<UpdateService> GetEnumerator() => mgr.Services.Cast<IUpdateService>().Select(s => new UpdateService(s)).GetEnumerator();

	/// <summary>Restricts access to the methods and properties of the object that implements this method.</summary>
	/// <param name="flags">
	/// <para>The option to restrict access to various Windows Update Agent (WUA) objects from the Windows Update website.</para>
	/// <para>
	/// Setting this parameter to <see cref="UpdateLockdownOption.uloForWebsiteAccess"/> or to 1 (one) restricts access to the WUA classes that implement the
	/// UpdateLockdown instance.
	/// </para>
	/// </param>
	public void LockDown([In] UpdateLockdownOption flags) => UpdateLockdown.LockDown(mgr, flags);

	/// <summary>Registers a service with Automatic Updates.</summary>
	/// <param name="serviceID">An identifier for the service to be registered.</param>
	/// <remarks>
	/// <para>This method returns <see cref="WUError.WU_E_DS_UNKNOWNSERVICE"/> if the service to be registered is unknown to Automatic Updates.</para>
	/// <para>
	/// This method returns <see cref="WUError.WU_E_INVALID_OPERATION"/> if the method is called with an invalid service ID. This method also returns
	/// <see cref="WUError.WU_E_INVALID_OPERATION"/> if the service ID is valid but the service can't register with Automatic Updates. That is, the
	/// requested change in the state of Automatic Updates is contrary to the specifications in the authorization cabinet file (for example,
	/// CanRegisterWithAU property is set to <see langword="false"/>). An error is returned by WinVerifyTrust function if the authorization
	/// cabinet file has not been signed.
	/// </para>
	/// <para>This method returns <see cref="WUError.WU_E_DS_NEEDWINDOWSSERVICE"/> if you try to remove the Windows Update service.</para>
	/// </remarks>
	public void RegisterServiceWithAU(string serviceID) => mgr.RegisterServiceWithAU(serviceID);

	/// <summary>Removes a service registration from Windows Update Agent (WUA).</summary>
	/// <param name="serviceID">An identifier for the service to be unregistered.</param>
	public void RemoveService(string serviceID) => mgr.RemoveService(serviceID);

	/// <summary>
	/// Set options for the object that specifies the service ID. The <see cref="SetOption"/> method is also used to determine whether a
	/// warning is displayed when you change the registration of Automatic Updates.
	/// </summary>
	/// <param name="optionName">
	/// <para>Set this parameter to AllowedServiceID to specify the form of the service ID that is provided to the object.</para>
	/// <para>Set to AllowWarningUI to display a warning when changing the Automatic Updates registration.</para>
	/// </param>
	/// <param name="optionValue">
	/// <para>
	/// If the <paramref name="optionName"/> parameter is set to AllowServiceID, the <paramref name="optionValue"/> parameter is set to the service ID
	/// that is provided as a <see cref="string"/> value.
	/// </para>
	/// <para>
	/// If <paramref name="optionName"/> is set to AllowWarningUI, <paramref name="optionValue"/> is a <see cref="bool"/> value that specifies
	/// whether to display a warning when changing the registration of Automatic Updates.
	/// </para>
	/// <para>
	/// Set the optionValue parameter to <see langword="true"/> to display the warning UI. Set it to <see langword="false"/> to suppress the
	/// warning UI.
	/// </para>
	/// </param>
	public void SetOption(string optionName, object optionValue) => mgr.SetOption(optionName, optionValue);

	/// <summary>Unregisters a service with Automatic Updates.</summary>
	/// <param name="serviceID">An identifier for the service to be unregistered.</param>
	/// <remarks>
	/// <para>
	/// This method returns <see cref="WUError.WU_E_DS_INVALIDOPERATION"/> if the requested change in the state of Automatic Updates is contrary to
	/// the specifications in the Authorization Cab. An error is returned by WinVerifyTrust function if the Authorization Cab has not been signed.
	/// </para>
	/// <para>This method returns <see cref="WUError.WU_E_DS_UNKNOWNSERVICE"/> if the service to be removed does not exist.</para>
	/// <para>
	/// This method returns <see cref="WUError.WU_E_DS_NEEDWINDOWSSERVICE"/> if you attempt to remove the Windows Update service and if it is the
	/// only service that is registered with Automatic Updates.
	/// </para>
	/// </remarks>
	public void UnregisterServiceWithAU(string serviceID) => mgr.UnregisterServiceWithAU(serviceID);

	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

/// <summary>
/// <para>Contains the HTTP proxy settings.</para>
/// <para><c>Important</c> This object is not supported on Windows 10 and Windows Server 2016. See the remarks for more details.</para>
/// </summary>
/// <remarks>
/// <para>
/// You can create an instance of this object by using the WebProxy class. Use the Microsoft.Update.WebProxy program identifier to create the object.
/// </para>
/// <note type="important">
/// This object is not supported on Windows 10 and Windows Server 2016. To configure proxy settings on these
/// operating systems (including proxy settings for Windows Update Agent), use the <c>Proxy</c> page of the <c>Network &amp;
/// Internet</c> section in <c>Settings</c>. You can optionally use a proxy auto-config script to apply settings. If you configure
/// proxy settings, be sure to allow access to the domains used by Windows Update listed in this article.
/// </note>
/// </remarks>
public class WebProxy
{
	internal readonly IWebProxy Interface;

	/// <summary>Initializes a new instance of the <see cref="WebProxy"/> class.</summary>
	public WebProxy() : this(null)
	{
	}

	internal WebProxy(IWebProxy? wp) => this.Interface = wp ?? new();

	/// <summary>Gets and sets the address and the decimal port number of the proxy server.</summary>
	/// <remarks>
	/// The value of the <see cref="Address"/> property is ignored if the value of the AutoDetect property is set to <see langword="true"/>.
	/// When <see cref="Address"/> is a null reference (for example, if you specified Nothing in Visual Basic), all the requests bypass the
	/// proxy. The requests connect directly to the destination host.
	/// </remarks>
	public string? Address { get => Interface.Address; set => Interface.Address = value; }

	/// <summary>Gets and sets a <see cref="bool"/> that indicates whether IWebProxy automatically detects proxy settings.</summary>
	/// <remarks>
	/// The values of the Address, BypassList, and BypassProxyOnLocal properties are ignored if the value of the <see cref="AutoDetect"/>
	/// property is set to <see langword="true"/>.
	/// </remarks>
	public bool AutoDetect { get => Interface.AutoDetect; set => Interface.AutoDetect = value; }

	/// <summary>Gets and sets a collection of addresses that do not use the proxy server.</summary>
	/// <remarks>
	/// The value of the <see cref="BypassList"/> property is ignored if the value of the AutoDetect property is set to <see langword="true"/>.
	/// </remarks>
	public IList<string> BypassList { get => new StringCollection(Interface.BypassList); set => Interface.BypassList = new StringCollection(value).Interface; }

	/// <summary>Gets and sets a <see cref="bool"/> that indicates whether local addresses bypass the proxy server.</summary>
	/// <remarks>
	/// The value of the <see cref="BypassProxyOnLocal"/> property is ignored if the value of the AutoDetect property is set to <see langword="true"/>.
	/// </remarks>
	public bool BypassProxyOnLocal { get => Interface.BypassProxyOnLocal; set => Interface.BypassProxyOnLocal = value; }

	/// <summary>Gets a <see cref="bool"/> that indicates whether the WebProxy object is read-only.</summary>
	public bool ReadOnly => Interface.ReadOnly;

	/// <summary>Gets and sets the user name to submit to the proxy server for authentication.</summary>
	public string? UserName { get => Interface.UserName; set => Interface.UserName = value; }

	/// <summary>Restricts access to the methods and properties of the object that implements this method.</summary>
	/// <param name="flags">
	/// <para>The option to restrict access to various Windows Update Agent (WUA) objects from the Windows Update website.</para>
	/// <para>
	/// Setting this parameter to <see cref="UpdateLockdownOption.uloForWebsiteAccess"/> or to 1 (one) restricts access to the WUA classes that implement the
	/// UpdateLockdown instance.
	/// </para>
	/// </param>
	public void LockDown([In] UpdateLockdownOption flags) => UpdateLockdown.LockDown(Interface, flags);

	/// <summary>Prompts the user for the password to use for proxy authentication.</summary>
	/// <param name="parentWindow">The parent window of the dialog box in which the user enters the credentials.</param>
	/// <param name="title">The title to use for the dialog box in which the user enters the credentials.</param>
	/// <remarks>
	/// <para>This method can be changed only by a user on the computer. This method can be accessed through the Dispatch instance.</para>
	/// <para>
	/// If null is specified for the parent window (for example, if you specified Nothing in Visual Basic), the dialog box is displayed on
	/// the desktop.
	/// </para>
	/// </remarks>
	public void PromptForCredentials([In, Optional] HWND parentWindow, string? title) => Interface.PromptForCredentialsFromHwnd(parentWindow, title ?? "");

	/// <summary>Sets the password to submit to the proxy server for authentication.</summary>
	/// <param name="value">The password to submit to the proxy server for authentication.</param>
	public void SetPassword(string? value) => Interface.SetPassword(value);
}

/// <summary>Contains the properties and the methods that are available only from a Windows driver update.</summary>
/// <remarks>
/// This object can be obtained by calling the QueryInterface method on a Update instance only if the object represents a Windows driver update.
/// </remarks>
public class WindowsDriverUpdate : Update
{
	private readonly IWindowsDriverUpdate Interface;

	internal WindowsDriverUpdate(IWindowsDriverUpdate upd) : base(upd) => Interface = upd;

	/// <summary>Gets the problem number of the matching device for the Windows driver update.</summary>
	public int DeviceProblemNumber => Interface.DeviceProblemNumber;

	/// <summary>Gets the status of the matching device for the Windows driver update.</summary>
	public int DeviceStatus => Interface.DeviceStatus;

	/// <summary>Gets the class of the Windows driver update.</summary>
	public string? DriverClass => Interface.DriverClass;

	/// <summary>Gets the hardware ID or compatible ID that the Windows driver update must match to be installable.</summary>
	public string? DriverHardwareID => Interface.DriverHardwareID;

	/// <summary>Gets the language-invariant name of the manufacturer of the Windows driver update.</summary>
	public string? DriverManufacturer => Interface.DriverManufacturer;

	/// <summary>Gets the language-invariant model name of the device for which the Windows driver update is intended.</summary>
	public string? DriverModel => Interface.DriverModel;

	/// <summary>Gets the language-invariant name of the provider of the Windows driver update.</summary>
	public string? DriverProvider => Interface.DriverProvider;

	/// <summary>Gets the driver version date of the Windows driver update.</summary>
	public DateTime DriverVerDate => Interface.DriverVerDate;

	/// <summary>Gets the driver update entries that are applicable for the update.</summary>
	public IReadOnlyList<WindowsDriverUpdateEntry> WindowsDriverUpdateEntries => (Interface as IWindowsDriverUpdate4)?.WindowsDriverUpdateEntries.GetList<IWindowsDriverUpdateEntry, WindowsDriverUpdateEntry>() ?? [];
}

/// <summary>Contains the properties that are available only from a Windows driver update.</summary>
/// <remarks>
/// None of the WindowsDriverUpdateEntry properties are expected to return any errors (other than E_POINTER if <c><see langword="null"/></c>
/// is passed to the property).
/// </remarks>
public class WindowsDriverUpdateEntry
{
	private readonly IWindowsDriverUpdateEntry entry;

	internal WindowsDriverUpdateEntry(IWindowsDriverUpdateEntry entry) => this.entry = entry;

	/// <summary>Gets the problem number of the matching device for the Windows driver update.</summary>
	public int DeviceProblemNumber => entry.DeviceProblemNumber;

	/// <summary>Gets the status of the matching device for the Windows driver update.</summary>
	public int DeviceStatus => entry.DeviceStatus;

	/// <summary>The <see cref="DriverClass"/> property retrieves the class of the Windows driver update.</summary>
	public string? DriverClass => entry.DriverClass;

	/// <summary>Gets the hardware or the compatible identifier that the Windows driver update must match to be installable.</summary>
	public string? DriverHardwareID => entry.DriverHardwareID;

	/// <summary>Gets the language-invariant name of the manufacturer of the Windows driver update.</summary>
	public string? DriverManufacturer => entry.DriverManufacturer;

	/// <summary>Gets the language-invariant model name of the device for which the Windows driver update is intended.</summary>
	public string? DriverModel => entry.DriverModel;

	/// <summary>Gets the language-invariant name of the provider of the Windows driver update.</summary>
	public string? DriverProvider => entry.DriverProvider;

	/// <summary>Gets the driver version date of the Windows driver update.</summary>
	public DateTime DriverVerDate => entry.DriverVerDate;
}

/// <summary>Retrieves information about the version of Windows Update Agent (WUA).</summary>
/// <remarks>
/// <para>
/// The <see cref="WindowsUpdateAgentInfo"/> class may require you to update WUA. For more information, see Updating Windows Update Agent.
/// </para>
/// <para>
/// You can create an instance of this object by using the WindowsUpdateAgentInfo class. Use the Microsoft.Update.AgentInfo program
/// identifier to create the object.
/// </para>
/// </remarks>
public class WindowsUpdateAgentInfo
{
	private readonly IWindowsUpdateAgentInfo wuai = new();

	/// <summary>Retrieves the current version of WUA.</summary>
	/// <remarks>
	/// The major version is incremented one time for each release if a change occurs in the interfaces of the WUA API. The minor version is
	/// incremented one time for each release if a change occurs in the existing interfaces of the WUA API.
	/// </remarks>
	public Version ApiVersion => new((int)wuai.GetInfo("ApiMajorVersion"), (int)wuai.GetInfo("ApiMinorVersion"));

	/// <summary>Retrieves the file version of the Wuapi.dll file.</summary>
	public Version ProductVersion => new((string)wuai.GetInfo("ProductVersionString"));
}

/// <summary>Extension methods for Windows Update classes.</summary>
public static class Ext
{
	/// <summary>Converts enumerated list of <see cref="Update"/> to and <see cref="UpdateCollection"/> instance.</summary>
	/// <param name="items">The items.</param>
	/// <returns>An <see cref="UpdateCollection"/> instance containing <paramref name="items"/>.</returns>
	public static UpdateCollection ToCollection(this IEnumerable<Update> items) => (items as UpdateCollection) ?? new(items);
}

internal static class IntExt
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IReadOnlyList<TOut> GetList<TIn, TOut>(this IEnumerable l) => l.Cast<TIn>().Select(e => (TOut)Activator.CreateInstance(typeof(TOut), e)!).ToList();
}

/// <summary>Restricts access to methods and properties of objects that implements the method of this object.</summary>
internal static class UpdateLockdown
{
	/// <summary>Restricts access to the methods and properties of the object that implements this method.</summary>
	/// <param name="lockdown">An object that supports IUpdateLockdown.</param>
	/// <param name="flags">
	/// <para>The option to restrict access to various Windows Update Agent (WUA) objects from the Windows Update website.</para>
	/// <para>
	/// Setting this parameter to <see cref="UpdateLockdownOption.uloForWebsiteAccess"/> or to 1 (one) restricts access to the WUA classes that implement the
	/// UpdateLockdown instance.
	/// </para>
	/// </param>
	public static void LockDown(object lockdown, [In] UpdateLockdownOption flags) => (lockdown as IUpdateLockdown ?? throw new NotImplementedException()).LockDown(flags);
}