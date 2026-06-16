namespace shared.Structures.Stack;

// Generic stack (LIFO) backed by linked nodes. Push/Pop/Peek run in O(1).
// Named LinkedStack (not Stack<T>) to avoid colliding with System.Collections.Generic.Stack<T>.
public class LinkedStack<T>
{
    private Node? _top;

    public int Count { get; private set; }

    public bool IsEmpty() => _top == null;

    public void Push(T value)
    {
        _top = new Node(value, _top);
        Count++;
    }

    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("The stack is empty.");

        var current = _top!;
        _top = current.Next;
        Count--;
        return current.Value;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("The stack is empty.");

        return _top!.Value;
    }

    public void Clear()
    {
        _top = null;
        Count = 0;
    }

    public T[] ToArray()
    {
        var array = new T[Count];
        var current = _top;
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
        public Node? Next { get; }
        public Node(T value, Node? next)
        {
            Value = value;
            Next = next;
        }
    }
}
