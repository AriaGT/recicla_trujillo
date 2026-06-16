namespace shared.Structures.Queue;

// Generic queue (FIFO) backed by linked nodes with front/back pointers. Operations run in O(1).
// Named LinkedQueue (not Queue<T>) to avoid colliding with System.Collections.Generic.Queue<T>.
public class LinkedQueue<T>
{
    private Node? _front;
    private Node? _back;

    public int Count { get; private set; }

    public bool IsEmpty() => _front == null;

    public void Enqueue(T value)
    {
        var node = new Node(value);
        if (IsEmpty())
        {
            _front = node;
            _back = node;
        }
        else
        {
            _back!.Next = node;
            _back = node;
        }
        Count++;
    }

    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("The queue is empty.");

        var current = _front!;
        _front = current.Next;
        if (_front == null)
            _back = null;
        Count--;
        return current.Value;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("The queue is empty.");

        return _front!.Value;
    }

    public void Clear()
    {
        _front = null;
        _back = null;
        Count = 0;
    }

    public T[] ToArray()
    {
        var array = new T[Count];
        var current = _front;
        var index = 0;
        while (current != null)
        {
            array[index++] = current.Value;
            current = current.Next;
        }
        return array;
    }

    private sealed class Node
    {
        public T Value { get; }
        public Node? Next { get; set; }
        public Node(T value) => Value = value;
    }
}
