using System.Threading;
using System.Threading.Tasks;
using Vanara.PInvoke.VssApi;

namespace Vanara.PInvoke.Tests;

/// <summary>Provides extension methods for working with asynchronous VSS (Volume Shadow Copy Service) operations.</summary>
/// <remarks>
/// The methods in this class enable integration of legacy IVssAsync-based asynchronous operations with modern Task-based asynchronous
/// patterns. These extensions simplify the process of awaiting VSS operations and handling cancellation in .NET applications.
/// </remarks>
public static class VssAsyncExtensions
{
	/// <summary>
	/// Creates a Task that represents the completion of the specified IVssAsync operation, enabling integration with the Task-based
	/// asynchronous pattern.
	/// </summary>
	/// <remarks>
	/// This method bridges the event-based asynchronous pattern used by IVssAsync with the Task-based asynchronous pattern. The returned
	/// Task will complete successfully when the underlying operation finishes, will be canceled if the cancellation token is triggered and
	/// the operation supports cancellation, or will fault if the operation encounters an error. Callers can use standard Task-based
	/// continuations and exception handling to observe the result.
	/// </remarks>
	/// <param name="vssAsync">The IVssAsync operation to monitor for completion.</param>
	/// <param name="cancellationToken">
	/// A CancellationToken that can be used to cancel the asynchronous operation. The default value is None.
	/// </param>
	/// <returns>A Task that completes when the IVssAsync operation finishes, is canceled, or encounters an error.</returns>
	public static Task AsTask(this IVssAsync vssAsync, CancellationToken cancellationToken = default)
	{
		// Use TaskCompletionSource to bridge the event-based VSS async to a modern Task.
		TaskCompletionSource<HRESULT> tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);

		// Register for cancellation
		CancellationTokenRegistration registration = default;
		if (cancellationToken.CanBeCanceled)
		{
			registration = cancellationToken.Register(() =>
			{
				// Attempt to cancel the underlying VSS operation if the token is cancelled.
				var hr = vssAsync.Cancel();
				if (hr.Succeeded)
					tcs.TrySetCanceled(cancellationToken);
				else
					tcs.TrySetException(hr.GetException()!);
			});
		}

		// IVssAsync doesn't have a direct callback mechanism that easily integrates, so polling or a wait handle is the common approach.
		// We'll use a loop in a Task.Run to periodically check the status.
		var pollingTask = Task.Run(async () =>
		{
			try
			{
				while (true)
				{
					// Check for cancellation requested by the token while polling
					cancellationToken.ThrowIfCancellationRequested();

					var hr = vssAsync.QueryStatus(out var hrStatus);

					// Check the HRESULT of GetStatus call itself
					if (hr.Failed)
					{
						tcs.TrySetException(hr.GetException()!);
						return;
					}

					switch ((VSS_ERROR)(int)hrStatus)
					{
						case 0:
						case VSS_ERROR.VSS_S_ASYNC_FINISHED:
							tcs.TrySetResult(HRESULT.S_OK);
							return;
						case VSS_ERROR.VSS_S_ASYNC_PENDING:
							break;
						case VSS_ERROR.VSS_S_ASYNC_CANCELLED:
							tcs.TrySetCanceled(cancellationToken);
							return;
						default:
							// Some other HRESULT means a failure occurred during the VSS operation.
							tcs.TrySetException(hrStatus.GetException()!);
							return;
					}

					// If pending, wait for a short period before polling again.
					await Task.Delay(200, cancellationToken);
				}
			}
			catch (OperationCanceledException)
			{
				tcs.TrySetCanceled(cancellationToken);
			}
			catch (Exception ex)
			{
				tcs.TrySetException(ex);
			}
			finally
			{
				// Clean up the cancellation registration when the task finishes.
				await registration.DisposeAsync();
			}
		}, CancellationToken.None); // The polling task manages its own cancellation internally.

		// Return the Task from the TaskCompletionSource
		return tcs.Task;
	}
}