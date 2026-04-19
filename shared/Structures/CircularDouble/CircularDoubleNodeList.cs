namespace shared.Structures.CircularDouble;

public class CircularDoubleNodeList<T>
{
    public CircularDoubleNode<T>? Head { get; private set; }

    public void AddLast(T item)
    {
        var newNode = new CircularDoubleNode<T>(item);
        if (Head == null)
        {
            Head = newNode;
            Head.Next = Head;
            Head.Previous = Head;
        }
        else
        {
            var tail = Head.Previous;
            tail!.Next = newNode;
            newNode.Previous = tail;
            newNode.Next = Head;
            Head.Previous = newNode;
        }
    }
}