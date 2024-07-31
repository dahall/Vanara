using System.ComponentModel;
using System.Security.AccessControl;
using System.Windows.Forms;
using Vanara.Security.AccessControl;
using static Vanara.PInvoke.AclUI;
using ResourceType = System.Security.AccessControl.ResourceType;

namespace Vanara.Windows.Forms;

/// <summary>Values that indicate the types of property pages in an access control editor property sheet.</summary>
public enum SecurityPageType : uint
{
	/// <summary>Permissions page.</summary>
	BasicPermissions = 0,

	/// <summary>Advanced page.</summary>
	AdvancedPermissions,

	/// <summary>Audit page.</summary>
	Audit,

	/// <summary>Owner page.</summary>
	Owner,

	/// <summary>Effective Rights page.</summary>
	EffectiveRights,

	/// <summary>Take Ownership page.</summary>
	TakeOwnership,

	/// <summary>Share page.</summary>
	Share
}

/// <summary>
/// Displays a property sheet that contains a basic security property page. This property page enables the user to view and edit the access rights allowed or
/// denied by the ACEs in an object's DACL.
/// </summary>
[ToolboxItem(true), ToolboxItemFilter("System.Windows.Forms.Control.TopLevel")]
[Designer("System.ComponentModel.Design.ComponentDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[DesignTimeVisible(true)]
[DefaultProperty("ObjectName"), Description("Displays a property sheet that contains a basic security property page.")]
[System.Drawing.ToolboxBitmap(typeof(AccessControlEditorDialog))]
public class AccessControlEditorDialog : CommonDialog
{
	/// <summary>Pseudo type cast for a Task specific ResourceType.</summary>
	public const ResourceType taskResourceType = (ResourceType)99;

	private static readonly SI_OBJECT_INFO_Flags defaultFlags = SI_OBJECT_INFO_Flags.SI_EDIT_ALL | SI_OBJECT_INFO_Flags.SI_ADVANCED | SI_OBJECT_INFO_Flags.SI_VIEW_ONLY;

	private SI_OBJECT_INFO_Flags flags = defaultFlags;
	private SecurityInfoImpl? iSecInfo;
	private string objectName = "", serverName = "";
	private string? title;

	/// <summary>Initializes a new instance of the <see cref="AccessControlEditorDialog"/> class.</summary>
	public AccessControlEditorDialog()
	{
		if (System.Threading.Thread.CurrentThread.GetApartmentState() != System.Threading.ApartmentState.STA)
			throw new InvalidOperationException("Current thread must be STA in order to use the AccessControlEditorDialog.");
	}

	/// <summary>
	/// When set, this flag displays the Reset permissions on all child objects and enable propagation of inheritable permissions check box in the
	/// Permissions page of the Access Control Settings window. This function does not reset the permissions and enable propagation of inheritable permissions.
	/// </summary>
	[DefaultValue(false), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Displays the Reset permissions on all child objects and enable propagation of inheritable permissions check box")]
	public bool AllowDaclInheritanceReset
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_RESET_DACL_TREE); set => SetFlag(SI_OBJECT_INFO_Flags.SI_RESET_DACL_TREE, value, true);
	}

	/// <summary>
	/// If this flag is set and the user clicks the Advanced button, the system displays an advanced security property sheet that includes an Auditing
	/// property page for editing the object's SACL.
	/// </summary>
	[DefaultValue(true), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("On Advanced button, shows Audit page.")]
	public bool AllowEditAudit
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_EDIT_AUDITS); set => SetFlag(SI_OBJECT_INFO_Flags.SI_EDIT_AUDITS, value, true);
	}

	/// <summary>
	/// If this flag is set and the user clicks the Advanced button, the system displays an advanced security property sheet that includes an Owner property
	/// page for changing the object's owner.
	/// </summary>
	[DefaultValue(true), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("On Advanced button, shows Owner page.")]
	public bool AllowEditOwner
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_EDIT_OWNER); set => SetFlag(SI_OBJECT_INFO_Flags.SI_EDIT_OWNER, value, true);
	}

	/// <summary>
	/// When set, this flag displays the Reset auditing entries on all child objects and enables propagation of the inheritable auditing entries check box in
	/// the Auditing page of the Access Control Settings window. This function does not reset the permissions and enable propagation of inheritable permissions.
	/// </summary>
	[DefaultValue(false), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Displays the Reset auditing entries on all child objects and enables propagation of the inheritable auditing entries check box.")]
	public bool AllowSaclInheritanceReset
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_RESET_SACL_TREE); set => SetFlag(SI_OBJECT_INFO_Flags.SI_RESET_SACL_TREE, value, true);
	}

	/// <summary>When set, this flag displays a shield on the Edit button of the advanced Auditing pages.</summary>
	[DefaultValue(false), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Displays a shield on the Edit button of the advanced Auditing pages.")]
	public bool AuditElevationRequired
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_AUDITS_ELEVATION_REQUIRED); set => SetFlag(SI_OBJECT_INFO_Flags.SI_AUDITS_ELEVATION_REQUIRED, value, true);
	}

	/// <summary>
	/// If this flag is set, the Title property value is used as the title of the basic security property page. Otherwise, a default title is used.
	/// </summary>
	[DefaultValue(false), Browsable(false), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Title property value is used as the title of the basic security property page.")]
	public bool CustomPageTitle
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_PAGE_TITLE); private set => SetFlag(SI_OBJECT_INFO_Flags.SI_PAGE_TITLE, value);
	}

	/// <summary>
	/// If this flag is set, the access control editor hides the check box that controls the NO_PROPAGATE_INHERIT_ACE flag. This flag is relevant only when
	/// the Advanced flag is also set.
	/// </summary>
	[DefaultValue(false), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Hides the check box that controls the NO_PROPAGATE_INHERIT_ACE flag")]
	public bool DisallowInheritance
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_NO_TREE_APPLY); set { SetFlag(SI_OBJECT_INFO_Flags.SI_NO_TREE_APPLY, value, true); if (value) ShowAdvancedButton = true; }
	}

	/// <summary>
	/// If this flag is set, the access control editor hides the check box that allows inheritable ACEs to propagate from the parent object to this object.
	/// If this flag is not set, the check box is visible. The check box is clear if the SE_DACL_PROTECTED flag is set in the object's security descriptor.
	/// In this case, the object's DACL is protected from being modified by inheritable ACEs. If the user clears the check box, any inherited ACEs in the
	/// security descriptor are deleted or converted to non-inherited ACEs. Before proceeding with this conversion, the system displays a warning message box
	/// to confirm the change.
	/// </summary>
	[DefaultValue(false), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Display of check box that allows inheritable ACEs to propagate from the parent object to this object.")]
	public bool DisallowProtectedAcls
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_NO_ACL_PROTECT); set => SetFlag(SI_OBJECT_INFO_Flags.SI_NO_ACL_PROTECT, value);
	}

	/// <summary>
	/// If this flag is set, the system enables controls for editing ACEs that apply to the object's property sets and properties. These controls are
	/// available only on the property sheet displayed when the user clicks the Advanced button.
	/// </summary>
	[DefaultValue(false), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Enables controls for editing ACEs that apply to the object's property sets and properties.")]
	public bool EditProperties
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_EDIT_PROPERTIES); set { SetFlag(SI_OBJECT_INFO_Flags.SI_EDIT_PROPERTIES, value, true); if (value) ShowAdvancedButton = true; }
	}

	/// <summary>When set, this flag displays a shield on the Edit button of the simple and advanced Permissions pages.</summary>
	[DefaultValue(false), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Displays a shield on the Edit button of the simple and advanced Permissions pages.")]
	public bool ElevationRequired
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_PERMS_ELEVATION_REQUIRED); set => SetFlag(SI_OBJECT_INFO_Flags.SI_PERMS_ELEVATION_REQUIRED, value, true);
	}

	/// <summary>Gets or sets the flags.</summary>
	/// <value>The flags.</value>
	[Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public SI_OBJECT_INFO_Flags Flags
	{
		get => flags; set { flags = value; if (iSecInfo != null) iSecInfo.objectInfo.dwFlags = value; }
	}

	/// <summary>If this flag is set, the access control editor hides the Special Permissions tab on the Advanced Security Settings page.</summary>
	[DefaultValue(false), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Hides the Special Permissions tab on the Advanced Security Settings page.")]
	public bool HideSpecialPermissionTab
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_NO_ADDITIONAL_PERMISSION); set => SetFlag(SI_OBJECT_INFO_Flags.SI_NO_ADDITIONAL_PERMISSION, value, true);
	}

	/// <summary>Indicates that the access control editor cannot read the DACL but might be able to write to the DACL.</summary>
	[DefaultValue(false), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Editor cannot read the DACL but might be able to write to the DACL.")]
	public bool MayWrite
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_MAY_WRITE); set => SetFlag(SI_OBJECT_INFO_Flags.SI_MAY_WRITE, value);
	}

	/// <summary>
	/// When set, indicates that the ObjectGuid property is valid. This is set in comparisons with object-specific ACEs in determining whether the ACE
	/// applies to the current object.
	/// </summary>
	[DefaultValue(false), Browsable(false), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Indicates that the ObjectGuid property is valid")]
	public bool ObjectGuid
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_OBJECT_GUID); private set => SetFlag(SI_OBJECT_INFO_Flags.SI_OBJECT_GUID, value);
	}

	/// <summary>
	/// Indicates that the object is a container. If this flag is set, the access control editor enables the controls relevant to the inheritance of
	/// permissions onto child objects.
	/// </summary>
	[DefaultValue(false), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Indicates that the object is a container.")]
	public bool ObjectIsContainer
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_CONTAINER); set => SetFlag(SI_OBJECT_INFO_Flags.SI_CONTAINER, value);
	}

	/// <summary>Gets or sets the name of the object. If the <see cref="Initialize(object)"/> method is used, it will overwrite this value. If not, then the control will attempt to get the security information for this object based on the type specified by <see cref="ResourceType"/>.</summary>
	[DefaultValue(null), Category("Data")]
	[Description("The full name of the object.")]
	public string ObjectName
	{
		get => objectName;
		set
		{
			objectName = value;
			if (iSecInfo != null)
				iSecInfo.objectInfo.pszObjectName = value;
		}
	}

	/// <summary>
	/// When set, this flag displays a shield on the Edit button of the advanced Owner page.
	/// </summary>
	[DefaultValue(false), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Displays a shield on the Edit button of the advanced Owner page.")]
	public bool OwnerElevationRequired
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_OWNER_ELEVATION_REQUIRED); set => SetFlag(SI_OBJECT_INFO_Flags.SI_OWNER_ELEVATION_REQUIRED, value, true);
	}

	/// <summary>
	/// If this flag is set, the user cannot change the owner of the object. Set this flag if EditOwner is set but the user does not have permission to
	/// change the owner.
	/// </summary>
	[DefaultValue(false), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("User cannot change the owner of the object.")]
	public bool OwnerReadOnly
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_OWNER_READONLY); set { var opt = value ? SI_OBJECT_INFO_Flags.SI_OWNER_READONLY | SI_OBJECT_INFO_Flags.SI_EDIT_OWNER : SI_OBJECT_INFO_Flags.SI_OWNER_READONLY; SetFlag(opt, value, true); }
	}

	/// <summary>
	/// Combine this flag with Container to display a check box on the owner page that indicates whether the user intends the new owner to be applied to all
	/// child objects as well as the current object. The access control editor does not perform the recursion.
	/// </summary>
	[DefaultValue(false), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Display a check box on the owner page that indicates whether the user intends the new owner to be applied to all child objects as well as the current object.")]
	public bool OwnerRecurse
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_OWNER_RECURSE); set => SetFlag(SI_OBJECT_INFO_Flags.SI_OWNER_RECURSE, value, true);
	}

	/// <summary>Gets or sets the type of the page to display.</summary>
	/// <value>The type of the page.</value>
	[DefaultValue(typeof(SecurityPageType), "BasicPermissions"), Category("Behavior")]
	[Description("The type of the page to display.")]
	public SecurityPageType PageType { get; set; } = SecurityPageType.BasicPermissions;

	/// <summary>
	/// If this flag is set, the editor displays the object's security information, but the controls for editing the information are disabled. This flag
	/// cannot be combined with the ViewOnly flag.
	/// </summary>
	[DefaultValue(false), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Disables controls for editing the information.")]
	public bool ReadOnly
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_READONLY); set { if (value) SetFlag(SI_OBJECT_INFO_Flags.SI_VIEW_ONLY, false); SetFlag(SI_OBJECT_INFO_Flags.SI_READONLY, value); }
	}

	/// <summary>Gets or sets the resource type of the object.  If the <see cref="Initialize(object)"/> method is used, it will overwrite this value. If not, then the control will attempt to get the security information for this object based on the type specified by <see cref="ObjectName"/>.</summary>
	/// <value>The type of the resource.</value>
	[DefaultValue(ResourceType.Unknown), Category("Data")]
	[Description("The resource type of the object.")]
	public ResourceType ResourceType { get; set; } = ResourceType.Unknown;

	/// <summary>Gets the resulting Security Descriptor.</summary>
	/// <value>The resulting Security Descriptor.</value>
	[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RawSecurityDescriptor? Result { get; private set; }

	/// <summary>Gets the resulting Security Descriptor in SDDL form.</summary>
	/// <value>The resulting Security Descriptor in SDDL form.</value>
	[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string? Sddl => Result?.GetSddlForm(AccessControlSections.All);

	/// <summary>
	/// Set this flag if the computer defined by the ServerName property is known to be a domain controller. If this flag is set, the domain name is included
	/// in the scope list of the Add Users and Groups dialog box. Otherwise, the pszServerName computer is used to determine the scope list of the dialog box.
	/// </summary>
	[DefaultValue(false), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Computer defined by the ServerName property is known to be a domain controller.")]
	public bool ServerIsDC
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_SERVER_IS_DC); set => SetFlag(SI_OBJECT_INFO_Flags.SI_SERVER_IS_DC, value);
	}

	/// <summary>Gets or sets the name of the server on which the object resides. A <c>null</c> value indicates the local machine.</summary>
	/// <value>The name of the server.</value>
	[DefaultValue(""), Category("Data")]
	[Description("Name of the server on which the object resides.")]
	public string ServerName
	{
		get => serverName; set { serverName = value; if (iSecInfo != null) iSecInfo.objectInfo.pszServerName = value; }
	}

	/// <summary>
	/// Determines if the Advanced button is displayed on the basic security property page. If the user clicks this button, the system displays an advanced
	/// security property sheet that enables advanced editing of the discretionary access control list (DACL) of the object.
	/// </summary>
	[DefaultValue(true), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Displays Advanced button on the basic security property page.")]
	public bool ShowAdvancedButton
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_ADVANCED); set { SetFlag(SI_OBJECT_INFO_Flags.SI_ADVANCED, value); if (value && PageType == SecurityPageType.BasicPermissions) SetFlag(SI_OBJECT_INFO_Flags.SI_VIEW_ONLY, true); }
	}

	/// <summary>When set, this flag displays the Reset Defaults button on the Auditing page.</summary>
	[DefaultValue(false), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Displays the Reset Defaults button on the Auditing page.")]
	public bool ShowAuditingResetButton
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_RESET_SACL); set => SetFlag(SI_OBJECT_INFO_Flags.SI_RESET_SACL, value, true);
	}

	/// <summary>
	/// If this flag is set, the Default button is displayed. If the user clicks this button, the access control editor calls the
	/// IAccessControlEditorDialogProvider.DefaultSecurity to retrieve an application-defined default security descriptor. The access control editor uses
	/// this security descriptor to reinitialize the property sheet, and the user is allowed to apply the change or cancel.
	/// </summary>
	[DefaultValue(false), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Displays the Default button.")]
	public bool ShowDefaultButton
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_RESET); set => SetFlag(SI_OBJECT_INFO_Flags.SI_RESET, value, true);
	}

	/// <summary>If this flag is set, the Effective Permissions page is displayed.</summary>
	[DefaultValue(false), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Displays the Effective Permissions page.")]
	public bool ShowEffectivePermissionsPage
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_EDIT_EFFECTIVE); set => SetFlag(SI_OBJECT_INFO_Flags.SI_EDIT_EFFECTIVE, value, true);
	}

	/// <summary>When set, this flag displays the Reset Defaults button on the Owner page.</summary>
	[DefaultValue(false), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Displays the Reset Defaults button on the Owner page.")]
	public bool ShowOwnerResetButton
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_RESET_OWNER); set => SetFlag(SI_OBJECT_INFO_Flags.SI_RESET_OWNER, value, true);
	}

	/// <summary>When set, this flag displays the Reset Defaults button on the Permissions page.</summary>
	[DefaultValue(false), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Displays the Reset Defaults button on the Permissions page.")]
	public bool ShowPermissionsResetButton
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_RESET_DACL); set => SetFlag(SI_OBJECT_INFO_Flags.SI_RESET_DACL, value, true);
	}

	/// <summary>Gets or sets the title of the property page tab. If this value is not set, a default will be used.</summary>
	/// <value>The title.</value>
	[DefaultValue(null), Category("Appearance")]
	[Description("Title of the property page tab.")]
	public string? TabTitle
	{
		get => title; set { title = value; if (iSecInfo != null) iSecInfo.objectInfo.pszPageTitle = value; CustomPageTitle = !string.IsNullOrEmpty(value); }
	}

	/// <summary>
	/// If this flag is set, the editor displays the object's security information, but the controls for editing the information are disabled. This flag
	/// cannot be combined with the EditOnly flag.
	/// </summary>
	[DefaultValue(true), Category("Behavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Displays the object's security information, but the controls for editing the information are disabled.")]
	public bool ViewOnly
	{
		get => HasFlag(SI_OBJECT_INFO_Flags.SI_VIEW_ONLY); set { if (value) SetFlag(SI_OBJECT_INFO_Flags.SI_READONLY, false); SetFlag(SI_OBJECT_INFO_Flags.SI_VIEW_ONLY, value); }
	}

	/// <summary>Initializes the dialog with the specified known object.</summary>
	/// <param name="knownObject">The known object. See Remarks section for acceptable object types.</param>
	/// <remarks>
	/// Known objects can include:
	/// <list type="bullet">
	///   <item><description>System.IO.Pipes.PipeStream</description></item>
	///   <item><description><see cref="System.Threading.EventWaitHandle"/></description></item>
	///   <item><description><see cref="System.IO.DirectoryInfo"/></description></item>
	///   <item><description><see cref="System.IO.FileInfo"/></description></item>
	///   <item><description><see cref="System.IO.FileStream"/></description></item>
	///   <item><description><see cref="System.Threading.Mutex"/></description></item>
	///   <item><description>System.Win32.RegistryKey</description></item>
	///   <item><description><see cref="System.Threading.Semaphore"/></description></item>
	///   <item><description>System.IO.MemoryMappedFiles.MemoryMappedFile</description></item>
	///   <item><description><see cref="CommonObjectSecurity"/> or derived class. <c>Note:</c> When using this option, be sure to 
	///   set the <see cref="ObjectIsContainer"/>, <see cref="ResourceType"/>, <see cref="ObjectName"/>, and <see cref="ServerName"/> properties.</description></item>
	///   <item><description>Any object that supports the following methods and properties:
	///     <list type="bullet"><item><description><code>GetAccessControl()</code> or <code>GetAccessControl(AccessControlSections)</code> method</description></item>
	///     <item><description><code>SetAccessControl(CommonObjectSecurity)</code> method</description></item>
	///     <item><description><code>Name</code> or <code>FullName</code> property</description></item>
	///     </list>
	///   </description></item>
	/// </list>
	/// </remarks>
	public void Initialize(object knownObject) => Initialize(new SecuredObject(knownObject));

	/// <summary>Initializes the dialog with the specified <see cref="CommonObjectSecurity"/> value and names.</summary>
	/// <param name="objSecurity">The object security.</param>
	/// <param name="objName">Name of the object.</param>
	/// <param name="displayName">The display name.</param>
	public void Initialize(CommonObjectSecurity objSecurity, string objName, string displayName) => Initialize(new SecuredObject(objSecurity, objName, displayName));

	private void Initialize(SecuredObject secObject)
	{
		Initialize(secObject.DisplayName, secObject.ObjectName, secObject.IsContainer, ProviderFromResourceType(secObject.ResourceType),
			secObject.ObjectSecurity.GetSecurityDescriptorBinaryForm(), secObject.TargetServer);
		ResourceType = secObject.ResourceType;
	}

	/// <summary>Initializes the dialog with the specified known object.</summary>
	/// <param name="fullObjectName">Full name of the object.</param>
	/// <param name="server">Name of the server. This value can be <c>null</c>.</param>
	/// <param name="resourceType">Type of the object resource.</param>
	/// <exception cref="ArgumentException">Unable to create an object from supplied arguments.</exception>
	public void Initialize(string fullObjectName, string? server, ResourceType resourceType) => Initialize(SecuredObject.GetKnownObject(resourceType, fullObjectName, server));

	/// <summary>Initializes the dialog with a custom provider.</summary>
	/// <param name="displayName">The object name.</param>
	/// <param name="fullObjectName">Full name of the object.</param>
	/// <param name="isContainer">Set to <c>true</c> if object is a container.</param>
	/// <param name="customProvider">The custom provider.</param>
	/// <param name="sd">The binary Security Descriptor.</param>
	/// <param name="targetServer">The target server.</param>
	public void Initialize(string displayName, string fullObjectName, bool isContainer, IAccessControlEditorDialogProvider customProvider, byte[]? sd = null, string? targetServer = null)
	{
		if (isContainer)
			ObjectIsContainer = true;
		iSecInfo = new SecurityInfoImpl(flags, displayName, fullObjectName, targetServer);
		ResourceType = ResourceType.Unknown;
		if (sd != null)
		{
			Result = new RawSecurityDescriptor(sd, 0);
			iSecInfo.SecurityDescriptor = new(sd);
		}
		else
		{
			Result = new RawSecurityDescriptor("");
			iSecInfo.SecurityDescriptor = new(20);
		}
		iSecInfo.SetProvider(customProvider);
	}

	/// <summary>Initializes the dialog with a known resource type.</summary>
	/// <param name="displayName">The display name.</param>
	/// <param name="fullName">The full name.</param>
	/// <param name="isContainer">if set to <c>true</c> [is container].</param>
	/// <param name="resourceType">Type of the resource.</param>
	/// <param name="sd">The raw security descriptor.</param>
	/// <param name="targetServer">The target server.</param>
	public void Initialize(string displayName, string fullName, bool isContainer, ResourceType resourceType, byte[] sd, string? targetServer = null)
	{
		Initialize(displayName, fullName, isContainer, ProviderFromResourceType(resourceType), sd, targetServer);
		ResourceType = resourceType;
	}

	/// <summary>When overridden in a derived class, resets the properties of a common dialog box to their default values.</summary>
	/// <exception cref="InvalidOperationException">
	/// AccessControlEditorDialog cannot be reset. It must be instantiated with a valid securable object.
	/// </exception>
	public override void Reset() => throw new InvalidOperationException("AccessControlEditorDialog cannot be reset. It must be instantiated with a valid securable object.");

	internal void ResetFlags() => flags = defaultFlags;

	internal bool ShouldSerializeFlags() => flags != defaultFlags;

	/// <summary>Runs the dialog.</summary>
	/// <param name="hWndOwner">The h WND owner.</param>
	/// <returns></returns>
	/// <exception cref="InvalidOperationException">The Initialize method must be called before the dialog can be shown.</exception>
	protected override bool RunDialog(IntPtr hWndOwner)
	{
		if (iSecInfo == null && !string.IsNullOrEmpty(ObjectName) && ResourceType != ResourceType.Unknown)
			Initialize(ObjectName, string.IsNullOrEmpty(ServerName) ? Environment.MachineName : ServerName, ResourceType);

		if (iSecInfo == null)
			throw new InvalidOperationException("The Initialize method must be called before the dialog can be shown.");

		var ret = iSecInfo.ShowDialog(hWndOwner, (SI_PAGE_TYPE)(uint)PageType);
		if (ret != null) Result = ret;
		return ret != null;
	}

	private bool HasFlag(SI_OBJECT_INFO_Flags flag) => (Flags & flag) == flag;

	private static GenericProvider ProviderFromResourceType(ResourceType resType) => resType switch
	{
		ResourceType.FileObject => new FileProvider(),
		ResourceType.KernelObject => new KernelProvider(),
		ResourceType.RegistryKey => new RegistryProvider(),
		taskResourceType => new TaskProvider(),
		_ => new GenericProvider(),
	};

	private void SetFlag(SI_OBJECT_INFO_Flags flag, bool set, bool reqAdvanced = false)
	{
		if (set)
		{
			if (reqAdvanced)
				flag |= SI_OBJECT_INFO_Flags.SI_ADVANCED;
			Flags |= flag;
		}
		else
			Flags &= ~flag;
	}
}