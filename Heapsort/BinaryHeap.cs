﻿using System;
using System.Linq;
using System.Collections.Generic;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("HeapsortTest")]

namespace DataStructures.BinaryHeap
{
    public class Heap<T> where T: IComparable
    {
        private IList<T> _list;

        private int? _heapSize = null;

        public Heap() {  _list = new List<T>(); }

        public Heap(int capacity) {  _list = new List<T>(capacity); }

        public Heap(IEnumerable<T> items) 
        { 
            _list = new List<T>(items);
            BuildMaxHeap();
        }


        public IEnumerable<T> Items => _list;

        public int HeapSize 
        {
            get =>_heapSize ?? _list.Count;
            set 
            {
                if (value > _heapSize)
                {
                    var tmp = new List<T>(value);
                    for (var i = 0; i < _heapSize; ++i)
                        tmp[i] = _list[i];

                    _list = tmp;
                }
                _heapSize = value;
            }
        }

        public void Sort()
        {
            for (var i = HeapSize - 1; i > 0; i--, HeapSize = HeapSize - 1)
            {
                var tmp = _list[0];
                _list[0] = _list[i];
                _list[i] = tmp;


                Heapify(0);                
            }
        }

        public T GetParent(int i) => i == 0 ? default(T) : _list[GetParentIndex(i)];

        public T GetLeft(int i) => GetAt(GetLeftIndex(i));

        public T GetRight(int i) => GetAt(GetRightIndex(i));


        internal static int GetParentIndex(int i) => (i - 1) >> 1;

        internal static int GetLeftIndex(int i) => (i << 1) + 1;

        internal static int GetRightIndex(int i) => (i << 1) + 2;

        private T GetAt(int index) => index < _list.Count ? _list[index] : default(T);

        private void BuildMaxHeap()
        {
            for (var i = 0; i < HeapSize / 2; ++i)
                Heapify(i);
        }

        internal void Heapify(int i)
        {
            var max = GetAt(i);
            var current = max;
            var maxIndex = i;

            var leftIndex = GetLeftIndex(i);
            if (leftIndex < HeapSize)
            {
                var left = GetLeft(i);
                if (left.CompareTo(max) > 0)
                {
                    max = left;
                    maxIndex = leftIndex;
                }
            }

            var rightIndex = GetRightIndex(i);
            if (rightIndex < HeapSize)
            {
                var right = GetRight(i);
                if (right.CompareTo(max) > 0)
                {
                    max = right;
                    maxIndex = rightIndex;
                }
            }

            if (maxIndex != i)
            {
                // swap:
                _list[i] = max;
                _list[maxIndex] = current;

                Heapify(maxIndex);
            }
        }
    }
}
