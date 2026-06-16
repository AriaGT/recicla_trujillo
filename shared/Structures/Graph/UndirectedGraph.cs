using shared.Structures.Queue;
using shared.Structures.Simple;

namespace shared.Structures.Graph;

public class UndirectedGraph<T> where T : notnull
{
    private AdjacencyNode? _head;
    private int _vertexCount;

    public int VertexCount => _vertexCount;

    public void AddVertex(T vertex)
    {
        if (Find(vertex) != null) return;
        _head = new AdjacencyNode(vertex) { Next = _head };
        _vertexCount++;
    }

    public void AddEdge(T origin, T destination)
    {
        AddVertex(origin);
        AddVertex(destination);

        var o = Find(origin)!;
        var d = Find(destination)!;

        if (!Contains(o.Neighbors, destination))
            o.Neighbors.AddLast(destination);
        if (!Contains(d.Neighbors, origin))
            d.Neighbors.AddLast(origin);
    }

    public T[] Neighbors(T vertex)
    {
        var entry = Find(vertex);
        return entry == null ? new T[0] : ToArray(entry.Neighbors);
    }

    public T[] BreadthFirstSearch(T origin)
    {
        if (Find(origin) == null) return new T[0];

        var queue = new LinkedQueue<T>();
        var marked = new NodeList<T>();
        var resultQueue = new LinkedQueue<T>();

        queue.Enqueue(origin);
        marked.AddLast(origin);

        while (!queue.IsEmpty())
        {
            var current = queue.Dequeue();
            resultQueue.Enqueue(current);

            var entry = Find(current);
            if (entry == null) continue;

            var neighbor = entry.Neighbors.Head;
            while (neighbor != null)
            {
                if (!Contains(marked, neighbor.Data))
                {
                    marked.AddLast(neighbor.Data);
                    queue.Enqueue(neighbor.Data);
                }
                neighbor = neighbor.Next;
            }
        }

        return resultQueue.ToArray();
    }

    private AdjacencyNode? Find(T vertex)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Vertex.Equals(vertex)) return current;
            current = current.Next;
        }
        return null;
    }

    private static bool Contains(NodeList<T> list, T value)
    {
        var current = list.Head;
        while (current != null)
        {
            if (current.Data.Equals(value)) return true;
            current = current.Next;
        }
        return false;
    }

    private static T[] ToArray(NodeList<T> list)
    {
        int count = 0;
        var current = list.Head;
        while (current != null) { count++; current = current.Next; }

        var array = new T[count];
        current = list.Head;
        int i = 0;
        while (current != null) { array[i++] = current.Data; current = current.Next; }
        return array;
    }

    private sealed class AdjacencyNode
    {
        public T Vertex { get; }
        public NodeList<T> Neighbors { get; } = new();
        public AdjacencyNode? Next { get; set; }
        public AdjacencyNode(T vertex) => Vertex = vertex;
    }
}
