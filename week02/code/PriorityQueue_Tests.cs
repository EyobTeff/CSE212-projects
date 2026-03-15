using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue Bob(1), Tim(5), Sue(3). Dequeue three times.
    // Expected Result: Dequeue order should be Tim, Sue, Bob.
    // Defect(s) Found: The highest-priority item was not removed from the queue, causing repeated returns of the same value.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);

        Assert.AreEqual("Tim", priorityQueue.Dequeue());
        Assert.AreEqual("Sue", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A(4), B(4), C(2). Dequeue three times.
    // Expected Result: For equal highest priority, the front-most item is removed first: A, then B, then C.
    // Defect(s) Found: Tie handling selected the most recently seen equal-priority item rather than FIFO order.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 4);
        priorityQueue.Enqueue("B", 4);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Enqueue A(1), B(2), C(10). Dequeue once.
    // Expected Result: C is removed first because it has the highest priority, even when it is at the back of the queue.
    // Defect(s) Found: The last element was skipped during highest-priority search, so the true highest-priority item at the back was not selected.
    public void TestPriorityQueue_HighestAtBack()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 10);

        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown with message "The queue is empty.".
    // Defect(s) Found: No defect found once exception behavior matched the requirement.
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}