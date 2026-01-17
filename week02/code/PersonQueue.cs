/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
{
    //_queue.Insert(0, person);this was adding at the beggining of the list

    // Ad to the back of the queue (FIFO)
    _queue.Add(person);
}

public Person Dequeue()
{
    //_queue.RemoveAt(0);

    // Remove from the Front of the queue
    var person = _queue[0];
    _queue.RemoveAt(0);
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