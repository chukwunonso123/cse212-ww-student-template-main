using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities and dequeue the highest.
    // Expected Result: The item with the highest priority ("High") should be returned.
    // Defect(s) Found:FIXED — Original code failed if high-priority item was last in the list.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);

        string result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority. Dequeue should return the first inserted item.
    // Expected Result: The first "High1" should be returned before "High2".
    // Defect(s) Found:FIXED — Original code incorrectly used >=, breaking FIFO order for ties.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("High1", 10);
        priorityQueue.Enqueue("High2", 10);

        string first = priorityQueue.Dequeue();
        string second = priorityQueue.Dequeue();

        Assert.AreEqual("High1", first);
        Assert.AreEqual("High2", second);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: Should throw InvalidOperationException.
    // Defect(s) Found: No defect found.
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_Empty_Throws()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }
}
