#include "pch.h"
#include "VssFactory.h"

using namespace System;
using namespace Runtime::InteropServices;

namespace Vanara { namespace PInvoke { namespace VssApi {

	HRESULT Vanara::PInvoke::VssApi::VssFactory::CreateVssBackupComponents(Vanara::PInvoke::VssApi::IVssBackupComponents^% ppBackup)
	{
		SafeComPtr<::IVssBackupComponents*> pBC;
		auto hr = ::CreateVssBackupComponents(&pBC);
		ppBackup = hr >= 0 ? gcnew Vanara::PInvoke::VssApi::CVssBackupComponents(pBC) : nullptr;
		return HRESULT(hr);
	}

	HRESULT Vanara::PInvoke::VssApi::VssFactory::CreateVssExamineWriterMetadata(String^ bstrXML, Vanara::PInvoke::VssApi::IVssExamineWriterMetadata^% ppMetadata)
	{
		SafeBSTR bstr = (BSTR)Marshal::StringToBSTR(bstrXML).ToPointer();
		SafeComPtr<::IVssExamineWriterMetadata*> pMeta;
		auto hr = ::CreateVssExamineWriterMetadata(bstr, &pMeta);
		ppMetadata = hr >= 0 ? gcnew Vanara::PInvoke::VssApi::CVssExamineWriterMetadata(pMeta) : nullptr;
		return HRESULT(hr);
	}

	HRESULT Vanara::PInvoke::VssApi::VssFactory::CreateVssExpressWriter(Vanara::PInvoke::VssApi::IVssExpressWriter^% ppWriter)
	{
		SafeComPtr<::IVssExpressWriter*> pWriter;
		auto hr = ::CreateVssExpressWriter(&pWriter);
		ppWriter = hr >= 0 ? gcnew Vanara::PInvoke::VssApi::CVssExpressWriter(pWriter) : nullptr;
		return HRESULT(hr);
	}

}}}
