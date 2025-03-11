using NUnit.Framework.Constraints;

namespace Vanara.PInvoke.Tests;

public abstract class ResultIs // : NUnit.Framework.Is
{
	public static FailureConstraint Failure => new();
	public static MyConstraintExpression Not => MyConstraintExpression.Not;
	public static SuccessfulConstraint Successful => new();
	public static ValidHandleConstraint ValidHandle => new();

	public static FailureConstraint FailureCode(object expectedError) => new(expectedError);
	public static ValueConstraint Value(object value) => new(value);
}

public class MyConstraintExpression
{
	private readonly OpConstraint.Op op;

	private MyConstraintExpression(OpConstraint.Op _op) => op = _op;

	public static MyConstraintExpression Not => new(OpConstraint.Op.Not);

	public ValidHandleConstraint ValidHandle => new(op);

	public ValueConstraint Value(object? value) => new(value, op);
}

public abstract class DescConstraint : Constraint
{
	protected string description = "";
	public override string Description => description;
}

public class FailureConstraint : DescConstraint
{
	public FailureConstraint(object? expected = null)
	{
		switch (expected)
		{
			case null:
				break;

			case uint i:
				Expected = new Win32Error(i);
				break;

			case int i:
				Expected = new HRESULT(i);
				break;

			case IErrorProvider iep:
				Expected = iep;
				break;

			default:
				throw new ArgumentException();
		}
	}

	public object? Expected { get; }

	public override ConstraintResult ApplyTo<TActual>(TActual actual)
	{
		var success = false;
		object? updActual = actual;
		switch (actual)
		{
			case bool b:
				success = b;
				description = nameof(Win32Error.ERROR_SUCCESS);
				if (!b)
				{
					var le = Win32Error.GetLastError();
					if (Expected != null) description = Expected.ToString() ?? "";
					success = Expected is null ? le.Failed : le.Failed && ((IErrorProvider)Expected).ToHRESULT().Equals(le.ToHRESULT());
					updActual = le;
				}
				break;

			case HRESULT hr:
				success = Expected is null ? hr.Failed : hr.Failed && ((IErrorProvider)Expected).ToHRESULT().Equals(hr);
				description = Expected?.ToString() ?? nameof(HRESULT.S_OK);
				break;

			case Win32Error err:
				success = Expected is null ? err.Failed : err.Failed && ((IErrorProvider)Expected).ToHRESULT().Equals(err.ToHRESULT());
				description = Expected?.ToString() ?? nameof(Win32Error.ERROR_SUCCESS);
				break;

			case NTStatus st:
				success = Expected is null ? st.Failed : st.Failed && ((IErrorProvider)Expected).ToHRESULT().Equals(((IErrorProvider)st).ToHRESULT());
				description = Expected?.ToString() ?? nameof(NTStatus.STATUS_SUCCESS);
				break;

			case uint i:
				var e = new Win32Error(i);
				success = Expected is null ? e.Failed : e.Failed && ((IErrorProvider)Expected).ToHRESULT().Equals(e.ToHRESULT());
				updActual = e;
				description = Expected?.ToString() ?? nameof(Win32Error.ERROR_SUCCESS);
				break;

			case int ui:
				var h = new HRESULT(ui);
				success = Expected is null ? h.Failed : h.Failed && ((IErrorProvider)Expected).ToHRESULT().Equals(h);
				updActual = h;
				description = Expected?.ToString() ?? nameof(HRESULT.S_OK);
				break;

			default:
				break;
		}
		return new ConstraintResult(this, updActual, success);
	}
}

public class SuccessfulConstraint : DescConstraint
{
	public SuccessfulConstraint()
	{
	}

	public override ConstraintResult ApplyTo<TActual>(TActual actual)
	{
		var success = false;
		var updActual = actual as IErrorProvider;
		switch (actual)
		{
			case bool b:
				success = b;
				description = nameof(Win32Error.ERROR_SUCCESS);
				if (!b)
				{
					var le = Win32Error.GetLastError();
					success = le.Succeeded;
					updActual = le;
				}
				break;

			case HRESULT hr:
				success = hr.Succeeded;
				description = nameof(HRESULT.S_OK);
				break;

			case Win32Error err:
				success = err.Succeeded;
				description = nameof(Win32Error.ERROR_SUCCESS);
				break;

			case NTStatus st:
				success = st.Succeeded;
				description = nameof(NTStatus.STATUS_SUCCESS);
				break;

			case uint i:
				var e = new Win32Error(i);
				success = e.Succeeded;
				updActual = e;
				description = nameof(Win32Error.ERROR_SUCCESS);
				break;

			case int ui:
				var h = new HRESULT(ui);
				success = h.Succeeded;
				updActual = h;
				description = nameof(HRESULT.S_OK);
				break;

			default:
				break;
		}
		return new ConstraintResult(this, updActual, success);
	}
}

public abstract class OpConstraint : DescConstraint
{
	public enum Op
	{
		None = 0,
		Not = 1
	}

	protected Op AppliedOp { get; }

	protected OpConstraint(Op op) => AppliedOp = op;

	protected string Prefix => AppliedOp switch
	{
		Op.Not => "Not ",
		_ => "",
	};
}

public class ValidHandleConstraint : OpConstraint
{
	public ValidHandleConstraint(Op op = Op.None) : base(op)
	{
	}

	public override ConstraintResult ApplyTo<TActual>(TActual actual)
	{
		IntPtr val;
		bool success;
		switch (actual)
		{
			case SafeHandle h:
				success = !h.IsInvalid;
				val = h.DangerousGetHandle();
				break;

			case IHandle ih:
				success = !ih.IsInvalid;
				val = ih.DangerousGetHandle();
				break;

			case IntPtr p:
				val = p;
				long l = val.ToInt64();
				success = l is not 0 and not (-1);
				break;

			default:
				throw new InvalidCastException("Cannot get a handle from value.");
		}
		description = $"Valid handle";
		if (AppliedOp == Op.Not)
		{
			success = !success;
			description = $"Invalid handle";
		}
		return new ErrConstraintResult(this, string.Format("0x{0:X" + IntPtr.Size + "}", val.ToInt64()), success);
	}
}

public class ValueConstraint : OpConstraint
{
	public object? Expected { get; }

	public ValueConstraint(object? expected, Op op = Op.None) : base(op) => Expected = expected;

	public override ConstraintResult ApplyTo<TActual>(TActual actual)
	{
		var eq = new EqualConstraint(Expected);
		description = Prefix + eq.Description;
		var success = eq.ApplyTo(actual).IsSuccess;
		if (AppliedOp == Op.Not)
			success = !success;
		return new ErrConstraintResult(this, actual, success);
	}
}

public class ErrConstraintResult : ConstraintResult
{
	private readonly Win32Error lastErr;

	public ErrConstraintResult(IConstraint constraint, object? actualValue, bool isSuccessful) : base(constraint, actualValue, isSuccessful) => lastErr = Win32Error.GetLastError();

	public override void WriteAdditionalLinesTo(MessageWriter writer) => writer.Write($" (Err: {lastErr})");
}