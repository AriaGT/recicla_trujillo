namespace shared.Structures.Circular;

public class CircularNodeList<T>
{
    public CircularNode<T>? Head { get; private set; }
    private CircularNode<T>? _tail;

    public void AddLast(T item)
    {
        var newNode = new CircularNode<T>(item);
        if (Head == null)
        {
            Head = newNode;
            newNode.Next = Head;
            _tail = newNode;
        }
        else
        {
            _tail!.Next = newNode;
            _tail = newNode;
            _tail.Next = Head;
        }
    }
}
