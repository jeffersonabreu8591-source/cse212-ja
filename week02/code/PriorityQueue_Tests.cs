using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
 // Scenario: Add multiple items with different priorities
 // Expected Result: The item with the highest priority is removed first
 // Defect(s) Found: Dequeue does not correctly remove the highest priority item
public void TestPriorityQueue_HighestPriority()
{
    var priorityQueue = new PriorityQueue();

    priorityQueue.Enqueue("Low", 1);
    priorityQueue.Enqueue("Medium", 5);
    priorityQueue.Enqueue("High", 10);

    var result = priorityQueue.Dequeue();

    Assert.AreEqual("High", result);
}


    [TestMethod]
 // Scenario: Add multiple items with the same highest priority
 // Expected Result: The first item added with that priority is removed first (FIFO)
 // Defect(s) Found: FIFO order is not preserved for equal priorities
public void TestPriorityQueue_SamePriorityFIFO()
{
    var priorityQueue = new PriorityQueue();

    priorityQueue.Enqueue("First", 10);
    priorityQueue.Enqueue("Second", 10);
    priorityQueue.Enqueue("Third", 5);

    var result = priorityQueue.Dequeue();

    Assert.AreEqual("First", result);
}


    // Add more test cases as needed below.

    [TestMethod]
 // Scenario: Attempt to dequeue from an empty queue
 // Expected Result: InvalidOperationException with correct message
 // Defect(s) Found: No exception or incorrect exception message
public void TestPriorityQueue_Empty()
{
    var priorityQueue = new PriorityQueue();

    try
    {
        priorityQueue.Dequeue();
        Assert.Fail("Exception should have been thrown.");
    }
    catch (InvalidOperationException e)
    {
        Assert.AreEqual("The queue is empty.", e.Message);
    }
}

}