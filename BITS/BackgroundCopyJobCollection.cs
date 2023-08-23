using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.BITS;

namespace Vanara.IO;

/// <summary>Manages the set of jobs for the background copy service (BITS).</summary>
public class BackgroundCopyJobCollection : ICollection<BackgroundCopyJob>
{
	internal BackgroundCopyJobCollection()
	{
	}

	/// <summary>Gets the number of jobs currently managed by BITS.</summary>
	public int Count
	{
		get
		{
			try
			{
				var ienum = BackgroundCopyManager.EnumJobs((BG_JOB_ENUM)JobListRights);
				return (int)ienum.GetCount();
			}
			catch (COMException cex)
			{
				throw new BackgroundCopyException(cex);
			}
		}
	}

	/// <summary>Gets a value indicating whether the <see cref="ICollection{T}"/> is read-only.</summary>
	bool ICollection<BackgroundCopyJob>.IsReadOnly => false;

	/// <summary>Gets the correct flag for enumerating jobs based on whether user has administrator rights.</summary>
	private uint JobListRights => BackgroundCopyManager.IsCurrentUserAdministrator() ? 1u : 0u;

	/// <summary>Gets the <see cref="BackgroundCopyJob"/> object with the specified job identifier.</summary>
	/// <param name="jobId">Unique identifier of the job.</param>
	/// <returns>The referenced <see cref="BackgroundCopyJob"/> object if found, <see langword="null"/> if not.</returns>
	public BackgroundCopyJob this[Guid jobId]
	{
		get
		{
			var job = BackgroundCopyManager.GetJob(jobId);
			return job is not null ? new BackgroundCopyJob(job) : throw new KeyNotFoundException();
		}
	}

	/// <summary>Gets the first <see cref="BackgroundCopyJob"/> object with the specified display name.</summary>
	/// <param name="displayName">The display name of the job.</param>
	/// <returns>The referenced <see cref="BackgroundCopyJob"/> object if found, <see langword="null"/> if not.</returns>
	public BackgroundCopyJob? this[string displayName]
	{
		get
		{
			var ijobs = BackgroundCopyManager.EnumJobs((BG_JOB_ENUM)JobListRights);
			IBackgroundCopyJob[] jobs;
			while ((jobs = ijobs.Next(1)).Length == 1)
				if (jobs[0].GetDisplayName() == displayName)
					return new(jobs[0]);
			return null;
		}
	}

	/// <summary>Creates a new upload or download transfer job.</summary>
	/// <param name="displayName">Name of the job.</param>
	/// <param name="description">Description of the job.</param>
	/// <param name="jobType">Type (upload or download) of the job.</param>
	/// <returns>The new <see cref="BackgroundCopyJob"/>.</returns>
	public BackgroundCopyJob Add(string displayName, string description = "", BackgroundCopyJobType jobType = BackgroundCopyJobType.Download)
	{
		try
		{
			var job = new BackgroundCopyJob(BackgroundCopyManager.CreateJob(displayName, (BG_JOB_TYPE)jobType));
			if (!string.IsNullOrEmpty(description))
				job.Description = description;
			return job;
		}
		catch (COMException cex)
		{
			throw new BackgroundCopyException(cex);
		}
	}

	/// <summary>Removes all items from the <see cref="ICollection{T}"/>.</summary>
	public void Clear()
	{
		foreach (var i in this)
			Remove(i);
	}

	/// <summary>Determines whether the <see cref="ICollection{T}"/> contains a specific value.</summary>
	/// <param name="jobId">The object to locate in the <see cref="ICollection{T}"/>.</param>
	/// <returns>true if <paramref name="jobId"/> is found in the <see cref="ICollection{T}"/>; otherwise, false.</returns>
	public bool Contains(Guid jobId)
	{
		try
		{
			var ijob = BackgroundCopyManager.GetJob(jobId);
			return ijob is not null;
		}
		catch
		{
			return false;
		}
	}

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>A <see cref="IEnumerator{T}"/> that can be used to iterate through the collection.</returns>
	public IEnumerator<BackgroundCopyJob> GetEnumerator()
	{
		var ienum = BackgroundCopyManager.EnumJobs((BG_JOB_ENUM)JobListRights);
		return new Enumerator(ienum);
	}

	/// <summary> Removes the first occurrence of a specific object from the <see cref="ICollection{T}" />. </summary> <param name="item">The object to
	/// remove from the <see cref="ICollection{T}" />.</param> <returns> true if <paramref name="item" /> was successfully removed from the <see
	/// cref="ICollection{T}" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see
	/// cref="ICollection{T}" />. </returns> <exception cref="ArgumentNullException">item</exception>
	public bool Remove(BackgroundCopyJob item)
	{
		if (item is null) throw new ArgumentNullException(nameof(item));
		// TODO: Look at what needs to be done to really remove a job and all it's actions
		try { item.Cancel(); return true; } catch { return false; }
	}

	/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
	/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
	public override string ToString() => $"Jobs: {Count}";

	/// <summary>Adds an item to the <see cref="ICollection{T}" />.</summary> <param name="item">The object to add to the <see cref="ICollection{T}" />.</param>
	void ICollection<BackgroundCopyJob>.Add(BackgroundCopyJob item)
	{
	}

	/// <summary>Determines whether the <see cref="ICollection{T}"/> contains a specific value.</summary>
	/// <param name="item">The object to locate in the <see cref="ICollection{T}"/>.</param>
	/// <returns>true if <paramref name="item"/> is found in the <see cref="ICollection{T}"/>; otherwise, false.</returns>
	/// <exception cref="NotImplementedException"></exception>
	bool ICollection<BackgroundCopyJob>.Contains(BackgroundCopyJob item) => Contains(item.ID);

	/// <summary> Copies the elements of the <see cref="ICollection{T}" /> to an <see cref="Array" />, starting at a particular <see cref="Array" /> index.
	/// </summary> <param name="array">The one-dimensional <see cref="Array" /> that is the destination of the elements copied from <see
	/// cref="ICollection{T}" />. The <see cref="Array" /> must have zero-based indexing.</param> <param name="arrayIndex">The zero-based index in <paramref
	/// name="array" /> at which copying begins.</param> <exception cref="NotImplementedException"></exception>
	void ICollection<BackgroundCopyJob>.CopyTo(BackgroundCopyJob[] array, int arrayIndex)
	{
		var ijobs = BackgroundCopyManager.EnumJobs((BG_JOB_ENUM)JobListRights);
		var cnt = ijobs.GetCount();
		Array.Copy(Array.ConvertAll(ijobs.Next(cnt), i => new BackgroundCopyJob(i)), 0, array, arrayIndex, cnt);
	}

	/// <summary>Returns an enumerator that iterates through a collection.</summary>
	/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	/// <summary>
	/// An implementation the <see cref="IEnumerator"/> interface that can iterate through the <see cref="BackgroundCopyJob"/> objects within the
	/// <see cref="BackgroundCopyJobCollection"/> collection.
	/// </summary>
	private sealed class Enumerator : IEnumerator<BackgroundCopyJob>
	{
		private IBackgroundCopyJob? icurrentjob;
		private readonly IEnumBackgroundCopyJobs ienum;

		internal Enumerator(IEnumBackgroundCopyJobs enumjobs)
		{
			ienum = enumjobs;
			ienum.Reset();
		}

		/// <summary>
		/// Gets the <see cref="BackgroundCopyJob"/> object in the <see cref="BackgroundCopyJobCollection"/> collection to which the enumerator is pointing.
		/// </summary>
		public BackgroundCopyJob Current => icurrentjob is not null ? new BackgroundCopyJob(icurrentjob) : throw new InvalidOperationException();

		/// <summary>
		/// Gets the <see cref="BackgroundCopyJob"/> object in the <see cref="BackgroundCopyJobCollection"/> collection to which the enumerator is pointing.
		/// </summary>
		object IEnumerator.Current => Current;

		/// <summary>Disposes of the Enumerator object.</summary>
		public void Dispose()
		{
			icurrentjob = null;
			GC.SuppressFinalize(this);
		}

		/// <summary>Moves the enumerator index to the next object in the collection.</summary>
		/// <returns></returns>
		public bool MoveNext()
		{
			try
			{
				icurrentjob = ienum.Next(1)?.FirstOrDefault();
				return icurrentjob is not null;
			}
			catch { return false; }
		}

		/// <summary>Resets the enumerator index to the beginning of the <see cref="BackgroundCopyJobCollection"/> collection.</summary>
		public void Reset()
		{
			icurrentjob = null;
			ienum.Reset();
		}
	}
}