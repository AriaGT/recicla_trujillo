namespace shared.Structures.CircularDouble;

public class CircularDoubleNode<T>
{
    public T Data { get; set; }
    public CircularDoubleNode<T>? Next { get; set; }
    public CircularDoubleNode<T>? Previous { get; set; }

    public CircularDoubleNode(T data) => Data = data;
}