namespace shared.Structures.Simple;

public class NodeList<T>
{
    public Node<T>? Head { get; private set; }

    public void AddLast(T item)
    {
        var newNode = new Node<T>(item);
        if (Head == null) Head = newNode;
        else
        {
            var current = Head;
            while (current.Next != null) current = current.Next;
            current.Next = newNode;
        }
    }
}