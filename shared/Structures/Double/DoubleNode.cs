namespace shared.Structures.Double;

public class DoubleNode<T>
{
    public T Data { get; set; }
    public DoubleNode<T>? Next { get; set; }
    public DoubleNode<T>? Previous { get; set; }

    public DoubleNode(T data) { Data = data; }
}
