using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Vanara.Windows.Shell
{
	internal static class TaskAgg
	{
		public static Task CompletedTask
		{
			get
			{
#if NET20 || NET35 || NET40 || NET45
				return TaskExEx.CompletedTask;
#else
				return Task.CompletedTask;
#endif
			}
		}

		public static Task Run(Action action, CancellationToken cancellationToken)
		{
#if NET20 || NET35 || NET40
			return TaskEx.Run(action, cancellationToken);
#else
			return Task.Run(action, cancellationToken);
#endif
		}

		public static Task<T> Run<T>(Func<T> action, CancellationToken cancellationToken)
		{
#if NET20 || NET35 || NET40
			return TaskEx.Run(action, cancellationToken);
#else
			return Task.Run(action, cancellationToken);
#endif
		}

		public static Task WhenAll(IEnumerable<Task> tasks)
		{
#if NET20 || NET35 || NET40
			return TaskEx.WhenAll(tasks);
#else
			return Task.WhenAll(tasks);
#endif
		}
	}
}