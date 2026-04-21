using shared.Structures.Simple;
using shared.Structures.Double;
using shared.Structures.Circular;
using shared.Structures.CircularDouble;
using System.Text.Json;
using System.Diagnostics;

namespace shared;

public class DataTransformer
{
    public static NodeList<T> ToSimpleList<T>(string jsonResponse)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
        };
        try
        {
            T[]? tempArray = JsonSerializer.Deserialize<T[]>(jsonResponse, options);
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
        catch (JsonException ex)
        {
            Debug.WriteLine($"Fallo crítico en deserialización: {ex.Message}");
            throw;
        }
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
    public static NodeList<string> EnumToNodeList<T>() where T : Enum
    {
        NodeList<string> list = new();

        Array values = Enum.GetValues(typeof(T));

        foreach (var value in values)
        {
            list.AddLast(value.ToString()!);
        }

        return list;
    }
    public static NodeList<EnumDisplayItem> EnumToNodeList<T>(Func<T, string> formatter) where T : struct, Enum
    {
        NodeList<EnumDisplayItem> list = new();

        T[] values = Enum.GetValues<T>();

        foreach (var value in values)
        {
            string displayName = formatter(value);
            list.AddLast(new EnumDisplayItem(value, displayName));
        }

        return list;
    }
}
