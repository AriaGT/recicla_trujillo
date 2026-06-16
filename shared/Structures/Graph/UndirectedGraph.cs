using shared.Structures.Queue;

namespace shared.Structures.Graph;

// Undirected graph represented with an adjacency list.
// Each edge connects two vertices in both directions.
public class UndirectedGraph<T> where T : notnull
{
    private readonly Dictionary<T, List<T>> _adjacency = new();

    public int VertexCount => _adjacency.Count;

    public void AddVertex(T vertex)
    {
        if (!_adjacency.ContainsKey(vertex))
            _adjacency[vertex] = new List<T>();
    }

    public void AddEdge(T origin, T destination)
    {
        AddVertex(origin);
        AddVertex(destination);

        if (!_adjacency[origin].Contains(destination))
            _adjacency[origin].Add(destination);
        if (!_adjacency[destination].Contains(origin))
            _adjacency[destination].Add(origin);
    }

    public List<T> Neighbors(T vertex)
    {
        return _adjacency.TryGetValue(vertex, out var list)
            ? new List<T>(list)
            : new List<T>();
    }

    // Breadth-first search using the generic LinkedQueue: returns the vertices
    // reachable from the origin in the order they are visited.
    public List<T> BreadthFirstSearch(T origin)
    {
        var visited = new List<T>();
        if (!_adjacency.ContainsKey(origin))
            return visited;

        var marked = new HashSet<T>();
        var queue = new LinkedQueue<T>();

        queue.Enqueue(origin);
        marked.Add(origin);

        while (!queue.IsEmpty())
        {
            var current = queue.Dequeue();
            visited.Add(current);

            foreach (var neighbor in _adjacency[current])
            {
                if (marked.Add(neighbor))
                    queue.Enqueue(neighbor);
            }
        }

        return visited;
    }
}
