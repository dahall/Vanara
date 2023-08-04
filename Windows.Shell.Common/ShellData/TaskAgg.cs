using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Vanara.Windows.Shell;

internal static class TaskAgg
{
#if !(NET46_OR_GREATER || NETSTANDARD1_2_OR_GREATER || NETCOREAPP)
	private static Task _completedTask;
#endif
	public static Task CompletedTask
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
#if NET46_OR_GREATER || NETSTANDARD1_2_OR_GREATER || NETCOREAPP
			return Task.CompletedTask;
#else
			return _completedTask ??= FromResult(false);
#endif
		}
	}

	public static Task<TResult> FromResult<TResult>(TResult result)
	{
#if NET45_OR_GREATER || NETSTANDARD || NETCOREAPP
		return Task.FromResult(result);
#else
		var completionSource = new TaskCompletionSource<TResult>();
		completionSource.TrySetResult(result);
		return completionSource.Task;
#endif
	}

	public static Task Run(Action action, CancellationToken cancellationToken)
	{
		return Task.Run(action, cancellationToken);
	}

	public static Task<T> Run<T>(Func<T> action, CancellationToken cancellationToken)
	{
		return Task.Run(action, cancellationToken);
	}

	public static Task WhenAll(IEnumerable<Task> tasks)
	{
		return Task.WhenAll(tasks);
	}
}