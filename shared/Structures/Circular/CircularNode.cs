namespace shared.Structures.Circular;

public class CircularNode<T>
{
    public T Data { get; set; }
    public CircularNode<T>? Next { get; set; }

    public CircularNode(T data) => Data = data;
}
