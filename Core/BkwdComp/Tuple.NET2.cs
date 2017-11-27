#if (NET20 || NET35)

namespace System
{
    /// <summary>Represents a 2-tuple, or pair.</summary>
    /// <typeparam name="T1">The type of the tuple's first component.</typeparam>
    /// <typeparam name="T2">The type of the tuple's second component.</typeparam>
    [Serializable]
    public class Tuple<T1, T2>
    {
        private readonly T1 m_Item1;
        private readonly T2 m_Item2;

        /// <summary>Initializes a new instance of the <see cref="Tuple{T1, T2}"/> class.</summary>
        /// <param name="item1">The value of the tuple's first component.</param>
        /// <param name="item2">The value of the tuple's second component.</param>
        public Tuple(T1 item1, T2 item2) { m_Item1 = item1; m_Item2 = item2; }

        /// <summary>Gets the value of the current <see cref="Tuple{T1, T2}"/> object's first component.</summary>
        /// <value>The value of the current <see cref="Tuple{T1, T2}"/> object's first component.</value>
        public T1 Item1 => m_Item1;

        /// <summary>Gets the value of the current <see cref="Tuple{T1, T2}"/> object's second component.</summary>
        /// <value>The value of the current <see cref="Tuple{T1, T2}"/> object's second component.</value>
        public T2 Item2 => m_Item2;

        /// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString() => $"({m_Item1}, {m_Item2})";
    }
}

#endif