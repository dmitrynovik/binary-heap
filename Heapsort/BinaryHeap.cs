using System.Collections.Generic;

namespace DataStructures.BinaryHeap
{
    public class BinaryHeap<T>
    {
        private IList<T> _list;


        public BinaryHeap() {  _list = new List<T>(); }

        public BinaryHeap(int capacity) {  _list = new List<T>(capacity); }

        public int HeapSize => _list.Count;

        public T GetParent(int i) => i == 0 ? default(T) : _list[GetParentIndex(i)];

        public T GetLeft(int i) => GetAt(GetLeftIndex(i));

        public T GetRight(int i) => GetAt(GetRightIndex(i));


        internal static int GetParentIndex(int i) => (i - 1) >> 1;

        internal static int GetLeftIndex(int i) => (i << 1) + 1;

        internal static int GetRightIndex(int i) => (i << 1) + 2;

        private T GetAt(int index) => index < _list.Count ? _list[index] : default(T);
    }
}
