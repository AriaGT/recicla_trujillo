namespace shared.Structures.Double;

public class DoubleNodeList<T>
{
    public DoubleNode<T>? Head { get; private set; }
    public DoubleNode<T>? Tail { get; private set; }

    public void AddLast(T item)
    {
        var newNode = new DoubleNode<T>(item);
        if (Head == null)
        {
            Head = Tail = newNode;
        }
        else
        {
            Tail!.Next = newNode;
            newNode.Previous = Tail;
            Tail = newNode;
        }
    }
}
