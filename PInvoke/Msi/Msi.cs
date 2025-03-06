namespace Vanara.PInvoke;

/// <summary>Items from the Msi.dll</summary>
public static partial class Msi
{
	private const string Lib_Msi = "msi.dll";

	/// <summary>To advertise the product locally to the computer.</summary>
	[PInvokeData("msi.h")]
	[Flags]
	public enum ADVERTISEFLAGS
	{
		/// <summary>Set to advertise a per-machine installation of the product available to all users.</summary>
		ADVERTISEFLAGS_MACHINEASSIGN = 0,   // set if the product is to be machine assigned

		/// <summary>Set to advertise a per-user installation of the product available to a particular user.</summary>
		ADVERTISEFLAGS_USERASSIGN = 1,   // set if the product is to be user assigned
	}

	/// <summary>Feature attributes specified at run time.</summary>
	[PInvokeData("msi.h")]
	[Flags]
	public enum INSTALLFEATUREATTRIBUTE // bit flags
	{
		/// <summary>
		/// Modifies default feature attributes to msidbFeatureAttributesFavorLocal at run time. See Attributes column of the Feature
		/// table for a description.
		/// </summary>
		INSTALLFEATUREATTRIBUTE_FAVORLOCAL = 1,

		/// <summary>
		/// Modifies default feature attributes to msidbFeatureAttributesFavorSource at run time. See Attributes column of the Feature
		/// table for a description.
		/// </summary>
		INSTALLFEATUREATTRIBUTE_FAVORSOURCE = 2,

		/// <summary>
		/// Modifies default feature attributes to msidbFeatureAttributesFollowParent at run time. Note that this is not a valid
		/// attribute to be set for top-level features. See Attributes column of the Feature table for a description.
		/// </summary>
		INSTALLFEATUREATTRIBUTE_FOLLOWPARENT = 4,

		/// <summary>
		/// Modifies default feature attributes to msidbFeatureAttributesFavorAdvertise at run time. See Attributes column of the
		/// Feature table for a description.
		/// </summary>
		INSTALLFEATUREATTRIBUTE_FAVORADVERTISE = 8,

		/// <summary>
		/// Modifies default feature attributes to msidbFeatureAttributesDisallowAdvertise at run time. See Attributes column of the
		/// Feature table for a description.
		/// </summary>
		INSTALLFEATUREATTRIBUTE_DISALLOWADVERTISE = 16,

		/// <summary>
		/// Modifies default feature attributes to msidbFeatureAttributesNoUnsupportedAdvertise at run time. See Attributes column of
		/// the Feature table for a description.
		/// </summary>
		INSTALLFEATUREATTRIBUTE_NOUNSUPPORTEDADVERTISE = 32,
	}

	/// <summary>Specifies how much of the product should be installed when installing the product to its default state.</summary>
	[PInvokeData("msi.h")]
	public enum INSTALLLEVEL
	{
		/// <summary>The authored default features are installed.</summary>
		INSTALLLEVEL_DEFAULT = 0,      // install authored default

		/// <summary>
		/// Only the required features are installed. You can specify a value between INSTALLLEVEL_MINIMUM and INSTALLLEVEL_MAXIMUM to
		/// install a subset of available features.
		/// </summary>
		INSTALLLEVEL_MINIMUM = 1,      // install only required features

		/// <summary>
		/// All features are installed. You can specify a value between INSTALLLEVEL_MINIMUM and INSTALLLEVEL_MAXIMUM to install a
		/// subset of available features.
		/// </summary>
		INSTALLLEVEL_MAXIMUM = 0xFFFF, // install all features
	}

	/// <summary>Specifies how frequently the log buffer is to be flushed.</summary>
	[PInvokeData("msi.h")]
	[Flags]
	public enum INSTALLLOGATTRIBUTES // flag attributes for MsiEnableLog
	{
		/// <summary>
		/// If this value is set, the installer appends the existing log specified by szLogFile. If not set, any existing log specified
		/// by szLogFile is overwritten.
		/// </summary>
		INSTALLLOGATTRIBUTES_APPEND = 1 << 0,

		/// <summary>
		/// Forces the log buffer to be flushed after each line. If this value is not set, the installer flushes the log buffer after 20
		/// lines by calling FlushFileBuffers.
		/// </summary>
		INSTALLLOGATTRIBUTES_FLUSHEACHLINE = 1 << 1,
	}

	/// <summary>Specifies the log mode.</summary>
	[PInvokeData("msi.h")]
	[Flags]
	public enum INSTALLLOGMODE : uint  // bit flags for use with MsiEnableLog and MsiSetExternalUI
	{
		/// <summary>Logs out of memory or fatal exit information.</summary>
		INSTALLLOGMODE_FATALEXIT = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_FATALEXIT >> 24),

		/// <summary>Logs the error messages.</summary>
		INSTALLLOGMODE_ERROR = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_ERROR >> 24),

		/// <summary>Logs the warning messages.</summary>
		INSTALLLOGMODE_WARNING = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_WARNING >> 24),

		/// <summary>Logs the user requests.</summary>
		INSTALLLOGMODE_USER = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_USER >> 24),

		/// <summary>Logs the status messages that are not displayed.</summary>
		INSTALLLOGMODE_INFO = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_INFO >> 24),

		/// <summary>Request to determine a valid source location.</summary>
		INSTALLLOGMODE_RESOLVESOURCE = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_RESOLVESOURCE >> 24),

		/// <summary>Indicates insufficient disk space.</summary>
		INSTALLLOGMODE_OUTOFDISKSPACE = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_OUTOFDISKSPACE >> 24),

		/// <summary>Logs the start of new installation actions.</summary>
		INSTALLLOGMODE_ACTIONSTART = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_ACTIONSTART >> 24),

		/// <summary>Logs the data record with the installation action.</summary>
		INSTALLLOGMODE_ACTIONDATA = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_ACTIONDATA >> 24),

		/// <summary>Logs the parameters for user-interface initialization.</summary>
		INSTALLLOGMODE_COMMONDATA = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_COMMONDATA >> 24),

		/// <summary>Logs the property values at termination.</summary>
		INSTALLLOGMODE_PROPERTYDUMP = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_PROGRESS >> 24), // log only

		/// <summary>
		/// Logs the information in all the other log modes, except for INSTALLLOGMODE_EXTRADEBUG. This sends large amounts of
		/// information to a log file not generally useful to users. May be used for technical support.
		/// </summary>
		INSTALLLOGMODE_VERBOSE = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_INITIALIZE >> 24), // log only

		/// <summary>
		/// Sends extra debugging information, such as handle creation information, to the log file. Windows 2000 and Windows XP: This
		/// feature is not supported.
		/// </summary>
		INSTALLLOGMODE_EXTRADEBUG = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_TERMINATE >> 24), // log only

		/// <summary>
		/// Logging information is collected but is is less frequently saved to the log file. This can improve the performance of some
		/// installations, but may have little benefit for large installations. The log file is removed when the installation succeeds.
		/// If the installation fails, all logging information is saved to the log file. Windows Installer 2.0: This log mode is not available.
		/// </summary>
		INSTALLLOGMODE_LOGONLYONERROR = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_SHOWDIALOG >> 24), // log only

		/// <summary></summary>
		INSTALLLOGMODE_LOGPERFORMANCE = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_PERFORMANCE >> 24), // log only

		/// <summary>
		/// Progress bar information. This message includes information on units so far and total number of units. For an explanation of
		/// the message format, see the MsiProcessMessage function. This message is only sent to an external user interface and is not logged.
		/// </summary>
		INSTALLLOGMODE_PROGRESS = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_PROGRESS >> 24), // external handler only

		/// <summary>
		/// If this is not a quiet installation, then the basic UI has been initialized. If this is a full UI installation, the full UI
		/// is not yet initialized. This message is only sent to an external user interface and is not logged.
		/// </summary>
		INSTALLLOGMODE_INITIALIZE = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_INITIALIZE >> 24), // external handler only

		/// <summary>
		/// If a full UI is being used, the full UI has ended. If this is not a quiet installation, the basic UI has not yet ended. This
		/// message is only sent to an external user interface and is not logged.
		/// </summary>
		INSTALLLOGMODE_TERMINATE = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_TERMINATE >> 24), // external handler only

		/// <summary>
		/// Sent prior to display of the full UI dialog. This message is only sent to an external user interface and is not logged.
		/// </summary>
		INSTALLLOGMODE_SHOWDIALOG = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_SHOWDIALOG >> 24), // external handler only

		/// <summary>Files in use information. When this message is received, a FilesInUse Dialog should be displayed.</summary>
		INSTALLLOGMODE_FILESINUSE = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_FILESINUSE >> 24), // external handler only

		/// <summary>Files in use information. When this message is received, a MsiRMFilesInUse Dialog should be displayed.</summary>
		INSTALLLOGMODE_RMFILESINUSE = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_RMFILESINUSE >> 24), // external handler only

		/// <summary>Installation of product begins. The message contains the product's ProductName and ProductCode.</summary>
		INSTALLLOGMODE_INSTALLSTART = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_INSTALLSTART >> 24), // external/embedded only

		/// <summary>Installation of product ends. The message contains the product's ProductName, ProductCode, and return value.</summary>
		INSTALLLOGMODE_INSTALLEND = 1 << (INSTALLMESSAGE.INSTALLMESSAGE_INSTALLEND >> 24), // external/embedded only
	}

	/// <summary>Defines the installation mode.</summary>
	[PInvokeData("msi.h")]
	public enum INSTALLMODE
	{
		/// <summary>
		/// Provide the component if a feature exists from any installed product. Otherwise return ERROR_FILE_NOT_FOUND. This mode only
		/// checks that the component is registered and does not verify that the key file of the component exists. This flag is similar
		/// to the INSTALLMODE_NODETECTION flag except that with this flag we check for any product that has installed the assembly as
		/// opposed to the last product as is the case with the INSTALLMODE_NODETECTION flag. This flag can only be used with MsiProvideAssembly.
		/// </summary>
		INSTALLMODE_NODETECTION_ANY = -4,  // provide any, if available, supported internally for MsiProvideAssembly

		/// <summary>
		/// Provide the component only if the feature's installation state is INSTALLSTATE_LOCAL. If the feature installation state is
		/// INSTALLSTATE_SOURCE, return ERROR_INSTALL_SOURCE_ABSENT. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that
		/// the component is registered and does not verify that the key file exists.
		/// </summary>
		INSTALLMODE_NOSOURCERESOLUTION = -3,  // skip source resolution

		/// <summary>
		/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that the
		/// component is registered and does not verify that the key file of the component exists.
		/// </summary>
		INSTALLMODE_NODETECTION = -2,  // skip detection

		/// <summary>
		/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode verifies that the key
		/// file of the component exists.
		/// </summary>
		INSTALLMODE_EXISTING = -1,  // provide, if available

		/// <summary>
		/// Provide the component and perform any installation necessary to provide the component. If the key file of a component in the
		/// requested feature, or a feature parent, is missing, reinstall the feature using MsiReinstallFeature with the following flag
		/// bits set: REINSTALLMODE_FILEMISSING, REINSTALLMODE_FILEOLDERVERSION, REINSTALLMODE_FILEVERIFY, REINSTALLMODE_MACHINEDATA,
		/// REINSTALLMODE_USERDATA and REINSTALLMODE_SHORTCUT.
		/// </summary>
		INSTALLMODE_DEFAULT = 0,  // install, if absent
	}

	/// <summary>Specifies the installation state.</summary>
	[PInvokeData("msi.h")]
	public enum INSTALLSTATE
	{
		/// <summary>The component being requested is disabled on the computer.</summary>
		INSTALLSTATE_NOTUSED = -7,  // component disabled

		/// <summary>The configuration data is corrupt.</summary>
		INSTALLSTATE_BADCONFIG = -6,  // configuration data corrupt

		/// <summary>The installation is suspended or in progress.</summary>
		INSTALLSTATE_INCOMPLETE = -5,  // installation suspended or in progress

		/// <summary>The component source is inaccessible.</summary>
		INSTALLSTATE_SOURCEABSENT = -4,  // run from source, source is unavailable

		/// <summary>The buffer provided was too small.</summary>
		INSTALLSTATE_MOREDATA = -3,  // return buffer overflow

		/// <summary>One of the function parameters is invalid.</summary>
		INSTALLSTATE_INVALIDARG = -2,  // invalid function argument

		/// <summary>The product code or component ID is unknown. See Remarks.</summary>
		INSTALLSTATE_UNKNOWN = -1,  // unrecognized product or feature

		/// <summary>The feature is broken.</summary>
		INSTALLSTATE_BROKEN = 0,  // broken

		/// <summary>The product is advertised.</summary>
		INSTALLSTATE_ADVERTISED = 1,  // advertised feature

		/// <summary>The component is being removed. In action state and not settable.</summary>
		INSTALLSTATE_REMOVED = 1,  // component being removed (action state, not settable)

		/// <summary>The product is uninstalled.</summary>
		INSTALLSTATE_ABSENT = 2,  // uninstalled (or action state absent but clients remain)

		/// <summary>The product is to be installed with all features installed locally.</summary>
		INSTALLSTATE_LOCAL = 3,  // installed on local drive

		/// <summary>The product is to be installed with all features installed to run from source.</summary>
		INSTALLSTATE_SOURCE = 4,  // run from source, CD or net

		/// <summary>The product is to be installed with all features installed to the default states specified in the Feature Table.</summary>
		INSTALLSTATE_DEFAULT = 5,  // use default, local or source
	}

	/// <summary>Specifies the type of installation to patch.</summary>
	[PInvokeData("msi.h")]
	public enum INSTALLTYPE
	{
		/// <summary>Searches system for products to patch. In this case, szInstallPackage must be 0.</summary>
		INSTALLTYPE_DEFAULT = 0,   // set to indicate default behavior

		/// <summary>
		/// Specifies an administrative installation. In this case, szInstallPackage must be set to a package path. A value of 1 for
		/// INSTALLTYPE_NETWORK_IMAGE sets this for an administrative installation.
		/// </summary>
		INSTALLTYPE_NETWORK_IMAGE = 1,   // set to indicate network install

		/// <summary>
		/// Patch the product specified by szInstallPackage. szInstallPackage is the product code of the instance to patch. This type of
		/// installation requires the installer running Windows Server 2003 or Windows XP with SP1. For more information see, Installing
		/// Multiple Instances of Products and Patches.
		/// </summary>
		INSTALLTYPE_SINGLE_INSTANCE = 2,   // set to indicate a particular instance
	}

	/// <summary>Specifies the level of complexity of the user interface.</summary>
	[PInvokeData("msi.h")]
	public enum INSTALLUILEVEL
	{
		/// <summary>No change in the UI level. However, if phWnd is not Null, the parent window can change.</summary>
		INSTALLUILEVEL_NOCHANGE = 0,    // UI level is unchanged

		/// <summary>The installer chooses an appropriate user interface level.</summary>
		INSTALLUILEVEL_DEFAULT = 1,    // default UI is used

		/// <summary>Completely silent installation.</summary>
		INSTALLUILEVEL_NONE = 2,    // completely silent installation

		/// <summary>Simple progress and error handling.</summary>
		INSTALLUILEVEL_BASIC = 3,    // simple progress and error handling

		/// <summary>Authored user interface with wizard dialog boxes suppressed.</summary>
		INSTALLUILEVEL_REDUCED = 4,    // authored UI, wizard dialogs suppressed

		/// <summary>Authored user interface with wizards, progress, and errors.</summary>
		INSTALLUILEVEL_FULL = 5,    // authored UI with wizards, progress, errors

		/// <summary>
		/// If combined with any above value, the installer displays a modal dialog box at the end of a successful installation or if
		/// there has been an error. No dialog box is displayed if the user cancels.
		/// </summary>
		INSTALLUILEVEL_ENDDIALOG = 0x80, // display success/failure dialog at end of install

		/// <summary>
		/// If combined with the INSTALLUILEVEL_BASIC value, the installer shows simple progress dialog boxes but does not display any
		/// modal dialog boxes or error dialog boxes.
		/// </summary>
		INSTALLUILEVEL_PROGRESSONLY = 0x40, // display only progress dialog

		/// <summary>
		/// If combined with the INSTALLUILEVEL_BASIC value, the installer shows simple progress dialog boxes but does not display a
		/// Cancel button on the dialog. This prevents users from canceling the install.
		/// </summary>
		INSTALLUILEVEL_HIDECANCEL = 0x20, // do not display the cancel button in basic UI

		/// <summary>
		/// If this value is combined with the INSTALLUILEVEL_NONE value, the installer displays only the dialog boxes used for source
		/// resolution. No other dialog boxes are shown. This value has no effect if the UI level is not INSTALLUILEVEL_NONE. It is used
		/// with an external user interface designed to handle all of the UI except for source resolution. In this case, the installer
		/// handles source resolution.
		/// </summary>
		INSTALLUILEVEL_SOURCERESONLY = 0x100, // force display of source resolution even if quiet

		/// <summary>Show UAC prompt even if quiet.</summary>
		INSTALLUILEVEL_UACONLY = 0x200, // show UAC prompt even if quiet
	}

	/// <summary>Bit flags that specify extra advertisement options.</summary>
	[PInvokeData("msi.h")]
	[Flags]
	public enum MSIADVERTISEOPTIONFLAGS
	{
		/// <summary>
		/// Multiple instances through product code changing transform support flag. Advertises a new instance of the product. Requires
		/// that the szTransforms parameter includes the instance transform that changes the product code. For more information, see
		/// Installing Multiple Instances of Products and Patches.
		/// </summary>
		MSIADVERTISEOPTIONFLAGS_INSTANCE = 0x00000001, // set if advertising a new instance
	}

	/// <summary>Bit flags that control for which platform the installer should create the script.</summary>
	[PInvokeData("msi.h")]
	[Flags]
	public enum MSIARCHITECTUREFLAGS
	{
		/// <summary>Creates a script for the x86 platform.</summary>
		MSIARCHITECTUREFLAGS_X86 = 0x00000001, // set if creating the script for i386 platform

		/// <summary>Creates a script for Itanium-based systems.</summary>
		MSIARCHITECTUREFLAGS_IA64 = 0x00000002, // set if creating the script for IA64 platform

		/// <summary>Creates a script for the x64 platform.</summary>
		MSIARCHITECTUREFLAGS_AMD64 = 0x00000004, // set if creating the script for AMD64 platform

		/// <summary>Creates a script for the ARM platform.</summary>
		MSIARCHITECTUREFLAGS_ARM = 0x00000008 //set if creating the script for ARM platform
	}

	/// <summary>Assembly information and assembly type.</summary>
	[PInvokeData("msi.h")]
	public enum MSIASSEMBLYINFO : uint
	{
		/// <summary>.NET Assembly</summary>
		MSIASSEMBLYINFO_NETASSEMBLY = 0,

		/// <summary>Win32 Assembly</summary>
		MSIASSEMBLYINFO_WIN32ASSEMBLY = 1,
	}

	/// <summary>The dwOptions value specifies the meaning of szProductCodeOrPatchCode.</summary>
	[PInvokeData("msi.h")]
	[Flags]
	public enum MSICODE
	{
		/// <summary>szProductCodeOrPatchCode is a product code GUID.</summary>
		MSICODE_PRODUCT = 0x00000000, // product code provided

		/// <summary>szProductCodeOrPatchCode is a patch code GUID.</summary>
		MSICODE_PATCH = 0x40000000  // patch code provided
	}

	/// <summary>Flags used by <c>MsiEnumProductsEx</c>.</summary>
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumProductsExA")]
	[Flags]
	public enum MSIINSTALLCONTEXT : uint
	{
		/// <summary>
		/// Enumeration extended to all per–user–managed installations for the users specified by szUserSid. An invalid SID returns no items.
		/// </summary>
		MSIINSTALLCONTEXT_USERMANAGED = 1,

		/// <summary>
		/// Enumeration extended to all per–user–unmanaged installations for the users specified by szUserSid. An invalid SID returns no items.
		/// </summary>
		MSIINSTALLCONTEXT_USERUNMANAGED = 2,

		/// <summary>
		/// Enumeration extended to all per-machine installations. When dwInstallContext is set to MSIINSTALLCONTEXT_MACHINE only, the
		/// szUserSID parameter must be NULL.
		/// </summary>
		MSIINSTALLCONTEXT_MACHINE = 4,

		/// <summary>All contexts. OR of all valid values</summary>
		MSIINSTALLCONTEXT_ALL = MSIINSTALLCONTEXT_USERMANAGED | MSIINSTALLCONTEXT_USERUNMANAGED | MSIINSTALLCONTEXT_MACHINE,

		/// <summary>All user-managed contexts.</summary>
		MSIINSTALLCONTEXT_ALLUSERMANAGED = 8,
	}

	/// <summary>The bit flags to indicate whether or not to ignore the computer state.</summary>
	[PInvokeData("msi.h")]
	[Flags]
	public enum MSIOPENPACKAGEFLAGS
	{
		/// <summary>Ignore the computer state when creating the product handle.</summary>
		MSIOPENPACKAGEFLAGS_IGNOREMACHINESTATE = 0x00000001, // ignore the machine state when creating the engine
	}

	/// <summary>Qualifies <c>szPatchData</c> as a patch file, an XML blob, or an XML file.</summary>
	[PInvokeData("msi.h", MSDNShortId = "NS:msi.tagMSIPATCHSEQUENCEINFOA")]
	public enum MSIPATCHDATATYPE
	{
		/// <summary>The szPatchData member refers to a path of a patch file.</summary>
		MSIPATCH_DATATYPE_PATCHFILE = 0,

		/// <summary>The szPatchData member refers to a path of a XML file.</summary>
		MSIPATCH_DATATYPE_XMLPATH = 1,

		/// <summary>The szPatchData member refers to a path of a XML file.</summary>
		MSIPATCH_DATATYPE_XMLBLOB = 2,
	}

	/// <summary>The filter for enumeration.</summary>
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiEnumPatchesExA")]
	[Flags]
	public enum MSIPATCHSTATE : uint
	{
		/// <summary>
		/// The enumeration includes patches that have been applied. Enumeration does not include superseded or obsolete patches.
		/// </summary>
		MSIPATCHSTATE_APPLIED = 1,

		/// <summary>The enumeration includes patches that are marked as superseded.</summary>
		MSIPATCHSTATE_SUPERSEDED = 2,

		/// <summary>The enumeration includes patches that are marked as obsolete.</summary>
		MSIPATCHSTATE_OBSOLETED = 4,

		/// <summary>
		/// The enumeration includes patches that are registered but not yet applied. The MsiSourceListAddSourceEx function can register
		/// new patches.
		/// <para>
		/// Note: Patches registered for users other than current user and applied in the per-user-unmanaged context are not enumerated.
		/// </para>
		/// </summary>
		MSIPATCHSTATE_REGISTERED = 8,

		/// <summary>The enumeration includes all applied, obsolete, superseded, and registered patches.</summary>
		MSIPATCHSTATE_ALL = 15,
	}

	/// <summary>Special error case flags.</summary>
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetFileSignatureInformationW")]
	[Flags]
	public enum MSISIGINFO : uint
	{
		/// <term>
		/// Without this flag set, and when requesting only the certificate context, an invalid hash in the digital signature does not
		/// cause MsiGetFileSignatureInformation to return a fatal error. To return a fatal error for an invalid hash, set the
		/// MSI_INVALID_HASH_IS_FATAL flag.
		/// </term>
		MSI_INVALID_HASH_IS_FATAL = 0x1
	}

	/// <summary>The type of sources to clear</summary>
	[PInvokeData("msi.h")]
	[Flags]
	public enum MSISOURCETYPE
	{
		/// <summary>The source is unknown.</summary>
		MSISOURCETYPE_UNKNOWN = 0x00000000,

		/// <summary>The source is a network type.</summary>
		MSISOURCETYPE_NETWORK = 0x00000001, // network source

		/// <summary>The source is a URL type.</summary>
		MSISOURCETYPE_URL = 0x00000002, // URL source

		/// <summary>The source is media.</summary>
		MSISOURCETYPE_MEDIA = 0x00000004  // media source
	}

	/// <summary>Attributes of the multiple-package installation.</summary>
	[PInvokeData("msi.h")]
	[Flags]
	public enum MSITRANSACTION
	{
		/// <summary>
		/// Set this attribute to request that the Windows Installer not shutdown the embedded UI until the transaction is complete.
		/// </summary>
		MSITRANSACTION_CHAIN_EMBEDDEDUI = 0x00000001,

		/// <summary>
		/// Set this attribute to request that the Windows Installer transfer the embedded UI from the original installation. If the
		/// original installation has no embedded UI, setting this attribute does nothing.
		/// </summary>
		MSITRANSACTION_JOIN_EXISTING_EMBEDDEDUI = 0x00000002,
	}

	/// <summary>
	/// The value of this parameter determines whether the installer commits or rolls back all the installations belonging to the transaction.
	/// </summary>
	[PInvokeData("msi.h")]
	public enum MSITRANSACTIONSTATE
	{
		/// <summary>
		/// Performs a Rollback Installation to undo changes to the system belonging to the transaction opened by the
		/// MsiBeginTransaction function.
		/// </summary>
		MSITRANSACTIONSTATE_ROLLBACK = 0x00000000,

		/// <summary>
		/// Commits all changes to the system belonging to the transaction. Runs any Commit Custom Actions and commits to the system any
		/// changes to Win32 or common language runtime assemblies. Deletes the rollback script, and after using this option, the
		/// transaction's changes can no longer be undone with a Rollback Installation.
		/// </summary>
		MSITRANSACTIONSTATE_COMMIT = 0x00000001,
	}

	/// <summary>Specifies what to install.</summary>
	[PInvokeData("msi.h")]
	[Flags]
	public enum REINSTALLMODE  // bit flags
	{
		/// <summary>Reserved.</summary>
		REINSTALLMODE_REPAIR = 0x00000001,  // Reserved bit - currently ignored

		/// <summary>Reinstall only if the file is missing.</summary>
		REINSTALLMODE_FILEMISSING = 0x00000002,  // Reinstall only if file is missing

		/// <summary>Reinstall if the file is missing or is an older version.</summary>
		REINSTALLMODE_FILEOLDERVERSION = 0x00000004,  // Reinstall if file is missing, or older version

		/// <summary>Reinstall if the file is missing, or is an equal or older version.</summary>
		REINSTALLMODE_FILEEQUALVERSION = 0x00000008,  // Reinstall if file is missing, or equal or older version

		/// <summary>Reinstall if the file is missing or is a different version.</summary>
		REINSTALLMODE_FILEEXACT = 0x00000010,  // Reinstall if file is missing, or not exact version

		/// <summary>
		/// Verify the checksum values, and reinstall the file if they are missing or corrupt. This flag only repairs files that have
		/// msidbFileAttributesChecksum in the Attributes column of the File table.
		/// </summary>
		REINSTALLMODE_FILEVERIFY = 0x00000020,  // checksum executables, reinstall if missing or corrupt

		/// <summary>Force all files to be reinstalled, regardless of checksum or version.</summary>
		REINSTALLMODE_FILEREPLACE = 0x00000040,  // Reinstall all files, regardless of version

		/// <summary>
		/// Rewrite all required registry entries from the Registry Table that go to the HKEY_LOCAL_MACHINEor HKEY_CLASSES_ROOT registry
		/// hive. Rewrite all information from the Class Table, Verb Table, PublishComponent Table, ProgID Table, MIME Table, Icon
		/// Table, Extension Table, and AppID Table regardless of machine or user assignment. Reinstall all qualified components. When
		/// reinstalling an application, this option runs the RegisterTypeLibraries and InstallODBC actions.
		/// </summary>
		REINSTALLMODE_MACHINEDATA = 0x00000080,  // insure required machine reg entries

		/// <summary>
		/// Rewrite all required registry entries from the Registry Table that go to theHKEY_CURRENT_USER or HKEY_USERS registry hive.
		/// </summary>
		REINSTALLMODE_USERDATA = 0x00000100,  // insure required user reg entries

		/// <summary>Reinstall all shortcuts and re-cache all icons overwriting any existing shortcuts and icons.</summary>
		REINSTALLMODE_SHORTCUT = 0x00000200,  // validate shortcuts items

		/// <summary>
		/// Use to run from the source package and re-cache the local package. Do not use for the first installation of an application
		/// or feature.
		/// </summary>
		REINSTALLMODE_PACKAGE = 0x00000400,  // use re-cache source install package
	}

	/// <summary>Bit flags that control advertisement.</summary>
	[PInvokeData("msi.h")]
	[Flags]
	public enum SCRIPTFLAGS
	{
		/// <summary>Include this flag if the icons need to be created or removed.</summary>
		SCRIPTFLAGS_CACHEINFO = 0x00000001,   // set if the icons need to be created/ removed

		/// <summary>Include this flag if the shortcuts need to be created or removed.</summary>
		SCRIPTFLAGS_SHORTCUTS = 0x00000004,   // set if the shortcuts needs to be created/ deleted

		/// <summary>Include this flag if the product to be assigned to a computer.</summary>
		SCRIPTFLAGS_MACHINEASSIGN = 0x00000008,   // set if product to be assigned to machine

		/// <summary>
		/// Include this flag if the configuration and management information in the registry data needs to be written or removed.
		/// </summary>
		SCRIPTFLAGS_REGDATA_CNFGINFO = 0x00000020,   // set if the product cnfg mgmt. registry data needs to be written/ removed

		/// <summary>
		/// Include this flag to force validation of the transforms listed in the script against previously registered transforms for
		/// this product. Note that transform conflicts are detected using a string comparison that is case insensitive and are
		/// evaluated between per-user and per-machine installations across all contexts. If the list of transforms in the script does
		/// not match the transforms registered for the product, the function returns ERROR_INSTALL_TRANSFORM_FAILURE.
		/// </summary>
		SCRIPTFLAGS_VALIDATE_TRANSFORMS_LIST = 0x00000040,

		/// <summary>
		/// Include this flag if advertisement information in the registry related to COM classes needs to be written or removed.
		/// </summary>
		SCRIPTFLAGS_REGDATA_CLASSINFO = 0x00000080,   // set if COM classes related app info needs to be  created/ deleted

		/// <summary>
		/// Include this flag if advertisement information in the registry related to an extension needs to be written or removed.
		/// </summary>
		SCRIPTFLAGS_REGDATA_EXTENSIONINFO = 0x00000100,   // set if extension related app info needs to be  created/ deleted

		/// <summary>Include this flag if the advertisement information in the registry needs to be written or removed.</summary>
		SCRIPTFLAGS_REGDATA_APPINFO = 0x00000010,

		/// <summary>Include this flag if the advertisement information in the registry needs to be written or removed.</summary>
		SCRIPTFLAGS_REGDATA = SCRIPTFLAGS_REGDATA_APPINFO | SCRIPTFLAGS_REGDATA_CNFGINFO, // for source level backward compatibility
	}

	/// <summary>Return values for <see cref="MsiGetUserInfo"/>.</summary>
	[PInvokeData("msi.h")]
	public enum USERINFOSTATE
	{
		/// <summary>A buffer is too small to hold the requested data.</summary>
		USERINFOSTATE_MOREDATA = -3,  // return buffer overflow

		/// <summary>One of the function parameters was invalid.</summary>
		USERINFOSTATE_INVALIDARG = -2,  // invalid function argument

		/// <summary>The product code does not identify a known product.</summary>
		USERINFOSTATE_UNKNOWN = -1,  // unrecognized product

		/// <summary>Some or all of the user information is absent.</summary>
		USERINFOSTATE_ABSENT = 0,  // user info and PID not initialized

		/// <summary>The function completed successfully.</summary>
		USERINFOSTATE_PRESENT = 1,  // user info and PID initialized
	}

	/// <summary>
	/// <para>Install message type for callback is a combination of the following:</para>
	/// <para>A message box style: MB_*, where MB_OK is the default</para>
	/// <para>A message box icon type: MB_ICON*, where no icon is the default</para>
	/// <para>A default button: MB_DEFBUTTON?, where MB_DEFBUTTON1 is the default</para>
	/// <para>One of the following install message types, no default</para>
	/// </summary>
	[PInvokeData("msi.h")]
	public enum INSTALLMESSAGE : int
	{
		/// <summary>
		/// Premature termination, possibly fatal out of memory.
		/// </summary>
		INSTALLMESSAGE_FATALEXIT = 0x00000000, // premature termination, possibly fatal OOM
		/// <summary>
		/// Formatted error message, [1] is message number in Error table.
		/// </summary>
		INSTALLMESSAGE_ERROR = 0x01000000, // formatted error message
		/// <summary>
		/// Formatted warning message, [1] is message number in Error table.
		/// </summary>
		INSTALLMESSAGE_WARNING = 0x02000000, // formatted warning message
		/// <summary>
		/// User request message, [1] is message number in Error table.
		/// </summary>
		INSTALLMESSAGE_USER = 0x03000000, // user request message
		/// <summary>
		/// Informative message for log, not to be displayed.
		/// </summary>
		INSTALLMESSAGE_INFO = 0x04000000, // informative message for log
		/// <summary>
		/// List of files currently in use that must be closed before being replaced.
		/// </summary>
		INSTALLMESSAGE_FILESINUSE = 0x05000000, // list of files in use that need to be replaced
		/// <summary>
		/// Request to determine a valid source location.
		/// </summary>
		INSTALLMESSAGE_RESOLVESOURCE = 0x06000000, // request to determine a valid source location
		/// <summary>
		/// Insufficient disk space message.
		/// </summary>
		INSTALLMESSAGE_OUTOFDISKSPACE = 0x07000000, // insufficient disk space message
		/// <summary>
		/// Progress: start of action, [1] action name, [2] description, [3] template for ACTIONDATA messages.
		/// </summary>
		INSTALLMESSAGE_ACTIONSTART = 0x08000000, // start of action: action name & description
		/// <summary>
		/// Action data. Record fields correspond to the template of ACTIONSTART message.
		/// </summary>
		INSTALLMESSAGE_ACTIONDATA = 0x09000000, // formatted data associated with individual action item
		/// <summary>
		/// Progress bar information. See the description of record fields below.
		/// </summary>
		INSTALLMESSAGE_PROGRESS = 0x0A000000, // progress gauge info: units so far, total
		/// <summary>
		/// To enable the Cancel button set [1] to 2 and [2] to 1. To disable the Cancel button set [1] to 2 and [2] to 0
		/// </summary>
		INSTALLMESSAGE_COMMONDATA = 0x0B000000, // product info for dialog: language Id, dialog caption
		/// <summary>
		/// sent prior to UI initialization, no string data
		/// </summary>
		INSTALLMESSAGE_INITIALIZE = 0x0C000000, // sent prior to UI initialization, no string data
		/// <summary>
		/// sent after UI termination, no string data
		/// </summary>
		INSTALLMESSAGE_TERMINATE = 0x0D000000, // sent after UI termination, no string data
		/// <summary>
		/// sent prior to display or authored dialog or wizard
		/// </summary>
		INSTALLMESSAGE_SHOWDIALOG = 0x0E000000, // sent prior to display or authored dialog or wizard
		/// <summary>
		/// log only, to log performance number like action time
		/// </summary>
		INSTALLMESSAGE_PERFORMANCE = 0x0F000000, // log only, to log performance number like action time
		/// <summary>
		/// List of files currently in use that must be closed before being replaced. Available beginning with Windows Installer version 4.0. For more information about this message see Using Restart Manager with an External UI.
		/// </summary>
		INSTALLMESSAGE_RMFILESINUSE = 0x19000000, // the list of apps that the user can request Restart Manager to shut down and restart
		/// <summary>
		/// sent prior to server-side install of a product
		/// </summary>
		INSTALLMESSAGE_INSTALLSTART = 0x1A000000, // sent prior to server-side install of a product
		/// <summary>
		/// sent after server-side install
		/// </summary>
		INSTALLMESSAGE_INSTALLEND = 0x1B000000, // sent after server-side install
	}

	/// <summary>
	/// The <c>MSIFILEHASHINFO</c> structure contains the file hash information returned by MsiGetFileHash and used in the MsiFileHash table.
	/// </summary>
	/// <remarks>
	/// The file hash entered into the fields of the MsiFileHash table must be obtained by calling MsiGetFileHash or the FileHash
	/// method. Do not use other methods to generate a file hash.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/ns-msi-msifilehashinfo typedef struct _MSIFILEHASHINFO { ULONG
	// dwFileHashInfoSize; ULONG dwData[4]; } MSIFILEHASHINFO, *PMSIFILEHASHINFO;
	[PInvokeData("msi.h", MSDNShortId = "NS:msi._MSIFILEHASHINFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MSIFILEHASHINFO
	{
		/// <summary>
		/// Specifies the size, in bytes, of this data structure. Set this member to
		/// <code>sizeof(MSIFILEHASHINFO)</code>
		/// before calling the MsiGetFileHash function.
		/// </summary>
		public uint dwFileHashInfoSize;

		/// <summary>
		/// The entire 128-bit file hash is contained in four 32-bit fields. The first field corresponds to the HashPart1 column of the
		/// MsiHashFile table, the second field corresponds to the HashPart2 column, the third field corresponds to the HashPart3
		/// column, and the fourth field corresponds to the HashPart4 column.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public uint[] dwData;
	}

	/// <summary>Provides a handle to a MSI instance.</summary>
	/// <remarks>Initializes a new instance of the <see cref="MSIHANDLE"/> struct.</remarks>
	/// <param name="preexistingHandle">An <see cref="ulong"/> object that represents the pre-existing handle to use.</param>
	[PInvokeData("msi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct MSIHANDLE(ulong preexistingHandle) : IHandle
	{
		private readonly ulong handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="MSIHANDLE"/> object with zero.</summary>
		public static MSIHANDLE NULL => new(0UL);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == 0UL;

		/// <summary>Performs an explicit conversion from <see cref="MSIHANDLE"/> to <see cref="ulong"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator ulong(MSIHANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="ulong"/> to <see cref="MSIHANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator MSIHANDLE(ulong h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(MSIHANDLE h1, MSIHANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(MSIHANDLE h1, MSIHANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is MSIHANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => new(unchecked((long)handle));
	}

	/// <summary>
	/// The <c>MSIPATCHSEQUENCEINFO</c> structure is used by the MsiDeterminePatchSequence and MsiDetermineApplicablePatches functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/ns-msi-msipatchsequenceinfoa typedef struct tagMSIPATCHSEQUENCEINFOA {
	// LPCSTR szPatchData; MSIPATCHDATATYPE ePatchDataType; DWORD dwOrder; UINT uStatus; } MSIPATCHSEQUENCEINFOA, *PMSIPATCHSEQUENCEINFOA;
	[PInvokeData("msi.h", MSDNShortId = "NS:msi.tagMSIPATCHSEQUENCEINFOA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct MSIPATCHSEQUENCEINFO
	{
		/// <summary>Pointer to the path of a patch file, an XML blob, or an XML file.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string szPatchData;

		/// <summary>
		/// <para>Qualifies <c>szPatchData</c> as a patch file, an XML blob, or an XML file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSIPATCH_DATATYPE_PATCHFILE 0</term>
		/// <term>The szPatchData member refers to a path of a patch file.</term>
		/// </item>
		/// <item>
		/// <term>MSIPATCH_DATATYPE_XMLPATH 1</term>
		/// <term>The szPatchData member refers to a path of a XML file.</term>
		/// </item>
		/// <item>
		/// <term>MSIPATCH_DATATYPE_XMLBLOB 2</term>
		/// <term>The szPatchData member refers to an XML blob.</term>
		/// </item>
		/// </list>
		/// </summary>
		public MSIPATCHDATATYPE ePatchDataType;

		/// <summary>
		/// Set to an integer that indicates the sequence of the patch in the order of application. The sequence starts with 0. If a
		/// patch is not applicable to the specified .msi file, or if the function fails, <c>dwOrder</c> is set to -1.
		/// </summary>
		public uint dwOrder;

		/// <summary>Set to ERROR_SUCCESS or the corresponding Win32 error code.</summary>
		public Win32Error uStatus;
	}

	/// <summary>Known installation properties.</summary>
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetProductInfoExA")]
	public static class INSTALLPROPERTY
	{
		/// <summary>
		/// Equals 0 (zero) if the product is advertised or installed per-user. Equals one(1) if the product is advertised or installed
		/// per-computer for all users.
		/// </summary>
		public const string INSTALLPROPERTY_ASSIGNMENTTYPE = "AssignmentType";

		/// <summary>
		/// A value of one (1) indicates a product that can be serviced by non-administrators using User Account Control (UAC) Patching.
		/// A missing value or a value of 0 (zero) indicates that least-privilege patching is not enabled. Available in Windows
		/// Installer 3.0 or later.
		/// </summary>
		public const string INSTALLPROPERTY_AUTHORIZED_LUA_APP = "AuthorizedLUAApp";

		/// <summary></summary>
		public const string INSTALLPROPERTY_DISKPROMPT = "DiskPrompt";

		/// <summary></summary>
		public const string INSTALLPROPERTY_DISPLAYNAME = "DisplayName";

		/// <summary>The support link. For more information, see the ARPHELPLINK property.</summary>
		public const string INSTALLPROPERTY_HELPLINK = "HelpLink";

		/// <summary>The support telephone. For more information, see the ARPHELPTELEPHONE property.</summary>
		public const string INSTALLPROPERTY_HELPTELEPHONE = "HelpTelephone";

		/// <summary>
		/// The last time this product received service. The value of this property is replaced each time a patch is applied or removed
		/// from the product or the /v Command-Line Option is used to repair the product. If the product has received no repairs or
		/// patches this property contains the time this product was installed on this computer.
		/// </summary>
		public const string INSTALLPROPERTY_INSTALLDATE = "InstallDate";

		/// <summary>Installed language. Windows Installer 4.5 and earlier: Not supported.</summary>
		public const string INSTALLPROPERTY_INSTALLEDLANGUAGE = "InstalledLanguage";

		/// <summary>The installed product name. For more information, see the ProductName property.</summary>
		public const string INSTALLPROPERTY_INSTALLEDPRODUCTNAME = "InstalledProductName";

		/// <summary>The installation location. For more information, see the ARPINSTALLLOCATION property.</summary>
		public const string INSTALLPROPERTY_INSTALLLOCATION = "InstallLocation";

		/// <summary>The installation source. For more information, see the SourceDir property.</summary>
		public const string INSTALLPROPERTY_INSTALLSOURCE = "InstallSource";

		/// <summary></summary>
		public const string INSTALLPROPERTY_INSTANCETYPE = "InstanceType";

		/// <summary>Product language.</summary>
		public const string INSTALLPROPERTY_LANGUAGE = "Language";

		/// <summary></summary>
		public const string INSTALLPROPERTY_LASTUSEDSOURCE = "LastUsedSource";

		/// <summary></summary>
		public const string INSTALLPROPERTY_LASTUSEDTYPE = "LastUsedType";

		/// <summary>The local cached package.</summary>
		public const string INSTALLPROPERTY_LOCALPACKAGE = "LocalPackage";

		/// <summary></summary>
		public const string INSTALLPROPERTY_LUAENABLED = "LUAEnabled";

		/// <summary></summary>
		public const string INSTALLPROPERTY_MEDIAPACKAGEPATH = "MediaPackagePath";

		/// <summary></summary>
		public const string INSTALLPROPERTY_MOREINFOURL = "MoreInfoURL";

		/// <summary>Identifier of the package that a product is installed from. For more information, see the Package Codes property.</summary>
		public const string INSTALLPROPERTY_PACKAGECODE = "PackageCode";

		/// <summary>Name of the original installation package.</summary>
		public const string INSTALLPROPERTY_PACKAGENAME = "PackageName";

		/// <summary></summary>
		public const string INSTALLPROPERTY_PATCHSTATE = "State";

		/// <summary></summary>
		public const string INSTALLPROPERTY_PATCHTYPE = "PatchType";

		/// <summary>Primary icon for the package. For more information, see the ARPPRODUCTICON property.</summary>
		public const string INSTALLPROPERTY_PRODUCTICON = "ProductIcon";

		/// <summary>The product identifier. For more information, see the ProductID property.</summary>
		public const string INSTALLPROPERTY_PRODUCTID = "ProductID";

		/// <summary>Human readable product name. For more information, see the ProductName property.</summary>
		public const string INSTALLPROPERTY_PRODUCTNAME = "ProductName";

		/// <summary>The state of the product returned in string form as "1" for advertised and "5" for installed.</summary>
		public const string INSTALLPROPERTY_PRODUCTSTATE = "State";

		/// <summary>The publisher. For more information, see the Manufacturer property.</summary>
		public const string INSTALLPROPERTY_PUBLISHER = "Publisher";

		/// <summary>The company that is registered to use the product.</summary>
		public const string INSTALLPROPERTY_REGCOMPANY = "RegCompany";

		/// <summary>The owner who is registered to use the product.</summary>
		public const string INSTALLPROPERTY_REGOWNER = "RegOwner";

		/// <summary>Transforms.</summary>
		public const string INSTALLPROPERTY_TRANSFORMS = "Transforms";

		/// <summary></summary>
		public const string INSTALLPROPERTY_UNINSTALLABLE = "Uninstallable";

		/// <summary>URL information. For more information, see the ARPURLINFOABOUT property.</summary>
		public const string INSTALLPROPERTY_URLINFOABOUT = "URLInfoAbout";

		/// <summary>The URL update information. For more information, see the ARPURLUPDATEINFO property.</summary>
		public const string INSTALLPROPERTY_URLUPDATEINFO = "URLUpdateInfo";

		/// <summary>Product version derived from the ProductVersion property.</summary>
		public const string INSTALLPROPERTY_VERSION = "Version";

		/// <summary>The major product version that is derived from the ProductVersion property.</summary>
		public const string INSTALLPROPERTY_VERSIONMAJOR = "VersionMajor";

		/// <summary>The minor product version that is derived from the ProductVersion property.</summary>
		public const string INSTALLPROPERTY_VERSIONMINOR = "VersionMinor";

		/// <summary>The product version. For more information, see the ProductVersion property.</summary>
		public const string INSTALLPROPERTY_VERSIONSTRING = "VersionString";
	}

	/// <summary>Provides a self-disposing instance for <see cref="MSIHANDLE"/> that is disposed using <see cref="MsiCloseHandle"/>.</summary>
	public class PMSIHANDLE : System.Runtime.ConstrainedExecution.CriticalFinalizerObject, IDisposable
	{
		private bool disposedValue;
		private MSIHANDLE handle;

		/// <summary>Initializes a new instance of the <see cref="PMSIHANDLE"/> class.</summary>
		private PMSIHANDLE() : base() { }

		/// <summary>Finalizes an instance of the <see cref="PMSIHANDLE"/> class.</summary>
		~PMSIHANDLE()
		{
			Dispose(disposing: false);
		}

		/// <summary>Performs an implicit conversion from <see cref="PMSIHANDLE"/> to <see cref="MSIHANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator MSIHANDLE(PMSIHANDLE h) => h.handle;

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		/// <param name="disposing">
		/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
		/// </param>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				MsiCloseHandle(handle);
				handle = default;
				disposedValue = true;
			}
		}
	}
}