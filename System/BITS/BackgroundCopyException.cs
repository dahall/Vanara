using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.BITS;

namespace Vanara.IO
{
	/// <summary>Exceptions specific to BITS</summary>
	public class BackgroundCopyException : Exception
	{
		private HRESULT code;
		private BG_ERROR_CONTEXT ctx;
		private SafeCoTaskMemString ctxDesc, protocol;
		private string errDesc;
		private IBackgroundCopyFile iVal;

		internal BackgroundCopyException(IBackgroundCopyError err)
		{
			const uint lang = 0x1; // LANG_NEUTRAL, SUBLANG_DEFAULT
			err.GetError(out ctx, out code);
			try { ctxDesc = err.GetErrorContextDescription(lang); }
			catch { ctxDesc = SafeCoTaskMemString.Null; }
			try { errDesc = err.GetErrorDescription(lang); }
			catch { errDesc = SafeCoTaskMemString.Null; }
			try { protocol = err.GetProtocol(); }
			catch { protocol = SafeCoTaskMemString.Null; }
			iVal = err.GetFile();
		}

		internal BackgroundCopyException(COMException cex)
		{
			code = cex.ErrorCode;
			errDesc = BackgroundCopyManager.GetErrorMessage(code);
			if (errDesc == null)
				code.ThrowIfFailed();
		}

		/// <summary>Context in which the error occurred.</summary>
		public BackgroundCopyErrorContext Context => (BackgroundCopyErrorContext)ctx;

		/// <summary>Description of the context in which the error occurred.</summary>
		public string ContextDescription => ctxDesc;

		/// <summary>Gets the error code.</summary>
		/// <value>The error code.</value>
		public HRESULT ErrorCode => code;

		/// <summary>If error was related to a file, returns information about the file and its progress. Otherwise, returns NULL.</summary>
		public BackgroundCopyFileInfo File
		{
			get { if (iVal == null) return null; return new BackgroundCopyFileInfo(iVal); }
		}

		/// <summary>The error text associated with the error.</summary>
		public override string Message => errDesc;

		/// <summary>
		/// Contains the protocol used to transfer the file. The string contains "http" for the HTTP protocol and "file" for the SMB protocol and to NULL if the
		/// error is not related to the transfer protocol.
		/// </summary>
		public string Protocol => protocol;
	}
}