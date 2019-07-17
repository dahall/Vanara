using NUnit.Framework.Constraints;

namespace Vanara.PInvoke.Tests
{
	public static class ResultIs
	{
		public static FailureConstraint Failure => new FailureConstraint();
		public static SuccessfulConstraint Successful => new SuccessfulConstraint();
		public static ValueConstraint Value(object value) => new ValueConstraint(value);
		public static ValidHandleConstraint ValidHandle => new ValidHandleConstraint();
	}

	public class FailureConstraint : Constraint
	{
		public FailureConstraint()
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
						success = le.Failed;
						updActual = le;
					}
					break;

				case HRESULT hr:
					success = hr.Failed;
					Description = nameof(HRESULT.S_OK);
					break;

				case Win32Error err:
					success = err.Failed;
					Description = nameof(Win32Error.ERROR_SUCCESS);
					break;

				case NTStatus st:
					success = st.Failed;
					Description = nameof(NTStatus.STATUS_SUCCESS);
					break;

				case int i:
					var e = new Win32Error(i);
					success = e.Failed;
					updActual = e;
					Description = nameof(Win32Error.ERROR_SUCCESS);
					break;

				case uint ui:
					var h = new HRESULT(ui);
					success = h.Failed;
					updActual = h;
					Description = nameof(HRESULT.S_OK);
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