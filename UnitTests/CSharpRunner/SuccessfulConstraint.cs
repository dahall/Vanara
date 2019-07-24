using NUnit.Framework.Constraints;
using System;

namespace Vanara.PInvoke.Tests
{
	public static class ResultIs
	{
		public static FailureConstraint Failure => new FailureConstraint();
		public static SuccessfulConstraint Successful => new SuccessfulConstraint();
		public static ValueConstraint Value(object value) => new ValueConstraint(value);
		public static ValidHandleConstraint ValidHandle => new ValidHandleConstraint();
		public static FailureConstraint FailureCode(object expectedError) => new FailureConstraint(expectedError);
	}

	public class FailureConstraint : Constraint
	{
		public FailureConstraint(object expected = null)
		{
			switch (expected)
			{
				case null:
					break;
				case int i:
					Expected = new Win32Error(i);
					break;
				case uint i:
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

				case int i:
					var e = new Win32Error(i);
					success = Expected is null ? e.Failed : e.Failed && ((IErrorProvider)Expected).ToHRESULT().Equals(e.ToHRESULT());
					updActual = e;
					Description = Expected?.ToString() ?? nameof(Win32Error.ERROR_SUCCESS);
					break;

				case uint ui:
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
			object updActual = actual;
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

				case int i:
					var e = new Win32Error(i);
					success = e.Succeeded;
					updActual = e;
					Description = nameof(Win32Error.ERROR_SUCCESS);
					break;

				case uint ui:
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

	public class ValueConstraint : Constraint
	{
		public object Expected { get; }

		public ValueConstraint(object expected)
		{
			Expected = expected;
		}

		public override ConstraintResult ApplyTo<TActual>(TActual actual)
		{
			if (!(Expected?.Equals(actual) ?? actual == null))
			{
				Description = $"{Expected}, {Win32Error.ERROR_SUCCESS}";
				return new ConstraintResult(this, (actual, Win32Error.GetLastError()), false);
			}
			return new ConstraintResult(this, actual, true);
		}
	}

	public class ValidHandleConstraint : Constraint
	{
		public ValidHandleConstraint()
		{
		}

		public override ConstraintResult ApplyTo<TActual>(TActual actual)
		{
			var success = true;
			switch (actual)
			{
				case System.Runtime.InteropServices.SafeHandle h:
					success = !h.IsInvalid;
					break;
				case IHandle ih:
					var l = ih.DangerousGetHandle().ToInt64();
					success = l != 0 && l != -1;
					break;
				case System.IntPtr p:
					l = p.ToInt64();
					success = l != 0 && l != -1;
					break;
				default:
					break;
			}
			Description = $"Valid handle";
			return new ConstraintResult(this, success ? "Valid handle" : $"Invalid handle (Err: {Win32Error.GetLastError()})", success);
		}
	}

}