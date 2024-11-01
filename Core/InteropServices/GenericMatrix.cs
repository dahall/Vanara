﻿#if NET7_0_OR_GREATER
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Vanara;

/// <summary>Represents a two-dimensional matrix of any size.</summary>
/// <typeparam name="T">A number type.</typeparam>
public class Matrix<T> :
	ICloneable,
	IEquatable<Matrix<T>>,
	IFormattable,
	IAdditionOperators<Matrix<T>, Matrix<T>, Matrix<T>>,
	IEqualityOperators<Matrix<T>, Matrix<T>, bool>,
	IMultiplyOperators<Matrix<T>, Matrix<T>, Matrix<T>>,
	IMultiplyOperators<Matrix<T>, T, Matrix<T>>,
	ISubtractionOperators<Matrix<T>, Matrix<T>, Matrix<T>>,
	IUnaryNegationOperators<Matrix<T>, Matrix<T>>,
	IUnaryPlusOperators<Matrix<T>, Matrix<T>>,
	IReadOnlyList<Memory<T>> where T : struct, IConvertible, INumber<T>, IMinMaxValue<T>
{
	private readonly Memory<T> m;

	/// <summary>Initializes a new instance of the <see cref="Matrix{T}"/> class.</summary>
	/// <param name="rows">The rows.</param>
	/// <param name="columns">The columns.</param>
	public Matrix(int rows, int columns) : this(new Memory<T>(new T[rows * columns]), rows, columns) { }

	/// <summary>Initializes a new instance of the <see cref="Matrix{T}"/> class.</summary>
	/// <param name="values">The values.</param>
	/// <param name="rows">The rows.</param>
	/// <param name="columns">The columns.</param>
	/// <exception cref="System.ArgumentException">The number of elements in the memory must be equal to rows * columns.</exception>
	public Matrix(Memory<T> values, int rows, int columns)
	{
		if (rows < 1)
			throw new ArgumentOutOfRangeException(nameof(rows), "Rows must be greater than 0.");
		if (columns < 1)
			throw new ArgumentOutOfRangeException(nameof(columns), "Columns must be greater than 0.");
		if (values.Length != rows * columns)
			throw new ArgumentException("The number of elements in the memory must be equal to rows * columns.");
		Rows = rows;
		Columns = columns;
		m = values;
	}

	/// <summary>Initializes a new instance of the <see cref="Matrix{T}"/> class.</summary>
	/// <param name="values">The values.</param>
	public Matrix(T[,] values) : this(values?.GetLength(0) ?? throw new ArgumentNullException(nameof(values)), values.GetLength(1))
	{
		for (int a = 0; a < values.GetLength(0); a++)
		{
			int bl = values.GetLength(1);
			for (int b = 0; b < bl; b++)
				m.Span[a * bl + b] = values[a, b];
		}
	}

	/// <summary>Gets the number of columns in the matrix.</summary>
	/// <value>The column count.</value>
	public int Columns { get; }

	/// <inheritdoc/>
	int IReadOnlyCollection<Memory<T>>.Count => Rows;

	/// <summary>Gets the determinant.</summary>
	/// <value>The determinant.</value>
	/// <exception cref="System.InvalidOperationException">The matrix must be square.</exception>
	public T Determinant
	{
		get
		{
			CheckSquare();
			ReadOnlySpan<T> s = m.Span;
			switch (Rows)
			{
				case 1:
					return s[0];
				case 2:
					return Det2x2(s[0], s[1], s[2], s[3]);
				case 3:
					return s[0] * Det2x2(s[4], s[5], s[7], s[8]) - s[1] * Det2x2(s[3], s[5], s[6], s[8]) + s[2] * Det2x2(s[3], s[4], s[6], s[7]);
			}
			T det = T.Zero;
			for (int i = 0; i < Columns; i++)
			{
				det += (i % 2 == 0 ? T.One : -T.One) * s[i] * Minor(0, i).Determinant;
			}
			return det;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			static T Det2x2(T i11, T i12, T i21, T i22) => (i11 * i22) + -(i21 * i12);
		}
	}

	/// <summary>Gets a value indicating whether this instance is empty (all zero values).</summary>
	/// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
	public bool IsEmpty
	{
		get
		{
			foreach (T t in m.Span)
				if (!t.Equals(T.Zero))
					return false;
			return true;
		}
	}

	/// <summary>Gets a value indicating whether this instance is full rank.</summary>
	/// <value><c>true</c> if this instance is full rank; otherwise, <c>false</c>.</value>
	public bool IsFullRank => Rank == Math.Min(Rows, Columns);

	/// <summary>Gets a value that indicates whether the current matrix is the identity matrix.</summary>
	/// <value><see langword="true" /> if the current matrix is the identity matrix; otherwise, <see langword="false" />.</value>
	public bool IsIdentity
	{
		get
		{
			if (Rows != Columns)
				return false;
			int c1 = Columns + 1;
			for (int i = 0; i < m.Length; i++)
				if (i % c1 == 0 && !m.Span[i].Equals(T.One) || i % c1 != 0 && !m.Span[i].Equals(T.Zero))
					return false;
			return true;
		}
	}
	/// <summary>Gets a value indicating whether this instance is singluar.</summary>
	/// <value><c>true</c> if this instance is singluar; otherwise, <c>false</c>.</value>
	public bool IsSingluar => Determinant.Equals(T.Zero);

	/// <summary>Gets a value indicating whether this instance is square.</summary>
	/// <value><c>true</c> if this instance is square; otherwise, <c>false</c>.</value>
	public bool IsSquare => Rows == Columns;

	/// <summary>Gets the principal minor.</summary>
	/// <value>The principal minor.</value>
	public Matrix<T> PrincipalMinor => Minor(Rows - 1, Columns - 1);

	/// <summary>Gets the rank of the matrix, or the number of linearly independent row or column vectors.</summary>
	/// <value>The rank of the matrix.</value>
	public int Rank
	{
		get
		{
			Matrix<T> r = ReducedRowEchelonForm();
			int rank = 0;
			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Columns; j++)
				{
					if (!r[i, j].Equals(T.Zero))
					{
						rank++;
						break;
					}
				}
			}
			return rank;
		}
	}

	/// <summary>Gets the number of rows in the matrix.</summary>
	/// <value>The row count.</value>
	public int Rows { get; }

	/// <inheritdoc/>
	Memory<T> IReadOnlyList<Memory<T>>.this[int index] => m.Slice(index * Columns, Columns);

	/// <summary>Gets or sets the element with the specified row and column.</summary>
	/// <value>The element value.</value>
	/// <param name="row">The row.</param>
	/// <param name="column">The column.</param>
	/// <returns>The element value at <paramref name="row"/> and <paramref name="column"/>.</returns>
	public T this[int row, int column]
	{
		get { CheckValidRow(row); CheckValidColumn(column); return GetUnchecked(row, column); }
		set { CheckValidRow(row); CheckValidColumn(column); m.Span[row * Columns + column] = value; }
	}

	/// <summary>Creates a matrix filled with the specified value.</summary>
	/// <param name="rows">The number of rows to create.</param>
	/// <param name="columns">The number of columns to create.</param>
	/// <param name="value">The fill value.</param>
	/// <returns>A new matrix of the specified dimensions with all values set to <paramref name="value"/>.</returns>
	public static Matrix<T> CreateFilled(int rows, int columns, T value)
	{
		var r = new Matrix<T>(rows, columns);
		if (!value.Equals(T.Zero))
			r.m.Span.Fill(value);
		return r;
	}

	/// <summary>Gets an identity matrix of the specified size.</summary>
	/// <param name="dimensions">The rows and columns in the matrix.</param>
	/// <returns>An identity matrix.</returns>
	/// <exception cref="System.ArgumentException">The number of rows must be equal to the number of columns.</exception>
	public static Matrix<T> CreateIdentity(int dimensions)
	{
		if (dimensions < 1)
			throw new ArgumentOutOfRangeException(nameof(dimensions), "Dimension must be greater than 0.");
		Memory<T> m = new T[dimensions * dimensions];
		Span<T> sp = m.Span;
		for (int i = 0; i < dimensions; i++)
		{
			int c1 = i * dimensions;
			for (int j = 0; j < dimensions; j++)
				sp[c1 + j] = i == j ? T.One : T.Zero;
		}
		return new(m, dimensions, dimensions);
	}

	/// <summary>Performs an implicit conversion from <typeparamref name="T"/>[,] to <see cref="Matrix{T}"/>.</summary>
	/// <param name="values">The values.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator Matrix<T>(T[,] values) => new(values);

	/// <summary>Negates the specified matrix by multiplying all its values by -1.</summary>
	/// <param name="value">The matrix to negate.</param>
	/// <returns>The negated matrix.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Matrix<T> operator -(Matrix<T> value) => UnaryAction(value, t => -t);

	/// <summary>Subtracts each element in a second matrix from its corresponding element in a first matrix.</summary>
	/// <param name="left">The first matrix.</param>
	/// <param name="right">The second matrix.</param>
	/// <returns>The matrix containing the values that result from subtracting each element in <paramref name="right" /> from its corresponding element in <paramref name="left" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Matrix<T> operator -(Matrix<T> left, Matrix<T> right) => BinaryAction(left, right, (a, b) => a - b);

	/// <summary>Implements the operator !=.</summary>
	/// <param name="left">The left.</param>
	/// <param name="right">The right.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(Matrix<T>? left, Matrix<T>? right) => !(left == right);

	/// <summary>Multiplies two matrices together to compute the product.</summary>
	/// <param name="left">The first matrix.</param>
	/// <param name="right">The second matrix.</param>
	/// <returns>The product matrix.</returns>
	public static Matrix<T> operator *(Matrix<T> left, Matrix<T> right)
	{
		ArgumentNullException.ThrowIfNull(left);
		ArgumentNullException.ThrowIfNull(right);
		if (left.Columns != right.Rows)
			throw new ArgumentException("The number of columns in the first matrix must be equal to the number of rows in the second matrix.");
		Matrix<T> result = new(left.Rows, right.Columns);
		for (int i = 0; i < left.Rows; i++)
		{
			for (int j = 0; j < right.Columns; j++)
			{
				T sum = T.Zero;
				for (int k = 0; k < left.Columns; k++)
					sum += left[i, k] * right[k, j];
				result[i, j] = sum;
			}
		}
		return result;
	}

	/// <summary>Multiplies a matrix by a scalar to compute the product.</summary>
	/// <param name="left">The matrix to scale.</param>
	/// <param name="right">The scaling value to use.</param>
	/// <returns>The scaled matrix.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Matrix<T> operator *(Matrix<T> left, T right) => UnaryAction(left, t => t * right);

	/// <summary>Multiplies a matrix by a scalar to compute the product.</summary>
	/// <param name="left">The scaling value to use.</param>
	/// <param name="right">The matrix to scale.</param>
	/// <returns>The scaled matrix.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Matrix<T> operator *(T left, Matrix<T> right) => UnaryAction(right, t => t * left);

	/// <summary>Divides a matrix by a scalar to compute the quotient.</summary>
	/// <param name="left">The matrix to scale.</param>
	/// <param name="right">The scaling value to use.</param>
	/// <returns>The scaled matrix.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Matrix<T> operator /(Matrix<T> left, T right) => UnaryAction(left, t => t / right);

	/// <summary>Computes the unary plus of a value.</summary>
	/// <param name="value">The value for which to compute the unary plus.</param>
	/// <returns>The unary plus of <paramref name="value" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Matrix<T> operator +(Matrix<T> value) => value;

	/// <summary>Adds each element in one matrix with its corresponding element in a second matrix.</summary>
	/// <param name="left">The first matrix.</param>
	/// <param name="right">The second matrix.</param>
	/// <returns>The matrix that contains the summed values.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Matrix<T> operator +(Matrix<T> left, Matrix<T> right) => BinaryAction(left, right, (a, b) => a + b);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="left">The left.</param>
	/// <param name="right">The right.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(Matrix<T>? left, Matrix<T>? right) => left is null ? right is null : left.Equals(right);

	/// <summary>Adjugates this instance.</summary>
	/// <returns></returns>
	/// <exception cref="System.InvalidOperationException">The matrix must be square.</exception>
	public Matrix<T> Adjugate()
	{
		CheckSquare();
		Memory<T> adjugate = new T[m.Length];
		Span<T> sp = adjugate.Span;
		for (int i = 0; i < Rows; i++)
		{
			for (int j = 0; j < Columns; j++)
			{
				T minor = Minor(i, j).Determinant;
				sp[j * Rows + i] = (i + j) % 2 == 0 ? minor : -minor;
			}
		}
		return new(adjugate, Rows, Columns);
	}

	/// <summary>Clones this matrix to a new value.</summary>
	/// <returns>A matrix matching this instance.</returns>
	public Matrix<T> Clone() => new(m.ToArray(), Rows, Columns);

	/// <inheritdoc/>
	object ICloneable.Clone() => Clone();

	/// <summary>Cofactors this instance.</summary>
	/// <returns></returns>
	/// <exception cref="System.InvalidOperationException">The matrix must be square.</exception>
	public Matrix<T> Cofactor()
	{
		Matrix<T> r = MatrixOfMinors();
		Span<T> sp = r.m.Span;
		for (int i = 0; i < sp.Length; i++)
			sp[i] = (i % 2 == 0 ? T.One : -T.One) * sp[i];
		return r;
	}

	/// <summary>Columns the vector.</summary>
	/// <param name="column">The column.</param>
	/// <returns></returns>
	/// <exception cref="System.ArgumentOutOfRangeException">column</exception>
	public Matrix<T> ColumnVector(int column)
	{
		CheckValidColumn(column);
		Memory<T> columnVector = new T[Rows];
		Span<T> sp = columnVector.Span;
		for (int i = 0; i < Rows; i++)
			sp[i] = m.Span[i * Columns + column];
		return new(columnVector, Rows, 1);
	}

	/// <summary>Returns a value that indicates whether this instance and another 3x2 matrix are equal.</summary>
	/// <param name="other">The other matrix.</param>
	/// <returns><see langword="true" /> if the two matrices are equal; otherwise, <see langword="false" />.</returns>
	/// <remarks>Two matrices are equal if all their corresponding elements are equal.</remarks>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Equals(Matrix<T>? other)
	{
		if (other is null || other.m.Length != m.Length)
			return false;
		for (int i = 0; i < m.Length; i++)
			if (!m.Span[i].Equals(other.m.Span[i]))
				return false;
		return true;
	}

	/// <inheritdoc/>
	public override bool Equals(object? obj) => obj is Matrix<T> other && Equals(other);

	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<Memory<T>>)this).GetEnumerator();

	/// <inheritdoc/>
	IEnumerator<Memory<T>> IEnumerable<Memory<T>>.GetEnumerator()
	{
		for (int i = 0; i < Rows; i++)
			yield return m.Slice(i * Columns, Columns);
	}

	/// <inheritdoc/>
	public override int GetHashCode()
	{
		HashCode hash = new();
		for (int i = 0; i < m.Length; i++)
			hash.Add(m.Span[i]);
		return hash.ToHashCode();
	}

	/// <summary>Inverts this instance.</summary>
	/// <returns></returns>
	/// <exception cref="System.InvalidOperationException">
	/// The matrix must be square.
	/// or
	/// The matrix is singular.
	/// </exception>
	public Matrix<T> Invert()
	{
		CheckSquare();
		T det = Determinant;
		if (det.Equals(T.Zero))
			throw new InvalidOperationException("The matrix is singular.");
		Matrix<T> adjugate = Adjugate();
		return adjugate * T.One / det;
	}

	/// <summary>Returns a matrix of the same dimensions with the minor determinants of each element.</summary>
	/// <returns>A matrix of the same dimensions with the minor determinants of each element.</returns>
	public Matrix<T> MatrixOfMinors()
	{
		Memory<T> dup = new T[Rows * Columns];
		for (int i = 0; i < Rows; i++)
			for (int j = 0; j < Columns; j++)
				dup.Span[i * Columns + j] = Minor(i, j).Determinant;
		return new(dup, Rows, Columns);
	}

	/// <summary>Creates a new matrix removing the specified row and column.</summary>
	/// <param name="row">The row to remove.</param>
	/// <param name="column">The column to remove.</param>
	/// <returns>A new matrix with the specified row and column removed.</returns>
	public Matrix<T> Minor(int row, int column)
	{
		CheckValidRow(row);
		CheckValidColumn(column);
		Memory<T> minor = new T[(Rows - 1) * (Columns - 1)];
		Span<T> sp = minor.Span;
		for (int i = 0, a = 0; i < Rows; i++)
		{
			if (i == row)
				continue;
			for (int j = 0, b = 0; j < Columns; j++)
			{
				if (j == column)
					continue;
				sp[a * (Columns - 1) + b] = GetUnchecked(i, j);
				b++;
			}
			a++;
		}
		return new(minor, Rows - 1, Columns - 1);
	}

	/// <summary>Pins this instance.</summary>
	/// <returns>A handle for the underlying memory.</returns>
	public MemoryHandle Pin() => m.Pin();

	/// <summary>Gets the reduced row echelon form (RREF) of the matrix.</summary>
	/// <returns>The reduced row echelon form (RREF).</returns>
	public Matrix<T> ReducedRowEchelonForm()
	{
		Matrix<T> r = Clone();
		int lead = 0;
		for (int r1 = 0; r1 < r.Rows; r1++)
		{
			if (r.Columns <= lead)
				break;
			int i = r1;
			while (r[i, lead].Equals(T.Zero))
			{
				i++;
				if (r.Rows == i)
				{
					i = r1;
					lead++;
					if (r.Columns == lead)
						break;
				}
			}
			if (r.Columns == lead)
				break;
			T[] temp = new T[r.Columns];
			for (int j = 0; j < r.Columns; j++)
			{
				temp[j] = r[i, j];
				r[i, j] = r[r1, j];
				r[r1, j] = temp[j];
			}
			T div = r[r1, lead];
			for (int j = 0; j < r.Columns; j++)
				r[r1, j] = r[r1, j] / div;
			for (int j = 0; j < r.Rows; j++)
			{
				if (j != r1)
				{
					T sub = r[j, lead];
					for (int k = 0; k < r.Columns; k++)
						r[j, k] = r[j, k] - sub * r[r1, k];
				}
			}
			lead++;
		}
		return r;
	}
	/// <summary>Rows the vector.</summary>
	/// <param name="row">The row.</param>
	/// <returns></returns>
	/// <exception cref="System.ArgumentOutOfRangeException">row</exception>
	public Matrix<T> RowVector(int row)
	{
		CheckValidRow(row);
		Memory<T> rowVector = new T[Columns];
		m.Slice(row * Columns, Columns).CopyTo(rowVector);
		return new(rowVector, 1, Columns);
	}

	/// <summary>Gets a submatrix of current matrix keeping only the specified rows and columns.</summary>
	/// <param name="rowsToKeep">The rows to keep.</param>
	/// <param name="columnsToKeep">The columns to keep.</param>
	/// <returns>A submatrix of current matrix with only the specified rows and columns.</returns>
	public Matrix<T> Submatrix(IEnumerable<Range> rowsToKeep, IEnumerable<Range> columnsToKeep)
	{
		int rows = 0, columns = 0;
		foreach (Range range in rowsToKeep ?? [])
			rows += range.GetOffsetAndLength(Rows).Length + 1;
		foreach (Range range in columnsToKeep ?? [])
			columns += range.GetOffsetAndLength(Columns).Length + 1;
		Memory<T> submatrix = new T[rows * columns];
		Span<T> sp = submatrix.Span;
		int a = 0;
		foreach (Range range in rowsToKeep ?? [])
		{
			(int offset, int length) = range.GetOffsetAndLength(Rows);
			for (int i = 0; i <= length; i++)
			{
				int b = 0;
				foreach (Range range2 in columnsToKeep ?? [])
				{
					(int offset2, int length2) = range2.GetOffsetAndLength(Columns);
					for (int j = 0; j <= length2; j++)
					{
						sp[a * columns + b] = m.Span[offset * Columns + offset2];
						b++;
						offset2++;
					}
				}
				a++;
				offset++;
			}
		}
		return new(submatrix, rows, columns);
	}

	/// <inheritdoc/>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override string ToString() => ToString(null, CultureInfo.CurrentCulture);

	/// <summary>Returns the string representation of the current instance using the specified format string to format individual elements.</summary>
	/// <param name="format">A standard or custom numeric format string that defines the format of individual elements.</param>
	/// <returns>The string representation of the current instance.</returns>
	/// <remarks>This method returns a string in which each element of the vector is formatted using <paramref name="format" /> and the current culture's formatting conventions. The "&lt;" and "&gt;" characters are used to begin and end the string, and the current culture's <see cref="System.Globalization.NumberFormatInfo.NumberGroupSeparator" /> property followed by a space is used to separate each element.</remarks>
	/// <related type="Article" href="/dotnet/standard/base-types/standard-numeric-format-strings">Standard Numeric Format Strings</related>
	/// <related type="Article" href="/dotnet/standard/base-types/custom-numeric-format-strings">Custom Numeric Format Strings</related>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public string ToString(string? format) => ToString(format, CultureInfo.CurrentCulture);

	/// <summary>Returns the string representation of the current instance using the specified format string to format individual elements and the specified format provider to define culture-specific formatting.</summary>
	/// <param name="format">A standard or custom numeric format string that defines the format of individual elements.</param>
	/// <param name="formatProvider">A format provider that supplies culture-specific formatting information.</param>
	/// <returns>The string representation of the current instance.</returns>
	/// <remarks>This method returns a string in which each element of the vector is formatted using <paramref name="format" /> and <paramref name="formatProvider" />. The "&lt;" and "&gt;" characters are used to begin and end the string, and the format provider's <see cref="System.Globalization.NumberFormatInfo.NumberGroupSeparator" /> property followed by a space is used to separate each element.</remarks>
	/// <related type="Article" href="/dotnet/standard/base-types/custom-numeric-format-strings">Custom Numeric Format Strings</related>
	/// <related type="Article" href="/dotnet/standard/base-types/standard-numeric-format-strings">Standard Numeric Format Strings</related>
	public string ToString(string? format, IFormatProvider? formatProvider)
	{
		StringBuilder sb = new();
		string separator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator + ' ';
		sb.AppendLine("{");
		foreach (Memory<T> row in this)
			sb.AppendFormat(formatProvider, " {{ {0} }}\n", string.Join(separator, row.ToArray()));
		sb.Append('}');
		return sb.ToString();
	}

	/// <summary>Transposes this instance.</summary>
	/// <returns></returns>
	public Matrix<T> Transpose()
	{
		Memory<T> transpose = new T[m.Length];
		Span<T> sp = transpose.Span;
		for (int i = 0; i < Rows; i++)
		{
			for (int j = 0; j < Columns; j++)
				sp[j * Rows + i] = m.Span[i * Columns + j];
		}
		return new(transpose, Columns, Rows);
	}

	/// <summary>Performs an action on each matching element in two matrices and returns the resulting matrix.</summary>
	/// <param name="a">The first matrix.</param>
	/// <param name="b">The second matrix.</param>
	/// <param name="action">The action to perform on the paired elements from <paramref name="a"/> and <paramref name="b"/>.</param>
	/// <returns>The resulting matrix.</returns>
	/// <exception cref="System.ArgumentException">The number of rows and columns must be equal.</exception>
	protected static Matrix<T> BinaryAction(Matrix<T> a, Matrix<T> b, Func<T, T, T> action)
	{
		ArgumentNullException.ThrowIfNull(a);
		ArgumentNullException.ThrowIfNull(b);
		ArgumentNullException.ThrowIfNull(action);
		if (a.Rows != b.Rows || a.Columns != b.Columns)
			throw new ArgumentException("The number of rows and columns must be equal.");
		Memory<T> dup = new T[a.m.Length];
		Span<T> sp = dup.Span, spa = a.m.Span, spb = b.m.Span;
		for (int i = 0; i < sp.Length; i++)
			sp[i] = action(spa[i], spb[i]);
		return new(dup, a.Rows, a.Columns);
	}

	/// <summary>Gets the element at the specified indices without bounds checking.</summary>
	/// <param name="row">The row.</param>
	/// <param name="column">The column.</param>
	/// <returns>The element at the specified indices.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	protected T GetUnchecked(int row, int column) => m.Span[row * Columns + column];

	/// <summary>Performs an action on each element in a matrix and returns the resulting matrix.</summary>
	/// <param name="value">The source matrix.</param>
	/// <param name="action">The action to perform on the elements from <paramref name="value"/>.</param>
	/// <returns>The resulting matrix.</returns>
	protected static Matrix<T> UnaryAction(Matrix<T> value, Func<T, T> action)
	{
		ArgumentNullException.ThrowIfNull(action);
		Memory<T> dup = value?.m.ToArray() ?? throw new ArgumentNullException(nameof(value));
		Span<T> sp = dup.Span;
		for (int i = 0; i < sp.Length; i++)
			sp[i] = action(sp[i]);
		return new(dup, value.Rows, value.Columns);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void CheckSquare()
	{
		if (!IsSquare)
			throw new InvalidOperationException("The matrix must be square.");
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void CheckValidColumn(int column)
	{
		if (column < 0 || column >= Columns)
			throw new ArgumentOutOfRangeException(nameof(column));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void CheckValidRow(int row)
	{
		if (row < 0 || row >= Rows)
			throw new ArgumentOutOfRangeException(nameof(row));
	}
}
#endif