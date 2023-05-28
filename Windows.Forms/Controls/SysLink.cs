#if SYSLINKGETSWORKING
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Controls;

/// <summary>Represents a Windows SysLink control that displays one or more hyperlinks.</summary>
/// <seealso cref="Control"/>
public class SysLink : Control
{
	private static readonly bool IsPlatformSupported = Environment.OSVersion.Version.Major > 5;
	private static Lazy<bool> init = new(() => InitCommonControlsEx(CommonControlClass.ICC_LINK_CLASS));

	/// <summary>Initializes a new instance of the <see cref="SysLink"/> class.</summary>
	public SysLink()
	{
		if (!IsPlatformSupported) throw new InvalidOperationException("A SysLink control is only supported after Vista.");
		if (!init.Value) throw new InvalidOperationException("Failed to initialize common controls.");
		Items = new(this);
	}

	/// <summary>Gets the list of hyperlinks.</summary>
	/// <value>The hyperlinks.</value>
	public SysLinkItemList Items { get; }

	/// <inheritdoc/>
	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams cp = base.CreateParams;
			cp.ClassName = WC_LINK;
			cp.Caption = "Click <a id=\"ID01\">here</a>";
			return cp;
		}
	}

	/// <inheritdoc/>
	protected override Size DefaultSize => new(200, AutoSize ? PreferredSize.Height : 58);

	/// <inheritdoc/>
	public override Size GetPreferredSize(Size proposedSize)
	{
		SIZE sz = proposedSize;
		if (IsHandleCreated)
		{
			using PinnedObject psz = new(sz);
			var h = SendMessage(Handle, SysLinkMessage.LM_GETIDEALSIZE, proposedSize.Width, psz).ToInt32();
		}
		return sz;
	}
}

/// <summary>Exposes the list of hyperlinks in a <see cref="SysLink"/> control. This class cannot be inherited.</summary>
public sealed class SysLinkItemList : IReadOnlyList<SysLinkItem>
{
	private readonly SysLink parent;

	internal SysLinkItemList(SysLink parent) => this.parent = parent;

	/// <inheritdoc/>
	public int Count
	{
		get
		{
			int count = 0;
			for (IEnumerator<SysLinkItem> e = GetEnumerator(); e.MoveNext(); count++) ;
			return Count;
		}
	}

	/// <inheritdoc/>
	public SysLinkItem this[int index] => new((HWND)parent.Handle, ValidateIndex(index));

	/// <inheritdoc/>
	public IEnumerator<SysLinkItem> GetEnumerator()
	{
		LITEM li = new(0, LIF.LIF_STATE);
		using var pli = new PinnedObject(li);
		if (parent.IsHandleCreated)
			for (; li.iLink < ushort.MaxValue && IntPtr.Zero != SendMessage(parent.Handle, SysLinkMessage.LM_GETITEM, default, pli); li.iLink++)
				yield return new((HWND)parent.Handle, li.iLink);
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	private int ValidateIndex(int index)
	{
		LITEM li = new(index, LIF.LIF_STATE);
		using var pli = new PinnedObject(li);
		return IntPtr.Zero == SendMessage(parent.Handle, SysLinkMessage.LM_GETITEM, default, pli)
			? throw new ArgumentOutOfRangeException(nameof(index))
			: index;
	}
}

/// <summary>Information about a hyperlink exposed by a <see cref="SysLink"/> control. This class cannot be inherited.</summary>
public sealed class SysLinkItem
{
	private readonly int index;
	private readonly HWND parent;

	internal SysLinkItem(HWND handle, int index) { parent = handle; this.index = index; }

	/// <summary>Gets or sets a value indicating whether this <see cref="SysLinkItem"/> is enabled.</summary>
	/// <value><see langword="true"/> if enabled; otherwise, <see langword="false"/>.</value>
	public bool Enabled { get => GetState(LIS.LIS_ENABLED); set => SetState(LIS.LIS_ENABLED, value); }

	/// <summary>Gets or sets a value indicating whether this <see cref="SysLinkItem"/> is focused.</summary>
	/// <value><see langword="true"/> if focused; otherwise, <see langword="false"/>.</value>
	public bool Focused { get => GetState(LIS.LIS_FOCUSED); set => SetState(LIS.LIS_FOCUSED, value); }

	/// <summary>Gets or sets a value indicating whether this <see cref="SysLinkItem"/> is hover.</summary>
	/// <value><see langword="true"/> if hover; otherwise, <see langword="false"/>.</value>
	public bool Hover { get => GetState(LIS.LIS_HOTTRACK); set => SetState(LIS.LIS_HOTTRACK, value); }

	/// <summary>Gets or sets the key.</summary>
	/// <value>The key.</value>
	public string Key { get => GetInfo(LIF.LIF_ITEMID).szID ?? index.ToString(); set => SetInfo(new(index, LIF.LIF_ITEMID) { szID = value }); }

	/// <summary>Gets or sets the URL.</summary>
	/// <value>The URL.</value>
	public Uri Url { get => new(GetInfo(LIF.LIF_URL).szUrl); set => SetInfo(new(index, LIF.LIF_URL) { szUrl = value.AbsoluteUri }); }

	/// <summary>Gets or sets a value indicating whether this <see cref="SysLinkItem"/> is visited.</summary>
	/// <value><see langword="true"/> if visited; otherwise, <see langword="false"/>.</value>
	public bool Visited { get => GetState(LIS.LIS_VISITED); set => SetState(LIS.LIS_VISITED, value); }

	private LITEM GetInfo(LIF mask)
	{
		LITEM li = new(index, mask);
		using PinnedObject pli = new(li);
		if (mask.IsFlagSet(LIF.LIF_STATE))
			li.stateMask = (LIS)0x1f;
		SendMessage(parent, SysLinkMessage.LM_GETITEM, default, pli);
		return li;
	}

	private bool GetState(LIS mask) => GetInfo(LIF.LIF_STATE).state.IsFlagSet(mask);

	private void SetInfo(in LITEM item)
	{
		using PinnedObject pli = new(item);
		if (0 != SendMessage(parent, SysLinkMessage.LM_SETITEM, default, pli).ToInt32())
			Win32Error.ThrowLastError();
	}

	private void SetState(LIS lIS, bool value) => SetInfo(new(index, LIF.LIF_STATE) { stateMask = lIS, state = value ? lIS : 0 });
}
#endif