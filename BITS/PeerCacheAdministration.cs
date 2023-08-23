using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Vanara.Collections;
using Vanara.PInvoke;
using static Vanara.PInvoke.BITS;

namespace Vanara.IO;

/// <summary>Provides information about a peer in the neighborhood.</summary>
public class CachePeer
{
	private readonly ComReleaser<IBitsPeer> ciPeer;

	internal CachePeer(IBitsPeer peer) => ciPeer = ComReleaserFactory.Create(peer);

	private CachePeer() => throw new NotImplementedException();

	/// <summary>Determines whether the peer is authenticated.</summary>
	/// <returns><see langword="true"/> if the peer is authenticated, otherwise, <see langword="false"/>.</returns>
	public bool IsAuthenticated => ciPeer.Item.IsAuthenticated();

	/// <summary>Determines whether the peer is available (online) to serve content.</summary>
	/// <returns><see langword="true"/> if the peer is available to serve content, otherwise, <see langword="false"/>.</returns>
	public bool IsAvailable => ciPeer.Item.IsAvailable();

	/// <summary>Gets the server principal name that uniquely identifies the peer.</summary>
	/// <returns>The server principal name of the peer. The principal name is of the form, server$.domain.suffix.</returns>
	public string Name => ciPeer.Item.GetPeerName();
}

/// <summary>Provides the ability to enumerate the list of peers that BITS has discovered.</summary>
public class CachePeers : IReadOnlyCollection<CachePeer>
{
	private readonly IBitsPeerCacheAdministration iCacheAdmin;

	internal CachePeers(IBitsPeerCacheAdministration admin) => iCacheAdmin = admin;

	/// <summary>Gets the number of elements in the collection.</summary>
	public int Count => EnumPeers().Count();

	/// <summary>Removes all peers from the list of peers that can serve content.</summary>
	public void Clear() => iCacheAdmin.ClearPeers();

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>An enumerator that can be used to iterate through the collection.</returns>
	public IEnumerator<CachePeer> GetEnumerator()
	{
		iCacheAdmin.DiscoverPeers();
		return EnumPeers().GetEnumerator();
	}

	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	private IEnumerable<CachePeer> EnumPeers() => iCacheAdmin.EnumPeers().Enumerate().Select(i => new CachePeer(i));
}

/// <summary>Use <c>PeerCacheAdministration</c> to manage the pool of peers from which you can download content.</summary>
public class PeerCacheAdministration
{
	internal readonly ComReleaser<IBitsPeerCacheAdministration> ciCacheAdmin;
	private CachePeers? peers;
	private PeerCacheRecords? recs;

	internal PeerCacheAdministration(IBackgroundCopyManager mgr) => ciCacheAdmin = ComReleaserFactory.Create((IBitsPeerCacheAdministration)mgr);

	/// <summary>
	/// Gets or sets the configuration flags that determine if the computer serves content to peers and can download content from peers.
	/// </summary>
	/// <value>Flags that determine if the computer serves content to peers and can download content from peers.</value>
	public PeerCaching ConfigurationFlags
	{
		get => (PeerCaching)ciCacheAdmin.Item.GetConfigurationFlags();
		set => ciCacheAdmin.Item.SetConfigurationFlags((BG_ENABLE_PEERCACHING)value);
	}

	/// <summary>Gets or sets the maximum size of the cache.</summary>
	/// <value>Maximum size of the cache, as a percentage of available hard disk drive space.</value>
	public uint MaximumCacheSize
	{
		get => ciCacheAdmin.Item.GetMaximumCacheSize();
		set => ciCacheAdmin.Item.SetMaximumCacheSize(value);
	}

	/// <summary>Gets or sets the age by when files are removed from the cache.</summary>
	/// <value>Age. If the last time that the file was accessed is older than this age, BITS removes the file from the cache.</value>
	public TimeSpan MaximumContentAge
	{
		get => TimeSpan.FromSeconds(ciCacheAdmin.Item.GetMaximumContentAge());
		set => ciCacheAdmin.Item.SetMaximumContentAge((uint)value.TotalSeconds);
	}

	/// <summary>Gets a <see cref="CachePeers"/> instance that you use to enumerate the peers that can serve content.</summary>
	/// <value>A <see cref="CachePeers"/> instance that you use to enumerate the peers that can serve content.</value>
	public CachePeers Peers => peers ??= new CachePeers(ciCacheAdmin.Item);

	/// <summary>
	/// Gets a <see cref="PeerCacheRecords"/> instance that you use to enumerate the records in the cache. The enumeration is a snapshot of
	/// the records in the cache.
	/// </summary>
	/// <value>A <see cref="PeerCacheRecords"/> instance that you use to enumerate the records in the cache.</value>
	public PeerCacheRecords Records => recs ??= new PeerCacheRecords(ciCacheAdmin.Item);

	/// <summary>Deletes all cache records and the file from the cache for the given URL.</summary>
	/// <param name="url">
	/// Null-terminated string that contains the URL of the file whose cache records and file you want to delete from the cache.
	/// </param>
	public void DeleteUrl(string url) => ciCacheAdmin.Item.DeleteUrl(url);
}

/// <summary>Provides the ability to enumerate the records of the cache.</summary>
public class PeerCacheRecords : IReadOnlyCollection<PeerCacheRecord>
{
	private readonly IBitsPeerCacheAdministration iCacheAdmin;

	internal PeerCacheRecords(IBitsPeerCacheAdministration admin) => iCacheAdmin = admin;

	/// <summary>Gets the number of elements in the collection.</summary>
	public int Count => EnumRecords().Count();

	/// <summary>Gets a record from the cache.</summary>
	/// <param name="id">Identifier of the record to get from the cache.</param>
	/// <returns>A <see cref="PeerCacheRecord"/> instance of the cache record.</returns>
	public PeerCacheRecord this[Guid id] => new(iCacheAdmin.GetRecord(id));

	/// <summary>Removes all the records and files from the cache.</summary>
	public void Clear() => iCacheAdmin.ClearRecords();

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>An enumerator that can be used to iterate through the collection.</returns>
	public IEnumerator<PeerCacheRecord> GetEnumerator() => EnumRecords().GetEnumerator();

	/// <summary>Deletes a record and file from the cache.</summary>
	/// <param name="item">The record to delete from the cache.</param>
	public bool Remove(PeerCacheRecord item)
	{ try { iCacheAdmin.DeleteRecord(item.Id); return true; } catch { return false; } }

	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	private IEnumerable<PeerCacheRecord> EnumRecords() =>
		iCacheAdmin.EnumRecords()?.Enumerate().Select(i => new PeerCacheRecord(i)) ?? Enumerable.Empty<PeerCacheRecord>();
}

/// <summary>Provides information about a file in the BITS peer cache.</summary>
public class PeerCacheRecord
{
	private readonly ComReleaser<IBitsPeerCacheRecord> ciRecord;

	internal PeerCacheRecord(IBitsPeerCacheRecord bitsPeerCacheRecord) => ciRecord = ComReleaserFactory.Create(bitsPeerCacheRecord);

	private PeerCacheRecord() => throw new NotImplementedException();

	/// <summary>Gets the date and time that the file was last modified on the server.</summary>
	/// <value>Date and time that the file was last modified on the server.</value>
	public DateTime FileModificationTime => ciRecord.Item.GetFileModificationTime().ToDateTime();

	/// <summary>Gets the ranges of the file that are in the cache.</summary>
	/// <value>Array of structures that specify the ranges of the file that are in the cache.</value>
	public BackgroundCopyFileRange[] FileRanges => Array.ConvertAll(ciRecord.Item.GetFileRanges(), i => (BackgroundCopyFileRange)i);

	/// <summary>Gets the size of the file.</summary>
	/// <value>Size of the file, in bytes.</value>
	public ulong FileSize => ciRecord.Item.GetFileSize();

	/// <summary>Gets the record identifier.</summary>
	/// <value>The identifier.</value>
	public Guid Id => ciRecord.Item.GetId();

	/// <summary>Determines whether the file has been validated.</summary>
	/// <value><see langword="true"/> if file has been validated; otherwise <see langword="false"/>.</value>
	public bool IsFileValidated => ciRecord.Item.IsFileValidated() == HRESULT.S_OK;

	/// <summary>Gets the date and time that the file was last accessed.</summary>
	/// <value>Date and time that the file was last accessed.</value>
	public DateTime LastAccessTime => ciRecord.Item.GetLastAccessTime().ToDateTime();

	/// <summary>Gets the origin URL of the cached file.</summary>
	/// <value>String that contains the origin URL of the cached file.</value>
	public string OriginUrl => ciRecord.Item.GetOriginUrl();
}