using shared.Structures.Simple;

namespace shared.Structures.Tree;

public class BinarySearchTree<T>
{
    private TreeNode<T>? _root;

    public bool IsEmpty() => _root == null;

    public void Clear() => _root = null;

    public void Insert(T value, Comparison<T> comparer)
    {
        _root = Insert(_root, value, comparer);
    }

    private static TreeNode<T> Insert(TreeNode<T>? node, T value, Comparison<T> comparer)
    {
        if (node == null)
            return new TreeNode<T>(value);

        var result = comparer(value, node.Value);
        if (result < 0)
            node.Left = Insert(node.Left, value, comparer);
        else if (result > 0)
            node.Right = Insert(node.Right, value, comparer);

        return node;
    }

    public T? Search(T value, Comparison<T> comparer, ref int comparisons, ref bool found)
    {
        comparisons = 0;
        found = false;

        var current = _root;
        while (current != null)
        {
            comparisons++;
            var result = comparer(value, current.Value);
            if (result == 0)
            {
                found = true;
                return current.Value;
            }
            current = result < 0 ? current.Left : current.Right;
        }

        return default;
    }

    public NodeList<T> InOrderTraversal()
    {
        var list = new NodeList<T>();
        InOrderTraversal(_root, list);
        return list;
    }

    private static void InOrderTraversal(TreeNode<T>? node, NodeList<T> list)
    {
        if (node == null)
            return;
        InOrderTraversal(node.Left, list);
        list.AddLast(node.Value);
        InOrderTraversal(node.Right, list);
    }
}
