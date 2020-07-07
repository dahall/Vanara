using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
    /// <summary>
    /// Enumerator with zero copy access using ref.
    /// </summary>
    public unsafe ref struct RefEnumerator<T> where T : unmanaged
    {
        private T* _arrayPtr;
        private readonly int _count;
        private int _index;

        /// <summary>
        /// Create RefEnumerator.
        /// </summary>
        /// <param name="arrayPtr">Pointer to unmanaged array</param>
        /// <param name="count">Number of elements in the <paramref name="arrayPtr"/></param>
        public RefEnumerator(T* arrayPtr, int count)
        {
            _arrayPtr = arrayPtr;
            _count = count;
            _index = -1;
        }

        /// <summary>
        /// Move to next element.
        /// </summary>
        public bool MoveNext()
        {
            int index = _index + 1;
            if (index < _count)
            {
                _index = index;
                _arrayPtr++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Return current element.
        /// </summary>
        public ref T Current => ref *_arrayPtr;
    }
}
