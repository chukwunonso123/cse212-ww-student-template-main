using System;
using System.Collections.Generic;

/// <summary>
/// A basic implementation of a FIFO Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the end of the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        _queue.Add(person); // Add to the end (back)
    }

    /// <summary>
    /// Remove the person from the front of the queue
    /// </summary>
    /// <returns>The person who was at the front</returns>
    public Person Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Cannot dequeue from an empty queue.");
        }

        var person = _queue[0]; // Get the first person
        _queue.RemoveAt(0);     // Remove from the front
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
