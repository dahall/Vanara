using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>A keyboard accelerator that can be used to trigger actions in a <see cref="VisibleWindow"/>.</summary>
/// <remarks>Initializes a new instance of the <see cref="Accelerator"/> class.</remarks>
/// <param name="charCode">The character code.</param>
/// <param name="modifiers">The modifiers for the accelerator.</param>
public class Accelerator(ushort charCode, ConsoleModifiers modifiers = 0)
{
	private static ushort lastId = 40000; // Starting command ID for accelerators

	private readonly bool vk = false;

	/// <summary>Initializes a new instance of the <see cref="Accelerator"/> class.</summary>
	/// <param name="virtualKey">The virtual key.</param>
	/// <param name="modifiers">The modifiers for the accelerator.</param>
	public Accelerator(VK virtualKey, ConsoleModifiers modifiers = 0) : this((ushort)virtualKey, modifiers) { vk = true; }

	/// <summary>Gets the virtual key code.</summary>
	public ushort CharCode { get; } = charCode;

	/// <summary>Gets the command identifier.</summary>
	public ushort CommandId { get; } = ++lastId;

	/// <summary>Gets the modifiers for the accelerator.</summary>
	public ConsoleModifiers Modifiers { get; } = modifiers;

	internal Accelerator(in ACCEL a) : this(a.key, GetModifiers(a.fVirt)) { CommandId = a.cmd; vk = a.fVirt.IsFlagSet(FVIRT.FVIRTKEY); }
	internal ACCEL ToACCEL() => new(CommandId, CharCode, GetFVIRT());

	private FVIRT GetFVIRT()
	{
		FVIRT virt = vk ? FVIRT.FVIRTKEY : 0;
		if ((Modifiers & ConsoleModifiers.Alt) != 0)
			virt |= FVIRT.FALT;
		if ((Modifiers & ConsoleModifiers.Control) != 0)
			virt |= FVIRT.FCONTROL;
		if ((Modifiers & ConsoleModifiers.Shift) != 0)
			virt |= FVIRT.FSHIFT;
		return virt;
	}

	private static ConsoleModifiers GetModifiers(FVIRT virt)
	{
		ConsoleModifiers modifiers = 0;
		if ((virt & FVIRT.FALT) != 0)
			modifiers |= ConsoleModifiers.Alt;
		if ((virt & FVIRT.FCONTROL) != 0)
			modifiers |= ConsoleModifiers.Control;
		if ((virt & FVIRT.FSHIFT) != 0)
			modifiers |= ConsoleModifiers.Shift;
		return modifiers;
	}
}

/// <summary>Provides extension methods for working with accelerator tables.</summary>
public static partial class AcceleratorExtension
{
	/// <summary>Creates a safe handle to an accelerator table from a collection of accelerators.</summary>
	/// <remarks>
	/// This method converts the provided collection of <see cref="Accelerator"/> objects into an array of ACCEL structures and creates an
	/// accelerator table using the array. The resulting table is encapsulated in a <see cref="SafeHACCEL"/> to ensure proper resource management.
	/// </remarks>
	/// <param name="accelerators">
	/// A collection of <see cref="Accelerator"/> objects used to populate the accelerator table. Each accelerator in the collection is
	/// converted to an ACCEL structure.
	/// </param>
	/// <returns>A <see cref="SafeHACCEL"/> representing the created accelerator table.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="accelerators"/> is <see langword="null"/>.</exception>
	public static SafeHACCEL CreateHandle(this IEnumerable<Accelerator> accelerators)
	{
		if (accelerators is null || !accelerators.Any())
			return SafeHACCEL.Null;
		var accelArray = accelerators.Select(a => a.ToACCEL()).ToArray();
		return CreateAcceleratorTable(accelArray, accelArray.Length);
	}

	/// <summary>Converts an <see cref="HACCEL"/> handle to an array of <see cref="Accelerator"/> objects.</summary>
	/// <remarks>
	/// This method retrieves all entries from the specified accelerator table and converts them into <see cref="Accelerator"/> objects. The
	/// returned array will contain one <see cref="Accelerator"/> object for each entry in the table.
	/// </remarks>
	/// <param name="hAccel">The handle to the accelerator table to convert.</param>
	/// <returns>An array of <see cref="Accelerator"/> objects representing the entries in the specified accelerator table.</returns>
	/// <exception cref="ArgumentException">Thrown if <paramref name="hAccel"/> is invalid.</exception>
	public static Accelerator[] ToAccelerators(this HACCEL hAccel)
	{
		if (hAccel.IsInvalid)
			throw new ArgumentException("Invalid accelerator handle.", nameof(hAccel));

		var c = CopyAcceleratorTable(hAccel, null, 0);
		ACCEL[] vals = new ACCEL[c];
		c = CopyAcceleratorTable(hAccel, vals, c);
		return Array.ConvertAll(vals, vals => new Accelerator(vals));
	}
}