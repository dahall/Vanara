using System.Linq;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>
	/// Defines options that can be applied when adding a run-time reference to a framework package by using the AddPackageDependency function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmodel/ne-appmodel-addpackagedependencyoptions typedef enum
	// AddPackageDependencyOptions { AddPackageDependencyOptions_None, AddPackageDependencyOptions_PrependIfRankCollision } ;
	[PInvokeData("appmodel.h", MSDNShortId = "NE:appmodel.AddPackageDependencyOptions")]
	public enum AddPackageDependencyOptions
	{
		/// <summary>No options are applied.</summary>
		AddPackageDependencyOptions_None,

		/// <summary>
		/// If multiple packages are present in the package graph with the same rank as the call to <c>AddPackageDependency</c>, the
		/// resolved package is added before others of the same rank.
		/// </summary>
		AddPackageDependencyOptions_PrependIfRankCollision,
	}

	/// <summary>
	/// The AppPolicyCreateFileAccess enumeration indicates whether a process has full or restricted access to the IO devices (file,
	/// file stream, directory, physical disk, volume, console buffer, tape drive, communications resource, mailslot, and pipe).
	/// </summary>
	// typedef enum AppPolicyCreateFileAccess { AppPolicyCreateFileAccess_Full = 0, AppPolicyCreateFileAccess_Limited = 1}
	// AppPolicyCreateFileAccess; https://msdn.microsoft.com/en-us/library/windows/desktop/mt829654(v=vs.85).aspx
	[PInvokeData("AppModel.h", MSDNShortId = "mt829654")]
	public enum AppPolicyCreateFileAccess
	{
		/// <summary>
		/// Indicates that the process has full access to the IO devices. This value is expected for a desktop application, or for a
		/// Desktop Bridge application.
		/// </summary>
		AppPolicyCreateFileAccess_Full,

		/// <summary>Indicates that the process has limited access to the IO devices. This value is expected for a UWP app.</summary>
		AppPolicyCreateFileAccess_Limited,
	}

	/// <summary>The AppPolicyProcessTerminationMethod enumeration indicates the method used to end a process.</summary>
	// typedef enum AppPolicyProcessTerminationMethod { AppPolicyProcessTerminationMethod_ExitProcess = 0,
	// AppPolicyProcessTerminationMethod_TerminateProcess = 1} AppPolicyProcessTerminationMethod; https://msdn.microsoft.com/en-us/library/windows/desktop/mt829659(v=vs.85).aspx
	[PInvokeData("AppModel.h", MSDNShortId = "mt829659")]
	public enum AppPolicyProcessTerminationMethod
	{
		/// <summary>
		/// Allows DLLs to execute code at shutdown. This value is expected for a desktop application, or for a Desktop Bridge application.
		/// </summary>
		AppPolicyProcessTerminationMethod_ExitProcess,

		/// <summary>Immediately ends the process. This value is expected for a UWP app.</summary>
		AppPolicyProcessTerminationMethod_TerminateProcess,
	}

	/// <summary>
	/// The AppPolicyShowDeveloperDiagnostic enumeration indicates the method used for a process to surface developer information, such
	/// as asserts, to the user.
	/// </summary>
	// typedef enum AppPolicyShowDeveloperDiagnostic { AppPolicyShowDeveloperDiagnostic_None = 0, AppPolicyShowDeveloperDiagnostic_ShowUI
	// = 1} AppPolicyShowDeveloperDiagnostic; https://msdn.microsoft.com/en-us/library/windows/desktop/mt829660(v=vs.85).aspx
	[PInvokeData("AppModel.h", MSDNShortId = "mt829660")]
	public enum AppPolicyShowDeveloperDiagnostic
	{
		/// <summary>Indicates that the process does not show developer diagnostics. This value is expected for a UWP app.</summary>
		AppPolicyShowDeveloperDiagnostic_None,

		/// <summary>
		/// Indicates that the process shows developer diagnostics UI. This value is expected for a desktop application, or for a
		/// Desktop Bridge application.
		/// </summary>
		AppPolicyShowDeveloperDiagnostic_ShowUI,
	}

	/// <summary>
	/// The AppPolicyThreadInitializationType enumeration indicates the kind of initialization that should be automatically performed
	/// for a process when beginthread[ex] creates a thread.
	/// </summary>
	// typedef enum AppPolicyThreadInitializationType { AppPolicyThreadInitializationType_None = 0,
	// AppPolicyThreadInitializationType_InitializeWinRT = 1} AppPolicyThreadInitializationType; https://msdn.microsoft.com/en-us/library/windows/desktop/mt829661(v=vs.85).aspx
	[PInvokeData("AppModel.h", MSDNShortId = "mt829661")]
	public enum AppPolicyThreadInitializationType
	{
		/// <summary>Indicates that no initialization should be performed.</summary>
		AppPolicyThreadInitializationType_None,

		/// <summary>Indicates that Windows Runtime initialization should be performed.</summary>
		AppPolicyThreadInitializationType_InitializeWinRT,
	}

	/// <summary>
	/// <para>Specifies the processor architectures supported by a package.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appxpackaging/ne-appxpackaging-appx_package_architecture typedef enum
	// APPX_PACKAGE_ARCHITECTURE { APPX_PACKAGE_ARCHITECTURE_X86 , APPX_PACKAGE_ARCHITECTURE_ARM , APPX_PACKAGE_ARCHITECTURE_X64 ,
	// APPX_PACKAGE_ARCHITECTURE_NEUTRAL , APPX_PACKAGE_ARCHITECTURE_ARM64 } ;
	[PInvokeData("appxpackaging.h", MSDNShortId = "8BC7ABF0-448F-4405-AA82-49C6DB3F230C")]
	public enum APPX_PACKAGE_ARCHITECTURE
	{
		/// <summary>The x86 processor architecture.</summary>
		APPX_PACKAGE_ARCHITECTURE_X86 = 0,

		/// <summary>The ARM processor architecture.</summary>
		APPX_PACKAGE_ARCHITECTURE_ARM = 5,

		/// <summary>The x64 processor architecture.</summary>
		APPX_PACKAGE_ARCHITECTURE_X64 = 9,

		/// <summary>Any processor architecture.</summary>
		APPX_PACKAGE_ARCHITECTURE_NEUTRAL = 11,

		/// <summary>The 64-bit ARM processor architecture.</summary>
		APPX_PACKAGE_ARCHITECTURE_ARM64 = 12,
	}

	/// <summary>Defines options that can be applied when creating a package dependency by using the TryCreatePackageDependency function.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmodel/ne-appmodel-createpackagedependencyoptions typedef enum
	// CreatePackageDependencyOptions { CreatePackageDependencyOptions_None,
	// CreatePackageDependencyOptions_DoNotVerifyDependencyResolution, CreatePackageDependencyOptions_ScopeIsSystem } ;
	[PInvokeData("appmodel.h", MSDNShortId = "NE:appmodel.CreatePackageDependencyOptions")]
	[Flags]
	public enum CreatePackageDependencyOptions
	{
		/// <summary>No options are applied.</summary>
		CreatePackageDependencyOptions_None = 0,

		/// <summary>
		/// Disables dependency resolution when pinning a package dependency. This is useful for installers running as user contexts
		/// other than the target user (for example, installers running as LocalSystem).
		/// </summary>
		CreatePackageDependencyOptions_DoNotVerifyDependencyResolution = 1,

		/// <summary>
		/// Defines the package dependency for the system, accessible to all users (by default, the package dependency is defined for a
		/// specific user). This option requires the caller has administrative privileges.
		/// </summary>
		CreatePackageDependencyOptions_ScopeIsSystem = 2,
	}

	/// <summary>Specifies how packages are to be processed.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/appxpkg/package-constants
	[PInvokeData("", MSDNShortId = "72E565C3-6CFD-47E3-8BAC-17D6E86B99DA")]
	[Flags]
	public enum PACKAGE_FLAGS : uint
	{
		/// <summary>The maximum number of apps in a package.</summary>
		PACKAGE_APPLICATIONS_MAX_COUNT = 100,

		/// <summary>The minimum number of apps in a package.</summary>
		PACKAGE_APPLICATIONS_MIN_COUNT = 0,

		/// <summary>The maximum number of resource packages a package can have.</summary>
		PACKAGE_FAMILY_MAX_RESOURCE_PACKAGES = 512,

		/// <summary>The minimum number of resource packages a package can have.</summary>
		PACKAGE_FAMILY_MIN_RESOURCE_PACKAGES = 0,

		/// <summary>
		/// Process all packages in the dependency graph. This is equivalent to PACKAGE_FILTER_HEAD | PACKAGE_FILTER_DIRECT. Note:
		/// PACKAGE_FILTER_ALL_LOADED may be altered or unavailable for releases after Windows 8.1. Instead, use PACKAGE_FILTER_HEAD | PACKAGE_FILTER_DIRECT.
		/// </summary>
		PACKAGE_FILTER_ALL_LOADED = 0x00000000,

		/// <summary>Process bundle packages in the package graph.</summary>
		PACKAGE_FILTER_BUNDLE = 0x00000080,

		/// <summary>Process the directly dependent packages of the head (first) package in the dependency graph.</summary>
		PACKAGE_FILTER_DIRECT = 0x00000020,

		/// <summary>Process the first package in the dependency graph.</summary>
		PACKAGE_FILTER_HEAD = 0x00000010,

		/// <summary>Process bundle packages in the package graph.</summary>
		PACKAGE_FILTER_OPTIONAL = 0x00020000,

		/// <summary>Process resource packages in the package graph.</summary>
		PACKAGE_FILTER_RESOURCE = 0x00000040,

		/// <summary>The maximum size of a package graph.</summary>
		PACKAGE_GRAPH_MAX_SIZE = (1 + PACKAGE_MAX_DEPENDENCIES + PACKAGE_FAMILY_MAX_RESOURCE_PACKAGES),

		/// <summary>The minimum size of a package graph.</summary>
		PACKAGE_GRAPH_MIN_SIZE = 1,

		/// <summary>Retrieve basic information.</summary>
		PACKAGE_INFORMATION_BASIC = 0x00000000,

		/// <summary>Retrieve full information.</summary>
		PACKAGE_INFORMATION_FULL = 0x00000100,

		/// <summary>The maximum number of packages a package depends on.</summary>
		PACKAGE_MAX_DEPENDENCIES = 128,

		/// <summary>The minimum number of packages a package depends on.</summary>
		PACKAGE_MIN_DEPENDENCIES = 0,

		/// <summary>The package is a bundle package.</summary>
		PACKAGE_PROPERTY_BUNDLE = 0x00000004,

		/// <summary>The package was registered with the DeploymentOptions enumeration.</summary>
		PACKAGE_PROPERTY_DEVELOPMENT_MODE = 0x00010000,

		/// <summary>The package is a framework.</summary>
		PACKAGE_PROPERTY_FRAMEWORK = 0x00000001,

		/// <summary>The package is an optional package.</summary>
		PACKAGE_PROPERTY_OPTIONAL = 0x00000008,

		/// <summary>The package is a resource package.</summary>
		PACKAGE_PROPERTY_RESOURCE = 0x00000002,
	}

	/// <summary>Specifies values that indicate the type of artifact that is used to define the lifetime of a package dependency.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmodel/ne-appmodel-packagedependencylifetimekind typedef enum
	// PackageDependencyLifetimeKind { PackageDependencyLifetimeKind_Process, PackageDependencyLifetimeKind_FilePath,
	// PackageDependencyLifetimeKind_RegistryKey } ;
	[PInvokeData("appmodel.h", MSDNShortId = "NE:appmodel.PackageDependencyLifetimeKind")]
	public enum PackageDependencyLifetimeKind
	{
		/// <summary>
		/// The current process is the lifetime artifact. The package dependency is implicitly deleted when the process terminates.
		/// </summary>
		PackageDependencyLifetimeKind_Process,

		/// <summary>
		/// The lifetime artifact is an absolute filename or path. The package dependency is implicitly deleted when this is deleted.
		/// </summary>
		PackageDependencyLifetimeKind_FilePath,

		/// <summary>
		/// <para>The lifetime artifact is a registry key in the format</para>
		/// <para>root</para>
		/// <para>\</para>
		/// <para>subkey</para>
		/// <para>, where</para>
		/// <para>root</para>
		/// <para>
		/// is one of the following: HKEY_LOCAL_MACHINE, HKEY_CURRENT_USER, HKEY_CLASSES_ROOT, or HKEY_USERS. The package dependency is
		/// implicitly deleted when this is deleted.
		/// </para>
		/// </summary>
		PackageDependencyLifetimeKind_RegistryKey,
	}

	/// <summary>
	/// Defines the processor architectures for a framework package dependency that you create by using the TryCreatePackageDependency function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmodel/ne-appmodel-packagedependencyprocessorarchitectures typedef enum
	// PackageDependencyProcessorArchitectures { PackageDependencyProcessorArchitectures_None,
	// PackageDependencyProcessorArchitectures_Neutral, PackageDependencyProcessorArchitectures_X86,
	// PackageDependencyProcessorArchitectures_X64, PackageDependencyProcessorArchitectures_Arm,
	// PackageDependencyProcessorArchitectures_Arm64, PackageDependencyProcessorArchitectures_X86A64 } ;
	[PInvokeData("appmodel.h", MSDNShortId = "NE:appmodel.PackageDependencyProcessorArchitectures")]
	[Flags]
	public enum PackageDependencyProcessorArchitectures
	{
		/// <summary>No processor architecture is specified.</summary>
		PackageDependencyProcessorArchitectures_None = 0x0000,

		/// <summary>Specifies the neutral architecture.</summary>
		PackageDependencyProcessorArchitectures_Neutral = 0x0001,

		/// <summary>Specifies the x86 architecture.</summary>
		PackageDependencyProcessorArchitectures_X86 = 0x0002,

		/// <summary>Specifies the x64 architecture.</summary>
		PackageDependencyProcessorArchitectures_X64 = 0x0004,

		/// <summary>Specifies the ARM architecture.</summary>
		PackageDependencyProcessorArchitectures_Arm = 0x0008,

		/// <summary>Specifies the ARM64 architecture.</summary>
		PackageDependencyProcessorArchitectures_Arm64 = 0x0010,

		/// <summary>Specifies the x86/A64 architecture.</summary>
		PackageDependencyProcessorArchitectures_X86A64 = 0x0020,
	}

	/// <summary>
	/// <para>Specifies the origin of a package.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/ne-appmodel-packageorigin typedef enum PackageOrigin {
	// PackageOrigin_Unknown , PackageOrigin_Unsigned , PackageOrigin_Inbox , PackageOrigin_Store , PackageOrigin_DeveloperUnsigned ,
	// PackageOrigin_DeveloperSigned , PackageOrigin_LineOfBusiness } ;
	[PInvokeData("appmodel.h", MSDNShortId = "0CB9CE97-8A54-4BE7-B054-00F29D36CAB2")]
	public enum PackageOrigin
	{
		/// <summary>The package's origin is unknown.</summary>
		PackageOrigin_Unknown,

		/// <summary>The package originated as unsigned.</summary>
		PackageOrigin_Unsigned,

		/// <summary>The package was included inbox.</summary>
		PackageOrigin_Inbox,

		/// <summary>The package originated from the Windows Store.</summary>
		PackageOrigin_Store,

		/// <summary>The package originated as developer unsigned.</summary>
		PackageOrigin_DeveloperUnsigned,

		/// <summary>The package originated as developer signed.</summary>
		PackageOrigin_DeveloperSigned,

		/// <summary>The package originated as a line-of-business app.</summary>
		PackageOrigin_LineOfBusiness,
	}

	/// <summary>Indicates the type of folder path to retrieve in a query for the path or other info about a package.</summary>
	/// <remarks>
	/// An application has a mutable install folder if it uses the windows.mutablePackageDirectories extension in its package manifest.
	/// This extension specifies a folder under the %ProgramFiles%\ModifiableWindowsApps path where the contents of the application's
	/// install folder are projected so that users can modify the installation files. This feature is currently available only for
	/// certain types of desktop PC games that are published by Microsoft and our partners, and it enables these types of games to
	/// support mods.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmodel/ne-appmodel-packagepathtype typedef enum PackagePathType {
	// PackagePathType_Install, PackagePathType_Mutable, PackagePathType_Effective } ;
	[PInvokeData("appmodel.h")]
	public enum PackagePathType
	{
		/// <summary>Retrieve the package path in the original install folder for the application.</summary>
		PackagePathType_Install,

		/// <summary>
		/// Retrieve the package path in the mutable install folder for the application, if the application is declared as mutable in
		/// the package manifest.
		/// </summary>
		PackagePathType_Mutable,

		/// <summary>
		/// Retrieve the package path in the mutable folder if the application is declared as mutable in the package manifest, or in the
		/// original install folder if the application is not mutable.
		/// </summary>
		PackagePathType_Effective
	}

	/// <summary>
	/// Adds a run-time reference for the framework package dependency you created earlier by using the TryCreatePackageDependency
	/// method, with the specified options. After this method successfully returns, your app can activate types and use content from the
	/// framework package.
	/// </summary>
	/// <param name="packageDependencyId">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>
	/// The ID of the package dependency to be resolved and added to the invoking process' package graph. This parameter must match a
	/// package dependency defined by using the TryCreatePackageDependency function for the calling user or the system (via the
	/// CreatePackageDependencyOptions_ScopeIsSystem option), or else an error is returned.
	/// </para>
	/// </param>
	/// <param name="rank">
	/// <para>Type: <c>INT32</c></para>
	/// <para>The rank to use to add the resolved package to the caller's package graph. For more information, see the remarks.</para>
	/// </param>
	/// <param name="options">
	/// <para>Type: <c>AddPackageDependencyOptions</c></para>
	/// <para>The options to apply when adding the package dependency.</para>
	/// </param>
	/// <param name="packageDependencyContext">
	/// <para>Type: <c>PACKAGEDEPENDENCY_CONTEXT*</c></para>
	/// <para>The handle of the added package dependency. This handle is valid until it is passed to RemovePackageDependency.</para>
	/// </param>
	/// <param name="packageFullName">
	/// <para>Type: <c>PCWSTR*</c></para>
	/// <para>
	/// The full name of the package to which the dependency has been resolved. Use the HeapAlloc function to allocate memory for this
	/// parameter, and use HeapFree to deallocate the memory.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The packageDependencyId or packageDependencyContext parameter is NULL on input.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Calling this method resolves the framework package dependency to a specific package on the system. It also informs the OS that
	/// the framework package is in active use and to handle any version updates in a side-by-side manner (effectively delay
	/// uninstalling or otherwise servicing the older version until after your app is done using it). Package resolution is specific to
	/// a user and can return different values for different users on a system.
	/// </para>
	/// <para>
	/// Each successful <c>AddPackageDependency</c> call adds the resolved package to the calling process' package graph, even if
	/// already present. There is no duplicate detection or filtering applied by the API (that is, multiple references from a package is
	/// not harmful). After resolution is complete, the package dependency stays resolved for that user until the last reference across
	/// all processes for that user is removed via RemovePackageDependency or the process is terminated.
	/// </para>
	/// <para>
	/// After this method successfully returns, your app can activate types and use content from the framework package until
	/// RemovePackageDependency is called.
	/// </para>
	/// <para>
	/// If multiple packages are present in the package graph with the same rank as the call to <c>AddPackageDependency</c>, the
	/// resolved package is (by default) added after others of the same rank. To add a package before others of the same rank, specify
	/// AddPackageDependencyOptions_PrependIfRankCollision for the options parameter.
	/// </para>
	/// <para>For more information, see Use the dynamic dependency API to reference framework packages at run time.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmodel/nf-appmodel-addpackagedependency HRESULT AddPackageDependency( PCWSTR
	// packageDependencyId, INT32 rank, AddPackageDependencyOptions options, PACKAGEDEPENDENCY_CONTEXT *packageDependencyContext, PWSTR
	// *packageFullName );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "NF:appmodel.AddPackageDependency")]
	public static extern HRESULT AddPackageDependency([MarshalAs(UnmanagedType.LPWStr)] string packageDependencyId, int rank,
		AddPackageDependencyOptions options, out PACKAGEDEPENDENCY_CONTEXT packageDependencyContext, out SafeHeapBlock packageFullName);

	/// <summary>
	/// Retrieves a value indicating whether a process has full or restricted access to the IO devices (file, file stream, directory,
	/// physical disk, volume, console buffer, tape drive, communications resource, mailslot, and pipe).
	/// </summary>
	/// <param name="processToken">A handle that identifies the access token for a process.</param>
	/// <param name="policy">
	/// A pointer to a variable of the <c>AppPolicyCreateFileAccess</c> enumerated type. When the function returns successfully, the
	/// variable contains an enumerated constant value indicating whether the process has full or restricted access to the IO devices.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns ERROR_SUCCESS.</para>
	/// <para>
	/// If no known create file access policy was found for the process token, the function raises a STATUS_ASSERTION_FAILURE exception
	/// and returns ERROR_NOT_FOUND.
	/// </para>
	/// <para>If either processToken or policy are null, the function returns ERROR_INVALID_PARAMETER.</para>
	/// </returns>
	// LONG WINAPI AppPolicyGetCreateFileAccess( _In_ HANDLE processToken, _Out_ AppPolicyCreateFileAccess *policy); https://msdn.microsoft.com/en-us/library/windows/desktop/mt829655(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("AppModel.h", MSDNShortId = "mt829655")]
	public static extern Win32Error AppPolicyGetCreateFileAccess(HTOKEN processToken, out AppPolicyCreateFileAccess policy);

	/// <summary>Retrieves the method used to end a process.</summary>
	/// <param name="processToken">A handle that identifies the access token for a process.</param>
	/// <param name="policy">
	/// A pointer to a variable of the <c>AppPolicyProcessTerminationMethod</c> enumerated type. When the function returns successfully,
	/// the variable contains a value indicating the method used to end the process.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns ERROR_SUCCESS.</para>
	/// <para>
	/// If no known create file access policy was found for the process token, the function raises a STATUS_ASSERTION_FAILURE exception
	/// and returns ERROR_NOT_FOUND.
	/// </para>
	/// <para>If either processToken or policy are null, the function returns ERROR_INVALID_PARAMETER.</para>
	/// </returns>
	// LONG WINAPI AppPolicyGetProcessTerminationMethod( _In_ HANDLE processToken, _Out_ AppPolicyProcessTerminationMethod *policy); https://msdn.microsoft.com/en-us/library/windows/desktop/mt829656(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("AppModel.h", MSDNShortId = "mt829656")]
	public static extern Win32Error AppPolicyGetProcessTerminationMethod(HTOKEN processToken, out AppPolicyProcessTerminationMethod policy);

	/// <summary>Retrieves the method used for a process to surface developer information, such as asserts, to the user.</summary>
	/// <param name="processToken">A handle that identifies the access token for a process.</param>
	/// <param name="policy">
	/// A pointer to a variable of the <c>AppPolicyShowDeveloperDiagnostic</c> enumerated type. When the function returns successfully,
	/// the variable contains a value indicating the method used for the process to surface developer information, such as asserts, to
	/// the user.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns ERROR_SUCCESS.</para>
	/// <para>
	/// If no known create file access policy was found for the process token, the function raises a STATUS_ASSERTION_FAILURE exception
	/// and returns ERROR_NOT_FOUND.
	/// </para>
	/// <para>If either processToken or policy are null, the function returns ERROR_INVALID_PARAMETER.</para>
	/// </returns>
	// LONG WINAPI AppPolicyGetShowDeveloperDiagnostic( _In_ HANDLE processToken, _Out_ AppPolicyShowDeveloperDiagnostic *policy); https://msdn.microsoft.com/en-us/library/windows/desktop/mt829657(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("AppModel.h", MSDNShortId = "mt829657")]
	public static extern Win32Error AppPolicyGetShowDeveloperDiagnostic(HTOKEN processToken, out AppPolicyShowDeveloperDiagnostic policy);

	/// <summary>
	/// Retrieves the kind of initialization that should be automatically performed for a process when beginthread[ex] creates a thread.
	/// </summary>
	/// <param name="processToken">A handle that identifies the access token for a process.</param>
	/// <param name="policy">
	/// A pointer to a variable of the <c>AppPolicyThreadInitializationType</c> enumerated type. When the function returns successfully,
	/// the variable contains a value indicating the kind of initialization that should be automatically performed for the process when
	/// beginthread[ex] creates a thread.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns ERROR_SUCCESS.</para>
	/// <para>
	/// If no known create file access policy was found for the process token, the function raises a STATUS_ASSERTION_FAILURE exception
	/// and returns ERROR_NOT_FOUND.
	/// </para>
	/// <para>If either processToken or policy are null, the function returns ERROR_INVALID_PARAMETER.</para>
	/// </returns>
	// LONG WINAPI AppPolicyGetThreadInitializationType( _In_ HANDLE processToken, _Out_ AppPolicyThreadInitializationType *policy); https://msdn.microsoft.com/en-us/library/windows/desktop/mt829658(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("AppModel.h", MSDNShortId = "mt829658")]
	public static extern Win32Error AppPolicyGetThreadInitializationType(HTOKEN processToken, out AppPolicyThreadInitializationType policy);

	/// <summary>
	/// <para>Closes a reference to the specified package information.</para>
	/// </summary>
	/// <param name="packageInfoReference">
	/// <para>Type: <c>PACKAGE_INFO_REFERENCE</c></para>
	/// <para>A reference to package information.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-closepackageinfo LONG ClosePackageInfo(
	// PACKAGE_INFO_REFERENCE packageInfoReference );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "BA84FB47-F241-4120-9441-7E1149F68738")]
	public static extern Win32Error ClosePackageInfo(PACKAGE_INFO_REFERENCE packageInfoReference);

	/// <summary>
	/// Deletes the install-time reference for the framework package dependency you created earlier by using the
	/// TryCreatePackageDependency method. This method informs the OS that it is safe to remove the framework package if no other apps
	/// have a dependency on it.
	/// </summary>
	/// <param name="packageDependencyId">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The ID of the package dependency to remove.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The packageDependencyId parameter is NULL on input.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Removing a package dependency is typically done when an app is uninstalled. A package dependency is implicitly removed if its
	/// lifetime artifact (specified via the lifetimeArtifact parameter of the TryCreatePackageDependency function) is deleted. Package
	/// dependencies that are not referenced by other packages are elegible to be removed.
	/// </para>
	/// <para>The caller of this function must have administrative privileges if the package dependency was created using CreatePackageDependencyOptions_ScopeIsSystem.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmodel/nf-appmodel-deletepackagedependency
	// HRESULT DeletePackageDependency( PCWSTR packageDependencyId );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "NF:appmodel.DeletePackageDependency")]
	public static extern HRESULT DeletePackageDependency([MarshalAs(UnmanagedType.LPWStr)] string packageDependencyId);

	/// <summary>
	/// <para>Finds the packages with the specified family name for the current user.</para>
	/// </summary>
	/// <param name="packageFamilyName">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The package family name.</para>
	/// </param>
	/// <param name="packageFilters">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>
	/// The package constants that specify how package information is retrieved. All package constants except
	/// <c>PACKAGE_FILTER_ALL_LOADED</c> are supported.
	/// </para>
	/// </param>
	/// <param name="count">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>A pointer to a variable that holds the number of package full names that were found.</para>
	/// <para>
	/// First you pass <c>NULL</c> to packageFullNames to get the number of package full names that were found. You use this number to
	/// allocate memory space for packageFullNames. Then you pass the address of this memory space to fill packageFullNames.
	/// </para>
	/// </param>
	/// <param name="packageFullNames">
	/// <para>Type: <c>PWSTR*</c></para>
	/// <para>A pointer to memory space that receives the strings of package full names that were found.</para>
	/// </param>
	/// <param name="bufferLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>A pointer to a variable that holds the number of characters in the string of package full names.</para>
	/// <para>
	/// First you pass <c>NULL</c> to buffer to get the number of characters. You use this number to allocate memory space for buffer.
	/// Then you pass the address of this memory space to fill buffer.
	/// </para>
	/// </param>
	/// <param name="buffer">
	/// <para>Type: <c>WCHAR*</c></para>
	/// <para>A pointer to memory space that receives the string of characters for all of the package full names.</para>
	/// </param>
	/// <param name="packageProperties">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>A pointer to memory space that receives the package properties for all of the packages that were found.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>One or more buffer is not large enough to hold the data. The required size is specified by either count or buffer.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-findpackagesbypackagefamily LONG
	// FindPackagesByPackageFamily( PCWSTR packageFamilyName, UINT32 packageFilters, UINT32 *count, PWSTR *packageFullNames, UINT32
	// *bufferLength, WCHAR *buffer, UINT32 *packageProperties );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "D52E98BD-726F-4AC0-A034-02896B1D1687")]
	public static extern Win32Error FindPackagesByPackageFamily(string packageFamilyName, PACKAGE_FLAGS packageFilters, ref uint count, IntPtr packageFullNames, ref uint bufferLength, IntPtr buffer, IntPtr packageProperties);

	/// <summary>Finds the packages with the specified family name for the current user.</summary>
	/// <param name="packageFamilyName"><para>Type: <c>PCWSTR</c></para>
	/// <para>The package family name.</para></param>
	/// <param name="packageFilters"><para>Type: <c>UINT32</c></para>
	/// <para>
	/// The package constants that specify how package information is retrieved. All package constants except
	/// <c>PACKAGE_FILTER_ALL_LOADED</c> are supported.
	/// </para></param>
	/// <param name="packageFullNames"><para>Type: <c>PWSTR*</c></para>
	/// <para>Receives the strings of package full names that were found.</para></param>
	/// <param name="packageProperties"><para>Type: <c>UINT32*</c></para>
	/// <para>Receives the package properties for all of the packages that were found.</para></param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-findpackagesbypackagefamily LONG
	// FindPackagesByPackageFamily( PCWSTR packageFamilyName, UINT32 packageFilters, UINT32 *count, PWSTR *packageFullNames, UINT32
	// *bufferLength, WCHAR *buffer, UINT32 *packageProperties );
	[PInvokeData("appmodel.h", MSDNShortId = "D52E98BD-726F-4AC0-A034-02896B1D1687")]
	public static Win32Error FindPackagesByPackageFamily(string packageFamilyName, PACKAGE_FLAGS packageFilters, out string?[] packageFullNames, out uint[] packageProperties)
	{
		uint count = 0, bufferLength = 0;
		packageFullNames = new string[0];
		packageProperties = new uint[0];
		Win32Error err = FindPackagesByPackageFamily(packageFamilyName, packageFilters, ref count, default, ref bufferLength, default, default);
		if (count == 0 || err != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			return err;

		using SafeCoTaskMemHandle mem = new(count * IntPtr.Size + bufferLength * StringHelper.GetCharSize(CharSet.Unicode) + count * sizeof(uint));
		IntPtr buffer = mem.DangerousGetHandle().Offset(count * IntPtr.Size);
		IntPtr props = mem.DangerousGetHandle().Offset(count * IntPtr.Size + bufferLength * StringHelper.GetCharSize(CharSet.Unicode));
		err = FindPackagesByPackageFamily(packageFamilyName, packageFilters, ref count, mem, ref bufferLength, buffer, props);
		if (err.Succeeded)
		{
			packageFullNames = mem.ToStringEnum((int)count, CharSet.Unicode).ToArray();
			packageProperties = props.ToArray<uint>((int)count)!;
		}
		return err;
	}

	/// <summary>
	/// <para>Constructs an application user model ID from the package family name and the package relative application ID (PRAID).</para>
	/// </summary>
	/// <param name="packageFamilyName">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The package family name.</para>
	/// </param>
	/// <param name="packageRelativeApplicationId">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The package-relative app ID (PRAID).</para>
	/// </param>
	/// <param name="applicationUserModelIdLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// A pointer to a variable that holds the number of characters ( <c>WCHAR</c> s) in the app user model ID string, which includes
	/// the null-terminator.
	/// </para>
	/// <para>
	/// First you pass <c>NULL</c> to applicationUserModelId to get the number of characters. You use this number to allocate memory
	/// space for applicationUserModelId. Then you pass the address of this memory space to fill applicationUserModelId.
	/// </para>
	/// </param>
	/// <param name="applicationUserModelId">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>A pointer to memory space that receives the app user model ID string, which includes the null-terminator.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The packageFamilyName or packageRelativeApplicationId parameter isn't valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// The buffer specified by applicationUserModelId is not large enough to hold the data; the required buffer size, in WCHARs, is
	/// stored in the variable pointed to by applicationUserModelIdLength.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-formatapplicationusermodelid LONG
	// FormatApplicationUserModelId( PCWSTR packageFamilyName, PCWSTR packageRelativeApplicationId, UINT32
	// *applicationUserModelIdLength, PWSTR applicationUserModelId );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "F48D19C2-6373-41FC-A99D-E3CCB68D6C6C")]
	public static extern Win32Error FormatApplicationUserModelId(string packageFamilyName, string packageRelativeApplicationId,
		ref uint applicationUserModelIdLength, [Optional] StringBuilder? applicationUserModelId);

	/// <summary>
	/// <para>Gets the application user model ID for the specified process.</para>
	/// </summary>
	/// <param name="hProcess">
	/// <para>
	/// A handle to the process. This handle must have the <c>PROCESS_QUERY_LIMITED_INFORMATION</c> access right. For more info, see
	/// Process Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="applicationUserModelIdLength">
	/// <para>
	/// On input, the size of the applicationUserModelId buffer, in wide characters. On success, the size of the buffer used, including
	/// the null terminator.
	/// </para>
	/// </param>
	/// <param name="applicationUserModelId">
	/// <para>A pointer to a buffer that receives the application user model ID.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>APPMODEL_ERROR_NO_APPLICATION</term>
	/// <term>The process has no application identity.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by applicationUserModelIdLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For info about string size limits, see Identity constants.</para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getapplicationusermodelid LONG
	// GetApplicationUserModelId( HANDLE hProcess, UINT32 *applicationUserModelIdLength, PWSTR applicationUserModelId );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "FE4E0818-F548-494B-B3BD-FB51DC748451")]
	public static extern Win32Error GetApplicationUserModelId(HPROCESS hProcess, ref uint applicationUserModelIdLength,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? applicationUserModelId);

	/// <summary>
	/// <para>Gets the application user model ID for the specified token.</para>
	/// </summary>
	/// <param name="token">
	/// <para>
	/// A token that contains the application identity. This handle must have the <c>PROCESS_QUERY_LIMITED_INFORMATION</c> access right.
	/// For more info, see Process Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="applicationUserModelIdLength">
	/// <para>
	/// On input, the size of the applicationUserModelId buffer, in wide characters. On success, the size of the buffer used, including
	/// the null terminator.
	/// </para>
	/// </param>
	/// <param name="applicationUserModelId">
	/// <para>A pointer to a buffer that receives the application user model ID.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>APPMODEL_ERROR_NO_APPLICATION</term>
	/// <term>The token has no application identity.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by applicationUserModelIdLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For info about string size limits, see Identity constants.</para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getapplicationusermodelidfromtoken LONG
	// GetApplicationUserModelIdFromToken( HANDLE token, UINT32 *applicationUserModelIdLength, PWSTR applicationUserModelId );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "80036518-927E-4CD0-B499-8EA472AB7E5A")]
	public static extern Win32Error GetApplicationUserModelIdFromToken(HTOKEN token, ref uint applicationUserModelIdLength,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? applicationUserModelId);

	/// <summary>
	/// <para>Gets the application user model ID for the current process.</para>
	/// </summary>
	/// <param name="applicationUserModelIdLength">
	/// <para>
	/// On input, the size of the applicationUserModelId buffer, in wide characters. On success, the size of the buffer used, including
	/// the null terminator.
	/// </para>
	/// </param>
	/// <param name="applicationUserModelId">
	/// <para>A pointer to a buffer that receives the application user model ID.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>APPMODEL_ERROR_NO_APPLICATION</term>
	/// <term>The process has no application identity.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by applicationUserModelIdLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For info about string size limits, see Identity constants.</para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getcurrentapplicationusermodelid LONG
	// GetCurrentApplicationUserModelId( UINT32 *applicationUserModelIdLength, PWSTR applicationUserModelId );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "562BB225-0922-4FE7-92C0-573A2CCE3195")]
	public static extern Win32Error GetCurrentApplicationUserModelId(ref uint applicationUserModelIdLength, [Optional] StringBuilder? applicationUserModelId);

	/// <summary>
	/// <para>Gets the package family name for the calling process.</para>
	/// </summary>
	/// <param name="packageFamilyNameLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// On input, the size of the packageFamilyName buffer, in characters, including the null terminator. On output, the size of the
	/// package family name returned, in characters, including the null terminator.
	/// </para>
	/// </param>
	/// <param name="packageFamilyName">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>The package family name.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>APPMODEL_ERROR_NO_PACKAGE</term>
	/// <term>The process has no package identity.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by packageFamilyNameLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For info about string size limits, see Identity constants.</para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getcurrentpackagefamilyname LONG
	// GetCurrentPackageFamilyName( UINT32 *packageFamilyNameLength, PWSTR packageFamilyName );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "39DBFBDD-A1CC-45C3-A5DD-5ED9697F9AFE")]
	public static extern Win32Error GetCurrentPackageFamilyName(ref uint packageFamilyNameLength, [Optional] StringBuilder? packageFamilyName);

	/// <summary>
	/// <para>Gets the package full name for the calling process.</para>
	/// </summary>
	/// <param name="packageFullNameLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// On input, the size of the packageFullName buffer, in characters. On output, the size of the package full name returned, in
	/// characters, including the null terminator.
	/// </para>
	/// </param>
	/// <param name="packageFullName">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>The package full name.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>APPMODEL_ERROR_NO_PACKAGE</term>
	/// <term>The process has no package identity.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by packageFullNameLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For info about string size limits, see Identity constants.</para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getcurrentpackagefullname LONG
	// GetCurrentPackageFullName( UINT32 *packageFullNameLength, PWSTR packageFullName );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "D5B00C53-1FBF-4245-92D1-FA39713A9EE7")]
	public static extern Win32Error GetCurrentPackageFullName(ref uint packageFullNameLength, [Optional] StringBuilder? packageFullName);

	/// <summary>
	/// <para>Gets the package identifier (ID) for the calling process.</para>
	/// </summary>
	/// <param name="bufferLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>On input, the size of buffer, in bytes. On output, the size of the structure returned, in bytes.</para>
	/// </param>
	/// <param name="buffer">
	/// <para>Type: <c>BYTE*</c></para>
	/// <para>The package ID, represented as a PACKAGE_ID structure.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>APPMODEL_ERROR_NO_PACKAGE</term>
	/// <term>The process has no package identity.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by bufferLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getcurrentpackageid LONG GetCurrentPackageId( UINT32
	// *bufferLength, BYTE *buffer );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "4CFC707A-2A5A-41FE-BB5F-6FECACC99271")]
	public static extern Win32Error GetCurrentPackageId(ref uint bufferLength, IntPtr buffer);

	/// <summary>
	/// <para>Gets the package information for the calling process.</para>
	/// </summary>
	/// <param name="flags">
	/// <para>Type: <c>const UINT32</c></para>
	/// <para>The package constants that specify how package information is retrieved. The <c>PACKAGE_FILTER_*</c> flags are supported.</para>
	/// </param>
	/// <param name="bufferLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>On input, the size of buffer, in bytes. On output, the size of the array of structures returned, in bytes.</para>
	/// </param>
	/// <param name="buffer">
	/// <para>Type: <c>BYTE*</c></para>
	/// <para>The package information, represented as an array of PACKAGE_INFO structures.</para>
	/// </param>
	/// <param name="count">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of structures in the buffer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>APPMODEL_ERROR_NO_PACKAGE</term>
	/// <term>The process has no package identity.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by bufferLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getcurrentpackageinfo LONG GetCurrentPackageInfo( const
	// UINT32 flags, UINT32 *bufferLength, BYTE *buffer, UINT32 *count );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "A1887D61-0FAD-4BE8-850F-F104CC074798")]
	public static extern Win32Error GetCurrentPackageInfo(PACKAGE_FLAGS flags, ref uint bufferLength, IntPtr buffer, out uint count);

	/// <summary>
	/// Gets the package information for the calling process, with the option to specify the type of folder path to retrieve for the package.
	/// </summary>
	/// <param name="flags">
	/// <para>Type: <c>const UINT32</c></para>
	/// <para>The package constants that specify how package information is retrieved. The <c>PACKAGE_FILTER_*</c> flags are supported.</para>
	/// </param>
	/// <param name="packagePathType">
	/// <para>Type: <c>PackagePathType</c></para>
	/// <para>Indicates the type of folder path to retrieve for the package (the original install folder or the mutable folder).</para>
	/// </param>
	/// <param name="bufferLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>On input, the size of buffer, in bytes. On output, the size of the array of structures returned, in bytes.</para>
	/// </param>
	/// <param name="buffer">
	/// <para>Type: <c>BYTE*</c></para>
	/// <para>The package information, represented as an array of PACKAGE_INFO structures.</para>
	/// </param>
	/// <param name="count">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of structures in the buffer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>APPMODEL_ERROR_NO_PACKAGE</term>
	/// <term>The process has no package identity.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by bufferLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The packagePathType parameter is useful for applications that use the windows.mutablePackageDirectories extension in their
	/// package manifest. This extension specifies a folder under the %ProgramFiles%\ModifiableWindowsApps path where the contents of
	/// the application's install folder are projected so that users can modify the installation files. This feature is currently
	/// available only for certain types of desktop PC games that are published by Microsoft and our partners, and it enables these
	/// types of games to support mods.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmodel/nf-appmodel-getcurrentpackageinfo2 LONG GetCurrentPackageInfo2( const
	// UINT32 flags, PackagePathType packagePathType, UINT32 *bufferLength, BYTE *buffer, UINT32 *count );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h")]
	public static extern Win32Error GetCurrentPackageInfo2(PACKAGE_FLAGS flags, PackagePathType packagePathType, ref uint bufferLength, IntPtr buffer, out uint count);

	/// <summary>
	/// <para>Gets the package path for the calling process.</para>
	/// </summary>
	/// <param name="pathLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// On input, the size of the path buffer, in characters. On output, the size of the package path returned, in characters, including
	/// the null terminator.
	/// </para>
	/// </param>
	/// <param name="path">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>The package path.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>APPMODEL_ERROR_NO_PACKAGE</term>
	/// <term>The process has no package identity.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by pathLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getcurrentpackagepath LONG GetCurrentPackagePath( UINT32
	// *pathLength, PWSTR path );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "46CE81DF-A9D5-492E-AB5E-4F043DC326E2")]
	public static extern Win32Error GetCurrentPackagePath(ref uint pathLength, [Optional] StringBuilder? path);

	/// <summary>
	/// Gets the package path for the calling process, with the option to specify the type of folder path to retrieve for the package.
	/// </summary>
	/// <param name="packagePathType">
	/// <para>Type: <c>PackagePathType</c></para>
	/// <para>Indicates the type of folder path to retrieve for the package (the original install folder or the mutable folder).</para>
	/// </param>
	/// <param name="pathLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// On input, the size of the path buffer, in characters. On output, the size of the package path returned, in characters, including
	/// the null terminator.
	/// </para>
	/// </param>
	/// <param name="path">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>The package path.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>APPMODEL_ERROR_NO_PACKAGE</term>
	/// <term>The process has no package identity.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by pathLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The packagePathType parameter is useful for applications that use the windows.mutablePackageDirectories extension in their
	/// package manifest. This extension specifies a folder under the %ProgramFiles%\ModifiableWindowsApps path where the contents of
	/// the application's install folder are projected so that users can modify the installation files. This feature is currently
	/// available only for certain types of desktop PC games that are published by Microsoft and our partners, and it enables these
	/// types of games to support mods.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmodel/nf-appmodel-getcurrentpackagepath2 LONG GetCurrentPackagePath2(
	// PackagePathType packagePathType, UINT32 *pathLength, PWSTR path );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h")]
	public static extern Win32Error GetCurrentPackagePath2(PackagePathType packagePathType, ref uint pathLength,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? path);

	/// <summary>Returns the package dependency for the specified context handle.</summary>
	/// <param name="packageDependencyContext">
	/// <para>Type: <c>PACKAGEDEPENDENCY_CONTEXT</c></para>
	/// <para>The handle of the package dependency to return.</para>
	/// </param>
	/// <param name="packageDependencyId">
	/// <para>Type: <c>PCWSTR*</c></para>
	/// <para>
	/// The ID of the package dependency for the specified context handle. If the package dependency cannot be resolved, the function
	/// succeeds but this parameter is <c>nullptr</c> on output. Use the HeapAlloc function to allocate memory for this parameter, and
	/// use HeapFree to deallocate the memory.
	/// </para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The packageDependencyContext or packageDependencyId parameter is NULL on input.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/gl-es/windows/win32/api/appmodel/nf-appmodel-getidforpackagedependencycontext
	// HRESULT GetIdForPackageDependencyContext( PACKAGEDEPENDENCY_CONTEXT packageDependencyContext, PWSTR *packageDependencyId );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "NF:appmodel.GetIdForPackageDependencyContext")]
	public static extern HRESULT GetIdForPackageDependencyContext(PACKAGEDEPENDENCY_CONTEXT packageDependencyContext,
		out SafeHeapBlock packageDependencyId);

	/// <summary>
	/// <para>Gets the IDs of apps in the specified package.</para>
	/// </summary>
	/// <param name="packageInfoReference">
	/// <para>Type: <c>PACKAGE_INFO_REFERENCE</c></para>
	/// <para>A reference to package information.</para>
	/// </param>
	/// <param name="bufferLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>A pointer to a variable that holds the size of buffer, in bytes.</para>
	/// <para>
	/// First you pass <c>NULL</c> to buffer to get the required size of buffer. You use this number to allocate memory space for
	/// buffer. Then you pass the address of this memory space to fill buffer.
	/// </para>
	/// </param>
	/// <param name="buffer">
	/// <para>Type: <c>BYTE*</c></para>
	/// <para>A pointer to memory space that receives the app IDs.</para>
	/// </param>
	/// <param name="count">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>A pointer to a variable that receives the number of app IDs in buffer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by bufferLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getpackageapplicationids LONG GetPackageApplicationIds(
	// PACKAGE_INFO_REFERENCE packageInfoReference, UINT32 *bufferLength, BYTE *buffer, UINT32 *count );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "F08135F9-FF45-4309-84B5-77F4AFD7FC0C")]
	public static extern Win32Error GetPackageApplicationIds(PACKAGE_INFO_REFERENCE packageInfoReference, ref uint bufferLength, IntPtr buffer, out uint count);

	/// <summary>
	/// <para>Gets the package family name for the specified process.</para>
	/// </summary>
	/// <param name="hProcess">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>
	/// A handle to the process that has the <c>PROCESS_QUERY_INFORMATION</c> or <c>PROCESS_QUERY_LIMITED_INFORMATION</c> access right.
	/// For more information, see Process Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="packageFamilyNameLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// On input, the size of the packageFamilyName buffer, in characters. On output, the size of the package family name returned, in
	/// characters, including the null-terminator.
	/// </para>
	/// </param>
	/// <param name="packageFamilyName">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>The package family name.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>APPMODEL_ERROR_NO_PACKAGE</term>
	/// <term>The process has no package identity.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by packageFamilyNameLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For info about string size limits, see Identity constants.</para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getpackagefamilyname LONG GetPackageFamilyName( HANDLE
	// hProcess, UINT32 *packageFamilyNameLength, PWSTR packageFamilyName );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "AC239898-9924-4193-9072-7A7EEC2D03E9")]
	public static extern Win32Error GetPackageFamilyName(HPROCESS hProcess, ref uint packageFamilyNameLength, [Optional] StringBuilder? packageFamilyName);

	/// <summary>
	/// <para>Gets the package family name for the specified token.</para>
	/// </summary>
	/// <param name="token">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>A token that contains the package identity.</para>
	/// </param>
	/// <param name="packageFamilyNameLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// On input, the size of the packageFamilyName buffer, in characters. On output, the size of the package family name returned, in
	/// characters, including the null-terminator.
	/// </para>
	/// </param>
	/// <param name="packageFamilyName">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>The package family name.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>APPMODEL_ERROR_NO_PACKAGE</term>
	/// <term>The token has no package identity.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by packageFamilyNameLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For info about string size limits, see Identity constants.</para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getpackagefamilynamefromtoken LONG
	// GetPackageFamilyNameFromToken( HANDLE token, UINT32 *packageFamilyNameLength, PWSTR packageFamilyName );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "C4FAF5DE-DF1F-4AFA-813B-5D80C786031B")]
	public static extern Win32Error GetPackageFamilyNameFromToken(HTOKEN token, ref uint packageFamilyNameLength, [Optional] StringBuilder? packageFamilyName);

	/// <summary>Gets the package full name for the specified process.</summary>
	/// <param name="hProcess">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>
	/// A handle to the process that has the <c>PROCESS_QUERY_INFORMATION</c> or <c>PROCESS_QUERY_LIMITED_INFORMATION</c> access right.
	/// For more information, see Process Security and Access Rights.
	/// </para>
	/// </param>
	/// <param name="packageFullNameLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// On input, the size of the packageFullName buffer, in characters. On output, the size of the package full name returned, in
	/// characters, including the null terminator.
	/// </para>
	/// </param>
	/// <param name="packageFullName">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>The package full name.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>APPMODEL_ERROR_NO_PACKAGE</term>
	/// <term>The process has no package identity.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by packageFullNameLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For info about string size limits, see Identity constants.</para>
	/// <para>Examples</para>
	/// <para>
	/// <code>#define _UNICODE 1 #define UNICODE 1 #include &lt;Windows.h&gt; #include &lt;appmodel.h&gt; #include &lt;malloc.h&gt; #include &lt;stdlib.h&gt; #include &lt;stdio.h&gt; int ShowUsage(); void ShowProcessPackageFullName(__in const UINT32 pid, __in HANDLE process); int ShowUsage() { wprintf(L"Usage: GetPackageFullName &lt;pid&gt; [&lt;pid&gt;...]\n"); return 1; } int __cdecl wmain(__in int argc, __in_ecount(argc) WCHAR * argv[]) { if (argc &lt;= 1) return ShowUsage(); for (int i=1; i&lt;argc; ++i) { UINT32 pid = wcstoul(argv[i], NULL, 10); if (pid &gt; 0) { HANDLE process = OpenProcess(PROCESS_QUERY_LIMITED_INFORMATION, FALSE, pid); if (process == NULL) wprintf(L"Error %d in OpenProcess (pid=%u)\n", GetLastError(), pid); else { ShowProcessPackageFullName(pid, process); CloseHandle(process); } } } return 0; } void ShowProcessPackageFullName(__in const UINT32 pid, __in HANDLE process) { wprintf(L"Process %u (handle=%p)\n", pid, process); UINT32 length = 0; LONG rc = GetPackageFullName(process, &amp;length, NULL); if (rc != ERROR_INSUFFICIENT_BUFFER) { if (rc == APPMODEL_ERROR_NO_PACKAGE) wprintf(L"Process has no package identity\n"); else wprintf(L"Error %d in GetPackageFullName\n", rc); return; } PWSTR fullName = (PWSTR) malloc(length * sizeof(*fullName)); if (fullName == NULL) { wprintf(L"Error allocating memory\n"); return; } rc = GetPackageFullName(process, &amp;length, fullName); if (rc != ERROR_SUCCESS) wprintf(L"Error %d retrieving PackageFullName\n", rc); else wprintf(L"%s\n", fullName); free(fullName); }</code>
	/// </para>
	/// </remarks>
	// https://webcache.googleusercontent.com/search?q=cache:IqzT6kD4rycJ:https://docs.microsoft.com/en-us/windows/win32/api/appmodel/nf-appmodel-getpackagefullname+&cd=2&hl=en&ct=clnk&gl=us
	// LONG GetPackageFullName( HANDLE hProcess, UINT32 *packageFullNameLength, PWSTR packageFullName );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "NF:appmodel.GetPackageFullName")]
	public static extern Win32Error GetPackageFullName(HPROCESS hProcess, ref uint packageFullNameLength,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? packageFullName);

	/// <summary>
	/// <para>Gets the package full name for the specified token.</para>
	/// </summary>
	/// <param name="token">
	/// <para>A token that contains the package identity.</para>
	/// </param>
	/// <param name="packageFullNameLength">
	/// <para>
	/// On input, the size of the packageFullName buffer, in characters. On output, the size of the package full name returned, in
	/// characters, including the null terminator.
	/// </para>
	/// </param>
	/// <param name="packageFullName">
	/// <para>The package full name.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>APPMODEL_ERROR_NO_PACKAGE</term>
	/// <term>The token has no package identity.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by packageFullNameLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For info about string size limits, see Identity constants.</para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getpackagefullnamefromtoken LONG
	// GetPackageFullNameFromToken( HANDLE token, UINT32 *packageFullNameLength, PWSTR packageFullName );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "7B0D574E-A2F5-4D08-AEFB-9E040BBC729F")]
	public static extern Win32Error GetPackageFullNameFromToken(HTOKEN token, ref uint packageFullNameLength, [Optional] StringBuilder? packageFullName);

	/// <summary>
	/// <para>Gets the package information for the specified package.</para>
	/// </summary>
	/// <param name="packageInfoReference">
	/// <para>Type: <c>PACKAGE_INFO_REFERENCE</c></para>
	/// <para>A reference to package information.</para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>const UINT32</c></para>
	/// <para>The package constants that specify how package information is retrieved.</para>
	/// </param>
	/// <param name="bufferLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>On input, the size of buffer, in bytes. On output, the size of the package information returned, in bytes.</para>
	/// </param>
	/// <param name="buffer">
	/// <para>Type: <c>BYTE*</c></para>
	/// <para>The package information, represented as an array of PACKAGE_INFO structures.</para>
	/// </param>
	/// <param name="count">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of packages in the buffer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by bufferLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getpackageinfo LONG GetPackageInfo(
	// PACKAGE_INFO_REFERENCE packageInfoReference, const UINT32 flags, UINT32 *bufferLength, BYTE *buffer, UINT32 *count );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "28F45B3B-A61F-44D3-B606-6966AD5866FA")]
	public static extern Win32Error GetPackageInfo(PACKAGE_INFO_REFERENCE packageInfoReference, uint flags, ref uint bufferLength, IntPtr buffer, out uint count);

	/// <summary>
	/// Gets the package information for the specified package, with the option to specify the type of folder path to retrieve for the package.
	/// </summary>
	/// <param name="packageInfoReference">
	/// <para>Type: <c>PACKAGE_INFO_REFERENCE</c></para>
	/// <para>A reference to package information.</para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>const UINT32</c></para>
	/// <para>The package constants that specify how package information is retrieved.</para>
	/// </param>
	/// <param name="packagePathType">
	/// <para>Type: <c>PackagePathType</c></para>
	/// <para>Indicates the type of folder path to retrieve for the package (the original install folder or the mutable folder).</para>
	/// </param>
	/// <param name="bufferLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>On input, the size of buffer, in bytes. On output, the size of the package information returned, in bytes.</para>
	/// </param>
	/// <param name="buffer">
	/// <para>Type: <c>BYTE*</c></para>
	/// <para>The package information, represented as an array of PACKAGE_INFO structures.</para>
	/// </param>
	/// <param name="count">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of packages in the buffer.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by bufferLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The packagePathType parameter is useful for applications that use the windows.mutablePackageDirectories extension in their
	/// package manifest. This extension specifies a folder under the %ProgramFiles%\ModifiableWindowsApps path where the contents of
	/// the application's install folder are projected so that users can modify the installation files. This feature is currently
	/// available only for certain types of desktop PC games that are published by Microsoft and our partners, and it enables these
	/// types of games to support mods.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmodel/nf-appmodel-getpackageinfo2 LONG GetPackageInfo2(
	// PACKAGE_INFO_REFERENCE packageInfoReference, const UINT32 flags, PackagePathType packagePathType, UINT32 *bufferLength, BYTE
	// *buffer, UINT32 *count );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h")]
	public static extern Win32Error GetPackageInfo2(PACKAGE_INFO_REFERENCE packageInfoReference, uint flags, PackagePathType packagePathType, ref uint bufferLength, IntPtr buffer, out uint count);

	/// <summary>
	/// <para>Gets the path for the specified package.</para>
	/// </summary>
	/// <param name="packageId">
	/// <para>Type: <c>const PACKAGE_ID*</c></para>
	/// <para>The package identifier.</para>
	/// </param>
	/// <param name="reserved">
	/// <para>Type: <c>const UINT32</c></para>
	/// <para>Reserved, do not use.</para>
	/// </param>
	/// <param name="pathLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// On input, the size of the path buffer, in characters. On output, the size of the package path returned, in characters, including
	/// the null-terminator.
	/// </para>
	/// </param>
	/// <param name="path">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>The package path.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer specified by path is not large enough to hold the data. The required size is specified by pathLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getpackagepath LONG GetPackagePath( const PACKAGE_ID
	// *packageId, const UINT32 reserved, UINT32 *pathLength, PWSTR path );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "BDA0DD87-A36D-486B-BF89-EA5CC105C742")]
	public static extern Win32Error GetPackagePath(in PACKAGE_ID packageId, uint reserved, ref uint pathLength, [Optional] StringBuilder? path);

	/// <summary>
	/// <para>Gets the path of the specified package.</para>
	/// </summary>
	/// <param name="packageFullName">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The full name of the package.</para>
	/// </param>
	/// <param name="pathLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// A pointer to a variable that holds the number of characters ( <c>WCHAR</c> s) in the package path string, which includes the null-terminator.
	/// </para>
	/// <para>
	/// First you pass <c>NULL</c> to path to get the number of characters. You use this number to allocate memory space for path. Then
	/// you pass the address of this memory space to fill path.
	/// </para>
	/// </param>
	/// <param name="path">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>A pointer to memory space that receives the package path string, which includes the null-terminator.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer specified by path is not large enough to hold the data. The required size is specified by pathLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getpackagepathbyfullname LONG GetPackagePathByFullName(
	// PCWSTR packageFullName, UINT32 *pathLength, PWSTR path );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "9C25708C-1464-4C59-9740-E9F105116385")]
	public static extern Win32Error GetPackagePathByFullName(string packageFullName, ref uint pathLength, [Optional] StringBuilder? path);

	/// <summary>Gets the path of the specified package, with the option to specify the type of folder path to retrieve for the package.</summary>
	/// <param name="packageFullName">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The full name of the package.</para>
	/// </param>
	/// <param name="packagePathType">
	/// <para>Type: <c>PackagePathType</c></para>
	/// <para>Indicates the type of folder path to retrieve for the package (the original install folder or the mutable folder).</para>
	/// </param>
	/// <param name="pathLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// A pointer to a variable that holds the number of characters ( <c>WCHAR</c> s) in the package path string, which includes the null-terminator.
	/// </para>
	/// <para>
	/// First you pass <c>NULL</c> to path to get the number of characters. You use this number to allocate memory space for path. Then
	/// you pass the address of this memory space to fill path.
	/// </para>
	/// </param>
	/// <param name="path">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>A pointer to memory space that receives the package path string, which includes the null-terminator.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer specified by path is not large enough to hold the data. The required size is specified by pathLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The packagePathType parameter is useful for applications that use the windows.mutablePackageDirectories extension in their
	/// package manifest. This extension specifies a folder under the %ProgramFiles%\ModifiableWindowsApps path where the contents of
	/// the application's install folder are projected so that users can modify the installation files. This feature is currently
	/// available only for certain types of desktop PC games that are published by Microsoft and our partners, and it enables these
	/// types of games to support mods.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmodel/nf-appmodel-getpackagepathbyfullname2 LONG GetPackagePathByFullName2(
	// PCWSTR packageFullName, PackagePathType packagePathType, UINT32 *pathLength, PWSTR path );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h")]
	public static extern Win32Error GetPackagePathByFullName2([MarshalAs(UnmanagedType.LPWStr)] string packageFullName, PackagePathType packagePathType,
		ref uint pathLength, [Optional, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? path);

	/// <summary>Gets the packages with the specified family name for the current user.</summary>
	/// <param name="packageFamilyName">The package family name.</param>
	/// <param name="packageFullNames">A pointer to the strings of package full names.</param>
	/// <returns>If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getpackagesbypackagefamily LONG
	// GetPackagesByPackageFamily( PCWSTR packageFamilyName, UINT32 *count, PWSTR *packageFullNames, UINT32 *bufferLength, WCHAR *buffer );
	[PInvokeData("appmodel.h", MSDNShortId = "C2163203-D654-4491-9090-0CC43F42EC35")]
	public static Win32Error GetPackagesByPackageFamily(string packageFamilyName, out string?[] packageFullNames)
	{
		uint count = 0, bufferLength = 0;
		packageFullNames = new string[0];
		Win32Error err = GetPackagesByPackageFamily(packageFamilyName, ref count, default, ref bufferLength, default);
		if (err != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			return err;

		using SafeCoTaskMemHandle mem = new(count * IntPtr.Size + bufferLength * StringHelper.GetCharSize(CharSet.Unicode));
		IntPtr buffer = mem.DangerousGetHandle().Offset(count * IntPtr.Size);
		err = GetPackagesByPackageFamily(packageFamilyName, ref count, mem, ref bufferLength, buffer);
		if (err.Succeeded)
			packageFullNames = mem.ToStringEnum((int)count, CharSet.Unicode).ToArray();
		return err;
	}

	/// <summary>Gets the packages with the specified family name for the current user.</summary>
	/// <param name="packageFamilyName">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The package family name.</para>
	/// </param>
	/// <param name="count">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>A pointer to a variable that holds the number of package full names.</para>
	/// <para>
	/// First you pass <c>NULL</c> to packageFullNames to get the number of package full names. You use this number to allocate memory space
	/// for packageFullNames. Then you pass the address of this number to fill packageFullNames.
	/// </para>
	/// </param>
	/// <param name="packageFullNames">
	/// <para>Type: <c>PWSTR*</c></para>
	/// <para>A pointer to the strings of package full names.</para>
	/// </param>
	/// <param name="bufferLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>A pointer to a variable that holds the number of characters in the string of package full names.</para>
	/// <para>
	/// First you pass <c>NULL</c> to buffer to get the number of characters. You use this number to allocate memory space for buffer. Then
	/// you pass the address of this number to fill buffer.
	/// </para>
	/// </param>
	/// <param name="buffer">
	/// <para>Type: <c>WCHAR*</c></para>
	/// <para>The string of characters for all of the package full names.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error codes
	/// include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>One or more buffer is not large enough to hold the data. The required size is specified by either count or buffer.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getpackagesbypackagefamily LONG
	// GetPackagesByPackageFamily( PCWSTR packageFamilyName, UINT32 *count, PWSTR *packageFullNames, UINT32 *bufferLength, WCHAR *buffer );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "C2163203-D654-4491-9090-0CC43F42EC35")]
	public static extern Win32Error GetPackagesByPackageFamily(string packageFamilyName, ref uint count,
		[Out] IntPtr packageFullNames, ref uint bufferLength, [Out] IntPtr buffer);

	/// <summary>
	/// <para>Gets the origin of the specified package.</para>
	/// </summary>
	/// <param name="packageFullName">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The full name of the package.</para>
	/// </param>
	/// <param name="origin">
	/// <para>Type: <c>PackageOrigin*</c></para>
	/// <para>
	/// A pointer to a variable that receives a PackageOrigin-typed value that indicates the origin of the package specified by packageFullName.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The packageFullName parameter isn't valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getstagedpackageorigin LONG GetStagedPackageOrigin(
	// PCWSTR packageFullName, PackageOrigin *origin );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "7A1EE2CA-83CE-4E03-85A5-0061E29EB49B")]
	public static extern Win32Error GetStagedPackageOrigin(string packageFullName, out PackageOrigin origin);

	/// <summary>
	/// <para>Gets the path of the specified staged package.</para>
	/// </summary>
	/// <param name="packageFullName">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The full name of the staged package.</para>
	/// </param>
	/// <param name="pathLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// A pointer to a variable that holds the number of characters ( <c>WCHAR</c> s) in the package path string, which includes the null-terminator.
	/// </para>
	/// <para>
	/// First you pass <c>NULL</c> to path to get the number of characters. You use this number to allocate memory space for path. Then
	/// you pass the address of this memory space to fill path.
	/// </para>
	/// </param>
	/// <param name="path">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>A pointer to memory space that receives the package path string, which includes the null-terminator.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer specified by path is not large enough to hold the data. The required size is specified by pathLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function succeeds if the package is staged, regardless of the user context or if the package is registered for the current user.
	/// </para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-getstagedpackagepathbyfullname LONG
	// GetStagedPackagePathByFullName( PCWSTR packageFullName, UINT32 *pathLength, PWSTR path );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "F0A37D77-6262-44B1-BEC5-083E41BDE139")]
	public static extern Win32Error GetStagedPackagePathByFullName([MarshalAs(UnmanagedType.LPWStr)] string packageFullName, ref uint pathLength,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? path);

	/// <summary>
	/// Gets the path of the specified staged package, with the option to specify the type of folder path to retrieve for the package.
	/// </summary>
	/// <param name="packageFullName">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The full name of the staged package.</para>
	/// </param>
	/// <param name="packagePathType">
	/// <para>Type: <c>PackagePathType</c></para>
	/// <para>Indicates the type of folder path to retrieve for the package (the original install folder or the mutable folder).</para>
	/// </param>
	/// <param name="pathLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// A pointer to a variable that holds the number of characters ( <c>WCHAR</c> s) in the package path string, which includes the null-terminator.
	/// </para>
	/// <para>
	/// First you pass <c>NULL</c> to path to get the number of characters. You use this number to allocate memory space for path. Then
	/// you pass the address of this memory space to fill path.
	/// </para>
	/// </param>
	/// <param name="path">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>A pointer to memory space that receives the package path string, which includes the null-terminator.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer specified by path is not large enough to hold the data. The required size is specified by pathLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The packagePathType parameter is useful for applications that use the windows.mutablePackageDirectories extension in their
	/// package manifest. This extension specifies a folder under the %ProgramFiles%\ModifiableWindowsApps path where the contents of
	/// the application's install folder are projected so that users can modify the installation files. This feature is currently
	/// available only for certain types of desktop PC games that are published by Microsoft and our partners, and it enables these
	/// types of games to support mods.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmodel/nf-appmodel-getstagedpackagepathbyfullname2 LONG
	// GetStagedPackagePathByFullName2( PCWSTR packageFullName, PackagePathType packagePathType, UINT32 *pathLength, PWSTR path );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h")]
	public static extern Win32Error GetStagedPackagePathByFullName2([MarshalAs(UnmanagedType.LPWStr)] string packageFullName, PackagePathType packagePathType,
		ref uint pathLength, [Optional, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? path);

	/// <summary>
	/// <para>Opens the package information of the specified package.</para>
	/// </summary>
	/// <param name="packageFullName">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The full name of the package.</para>
	/// </param>
	/// <param name="reserved">
	/// <para>Type: <c>const UINT32</c></para>
	/// <para>Reserved; must be 0.</para>
	/// </param>
	/// <param name="packageInfoReference">
	/// <para>Type: <c>PACKAGE_INFO_REFERENCE*</c></para>
	/// <para>A reference to package information.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>The package is not installed for the current user.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-openpackageinfobyfullname LONG
	// OpenPackageInfoByFullName( PCWSTR packageFullName, const UINT32 reserved, PACKAGE_INFO_REFERENCE *packageInfoReference );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "9ECFC757-1CB3-43A1-BA45-9AF72CAB240E")]
	public static extern Win32Error OpenPackageInfoByFullName([MarshalAs(UnmanagedType.LPWStr)] string packageFullName, uint reserved, ref PACKAGE_INFO_REFERENCE packageInfoReference);

	/// <summary>
	/// <para>Gets the package family name for the specified package full name.</para>
	/// </summary>
	/// <param name="packageFullName">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The full name of a package.</para>
	/// </param>
	/// <param name="packageFamilyNameLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// On input, the size of the packageFamilyName buffer, in characters. On output, the size of the package family name returned, in
	/// characters, including the null terminator.
	/// </para>
	/// </param>
	/// <param name="packageFamilyName">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>The package family name.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by packageFamilyNameLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For info about string size limits, see Identity constants.</para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-packagefamilynamefromfullname LONG
	// PackageFamilyNameFromFullName( PCWSTR packageFullName, UINT32 *packageFamilyNameLength, PWSTR packageFamilyName );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "98E95CE5-E970-4A19-BAD3-994DAEC4BEA0")]
	public static extern Win32Error PackageFamilyNameFromFullName(string packageFullName, ref uint packageFamilyNameLength,
		[Optional] StringBuilder? packageFamilyName);

	/// <summary>
	/// <para>Gets the package family name for the specified package identifier.</para>
	/// </summary>
	/// <param name="packageId">
	/// <para>Type: <c>const PACKAGE_ID*</c></para>
	/// <para>The package identifier.</para>
	/// </param>
	/// <param name="packageFamilyNameLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// On input, the size of the packageFamilyName buffer, in characters. On output, the size of the package family name returned, in
	/// characters, including the null terminator.
	/// </para>
	/// </param>
	/// <param name="packageFamilyName">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>The package family name.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by packageFamilyNameLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For info about string size limits, see Identity constants.</para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-packagefamilynamefromid LONG PackageFamilyNameFromId(
	// const PACKAGE_ID *packageId, UINT32 *packageFamilyNameLength, PWSTR packageFamilyName );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "198DAB6B-21D2-4ACB-87DF-B3F4EFBEE323")]
	public static extern Win32Error PackageFamilyNameFromId(in PACKAGE_ID packageId, ref uint packageFamilyNameLength,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? packageFamilyName);

	/// <summary>
	/// <para>Gets the package full name for the specified package identifier (ID).</para>
	/// </summary>
	/// <param name="packageId">
	/// <para>Type: <c>const PACKAGE_ID*</c></para>
	/// <para>The package ID.</para>
	/// </param>
	/// <param name="packageFullNameLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// On input, the size of the packageFullName buffer, in characters. On output, the size of the package full name returned, in
	/// characters, including the null terminator.
	/// </para>
	/// </param>
	/// <param name="packageFullName">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>The package full name.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by packageFullNameLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For info about string size limits, see Identity constants.</para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-packagefullnamefromid LONG PackageFullNameFromId( const
	// PACKAGE_ID *packageId, UINT32 *packageFullNameLength, PWSTR packageFullName );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "0024AF55-295E-49B1-90C2-9144D336529B")]
	public static extern Win32Error PackageFullNameFromId(in PACKAGE_ID packageId, ref uint packageFullNameLength,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? packageFullName);

	/// <summary>
	/// <para>Gets the package identifier (ID) for the specified package full name.</para>
	/// </summary>
	/// <param name="packageFullName">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The full name of a package.</para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>const UINT32</c></para>
	/// <para>The package constants that specify how package information is retrieved. The <c>PACKAGE_INFORMATION_*</c> flags are supported.</para>
	/// </param>
	/// <param name="bufferLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>On input, the size of buffer, in bytes. On output, the size of the data returned, in bytes.</para>
	/// </param>
	/// <param name="buffer">
	/// <para>Type: <c>BYTE*</c></para>
	/// <para>The package ID, represented as a PACKAGE_ID structure.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The buffer is not large enough to hold the data. The required size is specified by bufferLength.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>The package is not installed for the user.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If flags specifies <c>PACKAGE_INFORMATION_BASIC</c>, the following fields are retrieved:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>name</c></term>
	/// </item>
	/// <item>
	/// <term><c>processorArchitecture</c></term>
	/// </item>
	/// <item>
	/// <term><c>publisherId</c></term>
	/// </item>
	/// <item>
	/// <term><c>resourceId</c></term>
	/// </item>
	/// <item>
	/// <term><c>version</c></term>
	/// </item>
	/// </list>
	/// <para>If flags specifies <c>PACKAGE_INFORMATION_FULL</c>, the following fields are retrieved:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>name</c></term>
	/// </item>
	/// <item>
	/// <term><c>processorArchitecture</c></term>
	/// </item>
	/// <item>
	/// <term><c>publisher</c></term>
	/// </item>
	/// <item>
	/// <term><c>publisherId</c></term>
	/// </item>
	/// <item>
	/// <term><c>resourceId</c></term>
	/// </item>
	/// <item>
	/// <term><c>version</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// A request for <c>PACKAGE_INFORMATION_FULL</c> succeeds only if the package corresponding to packageFullName is installed for and
	/// accessible to the current user. If the package full name is syntactically correct but does not correspond to a package that is
	/// installed for and accessible to the current user, the function returns <c>ERROR_NOT_FOUND</c>.
	/// </para>
	/// <para>For info about string size limits, see Identity constants.</para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-packageidfromfullname LONG PackageIdFromFullName(
	// PCWSTR packageFullName, const UINT32 flags, UINT32 *bufferLength, BYTE *buffer );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "EED832F8-E4F7-4A0F-93E2-451F78F67767")]
	public static extern Win32Error PackageIdFromFullName([MarshalAs(UnmanagedType.LPWStr)] string packageFullName, PACKAGE_FLAGS flags, ref uint bufferLength, IntPtr buffer);

	/// <summary>
	/// <para>Gets the package name and publisher identifier (ID) for the specified package family name.</para>
	/// </summary>
	/// <param name="packageFamilyName">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The family name of a package.</para>
	/// </param>
	/// <param name="packageNameLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// On input, the size of the packageName buffer, in characters. On output, the size of the package name returned, in characters,
	/// including the null-terminator.
	/// </para>
	/// </param>
	/// <param name="packageName">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>The package name.</para>
	/// </param>
	/// <param name="packagePublisherIdLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// On input, the size of the packagePublishId buffer, in characters. On output, the size of the publisher ID returned, in
	/// characters, including the null-terminator.
	/// </para>
	/// </param>
	/// <param name="packagePublisherId">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>The package publisher ID.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>One of the buffers is not large enough to hold the data. The required sizes are specified by packageNameLength and packagePublisherIdLength.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For info about string size limits, see Identity constants.</para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-packagenameandpublisheridfromfamilyname LONG
	// PackageNameAndPublisherIdFromFamilyName( PCWSTR packageFamilyName, UINT32 *packageNameLength, PWSTR packageName, UINT32
	// *packagePublisherIdLength, PWSTR packagePublisherId );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "4AA5BD75-F865-40D6-9C10-E54C197D47C4")]
	public static extern Win32Error PackageNameAndPublisherIdFromFamilyName(string packageFamilyName, ref uint packageNameLength,
		[Optional] StringBuilder? packageName, ref uint packagePublisherIdLength, [Optional] StringBuilder? packagePublisherId);

	/// <summary>
	/// <para>Deconstructs an application user model ID to its package family name and package relative application ID (PRAID).</para>
	/// </summary>
	/// <param name="applicationUserModelId">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The app user model ID.</para>
	/// </param>
	/// <param name="packageFamilyNameLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// A pointer to a variable that holds the number of characters ( <c>WCHAR</c> s) in the package family name string, which includes
	/// the null-terminator.
	/// </para>
	/// <para>
	/// First you pass <c>NULL</c> to packageFamilyName to get the number of characters. You use this number to allocate memory space
	/// for packageFamilyName. Then you pass the address of this memory space to fill packageFamilyName.
	/// </para>
	/// </param>
	/// <param name="packageFamilyName">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>A pointer to memory space that receives the package family name string, which includes the null-terminator.</para>
	/// </param>
	/// <param name="packageRelativeApplicationIdLength">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>
	/// A pointer to a variable that holds the number of characters ( <c>WCHAR</c> s) in the package-relative app ID string, which
	/// includes the null-terminator.
	/// </para>
	/// <para>
	/// First you pass <c>NULL</c> to packageRelativeApplicationId to get the number of characters. You use this number to allocate
	/// memory space for packageRelativeApplicationId. Then you pass the address of this memory space to fill packageRelativeApplicationId.
	/// </para>
	/// </param>
	/// <param name="packageRelativeApplicationId">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>A pointer to memory space that receives the package-relative app ID (PRAID) string, which includes the null-terminator.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The applicationUserModelId parameter isn't valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// The buffer specified by packageFamilyName or packageRelativeApplicationId is not large enough to hold the data; the required
	/// buffer size, in WCHARs, is stored in the variable pointed to by packageFamilyNameLength or packageRelativeApplicationIdLength.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/nf-appmodel-parseapplicationusermodelid LONG
	// ParseApplicationUserModelId( PCWSTR applicationUserModelId, UINT32 *packageFamilyNameLength, PWSTR packageFamilyName, UINT32
	// *packageRelativeApplicationIdLength, PWSTR packageRelativeApplicationId );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("appmodel.h", MSDNShortId = "03B29E82-611F-47D1-8CB6-047B9BEB4D9E")]
	public static extern Win32Error ParseApplicationUserModelId(string applicationUserModelId, ref uint packageFamilyNameLength,
		[Optional] StringBuilder? packageFamilyName, ref uint packageRelativeApplicationIdLength, [Optional] StringBuilder? packageRelativeApplicationId);

	/// <summary>
	/// Removes a resolved package dependency from the current process' package graph (that is, a run-time reference for a framework
	/// package dependency that was added by using the AddPackageDependency method).
	/// </summary>
	/// <param name="packageDependencyContext">
	/// <para>Type: <c>PACKAGEDEPENDENCY_CONTEXT</c></para>
	/// <para>The handle of the package dependency to remove.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error
	/// codes include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The packageDependencyContext parameter is NULL on input.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// This function does not unload loaded resources such as DLLs. After removing a package dependency, any files loaded from the
	/// package can continue to be used. Future file resolution will fail to see the removed package dependency.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmodel/nf-appmodel-removepackagedependency HRESULT RemovePackageDependency(
	// PACKAGEDEPENDENCY_CONTEXT packageDependencyContext );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "NF:appmodel.RemovePackageDependency")]
	public static extern HRESULT RemovePackageDependency([In] PACKAGEDEPENDENCY_CONTEXT packageDependencyContext);

	/// <summary>Creates an install-time reference for a framework package dependency for the current app, using the specified package family name, minimum version, and additional criteria.</summary>
	/// <param name="user">
	/// <para>Type: <c>PSID</c></para>
	/// <para>The user scope of the package dependency. If NULL, the caller's user context is used. Must be NULL if CreatePackageDependencyOptions_ScopeIsSystem is specified.</para>
	/// </param>
	/// <param name="packageFamilyName">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The package family name of the framework package on which to take dependency.</para>
	/// </param>
	/// <param name="minVersion">
	/// <para>Type: <c>PACKAGE_VERSION</c></para>
	/// <para>The minimum version of the framework package on which to take dependency.</para>
	/// </param>
	/// <param name="packageDependencyProcessorArchitectures">
	/// <para>Type: <c>PackageDependencyProcessorArchitectures</c></para>
	/// <para>The processor architectures of the package dependency.</para>
	/// </param>
	/// <param name="lifetimeKind">
	/// <para>Type: <c>PackageDependencyLifetimeKind</c></para>
	/// <para>The type of artifact to use to define the lifetime of the package dependency. For more information, see the remarks.</para>
	/// </param>
	/// <param name="lifetimeArtifact">
	/// <para>Type: <c>PCWSTR</c></para>
	/// <para>The name of the artifact used to define the lifetime of the package dependency. Must be NULL if the lifetimeKind parameter is PackageDependencyLifetimeKind_Process. For more information, see the remarks.</para>
	/// </param>
	/// <param name="options">
	/// <para>Type: <c>CreatePackageDependencyOptions</c></para>
	/// <para>The options to apply when creating the package dependency.</para>
	/// </param>
	/// <param name="packageDependencyId">
	/// <para>Type: <c>PWSTR*</c></para>
	/// <para>The ID of the new package dependency. Use the HeapAlloc function to allocate memory for this parameter, and use HeapFree to deallocate the memory.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the function succeeds it returns <c>ERROR_SUCCESS</c>. Otherwise, the function returns an error code. The possible error codes include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The packageDependencyId parameter is NULL on input.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>In your app's installer or during the first run of your app, call this method to specify a set of criteria for a framework package you want to use in your app. This informs the OS that your app has a dependency upon a framework package that meets the specified criteria. If one or more framework packages are installed that meet the criteria, Windows will ensure that at least one of these framework packages will remain installed until the install-time reference is deleted. For more information, see Use the dynamic dependency API to reference framework packages at run time.</para>
	/// <para>This function fails if the specified dependency criteria cannot be resolved to a specific package. This package resolution check is skipped if CreatePackageDependencyOptions_DoNotVerifyDependencyResolution is specified for the options parameter. This is useful for installers running as user contexts other than the target user (for example, installers running as LocalSystem).</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmodel/nf-appmodel-trycreatepackagedependency
	// HRESULT TryCreatePackageDependency( PSID user, PCWSTR packageFamilyName, PACKAGE_VERSION minVersion, PackageDependencyProcessorArchitectures packageDependencyProcessorArchitectures, PackageDependencyLifetimeKind lifetimeKind, PCWSTR lifetimeArtifact, CreatePackageDependencyOptions options, PWSTR *packageDependencyId );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmodel.h", MSDNShortId = "NF:appmodel.TryCreatePackageDependency")]
	public static extern HRESULT TryCreatePackageDependency([In, Optional] PSID user, [MarshalAs(UnmanagedType.LPWStr)] string packageFamilyName,
		PACKAGE_VERSION minVersion, PackageDependencyProcessorArchitectures packageDependencyProcessorArchitectures,
		PackageDependencyLifetimeKind lifetimeKind, [MarshalAs(UnmanagedType.LPWStr)] string lifetimeArtifact,
		CreatePackageDependencyOptions options, out SafeHeapBlock packageDependencyId);

	/// <summary>
	/// <para>Represents package identification information, such as name, version, and publisher.</para>
	/// </summary>
	/// <remarks>
	/// <para>For info about string size limits, see Identity constants.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/ns-appmodel-package_id typedef struct PACKAGE_ID { UINT32 reserved;
	// UINT32 processorArchitecture; PACKAGE_VERSION version; PWSTR name; PWSTR publisher; PWSTR resourceId; PWSTR publisherId; };
	[PInvokeData("appmodel.h", MSDNShortId = "4B15281A-2227-47B7-A750-0A01DB8543FC")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PACKAGE_ID
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Reserved; do not use.</para>
		/// </summary>
		public uint reserved;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The processor architecture of the package. This member must be one of the values of the APPX_PACKAGE_ARCHITECTURE enumeration.
		/// </para>
		/// </summary>
		public APPX_PACKAGE_ARCHITECTURE processorArchitecture;

		/// <summary>
		/// <para>Type: <c>PACKAGE_VERSION</c></para>
		/// <para>The version of the package.</para>
		/// </summary>
		public PACKAGE_VERSION version;

		/// <summary>
		/// <para>Type: <c>PWSTR</c></para>
		/// <para>The name of the package.</para>
		/// </summary>
		public string name;

		/// <summary>
		/// <para>Type: <c>PWSTR</c></para>
		/// <para>The publisher of the package. If there is no publisher for the package, this member is <c>NULL</c>.</para>
		/// </summary>
		public string publisher;

		/// <summary>
		/// <para>Type: <c>PWSTR</c></para>
		/// <para>The resource identifier (ID) of the package. If there is no resource ID for the package, this member is <c>NULL</c>.</para>
		/// </summary>
		public string resourceId;

		/// <summary>
		/// <para>Type: <c>PWSTR</c></para>
		/// <para>The publisher identifier (ID) of the package. If there is no publisher ID for the package, this member is <c>NULL</c>.</para>
		/// </summary>
		public string publisherId;
	}

	/// <summary>Represents package identification information that includes the package identifier, full name, and install location.</summary>
	/// <remarks>For info about string size limits, see Identity constants.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/appmodel/ns-appmodel-package_info typedef struct PACKAGE_INFO { UINT32
	// reserved; UINT32 flags; PWSTR path; PWSTR packageFullName; PWSTR packageFamilyName; PACKAGE_ID packageId; } PACKAGE_INFO;
	[PInvokeData("appmodel.h", MSDNShortId = "0DDE00D1-9C5F-4F2B-8110-A92B1FFA1B64")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PACKAGE_INFO
	{
		/// <summary>Reserved; do not use.</summary>
		public uint reserved;

		/// <summary>Properties of the package.</summary>
		public uint flags;

		/// <summary>The location of the package.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string path;

		/// <summary>The package full name/</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string packageFullName;

		/// <summary>The package family name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string packageFamilyName;

		/// <summary>The package identifier (ID).</summary>
		public PACKAGE_ID packageId;
	}

	/// <summary>A reference to package information.</summary>
	[PInvokeData("appmodel.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PACKAGE_INFO_REFERENCE
	{
		/// <summary>Reserved.</summary>
		public IntPtr reserved;
	}

	/// <summary>
	/// <para>Represents the package version information.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmodel/ns-appmodel-package_version typedef struct PACKAGE_VERSION { union
	// { UINT64 Version; struct { USHORT Revision; USHORT Build; USHORT Minor; USHORT Major; } DUMMYSTRUCTNAME; } DUMMYUNIONNAME; };
	[PInvokeData("appmodel.h", MSDNShortId = "8543DF84-A908-4DF5-AEE6-169FECB2AA97")]
	[StructLayout(LayoutKind.Explicit)]
	public struct PACKAGE_VERSION
	{
		/// <summary>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>The full version number of the package represented as a single integral value.</para>
		/// </summary>
		[FieldOffset(0)]
		public ulong Version;

		/// <summary>Parts of the Version.</summary>
		[FieldOffset(0)]
		public DUMMYSTRUCTNAME Parts;

		/// <summary>Parts of the Version.</summary>
		public struct DUMMYSTRUCTNAME
		{
			/// <summary>
			/// <para>Type: <c>USHORT</c></para>
			/// <para>The revision version number of the package.</para>
			/// </summary>
			public ushort Revision;

			/// <summary>
			/// <para>Type: <c>USHORT</c></para>
			/// <para>The build version number of the package.</para>
			/// </summary>
			public ushort Build;

			/// <summary>
			/// <para>Type: <c>USHORT</c></para>
			/// <para>The minor version number of the package.</para>
			/// </summary>
			public ushort Minor;

			/// <summary>
			/// <para>Type: <c>USHORT</c></para>
			/// <para>The major version number of the package.</para>
			/// </summary>
			public ushort Major;
		}
	}
}