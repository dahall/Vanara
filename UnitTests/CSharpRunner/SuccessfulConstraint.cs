using NUnit.Framework.Constraints;
using System;

namespace Vanara.PInvoke.Tests;

public abstract class ResultIs // : NUnit.Framework.Is
{
	public static FailureConstraint Failure => new FailureConstraint();
	public static MyConstraintExpression Not => MyConstraintExpression.Not;
	public static SuccessfulConstraint Successful => new SuccessfulConstraint();
	public static ValidHandleConstraint ValidHandle => new ValidHandleConstraint();

	public static FailureConstraint FailureCode(object expectedError) => new FailureConstraint(expectedError);
	public static ValueConstraint Value(object value) => new ValueConstraint(value);
}

public class MyConstraintExpression
{
	private OpConstraint.Op op;

	private MyConstraintExpression(OpConstraint.Op _op) => op = _op;

	public static MyConstraintExpression Not => new MyConstraintExpression(OpConstraint.Op.Not);

	public ValidHandleConstraint ValidHandle => new ValidHandleConstraint(op);

	public ValueConstraint Value(object value) => new ValueConstraint(value, op);
}

public class FailureConstraint : Constraint
{
	public FailureConstraint(object expected = null)
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

	public object Expected { get; }

	public override ConstraintResult ApplyTo<TActual>(TActual actual)
	{
		var success = false;
		object updActual = actual;
		switch (actual)
		{
			case bool b:
				success = b;
				Description = nameof(Win32Error.ERROR_SUCCESS);
				if (!b)
				{
					var le = Win32Error.GetLastError();
					if (Expected != null) Description = Expected.ToString();
					success = Expected is null ? le.Failed : le.Failed && ((IErrorProvider)Expected).ToHRESULT().Equals(le.ToHRESULT());
					updActual = le;
				}
				break;

			case HRESULT hr:
				success = Expected is null ? hr.Failed : hr.Failed && ((IErrorProvider)Expected).ToHRESULT().Equals(hr);
				Description = Expected?.ToString() ?? nameof(HRESULT.S_OK);
				break;

			case Win32Error err:
				success = Expected is null ? err.Failed : err.Failed && ((IErrorProvider)Expected).ToHRESULT().Equals(err.ToHRESULT());
				Description = Expected?.ToString() ?? nameof(Win32Error.ERROR_SUCCESS);
				break;

			case NTStatus st:
				success = Expected is null ? st.Failed : st.Failed && ((IErrorProvider)Expected).ToHRESULT().Equals(((IErrorProvider)st).ToHRESULT());
				Description = Expected?.ToString() ?? nameof(NTStatus.STATUS_SUCCESS);
				break;

			case uint i:
				var e = new Win32Error(i);
				success = Expected is null ? e.Failed : e.Failed && ((IErrorProvider)Expected).ToHRESULT().Equals(e.ToHRESULT());
				updActual = e;
				Description = Expected?.ToString() ?? nameof(Win32Error.ERROR_SUCCESS);
				break;

			case int ui:
				var h = new HRESULT(ui);
				success = Expected is null ? h.Failed : h.Failed && ((IErrorProvider)Expected).ToHRESULT().Equals(h);
				updActual = h;
				Description = Expected?.ToString() ?? nameof(HRESULT.S_OK);
				break;

			default:
				break;
		}
		return new ConstraintResult(this, updActual, success);
	}
}

public class SuccessfulConstraint : Constraint
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
				Description = nameof(Win32Error.ERROR_SUCCESS);
				if (!b)
				{
					var le = Win32Error.GetLastError();
					success = le.Succeeded;
					updActual = le;
				}
				break;

			case HRESULT hr:
				success = hr.Succeeded;
				Description = nameof(HRESULT.S_OK);
				break;

			case Win32Error err:
				success = err.Succeeded;
				Description = nameof(Win32Error.ERROR_SUCCESS);
				break;

			case NTStatus st:
				success = st.Succeeded;
				Description = nameof(NTStatus.STATUS_SUCCESS);
				break;

			case uint i:
				var e = new Win32Error(i);
				success = e.Succeeded;
				updActual = e;
				Description = nameof(Win32Error.ERROR_SUCCESS);
				break;

			case int ui:
				var h = new HRESULT(ui);
				success = h.Succeeded;
				updActual = h;
				Description = nameof(HRESULT.S_OK);
				break;

			default:
				break;
		}
		return new ConstraintResult(this, updActual, success);
	}
}

public abstract class OpConstraint : Constraint
{
	public enum Op
	{
		None = 0,
		Not = 1
	}

	protected Op AppliedOp { get; }

	protected OpConstraint(Op op) => AppliedOp = op;

	protected string Prefix
	{
		get
		{
			switch (AppliedOp)
			{
				case Op.Not:
					return "Not ";
				default:
					return "";
			}
		}
	}
}

public class ValidHandleConstraint : OpConstraint
{
	public ValidHandleConstraint(OpConstraint.Op op = OpConstraint.Op.None) : base(op)
	{
	}

	public override ConstraintResult ApplyTo<TActual>(TActual actual)
	{
		IntPtr val;
		bool success;
		switch (actual)
		{
			case System.Runtime.InteropServices.SafeHandle h:
				success = !h.IsInvalid;
				val = h.DangerousGetHandle();
				break;

			case IHandle ih:
				val = ih.DangerousGetHandle();
				var l = val.ToInt64();
				success = l != 0 && l != -1;
				break;

			case System.IntPtr p:
				val = p;
				l = val.ToInt64();
				success = l != 0 && l != -1;
				break;

			default:
				throw new InvalidCastException("Cannot get a handle from value.");
		}
		Description = $"Valid handle";
		if (AppliedOp == Op.Not)
		{
			success = !success;
			Description = $"Invalid handle";
		}
		return new ErrConstraintResult(this, string.Format("0x{0:X" + IntPtr.Size + "}", val.ToInt64()), success);
	}
}

public class ValueConstraint : OpConstraint
{
	public object Expected { get; }

	public ValueConstraint(object expected, OpConstraint.Op op = OpConstraint.Op.None) : base(op)
	{
		Expected = expected;
	}

	public override ConstraintResult ApplyTo<TActual>(TActual actual)
	{
		var eq = new EqualConstraint(Expected);
		Description = Prefix + eq.Description;
		var success = eq.ApplyTo(actual).IsSuccess;
		if (AppliedOp == Op.Not)
			success = !success;
		return new ErrConstraintResult(this, actual, success);
	}
}

public class ErrConstraintResult : ConstraintResult
{
	private readonly Win32Error lastErr;

	public ErrConstraintResult(IConstraint constraint, object actualValue, bool isSuccessful) : base(constraint, actualValue, isSuccessful)
	{
		lastErr = Win32Error.GetLastError();
	}

	public override void WriteAdditionalLinesTo(MessageWriter writer) => writer.Write($" (Err: {lastErr})");
}