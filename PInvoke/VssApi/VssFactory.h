#pragma once
#include "pch.h"
#include "vswriter.h"
#include "vsbackup.h"

using namespace System;
using namespace Runtime::InteropServices;

namespace Vanara { namespace PInvoke { namespace VssApi {

	public ref class VssFactory sealed
	{
	public:
		/// <summary>The <c>CreateVssExamineWriterMetadata</c> function creates an IVssExamineWriterMetadata object.</summary>
		/// <param name="bstrXML">
		/// An XML string containing a Writer Metadata Document with which to initialize the returned IVssExamineWriterMetadata object.
		/// </param>
		/// <param name="ppMetadata">A variable that receives an IVssExamineWriterMetadata interface pointer to the object.</param>
		/// <returns>
		/// <para>The return values listed here are in addition to the normal COM HRESULTs that may be returned at any time from the function.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Successfully returned a pointer to an IVssExamineWriterMetadata interface.</term>
		/// </item>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term>VSS_E_INVALID_XML_DOCUMENT</term>
		/// <term>
		/// The XML document passed in the bstrXML parameter is not valid—that is, either it is not a correctly formed XML string or it does
		/// not match the schema.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VSS_E_UNEXPECTED</term>
		/// <term>
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows Server 2008 R2
		/// and Windows 7. E_UNEXPECTED is used instead.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To save a copy of a writer’s Writer Metadata Document into an XML string to pass in the bstrXML parameter, use the
		/// IVssExamineWriterMetadata::SaveAsXML method.
		/// </para>
		/// <para>
		/// To retrieve the latest version of a writer’s Writer Metadata Document, use the IVssBackupComponents::GetWriterMetadata method.
		/// </para>
		/// <para>
		/// To load a writer metadata document into an existing IVssExamineWriterMetadata object, use the
		/// IVssExamineWriterMetadata::LoadFromXML method.
		/// </para>
		/// <para>Users should not attempt to modify the contents of the Writer Metadata Document.</para>
		/// <para>
		/// The calling application is responsible for calling IUnknown::Release to release the resources held by the
		/// IVssExamineWriterMetadata object when the object is no longer needed.
		/// </para>
		/// </remarks>
		[PInvokeData("vsbackup.h", MSDNShortId = "NF:vsbackup.CreateVssExamineWriterMetadata")]
		static HRESULT CreateVssExamineWriterMetadata(String^ bstrXML, [Runtime::InteropServices::Out] Vanara::PInvoke::VssApi::IVssExamineWriterMetadata^% ppMetadata);

		/// <summary>Creates an IVssExpressWriter interface object and returns a pointer to it.</summary>
		/// <param name="ppWriter">Doubly indirect pointer to the newly created IVssExpressWriter object.</param>
		/// <returns>
		/// <para>
		/// The return values listed here are in addition to the normal COM HRESULT values that may be returned at any time from the function.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Successfully returned a pointer to an IVssExpressWriter interface.</term>
		/// </item>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>The caller does not have sufficient privileges.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vswriter/nf-vswriter-createvssexpresswriter HRESULT CreateVssExpressWriter(
		// [out] IVssExpressWriter **ppWriter );
		[PInvokeData("vswriter.h", MSDNShortId = "NF:vswriter.CreateVssExpressWriter")]
		static HRESULT CreateVssExpressWriter([Runtime::InteropServices::Out] Vanara::PInvoke::VssApi::IVssExpressWriter^% ppWriter);

		/// <summary>
		/// <para>
		/// The <c>CreateVssBackupComponents</c> function creates an IVssBackupComponents interface object and returns a pointer to it.
		/// </para>
		/// </summary>
		/// <param name="ppBackup">Doubly indirect pointer to the created IVssBackupComponents interface object.</param>
		/// <returns>
		/// <para>
		/// The return values listed here are in addition to the normal COM <c>HRESULT</c> s that may be returned at any time from the function.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Successfully returned a pointer to an IVssBackupComponents interface.</term>
		/// </item>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>The caller does not have sufficient backup privileges or is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Out of memory or other system resources.</term>
		/// </item>
		/// <item>
		/// <term>VSS_E_UNEXPECTED</term>
		/// <term>
		/// Unexpected error. The error code is logged in the error log file. For more information, see Event and Error Handling Under VSS.
		/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows Server 2008 R2
		/// and Windows 7. E_UNEXPECTED is used instead.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The calling application is responsible for calling IUnknown::Release to release the resources held by the returned
		/// IVssBackupComponents when it is no longer needed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsbackup/nf-vsbackup-createvssbackupcomponents HRESULT
		// CreateVssBackupComponents( [out] IVssBackupComponents **ppBackup);
		[PInvokeData("vsbackup.h", MSDNShortId = "NF:vsbackup.CreateVssBackupComponents")]
		static HRESULT CreateVssBackupComponents([Runtime::InteropServices::Out] Vanara::PInvoke::VssApi::IVssBackupComponents^% ppBackup);
	};
}}}
