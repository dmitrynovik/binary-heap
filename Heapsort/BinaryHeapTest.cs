using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace DataStructures.BinaryHeap
{
    [TestFixture]
    public class BinaryHeapTest
    {
        [Test]
        public void Index_Even_Produces_Correct_Parent_Left_Right()
        {
            var self = 2;
            using (new AssertionScope())
            {
                Heap<int>.GetParentIndex(self).Should().Be(0);
                Heap<int>.GetLeftIndex(self).Should().Be(5);
                Heap<int>.GetRightIndex(self).Should().Be(6);
            }
        }

        [Test]
        public void Index_Odd_Produces_Correct_Parent_Left_Right()
        {
            var self = 1;
            using (new AssertionScope())
            {
                Heap<int>.GetParentIndex(self).Should().Be(0);
                Heap<int>.GetLeftIndex(self).Should().Be(3);
                Heap<int>.GetRightIndex(self).Should().Be(4);
            }
        }

        [Test]
        public void Heapify()
        {
            var heap = new Heap<int>(new[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 });
            heap.Items.Should().BeEquivalentTo(new[] { 16, 14, 10, 8, 7, 9, 3, 2, 4, 1 });
        }

        [Test]
        public void Heapsort()
        {
            var heap = new Heap<int>(new[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 });
            heap.Sort();
            heap.Items.Should().BeEquivalentTo(new[] { 16, 14, 10, 9, 8, 7, 4, 3, 2, 1 });
        }
    }
}
