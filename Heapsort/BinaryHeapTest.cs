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
                BinaryHeap<int>.GetParentIndex(self).Should().Be(0);
                BinaryHeap<int>.GetLeftIndex(self).Should().Be(5);
                BinaryHeap<int>.GetRightIndex(self).Should().Be(6);
            }
        }

        [Test]
        public void Index_Odd_Produces_Correct_Parent_Left_Right()
        {
            var self = 1;
            using (new AssertionScope())
            {
                BinaryHeap<int>.GetParentIndex(self).Should().Be(0);
                BinaryHeap<int>.GetLeftIndex(self).Should().Be(3);
                BinaryHeap<int>.GetRightIndex(self).Should().Be(4);
            }
        }
    }
}
