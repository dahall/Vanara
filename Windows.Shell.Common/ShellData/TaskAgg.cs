using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Vanara.Windows.Shell
{
	internal static class TaskAgg
	{
		public static Task CompletedTask => Task.CompletedTask;

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
}