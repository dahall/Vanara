using NUnit.Framework;
using NUnit.Framework.Internal;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.WsmSvc;

namespace Vanara.PInvoke.Tests;

public class ShellClient : IDisposable
{
	private SafeWSMAN_API_HANDLE m_apiHandle;
	private WSMAN_SHELL_ASYNC m_async;
	private bool m_bExecute;
	private bool m_bSetup;
	private WSMAN_COMMAND_HANDLE m_command;
	private Win32Error m_errorCode;
	private SafeEventHandle m_event;
	private WSMAN_SHELL_ASYNC m_ReceiveAsync;
	private Win32Error m_ReceiveErrorCode;
	private SafeEventHandle m_ReceiveEvent;
	private SafeWSMAN_SESSION_HANDLE m_session;
	private WSMAN_SHELL_HANDLE m_shell;

	// Constructor.
	public ShellClient()
	{
	}

	// Clean up the used resources
	public void Dispose()
	{
		if (!m_command.IsNull)
		{
			WSManCloseCommand(m_command, 0, m_async);
			WaitForSingleObject(m_event, INFINITE);
			if (Win32Error.NO_ERROR != m_errorCode)
			{
				wprintf("WSManCloseCommand failed: {0}\n", m_errorCode);
			}
			else
			{
				m_command = default;
			}
		}

		if (!m_shell.IsNull)
		{
			WSManCloseShell(m_shell, 0, m_async);
			WaitForSingleObject(m_event, INFINITE);
			if (Win32Error.NO_ERROR != m_errorCode)
			{
				wprintf("WSManCloseShell failed: {0}\n", m_errorCode);
			}
			else
			{
				m_shell = default;
			}
		}

		// Frees memory of session and closes all related operations before returning
		m_session?.Dispose();

		// deinitializes the Winrm client stack; all operations will finish before this API will return
		m_apiHandle?.Dispose();

		m_event?.Dispose();
		m_ReceiveEvent?.Dispose();

		m_bSetup = false;
		m_bExecute = false;
	}

	// Execute shell-related operations
	public bool Execute(string resourceUri, string commandLine, byte[] sendData, uint count)
	{
		if (!m_bSetup)
		{
			wprintf("Setup() needs to be called first");
			return false;
		}
		if (m_bExecute)
		{
			wprintf("Execute() can only be called once");
			return false;
		}
		m_bExecute = true;

		// WSManCreateShell
		WSManCreateShell(m_session, 0, resourceUri, default, default, default, m_async, out m_shell);
		WaitForSingleObject(m_event, INFINITE);
		if (Win32Error.NO_ERROR != m_errorCode)
		{
			wprintf("WSManCreateShell failed: {0}\n", m_errorCode);
			return false;
		}

		// WSManRunShellCommand
		WSManRunShellCommand(m_shell, 0, commandLine, default, default, m_async, out m_command);
		WaitForSingleObject(m_event, INFINITE);
		if (Win32Error.NO_ERROR != m_errorCode)
		{
			wprintf("WSManRunShellCommand failed: {0}\n", m_errorCode);
			return false;
		}

		// WSManReceiveShellOutput
		WSManReceiveShellOutput(m_shell, m_command, 0, default, m_ReceiveAsync, out SafeWSMAN_OPERATION_HANDLE receiveOperation);

		// Send operation can be executed many times to send large data
		if (count >= 1)
		{
			for (uint i = 1; i <= count; i++)
			{
				// last send operation should indicate end of stream
				if (!Send(sendData, (i == count)))
				{
					wprintf("Send {0} failed.\n", i);
				}
			}
		}

		// Receive operation is finished
		WaitForSingleObject(m_ReceiveEvent, INFINITE);
		if (Win32Error.NO_ERROR != m_ReceiveErrorCode)
		{
			wprintf("WSManReceiveShellOutput failed: {0}\n", m_ReceiveErrorCode);
			return false;
		}
		receiveOperation.Dispose();

		return true;
	}

	// Initialize session for subsequent operations
	public bool Setup(string connection, WSManAuthenticationFlags authenticationMechanism, string username, string password)
	{
		if (m_bSetup) return true;

		// initialize the WinRM client
		m_errorCode = WSManInitialize(0, out m_apiHandle);
		if (Win32Error.NO_ERROR != m_errorCode)
		{
			wprintf("WSManInitialize failed: {0}\n", m_errorCode);
			return false;
		}

		// Create a session which can be used to perform subsequent operations
		var serverAuthenticationCredentials = new SafeCoTaskMemStruct<WSMAN_AUTHENTICATION_CREDENTIALS>(new WSMAN_AUTHENTICATION_CREDENTIALS
		{
			authenticationMechanism = authenticationMechanism,
			userAccount = new WSMAN_USERNAME_PASSWORD_CREDS
			{
				username = username,
				password = password
			}
		});
		m_errorCode = WSManCreateSession(m_apiHandle, connection, 0, serverAuthenticationCredentials, default, out m_session);
		if (Win32Error.NO_ERROR != m_errorCode)
		{
			wprintf("WSManCreateSession failed: {0}\n", m_errorCode);
			return false;
		}

		// Repeat the call to set any desired session options
		WSManSessionOption option = WSManSessionOption.WSMAN_OPTION_DEFAULT_OPERATION_TIMEOUTMS;
		var data = new WSMAN_DATA
		{
			type = WSManDataType.WSMAN_DATA_TYPE_DWORD,
			union = new WSMAN_DATA.WSMAN_DATA_UNION { number = 60000 }
		};
		m_errorCode = WSManSetSessionOption(m_session, option, data);
		if (Win32Error.NO_ERROR != m_errorCode)
		{
			wprintf("WSManSetSessionOption failed: {0}\n", m_errorCode);
			return false;
		}

		// Prepare async call
		m_event = CreateEvent(default, false, false, default);
		if (m_event.IsInvalid)
		{
			m_errorCode = Win32Error.GetLastError();
			wprintf("CreateEvent failed: {0}\n", m_errorCode);
			return false;
		}

		m_async = new WSMAN_SHELL_ASYNC
		{
			operationContext = default,
			completionFunction = m_WSManShellCompletionFunction
		};

		m_ReceiveEvent = CreateEvent(default, false, false, default);
		if (m_ReceiveEvent.IsInvalid)
		{
			m_errorCode = Win32Error.GetLastError();
			wprintf("CreateEvent failed: {0}\n", m_errorCode);
			return false;
		}
		m_ReceiveAsync = new WSMAN_SHELL_ASYNC
		{
			operationContext = default,
			completionFunction = m_ReceiveCallback
		};

		m_bSetup = true;

		return true;
	}

	// Receive async callback
	private void m_ReceiveCallback(IntPtr operationContext, WSManCallbackFlags flags, in WSMAN_ERROR error,
		WSMAN_SHELL_HANDLE shell, WSMAN_COMMAND_HANDLE command, WSMAN_OPERATION_HANDLE operationHandle, IntPtr pdata)
	{
		if (0 != error.code)
		{
			m_ReceiveErrorCode = error.code;
			// NOTE: if the errorDetail needs to be used outside of the callback, then need to allocate memory, copy the content to that
			// memory as error.errorDetail itself is owned by WSMan client stack and will be deallocated and invalid when the callback exits
			wprintf(error.errorDetail);
		}

		// Output the received data to the console
		WSMAN_RECEIVE_DATA_RESULT data = pdata.ToStructure<WSMAN_RECEIVE_DATA_RESULT>();
		if (pdata != default)
		{
			if (data.streamData.type == WSManDataType.WSMAN_DATA_TYPE_BINARY && data.streamData.union.binaryData.dataLength != 0)
			{
				HFILE hFile = ((0 == string.Compare(data.streamId, WSMAN_STREAM_ID_STDERR)) ? GetStdHandle(StdHandleType.STD_ERROR_HANDLE) : GetStdHandle(StdHandleType.STD_OUTPUT_HANDLE));
				WriteFile(hFile, data.streamData.union.binaryData.data, data.streamData.union.binaryData.dataLength, out _);
			}
		}

		// for WSManReceiveShellOutput, needs to wait for state to be done before signalliing the end of the operation
		if ((0 != error.code) || (pdata != default && !data.commandState.IsNull && string.Compare(data.commandState, WSMAN_COMMAND_STATE_DONE) == 0))
		{
			SetEvent(m_ReceiveEvent);
		}
	}

	// async callback
	private void m_WSManShellCompletionFunction(IntPtr operationContext, WSManCallbackFlags flags, in WSMAN_ERROR error,
		WSMAN_SHELL_HANDLE shell, WSMAN_COMMAND_HANDLE command, WSMAN_OPERATION_HANDLE operationHandle, IntPtr data)
	{
		if (0 != error.code)
		{
			m_errorCode = error.code;
			// NOTE: if the errorDetail needs to be used outside of the callback, then need to allocate memory, copy the content to that
			// memory as error->errorDetail itself is owned by WSMan client stack and will be deallocated and invalid when the callback exits
			wprintf(error.errorDetail);
		}

		// for non-receieve operation, the callback simply signals the async operation is finished
		SetEvent(m_event);
	}

	private bool Send(byte[] sendData, bool endOfStream)
	{
		// WSManSendShellInput
		var streamData = new WSMAN_DATA
		{
			type = WSManDataType.WSMAN_DATA_TYPE_BINARY
		};

		using var pSendData = new PinnedObject(sendData);
		if (sendData != null && sendData.Length > 0)
		{
			streamData.union.binaryData.dataLength = (uint)sendData.Length;
			streamData.union.binaryData.data = pSendData;
		}
		WSManSendShellInput(m_shell, m_command, 0, WSMAN_STREAM_ID_STDIN, streamData, endOfStream, m_async, out SafeWSMAN_OPERATION_HANDLE sendOperation);
		WaitForSingleObject(m_event, INFINITE);
		if (Win32Error.NO_ERROR != m_errorCode)
		{
			wprintf("WSManSendShellInput failed: {0}\n", m_errorCode);
			return false;
		}
		sendOperation.Dispose();

		return true;
	}

	private void wprintf(string fmt, params object[] p) => TestContext.Write(fmt, p);
}

[TestFixture]
public class WsmSvcTests
{
	[OneTimeSetUp]
	public void _Setup()
	{
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void Test()
	{
		using var cli = new ShellClient();
		cli.Setup("http://fqdn.domain.com", WSManAuthenticationFlags.WSMAN_FLAG_NO_AUTHENTICATION, null, null);
		cli.Execute("http://schemas.microsoft.com/wbem/wsman/1/windows/shell/cmd", "dir", null, 1);
	}
}