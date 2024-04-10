#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Vanara.PInvoke;

public static partial class Odbc32
{
	public const int SQL_NO_TOTAL = -4;
	public const int SQL_NTS = -3;
	public const nint SQL_NULL_DATA = -1;
	private const int SQL_MAX_NUMERIC_LEN = 16;

	[PInvokeData("sqltypes.h")]
	public enum SQLINTERVAL
	{
		SQL_IS_YEAR = 1,
		SQL_IS_MONTH = 2,
		SQL_IS_DAY = 3,
		SQL_IS_HOUR = 4,
		SQL_IS_MINUTE = 5,
		SQL_IS_SECOND = 6,
		SQL_IS_YEAR_TO_MONTH = 7,
		SQL_IS_DAY_TO_HOUR = 8,
		SQL_IS_DAY_TO_MINUTE = 9,
		SQL_IS_DAY_TO_SECOND = 10,
		SQL_IS_HOUR_TO_MINUTE = 11,
		SQL_IS_HOUR_TO_SECOND = 12,
		SQL_IS_MINUTE_TO_SECOND = 13
	}

	/// <summary>
	/// Each function in ODBC returns a code, known as its return code, which indicates the overall success or failure of the function.
	/// Program logic is generally based on return codes.
	/// </summary>
	[PInvokeData("sqltypes.h")]
	[Serializable]
	public enum SQLRETURN : short
	{
		/// <summary>
		/// Function completed successfully. The application calls SQLGetDiagField to retrieve additional information from the header record.
		/// </summary>
		SQL_SUCCESS = 0,

		/// <summary>
		/// Function completed successfully, possibly with a nonfatal error (warning). The application calls SQLGetDiagRec or SQLGetDiagField
		/// to retrieve additional information.
		/// </summary>
		SQL_SUCCESS_WITH_INFO = 1,

		/// <summary>
		/// Function failed. The application calls SQLGetDiagRec or SQLGetDiagField to retrieve additional information. The contents of any
		/// output arguments to the function are undefined.
		/// </summary>
		SQL_ERROR = -1,

		/// <summary>
		/// Function failed due to an invalid environment, connection, statement, or descriptor handle. This indicates a programming error.
		/// No additional information is available from SQLGetDiagRec or SQLGetDiagField. This code is returned only when the handle is a
		/// null pointer or is the wrong type, such as when a statement handle is passed for an argument that requires a connection handle.
		/// </summary>
		SQL_INVALID_HANDLE = -2,

		/// <summary>
		/// No more data was available. The application calls SQLGetDiagRec or SQLGetDiagField to retrieve additional information. One or
		/// more driver-defined status records in class 02xxx may be returned. Note: In ODBC 2.x, this return code was named SQL_NO_DATA_FOUND.
		/// </summary>
		SQL_NO_DATA = 100,

		/// <summary>
		/// A function that was started asynchronously is still executing. The application calls SQLGetDiagRec or SQLGetDiagField to retrieve
		/// additional information, if any.
		/// </summary>
		SQL_STILL_EXECUTING = 2,

		/// <summary>
		/// More data is needed, such as when parameter data is sent at execution time or additional connection information is required. The
		/// application calls SQLGetDiagRec or SQLGetDiagField to retrieve additional information, if any.
		/// </summary>
		SQL_NEED_DATA = 99,

		/// <summary>
		/// More data is available. The application calls SQLParamData to retrieve the data. Note: In ODBC 2.x, this return code was named
		/// </summary>
		SQL_PARAM_DATA_AVAILABLE = 101,
	}

	public static Exception? GetException(this SQLRETURN ret, ISQLHANDLE? h = null) => ret switch
	{
		SQLRETURN.SQL_SUCCESS => null,
		_ => Odbc32Exception.CreateException($"ODBC call failed with return code {ret}", ret, h),
	};

	public static bool SQL_SUCCEEDED(this SQLRETURN ret) => (((short)ret) & (~1)) == 0;

	public static void ThrowIfFailed(this SQLRETURN ret, ISQLHANDLE? h = null)
	{
		if (!SQL_SUCCEEDED(ret))
			throw ret.GetException(h)!;
	}

	[PInvokeData("sqltypes.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DATE_STRUCT
	{
		public short year;
		public ushort month;
		public ushort day;

		public static implicit operator DateTime(DATE_STRUCT d) => new(d.year, d.month, d.day);

		public static implicit operator DATE_STRUCT(DateTime d) => new() { year = (short)d.Year, month = (ushort)d.Month, day = (ushort)d.Day };
	}

	[PInvokeData("sqltypes.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SQL_DAY_SECOND
	{
		public uint day;
		public uint hour;
		public uint minute;
		public uint second;
		public uint fraction;
	}

	[PInvokeData("sqltypes.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SQL_INTERVAL_STRUCT
	{
		public SQLINTERVAL interval_type;
		public short interval_sign;
		public INTVAL intval;

		[StructLayout(LayoutKind.Sequential)]
		public struct INTVAL
		{
			public SQL_YEAR_MONTH year_month;
			public SQL_DAY_SECOND day_second;
		}
	}

	[PInvokeData("sqltypes.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SQL_NUMERIC_STRUCT
	{
		public byte precision;
		public sbyte scale;
		public byte sign;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = SQL_MAX_NUMERIC_LEN)]
		public byte[] val;

		public static SQL_NUMERIC_STRUCT FromDecimal(decimal d, byte precision)
		{
			SafeCoTaskMemHandle ret = SafeCoTaskMemHandle.CreateFromStructure<SQL_NUMERIC_STRUCT>();

			int[] parts = decimal.GetBits(d);
			byte[] bits = BitConverter.GetBytes(parts[3]);

			ret.Write(precision, false, 0);     //Bits 0-7 precision
			ret.Write(bits[2], false, 1);     //Bits 16-23 scale
			ret.Write((byte)(0 == bits[3] ? 1 : 0), false, 2);    //Bit 31 - sign(isnegative)
			ret.Write(parts[0], false, 3);
			ret.Write(parts[1], false, 7);
			ret.Write(parts[2], false, 11);

			return ret.ToStructure<SQL_NUMERIC_STRUCT>();
		}

		public static implicit operator decimal(SQL_NUMERIC_STRUCT ns)
		{
			SafeCoTaskMemStruct<SQL_NUMERIC_STRUCT> mem = ns;
			byte[] bits = mem.GetBytes();

			int[] buffer = new int[4];
			buffer[3] = bits[2] << 16; // scale
			if (0 == bits[3])
				buffer[3] |= unchecked((int)0x80000000); //sign
			buffer[0] = BitConverter.ToInt32(bits, 4);     // low
			buffer[1] = BitConverter.ToInt32(bits, 8);     // mid
			buffer[2] = BitConverter.ToInt32(bits, 12);     // high
			return 0 != BitConverter.ToInt32(bits, 16) ? throw new OverflowException() : new decimal(buffer);
		}
	}

	[PInvokeData("sqltypes.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SQL_YEAR_MONTH
	{
		public uint year;
		public uint month;
	}

	[PInvokeData("sqltypes.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TIME_STRUCT
	{
		public ushort hour;
		public ushort minute;
		public ushort second;

		public static implicit operator TimeSpan(TIME_STRUCT t) => new(t.hour, t.minute, t.second);

		public static implicit operator TIME_STRUCT(TimeSpan t) => new() { hour = (ushort)t.Hours, minute = (ushort)t.Minutes, second = (ushort)t.Seconds };
	}

	[PInvokeData("sqltypes.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TIMESTAMP_STRUCT
	{
		public short year;
		public ushort month;
		public ushort day;
		public ushort hour;
		public ushort minute;
		public ushort second;
		public uint fraction;

		public static implicit operator DateTime(TIMESTAMP_STRUCT t) => new DateTime(t.year, t.month, t.day, t.hour, t.minute, t.second, DateTimeKind.Unspecified) + TimeSpan.FromTicks(t.fraction / 100);

		public static implicit operator TIMESTAMP_STRUCT(DateTime t) => new() { year = (short)t.Year, month = (ushort)t.Month, day = (ushort)t.Day, hour = (ushort)t.Hour, minute = (ushort)t.Minute, second = (ushort)t.Second, fraction = (uint)(t.Ticks % TimeSpan.TicksPerSecond) * 100 };
	}

	public class Odbc32Exception(string message) : System.Data.Common.DbException(message)
	{
		public IReadOnlyCollection<Odbc32Error> Errors { get; private set; } = [];

		public static Odbc32Exception CreateException(string message, SQLRETURN ret, ISQLHANDLE? h = null)
		{
			var errs = Odbc32Error.GetDiagErrors(h, ret);
			StringBuilder sb = new(message);
			if (sb.Length > 0) sb.AppendLine();
			foreach (var e in errs)
				sb.AppendLine($"State: {e.SqlState},\tErr: {e.hResult},\tMessage: {e.Message}");
			return new(sb.ToString()) { Errors = errs };
		}

		public class Odbc32Error(string msg, string state, int err)
		{
			public int hResult { get; } = err;
			public string Message { get; } = msg;
			public string SqlState { get; } = state;

			internal static List<Odbc32Error> GetDiagErrors(ISQLHANDLE? h, SQLRETURN ret)
			{
				List<Odbc32Error> errors = [];
				if (ret != SQLRETURN.SQL_SUCCESS && h is not null)
				{
					short i = 0;
					StringBuilder sbState = new(5), sbMsg = new(1024);
					bool more = true;
					while (more)
					{
						++i;
						var rc = SQLGetDiagRec(h.GetHandleVal(), h.DangerousGetHandle(), i, sbState, out var err, sbMsg, (short)sbMsg.Capacity, out var req);
						if (rc == SQLRETURN.SQL_SUCCESS_WITH_INFO && sbMsg.Capacity - 1 < req)
						{
							sbMsg.Capacity = req + 1;
							rc = SQLGetDiagRec(h.GetHandleVal(), h.DangerousGetHandle(), i, sbState, out err, sbMsg, (short)sbMsg.Capacity, out _);
						}
						if (more = SQL_SUCCEEDED(rc))
							errors.Add(new Odbc32Error(sbMsg.ToString(), sbState.ToString(), err));
					}
				}
				return errors;
			}
		}
	}

	/* enumerations for DATETIME_INTERVAL_SUBCODE values for interval data ref types these values are from SQL-ref 92 */
}