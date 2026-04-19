using shared.Structures.Simple;
using shared.Structures.Double;
using shared.Structures.Circular;
using shared.Structures.CircularDouble;
using System.Text.Json;

namespace shared;

public class DataTransformer
{
    public static NodeList<T> ToSimpleList<T>(string jsonResponse)
    {
        T[]? tempArray = JsonSerializer.Deserialize<T[]>(jsonResponse);
        NodeList<T> list = new();
        if (tempArray != null)
        {
            foreach (T item in tempArray)
            {
                list.AddLast(item);
            }
        }
        return list;
    }
    public static DoubleNodeList<T> ToDoubleList<T>(string jsonResponse)
    {
        T[]? tempArray = JsonSerializer.Deserialize<T[]>(jsonResponse);
        DoubleNodeList<T> list = new();
        if (tempArray != null)
        {
            foreach (T item in tempArray)
            {
                list.AddLast(item);
            }
        }
        return list;
    }
    public static CircularNodeList<T> ToCircularList<T>(string jsonResponse)
    {
        T[]? tempArray = JsonSerializer.Deserialize<T[]>(jsonResponse);
        CircularNodeList<T> list = new();
        if (tempArray != null)
        {
            foreach (T item in tempArray)
            {
                list.AddLast(item);
            }
        }
        return list;
    }
    public static CircularDoubleNodeList<T> ToCircularDoubleList<T>(string jsonResponse)
    {
        T[]? tempArray = JsonSerializer.Deserialize<T[]>(jsonResponse);
        CircularDoubleNodeList<T> list = new();
        if (tempArray != null)
        {
            foreach (T item in tempArray)
            {
                list.AddLast(item);
            }
        }
        return list;
    }
}
